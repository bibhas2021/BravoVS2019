using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmEmployeeAccount : EDPComponent.FormBaseERP
    {
        int Locations = 0;
        public frmEmployeeAccount()
        {
            InitializeComponent();
        }

        private void frmEmployeeAccount_Load(object sender, EventArgs e)
        {
            this.HeaderText = "Select Employee to Account Transfer";
            dateTimePicker1.Value = System.DateTime.Now;
            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
            //set session
            if (System.DateTime.Now.Month >= 0)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }
            
           clsGeneralShow genralshow = new clsGeneralShow();
           genralshow.getCurLocID();
        }

        private void cmbsalstruc_DropDown(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                cmbsalstruc.Items.Clear();
                Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

                s = "select l.Location_Name from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls where l.Location_ID = ls.Location_ID and l.Location_ID in (" + edpcom.CurrentLocation + ")";
                Load_Data1(s, cmbsalstruc, -1);
                //clear_txt();
            }
            catch (Exception x) { }
        }

        private void cmbsalstruc_DropDownClosed(object sender, EventArgs e)
        {
            Locations = Convert.ToInt32(get_LocationID(cmbsalstruc.Text));

            if (Locations > 0)
            {
                DataTable Employ = clsDataAccess.RunQDTbl("select e.ID,e.Title +' '+ e.FirstName +' '+ e.MiddleName +' ' + e.LastName as Employee_Name   ,dg.DesignationName,s.Acc_transfer   from tbl_Employee_Mast e join tbl_Employee_SalaryMast s on e.ID = s.Emp_Id and s.Month='" + clsEmployee.GetMonthName(dateTimePicker1.Value.Month) + "' join tbl_Employee_DesignationMaster dg on e.DesgId = dg.SLNO where s.session ='" + cmbYear.Text + "' and s.Location_id='" + Locations + "' order by  dg.DesignationName ");
                dgvemployee.DataSource = null;
                dgvemployee.DataSource = Employ;
                dgvemployee.Focus();

                for (int i = 0; i <= Employ.Rows.Count - 1; i++)
                {
                    if (Convert.ToString(Employ.Rows[i]["Acc_transfer"]) == "True")
                        dgvemployee.Rows[i].ReadOnly = true;
                    else
                        dgvemployee.Rows[i].ReadOnly = false;
                }
                dgvemployee.Columns[0].Width = 100;
                dgvemployee.Columns[1].Width = 300;
                dgvemployee.Columns[2].Width = 150;
                dgvemployee.Columns[3].Width = 100;
            }
        }

        public void Load_Data1(string qry, ComboBox cb, int i)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {
                for (int d = 0; d < dt.Rows.Count; d++)
                {
                    cb.Items.Add(dt.Rows[d][0].ToString());
                }
                if (i >= 0)
                    cb.SelectedIndex = i;
            }
        }

        public int get_LocationID(string name)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select Location_ID from tbl_Emp_Location where Location_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0][0]);
            else
                return 0;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string emp_id = "";
            for (int i = 0; i <= dgvemployee.Rows.Count - 2; i++)
            {
                if (Convert.ToString(dgvemployee.Rows[i].Cells[3].Value) != "")
                {
                    if (Convert.ToBoolean(dgvemployee.Rows[i].Cells[3].Value) == true && dgvemployee.Rows[i].ReadOnly == false)
                    {
                        if (emp_id != "")
                            emp_id = emp_id + ",";
                        emp_id = emp_id + "'" + dgvemployee.Rows[i].Cells["Employid"].Value + "'";
                    }
                }
            }
            if (emp_id != "")
            {
                frmAccountTransfar ac = new frmAccountTransfar(emp_id, Locations, clsEmployee.GetMonthName(dateTimePicker1.Value.Month), cmbsalstruc.Text, cmbYear.Text);
                ac.ShowDialog();
            }
            else
                ERPMessageBox.ERPMessage.Show("Select Employee First");
        }

        private void frmEmployeeAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    for (int i = 0; i <= dgvemployee.Rows.Count - 2; i++)
                        dgvemployee.Rows[i].Cells["transfar"].Value = true;
                }
                if (e.KeyCode == Keys.D)
                {
                    for (int i = 0; i <= dgvemployee.Rows.Count - 2; i++)
                        if (dgvemployee.Rows[i].ReadOnly == false)
                            dgvemployee.Rows[i].Cells["transfar"].Value = false;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                Locations = Convert.ToInt32(get_LocationID(cmbsalstruc.Text));

                if (Locations > 0)
                {
                    DataTable Employ = clsDataAccess.RunQDTbl("select e.ID,e.Title +' '+ e.FirstName +' '+ e.MiddleName +' ' + e.LastName as Employee_Name   ,dg.DesignationName,s.Acc_transfer   from tbl_Employee_Mast e join tbl_Employee_SalaryMast s on e.ID = s.Emp_Id and s.Month='" + clsEmployee.GetMonthName(dateTimePicker1.Value.Month) + "' join tbl_Employee_DesignationMaster dg on e.DesgId = dg.SLNO where s.session ='" + cmbYear.Text + "' and s.Location_id='" + Locations + "' order by  dg.DesignationName ");
                    dgvemployee.DataSource = null;
                    dgvemployee.DataSource = Employ;
                    dgvemployee.Focus();

                    for (int i = 0; i <= Employ.Rows.Count - 1; i++)
                    {
                        if (Convert.ToString(Employ.Rows[i]["Acc_transfer"]) == "True")
                            dgvemployee.Rows[i].ReadOnly = true;
                        else
                            dgvemployee.Rows[i].ReadOnly = false;
                    }
                    dgvemployee.Columns[0].Width = 100;
                    dgvemployee.Columns[1].Width = 300;
                    dgvemployee.Columns[2].Width = 150;
                    dgvemployee.Columns[3].Width = 100;
                }
            }

        }

    }
}
