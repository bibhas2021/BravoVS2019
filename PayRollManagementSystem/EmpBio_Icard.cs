using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

using Microsoft.VisualBasic;
using Microsoft.Win32;
using Edpcom;
using System.IO;


namespace PayRollManagementSystem
{
    public partial class EmpBio_Icard : Form
    {

        int Co_ID = 0, Location_ID = 0;
        string Emp_ID = "0";
        string emp_id="",cadd="";

        public EmpBio_Icard()
        {
            InitializeComponent();

        }
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon con = new Edpcom.EDPCommon();
        SqlCommand cmd = new SqlCommand();

        DataTable dtquali = new DataTable();
        DataTable dtfamily = new DataTable();

        DataTable dt_co = new DataTable();
        DataTable dvl_table = new DataTable();
        DataSet ds = new DataSet();
        DataSet DS_VL = new DataSet();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        ArrayList arritem = new ArrayList();
        Hashtable getcode_item = new Hashtable();
        string Item_Code = "";

        //SqlConnection con = new SqlConnection("Data Source=DUTTA\\SQLEXPRESS;Initial Catalog=EDP_Payroll;Integrated Security=True;User Instance=False"); 

        private void frmEmpJoining_Load(object sender, EventArgs e)
        {
            //CmbCompany.Text = "";

            //CmbLocation.Text = "";
            //CmbEmpId.Text = "";

            //edpcon.Open();
            //DataTable dtco = clsDataAccess.RunQDTbl("select CO_name from company"); 


            //if (dtco.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtco.Rows.Count; i++)
            //    {
            //        CmbCompany.Items.Add(dtco.Rows[i]["CO_Name"].ToString());
            //        //CmbClient.Items.Add(dtco.Rows[i]["Client_name"].ToString());
            //    }
            //}

            //DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            //if (dta.Rows.Count == 1)
            //{
            //    CmbCompany.Text = dta.Rows[0][0].ToString();

            //    Co_ID = Convert.ToInt32(dta.Rows[0][1].ToString());
            //    CmbCompany.ReturnValue = Co_ID.ToString();
            //    CmbCompany.Enabled = false;

            //}
            //else if (dta.Rows.Count > 1)
            //{
                CmbCompany.PopUp();
            //}

                if (clsDataAccess.GetresultS("select download from CompanyLimiter") == "1")
                {
                    btn_download.Visible = true;
                }
                else
                {
                    btn_download.Visible = false;
                }

            rdb_ic_emp_CheckedChanged(sender, e);
        }

