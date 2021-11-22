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
    public partial class frmRegister_ot :  Form//EDPComponent.FormBaseERP
    {

        int Company_id = 0, Location_id = 0;
        public frmRegister_ot()
        {
            InitializeComponent();
        }

        private void frmUserWorkLog_Load(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            AttenDtTmPkr.Value = DateTime.Now.AddMonths(-1);
            //this.HeaderText = "OT Register";

            //DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");

            DataTable dta = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {

                dta = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            }
            if (dta.Rows.Count == 1)
            {
                cmbcompany.Text = dta.Rows[0][0].ToString();
               
                Company_id = Convert.ToInt32(dta.Rows[0][1].ToString()); 
                cmbcompany.ReturnValue=Company_id.ToString();
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
            if (cmbLoc.Text != "")
            {
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                string qry = "";
                qry = " SELECT (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName))   != '' THEN ' ' + LastName ELSE '' END) AS 'Name', e.Gender, e.Location_id, e.Company_id, s.Amount, s.Month, s.Session, m.Basic, m.OT, p.Proxy_Day, cast((s.Amount/m.OT)as numeric(18,2))as'ot_rate', CONVERT(char(10), m.Date_of_Insert, 103)  AS 'Date_of_Insert', (SELECT     DesignationName   FROM          tbl_Employee_DesignationMaster AS m   WHERE      (SlNo = e.DesgId)) AS DesignationName, (SELECT     Location_Name  FROM          tbl_Emp_Location   WHERE      (Location_ID = " + Location_id + ")) AS Location_Name, m.Month AS Expr1, m.Session AS Expr2 FROM         tbl_Employee_Proxy_Attendance AS p INNER JOIN tbl_Employee_Mast AS e INNER JOIN tbl_Employee_SalaryDet AS s ON e.ID = s.EmpId ON p.Employee_ID = e.ID INNER JOIN tbl_Employee_SalaryMast AS m ON e.ID = m.Emp_Id AND s.Month = m.Month AND s.Session = m.Session WHERE     (e.Location_id = " + Location_id + ") AND (e.Company_id = 1) AND (s.Month = '" + AttenDtTmPkr.Value.ToString("MMMM") + "') AND (s.Session = '" + cmbYear.Text + "') AND (s.TableName = 'tbl_Employee_ErnSalaryHead') AND (s.SalId = (SELECT DISTINCT TOP (1) SAL_HEAD  FROM          tbl_Employee_Assign_SalStructure AS ss  WHERE      (Location_id = " + Location_id + ") AND (Proxy_day = 1))) AND (p.Month = '" + AttenDtTmPkr.Value.ToString("MMMM") + "') AND (p.Session = '" + cmbYear.Text + "') and (OT>0)";
                DataTable dt = clsDataAccess.RunQDTbl(qry);
                String sub = clsDataAccess.GetresultS("SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = '" + Location_id + "') ");
                String client = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'Client' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");

                String cl_add = clsDataAccess.GetresultS("select (select Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                MidasReport.Form1 att = new MidasReport.Form1();
                att.R_OT(cmbcompany.Text, CO_ADD, sub, client, dt, AttenDtTmPkr.Value.ToString("MMMM, yyyy"), cl_add,0);

                att.ShowDialog();
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
            DataTable dt = clsDataAccess.RunQDTbl("Select EL.Location_Name,EL.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL,Companywiseid_Relation cr where cr.Location_ID=EL.Location_ID and  cr.Company_ID='"+Company_id+"'");
            if (dt.Rows.Count > 0)
            {
                cmbLoc.LookUpTable = dt;
                cmbLoc.ReturnIndex = 1;
            }
        }
        private void cmbLoc_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLoc.ReturnValue) == true)
                Location_id = Convert.ToInt32(cmbLoc.ReturnValue);
            AttenDtTmPkr.Focus();
            
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            if (cmbLoc.Text != "")
            {
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                string qry = "";
                qry = " SELECT (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName))   != '' THEN ' ' + LastName ELSE '' END) AS 'Name', e.Gender, e.Location_id, e.Company_id, s.Amount, s.Month, s.Session, m.Basic, m.OT, p.Proxy_Day, cast((s.Amount/m.OT)as numeric(18,2))as'ot_rate', CONVERT(char(10), m.Date_of_Insert, 103)  AS 'Date_of_Insert', (SELECT     DesignationName   FROM          tbl_Employee_DesignationMaster AS m   WHERE      (SlNo = e.DesgId)) AS DesignationName, (SELECT     Location_Name  FROM          tbl_Emp_Location   WHERE      (Location_ID = " + Location_id + ")) AS Location_Name, m.Month AS Expr1, m.Session AS Expr2 FROM         tbl_Employee_Proxy_Attendance AS p INNER JOIN tbl_Employee_Mast AS e INNER JOIN tbl_Employee_SalaryDet AS s ON e.ID = s.EmpId ON p.Employee_ID = e.ID INNER JOIN tbl_Employee_SalaryMast AS m ON e.ID = m.Emp_Id AND s.Month = m.Month AND s.Session = m.Session WHERE     (e.Location_id = " + Location_id + ") AND (e.Company_id = 1) AND (s.Month = '" + AttenDtTmPkr.Value.ToString("MMMM") + "') AND (s.Session = '" + cmbYear.Text + "') AND (s.TableName = 'tbl_Employee_ErnSalaryHead') AND (s.SalId = (SELECT DISTINCT TOP (1) SAL_HEAD  FROM          tbl_Employee_Assign_SalStructure AS ss  WHERE      (Location_id = " + Location_id + ") AND (Proxy_day = 1))) AND (p.Month = '" + AttenDtTmPkr.Value.ToString("MMMM") + "') AND (p.Session = '" + cmbYear.Text + "') and (OT>0)";
                DataTable dt = clsDataAccess.RunQDTbl(qry);
                String sub = clsDataAccess.GetresultS("SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = '" + Location_id + "') ");
                String client = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'Client' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");

                String cl_add = clsDataAccess.GetresultS("select (select Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                MidasReport.Form1 att = new MidasReport.Form1();
                att.R_OT(cmbcompany.Text, CO_ADD, sub, client, dt, AttenDtTmPkr.Value.ToString("MMMM, yyyy"), cl_add,1);

               // att.ShowDialog();
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
