using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class FrmPTAXCode : EDPComponent.FormBaseERP
    {
        int Company_id = 0;
        public FrmPTAXCode()
        {
            InitializeComponent();
        }

        private void cmbclient_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbclient.LookUpTable = dt;
                cmbclient.ReturnIndex = 1;
            }
        }

        private void cmbclient_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbclient.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbclient.ReturnValue);
            btnsave.Visible = true;
            txtpfcode.Text = "";
            data_retrive();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
             Boolean boolStatus = false;
            if (cmbclient.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Select Company Name");
                cmbclient.Focus();
                return;
            }
            if (txtpfcode.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Enter PTAXCode");
                txtpfcode.Focus();
                return;
            }

            boolStatus = clsDataAccess.RunNQwithStatus("insert into PTAXCodeMaster(Company_ID,PTAX_Code) values('" + Company_id + "','" + txtpfcode.Text + "')");

            if (boolStatus == true)
            {
                ERPMessageBox.ERPMessage.Show("Save Successfuly");                
                clearAll();
            }
            else
                ERPMessageBox.ERPMessage.Show("No Record To Save");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
             Boolean boolStatus = false;
             boolStatus = clsDataAccess.RunNQwithStatus("Delete from PTAXCodeMaster where PTAX_Code='" + txtpfcode.Text + "' and Company_ID ='" + Company_id + "' ");

            if (boolStatus == true)
            {
                ERPMessageBox.ERPMessage.Show("Delete Successfuly");                
                clearAll();
            }
            else
                ERPMessageBox.ERPMessage.Show("No Record To Delete");
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void data_retrive()
        {
            dgvquery.DataSource = null;
            DataTable dt = clsDataAccess.RunQDTbl("Select PTAX_Code,Company_ID from PTAXCodeMaster where  Company_ID = '" + Company_id + "' ");
            dgvquery.DataSource = dt;

            dgvquery.Columns[1].Visible = false;
            dgvquery.Columns[0].Width = 317;
            dgvquery.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void clearAll()
        {
            cmbclient.Text = "";
            txtpfcode.Text = "";
            Company_id = 0;
            dgvquery.DataSource = null;
            vistaButton1.Visible = false;
            btnsave.Visible = true;
        }

        private void dgvquery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Company_id != 0)
            {
                txtpfcode.Text = Convert.ToString(dgvquery.Rows[e.RowIndex].Cells[0].Value);
                btnsave.Visible = false;
                vistaButton1.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmPTAXCode_Load(object sender, EventArgs e)
        {
            this.HeaderText = "PTAX Code Generate";
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            Boolean boolStatus = false;
            if (cmbclient.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Select Company Name");
                cmbclient.Focus();
                return;
            }
            if (txtpfcode.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Enter PTAXCode");
                txtpfcode.Focus();
                return;
            }

            boolStatus = false;
            boolStatus = clsDataAccess.RunNQwithStatus("Delete from PTAXCodeMaster where PTAX_Code='" + dgvquery.Rows[dgvquery.CurrentRow.Index].Cells[0].Value + "' and Company_ID ='" + dgvquery.Rows[dgvquery.CurrentRow.Index].Cells[1].Value + "' ");
            if (boolStatus == true)
            {
                boolStatus = clsDataAccess.RunNQwithStatus("insert into PTAXCodeMaster(Company_ID,PTAX_Code) values('" + Company_id + "','" + txtpfcode.Text + "')");

                if (boolStatus == true)
                {
                    ERPMessageBox.ERPMessage.Show("Update Successfuly");
                    clearAll();
                }
                else
                    ERPMessageBox.ERPMessage.Show("Update Problem");
            }
        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {
            vistaButton1.Visible = false;
            btnsave.Visible = true;
            clearAll();
        }
    

       
    }
}
