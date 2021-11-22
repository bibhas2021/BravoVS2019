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
    public partial class ArrearAquittanceReport : EDPComponent.FormBaseERP
    {
        public ArrearAquittanceReport()
        {
            InitializeComponent();
        }

        private void ArrearAquittanceReport_Load(object sender, EventArgs e)
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
            dt.Columns.Add("Signature");
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

                        dt.Rows[i]["Signature"] = "";
                        DataTable dtSalary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + Convert.ToString(dtEmp.Rows[i]["ID"]) + "' and SalId='" + Convert.ToString(dtArrSal.Rows[0]["Salid"]) + "' and TableName='tbl_Employee_ErnSalaryHead' and Month='" + Convert.ToString(dtArrSal.Rows[0]["EffMonth"]) + "' and Session='" + cmbYear.Text.Trim() + "'");

                        dt.Rows[i]["ID"] = i + 1;
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
            SimpleTextReport ArrearPS = new SimpleTextReport();

            ArrearPS.MainPageHeaders.Add();
            ArrearPS.MainPageHeaders[0].Text = "Page No:-1" + Space(9) + "RISHRA VANI BHARATI";
            ArrearPS.MainPageHeaders[0].Bold = true;
            ArrearPS.MainPageHeaders[0].Expanded = true;
            ArrearPS.MainPageHeaders[0].Alignment = SimpleTextReport.PutTextAlign.Left;

            ArrearPS.MainPageHeaders.Add();
            ArrearPS.MainPageHeaders[1].Text = "";


            ArrearPS.MainPageHeaders.Add();
            ArrearPS.MainPageHeaders[2].Text = "Additional D.A. Aquittance Report";
            ArrearPS.MainPageHeaders[2].Bold = true;
            ArrearPS.MainPageHeaders[2].Alignment = SimpleTextReport.PutTextAlign.Left;

            ArrearPS.ActiveDataTable = true;
            ArrearPS.DataTable = dt;


            int intColNo = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                ArrearPS.ReportColumns.Add();

                if (dc.ColumnName.ToString() == "Name")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Name of");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("the Staff");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 25;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }
                else if (dc.ColumnName.ToString() == "SlNo")
                {
                    //ArrearPS.ReportColumns[intColNo].Header.Text.Add("Name of");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("SlNo");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 25;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "ID")
                {
                    //ArrearPS.ReportColumns[intColNo].Header.Text.Add("Name of");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("ID");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 25;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "Basic")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Basic");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Drawn");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 10;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }
                else if (dc.ColumnName.ToString() == "TotalDA")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("DA");

                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 8;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }
                else if (dc.ColumnName.ToString() == "DADrawn")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("DA");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Drawn");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 8;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "DADiff")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("DA Diff");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("P.M.");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 9;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }
                else if (dc.ColumnName.ToString() == "GrandTot")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Grand");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 9;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "OnWhichPFDed")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("On Which");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("P.F");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("DED.");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 10;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "LWPds")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("L.W.P.");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Days");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 8;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "LWPGross")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("L.W.P.");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Gross");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Amount");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 9;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }
                else if (dc.ColumnName.ToString() == "LWPAmtOnPFDed")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("L.W.P.");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Amount");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("On Which");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("P.F Ded.");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 10;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "LWPfrmGrndTot")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("L.W.P.");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("From");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Grand");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 14;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }


                else if (dc.ColumnName.ToString() == "GrossAfterLWP")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("L.W.P.");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("From");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Amount");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("P.F Ded.");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 14;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }


                else if (dc.ColumnName.ToString() == "GrossAmtAftrLWP")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Gross Amt.");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("After L.W.P");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 14;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "AftrWhichPFDedLWP")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("After");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Which");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("P.F Ded.");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("L.W.P.");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 18;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "TotDeduc")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Total");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Deduction");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 12;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }
                else if (dc.ColumnName.ToString() == "NetPay")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Net ");
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Payable");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 8;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "Signature")
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add("Signature");
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 11;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }

                else
                {
                    ArrearPS.ReportColumns[intColNo].Header.Text.Add(dc.ColumnName);
                    ArrearPS.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                    ArrearPS.ReportColumns[intColNo].LinesToAColumn = 8;
                    ArrearPS.ReportColumns[intColNo].Header.Condensed = true;
                    ArrearPS.ReportColumns[intColNo].TDataTable = dt;
                    ArrearPS.ReportColumns[intColNo].Condensed = true;
                    ArrearPS.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ArrearPS.ReportColumns[intColNo].Borderget = true;
                }
                intColNo += 1;
            }
            ArrearPS.CustomisedSection.Add();
            ArrearPS.CustomisedSection[0].Lines.Add();
            ArrearPS.CustomisedSection[0].Lines[0].Cells.Add();
            ArrearPS.CustomisedSection[0].Lines[0].Cells[0].Text = " ";
            ArrearPS.CustomisedSection.Add();
            ArrearPS.CustomisedSection[1].Position = SimpleTextReport.Position.AtEndofPage;
            ArrearPS.CustomisedSection[1].Lines.Add();
            ArrearPS.CustomisedSection[1].Lines[0].Cells.Add();
            ArrearPS.CustomisedSection[1].Lines[0].Cells[0].Text = "Prepared By:............";
            ArrearPS.Print();
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