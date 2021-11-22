using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmErnDeducHead : EDPComponent.FormBaseERP
    {
        public frmErnDeducHead()
        {
            InitializeComponent();
        }
        private string session = "";
        private string type = "";
        private string monthof = "";
        public String Session
        {
            set { session = value; }
        }
        public String Type
        {
            set { type = value; }
        }
        public string MonthOf
        {
            set { monthof = value; }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtCmpCut.Text.Trim() != "")
            {
                clsEmployee.HeadName = txtCmpCut.Text;
                clsDataAccess.RunNQwithStatus("insert into tbl_Employee_AddErnDeducHead(session,monthof, Type, HeadName) values('" + session + "','" + monthof + "','" + type + "','" + txtCmpCut.Text + "')");
                this.Close();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Name Can not be blank");
                txtCmpCut.Focus();
            }
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}