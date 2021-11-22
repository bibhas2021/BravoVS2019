using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace PayRollManagementSystem
{
    public partial class frmPFLoan : EDPComponent.FormBaseERP
    {
        public frmPFLoan()
        {
            InitializeComponent();
        }
        Hashtable hsh_emp_code = new Hashtable();
        Hashtable hsh_emp_name = new Hashtable();
        SqlConnection con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=EDP_Payroll;Data Source=.\\SQLEXPRESS");
        SqlCommand cmd = new SqlCommand();
        SqlTransaction sqltr = null;

        private void frmPFLoan_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbsession, 1950, System.DateTime.Now.Year, 1);
            //

            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbsession.SelectedIndex = 0;
            }
            else
            {
                cmbsession.SelectedIndex = 1;
            }
        }

        private void lblinstallment_Click(object sender, EventArgs e)
        {

        }

        private void txtinstallment_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Load_Data(string qry, ComboBox cb, int i)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            dt = clsDataAccess.RunQDTbl(qry);
            string t = "";
            if (dt.Rows.Count > 0)
            {
                for (int d = 0; d < dt.Rows.Count; d++)
                {
                    t = dt.Rows[d][0].ToString() + " " + dt.Rows[d][1].ToString() + " " + dt.Rows[d][2].ToString() + " " + dt.Rows[d][3].ToString();
                    cb.Items.Add(t);
                    if (!hsh_emp_code.ContainsKey(t))
                        hsh_emp_code.Add(t,dt.Rows[d][5].ToString());
                    if (!hsh_emp_name.ContainsKey(dt.Rows[d][4].ToString()))
                        hsh_emp_name.Add(dt.Rows[d][4].ToString(), t);
                }
                if (i >= 0)
                    cb.SelectedIndex = i;
            }
        }

        private void cmbempname_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbempname.Items.Clear();
                string s = "";
                s = "select title,firstname,middlename,lastname,id,code from tbl_Employee_Mast";
                Load_Data(s, cmbempname, -1);
            }
            catch (Exception ex) { }
        }

        private void cmbempname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbempname.Text.Trim() != "")
                {
                    string s1 = "select id from tbl_Employee_Mast where code=" + Convert.ToInt32(hsh_emp_code[cmbempname.Text.Trim()]);
                    DataTable temp = new DataTable();
                    temp = clsDataAccess.RunQDTbl(s1);
                    if (temp.Rows.Count > 0)
                    {
                        lblempcd.Text = temp.Rows[0][0].ToString();
                        lblempcode.Visible = true;
                    }
                }
                else
                {
                    lblempcd.Text = string.Empty;
                    lblempcode.Visible = false;
                }

            }
            catch (Exception ex) { }
        }

        private void cmbempname_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                clea_txt();
                if (cmbempname.Text.Trim() != "")
                {
                    string s1 = "select id from tbl_Employee_Mast where code=" + Convert.ToInt32(hsh_emp_code[cmbempname.Text.Trim()]);
                    DataTable temp = new DataTable();
                    temp = clsDataAccess.RunQDTbl(s1);
                    if (temp.Rows.Count > 0)
                    {
                        lblempcd.Text = temp.Rows[0][0].ToString();
                        lblempcode.Visible = true;
                    }
                }
                else
                {
                    lblempcd.Text = string.Empty;
                    lblempcode.Visible = false;
                }

            }
            catch (Exception ex) { }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                    con.Open();
                sqltr = con.BeginTransaction();
                save_dt();
                sqltr.Commit();
                msg = "SuccessFully Saved";
            }
            catch (Exception ex)
            {
                sqltr.Rollback();
                msg = ex.ToString();
            }
            finally
            {
                con.Close();
                ERPMessageBox.ERPMessage.Show(msg, "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
            Get_dtl();
            clea_txt();
            
        }
        public void save_dt()
        {
            string s = "";
            if (label1.Text.Trim() == "")
                s = "insert into tbl_Employee_PF_Loan(PFSession,EmpCode,LoanType,LoanDate,LoanAmount,InterestRate,NoOfInstallment,Remarks) values('" + cmbsession.Text.Trim() + "','" + lblempcd.Text.Trim() + "'," + get_loantypeID(cmbloantype.Text.Trim()) + ",'" + Convert.ToDateTime(dtpdate.Text.Trim()).Date.ToString("MM/dd/yyyy") + "'," + Convert.ToDouble(txtamt.Text.Trim()) + "," + Convert.ToDouble(txtirate.Text.Trim()) + "," + Convert.ToInt32(txtinstallment.Text.Trim()) + ",'" + txtrem.Text.Trim() + "')";
            else
                s = "update tbl_Employee_PF_Loan set PFSession='" + cmbsession.Text.Trim() + "',EmpCode='" + lblempcd.Text.Trim() + "',LoanType=" + get_loantypeID(cmbloantype.Text.Trim()) + ",LoanDate='" + Convert.ToDateTime(dtpdate.Text.Trim()).Date.ToString("MM/dd/yyyy") + "',LoanAmount=" + Convert.ToDouble(txtamt.Text.Trim()) + ",InterestRate=" + Convert.ToDouble(txtirate.Text.Trim()) + ",NoOfInstallment=" + txtinstallment.Text.Trim() + ",Remarks='" + txtrem.Text.Trim() + "' where SerialNo=" + label1.Text.Trim();                
            cmd.Connection = con;
            cmd.CommandText = s;
            cmd.Transaction = sqltr;
            cmd.ExecuteNonQuery();

        }
        public int get_loantypeID(string loantype)
        {
            int ID=0;
            if(loantype=="Refundable")
                ID=1;
            else if(loantype=="Non-Refundable")
                ID=2;

            return ID;
        }
        public string get_loantypeName(int ltype)
        {
            string ID = "";
            if (ltype == 1)
                ID = "Refundable";
            else if (ltype == 2)
                ID = "Non-Refundable";

            return ID;
        }
        public void Get_dtl()
        {
            string s = "";
            s = "Select EmpCode,LoanType,LoanDate,LoanAmount,InterestRate,NoOfInstallment,Remarks,SerialNo from tbl_Employee_PF_Loan where PFSession='" + cmbsession.Text.Trim() + "' and EmpCode='" + lblempcd.Text.Trim() + "'";
            DataTable dt_pfloan = new DataTable();
            DataColumn dc = new DataColumn("Employee Code");
            DataColumn dc1 = new DataColumn("Loan Type");
            DataColumn dc2 = new DataColumn("Loan Date");
            DataColumn dc3 = new DataColumn("Loan Amount");
            DataColumn dc4 = new DataColumn("Interest Rate");
            DataColumn dc5 = new DataColumn("No. of Installment");
            DataColumn dc6 = new DataColumn("Remarks");
            DataColumn dc7 = new DataColumn("slno");
            DataColumn[] dc_pf = new DataColumn[] { dc, dc1, dc2, dc3, dc4, dc5, dc6,dc7 };
            dt_pfloan.Columns.AddRange(dc_pf);
            DataRow drpf;
            DataTable dttemp = new DataTable();
            dttemp = clsDataAccess.RunQDTbl(s);
            if (dttemp.Rows.Count > 0)
            {
                for (int t = 0; t < dttemp.Rows.Count; t++)
                {
                    drpf = dt_pfloan.NewRow();
                    drpf[0] = dttemp.Rows[t][0].ToString();
                    drpf[1] = get_loantypeName(Convert.ToInt32(dttemp.Rows[t][1])).ToString();
                    drpf[2] = Convert.ToDateTime(dttemp.Rows[t][2]).ToString("dd MMMM,yyyy");
                    drpf[3] = dttemp.Rows[t][3].ToString();
                    drpf[4] = dttemp.Rows[t][4].ToString();
                    drpf[5] = dttemp.Rows[t][5].ToString();
                    drpf[6] = dttemp.Rows[t][6].ToString();
                    drpf[7] = dttemp.Rows[t][7].ToString();

                    dt_pfloan.Rows.Add(drpf);
                }
                
            }
            dgvpfloan.DataSource = dt_pfloan;
            dgvpfloan.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvpfloan.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvpfloan.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvpfloan.Columns[7].Visible = false;

        }

        private void cmbempname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Get_dtl();
            }
            catch (Exception ex)
            { }
        }

        private void dgvpfloan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblempcd.Text = dgvpfloan.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbempname.Text = hsh_emp_name[lblempcd.Text.Trim()].ToString();
                cmbloantype.Text = dgvpfloan.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpdate.Text = dgvpfloan.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtamt.Text = dgvpfloan.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtirate.Text = dgvpfloan.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtinstallment.Text = dgvpfloan.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtrem.Text = dgvpfloan.Rows[e.RowIndex].Cells[6].Value.ToString();
                label1.Text = dgvpfloan.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch (Exception ex) { }


        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string s = "", msg = "";
            s = "delete from tbl_Employee_PF_Loan where SerialNo=" + label1.Text.Trim();
            try
            {
                if(con.State==ConnectionState.Broken||con.State==ConnectionState.Closed)
                con.Open();
                sqltr = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqltr;
                cmd.CommandText = s;
                cmd.ExecuteNonQuery();
                sqltr.Commit();
                msg = "Successfully Deleted";

            }
            catch (Exception ex)
            {
                sqltr.Rollback();
                msg = "Error : " + ex.ToString();

            }
            finally
            {
                con.Close();
                ERPMessageBox.ERPMessage.Show(msg, "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
            Get_dtl();
            clea_txt();
            
        }
        public void clea_txt()
        {
            //cmbempname.SelectedIndex = -1;
            cmbloantype.SelectedIndex = -1;
            txtamt.Text = string.Empty;
            txtinstallment.Text = string.Empty;
            txtirate.Text = string.Empty;
            txtrem.Text = string.Empty;
            label1.Text = string.Empty;
            lblempcd.Text = string.Empty;
        }
    }
}