        private void BtnDisp_Click(object sender, EventArgs e)
        {

            string CO_NAM = "";
            //SqlCommand cmdcomp = new SqlCommand();
            //SqlCommand cmdsql = new SqlCommand();
            //SqlCommand presentcmd = new SqlCommand();
            edpcon.Close();
            edpcon.Open();
            DataTable DT_Comp = new DataTable();
            DataTable Dt_Emp = new DataTable();
            try
            {
                if (rdb_ic_selective.Checked == true)
                {
                    DT_Comp = clsDataAccess.RunQDTbl("SELECT DISTINCT Company.CO_NAME FROM tbl_Employee_Mast INNER JOIN Company ON tbl_Employee_Mast.Company_id = Company.CO_CODE where tbl_Employee_Mast.ID in (" + Emp_ID + ")");
                }
                else
                {
                    DT_Comp = clsDataAccess.RunQDTbl("SELECT DISTINCT Company.CO_NAME FROM tbl_Employee_Mast INNER JOIN Company ON tbl_Employee_Mast.Company_id = Company.CO_CODE where tbl_Employee_Mast.ID='" + Emp_ID + "'");
                }
                if (DT_Comp.Rows.Count > 0)
                    CO_NAM = (DT_Comp.Rows[0]["co_name"].ToString());
            }
            catch {

                CO_NAM = CmbCompany.Text;
            }

            string sql_emp = "";
            if (Location_ID != 0)
            {
                if (rdb_ic_selective.Checked == true)
                {

                    sql_emp = "SELECT em.Code,em.ID,isNull(em.Title,'') Title,em.FirstName,em.MiddleName,em.LastName," +
    "em.FathTitle,em.FathFN,em.FathMN,em.FathLN,em.MothTitle,em.MothFN,em.MothMN,em.MothLN,em.HusTitle," +
    "em.HusFN,em.HusMN,em.HusLN,em.DateOfBirth,em.Cast,em.MaritalStatus,em.Gender,em.DesgId,em.JobType," +
    "em.PresentAddress,em.PermanentAddress,em.STD,em.Phone,em.Mobile,em.aadhar,em.PANno,em.PassportNo,em.PF,em.PenssionNo," +
    "em.EDLI,em.ESIno,em.BankAcountNo,em.DateOfJoining,em.DateOfRetirement,em.InsertionDate,em.Session," +
    "em.GMIno,em.PenssionDate,em.EmailId,em.salid,em.SecId,em.EmpWorkingStatus,em.Empimage,em.Empdocimage," +
    "em.Empdocimage2,em.Empdocimage3,em.Presentbuilding,em.Presentstreet,em.Presentareia,em.Presentcity," +
    "em.Presentpin,em.Presentstate,em.Presentcountry,em.Permanentbuilding,em.Permanentstreet,em.Permanentareia," +
    "em.Permanentcity,em.Permanentpin,em.Permanentstate,em.Permanentcountry,em.Religion,em.Weight,em.Height," +
    "em.Language_Bengali,em.Language_Hindi,em.Language_English,em.Language_Other,em.Language_Name,em.Document_Titel," +
    "em.Document_Titel2,em.Document_Titel3,em.Location_id,em.Company_id,em.PF_Deduction,em.EMPBASIC,em.active," +
    "em.EMPSAL,em.Bank_Name,em.Branch_Name,em.Bank_AC_Type,eor.Emarg_Name,eor.Emarg_Address,eor.Emarg_Tele," +
    "eor.Emarg_Mobile,eor.Ref_Name,eor.Ref_Address,eor.Ref_Occupation,eor.Ref_Phone,eor.Ref_Email,eor.Emp_Service," +
    "eor.Emp_Period_Service,eor.Emp_Rank,eor.Emp_ICard_No,eor.Emp_Arms,eor.Emp_Pension_No,eor.Emp_GunLicence," +
    "eor.Emp_Operation_Area,eor.Emp_issue,eor.Emp_GunType,eor.Emp_GunValid,eor.Emp_DrivingLicence,cast(em.STD as nvarchar) +' '+ cast(em.Phone as nvarchar) as tel, cast(em.Mobile as nvarchar)Mobile " +
    "FROM tbl_Employee_Mast AS em INNER JOIN tbl_Employee_Other_Reff AS eor ON em.ID = eor.ID " +
    "WHERE em.Company_id='" + Co_ID + "'and em.location_id='" + Location_ID + "'and em.id IN (" + Emp_ID + ")";

                }
                else
                {
                    //                if (chk_ti_sign.Checked == true)
                    //                {
                    //                    sql_emp = "SELECT em.Code,em.ID,isNull(em.Title,'') Title,em.FirstName,em.MiddleName,em.LastName," +
                    //"em.FathTitle,em.FathFN,em.FathMN,em.FathLN,em.MothTitle,em.MothFN,em.MothMN,em.MothLN,em.HusTitle," +
                    //"em.HusFN,em.HusMN,em.HusLN,em.DateOfBirth,em.Cast,em.MaritalStatus,em.Gender,em.DesgId,em.JobType," +
                    //"em.PresentAddress,em.PermanentAddress,em.STD,em.Phone,em.Mobile,em.PANno,em.PassportNo,em.PF,em.PenssionNo," +
                    //"em.EDLI,em.ESIno,em.BankAcountNo,em.DateOfJoining,em.DateOfRetirement,em.InsertionDate,em.Session," +
                    //"em.GMIno,em.PenssionDate,em.EmailId,em.salid,em.SecId,em.EmpWorkingStatus,em.Empimage,em.Empdocimage," +
                    //"em.Empdocimage2,em.Empdocimage3,em.Presentbuilding,em.Presentstreet,em.Presentareia,em.Presentcity," +
                    //"em.Presentpin,em.Presentstate,em.Presentcountry,em.Permanentbuilding,em.Permanentstreet,em.Permanentareia," +
                    //"em.Permanentcity,em.Permanentpin,em.Permanentstate,em.Permanentcountry,em.Religion,em.Weight,em.Height," +
                    //"em.Language_Bengali,em.Language_Hindi,em.Language_English,em.Language_Other,em.Language_Name,em.Document_Titel," +
                    //"em.Document_Titel2,em.Document_Titel3,em.Location_id,em.Company_id,em.PF_Deduction,em.EMPBASIC,em.active," +
                    //"em.EMPSAL,em.Bank_Name,em.Branch_Name,em.Bank_AC_Type,eor.Emarg_Name,eor.Emarg_Address,eor.Emarg_Tele," +
                    //"eor.Emarg_Mobile,eor.Ref_Name,eor.Ref_Address,eor.Ref_Occupation,eor.Ref_Phone,eor.Ref_Email,eor.Emp_Service," +
                    //"eor.Emp_Period_Service,eor.Emp_Rank,eor.Emp_ICard_No,eor.Emp_Arms,eor.Emp_Pension_No,eor.Emp_GunLicence," +
                    //"eor.Emp_Operation_Area,eor.Emp_issue,eor.Emp_GunType,eor.Emp_GunValid,eor.Emp_DrivingLicence, " +
                    //"f.lThumb,f.rThumb,f.lIndex,f.rIndex,f.lMiddle,f.rMiddle,f.lRing,f.rRing,f.lfourth,f.rfourth,f.sign " +
                    //"FROM tbl_Employee_Mast AS em INNER JOIN tbl_Employee_Other_Reff AS eor ON em.ID = eor.ID " +
                    //"inner join tbl_employee_fscan as f  on em.ID=f.ID" +
                    //"WHERE em.Company_id='" + Co_ID + "'and em.location_id='" + Location_ID + "'and em.id='" + Emp_ID + "'";

                    //                }
                    //                else
                    //{
                    sql_emp = "SELECT em.Code,em.ID,isNull(em.Title,'') Title,em.FirstName,em.MiddleName,em.LastName," +
    "em.FathTitle,em.FathFN,em.FathMN,em.FathLN,em.MothTitle,em.MothFN,em.MothMN,em.MothLN,em.HusTitle," +
    "em.HusFN,em.HusMN,em.HusLN,em.DateOfBirth,em.Cast,em.MaritalStatus,em.Gender,em.DesgId,(case when em.JobType='0' then '' else (select shortform from tbl_Employee_JobType where slno=em.JobType) end)JobType," +
    "em.PresentAddress,em.PermanentAddress,em.STD,em.Phone,em.Mobile,em.aadhar,em.PANno,em.PassportNo,em.PF,em.PenssionNo," +
    "em.EDLI,em.ESIno,em.BankAcountNo,em.DateOfJoining,em.DateOfRetirement,em.InsertionDate,em.Session," +
    "em.GMIno,em.PenssionDate,em.EmailId,em.salid,em.SecId,em.EmpWorkingStatus,em.Empimage,em.Empdocimage," +
    "em.Empdocimage2,em.Empdocimage3,em.Presentbuilding,em.Presentstreet,em.Presentareia,em.Presentcity," +
    "em.Presentpin,em.Presentstate,em.Presentcountry,em.Permanentbuilding,em.Permanentstreet,em.Permanentareia," +
    "em.Permanentcity,em.Permanentpin,em.Permanentstate,em.Permanentcountry,em.Religion,em.Weight,em.Height," +
    "em.Language_Bengali,em.Language_Hindi,em.Language_English,em.Language_Other,em.Language_Name,em.Document_Titel," +
    "em.Document_Titel2,em.Document_Titel3,em.Location_id,em.Company_id,em.PF_Deduction,em.EMPBASIC,em.active," +
    "em.EMPSAL,em.Bank_Name,em.Branch_Name,em.Bank_AC_Type,eor.Emarg_Name,eor.Emarg_Address,eor.Emarg_Tele," +
    "eor.Emarg_Mobile,eor.Ref_Name,eor.Ref_Address,eor.Ref_Occupation,eor.Ref_Phone,eor.Ref_Email,eor.Emp_Service," +
    "eor.Emp_Period_Service,eor.Emp_Rank,eor.Emp_ICard_No,eor.Emp_Arms,eor.Emp_Pension_No,eor.Emp_GunLicence," +
    "eor.Emp_Operation_Area,eor.Emp_issue,eor.Emp_GunType,eor.Emp_GunValid,eor.Emp_DrivingLicence,cast(em.STD as nvarchar) +' '+ cast(em.Phone as nvarchar) as tel, cast(em.Mobile as nvarchar)Mobile " +
    "FROM tbl_Employee_Mast AS em INNER JOIN tbl_Employee_Other_Reff AS eor ON em.ID = eor.ID " +
    "WHERE em.Company_id='" + Co_ID + "'and em.location_id='" + Location_ID + "'and em.id='" + Emp_ID + "'";
                    //}
                }
            }
            else
            {
                if (rdb_ic_selective.Checked == true)
                {
                    sql_emp = "SELECT em.Code,em.ID,isNull(em.Title,'') Title,em.FirstName,em.MiddleName,em.LastName," +
    "em.FathTitle,em.FathFN,em.FathMN,em.FathLN,em.MothTitle,em.MothFN,em.MothMN,em.MothLN,em.HusTitle," +
    "em.HusFN,em.HusMN,em.HusLN,em.DateOfBirth,em.Cast,em.MaritalStatus,em.Gender,em.DesgId,(case when em.JobType='0' then '' else (select shortform from tbl_Employee_JobType where slno=em.JobType) end)JobType," +
    "em.PresentAddress,em.PermanentAddress,em.STD,em.Phone,em.Mobile,em.aadhar,em.PANno,em.PassportNo,em.PF,em.PenssionNo," +
    "em.EDLI,em.ESIno,em.BankAcountNo,em.DateOfJoining,em.DateOfRetirement,em.InsertionDate,em.Session," +
    "em.GMIno,em.PenssionDate,em.EmailId,em.salid,em.SecId,em.EmpWorkingStatus,em.Empimage,em.Empdocimage," +
    "em.Empdocimage2,em.Empdocimage3,em.Presentbuilding,em.Presentstreet,em.Presentareia,em.Presentcity," +
    "em.Presentpin,em.Presentstate,em.Presentcountry,em.Permanentbuilding,em.Permanentstreet,em.Permanentareia," +
    "em.Permanentcity,em.Permanentpin,em.Permanentstate,em.Permanentcountry,em.Religion,em.Weight,em.Height," +
    "em.Language_Bengali,em.Language_Hindi,em.Language_English,em.Language_Other,em.Language_Name,em.Document_Titel," +
    "em.Document_Titel2,em.Document_Titel3,em.Location_id,em.Company_id,em.PF_Deduction,em.EMPBASIC,em.active," +
    "em.EMPSAL,em.Bank_Name,em.Branch_Name,em.Bank_AC_Type,eor.Emarg_Name,eor.Emarg_Address,eor.Emarg_Tele," +
    "eor.Emarg_Mobile,eor.Ref_Name,eor.Ref_Address,eor.Ref_Occupation,eor.Ref_Phone,eor.Ref_Email,eor.Emp_Service," +
    "eor.Emp_Period_Service,eor.Emp_Rank,eor.Emp_ICard_No,eor.Emp_Arms,eor.Emp_Pension_No,eor.Emp_GunLicence," +
    "eor.Emp_Operation_Area,eor.Emp_issue,eor.Emp_GunType,eor.Emp_GunValid,eor.Emp_DrivingLicence,cast(em.STD as nvarchar) +' '+ cast(em.Phone as nvarchar) as tel, cast(em.Mobile as nvarchar)Mobile " +
    "FROM tbl_Employee_Mast AS em INNER JOIN tbl_Employee_Other_Reff AS eor ON em.ID = eor.ID " +
    "WHERE em.Company_id='" + Co_ID + "' and em.id IN (" + Emp_ID + ")";


                }
                else
                {
                    sql_emp = "SELECT em.Code,em.ID,isNull(em.Title,'') Title,em.FirstName,em.MiddleName,em.LastName," +
    "em.FathTitle,em.FathFN,em.FathMN,em.FathLN,em.MothTitle,em.MothFN,em.MothMN,em.MothLN,em.HusTitle," +
    "em.HusFN,em.HusMN,em.HusLN,em.DateOfBirth,em.Cast,em.MaritalStatus,em.Gender,em.DesgId,(case when em.JobType='0' then '' else (select shortform from tbl_Employee_JobType where slno=em.JobType) end)JobType," +
    "em.PresentAddress,em.PermanentAddress,em.STD,em.Phone,em.Mobile,em.aadhar,em.PANno,em.PassportNo,em.PF,em.PenssionNo," +
    "em.EDLI,em.ESIno,em.BankAcountNo,em.DateOfJoining,em.DateOfRetirement,em.InsertionDate,em.Session," +
    "em.GMIno,em.PenssionDate,em.EmailId,em.salid,em.SecId,em.EmpWorkingStatus,em.Empimage,em.Empdocimage," +
    "em.Empdocimage2,em.Empdocimage3,em.Presentbuilding,em.Presentstreet,em.Presentareia,em.Presentcity," +
    "em.Presentpin,em.Presentstate,em.Presentcountry,em.Permanentbuilding,em.Permanentstreet,em.Permanentareia," +
    "em.Permanentcity,em.Permanentpin,em.Permanentstate,em.Permanentcountry,em.Religion,em.Weight,em.Height," +
    "em.Language_Bengali,em.Language_Hindi,em.Language_English,em.Language_Other,em.Language_Name,em.Document_Titel," +
    "em.Document_Titel2,em.Document_Titel3,em.Location_id,em.Company_id,em.PF_Deduction,em.EMPBASIC,em.active," +
    "em.EMPSAL,em.Bank_Name,em.Branch_Name,em.Bank_AC_Type,eor.Emarg_Name,eor.Emarg_Address,eor.Emarg_Tele," +
    "eor.Emarg_Mobile,eor.Ref_Name,eor.Ref_Address,eor.Ref_Occupation,eor.Ref_Phone,eor.Ref_Email,eor.Emp_Service," +
    "eor.Emp_Period_Service,eor.Emp_Rank,eor.Emp_ICard_No,eor.Emp_Arms,eor.Emp_Pension_No,eor.Emp_GunLicence," +
    "eor.Emp_Operation_Area,eor.Emp_issue,eor.Emp_GunType,eor.Emp_GunValid,eor.Emp_DrivingLicence,cast(em.STD as nvarchar) +' '+ cast(em.Phone as nvarchar) as tel, cast(em.Mobile as nvarchar)Mobile " +
    "FROM tbl_Employee_Mast AS em INNER JOIN tbl_Employee_Other_Reff AS eor ON em.ID = eor.ID " +
    "WHERE em.Company_id='" + Co_ID + "' and em.id='" + Emp_ID + "'";
                }
            }
            Dt_Emp = clsDataAccess.RunQDTbl(sql_emp);
            if (Dt_Emp.Rows.Count == 0)
            {
                MessageBox.Show("No Record","BRAVO");
                return;
            }
            //             ("select tbl_employee_mast.id,title," + 
            //"firstname,middlename,lastname,fathtitle,fathfn,fathmn,fathln,mothtitle," + 
            //"mothfn,mothmn,mothln,hustitle,husfn,husmn,husln,dateofbirth,maritalstatus," + 
            //"gender,religion,cast,weight,height, designationname,location_name,tbl_employee_jobtype.Jobtype," + 
            //"presentaddress,presentbuilding,presentstreet,presentareia,presentcity,presentpin," + 
            //"Country_name,PermanentAddress,PermanentBuilding,Permanentstreet,permanentcity," + 
            //"Country_name,Permanentareia,permanentpin,language_bengali,Language_english," + 
            //"Language_hindi,panno,passportno,pf,EsiNo,tbl_employee_mast.BankAcountno,Bank_name," + 
            //"Branch_name,Bank_Ac_Type,GMIno,tbl_employee_mast.Penssionno,dateofjoining," + 
            //"DateOfRetirement,Emarg_Name,Emarg_Address,Emarg_Tele,Emarg_mobile,name,relation_name," + 
            //"age,dependent,Ref_Name,REf_Address,Ref_Occupation,Ref_phone,Ref_Email,Emp_Service," + 
            //"Emp_Period_Service,Emp_Rank,Emp_Icard_No,Emp_Arms,Emp_Pension_no,Emp_GunLicence," + 
            //"Emp_Operation_Area,Emp_Issue,Emp_GunType,Emp_GunValid,Emp_DrivingLicence," + 
            //"tbl_employee_mast.EMPIMAGE from tbl_employee_mast,tbl_employee_familyDetails," + 
            //"company,tbl_emp_location,tbl_employee_Designationmaster,tbl_Employee_other_Reff," + 
            //"tbl_employee_jobtype,StateMASTER,country,Relation_Master where " + 
            //"tbl_employee_mast.location_id=tbl_emp_location.location_id and " +
            //"tbl_employee_mast.desgid=tbl_employee_designationmaster.slno and " + 
            //"tbl_employee_mast.jobtype=tbl_employee_jobtype.slno and state_name in " + 
            //"(select state_name from statemaster where tbl_employee_mast.presentstate=statemaster.State_code) " + 
            //"AND cOUNTRY_NAME IN(SELECT Country_name from Country,tbl_employee_mast where " + 
            //"tbl_employee_mast.presentcountry=country.country_Code)and state_name in " + 
            //"(select state_name from statemaster where tbl_employee_mast.permanentstate=statemaster.state_code) " + 
            //"and country_name in(select country_name from tbl_employee_mast,country where " + 
            //"tbl_employee_mast.permanentcountry=country.country_code) and relation_name in " + 
            //"(select Relation_name from Relation_master,tbl_employee_familyDetails where " + 
            //"relation_master.relation_code=tbl_employee_FamilyDetails.relation) and " + 
            //"tbl_employee_mast.code=Tbl_employee_FamilyDetails.slNo and " + 
            //"tbl_employee_mast.id=tbl_employee_familyDetails.id and " + 
            //"tbl_employee_mast.presentstate=statemaster.state_code and " + 
            //"tbl_employee_mast.presentcountry=country.country_code and " +
            //"tbl_employee_Other_Reff.id=tbl_employee_mast.id and tbl_employee_mast.Company_id='" +
            //Co_ID + "'and tbl_employee_mast.location_id='" + Location_ID + 
            //"'and tbl_employee_mast.id='" + Emp_ID + "'");


            int i = 0;
            if (CmbEmpId.Text != "")
            {


                string title = Dt_Emp.Rows[i]["title"].ToString();
                string firstname = Dt_Emp.Rows[i]["firstname"].ToString();
                string middlename = Dt_Emp.Rows[i]["middlename"].ToString();
                string lastname = Dt_Emp.Rows[i]["lastname"].ToString();
                string fathtitle = Dt_Emp.Rows[i]["fathtitle"].ToString();
                string fathfn = Dt_Emp.Rows[i]["fathfn"].ToString();
                string fathmn = Dt_Emp.Rows[i]["fathmn"].ToString();
                string fathln = Dt_Emp.Rows[i]["fathln"].ToString();
                string mothtitle = Dt_Emp.Rows[i]["mothtitle"].ToString();
                string mothfn = Dt_Emp.Rows[i]["mothfn"].ToString();
                string mothmn = Dt_Emp.Rows[i]["mothmn"].ToString();
                string mothln = Dt_Emp.Rows[i]["mothln"].ToString();
                string hustitle = Dt_Emp.Rows[i]["hustitle"].ToString();
                string husfn = Dt_Emp.Rows[i]["husfn"].ToString();
                string husmn = Dt_Emp.Rows[i]["husmn"].ToString();
                string husln = Dt_Emp.Rows[i]["husln"].ToString();
                DateTime dateofbirth = DateTime.Parse((Dt_Emp.Rows[i]["dateofbirth"]).ToString());
                string maritalstatus = Dt_Emp.Rows[i]["maritalstatus"].ToString();
                string gender = Dt_Emp.Rows[i]["gender"].ToString();
                string religion = Dt_Emp.Rows[i]["religion"].ToString();
                string cast = Dt_Emp.Rows[i]["cast"].ToString();
                string weight = Dt_Emp.Rows[i]["weight"].ToString();
                string height = Dt_Emp.Rows[i]["height"].ToString().Replace("~", "'");

                string company = CO_NAM;
                string designation = clsDataAccess.GetresultS("Select isNull([DesignationName],'') from [tbl_Employee_DesignationMaster] where ([SlNo]=" + Dt_Emp.Rows[i]["DesgId"].ToString() + ")");
                string location = clsDataAccess.GetresultS("Select isNull([Location_Name],'') from [tbl_Emp_Location] where ([Location_ID]=" + Dt_Emp.Rows[i]["Location_id"].ToString() + ")");
                string jobtype = Dt_Emp.Rows[i]["jobtype"].ToString();
                string present_Address = Dt_Emp.Rows[i]["tel"].ToString();
                string Present_Building = Dt_Emp.Rows[i]["presentbuilding"].ToString();
                string Present_street = Dt_Emp.Rows[i]["presentstreet"].ToString();
                string Present_Area = Dt_Emp.Rows[i]["presentareia"].ToString();
                string Present_pin = Dt_Emp.Rows[i]["presentpin"].ToString();
                string presentcity = Dt_Emp.Rows[i]["presentcity"].ToString();
                DataTable presentdt = clsDataAccess.RunQDTbl("select state_name,Country_name from country,statemaster,tbl_employee_mast where presentstate=state_code and presentcountry=country.Country_code and ID = '" + Emp_ID + "'");
                string present_state = "", Present_Country = "";
                if (presentdt.Rows.Count > 0)
                {
                    present_state = presentdt.Rows[0]["state_name"].ToString();
                    Present_Country = presentdt.Rows[0]["Country_name"].ToString();
                }
                string Present_City = Dt_Emp.Rows[i]["presentcity"].ToString();
                //string Present_Country = presentdt.Rows[0]["Country_name"].ToString();
                string Permanent_Building = Dt_Emp.Rows[i]["permanentBuilding"].ToString();
                string Permanent_Street = Dt_Emp.Rows[i]["PermanentStreet"].ToString();
                string Permanent_Area = Dt_Emp.Rows[i]["PermanentAreia"].ToString();
                string permanent_City = Dt_Emp.Rows[i]["PermanentCity"].ToString();
                string permanent_pin = Dt_Emp.Rows[i]["PermanentPin"].ToString();
                string perManent_address = Dt_Emp.Rows[i]["mobile"].ToString();
                string Permanent_country = "", Permanent_state = "";
                DataTable permadt = clsDataAccess.RunQDTbl("select state_name,Country_name from statemaster,country,tbl_employee_mast where state_code=permanentstate and country.country_code=Permanentcountry and ID = '" + Emp_ID + "'");
                if (permadt.Rows.Count > 0)
                {
                    Permanent_country = permadt.Rows[0]["Country_Name"].ToString();
                    Permanent_state = permadt.Rows[0]["State_name"].ToString();
                }
                string output_bengali = Dt_Emp.Rows[i]["language_Bengali"].ToString();
                string language_bengali = "";

                string[] lang = clsDataAccess.EMPLang().Split('|');
                    //clsDataAccess.Emp_lang().Split('|');




                if (output_bengali != "0,0,0")
                {
                    language_bengali = lang[0].ToString(); //"Bengali";
                }
                string Output_english = Dt_Emp.Rows[i]["Language_English"].ToString();
                string language_English = "";
                if (Output_english != "0,0,0")
                {
                    language_English = lang[1].ToString(); //"English";
                }
                string OutPut_Hindi = Dt_Emp.Rows[i]["Language_Hindi"].ToString();
                string Language_Hindi = "";
                if (OutPut_Hindi != "0,0,0")
                {
                    Language_Hindi = lang[2].ToString(); //"Hindi";
                }
                string panno = Dt_Emp.Rows[i]["panno"].ToString();
                string passportno = Dt_Emp.Rows[i]["passportno"].ToString();
                string Pf_ACC_No = Dt_Emp.Rows[i]["pf"].ToString();
                string ESI_ACC_NO = Dt_Emp.Rows[i]["esino"].ToString();
                string BankAccountNo = Dt_Emp.Rows[i]["BankAcountNO"].ToString();
                string bank_name = Dt_Emp.Rows[i]["Bank_name"].ToString();
                string Branch_name = Dt_Emp.Rows[i]["Branch_name"].ToString();
                string acc_Type = Dt_Emp.Rows[i]["Bank_AC_Type"].ToString();
                string IFSC = Dt_Emp.Rows[i]["GMINo"].ToString();
                string pensionno = Dt_Emp.Rows[i]["penssionno"].ToString();
                DateTime dateofjoining = DateTime.Parse(Dt_Emp.Rows[i]["dateofjoining"].ToString());
                DateTime dateofretirement = DateTime.Parse(Dt_Emp.Rows[i]["DateOfRetirement"].ToString());
                string Emerg_name = Dt_Emp.Rows[i]["emarg_name"].ToString();
                string Emerg_Address = Dt_Emp.Rows[i]["Emarg_Address"].ToString();
                string Emerg_Tele = Dt_Emp.Rows[i]["Emarg_Tele"].ToString();
                string emerg_Mobile = Dt_Emp.Rows[i]["Emarg_Mobile"].ToString();


                string Family_name = "";//Dt_Emp.Rows[i]["name"].ToString();

                string Relation = "";//Dt_Emp.Rows[i]["relation_name"].ToString();
                int age = 0;//int.Parse(Dt_Emp.Rows[i]["age"].ToString());
                string dependent = "";// Dt_Emp.Rows[i]["dependent"].ToString();
                string ref_name = Dt_Emp.Rows[i]["Ref_name"].ToString();
                string Ref_Address = Dt_Emp.Rows[i]["Ref_Address"].ToString();
                string Ref_Occupation = Dt_Emp.Rows[i]["Ref_Occupation"].ToString();
                string Ref_Phone = Dt_Emp.Rows[i]["Ref_Phone"].ToString();
                string Ref_Email = Dt_Emp.Rows[i]["Ref_Email"].ToString();
                string ServiceNo = Dt_Emp.Rows[i]["Emp_Service"].ToString();
                string PeriodOfService = Dt_Emp.Rows[i]["Emp_Period_Service"].ToString();
                string Rank = Dt_Emp.Rows[i]["Emp_Rank"].ToString();
                string Identity_Card_No = Dt_Emp.Rows[i]["Emp_Icard_No"].ToString();
                string ArmsService = Dt_Emp.Rows[i]["Emp_Arms"].ToString();
                string PensionNo = Dt_Emp.Rows[i]["Emp_Pension_no"].ToString();
                string GunLicenceNO = Dt_Emp.Rows[i]["Emp_GunLicence"].ToString();
                string Operation_Area = Dt_Emp.Rows[i]["Emp_Operation_Area"].ToString();
                string Issuing_Authority = Dt_Emp.Rows[i]["Emp_Issue"].ToString();
                string GunType = Dt_Emp.Rows[i]["Emp_Guntype"].ToString();
                string valid = (Dt_Emp.Rows[i]["Emp_GunValid"].ToString());
                string driverLicenceNo = Dt_Emp.Rows[i]["Emp_DrivingLicence"].ToString();
                string empid = Dt_Emp.Rows[i]["id"].ToString();
                string aadhar = Dt_Emp.Rows[i]["aadhar"].ToString();

                //string lT = Dt_Emp.Rows[i]["lThumb"].ToString();
                //string rT = Dt_Emp.Rows[i]["rThumb"].ToString();
                //string lI = Dt_Emp.Rows[i]["lIndex"].ToString();
                //string rI = Dt_Emp.Rows[i]["rIndex"].ToString();
                //string lM = Dt_Emp.Rows[i]["lMiddle"].ToString();
                //string rM= Dt_Emp.Rows[i]["rMiddle"].ToString();
                //string lR = Dt_Emp.Rows[i]["lRing"].ToString();
                //string rR = Dt_Emp.Rows[i]["rRing"].ToString();
                //string lF = Dt_Emp.Rows[i]["lfourth"].ToString();
                //string rF = Dt_Emp.Rows[i]["rfourth"].ToString();
                //string sign = Dt_Emp.Rows[i]["sign"].ToString();

                //byte image = byte.Parse(Dt_Emp.Rows[i]["EmpImage"].ToString());
                // byte empimage = byte.Parse(Dt_Emp.Rows[i]["empimage"].ToString());


                MidasReport.Form1 emp = new MidasReport.Form1();


                dtquali = clsDataAccess.RunQDTbl("select (SELECT Quali_Name FROM Qualification_Master where Quali_Code=eq.qualification)'Qualification',university,YearOfPassing,Percentage from tbl_employee_qualificationdetails eq where (eq.ID='"+ Emp_ID +"')");
                dtfamily = clsDataAccess.RunQDTbl("SELECT ef.Name,(SELECT Relation_Name FROM Relation_Master where relation_code=ef.Relation)as Relation, ef.Age, ef.[Dependent],ef.dob,ef.aadhar FROM tbl_Employee_FamilyDetails AS ef WHERE (Relation <> '-' OR Relation = '') AND (ID ='" + Emp_ID + "')");
                DataTable dtimage = new DataTable();

                if (chk_ti_sign.Checked == true)
                {
                    dtimage = clsDataAccess.RunQDTbl("select em.empimage ,f.lThumb,f.rThumb,f.lIndex,f.rIndex,f.lMiddle,f.rMiddle,f.lRing,f.rRing,f.lfourth,f.rfourth,f.sign,f.lFace," +
   "f.rFace from tbl_employee_mast em ,tbl_employee_fscan  f where em.ID=f.ID AND em.ID='" + Emp_ID + "' ");
                }
                else
                {
                    dtimage = clsDataAccess.RunQDTbl("select em.empimage,f.sign  from tbl_employee_mast em,tbl_employee_fscan f where em.ID=f.ID AND em.ID='" + Emp_ID + "' ");
                }
                //where id='" + CmbEmpId.Text + "'");
                //ds.Tables.Add(dt);
                ds.Tables.Add(dtimage);                
                ds.Tables.Add(dtfamily);
                ds.Tables.Add(dtquali);
                //ds.Tables[0].TableName = "empj";
               
                ds.Tables[0].TableName = "tbl_employee_mast";
                ds.Tables[1].TableName = "Family";
                ds.Tables[2].TableName = "quali1";

                //ds.Tables[2].TableName = "tbl_employee_mast";
                emp.empjoining(title, firstname, middlename, lastname, fathtitle, fathfn, fathmn, fathln, mothtitle, mothfn, mothmn, mothln, hustitle, husfn, husmn, husln, dateofbirth, maritalstatus, gender, religion, cast, weight, height, designation, company, location, jobtype, present_Address, Present_Building, Present_street, Present_Area, Present_City, Present_pin, Present_Country, present_state, perManent_address, Permanent_Building, Permanent_Street, Permanent_Area, permanent_City, Permanent_state, Permanent_country, permanent_pin, language_bengali, language_English, Language_Hindi, panno, Pf_ACC_No, ESI_ACC_NO, BankAccountNo, bank_name, Branch_name, acc_Type, IFSC, pensionno, dateofjoining, dateofretirement, Emerg_name, Emerg_Address, Emerg_Tele, emerg_Mobile, Family_name, Relation, age, dependent, ref_name, Ref_Address, Ref_Occupation, Ref_Phone, Ref_Email, ServiceNo, PeriodOfService, Rank, Identity_Card_No, ArmsService, pensionno, GunLicenceNO, Operation_Area, Issuing_Authority, GunType, valid, driverLicenceNo, empid, passportno, ds,aadhar);


                edpcon.Close();
                emp.ShowDialog();

                ds.Tables[2].Clear();
                dtimage.Dispose();
                emp.Dispose();
                //if (dtimage.Rows.Count > 0)
                //{
                //EmpBio_Icard frm_ej = new EmpBio_Icard();

                //frm_ej.CmbCompany.Text = CO_NAM;
                //frm_ej.Co_ID = this.Co_ID;
                //frm_ej.cmbLocation.Text = location;
                //frm_ej.Location_ID = this.Location_ID;

                //this.DestroyHandle();
                //frm_ej.ShowDialog();
                //}
            }
            else
            {
                MessageBox.Show("Please select empid");
            }

            // }

        }


