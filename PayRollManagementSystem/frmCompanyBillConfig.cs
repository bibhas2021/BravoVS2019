using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmCompanyBillConfig : Form
    {
        public frmCompanyBillConfig()
        {
            InitializeComponent();
        }
        string CompID = "1";


        public void details()
        {
            string details = clsDataAccess.ReturnValue("select distinct ODetails FROM Branch where (GCODE='" + CompID + "') and (BRNCH_CODE=1)");
            string termscondition = clsDataAccess.ReturnValue("select distinct termscondition FROM Branch where (GCODE='" + CompID + "') and (BRNCH_CODE=1)");

            if (details.Trim() != "")
            {
                txt_Odetails.Text = details.Trim();
            }
            if(termscondition.Trim()!="")
            {
                txtTermsConditions.Text = termscondition.Trim();
            }
        }


        private void frmCompanyBillConfig_Load(object sender, EventArgs e)
        {
            txt_Odetails.Text = "";
            cmbcompany.PopUp();
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 1)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                cmbcompany.ReturnValue = dt.Rows[0]["CO_CODE"].ToString();
                cmbcompany.Text = dt.Rows[0]["CO_NAME"].ToString();
                CompID = cmbcompany.ReturnValue.ToString().Trim();
                details();
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            CompID = cmbcompany.ReturnValue.ToString().Trim();
            details();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bl = clsDataAccess.RunQry("update Branch set ODetails='" + txt_Odetails.Text + "',termscondition='"+txtTermsConditions.Text.Trim()+"' where (GCODE='" + CompID + "')");

             if (bl == true)
             {
                 MessageBox.Show("Record Updated");
             }
        }
    }
}
