using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using EDPComponent;
using Edpcom;
using System.Collections;

namespace PayRollManagementSystem
{
    public partial class frmEmployeeDesignationWiseClientBilling : EDPComponent.FormBaseERP
    {
        string CompID = "",ClientID="",DesgID = "";
        ArrayList OrdrList = new ArrayList();

        public frmEmployeeDesignationWiseClientBilling()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmEmployeeDesignationWiseClientBilling_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbSession, 2015, System.DateTime.Now.Year, 1);
            int currentMonth = System.DateTime.Now.Month;
            var months = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames;
            cmbMonth.DataSource = months;
            int setMonth = currentMonth - 2;

            //For setting the previous month of current system month as default
            if (setMonth >= 0)
            {
                cmbMonth.SelectedIndex = setMonth;
            }
            else
            {
                cmbMonth.SelectedIndex = 12 - setMonth;
            }

            //If current month is less than April then the previous or secoend indexed session will be selected automatically as default
            if (currentMonth >= 4)
                cmbSession.SelectedIndex = 0;
            else
                cmbSession.SelectedIndex = 1;
        }

        private void cmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
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
                CompID = cmbCompany.ReturnValue;
            }
        }

        private void cmbClient_DropDown(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(CompID))
            {
                DataTable dtClntDrpDwn = clsDataAccess.RunQDTbl("select [Client_Name],[Client_id] from [tbl_Employee_CliantMaster] where [coid] = " + CompID);
                if (dtClntDrpDwn.Rows.Count > 0)
                {
                    cmbClient.LookUpTable = dtClntDrpDwn;
                    cmbClient.ReturnIndex = 1;
                }
            }
            else
                EDPMessageBox.EDPMessage.Show("Select company name first.");
        }

        private void cmbClient_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbClient.ReturnValue))
            {
                ClientID = cmbClient.ReturnValue;
            }
        }

        private void cmbDesignation_DropDown(object sender, EventArgs e)
        {
            DataTable dtDesignationDrpDwn = clsDataAccess.RunQDTbl("select [DesignationName],[SlNo] from [tbl_Employee_DesignationMaster]");
            if (dtDesignationDrpDwn.Rows.Count > 0)
            {
                cmbDesignation.LookUpTable = dtDesignationDrpDwn;
                cmbDesignation.ReturnIndex = 1;
            }
        }

        private void cmbDesignation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbDesignation.ReturnValue))
            {
                DesgID = cmbDesignation.ReturnValue;
            }
        }

        private void btnBrowseLoc_Click(object sender, EventArgs e)
        {
            string[] StrLine = this.cmbSession.Text.Trim().Split('-');
            string firstDate = "", lastDate = "",mnValue = "";
            if (cmbMonth.SelectedIndex <= 2)
            {
                firstDate = StrLine[1]+"-"+(cmbMonth.SelectedIndex+1)+"-01";
                lastDate = StrLine[1] + "-" + (cmbMonth.SelectedIndex + 1) + "-" + DateTime.DaysInMonth(Convert.ToInt32(StrLine[1]), (cmbMonth.SelectedIndex + 1)).ToString();
            }
            else if (cmbMonth.SelectedIndex > 2)
            {
                firstDate = StrLine[0] + "-" + (cmbMonth.SelectedIndex + 1) + "-01";
                lastDate = StrLine[0] + "-" + (cmbMonth.SelectedIndex + 1) + "-" + DateTime.DaysInMonth(Convert.ToInt32(StrLine[0]), (cmbMonth.SelectedIndex + 1)).ToString();
            }

            try
            {
                String sqlLocGet = "select odd.Order_Name,pb.Location,odd.Order_Date from (select [Location],rtrim(ltrim([Order_Name])) as 'Order_Name',Co_Code,Cliant_ID from [tbl_Employee_OrderDetails]) pb inner join tbl_Employee_OrderDetails_Dtl odd on odd.Order_Name = pb.Order_Name where desig_ID = " + DesgID + " and Cliant_ID = " + ClientID + " and Co_Code = " + CompID + " and Order_Date between '" + firstDate + "' and '" + lastDate + "'";
                DataTable dtsqlLocGet = clsDataAccess.RunQDTbl(sqlLocGet);
                if (dtsqlLocGet.Rows.Count > 0)
                {


                    EDPCommon.MLOV_EDP(sqlLocGet, "Tag Item", "Select Item Name", "List of Item Name", 0, "CMPN", 0);
                    OrdrList.Clear();
                    OrdrList = EDPCommon.arr_mod;
                }
            }
            catch
            { }
        }



    }
}
