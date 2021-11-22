using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using Edpcom;
using FirstTimeNeed;

namespace PayRollManagementSystem
{
    public partial class PaymentRegisterForm : Form//EDPComponent.FormBaseERP
    {
        
        string company_id = clsDataAccess.RunQDTbl("select CO_CODE from Company").Rows[0][0].ToString().Trim();
        string location_id;
        string billNo;
        string client_id;
        SqlTransaction sqltran;
        ArrayList arr;
        SqlCommand cmd;
        bool bl_val, bl_tds, bl_oth;

        public PaymentRegisterForm()
        {
            InitializeComponent();
        }


        private void PaymentRegisterForm_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.HeaderText = "Bill Payment";
            onLoad();
        }

        private void onLoad()
        {
            location_id = "";
            billNo = "";
            client_id = "";
            sqltran = null;
            arr = new ArrayList();
            cmd = new SqlCommand();
/*---------------------------------------------------------------------Main Resetting Code----------------------------------------------------------------*/
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txtbox = (TextBox)control;
                    txtbox.Text = "";
                }
                else if (control is CheckBox)
                {
                    CheckBox chkbox = (CheckBox)control;
                    chkbox.Checked = false;
                }
                else if (control is RadioButton)
                {
                    RadioButton rdbtn = (RadioButton)control;
                    rdbtn.Checked = false;
                }
                else if (control is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)control;
                    dtp.Value = DateTime.Now;
                }
                else if (control is TabControl)
                {
                    foreach (Control pageControl in control.Controls)
                    {
                        foreach (Control cntrlInTabPage in pageControl.Controls)
                        {
                            if (cntrlInTabPage is GroupBox)
                            {
                                foreach (Control cntrlInGroupBox in cntrlInTabPage.Controls)
                                {
                                    if (cntrlInGroupBox is TextBox)
                                    {
                                        TextBox txtbox = (TextBox)cntrlInGroupBox;
                                        txtbox.Text = "";
                                    }
                                    else if (cntrlInGroupBox is DateTimePicker)
                                    {
                                        DateTimePicker dtp = (DateTimePicker)cntrlInGroupBox;
                                        dtp.Value = DateTime.Now;
                                    }
                                    else if (cntrlInGroupBox is EDPComponent.ComboDialog)
                                    {
                                        EDPComponent.ComboDialog cd = (EDPComponent.ComboDialog)cntrlInGroupBox;
                                        cd.Text = "";
                                    }
                                }
                            }
                            else if (cntrlInTabPage is TextBox)
                            {
                                TextBox txtbox = (TextBox)cntrlInTabPage;
                                txtbox.Text = "";
                            }
                            else if (cntrlInTabPage is DateTimePicker)
                            {
                                DateTimePicker dtp = (DateTimePicker)cntrlInTabPage;
                                dtp.Value = DateTime.Now;
                            }
                            else if (cntrlInTabPage is EDPComponent.ComboDialog)
                            {
                                EDPComponent.ComboDialog cd = (EDPComponent.ComboDialog)cntrlInTabPage;
                                cd.Text = "";
                            }
                        }
                    }
                }
                else if (control is EDPComponent.ComboDialog)
                {
                    EDPComponent.ComboDialog cd = (EDPComponent.ComboDialog)control;
                    cd.Text = "";
                }
            }
