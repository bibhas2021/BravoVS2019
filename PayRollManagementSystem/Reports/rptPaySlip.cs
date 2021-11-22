using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem.Reports
{
    public partial class rptPaySlip : Form
    {
        public rptPaySlip()
        {
            InitializeComponent();
        }

        private Boolean ChekAllExRecord()
        {
            Boolean boolStatus = false;

            DataTable dt = clsDataAccess.RunQDTbl("select emp.*,desg.DesignationName,job.JobType from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg, tbl_Employee_JobType job where emp.DesgId=desg.SlNo and emp.JobType=job.SlNo and emp.Session='" + cmbSession.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }
            return boolStatus;
        }

        private int CalculateAttndance()
        {
            DataTable dtAttndnce = clsDataAccess.RunQDTbl("select * from tbl_Employee_Attendance where ID='" + cmbdEmpId.Text + "' and ");
            int intCount = 0;
            if (dtAttndnce.Rows.Count > 0)
            {
                for (int i = 0; i < dtAttndnce.Rows.Count; i++)
                {
                    if (dtAttndnce.Rows[i]["Status"].ToString().ToLower == "false")
                    {
                        intCount += 1;
                    }
                }
            }
            return intCount;
        }


        private void SubmitDetails()
        {
            int intAtt = CalculateAttndance();

        }


        private void cmbMonth_DropDown(object sender, EventArgs e)
        {
            cmbMonth.Items.Clear();
            cmbMonth.Items.Add("January");
            cmbMonth.Items.Add("February");
            cmbMonth.Items.Add("March");
            cmbMonth.Items.Add("April");
            cmbMonth.Items.Add("May");
            cmbMonth.Items.Add("June");
            cmbMonth.Items.Add("July");
            cmbMonth.Items.Add("Aguast");
            cmbMonth.Items.Add("September");
            cmbMonth.Items.Add("October");
            cmbMonth.Items.Add("November");
            cmbMonth.Items.Add("December");
        }

        private void cmbdEmpId_DropDown(object sender, EventArgs e)
        {
            if (clsValidation.ValidateComboBox(cmbSession, "", "Please Select Session"))
            {
                if (ChekAllExRecord())
                {

                    DataTable dt = clsDataAccess.RunQDTbl("select emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name],desg.DesignationName from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg where emp.DesgId=desg.SlNo and emp.Session='" + cmbSession.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                    {
                        cmbdEmpId.LookUpTable = dt;
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}