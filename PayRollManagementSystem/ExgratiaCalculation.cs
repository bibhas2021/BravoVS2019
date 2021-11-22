using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class ExgratiaCalculation : EDPComponent.FormBaseERP 
    {
        public ExgratiaCalculation()
        {
            InitializeComponent();
        }

        #region Function

        private Boolean Validation()
        {
            Boolean boolStatus = false;

            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Select Session")) 
            {
                if (clsValidation.ValidateEdpCombo(cmbExgratiaName, "", "Please Select Exgratia Name")) 
                {
                    boolStatus = true;
                }
            }

            return boolStatus;
        }

        private void GetAllExgratia()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select ExGratia_Name,Session,ExGratia_Id from tbl_Employee_Config_Exgratia where Session=" + cmbYear.Text.Trim() + "");
            cmbExgratiaName.LookUpTable = dt;
            cmbExgratiaName.ReturnIndex = 2;
        }

        private void GetAllEmp(Int32 intSession)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select ID,FirstName+' '+MiddleName+' '+LastName Name,0.00 Salary,0.00 ActualExg,0.00 Given from tbl_Employee_Mast where Session='" + intSession + "-" + (intSession + 1) + "'");
            dgExgratia.DataSource = dt;
        }

        private String GetMonthsForEmpSal(Int32 intSession)
        {
            String strMonth = String.Empty;
            String  strQuote = "'";            

            DataTable dt = clsDataAccess.RunQDTbl("select Month from tbl_Employee_Config_Exgratia where session=" + intSession + "");
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Month"])))
                {                    
                    String[] strArrMonth;
                    if (Convert.ToString(dt.Rows[0]["Month"]).Contains("|"))
                    {
                        strArrMonth = Convert.ToString(dt.Rows[0]["Month"]).Split('|');

                        for (Int32 i = 0; i < strArrMonth.Length; i++)
                        {
                            strMonth += "Month=" + Convert.ToString(strQuote) + clsEmployee.GetMonthName(Convert.ToInt32(strArrMonth[i])) + Convert.ToString(strQuote) + " or ";
                        }
                        strMonth = strMonth.Substring(0, strMonth.LastIndexOf('o'));
                    }
                    else
                    {
                        strMonth = "Month=" + Convert.ToString(strQuote) + clsEmployee.GetMonthName(Convert.ToInt32(dt.Rows[0]["Month"])) + Convert.ToString(strQuote);
                    }
                }
            }
            return strMonth;
        }

        private Decimal GetEmpSalary(String strEmpId)
        {
            Decimal decSalary = 0.00m;

            DataTable dt = clsDataAccess.RunQDTbl("select max(TotalSal) TotalSal from tbl_Employee_SalaryMast where Emp_Id='" + strEmpId + "' and (" + GetMonthsForEmpSal(Convert.ToInt32(cmbYear.Text.Trim())) + ")");
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["TotalSal"])))
                {
                    decSalary = Convert.ToDecimal(dt.Rows[0]["TotalSal"]);
                }
            }

            return decSalary;
        }

        private Decimal GetActualExgratia(String strEmpId)
        {
            Decimal decAmt = 0.00m;
            DataTable dt = clsDataAccess.RunQDTbl("select Mode,Amount from tbl_Employee_Config_Exgratia where ExGratia_Id="+cmbExgratiaName.ReturnValue+"");
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Mode"])))
                {
                    if (Convert.ToString(dt.Rows[0]["Mode"]).ToLower() == "percentage")
                    {
                        if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Amount"])))
                        {
                            decAmt = (Decimal)(GetEmpSalary(strEmpId) * (Convert.ToDecimal(dt.Rows[0]["Amount"]) / 100));
                        }
                    }
                    else if (Convert.ToString(dt.Rows[0]["Mode"]).ToLower() == "amount")
                    {
                        if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Amount"])))
                        {
                            decAmt = Convert.ToDecimal(dt.Rows[0]["Amount"]);
                        }
                    }
                }
            }
            return decAmt;
        }

        private Int32 CheckExgGiven(String strEmpId, Int32 intExgId)
        {
            Int32 intSlNo = 0;

            DataTable dt = clsDataAccess.RunQDTbl("select SlNo from tbl_Employee_ExgratiaGiven where EmpId='" + strEmpId + "' and ExgratiaId=" + intExgId + "");
            if (dt.Rows.Count > 0)
            {
                intSlNo = Convert.ToInt32(dt.Rows[0]["SlNo"]);
            }

            return intSlNo;
        }

        private Decimal ExgratiaGiven(String strEmpId, Int32 intExgId)
        {
            Decimal decExgGiven = 0.00m;

            DataTable dt = clsDataAccess.RunQDTbl("select ExgAmount from tbl_Employee_ExgratiaGiven where EmpId='" +strEmpId + "' and ExgratiaId=" +intExgId+ "");
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ExgAmount"])))
                {
                    decExgGiven = Convert.ToDecimal(dt.Rows[0]["ExgAmount"]);
                }
            }

            return decExgGiven;
        }

        private Decimal CalculateDifference(Int32 intRowIndex)
        {
            Decimal decActualExg = 0.00m;
            Decimal decExgGiven = 0.00m;
            Decimal decDiff = 0.00m;


            if (!String.IsNullOrEmpty(Convert.ToString(dgExgratia.Rows[intRowIndex].Cells["Actual_Exg"].Value)))
            {
                decActualExg = Convert.ToDecimal(dgExgratia.Rows[intRowIndex].Cells["Actual_Exg"].Value);
            }
            if (!String.IsNullOrEmpty(Convert.ToString(dgExgratia.Rows[intRowIndex].Cells["ExgGiven"].Value)))
            {
                decExgGiven = Convert.ToDecimal(dgExgratia.Rows[intRowIndex].Cells["ExgGiven"].Value);
            }

            if (Convert.ToDecimal(dgExgratia.Rows[intRowIndex].Cells["ExgGiven"].Value) > GetMaxExgratia(Convert.ToInt32(cmbExgratiaName.ReturnValue)))
            {
                ERPMessageBox.ERPMessage.Show("Ex-Gratia Given Cannot Be Greater Than Maximum Ex-Gratia (Rs.) " + GetMaxExgratia(Convert.ToInt32(cmbExgratiaName.ReturnValue)));
                dgExgratia.Rows[intRowIndex].Cells["ExgGiven"].Value = 0.00m;
            }
            else if (decActualExg < decExgGiven)
            {
                ERPMessageBox.ERPMessage.Show("Ex-Gratia Given Cannot Be Greater Than Actual Ex-Gratia");
                dgExgratia.Rows[intRowIndex].Cells["ExgGiven"].Value = 0.00m;
            }

            if (decActualExg >= decExgGiven)
            {
                decDiff = (Decimal)(decActualExg - decExgGiven);
            }

            return decDiff;
        }

        private void GetDetails()
        {
            GetAllEmp(Convert.ToInt32(cmbYear.Text.Trim()));
            if (dgExgratia.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dgExgratia.Rows.Count; i++)
                {
                    String strEmpId = Convert.ToString(dgExgratia.Rows[i].Cells["Id"].Value);

                    if (!String.IsNullOrEmpty(strEmpId))
                    {
                        dgExgratia.Rows[i].Cells["Salary"].Value = GetEmpSalary(strEmpId);
                        dgExgratia.Rows[i].Cells["Actual_Exg"].Value = GetActualExgratia(strEmpId).ToString("0.00");

                        if (CheckExgGiven(strEmpId, Convert.ToInt32(cmbExgratiaName.ReturnValue)) > 0)
                        {
                            dgExgratia.Rows[i].Cells["ExgGiven"].Value = ExgratiaGiven(strEmpId, Convert.ToInt32(cmbExgratiaName.ReturnValue));
                            dgExgratia.Rows[i].Cells["Diff"].Value = CalculateDifference(i);
                            dgExgratia.Rows[i].Cells["SlNo"].Value = CheckExgGiven(strEmpId, Convert.ToInt32(cmbExgratiaName.ReturnValue));
                        }
                        else
                        {
                            dgExgratia.Rows[i].Cells["Diff"].Value = dgExgratia.Rows[i].Cells["ExgGiven"].Value;
                        }
                    }
                }
            }
        }

        private Decimal GetMaxExgratia(Int32 intExgratiaId)
        {
            Decimal decMaxExg = 0.00m;

            DataTable dt = clsDataAccess.RunQDTbl("select MaxPay from tbl_Employee_Config_Exgratia where ExGratia_Id=" + intExgratiaId + "");
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["MaxPay"])))
                {
                    decMaxExg = Convert.ToDecimal(dt.Rows[0]["MaxPay"]);
                }
            }

            return decMaxExg;
        }

        private Int32 GetPayMonth(Int32 intExgratiaId)
        {
            Int32 intExgId = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select PayMonth from tbl_Employee_Config_Exgratia where ExGratia_Id=" + intExgratiaId + "");
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PayMonth"])))
                {
                    intExgId = Convert.ToInt32(dt.Rows[0]["PayMonth"]);
                }
            }
            return intExgId;
        }

        private Decimal GetSpecialAmt(String strEmpId, String strSession, String strMonth)
        {
            Decimal decSpecialAmt = 0.00m;

            DataTable dt = clsDataAccess.RunQDTbl("select Special from tbl_Employee_SalaryMast where Emp_Id='" + strEmpId + "' and Session='" + strSession + "' and Month='" + strMonth + "'");
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Special"])))
                {
                    decSpecialAmt = Convert.ToDecimal(dt.Rows[0]["Special"]);
                }
            }

            return decSpecialAmt;
        }

        private Boolean InsertIntoEmpMast(String strEmpId, Decimal decExgAmount,Int32 intExgId,Int32 intYear)
        {
            Boolean boolExg = false;
            Decimal dcSpecial=(GetSpecialAmt(strEmpId, Convert.ToString((intYear) + "-" + (intYear + 1)), clsEmployee.GetMonthName(GetPayMonth(Convert.ToInt32(cmbExgratiaName.ReturnValue)))) + decExgAmount);
            DataTable dtSalMast = clsDataAccess.RunQDTbl("select TotalSal,NetPay,GrossAmount from tbl_Employee_SalaryMast where Emp_Id='" + strEmpId + "' and Session='" + (intYear) + "-" + (intYear + 1) + "' and Month='" + clsEmployee.GetMonthName(GetPayMonth(Convert.ToInt32(cmbExgratiaName.ReturnValue))) + "'");
            Boolean boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_SalaryMast set Special=" + dcSpecial + ",TotalSal='" + (Convert.ToDecimal(dtSalMast.Rows[0]["TotalSal"].ToString()) + dcSpecial) + "',NetPay='" + (Convert.ToDecimal(dtSalMast.Rows[0]["NetPay"].ToString()) + dcSpecial) + "',GrossAmount='" + (Convert.ToDecimal(dtSalMast.Rows[0]["GrossAmount"].ToString()) + dcSpecial) + "' where Emp_Id='" + strEmpId + "' and Session='" + (intYear) + "-" + (intYear + 1) + "' and Month='" + clsEmployee.GetMonthName(GetPayMonth(Convert.ToInt32(cmbExgratiaName.ReturnValue))) + "'");
            if (boolStatus)
            {
                boolExg = clsDataAccess.RunNQwithStatus("update tbl_Employee_ExgratiaGiven set Given=1 where EmpId='" + strEmpId + "' and ExgratiaId=" + intExgId + "");
            }
            return boolExg;
        }

        private String[] ExgratiaModeAmount(Int32 intExgId)
        {
            String[] strArr = new String[3];
            DataTable dt = clsDataAccess.RunQDTbl("select Mode,Amount,Month from tbl_Employee_Config_Exgratia where ExGratia_Id=" + intExgId + "");
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Month"])))
                {
                    strArr[2] = Convert.ToString(dt.Rows[0]["Month"]);
                    if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Mode"])))
                    {
                        strArr[0] = Convert.ToString(dt.Rows[0]["Mode"]);
                        if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Amount"])))
                        {
                            strArr[1] = Convert.ToString(dt.Rows[0]["Amount"]);
                        }
                        else
                        {
                            strArr[1] = "0.00";
                        }
                    }
                }
            }
            return strArr;
        }

        private Decimal CalculateExgratiaAmount(Decimal decExgAmtPerMonth,String strEmpId,Int32 intExgId,Int32 intYear)
        {
            Decimal decTotalAmt = 0.00m;
            String[] strArr;
            String strMonth = ExgratiaModeAmount(Convert.ToInt32(cmbExgratiaName.ReturnValue))[2];


            if (!String.IsNullOrEmpty(strMonth))
            {
                if (strMonth.Contains("|"))
                {
                    strArr = strMonth.Split('|');
                }
                else
                {
                    strArr = new String[1];
                    strArr[0] = strMonth;
                }
                if (ExgratiaModeAmount(Convert.ToInt32(cmbExgratiaName.ReturnValue))[0].ToLower() == "percentage")
                {
                    for (Int32 i = 0; i < strArr.Length; i++)
                    {
                        DataTable dtEmpSal = clsDataAccess.RunQDTbl("select TotalSal from tbl_Employee_SalaryMast where Emp_Id='" + strEmpId + "' and Month='" + clsEmployee.GetMonthName(Convert.ToInt32(strArr[i])) + "' and Session='" + intYear + "-" + (intYear + 1) + "'");
                        if (dtEmpSal.Rows.Count > 0)
                        {
                            if (!String.IsNullOrEmpty(Convert.ToString( dtEmpSal.Rows[0]["TotalSal"])))
                            {
                                decTotalAmt += (Decimal)Convert.ToDecimal(dtEmpSal.Rows[0]["TotalSal"]) * (Convert.ToDecimal(ExgratiaModeAmount(Convert.ToInt32(cmbExgratiaName.ReturnValue))[1]) / 100);
                            }
                        }
                    }                   
                }
                else if (ExgratiaModeAmount(Convert.ToInt32(cmbExgratiaName.ReturnValue))[0].ToLower() == "amount")
                {
                    for(Int32 i = 0; i < strArr.Length; i++)
                    {
                        decTotalAmt += (Decimal)decExgAmtPerMonth;
                    }
                }
            }

            return decTotalAmt;
        }

        #endregion

        private void ExgratiaCalculation_Load(object sender, EventArgs e)
        {
            //generate year
            clsEmployee.GenerateYear(cmbYear);
            //
        }

        private void cmbExgratiaName_DropDown(object sender, EventArgs e)
        {
            GetAllExgratia();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                GetDetails();
            }
        }
        
        private void dgExgratia_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgExgratia.Rows[e.RowIndex].Cells["Diff"].Value = CalculateDifference(e.RowIndex).ToString("0.00");
            }
            catch (Exception ex)
            {
               // ERPMessageBox.ERPMessage.Show("Ex-Gratia Given Should be Numeric");
            }
        }

        private void dgExgratia_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                decimal decGiven = Convert.ToDecimal(dgExgratia.Rows[e.RowIndex].Cells["ExgGiven"]);
            }
            catch (Exception ex)
            {
                ERPMessageBox.ERPMessage.Show("Ex-Gratia Given Should be Numeric");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgExgratia.Rows.Count > 0)
            {
                Boolean boolSatus = false;
                Boolean boolSalStatus = false;
                Int32 intCounter = 0;
                for (Int32 i = 0; i < dgExgratia.Rows.Count; i++)
                {
                    if (String.IsNullOrEmpty(Convert.ToString(dgExgratia.Rows[i].Cells["SlNo"].Value)))
                    {
                        boolSatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_ExgratiaGiven (EmpId,ExgratiaId,ExgAmount) values('" + dgExgratia.Rows[i].Cells["Id"].Value + "'," + cmbExgratiaName.ReturnValue + "," + dgExgratia.Rows[i].Cells["ExgGiven"].Value + ")");                          
                    }
                    else
                    {
                        boolSatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_ExgratiaGiven set ExgAmount='" + dgExgratia.Rows[i].Cells["ExgGiven"].Value + "' where SlNo='" + dgExgratia.Rows[i].Cells["SlNo"].Value + "'");
                    }
                    if (boolSatus)
                    {
                        boolSalStatus = InsertIntoEmpMast(Convert.ToString(dgExgratia.Rows[i].Cells["Id"].Value), CalculateExgratiaAmount(Convert.ToDecimal(dgExgratia.Rows[i].Cells["ExgGiven"].Value), Convert.ToString(dgExgratia.Rows[i].Cells["Id"].Value),Convert.ToInt32(cmbExgratiaName.ReturnValue),Convert.ToInt32(cmbYear.Text.Trim())), Convert.ToInt32(cmbExgratiaName.ReturnValue),Convert.ToInt32(cmbYear.Text.Trim()));
                        if (boolSalStatus)
                        {
                            intCounter += 1;
                        }
                    }
                }
                if (intCounter == dgExgratia.Rows.Count)
                {
                    ERPMessageBox.ERPMessage.Show("Ex-Gratia Calculation Submitted Successfully");
                    //dgExgratia.Rows.Clear();
                }
            }
        }

        
    }
}