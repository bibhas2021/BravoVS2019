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
    public partial class frmCompanySACMaster : Form
    {
        int SacGst = 0;
        public frmCompanySACMaster()
        {
            InitializeComponent();
        }

        private void frmCompanySACMaster_Load(object sender, EventArgs e)
        {
            SacGst = Convert.ToInt32(clsDataAccess.ReturnValue("select SacGst from CompanyLimiter"));
            btnSave.Text = "Save SAC";
            this.FormBorderStyle = FormBorderStyle.None;
            OnLoad();
        }

        private void OnLoad()
        {
            serviceNameTextBox.Text = "";
            SACNoTextBox.Text = "";
            serviceNoLabel.Text = "";
            txtGstPer.Text = "0";

            btnSave.Text = "Save SAC";
            
            sacDetDGView.Rows.Clear();
            sacDetDGView.Refresh();
            
            DataTable getSACDet = clsDataAccess.RunQDTbl("select * from CompanySACMaster");
            for (int index = 0; index < getSACDet.Rows.Count; index++)
            {
                sacDetDGView.Rows.Add();
                sacDetDGView.Rows[index].Cells["srvcNo"].Value = getSACDet.Rows[index]["slno"];
                sacDetDGView.Rows[index].Cells["srvcName"].Value = getSACDet.Rows[index]["serviceName"];
                sacDetDGView.Rows[index].Cells["sacNo"].Value = getSACDet.Rows[index]["sacNo"];
                sacDetDGView.Rows[index].Cells["GstPer"].Value = getSACDet.Rows[index]["GstPer"];
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string srvcNo = serviceNoLabel.Text.Trim();
            if (srvcNo != "")
            {
                btnSave.Text = "Update SAC";
                UpdateSacDetails();
            }
            else
            {
                btnSave.Text = "Save SAC";
                SaveSacDetails();
            }
            OnLoad();
            
        }

        private void sacDetDGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedCellRow = sacDetDGView.CurrentCell.RowIndex;
            serviceNameTextBox.Text = Convert.ToString(sacDetDGView.Rows[selectedCellRow].Cells["srvcName"].Value);
            SACNoTextBox.Text = Convert.ToString(sacDetDGView.Rows[selectedCellRow].Cells["sacNo"].Value);
            serviceNoLabel.Text = Convert.ToString(sacDetDGView.Rows[selectedCellRow].Cells["srvcNo"].Value);

            txtGstPer.Text = Convert.ToString(sacDetDGView.Rows[selectedCellRow].Cells["GstPer"].Value);


              string srvcNo = serviceNoLabel.Text.Trim();
              if (srvcNo != "")
              {
                  btnSave.Text = "Update SAC";
              }
              else
              {
                  btnSave.Text = "Save SAC";
              }
        }

        private void SaveSacDetails()
        {
            Boolean flagInsert = false;
            string maxSACID = "",gst_per="0";

            maxSACID = Convert.ToString(clsDataAccess.RunQDTbl("select max(slno) from CompanySACMaster").Rows[0][0]);
            if (maxSACID == "")
                maxSACID = "1";
            else if (Information.IsNumeric(maxSACID))
                maxSACID = Convert.ToString(Convert.ToInt32(maxSACID) + 1);
            else
            {
                EDPMessageBox.EDPMessage.Show("Something went wrong. Please contact with Bravo Software.");
                return;
            }

            try
            {
                gst_per = txtGstPer.Text.Trim();

            }
            catch { gst_per = "0"; }

            DataTable dtSavingValidity = clsDataAccess.RunQDTbl("select slno from CompanySACMaster where sacNo = '" + SACNoTextBox.Text.Trim() + "'");
            if (dtSavingValidity.Rows.Count == 0)
            {
                Boolean flagSvnametb = true;
                Boolean flagSacnotb = true;
                if (serviceNameTextBox.Text.Trim() == "")
                {
                    flagSvnametb = false;
                }
                if (SACNoTextBox.Text.Trim() == "")
                {
                    flagSacnotb = false;
                }
                if (flagSacnotb && flagSvnametb)
                    flagInsert = clsDataAccess.RunNQwithStatus("insert into CompanySACMaster values(" + maxSACID + ",'" + serviceNameTextBox.Text.Trim() + "','" + SACNoTextBox.Text.Trim() + "','"+gst_per+"')");
                else
                {
                    EDPMessageBox.EDPMessage.Show("Please enter both service name and SAC no.");
                    return;
                }

                if (flagInsert)
                {
                    EDPMessageBox.EDPMessage.Show("SAC no. has been saved successfully.");
                    OnLoad();
                }
                else
                    EDPMessageBox.EDPMessage.Show("Something went wrong during insertion of SAC no.");
            }
            else
            {
                EDPMessageBox.EDPMessage.Show("This SAC no already exists.Please check the SAC no or trt to update the previous SAC no.");
            }
        }

        private void UpdateSacDetails()
        {
            string srvcNo = serviceNoLabel.Text.Trim(), gst_per = "0"; 
            if (srvcNo != "")
            {
                try
                {
                    gst_per = txtGstPer.Text.Trim();

                }
                catch { gst_per = "0"; }

                DataTable dtOrderFBDetails, dtEmployeeOrderDetails, dtPaybill, dtPaybilld, dtPaybillo;
                Boolean flgUpdate = false;

                dtOrderFBDetails = clsDataAccess.RunQDTbl("select SAC from tbl_order_FB_detail where SAC = '" + srvcNo + "'");
                dtEmployeeOrderDetails = clsDataAccess.RunQDTbl("select SAC from tbl_Employee_OrderDetails_Dtl where SAC = '" + srvcNo + "'");
                dtPaybill = clsDataAccess.RunQDTbl("select SAC from paybill where SAC = '" + srvcNo + "'");
                dtPaybilld = clsDataAccess.RunQDTbl("select * from paybillD where SAC = '" + srvcNo + "'");
                dtPaybillo = clsDataAccess.RunQDTbl("select * from paybillO where SAC = '" + srvcNo + "'");

                //Checking for update validity
                if (dtPaybilld.Rows.Count > 0 || dtPaybillo.Rows.Count > 0 || dtPaybill.Rows.Count > 0 || dtOrderFBDetails.Rows.Count > 0 || dtEmployeeOrderDetails.Rows.Count > 0)
                {
                    Boolean flagSvnametb = true;
                    Boolean flagSacnotb = true;
                    if (serviceNameTextBox.Text.Trim() == "")
                    {
                        flagSvnametb = false;
                    }
                    if (SACNoTextBox.Text.Trim() == "")
                    {
                        flagSacnotb = false;
                    }
                    if (flagSacnotb && flagSvnametb)
                    {
                        DataTable dtChkChangeOfSacNo = clsDataAccess.RunQDTbl("select * from CompanySACMaster where sacNo = '" + SACNoTextBox.Text.Trim() + "' and slno = " + srvcNo);
                        if (dtChkChangeOfSacNo.Rows.Count == 0)
                        {
                            EDPMessageBox.EDPMessage.Show("You can't change the SAC no as it has already been used in Contract or Bill, you can only modify the service name." + Environment.NewLine + "Or you can save a new SAC number.");
                            return;
                        }
                        else
                            flgUpdate = clsDataAccess.RunNQwithStatus("UPDATE CompanySACMaster set [serviceName] = '" + serviceNameTextBox.Text.Trim() + "',[sacNo] = '" + SACNoTextBox.Text.Trim() + "',[GstPer]='" + gst_per + "' where [slno] =" + srvcNo);
                    }
                    else
                    {
                        EDPMessageBox.EDPMessage.Show("Please enter both service name and SAC no.");
                        return;
                    }
                }
                else
                {
                    Boolean flagSvnametb = true;
                    Boolean flagSacnotb = true;
                    if (serviceNameTextBox.Text.Trim() == "")
                    {
                        flagSvnametb = false;
                    }
                    if (SACNoTextBox.Text.Trim() == "")
                    {
                        flagSacnotb = false;
                    }
                    if (flagSacnotb && flagSvnametb)
                        flgUpdate = clsDataAccess.RunNQwithStatus("UPDATE CompanySACMaster set [serviceName] = '" + serviceNameTextBox.Text.Trim() + "',[sacNo] = '" + SACNoTextBox.Text.Trim() + "',[GstPer]='" + gst_per + "' where [slno] = " + srvcNo);
                    else
                    {
                        EDPMessageBox.EDPMessage.Show("Please enter both service name and SAC no.");
                        return;
                    }
                }
                if (flgUpdate)
                    EDPMessageBox.EDPMessage.Show("SAC details updated successfully.");
                else
                {
                    EDPMessageBox.EDPMessage.Show("Something went wrong during updation.");
                }
            }
            else
            {
                EDPMessageBox.EDPMessage.Show("Please select a service name from following list before updation.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateSacDetails();
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            OnLoad();
        }
    }
}
