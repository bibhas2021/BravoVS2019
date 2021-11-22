using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class Config_ExGratia : EDPComponent.FormBaseERP 
    {
        public Config_ExGratia()
        {
            InitializeComponent();
        }

        #region Function 

        private void GetAllExgratia()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select ExGratia_Name,Session,ExGratia_Id from tbl_Employee_Config_Exgratia where Session=" + cmbYear.Text.Trim() + "");
            cmbExgratiaName.LookUpTable = dt;
            cmbExgratiaName.ReturnIndex =2;
        }

        private void GetExgratiaDetails()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_Exgratia where Session=" + cmbYear.Text.Trim() + " and ExGratia_Id=" + cmbExgratiaName.ReturnValue + "");
            if (dt.Rows.Count > 0)
            {
               if(!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Month"])))
               {
                   if(Convert.ToString(dt.Rows[0]["Month"]).Contains("|"))
                   {
                       String[] strArrMonth=Convert.ToString(dt.Rows[0]["Month"]).Split('|');
                       
                       if (!String.IsNullOrEmpty(strArrMonth[0]))
                       {
                           cmbFromMonth_DropDown(cmbFromMonth, new EventArgs());
                           cmbFromMonth.SelectedItem = clsEmployee.GetMonthName(Convert.ToInt32(strArrMonth[0]));                           
                       }
                       if (!String.IsNullOrEmpty(strArrMonth[0]))
                       {                           
                           cmbToMonth_DropDown(cmbFromMonth, new EventArgs());
                           cmbToMonth.SelectedItem = clsEmployee.GetMonthName(Convert.ToInt32(strArrMonth[strArrMonth.Length - 1]));
                       }
                   }
               }

               if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PayMonth"])))
               {
                   cmbPayMonth_DropDown(cmbPayMonth, new EventArgs());
                   cmbPayMonth.SelectedItem = clsEmployee.GetMonthName(Convert.ToInt32(dt.Rows[0]["PayMonth"]));
               }

               if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Mode"])))
               {
                   if (Convert.ToString(dt.Rows[0]["Mode"]).ToLower() == "percentage")
                   {
                       rdoPercentage.Checked = true;
                       rdoAmount.Checked = false;
                   }
                   else if (Convert.ToString(dt.Rows[0]["Mode"]).ToLower() == "amount")
                   {
                       rdoPercentage.Checked = false;
                       rdoAmount.Checked = true;
                   }
                   else
                   {
                       rdoPercentage.Checked = false;
                       rdoAmount.Checked = false;
                   }
               }
               else
               {
                   rdoPercentage.Checked = false;
                   rdoAmount.Checked = false;
               }

               if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Amount"])))
               {
                   txtAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
               }

               if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["MaxPay"])))
               {
                   txtMaxPay.Text = Convert.ToString(dt.Rows[0]["MaxPay"]);
               }
            }                
        }

        private void ClearDetails()
        {
            cmbYear.SelectedIndex = 0;
            cmbExgratiaName.Text = String.Empty;
            cmbFromMonth.Items.Clear();
            cmbToMonth.Items.Clear();
            cmbPayMonth.Items.Clear();
            rdoPercentage.Checked = false;
            rdoAmount.Checked = false;
            txtAmount.Text = String.Empty;
            txtAmount.Enabled = false;
            txtAmount.BackColor = Color.Silver;
            txtMaxPay.Text = String.Empty;
            lblExg.Text = String.Empty;
        }

        private Boolean ExRecordForExgratia(Int32 intExgratiaId)
        {
            Boolean boolstatus = false;
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_ExgratiaGiven where ExgratiaId=" + intExgratiaId + " and ExgGiven=1");
            if (dt.Rows.Count > 0)
            {
                boolstatus = true;
            }
            return boolstatus;
        }

        private void SubmitDetails()
        {
            Boolean boolStatus = false;
            String strMonth = String.Empty;
            String strPayMode=String.Empty;

            for (Int32 i = clsEmployee.GetMonth_SingleDigit(cmbFromMonth.Text.Trim()); i <= clsEmployee.GetMonth_SingleDigit(cmbToMonth.Text.Trim()); i++)
            {
                strMonth += Convert.ToString(i) + "|";
            }
            if (!String.IsNullOrEmpty(strMonth))
            {
                strMonth = strMonth.Substring(0, strMonth.LastIndexOf("|"));
            }

            if (rdoAmount.Checked)
            {
                strPayMode = "Amount";
            }
            else if (rdoPercentage.Checked)
            {
                strPayMode = "Percentage";
            }
            

            if (String.IsNullOrEmpty(lblExg.Text.Trim()))
            {
                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_Exgratia(ExGratia_Name,Session,Month,PayMonth,MaxPay,Mode,Amount) values('" + cmbExgratiaName.Text.Trim() + "'," + cmbYear.Text.Trim() + ",'" + strMonth + "'," + clsEmployee.GetMonth_SingleDigit(cmbPayMonth.Text.Trim()) + "," + txtMaxPay.Text.Trim() + ",'" + strPayMode + "',"+txtAmount.Text.Trim()+")");
            }
            else
            {
                if (!ExRecordForExgratia(Convert.ToInt32(cmbExgratiaName.ReturnValue)))
                {
                    boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Config_Exgratia set ExGratia_Name='" + cmbExgratiaName.Text.Trim() + "',Session=" + cmbYear.Text.Trim() + ",Month='" + strMonth + "',PayMonth=" + clsEmployee.GetMonth_SingleDigit(cmbPayMonth.Text.Trim()) + ",MaxPay=" + txtMaxPay.Text.Trim() + ", Mode='" + strPayMode + "',Amount=" + txtAmount.Text.Trim() + " where ExGratia_Id=" + cmbExgratiaName.ReturnValue + "");
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Unable to Update !!!"+ Environment.NewLine +" Ex-Gratia "+cmbExgratiaName.Text +" Is Already Allocated To Employees");
                }
            }
            if (boolStatus)
            {
                ERPMessageBox.ERPMessage.Show("Ex-Gratia Details Submitted Successfully");
                ClearDetails();
            }
        }

        private void DeleteDetails()
        {
            if (!String.IsNullOrEmpty(lblExg.Text.Trim()))
            {
                Boolean boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Employee_Config_Exgratia where ExGratia_Id="+lblExg.Text.Trim()+"");
                if (boolStatus)
                {
                    ERPMessageBox.ERPMessage.Show("Ex-Gratia Details Deleted Successfully");
                }
            }
        }

        private Boolean  Validation()
        {
            Boolean boolStatus = false;
            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Select Session"))
            {
                if (clsValidation.ValidateEdpCombo(cmbExgratiaName, "", "Please Select Ex-Gratia Name"))
                {
                    if (clsValidation.ValidateComboBox(cmbFromMonth, "", "Please Select From Month"))
                    {
                        if (clsValidation.ValidateComboBox(cmbToMonth, "", "Please Select To Month"))
                        {
                            if (clsValidation.ValidateComboBox(cmbPayMonth, "", "Please Select Pay Month"))
                            {
                                if (rdoPercentage.Checked || rdoAmount.Checked)
                                {
                                    String strMsg=String.Empty;
                                    if (rdoPercentage.Checked)
                                        strMsg = "Percentage";
                                    else if (rdoAmount.Checked)
                                        strMsg = "Amount";
                                    if (clsValidation.ValidateTextBox(txtAmount, "", "Please Enter " + strMsg))
                                    {
                                        if (clsValidation.ValidateComboBox(cmbPayMonth, "", "Please Select Maximum Pay"))
                                        {
                                            boolStatus = true;
                                        }
                                    }
                                }
                                else
                                {
                                    ERPMessageBox.ERPMessage.Show("Please Enter Payment Mode");
                                }
                            }
                        }
                    }

                }
            }
            return boolStatus;
        }

        private void CheckPayMode()
        {
            if (rdoPercentage.Checked)
            {
                txtAmount.Enabled = true;
                txtAmount.Text = String.Empty;
                txtAmount.BackColor = Color.White;
                lblText.Text = "% of Total Salary";
            }
            else if (rdoAmount.Checked)
            {
                txtAmount.Enabled = true;
                txtAmount.Text = String.Empty;
                txtAmount.BackColor = Color.White;
                lblText.Text = "( Rs. )";
            }
            else
            {
                txtAmount.Enabled = false;
                txtAmount.Text = String.Empty;
                txtAmount.BackColor = Color.Silver;
                lblText.Text = String.Empty;
            }
        }

        #endregion

        private void Config_ExGratia_Load(object sender, EventArgs e)
        {
            //generate year
            clsEmployee.GenerateYear(cmbYear);
            //
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbExgratiaName_DropDown(object sender, EventArgs e)
        {
            GetAllExgratia();
        }

        private void cmbExgratiaName_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            GetExgratiaDetails();
            lblExg.Text = cmbExgratiaName.ReturnValue;
        }

        private void cmbFromMonth_DropDown(object sender, EventArgs e)
        {
            cmbFromMonth.Items.Add("January");
            cmbFromMonth.Items.Add("February");
            cmbFromMonth.Items.Add("March");
            cmbFromMonth.Items.Add("April");
            cmbFromMonth.Items.Add("May");
            cmbFromMonth.Items.Add("June");
            cmbFromMonth.Items.Add("July");
            cmbFromMonth.Items.Add("August");
            cmbFromMonth.Items.Add("September");
            cmbFromMonth.Items.Add("October");
            cmbFromMonth.Items.Add("November");
            cmbFromMonth.Items.Add("December");
        }

        private void cmbToMonth_DropDown(object sender, EventArgs e)
        {
            cmbToMonth.Items.Add("January");
            cmbToMonth.Items.Add("February");
            cmbToMonth.Items.Add("March");
            cmbToMonth.Items.Add("April");
            cmbToMonth.Items.Add("May");
            cmbToMonth.Items.Add("June");
            cmbToMonth.Items.Add("July");
            cmbToMonth.Items.Add("August");
            cmbToMonth.Items.Add("September");
            cmbToMonth.Items.Add("October");
            cmbToMonth.Items.Add("November");
            cmbToMonth.Items.Add("December");
        }

        private void cmbPayMonth_DropDown(object sender, EventArgs e)
        {
            cmbPayMonth.Items.Add("January");
            cmbPayMonth.Items.Add("February");
            cmbPayMonth.Items.Add("March");
            cmbPayMonth.Items.Add("April");
            cmbPayMonth.Items.Add("May");
            cmbPayMonth.Items.Add("June");
            cmbPayMonth.Items.Add("July");
            cmbPayMonth.Items.Add("August");
            cmbPayMonth.Items.Add("September");
            cmbPayMonth.Items.Add("October");
            cmbPayMonth.Items.Add("November");
            cmbPayMonth.Items.Add("December");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SubmitDetails();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ERPMessageBox.ERPMessage.Show("Are You Sure?", "Confirmation", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
            if (ERPMessageBox.ERPMessage.ButtonResult.Trim().ToLower() == "edpyes")
            {
                DeleteDetails();
            }
        }

        private void rdoPercentage_CheckedChanged(object sender, EventArgs e)
        {
            CheckPayMode();
        }

        private void rdoAmount_CheckedChanged(object sender, EventArgs e)
        {
            CheckPayMode();
        }
    }
}