        //private void CmbEmpId_Enter(object sender, EventArgs e)
        //{

        //    DataTable dtempid = clsDataAccess.RunQDTbl("select id from tbl_employee_Mast,company,tbl_emp_location where CO_name='" + CmbCompany.Text + "'and location_name='" + cmbLocation.Text + "'and tbl_emp_location.location_Id=tbl_employee_mast.Location_id");


        //        for (int i = 0; i < dtempid.Rows.Count; i++)
        //        {
        //            CmbEmpId.Items.Add(dtempid.Rows[i]["id"].ToString());
        //        }


        //}



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


            //if (dt.Rows.Count > 0)
            //{
            //    CmbCompany.LookUpTable = dt;
            //    CmbCompany.ReturnIndex = 1;
            //}

            if (dt.Rows.Count == 1)
            {
                CmbCompany.Text = dt.Rows[0][0].ToString();

                Co_ID = Convert.ToInt32(dt.Rows[0][1].ToString());
                CmbCompany.ReturnValue = Co_ID.ToString();
                CmbCompany.Enabled = false;

                try
                {
                    dt_co = clsDataAccess.RunQDTbl("SELECT BRNCH_NAME, BRNCH_ADD1, BRNCH_ADD2, BRNCH_CITY, BRNCH_STATE, BRNCH_PIN,BRNCH_TELE1,BRNCH_TELE2,BRNCH_TELE3,CONTACT_PERSON,website,COUNTRY, Cmpimage,GCODE FROM Branch where GCODE=" + Co_ID);
                    if (dt_co.Rows.Count > 0)
                    {
                        //                  {"1. Emergency Contact :
                        //9836616271, 9674194221
                        txt_eContact.Text = dt_co.Rows[0]["BRNCH_TELE1"].ToString();
                        txtOther.Text = "2. This card is non-transferrable and must be displayed on duty" + Environment.NewLine +
                            "3. Loss of card must be reported immediately" + Environment.NewLine +
                            "4. This card is to be surrendered on leaving service" + Environment.NewLine +
                            "5. This card is the property of M/s. " + CmbCompany.Text + ". ";


                        txtfound.Text = "If Found." + Environment.NewLine +
                            "Please return to us immediately at :-" + Environment.NewLine +
                            dt_co.Rows[0]["BRNCH_ADD1"].ToString();
                        lblWebsite.Text = dt_co.Rows[0]["website"].ToString();
                    }

                }catch
                {                }

            }
            else if (dt.Rows.Count > 1)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            //Extractcmd.Visible = true;
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                Co_ID = Convert.ToInt32(CmbCompany.ReturnValue);


