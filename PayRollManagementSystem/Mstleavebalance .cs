using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace PayRollManagementSystem
{
    public partial class Mstleavebalance : Form
    {
      //  SqlConnection con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=EDP_Payroll;Data Source=.\\SQLEXPRESS");
       // SqlCommand cmd = new SqlCommand();
        Boolean boolStatus = false;
        Boolean boolStatus2 = false;

        int Company_id = 0,location_id=0;
        public Mstleavebalance()
        {
            InitializeComponent();
        }

        private void leavebalance4_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            AttenDtTmPkr.Value = DateTime.Now;
           // this.HeaderText = "Earn Leave Master";
            int x = 0;
            txtLvRate.Text = x.ToString();

        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (rdbCo.Checked == true)
            {
                dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL order by Location_Name");
            }
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;

            }
            //df();
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (rdbCo.Checked == true)
            {
                if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                {
                    Company_id = Convert.ToInt32(cmbcompany.ReturnValue);
                    location_id = 0;
                }

                df();
            }
            else
            {
                if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                {
                    location_id = Convert.ToInt32(cmbcompany.ReturnValue);
                    Company_id = clsEmployee.GetCompany_ID(Convert.ToInt32(location_id));
                }

                df();

            }
        }

      

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    {
                        cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year;
                    }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

       
        private void df()
        {
            txtLvRate.Text = clsDataAccess.GetresultS("select ISNULL(lv_rate,0)lvRate from tbl_Comp_LVRate where (coid='" + Company_id + "')");

            if (txtLvRate.Text.Trim() == "" || txtLvRate.Text == null)
            {
                txtLvRate.Text = "0";
            }

            String str;
            if (rdbCo.Checked == true)
            {
                str = "select ID,(CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN ' ' + e.MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN ' ' + e.LastName ELSE '' END) AS 'EMP Name' ,ISNULL((select ISNULL(cur_lv_bal,0) from tbl_Emp_Leave_Balance b where b.eid=e.ID),0)LvBal FROM tbl_Employee_Mast e where (Company_id='" + Company_id + "')";
            }
            else
            {
                str = "select ID,(CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN ' ' + e.MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN ' ' + e.LastName ELSE '' END) AS 'EMP Name' ,ISNULL((select ISNULL(cur_lv_bal,0) from tbl_Emp_Leave_Balance b where b.eid=e.ID),0)LvBal FROM tbl_Employee_Mast e where (Company_id='" + Company_id + "') and (Location_id='" + location_id + "') order by [EMP Name]";
            }
            DataTable dt = clsDataAccess.RunQDTbl(str);
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("ID");
            dt1.Columns.Add("EName");
            dt1.Columns.Add("CurLvBal");
            for (int ind = 0; ind < dt.Rows.Count; ind++)
            {
                dt1.Rows.Add();
                dt1.Rows[ind]["ID"] = dt.Rows[ind]["ID"].ToString();
                dt1.Rows[ind]["EName"] = dt.Rows[ind]["EMP Name"].ToString();
                dt1.Rows[ind]["CurLvBal"] = dt.Rows[ind]["LvBal"].ToString();
                // dt1.Rows[ind]["EAAMT"] = dt.Rows[ind]["EAAMT"].ToString();

            }
            dgvRateMaster.DataSource = dt1;
        }
        private void save()
        {
            string format = "MMMM-yyyy";
            //  Year = dateTimePicker1.Value.ToShortDateString();
            // Month = dateTimePicker1.Value.Month.ToString();
            string Year = AttenDtTmPkr.Value.ToString(format);
            string str = "";
            clsDataAccess.RunNQwithStatus("delete from tbl_Comp_LVRate where (coid=" + Company_id + ")");
            for (Int32 i = 0; i < dgvRateMaster.Rows.Count-1; i++)
            {
                str = "IF EXISTS (SELECT * FROM tbl_Emp_Leave_Balance WHERE (st_lv_bal>0) and (coid='" + Company_id + "') and (eid='" + dgvRateMaster.Rows[i].Cells["Id"].Value.ToString().Trim() + "'))" + Environment.NewLine +
                         "Update tbl_Emp_Leave_Balance set cur_lv_bal='" + dgvRateMaster.Rows[i].Cells["CurLvBal"].Value + "',Session='" + cmbYear.Text + "',Month='" + Year + "' where (coid='" + Company_id + "') and (eid='" + dgvRateMaster.Rows[i].Cells["Id"].Value.ToString().Trim() + "')" + Environment.NewLine +
                      "Else" + Environment.NewLine +
                        "IF EXISTS (SELECT * FROM tbl_Emp_Leave_Balance WHERE (st_lv_bal=0) and (coid='" + Company_id + "') and (eid='" + dgvRateMaster.Rows[i].Cells["Id"].Value.ToString().Trim() + "'))" + Environment.NewLine +
                          "Update tbl_Emp_Leave_Balance set cur_lv_bal='" + dgvRateMaster.Rows[i].Cells["CurLvBal"].Value + "',Session='" + cmbYear.Text + "',Month='" + Year + "' where (coid='" + Company_id + "') and (eid='" + dgvRateMaster.Rows[i].Cells["Id"].Value.ToString().Trim() + "')" + Environment.NewLine + 
                           "Else" + Environment.NewLine +
                          "insert into tbl_Emp_Leave_Balance(coid,eid,cur_lv_bal,st_lv_bal,Session,Month) values ('" + Company_id + "','" + dgvRateMaster.Rows[i].Cells["Id"].Value.ToString().Trim() + "','" + dgvRateMaster.Rows[i].Cells["CurLvBal"].Value + "','" + dgvRateMaster.Rows[i].Cells["CurLvBal"].Value + "','" + cmbYear.Text + "','" + Year + "')";
              
                    boolStatus = clsDataAccess.RunNQwithStatus(str);
                


            }


            clsDataAccess.RunNQwithStatus("delete from tbl_Comp_LVRate where (coid=" + Company_id + ")");
            boolStatus2 = clsDataAccess.RunNQwithStatus("insert into tbl_Comp_LVRate(coid,LV_RATE,Session,Month) values ('" + Company_id + "' , '" + txtLvRate.Text + "' ,'" + cmbYear.Text + "' ,'" + Year + "' )");
            if (boolStatus == true && boolStatus2 == true)
            {
                MessageBox.Show("Records inserted.");
                df();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }




        
    }
}
