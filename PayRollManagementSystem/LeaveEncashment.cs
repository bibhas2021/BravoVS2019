using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class LeaveEncashment : EDPComponent.FormBaseERP 
    {
        public LeaveEncashment()
        {
            InitializeComponent();
        }

        #region Function

        private void SetGridValue()
        {
            SetTotalLeaves();
        }

        private void SetTotalLeaves()
        {
            if (dgEmpLeave.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dgEmpLeave.Rows.Count; i++)
                {
                    Int32 intTotalBalLeave = 0;
                    DataTable dtLeaveDet = GetLeaveHeads(cmbYear.Text.Trim());
                    if (dtLeaveDet.Rows.Count > 0)
                    {                        
                        for (Int32 j = 0; j < dtLeaveDet.Rows.Count; j++)
                        {
                            dgEmpLeave.Rows[i].Cells["Total" + Convert.ToString(dtLeaveDet.Rows[j]["ShortName"])].Value = dtLeaveDet.Rows[j]["TotalLeaves"];
                            dgEmpLeave.Rows[i].Cells[Convert.ToString(dtLeaveDet.Rows[j]["ShortName"]) + "Taken"].Value = SetTakenLeaves(cmbYear.Text.Trim(), Convert.ToString(dgEmpLeave.Rows[i].Cells["ID"].Value),Convert.ToInt32( dtLeaveDet.Rows[j]["LeaveId"]));
                            if (!String.IsNullOrEmpty(Convert.ToString(dgEmpLeave.Rows[i].Cells["Total" + Convert.ToString(dtLeaveDet.Rows[j]["ShortName"])].Value)) && !String.IsNullOrEmpty(Convert.ToString(dgEmpLeave.Rows[i].Cells[Convert.ToString(dtLeaveDet.Rows[j]["ShortName"]) + "Taken"].Value)))
                            {
                                dgEmpLeave.Rows[i].Cells["Balance" + Convert.ToString(dtLeaveDet.Rows[j]["ShortName"])].Value = SetBalanceLeave(Convert.ToInt32(dgEmpLeave.Rows[i].Cells["Total" + Convert.ToString(dtLeaveDet.Rows[j]["ShortName"])].Value), Convert.ToInt32(dgEmpLeave.Rows[i].Cells[Convert.ToString(dtLeaveDet.Rows[j]["ShortName"]) + "Taken"].Value));
                                intTotalBalLeave += Convert.ToInt32(dgEmpLeave.Rows[i].Cells["Balance" + Convert.ToString(dtLeaveDet.Rows[j]["ShortName"])].Value);
                            }
                            else
                            {
                                dgEmpLeave.Rows[i].Cells["Balance" + Convert.ToString(dtLeaveDet.Rows[i]["ShortName"])].Value = 0;
                            }
                        }
                    }
                    dgEmpLeave.Rows[i].Cells["BalanceLeave"].Value = intTotalBalLeave;
                    dgEmpLeave.Rows[i].Cells["HalfLeave"].Value = (int)(intTotalBalLeave/2);
                    dgEmpLeave.Rows[i].Cells["TotalSalary"].Value = SetTotalSalary(Convert.ToString(dgEmpLeave.Rows[i].Cells["ID"].Value),cmbYear.Text.Trim());
                    if (!String.IsNullOrEmpty(Convert.ToString(dgEmpLeave.Rows[i].Cells["TotalSalary"].Value)) && !String.IsNullOrEmpty(Convert.ToString(dgEmpLeave.Rows[i].Cells["HalfLeave"].Value)))
                    {
                        dgEmpLeave.Rows[i].Cells["GrossAmount"].Value = SetGrossAmount(Convert.ToDecimal(dgEmpLeave.Rows[i].Cells["TotalSalary"].Value), Convert.ToInt32(dgEmpLeave.Rows[i].Cells["HalfLeave"].Value)).ToString("0.00");
                    }
                    else
                    {
                        dgEmpLeave.Rows[i].Cells["GrossAmount"].Value = 0.00;
                    }
                }
            }
        }

        private Int32 SetTakenLeaves(String strSession,String strEmpId,Int32 intLeaveId)
        {
            String[] strarrYear = strSession.Split('-');

            DateTime dtmFrom=new DateTime(Convert.ToInt32(strarrYear[0]),4,1);
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

        private Decimal SetTotalSalary(String strEmpId,String strSession)
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

        private Decimal SetGrossAmount(Decimal decTotalSalary,Int32 intHalfLeave)
        {
            Decimal decGrossAmount = 0.00m;

            if (decTotalSalary > 0 )
            {
                decGrossAmount=(Decimal)((decTotalSalary/30)*intHalfLeave);
            }

           
            return decGrossAmount;
        }

        private Decimal SetTotalDeduction(DataGridViewCell dgcellAdvance,DataGridViewCell dgcellRevStamp)
        {
            Decimal decTotalDeduction=0.00m;

            if (String.IsNullOrEmpty(Convert.ToString(dgcellAdvance.Value)))
            {
                dgcellAdvance.Value = 0.00;
            }
            if (String.IsNullOrEmpty(Convert.ToString(dgcellRevStamp.Value)))
            {
                dgcellRevStamp.Value = 0.00;
            }
            decTotalDeduction = Convert.ToDecimal(dgcellAdvance.Value) + Convert.ToDecimal(dgcellRevStamp.Value);

            return decTotalDeduction;
        }

        private Decimal SetNetPayableAmount(DataGridViewCell dgcellGross, DataGridViewCell dgcellTotalDeduc)
        {
            Decimal decNetPay = 0.00m;

            if (String.IsNullOrEmpty(Convert.ToString(dgcellGross.Value)))
            {
                dgcellGross.Value = 0.00;
            }
            if (String.IsNullOrEmpty(Convert.ToString(dgcellTotalDeduc.Value)))
            {
                dgcellTotalDeduc.Value = 0.00;
            }
            if (Convert.ToDecimal(dgcellGross.Value) >= Convert.ToDecimal(dgcellTotalDeduc.Value))
            {
                decNetPay = (Decimal)(Convert.ToDecimal(dgcellGross.Value) - Convert.ToDecimal(dgcellTotalDeduc.Value));
            }            

            return decNetPay;
        }
       
        private void ClearGrid()
        {
            dgEmpLeave.Rows.Clear();
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

        private DataTable GetLeaveHeads(String strSession)
        {
            textBox1.Text = "SELECT LeaveId,ShortName,Amount,TotalLeaves from tbl_Employee_Config_LeaveDetails where Session='" + strSession + "'";        
            DataTable dt = clsDataAccess.RunQDTbl("SELECT LeaveId,ShortName,TotalLeaves from tbl_Employee_Config_LeaveDetails where Session='" + strSession + "'");
                    
            return dt;
        }

        private void GetGridHeader()
        {
            String strBalLeave = "Balance ( ";
            dgEmpLeave.Columns.Add("ID", "ID");
            dgEmpLeave.Columns["ID"].ReadOnly = true;
            //dgEmpLeave.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgEmpLeave.Columns["ID"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgEmpLeave.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgEmpLeave.Columns.Add("Name", "Name");
            dgEmpLeave.Columns["Name"].ReadOnly = true;
            dgEmpLeave.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgEmpLeave.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgEmpLeave.Columns["Name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgEmpLeave.Columns.Add("Designation", "Desg.");
            dgEmpLeave.Columns["Designation"].ReadOnly = true;
            dgEmpLeave.Columns["Designation"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgEmpLeave.Columns["Designation"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgEmpLeave.Columns["Designation"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            DataTable dt = GetLeaveHeads(cmbYear.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    if (strBalLeave != "(")
                    {
                        strBalLeave += " + ";
                    }
                    dgEmpLeave.Columns.Add("Total"+Convert.ToString(dt.Rows[i]["ShortName"]), "Total "+Convert.ToString(dt.Rows[i]["ShortName"]));
                    dgEmpLeave.Columns["Total" + Convert.ToString(dt.Rows[i]["ShortName"])].ReadOnly = true;
                    dgEmpLeave.Columns["Total" + Convert.ToString(dt.Rows[i]["ShortName"])].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    strBalLeave += Convert.ToString(dt.Rows[i]["ShortName"]);                    
                }
                strBalLeave += " )";

                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {            
                    dgEmpLeave.Columns.Add(Convert.ToString(dt.Rows[i]["ShortName"]) + "Taken", Convert.ToString(dt.Rows[i]["ShortName"]) + " Taken");
                    dgEmpLeave.Columns[Convert.ToString(dt.Rows[i]["ShortName"]) + "Taken"].ReadOnly = true;
                    dgEmpLeave.Columns[Convert.ToString(dt.Rows[i]["ShortName"]) + "Taken"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    dgEmpLeave.Columns.Add("Balance" + Convert.ToString(dt.Rows[i]["ShortName"]), "Bal. " + Convert.ToString(dt.Rows[i]["ShortName"]));
                    dgEmpLeave.Columns["Balance" + Convert.ToString(dt.Rows[i]["ShortName"])].ReadOnly = true;
                    dgEmpLeave.Columns["Balance" + Convert.ToString(dt.Rows[i]["ShortName"])].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                dgEmpLeave.Columns.Add("BalanceLeave", strBalLeave);
                dgEmpLeave.Columns["BalanceLeave"].ReadOnly = true;
                dgEmpLeave.Columns["BalanceLeave"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgEmpLeave.Columns.Add("HalfLeave","50% Leave");
            dgEmpLeave.Columns["HalfLeave"].ReadOnly = true;
            dgEmpLeave.Columns["HalfLeave"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgEmpLeave.Columns.Add("TotalSalary", "Total Salary");
            dgEmpLeave.Columns["TotalSalary"].ReadOnly = true;
            dgEmpLeave.Columns["TotalSalary"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgEmpLeave.Columns.Add("GrossAmount", "Gross Amt.");
            dgEmpLeave.Columns["GrossAmount"].ReadOnly = true;
            dgEmpLeave.Columns["GrossAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgEmpLeave.Columns.Add("AdvAGSalary", "Adv. AG Salary");
            dgEmpLeave.Columns["AdvAGSalary"].ReadOnly = true;
            dgEmpLeave.Columns["AdvAGSalary"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgEmpLeave.Columns.Add("RevStamp", "Rev. Stamp");
            dgEmpLeave.Columns["RevStamp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgEmpLeave.Columns["RevStamp"].ReadOnly = true;
            dgEmpLeave.Columns.Add("TotalDeduc", "Total Deduc.");
            dgEmpLeave.Columns["TotalDeduc"].ReadOnly = true;
            dgEmpLeave.Columns["TotalDeduc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgEmpLeave.Columns.Add("TotalPay", "Net Pay");
            dgEmpLeave.Columns["TotalPay"].ReadOnly = true;
            dgEmpLeave.Columns["TotalPay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void GetEmployeeDetails()
        {
            Int32 intSalHead = 0;
            //dgEmpLeave.Columns["Basic"].ValueType = System.Type.GetType("Decimal");
            DataTable dtEmp = clsDataAccess.RunQDTbl("select emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName Name,desg.DesignationName from tbl_Employee_Mast emp,tbl_Employee_DesignationMaster desg where emp.DesgId=desg.SlNo");
            if (dtEmp.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dtEmp.Rows.Count; i++)
                {
                    dgEmpLeave.Rows.Add();

                    dgEmpLeave.Rows[i].Cells["Name"].Value = dtEmp.Rows[i]["Name"];
                    dgEmpLeave.Rows[i].Cells["Designation"].Value = dtEmp.Rows[i]["DesignationName"];

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
                                    dgEmpLeave.Rows[i].Cells["Total"+Convert.ToString(dtLeave.Rows[j]["ShortName"])].Value = dtEx.Rows[0]["TotalLeaves"];
                                    dgEmpLeave.Rows[i].Cells[Convert.ToString(dtLeave.Rows[j]["ShortName"]) + "Taken"].Value = dtEx.Rows[0]["LeaveTaken"];
                                    dgEmpLeave.Rows[i].Cells["Balance" + Convert.ToString(dtLeave.Rows[j]["ShortName"])].Value = dtEx.Rows[0]["BalanceLeave"];
                                }
                                else
                                {
                                    dgEmpLeave.Rows[i].Cells["Total" + Convert.ToString(dtLeave.Rows[j]["ShortName"])].Value = 0;
                                    dgEmpLeave.Rows[i].Cells[Convert.ToString(dtLeave.Rows[j]["ShortName"]) + "Taken"].Value = 0;
                                    dgEmpLeave.Rows[i].Cells["Balance" + Convert.ToString(dtLeave.Rows[j]["ShortName"])].Value = 0;
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
                            dgEmpLeave.Rows[i].Cells["BalanceLeave"].Value = dtMast.Rows[0]["BalLeave"];//"";//Convert.ToInt32(dgEmpLeave.Rows[i].Cells["BalanceLeave"].Value) + Convert.ToInt32(dgEmpLeave.Rows[i].Cells["BalanceLeave"].Value) + Convert.ToInt32(dgEmpLeave.Rows[i].Cells["BalanceLeave"].Value);
                            dgEmpLeave.Rows[i].Cells["HalfLeave"].Value = dtMast.Rows[0]["HalfLeave"];//"";
                            dgEmpLeave.Rows[i].Cells["TotalSalary"].Value = dtMast.Rows[0]["GrossAmount"];
                            dgEmpLeave.Rows[i].Cells["GrossAmount"].Value = dtMast.Rows[0]["GrossAmount"];
                            dgEmpLeave.Rows[i].Cells["AdvAGSalary"].Value = dtMast.Rows[0]["AdvAGSal"];
                            dgEmpLeave.Rows[i].Cells["RevStamp"].Value = dtMast.Rows[0]["RevStamp"];
                            dgEmpLeave.Rows[i].Cells["TotalDeduc"].Value = dtMast.Rows[0]["TotalDeduction"];
                            dgEmpLeave.Rows[i].Cells["TotalPay"].Value = dtMast.Rows[0]["NetPay"];
                        }
                        else
                        {
                            dgEmpLeave.Rows[i].Cells["BalanceLeave"].Value = 0;
                            dgEmpLeave.Rows[i].Cells["HalfLeave"].Value = 0;
                            dgEmpLeave.Rows[i].Cells["TotalSalary"].Value = 0.00;
                            dgEmpLeave.Rows[i].Cells["GrossAmount"].Value = 0.00;
                            dgEmpLeave.Rows[i].Cells["AdvAGSalary"].Value = 0.00;
                            dgEmpLeave.Rows[i].Cells["RevStamp"].Value = 0.00;
                            dgEmpLeave.Rows[i].Cells["TotalDeduc"].Value = 0.00;
                            dgEmpLeave.Rows[i].Cells["TotalPay"].Value = 0.00;
                        }
                    }
                    dgEmpLeave.Rows[i].Cells["ID"].Value = dtEmp.Rows[i]["ID"];
                }
            }
        }

        private Int32 GetLeaveEncashMastID(String strEmpId, String strSession)
        {
            Int32 intLeaveEncashMastID = 0;

            DataTable dt = clsDataAccess.RunQDTbl("select SlNo from tbl_Employee_LeaveEncashment_Mast where EmpId='" + strEmpId + "' and Session='" + strSession + "'");
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["SlNo"])))
                {
                    intLeaveEncashMastID = Convert.ToInt32(dt.Rows[0]["SlNo"]);
                }
            }

            return intLeaveEncashMastID;
        }

        private Boolean SubmitLeaveDetails(String strEmpId, String strSession, Int32 intLeaveId, Int32 intTotalLeaves, Int32 intLeaveTaken, Int32 intBalLeave)
        {
            Boolean boolStatus = false;
            if (CheckForExDetRecord(strEmpId, strSession, intLeaveId))
            {
                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_LeaveEncashment_Det set TotalLeaves=" + intTotalLeaves + ",LeaveTaken=" + intLeaveTaken + ",BalanceLeave=" + intBalLeave + ",LeaveEncashMastID=" + GetLeaveEncashMastID(strEmpId, strSession) + " where Session='" + strSession + "' and EmpId='" + strEmpId + "' and LeaveId='" + intLeaveId + "'");
            }
            else
            {
                boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO [tbl_Employee_LeaveEncashment_Det] ([Session],[EmpId],[LeaveId],TotalLeaves,[LeaveTaken],BalanceLeave,[LeaveEncashMastID])VALUES('" + cmbYear.Text.Trim() + "','" + strEmpId + "'," + intLeaveId + "," + intTotalLeaves + "," + intLeaveTaken + "," + intBalLeave + "," + GetLeaveEncashMastID(strEmpId, strSession) + ")");
            }
            return boolStatus;
        }

        private Boolean SubmitEmpLeaveDet(String strEmpId, Int32 intGridRowIndex)
        {
            Int32 intCounter = 0;
            Int32 intSalHead = 5;
            Boolean boolStatus = false;
            DataTable dtLeave = GetLeaveHeads(cmbYear.Text.Trim());
            if (dtLeave.Rows.Count > 0)
            {
                for (Int32 j = 0; j < dtLeave.Rows.Count; j++)
                {
                    //if (!String.IsNullOrEmpty(Convert.ToString(dtLeave.Rows[j]["ID"])))
                    //{
                        //intSalHead += 1;
                    if (SubmitLeaveDetails(strEmpId, cmbYear.Text.Trim(), Convert.ToInt32(dtLeave.Rows[j]["LeaveId"]), Convert.ToInt32(dgEmpLeave.Rows[intGridRowIndex].Cells["Total" + Convert.ToString(dtLeave.Rows[j]["ShortName"])].Value), Convert.ToInt32(dgEmpLeave.Rows[intGridRowIndex].Cells[Convert.ToString(dtLeave.Rows[j]["ShortName"]) + "Taken"].Value), Convert.ToInt32(dgEmpLeave.Rows[intGridRowIndex].Cells["Balance" + Convert.ToString(dtLeave.Rows[j]["ShortName"])].Value)))
                    {
                        intCounter += 1;
                    }
                    //}
                }
                if (intCounter == dtLeave.Rows.Count)
                {
                    boolStatus = true;
                }
            }
            return boolStatus;
        }

        private void SubmitEmpLeave()
        {
            Boolean boolStatus = false;
            // Boolean bool
            Int32 intCounter = 0;

            if (clsValidation.ValidateComboBox(cmbYear,"","Please Select Session"))
            {
                if (dgEmpLeave.Rows.Count > 0)
                {
                    for (Int32 i = 0; i < dgEmpLeave.Rows.Count; i++)
                    {
                        String strEmpId = Convert.ToString(dgEmpLeave.Rows[i].Cells["ID"].Value);
                        String strBalLeave = Convert.ToString(dgEmpLeave.Rows[i].Cells["BalanceLeave"].Value);
                        if (String.IsNullOrEmpty(strBalLeave))
                        {
                            strBalLeave = "0";
                        }

                        String strHalfLeave = Convert.ToString(dgEmpLeave.Rows[i].Cells["HalfLeave"].Value);
                        if (String.IsNullOrEmpty(strHalfLeave))
                        {
                            strHalfLeave = "0";
                        }

                        String strTotalSal = Convert.ToString(dgEmpLeave.Rows[i].Cells["TotalSalary"].Value);
                        if (String.IsNullOrEmpty(strTotalSal))
                        {
                            strTotalSal = "0.00";
                        }

                        String strGrossAmount = Convert.ToString(dgEmpLeave.Rows[i].Cells["GrossAmount"].Value);
                        if (String.IsNullOrEmpty(strGrossAmount))
                        {
                            strGrossAmount = "0.00";
                        }

                        String strAdvAGSalary = Convert.ToString(dgEmpLeave.Rows[i].Cells["AdvAGSalary"].Value);
                        if (String.IsNullOrEmpty(strAdvAGSalary))
                        {
                            strAdvAGSalary = "0.00";
                        }

                        String strRevStamp = Convert.ToString(dgEmpLeave.Rows[i].Cells["RevStamp"].Value);
                        if (String.IsNullOrEmpty(strRevStamp))
                        {
                            strRevStamp = "0.00";
                        }

                        String strTotalDeduc = Convert.ToString(dgEmpLeave.Rows[i].Cells["TotalDeduc"].Value);
                        if (String.IsNullOrEmpty(strTotalDeduc))
                        {
                            strTotalDeduc = "0.00";
                        }

                        String strTotalPay = Convert.ToString(dgEmpLeave.Rows[i].Cells["TotalPay"].Value);
                        if (String.IsNullOrEmpty(strTotalPay))
                        {
                            strTotalPay = "0.00";
                        }

                        if (!String.IsNullOrEmpty(strEmpId))
                        {
                            if (CheckForExMastRecord(strEmpId, cmbYear.Text.Trim()))
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("UPDATE [tbl_Employee_LeaveEncashment_Mast] SET [BalLeave] = " + strBalLeave + ",[HalfLeave] = " + strHalfLeave + ",[GrossAmount] = " + strGrossAmount + ",[AdvAGSal] = " + strAdvAGSalary + ",[RevStamp] = " + strRevStamp + ",[TotalDeduction] = " + strTotalDeduc + ",[NetPay] = " + strTotalPay + " where [EmpId] ='" + strEmpId + "' and [Session] = '" + cmbYear.Text.Trim() + "'");

                            }
                            else
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO [tbl_Employee_LeaveEncashment_Mast] ([EmpId],[Session],[BalLeave],[HalfLeave],[GrossAmount],[AdvAGSal],[RevStamp],[TotalDeduction],[NetPay]) VALUES('" + strEmpId + "','" + cmbYear.Text.Trim() + "'," + strBalLeave + "," + strHalfLeave + "," + strGrossAmount + "," + strAdvAGSalary + "," + strRevStamp + "," + strTotalDeduc + "," + strTotalPay + ")");
                            }
                        }
                        if (boolStatus)
                        {
                            if (SubmitEmpLeaveDet(strEmpId, i))
                            {
                                intCounter += 1;
                            }
                        }
                    }
                    if (intCounter == dgEmpLeave.Rows.Count)
                    {
                        ERPMessageBox.ERPMessage.Show("Employee Salary Details Submitted Successfully ");
                    }

                }
            }

        }

        #endregion

        private void LeaveEncashment_Load(object sender, EventArgs e)
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

            GetGridHeader();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetEmployeeDetails();
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ClearGrid();
            GetEmployeeDetails();
            //SetGridValue();
        }

        private void dgEmpLeave_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
            dgEmpLeave.CurrentRow.Cells["TotalDeduc"].Value = SetTotalDeduction(dgEmpLeave.CurrentRow.Cells["AdvAGSalary"], dgEmpLeave.CurrentRow.Cells["RevStamp"]);
            dgEmpLeave.CurrentRow.Cells["TotalPay"].Value = SetNetPayableAmount(dgEmpLeave.CurrentRow.Cells["GrossAmount"], dgEmpLeave.CurrentRow.Cells["TotalDeduc"]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SubmitEmpLeave();
        }
    }
}