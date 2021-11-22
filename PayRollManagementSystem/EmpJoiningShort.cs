using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace PayRollManagementSystem
{
    public partial class EmpJoiningShort : Form
    {  Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        SqlTransaction sqltran;
        string lcid = "";
       public DataTable elist;
        public EmpJoiningShort(string lid)
        {
            InitializeComponent();

            lcid = lid.Trim();
        }
        string Loc_id = "0", co_id = "0",desgid="0";

        int ind_dt = 0;
       

        public string get_EmpNo()
        {
            Int32 odno = 0;
            int dcno = 4;
            string dcpref = "E",dcsufix="";


            string[] dc = clsDataAccess.Emp_No_struct().Split('|');

            dcpref = dc[0].Trim();
            dcno = Convert.ToInt32(dc[1]);
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


            DataTable dt2 = clsDataAccess.RunQDTbl("select [maxget].ID from (select ID from tbl_Employee_Mast where ID like '" + dcpref + "%') as maxget" +
                                                    " order by CAST(SUBSTRING(maxget.ID,2,LEN(maxget.ID)-1) as int) desc");
            
           
                if (dt2.Rows.Count > 0)
                {
                    string maxEmployeeId = dt2.Rows[0][0].ToString(); //21092017
                    maxEmployeeId = maxEmployeeId.Substring(1, maxEmployeeId.Length - 1);
                    odno = Convert.ToInt32(maxEmployeeId);
                    odno = odno + 1;
                }
                else
                {
                    odno = 1;
                }
            return dcpref + odno.ToString(dcsufix);
        }


        public void clear()
        {
            cmbcopany.Text = "";
            cmblocation.Text = "";
            cmbDesg.Text = "";
            cmbdEmpId.Text = get_EmpNo();
            if (lcid.Trim() == "")
            {
                DataTable dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID from tbl_Emp_Location");
                //where Location_ID in(select Location_ID from Companywiseid_Relation where Company_ID='" + co_id + "' )");
                if (dt.Rows.Count > 0)
                {
                    cmblocation.LookUpTable = dt;
                    cmblocation.ReturnIndex = 1;
                }
            }
            else
            {
                DataTable dt = clsDataAccess.RunQDTbl("select (Select CO_NAME from Company where CO_CODE=clr.Company_ID)Company, Company_ID,(Select Location_Name from tbl_Emp_Location where (location_id='"+ lcid +"'))Location from Companywiseid_Relation as clr where (Location_ID='" + lcid + "')");
                if (dt.Rows.Count > 0)
                {
                    cmblocation.Text = dt.Rows[0]["Location"].ToString();
                    cmblocation.ReturnValue = lcid;
                    Loc_id = lcid;
                    cmbcopany.Text = dt.Rows[0]["Company"].ToString();
                    co_id = dt.Rows[0]["Company_id"].ToString();
                }
            }
            txtEmpFName.Text = "";
            txtEmpMName.Text = "";
            txtEmpLName.Text = "";

            DataTable dt1 = clsDataAccess.RunQDTbl("select DesignationName,ShortForm,SlNo from tbl_Employee_DesignationMaster");
            if (dt1.Rows.Count > 0)
            {
                cmbDesg.LookUpTable = dt1;
                cmbDesg.ReturnIndex = 2;
            }

            dtpDOB.Value = DateTime.Now.Date.AddYears(-18);
           
            
        }

        private Boolean ChekExRecordByEmpId_Update()
        {
            Boolean boolStatus = false;

            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Mast emp where (emp.ID='" + cmbdEmpId.Text.Trim() + "')");
            //"select emp.*,desg.DesignationName,job.JobType from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg, tbl_Employee_JobType job where emp.DesgId=desg.SlNo and emp.JobType=job.SlNo and emp.ID='" + cmbdEmpId.Text.Trim() + "'", edpcon.mycon, sqltran);
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }

            return boolStatus;
        }

         private Int32 GetJobTypeId(String strJobType)
        {
            Int32 intJobId = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select SlNo from tbl_Employee_JobType where (JobType='" + strJobType + "')");
            if (dt.Rows.Count > 0)
            {
                intJobId = Convert.ToInt32(dt.Rows[0]["SlNo"]);
            }
            return intJobId;
        }

        public void accept_data()
        {
            int pf_deduction = 0, esi_deduction = 0;
            int _active = 1, pay_mod = 0;
           
            string lan_Ben = "0,0,0", lan_hindi = "0,0,0", lan_Eng = "0,0,0", lan_Other = "0,0,0";

            string pf_name = "", esi_name = "", bankAc_Name = "", ename = "", Pf_No = "xxxx", Esi_No = "xxxx";
            if (txtEmpFName.Text.Trim() != "")
            {
                ename = txtEmpFName.Text.Trim();
                if (txtEmpMName.Text.Trim() != "")
                {
                    ename = ename.Trim() + " " + txtEmpMName.Text.Trim();
                }
                if (txtEmpLName.Text.Trim() != "")
                {
                    ename = ename.Trim() + " " + txtEmpLName.Text.Trim();
                }

            }
            Pf_No = "xxxx";
            pf_name = ename;
            Esi_No = "xxxx";
            esi_name = ename;
            bankAc_Name = ename;

            pay_mod =1;


            if (ChekExRecordByEmpId_Update())
            {

            }

            else
            {

                Boolean boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Mast (ID,Title,FirstName,MiddleName,LastName,FathTitle,FathFN,FathMN,FathLN,MothTitle,MothFN,MothMN,MothLN,HusTitle,HusFN,HusMN,HusLN,DateOfBirth,Cast,MaritalStatus,Gender,DesgId,JobType,PresentAddress,PermanentAddress,STD,Phone,Mobile,PANno,PassportNo,PF,PenssionNo,EDLI, " +
                        " ESIno,BankAcountNo,DateOfJoining,DateOfRetirement,Session,GMIno,EmailId,PenssionDate,Presentbuilding,Presentstreet,Presentareia,Presentcity,Presentpin,Presentstate,Presentcountry,Permanentbuilding,Permanentstreet,Permanentareia,Permanentcity,Permanentpin,Permanentstate,Permanentcountry,Religion,Weight," +
                        " Height,Language_Bengali,Language_Hindi,Language_English,Language_Other,Language_Name,Empdocimage2,Empdocimage3,Document_Titel,Document_Titel2,Document_Titel3,Location_id,Company_id,PF_Deduction,EmpBasic,active,EMPSAL,Bank_Name,Branch_Name,Bank_AC_Type,pf_name,esi_name,bankAc_name,ESI_Deduction, remarks, oRemarks, status,pay_mod) values('" +
                        cmbdEmpId.Text.Trim() + "','','" + txtEmpFName.Text.Trim() + "','" + txtEmpMName.Text.Trim() + "','" + txtEmpLName.Text.Trim() + "','','','','','','','','','','','','','" + edpcom.getSqlDateStr(dtpDOB.Value) + "','','',''," + desgid + "," + GetJobTypeId("FULL TIME") + ",'','',0,0,0,'','','" + 
                        Pf_No + "','','','" + Esi_No + "','','" + edpcom.getSqlDateStr(dtpDOJ.Value) + "','','','','','','','','','','','0','0','','','','','','0','0','','','','" + lan_Ben + "','" + lan_hindi + "','" + lan_Eng + "','" + lan_Other + "','','','','','','','" + Loc_id + "','" + co_id + "','" + pf_deduction + "',0,'" + _active + "',0,'','','','" +
                        pf_name + "','" + esi_name + "','" + bankAc_Name + "','" + esi_deduction + "','','','" + _active + "','" + pay_mod + "')");
                
                edpcom.InsertMidasLog(this, true, "add", cmbdEmpId.Text.Trim());

                if (boolStatus == true)
                {
                    string st = "insert into [tbl_statuslog](slid,eid,sid,sdate,ucode,reason) values ((select max(slid)+1 from tbl_statuslog),'" + cmbdEmpId.Text.Trim() +
                                    "','" + _active + "','" + dtpDOJ.Value.ToString("dd/MMM/yyyy") + "','" + edpcom.UserDesc + "','Employee Inserted')";
                   clsDataAccess.RunNQwithStatus(st);
                    st = "";
                   clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Other_Reff(ID,Emarg_Name,Emarg_Address,Emarg_Tele,Emarg_Mobile,Emp_Achiev,Emp_Club,Emp_Association,Emp_Org,Emp_Notic,Emp_Join_refer,Emp_Preferlocation,Emp_Criminal_Rec,Emp_illness,Emp_Interview_Details,Emp_OtherInformation,Emp_Expected_Salary, " +
                    " Ref_Name,Ref_Address,Ref_Occupation,Ref_Phone,Ref_Email,Ref_Name1,Ref_Address1,Ref_Occupation1,Ref_Phone1,Ref_Email1,Emp_Service,Emp_Period_Service,Emp_Rank,Emp_ICard_No,Emp_Arms,Emp_Pension_No,Emp_GunLicence,Emp_Operation_Area,Emp_issue,Emp_GunType,Emp_GunValid,Emp_DrivingLicence) values('" +
                    cmbdEmpId.Text.Trim() + "','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','')");

                    elist.Rows.Add();
                    elist.Rows[ind_dt]["eid"] = cmbdEmpId.Text.Trim();
                    elist.Rows[ind_dt]["ename"] = ename.Trim();
                    ind_dt++;

                    

                    ERPMessageBox.ERPMessage.Show("Employee Details Submitted Successfully." + Environment.NewLine + "Want to Add more ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
                    if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
                    {
                        clear();
                    }
                    else{
                    this.Close();
                    
                    this.Dispose(true);
                    }
                }
                
            }

        }
        private void EmpJoiningShort_Load(object sender, EventArgs e)
        {
            clear();
            elist = new DataTable();
            try
            {
                elist.Columns.Clear();

            }
            catch { }
            try
            {
                elist.Rows.Clear();
            }
            catch { }
            elist.Columns.Add("eid");
            elist.Columns.Add("ename");

            cmbcopany.ReadOnlyText = true;

            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbcopany.Text = Convert.ToString(dt_co.Rows[0][0]);

                co_id = (dt_co.Rows[0][1].ToString());

            }
            else if (dt_co.Rows.Count > 1)
            {
                cmbcopany.PopUp();

            }
        }

        private void cmblocation_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID from tbl_Emp_Location");
            //where Location_ID in(select Location_ID from Companywiseid_Relation where Company_ID='" + co_id + "' )");
            if (dt.Rows.Count > 0)
            {
                cmblocation.LookUpTable = dt;
                cmblocation.ReturnIndex = 1;
            }
        }

        private void cmblocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmblocation.ReturnValue) == true)
                Loc_id = Convert.ToString(cmblocation.ReturnValue);


            DataTable dt = clsDataAccess.RunQDTbl("select (Select CO_NAME from Company where CO_CODE=clr.Company_ID)Company, Company_ID from Companywiseid_Relation as clr where (Location_ID='" + Loc_id + "')");
            if (dt.Rows.Count > 0)
            {
                cmbcopany.LookUpTable = dt;
                cmbcopany.ReturnIndex = 1;
                if (dt.Rows.Count > 1)
                {
                    cmbcopany.PopUp();
                }
                else
                {
                    cmbcopany.Text = dt.Rows[0]["Company"].ToString();
                    co_id = dt.Rows[0]["Company_id"].ToString();
                }
                dtpDOB.Focus();  
            }
        }

        private void cmbcopany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            co_id = cmbcopany.ReturnValue;
        }

        private void cmbDesg_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            desgid = cmbDesg.ReturnValue;
            cmblocation.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Close();
            this.Dispose(true);
        }

        private void btnFullEmpJoin_Click(object sender, EventArgs e)
        {
            EmpJoining ej = new EmpJoining();
            ej.ShowDialog();

            clear();
        }

        private void dtpDOJ_ValueChanged(object sender, EventArgs e)
        {
            //GetRetirementDate();
            //GetPenssionDate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            accept_data();

        }
    }
}
