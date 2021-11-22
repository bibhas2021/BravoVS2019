using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using System.Data.SqlClient;
using System.Data.Sql;
using FirstTimeNeed;
using EDPVersion.Properties;
using System.IO;

namespace EDPVersion
{
    public partial class versionEDP : Form
    {
        Edpcom.EDPConnection edpcon = new EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        SqlDataAdapter SQLDA = new SqlDataAdapter();
        clsMenuEntry menu = new clsMenuEntry();
        clsfirsttime first = new clsfirsttime();
        public DateTime CBuildDate, PBuildDate;
        public bool Versionflg;
        public versionEDP()
        {
            edpcom.PBUILD_DATE = Convert.ToDateTime(Resources.Build_Date);
            InitializeComponent();
        }

        public void ChkVersion(SqlConnection CON, DateTime Pbuild_date, DateTime Cbuild_date)// EACH ANOTHER MODULE NEED A CONNECTION FROM MAIN_FORM
        {
            CBuildDate = Cbuild_date; PBuildDate = Pbuild_date;
            if (edpcom.FirstTimeInstall)
            {
                lblVersion.Text = "Application Updating for the First Time Installation And creating database on " + Application.StartupPath;
                lblPath.Text = "Creating DataBase";
                prbVersion.Increment(prbVersion.Value + 1);
                if (first.firsttimeData(CON)) lblPath.Text = "Database created succesfully";
                else lblPath.Text = " Cannot create Database";
                lblPath.Text = "Creating Method";
                prbVersion.Increment(prbVersion.Value + 1);
                if (first.firstimemethod(CON)) lblPath.Text = "Methods created succesfully";
                else lblPath.Text = "Cannot create Methods";
                prbVersion.Increment(prbVersion.Value + 1);
                lblVersion.Text = "Application Successfully Updated It'sself";
                lblPath.Text = "Thank You for using AccordFour";
                lblVersion.Text = "Application Terminated auotomatically";
                prbVersion.Value = prbVersion.Maximum;
                Versionflg = true;
                menu.EnterIntomenu(CON, CBuildDate, PBuildDate);
                //  UpdtDBInfo(CON);
                Versionflg = true;
            }
            if (PBuildDate < CBuildDate)
            {
                MessageBox.Show("You are running an old Version.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Versionflg = false;
                return;
            }
            else
            {
                //if (Cbuild_date<Convert.ToDateTime("the next build date'"))
                //call the procedure
                if (Cbuild_date < Convert.ToDateTime("16/10/08"))
                    currency_alter(CON);
                if (Cbuild_date < Convert.ToDateTime("18/10/08"))
                {
                    TrnsType_alter(CON);
                    TypeMast_Updt(CON);
                }
                //if (Cbuild_date < Convert.ToDateTime("27/10/08"))
                //{
                //    TypeMast_Updt(CON);
                //}
                if (Cbuild_date < Convert.ToDateTime("28/10/08"))
                {

                    MenuUser_alter(CON);
                }
                if (Cbuild_date < Convert.ToDateTime("3/11/08"))
                {

                    RowIndx_alter(CON);
                    alloc_table_creation(CON);
                    TriggerAdjustPLtran_creation(CON);
                    Comment_alter(CON);
                }
                if (Cbuild_date < Convert.ToDateTime("15/11/08"))
                {

                    //   Asset_Class(CON);
                    //string strdbprc = "InvMst_ins";
                    //SqlCommand cmd = new SqlCommand(strdbprc, CON);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //SqlParameter FICODE = new SqlParameter("@pFICode", edpcom.CurrentFicode);

                    //cmd.Parameters.Add(FICODE);
                    //try
                    //{
                    //    cmd.ExecuteNonQuery();
                    //}
                    //catch { }
                    T_ENTRY_Entry(CON);
                    string strdbprc = "TypeMast_ins";
                    SqlCommand cmd = new SqlCommand(strdbprc, CON);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter FICODE = new SqlParameter("@pFICode", edpcom.CurrentFicode);
                    SqlParameter GCODE = new SqlParameter("@pGcode", edpcom.PCURRENT_GCODE);
                    cmd.Parameters.Add(FICODE);
                    cmd.Parameters.Add(GCODE);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("17/06/10"))
                {
                    string SqlStr = "ALTER TABLE Branch ADD [Comp_Type] [varchar](50) NULL CONSTRAINT [DF_Branch_Comp_Type]  DEFAULT ('-')";
                    try
                    {
                        edpcom.RunCommand(SqlStr, CON);
                    }
                    catch { }
                    //UpdateMethods.Typemas_InsUpdate();
                    //UpdateMethods.Typemas_InsUpdate();
                    //UpdateMethods.ItranTriggerUpdate();
                    //UpdateMethods.AdjustEtranUpdate();
                    AlterCompanyTrigger();
                }

                //if (Cbuild_date < Convert.ToDateTime("24/05/12"))
                //{
                //    //string SqlStr = "Update WACCOPTN Set OPTION_DESC='Bill on Cash Payment' Where Ficode='" + edpcom.CurrentFicode + "' And gcode='" + edpcom.PCURRENT_GCODE + "' And SeriesNo='3.4.8.8'";
                //    string SqlStr = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('1','2',1,3,'3040806000','3.4.8.9','Bill on Cash Payment',NULL,null,'True',0,0,'3040800000','False')";
                //    try
                //    {
                //        edpcom.RunCommand(SqlStr);
                //    }
                //    catch { }                   
                //}
                if (Cbuild_date < Convert.ToDateTime("10/06/12"))
                {
                    string str1 = "ALTER TABLE  idata ADD OrderType char(10) Null";
                    try
                    {
                        edpcom.RunCommand(str1, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("13/07/12"))
                {
                    try
                    {
                        string sqlstr = "ALTER TABLE idata ADD Your_Order_No Varchar(80) null";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("26/07/12"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('60150000000','60000000000','Settings','Settings',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "Insert into menutable values('60150100000','60150000000','Documents Numbering and A/C Posting SetUp','DNandPS',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "Insert into menutable values('60150200000','60150000000','User Details','UserDetails',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "Insert into menutable values('60150300000','60150000000','Setting HotKeys','SettingHotKeys',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);

                        //sqlstr = "ALTER TABLE typedoc ADD User_Code Varchar(10) not null";
                        //edpcom.RunCommand(sqlstr);
                        //sqlstr = "ALTER TABLE docnumber ADD User_Code Varchar(10) not null";
                        //edpcom.RunCommand(sqlstr);
                        //sqlstr = "ALTER TABLE docgen ADD User_Code Varchar(10) not null";
                        //edpcom.RunCommand(sqlstr);

                        //edpcom.RunCommand("alter TABLE typedoc ADD primary KEY (ficode,GCODE,T_entry,DESCCODE,VOUCHERNO,User_Code)");
                        //edpcom.RunCommand("alter TABLE docnumber ADD primary KEY (ficode,GCODE,T_entry,TYPE_NAME,DESCCODE,User_Code)");
                        //edpcom.RunCommand("alter TABLE docgen ADD primary KEY (ficode,GCODE,T_entry,Desccode,User_Code)");

                    }
                    catch { }
                }
                //if (Cbuild_date < Convert.ToDateTime("08/08/12"))
                //{
                //    string strParty = "CREATE TABLE [LocationMaster] (Lock_Code int  NOT NULL,Lock_Name varchar(100) NULL,";
                //    strParty = strParty + "Remarks varchar(max) NULL ,Loc_Transfar int NULL,";
                //    strParty = strParty + "primary key clustered(Lock_Code))";
                //    try
                //    {
                //        edpcom.RunCommand(strParty);
                //    }
                //    catch { }
                //}

                if (Cbuild_date < Convert.ToDateTime("10/08/12"))
                {
                    try
                    {
                        edpcom.RunCommand("update  prtyms set ACC_ADD1 varchar(max) Null,ACC_ADD2 varchar(max) Null", CON);
                    }
                    catch { }
                }

                //if (Cbuild_date < Convert.ToDateTime("20/08/12"))
                //{
                //    try
                //    {
                //        edpcom.RunCommand("ALTER TABLE LocationMaster ADD Contact_Person varchar(50) Null,Phone Varchar(50) Null ", CON);
                //        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD Kind_Attention varchar(50) Null,Phone varchar(50) Null,Mode_Of_Transport Varchar(50) Null ", CON);
                //    }
                //    catch { }
                //}
                if (Cbuild_date < Convert.ToDateTime("21/08/12"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('40020101030','40020101000','D Note','D_Note',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("23/08/12"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD Kind_Attention varchar(50) Null,Phone varchar(50) Null,Mode_Of_Transport Varchar(50) Null ", CON);
                        edpcom.RunCommand("ALTER TABLE Branch ADD Range varchar(50) Null,Website Varchar(100) Null", CON);
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD Prepared_by Varchar(50) Null ", CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("24/08/12"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('40020101040','40020101000','Order','order',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("25/08/12"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD Indent Varchar(50) Null ", CON);
                    }
                    catch { }
                }

                //if (Cbuild_date < Convert.ToDateTime("26/08/12"))
                //{
                //    string SqlStr = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('1','1',1,3,'3100400000','3.10.4','Brand Allonce',NULL,null,'False',0,0,'3100000000','False')";
                //    try
                //    {
                //        edpcom.RunCommand(SqlStr);
                //    }
                //    catch { }
                //}
                if (Cbuild_date < Convert.ToDateTime("27/08/12"))
                {
                    try
                    {
                        //string sqlstr = "ALTER TABLE iglmst ADD PaperConsume bit null,QtyRound bit null";
                        //edpcom.RunCommand(sqlstr);                       
                        string sqlstr2 = "ALTER TABLE idata ADD IncluciveVAT bit null,OnVATPer bit null,AdhokAmt bit null";
                        edpcom.RunCommand(sqlstr2, CON);

                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("28/08/12"))
                {
                    try
                    {
                        string strParty = "CREATE TABLE [LocationMaster] (Lock_Code int  NOT NULL,Lock_Name varchar(100) NULL,";
                        strParty = strParty + "Remarks varchar(max) NULL ,Loc_Transfar int NULL,";
                        strParty = strParty + "primary key clustered(Lock_Code))";
                        try
                        {
                            edpcom.RunCommand(strParty, CON);
                        }
                        catch { }
                        edpcom.RunCommand("ALTER TABLE Itran ADD YourQty varchar(50) Null,OurQty varchar(50) Null,Remarks Varchar(max) Null ", CON);
                        //string sqlstr = "Insert into menutable values('40020101030','40020101000','D Note','D_Note',1,' ',' ',0)";
                        //edpcom.RunCommand(sqlstr);

                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("29/08/12"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE iglmst ADD PurRate Varchar(50) Null ", CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("30/08/12"))
                {
                    try
                    {
                        string sqlstr = "update menutable Set  MENUDESC='Purchase Indent',DETAILDESC='Purchase_Indent' where MENUCODE='20020302010' and PARENTCODE='20020302000'";
                        edpcom.RunCommand(sqlstr, CON);
                        string sqlstr1 = "update menutable Set  MENUDESC='Purchase Order',DETAILDESC='Purchase' where MENUCODE='20020302020' and PARENTCODE='20020302000'";
                        edpcom.RunCommand(sqlstr1, CON);
                        string sqlstr2 = "update menutable Set  MENUDESC='Purchase Challan/DNote',DETAILDESC='Challan/DNote',SHORTCUT_KEY='' where MENUCODE='20020302030' and PARENTCODE='20020302000'";
                        edpcom.RunCommand(sqlstr2, CON);
                        string sqlstr3 = "update menutable Set  MENUDESC='Purchase Invoice',DETAILDESC='Purchase_Invoice',SHORTCUT_KEY='F8' where MENUCODE='20020302040' and PARENTCODE='20020302000'";
                        edpcom.RunCommand(sqlstr3, CON);
                        string sqlstr4 = "Insert into menutable values('20020302050','20020302000','Purchase Return','Purchase_Return',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr4, CON);
                        //string sqlstr5 = "insert into TypeMast values(1,1,'PI','Purchase Indent','PurInd')";
                        //edpcom.RunCommand(sqlstr5);
                        edpcom.RunCommand("ALTER TABLE itran ADD ReqDate Varchar(50) Null ", CON);

                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("31/08/12"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE LocationMaster ADD Contact_Person varchar(50) Null,Phone Varchar(50) Null ", CON);
                        edpcom.RunCommand("ALTER TABLE LocationMaster ADD FactoryPh1 varchar(50) Null,FactoryPh2 Varchar(50) Null,FactoryFax Varchar(50) Null ", CON);
                        edpcom.RunCommand("update  glmst set ACTV_FLG='True'", CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("06/09/12"))
                {
                    try
                    {
                        //edpcom.RunCommand("ALTER TABLE TypeMast ADD cash_bill varchar(50) Null,inclusive_vat Varchar(50) Null,online_print Varchar(50) Null ", CON);
                        Boolean Service = false;
                        edpcom.RunCommand("update  iglmst set SERVICE='" + Service + "'", CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime(" 07/09/12"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('40020101050','40020101000','Indent','Indent',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime(" 08/09/12"))
                {
                    try
                    {
                        string sqlstr = "  create table TransactControl (USER_CODE varchar(6)  NOT NULL ,FICode CHAR(10)  NOT NULL, GCODE CHAR(10)  NOT NULL,T_ENTRY CHAR(10) NOT NULL,BOOL_ADD BIT NULL, BOOL_MODIFY BIT NULL, BOOL_VIEW BIT NULL, BOOL_DELETE BIT NULL, BOOL_CANCEL BIT NULL, Desccode numeric(18, 0) NOT NULL,primary key clustered(USER_CODE,FICode,GCODE,T_ENTRY,Desccode))";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime(" 09/09/12"))
                {
                    try
                    {
                        string sqlstr = " alter table BillAdditionalDetails alter column LorryNo varchar(100) null ";
                        edpcom.RunCommand(sqlstr);
                        edpcom.RunCommand("ALTER TABLE idata ADD Type bit Null ", CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime(" 10/09/12"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE idata ADD Type bit Null ", CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime(" 11/09/12"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD Advance Varchar(100) Null ", CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("12/09/12"))
                {
                    try
                    {
                        string sqlstr = "ALTER TABLE iglmst ADD PaperConsume bit null,QtyRound bit null";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                //if (Cbuild_date < Convert.ToDateTime("13/09/12"))
                //{
                //    try
                //    {
                //        string SqlStr1 = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('1','1',1,3,'3040809000','3.4.8.9','Bill on Cash Payment',NULL,null,'True',0,0,'3040800000','False')";
                //        edpcom.RunCommand(SqlStr1);
                //        string SqlStr = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('1','2',1,3,'3040809000','3.4.8.9','Bill on Cash Payment',NULL,null,'True',0,0,'3040800000','False')";
                //        edpcom.RunCommand(SqlStr);

                //    }
                //    catch { }
                //}
                if (Cbuild_date < Convert.ToDateTime("29/09/12"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "ALTER TABLE typedoc ADD User_Code Varchar(10) null";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";
                        sqlstr = "ALTER TABLE docnumber ADD User_Code Varchar(10) null";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";
                        sqlstr = "ALTER TABLE docgen ADD User_Code Varchar(10) null";
                        edpcom.RunCommand(sqlstr, CON);
                        edpcom.RunCommand("update  typedoc set User_Code='" + 1 + "'", CON);
                        edpcom.RunCommand("update  docnumber set User_Code='" + 1 + "'", CON);
                        edpcom.RunCommand("update  docgen set User_Code='" + 1 + "'", CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("29/09/12"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "ALTER TABLE typedoc ADD Bill_Type bit null,Bill_Format Varchar(50) null";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                //if (Cbuild_date < Convert.ToDateTime("30/09/12"))
                //{                    
                //    try
                //    {
                //        edpcom.RunCommand("update  WACCOPTN set OPTION_CODE='3040809000 ' where OPTION_DESC='Bill on Cash Payment' and SeriesNo='3.4.8.9' ", CON);
                //    }
                //    catch { }
                //}

                if (Cbuild_date < Convert.ToDateTime("1/10/12"))
                {
                    try
                    {
                        //Purchase Order
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','1','PO','1001','Apply Discount','False','False')", CON);
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','1','PO','1002','Online BillPrint','False','False')", CON);

                        ////Purchase Entry
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','1','8','1002','Online BillPrint','False','False')", CON);
                        ////Purchase Challen

                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','1','a','1002','Online BillPrint','False','False')", CON);

                        ////Purchase Indent                        
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','1','PI','1002','Online BillPrint','False','False')", CON);

                        ////Sales Entry 

                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','1','9','1002','Online BillPrint','False','False')", CON);
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','1','9','1003','Vat Type','False','False')", CON);
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','1','9','1004','Document Type','False','False')", CON);
                        ////Sales Challan
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','1','n','1002','Online Bill Printing','False','False')", CON);

                        ////Sales Order
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','1','OS','1001','Apply Discount','False','False')", CON);
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','1','OS','1002','Online BillPrint','False','False')", CON);
                        //Purchase Order
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','2','PO','1001','Apply Discount','False','False')", CON);
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','2','PO','1002','Online BillPrint','False','False')", CON);

                        ////Purchase Entry
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','2','8','1002','Online BillPrint','False','False')", CON);
                        ////Purchase Challen

                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','2','a','1002','Online BillPrint','False','False')", CON);

                        ////Purchase Indent                        
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','2','PI','1002','Online BillPrint','False','False')", CON);

                        ////Sales Entry 

                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','2','9','1002','Online BillPrint','False','False')", CON);
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','2','9','1003','Vat Type','False','False')", CON);
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','2','9','1004','Document Type','False','False')", CON);
                        ////Sales Challan
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','2','n','1002','Online Bill Printing','False','False')", CON);

                        ////Sales Order
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','2','OS','1001','Apply Discount','False','False')", CON);
                        //edpcom.RunCommand("insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('1','2','OS','1002','Online BillPrint','False','False')", CON);


                    }
                    catch { }
                }


                if (Cbuild_date < Convert.ToDateTime("2/10/12"))
                {
                    try
                    {
                        string strtypemst = "create table TypeMast_Config(FICode char(10)not null,GCODE char(10)not null,T_ENTRY char(20) not null,";
                        strtypemst = strtypemst + "OPTION_CODE varchar(12)not null, OPTION_DESC varchar(70) not null,STR_VAL varchar(max) null,";
                        strtypemst = strtypemst + "DATE_VAL datetime null,BOOL_VAL varchar(30)null,NUM_VAL numeric(18,0)null,DFLT_VAL varchar(50)not null,PARENT_CODE numeric(18,0)null,MEMO_VAL varchar(max)null";
                        strtypemst = strtypemst + " primary key clustered(FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,DFLT_VAL))";
                        edpcom.RunCommand(strtypemst, CON); strtypemst = "";

                        strtypemst = "create table TypeDoc_Config(FICode char(10)not null,GCODE char(10)not null,T_ENTRY char(20) not null,";
                        strtypemst = strtypemst + "Desccode numeric(18,0)not null,OPTION_CODE varchar(12)not null,STR_VAL varchar(max) null,";
                        strtypemst = strtypemst + "DATE_VAL datetime null,BOOL_VAL varchar(30)null,NUM_VAL numeric(18,0)null,DFLT_VAL varchar(50)not null,PARENT_CODE numeric(18,0)null,MEMO_VAL varchar(max)null,Script varchar(max)null";
                        strtypemst = strtypemst + " primary key clustered(FICode,GCODE,T_ENTRY,Desccode,OPTION_CODE,DFLT_VAL))";
                        edpcom.RunCommand(strtypemst, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("04/10/12"))
                {
                    try
                    {
                        string str = "Insert into menutable values('50130100000','50130000000','Normal Backup','Normal_Backup',1,' ',' ',0)";
                        edpcom.RunCommand(str, CON);
                        str = "Insert into menutable values('50130200000','50130000000','Company Financial Year Wise Backup','Company_Financial_Year_Wise_Backup',1,' ',' ',0)";
                        edpcom.RunCommand(str, CON);
                        str = "update menutable Set  MENUDESC='Company Financial Year Wise Restore',DETAILDESC='Company_Financial_Year_Wise_Restore' where MENUCODE='50140100000' and PARENTCODE='50140000000'";
                        edpcom.RunCommand(str, CON);

                        str = "CREATE TABLE Backup_Restore_Information (FICODE char(10) NOT NULL ,GCODE char(10) NOT NULL ,";
                        str = str + "BR_Type char(10) NOT NULL,Backup_No varchar(50) Default('0') NOT NULL,";
                        str = str + "Backup_Date datetime NULL,Restore_No varchar(50) Default('0') NOT NULL,";
                        str = str + "Restore_Date datetime NULL,Serial_No varchar(50) NULL,";
                        str = str + "EXE_Ver varchar(50) NULL,Build_Date datetime NULL,";
                        str = str + "Status varchar(50) NULL,Remarkes varchar(50) NULL,";
                        str = str + "primary key clustered(FICODE,GCODE,BR_Type,Backup_No,Restore_No))";
                        try
                        {
                            edpcom.RunCommand(str, CON);
                        }
                        catch { }
                    }
                    catch { }

                }


                if (Cbuild_date < Convert.ToDateTime("05/10/12"))
                {
                    try
                    {
                        string strForm = "CREATE TABLE FormMaster (Form_CODE numeric (18,0) NOT NULL,Form_Name VARCHAR (100) NOT NULL,primary key clustered (Form_CODE))";
                        edpcom.RunCommand(strForm, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("06/10/12"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "ALTER TABLE iglmst ADD Cstpercent numeric (18,2) null";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("07/10/12"))
                {
                    try
                    {
                        string sqlstr = "Insert into FormMaster values('1','Null')";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("08/10/12"))
                {
                    try
                    {
                        string sqlstr2 = "update menutable Set  MENUDESC='Purchase GRN',DETAILDESC='GRN',SHORTCUT_KEY='' where MENUCODE='20020302030' and PARENTCODE='20020302000'";
                        edpcom.RunCommand(sqlstr2, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("09/10/12"))
                {
                    try
                    {
                        edpcom.RunCommand("update  WACCOPTN set bool_val='True' where SeriesNo='3.4.8.4' ", CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("10/10/12"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "ALTER TABLE company ADD Country_Code numeric (18,0) null";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("12/10/12"))
                {
                    try
                    {
                        FirstTimeNeed.clsfirsttime fisttime = new FirstTimeNeed.clsfirsttime();
                        fisttime.Country_table_creation(CON);
                        fisttime.creatTrigCompContary(CON);

                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("13/10/12"))
                {
                    try
                    {
                        string sqlstr = " insert into StateMaster values(36,'OTHERS',NULL)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("14/10/12"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "ALTER TABLE NARR ADD ACNO varchar(50) null";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime(" 15/10/12"))
                {
                    try
                    {
                        string sqlstr = "update menutable set SHORTCUT_KEY='F12',MENUDESC='ReUser Login',DETAILDESC='ReUser Login' Where MENUCODE='50200000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "";
                        sqlstr = "update menutable set SHORTCUT_KEY='F10',MENUDESC='Configuration',DETAILDESC='Configuration' Where MENUCODE='50190000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "";
                        sqlstr = "update menutable set SHORTCUT_KEY='' Where MENUCODE='50010000000'";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("16/10/12"))
                {
                    try
                    {
                        FirstTimeNeed.clsfirsttime fisttime = new FirstTimeNeed.clsfirsttime();
                        fisttime.AccordFourlogDetail_table_creation(CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("17/10/12"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "ALTER TABLE Glmst ADD ACNO varchar(50) null";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("18/10/12"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (1,1,'9','1011','Product Qty by Default','False','False')";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("19/10/12"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "update  LinkVATGLMST set vat_per='14.50' where vat_per='13.50' and glcode=1207";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("20/10/12"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "insert into TypeMast values(1,1,'SR','Sales Return','SRETURN'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "insert into TypeMast values(1,1,'PR','Purchase Return','PR'";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("21/10/12"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "insert into TypeMast values(1,2,'SR','Sales Return','SRETURN'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "insert into TypeMast values(1,2,'PR','Purchase Return','PR'";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("22/11/12"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('40010206000','40010200000','Cheque Print','Cheque_Print',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("23/11/12"))
                {
                    try
                    {

                        string sqlstr2 = "update menutable Set  MENUDESC='Vat Reports',DETAILDESC='Vat_Reports'where MENUCODE='40010420000' and PARENTCODE='40010400000'";
                        edpcom.RunCommand(sqlstr2, CON);
                        string sqlstr = "Insert into menutable values('40010422000','40010420000','State Name','State Name',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";
                        sqlstr = "Insert into menutable values('40010422100','40010422000','Delhi','Delhi',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";
                        sqlstr = "Insert into menutable values('40010422110','40010422100','DVAT 30','DVAT_30',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";
                        sqlstr = "Insert into menutable values('40010422120','40010422100','DVAT 31','DVAT_31',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";


                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("12/12/12"))
                {
                    try
                    {
                        string strForm = "CREATE TABLE Cheque_Print_Details (FICODE CHAR(10) NOT NULL,GCODE CHAR(10) NOT NULL,Initial VARCHAR (100) NOT NULL,GLCODE_BANK NUMERIC (18,0) NOT NULL,AC_PAYEE_TOP NUMERIC (18,0),AC_PAYEE_LEFT NUMERIC (18,0),AC_PAYEE_WIDTH NUMERIC (18,0),NOTOVERSTATEMENT_TOP NUMERIC (18,0),NOTOVERSTATEMENT_LEFT NUMERIC (18,0),NOTOVERSTATEMENT_WIDTH NUMERIC (18,0),DATE_TOP NUMERIC (18,0),DATE_LEFT NUMERIC (18,0),DATE_WIDTH NUMERIC (18,0),PAYTOLINE1_TOP NUMERIC (18,0),PAYTOLINE1_LEFT NUMERIC (18,0),PAYTOLINE1_WIDTH NUMERIC (18,0),PAYTOLINE2_TOP NUMERIC (18,0),PAYTOLINE2_LEFT NUMERIC (18,0)," +
                            " PAYTOLINE2_WIDTH NUMERIC (18,0),AMTINWORDS1_TOP NUMERIC (18,0),AMTINWORDS1_LEFT NUMERIC (18,0),AMTINWORDS1_WIDTH NUMERIC (18,0),AMTINWORDS2_TOP NUMERIC (18,0),AMTINWORDS2_LEFT NUMERIC (18,0),AMTINWORDS2_WIDTH NUMERIC (18,0),CHEQUE_AMT_TOP NUMERIC (18,0),CHEQUE_AMT_LEFT NUMERIC (18,0),CHEQUE_AMT_WIDTH NUMERIC (18,0),AC_NO_TOP NUMERIC (18,0),AC_NO_LEFT NUMERIC (18,0),AC_NO_WIDTH NUMERIC (18,0),PRINT_CO_NAME VARCHAR (100),PRINT_CO_NAME_TOP NUMERIC (18,0),PRINT_CO_NAME_LEFT NUMERIC (18,0),PRINT_CO_NAME__WIDTH NUMERIC (18,0),PRINT_TEXT VARCHAR (100),PRINT_TEXT_TOP NUMERIC (18,0),PRINT_TEXT_LEFT NUMERIC (18,0),PRINT_TEXT_WIDTH NUMERIC (18,0),BANK_AC_NO_TOP NUMERIC (18,0),BANK_AC_NO_LEFT NUMERIC (18,0),BANK_AC_NO_WIDTH NUMERIC (18,0),FONT_SIZE NUMERIC (18,0),ALL_CAPS BIT,WITH_AC_NO BIT,primary key clustered (FICODE,GCODE,Initial,GLCODE_BANK))";
                        edpcom.RunCommand(strForm, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("13/12/12"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('50220000000','50000000000','Set Cheque Position','Set_Cheque_Position',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("14/12/12"))
                {
                    try
                    {
                        string sqlstr2 = "update menutable Set  MENUCODE='40010422000',PARENTCODE='40010420000'where MENUCODE='40010421000' and PARENTCODE='40010420000'";
                        edpcom.RunCommand(sqlstr2, CON);
                        string sqlstr = "delete from menutable where menucode='40010421100'";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";
                        sqlstr = "delete from menutable where menucode='40010421110'";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";
                        sqlstr = "delete from menutable where menucode='40010421120'";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";

                        sqlstr = "Insert into menutable values('40010422100','40010422000','Delhi','Delhi',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";
                        sqlstr = "Insert into menutable values('40010422110','40010422100','DVAT 30','DVAT_30',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";
                        sqlstr = "Insert into menutable values('40010422120','40010422100','DVAT 31','DVAT_31',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("15/12/12"))
                {
                    try
                    {
                        string str = "update menutable Set  MENUDESC='Goods Receipt Note',DETAILDESC='Goods_Receipt_Note' where MENUCODE='40020101030' and PARENTCODE='40020101000'";
                        edpcom.RunCommand(str, CON);
                        str = "update menutable Set  MENUDESC='Purchase Order Report',DETAILDESC='Purchase_Order_Report' where MENUCODE='40020101040' and PARENTCODE='40020101000'";
                        edpcom.RunCommand(str, CON);
                        str = "update menutable Set  MENUDESC='Purchase Indent Report',DETAILDESC='Purchase_Indent_Report' where MENUCODE='40020101050' and PARENTCODE='40020101000'";
                        edpcom.RunCommand(str, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("16/12/12"))
                {
                    try
                    {
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataTable dtt = new DataTable();
                        SqlCommand cm = new SqlCommand("Select max(ficode),gcode from Company group by gcode", CON);
                        adp.SelectCommand = cm;
                        adp.Fill(dtt);
                        string sqlstr = "";
                        for (int i = 0; i <= dtt.Rows.Count - 1; i++)
                        {
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','9','1012','Bill On Cash Payment','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','9','1013','Set Auto Complete Line Item','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','1','1014','Online Party/Money Receipt Print','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','1','1015','Online Voucher Print','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','2','1015','Online Voucher Print','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','3','1015','Online Voucher Print','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','5','1015','Online Voucher Print','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','7','1015','Online Voucher Print','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','4','1015','Online Voucher Print','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','2','1016','Payment Advise Print','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','2','1017','Online Cheque Print','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','3','1010','Enable display current bal','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','5','1010','Enable display current bal','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','7','1010','Enable display current bal','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','4','1010','Enable display current bal','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','1','1010','Enable display current bal','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','2','1010','Enable display current bal','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                        }
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("16/12/12"))
                {
                    try
                    {
                        string str = "update TypeMast_Config Set  OPTION_DESC='VAT Applicability and Type' where OPTION_CODE='1003' ";
                        edpcom.RunCommand(str, CON);
                        str = "update TypeMast_Config Set  OPTION_DESC='Document Print Format' where OPTION_CODE='1004' ";
                        edpcom.RunCommand(str, CON);
                        str = "update TypeMast_Config Set  OPTION_DESC='Activate Auto VAT Charges' where OPTION_CODE='1005' ";
                        edpcom.RunCommand(str, CON);
                        str = "update TypeMast_Config Set  OPTION_DESC='Concessional Tax Form Applicable' where OPTION_CODE='1006' ";
                        edpcom.RunCommand(str, CON);
                        str = "update TypeMast_Config Set  OPTION_DESC='Concessional Tax Form Name' where OPTION_CODE='1007' ";
                        edpcom.RunCommand(str, CON);
                        str = "update TypeMast_Config Set  OPTION_DESC='Product Qty Unitary by Default' where OPTION_CODE='1011' ";
                        edpcom.RunCommand(str, CON);
                        str = "update TypeMast_Config Set  OPTION_DESC='Set Cash Memo/Bill Active' where OPTION_CODE='1012' ";
                        edpcom.RunCommand(str, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "ALTER TABLE VCHR ADD NCONV_FCTR NUMERIC(18,2) null,DCONV_FCTR NUMERIC(18,2) null";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "ALTER TABLE AddLess ADD FC_AMT NUMERIC(18,2) NULL,NCONV_FCTR NUMERIC(18,2) null,DCONV_FCTR NUMERIC(18,2) null";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "ALTER TABLE AddlessLineItem ADD FC_AMT NUMERIC(18,2) NULL,NCONV_FCTR NUMERIC(18,2) null,DCONV_FCTR NUMERIC(18,2) null";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "ALTER TABLE TaxAssasable ADD FC_AssableValue NUMERIC(18,2) NULL,FC_VatAmt NUMERIC(18,2) NULL,NCONV_FCTR NUMERIC(18,2) null,DCONV_FCTR NUMERIC(18,2) null";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataTable dtt = new DataTable();
                        SqlCommand cm = new SqlCommand("Select max(ficode),gcode from Company group by gcode", CON);
                        adp.SelectCommand = cm;
                        adp.Fill(dtt);
                        string sqlstr = "";
                        for (int i = 0; i <= dtt.Rows.Count - 1; i++)
                        {
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','9','1018','Multi Currency','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','8','1018','Multi Currency','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','SR','1018','Multi Currency','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                            sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','PR','1018','Multi Currency','False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                        }
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('40010422200','40010422000','West Bengal','West_Bengal',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "Insert into menutable values('40010422210','40010422200','WB VAT PartI/II/III','WB_VAT_Part_I/II/III',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD Invoice_Preparetion Varchar(50) Null,Removal_Date Varchar(50) Null,Removal_Time Varchar(50) Null", CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string strvchlock = "create table vchlock(FICode char(10) not null,GCODE char(10) not null,VTYPE char(1) not null,T_ENTRY char(2) not null,VOUCHER numeric not null,";
                        strvchlock = strvchlock + "[AutoIncre] [numeric](18, 0) IDENTITY(1,1) NOT NULL,USER_VCH	varchar(100),EDITFLAG char(1),USERCODE varchar(6),MODIFIED bit,ZEROFLG char(1),ViewFlag bit,Trans_Type char(10) Null,Cancel_Flag bit Null,";
                        strvchlock = strvchlock + "primary key clustered(FICode,GCODE,VTYPE,T_ENTRY,VOUCHER,[AutoIncre]))";
                        SqlCommand cmd = new SqlCommand(strvchlock, CON);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        { }
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "ALTER TABLE vchlock ADD Computer_Name Varchar(100)null,Status Varchar(50) null,Des_Code Varchar(50) null";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = " alter table BillAdditionalDetails alter column Weight varchar(50) null ";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "";
                        sqlstr = "ALTER TABLE vchlock ADD Trans_Date datetime not null DEFAULT(getdate())";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('60160000000','60000000000','Transaction Trail','Transaction_Trail',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);

                        //UpdateMethods.Mid_DELETE_COMPANYUpdate();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('60170000000','60000000000','Migrate From WinAccord','MigrateFromWinAccord',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);

                        //UpdateMethods.Mid_DELETE_COMPANYUpdate();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "ALTER TABLE DATA ADD MigratedData bit";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "ALTER TABLE IDATA ADD MigratedData bit";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataTable dtt = new DataTable();
                        SqlCommand cm = new SqlCommand("select max(ficode)as Ficode,gcode,t_entry,Desccode from TypeDoc where t_entry in('OS','n','9','OP','a','8' ) group by gcode,t_entry,Desccode", CON);
                        adp.SelectCommand = cm;
                        adp.Fill(dtt);
                        string sqlstr = "";
                        for (int i = 0; i <= dtt.Rows.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                if (Convert.ToString(dtt.Rows[i]["t_entry"]) == Convert.ToString(dtt.Rows[i - 1]["t_entry"]))
                                {
                                    if (Convert.ToString(dtt.Rows[i]["Desccode"]) == Convert.ToString(dtt.Rows[i - 1]["Desccode"]))
                                    {
                                        sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','1019','Multiple Sales A/C','False','False')";
                                        edpcom.RunCommand(sqlstr, CON);
                                    }
                                }
                                else
                                {
                                    sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','1019','Multiple Sales A/C','False','False')";
                                    edpcom.RunCommand(sqlstr, CON);
                                }
                            }
                            else
                            {
                                sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','1019','Multiple Sales A/C','False','False')";
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','" + dtt.Rows[i][3] + "','1019','True', 'False','True')";
                            edpcom.RunCommand(sqlstr, CON);
                        }
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "update VATMaster set VAT_DESC='Output VAT @ 3.84%' where STATE_CODE=19 and VAT_CODE=1100";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('40010422220','40010422200','CST Reports','CST_Reports',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('40020501000','40020500000','Transaction','Transaction',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE VCHR ADD BRNCH_CODE NUMERIC(18,0) NULL ", CON);

                        string str = "CREATE TABLE [CCMAST] (FICODE CHAR(10) NOT NULL,GCODE CHAR(10) NOT NULL,CC_TYPE VARCHAR(20) NOT NULL,";
                        str = str + "CC_CODE NUMERIC(18,0) NOT NULL,CC_DESC VARCHAR(150) NOT NULL,PLV_CODE NUMERIC(18,0) NOT NULL,CC_ALIAS VARCHAR(50) NULL,";
                        str = str + "CC_LEV NUMERIC(18,0) NULL,ALLOW_TRAN BIT NULL,PRIMARY KEY CLUSTERED(FICODE,GCODE,CC_TYPE,CC_CODE))";
                        edpcom.RunCommand(str, CON);

                        str = "CREATE TABLE [IGROUP] (FICODE CHAR(10) NOT NULL,GCODE CHAR(10) NOT NULL,PCODE NUMERIC(18,0) NOT NULL,";
                        str = str + "SGROUP NUMERIC(18,0) NOT NULL,PDESC VARCHAR(150) NULL,PRIMARY KEY CLUSTERED(FICODE,GCODE,PCODE,SGROUP))";
                        edpcom.RunCommand(str, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('40010120000','40010100000','BRS Report','BRS_Report',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);

                        //UpdateMethods.Mid_DELETE_COMPANYUpdate();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string strdb = "";
                        strdb = "CREATE LOGIN edp" + "\r\n";
                        strdb = strdb + " WITH PASSWORD =N'2477147edp', CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;" + "\r\n";
                        strdb = strdb + " USE AccordFour;" + "\r\n";
                        strdb = strdb + " CREATE USER edp FOR LOGIN edp;" + "\r\n";
                        strdb = strdb + " USE AccordFour" + "\r\n";
                        strdb = strdb + " EXEC sp_addrolemember N'db_owner', N'edp'" + "\r\n";
                        edpcom.RunCommand(strdb, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('40020401000','40020400000','Vat Computation','Vat_Computation',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);

                        //UpdateMethods.Mid_DELETE_COMPANYUpdate();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "update TypeDoc_Config set Script='Dos full Page Invoice' where Script='Standard Bill'";
                        edpcom.RunCommand(sqlstr, CON);
                        //UpdateMethods.Copy_AccUpdateParty();
                    }
                    catch { }
                }
                //if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                //{
                //    try
                //    {
                //        UpdateMethods.PRODUCT_COPY(CON);
                //    }
                //    catch { }
                //}
                //if (Cbuild_date < Convert.ToDateTime("01/03/13"))
                //{
                //    try
                //    {
                //        string sqlstr = "Insert into menutable values('60180000000','60000000000','Hot Keys Setting','HotKeysSetting',1,' ',' ',0)";
                //        edpcom.RunCommand(sqlstr, CON);
                //    }
                //    catch { }
                //}//40010402000
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('50120100000','50120000000','Account Import','AccountImport',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "Insert into menutable values('50120200000','50120000000','Stock Import','StockImport',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "Delete From MenuTable Where MENUCODE='40020401000'";
                        edpcom.RunCommand(sqlstr, CON);

                        sqlstr = "Insert into menutable values('40020401000','40020400000','Party Wise Product Wise(Sales)','PartyWiseProductWise',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "Insert into menutable values('40020402000','40020400000','Sales Register Rpt','SalesRegisterRpt',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "Insert into menutable values('40020403000','40020400000','Purchese Register Rpt','PurcheseRegisterRpt',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        //UpdateMethods.PRODUCT_COPY(CON);
                        UpdateMethods.Currency_COPY(CON);
                        //UpdateMethods.UserProfile_COPY(CON);
                        //UpdateMethods.BRANCH_COPY(CON);
                        //UpdateMethods.CONFIGARATION_ALL_COPY(CON);
                        UpdateMethods.CONSIGNING_PARTY_COPY(CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('40010422001','40010400000','Tax Register','tax register',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);

                        sqlstr = "Insert into menutable values('40020404000','40020400000','Party Wise Product Wise(Purchese)','PartyWiseProductWisePurchase',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE IGLMST ADD Excise_GLCODE numeric(18,0) Null,Excise_Per numeric(18,2) Null,E_Cess_GLCODE numeric(18,0) Null,E_Cess_Per numeric(18,2) Null,SHE_Cess_GLCODE numeric(18,0) Null,SHE_Cess_Per numeric(18,2) Null", CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        //string sqlstr = "ALTER TABLE itran ADD PaperConsume bit null,QtyRound bit null";
                        //edpcom.RunCommand(sqlstr, CON);

                        string sqlstr = "UPDATE WACCOPTN SET OPTION_DESC='Excise Applicable on Item' Where OPTION_CODE='3010500000'";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        string sqlstr = "ALTER TABLE iglmst ADD TariffHeading varchar(200) null";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD InvoiceIssueDate Varchar(50) Null", CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/03/13"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE Itran ADD Item_Note Varchar(max) Null", CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("28/03/13"))
                {
                    try
                    {
                        string sqlstr = "Insert into menutable values('40020101060','40020101000','WB Vat Declaration','WB_Vat_Declaration',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("29/03/13"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD InvoiceIssueTime Varchar(50) Null", CON);
                    }
                    catch { }
                }
                //if (Cbuild_date < Convert.ToDateTime("1/04/13"))
                //{
                //    try
                //    {
                //        UpdateMethods.CONFIGARATION_ALL_COPY(CON);
                //    }
                //    catch { }
                //}
                //if (Cbuild_date < Convert.ToDateTime("02/04/13"))
                //{
                //    try
                //    {
                //        UpdateMethods.TaxVat(CON);
                //        //UpdateMethods.Copy_AccUpdateParty();
                //    }
                //    catch { }
                //}
                //if (Cbuild_date < Convert.ToDateTime("02/04/13"))
                //{
                //    try
                //    {
                //        UpdateMethods.TaxVat(CON);
                //        UpdateMethods.AlterCompanyTriggerForLedger(CON);
                //        UpdateMethods.Copy_AccUpdateParty();
                //    }
                //    catch { }
                //}

                //if (Cbuild_date < Convert.ToDateTime("04/04/13"))
                //{
                //    try
                //    {
                //        UpdateMethods.Mid_DELETE_COMPANYUpdate();
                //    }
                //    catch { }
                //    //try
                //    //{
                //    //    UpdateMethods.Copy_AccUpdateParty();
                //    //}
                //    //catch { }
                //}

                if (Cbuild_date < Convert.ToDateTime("10/04/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,5,'5090000000','5.9','Can not transact through Supper User',NULL,null,'False',0,0,'5000000000','False')" +
                            " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,5,'5091000000','5.10','Create User with limited rights',NULL,null,'False',0,0,'5000000000','False')";
                            edpcom.RunCommand(str, CON);
                        }
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("11/04/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM GLMST", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = "INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK],[Details],[ACNO])" +
                                " VALUES('" + FICODE + "','" + GCODE + "','L',10,19,10,'ROUND OFF','ROUNDOFF',30,0,0,0,1,0,'0000000000',0,'C','2',0,NULL,NULL,0,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("16/04/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM TypeMast_Config WHERE T_ENTRY='9'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','9','1020','Item Wise Details','False','False')";

                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================
                        //SqlDataAdapter adp = new SqlDataAdapter();
                        //DataSet ds = new DataSet();
                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode FROM TypeDoc_Config WHERE T_ENTRY='9'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','9'," + DescCode + ",'1020','False', 'False','False')";

                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("18/04/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("alter table Branch alter column BRNCH_ADD1 VARCHAR(MAX)", CON);
                        edpcom.RunCommand("alter table Branch alter column BRNCH_ADD2 VARCHAR(MAX)", CON);

                        edpcom.RunCommand("alter table prtyms alter column BAdd1 VARCHAR(MAX)", CON);
                        edpcom.RunCommand("alter table prtyms alter column BAdd2 VARCHAR(MAX)", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("19/04/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD Your_Order_No Varchar(50) Null,Your_Order_Date Varchar(50) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("20/04/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD Payment_Terms Varchar(100) Null,Payment_Date Varchar(20) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("21/04/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE IDATA ADD Consignee_Party_Code Varchar(20) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("22/04/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM TypeMast_Config WHERE T_ENTRY='9'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','9','1021','Consignee Party','False','False')";

                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode FROM TypeDoc_Config WHERE T_ENTRY='9'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','9'," + DescCode + ",'1021','False', 'False','False')";

                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        CON.Close();
                    }
                    catch { }
                }



                //try
                // {
                //     CON.Close();
                //     CON.Open();
                //     string sqlstr = "UPDATE MenuTable set SHORTCUT_KEY ='Ctrl+T' where MENUCODE ='30010201000' and PARENTCODE ='30010200000'";
                //     edpcom.RunCommand(sqlstr, CON);
                //     string sqlstr1 = "UPDATE MenuTable set SHORTCUT_KEY ='Ctrl+B' where MENUCODE ='30010202000' and PARENTCODE ='30010200000'";
                //     edpcom.RunCommand(sqlstr1, CON);
                //     string sqlstr2 = "UPDATE MenuTable set SHORTCUT_KEY ='Ctrl+F5' where MENUCODE ='30010300000' and PARENTCODE ='30010000000'";
                //     edpcom.RunCommand(sqlstr2, CON);
                //     string sqlstr3 = "UPDATE MenuTable set SHORTCUT_KEY ='Ctrl+F7' where MENUCODE ='30020201000' and PARENTCODE ='30020200000'";
                //     edpcom.RunCommand(sqlstr3, CON);
                //     string sqlstr4 = "UPDATE MenuTable set SHORTCUT_KEY ='Shift+F8' where MENUCODE ='30020203000' and PARENTCODE ='30020200000'";
                //     edpcom.RunCommand(sqlstr4, CON);
                //     string sqlstr5 = "UPDATE MenuTable set SHORTCUT_KEY ='Shift+Ctrl+F12' where MENUCODE ='50180000000' and PARENTCODE ='50000000000'";
                //     edpcom.RunCommand(sqlstr5, CON);
                //     string sqlstr6 = "UPDATE MenuTable set SHORTCUT_KEY ='Shift+Ctrl+F3' where MENUCODE ='50211010000' and PARENTCODE ='50211000000'";
                //     edpcom.RunCommand(sqlstr6, CON);
                //     string sqlstr7 = "UPDATE MenuTable set SHORTCUT_KEY ='Shift+Ctrl+F2' where MENUCODE ='50211020000' and PARENTCODE ='50211000000'";
                //     edpcom.RunCommand(sqlstr7, CON);
                //     string sqlstr8 = "UPDATE MenuTable set SHORTCUT_KEY ='Shift+Ctrl+F7' where MENUCODE ='20020201000' and PARENTCODE ='20020200000'";
                //     edpcom.RunCommand(sqlstr8, CON);
                //     string sqlstr9 = "UPDATE MenuTable set SHORTCUT_KEY ='Ctrl+U' where MENUCODE ='20020203000' and PARENTCODE ='20020200000'";
                //     edpcom.RunCommand(sqlstr9, CON);
                //     string sqlstr10 = "UPDATE MenuTable set SHORTCUT_KEY ='Shift+F2' where MENUCODE ='20010100000' and PARENTCODE ='20010000000'";
                //     edpcom.RunCommand(sqlstr10, CON);
                //     string sqlstr11 = "UPDATE MenuTable set SHORTCUT_KEY ='Ctrl+Q' where MENUCODE ='10070100000' and PARENTCODE ='10070000000'";
                //     edpcom.RunCommand(sqlstr11, CON);
                //     string sqlstr12 = "UPDATE MenuTable set SHORTCUT_KEY ='Shift+F12' where MENUCODE ='10060100000' and PARENTCODE ='10060000000'";
                //     edpcom.RunCommand(sqlstr12, CON);
                //     string sqlstr13 = "UPDATE MenuTable set SHORTCUT_KEY ='Ctrl+F10' where MENUCODE ='10030000000' and PARENTCODE ='10000000000'";
                //     edpcom.RunCommand(sqlstr13, CON);
                //     string sqlstr14 = "UPDATE MenuTable set SHORTCUT_KEY ='Ctrl+F3' where MENUCODE ='10020000000' and PARENTCODE ='10000000000'";
                //     edpcom.RunCommand(sqlstr14, CON);

                //     //edpcom.RunCommand("update  prtyms set ACC_ADD1 varchar(max) Null,ACC_ADD2 varchar(max) Null", CON);
                //     //sql = sql + " update MenuTable set SHORTCUT_KEY ='Ctrl+T' where MENUCODE ='30010201000' and PARENTCODE ='30010200000'";
                //     CON.Close();
                // }
                // catch { }


                if (Cbuild_date < Convert.ToDateTime("25/04/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        try
                        {
                            edpcom.RunCommand("DELETE FROM WACCOPTN WHERE SeriesNo IN ('4.15.1','4.15.2','4.15.3','4.15.4','4.15.5','4.15.6','4.15.7','4.15.8','4.15.9','4.15.10','4.15.11','4.15.12','4.15.13','4.15.14','4.15.15','4.15.16','4.15.17')", CON);
                        }
                        catch { }
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4150100000','4.15.1','Print in Half Page',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4150200000','4.15.2','Print Batch No',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4150300000','4.15.3','Extended Company Name in Bill Printing',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4150400000','4.15.4','Supress parallel quantity printing in Bill',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4150500000','4.15.5','Print Free Quantity in Separate Coloumn',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4150600000','4.15.6','Select Ledger Account for Sub Total',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4150700000','4.15.7','Change the SubTotal Annanciation in Export Bill',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4150800000','4.15.8','Enable Box arround Party Details',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4150900000','4.15.9','Enable Party Phone no printing in Sales Bill',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            //str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'41509100000','4.15.10','Enable Lebel printing in Tax Invoice',NULL,null,'False',0,0,'4000000000','False')";
                            //edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'41509200000','4.15.10','Default Invoice Lebel < Tax/ Retail / Invoice >',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'41509300000','4.15.11','Customised Batch / Serial Column Heading',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'41509400000','4.15.12','Print M.R.P [M] / Product Code [P] / Exp Dt [ E] / None [ N]',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'41509500000','4.15.13','Print Item Details',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'41509600000','4.15.14','Print Addless Disc Col',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'41509700000','4.15.15','Print Addless VAT Col',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'41509800000','4.15.16','Print Company Logo',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'41509100000','4.15.17','Enable Lebel printing in Tax Invoice',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);

                        }
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("26/04/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM GLMST WHERE GLCODE=10 AND MTYPE='L'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG_Check");
                        if (ds.Tables["FIG"].Rows.Count > 0)
                            edpcom.RunCommand("DELETE FROM GLMST WHERE GLCODE=10 AND MTYPE='L'", CON);

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM GLMST", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = "INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK],[Details],[ACNO])" +
                                " VALUES('" + FICODE + "','" + GCODE + "','L',10,19,10,'ROUND OFF','ROUNDOFF',30,0,0,0,1,0,'0000000000',0,'C','2',0,NULL,NULL,0,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("29/04/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        try
                        {
                            edpcom.RunCommand("DELETE FROM WACCOPTN WHERE SeriesNo IN ('4.16.1')", CON);
                        }
                        catch { }
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG1");

                        for (int i = 0; i <= ds.Tables["FIG1"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG1"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG1"].Rows[i]["GCODE"]);

                            string str = " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4160100000','4.16.1','voucher report format','Prepared by,sanction by,accounts,recived by',null,'true',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                        }
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("6/05/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM TypeMast_Config WHERE T_ENTRY='9'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','9','1022','Addless Auto Round Off','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode FROM TypeDoc_Config WHERE T_ENTRY='9'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','9'," + DescCode + ",'1022','False', 'False','False')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("07/05/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataTable dtt = new DataTable();
                        SqlCommand cm = new SqlCommand("select max(ficode)as Ficode,gcode,t_entry,Desccode from TypeDoc where t_entry in('OP','a','PI') group by gcode,t_entry,Desccode", CON);
                        adp.SelectCommand = cm;
                        adp.Fill(dtt);
                        string sqlstr = "";
                        for (int i = 0; i <= dtt.Rows.Count - 1; i++)
                        {
                            if (dtt.Rows[i][2].ToString().Trim() == "OP")
                            {
                                try
                                {
                                    sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','OP','1023','ON Vat/Cst Persentage','False','False')";
                                    edpcom.RunCommand(sqlstr, CON);
                                    sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','OP','1024','Print Format','False','False')";
                                    edpcom.RunCommand(sqlstr, CON);
                                    sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','OP','1025','Active Location Name','False','False')";
                                    edpcom.RunCommand(sqlstr, CON);
                                    sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','OP','1026','Item Details','False','False')";
                                    edpcom.RunCommand(sqlstr, CON);
                                }
                                catch { }
                                sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','" + dtt.Rows[i][3] + "','1023','True', 'False','True')";
                                edpcom.RunCommand(sqlstr, CON);
                                sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','" + dtt.Rows[i][3] + "','1024','True', 'False','Stander')";
                                edpcom.RunCommand(sqlstr, CON);
                                sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','" + dtt.Rows[i][3] + "','1025','True', 'False','True')";
                                edpcom.RunCommand(sqlstr, CON);
                                sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','" + dtt.Rows[i][3] + "','1026','True', 'False','True')";
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            else if (dtt.Rows[i][2].ToString().Trim() == "a")
                            {
                                try
                                {
                                    sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','a','1018','ON Vat/Cst Persentage','False','False')";
                                    edpcom.RunCommand(sqlstr, CON);
                                    sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','a','1018','Format','False','False')";
                                    edpcom.RunCommand(sqlstr, CON);
                                    sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','a','1018','Active Location Name','False','False')";
                                    edpcom.RunCommand(sqlstr, CON);
                                    sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','a','1018','Item Details','False','False')";
                                    edpcom.RunCommand(sqlstr, CON);
                                }
                                catch { }
                                sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','" + dtt.Rows[i][3] + "','1023','True', 'False','True')";
                                edpcom.RunCommand(sqlstr, CON);
                                sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','" + dtt.Rows[i][3] + "','1024','True', 'False','Stander')";
                                edpcom.RunCommand(sqlstr, CON);
                                sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','" + dtt.Rows[i][3] + "','1025','True', 'False','True')";
                                edpcom.RunCommand(sqlstr, CON);
                                sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','" + dtt.Rows[i][3] + "','1026','True', 'False','True')";
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            else if (dtt.Rows[i][2].ToString().Trim() == "PI")
                            {
                                try
                                {
                                    sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','PI','1018','Format','False','False')";
                                    edpcom.RunCommand(sqlstr, CON);
                                }
                                catch { }
                                sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','" + dtt.Rows[i][3] + "','1024','True', 'False','Stander')";
                                edpcom.RunCommand(sqlstr, CON);
                            }
                        }
                    }
                    catch
                    {
                        CON.Close();
                    }
                    CON.Close();
                }

                if (Cbuild_date < Convert.ToDateTime("9/05/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();

                        string sqlstr = "Insert into menutable values('30020500000','30020000000','Stock Report','Stock_Report',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);

                        sqlstr = "Insert into menutable values('30020501000','30020500000','Statement','Statement',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);

                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("10/05/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        //New Tentry
                        string sqlstr = " insert into TypeMast values(1,1,'SRC','Sale Return Challan','SaleReturnChallan')";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " insert into TypeMast values(1,1,'FG','FGR','FGR')";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " insert into TypeMast values(1,1,'MIR','MFG Issue Return','MFGIssueReturn')";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " insert into TypeMast values(1,1,'NMR','NON MFG Issue Return','NONMFGIssueReturn')";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " insert into TypeMast values(1,1,'PRC','Purchase Return Challan','PurchaseReturnChallan')";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " insert into TypeMast values(1,1,'MI','MFG Issue','MFGIssue')";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " insert into TypeMast values(1,1,'NMI','Non MFG Issue','NonMFGIssue')";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " insert into TypeMast values(1,1,'FGR','FGR Return','FGRReturn')";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                        //New Tentry
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("11/05/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD Dom_Expo_Remarks varchar(MAX) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("13/05/13"))
                {
                    try
                    {
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataTable dtt = new DataTable();
                        SqlCommand cm = new SqlCommand("select max(ficode)as Ficode,gcode,t_entry,Desccode from TypeDoc where t_entry in('SR','PR') group by gcode,t_entry,Desccode", CON);
                        adp.SelectCommand = cm;
                        adp.Fill(dtt);
                        string sqlstr = "";
                        for (int i = 0; i <= dtt.Rows.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                if (Convert.ToString(dtt.Rows[i]["t_entry"]) == Convert.ToString(dtt.Rows[i - 1]["t_entry"]))
                                {
                                    if (Convert.ToString(dtt.Rows[i]["Desccode"]) == Convert.ToString(dtt.Rows[i - 1]["Desccode"]))
                                    {
                                        sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','1019','Multiple Sales A/C','False','False')";
                                        edpcom.RunCommand(sqlstr, CON);
                                    }
                                }
                                else
                                {
                                    sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','1019','Multiple Sales A/C','False','False')";
                                    edpcom.RunCommand(sqlstr, CON);
                                }
                            }
                            else
                            {
                                sqlstr = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','1019','Multiple Sales A/C','False','False')";
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + dtt.Rows[i][0] + "','" + dtt.Rows[i][1] + "','" + dtt.Rows[i][2] + "','" + dtt.Rows[i][3] + "','1019','False', 'False','False')";
                            edpcom.RunCommand(sqlstr, CON);
                        }
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("14/05/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "update TypeMast set T_ENTRY='SC' where T_entry='SRC'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update TypeMast set T_ENTRY='MR' where T_entry='MIR'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update TypeMast set T_ENTRY='NM' where T_entry='NMR'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update TypeMast set T_ENTRY='PC' where T_entry='PRC'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update TypeMast set T_ENTRY='NI' where T_entry='NMI'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update TypeMast set T_ENTRY='GR' where T_entry='FGR'";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("06/06/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE IGLMST ADD ParalalToBase bit Default('0') Null", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("10/06/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "Update menutable set MENUDESC='Stock Statement',DETAILDESC='Stock_Statement' where  MENUCODE ='30020501000' and PARENTCODE ='30020500000'";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("13/06/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM TypeMast_Config WHERE T_ENTRY='9'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','9','1027','Line Level Discount','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode FROM TypeDoc_Config WHERE T_ENTRY='9'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','9'," + DescCode + ",'1027','False', 'False','False')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("14/06/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('9','SR','PR','8')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1028','Line Item Amount Auto Round Off','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('9','SR','PR','8')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1028','False', 'False','False')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("17/06/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = " alter table AddLess alter column AddLessDESC varchar(max) null ";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " alter table AddlessLineItem alter column AddLessDESC varchar(max) null ";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "ALTER TABLE BillAdditionalDetails ADD CST_Declaration varchar(max) Null";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("18/06/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = " alter table iglmst alter column vatpercent numeric(18,4) null ";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " alter table VATMaster alter column VAT_PERCENT numeric(18,4) null ";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "ALTER TABLE LinkVATGLMST alter column Vat_Per numeric(18,4) Null";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("26/06/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "update bill set partycode=0 where user_vch='C//01709'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update idata set party_code=0 where user_vch='C//01709'";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/06/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM TypeMast_Config WHERE T_ENTRY='9'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','9','1029','Party Details in Cash Memo','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode FROM TypeDoc_Config WHERE T_ENTRY='9'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','9'," + DescCode + ",'1029','False', 'False','No')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("28/06/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('9','SR','PR','8') and gcode=2", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1028','Line Item Amount Auto Round Off','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('9','SR','PR','8')and desccode=1 and gcode=2", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1028','False', 'False','False')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("05/07/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "Insert into menutable values('40010506000','40010500000','Party CheckList','Party CheckList',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("17/07/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        String sqlstr = "ALTER TABLE IGLMST ADD REORDER_LEVEL NUMERIC(18,2) Default('0'),MINIMUM_LEVEL NUMERIC(18,2) Default('0')";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("19/07/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+B' where MENUCODE=30010202000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+F5' where MENUCODE=30010300000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+T' where MENUCODE=30010201000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+P' where MENUCODE=30010106000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Shift+F8' where MENUCODE=30020203000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+I' where MENUCODE=40010201000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+Z' where MENUCODE=40010202000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+Alt+Z' where MENUCODE=40010203000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Shift+Ctrl+F12' where MENUCODE=50180000000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Shift+Ctrl+F3' where MENUCODE=50211010000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Shift+Ctrl+F2' where MENUCODE=50211020000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+F3' where MENUCODE=10020000000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+F10' where MENUCODE=10030000000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Shift+F12' where MENUCODE=10060100000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+Q' where MENUCODE=10070100000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Shift+F2' where MENUCODE=20010100000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+H' where MENUCODE=20010400000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+E' where MENUCODE=20020102000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+R' where MENUCODE=20020103000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Shift+Ctrl+F7' where MENUCODE=20020201000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+U' where MENUCODE=20020203000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set SHORTCUT_KEY='Ctrl+F7',MENUDESC='Details' where MENUCODE=30020201000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set MENUDESC='Budget' where MENUCODE=30010300000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set MENUDESC='Trail Balance' where MENUCODE=30010201000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set MENUDESC='Balance Sheet' where MENUCODE=30010202000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set MENUDESC='Custom Field(Q)' where MENUCODE=30040000000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set MENUDESC='Invoice' where MENUCODE=40010201000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set MENUDESC='Voucher(R)' where MENUCODE=40010202000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set MENUDESC='Tax Invoice' where MENUCODE=40010203000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set MENUDESC='Tax Invoice' where MENUCODE=40010203000";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("20/07/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = " update MenuTable set MENUDESC='Trail Balance(Q)' where MENUCODE=30010201000";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update MenuTable set MENUDESC='Balance Sheet(Q)' where MENUCODE=30010202000";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("25/07/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "alter table vchr alter column NCONV_FCTR numeric(18,4) null";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "alter table vchr alter column DCONV_FCTR numeric(18,4) null";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "alter table ITRAN alter column AMT2 numeric(18,4) null";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "alter table ITRAN alter column RATE2 numeric(18,4) null";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "alter table ITRAN alter column NCONV_FCTR numeric(18,4) null";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "alter table ITRAN alter column CONF_CURR numeric(18,4) null";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("26/07/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('8')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1029','Party Details in Cash Memo','False','False')";
                            str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1012','Set Cash Memo/Bill Active','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('8')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1029','False', 'False','No')";
                            sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1012','False', 'False','False')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("29/07/13"))
                {

                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "Insert into menutable values('60180000000','60000000000','Tran Control Config Print','Tran_Control_Config_Print',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("07/08/13"))
                {
                    try
                    {
                        //UpdateMethods.Typemas_InsUpdate();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("11/08/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = " update idata set DESCCODE='1' where t_entry in('n','a')";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("22/08/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string strdb = "";
                        try
                        {
                            strdb = " update MenuTable set SHORTCUT_KEY='F6' where MENUCODE=20020401000";
                            edpcom.RunCommand(strdb, CON);
                            //strdb = "IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'edp')" + "\r\n";
                            //strdb = strdb + "DROP LOGIN [edp]" + "\r\n";
                            //strdb = strdb + " USE [AccordFour]" + "\r\n";
                            //strdb = strdb + "IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'edp')" + "\r\n";
                            //strdb = strdb + " DROP USER [edp]" + "\r\n";

                            strdb = strdb + "DROP LOGIN [edp]" + "\r\n";
                            strdb = strdb + " USE [AccordFour]" + "\r\n";
                            strdb = strdb + " DROP USER [edp]" + "\r\n";
                            edpcom.RunCommand(strdb, CON);
                        }
                        catch { }

                        strdb = "";
                        strdb = "CREATE LOGIN edp" + "\r\n";
                        strdb = strdb + " WITH PASSWORD =N'2477147edp', CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;" + "\r\n";
                        strdb = strdb + "EXEC sys.sp_addsrvrolemember N'edp', N'sysadmin';" + "\r\n";
                        strdb = strdb + " USE AccordFour;" + "\r\n";
                        strdb = strdb + " CREATE USER edp FOR LOGIN edp;" + "\r\n";
                        strdb = strdb + " USE AccordFour" + "\r\n";
                        strdb = strdb + " EXEC sp_addrolemember N'db_owner', N'edp'" + "\r\n";
                        edpcom.RunCommand(strdb, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("23/08/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        String sqlstr = "ALTER TABLE IGLMST ADD Opening_Amt NUMERIC(18,2) Default('0')";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("04/09/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ALTER column Delivery_At Varchar(MAX) Null ", CON);
                        string strdb = " update MenuTable set SHORTCUT_KEY='Ctrl+F6' where MENUCODE=20020401000";
                        edpcom.RunCommand(strdb, CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("06/09/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        try
                        {
                            edpcom.RunCommand("DELETE FROM WACCOPTN WHERE SeriesNo IN ('4.10.3','4.10.4')", CON);
                        }
                        catch { }
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4100300000','4.10.3','Additional Header & Footer details for Outstanding Form',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4100400000','4.10.4','Additional Header & Footer details for Outstanding Letter',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                        }
                        string sqlstr = "Insert into menutable values('40010410300','40010410000','Outstanding Letters Bills','OutstandingLettersBills',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "Insert into menutable values('40010408030','40010408000','OS Letters Forms','OSLettersForms',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "ALTER TABLE BillAdditionalDetails ADD Form_No Varchar(50) Null ";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "CREATE TABLE [NarrationDetails] (FICODE CHAR(10) NOT NULL,GCODE CHAR(10) NOT NULL,Narr_Type VARCHAR(10) NOT NULL,Narr_ID NUMERIC(18,0) NOT NULL,";
                        sqlstr = sqlstr + "Narr_Desc VARCHAR(max) NULL,PRIMARY KEY CLUSTERED(FICODE,GCODE,Narr_Type,Narr_ID))";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("07/09/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "ALTER TABLE BillAdditionalDetails ADD Form_Name Varchar(50) Null ";
                        edpcom.RunCommand(sqlstr, CON);
                        string strdb = " update MenuTable set MENUDESC='Form' where MENUCODE=40010408000";
                        edpcom.RunCommand(strdb, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("08/09/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "Insert into menutable values('40020301000','40020300000','PO Register','PORegister',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("11/09/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE LocationMaster ADD BRNCH_CODE numeric(18,0) Null", CON);
                        edpcom.RunCommand("ALTER TABLE IDATA ADD LOC_FROM numeric(18,0) Null", CON);
                        edpcom.RunCommand("ALTER TABLE IDATA ADD LOC_TO numeric(18,0) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("12/09/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("UPDATE MenuTable set MENUDESC = 'General' , DETAILDESC = 'General' where MENUCODE = 40020301000 and PARENTCODE = 40020300000", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020301010','40020301000','Material In-Out','Material In-Out', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020301020','40020301000','Location Transfer','Location Transfer', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020302000','40020300000','Manufacturing(R)','Manufacturing(R)', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020302010','40020302000','Consumption','Consumption', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020302020','40020302000','Contractor','Contractor', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020302030','40020302000','Finished Goods','Finished Goods', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020302040','40020302000','Issue','Issue', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020302050','40020302000','Work-In-Progress','Work-In-Progress', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020302060','40020302000','Plant Vector','Plant Vector', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020303000','40020300000','Trading(R)','Trading(R)', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020303010','40020303000','D Note','D Note', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020303030','40020303000','Unbilled D Note','Unbilled D Note', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020303040','40020303000','PO Register','PO Register', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020304000','40020300000','Production(R)','Production(R)', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020304010','40020304000','Formula','Formula', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020304020','40020304000','Yield','Yield', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020304030','40020304000','Day Book','Day Book', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020305000','40020300000','Excise','Excise', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020305010','40020305000','RG23A Part I','RG23A Part I', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020305020','40020305000','RG23A Part II','RG23A Part II', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020305030','40020305000','RG23C Part I','RG23C Part I', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020305040','40020305000','RG23C Part II','RG23C Part II', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020305050','40020305000','P L A','P L A', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020305060','40020305000','Form IV','Form IV', 1 , 0 )", CON);
                        edpcom.RunCommand("UPDATE MenuTable set MENUDESC = 'Purchase Register Rpt' , DETAILDESC = 'Purchase Register Rpt' where MENUCODE = 40020403000 and PARENTCODE = 40020400000", CON);
                        edpcom.RunCommand("UPDATE MenuTable set MENUDESC = 'Party Wise Product Wise(Purchase)' , DETAILDESC = 'Party Wise Product Wise(Purchase)' where MENUCODE = 40020404000and PARENTCODE = 40020400000", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("13/09/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();

                        string sqlstr = "delete from TypeMast_Config where OPTION_CODE='1027'";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";
                        sqlstr = "delete from TypeDoc_Config where OPTION_CODE='1027'";
                        edpcom.RunCommand(sqlstr, CON); sqlstr = "";


                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM TypeMast_Config WHERE T_ENTRY='9'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");
                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','9','1027','Line Level Discount','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode FROM TypeDoc_Config WHERE T_ENTRY='9'", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','9'," + DescCode + ",'1027','False', 'False','False')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        edpcom.RunCommand("UPDATE MenuTable set MENUDESC = 'Items/Products' , DETAILDESC = 'Items/Products' where MENUCODE = 40020501000 and PARENTCODE = 40020500000", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020502000','40020500000','Item Price List','Item Price List', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020503000','40020500000','Transaction','Transaction', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020405000','40020400000','Outstanding(MIS)','Outstanding(MIS)', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020405010','40020405000','Order','Order', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020406000','40020400000','Analysis(MIS)','Analysis(MIS)', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020406010','40020406000','Productwise','Productwise', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020406020','40020406000','Cost Of Sales','Cost Of Sales', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020407000','40020400000','Profitability','Profitability', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020408000','40020400000','Production Planning','Production Planning', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020409000','40020400000','Product Margin','Product Margin', 1 , 0 )", CON);
                        edpcom.RunCommand("UPDATE MenuTable set MENUDESC = 'Purchase Planning' , DETAILDESC = 'Purchase Planning' where MENUCODE = 40020410000 and PARENTCODE = 40020400000", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020410000','40020400000','Purchase Planning','Purchase Planning', 1 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020411000','40020400000','Stock Ageing','Stock Ageing', 1 , 0 )", CON);

                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("16/09/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("Drop table PROCESS", CON);
                        string strProcess = "CREATE TABLE PROCESS (FICode char(10)not null,GCODE char(10) not null,PROC_CODE numeric (18,0) NOT NULL,PROC_DESC VARCHAR(60),PLV_CODE numeric (18,0),PROC_LEV numeric (18,0),primary key clustered (FICode,GCODE,PROC_CODE));";
                        edpcom.RunCommand(strProcess, CON);

                        edpcom.RunCommand("Drop table FORMULA", CON);
                        string strFormula = "CREATE TABLE FORMULA (FICode char(10)not null,GCODE char(10) not null,PROC_CODE numeric (18,0) NOT NULL,MTYPE VARCHAR(10) NOT NULL,AUTOINCRE int IDENTITY(1,1) not null,PCODE numeric (18,0),QTY numeric (18,2),UCODE numeric (18,0),PQTY numeric (18,0),PUCODE numeric (18,0),COST_PERC numeric (18,2),Series_ID numeric (18,0),BaseQty numeric(18,0),primary key clustered (FICode,GCODE,PROC_CODE,MTYPE,AUTOINCRE))";
                        edpcom.RunCommand(strFormula, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("17/09/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("UPDATE MenuTable set MENUDESC = 'Inter Financial Analysis' , DETAILDESC = 'InterFinancialAnalysis' where MENUCODE = 50040000000 and PARENTCODE = 50000000000", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("21/09/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE iglmst ADD product_Unit_Type varchar(30) null", CON);
                        edpcom.RunCommand("ALTER TABLE iglmst ADD Parallal_Unit_Code numeric(18,0) null", CON);
                        edpcom.RunCommand("ALTER TABLE itran ADD ParalalToBase bit null", CON);
                        edpcom.RunCommand("ALTER TABLE itran ADD product_Type varchar(30) null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("26/09/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("update TypeMast_Config set OPTION_DESC ='Multiple Purchase A/C' where OPTION_CODE ='1019' AND T_ENTRY  in('8','a','PR')", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("30/09/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE idata ADD REF_LOG_NO varchar(30) null", CON);
                        edpcom.RunCommand("ALTER TABLE idata ADD Process_Code numeric(18,0) null", CON);
                        edpcom.RunCommand("ALTER TABLE itran ADD Loss_Percent varchar(10) null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("01/10/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        try
                        {
                            edpcom.RunCommand("DELETE FROM WACCOPTN WHERE SeriesNo IN ('4.10.5')", CON);
                        }
                        catch { }
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4100500000','4.10.5','Additional Header & Footer details for Party Statement',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                        }

                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("04/10/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();

                        edpcom.RunCommand("DROP TABLE Backup_Restore_Information", CON);

                        string str = "CREATE TABLE Backup_Restore_Information (FICODE char(10) NOT NULL ,GCODE char(10) NOT NULL ,";
                        str = str + "BR_Type char(10) NOT NULL,Backup_No numeric(18,0) Default(1) NOT NULL,";
                        str = str + "Backup_Date datetime NULL,Restore_No varchar(50) Default('0') NOT NULL,";
                        str = str + "Restore_Date datetime NULL,Serial_No varchar(50) NULL,";
                        str = str + "EXE_Ver varchar(50) NULL,Build_Date datetime NULL,";
                        str = str + "Status varchar(50) NULL,Remarkes varchar(50) NULL,";
                        str = str + "primary key clustered(FICODE,GCODE,BR_Type,Backup_No,Restore_No))";
                        try
                        {
                            edpcom.RunCommand(str, CON);
                        }
                        catch { }
                        CON.Close();
                    }
                    catch { }


                }

                if (Cbuild_date < Convert.ToDateTime("07/10/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM GLMST", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            //edpcom.RunCommand("DELETE FROM glmst WHERE  glcode=10 and LDESC='ROUND OFF' and ficode='" + FICODE + "',gcode='" + GCODE + "'", CON);

                            string str = "INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK],[Details],[ACNO])" +
                                " VALUES('" + FICODE + "','" + GCODE + "','L',10,19,10,'ROUND OFF','ROUNDOFF',30,0,0,0,1,0,'0000000000',0,'C','2',0,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("09/10/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE iglmst ADD Opening_Qty_Second numeric(18,2) null", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("10/10/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("update TypeMast_Config set OPTION_DESC ='Multiple Purchase A/C' where OPTION_CODE ='1019' AND T_ENTRY  in('OP')", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("22/10/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        try
                        {
                            edpcom.RunCommand("DELETE FROM WACCOPTN WHERE SeriesNo IN ('4.16.1')", CON);
                        }
                        catch { }
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG1");

                        for (int i = 0; i <= ds.Tables["FIG1"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG1"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG1"].Rows[i]["GCODE"]);

                            string str = " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4160100000','4.16.1','voucher report format','Prepared by,sanction by,accounts,received by',null,'true',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                        }
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("23/10/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE iglmst ADD Rate_unit_Code numeric(18,0) null, Method varchar(50) null,Rate_Type varchar(50) Null", CON);
                        edpcom.RunCommand("Update iglmst set  Method ='FIFO',Rate_Type ='Cost Price(CP)'", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("01/11/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE iglmst ADD Parallel_Unit_Conversion numeric(18,2) null ,Rate_Unit_Conversion numeric(18,2) null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("02/11/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE glmst ADD AOC_Charges numeric(18,4) null ,Link_Lib numeric(18,4) null", CON);
                        edpcom.RunCommand("ALTER TABLE idata ADD Multi_Linkvch varchar(100) null ", CON);
                        //UpdateMethods.TaxVat(CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("06/11/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "Insert into menutable values('50230000000','50000000000','Auto Bill Generate process','AutoBillgenerateprocess',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }

                if (Cbuild_date < Convert.ToDateTime("18/11/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "update narr set GDATE2='' where NTYPE='C' and GDATE=GDATE2";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("19/11/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "update menutable set SHORTCUT_KEY='Alt+F3' Where MENUCODE='60150100000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set SHORTCUT_KEY='F6' Where MENUCODE='20020301030'";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }

                if (Cbuild_date < Convert.ToDateTime("02/12/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('9')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1031','Document Title','False','Tax Invoice')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('9')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1031','True','False', 'Tax Invoice')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("04/12/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "update TypeMast set T_ENTRY='SC',TRAN_HEAD='SRChallan' where T_entry='SRC'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update TypeMast set T_ENTRY='MR' where T_entry='MIR'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update TypeMast set T_ENTRY='NM' where T_entry='NMR'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update TypeMast set T_ENTRY='PC',TRAN_HEAD='PRChallan' where T_entry='PRC'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update TypeMast set T_ENTRY='NI' where T_entry='NMI'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " update TypeMast set T_ENTRY='GR' where T_entry='FGR'";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("05/12/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE narr ADD CHQ_ROWINDEX numeric(18,0) null ", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("09/12/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.Copy_AccUpdateParty();
                        CON.Close();
                    }
                    catch
                    {
                        CON.Close();
                    }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.Copy_AccUpdate();
                        CON.Close();
                    }
                    catch { CON.Close(); }

                    //try
                    //{
                    //    CON.Close();
                    //    CON.Open();
                    //    UpdateMethods.PRODUCT_COPY(CON);
                    //    CON.Close();
                    //}
                    //catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("10/12/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        //UpdateMethods.TaxVat(CON);
                        UpdateMethods.UpdateCurrency(CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("11/12/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.BRANCH_COPY(CON);
                        CON.Close();
                    }
                    catch
                    {
                        CON.Close();
                    }

                    //try
                    //{
                    //    CON.Close();
                    //    CON.Open();
                    //    UpdateMethods.UserProfile_COPY(CON);
                    //    CON.Close();
                    //}
                    //catch
                    //{
                    //    CON.Close();
                    //}
                }
                if (Cbuild_date < Convert.ToDateTime("26/12/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE itran ADD TotalVolume varchar(50) null ,TotalQty varchar(50) null", CON);
                        CON.Close();
                    }
                    catch { }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM GLMST", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            //edpcom.RunCommand("DELETE FROM glmst WHERE  glcode=10 and LDESC='ROUND OFF' and ficode='" + FICODE + "',gcode='" + GCODE + "'", CON);

                            string str = "INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK],[Details],[ACNO])" +
                                " VALUES('" + FICODE + "','" + GCODE + "','L',10,19,10,'ROUND OFF','ROUNDOFF',30,0,0,0,1,0,'0000000000',0,'C','2',0,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { CON.Close(); }
                        }
                        CON.Close();
                    }
                    catch { CON.Close(); }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE idata ADD Reff_Party_Name varchar(80) null", CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "Insert into menutable values('40020208000','40020200000','Party Wise Paper Stock','PWPS',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "Insert into menutable values('40020209000','40020200000','Party Wise Paper Receipt','PWPS',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "Insert into menutable values('40020210000','40020200000','Outstanding Orders','OO',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "Insert into menutable values('40020211000','40020200000','Stock Out [Challan]','SOC',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "Insert into menutable values('40020600000','40020000000','Party Details','PD',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);

                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("29/12/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "CREATE TABLE [UserControl]([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,[UGcode] [char](10) NOT NULL,[SuperUser] [char](10) NOT NULL,[USER_CODE] [char](10) NOT NULL,[USGcode] [char](10) NULL PRIMARY KEY CLUSTERED ([Ficode] ASC,[Gcode] ASC,[UGcode] ASC,[SuperUser] ASC,[USER_CODE] ASC))";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("31/12/13"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();

                        edpcom.RunCommand("ALTER TABLE itran ADD Bool_Code varchar(10) null", CON);

                        string BATCH_MAST = "CREATE TABLE BTCHMAST (FICode char(10) not null,GCODE char(10) not null,BSTYPE VARCHAR(10) NOT NULL,PCODE NUMERIC (18,0) NOT NULL,AUTOINCRE numeric IDENTITY(1,1) not null,BATCHNO VARCHAR(100) NOT NULL,MFG_DATE DATETIME NULL,EXP_DATE DATETIME NULL,QTY_RECD numeric (18,4) NULL,QTY_ISSUED numeric (18,4),CURR_QTY numeric(18,4),UCODE NUMERIC (18,0),SERIALNO VARCHAR (50),STATUS BIT,SWITCH VARCHAR (20),RATE NUMERIC (18,4),PRATE NUMERIC (18,4),MRP NUMERIC (18,4),primary key clustered(FICode,GCODE,BSTYPE,AUTOINCRE,PCODE,BATCHNO))";
                        edpcom.RunCommand(BATCH_MAST, CON);

                        string BATCH_TRAN = "CREATE TABLE BTCHTRAN (FICode char(10) not null,GCODE char(10) not null,BSTYPE VARCHAR(10) NOT NULL,T_ENTRY char (20) NOT NULL,VOUCHER NUMERIC (18,0) NOT NULL,PCODE NUMERIC (18,0) NOT NULL,AUTOINCRE numeric IDENTITY(1,1) not null,BATCHNO VARCHAR(100) NOT NULL,USER_VCH VARCHAR(50),MFG_DATE DATETIME NULL,EXP_DATE DATETIME NULL,INOUT VARCHAR (10),SERFROM VARCHAR (50),SERTO VARCHAR (50),QTY numeric (18,4) NULL,QTY2 numeric (18,4),UCODE NUMERIC (18,0),STATUS BIT,SWITCH VARCHAR (20),RATE NUMERIC (18,4),RUCODE NUMERIC (18,0),PRATE NUMERIC (18,4),ITEMNO NUMERIC (18,0),MRP NUMERIC (18,4),primary key clustered(FICode,GCODE,BSTYPE,T_ENTRY,VOUCHER,PCODE,AUTOINCRE,BATCHNO))";
                        edpcom.RunCommand(BATCH_TRAN, CON);

                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("03/01/14"))
                {
                    try
                    {
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        CON.Close();
                        CON.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * from UserControl", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "UC");
                        if (ds.Tables["UC"].Rows.Count == 0)
                        {
                            cmd = new SqlCommand("SELECT distinct ficode from FICODEGEN", CON);
                            adp.SelectCommand = cmd;
                            adp.Fill(ds, "fcode");
                            for (int aa = 0; aa <= ds.Tables["fcode"].Rows.Count - 1; aa++)
                            {
                                int fi = Convert.ToInt32(ds.Tables["fcode"].Rows[aa]["ficode"]);
                                try
                                {
                                    ds.Tables["UserCode"].Clear();
                                }
                                catch { }
                                cmd = new SqlCommand("SELECT * from pasword where  user_code not in(2,3)", CON);
                                adp.SelectCommand = cmd;
                                adp.Fill(ds, "UserCode");
                                for (int i = 0; i <= ds.Tables["UserCode"].Rows.Count - 1; i++)
                                {
                                    cmd = new SqlCommand("insert into UserControl(Ficode,Gcode,UGcode,USGcode,SuperUser,USER_CODE) values('" + fi + "','1','1','0','1','" + ds.Tables["UserCode"].Rows[i]["USER_CODE"] + "')", CON);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    catch { }
                }
                //if (Cbuild_date < Convert.ToDateTime("04/01/14"))
                //{
                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        UpdateMethods.TrigCompOnInsUpdate(CON);
                //        CON.Close();
                //    }
                //    catch { }
                //}
                if (Cbuild_date < Convert.ToDateTime("08/01/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "update TypeMast set TRAN_HEAD='Rcpt' where T_entry='1'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='Pymt' where T_entry='2'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='Jtnl' where T_entry='3'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='CrNT' where T_entry='4'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='Cntr' where T_entry='5'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='ChRt' where T_entry='6'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='DbNt' where T_entry='7'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='Prch' where T_entry='8'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='Sale' where T_entry='9'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='SRet' where T_entry='SR'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='PRet' where T_entry='PR'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='SkIN' where T_entry='SI'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='PGrn' where T_entry='a'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='SRCh' where T_entry='SC'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='FnGR' where T_entry='FG'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='MfRT' where T_entry='MR'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='NMRT' where T_entry='NM'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='SDnt' where T_entry='n'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='PRCh' where T_entry='PC'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='MIss' where T_entry='MI'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='NMfg' where T_entry='NI'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='SkOT' where T_entry='SO'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='FgRT' where T_entry='GR'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='Pord' where T_entry='OP'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='Sord' where T_entry='OS'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update TypeMast set TRAN_HEAD='PuIn' where T_entry='PI'";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                        //UpdateMethods.Typemas_InsUpdate();
                    }
                    catch { CON.Close(); }
                }

                //if (Cbuild_date < Convert.ToDateTime("14/01/14"))
                //{
                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        //UpdateMethods.TaxVat(CON);
                //        //UpdateMethods.UpdateTrigComWACCOPTN(CON);
                //        CON.Close();
                //    }
                //    catch { }
                //}

                if (Cbuild_date < Convert.ToDateTime("17/01/14"))
                {
                    CON.Close();
                    CON.Open();
                    try
                    {
                        edpcom.RunCommand("DELETE FROM TypeDoc_Config WHERE OPTION_CODE='1011' and T_ENTRY='SR'", CON);
                    }
                    catch { }
                    CON.Close();
                }
                if (Cbuild_date < Convert.ToDateTime("22/01/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE IGLMST ADD CUR_QTY_SECOND numeric(18,2) null", CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("25/01/14"))
                {
                    try
                    {
                        string aa = edpcom.EnvironMent_Envelope;
                        CON.Close();
                        CON.Open();
                        string sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='20010303000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='20010305000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='20010306000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='20010400000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='20010500000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='20010600000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='20020103000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='20020105000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='20020303000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='20020403000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='30010105000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='30010108000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='30010109000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='30010110000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='30010300000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='30010501000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='30010502000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='30010503000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='30020300000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='30020400000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010110000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010204000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010205000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010305000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010306000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010307000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010308000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010309000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010401000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010404030'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010407000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010408020'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010409000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010411000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010411010'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010411020'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010412000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010412010'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010412020'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010414000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010415000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010416000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010416010'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010416020'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010416030'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010416040'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010416050'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010416060'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010417000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010418000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010418010'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40010418020'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020101010'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020201020'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020204020'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020205000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020206000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020206010'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020211000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020301000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020301010'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020301020'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020302000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020302010'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020302020'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020302030'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020302040'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020302050'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020302060'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020304020'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020304030'";
                        edpcom.RunCommand(sqlstr, CON);

                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020305000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020305010'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020305020'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020305030'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020305040'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020305050'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020305060'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020405010'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020406020'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020407000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020408000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020409000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020410000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020411000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020501000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='40020502000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='50030000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='50060000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='50090000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='50110000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='50150000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='50170000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='50070200000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='50160000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='50160100000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='50160200000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='50160300000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60010000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60030000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60040000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='6005000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60060000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60070000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60080000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60110000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60140000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60120100000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60120400000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60120500000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60120600000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60120700000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60120800000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60120900000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60121000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60121100000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60130000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60130100000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60130200000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "update menutable set ENABLE_MENU='False' Where MENUCODE='60130300000'";
                        edpcom.RunCommand(sqlstr, CON);

                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("27/01/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.Extra_Procedure_Drop(CON);
                        UpdateMethods.MENU_GENERATE(CON);
                        UpdateMethods.MENU_DISPLAY(CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                //if (Cbuild_date < Convert.ToDateTime("27/01/14"))
                //{
                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        SqlCommand com = new SqlCommand("MENU_DISPLAY", CON);
                //        com.CommandType = CommandType.StoredProcedure;
                //        SqlParameter MENU_FLAG = new SqlParameter("@ME", "FALSE");
                //        SqlParameter MENU_PARENT = new SqlParameter("@MC", "50020000000");
                //        com.Parameters.Add(MENU_FLAG);
                //        com.Parameters.Add(MENU_PARENT);
                //        com.ExecuteNonQuery();
                //        CON.Close();
                //    }
                //    catch { CON.Close(); }
                //}

                if (Cbuild_date < Convert.ToDateTime("28/01/14"))
                {
                    try
                    {
                        SqlCommand mycmd = new SqlCommand();
                        CON.Close();
                        CON.Open();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020208000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020209000 ", CON);
                        mycmd.ExecuteNonQuery();
                        CON.Close();
                        if (edpcom.EnvironMent_Envelope == "Brand Purchase")
                        {
                            CON.Close();
                            CON.Open();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010302000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010303000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010305000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010306000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010500000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010600000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20020301000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20020303000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20020400000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20020500000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20030000000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20040000000 ", CON);
                            mycmd.ExecuteNonQuery();
                            CON.Close();
                        }
                        else if (edpcom.EnvironMent_Envelope == "Petrol")
                        {
                            try
                            {
                                CON.Close();
                                CON.Open();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=50230000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                CON.Close();
                            }
                            catch { }
                        }
                        else if (edpcom.EnvironMent_Envelope == "PRINTING")
                        {
                            try
                            {
                                CON.Close();
                                CON.Open();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010303000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010305000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010306000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010400000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010500000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010600000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20020403000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20030000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20040000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30010105000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30010108000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30010109000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30010110000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30010300000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30020300000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30020400000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30030000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30040000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30050000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010107000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010108000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010109000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010110000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010204000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010205000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010206000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010304000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010305000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010306000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010307000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010308000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010309000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010400000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020500000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030400000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40040000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030300000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=40020208000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=40020209000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50050000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50060000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50070000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50110000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50120000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50150000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50160000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50170000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50220000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50230000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60030000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60040000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                CON.Close();
                                CON.Close();
                                CON.Open();
                                try
                                {
                                    mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=6005000000 ", CON);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60060000000 ", CON);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60070000000 ", CON);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60080000000 ", CON);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60090000000 ", CON);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60100000000 ", CON);
                                    mycmd.ExecuteNonQuery();
                                }
                                catch { }
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60110000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60140000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60170000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60180000000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020201000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020204000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020205000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020206000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60170007000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020300000 ", CON);
                                mycmd.ExecuteNonQuery();
                                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020400000 ", CON);
                                mycmd.ExecuteNonQuery();
                                CON.Close();
                            }
                            catch { }
                        }
                        else
                        {
                            CON.Close();
                            CON.Open();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=20010302000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=20020301000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=20020400000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=20020500000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=20030000000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=20040000000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50230000000 ", CON);
                            mycmd.ExecuteNonQuery();
                            CON.Close();
                        }
                    }
                    catch { }
                }

                //if (Cbuild_date < Convert.ToDateTime("01/02/14"))
                //{
                //    try
                //    {
                //        UpdateMethods.TaxVat(CON);
                //    }
                //    catch { }
                //}

                if (Cbuild_date < Convert.ToDateTime("02/02/14"))
                {
                    try
                    {
                        if (edpcom.EnvironMent_Envelope == "PRINTING")
                        {
                            SqlCommand mycmd = new SqlCommand();
                            CON.Close();
                            CON.Open();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='TRUE' where MENUCODE=40010400000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010401000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010403000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='TRUE' where MENUCODE=40010402000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010404000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010405000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010406000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010408000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010410000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010413000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010419000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010421000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010422001 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010422100 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010422220 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020203000 ", CON);
                            mycmd.ExecuteNonQuery();
                            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020207000 ", CON);
                            mycmd.ExecuteNonQuery();
                            CON.Close();
                        }
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("06/02/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020212000','40020200000','Statement Completed Orders','StatementCompletedOrder', 0 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020213000','40020200000','PartyWise OrderWise Closing Stock','PartyWiseOrderWiseClosingStock', 0 , 0 )", CON);
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020214000','40020200000','PartyWise Paper Transfar Statement','PartyWisePaperTransfarStatement', 0 , 0 )", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("07/02/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('8','PR')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1003','VAT Applicability and Type','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('8','PR')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1003','True','False', 'Not Applicable')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        CON.Close();

                        CON.Close();
                        CON.Open();
                        string sqlstr1 = "ALTER TABLE IDATA ADD Reff_Data_T_entry CHAR(2), Reff_Data_Voucher numeric(18,0) Default(0)";
                        edpcom.RunCommand(sqlstr1, CON);
                        CON.Close();

                        //UpdateMethods.Typemas_InsUpdate();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("11/02/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD Cash_PartyName varchar(Max) Null,Cash_PartyAddress varchar(Max) Null,Cash_PartyAddress2 Varchar(Max) Null ", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("19/02/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        String sqlstr = "ALTER TABLE ITRAN ADD CONVERSION_QTY NUMERIC(18,2), CONVERSION_UCODE numeric(18,0)";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("20/02/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        String sqlstr = "delete from TypeDoc_Config where OPTION_CODE='1027' and t_entry='SR'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "delete from TypeMast_Config where OPTION_CODE='1027' and t_entry='SR'";
                        edpcom.RunCommand(sqlstr, CON);
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD Cash_Partyphone Varchar(Max) Null ", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/02/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('9','8')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1032','Set Broker','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('9','8')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1032','False','False', 'False')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }
                        edpcom.RunCommand("ALTER TABLE BillAdditionalDetails ADD Broker_Name Varchar(Max) Null ", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("04/03/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = " alter table idata alter column Multi_Linkvch varchar(MAX) null";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE currency ADD Currency_Image varbinary(max) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("05/03/14"))
                {
                    string strvchlock = " create table vectormaster(FICode char(10) not null,GCODE char(10) not null,VCode char(10) not null,";
                    strvchlock = strvchlock + " [AutoIncre] [numeric](18, 0) IDENTITY(1,1) NOT NULL,Vector_dec	varchar(100),Vec_Clasification varchar(50),Type varchar(50),Alloc_Type varchar(50),Vec_config varchar(50)";
                    strvchlock = strvchlock + " primary key clustered(FICode,GCODE,VCode,[AutoIncre]))";
                    SqlCommand cmd = new SqlCommand(strvchlock, CON);
                    try
                    {
                        CON.Close();
                        CON.Open();
                        cmd.ExecuteNonQuery();
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("06/03/14"))
                {
                    string strvchlock = " create table linkvector(FICode char(10) not null,GCODE char(10) not null,LVCode [numeric](18, 0) IDENTITY(1,1) NOT NULL,VCode char(10) not null,Glcode char(10) not null,Status varchar(50)";
                    strvchlock = strvchlock + " primary key clustered(FICode,GCODE,VCode,Glcode,LVCode))";
                    SqlCommand cmd = new SqlCommand(strvchlock, CON);
                    try
                    {
                        CON.Close();
                        CON.Open();
                        cmd.ExecuteNonQuery();
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("07/03/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE narr ADD Vcode varchar(50) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("11/03/14"))
                {
                    string strvchlock = " create table traimage(FICode char(10) not null,GCODE char(10) not null,voucher char(10) not null,";
                    strvchlock = strvchlock + " [AutoIncre] [numeric](18, 0) IDENTITY(1,1) NOT NULL,t_entry	varchar(100),image varchar(max)";
                    strvchlock = strvchlock + " primary key clustered(FICode,GCODE,voucher,[AutoIncre]))";
                    SqlCommand cmd = new SqlCommand(strvchlock, CON);
                    try
                    {
                        CON.Close();
                        CON.Open();
                        cmd.ExecuteNonQuery();
                        CON.Close();
                    }
                    catch { CON.Close(); }

                    CON.Close();
                    CON.Open();
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE CSTOCK DROP CONSTRAINT PK__CSTOCK__5070F446", CON);
                        edpcom.RunCommand("ALTER TABLE CSTOCK ADD PRIMARY KEY(FICODE,GCODE,SDATE,GLCODE)", CON);
                    }
                    catch { }

                    CON.Close();
                }
                if (Cbuild_date < Convert.ToDateTime("19/03/14"))
                {
                    CON.Close();
                    CON.Open();
                    try
                    {
                        string sqlstr = "Insert into menutable values('50120300000','50120000000','Document Import','DocumentImport',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                    //try
                    //{
                    //    UpdateMethods.DOCUMENTS_COPY(CON);
                    //}
                    //catch { }

                    CON.Close();
                }
                if (Cbuild_date < Convert.ToDateTime("20/03/14"))
                {
                    CON.Close();
                    CON.Open();
                    try
                    {
                        string sqlstr = "Insert into menutable values('50070300000','50070000000','Opening Bill Delete','OBD',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("20/03/14"))
                {
                    try
                    {
                        string strvchlock = "create table VchDetails(FICode char(10) not null,GCODE char(10) not null,VTYPE char(1) not null,T_ENTRY char(2) not null,VOUCHER numeric not null,";
                        strvchlock = strvchlock + "[AutoIncre] [numeric](18, 0) IDENTITY(1,1) NOT NULL,USER_VCH	varchar(100) null,VCH_Date datetime null,Tran_Date datetime null,USERCODE varchar(6) Null,Tran_Time varchar(50) Null,Computer_Name varchar(max) Null,Trans_Type char(10) Null,Des_Code varchar(20) Null";
                        strvchlock = strvchlock + " primary key clustered(FICode,GCODE,T_ENTRY,VOUCHER,[AutoIncre]))";
                        SqlCommand cmd = new SqlCommand(strvchlock, CON);
                        try
                        {
                            CON.Close();
                            CON.Open();
                            cmd.ExecuteNonQuery();
                            CON.Close();
                        }
                        catch { CON.Close(); }
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("22/03/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.DOCUMENTS_COPY(CON);
                        CON.Close();
                    }
                    catch { }
                }
                //if (Cbuild_date < Convert.ToDateTime("24/03/14"))
                //{
                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        UpdateMethods.UpdtGrp_GlmstForLedgTrig(CON);
                //        UpdateMethods.CONFIGARATION_ALL_COPY(CON);
                //        CON.Close();
                //    }
                //    catch { }
                //}
                //if (Cbuild_date < Convert.ToDateTime("25/03/14"))
                //{
                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        SqlDataAdapter adp = new SqlDataAdapter();
                //        DataSet ds = new DataSet();
                //        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('9')", CON);
                //        adp.SelectCommand = cmd;
                //        adp.Fill(ds, "FIG");

                //        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                //        {
                //            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                //            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                //            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                //            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1030','Auto Increment No','False','False')";
                //            try
                //            {
                //                edpcom.RunCommand(str, CON);
                //            }
                //            catch { }
                //        }

                //        //================================================================

                //        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('9')", CON);
                //        adp.SelectCommand = cmd;
                //        adp.Fill(ds, "FI_TypeDock");

                //        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                //        {
                //            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                //            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                //            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                //            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                //            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1030','True','False', 'Yes')";
                //            try
                //            {
                //                edpcom.RunCommand(sqlstr, CON);
                //            }
                //            catch { }
                //        }

                //        CON.Close();
                //    }
                //    catch { }
                //}

                if (Cbuild_date < Convert.ToDateTime("26/03/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "update MenuTable set ENABLE_MENU='True' where MENUCODE=20010305000 ";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                //if (Cbuild_date < Convert.ToDateTime("27/03/14"))
                //{
                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        UpdateMethods.Typemas_InsUpdate(CON);
                //        CON.Close();
                //    }
                //    catch { }
                //}
                if (Cbuild_date < Convert.ToDateTime("28/03/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("update  WACCOPTN set bool_val='False' where SeriesNo='4.15.5' ", CON);
                        edpcom.RunCommand("update  WACCOPTN set bool_val='False' where SeriesNo='4.15.14' ", CON);
                        CON.Close();
                    }
                    catch { }
                }
                //if (Cbuild_date < Convert.ToDateTime("31/03/14"))
                //{
                //    try
                //    {
                //        CON.Close();
                //        CON.Open();                       
                //        UpdateMethods.CONFIGARATION_ALL_COPY(CON);
                //        UpdateMethods.Mid_DELETE_COMPANYUpdate();
                //        UpdateMethods.UserProfile_COPY(CON);
                //        CON.Close();
                //    }
                //    catch { }
                //}
                if (Cbuild_date < Convert.ToDateTime("01/04/14"))
                {

                    try
                    {
                        CON.Close();
                        CON.Open();
                        //UpdateMethods.CONFIGARATION_ALL_COPY(CON);
                        UpdateMethods.Mid_DELETE_COMPANYUpdate();
                        UpdateMethods.UserProfile_COPY(CON);
                        CON.Close();
                    }
                    catch { }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        T_ENTRY_Entry(CON);
                        string sqlstr = "insert into TypeMast values(1,1,'LT','Loc Trans','LT')";
                        edpcom.RunCommand(sqlstr, CON);

                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("08/04/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.TaxVat(CON);
                        CON.Close();
                    }
                    catch { }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("Insert into menutable values('50211040000','50211000000','Party Online Allocate','Party Online Allocate',1,' ',' ',0)", CON);
                        CON.Close();
                    }
                    catch { }
                    try
                    {
                        string sqlstr = "";
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM glmst ", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");
                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            int ficode = Convert.ToInt32(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            int gcode = Convert.ToInt32(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            if (i == 0)
                            {
                                sqlstr = "delete from glmst where glcode in('1126','1127') ";
                                edpcom.RunCommand(sqlstr, CON);
                                sqlstr = "delete from VATMaster where VAT_CODE in('1126','1127') ";
                                edpcom.RunCommand(sqlstr, CON);
                                sqlstr = "delete from LinkVATGLMST where VAT_CODE in('1126','1127') ";
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            sqlstr = " INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES(" + ficode + "," + gcode + ",'L',3,31,1126,'CST @ 5%','null',34,0,0,0,1,31,'0000000000',0,'C','2',1,NULL,NULL,0,'1',1,1,1,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)" + Environment.NewLine;
                            sqlstr = sqlstr + "INSERT INTO VATMaster(ficode,gcode,VAT_CODE,STATE_CODE,VAT_DESC,VAT_PERCENT,UPD_DATE,Tax_Type ) VALUES(" + ficode + "," + gcode + ",1126,19,'CST @ 5%',5,'03/27/2012','cst')" + Environment.NewLine;
                            sqlstr = sqlstr + " INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES(" + ficode + "," + gcode + ",'L',3,31,1127,'CST @ 14.5%','null',34,0,0,0,1,31,'0000000000',0,'C','2',1,NULL,NULL,0,'1',1,1,1,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)" + Environment.NewLine;
                            sqlstr = sqlstr + "INSERT INTO VATMaster(ficode,gcode,VAT_CODE,STATE_CODE,VAT_DESC,VAT_PERCENT,UPD_DATE,Tax_Type ) VALUES(" + ficode + "," + gcode + ",1127,19,'CST @ 14.5%',14.5,'03/27/2012','cst')" + Environment.NewLine;
                            sqlstr = sqlstr + " INSERT INTO LinkVATGLMST(FICode,GCODE,LVG_ID,STATE_CODE,VAT_CODE,GLCODE,Vat_Per) VALUES(" + ficode + "," + gcode + ",46,19,1126,1059,5)  " + Environment.NewLine;
                            sqlstr = sqlstr + " INSERT INTO LinkVATGLMST(FICode,GCODE,LVG_ID,STATE_CODE,VAT_CODE,GLCODE,Vat_Per) VALUES(" + ficode + "," + gcode + ",47,19,1127,1061,14.5)  ";
                            edpcom.RunCommand(sqlstr, CON);
                        }
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("10/04/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE FormMaster ADD vat_code numeric(18, 0) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }
                //if (Cbuild_date < Convert.ToDateTime("15/04/14"))
                //{                   
                //        string strmenu = "";
                //        try
                //        {
                //            CON.Close();
                //            CON.Open();
                //            strmenu = " Drop table menutable_New ";
                //            edpcom.RunCommand(strmenu, CON);
                //            CON.Close();
                //        }
                //        catch
                //        {
                //            CON.Close();
                //        }
                //        try
                //        {
                //            CON.Close();
                //            CON.Open();
                //            strmenu = "create table menutable_New(MENUCODE varchar(12) not null,PARENTCODE varchar(12) not null ,";
                //            strmenu = strmenu + "MENUDESC varchar(300) not null,DETAILDESC varchar(500) not null,ENABLE_MENU bit,FORMCODE varchar(20),";
                //            strmenu = strmenu + "SHORTCUT_KEY varchar(50),TOOLBARBTN bit,primary key clustered(MENUCODE,PARENTCODE))";
                //            edpcom.RunCommand(strmenu, CON);
                //            menu.EnterIntomenu(CON, CBuildDate, PBuildDate);
                //            CON.Close();
                //        }
                //        catch
                //        {
                //            CON.Close();
                //        }
                //}
                if (Cbuild_date < Convert.ToDateTime("17/04/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.DELETE_BILL_PROCEDURE(CON);
                        CON.Close();
                        CON.Open();
                        UpdateMethods.DELETE_DATA_PROCEDURE(CON);
                        CON.Close();
                        CON.Open();
                        UpdateMethods.DELETE_IDATA_PROCEDURE(CON);
                        CON.Close();
                        CON.Open();
                        UpdateMethods.DELETE_ITRAN_PROCEDURE(CON);
                        CON.Close();
                        CON.Open();
                        UpdateMethods.DELETE_VCHR_PROCEDURE(CON);
                        CON.Close();
                        CON.Open();
                        UpdateMethods.DELETE_AddlessLineItem_PROCEDURE(CON);
                        CON.Close();
                        CON.Open();
                        UpdateMethods.DELETE_IGLMST_PROCEDURE(CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("21/04/14"))
                {
                    try
                    {
                        //CON.Close();
                        //CON.Open();
                        //UpdateMethods.CreateTrigLinkVatGlmst(CON);
                        CON.Close();
                        CON.Open();
                        UpdateMethods.TaxVat(CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("24/04/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4015018001','4.15.18.01','Left Align',NULL,null,'False',0,0,'4000000000','False')" +
                            " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4015018002','4.15.18.02','Right Align',NULL,null,'False',0,0,'4000000000','False')" +
                            " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4015018003','4.15.18.03','Center Align',NULL,null,'True',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                        }
                        CON.Close();
                    }

                    catch { }
                    //try
                    //{
                    //    CON.Close();
                    //    CON.Open();
                    //    //UpdateMethods.UpdateTrigComWACCOPTN(CON);
                    //    CON.Close();
                    //}
                    //catch { CON.Close(); }
                }

                if (Cbuild_date < Convert.ToDateTime("28/04/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE ITRAN ADD PARALLEL_CONV NUMERIC(18,4) Null", CON);
                        edpcom.RunCommand("ALTER TABLE ITRAN ADD RATING_CONV NUMERIC(18,4) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("30/04/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE prtyms ADD Comp_Type varchar(80) null", CON);
                        CON.Close();
                    }
                    catch { }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE VCHR ADD Ledger_Curr_Code Numeric(18,0) Null,Ledger_NCONV_FCTR Numeric(18,4) Null,Ledger_DCONV_FCTR Numeric(18,4) Null,Ledger_FC_DBAMT Numeric(18,4) Null,Ledger_FC_CRAMT Numeric(18,4) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("07/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('9','8','SR','PR','OS','OP')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1033','Toggle VAT/CST on State Value','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('9','8','SR','PR','OS','OP')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1033','False','False', 'False')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        CON.Close();
                    }
                    catch { }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "delete from TypeDoc_Config where OPTION_CODE = 1023 ";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "delete from TypeMast_Config where OPTION_CODE = 1023 ";
                        edpcom.RunCommand(sqlstr, CON);
                        //UpdateMethods.Typemas_InsUpdate(CON);
                        CON.Close();
                        CON.Open();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("10/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,2,'2070000000','2.7','TDS',NULL,null,'False',0,0,'2000000000','False')" +
                            " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,2,'207010000','2.7.1','TDS Duty Amounts',NULL,null,'False',0,0,'2070000000','False')" +
                             " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,2,'207020000','2.7.2','Round Off TDS Duty Amounts',NULL,null,'False',0,0,'2070000000','False')";
                            edpcom.RunCommand(str, CON);
                        }
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("14/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string strParty = "CREATE TABLE [TDSCategoryMaster] (FICode char(10)not null,GCODE char(10)not null,Category_Code int  NOT NULL,Category_Name varchar(max) NULL,Section_Name varchar(max) NULL,";
                        strParty = strParty + "primary key clustered(Category_Code,FICode,GCODE))";
                        edpcom.RunCommand(strParty, CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("15/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string strParty = "CREATE TABLE [TDSCategoryLink] (FICode char(10)not null,GCODE char(10)not null,Category_Code int  NOT NULL,Payee_code int  NOT NULL,Payee_Category varchar(max) NULL,Threshold_ltd numeric(18, 2),TDS_withpan numeric(18, 2),TDS_withoutpan numeric(18, 2),Surcharge numeric(18, 2),Edu_cess numeric(18, 2),SHE_cess numeric(18, 2),";
                        strParty = strParty + "primary key clustered(Category_Code,FICode,GCODE,Payee_code))";
                        edpcom.RunCommand(strParty, CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("16/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE IDATA ADD Reff_Party_Code NUMERIC(18,0) null,Process_No varchar(50) null", CON);
                        CON.Close();
                    }
                    catch { }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("Insert into menutable values('20020503000','20020500000','Composite Stock Transfar','Composite Stock Transfer',1,' ',' ',0)", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("17/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE glmst ADD TDSCategory_Code  numeric(18,0) null", CON);
                        //UpdateMethods.TaxVat(CON);                       
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("18/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE LinkVATGLMST ADD Tax_Type  varchar(50) null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("19/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.CreateTrigLinkVatGlmst(CON);
                        CON.Close();

                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("20/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1083'and GLCODE='1002' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1084'and GLCODE='1003' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1085'and GLCODE='1004' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1086'and GLCODE='1005' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1087'and GLCODE='1006' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1088'and GLCODE='1008' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1089'and GLCODE='1009' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1090'and GLCODE='1010' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1091'and GLCODE='1014' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1092'and GLCODE='1015' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1093'and GLCODE='1016' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1094'and GLCODE='1017' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1095'and GLCODE='1018' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1096'and GLCODE='1020' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1112'and GLCODE='1021' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1113'and GLCODE='1022' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1114'and GLCODE='1023' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1115'and GLCODE='1024' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1116'and GLCODE='1025' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1117'and GLCODE='1026' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1118'and GLCODE='1027' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1104'and GLCODE='1028' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1105'and GLCODE='1029' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1106'and GLCODE='1030' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1119'and GLCODE='1041' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1120'and GLCODE='1042' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1121'and GLCODE='1043' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1122'and GLCODE='1044' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1123'and GLCODE='1045' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1124'and GLCODE='1046' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1125'and GLCODE='1047' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1099'and GLCODE='1057' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1099'and GLCODE='1058' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1101'and GLCODE='1059' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1102'and GLCODE='1060' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1103'and GLCODE='1061' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1104'and GLCODE='1063' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1105'and GLCODE='1064' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1106'and GLCODE='1065' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1107'and GLCODE='1072' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1108'and GLCODE='1073' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1109'and GLCODE='1074' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1209'and GLCODE='1207' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1214'and GLCODE='1211' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1215'and GLCODE='1212' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1126'and GLCODE='1059' and STATE_CODE='19' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1127'and GLCODE='1061' and STATE_CODE='19' ", CON);
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1180'and GLCODE='1126' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1181'and GLCODE='1127' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1182'and GLCODE='1128' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1183'and GLCODE='1129' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1184'and GLCODE='1130' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1195'and GLCODE='1137' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1196'and GLCODE='1138' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1197'and GLCODE='1139' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1198'and GLCODE='1140' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1199'and GLCODE='1141' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1200'and GLCODE='1142' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1201'and GLCODE='1151' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1202'and GLCODE='1152' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1203'and GLCODE='1153' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1204'and GLCODE='1154' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1205'and GLCODE='1155' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Cst' where VAT_CODE='1206'and GLCODE='1156' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1185'and GLCODE='1163' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1186'and GLCODE='1164' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1187'and GLCODE='1165' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1188'and GLCODE='1166' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1189'and GLCODE='1167' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1190'and GLCODE='1171' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1191'and GLCODE='1172' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1192'and GLCODE='1173' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1193'and GLCODE='1174' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1194'and GLCODE='1175' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1214'and GLCODE='1211' and STATE_CODE='7' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1214'and GLCODE='1212' and STATE_CODE='7' ", CON);
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1401'and GLCODE='1400' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1403'and GLCODE='1402' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1405'and GLCODE='1404' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1407'and GLCODE='1406' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1409'and GLCODE='1408' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1417'and GLCODE='1416' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1419'and GLCODE='1418' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1421'and GLCODE='1420' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1423'and GLCODE='1422' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1425'and GLCODE='1424' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1429'and GLCODE='1428' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1431'and GLCODE='1430' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1433'and GLCODE='1432' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1435'and GLCODE='1434' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1453'and GLCODE='1452' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1455'and GLCODE='1454' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1457'and GLCODE='1456' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1459'and GLCODE='1458' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1461'and GLCODE='1460' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1463'and GLCODE='1462' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1465'and GLCODE='1464' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1467'and GLCODE='1466' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1469'and GLCODE='1468' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1471'and GLCODE='1470' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1475'and GLCODE='1474' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1477'and GLCODE='1476' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1479'and GLCODE='1478' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1481'and GLCODE='1480' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1483'and GLCODE='1482' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1485'and GLCODE='1484' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1487'and GLCODE='1486' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1489'and GLCODE='1488' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1491'and GLCODE='1490' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1493'and GLCODE='1492' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1495'and GLCODE='1494' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1497'and GLCODE='1496' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1499'and GLCODE='1498' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1501'and GLCODE='1500' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1439'and GLCODE='1438' and STATE_CODE='10' ", CON);
                        edpcom.RunCommand("update  LinkVATGLMST set Tax_Type='Vat' where VAT_CODE='1512'and GLCODE='1511' and STATE_CODE='10' ", CON);
                        CON.Close();
                    }
                    catch
                    {
                        CON.Close();
                    }
                }

                //if (Cbuild_date < Convert.ToDateTime("22/05/14"))
                //{
                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        //UpdateMethods.CreateTDSCategory(CON);
                //        //UpdateMethods.UpdateTrigComWACCOPTN(CON);
                //        CON.Close();

                //    }
                //    catch { }
                //}

                //if (Cbuild_date < Convert.ToDateTime("23/05/14"))
                //{
                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        string strParty = "CREATE TABLE [TDS_Deduction] (FICode char(10)not null,GCODE char(10)not null,AUTOINCRE numeric IDENTITY(1,1) not null,T_ENTRY char(2) not null,voucher numeric(18, 0) NOT NULL,glcode numeric(18, 0),Category_Code numeric(18, 0),Refno varchar(50)  NOT NULL,TDSCalculate_Amt numeric(18, 2),TDS_Date datetime NULL,Expense_Date datetime NULL,TDS_per numeric(18, 2),TDS_Amt numeric(18, 2),Sur_Per numeric(18, 2),Sur_Amt numeric(18, 2),Educess_Per numeric(18, 2),Educess_Amt numeric(18, 2),SHEcess_Per numeric(18, 2),SHEcess_Amt numeric(18, 2),Tax_Amt numeric(18,2),TDS_Note varchar(max),";
                //        strParty = strParty + "primary key clustered(FICode,GCODE,T_ENTRY,voucher,AUTOINCRE))";
                //        edpcom.RunCommand(strParty, CON);
                //        CON.Close();
                //    }
                //    catch { CON.Close(); }
                //}
                //if (Cbuild_date < Convert.ToDateTime("24/05/14"))
                //{
                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        UpdateMethods.UpdateTrigComWACCOPTN(CON);
                //        CON.Close();
                //    }
                //    catch { CON.Close(); }
                //}
                if (Cbuild_date < Convert.ToDateTime("25/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        try
                        {
                            edpcom.RunCommand("DELETE FROM WACCOPTN WHERE SeriesNo IN ('4.10.5')", CON);
                        }
                        catch { }
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = " INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,4,'4100500000','4.10.5','Additional Header & Footer details for Party Statement',NULL,null,'False',0,0,'4000000000','False')";
                            edpcom.RunCommand(str, CON);
                        }

                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("26/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE prtyms ADD Comp_Type varchar(80) null", CON);
                        CON.Close();
                    }
                    catch { }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE VCHR ADD Ledger_Curr_Code Numeric(18,0) Null,Ledger_NCONV_FCTR Numeric(18,4) Null,Ledger_DCONV_FCTR Numeric(18,4) Null,Ledger_FC_DBAMT Numeric(18,4) Null,Ledger_FC_CRAMT Numeric(18,4) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                //if (Cbuild_date < Convert.ToDateTime("27/05/14"))
                //{
                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        edpcom.RunCommand("ALTER TABLE TDS_Deduction ADD TDS_Payment bit,Intarest numeric(18, 2),Penalty numeric(18, 2),Tds_Quarter varchar(10) ", CON);
                //        CON.Close();
                //    }
                //    catch { }                   
                //}
                if (Cbuild_date < Convert.ToDateTime("28/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        //UpdateMethods.CreateTDSCategory(CON);

                        string strParty = "CREATE TABLE [TDS_Deduction_Details] (FICode char(10)not null,GCODE char(10)not null,AUTOINCRE numeric IDENTITY(1,1) not null,T_ENTRY char(2) not null,voucher numeric(18, 0) NOT NULL,glcode numeric(18, 0),Category_Code numeric(18, 0),Refno varchar(50),Intarest numeric(18, 2),Penalty numeric(18, 2),Tds_Quarter varchar(10),link_voucher numeric(18, 0),link_Tentry char(2),";
                        strParty = strParty + "primary key clustered(FICode,GCODE,T_ENTRY,voucher,AUTOINCRE))";
                        edpcom.RunCommand(strParty, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("29/05/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("drop table TDS_Deduction_Details", CON);
                        CON.Close();
                    }
                    catch { }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string strParty = "CREATE TABLE [TDS_Deduction_Details] (FICode char(10)not null,GCODE char(10)not null,AUTOINCRE numeric IDENTITY(1,1) not null,T_ENTRY char(2) not null,voucher numeric(18, 0) NOT NULL,glcode numeric(18, 0),Category_Code numeric(18, 0),Refno varchar(50),Intarest numeric(18, 2),Penalty numeric(18, 2),Tds_Quarter varchar(10),link_voucher numeric(18, 0),link_Tentry char(2),";
                        strParty = strParty + "primary key clustered(FICode,GCODE,T_ENTRY,voucher,AUTOINCRE))";
                        edpcom.RunCommand(strParty, CON);
                        CON.Close();
                    }
                    catch { }
                }
                //if (Cbuild_date < Convert.ToDateTime("30/05/14"))
                //{
                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        edpcom.RunCommand("drop table TDS_Deduction", CON);
                //        CON.Close();
                //    }
                //    catch { }

                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        string strParty = "CREATE TABLE [TDS_Deduction] (FICode char(10)not null,GCODE char(10)not null,AUTOINCRE numeric IDENTITY(1,1) not null,T_ENTRY char(2) not null,voucher numeric(18, 0) NOT NULL,glcode numeric(18, 0),Category_Code numeric(18, 0),Refno varchar(50)  NOT NULL,TDS_Payment bit,TDSCalculate_Amt numeric(18, 2),TDS_Date datetime NULL,Expense_Date datetime NULL,TDS_per numeric(18, 2),TDS_Amt numeric(18, 2),Sur_Per numeric(18, 2),Sur_Amt numeric(18, 2),Educess_Per numeric(18, 2),Educess_Amt numeric(18, 2),SHEcess_Per numeric(18, 2),SHEcess_Amt numeric(18, 2),Tax_Amt numeric(18,2),TDS_Note varchar(max),Ref_TENTRY char(2) ,Ref_voucher numeric(18, 0) ,";
                //        strParty = strParty + "primary key clustered(FICode,GCODE,T_ENTRY,voucher,AUTOINCRE))";
                //        edpcom.RunCommand(strParty, CON);
                //        CON.Close();
                //    }
                //    catch { CON.Close(); }

                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        UpdateMethods.CreateTDSCategory(CON);
                //        CON.Close();
                //    }
                //    catch { }

                //    try
                //    {
                //        CON.Close();
                //        CON.Open();
                //        edpcom.RunCommand("ALTER TABLE IGLMST ADD ST_TYPE varchar(20),ST_TYPE_PER numeric(18, 2),ST_GLCODE numeric(18, 0),ST_PER numeric(18, 2),EDU_CESS_GLCODE numeric(18, 0),EDU_CESS_PER numeric(18, 2),HI_EDU_CESS_GLCODE numeric(18, 0),HI_EDU_CESS_PER numeric(18, 2)", CON);
                //        CON.Close();
                //    }
                //    catch { }

                //}
                if (Cbuild_date < Convert.ToDateTime("03/06/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE GLMST ADD ROUND_OFF_TYPE_EXC varchar(20),ROUND_OFF_TYPE_ST varchar(20)", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("05/06/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.AlterCompanyTriggerForLedger(CON);
                        CON.Close();
                    }
                    catch { }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('2')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1016','Payment Advise Print','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('2')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1016','False','False', 'False')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("09/06/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE ITRAN ADD Ledger_Curr_Code Numeric(18,0) Null,Ledger_NCONV_FCTR Numeric(18,4) Null,Ledger_DCONV_FCTR Numeric(18,4) Null,Rate_Ledger Numeric(18,4) Null,Amt_Ledger Numeric(18,4) Null", CON);
                        edpcom.RunCommand("ALTER TABLE BILL ADD Ledger_Curr_Code Numeric(18,0) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("13/06/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.PRODUCT_COPY(CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("14/06/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("UPDATE prtyms SET ACC_COUNTRY='91'", CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }

                if (Cbuild_date < Convert.ToDateTime("15/06/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,2,'2080000000','2.8','Service Tax',NULL,null,'False',0,0,'2000000000','False')";
                            edpcom.RunCommand(str, CON);
                        }
                        CON.Close();
                    }
                    catch { }
                    //try
                    //{
                    //    CON.Close();
                    //    CON.Open();
                    //    UpdateMethods.UpdateTrigComWACCOPTN(CON);
                    //    CON.Close();
                    //}
                    //catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("25/06/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string strPrice = "CREATE TABLE [Price_List_Master] ([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,Price_List_ID int  NOT NULL,Price_List_Name varchar(100) NULL,";
                        strPrice = strPrice + "Remarks varchar(max) NULL ,";
                        strPrice = strPrice + "primary key clustered(Ficode,Gcode,Price_List_ID))";
                        try
                        {
                            edpcom.RunCommand(strPrice, CON);
                        }
                        catch { }
                        CON.Close();
                    }
                    catch { }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        string strPrice = "CREATE TABLE [Price_List_Details] ([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,Price_List_ID int  NOT NULL,PCODE int  NOT NULL,Price_Type varchar(10) NOT NULL,Price_Rate numeric(18,4) NULL,UCODE numeric(18,0) NULL,";
                        strPrice = strPrice + "Effective_Date Datetime NOT NULL,Dis_Per numeric(18,2) NULL,Dis_Item numeric(18,2) NULL,MarkUp_Per numeric(18,2) NULL,MarkUp_Item numeric(18,2) NULL,";
                        strPrice = strPrice + "primary key clustered(Ficode,Gcode,Price_List_ID,PCODE,Price_Type,Effective_Date))";
                        try
                        {
                            edpcom.RunCommand(strPrice, CON);
                        }
                        catch { }
                        CON.Close();
                    }
                    catch { }
                }

                ControlFileDeletionCreation();

                if (Cbuild_date < Convert.ToDateTime("27/06/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.UpdtGrp_GlmstForLedgTrig(CON);
                        UpdateMethods.CONFIGARATION_ALL_COPY(CON);
                        CON.Close();
                    }
                    catch { }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "Insert into menutable values('20020106000','20020100000','Price List Entry','Price_List_Entry',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("28/06/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE prtyms ADD Price_List_ID Numeric(18,0) Null", CON);
                        CON.Close();
                    }
                    catch { }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "Insert into menutable values('40020504000','40020500000','Price List','Price_List',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("01/07/14"))
                {
                    try
                    {
                        string sqlstr = "alter table Glmst alter column BOOL_CODE bit null";
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("2/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("update menutable set MENUDESC = 'Forms ' where Menucode=40010408000", CON);
                        edpcom.RunCommand("update menutable set MENUDESC = 'A/C Statement ' where Menucode=40010416010", CON);
                        edpcom.RunCommand("update menutable set MENUDESC = 'Audit Check ' where Menucode=40010501000", CON);
                        edpcom.RunCommand("update menutable set MENUDESC = 'Ledgers ' where Menucode=40010101000", CON);
                        edpcom.RunCommand("update menutable set MENUDESC = 'Ledger ' where Menucode=40010502000", CON);
                        edpcom.RunCommand("update menutable set MENUDESC = 'Ledger A/c ' where Menucode=40020203000", CON);
                        edpcom.RunCommand("update menutable set MENUDESC = 'Status ' where Menucode=40020206010", CON);
                        edpcom.RunCommand("update menutable set MENUDESC = 'Statement ' where Menucode=40020207010", CON);
                        edpcom.RunCommand("update menutable set MENUDESC = 'Formula ' where Menucode=40020304010", CON);
                        edpcom.RunCommand("update menutable set MENUDESC = 'Items/Products ' where Menucode=40020501000", CON);
                        edpcom.RunCommand("update menutable set MENUDESC = 'Checklist ' where Menucode=40030400000", CON);
                        edpcom.RunCommand("update menutable set MENUDESC = 'Item Checklist ' where Menucode=40040100000", CON);
                        edpcom.RunCommand("update menutable set MENUDESC = 'Party Details ' where Menucode=40020600000", CON);
                        edpcom.RunCommand("update menutable set Toolbarbtn = 1 where Menucode=20020301030", CON);
                        edpcom.RunCommand("update menutable set Toolbarbtn = 1 where Menucode=20020302040", CON);
                        edpcom.RunCommand("update menutable set Toolbarbtn = 1 where Menucode=20010301000", CON);
                        edpcom.RunCommand("update menutable set Toolbarbtn = 1 where Menucode=10020000000", CON);
                        edpcom.RunCommand("update menutable set Toolbarbtn = 0 where Menucode=10010000000", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("03/07/14"))
                {
                    //try
                    //{
                    //    CON.Close();
                    //    CON.Open();
                    //    UpdateMethods.Typemas_InsUpdate(CON);
                    //    CON.Close();
                    //}
                    //catch { }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('OP')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1035','Order Generate with Reference','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('OP')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1035','False','False', 'False')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("04/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "Insert into menutable values('50240000000','50000000000','Account Merge','Account_Merge',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("05/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE APPRMAST ADD ROW_INDEX Numeric(18,0) Null", CON);
                        edpcom.RunCommand("ALTER TABLE APPRTRAN ADD ROW_INDEX Numeric(18,0) Null", CON);
                        edpcom.RunCommand("ALTER TABLE APPRTRAN ALTER column PVALUE Numeric(18,4) null", CON);
                        edpcom.RunCommand("ALTER TABLE APPRTRAN ALTER column AMOUNT Numeric(18,4) null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("08/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "Insert into menutable values('20020402030','20020402000','Production Order','Production_Order',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM TypeMast", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            edpcom.RunCommand("insert into TypeMast values('" + FICODE + "','" + GCODE + "','PN','Production Order','PN')", CON);
                        }
                    }
                    catch { }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE ITRAN ADD CC_CODE_Form Numeric(18,0) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("09/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE itran DROP column CC_CODE_From", CON);
                        CON.Close();
                    }
                    catch { }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE ITRAN ADD CC_CODE_Form Numeric(18,0) Null", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("10/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "Insert into menutable values('40020101070','40020101000','Purchase Return Rpt','Purchase_Return',1,' ',' ',0)";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("11/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('9')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','PN','1002','Enable Online Document Printing','False','False')";
                            str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','PN','1030','Auto Increment No','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }
                    }
                    catch { }

                    //try
                    //{
                    //    CON.Close();
                    //    CON.Open();
                    //    UpdateMethods.Typemas_InsUpdate(CON);
                    //    CON.Close();
                    //}
                    //catch { }

                }

                if (Cbuild_date < Convert.ToDateTime("15/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "UPDATE WACCOPTN SET OPTION_DESC='Stock Query DashBoards',bool_val='False' Where OPTION_CODE='3080000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "UPDATE WACCOPTN SET OPTION_DESC='Activate Double UOM Query Format',bool_val='False' Where OPTION_CODE='3080100000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "UPDATE WACCOPTN SET OPTION_DESC='Activate Order Qty Columns',bool_val='False' Where OPTION_CODE='3080200000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "UPDATE WACCOPTN SET OPTION_DESC='Activate Available to Promise Colum',bool_val='False' Where OPTION_CODE='3080300000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "UPDATE WACCOPTN SET OPTION_DESC='Activate BOM Details',bool_val='False' Where OPTION_CODE='3080400000'";
                        edpcom.RunCommand(sqlstr, CON);

                        sqlstr = "delete from WACCOPTN Where OPTION_CODE='3080500000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "delete from WACCOPTN Where OPTION_CODE='3080600000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "delete from WACCOPTN Where OPTION_CODE='3080601000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "delete from WACCOPTN Where OPTION_CODE='3080602000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "delete from WACCOPTN Where OPTION_CODE='3080700000'";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = "delete from WACCOPTN Where OPTION_CODE='3080800000'";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch
                    {
                        CON.Close();
                    }

                    //try
                    //{
                    //    CON.Close();
                    //    CON.Open();
                    //    UpdateMethods.UpdateTrigComWACCOPTN(CON);
                    //    CON.Close();
                    //}
                    //catch 
                    //{
                    //    CON.Close();
                    //}
                }

                if (Cbuild_date < Convert.ToDateTime("16/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        //UpdateMethods.Typemas_InsUpdate(CON);
                        string sqlstr = "delete from TypeDoc_Config Where OPTION_CODE='1035'";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('FG','GR','MR','MI','NI','NM','OP','PN','PI')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1035','Order Generate with Reference','False','False')";
                            try
                            {
                                edpcom.RunCommand(str, CON);

                                if (Tentry.Trim() == "OP")
                                {
                                    str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1036','Reference Type','False','False')";
                                    edpcom.RunCommand(str, CON);
                                }
                            }

                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('FG','GR','MR','MI','NI','NM','OP','PN','PI')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1035','False','False', 'Not Applicable')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                                if (Tentry.Trim() == "OP")
                                {
                                    sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1036','False','False', 'Sales Order')";
                                    edpcom.RunCommand(sqlstr, CON);
                                }
                            }
                            catch { }
                        }

                        CON.Close();
                    }
                    catch { }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('a','n')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1031','Document Title','False','Challan')";
                            try
                            {
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }

                        //================================================================

                        cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('a','n')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);
                            string sqlstr = "";
                            if (Tentry.Trim() == "a")
                                sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1031','False','False', 'Purchase Challan')";
                            else
                                sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1031','False','False', 'Sales Challan')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { CON.Close(); }
                        }

                        CON.Close();
                    }
                    catch { CON.Close(); }
                }


                if (Cbuild_date < Convert.ToDateTime("18/07/14"))
                {

                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "delete from TypeDoc_Config where OPTION_CODE = 1033 ";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                        CON.Open();
                    }
                    catch { }
                    try
                    {
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,Desccode,T_ENTRY FROM TypeDoc_Config WHERE T_ENTRY in('9','8','SR','PR','OS','OP')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FI_TypeDock");

                        for (int i = 0; i <= ds.Tables["FI_TypeDock"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FI_TypeDock"].Rows[i]["T_ENTRY"]);
                            int DescCode = Convert.ToInt32(ds.Tables["FI_TypeDock"].Rows[i]["Desccode"]);

                            string sqlstr = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FICODE + "','" + GCODE + "','" + Tentry + "'," + DescCode + ",'1033','False','False', 'False')";
                            try
                            {
                                edpcom.RunCommand(sqlstr, CON);
                            }
                            catch { }
                        }

                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("19/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "update MenuTable set ENABLE_MENU='True' where MENUCODE=40010304000";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("25/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("drop table TDS_Deduction", CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        string strParty = "CREATE TABLE [TDS_Deduction] (FICode char(10)not null,GCODE char(10)not null,AUTOINCRE numeric IDENTITY(1,1) not null,T_ENTRY char(2) not null,voucher numeric(18, 0) NOT NULL,glcode numeric(18, 0),Category_Code numeric(18, 0),Refno varchar(50)  NOT NULL,TDS_Payment bit,TDSCalculate_Amt numeric(18, 2),TDS_Date datetime NULL,Expense_Date datetime NULL,TDS_per numeric(18, 2),TDS_Amt numeric(18, 2),Sur_Per numeric(18, 2),Sur_Amt numeric(18, 2),Educess_Per numeric(18, 2),Educess_Amt numeric(18, 2),SHEcess_Per numeric(18, 2),SHEcess_Amt numeric(18, 2),Tax_Amt numeric(18,2),TDS_Note varchar(max),Ref_TENTRY char(2) ,Ref_voucher numeric(18, 0) ,";
                        strParty = strParty + "primary key clustered(FICode,GCODE,T_ENTRY,voucher,AUTOINCRE))";
                        edpcom.RunCommand(strParty, CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }

                    //try
                    //{
                    //    CON.Close();
                    //    CON.Open();
                    //    UpdateMethods.CreateTDSCategory(CON);
                    //    CON.Close();
                    //}
                    //catch { CON.Close(); }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE IGLMST ADD ST_TYPE varchar(20),ST_TYPE_PER numeric(18, 2),ST_GLCODE numeric(18, 0),ST_PER numeric(18, 2),EDU_CESS_GLCODE numeric(18, 0),EDU_CESS_PER numeric(18, 2),HI_EDU_CESS_GLCODE numeric(18, 0),HI_EDU_CESS_PER numeric(18, 2)", CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "UPDATE WACCOPTN SET OPTION_DESC='First character Search',bool_val='False' Where OPTION_CODE='5070000000'";
                        edpcom.RunCommand(sqlstr, CON);
                        //UpdateMethods.UpdateTrigComWACCOPTN(CON);
                        CON.Close();
                    }
                    catch
                    {
                        CON.Close();
                    }
                }
                if (Cbuild_date < Convert.ToDateTime("27/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            try
                            {
                                string str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,2,'2080000000','2.8','Service Tax',NULL,null,'False',0,0,'2000000000','False')";
                                edpcom.RunCommand(str, CON);
                            }
                            catch { }
                        }
                        //UpdateMethods.UpdateTrigComWACCOPTN(CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }

                if (Cbuild_date < Convert.ToDateTime("28/07/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.Typemas_InsUpdate(CON);
                        CON.Close();
                    }
                    catch { }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE,T_ENTRY FROM TypeMast_Config WHERE T_ENTRY in('9')", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            string Tentry = Convert.ToString(ds.Tables["FIG"].Rows[i]["T_ENTRY"]);
                            string str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1035','Strict Reference Type','False','False')";
                            edpcom.RunCommand(str, CON);
                            str = "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values ('" + FICODE + "','" + GCODE + "','" + Tentry + "','1036','Reference Transaction','False','False')";
                            edpcom.RunCommand(str, CON);
                        }
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("01/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        try
                        {
                            edpcom.RunCommand("Drop table FinishGoods_Details", CON);
                        }
                        catch { }
                        string strFormula = "CREATE TABLE FinishGoods_Details (FICode char(10)not null,GCODE char(10) not null,AUTOINCRE int IDENTITY(1,1) not null,T_ENTRY char(2) not null,voucher numeric(18,0),PCODE numeric (18,0),QTY numeric (18,2),UCODE numeric (18,0),Bool_Code bit , primary key clustered (FICode,GCODE,T_ENTRY,voucher,AUTOINCRE))";
                        edpcom.RunCommand(strFormula, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("05/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string strFormula = "CREATE TABLE BillAdditional_Config (FICode char(10)not null,GCODE char(10) not null,AUTOINCRE int IDENTITY(1,1) not null,T_ENTRY char(2) not null,DESCCODE numeric(18,0),Additional_Name varchar (max),Additional_Header varchar (max),Bool_Code bit , primary key clustered (FICode,GCODE,T_ENTRY,AUTOINCRE))";
                        edpcom.RunCommand(strFormula, CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("06/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string sqlstr = "alter table BillAdditionalDetails alter column transPortName varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column ConsingmentNo varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column ConsingmentDate varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column NoofPackages varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column SRVNO varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column SRVNODate varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column LorryNo varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Weight varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Delivery_At varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Kind_Attention varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Phone varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Mode_Of_Transport  varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Prepared_by varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Indent varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Advance varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Invoice_Preparetion varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Removal_Date varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Removal_Time varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column InvoiceIssueDate varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column InvoiceIssueTime varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Your_Order_No varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Your_Order_Date varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Payment_Terms varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Payment_Date varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Dom_Expo_Remarks varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column CST_Declaration varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Form_No varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Form_Name varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Cash_PartyName varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Cash_PartyAddress varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Cash_PartyAddress2 varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Cash_Partyphone varchar(MAX)" +
                            " alter table BillAdditionalDetails alter column Broker_Name varchar(MAX)";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("07/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string strFormula = "ALTER TABLE FinishGoods_Details ADD Ref_Tentry char(2),Ref_voucher numeric(18,0)";
                        edpcom.RunCommand(strFormula, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("08/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('50250000000','50000000000','Set Auto BackUp Path','SetAutoBackUpPath', 1 , 0 )", CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("09/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string strFormula = "ALTER TABLE BillAdditionalDetails ADD Consignment_no varchar(max),Consignment_date varchar(max),Supplier_no varchar(max),Supplier_date varchar(max)";
                        edpcom.RunCommand(strFormula, CON);
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("10/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('40020101080','40020101000','Sales Order Report','SalesOrderReport', 1 , 0 )", CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE IGLMST ADD Chk_Purchase bit,Chk_Sales bit", CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("11/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        String sqlstr = "delete from TypeDoc_Config where OPTION_CODE='1036'";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("19/08/14"))
                {
                    try
                    {
                        edpcom.SetInRegistry(DateTime.Now.ToShortDateString(), "START_DATE", "SOFTWARE\\DATARAM");
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("20/08/14"))
                {
                    try
                    {
                        SqlCommand mycmd = new SqlCommand();
                        CON.Close();
                        CON.Open();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20020102000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20030201000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20040100000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30010500000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30020100000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30030100000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30030200000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30040000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30050000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010405000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010406000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010408010 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010413000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010501000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010503000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010504000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010505000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020203000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020207010 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50010000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50050000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50100000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60160000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30030000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020500000 ", CON);
                        mycmd.ExecuteNonQuery();
                        CON.Close();

                        CON.Close();
                        CON.Open();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20020102000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20030201000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20040100000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=30010500000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=30020100000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=30030100000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=30030200000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=30040000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=30050000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40010405000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40010406000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40010408010 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40010413000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40010501000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40010503000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40010504000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40010505000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40020203000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40020207010 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=50010000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=50050000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=50100000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=60160000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=30030000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40020500000 ", CON);
                        mycmd.ExecuteNonQuery();
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("21/08/14"))
                {
                    try
                    {
                        SqlCommand mycmd = new SqlCommand();
                        CON.Close();
                        CON.Open();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='True' where MENUCODE=40020203000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True',MENUDESC='Stock Ledger' where MENUCODE=40020203000 ", CON);
                        mycmd.ExecuteNonQuery();
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("22/08/14"))
                {

                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE IGLMST ADD PRODUCT_TYPE VARCHAR(50) Null", CON);
                        CON.Close();
                    }
                    catch { }

                    try
                    {
                        SqlCommand mycmd = new SqlCommand();
                        CON.Close();
                        CON.Open();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20040000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30030000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40040000000 ", CON);
                        mycmd.ExecuteNonQuery();

                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20040000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=30030000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40030000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=40040000000 ", CON);
                        mycmd.ExecuteNonQuery();
                        //UpdateMethods.UpdateTrigComWACCOPTN(CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }

                if (Cbuild_date < Convert.ToDateTime("23/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,3,'3110000000','3.11','Vat',NULL,null,'True',0,0,'3000000000','False')";
                            edpcom.RunCommand(str, CON);
                        }
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("26/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('20010307000','20010300000','Stock In Hand','StockInHand', 1 , 0 )", CON);
                        edpcom.RunCommand("update MenuTable set MENUDESC ='Stock hand Details '  where MENUCODE=20010400000 ", CON);

                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("28/08/14"))
                {
                    CON.Close();
                    CON.Open();
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE CSTOCK DROP CONSTRAINT PK__CSTOCK__5441852A", CON);
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE CSTOCK DROP CONSTRAINT PK__CSTOCK__5070F446", CON);
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE CSTOCK ALTER Column MGROUP numeric(18, 0) not null", CON);
                        edpcom.RunCommand("ALTER TABLE CSTOCK ALTER Column SGROUP numeric(18, 0) not null", CON);
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE CSTOCK ADD PRIMARY KEY(FICODE,GCODE,SDATE,GLCODE,MGROUP,SGROUP)", CON);
                    }
                    catch { }

                    try
                    {
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020207000 ", CON);
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30010106000 ", CON);
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=71010000000 ", CON);

                        edpcom.RunCommand("Delete from MenuUser where MENUCODE=40020207000 ", CON);
                        edpcom.RunCommand("Delete from MenuUser where MENUCODE=30010106000 ", CON);
                        edpcom.RunCommand("Delete from MenuUser where MENUCODE=71010000000 ", CON);
                    }
                    catch { }

                    CON.Close();


                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,1,'1010800000','1.1.8','Cheque Print',NULL,null,'False',0,0,'1010000000','False')";
                            edpcom.RunCommand(str, CON);
                        }
                        //UpdateMethods.UpdateTrigComWACCOPTN(CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("29/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020600000 ", CON);
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=30010106000 ", CON);
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30020501000 ", CON);
                        edpcom.RunCommand("Delete from MenuUser where MENUCODE=40020600000 ", CON);
                        edpcom.RunCommand("update WACCOPTN set OPTION_DESC='Cheque Print' where SeriesNo='4.5.1'", CON);
                        edpcom.RunCommand("Delete from WACCOPTN where SeriesNo='1.1.8' ", CON);
                        edpcom.RunCommand("Delete from WACCOPTN where SeriesNo='3.11' ", CON);

                        //UpdateMethods.UpdateTrigComWACCOPTN(CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }
                if (Cbuild_date < Convert.ToDateTime("30/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=40020500000 ", CON);
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=40030000000 ", CON);
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030100000 ", CON);
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030200000 ", CON);
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030400000 ", CON);
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030302000 ", CON);
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030303000 ", CON);
                        edpcom.RunCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030304000 ", CON);
                        //UpdateMethods.UpdateTrigComWACCOPTN(CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }

                if (Cbuild_date < Convert.ToDateTime("31/08/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.UpdateTrigComWACCOPTN(CON);
                        CON.Close();
                    }
                    catch { }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);

                            string str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,7,'701000000','7.1','Narration 01[Alt+Shift+F1]',NULL,null,'True',0,0,'7000000000','')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,7,'702000000','7.2','Narration 02 [Alt+Shift+F2]',NULL,null,'True',0,0,'7000000000','')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,7,'703000000','7.3','Narration 03 [Alt+Shift+F3]',NULL,null,'True',0,0,'7000000000','')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,7,'704000000','7.4','Narration 04 [Alt+Shift+F4]',NULL,null,'True',0,0,'7000000000','')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,7,'705000000','7.5','Narration 05 [Alt+Shift+F5]',NULL,null,'True',0,0,'7000000000','')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,7,'706000000','7.6','Narration 06 [Alt+Shift+F6]',NULL,null,'True',0,0,'7000000000','')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,7,'707000000','7.7','Narration 07 [Alt+Shift+F7]',NULL,null,'True',0,0,'7000000000','')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,7,'708000000','7.8','Narration 08 [Alt+Shift+F8]',NULL,null,'True',0,0,'7000000000','')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,7,'709000000','7.9','Narration 09 [Alt+Shift+F9]',NULL,null,'True',0,0,'7000000000','')";
                            edpcom.RunCommand(str, CON);
                            str = "INSERT INTO WACCOPTN(FICode,Gcode,USER_CODE,MENU_CODE,OPTION_CODE,SeriesNo,OPTION_DESC,STR_VAL,DATE_VAL,BOOL_VAL,NUM_VAL,DFLT_VAL,PARENT_CODE,MEMO_VAL) VALUES('" + FICODE + "','" + GCODE + "',1,7,'710000000','7.10','Narration 10 [Alt+Shift+F10]',NULL,null,'True',0,0,'7000000000','')";
                            edpcom.RunCommand(str, CON);
                        }
                        CON.Close();
                    }
                    catch { }
                    CON.Close();
                    CON.Open();
                    edpcom.RunCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=50170000000 ", CON);
                    CON.Close();
                }

                if (Cbuild_date < Convert.ToDateTime("03/09/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        string strForm = "CREATE TABLE BankingInstrumentMaster (FICODE numeric (18,0) NOT NULL,GCODE numeric (18,0) NOT NULL,Instrument_CODE numeric (18,0) NOT NULL,Instrument_Name VARCHAR (100) NOT NULL,Lag_Days VARCHAR (50) NULL,primary key clustered (FICODE,GCODE,Instrument_CODE))";
                        edpcom.RunCommand(strForm, CON);
                    }
                    catch {CON.Close(); }
                    try
                    {
                        CON.Close();
                        CON.Open();
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT FICODE,GCODE FROM WACCOPTN", CON);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "FIG");

                        for (int i = 0; i <= ds.Tables["FIG"].Rows.Count - 1; i++)
                        {
                            string FICODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["FICODE"]);
                            string GCODE = Convert.ToString(ds.Tables["FIG"].Rows[i]["GCODE"]);
                            edpcom.RunCommand("insert into BankingInstrumentMaster (FICODE,GCODE,Instrument_CODE,Instrument_Name,Lag_Days)values('" + FICODE + "','" + GCODE + "',1,'Cheque','2')", CON);
                            edpcom.RunCommand("insert into BankingInstrumentMaster (FICODE,GCODE,Instrument_CODE,Instrument_Name,Lag_Days)values('" + FICODE + "','" + GCODE + "',2,'Demand Draft (DD)','2')", CON);
                            edpcom.RunCommand("insert into BankingInstrumentMaster (FICODE,GCODE,Instrument_CODE,Instrument_Name,Lag_Days)values('" + FICODE + "','" + GCODE + "',3,'Pay Order','2')", CON);
                            edpcom.RunCommand("insert into BankingInstrumentMaster (FICODE,GCODE,Instrument_CODE,Instrument_Name,Lag_Days)values('" + FICODE + "','" + GCODE + "',4,'Bankers Cheque','2')", CON);
                            edpcom.RunCommand("insert into BankingInstrumentMaster (FICODE,GCODE,Instrument_CODE,Instrument_Name,Lag_Days)values('" + FICODE + "','" + GCODE + "',5,'NEFT','1')", CON);
                            edpcom.RunCommand("insert into BankingInstrumentMaster (FICODE,GCODE,Instrument_CODE,Instrument_Name,Lag_Days)values('" + FICODE + "','" + GCODE + "',6,'RTGS','0')", CON);
                            edpcom.RunCommand("insert into BankingInstrumentMaster (FICODE,GCODE,Instrument_CODE,Instrument_Name,Lag_Days)values('" + FICODE + "','" + GCODE + "',7,'SWIFT','3')", CON);
                            edpcom.RunCommand("insert into BankingInstrumentMaster (FICODE,GCODE,Instrument_CODE,Instrument_Name,Lag_Days)values('" + FICODE + "','" + GCODE + "',8,'ATM Deposit','0')", CON);
                            edpcom.RunCommand("insert into BankingInstrumentMaster (FICODE,GCODE,Instrument_CODE,Instrument_Name,Lag_Days)values('" + FICODE + "','" + GCODE + "',9,'ATM Withdrawal','0')", CON);
                            edpcom.RunCommand("insert into BankingInstrumentMaster (FICODE,GCODE,Instrument_CODE,Instrument_Name,Lag_Days)values('" + FICODE + "','" + GCODE + "',10,'Cash Deposit','0')", CON);
                            edpcom.RunCommand("insert into BankingInstrumentMaster (FICODE,GCODE,Instrument_CODE,Instrument_Name,Lag_Days)values('" + FICODE + "','" + GCODE + "',11,'Cash Withdrawal','0')", CON);
                        }
                        CON.Close();
                    }
                    catch { CON.Close(); }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.CreateTDSCategory(CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }

                if (Cbuild_date < Convert.ToDateTime("04/09/14"))
                {

                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("ALTER TABLE Narr ADD Instrument_CODE numeric (18,0) Null", CON);
                        CON.Close();

                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("update Narr set  Instrument_CODE =1 where NTYPE='C'", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("05/09/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand(" Update MenuTable Set MENUDESC='Confirmation A/Cs' Where MENUCODE='40010422010'");
                        CON.Close();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("18/09/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();

                        string sqlstr = " alter table Branch alter column BRNCH_NAME varchar(MAX)";
                        edpcom.RunCommand(sqlstr, CON);
                        sqlstr = " alter table Company alter column CO_NAME varchar(MAX)";
                        edpcom.RunCommand(sqlstr, CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("19/09/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.TrigCompOnInsUpdate(CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("29/09/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("alter table iglmst alter column Excise_Per numeric(18,4)", CON);
                        edpcom.RunCommand("alter table iglmst alter column E_Cess_Per numeric(18,4)", CON);
                        edpcom.RunCommand("alter table iglmst alter column SHE_Cess_Per numeric(18,4)", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("08/10/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        UpdateMethods.Party_Transaction(CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }

                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("Insert into menutable values('40010421100','40010400000','Interest Calculation','InterestCalculation',1,' ',' ',0)", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("31/10/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("alter table prtyms ADD Dep_Per numeric(18,2) Null", CON);                       
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("01/11/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("Update MenuTable Set ENABLE_MENU=1 Where MENUCODE='40010412000'");
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("10/11/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("alter table iglmst alter column Excise_Per numeric(18,5)", CON);
                        edpcom.RunCommand("alter table iglmst alter column E_Cess_Per numeric(18,5)", CON);
                        edpcom.RunCommand("alter table iglmst alter column SHE_Cess_Per numeric(18,5)", CON);
                        edpcom.RunCommand("alter table iglmst alter column OP_RATE numeric(18,5)", CON);
                        edpcom.RunCommand("alter table iglmst alter column MKT_RATE numeric(18,5)", CON);
                        edpcom.RunCommand("alter table iglmst alter column SALE_RATE numeric(18,5)", CON);
                        edpcom.RunCommand("alter table iglmst alter column VAL_RATE numeric(18,5)", CON);
                        edpcom.RunCommand("alter table iglmst alter column vatpercent numeric(18,5)", CON);
                        edpcom.RunCommand("alter table iglmst alter column AmtBasePercent numeric(18,5)", CON);
                        edpcom.RunCommand("alter table iglmst alter column Cstpercent numeric(18,5)", CON);
                        edpcom.RunCommand("alter table iglmst alter column ST_PER numeric(18,5)", CON);
                        //edpcom.RunCommand("alter table iglmst alter column PurRate numeric(18,5)", CON);
                        edpcom.RunCommand("alter table MarketRateUpdate alter column Rate numeric(18,5)", CON);
                        edpcom.RunCommand("alter table iglmst alter column EDU_CESS_PER numeric(18,5)", CON);
                        edpcom.RunCommand("alter table iglmst alter column HI_EDU_CESS_PER numeric(18,5)", CON);
                        edpcom.RunCommand("alter table itran alter column RATE numeric(18,5)", CON);
                        edpcom.RunCommand("alter table LinkVATGLMST alter column Vat_Per numeric(18,5)", CON);
                        edpcom.RunCommand("alter table VATMaster alter column VAT_PERCENT numeric(18,5)", CON);
                       
                        //edpcom.RunCommand("alter table MarketRateUpdate alter column PurRate numeric(18,5)", CON);                       
                        //edpcom.RunCommand("alter table iglmst alter column EDU_CESS_PER numeric(18,5)", CON);
                        CON.Close();
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("29/11/14"))
                {
                    CON.Close();
                    CON.Open();
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE CSTOCK DROP CONSTRAINT PK__CSTOCK__0F8BB43F25518C17", CON);
                        edpcom.RunCommand("ALTER TABLE CSTOCK ADD PRIMARY KEY(FICODE,GCODE,SDATE,GLCODE,MGROUP,SGROUP)", CON);
                    }
                    catch { }
                    CON.Close();
                }

                if (Cbuild_date < Convert.ToDateTime("11/12/14"))
                {
                    try
                    {
                        CON.Close();
                        CON.Open();
                        edpcom.RunCommand("INSERT INTO MenuTable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,TOOLBARBTN) VALUES ('20010308000','20010300000','Day Book','DayBook', 1 , 0 )", CON);
                        CON.Close();
                    }
                    catch { CON.Close(); }
                }



                CON.Close();
                CON.Open();
                UpdtDBInfo(CON);    //this will be call only one time.
                Versionflg = true;
            }

            this.Close();
        }

        private void ControlFileDeletionCreation()
        {
            try
            {
                string filePath = Application.StartupPath + "\\ControlSettings.edp";
                filePath = @filePath;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    FileStream aFile = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
                    aFile.Close();
                }
            }
            catch { }
        }

        private void SectorMasterInsert(SqlConnection Con)
        {
            try
            {
                string sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (1,'Banks','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (2,'Energy','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (3,'Technology','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (4,'Pharma','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (5,'Eng Cons & Mch','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (6,'Financial','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (7,'Agriculture','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (8,'Metal & Mining','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (9,'FMCG','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (10,'Media & Ent','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (11,'Power','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (12,'Chemicals','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (13,'Auto','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (14,'Telecommunications','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (15,'Auto Ancillary','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (16,'Textiles','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (17,'Miscellaneous Manufacture','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (18,'Retail','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (19,'Metal Fabricate/Hardware','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (20,'Commercial Services','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (21,'Consumer Durable','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (22,'Building Materials','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (23,'Others','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (24,'Defence','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (25,'Healthcare','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (26,'Diversified','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (27,'Transportation & Logistics','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (28,'Airlines','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (29,'Forest  Products & Paper','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (30,'Distribution/wholesale','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (31,'Education','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (32,'Hotels & Motels','1')";
                edpcom.RunCommand(sqlstr);                
            }
            catch { }
        }

        private void glmstRectification(SqlConnection Con)
        {
            string qry = "Update glmst set [ALOC_CODE]='0000000000',[CONS_FLG]=0,[PDF_TYPE]='C',[PDF_CODE]='2',[ACTV_FLG]=1,[NCONV_FCTR]='1',[DCONV_FCTR]=1,[TRANS_CLOS]=1,";
            qry = qry + "[EXCHG_DIFF]=0,[FC_CURBAL]=0,[FC_OPBAL]=0,[FC_LBAL]=0,[EXDIFF_VAL]=0,[CFLOW_GROUP]='A',[LOCK]='0' Where Mtype='L' and aloc_code is null";
            try { edpcom.RunCommand(qry); }

            catch { }
        }

        private void InvUpdate(SqlConnection Con)
        {
            try
            {
                string sqlstr = "ALTER TABLE InvMst ADD OrgnIdesc varchar(150) null,Actv_Val bit null";
                edpcom.RunCommand(sqlstr);
            }
            catch { }
        }

        private void AlterCompanyTrigger()
        {
            string SqlStr = "";
            SqlStr = "ALTER TRIGGER [dbo].[TrigCompOnglmstIn] on [dbo].[Company] For insert as set nocount on " + Environment.NewLine +
            "Declare @gcode Char(10),@ficode varchar(10)" + Environment.NewLine +
            "select @gcode=gcode,@ficode=ficode from inserted" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',5,0,33,'Investment in Bullion',NULL,30,0,0,0,1,0,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0',NULL)" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',5,0,34,'Insurance Premium Paid','TRAD',30,0,0,0,1,0,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0',NULL)" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',5,0,35,'Investment in ULIP','ULIP',30,0,0,0,1,0,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0',NULL)" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',5,0,36,'Investment in Fixed Deposit',NULL,30,0,0,0,1,0,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0',NULL)" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',6,13,29,'Stock of Shares','STKS',70,0,0,0,1,13,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0',NULL)" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',8,18,28,'Purchase of Shares','POS',50,0,0,0,1,18,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0',NULL)" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',9,0,27,'Sale of Shares','SOS',60,0,0,0,1,0,'0000000000',0,'C','1',0,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0',NULL)" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',11,0,26,'Profit from Trading in Commodities','PTCOM',30,0,0,0,1,0,'0000000000',0,'C','1',0,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0',NULL)" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',11,0,30,'Profit from Trading in F&O','PTFO',30,0,0,0,1,0,'0000000000',0,'C','1',0,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0',NULL)" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',11,0,31,'Loss from Trading in F&O','LTFO',30,0,0,0,1,0,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0',NULL)" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',11,0,32,'Loss from Trading in Commodities','LTCOM',30,0,0,0,1,0,'0000000000',0,'C','2',0,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 6,14,1,  'Cash Account', null, 20, 0, 0, 0, 1, 14, '0000000000', 0, 'D','1' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 12, 0, 2,  'Profit & Loss A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 6, 0, 3,  'Opening Balance Debit A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','3' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 3, 0, 4,  'Opening Balance Credit A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','4' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 5, 0, 5,  'Investment In Shares', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 5, 0, 6,  'Investment In Mutual Funds', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 3, 27, 7,  'Broker A/C', null, 30, 0, 0, 0, 1, 27, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 8,  'Security Transaction Tax','STT', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 9,  'Service Tax', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 10,  'Transaction Charges', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 11,  'Long Term Capital Loss', 'LTCL', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 12,  'Short Term Capital Loss', 'STCL', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 13,  'Miscellenious Charges', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 11, 0, 14,  'Long Term Capital Gain', 'LTCG', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 11, 0, 15,  'Short Term Capital Gain', 'LTCL', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 16,  'Long Term Capital Loss On Mutual Fund', 'LTCLMF', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 17,  'Short Term Capital Loss On Mutual Fund', 'STCLMF', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 11, 0, 18,  'Long Term Capital Gain On Mutual Fund', 'LTCGMF', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 11, 0, 19,  'Short Term Capital Gain On Mutual Fund', 'STCGMF', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 20,  'Trn.Over Charges', 'TOC', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 21,  'Stamp Charges', 'SC', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 3, 6, 22,  'Edu. CESS A/C', 'EC', 30, 0, 0, 0, 1, 6, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 3, 6, 23,  'Higher Edu. CESS A/C', 'HEC', 30, 0, 0, 0, 1, 6, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 1, 1, 0,  'Reserve & Surplus', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','13' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 2, 2, 0,  'Secured Loans', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','14' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 2, 3, 0,  'Unsecured Loans', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','15' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 2, 4, 0,  'Bank Overdraft', null, 21, 0, 0, 0, 1, 0, '0000000000', 0, 'C','16' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3, 5, 0,  'Sundry Creditors', null, 23, 0, 0, 0, 1, 0, '0000000000', 0, 'C','17' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',3,  6, 0,  'Duties & Taxes', null, 32, 0, 0, 0, 1, 0, '0000000000', 0, 'C','18' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3,  7, 0,  'Provision', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','19' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3,  8, 0,  'Provision for Taxation', null, 30, 0, 0, 0, 2, 7, '0000000000', 0, 'C','20' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3,  9, 0,  'Provision for Dividend', null, 30, 0, 0, 0, 2, 7, '0000000000', 0, 'C','21' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 4, 10, 0,  'Fixed Asstes at Cost', null, 30, 0, 0, 0,1, 0, '0000000000', 0, 'D','22' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 4, 11, 0,  'Less Accumulated Depreciation', null, 30, 0, 0, 0, 1,0, '0000000000', 0, 'C','23' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 12, 0,  'Sundry Debtors', null, 22, 0, 0, 0, 1, 0, '0000000000', 0, 'D','24' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 13, 0,  'Stock in Hand', null, 70, 0, 0, 0, 1, 0, '0000000000', 0, 'D','25' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 14, 0,  'Cash Balances', null, 20, 0, 0, 0, 1, 0, '0000000000', 0, 'D','26' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 15, 0,  'Bank Balances', null, 21, 0, 0, 0, 1, 0, '0000000000', 0, 'D','27' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 16, 0,  'Short Term Investments', null, 21, 0, 0, 0, 2, 15, '0000000000', 0, 'D','28' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 17, 0,  'Loans and Advances', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 8, 18, 0,  'Purchase Account', null, 50, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',10, 19, 0,  'Administration & Selling Expenses', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',10, 20, 0,  'Finance Expenses', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',10, 21, 0,  'Interest Expenses', null, 31, 0, 0, 0, 2, 20, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',10, 22, 0,  'Dividend Expenses', null, 31, 0, 0, 0, 2, 20, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',11, 23, 0,  'Profit on Sale of Investments', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',11, 24, 0,  'Profit on Sale of Fixed Assets', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',11, 25, 0,  'Investment Income', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',11, 26, 0,  'Extraordinary Expenses', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3, 27, 0, 'Broker', null, 23, 0, 0, 0, 2, 5, '0000000000', 0, 'C','40' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL) " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 4, 28, 0,  'Less Depriciation Of Factory Equipments', null, 33, 0, 0, 0, 1,0, '0000000000', 0, 'C','41' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 8, 29, 0,  'Opening Stock', null, 30, 0, 0, 0, 1,0, '0000000000', 0, 'C','41' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 5, 0, 24,  'Investment In Commodities', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0',NULL)" + Environment.NewLine +
         "INSERT INTO prtyms(FICode,GCODE,GLCode,STT,SERVICE_TAX,brokShrtsl,brokPurchase,BRKG_PERCENTAGE,CRED_DAYS) VALUES(@ficode,@gcode, 7, 0.25, 12.36, 0.5, 0.5, 0.5,7)" + Environment.NewLine +
         "set nocount off";



        }

        //private void AddUpdateINFLT()
        //{
        //    try
        //    {
        //        edpcom.RunCommand(" Update INFLT Set indxval=582 Where stindxdt='04/01/2008'");
        //        edpcom.RunCommand(" Insert into INFLT Values('04/01/2009','03/31/2010',632)");
        //        edpcom.RunCommand(" Insert into INFLT Values('04/01/2010','03/31/2011',650)");
        //    }
        //    catch { }
        //}

        private void UpdateMenu()
        {
            try
            {
                edpcom.RunCommand(" Update MenuTable Set MENUDESC='Investment/Trading Reports' Where MENUCODE='50020000000'");
            }
            catch { }
        }

        private void AssetPropFld()
        {
            string strmfmst = "CREATE TABLE [AssetPropFld]([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,[FieldID] [numeric](18, 0) NOT NULL,[AssetClass] [varchar](50) NULL,[TransactionClass] [varchar](50) NULL,[FieldName] [varchar](100) NULL,[FieldLength] [int] NULL,[FIeldType] [varchar](50)  NULL,[NullCheck] [bit] NULL,[PrintName] [varchar](50)NULL,[Dfltval] [varchar](max) NULL,CONSTRAINT [PK_AssetPropFld] PRIMARY KEY CLUSTERED ([Ficode] ASC,[Gcode] ASC,[FieldID] ASC))";
            try
            {
                edpcom.RunCommand(strmfmst);
            }
            catch { }
        }        

        private void createvchlocktable(SqlConnection CON)
        {
            string strvchlock = " Drop table vchlock ";
            strvchlock = strvchlock + " create table vchlock(FICode char(10) not null,GCODE char(10) not null,VTYPE char(1) not null,T_ENTRY char(2) not null,VOUCHER numeric not null,";
            strvchlock = strvchlock + " [AutoIncre] [numeric](18, 0) IDENTITY(1,1) NOT NULL,USER_VCH	varchar(100),EDITFLAG char(1),USERCODE varchar(6),MODIFIED bit,ZEROFLG char(1),ViewFlag bit";
            strvchlock = strvchlock + " primary key clustered(FICode,GCODE,VTYPE,T_ENTRY,VOUCHER,[AutoIncre]))";
            SqlCommand cmd = new SqlCommand(strvchlock, CON);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        private void FDIntUpdate(SqlConnection CON)
        {
            string str = "ALTER TABLE FDInt ADD NetInterest money null";
            try
            {
                edpcom.RunCommand(str, CON);
            }
            catch { }
        }

        private void VchLockUpdate(SqlConnection CON)
        {
            string strvchlock = "drop table vchlock create table vchlock(FICode char(10) not null,GCODE char(10) not null,VTYPE char(1) not null,T_ENTRY char(2) not null,VOUCHER numeric not null,";
            strvchlock = strvchlock + "[AutoIncre] [numeric](18, 0) IDENTITY(1,1) NOT NULL,USER_VCH	varchar(100),EDITFLAG char(1),USERCODE varchar(6),MODIFIED bit,ZEROFLG char(1),ViewFlag bit";
            strvchlock = strvchlock + "primary key clustered(FICode,GCODE,VTYPE,T_ENTRY,VOUCHER,[AutoIncre]))";
            SqlCommand cmd = new SqlCommand(strvchlock, CON);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            { }
        }

        private void AlterProcTypeMast(SqlConnection CON)
        {
            string sqlstr = " Alter proc TypeMast_ins @pFICode char(10),@pGcode char(10) as begin" + Environment.NewLine;
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
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9','Sales','Sale')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'n','Sales Challan','SaleChal')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8','Purchase','Purchase')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'a','Purchase Challan','PurChal')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9C','Credit Sale','CrSale')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'m','Credit Sales Challan','CrSalCha')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'SO','Stock Out','StkOut')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'SI','Stock In','StkIn')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'OS','Sales Order','SelOrd')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'OP','Purchase Order','PurOrd')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'CM','Consume Row Meterial','CRM')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'PI','Purchase Indent','PurInd')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'SR','Sales Return','SRETURN')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'PR','Purchase Return','PR')" + Environment.NewLine;
            //New Tentry
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'SC','Sale Return Challan','SRC')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'FG','FGR','FGR')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'MR','MFG Issue Return','MFGIR')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'NM','NON MFG Issue Return','NMFGIR')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'PC','Purchase Return Challan','PRC')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'MI','MFG Issue','MFGI')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'NI','Non MFG Issue','NMFGI')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'GR','FGR Return','FGRR')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'LT','Loc Trans','LT')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'PN','Production Order','PN')" + Environment.NewLine;
            //New Tentry
            //Purchase Order
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1001','Apply Discount','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1008','Vat Calculation On Addless Elements','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1023','ON Vat/Cst Persentage','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1024','Print Format','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1025','Active Location Name','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1026','Item Details','False','False')" + Environment.NewLine;

            //Purchase Entry
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1008','Vat Calculation On Addless Elements','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1012','Set Cash Memo/Bill Active','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1018','Multi Currency','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1019','Multiple Purchase A/C','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1022','Addless Auto Round Off','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1028','Line Item Amount Auto Round Off','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1029','Party Details in Cash Memo','False','False')" + Environment.NewLine;
            //Purchase Return
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1008','Vat Calculation On Addless Elements','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1018','Multi Currency','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1019','Multiple Purchase A/C','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1022','Addless Auto Round Off','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1028','Line Item Amount Auto Round Off','False','False')" + Environment.NewLine;

            //Purchase Challen
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1008','Vat Calculation On Addless Elements','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1019','Multiple Purchase A/C','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1023','ON Vat/Cst Persentage','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1024','Print Format','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1025','Active Location Name','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1026','Item Details','False','False')" + Environment.NewLine;


            //Purchase Indent                        
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PI','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PI','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PI','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PI','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PI','1024','Print Format','False','False')" + Environment.NewLine;

            //Sales Entry 
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1003','VAT Applicability and Type','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1004','Document Print Format','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1008','Vat Calculation On Addless Elements','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1011','Product Qty Unitary by Default','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1012','Set Cash Memo/Bill Active','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1013','Set Auto Complete Line Item','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1018','Multi Currency','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1019','Multiple Sales A/C','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1020','Item Wise Details','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1021','Consignee Party','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1022','Addless Auto Round Off','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1028','Line Item Amount Auto Round Off','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1029','Party Details in Cash Memo','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1031','Document Title','False','Tax Invoice')" + Environment.NewLine;

            //Sales Return 
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1003','VAT Applicability and Type','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1004','Document Print Format','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1008','Vat Calculation On Addless Elements','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1018','Multi Currency','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1019','Multiple Sales A/C','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1022','Addless Auto Round Off','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1028','Line Item Amount Auto Round Off','False','False')" + Environment.NewLine;

            //Sales Challan
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'n','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'n','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'n','1019','Multiple Sales A/C','False','False')" + Environment.NewLine;

            //Sales Order
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OS','1001','Apply Discount','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OS','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OS','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OS','1007','oncessional Tax Form Name','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OS','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OS','1019','Multiple Sales A/C','False','False')" + Environment.NewLine;

            //Receipts
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'1','1010','Enable display current bal','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'1','1014','Online Party/Money Receipt Print','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'1','1015','Online Voucher Print','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'1','1018','Multi Currency','False','False')" + Environment.NewLine;

            //Payments
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'2','1010','Enable display current bal','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'2','1015','Online Voucher Print','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'2','1016','Payment Advise Print','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'2','1017','Online Cheque Print','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'2','1018','Multi Currency','False','False')" + Environment.NewLine;

            //Journal
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'3','1010','Enable display current bal','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'3','1015','Online Voucher Print','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'3','1018','Multi Currency','False','False')" + Environment.NewLine;

            //Contra
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'5','1010','Enable display current bal','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'5','1015','Online Voucher Print','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'5','1018','Multi Currency','False','False')" + Environment.NewLine;

            //Debit Note
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'7','1010','Enable display current bal','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'7','1015','Online Voucher Print','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'7','1018','Multi Currency','False','False')" + Environment.NewLine;

            //Credit Note
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'4','1010','Enable display current bal','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'4','1015','Online Voucher Print','False','False')" + Environment.NewLine;
            sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'4','1018','Multi Currency','False','False')" + Environment.NewLine;

            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'1','Receipt','Rcpt')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'2','Payment','Pymt')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'3','Journal ','Jrnl')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'4','Credit Note','Crnt')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'5','Contra','Cntra')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'6','Cheque Return','Chqrtrn')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'7','Debit Note','Dbnt')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8','Market Purchase','MP')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9','Sale','Sale')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8O','Opening','Opng')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'S','Short Sale','Shrtsle')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AA','Applied For','Appf')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AB','Allotment','Altmnt')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AC','Refund','Refnd')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'C','Composite Transaction','Cmpt')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8G','GiftIn','GftIn')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9G','GiftOut','GftOut')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8S','StockIn','StckIn')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9S','StockOut','StckOut')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'N','Conversion','Cnvsn')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8I','Insurance','Insu')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8F','Fixed Deposite','FD')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9F','Fixed Deposite Redeem','FDR')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'M','Commodities','Comm')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'U','Mutual Funds','MF')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'DE','Dividend Entry','Div')" + Environment.NewLine;
            //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'DE','Dividend Entry','Div')" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " end";
            SqlCommand cmd = new SqlCommand(sqlstr, CON);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        private void DividendTablecreation(SqlConnection CON)
        {
            string Divident_Schedlr = "Drop table Divident_Schedlr";
            SqlCommand cmd = new SqlCommand(Divident_Schedlr, CON);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            Divident_Schedlr = "CREATE TABLE [Divident_Schedlr]([Ficode] [char](10) NOT NULL,[Gcode] [char](10) NOT NULL,[User_Vch] [varchar](max) NULL,[Voucher] [numeric](18, 0) NOT NULL," +
                "[T_entry] [char](2) NOT NULL,[Vch_Date] [datetime] NOT NULL,[AutoIncNo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,[Pcode] [numeric](18, 0) NULL,[DPcode] [numeric](18, 0) NULL,[Declare_Date] [datetime] NULL," +
                "[Applicable_Date] [datetime] NULL,[Total_Qty] [decimal](18, 0) NULL,[Declare_Qty] [decimal](18, 0) NULL,[Div_Percent] [numeric](18, 2) NULL,[Div_pers] [numeric](18, 2) NULL,[Amount] [numeric](18, 2) NULL," +
                "[Note] [varchar](50) NULL,[Delv_Status] [varchar](50) NULL,[WarrantNo] [varchar](max) NULL,[WarrantDate] [datetime] NULL,[Options] [varchar](50) NULL,[Link_voucher] [numeric](18, 0) NULL,[Link_tentry] [char](2) NULL," +
                "[Desccode] [numeric](18, 0) NULL,[Financial_Year] [varchar](50) NULL,PRIMARY KEY CLUSTERED ([Ficode] ASC,[Gcode] ASC,[Voucher] ASC,[T_entry] ASC,[Vch_Date] ASC,[AutoIncNo] ASC))";
            cmd = new SqlCommand(Divident_Schedlr, CON);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
        }

        //private void UpdateFrmMst(SqlConnection CON)
        //{
        //    string sqlstr = "ALTER TABLE Formula_Master ADD Icode numeric(18, 0) Null";
        //    try
        //    {
        //        edpcom.RunCommand(sqlstr, CON);
        //    }
        //    catch { }
        //}

        private void AlterProcCopyBrker(SqlConnection CON)
        {
            string sqlstr = "Alter PROCEDURE COPY_BRKS @DestFicode Char(10),@DestGcode Char(10),@SourceFicode char(10),@SourceGcode char(10),@Sdate datetime,@Edate datetime" + Environment.NewLine;
            sqlstr = sqlstr + " AS BEGIN" + Environment.NewLine;
            sqlstr = sqlstr + " execute COPY_ACC @DestFicode,@DestGcode,@SourceFicode,@SourceGcode" + Environment.NewLine;
            sqlstr = sqlstr + " DELETE FROM Formula_Master  WHERE Ficode=@DestFicode and GCODE = @DestGcode" + Environment.NewLine;
            sqlstr = sqlstr + " INSERT INTO Formula_Master( FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal)SELECT @DestFicode,@DestGcode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,@Sdate,@Edate,0 FROM Formula_Master WHERE Ficode=@SourceFicode and GCODE = @SourceGcode" + Environment.NewLine;
            sqlstr = sqlstr + " END";
            try
            {
                edpcom.RunCommand(sqlstr, CON);
            }
            catch { }
        }

        //private void UpdtDBForNominee(SqlConnection con)
        //{
        //    string strnominee = "CREATE TABLE NomineeMaster (GCODE char(10) NOT NULL,ID int NOT NULL ,Type char(2) NOT NULL ,Parent int NOT NULL ,";
        //    strnominee = strnominee + "Nominee_Name varchar(30) ,Nominee_DOB datetime ,Relation varchar (30) ,Nominee_Gur varchar(30) , Internal int ,Link_Gcode char(10)";
        //    strnominee = strnominee + "PRIMARY KEY  CLUSTERED(GCODE,ID,Type))";
        //    SqlCommand cmd = new SqlCommand(strnominee, con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch
        //    {

        //    }
        //    string strmfmst = "ALTER TABLE DPMAST ADD Nominee_ID int Null";
        //    try
        //    {
        //        edpcom.RunCommand(strmfmst, con);
        //    }
        //    catch { }
        //    strmfmst = " ALTER TABLE FixedDepositeMaster ADD Location Varchar(50) Null,Nominee_ID int Null";
        //    try
        //    {
        //        edpcom.RunCommand(strmfmst, con);
        //    }
        //    catch { }
        //    //strmfmst = " ALTER TABLE itran ADD Nominee_ID int Null";
        //    //try
        //    //{
        //    //    edpcom.RunCommand(strmfmst, con);
        //    //}
        //    //catch { }
        //    strmfmst = " ALTER TABLE ETran ADD Nominee_ID int Null";
        //    try
        //    {
        //        edpcom.RunCommand(strmfmst, con);
        //    }
        //    catch { }
        //    strmfmst = " ALTER TABLE SHARE_INFO ADD Nominee_ID int Null";
        //    try
        //    {
        //        edpcom.RunCommand(strmfmst, con);
        //    }
        //    catch { }
        //    strmfmst = " ALTER TABLE INSURANCEMST drop column RELATION ";
        //    try
        //    {
        //        edpcom.RunCommand(strmfmst, con);
        //    }
        //    catch { }
        //}

        private void UpdtDBInfo(SqlConnection con)
        {                                                //exe version  
            string cm = "insert into AccordFour_Db_Info values('DEMO','" + Environment.MachineName + "','" + edpcom.PEXE_VERSION + "','" + edpcom.getSqlDateStr(PBuildDate) + "','" + edpcom.getSqlDateStr(DateTime.Now.Date) + "')";
            SqlCommand cmd = new SqlCommand(cm, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Cannot Update DB Info.");
                con.Close();
            }
        }
        public bool chk_table_creation(SqlConnection con)
        {
            string straccss = "create table ch_k(FICode char(10) not null,USER_CODE varchar(6) not null,GCODE char(10) not null,OPTION_STRING varchar(6),";
            straccss = straccss + "ENTRY_OPTION char(2),REPORT_OPTION varchar(5),BRNCH_CODE numeric,";
            straccss = straccss + "RESTRICT_LOCN bit, primary key clustered(FICode ,USER_CODE,GCODE))";
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
        public bool alt_table_creation(SqlConnection con)
        {
            string straccss = " Alter table ch_k drop primary key(USER_CODE)";
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
        public bool currency_alter(SqlConnection con)
        {
            string straccss = " alter table currency alter column DFLT_FLG bit";
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
        public bool TrnsType_alter(SqlConnection con)
        {
            string str1 = "ALTER TABLE itran ADD TransType varchar(20)";
            string str2 = "ALTER TABLE ETran ADD  TransType varchar(20)";
            SqlCommand cmd = new SqlCommand(str1, con);
            SqlCommand cmd1 = new SqlCommand(str2, con);
            try
            {
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public bool IGLMST_alter(SqlConnection con)
        //{
        //    string str1 = "ALTER TABLE IGLMST ADD Exp_Date datetime   DEFAULT (getdate()),Unit_Of_Mez varchar(50)," +
        //        "Strike_Price numeric(18, 3),Lot_Size numeric(18, 0),Lot_Unit varchar(50)";
        //    SqlCommand cmd = new SqlCommand(str1, con);
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
        public bool RowIndx_alter(SqlConnection con)
        {

            string str1 = "ALTER TABLE itran ADD RowIndex int";
            //string str2 = "ALTER TABLE ETran ADD  RowIndex int";
            SqlCommand cmd = new SqlCommand(str1, con);
            //SqlCommand cmd1 = new SqlCommand(str2, con);
            try
            {
                cmd.ExecuteNonQuery();
               // cmd1.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public void Comment_alter(SqlConnection con)
        {

            string str1 = "ALTER TABLE itran ADD Comment Varchar(50)";
            //string str2 = "ALTER TABLE ETran ADD  Comment Varchar(50)";
            //string str3 = "Alter table EffectTran add Comment varchar(50),ItemNo numeric";
            //string str4 = "Alter table PLTran add Comment varchar(50),ItemNo numeric";
            SqlCommand cmd = new SqlCommand(str1, con);
            //SqlCommand cmd1 = new SqlCommand(str2, con);
            //SqlCommand cmd2 = new SqlCommand(str3, con);
            //SqlCommand cmd3 = new SqlCommand(str4, con);
            try
            {
                cmd.ExecuteNonQuery();
                //cmd1.ExecuteNonQuery();
                //cmd2.ExecuteNonQuery();
                //cmd3.ExecuteNonQuery();
            }
            catch { }

        }
        public bool MenuUser_alter(SqlConnection con)
        {

            string str1 = "ALTER TABLE MenuUser ADD TOOLBARBTN bit";
            SqlCommand cmd = new SqlCommand(str1, con);
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
        public void TypeMast_Updt(SqlConnection con)
        {
            string strdb = "TypeMast_ins";
            SqlCommand cmd = new SqlCommand(strdb, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter FICODE = new SqlParameter("@pFICode", edpcom.CurrentFicode);
            SqlParameter GCODE = new SqlParameter("@pGCODE", edpcom.PCURRENT_GCODE);
            cmd.Parameters.Add(FICODE);
            cmd.Parameters.Add(GCODE);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
        }
        public bool alloc_table_creation(SqlConnection con)
        {
            string stralloc = "create table alloc (FICODE char(10) NOT NULL,GCODE char(10) NOT NULL,VOUCHER numeric(18, 0) NOT NULL,AUTOINCRE int NOT NULL,";
            stralloc = stralloc + "ALLOC_NO numeric(18, 0) NULL,ALLOC_DATE datetime NOT NULL,PARTY_CODE numeric(18, 0) NOT NULL,BT_ENTRY char(2) NOT NULL,";
            stralloc = stralloc + "B_VOUCHER numeric(18, 0),B_USER_VCH varchar(50),RPT_ENTRY char(2) NULL,RP_VOUCHER numeric(18, 0),";
            stralloc = stralloc + "RP_USER_VCH varchar(50),AMT money NOT NULL,B_AMT money,RP_AMT money,CURR_CODE varchar(6),AllocFlg bit,";
            stralloc = stralloc + "primary key clustered(FICode ,GCODE,VOUCHER,AUTOINCRE))";
            SqlCommand cmd = new SqlCommand(stralloc, con);
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
        public void TriggerAdjustPLtran_creation(SqlConnection con)
        {
            string sqlstr = "CREATE TRIGGER AdjustEtran ON PLtran" + Environment.NewLine;
            sqlstr = sqlstr + " FOR INSERT, DELETE AS" + Environment.NewLine;
            sqlstr = sqlstr + " set NoCount On" + Environment.NewLine;
            sqlstr = sqlstr + " declare @AgainstTentry char(2),@AgainstVoucherCode numeric,@AgainstAutoIncre numeric,@EffectiveQTY float,@T_Entry char(2)" + Environment.NewLine;
            sqlstr = sqlstr + " if exists(Select * from deleted where T_Entry in ('C8','C9','9M','8','9','8N','9N'))" + Environment.NewLine;
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
            sqlstr = sqlstr + " else if(@T_Entry='C9') or (@T_Entry='9M') or (@T_Entry='9') or (@T_Entry='9N')" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " update etran set BALQTY=BALQTY+@EffectiveQTY,STATUS='PendingSale'  where T_ENTRY=@AgainstTentry and VOUCHER=@AgainstVoucherCode and AUTOINCRE=@AgainstAutoIncre and STATUS in('PendingSale','Complete')" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " Fetch Next From delcur into @AgainstTentry,@AgainstVoucherCode,@AgainstAutoIncre,@EffectiveQTY,@T_Entry" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " Close delcur" + Environment.NewLine;
            sqlstr = sqlstr + " Deallocate delcur" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " if exists(Select * from inserted where T_Entry in ('9M','9','8','C8','C9','8N','9N'))" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " Declare delcur1 Cursor For select AgainstTentry,AgainstVoucherCode,AgainstAutoIncre,EffectiveQTY,T_ENTRY from inserted" + Environment.NewLine;
            sqlstr = sqlstr + " Open delcur1" + Environment.NewLine;
            sqlstr = sqlstr + " Fetch Next From delcur1 into @AgainstTentry,@AgainstVoucherCode,@AgainstAutoIncre,@EffectiveQTY,@T_Entry" + Environment.NewLine;
            sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " if (@T_Entry='9M') or (@T_Entry='9') or (@T_Entry='8') or (@T_Entry='C8') or (@T_Entry='C9') or (@T_Entry='9N')" + Environment.NewLine;
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
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        public void T_ENTRY_Entry(SqlConnection con)
        {

            string sqlstr = " if exists (select * from sysobjects where id = object_id('TypeMast_ins ')" + Environment.NewLine;
            sqlstr = sqlstr + " and OBJECTPROPERTY(id, 'IsProcedure') = 1)" + Environment.NewLine;
            sqlstr = sqlstr + " drop procedure TypeMast_ins" + Environment.NewLine;
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            try
            {
                cmd.ExecuteNonQuery();
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
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'CN','Convesion','Cnvsn')" + Environment.NewLine;
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
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9','Sales','Sale')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'n','Sales Challan','SaleChal')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8','Purchase','Purchase')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'a','Purchase Challan','PurChal')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9C','Credit Sale','CrSale')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'m','Credit Sales Challan','CrSalCha')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'SO','Stock Out','StkOut')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'SI','Stock In','StkIn')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'OS','Sales Order','SelOrd')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'OP','Purchase Order','PurOrd')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'CM','Consume Row Meterial','CRM')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'PI','Purchase Indent','PurInd')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'SR','Sales Return','SRETURN')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'PR','Purchase Return','PR')" + Environment.NewLine;
                
                //New Tentry
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'SC','Sale Return Challan','SRC')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'FG','FGR','FGR')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'MR','MFG Issue Return','MFGIR')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'NM','NON MFG Issue Return','NMFGIR')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'PC','Purchase Return Challan','PRC')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'MI','MFG Issue','MFGI')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'NI','Non MFG Issue','NMFGI')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'GR','FGR Return','FGRR')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'LT','Loc Trans','LT')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'PN','Production Order','PN')" + Environment.NewLine;
                //New Tentry

                //Purchase Order
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1001','Apply Discount','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1008','Vat Calculation On Addless Elements','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1023','ON Vat/Cst Persentage','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1024','Print Format','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1025','Active Location Name','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OP','1026','Item Details','False','False')" + Environment.NewLine;

                //Purchase Entry
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1008','Vat Calculation On Addless Elements','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1012','Set Cash Memo/Bill Active','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1018','Multi Currency','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1019','Multiple Purchase A/C','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1022','Addless Auto Round Off','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1028','Line Item Amount Auto Round Off','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'8','1029','Party Details in Cash Memo','False','False')" + Environment.NewLine;

                //Purchase Return
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1008','Vat Calculation On Addless Elements','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1018','Multi Currency','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1019','Multiple Purchase A/C','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1022','Addless Auto Round Off','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PR','1028','Line Item Amount Auto Round Off','False','False')" + Environment.NewLine;

                //Purchase Challen
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1008','Vat Calculation On Addless Elements','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1019','Multiple Purchase A/C','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1023','ON Vat/Cst Persentage','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1024','Print Format','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1025','Active Location Name','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'a','1026','Item Details','False','False')" + Environment.NewLine;


                //Purchase Indent                        
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PI','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PI','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PI','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PI','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'PI','1024','Print Format','False','False')" + Environment.NewLine;

                //Sales Entry 
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1003','VAT Applicability and Type','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1004','Document Print Format','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1008','Vat Calculation On Addless Elements','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1011','Product Qty Unitary by Default','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1012','Set Cash Memo/Bill Active','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1013','Set Auto Complete Line Item','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1018','Multi Currency','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1019','Multiple Sales A/C','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1020','Item Wise Details','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1021','Consignee Party','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1022','Addless Auto Round Off','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1028','Line Item Amount Auto Round Off','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1029','Party Details in Cash Memo','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'9','1031','Document Title','False','Tax Invoice')" + Environment.NewLine;

                //Sales Return 
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1003','VAT Applicability and Type','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1004','Document Print Format','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1005','Activate Auto VAT Charges','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1007','Concessional Tax Form Name','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1008','Vat Calculation On Addless Elements','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1018','Multi Currency','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1019','Multiple Sales A/C','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1022','Addless Auto Round Off','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'SR','1028','Line Item Amount Auto Round Off','False','False')" + Environment.NewLine;

                //Sales Challan
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'n','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'n','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'n','1019','Multiple Sales A/C','False','False')" + Environment.NewLine;

                //Sales Order
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OS','1001','Apply Discount','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OS','1002','Enable Online Document Printing','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OS','1006','Concessional Tax Form Applicable','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OS','1007','oncessional Tax Form Name','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OS','1009','Search By Product Alias Name','False','False')" + Environment.NewLine;//pppp
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'OS','1019','Multiple Sales A/C','False','False')" + Environment.NewLine;


                //Receipts
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'1','1010','Enable display current bal','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'1','1014','Online Party/Money Receipt Print','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'1','1015','Online Voucher Print','False','False')" + Environment.NewLine;

                //Payments
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'2','1010','Enable display current bal','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'2','1015','Online Voucher Print','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'2','1016','Payment Advise Print','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'2','1017','Online Cheque Print','False','False')" + Environment.NewLine;

                //Journal
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'3','1010','Enable display current bal','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'3','1015','Online Voucher Print','False','False')" + Environment.NewLine;

                //Contra
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'5','1010','Enable display current bal','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'5','1015','Online Voucher Print','False','False')" + Environment.NewLine;

                //Debit Note
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'7','1010','Enable display current bal','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'7','1015','Online Voucher Print','False','False')" + Environment.NewLine;

                //Credit Note
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'4','1010','Enable display current bal','False','False')" + Environment.NewLine;
                sqlstr = sqlstr + "insert into TypeMast_Config (FICode,GCODE,T_ENTRY,OPTION_CODE,OPTION_DESC,BOOL_VAL,DFLT_VAL) values (@pFICode,@pGcode,'4','1015','Online Voucher Print','False','False')" + Environment.NewLine;


                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'6','Cheque Return','Chqrtrn')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'7','Debit Note','Dbnt')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8','Market Purchase','MP')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9','Sale','Sale')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8O','Opening','Opng')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'S','Short Sale','Shrtsle')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AA','Appliad For','Appf')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AB','Allotment','Altmnt')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AC','Refund','Refnd')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'C','Composite Transaction','Cmpt')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8G','GiftIn','GftIn')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9G','GiftOut','GftOut')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8S','StockIn','StckIn')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9S','StockOut','StckOut')" + Environment.NewLine;
                //sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'N','Convesion','Cnvsn')" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " end";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }

            }
            catch { }

        }

        public static void AlterFDInfo()
        {
            Edpcom.EDPCommon edpcom = new EDPCommon();
            string StrSql = "";
            try
            {
                StrSql = "DROP TABLE FDInfo" + Environment.NewLine +
                " CREATE TABLE [dbo].[FDInfo]( " + Environment.NewLine +
                " [FICode] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," + Environment.NewLine +
                " [GCODE] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," + Environment.NewLine +
                " [T_ENTRY] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," + Environment.NewLine +
                " [PCODE] [numeric](18, 0) NOT NULL," + Environment.NewLine +
                " [AUTOINCRE] [numeric](18, 0) IDENTITY(1,1) NOT NULL," + Environment.NewLine +
                " [VOUCHER] [numeric](18, 0) NOT NULL," + Environment.NewLine +
                " [IntType] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," + Environment.NewLine +
                " [ReceiptDate] [datetime] NULL," + Environment.NewLine +
                " [Period] [numeric](18, 0) NULL," + Environment.NewLine +
                " [PeriodUnit] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," + Environment.NewLine +
                " [StartDate] [datetime] NULL," + Environment.NewLine +
                " [MaturityDate] [datetime] NULL," + Environment.NewLine +
                " [PrincipalAmt] [money] NULL," + Environment.NewLine +
                " [AmtPaid] [money] NULL," + Environment.NewLine +
                " [IntRate] [float] NULL," + Environment.NewLine +
                " [IntUnit] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," + Environment.NewLine +
                " [FirstIntReceive] [datetime] NULL," + Environment.NewLine +
                " [Frequency] [numeric](18, 0) NULL," + Environment.NewLine +
                " [FrequencyUnit] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," + Environment.NewLine +
                " [PayOut] [numeric](18, 0) NULL," + Environment.NewLine +
                " [PayOutUnit] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," + Environment.NewLine +
                " [TDSRate] [float] NULL," + Environment.NewLine +
                " [ItemNo] [numeric](18, 0) NULL," + Environment.NewLine +
                " [RowIndex] [numeric](18, 0) NULL," + Environment.NewLine +
                " [FDState] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__FDInfo__FDState__6CD828CA]  DEFAULT ('R')," + Environment.NewLine +
             " CONSTRAINT [PK__FDInfo__24927208] PRIMARY KEY CLUSTERED " + Environment.NewLine +
            " (" + Environment.NewLine +
                " [FICode] ASC," + Environment.NewLine +
                " [GCODE] ASC," + Environment.NewLine +
                " [T_ENTRY] ASC," + Environment.NewLine +
                " [PCODE] ASC," + Environment.NewLine +
                " [AUTOINCRE] ASC," + Environment.NewLine +
                " [VOUCHER] ASC" + Environment.NewLine +
            " )WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]" + Environment.NewLine +
            " ) ON [PRIMARY]";

                edpcom.RunCommand(StrSql);
            }
            catch { }

            try
            {
                StrSql = " ALTER TABLE dbo.FDInt ADD [PayOutAnt] [numeric](18, 2) NULL";
                edpcom.RunCommand(StrSql);
            }
            catch { }

        }



    }
}