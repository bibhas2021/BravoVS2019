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
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select chk_active_limit,limit_gross,chk_active_limit_esi,limit_gross_esi,chk_cont_type from CompanyLimiter");

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["chk_active_limit"].ToString().Trim() == "1")
                {
                    chk_activate_limit_PF.Checked = true;
                }
                else
                {
                    chk_activate_limit_PF.Checked = false;
                }
                
                txtGross_PF.Text = dt.Rows[0]["limit_gross"].ToString().Trim();



                if (dt.Rows[0]["chk_active_limit_esi"].ToString().Trim() == "1")
                {
                    chk_activate_limit_ESI.Checked = true;
                }
                else
                {
                    chk_activate_limit_ESI.Checked = false;
                }



                if (dt.Rows[0]["chk_cont_type"].ToString().Trim() == "1")
                {
                    chkLocContribution.Checked = true;
                }
                else
                {
                    chkLocContribution.Checked = false;
                }

                txtGross_ESI.Text = dt.Rows[0]["limit_gross_esi"].ToString().Trim();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string chk_limit = "0", gross = "0", chk_limit_esi = "0", gross_esi = "0", chk_cont_type="0";
            if (chk_activate_limit_PF.Checked == true)
            {
                chk_limit = "1";
            }
            try
            {
                if (Convert.ToDouble(txtGross_PF.Text) > 0)
                {
                    gross = txtGross_PF.Text;
                }
            }
            catch { gross = "15000.00"; }

            if (chk_activate_limit_ESI.Checked == true)
            {
                chk_limit_esi = "1";
            }
            try
            {
                if (Convert.ToDouble(txtGross_ESI.Text) > 0)
                {
                    gross_esi = txtGross_ESI.Text;
                }
            }
            catch { gross_esi = "21000.00"; }
            if (chkLocContribution.Checked == true)
            {
                chk_cont_type = "1";
            }
            else
            {
                chk_cont_type = "0";
            }
            bool bl = clsDataAccess.RunQry("update CompanyLimiter set chk_active_limit='" + chk_limit + "',limit_gross='" + gross + "',chk_active_limit_esi='" + chk_limit_esi + "',limit_gross_esi='" + gross_esi + "',chk_cont_type='" + chk_cont_type + "'");
            if (bl == true)
            {

                MessageBox.Show("Record Accepted", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Check Record", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
