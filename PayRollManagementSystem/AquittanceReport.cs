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
    public partial class AquittanceReport : EDPComponent.FormBaseERP
    {
        public int intIncr = 0;
        public decimal decTotalDeduc = 0.00m, decTotalPF = 0.00m, decGrossPay = 0.00m;
        public DataTable dtRowName = new DataTable();

        public AquittanceReport()
        {
            InitializeComponent();
        }
        private DataTable GetEmpDetails()
        {
            DataTable dtEmpName = clsDataAccess.RunQDTbl("select ID,FirstName+' '+MiddleName+' '+LastName as [Employee Name] from tbl_Employee_Mast");
            return dtEmpName;
        }
        private DataTable VariableHead_Mid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Variable");
            dt.Columns.Add("Variable Details");
            //dt.Rows.Add();
            //dt.Rows.Add();
            //dt.Rows[0]["Variable"]="Total Salary";
            dt.Rows.Add();
            dt.Rows[0]["Variable"] = "No of Days Present";
            dt.Rows.Add();
            dt.Rows[1]["Variable"] = "Leave With Pay";
            dt.Rows.Add();
            dt.Rows[2]["Variable"] = "Leave Without Pay";
            dt.Rows.Add();
            dt.Rows[3]["Variable"] = "Total Days Charged";
            dt.Rows.Add();
            dt.Rows[4]["Variable"] = "Total Days";

            return dt;
        }
        private DataTable EarnSalaryHead()
        {
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");

            return dtErn;
        }
        private DataTable VariableWithValue(string strID)
        {
            DataTable dtEmp = GetEmpDetails();
            DataTable dt = VariableHead_Mid();
            DataTable dtSummary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryMast where Emp_Id='" + strID + "' and Month='" + cmbMonth.Text + "' and Session='" + cmbSession.Text + "'");
            dt.Rows[4]["Variable Details"] = clsEmployee.GetTotalDaysByMonth(cmbMonth.Text.Trim(), clsEmployee.GetYear(cmbMonth.Text.Trim(), cmbSession.Text.Trim()));
            if (dtSummary.Rows.Count > 0)
            {
                dt.Rows[0]["Variable Details"] = dtSummary.Rows[0]["DaysPresent"].ToString();
                dt.Rows[1]["Variable Details"] = dtSummary.Rows[0]["LeaveWithPay"].ToString();
                dt.Rows[2]["Variable Details"] = dtSummary.Rows[0]["LeaveWithoutPay"].ToString();
                dt.Rows[3]["Variable Details"] = dtSummary.Rows[0]["TotalDays"].ToString();
            }
            else
            {
                dt.Rows[0]["Variable Details"] = "0";
                dt.Rows[1]["Variable Details"] = "0";
                dt.Rows[2]["Variable Details"] = "0";
                dt.Rows[3]["Variable Details"] = "0";
            }
            return dt;
        }
        private DataTable PFHead()
        {
            DataTable dtPF = clsDataAccess.RunQDTbl("select ShortName,SlNo from tbl_Employee_Config_PFHeads ");
            //dtPF.Rows.Add("Total PF");
            return dtPF;
        }

        private DataTable DeductionHead()
        {
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");

            return dtDeduction;
        }

        private DataTable EmpDeatilsHead()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Serial");
            dt.Columns.Add("Name");
            dt.Columns.Add("ID");

            //GetEmpDetails(dt);

            return dt;
        }

        private DataTable GetHeaders()
        {
            int i = 0, k = 0, j = 0;
            DataTable dtPF = clsDataAccess.RunQDTbl("select ShortName,SlNo from tbl_Employee_Config_PFHeads ");
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");
            DataTable dtErn = EarnSalaryHead();
            DataTable dt = EmpDeatilsHead();
            if (dtErn.Rows.Count > 0)
            {
                for (k = 0; k < dtErn.Rows.Count; k++)
                {
                    dt.Columns.Add(dtErn.Rows[k]["SalaryHead_Short"].ToString());
                }
            }
            dt.Columns.Add("Total Days");
            dt.Columns.Add("Total Salary");
            dt.Columns.Add("Days Present");
            dt.Columns.Add("LP");
            dt.Columns.Add("LWP");
            dt.Columns.Add("Total Days Charged");
            dt.Columns.Add("P.F Due");
            dt.Columns.Add("Gross Amount");

            if (dtPF.Rows.Count > 0)
            {
                for (k = 0; k < dtPF.Rows.Count; k++)
                {
                    dt.Columns.Add(dtPF.Rows[k]["ShortName"].ToString());
                }
            }
            dt.Columns.Add("Total PF", typeof(double));
            if (dtDeduction.Rows.Count > 0)
            {
                for (k = 0; k < dtDeduction.Rows.Count; k++)
                {
                    dt.Columns.Add(dtDeduction.Rows[k]["SalaryHead_Short"].ToString());
                }
            }
            dt.Columns.Add("Total Deduction", typeof(double));
            dt.Columns.Add("Net Pay", typeof(double));
           
            dt.Columns.Add("Signature");
            return dt;
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

        private DataTable GetSalaryDetails()
        {
            intIncr = 0;
            decTotalDeduc = 0.00m;
            decTotalPF = 0.00m;
            decGrossPay = 0.00m;
            DataTable dtSalaryDetails = GetHeaders();
            DataTable dtErn = EarnSalaryHead();
            DataTable dtDeduction = DeductionHead();
            DataTable dtPF = PFHead();
            DataTable dtEmpDet = EmpDeatilsHead();
            DataTable dtEmp = GetEmpDetails();
            DataTable dtAmount = new DataTable();

            if (dtEmp.Rows.Count > 0)
            {
                for (int i = 0; i < dtEmp.Rows.Count; i++)
                {
                    decTotalDeduc = 0.00m; decTotalPF = 0.00m; decGrossPay = 0.00m;
                    DataTable dtSummary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryMast where Emp_Id='" + dtEmp.Rows[i]["ID"].ToString() + "' and Month='" + cmbMonth.Text + "' and Session='" + cmbSession.Text + "'");
                    dtSalaryDetails.Rows.Add();
                    dtSalaryDetails.Rows[i]["Serial"] = i + 1;
                    dtSalaryDetails.Rows[i]["ID"] = dtEmp.Rows[i]["ID"];
                    dtSalaryDetails.Rows[i]["Name"] = dtEmp.Rows[i]["Employee Name"];

                    for (int j = 0; j < dtErn.Rows.Count; j++)
                    {
                        dtSalaryDetails.Rows[i][dtErn.Rows[j]["SalaryHead_Short"].ToString()] = "0.00";
                        dtAmount = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where Session='" + cmbSession.Text + "' and Month='" + cmbMonth.Text.Trim() + "' and TableName='tbl_Employee_ErnSalaryHead' and SalId='" + dtErn.Rows[j]["SlNo"] + "' and EmpId='" + dtEmp.Rows[i]["ID"] + "'");
                        if (dtAmount.Rows.Count > 0)
                        {
                            if (!String.IsNullOrEmpty(dtAmount.Rows[0]["Amount"].ToString()))
                            {
                                dtSalaryDetails.Rows[i][dtErn.Rows[j]["SalaryHead_Short"].ToString()] = dtAmount.Rows[0]["Amount"].ToString();
                                decGrossPay += Convert.ToDecimal(dtAmount.Rows[0]["Amount"]);
                            }
                        }
                    }
                    DataTable dt = VariableWithValue(dtEmp.Rows[i]["ID"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        dtSalaryDetails.Rows[i]["Days Present"] = dt.Rows[0]["Variable Details"].ToString();
                        dtSalaryDetails.Rows[i]["LP"] = dt.Rows[1]["Variable Details"].ToString();
                        dtSalaryDetails.Rows[i]["LWP"] = dt.Rows[2]["Variable Details"].ToString();
                        dtSalaryDetails.Rows[i]["Total Days Charged"] = dt.Rows[3]["Variable Details"].ToString();
                        dtSalaryDetails.Rows[i]["Total Days"] = dt.Rows[4]["Variable Details"].ToString();
                    }

                    int l = 0;

                    if (dtPF.Rows.Count > 0)
                    {
                        for (int k = 0; k < dtPF.Rows.Count; k++)
                        {
                            dtSalaryDetails.Rows[i][dtPF.Rows[k]["ShortName"].ToString()] = "0.00";
                            dtAmount = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where Session='" + cmbSession.Text + "' and Month='" + cmbMonth.Text.Trim() + "' and TableName='tbl_Employee_Config_PFHeads' and SalId='" + dtPF.Rows[l]["SlNo"] + "' and EmpId='" + dtEmp.Rows[i]["ID"] + "'");
                            if (dtAmount.Rows.Count > 0)
                            {
                                if (!String.IsNullOrEmpty(dtAmount.Rows[0]["Amount"].ToString()))
                                {
                                    dtSalaryDetails.Rows[i][dtPF.Rows[k]["ShortName"].ToString()] = dtAmount.Rows[0]["Amount"].ToString();
                                    decTotalPF += Convert.ToDecimal(dtAmount.Rows[0]["Amount"]);
                                }
                            }
                            l++;
                        }
                    }

                    dtSalaryDetails.Rows[i]["Total Deduction"] = "0.00";
                    if (dtDeduction.Rows.Count > 0)
                    {
                        for (int k = 0; k < dtDeduction.Rows.Count; k++)
                        {
                            dtSalaryDetails.Rows[i][dtDeduction.Rows[k]["SalaryHead_Short"].ToString()] = "0.00";
                            dtAmount = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where Session='" + cmbSession.Text + "' and Month='" + cmbMonth.Text.Trim() + "' and TableName='tbl_Employee_DeductionSalayHead' and SalId='" + dtDeduction.Rows[k]["SlNo"] + "' and EmpId='" + dtEmp.Rows[i]["ID"] + "'");
                            if (dtAmount.Rows.Count > 0)
                            {
                                if (!String.IsNullOrEmpty(dtAmount.Rows[0]["Amount"].ToString()))
                                {
                                    dtSalaryDetails.Rows[i][dtDeduction.Rows[k]["SalaryHead_Short"].ToString()] = dtAmount.Rows[0]["Amount"].ToString();
                                    decTotalDeduc += Convert.ToDecimal(dtAmount.Rows[0]["Amount"]);
                                }
                            }
                        }
                        dtSalaryDetails.Rows[i]["Total Deduction"] = decTotalDeduc + decTotalPF;
                    }

                    dtSalaryDetails.Rows[i]["Gross Amount"] = "0.00";
                    dtSalaryDetails.Rows[i]["P.F Due"] = "0.00";
                    dtSalaryDetails.Rows[i]["Total PF"] = "0.00";

                    if (dtSummary.Rows.Count > 0)
                    {
                        dtSalaryDetails.Rows[i]["Total Salary"] = dtSummary.Rows[0]["TotalSal"].ToString();
                        dtSalaryDetails.Rows[i]["Gross Amount"] = decGrossPay.ToString();
                        dtSalaryDetails.Rows[i]["P.F Due"] = dtSummary.Rows[0]["PFDue"].ToString();
                        dtSalaryDetails.Rows[i]["Total PF"] = decTotalPF.ToString();
                    }
                    dtSalaryDetails.Rows[i]["Net Pay"] = decGrossPay - (decTotalDeduc + decTotalPF);

                    intIncr += dtErn.Rows.Count;
                }
            }
            return dtSalaryDetails;
        }
        private void GetPrint()
        {
            DataTable dt = GetSalaryDetails();
            SimpleTextReport Aquittance = new SimpleTextReport();
            Aquittance.CharactersToALine = 225;
            Aquittance.MainPageHeaders.Add();
            Aquittance.MainPageHeaders[0].Text = "Page No:-1" + Space(9) + "RISHRA VANI BHARATI";
            Aquittance.MainPageHeaders[0].Bold = true;
            Aquittance.MainPageHeaders[0].Expanded = true;
            Aquittance.MainPageHeaders[0].Alignment = SimpleTextReport.PutTextAlign.Left;
            Aquittance.MainPageHeaders.Add();
            Aquittance.MainPageHeaders[1].Text = " ";

            Aquittance.MainPageHeaders.Add();
            Aquittance.MainPageHeaders[2].Text = "Aquittance for The Month " + cmbSession.Text.Trim()+" "+cmbSession.Text.Trim();
            Aquittance.MainPageHeaders[2].Bold = true;
            Aquittance.MainPageHeaders[2].Alignment = SimpleTextReport.PutTextAlign.Left;

            Aquittance.ActiveDataTable = true;
            Aquittance.DataTable = dt;

            int intColNo = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                Aquittance.ReportColumns.Add();

                if (dc.ColumnName.ToString() == "SlNo")
                {
                    Aquittance.ReportColumns[intColNo].Header.Text.Add(dc.ColumnName);
                    Aquittance.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    Aquittance.ReportColumns[intColNo].LinesToAColumn = 5;
                    Aquittance.ReportColumns[intColNo].Header.Condensed = true;
                    Aquittance.ReportColumns[intColNo].TDataTable = dt;
                    Aquittance.ReportColumns[intColNo].Condensed = true;
                    Aquittance.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Aquittance.ReportColumns[intColNo].Borderget = true;

                }

                else if (dc.ColumnName.ToString() == "Name")
                {
                    Aquittance.ReportColumns[intColNo].Header.Text.Add("       " + dc.ColumnName);
                    Aquittance.ReportColumns[intColNo].LinesToAColumn = 28;
                    Aquittance.ReportColumns[intColNo].Header.Condensed = true;
                    Aquittance.ReportColumns[intColNo].TDataTable = dt;
                    Aquittance.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;
                    Aquittance.ReportColumns[intColNo].Condensed = true;
                    Aquittance.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Aquittance.ReportColumns[intColNo].Borderget = true;
                }           

                else if (dc.ColumnName.ToString() == "Signature")
                {
                    Aquittance.ReportColumns[intColNo].Header.Text.Add("          Sign");
                    Aquittance.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;

                    Aquittance.ReportColumns[intColNo].LinesToAColumn = 12;
                    Aquittance.ReportColumns[intColNo].Header.Condensed = true;
                    Aquittance.ReportColumns[intColNo].TDataTable = dt;
                    Aquittance.ReportColumns[intColNo].Condensed = true;
                    Aquittance.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();

                }
                else
                {

                    Aquittance.ReportColumns[intColNo].Header.Text.Add("      " + dc.ColumnName);
                    Aquittance.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;

                    Aquittance.ReportColumns[intColNo].LinesToAColumn = 13;
                    Aquittance.ReportColumns[intColNo].Header.Condensed = true;
                    Aquittance.ReportColumns[intColNo].TDataTable = dt;
                    Aquittance.ReportColumns[intColNo].Condensed = true;
                    Aquittance.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Aquittance.ReportColumns[intColNo].Borderget = true;
                }
                intColNo += 1;
            }

            Aquittance.CustomisedSection.Add();
            Aquittance.CustomisedSection[0].Position = SimpleTextReport.Position.AtEndofPage;
            Aquittance.CustomisedSection[0].Lines.Add();
            Aquittance.CustomisedSection[0].Lines[0].Cells.Add();
            Aquittance.CustomisedSection[0].Lines[0].Cells[0].Text = "Prepared By:............";

            Aquittance.Print();
        }


        private void AquittanceReport_Load(object sender, EventArgs e)
        {
            //generate year
            clsValidation.GenerateYear(cmbSession, 1950, System.DateTime.Now.Year, 1);
            //

            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbSession.SelectedIndex = 0;
            }
            else
            {
                cmbSession.SelectedIndex = 1;
            }
        }

        private void cmbMonth_DropDown(object sender, EventArgs e)
        {
            cmbMonth.Items.Clear();
            cmbMonth.Items.Add("January");
            cmbMonth.Items.Add("February");
            cmbMonth.Items.Add("March");
            cmbMonth.Items.Add("April");
            cmbMonth.Items.Add("May");
            cmbMonth.Items.Add("June");
            cmbMonth.Items.Add("July");
            cmbMonth.Items.Add("August");
            cmbMonth.Items.Add("September");
            cmbMonth.Items.Add("October");
            cmbMonth.Items.Add("November");
            cmbMonth.Items.Add("December");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            GetPrint();
        }

        
    }
}