
//ANURAG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Collections;
using EDPVersion;
using FirstTimeNeed;
using Microsoft.VisualBasic.FileIO;
using EDPComponent;
using EDPMessageBox;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.Sql;

namespace PayRollManagementSystem
{
    public partial class Cheque : Form
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        SqlTransaction sqltran;
        int Sl_No;
        public Cheque()
        {
            InitializeComponent();
        }

        #region Function
               
        private void SaveDetails()
        {
            Boolean boolStatus = false;
                BtnSubmit.Text = "Save";
                boolStatus = clsDataAccess.RunNQwithStatus("insert into Cheque_Details (Session,Cheque_no,Given_to,Purpose,Amount,Bank_name) values('" + cmbYear.Text.Trim() + "','" + txtChequeNo.Text.Trim() + "','" + txtGivenTo.Text.Trim() + "', '" + txtPurpose.Text.Trim() + "','" + txtAmount.Text.Trim() + "','" + txtBank_Name.Text.Trim() + "')");            
            
            if (boolStatus)
            {
                ERPMessageBox.ERPMessage.Show("Cheque Details " + BtnSubmit.Text.Trim() + " Successfully");
                ClearControl();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To " + BtnSubmit.Text.Trim() + " Cheque Details");
            }
        }

        private void Updatedetails()
        {
            Boolean boolStatus = false;
            //DataTable dt = clsDataAccess.RunQDTbl("select * from Check_Details where Session='" + cmbYear.Text.Trim() + "'");
            //if (dt.Rows.Count > 0)
            //{
                btnUpdate.Text = "Update";
                boolStatus = clsDataAccess.RunNQwithStatus("update Cheque_Details set Session='" + cmbYear.Text.Trim() + "',Cheque_no='" + txtChequeNo.Text.Trim() + "',Given_to ='" + txtGivenTo.Text.Trim() + "',Purpose='" + txtPurpose.Text.Trim() + "',Amount=" + txtAmount.Text.Trim() + ",Bank_name='" + txtBank_Name.Text.Trim() + "' where Sl_No=" + Sl_No + "");
            //}
             if (boolStatus)
            {
                ERPMessageBox.ERPMessage.Show("Cheque Details " + btnUpdate.Text.Trim() + " Successfully");
                ClearControl();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To " + btnUpdate.Text.Trim() + " Cheque Details");
            }
        }

        private void dataDisplay()
        {
            edpcon.Open();
            SqlCommand cm = new SqlCommand("select * from Cheque_Details", edpcon.mycon);
            SqlDataAdapter sdaa = new SqlDataAdapter(cm);
            DataTable dtt = new DataTable();
            sdaa.Fill(dtt);
            edpcon.Close();

            DataTable table = new DataTable();
            dtt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dbBindingSource.DataSource = dtt;
            dbGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dbGridView.ReadOnly = true;
            dbGridView.DataSource = dbBindingSource;
        }

        private void ClearControl()
        {
            //BtnSubmit.Text = "Save";
            cmbYear.Text = String.Empty;
            txtChequeNo.Text = String.Empty;
            txtGivenTo.Text = String.Empty;
            txtPurpose.Text = String.Empty;
            txtAmount.Text = String.Empty;
            txtBank_Name.Text = String.Empty;
            BtnSubmit.Enabled = true;
            btnUpdate.Enabled = false;
        }
        #endregion

        private void Cheque_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            rdbCheque_DD.Checked = true;
            btnUpdate.Enabled = false;

            dataDisplay();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txtChequeNo.Text) == "")
            {
                ERPMessageBox.ERPMessage.Show("Cheque No. Cannot be 0");
            }
            else if (Convert.ToString(txtGivenTo.Text) == "")
            {
                ERPMessageBox.ERPMessage.Show("Given_To Cannot be Blank");
            }
            else if (Convert.ToString(txtPurpose.Text) == "")
            {
                ERPMessageBox.ERPMessage.Show("Purpose Cannot be Blank");
            }
            else if (Convert.ToDouble(txtAmount.Text) <= 0)
            {
                ERPMessageBox.ERPMessage.Show("Amount Cannot be 0 or less");
            }
            else
            {
                SaveDetails();
            }
            dataDisplay();
        }
       
        private void txtChequeNo_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select Cheque_no,Given_to,Sl_No from Cheque_Details");
            if (dt.Rows.Count > 0)
            {
                txtChequeNo.LookUpTable = dt;
                txtChequeNo.ReturnIndex = 2;
                btnUpdate.Enabled = true;
                BtnSubmit.Enabled = false;
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("There is No Data to Show");
                btnUpdate.Enabled = false;
                BtnSubmit.Enabled = true;
            }
        }

        private void txtChequeNo_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Sl_No = Convert.ToInt32(txtChequeNo.ReturnValue);
            String str = "select Session,Cheque_no,Given_to,Purpose,Amount,Bank_name from Cheque_Details where (Sl_No = '" + Sl_No + "')";
            DataTable dt = clsDataAccess.RunQDTbl(str);
            if (dt.Rows.Count > 0)
            {
                //txtChequeNo.Text = dt.Rows[0]["Cheque_no"].ToString();
                cmbYear.Text = dt.Rows[0]["Session"].ToString();
                txtGivenTo.Text = dt.Rows[0]["Given_to"].ToString();
                txtPurpose.Text = dt.Rows[0]["Purpose"].ToString();
                txtAmount.Text = dt.Rows[0]["Amount"].ToString();
                txtBank_Name.Text = dt.Rows[0]["Bank_name"].ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txtChequeNo.Text) == "")
            {
                ERPMessageBox.ERPMessage.Show("Cheque No. Cannot be 0");
            }
            else if (Convert.ToString(txtGivenTo.Text) == "")
            {
                ERPMessageBox.ERPMessage.Show("Given_To Cannot be Blank");
            }
            else if (Convert.ToString(txtPurpose.Text) == "")
            {
                ERPMessageBox.ERPMessage.Show("Purpose Cannot be Blank");
            }
            else if (Convert.ToDouble(txtAmount.Text) <= 0)
            {
                ERPMessageBox.ERPMessage.Show("Amount Cannot be 0 or less");
            }
            else
            {
                Updatedetails();
            }
            dataDisplay();
        }

        private void rdbCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCash.Checked == true)
            {
                txtChequeNo.Enabled = false;
            }
            else
            {
                txtChequeNo.Enabled = true;
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchValue.Text.ToLower();

            if (searchValue == "")
                ERPMessageBox.ERPMessage.Show("Give input to Search");
            else
            {

                dbGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                try
                {
                    foreach (DataGridViewRow row in dbGridView.Rows)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        if (row.Cells[1].Value.ToString().ToLower().Contains(searchValue) || (row.Cells[2].Value.ToString().ToLower().Contains(searchValue)) || (row.Cells[3].Value.ToString().ToLower().Contains(searchValue)) || row.Cells[4].Value.ToString().ToLower().Contains(searchValue) || row.Cells[6].Value.ToString().ToLower().Contains(searchValue))
                        {
                            //dbGridView.ClearSelection();                        
                            row.Selected = true;
                            dbGridView.Rows[row.Index].DefaultCellStyle.BackColor = Color.YellowGreen;
                            dbGridView.ClearSelection();
                            //break;
                        }
                        //dbGridView.Rows[row.Index].DefaultCellStyle.BackColor = Color.White;                  
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    btnUpdate.Enabled = false;
                    BtnSubmit.Enabled = true;
                }
            }
            txtSearchValue.Text = String.Empty;
        }

    }
}

