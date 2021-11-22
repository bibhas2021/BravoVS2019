using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading;
using Microsoft.Win32;
using Edpcom;
using System.IO;
using System.Data.OleDb;


namespace PayRollManagementSystem
{
    public partial class frmEmpAttendance : Form//EDPComponent.FormBaseERP
    {
        int Location_ID = 0, Company_id=0;
        int PreviousRow = 0, PreviousColumn = 0;
        int calc_tot_days = 0, ed_wo=0;
        int NumberOfDays;
        string path="",fname="";

        EDPConnection edpcon=new EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();


        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        
        public frmEmpAttendance()
        {
            InitializeComponent();
        }

        private Boolean SearchHoliday(DataTable HoliDayDtbl, Int32 HDay)
        {
            int Cnt = 0;

            for (Cnt = 0; Cnt < HoliDayDtbl.Rows.Count; Cnt++)
            {
                if (HDay == Convert.ToInt32(HoliDayDtbl.Rows[Cnt]["HolDay"].ToString()))
                {
                    return true;
                }

            }
            return false;
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
              
               log_status=ds.Tables[0].Rows[0]["log_status"].ToString();
               return log_status;
            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.ToString());
                edpcon.Close();
                return "NS";

            }
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


        private void Extractcmd_Click(object sender, EventArgs e)
        {
            if (cmblocation.Text == "")
            {
                EDPMessageBox.EDPMessage.Show("Please select the location.");
                return;
            }
            

            else
            {

                DataView dv;
                if (CheckAttendanceIsDailyOrMonthlyWise() == "M")
                {
                    EDPMessageBox.EDPMessage.Show("You can not make changes due to monthly attendance already defined.");
                    dv = new DataView(EmployeeList_attend());
                }
                else
                {
                    dv = new DataView(EmployeeList());
                }

                Extractcmd.Visible = false;
                AttendanceGrid.Columns.Clear();
               
                dv.Sort = "Employee Name";
                AttendanceGrid.DataSource = dv;

                
                int Cnt = 1, chk_val = 0, cnt_ab = 0;
                int sun = NoOfSundays(AttenDtTmPkr.Value);
                DataGridViewTextBoxColumn Dtcol;
                DataGridViewTextBoxColumn Dtcol1;
                DataGridViewCellStyle CellStyle1 = new DataGridViewCellStyle();
                DataGridViewCellStyle CellStyle2 = new DataGridViewCellStyle();
                DataGridViewCellStyle CellStyle3 = new DataGridViewCellStyle();
                DataGridViewCellStyle CellStyle4 = new DataGridViewCellStyle();


                AttendanceGrid.Columns[0].Visible = true;
                //AttendanceGrid.Columns[1].Frozen = true;
                //AttendanceGrid.Columns[2].Frozen = true;

                AttendanceGrid.Columns[1].ReadOnly = true;
                AttendanceGrid.Columns[2].ReadOnly = true;
                AttendanceGrid.Columns[1].HeaderText = "Employee Name";
                AttendanceGrid.Columns[1].Name = "Employee Name";
                AttendanceGrid.Columns[2].HeaderText = "Employee Designation";
                AttendanceGrid.Columns[2].DataPropertyName = "Employee Designation";
                AttendanceGrid.Columns[2].Name = "Employee Designation";
                AttendanceGrid.Columns[0].Width = 60;
                AttendanceGrid.Columns[1].Width = 140;
                AttendanceGrid.Columns[2].Width = 100;
                //AttendanceGrid.Columns[3].Width = 30;

                AttendanceGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                AttendanceGrid.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
                AttendanceGrid.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                //AttendanceGrid.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;



                CellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                CellStyle1.BackColor = System.Drawing.Color.Honeydew;

                AttendanceGrid.Columns[1].DefaultCellStyle = CellStyle1;
                AttendanceGrid.Columns[2].DefaultCellStyle = CellStyle1;

                Dtcol1 = new DataGridViewTextBoxColumn();
                Dtcol1.DefaultCellStyle = CellStyle1;
                AttendanceGrid.Columns.Add(Dtcol1);
                AttendanceGrid.Columns[3].HeaderText = "Proxy";
                AttendanceGrid.Columns[3].DataPropertyName = "Proxy";
                AttendanceGrid.Columns[3].Name = "Proxy";
                AttendanceGrid.Columns[3].Width = 40;
                //AttendanceGrid.Columns[3].Frozen = true;
                AttendanceGrid.Columns[3].ReadOnly = true;

                for (Cnt = 0; Cnt < AttendanceGrid.Rows.Count; Cnt++)
                {
                    string Salary_Head = clsDataAccess.GetresultS("select Proxy_Day from tbl_Employee_Proxy_Attendance where Employee_ID ='" + AttendanceGrid.Rows[Cnt].Cells[0].Value + "' and Month ='" + AttenDtTmPkr.Value.ToString("MMMM") + "' and  Session = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + "    ");
                    if (Salary_Head == null)
                        AttendanceGrid.Rows[Cnt].Cells[3].Value = "0";
                    else
                        AttendanceGrid.Rows[Cnt].Cells[3].Value = Salary_Head;

                    AttendanceGrid.Rows[Cnt].Height = 40;
                }



               DataTable dt_mod = clsDataAccess.RunQDTbl("Select CR.MOD,isNUll(CR.[hrs_per_wd],8)[hrs_per_wd],isNull(CR.[hrs_per_ot],4)[hrs_per_ot],isNull(CR.[apply_hrs_wd],0)[apply_hrs_wd],isNull(CR.[apply_hrs_ot],0)[apply_hrs_ot],isNull(CR.[apply_hrs_ed],0)[apply_hrs_ed],isNull(CR.[hrs_per_ed],4)[hrs_per_ed] from Companywiseid_Relation CR  where (CR.Location_ID='" + Location_ID + "')");
                try
                {
                    string modVal = dt_mod.Rows[0][0].ToString().ToUpper();

                    //lbl_Accpt_wd_hrs.Text = dt.Rows[0]["apply_hrs_wd"].ToString().ToUpper();
                    //lbl_Accpt_ot_hrs.Text = dt.Rows[0]["apply_hrs_ot"].ToString().ToUpper();

                    //lbl_Accpt_ed_hrs.Text = dt.Rows[0]["apply_hrs_ed"].ToString().ToUpper();

                    //lbl_wd_hrs.Text = dt.Rows[0]["hrs_per_wd"].ToString().ToUpper();
                    //lbl_ot_hrs.Text = dt.Rows[0]["hrs_per_ot"].ToString().ToUpper();
                    //lbl_ed_hrs.Text = dt.Rows[0]["hrs_per_ed"].ToString().ToUpper();

                    //if (lbl_Accpt_wd_hrs.Text == "")
                    //{
                    //    lbl_Accpt_wd_hrs.Text = "0";
                    //}

                    //if (lbl_ot_hrs.Text == "")
                    //{
                    //    lbl_ot_hrs.Text = "0";
                    //}

                    //if (lbl_Accpt_ot_hrs.Text == "")
                    //{
                    //    lbl_Accpt_ot_hrs.Text = "0";
                    //}
                    //if (lbl_wd_hrs.Text == "")
                    //{
                    //    lbl_wd_hrs.Text = "0";
                    //}


                    //if (lbl_ed_hrs.Text == "")
                    //{
                    //    lbl_ed_hrs.Text = "0";
                    //}

                    //if (lbl_Accpt_ed_hrs.Text == "")
                    //{
                    //    lbl_Accpt_ed_hrs.Text = "0";
                    //}

                    if (modVal == "MONTHOFDAYS")
                    {
                        try
                        {
                            NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                            lblMOD.Text = NumberOfDays.ToString();
                            
                        }
                        catch { }
                    }
                    else if (modVal == "MOD-EWO")
                    {
                        //lbl_mod.Text = "MOD-EWO";
                        try
                        {
                            NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                            lblMOD.Text = NumberOfDays.ToString();
                        }
                        catch { }
                    }
                    else if (modVal == "MOD-SUNDAYS")
                    {
                        try
                        {
                            NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value);
                            lblMOD.Text = NumberOfDays.ToString();
                        }
                        catch { }
                    }
                    else if (modVal.Contains("MOD-WO"))
                    {
                        NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                        lblMOD.Text = NumberOfDays.ToString();
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('[');
                        lblWO.Text = strFromTo[0];

                        lblMOD.Text = (NumberOfDays - Convert.ToInt32(lblWO.Text)).ToString();
                        //tbTo.Text = strFromTo[1];
                    }
                    else if (modVal.Contains("RANGE-SUNDAYS"))
                    {
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                         NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), true);
                         lblMOD.Text = NumberOfDays.ToString();

                        //tbTo.Text = strFromTo[1];
                    }
                    else if (modVal.Contains("RANGE"))
                    {
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                         NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), false);
                         lblMOD.Text = NumberOfDays.ToString();
                        //tbTo.Text = strFromTo[1];
                    }
                    else
                    {
                        lblMOD.Text = dt_mod.Rows[0][0].ToString();
                    }

                    if (lblMOD.Text == "0")
                    {
                         NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                         lblMOD.Text = NumberOfDays.ToString();
                    }
                }
                catch
                {
                    try
                    {
                        NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                        lblMOD.Text = NumberOfDays.ToString();
                    }
                    catch { }
                }
                lblWO.Text = (Convert.ToInt32(lblTdays.Text) - Convert.ToInt32(lblMOD.Text)).ToString("0");
                //lblWO.Text = "4";

                NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);

                CellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                CellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                CellStyle2.Format = "";
                DataTable HoliDayDtbl = HolidayList();
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
                    if ((clsDataAccess.GetresultS("select loc_initial from Companywiseid_Relation where (Location_ID='" + Location_ID + "')") == "1") && (ed_wo == 1))
                    {
                        ed_wo = 1;
                    }
                    else
                    {
                        ed_wo = 0;
                    }

                }
                catch { }

                for (Cnt = 1; Cnt <= NumberOfDays; Cnt++)
                {

                    Dtcol = new DataGridViewTextBoxColumn();


                    string AttenDate;
                    AttenDate = Convert.ToDateTime(DatePatern(Cnt, AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());


                    if (DateAndTime.WeekdayName(DateAndTime.Weekday(Convert.ToDateTime(AttenDate), FirstDayOfWeek.Monday), false, FirstDayOfWeek.Monday) == "Sunday")
                    {
                        CellStyle3.BackColor = System.Drawing.Color.Lavender;
                        CellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        CellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                        Dtcol.DefaultCellStyle = CellStyle3;
                    }

                    else if (SearchHoliday(HoliDayDtbl, Cnt) == true)
                    {
                        CellStyle4.BackColor = System.Drawing.Color.OldLace;
                        CellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        CellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                        Dtcol.DefaultCellStyle = CellStyle4;
                    }
                    else
                    {
                        Dtcol.DefaultCellStyle = CellStyle2;
                    }

                    Dtcol.HeaderText = Cnt.ToString();
                    //Dtcol.DataPropertyName = Cnt.ToString().Trim();
                    Dtcol.ReadOnly = false;
                    AttendanceGrid.Columns.Add(Dtcol);
                    AttendanceGrid.Columns[Cnt + 3].Name = Cnt.ToString();
                    AttendanceGrid.Columns[Cnt + 3].DataPropertyName = Cnt.ToString();
                    AttendanceGrid.Columns[Cnt + 3].Width = 30;

                    if (Cnt == NumberOfDays)
                    {
                        Dtcol1 = new DataGridViewTextBoxColumn();
                        Dtcol1.DefaultCellStyle = CellStyle1;
                        AttendanceGrid.Columns.Add(Dtcol1);
                        Dtcol1.ReadOnly = true;
                        AttendanceGrid.Columns[Cnt + 4].HeaderText = "WD";
                        AttendanceGrid.Columns[Cnt + 4].DataPropertyName = "WD";
                        AttendanceGrid.Columns[Cnt + 4].Name = "WD";
                        AttendanceGrid.Columns[Cnt + 4].Width = 30;
                        AttendanceGrid.Columns[Cnt + 4].ReadOnly = true;


                        Dtcol1 = new DataGridViewTextBoxColumn();
                        Dtcol1.DefaultCellStyle = CellStyle1;
                        AttendanceGrid.Columns.Add(Dtcol1);
                        Dtcol1.ReadOnly = true;
                        AttendanceGrid.Columns[Cnt + 5].HeaderText = "WOff";
                        AttendanceGrid.Columns[Cnt + 5].DataPropertyName = "WOff";
                        AttendanceGrid.Columns[Cnt + 5].Name = "Woff";
                        AttendanceGrid.Columns[Cnt + 5].Width = 30;
                        AttendanceGrid.Columns[Cnt + 5].ReadOnly = false;



                        Dtcol1 = new DataGridViewTextBoxColumn();
                        Dtcol1.DefaultCellStyle = CellStyle1;
                        AttendanceGrid.Columns.Add(Dtcol1);
                        Dtcol1.ReadOnly = true;
                        AttendanceGrid.Columns[Cnt + 6].HeaderText = "Abs";
                        AttendanceGrid.Columns[Cnt + 6].DataPropertyName = "Abs";
                        AttendanceGrid.Columns[Cnt + 6].Name = "TotalAbsent";
                        AttendanceGrid.Columns[Cnt + 6].Width = 30;
                        AttendanceGrid.Columns[Cnt + 6].ReadOnly = true;
                      //  AttendanceGrid.Columns["TotalAbsent"].Frozen = true;
                        


                        Dtcol1 = new DataGridViewTextBoxColumn();
                        Dtcol1.DefaultCellStyle = CellStyle1;
                        AttendanceGrid.Columns.Add(Dtcol1);
                        Dtcol1.ReadOnly = true;
                        AttendanceGrid.Columns[Cnt + 7].HeaderText = "Total";
                        AttendanceGrid.Columns[Cnt + 7].DataPropertyName = "Total";
                        AttendanceGrid.Columns[Cnt + 7].Name = "TotalDaysWorked";
                        AttendanceGrid.Columns[Cnt + 7].Width = 30;
                        AttendanceGrid.Columns[Cnt + 7].ReadOnly = true;
                       // AttendanceGrid.Columns["TotalDaysWorked"].Frozen = true;



                        Dtcol1 = new DataGridViewTextBoxColumn();
                        Dtcol1.DefaultCellStyle = CellStyle1;
                        AttendanceGrid.Columns.Add(Dtcol1);
                        Dtcol1.ReadOnly = true;
                        AttendanceGrid.Columns[Cnt + 8].HeaderText = "Hol";
                        AttendanceGrid.Columns[Cnt + 8].DataPropertyName = "Holiday";
                        AttendanceGrid.Columns[Cnt + 8].Name = "Hol";
                        AttendanceGrid.Columns[Cnt + 8].Width = 30;
                        AttendanceGrid.Columns[Cnt + 8].Visible = true;
                    }
                }

                if (Convert.ToInt32(clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Attend_daily where (Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') and (Location_ID='" + Location_ID + "') and (Company_id='" + Company_id + "')")) == 0)
                { //AttendanceGrid.Columns[1].sh
                    int day1 = 0, day2 = 0, calculateDay = 0, month_no = 0, rwo = 0, cwo = 0, cdt=4,wo=0;
                    string AttenDate;
                    for (int j = 0; j <= AttendanceGrid.Rows.Count - 1; j++)
                    {
                        day1 = 0; day2 = 0; calculateDay = 0; month_no = 0; rwo = rwo + 1; cdt = 4 + cwo; cwo = cwo + 1;
                        wo = 0;
                        string Employ_Location = clsDataAccess.GetresultS("select Location_id from tbl_Employee_Mast where ID ='" + AttendanceGrid.Rows[j].Cells[0].Value + "'  ");
                        DataTable AllocateEmploy = clsDataAccess.RunQDTbl("select FromDate,Posting_Month,ToDate,LOcation_ID from tbl_Emp_Posting where Employ_ID='" + AttendanceGrid.Rows[j].Cells[0].Value + "' and Posting_Month = '" + clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month) + "'and Session='" + cmbYear.Text + "' order by FromDate ");
                        month_no = AttenDtTmPkr.Value.Month;
                        if (Information.IsNumeric(Employ_Location) == false)
                            Employ_Location = "0";
                        if (Convert.ToInt32(Employ_Location) == Location_ID)
                        {
                            if (rwo > 7)
                            {
                                rwo = 1;
                                cwo = rwo;
                                cdt = 4;
                            }

                            for (int ij = 4; ij < AttendanceGrid.ColumnCount - 4; ij++)
                            {

                                if (cdt == ij)
                                {
                                    if (ed_wo == 1)
                                    {
                                        try
                                        {
                                            //if (AttendanceGrid.Rows[j].Cells[ij].Value.ToString().ToUpper() == "P" || AttendanceGrid.Rows[j].Cells[ij].Value == null)
                                            AttendanceGrid.Rows[j].Cells[ij].Value = "WO";

                                        }
                                        catch
                                        {
                                            AttendanceGrid.Rows[j].Cells[ij].Value = "WO";
                                        }
                                    }
                                    else
                                    {
                                        if (AttendanceGrid.Columns[ij].HeaderText.ToLower() == "wd")
                                        {
                                            AttendanceGrid.Rows[j].Cells["WD"].Value = "";
                                        }
                                        else if (AttendanceGrid.Columns[ij].HeaderText.ToLower() == "woff")
                                        {
                                            if (Convert.ToDouble(lblWO.Text) > 0)
                                            {
                                                AttendanceGrid.Rows[j].Cells["Woff"].Value = lblWO.Text;

                                                AttendanceGrid.Rows[j].Cells["Hol"].Value = "0";
                                            }
                                            else
                                            {
                                                AttendanceGrid.Rows[j].Cells["Woff"].Value = sun.ToString();
                                                AttendanceGrid.Rows[j].Cells["Hol"].Value = "0";
                                            }
                                        }
                                        else
                                        {

                                            AttenDate = Convert.ToDateTime(DatePatern(ij - 3, AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());
                                            if (DateAndTime.WeekdayName(DateAndTime.Weekday(Convert.ToDateTime(AttenDate), FirstDayOfWeek.Monday), false, FirstDayOfWeek.Monday) != "Sunday")
                                            {
                                                AttendanceGrid.Rows[j].Cells[ij].Value = "P";
                                            }
                                            else
                                            {
                                                if (ed_wo != 1)
                                                {
                                                    AttendanceGrid.Rows[j].Cells[ij].Value = "WO";
                                                }
                                            }
                                            //AttendanceGrid.Rows[j].Cells[ij].Value = "P";
                                        }
                                    }
                                    cdt = cdt + 7;
                                }
                                else
                                {

                                    if (AttendanceGrid.Columns[ij].HeaderText.ToLower() == "wd")
                                    {
                                        AttendanceGrid.Rows[j].Cells["WD"].Value = "";
                                    }
                                    else if (AttendanceGrid.Columns[ij].HeaderText.ToLower() =="woff")
                                    {
                                        if (Convert.ToDouble(lblWO.Text) > 0)
                                        {
                                            AttendanceGrid.Rows[j].Cells["Woff"].Value = lblWO.Text;
                                        }
                                        else
                                        {
                                            AttendanceGrid.Rows[j].Cells["Woff"].Value = sun.ToString();

                                        }
                                    }
                                    else
                                    {

                                        AttenDate = Convert.ToDateTime(DatePatern(ij - 3, AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());
                                        if (DateAndTime.WeekdayName(DateAndTime.Weekday(Convert.ToDateTime(AttenDate), FirstDayOfWeek.Monday), false, FirstDayOfWeek.Monday) != "Sunday")
                                        {
                                            AttendanceGrid.Rows[j].Cells[ij].Value = "P";
                                        }
                                        else
                                        {
                                            if (ed_wo != 1)
                                            {
                                                wo++;
                                                AttendanceGrid.Rows[j].Cells[ij].Value = "WO";
                                            }
                                        }
                                       // AttendanceGrid.Rows[j].Cells[ij].Value = "P";
                                    }
                                }
                            }

                            for (int i = 0; i <= AllocateEmploy.Rows.Count - 1; i++)
                            {
                                int co = i + 1;
                                int cou = AllocateEmploy.Rows.Count;
                                if (co < cou)
                                    day2 = Convert.ToDateTime(AllocateEmploy.Rows[i + 1]["ToDate"]).Day;
                                else
                                    day2 = Day_count(month_no) + 1;

                                day1 = Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day;

                                Employ_Location = Convert.ToString(AllocateEmploy.Rows[i]["LOcation_ID"]);
                                if (Convert.ToInt32(Employ_Location) != Location_ID)
                                {
                                    for (int ij = day1; ij < day2; ij++)
                                    {
                                        AttenDate="";
                                        AttenDate = Convert.ToDateTime(DatePatern(ij, AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());
                                        AttendanceGrid.Rows[j].Cells[ij + 3].Value = " ";
                                    }
                                }
                            }
                        }

                        else
                        {
                            AttenDate="";
                            for (int ij = 4; ij <= AttendanceGrid.ColumnCount - 6; ij++)
                            {
                                AttenDate = Convert.ToDateTime(DatePatern(ij-3, AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());
                                if (DateAndTime.WeekdayName(DateAndTime.Weekday(Convert.ToDateTime(AttenDate), FirstDayOfWeek.Monday), false, FirstDayOfWeek.Monday) != "Sunday")
                                {
                                    AttendanceGrid.Rows[j].Cells[ij].Value = "P";
                                }
                                else
                                {
                                    if (ed_wo != 1)
                                    {
                                        wo++;
                                        AttendanceGrid.Rows[j].Cells[ij].Value = "WO";
                                    }
                                }
                            }
                            for (int i = 0; i <= AllocateEmploy.Rows.Count - 1; i++)
                            {
                                if (Location_ID == Convert.ToInt32(AllocateEmploy.Rows[i]["LOcation_ID"]))
                                {
                                    //if (i > 0)
                                    //{
                                    int co = i + 1;
                                    int cou = AllocateEmploy.Rows.Count;
                                    if (co < cou)
                                        day2 = Convert.ToDateTime(AllocateEmploy.Rows[i + 1]["ToDate"]).Day;
                                    else
                                        day2 = Day_count(month_no) + 1;

                                    day1 = Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day;

                                    for (int ij = day1; ij < day2; ij++)
                                    {
                                        AttenDate="";
                                        AttenDate = Convert.ToDateTime(DatePatern(ij, AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());
                                        if (DateAndTime.WeekdayName(DateAndTime.Weekday(Convert.ToDateTime(AttenDate), FirstDayOfWeek.Monday), false, FirstDayOfWeek.Monday) != "Sunday")
                                        {
                                            AttendanceGrid.Rows[j].Cells[ij + 3].Value = "P";
                                        }
                                        else
                                        {
                                            if (ed_wo != 1)
                                            {
                                                wo++;
                                                AttendanceGrid.Rows[j].Cells[ij + 3].Value = "WO";
                                            }
                                        }
                                    }
                                    calculateDay = calculateDay + day1;
                                    //}
                                    //else if (AllocateEmploy.Rows.Count == 1)
                                    //{
                                    //    day1 = Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day;
                                    //    for (int ij = day1; ij <= NumberOfDays; ij++)
                                    //    {
                                    //        AttendanceGrid.Rows[j].Cells[ij + 2].Value = "P";
                                    //    }
                                    //}
                                }

                            }
                        }
                       /*
                        try
                        {
                            if (Convert.ToString(AttendanceGrid.Rows[j].Cells["WD"].Value).Trim() == "")
                            {
                                AttendanceGrid.Rows[j].Cells["WD"].Value = (Convert.ToDouble(lblMOD.Text) - Convert.ToDouble(AttendanceGrid.Rows[j].Cells["TotalAbsent"].Value));
                            }
                        }
                        catch { AttendanceGrid.Rows[j].Cells["WD"].Value = lblMOD.Text; }


                        try
                        {
                            if (Convert.ToString(AttendanceGrid.Rows[j].Cells["Woff"].Value).Trim() == "")
                            {
                                AttendanceGrid.Rows[j].Cells["Woff"].Value = lblWO.Text;
                            }
                        }
                        catch { AttendanceGrid.Rows[j].Cells["Woff"].Value = "0"; }
                       
                        */
                    }

                    Thread Th = new Thread(new ThreadStart(LoadLeaveData));
                    Th.Start();

                }
                else if (Convert.ToInt32(clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Attend_daily where (Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') and (Location_ID='" + Location_ID + "') and (Company_id='" + Company_id + "')")) != Convert.ToInt32(clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Attend where (Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') and (Location_ID='" + Location_ID + "') and (Company_id='" + Company_id + "')")))
                { //AttendanceGrid.Columns[1].sh

                    clsDataAccess.RunQry("Delete from tbl_Employee_Attend_daily where  (Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') and (Location_ID='" + Location_ID + "') and (Company_id='" + Company_id + "')");
                   
                    int day1 = 0, day2 = 0, calculateDay = 0, month_no = 0, rwo = 0, cwo = 0, cdt = 4;
                    for (int j = 0; j <= AttendanceGrid.Rows.Count - 1; j++)
                    {
                        day1 = 0; day2 = 0; calculateDay = 0; month_no = 0; rwo = rwo + 1; cdt = 4 + cwo; cwo = cwo + 1;
                        string Employ_Location = clsDataAccess.GetresultS("select Location_id from tbl_Employee_Mast where ID ='" + AttendanceGrid.Rows[j].Cells[0].Value + "'  ");
                        DataTable AllocateEmploy = clsDataAccess.RunQDTbl("select FromDate,Posting_Month,ToDate,LOcation_ID from tbl_Emp_Posting where Employ_ID='" + AttendanceGrid.Rows[j].Cells[0].Value + "' and Posting_Month = '" + clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month) + "'and Session='" + cmbYear.Text + "' order by FromDate ");
                        month_no = AttenDtTmPkr.Value.Month;
                        if (Information.IsNumeric(Employ_Location) == false)
                            Employ_Location = "0";
                        if (Convert.ToInt32(Employ_Location) == Location_ID)
                        {
                            if (rwo > 7)
                            {
                                rwo = 1;
                                cwo = rwo;
                                cdt = 4;
                            }



                            for (int ij = 4; ij <= AttendanceGrid.ColumnCount - 3; ij++)
                            {

                                if (cdt == ij)
                                {
                                    if (ed_wo == 1)
                                    {
                                        if (AttendanceGrid.Rows[j].Cells[ij].Value.ToString().ToUpper() == "P")
                                            AttendanceGrid.Rows[j].Cells[ij].Value = "WO";
                                    }
                                    else
                                    {
                                        AttendanceGrid.Rows[j].Cells[ij].Value = "P";
                                    }
                                    cdt = cdt + 7;
                                }
                                else
                                {
                                    AttendanceGrid.Rows[j].Cells[ij].Value = "P";
                                }
                            }

                            for (int i = 0; i <= AllocateEmploy.Rows.Count - 1; i++)
                            {
                                int co = i + 1;
                                int cou = AllocateEmploy.Rows.Count;
                                if (co < cou)
                                    day2 = Convert.ToDateTime(AllocateEmploy.Rows[i + 1]["ToDate"]).Day;
                                else
                                    day2 = Day_count(month_no) + 1;

                                day1 = Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day;

                                Employ_Location = Convert.ToString(AllocateEmploy.Rows[i]["LOcation_ID"]);
                                if (Convert.ToInt32(Employ_Location) != Location_ID)
                                {
                                    for (int ij = day1; ij < day2; ij++)
                                    {
                                        string AttenDate;
                                        AttenDate = Convert.ToDateTime(DatePatern(ij, AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());
                                        AttendanceGrid.Rows[j].Cells[ij + 3].Value = " ";
                                    }
                                }
                            }
                        }

                        else
                        {
                            for (int ij = 4; ij <= AttendanceGrid.ColumnCount - 3; ij++)
                            {
                                AttendanceGrid.Rows[j].Cells[ij].Value = "P";
                            }
                            for (int i = 0; i <= AllocateEmploy.Rows.Count - 1; i++)
                            {
                                if (Location_ID == Convert.ToInt32(AllocateEmploy.Rows[i]["LOcation_ID"]))
                                {
                                    //if (i > 0)
                                    //{
                                    int co = i + 1;
                                    int cou = AllocateEmploy.Rows.Count;
                                    if (co < cou)
                                        day2 = Convert.ToDateTime(AllocateEmploy.Rows[i + 1]["ToDate"]).Day;
                                    else
                                        day2 = Day_count(month_no) + 1;

                                    day1 = Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day;

                                    for (int ij = day1; ij < day2; ij++)
                                    {
                                        string AttenDate;
                                        AttenDate = Convert.ToDateTime(DatePatern(ij, AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());
                                        //if (DateAndTime.WeekdayName(DateAndTime.Weekday(Convert.ToDateTime(AttenDate), FirstDayOfWeek.Monday), false, FirstDayOfWeek.Monday) != "Sunday")

                                        AttendanceGrid.Rows[j].Cells[ij + 3].Value = "P";
                                    }
                                    calculateDay = calculateDay + day1;
                                    //}
                                    //else if (AllocateEmploy.Rows.Count == 1)
                                    //{
                                    //    day1 = Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day;
                                    //    for (int ij = day1; ij <= NumberOfDays; ij++)
                                    //    {
                                    //        AttendanceGrid.Rows[j].Cells[ij + 2].Value = "P";
                                    //    }
                                    //}
                                }

                            }
                        }
                    }

                    Thread Th = new Thread(new ThreadStart(LoadLeaveData));
                    Th.Start();

                }
                else
                {
                    DataTable dt = clsDataAccess.RunQDTbl("select (select CO_NAME from Company where GCODE=ead.Company_id)as 'company'," +
                        "(select CO_ADD from Company where GCODE=ead.Company_id)as 'coadd'," +
                        "(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=ead.Location_ID) as 'client'," +
                        "(select (SELECT Client_ADD1 FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=ead.Location_ID) as 'clientadd'," +
                        "(select Location_Name from tbl_Emp_Location EL where Location_ID=ead.Location_ID) as 'location'," +
                        "'' as 'Nature','" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "' as 'month',eid," +
                        "((SELECT distinct (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS ename FROM tbl_Employee_Mast WHERE (ID = ead.eid)))as 'ename'," +
                        "((SELECT distinct (CASE WHEN ltrim(rtrim(FathFN)) != '' THEN FathFN ELSE '' END) + (CASE WHEN ltrim(rtrim(FathMN)) != '' THEN ' ' + FathMN ELSE '' END) + (CASE WHEN ltrim(rtrim(FathLN)) != '' THEN ' ' + FathLN ELSE '' END) AS ename FROM tbl_Employee_Mast WHERE (ID = ead.eid)))as 'fathername'," +
                        "d1,d2,d3,d4,d5,d6,d7,d8,d9,d10,d11,d12,d13,d14,d15,d16,d17,d18,d19,d20,d21,d22,d23,d24,d25,d26,d27,d28,d29,d30,d31,"+
                        "(case when ((SELECT Absent FROM tbl_Employee_Attend WHERE Month=ead.month and LOcation_ID=ead.Location_ID and Company_id=ead.Company_id and Desgid=ead.Desgid and ID=ead.eid)=Absent) then Absent else (SELECT Absent FROM tbl_Employee_Attend WHERE Month=ead.month and LOcation_ID=ead.Location_ID and Company_id=ead.Company_id and Desgid=ead.Desgid and ID=ead.eid) end) as 'Absent',"+
                        "(case when ((SELECT Wday FROM tbl_Employee_Attend WHERE Month=ead.month and LOcation_ID=ead.Location_ID and Company_id=ead.Company_id and Desgid=ead.Desgid and ID=ead.eid)=Wday) then Wday else (SELECT Wday FROM tbl_Employee_Attend WHERE Month=ead.month and LOcation_ID=ead.Location_ID and Company_id=ead.Company_id and Desgid=ead.Desgid and ID=ead.eid) end) as 'tdays'," +
                        "(SELECT distinct  LEFT(Gender, 1) FROM tbl_Employee_Mast WHERE (ID = ead.eid))'Sex',woff,sfid from tbl_Employee_Attend_daily ead where (MONTH='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') and (Location_ID='" + Location_ID + "') order by 'ename'");


                    int j = 0;
                    
                      NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                      string cl = "";
                      for (int rw = 0; rw < dt.Rows.Count; rw++)
                      {
                          cnt_ab = 0;
                          //for (Cnt = 1; Cnt <= NumberOfDays; Cnt++)
                          //{
                              Cnt = 1;
                              for (int ij = 4; ij < AttendanceGrid.ColumnCount ; ij++)
                              {
                                  try
                                  {
                                      if (AttendanceGrid.Columns[ij].HeaderText == "WD")
                                      {
                                          AttendanceGrid.Rows[rw].Cells[ij].Value = dt.Rows[rw]["tdays"].ToString();
                                      }
                                      else if (AttendanceGrid.Columns[ij].HeaderText == "WOff")
                                      {
                                          //***AttendanceGrid.Rows[rw].Cells[ij].Value = lblWO.Text;   //dt.Rows[rw][Cnt + 9].ToString();

                                          //if (Convert.ToDouble(lblWO.Text) > 0)
                                          //{
                                          //    AttendanceGrid.Rows[rw].Cells["Woff"].Value = lblWO.Text;
                                          //}
                                          //else
                                          //{
                                          //    AttendanceGrid.Rows[rw].Cells["Woff"].Value = sun.ToString();

                                          //}

                                          AttendanceGrid.Rows[rw].Cells["Woff"].Value = dt.Rows[rw]["woff"].ToString();

                                          AttendanceGrid.Rows[rw].Cells["hol"].Value = dt.Rows[rw]["sfid"].ToString();
                                      }
                                      else if (AttendanceGrid.Columns[ij].HeaderText == "Abs")
                                      {
                                          AttendanceGrid.Rows[rw].Cells[ij].Value = dt.Rows[rw]["Absent"].ToString();
                                      }
                                      else if (AttendanceGrid.Columns[ij].HeaderText == "Total")
                                      {

                                          AttendanceGrid.Rows[rw].Cells[ij].Value = Convert.ToDouble(dt.Rows[rw]["tdays"].ToString()) + Convert.ToDouble(lblWO.Text) + Convert.ToDouble(dt.Rows[rw]["Absent"].ToString());
                                          //dt.Rows[rw][Cnt + 9].ToString(); 
                                      }

                                      else
                                      {
                                          cl = "d" + AttendanceGrid.Columns[ij].HeaderText;
                                          string AttenDate;
                                          AttenDate = Convert.ToDateTime(DatePatern(ij-3, AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());
                                          if (DateAndTime.WeekdayName(DateAndTime.Weekday(Convert.ToDateTime(AttenDate), FirstDayOfWeek.Monday), false, FirstDayOfWeek.Monday) == "Sunday")
                                          {
                                              if (dt.Rows[rw][cl].ToString().ToUpper() == "A" || dt.Rows[rw][cl].ToString().ToUpper() == "AB" || dt.Rows[rw][cl].ToString().ToUpper() == "AB +________________+ AB")
                                              {
                                                  AttendanceGrid.Rows[rw].Cells[ij].Value = dt.Rows[rw][cl].ToString();
                                              }
                                              else
                                              {
                                                  AttendanceGrid.Rows[rw].Cells[ij].Value = "WO";
                                              }
                                          }
                                          else if (SearchHoliday(HoliDayDtbl, Convert.ToInt32(AttendanceGrid.Columns[ij].HeaderText)) == true)
                                          {
                                              if (dt.Rows[rw][cl].ToString().ToUpper() == "A" || dt.Rows[rw][cl].ToString().ToUpper() == "AB" || dt.Rows[rw][cl].ToString().ToUpper() == "AB +________________+ AB")
                                              {
                                                  AttendanceGrid.Rows[rw].Cells[ij].Value = dt.Rows[rw][cl].ToString();
                                              }
                                              else
                                              {
                                                  AttendanceGrid.Rows[rw].Cells[ij].Value = "H";
                                              }

                                          }
                                          else
                                          {
                                              AttendanceGrid.Rows[rw].Cells[ij].Value = dt.Rows[rw][cl].ToString();
                                          }
                                      }
                                  }
                                  catch { 
                                      //AttendanceGrid.Rows[rw].Cells[ij].Value = "A"; 
                                  }
                                  if (AttendanceGrid.Rows[rw].Cells[ij].Value.ToString().ToUpper() == "AB +________________+ AB" || AttendanceGrid.Rows[rw].Cells[ij].Value.ToString().ToUpper() == "AB" || AttendanceGrid.Rows[rw].Cells[ij].Value.ToString().ToUpper() == "A")
                                  {
                                      cnt_ab = cnt_ab + 1;
                                  }
                                  Cnt++;
                              }
                         // }

                              try
                              {
                                  if (Convert.ToString(AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Value).Trim() =="")
                                  {
                                      AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Value = cnt_ab;
                                  }
                              }
                              catch { AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Value = "0"; }


                              try
                              {
                                  if (Convert.ToString(AttendanceGrid.Rows[rw].Cells["WD"].Value).Trim() == "")
                                  {
                                      AttendanceGrid.Rows[rw].Cells["WD"].Value = (Convert.ToDouble(lblMOD.Text)-cnt_ab);
                                  }
                              }
                              catch { AttendanceGrid.Rows[rw].Cells["WD"].Value = lblMOD.Text; }


                              try
                              {
                                  if (Convert.ToString(AttendanceGrid.Rows[rw].Cells["Woff"].Value).Trim() == "")
                                  {
                                      AttendanceGrid.Rows[rw].Cells["Woff"].Value = lblWO.Text;
                                  }
                              }
                              catch { AttendanceGrid.Rows[rw].Cells["Woff"].Value = "0"; }

                              try
                              {                             
                                  if (Convert.ToDouble(AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Value) < cnt_ab)
                                  {
                                      chk_val = 1;
                                      AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Style.BackColor = Color.Red;
                                  }
                                  else if (Convert.ToDouble(AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Value) > cnt_ab)
                                  {
                                      chk_val = 2;
                                   
                                      AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Style.BackColor = Color.Green;
                                  }
                                  else
                                  {
                                     // chk_val = 0;
                                      AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Style.BackColor = Color.Honeydew;
                                     
                                  }
                              }
                              catch { AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Value = "0"; }

                              cnt_ab = 0;
                      }
                      Thread Th = new Thread(new ThreadStart(LoadLeaveData));
                      Th.Start();

                }

                
                if (chk_val > 0)
                {
                    btnSave.Enabled = false;
                    btnExcel.Enabled = false;
                    MessageBox.Show("Total Absent mismatch");
                }
                else
                {
                    btnSave.Enabled = true;
                    btnExcel.Enabled = true;
                    Extractcmd.Visible = true;


                    DeleteSelcmd.Visible = true;
                }
                chk_val = 0;
            }
            rcheck();
            
        }

        private int Day_count(int month)
        {
            int day = 0;
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                day = 31;

            if (month == 4 || month == 6 || month == 9 || month == 11)
                day = 30;

            if (month == 2)
                day = 28;

            return day;
        }

        private string DatePatern(int PaternDay, int PaternMonth, int PaternYear)
        {
            string ReturnVal = "";
            RegistryKey Reg;
            Reg = Registry.CurrentUser.OpenSubKey("Control Panel\\International", true);
            ReturnVal = Reg.GetValue("sShortDate").ToString();

            switch (ReturnVal.ToString().IndexOf("dd"))
            {
                case 0:
                    ReturnVal = PaternDay.ToString() + "/" + PaternMonth.ToString() + "/" + PaternYear.ToString();
                    break;
                case 3:
                    ReturnVal = PaternMonth.ToString() + "/" + PaternDay.ToString() + "/" + PaternYear.ToString();
                    break;
                case 8:
                    ReturnVal = PaternYear.ToString() + "/" + PaternMonth.ToString() + "/" + PaternDay.ToString();
                    break;

            }

            return ReturnVal;
        }

        private string DatePatern()
        {
            string ReturnVal = "";
            RegistryKey Reg;
            Reg = Registry.CurrentUser.OpenSubKey("Control Panel\\International", true);
            ReturnVal = Reg.GetValue("sShortDate").ToString();
            return ReturnVal;
        }

        public DataTable HolidayList()
        {
            DataTable HolDayDtbl = clsDataAccess.RunQDTbl("SELECT day(HolDate) As HolDay,HolDate,HolidayName FROM " +
            "tbl_Employee_Holiday WHERE Month(HolDate)=" + AttenDtTmPkr.Value.Month + " AND YEAR(HolDate)=" +
            AttenDtTmPkr.Value.Year);

            return HolDayDtbl;
        }

        public DataTable EmployeeList()
        {
            int month = AttenDtTmPkr.Value.Month;
            string Mo = clsEmployee.GetMonthName(month);
            //DataTable dt = clsDataAccess.RunQDTbl("select distinct emp.ID,emp.FirstName+' '+emp.MiddleName+'" +
            //" '+emp.LastName as [Employee Name],desg.DesignationName from tbl_Employee_Mast emp," +
            //" tbl_Employee_DesignationMaster desg , tbl_Emp_Posting ep where emp.DesgId=desg.SlNo " +
            //" and ep.LOcation_ID='" + Location_ID + "' and emp.ID=ep.Employ_ID and Posting_Month ='" + Mo + "'and ep.Session = '" + cmbYear.Text + "'  ");

            DataTable dt = clsDataAccess.RunQDTbl("select distinct emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name],desg.DesignationName " +
                           " from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg  where emp.DesgId=desg.SlNo  " +
                           "  and emp.active=1  and emp.Location_id='" + Location_ID + "' " +
                           "union all " +
                           " select distinct emp.ID,emp.FirstName+' '+emp.MiddleName+'" +
                           " '+emp.LastName as [Employee Name],desg.DesignationName from tbl_Employee_Mast emp," +
                           " tbl_Employee_DesignationMaster desg , tbl_Emp_Posting ep where emp.DesgId=desg.SlNo " +
                           " and ep.LOcation_ID='" + Location_ID + "' and emp.ID=ep.Employ_ID and Posting_Month ='" + Mo + "' and ep.Session = '" + cmbYear.Text + "' and emp.active=1 and  ep.LOcation_ID !=emp.Location_id   ");

            return dt;

        }

        public DataTable EmployeeList_attend()
         {
            string month = AttenDtTmPkr.Value.ToString("M/yyyy");
            //string Mo = clsEmployee.GetMonthName(month);
            //DataTable dt = clsDataAccess.RunQDTbl("select distinct emp.ID,emp.FirstName+' '+emp.MiddleName+'" +
            //" '+emp.LastName as [Employee Name],desg.DesignationName from tbl_Employee_Mast emp," +
            //" tbl_Employee_DesignationMaster desg , tbl_Emp_Posting ep where emp.DesgId=desg.SlNo " +
            //" and ep.LOcation_ID='" + Location_ID + "' and emp.ID=ep.Employ_ID and Posting_Month ='" + Mo + "'and ep.Session = '" + cmbYear.Text + "'  ");

            DataTable dt = clsDataAccess.RunQDTbl("SELECT ID,(SELECT distinct (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS ename FROM tbl_Employee_Mast WHERE (ID = ea.ID)) as [Employee Name] ,"+
            "(select DesignationName from tbl_Employee_DesignationMaster where SlNo=ea.Desgid) as 'DesignationName' FROM tbl_Employee_Attend ea where (month='" + month + "') and (season='" + cmbYear.Text + "') and (location_id='" + Location_ID + "')   order by slno ");

            return dt;

        }

        public String GetSessionByFromToDate(int CurrMonth, int CurrYear)
        {
            String ReturnVal;

            if (CurrMonth > 3)
            {
                ReturnVal = CurrYear.ToString() + "-" + (CurrYear + 1);
            }
            else
            {
                ReturnVal = (CurrYear - 1) + "-" + (CurrYear);
                //ReturnVal = CurrYear.ToString() + "-";
            }
            return ReturnVal;
        }

        private void AttendanceGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[0].Value.ToString().Trim().Length == 0)
            {
                return;
            }
         
            DataGridViewCellStyle CellStyle1 = new DataGridViewCellStyle();
            CellStyle1 = AttendanceGrid.Columns[AttendanceGrid.CurrentCell.ColumnIndex].DefaultCellStyle;

            clsEmployee.TotalLeaveDetails[12] = CellStyle1.BackColor.ToString();

            if (AttendanceGrid.CurrentCell.ColumnIndex > 3)
            {
                if (CellStyle1.BackColor.ToString() == "Color [Empty]" || CellStyle1.BackColor.ToString() == "Color [Lavender]" || CellStyle1.BackColor.ToString() == "Color [OldLace]")
                {
                    string AttenDate;
                    AttenDate = Convert.ToDateTime(DatePatern(Convert.ToInt32(AttendanceGrid.Columns[AttendanceGrid.CurrentCell.ColumnIndex].HeaderText), AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());

                    frmDailyAttendance frmadd = new frmDailyAttendance(Location_ID, cmbYear.Text, clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month));
                    if (AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[AttendanceGrid.CurrentCell.ColumnIndex].Value == "P")
                        AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[AttendanceGrid.CurrentCell.ColumnIndex].Value = null;
                    if (AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[AttendanceGrid.CurrentCell.ColumnIndex].Value != null)
                    {
                        String[] StrRemark = new String[7];
                        StrRemark = AttendanceGrid.CurrentCell.Tag.ToString().Split((char)187);
                        clsEmployee.TotalLeaveDetails[0] = StrRemark[0];
                        clsEmployee.TotalLeaveDetails[1] = StrRemark[1];
                        clsEmployee.TotalLeaveDetails[2] = AttenDate.ToString();//Date
                        clsEmployee.TotalLeaveDetails[3] = AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[0].Value.ToString();//Emp Code
                        clsEmployee.TotalLeaveDetails[4] = StrRemark[2];
                        clsEmployee.TotalLeaveDetails[5] = StrRemark[3];
                        clsEmployee.TotalLeaveDetails[6] = StrRemark[4];
                        clsEmployee.TotalLeaveDetails[7] = StrRemark[5];
                        clsEmployee.TotalLeaveDetails[8] = SeasonVal(); // Session
                        clsEmployee.TotalLeaveDetails[9] = AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[1].Value.ToString();
                        clsEmployee.TotalLeaveDetails[10] = StrRemark[6];
                        clsEmployee.TotalLeaveDetails[11] = StrRemark[7];
                        clsEmployee.TotalLeaveDetails[12] = StrRemark[8];

                    }
                    else
                    {
                        AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[AttendanceGrid.CurrentCell.ColumnIndex].Value = "";
                        clsEmployee.TotalLeaveDetails[0] = "-1";
                        clsEmployee.TotalLeaveDetails[1] = "";
                        clsEmployee.TotalLeaveDetails[2] = AttenDate.ToString();
                        clsEmployee.TotalLeaveDetails[3] = AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[0].Value.ToString();
                        clsEmployee.TotalLeaveDetails[4] = "0";
                        clsEmployee.TotalLeaveDetails[5] = "0";
                        clsEmployee.TotalLeaveDetails[6] = "";
                        clsEmployee.TotalLeaveDetails[7] = "";
                        clsEmployee.TotalLeaveDetails[8] = SeasonVal();
                        clsEmployee.TotalLeaveDetails[9] = AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[1].Value.ToString();
                        clsEmployee.TotalLeaveDetails[10] = "0";
                        clsEmployee.TotalLeaveDetails[11] = "0";
                        clsEmployee.TotalLeaveDetails[12] = "0";
                    }

                    frmadd.ShowDialog();
                    if (frmadd.DialogResult == DialogResult.OK)
                    {
                        if (AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[AttendanceGrid.CurrentCell.ColumnIndex].Value == "")
                            AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[AttendanceGrid.CurrentCell.ColumnIndex].Value = "P";

                        Thread Th = new Thread(new ThreadStart(LoadLeaveData));
                        Th.Start();
                    }
                    else
                    {
                        AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[AttendanceGrid.CurrentCell.ColumnIndex].Value = "P";
                        Thread Th = new Thread(new ThreadStart(LoadLeaveData));
                        Th.Start();
                    }

                }
            }

        }

        public string SeasonVal()
        {
            string ReturnVal = "";
            if (AttenDtTmPkr.Value.Month > 3)
            {
                ReturnVal = AttenDtTmPkr.Value.Year.ToString() + "-" + (AttenDtTmPkr.Value.Year + 1);
            }
            else
            {
                ReturnVal = (AttenDtTmPkr.Value.Year - 1) + "-" + AttenDtTmPkr.Value.Year.ToString();
            }
            return ReturnVal;

        }

        public void LoadLeaveData()
        {
            DataTable LeaveDetailTbl = clsDataAccess.RunQDTbl("select ShortName,LeaveId from tbl_Employee_Config_LeaveDetails "); //where Session='" + SeasonVal() + "'

            DataTable LvDataTbl = clsDataAccess.RunQDTbl("SELECT SlNo,ID,Remarks,day(LeaveDate) As LvDate," +
            "FstLeave,SndLeave,LeaveType,FstProxy,SndProxy FROM tbl_Employee_Attendance WHERE month(LeaveDate)=" + AttenDtTmPkr.Value.Month +
            " AND year(LeaveDate)=" + AttenDtTmPkr.Value.Year + " and LOcation_ID='" + Location_ID + "' ORDER By LvDate");

            int Cnt = 0;
            int TempEmpVal = -1;
            string LeaveFstDet = "", LeaveSnfDet = "";

            for (Cnt = 0; Cnt < LvDataTbl.Rows.Count; Cnt++)
            {
                TempEmpVal = SearchEmpRow(LvDataTbl.Rows[Cnt]["ID"].ToString());
                if (TempEmpVal >= 0)
                {
                    //if (AttendanceGrid.Rows[TempEmpVal].Cells[Convert.ToInt32(LvDataTbl.Rows[Cnt]["LvDate"].ToString()) + 2].Value == "P")
                    //{
                    LeaveFstDet = SearchLeaveType(Convert.ToInt32(LvDataTbl.Rows[Cnt]["FstLeave"]), LeaveDetailTbl);
                    LeaveSnfDet = SearchLeaveType(Convert.ToInt32(LvDataTbl.Rows[Cnt]["SndLeave"]), LeaveDetailTbl);

                    if (LeaveFstDet == "" && LeaveSnfDet == "")
                    {
                        if (Convert.ToInt32(LvDataTbl.Rows[Cnt]["FstProxy"]) == 1)
                            LeaveFstDet = "Pxi";
                        if (Convert.ToInt32(LvDataTbl.Rows[Cnt]["SndProxy"]) == 1)
                            LeaveSnfDet = "Pxi";
                    }

                    //if (AttendanceGrid.Rows[TempEmpVal].Cells[Convert.ToInt32(LvDataTbl.Rows[Cnt]["LvDate"].
                    //    ToString()) + 3].Value.ToString().ToUpper() != "WO")
                    {
                        AttendanceGrid.Rows[TempEmpVal].Cells[Convert.ToInt32(LvDataTbl.Rows[Cnt]["LvDate"].
                            ToString()) + 3].Value = LeaveFstDet + " +________________+ " + LeaveSnfDet;
                    }
                    AttendanceGrid.Rows[TempEmpVal].Cells[Convert.ToInt32(LvDataTbl.Rows[Cnt]["LvDate"].
                        ToString()) + 3].Tag = LvDataTbl.Rows[Cnt]["SlNo"].ToString() + (char)187 +
                        LvDataTbl.Rows[Cnt]["Remarks"].ToString() + (char)187 +
                        LvDataTbl.Rows[Cnt]["FstLeave"].ToString() + (char)187 +
                        LvDataTbl.Rows[Cnt]["SndLeave"].ToString() + (char)187 +
                        SearchLeaveType(Convert.ToInt32(LvDataTbl.Rows[Cnt]["FstLeave"]), LeaveDetailTbl) + (char)187 +
                        SearchLeaveType(Convert.ToInt32(LvDataTbl.Rows[Cnt]["SndLeave"]), LeaveDetailTbl) + (char)187 +
                        LvDataTbl.Rows[Cnt]["LeaveType"].ToString() + (char)187 + LvDataTbl.Rows[Cnt]["FstProxy"].ToString() +
                        (char)187 + LvDataTbl.Rows[Cnt]["SndProxy"].ToString();
                    //}
                }
            }
            int sun = NoOfSundays(AttenDtTmPkr.Value),sun_ab=0;
            double ab_one = 0, ab_two = 0;
            int  NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
            for (int i = 0; i <= AttendanceGrid.Rows.Count - 1; i++)
            {
                 ab_one = 0; ab_two = 0;
                sun_ab=0;
                //int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                ab_one = Convert.ToDouble(clsDataAccess.GetresultS("select count(FstLeave) from tbl_Employee_Attendance where ID='" + AttendanceGrid.Rows[i].Cells[0].Value + "' and month(LeaveDate)=" + AttenDtTmPkr.Value.Month + " AND year(LeaveDate)=" + AttenDtTmPkr.Value.Year + " and LOcation_ID in (" + Location_ID + ") and FstLeave>0"));
                ab_two = Convert.ToDouble(clsDataAccess.GetresultS("select count(SndLeave) from tbl_Employee_Attendance where ID='" + AttendanceGrid.Rows[i].Cells[0].Value + "' and month(LeaveDate)=" + AttenDtTmPkr.Value.Month + " AND year(LeaveDate)=" + AttenDtTmPkr.Value.Year + " and LOcation_ID in (" + Location_ID + ") and SndLeave>0"));
                ab_one = ab_one + ab_two;
                try
                {
                    sun_ab = Convert.ToInt32(clsDataAccess.ReturnValue("select count(DATENAME(dw,LeaveDate)) As LvDate FROM tbl_Employee_Attendance WHERE month(LeaveDate)='" + AttenDtTmPkr.Value.Month + "' AND year(LeaveDate)='" + AttenDtTmPkr.Value.Year + "'  and LOcation_ID='" + Location_ID + "' and DATENAME(dw,LeaveDate)='Sunday' and (ID='" + AttendanceGrid.Rows[i].Cells[0].Value + "')"));
                }
                catch { sun_ab = 0; }

                if (ab_one > 0)
                    ab_one = ab_one / 2;
                //ab_one = NumberOfDays - ab_one; 
                double proxy = Convert.ToDouble(AttendanceGrid.Rows[i].Cells[3].Value);
                AttendanceGrid.Rows[i].Cells[AttendanceGrid.Columns.Count - 3].Value = ab_one;
                AttendanceGrid.Rows[i].Cells[AttendanceGrid.Columns.Count - 2].Value = (NumberOfDays + proxy);
               

                try
                {
                    if (Convert.ToString(AttendanceGrid.Rows[i].Cells["Woff"].Value).Trim() == "")
                    {

                        AttendanceGrid.Rows[i].Cells["Woff"].Value = sun-sun_ab; 
                        //if (AttendanceGrid.Rows[i].Cells["WD"].Value == lblMOD.Text)
                        //{
                        //    AttendanceGrid.Rows[i].Cells["Woff"].Value = sun//lblWO.Text;
                        //}
                        //else
                        //{
                        //    AttendanceGrid.Rows[i].Cells["Woff"].Value = sun; //Convert.ToInt32(Convert.ToDouble(AttendanceGrid.Rows[i].Cells["WD"].Value) / 6);
                        //}
                    }
                }
                catch { AttendanceGrid.Rows[i].Cells["Woff"].Value = "0"; }

                try
                {
                    if (Convert.ToString(AttendanceGrid.Rows[i].Cells["WD"].Value).Trim() == "")
                    {
                        AttendanceGrid.Rows[i].Cells["WD"].Value = (Convert.ToDouble(NumberOfDays) - Convert.ToDouble(AttendanceGrid.Rows[i].Cells["TotalAbsent"].Value) - Convert.ToDouble(AttendanceGrid.Rows[i].Cells["WOff"].Value) - Convert.ToDouble(AttendanceGrid.Rows[i].Cells["Hol"].Value));
                    }
                }
                catch { AttendanceGrid.Rows[i].Cells["WD"].Value = NumberOfDays; }

            }

        }

        public string SearchLeaveType(int LeaveNo, DataTable LeaveDt)
        {
            int Cnt = 0;
            string ReturnVal = "";

            for (Cnt = 0; Cnt < LeaveDt.Rows.Count; Cnt++)
            {
                if (Convert.ToInt32(LeaveDt.Rows[Cnt]["LeaveId"].ToString()) == LeaveNo)
                {
                    ReturnVal = LeaveDt.Rows[Cnt]["ShortName"].ToString();
                    return ReturnVal;
                }

            }
            return ReturnVal;
        }

        public int SearchEmpRow(string EmpoyID)
        {
            int Cnt = 0;
            int ReturnVal = -1;

            for (Cnt = 0; Cnt < AttendanceGrid.RowCount; Cnt++)
            {
                if (EmpoyID == AttendanceGrid.Rows[Cnt].Cells[0].Value.ToString())
                {
                    ReturnVal = Cnt;
                }
            }

            return ReturnVal;
        }

        private void Closecmd_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DeleteOrUpdateAttendanceLogDetails()
        {
            try
            {


                // Boolean rs = false;
                edpcon.Open();
                SqlCommand sqlcmd = new SqlCommand("sp_delete_or_update_attendance_log_details", edpcon.mycon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@company_id", SqlDbType.VarChar).Value = Convert.ToString(clsEmployee.GetCompany_ID(Convert.ToInt32(cmblocation.ReturnValue)));
                sqlcmd.Parameters.AddWithValue("@location_id", SqlDbType.VarChar).Value = cmblocation.ReturnValue;
                sqlcmd.Parameters.AddWithValue("@session", SqlDbType.VarChar).Value = cmbYear.Text;
                sqlcmd.Parameters.AddWithValue("@month", SqlDbType.VarChar).Value = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
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
        private void DeleteSelcmd_Click(object sender, EventArgs e)
        {
            if (AttendanceGrid.CurrentCell == null)
            {
                ERPMessageBox.ERPMessage.Show("Please select a cell that will be deleted.", "Attendance");
                return;
            }

            if (AttendanceGrid.CurrentCell.Tag == null)
            {
                return;
            }
            if (MessageBox.Show("Would you like to delete selected record ? ", "Remove Leave Recoed", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            String[] StrRemark = new String[1];
            StrRemark = AttendanceGrid.CurrentCell.Tag.ToString().Split((char)187);


            clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Attendance WHERE SlNo=" +
                 StrRemark[0].ToString().Trim());
            AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[AttendanceGrid.CurrentCell.ColumnIndex].Value = "P";
            DeleteOrUpdateAttendanceLogDetails();
            //AttendanceGrid.CurrentCell.Value = null;
            //AttendanceGrid.CurrentCell.Tag = "";
            Thread Th = new Thread(new ThreadStart(LoadLeaveData));
            Th.Start();

        }

        private void cmblocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            if (edpcom.CurrentLocation.Trim() != "")
            {
                DataTable dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID in (" + edpcom.CurrentLocation + ") ");
                if (dt.Rows.Count > 0)
                {
                    cmblocation.LookUpTable = dt;
                    cmblocation.ReturnIndex = 1;
                }
                else
                {
                    EDPMessageBox.EDPMessage.Show("No location found.","BRAVO");
                }
            }
            else
            {
                DataTable dt =clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL");
                if (dt.Rows.Count > 0)
                {
                    cmblocation.LookUpTable = dt;
                    cmblocation.ReturnIndex = 1;
                }
                else
                {
                    EDPMessageBox.EDPMessage.Show("No location found.","BRAVO");
                }
            }
        }

        private void cmblocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Extractcmd.Visible = true;
            if (Information.IsNumeric(cmblocation.ReturnValue) == true)
            {
                Location_ID = Convert.ToInt32(cmblocation.ReturnValue);
                Company_id =  clsEmployee.GetCompany_ID(Location_ID);

                lblCoid.Text = Company_id.ToString() ;

                Extractcmd_Click(sender, e);
            }
        }

        private void frmEmpAttendance_Load(object sender, EventArgs e)
        {
            //generate year
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            //
            AttenDtTmPkr.Value = System.DateTime.Now.AddMonths(-1);
            Extractcmd.Visible = false;
            //set session
            try
            {
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

            cmbOption.SelectedIndex = 0;
            // Import and Export
            try
            {
                if (Convert.ToInt32(edpcom.GetDatatable("select ieAttend from CompanyLimiter").Rows[0][0].ToString()) == 1)
                {  btnExport.Visible = true; btnImport.Visible = true; }
                else
                {  btnExport.Visible = false; btnImport.Visible = false; }

            }
            catch { }
        }

        private void AttendanceGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (AttendanceGrid.Columns[e.ColumnIndex].HeaderText == "Proxy")
            {
                if (AttendanceGrid.Rows[e.RowIndex].Cells[0] != null)
                    if (Convert.ToString(AttendanceGrid.Rows[e.RowIndex].Cells[0]) != "")
                        if (Information.IsNumeric(AttendanceGrid.Rows[e.RowIndex].Cells[3].Value) == true)
                        {
                            if (Convert.ToDouble(AttendanceGrid.Rows[e.RowIndex].Cells[3].Value) > 60)
                            {
                                ERPMessageBox.ERPMessage.Show("Proxy Max 60 Days", "Attendance");
                                AttendanceGrid.Rows[e.RowIndex].Cells[3].Value = 0;
                                return;
                            }
                            else if (Convert.ToDouble(AttendanceGrid.Rows[e.RowIndex].Cells[3].Value) < 0)
                            {
                                ERPMessageBox.ERPMessage.Show("Proxy No Cannot be Negative", "Attendance");
                                AttendanceGrid.Rows[e.RowIndex].Cells[3].Value = 0;
                                return;
                            }
                            else
                            {
                                int company_Id = clsEmployee.GetCompany_ID(Location_ID);
                                Boolean flug_save = false;
                                DataTable dt = clsDataAccess.RunQDTbl("select Employee_ID from tbl_Employee_Proxy_Attendance where Employee_ID ='" + AttendanceGrid.Rows[e.RowIndex].Cells[0].Value + "' and Month ='" + AttenDtTmPkr.Text + "' and  Session = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + "    ");
                                if (dt.Rows.Count > 0)
                                    clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Proxy_Attendance where Employee_ID ='" + AttendanceGrid.Rows[e.RowIndex].Cells[0].Value + "' and Month ='" + AttenDtTmPkr.Text + "' and  Session = '" + cmbYear.Text + "' and Location_ID =" + Location_ID + " ");

                                flug_save = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Proxy_Attendance(Employee_ID,Proxy_Day,Month,Session,Location_ID,Company_id) values('" + AttendanceGrid.Rows[e.RowIndex].Cells[0].Value + "','" + AttendanceGrid.Rows[e.RowIndex].Cells[3].Value + "','" + AttenDtTmPkr.Text + "','" + cmbYear.Text + "'," + Location_ID + ",'" + company_Id + "')");
                            }

                        }
            }
        }

        private void AttendanceGrid_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                //    for (int i = 4; i <= AttendanceGrid.Columns.Count - 3; i++)
                //    {
                //        if (Convert.ToString(AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[i].Value) == "P")
                //        {
                //            string AttenDate;
                //            int company_Id = clsEmployee.GetCompany_ID(Location_ID);
                //            AttenDate = Convert.ToDateTime(DatePatern(Convert.ToInt32(AttendanceGrid.Columns[i].HeaderText), AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());
                //            System.DateTime LvDate = new System.DateTime();
                //            LvDate = Convert.ToDateTime(AttenDate);
                //            AttenDate = LvDate.Date.ToString("MM/dd/yyyy");
                //            clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Attendance where ID ='" + AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[0].Value + "' and LeaveDate ='" + AttenDate + "' and Location_ID =" + Location_ID + " ");
                //            clsDataAccess.RunNQwithStatus("INSERT INTO tbl_Employee_Attendance(ID,Remarks,LeaveDate,FstLeave," +
                //            "SndLeave,LeaveType,DayStatus,Location_ID,FstProxy,SndProxy,Company_id) values('" + AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[0].Value + "',' ','" + AttenDate + "','367'," +
                //            367 + ",'0','0'," + Location_ID + ",'0','0','" + company_Id + "')");
                //        }
                //    }

                //    Thread Th = new Thread(new ThreadStart(LoadLeaveData));
                //    Th.Start();
                }

                if (e.KeyCode == Keys.P)
                {                    
                    //clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Attendance where ID ='" + AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[0].Value + "' and month(LeaveDate)=" + AttenDtTmPkr.Value.Month + " AND year(LeaveDate)=" + AttenDtTmPkr.Value.Year + "  and Location_ID =" + Location_ID + " ");

                    //for (int i = 4; i <= AttendanceGrid.Columns.Count - 3; i++)
                    //{
                    //    AttendanceGrid.Rows[AttendanceGrid.CurrentRow.Index].Cells[i].Value = "P";
                    //}
                    //Thread Th = new Thread(new ThreadStart(LoadLeaveData));
                    //Th.Start();
                }
            }
        }
        private void SessionValueCheckAndAssignNoOfDays()
        {
            //////////////////int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
            //////////////////txtDays.Text = NumberOfDays.ToString();

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
                SessionValueCheckAndAssignNoOfDays();
                AttendanceGrid.Columns.Clear();
                cmblocation.Text = "";
                lblWO.Text = NoOfSundays(AttenDtTmPkr.Value).ToString();

                int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                lblTdays.Text = NumberOfDays.ToString();

                lblMOD.Text = (Convert.ToInt32(lblTdays.Text) - Convert.ToInt32(lblWO.Text)).ToString("0");

            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.ToString());
            }
        }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string slno, eid, MOD, Wday, Absent, Proxy, cnt_wo, cnt_hol; 
            string Season = cmbYear.Text, Month = AttenDtTmPkr.Value.ToString("M/yyyy"), Desgid, status, edate, sfid, sno, days_wd, days_ot;
            string apply_hrs_wd, apply_hrs_ot, lv_earn, lv_adj, lv_pbal, ed, woff, cWD, days_ed, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15, d16, d17, d18, d19, d20;
            string d21, d22, d23, d24, d25, d26, d27, d28, d29, d30, d31;
            int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
            // Location_ID, Company_id
            string Sql = "Delete from tbl_Employee_Attend_daily where  (Month='" + Month + "') and (Location_ID='" + Location_ID + "') and (Company_id='" + Company_id + "')";
            clsDataAccess.RunQry(Sql);

                Sql = "";
                Sql = " INSERT INTO  tbl_Employee_Attend_daily(slno, eid, MOD, Wday, Absent, Proxy, Season, Month, Location_ID, Company_id, Desgid, status, edate, sfid, sno, days_wd, days_ot,apply_hrs_wd, apply_hrs_ot, lv_earn, lv_adj, lv_pbal, ed, woff, cWD, days_ed, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15, d16, d17, d18, d19, d20, d21, d22, d23, d24, d25, d26, d27, d28, d29, d30, d31) Values ";
            
            sfid = "0";
            sno = "0";
            days_wd = "0";
            days_ot = "0";

            d29 = "";
            d30 = "";
            d31 = "";
            cnt_wo = "0";
            cnt_hol="0";
            for (int j = 0; j <= AttendanceGrid.Rows.Count - 1; j++)
            {  
                eid = AttendanceGrid.Rows[j].Cells["ID"].Value.ToString();
                MOD = NumberOfDays.ToString();
                Wday = AttendanceGrid.Rows[j].Cells[AttendanceGrid.Columns["WD"].Index].Value.ToString();
                Absent = AttendanceGrid.Rows[j].Cells["TotalAbsent"].Value.ToString();
                Proxy = AttendanceGrid.Rows[j].Cells["Proxy"].Value.ToString();

                cnt_wo=AttendanceGrid.Rows[j].Cells["WOff"].Value.ToString();
                try
                {
                    cnt_hol = AttendanceGrid.Rows[j].Cells["Hol"].Value.ToString();
                }
                catch { cnt_hol = "0";}
                Desgid = clsDataAccess.ReturnValue("select SlNo from tbl_Employee_DesignationMaster where (DesignationName='" + AttendanceGrid.Rows[j].Cells["Employee Designation"].Value.ToString() + "')");
                //=======================================================================
                d1 = AttendanceGrid.Rows[j].Cells["1"].Value.ToString();
                d2 = AttendanceGrid.Rows[j].Cells["2"].Value.ToString();
                d3 = AttendanceGrid.Rows[j].Cells["3"].Value.ToString();
                d4 = AttendanceGrid.Rows[j].Cells["4"].Value.ToString();
                d5 = AttendanceGrid.Rows[j].Cells["5"].Value.ToString();
                d6 = AttendanceGrid.Rows[j].Cells["6"].Value.ToString();
                d7 = AttendanceGrid.Rows[j].Cells["7"].Value.ToString();
                d8 = AttendanceGrid.Rows[j].Cells["8"].Value.ToString();
                d9 = AttendanceGrid.Rows[j].Cells["9"].Value.ToString();
                d10 = AttendanceGrid.Rows[j].Cells["10"].Value.ToString();
                d11 = AttendanceGrid.Rows[j].Cells["11"].Value.ToString();
                d12 = AttendanceGrid.Rows[j].Cells["12"].Value.ToString();
                d13 = AttendanceGrid.Rows[j].Cells["13"].Value.ToString(); 
                d14 = AttendanceGrid.Rows[j].Cells["14"].Value.ToString();
                d15 = AttendanceGrid.Rows[j].Cells["15"].Value.ToString();
                d16 = AttendanceGrid.Rows[j].Cells["16"].Value.ToString();
                d17 = AttendanceGrid.Rows[j].Cells["17"].Value.ToString();
                d18 = AttendanceGrid.Rows[j].Cells["18"].Value.ToString(); 
                d19 = AttendanceGrid.Rows[j].Cells["19"].Value.ToString();

                d20 = AttendanceGrid.Rows[j].Cells["20"].Value.ToString();

                d21 = AttendanceGrid.Rows[j].Cells["21"].Value.ToString();
                d22 = AttendanceGrid.Rows[j].Cells["22"].Value.ToString();
                d23 = AttendanceGrid.Rows[j].Cells["23"].Value.ToString();
                d24 = AttendanceGrid.Rows[j].Cells["24"].Value.ToString();
                d25 = AttendanceGrid.Rows[j].Cells["25"].Value.ToString();
                d26 = AttendanceGrid.Rows[j].Cells["26"].Value.ToString();
                d27 = AttendanceGrid.Rows[j].Cells["27"].Value.ToString();
                d28 = AttendanceGrid.Rows[j].Cells["28"].Value.ToString();

                if (NumberOfDays == 29)
                {   
                    d29 = AttendanceGrid.Rows[j].Cells["29"].Value.ToString();
                    d30 = "";
                    d31 = "";                    
                }
                if (NumberOfDays == 30)
                {
                    d29 = AttendanceGrid.Rows[j].Cells["29"].Value.ToString();
                    d30 = AttendanceGrid.Rows[j].Cells["30"].Value.ToString();
                    d31 = "";
                }
                if (NumberOfDays == 31)
                {
                    d29 = AttendanceGrid.Rows[j].Cells["29"].Value.ToString();
                    d30 = AttendanceGrid.Rows[j].Cells["30"].Value.ToString();
                    d31 = AttendanceGrid.Rows[j].Cells["31"].Value.ToString();
                }

                //=======================================================================
                //AttendanceGrid.Rows[j].Cells[3].Value 
                //for (int Cnt = 1; Cnt <= NumberOfDays; Cnt++)
                //{


                //}
                //slno, eid, MOD, Wday, Absent, Proxy, Season, Month, Location_ID, Company_id, Desgid, status, edate, sfid, sno, days_wd, days_ot,apply_hrs_wd, apply_hrs_ot, lv_earn, lv_adj, lv_pbal, ed, woff, cWD, days_ed, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15, d16, d17, d18, d19, d20, d21, d22, d23, d24, d25, d26, d27, d28, d29, d30, d31
                if (j == 0)
                {
                    Sql = Sql + "('" + (j + 1) + "','" + eid + "','" + MOD + "','" + Wday + "','" + Absent + "','" + Proxy + "','" + Season + "','" + Month + "','" + Location_ID + "','" + Company_id + "','" + Desgid + "','0','" + DateTime.Now.ToString("dd/MMM/yyyy") + "','" + cnt_hol + "','0','" + days_wd + "','" + days_ot + "','0','0','0','0','0','0','" + cnt_wo + "','0','0','" + d1 + "','" + d2 + "','" + d3 + "','" + d4 + "','" + d5 + "','" + d6 + "','" + d7 + "','" + d8 + "','" + d9 + "','" + d10 + "','" + d11 + "','" + d12 + "','" + d13 + "','" + d14 + "','" + d15 + "','" + d16 + "','" + d17 + "','" + d18 + "','" + d19 + "','" + d20 + "','" + d21 + "','" + d22 + "','" + d23 + "','" + d24 + "','" + d25 + "','" + d26 + "','" + d27 + "','" + d28 + "','" + d29 + "','" + d30 + "','" + d31 + "')";

                }
                else
                {
                    Sql = Sql + ", ('" + (j + 1) + "','" + eid + "','" + MOD + "','" + Wday + "','" + Absent + "','" + Proxy + "','" + Season + "','" + Month + "','" + Location_ID + "','" + Company_id + "','" + Desgid + "','0','" + DateTime.Now.ToString("dd/MMM/yyyy") + "','" + cnt_hol + "','0','" + days_wd + "','" + days_ot + "','0','0','0','0','0','0','" + cnt_wo + "','0','0','" + d1 + "','" + d2 + "','" + d3 + "','" + d4 + "','" + d5 + "','" + d6 + "','" + d7 + "','" + d8 + "','" + d9 + "','" + d10 + "','" + d11 + "','" + d12 + "','" + d13 + "','" + d14 + "','" + d15 + "','" + d16 + "','" + d17 + "','" + d18 + "','" + d19 + "','" + d20 + "','" + d21 + "','" + d22 + "','" + d23 + "','" + d24 + "','" + d25 + "','" + d26 + "','" + d27 + "','" + d28 + "','" + d29 + "','" + d30 + "','" + d31 + "')";

                }

            }
            bool bl = clsDataAccess.RunNQwithStatus(Sql.ToUpper().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A"));


          if (bl == true)
          {

              MessageBox.Show("Daily Attendance confirmed", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);

              DataTable dt = clsDataAccess.RunQDTbl("select (select CO_NAME from Company where GCODE=ead.Company_id)as 'company',"+
              "(select CO_ADD from Company where GCODE=ead.Company_id)as 'coadd',"+
              "(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=ead.Location_ID) as 'client',"+
              "(select (SELECT Client_ADD1 FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=ead.Location_ID) as 'clientadd',"+
              "(select Location_Name from tbl_Emp_Location EL where Location_ID=ead.Location_ID) as 'location','" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "' as 'month',eid,"+
              "((SELECT Distinct (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS ename FROM tbl_Employee_Mast WHERE (ID = ead.eid)))as 'ename',"+
              "((SELECT Distinct (CASE WHEN ltrim(rtrim(FathFN)) != '' THEN FathFN ELSE '' END) + (CASE WHEN ltrim(rtrim(FathMN)) != '' THEN ' ' + FathMN ELSE '' END) + (CASE WHEN ltrim(rtrim(FathLN)) != '' THEN ' ' + FathLN ELSE '' END) AS ename FROM tbl_Employee_Mast WHERE (ID = ead.eid)))as 'fathername'," +
              "d1,d2,d3,d4,d5,d6,d7,d8,d9,d10,d11,d12,d13,d14,d15,d16,d17,d18,d19,d20,d21,d22,d23,d24,d25,d26,d27,d28,d29,d30,d31,(Wday- Proxy) as 'tdays'," +
              "(SELECT Distinct LEFT(Gender, 1) FROM tbl_Employee_Mast WHERE (ID = ead.eid))'Sex'," +
              "(select DesignationName from tbl_Employee_DesignationMaster where SlNo=ead.Desgid)'Nature',"+
              "(select sign from Company where GCODE=ead.Company_id)'cosign' from tbl_Employee_Attend_daily ead where (MONTH='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') and (Location_ID='" + Location_ID + "') order by 'ename'");
              DataTable dt2 = clsDataAccess.RunQDTbl("select sign from Company where GCODE=1");
              string stot = clsDataAccess.GetresultS("select sum(Wday) as 'tdays'" +
             " from tbl_Employee_Attend_daily ead where (MONTH='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') and (Location_ID='" + Location_ID + "') Group by Location_ID");
              //dt.Merge(dt1);
              
              dt.Rows.Add();
              int idx = dt.Rows.Count-1;

              dt.Rows[idx]["ename"] = "Total :";
              dt.Rows[idx]["tdays"] = stot;
              dt.Rows[idx]["cosign"] = dt.Rows[0]["cosign"];
              MidasReport.Form1 f1 = new MidasReport.Form1();
              f1.attn_daily(dt, NumberOfDays,dt2);
              f1.ShowDialog();
                  

          }
          else
          {
              MessageBox.Show("Please Check again", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }



            /*
             <DesignColumnRef Name="company" />
            <DesignColumnRef Name="coadd" />
            <DesignColumnRef Name="client" />
            <DesignColumnRef Name="clientadd" />
            <DesignColumnRef Name="location" />
            <DesignColumnRef Name="Nature" />
            <DesignColumnRef Name="month" />
            <DesignColumnRef Name="eid" />
            <DesignColumnRef Name="ename" />
            <DesignColumnRef Name="fathername" />
            <DesignColumnRef Name="d1" />
            <DesignColumnRef Name="d2" />
            <DesignColumnRef Name="d3" />
            <DesignColumnRef Name="d4" />
            <DesignColumnRef Name="d5" />
            <DesignColumnRef Name="d6" />
            <DesignColumnRef Name="d7" />
            <DesignColumnRef Name="d8" />
            <DesignColumnRef Name="d9" />
            <DesignColumnRef Name="d10" />
            <DesignColumnRef Name="d11" />
            <DesignColumnRef Name="d12" />
            <DesignColumnRef Name="d13" />
            <DesignColumnRef Name="d14" />
            <DesignColumnRef Name="d15" />
            <DesignColumnRef Name="d16" />
            <DesignColumnRef Name="d17" />
            <DesignColumnRef Name="d18" />
            <DesignColumnRef Name="d19" />
            <DesignColumnRef Name="d20" />
            <DesignColumnRef Name="d21" />
            <DesignColumnRef Name="d22" />
            <DesignColumnRef Name="d23" />
            <DesignColumnRef Name="d24" />
            <DesignColumnRef Name="d25" />
            <DesignColumnRef Name="d26" />
            <DesignColumnRef Name="d27" />
            <DesignColumnRef Name="d28" />
            <DesignColumnRef Name="d29" />
            <DesignColumnRef Name="d30" />
            <DesignColumnRef Name="d31" />
            <DesignColumnRef Name="tdays" />
             * */
        }

        private void AttendanceGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      
       

         }
        string pval = "",cVal="";
        private void AttendanceGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            PreviousRow = e.RowIndex;
            PreviousColumn = e.ColumnIndex;

            pval = AttendanceGrid.Rows[PreviousRow].Cells[PreviousColumn].Value.ToString();
        }

        private void AttendanceGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month), cnt_val = 0, cnt_ab = 0, cnt_ho = 0, cnt_wo=0;
            string d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15, d16, d17, d18, d19, d20;
            string d21, d22, d23, d24, d25, d26, d27, d28, d29, d30, d31, eid, Absent, Desgid;
            try
            {
                d1 = AttendanceGrid.Rows[PreviousRow].Cells["1"].Value.ToString();
                d2 = AttendanceGrid.Rows[PreviousRow].Cells["2"].Value.ToString();
                d3 = AttendanceGrid.Rows[PreviousRow].Cells["3"].Value.ToString();
                d4 = AttendanceGrid.Rows[PreviousRow].Cells["4"].Value.ToString();
                d5 = AttendanceGrid.Rows[PreviousRow].Cells["5"].Value.ToString();
                d6 = AttendanceGrid.Rows[PreviousRow].Cells["6"].Value.ToString();
                d7 = AttendanceGrid.Rows[PreviousRow].Cells["7"].Value.ToString();
                d8 = AttendanceGrid.Rows[PreviousRow].Cells["8"].Value.ToString();
                d9 = AttendanceGrid.Rows[PreviousRow].Cells["9"].Value.ToString();
                d10 = AttendanceGrid.Rows[PreviousRow].Cells["10"].Value.ToString();
                d11 = AttendanceGrid.Rows[PreviousRow].Cells["11"].Value.ToString();
                d12 = AttendanceGrid.Rows[PreviousRow].Cells["12"].Value.ToString();
                d13 = AttendanceGrid.Rows[PreviousRow].Cells["13"].Value.ToString();
                d14 = AttendanceGrid.Rows[PreviousRow].Cells["14"].Value.ToString();
                d15 = AttendanceGrid.Rows[PreviousRow].Cells["15"].Value.ToString();
                d16 = AttendanceGrid.Rows[PreviousRow].Cells["16"].Value.ToString();
                d17 = AttendanceGrid.Rows[PreviousRow].Cells["17"].Value.ToString();
                d18 = AttendanceGrid.Rows[PreviousRow].Cells["18"].Value.ToString();
                d19 = AttendanceGrid.Rows[PreviousRow].Cells["19"].Value.ToString();

                d20 = AttendanceGrid.Rows[PreviousRow].Cells["20"].Value.ToString();

                d21 = AttendanceGrid.Rows[PreviousRow].Cells["21"].Value.ToString();
                d22 = AttendanceGrid.Rows[PreviousRow].Cells["22"].Value.ToString();
                d23 = AttendanceGrid.Rows[PreviousRow].Cells["23"].Value.ToString();
                d24 = AttendanceGrid.Rows[PreviousRow].Cells["24"].Value.ToString();
                d25 = AttendanceGrid.Rows[PreviousRow].Cells["25"].Value.ToString();
                d26 = AttendanceGrid.Rows[PreviousRow].Cells["26"].Value.ToString();
                d27 = AttendanceGrid.Rows[PreviousRow].Cells["27"].Value.ToString();
                d28 = AttendanceGrid.Rows[PreviousRow].Cells["28"].Value.ToString();

                if (NumberOfDays == 29)
                {
                    d29 = AttendanceGrid.Rows[PreviousRow].Cells["29"].Value.ToString();
                    d30 = "";
                    d31 = "";
                }
                if (NumberOfDays == 30)
                {
                    d29 = AttendanceGrid.Rows[PreviousRow].Cells["29"].Value.ToString();
                    d30 = AttendanceGrid.Rows[PreviousRow].Cells["30"].Value.ToString();
                    d31 = "";
                }
                if (NumberOfDays == 31)
                {
                    d29 = AttendanceGrid.Rows[PreviousRow].Cells["29"].Value.ToString();
                    d30 = AttendanceGrid.Rows[PreviousRow].Cells["30"].Value.ToString();
                    d31 = AttendanceGrid.Rows[PreviousRow].Cells["31"].Value.ToString();
                }

                eid = AttendanceGrid.Rows[PreviousRow].Cells["ID"].Value.ToString();


                Absent = AttendanceGrid.Rows[PreviousRow].Cells["TotalAbsent"].Value.ToString();

                Desgid = clsDataAccess.ReturnValue("select SlNo from tbl_Employee_DesignationMaster where (DesignationName='" + AttendanceGrid.Rows[PreviousRow].Cells["Employee Designation"].Value.ToString() + "')");
                cVal = AttendanceGrid.Rows[PreviousRow].Cells[PreviousColumn].Value.ToString();
                //if (pval != cVal)
                //{
                    cnt_ab = 0;
                    cnt_ho = 0;
                    cnt_wo = 0;
                    AttendanceGrid.Rows[PreviousRow].Cells["Hol"].Value = cnt_ho;
                    for (int Cnt = 1; Cnt <= NumberOfDays; Cnt++)
                    {
                        //if ((Cnt + 3) > PreviousColumn)
                        //{
                        if (AttendanceGrid.Rows[PreviousRow].Cells[Cnt + 3].Value.ToString().ToUpper() == "AB +________________+ AB" || AttendanceGrid.Rows[PreviousRow].Cells[Cnt + 3].Value.ToString().ToUpper() == "AB" || AttendanceGrid.Rows[PreviousRow].Cells[Cnt + 3].Value.ToString().ToUpper() == "A")
                            {
                                //AttendanceGrid.Rows[PreviousRow].Cells[Cnt + 3].Value = "AB +________________+ AB";
                                //return;

                                cnt_ab = cnt_ab + 1;
                            }

                        else if (AttendanceGrid.Rows[PreviousRow].Cells[Cnt + 3].Value.ToString().ToUpper() == "H" || AttendanceGrid.Rows[PreviousRow].Cells[Cnt + 3].Value.ToString().ToUpper() == "HOL" || AttendanceGrid.Rows[PreviousRow].Cells[Cnt + 3].Value.ToString().ToUpper() == "HOLIDAY")
                        {
                            //AttendanceGrid.Rows[PreviousRow].Cells[Cnt + 3].Value = "AB +________________+ AB";
                            //return;

                            cnt_ho = cnt_ho + 1;
                            AttendanceGrid.Rows[PreviousRow].Cells["Hol"].Value = cnt_ho;
                        }
                        else if (AttendanceGrid.Rows[PreviousRow].Cells[Cnt + 3].Value.ToString().ToUpper() == "WO" || AttendanceGrid.Rows[PreviousRow].Cells[Cnt + 3].Value.ToString().ToUpper() == "HOL" || AttendanceGrid.Rows[PreviousRow].Cells[Cnt + 3].Value.ToString().ToUpper() == "O")
                        {
                            //AttendanceGrid.Rows[PreviousRow].Cells[Cnt + 3].Value = "AB +________________+ AB";
                            //return;

                            cnt_wo = cnt_wo + 1;
                            AttendanceGrid.Rows[PreviousRow].Cells["WOff"].Value = cnt_wo;
                        }

                       // }

                    }
                    AttendanceGrid.Rows[PreviousRow].Cells["WD"].Value = NumberOfDays - (cnt_ab + cnt_ho + cnt_wo);

                    if (Convert.ToDouble(AttendanceGrid.Rows[PreviousRow].Cells["TotalAbsent"].Value) < cnt_ab)
                    {
                        btnSave.Enabled = false;
                        btnExcel.Enabled = false;
                        cnt_val=1;
                        AttendanceGrid.Rows[PreviousRow].Cells["TotalAbsent"].Style.BackColor = Color.Red;
                    }
                    else if (Convert.ToDouble(AttendanceGrid.Rows[PreviousRow].Cells["TotalAbsent"].Value) > cnt_ab)
                    {
                        btnSave.Enabled = false;
                        btnExcel.Enabled = false;
                        cnt_val = 2;
                        AttendanceGrid.Rows[PreviousRow].Cells["TotalAbsent"].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        AttendanceGrid.Rows[PreviousRow].Cells["TotalAbsent"].Style.BackColor = Color.Honeydew;
                        btnSave.Enabled = true;
                        btnExcel.Enabled = true;
                    }
                //}

            }
            catch
            {

            }
        }

        public void rcheck()
        {

            int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month), rw=0, cnt_val = AttendanceGrid.Rows.Count, cnt_ab = 0, cnt_ho = 0, cnt_wo = 0;
            
            string eid, Absent;

            for (rw=0;rw<cnt_val;rw++)
            {
                try
                {

                eid = AttendanceGrid.Rows[rw].Cells["ID"].Value.ToString();


                Absent = AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Value.ToString();

                
                cVal = AttendanceGrid.Rows[rw].Cells[PreviousColumn].Value.ToString();
                
                cnt_ab = 0;
                cnt_ho = 0;
                cnt_wo = 0;
                
                AttendanceGrid.Rows[rw].Cells["Hol"].Value = cnt_ho;
                for (int Cnt = 1; Cnt <= NumberOfDays; Cnt++)
                {
                    
                    if (AttendanceGrid.Rows[rw].Cells[Cnt + 3].Value.ToString().ToUpper() == "AB +________________+ AB" || AttendanceGrid.Rows[rw].Cells[Cnt + 3].Value.ToString().ToUpper() == "AB" || AttendanceGrid.Rows[rw].Cells[Cnt + 3].Value.ToString().ToUpper() == "A")
                    {
                       

                        cnt_ab = cnt_ab + 1;
                    }

                    else if (AttendanceGrid.Rows[rw].Cells[Cnt + 3].Value.ToString().ToUpper() == "H" || AttendanceGrid.Rows[rw].Cells[Cnt + 3].Value.ToString().ToUpper() == "HOL" || AttendanceGrid.Rows[rw].Cells[Cnt + 3].Value.ToString().ToUpper() == "HOLIDAY")
                    {
                        

                        cnt_ho = cnt_ho + 1;
                        AttendanceGrid.Rows[rw].Cells["Hol"].Value = cnt_ho;
                    }
                    else if (AttendanceGrid.Rows[rw].Cells[Cnt + 3].Value.ToString().ToUpper() == "WO" || AttendanceGrid.Rows[rw].Cells[Cnt + 3].Value.ToString().ToUpper() == "HOL" || AttendanceGrid.Rows[rw].Cells[Cnt + 3].Value.ToString().ToUpper() == "O")
                    {
                        
                        cnt_wo = cnt_wo + 1;
                        AttendanceGrid.Rows[rw].Cells["WOff"].Value = cnt_wo;
                    }

                    

                }
                AttendanceGrid.Rows[rw].Cells["WD"].Value = NumberOfDays - (cnt_ab + cnt_ho + cnt_wo);

                if (Convert.ToDouble(AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Value) < cnt_ab)
                {
                    btnSave.Enabled = false;
                    btnExcel.Enabled = false;
                    cnt_val = 1;
                    AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Style.BackColor = Color.Red;
                }
                else if (Convert.ToDouble(AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Value) > cnt_ab)
                {
                    btnSave.Enabled = false;
                    btnExcel.Enabled = false;
                    cnt_val = 2;
                    AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Style.BackColor = Color.Green;
                }
                else
                {
                    AttendanceGrid.Rows[rw].Cells["TotalAbsent"].Style.BackColor = Color.Honeydew;
                    btnSave.Enabled = true;
                    btnExcel.Enabled = true;
                }
               

            }
            catch
            {

            }
        }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string slno, eid, MOD, Wday, Absent, Proxy,WO,Hol;
            string Season = cmbYear.Text, Month = AttenDtTmPkr.Value.ToString("M/yyyy"), Desgid, status, edate, sfid, sno, days_wd, days_ot;
            string apply_hrs_wd, apply_hrs_ot, lv_earn, lv_adj, lv_pbal, ed, woff, cWD, days_ed, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15, d16, d17, d18, d19, d20;
            string d21, d22, d23, d24, d25, d26, d27, d28, d29, d30, d31;
            int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
            // Location_ID, Company_id
            string Sql = "Delete from tbl_Employee_Attend_daily where  (Month='" + Month + "') and (Location_ID='" + Location_ID + "') and (Company_id='" + Company_id + "')";
            clsDataAccess.RunQry(Sql);

            Sql = "";
            Sql = " INSERT INTO  tbl_Employee_Attend_daily(slno, eid, MOD, Wday, Absent, Proxy, Season, Month, Location_ID, Company_id, Desgid, status, edate, sfid, sno, days_wd, days_ot,apply_hrs_wd, apply_hrs_ot, lv_earn, lv_adj, lv_pbal, ed, woff, cWD, days_ed, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15, d16, d17, d18, d19, d20, d21, d22, d23, d24, d25, d26, d27, d28, d29, d30, d31) Values ";

            sfid = "0";
            sno = "0";
            days_wd = "0";
            days_ot = "0";
            WO = "0"; Hol = "0";
            d29 = "";
            d30 = "";
            d31 = "";
            for (int j = 0; j <= AttendanceGrid.Rows.Count - 1; j++)
            {
                eid = AttendanceGrid.Rows[j].Cells["ID"].Value.ToString();
                MOD = NumberOfDays.ToString();
                Wday = AttendanceGrid.Rows[j].Cells[AttendanceGrid.Columns["WD"].Index].Value.ToString();
                Absent = AttendanceGrid.Rows[j].Cells["TotalAbsent"].Value.ToString();
                Proxy = AttendanceGrid.Rows[j].Cells["Proxy"].Value.ToString();

                WO = AttendanceGrid.Rows[j].Cells["Woff"].Value.ToString();
                try
                {
                    Hol = AttendanceGrid.Rows[j].Cells["Hol"].Value.ToString();
                }
                catch { Hol = "0"; }
                Desgid = clsDataAccess.ReturnValue("select SlNo from tbl_Employee_DesignationMaster where (DesignationName='" + AttendanceGrid.Rows[j].Cells["Employee Designation"].Value.ToString() + "')");
                //=======================================================================
                d1 = AttendanceGrid.Rows[j].Cells["1"].Value.ToString();
                d2 = AttendanceGrid.Rows[j].Cells["2"].Value.ToString();
                d3 = AttendanceGrid.Rows[j].Cells["3"].Value.ToString();
                d4 = AttendanceGrid.Rows[j].Cells["4"].Value.ToString();
                d5 = AttendanceGrid.Rows[j].Cells["5"].Value.ToString();
                d6 = AttendanceGrid.Rows[j].Cells["6"].Value.ToString();
                d7 = AttendanceGrid.Rows[j].Cells["7"].Value.ToString();
                d8 = AttendanceGrid.Rows[j].Cells["8"].Value.ToString();
                d9 = AttendanceGrid.Rows[j].Cells["9"].Value.ToString();
                d10 = AttendanceGrid.Rows[j].Cells["10"].Value.ToString();
                d11 = AttendanceGrid.Rows[j].Cells["11"].Value.ToString();
                d12 = AttendanceGrid.Rows[j].Cells["12"].Value.ToString();
                d13 = AttendanceGrid.Rows[j].Cells["13"].Value.ToString();
                d14 = AttendanceGrid.Rows[j].Cells["14"].Value.ToString();
                d15 = AttendanceGrid.Rows[j].Cells["15"].Value.ToString();
                d16 = AttendanceGrid.Rows[j].Cells["16"].Value.ToString();
                d17 = AttendanceGrid.Rows[j].Cells["17"].Value.ToString();
                d18 = AttendanceGrid.Rows[j].Cells["18"].Value.ToString();
                d19 = AttendanceGrid.Rows[j].Cells["19"].Value.ToString();

                d20 = AttendanceGrid.Rows[j].Cells["20"].Value.ToString();

                d21 = AttendanceGrid.Rows[j].Cells["21"].Value.ToString();
                d22 = AttendanceGrid.Rows[j].Cells["22"].Value.ToString();
                d23 = AttendanceGrid.Rows[j].Cells["23"].Value.ToString();
                d24 = AttendanceGrid.Rows[j].Cells["24"].Value.ToString();
                d25 = AttendanceGrid.Rows[j].Cells["25"].Value.ToString();
                d26 = AttendanceGrid.Rows[j].Cells["26"].Value.ToString();
                d27 = AttendanceGrid.Rows[j].Cells["27"].Value.ToString();
                d28 = AttendanceGrid.Rows[j].Cells["28"].Value.ToString();

                if (NumberOfDays == 29)
                {
                    d29 = AttendanceGrid.Rows[j].Cells["29"].Value.ToString();
                    d30 = "";
                    d31 = "";
                }
                if (NumberOfDays == 30)
                {
                    d29 = AttendanceGrid.Rows[j].Cells["29"].Value.ToString();
                    d30 = AttendanceGrid.Rows[j].Cells["30"].Value.ToString();
                    d31 = "";
                }
                if (NumberOfDays == 31)
                {
                    d29 = AttendanceGrid.Rows[j].Cells["29"].Value.ToString();
                    d30 = AttendanceGrid.Rows[j].Cells["30"].Value.ToString();
                    d31 = AttendanceGrid.Rows[j].Cells["31"].Value.ToString();
                }

                //=======================================================================
                //AttendanceGrid.Rows[j].Cells[3].Value 
                //for (int Cnt = 1; Cnt <= NumberOfDays; Cnt++)
                //{


                //}
                //slno, eid, MOD, Wday, Absent, Proxy, Season, Month, Location_ID, Company_id, Desgid, status, edate, sfid, sno, days_wd, days_ot,apply_hrs_wd, apply_hrs_ot, lv_earn, lv_adj, lv_pbal, ed, woff, cWD, days_ed, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15, d16, d17, d18, d19, d20, d21, d22, d23, d24, d25, d26, d27, d28, d29, d30, d31
                if (j == 0)
                {
                    Sql = Sql + "('" + (j + 1) + "','" + eid + "','" + MOD + "','" + Wday + "','" + Absent + "','" + Proxy + "','" + Season + "','" + Month + "','" + Location_ID + "','" + Company_id + "','" + Desgid + "','0','" + DateTime.Now.ToString("dd/MMM/yyyy") + "','" + Hol + "','0','" + days_wd + "','" + days_ot + "','0','0','0','0','0','0','"+WO+"','0','0','" + d1 + "','" + d2 + "','" + d3 + "','" + d4 + "','" + d5 + "','" + d6 + "','" + d7 + "','" + d8 + "','" + d9 + "','" + d10 + "','" + d11 + "','" + d12 + "','" + d13 + "','" + d14 + "','" + d15 + "','" + d16 + "','" + d17 + "','" + d18 + "','" + d19 + "','" + d20 + "','" + d21 + "','" + d22 + "','" + d23 + "','" + d24 + "','" + d25 + "','" + d26 + "','" + d27 + "','" + d28 + "','" + d29 + "','" + d30 + "','" + d31 + "')";

                }
                else
                {
                    Sql = Sql + ", ('" + (j + 1) + "','" + eid + "','" + MOD + "','" + Wday + "','" + Absent + "','" + Proxy + "','" + Season + "','" + Month + "','" + Location_ID + "','" + Company_id + "','" + Desgid + "','0','" + DateTime.Now.ToString("dd/MMM/yyyy") + "','" + Hol + "','0','" + days_wd + "','" + days_ot + "','0','0','0','0','0','0','" + WO + "','0','0','" + d1 + "','" + d2 + "','" + d3 + "','" + d4 + "','" + d5 + "','" + d6 + "','" + d7 + "','" + d8 + "','" + d9 + "','" + d10 + "','" + d11 + "','" + d12 + "','" + d13 + "','" + d14 + "','" + d15 + "','" + d16 + "','" + d17 + "','" + d18 + "','" + d19 + "','" + d20 + "','" + d21 + "','" + d22 + "','" + d23 + "','" + d24 + "','" + d25 + "','" + d26 + "','" + d27 + "','" + d28 + "','" + d29 + "','" + d30 + "','" + d31 + "')";

                }

            }
            bool bl = clsDataAccess.RunNQwithStatus(Sql.ToUpper().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A"));


            if (bl == true)
            {

                MessageBox.Show("Daily Attendance confirmed", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cmbOption.SelectedIndex == 2)
                {
                    btnExcel.Text = "Save & Export / Preview";
                    expExcel();
                    printPview(0);
                }
                else if (cmbOption.SelectedIndex == 1)
                {
                    btnExcel.Text = "Save and Preview";
                    printPview(0);
                }
                else
                {
                    btnExcel.Text = "Save and Export to Excel";
                    expExcel();
                }
            }

        }
        public void expExcel()
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            int iCol = 0, cCol = AttendanceGrid.Columns.Count, hCol = Convert.ToInt32(cCol / 2);

            excel.Cells[1, 1] = "MUSTER ROLL";
            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, cCol]);
            range.Font.Bold = true;
            range.Merge(true);

            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[2, 1] = "Form - XVI";
            //+Environment.NewLine+"[See Rule 78(1)(a)(ii)]";
            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, cCol]);
            range.Font.Bold = true;
            range.Merge(true);

            excel.Cells[3, 1] = "[See Rule 78(1)(a)(ii)]";
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, cCol]);
            range.Merge(true);


            excel.Cells[4, 1] = "Name & Address of Contractor : ";
            range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, 3]);
            range.Font.Bold = true;
            range.Merge(true);

            excel.Cells[5, 1] = "";
            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, 3]);
            range.Merge(true);

            excel.Cells[4, 4] = clsDataAccess.ReturnValue("select CO_NAME from Company where GCODE=" + lblCoid.Text);
            range = worksheet.get_Range(worksheet.Cells[4, 4], worksheet.Cells[4, Convert.ToInt32(cCol / 2)]);
            range.Merge(true);
            range.WrapText = true;
            range.Rows.AutoFit();

            excel.Cells[5, 4] = clsDataAccess.ReturnValue("select CO_ADD from Company where GCODE=" + lblCoid.Text);
            range = worksheet.get_Range(worksheet.Cells[5, 4], worksheet.Cells[5, Convert.ToInt32(cCol / 2)]);
            range.Merge(true);
            range.WrapText = true;
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;//System.Web.UI.WebControls.VerticalAlign.Top;
            range.Rows.AutoFit();
            range.RowHeight = 65;

            excel.Cells[4, Convert.ToInt32(cCol / 2) + 1] = "Name & Address of Principle Employer : ";
            range = worksheet.get_Range(worksheet.Cells[4, hCol + 1], worksheet.Cells[4, hCol + 11]);
            range.Font.Bold = true;
            range.Merge(true);

            excel.Cells[5, Convert.ToInt32(cCol / 2) + 1] = "";
            range = worksheet.get_Range(worksheet.Cells[5, hCol + 1], worksheet.Cells[5, hCol + 11]);
            range.Merge(true);


            excel.Cells[4, hCol + 12] = clsDataAccess.ReturnValue("select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) as ClientName from tbl_Emp_Location EL where Location_ID =" + cmblocation.ReturnValue.Trim());
            range = worksheet.get_Range(worksheet.Cells[4, hCol + 12], worksheet.Cells[4, cCol]);
            range.Merge(true);
            range.WrapText = true;
            range.Rows.AutoFit();

            excel.Cells[5, hCol + 12] = clsDataAccess.ReturnValue("Select (SELECT Client_ADD1 FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=" + cmblocation.ReturnValue.Trim());
            range = worksheet.get_Range(worksheet.Cells[5, hCol + 12], worksheet.Cells[5, cCol]);
            range.Merge(true);
            range.WrapText = true;
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;//System.Web.UI.WebControls.VerticalAlign.Top;
            range.Rows.AutoFit();
            range.RowHeight = 65;

            excel.Cells[6, 1] = "Nature & Location of Work : " + cmblocation.Text.ToString().Trim();
            range = worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[6, cCol - 11]);
            range.Font.Bold = true;
            range.Merge(true);

            excel.Cells[6, cCol - 10] = "Wages Period : " + AttenDtTmPkr.Value.ToString("MMMM-yyyy");
            range = worksheet.get_Range(worksheet.Cells[6, cCol - 10], worksheet.Cells[6, cCol]);
            range.Font.Bold = true;
            range.Merge(true);

            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            

            iCol = 0;
            for (int c = 0; c < this.AttendanceGrid.Columns.Count - 1; c++)
            {
                iCol++;
                if (AttendanceGrid.Columns[c].HeaderText == "WOff")
                {
                    excel.Cells[7, iCol] = "WOff";
                    iCol++;
                    excel.Cells[7, iCol] = "Holiday";
                }
                else
                {
                    excel.Cells[7, iCol] = AttendanceGrid.Columns[c].HeaderText;

                }
            }
            range = worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[7, cCol]);
            range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();
            DataTable HoliDayDtbl = HolidayList();
            double WD = 0, WOff = 0, Abs = 0, Total = 0, hol = 0, thol = 0;
            int iRow = 7;
            for (int r = 0; r < this.AttendanceGrid.Rows.Count; r++)
            {
                iRow++;
                iCol = 0;
                //WOff = 0;
                hol = 0;
                for (int c = 0; c < this.AttendanceGrid.Columns.Count - 1; c++)
                {
                    try
                    {
                        iCol++;
                        if (AttendanceGrid.Columns[c].HeaderText == "WD" || AttendanceGrid.Columns[c].HeaderText == "WOff" || AttendanceGrid.Columns[c].HeaderText == "Abs" || AttendanceGrid.Columns[c].HeaderText == "Total")
                        {

                            if (AttendanceGrid.Columns[c].HeaderText == "WD")
                            {
                                WD = WD + (Convert.ToDouble(AttendanceGrid.Rows[r].Cells["WD"].Value));
                                excel.Cells[iRow, iCol] = (Convert.ToDouble(AttendanceGrid.Rows[r].Cells["WD"].Value));
                            }
                            else if (AttendanceGrid.Columns[c].HeaderText == "WOff")
                            {
                                WOff = WOff + Convert.ToDouble(AttendanceGrid.Rows[r].Cells["WOff"].Value);
                                excel.Cells[iRow, iCol] = AttendanceGrid.Rows[r].Cells["WOff"].Value;
                                //c++;
                                iCol++;
                                //hol = hol + Convert.ToDouble(AttendanceGrid.Rows[r].Cells[c].Value);
                                excel.Cells[iRow, iCol] = hol;//AttendanceGrid.Rows[r].Cells[c].Value;
                                thol = thol + hol;
                            }
                            else if (AttendanceGrid.Columns[c].HeaderText == "Abs")
                            {
                                Abs = Abs + Convert.ToDouble(AttendanceGrid.Rows[r].Cells["TotalAbsent"].Value);
                                excel.Cells[iRow, iCol] = AttendanceGrid.Rows[r].Cells["TotalAbsent"].Value;
                            }
                            else if (AttendanceGrid.Columns[c].HeaderText == "Total")
                            {

                                Total = Total + Convert.ToDouble(AttendanceGrid.Rows[r].Cells["TotalDaysWorked"].Value);
                                excel.Cells[iRow, iCol] = AttendanceGrid.Rows[r].Cells["TotalDaysWorked"].Value;
                            }



                            //  excel.Cells[iRow, iCol] = AttendanceGrid.Rows[r].Cells[c].Value;

                        }
                        else
                        {
                            if (iCol >= 4)
                            {

                                excel.Cells[iRow, iCol] = "'" + AttendanceGrid.Rows[r].Cells[c].Value.ToString().Trim().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A");


                                try
                                {
                                    string AttenDate;
                                    AttenDate = Convert.ToDateTime(DatePatern(Convert.ToInt32(AttendanceGrid.Columns[c].HeaderText), AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());

                                    if (DateAndTime.WeekdayName(DateAndTime.Weekday(Convert.ToDateTime(AttenDate), FirstDayOfWeek.Monday), false, FirstDayOfWeek.Monday) == "Sunday")
                                    {
                                        range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                        range.Font.Bold = true;
                                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
                                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                                    }
                                    else if (SearchHoliday(HoliDayDtbl, Convert.ToInt32(AttendanceGrid.Columns[c].HeaderText)) == true)
                                    {
                                        range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                        range.Font.Bold = true;
                                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
                                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                                        hol = hol + 1;
                                    }
                                    else if (AttendanceGrid.Rows[r].Cells[c].Value.ToString().Trim().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A").Trim().ToUpper() == "A")
                                    {
                                        range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                        range.Font.Bold = true;
                                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                                    }
                                    else if (AttendanceGrid.Rows[r].Cells[c].Value.ToString().Trim().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A").Trim().ToUpper() == "H")
                                    {
                                        range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                        range.Font.Bold = true;
                                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
                                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                                        hol = hol + 1;
                                    }
                                }
                                catch { }
                            }
                            else
                            {
                                excel.Cells[iRow, iCol] = "'" + AttendanceGrid.Rows[r].Cells[c].Value.ToString().Trim().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A");
                                if (AttendanceGrid.Rows[r].Cells[c].Value.ToString().Trim().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A").Trim().ToUpper() == "A")
                                {
                                    range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                    range.Font.Bold = true;
                                    range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                                }
                                else if (AttendanceGrid.Rows[r].Cells[c].Value.ToString().Trim().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A").Trim().ToUpper() == "H")
                                {
                                    range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                    range.Font.Bold = true;
                                    range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
                                    range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                                    hol = hol + 1;

                                }
                            }

                        }

                    }
                    catch
                    {

                    }
                }
            }
            //----------------grand Total-------------------------------------------------------------------------
            iCol = 0;
            iRow++;
            for (int c = 0; c < this.AttendanceGrid.Columns.Count; c++)
            {
                iCol++;
                if (AttendanceGrid.Columns[c].HeaderText == "WD" || AttendanceGrid.Columns[c].HeaderText == "WOff" || AttendanceGrid.Columns[c].HeaderText == "Abs" || AttendanceGrid.Columns[c].HeaderText == "Total")
                {

                    if (AttendanceGrid.Columns[c].HeaderText == "WD")
                    {
                        excel.Cells[iRow, iCol] = WD;
                    }
                    if (AttendanceGrid.Columns[c].HeaderText == "WOff")
                    {
                        excel.Cells[iRow, iCol] = WOff;
                        iCol++;
                        //c++;
                        excel.Cells[iRow, iCol] = thol;
                    }
                    if (AttendanceGrid.Columns[c].HeaderText == "Abs")
                    {
                        excel.Cells[iRow, iCol] = Abs;
                    }
                    if (AttendanceGrid.Columns[c].HeaderText == "Total")
                    {

                        excel.Cells[iRow, iCol] = Total;
                    }


                }
                else if (AttendanceGrid.Columns[c].HeaderText == "Employee Name")
                {
                    excel.Cells[iRow, iCol] = "TOTAL : ";

                }
            }
            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[iRow, cCol]);
            range.BorderAround(Excel.XlLineStyle.xlContinuous,
    Excel.XlBorderWeight.xlThin,
    Excel.XlColorIndex.xlColorIndexNone,
    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
            Excel.Borders borders = range.Borders;
            //Set the thick lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 2d;
            //range.WrapText = true;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            excel.Cells[iRow + 1, 2] = "";
            range = worksheet.get_Range(worksheet.Cells[iRow + 1, 2], worksheet.Cells[iRow + 4, hCol]);
            range.Merge(true);

            excel.Cells[iRow + 5, 2] = "SIGNATURE OF UNIT INCHARGE";
            range = worksheet.get_Range(worksheet.Cells[iRow + 5, 2], worksheet.Cells[iRow + 5, hCol]);
            range.Merge(true);
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;


            range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            range.Columns.AutoFit();
            //range.Rows.AutoFit();


            excel.Cells[iRow + 1, hCol + 1] = "";
            range = worksheet.get_Range(worksheet.Cells[iRow + 1, hCol + 1], worksheet.Cells[iRow + 4, cCol]);
            range.Merge(true);

            excel.Cells[iRow + 5, hCol + 1] = "SIGNATURE OF CUSTOMER";
            range = worksheet.get_Range(worksheet.Cells[iRow + 5, hCol + 1], worksheet.Cells[iRow + 5, cCol]);
            range.Merge(true);
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Font.Bold = true;

            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            //range.Rows.AutoFit();


            excel.Cells[iRow + 6, 2] = "SUNDAYS";
            range = worksheet.get_Range(worksheet.Cells[iRow + 6, 2], worksheet.Cells[iRow + 6, 2]);
            range.Font.Bold = true;
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
            range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

            excel.Cells[iRow + 7, 2] = "HOLIDAYS";
            range = worksheet.get_Range(worksheet.Cells[iRow + 7, 2], worksheet.Cells[iRow + 7, 2]);
            range.Font.Bold = true;
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
            range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);


            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();

            ((Excel._Application)excel).Quit();

            MessageBox.Show("Export To ExcelCompleted!", "Export");

        }

        public void printPview(int ft)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select (select CO_NAME from Company where GCODE=ead.Company_id)as 'company'," +
             "(select CO_ADD from Company where GCODE=ead.Company_id)as 'coadd'," +
             "(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=ead.Location_ID) as 'client'," +
             "(select (SELECT Client_ADD1 FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=ead.Location_ID) as 'clientadd'," +
             "(select Location_Name from tbl_Emp_Location EL where Location_ID=ead.Location_ID) as 'location','" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "' as 'month',eid," +
             "((SELECT Distinct (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS ename FROM tbl_Employee_Mast WHERE (ID = ead.eid)))as 'ename'," +
             "((SELECT Distinct (CASE WHEN ltrim(rtrim(FathFN)) != '' THEN FathFN ELSE '' END) + (CASE WHEN ltrim(rtrim(FathMN)) != '' THEN ' ' + FathMN ELSE '' END) + (CASE WHEN ltrim(rtrim(FathLN)) != '' THEN ' ' + FathLN ELSE '' END) AS ename FROM tbl_Employee_Mast WHERE (ID = ead.eid)))as 'fathername'," +
             "d1,d2,d3,d4,d5,d6,d7,d8,d9,d10,d11,d12,d13,d14,d15,d16,d17,d18,d19,d20,d21,d22,d23,d24,d25,d26,d27,d28,d29,d30,d31,(Wday- Proxy) as 'tdays'," +
             "(SELECT Distinct LEFT(Gender, 1) FROM tbl_Employee_Mast WHERE (ID = ead.eid))'Sex'," +
             "(select DesignationName from tbl_Employee_DesignationMaster where SlNo=ead.Desgid)'Nature'," +
             "(select sign from Company where GCODE=ead.Company_id)'cosign' from tbl_Employee_Attend_daily ead where (MONTH='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') and (Location_ID='" + Location_ID + "') order by 'ename'");
            DataTable dt2 = clsDataAccess.RunQDTbl("select sign from Company where GCODE=1");
            string stot = clsDataAccess.GetresultS("select sum(Wday) as 'tdays'" +
           " from tbl_Employee_Attend_daily ead where (MONTH='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') and (Location_ID='" + Location_ID + "') Group by Location_ID");
            //dt.Merge(dt1);

            dt.Rows.Add();
            int idx = dt.Rows.Count - 1;

            dt.Rows[idx]["ename"] = "Total :";
            dt.Rows[idx]["tdays"] = stot;
            dt.Rows[idx]["cosign"] = dt.Rows[0]["cosign"];
            MidasReport.Form1 f1 = new MidasReport.Form1();
            if (ft == 0)
            {
                f1.attn_daily(dt, NumberOfDays, dt2);
                f1.ShowDialog();
            }
            else if (ft == 1)
            {
                f1.attn_daily_exp(dt, NumberOfDays, dt2, lbl_path.Text + fname + ".pdf");
            }

        }

        private void btnRecheck_Click(object sender, EventArgs e)
        {
            rcheck();
        }

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOption.SelectedIndex == 2)
            {
                btnExcel.Text = "Save & Export / Preview";
            }
            else if (cmbOption.SelectedIndex == 1)
            {
                btnExcel.Text = "Save and Preview";

            }
            else
            {
                btnExcel.Text = "Save and Export to Excel";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                lbl_path.Text = folderBrowserDialog1.SelectedPath + "\\";
                path = lbl_path.Text.Trim() + "\\Log" + System.DateTime.Now.Day + System.DateTime.Now.Month + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".txt";

            }
            expExcel_blnk();
           // printPview(1);
        }

        public bool Rechk_data(string ecode, int idx)
        {
            int dbl = 0;
            bool rc = false;
            try
            {
                foreach (DataGridViewRow row in AttendanceGrid.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(ecode))
                    {
                        dbl += 1;
                        //MessageBox.Show("Name " + row.Cells[1].Value.ToString() + " already exist, Check Row : " + (idx + 1), "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (dbl > 1)
                        {
                            rc = true;
                            break;
                        }
                    }
                }
            }
            catch
            {

            }

            return rc;
        }


        public void expExcel_blnk()
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            Excel.Range range;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            int iCol = 0, cCol = AttendanceGrid.Columns.Count, hCol = Convert.ToInt32(cCol / 2);
            object missing = System.Reflection.Missing.Value;

            iCol = 0;


            fname = cmblocation.Text.Trim().Replace(" ", "_") + "_daily_" + Location_ID + "_" + AttenDtTmPkr.Value.ToString("MMM_yyyy") + "_as_on_" + DateTime.Now.ToString("dd_mm_yy_hh_mm_ss_tt");

            for (int c = 0; c < this.AttendanceGrid.Columns.Count - 1; c++)
            {
                iCol++;
                if (AttendanceGrid.Columns[c].HeaderText == "WOff")
                {
                    excel.Cells[1, iCol] = "WOff";
                    iCol++;
                    excel.Cells[1, iCol] = "Holiday";
                }
                else
                {
                    excel.Cells[1, iCol] = AttendanceGrid.Columns[c].HeaderText;

                }
            }
            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, cCol]);
            range.EntireRow.Hidden = true;

            excel.Cells[2, 1] = "MUSTER ROLL";
            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, cCol]);
            range.Font.Bold = true;
            range.Merge(true);

            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[3, 1] = "Form - XVI";
            //+Environment.NewLine+"[See Rule 78(1)(a)(ii)]";
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, cCol]);
            range.Font.Bold = true;
            range.Merge(true);

            excel.Cells[4, 1] = "[See Rule 78(1)(a)(ii)]";
            range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, cCol]);
            range.Merge(true);


            excel.Cells[5, 1] = "Name & Address of Contractor : ";
            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, 3]);
            range.Font.Bold = true;
            range.Merge(true);

            excel.Cells[6, 1] = cmblocation.ReturnValue;
            range = worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[6, 3]);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            range.Merge(true);

            excel.Cells[5, 4] = clsDataAccess.ReturnValue("select CO_NAME from Company where GCODE=" + lblCoid.Text);
            range = worksheet.get_Range(worksheet.Cells[5, 4], worksheet.Cells[5, Convert.ToInt32(cCol / 2)]);
            range.Merge(true);
            range.WrapText = true;
            range.Rows.AutoFit();

            excel.Cells[6, 4] = clsDataAccess.ReturnValue("select CO_ADD from Company where GCODE=" + lblCoid.Text);
            range = worksheet.get_Range(worksheet.Cells[6, 4], worksheet.Cells[6, Convert.ToInt32(cCol / 2)]);
            range.Merge(true);
            range.WrapText = true;
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;//System.Web.UI.WebControls.VerticalAlign.Top;
            range.Rows.AutoFit();
            range.RowHeight = 65;

            excel.Cells[5, Convert.ToInt32(cCol / 2) + 1] = "Name & Address of Principle Employer : ";
            range = worksheet.get_Range(worksheet.Cells[5, hCol + 1], worksheet.Cells[5, hCol + 11]);
            range.Font.Bold = true;
            range.Merge(true);

            excel.Cells[6, Convert.ToInt32(cCol / 2) + 1] = "";
            range = worksheet.get_Range(worksheet.Cells[6, hCol + 1], worksheet.Cells[6, hCol + 11]);
            range.Merge(true);


            excel.Cells[5, hCol + 12] = clsDataAccess.ReturnValue("select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) as ClientName from tbl_Emp_Location EL where Location_ID =" + cmblocation.ReturnValue.Trim());
            range = worksheet.get_Range(worksheet.Cells[5, hCol + 12], worksheet.Cells[5, cCol]);
            range.Merge(true);
            range.WrapText = true;
            range.Rows.AutoFit();

            excel.Cells[6, hCol + 12] = clsDataAccess.ReturnValue("Select (SELECT Client_ADD1 FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=" + cmblocation.ReturnValue.Trim());
            range = worksheet.get_Range(worksheet.Cells[6, hCol + 12], worksheet.Cells[6, cCol]);
            range.Merge(true);
            range.WrapText = true;
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;//System.Web.UI.WebControls.VerticalAlign.Top;
            range.Rows.AutoFit();
            range.RowHeight = 65;

            excel.Cells[7, 1] = "Nature & Location of Work : " + cmblocation.Text.ToString().Trim();
            range = worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[7, cCol - 11]);
            range.Font.Bold = true;
            range.Merge(true);

            excel.Cells[7, cCol - 10] = "Wages Period : " + AttenDtTmPkr.Value.ToString("MMMM-yyyy");
            range = worksheet.get_Range(worksheet.Cells[7, cCol - 10], worksheet.Cells[7, cCol]);
            range.Font.Bold = true;
            range.Merge(true);

            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();




            iCol = 0;
            for (int c = 0; c < this.AttendanceGrid.Columns.Count - 1; c++)
            {
                iCol++;
                if (AttendanceGrid.Columns[c].HeaderText == "WOff")
                {
                    excel.Cells[8, iCol] = "WOff";
                    iCol++;
                    excel.Cells[8, iCol] = "Holiday";
                }
                else
                {
                    excel.Cells[8, iCol] = AttendanceGrid.Columns[c].HeaderText;

                }
            }
            range = worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[8, cCol]);
            range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();

            DataTable HoliDayDtbl = HolidayList();
            double WD = 0, WOff = 0, Abs = 0, Total = 0, hol = 0, thol = 0;
            int iRow = 8;
            for (int r = 0; r < this.AttendanceGrid.Rows.Count; r++)
            {
                iRow++;
                iCol = 0;
                //WOff = 0;
                hol = 0;
                for (int c = 0; c < this.AttendanceGrid.Columns.Count - 1; c++)
                {
                    try
                    {
                        iCol++;
                        if (AttendanceGrid.Columns[c].HeaderText == "WD" || AttendanceGrid.Columns[c].HeaderText == "WOff" || AttendanceGrid.Columns[c].HeaderText == "Abs" || AttendanceGrid.Columns[c].HeaderText == "Total")
                        {

                            if (AttendanceGrid.Columns[c].HeaderText == "WD")
                            {
                                WD = WD + (Convert.ToDouble(AttendanceGrid.Rows[r].Cells["WD"].Value));
                                excel.Cells[iRow, iCol] = (Convert.ToDouble(AttendanceGrid.Rows[r].Cells["WD"].Value));
                            }
                            else if (AttendanceGrid.Columns[c].HeaderText == "WOff")
                            {
                                WOff = WOff + Convert.ToDouble(AttendanceGrid.Rows[r].Cells["WOff"].Value);
                                excel.Cells[iRow, iCol] = AttendanceGrid.Rows[r].Cells["WOff"].Value;
                                //c++;
                                iCol++;
                                //hol = hol + Convert.ToDouble(AttendanceGrid.Rows[r].Cells[c].Value);
                                excel.Cells[iRow, iCol] = hol;//AttendanceGrid.Rows[r].Cells[c].Value;
                                thol = thol + hol;
                            }
                            else if (AttendanceGrid.Columns[c].HeaderText == "Abs")
                            {
                                Abs = Abs + Convert.ToDouble(AttendanceGrid.Rows[r].Cells["TotalAbsent"].Value);
                                excel.Cells[iRow, iCol] = AttendanceGrid.Rows[r].Cells["TotalAbsent"].Value;
                            }
                            else if (AttendanceGrid.Columns[c].HeaderText == "Total")
                            {

                                Total = Total + Convert.ToDouble(AttendanceGrid.Rows[r].Cells["TotalDaysWorked"].Value);
                                excel.Cells[iRow, iCol] = AttendanceGrid.Rows[r].Cells["TotalDaysWorked"].Value;
                            }



                            //  excel.Cells[iRow, iCol] = AttendanceGrid.Rows[r].Cells[c].Value;

                        }
                        else
                        {
                            if (iCol >= 4)
                            {

                                excel.Cells[iRow, iCol] = "'" + AttendanceGrid.Rows[r].Cells[c].Value.ToString().Trim().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A");


                                try
                                {
                                    string AttenDate;
                                    AttenDate = Convert.ToDateTime(DatePatern(Convert.ToInt32(AttendanceGrid.Columns[c].HeaderText), AttenDtTmPkr.Value.Month, AttenDtTmPkr.Value.Year)).ToString(DatePatern());

                                    if (DateAndTime.WeekdayName(DateAndTime.Weekday(Convert.ToDateTime(AttenDate), FirstDayOfWeek.Monday), false, FirstDayOfWeek.Monday) == "Sunday")
                                    {
                                        range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                        range.Font.Bold = true;
                                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
                                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                                    }
                                    else if (SearchHoliday(HoliDayDtbl, Convert.ToInt32(AttendanceGrid.Columns[c].HeaderText)) == true)
                                    {
                                        range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                        range.Font.Bold = true;
                                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
                                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                                        hol = hol + 1;
                                    }
                                    else if (AttendanceGrid.Rows[r].Cells[c].Value.ToString().Trim().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A").Trim().ToUpper() == "A")
                                    {
                                        range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                        range.Font.Bold = true;
                                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                                    }
                                    else if (AttendanceGrid.Rows[r].Cells[c].Value.ToString().Trim().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A").Trim().ToUpper() == "H")
                                    {
                                        range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                        range.Font.Bold = true;
                                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
                                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                                        hol = hol + 1;
                                    }
                                }
                                catch { }
                            }
                            else
                            {
                                excel.Cells[iRow, iCol] = "'" + AttendanceGrid.Rows[r].Cells[c].Value.ToString().Trim().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A");
                                if (AttendanceGrid.Rows[r].Cells[c].Value.ToString().Trim().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A").Trim().ToUpper() == "A")
                                {
                                    range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                    range.Font.Bold = true;
                                    range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                                }
                                else if (AttendanceGrid.Rows[r].Cells[c].Value.ToString().Trim().Replace("A +________________+ A", "A").Replace("AB +________________+ AB", "A").Trim().ToUpper() == "H")
                                {
                                    range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                    range.Font.Bold = true;
                                    range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
                                    range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                                    hol = hol + 1;

                                }
                            }

                        }

                    }
                    catch
                    {

                    }
                }
            }
            //----------------grand Total-------------------------------------------------------------------------
            iCol = 0;
            iRow++;
            for (int c = 0; c < this.AttendanceGrid.Columns.Count; c++)
            {
                iCol++;
                if (AttendanceGrid.Columns[c].HeaderText == "WD" || AttendanceGrid.Columns[c].HeaderText == "WOff" || AttendanceGrid.Columns[c].HeaderText == "Abs" || AttendanceGrid.Columns[c].HeaderText == "Total")
                {

                    if (AttendanceGrid.Columns[c].HeaderText == "WD")
                    {
                        excel.Cells[iRow, iCol] = WD;
                    }
                    if (AttendanceGrid.Columns[c].HeaderText == "WOff")
                    {
                        excel.Cells[iRow, iCol] = WOff;
                        iCol++;
                        //c++;
                        excel.Cells[iRow, iCol] = thol;
                    }
                    if (AttendanceGrid.Columns[c].HeaderText == "Abs")
                    {
                        excel.Cells[iRow, iCol] = Abs;
                    }
                    if (AttendanceGrid.Columns[c].HeaderText == "Total")
                    {

                        excel.Cells[iRow, iCol] = Total;
                    }


                }
                else if (AttendanceGrid.Columns[c].HeaderText == "Employee Name")
                {
                    excel.Cells[iRow, iCol] = "TOTAL : ";

                }
            }
            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[iRow, cCol]);
            range.BorderAround(Excel.XlLineStyle.xlContinuous,
    Excel.XlBorderWeight.xlThin,
    Excel.XlColorIndex.xlColorIndexNone,
    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
            Excel.Borders borders = range.Borders;
            //Set the thick lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 2d;
            //range.WrapText = true;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            excel.Cells[iRow + 1, 2] = "";
            range = worksheet.get_Range(worksheet.Cells[iRow + 1, 2], worksheet.Cells[iRow + 4, hCol]);
            range.Merge(true);

            excel.Cells[iRow + 5, 2] = "SIGNATURE OF UNIT INCHARGE";
            range = worksheet.get_Range(worksheet.Cells[iRow + 5, 2], worksheet.Cells[iRow + 5, hCol]);
            range.Merge(true);
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;


            range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            range.Columns.AutoFit();
            //range.Rows.AutoFit();


            excel.Cells[iRow + 1, hCol + 1] = "";
            range = worksheet.get_Range(worksheet.Cells[iRow + 1, hCol + 1], worksheet.Cells[iRow + 4, cCol]);
            range.Merge(true);

            excel.Cells[iRow + 5, hCol + 1] = "SIGNATURE OF CUSTOMER";
            range = worksheet.get_Range(worksheet.Cells[iRow + 5, hCol + 1], worksheet.Cells[iRow + 5, cCol]);
            range.Merge(true);
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Font.Bold = true;

            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            //range.Rows.AutoFit();


            excel.Cells[iRow + 6, 2] = "SUNDAYS";
            range = worksheet.get_Range(worksheet.Cells[iRow + 6, 2], worksheet.Cells[iRow + 6, 2]);
            range.Font.Bold = true;
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
            range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

            excel.Cells[iRow + 7, 2] = "HOLIDAYS";
            range = worksheet.get_Range(worksheet.Cells[iRow + 7, 2], worksheet.Cells[iRow + 7, 2]);
            range.Font.Bold = true;
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
            range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

            ((Excel._Worksheet)worksheet).SaveAs(lbl_path.Text + fname + ".xlsx", missing, missing, missing, false, missing, missing, missing, missing);

            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();

            ((Excel._Application)excel).Quit();

            MessageBox.Show("Export To ExcelCompleted!", "Export");

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            string extension = Path.GetExtension(filePath);
            string conStr = string.Empty, header = "YES", sheetName = "";
            lbl_Log.Text = "";
            string co =clsDataAccess.ReturnValue("select CO_NAME from Company where GCODE=" + lblCoid.Text);
            lbl_path.Text = filePath.Substring(0, filePath.LastIndexOf("\\"));
            path = lbl_path.Text.Trim() + "\\Log" + System.DateTime.Now.Day + System.DateTime.Now.Month + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".txt";

            if (!File.Exists(path))
            {
                //File.Create(path);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                using (var tw = new StreamWriter(fs))
                {
                    tw.WriteLine("#Company: " + co.Trim());
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
                            
                            int ix = 0;
                            
                            string ecode, chkName = "", ename, SHIFT, SftID, desg, desgid, wd, ot, ed, wo, abs, locid,hol;
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                            {

                                if (dt.Rows[4][0].ToString().Trim() != Location_ID.ToString().Trim())
                                {
                                    MessageBox.Show("Selected Location not matched with excel location", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    file.WriteLine("Selected Location not matched with excel location");
                                    lbl_Log.Text = "Selected Location(" + Location_ID + ") not matched with excel location (" + dt.Rows[4][0].ToString().Trim() + ")";
                                }
                                //AttendanceGrid.Rows.Clear();
                                dt.Rows.RemoveAt(6);
                                dt.Rows.RemoveAt(5);
                                dt.Rows.RemoveAt(4);
                                dt.Rows.RemoveAt(3);
                                dt.Rows.RemoveAt(2);
                                dt.Rows.RemoveAt(1);
                                dt.Rows.RemoveAt(0);

                                try
                                {

                                }
                                catch { }

                                int ind = dt.Rows.Count-1;


                                try
                                {
                                    dt.Rows.RemoveAt(ind);
                                    dt.Rows.RemoveAt(ind-1);
                                    dt.Rows.RemoveAt(ind-2);
                                    dt.Rows.RemoveAt(ind-3);
                                    dt.Rows.RemoveAt(ind-4);
                                    dt.Rows.RemoveAt(ind-5);
                                    dt.Rows.RemoveAt(ind-6);
                                    dt.Rows.RemoveAt(ind-7);

                                }
                                catch { }

                                try
                                {
                                    AttendanceGrid.DataSource = dt;
                                }
                                catch { }

                                for (int idx = 0; idx < dt.Rows.Count; idx++)
                                {
                                    ecode = dt.Rows[idx]["ID"].ToString().Trim();

                                    ename = dt.Rows[idx]["EMPLOYEE NAME"].ToString().Trim();

                                    try
                                    {
                                        chkName = clsDataAccess.ReturnValue("SELECT (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + " +
                                            "(CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + " +
                                            "(CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS EName FROM tbl_Employee_Mast AS em  where (ID='" + ecode.Trim() + "')");

                                    }
                                    catch { chkName = ""; }

                                    desg = dt.Rows[idx]["EMPLOYEE DESIGNATION"].ToString().Trim();
                                    desgid = clsDataAccess.ReturnValue("SELECT SlNo from tbl_Employee_DesignationMaster where (DesignationName='" + desg + "')");
                                    //SHIFT = dt.Rows[idx]["SHIFT"].ToString().Trim();
                                    //SftID = clsDataAccess.ReturnValue("select sid from tbl_shift where (sname='" + SHIFT + "')");
                                    wd = dt.Rows[idx]["WD"].ToString().Trim();
                                    ot = dt.Rows[idx]["PROXY"].ToString().Trim();
                                    hol = dt.Rows[idx]["Holiday"].ToString().Trim();
                                    wo = dt.Rows[idx]["WOff"].ToString().Trim();
                                    abs = dt.Rows[idx]["Abs"].ToString().Trim();
                                    locid = Location_ID.ToString().Trim();//dt.Rows[idx]["LocID"].ToString().Trim();

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
                                            ind = idx;//AttendanceGrid.Rows.Add();
                                            this.AttendanceGrid.Rows[ind].Cells["ID"].Value = ecode;
                                            this.AttendanceGrid.Rows[ind].Cells["Employee Name"].Value = ename;
                                            this.AttendanceGrid.Rows[ind].Cells["Employee Designation"].Value = desg;
                                            this.AttendanceGrid.Rows[ind].Cells["WD"].Value = wd;
                                            this.AttendanceGrid.Rows[ind].Cells["Proxy"].Value = ot;
                                            
                                            this.AttendanceGrid.Rows[ind].Cells["Woff"].Value = wo;
                                            AttendanceGrid.Rows[ind].Cells["TotalAbsent"].Value = abs;


                                           // AttendanceGrid.Rows[ind].Cells["col_desgid"].Value = desgid;




                                            AttendanceGrid.Rows[ind].Cells["1"].Value = dt.Rows[idx]["1"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["2"].Value = dt.Rows[idx]["2"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["3"].Value = dt.Rows[idx]["3"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["4"].Value = dt.Rows[idx]["4"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["5"].Value = dt.Rows[idx]["5"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["6"].Value = dt.Rows[idx]["6"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["7"].Value = dt.Rows[idx]["7"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["8"].Value = dt.Rows[idx]["8"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["9"].Value = dt.Rows[idx]["9"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["10"].Value = dt.Rows[idx]["10"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["11"].Value = dt.Rows[idx]["11"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["12"].Value = dt.Rows[idx]["12"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["13"].Value = dt.Rows[idx]["13"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["14"].Value = dt.Rows[idx]["14"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["15"].Value = dt.Rows[idx]["15"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["16"].Value = dt.Rows[idx]["16"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["17"].Value = dt.Rows[idx]["17"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["18"].Value = dt.Rows[idx]["18"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["19"].Value = dt.Rows[idx]["19"].ToString().Trim();

                                            AttendanceGrid.Rows[ind].Cells["20"].Value = dt.Rows[idx]["20"].ToString().Trim();

                                            AttendanceGrid.Rows[ind].Cells["21"].Value = dt.Rows[idx]["21"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["22"].Value = dt.Rows[idx]["22"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["23"].Value = dt.Rows[idx]["23"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["24"].Value = dt.Rows[idx]["24"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["25"].Value = dt.Rows[idx]["25"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["26"].Value = dt.Rows[idx]["26"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["27"].Value = dt.Rows[idx]["27"].ToString().Trim();
                                            AttendanceGrid.Rows[ind].Cells["28"].Value = dt.Rows[idx]["28"].ToString().Trim();

                                            if (NumberOfDays == 29)
                                            {
                                                AttendanceGrid.Rows[ind].Cells["29"].Value = dt.Rows[idx]["29"].ToString().Trim();
                                                
                                            }
                                            if (NumberOfDays == 30)
                                            {
                                                AttendanceGrid.Rows[ind].Cells["29"].Value = dt.Rows[idx]["29"].ToString().Trim();
                                                AttendanceGrid.Rows[ind].Cells["30"].Value = dt.Rows[idx]["30"].ToString().Trim();
                                                
                                            }
                                            if (NumberOfDays == 31)
                                            {
                                                AttendanceGrid.Rows[ind].Cells["29"].Value = dt.Rows[idx]["29"].ToString().Trim();
                                                AttendanceGrid.Rows[ind].Cells["30"].Value = dt.Rows[idx]["30"].ToString().Trim();
                                                AttendanceGrid.Rows[ind].Cells["31"].Value = dt.Rows[idx]["31"].ToString().Trim();
                                            }

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

        }// end of sub







    }
}