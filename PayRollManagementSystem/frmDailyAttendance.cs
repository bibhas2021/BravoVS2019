using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using Edpcom;

namespace PayRollManagementSystem
{

    public partial class frmDailyAttendance : EDPComponent.FormBaseERP
    {
        int LocationID = 0, company_Id = 0;
        string session = "",mnth="";
        public frmDailyAttendance(int loc_ID, string year,string mon)
        {
            LocationID = loc_ID;
            session = year;
            mnth = mon;
            company_Id = clsEmployee.GetCompany_ID(LocationID);
            InitializeComponent();

        }
        EDPConnection edpcon = new EDPConnection();
        frmEmpAttendance frmEA = new frmEmpAttendance();
        //System.Globalization.CultureInfo info =
        //   new System.Globalization.CultureInfo("en-US", false);
        //  DataGridViewComboBoxColumn cmbColLeaveTaken = 
        //(DataGridViewComboBoxColumn)DgAttendance.Columns["LeaveTaken"];

        private void frmDailyAttendance_Load(object sender, EventArgs e)
        {
            txtRem.Text = clsEmployee.TotalLeaveDetails[1].ToString();

            if (clsEmployee.TotalLeaveDetails[11].ToString().CompareTo("Color [Lavender]") == 0)
            {
                DayStatuslbl.Text = "(Sunday)";
                DayStatuslbl.ForeColor = System.Drawing.Color.Red;
            }
            if (clsEmployee.TotalLeaveDetails[11].ToString().CompareTo("Color [OldLace]") == 0)
            {
                DayStatuslbl.Text = "(Holiday)";
                DayStatuslbl.ForeColor = System.Drawing.Color.CornflowerBlue;
            }

            if (clsEmployee.TotalLeaveDetails[11].ToString().CompareTo("Color [Empty]") == 0)
            {
                DayStatuslbl.Text = "";
            }

            if (DayStatuslbl.Text.Trim() == "")
            {
                PopulateComboColumnInGrid(clsEmployee.TotalLeaveDetails[8].ToString(), clsEmployee.TotalLeaveDetails[9].ToString(), clsEmployee.TotalLeaveDetails[3].ToString(), 1);
            }
            else
            {
                PopulateComboColumnInGrid(clsEmployee.TotalLeaveDetails[8].ToString(), clsEmployee.TotalLeaveDetails[9].ToString(), clsEmployee.TotalLeaveDetails[3].ToString(), 0);
            }

            System.DateTime LvDate = new System.DateTime();
            LvDate = Convert.ToDateTime(clsEmployee.TotalLeaveDetails[2].ToString());

            Datelbl.Text = LvDate.Day + " - " + Microsoft.VisualBasic.DateAndTime.MonthName(LvDate.Month, true) +
            "-" + LvDate.Year;

            cmbFh.Text = clsEmployee.TotalLeaveDetails[6].ToString();
            cmbSh.Text = clsEmployee.TotalLeaveDetails[7].ToString();
            if (cmbFh.Text.ToString().Trim() == "")
            {
                cmbFh.SelectedItem = "PRN";
            }
            if (cmbSh.Text.ToString().Trim() == "")
            {
                cmbSh.SelectedItem = "PRN";
            }
            if (clsEmployee.TotalLeaveDetails[10].ToString() == "0")
            {
                LeavePayCheckBox.Checked = false;
            }
            else if (clsEmployee.TotalLeaveDetails[10].ToString() == "1")
            {
                LeavePayCheckBox.Checked = true;
            }

            if (clsEmployee.TotalLeaveDetails[11].ToString() == "0")
            {
                radproxyhalf.Checked = false;
            }
            else if (clsEmployee.TotalLeaveDetails[11].ToString() == "1")
            {
                radproxyhalf.Checked = true;
            }
            if (clsEmployee.TotalLeaveDetails[12].ToString() == "0")
            {
                radproxyfull.Checked = false;
            }
            else if (clsEmployee.TotalLeaveDetails[12].ToString() == "1")
            {
                radproxyfull.Checked = true;
            }

        }

        private void PopulateComboColumnInGrid(String strSession, string EmpName, string EmpCode, int Flag)
        {
            txtEmp.Text = EmpName;
            DataTable dt = new DataTable();

            if (Flag == 1)
            {
                dt = clsDataAccess.RunQDTbl("select ShortName,LeaveId from tbl_Employee_Config_LeaveDetails where  LeaveId<>0"); //Session='" + strSession + "' AND
            }

            else
            {
                dt = clsDataAccess.RunQDTbl("select ShortName,LeaveId from tbl_Employee_Config_LeaveDetails where (Location_ID ='" + LocationID + "')");  //where Session='" + strSession + "'
            }

            if (dt.Rows.Count > 0)
            {
                cmbFh.Items.Clear();
                cmbSh.Items.Clear();
                LeaveIdListbx.Items.Clear();


                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    cmbFh.Items.Add(dt.Rows[i]["ShortName"].ToString());
                    cmbSh.Items.Add(dt.Rows[i]["ShortName"].ToString());
                    LeaveIdListbx.Items.Add(dt.Rows[i]["LeaveId"].ToString());
                }
            }
            else
            {
                clsDataAccess.RunNQwithStatus("INSERT INTO tbl_Employee_Config_LeaveDetails(LeaveHead," +
                    "ShortName,Session)VALUES('EXTRA DUTY','EX.DUTY','" + strSession + "')");
                clsDataAccess.RunNQwithStatus("INSERT INTO tbl_Employee_Config_LeaveDetails(LeaveHead," +
                    "ShortName,Session)VALUES('PRESENT','PRN','" + strSession + "')");

                PopulateComboColumnInGrid(strSession, EmpName, EmpCode, Flag);
            }

