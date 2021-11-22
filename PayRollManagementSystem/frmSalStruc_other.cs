using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmSalStruc_other : Form
    {
        public frmSalStruc_other()
        {
            InitializeComponent();
        }
        public String val_Name="",val_Bank="",val_Branch="",val_Ac="",val_IFSC="",val_qry="";
        private void dgvOtherCharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                int ind = dgvOtherCharges.CurrentRow.Index - 1;

                    val_Ac= dgvOtherCharges.Rows[ind].Cells["dgColOAc"].Value.ToString();
                    val_IFSC= dgvOtherCharges.Rows[ind].Cells["dgColOIfsc"].Value.ToString();
                   
                    val_Bank= dgvOtherCharges.Rows[ind].Cells["dgColOBank"].Value.ToString();
                    val_Branch= dgvOtherCharges.Rows[ind].Cells["dgColOBranch"].Value.ToString();
                    val_Name = dgvOtherCharges.Rows[ind].Cells["dgColOName"].Value.ToString();
                    this.Close();
            }
        }

        private void frmSalStruc_other_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = clsDataAccess.RunQDTbl(val_qry);
                int dt_ind=0;
                while (dt_ind < dt.Rows.Count)
                {
                  int grid_ind= dgvOtherCharges.Rows.Add();
                    dgvOtherCharges.Rows[grid_ind].Cells["dgColOAc"].Value = dt.Rows[dt_ind][3];
                    dgvOtherCharges.Rows[grid_ind].Cells["dgColOIfsc"].Value = dt.Rows[dt_ind][4];

                    dgvOtherCharges.Rows[grid_ind].Cells["dgColOBank"].Value = dt.Rows[dt_ind][1];
                    dgvOtherCharges.Rows[grid_ind].Cells["dgColOBranch"].Value = dt.Rows[dt_ind][2];
                    dgvOtherCharges.Rows[grid_ind].Cells["dgColOName"].Value = dt.Rows[dt_ind][0];
                    dt_ind++;
                }
            }
            catch
            {
            }
        }

        private void dgvOtherCharges_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int ind = dgvOtherCharges.CurrentRow.Index ;

                val_Ac = dgvOtherCharges.Rows[ind].Cells["dgColOAc"].Value.ToString();
                val_IFSC = dgvOtherCharges.Rows[ind].Cells["dgColOIfsc"].Value.ToString();

                val_Bank = dgvOtherCharges.Rows[ind].Cells["dgColOBank"].Value.ToString();
                val_Branch = dgvOtherCharges.Rows[ind].Cells["dgColOBranch"].Value.ToString();
                val_Name = dgvOtherCharges.Rows[ind].Cells["dgColOName"].Value.ToString();
                this.Close();
            }
            catch { }
        }

        private void dgvOtherCharges_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
