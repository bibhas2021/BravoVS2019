using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERPMessageBox;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace PayRollManagementSystem
{
    public partial class frmAddErnDeduc : EDPComponent.FormBaseERP
    {
        public frmAddErnDeduc()
        {
            InitializeComponent();
        }
        private string empid = "";Int32 slno = 0;
        private void frmAddErnDeduc_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Month >= 4)
                clsEmployee.PopulateYear(cmbYear, 1950, DateTime.Now.Year, 1);
            else
                clsEmployee.PopulateYear(cmbYear, 1950, DateTime.Now.Year - 1, 1);
             cmbMonth.SelectedIndex = 0; cmbYear.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsEmployee.HeadName = "";
            frmErnDeducHead head = new frmErnDeducHead();
            if (tv.SelectedNode.Text == "Earning")
                head.Type = "E";
            else if (tv.SelectedNode.Text == "Deduction")
                head.Type = "D";
            head.Session = cmbYear.Text;
            head.MonthOf = cmbMonth.Text;
            head.ShowDialog();
            cmbYear_SelectedIndexChanged(sender, e);
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Clear();
            if (e.Node.Level == 0)
            {
                btnAdd.Enabled = true;
                btnDel.Enabled = false;
            }
            else if (e.Node.Level > 0)
            {
                btnAdd.Enabled = false;
                btnDel.Enabled = true;
                DataTable dt = new DataTable();
                if (e.Node.Parent.Text == "Earning")
                    dt = clsDataAccess.RunQDTbl("Select  e.SlNo SlNo, e.Amount Amount, emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name] from tbl_Employee_AddErnDeducDetails e , tbl_Employee_Mast emp where emp.id=e.empid and e.type='E' and e.session='" + cmbYear.Text + "' and e.monthof='" + cmbMonth.Text + "' and e.headid=" + tv.SelectedNode.Tag.ToString());
                else if (e.Node.Parent.Text == "Deduction") dt = clsDataAccess.RunQDTbl("Select e.SlNo SlNo, e.Amount Amount, emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name] from tbl_Employee_AddErnDeducDetails e , tbl_Employee_Mast emp where emp.id=e.empid and e.type='D' and e.session='" + cmbYear.Text + "' and e.monthof='" + cmbMonth.Text + "' and e.headid=" + tv.SelectedNode.Tag.ToString());
                dgv.DataSource = dt;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select * from tbl_Employee_AddErnDeducHead where type='E' and session='" + cmbYear.Text + "' and monthof='" + cmbMonth.Text + "'");
            tv.Nodes[0].Nodes.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                tv.Nodes[0].Nodes.Add(dt.Rows[i]["HeadName"].ToString());
                tv.Nodes[0].Nodes[i].Tag = dt.Rows[i]["HeadID"].ToString();
            }
            dt = clsDataAccess.RunQDTbl("Select * from tbl_Employee_AddErnDeducHead where type='D' and session='" + cmbYear.Text + "' and monthof='" + cmbMonth.Text + "'");
            tv.Nodes[1].Nodes.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                tv.Nodes[1].Nodes.Add(dt.Rows[i]["HeadName"].ToString());
                tv.Nodes[1].Nodes[i].Tag = dt.Rows[i]["HeadID"].ToString();
            }
        }

        private void cmbdEmpId_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name] from tbl_Employee_Mast emp");
            if (dt.Rows.Count > 0)
            {
                cmbdEmpId.LookUpTable = dt;
            }
        }

        private void cmbdEmpId_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            empid = e.ReturnValue;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tv.SelectedNode != null)
            {
                if (tv.SelectedNode.Level > 0)
                {
                    if (cmbdEmpId.Text == "")
                    {
                        ERPMessage.Show("Please Select Employee");
                        return;
                    }
                    if (!Information.IsNumeric(txtCmpCut.Text.Trim()))
                    {
                        ERPMessage.Show("Please Enter Numeric value");
                        txtCmpCut.Text = "0.00";
                        txtCmpCut.Focus();
                        return;
                    }
                    if (slno == 0)
                    {
                        if (tv.SelectedNode.Parent.Text == "Earning")
                            clsDataAccess.RunNQwithStatus("insert into tbl_Employee_AddErnDeducDetails(Session, EmpID, Monthof, Amount, HeadID, Type) values('" + cmbYear.Text + "','" + empid + "','" + cmbMonth.Text + "'," + txtCmpCut.Text + "," + tv.SelectedNode.Tag.ToString() + ",'E')");
                        else if (tv.SelectedNode.Parent.Text == "Deduction")
                            clsDataAccess.RunNQwithStatus("insert into tbl_Employee_AddErnDeducDetails(Session, EmpID, Monthof, Amount, HeadID, Type) values('" + cmbYear.Text + "','" + empid + "','" + cmbMonth.Text + "'," + txtCmpCut.Text + "," + tv.SelectedNode.Tag.ToString() + ",'D')");
                    }
                    else
                    {
                        clsDataAccess.RunNQwithStatus("update tbl_Employee_AddErnDeducDetails set Amount=" + txtCmpCut.Text + " where slno=" + slno);
                    }
                }
            }
            tv_AfterSelect(sender, new TreeViewEventArgs(tv.SelectedNode));
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            if (e.RowIndex >= 0)
            {
                txtCmpCut.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbdEmpId.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                slno = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                cmbdEmpId.ReturnValue = "";
            }
        }
                           
        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            slno = 0; cmbdEmpId.Text = ""; cmbdEmpId.ReturnValue = ""; empid = ""; txtCmpCut.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (slno != 0)
            {
                bool bu = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_AddErnDeducDetails where slno=" + slno);
                if (bu)
                    ERPMessage.Show("Successfully Deleted");
            }
        }
    }
}