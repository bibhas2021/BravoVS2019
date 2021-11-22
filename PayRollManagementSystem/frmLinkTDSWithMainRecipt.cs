using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmLinkTDSWithMainRecipt : EDPComponent.FormBaseERP
    {
        string strBillNo = "",strMainVoucherNo = "",strTDSVoucherNo = "";
        public frmLinkTDSWithMainRecipt()
        {
            InitializeComponent();
        }

        private void frmLinkTDSWithMainRecipt_Load(object sender, EventArgs e)
        {

        }

        public void LoadBillNo(string BillNo)
        {
            strBillNo = BillNo;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbMainRecipt_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select [userVchNo] from [tbl_Payment_Register] where [billNo] = '"+strBillNo+"' and [tblName] = 'tbl_Payment_Receipt_Register'");
            if (dt.Rows.Count > 0)
            {
                cmbMainRecipt.LookUpTable = dt;
                cmbMainRecipt.ReturnIndex = 0;
            }
        }

        private void cmbMainRecipt_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (cmbMainRecipt.ReturnValue.Trim() != "")
            {
                strMainVoucherNo = cmbMainRecipt.ReturnValue;
            }
        }

        private void cmbTDSVoucher_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select [userVchNo] from [tbl_Payment_Register] where [billNo] = '" + strBillNo + "' and [tblName] = 'tbl_TDS_Register'");
            if (dt.Rows.Count > 0)
            {
                cmbTDSVoucher.LookUpTable = dt;
                cmbTDSVoucher.ReturnIndex = 0;
            }
        }

        private void cmbTDSVoucher_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (cmbTDSVoucher.ReturnValue.Trim() != "")
            {
                strTDSVoucherNo = cmbTDSVoucher.ReturnValue;
            }
        }

    }
}
