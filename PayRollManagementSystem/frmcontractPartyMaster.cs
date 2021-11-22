using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;

namespace PayRollManagementSystem
{
    public partial class frmcontractPartyMaster : EDPComponent.FormBaseERP
    {

        Boolean boolPermissionNewClientEntry = false;
        int defaultClientLimit = 100;

        public frmcontractPartyMaster()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmcompanyMaster cm = new frmcompanyMaster();
            cm.getcode(0, "P");
            cm.ShowDialog();
            GetDetails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int co_code = Convert.ToInt32(dgCatg.Rows[dgCatg.CurrentRow.Index].Cells["Slno"].Value);
            DataTable dt = clsDataAccess.RunQDTbl("Select Location_ID from tbl_Emp_Location where Cliant_ID='" + co_code + "' ");
            if (dt.Rows.Count == 0)
            {
                if (Information.IsNumeric(dgCatg.Rows[dgCatg.CurrentRow.Index].Cells["Slno"].Value) == true)
                {
                    Boolean boolStatus = false;
                    boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Employee_CliantMaster where Client_id=" + co_code + "");

                    if (boolStatus)
                    {
                        ERPMessageBox.ERPMessage.Show("Client Name Deleted Successfully");
                        GetDetails();
                    }
                }
            }
            else
                ERPMessageBox.ERPMessage.Show("Client Name Already Use");

        }

