using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frmEmpPostingRpt : Form
    {
        int Company_id = 0;
        String qry, cmp, sub;
        DataTable dt_post = new DataTable();



        public frmEmpPostingRpt()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
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

        private void frmEmpPostingRpt_Load(object sender, EventArgs e)
        {
            this.Text = "Employee Wise Posting";
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            AttenDtTmPkr.Value = DateTime.Now;
            cmbcompany.PopUp();

        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
                //cmbLoc.Text = "";
            }

        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cmbcompany.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Please Select the Company Name", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
            else
            {
                Retreive_Data();

                MidasReport.Form1 post = new MidasReport.Form1();
                post.empwiseposting(cmp, sub, dt_post);
                post.Show();
            }
        }

        public void Retreive_Data()
        {
            //DataTable dt_post = new DataTable();

            qry = "SELECT ea.ID," +
            "(SELECT (CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName ELSE '' END)+" +
            "(CASE WHEN ltrim(rtrim(e.MiddleName))!= '' THEN ' ' + e.MiddleName ELSE '' END)+" +
            "(CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN ' ' + e.LastName ELSE '' END) AS 'EName' FROM tbl_Employee_Mast AS e WHERE (ID=ea.ID)) AS 'EName'," +
            "(select e.PF  from tbl_Employee_Mast e where (ID=ea.ID))as'PFNo'," +
            "(select e.ESIno from tbl_Employee_Mast e where (ID=ea.ID))as'ESIno'," +
            "(select e.PassportNo from tbl_Employee_Mast e where (ID=ea.ID))as'UAN'," +
            "loc.Client_Name,loc.Location_Name,loc.Cliant_ID,loc.Location_ID AS lid," +
            "ea.days_wd,ea.days_ot,(SELECT DesignationName FROM tbl_Employee_DesignationMaster where SlNo=ea.Desgid)as 'DataColumn4'  from tbl_Employee_Attend as ea inner join" +
            "(SELECT el.Location_ID,el.Location_Name,el.Cliant_ID,ec.Client_Name FROM tbl_Emp_Location AS el INNER JOIN tbl_Employee_CliantMaster AS ec ON el.Cliant_ID =ec.Client_id AND ec.coid='"+Company_id+"')AS loc ON ea.LOcation_ID=loc.Location_ID " +
            "where ea.Month='"+AttenDtTmPkr.Value.ToString("M/yyyy")+"'and ea.Season='"+cmbYear.Text+"' and ea.Company_id='"+Company_id+"' order by ea.ID asc";


            dt_post = clsDataAccess.RunQDTbl(qry);

             cmp = clsDataAccess.GetresultS("Select c.CO_NAME from Company c,tbl_Employee_Attend ea  where c.CO_CODE='"+Company_id+"' ");

            sub = "For the month of" + AttenDtTmPkr.Value.ToString("MMMM,yyyy");
        }
    }
} 
