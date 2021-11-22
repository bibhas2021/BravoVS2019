using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System.Collections;


namespace PayRollManagementSystem
{
    public partial class Report_LeaveEnCashment :EDPComponent.FormBaseERP 
    {
        public Report_LeaveEnCashment()
        {
            InitializeComponent();
        }

        private DataTable GetLeaveHeads(String strSession)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT LeaveId,ShortName,Amount,TotalLeaves from tbl_Employee_Config_LeaveDetails where Session='" + strSession + "'");

            return dt;
        }

        private Boolean CheckForExDetRecord(String strEmpId, String strSession, Int32 intLeaveId)
        {
            Boolean boolStatus = false;
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_LeaveEncashment_Det where EmpId='" + strEmpId + "' and Session='" + strSession + "' and SlNo=" + intLeaveId + "");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }
            return boolStatus;
        }
        private Boolean CheckForExMastRecord(String strEmpId, String strSession)
        {
            Boolean boolStatus = false;
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_LeaveEncashment_Mast where EmpId='" + strEmpId + "' and Session='" + strSession + "'");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }
            return boolStatus;
        }

        private DataTable  GetHeader()
        { 
            DataTable dtLeaveEncash = new DataTable();
            String strBalLeave = "Bal ( ";
            dtLeaveEncash.Columns.Add("ID");

            dtLeaveEncash.Columns.Add("Name");
            dtLeaveEncash.Columns.Add("Desg");
            DataTable dt = GetLeaveHeads(cmbYear.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    if (strBalLeave != "(")
                    {
                        strBalLeave += " + ";
                    }
                    dtLeaveEncash.Columns.Add("Total " + Convert.ToString(dt.Rows[i]["ShortName"]));
                    strBalLeave += Convert.ToString(dt.Rows[i]["ShortName"]);
                }
                strBalLeave += " )";

                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    dtLeaveEncash.Columns.Add(Convert.ToString(dt.Rows[i]["ShortName"]) + " Taken");
                }
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    dtLeaveEncash.Columns.Add("Bal " + Convert.ToString(dt.Rows[i]["ShortName"]));
                }


                
            }
            dtLeaveEncash.Columns.Add("Bal Leave");
            dtLeaveEncash.Columns.Add("Half Leave");
            dtLeaveEncash.Columns.Add("Total Sal");
            dtLeaveEncash.Columns.Add("Gross Amt");
            dtLeaveEncash.Columns.Add("Adv AG Sal");
            dtLeaveEncash.Columns.Add("Rev Stamp");
            dtLeaveEncash.Columns.Add("Total Deduc");
            dtLeaveEncash.Columns.Add("Total Pay");
            return dtLeaveEncash;

        }

        private DataTable GetEmployeeDetails()
        {
            DataTable dtLeaveEncash = GetHeader();
            Int32 intSalHead = 0;
            //dtLeaveEncash.Columns["Basic"]Type = System.Type.GetType("Decimal");
            DataTable dtEmp = clsDataAccess.RunQDTbl("select emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName Name,desg.DesignationName from tbl_Employee_Mast emp,tbl_Employee_DesignationMaster desg where emp.DesgId=desg.SlNo");
            if (dtEmp.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dtEmp.Rows.Count; i++)
                {
                    dtLeaveEncash.Rows.Add();

                    dtLeaveEncash.Rows[i]["Name"] = dtEmp.Rows[i]["Name"];
                    dtLeaveEncash.Rows[i]["Desg"] = dtEmp.Rows[i]["DesignationName"];

                    DataTable dtLeave = GetLeaveHeads(cmbYear.Text.Trim());
                    if (dtLeave.Rows.Count > 0)
                    {
                        for (Int32 j = 0; j < dtLeave.Rows.Count; j++)
                        {
                            //if (!String.IsNullOrEmpty(Convert.ToString(dtLeave.Rows[j]["ID"])))
                            //{
                            //intSalHead += 1;
                            if (CheckForExDetRecord(Convert.ToString(dtEmp.Rows[i]["ID"]), cmbYear.Text.Trim(), Convert.ToInt32(dtLeave.Rows[j]["LeaveId"])))
                            {
                                DataTable dtEx = clsDataAccess.RunQDTbl("select * from tbl_Employee_LeaveEncashment_Det where EmpId='" + Convert.ToString(dtEmp.Rows[i]["ID"]) + "' and Session='" + cmbYear.Text.Trim() + "' and LeaveId=" + Convert.ToString(dtLeave.Rows[j]["LeaveId"]) + "");
                                if (dtEx.Rows.Count > 0)
                                {
                                    dtLeaveEncash.Rows[i]["Total " + Convert.ToString(dtLeave.Rows[j]["ShortName"])] = dtEx.Rows[0]["TotalLeaves"];
                                    dtLeaveEncash.Rows[i][Convert.ToString(dtLeave.Rows[j]["ShortName"]) + " Taken"] = dtEx.Rows[0]["LeaveTaken"];
                                    dtLeaveEncash.Rows[i]["Bal " + Convert.ToString(dtLeave.Rows[j]["ShortName"])] = dtEx.Rows[0]["BalanceLeave"];
                                }
                                else
                                {
                                    dtLeaveEncash.Rows[i]["Total " + Convert.ToString(dtLeave.Rows[j]["ShortName"])] = 0;
                                    dtLeaveEncash.Rows[i][Convert.ToString(dtLeave.Rows[j]["ShortName"]) + " Taken"] = 0;
                                    dtLeaveEncash.Rows[i]["Bal " + Convert.ToString(dtLeave.Rows[j]["ShortName"])] = 0;
                                }
                            }
                            //}
                        }
                    }

                    if (CheckForExMastRecord(Convert.ToString(dtEmp.Rows[i]["ID"]), cmbYear.Text.Trim()))
                    {
                        DataTable dtMast = clsDataAccess.RunQDTbl("select * from tbl_Employee_LeaveEncashment_Mast where EmpId='" + Convert.ToString(dtEmp.Rows[i]["ID"]) + "' and Session='" + cmbYear.Text.Trim() + "'");
                        if (dtMast.Rows.Count > 0)
                        {
                            dtLeaveEncash.Rows[i]["Bal Leave"] = dtMast.Rows[0]["BalLeave"];//"";//Convert.ToInt32(dtLeaveEncash.Rows[i]["BalanceLeave"]) + Convert.ToInt32(dtLeaveEncash.Rows[i]["BalanceLeave"]) + Convert.ToInt32(dtLeaveEncash.Rows[i]["BalanceLeave"]);
                            dtLeaveEncash.Rows[i]["Half Leave"] = dtMast.Rows[0]["HalfLeave"];//"";
                            dtLeaveEncash.Rows[i]["Total Sal"] = dtMast.Rows[0]["GrossAmount"];
                            dtLeaveEncash.Rows[i]["Gross Amt"] = dtMast.Rows[0]["GrossAmount"];
                            dtLeaveEncash.Rows[i]["Adv AG Sal"] = dtMast.Rows[0]["AdvAGSal"];
                            dtLeaveEncash.Rows[i]["Rev Stamp"] = dtMast.Rows[0]["RevStamp"];
                            dtLeaveEncash.Rows[i]["Total Deduc"] = dtMast.Rows[0]["TotalDeduction"];
                            dtLeaveEncash.Rows[i]["Total Pay"] = dtMast.Rows[0]["NetPay"];
                        }
                        else
                        {
                            dtLeaveEncash.Rows[i]["Bal Leave"] = 0;
                            dtLeaveEncash.Rows[i]["Half Leave"] = 0;
                            dtLeaveEncash.Rows[i]["Total Sal"] = 0.00;
                            dtLeaveEncash.Rows[i]["Gross Amt"] = 0.00;
                            dtLeaveEncash.Rows[i]["Adv AG Sal"] = 0.00;
                            dtLeaveEncash.Rows[i]["Rev Stamp"] = 0.00;
                            dtLeaveEncash.Rows[i]["Total Deduc"] = 0.00;
                            dtLeaveEncash.Rows[i]["Total Pay"] = 0.00;
                        }
                    }
                    dtLeaveEncash.Rows[i]["ID"] = dtEmp.Rows[i]["ID"];
                }
            }

            return dtLeaveEncash;
        }

        private Int32 SetTakenLeaves(String strSession, String strEmpId, Int32 intLeaveId)
        {
            String[] strarrYear = strSession.Split('-');

            DateTime dtmFrom = new DateTime(Convert.ToInt32(strarrYear[0]), 4, 1);
            DateTime dtmTo = new DateTime(Convert.ToInt32(strarrYear[1]), 3, 31);

            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_LeaveDetails cld,tbl_Employee_Attendance ea where cld.LeaveId=ea.LeaveTaken and ea.ID='" + strEmpId + "' and ea.Date>='" + new Edpcom.EDPCommon().getSqlDateStr(dtmFrom) + "' and ea.Date<='" + new Edpcom.EDPCommon().getSqlDateStr(dtmTo) + "' and ea.LeaveTaken=" + intLeaveId + "");

            return dt.Rows.Count;
        }

        private Int32 SetBalanceLeave(Int32 intTotalLeaves, Int32 intLeaveTaken)
        {
            Int32 intBalLeave = 0;
            if (intTotalLeaves >= intLeaveTaken)
            {
                intBalLeave = (intTotalLeaves - intLeaveTaken);
            }
            return intBalLeave;
        }

        private Decimal SetTotalSalary(String strEmpId, String strSession)
        {
            Decimal decTotalSal = 0.00m;

            DataTable dt = clsDataAccess.RunQDTbl("select top 1 * from tbl_Employee_SalaryMast where Emp_Id='" + strEmpId + "' and Session='" + strSession + "' order by InsertionDate desc");
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["TotalSal"])))
                {
                    decTotalSal = Convert.ToDecimal(dt.Rows[0]["TotalSal"]);
                }
            }

            return decTotalSal;
        }

        private Decimal SetGrossAmount(Decimal decTotalSalary, Int32 intHalfLeave)
        {
            Decimal decGrossAmount = 0.00m;

            if (decTotalSalary > 0)
            {
                decGrossAmount = (Decimal)((decTotalSalary / 30) * intHalfLeave);
            }


            return decGrossAmount;
        }


        private DataTable  SetTotalLeaves()
        {
            DataTable dtLeaveCash = GetEmployeeDetails();
            if (dtLeaveCash.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dtLeaveCash.Rows.Count; i++)
                {
                    Int32 intTotalBalLeave = 0;
                    DataTable dtLeaveDet = GetLeaveHeads(cmbYear.Text.Trim());
                    if (dtLeaveDet.Rows.Count > 0)
                    {
                        for (Int32 j = 0; j < dtLeaveDet.Rows.Count; j++)
                        {
                            dtLeaveCash.Rows[i]["Total " + Convert.ToString(dtLeaveDet.Rows[j]["ShortName"])] = dtLeaveDet.Rows[j]["TotalLeaves"];
                            dtLeaveCash.Rows[i][Convert.ToString(dtLeaveDet.Rows[j]["ShortName"]) + " Taken"] = SetTakenLeaves(cmbYear.Text.Trim(), Convert.ToString(dtLeaveCash.Rows[i]["ID"]), Convert.ToInt32(dtLeaveDet.Rows[j]["LeaveId"]));
                            if (!String.IsNullOrEmpty(Convert.ToString(dtLeaveCash.Rows[i]["Total " + Convert.ToString(dtLeaveDet.Rows[j]["ShortName"])])) && !String.IsNullOrEmpty(Convert.ToString(dtLeaveCash.Rows[i][Convert.ToString(dtLeaveDet.Rows[j]["ShortName"]) + " Taken"])))
                            {
                                dtLeaveCash.Rows[i]["Bal " + Convert.ToString(dtLeaveDet.Rows[j]["ShortName"])] = SetBalanceLeave(Convert.ToInt32(dtLeaveCash.Rows[i]["Total " + Convert.ToString(dtLeaveDet.Rows[j]["ShortName"])]), Convert.ToInt32(dtLeaveCash.Rows[i][Convert.ToString(dtLeaveDet.Rows[j]["ShortName"]) + " Taken"]));
                                intTotalBalLeave += Convert.ToInt32(dtLeaveCash.Rows[i]["Bal " + Convert.ToString(dtLeaveDet.Rows[j]["ShortName"])]);
                            }
                            else
                            {
                                dtLeaveCash.Rows[i]["Bal " + Convert.ToString(dtLeaveDet.Rows[i]["ShortName"])] = 0;
                            }
                        }
                    }
                    dtLeaveCash.Rows[i]["Bal Leave"] = intTotalBalLeave;
                    dtLeaveCash.Rows[i]["Half Leave"] = (int)(intTotalBalLeave / 2);
                    dtLeaveCash.Rows[i]["Total Sal"] = SetTotalSalary(Convert.ToString(dtLeaveCash.Rows[i]["ID"]), cmbYear.Text.Trim());
                    if (!String.IsNullOrEmpty(Convert.ToString(dtLeaveCash.Rows[i]["Total Sal"])) && !String.IsNullOrEmpty(Convert.ToString(dtLeaveCash.Rows[i]["Half Leave"])))
                    {
                        dtLeaveCash.Rows[i]["Gross Amt"] = SetGrossAmount(Convert.ToDecimal(dtLeaveCash.Rows[i]["Total Sal"]), Convert.ToInt32(dtLeaveCash.Rows[i]["Half Leave"])).ToString("0.00");
                    }
                    else
                    {
                        dtLeaveCash.Rows[i]["Gross Amt"] = 0.00;
                    }
                }
            }
            return dtLeaveCash;
        }

        private void Report_LeaveEnCashment_Load(object sender, EventArgs e)
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
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {          
            DataTable dt = SetTotalLeaves();

            DataTable dtLeaveDetails = new DataTable();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dtLeaveDetails.Columns.Add("Column" + (i + 1));                
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                dtLeaveDetails.Rows.Add();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dtLeaveDetails.Rows[j]["Column" + (i + 1)] = dt.Rows[j][i].ToString();
                }
            }

            ReportDocument reportDocument;
            ParameterFields paramFields;
            ParameterField paramField;
            ParameterDiscreteValue paramDiscreteValue;
            reportDocument = new ReportDocument();
            paramFields = new ParameterFields();

            int columnNo = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                columnNo++;
                paramField = new ParameterField();
                paramField.Name = "col" + columnNo.ToString();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = dc.ColumnName.ToString();
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);
            }

            for (int i = columnNo; i < 25; i++)
            {
                columnNo++;
                paramField = new ParameterField();
                paramField.Name = "col" + columnNo.ToString();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = "";
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);
            }

            crystalReportViewer1.ParameterFieldInfo = paramFields;
            rptLeaveEncashment le = new rptLeaveEncashment();
            le.SetDataSource(dtLeaveDetails);
            crystalReportViewer1.ReportSource = le;
            le.SetParameterValue("Session",cmbYear.Text.Trim());

        }
    }
}