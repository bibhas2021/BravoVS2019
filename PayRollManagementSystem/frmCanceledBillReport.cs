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
    public partial class frmCanceledBillReport : EDPComponent.FormBaseERP
    {
        int Co_Code = 0, Client_Id = 0, Location_Id = 0;

        public frmCanceledBillReport()
        {
            InitializeComponent();
        }

        private void frmCanceledBillReport_Load(object sender, EventArgs e)
        {
            this.HeaderText = "Cancelled bill Register";
            dtpDateTo.MinDate = dtpDateForm.Value;
        }

        private void cmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbCompany.LookUpTable = dt;
                cmbCompany.ReturnIndex = 1;
            }
        }

        private void cmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbCompany.ReturnValue))
            {
                Co_Code = Convert.ToInt32(cmbCompany.ReturnValue);
            }
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            if (Co_Code > 0)
            {
                DataTable dt = clsDataAccess.RunQDTbl("select (select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = cwr.Location_ID)as'LocationName',Location_ID from Companywiseid_Relation cwr where Company_ID = " + Co_Code);
                if (dt.Rows.Count > 0)
                {
                    cmbLocation.LookUpTable = dt;
                    cmbLocation.ReturnIndex = 1;
                }
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue))
            {
                Location_Id = Convert.ToInt32(cmbLocation.ReturnValue);
            }
        }

        private void dtpDateForm_ValueChanged(object sender, EventArgs e)
        {
            dtpDateTo.MinDate = dtpDateForm.Value;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //Button Click validation
            if (cmbCompany.Text.Trim() == ""||Co_Code==0)
            {
                EDPMessageBox.EDPMessage.Show("Please select company first.");
                return;
            }

            //Data fetching
            RetriveData();
        }

        private void RetriveData()
        {
            string strDateFormForSql = dtpDateForm.Value.Date.Month + "/" + dtpDateForm.Value.Date.Day + "/" + dtpDateForm.Value.Date.Year; ;
            string strDateToForSql = dtpDateTo.Value.Date.Month + "/" + dtpDateTo.Value.Date.Day + "/" + dtpDateTo.Value.Date.Year;
            string strMainSql = "select [BILLNO],CONVERT(varchar(10),[BILLDATE],103) as 'BillDate',(select lm.Location_Name from tbl_Emp_Location lm where pb.[Location_ID] = lm.Location_ID) as 'LocationName',(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id=pb.Cliant_ID) as 'ClientName',([TotAMT]+[ServiceAmount]+[ScAmt]) as 'BillAmount' from paybill pb where BILLDATE between '" + strDateFormForSql + "' and '" + strDateToForSql + "' and [Comany_id] = " + Co_Code + " and [BillStatus] = 'CANCELED'";
            if (Location_Id > 0)
                strMainSql = strMainSql + " and pb.[Location_ID] = " + Location_Id;
            if (Client_Id > 0)
                strMainSql = strMainSql + " and pb.[Cliant_ID] = " + Client_Id;
            DataTable dtMainTable = clsDataAccess.RunQDTbl(strMainSql);
            string dateFrom = dtpDateForm.Value.Date.Day + "/" + dtpDateForm.Value.Date.Month + "/" + dtpDateForm.Value.Date.Year;
            string dateTo = dtpDateTo.Value.Date.Day + "/" + dtpDateTo.Value.Date.Month + "/" + dtpDateTo.Value.Date.Year;
            string strDateRange = "Date Range : " + dateFrom + " To " + dateTo;
            DataTable dtCompanyInfo = clsDataAccess.RunQDTbl("select [CO_NAME],[CO_ADD] from [Company] where [CO_CODE] = " + Co_Code);
            string strCompanyName = "";
            string strCompanyAdd = "";
            if (dtCompanyInfo.Rows.Count > 0)
            {
                strCompanyName = dtCompanyInfo.Rows[0]["CO_NAME"].ToString();
                strCompanyAdd = dtCompanyInfo.Rows[0]["CO_ADD"].ToString();
            }

            MidasReport.Form1 mr = new MidasReport.Form1();
            mr.CanceledBillRegister(dtMainTable,strCompanyName,strCompanyAdd,strDateRange);
            mr.Show();

        }

        private void cmbClient_DropDown(object sender, EventArgs e)
        {
            if (Co_Code > 0)
            {
                DataTable dt = clsDataAccess.RunQDTbl("select [Client_Name],[Client_id] from [tbl_Employee_CliantMaster] where [coid] = " + Co_Code);
                if (dt.Rows.Count > 0)
                {
                    cmbClient.LookUpTable = dt;
                    cmbClient.ReturnIndex = 1;
                }
            }
        }

        private void cmbClient_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbClient.ReturnValue))
            {
                Client_Id = Convert.ToInt32(cmbClient.ReturnValue);
            }
        }
    }
}
