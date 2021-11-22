using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class EmployeeSalaryDetails : EDPComponent.FormBaseERP
    {
        public EmployeeSalaryDetails()
        {
            InitializeComponent();
        }

        public Int32 intEmpDet = 0;
        Hashtable emp_id = new Hashtable();
        Hashtable SalHead1 = new Hashtable();
        Hashtable lbtxt = new Hashtable();
        Hashtable head_formula = new Hashtable();
        Hashtable hsh_cmp_lumpsum = new Hashtable();
        Hashtable hsh_slab = new Hashtable();
        Hashtable hsh_PF = new Hashtable();
        Hashtable hsh_ESI = new Hashtable();
        Hashtable hsh_PT = new Hashtable();
        Hashtable hsh_lst_mnth = new Hashtable();
        Hashtable hsh_All_Mnth = new Hashtable();
        Hashtable hsh_chk_SalErnHead = new Hashtable();
        Hashtable hsh_chk_SalDedHead = new Hashtable();
        Hashtable hsh_chk_SalPFHead = new Hashtable();
        Hashtable hsh_chk_PT = new Hashtable();
        Hashtable hsh_chk_esi = new Hashtable();
        Hashtable hsh_chk_pfVol = new Hashtable();
        Hashtable hsh_DayCount = new Hashtable();
        Hashtable hsh_CFwd_DayCount = new Hashtable();
        Hashtable hsh_PayLeave = new Hashtable();
        Hashtable hsh_emp_code = new Hashtable();
        Hashtable hsh_rtype = new Hashtable();
        //Hashtable hsh_chk_save_updt = new Hashtable();
        //Hashtable hsh_PFd = new Hashtable();
        //Hashtable hsh_ESId = new Hashtable();
        //Hashtable hsh_PTd = new Hashtable();
        Label[] lbe = new Label[32];
        Label[] lbd = new Label[32];
        Label[] lbp = new Label[4];
        string empnm = "";
        TextBoxX.TextBoxX[] txte = new TextBoxX.TextBoxX[32];
        TextBoxX.TextBoxX[] txtd = new TextBoxX.TextBoxX[32];
        TextBoxX.TextBoxX[] txtp = new TextBoxX.TextBoxX[4];
        Label lbpt = new Label();
        TextBoxX.TextBoxX txpt = new TextBoxX.TextBoxX();
        double pfdue = 0, totpf = 0;
        double totLVWPay = 0, totLVWOPay = 0;
        double LeaveAmt = 0;
        SqlConnection con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=EDP_Payroll;Data Source=.\\SQLEXPRESS");
        SqlCommand cmd = new SqlCommand();
        SqlTransaction sqltran = null;
        //double[] pfc = new double[16];
        //double[] esit = new double[16];
        //double[] pt = new double[16];
        int PFSno = 0;
        string emply_id = "";


        #region Function

        #region Validation

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

        #endregion

        #region Get Existing Record Details

        private void GetTotalCalculation()
        {
            //GetTotalSalary();
            //GetTotalDeduction();
            //GetGrossAmount();
            //GetNetPay();
            //GetTotalDaysByMonthForGrid();
            //GetTotalPF();
        }

        //private void GetTotalPF()
        //{
        //    if (dgEmpSal.Rows.Count > 0)
        //    {
        //        for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
        //        {
        //            Decimal decTotalPF = 0.00m;
        //            for (Int32 j = (dgEmpSal.Rows[i].Cells["Amount on Which P.F. Due"].ColumnIndex + 1); j < dgEmpSal.Rows[i].Cells["Total PF"].ColumnIndex; j++)
        //            {
        //                Decimal decPF = 0.00m;
        //                if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells[j].Value)))
        //                {
        //                    decPF = Convert.ToDecimal(dgEmpSal.Rows[i].Cells[j].Value);
        //                }
        //                decTotalPF += decPF;
        //            }
        //            dgEmpSal.Rows[i].Cells["Total PF"].Value = decTotalPF;
        //        }
        //    }
        //}

        //private void GetTotalSalary()
        //{
        //    if (dgEmpSal.Rows.Count > 0)
        //    {
        //        for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
        //        {
        //            Decimal decTotalSal = 0.00m;
        //            for (Int32 j = (intEmpDet); j < ((GetTotalErnHeads() + intEmpDet)); j++)
        //            {
        //                Decimal decsal = 0.00m;
        //                if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells[j].Value)))
        //                {
        //                    decsal = Convert.ToDecimal(dgEmpSal.Rows[i].Cells[j].Value);
        //                }
        //                decTotalSal += decsal;
        //            }
        //            dgEmpSal.Rows[i].Cells["Total Salary"].Value = decTotalSal;
        //        }
        //    }
        //}

        //private void GetTotalDeduction()
        //{
        //    if (dgEmpSal.Rows.Count > 0)
        //    {
        //        for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
        //        {
        //            Decimal decTotalDeduc = 0.00m;
        //            for (Int32 j = dgEmpSal.Rows[i].Cells["Total PF"].ColumnIndex; j < dgEmpSal.Rows[i].Cells["Total Deduc."].ColumnIndex; j++)
        //            {
        //                Decimal decDeduc = 0.00m;
        //                if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells[j].Value)))
        //                {
        //                    decDeduc = Convert.ToDecimal(dgEmpSal.Rows[i].Cells[j].Value);
        //                }
        //                decTotalDeduc += decDeduc;
        //            }
        //            dgEmpSal.Rows[i].Cells["Total Deduc."].Value = decTotalDeduc;
        //        }
        //    }
        //}

        //private void GetNetPay()
        //{
        //    if (dgEmpSal.Rows.Count > 0)
        //    {
        //        for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
        //        {
        //            Decimal decGrossAmount = 0.00m;
        //            if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells["Gross Amount"].Value)))
        //            {
        //                decGrossAmount = Convert.ToDecimal(Convert.ToString(dgEmpSal.Rows[i].Cells["Gross Amount"].Value));
        //            }

        //            Decimal decTotalDec = 0.00m;
        //            if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells["Total Deduc."].Value)))
        //            {
        //                decTotalDec = Convert.ToDecimal(Convert.ToString(dgEmpSal.Rows[i].Cells["Total Deduc."].Value));
        //            }
        //            if (decGrossAmount > decTotalDec)
        //            {
        //                dgEmpSal.Rows[i].Cells["Net Pay"].Value = decGrossAmount - decTotalDec;
        //            }
        //            else
        //            {
        //                dgEmpSal.Rows[i].Cells["Net Pay"].Value = "0.00";
        //            }
        //        }
        //    }
        //}

        //private void GetGrossAmount()
        //{
        //    if (dgEmpSal.Rows.Count > 0)
        //    {
        //        for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
        //        {
        //            Int32 intLWP = 0;
        //            Decimal decGrossAmount = 0.00m;
        //            if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells["Leave With out Pay"].Value)))
        //            {
        //                intLWP = Convert.ToInt32(dgEmpSal.Rows[i].Cells["Leave With out Pay"].Value);
        //            }
        //            if (intLWP > 0)
        //            {
        //                Decimal decTotalSal = 0.00m;
        //                if (!String.IsNullOrEmpty(Convert.ToString(dgEmpSal.Rows[i].Cells["Total Salary"].Value)))
        //                {
        //                    decTotalSal = Convert.ToDecimal(Convert.ToString(dgEmpSal.Rows[i].Cells["Total Salary"].Value));
        //                }
        //                decGrossAmount=Convert.ToDecimal( decTotalSal/intLWP);
                        
        //            }
        //            dgEmpSal.Rows[i].Cells["Gross Amount"].Value = dgEmpSal.Rows[i].Cells["Total Salary"].Value;
        //        }
        //    }
        //}

        //private void GetGridHeader()
        //{
        //    dgEmpSal.Columns.Add("ID", "ID");
        //    dgEmpSal.Columns["ID"].ReadOnly = true;
        //    dgEmpSal.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        //    dgEmpSal.Columns.Add("Name", "Name");
        //    dgEmpSal.Columns["Name"].ReadOnly = true;
        //    dgEmpSal.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    dgEmpSal.Columns["Name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        //    dgEmpSal.Columns.Add("Designation", "Desg.");
        //    dgEmpSal.Columns["Designation"].ReadOnly = true;
        //    dgEmpSal.Columns["Designation"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    dgEmpSal.Columns["Designation"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        //    DataTable dt = GetSalaryHeads();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (Int32 i = 0; i < dt.Rows.Count; i++)
        //        {
        //            dgEmpSal.Columns.Add(Convert.ToString(dt.Rows[i]["SalaryHead"]), Convert.ToString(dt.Rows[i]["SalaryHead"]));
        //            if (Convert.ToString(dt.Rows[i]["SalaryHead"]).ToLower() == "basic")
        //            {
        //                dgEmpSal.Columns[Convert.ToString(dt.Rows[i]["SalaryHead"])].ReadOnly = false;
                        
        //            }
        //            else
        //            {
        //                //dgEmpSal.Columns[Convert.ToString(dt.Rows[i]["SalaryHead"])].ReadOnly = true;
        //            }
        //            dgEmpSal.Columns[Convert.ToString(dt.Rows[i]["SalaryHead"])].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //            dgEmpSal.Columns[Convert.ToString(dt.Rows[i]["SalaryHead"])].DefaultCellStyle.WrapMode = DataGridViewTriState.True;                   
        //        }
        //    }
        //    //dgEmpSal.Columns.Add("Total", "Net Salary");
        //    //dgEmpSal.Columns["Total"].ReadOnly = true;
        //}

        private Int32 GetTotalErnHeads()
        {
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");
            return dtErn.Rows.Count;
        }

        private Int32 GetTotalDeductionHeads()
        {
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");
            return dtDeduction.Rows.Count;
        }

        private Int32 GetTotalPFHeads()
        {
            DataTable dtPF = clsDataAccess.RunQDTbl("select ShortName,SlNo from tbl_Employee_Config_PFHeads ");
            return dtPF.Rows.Count;
        }

        //private DataTable GetSalaryHeads()
        //{
        //    DataTable dtSalaryHead = new DataTable();
        //    DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");
        //    DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");
        //    DataTable dtPF = clsDataAccess.RunQDTbl("select ShortName,SlNo from tbl_Employee_Config_PFHeads ");
        //    //String[,] strArr = new String[dtErn.Rows.Count + dtDeduction.Rows.Count, strColCount];
        //    dtSalaryHead.Columns.Add("SalaryHead");
        //    dtSalaryHead.Columns.Add("ID");
        //    dtSalaryHead.Columns.Add("TableName");

        //    for (Int32 i = 0; i < dtErn.Rows.Count; i++)
        //    {
        //        dtSalaryHead.Rows.Add();
        //        dtSalaryHead.Rows[i]["SalaryHead"] = Convert.ToString(dtErn.Rows[i]["SalaryHead_Short"]);
        //        dtSalaryHead.Rows[i]["ID"] = Convert.ToString(dtErn.Rows[i]["SlNo"]);
        //        dtSalaryHead.Rows[i]["TableName"] = Convert.ToString("tbl_Employee_ErnSalaryHead");
        //    }

        //    dtSalaryHead.Rows.Add();
        //    dtSalaryHead.Rows[dtSalaryHead.Rows.Count-1]["SalaryHead"]="Total Salary";
        //    dtSalaryHead.Rows.Add();
        //    dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "No Of Days Present";
        //    dtSalaryHead.Rows.Add();
        //    dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Leave With Pay";
        //    dtSalaryHead.Rows.Add();
        //    dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Leave With out Pay";
        //    dtSalaryHead.Rows.Add();
        //    dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Total days";
        //    dtSalaryHead.Rows.Add();
        //    dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Gross Amount";
        //    dtSalaryHead.Rows.Add();
        //    dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Amount on Which P.F. Due";

        //    for (Int32 i = 0; i < dtPF.Rows.Count; i++)
        //    {
        //        dtSalaryHead.Rows.Add();
        //        dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = Convert.ToString(dtPF.Rows[i]["ShortName"]);
        //        dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["ID"] = Convert.ToString(dtPF.Rows[i]["SlNo"]);
        //        dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["TableName"] = Convert.ToString("tbl_Employee_Config_PFHeads");
        //    }

        //    dtSalaryHead.Rows.Add();
        //    dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = "Total PF";

        //    for (Int32 i = 0; i < dtDeduction.Rows.Count; i++)
        //    {
        //        dtSalaryHead.Rows.Add();
        //        dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = Convert.ToString(dtDeduction.Rows[i]["SalaryHead_Short"]);
        //        dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["ID"] = Convert.ToString(dtDeduction.Rows[i]["SlNo"]);
        //        dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["TableName"] = Convert.ToString("tbl_Employee_DeductionSalayHead");
        //    }

        //    dtSalaryHead.Rows.Add();
        //    dtSalaryHead.Rows[dtSalaryHead.Rows.Count-1]["SalaryHead"]="Total Deduc.";
        //    dtSalaryHead.Rows.Add();
        //    dtSalaryHead.Rows[dtSalaryHead.Rows.Count-1]["SalaryHead"]="Net Pay";
        //    return dtSalaryHead;
        //}

        //private void GetEmployeeDetails()
        //{
        //    Int32 intSalHead = 0;
        //    //dgEmpSal.Columns["Basic"].ValueType = System.Type.GetType("Decimal");
        //    DataTable dtEmp = clsDataAccess.RunQDTbl("select emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName Name,desg.DesignationName from tbl_Employee_Mast emp,tbl_Employee_DesignationMaster desg where emp.DesgId=desg.SlNo");
        //    if (dtEmp.Rows.Count > 0)
        //    {
        //        for (Int32 i = 0; i < dtEmp.Rows.Count; i++)
        //        {
        //            dgEmpSal.Rows.Add();
                    
        //            dgEmpSal.Rows[i].Cells["Name"].Value = dtEmp.Rows[i]["Name"];
        //            dgEmpSal.Rows[i].Cells["Designation"].Value = dtEmp.Rows[i]["DesignationName"];

        //            intEmpDet = 3;

        //            DataTable dtSal = GetSalaryHeads();
        //            if (dtSal.Rows.Count > 0)
        //            {
        //                for (Int32 j = 0; j < dtSal.Rows.Count; j++)
        //                {
        //                    if (!String.IsNullOrEmpty(Convert.ToString(dtSal.Rows[j]["ID"])))
        //                    {
        //                        //intSalHead += 1;
        //                        if (CheckForExDetRecord(Convert.ToString(dtEmp.Rows[i]["ID"]), cmbYear.Text.Trim(), cmbMonth.Text.Trim(), Convert.ToString(dtSal.Rows[j]["SalaryHead"])))
        //                        {
        //                            DataTable dtEx = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + Convert.ToString(dtEmp.Rows[i]["ID"]) + "' and Session='" + cmbYear.Text.Trim() + "' and Month='" + cmbMonth.Text.Trim() + "' and SalId=" + GetSalDetAccSalaryHead(Convert.ToString(dtSal.Rows[j]["SalaryHead"]))[0] + " and TableName='" + GetSalDetAccSalaryHead(Convert.ToString(dtSal.Rows[j]["SalaryHead"]))[1] + "'");
        //                            if (dtEx.Rows.Count > 0)
        //                            {
        //                                dgEmpSal.Rows[i].Cells[Convert.ToString(dtSal.Rows[j]["SalaryHead"])].Value = dtEx.Rows[0]["Amount"];
        //                            }
        //                            else
        //                            {
        //                                dgEmpSal.Rows[i].Cells[Convert.ToString(dtSal.Rows[j]["SalaryHead"])].Value = "0.00";
        //                            }
        //                        }
        //                    }
        //                }
        //            } 

        //            if(CheckForExMastRecord(Convert.ToString(dtEmp.Rows[i]["ID"]),cmbYear.Text.Trim(), cmbMonth.Text.Trim()))
        //            {
        //                DataTable dtMast = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryMast where Emp_Id='" + Convert.ToString(dtEmp.Rows[i]["ID"]) + "' and Session='" + cmbYear.Text.Trim() + "' and Month='" + cmbMonth.Text.Trim() + "'");
        //                if (dtMast.Rows.Count > 0)
        //                {
        //                    dgEmpSal.Rows[i].Cells["Total Salary"].Value = dtMast.Rows[0]["TotalSal"];
        //                    dgEmpSal.Rows[i].Cells["No Of Days Present"].Value = dtMast.Rows[0]["DaysPresent"];
        //                    dgEmpSal.Rows[i].Cells["Leave With Pay"].Value = dtMast.Rows[0]["LeaveWithPay"];
        //                    dgEmpSal.Rows[i].Cells["Leave With out Pay"].Value = dtMast.Rows[0]["LeaveWithoutPay"];
        //                    dgEmpSal.Rows[i].Cells["Total days"].Value = dtMast.Rows[0]["TotalDays"];
        //                    dgEmpSal.Rows[i].Cells["Gross Amount"].Value = dtMast.Rows[0]["GrossAmount"];
        //                    dgEmpSal.Rows[i].Cells["Amount on Which P.F. Due"].Value = dtMast.Rows[0]["PFDue"];
        //                    dgEmpSal.Rows[i].Cells["Total PF"].Value = dtMast.Rows[0]["TotalPF"];                            
        //                    dgEmpSal.Rows[i].Cells["Total Deduc."].Value = dtMast.Rows[0]["TotalDec"];
        //                    dgEmpSal.Rows[i].Cells["Net Pay"].Value = dtMast.Rows[0]["NetPay"];
        //                }
        //                else
        //                {
        //                    dgEmpSal.Rows[i].Cells["Total Salary"].Value = 0.00;
        //                    dgEmpSal.Rows[i].Cells["No Of Days Present"].Value = 0;
        //                    dgEmpSal.Rows[i].Cells["Leave With Pay"].Value = 0;
        //                    dgEmpSal.Rows[i].Cells["Leave With out Pay"].Value = 0;
        //                    dgEmpSal.Rows[i].Cells["Total days"].Value = 0;
        //                    dgEmpSal.Rows[i].Cells["Gross Amount"].Value = 0.00;
        //                    dgEmpSal.Rows[i].Cells["Amount on Which P.F. Due"].Value = 0.00;
        //                    dgEmpSal.Rows[i].Cells["Total PF"].Value = 0.00;       
        //                    dgEmpSal.Rows[i].Cells["Total Deduc."].Value = 0.00;
        //                    dgEmpSal.Rows[i].Cells["Net Pay"].Value = 0.00;
        //                }
        //            }
        //            dgEmpSal.Rows[i].Cells["ID"].Value = dtEmp.Rows[i]["ID"];
        //        }
        //    }
        //}

        //private String[] GetSalDetAccSalaryHead(String strSalaryHead)
        //{
        //    String[] strTable = new String[2];
        //    DataTable dt = GetSalaryHeads();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (Int32 i = 0; i < dt.Rows.Count; i++)
        //        {
        //            if (strSalaryHead == Convert.ToString(dt.Rows[i]["SalaryHead"]))
        //            {
        //                strTable[0] = Convert.ToString(dt.Rows[i]["ID"]);
        //                strTable[1] = Convert.ToString(dt.Rows[i]["TableName"]);
        //            }
        //        }
        //    }
        //    return strTable;
        //}

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
                            intDays =28;
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

        private Int32 GetYear(String strFullMonthNameMonth, String strSession)
        {
            Int32 intYear = 0;
            String[] strArr = new String[2];
            strArr=strSession.Split('-');
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

        //private void GetTotalDaysByMonthForGrid()
        //{
        //    if (dgEmpSal.Rows.Count > 0)
        //    {
        //        for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
        //        {
        //            dgEmpSal.Rows[i].Cells["Total days"].Value = GetTotalDaysByMonth(cmbMonth.Text.Trim(), GetYear(cmbMonth.Text.Trim(), cmbYear.Text.Trim()));
        //        }
        //    }
        //}

        #endregion

        #region Check For Existing Records

        private Boolean CheckForExMastRecord(String strEmpId,String strSession,String strMonth)
        {
            Boolean boolStatus = false;
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryMast where Emp_Id='" + strEmpId + "' and Session='" + strSession + "' and Month='" + strMonth + "'");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }
            return boolStatus;
        }

        //private Boolean CheckForExDetRecord(String strEmpId, String strSession, String strMonth,String strSalHead)
        //{
        //    Boolean boolStatus = false;
        //    DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + strEmpId + "' and Session='" + strSession + "' and Month='" + strMonth + "' and SalId=" + GetSalDetAccSalaryHead(strSalHead)[0] + " and TableName='" + GetSalDetAccSalaryHead(strSalHead)[1] + "'");
        //    if (dt.Rows.Count > 0)
        //    {
        //        boolStatus = true;
        //    }
        //    return boolStatus;
        //}

        #endregion

        #region Submit Details

        //private Boolean SubmitSalaryDetails(String strEmpId, String strSession, String strMonth, String strSalHead,Decimal decAmount)
        //{
        //    Boolean boolStatus = false;
        //    if (CheckForExDetRecord(strEmpId, strSession, strMonth, strSalHead))
        //    {
        //        boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_SalaryDet set Amount=" + decAmount + " where EmpId='" + strEmpId + "' and SalId=" + GetSalDetAccSalaryHead(strSalHead)[0] + " and Month='" + strMonth + "' and Session='" + strSession + "' and TableName='" + GetSalDetAccSalaryHead(strSalHead)[1] + "'");
        //    }
        //    else
        //    {
        //        boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + strEmpId + "'," + GetSalDetAccSalaryHead(strSalHead)[0] + ",'" + GetSalDetAccSalaryHead(strSalHead)[1] + "'," + decAmount + ",'" + strMonth + "','" + strSession + "')");
        //    }
        //    return boolStatus;
        //}

        //private Boolean SubmitEmpSalaryDet(String strEmpId, Int32 intGridRowIndex)
        //{
        //    Int32 intCounter = 0;
        //    Int32 intSalHead = 0;
        //    Boolean boolStatus = false;
        //    DataTable dtSal = GetSalaryHeads();
        //    if (dtSal.Rows.Count > 0)
        //    {
        //        for (Int32 j = 0; j < dtSal.Rows.Count; j++)
        //        {
        //            if (!String.IsNullOrEmpty(Convert.ToString(dtSal.Rows[j]["ID"])))
        //            {
        //                intSalHead += 1;
        //                if (SubmitSalaryDetails(strEmpId, cmbYear.Text.Trim(), cmbMonth.Text.Trim(), Convert.ToString(dtSal.Rows[j]["SalaryHead"]), Convert.ToDecimal(dgEmpSal.Rows[intGridRowIndex].Cells[Convert.ToString(dtSal.Rows[j]["SalaryHead"])].Value)))
        //                {
        //                    intCounter += 1;
        //                }
        //            }
        //        }
        //        if (intCounter == intSalHead)
        //        {
        //            boolStatus = true;
        //        }
        //    }
        //    return boolStatus;
        //}

        //private void SubmitEmpSal()
        //{
        //    Boolean boolStatus = false;
        //    // Boolean bool
        //    Int32 intCounter = 0;

        //    if (Validation())
        //    {
        //        if (dgEmpSal.Rows.Count > 0)
        //        {
        //            for (Int32 i = 0; i < dgEmpSal.Rows.Count; i++)
        //            {
        //                String strEmpId = Convert.ToString(dgEmpSal.Rows[i].Cells["ID"].Value);
        //                String strTotalSal = Convert.ToString(dgEmpSal.Rows[i].Cells["Total Salary"].Value);
        //                if (String.IsNullOrEmpty(strTotalSal))
        //                {
        //                    strTotalSal = "0.00";
        //                }

        //                String strTotalDec = Convert.ToString(dgEmpSal.Rows[i].Cells["Total Deduc."].Value);
        //                if (String.IsNullOrEmpty(strTotalDec))
        //                {
        //                    strTotalDec = "0.00";
        //                }

        //                String strNetPay = Convert.ToString(dgEmpSal.Rows[i].Cells["Net Pay"].Value);
        //                if (String.IsNullOrEmpty(strNetPay))
        //                {
        //                    strNetPay = "0.00";
        //                }

        //                String strPresent = Convert.ToString(dgEmpSal.Rows[i].Cells["No Of Days Present"].Value);
        //                if (String.IsNullOrEmpty(strPresent))
        //                {
        //                    strPresent = "0";
        //                }

        //                String strLP = Convert.ToString(dgEmpSal.Rows[i].Cells["Leave With Pay"].Value);
        //                if (String.IsNullOrEmpty(strLP))
        //                {
        //                    strLP = "0";
        //                }

        //                String strLWP = Convert.ToString(dgEmpSal.Rows[i].Cells["Leave With out Pay"].Value);
        //                if (String.IsNullOrEmpty(strLWP))
        //                {
        //                    strLWP = "0";
        //                }

        //                String strTotalDays = Convert.ToString(dgEmpSal.Rows[i].Cells["Total days"].Value);
        //                if (String.IsNullOrEmpty(strTotalDays))
        //                {
        //                    strTotalDays = "0";
        //                }

        //                String strGrossAmount = Convert.ToString(dgEmpSal.Rows[i].Cells["Gross Amount"].Value);
        //                if (String.IsNullOrEmpty(strGrossAmount))
        //                {
        //                    strGrossAmount = "0.00";
        //                }

        //                String strPFDue = Convert.ToString(dgEmpSal.Rows[i].Cells["Amount on Which P.F. Due"].Value);
        //                if (String.IsNullOrEmpty(strPFDue))
        //                {
        //                    strPFDue = "0.00";
        //                }

        //                String strTotalPF = Convert.ToString(dgEmpSal.Rows[i].Cells["Total PF"].Value);
        //                if (String.IsNullOrEmpty(strTotalPF))
        //                {
        //                    strTotalPF = "0.00";
        //                }

        //                if (!String.IsNullOrEmpty(strEmpId))
        //                {
        //                    if (CheckForExMastRecord(strEmpId, cmbYear.Text.Trim(), cmbMonth.Text.Trim()))
        //                    {
        //                        boolStatus = clsDataAccess.RunNQwithStatus("UPDATE [tbl_Employee_SalaryMast] SET [TotalSal] = " + strTotalSal + ",[DaysPresent] = " + strPresent + ",[LeaveWithPay] = " + strLP + ",[LeaveWithoutPay] = " + strLWP + ",[TotalDays] = " + strTotalDays + ",[GrossAmount] = " + strGrossAmount + ",[PFDue] = " + strPFDue + ",[TotalPF] = " + strTotalPF + ",[TotalDec] = " + strTotalDec + ",[NetPay] = " + strNetPay + " WHERE [Emp_Id] = '" + strEmpId + "' and [Month] = '" + cmbMonth.Text.Trim() + "' and [Session] = '" + cmbYear.Text.Trim() + "'");
        //                    }
        //                    else
        //                    {
        //                        boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO [SchoolManagement].[tbl_Employee_SalaryMast] ([Emp_Id],[TotalSal],[DaysPresent],[LeaveWithPay],[LeaveWithoutPay],[TotalDays],[GrossAmount],[PFDue],[TotalPF],[TotalDec],[NetPay],[Month],[Session]) VALUES('" + strEmpId + "'," + strTotalSal + "," + strPresent + "," + strLP + "," + strLWP + "," + strTotalDays + "," + strGrossAmount + "," + strPFDue + "," + strTotalPF + "," + strTotalDec + "," + strNetPay + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')");
        //                    }
        //                }
        //                if (boolStatus)
        //                {
        //                    if (SubmitEmpSalaryDet(strEmpId, i))
        //                    {
        //                        intCounter += 1;
        //                    }
        //                }
        //            }
        //            if (intCounter == dgEmpSal.Rows.Count)
        //            {
        //                ERPMessageBox.ERPMessage.Show("Employee Salary Details Submitted Successfully ");
        //            }

        //        }
        //    }

        //}

        #endregion

        #endregion

        private void EmployeeSalaryDetails_Load(object sender, EventArgs e)
        {
            try
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
                //
                //GetGridHeader();
                GetSalaryHeads();

                cmbMonth.Text = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

                load_txt();
                load_txtd();
                load_txtp();

            }
            catch (Exception x) { }
        }

        public void Load_Data(string qry, ComboBox cb, int i)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            dt = clsDataAccess.RunQDTbl(qry);
            string t = "";
            if (dt.Rows.Count > 0)
            {
                for (int d = 0; d < dt.Rows.Count; d++)
                {
                    t = dt.Rows[d][0].ToString() + " " + dt.Rows[d][1].ToString() + " " + dt.Rows[d][2].ToString() + " " + dt.Rows[d][3].ToString();
                    cb.Items.Add(t);
                    if (!emp_id.ContainsKey(t))
                        emp_id.Add(t, dt.Rows[d][4].ToString());
                    if (!hsh_emp_code.ContainsKey(t))
                        hsh_emp_code.Add(t, dt.Rows[d][5].ToString());
                    
                }
                if (i >= 0)
                    cb.SelectedIndex = i;
            }
        }

        //private void dgEmpSal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 3)
        //    {
        //        String strVal = Convert.ToString(dgEmpSal.CurrentCell.Value);
        //        try
        //        {
        //            Decimal decBasic = Convert.ToDecimal(dgEmpSal.CurrentCell.Value);
        //        }
        //        catch (Exception ex)
        //        {
        //            dgEmpSal.CurrentCell.Value ="0.00";
        //        }
        //    }
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            //SubmitEmpSal();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                //dgEmpSal.Rows.Clear();
                //GetEmployeeDetails();
                GetTotalCalculation();
            }
        }

        private void dgEmpSal_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            GetTotalCalculation();
        }

        private void dgEmpSal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GetTotalCalculation();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cmbsalstruc_DropDown(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                cmbsalstruc.Items.Clear();
                if (cmbempname.Text == "")
                {
                    s = "select salarycategory from tbl_Employee_SalaryStructure";
                    Load_Data1(s, cmbsalstruc, -1);
                }
                else
                    //if (get_SalIdFrmEmpMst(cmbempname.Text.Trim()) != "")
                    //{
                        
                       s = "select distinct ss.salarycategory from tbl_Emp_Posting ep,tbl_Employee_Link_SalaryStructure ls,tbl_Employee_SalaryStructure ss "+
                           " where ep.Employ_ID='" + emply_id + "' and ep.LOcation_ID=ls.LOcation_ID and ep.Posting_Month='" + cmbMonth.Text + "' and ls.SalaryStructure_ID=ss.slno";
                        //s = "select salarycategory from tbl_Employee_SalaryStructure where slno=" + get_SalIdFrmEmpMst(cmbempname.Text.Trim());
                        Load_Data1(s, cmbsalstruc, -1);
                    //}

                clear_txt();
            }
            catch (Exception x) { }
        }

        public void Load_Data1(string qry, ComboBox cb, int i)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {
                for (int d = 0; d < dt.Rows.Count; d++)
                {
                    cb.Items.Add(dt.Rows[d][0].ToString());
                }
                if (i >= 0)
                    cb.SelectedIndex = i;
            }
        }

        public void get_data()
        {
            string s = ""; int j = 1;  int lbl = 6,lbl1=6,jt=0;
            //head_formula.Clear();
            hsh_PF.Clear();
            hsh_ESI.Clear();
            hsh_PT.Clear();
            //pfc = 0; pt = 0;
            s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE from tbl_Employee_Assign_SalStructure where session='" + cmbYear.Text.Trim() + "' and sal_struct=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " and p_type='E' ";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Label lb = new Label();
                    //TextBoxX.TextBoxX tx5 = new TextBoxX.TextBoxX();

                    if (dt.Rows[i][1].ToString().Trim() == "E" && clsEmployee.GetMonth_SingleDigit(cmbMonth.Text.Trim())>=clsEmployee.GetMonth_SingleDigit(dt.Rows[i][4].ToString()) && clsEmployee.GetMonth_SingleDigit(cmbMonth.Text.Trim())<=clsEmployee.GetMonth_SingleDigit(dt.Rows[i][5].ToString()))
                    {
                        lb = lbe[i];
                        lb.Text = get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E");
                        lbe[i] = lb;

                        this.grpern.Controls.Add(lbe[i]);
                        if (dt.Rows[i][9].ToString().Trim() == "Nearest Rupee")
                        {
                            if (!hsh_rtype.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                hsh_rtype.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][9].ToString().Trim());
                        }
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            if (!head_formula.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                head_formula.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][3].ToString());
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                        {
                            if (!hsh_cmp_lumpsum.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                hsh_cmp_lumpsum.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][3].ToString());                            
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "SLAB")
                        {
                            if (!hsh_slab.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                hsh_slab.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][3].ToString());
                        }
                        if (Convert.ToDouble(dt.Rows[i]["PF_PER"]) > 0)
                        {
                            if (!hsh_PF.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                hsh_PF.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), Convert.ToString(Convert.ToDouble(dt.Rows[i]["PF_PER"]) / 100));
                        }
                        if (Convert.ToDouble(dt.Rows[i]["ESI_PER"]) > 0)
                        {
                            if (!hsh_ESI.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                hsh_ESI.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), Convert.ToString(Convert.ToDouble(dt.Rows[i]["ESI_PER"]) / 100));
                        }
                        if (Convert.ToDouble(dt.Rows[i]["PT"]) > 0)
                        {
                            if (!hsh_PT.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                hsh_PT.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i]["PT"].ToString());
                        }
                        //this.grpern.Controls.Add(lbe[i]);
                    }

                }
            }
        }

        public void load_txt()
        {
            int lbl = 6, lbl1 = 7;
            for (int t = 0; t < 16; t++)
            {
                Label lb = new Label();
                TextBoxX.TextBoxX txt = new TextBoxX.TextBoxX();
                txt.Name = "txte" + t.ToString();
                lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.Name = "lble" + t.ToString();
                if (t < 8)
                {
                    lb.Location = new System.Drawing.Point(lbl, 18);
                  
                    txt.Location = new System.Drawing.Point(lbl, 36);
                    lbl += 94;
                }
                else if (t < 16)
                {
                    lb.Location = new System.Drawing.Point(lbl1, 60);
                    txt.Location = new System.Drawing.Point(lbl1, 78);
                    lbl1 += 94;
                }
                lb.Size = new System.Drawing.Size(37, 15);
                txt.Size = new System.Drawing.Size(90, 22);
                txt.TextChanged += new EventHandler(txt_TextChanged);
                txt.KeyUp += new KeyEventHandler(txt_KeyUp);
                lbe[t] = lb;
                txte[t] = txt;
                this.grpern.Controls.Add(lbe[t]);
                this.grpern.Controls.Add(txte[t]);
            }
        }

        void txt_KeyUp(object sender, KeyEventArgs e)
        {

        }

        void txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string a = "1";
                sal_total();
            }
            catch (Exception ex) {}

        }

        public string cal_formula(int id)
        {
            string exp = "", s = "", res = "";
            int g = 0, i = 0;
            s = "select fexp from tbl_Employee_Sal_Structure_Formula where fid=" + id;
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                for (int f = 0; f < dt.Rows[0][0].ToString().Trim().Length; f++)
                {
                    if (dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "=" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "*" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "+" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "-" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "/" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "%" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "(" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == ")")
                    {
                        if (SalHead1.ContainsKey(dt.Rows[0][0].ToString().Trim().Substring(g, i)))
                        {
                            for (int lt = 0; lt < lbe.Length; lt++)
                            {
                                Label l = new Label();
                                TextBoxX.TextBoxX t = new TextBoxX.TextBoxX();
                                l = lbe[lt];
                                t = txte[lt];
                                string te = SalHead1[dt.Rows[0][0].ToString().Trim().Substring(g, i)].ToString();
                                if (lbe[lt] != null && l.Text.Trim() == SalHead1[dt.Rows[0][0].ToString().Trim().Substring(g, i)].ToString())
                                {
                                    exp += t.Text.Trim() + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                }
                            }
                        }
                        else
                            exp += dt.Rows[0][0].ToString().Trim().Substring(g, i) + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                        i = 0;
                        g = f + 1;
                    }
                    else
                        i++;
                }
                exp += dt.Rows[0][0].ToString().Trim().Substring(g, i);
                res = f_cal(exp);
            }
            return res;
        }

        public string f_cal(string exp)
        {
            int g = 0, i = 0,ta=0;
            double fl = 0;
            string res = "";
            for (int f = 0; f < exp.Trim().Length; f++)
            {
                if (exp.Trim().Substring(f, 1) == "*")
                {
                    if (fl == 0)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = 0;
                    }
                    if (ta == 1)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl * 0;
                    }
                    else if (ta == 2)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl + 0;
                    }
                    else if (ta == 3)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl - 0;
                    }
                    else if (ta == 4)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl / 0;
                    }
                    else if (ta == 5)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl % 0;
                    }
                    ta = 1;
                    i = 0;
                    g = f + 1;
                }
                else if(exp.Trim().Substring(f, 1) == "+")
                {
                    if (fl == 0)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = 0;
                    }
                    if (ta == 1)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl * 0;
                    }
                    else if (ta == 2)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl + 0;
                    }
                    else if (ta == 3)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl - 0;
                    }
                    else if (ta == 4)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl / 0;
                    }
                    else if (ta == 5)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl % 0;
                    }
                    ta = 2;
                    i = 0;
                    g = f + 1;
                }
                else if(exp.Trim().Substring(f, 1) == "-")
                {
                    if (fl == 0)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = 0;
                    }
                    if (ta == 1)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl * 0;
                    }
                    else if (ta == 2)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl + 0;
                    }
                    else if (ta == 3)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl - 0;
                    }
                    else if (ta == 4)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl / 0;
                    }
                    else if (ta == 5)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl % 0;
                    }
                    ta = 3;
                    i = 0;
                    g = f + 1;
                }
                else if(exp.Trim().Substring(f, 1) == "/")
                {
                    if (fl == 0)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = 0;
                    }
                    if (ta == 1)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl * 0;
                    }
                    else if (ta == 2)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl + 0;
                    }
                    else if (ta == 3)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl - 0;
                    }
                    else if (ta == 4)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl / 0;
                    }
                    else if (ta == 5)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl % 0;
                    }
                    ta = 4;
                    i = 0;
                    g = f + 1;
                }
                else if(exp.Trim().Substring(f, 1) == "%")
                {
                    if (fl == 0)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = 0;
                    }
                    if (ta == 1)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl * 0;
                    }
                    else if (ta == 2)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl + 0;
                    }
                    else if (ta == 3)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl - 0;
                    }
                    else if (ta == 4)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl / 0;
                    }
                    else if (ta == 5)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl % 0;
                    }
                    ta = 5;
                    i = 0;
                    g = f + 1;
                }
                else if(exp.Trim().Substring(f, 1) == "(")
                {
                    i = 0;
                    g = f + 1;
                }
                else if (exp.Trim().Substring(f, 1) == ")")
                {
                    i = 0;
                    g = f + 1;
                }
                else
                {
                    i++;
                }
            }
            if (ta == 1)
            {
                if (exp.Trim().Substring(g, i) != "")
                    fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                else
                    fl = fl * 0;
            }
            else if (ta == 2)
            {
                if (exp.Trim().Substring(g, i) != "")
                    fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                else
                    fl = fl + 0;
            }
            else if (ta == 3)
            {
                if (exp.Trim().Substring(g, i) != "")
                    fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                else
                    fl = fl - 0;
            }
            else if (ta == 4)
            {
                if (exp.Trim().Substring(g, i) != "")
                    fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                else
                    fl = fl / 0;
            }
            else if (ta == 5)
            {
                if (exp.Trim().Substring(g, i) != "")
                    fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                else
                    fl = fl % 0;
            }
            res = Convert.ToString(fl);
            return res;
        }

        private void cmbempname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cmbMonth.Text != "" && cmbempname.Text != "" && cmbsalstruc.Text != "")
            //    {
            //        get_data();
            //        get_data1();
            //    }
            //}
            //catch (Exception x) { }
            //try
            //{
            //    if (cmbempname.Text.Trim() != "")
            //    {
            //        string s1 = "select id from tbl_Employee_Mast where code=" + Convert.ToInt32(hsh_emp_code[cmbempname.Text.Trim()]);
            //        DataTable temp = new DataTable();
            //        temp = clsDataAccess.RunQDTbl(s1);
            //        if (temp.Rows.Count > 0)
            //        {
            //            lblempid.Text = temp.Rows[0][0].ToString();
            //        }
            //    }
            //    else
            //        lblempid.Text = string.Empty;
            //}
            //catch (Exception ex) { }
           
        }

        private void cmbsalstruc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbempname_DropDown(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                cmbempname1111.Items.Clear();
                //if(cmbsalstruc.Text=="")
                 s = "select title,firstname,middlename,lastname,id,code from tbl_Employee_Mast";
                //else
                // s = "select title,firstname,middlename,lastname,id,code from tbl_Employee_Mast where salid=" + get_SalStructID(cmbsalstruc.Text.Trim());
                Load_Data(s, cmbempname1111, -1);

                cmbsalstruc.Items.Clear();
                cmbsalstruc.Text = "";
                clear_txt();
                
            }
            catch (Exception x) { }

        }

        public int get_SalStructID(string name)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select SlNo from tbl_Employee_SalaryStructure where SalaryCategory='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public string get_SalStructName(int id)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select SalaryCategory from tbl_Employee_SalaryStructure where SlNo=" + id;
            dt = clsDataAccess.RunQDTbl(s);
            return dt.Rows[0][0].ToString();

        }

        public string get_SalIdFrmEmpMst(string name)
        {
            string s="";
            DataTable dt = new DataTable();
            dt.Clear();
            if (emp_id.ContainsKey(name))
                s = "select salid from tbl_Employee_Mast where id='" + emp_id[name].ToString() + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return dt.Rows[0][0].ToString();

        }

        public string get_sal_head_name(int id, string type)
        {
            string res = "";
            if (type == "E")
            {
                string s = "select SalaryHead_Short from tbl_Employee_ErnSalaryHead where slno=" + id;
                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    res = dts.Rows[0][0].ToString();

            }
            else if (type == "D")
            {
                string s = "select SalaryHead_Short from tbl_Employee_DeductionSalayHead where slno=" + id;

                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    res = dts.Rows[0][0].ToString();
            }
            return res;
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetSalaryHeads()
        {
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");
            
            for (Int32 i = 0; i < dtErn.Rows.Count; i++)
            {
               
                if (!SalHead1.ContainsKey(Gen_ID("S", dtErn.Rows[i][1].ToString())))
                    SalHead1.Add(Gen_ID("S", dtErn.Rows[i][1].ToString()), dtErn.Rows[i][0].ToString());
            }
            for (Int32 i = 0; i < dtDeduction.Rows.Count; i++)
            {
                
                if (!SalHead1.ContainsKey(Gen_ID("D", dtDeduction.Rows[i][1].ToString())))
                    SalHead1.Add(Gen_ID("D", dtDeduction.Rows[i][1].ToString()), dtDeduction.Rows[i][0].ToString());
            }
        }

        public string Gen_ID(string h_type, string s)
        {
            string res = "";
            switch (s.Length)
            {
                case 1: res = h_type + "00" + s; break;
                case 2: res = h_type + "0" + s; break;
                case 3: res = h_type + s; break;


            }
            return res;
        }

        public void load_txtd()
        {
            int lbl = 6, lbl1 = 7;
            for (int t = 0; t < 16; t++)
            {
                Label lb1 = new Label();
                TextBoxX.TextBoxX txt1 = new TextBoxX.TextBoxX();
                txt1.Name = "txte" + t.ToString();
                lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb1.Name = "lble" + t.ToString();
                if (t < 8)
                {
                    lb1.Location = new System.Drawing.Point(lbl, 18);

                    txt1.Location = new System.Drawing.Point(lbl, 36);
                    lbl += 94;
                }
                else if (t < 16)
                {
                    lb1.Location = new System.Drawing.Point(lbl1, 60);
                    txt1.Location = new System.Drawing.Point(lbl1, 78);
                    lbl1 += 94;
                }
                lb1.Size = new System.Drawing.Size(37, 15);
                txt1.Size = new System.Drawing.Size(90, 22);
                txt1.TextChanged += new EventHandler(txt1_TextChanged);
                txt1.KeyUp += new KeyEventHandler(txt1_KeyUp);
                lbd[t] = lb1;
                txtd[t] = txt1;
                this.grpded.Controls.Add(lbd[t]);
                this.grpded.Controls.Add(txtd[t]);
            }
        }

        void txt1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        void txt1_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
                //double d1 = 0;
                //for (int tc = 0; tc < lbd.Length; tc++)
                //{

                //    Label ll = new Label();
                //    TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                //    ll = lbd[tc];
                //    if (lbd[tc] != null)
                //    {
                //        if (head_formula.ContainsKey(ll.Text.Trim()))
                //        {
                //            tx = txtd[tc];
                //            tx.Text = cal_formula(Convert.ToInt32(head_formula[ll.Text.Trim()]));
                //            txtd[tc] = tx;
                //            this.grpded.Controls.Add(txtd[tc]);

                //        }
                //    }

                //}
                //for (int tc = 0; tc < 16; tc++)
                //{
                //    TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                //    tx = txtd[tc];
                //    if (tx.Text != "")
                //        d1 = d1 + Convert.ToDouble(tx.Text.Trim());
                //}


                //for (int p = 0; p < 3; p++)
                //{
                //    TextBoxX.TextBoxX tx1 = new TextBoxX.TextBoxX();
                //    tx1 = txtp[p];
                //    if (tx1.Text.Trim() != "")
                //        d1 += Convert.ToDouble(tx1.Text.Trim());
                //}
                //if (txtd19.Text.Trim() != "")
                //    d1 += Convert.ToDouble(txtd19.Text.Trim());


                //txtdtot.Text = string.Format("{0:F}", d1);
                //sal_total();
            //}
            //catch (Exception x) { }
            try
            {
                sal_total();
            }
            catch (Exception ex) { }
        }

        public void get_data1()
        {
            string s = ""; int j = 1; int lbl = 6, lbl1 = 6, jt = 0;
            //hsh_PFd.Clear();
            //hsh_ESId.Clear();
            //hsh_PTd.Clear();
            s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE from tbl_Employee_Assign_SalStructure where session='" + cmbYear.Text.Trim() + "' and sal_struct=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " and p_type='D'";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Label lb = new Label();
                    //if (dt.Rows[i][1].ToString().Trim() == "E")
                    //{
                    //    lb = lbe[i];
                    //    lb.Text = get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E");
                    //    lbe[i] = lb;

                    //    this.grpern.Controls.Add(lbe[i]);
                    //    if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                    //    {
                    //        if (!head_formula.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                    //            head_formula.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][3].ToString());
                    //    }
                    //}
                    if (dt.Rows[i][1].ToString().Trim() == "D" && clsEmployee.GetMonth_SingleDigit(cmbMonth.Text.Trim()) >= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][4].ToString()) && clsEmployee.GetMonth_SingleDigit(cmbMonth.Text.Trim()) <= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][5].ToString()))
                    {
                        lb = lbd[i];
                        lb.Text = get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D");
                        lbd[i] = lb;
                        this.grpded.Controls.Add(lbd[i]);
                        if (dt.Rows[i][9].ToString().Trim() == "Nearest Rupee")
                        {
                            if (!hsh_rtype.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D")))
                                hsh_rtype.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D"), dt.Rows[i][9].ToString().Trim());
                        }
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            if (!head_formula.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D")))
                                head_formula.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D"), dt.Rows[i][3].ToString());
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                        {
                            if (!hsh_cmp_lumpsum.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D")))
                                hsh_cmp_lumpsum.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D"), dt.Rows[i][3].ToString());
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "SLAB")
                        {
                            if (!hsh_slab.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D")))
                                hsh_slab.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D"), dt.Rows[i][3].ToString());
                        }
                        //if (Convert.ToDouble(dt.Rows[i]["PF_PER"]) > 0)
                        //{
                        //    if (!hsh_PFd.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D")))
                        //        hsh_PFd.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D"), Convert.ToString(Convert.ToDouble(dt.Rows[i]["PF_PER"]) / 100));
                        //}
                        //if (Convert.ToDouble(dt.Rows[i]["ESI_PER"]) > 0)
                        //{
                        //    if (!hsh_ESId.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D")))
                        //        hsh_ESId.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D"), Convert.ToString(Convert.ToDouble(dt.Rows[i]["ESI_PER"]) / 100));
                        //}
                        //if (Convert.ToDouble(dt.Rows[i]["PT"]) > 0)
                        //{
                        //    if (!hsh_PTd.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D")))
                        //        hsh_PTd.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D"), dt.Rows[i]["PT"].ToString());
                        //}

                    }
                }
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {

        }

        public void clear_txt()
        {

            for (int tc = 0; tc < 16; tc++)
            {
                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbe[tc];
                tx = txte[tc];
                tx.Text = string.Empty;
                ll.Text = string.Empty;
                txte[tc] = tx;
                lbe[tc] = ll;
                this.grpern.Controls.Add(txte[tc]);
                this.grpern.Controls.Add(lbe[tc]);
            }
            for (int tc = 0; tc < 16; tc++)
            {
                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbd[tc];
                tx = txtd[tc];
                tx.Text = string.Empty;
                ll.Text = string.Empty;
                txtd[tc] = tx;
                lbd[tc] = ll;
                this.grpded.Controls.Add(txtd[tc]);
                this.grpded.Controls.Add(lbd[tc]);
            }
            for (int tc = 0; tc < 3; tc++)
            {
                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbp[tc];
                tx = txtp[tc];
                tx.Text = string.Empty;
                ll.Text = string.Empty;
                txtp[tc] = tx;
                lbp[tc] = ll;
                this.grpded.Controls.Add(txtp[tc]);
                this.grpded.Controls.Add(lbp[tc]);
            }
            txtpfvol.Text = string.Empty;
            txtpfvol.Enabled = false;
            chkpfvol.Checked = false;
            lbld19.Text = string.Empty;
            txtd19.Text = string.Empty;
            txtd20.Text = string.Empty;
            lbld20.Text = string.Empty;
            //txtetot.Text = "";
            txtdtot.Text = string.Empty;
            txtnetamt.Text = string.Empty;
            txttlwp.Text = string.Empty;
            txtalwp.Text = string.Empty;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cmbMonth.Text != "" && cmbempname.Text != "" && cmbsalstruc.Text != "")
            //    {
            //        get_data();
            //        get_data1();
            //    }
            //}
            //catch (Exception x) { }
        }

        private void cmbYear_DropDown(object sender, EventArgs e)
        {
            try
            {
                clear_txt();
            }
            catch (Exception x) { }
        }

        private void cmbMonth_DropDown(object sender, EventArgs e)
        {
            try
            {
                clear_txt();
            }
            catch (Exception x) { }
        }

        private void cmbsalstruc_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                hsh_rtype.Clear();
                string Locations = "";
                int day1 = 0, day2 = 0, calculateDay = 0, month_no = 0, Tot_Leave = 0;
                DataTable AllocateEmploy = clsDataAccess.RunQDTbl("select FromDate,Posting_Month,LOcation_ID from tbl_Emp_Posting where Employ_ID='" + emply_id + "' and Posting_Month = '" + cmbMonth.Text + "' order by FromDate ");

                DataTable SalaryLocation = clsDataAccess.RunQDTbl("select Location_ID from tbl_Employee_Link_SalaryStructure where SalaryStructure_ID=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " ");
                for (int i = 0; i <= SalaryLocation.Rows.Count - 1; i++)
                {
                    Locations = Locations + SalaryLocation.Rows[i]["Location_ID"];
                    if (i != SalaryLocation.Rows.Count - 1)
                        Locations = Locations + ",";
                }
                DataView dv = new DataView(SalaryLocation);
                int Cur_Month = dateTimePicker1.Value.Month;
                int Cur_year = dateTimePicker1.Value.Year;
                int Month_Day = Day_count(Cur_Month);
                DataTable leave_taken = clsDataAccess.RunQDTbl("select count(LeaveDate) from tbl_Employee_Attendance where ID='" + emply_id + "' and LeaveDate between '" + Cur_Month + "/01/" + Cur_year + "' and '" + Cur_Month + "/" + Month_Day + "/" + Cur_year + "' and LOcation_ID in (" + Locations + ")");
                if (leave_taken.Rows.Count > 0)
                {
                    if (Information.IsNumeric(leave_taken.Rows[0][0]) == true)
                        Tot_Leave = Convert.ToInt32(leave_taken.Rows[0][0]);
                }
                month_no = clsEmployee.GetMonth_SingleDigit(cmbMonth.Text);
                for (int i = 0; i <= AllocateEmploy.Rows.Count - 1; i++)
                {
                    dv.RowFilter = "Location_ID = " + AllocateEmploy.Rows[i]["LOcation_ID"] + "";
                    if (dv.Count > 0)
                    {
                        int co = i + 1;
                        int cou = AllocateEmploy.Rows.Count;
                        if (co < cou)
                            day2 = Convert.ToDateTime(AllocateEmploy.Rows[i + 1]["FromDate"]).Day;
                        else
                            day2 = Day_count(month_no) + 1;

                        day1 = Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day;


                        calculateDay = calculateDay + (day2 - day1);
                    }
                }
                calculateDay = calculateDay - Tot_Leave;
                txtattendence.Text = Convert.ToString(calculateDay);

                //sal_struct=" + get_SalStructID(cmbsalstruc.Text.Trim()) + "

                if (cmbMonth.Text != "" && cmbempname.Text != "" && cmbsalstruc.Text != "")
                {
                    string eid = "";
                    get_data();
                    get_data1();
                    Get_mnth_detl();
                    if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
                        eid = emp_id[cmbempname1111.Text.Trim()].ToString();

                    if (hsh_All_Mnth.ContainsKey(cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()))
                        view_sal(hsh_All_Mnth[cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()].ToString(),"Y");
                    else
                    {
                        if (hsh_lst_mnth.ContainsKey(cmbYear.Text.Trim() + "/" + eid.ToString()))
                            view_sal(hsh_lst_mnth[cmbYear.Text.Trim() + "/" + eid.ToString()].ToString(),"N");
                    }
                }
            }
            catch (Exception x) { }
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

        private void cmbempname_DropDownClosed(object sender, EventArgs e)
        {
            //try
            //{
            //    if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
            //          = emp_id[cmbempname1111.Text.Trim()].ToString();

            //    hsh_rtype.Clear();

            //    if (cmbMonth.Text != "" && cmbempname1111.Text != "" && cmbsalstruc.Text != "")
            //    {
            //        string eid = "";
            //        get_data();
            //        get_data1();
            //        Get_mnth_detl();
            //        if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
            //            eid = emp_id[cmbempname1111.Text.Trim()].ToString();
            //        if (hsh_All_Mnth.ContainsKey(cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()))
            //            view_sal(hsh_All_Mnth[cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()].ToString(),"Y");
            //        else
            //        {
            //            if (hsh_lst_mnth.ContainsKey(cmbYear.Text.Trim() + "/" + eid.ToString()))
            //                view_sal(hsh_lst_mnth[cmbYear.Text.Trim() + "/" + eid.ToString()].ToString(),"N");
            //        }
            //    }
            //}
            //catch (Exception x) { }
        }

        private void cmbMonth_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                hsh_rtype.Clear();
                if (cmbMonth.Text != "" && cmbempname1111.Text != "" && cmbsalstruc.Text != "")
                {
                    string eid = "";
                    get_data();
                    get_data1();
                    Get_mnth_detl();
                    if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
                        eid = emp_id[cmbempname1111.Text.Trim()].ToString();

                    if (hsh_All_Mnth.ContainsKey(cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()))
                        view_sal(hsh_All_Mnth[cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()].ToString(),"Y");
                    else
                    {
                        if (hsh_lst_mnth.ContainsKey(cmbYear.Text.Trim() + "/" + eid.ToString()))
                            view_sal(hsh_lst_mnth[cmbYear.Text.Trim() + "/" + eid.ToString()].ToString(),"N");
                    }
                }
               
            }
            catch (Exception x) { }
        }

        private void cmbYear_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                hsh_rtype.Clear();
                if (cmbMonth.Text != "" && cmbempname1111.Text != "" && cmbsalstruc.Text != "")
                {
                    string eid = "";
                    get_data();
                    get_data1();
                    Get_mnth_detl();
                    if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
                        eid = emp_id[cmbempname1111.Text.Trim()].ToString();

                    if (hsh_All_Mnth.ContainsKey(cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()))
                        view_sal(hsh_All_Mnth[cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()].ToString(),"Y");
                    else
                    {
                        if (hsh_lst_mnth.ContainsKey(cmbYear.Text.Trim() + "/" + eid.ToString()))
                            view_sal(hsh_lst_mnth[cmbYear.Text.Trim() + "/" + eid.ToString()].ToString(),"N");
                    }
                }
            }
            catch (Exception x) { }
        }

        public void save_sal_Det()
        {
            string s = "",eid="";bool b = false;
            //if(emp_id.ContainsKey(cmbempname.Text))
                //eid=emp_id[cmbempname.Text].ToString();
            eid = emply_id;
            Save_Sal_mst(eid);
            
            for (int tc = 0; tc < 16; tc++)
            {
                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbe[tc];
                tx = txte[tc];
                if (ll.Text.Trim() != "" && tx.Text.Trim()!="")
                {
                    s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(tx.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')";
                      Command_TR(s);
                    //b = clsDataAccess.RunNQwithStatus(s);
                    //if (!b)
                    //    ERPMessageBox.ERPMessage.Show("Error");

                }
            }
            for (int tc = 0; tc < 16; tc++)
            {
                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbd[tc];
                tx = txtd[tc];
                if (ll.Text.Trim() != "" && tx.Text.Trim() != "")
                {
                    s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_DeductionSalayHead'," + Convert.ToDouble(tx.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')";
                    Command_TR(s);
                    //b = clsDataAccess.RunNQwithStatus(s);
                    //if (!b)
                    //    ERPMessageBox.ERPMessage.Show("Error");
                }
            }

            for (int tc = 0; tc < 3; tc++)
            {
                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbp[tc];
                tx = txtp[tc];
                if (ll.Text.Trim() != "" && tx.Text.Trim() != "")
                {
                    s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_Config_PFHeads'," + Convert.ToDouble(tx.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')";
                    Command_TR(s);
                    //b = clsDataAccess.RunNQwithStatus(s);
                    //if (!b)
                    //    ERPMessageBox.ERPMessage.Show("Error");
                }
            }
            if (lbld19.Text.Trim() != "" && txtd19.Text.Trim() != "")
            {
                s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + eid + "'," +get_sal_head_ID(lbld19.Text.Trim()) +",'tbl_Employee_Config_PFHeads'," + Convert.ToDouble(txtd19.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')";
                Command_TR(s);

            }
            if (lbld20.Text.Trim() != "" && txtd20.Text.Trim() != "")
            {
                s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + eid + "'," + get_sal_head_ID(lbld20.Text.Trim()) + ",'tbl_Employee_Config_PFHeads'," + Convert.ToDouble(txtd20.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')";
                Command_TR(s);

            }
            if (chkpfvol.Checked && txtpfvol.Text.Trim() != "")
            {
                s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + eid + "',6 ,'tbl_Employee_Config_PFHeads'," + Convert.ToDouble(txtpfvol.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')";
                Command_TR(s);

            }
           
            //Save_Sal_mst(eid);
            //return b;
        }

        public int get_sl()
        {
            string s = "";int res=0;
            s = "select max(slno) from tbl_Employee_SalaryDet";
            DataTable dtt = new DataTable();
            dtt = clsDataAccess.RunQDTbl(s);
            if(dtt.Rows.Count>0 && dtt.Rows[0][0].ToString()!="")
            {
                res=Convert.ToInt32(dtt.Rows[0][0]);
            }
            return res + 1;
        }

        public void Save_Sal_mst(string eid)
        {
            string s = ""; bool b = false;
            s = "insert into tbl_Employee_SalaryMast(Emp_Id,TotalSal,TotalDec,NetPay,Month,Session,DaysPresent,LeaveWithPay,LeaveWithoutPay,TotalDays,GrossAmount,PFDue,TotalPF,Date_of_Insert) values('" + eid + "'," + Convert.ToDouble(txtetot.Text.Trim()) + "," + Convert.ToDouble(txtdtot.Text.Trim()) + "," + Convert.ToDouble(txtnetamt.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "',"+Convert.ToDouble(GetTotalDaysByMonth(cmbMonth.Text.Trim(), GetYear(cmbMonth.Text.Trim(), cmbYear.Text.Trim()))-(totLVWPay+totLVWOPay))+"," + totLVWPay + "," + totLVWOPay + "," + GetTotalDaysByMonth(cmbMonth.Text.Trim(), GetYear(cmbMonth.Text.Trim(), cmbYear.Text.Trim())) + "," + Convert.ToDouble(txtetot.Text.Trim()) + "," + pfdue + "," + totpf + ",'" + Convert.ToDateTime(dtpidate.Text.Trim()).Date.ToString("MM/dd/yyyy") + "')";
            Command_TR(s);
            //b = clsDataAccess.RunNQwithStatus(s);
            //return b;
        }

        public int get_sal_head_ID(string head)
        {

            string s = "";
            int pb = 0;
            DataTable dt1 = new DataTable();

            s = "select SalaryHead_Short,slno from tbl_Employee_ErnSalaryHead";
            dt1 = clsDataAccess.RunQDTbl(s);
            if (dt1.Rows.Count > 0)
            {
                for (int f = 0; f < dt1.Rows.Count; f++)
                {
                    if (dt1.Rows[f][0].ToString() == head)
                        pb = Convert.ToInt32(dt1.Rows[f][1]);
                }

            }

            dt1.Clear();
            dt1.Columns.Clear();
            s = "select SalaryHead_Short,slno from tbl_Employee_DeductionSalayHead";
            dt1 = clsDataAccess.RunQDTbl(s);
            if (dt1.Rows.Count > 0)
            {
                for (int f = 0; f < dt1.Rows.Count; f++)
                {
                    if (dt1.Rows[f][0].ToString() == head)
                        pb = Convert.ToInt32(dt1.Rows[f][1]);
                }

            }

            dt1.Clear();
            dt1.Columns.Clear();
            s = "select ShortName,SlNo from tbl_Employee_Config_PFHeads";
            dt1 = clsDataAccess.RunQDTbl(s);
            if (dt1.Rows.Count > 0)
            {
                for (int f = 0; f < dt1.Rows.Count; f++)
                {
                    if (dt1.Rows[f][0].ToString() == head)
                        pb = Convert.ToInt32(dt1.Rows[f][1]);
                }

            }

            return pb;
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //bool s= save_sal_Det();

            //    if (s)
            //    {
            //        clear_txt();
            //        ERPMessageBox.ERPMessage.Show("Record Inserted Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
            //    }
            //}
            //catch (Exception x) 
            //{
            //    ERPMessageBox.ERPMessage.Show("Error" + x.ToString());
            //}

        }

        private void txtetot_TextChanged(object sender, EventArgs e)
        {
            double pfc = 0, pt = 0, esit = 0; pfdue = 0;
            txtd19.Text = string.Empty;
            clea_p();
            for (int tc = 0; tc < 16; tc++)
            {
                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                    ll = lbe[tc];
                    tx = txte[tc];
                    if (lbe[tc] != null || ll.Text.Trim()!="")
                    {
                        if (hsh_PF.ContainsKey(ll.Text.Trim()))
                        {
                            if (tx.Text.Trim() != "")
                                pfc += Convert.ToDouble(tx.Text.Trim()) * Convert.ToDouble(hsh_PF[ll.Text.Trim()]);
                        }
                        if (hsh_ESI.ContainsKey(ll.Text.Trim()))
                        {
                            if (tx.Text.Trim() != "")
                                esit += Convert.ToDouble(tx.Text.Trim()) * Convert.ToDouble(hsh_ESI[ll.Text.Trim()]);

                        }
                        if (hsh_PT.ContainsKey(ll.Text.Trim()))
                        {
                            if (tx.Text.Trim() != "")
                            {
                                if (Convert.ToInt32(hsh_PT[ll.Text.Trim()]) == 1)
                                    pt += Convert.ToDouble(tx.Text.Trim());
                            }
                        }
                    }
            }
            if (pfc > 0)
            {
                PFCal(pfc,"PF");
                //pfdue=pfc;
            }
            if (esit > 0)
                PFCal(esit,"ESI");

            if (pt > 0)
                PT_Cal(pt);
            Get_Total_Leave();
            //pfloan_cal();
        }

        public void PFCal(double val,string pfesi)
        {
            string w = ""; double eei=0,cei=0,esi=0;
            //w = "select PFEMP,PFCUTOFF,ESIEMP,ESICMP,ESICUTOFF from tbl_Employee_PFESIRate where Year='" + cmbYear.Text.Trim() + "'";
            w = "select PFEMP,PFCUTOFF,ESIEMP,ESICMP,ESICUTOFF from tbl_Employee_PFESIRate where Year='" + cmbYear.Text.Trim() + "' and slno=(select max(slno) from tbl_Employee_PFESIRate where Year='" + cmbYear.Text.Trim() + "')";
            DataTable dtp = new DataTable();
            dtp = clsDataAccess.RunQDTbl(w);
            if (dtp.Rows.Count > 0)
            {
                if (pfesi == "PF")
                {
                    if ((val * Convert.ToDouble(dtp.Rows[0][0]) / 100) > Convert.ToDouble(dtp.Rows[0][1]))
                    {
                        PFlbTxt();
                        TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                        tx = txtp[0];
                        tx.Text = string.Format("{0:F}",Math.Round(Convert.ToDouble(dtp.Rows[0][1])));
                        txtp[0] = tx;
                        this.grpded.Controls.Add(txtp[0]);
                        pfdue = val;

                    }
                    else if ((val * Convert.ToDouble(dtp.Rows[0][0]) / 100) < Convert.ToDouble(dtp.Rows[0][1]))
                    {
                        PFlbTxt();
                        TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                        tx = txtp[0];
                        tx.Text = string.Format("{0:F}",Math.Round((val * Convert.ToDouble(dtp.Rows[0][0]) / 100)));
                        txtp[0] = tx;
                        this.grpded.Controls.Add(txtp[0]);
                        pfdue = val;

                    }
                }
                else if (pfesi == "ESI")
                {
                    if (val < Convert.ToDouble(dtp.Rows[0][4]))
                    {

                        lbld20.Visible = true;
                        lbld20.Text = "ESI";
                        txtd20.Text = string.Format("{0:N}", Math.Round((val * Convert.ToDouble(dtp.Rows[0][2]) / 100)));
                        //pfdue = 0;

                    }
                    else
                    {
                        lbld20.Visible = false;
                        lbld20.Text = string.Empty;
                        txtd20.Text = string.Empty;
                        //pfdue = 0;
                    }
                }
            }
        }

        public void load_txtp()
        {

            int lbl = 6, lbl1 = 7;
            for (int t = 0; t < 3; t++)
            {
                Label lb1 = new Label();
                TextBoxX.TextBoxX txt2 = new TextBoxX.TextBoxX();
                txt2.Name = "txtp" + t.ToString();
                lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb1.Name = "lblp" + t.ToString();
                    lb1.Location = new System.Drawing.Point(lbl, 103);

                    txt2.Location = new System.Drawing.Point(lbl,120);
                    lbl += 94;
                
                lb1.Size = new System.Drawing.Size(37, 15);
                txt2.Size = new System.Drawing.Size(90, 22);
                txt2.TextChanged += new EventHandler(txt2_TextChanged);
                lbp[t] = lb1;
                txtp[t] = txt2;
                this.grpded.Controls.Add(lbp[t]);
                this.grpded.Controls.Add(txtp[t]);

            }

        }

        void txt2_TextChanged(object sender, EventArgs e)
        {
            //double d1 = 0;
            //d1 = Convert.ToDouble(txtdtot.Text.Trim());
            //for (int p = 0; p < 3; p++)
            //{
            //    TextBoxX.TextBoxX tx1 = new TextBoxX.TextBoxX();
            //    tx1 = txtp[p];
            //    if (tx1.Text.Trim() != "")
            //        d1 += Convert.ToDouble(tx1.Text.Trim());

            //}
            //txtdtot.Text = string.Format("{0:F}", d1);
            sal_total();
        }

        public void PFlbTxt()
        {
            string s = "select shortname from tbl_Employee_Config_PFHeads";
            DataTable dtp = new DataTable();
            dtp = clsDataAccess.RunQDTbl(s);
            if (dtp.Rows.Count > 0)
            {
                for (int p = 0; p <=2; p++)
                {
                    Label lb = new Label();

                    lb = lbp[p];
                    lb.Text = dtp.Rows[p][0].ToString();
                    lbp[p] = lb;
                    this.grpded.Controls.Add(lbp[p]);

                }
                
            }

        }

        public void clea_p()
        {
            for (int tc = 0; tc < 3; tc++)
            {

                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbp[tc];
                tx = txtp[tc];
                tx.Text = string.Empty;
                ll.Text = string.Empty;
                txtp[tc] = tx;
                lbp[tc] = ll;
                this.grpded.Controls.Add(txtp[tc]);
                this.grpded.Controls.Add(lbp[tc]);



            }
        }

        private void txtdtot_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sal_total();
                Get_Total_Leave();
            }
            catch (Exception ex) { }
        }

        public void PT_Cal(double rate)
        {
            Label lbt = new Label();
            TextBoxX.TextBoxX txt = new TextBoxX.TextBoxX();
            string s = "";
            //s = "select pt,wfrom,wto from tbl_Employee_PTRate where Session='" + cmbYear.Text.Trim() + "' and monthof='" + cmbMonth.Text.Trim() + "'";
            s = "select pt,wfrom,wto from tbl_Employee_PTRate where Session='" + cmbYear.Text.Trim() + "'";// and ptgroup='" +get_SalStructID(cmbsalstruc.Text.Trim()).ToString() + "'";
            DataTable dtpt = new DataTable();
            dtpt = clsDataAccess.RunQDTbl(s);
            if(dtpt.Rows.Count>0)
            {
                for(int t=0;t<dtpt.Rows.Count;t++)
                {
                    if (dtpt.Rows[t][2].ToString() != "Max.Value")
                    {
                        if (rate >= Convert.ToDouble(dtpt.Rows[t][1]) && rate <= Convert.ToDouble(dtpt.Rows[t][2]))
                        {

                            lbld19.Visible = true;
                            lbld19.Text = "PT";
                            txtd19.Text = dtpt.Rows[t][0].ToString();
                        }
                    }
                    else if (Convert.ToString(dtpt.Rows[t][2]) == "Max.Value")
                    {
                        if (rate >= Convert.ToDouble(dtpt.Rows[t][1]) && Convert.ToString(dtpt.Rows[t][2]) == "Max.Value")
                        {
                            lbld19.Visible = true;
                            lbld19.Text = "PT";
                            txtd19.Text = dtpt.Rows[t][0].ToString();
                        }

                    }
                    
                }
            }
            
 
        }

        private void txtd19_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    double d1 = 0;
            //    d1 = Convert.ToDouble(txtdtot.Text.Trim());
               
            //    txtdtot.Text = string.Format("{0:F}", d1);
            //}
            //catch (Exception x) { }
            try
            {
                if (txtd19.Text.Trim() == "")
                    lbld19.Text = string.Empty;
                sal_total();
            }
            catch (Exception ex) { }
        }

        private void txteot1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //double e1 = 0;
                //e1 = Convert.ToDouble(txtetot.Text.Trim());
                //if (txteot1.Text.Trim() != "")
                //    e1 += Convert.ToDouble(txteot1.Text.Trim());
                //txtetot.Text = string.Format("{0:F}", e1);
                sal_total();
            }
            catch (Exception x) { }

        }

        private void txteot2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //double e1 = 0;
                //e1 = Convert.ToDouble(txtetot.Text.Trim());
                //if (txteot2.Text.Trim() != "")
                //    e1 += Convert.ToDouble(txteot2.Text.Trim());

                //txtetot.Text = string.Format("{0:F}", e1);
                sal_total();
            }
            catch (Exception x) { }
        }

        public void sal_total()
        {
            double e1 = 0, d1 = 0;
            totpf = 0; 

            for (int tc = 0; tc < 16; tc++)
            {

                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbe[tc];
                if (lbe[tc] != null)
                {
                    if (head_formula.ContainsKey(ll.Text.Trim()))
                    {
                        tx = txte[tc];
                        if (hsh_rtype.ContainsKey(ll.Text.Trim()))
                            tx.Text = Convert.ToString(Math.Round(Convert.ToDouble(cal_formula(Convert.ToInt32(head_formula[ll.Text.Trim()])))));
                        else
                        {
                            //string amt = string.Format("{0:F}", Convert.ToDouble(cal_formula(Convert.ToInt32(head_formula[ll.Text.Trim()]))));
                            string amt = string.Format("{0:F}",(Math.Round(Convert.ToDouble(cal_formula(Convert.ToInt32(head_formula[ll.Text.Trim()]))))));
                            tx.Text = amt;
                        }

                        txte[tc] = tx;
                        this.grpern.Controls.Add(txte[tc]);

                    }
                    if (hsh_cmp_lumpsum.ContainsKey(ll.Text.Trim()))
                    {
                        tx = txte[tc];
                        if (hsh_rtype.ContainsKey(ll.Text.Trim()))
                            tx.Text = Convert.ToString(Math.Round(Convert.ToDouble(cal_Cmp_Lumpsum(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()])))));
                        else
                        {
                            if (tc == 0)
                            {
                                if (Information.IsNumeric(txtattendence.Text) == true)
                                {
                                    int Cur_Month = dateTimePicker1.Value.Month;                                    
                                    int Month_Day = Day_count(Cur_Month);
                                    string lum_amt = cal_Cmp_Lumpsum(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()]));
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    //tx.Text = Convert.ToString(Math.Round(amt)); string.Format("{0:F}", e1);
                                    tx.Text = string.Format("{0:F}",amt);
                                }
                                else
                                    tx.Text = cal_Cmp_Lumpsum(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()]));
                            }
                            else
                                tx.Text = cal_Cmp_Lumpsum(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()]));
                        }
                        txte[tc] = tx;
                        this.grpern.Controls.Add(txte[tc]);
                    }

                    
                    //if (hsh_slab.ContainsKey(ll.Text.Trim()))
                    //{
                    //    tx = txte[tc];
                    //    tx.Text = cal_Slab(Convert.ToInt32(hsh_slab[ll.Text.Trim()]), e1);
                    //    txte[tc] = tx;
                    //    this.grpern.Controls.Add(txte[tc]);
                    //}

                }

            }

            for (int tc = 0; tc < 16; tc++)
            {

                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbd[tc];
                if (lbd[tc] != null)
                {
                    if (head_formula.ContainsKey(ll.Text.Trim()))
                    {
                        tx = txtd[tc];
                        if (hsh_rtype.ContainsKey(ll.Text.Trim()))
                            tx.Text = Convert.ToString(Math.Round(Convert.ToDouble(cal_formula(Convert.ToInt32(head_formula[ll.Text.Trim()])))));
                        else
                            tx.Text = string.Format("{0:F}",(Math.Round(Convert.ToDouble(cal_formula(Convert.ToInt32(head_formula[ll.Text.Trim()]))))));
                        txtd[tc] = tx;
                        this.grpded.Controls.Add(txtd[tc]);

                    }
                    if (hsh_cmp_lumpsum.ContainsKey(ll.Text.Trim()))
                    {
                        tx = txtd[tc];
                        if (hsh_rtype.ContainsKey(ll.Text.Trim()))
                            tx.Text = Convert.ToString(Math.Round(Convert.ToDouble(cal_Cmp_Lumpsum(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()])))));
                        else
                            tx.Text = cal_Cmp_Lumpsum(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()]));
                        txtd[tc] = tx;
                        this.grpded.Controls.Add(txtd[tc]);
                    }
                    //if (hsh_slab.ContainsKey(ll.Text.Trim()))
                    //{
                    //    tx = txtd[tc];
                    //    tx.Text = cal_Slab(Convert.ToInt32(hsh_slab[ll.Text.Trim()]));
                    //    txtd[tc] = tx;
                    //    this.grpded.Controls.Add(txtd[tc]);
                    //}
                }
            }

            for (int tc = 0; tc < 16; tc++)
            {
                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbe[tc];
                tx = txte[tc];
                if (tx.Text != "" && ll.Text!="")
                    e1 = e1 + Convert.ToDouble(tx.Text.Trim());
                tx = txtd[tc];
                ll = lbd[tc];
                if (tx.Text != "" && ll.Text!="")
                    d1 = d1 + Convert.ToDouble(tx.Text.Trim());
            }
