using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmStatusMst : Form
    {
        public frmStatusMst()
        {
            InitializeComponent();
        }

        public void clear()
        {
            DataTable dt_status = clsDataAccess.RunQDTbl("SELECT sid,status FROM tbl_StatusMst");
            dgvEmployee.DataSource = dt_status;

            txtStatus.Text = "";
            lblStatus.Text = "";
            btnSave.Text = "SAVE";
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void frmStatusMst_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int ind = dgvEmployee.CurrentCell.RowIndex;
                lblStatus.Text = dgvEmployee.Rows[ind].Cells["sid"].Value.ToString().Trim();
                txtStatus.Text = dgvEmployee.Rows[ind].Cells["status"].Value.ToString().Trim();
                btnSave.Text = "Modify";
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string opt = "";
            if (lblStatus.Text == "")
            {

                opt = "INSERT INTO tbl_StatusMst(sid, status) VALUES ((Select Max(sid)+1 from tbl_StatusMst),'" + txtStatus.Text.Replace("'","") + "')";
            }
            else
            {
                opt = "UPDATE tbl_StatusMst SET status='" + txtStatus.Text.Replace("'", "") + "' where (sid='" + lblStatus.Text + "')";

            }
            bool b = clsDataAccess.RunQry(opt);
            opt = "";
            if (b== true){
             MessageBox.Show("Accepted Changes.", "BRAVO");
                clear();
            }
            else{
                 MessageBox.Show("Recheck Values.", "BRAVO");
            }
        }
    }
}
