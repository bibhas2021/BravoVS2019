using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
//Bibhas
using Edpcom;
using System.IO;

namespace FirstTimeNeed
{
    public class clsfirsttime
    {
        SqlCommand cmd;
        //first time two data base
        public bool database_creation(string path, SqlConnection con, String Dbname)
        {
            string strdb = "IF EXISTS (SELECT name FROM sysdatabases WHERE name ='" + Dbname + "') drop database [" + Dbname + "]";
            // string strdb = "drop database [" + Dbname + "]";
            cmd = new SqlCommand(strdb, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            strdb = "";
            strdb = strdb + "CREATE DATABASE [" + Dbname + "]";
            //strdb = strdb + "ON";
            //strdb = strdb + "(NAME = '" + Dbname + "',";
            //strdb = strdb + "FILENAME = '" + path + "\\" + Dbname + ".mdf' , ";
            //strdb = strdb + " SIZE = 100,FILEGROWTH = 10%)";
            //strdb = strdb + " LOG ON";
            //strdb = strdb + " (NAME = '" + Dbname + "_Log',";
            //strdb = strdb + " FILENAME = '" + path + "\\" + Dbname + "_log.ldf' ,";
            //strdb = strdb + " SIZE = 100,FILEGROWTH = 10%)";
            cmd = new SqlCommand(strdb, con);
            try
            {
                cmd.ExecuteNonQuery();
                strdb = "";
                strdb = "CREATE LOGIN edp" + "\r\n";
                strdb = strdb + " WITH PASSWORD =N'2477147edp', CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;;" + "\r\n";
                strdb = strdb + " USE [" + Dbname + "]" + "\r\n";
                strdb = strdb + " CREATE USER edp FOR LOGIN edp;" + "\r\n";
                strdb = strdb + " USE [" + Dbname + "]" + "\r\n";
                strdb = strdb + " EXEC sp_addrolemember N'db_owner', N'edp'" + "\r\n";
                cmd = new SqlCommand(strdb, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool use_db(SqlConnection con, string dbname)
        {
            string strusedb = "USE [" + dbname + "]";
            SqlCommand cmd = new SqlCommand(strusedb, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool db_attach(SqlConnection con, string path, string dbname)
        {
            try
            {
                string strdb = "IF EXISTS (SELECT name FROM sysdatabases WHERE name ='" + dbname + "') drop database [" + dbname + "]";
                // string strdb = "drop database [" + Dbname + "]";
                cmd = new SqlCommand(strdb, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                con.Open();
                strdb = "sp_attach_db";
                cmd = new SqlCommand(strdb, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter DBname = new SqlParameter("@dbname", dbname);
                SqlParameter mdfname = new SqlParameter("@filename1", Environment.CurrentDirectory + "\\" + dbname + ".mdf");
                SqlParameter ldfname = new SqlParameter("@filename2", Environment.CurrentDirectory + "\\" + dbname + "_log.ldf");
                cmd.Parameters.Add(DBname);
                cmd.Parameters.Add(mdfname);
                cmd.Parameters.Add(ldfname);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); return false;
            }
        }
        
        public bool AccordFour_dbinfo_table_creation(SqlConnection con)
        {
            string strmiddbinfo = "create table ACCORD_DB_INFO(SERIAL_NO varchar(20) not null,MACHINE_NAME varchar(20),";
            strmiddbinfo = strmiddbinfo + "EXE_VERSION varchar(10) not null,BUILD_DATE datetime not null,UPDATED_ON datetime,";
            strmiddbinfo = strmiddbinfo + "primary key(SERIAL_NO,EXE_VERSION,BUILD_DATE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmiddbinfo, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //dutta da start

        public bool AccordFourlog_table_creation(SqlConnection con)
        {
            string strmidlog = "create table AccordFourlog(LOG_UCODE varchar(6) not null,LOG_GCODE char(10) not null,LOG_CCODE char(10) not null,AUTOINCRE int IDENTITY(1,1) not null,";
            strmidlog = strmidlog + "FORM_NAME varchar(40),FORM_CODE int,DATE_FROM datetime,";
            strmidlog = strmidlog + "TIME_FROM varchar(50),DATE_TO datetime,TIME_TO varchar(50),";
            strmidlog = strmidlog + "LOG_STAT int,MACHINE_NAME varchar(20),Exclusive bit,";
            strmidlog = strmidlog + "session_no int,primary key clustered(LOG_UCODE,LOG_GCODE,LOG_CCODE,AUTOINCRE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //pallabi start
         public bool Access_table_creation(SqlConnection con)
        {
            string straccss = "create table Access(FICode char(10) not null,USER_CODE varchar(6) not null,GCODE char(10) not null,OPTION_STRING varchar(6),";
            straccss = straccss + "ENTRY_OPTION char(2),REPORT_OPTION varchar(5),BRNCH_CODE numeric,";
            straccss = straccss + "RESTRICT_LOCN bit, primary key clustered(FICode ,USER_CODE,GCODE))";

            SqlCommand cmd;
            cmd = new SqlCommand(straccss, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
         }
        public bool AccessBranch_table_creation(SqlConnection con)
        {
            string strmidlog = "create table AccessBranch(USER_CODE varchar(6) not null,FICode char(10) not null,GCODE char(10) not null,BRNCH_CODE numeric(18,0) not null,";
            strmidlog = strmidlog + "primary key clustered(USER_CODE,FICode,GCODE,BRNCH_CODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
           public bool AccPost_table_creation(SqlConnection con)
        {
            string strmidlog = "create table AccPost(FICode char(10) not null,GCODE char(10) not null,T_ENTRY char(2) not null,DESCCODE numeric(18,0) not null,";
            strmidlog = strmidlog + "Sl_No varchar(6) not null,BTerms_Desc varchar(50) null,Term_Type char(1) null,";
            strmidlog = strmidlog + "Tax char(10) null,Glcode varchar(6) null,Formula varchar(20) null,Type_Code numeric(18,0) null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,T_ENTRY,DESCCODE,Sl_No))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
          public bool adles_table_creation(SqlConnection con)
        {
            string strmidlog = "create table adles(FICODE char(10) not null,GCODE char(10) not null,T_ENTRY char(2) not null,VOUCHER numeric(18,0) not null,";
            strmidlog = strmidlog + "AUTOINCRE numeric(18,0) not null,ADDLESSCODE numeric(18,0) not null,PERCENTAGE float null,";
            strmidlog = strmidlog + "ONAMT char(2)not null,DUMMY_FLD char(1) null,AUTO_MANUAL char(1) null,TEMP_DESC varchar(20) null,ADDLESSAMT money null,Tax_Desc varchar(50) null,AddLessDesc varchar(50) null,GlCode numeric (18,0) null,AccessVal money null,";
            strmidlog = strmidlog + "primary key clustered(FICODE,GCODE,T_ENTRY,VOUCHER,AUTOINCRE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool alloc_table_creation(SqlConnection con)
        {
            string strmidlog = "create table alloc(FICODE char(10) not null,GCODE char(10) not null,VOUCHER numeric(18,0) not null,";
            strmidlog = strmidlog + "AUTOINCRE int not null,ALLOC_NO numeric(18,0)  null,ALLOC_DATE datetime not null,";
            strmidlog = strmidlog + "PARTY_CODE numeric(18,0) not null,BT_ENTRY char(2) not null,B_VOUCHER numeric(18,0) not null,B_USER_VCH varchar(25) null,RPT_ENTRY char(2) null,RP_VOUCHER numeric (18,0) null,RP_USER_VCH varchar(25) null,AMT money not null,B_AMT money null,RP_AMT money null,CURR_CODE varchar(6) null,AllocFlg bit null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,VOUCHER,AUTOINCRE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Autogen_table_creation(SqlConnection con)
        {
            string strmidlog = "create table Autogen(prim numeric(18,0) not null,Second numeric(18,0) not null,VOUCHER numeric(18,0) not null)";
            
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Emp_DocumentImage_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Emp_DocumentImage([Sl_no] [numeric](18, 0) IDENTITY(1,1) NOT NULL,[ID] [varchar](50) NULL,[Document_Type] [numeric](18, 0) NULL,[Document_Image] [varbinary](max) NULL,[Temp_Image] [varchar](max) NULL)";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool bill_table_creation(SqlConnection con)
        {
            string strmidlog = "create table bill(FICODE char(10) not null,GCODE char(10) not null,T_ENTRY char(2) not null,VOUCHER numeric(18,0) not null,";
            strmidlog = strmidlog + "AUTOINCRE int not null,BILLNO varchar(50)  null,BILLDATE datetime null,";
            strmidlog = strmidlog + "PARTYCODE numeric(18,0) not null,DB_CR char(1) not null,DUEDATE datetime  null,BILLAMT money null,BALAMT  money null,CFORMNO varchar(25) null,CFORMNAME varchar(15) null,C_T_ENTRY char(2) null,C_VOUCHER numeric(18,0) null,C_USER_VCH varchar(50)null,O_T_ENTRY char(2) null,SERVICE bit null,O_VOUCHER numeric(18,0) null,O_USER_VCH varchar(50) null,CREDIT bit null,REF_VOUCHER numeric (18,0) null,REF_USER_VCH varchar(50) null,CURR_CODE numeric (18,0) null,BRNCH_CODE numeric (18,0) null,NCONV_STR float null,DCONV_STR float null,PRO_STATUS bit null,BC_TENTRY char(2) null,BC_VOUCHER numeric (18,0) null,FC_BALAMT money null,FC_BILLAMT money null,BROKER_CODE numeric (18,0) null,TRN_BAL money null,FC_TRN_BAL money null,BRK_PRCNT money null,MEMO_VCH bit null,REF_TENTRY char(2) null,DESCCODE varchar(6) null,TYPENAME varchar(50) null ,DECSRIPTION varchar(50) null ,";
            strmidlog = strmidlog + "primary key clustered(FICODE,GCODE,T_ENTRY,VOUCHER,AUTOINCRE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool BillTerms_table_creation(SqlConnection con)
        {
            string strmidlog = "create table BillTerms(FICode char(10) not null,GCODE char(10) not null,TERMSTYPE char(1) not null,";
            strmidlog = strmidlog + "Sl_No int not null,Description varchar(50)  null,Types varchar(25) null,";
            strmidlog = strmidlog + "Formula varchar(20)  null,PlusMinus char(10) null,Type_Code numeric(18,0) not null,DefineUnder char(1) null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,TERMSTYPE,Sl_No,Type_Code))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Branch_table_creation(SqlConnection con)
        {
            string strmidlog = "create table Branch(FICode char(10) not null,GCODE char(10) not null,BRNCH_CODE numeric(18,0) not null,BRNCH_NAME varchar(40) null,BRNCH_ADD1 varchar(40) null,BRNCH_ADD2 varchar(40) null,BRNCH_CITY varchar(20) null,BRNCH_STATE varchar(20) null,BRNCH_PIN varchar(10) null, BRNCH_CST varchar(30) null,BRNCH_SST varchar(30) null,BRNCH_TELE1  varchar(20) null,BRNCH_TELE2 varchar(20) null,BRNCH_TELE3 varchar(20) null,BRNCH_PAN1 varchar(30) null,BRNCH_PAN2 varchar(30) null,VAT_DET varchar(25) null,BRNCH_FAX varchar(20) null,BRNCH_EMAIL nvarchar(Max) null,CONTACT_PERSON varchar(20) null,PERSON_DESIG varchar(20) null,FREEZE_FROM datetime null,FREEZE_TO datetime null,COUNTRY varchar(20) null,EX_REG_NO varchar(40) null,EX_DIV varchar(40) null,EX_COMM varchar(40) null,ECC_NO varchar(40) null,EX_RANGE varchar(40) null,Brnch_Alias  varchar(10) null,Stax float null,STT float null,TAN varchar(50) null,STAXNO varchar(50) null,DIN1 varchar(50) null,DIN2 varchar(50) null,DIN3 varchar(50) null,DIN4 varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,BRNCH_CODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool btchtran_table_creation(SqlConnection con)
        {
            string strmidlog = "create table btchtran(FICODE char(10) not null,GCODE char(10) not null,BSTYPE char(1) not null,T_ENTRY char(1) not null,VOUCHER numeric(18,0) not null,PCODE numeric(18,0) not null,AUTOINCRE int not null,BATCHNO varchar(30) null,USER_VCH varchar(25) null, MFG_DATE datetime null,EXP_DATE  datetime null,INOUT  char(1) null,SERFROM varchar(30) null,SERTO varchar(30) null,QTY float not null,QTY2 float null,UCODE varchar(6) not null,STATUS bit null,SWITCH varchar(10) null,RATE float null,RUCODE varchar(6) null,PRATE float null,ITEMNO int null,MRP float null,ED float null,CESS float null,Serial int null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,BRNCH_CODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ccmast_table_creation(SqlConnection con)
        {
            string strmidlog = "create table ccmast(FICODE char(10) not null,GCODE char(10) not null,CC_TYPE char(1) not null,CC_CODE numeric(18,0) not null,CC_DESC varchar(40) not null,PLV_CODE numeric(18,0) not null,CC_LEV int not null,CURBAL money not null,CONS_FLG smallint null, CC_ALIAS varchar(10) null,ALLOW_TRAN  bit not null,Brnch_Code  varchar(6) null,OPBAL float null,SUB_CCTYPE char(1) null,TAX_GRP char(1) null,R_V char(1) null,LOC_TYPE char(1) not null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,CC_TYPE,CC_CODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Company_table_creation(SqlConnection con)
        {
            string strmidlog = "create table Company(CO_CODE char(10) not null,FICode char(10) not null,GCODE char(10) not null,CO_NAME [nvarchar](max) NULL,CO_ADD [nvarchar](max) NULL,CO_ADD1 [nvarchar](max) NULL,CO_SDATE datetime null,CO_EDATE  datetime null,CO_VER varchar(7) null,CO_CDT datetime null, CO_link char(2) null,";
            strmidlog = strmidlog + "primary key clustered(CO_CODE,FICode,GCODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CSTOCK_table_creation(SqlConnection con)
        {
            string strmidlog = "create table CSTOCK(SDate datetime not null,FICode char(20) not null,GCODE char(20) not null,MGROUP int not null,SGROUP int not null,GLCODE numeric(18,0) null,OPAMT numeric(18,3)  null,CLAMT  numeric(18,3)  null,NCONV_FCTR float null,DCONV_FCTR float null, FC_OPAMT numeric(18,3)  null,FC_CLAMT numeric(18,3)  null,CURR_CODE varchar(6) null,";
            strmidlog = strmidlog + "primary key clustered(SDate,FICode,GCODE,MGROUP,SGROUP))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool currency_table_creation(SqlConnection con)
        {
            string strmidlog = "create table currency(FICode char(10) not null,GCODE char(10) not null,CURR_CODE varchar(6) not null,CURR_DESC varchar(20) not null,CURR_STR varchar(10) not null,CURR_SUBSTR varchar(10) not null,NCONV_STR float null,DCONV_STR float null, DFLT_FLG bit  null,CURR_DECIMAL int null,CURR_FORMAT  int null,CURR_NFORMAT  int null,THOU_SEP char(1) null,DEC_SEP char(1) null, ";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,CURR_CODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool data_table_creation(SqlConnection con)
        {
            string strmidlog = "create table data(FICode varchar(10) not null,GCODE varchar(10) not null,T_ENTRY char(2) not null,VOUCHER numeric(18,0) not null,VCHDATE datetime null,USER_VCH varchar(100) null,CURR_CODE numeric(18,0) null,NCONV_STR float null, DCONV_STR float null, BRANCH_CODE numeric(18,0) null,DESCCODE  numeric(18,0) null,View_stat  bit null,linkvoucher numeric(18,0) null,linkTentry char(2) null,PFCode numeric(18,0) null, ";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,T_ENTRY,VOUCHER))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DOCGEN_table_creation(SqlConnection con)
        {
            string strmidlog = "create table DOCGEN(FICode char(10) not null,GCODE char(10) not null,T_ENTRY char(2) not null,DESCCODE numeric(18,0) not null,VOUCHERNO varchar(100) null) ";
           // strmidlog = strmidlog + "primary key clustered(FICode,GCODE,T_ENTRY,DESCCODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool docnumber_table_creation(SqlConnection con)
        {
            string strmidlog = "create table docnumber(FICode char(10) not null,GCODE char(10) not null,T_ENTRY char(2) not null,TYPE_NAME varchar(50) not null,DESCCODE numeric(18,0)  not null,TYPE_DESC char(40) null,METHOD char(1) null,PREPOS char(10) null, SUFPOS char(10) null, padding char(10) null,doc_pos char(10) null,no_sep  char(10) null,prefix char(40) null,suffix char(40) null) ";
            //strmidlog = strmidlog + "primary key clustered(FICode,GCODE,T_ENTRY,TYPE_NAME,DESCCODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DummyWacclog_table_creation(SqlConnection con)
        {
            string strmidlog = "create table DummyWacclog(LOG_UCODE varchar(6) not null,LOG_GCODE char(10) not null,LOG_CCODE char(10) not null,AUTOINCRE int not null,FORM_NAME varchar(40) not null,FORM_CODE int null,DATE_FROM datetime null,TIME_FROM datetime null,DATE_TO datetime null, TIME_TO datetime null, LOG_STAT int null,MACHINE_NAME varchar(20) null,Exclusive  bit null,session_no int null, ";
            strmidlog = strmidlog + "primary key clustered(LOG_UCODE,LOG_GCODE,LOG_CCODE,AUTOINCRE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
      
        public bool FICODEGEN_table_creation(SqlConnection con)
        {
            string strmidlog = "create table FICODEGEN(Start_Date datetime not null,End_Date datetime not null,FICode char(10) not null,";
            strmidlog = strmidlog + "primary key clustered(Start_Date,End_Date,FICode))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
      
        public bool glmst_table_creation(SqlConnection con)
        {
            string strmidlog = "create table glmst(FICode char(10) not null,GCODE char(10) not null,MType char(1) not null,MGROUP int not null,SGROUP int not null,GLCODE int not null,LDESC varchar(50) null,LALIAS varchar(15) null,T_FILTER int not null,OPBAL money null,CURBAL money null,LBAL money null, SGRP_LEV int null, PREV_GROUP int null,ALOC_CODE varchar(10) null,CONS_FLG  smallint null,PDF_TYPE char(1) null,PDF_CODE numeric(18,0) null,NBAL_FLG bit null,UNB_GROUP varchar(6) null,UNB_SGROUP varchar(6) null,ACTV_FLG bit null,CURR_CODE varchar(6) null,NCONV_FCTR float null,DCONV_FCTR float null,TRANS_CLOS int null,EXCHG_DIFF int null,FC_CURBAL money null,BOOL_CODE varchar(10) null,FC_OPBAL money null,FC_LBAL money null,EXDIFF_VAL money  null ,OP_LBAL money not null,FC_OPLBAL money not null,SCHD_NO varchar(10) null,CFLOW_GROUP varchar(10) null,MGCODE char(2) null,MMTYPE char(1) null,MMGROUP varchar(6) null,MSGROUP varchar(6) null,MGLCODE varchar(6) null,MLDESC varchar(40) null,LOCK char(1) null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,MType,MGROUP,SGROUP,GLCODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool grp_table_creation(SqlConnection con)
        {
            string strmidlog = "create table grp(FICode char(10) not null,GCODE char(10) not null,MGROUP int not null,SGROUP int not null,SDESC varchar(40) null,GALIAS  varchar(40) null,T_FILTER int null,CURBAL money null,LBAL money null,ACCTYPE char(2) null,CONS_FLG smallint null,PDF_TYPE char(1) null, PDF_CODE numeric(18,0) null, ACTV_FLG bit null,EXDIFF_VAL money null,OP_LBAL  money null,SCHD_NO varchar(10) null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,MGROUP,SGROUP))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool IALIAS_table_creation(SqlConnection con)
        {
            string strmidlog = "create table IALIAS(FICODE char(10) not null,GCODE char(10) not null,PCODE  numeric (18,0) not null,PALIAS varchar(10) not null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,PCODE,PALIAS))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool iglmst_table_creation(SqlConnection con)
        {
            string strmidlog = "create table iglmst(Ficode char(10) not null,GCODE char(10) not null,PCODE  numeric (18,0) not null,PDESC varchar(50)  null,PALIAS varchar(30) not null,PTYPE char(2) null,PDETAILS text null,UCODE numeric (18,0) not null,SGROUP numeric (18,0) null,EQUIP_CODE numeric (18,0) null,PUCODE numeric (18,0) null,SAL_ACC numeric (18,0) null,TAX_ACC numeric (18,0) null,DIS_ACC  numeric (18,0) null,PUR_ACC numeric (18,0) null,STK_ACC numeric (18,0) null,OP_QTY float null,OP_RATE  float null,OP_AMT float null,MIN_QTY float null,ORD_QTY float null,CUR_QTY float null,MKT_RATE float null,SALE_RATE float null,VAL_METH char(1) not null,VAL_RATE char(1) not null,DEC_PLACE int null,RATE_UCODE numeric (18,0) null,PCUR_QTY float null,POP_QTY float not null,OP_UCODE numeric (18,0) null,PDEC_PLACE int not null,RUCODE numeric (18,0) null,RPUCODE numeric (18,0) null,RU2FLG bit null,BOOL_CODE varchar(10) null,VIRTUAL_AMT float null,DCODE varchar(50) null, Item_Type varchar(100) null,Tariff_Code varchar(10) null,TariffSub_Code varchar(10) null,Proc_Tag bit null,";
           
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,PCODE,PALIAS))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool igroup_table_creation(SqlConnection con)
        {
            string strmidlog = "create table igroup(Ficode char(10) not null,GCODE char(10) not null,PCODE  numeric (18,0) not null,SGROUP numeric (18,0) not null,PDESC varchar(40) not null,TAX_GRP char(1) null,";
            strmidlog = strmidlog + "primary key clustered(Ficode,GCODE,PCODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool inarr_table_creation(SqlConnection con)
        {
            string strmidlog = "create table inarr(FICODE char(10) not null,GCODE char(10) not null,T_ENTRY  char(1) not null,VOUCHER varchar(5) not null,AUTOINCRE int not null,VCHRAUTOINCRE int null,NTYPE char(1) null,GAMT float null,AMT_TYPE char(2) null,GDATE datetime null,GCODE1 varchar(6) null,GCODE2 varchar(6) null,NAR1 text null,BRNCH_CODE varchar(6) null,";
            strmidlog = strmidlog + "primary key clustered(FICODE,GCODE,T_ENTRY,VOUCHER,AUTOINCRE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Inportant_Note_table_creation(SqlConnection con)
        {
            string strmidlog = "create table Inportant_Note(ID numeric(18,0) not null,ImportantNote varchar(max) null,";
            strmidlog = strmidlog + "primary key clustered(ID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool invtype_Note_table_creation(SqlConnection con)
        {
            string strmidlog = "create table invtype(FICODE char(10) not null,GCODE char(10) not null,ITEMTYPE int not null, TYPEDESC  varchar(40) not null ,";
            strmidlog = strmidlog + "primary key clustered(FICODE,GCODE,ITEMTYPE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ITEMADDDET_Note_table_creation(SqlConnection con)
        {
            string strmidlog = "create table ITEMADDDET(FICODE char(10) not null,GCODE char(10) not null,PCODE numeric(18,0) not null,SLNO int not null,PROP_DESC varchar(250) null,PROP_VALUE varchar(250) null,";
            strmidlog = strmidlog + "primary key clustered(FICODE,GCODE,PCODE,SLNO))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool itran_table_creation(SqlConnection con)
        {
            string strmidlog = "create table itran(FICODE char(10) not null,GCODE char(10) not null,T_ENTRY  char(2) not null,VOUCHER numeric(18,0)not null,AUTOINCRE numeric(10,0)not null,PCODE numeric(18,0)not null,UCODE numeric(18,0)not null,QTY float not null,RATE float not null,AMT money null,SAL_ACC numeric(18,0) null,SAL_PER float null,SAL_AMT float null,TAX_ACC numeric(18,0) null,TAX_PER float null,TAX_AMT float null,DIS_ACC numeric(18,0) null,DIS_PER float null,DIS_AMT float null,LOC_FROM numeric(18,0) null,LOC_TO numeric(18,0) null,CC_CODE numeric(18,0) null,USER_VCH varchar(50)not null,RUCODE numeric(18,0) null,VCHDATE datetime null,PDETAILS text null,PUCODE numeric(18,0) null,PQTY float null,BRNCH_CODE numeric(18,0) null,PROC_CODE numeric(18,0) null,BATCH_NO varchar(15) null,PLOG_NO varchar(15) null,PARTY_CODE numeric(18,0) null,LINK_TENTRY char(2) null,LINK_VOUCHER numeric(18,0) null,REF_TENTRY char(2) null,REF_VOUCHER numeric(18,0) null,ITEMNO int null,CURR_CODE numeric(18,0) null,NCONV_FCTR float null,DCONV_FCTR float null,CONF_CURR bit null,PCL_TENTRY char(1) null,PCL_VOUCHER varchar(5) null,AMT2 float null,RATE2 float null,DUMMY_FLD char(1) null,ACTUAL_AMT float null,PLOG_FLG bit null,DFLT_QTY float null,PARL_QTY float null,LINE_DIS_PER float null,LINE_DIS_AMT float null,LINE_TAX1_PER float null,LINE_TAX1_AMT float null,LINE_OPTION_ID varchar(4) null,Link_ItemNo int null,LINE_DATE datetime null,Free varchar(4) null,PALIAS varchar(30) null,DCODE numeric(18,0) null,AuRate float null,AuAmount float null,JobAlotvou varchar(5) null,JobProcess varchar(6) null,JobAlotUser varchar(40) null,CHECKQTY varchar(50) null,Joballot varchar(50) null,BatchNo varchar(50) null,FromR_V char(1) null,ToR_V char(1) null,WorksProduction varchar(50) null,CurQty float null,MCNAME varchar(40) null,LINE_DIS_PER1 float null,LINE_DIS_AMT1 float null,LINE_DIS_ACTUAL float null,LINE_DIS_ACTUAL1 float null,LINE_TAX1_VATACC float null,TAX_AMTDUMMY float null,ShopOrderNo varchar(6) null,ShopTag bit null,ProQty float null,ProitemCode varchar(50) null,ProitemDesc varchar(50) null,Udesc varchar(10) null,RentQty float null,OrdQty float null,RejQty float null,BalQty float null,Qty2nd float null,Ucode2nd varchar(6) null,Qty3rd float null,Ucode3rd varchar(6) null,RateUcode numeric(18,0)null,";
            strmidlog = strmidlog + "primary key clustered(FICODE,GCODE,T_ENTRY,VOUCHER,AUTOINCRE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_AlmirahDetails_Note_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_AlmirahDetails(ALCODE int not null,ALNO varchar(50) not null,SELFNO varchar(50) not null,RACKNO varchar(50) not null,";
            strmidlog = strmidlog + "primary key clustered(ALNO,SELFNO,RACKNO))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Book_Binding_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Book_Binding(SlNo int not null,BOOK_ACCESS_CODE varchar(50) null,CATG_CODE int null,BINDINGDATE datetime null,PRICE money null,STATUS bit null,RETURNGDATE datetime null,TypeofBinding varchar(50) null,InsertionDate datetime  not null DEFAULT(getdate()),Obtain_Type chae(1) null,";
           
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Book_Recomendation_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_AlmirahDetails(SerialNo int not null,CallNo varchar(50) null,BookName varchar(200) null,Author varchar(200) null,ReaderType varchar(50) null,Price money null,NewBookName varchar(50) null,NewAuthor varchar(50) null,NewPrice money null,ReaderId varchar(50) null,Class varchar(50) null,Session varchar(50) null,Reason varchar(50) null,InsertionDate datetime  not null DEFAULT(getdate()),";
            
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_BookInfo_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_BookInfo(FIcode char(10) not null,GCODE char(10) not null,LIB_CATG_CODE int not null,BOOK_ACCESS_CODE varchar(50) not null,Date datetime null,BOOK_TITLE varchar(max) not null,EDITION_INFO varchar(max) not null,EDITION_YR numeric(18,0) null,AUTHOR varchar(max) null,PUBLISHER varchar(max) null,PUBPLACE varchar(max) null,PUBDATE datetime null,SOURCEPERSON varchar(50) null,SOURCENAME varchar(50) null,PUBPRICE numeric(18,2) not null,PUR_PRICE money null,PAYMENTMODE varchar(50) null,PAYNO varchar(50) null,PUR_DATE datetime null,NO_PAGES varchar(20) null,NO_PICTURES numeric(18,0)  null,NO_MAP numeric(18,0)  null,VOLUME varchar(50) null,SIZE varchar(50) null,CALLNO varchar(50) null,ALCODE int null,NATUREOFBINDING varchar(50) null,LANG varchar(50) null,SUBJECT varchar(50) null,REMARKS varchar(max) null,INSERTIONDATE datetime not null DEFAULT(getdate()),ISBN varchar(max) null,Obtain_Type char(1) not null,DA_LO int null,LD_DATE datetime null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,LIB_CATG_CODE,BOOK_ACCESS_CODE,Obtain_Type))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_BookIssue_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_BookIssue(SlNo int not null,CallNo varchar(50) null,IssueDate datetime null,ReaderId varchar(50) null,ReturnDate datetime null,LibrarianId varchar(50) null,Remarks varchar(max) null,InsertionDate datetime  not null DEFAULT(getdate()),BOOK_ACCESS_CODE varchar(50) null,ReaderType varchar(50) null,Obtain_Type char(1) null,LIB_CATG_CODE int null,Session varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_BookReservation_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_BookReservation(Ficode char(10) not null,GCODE char(10) not null,RID int not null,ACCESS_CODE varchar(50) not null,MEMBER_ID varchar(50) null,RDATE datetime null,DESIGID varchar(50) null,SECID varchar(50) null,RESERVE_FROM datetime null,RESERVE_TO datetime null,STATUS bit null,READER_TYPE varchar(50) null,LIB_CATG int null,Obtain_Type char(1) null,";
            strmidlog = strmidlog + "primary key clustered(Ficode,GCODE,RID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_CATG_table_creation(SqlConnection con)
        {
           
            string strmidlog = "create table lib_CATG(CATG_CODE int not null,CATG varchar(50) not null,";
            strmidlog = strmidlog + "primary key clustered(CATG_CODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Deleted_Book_Record_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Deleted_Book_Record(FIcode char(10) not null,GCODE char(10) not null,LIB_CATG_CODE int not null,BOOK_ACCESS_CODE varchar(50) not null,Date datetime null,BOOK_TITLE varchar(50) not null,EDITION_INFO varchar(50) null,EDITION_YR numeric(18,0) null,AUTHOR varchar(50) null,PUBLISHER  varchar(50) null,PUBPLACE varchar(50) null,PUBDATE datetime null,SOURCEPERSON varchar(50) null,SOURCENAME varchar(50) null,PUBPRICE numeric(18,2) null,PUR_PRICE money null,PAYMENTMODE varchar(50)  null,PAYNO varchar(50)  null,PUR_DATE datetime null,NO_PAGES varchar(20)  null,NO_PICTURES numeric(18,0) null,NO_MAP numeric(18,0) null,VOLUME varchar(50) null,SIZE varchar(50) null,CALLNO varchar(50) null,ALCODE int null,NATUREOFBINDING varchar(50) null,LANG varchar(50) null,SUBJECT varchar(50) null,REMARKS varchar(50) null,INSERTIONDATE datetime not null DEFAULT(getdate()),ISBN varchar(max) null,Slno int not null,Obtain_Type char(1) null,DA_LO int null,LD_DATE datetime null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,LIB_CATG_CODE,BOOK_ACCESS_CODE ,Slno))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Deleted_Fld_Record_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Deleted_Fld_Record(FIcode char(10) not null,GCODE char(10) not null,FLD_TYPE varchar(50) null,FLD_CODE varchar(50)not null,FLD_NAME varchar(50) null,DELETION_DATE datetime null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,FLD_CODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Deleted_Member_Record_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Deleted_Member_Record(FIcode char(10) not null,GCODE char(10) not null,MEMBER_ID varchar(50) not null,MEMBER_NAME varchar(50) null,FATHER_NAME varchar(50) null,DESIGNATION varchar(50) null,GENDER varchar(50) null,ADDRESS varchar(50) null,MEMBER_STATUS varchar(50) null,CONTACT_NO numeric(18,0) null,FINE_AMT money null,DELETION_DATE datetime null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,MEMBER_ID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_FeesConfiguration_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_FeesConfiguration(Session varchar(50) not null,LateFine money null,DuplicateCardFine money null,LostBookFine money null,";
            strmidlog = strmidlog + "primary key clustered(Session))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Fine_Record_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Fine_Record(FIcode char(10) not null,GCODE char(10) not null,FINE_ID  varchar(50) not null,MEMBER_ID  varchar(50) not null,ACCESS_ID varchar(50) not null,FINE_AMT money not null,FINE_RE_DATE datetime null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,FINE_ID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_FineBalance_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_FineBalance(Serial_No int not null,Reciept_No int not null,Date datetime null,RegNo varchar(20) null,Roll int null,Class varchar(20) null,Name varchar(50) null,Late_Fine numeric (18,2) null,Duplicate_Card_Fine numeric (18,2) null,Damaged_Book_Fine numeric (18,2) null,Lost_Book_Fine numeric (18,2) null,BookName varchar(80) null,BOOK_ACCESS_CODE varchar(50) null,Insertion_Date datetime null,Section varchar(20) null,total_fine numeric (18,2) null,amount_paid numeric (18,2) null,paid varchar(50) null,Reason varchar(max) null,";
            strmidlog = strmidlog + "primary key clustered(Serial_No,Reciept_No))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Issue_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Issue(FIcode char(10) not null,GCODE char(10) not null,ISSUEID  varchar(50) not null,ISSUE_DATE datetime not null,RCODE varchar(50) not null,RNAME varchar(50) null,DESIGNATION varchar(50) null,SECTION varchar(50) null,CATEGORIES varchar(50) null,BCODE varchar(50) not null,BTITLE varchar(50) null,BTYPE varchar(50) null,ERETURN_DATE datetime not null,RETURN_DATE datetime null,RECEIVED bit null,REMARK varchar(max) null,RPIC image null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,ISSUEID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Magazine_Subscription_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Magazine_Subscription(FIcode char(10) not null,GCODE char(10) not null,MAGSUBID varchar(50) not null,MAGID varchar(50) not null,MAGBILLNO varchar(50) null,QTY numeric (18,0) null,PRICE money null,DT1 datetime null,DT2 datetime null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,MAGSUBID,MAGID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Member_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Member(FIcode char(10) not null,GCODE char(10) not null,MEMBER_ID varchar(50) not null,FULL_NAME varchar(50) null,FATHER_NAME varchar(50) null,RTYPE varchar(50) null,DBIRTH datetime null,GENDER varchar(50) null,CATEGORIES varchar(50) null,SCHOOLID varchar(50) null,DESIGNATION varchar(50) null,SECTION varchar(50) null,SEQURITY_DEPOSIT money null,REGN_DATE datetime not null,TEL_NO numeric(18,0) null,MOB_NO numeric(18,0) null,MEMBER_PIC image null,ADDRESS varchar(200) null,BOOK_ISSUE_PERMIT bit not null,LENDING_MEMBER bit null,READONLY_MEMBER bit null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,MEMBER_ID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Member_Regn_Canceled_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Member_Regn_Canceled(FIcode char(10) not null,GCODE char(10) not null,MEMBER_ID varchar(50) not null,MEMBER_NAME  varchar(50)  null,FATHER_NAME varchar(50)  null,GENDER varchar(50)  null,DESIGNATION varchar(50)  null,DOB datetime null,SCHOOLID varchar(50)  null,REGN_DATE datetime null,ADDRESS varchar(50)  null,CONTACT_NO numeric(18,0) null,MEMBER_STATUS numeric(18,0) null,REGN_CANCEL_DATE datetime null,CANCEL_REASON varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,MEMBER_ID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Prod_issue_count_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Prod_issue_count(FIcode char(10) not null,GCODE char(10) not null,PROD_TYPE varchar(50)  null,PROD_ID  varchar(50) not null,PROD_NAME varchar(50) null,NO_OF_TIMES numeric(18,0) null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,PROD_ID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Product_Bill_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Product_Bill(FIcode char(10) not null,GCODE char(10) not null,BILL_NO varchar(50) not null,PRODUCT_TYPE  varchar(50)  null,PRODUCT_NAME varchar(50) null,PRODUCT_VENDOR varchar(50) null,NO_OF_COPIES numeric(18,0) null,PURCHASE_DATE datetime null,PURCHASE_PRICE money null,TOTAL_AMOUNT money null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,BILL_NO))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
         public bool lib_Product_Status_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Product_Status(FIcode char(10) not null,GCODE char(10) not null,STATUS_ID varchar(50) not null,PROD_TYPE  varchar(50)  null,PROD_ID varchar(50) not null,PROD_TITLE varchar(50) null,PROD_STATUS varchar(50) null,LAST_UPDATED_ON datetime null,PROD_PRICE money null,SOLD_TO varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,BILL_NO))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_Receipt_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_Receipt(FIcode char(10) not null,GCODE char(10) not null,RECEIPT_DATE datetime not null,FLD_TYPE varchar(50) not null,FLD_NAME varchar(50) not null,PRICE money null,VOLUME varchar(50) null,EDITION_DATE datetime null,NO_COPIES numeric(18,0) null,MONTH varchar(50) null,RENEWAL_DATE datetime null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,RECEIPT_DATE,FLD_TYPE,FLD_NAME))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool lib_RecordMaster_table_creation(SqlConnection con)
        {
            string strmidlog = "create table lib_RecordMaster(FIcode char(10) not null,GCODE char(10) not null,RECORD_FLD varchar(50) not null,FLD_CODE varchar(50) not null,FLD_NAME varchar(50) not null,FLD_REMARKS  varchar(50)  null,FLD_OTHER varchar(50) null,FLD_ADDRESS varchar(max) null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,FLD_CODE,FLD_NAME))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MenuTable_table_creation(SqlConnection con)
        {
            string strmidlog = "create table MenuTable(MENUCODE varchar(12) not null,PARENTCODE varchar(12) not null,MENUDESC varchar(300) not null,DETAILDESC varchar(500) not null,ENABLE_MENU bit null,FORMCODE varchar(20) null,SHORTCUT_KEY varchar(50) null,TOOLBARBTN bit null,";
            strmidlog = strmidlog + "primary key clustered(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MenuUser_table_creation(SqlConnection con)
        {
            string strmidlog = "create table MenuUser(USER_CODE varchar(6) not null,GCODE varchar(10) not null,MENUCODE varchar(12) not null,ENABLE_MENU bit null,TOOLBARBTN bit null,";
            strmidlog = strmidlog + "primary key clustered(USER_CODE,GCODE,MENUCODE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Midaslog_table_creation(SqlConnection con)
        {
            string strmidlog = "create table Midaslog(LOG_UCODE varchar(6) not null,LOG_GCODE varchar(10) not null,LOG_CCODE varchar(10) not null,AUTOINCRE int not null,FORM_NAME varchar(40) null,FORM_CODE int null,DATE_FROM datetime null,TIME_FROM datetime null,DATE_TO datetime null,TIME_TO datetime null,LOG_STAT int null,MACHINE_NAME varchar(20) null,Exclusive bit null,session_no int null,[function] nvarchar(5) null, job nvarchar(Max) null,";
            strmidlog = strmidlog + "primary key clustered(LOG_UCODE,LOG_GCODE,LOG_CCODE,AUTOINCRE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MonthlyFee_Details_table_creation(SqlConnection con)
        {
            string strmidlog = "create table MonthlyFee_Details(RegNo varchar(50) not null,Autoincer numeric(18,0) null,Name varchar(50)  null,ClassID int not null,Section varchar(50)  null,Roll int null,Month varchar(50) not null,Feehead varchar(50) not null,Amount decimal (18,2) null,session varchar(50)  null,InsertDate varchar(50)  null,FeeID int null,Accadamic int null,";
            strmidlog = strmidlog + "primary key clustered(RegNo,ClassID,Month,Feehead))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool narr_table_creation(SqlConnection con)
        {
            string strmidlog = "create table narr(FICODE char(10) not null,GCODE char(10) not null,T_ENTRY char(2) not null,VOUCHER numeric (18,0) not null,AUTOINCRE numeric (18,0) not null,GAMT float null,AMT_TYPE char(2) null,GDATE datetime null,GCODE1 numeric (18,0) null,GCODE2 varchar(6) null,CHQ_DATE datetime null,CHQ_NO varchar(15) null,BRNCH_CODE numeric(18,0) null,PICTURE image null,CURR_CODE numeric(18,0) null,NCONV_FCTR float null,DCONV_FCTR float null,PRO_STATUS bit null,GDATE2 datetime null,FC_GAMT float null,NTYPE char(1) null,NAR1 text null,PAYEE_NAME varchar(50) null,linkvoucher numeric(18,0) null,linkTentry char(2) null,";
            strmidlog = strmidlog + "primary key clustered(FICODE,GCODE,T_ENTRY,VOUCHER,AUTOINCRE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool prtyms_table_creation(SqlConnection con)
        {
            string strmidlog = "create table prtyms(FICODE char(10) not null,GCODE char(10) not null,GLCode int not null,ACC_ADD1 varchar(40) null,ACC_ADD2 varchar(40) null,ACC_CITY varchar(20) null,ACC_STATE varchar(20) null,ACC_PIN varchar(10) null,ACC_COUNTRY varchar(50) null,CONTACT_PERSON varchar(50) null,ACC_DESIG varchar(50) null,ACC_TELE1 varchar(20) null,ACC_TELE2 varchar(20) null,ACC_TELE3 varchar(20) null,ACC_FAX varchar(50) null,ACC_Email varchar(50) null,ACC_CIN varchar(50) null,ACC_ServiceTaxNo varchar(50) null,DIN  varchar(50) null,IT_PAN varchar(50) null,TAN_NO varchar(50) null,EX_REG_NO varchar(50) null,EX_DIV varchar(50) null,EX_RANGE varchar(50) null,EX_COMM varchar(50) null,ECC_NO varchar(50) null,CRED_DAYS int null,TDS_RATE float null,RCV_INT float null,PAY_INT float null,CREDIT_LIMIT float null,BRKG_PERCENTAGE float null,AUTOADJUSTMENT bit null,BAdd1 varchar(50) null,BAdd2 varchar(50) null,BCity varchar(50) null,BState varchar(50) null,BCountry varchar(50) null,BPin varchar(50) null,BContact varchar(50) null,BDesig varchar(50) null,BTele1 varchar(50) null,BTele2 varchar(50) null,BTele3 varchar(50) null,BFax varchar(50) null,BEmail varchar(50) null,CAdd1 varchar(50) null,CAdd2 varchar(50) null,CCity varchar(50) null,CState varchar(50) null,CCountry varchar(50) null,CPin varchar(50) null,CContact varchar(50) null,CDesig varchar(50) null,CTele1 varchar(50) null,CTele2 varchar(50) null,CTele3 varchar(50) null,CFax varchar(50) null,CEmail varchar(50) null,brokShrtsl float null,brokPurchase float null,STT float null,SERVICE_TAX float null,";
            strmidlog = strmidlog + "primary key clustered(FICODE,GCODE,GLCode))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Session2_table_creation(SqlConnection con)
        {
            string strmidlog = "create table Session2(Fromdate datetime not null,Todate datetime not null,SfiCode char(10) not null,Session nchar(10) null,Class int not null,";
            strmidlog = strmidlog + "primary key clustered(Fromdate,Todate,Class))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TaxDetail_table_creation(SqlConnection con)
        {
            string strmidlog = "create table TaxDetail(FICode char(10)not null,GCODE char(10)not null,glcode numeric(18,0) not null,T_DESC varchar(50) not null,T_RATE float null,CODE varchar(50) null,INITIALS varchar(20) null,TAX_TYPE char(1) null,EFFECT char(1) null,TYPE_CODE numeric(18,0)  null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,glcode,T_DESC))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TaxMaster_table_creation(SqlConnection con)
        {
            string strmidlog = "create table TaxMaster(FICode char(10)not null,GCODE char(10)not null,Types varchar(50) not null,Type_code numeric(18,0) not null,TaxStatus bit null,VIEW_STAT bit null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,Types,Type_code))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_AdditionalFeeHeads_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_AdditionalFeeHeads(SlNo int IDENTITY(1,1) not null,ClassId int null,FeeId int null,FeeHead varchar(50) not null,OldAmount numeric(18,2) null,NewAmount numeric(18,2) null,DiffAmt numeric(18,2) null,Mode varchar(50)null,Date datetime null,AffectedFromMonth varchar(50) null,AffectedFromYear varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_AdditionalSubject_Result_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_AdditionalSubject_Result(SlNo int IDENTITY(1,1) not null,RegNo varchar(50) null,Class_Id int not null,RollNo varchar(50) null,Name_Subject varchar(50) null,Term varchar(50) null,Written numeric (18,0) null,Oral numeric (18,0) null,Student_Score int null,Average decimal (18,2) null,Total_score int null,GrandTotal int null,Grand_Average decimal (18,2) null,Comments varchar(50) null,Attendence int null,ResultCondition varchar(50) null,WrittenExamed int null,InsertionDate datetime not null DEFAULT(getdate()),OralExamed int null,ExamDate datetime null,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_AdditionalSubjectAllocation_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_AdditionalSubjectAllocation(SlNo int IDENTITY(1,1) not null,RegNo varchar(50) null,ClassID int null,AdSubjectId int null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Admission_ParentDetails_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Admission_ParentDetails(FICode char(10) not null,GCODE char(10) not null,SFicode char(10) not null,Id int IDENTITY(1,1) not null,RegNo varchar(50) null,Father_Title varchar(50) null,Father_FirstName varchar(50) null,Father_MiddleName varchar(50) null,Father_LastName varchar(50) null,Father_Occupation varchar(max) null,Father_AvgMonthlyIncome varchar(50) null,Father_CompanyName varchar(50) null,Father_Department varchar(50) null,Father_Designation varchar(50) null,Father_Address varchar(max) null,Father_Phone varchar(50) null,Father_Extn varchar(50) null,Father_Fax varchar(50) null,Father_Email varchar(50) null,Father_Mobile varchar(50) null,Mother_Title varchar(50) null,Mother_FirstName varchar(50) null,Mother_MiddleName varchar(50) null,Mother_LastName varchar(50) null,Mother_Occupation varchar(max) null,Mother_AvgMonthlyIncome varchar(50) null,Mother_CompanyName varchar(50) null,Mother_Department varchar(50) null,Mother_Designation varchar(50) null,Mother_Address varchar(max) null,Mother_Phone varchar(50) null,Mother_Extn varchar(50) null,Mother_Fax varchar(50) null,Mother_Email varchar(50) null,Mother_Mobile varchar(50) null,RefRegNo varchar(50) null,RefName varchar(50) null,RefClass varchar(50) null,RefSection varchar(50) null,RefShift varchar(50) null,RecGuardian_Title varchar(50) null,RecGuardian_FirstName varchar(50) null,RecGuardian_MiddleName varchar(50) null,RecGuardian_LastName varchar(50) null,RelationWithStudent varchar(50) null,RecGuardian_Occupation varchar(50) null,RecGuardian_AvgMonthlyIncome varchar(50) null,RecGuardian_Company varchar(50) null,RecGuardian_Department varchar(50) null,RecGuardian_Designation varchar(50) null,RecGuardian_Address varchar(max) null,RecGuardian_Phone varchar(50) null,RecGuardian_Fax varchar(50) null,RecGuardian_Email varchar(50) null,RecGuardian_Mobile varchar(50) null,LivingWith varchar(50) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,SFicode,Id))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Admission_StudentDetails_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Admission_StudentDetails(FICode char(10) not null,GCODE char(10) not null,SFicode char(10) not null,FormNo int not null,RegNo varchar(50) not null,RollNo int not null,ClassAdmission varchar(50) null,Section varchar(50) null,Shift varchar(50) null,Session varchar(50) null,OldClassId int null,ClassId int null,StudentFirstName varchar(50) null,StudentMiddleName varchar(50) null,StudentLastName varchar(50) null,Gender varchar(10) null,Nationality varchar(10) null,Religion varchar(50) null,MotherTongue varchar(50) null,Caste varchar(50) null,BloodGroup varchar(50) null,DateOfBirth datetime null,AgeOn varchar(50) null,Age varchar(50) null,AgeReason varchar(max) null,BirthCertificateIsuuedBy varchar(50) null,PresentAddress varchar(max) null,PresentPlace varchar(max) null,PresentState varchar(max) null,PresentPIN varchar(50) null,PresentRlyStn varchar(50) null,PresentDist varchar(50) null,PresentPhone varchar(50) null,PermanentAddress  varchar(max) null,PermanentPlace varchar(max) null,PermanentState varchar(max) null,PermanentPIN  varchar(50) null,PermanentRlyStn varchar(50) null,PermanentDist varchar(max) null,PermanentPhone varchar(50) null,FromSchool varchar(50) null,TCSubmited varchar(50) null,InsertionDate datetime not null DEFAULT(getdate()),AdmissionDate datetime null,UnicNo varchar(50) null,Type varchar(50) null,Promotion_Status int not null DEFAULT((0)) ,FeePercent int null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,SFicode,RegNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_BusMaster_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_BusMaster(GCode int not null,BusCode varchar(50) not null,BusNumber varchar(50) not null,";
            strmidlog = strmidlog + "primary key clustered(GCode,BusCode,BusNumber))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_BusRouteMaster_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_BusRouteMaster(FiCode int not null,GCode int not null, BusRouteCode varchar(50) not null,BusRouteName varchar(50) null,BusFee decimal(18,2) null,OtherCharges decimal(18,2) null,";
            strmidlog = strmidlog + "primary key clustered(FiCode,GCode,BusRouteCode))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_CashReceipt_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_CashReceipt(SlNo int IDENTITY(1,1) not null,FICode char(10) not null, GCode char(10) not null,ReceiptNo numeric(18,0) not null,FormNo varchar(50) null,RegNo varchar(20) null,Fine int null,DuplicateFee int null,ReAdm int null,AdmFrom int null,RegFee int null,CentreFree int null,OtherCharges int null,Total int null,Date datetime null,voucherno numeric(18,0) null,";
            strmidlog = strmidlog + "primary key clustered(SlNo,FICode,GCode))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_caste_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_caste(SlNo int Identity(1,1) not null,Gender varchar(50) null, caste varchar(50) null),";
            
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_CautionMoney_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_CautionMoney(SlNo int Identity(1,1) not null,RegNo varchar(50) not null, Session varchar(50) null,Class varchar(50) null,Section varchar(50) null,Amount decimal(18,2) null,Status int not null,Date varchar(50) null,Voucher varchar(50) null,ReceiptNo varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(RegNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_ClassSubject_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_ClassSubject(Subject_Id int  not null,Class_Id int not null, Subject_Name varchar(50) null,Total_Matks int  null,Pass_Marks int  null,No_Of_Terms int  null,Terms int null,Date varchar(50) null,Voucher varchar(max) null,Insertion_Date datetime null,ReportName varchar(50) null,Oral bit null,";
            strmidlog = strmidlog + "primary key clustered(Subject_Id,Class_Id))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_ClassTerm_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_ClassTerm(Class varchar(50) null,ExamName varchar(50) null, TotalNo varchar(50) null,CutOffNo varchar(50) null,";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_AdditionalSubject_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_AdditionalSubject(AdSubjectId int Identity(1,1) not null,Class_Id int not null,Subject_Name varchar(50) null,Total_Matks int null,Pass_Marks int null,Insertion_Date datetime null,";
            strmidlog = strmidlog + "primary key clustered(AdSubjectId))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_AddlExam_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_AddlExam(ExamId int not null,ClassId int not null,ExamName varchar(50) null,ExamCode int null,TotalMarks int not null,PassMarks int not null,FromDate datetime null,ToDate datetime null,MarksCalculation int null,InsertionDate datetime not null DEFAULT(getdate()),Written int null,Oral int null,";
            strmidlog = strmidlog + "primary key clustered(ExamId))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_BestOfThree_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_BestOfThree(SubjectId int not null,Subject_Name  varchar(50) not null,Class_Id int not null,Year varchar(50) not null,Status bit null,";
            strmidlog = strmidlog + "primary key clustered(SubjectId,Subject_Name,Class_Id,Year))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_Class_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_Class(ClassId int IDENTITY(1,1) not null,ClassName  varchar(50)  null,Year varchar(10)  null,Category varchar(50)  null,Shift varchar(50)  null,Total_Seats int null,OBC int null,SC int null,ST int null,General int null,AgeCriteria varchar(50)  null,AgeOn varchar(50)  null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(ClassId))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_Exam_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_Exam(ExamId int IDENTITY(1,1) not null,ClassId  int not null,ExamName varchar(50) not null,ExamCode int null,TotalMarks int not null,PassMarks int not null,FromDate datetime  null,ToDate datetime  null,MarksCalculation int null,InsertionDate datetime not null DEFAULT(getdate()),Written int null,Oral int null,";
            strmidlog = strmidlog + "primary key clustered(ExamId))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_FeeApp_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_FeeApp(Auto numeric(18,0) IDENTITY(1,1) not null,Session  varchar(50) not null,RegNo varchar(50) not null,ClassId int null,FeeIds varchar(max) null,";
            strmidlog = strmidlog + "primary key clustered(Auto))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_FeeEx_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_FeeEx(Ficode char(10) not null,GCode  char(10) not null,AutoIncre numeric(18,0) IDENTITY(1,1) not null,FeeID numeric(18,0)  null,Type varchar(100) null,Percentage float null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(Ficode,GCode,AutoIncre))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_Fees_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_Fees(Ficode char(10) not null,GCode  char(10) not null,SlNo int IDENTITY(1,1) not null,ClassId int not null,FeeID numeric(18,0) null,FeeVal decimal (18,2) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(Ficode,GCode,SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_FeesDetails_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_FeesDetails(Ficode int not null,GCode  int not null,SlNo int IDENTITY(1,1) not null,ClassId int not null,MonthlyFees numeric(18,2) null,SubmissionDate datetime null,LateFine numeric(18,2) null,InsertionDate datetime not null DEFAULT(getdate()),YearlyNewFees numeric(18,2) null,YearlyOldFees numeric(18,2) null,";
            strmidlog = strmidlog + "primary key clustered(Ficode,GCode,SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_Grade_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_Grade(Grade varchar(50) null,RangeFrom  int null,RangeTo int null,ClassId int null,GradeId int IDENTITY(1,1) not null,";
            strmidlog = strmidlog + "primary key clustered(GradeId))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_HouseCategory_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_HouseCategory(SlNo int Identity(1,1) not null,HouseCategory varchar(50) not null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_Promotion_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_Promotion(SlNo int Identity(1,1) not null,MarksOf varchar(100) not null,MinAttendence int not null,CheckDueFees int not null,CheckLibClearance int not null,InsertionDate datetime not null DEFAULT(getdate()), ";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Config_SeeApp_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Config_SeeApp(Slno numeric(18,0) not null,Session varchar(50) not null,Regno varchar(100) not null,ClassID int not null,FeeIDs varchar(100) not null, ";
            strmidlog = strmidlog + "primary key clustered(Slno))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Convert_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Convert(length int not null,word varchar(50)  null,";
            
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Emp_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Emp(SlNo int not null,EmpId varchar(50) null,EmpName varchar(50)  null, ";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_AddErnDeducDetails_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_AddErnDeducDetails(SlNo numeric(18,0) not null,Session varchar(50) null,EmpID varchar(50)  null,Monthof varchar(50)  null,Amount money null,HeadID  numeric(18,0) null,Type char(10) null,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_AddErnDeducHead_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_AddErnDeducHead(Session varchar(50) not null,monthof varchar(50) not null,Type char(10) not  null,HeadID numeric(18,0) not null,HeadName varchar(100) null,";
            strmidlog = strmidlog + "primary key clustered(Session,monthof,Type,HeadID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Assign_SalStructure_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Assign_SalStructure([SLNO] [int] IDENTITY(1,1) NOT NULL,[P_TYPE] [char](1) NOT NULL,[SESSION] [varchar](50) NOT NULL,[SAL_STRUCT] [int] NOT NULL, ";
            strmidlog = strmidlog + "[SAL_HEAD] [int] NOT NULL,[V_FROM] [varchar](50) NOT NULL,[V_TO] [varchar](50) NOT NULL,[C_BASIS] [varchar](50) NULL,";
            strmidlog = strmidlog + "[C_TYPE] [varchar](50) NULL,[C_DET] [int] NULL,[PF_PER] [int] NULL,[PF_VOL] [int] NULL,[ESI_PER] [int] NULL,[PT] [int] NULL,";
            strmidlog = strmidlog + "[ROUND_TYPE] [varchar](50) NULL,[TDSREFNO] [int] NULL,[TDS_EXEMPT] [int] NULL,[CARRY] [int] NULL,[TDS_EXTRAPOL] [int] NULL,[REMARKS] [varchar](100) NULL,[atten_day] [int] NULL,";
            strmidlog = strmidlog + "[Proxy_day] [int] NULL,[Daily_wages] [int] NULL,[Revenue_Stamp] [int] NULL,[Stamp_Amount] [varchar](50) NULL,[Location_id] [numeric](18, 0) NOT NULL,[Company_id] [numeric](18, 0) NOT NULL,";           
            strmidlog = strmidlog + "primary key clustered(SLNO,P_TYPE,SESSION,SAL_STRUCT,SAL_HEAD,V_FROM,V_TO))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Emp_Attend(SqlConnection con)
        {
            string strmidlog = "create table [tbl_Employee_Attend]([SlNo] [int] IDENTITY(1,1) NOT NULL," + 
            "[ID] [varchar](50) NULL,[MOD] [numeric] (18,2) NULL,[Wday] [numeric] (18,2) NULL," + 
            "[Absent] [numeric] (18,2) NULL,[Proxy] [numeric] (18,2) null,[Season] [varchar](20) NULL," +
            "[Month] [varchar](50) NULL,[LOcation_ID] [numeric](18, 0) NULL," + 
            "[Company_id] [numeric](18, 0) NOT NULL,primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {return false;}

        }

        public bool tbl_Employee_Attendance_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Attendance([SlNo] [int] IDENTITY(1,1) NOT NULL,[ID] [varchar](50) NULL,[Status] [bit] NULL,[Remarks] [varchar](max) NULL,";
            strmidlog = strmidlog + "[LeaveDate] [datetime] NULL,[InsertionDate] [datetime] NULL,[DayStatus] [int] NULL,[LeaveType] [varchar](50) NULL,";
            strmidlog = strmidlog + "[FstLeave] [int] NULL,[SndLeave] [int] NULL,[Season] [varchar](20) NULL,[LeaveType1] [int] NULL,";
            strmidlog = strmidlog + "[Date] [varchar](50) NULL,[LeaveTaken] [varchar](50) NULL,[LOcation_ID] [numeric](18, 0) NULL,[FstProxy] [numeric](18, 0) NULL,";
            strmidlog = strmidlog + "[SndProxy] [numeric](18, 0) NULL,[Company_id] [numeric](18, 0) NOT NULL,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

                public bool Employee_Link_SalaryStructure_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Link_SalaryStructure([Link_ID] [numeric](18, 0) NOT NULL,[Location_ID] [numeric](18, 0) NULL,[SalaryStructure_ID] [numeric](18, 0) NULL,";
            strmidlog = strmidlog + "primary key clustered(Link_ID))";


            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        	

        public bool tbl_Employee_Config_ArrearDet_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Config_ArrearDet(SlNo int not null,ArrearId int null,SalId int  null,SalTable varchar(50) null,PayType varchar(50) null,Amount numeric(18,2) null,PayMode varchar(50) null,PayMode_sub varchar(50) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Config_ArrearMast_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Config_ArrearMast(ArrearId int not null,ArrearName varchar(50) null,ArrearDesc varchar(max) null,FromMonth varchar(50) null,FromYear int null,ToMonth varchar(50) null,PayMode varchar(50) null,ToYear int null,EffMonth varchar(50) null,EffYear nchar(10) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(ArrearId))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Config_Exgratia_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Config_Exgratia(ExGratia_Id int not null,ExGratia_Name varchar(50) null,Session int null,Month varchar(50) null,PayMonth varchar(50) null,Mode varchar(50) null,Amount numeric(18,2) null,MaxPay numeric(18,2) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(ExGratia_Id))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Config_LeaveDetails_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Config_LeaveDetails(LeaveId int IDENTITY(1,1) not null,LeaveHead varchar(50) not null,ShortName varchar(10) not null,TotalLeaves numeric(18,0) not null,DayCount numeric(18,0) not null,Session varchar(50) not null,PayType varchar(30) not null,LeaveFwd varchar(30) not null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(LeaveId))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool tbl_Employee_Config_LeaveDetails_insert(SqlConnection con)
        {
            string strmidlog = "INSERT [tbl_Employee_Config_LeaveDetails] ([LeaveId], [LeaveHead], [ShortName], [TotalLeaves], [DayCount], ";
            strmidlog = strmidlog + "[Session], [PayType], [LeaveFwd], [InsertionDate]) VALUES (367, N'Ab', N'Ab', CAST(10 AS Numeric(18, 0)), CAST(10 AS Numeric(18, 0)), N'2014-2015', N'Full Pay', N'Nothing', CAST(0x0000A44A00D5AE27 AS DateTime))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool tbl_Hour_insert(SqlConnection con)
        {
            string strmidlog = "INSERT [HourMaster] ([Hour_CODE], [Hour_Name],  ";
            strmidlog = strmidlog + "[Country_Code]) VALUES (1,'8',0);";
            strmidlog = strmidlog + "INSERT [HourMaster] ([Hour_CODE], [Hour_Name],  ";
            strmidlog = strmidlog + "[Country_Code]) VALUES (2,'12',0)";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }
       

        public bool tbl_Month_insert(SqlConnection con)
        {
            string strmidlog = "INSERT [MonthOfDays] ([MONTH_CODE], [MONTH_Name],";
            strmidlog = strmidlog + "[Country_Code]) VALUES (1,'26',0);";

            strmidlog = strmidlog + " INSERT [MonthOfDays] ([MONTH_CODE], [MONTH_Name],  ";
            strmidlog = strmidlog + "[Country_Code]) VALUES (2,'MonthOfDays',0);";

            strmidlog = strmidlog + " INSERT [MonthOfDays] ([MONTH_CODE], [MONTH_Name],  ";
            strmidlog = strmidlog + "[Country_Code]) VALUES (3,'PerDay',0)";
           
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool tbl_Employee_Config_PFHeads_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Config_PFHeads(SlNo int not null,PFHead varchar(max) null,ShortName varchar(50) not null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Config_Retirement_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Config_Retirement(SlNo int IDENTITY(1,1) not null,Session varchar(50) null,Age  int null,InsertionDate datetime not null DEFAULT(getdate()),PenssionAge int null,PFAge int null,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_DeductionSalayHead_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_DeductionSalayHead([SlNo] [int] IDENTITY(1,1) NOT NULL,[SalaryHead_Full] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[SalaryHead_Short] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Amount] [numeric](18, 2) NULL,[InsertionDate] [datetime] NULL CONSTRAINT [DF_tbl_Employee_DeductionSalayHead_InsertionDate]  DEFAULT (getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_DeletedEmp_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_DeletedEmp(Code int not null,ID varchar(50) null,Title varchar(50) null,FirstName varchar(50) null,MiddleName varchar(50) null,LastName varchar(50) null,FathTitle varchar(50) null,FathFN varchar(50) null,FathMN varchar(50) null,FathLN varchar(50) null,MothTitle varchar(50) null ,MothFN varchar(50) null,MothMN varchar(50) null,MothLN varchar(50) null,HusTitle varchar(50) null,HusFN varchar(50) null,HusMN varchar(50) null,HusLN varchar(50) null,DateOfBirth datetime null,Cast varchar(50) null,MaritalStatus varchar(50) null,Gender varchar(50) null,DesgId int null,JobType int null,PresentAddress varchar(max) null,PermanentAddress varchar(max) null,STD numeric(18,0) null,Phone numeric(18,0) null,Mobile numeric(18,0) null,PANno varchar(50) null,PassportNo varchar(50) null,PF varchar(50) null,PenssionNo varchar(50) null,EDLI varchar(50) null,ESIno varchar(50) null,BankAcountNo varchar(50) null,DateOfJoining datetime null,DateOfRetirement datetime null,InsertionDate datetime  not null DEFAULT(getdate()),Session varchar(50) null,GMIno varchar(50) null,PenssionDate datetime null,";
            strmidlog = strmidlog + "primary key clustered(Code))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_DesignationMaster_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_DesignationMaster(SlNo int IDENTITY (1, 1) not null,DesignationName varchar(50) null,ShortForm varchar(50) null,InsertionDate datetime  not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_ErnSalaryHead_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_ErnSalaryHead(SlNo int identity(1,1) not null,SalaryHead_Full varchar(max) null,SalaryHead_Short varchar(50) null,Amount numeric(18,2) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_ExgratiaGiven_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_ExgratiaGiven(SlNo int not null,EmpId varchar(50) null,ExgratiaId int null,ExgGiven numeric(18,2) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_FamilyDetails_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_FamilyDetails(SlNo int identity(1,1) not null,ID varchar(50) not null,Name varchar(50) null,Relation varchar(50) null,Age int null,Dependent bit null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo,ID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Holiday_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Holiday(SrlNo int identity(1,1) not null,HolDate datetime not null, HolidayName varchar(100) not null,NationFlag varchar(10) not null,HolRemarks varchar(300) null,HolSession varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(HolDate))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_IncrementDetails_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_IncrementDetails(SlNo int not null,EmpId varchar(50) null, Month varchar(50) null,Session int null,SalId int null,IncAmount numeric(18,2) null,InsertionDate datetime not null DEFAULT(getdate()),IncrementAs varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_JobType_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_JobType(SlNo int identity(1,1) not null,JobType varchar(50) null, ShortForm varchar(50) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Leave_Stat_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Leave_Stat(AutoSerial int not null,EmpID varchar(50) not null, LeaveID int not null,LeaveAction varchar(50) null,LeaveName varchar(50) null,LeaveAvail int null,LeaveTaken int null,LeaveBalance int null,AcadYear varchar(50) not null,";
            strmidlog = strmidlog + "primary key clustered(AutoSerial,EmpID,LeaveID,AcadYear))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_LeaveEncashment_Det_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_LeaveEncashment_Det(SlNo int not null,Session varchar(50) null, EmpId varchar(50) not null,LeaveId int null,TotalLeaves int null,Amount numeric(18,2) null,LeaveEncashMastID int null,InsertionDate datetime not null DEFAULT(getdate()),LeaveTaken  int null,BalanceLeave int null,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_LeaveEncashment_Mast_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_LeaveEncashment_Mast(SlNo int not null,EmpId varchar(50) not null, Session varchar(50) not null,BalLeave int null,HalfLeave int null,GrossAmount numeric(18,2) null,AdvAGSal numeric(18,2) null,RevStamp numeric(18,2) null,TotalDeduction  numeric(18,2) null,NetPay numeric(18,2) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(EmpId,Session))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Lumpsum_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Lumpsum([LUMPID] [int] NOT NULL,[LUMPNAME] [varchar](50) NOT NULL,[LUMPTYPE] [int] NOT NULL,[GRADE] [int] NOT NULL,[STRUCID] [int] NULL,[AMOUNT] [numeric](15, 2) NOT NULL,[Pf_Amt] [numeric](18, 2) NULL,";
            strmidlog = strmidlog + "primary key clustered(LUMPID,LUMPTYPE,GRADE))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool tbl_Employee_Proxy_Attendance_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Proxy_Attendance([Proxy_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,	[Employee_ID] [varchar](50) NULL,";
            strmidlog = strmidlog + " [Proxy_Day] [numeric](18, 2) NULL,	[Month] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Session] [varchar](50) NULL,	[Location_ID] [numeric](18, 0) NULL,	[Company_id] [numeric](18, 0) NOT NULL,";
            strmidlog = strmidlog + "primary key clustered(Proxy_ID))";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool tbl_Employee_Other_Reff_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Other_Reff(";         
            strmidlog = strmidlog + "[ID] [varchar](50) NOT NULL,[Emarg_Name] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Emarg_Address] [varchar](max) NULL,[Emarg_Tele] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Emarg_Mobile] [varchar](50) NULL,[Emp_Achiev] [varchar](max) NULL,";
            strmidlog = strmidlog + "[Emp_Club] [varchar](50) NULL,[Emp_Association] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Emp_Org] [varchar](max) NULL,[Emp_Notic] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Emp_Join_refer] [varchar](50) NULL,[Emp_Preferlocation] [varchar](max) NULL,";
            strmidlog = strmidlog + "[Emp_Criminal_Rec] [varchar](50) NULL,[Emp_illness] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Emp_Interview_Details] [varchar](20) NULL,[Emp_OtherInformation] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Emp_Expected_Salary] [varchar](50) NULL,[Ref_Name] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Ref_Address] [varchar](max) NULL,[Ref_Occupation] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Ref_Phone] [varchar](20) NULL,[Ref_Email] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Ref_Name1] [varchar](50) NULL,[Ref_Address1] [varchar](max) NULL,";
            strmidlog = strmidlog + "[Ref_Occupation1] [varchar](50) NULL,[Ref_Phone1] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Ref_Email1] [varchar](50) NULL,[Emp_Service] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Emp_Period_Service] [varchar](50) NULL,[Emp_Rank] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Emp_ICard_No] [varchar](50) NULL,[Emp_Arms] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Emp_Pension_No] [varchar](50) NULL,[Emp_GunLicence] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Emp_Operation_Area] [varchar](50) NULL,[Emp_issue] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Emp_GunType] [varchar](50) NULL,[Emp_GunValid] [varchar](50) NULL,[Emp_DrivingLicence] [varchar](50) NULL,";

            strmidlog = strmidlog + "primary key clustered(ID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool tbl_Employee_Mast_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Mast(Code int IDENTITY(1,1) NOT NULL,ID varchar(50) not null, Title varchar(50)  null,FirstName varchar(50)  null,MiddleName varchar(50)  null,LastName varchar(50)  null,FathTitle varchar(50)  null,FathFN varchar(50)  null,FathMN  varchar(50)  null,FathLN varchar(50)  null,MothTitle varchar(50)  null,MothFN varchar(50) null,MothMN varchar(50) null,MothLN varchar(50) null,HusTitle varchar(50) null,HusFN varchar(50) null,HusMN varchar(50) null, HusLN varchar(50) null,DateOfBirth datetime null,Cast varchar(50) null,MaritalStatus varchar(50) null,Gender varchar(50) null,DesgId int null,JobType int null,PresentAddress varchar(max) null,PermanentAddress varchar(max) null,STD numeric(18,0) null,Phone numeric(18,0) null,Mobile numeric(18,0) null,PANno varchar(50) null,PassportNo varchar(50) null,PF varchar(50) null,PenssionNo varchar(50) null,EDLI varchar(50) null,ESIno varchar(50) null,BankAcountNo varchar(50) null,DateOfJoining datetime null,DateOfRetirement datetime null,InsertionDate datetime not null DEFAULT(getdate()),Session varchar(50) null,GMIno varchar(50) null,PenssionDate datetime null,EmailId varchar(50) null,salid int null,SecId int null,EmpWorkingStatus varchar(25) null,";           
            strmidlog = strmidlog + "[Empimage] [varbinary](max) NULL,[Empdocimage] [varchar](max) NULL,";
            strmidlog = strmidlog + "[Empdocimage2] [varchar](max) NULL,[Empdocimage3] [varchar](max) NULL,";
            strmidlog = strmidlog + "[Presentbuilding] [varchar](max) NULL,[Presentstreet] [varchar](max) NULL,";
            strmidlog = strmidlog + "[Presentareia] [varchar](max) NULL,[Presentcity] [varchar](max) NULL,";
            strmidlog = strmidlog + "[Presentpin] [varchar](50) NULL,[Presentstate] [numeric](18, 0) NULL,";
            strmidlog = strmidlog + "[Presentcountry] [numeric](18, 0) NULL,[Permanentbuilding] [varchar](max) NULL,";
            strmidlog = strmidlog + "[Permanentstreet] [varchar](max) NULL,[Permanentareia] [varchar](max) NULL,";
            strmidlog = strmidlog + "[Permanentcity] [varchar](max) NULL,[Permanentpin] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Permanentstate] [numeric](18, 0) NULL,[Permanentcountry] [numeric](18, 0) NULL,";
            strmidlog = strmidlog + "[Religion] [varchar](20) NULL,[Weight] [varchar](20) NULL,";
            strmidlog = strmidlog + "[Height] [varchar](20) NULL,[Language_Bengali] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Language_Hindi] [varchar](50) NULL,[Language_English] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Language_Other] [varchar](50) NULL,[Language_Name] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Document_Titel] [varchar](50) NULL,[Document_Titel2] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Document_Titel3] [varchar](50) NULL,[Location_id] [numeric](18, 0) NULL,";
            strmidlog = strmidlog + "[Company_id] [numeric](18, 0) NOT NULL,	[PF_Deduction] [int] NULL,";
	
            strmidlog = strmidlog + "primary key clustered(Code,ID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Other_Det_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Other_Det(SlNo int not null,Det_Item_Header varchar(50) not null, Det_Emp_ID varchar(50) not null,Sal_ItemDetails varchar(50) null,SalHeader_Text varchar(50) null,Header_ID int not null,Amount numeric(18,2) null,InsertDate datetime null,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Other_Mast_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Other_Mast(SrlNo int not null,Mast_Item_Header varchar(50) not null, TransType varchar(20) null,Mast_Emp_ID varchar(50) not null,Gross_Amount  numeric(18,2) null,Tot_Deduc_Amount numeric(18,2) null,Net_Amount numeric(18,2) null,Mth_Frm datetime null,Mth_To datetime null,Season varchar (50) null,No_Of_Month int null,PrevCalc numeric(18,2) null,CurrCalc numeric(18,2) null,PF_Due numeric(18,2) null,Tot_LWP  varchar(50) null,App_LWP varchar(50) null,Tot_PF_Amount numeric(18,2) null,InsertDate datetime null,";
            strmidlog = strmidlog + "primary key clustered(Mast_Item_Header,Mast_Emp_ID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Pay_Details_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Pay_Details(SlNo int not null,Employee_ID varchar(50)  null, ApprovalNo varchar(50) null,Employee_Name varchar(50)  null,Employee_Designation  varchar(50)  null,Salary_Of_Pay int null,Basic_Pay int null,DPay int null,DA int null,HRA int null,MA int null,Gross_Ammount int null,PF int null,PTax int null,ITax int null,ADA int null,Bonus int null,ExtraAllowance int null,Net_Amount int null,Month_Of varchar(50) null,Year_Of varchar(50) null,PayDate int null,Pay int null,Due int null,)";
           
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Pay_SetUp_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Pay_SetUp(Employee_ID int not null,Employee_Approval_No varchar(50) not null, Employee_Name varchar(20) null,Date_Of_Approval varchar(50) null,Qualification  varchar(50)  null,Employee_Designation varchar(50)  null,Salary_Of_Pay varchar(20) null,Basic_Pay int null,DPay int null,DPayPercentage int null,DA int null,DAPercentage int null,HRA int null,HRAPercentage int null,MA int null,MAPercentage int null,Gross_Ammount int null,PF int null,PFPercentage int null,PTax int null,PTaxPercentage int null,ITax int null,ITaxPercentage int null,NetAmount int null,)";
          
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_PF_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_PF(SerialNo int not null,EmpCode varchar(50) null, DateOfEntry datetime null,PFDateMonth datetime null,PfYear  int null,PFDueAmt numeric(18,2) null,PFEDLIDue numeric(18,2) null,EmplrOpeningBal numeric(18,2) null,EmplrPFContAmount numeric(18,2) null,EmplrPFClosing numeric(18,2) null,EmplrPFInterest numeric(18,2) null,EmpOpeningBal numeric(18,2) null,EmpPFContAmount numeric(18,2) null,EmpPFVolContAmount numeric(18,2) null,EmpPFClosing numeric(18,2) null,EmpPFInterest numeric(18,2) null,PFRefLoan numeric(18,2) null,PFNonRefLoanEmplr numeric(18,2) null,PFNonRefLoanEmp numeric(18,2) null,PFLoanRecon numeric(18,2) null,PFLoanInt numeric(18,2) null,PFAcc2 numeric(18,2) null,PFAcc21 numeric(18,2) null,PFAcc22 numeric(18,2) null,PFPension numeric(18,2) null,AddDaDue numeric(18,2) null,AddAmt numeric(18,2) null,SuppliDue numeric(18,2) null,SuppliAmt numeric(18,2) null,ArrDue numeric(18,2) null,ArrAmt numeric(18,2) null,ClosingBal numeric(18,2) null,PFSeason varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(SerialNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_PF_Loan_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_PF_Loan(SerialNo int not null,EmpCode varchar(50) null, LoanType int null,LoanDate datetime null,LoanAmount numeric(18,2) null,EmplrLoanAmt numeric(18,2) null,EmpLoanAmt numeric(18,2) null,InterestRate numeric(18,2) null,LoanRepaid numeric(18,2) null,NoOfInstallment numeric(18,2) null,InstallmentAmount numeric(18,2) null,Remarks varchar(50) null,PFSession varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(SerialNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_PFESIRate_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_PFESIRate(SlNo numeric(18,0) identity(1,1) not null,Month varchar(50) not null, Year varchar(50) not null,PFEMP numeric(18,2) null,PFCMPEPS numeric(18,2) null,PFCMPEPF numeric(18,2) null,PFCUTOFF numeric(18,2) null,PFACC2 numeric(18,2) null,PFACC21 numeric(18,2) null,PFACC22 numeric(18,2) null,ESIEMP numeric(18,2) null,ESICMP numeric(18,2) null,ESICUTOFF numeric(18,2) null,";
            strmidlog = strmidlog + "primary key clustered(Month,Year))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_ProvidentFund_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_ProvidentFund(SlNo int not null,Employee_No int  null, Employee_Name varchar(50) null,Month varchar(50) null,Year varchar(50) null,PF int null,Date varchar(50) null,Extra int null,Total int null,Open_Balance int null,Close_Balance int null)";
           
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_PTRate_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_PTRate(Slno [int] NULL,Session varchar(50) null,wfrom numeric(18,2) null,wto nvarchar(50) null,pt numeric(18,2) null,edate smalldatetime null,estate nvarchar (MAX) null";
            strmidlog = strmidlog + ")";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_QualificationDetails_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_QualificationDetails(SlNo int  IDENTITY(1,1) NOT NULL,ID  varchar(50) not null,Qualification varchar(50) null,University varchar(50) null,YearOfPassing int null,Percentage numeric(18,2) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(Slno,ID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Sal_Structure_Formula_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Sal_Structure_Formula(FID numeric(18,0) not null,FName varchar(50) null,FExp varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(FID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_SalaryDet_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_SalaryDet([Slno] [int] IDENTITY(1,1) NOT NULL,[EmpId] [varchar](50) NOT NULL,"+
            "[SalId] [int] NOT NULL,[TableName] [varchar](100) NOT NULL,[Amount] [numeric](18, 2) NULL,[Month] [varchar](50) NOT NULL,"+
            "[Session] [varchar](50) NOT NULL,[InsertionDate] [datetime] NULL,[Location_id] [numeric](18, 0) NOT NULL,[Company_id] [numeric](18, 0) NOT NULL,";
            strmidlog = strmidlog + "primary key clustered(EmpId,SalId,TableName,Month,Session,Location_id))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Emp_Sal_Ocharge(SqlConnection con)
        {

            string strmidlog = "create table [tbl_Employee_Sal_OCharges]([Slno] [int] IDENTITY(1,1) NOT NULL,[OCId] [int] NOT NULL," + 
       "[OCName] [varchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[Amount] [numeric](18, 2) NULL," + 
       "[Month] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," + 
       "[Session] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," + 
       "[InsertionDate] [datetime] NULL CONSTRAINT [DF_tbl_Employee_Sal_OCharges_InsertionDate]  DEFAULT (getdate())," + 
       "[Location_id] [numeric](18, 0) NOT NULL DEFAULT ((0)),[Company_id] [numeric](18, 0) NOT NULL DEFAULT ((0))," +
       "[ODName] [nvarchar](150) NULL,[AcNo] [nvarchar](50) NULL,[Bank] [nvarchar](150) NULL,[Branch] [nvarchar](150) NULL,[IFSC] [nvarchar](50) NULL)";
          //  strmidlog = strmidlog + "primary key clustered(EmpId,SalId,TableName,Month,Session,Location_id))";
            SqlCommand cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }


        public bool Emp_Sal_ODet(SqlConnection con)
        {

            string strmidlog = "create table [tbl_Employee_Sal_ODet]([Slno] [int] IDENTITY(1,1) NOT NULL," +
       "[ODID] [varchar](50),[ODName] [varchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[AcNo] [varchar](50) NULL,[Bank] [varchar](50) NULL," +
       "[Month] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," +
       "[Session] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," +
       "[InsertionDate] [datetime] NULL CONSTRAINT [DF_tbl_Employee_Sal_ODet_InsertionDate]  DEFAULT (getdate())," +
       "[Location_id] [numeric](18, 0) NOT NULL DEFAULT ((0)),[Company_id] [numeric](18, 0) NOT NULL DEFAULT ((0)))";
            //  strmidlog = strmidlog + "primary key clustered(EmpId,SalId,TableName,Month,Session,Location_id))";
            SqlCommand cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }


                public bool tbl_Sal_Heads_Print_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Sal_Heads_Print([Location_id] [numeric](18, 0) NOT NULL,[BankAcountNo] [bit] NOT NULL,[RefBankAcountNo] [numeric](18, 0) NOT NULL,";
            strmidlog = strmidlog + "[DesignationName] [bit] NOT NULL,[RefDesignationName] [numeric](18, 0) NOT NULL,";
            strmidlog = strmidlog + "[Basic] [bit] NOT NULL,[RefBasic] [numeric](18, 0) NOT NULL,[DaysPresent] [bit] NOT NULL,";
            strmidlog = strmidlog + "[RefDaysPresent] [numeric](18, 0) NOT NULL,[OT] [bit] NOT NULL,[RefOT] [numeric](18, 0) NOT NULL,";
            strmidlog = strmidlog + "[TotalDays] [bit] NOT NULL,[RefTotalDays] [numeric](18, 0) NOT NULL)";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }




         public bool tbl_Emp_Posting_creation(SqlConnection con)
        {
            string strmidlog = "create table [tbl_Emp_Posting]([ID] [numeric](18, 0) NOT NULL,	[Employ_ID] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Cliant_ID] [numeric](18, 0) NULL,	[LOcation_ID] [numeric](18, 0) NULL,[FromDate] [varchar](50) NULL,	[ToDate] [varchar](50) NULL,";
            strmidlog = strmidlog + "[Posting_Month] [varchar](20) NULL,[Order_Person] [varchar](max) NULL,[Order_Date] [varchar](50) NULL,	[UserName] [varchar](max) NULL,";
            strmidlog = strmidlog + "[Transaction_ID] [varchar](50) NULL,[Order_No] [varchar](50) NULL,[Session] [varchar](50) NULL,[DesgId] [numeric](18, 0) NULL,[TDay] [numeric](18, 0) NULL,";
            strmidlog = strmidlog + "primary key clustered(ID))";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

        
	    public bool tbl_Employee_SalaryMast_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_SalaryMast([Slno] [int] IDENTITY(1,1) NOT NULL,[Emp_Id] [varchar](50) NOT NULL,"+
            "[TotalSal] [numeric](18, 2) NULL,[TotalDec] [numeric](18, 2) NULL,[NetPay] [numeric](18, 2) NULL,[Month] [varchar](50) NOT NULL,"+
            "[Session] [varchar](50) NOT NULL,[InsertionDate] [datetime] NULL,[DaysPresent] [numeric](18, 2) NULL,[LeaveWithPay] [numeric](18, 2) NULL,"+
            "[LeaveWithoutPay] [numeric](18, 2) NULL,[TotalDays] [int] NULL,[GrossAmount] [numeric](18, 2) NULL,[PFDue] [numeric](18, 2) NULL,"+
            "[TotalPF] [numeric](18, 2) NULL,[Special] [numeric](18, 2) NULL,[Exgratia] [numeric](18, 2) NULL,[Date_of_Insert] [datetime] NULL,"+
            "[Basic] [numeric](18, 2) NOT NULL,[Location_id] [numeric](18,0) NOT NULL,[OT] [numeric](18, 0) NOT NULL,[Calculate_day] [numeric](18, 0) NOT NULL,";
            strmidlog = strmidlog + "[Company_id] [numeric](18, 0) NOT NULL,[bill_tag] [numeric](18, 0) NOT NULL,[desig_id] [numeric](18, 0) NULL,"+
            "Chk_A [numeric](18, 0) NULL,Chk_L [numeric](18, 0) NULL,Chk_K  [numeric](18, 0) NULL,";
            strmidlog = strmidlog + "primary key clustered(Emp_Id,Month,Session,Location_id))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

          public bool tbl_Employee_SalaryStructure_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_SalaryStructure(SlNo int identity(1,1) not null,SalaryCategory varchar(max) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

                public bool tbl_Employee_ESICodeMaster(SqlConnection con)
        {
            string strmidlog = "create table ESICodeMaster(Slno [numeric](18, 0) identity(1,1) not null,Company_ID [numeric](18, 0) NULL,[ESI_Code] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,primary key clustered(SlNo))";
            
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_PTAXCodeMaster(SqlConnection con)
        {
            string strmidlog = "create table PTAXCodeMaster(Slno [numeric](18, 0) identity(1,1) not null,Company_ID [numeric](18, 0) NULL,[PTAX_Code] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,primary key clustered(SlNo))";
            
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool tbl_Employee_PFCodeMaster(SqlConnection con)
        {
            string strmidlog = "create table PFCodeMaster(Slno [numeric](18, 0) identity(1,1) not null,Company_ID [numeric](18, 0) NULL,[PF_Code] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,primary key clustered(SlNo))";
            
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool tbl_Employee_SectionMaster_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_SectionMaster(SlNo int not null,section varchar(50) not null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Slab_Def_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Slab_Def(SLABID int not null,SLABNAME varchar(50) not null,SLABDESC varchar(50)  null,FID int null,";
            strmidlog = strmidlog + "primary key clustered(SLABID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Employee_Slab_Det_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Employee_Slab_Det(SLABID int not null,SLNO int not null,MINI numeric(15,2) not null,MAXIM nvarchar(50) not null,)";
           
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Exam_Details_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Exam_Details(Class varchar(50) null,Term varchar(50) null,Total_Score int null,Total_No_Class int null,)";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_ExamCodeGeneration_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_ExamCodeGeneration(SlNo  int Identity(1,1) not null,ClassId int null,Subject varchar(50) null,Exam varchar(50) null, RegNo varchar(50) null,RollNo int null,PaperCode int null,ExamAttn int null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Expenditure_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Expenditure(SlNo  int not null,Particulars  varchar(50) null,Date varchar(50) null, VoucherNo varchar(50) null,PayMent int null,TotalExpenditure int null,ClosingBalance int null ,)";
          
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_GovernmentAudit_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_GovernmentAudit(SlNo  int not null,Class  varchar(50) null,RollNo varchar(50) null, Name varchar(50) null,Section varchar(50) null,DevelopmentFee int null,ExaminationFee int null,GameFee int null,LibraryFee int null,MagazineFee int null,Miscellaneous int null,Subscription int null,Furnitere int null,Total int null,TotalWord varchar(50) null,Date  varchar(50) null,)";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_HouseCatg_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_HouseCatg(SLNO  int not null,CLASSID int not null,REGNO varchar(50) not null,HOUSE_CATG varchar(50) null,INSERTIONDATE datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SLNO))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Link_Busmaster_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Link_Busmaster(Ficode  int not null,Gcode int not null,LinkCode varchar(50) not null,BusRutCode varchar(50) not null,BusCode varchar(50) not null,";
            strmidlog = strmidlog + "primary key clustered(Ficode,Gcode,BusRutCode,BusCode))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_LinkFeeAcc_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_LinkFeeAcc(Ficode  char(10) not null,Gcode char(10) not null,Type char(10) not null,FeeID numeric(18,0) not null,FeeName varchar(50) null,Frequency varchar(50) null,GLcode  numeric(18,0) null,ReportHead varchar(50) null,FeeFor varchar(50) null,Feetype varchar(50) null,LedgerName varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(Ficode,Gcode,Type,FeeID))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Markscalculation_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Markscalculation(SlNo  int Identity(1,1) not null,ClassId int  null,CodeFrom int  null,MarksCalculation int null,Anuual int null,OtherExams int null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_NonAccadamic_Datails_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_NonAccadamic_Datails(Ficode int not null,Gcode int not null,RegNo varchar(50) not null,NonAccadamic_Datails varchar(50)  null,Bus_No varchar(50)  null,Bus_Code varchar(50)  null,BusRout_Code varchar(50)  null,";
            strmidlog = strmidlog + "primary key clustered(Ficode,Gcode,RegNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_OnlyForSchool_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_OnlyForSchool(SlNo int not null,Class varchar(50) not null,RollNo varchar(50)  null,Name varchar(50)  null,Section varchar(50)  null,Development int null,UnitTest1 int null,UnitTest2 int null,UnitTest3 int null,UnitTest4 int null,AnnualTest int null,PTest int null,AdmissionTest int null,Miscellaneous int null,Subscription int null,Total int null,TotalWord varchar(50)  null,Date varchar(50)  null,)";
          
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_OtherIncome_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_OtherIncome(SlNo int not null,Date varchar(50) null,Particular varchar(50)  null,SchoolFund int null,Bank int null,Govt int null,DailyTotal int null,)";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_SalStruct_Apply_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_SalStruct_Apply(SlNo int not null,ID varchar(50) not null,Salid int not null,SalHeadNo int not null,SalFED varchar(50) not null,SalHeadShort varchar(30) not null,SalHeApply int not null,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_SchoolLeave_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_SchoolLeave(Student_ID int not null,Student_Name varchar(50) null,Student_Father_Name varchar(50) null,Student_Gurdian_Name varchar(50) null,Date_Of_Birth varchar(50) null,Student_Address varchar(50) null,Student_Phone_No varchar(50) null,)";
        
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_SectionTransferRecord_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_SectionTransferRecord(SlNo int Identity(1,1) not null,RegNo varchar(50) null,ClassId int null,FromSec varchar(50) null,ToSec  varchar(50) null,TransferDate datetime null,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_StudentAttendance_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_StudentAttendance (SlNo int Identity(1,1) not null, RegNo varchar(50),RollNo int ,ClassId int,Section varchar(50),Shift varchar(50),Date datetime,Status bit,Excmd bit,LtrSubmitted datetime,TeachersName varchar(50),SubmitOfcBy datetime,Penalty numeric,PenaltyExcmd bit,NetPenalty numeric,PaidOn datetime,Comments varchar,InsertionDate datetime, ";
            strmidlog = strmidlog + "primary key clustered(SlNo))";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Session_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Session(FromDate datetime not null,ToDate datetime not null,SFiCode char(10) not null,Session nchar(10) null,";
            strmidlog = strmidlog + "primary key clustered(FromDate,ToDate,SFiCode))";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Student_BusCode_Mast_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Student_BusCode_Mast(FiCode char(10) not null,GCode char(10) not null,BusCode varchar(50) not null,RegNo varchar(50) not null,";
            strmidlog = strmidlog + "primary key clustered(FiCode,GCode,BusCode,RegNo))";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Student_BusRoute_Master_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Student_BusRoute_Master(FiCode char(10) not null,GCode char(10) not null,BusRouteCode varchar(50) not null,RegNo varchar(50) not null,";
            strmidlog = strmidlog + "primary key clustered(FiCode,GCode,BusRouteCode,RegNo))";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Student_Fee_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Student_Fee(SlNo int not null,ImportNo int null,RunNo int null,RegNo varchar(50) null,Name varchar(max)  null,Amount varchar(50) null,FeeType varchar(50) null,InsertionDate datetime not null DEFAULT(getdate()),UserID varchar(50) null,UserName varchar(50) null,InsertStatus int null,PendingStatus int null,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Student_FeesDet_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Student_FeesDet(Ficode char(10) not null,Gcode char(10) not null,SlNo int Identity(1,1) not null,ReceiptNo numeric(18,0) null,RegNo varchar(50) not null,FeeID numeric(18,0) null,PaidVal numeric(18,0) null,InsertionDate datetime not null DEFAULT(getdate()),Type int null,";
            strmidlog = strmidlog + "primary key clustered(Ficode,Gcode,SlNo))";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Student_FeesDet_Temp_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Student_FeesDet_Temp(Ficode char(10) not null,Gcode char(10) not null,SlNo int null,ReceiptNo numeric(18,0) null,RegNo varchar(50) not null,FeeID numeric(18,0) null,PaidVal numeric(18,0) null,InsertionDate datetime not null DEFAULT(getdate()),Code int null,)";
           

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Student_FeesMast_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Student_FeesMast(Ficode char(10) not null,Gcode char(10) not null,ReceiptNo  numeric(18,0) not null,RegNo varchar(50) not null,ClassId int not null,RefEmpId varchar(50) null,TotalFees decimal(18,2) null,LateFine decimal(18,2) null,PrevDue decimal(18,2) null,PrevRefund decimal(18,2) null,DueFees decimal(18,2) null,RefundFees decimal(18,2) null,AmountPaid decimal(18,2) null,PaymentMode varchar(50) null,ChequeDate datetime null,BankName varchar(max) null,iswaviedoff bit null,monthof varchar(50) null,voucher numeric(18,0) null,SubmissionDate datetime null,InsertionDate datetime not null DEFAULT(getdate()),Session varchar(50) null,AutoIncre  numeric(18,0) identity(1,1) not null,MonthlyFees varchar(50) null,Type int null,";
            strmidlog = strmidlog + "primary key clustered(Ficode,Gcode,ReceiptNo,AutoIncre))";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Student_FeesMast_Temp_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Student_FeesMast_Temp(Ficode char(10) not null,Gcode char(10) not null,ReceiptNo  numeric(18,0)  null,RegNo varchar(50) not null,ClassId int not null,RefEmpId varchar(50) null,TotalFees decimal(18,2) null,LateFine decimal(18,2) null,PrevDue decimal(18,2) null,PrevRefund decimal(18,2) null,DueFees decimal(18,2) null,RefundFees decimal(18,2) null,AmountPaid decimal(18,2) null,PaymentMode varchar(50) null,ChequeDate datetime null,BankName varchar(max) null,iswaviedoff bit null,monthof varchar(50) null,voucher numeric(18,0) null,SubmissionDate datetime null,InsertionDate datetime not null DEFAULT(getdate()),Session varchar(50) null,Code int null,)";
            
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Student_PromotionDetails_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Student_PromotionDetails(FICode char(10) not null,GCODE char(10) not null,SlNo  int not null,RegNo varchar(50) not null,OldClassId int not null,NewClassId int null,MarksOf varchar(100) null,MarksToPromote int null,AttendenceToPromote  int null,DueFeesToPromote int null,LibClearance int null,Promoted bit null,PromotedByAuthority int not null,Comments varchar(max) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,SlNo))";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //public bool tbl_StudentAttendance_table_creation(SqlConnection con)
        //{
        //    string strmidlog = "create table tbl_StudentAttendance(SlNo int not null,RegNo varchar(50) not null,RollNo int not null,ClassId int not null,Section varchar(50) not null,Shift varchar(50) not null,Date datetime null,Status bit null,Excmd bit null,LtrSubmitted datetime null,TeachersName varchar(50) null,SubmitOfcBy datetime null,Penalty numeric(18,2) null,PenaltyExcmd bit null,NetPenalty numeric(18,2) null,PaidOn datetime null,Comments varchar(max) null,InsertionDate datetime not null DEFAULT(getdate()),";
        //    strmidlog = strmidlog + "primary key clustered(FICode,GCODE,SlNo))";

        //    SqlCommand cmd;
        //    cmd = new SqlCommand(strmidlog, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        public bool tbl_StudentDetails_Addmission_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_StudentDetails_Addmission(Student_ID int not null,Enrollment_No varchar(50) not null,Student_Name varchar(50) null,Student_Father_Name varchar(50) null,Student_Gurdian_Name varchar(50) null,RefEmpId varchar(50) null,Date_Of_Birth varchar(50) null,Student_Address varchar(50) null,Class varchar(50) null,Old_Class varchar(50) null,Student_Phone_No varchar(50) null,Student_Gender varchar(50) null,Student_Cast varchar(50) null,Date_Of_Admission varchar(50) null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(Student_ID))";

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_StudentDetails_Class_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_StudentDetails_Class(Student_ID int  null,Enrollment_No varchar(50) null,Class_Enrollment_No varchar(50) null,Student_Name varchar(50) null,Class varchar(50) null,Section varchar(50) null,Roll_No varchar(50) null,)";
         

            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_StudentDetails_Result_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_StudentDetails_Result(SlNo int identity(1,1) not null,RegNo varchar(50) null,Class_Id int not null,RollNo varchar(50) null,Student_Name varchar(50) null,Name_Subject varchar(50) null,Term varchar(50) null,PaperCode varchar(50) null,Written varchar(50) null,Oral numeric(18,0) null,Student_Score int null,Average decimal (18,0) null,Total_score int null,GrandTotal int null,Grand_Average decimal (18,2) null,Comments varchar(50) null,Attendence int null,ResultCondition  varchar(50) null,WrittenExamed int null,OralExamed int null,ExamDate datetime null,OriginalScore int null,";
            strmidlog = strmidlog + "primary key clustered(SlNo))";
            
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_StudentpreAddmission_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_StudentpreAddmission(SFiCode char(10) not null,Sl_No int  IDENTITY(1,1) not null,Date datetime null,FormNo varchar(50) null,Student_Fname  varchar(50) null,Student_Mname varchar(50) null,Student_Lname varchar(50) null,Fath_Fn varchar(50) null,Fath_Mn varchar(50) null,Fath_Ln varchar(50) null,Moth_Fn varchar(50) null,Moth_Mn varchar(50) null,Moth_Ln varchar(50) null,ClassId int null,Address varchar(max) null,PhoneNo varchar(50) null,DateOfInterview datetime null,Admitted int null,Gender varchar(50) null,";
            strmidlog = strmidlog + "primary key clustered(SFiCode,Sl_No))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_StudentPreAdmList_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_StudentPreAdmList(SFiCode char(10) not null,SlNo int IDENTITY(1,1) not null,FormNo varchar(50) null,Passed  int null,Admitted int null,InsertionDate datetime not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(SFiCode,SlNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Students_Leave_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Students_Leave(FICode char(10) not null,GCODE char(10) not null,SFicode  char(10) not null,FormNo int not null,RegNo varchar(50) not null,RollNo int not null,ClassAdmission varchar(50)  null,Section varchar(50)  null,Shift varchar(50)  null,Session varchar(50)  null, OldClassId int null,ClassId int null,StudentFirstName varchar(50)  null,StudentMiddleName varchar(50)  null,StudentLastName varchar(50)  null,Gender varchar(10)  null,Nationality varchar(10)  null,Religion varchar(10)  null,MotherTongue  varchar(10)  null,Caste varchar(10)  null,BloodGroup varchar(10)  null,DateOfBirth datetime null,AgeOn varchar(50)  null,Age varchar(50)  null,AgeReason varchar(max) null,BirthCertificateIsuuedBy varchar(50) null,PresentAddress varchar(50) null,PresentPlace varchar(50) null,PresentState varchar(50) null,PresentPIN varchar(50) null,PresentRlyStn varchar(50) null,PresentDist varchar(50) null,PresentPhone varchar(50) null,PermanentAddress varchar(50) null,PermanentPlace varchar(50) null,PermanentState varchar(50) null,PermanentPIN varchar(50) null,PermanentRlyStn varchar(50) null,PermanentDist varchar(50) null,PermanentPhone varchar(50) null,PFromSchool varchar(50) null,TCSubmited varchar(50) null,InsertionDate datetime  not null DEFAULT(getdate()),AdmissionDate datetime null,UnicNo varchar(50) null,Type varchar(50) null,CertificateType varchar(50) null,LeavingCertificateCount int null,TransferCertificateCount int null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,SFicode,RegNo))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Students_Leaving_ParentsDetail_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Students_Leaving_ParentsDetail(FICode char(10) not null,GCODE char(10) not null,SFicode  char(10) not null,Id int not null,RegNo varchar(50) not null,Father_Title varchar(50)  null,Father_FirstName varchar(50)  null,Father_MiddleName varchar(50)  null,Father_LastName varchar(50)  null,Father_Occupation varchar(max) null, Father_AvgMonthlyIncome varchar(50)  null,Father_CompanyName varchar(50)  null,Father_Department varchar(50)  null,Father_Designation varchar(50)  null,Father_Address varchar(50)  null,Father_Phone varchar(50)  null,Father_Extn varchar(50)  null,Father_Fax varchar(50)  null,Father_Email  varchar(50)  null,Father_Mobile varchar(50)  null,Mother_Title varchar(50)  null,Mother_FirstName varchar(50)  null,Mother_MiddleName varchar(50)  null,Mother_LastName varchar(50)  null,Mother_Occupation varchar(max) null,Mother_AvgMonthlyIncome varchar(50) null,PresentAddress varchar(50) null,PresentPlace varchar(50) null,Mother_CompanyName varchar(50) null,Mother_Department varchar(50) null,Mother_Designation varchar(50) null,Mother_Address varchar(50) null,Mother_Phone varchar(50) null,Mother_Extn varchar(50) null,Mother_Fax varchar(50) null,Mother_Email varchar(50) null,Mother_Mobile varchar(50) null,RefRegNo varchar(50) null,RefName varchar(50) null,RefClass varchar(50) null,RefSection varchar(50) null,RefShift varchar(50) null,RecGuardian_Title varchar(50) null,RecGuardian_FirstName varchar(50) null,RecGuardian_MiddleName varchar(50) null,RecGuardian_LastName varchar(50) null,RelationWithStudent varchar(50) null,RecGuardian_Occupation varchar(max) null,RecGuardian_AvgMonthlyIncome varchar(50) null,RecGuardian_Company varchar(50) null,RecGuardian_Department varchar(50) null,RecGuardian_Designation varchar(50) null,RecGuardian_Address varchar(50) null,RecGuardian_Phone varchar(50) null,RecGuardian_Fax varchar(50) null,RecGuardian_Email varchar(50) null,RecGuardian_Mobile varchar(50) null,LivingWith varchar(50) null,InsertionDate datetime  not null DEFAULT(getdate()),";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,SFicode,Id))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_Total_Employee_Pay_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_Total_Employee_Pay(Year_Of varchar(50) null,Month_Of varchar(50) null,Total_Basic_Pay int null,Total_DPay int null,Total_DA int null,Total_HRA int null,Total_MA int null,Total_Gross_Ammount int null,Total_PF int null,Total_PTax int null,ShortFall int null,Total_Net_Amount int null,Total_Net_Amount_Word varchar(50)  null,)";
         //,strmidlog = strmidlog + "primary key clustered(FICode,GCODE,SFicode,Id))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_TotalIncome_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_TotalIncome(TotalIncome int null,)";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_TotalPay_table_creation(SqlConnection con)
        {
            string strmidlog = "create table tbl_TotalPay(Month varchar(50) null,Year varchar(50) null,TotalPay int null,TotalPayWord varchar(50) null,)";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool temp_table_creation(SqlConnection con)
        {
            string strmidlog = "create table temp(FICode char(10) not null,GCODE char(10) not null,SFicode char(10) not null,FormNo int not null,RegNo varchar(50) not null,Col varchar(50) null,Col1 varchar(50) null,Col2 varchar(50) null,Col3 varchar(50) null,Col4 varchar(50) null,Col5 varchar(50) null,Col6 varchar(50) null,Col7 varchar(50) null,Col8 varchar(50) null,Col9 varchar(50) null,)";
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TypeDoc_table_creation(SqlConnection con)
        {
            string strmidlog = "create table TypeDoc(FICode char(10) not null,GCODE char(10) not null,T_ENTRY char(2) not null,Desccode numeric(18,0) not null,Type_Desc varchar(50) null,Specific_Acc bit null,METHOD char(1) null,Effect_Amt bit null,Req_Acc bit null)";
           // strmidlog = strmidlog + "CONSTRAINT [PK__TypeDoc__6F7F8B4B] primary key clustered(FICode,GCODE,T_ENTRY,Desccode))";
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TypeMast_table_creation(SqlConnection con)
        {
            string strmidlog = "create table TypeMast(FICode char(10) not null,GCODE char(10) not null,T_ENTRY char(2) not null,TypeName varchar(50) not null,TRAN_HEAD varchar(100) null,";
            strmidlog = strmidlog + "primary key clustered(FICode,GCODE,T_ENTRY,TypeName))";
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ufldval_table_creation(SqlConnection con)
        {
            string strmidlog = "create table ufldval(GCODE char(10) not null,VTYPE char(10) not null,T_ENTRY char(1) not null,VOUCHER varchar(5) not null,FIELD_ID varchar(6) not null,AUTOINCRE int not null,USER_VCH varchar(25) null,VCH_DATE datetime null,FLD_VAL varchar(50) null,PREV_VAL bit null,PRINT_VAL bit null,";
            strmidlog = strmidlog + "primary key clustered(GCODE,VTYPE,T_ENTRY,VOUCHER,FIELD_ID,AUTOINCRE))";
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool unit_table_creation(SqlConnection con)
        {
            string strmidlog = "create table unit(FIcode char(10) not null,GCODE char(10) not null,UCODE numeric(18,0) not null,UDESC varchar(10) not null,DEC_PLACE int null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,UCODE))";
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool unitrel_table_creation(SqlConnection con)
        {
            string strmidlog = "create table unitrel(Ficode char(10) not null,GCODE char(10) not null,Autoincre numeric(18,0) not null,PCODE varchar(6) null,UNIT_F varchar(6) not null,UNIT_T  varchar(6) not null,CONV_RATE float null,";
            strmidlog = strmidlog + "primary key clustered(FIcode,GCODE,Autoincre))";
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool userfld_table_creation(SqlConnection con)
        {
            string strmidlog = "create table userfld(GCODE char(10) not null,FIELD_ID  varchar(6) not null,FIELD_NAME varchar(20) not null,FIELD_LEN int null,FIELD_MAX int null,AVCH_TAG varchar(10) null,IVCH_TAG varchar(26) null,NVCH_TAG varchar(20) null,FIELD_TYPE char(1) null,_CHECK bit null,FIELD_FORMAT varchar(20) null,PRNT_ANNVAL bit null,PRNT_FLG bit null,PRNT_ANNNAME varchar(40) null,DFLT_VAL varchar(40) null,";
            strmidlog = strmidlog + "primary key clustered(GCODE,FIELD_ID,FIELD_NAME))";
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool vchlock_table_creation(SqlConnection con)
        {
            string strmidlog = "create table vchlock(GCODE char(10) not null,VTYPE  char(1) not null,T_ENTRY char(1) not null,VOUCHER varchar(5) not null,USER_VCH varchar(40) null,EDITFLAG char(1) null,USERCODE varchar(6) null,MODIFIED bit null,ZEROFLG char(1) null,";
            strmidlog = strmidlog + "primary key clustered(GCODE,VTYPE,T_ENTRY,VOUCHER))";
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool vchr_table_creation(SqlConnection con)
        {
            string strmidlog = "create table vchr(FICODE char(10) not null,GCODE  char(10) not null,T_ENTRY char(2) not null,VOUCHER numeric(18,0) not null,AUTOINCRE numeric(10,0) not null,USER_VCH varchar(100)  null,VCHDATE datetime null,GLCODE numeric(18,0) not null,CRAMT money not null,TOBY money not null,POSTED bit null,RDATE datetime null,DUMMY_FLD char(1) null,FC_DBAMT money null,FC_CRAMT money null,MEMO_VCH bit null,DBAMT money null,Effect bit null,DifineUnder char(3) null,Taxtype bit null,linkvoucher numeric(18,0) null,linkTentry char(2) null,PFCode numeric(18,0) null,";
            strmidlog = strmidlog + "primary key clustered(FICODE,GCODE,T_ENTRY,VOUCHER,AUTOINCRE))";
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool wacclog_table_creation(SqlConnection con)
        {
            string strmidlog = "create table wacclog(LOG_UCODE varchar(6) not null,LOG_GCODE char(10) not null,LOG_CCODE char(10) not null,AUTOINCRE int not null,FORM_NAME varchar(40) null,FORM_CODE int null,DATE_FROM datetime  null,TIME_FROM datetime  null,DATE_TO datetime  null,TIME_TO datetime  null,LOG_STAT int  null,MACHINE_NAME varchar(20) null,Exclusive bit null,session_no int null,";
            strmidlog = strmidlog + "primary key clustered(LOG_UCODE,LOG_GCODE,LOG_CCODE,AUTOINCRE))";
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool GenarateFicode_table_creation(SqlConnection con)
        {
            string strmidlog = "create table GenarateFicode(Sl_No int identity(1,1) not null,Session varchar(50) not null,FromDate datetime null,ToDate datetime null,Ficode numeric(18,0) null,Gcode numeric(18,0) null,";
            strmidlog = strmidlog + "primary key clustered(Sl_No,Session))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //end
        public bool AccordFourlogDetail_table_creation(SqlConnection con)
        {
            string strmidlog = "create table AccordFourlogDetail([LOG_UCODE] [varchar](6) NOT NULL,[LOG_GCODE] [char](10) NOT NULL,	[LOG_CCODE] [char](10) NOT NULL,";
            strmidlog = strmidlog + "[AUTOINCRE] [int] IDENTITY(1,1) NOT NULL,[Company_NAME] [varchar](100) NULL,[FORM_CODE] [int] NULL,";
            strmidlog = strmidlog + "[DATE_FROM] [datetime] NULL,[TIME_FROM] [varchar](50) NULL,[DATE_TO] [datetime] NULL,";
            strmidlog = strmidlog + "[TIME_TO] [varchar](50) NULL,[LOG_STAT] [int] NULL,[MACHINE_NAME] [varchar](20) NULL,";
            strmidlog = strmidlog + "[Exclusive] [bit] NULL,[session_no] [int] NULL,";

            strmidlog = strmidlog + "primary key clustered(LOG_UCODE,LOG_GCODE,LOG_CCODE,AUTOINCRE ))";
            SqlCommand cmd;
            cmd = new SqlCommand(strmidlog, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //public bool narr_table_creation(SqlConnection con)
        //{
        //    string strnarr = "create table narr(FICode char(10) not null,GCODE char(10) not null,";
        //    strnarr = strnarr + "T_ENTRY char(2) not null,VOUCHER numeric not null,AUTOINCRE int IDENTITY(1,1) not null,";
        //    strnarr = strnarr + "GAMT money,AMT_TYPE char(2),GDATE	datetime,GCODE1	varchar(6),GCODE2 varchar(6),";
        //    strnarr = strnarr + "CHQ_DATE datetime,CHQ_NO varchar(15),BRNCH_CODE numeric,PICTURE image,";
        //    strnarr = strnarr + "CURR_CODE varchar(6),NCONV_FCTR float,DCONV_FCTR float,PRO_STATUS	bit,";
        //    strnarr = strnarr + "GDATE2	datetime,FC_GAMT money, NTYPE char(3),NAR1 text,PAYEE_NAME	varchar(40),linkvoucher numeric,linkTentry char(2), ";
        //    strnarr = strnarr + "primary key clustered(FICode,GCODE,T_ENTRY,VOUCHER,AUTOINCRE))";
        //    SqlCommand cmd = new SqlCommand(strnarr, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool MdsOption_table_creation(SqlConnection con)
        //{
        //    string MdsOption = "create table AccordFourOPTN(FICode char(10) not null,GCODE char(10) not null,";
        //    MdsOption = MdsOption + "USER_CODE numeric not null,CNFG_CODE Varchar(50)not null,PARENT_CODE Varchar(50) not null,";
        //    MdsOption = MdsOption + "STR_VAL varchar(100),Bool_VAL bit,NUM_VAL numeric,DATE_VAL Datetime,";
        //    MdsOption = MdsOption + "primary key clustered(FICode,GCODE,USER_CODE,CNFG_CODE))";
        //    SqlCommand cmd = new SqlCommand(MdsOption, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //dutta da start
        public bool password_table_creation(SqlConnection con)
        {
            string strpasword = "create table pasword(USER_CODE varchar(6) not null,";
            strpasword = strpasword + "USER_DESC varchar(500),PLV_CODE varchar(6),";
            strpasword = strpasword + "USER_LEV varchar(20),PSWD_DESC varchar(500),";
            strpasword = strpasword + "EXCLUSIVE_USE_RIGHT bit,PSWD_VALIDTILL_DATE datetime,";
            strpasword = strpasword + "PSWD_VALIDTILL_SESSION int,PSWD_CHANGE_ATFIRSTSESSION bit,";
            strpasword = strpasword + "PSWD_VALIDITY char(1),WebAccess bit,";
            strpasword = strpasword + "primary key clustered(USER_CODE))";
            SqlCommand cmd = new SqlCommand(strpasword, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //dutta da start
        public bool Authentication_Table(SqlConnection con)
        {
            string strpasword = "create table [tbl_Authentication](SlNo int,";
            strpasword = strpasword + "UserID varchar(100),";
            strpasword = strpasword + "UserPassword varchar(100))";           
            SqlCommand cmd = new SqlCommand(strpasword, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //dutta da start
        public bool CreateSession_Table(SqlConnection con)
        {
            string StrSession = "create table [tbl_Session](FromDate datetime,";
            StrSession = StrSession + "ToDate datetime,";
            StrSession = StrSession + "SFiCode char(10),";
            StrSession = StrSession + "Session nchar(10)";
            StrSession = StrSession + "primary key clustered(FromDate,ToDate,SFiCode))";
            SqlCommand cmd = new SqlCommand(StrSession, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public bool Formula_table_creation(SqlConnection con)
        //{
        //    string strFormula = "create table FORMULA (PROC_CODE numeric (18,0) NOT NULL,MTYPE VARCHAR(10) NOT NULL,AUTOINCRE int IDENTITY(1,1) not null,PCODE numeric (18,0),QTY numeric (18,2),UCODE numeric (18,0),PQTY numeric (18,0),PUCODE numeric (18,0),COST_PERC numeric (18,2),Series_ID numeric (18,0),primary key clustered (PROC_CODE,MTYPE,AUTOINCRE))";
        //    SqlCommand cmd = new SqlCommand(strFormula, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool Process_table_creation(SqlConnection con)
        //{
        //    string strProcess = "create table PROCESS (PROC_CODE numeric (18,0) NOT NULL,PROC_DESC VARCHAR(60),PLV_CODE numeric (18,0),PROC_LEV numeric (18,0),primary key clustered (PROC_CODE));";
        //    SqlCommand cmd = new SqlCommand(strProcess, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool pltran_table_creation(SqlConnection con)
        //{
        //    string strpltrn = "create table PLTran(FICode char(10)not null,GCODE char(10) not null,T_ENTRY char(2) not null,VOUCHER numeric not null,";
        //    strpltrn = strpltrn + "AUTOINCRE numeric IDENTITY(1,1) not null,PCODE numeric,EffectiveQTY float,EffectiveRATE float,EffectiveAMT money,";
        //    strpltrn = strpltrn + "AgainstVoucher varchar(100),AgainstVoucherDate datetime,AgainstRate float,Profit_Loss money,DPCODE numeric,AgainstTentry char(2),AgainstVoucherCode numeric,AgainstAutoIncre numeric ,RowIndex numeric,Comment Varchar(50),ItemNo numeric,linkTentry char(2),ActualAmt money, ";
        //    strpltrn = strpltrn + "primary key clustered(FICode,GCODE,T_ENTRY,VOUCHER,AUTOINCRE))";
        //    SqlCommand cmd = new SqlCommand(strpltrn, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool prtyms_table_creation(SqlConnection con)
        //{
        //    string strprtyms = "create table prtyms(FICode char(10)not null,GCODE char(10)not null,";
        //    strprtyms = strprtyms + "GLCode numeric not null,ACC_ADD1 varchar(max),ACC_ADD2 varchar(max),";
        //    strprtyms = strprtyms + "ACC_CITY varchar(20),ACC_STATE varchar(50),";
        //    strprtyms = strprtyms + "ACC_PIN varchar(10),ACC_COUNTRY varchar(50),CONTACT_PERSON	varchar(50),ACC_DESIG varchar(50),";
        //    strprtyms = strprtyms + "ACC_TELE1 varchar(20),ACC_TELE2 varchar(20),ACC_TELE3 varchar(20),ACC_FAX varchar(50),ACC_Email varchar(50),";
        //    strprtyms = strprtyms + "ACC_CIN varchar(50),ACC_ServiceTaxNo varchar(50),DIN varchar(50),IT_PAN varchar(50),";
        //    strprtyms = strprtyms + "TAN_NO	varchar(50),EX_REG_NO varchar(50),EX_DIV varchar(50),EX_RANGE varchar(50),EX_COMM varchar(50),ECC_NO varchar(50),CRED_DAYS int,";
        //    strprtyms = strprtyms + "TDS_RATE float,RCV_INT	float,PAY_INT float,CREDIT_LIMIT float,BRKG_PERCENTAGE	float,";
        //    strprtyms = strprtyms + "AUTOADJUSTMENT	bit,BAdd1 varchar(50),BAdd2 varchar(50),BCity varchar(50),BState varchar(50),";
        //    strprtyms = strprtyms + "BCountry varchar(50),BPin varchar(50),BContact varchar(50),BDesig varchar(50),BTele1 varchar(50),BTele2 varchar(50),BTele3 varchar(50),BFax varchar(50),BEmail varchar(50),";
        //    strprtyms = strprtyms + "CAdd1 varchar(50),CAdd2 varchar(50),CCity varchar(50),CState varchar(50),CCountry varchar(50),CPin varchar(50),CContact varchar(50),CDesig varchar(50),CTele1 varchar(50),CTele2 varchar(50), ";
        //    strprtyms = strprtyms + "CTele3 varchar(50),CFax varchar(50),CEmail varchar(50),brokShrtsl float,brokPurchase float,STT float,SERVICE_TAX float,TIN VARCHAR(50),ACC_STT VARCHAR(50),";
        //    strprtyms = strprtyms + "primary key clustered(FICode,GCODE,GLCode))";
        //    SqlCommand cmd = new SqlCommand(strprtyms, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool share_info_table_creation(SqlConnection con)
        //{
        //    string strsinfo = "create table SHARE_INFO (FICODE char(10) NOT NULL ,GCODE char(10) NOT NULL ,T_ENTRY char(2) NOT NULL ,VOUCHER numeric(18, 0) NOT NULL ,";
        //    strsinfo = strsinfo + "AUTOINCRE numeric(18, 0) IDENTITY (1, 1) NOT NULL ,PCODE numeric(18, 0) NOT NULL ,Crtfct_From varchar (50)   ,Crtfct_To varchar (50)   ,";
        //    strsinfo = strsinfo + "Crtfct_No varchar (50)   ,Dstntv_From numeric(18, 0)  ,Dstntv_To numeric(18, 0)  ,Location varchar (50)   ,Units numeric(18, 0)  ,";
        //    strsinfo = strsinfo + "Ufrom numeric(18, 0)  ,Uto numeric(18, 0)  ,DPCode numeric(18, 0)  ,ItemNo int  ,RowIndex int  ,Nominee_ID int , ";
        //    strsinfo = strsinfo + "PRIMARY KEY  CLUSTERED(FICODE,GCODE,T_ENTRY,VOUCHER,AUTOINCRE,PCODE))";

        //    SqlCommand cmd = new SqlCommand(strsinfo, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool NomineeMaster(SqlConnection con)
        //{
        //    string strnominee = "create table NomineeMaster (GCODE char(10) NOT NULL,ID int NOT NULL ,Type char(2) NOT NULL ,Parent int NOT NULL ,";
        //    strnominee = strnominee + "Nominee_Name varchar(30) ,Nominee_DOB datetime ,Relation varchar (30) ,Nominee_Gur varchar(30) , Internal int ,Link_Gcode char(10),";
        //    strnominee = strnominee + "PRIMARY KEY  CLUSTERED(GCODE,ID,Type))";

        //    SqlCommand cmd = new SqlCommand(strnominee, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool MFDET_table_creation(SqlConnection con)
        //{
        //    string strmfdet = "create table [MFDET]([FICODE] [char](10)  NOT NULL," + "[GCODE] [char](10) NOT NULL," + "[T_ENTRY] [char](2) NOT NULL," +
        //                     "[VOUCHER] [numeric](18, 0) NOT NULL," + "[USER_VOUCHER] [varchar](50) NULL," + "[AUTO_INCR] [int] IDENTITY(1,1) NOT NULL," + "[PCODE] [numeric](18, 0) NULL," +
        //                     "[TRANTYPE] [varchar](50)  NULL," + "[NAV] [float] NULL," + "[UNITS] [float] NULL," + "[AMOUNT] [money] NULL,[LINKVCHR] [numeric](18, 0) NULL," + "PRIMARY KEY CLUSTERED([FICODE] ASC,[GCODE] ASC,[T_ENTRY] ASC,[VOUCHER] ASC,[AUTO_INCR] ASC))";
        //    SqlCommand cmd = new SqlCommand(strmfdet, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool MFMST_table_creation(SqlConnection con)
        //{
        //    string strmfmst = " create table [MFMST]([FICODE] [char](10) NOT NULL,[GCODE] [char](10) NOT NULL, [T_ENTRY] [char](2)  NOT NULL," +
        //                    "[VOUCHER] [numeric](18, 0) NOT NULL,[USER_VOUCHER] [varchar](50)  NULL,[AUTO_INCR] [int] IDENTITY(1,1) NOT NULL," +
        //                    "[DMFACNO] [varchar](max)  NULL,[LINKACNO] [varchar](max)  NULL,[RowLock] [bit] NULL  DEFAULT ((0)),PRIMARY KEY CLUSTERED ([FICODE] ASC,[GCODE] ASC,[T_ENTRY] ASC,[VOUCHER] ASC,[AUTO_INCR] ASC))";
        //    SqlCommand cmd = new SqlCommand(strmfmst, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool taxdetails_table_creation(SqlConnection con)
        //{
        //    string strtaxdet = "create table TaxDetail(FICode char(10)not null,GCODE char(10)not null,glcode numeric not null,T_DESC varchar(50) not null,";
        //    strtaxdet = strtaxdet + "T_RATE	float,CODE	varchar(50),INITIALS varchar(20),TAX_TYPE char(1),EFFECT char(1),TYPE_CODE	numeric,";
        //    strtaxdet = strtaxdet + "primary key clustered(FICode,GCODE,glcode,T_DESC))";
        //    SqlCommand cmd = new SqlCommand(strtaxdet, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool taxmaster_table_creation(SqlConnection con)
        //{
        //    string strtaxmst = "create table TaxMaster(FICode char(10)not null,GCODE char(10)not null,Types	varchar(50) not null,";
        //    strtaxmst = strtaxmst + "Type_Code	numeric not null,TaxStatus bit,VIEW_STAT	bit	,";
        //    strtaxmst = strtaxmst + "primary key clustered(FICode,GCODE,Types,Type_Code))";
        //    SqlCommand cmd = new SqlCommand(strtaxmst, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool typedoc_table_creation(SqlConnection con)
        //{
        //    string strtypedoc = "create table TypeDoc(FICode char(10)not null,GCODE char(10)not null,T_ENTRY char(2) not null,";
        //    strtypedoc = strtypedoc + "Desccode	numeric	not null,Type_Desc	varchar(50),Specific_Acc bit,METHOD	char(1),Effect_Amt	bit,Req_Acc	bit,User_Code Varchar(10) not null,";
        //    strtypedoc = strtypedoc + "primary key clustered(FICode,GCODE,T_ENTRY,Desccode,User_Code))";
        //    SqlCommand cmd = new SqlCommand(strtypedoc, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool typemast_table_creation(SqlConnection con)
        //{
        //    string strtypemst = "create table TypeMast(FICode char(10)not null,GCODE char(10)not null,T_ENTRY char(20) not null,";
        //    strtypemst = strtypemst + "TypeName	varchar(50) not null,TRAN_HEAD varchar(100),";
        //    strtypemst = strtypemst + "primary key clustered(FICode,GCODE,T_ENTRY))";
        //    SqlCommand cmd = new SqlCommand(strtypemst, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool vchlock_table_creation(SqlConnection con)
        //{
        //    string strvchlock = "create table vchlock(FICode char(10) not null,GCODE char(10) not null,VTYPE char(10) not null,T_ENTRY char(2) not null,VOUCHER numeric not null,";
        //    strvchlock = strvchlock + "[AutoIncre] [numeric](18, 0) IDENTITY(1,1) NOT NULL,USER_VCH	varchar(100),EDITFLAG char(1),USERCODE varchar(6),MODIFIED bit,ZEROFLG char(1),ViewFlag bit,Trans_Type char(10),Cancel_Flag bit,";
        //    strvchlock = strvchlock + "primary key clustered(FICode,GCODE,VTYPE,T_ENTRY,VOUCHER,[AutoIncre]))";
        //    SqlCommand cmd = new SqlCommand(strvchlock, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool vchr_table_creation(SqlConnection con)
        //{
        //    string strvchr = "create table vchr(FICode char(10) not null,GCode char(10) not null,T_ENTRY char(2)not null,VOUCHER numeric not null,";
        //    strvchr = strvchr + " AUTOINCRE int IDENTITY(1,1) not null,USER_VCH varchar(100),VCHDATE datetime,GLCODE numeric not null,";
        //    strvchr = strvchr + "CRAMT money not null,TOBY char(2)not null,POSTED bit,RDATE datetime,DUMMY_FLD char(1),";
        //    strvchr = strvchr + "FC_DBAMT money ,FC_CRAMT money,MEMO_VCH bit,DBAMT money,Effect bit,DifineUnder char(3),Taxtype bit,linkvoucher numeric,linkTentry char(2), ";
        //    strvchr = strvchr + "primary key clustered(FICode,GCode,T_ENTRY,AUTOINCRE,VOUCHER))";
        //    SqlCommand cmd = new SqlCommand(strvchr, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool UnitSeries_creation(SqlConnection con)
        //{
        //    string strvchr = "create table UnitSeriesMaster(FICode char(10) not null,GCode char(10) not null,SM_ID numeric (18,0) not null,SM_NAME varchar (200),UCODE numeric (18,0),primary key clustered(FICode,GCode,SM_ID,UCODE))";
        //    SqlCommand cmd = new SqlCommand(strvchr, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
           
        //}

        //public bool UnitRelationMaster_creation(SqlConnection con)  
        //{
        //    string strvchr = "create table UnitRelationMaster(FICode char(10) not null,GCode char(10) not null,SM_ID numeric (18,0) not null,PCODE numeric (18,0),UnitF numeric (18,0),UnitT numeric (18,0),Conv_Fig numeric (18,4),primary key clustered(FICode,GCode,SM_ID,PCODE,UnitF,UnitT))";
        //    SqlCommand cmd = new SqlCommand(strvchr, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }          
        //}

        public bool Country_table_creation(SqlConnection con)
        {
            string Country = "create table Country (Country_CODE numeric (18,0) NOT NULL,Country_Name VARCHAR (200) NOT NULL,Country_Detail numeric (18,0),Currency_Name VARCHAR (100) NULL,primary key clustered (Country_CODE))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

                public bool StateMaster_table_creation(SqlConnection con)
        {
            string Country = "create table StateMaster (STATE_CODE numeric (18,0) NOT NULL,State_Name VARCHAR (200) NOT NULL,Country_Code numeric (18,0),primary key clustered (STATE_CODE))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AccessLocation_table_creation(SqlConnection con)
        {
            string Country = "create table AccessLocation (USER_CODE varchar (6) NOT NULL,FICode CHAR (10) NOT NULL,GCODE CHAR (10) NOT NULL,LOC_CODE numeric (18, 0) NOT NULL,primary key (USER_CODE,FICode,GCODE,LOC_CODE))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

                public bool AccessLocation_tbl_Emp_Location(SqlConnection con)
        {
            string Country = "create table tbl_Emp_Location (Location_ID numeric (18, 0) NOT NULL,Location_Name varchar (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,Cliant_ID numeric (18, 0) NOT NULL,primary key CLUSTERED (Location_ID))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AccessLocation_paybill(SqlConnection con)
        {
            string Country = "create table paybill (AUTOINCRE int IDENTITY(1,1) NOT NULL,BILLNO varchar (50) NOT NULL,BILLDATE [datetime] NULL,Comany_id numeric (18, 0) NOT NULL,Session varchar (50) NOT NULL,Location_ID numeric (18, 0) NOT NULL,Month varchar (50) NULL,TotAMT [money] NULL,IsService bit NULL,ServiceAmount [money] NULL,Cliant_ID numeric (18, 0) NOT NULL,primary key CLUSTERED (BILLNO,AUTOINCRE))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

                public bool AccessLocation_MonthOfDays(SqlConnection con)
        {
            string Country = "create table MonthOfDays (MONTH_CODE numeric (18, 0) NOT NULL,MONTH_Name varchar (100) NULL,Country_Code numeric (18, 0) NULL,primary key CLUSTERED (MONTH_CODE))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

                        public bool AccessLocation_HourMaster(SqlConnection con)
        {
            string Country = "create table HourMaster (Hour_CODE numeric (18, 0) NOT NULL,Hour_Name varchar (100) NULL,Country_Code numeric (18, 0) NULL,primary key CLUSTERED (Hour_CODE))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

                public bool AccessLocation_OrderDetails_Dtl(SqlConnection con)
        {
            string Country = "create table tbl_Employee_OrderDetails_Dtl (AUTOINCRE int IDENTITY(1,1) NOT NULL,Dtl_id numeric (18, 0) NULL,Order_Name varchar (50) NULL,Order_Date [datetime] NULL,desig_ID varchar (50) NULL,Hour varchar (50) NULL,MonthDays varchar (50) NULL,RATE [money] NULL,primary key CLUSTERED (AUTOINCRE))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

                        public bool AccessLocation_tbl_Employee_OrderDetails(SqlConnection con)
        {
            string Country = "create table tbl_Employee_OrderDetails (Order_ID [numeric](18, 0) IDENTITY(1,1) NOT NULL,Co_Code numeric (18, 0) NULL,Cliant_ID numeric (18, 0) NULL,Order_Name varchar (50) NOT NULL,Order_Date varchar (50) NULL,[FromDate] [varchar](50) NULL,[ToDate] [varchar](50) NULL,[Contract_Person] [varchar](50) NULL,[PnoneNo] [varchar](50) NULL,[Location] [varchar](50) NULL,[ManPower] [varchar](50) NULL,[Order_Remarks] [varchar](max) NULL,[Cliant_OrderNo] [varchar](50) NULL,[Hour_CODE] [numeric](18, 0) NULL,[MONTH_CODE] [numeric](18, 0) NULL,primary key CLUSTERED (Order_Name))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
         public bool AccessLocation_tbl_Employee_CliantMaster(SqlConnection con)
        {
            string Country = "create table tbl_Employee_CliantMaster ([Client_id] [numeric](18, 0) NOT NULL,[Client_Name] [varchar](100) NULL,[Client_ADD1] [varchar](max) NULL,[Client_ADD2] [varchar](max) NULL,[Client_City] [varchar](50) NULL,	[Client_State] [varchar](50) NULL,[Contract_Person] [varchar](100) NULL,[Contract_No] [varchar](50) NULL,primary key CLUSTERED (Client_id))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

                 public bool AccessLocation_Relation_Master(SqlConnection con)
        {
            string Country = "create table Relation_Master ([Relation_Code] [numeric](18, 0) NOT NULL,[Relation_Name] [varchar](50) NULL,[Relation_Remarks] [varchar](50) NULL,primary key CLUSTERED (Relation_Code))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }


                        public bool AccessLocation_Qualification_Master(SqlConnection con)
        {
            string Country = "create table Qualification_Master ([Quali_Code] [numeric](18, 0) NOT NULL,[Quali_Name] [varchar](50) NULL,[Quali_Remarks] [varchar](50) NULL,primary key CLUSTERED (Quali_Code))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AccessLocation_paybillD(SqlConnection con)
        {
            string Country = "create table paybillD ([AUTOINCRE] [int] IDENTITY(1,1) NOT NULL,[Dtl_id] [numeric](18, 0) NULL,[BILLNO] [varchar](50) NULL,[BILLDATE] [datetime] NULL,[desig_ID] [varchar](50) NULL,[Hour] [varchar](50) NULL,[MonthDays] [varchar](50) NULL,[Attendance] [varchar](50) NULL,[BILLAMT] [money] NULL,[RATE] [money] NULL,[Location_ID] [numeric](18, 0) NULL,[ref_order_no] [varchar](100) NULL,[ref_order_date] [datetime] NULL,[Month] [varchar](50) NULL,[Session] [varchar](50) NULL,primary key CLUSTERED (AUTOINCRE))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        

 public bool AccessLocation_paybillO(SqlConnection con)
    {

        string Country = "create table [paybillO]( [AUTOINCRE] [int] IDENTITY(1,1) NOT NULL,[BILLNO] [varchar](50) NULL," +
	"[BILLDATE] [date] NULL,[OID] [int] NULL,[OCHARGES] [nvarchar](150) NULL,[ORate] [numeric](18, 2) NULL,	[OQty] [numeric](18, 2) NULL," +
	"[OAMT] [numeric](18, 2) NULL, CONSTRAINT [PK_paybillO] PRIMARY KEY CLUSTERED (	[AUTOINCRE] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]";
        SqlCommand cmd = new SqlCommand(Country, con);
        try
        {
            cmd.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
        
    }



 public bool AccessLocation_paybillST(SqlConnection con)
 {

     string Country = "create table [paybillST](" +
     "[STID] [int] NOT NULL,[FromDATE] [date] NULL, [Slno] [int] NULL, " +
     "[STNAME] [nvarchar](150) NULL, [STPER] [numeric](18, 2) NULL,[STMonth] [nvarchar](20) NULL)";
     SqlCommand cmd = new SqlCommand(Country, con);
     try
     {
         cmd.ExecuteNonQuery();
         return true;
     }
     catch
     {
         return false;
     }



 }


                public bool AccessLocation_tbl_Employee_Config_Retirement(SqlConnection con)
        {
            string Country = "create table tbl_Employee_Config_Retirement (SlNo [int] IDENTITY(1,1) NOT NULL,[Session] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[Age] [int] NULL CONSTRAINT [DF_tbl_Employee_Config_Retirement_Age]  DEFAULT ((0)),[InsertionDate] [datetime] NULL CONSTRAINT [DF_tbl_Employee_Config_Retirement_InsertionDate]  DEFAULT (getdate()),[PenssionAge] [int] NULL,[PFAge] [int] null,primary key CLUSTERED (SlNo))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Companywiseid_Relation_table_creation(SqlConnection con)
        {
            string Country = "create table Companywiseid_Relation (ID [numeric](18, 0) NOT NULL,[Company_ID] [numeric](18, 0) NULL,[Location_ID] [numeric](18, 0) NULL,[PF_Code] [varchar](50),[Pan_Code] [varchar](50),[StReg_Code] [varchar](50),[M_inst] [varchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Esi_Code] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[Ptax_Code] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,primary key CLUSTERED(ID))";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }




        //public bool inflt_table_creation(SqlConnection con)
        //{
        //    string strinflt = "create table INFLT(stindxdt datetime not null,enindxdt  datetime not null,indxval float not null,";
        //    strinflt = strinflt + "primary key clustered(stindxdt,enindxdt,indxval))";
        //    SqlCommand cmd = new SqlCommand(strinflt, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool cnfgmst_table_creation(SqlConnection con)
        //{
        //    string cnfg = "create table CNFGMST(CNFG_TYPE char(1) not null,CNFG_LEVEL char(1) not null,MENUCODE varchar(12),CNFG_CODE Varchar(50)not null,";
        //    cnfg = cnfg + "CNFG_DESC varchar(50)not null,PARENT_CODE Varchar(50) not null,";
        //    cnfg = cnfg + "SERIAL_NO numeric,ARTICLE_NO varchar(50),DEFAULT_BOOL_VA bit,DEFAULT_VAL_TYPE char(1),";
        //    cnfg = cnfg + "STR_VAL varchar(100),Bool_VAL bit,NUM_VAL numeric,DATE_VAL Datetime,";
        //    cnfg = cnfg + "primary key clustered(CNFG_CODE))";
        //    SqlCommand cmd = new SqlCommand(cnfg, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool cnfgcmp_table_creation(SqlConnection con)
        //{
        //    string cnfg = "create table CNFGCMP(GCODE char(10) not null,CNFG_CODE Varchar(50)not null,PARENT_CODE Varchar(50) not null,";
        //    cnfg = cnfg + "STR_VAL varchar(100),Bool_VAL bit,NUM_VAL numeric,DATE_VAL Datetime,";
        //    cnfg = cnfg + "primary key clustered(GCODE,CNFG_CODE))";
        //    SqlCommand cmd = new SqlCommand(cnfg, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool cnfguser_table_creation(SqlConnection con)
        //{
        //    string cnfg = "create table CNFGUSER(USER_CODE varchar(6) not null,";
        //    cnfg = cnfg + "CNFG_CODE Varchar(50)not null,PARENT_CODE Varchar(50) not null,";
        //    cnfg = cnfg + "STR_VAL varchar(100),Bool_VAL bit,NUM_VAL numeric,DATE_VAL Datetime,";
        //    cnfg = cnfg + "primary key clustered(USER_CODE,CNFG_CODE))";
        //    SqlCommand cmd = new SqlCommand(cnfg, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool cnfgfinanc_table_creation(SqlConnection con)
        //{
        //    string cnfg = "create table CNFGFIYR(FICODE char(10) not null,";
        //    cnfg = cnfg + "CNFG_CODE Varchar(50)not null,PARENT_CODE Varchar(50) not null,";
        //    cnfg = cnfg + "STR_VAL varchar(100),Bool_VAL bit,NUM_VAL numeric,DATE_VAL Datetime,";
        //    cnfg = cnfg + "primary key clustered(FICODE,CNFG_CODE))";
        //    SqlCommand cmd = new SqlCommand(cnfg, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool INSURANCEMST_table_creation(SqlConnection con)
        //{
        //    string cnfg = "create table INSURANCEMST(FICODE char(10) not null,GCODE	char(10) not null,T_ENTRY char(2) not null,PCODE numeric not null,";
        //    cnfg = cnfg + "VOUCHER	numeric not null,CLSS_CODE	numeric not null,USER_VOUCHER varchar(50),AUTO_INCR	int IDENTITY(1,1) not null,POLICY_NO varchar(50),";
        //    cnfg = cnfg + "SUMASSURED money,MOD_PAYMENT varchar(50),PREMIUM_AMT	money,TOT_PRM_AMT money,POLICY_TERM	numeric,TOTPRMAMT_PAID	money,DTOF_COMMENCE	datetime,";
        //    cnfg = cnfg + "MATUARITY_DT	datetime,NOMINEE_ID int, FUND_TYPE numeric,NetAmt money,LockPeriod numeric,";
        //    cnfg = cnfg + "primary key clustered(FICODE,GCODE,T_ENTRY,PCODE,VOUCHER,CLSS_CODE,AUTO_INCR,POLICY_NO))";
        //    SqlCommand cmd = new SqlCommand(cnfg, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool INSURANCECHLD_table_creation(SqlConnection con)
        //{
        //    string cnfg = "create table INSURANCECHLD(FICODE char(10) not null,GCODE	char(10) not null,T_ENTRY char(2) not null,PCODE numeric not null,";
        //    cnfg = cnfg + "VOUCHER	numeric not null,CLSS_CODE	numeric not null,AUTO_INCR	int IDENTITY(1,1) not null,POLICY_NO varchar(50),";
        //    cnfg = cnfg + "PREMIUM_AMT	money,PREMIUM_PAID_DATE	datetime,NXTDUE_DT	datetime,Status varchar(50),LinkVCHR numeric,Fine money,InstallNo numeric,Bonus money,Tot_Bonus money, ";
        //    cnfg = cnfg + "primary key clustered(FICODE,GCODE,T_ENTRY,PCODE,VOUCHER,CLSS_CODE,AUTO_INCR,POLICY_NO))";
        //    SqlCommand cmd = new SqlCommand(cnfg, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool UserFormulaMaster_table_creation(SqlConnection con)
        //{
        //    string cnfg = "create table UserFormulaMaster(FICODE char(10) not null,GCODE char(10) not null,description varchar(50) not null,Dcode numeric not null,";
        //    cnfg = cnfg + "primary key clustered(FICODE,GCODE,Dcode))";
        //    SqlCommand cmd = new SqlCommand(cnfg, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool INSURANCEFUND_table_creation(SqlConnection con)
        //{
        //    string cnfg = "create table INSURANCEFUND(FICODE char(10) not null,GCODE char(10) not null,Fund_Code numeric not null,Fund_Desc varchar(50) not null,Fund_Profile varchar(50),Fund_Type varchar(50),";
        //    cnfg = cnfg + "primary key clustered(FICODE,GCODE,Fund_Code))";
        //    SqlCommand cmd = new SqlCommand(cnfg, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool FixedDepositeMaster_table_creation(SqlConnection con)
        //{
        //    string cnfg = "create table FixedDepositeMaster(FICODE char(10) not null,GCODE	char(10) not null,T_ENTRY char(2) not null,PCODE numeric not null,";
        //    cnfg = cnfg + "VOUCHER	numeric not null,AUTO_INCR	int IDENTITY(1,1) not null,";
        //    cnfg = cnfg + "DPcode numeric,FDRNO	varchar(50),Quantity numeric,Dform	varchar(50),Dto	varchar(50),Location varchar(50),Nominee_ID int,DepositPaybleTo varchar(25),";
        //    cnfg = cnfg + "primary key clustered(FICODE,GCODE,T_ENTRY,PCODE,VOUCHER,AUTO_INCR))";
        //    SqlCommand cmd = new SqlCommand(cnfg, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool InsRiskProfile_table_creation(SqlConnection con)
        //{
        //    string cnfg = "create table InsRiskProfile(FICODE char(10) not null,GCODE char(10) not null,T_ENTRY char(2) not null,PCODE numeric not null,";
        //    cnfg = cnfg + "VOUCHER	numeric not null,AUTO_INCR	int IDENTITY(1,1) not null,";
        //    cnfg = cnfg + "fundcode numeric,SLNo numeric,Allocation numeric(18,2),Investment money,Unitprice float,NumberofUnit float,";
        //    cnfg = cnfg + "primary key clustered(FICODE,GCODE,T_ENTRY,PCODE,VOUCHER,AUTO_INCR))";
        //    SqlCommand cmd = new SqlCommand(cnfg, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool ExpRev_table_creation(SqlConnection con)
        //{
        //    string cnfg = "create table ExpRev(Ficode char(10) NOT NULL,Gcode char(10) NOT NULL , ";
        //    cnfg = cnfg + "Voucher numeric NOT NULL ,AutoIncre numeric IDENTITY (1, 1) NOT NULL ,TranType char(1) NOT NULL , ";
        //    cnfg = cnfg + "Qty numeric ,Rate money,Amt money,AgainstVoucher numeric,AgainstTEntry char(2), ";
        //    cnfg = cnfg + "AgainstAutoIncre numeric ,AgainstPcode numeric,AgainstLineItem numeric,InterLinkVch numeric,InterLinkAutoIncre numeric, ";
        //    cnfg = cnfg + "LockRow bit,InterLinkVoucher numeric,PRIMARY KEY  CLUSTERED(Ficode,Gcode,Voucher,TranType))";
        //    SqlCommand cmd = new SqlCommand(cnfg, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool Unit_table_creation(SqlConnection con)
        //{
        //    string unit = "create table UNIT (FICODE char(10) NOT NULL ,GCODE char(10) NOT NULL ,";
        //    unit = unit + "UCODE numeric NOT NULL ,UDESC varchar(50) NOT NULL,DESM_PLACE	numeric,";
        //    unit = unit + "primary key clustered(FICODE,GCODE,UCODE))";
        //    SqlCommand cmd = new SqlCommand(unit, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool UnitRel_table_creation(SqlConnection con)
        //{
        //    string unitrel = "create table UNITREL (FICODE char(10) NOT NULL ,GCODE char(10) NOT NULL ,";
        //    unitrel = unitrel + "UFCODE numeric NOT NULL ,UTCODE numeric NOT NULL ,CONV_RATE decimal,";
        //    unitrel = unitrel + "primary key clustered(FICODE,GCODE,UCODE))";
        //    SqlCommand cmd = new SqlCommand(unitrel, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool BillAdditional_table_creation(SqlConnection con)
        //{
        //    string striglmst = "create table BillAdditionalDetails(FICode char(10)not null,GCODE char(10) not null,t_entry VARCHAR(10) not null ,voucher int not null  ,autoincre numeric identity(1,1) not null ,transPortName VARCHAR(50),ConsingmentNo VARCHAR(50),ConsingmentDate VARCHAR(50),NoofPackages VARCHAR(30),SRVNO varchar (30),SRVNODate VARCHAR(50),LorryNo VARCHAR(15),Weight numeric(18,4),Delivery_At VARCHAR(50),primary key clustered(FICode,GCODE,t_entry,voucher,autoincre))";
        //    SqlCommand cmd = new SqlCommand(striglmst, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}


        public bool WACCOPTN_table_creation(SqlConnection con)
        {
            string stritran = "create table WACCOPTN (FICode char(10)not null,GCODE char(10) not null,USER_CODE numeric (18,0) NOT NULL,MENU_CODE numeric (18,0) NOT NULL,OPTION_CODE varchar (12) NOT NULL,SeriesNo VARCHAR(30) NOT NULL,OPTION_DESC VARCHAR(70),STR_VAL VARCHAR(MAX),DATE_VAL datetime,BOOL_VAL varchar(30),NUM_VAL numeric (18,0),DFLT_VAL VARCHAR(10),PARENT_CODE numeric (18,0),MEMO_VAL VARCHAR(MAX),primary key clustered (Ficode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo))";
            SqlCommand cmd = new SqlCommand(stritran, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public bool VATGroupMaster_creation(SqlConnection con)
        //{
        //    string VGM = "create table VATGroupMaster (FICODE char(10) NOT NULL ,GCODE char(10) NOT NULL,";
        //    VGM = VGM + "VGM_ID numeric(18,0) NOT NULL,Group_Desc varchar (80) NOT NULL,VAT_Per numeric(18,2) default(0),Active bit,";
        //    VGM = VGM + "EffectiveDate datetime,Comment varchar (80),primary key clustered(FICODE,GCODE,VGM_ID))";
        //    SqlCommand cmd = new SqlCommand(VGM, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool VATItemGroup_creation(SqlConnection con)
        //{
        //    string VGM = "create table VATItemGroup (FICODE char(10) NOT NULL ,GCODE char(10) NOT NULL,VIG_ID numeric(18,0) NOT NULL,";
        //    VGM = VGM + "autoincre numeric identity(1,1) not null,VGM_ID numeric(18,0) NOT NULL,PCODE numeric (18,0) NOT NULL,";
        //    VGM = VGM + "primary key clustered(FICODE,GCODE,VIG_ID,autoincre,VGM_ID,PCODE))";
        //    SqlCommand cmd = new SqlCommand(VGM, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public bool TypeMast_Config_table_creation(SqlConnection con)
        {
            string strtypemst = "create table TypeMast_Config(FICode char(10)not null,GCODE char(10)not null,T_ENTRY char(20) not null,";
            strtypemst = strtypemst + "OPTION_CODE varchar(12)not null, OPTION_DESC varchar(70) not null,STR_VAL varchar(max) null,";
            strtypemst = strtypemst + "DATE_VAL datetime null,BOOL_VAL varchar(30)null,NUM_VAL numeric(18,0)null,DFLT_VAL varchar(50)not null,PARENT_CODE numeric(18,0)null,MEMO_VAL varchar(max)null";
            strtypemst = strtypemst + "primary key clustered(FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,DFLT_VAL))";
            SqlCommand cmd = new SqlCommand(strtypemst, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public bool TypeDoc_Config_table_creation(SqlConnection con)
        //{
        //    string strtypemst = "create table TypeDoc_Config(FICode char(10)not null,GCODE char(10)not null,T_ENTRY char(20) not null,";
        //    strtypemst = strtypemst + "Desccode numeric(18,0)not null,OPTION_CODE varchar(12)not null,STR_VAL varchar(max) null,";
        //    strtypemst = strtypemst + "DATE_VAL datetime null,BOOL_VAL varchar(30)null,NUM_VAL numeric(18,0)null,DFLT_VAL varchar(50)not null,PARENT_CODE numeric(18,0)null,MEMO_VAL varchar(max)null,Script varchar(max)null";
        //    strtypemst = strtypemst + "primary key clustered(FICode,GCODE,T_ENTRY,Desccode,OPTION_CODE,DFLT_VAL))";
        //    SqlCommand cmd = new SqlCommand(strtypemst, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        ////public bool Commodity_table_creation(SqlConnection con)
        ////{
        ////    string cmdty = "create table COMMDITY_INFO (FICODE char(10) NOT NULL ,GCODE char(10) NOT NULL ,";
        ////    cmdty = cmdty + "T_ENTRY char(2),PCODE numeric NOT NULL,VOUCHER numeric NOT NULL,AUTOINCR numeric IDENTITY (1, 1) NOT NULL,";
        ////    cmdty = cmdty + "ORDERNO varchar(50), TRADENO varchar(50),TRADETYPE char(1)NOT NULL,UCODE numeric NOT NULL,";
        ////    cmdty = cmdty + "ITEMNO numeric NOT NULL,ROWINDX numeric NOT NULL,DPCODE numeric,";
        ////    cmdty = cmdty + "primary key clustered(FICODE,GCODE,T_ENTRY,PCODE,VOUCHER,AUTOINCR))";
        ////    SqlCommand cmd = new SqlCommand(cmdty, con);
        ////    try
        ////    {
        ////        cmd.ExecuteNonQuery();
        ////        return true;
        ////    }
        ////    catch
        ////    {
        ////        return false;
        ////    }
        ////}
        ////public bool IGLMST_MASTER_table_creation(SqlConnection con)
        ////{
        ////    string IGLMST_MASTER = "create table IGLMST_MASTER (Prod_Desc varchar(50) not null,Prod_ISNNo varchar(50) not null,Prod_Facevalue float not null,";
        ////    IGLMST_MASTER = IGLMST_MASTER + "primary key clustered(Prod_ISNNo))";
        ////    SqlCommand cmd = new SqlCommand(IGLMST_MASTER, con);
        ////    try
        ////    {
        ////        cmd.ExecuteNonQuery();
        ////        return true;
        ////    }
        ////    catch
        ////    {
        ////        return false;
        ////    }
        ////}

        ////public bool Divident_Schedlr_table_creation(SqlConnection con)
        ////{
        ////    string Divident_Schedlr = "create table [Divident_Schedlr]([Ficode] [char](10) NOT NULL,[Gcode] [char](10) NOT NULL,[User_Vch] [varchar](max) NULL,[Voucher] [numeric](18, 0) NOT NULL," +
        ////        "[T_entry] [char](2) NOT NULL,[Vch_Date] [datetime] NOT NULL,[AutoIncNo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,[Pcode] [numeric](18, 0) NULL,[DPcode] [numeric](18, 0) NULL,[Declare_Date] [datetime] NULL," +
        ////        "[Applicable_Date] [datetime] NULL,[Total_Qty] [decimal](18, 0) NULL,[Declare_Qty] [decimal](18, 0) NULL,[Div_Percent] [numeric](18, 2) NULL,[Div_pers] [numeric](18, 2) NULL,[Amount] [numeric](18, 2) NULL," +
        ////        "[Note] [varchar](50) NULL,[Delv_Status] [varchar](50) NULL,[WarrantNo] [varchar](max) NULL,[WarrantDate] [datetime] NULL,[Options] [varchar](50) NULL,[Link_voucher] [numeric](18, 0) NULL,[Link_tentry] [char](2) NULL," +
        ////        "[Desccode] [numeric](18, 0) NULL,[Financial_Year] [varchar](50) NULL,PRIMARY KEY CLUSTERED ([Ficode] ASC,[Gcode] ASC,[Voucher] ASC,[T_entry] ASC,[Vch_Date] ASC,[AutoIncNo] ASC))";

        ////    SqlCommand cmd = new SqlCommand(Divident_Schedlr, con);
        ////    try
        ////    {
        ////        cmd.ExecuteNonQuery();
        ////        return true;
        ////    }
        ////    catch
        ////    {
        ////        return false;
        ////    }
        ////}

        ////public bool Condat_table_creation(SqlConnection con)
        ////{
        ////    string strmfmst = "create table [ConData]([FICode][char](10) NOT NULL,[GCODE] [char](10) NOT NULL,[T_ENTRY] [char](2) NOT NULL,[Sub_T_ENTRY] [char](2)" +
        ////                      "NOT NULL,[Voucher] [numeric](18, 0) NOT NULL,[Sub_Voucher] [numeric](18, 0) NULL,[AccountStat] [bit] NULL,[TotalAmount] [decimal](18, 0) NULL," +
        ////                      "[User_Vch] [varchar](max) NULL,[Vch_date] [datetime] NULL,[Desccode] [numeric](18, 0) NULL,[Type] [varchar](50)  NULL,PRIMARY KEY CLUSTERED ([FICode] ASC,[GCODE] ASC,[T_ENTRY] ASC,[Voucher] ASC))";
        ////    SqlCommand cmd = new SqlCommand(strmfmst, con);
        ////    try
        ////    {
        ////        cmd.ExecuteNonQuery();
        ////        return true;
        ////    }
        ////    catch
        ////    {
        ////        return false;
        ////    }
        ////}
        ////public bool InsMktRate_table_creation(SqlConnection con)
        ////{
        ////    string strmfmst = "create table [Ins_Mkt_Rate]([Ficode] [char](10) NOT NULL,[Gcode] [char](10) NOT NULL," +
        ////                      "[Autoincre] [numeric](18, 0) IDENTITY(1,1) NOT NULL,[Pcode] [numeric](18, 0) NOT NULL,[EX_Code] [numeric](18, 0) NULL,[EffectiveDate] [datetime] NOT NULL,[OpeningRate] [decimal](18, 0) NULL,[HighestRate] [decimal](18, 0) NULL," +
        ////                      "[LowestRate] [decimal](18, 0) NULL,[ClosingRate] [numeric](18, 0) NULL,[Comments] [varchar](max) NULL,[LastRate] [numeric](18, 0) NULL,[PREVCLOSE] [numeric](18, 0) NULL,[SERIES] [varchar](50) NULL,[PName] [varchar](50) NOT NULL,[EntryDate] [datetime] NOT NULL,[SC_CODE] [varchar](50) NULL,PRIMARY KEY CLUSTERED ([Ficode] ASC,[Gcode] ASC,[Autoincre] ASC)) ";
        ////    SqlCommand cmd = new SqlCommand(strmfmst, con);
        ////    try
        ////    {
        ////        cmd.ExecuteNonQuery();
        ////        return true;
        ////    }
        ////    catch
        ////    {
        ////        return false;
        ////    }
        ////}
        public bool veryfirst(SqlConnection con)
        {

            //Password table creation
            try
            {
                con.Close();
                con.Open();
                if (password_table_creation(con))
                {
                    Authentication_Table(con);
                    CreateSession_Table(con);
                    Company_table_creation(con);
                    Branch_table_creation(con);
                    if (AccordFourlog_table_creation(con) && UserControl_table_creation(con))
                    {
                        con.Close();
                        return true;
                    }
                    else
                    {
                        con.Close();
                        return false;
                    }
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch
            {
                con.Close();
                return false;
            }

        }
         //Initial database creation
        public bool UserControl_table_creation(SqlConnection con)
        {
            string straccss = "create table [UserControl]([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,[UGcode] [char](10) NOT NULL,[SuperUser] [char](10) NOT NULL,[USER_CODE] [char](10) NOT NULL,[USGcode] [char](10) NULL PRIMARY KEY CLUSTERED ([Ficode] ASC,[Gcode] ASC,[UGcode] ASC,[SuperUser] ASC,[USER_CODE] ASC))";
            SqlCommand cmd = new SqlCommand(straccss, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool creatTrigCompStateCode(SqlConnection con)
        {
            string qry ="Delete from StateMaster " +
                "insert into StateMaster values(1,'JAMMU & KASHMIR',NULL) " +
           " insert into StateMaster values(2,'HIMACHAL PRADESH',NULL) " +
           " insert into StateMaster values(3,'PUNJAB',NULL) " +
           " insert into StateMaster values(4,'CHANDIGARH',NULL) " +
           " insert into StateMaster values(5,'UTTRAKHAND',NULL) " +
           " insert into StateMaster values(6,'HARYANA',NULL) " +
           " insert into StateMaster values(7,'DELHI',NULL) " +
           " insert into StateMaster values(8,'RAJASTHAN',NULL) " +
           " insert into StateMaster values(9,'U.P',NULL) " +
           " insert into StateMaster values(10,'BIHAR',NULL) " +
           " insert into StateMaster values(11,'SIKKIM',NULL) " +
           " insert into StateMaster values(12,'ARUNACHAL PRADESH',NULL) " +
           " insert into StateMaster values(13,'NAGALAND',NULL) " +
           " insert into StateMaster values(14,'MANIPUR',NULL) " +
           " insert into StateMaster values(15,'MIZORAM',NULL) " +
           " insert into StateMaster values(16,'TRIPURA',NULL) " +
           " insert into StateMaster values(17,'MEGHALAYA',NULL) " +
           " insert into StateMaster values(18,'ASSAM',NULL) " +
           " insert into StateMaster values(19,'WEST BENGAL',NULL) " +
           " insert into StateMaster values(20,'JHARKHAND',NULL) " +
           " insert into StateMaster values(21,'ORISSA',NULL) " +
           " insert into StateMaster values(22,'CHHATISGARH',NULL) " +
           " insert into StateMaster values(23,'M.P',NULL) " +
           " insert into StateMaster values(24,'GUJARAT',NULL) " +
           " insert into StateMaster values(25,'DAMAN AND DIU',NULL) " +
           " insert into StateMaster values(26,'DADRA AND NAGAR HAVELI',NULL) " +
           " insert into StateMaster values(27,'MAHARASHTRA',NULL) " +
           " insert into StateMaster values(28,'ANDHRA PRADESH',NULL) " +
           " insert into StateMaster values(29,'KARNATAKA',NULL) " +
           " insert into StateMaster values(30,'GOA',NULL) " +
           " insert into StateMaster values(31,'LAKSHDWEEP',NULL) " +
           " insert into StateMaster values(32,'KARELA',NULL) " +
           " insert into StateMaster values(33,'TAMILNADU',NULL) " +
           " insert into StateMaster values(34,'PONDICHERRY',NULL) " +
           " insert into StateMaster values(35,'ANDAMAN AND NICOBAR ISLAND',NULL)";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool creatTrigCompContary(SqlConnection con)
        {
            string qry = "Delete from Country " +
                " insert into Country values(1,'Afghanistan',NULL,NULL) " +
           "insert into Country values(2,'Albania',NULL,NULL) " +
           " insert into Country values(3,'Algeria',NULL,NULL) " +
           " insert into Country values(4,'American Samoa',NULL,NULL) " +
           " insert into Country values(5,'Andorra',NULL,NULL) " +
           " insert into Country values(6,'Angola',NULL,NULL) " +
           " insert into Country values(7,'Anguilla',NULL,NULL) " +
           " insert into Country values(8,'Antigua and Barbuda',NULL,NULL) " +
           " insert into Country values(9,'Argentina',NULL,NULL) " +
           " insert into Country values(10,'Armenia',NULL,NULL) " +
           " insert into Country values(11,'Aruba',NULL,NULL) " +
           " insert into Country values(12,'Australia',NULL,'Australian Dollar') " +
           " insert into Country values(13,'Austria',NULL,NULL) " +
           " insert into Country values(14,'Azerbaijan',NULL,NULL) " +
           " insert into Country values(15,'Bahamas',NULL,NULL) " +
           " insert into Country values(16,'Bahrain',NULL,NULL) " +
           " insert into Country values(17,'Bangladesh',NULL,'Bangladeshi Taka') " +
           " insert into Country values(18,'Barbados',NULL,NULL) " +
           " insert into Country values(19,'Belarus',NULL,NULL) " +
           " insert into Country values(20,'Belgium',NULL,NULL) " +
           " insert into Country values(21,'Belize',NULL,NULL) " +
           " insert into Country values(22,'Benin',NULL,NULL) " +
           " insert into Country values(23,'Bermuda',NULL,NULL) " +
           " insert into Country values(24,'Bhutan',NULL,NULL) " +
           " insert into Country values(25,'Bolivia',NULL,NULL) " +
           " insert into Country values(26,'Bosnia-Herzegovina',NULL,NULL) " +
           " insert into Country values(27,'Botswana',NULL,NULL) " +
           " insert into Country values(28,'Bouvet Island',NULL,NULL) " +
           " insert into Country values(29,'Brazil',NULL,NULL) " +
           " insert into Country values(30,'Brunei',NULL,NULL) " +
           " insert into Country values(31,'Bulgaria',NULL,NULL) " +
           " insert into Country values(32,'Burkina Faso',NULL,NULL) " +
           " insert into Country values(33,'Burundi',NULL,NULL) " +
           " insert into Country values(34,'Cambodia',NULL,NULL) " +
           " insert into Country values(35,'Cameroon',NULL,NULL) " +
            " insert into Country values(36,'Canada',NULL,NULL) " +
            " insert into Country values(37,'Cape Verde',NULL,NULL) " +
            " insert into Country values(38,'Cayman Islands',NULL,NULL) " +
            " insert into Country values(39,'Central African Republic',NULL,NULL)" +
            " insert into Country values(40,'Chad',NULL,NULL) " +
          " insert into Country values(41,'Chile',NULL,NULL) " +
           " insert into Country values(42,'China',NULL,NULL) " +
          " insert into Country values(43,'Christmas Island',NULL,NULL) " +
            " insert into Country values(44,'Cocos (Keeling) Islands',NULL,NULL) " +
          " insert into Country values(45,'Colombia',NULL,NULL) " +
            " insert into Country values(46,'Comoros',NULL,NULL) " +
          " insert into Country values(47,'Congo, Democratic Republic of the (Zaire)',NULL,NULL) " +
            " insert into Country values(48,'Congo, Republic of',NULL,NULL) " +
          " insert into Country values(49,'Cook Islands',NULL,NULL) " +
            " insert into Country values(50,'Costa Rica',NULL,NULL) " +
          " insert into Country values(51,'Croatia',NULL,NULL) " +
            " insert into Country values(52,'Cuba',NULL,NULL) " +
          " insert into Country values(53,'Cyprus',NULL,NULL) " +
            " insert into Country values(54,'Czech Republic',NULL,NULL) " +
          " insert into Country values(55,'Denmark',NULL,NULL)" +
          " insert into Country values(56,'Djibouti',NULL,NULL) " +
          " insert into Country values(57,'Dominica',NULL,NULL)" +
          " insert into Country values(58,'Dominican Republic',NULL,NULL) " +
          " insert into Country values(59,'Ecuador',NULL,NULL) " +
            " insert into Country values(60,'Egypt',NULL,NULL) " +
          " insert into Country values(61,'El Salvador',NULL,NULL) " +
            " insert into Country values(62,'Equatorial Guinea',NULL,NULL) " +
           " insert into Country values(63,'Eritrea',NULL,NULL) " +
           " insert into Country values(64,'Estonia',NULL,NULL) " +
           " insert into Country values(65,'Ethiopia',NULL,NULL) " +
           " insert into Country values(66,'Fiji',NULL,NULL) " +
           " insert into Country values(67,'Finland',NULL,NULL) " +
           " insert into Country values(68,'France',NULL,NULL) " +
           " insert into Country values(69,'French Guiana',NULL,NULL) " +
           " insert into Country values(70,'Gabon',NULL,NULL) " +
           " insert into Country values(71,'Gambia',NULL,NULL) " +
           " insert into Country values(72,'Georgia',NULL,NULL) " +
           " insert into Country values(73,'Germany',NULL,NULL) " +
           " insert into Country values(74,'Ghana',NULL,NULL) " +
           " insert into Country values(75,'Gibraltar',NULL,NULL) " +
           " insert into Country values(76,'Greece',NULL,NULL) " +
           " insert into Country values(77,'Greenland',NULL,NULL) " +
           " insert into Country values(78,'Grenada',NULL,NULL) " +
           " insert into Country values(79,'Guadeloupe (French)',NULL,NULL) " +
           " insert into Country values(80,'Guam (USA)',NULL,NULL) " +
           " insert into Country values(81,'Guatemala',NULL,NULL) " +
           " insert into Country values(82,'Guinea',NULL,NULL) " +
           " insert into Country values(83,'Guinea Bissau',NULL,NULL) " +
           " insert into Country values(84,'Guyana',NULL,NULL) " +
           " insert into Country values(85,'Haiti',NULL,NULL) " +
           " insert into Country values(86,'Holy See',NULL,NULL) " +
           " insert into Country values(87,'Honduras',NULL,NULL) " +
           " insert into Country values(88,'Hong Kong',NULL,NULL) " +
           " insert into Country values(89,'Hungary',NULL,NULL) " +
           " insert into Country values(90,'Iceland',NULL,NULL) " +
           " insert into Country values(91,'India',NULL,'Indian Rupee') " +
           " insert into Country values(92,'Indonesia',NULL,NULL) " +
           " insert into Country values(93,'Iran',NULL,NULL) " +
           " insert into Country values(94,'Iraq',NULL,NULL) " +
           " insert into Country values(95,'Ireland',NULL,NULL) " +
           " insert into Country values(96,'Israel',NULL,NULL) " +
           " insert into Country values(97,'Italy',NULL,NULL) " +
           " insert into Country values(98,'Ivory Coast (Cote D`Ivoire)',NULL,NULL) " +
           " insert into Country values(99,'Jamaica',NULL,NULL) " +
           " insert into Country values(100,'Japan',NULL,NULL) " +
           " insert into Country values(101,'Jordan',NULL,NULL) " +
           " insert into Country values(102,'Kazakhstan',NULL,NULL) " +
           " insert into Country values(103,'Kenya',NULL,'Kenyan Shillings') " +
           " insert into Country values(104,'Kiribati',NULL,NULL) " +
           " insert into Country values(105,'Kuwait',NULL,'Kuwait Dinar') " +
           " insert into Country values(106,'Kyrgyzstan',NULL,NULL) " +
            " insert into Country values(107,'Laos',NULL,NULL) " +
           " insert into Country values(108,'Latvia',NULL,NULL) " +
            " insert into Country values(109,'Lebanon',NULL,NULL) " +
           " insert into Country values(110,'Lesotho',NULL,NULL) " +
            " insert into Country values(111,'Liberia',NULL,NULL) " +
           " insert into Country values(112,'Libya',NULL,NULL) " +
            " insert into Country values(113,'Liechtenstein',NULL,NULL) " +
           " insert into Country values(114,'Lithuania',NULL,NULL) " +
            " insert into Country values(115,'Luxembourg',NULL,NULL) " +
           " insert into Country values(116,'Macau',NULL,NULL) " +
            " insert into Country values(117,'Macedonia',NULL,NULL) " +
           " insert into Country values(118,'Madagascar',NULL,NULL) " +
            " insert into Country values(119,'Malawi',NULL,NULL) " +
           " insert into Country values(120,'Malaysia',NULL,NULL) " +
            " insert into Country values(121,'Maldives',NULL,NULL) " +
           " insert into Country values(122,'Mali',NULL,NULL) " +
           " insert into Country values(123,'Malta',NULL,NULL) " +
            " insert into Country values(124,'Marshall Islands',NULL,NULL) " +
           " insert into Country values(125,'Martinique (French)',NULL,NULL) " +
            " insert into Country values(126,'Mauritania',NULL,NULL) " +
           " insert into Country values(127,'Mauritius',NULL,NULL) " +
            " insert into Country values(128,'Mayotte',NULL,NULL) " +
           " insert into Country values(129,'Mexico',NULL,NULL) " +
             " insert into Country values(130,'Micronesia',NULL,NULL) " +
            " insert into Country values(131,'Moldova',NULL,NULL) " +
           " insert into Country values(132,'Monaco',NULL,NULL) " +
            " insert into Country values(133,'Mongolia',NULL,NULL) " +
           " insert into Country values(134,'Montenegro',NULL,NULL) " +
            " insert into Country values(135,'Montserrat',NULL,NULL) " +
           " insert into Country values(136,'Morocco',NULL,NULL) " +
            " insert into Country values(137,'Mozambique',NULL,NULL) " +
           " insert into Country values(138,'Myanmar',NULL,NULL) " +
           " insert into Country values(139,'Namibia',NULL,NULL) " +
           " insert into Country values(140,'Nauru',NULL,NULL) " +
           " insert into Country values(141,'Nepal',NULL,'Nepali Rupee') " +
           " insert into Country values(142,'Netherlands',NULL,NULL) " +
           " insert into Country values(143,'Netherlands Antilles',NULL,NULL) " +
           " insert into Country values(144,'New Caledonia (French)',NULL,NULL) " +
           " insert into Country values(145,'New Zealand',NULL,NULL) " +
           " insert into Country values(146,'Nicaragua',NULL,NULL) " +
           " insert into Country values(147,'Niger',NULL,NULL) " +
           " insert into Country values(148,'Nigeria',NULL,'NGN') " +
           " insert into Country values(149,'Niue',NULL,NULL) " +
           " insert into Country values(150,'Norfolk Island',NULL,NULL) " +
           " insert into Country values(151,'North Korea',NULL,NULL) " +
           " insert into Country values(152,'Northern Mariana' ,NULL,NULL) " +
           " insert into Country values(153,'Norway',NULL,NULL) " +
           " insert into Country values(154,'Oman',NULL,'Omani Riyal') " +
           " insert into Country values(155,'Pakistan',NULL,NULL) " +
           " insert into Country values(156,'Palau',NULL,NULL) " +
           " insert into Country values(157,'Panama',NULL,NULL) " +
           " insert into Country values(158,'Papua New Guinea',NULL,NULL) " +
           " insert into Country values(159,'Paraguay',NULL,NULL) " +
           " insert into Country values(160,'Peru',NULL,NULL) " +
           " insert into Country values(161,'Philippines',NULL,NULL) " +
           " insert into Country values(162,'Pitcairn Island',NULL,NULL) " +
           " insert into Country values(163,'Poland',NULL,NULL) " +
           " insert into Country values(164,'Polynesia (French)',NULL,NULL) " +
           " insert into Country values(165,'Portugal',NULL,NULL) " +
           " insert into Country values(166,'Puerto Rico',NULL,NULL) " +
           " insert into Country values(167,'Qatar',NULL,'Qatar Riyal') " +
           " insert into Country values(168,'Reunion',NULL,NULL) " +
           " insert into Country values(169,'Romania',NULL,NULL) " +
           " insert into Country values(170,'Russia',NULL,NULL) " +
           " insert into Country values(171,'Rwanda',NULL,NULL) " +
           " insert into Country values(172,'Saint Helena',NULL,NULL) " +
           " insert into Country values(173,'Saint Kitts and Nevis',NULL,NULL) " +
           " insert into Country values(174,'Saint Lucia',NULL,NULL) " +
           " insert into Country values(175,'Saint Pierre and Miquelon',NULL,NULL) " +
           " insert into Country values(176,'Saint Vincent and Grenadines',NULL,NULL) " +
           " insert into Country values(177,'Samoa',NULL,NULL) " +
           " insert into Country values(178,'San Marino',NULL,NULL) " +
           " insert into Country values(179,'Sao Tome and Principe',NULL,NULL) " +
           " insert into Country values(180,'Saudi Arabia',NULL,NULL) " +
           " insert into Country values(181,'Senegal',NULL,NULL) " +
           " insert into Country values(182,'Serbia',NULL,NULL) " +
           " insert into Country values(183,'Seychelles',NULL,NULL) " +
           " insert into Country values(184,'Sierra Leone',NULL,NULL) " +
           " insert into Country values(185,'Singapore',NULL,'Singapore Dollar') " +
           " insert into Country values(186,'Slovakia',NULL,NULL) " +
           " insert into Country values(187,'Slovenia' ,NULL,NULL) " +
           " insert into Country values(188,'Solomon Islands',NULL,NULL) " +
           " insert into Country values(189,'Somalia',NULL,NULL) " +
           " insert into Country values(190,'South Africa',NULL,NULL) " +
           " insert into Country values(191,'South Georgia and South Sandwich Islands',NULL,NULL) " +
           " insert into Country values(192,'South Korea',NULL,NULL) " +
           " insert into Country values(193,'Spain',NULL,NULL) " +
           " insert into Country values(194,'Sri Lanka',NULL,NULL) " +
           " insert into Country values(195,'Sudan',NULL,NULL) " +
           " insert into Country values(196,'Suriname',NULL,NULL) " +
           " insert into Country values(197,'Svalbard and Jan Mayen Islands',NULL,NULL) " +
           " insert into Country values(198,'Swaziland',NULL,NULL) " +
           " insert into Country values(199,'Sweden',NULL,NULL) " +
           " insert into Country values(200,'Switzerland',NULL,NULL) " +
           " insert into Country values(201,'Syria',NULL,NULL) " +
           " insert into Country values(202,'Taiwan',NULL,NULL) " +
           " insert into Country values(203,'Tajikistan',NULL,NULL) " +
           " insert into Country values(204,'Tanzania',NULL,'Tanzanian Shilling') " +
           " insert into Country values(205,'Thailand',NULL,NULL) " +
           " insert into Country values(206,'Timor-Leste (East Timor)',NULL,NULL) " +
           " insert into Country values(207,'Togo',NULL,NULL) " +
           " insert into Country values(208,'Tokelau',NULL,NULL) " +
           " insert into Country values(209,'Tonga',NULL,NULL) " +
           " insert into Country values(210,'Trinidad and Tobago',NULL,NULL) " +
           " insert into Country values(211,'Tunisia',NULL,NULL) " +
           " insert into Country values(212,'Turkey',NULL,NULL) " +
           " insert into Country values(213,'Turkmenistan',NULL,NULL) " +
           " insert into Country values(214,'Turks and Caicos Islands',NULL,NULL) " +
           " insert into Country values(215,'Tuvalu',NULL,NULL) " +
           " insert into Country values(216,'Uganda',NULL,'Ugandan Shilling') " +
           " insert into Country values(217,'Ukraine',NULL,NULL) " +
           " insert into Country values(218,'United Arab Emirates',NULL,'UAE Dirham') " +
           " insert into Country values(219,'United Kingdom',NULL,'Pound Sterling') " +
           " insert into Country values(220,'United States',NULL,'US Dollar') " +
           " insert into Country values(221,'Uruguay',NULL,NULL) " +
           " insert into Country values(222,'Uzbekistan',NULL,NULL) " +
           " insert into Country values(223,'Vanuatu',NULL,NULL) " +
           " insert into Country values(224,'Venezuela',NULL,NULL) " +
           " insert into Country values(225,'Vietnam',NULL,NULL) " +
           " insert into Country values(226,'Virgin',NULL,NULL) " +
           " insert into Country values(227,'Wallis and Futuna Islands',NULL,NULL) " +
           " insert into Country values(228,'Yemen',NULL,NULL) " +
           " insert into Country values(229,'Zambia',NULL,NULL) " +
           " insert into Country values(230,'Zimbabwe',NULL,'Zimbabwean Dollar') ";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //for demo insert
        //added by bibhas
        public bool creatTrigClient(SqlConnection con)
        {
            string qry = "Delete from [tbl_Employee_CliantMaster] " + 
 "INSERT into [tbl_Employee_CliantMaster]([Client_id],[Client_Name],[Client_ADD1],[Client_ADD2],[Client_City],[Client_State],[Contract_Person],[Contract_No]) VALUES " + 
 "(CAST(1 AS Numeric(18, 0)), N'ICICI BANK', N'GARIA', N'', N'KOLKATA', N'19', N'', N'')";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool creatTrigLocSite(SqlConnection con)
        {
            string qry = "Delete from [tbl_Emp_Location] " + 
"INSERT into [tbl_Emp_Location] ([Location_ID], [Location_Name], [Cliant_ID]) VALUES (CAST(1 AS Numeric(18, 0)), N'Park Street', CAST(1 AS Numeric(18, 0)))"+
"INSERT into [tbl_Emp_Location] ([Location_ID], [Location_Name], [Cliant_ID]) VALUES (CAST(2 AS Numeric(18, 0)), N'Howrah', CAST(1 AS Numeric(18, 0)))";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool createTrigJobTypeMst(SqlConnection con)
        {
            string qry = "SET IDENTITY_INSERT [tbl_Employee_JobType] ON " + 
            " Delete from tbl_Employee_JobType " +
  "INSERT into [tbl_Employee_JobType] ([SlNo], [JobType], [ShortForm], [InsertionDate]) VALUES (1, N'FULL TIME', N'FT', CAST(0x0000A59500A53A0F AS DateTime))" +
  "INSERT into [tbl_Employee_JobType] ([SlNo], [JobType], [ShortForm], [InsertionDate]) VALUES (2, N'PART TIME', N'PT', CAST(0x0000A59500A53A13 AS DateTime))" +
           " SET IDENTITY_INSERT [tbl_Employee_JobType] OFF";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool creatTrigDesgnation(SqlConnection con)
        {
            string qry ="SET IDENTITY_INSERT [tbl_Employee_DesignationMaster] ON " + 
         " Delete from tbl_Employee_DesignationMaster " +      
         "INSERT into [tbl_Employee_DesignationMaster]" + 
         "([SlNo],[DesignationName],[ShortForm],[InsertionDate]) VALUES " + 
         "(1, N'SECURITY GUARD', N'SG', CAST(0x0000A59500A55CF5 AS DateTime))" +
         "INSERT into [tbl_Employee_DesignationMaster]" +
         "([SlNo],[DesignationName],[ShortForm],[InsertionDate]) VALUES " +
         "(2, N'GUNMAN', N'GM', CAST(0x0000A59500A55CF5 AS DateTime))" +
         " SET IDENTITY_INSERT [tbl_Employee_DesignationMaster] OFF";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool creatTrigQualification(SqlConnection con)
        {
            string qry = "delete from Qualification_Master " +
                "INSERT into [Qualification_Master] ([Quali_Code], [Quali_Name], [Quali_Remarks]) VALUES (CAST(0 AS Numeric(18, 0)), N'-', NULL)" +
"INSERT into [Qualification_Master] ([Quali_Code], [Quali_Name], [Quali_Remarks]) VALUES (CAST(1 AS Numeric(18, 0)), N'8th Pass', NULL)" +
"INSERT into [Qualification_Master] ([Quali_Code], [Quali_Name], [Quali_Remarks]) VALUES (CAST(2 AS Numeric(18, 0)), N'MADHYAMIK', NULL)" +
"INSERT into [Qualification_Master] ([Quali_Code], [Quali_Name], [Quali_Remarks]) VALUES (CAST(3 AS Numeric(18, 0)), N'HIGHER SECONDARY', NULL)";
            
            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool creatTrigRelation(SqlConnection con)
        {
            string qry = "Delete from Relation_Master " +
"INSERT into [Relation_Master] ([Relation_Code], [Relation_Name], [Relation_Remarks]) VALUES (CAST(1 AS Numeric(18, 0)), N'FATHER', NULL)" +
"INSERT [Relation_Master] ([Relation_Code], [Relation_Name], [Relation_Remarks]) VALUES (CAST(2 AS Numeric(18, 0)), N'BROTHER', NULL)" +
"INSERT [Relation_Master] ([Relation_Code], [Relation_Name], [Relation_Remarks]) VALUES (CAST(3 AS Numeric(18, 0)), N'MOTHER', NULL)" +
"INSERT [Relation_Master] ([Relation_Code], [Relation_Name], [Relation_Remarks]) VALUES (CAST(4 AS Numeric(18, 0)), N'SISTER', NULL)";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool creatTrigSalHead(SqlConnection con)
        {
            string qry =" SET IDENTITY_INSERT [tbl_Employee_ErnSalaryHead] ON " + 
" Delete from tbl_Employee_ErnSalaryHead " +             
"INSERT into [tbl_Employee_ErnSalaryHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (1, N'BASIC', N'BS', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500A94F1D AS DateTime))" +
" INSERT into [tbl_Employee_ErnSalaryHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (2, N'OVERTIME ALLOWANCE', N'OTA', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500A94F1D AS DateTime))" +
" INSERT into [tbl_Employee_ErnSalaryHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (3, N'OTHER ALLOWANCE', N'OA', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500A94F1D AS DateTime))" +
" INSERT into [tbl_Employee_ErnSalaryHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (4, N'HOUSE RENT ALLOWANCE', N'HRA', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500A94F1D AS DateTime))" +
" INSERT into [tbl_Employee_ErnSalaryHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (5, N'CONVEYANCE ALLOWANCE', N'COV', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500A94F1D AS DateTime))" +
" INSERT into [tbl_Employee_ErnSalaryHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (6, N'WASHING ALLOWANCE', N'WA', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500A94F1D AS DateTime))" +
" INSERT into [tbl_Employee_ErnSalaryHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (7, N'EDUCATION ALLOWANCE', N'EDU', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500A94F1D AS DateTime))" +
" INSERT into [tbl_Employee_ErnSalaryHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (8, N'BONUS', N'BON', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500A94F1D AS DateTime))" +
" INSERT into [tbl_Employee_ErnSalaryHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (9, N'SPECIAL ALLOWANCE', N'SPA', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500A94F1D AS DateTime))" +
" INSERT into [tbl_Employee_ErnSalaryHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (10, N'DEARNESS ALLOWANCE', N'DA', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500A94F1D AS DateTime))" +

" SET IDENTITY_INSERT [tbl_Employee_ErnSalaryHead] OFF " + 
" SET IDENTITY_INSERT [tbl_Employee_DeductionSalayHead] ON " +

" INSERT into [tbl_Employee_DeductionSalayHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (1, N'PROVIDENT FUND', N'PF', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500AA2517 AS DateTime))" +
" INSERT into [tbl_Employee_DeductionSalayHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (2, N'EMPLOYEE STATE INSURANCE', N'ESI', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500AA2517 AS DateTime))" +
" INSERT into [tbl_Employee_DeductionSalayHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (3, N'LOAN', N'LOAN', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500AA2517 AS DateTime))" +
" INSERT into [tbl_Employee_DeductionSalayHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (4, N'PROFESSIONAL TAX', N'PTAX', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500AA2517 AS DateTime))" +
" INSERT into [tbl_Employee_DeductionSalayHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (5, N'TAX DEDUCTED AT SOURCE', N'TDS', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500AA2517 AS DateTime))" +
" INSERT into [tbl_Employee_DeductionSalayHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (6, N'ADVANCE', N'ADV', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500AA2517 AS DateTime))" +
" INSERT into [tbl_Employee_DeductionSalayHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (7, N'UNIFORM', N'KIT', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500AA2517 AS DateTime))" +
" INSERT into [tbl_Employee_DeductionSalayHead] ([SlNo], [SalaryHead_Full], [SalaryHead_Short], [Amount], [InsertionDate]) VALUES (8, N'Labour Welfare Fund', N'LWF', CAST(0.00 AS Numeric(18, 2)), CAST(0x0000A59500AA2517 AS DateTime))" +

" SET IDENTITY_INSERT [tbl_Employee_DeductionSalayHead] OFF " +

" SET IDENTITY_INSERT [tbl_Employee_Contribution] ON " +

"insert into tbl_Employer_Contribution(SalaryHead_Full,SalaryHead_Short,Amount,Glcode,InsertionDate) values(N'A/C No. 02 - (%)',N'A/C No. 02 - (%)',0.50,0, CAST(0x0000A59500AA2517 AS DateTime))" +
"insert into tbl_Employer_Contribution(SalaryHead_Full,SalaryHead_Short,Amount,Glcode,InsertionDate) values(N'A/C No. 21 - (%)',N'A/C No. 21 - (%)',0.50,0, CAST(0x0000A59500AA2517 AS DateTime))" +
"insert into tbl_Employer_Contribution(SalaryHead_Full,SalaryHead_Short,Amount,Glcode,InsertionDate) values(N'A/C No. 22 - (%)',N'A/C No. 22 - (%)',0.00,0, CAST(0x0000A59500AA2517 AS DateTime))" +
//"insert into tbl_Employer_Contribution_Esi ([SalaryHead_Full],[SalaryHead_Short],[Amount],[InsertionDate],[Glcode]) VALUES('Esi Contribution','EsiContribution','3.75','01/July/2019',0)"+

            " SET IDENTITY_INSERT [tbl_Employee_Contribution] OFF ";
            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool creatTrigSalStuc(SqlConnection con)
        {
            string qry = " SET IDENTITY_INSERT [tbl_Employee_SalaryStructure] ON " +
" Delete from tbl_Employee_SalaryStructure " +                
"INSERT into [tbl_Employee_SalaryStructure] ([SlNo], [SalaryCategory], [InsertionDate]) VALUES (1, N'ICICI Bank', CAST(0x0000A59500A7C318 AS DateTime))" + 
       " SET IDENTITY_INSERT [tbl_Employee_SalaryStructure] OFF ";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool creatTrigLeaveHead(SqlConnection con)
        {
            string qry = " SET IDENTITY_INSERT [tbl_Employee_Config_LeaveDetails] ON " + 
                "Delete from tbl_Employee_Config_LeaveDetails " +
                "INSERT into [tbl_Employee_Config_LeaveDetails] ([LeaveId], [LeaveHead], [ShortName], [TotalLeaves], [DayCount], [Session], [PayType], [LeaveFwd], [InsertionDate]) VALUES (1, N'Absent', N'Ab', CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), N'2015-2016', N'', N'Nothing', CAST(0x0000806800000000 AS DateTime))" +
"INSERT into [tbl_Employee_Config_LeaveDetails] ([LeaveId], [LeaveHead], [ShortName], [TotalLeaves], [DayCount], [Session], [PayType], [LeaveFwd], [InsertionDate]) VALUES (2, N'CASUAL LEAVE', N'CL', CAST(10 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), N'2015-2016', N'', N'', CAST(0x0000A59500A87017 AS DateTime))" +
"INSERT into [tbl_Employee_Config_LeaveDetails] ([LeaveId], [LeaveHead], [ShortName], [TotalLeaves], [DayCount], [Session], [PayType], [LeaveFwd], [InsertionDate]) VALUES (3, N'SICK LEAVE', N'SL', CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), N'2015-2016', N'', N'', CAST(0x0000A59500A87017 AS DateTime))" + 
" SET IDENTITY_INSERT [tbl_Employee_Config_LeaveDetails] OFF ";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool creatTrigSalCal(SqlConnection con)
        {//"Delete from tbl_Employee_Sal_Structure_Formula " +     
            string qry =  "if (select COUNT(*) from tbl_Employee_Sal_Structure_Formula)=0 "+ Environment.NewLine+
                          "begin" + Environment.NewLine +
                "INSERT into [tbl_Employee_Sal_Structure_Formula] ([FID], [FName], [FExp]) VALUES (CAST(1 AS Numeric(18, 0)), N'PFX', N'S001*12/100')" + Environment.NewLine +
                "INSERT into [tbl_Employee_Sal_Structure_Formula] ([FID], [FName], [FExp]) VALUES (CAST(2 AS Numeric(18, 0)), N'ESIX', N'S001+S002*1.75/100')" + Environment.NewLine +
                          "End";
            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Added by dwipraj dutta 20092017
        public bool creatTrigSACMaster(SqlConnection con)
        {
            string qry = "Delete from [CompanySACMaster] " +
 "INSERT into [CompanySACMaster]([slno],[serviceName],[sacNo]) VALUES " +
 "(1, N'HOUSEKEEPING', N'998533'),"+
 "(2, N'SECURITY GUARD', N'998525')," +
 "(3, N'Other Employment', N'998519')";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool creatTrigPtaxSlab(SqlConnection con)
        {
            string qry = "create table [tbl_employee_advance]( " +
	"[aid] [numeric](18, 0) NULL," +
	"[EmpID] [varchar](50) NULL," +
	"[advDate] [date] NULL," +
	"[Session] [varchar](50) NULL," +
	"[month] [varchar](50) NULL," +
	"[AdvAmount] [numeric](18, 2) NULL," +
	"[DeductAmount] [numeric](18, 2) NULL," +
	"[Location_id] [int] NULL," +
	"[Company_id] [int] NULL" +
    ")";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool tbl_Emp_Adv_creation(SqlConnection con)
        {
            string qry = "create table [tbl_employee_advance]( " +
    "[aid] [numeric](18, 0) NULL, " +
    "[EmpID] [varchar](50) NULL, " +
    "[advDate] [date] NULL, " +
    "[Session] [varchar](50) NULL, " +
    "[month] [varchar](50) NULL, " +
    "[AdvAmount] [numeric](18, 2) NULL, " +
    "[DeductAmount] [numeric](18, 2) NULL, " +
    "[Location_id] [int] NULL, " +
    "[Company_id] [int] NULL " +
    ")";
            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=================xxx end demo input xxx================================================================================================

        public bool firsttimeData(SqlConnection con)
        {
            try
            {
                
                Access_table_creation(con);
                AccessBranch_table_creation(con);
                AccordFour_dbinfo_table_creation(con);
                AccPost_table_creation(con);
                adles_table_creation(con);
                alloc_table_creation(con);
                Autogen_table_creation(con);
                bill_table_creation(con);
                BillTerms_table_creation(con);
                Branch_table_creation(con);
                btchtran_table_creation(con);
                ccmast_table_creation(con);
                Company_table_creation(con);
                WACCOPTN_table_creation(con);
                CSTOCK_table_creation(con);
                currency_table_creation(con);
                data_table_creation(con);
                DOCGEN_table_creation(con);
                docnumber_table_creation(con);
                DummyWacclog_table_creation(con);
                FICODEGEN_table_creation(con);
                glmst_table_creation(con);
                grp_table_creation(con);
                IALIAS_table_creation(con);
                
                iglmst_table_creation(con);
                igroup_table_creation(con);
                inarr_table_creation(con);
                Inportant_Note_table_creation(con);
                invtype_Note_table_creation(con);
                ITEMADDDET_Note_table_creation(con);
                itran_table_creation(con);
                lib_AlmirahDetails_Note_table_creation(con);
                lib_Book_Binding_table_creation(con);
                lib_Book_Recomendation_table_creation(con);
                lib_BookInfo_table_creation(con);
                lib_BookIssue_table_creation(con);
                lib_BookReservation_table_creation(con);
                lib_CATG_table_creation(con);
                lib_Deleted_Book_Record_table_creation(con);
                lib_Deleted_Fld_Record_table_creation(con);
                lib_Deleted_Member_Record_table_creation(con);
                lib_FeesConfiguration_table_creation(con);
                lib_Fine_Record_table_creation(con);
                lib_FineBalance_table_creation(con);
                lib_Issue_table_creation(con);
                lib_Magazine_Subscription_table_creation(con);
                lib_Member_table_creation(con);
                lib_Member_Regn_Canceled_table_creation(con);
                lib_Prod_issue_count_table_creation(con);
                lib_Product_Bill_table_creation(con);
                lib_Product_Status_table_creation(con);
                lib_Receipt_table_creation(con);
                lib_RecordMaster_table_creation(con);
                MenuTable_table_creation(con);
                MenuUser_table_creation(con);
                Midaslog_table_creation(con);
                MonthlyFee_Details_table_creation(con);
                narr_table_creation(con);
                prtyms_table_creation(con);
                Session2_table_creation(con);
                TaxDetail_table_creation(con);
                TaxMaster_table_creation(con);
                tbl_AdditionalFeeHeads_table_creation(con);
                tbl_AdditionalSubject_Result_table_creation(con);
                tbl_AdditionalSubjectAllocation_table_creation(con);
                tbl_Admission_ParentDetails_table_creation(con);
                tbl_Admission_StudentDetails_table_creation(con);
                tbl_BusMaster_table_creation(con);
                tbl_BusRouteMaster_table_creation(con);
                tbl_CashReceipt_table_creation(con);
                tbl_caste_table_creation(con);
                tbl_CautionMoney_table_creation(con);
                tbl_ClassSubject_table_creation(con);
                tbl_ClassTerm_table_creation(con);
                tbl_Config_AdditionalSubject_table_creation(con);
                tbl_Config_AddlExam_table_creation(con);
                tbl_Config_BestOfThree_table_creation(con);
                tbl_Config_Class_table_creation(con);
                tbl_Config_Exam_table_creation(con);
                tbl_Config_FeeApp_table_creation(con);
                tbl_Config_FeeEx_table_creation(con);
                tbl_Config_Fees_table_creation(con);
                tbl_Config_FeesDetails_table_creation(con);
                tbl_Config_Grade_table_creation(con);
                tbl_Config_HouseCategory_table_creation(con);
                tbl_Config_Promotion_table_creation(con);
                tbl_Config_SeeApp_table_creation(con);
                tbl_Convert_table_creation(con);
                tbl_Emp_table_creation(con);
                tbl_Employee_AddErnDeducDetails_table_creation(con);
                tbl_Employee_AddErnDeducHead_table_creation(con);
                tbl_Employee_Assign_SalStructure_table_creation(con);
                tbl_Employee_Attendance_table_creation(con);
                tbl_Emp_Attend(con);
                tbl_Employee_Config_ArrearDet_table_creation(con);
                tbl_Employee_Config_ArrearMast_table_creation(con);
                tbl_Employee_Config_Exgratia_table_creation(con);
                tbl_Employee_Config_LeaveDetails_table_creation(con);

                //tbl_Employee_Config_LeaveDetails_insert(con);


                tbl_Employee_Config_PFHeads_table_creation(con);
                tbl_Employee_Config_Retirement_table_creation(con);
                tbl_Employee_DeductionSalayHead_table_creation(con);
                tbl_Employee_DeletedEmp_table_creation(con);
                tbl_Employee_DesignationMaster_table_creation(con);
                tbl_Employee_ErnSalaryHead_table_creation(con);
                tbl_Employee_ExgratiaGiven_table_creation(con);
                tbl_Employee_FamilyDetails_table_creation(con);
                tbl_Employee_Holiday_table_creation(con);
                tbl_Employee_IncrementDetails_table_creation(con);
                tbl_Employee_JobType_table_creation(con);
                tbl_Employee_Leave_Stat_table_creation(con);
                tbl_Employee_LeaveEncashment_Det_table_creation(con);
                tbl_Employee_LeaveEncashment_Mast_table_creation(con);
                tbl_Employee_Lumpsum_table_creation(con);
                tbl_Employee_Mast_table_creation(con);
                tbl_Employee_Other_Det_table_creation(con);
                tbl_Employee_Other_Mast_table_creation(con);
                tbl_Employee_Pay_Details_table_creation(con);
                tbl_Employee_Pay_SetUp_table_creation(con);
                tbl_Employee_PF_table_creation(con);
                tbl_Employee_PF_Loan_table_creation(con);
                tbl_Employee_PFESIRate_table_creation(con);
                tbl_Employee_ProvidentFund_table_creation(con);
                tbl_Employee_PTRate_table_creation(con);
                tbl_Employee_QualificationDetails_table_creation(con);
                tbl_Employee_Sal_Structure_Formula_table_creation(con);
                tbl_Employee_SalaryDet_table_creation(con);
                Emp_Sal_Ocharge(con);
                Emp_Sal_ODet(con);
                tbl_Employee_SalaryMast_table_creation(con);
                tbl_Employee_SalaryStructure_table_creation(con);
                tbl_Employee_SectionMaster_table_creation(con);
                tbl_Employee_Slab_Def_table_creation(con);
                tbl_Employee_Slab_Det_table_creation(con);
                tbl_Exam_Details_table_creation(con);
                tbl_ExamCodeGeneration_table_creation(con);
                tbl_Expenditure_table_creation(con);
                tbl_GovernmentAudit_table_creation(con);
                tbl_HouseCatg_table_creation(con);
                tbl_Link_Busmaster_table_creation(con);
                tbl_LinkFeeAcc_table_creation(con);
                tbl_Markscalculation_table_creation(con);
                tbl_NonAccadamic_Datails_table_creation(con);
                tbl_OnlyForSchool_table_creation(con);
                tbl_OtherIncome_table_creation(con);
                tbl_SalStruct_Apply_table_creation(con);
                tbl_SchoolLeave_table_creation(con);
                tbl_SectionTransferRecord_table_creation(con);
                tbl_Session_table_creation(con);
                tbl_Student_BusCode_Mast_table_creation(con);
                tbl_Student_BusRoute_Master_table_creation(con);
                tbl_Student_Fee_table_creation(con);
                tbl_Student_FeesDet_table_creation(con);
                tbl_Student_FeesDet_Temp_table_creation(con);
                tbl_Student_FeesMast_table_creation(con);
                tbl_Student_FeesMast_Temp_table_creation(con);
                tbl_Student_PromotionDetails_table_creation(con);
                tbl_StudentAttendance_table_creation(con);
                tbl_StudentDetails_Addmission_table_creation(con);
                tbl_StudentDetails_Class_table_creation(con);
                tbl_StudentDetails_Result_table_creation(con);
                tbl_StudentpreAddmission_table_creation(con);
                tbl_StudentPreAdmList_table_creation(con);
                tbl_Students_Leave_table_creation(con);
                tbl_Students_Leaving_ParentsDetail_table_creation(con);
                tbl_Total_Employee_Pay_table_creation(con);
                tbl_TotalIncome_table_creation(con);
                tbl_TotalPay_table_creation(con);
                temp_table_creation(con);
                TypeDoc_table_creation(con);
                TypeMast_table_creation(con);
                ufldval_table_creation(con);
                unit_table_creation(con);
                unitrel_table_creation(con);
                userfld_table_creation(con);
                vchlock_table_creation(con);
                vchr_table_creation(con);
                wacclog_table_creation(con);
                GenarateFicode_table_creation(con);
                insert_LinkFeeAcc(con);
                insert_lib_CATG(con);
                insert_Autogen(con);
                //Country_table_creation(con);
               // creatTrigCompContary(con);
                StateMaster_table_creation(con);
                
                
                TypeMast_Config_table_creation(con);
                Companywiseid_Relation_table_creation(con);
                AccessLocation_table_creation(con);
                AccessLocation_tbl_Emp_Location(con);
                AccessLocation_paybill(con);
                AccessLocation_tbl_Employee_Config_Retirement(con);
                AccessLocation_paybillD(con);
                AccessLocation_paybillO(con);
                
                AccessLocation_Qualification_Master(con);
                AccessLocation_Relation_Master(con);
                AccessLocation_tbl_Employee_CliantMaster(con);
                AccessLocation_tbl_Employee_OrderDetails(con);
                AccessLocation_OrderDetails_Dtl(con);
                AccessLocation_HourMaster(con);
                AccessLocation_MonthOfDays(con);
                tbl_Employee_ESICodeMaster(con);
                tbl_Employee_PFCodeMaster(con);
                tbl_Employee_PTAXCodeMaster(con);
                AccordFourlogDetail_table_creation(con);
                Emp_DocumentImage_table_creation(con);
                Employee_Link_SalaryStructure_creation(con);
                tbl_Employee_Proxy_Attendance_creation(con);
                tbl_Sal_Heads_Print_creation(con);
                create_EmpAdv(con);
                crt_billOD(con);
                create_EmpKIT(con);
                create_EmpLoan(con);
                create_KIT_Trigger(con);
                create_KIT(con);
                tbl_Employee_Other_Reff_creation(con);
                tbl_Emp_Posting_creation(con);
                tbl_Emp_Adv_creation(con);
                 tbl_Hour_insert(con);
                 tbl_Month_insert(con);

                //APPRTRAN_table_creation / APPRMAST_table_creation / Alloc_table_creation / AGTYPE_table_creation / AddlessLineItem_table_creation
                //pallabi
                //access_table_creation(con);
                //accessbrnch_table_creation(con);
                //APPRTRAN_table_creation(con);
                //APPRMAST_table_creation(con);
                //Alloc_table_creation(con);
                //AGTYPE_table_creation(con);
                //AddlessLineItem_table_creation(con);
                //AddLess_table_creation(con);
                //bill_table_creation(con);
                //Branch_table_creation(con);
                //company_table_creation(con);
                //currency_table_creation(con);
                //data_table_creation(con);
                //docgen_table_creation(con);
                //docnumber_table_creation(con);
                //ficodegen_table_creation(con);
                //glmst_table_creation(con);
                //grp_table_creation(con);
                //idata_table_creation(con);
                //idocmst_table_creation(con);
                //idoctrn_table_creation(con);
                //iglmst_table_creation(con);
                //ficodegen_table_creation(con);
                //glmst_table_creation(con);
                //grp_table_creation(con);
                //idata_table_creation(con);
                //idocmst_table_creation(con);
                //idoctrn_table_creation(con);
                //iglmst_table_creation(con);
                //itran_table_creation(con);
                //menutable_table_creation(con);
                //menuuser_table_creation(con);
                //AccordFour_dbinfo_table_creation(con);
                //narr_table_creation(con);
                //MdsOption_table_creation(con);
                //inarr_table_creation(con);
                //prtyms_table_creation(con);
                //typedoc_table_creation(con);
                //typemast_table_creation(con);
                //vchlock_table_creation(con);
                //vchr_table_creation(con);
                //Unit_table_creation(con);
                //UnitRelationMaster_creation(con);
                //UnitSeries_creation(con);
                //cstock_table_creation(con);
                //Process_table_creation(con);
                //Formula_table_creation(con);
                //WACCOPTN_table_creation(con);
                ////RawMeterialDetails_table_creation(con);
                //creatTrigComWACCOPTN(con);
                //VATMASTER_table_creation(con);
                //LinkVATGLMST_table_creation(con);
                //State_table_creation(con);
                //TaxAssasable_CreatTable(con);
                //MarketRateUpdate(con);
                //BillAdditional_table_creation(con);
                //VATItemGroup_creation(con);
                //VATGroupMaster_creation(con);
                //creatTrigCompStateCode(con);
              // TaxVat(con);
             //   CreateTrigLinkVatGlmst(con);
              //  creatTrigUnit(con);
                //ConsumeProduct_table_creation(con);
                //ReffParty_table_creation(con);
                //TypeMast_Config_table_creation(con);
                //TypeDoc_Config_table_creation(con);
                //Country_table_creation(con);
                //creatTrigCompContary(con);

                //accpost_table_creation(con);                
                //alloc_table_creation(con);               
               // BillTerms_table_creation(con);                
                //dpmst_table_creation(con);                
                //exchngmst_table_creation(con);
                //exbrrel_table_creation(con);
                //effecttran_table_creation(con);
                //etran_table_creation(con);
                //fdint_table_creation(con);
                //fdinfo_table_creation(con);
                //fomula_table_creation(con);                
                //invmst_table_creation(con);                
                //Divident_Schedlr_table_creation(con);
                // AccordFourlog_table_creation(con);                
                //password_table_creation(con);
                //pltran_table_creation(con);                
                //taxdetails_table_creation(con);
                //taxmaster_table_creation(con);                
                //inflt_table_creation(con);
                //cnfgmst_table_creation(con);
                //cnfgcmp_table_creation(con);
                //cnfguser_table_creation(con);
                //cnfgfinanc_table_creation(con);
                //INSURANCEMST_table_creation(con);
                //INSURANCECHLD_table_creation(con);
                //UserFormulaMaster_table_creation(con);
                //INSURANCEFUND_table_creation(con);
                //FixedDepositeMaster_table_creation(con);
                //InsRiskProfile_table_creation(con);
                //ExpRev_table_creation(con);                
                //Commodity_table_creation(con);
                //IGLMST_MASTER_table_creation(con);
                //share_info_table_creation(con);
                //NomineeMaster(con);
                //MFDET_table_creation(con);
                //MFMST_table_creation(con);
                //Condat_table_creation(con);
                //InsMktRate_table_creation(con);
                //ShortSale(con);
                //AssetPropFld(con);
                //LocationMaster(con);
                //DistrictMaster(con);
                //DepartmentMaster(con);
                //OrganizationPersonMaster(con);
                //ContactRelationDetails(con);
                 //new code block added by Bibhas
                 try
                 {

                     string filePath = "";
                     filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
                     string line;
                     if (File.Exists(filePath))
                     {

                         StreamReader file = null;
                         try
                         {
                             Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                             Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
                             edpcon.Close();
                             file = new StreamReader(filePath);
                             if (file.ReadLine() != null)
                             {
                                 int chk_str = 0;
                                 while ((line = file.ReadLine()) != null)
                                 {
                                     string[] StrSTAR = line.Trim().Split('*');
                                     if (StrSTAR.Length == 2)
                                     {
                                         if (StrSTAR[0].Trim() == "")
                                             continue;
                                     }

                                     string[] StrLine = line.Trim().Split('[');
                                     if (StrLine.Length == 2)
                                     {
                                         string str = line.Substring(1, line.Length - 2);
                                         if (str == "Environment_Envelope")
                                             chk_str = 1;
                                         else if (str == "Environment_Menu")
                                             chk_str = 2;
                                         else if (str == "Environment_Bit")
                                             chk_str = 3;
                                     }

                                     string[] StrLine_WACC = line.Trim().Split(';');

                                     if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                                     {
                                         //if (StrLine_WACC[0].ToUpper() == "PETROL")
                                         //    edpcom.EnvironMent_Envelope = "Petrol";
                                         //else if (StrLine_WACC[0].ToUpper() == "PRINTING")
                                         //    edpcom.EnvironMent_Envelope = "PRINTING";
                                         //else if (StrLine_WACC[0].ToUpper() == "BRANDPURCHASE")
                                         //    edpcom.EnvironMent_Envelope = "Brand Purchase";
                                         //else if (StrLine_WACC[0].ToUpper() == "BRANDSALES")
                                         //    edpcom.EnvironMent_Envelope = "Brand Sales";
                                         //else if (StrLine_WACC[0].ToUpper() == "SCHOOL")
                                         //    edpcom.EnvironMent_Envelope = "School";
                                         //else
                                         //    edpcom.EnvironMent_Envelope = "";

                                         if (StrLine_WACC[0].ToUpper() == "DEMO")
                                         {
                                             creatTrigClient(con);
                                             //following line has been added by dwu=ipraj dutta 20092017
                                             creatTrigSACMaster(con);
                                             creatTrigLocSite(con);
                                             createTrigJobTypeMst(con);
                                             creatTrigDesgnation(con);
                                             creatTrigQualification(con);
                                             creatTrigRelation(con);
                                             creatTrigSalHead(con);
                                             creatTrigSalStuc(con);
                                             creatTrigLeaveHead(con);
                                             creatTrigSalCal(con);
                                             creatTrigPtaxSlab(con);


                                         }

                                         else
                                         {
                                             creatTrigDesgnation(con);
                                             creatTrigQualification(con);
                                             creatTrigRelation(con);
                                             creatTrigSalHead(con);
                                             //creatTrigSalHead(con);
                                             creatTrigCompStateCode(con);
                                         }
                                         //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

                                     }
                                 }
                             }
                         }
                         catch { }
                     }
                 }
                 catch { } 
                return true;
            }
            catch
            {

                return false;
            }
        }
//}         // coded by amit  19/11/2013
        private void insert_Autogen(SqlConnection con)
        {
            string sqlstr = " insert into Autogen(prim,Second,voucher) values (3597,8056,0)" + Environment.NewLine;
            
            cmd = new SqlCommand(sqlstr, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }
        }
        private void insert_lib_CATG(SqlConnection con)
        {
            string sqlstr = " insert into lib_CATG(CATG_CODE,CATG) values (1,'Primary')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into lib_CATG(CATG_CODE,CATG) values (2,'Secondary')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into lib_CATG(CATG_CODE,CATG) values (3,'Specimen')" + Environment.NewLine;
            
            cmd = new SqlCommand(sqlstr, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }   
        }                                                       //end
        private void insert_LinkFeeAcc(SqlConnection con)
        {           
            string sqlstr = " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',49,'Tution Fee','Both',51,'T.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',50,'Admission','Yearly',52,'Ad F.','New Student','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',51,'Examination Fee','Yearly',53,'Ex.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',52,'Magazine Fee','Yearly',54,'M.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',53,'Library Fee','Yearly',55,'L.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',54,'Game Fee','Yearly',56,'G.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',55,'Diary Fee','Yearly',57,'D.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',56,'Development Fee','Yearly',58,'DV.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',57,'Session Fee','Yearly',59,'S.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',58,'Computer Adm. Fee','Yearly',60,'C.A.F.','New Student','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',59,'Computer Fee','Both',61,'C.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',60,'Puja Fee','Yearly',62,'P.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',61,'Bank Fee-Book','Yearly',63,'B.F.B.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',62,'Caution Maney','Yearly',64,'C.M.','New Student','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',63,'Lab Charges','Yearly',65,'LAB.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',64,'Transport Fee','Both',66,'TRANS.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',65,'Arrear Tution Fee','Both',67,'A.T.F.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',66,'Other Charges','Both',68,'O.C.','Both','Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,GLcode,Feetype) values('1','1','Fee',74,'Bank',70,'Academic')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into tbl_LinkFeeAcc(Ficode,Gcode,Type,FeeID,FeeName,Frequency,GLcode,ReportHead,FeeFor,Feetype) values('1','1','Fee',75,'Extra','Yearly',69,'Ext.','Both','Academic')" + Environment.NewLine;
           
            cmd = new SqlCommand(sqlstr, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }          
        }

        //private void ShortSale(SqlConnection con)
        //{
        //    string strmfmst = "create table [ShortSaleInfo]([FICode] [char](10) NOT NULL,[GCODE] [char](10) NOT NULL,[T_ENTRY] [char](2) NOT NULL," +
        //                      "[VOUCHER] [numeric](18, 0) NOT NULL,[AUTOINCRE] [numeric](18, 0) IDENTITY(1,1) NOT NULL,[PCODE] [numeric](18, 0) NULL," +
        //                      "[AgainstVoucher] [varchar](100) NULL,[AgainstVoucherDate] [datetime] NULL,[AgainstQty] [decimal](18, 0) NULL,[AgainstRate] [float] NULL," +
        //                      "[AgainstTentry] [char](2) NULL,[AgainstVoucherCode] [numeric](18, 0) NULL,[AgainstAutoIncre] [numeric](18, 0) NULL," +
        //                      "[AgainstRowIndex] [numeric](18, 0) NULL,[AgainstItemNo] [numeric](18, 0) NULL,[BalQty] [decimal](18, 0) NULL,[RowIndex] [numeric](18, 0) NULL,[Itemno] [numeric](18, 0) NULL,PRIMARY KEY CLUSTERED ([FICode] ASC,[GCODE] ASC,[T_ENTRY] ASC,[VOUCHER] ASC,[AUTOINCRE] ASC))";
        //    cmd = new SqlCommand(strmfmst, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch { }
        //}

        ////private void LocationMaster(SqlConnection con)
        ////{
        ////    string strmfmst = "create table [LocationMaster]([FICode] [char](20) NOT NULL,[GCODE] [char](20) NOT NULL," +
        ////                      "[LID] [numeric](18, 0) NOT NULL,[LName] [varchar](200) NOT NULL,[District_ID] [numeric](18, 0) NULL,[PS] [varchar](100) NULL,PRIMARY KEY CLUSTERED ([FICode] ASC,[GCODE] ASC,[LID] ASC))";                              
        ////    cmd = new SqlCommand(strmfmst, con);
        ////    try
        ////    {
        ////        cmd.ExecuteNonQuery();
        ////    }
        ////    catch { }
        ////}

        ////private void DistrictMaster(SqlConnection con)
        ////{
        ////    string strmfmst = "create table [DistrictMaster]([FICode] [char](20) NOT NULL,[GCODE] [char](20) NOT NULL," +
        ////                      "[D_ID] [numeric](18, 0) NOT NULL,[D_Name] [varchar](150) NOT NULL,[StateCode] [numeric](18, 0) NULL,PRIMARY KEY CLUSTERED ([FICode] ASC,[GCODE] ASC,[D_ID] ASC))";
        ////    cmd = new SqlCommand(strmfmst, con);
        ////    try
        ////    {
        ////        cmd.ExecuteNonQuery();
        ////    }
        ////    catch { }
        ////}
        
        ////private void DepartmentMaster(SqlConnection con)
        ////{
        ////    string strmfmst = "create table [DepartmentMaster]([FICode] [char](20) NOT NULL,[GCODE] [char](20) NOT NULL," +
        ////                      "[Dept_ID] [numeric](18, 0) NOT NULL,[DeptName] [varchar](150) NOT NULL,[DeptEDate] [datetime] NULL,[LID] [numeric](18, 0) NULL,PRIMARY KEY CLUSTERED ([FICode] ASC,[GCODE] ASC,[Dept_ID] ASC))";
        ////    cmd = new SqlCommand(strmfmst, con);
        ////    try
        ////    {
        ////        cmd.ExecuteNonQuery();
        ////    }
        ////    catch { }
        ////}

        ////private void OrganizationPersonMaster(SqlConnection con)
        ////{
        ////    string strmfmst = "create table [OrganizationPersonMaster]([FICode] [char](20) NOT NULL,[GCODE] [char](20) NOT NULL," +
        ////                      "[OPID] [numeric](18, 0) NOT NULL,[OPName] [varchar](200) NOT NULL,[OPAddPresent1] [varchar](150) NULL,[OPAddPresent2] [varchar](150) NULL," +
        ////                      "[OPAddParmanent1] [varchar](150) NULL,[OPAddParmanent2] [varchar](150) NULL,[OPPSPresent] [varchar](150) NULL,[OPPSParmanent] [varchar](150) NULL," +
        ////                      "[OPDistrictPresent] [varchar](150) NULL,[OPDistrictParmanent] [varchar](150) NULL,[OPStatePresent] [varchar](150) NULL,[OPStateParmanent] [varchar](150) NULL,[OPPINPresent] [varchar](25) NULL,[OPPINParmanent] [varchar](25) NULL," +
        ////                      "[OPPh1Present] [varchar](20) NULL,[OPPh2Present] [varchar](20) NULL,[OPPh1Parmanent] [varchar](20) NULL,[OPPh2Parmanent] [varchar](20) NULL," +
        ////                      "[OPCountryPresent] [varchar](50) NULL,[OPCountryParmanent] [varchar](50) NULL,[OPEDatePresent] [datetime] NULL,[OPEDateParmanent] [datetime] NULL," +
        ////                      "[OPEmailPresent1] [varchar](150) NULL,[OPEmailPresent2] [varchar](150) NULL,[OPEmailParmanent1] [varchar](150) NULL,[OPEmailParmanent2] [varchar](150) NULL," +
        ////                      "[OPFaxNoPresent] [varchar](150) NULL,[OPFaxNoParmanent] [varchar](150) NULL,[OPDOB] [datetime] NULL,[OPMADATE] [datetime] NULL," +
        ////                      "[OrgPerStatus] [varchar](15) NOT NULL,[Ref_OPID] [numeric](18, 0) NULL,[Salvtation] [varchar](15) NULL,PRIMARY KEY CLUSTERED ([FICode] ASC,[GCODE] ASC,[OPID] ASC,[OrgPerStatus] ASC))";
        ////    cmd = new SqlCommand(strmfmst, con);
        ////    try
        ////    {
        ////        cmd.ExecuteNonQuery();
        ////    }
        ////    catch { }
        ////}

        ////private void ContactRelationDetails(SqlConnection con)
        ////{
        ////    string strmfmst = "create table [ContactRelationDetails]([FICode] [char](20) NOT NULL,[GCODE] [char](20) NOT NULL," +
        ////                      "[Org_ID] [numeric](18, 0) NOT NULL,[CP_ID] [numeric](18, 0) NOT NULL,[District_ID] [numeric](18, 0) NULL,[ContactDate] [datetime] NULL," +
        ////                      "[Dept_ID] [numeric](18, 0) NULL,[EntryDate] [datetime] NULL,[Designation] [numeric](18, 0) NULL," +
        ////                      "PRIMARY KEY CLUSTERED ([FICode] ASC,[GCODE] ASC,[Org_ID] ASC,[CP_ID] ASC))";
        ////    cmd = new SqlCommand(strmfmst, con);
        ////    try
        ////    {
        ////        cmd.ExecuteNonQuery();
        ////    }
        ////    catch { }
        ////}


        // all the trigger
        public bool firstimemethod(SqlConnection con)
        {
            try
            {

                string sqlstr = "CREATE TRIGGER [TrigCompOnIns] on [Company] for insert as set nocount on " + Environment.NewLine;
                sqlstr = sqlstr + " Declare @gcode Char(10),@ficode char(10),@name varchar(50)" + Environment.NewLine;
                sqlstr = sqlstr + "  select @gcode=gcode,@ficode=ficode,@name=CO_NAME from inserted " + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 1, 0, 'Share Capital', null, 30, 0, 0, 'BL',0,'C', '1', 1,0, 0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 2, 0, 'Loan Funds', null, 30, 0, 0, 'BL',0,'C', 2, 1,0, 0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 3, 0, 'Current Liabilities & Provisions', null, 30, 0, 0, 'BL',0,'C', '3',1,0,0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 4, 0, 'Fixed Assets', null, 30, 0, 0, 'BA',0,'D','4',1,0,0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 5, 0, 'Investments', null, 30, 0, 0, 'BA',0,'D', '5',1,0,0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 6, 0, 'Current Assets,Loans & Advances', null, 30, 0, 0, 'BA',0,'D','6',1,0,0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 7, 0, 'Miscellaneous Expenditure', null, 30, 0, 0, 'BA',0,'D','7',1,0,0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 8, 0, 'Direct Expenses', null, 31, 0, 0, 'TD',0,'D','8',1,0,0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 9, 0, 'Sales', null, 60, 0, 0, 'TC',0,'C','9',1,0, 0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 10,0, 'Indirect Expenses', null, 31, 0, 0, 'PD',0,'D','10',1,0,0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 11,0, 'Indirect Income', null, 31, 0, 0, 'PC',0,'C','11',1,0,0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 12,0, 'Profit & Loss', null, 30, 0, 0, 'PL',0,'C','12',1,0,0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 13,0, 'UnExchanged Foreign Currency Gain/Loss', null, 75, 0, 0, 'FB',0,'X','13',0,0,0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO grp VALUES(@ficode,@gcode, 14,0, 'Realized Foreign Currency Gain/Loss', null, 76, 0, 0, 'FP',0,'X','14',0,0,0,null)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO ACCESS(USER_CODE,ficode,GCODE) VALUES('1',@ficode,@gcode)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO ACCESSBRANCH(USER_CODE,ficode,GCODE,BRNCH_CODE) VALUES('1',@ficode,@gcode,0)" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO ACCESSBRANCH(USER_CODE,ficode,GCODE,BRNCH_CODE) VALUES('1',@ficode,@gcode,1)" + Environment.NewLine;
                sqlstr = sqlstr + " EXEC BillTerms_ins @ficode,@gcode" + Environment.NewLine;
                ////sqlstr = sqlstr + " EXEC currency_ins @pFICode=@ficode,@pGcode=@gcode" + Environment.NewLine;
                sqlstr = sqlstr + " EXEC TaxMaster_ins @pFICode=@ficode,@pGcode=@gcode" + Environment.NewLine;
                //sqlstr = sqlstr + " EXEC TypeMast_ins @pFICode=@ficode,@pGcode=@gcode" + Environment.NewLine;
                sqlstr = sqlstr + " If Exists(Select * From Branch WHERE GCODE=@gcode and FIcode<>@ficode )" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " declare @gficode char(10)" + Environment.NewLine;
                sqlstr = sqlstr + " Select @gficode=ficode From Branch WHERE GCODE=@gcode and FIcode<>@ficode" + Environment.NewLine;
                sqlstr = sqlstr + " declare @BRNCH_CODE numeric(5),@BRNCH_NAME varchar(40),@BRNCH_ADD1 varchar(40),@BRNCH_ADD2 varchar(40),@BRNCH_CITY varchar(20),@BRNCH_STATE varchar(20)," + Environment.NewLine;
                sqlstr = sqlstr + " @BRNCH_PIN varchar(10),@BRNCH_CST varchar(30),@BRNCH_SST varchar(30),@BRNCH_TELE1 varchar(20),@BRNCH_TELE2 varchar(20),@BRNCH_TELE3 varchar(20)," + Environment.NewLine;
                sqlstr = sqlstr + " @BRNCH_PAN1 varchar(30), @BRNCH_PAN2 varchar(30),@VAT_DET varchar(25),@BRNCH_FAX varchar(20),@BRNCH_EMAIL varchar(40),@CONTACT_PERSON varchar(40)," + Environment.NewLine;
                sqlstr = sqlstr + " @PERSON_DESIG varchar(20),@FREEZE_FROM datetime,@FREEZE_TO datetime,@COUNTRY varchar(20),@EX_REG_NO varchar(40),@EX_DIV varchar(40), @EX_COMM varchar(40)," + Environment.NewLine;
                sqlstr = sqlstr + " @ECC_NO varchar(40),@EX_RANGE varchar(40),@Brnch_Alias varchar(10),@Stax float(8),@STT float(8),@TAN varchar(50),@STAXNO varchar(50),@DIN1 varchar(50),@DIN2 varchar (50),@DIN3 varchar(50),@DIN4 varchar(50)" + Environment.NewLine;
                sqlstr = sqlstr + " Declare Cursor2 Cursor For select" + Environment.NewLine;
                sqlstr = sqlstr + " distinct BRNCH_CODE,BRNCH_NAME,BRNCH_ADD1,BRNCH_ADD2,BRNCH_CITY,BRNCH_STATE,BRNCH_PIN,BRNCH_CST, BRNCH_SST,BRNCH_TELE1,BRNCH_TELE2,BRNCH_TELE3,BRNCH_PAN1," + Environment.NewLine;
                sqlstr = sqlstr + " BRNCH_PAN2,VAT_DET,BRNCH_FAX,BRNCH_EMAIL,CONTACT_PERSON,PERSON_DESIG, FREEZE_FROM,FREEZE_TO,COUNTRY,EX_REG_NO,EX_DIV, EX_COMM,ECC_NO,EX_RANGE," + Environment.NewLine;
                sqlstr = sqlstr + " Brnch_Alias,Stax,STT,TAN ,STAXNO,DIN1 ,DIN2 ,DIN3 ,DIN4  from branch where gcode=@gcode and ficode=@gficode" + Environment.NewLine;
                sqlstr = sqlstr + " Open Cursor2 " + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From Cursor2  into @BRNCH_CODE,@BRNCH_NAME,@BRNCH_ADD1,@BRNCH_ADD2,@BRNCH_CITY,@BRNCH_STATE,@BRNCH_PIN,@BRNCH_CST," + Environment.NewLine;
                sqlstr = sqlstr + " @BRNCH_SST,@BRNCH_TELE1,@BRNCH_TELE2,@BRNCH_TELE3,@BRNCH_PAN1,@BRNCH_PAN2,@VAT_DET,@BRNCH_FAX,@BRNCH_EMAIL,@CONTACT_PERSON,@PERSON_DESIG," + Environment.NewLine;
                sqlstr = sqlstr + " @FREEZE_FROM,@FREEZE_TO,@COUNTRY,@EX_REG_NO,@EX_DIV, @EX_COMM,@ECC_NO,@EX_RANGE,@Brnch_Alias,@Stax,@STT,@TAN ,@STAXNO,@DIN1 ,@DIN2 ,@DIN3 ,@DIN4" + Environment.NewLine;
                sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO branch(FIcode,GCODE,Brnch_Code,Brnch_Name,BRNCH_ADD1,BRNCH_ADD2,BRNCH_CITY,BRNCH_STATE,BRNCH_PIN,BRNCH_CST," + Environment.NewLine;
                sqlstr = sqlstr + " BRNCH_SST,BRNCH_TELE1,BRNCH_TELE2,BRNCH_TELE3,BRNCH_PAN1,BRNCH_PAN2,VAT_DET,BRNCH_FAX,BRNCH_EMAIL,CONTACT_PERSON,PERSON_DESIG," + Environment.NewLine;
                sqlstr = sqlstr + " FREEZE_FROM,FREEZE_TO,COUNTRY,EX_REG_NO,EX_DIV, EX_COMM,ECC_NO,EX_RANGE,Brnch_Alias,Stax,STT,TAN,STAXNO,DIN1,DIN2,DIN3,DIN4" + Environment.NewLine;
                sqlstr = sqlstr + " )VALUES(@ficode,@gcode,@BRNCH_CODE,@BRNCH_NAME,@BRNCH_ADD1,@BRNCH_ADD2,@BRNCH_CITY,@BRNCH_STATE,@BRNCH_PIN,@BRNCH_CST," + Environment.NewLine;
                sqlstr = sqlstr + "  @BRNCH_SST,@BRNCH_TELE1,@BRNCH_TELE2,@BRNCH_TELE3,@BRNCH_PAN1,@BRNCH_PAN2,@VAT_DET,@BRNCH_FAX,@BRNCH_EMAIL,@CONTACT_PERSON,@PERSON_DESIG," + Environment.NewLine;
                sqlstr = sqlstr + "  @FREEZE_FROM,@FREEZE_TO,@COUNTRY,@EX_REG_NO,@EX_DIV, @EX_COMM,@ECC_NO,@EX_RANGE,@Brnch_Alias,@Stax,@STT,@TAN ,@STAXNO,@DIN1 ,@DIN2 ,@DIN3 ,@DIN4)" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From Cursor2 into @BRNCH_CODE,@BRNCH_NAME,@BRNCH_ADD1,@BRNCH_ADD2,@BRNCH_CITY,@BRNCH_STATE,@BRNCH_PIN,@BRNCH_CST," + Environment.NewLine;
                sqlstr = sqlstr + " @BRNCH_SST,@BRNCH_TELE1,@BRNCH_TELE2,@BRNCH_TELE3,@BRNCH_PAN1,@BRNCH_PAN2,@VAT_DET,@BRNCH_FAX,@BRNCH_EMAIL,@CONTACT_PERSON,@PERSON_DESIG," + Environment.NewLine;
                sqlstr = sqlstr + " @FREEZE_FROM,@FREEZE_TO,@COUNTRY,@EX_REG_NO,@EX_DIV, @EX_COMM,@ECC_NO,@EX_RANGE,@Brnch_Alias,@Stax,@STT,@TAN ,@STAXNO,@DIN1 ,@DIN2 ,@DIN3 ,@DIN4" + Environment.NewLine;
                sqlstr = sqlstr + " End" + Environment.NewLine;
                sqlstr = sqlstr + " CLOSE Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " DEALLOCATE Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + "  END" + Environment.NewLine;
                //sqlstr = sqlstr + " ELSE" + Environment.NewLine;
                //sqlstr = sqlstr + "  BEGIN" + Environment.NewLine;
                //sqlstr = sqlstr + " INSERT INTO branch( ficode,GCODE,Brnch_Code,Brnch_Name,Stax,STT) VALUES(@ficode,@gcode,0,@name,12.36,0.25)" + Environment.NewLine;
                //sqlstr = sqlstr + " INSERT INTO branch( ficode,GCODE,Brnch_Code,Brnch_Name,Stax,STT) VALUES(@ficode,@gcode,1,@name,12.36,0.25)" + Environment.NewLine;
                //sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " set nocount off";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }


                        
                //////sqlstr = " CREATE TRIGGER [TrigCompOnglmstIns] on [Company] For insert as set nocount on " + Environment.NewLine;
                //////sqlstr = sqlstr + " Declare @gcode Char(10),@ficode varchar(10)" + Environment.NewLine;
                //////sqlstr = sqlstr + " select @gcode=gcode,@ficode=ficode from inserted " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 6,14,1,  'Cash Account', null, 20, 0, 0, 0, 1, 14, '0000000000', 0, 'D','1' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 12, 0, 2,  'Profit & Loss A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 6, 0, 3,  'Opening Balance Debit A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','3' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 3, 0, 4,  'Opening Balance Credit A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','4' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine;
                //////sqlstr = sqlstr + "  INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 1, 1, 0,  'Reserve & Surplus', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','13' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 2, 2, 0,  'Secured Loans', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','14' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 2, 3, 0,  'Unsecured Loans', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','15' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 2, 4, 0,  'Bank Overdraft', null, 21, 0, 0, 0, 1, 0, '0000000000', 0, 'C','16' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3, 5, 0,  'Sundry Creditors', null, 23, 0, 0, 0, 1, 0, '0000000000', 0, 'C','17' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S',3,  6, 0,  'Duties & Taxes', null, 32, 0, 0, 0, 1, 0, '0000000000', 0, 'C','18' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3,  7, 0,  'Provision', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','19' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3,  8, 0,  'Provision for Taxation', null, 30, 0, 0, 0, 2, 7, '0000000000', 0, 'C','20' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3,  9, 0,  'Provision for Dividend', null, 30, 0, 0, 0, 2, 7, '0000000000', 0, 'C','21' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 4, 10, 0,  'Fixed Asstes at Cost', null, 30, 0, 0, 0,1, 0, '0000000000', 0, 'D','22' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 4, 11, 0,  'Less Accumulated Depreciation', null, 30, 0, 0, 0, 1,0, '0000000000', 0, 'C','23' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 12, 0,  'Sundry Debtors', null, 22, 0, 0, 0, 1, 0, '0000000000', 0, 'D','24' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 13, 0,  'Stock in Hand', null, 70, 0, 0, 0, 1, 0, '0000000000', 0, 'D','25' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + "  INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 14, 0,  'Cash Balances', null, 20, 0, 0, 0, 1, 0, '0000000000', 0, 'D','26' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 15, 0,  'Bank Balances', null, 21, 0, 0, 0, 1, 0, '0000000000', 0, 'D','27' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 16, 0,  'Short Term Investments', null, 21, 0, 0, 0, 2, 15, '0000000000', 0, 'D','28' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 17, 0,  'Loans and Advances', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 8, 18, 0,  'Purchase Account', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S',10, 19, 0,  'Administration & Selling Expenses', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S',10, 20, 0,  'Finance Expenses', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S',10, 21, 0,  'Interest Expenses', null, 31, 0, 0, 0, 2, 20, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S',10, 22, 0,  'Dividend Expenses', null, 31, 0, 0, 0, 2, 20, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S',11, 23, 0,  'Profit on Sale of Investments', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S',11, 24, 0,  'Profit on Sale of Fixed Assets', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S',11, 25, 0,  'Investment Income', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S',11, 26, 0,  'Extraordinary Expenses', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3, 27, 0, 'Broker', null, 23, 0, 0, 0, 2, 5, '0000000000', 0, 'C','40' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine;
                //////sqlstr = sqlstr + "  INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 4, 28, 0,  'Less Depriciation Of Factory Equipments', null, 33, 0, 0, 0, 1,0, '0000000000', 0, 'C','41' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine;
                //////sqlstr = sqlstr + " INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 8, 29, 0,  'Opening Stock', null, 30, 0, 0, 0, 1,0, '0000000000', 0, 'C','41' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine;
                //////sqlstr = sqlstr + "  INSERT INTO prtyms(FICode,GCODE,GLCode,STT,SERVICE_TAX,brokShrtsl,brokPurchase,BRKG_PERCENTAGE,CRED_DAYS) VALUES(@ficode,@gcode, 7, 0.25, 12.36, 0.5, 0.5, 0.5,7)" + Environment.NewLine;
                //////sqlstr = sqlstr + " set nocount off";
                //////cmd = new SqlCommand(sqlstr, con);
                //////try
                //////{
                //////    cmd.ExecuteNonQuery();
                //////}
                //////catch { }
                //--------------------cnfgmst trig---------------
                //sqlstr = "CREATE TRIGGER TrigCnfgOnIns on CNFGMST for insert as set nocount on" + Environment.NewLine;
                //sqlstr = sqlstr + "EXEC CNFGMST_ins" + Environment.NewLine;
                //sqlstr = sqlstr + "set nocount off";
                //cmd = new SqlCommand(sqlstr, con);
                //try
                //{
                //    cmd.ExecuteNonQuery();
                //}
                //catch { }
                //------------------------------------------------

                sqlstr = "CREATE Trigger UpdtGrpForLedgTrig On glmst For Update As " + Environment.NewLine;
                sqlstr = sqlstr + " If Exists(Select I.* From Inserted as I,Deleted as D Where I.CurBal <> D.CurBal and I.Mtype='S')" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " Update glmst" + Environment.NewLine;
                sqlstr = sqlstr + " Set Glmst.CurBal = Glmst.CurBal + I.CurBal - D.CurBal " + Environment.NewLine;
                sqlstr = sqlstr + " From Glmst, Inserted as I, Deleted as D " + Environment.NewLine;
                sqlstr = sqlstr + " Where  Glmst.SGroup=I.Prev_Group  and Glmst.Mtype='S' and  Glmst.GCode= I.GCode and  Glmst.FIcode = I.FIcode " + Environment.NewLine;
                sqlstr = sqlstr + " End" + Environment.NewLine;
                sqlstr = sqlstr + " If Exists(Select I.* From Inserted as I,Deleted as D Where I.CurBal <> D.CurBal and I.Mtype='L')" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " Update grp" + Environment.NewLine;
                sqlstr = sqlstr + " Set Grp.CurBal = Grp.CurBal + I.CurBal - D.CurBal " + Environment.NewLine;
                sqlstr = sqlstr + " From Grp, Inserted as I, Deleted as D Where  Grp.MGroup= I.MGroup and Grp.GCode = I.GCode and  Grp.FIcode = I.FIcode" + Environment.NewLine;
                sqlstr = sqlstr + " Update Glmst" + Environment.NewLine;
                sqlstr = sqlstr + " Set Glmst.CurBal = Glmst.CurBal + I.CurBal - D.CurBal" + Environment.NewLine;
                sqlstr = sqlstr + " From Glmst, Inserted as I, Deleted as D Where  Glmst.SGroup=I.SGroup  and Glmst.Mtype='S'" + Environment.NewLine;
                sqlstr = sqlstr + " and  Glmst.GCode= I.GCode and  Glmst.FIcode = I.FIcode" + Environment.NewLine;
                sqlstr = sqlstr + " End";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }

                sqlstr = "create TRIGGER [billAfterInsert] ON [paybillD] " + Environment.NewLine;
                sqlstr = sqlstr + " After insert " + Environment.NewLine;
                sqlstr = sqlstr + " AS " + Environment.NewLine;
                sqlstr = sqlstr + " begin " + Environment.NewLine;
                sqlstr = sqlstr + " declare @month varchar(100);" + Environment.NewLine;
                sqlstr = sqlstr + " declare @location varchar(100);" + Environment.NewLine;
                sqlstr = sqlstr + " declare @Session varchar(100);" + Environment.NewLine;
                sqlstr = sqlstr + " declare @desig_id varchar(100);" + Environment.NewLine;
                sqlstr = sqlstr + " select @month=i.month from inserted i;" + Environment.NewLine;
                sqlstr = sqlstr + " select @location=i.Location_ID  from inserted i;" + Environment.NewLine;	
                sqlstr = sqlstr + " select @Session=i.Session  from inserted i;" + Environment.NewLine;	
                sqlstr = sqlstr + " select @desig_id=i.desig_id  from inserted i;" + Environment.NewLine;	
                sqlstr = sqlstr + " Update tbl_Employee_SalaryMast " + Environment.NewLine;
                sqlstr = sqlstr + " Set tbl_Employee_SalaryMast.bill_tag = 1" + Environment.NewLine;
                sqlstr = sqlstr + " From tbl_Employee_SalaryMast, Inserted as I" + Environment.NewLine;
                sqlstr = sqlstr + " where tbl_Employee_SalaryMast.Month=@month and tbl_Employee_SalaryMast.Location_id=@location	and tbl_Employee_SalaryMast.Session=@Session and tbl_Employee_SalaryMast.desig_id=@desig_id " + Environment.NewLine;
                sqlstr = sqlstr + " End";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }

                sqlstr = " create TRIGGER [billAfterDelete] ON [paybillD] ";
                sqlstr = sqlstr + " After Delete" + Environment.NewLine;
                sqlstr = sqlstr + " AS" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " declare @month varchar(100);" + Environment.NewLine;
                sqlstr = sqlstr + " declare @location varchar(100);" + Environment.NewLine;
                sqlstr = sqlstr + " declare @Session varchar(100);" + Environment.NewLine;
                sqlstr = sqlstr + " declare @desig_id varchar(100);" + Environment.NewLine;
                sqlstr = sqlstr + " select @month=i.month from deleted  i;	" + Environment.NewLine;
                sqlstr = sqlstr + " select @location=i.Location_ID  from deleted i;	" + Environment.NewLine;
                sqlstr = sqlstr + " select @Session=i.Session  from deleted i;	" + Environment.NewLine;
                sqlstr = sqlstr + " select @desig_id=i.desig_id  from deleted i;	" + Environment.NewLine;
                sqlstr = sqlstr + " Update tbl_Employee_SalaryMast" + Environment.NewLine;
                sqlstr = sqlstr + " Set tbl_Employee_SalaryMast.bill_tag = 0" + Environment.NewLine;
                sqlstr = sqlstr + "  From tbl_Employee_SalaryMast, deleted  as I" + Environment.NewLine;
                sqlstr = sqlstr + "  where tbl_Employee_SalaryMast.Month=@month and tbl_Employee_SalaryMast.Location_id=@location	and tbl_Employee_SalaryMast.Session=@Session and tbl_Employee_SalaryMast.desig_id=@desig_id " + Environment.NewLine;
               sqlstr = sqlstr + " End";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                cmd.ExecuteNonQuery();
                }
                catch { }
 

                sqlstr = "CREATE Trigger UpdtGrpForLedgTrig On glmst For Update As " + Environment.NewLine;
                sqlstr = sqlstr + " If Exists(Select I.* From Inserted as I,Deleted as D Where I.CurBal <> D.CurBal and I.Mtype='S')" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " Update glmst" + Environment.NewLine;
                sqlstr = sqlstr + " Set Glmst.CurBal = Glmst.CurBal + I.CurBal - D.CurBal " + Environment.NewLine;
                sqlstr = sqlstr + " From Glmst, Inserted as I, Deleted as D " + Environment.NewLine;
                sqlstr = sqlstr + " Where  Glmst.SGroup=I.Prev_Group  and Glmst.Mtype='S' and  Glmst.GCode= I.GCode and  Glmst.FIcode = I.FIcode " + Environment.NewLine;
                sqlstr = sqlstr + " End" + Environment.NewLine;
                sqlstr = sqlstr + " If Exists(Select I.* From Inserted as I,Deleted as D Where I.CurBal <> D.CurBal and I.Mtype='L')" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " Update grp" + Environment.NewLine;
                sqlstr = sqlstr + " Set Grp.CurBal = Grp.CurBal + I.CurBal - D.CurBal " + Environment.NewLine;
                sqlstr = sqlstr + " From Grp, Inserted as I, Deleted as D Where  Grp.MGroup= I.MGroup and Grp.GCode = I.GCode and  Grp.FIcode = I.FIcode" + Environment.NewLine;
                sqlstr = sqlstr + " Update Glmst" + Environment.NewLine;
                sqlstr = sqlstr + " Set Glmst.CurBal = Glmst.CurBal + I.CurBal - D.CurBal" + Environment.NewLine;
                sqlstr = sqlstr + " From Glmst, Inserted as I, Deleted as D Where  Glmst.SGroup=I.SGroup  and Glmst.Mtype='S'" + Environment.NewLine;
                sqlstr = sqlstr + " and  Glmst.GCode= I.GCode and  Glmst.FIcode = I.FIcode" + Environment.NewLine;
                sqlstr = sqlstr + " End";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }


                sqlstr = " CREATE Trigger TrigUpdtLedgBal On vchr For Insert, Update, Delete As " + Environment.NewLine;
                sqlstr = sqlstr + "Set NoCount On" + Environment.NewLine;
                sqlstr = sqlstr + " Declare @GCode VarChar(10),@FICode VarChar(10),@ToBy Char(2),@GlCode Varchar(10), @DbAmt money, @CrAmt money,@Fc_DbAmt money, @Fc_CrAmt money " + Environment.NewLine;
                sqlstr = sqlstr + " Declare @CurrCode Char(6)" + Environment.NewLine;
                sqlstr = sqlstr + " Declare @CurAmt Float, @FcCurAmt Float " + Environment.NewLine;
                sqlstr = sqlstr + " Declare  @TrDate DateTime" + Environment.NewLine;
                sqlstr = sqlstr + " Select @Gcode=GCode, @FICode=FICode,@TrDate=VchDate, @GlCode=GlCode,@CurAmt=DbAmt-CrAmt  from Deleted " + Environment.NewLine;
                sqlstr = sqlstr + " Declare Cursor1 Cursor For select GCode,FICode,ToBy,GlCode,DbAmt,CrAmt,Fc_DbAmt,Fc_CrAmt  from deleted" + Environment.NewLine;
                sqlstr = sqlstr + " Open Cursor1 " + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From Cursor1 into @GCode,@FICode, @ToBy, @GlCode, @DbAmt, @CrAmt, @Fc_DbAmt, @Fc_CrAmt " + Environment.NewLine;
                sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " If Upper(@ToBy) = 'TO'" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " Update Glmst Set CurBal=CurBal + @CrAmt Where GlCode = @GlCode and GCode = @GCode and FICode=@FICode" + Environment.NewLine;
                sqlstr = sqlstr + " End " + Environment.NewLine;
                sqlstr = sqlstr + " If Upper(@ToBy) = 'BY'" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " Update Glmst Set CurBal=CurBal - @DbAmt Where GlCode = @GlCode and GCode = @GCode and FICode=@FICode" + Environment.NewLine;
                sqlstr = sqlstr + " End" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From Cursor1 Into @GCode,@FICode, @ToBy, @GlCode, @DbAmt, @CrAmt, @Fc_DbAmt, @Fc_CrAmt" + Environment.NewLine;
                sqlstr = sqlstr + " End" + Environment.NewLine;
                sqlstr = sqlstr + " Close Cursor1" + Environment.NewLine;
                sqlstr = sqlstr + " Deallocate Cursor1" + Environment.NewLine;
                sqlstr = sqlstr + " If exists(Select * from inserted)" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " Select @Gcode=GCode,  @FICode=FICode,@TrDate=VchDate, @GlCode=GlCode,@CurAmt=DbAmt-CrAmt  from Inserted " + Environment.NewLine;
                sqlstr = sqlstr + " Select @CurrCode=G.Curr_Code from GlMst G, Inserted I where G.GCode=I.GCode and G.GlCode=I.GlCode and G.MType='L' " + Environment.NewLine;
                sqlstr = sqlstr + " Select @ToBy = ToBy From Inserted " + Environment.NewLine;
                sqlstr = sqlstr + " If Upper(@ToBy) = 'TO'" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " Update Glmst Set CurBal=CurBal - I.CrAmt From Glmst,Inserted as I" + Environment.NewLine;
                sqlstr = sqlstr + " Where Glmst.GlCode = I.GlCode and Glmst.GCode = I.GCode  and Glmst.FICode = I.FICode " + Environment.NewLine;
                sqlstr = sqlstr + " End " + Environment.NewLine;
                sqlstr = sqlstr + " Else " + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " Update Glmst Set CurBal=CurBal + I.DbAmt From Glmst,Inserted as I " + Environment.NewLine;
                sqlstr = sqlstr + " Where Glmst.GlCode = I.GlCode and Glmst.GCode = I.GCode  and Glmst.FICode = I.FICode" + Environment.NewLine;
                sqlstr = sqlstr + " End" + Environment.NewLine;
                sqlstr = sqlstr + " End" + Environment.NewLine;
                sqlstr = sqlstr + " Set NoCount Off" + Environment.NewLine;
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }

                sqlstr = "CREATE TRIGGER AdjustEtran ON PLtran" + Environment.NewLine;
                sqlstr = sqlstr + " FOR INSERT, DELETE AS" + Environment.NewLine;
                sqlstr = sqlstr + " set NoCount On" + Environment.NewLine;
                sqlstr = sqlstr + " declare @AgainstTentry char(2),@AgainstVoucherCode numeric,@AgainstAutoIncre numeric,@EffectiveQTY float,@T_Entry char(2)" + Environment.NewLine;
                sqlstr = sqlstr + " if exists(Select * from deleted where T_Entry in ('C8','C9','9M','8','9','8N','9N','9G','9S'))" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " Declare delcur Cursor For select AgainstTentry,AgainstVoucherCode,AgainstAutoIncre,EffectiveQTY,T_ENTRY from deleted" + Environment.NewLine;
                sqlstr = sqlstr + " Open delcur" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From delcur into @AgainstTentry,@AgainstVoucherCode,@AgainstAutoIncre,@EffectiveQTY,@T_Entry" + Environment.NewLine;
                sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " if(@T_Entry='C8') or (@T_Entry='8') or (@T_Entry='8N')" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " update etran set BALQTY=BALQTY+@EffectiveQTY,STATUS='PendingPurchase'  where T_ENTRY=@AgainstTentry and VOUCHER=@AgainstVoucherCode and AUTOINCRE=@AgainstAutoIncre and STATUS='PendingPurchase' or STATUS='Complete'" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " else if(@T_Entry='C9') or (@T_Entry='9M') or (@T_Entry='9') or (@T_Entry='9N') or (@T_Entry='9G') or (@T_Entry='9S')" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " update etran set BALQTY=BALQTY+@EffectiveQTY,STATUS='PendingSale'  where T_ENTRY=@AgainstTentry and VOUCHER=@AgainstVoucherCode and AUTOINCRE=@AgainstAutoIncre and STATUS in('PendingSale','Complete')" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From delcur into @AgainstTentry,@AgainstVoucherCode,@AgainstAutoIncre,@EffectiveQTY,@T_Entry" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " Close delcur" + Environment.NewLine;
                sqlstr = sqlstr + " Deallocate delcur" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " if exists(Select * from inserted where T_Entry in ('9M','9','8','C8','C9','8N','9N','9G','9S'))" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " Declare delcur1 Cursor For select AgainstTentry,AgainstVoucherCode,AgainstAutoIncre,EffectiveQTY,T_ENTRY from inserted" + Environment.NewLine;
                sqlstr = sqlstr + " Open delcur1" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From delcur1 into @AgainstTentry,@AgainstVoucherCode,@AgainstAutoIncre,@EffectiveQTY,@T_Entry" + Environment.NewLine;
                sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " if (@T_Entry='9M') or (@T_Entry='9') or (@T_Entry='8') or (@T_Entry='C8') or (@T_Entry='C9') or (@T_Entry='9N') or (@T_Entry='9G') or (@T_Entry='9S')" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " declare @balQTY numeric" + Environment.NewLine;
                sqlstr = sqlstr + " Declare delcur2 Cursor For select BALQTY from etran where T_ENTRY=@AgainstTentry and VOUCHER=@AgainstVoucherCode and AUTOINCRE=@AgainstAutoIncre" + Environment.NewLine;
                sqlstr = sqlstr + " Open delcur2" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From delcur2 into @balQTY" + Environment.NewLine;
                sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " set @balQTY=@balQTY-@EffectiveQTY" + Environment.NewLine;
                sqlstr = sqlstr + " if (@balQTY=0)" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " update etran set BALQTY=BALQTY-@EffectiveQTY,STATUS='Complete'  where T_ENTRY=@AgainstTentry and VOUCHER=@AgainstVoucherCode and AUTOINCRE=@AgainstAutoIncre" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " else if(@balQTY>0)" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " update etran set BALQTY=BALQTY-@EffectiveQTY,STATUS='PendingSale'  where T_ENTRY=@AgainstTentry and VOUCHER=@AgainstVoucherCode and AUTOINCRE=@AgainstAutoIncre" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From delcur2 into @balQTY" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " Close delcur2" + Environment.NewLine;
                sqlstr = sqlstr + " Deallocate delcur2" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From delcur1 into @AgainstTentry,@AgainstVoucherCode,@AgainstAutoIncre,@EffectiveQTY,@T_Entry" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " Close delcur1" + Environment.NewLine;
                sqlstr = sqlstr + " Deallocate delcur1" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " set NoCount Off";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }

                sqlstr = "CREATE TRIGGER EfectOnIGLMST ON Itran FOR INSERT, UPDATE, DELETE AS BEGIN" + Environment.NewLine;
                sqlstr = sqlstr + " set NoCount On" + Environment.NewLine;
                sqlstr = sqlstr + " declare @T_Entry char(2),@ficode char(10),@Gcode char(10),@PCode numeric,@qty float" + Environment.NewLine;
                sqlstr = sqlstr + " if exists(Select * from Deleted where T_Entry in ('8','8O','S','9','C8','C9','CS','8G','8S','9G','9S','8I','8F','9F','8M','9M','8U','9U','8N','9N'))" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " Declare delcur Cursor For select FICode,GCODE,T_Entry,PCode,qty from Deleted where ItemState<>'" + "DO" + "'" + Environment.NewLine;
                sqlstr = sqlstr + " Open delcur" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From delcur into @ficode,@Gcode, @T_Entry, @PCode,@qty" + Environment.NewLine;
                sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " if (@T_Entry='S') or (@T_Entry='9') or (@T_Entry='CS') or (@T_Entry='C9') or (@T_Entry='9G') or (@T_Entry='9S') or (@T_Entry='9F') or  (@T_Entry='9M') or (@T_Entry='9U') or (@T_Entry='9N')" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " update iglmst set curstk=curstk+@qty where ficode=@ficode and pcode=@PCode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " if (@T_Entry='8') or (@T_Entry='C8') or (@T_Entry='8I') or (@T_Entry='8F') or (@T_Entry='8M') or (@T_Entry='8U') or (@T_Entry='8N')" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " update iglmst  set curstk=curstk-@qty where ficode=@ficode and pcode=@PCode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + " end";
                sqlstr = sqlstr + " Fetch Next From delcur into @ficode,@Gcode, @T_Entry, @PCode,@qty" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + "  select @ficode=ficode,@Gcode=gcode,@T_Entry=T_entry,@PCode=pcode,@qty=qty from deleted " + Environment.NewLine;
                sqlstr = sqlstr + "  if (@T_Entry='8O') or (@T_Entry='8G') or (@T_Entry='8S') " + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + "  update iglmst  set curstk=curstk-@qty where ficode=@ficode and pcode=@PCode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " Close delcur" + Environment.NewLine;
                sqlstr = sqlstr + " Deallocate delcur" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " if exists(Select * from inserted where T_Entry in ('8','8O','S','9','C8','C9','CS','8G','8S','9G','9S','8I','8F','9F','8M','9M','8U','9U','8N','9N'))" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " Declare delcur1 Cursor For select FICode,GCODE,T_Entry,PCode,qty from inserted where ItemState<>'" + "DO" + "'" + Environment.NewLine;
                sqlstr = sqlstr + " Open delcur1" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From delcur1 into @ficode,@Gcode, @T_Entry, @PCode,@qty" + Environment.NewLine;
                sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " if (@T_Entry='S') or (@T_Entry='9') or (@T_Entry='CS') or (@T_Entry='C9') or (@T_Entry='9G') or (@T_Entry='9F') or (@T_Entry='9S') or (@T_Entry='9M') or (@T_Entry='9U') or (@T_Entry='9N')" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " update iglmst  set curstk=curstk-@qty where ficode=@ficode and pcode=@PCode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " if (@T_Entry='8') or (@T_Entry='C8') or (@T_Entry='8I') or (@T_Entry='8F') or (@T_Entry='8U') or (@T_Entry='8N')" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " update iglmst  set curstk=curstk+@qty where ficode=@ficode and pcode=@PCode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " if (@T_Entry='8O') or (@T_Entry='8G') or (@T_Entry='8S') or (@T_Entry='8M')" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " update iglmst set curstk=curstk+@qty where ficode=@ficode and pcode=@PCode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From delcur1 into @ficode,@Gcode, @T_Entry, @PCode,@qty" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " Close delcur1" + Environment.NewLine;
                sqlstr = sqlstr + " Deallocate delcur1" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " set NoCount Off" + Environment.NewLine;
                sqlstr = sqlstr + " END" + Environment.NewLine;
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                //Trigger for Inprovment and Discount-------------------
                sqlstr = "CREATE TRIGGER EfectOnEtran ON ExpRev FOR INSERT, UPDATE, DELETE AS BEGIN" + Environment.NewLine;
                sqlstr = sqlstr + "set NoCount On" + Environment.NewLine;
                sqlstr = sqlstr + "declare  @AgainstVoucher numeric,@AgainstTEntry char(2),@AgainstAutoIncre numeric,@AgainstPcode numeric,@AgainstLineItem numeric,@ficode char(10),@Gcode char(10),@Amt money,@TranType char(1),@InterLinkVch numeric,@InterLinkAutoIncre numeric,@LockRow bit,@voucher numeric,@InterLinkVoucher numeric" + Environment.NewLine;
                sqlstr = sqlstr + "if exists(Select *  from Deleted)" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "Declare delcur Cursor For select AgainstVoucher,AgainstTEntry,AgainstAutoIncre,AgainstPcode,AgainstLineItem,ficode,Gcode,Amt,TranType,InterLinkVch ,InterLinkAutoIncre ,LockRow,voucher,InterLinkVoucher from deleted" + Environment.NewLine;
                sqlstr = sqlstr + "Open delcur" + Environment.NewLine;
                sqlstr = sqlstr + "Fetch Next From delcur into  @AgainstVoucher,@AgainstTEntry,@AgainstAutoIncre,@AgainstPcode,@AgainstLineItem,@ficode,@Gcode,@Amt,@TranType,@InterLinkVch,@InterLinkAutoIncre,@LockRow,@voucher,@InterLinkVoucher" + Environment.NewLine;
                sqlstr = sqlstr + "if(@TranType='I')" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "if (@InterLinkAutoIncre=0)" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "update etran set EffectiveAmt=EffectiveAmt-@Amt,lock=0,LinkExpRev=@InterLinkVoucher where T_ENTRY=@AgainstTEntry and VOUCHER=@AgainstVoucher and AUTOINCRE=@AgainstAutoIncre and PCODE=@AgainstPcode and RowIndex=@AgainstLineItem and ficode=@Ficode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "else" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "update etran set EffectiveAmt=EffectiveAmt-@Amt,LinkExpRev=@InterLinkVoucher where T_ENTRY=@AgainstTEntry and VOUCHER=@AgainstVoucher and AUTOINCRE=@AgainstAutoIncre and PCODE=@AgainstPcode and RowIndex=@AgainstLineItem and ficode=@Ficode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "else" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "if (@InterLinkAutoIncre=0)" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "update etran set EffectiveAmt=EffectiveAmt+@Amt,lock=0,LinkExpRev=@InterLinkVoucher where T_ENTRY=@AgainstTEntry and VOUCHER=@AgainstVoucher and AUTOINCRE=@AgainstAutoIncre and PCODE=@AgainstPcode and RowIndex=@AgainstLineItem and ficode=@Ficode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "else" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "update etran set EffectiveAmt=EffectiveAmt+@Amt,LinkExpRev=@InterLinkVoucher where T_ENTRY=@AgainstTEntry and VOUCHER=@AgainstVoucher and AUTOINCRE=@AgainstAutoIncre and PCODE=@AgainstPcode and RowIndex=@AgainstLineItem and ficode=@Ficode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "update ExpRev set LockRow=0  where ficode=@Ficode and gcode=@Gcode and AutoIncre=@InterLinkAutoIncre" + Environment.NewLine;
                sqlstr = sqlstr + "Close delcur" + Environment.NewLine;
                sqlstr = sqlstr + "Deallocate delcur" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "if exists(Select * from inserted )" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "Declare delcur Cursor For select   AgainstVoucher,AgainstTEntry,AgainstAutoIncre,AgainstPcode,AgainstLineItem,ficode,Gcode,Amt,TranType,InterLinkVch,InterLinkAutoIncre ,LockRow,voucher from inserted" + Environment.NewLine;
                sqlstr = sqlstr + "Open delcur" + Environment.NewLine;
                sqlstr = sqlstr + "Fetch Next From delcur into  @AgainstVoucher,@AgainstTEntry,@AgainstAutoIncre,@AgainstPcode,@AgainstLineItem,@ficode,@Gcode,@Amt,@TranType,@InterLinkVch,@InterLinkAutoIncre ,@LockRow,@voucher" + Environment.NewLine;
                sqlstr = sqlstr + "if(@TranType='I')" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "if (@InterLinkAutoIncre=0)" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "update etran set EffectiveAmt=EffectiveAmt+@Amt,lock=1,LinkExpRev=@voucher where T_ENTRY=@AgainstTEntry and VOUCHER=@AgainstVoucher and AUTOINCRE=@AgainstAutoIncre and PCODE=@AgainstPcode and RowIndex=@AgainstLineItem and ficode=@Ficode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "else" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "update etran set EffectiveAmt=EffectiveAmt+@Amt,LinkExpRev=@voucher where T_ENTRY=@AgainstTEntry and VOUCHER=@AgainstVoucher and AUTOINCRE=@AgainstAutoIncre and PCODE=@AgainstPcode and RowIndex=@AgainstLineItem and ficode=@Ficode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "else" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "if (@InterLinkAutoIncre=0)" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "update etran set EffectiveAmt=EffectiveAmt-@Amt,lock=1,LinkExpRev=@voucher where T_ENTRY=@AgainstTEntry and VOUCHER=@AgainstVoucher and AUTOINCRE=@AgainstAutoIncre and PCODE=@AgainstPcode and RowIndex=@AgainstLineItem and ficode=@Ficode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "else" + Environment.NewLine;
                sqlstr = sqlstr + "begin" + Environment.NewLine;
                sqlstr = sqlstr + "update etran set EffectiveAmt=EffectiveAmt-@Amt,LinkExpRev=@voucher where T_ENTRY=@AgainstTEntry and VOUCHER=@AgainstVoucher and AUTOINCRE=@AgainstAutoIncre and PCODE=@AgainstPcode and RowIndex=@AgainstLineItem and ficode=@Ficode and gcode=@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "update ExpRev set LockRow=1 where ficode=@Ficode and gcode=@Gcode  and AutoIncre=@InterLinkAutoIncre" + Environment.NewLine;
                sqlstr = sqlstr + "Close delcur" + Environment.NewLine;
                sqlstr = sqlstr + "Deallocate delcur" + Environment.NewLine;
                sqlstr = sqlstr + "end" + Environment.NewLine;
                sqlstr = sqlstr + "set NoCount Off" + Environment.NewLine;
                sqlstr = sqlstr + "END" + Environment.NewLine;
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                //End Trigger-------------------------------------------
                //for company deletion
                sqlstr = " Create Proc Mid_DELETE_COMPANY @pFICode char(10),@pGCODE char(10)AS BEGIN " + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM Access where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM AccessBranch where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM AddLess where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " DELETE FROM AccPost where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM bill where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                // sqlstr = sqlstr + " DELETE FROM BillTerms where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM Branch where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM Company where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM currency where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM DATA where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM DOCGEN where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM docnumber where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " DELETE FROM DPMAST where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " DELETE FROM ETran where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " DELETE FROM FDInt where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM glmst where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM grp where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM idata where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM Idocmast where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM IDocTran where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM IGLMST where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM  inarr where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM  itran where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM MenuUser where GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM AccordFourlog where  LOG_GCODE=@pGcode and LOG_CCODE=@pFICode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM  narr where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " DELETE FROM  PLTran where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM prtyms where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " DELETE FROM TaxMaster where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM TypeDoc where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM TypeMast where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM vchr where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM WACCOPTN where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM TypeDoc_Config where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM TypeMast_Config where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM AddlessLineItem where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " DELETE FROM Exchng_Mst where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " DELETE FROM Formula_Master where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " DELETE FROM FDInfo where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " DELETE FROM FDInt where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " DELETE FROM ExBrRel where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM AccordFourOPTN where FIcode=@pFICode and GCODE=@pGcode" + Environment.NewLine;
                sqlstr = sqlstr + " EXEC FICODEGENDEL @pFICode=@pficode" + Environment.NewLine;
                sqlstr = sqlstr + " END";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                sqlstr = "Create Proc FICODEGENDEL @pFICode char(10)AS BEGIN" + Environment.NewLine;
                sqlstr = sqlstr + " if not exists(Select * from Company where FIcode=@pFICode)" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM FICODEGEN where FIcode=@pFICode" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " end";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                //-------------------SP--------------------------//
                sqlstr = " create procedure BillTerms_ins " + Environment.NewLine;
                sqlstr = sqlstr + " @pFICode char(10),@pGcode char(10)" + Environment.NewLine;
                sqlstr = sqlstr + " as begin" + Environment.NewLine;
                sqlstr = sqlstr + " if not exists(select * from BillTerms where FIcode=@pFICode and GCODE=@PGcode )" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'S',1,'BASIC','NORMAL',null,'Plus',1,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'S',2,'STT','NORMAL','1','Minus',1,0)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'S',3,'SERVICE TAX','NORMAL','1+2','Minus',1,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'S',4,'TRANSACTION CHARGES','NORMAL','1+2+3','Minus',1,4)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'S',5,'OTHERS CHARGES','NORMAL','1+2+3+4','Minus',1,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'S',6,'TRN.OVER CHARGES','NORMAL','1+2+3+4+5','Minus',1,2)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'S',7,'STAMP CHARGES','NORMAL','1+2+3+4+5+6','Minus',1,3)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'S',8,'Edu. CESS','NORMAL','1+2+3+4+5+6+7','Minus',1,5)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'S',9,'Higher Edu. CESS','NORMAL','1+2+3+4+5+6+7+8','Minus',1,6)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'P',1,'BASIC','NORMAL',null,'Plus',1,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'P',2,'STT','NORMAL','1','Plus',1,0)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'P',3,'SERVICE TAX','NORMAL','1+2','Plus',1,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'P',4,'TRANSACTION CHARGES','NORMAL','1+2+3','Plus',1,4)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'P',5,'OTHERS CHARGES','NORMAL','1+2+3+4','Plus',1,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'P',6,'TRN.OVER CHARGES','NORMAL','1+2+3+4+5','Plus',1,2)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'P',7,'STAMP CHARGES','NORMAL','1+2+3+4+5+6','Plus',1,3)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'P',8,'Edu. CESS','NORMAL','1+2+3+4+5+6+7','Plus',1,5)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into BillTerms values(@pFICode,@pGcode,'P',9,'Higher Edu. CESS','NORMAL','1+2+3+4+5+6+7+8','Plus',1,6)" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                //----------------SP--------------------------//
                sqlstr = " create proc currency_ins @pFICode char(10),@pGcode char(10) as begin" + Environment.NewLine;
                sqlstr = sqlstr + " if not exists(select * from currency where FIcode=@pFICode and GCODE=@PGcode)" + Environment.NewLine;
                sqlstr = sqlstr + "  insert into currency values(@pFICode,@pGcode,'1','Indian Rupee','Rs.','Paisa',null,null,1,null,null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                //---------------SP--------------------------//

                sqlstr = "CREATE proc InvMst_ins @pFICode char(10) as begin " + Environment.NewLine;
                sqlstr = sqlstr + " if exists(select * from InvMst where Ficode=@pFicode)" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " declare @Ficode char(10), @Itype char(10),@Icode numeric,@Idesc varchar(50),@Iparent numeric,@IAlias varchar(50),@invs_ac int," + Environment.NewLine;
                sqlstr = sqlstr + " @ltcg_ac int,@ltcl_ac int,@stcg_ac int,@stcl_ac int,@prch_ac int,@sls_ac int,@stck_ac int" + Environment.NewLine;
                sqlstr = sqlstr + " Declare Cursor2 Cursor For" + Environment.NewLine;
                sqlstr = sqlstr + " SELECT DISTINCT FICode FROM InvMst" + Environment.NewLine;
                sqlstr = sqlstr + " Open Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From Cursor2  into @Ficode" + Environment.NewLine;
                sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " if not exists (SELECT * FROM  InvMst WHERE   (Idesc IN ('FOREX', 'Bullion', 'Insurence ')) AND (FICode = @Ficode))" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@FICode,'I',8,'Forex',0,null,null,null,null,null,null,null,null,null,null,null) " + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@FICode,'I',9,'Bullion',0,null,null,null,null,null,null,null,null,null,null,null) " + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@FICode,'I',10,'Insurence',0,null,null,null,null,null,null,null,null,null,'''I'',''8O''','''I''') " + Environment.NewLine;
                sqlstr = sqlstr + " END" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From Cursor2  into @Ficode" + Environment.NewLine;
                sqlstr = sqlstr + " End" + Environment.NewLine;
                sqlstr = sqlstr + " CLOSE Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " DEALLOCATE Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " END" + Environment.NewLine;
                sqlstr = sqlstr + " else" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'I',1,'Equity Listed',0,null,null,null,null,null,null,null,null,null,'''8'',''8S'',''C'',''8G'',''8O''','''9'',''9S'',''C'',''9G'',''S''')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'I',2,'Equity Unlisted',0,null,null,null,null,null,null,null,null,null,'''8'',''8S'',''C'',''8G'',''8O''','''9'',''9S'',''C'',''9G'',''S''')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'I',3,'Debentures',0,null,null,null,null,null,null,null,null,null,'''8'',''8S'',''C'',''8G'',''8O''','''9'',''9S'',''C'',''9G'',''S''') " + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'I',4,'Derivatives(Futures & Options)',0,null,null,null,null,null,null,null,null,null,null,null) " + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'I',7,'Bonds',0,null,null,null,null,null,null,null,null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'I',5,'Fixed Deposits',0,null,null,null,null,null,null,null,null,null,'''8F'',''8O''',null) " + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'I',6,'Mutual Funds',0,null,null,null,null,null,null,null,null,null,'''U'',''8O''','''U''') " + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'I',8,'T-Bills/Govt.Security',0,null,null,null,null,null,null,null,null,null,null,null) " + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'I',9,'Commodities',0,null,null,null,null,null,null,null,null,null,'''M'',''8O''','''M''') " + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'I',10,'Bullion',0,null,null,null,null,null,null,null,null,null,null,null) " + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'I',11,'Insurance',0,null,null,null,null,null,null,null,null,null,'''I'',''8O''','''I''')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'I',12,'Properties-immovable',0,null,null,null,null,null,null,null,null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'C',13,'Traditional',11,null,null,null,null,null,null,null,null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'C',14,'ULIP',11,null,null,null,null,null,null,null,null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into InvMst values(@pFICode,'C',15,'Single Premium Plan',11,null,null,null,null,null,null,null,null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " end";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                //----------------SP------------------------//
                sqlstr = " create proc TaxMaster_ins @pFICode char(10),@pGcode char(10) as begin" + Environment.NewLine;
                sqlstr = sqlstr + " if not exists(select * from TaxMaster where FIcode=@pFICode and GCODE=@PGcode)" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'NORMAL',1,0,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'EXCISE/CENVAT',2,0,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'CESS',3,1,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'SALES TAX',4,1,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'VAT 4%',5,1,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'VAT 12.5%',6,1,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'VAT 8%',7,1,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'VAT 0%',8,1,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'VAT 1%',9,1,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'FREIGHT PLUS',10,0,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'FREIGHT MINUS',11,0,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'ROUND OFF PLUS',12,0,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'ROUND OFF MINUS',13,0,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'CASH DISCOUNT',14,0,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'SPL DISCOUNT',15,0,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'SERVICE TAX',16,1,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'CESS ON SERVICE',17,1,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'STT',18,1,1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TaxMaster values(@pFICode,@pGcode,'BROKERAGE',19,0,1)" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " end";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                //---------------SP---------------------------//

                sqlstr = " create proc TypeMast_ins @pFICode char(10),@pGcode char(10) as begin" + Environment.NewLine;
                sqlstr = sqlstr + " if  exists(select * from TypeMast where FIcode=@pFICode and GCODE=@PGcode)" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " declare @Ficode char(10),@Gcode char(10)" + Environment.NewLine;
                sqlstr = sqlstr + " Declare Cursor2 Cursor For  SELECT DISTINCT FICode,Gcode FROM TypeMast" + Environment.NewLine;
                sqlstr = sqlstr + " Open Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From Cursor2  into @Ficode,@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'8G','GiftIn','GftIn')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'9G','GiftOut','GftOut') " + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'8S','StockIn','StckIn') " + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'9S','StockOut','StckOut')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'N','Conversion','Cnvsn')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'DE','Dividend Entry','Div')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'8B','Bonus Entry','BE')" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From Cursor2  into @Ficode,@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + " End" + Environment.NewLine;
                sqlstr = sqlstr + " CLOSE Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " DEALLOCATE Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " END" + Environment.NewLine;
                sqlstr = sqlstr + " else" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'1','Receipt','Rcpt')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'2','Payment','Pymt')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'3','Journal ','Jrnl')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'4','Credit Note','Crnt')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'5','Contra','Cntra')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'6','Cheque Return','Chqrtrn')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'7','Debit Note','Dbnt')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8','Market Purchase','MP')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9','Sale','Sale')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8O','Opening','Opng')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'S','Short Sale','Shrtsle')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AA','Applied For','Appf')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AB','Allotment','Altmnt')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AC','Refund','Refnd')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'C','Composite Transaction','Cmpt')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8G','GiftIn','GftIn')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9G','GiftOut','GftOut')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8S','StockIn','StckIn')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9S','StockOut','StckOut')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'N','Conversion','Cnvsn')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'I','Insurance','Insu')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8F','Fixed Deposit','FD')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9F','Fixed Deposite Redeem','FDR')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'M','Commodities','Comm')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'U','Mutual Funds','MF')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'DE','Dividend Entry','Div')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8B','Bonus Entry','BE')" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " end";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }

                sqlstr = " Create Proc DELETE_Branch @pBrnchCODE char(10),@pGCODE char(10)AS BEGIN " + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM ACCESSBRANCH where brnch_code=@pGCODE and brnch_code=@pBrnchCODE" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM branch where GCODE=@pGCODE and brnch_code=@pBrnchCODE" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM Idocmast where GCODE=@pGCODE and brnch_code=@pBrnchCODE" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM VCHR where GCODE=@pGCODE and brnch_code=@pBrnchCODE" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM VCHLOCK where GCODE=@pGCODE and brnch_code=@pBrnchCODE" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM DATA where GCODE=@pGCODE and brnch_code=@pBrnchCODE" + Environment.NewLine;
                sqlstr = sqlstr + " END";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                sqlstr = "CREATE PROCEDURE DeleteVoucher @ficode char(10),@gcode char(10),@tentry char(2),@vou numeric,@chkbit numeric  AS " + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " if (@chkbit=1)" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " delete from idoctran where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " delete from idocmast where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " delete from idata where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " delete from etran where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " delete from inarr where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " delete from itran where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " else if (@chkbit=2)" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " delete from idata where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " delete from etran where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " delete from inarr where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " delete from itran where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " delete from EffectTran where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " exec DeleteDataVChr @ficode=@ficode,@gcode=@gcode,@tentry=@tentry,@vou=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;

                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                sqlstr = " CREATE PROCEDURE DeleteDataVChr @ficode char(10),@gcode char(10),@tentry char(2),@vou numeric  AS " + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " delete from data where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " delete from vchr where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " delete from AddLess where FICode=@ficode and GCODE=@gcode and T_ENTRY=@tentry and VOUCHER=@vou" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;

                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                //-----------------------------SP----------------------------//
                sqlstr = "CREATE PROCEDURE COPY_ACC @DestFicode Char(10),@DestGcode Char(10),@SourceFicode char(10),@SourceGcode char(10)" + Environment.NewLine;
                sqlstr = sqlstr + " AS BEGIN " + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM GRP WHERE Ficode=@DestFicode and GCODE = @DestGcode " + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO GRP (Ficode,GCODE,MGROUP,SGROUP,SDESC," + Environment.NewLine;
                sqlstr = sqlstr + " GALIAS,T_FILTER,CURBAL,LBAL,ACCTYPE," + Environment.NewLine;
                sqlstr = sqlstr + " CONS_FLG,PDF_TYPE,PDF_CODE,ACTV_FLG," + Environment.NewLine;
                sqlstr = sqlstr + " EXDIFF_VAL,OP_LBAL,SCHD_NO)" + Environment.NewLine;
                sqlstr = sqlstr + " SELECT @DestFicode,@DestGcode,MGROUP,SGROUP,SDESC," + Environment.NewLine;
                sqlstr = sqlstr + " GALIAS,T_FILTER,CURBAL,LBAL,ACCTYPE,CONS_FLG," + Environment.NewLine;
                sqlstr = sqlstr + " PDF_TYPE,PDF_CODE,ACTV_FLG,EXDIFF_VAL,OP_LBAL,SCHD_NO FROM GRP" + Environment.NewLine;
                sqlstr = sqlstr + " WHERE Ficode=@SourceFicode and GCODE = @SourceGcode" + Environment.NewLine;
                sqlstr = sqlstr + " UPDATE GRP SET CURBAL =0,LBAL=0,OP_LBAL=0 WHERE Ficode = @DestFicode and GCODE = @DestGcode" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM GLMST WHERE Ficode= @DestFicode and GCODE = @DestGcode" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO GLMST (Ficode,GCODE,MTYPE,MGROUP," + Environment.NewLine;
                sqlstr = sqlstr + " SGROUP, GLCODE,LDESC,LALIAS,T_FILTER," + Environment.NewLine;
                sqlstr = sqlstr + " OPBAL, CURBAL, LBAL, SGRP_LEV, PREV_GROUP," + Environment.NewLine;
                sqlstr = sqlstr + " ALOC_CODE, CONS_FLG, PDF_TYPE, PDF_CODE," + Environment.NewLine;
                sqlstr = sqlstr + " NBAL_FLG, UNB_GROUP, UNB_SGROUP, ACTV_FLG," + Environment.NewLine;
                sqlstr = sqlstr + " CURR_CODE, NCONV_FCTR, DCONV_FCTR, TRANS_CLOS," + Environment.NewLine;
                sqlstr = sqlstr + " EXCHG_DIFF, FC_CURBAL, BOOL_CODE, FC_OPBAL," + Environment.NewLine;
                sqlstr = sqlstr + " FC_LBAL, EXDIFF_VAL,OP_LBAL, FC_OPLBAL,SCHD_NO,CFLOW_GROUP," + Environment.NewLine;
                sqlstr = sqlstr + " MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK)" + Environment.NewLine;
                sqlstr = sqlstr + " SELECT @DestFicode,@DestGcode,MTYPE, MGROUP, SGROUP," + Environment.NewLine;
                sqlstr = sqlstr + " GLCODE, LDESC, LALIAS, T_FILTER,OPBAL, CURBAL, LBAL," + Environment.NewLine;
                sqlstr = sqlstr + " SGRP_LEV, PREV_GROUP, ALOC_CODE, CONS_FLG," + Environment.NewLine;
                sqlstr = sqlstr + " PDF_TYPE, PDF_CODE, NBAL_FLG, UNB_GROUP," + Environment.NewLine;
                sqlstr = sqlstr + " UNB_SGROUP, ACTV_FLG, CURR_CODE, NCONV_FCTR," + Environment.NewLine;
                sqlstr = sqlstr + " DCONV_FCTR, TRANS_CLOS, EXCHG_DIFF, FC_CURBAL," + Environment.NewLine;
                sqlstr = sqlstr + " BOOL_CODE, FC_OPBAL, FC_LBAL, EXDIFF_VAL,OP_LBAL, FC_OPLBAL, SCHD_NO,CFLOW_GROUP," + Environment.NewLine;
                sqlstr = sqlstr + " MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK" + Environment.NewLine;
                sqlstr = sqlstr + " FROM GLMST WHERE Ficode=@SourceFicode and GCODE = @SourceGcode" + Environment.NewLine;
                sqlstr = sqlstr + " UPDATE GLMST SET CURBAL =0 WHERE Ficode = @DestFicode and GCODE = @DestGcode" + Environment.NewLine;
                sqlstr = sqlstr + " END" + Environment.NewLine;
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                sqlstr = "CREATE PROCEDURE INVMST_COPY @DestFicode Char(10),@DestGcode Char(10),@SourceFicode char(10),@SourceGcode char(10)" + Environment.NewLine;
                sqlstr = sqlstr + " AS BEGIN" + Environment.NewLine;
                sqlstr = sqlstr + " if(@DestFicode<>@SourceFicode)" + Environment.NewLine;
                sqlstr = sqlstr + " BEGIN" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM InvMst WHERE Ficode=@DestFicode" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO InvMst (Ficode,Itype,Icode,Idesc,Iparent,IAlias,invs_ac," + Environment.NewLine;
                sqlstr = sqlstr + " ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac,T_entryIn,T_entryOut)" + Environment.NewLine;
                sqlstr = sqlstr + " SELECT @DestFicode,Itype,Icode,Idesc,Iparent,IAlias,invs_ac," + Environment.NewLine;
                sqlstr = sqlstr + " ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac,T_entryIn,T_entryOut FROM InvMst" + Environment.NewLine;
                sqlstr = sqlstr + " WHERE Ficode=@SourceFicode" + Environment.NewLine;
                sqlstr = sqlstr + " declare @pDestGcode char(10)" + Environment.NewLine;
                sqlstr = sqlstr + " Declare Cursor2 Cursor For" + Environment.NewLine;
                sqlstr = sqlstr + " SELECT DISTINCT GCODE FROM  COMPANY WHERE FICODE=@DestFicode" + Environment.NewLine;
                sqlstr = sqlstr + " Open Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From Cursor2  into @pDestGcode" + Environment.NewLine;
                sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " DELETE FROM IGLMST WHERE Ficode= @DestFicode and GCODE = @pDestGcode" + Environment.NewLine;
                sqlstr = sqlstr + " INSERT INTO IGLMST (Ficode,PCODE,GCODE,CO_NAME,CO_ALIAS,INV_TYPECODE,CLASSCODE,FACE_VALUE,BUS_TYPE,OPSTK," + Environment.NewLine;
                sqlstr = sqlstr + " CURSTK,ISIN_NO,Applied_Stat,invs_ac,ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac)" + Environment.NewLine;
                sqlstr = sqlstr + " SELECT @DestFicode,PCODE,@pDestGcode,CO_NAME,CO_ALIAS,INV_TYPECODE,CLASSCODE,FACE_VALUE,BUS_TYPE,0," + Environment.NewLine;
                sqlstr = sqlstr + " 0,ISIN_NO,Applied_Stat,invs_ac,ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac" + Environment.NewLine;
                sqlstr = sqlstr + " FROM IGLMST WHERE Ficode=@SourceFicode  AND GCODE=@SourceGcode" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From Cursor2  into @pDestGcode" + Environment.NewLine;
                sqlstr = sqlstr + " End" + Environment.NewLine;
                sqlstr = sqlstr + " CLOSE Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " DEALLOCATE Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " END" + Environment.NewLine;
                sqlstr = sqlstr + " END" + Environment.NewLine;
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                sqlstr = " create proc CNFGMST_ins  as begin" + Environment.NewLine;
                sqlstr = sqlstr + " if not exists(select * from CNFGMST)" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('G','C','0000','01000000000000000000','Accounts Details','0',0,'1',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','01010000000000000000','User Defined Subgroups','01000000000000000000',0,'1.1',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','01020000000000000000','Ledger Accounts','01000000000000000000',0,'1.2',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','01020100000000000000','Alias Name','01020000000000000000',0,'1.2.1',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','01020200000000000000','Account Merging','01020000000000000000',0,'1.2.2',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','01020300000000000000','Update Party Balance for Op. Documents','01020000000000000000',0,'1.2.3',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','01020400000000000000','Maintain Unnatural Balance Group','01020000000000000000',0,'1.2.4',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','01020500000000000000','Warn Negative Cash Balance','01020000000000000000',0,'1.2.5',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','01020600000000000000','Ledger A/c save without Code','01020000000000000000',0,'1.2.6',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','01030000000000000000','Vouchers','01000000000000000000',0,'1.3',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','01040000000000000000','BRS Details','01000000000000000000',0,'1.4',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','01050000000000000000','Document Numbering','01000000000000000000',0,'1.5',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','01060000000000000000','TDS','01000000000000000000',0,'1.6',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02000000000000000000','Investment Details','0',0,'2',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02010000000000000000','Equity Listed','02000000000000000000',0,'2.1',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02020000000000000000','Equity Unlisted','02000000000000000000',0,'2.2',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02030000000000000000','Debentures','02000000000000000000',0,'2.3',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02040000000000000000','Derivatives(Futures & Options)','02000000000000000000',0,'2.4',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02050000000000000000','Fixed Deposits','02000000000000000000',0,'2.5',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02060000000000000000','Mutual Funds','02000000000000000000',0,'2.6',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02070000000000000000','Bonds','02000000000000000000',0,'2.7',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02080000000000000000','T-Bills/Govt.Security','02000000000000000000',0,'2.8',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02090000000000000000','Commodities','02000000000000000000',0,'2.9',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02100000000000000000','Bullion','02000000000000000000',0,'2.10',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02110000000000000000','Insurance','02000000000000000000',0,'2.11',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02120000000000000000','Properties-immovable','02000000000000000000',0,'2.12',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','03000000000000000000','Printing Details','0',0,'3',1,'S',null,null,null,null)" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                sqlstr = " create proc userfrml_ins @pFICode char(10),@pGcode char(10) as begin" + Environment.NewLine;
                sqlstr = sqlstr + " if not exists(select * from UserFormulaMaster where FIcode=@pFICode and GCODE=@PGcode)" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " insert into UserFormulaMaster(FICODE,GCODE,description,Dcode) values(@pFICode,@pGcode,'NetAmount',0)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into UserFormulaMaster(FICODE,GCODE,description,Dcode) values(@pFICode,@pGcode,'AmountWithBrokerage',1)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into UserFormulaMaster(FICODE,GCODE,description,Dcode) values(@pFICode,@pGcode,'AmountLessBrokerage',2)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into UserFormulaMaster(FICODE,GCODE,description,Dcode) values(@pFICode,@pGcode,'BrokerageAmount',3)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into UserFormulaMaster(FICODE,GCODE,description,Dcode) values(@pFICode,@pGcode,'TrnOverCharges',4)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into UserFormulaMaster(FICODE,GCODE,description,Dcode) values(@pFICode,@pGcode,'BrokerageAndTrnOverCharges',5)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into UserFormulaMaster(FICODE,GCODE,description,Dcode) values(@pFICode,@pGcode,'None',6)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into UserFormulaMaster(FICODE,GCODE,description,Dcode) values(@pFICode,@pGcode,'ServiceTax',7)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into UserFormulaMaster(FICODE,GCODE,description,Dcode) values(@pFICode,@pGcode,'EduCess',8)" + Environment.NewLine;
                sqlstr = sqlstr + " insert into UserFormulaMaster(FICODE,GCODE,description,Dcode) values(@pFICode,@pGcode,'BrokerageAndTran.Charges',9)" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                //sqlstr = "CREATE PROCEDURE COPY_BRKS @DestFicode Char(10),@DestGcode Char(10),@SourceFicode char(10),@SourceGcode char(10)" + Environment.NewLine;
                //sqlstr = sqlstr + " AS BEGIN" + Environment.NewLine;
                //sqlstr = sqlstr + " execute COPY_ACC @DestFicode,@DestGcode,@SourceFicode,@SourceGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " DELETE FROM Formula_Master  WHERE Ficode=@DestFicode and GCODE = @DestGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " INSERT INTO Formula_Master( FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode)SELECT @DestFicode,@DestGcode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode FROM Formula_Master WHERE Ficode=@SourceFicode and GCODE = @SourceGcode" + Environment.NewLine;
                //sqlstr = sqlstr + " END";
                //cmd = new SqlCommand(sqlstr, con);
                //try
                //{
                //    cmd.ExecuteNonQuery();
                //}
                //catch { }
                return true;
            }
            catch
            {
                return false;
            }
        }
      


        public bool creatTrigger_session(SqlConnection con)
        {
            string qry = " Create TRIGGER [TrigCompInsertSetting] on [Company] For insert as set nocount on " +
           " Declare @gcode Char(10),@ficode varchar(10) select @gcode=gcode,@ficode=ficode from inserted " +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1000000000','1.0.0','General',NULL,NULL,'True',0,0,'0','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1010000000','1.1','Company Details',NULL,NULL,'True',0,0,'1000000000','False') " +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1010100000','1.1.1','Account Details',NULL,null,'True',0,0,'1010000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1010200000','1.1.2','Inventory Details',NULL,null,'True',0,0,'1010000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1010300000','1.1.3','Vector Details',NULL,null,'True',0,0,'1010000000','False') " +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1010400000','1.1.4','Multiple Currency',NULL,null,'True',0,0,'1010000000','False') " +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1010500000','1.1.5','Multiple Branch',NULL,null,'True',0,0,'1010000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1010600000','1.1.6','Custom Field',NULL,null,'True',0,0,'1010000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1010700000','1.1.7','Statutory VAT',NULL,null,'True',0,0,'1010000000','False')" +


           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1020000000','1.2','Default Currency',NULL,NULL,'True',0,0,'1000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1020100000','1.2.1','Currency Description','Indian Rupee',null,'True',0,0,'1020000000','False') " +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1020200000','1.2.2','Currency String','Rs.',null,'True',0,0,'1020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1020300000','1.2.3','Currency Sub string','Paisa',null,'True',0,0,'1020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1020400000','1.2.4','Currency Decimal','2',null,'True',0,0,'1020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1030000000','1.3','Currency Setting',NULL,NULL,'True',0,0,'1000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1030100000','1.3.1','Default Format','X1',null,'True',0,0,'1030000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1030200000','1.3.2','Negative Format','(X1.1)',null,'True',0,0,'1030000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1030300000','1.3.3','Thousand Separator',null,null,'True',0,0,'1030000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,1,'1030400000','1.3.4','Decimal Separator',null,null,'True',0,0,'1030000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2000000000','2.0','Account',NULL,NULL,'True',0,0,'0','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2010000000','2.1','User Define Subgroup',NULL,NULL,'True',0,0,'2000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2010200000','2.1.1','Allocation to Vector',NULL,NULL,'True',0,0,'2010000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2020000000','2.2','Ledger  Account',NULL,null,'True',0,0,'2000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2020100000','2.2.1','Alias Name',NULL,null,'True',0,0,'2020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2020101000','2.2.1.1','Select Ledger Account Through Alias',NULL,null,'True',0,0,'2020100000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2020200000','2.2.2','Merging Account',NULL,null,'True',0,0,'2020000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2020300000','2.2.3','Update Party Balance for Opening Document',NULL,null,'True',0,0,'2020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2030000000','2.3','Budget  Details',NULL,null,'True',0,0,'2000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2040000000','2.4','Voucher Details',NULL,null,'True',0,0,'2000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2040100000','2.4.1','Accept Opening Documentss',NULL,null,'True',0,0,'2040000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2040200000','2.4.2','Key-in Account Description',NULL,null,'True',0,0,'2040000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2040300000','2.4.3','Narration',NULL,null,'True',0,0,'2040000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2040301000','2.4.3.1','Multiple Ledger Narration',NULL,null,'True',0,0,'2040300000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2040302000','2.4.3.2','Formatted Ledger Naration',NULL,null,'True',0,0,'2040300000','False')" +


           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2040400000','2.4.4','Online Bill Adjustment',NULL,null,'True',0,0,'2040000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2040500000','2.4.5','Store Image for Document',NULL,null,'True',0,0,'2040000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2040600000','2.4.6','Show Ledger A/C Current Balance',NULL,null,'True',0,0,'2040000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2040700000','2.4.7','Accept Memo Voucher',NULL,null,'True',0,0,'2040000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2040701000','2.4.7.1','Memo Register at Startup',NULL,null,'True',0,0,'2040700000','False')" +          
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2040800000','2.4.8','Activate Cheque Return Voucher',NULL,null,'True',0,0,'2040000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2050000000','2.5','BRS Details',NULL,null,'True',0,0,'2000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,2,'2060000000','2.6','Auto Popup Custom Field',NULL, null,'True',0,0,'2000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3000000000','3.0.0','Inventory',NULL,NULL,'True',0,0,'0','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3010000000','3.1','Item Master',NULL,NULL,'True',0,0,'3000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3010100000','3.1.1','Batch & Serial No. Details',NULL,NULL,'True',0,0,'3010000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3010200000','3.1.2','Compound Multiple Unit',NULL,null,'True',0,0,'3010000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3010300000','3.1.3','Packing Details',NULL,null,'True',0,0,'3010000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3010400000','3.1.4','Reporting Unit',NULL,null,'True',0,0,'3010000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3010500000','3.1.5','Select Service Item for Reports',NULL,null,'True',0,0,'3010000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3010600000','3.1.6','Select Item thtough Alias',NULL,null,'True',0,0,'3010000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3010700000','3.1.7','Auto Generated Item Alias',NULL,null,'True',0,0,'3010000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3010800000','3.1.8','VAT Calculated on MRP',NULL,null,'False',0,0,'3010000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3010900000','3.1.9','Free Quantity',NULL,null,'False',0,0,'3010000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3011000000','3.1.10','Discount Amount',NULL,null,'False',0,0,'3010000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3011100000','3.1.11','Parallal Multiple Unit',NULL,null,'False',0,0,'3010000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3020000000','3.2','Item Group',NULL,NULL,'True',0,0,'3000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3020100000','3.2.1','Online Item Grouping ',NULL,NULL,'True',0,0,'3020000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3030000000','3.3','Location Details',NULL,null,'True',0,0,'3000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3030100000','3.3.1','Itemwise Location',NULL,null,'True',0,0,'3030000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040000000','3.4','Transaction',NULL,null,'True',0,0,'3000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040100000','3.4.1','Accepts Opening Documents',NULL,null,'True',0,0,'3040000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040200000','3.4.2','Apply Discount Scheme',NULL,null,'True',0,0,'3040000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040201000','3.4.2.1','Update Discount Rate Automatically ',NULL,null,'True',0,0,'3040200000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040300000','3.4.3','Apply Price List',NULL,null,'True',0,0,'3040000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040301000','3.4.3.1','Lock Rates in Transaction',NULL,null,'True',0,0,'3040300000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040302000','3.4.3.2','Update Rate(Non Zero) from Amount',NULL,null,'True',0,0,'3040300000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040400000','3.4.4','Apply Tax/VAT Scheme',NULL,null,'True',0,0,'3040000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040401000','3.4.4.1','Update VAT/Tax Rate Automatically',NULL,null,'True',0,0,'3040400000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040500000','3.4.5','Key-in Item Description',NULL,null,'True',0,0,'3040000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040600000','3.4.6','Manufacturing Details',NULL,null,'True',0,0,'3040000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040601000','3.4.6.1','Apply Fixed cost in FG Receipt',NULL,null,'True',0,0,'3040600000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040602000','3.4.6.2','Production Formula',NULL,null,'True',0,0,'3040600000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040603000','3.4.6.3','Apply Material Costing for issue',NULL,null,'True',0,0,'3040600000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040604000','3.4.6.4','Apply Production Vector',NULL,null,'True',0,0,'3040600000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040604010','3.4.6.4.1','Apply Zero Validation Check',NULL,null,'True',0,0,'3040604000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040606000','3.4.6.5','Activate Production Log No',NULL,null,'True',0,0,'3040600000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040607000','3.4.6.6','Activate Production Log No-Raw Mat Vs Fin Goods',NULL,null,'True',0,0,'3040600000','False')" +
           
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040700000','3.4.7','Narration Details',NULL,null,'True',0,0,'3040000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040800000','3.4.8','Trading Details (Sales)',NULL,null,'True',0,0,'3040000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040801000','3.4.8.1','Accept Broker Details(S)',NULL,null,'True',0,0,'3040800000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040802000','3.4.8.2','Activate Way Bill Details(S)',NULL,null,'True',0,0,'3040800000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040803000','3.4.8.3','Calculated VAT on Discounted Price(S)',NULL,null,'True',0,0,'3040800000',null)" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040804000','3.4.8.4','Multiple Sales/Purchase A/C(S)',NULL,null,'True',0,0,'3040800000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040805000','3.4.8.5','Order Details(S)',NULL,null,'False',0,0,'3040800000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040806000','3.4.8.6','Segregate Debtor Creditor(S)',NULL,null,'True',0,0,'3040800000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040807000','3.4.8.7','Accept Form Details(S)',NULL,null,'True',0,0,'3040800000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040808000','3.4.8.8','Item on Sales/Purchase(S)',NULL,null,'True',0,0,'3040800000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040809000','3.4.8.9','Bill on Cash Payment',NULL,null,'False',0,0,'3040800000','False')" +
                     
           //===================================pp           

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040900000','3.4.9','Trading Details (Purchase)',NULL,null,'True',0,0,'3040000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040901000','3.4.9.1','Accept Broker Details(P)',NULL,null,'True',0,0,'3040900000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040902000','3.4.9.2','Activate Way Bill Details(P)',NULL,null,'True',0,0,'3040900000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040903000','3.4.9.3','Calculated VAT on Discounted Price(P)',NULL,null,'True',0,0,'3040900000',null)" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040904000','3.4.9.4','Multiple Sales/Purchase A/C(P)',NULL,null,'True',0,0,'3040900000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040905000','3.4.9.5','Order Details(P)',NULL,null,'True',0,0,'3040900000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040906000','3.4.9.6','Segregate Debtor Creditor(P)',NULL,null,'True',0,0,'3040900000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040907000','3.4.9.7','Accept Form Details(P)',NULL,null,'True',0,0,'3040900000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3040908000','3.4.9.8','Item on Sales/Purchase(P)',NULL,null,'True',0,0,'3040900000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3041000000','3.4.10','Lock Add/Less Values',NULL,null,'True',0,0,'3040000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3041100000','3.4.11','Store image of document',NULL,null,'True',0,0,'3040000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3041200000','3.4.12','Appropriation',NULL,null,'True',0,0,'3040000000','False')" +           
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3041300000','3.4.13','Apply Nature of Product Scheme',NULL,null,'True',0,0,'3040000000','False')" +
           //==================================end

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3050000000','3.5','Auto Valuation of Stock',NULL,null,'True',0,0,'3000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3060000000','3.6','Auto Popup Custom Fields',NULL,null,'True',0,0,'3000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3070000000','3.7','Active Template',NULL,null,'True',0,0,'3000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3080000000','3.8','Line Tax/Discount',NULL,null,'True',0,0,'3000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3080100000','3.8.1','Line Tax Calculate On Quantity',NULL,null,'True',0,0,'3080000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3080200000','3.8.2','Line Tax Calculate Inclusive',NULL,null,'True',0,0,'3080000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3080300000','3.8.3','Effect Ledger With Predefine Tax',NULL,null,'True',0,0,'3080000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3080400000','3.8.4','Line Discount Calculate On Quantity',NULL,null,'True',0,0,'3080000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3080500000','3.8.5','Line Discount Calculate Inclusive',NULL,null,'True',0,0,'3080000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3080600000','3.8.6','Line Tax Calculation ',NULL,null,'True',0,0,'3080000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3080601000','3.8.6.1','Calculate Tax Before Discount',NULL,null,'True',0,0,'3080600000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3080602000','3.8.6.2','Calculate Tax on Original Amount',NULL,null,'True',0,0,'3080600000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3080700000','3.8.7','Line Discount Calculation Only',NULL,null,'True',0,0,'3080000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3080800000','3.8.8','Suppress Line-Item Tax Discount Popup Window',NULL,null,'True',0,0,'3080000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3090000000','3.9','Multiple Grouping of Items',NULL,null,'True',0,0,'3000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3100000000','3.10','Publishing',NULL,null,'False',0,0,'3000000000','False')" +


           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3100100000','3.10.1','Printing House',NULL,null,'False',0,0,'3100000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3100101000','3.10.1.1','Rules for Invoice',NULL,null,'False',0,0,'3100100000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3100200000','3.10.2','Dyeing',NULL,null,'False',0,0,'3100000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3100300000','3.10.3','M.Raj',NULL,null,'False',0,0,'3100000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,3,'3100400000','3.10.4','Brand Allonce',NULL,null,'False',0,0,'3100000000','False')" +


           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4000000000','4.0.0','Pinting',NULL,NULL,'True',0,0,'0','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4010000000','4.1','Details Report Heading',NULL,NULL,'True',0,0,'4000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4020000000','4.2','On-line Document Printing',NULL,NULL,'True',0,0,'4000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4020100000','4.2.1','Print Tax Invoice by Default',NULL,null,'True',0,0,'4020000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4030000000','4.3','Grayed Column Heading',NULL,null,'True',0,0,'4000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4040000000','4.4','Horizontal Line in Report',NULL,null,'True',0,0,'4000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4050000000','4.5','Custom Format report',NULL,null,'True',0,0,'4000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4050100000','4.5.1','Custom Print Format Files',NULL,null,'True',0,0,'4050000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4060000000','4.6','Confirm Custom Print Data File',NULL,null,'True',0,0,'4000000000','False')" +


           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4070000000','4.7','Amount in Words in Lac/Core',NULL,NULL,'True',0,0,'4000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4080000000','4.8','Print as on date and time Advance',NULL,NULL,'True',0,0,'4000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4090000000','4.9','DOS Mode Printing',NULL,null,'True',0,0,'4000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4090100000','4.9.1','Printer Type',NULL,null,'True',0,0,'4090000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4090200000','4.9.2','Orientation (Portrait/Landscape)',NULL,null,'True',0,0,'4090000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4090300000','4.9.3','Lines per page','0',null,'True',0,0,'4090000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4090400000','4.9.4','Eject After Finish',NULL,null,'True',0,0,'4090000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4090500000','4.9.5','Lines Feed',NULL,null,'True',0,0,'4090000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4090600000','4.9.6','Printing each Ledger in saparate page ',NULL,null,'True',0,0,'4090000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4090700000','4.9.7','Customised Dos Mode Printing ',NULL,null,'True',0,0,'4090000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4090800000','4.9.8','Sidewise Details in Tax Invoice ',NULL,null,'True',0,0,'4090000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4090900000','4.9.9','Customised Dos Mode Invoice Printing',NULL,null,'True',0,0,'4090000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4090901000','4.9.9.1','DEFAULT',NULL,null,'True',0,0,'4090900000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4090902000','4.9.9.2','DRAKT',NULL,null,'True',0,0,'4090900000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4091000000','4.9.10','Parallel Unit Printing for Invoice',NULL,null,'True',0,0,'4090000000','False')" +



           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4100000000','4.10','Header & Footer',NULL,null,'True',0,0,'4000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4100100000','4.10.1','Additional Header & Footer details for normal Invoice & Tax Invoice',NULL,null,'True',0,0,'4100000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4100200000','4.10.2','Additional Header & Footer details  for Vouchers ',NULL,null,'True',0,0,'4100000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4110000000','4.11','Report Levels ',NULL,null,'True',0,0,'4000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4110100000','4.11.1','User Defined Report levels for Invoice',NULL,null,'True',0,0,'4110000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4110200000','4.11.2','User Defined Report Title  for Tax Invoice ',NULL,null,'True',0,0,'4110000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4110300000','4.11.3','User Defined Report levels for Tax Invoice',NULL,null,'True',0,0,'4110000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4110400000','4.11.4','User Defined Report levels for Tax Invoice',',,,',null,'True',0,0,'4110000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4110500000','4.11.5','User Defined Report Subtitle for Tax Invoice ',NULL,null,'True',0,0,'4110000000','False')" +


           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4120000000','4.12','Report Headings',NULL,null,'True',0,0,'4000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4120100000','4.12.1','Order','$',null,'True',0,0,'4120000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4120200000','4.12.2','Challan','$',null,'True',0,0,'4120000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4120300000','4.12.3','Invoice','$',null,'True',0,0,'4120000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4120400000','4.12.4','Return','$',null,'True',0,0,'4120000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4130000000','4.13','Document Level',NULL,null,'True',0,0,'4000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4130100000','4.13.1','Order','$',null,'True',0,0,'4130000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4130200000','4.13.2','Challan','$',null,'True',0,0,'4130000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4130300000','4.13.3','Invoice','$',null,'True',0,0,'4130000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4130400000','4.13.4','Return','$',null,'True',0,0,'4130000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4140100000','4.14.1','Return','$',null,'True',0,0,'4000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,4,'4140200000','4.14.2','Return','$',null,'True',0,0,'4000000000','False')" +


           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5000000000','5.0.0','Control',NULL,NULL,'True',0,0,'0','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5010000000','5.1','Accounts',NULL,NULL,'True',0,0,'5000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5010100000','5.1.1','Cash Balance ',NULL,null,'True',0,0,'5010000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5010100000','5.1.1.1','Warning on Negative Balance ',NULL,null,'True',0,0,'5010100000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5010100000','5.1.1.2','Disallow Entry on Negative Balance',NULL,null,'True',0,0,'5010100000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5010200000','5.1.2','Bank Balance',NULL,null,'True',0,0,'5010000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5010201000','5.1.2.1','Warning on Negative Balance ',NULL,null,'True',0,0,'5010200000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5010202000','5.1.2.2','Disallow Entry on Negative Balance',NULL,null,'True',0,0,'5010200000','False')" +


           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5010300000','5.1.3','Account Budgets',NULL,null,'True',0,0,'5010000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5010301000','5.1.3.1','Expenditure',NULL,null,'True',0,0,'5010300000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5010400000','5.1.4','Credit Limit',NULL,null,'True',0,0,'5010000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5010401000','5.1.4.1','Debtors',NULL,NULL,'True',0,0,'5010400000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5010402000','5.1.4.2','Creditors',NULL,NULL,'True',0,0,'5010400000','False')" +




           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020000000','5.2','Inventory',NULL,null,'True',0,0,'5000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020100000','5.2.1','Warning on zero level Issues',NULL,null,'True',0,0,'5020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020101000','5.2.1.1','Active till Location Level',NULL,null,'True',0,0,'5020100000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020102000','5.2.1.2','Warning on zero level issue-Sales',NULL,null,'True',0,0,'5020100000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020103000','5.2.1.3','Warning on zero level issue-Purchase Returns',NULL,null,'True',0,0,'5020100000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020104000','5.2.1.4','Warning on zero level issue-Issues',NULL,null,'True',0,0,'5020100000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020105000','5.2.1.5','Warning on zero level issue-Stock Transfer OUT',NULL,null,'True',0,0,'5020100000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020200000','5.2.2','Disallow on zero level issues',NULL,null,'True',0,0,'5020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020201000','5.2.2.1','Active till Location Level for Disallow',NULL,null,'True',0,0,'5020200000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020202000','5.2.2.2','Disallow on zero level issue-Sales',NULL,null,'True',0,0,'5020200000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020203000','5.2.2.3','Disallow on zero level issue-Purchase Returns',NULL,null,'True',0,0,'5020200000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020204000','5.2.2.4','Disallow on zero level issue-Issues',NULL,null,'True',0,0,'5020200000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020205000','5.2.2.5','Disallow on zero level issue-Stock Transfer OUT ',NULL,null,'True',0,0,'5020200000','False')" +



           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020300000','5.2.3','Disallow modification of Item rates ',NULL,null,'True',0,0,'5020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020301000','5.2.3.1','Sales',NULL,null,'True',0,0,'5020300000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020302000','5.2.3.2','Purchase',NULL,null,'True',0,0,'5020300000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020303000','5.2.3.3','Sales Return',NULL,null,'True',0,0,'5020300000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020304000','5.2.3.4','Purchase return',NULL,null,'True',0,0,'5020300000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020305000','5.2.3.5','Stock Transfers In ',NULL,null,'True',0,0,'5020300000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020306000','5.2.3.6','Stock Transfers Out',NULL,null,'True',0,0,'5020300000','False')" +


           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020400000','5.2.4','Disallow modification of despatched/Recd Qty against DNote',NULL,null,'True',0,0,'5020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020401000','5.2.4.1','Sales',NULL,null,'True',0,0,'5020400000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020402000','5.2.4.2','Purchase',NULL,null,'True',0,0,'5020400000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020403000','5.2.4.3','Sales Return',NULL,null,'True',0,0,'5020400000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020404000','5.2.4.4','Purchase return',NULL,null,'True',0,0,'5020400000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020405000','5.2.4.5','Manufacturing Returns',NULL,null,'True',0,0,'5020400000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020406000','5.2.4.6','FG returns',NULL,null,'True',0,0,'5020400000','False')" +
           
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020500000','5.2.5','Disallow modification of Order Qty ',NULL,null,'True',0,0,'5020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020501000','5.2.5.1','Sales',NULL,null,'True',0,0,'5020500000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020502000','5.2.5.2','Purchase',NULL,null,'True',0,0,'5020500000','False')" +

            " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020600000','5.2.6','Disallow modification of Order Qty ',NULL,null,'True',0,0,'5020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020601000','5.2.6.1','Sales',NULL,null,'True',0,0,'5020600000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020602000','5.2.6.2','Purchase',NULL,null,'True',0,0,'5020600000','False')" +
           
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020700000','5.2.7','Allow zero value issues',NULL,null,'True',0,0,'5020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020701000','5.2.7.1','Sales',NULL,null,'True',0,0,'5020700000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020702000','5.2.7.2','Purchase',NULL,null,'True',0,0,'5020700000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020703000','5.2.7.3','Stock Transfer Out',NULL,null,'True',0,0,'5020700000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020704000','5.2.7.4','Manufacturing Issues',NULL,null,'True',0,0,'5020700000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020705000','5.2.7.5','Non-Manufacturing Issues',NULL,null,'True',0,0,'5020700000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020706000','5.2.7.6','FG Returns',NULL,null,'True',0,0,'5020700000','False')" +
           
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020800000','5.2.8','Allow zero value Receipts',NULL,null,'True',0,0,'5020000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020801000','5.2.8.1','Purchase',NULL,null,'True',0,0,'5020800000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020802000','5.2.8.2','Sales Return',NULL,null,'True',0,0,'5020800000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020803000','5.2.8.3','Stock Transfer In',NULL,null,'True',0,0,'5020800000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020804000','5.2.8.4','Manufacturing Returns',NULL,null,'True',0,0,'5020800000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020805000','5.2.8.5','Non-Manufacturing Returns',NULL,null,'True',0,0,'5020800000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5020806000','5.2.8.6','FG Receipts',NULL,null,'True',0,0,'5020800000','False')" +


           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5030000000','5.3','Auto Backup',NULL,null,'True',0,0,'5000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5040000000','5.4','Auto Index every_Hours',NULL,null,'True',0,0,'5000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5050000000','5.5','Index Checking at Company Selection',NULL,null,'True',0,0,'5000000000','False')" +

           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5060000000','5.6','Transaction Control',NULL,null,'True',0,0,'5000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5060100000','5.6.1','Voucher Date',NULL,null,'True',0,0,'5060000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5060101000','5.6.1.1','Last Voucher Date',NULL,null,'True',0,0,'5060100000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5060202000','5.6.1.2','Min of System date & voucher date',NULL,null,'True',0,0,'5060100000','False')" +
           
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5060200000','5.6.2','Default Sales Transaction Type Cash',NULL,null,'True',0,0,'5060000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5060300000','5.6.3','Last Voucher Date',NULL,null,'True',0,0,'5060000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5060301000','5.6.3.1','Prevent Replicating Documents(Details)',NULL,null,'True',0,0,'5060300000','False')" +
           
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5070000000','5.7','Auto Invoice',NULL,null,'True',0,0,'5000000000','False')" +
           " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES(@ficode,@gcode,1,5,'5080000000','5.8','Multi Selection of Items',NULL,null,'True',0,0,'5000000000','False')" +
           " set nocount off";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }
        
        public bool create_EmpAdv(SqlConnection con)
        {
           string qry="create table [tbl_Employee_Advance]([EAID] [numeric](18, 0) NULL," + 
         "[EAEID] [nvarchar](10) NULL,[EANAME] [nvarchar](50) NULL,[EADT] [date] NULL," +
         "[EAMONTH] [nvarchar](15) NULL,[EAAMT] [numeric](18, 2) NULL," +
         "[EADEDUCT] [numeric](18, 0) NULL,[EADEDUCTDT] [date] NULL," + 
         "[SLNO] [numeric](18, 0) NULL,[CoID] [int] NULL,[LocID] [int] NULL) ON [PRIMARY]";
            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool create_EmpKIT(SqlConnection con)
        {
            string qry = "create table [tbl_Employee_KIT]([EKID] [numeric](18, 0) NULL," +
          "[EKEID] [nvarchar](10) NULL,[EKNAME] [nvarchar](50) NULL,[EKDT] [date] NULL," +
          "[EKMONTH] [nvarchar](15) NULL,[EKKIT] [nvarchar](50) NULL,[EKAMT] [numeric](18, 2) NULL," +
          "[EKDuration] [numeric](18, 2) NULL,[EKEMI] [numeric](18, 2) NULL," +
          "[EKDEDUCT] [numeric](18, 0) NULL,[EKDEDUCTDT] [date] NULL," +
          "[SLNO] [numeric](18, 0) NULL,[CoID] [int] NULL,[LocID] [int] NULL) ON [PRIMARY]";
            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool create_EmpLoan(SqlConnection con)
        {
            string qry = "create table [tbl_Employee_LOAN]([ELID] [numeric](18, 0) NULL," +
          "[ELEID] [nvarchar](10) NULL,[ELNAME] [nvarchar](50) NULL,[ELDT] [date] NULL," +
          "[ELMONTH] [nvarchar](15) NULL,[ELAMT] [numeric](18, 2) NULL,[ELRate] [numeric](18, 2) NULL," +
          "[ELRtAmt] [numeric](18, 2) NULL,[ELDuration] [numeric](18, 2) NULL,[ELEMI] [numeric](18, 2) NULL," +
          "[ELDEDUCT] [numeric](18, 0) NULL,[ELDEDUCTDT] [date] NULL," +
          "[SLNO] [numeric](18, 0) NULL,[CoID] [int] NULL,[LocID] [int] NULL) ON [PRIMARY]";
            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool create_KIT(SqlConnection con)
        {
            string qry = "create table [MSTKIT]([KTID] [int] NULL,[KTNAME] [nvarchar](50) NULL," +
            "[KTVAL] [numeric](18, 2) NULL) ON [PRIMARY] ";
           

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool create_KIT_Trigger(SqlConnection con)
        {
            string qry = " CREATE PROCEDURE [SP_MSTKIT_IU] @KTNO INT,@KTNAME nvarchar(50),@KTAMT numeric(18,2) " +
            " AS BEGIN if (@KTNO>0) BEGIN try SET NOCOUNT ON; " +
            " UPDATE MSTKIT SET KTNAME = @KTNAME, KTVAL = @KTAMT WHERE KTID = @KTNO " +
            " SELECT 'y' end try Begin catch select 'n' end catch " +
            " else if (@KTNO=0) Declare @KTID int= (Select COUNT(*)+1 from MSTKIT) " +
            " Begin TRY SET NOCOUNT ON; " +
            " insert into MSTKIT(KTID,KTNAME,KTVAL) VALUES (@KTID,@KTNAME,@KTAMT) " +
            " SELECT 'y' END TRY BEGIN CATCH SELECT 'n' END CATCH END";

            cmd = new SqlCommand(qry, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool crt_billOD(SqlConnection con)
        {
            string Country = "create table [paybillOD]([ODetails] [nvarchar](max) NULL,[TC] [nvarchar](max) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