        private void GetDetails()
        {
            txtSearch.Text = "";
            DataTable dt = clsDataAccess.RunQDTbl("Select Client_id,Client_Name,(select CO_NAME from Company where GCODE=cm.coid)Company_Name from tbl_Employee_CliantMaster cm");
            if (dt.Rows.Count > 0)
            {
                dgCatg.DataSource = dt;
            }

            DataTable dtCompanyLimiter = clsDataAccess.RunQDTbl("select ClientLimit,LocLimit from CompanyLimiter");
            int count_client = Convert.ToInt32(clsDataAccess.RunQDTbl("select count(*)as 'TR' from [tbl_Employee_CliantMaster]").Rows[0][0]);

           
            if (count_client == 0)
                btnSave.Enabled = true;
            else
            {

                if (dtCompanyLimiter.Rows.Count > 0)
                {
                    if (count_client < Convert.ToInt32(dtCompanyLimiter.Rows[0]["ClientLimit"]) || Convert.ToInt32(dtCompanyLimiter.Rows[0]["ClientLimit"]) == 0)
                        btnSave.Enabled = true;
                    else
                    {
                        btnSave.Enabled = false;
                        MessageBox.Show("Client Limit Reached in your version right now." + Environment.NewLine + "Please contact support@edpsoft.com or" + Environment.NewLine + "Call : 033-40003855", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    btnSave.Enabled = false;
                    MessageBox.Show("Client Limit Reached in your version right now." + Environment.NewLine + "Please contact support@edpsoft.com or" + Environment.NewLine + "Call : 033-40003855", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
          

        }

        private void frmcontractPartyMaster_Load(object sender, EventArgs e)
        {
            this.HeaderText = "Client Master";
            txtSearch.Focus();
            ////Added by dwipraj dutta 18092017
            //string filePath = "";
            //filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
            //string lineForConfigSetting;
            //if (File.Exists(filePath))
            //{
            //    StreamReader file = null;
            //    try
            //    {
            //        file = new StreamReader(filePath);
            //        if (file.ReadLine() != null)
            //        {
            //            int chk_str = 0;
            //            while ((lineForConfigSetting = file.ReadLine()) != null)
            //            {
            //                string[] StrSTAR = lineForConfigSetting.Trim().Split('*');
            //                if (StrSTAR.Length == 2)
            //                {
            //                    if (StrSTAR[0].Trim() == "")
            //                        continue;
            //                }

            //                string[] StrLine = lineForConfigSetting.Trim().Split('[');
            //                if (StrLine.Length == 2)
            //                {
            //                    string str = lineForConfigSetting.Substring(1, lineForConfigSetting.Length - 2);
            //                    if (str.ToUpper() == "CLIENT_ENTRY_LIMITER")
            //                        chk_str = 1;
            //                }

            //                string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
            //                if ((chk_str == 1) && (StrLine_WACC.Length > 1))
            //                {
            //                    if (Information.IsNumeric(StrLine_WACC[0]))
            //                    {
            //                        DataTable dtCountClient = clsDataAccess.RunQDTbl("select count(*) as 'TotalRecord' from [tbl_Employee_CliantMaster]");
            //                        if(Convert.ToInt32(dtCountClient.Rows[0][0])<Convert.ToInt32(StrLine_WACC[0]))
            //                        {
            //                            boolPermissionNewClientEntry = true;
            //                        }
            //                    }
            //                    else if (StrLine_WACC[0] == "EDP_BRAVO_UNLIMITED")
            //                        boolPermissionNewClientEntry = true;
            //                    else
            //                    {
            //                        DataTable dtCountClient = clsDataAccess.RunQDTbl("select count(*) as 'TotalRecord' from [tbl_Employee_CliantMaster]");
            //                        if (Convert.ToInt32(dtCountClient.Rows[0][0]) < defaultClientLimit)
            //                        {
            //                            boolPermissionNewClientEntry = true;
            //                        }
            //                    }
                                
            //                    chk_str = 0;
            //                }
            //            }
            //        }

            //    }
            //    catch
            //    { }
            //}
            btnSave.Visible = true;// boolPermissionNewClientEntry;

            GetDetails();
        }

        private void dgCatg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int co_code = 0;
            if (Information.IsNumeric(dgCatg.Rows[e.RowIndex].Cells["Slno"].Value) == true)
            {
                co_code = Convert.ToInt32(dgCatg.Rows[e.RowIndex].Cells["Slno"].Value);
                frmcompanyMaster cm = new frmcompanyMaster();
                cm.getcode(co_code,"P");
                cm.ShowDialog();
                GetDetails();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim()!="")
            {
                
                //dgCatg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //try
                //{
                //    string searchValue = txtSearch.Text.Trim();
                //    foreach (DataGridViewRow row in dgCatg.Rows)
                //    {
                //        row.DefaultCellStyle.BackColor = Color.White;
                //        if (row.Cells[1].Value.ToString().ToLower().Contains(searchValue))
                //        {               
                //            row.Selected = true;
                            
                //            dgCatg.Rows[row.Index].DefaultCellStyle.BackColor = Color.YellowGreen;

                //            dgCatg.ClearSelection();
                           
                //        }
                        
                //    }
                //}
                //catch {}


                DataTable dt = clsDataAccess.RunQDTbl("Select Client_id,Client_Name from tbl_Employee_CliantMaster where Client_Name like '%"+txtSearch.Text.Trim()+"%'");
                if (dt.Rows.Count > 0)
                {
                    dgCatg.DataSource = dt;
                }
            }
            else
            {
                DataTable dt = clsDataAccess.RunQDTbl("Select Client_id,Client_Name from tbl_Employee_CliantMaster");
                if (dt.Rows.Count > 0)
                {
                    dgCatg.DataSource = dt;
                }

                dgCatg.BackgroundColor=Color.White;
            }

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    
                    //int co_code = 0;
                    //if (Information.IsNumeric(dgCatg.Rows[0].Cells["Slno"].Value) == true)
                    //{
                    //    co_code = Convert.ToInt32(dgCatg.Rows[0].Cells["Slno"].Value);
                    //    frmcompanyMaster cm = new frmcompanyMaster();
                    //    cm.getcode(co_code, "P");
                    //    cm.ShowDialog();
                    //    GetDetails();
                    //}

                    dgCatg.Focus();
                }
            }
            catch { }
        }

        private void dgCatg_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int co_code = 0;
                int rw = dgCatg.CurrentCell.RowIndex-1;
                if (Information.IsNumeric(dgCatg.Rows[rw].Cells["Slno"].Value) == true)
                {
                    co_code = Convert.ToInt32(dgCatg.Rows[rw].Cells["Slno"].Value);
                    frmcompanyMaster cm = new frmcompanyMaster();
                    cm.getcode(co_code, "P");
                    cm.ShowDialog();
                    GetDetails();
                }

            }
        }
    }
}