            dt = clsDataAccess.RunQDTbl("SELECT al.LeaveHead AS 'Leave Head',al.TotalLeaves AS 'Total Leave',(SELECT count(atf.SlNo) " +
                " FROM tbl_Employee_Attendance AS Atf WHERE atf.ID='" + EmpCode.ToString().Trim() +
                "' AND atf.FstLeave=al.LeaveId) As '1st Half Leave'," +
                " (SELECT count(ats.SlNo) FROM tbl_Employee_Attendance AS Ats WHERE ats.ID='" +
                EmpCode.ToString().Trim() + "' AND ats.SndLeave=al.LeaveId) As '2nd Half Leave' " +
                " FROM tbl_Employee_Config_LeaveDetails as Al  where al.LeaveId<>0 and al.LeaveId<>1 and Location_ID ='" + LocationID + "' ");

            LeaveDetailsGrid.DataSource = dt;
            LeaveDetailsGrid.Columns[0].Width = 200;
            LeaveDetailsGrid.Columns[1].Width = 70;
            LeaveDetailsGrid.Columns[2].Width = 70;
            LeaveDetailsGrid.Columns[3].Width = 70;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InsertUpdateAttendaceLogDet()
        {
            try
            {
                
              
               // Boolean rs = false;
                edpcon.Open();
                SqlCommand sqlcmd = new SqlCommand("sp_insert_update_attendance_log_details", edpcon.mycon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@company_id", SqlDbType.VarChar).Value = company_Id;
                sqlcmd.Parameters.AddWithValue("@location_id", SqlDbType.VarChar).Value = LocationID;
                sqlcmd.Parameters.AddWithValue("@session", SqlDbType.VarChar).Value = session;
                sqlcmd.Parameters.AddWithValue("@month", SqlDbType.VarChar).Value = mnth;
                sqlcmd.Parameters.AddWithValue("@log_status_attendance_wise", SqlDbType.VarChar).Value = "D";
                SqlDataAdapter adpt = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adpt.SelectCommand = sqlcmd;
                adpt.Fill(ds);

               // rs = Convert.ToBoolean(sqlcmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.ToString());
                edpcon.Close();
               

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int PayVal = 0, FstProxy = 0, SendProxy = 0;
            int DayStatus = 0, live_fast = 0, live_second = 0;
            if (LeavePayCheckBox.Checked == true)
            {
                PayVal = 1;
            }
            if (radproxyfull.Checked == true)
            {
                FstProxy = 1;
                SendProxy = 1;
            }
            if (radproxyhalf.Checked == true)
            {
                FstProxy = 1;
                SendProxy = 0;
            }
            string LvDate = "";

            if (DayStatuslbl.Text == "(Sunday)")
            {
                DayStatus = 1;
            }

            if (DayStatuslbl.Text == "(Holiday)")
            {
                DayStatus = 2;
            }
            //MessageBox.Show(DatePatern(clsEmployee.TotalLeaveDetails[2].ToString()));
            LvDate = DatePatern(clsEmployee.TotalLeaveDetails[2].ToString());

            if (txtRem.Text.Trim() == "")
            {
                txtRem.Text = "-";
            }

            if (cmbFh.SelectedIndex >= 0)
            {
                if (Information.IsNumeric(LeaveIdListbx.Items[cmbFh.SelectedIndex]) == true)
                    live_fast = Convert.ToInt32(LeaveIdListbx.Items[cmbFh.SelectedIndex]);
            }
            if (cmbSh.SelectedIndex >= 0)
            {
                if (Information.IsNumeric(LeaveIdListbx.Items[cmbSh.SelectedIndex]) == true)
                    live_second = Convert.ToInt32(LeaveIdListbx.Items[cmbSh.SelectedIndex]);
            }

            if (live_fast == 0 && live_second == 0 && FstProxy == 0 && SendProxy == 0)
            {
                ERPMessageBox.ERPMessage.Show("Select Any Leave Details or Proxy Details ", "Attendance");
                return;
            }

            if (Convert.ToInt32(clsEmployee.TotalLeaveDetails[0].ToString()) < 0)
            {
                clsDataAccess.RunNQwithStatus("INSERT INTO tbl_Employee_Attendance(ID,Remarks,LeaveDate,FstLeave," +
                "SndLeave,LeaveType,DayStatus,Location_ID,FstProxy,SndProxy,Company_id,season) values('" + clsEmployee.TotalLeaveDetails[3].ToString() + "','" +
                txtRem.Text.Trim() + "','" + LvDate + "'," + live_fast + "," +
                live_second + "," + PayVal + "," + DayStatus + "," + LocationID + "," + FstProxy + "," + SendProxy + ",'" + company_Id + "','" + session + "')");
            }
            else
            {
                clsDataAccess.RunNQwithStatus("UPDATE tbl_Employee_Attendance SET ID='" + clsEmployee.TotalLeaveDetails[3].ToString() +
                "',Remarks='" + txtRem.Text.Trim() + "',LeaveDate='" + LvDate +
                "',FstLeave=" + live_fast + ",SndLeave=" + live_second + ",LeaveType=" +
                PayVal + ",DayStatus=" + DayStatus + ",Location_ID = " + LocationID + ",FstProxy =" + FstProxy + ",SndProxy=" + SendProxy + ",Company_id = '" + company_Id + "',season ='" + session + "'   WHERE SlNo=" + clsEmployee.TotalLeaveDetails[0].ToString());
            }
          
            this.DialogResult = DialogResult.OK;
            InsertUpdateAttendaceLogDet();//new add
            this.Close();
        }


        private string DatePatern(string DatePart)
        {
            string ReturnVal = "";
            RegistryKey Reg;
            Reg = Registry.CurrentUser.OpenSubKey("Control Panel\\International", true);
            ReturnVal = Reg.GetValue("sShortDate").ToString();
            string[] DateVal = new string[3];

            DateVal = DatePart.Split('/');

            switch (ReturnVal.ToString().IndexOf("dd"))
            {
                case 0:
                    ReturnVal = DateVal[1] + "/" + DateVal[0] + "/" + DateVal[2];
                    break;
                case 3:
                    ReturnVal = DateVal[0] + "/" + DateVal[1] + "/" + DateVal[2];
                    break;
                case 8:
                    ReturnVal = DateVal[1] + "/" + DateVal[2] + "/" + DateVal[0];
                    break;
            }

            return ReturnVal;
        }

        private void cmbFh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbFh.SelectedIndex == 0)
            //{
            //    LeavePayCheckBox.Checked = false;
            //    LeavePayCheckBox.Visible = false;
            //}
            //else
            //{
            if (clsEmployee.TotalLeaveDetails[10].ToString() == "0")
            {
                LeavePayCheckBox.Checked = false;
            }
            else if (clsEmployee.TotalLeaveDetails[10].ToString() == "1")
            {
                LeavePayCheckBox.Checked = true;
            }

            LeavePayCheckBox.Visible = true;
            //}

        }

