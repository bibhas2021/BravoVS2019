using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Globalization;
using Microsoft.Win32;
//==================================================
using System.Runtime.InteropServices;
//using Excel = Microsoft.Office.Interop.Excel; 

//using Excel = Microsoft.Office.Interop.Excel;

//using Microsoft.Office.Interop.Excel; //use the reference 

namespace PayRollManagementSystem
{

    public partial class frmEmpJoinExcel : Form
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        SqlTransaction sqltran;
        Edpcom.EDPCommon edpcmn = new Edpcom.EDPCommon();
        string var_file_path = "";
        string EmpId, EmpTitle, EmpFName, EmpMName, EmpLName, FathTitle, FathFN, FathMN, FathLN, MothTitle, FAge,MAge,spouse;
        string MothFN, MothMN, MothLN, HusTitle, HusFN, HusMN, HusLN;
        string EGender, ECast, EMStatus, religion, precountry, prestreet,prepin, prestate, precity, EDesg, EType;
        string Desg,JbType;
        string EDOB, EDOJ,EMob="";
        string ClientName, LocationName;
        string strEmpName = "";
        string Qualification, Board_University, Percentage, YearOfPassing;
        string DependentPerson, Relation, Age, strDependent;
        string PF, ESI, UAN, Bank, Branch, AcNo, IFSC, AcType, AadharNo, PanNo, pay_mod="2";
        string strEmpBasic = "", strEmpSal = "";

        string LogFilePath = "";

        Hashtable htFailedInsertion = new Hashtable();

        Boolean ErrorOccured = false;
        
        DataTable ds;
        string pf_limit = "15000", esi_limit = "21000";
          
        int Co_ID = 0, Location_ID = 0, Emp_ID = 0,desg_id=0,Jb_ID=0,Client_ID = 0;

        //private static Microsoft.Office.Interop.Excel.ApplicationClass appExcel;
        //private static Workbook newWorkbook = null;
        //private static _Worksheet objsheet = null;
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        //change made by dwipraj dutta 07082017
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'";
      
        public frmEmpJoinExcel()
        {
            InitializeComponent();
        }


     

        //==================================================================================================
        private string chk_dt(string vdt)
        {
            try
            {
                string[] dateonly = vdt.Split(' ');
                vdt = dateonly[0];
            }
            catch { vdt = "01/01/1900"; }
            return vdt;
        }
        private string func_dt(string vdt,string eid,string datetype)
        {
            string[] dateonly = vdt.Split(' ');
            vdt = dateonly[0];
             String[] strArr_Name = new String[2];
            strArr_Name = vdt.Split('/','.','-');
            //Edited by dwipraj dutta 080820170627PM
            try
            {
                if (strArr_Name.Length == 1)
                {
                    if (strArr_Name[0].Length == 4)
                    {
                        strArr_Name = ("01/01/" + strArr_Name[0]).ToString().Split('/', '.', '-');
                    }
                   

                }
            }
            catch { }
            try
            {
                DateTime dttt;

                int mn_val = 0;
                try
                {
                    mn_val = Convert.ToInt32(strArr_Name[1]);
                }
                catch
                {
                    mn_val = Convert.ToDateTime(strArr_Name[1] + " 01, 1900").Month;
                }
                string mnthvalue = mn_val.ToString();
                if (mnthvalue.Length < 2)
                    mnthvalue = 0 + mnthvalue;
                string rtn = strArr_Name[0] + "/" + (mnthvalue) + "/" + strArr_Name[2];
                dttt = DateTime.ParseExact(rtn, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                rtn = dttt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                return rtn;
            }
            catch
            {
                string typ = "";
                if (datetype == "dob")
                    typ = "Date Of Birth";
                else if (datetype == "doj")
                    typ = "Date Of joining";
                htFailedInsertion["Record"] = htFailedInsertion["Record"] + typ + " error | ";
                htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Wrong Date format | ";
                ErrorOccured = true;
                //ERPMessageBox.ERPMessage.Show("We have encountered a problem while inserting " + typ + " of " + eid + " employee, no such date exists. Please change the " + typ + " of the employee from Master->Employee Master->Employee Joining after insertion of all records." + Environment.NewLine + "By Default the date will be saved as 01/01/1900.");
                return null;
            }
        }

        //private void disp_grid(string fpath)
        //{
        //    string connString = "";
        //    string strFileType = Path.GetExtension(fpath).ToLower();
        //    string path = fpath;
        //    //Connection String to Excel Workbook
        //    if (strFileType.Trim() == ".xls")
        //    {
        //        connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        //    }
        //    else if (strFileType.Trim() == ".xlsx")
        //    {
        //        //connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        //        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=2\"";
        //    }

        //    string query = "Select * from [Sheet1$]";
        //   //     "SELECT [EmployeeID],[Name]," +
        //   //"[FatherName],[MotherName],[DateOfBirth],[Gender]," + 
        //   //"[Religion],[Cast],[MaritalStatus],[Padd_Road],[Padd_State],[Padd_City]," +
        //   //"[Padd_Country],[Padd_Pin],[DateOfJoining]," + 
        //   //"[Designation],[JobType] FROM [Sheet1$]";
            

        //    OleDbConnection conn = new OleDbConnection(connString);
        //    try
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();

        //         OleDbCommand command = new OleDbCommand(query, conn);
        //         using (OleDbDataReader dr = command.ExecuteReader())
        //         {

        //             while (dr.Read())
        //             {
        //                 var row1Col0 = dr[0];
        //                 var row1Col1 = dr[1];
        //                 var row1Col2 = dr[2];
        //             }
        //         }
        //        OleDbCommand cmd = new OleDbCommand(query, conn);
        //        //cmd.TableMappings.Add("Table", "Net-informations.com");
        //        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //        ds = new DataSet();
        //        da.Fill(ds);

        //        dgView_Emp.DataSource = ds.Tables[0];
        //        //dgView_Emp.Columns["imp"].Visible = false;
        //        //dgView_Emp.DataBindings();
        //        da.Dispose();
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);

        //    }

            
        //    conn.Close();
        //    conn.Dispose();

           
        //}
        //private string GetEmpId(String strDesignation)
        //{
        //    string intEmpId = 0;
        //    DataTable dt = clsDataAccess.RunQDTbl("select SlNo from tbl_Employee_DesignationMaster where DesignationName='" + strDesignation + "'", edpcon.mycon, sqltran);
        //    if (dt.Rows.Count > 0)
        //    {
        //        intDesgId = Convert.ToInt32(dt.Rows[0]["SlNo"]);
        //    }
        //    return intDesgId;
        //}

        private Int32 GetDesgId(String strDesignation)
        {
            Int32 intDesgId = 0;
            if (strDesignation.Trim() == "")
            {
                strDesignation = "SG";
            }

            System.Data.DataTable dt = clsDataAccess.RunQDTbl("select SlNo from tbl_Employee_DesignationMaster where ({ fn UCASE(DesignationName)})='" + strDesignation.ToUpper() + "' or ({ fn UCASE(ShortForm)}='" + strDesignation.ToUpper() + "')");
            if (dt.Rows.Count > 0)
            {
                intDesgId = Convert.ToInt32(dt.Rows[0]["SlNo"]);
            }
            else
            {                                                           //Added by dwipraj dutta 07082017
                Boolean flag = false;
                string[] sfrm = strDesignation.Split(' ');
                string msfrm = "";
                foreach (string sf in sfrm)
                {
                    if(sf!="")
                        msfrm = msfrm + sf[0];                        
                }
                DataTable maxSlnoGet = clsDataAccess.RunQDTbl("select MAX(SlNo) as 'SlNo' from tbl_Employee_DesignationMaster");
                intDesgId = Convert.ToInt32(maxSlnoGet.Rows[0][0])+1;
                flag = clsDataAccess.RunNQwithStatus("SET IDENTITY_INSERT tbl_Employee_DesignationMaster ON" + Environment.NewLine + "Insert into tbl_Employee_DesignationMaster([SlNo],[DesignationName],[ShortForm]) values(" + intDesgId + ",'" + strDesignation + "','" + msfrm + "')" + Environment.NewLine + "SET IDENTITY_INSERT tbl_Employee_DesignationMaster OFF");
                if (!flag)
                {
                    htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Designation Error | ";
                    htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                    ErrorOccured = true;
                }
            }
            return intDesgId;
        }

        private Int32 GetjobType(String strJobtype)
        {
            Int32 intJTId = 0;
            DataTable dt = clsDataAccess.RunQDTbl("SELECT [SlNo] FROM tbl_Employee_JobType where ({ fn UCASE(JobType)}='" + strJobtype.ToUpper() + "') or ({ fn UCASE(ShortForm)}='" + strJobtype.ToUpper() + "')");
            if (dt.Rows.Count > 0)
            {
                intJTId = Convert.ToInt32(dt.Rows[0]["SlNo"]);
            }
            else
            {                                                           //Added by dwipraj dutta 07082017
                Boolean flag = false;
                string[] sfrm = strJobtype.Split(' ');
                string msfrm = "";
                foreach (string sf in sfrm)
                {
                    if (sf != "")
                        msfrm = msfrm + sf[0];
                }
                flag = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_JobType(JobType,ShortForm) values('" + strJobtype + "','" + msfrm + "')");
                if (!flag)
                {
                    htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Job Type Error | ";
                    htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                    ErrorOccured = true;
                }
                DataTable dtNewSlno = clsDataAccess.RunQDTbl("SELECT [SlNo] FROM tbl_Employee_JobType where ({ fn UCASE(JobType)}='" + strJobtype.ToUpper() + "') or ({ fn UCASE(ShortForm)}='" + strJobtype.ToUpper() + "')");
                if (dtNewSlno.Rows.Count > 0)
                {
                    intJTId = Convert.ToInt32(dtNewSlno.Rows[0]["SlNo"]);
                }
            }
            return intJTId;
        }


        private Int32 GetStatID(string strSecname)
        {
            Int32 salid = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select STATE_CODE from StateMaster where ({ fn UCASE(STATE_Name) })='" + strSecname.ToUpper() + "'");
            if (dt.Rows.Count > 0)
            {
                salid = Convert.ToInt32(dt.Rows[0]["STATE_CODE"]);
            }
            return salid;
        }

