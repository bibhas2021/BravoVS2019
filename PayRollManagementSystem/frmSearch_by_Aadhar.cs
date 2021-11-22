using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmSearch_by_Aadhar : Form
    {
        public frmSearch_by_Aadhar()
        {
            InitializeComponent();
        }
        public string eid = "";
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable rw_total = clsDataAccess.RunQDTbl("select ID FROM tbl_Employee_Mast where (aadhar='" + txtAadharNo.Text + "' or aadhar='" + txtAadharNo.Text.Replace(" ", "") + "')");
           // eid = edpcom.GetresultS("select ID FROM tbl_Employee_Mast where (aadhar='" + txtAadharNo.Text + "')");
            if (rw_total.Rows.Count > 0)
                eid = rw_total.Rows[0][0].ToString();
            else
                eid = "";
            this.Close();
        }
    }
}