/*---------------------------------------------------------------End of Main Resetting Code---------------------------------------------------------------*/

            txtMainVoucher.ReturnIndex = -1;
            existingTDSVoucher.ReturnIndex = -1;
            othSelectVchNo.ReturnIndex = -1;

            

            chequeNoTextBox.ReadOnly = false;
            bankNameTextBox.ReadOnly = false;
            BranchNameTextBox.ReadOnly = false;
           
            if (rdbBank.Checked == true || rdbNEFT.Checked == true)
            {
                instrumentCleared.Enabled = true;
                instrumentIssueDate.Enabled = true;
                instrumentClearDate.Enabled = true;
            }
            else
            {
                instrumentCleared.Enabled = false;
                instrumentIssueDate.Enabled = false;
                instrumentClearDate.Enabled = false;
            }
            instrumentCleared.Checked = true;
            rdbBank.Checked = true;
            rdbCash.Checked = false;
            //tdsStatusCmbBox.SelectedIndex = 0;
            tdsConfirmation.Checked = false;
            certificateNoTextBox.Enabled = false;
            tdsCertificateDate.Enabled = false;

            clientName.Text = "";
            billDate.Text = "";
            billAmount.Text = "0.00";
            paidAmount.Text = "0.00";
            balAmount.Text = "0.00";
            lbl_balAmt.Text = "0.00";
            contextMonth.Text = "";
            billStatus.Text = "";

            txtMainVoucher.Text = bno();
            vchrNumber.Text = txtMainVoucher.Text;
            existingTDSVoucher.Text = txtMainVoucher.Text;
            tdsVoucherNumber.Text = txtMainVoucher.Text;
            othSelectVchNo.Text = txtMainVoucher.Text;
            othVoucherNumber.Text = txtMainVoucher.Text;
            HiddenHintLable.Text = "";
            HiddenHintLable.Visible = false;

            //if (Information.IsNumeric(givenAmountTextBox.Text) == false)
            //{
            //    givenAmountTextBox.Text = "0";
            //}
            //if (Information.IsNumeric(tdsAmountTextBox.Text) == false)
            //{
            //    tdsAmountTextBox.Text = "0";
            //}
            //if (Information.IsNumeric(othAmount.Text) == false)
            //{
            //    othAmount.Text = "0";
            //}
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {
                dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID in (" + edpcom.CurrentLocation + ")");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL");
            }
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            txtVoucherChallan.Text = "";//This will clear the field every time the location's value will selected
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                location_id = Convert.ToString(cmbLocation.ReturnValue.Trim());


            company_id = clsEmployee.GetCompany_ID(Convert.ToInt32(location_id)).ToString().Trim();
            dtpMonth.Focus();
        }
        public string bno()
        {
            int cnt = 0;
            try
            {
                cnt = Convert.ToInt32(clsDataAccess.GetresultS("select max(pid)+1 from tbl_Payment_Register where (pay_month='"+dtpMonth.Value.ToString("MMMM-yyyy")+"')"));
            }
            catch
            {
                cnt = 1;
            }
            lbl_bid.Text = cnt.ToString();
            return dtpMonth.Value.ToString("MMM/yy/"+cnt.ToString("00"));
        }
        private void txtVoucherChallan_DropDown(object sender, EventArgs e)
        {
            if (location_id != null || location_id != "")
            {
                DataTable dt = clsDataAccess.RunQDTbl("Select BILLNO,BILLDATE from paybill where BillStatus = 'ACTIVE' and Location_ID = " + location_id);//BillStatus = 'ACTIVE' has been added by dwipraj dutta 24102017
                if (dt.Rows.Count > 0)
                {
                    txtVoucherChallan.LookUpTable = dt;
                    txtVoucherChallan.ReturnIndex = 0;
                    txtVoucherChallan.Text = "";
                    givenAmountTextBox.Focus();
                }  
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Select location first.");
            }
        }

        private void txtVoucherChallan_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            txtMainVoucher.Text = bno();
            vchrNumber.Text = txtMainVoucher.Text;
            existingTDSVoucher.Text = txtMainVoucher.Text;
            tdsVoucherNumber.Text = txtMainVoucher.Text;
            othSelectVchNo.Text = txtMainVoucher.Text;
            othVoucherNumber.Text = txtMainVoucher.Text;

            existingTDSVoucher.ReturnValue = txtMainVoucher.Text;
            othSelectVchNo.ReturnValue = txtMainVoucher.Text;

            billNo = txtVoucherChallan.ReturnValue;
            
            LoadData(billNo);

            //existingMainVoucher_DropDown(sender, e);
            txtMainVoucher.PopUp();
        }

        private void LoadData(string billNo)
        {
            //throw new NotImplementedException();
            double paidbal = 0;
            string qry = "select Cliant_ID,CONVERT(VARCHAR(10), BILLDATE, 103) AS BILLDATE,Month,([TotAMT]+ServiceAmount+ScAmt) as 'TotAMT' from paybill where BILLNO = '" + billNo + "'";
            DataTable dt = clsDataAccess.RunQDTbl(qry);
            client_id = dt.Rows[0]["Cliant_ID"].ToString().Trim();
            clientName.Text = "";
            billDate.Text = dt.Rows[0]["BILLDATE"].ToString();
            billAmount.Text = dt.Rows[0]["TotAMT"].ToString();
            contextMonth.Text = dt.Rows[0]["Month"].ToString();

            clientName.Text = clsDataAccess.RunQDTbl("select Client_Name from tbl_Employee_CliantMaster where Client_id = " + client_id).Rows[0][0].ToString();

            Boolean flag = true;
            qry = "select userVchNo,tblName from tbl_Payment_Register where billNo = '"+billNo+"'";
            DataTable paidAmountRefTable = clsDataAccess.RunQDTbl(qry);
            for (int i = 0; i < paidAmountRefTable.Rows.Count; i++)
            {
                string statusGettingQry = "";
                DataTable statusGettingTable;
                string balanceGettingQry = "select amount from " + paidAmountRefTable.Rows[i]["tblName"] + " where vchrNo = '" + paidAmountRefTable.Rows[i]["userVchNo"] + "'";
                paidbal = paidbal + Convert.ToDouble(clsDataAccess.RunQDTbl(balanceGettingQry).Rows[0]["amount"].ToString());
                if (flag && paidAmountRefTable.Rows[i]["tblName"].ToString() == "tbl_Payment_Receipt_Register")
                {
                    statusGettingQry = "select reciptMmode,instrumentClearDate from tbl_Payment_Receipt_Register where vchrNo ='" + paidAmountRefTable.Rows[i]["userVchNo"] + "'";
                    statusGettingTable = clsDataAccess.RunQDTbl(statusGettingQry);
                    if (statusGettingTable.Rows[0]["reciptMmode"].ToString().Trim() == "C" || statusGettingTable.Rows[0]["reciptMmode"].ToString().Trim() == "N")
                    {
                        if (statusGettingTable.Rows[0]["instrumentClearDate"].ToString().Trim()=="")
                            flag = false;
                    }
                   
                }
                /*else if (flag && paidAmountRefTable.Rows[i]["tblName"].ToString() == "tbl_TDS_Register")
                {
                    statusGettingQry = "select tdsStatus from tbl_TDS_Register where vchrNo ='" + paidAmountRefTable.Rows[i]["userVchNo"] + "'";
                    statusGettingTable = clsDataAccess.RunQDTbl(statusGettingQry);
                    if (statusGettingTable.Rows[0][0].ToString().Trim() == "P")
                        flag = false;
                }*/
            }

            paidAmount.Text = paidbal.ToString();
            balAmount.Text = (Convert.ToDouble(billAmount.Text)-paidbal).ToString();
            lbl_balAmt.Text = (Convert.ToDouble(billAmount.Text) - paidbal).ToString();
            if (Convert.ToDouble(paidAmount.Text) == 0)
                billStatus.Text = "Outstanding";
            else if (!flag && Convert.ToDouble(balAmount.Text) <= 0)
                billStatus.Text = "Pending";
            else if (Convert.ToDouble(balAmount.Text) > 0)
                billStatus.Text = "Part Payment";
            else if (flag && Convert.ToDouble(balAmount.Text) <= 0)
                billStatus.Text = "Cleared";

            billAmount.Text = Math.Round(Convert.ToDouble(billAmount.Text)).ToString("N");
            paidAmount.Text = Math.Round(Convert.ToDouble(paidAmount.Text)).ToString("N");
            balAmount.Text = Math.Round(Convert.ToDouble(balAmount.Text)).ToString("N");
            lbl_balAmt.Text = Math.Round(Convert.ToDouble(lbl_balAmt.Text)).ToString("N");
            //-----Added at 040820170213PM[Dwipraj Dutta]: Reason : Only clear button will clear everything otherwise only tabcontrol will be cleared-------
            foreach (Control control in this.Controls)
            {
                if(control is TabControl)
                {
                    foreach (Control pageControl in control.Controls)
                    {
                        foreach (Control cntrlInTabPage in pageControl.Controls)
                        {
                            if (cntrlInTabPage is GroupBox)
                            {
                                foreach (Control cntrlInGroupBox in cntrlInTabPage.Controls)
                                {
                                    if (cntrlInGroupBox is TextBox)
                                    {
                                        TextBox txtbox = (TextBox)cntrlInGroupBox;
                                        txtbox.Text = "";
                                    }
                                    else if (cntrlInGroupBox is DateTimePicker)
                                    {
                                        DateTimePicker dtp = (DateTimePicker)cntrlInGroupBox;
                                        dtp.Value = DateTime.Now;
                                    }
                                    else if (cntrlInGroupBox is EDPComponent.ComboDialog)
                                    {
                                        EDPComponent.ComboDialog cd = (EDPComponent.ComboDialog)cntrlInGroupBox;
                                        cd.Text = "";
                                    }
                                }
                            }
                            else if (cntrlInTabPage is TextBox)
                            {
                                TextBox txtbox = (TextBox)cntrlInTabPage;
                                txtbox.Text = "";
                            }
                            else if (cntrlInTabPage is DateTimePicker)
                            {
                                DateTimePicker dtp = (DateTimePicker)cntrlInTabPage;
                                dtp.Value = DateTime.Now;
                            }
                            else if (cntrlInTabPage is EDPComponent.ComboDialog)
                            {
                                EDPComponent.ComboDialog cd = (EDPComponent.ComboDialog)cntrlInTabPage;
                                cd.Text = "";
                            }
                        }
                    }
                }
            }
            //------------------------------------------------End of 040820170213PM Editing-------------------------------------------------------


           // txtMainVoucher.Text = bno();
            vchrNumber.Text =txtMainVoucher.Text;
            existingTDSVoucher.Text =txtMainVoucher.Text;
            tdsVoucherNumber.Text =txtMainVoucher.Text;
            othSelectVchNo.Text =txtMainVoucher.Text;
            othVoucherNumber.Text = txtMainVoucher.Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCash.Checked == true)
            {
                chequeNoTextBox.ReadOnly = true;
                bankNameTextBox.ReadOnly = true;
                BranchNameTextBox.ReadOnly = true;
                instrumentIssueDate.Enabled = false;
                instrumentClearDate.Enabled = false;
                cashPaymentDate.Enabled = true;
                instrumentCleared.Enabled = false;

                instrumentCleared.Checked = true;
            }
            else
            {
                chequeNoTextBox.ReadOnly = false;
                bankNameTextBox.ReadOnly = false;
                BranchNameTextBox.ReadOnly = false;
                instrumentIssueDate.Enabled = true;
                if(instrumentCleared.Checked)
                    instrumentClearDate.Enabled = true;
                else
                    instrumentClearDate.Enabled = false;
                cashPaymentDate.Enabled = false;
                instrumentCleared.Enabled = true;
                instrumentCleared.Checked = true;
                if (rdbNEFT.Checked == true)
                {
                    bankNameTextBox.Text = "NEFT";
                }
                else
                {
                    bankNameTextBox.Text = "";
                }

            }
        }

        private void instrumentCleared_CheckedChanged(object sender, EventArgs e)
        {
            if (instrumentCleared.Checked == true)
            {
                instrumentClearDate.Enabled = true;
            }
            else
            {
                instrumentClearDate.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (location_id != "" && billNo != "")
            {
                RadioButton rb = null;
                   
                    if (rdbCash.Checked)
                        rb = rdbCash;
                    else if (rdbBank.Checked)
                        rb = rdbBank;
                    else
                        rb = rdbNEFT;

                    if (rb.Text.ToLower() == "cheque")
                    {
                        if (chequeNoTextBox.Text.Trim() == "" && bankNameTextBox.Text.Trim() == "")
                        {
                            MessageBox.Show("Cheque Number / Bank Name not given", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else if (rb.Text.ToLower() == "neft")
                    {
                        if (chequeNoTextBox.Text.Trim() == "")
                        {
                            MessageBox.Show("Please give IFSC Number ", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    bl_val = false; bl_tds = false; bl_oth = false;
                if (getMainVoucherUpdateValidity())
                {
                    updateMainPayment();
                }
                else
                {
                    saveMainPayment();
                }
                if (getTDSVoucherUpdateValidity())
                {
                    updateTDSDetails();
                }
                else
                {
                    saveTDSDetails();
                }
                if (getOTHVoucherUpdateValidity())
                {
                    updateOthDetails();
                }
                else
                {
                    saveOTHDetails();
                }


                if (bl_val == true || bl_tds == true || bl_oth == true)
                {
                    MessageBox.Show("Main transaction successfull", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            { 
                //Error message
            }

            LoadData(billNo);
            //btnCLear_Click(sender, e);
            onLoad();
        }


        private void saveMainPayment()
        {
            try
            {
                //Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                //edpcon.Open();
                //cmd.Connection = edpcon.mycon;
                //sqltran = edpcon.mycon.BeginTransaction();

                string insertionqry = "", remarks=txtRemarks.Text.Trim(), pay_month = dtpMonth.Value.ToString("MMMM-yyyy");
                int pid =Convert.ToInt32(lbl_bid.Text);

                if (vchrNumber.Text != "" && givenAmountTextBox.Text != "")
                {
                    RadioButton rb = null;
                    string recivemode = "";     //Define how the voucher payment has recived
                    int act = 0;
                    if (rdbCash.Checked)
                        rb = rdbCash;
                    else if (rdbBank.Checked)
                        rb = rdbBank;
                    else
                        rb = rdbNEFT;

                    if (rb.Text == "Cash")
                    {
                        insertionqry = "insert into tbl_Payment_Register (userVchNo,billNo,tblName,LocationId,CompanyId,ClientId,remarks,pay_month,pid,balamt,actbalamt) values ('" + vchrNumber.Text + "','" + billNo + "','tbl_Payment_Receipt_Register'," + location_id + "," + company_id + "," + client_id + ",'" + remarks + "','" + pay_month + "','" + pid + "','" + balAmount.Text + "','" + paidAmount.Text + "')";
                        clsDataAccess.RunQry(insertionqry);

                        //In next line 'H' stands for Cash or In Hand payment type
                        recivemode = "H";
                        if (instrumentCleared.Checked == true)
                        { act = 1;  }
                        else
                        { act = 0;  }
                        insertionqry = "insert into tbl_Payment_Receipt_Register (vchrNo,reciptMmode,amount,instumentDate,activation) values('" + vchrNumber.Text + "','" + recivemode + "'," + givenAmountTextBox.Text + ",'" + cashPaymentDate.Value.Date.ToString("yyyyMMdd") + "',"+act+")";
                        bl_val= clsDataAccess.RunQry(insertionqry);
                        //ERPMessageBox.ERPMessage.Show("Main Payment Record Inserted Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                    else
                    {
                        if (rdbBank.Checked)
                        {
                            recivemode = "C";
                            if (instrumentCleared.Checked == true)
                            {
                                act = 1;
                            }
                            else
                            {
                                act = 0;
                            }
                        }//If payment has made by cheque then it will be C
                        else
                        { 
                            recivemode = "N";
                            if (instrumentCleared.Checked == true)
                            {
                                act = 1;
                            }
                            else
                            {
                                act = 0;
                            }
                        } //If payment has made by NEFT then it will be N
                        if (chequeNoTextBox.Text != "" && bankNameTextBox.Text != "" )
                        {
                            insertionqry = "insert into tbl_Payment_Register (userVchNo,billNo,tblName,LocationId,CompanyId,ClientId,remarks,pay_month,pid,balamt,actbalamt) values ('" + vchrNumber.Text + "','" + billNo + "','tbl_Payment_Receipt_Register'," + location_id.Trim() + "," + company_id.Trim() + "," + client_id.Trim() + ",'" + remarks + "','" + pay_month + "','" + pid + "','" + balAmount.Text + "','" + paidAmount.Text + "')";
                            bl_val= clsDataAccess.RunQry(insertionqry);
                            if (instrumentCleared.Checked)
                            {
                                insertionqry = "insert into tbl_Payment_Receipt_Register (vchrNo,reciptMmode,amount,instumentDate,instrumentNo,bankName,branchName,instrumentClearDate,activation) values('" + vchrNumber.Text + "','" + recivemode + "'," + givenAmountTextBox.Text + ",'" + instrumentIssueDate.Value.Date.ToString("yyyyMMdd") + "','" + chequeNoTextBox.Text + "','" + bankNameTextBox.Text + "','" + BranchNameTextBox.Text + "','" + instrumentClearDate.Value.Date.ToString("yyyyMMdd") + "',"+act+")";
                                bl_val=clsDataAccess.RunQry(insertionqry);
                                ///ERPMessageBox.ERPMessage.Show("Main Payment Record Inserted Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                            }
                            else
                            {
                                insertionqry = "insert into tbl_Payment_Receipt_Register (vchrNo,reciptMmode,amount,instumentDate,instrumentNo,bankName,branchName,activation) values('" + vchrNumber.Text + "','" + recivemode + "'," + givenAmountTextBox.Text + ",'" + instrumentIssueDate.Value.Date.ToString("yyyyMMdd") + "','" + chequeNoTextBox.Text + "','" + bankNameTextBox.Text + "','" + BranchNameTextBox.Text + "',"+act+")";
                                bl_val =clsDataAccess.RunQry(insertionqry);
                                //ERPMessageBox.ERPMessage.Show("Main Payment Record Inserted Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                            }
                        }
                        else
                        {
                           
                            //Error message
                        }
                    }
                }
                else
                {
                    bl_val = true;
                    //Error Message
                }
                

            }
            catch (Exception x)
            {
                //sqltran.Rollback();
                //clsDataAccess.DisconnectDB();
               MessageBox.Show("Error" + x.ToString());
            }

        }

        private void updateMainPayment()
        {
            try
            {
                //Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                //edpcon.Open();
                //cmd.Connection = edpcon.mycon;
                //sqltran = edpcon.mycon.BeginTransaction();
                int act = 0;
                string insertionqry = "", remarks = txtRemarks.Text.Trim(), pay_month = dtpMonth.Value.ToString("MMMM-yyyy"); ;

                if (vchrNumber.Text != "" && givenAmountTextBox.Text != "")
                {
                    RadioButton rb = null;
                    string recivemode = "";     //Define how the voucher payment has recived

                    if (rdbCash.Checked)
                        rb = rdbCash;
                    else if (rdbBank.Checked)
                        rb = rdbBank;
                    else
                        rb = rdbNEFT;

                    if (rb.Text == "Cash")
                    {
                        //In next line 'H' stands for Cash or In Hand payment type
                        recivemode = "H";
                        if (instrumentCleared.Checked == true)
                        { act = 1; }
                        else
                        { act = 0; }

                        insertionqry = "update tbl_Payment_Receipt_Register set reciptMmode = '" + recivemode + "',amount = " + givenAmountTextBox.Text + ",instumentDate = '" + cashPaymentDate.Value.Date.ToString("yyyyMMdd") + "',instrumentNo = NULL,bankName = NULL,branchName = NULL,instrumentClearDate = NULL,remarks='"+ remarks +"' where (vchrNo = '" + vchrNumber.Text + "')";
                       bl_val= clsDataAccess.RunQry(insertionqry);
                        //ERPMessageBox.ERPMessage.Show("Main Payment Record Updated Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                    else
                    {
                        if (rdbBank.Checked)
                        {
                            recivemode = "C";
                            if (instrumentCleared.Checked == true)
                            {
                                act = 1;
                            }
                            else
                            {
                                act = 0;
                            }
                        }//If payment has made by cheque then it will be C
                        else
                        {
                            recivemode = "N";
                            if (instrumentCleared.Checked == true)
                            {
                                act = 1;
                            }
                            else
                            {
                                act = 0;
                            }
                        }  //If payment has made by NEFT then it will be N
                        if (chequeNoTextBox.Text != "" && bankNameTextBox.Text != "" )
                        {
                            if (instrumentCleared.Checked)
                            {
                                insertionqry = "update tbl_Payment_Receipt_Register set reciptMmode = '" + recivemode + "',amount = " + givenAmountTextBox.Text + ",instumentDate = '" + instrumentIssueDate.Value.Date.ToString("yyyyMMdd") + "',instrumentNo = '" + chequeNoTextBox.Text + "',bankName = '" + bankNameTextBox.Text + "',branchName = '" + BranchNameTextBox.Text + "',instrumentClearDate = '" + instrumentClearDate.Value.Date.ToString("yyyyMMdd") + "',activation="+act+" where vchrNo = '" + vchrNumber.Text + "'";
                               bl_val= clsDataAccess.RunQry(insertionqry);
                                //MessageBox.Show("Main Payment Record Updated Successfully", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                insertionqry = "update tbl_Payment_Receipt_Register set reciptMmode = '" + recivemode + "',amount = " + givenAmountTextBox.Text + ",instumentDate = '" + instrumentIssueDate.Value.Date.ToString("yyyyMMdd") + "',instrumentNo = '" + chequeNoTextBox.Text + "',bankName = '" + bankNameTextBox.Text + "',branchName = '" + BranchNameTextBox.Text + "',activation=" + act + " where vchrNo = '" + vchrNumber.Text + "'";
                               bl_val= clsDataAccess.RunQry(insertionqry);
                               //MessageBox.Show("Main Payment Record Updated Successfully", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            //Error message
                        }
                    }
                }
                else
                {
                    //Error Message
                }
                //sqltran.Commit();
                
                //edpcon.Close();

            }
            catch (Exception x)
            {
                //sqltran.Rollback();
                //clsDataAccess.DisconnectDB();
                MessageBox.Show("Error" + x.ToString());
            }

        }

        private void saveTDSDetails()
        {
            try
            {
                //Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                //edpcon.Open();
                //cmd.Connection = edpcon.mycon;
                //sqltran = edpcon.mycon.BeginTransaction();

                string insertionqry = "";
                
                if (tdsVoucherNumber.Text != "" && tdsAmountTextBox.Text != "")
                {
                    string tdsstatus = ""; //identifying the status of the tds P if provisional and C if Confirmed
                    insertionqry = "insert into tbl_Payment_Register (userVchNo,billNo,tblName,LocationId,CompanyId,ClientId,pay_month,pid) values ('" + tdsVoucherNumber.Text + "','" + billNo + "','tbl_TDS_Register'," + location_id.Trim() + "," + company_id.Trim() + "," + client_id.Trim() + ",'"+dtpMonth.Value.ToString("MMMM-yyyy")+"','"+ lbl_bid.Text +"')";
                   bl_tds= clsDataAccess.RunQry(insertionqry);
                    if (tdsConfirmation.Checked)
                    {
                        if (certificateNoTextBox.Text != "")
                        {
                            tdsstatus = "C";
                            insertionqry = "insert into tbl_TDS_Register(vchrNo,amount,certificateNo,certificationDate,tdsStatus)values ('" + tdsVoucherNumber.Text + "'," + tdsAmountTextBox.Text + ",'" + certificateNoTextBox.Text + "','" + tdsCertificateDate.Value.Date.ToString("yyyyMMdd") + "','" + tdsstatus + "')";
                            bl_tds= clsDataAccess.RunQry(insertionqry);
                            //ERPMessageBox.ERPMessage.Show("TDS Record Inserted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        { 
                            //Message give the value of Certificate number.
                        }
                    }
                    else
                    {
                        tdsstatus = "P";
                        insertionqry = "insert into tbl_TDS_Register(vchrNo,amount,tdsStatus)values('"+tdsVoucherNumber.Text+"',"+tdsAmountTextBox.Text+",'"+tdsstatus+"')";
                        bl_tds= clsDataAccess.RunQry(insertionqry);
                        //ERPMessageBox.ERPMessage.Show("TDS Record Inserted Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                }
                else
                {
                    bl_tds = true;
                    //TDS will not enter into database
                }
                //sqltran.Commit();
                
                //edpcon.Close();
            }
            catch(Exception x)
            {
                //sqltran.Rollback();
                //clsDataAccess.DisconnectDB();
                MessageBox.Show("Error" + x.ToString());
            }
            
        }

        private void updateTDSDetails()
        {
            try
            {
                //Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                //edpcon.Open();
                //cmd.Connection = edpcon.mycon;
                //sqltran = edpcon.mycon.BeginTransaction();

                string insertionqry = "";

                if (tdsVoucherNumber.Text != "" && tdsAmountTextBox.Text != "")
                {
                    string tdsstatus = ""; //identifying the status of the tds P if provisional and C if Confirmed
                    if (tdsConfirmation.Checked)
                    {
                        if (certificateNoTextBox.Text != "")
                        {
                            tdsstatus = "C";
                            insertionqry = "update tbl_TDS_Register set amount = " + tdsAmountTextBox.Text + ",certificateNo = '" + certificateNoTextBox.Text + "',certificationDate = '" + tdsCertificateDate.Value.Date.ToString("yyyyMMdd") + "',tdsStatus = '" + tdsstatus + "' where vchrNo = '" + tdsVoucherNumber.Text + "'";
                          bl_tds= clsDataAccess.RunQry(insertionqry);
                            //ERPMessageBox.ERPMessage.Show("TDS Record Updated Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                        }
                        else
                        {
                            //Message give the value of Certificate number.
                        }
                    }
                    else
                    {
                        tdsstatus = "P";
                        insertionqry = "update tbl_TDS_Register set amount = " + tdsAmountTextBox.Text + ",certificateNo = NULL,certificationDate = NULL,tdsStatus = '" + tdsstatus + "' where vchrNo = '" + tdsVoucherNumber.Text + "'";
                        bl_tds= clsDataAccess.RunQry(insertionqry);
                        //ERPMessageBox.ERPMessage.Show("TDS Record Updated Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                }
                else
                {
                    bl_tds = true;
                    //TDS will not enter into database
                }
                //sqltran.Commit();
                
                //edpcon.Close();
            }
            catch (Exception x)
            {
                //sqltran.Rollback();
                //clsDataAccess.DisconnectDB();
                MessageBox.Show("Error" + x.ToString());
            }

        }

        private void saveOTHDetails()
        {
            try
            {
                //Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                //edpcon.Open();
                //cmd.Connection = edpcon.mycon;
                //sqltran = edpcon.mycon.BeginTransaction();

                string insertionqry = "";

                if (othVoucherNumber.Text != "" && othAmount.Text != "")
                {
                    insertionqry = "insert into tbl_Payment_Register (userVchNo,billNo,tblName,LocationId,CompanyId,ClientId,pay_month,pid) values ('" + othVoucherNumber.Text + "','" + billNo + "','tbl_OTH_Register'," + location_id.Trim() + "," + company_id.Trim() + "," + client_id.Trim() + ",'" + dtpMonth.Value.ToString("MMMM-yyyy") + "','" + lbl_bid.Text + "')" + Environment.NewLine +
                    "insert into tbl_OTH_Register values('" + othVoucherNumber.Text + "'," + othAmount.Text + ",'" + othDate.Value.Date.ToString("yyyyMMdd") + "')";
                    bl_oth = clsDataAccess.RunQry(insertionqry);
                    //sqltran.Commit();
                    //ERPMessageBox.ERPMessage.Show("OTH Record Inserted Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    //edpcon.Close();
                }
                else
                {
                    bl_oth = true;
                }
            }
            catch (Exception x)
            {
                //sqltran.Rollback();
                //clsDataAccess.DisconnectDB();
                MessageBox.Show("Error" + x.ToString());
            }
        }

        private void updateOthDetails()
        {
            try
            {
                //Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                //edpcon.Open();
                //cmd.Connection = edpcon.mycon;
                //sqltran = edpcon.mycon.BeginTransaction();

                string insertionqry = "";

                if (othVoucherNumber.Text != "" && othAmount.Text != "")
                {
                    insertionqry = "update tbl_OTH_Register set amount = " + othAmount.Text + ",issueDate = '" + othDate.Value.Date.ToString("yyyyMMdd") + "' where vchrNo = '" + othVoucherNumber.Text + "'";
                    bl_oth = clsDataAccess.RunQry(insertionqry);
                    //sqltran.Commit();
                    //ERPMessageBox.ERPMessage.Show("OTH Record Updated Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    //edpcon.Close();
                }
                else
                {
                    bl_oth = true;
                }
            }
            catch (Exception x)
            {
                //sqltran.Rollback();
                //clsDataAccess.DisconnectDB();
                MessageBox.Show("Error" + x.ToString());
            }
        }

        public void Command_TR(string qry)
        {
            //cmd.Connection = clsDataAccess.conn;
            cmd.Transaction = sqltran;
            cmd.CommandText = qry;
            cmd.ExecuteNonQuery();
        }

        private void tdsConfirmation_CheckedChanged(object sender, EventArgs e)
        {
            if (tdsConfirmation.Checked)
            {
                certificateNoTextBox.Enabled = true;
                tdsCertificateDate.Enabled = true;                
            }
            else
            {
                certificateNoTextBox.Enabled = false;
                tdsCertificateDate.Enabled = false;  
            }
        }

        /*private void btnFetch_Click(object sender, EventArgs e)
        {
            //object sndr = new object(EDPComponent.ComboDialog);
            EventArgs evnt = new EventArgs();
            this.cmbLocation_DropDown(sender,evnt);
        }*/

        private void existingMainVoucher_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select userVchNo,pid from tbl_Payment_Register where billNo = '" + billNo + "' and tblName = 'tbl_Payment_Receipt_Register'");
            if (dt.Rows.Count > 0)
            {
                txtMainVoucher.LookUpTable = dt;
                txtMainVoucher.ReturnIndex = 1;
            }

           
        }

        private void existingMainVoucher_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            string vno = txtMainVoucher.ReturnValue;
            string vchrno = txtMainVoucher.Text;
            lbl_bid.Text = vno;
            if (vno.Trim() == "")
            {
                txtMainVoucher.Text = "";
                vchrno = "";
                txtMainVoucher.Text = bno();

            }
            else
            {
                DataTable dt = clsDataAccess.RunQDTbl("select balamt,actbalamt from tbl_Payment_Register where userVchNo = '" + vchrno + "'");
                if (dt.Rows.Count > 0)
                {
                    lbl_balAmt.Text = dt.Rows[0]["actbalamt"].ToString();
                    balAmount.Text = dt.Rows[0]["balamt"].ToString();
                }
            }
            vchrNumber.Text = txtMainVoucher.Text;
            existingTDSVoucher.Text = txtMainVoucher.Text;
            
            tdsVoucherNumber.Text = txtMainVoucher.Text;
            othSelectVchNo.Text = txtMainVoucher.Text;
            othVoucherNumber.Text = txtMainVoucher.Text;


            existingTDSVoucher.ReturnValue = txtMainVoucher.Text;
            othSelectVchNo.ReturnValue = txtMainVoucher.Text;

            if(vchrno!="")
                getMainVoucherDetail(vchrno);


            existingTDSVoucher_CloseUp(sender,e);
            othSelectVchNo_CloseUp(sender, e);

            txtMainVoucher.ReturnValue = "";
        }

        private void getMainVoucherDetail(string vchrno)
        {
            //btnSave.Text = "Update";
            string getqry = "select vchrNo,reciptMmode,amount,instumentDate,instrumentNo,bankName,branchName,instrumentClearDate,activation from tbl_Payment_Receipt_Register where vchrNo = '" + vchrno + "'";
            DataTable mainPaymentTable = clsDataAccess.RunQDTbl(getqry);

            vchrNumber.Text = mainPaymentTable.Rows[0]["vchrNo"].ToString();
            //vchrNumber.ReadOnly = true;
            givenAmountTextBox.Text = mainPaymentTable.Rows[0]["amount"].ToString();

            if (Convert.ToBoolean(mainPaymentTable.Rows[0]["activation"]) == true)
            {
                instrumentCleared.Checked = true;
            }
            else
            {
                instrumentCleared.Checked = false;
            }


            if (mainPaymentTable.Rows[0]["reciptMmode"].ToString()=="H")
            {
                rdbCash.Checked = true;
                cashPaymentDate.Value = Convert.ToDateTime(mainPaymentTable.Rows[0]["instumentDate"]);
            }
            else if (mainPaymentTable.Rows[0]["reciptMmode"].ToString() == "C")
            {
                rdbBank.Checked = true;
                instrumentIssueDate.Value = Convert.ToDateTime(mainPaymentTable.Rows[0]["instumentDate"]);
                chequeNoTextBox.Text = mainPaymentTable.Rows[0]["instrumentNo"].ToString();
                bankNameTextBox.Text = mainPaymentTable.Rows[0]["bankName"].ToString();
                BranchNameTextBox.Text = mainPaymentTable.Rows[0]["branchName"].ToString();
                if (mainPaymentTable.Rows[0]["instrumentClearDate"].ToString() != "")
                {
                   // instrumentCleared.Checked = true;
                    instrumentClearDate.Value = Convert.ToDateTime(mainPaymentTable.Rows[0]["instrumentClearDate"]);
                }
                else
                {
                    //instrumentCleared.Checked = false;
                    instrumentClearDate.Enabled = false;
                }
            }
            else
            {
                rdbNEFT.Checked = true;
                instrumentIssueDate.Value = Convert.ToDateTime(mainPaymentTable.Rows[0]["instumentDate"]);
                chequeNoTextBox.Text = mainPaymentTable.Rows[0]["instrumentNo"].ToString();
                bankNameTextBox.Text = mainPaymentTable.Rows[0]["bankName"].ToString();
                BranchNameTextBox.Text = mainPaymentTable.Rows[0]["branchName"].ToString();
                if (mainPaymentTable.Rows[0]["instrumentClearDate"].ToString() != "")
                {
                    instrumentCleared.Checked = true;
                    instrumentClearDate.Value = Convert.ToDateTime(mainPaymentTable.Rows[0]["instrumentClearDate"]);
                }
                else
                {
                    instrumentCleared.Checked = false;
                    instrumentClearDate.Enabled = false;
                }
            }


        }

        private void btnCLear_Click(object sender, EventArgs e)
        {
            //this.cmbLocation.Refresh();
            onLoad();
        }

        private void vchrNumber_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select userVchNo from tbl_Payment_Register where userVchNo = '"+vchrNumber.Text+"'");
            if (dt.Rows.Count > 0)
            {
                if (getMainVoucherUpdateValidity())
                {
                    HiddenHintLable.Text = "This voucher number is already exists," + Environment.NewLine + "you can update details.";
                }
                else
                {
                    HiddenHintLable.Text = "This voucher number is already exists for"+Environment.NewLine+" another bill or applied in tds/oth.";
                }

                HiddenHintLable.Visible = true;
            }
            else
            {
                HiddenHintLable.Text = "";
                HiddenHintLable.Visible = false;
            }

        }

        private Boolean getMainVoucherUpdateValidity()
        {
            Boolean flag = false;
            string getallvchrno = "select userVchNo,billNo,tblName from tbl_Payment_Register where userVchNo = '" + vchrNumber.Text.Trim()+"'";
            DataTable dt = clsDataAccess.RunQDTbl(getallvchrno);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["billNo"].ToString() == billNo && dt.Rows[0]["tblName"].ToString() == "tbl_Payment_Receipt_Register")
                {
                    flag = true;
                }
                else if (dt.Rows[0]["billNo"].ToString() != billNo)
                {
                    flag = false;
                }
                else if (dt.Rows[0]["tblName"].ToString() != "tbl_Payment_Receipt_Register")
                {
                    flag = false;
                }
            }
            return flag;
        }

        private Boolean getTDSVoucherUpdateValidity()
        {
            Boolean flag = false;
            string getallvchrno = "select userVchNo,billNo,tblName from tbl_Payment_Register where userVchNo = '" + tdsVoucherNumber.Text.Trim()+"'  and (tblName='tbl_TDS_Register')";
            DataTable dt = clsDataAccess.RunQDTbl(getallvchrno);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["billNo"].ToString() == billNo && dt.Rows[0]["tblName"].ToString() == "tbl_TDS_Register")
                {
                    flag = true;
                }
                else if (dt.Rows[0]["billNo"].ToString() != billNo)
                {
                    flag = false;
                }
                else if (dt.Rows[0]["tblName"].ToString() != "tbl_TDS_Register")
                {
                    flag = false;
                }
            }
            return flag;
        }
        
        private Boolean getOTHVoucherUpdateValidity()
        {
            Boolean flag = false;
            string getallvchrno = "select userVchNo,billNo,tblName from tbl_Payment_Register where (userVchNo='" +
                othVoucherNumber.Text.Trim() + "') and (tblName='tbl_OTH_Register')";
            DataTable dt = clsDataAccess.RunQDTbl(getallvchrno);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["billNo"].ToString() == billNo && dt.Rows[0]["tblName"].ToString() == "tbl_OTH_Register")
                {
                    flag = true;
                }
                else if (dt.Rows[0]["billNo"].ToString() != billNo)
                {
                    flag = false;
                }
                else if (dt.Rows[0]["tblName"].ToString() != "tbl_OTH_Register")
                {
                    flag = false;
                }
            }
            return flag;
        }

        private void existingTDSVoucher_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select userVchNo from tbl_Payment_Register where billNo = '" + billNo + "' and tblName = 'tbl_TDS_Register'");
            if (dt.Rows.Count > 0)
            {
                existingTDSVoucher.LookUpTable = dt;
                existingTDSVoucher.ReturnIndex = 0;
            }
        }

        private void existingTDSVoucher_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            string vchrno = existingTDSVoucher.ReturnValue;
            if (vchrno != "")
                getTDSVoucherDetail(vchrno);
        }

        private void getTDSVoucherDetail(string vouchrno)
        {
            string getqry = "select vchrNo,amount,certificateNo,certificationDate,tdsStatus from tbl_TDS_Register where vchrNo = '" + vouchrno + "'";
            DataTable dt = clsDataAccess.RunQDTbl(getqry);
            if (dt.Rows.Count > 0)
            {
                tdsVoucherNumber.Text = dt.Rows[0]["vchrNo"].ToString();
                tdsAmountTextBox.Text = dt.Rows[0]["amount"].ToString();
                if (dt.Rows[0]["tdsStatus"].ToString().Trim() == "P")
                {
                    tdsConfirmation.Checked = false;
                    certificateNoTextBox.Enabled = false;
                    tdsCertificateDate.Enabled = false;
                }
                else
                {
                    tdsConfirmation.Checked = true;
                    certificateNoTextBox.Text = dt.Rows[0]["certificateNo"].ToString();
                    tdsCertificateDate.Value = Convert.ToDateTime(dt.Rows[0]["certificationDate"]);
                }
            }
        }

        private void othSelectVchNo_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select userVchNo from tbl_Payment_Register where billNo = '" + billNo + "' and tblName = 'tbl_OTH_Register'");
            if (dt.Rows.Count > 0)
            {
                othSelectVchNo.LookUpTable = dt;
                othSelectVchNo.ReturnIndex = 0;
            }
        }

        private void othSelectVchNo_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            string vchrno = othSelectVchNo.ReturnValue;
            if (vchrno != "")
                getOTHVoucherDetail(vchrno);
        }

        private void getOTHVoucherDetail(string vchrno)
        {
            string getqry = "select vchrNo,amount,issueDate from tbl_OTH_Register where vchrNo = '"+vchrno+"'";
            DataTable dt = clsDataAccess.RunQDTbl(getqry);
            if (dt.Rows.Count>0)
         
            {
             othVoucherNumber.Text = dt.Rows[0]["vchrNo"].ToString();
             othAmount.Text = dt.Rows[0]["amount"].ToString();
             othDate.Value = Convert.ToDateTime(dt.Rows[0]["issueDate"]);
            }
        }

        private void tdsVoucherNumber_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select userVchNo from tbl_Payment_Register where userVchNo = '" + tdsVoucherNumber.Text + "'");
            if (dt.Rows.Count > 0)
            {
                if (getTDSVoucherUpdateValidity())
                {
                    hiddenTDSHintLbl.Text = "This voucher number is already exists," + Environment.NewLine + "you can update details.";
                }
                else
                {
                    hiddenTDSHintLbl.Text = "This voucher number is already exists for" + Environment.NewLine + " another bill or applied in Main Payment/OTH.";
                }
            }
            else
            {
                hiddenTDSHintLbl.Text = "";
            }
        }

        private void othVoucherNumber_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select userVchNo from tbl_Payment_Register where userVchNo = '" + othVoucherNumber.Text + "'");
            if (dt.Rows.Count > 0)
            {
                if (getOTHVoucherUpdateValidity())
                {
                    hiddenOTHHintLbl.Text = "This voucher number is already exists," + Environment.NewLine + "you can update details.";
                }
                else
                {
                    hiddenOTHHintLbl.Text = "This voucher number is already exists for" + Environment.NewLine + " another bill or applied in TDS/Main Payment.";
                }
            }
            else
            {
                hiddenOTHHintLbl.Text = "";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (vchrNumber.Text.Trim() == "" && tdsVoucherNumber.Text.Trim() == "" && othVoucherNumber.Text.Trim() == "")
            {
                ERPMessageBox.ERPMessage.Show("No Voucher Number Has Defined. Nothing to Delete.", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
            else
            {
                deleteMainPaymentVoucher();
                deleteTDSPaymentVoucher();
                deleteOTHPaymentVoucher();
                LoadData(billNo);
                this.Refresh();
            }
            //onLoad();
        }

        private void deleteMainPaymentVoucher()
        {
            try
            {
                Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                edpcon.Open();
                cmd.Connection = edpcon.mycon;
                sqltran = edpcon.mycon.BeginTransaction();

                string deleteqry = "";

                if (vchrNumber.Text != "")
                {
                    if (getMainVoucherUpdateValidity())
                    {
                        deleteqry = "delete from tbl_Payment_Receipt_Register where vchrNo = '" + vchrNumber.Text.Trim() + "'";
                        Command_TR(deleteqry);
                        deleteqry = "delete from tbl_Payment_Register where userVchNo = '" + vchrNumber.Text.Trim() + "'";
                        Command_TR(deleteqry);
                        ERPMessageBox.ERPMessage.Show("Main Payment Record Deleted Successfully.", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Main Payment Record Delete can not be done as it is associated to different bill or TDS/OTH.", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("There is nothing to delete in Main Payment.", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                }
                sqltran.Commit();

                edpcon.Close();

            }
            catch (Exception x)
            {
                sqltran.Rollback();
                clsDataAccess.DisconnectDB();
                ERPMessageBox.ERPMessage.Show("Error" + x.ToString());
            }
        }

        private void deleteTDSPaymentVoucher()
        {
            try
            {
                Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                edpcon.Open();
                cmd.Connection = edpcon.mycon;
                sqltran = edpcon.mycon.BeginTransaction();

                string deleteqry = "";

                if (tdsVoucherNumber.Text != "")
                {
                    if (getTDSVoucherUpdateValidity())
                    {
                        deleteqry = "delete from tbl_TDS_Register where vchrNo = '" + tdsVoucherNumber.Text.Trim() + "'";
                        Command_TR(deleteqry);
                        deleteqry = "delete from tbl_Payment_Register where userVchNo = '" + tdsVoucherNumber.Text.Trim() + "'";
                        Command_TR(deleteqry);
                        ERPMessageBox.ERPMessage.Show("TDS Payment Record Deleted Successfully.", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("TDS Payment Record Delete can not be done as it is associated to different bill or Main Payment/OTH.", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("There is nothing to delete in TDS Payment.", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                }
                sqltran.Commit();

                edpcon.Close();

            }
            catch (Exception x)
            {
                sqltran.Rollback();
                clsDataAccess.DisconnectDB();
                ERPMessageBox.ERPMessage.Show("Error" + x.ToString());
            }
        }

        private void deleteOTHPaymentVoucher()
        {
            try
            {
                Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                edpcon.Open();
                cmd.Connection = edpcon.mycon;
                sqltran = edpcon.mycon.BeginTransaction();

                string deleteqry = "";

                if (othVoucherNumber.Text != "")
                {
                    if (getOTHVoucherUpdateValidity())
                    {
                        deleteqry = "delete from tbl_OTH_Register where vchrNo = '" + othVoucherNumber.Text.Trim() + "'";
                        Command_TR(deleteqry);
                        deleteqry = "delete from tbl_Payment_Register where userVchNo = '" + othVoucherNumber.Text.Trim() + "'";
                        Command_TR(deleteqry);
                        ERPMessageBox.ERPMessage.Show("OTH Payment Record Deleted Successfully.", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("OTH Payment Record Delete can not be done as it is associated to different bill or TDS/Main Payment.", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("There is nothing to delete in OTH Payment.", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                }
                sqltran.Commit();

                edpcon.Close();

            }
            catch (Exception x)
            {
                sqltran.Rollback();
                clsDataAccess.DisconnectDB();
                ERPMessageBox.ERPMessage.Show("Error" + x.ToString());
            }
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            string billNo = txtVoucherChallan.Text.Trim();
            if (billNo == "")
            {
                ERPMessageBox.ERPMessage.Show("Select Bill Number First. Then try again.", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
            else
            {
                try
                {
                    Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                    edpcon.Open();
                    cmd.Connection = edpcon.mycon;
                    sqltran = edpcon.mycon.BeginTransaction();

                    ERPMessageBox.ERPMessage.Show("Are You Sure to Delete all Payment registers against this bill ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
                    if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
                    {
                        DataTable gettingVchrNo = clsDataAccess.RunQDTbl("select userVchNo,tblName from tbl_Payment_Register where billNo = '"+billNo+"'");
                        for (int i = 0; i < gettingVchrNo.Rows.Count; i++)
                        {
                            string delDetailPaymentSql = "delete from " + gettingVchrNo.Rows[0]["tblName"] + " where vchrNo = '" + gettingVchrNo.Rows[0]["userVchNo"] + "'";
                            Command_TR(delDetailPaymentSql);
                        }
                        string delPaymentRegisterSql = "delete from tbl_Payment_Register where billNo = '" + billNo + "'";
                        Command_TR(delPaymentRegisterSql);
                    }

                    sqltran.Commit();
                    edpcon.Close();
                    ERPMessageBox.ERPMessage.Show("Successfully deleted all Payments against "+billNo+" number.", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    LoadData(billNo);

                }
                catch (Exception x)
                {
                    sqltran.Rollback();
                    clsDataAccess.DisconnectDB();
                    ERPMessageBox.ERPMessage.Show("Error" + x.ToString());
                }
            }
        }

        private void btnLinkTDS_Click(object sender, EventArgs e)
        {
            if (txtVoucherChallan.Text.Trim() != "" && billNo != "")
            {

            }
            else
            {
                EDPMessageBox.EDPMessage.Show("Please Select Bill No First.");
            }
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            txtMainVoucher.Text = bno();
            vchrNumber.Text = txtMainVoucher.Text;
            existingTDSVoucher.Text = txtMainVoucher.Text;
            tdsVoucherNumber.Text = txtMainVoucher.Text;
            othSelectVchNo.Text = txtMainVoucher.Text;
            othVoucherNumber.Text = txtMainVoucher.Text;

            existingTDSVoucher.ReturnValue = txtMainVoucher.Text;
            othSelectVchNo.ReturnValue = txtMainVoucher.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void givenAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            double val = 0, tds = 0, oth = 0;
            //if (Information.IsNumeric(givenAmountTextBox.Text) == false)
            //{
            //    givenAmountTextBox.Text = "0";
            //}
            //if (Information.IsNumeric(tdsAmountTextBox.Text) == false)
            //{
            //    tdsAmountTextBox.Text = "0";
            //}
            //if (Information.IsNumeric(othAmount.Text) == false)
            //{
            //    othAmount.Text = "0";
            //}
            try{
               val =Convert.ToDouble(givenAmountTextBox.Text.Trim());
            }catch{
                val=0;
                //givenAmountTextBox.Text = "0";
            }
            try{
                tds = Convert.ToDouble(tdsAmountTextBox.Text.Trim());
            }
            catch { tds = 0; //tdsAmountTextBox.Text = "0"; 
            }
            try
            {
                oth = Convert.ToDouble(othAmount.Text.Trim());
            }catch{
                oth = 0; //othAmount.Text = "0";
            }

            try{
                paidAmount.Text = (val + tds + oth).ToString("0.00");
                    //(Convert.ToDouble(givenAmountTextBox.Text)+Convert.ToDouble(tdsAmountTextBox.Text)+ Convert.ToDouble(othAmount.Text)).ToString("0.00");
            }catch{}
            try
            {
                if (Convert.ToDouble(balAmount.Text) > 0)
                {
                    balAmount.Text = (Convert.ToDouble(lbl_balAmt.Text) - Convert.ToDouble(paidAmount.Text)).ToString("0.00");
                }
                else
                {
                    balAmount.Text = "0.00";
                }
            }
            catch { balAmount.Text = "0.00"; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void givenAmountTextBox_Enter(object sender, EventArgs e)
        {
            if (givenAmountTextBox.Text=="0")
            givenAmountTextBox.SelectAll();
        
        }

        private void tdsAmountTextBox_Enter(object sender, EventArgs e)
        {
            if (tdsAmountTextBox.Text == "0")
                tdsAmountTextBox.SelectAll();
        }

        private void othAmount_Enter(object sender, EventArgs e)
        {
            if (othAmount.Text == "0")
                othAmount.SelectAll();
        }

       

        
    }
}
