using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERPMessageBox;
using EDPComponent;

namespace PayRollManagementSystem
{
    public partial class ArrearBillReport : EDPComponent.FormBaseERP
    {
        public ArrearBillReport()
        {
            InitializeComponent();
        }

        private DataTable GetDtHeader()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SlNo");
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Basic");
            dt.Columns.Add("TotalDA");
            dt.Columns.Add("DADrawn");
            dt.Columns.Add("DADiff");
            dt.Columns.Add("GrandTot");
            dt.Columns.Add("OnWhichPFDed");
            dt.Columns.Add("LWPds");
            dt.Columns.Add("LWPGross");
            dt.Columns.Add("LWPAmtOnPFDed");
            dt.Columns.Add("LWPfrmGrndTot");
            dt.Columns.Add("GrossAfterLWP");
            dt.Columns.Add("GrossAmtAftrLWP");
            dt.Columns.Add("AftrWhichPFDedLWP");
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");

            for (int i = 0; i < dtDeduction.Rows.Count; i++)
            {
                dt.Columns.Add(Convert.ToString(dtDeduction.Rows[i]["SalaryHead_Short"]));
            }

            dt.Columns.Add("TotDeduc");
            dt.Columns.Add("NetPay");
        
            return dt;
        }

        private decimal Basic(string ID)
        {
            decimal dcBasic = 0.00m, dcDA = 0.00m, dcTotal = 0.00m;
            DataTable dtArrSal = clsDataAccess.RunQDTbl("select EffMonth from tbl_Employee_Config_ArrearMast where ArrearId='" + cmbArrearName.ReturnValue + "' and EffYear='" + cmbYear.Text.Substring(0, 4) + "'");
            DataTable dtBasicSalary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + ID + "' and SalId='3' and TableName='tbl_Employee_ErnSalaryHead' and Month='" + Convert.ToString(dtArrSal.Rows[0]["EffMonth"]) + "' and Session='" + cmbYear.Text.Trim() + "'");
            DataTable dtDASalary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + ID + "' and SalId='6' and TableName='tbl_Employee_ErnSalaryHead' and Month='" + Convert.ToString(dtArrSal.Rows[0]["EffMonth"]) + "' and Session='" + cmbYear.Text.Trim() + "'");

            if (dtBasicSalary.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(dtBasicSalary.Rows[0]["Amount"].ToString()))
                {
                    dcBasic = Convert.ToDecimal(dtBasicSalary.Rows[0]["Amount"].ToString());
                }
                else
                {
                    dcBasic = 0;
                }
            }



            dcTotal = dcBasic;
            return dcTotal;
        }
        private DataTable GetDetails()
        {
            decimal dcDASal = 0.00m;
            DataTable dt = GetDtHeader();
            DataTable dtArrSal = clsDataAccess.RunQDTbl("select mast.EffMonth,mast.FromMonth,mast.ToMonth,mast.FromYear,mast.ToYear,det.SalId,det.PayType,det.PayMode,det.SalTable,det.Amount from tbl_Employee_Config_ArrearDet det,dbo.tbl_Employee_Config_ArrearMast mast where det.ArrearId='" + cmbArrearName.ReturnValue + "' and det.ArrearId=mast.ArrearId");
            //DataTable dtArrear = clsDataAccess.RunQDTbl("select EffMonth from tbl_Employee_Config_ArrearMast where ArrearId='" + cmbArrearName.ReturnValue + "' and EffYear='" + cmbYear.Text.Substring(0, 4) + "'");

            if (dtArrSal.Rows.Count > 0)
            {

                DataTable dtEmp = clsDataAccess.RunQDTbl("select ID,FirstName+' '+MiddleName+' '+LastName Name from tbl_Employee_Mast where Session='" + cmbYear.Text.Trim() + "'");
                if (dtEmp.Rows.Count > 0)
                {
                    for (Int32 i = 0; i < dtEmp.Rows.Count; i++)
                    {
                        dt.Rows.Add();
                        foreach (DataColumn dc in dt.Columns) { dt.Rows[i][dc.ColumnName] = "0"; }

                   
                        DataTable dtSalary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + Convert.ToString(dtEmp.Rows[i]["ID"]) + "' and SalId='" + Convert.ToString(dtArrSal.Rows[0]["Salid"]) + "' and TableName='tbl_Employee_ErnSalaryHead' and Month='" + Convert.ToString(dtArrSal.Rows[0]["EffMonth"]) + "' and Session='" + cmbYear.Text.Trim() + "'");
                        dt.Rows[i]["SlNo"] = i + 1;
                        dt.Rows[i]["ID"] = Convert.ToString(dtEmp.Rows[i]["ID"]);
                        dt.Rows[i]["Name"] = Convert.ToString(dtEmp.Rows[i]["Name"]);
                        dt.Rows[i]["Basic"] = Basic(Convert.ToString(dtEmp.Rows[i]["ID"]));


                        if (dtSalary.Rows.Count > 0)
                        {
                            if (!String.IsNullOrEmpty(dtSalary.Rows[0]["Amount"].ToString()))
                            {
                                dcDASal = Convert.ToDecimal(dtSalary.Rows[0]["Amount"].ToString());
                            }
                            else
                            {
                                dcDASal = 0;
                            }
                        }
                        dt.Rows[i]["DADrawn"] = dcDASal.ToString("0.00");
                        if (Convert.ToString(dtArrSal.Rows[0]["PayType"]).ToLower() == "amount")
                        {
                            dcDASal += Convert.ToDecimal(dtArrSal.Rows[0]["Amount"].ToString());
                        }
                        else
                        {
                            dcDASal += Convert.ToDecimal(dtArrSal.Rows[0]["Amount"].ToString()) * (dcDASal / 100);
                        }

                        dt.Rows[i]["TotalDA"] = dcDASal.ToString("0.00");
                        decimal dcDiff = Convert.ToDecimal(dt.Rows[i]["TotalDA"]) - Convert.ToDecimal(dt.Rows[i]["DADrawn"]);
                        dt.Rows[i]["DADiff"] = dcDiff.ToString("0.00");

                        int frmMon = clsEmployee.GetMonth_SingleDigit(Convert.ToString(dtArrSal.Rows[0]["FromMonth"]));
                        int toMon = clsEmployee.GetMonth_SingleDigit(Convert.ToString(dtArrSal.Rows[0]["ToMonth"]));
                        int frmYear = Convert.ToInt32(dtArrSal.Rows[0]["FromYear"]);
                        int toYear = Convert.ToInt32(dtArrSal.Rows[0]["ToYear"]);
                        int totalMon = 0, totalYr = 0;
                        if (toYear > frmYear)
                        {
                            totalYr = (toYear - frmYear);
                            if (frmMon > toMon)
                            {

                                totalMon = totalYr * 12 + (frmMon + toMon);
                            }
                            else
                            {
                                totalMon = totalYr * 12 + (toMon - frmMon);
                            }
                        }
                        else if (toYear == frmYear)
                        {
                            totalMon = toMon - frmMon;
                        }
                        dt.Rows[i]["GrandTot"] = totalMon * dcDiff;
                        dt.Rows[i]["GrossAmtAftrLWP"] = Convert.ToDecimal(dt.Rows[i]["GrandTot"]) - Convert.ToDecimal(dt.Rows[i]["LWPAmtOnPFDed"]);
                        dt.Rows[i]["AftrWhichPFDedLWP"] = Convert.ToDecimal(dt.Rows[i]["GrossAmtAftrLWP"]);
                        dt.Rows[i]["NetPay"] = Convert.ToDecimal(dt.Rows[i]["GrandTot"]) - Convert.ToDecimal(dt.Rows[i]["TotDeduc"]);
                    }
                }
            }
            return dt;
        }
        private void ArrearBillReport_Load(object sender, EventArgs e)
        {
            //generate year
            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
            //
            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }
        }

        private void cmbArrearName_DropDown(object sender, EventArgs e)
        {
            GetAllArrear();
        }
        private void GetAllArrear()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select ArrearName,ArrearId from tbl_Employee_Config_ArrearMast");
            if (dt.Rows.Count > 0)
            {
                cmbArrearName.LookUpTable = dt;
                cmbArrearName.ReturnIndex = 1;
            }
        }
        private string Space(Int32 number)
        {
            string Blank_Space = " ";
            for (int i = 0; i < number; i++)
            {
                Blank_Space = Blank_Space + " ";
            }
            return Blank_Space;
        }
        private void GetPrint()
        {
            DataTable dt = GetDetails();
            SimpleTextReport ArrearBill = new SimpleTextReport();

            ArrearBill.MainPageHeaders.Add();
            ArrearBill.MainPageHeaders[0].Text = "Page No:-1" + Space(9) + "RISHRA VANI BHARATI";
            ArrearBill.MainPageHeaders[0].Bold = true;
            ArrearBill.MainPageHeaders[0].Expanded = true;
            ArrearBill.MainPageHeaders[0].Alignment = SimpleTextReport.PutTextAlign.Left;

            ArrearBill.MainPageHeaders.Add();
            ArrearBill.MainPageHeaders[1].Text = "";


            ArrearBill.MainPageHeaders.Add();
            ArrearBill.MainPageHeaders[2].Text = "Additional D.A. Bill";
            ArrearBill.MainPageHeaders[2].Bold = true;
            ArrearBill.MainPageHeaders[2].Alignment = SimpleTextReport.PutTextAlign.Left;

            ArrearBill.ActiveDataTable = true;
            ArrearBill.DataTable = dt;


            int intColNo = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                ArrearBill.ReportColumns.Add();

                if (dc.ColumnName.ToString() == "Name")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Name of");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("the Staff");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 25;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "SlNo")
                {
                    //ArrearBill.ReportColumns[intColNo].Header.Text.Add("Name of");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("SlNo");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 25;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "ID")
                {
                    //ArrearBill.ReportColumns[intColNo].Header.Text.Add("Name of");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("ID");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 25;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "Basic")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Basic");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Drawn");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 10;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }
                else if (dc.ColumnName.ToString() == "TotalDA")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("DA");

                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 8;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }
                else if (dc.ColumnName.ToString() == "DADrawn")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("DA");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Drawn");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 8;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "DADiff")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("DA Diff");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("P.M.");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 9;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }
                else if (dc.ColumnName.ToString() == "GrandTot")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Grand");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 9;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "OnWhichPFDed")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("On Which");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("P.F");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("DED.");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 10;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "LWPds")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("L.W.P.");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Days");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 8;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "LWPGross")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("L.W.P.");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Gross");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Amount");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 9;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }
                else if (dc.ColumnName.ToString() == "LWPAmtOnPFDed")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("L.W.P.");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Amount");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("On Which");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("P.F Ded.");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 10;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "LWPfrmGrndTot")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("L.W.P.");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("From");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Grand");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 14;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }


                else if (dc.ColumnName.ToString() == "GrossAfterLWP")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("L.W.P.");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("From");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Amount");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("P.F Ded.");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 14;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }


                else if (dc.ColumnName.ToString() == "GrossAmtAftrLWP")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Gross Amt.");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("After L.W.P");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 14;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "AftrWhichPFDedLWP")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("After");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Which");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("P.F Ded.");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("L.W.P.");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 18;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "TotDeduc")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Deduction");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 12;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }
                else if (dc.ColumnName.ToString() == "NetPay")
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Net ");
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add("Payable");
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 8;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }

                else
                {
                    ArrearBill.ReportColumns[intColNo].Header.Text.Add(dc.ColumnName);
                    ArrearBill.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearBill.ReportColumns[intColNo].LinesToAColumn = 8;
                    ArrearBill.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearBill.ReportColumns[intColNo].TDataTable = dt;
                    ArrearBill.ReportColumns[intColNo].Condensed = true;
                    ArrearBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearBill.ReportColumns[intColNo].Borderget = true;
                }
                intColNo += 1;
            }
            ArrearBill.CustomisedSection.Add();
            ArrearBill.CustomisedSection[0].Lines.Add();
            ArrearBill.CustomisedSection[0].Lines[0].Cells.Add();
            ArrearBill.CustomisedSection[0].Lines[0].Cells[0].Text = " ";
            ArrearBill.CustomisedSection.Add();
            ArrearBill.CustomisedSection[1].Position = SimpleTextReport.Position.AtEndofPage;
            ArrearBill.CustomisedSection[1].Lines.Add();
            ArrearBill.CustomisedSection[1].Lines[0].Cells.Add();
            ArrearBill.CustomisedSection[1].Lines[0].Cells[0].Text = "Prepared By:............";
            ArrearBill.Print();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Select Year."))
            {
                if (clsValidation.ValidateEdpCombo(cmbArrearName, "", "Please Select Arrear Name."))
                {

                    GetPrint();

                }
            }
        }

    }
}