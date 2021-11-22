using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data.SqlClient;

using Edpcom;

namespace PayRollManagementSystem
{
    public partial class Reg_Advance : Form//EDPComponent.FormBaseERP
    {

        int Company_id = 0, Location_id = 0;
        DataTable dt = new DataTable();
        public Reg_Advance()
        {
            InitializeComponent();
        }

        private void frmUserWorkLog_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            AttenDtTmPkr.Value = DateTime.Now.AddMonths(-1);
            //this.HeaderText = "Advance Register";

            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                cmbcompany.Text = dta.Rows[0][0].ToString();

                Company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                cmbcompany.ReturnValue = Company_id.ToString();
                cmbcompany.Enabled = false;

            }
            else if (dta.Rows.Count > 1)
            {
                cmbcompany.PopUp();
            }
            cmbLoc.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    {
                        cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year;
                    }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //String str = "SELECT (CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN ' ' + e.MiddleName ELSE '' END)    + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN ' ' + e.LastName ELSE '' END) AS 'Name'," +
            //"(CASE WHEN ltrim(rtrim(e.FathFN)) != '' THEN e.FathFN ELSE '' END)  + (CASE WHEN ltrim(rtrim(e.FathMN)) != '' THEN ' ' + e.FathMN ELSE '' END) + (CASE WHEN ltrim(rtrim(e.FathLN)) != '' THEN ' ' + e.FathLN ELSE '' END) AS 'Father Name', a.EADT, a.EAAMT, a.LocID,  e.Location_id,"+
            //"e.Company_id, s.Amount, s.Month, s.Session, m.NetPay,m.Month as NetMonth, (SELECT DesignationName FROM          tbl_Employee_DesignationMaster AS m  WHERE      (SlNo = e.DesgId)) AS DesignationName, (SELECT     Location_Name FROM          tbl_Emp_Location  WHERE      (Location_ID = '" + Location_id + "')) AS Location_Name FROM tbl_Employee_Mast AS e INNER JOIN  tbl_Employee_SalaryDet AS s ON e.ID = s.EmpId INNER JOIN  tbl_Employee_Advance AS a ON e.ID = a.EAEID INNER JOIN tbl_Employee_SalaryMast AS m ON a.EAEID = m.Emp_Id AND s.Month = m.Month AND s.Session = m.Session WHERE     (e.Location_id = '" + Location_id + "') AND (e.Company_id = '" + Company_id + "') AND (s.Session = '" + cmbYear.Text + "') AND (s.TableName = 'tbl_Employee_DeductionSalayHead') AND (s.SalId = (SELECT     SAL_HEAD  FROM          tbl_Employee_Assign_SalStructure AS ss  WHERE   (a.EAAMT!=0) and   (Location_id = '" + Location_id + "') AND (chkALK = 1))) AND (a.LocID = '" + Location_id + "') AND (e.Location_id = '" + Location_id + "') AND (s.Month = '" + AttenDtTmPkr.Value.ToString("MMMM") + "')";
            //DataTable dt = clsDataAccess.RunQDTbl(str);
            //DataTable dt1 = new DataTable();
            //dt1.Columns.Add("Name");
            //dt1.Columns.Add("Father Name");
            //dt1.Columns.Add("EADT");
            //dt1.Columns.Add("EAAMT");
            //dt1.Columns.Add("Amount");
            //dt1.Columns.Add("Month");
            //dt1.Columns.Add("Session");
            //dt1.Columns.Add("NetPay");
            //dt1.Columns.Add("NetMonth");
            //dt1.Columns.Add("Company");
            //dt1.Columns.Add("Address");
            //dt1.Columns.Add("DesignationName");
            //dt1.Columns.Add("Location_Name");
            //dt1.Columns.Add("Personal");
            //dt1.Columns.Add("one");
            //dt1.Columns.Add("Client");
            //dt1.Columns.Add("ClientAdd");
            //for (int ind = 0; ind < dt.Rows.Count; ind++)
            //{
            //    dt1.Rows.Add();
            //    dt1.Rows[ind]["Name"] = dt.Rows[ind]["Name"].ToString();
            //    dt1.Rows[ind]["Father Name"] = dt.Rows[ind]["Father Name"].ToString();
            //    dt1.Rows[ind]["EADT"] = dt.Rows[ind]["EADT"].ToString();
            //    dt1.Rows[ind]["EAAMT"] = dt.Rows[ind]["EAAMT"].ToString();
            //    dt1.Rows[ind]["Amount"] = dt.Rows[ind]["Amount"].ToString();
            //    dt1.Rows[ind]["Month"] = dt.Rows[ind]["Month"].ToString();
            //    dt1.Rows[ind]["Session"] = cmbYear.Text.ToString();
            //    dt1.Rows[ind]["NetPay"] = dt.Rows[ind]["NetPay"].ToString();
            //    dt1.Rows[ind]["NetMonth"] = dt.Rows[ind]["NetMonth"].ToString();
            //    dt1.Rows[ind]["Company"] = cmbcompany.Text.ToString();
            //    //dt.Rows[ind]["SlNo"] = ind + 1;
            //    dt1.Rows[ind]["Address"] = clsDataAccess.GetresultS(" select BRNCH_ADD1+''+BRNCH_ADD2 from Branch where GCODE = '" + cmbcompany.ReturnValue + "' ");
            //    dt1.Rows[ind]["DesignationName"] = dt.Rows[ind]["DesignationName"].ToString();
            //    dt1.Rows[ind]["Location_Name"] = dt.Rows[ind]["Location_Name"].ToString();
            //    dt1.Rows[ind]["Personal"] = "Personal";
            //    dt1.Rows[ind]["one"] = "One";
            //    dt1.Rows[ind]["Client"] = clsDataAccess.GetresultS(" select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = '" + Location_id + "' ");
            //    dt1.Rows[ind]["ClientAdd"] = clsDataAccess.GetresultS(" select (select cm.Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = '" + Location_id + "' ");
            //}