            try
            {

                dt_co = clsDataAccess.RunQDTbl("SELECT BRNCH_NAME, BRNCH_ADD1, BRNCH_ADD2, BRNCH_CITY, BRNCH_STATE,website, BRNCH_PIN,BRNCH_TELE1,BRNCH_TELE2,BRNCH_TELE3,CONTACT_PERSON,COUNTRY, Cmpimage,GCODE FROM Branch where GCODE=" + Co_ID);
                if (dt_co.Rows.Count > 0)
                {
                    //                  {"1. Emergency Contact :
                    //9836616271, 9674194221
                    txt_eContact.Text = dt_co.Rows[0]["BRNCH_TELE1"].ToString();
                    txtOther.Text = "2. This card is non-transferrable and must be displayed on duty" + Environment.NewLine +
                        "3. Loss of card must be reported immediately" + Environment.NewLine +
                        "4. This card is to be surrendered on leaving service" + Environment.NewLine +
                        "5. This card is the property of M/s. " + CmbCompany.Text + ". ";
                       


                    txtfound.Text = "If Found." + Environment.NewLine +
                        "Please return to us immediately at :-" + Environment.NewLine +
                        dt_co.Rows[0]["BRNCH_ADD1"].ToString();
                    lblWebsite.Text = dt_co.Rows[0]["website"].ToString();
                }

            }
            catch
            {
            }
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("SELECT DISTINCT EL.Location_Name,EL.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName FROM tbl_Employee_Mast EM INNER JOIN tbl_Emp_Location EL ON EM.Location_id = EL.Location_ID WHERE  (EM.Company_id =" + Co_ID + ") ORDER BY EL.Location_ID");
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

