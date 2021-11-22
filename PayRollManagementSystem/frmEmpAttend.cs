using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

using System.Windows;

using System.Windows.Forms;

using Microsoft.VisualBasic;
using System.Threading;
using Microsoft.Win32;

using Edpcom;
using FirstTimeNeed;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.OleDb;



namespace PayRollManagementSystem
{
    public partial class frmEmpAttend : Form
    {
        int Location_ID = 0, leave_id = 0, live_fast = 0, live_second = 0, PayVal = 0, cWD_MOD = 0, wd_limit = 60, MEmp=0;
        int DayStatus = 0, FstProxy = 0, SendProxy = 0;
        int PreviousRow = 0, PreviousColumn = 0;
        string LvDate = "";
        string path = "";
        int sal_in = 0;
        ArrayList alEmpID = new ArrayList();
        ArrayList alEmpDesgID = new ArrayList();
        EDPConnection edpcon;
        Edpcom.EDPCommon edpcom = new EDPCommon();
        String strAttenDtTmPkrMonth = "";
        int attype = 0;
        ArrayList arrecode = new ArrayList();
        string arrayEcode = "";
        Hashtable get_ecode = new Hashtable();
        MidasReport.Form1 fr = new MidasReport.Form1();
        int wo = 0;


        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        

        public frmEmpAttend()
        {
            InitializeComponent();
        }

        //=========== functions======
        private void clientname()
        {
            lbl_mod.Text = "";
            DataTable dt = clsDataAccess.RunQDTbl("SELECT Cliant_ID,(SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE (Client_id = el.Cliant_ID)) AS ClientName FROM tbl_Emp_Location AS el WHERE (Location_ID='" + Location_ID + "')");
            try
            {
                lblClientID.Text = dt.Rows[0]["Cliant_ID"].ToString();
                LblClient.Text = dt.Rows[0]["ClientName"].ToString();
            }
            catch { }
            dt = clsDataAccess.RunQDTbl("Select CR.MOD,isNUll(CR.[hrs_per_wd],8)[hrs_per_wd],isNull(CR.[hrs_per_ot],4)[hrs_per_ot],isNull(CR.[apply_hrs_wd],0)[apply_hrs_wd],isNull(CR.[apply_hrs_ot],0)[apply_hrs_ot],isNull(CR.[apply_hrs_ed],0)[apply_hrs_ed],isNull(CR.[hrs_per_ed],4)[hrs_per_ed] from Companywiseid_Relation CR  where (CR.Location_ID='" + Location_ID + "')");
            try
            {
                string modVal = dt.Rows[0][0].ToString().ToUpper();

                lbl_Accpt_wd_hrs.Text = dt.Rows[0]["apply_hrs_wd"].ToString().ToUpper();
                lbl_Accpt_ot_hrs.Text = dt.Rows[0]["apply_hrs_ot"].ToString().ToUpper();

                lbl_Accpt_ed_hrs.Text = dt.Rows[0]["apply_hrs_ed"].ToString().ToUpper();

                    lbl_wd_hrs.Text = dt.Rows[0]["hrs_per_wd"].ToString().ToUpper();
                    lbl_ot_hrs.Text = dt.Rows[0]["hrs_per_ot"].ToString().ToUpper();
                    lbl_ed_hrs.Text = dt.Rows[0]["hrs_per_ed"].ToString().ToUpper();

                    if (lbl_Accpt_wd_hrs.Text == "")
                    {
                        lbl_Accpt_wd_hrs.Text = "0";
                    }
                    
                    if (lbl_ot_hrs.Text == "")
                    {
                        lbl_ot_hrs.Text = "0";
                    }

                    if (lbl_Accpt_ot_hrs.Text == "")
                    {
                        lbl_Accpt_ot_hrs.Text = "0";
                    }
                    if (lbl_wd_hrs.Text == "")
                    {
                        lbl_wd_hrs.Text = "0";
                    }


                    if (lbl_ed_hrs.Text == "")
                    {
                        lbl_ed_hrs.Text = "0";
                    }

                    if (lbl_Accpt_ed_hrs.Text == "")
                    {
                        lbl_Accpt_ed_hrs.Text = "0";
                    }

                if (modVal == "MONTHOFDAYS")
                {
                    try
                    {
                        int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                        txtDays.Text = NumberOfDays.ToString();
                    }
                    catch { }
                }
                else if (modVal == "MOD-EWO")
                {
                    lbl_mod.Text = "MOD-EWO";
                    try
                    {
                        int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                        txtDays.Text = NumberOfDays.ToString();
                    }
                    catch { }
                }
                else if (modVal == "MOD-SUNDAYS")
                {
                    try
                    {
                        int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value);
                        txtDays.Text = NumberOfDays.ToString();
                    }
                    catch { }
                }
                else if (modVal.Contains("MOD-WO"))
                {
                    int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                    txtDays.Text = NumberOfDays.ToString();
                    string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('[');
                    lblWO.Text = strFromTo[0];

                    txtDays.Text = (NumberOfDays - Convert.ToInt32(lblWO.Text)).ToString();
                    //tbTo.Text = strFromTo[1];
                }
                else if (modVal.Contains("RANGE-SUNDAYS"))
                {
                    string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                    int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), true);
                    txtDays.Text = NumberOfDays.ToString();

