using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class IncrementSalary : EDPComponent.FormBaseERP
    {
        public IncrementSalary()
        {
            InitializeComponent();
        }

        public Int32 intEmpDet = 0;
        String[,] strCount;
        DataTable dtInc = new DataTable();
        Decimal decPreInc = 0.00m;
        

        #region Function

        private Boolean ValiadtionInc()
        {
            Boolean boolStatus = false;

            if (clsValidation.ValidateLabel(lblEmpId, "", "Please Select An Employee To Increament"))
            {
                if (clsValidation.ValidateComboBox(cmbSalHead, "", "Please Select A Salary Head"))
                {
                    if (rdoPercentage.Checked || rdoAmount.Checked)
                    {
                        String strMsg = String.Empty;
                        if (rdoPercentage.Checked)
                            strMsg = "Percentage";
                        else if (rdoAmount.Checked)
                            strMsg = "Amount";
                        if (clsValidation.ValidateTextBox(txtAmount, "", "Please Enter " + strMsg))
                        {
                            boolStatus = true;
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Payment Mode of Increament");
                    }
                }
            }
            return boolStatus;
        }

        private Boolean Validation()
        {
            Boolean boolStatus = false;
            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Select Session"))
            {
                if (clsValidation.ValidateComboBox(cmbMonth, "", "Please Select Month"))
                {
                    boolStatus = true;
                }
            }
            return boolStatus;
        }

        private void CheckPayMode()
        {
            if (clsValidation.ValidateComboBox(cmbSalHead, ""))
            {
                if (rdoPercentage.Checked)
                {
                    txtAmount.Enabled = true;
                    txtAmount.Text = String.Empty;
                    txtAmount.BackColor = Color.White;
                    lblText.Text = "% of " + cmbSalHead.Text.Trim();
                }
                else if (rdoAmount.Checked)
                {
                    txtAmount.Enabled = true;
                    txtAmount.Text = String.Empty;
                    txtAmount.BackColor = Color.White;
                    lblText.Text = "( Rs. )";
                }
                else
                {
                    txtAmount.Enabled = false;
                    txtAmount.Text = String.Empty;
                    txtAmount.BackColor = Color.Silver;
                    lblText.Text = String.Empty;
                }
            }
            else
            {
                if (!rdoPercentage.Checked && !rdoAmount.Checked)
                {
                    ERPMessageBox.ERPMessage.Show("Please Enter Salary Head");
                }
                rdoPercentage.Checked = false;
                rdoAmount.Checked = false;
                
            }
        }

        private void PopulateSalaryHeadCombo(ComboBox cmb)
        {
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");
            if (dtErn.Rows.Count > 0)
            {
                cmb.Items.Clear();
                for (Int32 i = 0; i < dtErn.Rows.Count; i++)
                {
                    cmb.Items.Add(dtErn.Rows[i]["SalaryHead_Short"]);
                }
            }
        }

        private String GetSession(Int32 intYear)
        {
            if (intYear.ToString().Length == 4)
            {
                return Convert.ToString((intYear) + "-" + (intYear + 1));
            }
            else
            {
                return String.Empty;
            }
        }

        private void MakeGridReadOnly(DataGridView dg)
        {
            if (dg.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dg.Columns.Count; i++)
                {
                    dg.Columns[i].ReadOnly = true;
                }
            }
        }
        
        private void GetGridHeader()
        {
            dgEmpSal.Columns.Add("ID", "ID");
            dgEmpSal.Columns["ID"].ReadOnly = true;
            dgEmpSal.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgEmpSal.Columns.Add("Name", "Name");
            dgEmpSal.Columns["Name"].ReadOnly = true;
            dgEmpSal.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgEmpSal.Columns["Name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgEmpSal.Columns.Add("Designation", "Desg.");
            dgEmpSal.Columns["Designation"].ReadOnly = true;
            dgEmpSal.Columns["Designation"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgEmpSal.Columns["Designation"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            DataTable dt = GetSalaryHeads();
            if (dt.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    dgEmpSal.Columns.Add(Convert.ToString(dt.Rows[i]["SalaryHead"]), Convert.ToString(dt.Rows[i]["SalaryHead"]));
                    if (Convert.ToString(dt.Rows[i]["SalaryHead"]).ToLower() == "basic")
                    {
                        dgEmpSal.Columns[Convert.ToString(dt.Rows[i]["SalaryHead"])].ReadOnly = false;

                    }
                    else
                    {
                        //dgEmpSal.Columns[Convert.ToString(dt.Rows[i]["SalaryHead"])].ReadOnly = true;
                    }
                    dgEmpSal.Columns[Convert.ToString(dt.Rows[i]["SalaryHead"])].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgEmpSal.Columns[Convert.ToString(dt.Rows[i]["SalaryHead"])].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
            }
            //dgEmpSal.Columns.Add("Total", "Net Salary");
            //dgEmpSal.Columns["Total"].ReadOnly = true;
        }

        private DataTable GetSalaryHeads()
        {
            DataTable dtSalaryHead = new DataTable();
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");
            DataTable dtPF = clsDataAccess.RunQDTbl("select ShortName,SlNo from tbl_Employee_Config_PFHeads ");
            //String[,] strArr = new String[dtErn.Rows.Count + dtDeduction.Rows.Count, strColCount];
            dtSalaryHead.Columns.Add("SalaryHead");
            dtSalaryHead.Columns.Add("ID");
            dtSalaryHead.Columns.Add("TableName");

            for (Int32 i = 0; i < dtErn.Rows.Count; i++)
            {
                dtSalaryHead.Rows.Add();
                dtSalaryHead.Rows[i]["SalaryHead"] = Convert.ToString(dtErn.Rows[i]["SalaryHead_Short"]);
                dtSalaryHead.Rows[i]["ID"] = Convert.ToString(dtErn.Rows[i]["SlNo"]);
                dtSalaryHead.Rows[i]["TableName"] = Convert.ToString("tbl_Employee_ErnSalaryHead");
            }

            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Total Salary";
            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "No Of Days Present";
            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Leave With Pay";
            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Leave With out Pay";
            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Total days";
            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Gross Amount";
            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Amount on Which P.F. Due";

            for (Int32 i = 0; i < dtPF.Rows.Count; i++)
            {
                dtSalaryHead.Rows.Add();
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = Convert.ToString(dtPF.Rows[i]["ShortName"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["ID"] = Convert.ToString(dtPF.Rows[i]["SlNo"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["TableName"] = Convert.ToString("tbl_Employee_Config_PFHeads");
            }

            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Total PF";

            for (Int32 i = 0; i < dtDeduction.Rows.Count; i++)
            {
                dtSalaryHead.Rows.Add();
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = Convert.ToString(dtDeduction.Rows[i]["SalaryHead_Short"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["ID"] = Convert.ToString(dtDeduction.Rows[i]["SlNo"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["TableName"] = Convert.ToString("tbl_Employee_DeductionSalayHead");
            }

            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Total Deduc.";
            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Net Pay";
            return dtSalaryHead;
        }        

        private void GetEmployeeDetails()
        {
            Int32 intSalHead = 0;
            //dgEmpSal.Columns["Basic"].ValueType = System.Type.GetType("Decimal");
            DataTable dtEmp = clsDataAccess.RunQDTbl("select emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName Name,desg.DesignationName from tbl_Employee_Mast emp,tbl_Employee_DesignationMaster desg where emp.DesgId=desg.SlNo");
            if (dtEmp.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dtEmp.Rows.Count; i++)
                {
                    dgEmpSal.Rows.Add();

                    dgEmpSal.Rows[i].Cells["Name"].Value = dtEmp.Rows[i]["Name"];
                    dgEmpSal.Rows[i].Cells["Designation"].Value = dtEmp.Rows[i]["DesignationName"];

                    intEmpDet = 3;

                    DataTable dtSal = GetSalaryHeads();
                    if (dtSal.Rows.Count > 0)
                    {
                        for (Int32 j = 0; j < dtSal.Rows.Count; j++)
                        {
                            if (!String.IsNullOrEmpty(Convert.ToString(dtSal.Rows[j]["ID"])))
                            {
                                //intSalHead += 1;
                                if (CheckForExDetRecord(Convert.ToString(dtEmp.Rows[i]["ID"]), GetSession(Convert.ToInt32(cmbYear.Text.Trim())), cmbMonth.Text.Trim(), Convert.ToString(dtSal.Rows[j]["SalaryHead"])))
                                {
                                    DataTable dtEx = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + Convert.ToString(dtEmp.Rows[i]["ID"]) + "' and Session='" + GetSession(Convert.ToInt32(cmbYear.Text.Trim())) + "' and Month='" + cmbMonth.Text.Trim() + "' and SalId=" + GetSalDetAccSalaryHead(Convert.ToString(dtSal.Rows[j]["SalaryHead"]))[0] + " and TableName='" + GetSalDetAccSalaryHead(Convert.ToString(dtSal.Rows[j]["SalaryHead"]))[1] + "'");
                                    if (dtEx.Rows.Count > 0)
                                    {
                                        dgEmpSal.Rows[i].Cells[Convert.ToString(dtSal.Rows[j]["SalaryHead"])].Value = dtEx.Rows[0]["Amount"];
                                    }
                                    else
                                    {
                                        dgEmpSal.Rows[i].Cells[Convert.ToString(dtSal.Rows[j]["SalaryHead"])].Value = "0.00";
                                    }
                                }
                            }
                        }
                    }

                    if (CheckForExMastRecord(Convert.ToString(dtEmp.Rows[i]["ID"]), GetSession(Convert.ToInt32(cmbYear.Text.Trim())), cmbMonth.Text.Trim()))
                    {
                        DataTable dtMast = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryMast where Emp_Id='" + Convert.ToString(dtEmp.Rows[i]["ID"]) + "' and Session='" + GetSession(Convert.ToInt32(cmbYear.Text.Trim())) + "' and Month='" + cmbMonth.Text.Trim() + "'");
                        if (dtMast.Rows.Count > 0)
                        {
                            dgEmpSal.Rows[i].Cells["Total Salary"].Value = dtMast.Rows[0]["TotalSal"];
                            dgEmpSal.Rows[i].Cells["No Of Days Present"].Value = dtMast.Rows[0]["DaysPresent"];
                            dgEmpSal.Rows[i].Cells["Leave With Pay"].Value = dtMast.Rows[0]["LeaveWithPay"];
                            dgEmpSal.Rows[i].Cells["Leave With out Pay"].Value = dtMast.Rows[0]["LeaveWithoutPay"];
                            dgEmpSal.Rows[i].Cells["Total days"].Value = dtMast.Rows[0]["TotalDays"];
                            dgEmpSal.Rows[i].Cells["Gross Amount"].Value = dtMast.Rows[0]["GrossAmount"];
                            dgEmpSal.Rows[i].Cells["Amount on Which P.F. Due"].Value = dtMast.Rows[0]["PFDue"];
                            dgEmpSal.Rows[i].Cells["Total PF"].Value = dtMast.Rows[0]["TotalPF"];
                            dgEmpSal.Rows[i].Cells["Total Deduc."].Value = dtMast.Rows[0]["TotalDec"];
                            dgEmpSal.Rows[i].Cells["Net Pay"].Value = dtMast.Rows[0]["NetPay"];
                        }
                        else
                        {
                            dgEmpSal.Rows[i].Cells["Total Salary"].Value = 0.00;
                            dgEmpSal.Rows[i].Cells["No Of Days Present"].Value = 0;
                            dgEmpSal.Rows[i].Cells["Leave With Pay"].Value = 0;
                            dgEmpSal.Rows[i].Cells["Leave With out Pay"].Value = 0;
                            dgEmpSal.Rows[i].Cells["Total days"].Value = 0;
                            dgEmpSal.Rows[i].Cells["Gross Amount"].Value = 0.00;
                            dgEmpSal.Rows[i].Cells["Amount on Which P.F. Due"].Value = 0.00;
                            dgEmpSal.Rows[i].Cells["Total PF"].Value = 0.00;
                            dgEmpSal.Rows[i].Cells["Total Deduc."].Value = 0.00;
                            dgEmpSal.Rows[i].Cells["Net Pay"].Value = 0.00;
                        }
                    }
                    dgEmpSal.Rows[i].Cells["ID"].Value = dtEmp.Rows[i]["ID"];
                }
            }
        }

        private String[] GetSalDetAccSalaryHead(String strSalaryHead)
        {
            String[] strTable = new String[2];
            DataTable dt = GetSalaryHeads();
            if (dt.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    if (strSalaryHead == Convert.ToString(dt.Rows[i]["SalaryHead"]))
                    {
                        strTable[0] = Convert.ToString(dt.Rows[i]["ID"]);
                        strTable[1] = Convert.ToString(dt.Rows[i]["TableName"]);
                    }
                }
            }
            return strTable;
        }

        private Boolean CheckForExDetRecord(String strEmpId, String strSession, String strMonth, String strSalHead)
        {
            Boolean boolStatus = false;
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + strEmpId + "' and Session='" + strSession + "' and Month='" + strMonth + "' and SalId=" + GetSalDetAccSalaryHead(strSalHead)[0] + " and TableName='" + GetSalDetAccSalaryHead(strSalHead)[1] + "'");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }
            return boolStatus;
        }

        private Boolean CheckForExMastRecord(String strEmpId, String strSession, String strMonth)
        {
            Boolean boolStatus = false;
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryMast where Emp_Id='" + strEmpId + "' and Session='" + strSession + "' and Month='" + strMonth + "'");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }
            return boolStatus;
        }

        private void GetTotalCalculation()
        {
            GetTotalSalary();
            GetTotalDeduction();
            GetGrossAmount();
            GetNetPay();
            GetTotalDaysByMonthForGrid();
            GetTotalPF();
        }

        private Int32 GetTotalErnHeads()
        {
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");
            return dtErn.Rows.Count;
        }

        private void GetTotalPF()
        {
            if (dgEmpSal.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
                {
                    Decimal decTotalPF = 0.00m;
                    for (Int32 j = (dgEmpSal.Rows[i].Cells["Amount on Which P.F. Due"].ColumnIndex + 1); j < dgEmpSal.Rows[i].Cells["Total PF"].ColumnIndex; j++)
                    {
                        Decimal decPF = 0.00m;
                        if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells[j].Value)))
                        {
                            decPF = Convert.ToDecimal(dgEmpSal.Rows[i].Cells[j].Value);
                        }
                        decTotalPF += decPF;
                    }
                    dgEmpSal.Rows[i].Cells["Total PF"].Value = decTotalPF;
                }
            }
        }

        private void GetTotalSalary()
        {
            if (dgEmpSal.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
                {
                    Decimal decTotalSal = 0.00m;
                    for (Int32 j = (intEmpDet); j < ((GetTotalErnHeads() + intEmpDet)); j++)
                    {
                        Decimal decsal = 0.00m;
                        if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells[j].Value)))
                        {
                            decsal = Convert.ToDecimal(dgEmpSal.Rows[i].Cells[j].Value);
                        }
                        decTotalSal += decsal;
                    }
                    dgEmpSal.Rows[i].Cells["Total Salary"].Value = decTotalSal;
                }
            }
        }

        private void GetTotalDeduction()
        {
            if (dgEmpSal.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
                {
                    Decimal decTotalDeduc = 0.00m;
                    for (Int32 j = dgEmpSal.Rows[i].Cells["Total PF"].ColumnIndex; j < dgEmpSal.Rows[i].Cells["Total Deduc."].ColumnIndex; j++)
                    {
                        Decimal decDeduc = 0.00m;
                        if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells[j].Value)))
                        {
                            decDeduc = Convert.ToDecimal(dgEmpSal.Rows[i].Cells[j].Value);
                        }
                        decTotalDeduc += decDeduc;
                    }
                    dgEmpSal.Rows[i].Cells["Total Deduc."].Value = decTotalDeduc;
                }
            }
        }

        private void GetNetPay()
        {
            if (dgEmpSal.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
                {
                    Decimal decGrossAmount = 0.00m;
                    if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells["Gross Amount"].Value)))
                    {
                        decGrossAmount = Convert.ToDecimal(Convert.ToString(dgEmpSal.Rows[i].Cells["Gross Amount"].Value));
                    }

                    Decimal decTotalDec = 0.00m;
                    if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells["Total Deduc."].Value)))
                    {
                        decTotalDec = Convert.ToDecimal(Convert.ToString(dgEmpSal.Rows[i].Cells["Total Deduc."].Value));
                    }
                    if (decGrossAmount > decTotalDec)
                    {
                        dgEmpSal.Rows[i].Cells["Net Pay"].Value = decGrossAmount - decTotalDec;
                    }
                    else
                    {
                        dgEmpSal.Rows[i].Cells["Net Pay"].Value = "0.00";
                    }
                }
            }
        }

        private void GetTotalDaysByMonthForGrid()
        {
            if (dgEmpSal.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
                {
                    dgEmpSal.Rows[i].Cells["Total days"].Value = GetTotalDaysByMonth(cmbMonth.Text.Trim(), GetYear(cmbMonth.Text.Trim(), cmbYear.Text.Trim()));
                }
            }
        }

        private Int32 GetYear(String strFullMonthNameMonth, String strSession)
        {
            Int32 intYear = 0;
            String[] strArr = new String[2];
            strArr = strSession.Split('-');
            if (!String.IsNullOrEmpty(strFullMonthNameMonth))
            {
                if (strFullMonthNameMonth.ToLower() == "april" || strFullMonthNameMonth.ToLower() == "may" || strFullMonthNameMonth.ToLower() == "june" || strFullMonthNameMonth.ToLower() == "july" || strFullMonthNameMonth.ToLower() == "august" || strFullMonthNameMonth.ToLower() == "september" || strFullMonthNameMonth.ToLower() == "october" || strFullMonthNameMonth.ToLower() == "november" || strFullMonthNameMonth.ToLower() == "december")
                {
                    intYear = Convert.ToInt32(strArr[0]);
                }
                else if (strFullMonthNameMonth.ToLower() == "january" || strFullMonthNameMonth.ToLower() == "february" || strFullMonthNameMonth.ToLower() == "march")
                {
                    intYear = Convert.ToInt32(strArr[1]);
                }
            }
            return intYear;
        }

        private Int32 GetTotalDaysByMonth(String strFullMonthNameMonth, Int32 intYear)
        {
            Int32 intDays = 0;
            if (Convert.ToString(intYear).Length == 4)
            {
                if (!String.IsNullOrEmpty(strFullMonthNameMonth))
                {
                    if (strFullMonthNameMonth.ToLower() == "february")
                    {
                        if ((intYear > 0) && (intYear % 4 == 0))
                        {
                            intDays = 29;
                        }
                        else
                        {
                            intDays = 28;
                        }
                    }
                    else if (strFullMonthNameMonth.ToLower() == "january" || strFullMonthNameMonth.ToLower() == "march" || strFullMonthNameMonth.ToLower() == "may" || strFullMonthNameMonth.ToLower() == "july" || strFullMonthNameMonth.ToLower() == "august" || strFullMonthNameMonth.ToLower() == "october" || strFullMonthNameMonth.ToLower() == "december")
                    {
                        intDays = 31;
                    }
                    else if (strFullMonthNameMonth.ToLower() == "april" || strFullMonthNameMonth.ToLower() == "june" || strFullMonthNameMonth.ToLower() == "september" || strFullMonthNameMonth.ToLower() == "november")
                    {
                        intDays = 30;
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("No Such Month Exists");
                    }
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Please Enter Valid Year.");
            }
            return intDays;
        }

        private void GetGrossAmount()
        {
            if (dgEmpSal.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
                {
                    Int32 intLWP = 0;
                    Decimal decGrossAmount = 0.00m;
                    if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells["Leave With out Pay"].Value)))
                    {
                        intLWP = Convert.ToInt32(dgEmpSal.Rows[i].Cells["Leave With out Pay"].Value);
                    }
                    if (intLWP > 0)
                    {
                        Decimal decTotalSal = 0.00m;
                        if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells["Total Salary"].Value)))
                        {
                            decTotalSal = Convert.ToDecimal(Convert.ToString(dgEmpSal.Rows[i].Cells["Total Salary"].Value));
                        }
                        decGrossAmount = Convert.ToDecimal(decTotalSal / intLWP);

                    }
                    dgEmpSal.Rows[i].Cells["Gross Amount"].Value = dgEmpSal.Rows[i].Cells["Total Salary"].Value;
                }
            }
        }

        private Decimal[] Increament(Decimal decPreInc)
        {
            Decimal [] decInc=new Decimal[2]; 
            Decimal decAmt = 0.00m;
            Decimal decAmtInc = Convert.ToInt32(txtAmount.Text.Trim());
            if (!String.IsNullOrEmpty(Convert.ToString(decPreInc)))
            {
                decAmt = Convert.ToDecimal(decPreInc);
            }

            if (rdoPercentage.Checked)
            {
                decAmtInc = decAmt * (decAmtInc / 100);
            }

            decInc[0] = Convert.ToDecimal(decAmt + decAmtInc);
            decInc[1] = decAmtInc;
           // dgEmpSal.CurrentRow.Cells[cmbSalHead.Text.Trim()].Value = Convert.ToDecimal(decAmt + decAmtInc).ToString("0.00");

            return decInc;
        }

        private void CreateBlankIncTable(DataTable dt)
        {
            dt.Columns.Add("EmpId");
            dt.Columns.Add("Month");
            dt.Columns.Add("Session");
            dt.Columns.Add("SalId");
            dt.Columns.Add("Mode");
            dt.Columns.Add("Amt");
            dt.Columns.Add("IncAmount");
        }

        private void SaveIncrementToTable()
        {
            if (dtInc.Rows.Count <= 0)
            {
                CreateBlankIncTable(dtInc);
            }

            dtInc.Rows.Add();
            dtInc.Rows[dtInc.Rows.Count - 1]["EmpId"] = lblEmpId.Text.Trim();
            dtInc.Rows[dtInc.Rows.Count - 1]["Month"] = cmbMonth.Text.Trim();
            dtInc.Rows[dtInc.Rows.Count - 1]["Session"] = cmbYear.Text.Trim();
            dtInc.Rows[dtInc.Rows.Count - 1]["SalId"] = GetSalDetAccSalaryHead(cmbSalHead.Text.Trim())[0];
            dtInc.Rows[dtInc.Rows.Count - 1]["Mode"] = GetPayMode();
            dtInc.Rows[dtInc.Rows.Count - 1]["Amt"] = txtAmount.Text.Trim();
            dtInc.Rows[dtInc.Rows.Count - 1]["IncAmount"] = Increament(decPreInc)[1].ToString("0.00");
        }

        private String GetPayMode()
        {
            String strMode = String.Empty;

            if (rdoPercentage.Checked)
            {
                strMode = "Percentage";
            }
            else if (rdoAmount.Checked)
            {
                strMode = "Amount";
            }

            return strMode;
        }

        private void ClearIncreamentTable()
        {
            dtInc.Clear();
        }

        private Boolean SaveAllIncreaments()
        {
            Boolean boolStatus = false;
            Boolean boolReturn = false;
            Int32 intCount = 0;
            String strMode=String.Empty;           

            for (Int32 i = 0; i < dtInc.Rows.Count; i++)
            {
                if (!CheckExInc(Convert.ToString(dtInc.Rows[i]["EmpId"]), cmbMonth.Text.Trim(), Convert.ToInt32(cmbYear.Text.Trim()), Convert.ToInt32(dtInc.Rows[i]["SalId"])))
                {
                    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_IncrementDetails(EmpId,Month,Session,SalId,Mode,Amount,IncAmount) values('" + dtInc.Rows[i]["EmpId"] + "','" + dtInc.Rows[i]["Month"] + "'," + dtInc.Rows[i]["Session"] + "," + dtInc.Rows[i]["SalId"] + ",'" + dtInc.Rows[i]["Mode"] + "'," + dtInc.Rows[i]["Amt"] + "," + dtInc.Rows[i]["IncAmount"] + ")");
                }
                else
                {
                    boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_IncrementDetails set IncAmount=" + dtInc.Rows[i]["IncAmount"] + ",Mode='" + dtInc.Rows[i]["Mode"] + "',Amount=" + dtInc.Rows[i]["Amt"] + " where EmpId='" + dtInc.Rows[i]["EmpId"] + "' and Month='" + dtInc.Rows[i]["Month"] + "' and Session=" + dtInc.Rows[i]["Session"] + " and SalId=" + dtInc.Rows[i]["SalId"]);
                }
                if(boolStatus)
                {
                    ClearIncreamentCount(Convert.ToString(dtInc.Rows[i]["EmpId"]));
                    intCount += 1;
                }
            }

            if (intCount == dtInc.Rows.Count)
            {
                boolReturn = true;
            }
            return boolReturn;
        }

        private Boolean SubmitEmpSal()
        {
            Boolean boolStatus = false;
            Boolean boolReturn = false;
            
            Int32 intCounter = 0;

            if (Validation())
            {
                if (dgEmpSal.Rows.Count > 0)
                {
                    for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
                    {
                        String strEmpId = Convert.ToString(dgEmpSal.Rows[i].Cells["ID"].Value);
                        String strTotalSal = Convert.ToString(dgEmpSal.Rows[i].Cells["Total Salary"].Value);
                        if (String.IsNullOrEmpty(strTotalSal))
                        {
                            strTotalSal = "0.00";
                        }

                        String strTotalDec = Convert.ToString(dgEmpSal.Rows[i].Cells["Total Deduc."].Value);
                        if (String.IsNullOrEmpty(strTotalDec))
                        {
                            strTotalDec = "0.00";
                        }

                        String strNetPay = Convert.ToString(dgEmpSal.Rows[i].Cells["Net Pay"].Value);
                        if (String.IsNullOrEmpty(strNetPay))
                        {
                            strNetPay = "0.00";
                        }

                        String strPresent = Convert.ToString(dgEmpSal.Rows[i].Cells["No Of Days Present"].Value);
                        if (String.IsNullOrEmpty(strPresent))
                        {
                            strPresent = "0";
                        }

                        String strLP = Convert.ToString(dgEmpSal.Rows[i].Cells["Leave With Pay"].Value);
                        if (String.IsNullOrEmpty(strLP))
                        {
                            strLP = "0";
                        }

                        String strLWP = Convert.ToString(dgEmpSal.Rows[i].Cells["Leave With out Pay"].Value);
                        if (String.IsNullOrEmpty(strLWP))
                        {
                            strLWP = "0";
                        }

                        String strTotalDays = Convert.ToString(dgEmpSal.Rows[i].Cells["Total days"].Value);
                        if (String.IsNullOrEmpty(strTotalDays))
                        {
                            strTotalDays = "0";
                        }

                        String strGrossAmount = Convert.ToString(dgEmpSal.Rows[i].Cells["Gross Amount"].Value);
                        if (String.IsNullOrEmpty(strGrossAmount))
                        {
                            strGrossAmount = "0.00";
                        }

                        String strPFDue = Convert.ToString(dgEmpSal.Rows[i].Cells["Amount on Which P.F. Due"].Value);
                        if (String.IsNullOrEmpty(strPFDue))
                        {
                            strPFDue = "0.00";
                        }

                        String strTotalPF = Convert.ToString(dgEmpSal.Rows[i].Cells["Total PF"].Value);
                        if (String.IsNullOrEmpty(strTotalPF))
                        {
                            strTotalPF = "0.00";
                        }

                        String strSession = cmbYear.Text.Trim() + "-" + (Convert.ToInt32(cmbYear.Text.Trim()) + 1);

                        if (!String.IsNullOrEmpty(strEmpId))
                        {
                            
                            if (CheckForExMastRecord(strEmpId, strSession, cmbMonth.Text.Trim()))
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("UPDATE [tbl_Employee_SalaryMast] SET [TotalSal] = " + strTotalSal + ",[DaysPresent] = " + strPresent + ",[LeaveWithPay] = " + strLP + ",[LeaveWithoutPay] = " + strLWP + ",[TotalDays] = " + strTotalDays + ",[GrossAmount] = " + strGrossAmount + ",[PFDue] = " + strPFDue + ",[TotalPF] = " + strTotalPF + ",[TotalDec] = " + strTotalDec + ",[NetPay] = " + strNetPay + " WHERE [Emp_Id] = '" + strEmpId + "' and [Month] = '" + cmbMonth.Text.Trim() + "' and [Session] = '" + strSession + "'");

                            }
                            else
                            {
                               // boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO [SchoolManagement].[tbl_Employee_SalaryMast] ([Emp_Id],[TotalSal],[DaysPresent],[LeaveWithPay],[LeaveWithoutPay],[TotalDays],[GrossAmount],[PFDue],[TotalPF],[TotalDec],[NetPay],[Month],[Session]) VALUES('" + strEmpId + "'," + strTotalSal + "," + strPresent + "," + strLP + "," + strLWP + "," + strTotalDays + "," + strGrossAmount + "," + strPFDue + "," + strTotalPF + "," + strTotalDec + "," + strNetPay + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')");
                            }
                        }
                        if (boolStatus)
                        {
                            if (SubmitEmpSalaryDet(strEmpId, i, strSession))
                            {
                                intCounter += 1;
                            }
                        }
                    }
                    if (intCounter == dgEmpSal.Rows.Count)
                    {
                        boolReturn = true;
                        //ERPMessageBox.ERPMessage.Show("Employee Salary Details Submitted Successfully ");
                    }

                }
            }
            return boolReturn;
        }

        private Boolean SubmitEmpSalaryDet(String strEmpId, Int32 intGridRowIndex,String strSession)
        {
            Int32 intCounter = 0;
            Int32 intSalHead = 0;
            Boolean boolStatus = false;
            DataTable dtSal = GetSalaryHeads();
            if (dtSal.Rows.Count > 0)
            {
                for (Int32 j = 0; j < dtSal.Rows.Count; j++)
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(dtSal.Rows[j]["ID"])))
                    {
                        intSalHead += 1;
                        if (SubmitSalaryDetails(strEmpId, strSession, cmbMonth.Text.Trim(), Convert.ToString(dtSal.Rows[j]["SalaryHead"]), Convert.ToDecimal(dgEmpSal.Rows[intGridRowIndex].Cells[Convert.ToString(dtSal.Rows[j]["SalaryHead"])].Value)))
                        {
                            intCounter += 1;
                        }
                    }
                }
                if (intCounter == intSalHead)
                {
                    boolStatus = true;
                }
            }
            return boolStatus;
        }

        private Boolean SubmitSalaryDetails(String strEmpId, String strSession, String strMonth, String strSalHead, Decimal decAmount)
        {
            Boolean boolStatus = false;
            if (CheckForExDetRecord(strEmpId, strSession, strMonth, strSalHead))
            {
                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_SalaryDet set Amount=" + decAmount + " where EmpId='" + strEmpId + "' and SalId=" + GetSalDetAccSalaryHead(strSalHead)[0] + " and Month='" + strMonth + "' and Session='" + strSession + "' and TableName='" + GetSalDetAccSalaryHead(strSalHead)[1] + "'");
            }
            else
            {
                //boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + strEmpId + "'," + GetSalDetAccSalaryHead(strSalHead)[0] + ",'" + GetSalDetAccSalaryHead(strSalHead)[1] + "'," + decAmount + ",'" + strMonth + "','" + strSession + "')");
            }
            return boolStatus;
        }
        
        private void GetCount()
        {
            strCount = new String[dgEmpSal.Rows.Count, dgEmpSal.Rows.Count];
            for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
            {
                strCount[i, 0] = Convert.ToString(dgEmpSal.Rows[i].Cells["ID"].Value);
            }
        }

        private void IncreamentCount(String strEmpId, Int32 intCount)
        {
            for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
            {
                if (strEmpId == strCount[i, 0])
                {
                 if (!String.IsNullOrEmpty(strCount[i, 1]))
                    {
                        Int32 intC = Convert.ToInt32(strCount[i, 1]);
                        intC = intCount + intC;
                        strCount[i, 1] = Convert.ToString(intC);
                    }
                    else
                    {
                        strCount[i, 1] = Convert.ToString(intCount);
                    }
                }
            }
        }

        private void ClearIncreamentCount(String strEmpId)
        {
            for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
            {
                if (strEmpId == strCount[i, 0])
                {
                    if (!String.IsNullOrEmpty(strCount[i, 1]))
                    {                        
                        strCount[i, 1] = Convert.ToString(0);
                    }                    
                }
            }
            
        }

        private Int32 GetCountByEmp(String strEmpId)
        {
            Int32 intInc = 0;
            for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
            {
                if (strEmpId == strCount[i, 0])
                {
                    if (!String.IsNullOrEmpty(strEmpId))
                    {
                        intInc = Convert.ToInt32( strCount[i, 1]);
                    }
                }
            }
            return intInc;
        }

        private Boolean  CheckExInc(String strEmpId,String strmonth,Int32 intSession,Int32 intSalId)
        {
            Boolean boolStatus = false;

            DataTable dt = clsDataAccess.RunQDTbl("select IncAmount from tbl_Employee_IncrementDetails where EmpId='" + strEmpId + "' and Month='" + strmonth + "' and Session=" + intSession + " and SalId=" + intSalId + "");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }

            return boolStatus;
        }

        private void ClearInc()
        {
            lblEmpId.Text = String.Empty;
            lblEmpName.Text = String.Empty;
            rdoAmount.Checked = false;
            rdoPercentage.Checked = false;
            cmbSalHead.Items.Clear();
            txtAmount.Text = String.Empty;
            txtAmount.Enabled = false;
            txtAmount.BackColor = Color.Silver;
            lblText.Text = String.Empty;
            lblCurrentGross.Text = String.Empty;
            lblCurrentNet.Text = String.Empty;
            lblPrevGross.Text = String.Empty;
            lblPrevNet.Text = String.Empty;
        }

        private String GetEarnSalaryName(Int32 intSalId)
        {
            String strSalName = String.Empty;

            DataTable dt = clsDataAccess.RunQDTbl("select SalaryHead_Short from tbl_Employee_ErnSalaryHead where SlNo="+intSalId+"");
            if (dt.Rows.Count > 0)
            {
                strSalName = Convert.ToString(dt.Rows[0]["SalaryHead_Short"]);
            }

            return strSalName;
        }

        #endregion



        private void IncrementSalary_Load(object sender, EventArgs e)
        {
            //generate year
            clsEmployee.GenerateYear(cmbYear);
            //

            GetGridHeader();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbMonth_DropDown(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                dgEmpSal.Rows.Clear();
                GetEmployeeDetails();
                MakeGridReadOnly(dgEmpSal);
                GetCount();
                //GetTotalCalculation();
            }
        }

        private void dgEmpSal_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ClearInc();
            lblEmpId.Text = Convert.ToString(dgEmpSal.CurrentRow.Cells["ID"].Value);
            lblEmpName.Text = Convert.ToString(dgEmpSal.CurrentRow.Cells["Name"].Value);
            lblCurrentGross.Text = Convert.ToString(dgEmpSal.CurrentRow.Cells["Total Salary"].Value);
            lblCurrentNet.Text = Convert.ToString(dgEmpSal.CurrentRow.Cells["Net Pay"].Value);            
        }

        private void cmbSalHead_DropDown(object sender, EventArgs e)
        {
            PopulateSalaryHeadCombo(cmbSalHead);
        }

        private void rdoPercentage_CheckedChanged(object sender, EventArgs e)
        {
            CheckPayMode();
        }

        private void rdoAmount_CheckedChanged(object sender, EventArgs e)
        {
            CheckPayMode();
        }

        private void btnInc_Click(object sender, EventArgs e)
        {
            IncreamentCount(lblEmpId.Text.Trim(), 1);
            if (GetCountByEmp(lblEmpId.Text.Trim()) == 1)
            {
                
                if (ValiadtionInc())
                {
                    // dgEmpSal.CurrentRow.Cells[cmbSalHead.Text.Trim()].Value=
                    lblPrevGross.Text = Convert.ToString(dgEmpSal.CurrentRow.Cells["Total Salary"].Value);
                    lblPrevNet.Text = Convert.ToString(dgEmpSal.CurrentRow.Cells["Net Pay"].Value);

                    decPreInc = Convert.ToDecimal(dgEmpSal.CurrentRow.Cells[cmbSalHead.Text.Trim()].Value);
                    dgEmpSal.CurrentRow.Cells[cmbSalHead.Text.Trim()].Value = Increament(decPreInc)[0].ToString("0.00");
                    GetTotalCalculation();

                    lblCurrentGross.Text = Convert.ToString(dgEmpSal.CurrentRow.Cells["Total Salary"].Value);
                    lblCurrentNet.Text = Convert.ToString(dgEmpSal.CurrentRow.Cells["Net Pay"].Value);
                    SaveIncrementToTable();
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Please Save Increament First For Employee Id '"+ lblEmpId.Text.Trim() +"'.");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValiadtionInc())
            {
                if (SaveAllIncreaments())
                {
                    if (SubmitEmpSal())
                    {
                        ERPMessageBox.ERPMessage.Show("Salary Increament Done Successfully");
                    }
                }
            }
        }

        private void cmbSalHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckExInc(Convert.ToString(dgEmpSal.CurrentRow.Cells["ID"].Value), cmbMonth.Text.Trim(), Convert.ToInt32(cmbYear.Text.Trim()),Convert.ToInt32( GetSalDetAccSalaryHead(cmbSalHead.Text.Trim())[0])))
            {
                DataTable dt = clsDataAccess.RunQDTbl("select Mode,Amount,IncAmount from tbl_Employee_IncrementDetails where EmpId='" + Convert.ToString(dgEmpSal.CurrentRow.Cells["ID"].Value) + "' and Month='" + cmbMonth.Text.Trim() + "' and Session=" + Convert.ToInt32(cmbYear.Text.Trim()) + " and SalId=" + GetSalDetAccSalaryHead(cmbSalHead.Text.Trim())[0] + "");
                if (dt.Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Mode"])))
                    {
                        if (Convert.ToString(dt.Rows[0]["Mode"]).ToLower()=="percentage")
                        {
                            rdoPercentage.Checked = true;
                            rdoAmount.Checked = false;
                        }
                        else if (Convert.ToString(dt.Rows[0]["Mode"]).ToLower() == "amount")
                        {
                            rdoPercentage.Checked = false;
                            rdoAmount.Checked = true;
                        }
                        else
                        {
                            rdoPercentage.Checked = false;
                            rdoAmount.Checked = false;
                        }
                    }
                    else
                    {
                        rdoPercentage.Checked = false;
                        rdoAmount.Checked = false;
                    }

                    if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Amount"])))
                    {
                        txtAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
                        txtAmount.Enabled = true;
                        txtAmount.BackColor = Color.White;
                    }
                    else
                    {
                        txtAmount.Text = String.Empty;
                        txtAmount.Enabled = false;
                        txtAmount.BackColor = Color.Silver;
                    }

                    if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["IncAmount"])))
                    {
                        lblPrevGross.Text = Convert.ToString(Convert.ToDecimal(lblCurrentGross.Text.Trim()) - Convert.ToDecimal(dt.Rows[0]["IncAmount"]));
                        lblPrevNet.Text = Convert.ToString(Convert.ToDecimal(lblCurrentNet.Text) - Convert.ToDecimal(dt.Rows[0]["IncAmount"]));
                    }
                }
                
            }
            
        }
    }
}