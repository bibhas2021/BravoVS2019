using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class Reg_Damage_Loss : Form
    {
        int Location_id = 0, Company_id = 0;
        DataTable dt = new DataTable();
        public Reg_Damage_Loss()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            if (dt.Rows.Count > 0)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(CmbCompany.ReturnValue);
       
        }

        private void CmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("Select EL.Location_Name,EL.Location_ID from tbl_Emp_Location EL,Companywiseid_Relation cr where cr.Location_ID=EL.Location_ID and  cr.Company_ID='" + Company_id + "'");
            if (dt.Rows.Count > 0)
            {
                CmbLocation.LookUpTable = dt;
                CmbLocation.ReturnIndex = 1;
            }
        }

        private void CmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbLocation.ReturnValue) == true)
                Location_id = Convert.ToInt32(CmbLocation.ReturnValue);
            dateTimePicker1.Focus();
        }

        private void Damage_Loss_reg_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(CmbSession, 2015, System.DateTime.Now.Year, 1);
            try
            {
                if (dateTimePicker1.Value.Month >= 4)
                {
                    try
                    { CmbSession.SelectedItem = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    CmbSession.SelectedItem = dateTimePicker1.Value.AddYears(-1).Year + "-" + dateTimePicker1.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }

            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
           

            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                CmbCompany.Text = dta.Rows[0][0].ToString();

                Company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                CmbCompany.ReturnValue = Company_id.ToString();
                CmbCompany.Enabled = false;

            }
            else if (dta.Rows.Count > 1)
            {
                CmbCompany.PopUp();
            }
            CmbLocation.Select();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (CmbLocation.Text != "")
            {
                get_data();
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                String loc = clsDataAccess.GetresultS("SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = '" + Location_id + "') ");
                String client = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'Client' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                String clientadd = clsDataAccess.GetresultS("select (select cm.Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                String sub = "For the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");

                

                MidasReport.Form1 dml = new MidasReport.Form1();
                dml.dam(CmbCompany.Text, CO_ADD, loc, client, clientadd, sub, dt,0);
                dml.Show();
            }
            else
            {
                MessageBox.Show("Please select location");
                //return;
            }
            CmbLocation.Focus();
        }

        public void get_data()
        {
            string Str_ESI = "";
            string Str_ESI_SLNO = "";

            DataTable ss = clsDataAccess.RunQDTbl("SELECT DISTINCT d.SalaryHead_Short,d.SlNo FROM tbl_Employee_DeductionSalayHead AS d INNER JOIN tbl_Employee_Assign_SalStructure AS e ON d.SlNo = e.SAL_HEAD WHERE ({ fn UCASE(d.SalaryHead_Short) } = 'FINE') AND (e.Location_ID ='" + Location_id + "')");

            if (ss.Rows.Count > 0)
            {
                Str_ESI = ss.Rows[0][0].ToString();
                Str_ESI_SLNO = ss.Rows[0][1].ToString();
            }
            else
            {
                Str_ESI = "";
                ERPMessageBox.ERPMessage.Show("There is no Fine Head in the Salary Structure");
                return;
            }

            //DataTable dt_fine = new DataTable();
            string month = dateTimePicker1.Value.ToString("MMMM/ yyyy");
            string mon = dateTimePicker1.Value.ToString("MMMM");
            string mn = dateTimePicker1.Value.ToString("M/yyyy");
            string qry = "SELECT null as sl,fl.eid as ID," +
"(select (CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+ (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END) from tbl_Employee_Mast em where em.ID=ea.ID) as Name," +
"(select (CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN ltrim(rtrim(em.FathFN)) + ' ' ELSE '' END)+ (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN ltrim(rtrim(em.FathMN)) + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN ltrim(rtrim(em.FathLN)) + ' ' ELSE '' END) from tbl_Employee_Mast em where em.ID=ea.ID)as FatherName," +
"(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=ea.DesgId) as 'DesignationName'," +
"cast(convert(char(11), fl.FDT, 103) as VARCHAR) as FDT,fl.FAMT,(case when fl.cause_check='1' then cause else 'no' end) as cause," +
"fl.wit_name,cast(convert(char(11), fl.dof, 103) as VARCHAR) as dof," +
"(select REASON from tbl_FineMst where fid=fl.FID) as 'reason', 'one' as 'one'," +
"(select Amount from tbl_Employee_SalaryDet where (EmpId=fl.eid) and (TableName='tbl_Employee_DeductionSalayHead') and (SalId='" + Str_ESI_SLNO + "') and (Month='" + mon + "') and (Location_id=ea.LOcation_ID) and (Session='" + CmbSession.Text + "') ) as 'Amount'," +
"(select cast(convert(char(11), InsertionDate, 103) as VARCHAR) from tbl_Employee_SalaryDet where (EmpId=fl.eid) and (TableName='tbl_Employee_DeductionSalayHead') and (SalId='" + Str_ESI_SLNO + "') and (Month='" + mon + "') and (Location_id=ea.LOcation_ID) and (Session='" + CmbSession.Text + "')) as 'ADT' " +
" from tbl_fine_log fl, tbl_Employee_Attend ea where (ea.ID=fl.eid) and (ea.LOcation_ID='" + Location_id + "') and (ea.Month='"+ mn +"') and (fl.FMONTH='" + month + "') and (fl.d_chk='1' or fl.d_chk='True')";
                
                
                
                //"SELECT null as sl,fl.eid as ID,' '+FirstName+' '+MiddleName+' '+LastName as Name,' '+FathFN+' '+FathMN+' '+FathLN as FatherName," +
                //"(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as 'DesignationName'," +
                ////"(select lm.[Location_Name] from [tbl_Emp_Location] lm where lm.[Location_ID] = fl.LocID) as 'LocationName'," +
                //"cast(convert(char(11), FDT, 103) as VARCHAR) as FDT,fl.FAMT," +
                //"(case when fl.cause_check='1'then cause else 'no'end)as cause," +
                //"fl.wit_name,cast(convert(char(11), dof, 103) as VARCHAR) as dof," +
                //"(select REASON from tbl_FineMst where fid=fl.FID)as 'reason','one' as 'one'," +
                //"(select Amount from tbl_Employee_SalaryDet where EmpId=fl.eid and TableName='tbl_Employee_DeductionSalayHead' and SalId='" + Str_ESI_SLNO + "' and Month='" + mon + "'and Location_id='" + Location_id + "' and Session='" + CmbSession.Text + "' )as 'Amount'," +
                //"(select cast(convert(char(11), InsertionDate, 103) as VARCHAR) from tbl_Employee_SalaryDet where EmpId=fl.eid and TableName='tbl_Employee_DeductionSalayHead' and SalId='" + Str_ESI_SLNO + "' and Month='" + mon + "'and Location_id='" + Location_id + "' and Session='" + CmbSession.Text + "' )as 'ADT'" +
                      
                ////"(select NetPay from tbl_Employee_SalaryMast where Emp_Id=fl.eid and Location_id='" + Location_id + "' and Month='" + mon + "')as NetPay, " +
                ////"(select cast(convert(char(11), Date_of_Insert, 103) as VARCHAR) from tbl_Employee_SalaryMast where Emp_Id=fl.eid and Location_id='" + Location_id + "' and Month='" + mon + "')as 'frd'" +
                //"from tbl_fine_log fl, tbl_Employee_Mast em where em.ID=fl.eid  and   fl.LocID='" + Location_id + "' and fl.FMONTH='" + month + "' and fl.d_chk='1'";

            dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("There is no damage record ");
            }
            else
            { }


        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            if (CmbLocation.Text != "")
            {
                get_data();
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                String loc = clsDataAccess.GetresultS("SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = '" + Location_id + "') ");
                String client = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'Client' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                String clientadd = clsDataAccess.GetresultS("select (select cm.Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                String sub = "For the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");



                MidasReport.Form1 dml = new MidasReport.Form1();
                dml.dam(CmbCompany.Text, CO_ADD, loc, client, clientadd, sub, dt,1);
                //dml.Show();
            }
            else
            {
                MessageBox.Show("Please select location");
               // return;
            }
            CmbLocation.Focus();
        }
    }
}