//************************
            for (int tc = 0; tc < 16; tc++)
            {

                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbe[tc];
                if (lbe[tc] != null)
                {
                    if (hsh_slab.ContainsKey(ll.Text.Trim()))
                    {
                        tx = txte[tc];
                        if (hsh_rtype.ContainsKey(ll.Text.Trim()))
                            tx.Text = Convert.ToString(Math.Round(Convert.ToDouble(cal_Slab(Convert.ToInt32(hsh_slab[ll.Text.Trim()]), e1))));
                        else
                            tx.Text = cal_Slab(Convert.ToInt32(hsh_slab[ll.Text.Trim()]), e1);
                        txte[tc] = tx;
                        this.grpern.Controls.Add(txte[tc]);
                    }

                }

            }

            for (int tc = 0; tc < 16; tc++)
            {

                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbd[tc];
                if (lbd[tc] != null)
                {

                    if (hsh_slab.ContainsKey(ll.Text.Trim()))
                    {
                        tx = txtd[tc];
                        if (hsh_rtype.ContainsKey(ll.Text.Trim()))
                            tx.Text = Convert.ToString(Math.Round(Convert.ToDouble(cal_Slab(Convert.ToInt32(hsh_slab[ll.Text.Trim()]), e1))));//e1
                        else
                            tx.Text = cal_Slab(Convert.ToInt32(hsh_slab[ll.Text.Trim()]), e1);
                        txtd[tc] = tx;
                        this.grpded.Controls.Add(txtd[tc]);
                    }
                }
            }