        private void cmbSh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbSh.SelectedIndex == 0)
            //{
            //    LeavePayCheckBox.Checked = false;
            //    LeavePayCheckBox.Visible = false;
            //}
            //else
            //{
            if (clsEmployee.TotalLeaveDetails[10].ToString() == "0")
            {
                LeavePayCheckBox.Checked = false;
            }
            else if (clsEmployee.TotalLeaveDetails[10].ToString() == "1")
            {
                LeavePayCheckBox.Checked = true;
            }

            LeavePayCheckBox.Visible = true;
            //}
        }

        private void DeleteOrUpdateAttendanceLogDetails()
        {
            try
            {
                
              
               // Boolean rs = false;
                edpcon.Open();
                SqlCommand sqlcmd = new SqlCommand("sp_delete_or_update_attendance_log_details", edpcon.mycon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@company_id", SqlDbType.VarChar).Value = company_Id;
                sqlcmd.Parameters.AddWithValue("@location_id", SqlDbType.VarChar).Value = LocationID;
                sqlcmd.Parameters.AddWithValue("@session", SqlDbType.VarChar).Value = session;
                sqlcmd.Parameters.AddWithValue("@month", SqlDbType.VarChar).Value = mnth;
                sqlcmd.Parameters.AddWithValue("@log_status_attendance_wise", SqlDbType.VarChar).Value = "D";
                sqlcmd.Parameters.AddWithValue("@attendance_wise_page_ref", SqlDbType.VarChar).Value = "D";
                SqlDataAdapter adpt = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adpt.SelectCommand = sqlcmd;
                adpt.Fill(ds);

               // rs = Convert.ToBoolean(sqlcmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.ToString());
                edpcon.Close();
               

            }

        }


        private void vistaButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to Cancel Leave ? ", "Remove Leave Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                clsDataAccess.RunNQwithStatus("Delete from tbl_Employee_Attendance WHERE SlNo=" + clsEmployee.TotalLeaveDetails[0].ToString());
                cmbFh.SelectedIndex = -1;
                cmbSh.SelectedIndex = -1;
                DeleteOrUpdateAttendanceLogDetails();
                this.Close();
            }
        }


    }
}