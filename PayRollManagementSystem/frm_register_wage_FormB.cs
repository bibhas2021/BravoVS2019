using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Collections;
using System.Data.SqlClient;
using Edpcom;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frm_register_wage_FormB : Form
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        string Item_Code = "", Tentry_code = "";
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Frm_Type = "";
        string Location_Name = "";
        int Head_Cou = 0, EHSPOS = 0, DHSPOS = 0;
        string Locations = "", compid = "";
        string Odet = "", Oamt = "", Agent = "";
        TextBoxX.TextBoxX[] txte = new TextBoxX.TextBoxX[32];
        Label[] lbe = new Label[32];
        Label[] lbd = new Label[32];

        ArrayList DeductionHeads = new ArrayList();
        ArrayList EarningHeads = new ArrayList();

        string month = "";

        public frm_register_wage_FormB()
        {
            InitializeComponent();
        }


        public void opt()
        {
            int asign = 0;
            bool lv_col = false;
            try
            {
                asign = Convert.ToInt32(clsDataAccess.GetresultS("select lv from CompanyLimiter"));
            }
            catch
            {
                asign = 0;
            }

            if (asign == 1)
            {
                lv_col = true;
            }
            else
            {
                lv_col = false;
            }
            try
            {
                dgv_show.Columns["Leave.Prev Bal"].Visible = lv_col;
            }
            catch { }
            try
            {
                dgv_show.Columns["Leave.Availed"].Visible = lv_col;
            }
            catch { }
            try
            {
                dgv_show.Columns["Leave.Earned"].Visible = lv_col;
            }
            catch { }
            try
            {
                dgv_show.Columns["Leave.Cur Bal"].Visible = lv_col;
            }
            catch { }


        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Boolean flug_deduction = false;
            int asign = 0;
            month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");
            DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as [SlNo],sm.Emp_Id as [Employee Code],((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END))  as [Employee Name],"+
          "(case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_ID) and (ID=em.ID))) else (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end) as Designation," +
          "isNull((select (Amount) from tbl_Employee_SalaryGross where EmpId=sm.Emp_Id and Location_id=sm.Location_id and Company_id=sm.Company_id and MONTH='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "' and hd='BS' and desgid=(case when sm.desig_id = 0 then (select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_ID) and (ID=sm.emp_id)) else sm.desig_id end)),0)'Rate of Wage.BS'," +
          "isNUll((select (Amount) from tbl_Employee_SalaryGross where (EmpId=sm.Emp_Id) and (Location_id=sm.Location_id) and (Company_id=sm.Company_id) and (MONTH='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "') and (hd='DA') and (desgid=(case when sm.desig_id = 0 then (select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_ID) and (ID=sm.emp_id)) else sm.desig_id end))),0)'Rate of Wage.DA', " +
          "sm.DaysPresent as 'Days worked',sm.OT as 'Overtime',sm.TotalDays as 'Total Days' ,sm.desig_id," +
                "cast(ROUND((sm.[Basic]/sm.[Calculate_day]),2) as numeric(18,2)) as 'col36',cast(sm.TotalSal as Numeric(18,2)) 'Total Earning',cast(sm.TotalDec as Numeric(18,2)) 'Total Deduction',cast(sm.NetPay as Numeric(18,2)) 'Net Pay'" +
                "FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID = sm.Emp_Id");

            if (tot_employ.Rows.Count == 0)
            {
                MessageBox.Show("No Data Present!", "BRAVO");

                return;
            }

            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");


            DataTable salary_details = clsDataAccess.RunQDTbl("select * from (SELECT EmpId,SalId,TableName,Slno,Amount, 0 as Designation_id FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' and TableName<>'tbl_Employer_Contribution' union SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' and TableName<>'tbl_Employer_Contribution') main order by Designation_id,Slno");
            DataView dv = new DataView(salary_details);
            int table_count = tot_employ.Columns.Count;

            int dt_count = tot_employ.Rows.Count;

            int counter = 0;

            for (int i = 0; i < tot_employ.Rows.Count; i++)
            {
                dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["Employee Code"] + "' and Designation_id = '" + tot_employ.Rows[i]["desig_id"] + "'";

                for (int j = 0; j <= dv.Count - 1; j++)
                {
                    if (i == 0)
                    {
                        if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                        {
                            table_count = tot_employ.Columns.Count;
                            flug_deduction = true;
                            counter = j;
                        }

                        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");


                        if (flug_deduction)
                        {
                            Salary_Head = "Deduction." + Salary_Head;
                            DeductionHeads.Add("Deduction." + Salary_Head);
                        }
                        else
                        {
                            Salary_Head = "Earning." + Salary_Head;
                            EarningHeads.Add("Earning." + Salary_Head);
                        }
                        tot_employ.Columns.Add(Salary_Head, typeof(Double));
                        tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                    }
                    else
                    {
                        if (!flug_deduction)
                        {
                           // table_count = tot_employ.Columns.Count;
                            flug_deduction = true;
                        }
                        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");

                        if (Convert.ToString(dv[j]["TableName"]).Trim() == "tbl_Employee_DeductionSalayHead" )
                        {
                            //table_count = tot_employ.Columns.Count;
                            flug_deduction = true;
                           // counter = j;
                        }
                        else
                        {
                            flug_deduction=false;

                        }
                        if (flug_deduction)
                        {
                            Salary_Head = "Deduction." + Salary_Head;
                            //DeductionHeads.Add("Deduction." + Salary_Head);
                        }
                        else
                        {
                            Salary_Head = "Earning." + Salary_Head;
                            //EarningHeads.Add("Earning." + Salary_Head);
                        }
                        tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                        //tot_employ.Rows[i][j + 18] = dv[j]["Amount"];
                    }
                }

                tot_employ.Rows[i]["Slno"] = i + 1;
            }
            tot_employ.Rows.Add();
            int rwc = tot_employ.Rows.Count - 1;
            string col_Name = "";
            tot_employ.Rows[rwc]["Employee Name"] = "TOTAL :";
            for (int clc = 11; clc < tot_employ.Columns.Count; clc++)
            {
                col_Name = tot_employ.Columns[clc].ColumnName;

                tot_employ.Rows[rwc][col_Name] = tot_employ.Compute("SUM([" + col_Name + "])", "");
                //tot_employ.AsEnumerable().Sum(x => Convert.ToDouble(x[col_Name]));
                //tot_employ.Compute("SUM([" + col_Name + "])", "");
            }



            EHSPOS = tot_employ.Columns["Total Earning"].Ordinal;

            tot_employ.Columns["Total Earning"].SetOrdinal(table_count - 1);
            tot_employ.Columns["Total Deduction"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns["Net Pay"].SetOrdinal(tot_employ.Columns.Count - 1);

            DHSPOS = tot_employ.Columns["Total Earning"].Ordinal + 1;

            //tot_employ.Columns["Leave.Prev Bal"].SetOrdinal(tot_employ.Columns.Count - 1);
            //tot_employ.Columns["Leave.Earned"].SetOrdinal(tot_employ.Columns.Count - 1);
            //tot_employ.Columns["Leave.Availed"].SetOrdinal(tot_employ.Columns.Count - 1);
            //tot_employ.Columns["Leave.Cur Bal"].SetOrdinal(tot_employ.Columns.Count - 1);
            //tot_employ.Columns.Add("Signature");

            //tot_employ.Columns.Remove("Leave.Prev Bal");
            //tot_employ.Columns.Remove("Leave.Earned");
            //tot_employ.Columns.Remove("Leave.Availed");
            //tot_employ.Columns.Remove("Leave.Cur Bal");

            tot_employ.Columns.Remove("desig_id");
            tot_employ.Columns.Remove("col36");

            tot_employ.Columns.Add("Employer PF Share");
            tot_employ.Columns.Add("Receipt by Employee / Bank Transaction ID");
            tot_employ.Columns.Add("Date of Payment");
            tot_employ.Columns.Add("Remarks");

            //try
            //{
            //    asign = Convert.ToInt32(clsDataAccess.GetresultS("select lv from CompanyLimiter"));
            //}
            //catch
            //{ 
            //    asign = 0;
            //}
            //if (asign == 0)
            //{
            //    tot_employ.Columns.Remove("Leave.Prev Bal");
            //    tot_employ.Columns.Remove("Leave.Earned");
            //    tot_employ.Columns.Remove("Leave.Availed");
            //    tot_employ.Columns.Remove("Leave.Cur Bal");
            //}
            tot_employ.AcceptChanges();

            dt = tot_employ.Copy();


            //onload(dt);

            //for (int ind = 0; ind < checkedListBox1.Items.Count; ind++)
            //{

            //    if (checkedListBox1.GetItemChecked(ind) == false)
            //    {
            //        dt.Columns.Remove(checkedListBox1.Items[ind].ToString());
            //    }

            //}

            dgv_show.DataSource = dt;

            opt();


            string co_addr = clsDataAccess.RunQDTbl("select CO_ADD from Company where GCODE = " + compid).Rows[0][0].ToString();
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(AttenDtTmPkr.Value.Month);
            DataTable dtClientInfo = clsDataAccess.RunQDTbl("select Client_Name,[Client_ADD1] from tbl_Employee_CliantMaster cm,[tbl_Emp_Location] l where cm.Client_id = l.Cliant_ID and l.Location_ID = " + Locations);
            string clname = dtClientInfo.Rows[0]["Client_Name"].ToString();
            string clAddress = dtClientInfo.Rows[0]["Client_ADD1"].ToString();


            int MDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
            // *excel

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 0, irw = 0; ;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            iCol = dgv_show.Columns.Count;
             Excel.Borders borders;
          

            excel.Cells[1, 1] = "FORM B";                               
            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);
            range.Merge(true);
            range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            //range.RowHeight = 25.00;
            //range.Columns.AutoFit();
            //range.Rows.AutoFit();
            //cmbcompany.Text + Environment.NewLine + co_addr;
            excel.Cells[2, 1] = "FORMAT FOR WAGE REGISTER";
            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[2, iCol]);
            range.Merge(true);
            range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            excel.Cells[3, 1] = "Rate of Minimum Wages since the date ………………….";
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
            range.Merge(true);
            //range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[3, iCol]);
          


            excel.Cells[4, 3] = "Highly Skilled";
            range = worksheet.get_Range(worksheet.Cells[4, 3], worksheet.Cells[4, 4]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            excel.Cells[4, 5] = "Skilled";
            range = worksheet.get_Range(worksheet.Cells[4, 5], worksheet.Cells[4, 6]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            excel.Cells[4, 7] = "Semi-Skilled";
            range = worksheet.get_Range(worksheet.Cells[4, 7], worksheet.Cells[4, 8]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            excel.Cells[4, 9] = "Un Skilled";
            range = worksheet.get_Range(worksheet.Cells[4, 9], worksheet.Cells[4, 10]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            excel.Cells[4, 11] = "Others";
            range = worksheet.get_Range(worksheet.Cells[4, 11], worksheet.Cells[4, 12]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            excel.Cells[5, 1] = "Minimum Basic";
            excel.Cells[6, 1] = "DA";
            excel.Cells[7, 1] = "Overtime";

            range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[7, iCol]);
            borders = range.Borders;
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 2d;

            excel.Cells[8, 1] = "Name of the Establishment:     " + cmbcompany.Text.Trim().ToUpper();

            range = worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[8, (iCol/2)-1]);
            range.Merge(true);
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            excel.Cells[8, (iCol / 2)] = "LOCATION :  " + cmbLocation.Text.Trim().ToUpper();

            range = worksheet.get_Range(worksheet.Cells[8, (iCol / 2)], worksheet.Cells[8, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            excel.Cells[9, 1] = AttenDtTmPkr.Value.ToString("MMM-yy");
            excel.Cells[9, 3] = "Wage period From  …. " + AttenDtTmPkr.Value.ToString("01/MM/yyyy") + " To " + MDays +"/"+ AttenDtTmPkr.Value.ToString("MM/yyyy");
            range = worksheet.get_Range(worksheet.Cells[9, 3], worksheet.Cells[9, 8]);
            range.Merge(true);
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            excel.Cells[9, 9] = "(Monthly Fortnightly/Weekly/Daily/Piece Rated)";
            range = worksheet.get_Range(worksheet.Cells[9, 9], worksheet.Cells[9, 12]);
            range.Merge(true);
            range.Font.Size = 8;
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            //Heading
            excel.Cells[10, 1] = "";

            range = worksheet.get_Range(worksheet.Cells[10, 1], worksheet.Cells[10, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;


            string[] cell_head = new string[] { };
            string old_head = "";
            int ind_st = 0, ind_fin = 0;

            for (int i = 1; i <= dgv_show.Columns.Count; i++)
            {
                cell_head = Convert.ToString(dgv_show.Columns[i - 1].HeaderText).Split('.');
                if (cell_head.Length > 1)
                {
                    if (old_head == cell_head[0])
                    {
                        ind_fin = i;
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[11, ind_st], worksheet.Cells[11, ind_fin]);
                            range.Merge(Type.Missing);
                            range.Font.Bold = true;
                            range.Font.Size = 10;
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[11, ind_st], worksheet.Cells[11, ind_fin]);
                            //range.Merge(Type.Missing);
                            range.Font.Bold = true;
                            range.Font.Size = 10;
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        }
                        catch { }
                        ind_st = i;
                        excel.Cells[11, i] = cell_head[0];
                        old_head = cell_head[0];
                    }
                    excel.Cells[12, i] = cell_head[1];
                }
                else if (cell_head.Length > 0)
                {


                    excel.Cells[11, i] = dgv_show.Columns[i - 1].HeaderText;
                    try
                    {
                        range = worksheet.get_Range(worksheet.Cells[11, i], worksheet.Cells[12, i]);
                        range.Merge(Type.Missing);
                        range.Font.Bold = true;
                        range.Font.Size = 10;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    }
                    catch { }
                }

            }

            range = worksheet.get_Range(worksheet.Cells[12, 1], worksheet.Cells[12, iCol]);
            range.Font.Bold = true;
            DateTime MyDate;
            for (int i = 0; i < dgv_show.Rows.Count; i++)
            {
                for (int j = 1; j <= dgv_show.Columns.Count; j++)
                {
                    try
                    {
                        irw = i + 14;
                        //if (j != 20 || j != 22)
                        //{
                        //    range = worksheet.get_Range(worksheet.Cells[i + 14, j], worksheet.Cells[i + 14, j]);
                        //    range.NumberFormat = "@";
                        //}
                        if (!DateTime.TryParse(dgv_show.Rows[i].Cells[j - 1].Value.ToString(), out MyDate))
                        {
                            excel.Cells[i + 14, j] = dgv_show.Rows[i].Cells[j - 1].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 14, j] = "'" + dgv_show.Rows[i].Cells[j - 1].Value.ToString();
                        }
                    }
                    catch { }
                }
            }
            
            object missing = System.Reflection.Missing.Value;



            range = worksheet.get_Range(worksheet.Cells[11, 1], worksheet.Cells[irw, iCol]);
            borders = range.Borders;
            //Set the thick lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 2d;
            // range.WrapText = true;

            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();

            //((Excel._Application)excel).Save();

            MessageBox.Show("Export To Excel Completed!", "Export");
        }

        private void frm_register_wage_FormB_Load(object sender, EventArgs e)
        {
            
            clsValidation.GenerateYear(cmbYear, 2000, System.DateTime.Now.Year, 1);

            AttenDtTmPkr.Value = DateAndTime.Now.AddMonths(-1);

           // cmbcompany.PopUp();
            cmbLocation.PopUp();
        }

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {
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
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {

            string s = "select  l.Location_Name, l.Location_ID,(SELECT top 1 Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls where l.Location_ID = ls.Location_ID";
            DataTable dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;

            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
            {
                Locations = Convert.ToString(cmbLocation.ReturnValue);
                cmbLocation.Text = cmbLocation.Text + " - " + clsDataAccess.ReturnValue("select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l where l.Location_ID =" + Locations);

                Location_Name = Convert.ToString(cmbLocation.Text);
                cmbLocationid();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Location  must be entered");
                return;
            }
            AttenDtTmPkr.Focus();
        }
        private void cmbLocationid()
        {
            DataTable dt = new DataTable();
            lbl_company.Text = "";
            cmbcompany.Text = "";
            compid = "";
            dt.Clear();
            string s = "SELECT CO_NAME, GCODE  FROM Company WHERE  (CO_CODE IN " +
            "(SELECT Company_ID FROM Companywiseid_Relation WHERE (Location_ID =" + Locations + ")))";
            dt = clsDataAccess.RunQDTbl(s);
            try
            {
                if (dt.Rows.Count > 1)
                {
                    cmbcompany.LookUpTable = dt;
                    cmbcompany.ReturnIndex = 1;
                    lbl_company.Text = "";
                }
                if (dt.Rows.Count == 1)
                {
                    cmbcompany.Text = Convert.ToString(dt.Rows[0][0]);
                    lbl_company.Text = Convert.ToString(dt.Rows[0][0]);
                    compid = Convert.ToString(dt.Rows[0][1]);
                }
                if (dt.Rows.Count == 0)
                {
                    lbl_company.Text = "";
                    compid = "";
                    cmbcompany.Visible = false;
                    MessageBox.Show("No Company linked with Location");
                }
                label3.Visible = true;
                lbl_company.Visible = false;
                cmbcompany.Visible = true;
            }
            catch
            {
                lbl_company.Text = "No Company linked with Location";
                MessageBox.Show("No Company linked with Location");
                label3.Visible = false;
                lbl_company.Visible = false;
                cmbcompany.Visible = false;
            }
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {


        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
            {
                compid = Convert.ToString(cmbcompany.ReturnValue);
                lbl_company.Text = cmbcompany.Text;
            }
        }
    }
}