//*************************

            for (int p = 0; p < 3; p++)
            {
                Label lb = new Label();
                TextBoxX.TextBoxX tx1 = new TextBoxX.TextBoxX();
                lb = lbp[p];
                tx1 = txtp[p];
                if (tx1.Text.Trim() != "")
                {
                    d1 += Convert.ToDouble(tx1.Text.Trim());
                    if (lb.Text.Trim() != "ESI" && lb.Text.Trim()!="")
                    {
                        totpf += Convert.ToDouble(tx1.Text.Trim());
                        if (!hsh_chk_SalPFHead.ContainsKey(get_sal_head_ID(lb.Text.Trim())))
                            hsh_chk_SalPFHead.Add(get_sal_head_ID(lb.Text.Trim()), "");
                    }
                }
                //else
                //{

                if (lb.Text.Trim() == "PFL" && lb.Text.Trim() != "")
                    {
                        pfloan_cal();
                        if (!hsh_chk_SalPFHead.ContainsKey(get_sal_head_ID(lb.Text.Trim())))
                            hsh_chk_SalPFHead.Add(get_sal_head_ID(lb.Text.Trim()), "");
                        tx1 = txtp[1];
                        if (tx1.Text.Trim() == "")
                            tx1.Text = "0.00";
                        

                        txtp[1] = tx1;
                    }
                    if (lb.Text.Trim() == "PFLI" && lb.Text.Trim() != "")
                    {
                        tx1 = txtp[2];
                        if (tx1.Text.Trim() == "")
                            tx1.Text = "0.00";


                        txtp[2] = tx1;
                    }
                

                    //if (lb.Text.Trim() != "ESI" && lb.Text.Trim()!="")
                    //{
                    //    tx1.Text = "0.00";
                    //    if (!hsh_chk_SalPFHead.ContainsKey(get_sal_head_ID(lb.Text.Trim())))
                    //        hsh_chk_SalPFHead.Add(get_sal_head_ID(lb.Text.Trim()), "");
                    //    txtp[p] = tx1;
                    //}

                //}
            }
            if (txteot1.Text.Trim() != "")
                e1 += Convert.ToDouble(txteot1.Text.Trim());
                        
            if (txteot2.Text.Trim() != "")
                e1 += Convert.ToDouble(txteot2.Text.Trim());



            if (txtd19.Text.Trim() != "")
            {
                d1 += Convert.ToDouble(txtd19.Text.Trim());
                //if (!hsh_chk_PT.ContainsKey("1"))
                //    hsh_chk_PT.Add("1", "");
            }
            if (txtd20.Text.Trim() != "")
            {
                d1 += Convert.ToDouble(txtd20.Text.Trim());
            }
            if (chkpfvol.Checked && txtpfvol.Text.Trim() != "")
            {
                d1 += Convert.ToDouble(txtpfvol.Text.Trim());
            }

           
            txtetot.Text = string.Format("{0:F}", e1);
            txtdtot.Text = string.Format("{0:F}", d1);
            //txtnetamt.Text = string.Format("{0:F}", ((Convert.ToDouble(txtetot.Text.Trim()) - Convert.ToDouble(txtdtot.Text.Trim())) + LeaveAmt));

        }

        public void view_sal(string Mnth,string Exts)
        {
            string w = ""; hsh_chk_SalErnHead.Clear(); hsh_chk_SalDedHead.Clear(); hsh_chk_SalPFHead.Clear(); hsh_chk_PT.Clear(); hsh_chk_esi.Clear(); hsh_chk_pfVol.Clear();
            string eid="";
            if(emp_id.ContainsKey(cmbempname1111.Text.Trim()))
                eid=emp_id[cmbempname1111.Text.Trim()].ToString();
            
            w = "select distinct salid,tablename,amount,TotalSal,TotalDec,NetPay from tbl_Employee_SalaryDet as esd inner join tbl_Employee_SalaryMast as esm on esd.EmpId=esm.Emp_Id";
            w += " and esd.Month=esm.Month and esd.Session=esm.Session where esd.EmpId='" + eid + "' and esd.month='" + Mnth + "' and esd.session='" + cmbYear.Text.Trim() + "'";

            DataTable ddt = new DataTable();
            ddt = clsDataAccess.RunQDTbl(w);
            if (ddt.Rows.Count > 0)
            {
                PFlbTxt();
                for (int d = 0; d < ddt.Rows.Count; d++)
                {
                    if (ddt.Rows[d][1].ToString() == "tbl_Employee_ErnSalaryHead")
                    {
                        for (int le = 0; le < 16; le++)
                        {
                            Label lb = new Label();
                            TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                            lb = lbe[le];
                            tx=txte[le];
                            if (Convert.ToInt32(ddt.Rows[d][0]) == get_sal_head_ID(lb.Text.Trim()))
                            {
                                tx.Text = ddt.Rows[d][2].ToString();
                                if (!hsh_chk_SalErnHead.ContainsKey(ddt.Rows[d][0].ToString()))
                                    hsh_chk_SalErnHead.Add(ddt.Rows[d][0].ToString(),"");
                            }
                            txte[le] = tx;
                            this.grpern.Controls.Add(txte[le]);

                        }
                        
                    }
                    if (ddt.Rows[d][1].ToString() == "tbl_Employee_DeductionSalayHead")
                    {
                        for (int le = 0; le < 16; le++)
                        {
                            Label lb = new Label();
                            TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                            lb = lbd[le];
                            tx = txtd[le];
                            if (Convert.ToInt32(ddt.Rows[d][0]) == get_sal_head_ID(lb.Text.Trim()))
                            {
                                tx.Text = ddt.Rows[d][2].ToString();
                                if (!hsh_chk_SalDedHead.ContainsKey(ddt.Rows[d][0].ToString()))
                                    hsh_chk_SalDedHead.Add(ddt.Rows[d][0].ToString(),"");
                            }
                            txtd[le] = tx;
                            this.grpded.Controls.Add(txtd[le]);
                        }

                    }
                    //else
                    //{
                    //    for (int le = 0; le < 16; le++)
                    //    {
                           
                    //        TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                    //       tx = txtd[le];
                    //       txtd[le] = tx;
                    //        this.grpern.Controls.Add(txtd[le]);
                    //    }
                    //}
                    if (ddt.Rows[d][1].ToString() == "tbl_Employee_Config_PFHeads")
                    {
                       
                        for (int le = 0; le < 3; le++)
                        {
                            Label lb = new Label();
                            TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                            lb = lbp[le];
                            tx = txtp[le];
                            if (Convert.ToInt32(ddt.Rows[d][0]) == get_sal_head_ID(lb.Text.Trim()))
                            {
                                if (Exts == "N")
                                {
                                    if (le >= 1)
                                    {
                                        pfloan_cal();
                                    }
                                    else
                                    {
                                        tx.Text = ddt.Rows[d][2].ToString();
                                    }
                                }
                                else if (Exts == "Y")
                                {
                                    tx.Text = ddt.Rows[d][2].ToString();
                                }
                                if (!hsh_chk_SalPFHead.ContainsKey(get_sal_head_ID(lb.Text.Trim())))
                                    hsh_chk_SalPFHead.Add(get_sal_head_ID(lb.Text.Trim()), "");
                            }

                           txtp[le] = tx;
                         
                            this.grpded.Controls.Add(txtp[le]);
                        }

                    }
                    if (ddt.Rows[d][1].ToString() == "tbl_Employee_Config_PFHeads" && Convert.ToInt32(ddt.Rows[d][0])==5)
                    {
                        if (lbld19.Text != "")
                        
                            txtd19.Text = ddt.Rows[d][2].ToString();
                            if (!hsh_chk_PT.ContainsKey("5"))
                                hsh_chk_PT.Add("5", "");
                        
                    }
                    if (ddt.Rows[d][1].ToString() == "tbl_Employee_Config_PFHeads" && Convert.ToInt32(ddt.Rows[d][0]) == 4)
                    {
                        if (lbld20.Text != "")
                        
                            txtd20.Text = ddt.Rows[d][2].ToString();
                            if (!hsh_chk_esi.ContainsKey("4"))
                                hsh_chk_esi.Add("4", "");
                        
                    }
                    if (ddt.Rows[d][1].ToString() == "tbl_Employee_Config_PFHeads" && Convert.ToInt32(ddt.Rows[d][0]) == 6)
                    {
                        if (Convert.ToDouble(ddt.Rows[d][2]) > 0)
                        {
                            chkpfvol.Checked = true;
                            txtpfvol.Enabled = true;
                            txtpfvol.Text = ddt.Rows[d][2].ToString();
                        }
                        if (!hsh_chk_pfVol.ContainsKey("6"))
                            hsh_chk_pfVol.Add("6", "");
                    }
                    //else
                    //{
                    //    for (int le = 0; le < 3; le++)
                    //    {

                    //        TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                    //        tx = txtp[le];
                    //        txtp[le] = tx;
                    //        this.grpern.Controls.Add(txtp[le]);
                    //    }
                    //}

                }
            }
        }

        public void Get_EmpID()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string tl="",fn="",mn="",ln="";int sp=0,t=0;
            for(int i=0;i<cmbempname1111.Text.Trim().Length;i++)
            {
                char k = Convert.ToChar(cmbempname1111.Text.Trim().Substring(i, 1));
                if (k == ' ')
                {
                    if (sp == 0)
                    {
                        tl = cmbempname1111.Text.Trim().Substring(t, cmbempname1111.Text.Trim().IndexOf(' ', t));
                        sp += 1;
                        t = i + 1;
                    }
                    else if (sp == 1)
                    {       
                        fn = cmbempname1111.Text.Trim().Substring(t, cmbempname1111.Text.Trim().IndexOf(' ', t) - t);
                        sp += 1;
                        t = i + 1;
                    }
                    else if (sp == 2)
                    {
                        mn = cmbempname1111.Text.Trim().Substring(t, cmbempname1111.Text.Trim().IndexOf(' ', t) - t);
                        sp += 1;
                        t = i + 1;
                    }
                }
                
                
            }
            
            ln = cmbempname1111.Text.Trim().Substring(t);
            //string s = "select id from tbl_Employee_Mast where title='"+tl+"' and FirstName='"+fn+"' and MiddleName='"+mn+"' and LastName='"+
            //dt = clsDataAccess.RunQDTbl(s);
            //return Convert.ToInt32(dt.Rows[0][0]);
        }

        public void Get_mnth_detl()
        {
            string eid = "";
            hsh_All_Mnth.Clear();
            hsh_lst_mnth.Clear();
            if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
                eid = emp_id[cmbempname1111.Text.Trim()].ToString();

            string s = "";
            s = "select session,month,emp_id from tbl_Employee_SalaryMast where session='"+cmbYear.Text.Trim()+"' and emp_id='"+eid+"' and slno=(select max(slno) from tbl_Employee_SalaryMast where emp_id='"+eid+"')";

            DataTable temp_dt = new DataTable();
            temp_dt = clsDataAccess.RunQDTbl(s);
            if (temp_dt.Rows.Count > 0)
            {
                hsh_lst_mnth.Add(temp_dt.Rows[0][0].ToString() + "/" + temp_dt.Rows[0][2].ToString(), temp_dt.Rows[0][1].ToString());
            }

            s = "select session,month,emp_id from tbl_Employee_SalaryMast where session='"+cmbYear.Text.Trim()+"' and emp_id='"+eid+"'";
            DataTable temp_dt1 = new DataTable();
            temp_dt1 = clsDataAccess.RunQDTbl(s);
            if (temp_dt1.Rows.Count > 0)
            {
                for (int te = 0; te < temp_dt1.Rows.Count; te++)
                {
                    string s1 = temp_dt1.Rows[te][0].ToString() + "/" + temp_dt1.Rows[te][1].ToString() + "/" + temp_dt1.Rows[te][2].ToString();
                    if(!hsh_All_Mnth.ContainsKey(temp_dt1.Rows[te][0].ToString() + "/" + temp_dt1.Rows[te][1].ToString() + "/" + temp_dt1.Rows[te][2].ToString()))
                    hsh_All_Mnth.Add(temp_dt1.Rows[te][0].ToString() + "/" + temp_dt1.Rows[te][1].ToString() + "/" + temp_dt1.Rows[te][2].ToString(), temp_dt1.Rows[te][1].ToString());
                }
            }

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                string eid = ""; bool s_Msg = false;
                //if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
                //    eid = emp_id[cmbempname.Text.Trim()].ToString();
                eid = emply_id;
                if (!hsh_All_Mnth.ContainsKey(cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()))
                {
                    if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                        con.Open();
                    sqltran = con.BeginTransaction();
                    save_sal_Det();
                    sqltran.Commit();
                    sqltran = con.BeginTransaction();
                    Loan_Repaid();
                    sqltran.Commit();
                    s_Msg = true;
                    if (s_Msg)
                    {
                        clear_txt();
                        ERPMessageBox.ERPMessage.Show("Record Inserted Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }

                }
                else
                {
                    if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                        con.Open();
                    sqltran = con.BeginTransaction();
                    Update_sal_Det();
                    sqltran.Commit();
                    s_Msg = true;
                    if (s_Msg)
                    {
                        clear_txt();
                        ERPMessageBox.ERPMessage.Show("Record Updated Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                }

            }
             catch (Exception x)
            {
                sqltran.Rollback();
                ERPMessageBox.ERPMessage.Show("Error" + x.ToString());
            }
            finally
            {
                con.Close();
                
            }
        }

        public void Update_sal_Det()
        {
            string s = "", eid = ""; bool b = false;
            //if (emp_id.ContainsKey(cmbempname.Text))
            //    eid = emp_id[cmbempname.Text].ToString();
            eid = emply_id;
            Update_Sal_mst(eid);

            for (int tc = 0; tc < 16; tc++)
            {

                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbe[tc];
                tx = txte[tc];
                if (ll.Text.Trim() != "" && tx.Text.Trim() != "")
                {
                    
                    if(hsh_chk_SalErnHead.ContainsKey(Convert.ToString(get_sal_head_ID(ll.Text.Trim()))))
                    s = "update tbl_Employee_SalaryDet set Amount=" + Convert.ToDouble(tx.Text.Trim()) + " where EmpId='" + eid + "' and SalId=" + get_sal_head_ID(ll.Text.Trim()) + " and TableName= 'tbl_Employee_ErnSalaryHead' and Month='" + cmbMonth.Text.Trim() + "' and Session='" + cmbYear.Text.Trim() + "'";  //values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(tx.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "','" + System.DateTime.Now + "')";
                    else
                    s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(tx.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')";

                Command_TR(s);
                    //b = clsDataAccess.RunNQwithStatus(s);
                    //if (!b)
                    //    ERPMessageBox.ERPMessage.Show("Error");
                }

            }
            for (int tc = 0; tc < 16; tc++)
            {

                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbd[tc];
                tx = txtd[tc];
                if (ll.Text.Trim() != "" && tx.Text.Trim() != "")
                {
                    if (hsh_chk_SalDedHead.ContainsKey(Convert.ToString(get_sal_head_ID(ll.Text.Trim()))))
                   s = "update tbl_Employee_SalaryDet set Amount=" + Convert.ToDouble(tx.Text.Trim()) + " where EmpId='" + eid + "' and SalId=" + get_sal_head_ID(ll.Text.Trim()) + " and TableName= 'tbl_Employee_DeductionSalayHead' and Month='" + cmbMonth.Text.Trim() + "' and Session='" + cmbYear.Text.Trim() + "'";
                    else
                   s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_DeductionSalayHead'," + Convert.ToDouble(tx.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')";

               Command_TR(s);
                   //b = clsDataAccess.RunNQwithStatus(s);
                    //if (!b)
                    //    ERPMessageBox.ERPMessage.Show("Error");
                }

            }

            for (int tc = 0; tc < 3; tc++)
            {

                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbp[tc];
                tx = txtp[tc];
                if (ll.Text.Trim() != "" && tx.Text.Trim() != "")
                {
                   
                    if (hsh_chk_SalPFHead.ContainsKey(get_sal_head_ID(ll.Text.Trim())))
                    s = "update tbl_Employee_SalaryDet set Amount=" + Convert.ToDouble(tx.Text.Trim()) + " where EmpId='" + eid + "' and SalId=" + get_sal_head_ID(ll.Text.Trim()) + " and TableName= 'tbl_Employee_Config_PFHeads' and Month='" + cmbMonth.Text.Trim() + "' and Session='" + cmbYear.Text.Trim() + "'";//"insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session,InsertionDate) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_Config_PFHeads'," + Convert.ToDouble(tx.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "','" + System.DateTime.Now + "')";
                else
                    s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_Config_PFHeads'," + Convert.ToDouble(tx.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')";
                    Command_TR(s);
                    //b = clsDataAccess.RunNQwithStatus(s);
                    //if (!b)
                    //    ERPMessageBox.ERPMessage.Show("Error");
                }

            }
            if (lbld19.Text.Trim() != "" && txtd19.Text.Trim() != "")
            {
                if(hsh_chk_PT.ContainsKey("5"))
                    s = "update tbl_Employee_SalaryDet set Amount=" + Convert.ToDouble(txtd19.Text.Trim()) + " where EmpId='" + eid + "' and SalId="+get_sal_head_ID(lbld19.Text.Trim())+" and TableName= 'tbl_Employee_Config_PFHeads' and Month='" + cmbMonth.Text.Trim() + "' and Session='" + cmbYear.Text.Trim() + "'";//"insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session,InsertionDate) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_Config_PFHeads'," + Convert.ToDouble(tx.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "','" + System.DateTime.Now + "')";
                else
                    s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + eid + "',"+get_sal_head_ID(lbld19.Text.Trim())+",'tbl_Employee_Config_PFHeads'," + Convert.ToDouble(txtd19.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')";
                Command_TR(s);
            }
            if (lbld20.Text.Trim() != "" && txtd20.Text.Trim() != "")
            {
                if (hsh_chk_esi.ContainsKey("4"))
                    s = "update tbl_Employee_SalaryDet set Amount=" + Convert.ToDouble(txtd20.Text.Trim()) + " where EmpId='" + eid + "' and SalId=" + get_sal_head_ID(lbld20.Text.Trim()) + " and TableName= 'tbl_Employee_Config_PFHeads' and Month='" + cmbMonth.Text.Trim() + "' and Session='" + cmbYear.Text.Trim() + "'";//"insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session,InsertionDate) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_Config_PFHeads'," + Convert.ToDouble(tx.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "','" + System.DateTime.Now + "')";
                else
                    s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + eid + "'," + get_sal_head_ID(lbld20.Text.Trim()) + ",'tbl_Employee_Config_PFHeads'," + Convert.ToDouble(txtd20.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')";
                Command_TR(s);
            }
            if ((chkpfvol.Checked && txtpfvol.Text.Trim() != "")|| (!chkpfvol.Checked && txtpfvol.Text.Trim()== "0") )
            {
                if (hsh_chk_pfVol.ContainsKey("6"))
                    s = "update tbl_Employee_SalaryDet set Amount=" + Convert.ToDouble(txtpfvol.Text.Trim()) + " where EmpId='" + eid + "' and SalId=6 and TableName= 'tbl_Employee_Config_PFHeads' and Month='" + cmbMonth.Text.Trim() + "' and Session='" + cmbYear.Text.Trim() + "'";//"insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session,InsertionDate) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_Config_PFHeads'," + Convert.ToDouble(tx.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "','" + System.DateTime.Now + "')";
                else
                    s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session) values('" + eid + "',6,'tbl_Employee_Config_PFHeads'," + Convert.ToDouble(txtpfvol.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "')";
                Command_TR(s);
            }
            //Update_Sal_mst(eid);

            //return b;
        }
        public void Command_TR(string qry)
        {
            cmd.Connection = con;
            cmd.Transaction = sqltran;
            cmd.CommandText = qry;
            cmd.ExecuteNonQuery();
        }

        public void Update_Sal_mst(string eid)
        {
            string s = ""; bool b = false;
            s = "update tbl_Employee_SalaryMast set TotalSal=" + Convert.ToDouble(txtetot.Text.Trim()) + ",TotalDec=" + Convert.ToDouble(txtdtot.Text.Trim()) + ",NetPay=" + Convert.ToDouble(txtnetamt.Text.Trim()) + ",TotalDays=" + GetTotalDaysByMonth(cmbMonth.Text.Trim(), GetYear(cmbMonth.Text.Trim(), cmbYear.Text.Trim())) + ",GrossAmount=" + Convert.ToDouble(txtetot.Text.Trim()) + ",PFDue=" + pfdue + ",TotalPF=" + totpf + ",Date_of_Insert='" + Convert.ToDateTime(dtpidate.Text.Trim()).Date.ToString("MM/dd/yyyy") + "',LeaveWithPay=" + totLVWPay + ",LeaveWithoutPay=" + totLVWOPay + ",DaysPresent=" + Convert.ToDouble(GetTotalDaysByMonth(cmbMonth.Text.Trim(), GetYear(cmbMonth.Text.Trim(), cmbYear.Text.Trim())) - (totLVWPay + totLVWOPay)) + " where Emp_Id='" + eid + "' and Month='" + cmbMonth.Text.Trim() + "' and Session='" + cmbYear.Text.Trim() + "'";  // values('" + eid + "'," + Convert.ToDouble(txtetot.Text.Trim()) + "," + Convert.ToDouble(txtdtot.Text.Trim()) + "," + Convert.ToDouble(txtnetamt.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "','" + System.DateTime.Now + "'," + Convert.ToDouble(txtnetamt.Text.Trim()) + "," + pfdue + "," + totpf + ")";
            //s = "delete from tbl_Employee_SalaryMast where Emp_Id='" + eid + "' and Month='" + cmbMonth.Text.Trim() + "' and Session='" + cmbYear.Text.Trim() + "'";  
            //Command_TR(s);
            //s = "insert into tbl_Employee_SalaryMast(Emp_Id,TotalSal,TotalDec,NetPay,Month,Session,DaysPresent,LeaveWithPay,LeaveWithoutPay,TotalDays,GrossAmount,PFDue,TotalPF,Date_of_Insert) values('" + eid + "'," + Convert.ToDouble(txtetot.Text.Trim()) + "," + Convert.ToDouble(txtdtot.Text.Trim()) + "," + Convert.ToDouble(txtnetamt.Text.Trim()) + ",'" + cmbMonth.Text.Trim() + "','" + cmbYear.Text.Trim() + "'," + Convert.ToDouble(GetTotalDaysByMonth(cmbMonth.Text.Trim(), GetYear(cmbMonth.Text.Trim(), cmbYear.Text.Trim())) - (totLVWPay + totLVWOPay)) + "," + totLVWPay + "," + totLVWOPay + "," + GetTotalDaysByMonth(cmbMonth.Text.Trim(), GetYear(cmbMonth.Text.Trim(), cmbYear.Text.Trim())) + "," + Convert.ToDouble(txtetot.Text.Trim()) + "," + pfdue + "," + totpf + ",'" + Convert.ToDateTime(dtpidate.Text.Trim()).Date.ToString("MM/dd/yyyy") + "')";
            Command_TR(s);
            //b = clsDataAccess.RunNQwithStatus(s);
            //return b;
        }
        public string cal_Cmp_Lumpsum(int lump_type)
        {
            string res = "",s="";
            s = "select amount from tbl_Employee_Lumpsum where LUMPID=" + lump_type;
            DataTable dttemp = new DataTable();
            dttemp = clsDataAccess.RunQDTbl(s);
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0][0].ToString() != "")
                    res = dttemp.Rows[0][0].ToString();
            }
            return res;
        }
        public string cal_Slab(int slab_type, double erntot)
        {
            string res = "", s = "";
            s = "select amt,maxim from tbl_Employee_Slab_Det where slabid=" + slab_type + " and mini<=" + erntot;

            DataTable dttemp = new DataTable();
            dttemp = clsDataAccess.RunQDTbl(s);
            if (dttemp.Rows.Count > 0)
            {
                for (int j = 0; j < dttemp.Rows.Count; j++)
                {
                    if (dttemp.Rows[j][1].ToString().Trim() != "Max. Value" && Convert.ToInt32(dttemp.Rows[j][1]) >=erntot)
                    {
                        res = dttemp.Rows[j][0].ToString();
                    }
                    else
                        res = dttemp.Rows[j][0].ToString();
                }
            }
            return res;
        }
        public void Get_Total_Leave()
        {
            Int32 Mont = 0;
            Int32 Yr = 0;
            totLVWOPay = 0; totLVWPay = 0; LeaveAmt = 0;
            double totPayforLeave = 0;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            string ReturnVal = "";
            string MontName = "";
            string qry = "", eid = ""; string lx = "", ly = "";
            int flv = -1, slv = -1;
            Get_Leave_Dtl();
            if(emp_id.ContainsKey(cmbempname1111.Text))
                eid=emp_id[cmbempname1111.Text].ToString();

            qry = "select LeaveDate,FstLeave,SndLeave,LeaveType from tbl_Employee_Attendance where id='" + eid + "'";
            DataTable dtl = new DataTable();
            dtl = clsDataAccess.RunQDTbl(qry);
            if (dtl.Rows.Count > 0)
            {
                for (int f = 0; f < dtl.Rows.Count; f++)
                {
                    flv = -1; slv = -1;
                    MontName = Microsoft.VisualBasic.DateAndTime.MonthName(Convert.ToDateTime(dtl.Rows[f][0]).Month, false);



                    Mont = Convert.ToDateTime(dtl.Rows[f][0]).Month;
                    Yr = Convert.ToDateTime(dtl.Rows[f][0]).Year;


                    if (Mont >= 4 && Mont <= 12)
                    {

                        ReturnVal = Yr.ToString() + "-" + Convert.ToString(Yr + 1);
                    }
                    else if (Mont >= 1 && Mont <= 3)
                    {
                        ReturnVal = Convert.ToString(Yr - 1) + "-" + Yr.ToString();

                    }

                    if (ReturnVal == cmbYear.Text.Trim() && MontName == cmbMonth.Text.Trim())
                    {                       
                        //if (dtl.Rows[f][1].ToString() != "" && dtl.Rows[f][2].ToString() != "")
                        //{
                        //    flv = Convert.ToInt32(dtl.Rows[f][1]);
                        //    slv = Convert.ToInt32(dtl.Rows[f][2]);
                        //}
                        if (Convert.ToInt32(dtl.Rows[f][1])>1 && Convert.ToInt32(dtl.Rows[f][3])==0)
                        {
                            totLVWPay += 0.5;
                        }
                        else if (Convert.ToInt32(dtl.Rows[f][1]) > 1 && Convert.ToInt32(dtl.Rows[f][3]) == 1)
                        {
                            totLVWOPay += 0.5;
                        }

                        if (Convert.ToInt32(dtl.Rows[f][2]) > 1 && Convert.ToInt32(dtl.Rows[f][3]) == 0)
                        {
                            totLVWPay += 0.5;
                        }
                        else if (Convert.ToInt32(dtl.Rows[f][2]) > 1 && Convert.ToInt32(dtl.Rows[f][3]) == 1)
                        {
                            totLVWOPay += 0.5;
                        }

                    }
                    
                    //if (hsh_DayCount.ContainsKey(flv.ToString()))
                    //{
                    //    totLVWPay += Convert.ToDouble(hsh_DayCount[flv.ToString()]) * 0.5;

                    //}
                    //if (hsh_DayCount.ContainsKey(slv.ToString()))
                    //{
                    //    totLVWPay += Convert.ToDouble(hsh_DayCount[slv.ToString()]) * 0.5;
                    //}
                    //if (hsh_CFwd_DayCount.ContainsKey(flv.ToString()))
                    //{
                    //    totLVWOPay += Convert.ToDouble(hsh_CFwd_DayCount[flv.ToString()]) * 0.5;
                    //}
                    //if (hsh_CFwd_DayCount.ContainsKey(slv.ToString()))
                    //{
                    //    totLVWOPay += Convert.ToDouble(hsh_CFwd_DayCount[slv.ToString()]) * 0.5;
                    //}
                    //if (hsh_PayLeave.ContainsKey(flv.ToString()))
                    //{
                    //    LeaveAmt += Convert.ToDouble(txtetot.Text.Trim()) / 30 * Convert.ToDouble(hsh_PayLeave[flv.ToString()]) * (Convert.ToDouble(hsh_DayCount[flv.ToString()]) * 0.5);
                    //}
                    //if (hsh_PayLeave.ContainsKey(slv.ToString()))
                    //{
                    //    LeaveAmt += Convert.ToDouble(txtetot.Text.Trim()) / 30 * Convert.ToDouble(hsh_PayLeave[slv.ToString()]) * (Convert.ToDouble(hsh_DayCount[slv.ToString()]) * 0.5);
                    //}

                }
                        if (totLVWOPay > 0)
                        {

                            LeaveAmt += Convert.ToDouble(string.Format("{0:N}", ((Convert.ToDouble(txtetot.Text.Trim()) / 30) * totLVWOPay)));
                            
                        }

            }
            LeaveAmt = Math.Round(LeaveAmt);
            txtalwp.Text = string.Format("{0:F}",LeaveAmt);
            if (totLVWOPay.ToString().Contains("."))
            {
                lx = totLVWOPay.ToString().Substring(0, totLVWOPay.ToString().LastIndexOf('.'));
                ly = totLVWOPay.ToString().Substring(totLVWOPay.ToString().LastIndexOf('.'));
                if (ly.Trim() == ".5" && lx.Trim() != "0")
                    txttlwp.Text = lx + "½" + "  Day";
                else if (ly.Trim() == ".5" && lx.Trim() == "0")
                    txttlwp.Text = "½" + "  Day";
            }
            else
            {
                if (totLVWOPay > 1)
                    txttlwp.Text = totLVWOPay.ToString() + "  Days";
                else
                    txttlwp.Text = totLVWOPay.ToString() + "  Day";
            }
            txtnetamt.Text = string.Format("{0:F}", (Convert.ToDouble(txtetot.Text.Trim()) - (Convert.ToDouble(txtdtot.Text.Trim()) + LeaveAmt)));

        }
        public void Get_Leave_Dtl()
        {
            hsh_CFwd_DayCount.Clear();
            hsh_DayCount.Clear();
            hsh_PayLeave.Clear();
            string qry = "";
            qry = "select LeaveId,TotalLeaves,DayCount,PayType,LeaveFwd from tbl_Employee_Config_LeaveDetails where session='" + cmbYear.Text.Trim() + "'";
            DataTable dtle = new DataTable();
            dtle = clsDataAccess.RunQDTbl(qry);
            if (dtle.Rows.Count > 0)
            {
                for(int l=0;l<dtle.Rows.Count;l++)
                {
                    //if (dtle.Rows[l][4].ToString() == "Payment" || dtle.Rows[l][4].ToString()=="Both")
                    //{
                        if (Convert.ToInt32(dtle.Rows[l][2]) != 0)
                        {
                            if (!hsh_DayCount.ContainsKey(dtle.Rows[l][0].ToString()))
                                hsh_DayCount.Add(dtle.Rows[l][0].ToString(), Convert.ToString(Convert.ToDouble(dtle.Rows[l][2]) / Convert.ToDouble(dtle.Rows[l][1])));
                        }
                        if (!hsh_PayLeave.ContainsKey(dtle.Rows[l][0].ToString()))
                        {
                            if (dtle.Rows[l][3].ToString().Trim() == "Half Pay")
                                hsh_PayLeave.Add(dtle.Rows[l][0].ToString(), "0.5");
                            if (dtle.Rows[l][3].ToString().Trim() == "Full Pay")
                                hsh_PayLeave.Add(dtle.Rows[l][0].ToString(), "1");
                        }
                    //}
                    //else if (dtle.Rows[l][4].ToString() == "Carry-Forward")
                    //{
                        if (Convert.ToInt32(dtle.Rows[l][2]) != 0)
                        {
                            if (!hsh_CFwd_DayCount.ContainsKey(dtle.Rows[l][0].ToString()))
                            {
                                hsh_CFwd_DayCount.Add(dtle.Rows[l][0].ToString(), Convert.ToString(Convert.ToDouble(dtle.Rows[l][2]) / Convert.ToDouble(dtle.Rows[l][1])));
                            }
                        }
                    //}
                }
            }
        }

        private void chkpfvol_Click(object sender, EventArgs e)
        {
            double temppfvol = 0;
            if (chkpfvol.Checked)
                txtpfvol.Enabled = true;
            else
            {
                txtpfvol.Text = temppfvol.ToString();
                txtpfvol.Enabled = false;
            }
                
        }

        private void txtnetamt_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    sal_total();
            //}
            //catch (Exception ex) { }
        }

        private void txtpfvol_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtpfvol.Text.IndexOf("%") > 0)
                {
                    string TempVal = txtpfvol.Text;
                    TempVal = TempVal.Substring(0, TempVal.IndexOf("%"));

                    txtpfvol.Text = Convert.ToString((Convert.ToDouble(txtetot.Text.Trim()) * Convert.ToDouble(TempVal)) / 100);
                }

                sal_total();
                Get_Total_Leave();
                
            }
            catch (Exception x) { }
            
        }

     

        //private void cmbempid_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string s="";
        //        cmbempid.Items.Clear();
        //        if (cmbsalstruc.Text.Trim() == "")
        //            s = "select id from tbl_Employee_Mast";
        //        else
        //            s = "select id from tbl_Employee_Mast where salid=" + get_SalStructID(cmbsalstruc.Text.Trim());
        //        Load_Data1(s, cmbempid,-1);
        //        clear_txt();

        //    }
        //    catch (Exception ex) { }
        //}

        //private void cmbempid_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cmbempid.Text.Trim() != "")
        //        {
        //            cmbempname.Items.Clear();

        //            string s = "select title,firstname,middlename,lastname,id from tbl_Employee_Mast where id='" + cmbempid.Text.Trim() + "'";
        //            Load_Data(s, cmbempname, 0);
        //            clear_txt();
        //            cmbempname_DropDownClosed(sender, e);
        //        }
        //    }
        //    catch (Exception ex) { }
        //}

        private void cmbempname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbempname1111.Text.Trim() != "")
                {
                    string s1 = "select id from tbl_Employee_Mast where code=" + Convert.ToInt32(hsh_emp_code[cmbempname1111.Text.Trim()]);
                    DataTable temp = new DataTable();
                    temp = clsDataAccess.RunQDTbl(s1);
                    if (temp.Rows.Count > 0)
                    {
                        lblempid.Text = temp.Rows[0][0].ToString();
                    }
                }
                else
                    lblempid.Text = string.Empty;
            }
            catch (Exception ex) { }
        }
        public void pfloan_cal()
        {
            string s = "",eid="",s1="";
            double pflirate = 0;
            PFSno = 0;
            if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
                eid = emp_id[cmbempname1111.Text.Trim()].ToString();

            s = "select LoanAmount,NoOfInstallment,InterestRate,LoanRepaid,SerialNo from tbl_Employee_PF_Loan where empcode='" + eid + "' and PFSession='" + cmbYear.Text.Trim() + "' and LoanType=1";
            DataTable dtloan = new DataTable();
            DataTable dtloan1 = new DataTable();
            dtloan = clsDataAccess.RunQDTbl(s);
            if (dtloan.Rows.Count > 0)
            {
                for (int pfl = 0; pfl < dtloan.Rows.Count; pfl++)
                {
                    if (Convert.ToDouble(dtloan.Rows[pfl][0]) > Convert.ToDouble(dtloan.Rows[pfl][3]))
                    {
                        TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                        tx = txtp[1];
                        tx.Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(dtloan.Rows[0][0]) / Convert.ToDouble(dtloan.Rows[pfl][1]))));

                        txtp[1] = tx;

                        this.grpded.Controls.Add(txtp[1]);
                        //s1 = "select amount from tbl_Employee_SalaryDet where EmpId='" + eid + "' and Session='" + cmbYear.Text.Trim() + "' and TableName='tbl_Employee_Config_PFHeads' and SalId=2";
                        //dtloan1 = clsDataAccess.RunQDTbl(s1);
                        //if (dtloan1.Rows.Count > 0)
                        //{
                        //    for (int x = 0; x < dtloan1.Rows.Count; x++)
                        //    {
                        //        pflirate += Convert.ToDouble(dtloan1.Rows[x][0]);
                        //    }

                        //}
                        pflirate = Convert.ToDouble(((Convert.ToDouble(dtloan.Rows[pfl][0]) - Convert.ToDouble(dtloan.Rows[pfl][3])) * (Convert.ToDouble(dtloan.Rows[pfl][2]) / 100)) / 12);

                        tx = txtp[2];
                        tx.Text = string.Format("{0:F}", pflirate);

                        txtp[2] = tx;

                        this.grpded.Controls.Add(txtp[2]);
                        PFSno = Convert.ToInt32(dtloan.Rows[pfl][4]);
                    }
                }
            }

        }
        public void Loan_Repaid()
        {
            double lrepaid = 0;
            string eid = ""; 

            if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
                eid = emp_id[cmbempname1111.Text.Trim()].ToString();

            DataTable dtloan1 = new DataTable();
           string s1 = "select amount from tbl_Employee_SalaryDet where EmpId='" + eid + "' and Session='" + cmbYear.Text.Trim() + "' and TableName='tbl_Employee_Config_PFHeads' and SalId=2";
            dtloan1 = clsDataAccess.RunQDTbl(s1);
            if (dtloan1.Rows.Count > 0)
            {
                for (int x = 0; x < dtloan1.Rows.Count; x++)
                {
                    lrepaid += Convert.ToDouble(dtloan1.Rows[x][0]);
                }

                string qry = "update tbl_Employee_PF_Loan set LoanRepaid=" + lrepaid + " where SerialNo=" + PFSno;
                Command_TR(qry);
            }

        }

        private void btngene_Click(object sender, EventArgs e)
        {

        }

        private void txtebasic_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cmbMonth.Text = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
        }

        private void cmborderno_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select Title +' '+ FirstName +' '+ MiddleName +' '+ LastName as EmployName,ID from tbl_Employee_Mast");
            if (dt.Rows.Count > 0)
            {
                cmbempname.LookUpTable = dt;
                cmbempname.ReturnIndex = 1;
            } 
        }

        private void cmborderno_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {         

            try
            {
                emply_id = cmbempname.ReturnValue;

                hsh_rtype.Clear();

                if (cmbMonth.Text != "" && cmbempname.Text != "" && cmbsalstruc.Text != "")
                {
                    string eid = "";
                    get_data();
                    get_data1();
                    Get_mnth_detl();
                    if (emp_id.ContainsKey(cmbempname.Text.Trim()))
                        eid = emp_id[cmbempname.Text.Trim()].ToString();
                    if (hsh_All_Mnth.ContainsKey(cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()))
                        view_sal(hsh_All_Mnth[cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()].ToString(), "Y");
                    else
                    {
                        if (hsh_lst_mnth.ContainsKey(cmbYear.Text.Trim() + "/" + eid.ToString()))
                            view_sal(hsh_lst_mnth[cmbYear.Text.Trim() + "/" + eid.ToString()].ToString(), "N");
                    }
                }
            }
            catch (Exception x) { }
        }

        private void txte4_TextChanged(object sender, EventArgs e)
        {

        }
          

       
    }
}  