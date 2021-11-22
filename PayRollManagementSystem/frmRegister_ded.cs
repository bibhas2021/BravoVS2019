using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using Edpcom;

namespace PayRollManagementSystem
{
    public partial class frmRegister_ded : Form//EDPComponent.FormBaseERP
    {
        public frmRegister_ded()
        {
            InitializeComponent();
        }
        string Item_Code = "";
        ArrayList arritem = new ArrayList();
        Hashtable getcode_item = new Hashtable();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        string[] ar = new string[12];
        int Location_id = 0, Company_id = 0;

        private void frmUserWorkLog_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(CmbSession, 2015, System.DateTime.Now.Year, 1);
            try
            {
                if (dateTimePicker1.Value.Month >= 4)
                {
                    try
                    {
                        CmbSession.SelectedItem = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.AddYears(1).Year;
                    }
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
           // this.HeaderText = "Deduction Register";

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

        private void CmbCompany_DropDown_Closeup(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
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

        private void CmbLocation_DropDown_Closeup(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {

            if (Information.IsNumeric(CmbLocation.ReturnValue) == true)
                Location_id = Convert.ToInt32(CmbLocation.ReturnValue);
            dateTimePicker1.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (CmbLocation.Text != "")
            {
                string Str_ESI = "";
                string Str_ESI_SLNO = "";

                string month = dateTimePicker1.Value.ToString("MMMM/ yyyy");
                int nxt_mon = 0;
                nxt_mon = dateTimePicker1.Value.Month + 1;
                string mon = clsEmployee.GetMonthName(nxt_mon);

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


                string qry = "";
                //qry = " SELECT (SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = f.eid)) AS Name,f.eid as code,f.FEMI as 'Amount', m.FathFN+ ' ' +FathLN as 'Father Name' ,f.FAMT as 'EADT',(SELECT d.DesignationName FROM tbl_Employee_DesignationMaster AS d WHERE (SlNo = m.DesgId)) AS DesignationName,f.FDT AS 'Date Of Damage', cast(f.FDuration as numeric(18,0)) AS 'one' from tbl_Employee_Mast m, tbl_fine_log f where f.eid = m.ID and (f.FMONTH ='" + dateTimePicker1.Value.ToString("MMMM") + "/ " + dateTimePicker1.Value.Year + "') and (f.CoID='" + Company_id + "') and f.LocID= '" + Location_id + "'  ";

                qry = "SELECT fl.eid as ID,' '+FirstName+' '+MiddleName+' '+LastName as Name,' '+FathFN+' '+FathMN+' '+FathLN as FatherName," +
                      "(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as 'DesignationName'," +
                       "cast(convert(char(11), FDT, 103) as VARCHAR) as FDT,fl.FAMT,fl.FDuration as 'Fd'," +
                      "(select REASON from tbl_FineMst where fid=fl.FID)as 'reason'," +
                      "(select Amount from tbl_Employee_SalaryDet where EmpId=fl.eid and TableName='tbl_Employee_DeductionSalayHead' and SalId='" + Str_ESI_SLNO + "' and Month='" + dateTimePicker1.Value.ToString("MMMM") + "'and Location_id='" + Location_id + "' and Session='" + CmbSession.Text + "' )as 'Amount'," +
                      "(select cast(convert(char(11), InsertionDate, 103) as VARCHAR) from tbl_Employee_SalaryDet where EmpId=fl.eid and TableName='tbl_Employee_DeductionSalayHead' and SalId='" + Str_ESI_SLNO + "' and Month='" + dateTimePicker1.Value.ToString("MMMM") + "'and Location_id='" + Location_id + "' and Session='" + CmbSession.Text + "' )as 'ADT'" +
                       "from tbl_fine_log fl, tbl_Employee_Mast em where em.ID=fl.eid  and   fl.LocID='" + Location_id + "' and fl.FMONTH='" + month + "'";
                DataTable dt = clsDataAccess.RunQDTbl(qry);

                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                String loc = clsDataAccess.GetresultS("SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = '" + Location_id + "') ");
                String client = clsDataAccess.GetresultS("select (select cm.Client_Name+'  '+Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                String clientadd = clsDataAccess.GetresultS("select (select cm.Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                String sub = "For the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");

                MidasReport.Form1 att = new MidasReport.Form1();
                att.d_deduct(CmbCompany.Text, CO_ADD, loc, client, clientadd, sub, dt,0);
                edpcon.Close();
                att.Show();
            }
            else
            { 
                MessageBox.Show("Please select location");
                //return;
            }
           CmbLocation.Focus();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void LblCompany_Click(object sender, EventArgs e)
        {

        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            if (CmbLocation.Text != "")
            {
                string Str_ESI = "";
                string Str_ESI_SLNO = "";

                string month = dateTimePicker1.Value.ToString("MMMM/ yyyy");
                int nxt_mon = 0;
                nxt_mon = dateTimePicker1.Value.Month + 1;
                string mon = clsEmployee.GetMonthName(nxt_mon);

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


                string qry = "";
                //qry = " SELECT (SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = f.eid)) AS Name,f.eid as code,f.FEMI as 'Amount', m.FathFN+ ' ' +FathLN as 'Father Name' ,f.FAMT as 'EADT',(SELECT d.DesignationName FROM tbl_Employee_DesignationMaster AS d WHERE (SlNo = m.DesgId)) AS DesignationName,f.FDT AS 'Date Of Damage', cast(f.FDuration as numeric(18,0)) AS 'one' from tbl_Employee_Mast m, tbl_fine_log f where f.eid = m.ID and (f.FMONTH ='" + dateTimePicker1.Value.ToString("MMMM") + "/ " + dateTimePicker1.Value.Year + "') and (f.CoID='" + Company_id + "') and f.LocID= '" + Location_id + "'  ";

                qry = "SELECT fl.eid as ID,' '+FirstName+' '+MiddleName+' '+LastName as Name,' '+FathFN+' '+FathMN+' '+FathLN as FatherName," +
                      "(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as 'DesignationName'," +
                       "cast(convert(char(11), FDT, 103) as VARCHAR) as FDT,fl.FAMT,fl.FDuration as 'Fd'," +
                      "(select REASON from tbl_FineMst where fid=fl.FID)as 'reason'," +
                      "(select Amount from tbl_Employee_SalaryDet where EmpId=fl.eid and TableName='tbl_Employee_DeductionSalayHead' and SalId='" + Str_ESI_SLNO + "' and Month='" + dateTimePicker1.Value.ToString("MMMM") + "'and Location_id='" + Location_id + "' and Session='" + CmbSession.Text + "' )as 'Amount'," +
                      "(select cast(convert(char(11), InsertionDate, 103) as VARCHAR) from tbl_Employee_SalaryDet where EmpId=fl.eid and TableName='tbl_Employee_DeductionSalayHead' and SalId='" + Str_ESI_SLNO + "' and Month='" + dateTimePicker1.Value.ToString("MMMM") + "'and Location_id='" + Location_id + "' and Session='" + CmbSession.Text + "' )as 'ADT'" +
                       "from tbl_fine_log fl, tbl_Employee_Mast em where em.ID=fl.eid  and   fl.LocID='" + Location_id + "' and fl.FMONTH='" + month + "'";
                DataTable dt = clsDataAccess.RunQDTbl(qry);

                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                String loc = clsDataAccess.GetresultS("SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = '" + Location_id + "') ");
                String client = clsDataAccess.GetresultS("select (select cm.Client_Name+'  '+Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                String clientadd = clsDataAccess.GetresultS("select (select cm.Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                String sub = "For the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");

                MidasReport.Form1 att = new MidasReport.Form1();
                att.d_deduct(CmbCompany.Text, CO_ADD, loc, client, clientadd, sub, dt,1);
                edpcon.Close();
                //att.Show();
            }
            else
            {
                MessageBox.Show("Please select location");
                //return;
            }
            CmbLocation.Focus();
  
        }
    }
}
