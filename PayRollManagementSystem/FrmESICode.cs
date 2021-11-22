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
    public partial class FrmESICode : Form//EDPComponent.FormBaseERP
    {
        int Company_id = 0;
        public FrmESICode()
        {
            InitializeComponent();
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);
            btnsave.Visible = true;
            txtesicode.Text = "";
            data_retrive();
        }

        private void data_retrive()
        {
            dgvquery.DataSource = null;
            DataTable dt = clsDataAccess.RunQDTbl("Select ESI_Code,Company_ID from ESICodeMaster where  Company_ID = '" + Company_id + "' ");
            dgvquery.DataSource = dt;

            dgvquery.Columns[1].Visible = false;
            dgvquery.Columns[0].Width = 317;
            dgvquery.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void clearAll()
        {
            cmbcompany.Text = "";
            txtesicode.Text = "";
            Company_id = 0;
            dgvquery.DataSource = null;
            vistaButton1.Visible = false;
            btnsave.Visible = true;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Boolean boolStatus = false;
            boolStatus = clsDataAccess.RunNQwithStatus("Delete from ESICodeMaster where ESI_Code='" + txtesicode.Text + "' and Company_ID ='" + Company_id + "' ");

            if (boolStatus == true)
            {
                ERPMessageBox.ERPMessage.Show("Delete Successfuly");
                clearAll();
            }
            else
                ERPMessageBox.ERPMessage.Show("No Record To Delete");
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Boolean boolStatus = false;
            if (cmbcompany.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Select Company Name");
                cmbcompany.Focus();
                return;
            }
            if (txtesicode.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Enter EsiCode");
                txtesicode.Focus();
                return;
            }

            boolStatus = clsDataAccess.RunNQwithStatus("insert into ESICodeMaster(Company_ID,ESI_Code) values('" + Company_id + "','" + txtesicode.Text + "')");

            if (boolStatus == true)
            {
                ERPMessageBox.ERPMessage.Show("Save Successfuly");
                clearAll();
            }
            else
                ERPMessageBox.ERPMessage.Show("No Record To Save");
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvquery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Company_id != 0)
            {
                txtesicode.Text = Convert.ToString(dgvquery.Rows[e.RowIndex].Cells[0].Value);
                btnsave.Visible = false;
                vistaButton1.Visible = true;
            }
        }

        private void FrmESICode_Load(object sender, EventArgs e)
        {
            //this.HeaderText = "ESI Code Genarate";
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            Boolean boolStatus = false;
            if (cmbcompany.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Select Company Name");
                cmbcompany.Focus();
                return;
            }
            if (txtesicode.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Enter EsiCode");
                txtesicode.Focus();
                return;
            }

            boolStatus = false;
            boolStatus = clsDataAccess.RunNQwithStatus("Delete from ESICodeMaster where ESI_Code='" + dgvquery.Rows[dgvquery.CurrentRow.Index].Cells[0].Value + "' and Company_ID ='" + dgvquery.Rows[dgvquery.CurrentRow.Index].Cells[1].Value + "' ");
            if (boolStatus == true)
            {
                boolStatus = clsDataAccess.RunNQwithStatus("insert into ESICodeMaster(Company_ID,ESI_Code) values('" + Company_id + "','" + txtesicode.Text + "')");

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
