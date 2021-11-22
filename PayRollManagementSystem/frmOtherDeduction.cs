using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PayRollManagementSystem
{
    public partial class frmOtherDeduction : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public frmOtherDeduction()
        {
            InitializeComponent();
        }
        string sql = "", Company_id="1",location_id="";
        DataTable dt = new DataTable();
        DataTable sal_head_deduction = new DataTable();
        DataTable sal_head_earning = new DataTable();
        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            sql = "";
            sql=("Select Location_Name,Location_ID,(select client_name from tbl_Employee_CliantMaster where Client_id= el.Cliant_ID) as Client  from tbl_Emp_Location el where (Location_ID IN (select Location_ID from Companywiseid_Relation where (Company_ID='" + Company_id + "'))) order by Location_Name");
            dt = clsDataAccess.RunQDTbl(sql);
            if (dt.Rows.Count > 1)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                cmbLocation.Text = dt.Rows[0]["Location_Name"].ToString();
                cmbLocation.ReturnValue = dt.Rows[0]["Location_ID"].ToString();
                location_id = dt.Rows[0]["Location_ID"].ToString();
                fill_emp();
            }
            else
            {
                MessageBox.Show("No Location Record Found","BRAVO");
            }
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 1)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;

            }
            else if (dt.Rows.Count==1)
            {
                cmbcompany.ReturnValue = dt.Rows[0]["CO_CODE"].ToString();
                cmbcompany.Text = dt.Rows[0]["CO_NAME"].ToString();
                Company_id = (cmbcompany.ReturnValue);
            }
            else
            {
                MessageBox.Show("No Company Record Found","BRAVO");
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
           Company_id = (cmbcompany.ReturnValue);
        }

        private void frmOtherDeduction_Load(object sender, EventArgs e)
        {
            cmbcompany.PopUp();

            sal_head_earning = clsDataAccess.RunQDTbl("select SalaryHead_Full,SalaryHead_Short from tbl_Employee_ErnSalaryHead");

            if (sal_head_earning.Rows.Count > 0)
            {
                dgSalaryEarning.Columns.Add("col_id", "ID");
                dgSalaryEarning.Columns.Add("col_eid", "Employee ID");
                dgSalaryEarning.Columns.Add("col_ename", "Name");

               
                for (int idx = 0; idx < sal_head_earning.Rows.Count; idx++)
                {
                    dgSalaryEarning.Columns.Add("col_" + sal_head_earning.Rows[idx]["SalaryHead_Short"].ToString(), sal_head_earning.Rows[idx]["SalaryHead_Full"].ToString());

                }

                dgSalaryEarning.Columns["col_id"].Visible = false;
                


                SendMessage(cmbLocation.Handle, EM_SETCUEBANNER, 0, "Select Location to view heads");
                
            }


            sal_head_deduction = clsDataAccess.RunQDTbl("select SalaryHead_Full,SalaryHead_Short from tbl_Employee_DeductionSalayHead where pre=1");

            if (sal_head_deduction.Rows.Count > 0)
            {
                dgvSalaryDeduction.Columns.Add("col_id", "ID");
                dgvSalaryDeduction.Columns.Add("col_eid", "Employee ID");
                dgvSalaryDeduction.Columns.Add("col_ename", "Name");

                

                for (int idx = 0; idx < sal_head_deduction.Rows.Count; idx++)
                {
                    dgvSalaryDeduction.Columns.Add("col_" + sal_head_deduction.Rows[idx]["SalaryHead_Short"].ToString(), sal_head_deduction.Rows[idx]["SalaryHead_Full"].ToString());

                }

                dgvSalaryDeduction.Columns["col_id"].Visible = false;

                
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {

          location_id=cmbLocation.ReturnValue;
          fill_emp();
        }

        public void fill_emp()
        {
            string dval = "0";
            dgvSalaryDeduction.Rows.Clear();
            dgSalaryEarning.Rows.Clear();
            if (sal_head_deduction.Rows.Count > 0 || sal_head_earning.Rows.Count > 0)
            {
                dt = clsDataAccess.RunQDTbl("SELECT em.Code as id,em.ID as ecode,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))'ename' from tbl_Employee_Mast em where (Location_id='" + location_id +"') and (active=1)");

                if (dt.Rows.Count > 0)
                {
                    //---Earning---------------------------------------------------------------------------
                    try
                    {
                        for (int idx = 0; idx < dt.Rows.Count; idx++)
                        {


                            dgSalaryEarning.Rows.Add();
                            dgSalaryEarning.Rows[idx].Cells["col_id"].Value = dt.Rows[idx]["id"].ToString();
                            dgSalaryEarning.Rows[idx].Cells["col_eid"].Value = dt.Rows[idx]["ecode"].ToString();
                            dgSalaryEarning.Rows[idx].Cells["col_ename"].Value = dt.Rows[idx]["ename"].ToString();

                            for (int ix = 0; ix < sal_head_earning.Rows.Count; ix++)
                            {
                                dval = "0";
                                try
                                {
                                    dval = clsDataAccess.ReturnValue("SELECT value FROM tbl_other_deduction where (ecode='" + dt.Rows[idx]["ecode"].ToString() +
                  "') and (month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "') and (head='" + sal_head_earning.Rows[ix]["SalaryHead_Short"].ToString() + "') and (locid='" + location_id.Trim() + "') and (coid='" + Company_id.Trim() + "') and (type='E') ");
                                }
                                catch { }

                                if (dval.Trim() == "")
                                {
                                    dgSalaryEarning.Rows[idx].Cells["col_" + sal_head_earning.Rows[ix]["SalaryHead_Short"].ToString()].Value = "0";
                                }
                                else
                                {
                                    dgSalaryEarning.Rows[idx].Cells["col_" + sal_head_earning.Rows[ix]["SalaryHead_Short"].ToString()].Value = dval;
                                }
                            }
                        }
                        dgSalaryEarning.Columns["col_id"].Visible = false;
                        dgSalaryEarning.Columns["col_id"].Frozen = true;
                        dgSalaryEarning.Columns["col_eid"].Frozen = true;
                        dgSalaryEarning.Columns["col_ename"].Frozen = true;
                    }
                    catch { }
                    //---Deduction---------------------------------------------------------------------------
                    try
                    {
                        for (int idx = 0; idx < dt.Rows.Count; idx++)
                        {

                            dgvSalaryDeduction.Rows.Add();
                            dgvSalaryDeduction.Rows[idx].Cells["col_id"].Value = dt.Rows[idx]["id"].ToString();
                            dgvSalaryDeduction.Rows[idx].Cells["col_eid"].Value = dt.Rows[idx]["ecode"].ToString();
                            dgvSalaryDeduction.Rows[idx].Cells["col_ename"].Value = dt.Rows[idx]["ename"].ToString();
                            for (int ix = 0; ix < sal_head_deduction.Rows.Count; ix++)
                            {
                                dval = "0";
                                try
                                {
                                    dval = clsDataAccess.ReturnValue("SELECT value FROM tbl_other_deduction where (ecode='" + dt.Rows[idx]["ecode"].ToString() +
                  "') and (month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "') and (head='" + sal_head_deduction.Rows[ix]["SalaryHead_Short"].ToString() + "') and (locid='" + location_id.Trim() + "') and (coid='" + Company_id.Trim() + "') and (type='I') ");
                                }
                                catch { }

                                if (dval.Trim() == "")
                                {
                                    dgvSalaryDeduction.Rows[idx].Cells["col_" + sal_head_deduction.Rows[ix]["SalaryHead_Short"].ToString()].Value = "0";
                                }
                                else
                                {
                                    dgvSalaryDeduction.Rows[idx].Cells["col_" + sal_head_deduction.Rows[ix]["SalaryHead_Short"].ToString()].Value = dval;
                                }
                            }
                        }
                        dgvSalaryDeduction.Columns["col_id"].Visible = false;

                        dgvSalaryDeduction.Columns["col_id"].Frozen = true;
                        dgvSalaryDeduction.Columns["col_eid"].Frozen = true;
                        dgvSalaryDeduction.Columns["col_ename"].Frozen = true;
                    }
                    catch { }
                }
            }

        


           
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int x=0;
            bool blE = false, blD = false;
            sql = "delete from tbl_other_deduction where (month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "') and (locid='" + location_id.Trim() + "') and (coid='" + Company_id.Trim() + "') and (type='E')" + Environment.NewLine
              + "INSERT INTO tbl_other_deduction(eid, ecode, month, locid, coid, head, value, type) VALUES ";
            for (int idx = 0; idx < dgSalaryEarning.Rows.Count; idx++)
            {
                for (int ix = 0; ix < sal_head_earning.Rows.Count; ix++)
                {
                    //if (Convert.ToDouble(dgSalaryEarning.Rows[idx].Cells["col_" + sal_head_earning.Rows[ix]["SalaryHead_Short"].ToString()].Value) != 0)
                    //{
                        if (x == 0)
                        {
                            sql = sql + "('" + dgSalaryEarning.Rows[idx].Cells["col_id"].Value + "','" + dgSalaryEarning.Rows[idx].Cells["col_eid"].Value +
                                "','" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "','" + location_id.Trim() + "','" + Company_id.Trim() + "','" +
                                sal_head_earning.Rows[ix]["SalaryHead_Short"].ToString() + "','" + dgSalaryEarning.Rows[idx].Cells["col_" + sal_head_earning.Rows[ix]["SalaryHead_Short"].ToString()].Value + "','E')";
                        }
                        else
                        {
                            sql = sql + ",('" + dgSalaryEarning.Rows[idx].Cells["col_id"].Value + "','" + dgSalaryEarning.Rows[idx].Cells["col_eid"].Value +
                           "','" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "','" + location_id.Trim() + "','" + Company_id.Trim() + "','" +
                           sal_head_earning.Rows[ix]["SalaryHead_Short"].ToString() + "','" + dgSalaryEarning.Rows[idx].Cells["col_" + sal_head_earning.Rows[ix]["SalaryHead_Short"].ToString()].Value + "','E')";
                        }
                        x++;
                    //}
                }
            }
            try
            {
                blE = clsDataAccess.RunQry(sql);
            }
            catch { }
            
            
            x = 0;
            sql = "";
            sql = "delete from tbl_other_deduction where (month='"+AttenDtTmPkr.Value.ToString("MMMM-yyyy")+"') and (locid='"+location_id.Trim()+"') and (coid='"+Company_id.Trim()+"') and (type='I')"+Environment.NewLine
                +"INSERT INTO tbl_other_deduction(eid, ecode, month, locid, coid, head, value, type) VALUES ";
            for (int idx = 0; idx < dgvSalaryDeduction.Rows.Count; idx++)
            {
                for (int ix = 0; ix < sal_head_deduction.Rows.Count; ix++)
                {
                    //if (Convert.ToDouble(dgvSalaryDeduction.Rows[idx].Cells["col_" + sal_head_deduction.Rows[ix]["SalaryHead_Short"].ToString()].Value)!=0)
                    //{
                        if (x == 0)
                        {
                            sql = sql + "('" + dgvSalaryDeduction.Rows[idx].Cells["col_id"].Value + "','" + dgvSalaryDeduction.Rows[idx].Cells["col_eid"].Value +
                                "','" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "','" + location_id.Trim() + "','" + Company_id.Trim() + "','" +
                                sal_head_deduction.Rows[ix]["SalaryHead_Short"].ToString() + "','" + dgvSalaryDeduction.Rows[idx].Cells["col_" + sal_head_deduction.Rows[ix]["SalaryHead_Short"].ToString()].Value + "','I')";
                        }
                        else
                        {
                            sql = sql + ",('" + dgvSalaryDeduction.Rows[idx].Cells["col_id"].Value + "','" + dgvSalaryDeduction.Rows[idx].Cells["col_eid"].Value +
                           "','" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "','" + location_id.Trim() + "','" + Company_id.Trim() + "','" +
                           sal_head_deduction.Rows[ix]["SalaryHead_Short"].ToString() + "','" + dgvSalaryDeduction.Rows[idx].Cells["col_" + sal_head_deduction.Rows[ix]["SalaryHead_Short"].ToString()].Value + "','I')";
                        }
                        x++;
                    //}
                }
            }
            try
            {
                blD = clsDataAccess.RunQry(sql);
            }
            catch { }
            if (blE == true || blD == true)
            {
                MessageBox.Show("Record Added", "BRAVO");
                fill_emp();
            }
        }

        private void btnclose_frm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchEarn_TextChanged(object sender, EventArgs e)
        {
            int rowIndex = -1;
            dgSalaryEarning.ClearSelection();
            try
            {
                foreach (DataGridViewRow row in dgSalaryEarning.Rows)
                {
                    if (row.Cells["col_ename"].Value != null) // Need to check for null if new row is exposed
                    {
                        if (row.Cells["col_ename"].Value.ToString().Trim().ToLower().Contains(txtSearchEarn.Text.Trim().ToLower()))
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }
                }
                dgSalaryEarning.Rows[rowIndex].Selected = true;
            }
            catch { }
        }

        private void txtSearchDeduction_TextChanged(object sender, EventArgs e)
        {
            int rowIndex = -1;
            dgvSalaryDeduction.ClearSelection();
            try
            {
                foreach (DataGridViewRow row in dgvSalaryDeduction.Rows)
                {
                    if (row.Cells["col_ename"].Value != null) // Need to check for null if new row is exposed
                    {
                        if (row.Cells["col_ename"].Value.ToString().Trim().ToLower().Contains(txtSearchDeduction.Text.Trim().ToLower()))
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }
                }
                dgvSalaryDeduction.Rows[rowIndex].Selected = true;
            }
            catch { }
        }
    }
}