                    //tbTo.Text = strFromTo[1];
                }
                else if (modVal.Contains("RANGE"))
                {
                    string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                    int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), false);
                    txtDays.Text = NumberOfDays.ToString();
                    //tbTo.Text = strFromTo[1];
                }
                else
                {
                    txtDays.Text = dt.Rows[0][0].ToString();
                }

                if (txtDays.Text == "0")
                {
                    int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                    txtDays.Text = NumberOfDays.ToString();
                }
            }
            catch
            {
                try
                {
                    int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                    txtDays.Text = NumberOfDays.ToString();
                }
                catch { }
            }
        }

        public DataTable EmployeeList()
        {
            int month = AttenDtTmPkr.Value.Month;
            string Mo = clsEmployee.GetMonthName(month);
            //DataTable dt = clsDataAccess.RunQDTbl("select distinct emp.ID,emp.FirstName+' '+emp.MiddleName+'" +
            //" '+emp.LastName as [Employee Name],desg.DesignationName from tbl_Employee_Mast emp," +
            //" tbl_Employee_DesignationMaster desg , tbl_Emp_Posting ep where emp.DesgId=desg.SlNo " +
            //" and ep.LOcation_ID='" + Location_ID + "' and emp.ID=ep.Employ_ID and Posting_Month ='" + Mo + "'and ep.Session = '" + cmbYear.Text + "'  ");

            DataTable dt = clsDataAccess.RunQDTbl("select distinct emp.ID," +
                 "(CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + " +
 "(CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + " +
 "(CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS [Employee Name],desg.DesignationName " +
                           " from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg  where emp.DesgId=desg.SlNo  " +
                           "  and emp.active=1  and emp.Location_id='" + Location_ID + "' " +
                           "union all " +
                           " select distinct emp.ID," +
                 "(CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + " +
 "(CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + " +
 "(CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS [Employee Name],desg.DesignationName from tbl_Employee_Mast emp," +
                           " tbl_Employee_DesignationMaster desg , tbl_Emp_Posting ep where emp.DesgId=desg.SlNo " +
                           " and ep.LOcation_ID='" + Location_ID + "' and emp.ID=ep.Employ_ID and Posting_Month ='" + Mo + "' and ep.Session = '" + cmbYear.Text + "' and emp.active=1 and  ep.LOcation_ID !=emp.Location_id   ");

            return dt;

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
        //======================================
        private int Salary_Exist_Cnt_For_Location_Session_Month()
        {
            try
            {
                edpcon.Open();
                int cnt = 0;
                SqlCommand sqlcmd = new SqlCommand("sp_check_salary_details_exist_respect_to_location_session_month", edpcon.mycon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@company_id", SqlDbType.VarChar).Value = Convert.ToString(clsEmployee.GetCompany_ID(Convert.ToInt32(cmblocation.ReturnValue)));
                sqlcmd.Parameters.AddWithValue("@location_id", SqlDbType.VarChar).Value = cmblocation.ReturnValue;
                sqlcmd.Parameters.AddWithValue("@session", SqlDbType.VarChar).Value = cmbYear.Text;
                sqlcmd.Parameters.AddWithValue("@month", SqlDbType.VarChar).Value = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
                SqlDataAdapter adpt = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adpt.SelectCommand = sqlcmd;
                adpt.Fill(ds);
                cnt = Convert.ToInt32(ds.Tables[0].Rows[0]["cnt_inserted_salary_for_location"]);
                if (cnt > 0)
                {
                    return cnt;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.ToString());
                edpcon.Close();
                return 0;

            }
        }
        private DataSet chkSpAttend(int rw, int mod)
        {
            edpcon.Open();
            string log_status = "NS";
            SqlCommand sqlcmd = new SqlCommand("sp_emp_attend_view", edpcon.mycon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@company_id", SqlDbType.Int).Value = (clsEmployee.GetCompany_ID(Convert.ToInt32(cmblocation.ReturnValue)));
            sqlcmd.Parameters.AddWithValue("@location_id", SqlDbType.Int).Value = cmblocation.ReturnValue;
            sqlcmd.Parameters.AddWithValue("@session", SqlDbType.VarChar).Value = cmbYear.Text;
            sqlcmd.Parameters.AddWithValue("@month", SqlDbType.VarChar).Value = AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year;
            sqlcmd.Parameters.AddWithValue("@cnt", SqlDbType.Int).Value = rw;
            sqlcmd.Parameters.AddWithValue("@mod", SqlDbType.Int).Value = mod;
            int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
            sqlcmd.Parameters.AddWithValue("@mon", SqlDbType.Int).Value = NumberOfDays + AttenDtTmPkr.Value.ToString("/MMM/yyyy");
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adpt.SelectCommand = sqlcmd;
            adpt.Fill(ds);

            return ds;
        }
        private string CheckAttendanceIsDailyOrMonthlyWise()
        {
            try
            {
                edpcon.Open();
                string log_status = "NS";
                SqlCommand sqlcmd = new SqlCommand("sp_check_attendance_is_daily_or_monthly_wise", edpcon.mycon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@company_id", SqlDbType.VarChar).Value = Convert.ToString(clsEmployee.GetCompany_ID(Convert.ToInt32(cmblocation.ReturnValue)));
                sqlcmd.Parameters.AddWithValue("@location_id", SqlDbType.VarChar).Value = cmblocation.ReturnValue;
                sqlcmd.Parameters.AddWithValue("@session", SqlDbType.VarChar).Value = cmbYear.Text;
                sqlcmd.Parameters.AddWithValue("@month", SqlDbType.VarChar).Value = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
                SqlDataAdapter adpt = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adpt.SelectCommand = sqlcmd;
                adpt.Fill(ds);

                log_status = ds.Tables[0].Rows[0]["log_status"].ToString();
                return log_status;
            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.ToString());
                edpcon.Close();
                return "NS";

            }
        }
        //======================================================================================
        public int rwCount()
        {
            string sql = "select count(*) FROM tbl_Employee_Attend where (Season='" + cmbYear.Text + "') and (Month='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "') and (LOcation_ID='" + Location_ID + "')";
            int cnt = 0;
            cnt = Convert.ToInt32(clsDataAccess.GetresultS(sql));
            return cnt;
        }

        public void disp_Grid(DataSet ds)
        {
            dgvAttend.Rows.Clear();
            string shift = "",sfid="0",sno="1";
            if (ds.Tables[0].Rows.Count > 0)
            {
                int ind = 0, rw = 0;
                double lv_pbal = 0,lv_earn=0,lv_adj=0;
                //dgvAttend.DataSource = ds;
                while (ind < ds.Tables[0].Rows.Count)
                {
                    try
                    {
                        rw = dgvAttend.Rows.Add();
                    }
                    catch { }
                    dgvAttend.Rows[rw].Cells["col_ecode"].Value = ds.Tables[0].Rows[ind]["ID"].ToString();
                    dgvAttend.Rows[rw].Cells["col_ename"].Value = ds.Tables[0].Rows[ind]["ename"].ToString();
                    dgvAttend.Rows[rw].Cells["col_wday"].Value = ds.Tables[0].Rows[ind]["Wday"].ToString();
                    dgvAttend.Rows[rw].Cells["col_proxy"].Value = ds.Tables[0].Rows[ind]["Proxy"].ToString();
                    dgvAttend.Rows[rw].Cells["col_absent"].Value = ds.Tables[0].Rows[ind]["Absent"].ToString();
                    dgvAttend.Rows[rw].Cells["col_ed"].Value = ds.Tables[0].Rows[ind]["ed"].ToString();
                    dgvAttend.Rows[rw].Cells["col_desg"].Value = ds.Tables[0].Rows[ind]["Designation"].ToString();
                    if (lbl_mod.Text.Trim().ToUpper() == "MOD-EWO")
                    {
                        try { dgvAttend.Rows[rw].Cells["col_wo"].Value = ds.Tables[0].Rows[ind]["Woff"].ToString(); }
                        catch { dgvAttend.Rows[rw].Cells["col_wo"].Value = lblWO.Text; }
                    }
                    else
                    {
                        dgvAttend.Rows[rw].Cells["col_wo"].Value = lblWO.Text;

                    }
                    //--------------------------------------------------------------------------------------------------
                    dgvAttend.Rows[rw].Cells["col_lv_earn"].Value = ds.Tables[0].Rows[ind]["lv_earn"].ToString();
                    dgvAttend.Rows[rw].Cells["col_lv_pbal"].Value = ds.Tables[0].Rows[ind]["lv_pbal"].ToString(); //clsDataAccess.GetresultS("select ISNULL(cur_lv_bal,0) from tbl_Emp_Leave_Balance b where (b.eid='" + ds.Tables[0].Rows[ind]["ID"].ToString() + "')");
                    dgvAttend.Rows[rw].Cells["col_lv_adj"].Value = ds.Tables[0].Rows[ind]["lv_adj"].ToString();

                    try { if (dgvAttend.Rows[rw].Cells["col_lv_pbal"].Value == null) { dgvAttend.Rows[rw].Cells["col_lv_pbal"].Value = "0"; } }

                    catch { }
                    try
                    {
                        try
                        {
                            lv_pbal = Convert.ToDouble(dgvAttend.Rows[rw].Cells["col_lv_pbal"].Value);
                        }
                        catch { lv_pbal = 0; }
                        try
                        {
                            lv_earn = Convert.ToDouble(dgvAttend.Rows[rw].Cells["col_lv_earn"].Value);
                        }
                        catch { lv_earn = 0; }

                        try
                        {
                            lv_adj = Convert.ToDouble(dgvAttend.Rows[rw].Cells["col_lv_adj"].Value);
                        }
                        catch
                        {
                            lv_adj = 0;
                        }
                        dgvAttend.Rows[rw].Cells["col_lv_cbal"].Value = ((lv_pbal - lv_adj) + lv_earn).ToString("0.00");
                    }
                    catch
                    {
                        dgvAttend.Rows[rw].Cells["col_lv_cbal"].Value = 0;
                    }


                    //-----------------------------------------------------------------------------------------------------
                    if (btnProcess.Text.ToLower() == "process")
                    {
                        dgvAttend.Rows[rw].Cells["col_lv_earn_old"].Value = 0;//ds.Tables[0].Rows[ind]["lv_earn"].ToString();
                        dgvAttend.Rows[rw].Cells["col_lv_pbal_old"].Value = 0;//ds.Tables[0].Rows[ind]["lv_pbal"].ToString(); //clsDataAccess.GetresultS("select ISNULL(cur_lv_bal,0) from tbl_Emp_Leave_Balance b where (b.eid='" + ds.Tables[0].Rows[ind]["ID"].ToString() + "')");
                        dgvAttend.Rows[rw].Cells["col_lv_adj_old"].Value = 0;//ds.Tables[0].Rows[ind]["lv_adj"].ToString();
                        dgvAttend.Rows[rw].Cells["col_lv_cbal_old"].Value = dgvAttend.Rows[rw].Cells["col_lv_cbal"].Value;// ds.Tables[0].Rows[ind]["lv_cbal_old"].ToString();

                        try
                        {
                            dgvAttend.Rows[rw].Cells["col_cwd"].Value = ds.Tables[0].Rows[ind]["cWD"].ToString();
                        }
                        catch
                        { }
                        try
                        {
                            dgvAttend.Rows[rw].Cells["col_cfw"].Value = 1;
                        }
                        catch { }

                        shift = clsDataAccess.GetresultS("select isNull(sname,'General Shift') from tbl_shift where (sid='0')");
                        sfid = "0";
                        sno = "1";
                    }
                    else if (btnProcess.Text.ToLower() == "reprocess")
                    {
                        dgvAttend.Rows[rw].Cells["col_lv_earn_old"].Value = ds.Tables[0].Rows[ind]["lv_earn"].ToString();
                        dgvAttend.Rows[rw].Cells["col_lv_pbal_old"].Value = ds.Tables[0].Rows[ind]["lv_pbal"].ToString(); //clsDataAccess.GetresultS("select ISNULL(cur_lv_bal,0) from tbl_Emp_Leave_Balance b where (b.eid='" + ds.Tables[0].Rows[ind]["ID"].ToString() + "')");
                        dgvAttend.Rows[rw].Cells["col_lv_adj_old"].Value = ds.Tables[0].Rows[ind]["lv_adj"].ToString();
                        dgvAttend.Rows[rw].Cells["col_lv_cbal_old"].Value = dgvAttend.Rows[rw].Cells["col_lv_cbal"].Value;// ds.Tables[0].Rows[ind]["lv_cbal_old"].ToString();


                        sfid = clsDataAccess.GetresultS("select isNull(sfid,0) FROM tbl_Employee_Attend where (Season='" + cmbYear.Text + "') and (Month='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "') and (LOcation_ID='" + Location_ID + "') and (ID='" + ds.Tables[0].Rows[ind]["ID"].ToString() + "')");
                        if (sfid.Trim() == "")
                        {
                            sfid = "0";
                        }
                        sno = clsDataAccess.GetresultS("select isNull(sno,0) FROM tbl_Employee_Attend where (Season='" + cmbYear.Text + "') and (Month='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "') and (LOcation_ID='" + Location_ID + "') and (ID='" + ds.Tables[0].Rows[ind]["ID"].ToString() + "')");
                        if (sno.Trim() == "")
                        {
                            sno = "0";
                        }
                        shift = clsDataAccess.GetresultS("select isNull(sname,'General Shift') from tbl_shift where (sid='" + sfid + "')");
                        try
                        {
                            dgvAttend.Rows[rw].Cells["col_cwd"].Value = clsDataAccess.ReturnValue("select cWD from tbl_Employee_Attend where (Season='" + cmbYear.Text + "') and (Month='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "') and (LOcation_ID='" + Location_ID + "') and (ID='" + ds.Tables[0].Rows[ind]["ID"].ToString() + "') and (Desgid='" + ds.Tables[0].Rows[ind]["Desgid"].ToString() + "')");//ds.Tables[0].Rows[ind]["cWD"].ToString();
                        }
                        catch
                        {
                        }

                        try
                        {
                            dgvAttend.Rows[rw].Cells["col_cfw"].Value = clsDataAccess.ReturnValue("select cfw from tbl_Employee_Attend where (Season='" + cmbYear.Text + "') and (Month='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "') and (LOcation_ID='" + Location_ID + "') and (ID='" + ds.Tables[0].Rows[ind]["ID"].ToString() + "') and (Desgid='" + ds.Tables[0].Rows[ind]["Desgid"].ToString() + "')");//ds.Tables[0].Rows[ind]["cWD"].ToString();
                        }
                        catch
                        {
                        }
                    }
                    if (shift == DBNull.Value.ToString())
                    {
                        shift = "General Shift";

                    }

                    dgvAttend.Rows[rw].Cells["col_shift"].Value = shift.ToString();
                    dgvAttend.Rows[rw].Cells["col_others"].Value = ds.Tables[0].Rows[ind]["WD"].ToString() + (char)13 + ds.Tables[0].Rows[ind]["PX"].ToString();
                    dgvAttend.Rows[rw].Cells["col_desgid"].Value = ds.Tables[0].Rows[ind]["DesgId"].ToString();
                    dgvAttend.Rows[rw].Cells["col_eid"].Value = 0;
                    dgvAttend.Rows[rw].Cells["col_shift_id"].Value = sfid;
                    try
                    {
                        //dgvAttend.Rows[rw].Cells["col_cwd"].Value = ds.Tables[0].Rows[ind]["cWD"].ToString();
                    }
                    catch
                    {
                        //double tdays = 0, wdays = 0, cWdMod = 0, clday = 0;
                        //string desg_id = "0";

                        //if (cWD_MOD == 1)
                        //{
                        //    tdays = Convert.ToDouble(txtDays.Text);
                        //    desg_id = dgvAttend.Rows[rw].Cells["col_desgid"].Value.ToString();
                        //    wdays = Convert.ToDouble(dgvAttend.Rows[rw].Cells["col_wday"].Value);
                        //    try
                        //    {
                        //        cWdMod = Convert.ToDouble(clsDataAccess.ReturnValue("Select other from tbl_Site_mod_desg where (sid='" + cmblocation.ReturnValue + "') and (desgid='" + desg_id + "')"));
                        //    }
                        //    catch { cWdMod = 0; }
                        //    //if (cWdMod > wdays)
                        //        clday= Math.Round(((wdays / tdays) * cWdMod));





                        //    if (cWdMod == 0)
                        //        dgvAttend.Rows[rw].Cells["col_cwd"].Value = wdays.ToString("0.00");
                        //    else  if (cWdMod > clday)
                        //        dgvAttend.Rows[rw].Cells["col_cwd"].Value = clday.ToString("0.00");
                        //    else
                        //        dgvAttend.Rows[rw].Cells["col_cwd"].Value = cWdMod.ToString("0.00");

                        //}
                    }
                    ind++;
                }

            }


            try
            {
                if (clsDataAccess.GetresultS("select loc_initial from Companywiseid_Relation where (Location_ID='" + cmblocation.ReturnValue + "')") == "1")
                {
                    dgvAttend.Columns["col_wo"].Visible = true;
                }
                else
                {
                    dgvAttend.Columns["col_wo"].Visible = false;
                }

            }
            catch { }
        }

        //======================================================================================

        private void Extractcmd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckAttendanceIsDailyOrMonthlyWise() == "D")
                {
                    //EDPMessageBox.EDPMessage.Show("You can not fetch due to daily attendance already defined.");
                    //return;
                }

                if (cmblocation.Text.Trim() == "")
                {
                    EDPMessageBox.EDPMessage.Show("First Select any Location");
                    return;
                }

                DataSet ds_sp = new DataSet();
                if (rwCount() > 0)
                {
                    btnProcess.Text = "ReProcess";
                    btnDelete.Visible = true;
                    btnImport.Enabled = false;
                    ds_sp = chkSpAttend(2, Convert.ToInt32(txtDays.Text));

                    string sql = "select status FROM tbl_Employee_Attend where (Season='" + cmbYear.Text + "') and (Month='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "') and (LOcation_ID='" + Location_ID + "')";
                    int cnt = 0;
                    cnt = Convert.ToInt32(clsDataAccess.GetresultS(sql));
                    if (cnt == 1)
                    {
                        chkAuthorise.Checked = true;
                    }
                    else if (cnt==0)
                    {
                        chkAuthorise.Checked = false;

                    }

                    sql = clsDataAccess.GetresultS("select top(1) RIGHT('0' + DATENAME(DAY, edate), 2) + '/' + DATENAME(MONTH,edate)+ '/' +  DATENAME(YEAR, edate)as edate FROM tbl_Employee_Attend where (Season='" + cmbYear.Text + "') and (Month='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "') and (LOcation_ID='" + Location_ID + "')");
                    try
                    {
                        txtCurrentDate.Text = Convert.ToDateTime(sql).ToString("dd/MM/yyyy");
                    }
                    catch
                    {
                        txtCurrentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }

                }
                else
                {
                    btnImport.Enabled = true;
                    txtCurrentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    DataTable dt = clsDataAccess.RunQDTbl("SELECT MAX( convert(smalldatetime ,('28/'+[MONTH]), 103)) AS mn FROM tbl_Employee_Attend WHERE (LOcation_ID ='" + cmblocation.ReturnValue + "') AND (Company_id ='" + (clsEmployee.GetCompany_ID(Convert.ToInt32(cmblocation.ReturnValue))) + "')");
                    chkAuthorise.Checked = false;
                    btnProcess.Text = "Process";
                    btnDelete.Visible = false;
                    if (chkFetch.Checked == true)
                    {
                        try
                        {
                            if (dt.Rows[0][0].ToString().Trim()!="")
                            {
                                ds_sp = chkSpAttend(1, Convert.ToInt32(txtDays.Text));
                            }
                            else
                            {
                                ds_sp = chkSpAttend(0, Convert.ToInt32(txtDays.Text));
                            }
                        }
                        catch {  ds_sp = chkSpAttend(0, Convert.ToInt32(txtDays.Text));}
                    }
                    else
                    {
                        ds_sp = chkSpAttend(0, Convert.ToInt32(txtDays.Text));
                    }
                }
                disp_Grid(ds_sp);
            }
            catch { }
            //------------ New grid created... on 11-03-2017
            ////AttendanceGrid.Visible = true;
            ////Extractcmd.Visible = false;
            ////AttendanceGrid.Columns.Clear();
            ////DataView dv = new DataView(EmployeeList());
            ////dv.Sort = "Employee Name";
            ////AttendanceGrid.DataSource = dv;

            ////int NumberOfDays;
            ////int Cnt = 1;
            ////double ab_one = 0, ab_two = 0, emp_proxy = 0, tot_wday = 0, tdays = 0;

            ////DataGridViewTextBoxColumn Dtcol;
            ////DataGridViewTextBoxColumn Dtcol1;
            ////DataGridViewCellStyle CellStyle1 = new DataGridViewCellStyle();
            ////DataGridViewCellStyle CellStyle2 = new DataGridViewCellStyle();
            ////DataGridViewCellStyle CellStyle3 = new DataGridViewCellStyle();
            ////DataGridViewCellStyle CellStyle4 = new DataGridViewCellStyle();


            ////AttendanceGrid.Columns[0].Visible = true;
            //////AttendanceGrid.Columns[1].Frozen = true;
            //////AttendanceGrid.Columns[2].Frozen = true;

            ////AttendanceGrid.Columns[1].ReadOnly = true;
            ////AttendanceGrid.Columns[2].ReadOnly = true;
            ////AttendanceGrid.Columns[1].HeaderText = "Employee Name";
            ////AttendanceGrid.Columns[2].HeaderText = "Employee Designation";
            ////AttendanceGrid.Columns[0].Width = 60;
            ////AttendanceGrid.Columns[1].Width = 150;
            ////AttendanceGrid.Columns[2].Width = 100;
            //////AttendanceGrid.Columns[3].Width = 50;

            ////AttendanceGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            ////AttendanceGrid.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            ////AttendanceGrid.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            //////AttendanceGrid.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;



            ////CellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            ////CellStyle1.BackColor = System.Drawing.Color.Honeydew;

            ////AttendanceGrid.Columns[1].DefaultCellStyle = CellStyle1;
            ////AttendanceGrid.Columns[2].DefaultCellStyle = CellStyle1;

            ////tdays = Convert.ToDouble(txtDays.Text);

            ////Dtcol1 = new DataGridViewTextBoxColumn();
            ////Dtcol1.DefaultCellStyle = CellStyle1;
            ////AttendanceGrid.Columns.Add(Dtcol1);
            ////AttendanceGrid.Columns[3].HeaderText = "Total Days worked";
            ////AttendanceGrid.Columns[3].Width = 80;
            ////AttendanceGrid.Columns[3].Frozen = true;

            ////Dtcol1 = new DataGridViewTextBoxColumn();
            ////Dtcol1.DefaultCellStyle = CellStyle1;
            ////AttendanceGrid.Columns.Add(Dtcol1);
            ////AttendanceGrid.Columns[4].HeaderText = "Proxy";
            ////AttendanceGrid.Columns[4].Width = 40;
            ////AttendanceGrid.Columns[4].Frozen = true;

            ////NumberOfDays = Convert.ToInt32(this.txtDays.Text); //DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);

            //////for (Cnt = 0; Cnt <= AttendanceGrid.Rows.Count - 1; Cnt++)
            //////{
            //////    string Salary_Head = clsDataAccess.GetresultS("select Proxy_Day from tbl_Employee_Proxy_Attendance where Employee_ID ='" + AttendanceGrid.Rows[Cnt].Cells["col_ecode"].Value + "' and Month ='" + AttenDtTmPkr.Text + "' and  Session = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + "    ");
            //////    if (Salary_Head == null)
            //////        AttendanceGrid.Rows[Cnt].Cells["col_proxy"].Value = "0";
            //////    else
            //////        AttendanceGrid.Rows[Cnt].Cells["col_proxy"].Value = Salary_Head;

            //////    AttendanceGrid.Rows[Cnt].Height = 40;
            //////}

            ////Dtcol1 = new DataGridViewTextBoxColumn();
            ////Dtcol1.DefaultCellStyle = CellStyle1;
            ////AttendanceGrid.Columns.Add(Dtcol1);
            ////AttendanceGrid.Columns[5].HeaderText = "Total Absent";
            ////AttendanceGrid.Columns[5].Width = 50;
            ////AttendanceGrid.Columns[5].Frozen = true;

            ////Dtcol1 = new DataGridViewTextBoxColumn();
            ////Dtcol1.DefaultCellStyle = CellStyle1;
            ////AttendanceGrid.Columns.Add(Dtcol1);
            ////AttendanceGrid.Columns[6].HeaderText = "Other Attendence " + (char)13 + "(Wday + proxy)";
            ////AttendanceGrid.Columns[6].Width = 70;
            ////AttendanceGrid.Columns[6].Frozen = true;

            ////Dtcol1 = new DataGridViewTextBoxColumn();
            ////Dtcol1.DefaultCellStyle = CellStyle1;
            ////AttendanceGrid.Columns.Add(Dtcol1);
            ////AttendanceGrid.Columns[7].HeaderText = "desgid";
            ////AttendanceGrid.Columns[7].Width = 50;
            ////AttendanceGrid.Columns[7].Visible = true;



            ////int count_attn = Convert.ToInt32(clsDataAccess.GetresultS("select count(*) from [tbl_Employee_Attend] where Month ='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "' and  Season = '" + cmbYear.Text + "' and Location_ID ='" + Location_ID + "'"));

            ////for (Cnt = 0; Cnt <= AttendanceGrid.Rows.Count - 1; Cnt++)
            ////{
            ////    string Salary_Head = clsDataAccess.GetresultS("select Proxy_Day from tbl_Employee_Proxy_Attendance where Employee_ID ='" + AttendanceGrid.Rows[Cnt].Cells["col_ecode"].Value + "' and Month ='" + AttenDtTmPkr.Text + "' and  Session = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + "    ");
            ////    DataTable prev_att = clsDataAccess.RunQDTbl("select  SUM(Wday) AS Wday, SUM(Proxy) AS Proxy from [tbl_Employee_Attend] where ID='" + AttendanceGrid.Rows[Cnt].Cells["col_ecode"].Value + "' and Month ='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "' and  Season = '" + cmbYear.Text + "' and (Location_ID <>'" + Location_ID + "')");
            ////    if (Salary_Head == null)
            ////        emp_proxy = 0;
            ////    else
            ////        emp_proxy = Convert.ToDouble(Salary_Head);


            ////    AttendanceGrid.Rows[Cnt].Cells["col_proxy"].Value = emp_proxy;
            ////    AttendanceGrid.Rows[Cnt].Height = 40;
            ////    AttendanceGrid.Rows[Cnt].Cells["col_desgid"].Value = clsDataAccess.GetresultS("SELECT SlNo FROM tbl_Employee_DesignationMaster WHERE (DesignationName ='" + AttendanceGrid.Rows[Cnt].Cells["col_desg"].Value + "')");
            ////    if (count_attn == 0)
            ////    {
            ////        //int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
            ////        ab_one = Convert.ToDouble(clsDataAccess.GetresultS("select count(FstLeave) from tbl_Employee_Attendance where ID='" + AttendanceGrid.Rows[Cnt].Cells["col_ecode"].Value + "' and month(LeaveDate)=" + AttenDtTmPkr.Value.Month + " AND year(LeaveDate)=" + AttenDtTmPkr.Value.Year + " and LOcation_ID in (" + Location_ID + ") and FstLeave>0"));
            ////        ab_two = Convert.ToDouble(clsDataAccess.GetresultS("select count(SndLeave) from tbl_Employee_Attendance where ID='" + AttendanceGrid.Rows[Cnt].Cells["col_ecode"].Value + "' and month(LeaveDate)=" + AttenDtTmPkr.Value.Month + " AND year(LeaveDate)=" + AttenDtTmPkr.Value.Year + " and LOcation_ID in (" + Location_ID + ") and SndLeave>0"));
            ////        ab_one = ab_one + ab_two;
            ////        if (ab_one > 0)
            ////            ab_one = ab_one / 2;
            ////    }
            ////    else
            ////    {

            ////        DataTable data_attn = clsDataAccess.RunQDTbl("select * from [tbl_Employee_Attend] where (ID='" + AttendanceGrid.Rows[Cnt].Cells["col_ecode"].Value + "') and (Month ='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "') and  (Season = '" + cmbYear.Text + "') and (Location_ID ='" + Location_ID + "')");
            ////        if (data_attn.Rows.Count > 0)
            ////        {
            ////            ab_one = Convert.ToDouble(data_attn.Rows[0]["Absent"]);
            ////        }
            ////        else
            ////        {
            ////            ab_one = 0;
            ////        }

            ////    }
            ////    //ab_one = NumberOfDays - ab_one; 
            ////    AttendanceGrid.Rows[Cnt].Cells["col_absent"].Value = ab_one;

            ////    if (ab_one > 0)
            ////    {
            ////        tot_wday = tdays - ab_one;
            ////    }
            ////    //else if (emp_proxy > 0)
            ////    //{
            ////    //    tot_wday = tdays + emp_proxy;
            ////    //}
            ////    else
            ////    {
            ////        tot_wday = tdays;
            ////    }

            ////    AttendanceGrid.Rows[Cnt].Cells["col_wday"].Value = tot_wday;
            ////    AttendanceGrid.Rows[Cnt].Cells["col_others"].Value = "WD : " + prev_att.Rows[0]["Wday"] + (char)13 + "P : " + prev_att.Rows[0]["Proxy"];

            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////    EDPMessageBox.EDPMessage.Show(ex.ToString());
            ////}
           
        }


        private void cmblocation_DropDown(object sender, EventArgs e)
        {
            cmblocation.ReturnValue = "0";
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {
                if (chkAllLocation.Checked == true)
                {
                    dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName,(select (SELECT CO_NAME FROM Company where co_code=cr.Company_ID) from Companywiseid_Relation cr where Location_ID=EL.Location_ID) as 'Company' from tbl_Emp_Location EL where Location_ID in (" + edpcom.CurrentLocation + ") and (zid='" + cmbZone.ReturnValue.Trim() + "')");
                }
                else
                {
                    dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName,(select (SELECT CO_NAME FROM Company where co_code=cr.Company_ID) from Companywiseid_Relation cr where Location_ID=EL.Location_ID) as 'Company' from tbl_Emp_Location EL where Location_ID in (" + edpcom.CurrentLocation + ") ");
                }
                if (dt.Rows.Count > 0)
                {
                    cmblocation.LookUpTable = dt;
                    cmblocation.ReturnIndex = 1;
                }
                else
                {

                    EDPMessageBox.EDPMessage.Show("No location found.", "BRAVO");

                    //cmblocation.LookUpTable = dt;
                    //cmblocation.ReturnIndex = 1;

                }
            }
            else
            {
                if (chkAllLocation.Checked == true)
                {
                    dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where (zid='" + cmbZone.ReturnValue.Trim() + "')");
                }
                else
                {
                    dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL ");
                }
                if (dt.Rows.Count > 0)
                {
                    cmblocation.LookUpTable = dt;
                    cmblocation.ReturnIndex = 1;
                }
                else
                {

                    EDPMessageBox.EDPMessage.Show("No location found.", "BRAVO");

                    //cmblocation.LookUpTable = dt;
                    //cmblocation.ReturnIndex = 1;

                }

            }
        }

        private void cmblocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Extractcmd.Visible = true;
            
            if (Information.IsNumeric(cmblocation.ReturnValue) == true)
            { 
                Location_ID = Convert.ToInt32(cmblocation.ReturnValue);
                btnAllotement.Visible = true;
            }
            else
            {
                btnAllotement.Visible = false;
                return;
            }

            if (Location_ID > 0)
            {
                lblCoid.Text = clsEmployee.GetCompany_ID(Location_ID).ToString();
                lblCo.Text = clsDataAccess.GetresultS("select CO_NAME from Company where (CO_CODE='"+lblCoid.Text+"')");

                try
                {
                    lbl_lvRt.Text = clsDataAccess.GetresultS("select isNUll((case when lv_rate>0 then lv_rate else (select ISNULL(lv_rate,0)lvRate from tbl_Comp_LVRate where (coid=cr.Company_ID)) end),0) FROM Companywiseid_Relation cr where (Company_ID='" + lblCoid.Text + "') and (Location_ID='" + Location_ID + "')");
                    //"select ISNULL(lv_rate,0)lvRate from tbl_Comp_LVRate where (coid='" + lblCoid.Text + "')");
                }
                catch { lbl_lvRt.Text = "0"; }

                txtClient.Text = clsDataAccess.GetresultS("SELECT Client_Name FROM tbl_Employee_CliantMaster where client_id=(select distinct Cliant_ID from tbl_Emp_Location where Location_ID='"+ Location_ID +"')");
                
                try
                {
                    lblLeaveID.Text = clsDataAccess.GetresultS("select LeaveId from tbl_Employee_Config_LeaveDetails where ({ fn UCASE(ShortName) } in ('AB','A')) and (Location_ID ='" + Location_ID + "')");
                    leave_id = Convert.ToInt32(lblLeaveID.Text);
                }
                catch
                {
                    MessageBox.Show("Please assign Absent (Ab) head in location wise LeaveMaster");
                }
                
                clientname();
                
                Extractcmd_Click(sender, e);

                try
                {
                    if (clsDataAccess.GetresultS("select loc_initial from Companywiseid_Relation where (Location_ID='"+Location_ID+"')") == "1")
                    {
                        dgvAttend.Columns["col_wo"].Visible = true;
                    }
                    else
                    {
                        dgvAttend.Columns["col_wo"].Visible = false;
                    }

                }
                catch { }

                if (Convert.ToDouble(clsDataAccess.ReturnValue("SELECT count(*) FROM tbl_Employee_Assign_SalStructure where (Proxy_day=1) and (Location_id='" + Location_ID + "') and (Company_id='" + lblCoid.Text + "')")) == 0)
                {
                    dgvAttend.Columns["col_proxy"].ReadOnly = true;
                    dgvAttend.Columns["col_proxy"].DefaultCellStyle.BackColor = Color.Gray;

                    MessageBox.Show("Proxy Disabled, for activation add OTA head in Salary Structure", "Bravo", MessageBoxButtons.OK);
                }
                else
                {
                    dgvAttend.Columns["col_proxy"].ReadOnly = false;
                    dgvAttend.Columns["col_proxy"].DefaultCellStyle.BackColor = Color.White;
                }
                if (Convert.ToDouble(clsDataAccess.ReturnValue("SELECT count(*) FROM tbl_Employee_Assign_SalStructure where (Proxy_day=2) and (Location_id='" + Location_ID + "') and (Company_id='" + lblCoid.Text + "')")) == 0)
                {
                    dgvAttend.Columns["col_ed"].ReadOnly = true;
                    dgvAttend.Columns["col_ed"].DefaultCellStyle.BackColor = Color.Gray;
                    if (Convert.ToInt32(clsDataAccess.GetresultS("select ed from CompanyLimiter")) == 1)
                    {
                        MessageBox.Show("ED Disabled, for activation add ED head in Salary Structure", "Bravo", MessageBoxButtons.OK);

                    }
                }
                else
                {
                    dgvAttend.Columns["col_ed"].ReadOnly = false;
                    dgvAttend.Columns["col_ed"].DefaultCellStyle.BackColor = Color.White;
                }

                lbl_msg_hrs.Text = "";
                try
                {

                    if (lbl_Accpt_wd_hrs.Text == "0")
                    {
                        dgvAttend.Columns["col_wday"].HeaderText = "WDay";
                        dgv_cnt.Columns["col_cnt_wd"].HeaderText = "WD";

                    }
                    else if (lbl_Accpt_wd_hrs.Text == "1")
                    {

                        dgvAttend.Columns["col_wday"].HeaderText = "WDay(Hrs)";
                        dgv_cnt.Columns["col_cnt_wd"].HeaderText = "WD(Hrs)";

                        lbl_msg_hrs.Text = "WD : " + lbl_wd_hrs.Text + " Hrs/day";
                    }

                    if (lbl_Accpt_ot_hrs.Text == "0")
                    {
                        dgvAttend.Columns["col_proxy"].HeaderText = "Proxy";
                        dgv_cnt.Columns["col_cnt_ot"].HeaderText = "Proxy";
                    }
                    else if (lbl_Accpt_ot_hrs.Text == "1")
                    {
                        dgvAttend.Columns["col_proxy"].HeaderText = "Proxy(Hrs)";
                        dgv_cnt.Columns["col_cnt_ot"].HeaderText = "Proxy(Hrs)";

                        if (lbl_msg_hrs.Text.Trim()== "")
                        {
                            lbl_msg_hrs.Text = "Proxy : " + lbl_ot_hrs.Text + " Hrs/day";
                        }
                        else
                        {
                            lbl_msg_hrs.Text = "  Proxy : " + lbl_ot_hrs.Text + " Hrs/day";
                        }

                    }


                    if (lbl_Accpt_ed_hrs.Text == "0")
                    {
                        dgvAttend.Columns["col_ed"].HeaderText = "ED";
                        dgv_cnt.Columns["col_cnt_ed"].HeaderText = "ED";
                    }
                    else if (lbl_Accpt_ed_hrs.Text == "1")
                    {

                        dgvAttend.Columns["col_ed"].HeaderText = "ED(Hrs)";
                        dgv_cnt.Columns["col_cnt_ed"].HeaderText = "ED(Hrs)";

                        if (lbl_msg_hrs.Text.Trim() == "")
                        {
                            lbl_msg_hrs.Text = "ED : " + lbl_ed_hrs.Text + " Hrs/day";
                        }
                        else
                        {
                            lbl_msg_hrs.Text = "  ED : " + lbl_ed_hrs.Text + " Hrs/day";
                        }
                    }

                    if (lbl_msg_hrs.Text.Trim() == "")
                    {

                        lbl_msg_hrs.Visible = false;
                    }
                    else
                    {
                        lbl_msg_hrs.Visible = true;
                    }
                }
                catch
                {
                }

                if (Salary_Exist_Cnt_For_Location_Session_Month() > 0)
                {
                    MessageBox.Show("You can not change / delete this attendance since salary has been created for this month at this location", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnDelete.Visible = false;
                    btnProcess.Visible = false;
                    btnAllotement.Visible = false;
                    dgvAttend.ReadOnly = true;
                    btnImport.Enabled = false;
                    dgvAttend.Focus();
                }
                else
                {
                    btnImport.Enabled = true;
                    btnAllotement.Visible = true;
                    btnProcess.Visible = true;
                    btnDelete.Visible = true;
                    dgvAttend.ReadOnly = false;
                   
                    dgvAttend.Focus();
                    calc_desg(); 
                }
            }
            else
            {
                return;
            }


        }

        private void Closecmd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Close ?", "Bravo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Close();

            }
        }

        private void DeleteSelcmd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete ?", "Bravo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Attend  where (Mon='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "') and  Season = '" + cmbYear.Text + "' and Location_ID ='" + Location_ID + "'");
                clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Proxy_Attendance  where (Month='" + AttenDtTmPkr.Value.ToString("MMMM") + "') and (Session = '" + cmbYear.Text + "') and (Location_ID ='" + Location_ID + "')");

                clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Attendance WHERE (LOcation_ID='" + Location_ID + "') AND (DATENAME(m, LeaveDate) + '-' + CAST(DATEPART(yyyy, LeaveDate) AS varchar) ='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "')");
                ERPMessageBox.ERPMessage.Show("Attendance Deleted Successfully.");
                Extractcmd_Click(sender, e);

            }
        }

        public void shift()
        {
            string cnt_sft = clsDataAccess.GetresultS("select count(*) from tbl_shift" );

        
            if (Convert.ToInt32(cnt_sft)==0)
            {
                string sid = clsDataAccess.GetresultS("select max(sid)+1 from tbl_shift");
                   string sno="1";
                string sname="General Shift";
                string shrs = "8 Hrs";
                string    time_from="09:00 AM";
                 string   time_upto="6:00 PM";


                string  qry="INSERT INTO tbl_shift(sid,sno,sname,shrs,time_from,time_upto) VALUES ('0','"+
                    sno +"','"+sname +"','"+shrs +"','"+time_from +"','"+time_upto +"')";
                    bool bl = clsDataAccess.RunQry(qry);
                    
            }
        }

        public void chk_desg()
        {
              DataTable dt = new DataTable();
            dt.Columns.Add("desg", typeof(string));
           
            dt.Columns.Add("desgid", typeof(string));

            foreach (DataGridViewRow dgvR in dgvAttend.Rows)
            {
                dt.Rows.Add(dgvR.Cells["col_desg"].Value, dgvR.Cells["col_desgid"].Value);
            }

            //var distinctRows = (from DataRow dRow in dt.Rows
            //                    select dRow["desg"]).Distinct();
            DataView view = new DataView(dt);
            DataTable distinctValues = view.ToTable(true, "desg");
            string gs="0",dsg="",bs_id = clsDataAccess.ReturnValue("select c_det from tbl_Employee_Assign_SalStructure where  (c_type='COMPANY LUMPSUM') and (p_type='E') and (SAL_HEAD='1') and (Location_id='" + Location_ID + "') and (Company_id='" + lblCoid.Text + "')");
          //  int sum = Convert.ToInt32(dt.Compute("SUM(Salary)", "EmployeeId > 2"));
            if (bs_id != "0")
            {
                for (int ix = 0; ix < distinctValues.Rows.Count; ix++)
                {

                    gs = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where (LUMPID =" + bs_id + ") and (GRADE =" + clsDataAccess.ReturnValue("select SlNo from tbl_Employee_DesignationMaster where (DesignationName='" + distinctValues.Rows[ix]["desg"].ToString()+"')") + " or GRADE ='0')");

                    if (gs == "" || gs == null || gs == "0")
                    {
                        if (dsg == "")
                        {
                            dsg = distinctValues.Rows[ix]["desg"].ToString();
                        }
                        else
                        {
                            dsg = dsg+", "+distinctValues.Rows[ix]["desg"].ToString();
                        }
                    }
                }

                if (dsg != "")
                {
                    MessageBox.Show("No Basic assigned for following designation : " + dsg,"BRAVO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        public void calc_desg()
        {
            //DataSet ds = dgvAttend.Rows;

            DataTable dt = new DataTable();
            dt.Columns.Add("desg", typeof(string));
            dt.Columns.Add("wday", typeof(double));
            dt.Columns.Add("proxy", typeof(double));
            dt.Columns.Add("ed", typeof(double));
           // dt.Columns.Add("desgid", typeof(string));

            foreach (DataGridViewRow dgvR in dgvAttend.Rows)
            {
                dt.Rows.Add(dgvR.Cells["col_desg"].Value, Convert.ToDouble(dgvR.Cells["col_wday"].Value), Convert.ToDouble(dgvR.Cells["col_proxy"].Value), Convert.ToDouble(dgvR.Cells["col_ed"].Value));
                    //, dgvR.Cells["col_desgid"].Value);
            }

            //var distinctRows = (from DataRow dRow in dt.Rows
            //                    select dRow["desg"]).Distinct();
            DataView view = new DataView(dt);
            DataTable distinctValues = view.ToTable(true, "desg");
            try
            {
                dgv_cnt.Rows.Clear();
            }
            catch{}

          //  int sum = Convert.ToInt32(dt.Compute("SUM(Salary)", "EmployeeId > 2"));
            for (int ix = 0; ix < distinctValues.Rows.Count;ix++ )
            {
                dgv_cnt.Rows.Add();

                dgv_cnt.Rows[ix].Cells["col_cnt_desg"].Value=distinctValues.Rows[ix][0].ToString();
                dgv_cnt.Rows[ix].Cells["col_cnt_no"].Value= Convert.ToInt32(dt.Compute("Count(desg)", "desg ='"+distinctValues.Rows[ix][0].ToString()+"'")).ToString();
                try
                {
                    dgv_cnt.Rows[ix].Cells["col_cnt_wd"].Value = Convert.ToDouble(dt.Compute("SUM(wday)", "desg ='" + distinctValues.Rows[ix][0].ToString() + "'"));
                }
                catch {
                    dgv_cnt.Rows[ix].Cells["col_cnt_wd"].Value = 0;
                }
                try{
                   dgv_cnt.Rows[ix].Cells["col_cnt_ot"].Value = Convert.ToDouble(dt.Compute("SUM(proxy)", "desg ='" + distinctValues.Rows[ix][0].ToString() + "'")).ToString();
                     }
                catch {
                    dgv_cnt.Rows[ix].Cells["col_cnt_ot"].Value = 0;
                }
                try{
                dgv_cnt.Rows[ix].Cells["col_cnt_ed"].Value = Convert.ToDouble(dt.Compute("SUM(ed)", "desg ='" + distinctValues.Rows[ix][0].ToString() + "'")).ToString();
                     }
                catch {
                    dgv_cnt.Rows[ix].Cells["col_cnt_ed"].Value = 0;
                }
                
            }
            dgv_cnt.Visible = true;
        }


        private void frmEmpAttend_Load(object sender, EventArgs e)
        {
            try
            {
                MEmp = Convert.ToInt32(edpcom.GetDatatable("select MEmp from CompanyLimiter").Rows[0][0].ToString());

            }
            catch { MEmp = 0; }



            try
            {
                if (Convert.ToInt32(edpcom.GetDatatable("select ieAttend from CompanyLimiter").Rows[0][0].ToString()) == 1)
                {
                    btnExport.Visible = true;
                    btnImport.Visible = true;
                }
                else
                {
                    btnExport.Visible = false;
                    btnImport.Visible = false;
                }

            }
            catch { }

            txtDays.ReadOnly = true;

            cWD_MOD = 0;
            wd_limit = 60;
            try
            {
                cWD_MOD = Convert.ToInt32(Convert.ToDouble( clsDataAccess.GetresultS("select desgday from CompanyLimiter")));
            }
            catch
            {
                cWD_MOD = 0;
            }


            try
            {
                wd_limit = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select wd_limit from CompanyLimiter")));

            }
            catch { wd_limit = 60; }

            if (cWD_MOD == 1)
            {

                lblConfig_msg.Visible = true;
            }
            else
            {
                lblConfig_msg.Visible = false;
            }

            lbl_lv_type.Text = clsDataAccess.GetresultS("select isNull(lv_type,1) from CompanyLimiter");

            if (lbl_lv_type.Text == "1")
            {
                lbl_lv_msg.Visible = true;
            }
            else
            {
                lbl_lv_msg.Visible=false;
            }
            AttenDtTmPkr.Value = DateTime.Now.AddMonths(-1); 
            clsfirsttime obj_CFT = new clsfirsttime();
            bool result;
            txtCurrentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //generate year
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);


            //
            Extractcmd.Visible = false;
            //set session
            try
            {
                strAttenDtTmPkrMonth = AttenDtTmPkr.Text.Substring(0, AttenDtTmPkr.Text.IndexOf('-'));
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
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
            //

            clsGeneralShow genralshow = new clsGeneralShow();
            genralshow.getCurLocID();

            edpcon = new EDPConnection();
            int var_mstcount = Convert.ToInt32(clsDataAccess.GetresultIT("tbl_Employee_Attend"));
            if (var_mstcount == 0)
            {
                edpcon.Open();
                result = obj_CFT.tbl_Emp_Attend(edpcon.mycon);
            }
            chkAllLocation.Checked = false;
            txtCurrentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            cmbZone.Text = "";
            cmbZone.Enabled = false;

            shift();
            Configuration_Menu_TypeDoc_companySetting();
            //this.WindowState = FormWindowState.Maximized;

                     

                btnEmpJoining.Enabled = chk_permission("I", 0);


                int asign = 0, ed_assign=0,ed_zone=0,ed_wo=0;
                bool lv_col = false,ed_col=false,bl_zone=false,bl_wo=false;
                try
                {
                    asign = Convert.ToInt32(clsDataAccess.GetresultS("select lv from CompanyLimiter"));
                }
                catch
                {
                    asign = 0;
                }

                try
                {
                    ed_assign = Convert.ToInt32(clsDataAccess.GetresultS("select ed from CompanyLimiter"));
                }
                catch
                {
                    ed_assign = 0;
                }


                try
                {
                    ed_wo = Convert.ToInt32(clsDataAccess.GetresultS("select woff from CompanyLimiter"));
                }
                catch
                {
                    ed_wo = 0;
                }
                


                try
                {
                    ed_zone = Convert.ToInt32(clsDataAccess.GetresultS("select zone from CompanyLimiter"));
                }
                catch
                {
                    ed_zone = 0;
                }


                if (ed_zone == 1)
                {
                    bl_zone = true;
                }
                else
                {
                    bl_zone = false;
                }


                if (ed_wo == 1)
                {
                    bl_wo = true;
                }
                else
                {
                    bl_wo = false;
                }

                if (asign == 1)
                {
                    lv_col=true;
                }
                else
                {
                    lv_col = false;
                }
                if (ed_assign == 1)
                {
                    ed_col = true;
                }
                else
                {
                    ed_col = false;
                }

                dgvAttend.Columns["col_ed"].Visible = ed_col;

                dgvAttend.Columns["col_lv_earn"].Visible = lv_col;
                dgvAttend.Columns["col_lv_adj"].Visible = lv_col;
                dgvAttend.Columns["col_lv_pbal"].Visible = lv_col;
                dgvAttend.Columns["col_lv_cbal"].Visible = lv_col;
                dgvAttend.Columns["col_WO"].Visible = bl_wo;



                chkAllLocation.Visible = bl_zone;
                cmbZone.Visible = bl_zone;

                WindowState = FormWindowState.Maximized;
        }

        private bool chk_permission(string tp, double eid)
        {
            DataTable dtCompanyLimiter = clsDataAccess.RunQDTbl("select EmpLimit from CompanyLimiter");
            int count_emp = 0;
            Boolean bl;
            if (tp == "I")
                count_emp = Convert.ToInt32(clsDataAccess.RunQDTbl("select count(*) as 'TotalRecord' from [tbl_Employee_Mast]").Rows[0][0]);
            else if (tp == "U")
                count_emp = Convert.ToInt32(clsDataAccess.RunQDTbl("select count(*)+1 as 'TotalRecord' from [tbl_Employee_Mast] where (code<='" + eid + "')").Rows[0][0]);


            if (count_emp == 0)
                bl = true;
            else
            {

                if (dtCompanyLimiter.Rows.Count > 0)
                {
                    if (count_emp < Convert.ToInt32(dtCompanyLimiter.Rows[0]["EmpLimit"]) || Convert.ToInt32(dtCompanyLimiter.Rows[0]["EmpLimit"]) == 0)
                        bl = true;
                    else
                        bl = false;
                }
                else
                {
                    bl = false;
                }
            }

            return bl;

        }

        public void Configuration_Menu_TypeDoc_companySetting()
        {
            try
            {
                string filePath = "";
                filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
                string line;
                if (File.Exists(filePath))
                {
                    StreamReader file = null;
                    try
                    {
                        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
                        edpcon.Close();
                        file = new StreamReader(filePath);
                        if (file.ReadLine() != null)
                        {
                            int chk_str = 0;
                            while ((line = file.ReadLine()) != null)
                            {
                                string[] StrSTAR = line.Trim().Split('*');
                                if (StrSTAR.Length == 2)
                                {
                                    if (StrSTAR[0].Trim() == "")
                                        continue;
                                }

                                string[] StrLine = line.Trim().Split('[');
                                if (StrLine.Length == 2)
                                {
                                    string str = line.Substring(1, line.Length - 2);
                                    if (str == "attend_type")
                                        chk_str = 1;
                                    else
                                        chk_str = 0;
                                }

                                string[] StrLine_WACC = line.Trim().Split(';');

                                if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                                {
                                    switch (StrLine_WACC[0])
                                    {
                                        case "1":
                                            dgvAttend.Columns["col_lv_earn"].Visible = true;
                                            dgvAttend.Columns["col_lv_adj"].Visible = true;
                                            dgvAttend.Columns["col_lv_pbal"].Visible = true;
                                            dgvAttend.Columns["col_lv_cbal"].Visible = true;
                                            break;
                                        case "0":
                                            dgvAttend.Columns["col_lv_earn"].Visible = false;
                                            dgvAttend.Columns["col_lv_adj"].Visible =false;
                                            dgvAttend.Columns["col_lv_pbal"].Visible = false;
                                            dgvAttend.Columns["col_lv_cbal"].Visible = false;
                                            break;

                                    }
                                }

                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }

        }

        private void AttendanceGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (AttendanceGrid.Columns[e.ColumnIndex].HeaderText == "Proxy")
            {
                if (AttendanceGrid.Rows[e.RowIndex].Cells[0] != null)
                    if (Convert.ToString(AttendanceGrid.Rows[e.RowIndex].Cells[0]) != "")
                        if (Information.IsNumeric(AttendanceGrid.Rows[e.RowIndex].Cells["col_proxy"].Value) == true)
                        {
                            if (Convert.ToDouble(AttendanceGrid.Rows[e.RowIndex].Cells["col_proxy"].Value) > Convert.ToDouble(wd_limit))
                            {
                                if (lbl_Accpt_ot_hrs.Text == "1" && Convert.ToDouble(AttendanceGrid.Rows[e.RowIndex].Cells["col_proxy"].Value) > (Convert.ToDouble(lbl_ot_hrs.Text)* Convert.ToDouble(wd_limit)) )
                                {
                                    ERPMessageBox.ERPMessage.Show("Proxy Max 60 Days / "+(Convert.ToDouble(lbl_ot_hrs.Text)* Convert.ToDouble(wd_limit))+" Hrs", "BRAVO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    AttendanceGrid.Rows[e.RowIndex].Cells["col_proxy"].Value = 0;
                                    return;
                                }
                                else
                                {
                                    ERPMessageBox.ERPMessage.Show("Proxy Max 60 Days", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    AttendanceGrid.Rows[e.RowIndex].Cells["col_proxy"].Value = 0;
                                    return;
                                }
                            }
                            else if (Convert.ToDouble(AttendanceGrid.Rows[e.RowIndex].Cells["col_proxy"].Value) < 0)
                            {
                                ERPMessageBox.ERPMessage.Show("Proxy No Cannot be Negative", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                AttendanceGrid.Rows[e.RowIndex].Cells["col_proxy"].Value = 0;
                                return;
                            }
                            else
                            {
                                int company_Id = clsEmployee.GetCompany_ID(Location_ID);
                                Boolean flug_save = false;
                                DataTable dt = clsDataAccess.RunQDTbl("select Employee_ID from tbl_Employee_Proxy_Attendance where Employee_ID ='" + AttendanceGrid.Rows[e.RowIndex].Cells["col_ecode"].Value + "' and Month ='" + strAttenDtTmPkrMonth + "' and  Session = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + "    ");
                                if (dt.Rows.Count > 0)
                                    clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Proxy_Attendance where Employee_ID ='" + AttendanceGrid.Rows[e.RowIndex].Cells["col_ecode"].Value + "' and Month ='" + strAttenDtTmPkrMonth + "' and  Session = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + " ");

                                // flug_save = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Proxy_Attendance(Employee_ID,Proxy_Day,Month,Session,Location_ID,Company_id) values('" + AttendanceGrid.Rows[e.RowIndex].Cells["col_ecode"].Value + "','" + AttendanceGrid.Rows[e.RowIndex].Cells["col_wday"].Value + "','" + strAttenDtTmPkrMonth + "','" + cmbYear.Text + "'," + Location_ID + ",'" + company_Id + "')");
                            }

                        }
            }
        }
        private void SessionValueCheckAndAssignNoOfDays()
        {
            int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
            txtDays.Text = NumberOfDays.ToString();

            if (AttenDtTmPkr.Value.Month >= 4)
            {
                cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year;

                // cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                // cmbYear.SelectedIndex = 1;
            }

        }
        private void InsertUpdateAttendaceLogDet()
        {
            try
            {


                // Boolean rs = false;
                edpcon.Open();
                SqlCommand sqlcmd = new SqlCommand("sp_insert_update_attendance_log_details", edpcon.mycon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@company_id", SqlDbType.VarChar).Value = Convert.ToString(clsEmployee.GetCompany_ID(Convert.ToInt32(cmblocation.ReturnValue)));
                sqlcmd.Parameters.AddWithValue("@location_id", SqlDbType.VarChar).Value = cmblocation.ReturnValue;
                sqlcmd.Parameters.AddWithValue("@session", SqlDbType.VarChar).Value = cmbYear.Text;
                sqlcmd.Parameters.AddWithValue("@month", SqlDbType.VarChar).Value = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
                sqlcmd.Parameters.AddWithValue("@log_status_attendance_wise", SqlDbType.VarChar).Value = "M";
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
        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SessionValueCheckAndAssignNoOfDays();
                AttendanceGrid.Columns.Clear();
                cmblocation.Text = "";


            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.ToString());
            }
        }
        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                strAttenDtTmPkrMonth = AttenDtTmPkr.Text.Substring(0, AttenDtTmPkr.Text.IndexOf('-'));
                SessionValueCheckAndAssignNoOfDays();
                AttendanceGrid.Columns.Clear();
                cmblocation.Text = "";
                dgvAttend.Rows.Clear();
                lblWO.Text = NoOfSundays(AttenDtTmPkr.Value).ToString();

            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.ToString());
            }
        }

        //private void btnProcess_Click(object sender, EventArgs e)
        //{
        //    //if (AttendanceGrid.Columns.Count <= 0)
        //    //{
        //    //    EDPMessageBox.EDPMessage.Show("There is no attendance list for process.");
        //    //}
        //    //else if (Salary_Exist_Cnt_For_Location_Session_Month() > 0)
        //    //{
        //    //    EDPMessageBox.EDPMessage.Show("You can not change this attendance since salary has been created for this month at this location");
        //    //}
        //    //else
        //    //{
        //    //    int cnt = 0, company_Id = 0;
        //    //    company_Id = clsEmployee.GetCompany_ID(Location_ID);
        //    //    string empid;
        //    //    double tdays, tabsent, tproxy, wdays;
        //    //    clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Attend where Month='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "' and  Season = '" + cmbYear.Text + "' and Location_ID ='" + Location_ID + "'");
        //    //    edpcom.InsertMidasLog(this, true, "proc", "Mon:" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + " | Loc:" + Location_ID);
        //    //    for (cnt = 0; cnt < AttendanceGrid.Rows.Count; cnt++)
        //    //    {
        //    //        empid = AttendanceGrid.Rows[cnt].Cells["col_ecode"].Value.ToString();
        //    //        tdays = Convert.ToDouble(txtDays.Text);
        //    //        wdays = Convert.ToDouble(AttendanceGrid.Rows[cnt].Cells["col_wday"].Value);
        //    //        try
        //    //        { tproxy = Convert.ToDouble(AttendanceGrid.Rows[cnt].Cells["col_proxy"].Value); }
        //    //        catch
        //    //        { tproxy = 0; }
        //    //        try
        //    //        { tabsent = Convert.ToDouble(AttendanceGrid.Rows[cnt].Cells["col_absent"].Value); }
        //    //        catch
        //    //        { tabsent = 0; }

        //    //        if (tproxy == 0 && tabsent == 0)
        //    //        {
        //    //            if (tdays > wdays)
        //    //            {
        //    //                tabsent = tdays - wdays;

        //    //                tproxy = 0;
        //    //            }
        //    //            else
        //    //            {
        //    //                tabsent = 0;
        //    //                tproxy = wdays - tdays;
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            if (tabsent > 0)
        //    //            {
        //    //                wdays = tdays - tabsent;
        //    //                AttendanceGrid.Rows[cnt].Cells["col_wday"].Value = wdays;

        //    //            }
        //    //            else
        //    //            {
        //    //                tabsent = tdays - wdays;

        //    //            }


        //    //        }
        //    //        AttendanceGrid.Rows[cnt].Cells["col_proxy"].Value = tproxy;

        //    //        AttendanceGrid.Rows[cnt].Cells["col_absent"].Value = tabsent;


        //    //        //=============Proxy===============================================================

        //    //        if (AttendanceGrid.Rows[cnt].Cells[0] != null)
        //    //            if (Convert.ToString(AttendanceGrid.Rows[cnt].Cells[0]) != "")
        //    //                if (Information.IsNumeric(AttendanceGrid.Rows[cnt].Cells["col_proxy"].Value) == true)
        //    //                {
        //    //                    if (Convert.ToDouble(AttendanceGrid.Rows[cnt].Cells["col_proxy"].Value) > 60)
        //    //                    {
        //    //                        ERPMessageBox.ERPMessage.Show(AttendanceGrid.Rows[cnt].Cells["col_ecode"].Value + " : Proxy Max 60 Days", "Attendance");
        //    //                        AttendanceGrid.Rows[cnt].Cells["col_proxy"].Value = 0;
        //    //                        return;
        //    //                    }
        //    //                    else if (Convert.ToDouble(AttendanceGrid.Rows[cnt].Cells["col_proxy"].Value) < 0)
        //    //                    {
        //    //                        ERPMessageBox.ERPMessage.Show(AttendanceGrid.Rows[cnt].Cells["col_ecode"].Value + " : Proxy Cannot be Negative", "Attendance");
        //    //                        AttendanceGrid.Rows[cnt].Cells["col_proxy"].Value = 0;
        //    //                        return;
        //    //                    }
        //    //                    else
        //    //                    {
        //    //                        //  company_Id = clsEmployee.GetCompany_ID(Location_ID);
        //    //                        Boolean flug_save = false;
        //    //                        DataTable dt = clsDataAccess.RunQDTbl("select Employee_ID from tbl_Employee_Proxy_Attendance where Employee_ID ='" + AttendanceGrid.Rows[cnt].Cells["col_ecode"].Value + "' and Month ='" + AttenDtTmPkr.Text + "' and  Session = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + "    ");
        //    //                        if (dt.Rows.Count > 0)
        //    //                            clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Proxy_Attendance where Employee_ID ='" + AttendanceGrid.Rows[cnt].Cells["col_ecode"].Value + "' and Month ='" + AttenDtTmPkr.Text + "' and  Session = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + " ");

        //    //                        flug_save = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Proxy_Attendance(Employee_ID,Proxy_Day,Month,Session,Location_ID,Company_id) values('" + AttendanceGrid.Rows[cnt].Cells["col_ecode"].Value + "','" + AttendanceGrid.Rows[cnt].Cells["col_proxy"].Value + "','" + AttenDtTmPkr.Text + "','" + cmbYear.Text + "'," + Location_ID + ",'" + company_Id + "')");
        //    //                    }

        //    //                }
        //    //        //================absent==================================================================
        //    //        if (tabsent > 0)
        //    //        {
        //    //            clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Attendance where ID='" + AttendanceGrid.Rows[cnt].Cells["col_ecode"].Value + "' and month(LeaveDate)='" + AttenDtTmPkr.Value.Month + "' AND year(LeaveDate)=" + AttenDtTmPkr.Value.Year + " and  Season = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + " ");
        //    //            for (int var_ts = 1; var_ts <= tabsent; var_ts++)
        //    //            {

        //    //                LvDate = DatePatern(var_ts + "/" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year);
        //    //                live_fast = leave_id;
        //    //                live_second = leave_id;
        //    //                clsDataAccess.RunNQwithStatus("INSERT INTO tbl_Employee_Attendance(ID,Remarks,LeaveDate,FstLeave," +
        //    //       "SndLeave,LeaveType,DayStatus,Location_ID,FstProxy,SndProxy,Company_id,season) values('" + AttendanceGrid.Rows[cnt].Cells["col_ecode"].Value.ToString() + "','-','" + LvDate + "'," + live_fast + "," +
        //    //       live_second + "," + PayVal + "," + DayStatus + "," + Location_ID + "," + FstProxy + "," + SendProxy + ",'" + company_Id + "','" + cmbYear.Text + "')");

        //    //            }


        //    //        }


        //    //        clsDataAccess.RunNQwithStatus("INSERT INTO [tbl_Employee_Attend]([ID],[MOD],[Wday],[Absent],[Proxy],[Season],[Month],[LOcation_ID],[Company_id]) VALUES ('" + empid + "','" + tdays + "','" + wdays + "','" + tabsent + "','" + tproxy + "','" + cmbYear.Text + "','" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "','" + Location_ID + "','" + company_Id + "')");

        //    //        InsertUpdateAttendaceLogDet();

        //    //    }
        //    //    MessageBox.Show("Attendance Accepted..", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //    AttenDtTmPkr.Value = DateTime.Now;
        //    //}
        //}

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLeaveDetails_Click(object sender, EventArgs e)
        {
            try
            {
                Config_LeaveDetails FB = new Config_LeaveDetails();
                FB.ShowDialog();
            }
            catch
            {

            }
        }


        private void AttendanceGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int sal_in = Salary_Exist_Cnt_For_Location_Session_Month();
                if (sal_in > 0)
                {
                    EDPMessageBox.EDPMessage.Show("You can not change this attendance since salary has been created for this month at this location");

                }
            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.ToString());
            }
        }
        public bool chk_data(string ecode)
        {
            bool rc = false;
            try
            {
                foreach (DataGridViewRow row in dgvAttend.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(ecode))
                    {
                        rc = true;
                        break;
                    }
                }
            }
            catch
            {

            }

            return rc;
        }


        public bool Rechk_data(string ecode, int idx)
        {
            bool rc = false;
            try
            {
                foreach (DataGridViewRow row in dgvAttend.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(ecode))
                    {
                        MessageBox.Show("Name " + row.Cells[1].Value.ToString() + " already exist, Check Row : " + (idx +1), "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (File.Exists(path))
                        //{
                        //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                        //    {

                        //        //tw.WriteLine("Name: " + row.Cells[1].Value.ToString() + " ECode: " + ecode + " already exist, Check Row : " + (idx + 1));

                        //        //tw.Close();
                        //        file.WriteLine("Name: " + row.Cells[1].Value.ToString() + " ECode: " + ecode + " already exist, Check Row : " + idx + 1);
                        //        file.Close();
                        //    }
                            
                        //}
                        rc = true;
                        break;
                    }
                }
            }
            catch
            {

            }

            return rc;
        }

        private void AddARow(DataTable table)
        {
            // Use the NewRow method to create a DataRow with 
            // the table's schema.
            DataRow newRow = table.NewRow();

            // Add the row to the rows collection.
            table.Rows.Add(newRow);
        }

        private void btnAllotement_Click(object sender, EventArgs e)
        {
            try
            {
                string shift = "", sfid = "", sno = "";
                string sqlstmnt = "";
                if (MEmp == 1)
                {
                    sqlstmnt = "SELECT ID, " +
      "(CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + " +
      "(CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + " +
      "(CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS EName," +
      "(SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE (SlNo = em.DesgId)) AS Designation" +
                        ",IsNull((SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = em.Location_id)),'-') AS 'Base Location'," +
                        "IsNull((SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id=el.Cliant_ID) as Client FROM tbl_Emp_Location el WHERE (Location_ID = em.Location_id)),'-') AS 'Base Client'," +
                        "(SELECT DISTINCT CO_NAME FROM Company WHERE (GCODE = em.Company_id)) AS Company" +
      " FROM tbl_Employee_Mast AS em  where (active=1) and (company_id='" + lblCoid.Text + "') ORDER BY FirstName";
                }
                else
                {
                    sqlstmnt = "SELECT ID, " +
     "(CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + " +
     "(CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + " +
     "(CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS EName," +
     "(SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE (SlNo = em.DesgId)) AS Designation" +
                       ",IsNull((SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = em.Location_id)),'-') AS 'Base Location'," +
                       "IsNull((SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id=el.Cliant_ID) as Client FROM tbl_Emp_Location el WHERE (Location_ID = em.Location_id)),'-') AS 'Base Client'," +
                       "(SELECT DISTINCT CO_NAME FROM Company WHERE (GCODE = em.Company_id)) AS Company" +
     " FROM tbl_Employee_Mast AS em  where (active=1) ORDER BY FirstName";
                }
                EDPCommon.MLOV_EDP(sqlstmnt, "Tag ID", "Select EName", "Select EName", 0, "CMPN", 0);

                arrecode.Clear();
                arrecode = EDPCommon.arr_mod;
                string vecode = "", vename = "", str = "";
                if (arrecode.Count > 0)
                {
                    get_ecode.Clear();
                    arrecode = EDPCommon.arr_mod;
                    get_ecode = EDPCommon.get_code;

                    arrayEcode = "";
                    DataSet ds = new DataSet();

                    DataTable dataTable = new DataTable();
                    //ds.Tables[AttendanceGrid];



                    for (int i = 0; i <= arrecode.Count - 1; i++)
                    {


                        vecode = arrecode[i].ToString();
                        vename = get_ecode[i].ToString();
                        //if (chk_data(vecode) == false || chk_data(vecode))
                        if (chk_data(vecode) == false || chk_data(vecode) == true)
                        {
                            str = "select (SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE (SlNo = em.DesgId)) AS Designation, DesgId FROM tbl_Employee_Mast AS em where (ID='" + vecode + "')";
                            DataTable dv = clsDataAccess.RunQDTbl(str);
                            try
                            {

                                //DataRow drToAdd = dataTable.NewRow();
                                //DataView dvg = new DataView((DataTable)AttendanceGrid.DataSource);
                                //drToAdd[0] = vecode;
                                //drToAdd[1] = vename;
                                //drToAdd[2] = dv.Rows[0][0].ToString();
                                //drToAdd[3] = txtDays.Text;
                                //drToAdd[4] = "0";
                                //drToAdd[5] = "0";

                                //DataTable prev_att = clsDataAccess.RunQDTbl("select  SUM(Wday) AS Wday, SUM(Proxy) AS Proxy from [tbl_Employee_Attend] where ID='" + vecode + "' and Month ='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "' and  Season = '" + cmbYear.Text + "' and (Location_ID <>'" + Location_ID + "')");
                                //drToAdd[6] = "WD : " + prev_att.Rows[0]["wday"] + (char)13 + "P : " + prev_att.Rows[0]["proxy"];


                                //drToAdd[7] = dv.Rows[0][1].ToString();
                                //dataTable.Rows.Add(drToAdd);
                                //dataTable.AcceptChanges();
                                //dvg.AddNew();
                                for (int idx = 0; idx < dgvAttend.Rows.Count; idx++)
                                {
                                    if (dgvAttend.Rows[idx].Cells["col_ecode"].Value.ToString().Trim() == vecode)
                                    {
                                        MessageBox.Show("Name "+ vename + " already exist, Check Row : "+ idx+1,"BRAVO",MessageBoxButtons.OK, MessageBoxIcon.Information );

                                        break;
                                    }

                                }

                                int ind = dgvAttend.Rows.Add();
                                this.dgvAttend.Rows[ind].Cells["col_ecode"].Value = vecode;
                                this.dgvAttend.Rows[ind].Cells["col_ename"].Value = vename;
                                this.dgvAttend.Rows[ind].Cells["col_desg"].Value = dv.Rows[0][0].ToString();
                                this.dgvAttend.Rows[ind].Cells["col_wday"].Value = txtDays.Text;
                                this.dgvAttend.Rows[ind].Cells["col_proxy"].Value = 0;
                                this.dgvAttend.Rows[ind].Cells["col_ed"].Value = 0;
                                this.dgvAttend.Rows[ind].Cells["col_WO"].Value = lblWO.Text;
                                dgvAttend.Rows[ind].Cells["col_absent"].Value = 0;

                                
                                dgvAttend.Rows[ind].Cells["col_desgid"].Value = dv.Rows[0][1].ToString();
                                shift = ""; sfid = ""; sno = "";
                                if (btnProcess.Text.ToLower() == "process")
                                {
                                    shift = clsDataAccess.GetresultS("select isNull(sname,'General Shift') from tbl_shift where (sid='0')");
                                    sfid = "0";
                                    sno = "1";
                                }
                                else if (btnProcess.Text.ToLower() == "reprocess")
                                {
                                    try
                                    {
                                        sfid = clsDataAccess.GetresultS("select isNull(sfid,0) FROM tbl_Employee_Attend where (Season='" + cmbYear.Text + "') and (Month='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "') and (LOcation_ID='" + Location_ID + "') and (ID='" + ds.Tables[0].Rows[ind]["ID"].ToString() + "')");
                                        if (sfid.Trim() == "")
                                        {
                                            sfid = "0";
                                        }
                                    }
                                    catch { sfid = "0"; }
                                    try
                                    {
                                        sno = clsDataAccess.GetresultS("select isNull(sno,0) FROM tbl_Employee_Attend where (Season='" + cmbYear.Text + "') and (Month='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "') and (LOcation_ID='" + Location_ID + "') and (ID='" + ds.Tables[0].Rows[ind]["ID"].ToString() + "')");
                                    }
                                    catch { sno = "0"; }
                                    if (sno.Trim() == "")
                                    {
                                        sno = "0";
                                    }
                                    try
                                    {
                                        shift = clsDataAccess.GetresultS("select isNull(sname,'General Shift') from tbl_shift where (sid='" + sfid + "')");
                                    }
                                    catch
                                    {
                                        shift = "General Shift";
                                        sno = "0";
                                    }
                                }
                                if (shift == DBNull.Value.ToString())
                                {
                                    shift = "General Shift";
                                    sno = "0";
                                }

                                dgvAttend.Rows[ind].Cells["col_shift"].Value = shift.ToString();
                                dgvAttend.Rows[ind].Cells["col_shift_id"].Value = sno.ToString();


                                DataTable prev_att = clsDataAccess.RunQDTbl("select IsNull(SUM(Wday),0) AS Wday, IsNull(SUM(Proxy),0) AS Proxy from [tbl_Employee_Attend] where ID='" + vecode + "' and Month ='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "' and  Season = '" + cmbYear.Text + "' and (Location_ID <>'" + Location_ID + "')");
                                dgvAttend.Rows[ind].Cells["col_others"].Value = "WD : " + prev_att.Rows[0]["wday"] + (char)13 + "P : " + prev_att.Rows[0]["proxy"];

                                calc_desg();
                                //dgvAttend.AutoResizeColumns();
                                //dgvAttend.AutoResizeRows();
                            }
                            catch { }

                        }
                    }

                }
            }
            catch { }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            chk_desg();
            if (MessageBox.Show("Do you want to process ?", "Bravo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                double cWdMod = 0, cWD=0;
                string desg_id = "0";

                if (dgvAttend.Rows.Count == 0)
                {
                    MessageBox.Show("There is no attendance list for process.", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Salary_Exist_Cnt_For_Location_Session_Month() > 0)
                {
                    MessageBox.Show("You can not change this attendance since salary has been created for this month at this location", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    switch (PreviousColumn)
                    {
                        case 3:
                            if (lbl_Accpt_wd_hrs.Text == "1")
                            {
                                dgvAttend.Rows[PreviousRow].Cells["col_absent"].Value = Convert.ToDouble(txtDays.Text) - (Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_wday"].Value)/Convert.ToDouble(lbl_Accpt_wd_hrs.Text));
                            }
                            else
                            {
                                dgvAttend.Rows[PreviousRow].Cells["col_absent"].Value = Convert.ToDouble(txtDays.Text) - Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_wday"].Value);
                            }
                            break;
                        case 5:
                            //dgvAttend.Rows[PreviousRow].Cells["col_wday"].Value = Convert.ToDouble(txtDays.Text) - Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_absent"].Value);
                            break;
                    }
                    int cnt = 0, company_Id = 0, desgid = 0;
                    company_Id = clsEmployee.GetCompany_ID(Location_ID);

                    string empid;
                    double tdays = 0, tabsent = 0, tproxy = 0, ted = 0,clday=0, wdays = 0,wo=0, days_wd = 0, days_ot = 0, apply_hrs_wd = 0, days_ed = 0, apply_hrs_ed = 0, apply_hrs_ot = 0, lv_earn = 0, lv_adj = 0, lv_pbal = 0, lv_earn_old = 0, lv_adj_old = 0, lv_pbal_old = 0;
                    string lv_cfw ="1";
                    int sts = 0;
                    string sfid="0",sno="0",woff="0",mon=AttenDtTmPkr.Value.ToString("MMMM-yyyy");
                    string type = "",emp_proxy_attend="",emp_attendance="",emp_attend="";
                    if (chkAuthorise.Checked == true)
                    {
                        sts = 1;
                    }
                    else
                    {
                        sts = 0;
                    }
                    type = btnProcess.Text;
                    clsDataAccess.RunWorkflow_Log(edpcom.UserDesc, "Attendance", sts.ToString(), DateAndTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt"),type, Environment.MachineName, AttenDtTmPkr.Value.ToString("MMM"), AttenDtTmPkr.Value.Year.ToString(), Location_ID.ToString(), company_Id.ToString(),"");
                    clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Attend where (Month='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "') and  Season = '" + cmbYear.Text + "' and Location_ID ='" + Location_ID + "'");
                    edpcom.InsertMidasLog(this, true, "proc", "Mon:" + mon + " | Loc:" + Location_ID);
                    
                    for (cnt = 0; cnt < dgvAttend.Rows.Count; cnt++)
                    {
                        emp_attendance = "";
                        try
                        {
                            wdays = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_wday"].Value);
                            wo = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_WO"].Value);

                            tdays = Convert.ToDouble(txtDays.Text);
                            desg_id = dgvAttend.Rows[cnt].Cells["col_desgid"].Value.ToString();
                            

                            if (dgvAttend.Rows[cnt].Cells["col_cwd"].Value.ToString().Trim() == "0" || dgvAttend.Rows[cnt].Cells["col_cwd"].Value.ToString().Trim() == "" || dgvAttend.Rows[cnt].Cells["col_cwd"].Value.ToString().Trim() == null)
                            {
                                if (cWD_MOD == 1)
                                {

                                    wdays = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_wday"].Value);
                                    try
                                    {
                                        if (lbl_mod.Text.Trim().ToUpper() == "MOD-EWO")
                                        {
                                            tdays = tdays - wo;
                                            if (tdays < wdays)
                                            {
                                                dgvAttend.Rows[cnt].Cells["col_wday"].Value = tdays;
                                                wdays = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_wday"].Value);
                                            }
                                        }
                                    }
                                    catch { }
                                    try
                                    {
                                        cWdMod = Convert.ToDouble(clsDataAccess.ReturnValue("Select other from tbl_Site_mod_desg where (sid='" + cmblocation.ReturnValue + "') and (desgid='" + desg_id + "')"));
                                    }
                                    catch { cWdMod = 0; }
                                    //if (cWdMod > wdays)
                                    clday = Math.Round(((wdays / tdays) * cWdMod));

                                    if (cWdMod == 0)
                                        dgvAttend.Rows[cnt].Cells["col_cwd"].Value = wdays.ToString("0.00");
                                    else if (cWdMod > clday)
                                        dgvAttend.Rows[cnt].Cells["col_cwd"].Value = clday.ToString("0.00");
                                    else
                                        dgvAttend.Rows[cnt].Cells["col_cwd"].Value = cWdMod.ToString("0.00");

                                }
                            }

                        }
                        catch
                        {
                            dgvAttend.Rows[cnt].Cells["col_cwd"].Value = wdays.ToString("0.00");
                        }


                        cWD = 0;
                        lv_earn = 0; lv_adj = 0; lv_pbal = 0;
                        woff = "0";
                        empid = dgvAttend.Rows[cnt].Cells["col_ecode"].Value.ToString();
                        tdays = Convert.ToDouble(txtDays.Text);
                        wdays = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_wday"].Value);

                        wo = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_WO"].Value);
                        try
                        {
                            if (lbl_mod.Text.Trim().ToUpper() == "MOD-EWO")
                            {
                                tdays = tdays - wo;
                                if (tdays < wdays)
                                {
                                    dgvAttend.Rows[cnt].Cells["col_wday"].Value = tdays;
                                    wdays = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_wday"].Value);
                                }
                            }
                        }
                        catch { }
                        try
                        {
                            lv_cfw = Convert.ToString(dgvAttend.Rows[cnt].Cells["col_cfw"].Value);
                        }
                        catch { lv_cfw = "1"; }
                        try
                        { tproxy = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_proxy"].Value); }
                        catch
                        { tproxy = 0; }

                        try
                        { ted = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_ed"].Value); }
                        catch
                        { ted = 0; }

                        try
                        { tabsent = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_absent"].Value); }
                        catch
                        { tabsent = 0; }
                        try
                        { desgid = Convert.ToInt32(dgvAttend.Rows[cnt].Cells["col_desgid"].Value); }
                        catch
                        { desgid = 0; }

                        try
                        { sfid = dgvAttend.Rows[cnt].Cells["col_shift_id"].Value.ToString(); }
                        catch
                        { sfid = "0"; }

                        try
                        { sno = dgvAttend.Rows[cnt].Cells["col_shift_no"].Value.ToString(); }
                        catch
                        { sno = "0"; }

                        try
                        {
                            lv_earn = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_lv_earn"].Value);
                        }
                        catch
                        { lv_earn = 0; }
                        
                        try
                        { 
                        lv_adj=Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_lv_adj"].Value);
                        }
                        catch
                        { lv_adj = 0; }
                        
                        try
                        { 
                        lv_pbal = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_lv_pbal"].Value);
                        }
                        catch
                        { lv_pbal = 0; }


                        try
                        {
                            lv_earn_old = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_lv_earn_old"].Value);
                        }
                        catch
                        { lv_earn_old = 0; }

                        try
                        {
                            lv_adj_old = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_lv_adj_Old"].Value);
                        }
                        catch
                        { lv_adj_old = 0; }

                        try
                        {
                            lv_pbal_old = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_lv_cbal_old"].Value);
                        }
                        catch
                        { lv_pbal_old = 0; }

                        try
                        {
                            woff = dgvAttend.Rows[cnt].Cells["col_WO"].Value.ToString();
                        }
                        catch { woff = "0"; }

                        if (tproxy == 0 && tabsent == 0)
                        {
                            if (lbl_Accpt_wd_hrs.Text == "1")
                            {
                                if (tdays >= (wdays/Convert.ToDouble(lbl_wd_hrs.Text)))
                                {
                                    tabsent = tdays -(wdays/Convert.ToDouble(lbl_wd_hrs.Text));

                                    tproxy = 0;
                                }
                                else
                                {
                                    tabsent = 0;
                                    tproxy = wdays - (tdays * Convert.ToDouble(lbl_wd_hrs.Text));
                                }

                            }
                            else
                            {
                                if (tdays >= wdays)
                                {
                                    tabsent = tdays - wdays;

                                    tproxy = 0;
                                }
                                else
                                {
                                    tabsent = 0;

                                   // tproxy =tproxy+( wdays - tdays);
                                }
                            }
                        }
                        else
                        {

                            if (lbl_Accpt_wd_hrs.Text == "1")
                            {
                                if (tdays >= (wdays / Convert.ToDouble(lbl_wd_hrs.Text)))
                                {
                                    tabsent = tdays - (wdays / Convert.ToDouble(lbl_wd_hrs.Text));

                                    
                                }
                                else
                                {
                                    tabsent = 0;
                                    if (tproxy == 0)
                                        tproxy = wdays - (tdays * Convert.ToDouble(lbl_wd_hrs.Text));
                                    else
                                        tproxy = tproxy;//+ (wdays - (tdays * Convert.ToDouble(lbl_wd_hrs.Text)));
                                }

                            }
                            else
                            {
                                if (tdays >= wdays)
                                {
                                    tabsent = tdays - wdays;                                    
                                }
                                else
                                {
                                    tabsent = 0;
                                    if (tproxy == 0)
                                        tproxy = tproxy; //wdays - tdays;
                                    else
                                        tproxy = tproxy; //+ (wdays - tdays);
                                }
                            }
                            
                            //if (tabsent > 0)
                            //{
                            //    wdays = tdays - tabsent;
                            //    dgvAttend.Rows[cnt].Cells["col_wday"].Value = wdays;

                            //}
                            //else
                            //{
                            //    tabsent = tdays - wdays;

                            //}


                        }
                       
                        //if (cWD_MOD == 1)
                        //{
                        //    desg_id = dgvAttend.Rows[cnt].Cells["col_desgid"].Value.ToString();
                        //    try
                        //    {
                        //        cWdMod = Convert.ToDouble(clsDataAccess.ReturnValue("SELECT ISNULL((Select (case when other!=0 then isNull(other,0) else 0 end)other from tbl_Site_mod_desg where (sid='" + cmblocation.ReturnValue + "') and (desgid='" + desg_id + "')),0)"));
                        //        if (cWdMod != 0)
                        //        {
                        //            if (wdays < tdays)
                        //                dgvAttend.Rows[cnt].Cells["col_cwd"].Value = ((wdays / tdays) * cWdMod).ToString("0.00");
                        //            else
                        //                dgvAttend.Rows[cnt].Cells["col_cwd"].Value = cWdMod.ToString("0.00");
                        //        }
                        //        else
                        //        {
                        //            dgvAttend.Rows[cnt].Cells["col_cwd"].Value = wdays;

                        //        }
                        //    }
                        //    catch {
                        //        dgvAttend.Rows[cnt].Cells["col_cwd"].Value = wdays;
                        //    }

                        //    cWD = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_cwd"].Value);
                        //}
                        cWD = Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_cwd"].Value);
                        dgvAttend.Rows[cnt].Cells["col_proxy"].Value = tproxy;

                        dgvAttend.Rows[cnt].Cells["col_absent"].Value = tabsent;
                        try
                        {
                            apply_hrs_wd = Convert.ToDouble(lbl_Accpt_wd_hrs.Text);
                        }
                        catch { apply_hrs_wd = 0; }
                        try
                        {
                            apply_hrs_ot = Convert.ToDouble(lbl_Accpt_ot_hrs.Text);
                        }
                        catch { apply_hrs_wd = 0; }

                        try
                        {
                            apply_hrs_ed = Convert.ToDouble(lbl_Accpt_ed_hrs.Text);
                        }
                        catch { apply_hrs_ed = 0; }

                        if (apply_hrs_wd==1)
                            days_wd=wdays/Convert.ToDouble(lbl_wd_hrs.Text);
                        else
                            days_wd=wdays;

                        if (apply_hrs_ot == 1)
                            days_ot = tproxy / Convert.ToDouble(lbl_ot_hrs.Text);
                        else
                            days_ot = tproxy;

                        if (apply_hrs_ed == 1)
                            days_ed = ted / Convert.ToDouble(lbl_ed_hrs.Text);
                        else
                            days_ed = ted;
                        //=============Proxy===============================================================

                        if (dgvAttend.Rows[cnt].Cells[0] != null)
                            if (Convert.ToString(dgvAttend.Rows[cnt].Cells[0]) != "")
                                if (Information.IsNumeric(dgvAttend.Rows[cnt].Cells["col_proxy"].Value) == true)
                                {
                                    if (Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_proxy"].Value) > Convert.ToDouble(wd_limit) && Convert.ToDouble(lbl_Accpt_ot_hrs.Text) == 0)
                                    {
                                        ERPMessageBox.ERPMessage.Show(dgvAttend.Rows[cnt].Cells["col_ecode"].Value + " : Proxy Max 60 Days", "BRAVO");
                                        dgvAttend.Rows[cnt].Cells["col_proxy"].Value = 0;
                                        return;
                                    }
                                    else if (Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_proxy"].Value) > (Convert.ToDouble(lbl_ot_hrs.Text) * Convert.ToDouble(wd_limit)) && Convert.ToDouble(lbl_Accpt_ot_hrs.Text) == 1)
                                    {
                                        ERPMessageBox.ERPMessage.Show(dgvAttend.Rows[cnt].Cells["col_ecode"].Value + " : Proxy Max 60 Days / " + (Convert.ToDouble(lbl_ot_hrs.Text) * Convert.ToDouble(wd_limit)) + " Hrs", "BRAVO");
                                        dgvAttend.Rows[cnt].Cells["col_proxy"].Value = 0;
                                        return;
                                    }
                                    else if (Convert.ToDouble(dgvAttend.Rows[cnt].Cells["col_proxy"].Value) < 0)
                                    {
                                        ERPMessageBox.ERPMessage.Show(dgvAttend.Rows[cnt].Cells["col_ecode"].Value + " : Proxy Cannot be Negative", "BRAVO");
                                        dgvAttend.Rows[cnt].Cells["col_proxy"].Value = 0;
                                        return;
                                    }
                                    else
                                    {
                                        //  company_Id = clsEmployee.GetCompany_ID(Location_ID);
                                        Boolean flug_save = false;
                                        DataTable dt = clsDataAccess.RunQDTbl("select Employee_ID from tbl_Employee_Proxy_Attendance where Employee_ID ='" + dgvAttend.Rows[cnt].Cells["col_ecode"].Value + "' and Month ='" + strAttenDtTmPkrMonth + "' and  Session = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + "    ");
                                        if (dt.Rows.Count > 0)
                                            clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Proxy_Attendance where Employee_ID ='" + dgvAttend.Rows[cnt].Cells["col_ecode"].Value + "' and Month ='" + strAttenDtTmPkrMonth + "' and  Session = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + " ");

                                      //  flug_save = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Proxy_Attendance(Employee_ID,Proxy_Day,Month,Session,Location_ID,Company_id) values('" + dgvAttend.Rows[cnt].Cells["col_ecode"].Value + "','" + days_ot + "','" + strAttenDtTmPkrMonth + "','" + cmbYear.Text + "'," + Location_ID + ",'" + company_Id + "')");

                                        if (emp_proxy_attend.Trim() == "")
                                        {
                                            emp_proxy_attend = "('" + dgvAttend.Rows[cnt].Cells["col_ecode"].Value + "','" + days_ot + "','" + strAttenDtTmPkrMonth + "','" + cmbYear.Text + "'," + Location_ID + ",'" + company_Id + "')";
                                        }
                                        else
                                        {
                                            emp_proxy_attend =  emp_proxy_attend +Environment.NewLine+ ",('" + dgvAttend.Rows[cnt].Cells["col_ecode"].Value + "','" + days_ot + "','" + strAttenDtTmPkrMonth + "','" + cmbYear.Text + "'," + Location_ID + ",'" + company_Id + "')";

                                        }
                                    }

                                }
                        //================absent==================================================================
                        if (tabsent > 0)
                        {
                            clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Attendance where ID='" + dgvAttend.Rows[cnt].Cells["col_ecode"].Value + "' and month(LeaveDate)='" + AttenDtTmPkr.Value.Month + "' AND year(LeaveDate)=" + AttenDtTmPkr.Value.Year + " and  Season = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + " ");
                            int mxday = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                            for (int var_ts = 1; var_ts <= tabsent; var_ts++)
                            {

                               
                       //         clsDataAccess.RunNQwithStatus("INSERT INTO tbl_Employee_Attendance(ID,Remarks,LeaveDate,FstLeave," +
                       //"SndLeave,LeaveType,DayStatus,Location_ID,FstProxy,SndProxy,Company_id,season) values('" + dgvAttend.Rows[cnt].Cells["col_ecode"].Value.ToString() + "','-','" + LvDate + "'," + live_fast + "," +
                       //live_second + "," + PayVal + "," + DayStatus + "," + Location_ID + "," + FstProxy + "," + SendProxy + ",'" + company_Id + "','" + cmbYear.Text + "')");
                                if (mxday != 0)
                                {
                                    LvDate = DatePatern(mxday + "/" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year);
                                    mxday = mxday - 1;

                                    live_fast = leave_id;
                                    live_second = leave_id;


                                    if (emp_attendance.Trim() == "")
                                    {
                                        emp_attendance = "('" + dgvAttend.Rows[cnt].Cells["col_ecode"].Value.ToString() + "','-','" + LvDate + "'," + live_fast + "," +
                           live_second + "," + PayVal + "," + DayStatus + "," + Location_ID + "," + FstProxy + "," + SendProxy + ",'" + company_Id + "','" + cmbYear.Text + "')";
                                    }
                                    else
                                    {

                                        emp_attendance = emp_attendance + Environment.NewLine + ",('" + dgvAttend.Rows[cnt].Cells["col_ecode"].Value.ToString() + "','-','" + LvDate + "'," + live_fast + "," +
                           live_second + "," + PayVal + "," + DayStatus + "," + Location_ID + "," + FstProxy + "," + SendProxy + ",'" + company_Id + "','" + cmbYear.Text + "')";

                                    }
                                }
                                else
                                {

                                }

                            }


                            if (emp_attendance.Trim() != "")
                            {

                                clsDataAccess.RunQry("INSERT INTO tbl_Employee_Attendance(ID,Remarks,LeaveDate,FstLeave," +
                             "SndLeave,LeaveType,DayStatus,Location_ID,FstProxy,SndProxy,Company_id,season) values" + emp_attendance);
                            }
                        }

                        string[] edt = txtCurrentDate.Text.Split('/');
                        string adt = "";
                        if (txtCurrentDate.Text == System.DateTime.Now.ToString("dd/MM/yyyy"))
                        {
                            adt = System.DateTime.Now.ToString("dd/MMMM/yyyy");
                        }
                        else
                        {
                            adt = edt[0].ToString() + "/" + clsEmployee.GetMonthName(Convert.ToInt32(edt[1])) + "/" + edt[2].ToString();
                        }
                        //clsDataAccess.RunNQwithStatus("INSERT INTO [tbl_Employee_Attend]([ID],[MOD],[Wday],[Absent],[Proxy],[ed],[Season],[Month],[LOcation_ID],[Company_id],[Desgid],[status],[edate],[sfid],[sno], days_wd, days_ot, apply_hrs_wd,apply_hrs_ot,lv_earn,lv_adj,lv_pbal,woff,cWD,days_ed,cfw) VALUES ('" +
                        //empid + "','" + tdays + "','" + wdays + "','" + tabsent + "','" + tproxy + "','"+ ted + "','" + cmbYear.Text + "','" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "','" + Location_ID + "','" + company_Id + "','" + desgid + "','" + sts + "','" +
                        //adt + "','" + sfid + "','" + sno + "','" + days_wd + "','" + days_ot + "','" + apply_hrs_wd + "','" + apply_hrs_ot + "','" + lv_earn + "','" + lv_adj + "','" + lv_pbal + "','" + woff + "','" + cWD + "','" + days_ed + "','" + lv_cfw + "')");

                        if (emp_attend.Trim() == "")
                        {
                            emp_attend="('" +
                        empid + "','" + tdays + "','" + wdays + "','" + tabsent + "','" + tproxy + "','"+ ted + "','" + cmbYear.Text + "','" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "','" + Location_ID + "','" + company_Id + "','" + desgid + "','" + sts + "','" +
                        adt + "','" + sfid + "','" + sno + "','" + days_wd + "','" + days_ot + "','" + apply_hrs_wd + "','" + apply_hrs_ot + "','" + lv_earn + "','" + lv_adj + "','" + lv_pbal + "','" + woff + "','" + cWD + "','" + days_ed + "','" + lv_cfw + "','" + mon + "')";
                        }
                        else
                        {
                            emp_attend = emp_attend + Environment.NewLine + ",('" +
                        empid + "','" + tdays + "','" + wdays + "','" + tabsent + "','" + tproxy + "','" + ted + "','" + cmbYear.Text + "','" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "','" + Location_ID + "','" + company_Id + "','" + desgid + "','" + sts + "','" +
                        adt + "','" + sfid + "','" + sno + "','" + days_wd + "','" + days_ot + "','" + apply_hrs_wd + "','" + apply_hrs_ot + "','" + lv_earn + "','" + lv_adj + "','" + lv_pbal + "','" + woff + "','" + cWD + "','" + days_ed + "','" + lv_cfw + "','"+mon+"')";

                        }

                        InsertUpdateAttendaceLogDet();

                        //Added by dwipraj dutta 30102017
                        if (cbSaveAsPrimaryDesignation.Checked)
                        {
                            for (int i = 0; i < alEmpID.Count; i++)
                            {
                                clsDataAccess.RunNQwithStatus("update tbl_Employee_Mast set DesgId = " + alEmpDesgID[i] + " where ID = '" + alEmpID[i] + "'");
                            }
                        }

                        try
                        {
                            clsDataAccess.RunNQwithStatus("update tbl_Emp_Leave_Balance Set cur_lv_bal='" + ((((lv_pbal_old + lv_adj_old) - lv_earn_old) - lv_adj) + lv_earn) + "',[session]='" + cmbYear.Text + "',[month]='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "'  where (eid='" + empid + "')");
                        }
                        catch { }


                        alEmpID.Clear();
                        alEmpDesgID.Clear();
                    }


                      if (emp_proxy_attend.Trim()!="")
                      {

                          clsDataAccess.RunQry("insert into tbl_Employee_Proxy_Attendance(Employee_ID,Proxy_Day,Month,Session,Location_ID,Company_id) values "+ emp_proxy_attend);
                      }
                  

                      if (emp_attend.Trim()!= "")
                      {

                          clsDataAccess.RunQry("INSERT INTO [tbl_Employee_Attend]([ID],[MOD],[Wday],[Absent],[Proxy],[ed],[Season],"+
                              "[Month],[LOcation_ID],[Company_id],[Desgid],[status],[edate],[sfid],[sno], days_wd, days_ot, apply_hrs_wd,"+
                              "apply_hrs_ot,lv_earn,lv_adj,lv_pbal,woff,cWD,days_ed,cfw,[Mon]) VALUES "+ emp_attend);
                      }

                    if (chkAllLocation.Checked == false)
                    {
                        MessageBox.Show("Attendance Accepted.." + Environment.NewLine +
                        " Location : " + cmblocation.Text.Trim() + ". for the month of " + AttenDtTmPkr.Value.ToString("MMMM - yyyy"), "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        chkAllLocation.Checked = false;
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Attendance Accepted.." + Environment.NewLine +
                            " Location : " + cmblocation.Text.Trim() + ". for the month of " + AttenDtTmPkr.Value.ToString("MMMM - yyyy")
                            + Environment.NewLine + " Want to continue with current selected zone ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
                        if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
                        {

                        }
                        else
                        {
                            chkAllLocation.Checked = false;
                            chkAllLocation.Checked = true;
                        }
                    }
                    AttenDtTmPkr.Value = DateTime.Now.AddMonths(-1); 
                    chkAuthorise.Checked = false;
                    txtCurrentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lbl_Accpt_wd_hrs.Text = "";
                    lbl_Accpt_ot_hrs.Text ="";
                    btnAllotement.Visible = false;
                    lbl_wd_hrs.Text = "";
                    lbl_ot_hrs.Text ="";
                    dgv_cnt.Visible = false;
                }
            }
        }

        private void dgvAttend_KeyUp(object sender, KeyEventArgs e)
        {
        
         if (e.KeyCode == Keys.Delete)
         {
             if (Salary_Exist_Cnt_For_Location_Session_Month() > 0)
             {
                 Extractcmd_Click(sender, e);
             }
             else
             {
                 if (MessageBox.Show("Do you want to delete current details?", "Bravo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                 {
                     int ind = Convert.ToInt32(dgvAttend.CurrentRow.Index);
                     dgvAttend.Rows.RemoveAt(ind);
                 }
             }
            }

            if (e.KeyCode == Keys.F2)
            {
                txtSearch.Focus();
            }
            if (e.KeyCode == Keys.F5) // manual entry
            {

                dgvAttend.Rows.Add();
            }
            if (e.KeyCode == Keys.F8) // config days
            {

                dgvAttend.Columns["col_cwd"].Visible = true;
                if (btnProcess.Text.ToLower() == "process")
                {
                    for (int cnt = 0; cnt < dgvAttend.Rows.Count; cnt++)
                    { calc_wd(cnt); }
                }
                //chk_desg();
            }
            if (e.KeyCode == Keys.F9)  // check 
            {
                if (lbl_lv_type.Text == "1")
                {
                    dgvAttend.Columns["col_cfw"].Visible = true;
                }

            }
        }

        private void dgvAttend_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dgvAttend.CurrentCell.ColumnIndex == dgvAttend.Columns["col_desg"].Index) || (dgvAttend.CurrentCell.ColumnIndex == dgvAttend.Columns["col_desgid"].Index))
            {
                DialogView dv = new DialogView();
                dv.sql_frm = "SELECT SlNo,DesignationName, ShortForm,(select type from tbl_desg_type where slno=edm.type)dtype FROM tbl_Employee_DesignationMaster edm";
                dv.retno = 2;
                dv.lblCo.Text = "";
                dv.lblHead.Text = "";
                dv.btnPreview.Visible = false;
                dv.ShowDialog();
                try
                {
                    int ind = Convert.ToInt32(dgvAttend.CurrentRow.Index);

                    this.dgvAttend.Rows[ind].Cells["col_desg"].Value = dv.retval1.ToString();
                    this.dgvAttend.Rows[ind].Cells["col_desgid"].Value = dv.retval.ToString();
                    //Added by dwipraj dutta 10102017
                    //check if employee id already exists on the arraylist or not. If exists then get the context of the employee id and update the desgid of the index of designation id arraylist
                    if (alEmpID.Count > 0)
                    {
                        if (alEmpID.Contains(this.dgvAttend.Rows[ind].Cells["col_ecode"].Value))
                        {
                            int indexOfEmpID = alEmpID.IndexOf(this.dgvAttend.Rows[ind].Cells["col_ecode"].Value);
                            alEmpDesgID[indexOfEmpID] = this.dgvAttend.Rows[ind].Cells["col_desgid"].Value;
                        }
                        else
                        {
                            alEmpID.Add(this.dgvAttend.Rows[ind].Cells["col_ecode"].Value);
                            alEmpDesgID.Add(this.dgvAttend.Rows[ind].Cells["col_desgid"].Value);

                        }
                    }
                    else
                    {
                        alEmpID.Add(this.dgvAttend.Rows[ind].Cells["col_ecode"].Value);
                        alEmpDesgID.Add(this.dgvAttend.Rows[ind].Cells["col_desgid"].Value);
                    }
                }
                catch { }

            }
            if (dgvAttend.CurrentCell.ColumnIndex == dgvAttend.Columns["col_shift"].Index)
            {
                int ind = Convert.ToInt32(dgvAttend.CurrentRow.Index);
                int cnt_shift = Convert.ToInt32(clsDataAccess.GetresultS("Select count(*) FROM tbl_link_shift as ls where (locid='" + Location_ID + "')"));
                if (cnt_shift > 0)
                {
                    DialogView dv = new DialogView();

                    dv.sql_frm = "select sid,(select sname from tbl_shift where sid=ls.sid)sname,sno FROM tbl_link_shift as ls where (locid='" + Location_ID + "') order by sid";
                    dv.retno = 3;
                    dv.StartPosition = FormStartPosition.CenterScreen;
                    dv.lblCo.Text = "";
                    dv.lblHead.Text = "";
                    dv.btnPreview.Visible = false;
                    dv.ShowDialog();
                    //ind = Convert.ToInt32(dgvAttend.CurrentRow.Index);
                    try
                    {
                        this.dgvAttend.Rows[ind].Cells["col_shift"].Value = dv.retval1.ToString();
                    }
                    catch { this.dgvAttend.Rows[ind].Cells["col_shift"].Value = ""; }
                    try
                    {
                        this.dgvAttend.Rows[ind].Cells["col_shift_id"].Value = dv.retval.ToString();
                    }
                    catch { this.dgvAttend.Rows[ind].Cells["col_shift_id"].Value = 0; }

                    try
                    {
                        this.dgvAttend.Rows[ind].Cells["col_shift_no"].Value = dv.retval2.ToString();
                    }
                    catch { this.dgvAttend.Rows[ind].Cells["col_shift_no"].Value = 1; }
                }
                else
                {
                    MessageBox.Show("No Shift tagged.. Go to Company Location link master");
                }
            }
            if ((dgvAttend.CurrentCell.ColumnIndex == dgvAttend.Columns["col_others"].Index))
            {

                int ind = Convert.ToInt32(dgvAttend.CurrentRow.Index);
                string vecode = this.dgvAttend.Rows[ind].Cells["col_ecode"].Value.ToString();
                DialogView dv = new DialogView();
                dv.sql_frm = "select IsNull(Wday,0) AS Wday, IsNull(Proxy,0) AS Proxy," +
               "(SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = ea.Location_id)) AS Location," +
               "(SELECT DesignationName FROM tbl_Employee_DesignationMaster where SlNo=ea.Desgid)as Designation from [tbl_Employee_Attend]as ea where (ID='" + vecode + "') and (Month ='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "') and  (Season = '" + cmbYear.Text + "') and (Location_ID <>'" + Location_ID + "')";
                dv.retno = 1;
                dv.StartPosition = FormStartPosition.CenterScreen;

                dv.lblCo.Text = "";
                dv.lblHead.Text = "";
                dv.btnPreview.Visible = false;

                dv.ShowDialog();


            }
        }

        private void dgvAttend_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            PreviousRow = e.RowIndex;
            PreviousColumn = e.ColumnIndex;
           
        }

        private void dgvAttend_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*
            double tdays = 0, wdays = 0, adays = 0;
            switch (e.ColumnIndex)
            {
                case 3:
                    tdays = Convert.ToDouble(txtDays.Text);
                    wdays = Convert.ToDouble(dgvAttend.Rows[e.RowIndex].Cells["col_wday"].Value);
                    adays = tdays - wdays;
                    dgvAttend.Rows[e.RowIndex].Cells["col_absent"].Value = adays;
                    break;
                case 5:
                    tdays = Convert.ToDouble(txtDays.Text);
                    adays = Convert.ToDouble(dgvAttend.Rows[e.RowIndex].Cells["col_absent"].Value);
                    wdays = tdays - wdays;
                    dgvAttend.Rows[e.RowIndex].Cells["col_wday"].Value = wdays;
                    break;
            }*/
        }
        public void calc_wd(int rw)
        {
            double tdays = 0, wdays = 0, cWdMod = 0, clday = 0,limit=0,wo=0;
            string desg_id = "0",mod="",cfw_mod="0",cfw_loc="";
            cfw_loc = clsDataAccess.ReturnValue("select mode_cwd from Companywiseid_Relation where (Location_ID='" + cmblocation.ReturnValue + "')");
            if (cWD_MOD == 1)
            {
                tdays = Convert.ToDouble(txtDays.Text);
                desg_id = dgvAttend.Rows[rw].Cells["col_desgid"].Value.ToString();
                cfw_mod = clsDataAccess.ReturnValue("select mode_cwd from tbl_Employee_Mast where (ID='" + dgvAttend.Rows[rw].Cells["col_ecode"].Value + "')");
                mod = clsDataAccess.ReturnValue("Select mod from tbl_Site_mod_desg where (sid='" + cmblocation.ReturnValue + "') and (desgid='" + desg_id + "')");
                wdays = Convert.ToDouble(dgvAttend.Rows[rw].Cells["col_wday"].Value);
                wo = Convert.ToDouble(dgvAttend.Rows[rw].Cells["col_WO"].Value);
                try
                {
                    if (lbl_mod.Text.Trim().ToUpper() == "MOD-EWO")
                    {
                        tdays = (tdays - wo);
                        if ((tdays) < wdays)
                        {
                            dgvAttend.Rows[rw].Cells["col_wday"].Value = tdays;
                            wdays = Convert.ToDouble(dgvAttend.Rows[rw].Cells["col_wday"].Value);
                        }
                    }
                }
                catch { }
                
                try
                {
                    cWdMod = Convert.ToDouble(clsDataAccess.ReturnValue("Select other from tbl_Site_mod_desg where (sid='" + cmblocation.ReturnValue + "') and (desgid='" + desg_id + "')"));
                }
                catch { cWdMod = 0; }


                try
                {
                    limit = Convert.ToDouble(clsDataAccess.ReturnValue("Select limit from tbl_Site_mod_desg where (sid='" + cmblocation.ReturnValue + "') and (desgid='" + desg_id + "')"));
                }
                catch { limit = 0; }
                //if (cWdMod > wdays)
                if (mod.Trim().ToLower() == "limit")
                {
                    if (wdays <= cWdMod)
                    {
                        clday = wdays;
                    }
                    else
                    {
                        clday = cWdMod;
                    }
                }
                else
                {
                    if (cfw_loc == "0")
                    {
                        if (cfw_mod == "1")
                        {
                            clday = Math.Floor(((wdays / tdays) * cWdMod));
                            if (limit > 0)
                            {
                                if (limit <= clday)
                                {
                                    clday = limit;
                                }

                            }

                        }
                        else if (cfw_mod == "2")
                        {
                            clday = Math.Floor(((wdays / tdays) * cWdMod));
                            if (((((wdays / tdays) * cWdMod)) - clday) >= 0.50)
                            {
                                double d = Math.Truncate(((wdays / tdays) * cWdMod));
                                clday = clday + 0.50;
                            }

                            if (limit > 0)
                            {
                                if (limit <= clday)
                                {
                                    clday = limit;
                                }

                            }
                        }
                        else
                        {

                            clday = Math.Round(((wdays / tdays) * cWdMod), 2);
                            if (limit > 0)
                            {
                                if (limit <= clday)
                                {
                                    clday = limit;
                                }

                            }
                        }
                    }
                    else if (cfw_loc == "1")
                    {
                        clday = Math.Floor(((wdays / tdays) * cWdMod));
                    }
                    else if (cfw_loc == "2")
                    {
                        clday = Math.Ceiling(((wdays / tdays) * cWdMod));
                    }
                    else if (cfw_loc == "3")
                    {
                        clday = Math.Round(((wdays / tdays) * cWdMod));
                    }
                }


                //if (dgvAttend.Rows[rw].Cells["col_cwd"].Value == "0" || dgvAttend.Rows[rw].Cells["col_cwd"].Value.ToString().Trim() == "")
                //{
                if (cWD_MOD == 1)
                {
                    dgvAttend.Rows[rw].Cells["col_cwd"].Value = clday.ToString("0.00");
                }
                else
                {
                    if (cWdMod == 0)
                        dgvAttend.Rows[rw].Cells["col_cwd"].Value = wdays.ToString("0.00");
                    else if (cWdMod > clday)
                        dgvAttend.Rows[rw].Cells["col_cwd"].Value = clday.ToString("0.00");
                    else
                        dgvAttend.Rows[rw].Cells["col_cwd"].Value = cWdMod.ToString("0.00");
                }
               // }
            }

        }
        private void dgvAttend_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            double tdays = 0, wdays = 0, adays = 0,cWdMod=0;
            string desg_id="0";
            switch (PreviousColumn)
            {
                case 3:
                    tdays = Convert.ToDouble(txtDays.Text);
                    wdays = Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_wday"].Value);
                    if (lbl_Accpt_wd_hrs.Text == "1") { wdays = wdays / Convert.ToDouble(lbl_wd_hrs.Text); } 
                    adays = tdays - wdays;
                    dgvAttend.Rows[PreviousRow].Cells["col_absent"].Value = adays;
                    dgvAttend.Rows[PreviousRow].Cells["col_WO"].Value = Convert.ToInt32(wdays / 7);
                    //if (cWD_MOD == 1)
                    //{
                    //    desg_id = dgvAttend.Rows[PreviousRow].Cells["col_desgid"].Value.ToString();
                    //    cWdMod = Convert.ToDouble(clsDataAccess.ReturnValue("Select other from tbl_Site_mod_desg where (sid='" + cmblocation.ReturnValue + "') and (desgid='"+ desg_id +"')"));
                    //    if (wdays<tdays)
                    //        dgvAttend.Rows[PreviousRow].Cells["col_cwd"].Value = ((wdays/tdays)*cWdMod).ToString("0.00");
                    //    else 
                    //        dgvAttend.Rows[PreviousRow].Cells["col_cwd"].Value = wdays.ToString("0.00");

                    //}

                    break;
                case 5:
                    tdays = Convert.ToDouble(txtDays.Text);
                    wdays = Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_wday"].Value);
                    if (lbl_Accpt_wd_hrs.Text == "1") { wdays = wdays / Convert.ToDouble(lbl_wd_hrs.Text); }
                    adays = tdays - wdays;
                    dgvAttend.Rows[PreviousRow].Cells["col_WO"].Value = Convert.ToInt32(wdays / 7);
                    try
                    {
                        dgvAttend.Rows[PreviousRow].Cells["col_absent"].Value = adays;
                        if (lbl_lv_type.Text == "1")
                        {
                            dgvAttend.Rows[PreviousRow].Cells["col_lv_earn"].Value = ((Convert.ToDouble(lbl_lvRt.Text) * wdays) / tdays).ToString("0.00");
                        }
                        dgvAttend.Rows[PreviousRow].Cells["col_lv_cbal"].Value = (Convert.ToDouble(Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_pbal"].Value) - Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_adj"].Value)) + Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_earn"].Value)).ToString("0.00");
                    }
                    catch 
                    { }

                    //if (cWD_MOD == 1)
                    //{
                    //    desg_id = dgvAttend.Rows[PreviousRow].Cells["col_desgid"].Value.ToString();
                    //    try{
                    //    cWdMod = Convert.ToDouble(clsDataAccess.ReturnValue("Select other from tbl_Site_mod_desg where (sid='" + cmblocation.ReturnValue + "') and (desgid='" + desg_id + "')"));
                    //     }
                    //    catch { cWdMod = 0; }
                    //    if (cWdMod<wdays)
                    //        dgvAttend.Rows[PreviousRow].Cells["col_cwd"].Value = ((wdays / tdays) * cWdMod).ToString("0.00");
                    //    else
                    //        dgvAttend.Rows[PreviousRow].Cells["col_cwd"].Value = wdays.ToString("0.00");

                    //}

                    break;
                case 11:
                    if (Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_adj"].Value) > 0 && lbl_lv_type.Text == "2")
                    {
                        if (Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_pbal"].Value) >= Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_adj"].Value) && Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_absent"].Value) >= Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_adj"].Value))
                        {
                            btnProcess.Enabled = true;
                            dgvAttend.Rows[PreviousRow].Cells["col_lv_cbal"].Value = Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_pbal"].Value) - Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_adj"].Value);
                        }
                        else
                        {
                            dgvAttend.Rows[PreviousRow].Cells["col_lv_cbal"].Value = Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_pbal"].Value);
                            MessageBox.Show("Leave adjustment is greter, Please Correct");
                            btnProcess.Enabled = false;
                        }

                    }

                    break;

                case 4:
                    tdays = Convert.ToDouble(txtDays.Text);
                    wdays = Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_wday"].Value);
                    if (lbl_Accpt_wd_hrs.Text == "1") { wdays = wdays / Convert.ToDouble(lbl_wd_hrs.Text); }
                    adays = tdays - wdays;

                    dgvAttend.Rows[PreviousRow].Cells["col_WO"].Value = Convert.ToInt32(wdays/7);

                    try
                    {
                        if (Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_pbal"].Value) > 0 && lbl_lv_type.Text == "2")
                        {
                            if (Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_pbal"].Value) >= adays)
                            {
                                if (Convert.ToInt32(Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_adj"].Value.ToString())) == 0)
                                {
                                    dgvAttend.Rows[PreviousRow].Cells["col_lv_adj"].Value = adays;
                                    dgvAttend.Rows[PreviousRow].Cells["col_absent"].Value = adays;
                                }
                            }
                            else
                            {
                                dgvAttend.Rows[PreviousRow].Cells["col_lv_adj"].Value = dgvAttend.Rows[PreviousRow].Cells["col_lv_pbal"].Value;
                                dgvAttend.Rows[PreviousRow].Cells["col_absent"].Value = adays -Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_pbal"].Value);
                            }
                            
                        }
                        else
                        {
                            dgvAttend.Rows[PreviousRow].Cells["col_absent"].Value = adays;

                        }
                        if (lbl_lv_type.Text == "1")
                        {
                            dgvAttend.Rows[PreviousRow].Cells["col_lv_earn"].Value = ((Convert.ToDouble(lbl_lvRt.Text) * wdays) / tdays).ToString("0.00");
                        }
                        //dgvAttend.Rows[PreviousRow].Cells["col_lv_earn"].Value = ((Convert.ToDouble(lbl_lvRt.Text) * wdays) / tdays).ToString("0.00");
                        dgvAttend.Rows[PreviousRow].Cells["col_lv_cbal"].Value = (Convert.ToDouble(Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_pbal"].Value) - Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_adj"].Value)) + Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_earn"].Value)).ToString("0.00");
                    }
                    catch (Exception ex)
                    { string err = ex.ToString(); }

                    //if (cWD_MOD == 1)
                    //{
                    //    desg_id = dgvAttend.Rows[PreviousRow].Cells["col_desgid"].Value.ToString();
                    //    try
                    //    {
                    //        cWdMod = Convert.ToDouble(clsDataAccess.ReturnValue("Select other from tbl_Site_mod_desg where (sid='" + cmblocation.ReturnValue + "') and (desgid='" + desg_id + "')"));
                    //    }
                    //    catch { cWdMod = 0; }
                    //    if (wdays < tdays)
                    //        dgvAttend.Rows[PreviousRow].Cells["col_cwd"].Value = ((wdays / tdays) * cWdMod).ToString("0.00");
                    //    else
                    //        dgvAttend.Rows[PreviousRow].Cells["col_cwd"].Value = wdays.ToString("0.00");

                    //}

                    break;
                case 9:
                    tdays = Convert.ToDouble(txtDays.Text);
                    wdays = Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_wday"].Value);
                    if (lbl_Accpt_wd_hrs.Text == "1") { wdays = wdays / Convert.ToDouble(lbl_wd_hrs.Text); }
                    adays = tdays - wdays;
                    try
                    {
                        dgvAttend.Rows[PreviousRow].Cells["col_absent"].Value = adays;
                        if (lbl_lv_type.Text == "1")
                        {
                            dgvAttend.Rows[PreviousRow].Cells["col_lv_earn"].Value = ((Convert.ToDouble(lbl_lvRt.Text) * wdays) / tdays).ToString("0.00");
                        }
                       // dgvAttend.Rows[PreviousRow].Cells["col_lv_earn"].Value = ((Convert.ToDouble(lbl_lvRt.Text) * wdays) / tdays).ToString("0.00");
                        dgvAttend.Rows[PreviousRow].Cells["col_lv_cbal"].Value = (Convert.ToDouble(Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_pbal"].Value) - Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_adj"].Value)) + Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_lv_earn"].Value)).ToString("0.00");
                    }
                    catch
                    { }

                    //if (cWD_MOD == 1)
                    //{
                    //    desg_id = dgvAttend.Rows[PreviousRow].Cells["col_desgid"].Value.ToString();
                    //    cWdMod = Convert.ToDouble(clsDataAccess.ReturnValue("Select other from tbl_Site_mod_desg where (sid='" + cmblocation.ReturnValue + "') and (desgid='" + desg_id + "')"));
                    //    if (wdays < tdays)
                    //        dgvAttend.Rows[PreviousRow].Cells["col_cwd"].Value = ((wdays / tdays) * cWdMod).ToString("0.00");
                    //    else
                    //        dgvAttend.Rows[PreviousRow].Cells["col_cwd"].Value = wdays.ToString("0.00");

                    //}
                    break;

                    //tdays = Convert.ToDouble(txtDays.Text);
                    //adays = Convert.ToDouble(dgvAttend.Rows[PreviousRow].Cells["col_absent"].Value);
                    //wdays = tdays - adays;
                    //dgvAttend.Rows[PreviousRow].Cells["col_wday"].Value = wdays;
                    //break;
            }
            calc_desg(); 
        }

        public int NoOfWorkingDays(DateTime dtpBillMon)
        {
            int count = 0;
            int Days = DateTime.DaysInMonth(dtpBillMon.Year, dtpBillMon.Month);
            for (int i = 0; i < Days; i++)
            {
                DateTime dt = new DateTime(dtpBillMon.Year, dtpBillMon.Month, i + 1);
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    count++;
                }
            }
            return (Days - count);
        }


        public int NoOfSundays(DateTime dtpBillMon)
        {
            int count = 0;
            int Days = DateTime.DaysInMonth(dtpBillMon.Year, dtpBillMon.Month);
            for (int i = 0; i < Days; i++)
            {
                DateTime dt = new DateTime(dtpBillMon.Year, dtpBillMon.Month, i + 1);
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    count++;
                }
            }
            return (count);
        }

        public int NoOfWorkingDays(DateTime dtpBillMon, int From, int To, Boolean WOSunday)
        {
            int count = 0;
            int DaysInFromMonth = DateTime.DaysInMonth(dtpBillMon.Year, dtpBillMon.Month - 1);
            int DaysInToMonth = DateTime.DaysInMonth(dtpBillMon.Year, dtpBillMon.Month);
            int Days = DaysInFromMonth - From + To + 1;     //1 has been added as the from date will also counted
            if (WOSunday)
            {
                for (int i = From; i <= DaysInFromMonth; i++)
                {
                    DateTime dt = new DateTime(dtpBillMon.Year, dtpBillMon.Month - 1, i);
                    if (dt.DayOfWeek == DayOfWeek.Sunday)
                    {
                        count++;
                    }
                }
                for (int i = 1; i <= To; i++)
                {
                    DateTime dt = new DateTime(dtpBillMon.Year, dtpBillMon.Month, i);
                    if (dt.DayOfWeek == DayOfWeek.Sunday)
                    {
                        count++;
                    }
                }
                return (Days - count);
            }
            return (Days);
        }

        private void chkFetch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFetch.Checked == true)
            {
                Extractcmd.Text = "Fetch from Prev Month";
            }
            else
            {
                Extractcmd.Text = "Fetch from Emp Joining";

            }
        }

        private void btnEmpJoining_Click(object sender, EventArgs e)
        {
            string lcid = "";
            DataTable dt_list = new DataTable();
            if (cmblocation.Text.Trim() != "")
            {
                lcid = cmblocation.ReturnValue;

            }
            else
            {
                lcid = "";
            }
            EmpJoiningShort ejs = new EmpJoiningShort(lcid);
            ejs.ShowDialog();
            if (lcid.Trim() != "")
            {
                dt_list = ejs.elist.Copy();

                
                 string   vecode = "";
                 string vename = "";
                 if (dt_list.Rows.Count > 0)
                 {
                     for (int ix = 0; ix < dt_list.Rows.Count; ix++)
                     {

                         vecode = dt_list.Rows[ix]["eid"].ToString();
                         vename = dt_list.Rows[ix]["ename"].ToString();


                         if (chk_data(vecode) == false || chk_data(vecode) == true)
                         {
                             string str = "select (SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE (SlNo = em.DesgId)) AS Designation, DesgId FROM tbl_Employee_Mast AS em where (ID='" + vecode + "')";
                             DataTable dv = clsDataAccess.RunQDTbl(str);
                             try
                             {

                                 int ind = dgvAttend.Rows.Add();
                                 this.dgvAttend.Rows[ind].Cells["col_ecode"].Value = vecode;
                                 this.dgvAttend.Rows[ind].Cells["col_ename"].Value = vename;
                                 this.dgvAttend.Rows[ind].Cells["col_desg"].Value = dv.Rows[0][0].ToString();
                                 this.dgvAttend.Rows[ind].Cells["col_wday"].Value = txtDays.Text;
                                 this.dgvAttend.Rows[ind].Cells["col_proxy"].Value = 0;


                                 dgvAttend.Rows[ind].Cells["col_absent"].Value = 0;
                                 dgvAttend.Rows[ind].Cells["col_desgid"].Value = dv.Rows[0][1].ToString();


                                 DataTable prev_att = clsDataAccess.RunQDTbl("select  IsNull(SUM(Wday),0) AS Wday, IsNull(SUM(Proxy),0) AS Proxy from [tbl_Employee_Attend] where ID='" + vecode + "' and Month ='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "' and  Season = '" + cmbYear.Text + "' and (Location_ID <>'" + Location_ID + "')");
                                 dgvAttend.Rows[ind].Cells["col_others"].Value = "WD : " + prev_att.Rows[0]["wday"] + (char)13 + "P : " + prev_att.Rows[0]["proxy"];

                             }
                             catch { }

                         }
                     }
                 }
            }
        }

        private void cmbZone_DropDown(object sender, EventArgs e)
        {
            cmbZone.ReturnValue = "0";
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("select zone,zid from tbl_zone order by zid");
            if (dt.Rows.Count > 0)
            {
                cmbZone.LookUpTable = dt;
                cmbZone.ReturnIndex = 1;
            }
        }

        

        private void chkAllLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllLocation.Checked == true)
            {
                cmbZone.Enabled = true;
                cmbZone.PopUp();
            }
            else
            {
                cmbZone.Text = "";
                cmbZone.Enabled = false;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvAttend.ClearSelection();
                //int nRowIndex = dataGridView1.Rows.Count - 1;

                //dataGridView1.Rows[nRowIndex].Selected = true;
                //dataGridView1.Rows[nRowIndex].Cells[0].Selected = true;

                int RIndex = 0;
                string searchValue = txtSearch.Text.Trim().ToLower();

                dgvAttend.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                try
                {
                    foreach (DataGridViewRow row in dgvAttend.Rows)
                    {
                        if (row.Cells[1].Value.ToString().ToLower().Contains(searchValue) || row.Cells[0].Value.ToString().ToLower().Equals(searchValue))
                        {
                            dgvAttend.Rows[RIndex].Selected = true;
                            dgvAttend.Rows[RIndex].Cells[0].Selected = true;
                           // row.Selected = true;
                            dgvAttend.CurrentCell = dgvAttend.Rows[RIndex].Cells[0];
                            break;
                        }
                        RIndex++;
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void frmEmpAttend_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtSearch.Focus();
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
               for (int cnt = 0; cnt < dgvAttend.Rows.Count; cnt++)
                    {calc_wd(cnt);}
               dgvAttend.Columns["col_cwd"].Visible = true;

        }

        public void proc_exp()
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;

            int iCol = 0;

            string fname = cmblocation.Text.Trim().Replace(" ", "_") + "_" + Location_ID + "_" + AttenDtTmPkr.Value.ToString("MMM_yyyy") + "_as_on_" + DateTime.Now.ToString("dd_mm_yy_hh_mm_ss_tt");

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                lbl_path.Text = folderBrowserDialog1.SelectedPath + "\\";
                path = lbl_path.Text.Trim() + "\\Log" + System.DateTime.Now.Day + System.DateTime.Now.Month + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".txt";

            }
            if (!File.Exists(path))
            {
                //File.Create(path);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                using (var tw = new StreamWriter(fs))
                {
                    tw.WriteLine("#Company: " + lblCo.Text.Trim());
                    tw.WriteLine("#Version: " + edpcom.PBUILD_DATE.ToString("dd/MM/yyyy"));
                    tw.WriteLine("#Date: " + System.DateTime.Now);
                    tw.Close();
                }
            }

            DataTable dtexp = new DataTable();
            
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            worksheet.Name = "Attendance";
            iCol = 11;
            Excel.Range range;

            iCol = 0;

            excel.Cells[1, 1] = "CODE";
            excel.Cells[1, 2] = "NAME";
            excel.Cells[1, 3] = "DESIGNATION";
            excel.Cells[1, 4] = "SHIFT";
            excel.Cells[1, 5] = "WD";
            excel.Cells[1, 6] = "WO";
            excel.Cells[1, 7] = "PROXY";
            excel.Cells[1, 8] = "ED";
            excel.Cells[1, 9] = "Absent";
            excel.Cells[1, 10] = "Location";
            excel.Cells[1, 11] = "LocID";

            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 9]);
            range.EntireRow.Hidden = true;

            excel.Cells[2, 1] = lblCo.Text.Trim().ToUpper();
            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 9]);
            range.Font.Size = 10;
            range.Font.Bold = true;
            range.Merge(true);

            excel.Cells[3, 1] = cmblocation.Text.Trim().ToUpper();
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, 9]);
            range.Font.Size = 8;
            range.Font.Bold = true;
            range.Merge(true);


            excel.Cells[4, 1] = "Attendance Report for the month of " + AttenDtTmPkr.Value.ToString("MMMM-yyyy");
            range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, 9]);
            range.Font.Size = 8;
            range.Font.Bold = true;
            range.Merge(true);




            excel.Cells[5, 1] = "CODE";
            excel.Cells[5, 2] = "NAME";
            excel.Cells[5, 3] = "DESIGNATION";
            excel.Cells[5, 4] = "SHIFT";
            excel.Cells[5, 5] = "WD";
            excel.Cells[5, 6] = "WO";
            excel.Cells[5, 7] = "PROXY";
            excel.Cells[5, 8] = "ED";
            excel.Cells[5, 9] = "Absent";
            excel.Cells[5, 10] = "Location";
            excel.Cells[5, 11] = "LocID";
            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, 9]);
            range.Font.Bold = true;

            dtexp.Columns.Add("CODE");
            dtexp.Columns.Add("NAME");
            dtexp.Columns.Add("DESIGNATION");
            dtexp.Columns.Add("SHIFT");
            dtexp.Columns.Add("WDAY");
            dtexp.Columns.Add("WO");
            dtexp.Columns.Add("PROXY");
            dtexp.Columns.Add("ED");
            dtexp.Columns.Add("ABSENT");

            dtexp.TableName = "attend";

            int iRow = 0, iRw = 5;
            try
            {
                foreach (DataGridViewRow r in dgvAttend.Rows)
                {

                    iRw++;
                    iCol = 0;
                    dtexp.Rows.Add();
                    excel.Cells[iRw, 1] = "'" + dgvAttend.Rows[iRow].Cells["col_ecode"].Value.ToString().Trim();

                    excel.Cells[iRw, 2] = dgvAttend.Rows[iRow].Cells["col_ename"].Value.ToString().Trim();
                    excel.Cells[iRw, 3] = dgvAttend.Rows[iRow].Cells["col_desg"].Value.ToString().Trim();
                    excel.Cells[iRw, 4] = dgvAttend.Rows[iRow].Cells["col_shift"].Value.ToString().Trim();
                    excel.Cells[iRw, 5] = dgvAttend.Rows[iRow].Cells["col_wday"].Value.ToString().Trim();
                    range = worksheet.get_Range(worksheet.Cells[iRw, 9], worksheet.Cells[iRw, 9]);
                    range.Formula = "=(" + txtDays.Text + "-E" + iRw + ")";
                    excel.Cells[iRw, 6] = dgvAttend.Rows[iRow].Cells["col_WO"].Value.ToString().Trim();
                    excel.Cells[iRw, 7] = dgvAttend.Rows[iRow].Cells["col_proxy"].Value.ToString().Trim();
                    excel.Cells[iRw, 8] = dgvAttend.Rows[iRow].Cells["col_ed"].Value.ToString().Trim();
                    excel.Cells[iRw, 10] = cmblocation.Text;
                    excel.Cells[iRw, 11] = Location_ID;

                    dtexp.Rows[iRow]["CODE"] = dgvAttend.Rows[iRow].Cells["col_ecode"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["NAME"] = dgvAttend.Rows[iRow].Cells["col_ename"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["DESIGNATION"] = dgvAttend.Rows[iRow].Cells["col_desg"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["SHIFT"] = dgvAttend.Rows[iRow].Cells["col_shift"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["WDAY"] = dgvAttend.Rows[iRow].Cells["col_wday"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["WO"] = dgvAttend.Rows[iRow].Cells["col_WO"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["PROXY"] = dgvAttend.Rows[iRow].Cells["col_proxy"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["ED"] = dgvAttend.Rows[iRow].Cells["col_ed"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["ABSENT"] = dgvAttend.Rows[iRow].Cells["col_absent"].Value.ToString().Trim();

                    iRow++;
                }
            }
            catch { }

            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[iRw, 9]);

            Excel.Borders borders = range.Borders;

            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 2d;

            object missing = System.Reflection.Missing.Value;





            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();
            
            //workbook.SaveAs(lbl_path.Text + fname + ".xls");
            ((Excel._Worksheet)worksheet).SaveAs(lbl_path.Text + fname + ".xlsx", missing, missing, missing, false, missing, missing, missing, missing);
            //((Excel._Application)excel).SaveFileDialog();
            //((Excel._Application)excel).Save(lbl_path.Text + fname + ".xlsx");

            //worksheet.SaveAs(lbl_path.Text + fname + ".xls", missing, missing, missing, false, missing, missing, missing, missing);
            // ((Excel._Application)excel).Quit();


            fr.attend_pdf(dtexp, lblCo.Text, cmblocation.Text, AttenDtTmPkr.Value.ToString("MMMM-yyyy"), lbl_path.Text + fname + ".pdf");
            //excel.Save(lbl_path.Text + fname + ".xls");
            //fr.ShowDialog();



            MessageBox.Show("Attendance Export Completed!", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public void reproc_exp()
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;

            int iCol = 0;

            string fname = cmblocation.Text.Trim().Replace(" ", "_") + "_" + Location_ID + "_" + AttenDtTmPkr.Value.ToString("MMM_yyyy") + "_as_on_" + DateTime.Now.ToString("dd_mm_yy_hh_mm_ss_tt");
            path = "";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                lbl_path.Text = folderBrowserDialog1.SelectedPath + "\\";
                path = lbl_path.Text.Trim() + "\\Log" + System.DateTime.Now.Day + System.DateTime.Now.Month + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".txt";

            }
            if (!File.Exists(path))
            {
                //File.Create(path);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                using (var tw = new StreamWriter(fs))
                {
                    tw.WriteLine("#Company: " + lblCo.Text.Trim());
                    tw.WriteLine("#Version: " + edpcom.PBUILD_DATE.ToString("dd/MM/yyyy"));
                    tw.WriteLine("#Date: " + System.DateTime.Now);
                    tw.Close();
                }
            }

            DataTable dtexp = new DataTable();
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            worksheet.Name = "Attendance";
            iCol = 11;
            Excel.Range range;

            iCol = 0;

            excel.Cells[1, 1] = lblCo.Text.Trim().ToUpper();
            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 9]);
            range.Font.Size=10;
            range.Font.Bold = true;
            range.Merge(true);

            excel.Cells[2, 1] = cmblocation.Text.Trim().ToUpper();
            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 9]);
            range.Font.Size = 8;
            range.Font.Bold = true;
            range.Merge(true);


            excel.Cells[3, 1] = "Attendance Report for the month of "+ AttenDtTmPkr.Value.ToString("MMMM-yyyy");
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, 9]);
            range.Font.Size = 8;
            range.Font.Bold = true;
            range.Merge(true);




            excel.Cells[4, 1] = "CODE";
            excel.Cells[4, 2] = "NAME";
            excel.Cells[4, 3] = "DESIGNATION";
            excel.Cells[4, 4] = "SHIFT";
            excel.Cells[4, 5] = "WD";
            excel.Cells[4, 6] = "WO";
            excel.Cells[4, 7] = "PROXY";
            excel.Cells[4, 8] = "ED";
            excel.Cells[4, 9] = "Absent";
            /*excel.Cells[4, 10] = "Location";
            excel.Cells[4, 11] = "LocID";*/

            range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, 9]);
            range.Font.Bold = true;
            range.Font.Size = 8;

            dtexp.Columns.Add("CODE");
            dtexp.Columns.Add("NAME");
            dtexp.Columns.Add("DESIGNATION");
            dtexp.Columns.Add("SHIFT");
            dtexp.Columns.Add("WDAY");
            dtexp.Columns.Add("WO");
            dtexp.Columns.Add("PROXY");
            dtexp.Columns.Add("ED");
            dtexp.Columns.Add("ABSENT");

            dtexp.TableName = "attend";

            int iRow = 0, iRw = 4;
            try
            {
                foreach (DataGridViewRow r in dgvAttend.Rows)
                {

                    iRw++;
                    iCol = 0;
                    dtexp.Rows.Add();
                    excel.Cells[iRw, 1] = "'" + dgvAttend.Rows[iRow].Cells["col_ecode"].Value.ToString().Trim();
                    excel.Cells[iRw, 2] = dgvAttend.Rows[iRow].Cells["col_ename"].Value.ToString().Trim();
                    excel.Cells[iRw, 3] = dgvAttend.Rows[iRow].Cells["col_desg"].Value.ToString().Trim();
                    excel.Cells[iRw, 4] = dgvAttend.Rows[iRow].Cells["col_shift"].Value.ToString().Trim();
                    excel.Cells[iRw, 5] = dgvAttend.Rows[iRow].Cells["col_wday"].Value.ToString().Trim();
                    range = worksheet.get_Range(worksheet.Cells[iRw, 9], worksheet.Cells[iRw, 9]);
                    //range.Formula = "=(" + txtDays.Text + "-E" + iRw + ")";
                    excel.Cells[iRw, 6] = dgvAttend.Rows[iRow].Cells["col_WO"].Value.ToString().Trim();
                    excel.Cells[iRw, 7] = dgvAttend.Rows[iRow].Cells["col_proxy"].Value.ToString().Trim();
                    excel.Cells[iRw, 8] = dgvAttend.Rows[iRow].Cells["col_ed"].Value.ToString().Trim();
                    excel.Cells[iRw, 9] = dgvAttend.Rows[iRow].Cells["col_absent"].Value.ToString().Trim();
                    /*excel.Cells[iRw, 10] = cmblocation.Text;
                    excel.Cells[iRw, 11] = Location_ID;*/

                    range = worksheet.get_Range(worksheet.Cells[iRw, 1], worksheet.Cells[iRw, 9]);
                    range.Font.Size = 8;

                    dtexp.Rows[iRow]["CODE"] = dgvAttend.Rows[iRow].Cells["col_ecode"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["NAME"] = dgvAttend.Rows[iRow].Cells["col_ename"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["DESIGNATION"] = dgvAttend.Rows[iRow].Cells["col_desg"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["SHIFT"] = dgvAttend.Rows[iRow].Cells["col_shift"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["WDAY"] = dgvAttend.Rows[iRow].Cells["col_wday"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["WO"] = dgvAttend.Rows[iRow].Cells["col_WO"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["PROXY"] = dgvAttend.Rows[iRow].Cells["col_proxy"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["ED"] = dgvAttend.Rows[iRow].Cells["col_ed"].Value.ToString().Trim();
                    dtexp.Rows[iRow]["ABSENT"] = dgvAttend.Rows[iRow].Cells["col_absent"].Value.ToString().Trim();

                    iRow++;
                }
            }
            catch { }

            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[iRw, 9]);

            Excel.Borders borders = range.Borders;

            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 2d;

            object missing = System.Reflection.Missing.Value;





            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();
            //((Excel._Application)excel).SaveFileDialog();
            //((Excel._Application)excel).Save(lbl_path.Text + fname + ".xls");

            //worksheet.SaveAs(lbl_path.Text + fname + ".xls", missing, missing, missing, false, missing, missing, missing, missing);
            // ((Excel._Application)excel).Quit();

            ((Excel._Worksheet)worksheet).SaveAs(lbl_path.Text + fname + ".xls", missing, missing, missing, false, missing, missing, missing, missing);
            fr.attend_pdf(dtexp, lblCo.Text, cmblocation.Text, AttenDtTmPkr.Value.ToString("MMMM-yyyy"), lbl_path.Text + fname + ".pdf");
            //excel.Save(lbl_path.Text + fname + ".xls");
            //fr.ShowDialog();



            MessageBox.Show("Attendance Export Completed!", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            if (btnProcess.Text.ToLower() == "process")
            {
                proc_exp();

            }
            else
            {
                reproc_exp();
            }
            
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            string extension = Path.GetExtension(filePath);
            string conStr = string.Empty, header = "YES", sheetName="";
            lbl_Log.Text = "";

            lbl_path.Text = filePath.Substring(0, filePath.LastIndexOf("\\"));
            path = lbl_path.Text.Trim() + "\\Log" + System.DateTime.Now.Day + System.DateTime.Now.Month + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".txt";

            if (!File.Exists(path))
            {
                //File.Create(path);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                using (var tw = new StreamWriter(fs))
                {
                    tw.WriteLine("#Company: " + lblCo.Text.Trim());
                    tw.WriteLine("#Location: " + cmblocation.Text.Trim());
                    tw.WriteLine("#Month: " + AttenDtTmPkr.Value.ToString("MMMM-yyyy"));
                    tw.WriteLine("#Version: " + edpcom.PBUILD_DATE.ToString("dd/MM/yyyy"));
                    tw.WriteLine("#Date: " + System.DateTime.Now);
                    tw.Close();
                }
            }
             switch (extension)
            {

                case ".xls": //Excel 97-03
                    conStr = string.Format(Excel03ConString, filePath, header);
                    break;

                case ".xlsx": //Excel 07
                    conStr = string.Format(Excel07ConString, filePath, header);
                    break;
            }

            //Get the name of the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dtExcelSchema.Rows.Count > 0)
                    {
                        sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                    }
                    else
                    {
                        sheetName = "Sheet1$";
                    }
                    con.Close();
                }
            }

            //Read Data from the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    using (OleDbDataAdapter oda = new OleDbDataAdapter())
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandText = "SELECT * From [" + sheetName + "]";
                        cmd.Connection = con;
                        con.Open();
                        oda.SelectCommand = cmd;
                        oda.FillSchema(dt, SchemaType.Source);
                        oda.Fill(dt);
                        con.Close();


                        if (dt.Rows.Count > 0)
                        {
                            dgvAttend.Rows.Clear();
                            int ix = 0;
                            dt.Rows.RemoveAt(3);
                            dt.Rows.RemoveAt(2);
                            dt.Rows.RemoveAt(1);
                            dt.Rows.RemoveAt(0);
                            string ecode, chkName="",ename,SHIFT,SftID ,desg, desgid, wd, ot, ed, wo, abs, locid;
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                            {
                                for (int idx = 0; idx < dt.Rows.Count; idx++)
                                {
                                    ecode=dt.Rows[idx]["CODE"].ToString().Trim();
                                   
                                    ename=dt.Rows[idx]["NAME"].ToString().Trim();
                                   
                                    try{chkName=clsDataAccess.ReturnValue("SELECT (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS EName FROM tbl_Employee_Mast AS em  where (ID='" + ecode.Trim() + "')");

                                    }
                                    catch { chkName = ""; }
                                    
                                    desg=dt.Rows[idx]["DESIGNATION"].ToString().Trim();
                                    desgid = clsDataAccess.ReturnValue("SELECT SlNo from tbl_Employee_DesignationMaster where (DesignationName='" + desg + "')");
                                    SHIFT = dt.Rows[idx]["SHIFT"].ToString().Trim();
                                    SftID = clsDataAccess.ReturnValue("select sid from tbl_shift where (sname='" + SHIFT + "')");
                                    wd=dt.Rows[idx]["WD"].ToString().Trim();
                                    ot=dt.Rows[idx]["PROXY"].ToString().Trim();
                                    ed=dt.Rows[idx]["ED"].ToString().Trim();
                                    wo=dt.Rows[idx]["WO"].ToString().Trim();
                                    abs=dt.Rows[idx]["ABSENT"].ToString().Trim();
                                    locid=dt.Rows[idx]["LocID"].ToString().Trim();

                                    if (ecode.Trim() != "" && ename.Trim().ToLower() == chkName.Trim().ToLower())
                                    {
                                        if (Rechk_data(ecode, idx) == true)
                                        {
                                            file.WriteLine("Name: " + ename.Trim().ToString() + " ECode: " + ecode.Trim() + " already exist, Check Row : " + (idx + 1));
                                            //file.Close();
                                            lbl_Log.Text = lbl_Log.Text + Environment.NewLine + "Already exist, Check Row : " + (idx + 1) + "Name: " + ename.Trim().ToString() + " ECode: " + ecode.Trim();
                                        }


                                        try
                                        {
                                            int ind = dgvAttend.Rows.Add();
                                            this.dgvAttend.Rows[ind].Cells["col_ecode"].Value = ecode;
                                            this.dgvAttend.Rows[ind].Cells["col_ename"].Value = ename;
                                            this.dgvAttend.Rows[ind].Cells["col_desg"].Value = desg;
                                            this.dgvAttend.Rows[ind].Cells["col_wday"].Value = wd;
                                            this.dgvAttend.Rows[ind].Cells["col_proxy"].Value = ot;
                                            this.dgvAttend.Rows[ind].Cells["col_ed"].Value = ed;
                                            this.dgvAttend.Rows[ind].Cells["col_WO"].Value = wo;
                                            dgvAttend.Rows[ind].Cells["col_absent"].Value = abs;


                                            dgvAttend.Rows[ind].Cells["col_desgid"].Value = desgid;


                                            dgvAttend.Rows[ind].Cells["col_shift"].Value = SHIFT.ToString();
                                            dgvAttend.Rows[ind].Cells["col_shift_id"].Value = SftID.ToString();


                                            DataTable prev_att = clsDataAccess.RunQDTbl("select IsNull(SUM(Wday),0) AS Wday, IsNull(SUM(Proxy),0) AS Proxy from [tbl_Employee_Attend] where ID='" + ecode + "' and Month ='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "' and  Season = '" + cmbYear.Text + "' and (Location_ID <>'" + Location_ID + "')");
                                            dgvAttend.Rows[ind].Cells["col_others"].Value = "WD : " + prev_att.Rows[0]["wday"] + (char)13 + "P : " + prev_att.Rows[0]["proxy"];

                                            calc_desg();

                                        }
                                        catch { }




                                    }

                                    else
                                    {
                                        if (File.Exists(path))
                                        {
                                            
                                                if (ecode.Trim() == "")
                                                {
                                                    file.WriteLine("Name: " + ename + " ECode: " + ecode + ", No Code Found / Blank code, Check Row : " + (idx + 1));
                                                    lbl_Log.Text = lbl_Log.Text + Environment.NewLine + "No Code Found / Blank code, Check Row : " + (idx + 1) + "  Name: " + ename.Trim().ToString() + " ECode: " + ecode.Trim();
                                                }
                                                else if (ecode.Trim() != "" && ename.Trim().ToLower() != chkName.Trim().ToLower())
                                                {
                                                    if (chkName.Trim().ToLower() == "")
                                                    {
                                                        file.WriteLine("Name: " + ename + " ECode: " + ecode + ", Incorrect Code, No employee found, Check Row : " + (idx + 1));
                                                        lbl_Log.Text = lbl_Log.Text + Environment.NewLine + "Incorrect Code, No employee found, Check Row : " + (idx + 1) + " Name: " + ename.Trim().ToString() + " ECode: " + ecode.Trim();
                                                    }
                                                    else
                                                    {
                                                        file.WriteLine("Name: " + ename + " ECode: " + ecode + ", Incorrect Employee Name, Check Row : " + (idx + 1));
                                                        lbl_Log.Text = lbl_Log.Text + Environment.NewLine + "Incorrect Employee Name, Check Row : " + (idx + 1) + " Name: " + ename.Trim().ToString() + " ECode: " + ecode.Trim();
                                                    }

                                                }
                                                //file.Close();

                                              
                                            }
                                        }
                                       
                                    }

                                file.Close();
                                }


                            if (lbl_Log.Text.Trim() != "")
                            {
                                MessageBox.Show(lbl_Log.Text + Environment.NewLine + "Check Log: " + path, "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                           }
                        }

                    
                    }

                
                }
            
            }
        }

      


         
        




    }