        private Int32 GetCountryID(string strSecname)
        {
            Int32 salid = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select Country_CODE from Country where ({ fn UCASE(Country_Name) })='" + strSecname.ToUpper() + "'");
            if (dt.Rows.Count > 0)
            {
                salid = Convert.ToInt32(dt.Rows[0]["Country_CODE"]);
            }
            return salid;
        }
        public Boolean chkPrevRecord()
        {
            Boolean boolStatus = false;
            int cnt = 0;
            //string[] dateonly = EDOB.Split(' ');
            //string vdt = dateonly[0];
            
            string opt="";
            //PF.Replace('xxxx','****');
            if (PF.Trim() != "****" && PF.Trim() != "xxxx")
            {
                opt = "where (PF='" + PF + "')";

            }
            if (ESI.Trim() != "****" && ESI.Trim() != "xxxx")
            {
                if (opt == "")
                    opt = "where (ESIno='" + ESI + "')";
                else
                {
                    opt = opt + " or (ESIno='" + ESI + "')";
                }
            }
            if (UAN.Trim() != "****" && UAN.Trim() != "xxxx")
            {
                if (opt == "")
                    opt = "where (PassportNo='" + UAN.Trim() + "')";
                else
                {
                    opt = opt + " or (PassportNo='" + UAN.Trim() + "')";
                }
            }
            if (PanNo.Trim() != "")
            {
                if (opt == "")
                    opt = "where (PANno='" + PanNo + "')";
                else
                {
                    opt = opt + " or (PANno='" + PanNo + "')";
                }
            }

            if (AadharNo.Trim() != "")
            {
                if (opt == "")
                    opt = "where (aadhar='" + AadharNo + "')";
                else
                {
                    opt = opt + " or (aadhar='" + AadharNo + "')";
                }
            }
            //if (EDOJ.Trim() != "")
            //{
            //    if (opt == "")
            //        opt = "where (CONVERT(VARCHAR(11),DateOfBirth,103)='" + EDOJ + "')";
            //    else
            //    {
            //        opt = opt + " and (CONVERT(VARCHAR(11),DateOfBirth,103)='" + EDOJ + "')"
            //    }
            //}

            if (opt != "")
            {
                cnt = Convert.ToInt32(clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Mast " + opt));
            }
            if (cnt == 0)
            {
                cnt = Convert.ToInt32(clsDataAccess.ReturnValue("Select count (*) from tbl_Employee_Mast where (lower(ltrim(rtrim(FirstName)))='" + EmpFName.Trim().ToLower() +
            "') and (lower(ltrim(rtrim(MiddleName)))='" + EmpMName.Trim().ToLower() + "') and (lower(ltrim(rtrim(LastName)))='" + EmpLName.Trim().ToLower() +
            "') and (lower(ltrim(rtrim(FathFN)))='" + FathFN.Trim().ToLower() + "') and (lower(ltrim(rtrim(FathMN)))='" + FathMN.Trim().ToLower() +
            "') and (lower(ltrim(rtrim(FathLN)))='" + FathLN.Trim().ToLower() + "') and (CONVERT(VARCHAR(11),DateOfBirth,103)='" + chk_dt(EDOB) + "')"));
            }
            else if (cnt > 1)
            {
             clsDataAccess.RunQry("delete from tbl_Employee_QualificationDetails where (ID in (select id from tbl_Employee_Mast " + opt + "))" + Environment.NewLine +
"delete from tbl_Employee_FamilyDetails where (ID in (select id from tbl_Employee_Mast " + opt + "))" + Environment.NewLine +

"delete from tbl_Employee_Other_Reff where (ID in (select id from tbl_Employee_Mast " + opt + "))" + Environment.NewLine +
"delete from tbl_Employee_Mast where (ID in (select id from tbl_Employee_Mast " + opt + "))");
             if (EmpId.Trim() == "")
             {
                 EmpId = get_EmpNo();
             }
             cnt = 0;

            }
          if (cnt > 0)
          {
              boolStatus = true;
          }
          return boolStatus;
        }
        private Boolean ChekExRecordByEmpId_Update()
        {
            Boolean boolStatus = false;

            DataTable dt = clsDataAccess.RunQDTbl("select emp.*,(select DesignationName from tbl_Employee_DesignationMaster desg where desg.SlNo=emp.DesgId) DesignationName,(select JobType from tbl_Employee_JobType job where SlNo=emp.JobType ) Jobtype  from tbl_Employee_Mast emp  where ({ fn UCASE(emp.ID) })='" + EmpId.ToUpper() + "'");
            //"select emp.*,desg.DesignationName,job.JobType from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg, tbl_Employee_JobType job where emp.DesgId=desg.SlNo and emp.JobType=job.SlNo and ({ fn UCASE(emp.ID) })='" + EmpId.ToUpper() + "'");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }

            return boolStatus;
        }
        
        Boolean boolStatus, bool_Qualification, bool_Family, bool_Others;

        public void Loc_permission()
        {
            clsDataAccess.RunNQwithStatus("DELETE FROM AccessLocation");
            DataTable dt_usr = clsDataAccess.RunQDTbl("select user_code from pasword where user_lev='User'");
            DataTable dt_loc = clsDataAccess.RunQDTbl("SELECT Location_ID FROM tbl_Emp_Location");


            if (dt_usr.Rows.Count > 0)
            {
                for (int ind = 0; ind < dt_usr.Rows.Count; ind++)
                {
                    clsDataAccess.RunNQwithStatus("INSERT INTO AccessLocation(USER_CODE, FICode, GCODE, LOC_CODE)VALUES ('" + dt_usr.Rows[ind]["user_code"].ToString() + "',1,1,0)");

                    if (dt_loc.Rows.Count > 0)
                    {
                        for (int ind1 = 0; ind1 < dt_loc.Rows.Count; ind1++)
                        {
                            clsDataAccess.RunNQwithStatus("INSERT INTO AccessLocation(USER_CODE, FICode, GCODE, LOC_CODE)VALUES ('" + dt_usr.Rows[ind]["user_code"].ToString() + "','1','1','" + dt_loc.Rows[ind1]["Location_ID"].ToString() + "')");
                        }
                    }
                }

            }
        }
        
        private void SubmitPersonalDetails()
        {
            //String strQuery = String.Empty;
          
            string lan_Ben = "", lan_hindi = "", lan_Eng = "", lan_Other = "";
            

            String strName = "";
            string strRelation = "";
            string strAge = "0";
            String strSlNo = "";
           
            DataTable dt;
                lan_Ben = "0,0,0";
                lan_hindi = "0,0,0";
                lan_Eng = "0,0,0";
                lan_Other = "0,0,0";
            //---------------------------------------------------Changed by dwipraj dutta 070820170450PM----------------------------------------------------
                Boolean clientEntry = false;
                Boolean locationEntry = false;
                if (cmbLocation.Text == "")
                {
                    if (ClientName != "")
                    {
                        clientEntry = true;
                        ClientName = ClientName.Trim().Replace("'", "''");
                        DataTable dtEmployeeCM = clsDataAccess.RunQDTbl("select Client_id,Client_Name from tbl_Employee_CliantMaster where lower(ltrim(rtrim(Client_Name))) = '" + ClientName.Trim().ToLower() + "'");
                        if (dtEmployeeCM.Rows.Count > 0)
                        {
                            Client_ID = Convert.ToInt32(dtEmployeeCM.Rows[0]["Client_id"]);
                        }
                        else
                        {
                            DataTable getMaxCID = clsDataAccess.RunQDTbl("select MAX(Client_id) as 'MCLID' from [tbl_Employee_CliantMaster]");
                            if (getMaxCID.Rows[0][0].ToString().Trim() == "")
                                Client_ID = 1;
                            else
                                Client_ID = Convert.ToInt32(getMaxCID.Rows[0][0])+1;

                            clientEntry = clsDataAccess.RunNQwithStatus("Insert into tbl_Employee_CliantMaster (Client_id,Client_Name,coid) values (" + Client_ID + ",'" + ClientName.ToUpper().Trim() + "','" + Co_ID + "')");
                            if (!clientEntry)
                            {
                                htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Client Error | ";
                                htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                                ErrorOccured = true;
                            }

                        }
                    }
                    else
                    {
                        clientEntry = false;
                        //ERPMessageBox.ERPMessage.Show("No Client Name is Specified for "+EmpFName+". This record cannot be inserted.");
                    }
                    if (LocationName != ""&&clientEntry)
                    {
                        LocationName = LocationName.Trim().Replace("'", "''");
                        DataTable dtEmployeeCM = clsDataAccess.RunQDTbl("select Location_ID,Location_Name,Cliant_ID from tbl_Emp_Location where (lower(ltrim(rtrim(Location_Name))) = '" + LocationName.ToLower() + "') and (cliant_ID='" + Client_ID + "')");
                        if (dtEmployeeCM.Rows.Count > 0)
                        {
                            Location_ID = Convert.ToInt32(dtEmployeeCM.Rows[0]["Location_ID"]);
                        }
                        else
                        {
                            int Max_ID = 0, Max_rel_id = 0;
                            string strCoid = Convert.ToString(Co_ID);
                            DataTable getMaxLID = clsDataAccess.RunQDTbl("select MAX(Location_ID) as 'MLOCID' from [tbl_Emp_Location]");
                            if (getMaxLID.Rows[0][0].ToString().Trim() == "")
                                Location_ID = 1;
                            else
                                Location_ID = Convert.ToInt32(getMaxLID.Rows[0][0])+1;


                            locationEntry = clsDataAccess.RunNQwithStatus("Insert into tbl_Emp_Location (Location_ID,Location_Name,Cliant_ID) values (" + Location_ID + ",'" + LocationName.ToUpper().Trim() + "'," + Client_ID + ")");
                            if (!locationEntry)
                            {
                                htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Location Error | ";
                                htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                                ErrorOccured = true;
                            }

                            dt = clsDataAccess.RunQDTbl("SELECT Max(ID) FROM Companywiseid_Relation");
                            if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                            {
                                Max_rel_id = Convert.ToInt32(dt.Rows[0][0]) + 1;
                            }
                            else
                            {
                                Max_rel_id = 1;
                            }
                            if (locationEntry)
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_LeaveDetails(LeaveHead,ShortName,TotalLeaves,DayCount,Session,PayType,LeaveFwd,Location_ID,company_Id) values('Absent','AB',0,0,'2016-2017',' ','Nothing','" + Location_ID + "','" + Client_ID + "')");
                                if (!boolStatus)
                                {
                                    htFailedInsertion["Record"] = htFailedInsertion["Record"] + "LeaveDetails Error | ";
                                    htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                                    ErrorOccured = true;
                                }
                            }


                            if (strCoid != "" && locationEntry)
                            {


                                boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO Companywiseid_Relation(ID,Company_ID,Location_ID,PF_Code,Esi_Code,Ptax_Code,Pan_Code,StReg_Code,M_inst,MOD,[typeRem],[prefix],[sufix],[hidedocno],[lstDocNo],[padding],[isSC],[isST],[isSTC],[freeze],blAdd,blPh,blFax,blEmail,isAdd,blState,blAcNo,GSTTYPE,DueDateDays,[hrs_per_wd],[hrs_per_ot],[apply_hrs_wd],[apply_hrs_ot],[Lv_Rate],[lv_adj],[scPer],[hrs_per_ed],[apply_hrs_ed],mode_cwd,pf_limit,esi_limit,pf_base,esi_base,narration,note,remit_pfesi,OCQ) VALUES ('" +
                                Max_rel_id + "','" + strCoid + "','" + Location_ID + "','','','','','','False','MonthOfDays','','','Session','0','0','0','0','0','0','0','','','','','0','0','','LOCAL','-1','8','4','0','0','0','0','0','0','0','0','" + pf_limit + "','" + esi_limit + "','0','1','','','0','0')");
                                
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_LeaveDetails(LeaveHead,ShortName,TotalLeaves,DayCount,Session,PayType,LeaveFwd,Location_ID,company_Id) values('Absent','AB',0,0,'2016-2017',' ','Nothing','" + Location_ID + "','" + strCoid + "')");
                                try
                                {
                                    bool boolSS = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_SalaryStructure(SalaryCategory) values('" + LocationName.Trim() + "_Salary_" + Location_ID + "')");

                                 if (boolSS == true)
                                 {
                                     int LSlink_ID = 0;
                                     int sal_st_id = Convert.ToInt32(clsDataAccess.GetresultS("select isNull(SlNo,0) from  tbl_Employee_SalaryStructure where (SalaryCategory='" + LocationName.Trim() + "_Salary_" + Location_ID + "')"));
                                     if (sal_st_id > 0)
                                     {
                                         LSlink_ID = 0;

                                         DataTable dt1 = clsDataAccess.RunQDTbl("SELECT Max(Link_ID) FROM tbl_Employee_Link_SalaryStructure");
                                         if (Convert.ToString(dt1.Rows[0][0]).Length > 0)
                                         {
                                             LSlink_ID = Convert.ToInt32(dt1.Rows[0][0]) + 1;
                                         }
                                         else
                                         {
                                             LSlink_ID = 1;
                                         }

                                         boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Link_SalaryStructure(Link_ID,Location_ID,SalaryStructure_ID) values('" + LSlink_ID + "','" + Location_ID + "','" + sal_st_id + "')");

                                     }
                                 }
                                }
                                catch { }
                                
                                if (!boolStatus)
                                {
                                    htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Companywiseid_Relation Error | ";
                                    htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                                    ErrorOccured = true;
                                }



                            }
                        }
                    }
                    else
                    { 
                    
                    }
                }
                //-----------------------------------------------------------End of 070820170450PM--------------------------------------------------------

                if (ChekExRecordByEmpId_Update() == false)
                {
                    if (chkPrevRecord() == false)
                    {
                        string qry = "insert into tbl_Employee_Mast (ID,Title,FirstName," +
                  "MiddleName,LastName,FathTitle,FathFN,FathMN,FathLN,MothTitle,MothFN,MothMN,MothLN,HusTitle,HusFN," +
                  "HusMN,HusLN,DateOfBirth,Cast,MaritalStatus,Gender,DesgId,JobType,PresentAddress,PermanentAddress,STD," +
                  "Phone,Mobile,PassportNo,PF,PenssionNo,EDLI,ESIno,BankAcountNo,DateOfJoining,DateOfRetirement," +
                  "Session,GMIno,EmailId,PenssionDate,Presentbuilding,Presentstreet,Presentareia,Presentcity,Presentpin," +
                  "Presentstate,Presentcountry,Permanentbuilding,Permanentstreet,Permanentareia,Permanentcity,Permanentpin," +
                  "Permanentstate,Permanentcountry,Empimage,Empdocimage,Religion,Weight,Height,Language_Bengali," +
                  "Language_Hindi,Language_English,Language_Other,Language_Name,Empdocimage2,Empdocimage3," +
                  "Document_Titel,Document_Titel2,Document_Titel3,Location_id,Company_id,PF_Deduction,EmpBasic,active," +
                  "EMPSAL,Bank_Name,Branch_Name,Bank_AC_Type,PANno, aadhar,pay_mod,[pass],del,memp) values('" +
                  EmpId + "','" + EmpTitle + "','" + EmpFName + "','" + EmpMName + "','" + EmpLName + "','" +
                  FathTitle + "','" + FathFN + "','" + FathMN + "','" + FathLN + "','" + MothTitle +
                  "','" + MothFN + "','" + MothMN + "','" + MothLN + "','" + HusTitle + "','" + HusFN + "','" +
                  HusMN + "','" + HusLN + "','" + func_dt(EDOB, EmpId, "dob") + "','" + ECast + "','" + EMStatus +
                  "','" + EGender + "'," + desg_id + "," + Jb_ID + ",'','',0,0,'" + EMob + "','" + UAN + "','" + PF + "','-','-','" + ESI + "','" + AcNo + "','" +
                  func_dt(EDOJ, EmpId, "doj") + "','','" + cmbYear.Text.Trim() + "','" + IFSC + "','','','','" +
                  prestreet + "','','','" + prepin + "','" + GetStatID(prestate) + "','" + GetCountryID(precountry) +
                  "','','" + prestreet + "','','','" + prepin + "','" + GetStatID(prestate) + "','" +
                      GetCountryID(precountry) + "',NULL,'','" + religion + "','0','0','" + lan_Ben + "','" + lan_hindi +
                      "','" + lan_Eng + "','" + lan_Other + "','','','','','','','" + Location_ID + "','" + Co_ID +
                      "','0'," + strEmpBasic + ",'1'," + strEmpSal + ",'" + Bank + "','" + Branch + "','" + AcType + "','" + PanNo + "','" + AadharNo + "','" + pay_mod + "','" + EmpId + "','1','0')";
                        boolStatus = clsDataAccess.RunNQwithStatus(qry);

                        if (boolStatus == true)
                        {
                            if (Qualification == "") { Qualification = "0"; }
                            else
                            {
                                try
                                {
                                    Qualification = clsDataAccess.GetresultS("SELECT Quali_Code FROM Qualification_Master WHERE Quali_Name='" + Qualification + "'");
                                }
                                catch
                                {
                                    Qualification = "0";
                                }
                            }
                            if (Board_University == "") { Board_University = "-"; }
                            if (YearOfPassing == "") { YearOfPassing = "0"; }
                            if (Percentage == "") { Percentage = "0"; }
                            bool_Qualification = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_QualificationDetails " +
               "(ID,Qualification,University,YearOfPassing,Percentage) values('" +
               EmpId + "','" + Qualification + "','" + Board_University + "','" + YearOfPassing + "','" + Percentage + "')");

                            if (!bool_Qualification)
                            {
                                htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Qualification Details Error | ";
                                htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                                ErrorOccured = true;
                            }


                            if (FathFN == "")
                            {
                                strName = "-";
                                strRelation = "-";
                                strAge = "0";
                                strDependent = "0";
                                strSlNo = "";
                            }
                            else
                            {
                                strName = FathFN + " " + FathMN + " " + FathLN;
                                strRelation = "Father";
                                strAge = FAge;
                                if (FAge.Trim() == "")
                                {
                                    strAge = "0";
                                }
                                strDependent = "1";
                                strSlNo = "";
                                dt = clsDataAccess.RunQDTbl("Select Relation_Code from Relation_Master Where Relation_Name='" + strRelation + "'");
                                if (dt.Rows.Count > 0)
                                {
                                    strRelation = Convert.ToString(dt.Rows[0]["Relation_Code"]);
                                }
                            }
                            bool_Family = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_FamilyDetails(ID,Name,Relation,Age,Dependent) values('" + EmpId + "','" + strName + "','" + strRelation + "'," + strAge + "," + strDependent + ")");
                            if (!bool_Family)
                            {
                                htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Family Details Error | ";
                                htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                                ErrorOccured = true;
                            }
                            if (MothFN == "")
                            {
                                strName = "-";
                                strRelation = "-";
                                strAge = "0";
                                strDependent = "0";
                                strSlNo = "";

                            }
                            else
                            {
                                strName = MothFN + " " + MothMN + " " + MothLN;
                                strRelation = "Mother";
                                strAge = MAge;
                                if (MAge.Trim() == "")
                                {
                                    strAge = "0";
                                }
                                strDependent = "1";
                                strSlNo = "";
                                dt = clsDataAccess.RunQDTbl("Select Relation_Code from Relation_Master Where Relation_Name='" + strRelation + "'");
                                if (dt.Rows.Count > 0)
                                {
                                    strRelation = Convert.ToString(dt.Rows[0]["Relation_Code"]);
                                }

                                bool_Family = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_FamilyDetails(ID,Name,Relation,Age,Dependent) values('" + EmpId + "','" + strName + "','" + strRelation + "'," + strAge + "," + strDependent + ")");
                                if (!bool_Family)
                                {
                                    htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Family Details Error | ";
                                    htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                                    ErrorOccured = true;
                                }
                            }


                            bool_Others = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Other_Reff" +
    "(ID,Emarg_Name,Emarg_Address,Emarg_Tele,Emarg_Mobile,Emp_Achiev,Emp_Club,Emp_Association,Emp_Org,Emp_Notic," +
    "Emp_Join_refer,Emp_Preferlocation,Emp_Criminal_Rec,Emp_illness,Emp_Interview_Details,Emp_OtherInformation," +
    "Emp_Expected_Salary,Ref_Name,Ref_Address,Ref_Occupation,Ref_Phone,Ref_Email,Ref_Name1,Ref_Address1," +
    "Ref_Occupation1,Ref_Phone1,Ref_Email1,Emp_Service,Emp_Period_Service,Emp_Rank,Emp_ICard_No,Emp_Arms," +
    "Emp_Pension_No,Emp_GunLicence,Emp_Operation_Area,Emp_issue,Emp_GunType,Emp_GunValid,Emp_DrivingLicence) values('" +
    EmpId + "','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','')");

                            if (!bool_Others)
                            {
                                htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Other Error | ";
                                htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                                ErrorOccured = true;
                            }

                        }
                        else
                        {
                            htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Employee Details Error | ";
                            htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                            ErrorOccured = true;
                        }
                    }
                    else
                    {
                        htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Skipped | ";

                        if (chkPrevRecord() == true)
                        {
                            htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Record Present | Check PF No / ESI No / UAN No / PAN No / AADHAR No ";
                        }
                        else
                        {
                            htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Record Present already | ";
                        }
                    }
                }
                else
                {
                    if (chkPrevRecord() == true)
                    {
                        string qry = "delete from tbl_Employee_QualificationDetails where (ID ='" + EmpId + "')" + Environment.NewLine+
                        "delete from tbl_Employee_FamilyDetails where (ID ='" + EmpId + "')" + Environment.NewLine +
                        "delete from tbl_Employee_Other_Reff where (ID ='" + EmpId + "')";
                        boolStatus = clsDataAccess.RunNQwithStatus(qry);

                        qry = "UPDATE tbl_Employee_Mast SET Title='"+EmpTitle+"',FirstName='" + EmpFName + "',MiddleName='" + EmpMName + "',LastName='" + EmpLName + 
                     "',FathTitle='"+FathTitle + "',FathFN='" + FathFN + "',FathMN='" + FathMN + "',FathLN='" + FathLN + 
                     "',MothTitle='" + MothTitle + "',MothFN='" + MothFN + "',MothMN='" + MothMN + "',MothLN ='" + MothLN + 
                     "',HusTitle='" + HusTitle + "',HusFN='" + HusFN + "',HusMN='" + HusMN + "',HusLN='" + HusLN + 
                     "',DateOfBirth='" + func_dt(EDOB, EmpId, "dob") + "', Cast='" + ECast + "',MaritalStatus='" + EMStatus +"',Gender='" + EGender + "', DesgId=" + desg_id + 
                     ",JobType=" + Jb_ID + ",PresentAddress ='', PermanentAddress ='', STD=0, Phone=0, Mobile='" + EMob + "',PANno='" + PanNo + "',PassportNo='" + UAN + "',PF='" + PF + "', PenssionNo='-', EDLI ='-', ESIno='" + ESI + "',BankAcountNo='" + AcNo + 
                     "',DateOfJoining ='"+func_dt(EDOJ, EmpId, "doj") + "',Session ='" + cmbYear.Text.Trim() + "',GMIno ='" + IFSC + 
                     "',Presentbuilding='',Presentstreet ='"+prestreet+"',Presentareia='',Presentcity='"+precity+"',Presentpin='"+prepin+"',Presentstate='" + GetStatID(prestate) + "', Presentcountry='"+ GetCountryID(precountry)+
                     "',Permanentbuilding='',Permanentstreet='"+prestreet+"',Permanentareia='',Permanentcity ='"+precity+"',Permanentpin='"+prepin+"',Permanentstate='" + GetStatID(prestate) + "',Permanentcountry='"+ GetCountryID(precountry)+
                     "',Religion ='"+religion+"',Language_Bengali='" + lan_Ben + "',Language_Hindi='" + lan_hindi +"',Language_English='" + lan_Eng + "',Language_Other='" + lan_Other + "',Language_Name='', Document_Titel='', Document_Titel2='',Document_Titel3='',"+
                     "Location_id ='" + Location_ID + "',Company_id ='" + Co_ID + "',PF_Deduction=0,ESI_Deduction =0,EMPBASIC=0,active=1,EMPSAL=0,Bank_Name ='" + Bank + "',Branch_Name='" + Branch + "',Bank_AC_Type ='" + AcType + 
                     "',pf_name='"+strEmpName+"',esi_name='"+strEmpName+"',bankAc_name='"+strEmpName+"',[identity]='',econtact='',other='',remarks='',oRemarks='',status=1,pay_mod="+pay_mod+",ifFound ='',chest='',complexion ='',haircolor='',eyecolor='',aadhar='" + AadharNo +
                     "',icard=0,dept='',blgrp ='', psid=0, mode_cwd=0,Language_Other2='',Language_Name2='',[pass] ='" + EmpId + "',del='1',memp='0' where ID ='" + EmpId + "'";
                            
                    boolStatus = clsDataAccess.RunNQwithStatus(qry);

                        if (boolStatus == true)
                        {
                            if (Qualification == "") { Qualification = "0"; }
                            else
                            {
                                try
                                {
                                    Qualification = clsDataAccess.GetresultS("SELECT Quali_Code FROM Qualification_Master WHERE Quali_Name='" + Qualification + "'");
                                }
                                catch
                                {
                                    Qualification = "0";
                                }
                            }
                            if (Board_University == "") { Board_University = "-"; }
                            if (YearOfPassing == "") { YearOfPassing = "0"; }
                            if (Percentage == "") { Percentage = "0"; }
                            bool_Qualification = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_QualificationDetails " +
               "(ID,Qualification,University,YearOfPassing,Percentage) values('" +
               EmpId + "','" + Qualification + "','" + Board_University + "','" + YearOfPassing + "','" + Percentage + "')");

                            if (!bool_Qualification)
                            {
                                htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Qualification Details Error | ";
                                htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                                ErrorOccured = true;
                            }


                            if (FathFN == "")
                            {
                                strName = "-";
                                strRelation = "-";
                                strAge = "0";
                                strDependent = "0";
                                strSlNo = "";
                            }
                            else
                            {
                                strName = FathFN + " " + FathMN + " " + FathLN;
                                strRelation = "Father";
                                strAge = FAge;
                                if (FAge.Trim() == "")
                                {
                                    strAge = "0";
                                }
                                strDependent = "1";
                                strSlNo = "";
                                dt = clsDataAccess.RunQDTbl("Select Relation_Code from Relation_Master Where Relation_Name='" + strRelation + "'");
                                if (dt.Rows.Count > 0)
                                {
                                    strRelation = Convert.ToString(dt.Rows[0]["Relation_Code"]);
                                }
                            }
                            bool_Family = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_FamilyDetails(ID,Name,Relation,Age,Dependent) values('" + EmpId + "','" + strName + "','" + strRelation + "'," + strAge + "," + strDependent + ")");
                            if (!bool_Family)
                            {
                                htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Family Details Error | ";
                                htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                                ErrorOccured = true;
                            }
                            if (MothFN == "")
                            {
                                strName = "-";
                                strRelation = "-";
                                strAge = "0";
                                strDependent = "0";
                                strSlNo = "";

                            }
                            else
                            {
                                strName = MothFN + " " + MothMN + " " + MothLN;
                                strRelation = "Mother";
                                strAge = MAge;
                                if (MAge.Trim() == "")
                                {
                                    strAge = "0";
                                }
                                strDependent = "1";
                                strSlNo = "";
                                dt = clsDataAccess.RunQDTbl("Select Relation_Code from Relation_Master Where Relation_Name='" + strRelation + "'");
                                if (dt.Rows.Count > 0)
                                {
                                    strRelation = Convert.ToString(dt.Rows[0]["Relation_Code"]);
                                }

                                bool_Family = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_FamilyDetails(ID,Name,Relation,Age,Dependent) values('" + EmpId + "','" + strName + "','" + strRelation + "'," + strAge + "," + strDependent + ")");
                                if (!bool_Family)
                                {
                                    htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Family Details Error | ";
                                    htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                                    ErrorOccured = true;
                                }
                            }


                            bool_Others = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Other_Reff" +
    "(ID,Emarg_Name,Emarg_Address,Emarg_Tele,Emarg_Mobile,Emp_Achiev,Emp_Club,Emp_Association,Emp_Org,Emp_Notic," +
    "Emp_Join_refer,Emp_Preferlocation,Emp_Criminal_Rec,Emp_illness,Emp_Interview_Details,Emp_OtherInformation," +
    "Emp_Expected_Salary,Ref_Name,Ref_Address,Ref_Occupation,Ref_Phone,Ref_Email,Ref_Name1,Ref_Address1," +
    "Ref_Occupation1,Ref_Phone1,Ref_Email1,Emp_Service,Emp_Period_Service,Emp_Rank,Emp_ICard_No,Emp_Arms," +
    "Emp_Pension_No,Emp_GunLicence,Emp_Operation_Area,Emp_issue,Emp_GunType,Emp_GunValid,Emp_DrivingLicence) values('" +
    EmpId + "','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','')");

                            if (!bool_Others)
                            {
                                htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Other Error | ";
                                htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                                ErrorOccured = true;
                            }

                        }
                        else
                        {
                            htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Employee Details Error | ";
                            htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Unknown Error | ";
                            ErrorOccured = true;
                        }




                        htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Updated | ";

                        if (chkPrevRecord() == false)
                        {
                            htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Record Present | Check PF No / ESI No / UAN No / PAN No / AADHAR No ";
                        }
                        else
                        {
                            htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Record Present already | ";
                        }
                    }
                    else
                    {
                        htFailedInsertion["Record"] = htFailedInsertion["Record"] + "Skipped | ";

                        if (chkPrevRecord() == true)
                        {
                            htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Record Present | Check PF No / ESI No / UAN No / PAN No / AADHAR No ";
                        }
                        else
                        {
                            htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Record Present already | ";
                        }
                    }
                }
            /////////////////////////////////

        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
        /*    
           // openFileDialog1.ShowDialog();
            

          //  Stream myStream = null;
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
           //1 openFileDialog1.Filter = "All files (*.*)|*.*|excel files (*.xlsx)|*.xls";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var_file_path = openFileDialog1.FileName;
                    if (openFileDialog1.OpenFile() != null)
                    {
                        txt_filepath.Text = System.IO.Path.GetFileName(var_file_path);
                       
                        disp_grid(var_file_path);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    
                }
            }
            */

            openFileDialog1.ShowDialog();

        }

        /*
        public string get_EmpNo()
        {
            Int32 odno = 0;

            //DataTable dt2 = clsDataAccess.RunQDTbl("Select count(*)+1 from tbl_Employee_Mast");// where OrderDate='"+ dtporderdate.Text +"'");
            DataTable dt2 = clsDataAccess.RunQDTbl("SELECT MAX(ID) FROM tbl_Employee_Mast WHERE (ID like 'E[0-9][0-9][0-9][0-9]%')");
            if (dt2.Rows.Count > 0 && !String.IsNullOrEmpty(dt2.Rows[0][0].ToString()))
            {
                try
                {
                    odno = Convert.ToInt32(dt2.Rows[0][0].ToString().Substring(1)) + 1;
                }
                catch
                { 
                
                }
            }
            else
            {
                odno = 1;
            }
            return "E" + odno.ToString("0000");
        }

        */

        public string get_EmpNo()
        {
            Int32 odno = 0;
            int dcno = 4;
            string dcpref = "E", dcsufix = "";


            DataTable dt2 = new DataTable();
            if (Information.IsNumeric(CmbCompany.ReturnValue) == false)
            {
                string[] dc = clsDataAccess.Emp_No_struct().Split('|');

                dcpref = dc[0].Trim();
                dcno = Convert.ToInt32(dc[1]);
            }
            else
            {
                dt2 = clsDataAccess.RunQDTbl("select prefix,padding from Branch where (BRNCH_CODE=1) and (gcode='" + Co_ID + "')");
                if (dt2.Rows.Count > 0)
                {
                    dcpref = dt2.Rows[0]["Prefix"].ToString().Trim();
                    dcno = Convert.ToInt32(dt2.Rows[0]["padding"].ToString().Trim());
                }

            }
            for (int idx = 0; idx < dcno; idx++)
            {
                if (dcsufix == "")
                {
                    dcsufix = "0";
                }
                else
                {
                    dcsufix = dcsufix + "0";
                }

            }


            

            if (dcpref.Trim() != "")
            {
                dt2 = clsDataAccess.RunQDTbl("select [maxget].ID from (select ID from tbl_Employee_Mast where ID like '" + dcpref + "%') as maxget" +
                                                    " order by CAST(SUBSTRING(maxget.ID," + (dcpref.Length + 1) + ",LEN(maxget.ID)-1) as int) desc");
            }
            else
            {
                dt2 = clsDataAccess.RunQDTbl("select [maxget].ID from (select ID from tbl_Employee_Mast) as maxget order by CAST(maxget.ID as int) desc");
            }

            if (dt2.Rows.Count > 0)
            {
                string maxEmployeeId = dt2.Rows[0][0].ToString(); //21092017
                if (dcpref.Trim() != "")
                {
                    maxEmployeeId = maxEmployeeId.Substring(dcpref.Length, maxEmployeeId.Length - dcpref.Length);

                }
                odno = Convert.ToInt32(maxEmployeeId);
                odno = odno + 1;
            }
            else
            {
                odno = 1;
            }
            return dcpref + odno.ToString(dcsufix);
        }

        private void btnProccess_Bank_Click(object sender, EventArgs e)
        {
            string qry = "",condt="";;
            string path = @LogFilePath + "\\Log" + System.DateTime.Now.Day + System.DateTime.Now.Month + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".txt";
            if (!File.Exists(path))
            {
                //File.Create(path);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                using (var tw = new StreamWriter(fs))
                {
                    tw.WriteLine("#Version: " + edpcmn.PBUILD_DATE);
                    tw.WriteLine("#Date: " + System.DateTime.Now);
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                File.Delete(path);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                using (var tw = new StreamWriter(fs))
                {
                    tw.WriteLine("#Version: " + edpcmn.PBUILD_DATE);
                    tw.WriteLine("#Date: " + System.DateTime.Now);
                    tw.Close();
                }
            }
            pbEmployeeInsertion.Visible = true;
            pbEmployeeInsertion.Value = 0;
            ds = ((DataTable)dgView_Emp.DataSource).Copy();

            for (int var_ds_index = 0; var_ds_index < ds.Rows.Count; var_ds_index++)
            {
                htFailedInsertion["Record"] = "";
                htFailedInsertion["Reason"] = "";
                EmpId = ds.Rows[var_ds_index]["EmployeeID"].ToString().Trim();

                try
                {
                    Bank = (ds.Rows[var_ds_index]["Bank"].ToString().Replace("'", "").Trim());
                }
                catch { Bank = ""; }

                try
                {
                Branch = (ds.Rows[var_ds_index]["Branch"].ToString().Replace("'", "").Trim());
                 }
                catch { Branch = ""; }

                try
                {
                AcNo = (ds.Rows[var_ds_index]["AcNo"].ToString().Replace("'", "").Trim());
                 }
                catch { AcNo = ""; }

                try
                {
                IFSC = (ds.Rows[var_ds_index]["IFSC"].ToString().Replace("'", "").Trim());
                }
                catch { IFSC = ""; }

                try
                {
                    condt="";
                    if (EmpId.Trim() != "" && AcNo.Trim() != "")
                    {


                        if (AcNo.Trim() != "")
                        {
                            if (condt.Trim() == "")
                            {
                                condt = "BankAcountNo='" + AcNo.Trim() + "'";
                            }
                        }

                        

                        if (IFSC.Trim()!="")
                        {
                            if (condt.Trim()=="")
                            {
                            condt="GMIno='"+IFSC.Trim()+"'";
                            }
                            else
                            {
                                condt = condt + ",GMIno='" + IFSC.Trim() + "'";
                            }
                        }

                        if (Bank.Trim()!="")
                        {
                            if (condt.Trim()=="")
                            {
                            condt="Bank_Name='"+Bank.Trim()+"'";
                            }
                            else
                            {
                                condt = condt + ",Bank_Name='" + Bank.Trim() + "'";
                            }
                        }
                        if (Branch.Trim()!="")
                        {
                            if (condt.Trim()=="")
                            {
                                condt = "Branch_Name='" + Branch.Trim() + "'";
                            }
                             else
                             {
                                 condt = condt+ ",Branch_Name='" + Branch.Trim() + "'";
                             }
                            
                        }
                        if (AcNo.Trim() != "" && IFSC.Trim()!="")
                        {
                            if (condt.Trim()=="")
                            {
                                condt = "pay_mod='1'";
                            }
                             else
                             {
                                 condt = condt + ",pay_mod='1'";
                             }
                        }


                        qry = "UPDATE tbl_Employee_Mast SET "+condt+" where (ID ='" + EmpId + "')";

                        boolStatus = clsDataAccess.RunNQwithStatus(qry);


                        if (boolStatus == false)
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                            {
                               try
                                    {
                                        file.WriteLine("Failed Record for Employee ID: " + EmpId + " :: " + "Reason: Employee ID not present");
                                    }
                                    catch
                                    {

                                        file.WriteLine("Failed Record for Employee ID: " + EmpId + " :: " + "Record: LocationName / ClientName / Name / Designation :: Reason: Compulsory missing data");
                                    }
                              
                            }
                        }
                        else
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                            {
                                    try
                                    {
                                        file.WriteLine("Record Updated for Employee ID: " + EmpId + " :: " + "Record: " + htFailedInsertion["Record"].ToString().Substring(0, (htFailedInsertion["Record"].ToString().Length - 2)) + " :: Reason: " + htFailedInsertion["Reason"].ToString().Substring(0, (htFailedInsertion["Reason"].ToString().Length - 2)));
                                    }
                                    catch
                                    {
                                    }
                           }
                        }
                    }
                    else
                    {
                       
                    }

                }
                catch { }


            }

            MessageBox.Show("File Uploaded. Please check the log file at " + path + " for upload details.");

        }



        private void btn_Proc_Click(object sender, EventArgs e)
        {   EMob="";
            strEmpName = "";
            string path = @LogFilePath + "\\Log" + System.DateTime.Now.Day + System.DateTime.Now.Month + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".txt";
            if (!File.Exists(path))
            {
                //File.Create(path);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                using (var tw = new StreamWriter(fs)) 
                {
                    tw.WriteLine("#Version: " + edpcmn.PBUILD_DATE);
                    tw.WriteLine("#Date: " + System.DateTime.Now);
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                File.Delete(path);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                using (var tw = new StreamWriter(fs))
                {
                    tw.WriteLine("#Version: " + edpcmn.PBUILD_DATE);
                    tw.WriteLine("#Date: " + System.DateTime.Now);
                    tw.Close();
                }
            }


            if (Co_ID == 0 || CmbCompany.Text.Trim() == "")
            {
                EDPMessageBox.EDPMessage.Show("Select Company First.");
                return;
            }
            pbEmployeeInsertion.Visible = true;
            pbEmployeeInsertion.Value = 0;
            ds = ((DataTable)dgView_Emp.DataSource).Copy();
            string var_strVal="";
            String[] strArr_Name = new String[2];
            double doubleRowCountOfDGV = ds.Rows.Count;



            for (int var_ds_index = 0; var_ds_index < ds.Rows.Count; var_ds_index++)
            {
                htFailedInsertion["Record"] = "";
                htFailedInsertion["Reason"] = "";
                EmpId = ds.Rows[var_ds_index]["EmployeeID"].ToString().Trim();
                ////if (EmpId.Trim() == "MRCNC2252")
                ////{
                ////    EmpId = get_EmpNo();
                ////}
                if (EmpId.Trim() == "")
                {
                    EmpId = get_EmpNo();
                }
                var_strVal = ds.Rows[var_ds_index]["Name"].ToString().Trim().Replace("'","''");
                EmpTitle = "";
                EmpFName = "";
                EmpMName = "";
                EmpLName = "";

                FathTitle = "";
                FathFN = "";
                FathMN = "";
                FathLN = "";

                spouse = "";

                HusTitle = "";
                HusFN = "";
                HusMN = "";
                HusLN = "";


                //if (var_strVal.Trim() == "RAM KUMAR RAY")
                //{

                //}
                strEmpName = var_strVal;
                strArr_Name = var_strVal.Split(' ',' ');
                /*if (strArr_Name.Length==4)
                {
                    if (strArr_Name[1] != "")
                    {
                        EmpTitle = strArr_Name[0];
                        EmpFName = strArr_Name[1];
                    }
                    else
                    {
                        EmpTitle = "-";
                        EmpFName = strArr_Name[0];

                    }
                    EmpMName=strArr_Name[2];
                    EmpLName=strArr_Name[3];
                }
                else if (strArr_Name.Length == 3)
                { 
                    EmpTitle="-";
                    EmpFName=strArr_Name[0];
                    EmpMName=strArr_Name[1];
                    EmpLName=strArr_Name[2];
               }
                else if (strArr_Name.Length == 2)
                {
                    EmpTitle = "-";
                    EmpFName = strArr_Name[0];
                    EmpMName = "";//strArr_Name[2];
                    EmpLName = strArr_Name[1];
                }
                else if (strArr_Name.Length == 1)
                {
                    EmpTitle = "-";
                    EmpFName = strArr_Name[0];
                    //EmpMName = "";//strArr_Name[2];
                    //EmpLName = strArr_Name[1];
                }*/

                if (strArr_Name[0].ToLower() == "late" || strArr_Name[0].ToLower() == "late." || strArr_Name[0].ToLower() == "lt" || strArr_Name[0].ToLower() == "lt." || strArr_Name[0].ToLower() == "mr" || strArr_Name[0].ToLower() == "mr." || strArr_Name[0].ToLower() == "ms" || strArr_Name[0].ToLower() == "ms." || strArr_Name[0].ToLower() == "miss" || strArr_Name[0].ToLower() == "miss." || strArr_Name[0].ToLower() == "mrs" || strArr_Name[0].ToLower() == "mrs." || strArr_Name[0].ToLower() == "dr" || strArr_Name[0].ToLower() == "dr." || strArr_Name[0].ToLower() == "prof" || strArr_Name[0].ToLower() == "prof." || strArr_Name[0].ToLower() == "proff" || strArr_Name[0].ToLower() == "proff.")
                {
                    if (strArr_Name[0][strArr_Name[0].Length - 1] == '.')
                    {
                        EmpTitle = strArr_Name[0].Substring(0, 1).ToUpper();
                        EmpTitle = EmpTitle + strArr_Name[0].Substring(1).ToLower();
                    }
                    else
                    {
                        EmpTitle = strArr_Name[0].Substring(0, 1).ToUpper();
                        EmpTitle = EmpTitle + strArr_Name[0].Substring(1).ToLower() + ".";
                    }
                    if (strArr_Name.Length == 2)
                    {
                        EmpFName = strArr_Name[1];
                    }
                    else if (strArr_Name.Length == 3)
                    {
                        EmpFName = strArr_Name[1];
                        EmpLName = strArr_Name[2];
                    }
                    else if (strArr_Name.Length >= 4)
                    {
                        EmpFName = strArr_Name[1];
                        for (int i = 2; i < strArr_Name.Length - 1; i++)
                        {
                            EmpMName = EmpMName + strArr_Name[i];
                        }
                        EmpLName = strArr_Name[strArr_Name.Length - 1];
                    }
                }
                else
                {
                    if (strArr_Name.Length == 1)
                    {
                        EmpFName = strArr_Name[0];
                    }
                    else if (strArr_Name.Length == 2)
                    {
                        EmpFName = strArr_Name[0];
                        EmpLName = strArr_Name[1];
                    }
                    else if (strArr_Name.Length >= 3)
                    {
                        EmpFName = strArr_Name[0];
                        for (int i = 1; i < strArr_Name.Length - 1; i++)
                        {
                            EmpMName = EmpMName + strArr_Name[i];
                        }
                        EmpLName = strArr_Name[strArr_Name.Length - 1];
                    }
                }

                EDOB = (ds.Rows[var_ds_index]["DateOfBirth"].ToString().Replace("'", "").Trim());
                EGender = (ds.Rows[var_ds_index]["Gender"].ToString().Replace("'", "").Trim());
                EDOJ = (ds.Rows[var_ds_index]["DateOfJoining"].ToString().Replace("'", "").Trim());
                Desg = (ds.Rows[var_ds_index]["Designation"].ToString().Replace("'", "").Trim());
                desg_id = GetDesgId(Desg);
                JbType = ds.Rows[var_ds_index]["JobType"].ToString().Replace("'", "''").Trim();
                try
                {
                    EMob = ds.Rows[var_ds_index]["Mobile"].ToString().Trim().Trim();
                }
                catch
                {
                    EMob="";
                }
                if (EMob == "")
                {
                    EMob = "0";
                }
                if (JbType == "")
                {
                    JbType = "FT";
                }

                Jb_ID = GetjobType(JbType);




                var_strVal = ds.Rows[var_ds_index]["FatherName"].ToString().Replace("'", "''").Trim();


                strArr_Name = var_strVal.Split(' ');
                /*if (strArr_Name.Length == 4)
                {
                    FathTitle = strArr_Name[0];
                    FathFN = strArr_Name[1];
                    FathMN = strArr_Name[2];
                    FathLN = strArr_Name[3];
                }
                else if (strArr_Name.Length == 3)
                {
                    if (strArr_Name[0].ToUpper() == "LATE" || strArr_Name[0].ToUpper() == "LATE." || strArr_Name[0].ToUpper() == "LT" || strArr_Name[0].ToUpper() == "LT." || strArr_Name[0].ToUpper() == "MR" || strArr_Name[0].ToUpper() == "MR." || strArr_Name[0].ToUpper() == "SRI." || strArr_Name[0].ToUpper() == "SRI" || strArr_Name[0].ToUpper() == "DR." || strArr_Name[0].ToUpper() == "DR" || strArr_Name[0].ToUpper() == "PROFF" || strArr_Name[0].ToUpper() == "PROFF.")
                    {
                        char lastChar = strArr_Name[0][strArr_Name[0].Length - 1];
                        string fathTitle = "";
                        
                        for (int i = 0; i < strArr_Name[0].Length; i++)
                        {
                            if (i == 0)
                                fathTitle = fathTitle + strArr_Name[0][i].ToString().ToUpper();
                            else
                                fathTitle = fathTitle + strArr_Name[0][i].ToString().ToLower();
                        }

                        if (lastChar != '.')
                        {
                            fathTitle = fathTitle + ".";
                        }

                        FathTitle = fathTitle;
                        FathFN = strArr_Name[1];
                        FathMN = "";
                        FathLN = strArr_Name[2];
                    }
                    else
                    {
                        FathTitle = "-";
                        FathFN = strArr_Name[0];
                        FathMN = strArr_Name[1];
                        FathLN = strArr_Name[2];
                    }
                }
                else if (strArr_Name.Length == 2)
                {


                    FathTitle = "-";
                    FathFN = strArr_Name[0];
                    FathMN = "";//strArr_Name[2];
                    FathLN = strArr_Name[1];
                }*/

               

            
                FathTitle = "";
                FathFN = "";
                FathMN = "";
                FathLN = "";
                if (strArr_Name[0].ToLower() == "late" || strArr_Name[0].ToLower() == "late." || strArr_Name[0].ToLower() == "lt" || strArr_Name[0].ToLower() == "mr" || strArr_Name[0].ToLower() == "mr." || strArr_Name[0].ToLower() == "ms" || strArr_Name[0].ToLower() == "ms." || strArr_Name[0].ToLower() == "miss" || strArr_Name[0].ToLower() == "miss." || strArr_Name[0].ToLower() == "mrs" || strArr_Name[0].ToLower() == "mrs." || strArr_Name[0].ToLower() == "dr" || strArr_Name[0].ToLower() == "dr." || strArr_Name[0].ToLower() == "prof" || strArr_Name[0].ToLower() == "prof." || strArr_Name[0].ToLower() == "proff" || strArr_Name[0].ToLower() == "proff." || strArr_Name[0].ToUpper() == "LATE" || strArr_Name[0].ToUpper() == "LATE." || strArr_Name[0].ToUpper() == "LT" || strArr_Name[0].ToUpper() == "LT." || strArr_Name[0].ToUpper() == "MR" || strArr_Name[0].ToUpper() == "MR." || strArr_Name[0].ToUpper() == "SRI." || strArr_Name[0].ToUpper() == "SRI" || strArr_Name[0].ToUpper() == "DR." || strArr_Name[0].ToUpper() == "DR" || strArr_Name[0].ToUpper() == "PROFF" || strArr_Name[0].ToUpper() == "PROFF.")
                {
                    if (strArr_Name[0][strArr_Name[0].Length - 1] == '.')
                    {
                        FathTitle = strArr_Name[0].Substring(0, 1).ToUpper();
                        FathTitle = FathTitle + strArr_Name[0].Substring(1).ToLower();
                    }
                    else
                    {
                        FathTitle = strArr_Name[0].Substring(0, 1).ToUpper();
                        FathTitle = FathTitle + strArr_Name[0].Substring(1).ToLower() + ".";
                    }
                    if (strArr_Name.Length == 2)
                    {
                        FathFN = strArr_Name[1];
                    }
                    else if (strArr_Name.Length == 3)
                    {
                        FathFN = strArr_Name[1];
                        FathLN = strArr_Name[2];
                    }
                    else if (strArr_Name.Length >= 4)
                    {
                        FathFN = strArr_Name[1];
                        for (int i = 2; i < strArr_Name.Length - 1; i++)
                        {
                            FathMN = FathMN + strArr_Name[i];
                        }
                        FathLN = strArr_Name[strArr_Name.Length - 1];
                    }
                }
                else
                {
                    if (strArr_Name.Length == 1)
                    {
                        FathFN = strArr_Name[0];
                    }
                    else if (strArr_Name.Length == 2)
                    {
                        FathFN = strArr_Name[0];
                        FathLN = strArr_Name[1];
                    }
                    else if (strArr_Name.Length >= 3)
                    {
                        FathFN = strArr_Name[0];
                        for (int i = 1; i < strArr_Name.Length - 1; i++)
                        {
                            FathMN = FathMN + strArr_Name[i];
                        }
                        FathLN = strArr_Name[strArr_Name.Length - 1];
                    }
                }


                FAge = (ds.Rows[var_ds_index]["Father_Age"].ToString().Replace("'", "").Trim());

                MothTitle = "";
                MothFN = "";
                MothMN = "";
                MothLN = "";
                var_strVal = ds.Rows[var_ds_index]["MotherName"].ToString().Replace("'", "''").Trim();
                strArr_Name = var_strVal.Split(' ');
                if (strArr_Name.Length == 4)
                {
                    MothTitle = strArr_Name[0];
                    MothFN = strArr_Name[1];
                    MothMN = strArr_Name[2];
                    MothLN = strArr_Name[3];
                }
                else if (strArr_Name.Length == 3)
                {
                    MothTitle = strArr_Name[0];
                    MothFN = strArr_Name[1];
                    MothMN = "";//strArr_Name[2];
                    MothLN = strArr_Name[2];
                }
                else if (strArr_Name.Length == 2)
                {
                    MothTitle = "";
                    MothFN = strArr_Name[0];
                    MothMN = "";//strArr_Name[2];
                    MothLN = strArr_Name[1];
                }
                else if (strArr_Name.Length ==1)
                {
                    MothTitle = "";
                    MothFN = strArr_Name[0];
                    MothMN = "";//strArr_Name[2];
                    MothLN = "";// strArr_Name[1];
                }
                MAge = (ds.Rows[var_ds_index]["Mother_Age"].ToString().Replace("'", "").Trim());

                try
                {
                    spouse = ds.Rows[var_ds_index]["Spouse"].ToString().Replace("'", "''").Trim();
                }
                catch { spouse = ""; }
                HusTitle = "";
                HusFN = "";
                HusMN = "";
                HusLN = "";
                var_strVal = spouse;
                strArr_Name = var_strVal.Split(' ');
                if (strArr_Name[0].ToLower() == "late" || strArr_Name[0].ToLower() == "late." || strArr_Name[0].ToLower() == "lt" || strArr_Name[0].ToLower() == "lt." || strArr_Name[0].ToLower() == "mr" || strArr_Name[0].ToLower() == "mr." || strArr_Name[0].ToLower() == "ms" || strArr_Name[0].ToLower() == "ms." || strArr_Name[0].ToLower() == "miss" || strArr_Name[0].ToLower() == "miss." || strArr_Name[0].ToLower() == "mrs" || strArr_Name[0].ToLower() == "mrs." || strArr_Name[0].ToLower() == "dr" || strArr_Name[0].ToLower() == "dr." || strArr_Name[0].ToLower() == "prof" || strArr_Name[0].ToLower() == "prof." || strArr_Name[0].ToLower() == "proff" || strArr_Name[0].ToLower() == "proff.")
                {
                    if (strArr_Name[0][strArr_Name[0].Length - 1] == '.')
                    {
                        HusTitle = strArr_Name[0].Substring(0, 1).ToUpper();
                        HusTitle = HusTitle + strArr_Name[0].Substring(1).ToLower();
                    }
                    else
                    {
                        HusTitle = strArr_Name[0].Substring(0, 1).ToUpper();
                        HusTitle = HusTitle + strArr_Name[0].Substring(1).ToLower() + ".";
                    }
                    if (strArr_Name.Length == 2)
                    {
                        HusFN = strArr_Name[1];
                    }
                    else if (strArr_Name.Length == 3)
                    {
                        HusFN = strArr_Name[1];
                        HusLN = strArr_Name[2];
                    }
                    else if (strArr_Name.Length >= 4)
                    {
                        HusFN = strArr_Name[1];
                        for (int i = 2; i < strArr_Name.Length - 1; i++)
                        {
                            HusMN = HusMN + strArr_Name[i];
                        }
                        HusLN = strArr_Name[strArr_Name.Length - 1];
                    }
                }
                else
                {
                    if (strArr_Name.Length == 1)
                    {
                        HusFN = strArr_Name[0];
                    }
                    else if (strArr_Name.Length == 2)
                    {
                        HusFN = strArr_Name[0];
                        HusLN = strArr_Name[1];
                    }
                    else if (strArr_Name.Length >= 3)
                    {
                        HusFN = strArr_Name[0];
                        for (int i = 1; i < strArr_Name.Length - 1; i++)
                        {
                            HusMN = HusMN + strArr_Name[i];
                        }
                        HusLN = strArr_Name[strArr_Name.Length - 1];
                    }
                }




                religion = (ds.Rows[var_ds_index]["Religion"].ToString().Replace("'", "").Trim());
                ECast = (ds.Rows[var_ds_index]["Cast"].ToString().Replace("'", "").Trim());
                EMStatus = (ds.Rows[var_ds_index]["MaritalStatus"].ToString().Replace("'", "").Trim());

                prestreet = (ds.Rows[var_ds_index]["Padd_Road"].ToString().Replace("'", "''").Trim());
                prestate = (ds.Rows[var_ds_index]["Padd_State"].ToString().Replace("'", "''").Trim());
                precity = (ds.Rows[var_ds_index]["Padd_City"].ToString().Replace("'", "''").Trim());
                precountry = (ds.Rows[var_ds_index]["Padd_Country"].ToString().Replace("'", "''").Trim());
                prepin = (ds.Rows[var_ds_index]["Padd_Pin"].ToString().Replace("'", "").Trim());


                Qualification = (ds.Rows[var_ds_index]["Qualification"].ToString().Replace("'", "''").Trim());
                Board_University = (ds.Rows[var_ds_index]["Board_University"].ToString().Replace("'", "''").Trim());
                YearOfPassing = (ds.Rows[var_ds_index]["YearOfPassing"].ToString().Replace("'", "").Trim());
                Percentage = (ds.Rows[var_ds_index]["Percentage"].ToString().Replace("'", "").Trim());
                //try
                //{
                //    EMob = ds.Rows[var_ds_index]["Mobile"].ToString();
                //}
                //catch
                //{
                //    EMob = "";
                //}

                PF = (ds.Rows[var_ds_index]["PF_No"].ToString().Replace("'", "").Trim());
                if (PF == ""){ PF = "****"; }

                ESI = (ds.Rows[var_ds_index]["ESI_No"].ToString().Replace("'", "").Trim());
                if (ESI == ""){ESI = "****";}
                try
                {
                    AadharNo = (ds.Rows[var_ds_index]["AadharNo"].ToString().Replace("'", "").Trim());
                }
                catch { AadharNo = ""; }
                try
                {
                    PanNo = (ds.Rows[var_ds_index]["PanNo"].ToString().Replace("'", "").Trim());
                }
                catch { PanNo = ""; }


                //ANURAG
                UAN = (ds.Rows[var_ds_index]["UAN_No"].ToString().Replace("'", "").Trim());
                if (UAN == ""){ UAN = "****"; }

                strEmpBasic = (ds.Rows[var_ds_index]["EmployeeBasic"].ToString().Replace("'", "").Trim().Trim());
                if (!Information.IsNumeric(strEmpBasic))
                    strEmpBasic = "0";

                strEmpSal = (ds.Rows[var_ds_index]["EmployeeSalary"].ToString().Replace("'", "").Trim());
                if (!Information.IsNumeric(strEmpSal))
                    strEmpSal = "0";

                Bank = (ds.Rows[var_ds_index]["Bank"].ToString().Replace("'", "''").Trim());
                Branch = (ds.Rows[var_ds_index]["Branch"].ToString().Replace("'", "''").Trim());
                AcNo = (ds.Rows[var_ds_index]["AcNo"].ToString().Replace("'", "").Trim());
                IFSC = (ds.Rows[var_ds_index]["IFSC"].ToString().Replace("'", "").Trim());

                if (AcNo.Trim() != "" && IFSC.Trim() != "")
                {
                    pay_mod = "1";
                }
                else
                {
                    pay_mod = "2";
                }
               

                AcType = (ds.Rows[var_ds_index]["AcType"].ToString().Replace("'", "").Trim());
                if (AcType == "S" || AcType == "Savings") { AcType = "Savings A/C"; }
                else if (AcType == "C" || AcType == "Current") { AcType = "Current A/C"; }
                else AcType = "";

                LocationName = (ds.Rows[var_ds_index]["LocationName"].ToString().Replace("'", "''").Trim());
                ClientName = (ds.Rows[var_ds_index]["ClientName"].ToString().Replace("'", "''").Trim());

                if (Convert.ToDouble(clsDataAccess.ReturnValue("select EmpLimit from CompanyLimiter")) > 0)
                {
                    if (Convert.ToDouble(clsDataAccess.ReturnValue("select count(*) as 'TotalRecord' from [tbl_Employee_Mast] where active=1")) > Convert.ToDouble(clsDataAccess.ReturnValue("select EmpLimit from CompanyLimiter")))
                    {
                        MessageBox.Show("Employee Limit Reached", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (EmpFName != "" && chk_row(dgView_Emp.Rows[var_ds_index]) == true)
                {
                    SubmitPersonalDetails();
                    if (dgView_Emp.Rows[var_ds_index].Cells["EmployeeID"].Value.ToString().Trim() == "")
                    {
                        dgView_Emp.Rows[var_ds_index].Cells["EmployeeID"].Value = EmpId;
                    }
                }
                else
                {
                    htFailedInsertion["Record"] = EmpFName;
                    htFailedInsertion["Reason"] = "";
                }
                /*using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                using (var tw = new StreamWriter(fs))
                {
                    tw.WriteLine("Record: " + htFailedInsertion["Record"] + "Reason: " + htFailedInsertion["Reason"]);
                    tw.Close();
                }*/
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    if (htFailedInsertion["Reason"].ToString().Trim() != "")
                    {
                        try
                        {
                            file.WriteLine("Failed Record for Employee ID: " + EmpId + " and Employee Name: " + strEmpName + " :: " + "Record: " + htFailedInsertion["Record"].ToString().Substring(0, (htFailedInsertion["Record"].ToString().Length - 2)) + " :: Reason: " + htFailedInsertion["Reason"].ToString().Substring(0, (htFailedInsertion["Reason"].ToString().Length - 2)));
                        }
                        catch {

                            file.WriteLine("Failed Record for Employee ID: " + EmpId + " and Employee Name: " + strEmpName + " :: " + "Record: LocationName / ClientName / Name / Designation :: Reason: Compulsory missing data" );
                        }
                    }
                }
                /*using (var tw = new StreamWriter(path,true))
                {
                    tw.WriteLine("Record: "+htFailedInsertion["Record"]+"Reason: "+htFailedInsertion["Reason"]);
                    tw.Close();
                }*/


                pbEmployeeInsertion.Value = (int)((var_ds_index/doubleRowCountOfDGV)*100);

           }
            if ((boolStatus == true) || (bool_Family == true) || (bool_Qualification == true) || (bool_Others == true))
            {
                if (!ErrorOccured)
                {
                    MessageBox.Show("Record Inserted");
                    Co_ID = 0;
                    CmbCompany.Text = "";
                    pbEmployeeInsertion.Visible = false;
                }
                else
                {
                    MessageBox.Show("Record Inserted With some error. Please check the log file at " + path + " and make the necessary changes.");
                    Co_ID = 0;
                    CmbCompany.Text = "";
                    pbEmployeeInsertion.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Process Completed, Check Log file ","Bravo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Co_ID = 0;
                CmbCompany.Text = "";
                pbEmployeeInsertion.Visible = false;

            }

            btn_Create_File_data_Click(sender, e);
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = new DataTable();

            if (edpcom.CurrentLocation.Trim() != "")
            {

                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            }

            if (dt.Rows.Count > 0)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
            {
                Co_ID = Convert.ToInt32(CmbCompany.ReturnValue);


            }
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID in(select Location_ID from Companywiseid_Relation where Company_ID='" + Co_ID + "')");
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                Location_ID = Convert.ToInt32(cmbLocation.ReturnValue);
        }

        //private void btn_Create_File_data_Click(object sender, EventArgs e)
        //{
        //    //frmExcel_export_Tally eet = new frmExcel_export_Tally();
        //    //eet.ShowDialog();


        //    Excel.Application xlApp ;
        //    Excel.Workbook xlWorkBook ;
        //    Excel.Worksheet xlWorkSheet ;
        //    Excel.Range range ;



        //    string str;
        //    int rCnt ;
        //    int cCnt ;
        //    int rw = 0;
        //    int cl = 0;

        //    xlApp = new Excel.Application();

        //    xlWorkBook = xlApp.Workbooks.Open(@"d:\Employee Sheet.xls", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);

        //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);



        //    range = xlWorkSheet.UsedRange;

        //    rw = range.Rows.Count;

        //    cl = range.Columns.Count;





        //    for (rCnt = 1; rCnt<=rw; rCnt++)

        //    {
        //        for (cCnt = 1; cCnt<= cl; cCnt++)
        //         {
        //            str = Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value2);
        //            MessageBox.Show(str);
        //        }
        //    }



        //    xlWorkBook.Close(true, null, null);

        //    xlApp.Quit();



        //    Marshal.ReleaseComObject(xlWorkSheet);

        //    Marshal.ReleaseComObject(xlWorkBook);

        //    Marshal.ReleaseComObject(xlApp);



        
        //}

        private void btn_Create_file_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;

        
            excel.Cells.Font.Bold = true;
            
            excel.Cells[1, 1] ="EmployeeID";
            excel.Cells[1, 2] ="Name";
            excel.Cells[1, 3] = "DateOfBirth";
            excel.Cells[1, 4] = "Gender";
            excel.Cells[1, 5] = "DateOfJoining";
            excel.Cells[1, 6] = "Designation";
            excel.Cells[1, 7] = "JobType";

            excel.Cells[1, 8] = "FatherName";
            excel.Cells[1, 9] = "Father_Age";
            excel.Cells[1, 10] = "MotherName";
            excel.Cells[1, 11] = "Mother_Age";
            excel.Cells[1, 12] = "Spouse";  //--- 21/12/2018
            excel.Cells[1, 13] = "MaritalStatus";
            excel.Cells[1, 14] = "Religion";

            excel.Cells[1, 15] = "Cast";
            excel.Cells[1, 16] = "Mobile";
            excel.Cells[1, 17] = "Padd_Road";
            excel.Cells[1, 18] = "Padd_State";
            excel.Cells[1, 19] = "Padd_City";
            excel.Cells[1, 20] = "Padd_Country";
            excel.Cells[1, 21] = "Padd_Pin";
            excel.Cells[1, 22] = "Qualification";
            excel.Cells[1, 23] = "Board_University";
            excel.Cells[1, 24] = "YearOfPassing";
            excel.Cells[1, 25] = "Percentage";
            excel.Cells[1, 26] = "PF_No";
            excel.Cells[1, 27] = "ESI_No";
            excel.Cells[1, 28] = "AadharNo";//----------10/04/2018
            excel.Cells[1, 29] = "PanNo";   //--------------------          
            excel.Cells[1, 30] = "UAN_No";//ANURAG
            excel.Cells[1, 31] = "Bank";
            excel.Cells[1, 32] = "Branch";
            excel.Cells[1, 33] = "AcNo";
            excel.Cells[1, 34] = "IFSC";
            excel.Cells[1, 35] = "AcType";
            excel.Cells[1, 36] = "LocationName";            //Dipraj
            excel.Cells[1, 37] = "ClientName";
            excel.Cells[1, 38] = "EmployeeBasic";
            excel.Cells[1, 39] = "EmployeeSalary";



            //------------------------------------


            excel.Rows.Select();
            excel.Columns.AutoFit();
           
           
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEmpJoinExcel_Load(object sender, EventArgs e)
        {
            //generate year
            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
            //
            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }
            //

            lstDesignation.Items.Clear();
            DataTable dt = clsDataAccess.RunQDTbl("select DesignationName,ShortForm,SlNo from tbl_Employee_DesignationMaster");
            for(int ind=0; ind <dt.Rows.Count ; ind++)
            {
                lstDesignation.Items.Add(dt.Rows[ind][0].ToString() + " | " + dt.Rows[ind][1].ToString());  
            }
         
            dt = clsDataAccess.RunQDTbl("select pf_limit, esi_limit FROM CompanyLimiter");

            if (dt.Rows.Count > 0)
            {

                pf_limit = dt.Rows[0]["pf_limit"].ToString();
                esi_limit = dt.Rows[0]["esi_limit"].ToString();
            }


           
                CmbCompany.PopUp();

           

        }

        private void rdbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbManual.Checked == true)
            {
                txt_LstNo.Enabled = false;
                rdbAuto.Checked = false;
            }
        }

        private void rdbAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAuto.Checked == true)
            {
                txt_LstNo.Enabled = true;
                rdbManual.Checked = false;
            }

        }
        public void row_color()
        {
//LocationName
//ClientName
//DateOfBirth
//DateOfJoining
//Name
//Designation
            for (int idx = 0; idx < dgView_Emp.Rows.Count; idx++)
            {
                if (dgView_Emp.Rows[idx].Cells["LocationName"].Value.ToString().Trim() == "" || dgView_Emp.Rows[idx].Cells["LocationName"].Value.ToString().Trim() == "-" || 
          dgView_Emp.Rows[idx].Cells["ClientName"].Value.ToString().Trim() == "" || dgView_Emp.Rows[idx].Cells["ClientName"].Value.ToString().Trim() == "-" || 
          dgView_Emp.Rows[idx].Cells["Name"].Value.ToString().Trim() == "" || dgView_Emp.Rows[idx].Cells["Name"].Value.ToString().Trim() == "-" || 
          dgView_Emp.Rows[idx].Cells["Designation"].Value.ToString().Trim() == "" || dgView_Emp.Rows[idx].Cells["Designation"].Value.ToString().Trim() == "-")
                {
                    dgView_Emp.Rows[idx].DefaultCellStyle.BackColor = Color.Red;

                }

                if (dgView_Emp.Rows[idx].Cells["DateOfBirth"].Value.ToString().Trim() == "" || dgView_Emp.Rows[idx].Cells["DateOfBirth"].Value.ToString().Trim() == "-" || dgView_Emp.Rows[idx].Cells["DateOfBirth"].Value.ToString().Trim() == "01/01/1900")
                {

                   // dgView_Emp.Columns["DateOfBirth"].in
                }
            }

        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            LogFilePath = filePath.Substring(0, filePath.LastIndexOf("\\"));
            string extension = Path.GetExtension(filePath);
            string header = "YES";
               // rbHeaderYes.Checked ? "YES" : "NO";
            string conStr, sheetName;

            conStr = string.Empty;
            switch (extension)
            {

                case ".xls": //Excel 97-03
                    conStr = string.Format(Excel03ConString, filePath, header);
                    break;

                case ".xlsx": //Excel 07
                    conStr = string.Format(Excel07ConString, filePath, header);
                    break;
            }

            //Get the name of the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                    con.Close();
                }
            }

            //Read Data from the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    using (OleDbDataAdapter oda = new OleDbDataAdapter())
                    {
                        DateTime dob, doj;
                        DataTable dt = new DataTable();
                        cmd.CommandText = "select * From [" + sheetName + "]";
                            //"SELECT EmployeeID,Name,DateOfBirth,Gender,DateOfJoining,Designation,JobType,FatherName,Father_Age,MotherName,Mother_Age,Spouse,MaritalStatus,Religion,Cast,Mobile,Padd_Road,Padd_State,Padd_City,Padd_Country,Padd_Pin,Qualification,Board_University,YearOfPassing,Percentage,PF_No,ESI_No,AadharNo,PanNo,UAN_No,Bank,Branch,AcNo,IFSC,AcType,LocationName,ClientName,EmployeeBasic,EmployeeSalary from (select * From [" + sheetName + "])x";
                        cmd.Connection = con;
                        con.Open();
                       oda.SelectCommand = cmd;
        


                        oda.FillSchema(dt, SchemaType.Source);
                        foreach (DataColumn cl in dt.Columns)
                        {
                            if (cl.ColumnName.ToUpper().Contains("DATE"))
                                cl.DataType = typeof(string);
                            else if (cl.ColumnName.ToUpper().Contains("ACNO"))
                                cl.DataType = typeof(string);

                            else
                                cl.DataType = typeof(string);
                        }
                        oda.Fill(dt);
                        con.Close();

                        try
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (dt.Rows[i]["DateOfBirth"].ToString().Trim().Length == 5)
                                {
                                    dob = DateTime.FromOADate(Convert.ToInt32(dt.Rows[i]["DateOfBirth"].ToString().Trim()));
                                    dt.Rows[i]["DateOfBirth"] = dob.ToString("dd/MM/yyyy");
                                }


                                if (dt.Rows[i]["DateOfJoining"].ToString().Trim().Length == 5)
                                {
                                    doj = DateTime.FromOADate(Convert.ToInt32(dt.Rows[i]["DateOfJoining"].ToString().Trim()));
                                    dt.Rows[i]["DateOfJoining"] = doj.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    try
                                    {
                                        doj = Convert.ToDateTime(dt.Rows[i]["DateOfJoining"].ToString().Trim());
                                    }
                                    catch
                                    {
                                        doj = Convert.ToDateTime("01/01/1900");
                                    }
                                    dt.Rows[i]["DateOfJoining"] = doj.ToString("dd/MM/yyyy");
                                }


                            }
                        }
                        catch { }
                            //Populate DataGridView.
                            this.dgView_Emp.DataSource = dt;
                            //row_color();
                    }
                }
            }
        }

        private void dgView_Emp_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgView_Emp_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            FormatRow(dgView_Emp.Rows[e.RowIndex]);
        }

        public bool chk_row(DataGridViewRow row)
        {
            bool rs=true;
            try
            {
                if (row.Cells["LocationName"].Value.ToString().Trim() == "" || row.Cells["LocationName"].Value.ToString().Trim() == "-" ||
          row.Cells["ClientName"].Value.ToString().Trim() == "" || row.Cells["ClientName"].Value.ToString().Trim() == "-" ||
          row.Cells["Name"].Value.ToString().Trim() == "" || row.Cells["Name"].Value.ToString().Trim() == "-" ||
          row.Cells["Designation"].Value.ToString().Trim() == "" || row.Cells["Designation"].Value.ToString().Trim() == "-")
                {
                    rs = false;

                }
                
            }
            catch { }
            return rs;
        }
        private void FormatRow(DataGridViewRow row)
        {
           
                try
                {
                    if (row.Cells["LocationName"].Value.ToString().Trim() == "" || row.Cells["LocationName"].Value.ToString().Trim() == "-" ||
              row.Cells["ClientName"].Value.ToString().Trim() == "" || row.Cells["ClientName"].Value.ToString().Trim() == "-" ||
              row.Cells["Name"].Value.ToString().Trim() == "" || row.Cells["Name"].Value.ToString().Trim() == "-" ||
              row.Cells["Designation"].Value.ToString().Trim() == "" || row.Cells["Designation"].Value.ToString().Trim() == "-")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;

                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                catch { }
                try
                {
                    if (row.Cells["DateOfBirth"].Value.ToString().Trim() == "" || row.Cells["DateOfBirth"].Value.ToString().Trim() == "-" || row.Cells["DateOfBirth"].Value.ToString().Trim() == "01/01/1900")
                    {

                        row.Cells["DateOfBirth"].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        row.Cells["DateOfBirth"].Style.BackColor = Color.White;

                    }
                }
                catch { }
                try
                {
                    if (row.Cells["DateOfJoining"].Value.ToString().Trim() == "" || row.Cells["DateOfJoining"].Value.ToString().Trim() == "-" || row.Cells["DateOfJoining"].Value.ToString().Trim() == "01/01/1900")
                    {

                        row.Cells["DateOfJoining"].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        row.Cells["DateOfJoining"].Style.BackColor = Color.White;
                    }
                }
                catch { }

            
        }

        private void btnReChk_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgView_Emp.Rows)
            {
                FormatRow(dgView_Emp.Rows[row.Index]);
            }
        }

        private void btn_Create_File_data_Click(object sender, EventArgs e)
        {
            //excel

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            int iCol = 0, cCol = dgView_Emp.Columns.Count, cRow = dgView_Emp.Rows.Count;

            if (cCol == 0 || cRow==0)
            {
                MessageBox.Show("No Record Present","Bravo");
                return;
            }


            foreach (DataGridViewColumn c in dgView_Emp.Columns)
            {
                iCol++;
                excel.Cells[1, iCol] = c.HeaderText;
            }
            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, cCol]);
            range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();

            int iRow = 1;
            foreach (DataGridViewRow r in dgView_Emp.Rows)
            {
                iRow++;
                iCol = 0;
                foreach (DataGridViewColumn c in dgView_Emp.Columns)
                {
                    try
                    {
                        iCol++;
                        excel.Cells[iRow, iCol] = r.Cells[c.Index].Value.ToString();

                        if (iCol > 5)
                        {
                            range = worksheet.get_Range(worksheet.Cells[iRow, 6], worksheet.Cells[iRow, cCol - 1]);
                            range.NumberFormat = "@";
                        }
                        else
                        {

                            range = worksheet.get_Range(worksheet.Cells[iRow, 1], worksheet.Cells[iRow, 5]);

                            range.NumberFormat = "@";
                        }

                    }
                    catch
                    {

                    }
                }
            }
            object missing = System.Reflection.Missing.Value;

            worksheet = (Excel.Worksheet)excel.ActiveSheet;
            ((Excel._Worksheet)worksheet).Activate();

            worksheet.UsedRange.Select();
            worksheet.UsedRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexNone, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
            worksheet.Columns.AutoFit();

            ((Excel._Application)excel).Quit();

            MessageBox.Show("Export To ExcelCompleted!", "Export");
        }

       
     
        //private void dgView_Emp_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    foreach (DataGridViewRow row in dgView_Emp.Rows)
        //    {
        //        try
        //        {
        //            if (row.Cells["LocationName"].Value.ToString().Trim() == "" || row.Cells["LocationName"].Value.ToString().Trim() == "-" ||
        //      row.Cells["ClientName"].Value.ToString().Trim() == "" || row.Cells["ClientName"].Value.ToString().Trim() == "-" ||
        //      row.Cells["Name"].Value.ToString().Trim() == "" || row.Cells["Name"].Value.ToString().Trim() == "-" ||
        //      row.Cells["Designation"].Value.ToString().Trim() == "" || row.Cells["Designation"].Value.ToString().Trim() == "-")
        //            {
        //                row.DefaultCellStyle.BackColor = Color.Red;

        //            }
        //        }
        //        catch { }
        //        try
        //        {
        //            if (row.Cells["DateOfBirth"].Value.ToString().Trim() == "" || row.Cells["DateOfBirth"].Value.ToString().Trim() == "-" || row.Cells["DateOfBirth"].Value.ToString().Trim() == "01/01/1900")
        //            {

        //                row.Cells["DateOfBirth"].Style.BackColor = Color.Yellow;
        //            }
        //        }
        //        catch { }
        //        try
        //        {
        //            if (row.Cells["DateOfJoining"].Value.ToString().Trim() == "" || row.Cells["DateOfJoining"].Value.ToString().Trim() == "-" || row.Cells["DateOfJoining"].Value.ToString().Trim() == "01/01/1900")
        //            {

        //                row.Cells["DateOfJoining"].Style.BackColor = Color.Yellow;
        //            }
        //        }
        //        catch { }

        //    }
        //}
       
       
    }
}