        private void CmbEmpId_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

            DataTable dt = new DataTable();
            if (Location_ID != 0)
            {
                dt = clsDataAccess.RunQDTbl("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName, ID FROM tbl_Employee_Mast em WHERE (Company_id = " +
                     Co_ID + ") AND (Location_id = " + Location_ID + ") ORDER BY ID");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName , ID FROM tbl_Employee_Mast em WHERE (Company_id = " +
                        Co_ID + ") ORDER BY ID");

            }
            if (dt.Rows.Count > 0)
            {
                CmbEmpId.LookUpTable = dt;
                CmbEmpId.ReturnIndex = 1;
            }
        }

        private void CmbEmpId_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            // if (Information.IsNumeric(CmbEmpId.ReturnValue) == true)
            Emp_ID = CmbEmpId.ReturnValue.ToString();
            emp_id = CmbEmpId.ReturnValue.ToString();
            string sql_emp = "SELECT [issuedate],[valid],[identity],[econtact],[other] FROM tbl_Employee_Mast AS em WHERE (em.id='" + Emp_ID + "')";
            DataTable Dt_Emp = clsDataAccess.RunQDTbl(sql_emp);

            if (Dt_Emp.Rows.Count > 0)
            {

                if (Dt_Emp.Rows[0]["econtact"].ToString().Trim() != "")
                {
                    txt_eContact.Text = Dt_Emp.Rows[0]["econtact"].ToString().Trim();
                }

                if (Dt_Emp.Rows[0]["other"].ToString().Trim() != "")
                {
                    txtOther.Text = Dt_Emp.Rows[0]["other"].ToString().Trim();
                }

                txt_eidentityMark.Text = Dt_Emp.Rows[0]["identity"].ToString().Trim();

                if (Dt_Emp.Rows[0]["issuedate"].ToString().Trim() != "")
                {
                    dtpDOI.Value = Convert.ToDateTime(Dt_Emp.Rows[0]["issuedate"].ToString().Trim());
                }

                if (Dt_Emp.Rows[0]["valid"].ToString().Trim() != "")
                {
                    dtp_DOV.Value = Convert.ToDateTime(Dt_Emp.Rows[0]["valid"].ToString().Trim());
                }

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnicard_prev_Click(object sender, EventArgs e)
        {

            int ty = 0;

            string sql_emp = "", other = "", sign = "";
            DataTable Dt_Emp = new DataTable();

            if (rdb_sign.Checked == true)
            {
                sign = "sign";
            }
            else if (rdb_sign2.Checked == true)
            {
                sign = "sign2";
            }
            else
            {
                sign = "'' as sign";

            }
            if (rdbType1.Checked == true)
            {
                other = txtOther.Text.Trim() + Environment.NewLine + "" + Environment.NewLine + txtfound.Text.Trim().Replace("'", "''");
            }
            else
            {
                other = txtOther.Text.Trim();
            }


            if (rdb_ic_selective.Checked == true)
            {


                sql_emp = "SELECT '" + CmbCompany.Text + "' as coname,'" + lblWebsite.Text + "' as website,"+
       "em.ID as eregno,em.Permanentstreet,em.Permanentcity,em.Permanentpin,cast(convert(char(11), em.DateOfBirth, 103) as VARCHAR) as DateOfBirth, em.BlGrp,cast(convert(char(11), em.DateOfJoining, 103) as VARCHAR) as DateOfJoining,em.Gender," +
       "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
       "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
       "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename," +
       "(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=em.Desgid))as edesg," +
       "'" + dtpDOI.Value.ToString("dd/MM/yyyy") + "' as [issuedate],'" + dtp_DOV.Value.ToString("dd/MM/yyyy") + "' as [validupto],'" +
       txt_eidentityMark.Text.Trim() + "' as [identitymark],'" + txt_eContact.Text.Trim() + "' as [econtact],'" + other + "' as [others],'" +
       txtfound.Text.Trim().Replace("'", "''") + "'as [ifFound],(select distinct(Cmpimage) from Branch where GCODE=" + Co_ID +
       ") as coimg, Empimage as eimg,(select " + sign + " from Company where GCODE='" + Co_ID + "') as authsign,(select sign from tbl_employee_fscan where ID=em.ID)as empsign" +
       " FROM tbl_Employee_Mast AS em WHERE (em.id in (" + Emp_ID + "))";


                Dt_Emp = clsDataAccess.RunQDTbl(sql_emp);


                sql_emp = "update tbl_Employee_Mast set [issuedate]='" + dtpDOI.Value.ToString("dd/MMM/yyyy") + "'," +
                          "[valid]='" + dtp_DOV.Value.ToString("dd/MMM/yyyy") + "',[identity]='" + txt_eidentityMark.Text.Trim() +
                          "',[econtact]='" + txt_eContact.Text.Trim() + "',[other]='" + txtOther.Text.Trim() + "',[ifFound]='" + txtfound.Text.Trim().Replace("'", "''") + "' where (id in (" + Emp_ID + ")) ";
                clsDataAccess.RunNQwithStatus(sql_emp);
            }


            if (rdb_ic_emp.Checked == true)
            {
                if (CmbEmpId.ReturnValue.Trim() == "")
                {
                    MessageBox.Show("Please select Employee", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                sql_emp = "SELECT '" + CmbCompany.Text + "' as coname,'" + lblWebsite.Text + "' as website,em.ID as eregno,"+
                    "em.Permanentstreet,em.Permanentcity,em.Permanentpin,cast(convert(char(11), em.DateOfBirth, 103) as VARCHAR) as DateOfBirth,em.BlGrp,cast(convert(char(11), em.DateOfJoining, 103) as VARCHAR) as DateOfJoining,em.Gender," +
        "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
        "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
        "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename," +
        "(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=em.Desgid))as edesg," +
        "'" + dtpDOI.Value.ToString("dd/MM/yyyy") + "' as [issuedate],'" + dtp_DOV.Value.ToString("dd/MM/yyyy") + "' as [validupto],'" +
        txt_eidentityMark.Text.Trim() + "' as [identitymark],'" + txt_eContact.Text.Trim() + "' as [econtact],'" + other + "' as [others],'" +
        txtfound.Text.Trim().Replace("'", "''") + "'as [ifFound],(select distinct(Cmpimage) from Branch where GCODE=" + Co_ID +
        ") as coimg, Empimage as eimg,(select " + sign + " from Company where GCODE='" + Co_ID + "') as authsign,(select sign from tbl_employee_fscan where ID=em.ID)as empsign" +
        " FROM tbl_Employee_Mast AS em WHERE (em.id='" + Emp_ID + "')";

               
                Dt_Emp = clsDataAccess.RunQDTbl(sql_emp);


                sql_emp = "update tbl_Employee_Mast set [issuedate]='" + dtpDOI.Value.ToString("dd/MMM/yyyy") + "'," +
                          "[valid]='" + dtp_DOV.Value.ToString("dd/MMM/yyyy") + "',[identity]='" + txt_eidentityMark.Text.Trim() +
                          "',[econtact]='" + txt_eContact.Text.Trim() + "',[other]='" + txtOther.Text.Trim() + "',[ifFound]='" + txtfound.Text.Trim().Replace("'", "''") + "' where (id='" + Emp_ID + "') ";
                clsDataAccess.RunNQwithStatus(sql_emp);
            }

            if (rdb_ic_loc.Checked == true)
            {
                sql_emp = "SELECT '" + CmbCompany.Text + "' as coname,'" + lblWebsite.Text + "' as website,em.Permanentstreet,"+
                    "em.Permanentcity,em.Permanentpin,em.BlGrp,em.ID as eregno,em.DateOfBirth,cast(convert(char(11), em.DateOfBirth, 103) as VARCHAR) as DateOfBirth,cast(convert(char(11), em.DateOfJoining, 103) as VARCHAR) as DateOfJoining,em.Gender," +
              "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
              "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
              "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename," +
              "(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=em.Desgid))as edesg," +
              "'" + dtpDOI.Value.ToString("dd/MM/yyyy") + "' as [issuedate],'" + dtp_DOV.Value.ToString("dd/MM/yyyy") + "' as [validupto],'" +
              txt_eidentityMark.Text.Trim() + "' as [identitymark],'" + txt_eContact.Text.Trim() + "' as [econtact],'" + other + "' as [others],'" +
              txtfound.Text.Trim().Replace("'", "''") + "'as [ifFound],(select distinct(Cmpimage) from Branch where GCODE=" + dt_co.Rows[0]["GCODE"].ToString() +
              ") as coimg, Empimage as eimg,(select " + sign + " from Company where GCODE='" + dt_co.Rows[0]["GCODE"].ToString() + "') as authsign,(select sign from tbl_employee_fscan where ID=em.ID)as empsign" +
              " FROM tbl_Employee_Mast AS em WHERE (em.Location_id='" + Location_ID + "')";
                Dt_Emp = clsDataAccess.RunQDTbl(sql_emp);


                sql_emp = "update tbl_Employee_Mast set [issuedate]='" + dtpDOI.Value.ToString("dd/MMM/yyyy") + "'," +
                          "[valid]='" + dtp_DOV.Value.ToString("dd/MMM/yyyy") + "',[econtact]='" + txt_eContact.Text.Trim() +
                          "',[other]='" + txtOther.Text.Trim() + "',[ifFound]='" + txtfound.Text.Trim() + "' where ( Location_id='" + Location_ID + "') ";
                clsDataAccess.RunNQwithStatus(sql_emp);
            }
            if (rdb_ic_co.Checked == true)
            {
                sql_emp = "SELECT '" + CmbCompany.Text + "' as coname,'" + lblWebsite.Text + "' as website,em.Permanentstreet,"+
                    "em.Permanentcity,em.Permanentpin,em.BlGrp,em.ID as eregno,cast(convert(char(11), em.DateOfBirth, 103) as VARCHAR) as DateOfBirth,cast(convert(char(11), em.DateOfJoining, 103) as VARCHAR) as DateOfJoining,em.Gender," +
              "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
              "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
              "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename," +
              "(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=em.Desgid))as edesg," +
              "'" + dtpDOI.Value.ToString("dd/MM/yyyy") + "' as [issuedate],'" + dtp_DOV.Value.ToString("dd/MM/yyyy") + "' as [validupto],'" +
              txt_eidentityMark.Text.Trim() + "' as [identitymark],'" + txt_eContact.Text.Trim() + "' as [econtact],'" + txtOther.Text.Trim() +
              "' as [others],'" + txtfound.Text.Trim().Replace("'", "''") + "'as [ifFound],(select distinct(Cmpimage) from Branch where GCODE=" +
              dt_co.Rows[0]["GCODE"].ToString() + ") as coimg, Empimage as eimg,(select " + sign + " from Company where GCODE='" + dt_co.Rows[0]["GCODE"].ToString() + "') as authsign,(select sign from tbl_employee_fscan where ID=em.ID)as empsign" +
              " FROM tbl_Employee_Mast AS em WHERE (em.id='" + Co_ID + "')";
                Dt_Emp = clsDataAccess.RunQDTbl(sql_emp);


                sql_emp = "update tbl_Employee_Mast set [issuedate]='" + dtpDOI.Value.ToString("dd/MMM/yyyy") + "'," +
                          "[valid]='" + dtp_DOV.Value.ToString("dd/MMM/yyyy") + "',[identity]='" + txt_eidentityMark.Text.Trim() +
                          "',[econtact]='" + txt_eContact.Text.Trim() + "',[other]='" + txtOther.Text.Trim() + "',[ifFound]='" + txtfound.Text.Trim() + "' where (id='" + Emp_ID + "') ";
                clsDataAccess.RunNQwithStatus(sql_emp);
            }
            if (rdbType1B.Checked == true)
            {
                sql_emp = "select  CO_ADD  + CHAR(13) + (select distinct (case when b.BRNCH_TELE1='' then '' else 'Tel: '+ b.BRNCH_TELE1 end ) 'Tel'  from Branch b where b.GCODE=c.CO_CODE ) + (select distinct (case when b.Email='' then '' else '  Email: '+ b.Email end ) 'email' from Branch b where b.GCODE=c.CO_CODE ) as 'cdet' from Company C where (CO_CODE='" + Co_ID + "')";

            }
            else
            {
                sql_emp = "select  CO_ADD from Company C where (CO_CODE='" + Co_ID + "')";
            }
            cadd = clsDataAccess.GetresultS(sql_emp);
            MidasReport.Form1 frm1 = new MidasReport.Form1();
            if (rdbType1.Checked == true)
            {
                ty = 1;
            }
            else if (rdbType2.Checked == true)
            {
                ty = 2;
            }
            else if (rdbType3.Checked == true)
            {
                ty = 3;
            }
            else if (rdbType1B.Checked == true)
            {
                ty = 4;
            }
            frm1.show_icard(Dt_Emp, ty,cadd);
            frm1.ShowDialog();

        }

        private void rdbType2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbType2.Checked == true)
            {
                txt_eidentityMark.Enabled = false;
            }
            else if (rdbType1.Checked == true)
            {
                txt_eidentityMark.Enabled = true;
            }
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            DataTable dt_emp = new DataTable();
            DataTable dt_equali = new DataTable();
            //dt_emp.Columns.Add("eid",)
            //  <DesignColumnRef Name="ename" />
            //  <DesignColumnRef Name="fname" />
            //  <DesignColumnRef Name="preadd" />
            //  <DesignColumnRef Name="peradd" />
            //  <DesignColumnRef Name="dob" />
            //  <DesignColumnRef Name="status" />
            //  <DesignColumnRef Name="height" />
            //  <DesignColumnRef Name="weight" />
            //  <DesignColumnRef Name="chest" />
            //  <DesignColumnRef Name="haircolor" />
            //  <DesignColumnRef Name="eyecolor" />
            //  <DesignColumnRef Name="complexion" />
            //  <DesignColumnRef Name="idmark" />
            //  <DesignColumnRef Name="lang" />
            //  <DesignColumnRef Name="aadhar" />
            //  <DesignColumnRef Name="pan" />
            //  <DesignColumnRef Name="eimg" />
            //  <DesignColumnRef Name="qualification" />
            //  <DesignColumnRef Name="institute" />
            //  <DesignColumnRef Name="passyr" />
            //  <DesignColumnRef Name="marks" />
            string cond = "", sign="";
            if (rdb_sign.Checked == true)
            {
                sign = "[sign]";
            }
            else if (rdb_sign2.Checked == true)
            {
                sign = "[sign2]";
            }
            else
            {
                sign = "'' as sign";

            }
            if (rdb_ic_emp.Checked == true)
            {
                if (CmbEmpId.ReturnValue.Trim() == "")
                {
                    MessageBox.Show("Please select Employee", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                cond = " where (ID='" + Emp_ID + "')";
            }
            if (rdb_ic_loc.Checked == true)
            {

                cond = " where (Location_id='" + Location_ID + "')";
            }
            else if (rdb_ic_selective.Checked == true)
            {

                cond = " where (ID in (" + Emp_ID + "))";
            }
            string qualification = "", inst = "", qyr = "", qper = "";

            string qry = "SELECT ID as eid,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
            "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
            "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename," +
            "(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=em.Desgid))as edesg," +
            "((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN ltrim(rtrim(em.FathFN)) + ' ' ELSE '' END)+" +
            "(CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN ltrim(rtrim(em.FathMN)) + ' ' ELSE '' END) +" +
            "(CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN ltrim(rtrim(em.FathLN)) + ' ' ELSE '' END)) as fname," +
            "cast(convert(char(11), DateOfBirth, 103) as VARCHAR) as dob,cast(convert(char(11), DateOfJoining, 103) as VARCHAR) as doj, MaritalStatus as status, DesgId,JobType,PANno,aadhar,Empimage as eimg," +
            "(Presentstreet +'\n\r'+ Presentcity +' PIN - '+ Presentpin +'\n\r'+ (select upper(state_name) from statemaster where em.presentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.presentcountry=country_Code)) as preadd, Presentcountry," +
            "(Permanentstreet +'\n\r'+ Permanentcity +' PIN - '+ Permanentpin +'\n\r'+ (select upper(state_name) from statemaster where em.Permanentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.Permanentcountry=country_Code))as peradd ,Permanentcountry," +
            "Weight,Height,Language_Bengali,Language_Hindi,Language_English,Location_id,Company_id,chest,complexion,haircolor,eyecolor,blgrp,Gender,Religion,(Select isNull([DesignationName],'') from [tbl_Employee_DesignationMaster] where ([SlNo]=em.DesgId)) as desg,(select " + sign + " from Company where GCODE='" + Co_ID + "') as authsign,(select sign from tbl_employee_fscan where ID=em.ID)as empsign," +
            "'' as qualification,''as institute,''as passyr,''as marks,''as lang,STR(mobile) as contact FROM tbl_Employee_Mast as em " + cond;
            dt_emp = clsDataAccess.RunQDTbl(qry);
            for (int ind = 0; ind < dt_emp.Rows.Count; ind++)
            {
                string output_bengali = dt_emp.Rows[ind]["language_Bengali"].ToString();
                string language_bengali = "";

                string[] lang = clsDataAccess.Emp_lang().Split('|');

                if (output_bengali != "0,0,0")
                {
                    language_bengali = lang[0].ToString() + ","; //"Bengali";
                }
                string Output_english = dt_emp.Rows[ind]["Language_English"].ToString();
                string language_English = "";
                if (Output_english != "0,0,0")
                {
                    language_English = lang[1].ToString() + ","; //"English";
                }
                string OutPut_Hindi = dt_emp.Rows[ind]["Language_Hindi"].ToString();
                string Language_Hindi = "";
                if (OutPut_Hindi != "0,0,0")
                {
                    Language_Hindi = lang[2].ToString(); //"Hindi";
                }
                dt_equali = clsDataAccess.RunQDTbl("select quali_name,university,yearofpassing,percentage from qualification_master,tbl_employee_qualificationdetails,tbl_employee_mast where tbl_employee_qualificationdetails.id=tbl_employee_mast.id and tbl_Employee_qualificationDetails.qualification=qualification_master.Quali_code and (tbl_employee_mast.id='" + dt_emp.Rows[ind]["eID"].ToString() + "')");
                qualification = ""; inst = ""; qyr = ""; qper = "";
                for (int id = 0; id < dt_equali.Rows.Count; id++)
                {
                    if (qualification == "")
                    {
                        qualification = dt_equali.Rows[id]["quali_name"].ToString().Trim();
                        inst = dt_equali.Rows[id]["university"].ToString().Trim();
                        qyr = dt_equali.Rows[id]["yearofpassing"].ToString().Trim();
                        qper = dt_equali.Rows[id]["percentage"].ToString().Trim();
                    }
                    else
                    {
                        qualification = qualification + Environment.NewLine + dt_equali.Rows[id]["quali_name"].ToString().Trim();
                        inst = inst + Environment.NewLine + dt_equali.Rows[id]["university"].ToString().Trim();
                        qyr = qyr + Environment.NewLine + dt_equali.Rows[id]["yearofpassing"].ToString().Trim();
                        qper = qper + Environment.NewLine + dt_equali.Rows[id]["percentage"].ToString().Trim();
                    }
                }
                dt_emp.Rows[ind]["Height"] = dt_emp.Rows[ind]["Height"].ToString().Replace("~", "'");
                dt_emp.Rows[ind]["lang"] = language_bengali + language_English + Language_Hindi;
                dt_emp.Rows[ind]["qualification"] = qualification;
                dt_emp.Rows[ind]["institute"] = inst;
                dt_emp.Rows[ind]["passyr"] = qyr;
                dt_emp.Rows[ind]["marks"] = qper;




            }

            MidasReport.Form1 frm1 = new MidasReport.Form1();
            if (clsDataAccess.ReturnValue("Select pinfo from CompanyLimiter") == "1")
            {
                frm1.show_hist1(dt_emp);
            }
            else
            {
                frm1.show_hist(dt_emp);
            }
            frm1.ShowDialog();
        }

        private void rdbType1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdb_ic_emp_CheckedChanged(object sender, EventArgs e)
        {
            CmbEmpId.Visible = true;
            btnclient.Visible = false;
            emp_id = "";
            CmbEmpId.Text = "";
            BtnDisp_Bio.Visible = true;
            if (rdb_ic_selective.Checked == true)
            {
                BtnDisp_Bio.Visible = false;
                CmbEmpId.Visible = false; btnclient.Visible = true;
                btnVerifyLetter.Enabled = true;
            }
            else if (rdb_ic_emp.Checked == true)
            {
                btnVerifyLetter.Enabled = true;
            }
            else
            {
                btnVerifyLetter.Enabled = false;
            }
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
           // string emp_id;
            try
            {


                string sqlstmnt = "SELECT Client_Name AS ClientName, Client_id AS ID, coid AS ID1  FROM tbl_Employee_CliantMaster";

                if (Location_ID != 0)
                {
                    sqlstmnt = ("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
              "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName, ID,Location_id FROM tbl_Employee_Mast em WHERE (Company_id = " +
                         Co_ID + ") AND (Location_id = " + Location_ID + ") ORDER BY ID,Location_id ");
                }
                else
                {
                    sqlstmnt = ("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
              "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName , ID,Company_id FROM tbl_Employee_Mast em WHERE (Company_id = " +
                            Co_ID + ") ORDER BY ID,Company_id");

                }

                EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Client", "Select Client", 0, "CMPN", 0);

                arritem.Clear();
                arritem = EDPCommon.arr_mod;

                if (arritem.Count > 0)
                {
                    getcode_item.Clear();
                    arritem = EDPCommon.arr_mod;
                    getcode_item = EDPCommon.get_code;
                    //lblproduct.Items.Clear();
                    emp_id = "";
                    //for (int i = 0; i <= (arritem.Count - 1); i++)
                    //{
                    //    //lblproduct.Items.Add(arritem[i].ToString());
                    //    Item_Code = Item_Code + getcode_item[i].ToString();
                    //    if (i != getcode_item.Count - 1)
                    //    {
                    //        Item_Code = "'" + Item_Code + "'" + "," + "'";
                    //    }
                    //}



                    for (int i = 0; i <= arritem.Count - 1; i++)
                    {
                        if (emp_id == "")
                        {
                            emp_id = "'" + getcode_item[i].ToString() + "'";
                        }
                        else
                        {
                            emp_id = emp_id + ",'" + getcode_item[i].ToString() + "'";
                        }

                    }

                    Emp_ID = emp_id;


                }


            }
            catch { }
        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {

            Retrieve_Data();

            //Calling the Crystal Report viewer page 
            MidasReport.Form1 verify = new MidasReport.Form1();
            // Passing records to print page
            if (chkVerification_Type.Checked==true)
            {
            verify.VerifyLetter(dvl_table);
            }
            else{
                verify.VerifyLetter_2(dvl_table);
            }

            verify.ShowDialog();

            //ds.Tables.Clear();
            //ds.Dispose();
        }
        public void Retrieve_Data()
        {
            string qry = "", sign="";
            if (rdb_sign.Checked == true)
            {
                sign = "[sign]";
            }
            else if (rdb_sign2.Checked == true)
            {
                sign = "[sign2]";
            }
            else
            {
                sign = "'' as sign";

            }
           // DataTable dvl_table = new DataTable();
            //DataTable Dt_Emp = new DataTable();

            qry = "";
            qry = qry + " select ";
            qry = qry + "(SELECT  CO_NAME FROM Company where CO_CODE='" + Co_ID + "')as 'coname'";
            qry=qry + ",(select distinct Cmpimage from branch b where b.GCODE='" +Co_ID + "' ) as 'Cmpimage'";
            qry = qry + ",(select " + sign + " from Company where GCODE='" + dt_co.Rows[0]["GCODE"].ToString() + "') as ASign"+
                        ",(select c.CO_ADD  from Company c where c.CO_CODE=e.Company_id ) as 'Add1',(select c.CO_ADD1  from Company c where c.CO_CODE=e.Company_id ) as 'Add2', "+
                        "(select distinct b.Email  from Branch b where b.GCODE=e.Company_id ) as 'c_Email', (select distinct b.BRNCH_TELE1 from Branch b where b.GCODE=e.Company_id ) as 'c_Contact', (select distinct b.BRNCH_TELE2 from Branch b where b.GCODE=e.Company_id ) as 'c_Contact1', ";
            qry = qry + "(select p.PoliceStation from PS_Master p where p.psid=e.psid) as 'PoliceStation',(select p.dist from PS_Master p where p.psid=e.psid) as 'p_dist',(select p.state from PS_Master p where p.psid=e.psid) as 'p_state',";
            qry = qry + "(select c.plicence  from Company c where c.CO_CODE=e.Company_id ) as 'LicenceNo' ,(select (case when convert(varchar,c.plicencedt, 101)='01/01/1900' then '' else convert(varchar,c.plicencedt, 101) end)  from Company c where c.CO_CODE=e.Company_id )  as 'Dated' , ";
            qry = qry + " ((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN ltrim(rtrim(e.FirstName)) + ' ' ELSE '' END)+" +
            "(CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN ltrim(rtrim(e.MiddleName)) + ' ' ELSE '' END)+ " +
            "(CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN ltrim(rtrim(e.LastName)) + ' ' ELSE '' END)) as 'ename'";
            qry = qry + " ,((CASE WHEN ltrim(rtrim(e.FathFN)) != '' THEN ltrim(rtrim(e.FathFN)) + ' ' ELSE '' END)+" +
            "(CASE WHEN ltrim(rtrim(e.FathMN)) != '' THEN ltrim(rtrim(e.FathMN)) + ' ' ELSE '' END) +" +
            "(CASE WHEN ltrim(rtrim(e.FathLN)) != '' THEN ltrim(rtrim(e.FathLN)) + ' ' ELSE '' END)) as 'fname'";
            qry = qry + " , cast(convert(char(11), e.Mobile) as VARCHAR) as 'Mobile'";
            qry = qry + ",(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=e.Desgid))as 'edesg'";
            qry = qry + " , cast(convert(char(11), DateOfBirth, 103) as VARCHAR) as 'dob'";
            qry = qry + ",(select q.Quali_Name from Qualification_Master q where q.Quali_Code=e.Code) as 'qualification'";

            qry = qry + " ,(Presentstreet +'\n\r'+ Presentcity +'-'+ Presentpin +'\n\r'+ (select upper(state_name) from statemaster where e.Presentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where e.Presentcountry=country_Code)) as 'preadd', Presentcountry";
            qry = qry + ",(Permanentstreet +'\n\r'+ Permanentcity +'-'+ Permanentpin +'\n\r'+ (select upper(state_name) from statemaster where e.Permanentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where e.Permanentcountry=country_Code))as 'peradd' ,Permanentcountry";
            qry = qry + "   from tbl_Employee_Mast e where ";
            if (rdb_ic_selective.Checked == true)
            {
                qry = qry + "(e.ID in (" + emp_id + ")) ";
            }
            else if (rdb_ic_emp.Checked == true)
            {
                qry = qry + "(e.ID ='" + emp_id + "') ";
            }
           

                        dvl_table = clsDataAccess.RunQDTbl(qry);

           // DataTable dtimage = clsDataAccess.RunQDTbl("select distinct Cmpimage from branch where GCODE='" + Co_ID + "' ");//where id='" + CmbEmpId.Text + "'");
            //DS_VL.Tables.Add(dtimage);

            

            

        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            if (CmbCompany.Text.Trim() != "")
            {

                string fpath = "";
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;
                // Show the FolderBrowserDialog.  
                DialogResult result = folderDlg.ShowDialog();
                MemoryStream stream = new MemoryStream();

                Bitmap bitmap;
                byte[] image;

                if (result == DialogResult.OK)
                {
                    fpath = folderDlg.SelectedPath;
                    Environment.SpecialFolder root = folderDlg.RootFolder;
                    DataTable dt = clsDataAccess.RunQDTbl("SELECT ID,Empimage FROM tbl_Employee_Mast AS emp WHERE (Company_id='" + CmbCompany.ReturnValue.Trim() + "') and (active=1)");

                    try
                    {
                        if (dt.Rows.Count > 0)
                        {

                            for (int ind = 0; ind < dt.Rows.Count; ind++)
                            {
                                //pictureimport.Image = null;
                                //context.Response.BinaryWrite((Byte[])dr[0]);
                                MemoryStream stream1 = new MemoryStream();
                                try
                                {
                                    image = ((byte[])dt.Rows[ind]["Empimage"]);
                                    stream1.Write(image, 0, image.Length);
                                    //edpcon.Close();

                                  bitmap = new Bitmap(stream1);
                                    bitmap.Save(fpath + "\\" + dt.Rows[ind]["ID"] + ".jpg");
                                    bitmap.Dispose();
                                    //stream.Dispose();
                                    
                                }
                                catch
                                {

                                }
                            }
                            //pictureimport.Image.Save(fpath + "\\" + cmbdEmpId.Text + ".jpg");
                        }
                        MessageBox.Show("Image saved in " + fpath, "Bravo");
                    }
                    catch { }
                }
            }
            else
            {
                MessageBox.Show("Please Select Company Name", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       

        /* public DataTable EmpDetails(string empid)
         {
             con.Close();
             con.Open();
             SqlCommand cmdempdet = new SqlCommand("select title,firstname,middlename,lastname,fathtitle,fathfn,fathmn,fathln,mothtitle,mothfn,mothmn,mothln,hustitle,husfn,husmn,husln,dateofbirth,maritalstatus,gender,religion,cast,weight,height,designationname,co_name,location_name,tbl_employee_jobtype.jobtype from tbl_employee_mast,tbl_emp_location,company,tbl_employee_jobtype,tbl_employee_designationmaster where tbl_employee_mast.desgid=tbl_employee_designationmaster.slno and tbl_employee_mast.location_id=tbl_emp_location.location_id and tbl_employee_mast.company_id=company.co_code and tbl_employee_mast.jobtype=tbl_employee_jobtype.slno and tbl_employee_mast.id='" + empid + "'", con);
             SqlDataAdapter da = new SqlDataAdapter(cmdempdet);
             DataTable dtempdet = new DataTable();
             da.Fill(dtempdet);
             con.Close();
             return dtempdet;
         }*/

       
    }
}


