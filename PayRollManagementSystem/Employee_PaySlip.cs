using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PayRollManagementSystem
{
    public partial class Employee_PaySlip : EDPComponent.FormBaseERP 
    {
        public Employee_PaySlip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] EmpCode = new string[2];
            EmpCode = Employeecmb.Text.ToString().Split('-');
            DataTable ReportDt = new DataTable();
            DataTable TempDt=new DataTable();
            ReportDt.Columns.Add("DESCRIPTION");
            ReportDt.Columns.Add("DETAILS");
            ReportDt.Columns.Add("AMOUNT");
            ReportDt.Columns.Add("Temp");

            TempDt = GetSalaryHeads(EmpCode[1].Trim());
            //ReportDt = GetSalaryHeads(EmpCode[1].Trim()).Copy();
            //ReportDt= .Copy();
            int Cnt = 0;
            for (Cnt = 0; Cnt < TempDt.Rows.Count; Cnt++)
            {
                ReportDt.Rows.Add();
                ReportDt.Rows[Cnt]["DESCRIPTION"] = Convert.ToString(TempDt.Rows[Cnt]["DESCRIPTION"]);
                ReportDt.Rows[Cnt]["DETAILS"] = Convert.ToString(TempDt.Rows[Cnt]["DETAILS"]);
                ReportDt.Rows[Cnt]["AMOUNT"] = Convert.ToString(TempDt.Rows[Cnt]["AMOUNT"]);
            }


            TempDt = CalculateAttndance(EmpCode[1].Trim());
            int Cnt2 = Cnt ;
            ReportDt.Rows.Add();
            ReportDt.Rows.Add();
            Cnt2++;
            ReportDt.Rows[Cnt2]["DESCRIPTION"] = "Leave Details";
                 Cnt2++;
       for (Cnt = 0; Cnt < TempDt.Rows.Count; Cnt++)
            {
                
                ReportDt.Rows.Add();
                ReportDt.Rows[Cnt2]["DESCRIPTION"] = Convert.ToString(TempDt.Rows[Cnt]["ShortName"]);
                ReportDt.Rows[Cnt2]["DETAILS"] = Convert.ToString(TempDt.Rows[Cnt]["TotalLeaves"]);
                ReportDt.Rows[Cnt2]["AMOUNT"] = Convert.ToString(TempDt.Rows[Cnt]["FstHalf"]);
                ReportDt.Rows[Cnt2]["Temp"] = Convert.ToString(TempDt.Rows[Cnt]["SndHalf"]);
                Cnt2++;
            }

            PaySlipGrid.DataSource = ReportDt;

        }

        public void EmployeeListing()
        {
            DataTable EmpDtbl = clsDataAccess.RunQDTbl("SELECT Title + ' ' + FirstName + ' ' + MiddleName + " +
            "' ' + LastName + ' - ' + ID AS EmpDetails FROM EDP_Payroll.dbo.tbl_Employee_Mast");
            int Cnt = 0;

            while (Cnt < EmpDtbl.Rows.Count)
            {
                Employeecmb.Items.Add(EmpDtbl.Rows[Cnt][0].ToString());
                Cnt++;
            }

        }

        private DataTable GetSalaryHeads(string EmployeeID)
        {
            decimal decTotalDeduc = 0.00m;
            DataTable dtSalaryHead = new DataTable("SalaryHead");
            DataTable EarningHead = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,tbl_Employee_SalaryDet.Amount As Amt " +
                " FROM tbl_Employee_ErnSalaryHead INNER JOIN tbl_Employee_SalaryDet ON " +
                " tbl_Employee_ErnSalaryHead.SlNo=tbl_Employee_SalaryDet.SalId AND " +
                " tbl_Employee_SalaryDet.TableName='tbl_Employee_ErnSalaryHead' WHERE " +
                " tbl_Employee_SalaryDet.Session='" + FinacialYear.Text.Trim() + "' AND tbl_Employee_SalaryDet.[Month]='" +
                Microsoft.VisualBasic.DateAndTime.MonthName(ConsolMonthdttmpkr.Value.Month, false) +
                "' AND tbl_Employee_SalaryDet.EmpID='" + EmployeeID + "'");


            DataTable Deductiontbl = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,tbl_Employee_SalaryDet.Amount  As DAmt " +
                "FROM tbl_Employee_SalaryDet INNER JOIN tbl_Employee_DeductionSalayHead ON " +
                " tbl_Employee_DeductionSalayHead.SlNo=tbl_Employee_SalaryDet.SalId AND " +
                " tbl_Employee_SalaryDet.TableName='tbl_Employee_DeductionSalayHead' WHERE " +
                " tbl_Employee_SalaryDet.Session='" + FinacialYear.Text.Trim() +
                "' AND tbl_Employee_SalaryDet.[Month]='" +
                Microsoft.VisualBasic.DateAndTime.MonthName(ConsolMonthdttmpkr.Value.Month, false) +
                "' AND tbl_Employee_SalaryDet.EmpID='" + EmployeeID + "'");
            
            DataTable PFTable = clsDataAccess.RunQDTbl("SELECT ShortName,tbl_Employee_SalaryDet.Amount As PAmt  FROM " +
                " tbl_Employee_SalaryDet INNER JOIN tbl_Employee_Config_PFHeads ON " +
                " tbl_Employee_Config_PFHeads.SlNo=tbl_Employee_SalaryDet.SalId AND " +
                " tbl_Employee_SalaryDet.TableName='tbl_Employee_Config_PFHeads' WHERE " +
                " tbl_Employee_SalaryDet.Session='" + FinacialYear.Text.Trim() + "' AND tbl_Employee_SalaryDet.[Month]='" +
                Microsoft.VisualBasic.DateAndTime.MonthName(ConsolMonthdttmpkr.Value.Month, false) +
                "' AND tbl_Employee_SalaryDet.EmpID='" + EmployeeID + "'");

            DataTable dtSummary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryMast where Emp_Id='" +
            EmployeeID + "' and Month='" + Microsoft.VisualBasic.DateAndTime.MonthName(ConsolMonthdttmpkr.Value.Month, false) +
            "' and Session='" + FinacialYear.Text.Trim() + "'");

            dtSalaryHead.Columns.Add("DESCRIPTION");
            dtSalaryHead.Columns.Add("DETAILS");
            dtSalaryHead.Columns.Add("AMOUNT");
            //dtSalaryHead.Columns.Add("Amount");

            for (Int32 i = 0; i < EarningHead.Rows.Count; i++)
            {
                dtSalaryHead.Rows.Add();
                dtSalaryHead.Rows[i]["DESCRIPTION"] = Convert.ToString(EarningHead.Rows[i]["SalaryHead_Short"]);
                dtSalaryHead.Rows[i]["DETAILS"] = Convert.ToString(EarningHead.Rows[i]["Amt"]);
                //dtSalaryHead.Rows[i]["ID"] = Convert.ToString(EarningHead.Rows[i]["SlNo"]);
                //dtSalaryHead.Rows[i]["TableName"] = Convert.ToString("tbl_Employee_ErnSalaryHead");
            }
            dtSalaryHead.Rows.Add();
            if (dtSummary.Rows.Count > 0)
            {
                dtSalaryHead.Rows[EarningHead.Rows.Count]["DESCRIPTION"] = "Special";
                dtSalaryHead.Rows[EarningHead.Rows.Count]["DETAILS"] = dtSummary.Rows[0]["Special"].ToString();
            }
            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DETAILS"] = "-----------";

            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "Total Salary";

            dtSalaryHead.Rows.Add();


            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "Gross Salary";

            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "Salary for P.F Due";

            dtSalaryHead.Rows.Add();


            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "P.F Contribution";
            for (Int32 i = 0; i < PFTable.Rows.Count; i++)
            {
                dtSalaryHead.Rows.Add();
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "   " + Convert.ToString(PFTable.Rows[i]["ShortName"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DETAILS"] = Convert.ToString(PFTable.Rows[i]["PAmt"]);
                //dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["ID"] = Convert.ToString(PFTable.Rows[i]["SlNo"]);
                //dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["TableName"] = Convert.ToString("tbl_Employee_Config_PFHeads");
            }


            for (Int32 i = 0; i < Deductiontbl.Rows.Count; i++)
            {
                dtSalaryHead.Rows.Add();
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = Convert.ToString(Deductiontbl.Rows[i]["SalaryHead_Short"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DETAILS"] = Convert.ToString(Deductiontbl.Rows[i]["DAmt"]);

                //dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["ID"] = Convert.ToString(Deductiontbl.Rows[i]["SlNo"]);
                //dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["TableName"] = Convert.ToString("tbl_Employee_DeductionSalayHead");
            }
            //
            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DETAILS"] = "____________________";
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "____________________";

            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "Total Deduction";

            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "Net Amount Payable";

            if (dtSummary.Rows.Count > 0)
            {
                dtSalaryHead.Rows[EarningHead.Rows.Count + 2]["AMOUNT"] = dtSummary.Rows[0]["GrossAmount"];
                dtSalaryHead.Rows[EarningHead.Rows.Count + 4]["DETAILS"] = dtSummary.Rows[0]["GrossAmount"];
                dtSalaryHead.Rows[EarningHead.Rows.Count + 5]["DETAILS"] = dtSummary.Rows[0]["PFDue"];
                decTotalDeduc += Convert.ToDecimal(dtSummary.Rows[0]["TotalDec"]);
            }

            int j;

            for (j = EarningHead.Rows.Count + 5; j < EarningHead.Rows.Count + PFTable.Rows.Count + Deductiontbl.Rows.Count + 5; j++)
            {
                if (!String.IsNullOrEmpty(dtSalaryHead.Rows[j]["DETAILS"].ToString()))
                {

                }
            }

            dtSalaryHead.Rows[EarningHead.Rows.Count + PFTable.Rows.Count + Deductiontbl.Rows.Count + 5 + 4]["AMOUNT"] = decTotalDeduc.ToString("0.00");
            //if (!String.IsNullOrEmpty(dtSalaryHead.Rows[EarningHead.Rows.Count + 3]["DETAILS"].ToString()))
            //{
            //    decTotalDeduc = Convert.ToDecimal();

            //}
            if (dtSummary.Rows.Count > 0)
            {
                dtSalaryHead.Rows[EarningHead.Rows.Count + PFTable.Rows.Count + Deductiontbl.Rows.Count + 5 + 5]["AMOUNT"] = Convert.ToString(dtSummary.Rows[0]["NetPay"]);
            }

            return dtSalaryHead;

        }

        private DataTable CalculateAttndance(string EmployeeID)
        {
             int NumberOfDays = DateTime.DaysInMonth(ConsolMonthdttmpkr.Value.Year, ConsolMonthdttmpkr.Value.Month);
            //int LeaveWithPay = 0;
            //int LaeveWithOutPay = 0;
            //int TotalDaysCharge = 0;
            //int ExtraDury = 0;

            //DataTable Dt = clsDataAccess.RunQDTbl("");
            //dtAtt.Columns.Add("Present Days");
            //dtAtt.Columns.Add("Leave With Pay");
            //dtAtt.Columns.Add("Leave Without Pay");
            //dtAtt.Columns.Add("Total Days Charged");
            //dtAtt.Rows.Add();
            //int i = 0;

            //Present Days
            //Leave With Pay
            //Leave With Out Pay
            //Total Days Charged
            //Extra Duties
            //Cl

            DataTable LeaveDt = clsDataAccess.RunQDTbl("SELECT ShortName,TotalLeaves,(SELECT Count(*) FROM " + 
            "tbl_Employee_Attendance AS LvAt WHERE LvAt.FstLeave=LvDt.LeaveId AND LeaveDate between '" + 
            ConsolMonthdttmpkr.Value.Month + "/01/" + ConsolMonthdttmpkr.Value.Year + "' AND '" +
            ConsolMonthdttmpkr.Value.Month + "/" + NumberOfDays + "/" + ConsolMonthdttmpkr.Value.Year +
            "' AND ID='" + EmployeeID + "') As FstHalf,(SELECT Count(*) FROM tbl_Employee_Attendance AS LvAt WHERE " +
            " LvAt.SndLeave=LvDt.LeaveId AND LeaveDate between '" + 
            ConsolMonthdttmpkr.Value.Month + "/01/" + ConsolMonthdttmpkr.Value.Year + "' AND '" +
            ConsolMonthdttmpkr.Value.Month + "/" + NumberOfDays + "/" + ConsolMonthdttmpkr.Value.Year +
            "' AND ID='" + EmployeeID + "') As SndHalf FROM tbl_Employee_Config_LeaveDetails AS LvDt WHERE LeaveID <>1");

            return LeaveDt;
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


        private void Employee_PaySlip_Load(object sender, EventArgs e)
        {
            EmployeeListing();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PaySlipGrid.Print();
        }
    }
}