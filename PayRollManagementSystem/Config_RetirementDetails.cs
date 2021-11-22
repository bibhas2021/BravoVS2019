using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class Config_RetirementDetails : EDPComponent .FormBaseERP
    {
        public Config_RetirementDetails()
        {
            InitializeComponent();
        }

        #region Function

        private void GetDetails()
        {
            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Select Session"))
            {
                DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_Retirement where Session='" + cmbYear.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    btnSubmit.Text = "Update";
                    txtAge.Text = dt.Rows[0]["Age"].ToString();
                    txtPenssionAge.Text = dt.Rows[0]["PenssionAge"].ToString();
                    txtPfAge.Text = dt.Rows[0]["PFAge"].ToString();
                }
                else
                {
                    btnSubmit.Text = "Save";
                    txtAge.Text = String.Empty;
                    txtPenssionAge.Text = String.Empty;
                }
            }
        }

        private void SaveDetails()
        {
            Boolean boolStatus = false;
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_Retirement where Session='" + cmbYear.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                btnSubmit.Text = "Update";
                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Config_Retirement set Age=" + txtAge.Text.Trim() + ",PenssionAge =" + txtPenssionAge.Text.Trim() + ",PFAge=" + txtPfAge.Text.Trim() + " where SlNo=" + dt.Rows[0]["SlNo"] + "");
            }
            else
            {
                btnSubmit.Text = "Save";
                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_Retirement(Session,Age,PenssionAge,PFAge) values('" + cmbYear.Text.Trim() + "'," + txtAge.Text.Trim() + "," + txtPenssionAge.Text.Trim() + "," + txtPfAge.Text.Trim() + ")");
            }
            if (boolStatus)
            {
                ERPMessageBox.ERPMessage.Show("Retirement Details " + btnSubmit.Text.Trim() + " Successfully");
                ClearControl();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To " + btnSubmit.Text.Trim() + " Retirement Details");
            }
        }

        private void ClearControl()
        {
            btnSubmit.Text = "Save";
            cmbYear.Text = String.Empty;
            txtAge.Text = String.Empty;
            txtPenssionAge.Text = String.Empty;
            txtPfAge.Text = String.Empty;
        }

        #endregion

        private void Config_RetirementDetails_Load(object sender, EventArgs e)
        {
            
            //
            int mn = Convert.ToInt32(clsDataAccess.GetresultI("tbl_Employee_Config_Retirement", "PFAge"));
            string str = "";
            if (mn == 0)
            {
                str = "ALTER TABLE tbl_Employee_Config_Retirement ADD ";
               
                if (mn == 0)
                {
                    str = str + "[PFAge] [int] NULL ";
                    //str = str + " update tbl_Employee_Config_Retirement set [PFAge]=58 ";

                }

                bool rs = clsDataAccess.RunNQwithStatus(str);
            }
            //generate year
            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
            //

            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //generate year
            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
            //

            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }
            //
            txtAge.Text = String.Empty;
            txtPenssionAge.Text = String.Empty;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Enter Session"))
            {
                if (clsValidation.ValidateTextBox(txtAge, "", "Please Enter Employee's Age of Retirement"))
                {
                    if (clsValidation.ValidateTextBox(txtPenssionAge, "", "Please Enter Employee's Age of Penssion"))
                    {
                        if (clsValidation.ValidateTextBox(txtPfAge, "", "Please Enter Employee's Max Age of PF"))
                        {
                            if (Convert.ToInt32(txtAge.Text) == 0)
                            {
                                ERPMessageBox.ERPMessage.Show("Employee's Age of Retirement Cannot be 0");
                            }
                            else if (Convert.ToInt32(txtPenssionAge.Text) == 0)
                            {
                                ERPMessageBox.ERPMessage.Show("Employee's Age of Penssion Cannot be 0");
                            }
                            else if (Convert.ToInt32(txtPfAge.Text) == 0)
                            {
                                ERPMessageBox.ERPMessage.Show("Employee's Max Age of PF Cannot be 0");
                            }
                            else
                            {
                                SaveDetails();
                            }
                        }
                    }
                }
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDetails();
        }
    }
}