            if (cmbLoc.Text != "")
            {
                string Str_ESI = "";
                string Str_ESI_SLNO = "";

                string month = AttenDtTmPkr.Value.ToString("MMMM/ yyyy");
                int nxt_mon = 0;
                nxt_mon = AttenDtTmPkr.Value.Month + 1;
                string mon = clsEmployee.GetMonthName(nxt_mon);

                DataTable ss = clsDataAccess.RunQDTbl("SELECT DISTINCT d.SalaryHead_Full,d.SlNo FROM tbl_Employee_DeductionSalayHead AS d INNER JOIN tbl_Employee_Assign_SalStructure AS e ON d.SlNo = e.SAL_HEAD WHERE ({ fn UCASE(d.SalaryHead_Short) } = 'ADV') AND (e.Location_ID ='" + Location_id + "')");

                if (ss.Rows.Count > 0)
                {
                    Str_ESI = ss.Rows[0][0].ToString();
                    Str_ESI_SLNO = ss.Rows[0][1].ToString();
                }
                else
                {
                    Str_ESI = "";
                    ERPMessageBox.ERPMessage.Show("There is no Advance Head in the Salary Structure");
                    return;
                }


                string qry = "SELECT (CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ' ' + em.MiddleName ELSE '' END)    + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ' ' + em.LastName ELSE '' END) AS 'Name'," +
                           "(CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN ELSE '' END)  + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN ' ' + em.FathMN ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN ' ' + em.FathLN ELSE '' END) AS 'Father Name'," +
                           "(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)AS DesignationName," +
                           "(select NetPay from tbl_Employee_SalaryMast where Emp_Id=ea.EAEID and Location_id='" + Location_id + "' and Month='" + mon + "')as NetPay," +
                           "(select Month from tbl_Employee_SalaryMast where Emp_Id=ea.EAEID and Location_id='" + Location_id + "' and Month='" + mon + "')as 'NetMonth'," +
                           "cast(convert(char(11), EADT, 103) as VARCHAR)as eadt,ea.EAAMT,ea.remarks as 'Personal','one' as 'one'," +
                           "(select Amount from tbl_Employee_SalaryDet where EmpId=ea.EAEID and TableName='tbl_Employee_DeductionSalayHead' and SalId='" + Str_ESI_SLNO + "' and Month='" + mon + "'and Location_id='" + Location_id + "' and Session='" + cmbYear.Text + "' )as 'Amount'," +
                           "(select cast(convert(char(11), InsertionDate, 103) as VARCHAR) from tbl_Employee_SalaryDet where EmpId=ea.EAEID and TableName='tbl_Employee_DeductionSalayHead' and SalId='" + Str_ESI_SLNO + "' and Month='" + mon + "'and Location_id='" + Location_id + "' and Session='" + cmbYear.Text + "' )as 'ADT' " +
                           ",'" + cmbcompany.Text + "' as 'Company',(SELECT BRNCH_ADD1 FROM Branch where gcode='" + Company_id + "' and Brnch_code=1) as 'Address', '"+month+"' as 'Month','"+lblClient.Text+"'as 'Client','"+cmbLoc.Text+"' as 'ClientAdd' from tbl_Employee_Advance ea, tbl_Employee_Mast em where em.ID=ea.EAEID  and   ea.LocID='" + Location_id + "' and ea.EAMONTH='" + month + "'";

                dt = clsDataAccess.RunQDTbl(qry);

                MidasReport.Form1 opening = new MidasReport.Form1();
                opening.R_Advance(dt,0);
                opening.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select location");
                //return;
            }
            cmbLoc.Focus();

        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;

            }
        }
        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);


        }

        private void cmbLoc_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select EL.Location_Name,EL.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL,Companywiseid_Relation cr where cr.Location_ID=EL.Location_ID and  cr.Company_ID='" + Company_id + "'");
            if (dt.Rows.Count > 0)
            {
                cmbLoc.LookUpTable = dt;
                cmbLoc.ReturnIndex = 1;
            }
        }
        private void cmbLoc_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            lblClient.Text = "";
            if (Information.IsNumeric(cmbLoc.ReturnValue) == true)
            {
                Location_id = Convert.ToInt32(cmbLoc.ReturnValue);

                lblClient.Text = clsDataAccess.ReturnValue("select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where (EL.Location_ID='" + Location_id + "')");
            }
            AttenDtTmPkr.Focus();
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            if (cmbLoc.Text != "")
            {
                string Str_ESI = "";
                string Str_ESI_SLNO = "";

                string month = AttenDtTmPkr.Value.ToString("MMMM/ yyyy");
                int nxt_mon = 0;
                nxt_mon = AttenDtTmPkr.Value.Month + 1;
                string mon = clsEmployee.GetMonthName(nxt_mon);

                DataTable ss = clsDataAccess.RunQDTbl("SELECT DISTINCT d.SalaryHead_Full,d.SlNo FROM tbl_Employee_DeductionSalayHead AS d INNER JOIN tbl_Employee_Assign_SalStructure AS e ON d.SlNo = e.SAL_HEAD WHERE ({ fn UCASE(d.SalaryHead_Short) } = 'ADV') AND (e.Location_ID ='" + Location_id + "')");

                if (ss.Rows.Count > 0)
                {
                    Str_ESI = ss.Rows[0][0].ToString();
                    Str_ESI_SLNO = ss.Rows[0][1].ToString();
                }
                else
                {
                    Str_ESI = "";
                    ERPMessageBox.ERPMessage.Show("There is no Advance Head in the Salary Structure");
                    return;
                }


                string qry = "SELECT (CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ' ' + em.MiddleName ELSE '' END)    + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ' ' + em.LastName ELSE '' END) AS 'Name'," +
                           "(CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN ELSE '' END)  + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN ' ' + em.FathMN ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN ' ' + em.FathLN ELSE '' END) AS 'Father Name'," +
                           "(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)AS DesignationName," +
                           "(select NetPay from tbl_Employee_SalaryMast where Emp_Id=ea.EAEID and Location_id='" + Location_id + "' and Month='" + mon + "')as NetPay," +
                           "(select Month from tbl_Employee_SalaryMast where Emp_Id=ea.EAEID and Location_id='" + Location_id + "' and Month='" + mon + "')as 'NetMonth'," +
                           "cast(convert(char(11), EADT, 103) as VARCHAR)as eadt,ea.EAAMT,ea.remarks as 'Personal','one' as 'one'," +
                           "(select Amount from tbl_Employee_SalaryDet where EmpId=ea.EAEID and TableName='tbl_Employee_DeductionSalayHead' and SalId='" + Str_ESI_SLNO + "' and Month='" + mon + "'and Location_id='" + Location_id + "' and Session='" + cmbYear.Text + "' )as 'Amount'," +
                           "(select cast(convert(char(11), InsertionDate, 103) as VARCHAR) from tbl_Employee_SalaryDet where EmpId=ea.EAEID and TableName='tbl_Employee_DeductionSalayHead' and SalId='" + Str_ESI_SLNO + "' and Month='" + mon + "'and Location_id='" + Location_id + "' and Session='" + cmbYear.Text + "' )as 'ADT' " +
                           "from tbl_Employee_Advance ea, tbl_Employee_Mast em where em.ID=ea.EAEID  and   ea.LocID='" + Location_id + "' and ea.EAMONTH='" + month + "'";

                dt = clsDataAccess.RunQDTbl(qry);

                MidasReport.Form1 opening = new MidasReport.Form1();
                opening.R_Advance(dt,1);
                //opening.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select location");
                //return;
            }
            cmbLoc.Focus();
        }
    }
}
