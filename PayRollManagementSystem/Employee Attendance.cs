using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class Employee_Attendance : EDPComponent .FormBaseERP 
    {
        public Employee_Attendance()
        {
            InitializeComponent();
        }
        #region Events

        private void Employee_Attendance_Load(object sender, EventArgs e)
        {
            dtpDate.Value = System.DateTime.Now;
            dtpToDate.Value =System.DateTime.Now;
        }

        private void cmbEmpDesg_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PopulateGrid();
        }

        private void cmbEmpDesg_DropDown(object sender, EventArgs e)
        {
            //PopulateCombo(); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
                SubmitDetails();
            
        }
        #endregion

        #region Functions

        private Boolean ValidateGrid(Int32 intRowIndex)
        {
            Boolean boolStatus = false;
            if (Convert.ToString(DgAttendance.Rows[intRowIndex].Cells["Status"].Value).ToLower() == "false" || Convert.ToInt32(DgAttendance.Rows[intRowIndex].Cells["Status"].Value) == 0)
            {
                ERPMessageBox.ERPMessage.Show("Please Check The Absent Box in Line " + (intRowIndex + 1));
            }
            else
            {
                if (Convert.ToString(DgAttendance.Rows[intRowIndex].Cells["Status"].Value).ToLower() == "true" || Convert.ToInt32(DgAttendance.Rows[intRowIndex].Cells["Status"].Value) == 1)
                {
                    if (String.IsNullOrEmpty(Convert.ToString(DgAttendance.Rows[intRowIndex].Cells["LeaveTaken"].Value)))
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Leave Taken in Line " + (intRowIndex + 1));
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(Convert.ToString(DgAttendance.Rows[intRowIndex].Cells["LeaveType"].Value)))
                        {
                            ERPMessageBox.ERPMessage.Show("Please Enter Leave Type in Line " + (intRowIndex + 1));
                        }
                        else
                        {
                            boolStatus = true;
                        }
                    }
                }
            }
            return boolStatus;
        }

        private void ClearGrid()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select b.SlNo,a.ID,a.FirstName+' '+a.MiddleName+' '+a.LastName as [Employee Name],b.Date,b.Status,b.Remarks,b.LeaveTaken,b.LeaveType from tbl_Employee_Mast as a,tbl_Employee_Attendance as b where a.DesgId=0 and a.ID=b.ID");
            DgAttendance.DataSource = dt;
        }

        private void SubmitDetails()
        {
            Boolean boolStatus = true;
            int intStatus = 0;
            int intCounter = 0;
            if (clsValidation.ValidateEdpCombo(cmbDesg, "", "Select Designation"))
            {
                if (DgAttendance.Rows.Count > 1)
                {
                    for (int i = 0; i < DgAttendance.Rows.Count-1; i++)
                    {
                        if (ValidateGrid(i))
                        {
                            String strSlNo = Convert.ToString(DgAttendance.Rows[i].Cells["SlNo"].Value);
                            String strID = cmbdEmpId.Text.Trim();

                            String strCheck = Convert.ToString(DgAttendance.Rows[i].Cells["Status"].Value);
                            if (!String.IsNullOrEmpty(strCheck))
                            {
                                if (strCheck.ToLower() == "true" || strCheck.ToLower() == "1")
                                {
                                    intStatus = 0;
                                }
                                else
                                {
                                    intStatus = 1;
                                }
                            }
                            else
                            {
                                intStatus = 1;
                            }
                            String strRemarks = Convert.ToString(DgAttendance.Rows[i].Cells["Remarks"].Value);
                            string leavetaken = "½." + clsEmployee.GetLeaveId(Convert.ToString(DgAttendance.Rows[i].Cells["LeaveTaken"].Value).Substring(1, DgAttendance.Rows[i].Cells["LeaveTaken"].Value.ToString().IndexOf("+") - 1)).ToString() + "+½." + clsEmployee.GetLeaveId(Convert.ToString(DgAttendance.Rows[i].Cells["LeaveTaken"].Value).Substring(DgAttendance.Rows[i].Cells["LeaveTaken"].Value.ToString().IndexOf("+") + 2, DgAttendance.Rows[i].Cells["LeaveTaken"].Value.ToString().Length - (DgAttendance.Rows[i].Cells["LeaveTaken"].Value.ToString().IndexOf("+") + 2))).ToString();

                            if (String.IsNullOrEmpty(strSlNo))
                            {
                                //boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Attendance(ID,Status,Remarks,Date,LeaveTaken,LeaveType)values('" + strID + "'," + intStatus + ",'" + strRemarks + "','" + new Edpcom.EDPCommon().getSqlDateStr(Convert.ToDateTime(DgAttendance.Rows[i].Cells["Date"].Value)) + "','" + leavetaken + "','" + Convert.ToString(DgAttendance.Rows[i].Cells["LeaveType"].Value) + "')");
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Attendance(ID,Status,Remarks,Date,LeaveType,FstLeave,SndLeave)values('" + strID + "','" + intStatus + "','" + strRemarks + "','" + new Edpcom.EDPCommon().getSqlDateStr(Convert.ToDateTime(DgAttendance.Rows[i].Cells["Date"].Value)) + "','" + Convert.ToString(DgAttendance.Rows[i].Cells["LeaveType"].Value) + "'," + clsEmployee.GetLeaveId(Convert.ToString(DgAttendance.Rows[i].Cells["LeaveTaken"].Value).Substring(1, DgAttendance.Rows[i].Cells["LeaveTaken"].Value.ToString().IndexOf("+") - 1)) + "," + clsEmployee.GetLeaveId(Convert.ToString(DgAttendance.Rows[i].Cells["LeaveTaken"].Value).Substring(DgAttendance.Rows[i].Cells["LeaveTaken"].Value.ToString().IndexOf("+") + 2, DgAttendance.Rows[i].Cells["LeaveTaken"].Value.ToString().Length - (DgAttendance.Rows[i].Cells["LeaveTaken"].Value.ToString().IndexOf("+") + 2)))+ ")");                                
                            }
                            else
                            {
                                //boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Attendance set Status=" + intStatus + ",Remarks='" + strRemarks + "',LeaveTaken='" + leavetaken + "',LeaveType='" + Convert.ToString(DgAttendance.Rows[i].Cells["LeaveType"].Value) + "' where ID='" + strID + "' and SlNo='" + strSlNo + "'");
                                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Attendance set Status=" + intStatus + ",Remarks='" + strRemarks + "',LeaveType='" + Convert.ToString(DgAttendance.Rows[i].Cells["LeaveType"].Value) + "',FstLeave=" + clsEmployee.GetLeaveId(Convert.ToString(DgAttendance.Rows[i].Cells["LeaveTaken"].Value).Substring(1, DgAttendance.Rows[i].Cells["LeaveTaken"].Value.ToString().IndexOf("+") - 1)) + ",SndLeave="+clsEmployee.GetLeaveId(Convert.ToString(DgAttendance.Rows[i].Cells["LeaveTaken"].Value).Substring(DgAttendance.Rows[i].Cells["LeaveTaken"].Value.ToString().IndexOf("+") + 1, DgAttendance.Rows[i].Cells["LeaveTaken"].Value.ToString().Length - (DgAttendance.Rows[i].Cells["LeaveTaken"].Value.ToString().IndexOf("+") + 2)))+" where ID='" + strID + "' and SlNo='" + strSlNo + "'");
                            }
                            if (boolStatus)
                            {
                                intCounter += 1;
                            }
                        }
                    }
                    if (intCounter == DgAttendance.Rows.Count-1)
                    {
                        ClearGrid();
                        ERPMessageBox.ERPMessage.Show("Employees' Attendence Details Submitted Successfully.");
                    }
                }
            }
           
        }

        private void SingleDateInsertion()
        {
                
            String strQuery = "select att.SlNo,emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name],att.Date,att.Status,att.Remarks,lvdet.ShortName LeaveTaken,att.LeaveType from tbl_Employee_Mast emp,tbl_Employee_Attendance att,tbl_Employee_DesignationMaster desg,tbl_Employee_JobType job,tbl_Employee_Config_LeaveDetails lvdet where emp.DesgId=desg.SlNo and emp.JobType=job.SlNo and att.LeaveTaken=lvdet.LeaveId and emp.ID=att.ID and emp.DesgId=" + clsEmployee.GetDesgId(cmbDesg.Text.Trim()) + " and emp.JobType=" + clsEmployee.GetJobTypeId(cmbEmpType.Text.Trim()) + " and att.Date='" + new Edpcom.EDPCommon().getSqlDateStr(dtpDate.Value) + "' and emp.ID='" + cmbdEmpId.Text.Trim() + "'";
            DataTable dt = clsDataAccess.RunQDTbl(strQuery);
            if (dt.Rows.Count > 0)
            {
                DgAttendance.DataSource = dt;
            }
            else
            {
                strQuery = "select '' SlNo,emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name],'' Date,1 Status,'' Remarks,'' LeaveTaken,'' LeaveType from tbl_Employee_Mast emp where emp.ID='" + cmbdEmpId.Text.Trim() + "'";
                dt = clsDataAccess.RunQDTbl(strQuery);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Date"] = dtpDate.Text.ToString();
                }
                DgAttendance.DataSource = dt;
            }
        }

        private void MultipleDateInsertion()
        {
            ClearGrid();
            PopulateComboColumnInGrid(GetSessionByFromToDate(dtpDate.Value, dtpToDate.Value));     
            DataTable dtDetails = new DataTable();
            DataTable dtEmp = new DataTable();
            DateTime toDate = Convert.ToDateTime(dtpDate.Text.Trim());
            DateTime DateRange = new DateTime(toDate.Year, toDate.Month, toDate.Day);
            Int32 j = 0;

            String strQuery = "select '' SlNo,emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name],'' Date,1 Status,'' Remarks,'' LeaveTaken,'' LeaveType from tbl_Employee_Mast emp,tbl_Employee_DesignationMaster desg,tbl_Employee_JobType job where emp.DesgId=desg.SlNo and emp.DesgId=" + clsEmployee.GetDesgId(cmbDesg.Text.Trim()) + " and emp.JobType=" + clsEmployee.GetJobTypeId(cmbEmpType.Text.Trim()) + " and emp.JobType=job.SlNo and emp.ID='" + cmbdEmpId.Text.Trim() + "'";
            dtDetails = clsDataAccess.RunQDTbl(strQuery);

            if (dtDetails.Rows.Count > 0)
            {
                while (DateRange.AddDays(j) <= dtpToDate.Value)
                {
                    dtEmp.Rows.Add();

                    if (dtEmp.Rows.Count == 1)
                    {
                        dtEmp = dtDetails;

                        //dtEmp.Rows[dtEmp.Rows.Count - 1]["Employee Name"] = dtDetails.Rows[0]["Employee Name"];
                        //dtEmp.Rows[dtEmp.Rows.Count - 1]["ID"] = dtDetails.Rows[0]["ID"];
                    }
                    else
                    {
                        dtEmp.Rows[dtEmp.Rows.Count - 1]["Employee Name"] = dtEmp.Rows[dtEmp.Rows.Count - 2]["Employee Name"];
                        dtEmp.Rows[dtEmp.Rows.Count - 1]["ID"] = dtEmp.Rows[dtEmp.Rows.Count - 2]["ID"];
                    }
                    //for (int i = 0; i < dtEmp.Rows.Count; i++)
                    //{
                        string strAtt = "select att.SlNo,att.Status,att.Remarks,lvdet.ShortName LeaveTaken,att.LeaveType from tbl_Employee_Attendance att,tbl_Employee_Config_LeaveDetails lvdet where lvdet.LeaveId=att.LeaveTaken and att.Date='" + new Edpcom.EDPCommon().getSqlDateStr(DateRange.AddDays(j)) + "' and att.ID='" + dtEmp.Rows[dtEmp.Rows.Count - 1]["ID"] + "'";
                        DataTable dtAtt = clsDataAccess.RunQDTbl(strAtt);
                        if (dtAtt.Rows.Count > 0)
                        {
                            if (!String.IsNullOrEmpty(Convert.ToString(dtAtt.Rows[0]["Status"])))
                            {
                                if (Convert.ToString(dtAtt.Rows[0]["Status"]).ToLower() == "false" || Convert.ToString(dtAtt.Rows[0]["Status"]) == "0")
                                {
                                    dtEmp.Rows[dtEmp.Rows.Count - 1]["Status"] = 0;
                                }
                                else
                                {
                                    dtEmp.Rows[dtEmp.Rows.Count - 1]["Status"] = 1;//dtAtt.Rows[0]["Status"];
                                }
                            }
                            else
                            {
                                dtEmp.Rows[dtEmp.Rows.Count - 1]["Status"] = 1;
                            }
                            dtEmp.Rows[dtEmp.Rows.Count - 1]["LeaveTaken"] = dtAtt.Rows[0]["LeaveTaken"];
                            dtEmp.Rows[dtEmp.Rows.Count - 1]["LeaveType"] = dtAtt.Rows[0]["LeaveType"];
                            dtEmp.Rows[dtEmp.Rows.Count - 1]["Remarks"] = dtAtt.Rows[0]["Remarks"];
                            dtEmp.Rows[dtEmp.Rows.Count - 1]["SlNo"] = dtAtt.Rows[0]["SlNo"];

                        }
                        else
                        {
                            dtEmp.Rows[dtEmp.Rows.Count - 1]["Status"] = 1;
                        }
                        dtEmp.Rows[dtEmp.Rows.Count - 1]["Date"] = DateRange.AddDays(j);

                    //}
                    j += 1;
                }

                DgAttendance.DataSource = dtEmp;
            }
        }

        private void PopulateGrid()
        {
            ClearGrid();

            DateTime dtFrom = Convert.ToDateTime("01/" + clsEmployee.GetMonth_DoubleDigit(cmbMonth.Text.Trim()) + "/" + cmbYear.Text.Substring(0,4));
            //MessageBox.Show(Convert.ToDateTime(clsEmployee.GetTotalDaysByMonth(cmbMonth.Text.Trim(), Convert.ToInt32(cmbYear.Text.Substring(0, 4))) + "/" + clsEmployee.GetMonth_DoubleDigit(cmbMonth.Text.Trim()) + "/" + cmbYear.Text.Substring(0, 4)).ToString());
            DateTime dtTo = Convert.ToDateTime(clsEmployee.GetTotalDaysByMonth(cmbMonth.Text.Trim(), Convert.ToInt32(cmbYear.Text.Substring(0, 4))) + "/" + clsEmployee.GetMonth_DoubleDigit(cmbMonth.Text.Trim()) + "/" + cmbYear.Text.Substring(0, 4));

            PopulateComboColumnInGrid(GetSessionByFromToDate(dtFrom,dtTo));

            DataTable dt = clsDataAccess.RunQDTbl("select att.SlNo,att.ID,att.Date,att.Status,lvdet.ShortName LeaveTaken,att.LeaveType,att.Remarks from tbl_Employee_Attendance  att,tbl_Employee_Config_LeaveDetails lvdet where att.LeaveTaken=lvdet.LeaveId and att.Date>='" + clsEmployee.GetMonth_DoubleDigit(cmbMonth.Text.Trim()) + "/01/" + cmbYear.Text.Substring(0, 4) + "' and att.Date<='" + clsEmployee.GetMonth_DoubleDigit(cmbMonth.Text.Trim()) + "/" + clsEmployee.GetTotalDaysByMonth(cmbMonth.Text.Trim(), Convert.ToInt32(cmbYear.Text.Substring(0, 4))) + "/" + cmbYear.Text.Substring(0, 4) + "' and att.Status=0 and att.ID='" + cmbdEmpId.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                DgAttendance.DataSource = dt;
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    DgAttendance.Rows[i].Cells["Status"].Value = 1;
                }
            }
            else
            {
               DataTable dt1 = clsDataAccess.RunQDTbl("select '' SlNo,'' ID,getdate() Date,0 Status,'' LeaveTaken,'' LeaveType,'' Remarks from tbl_Employee_Attendance  where ID=' '");
               DgAttendance.DataSource = dt1;
            }
        }

        private void PopulateComboColumnInGrid(String strSession)
        {
            //DataGridViewComboBoxColumn cmbColLeaveTaken = (DataGridViewComboBoxColumn)DgAttendance.Columns["LeaveTaken"];
            //DataTable dt = clsDataAccess.RunQDTbl("select ShortName from tbl_Employee_Config_LeaveDetails where Session='" + strSession + "'");
            //if (dt.Rows.Count > 0)
            //{
            //    cmbColLeaveTaken.Items.Clear();
            //    for (Int32 i = 0; i < dt.Rows.Count; i++)
            //    {
            //        cmbColLeaveTaken.Items.Add(dt.Rows[i]["ShortName"]);
            //    }
            //}
        }

        public String GetSessionByFromToDate(DateTime dtFrom,DateTime dtTo)
        {
            String strSession = String.Empty;

            if (dtpDate.Value != dtpToDate.Value)
            {
                String strFromSession = Convert.ToString(clsEmployee.GetSessionByDate(dtFrom.Month, dtFrom.Year));
                String strToSession = Convert.ToString(clsEmployee.GetSessionByDate(dtTo.Month, dtTo.Year));

                if (strFromSession.Trim() == strToSession.Trim())
                {
                    strSession = strFromSession;
                }

                else
                {
                    ERPMessageBox.ERPMessage.Show("Please Select Date from Same Session ");
                }
            }
            else
            {
                String strFromSession = Convert.ToString(clsEmployee.GetSessionByDate(dtpDate.Value.Month, dtpDate.Value.Year));
                strSession = strFromSession;
            }           

            return strSession;
        }

        private Boolean ChekAllExRecord(String strSession)
        {
            Boolean boolStatus = false;

            //DataTable dt = clsDataAccess.RunQDTbl("select emp.*,desg.DesignationName,job.JobType from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg, tbl_Employee_JobType job where emp.DesgId=desg.SlNo and emp.JobType=job.SlNo and emp.Session='" + strSession + "'");
            DataTable dt = clsDataAccess.RunQDTbl("select emp.*,desg.DesignationName,job.JobType from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg, tbl_Employee_JobType job where emp.DesgId=desg.SlNo and emp.JobType=job.SlNo ");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }

            return boolStatus;
        }       

        private Boolean Validation()
        {
            Boolean boolStatus = false;

            if (clsValidation.CompareFromDateToDate(dtpDate.Value, dtpToDate.Value,"From Date Cannot Be Less Than To Date"))
            {
                if (clsValidation.ValidateEdpCombo(cmbDesg, "", "Please Select Designation"))
                {
                    if (clsValidation.ValidateEdpCombo(cmbEmpType, "", "Please Select Job Type"))
                    {
                        if (clsValidation.ValidateEdpCombo(cmbdEmpId, "", "Please Select Employee Id"))
                        {
                            boolStatus = true;
                        }
                    }
                }
            }

            return boolStatus;
        }

        #endregion
        
        private void cmbDesg_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select DesignationName,ShortForm,SlNo from tbl_Employee_DesignationMaster");
            if (dt.Rows.Count > 0)
            {
                cmbDesg.LookUpTable = dt;
                cmbDesg.ReturnIndex = 2;
            }
        }

        private void cmbEmpType_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select JobType,ShortForm,SlNo from tbl_Employee_JobType");
            if (dt.Rows.Count > 0)
            {
                cmbEmpType.LookUpTable = dt;
                cmbEmpType.ReturnIndex = 2;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                PopulateGrid();               
            }
        }

        private void cmbdEmpId_DropDown(object sender, EventArgs e)
        {            
            if (ChekAllExRecord(GetSessionByFromToDate(dtpDate.Value,dtpToDate.Value)))
            {
                //DataTable dt = clsDataAccess.RunQDTbl("select emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name],desg.DesignationName from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg where emp.DesgId=desg.SlNo and emp.Session='" + GetSessionByFromToDate(dtpDate.Value, dtpToDate.Value) + "' and emp.DesgId=" + clsEmployee.GetDesgId(cmbDesg.Text.Trim()) + " and emp.JobType=" + clsEmployee.GetJobTypeId(cmbEmpType.Text.Trim()) + "");
                DataTable dt = clsDataAccess.RunQDTbl("select emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name],desg.DesignationName from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg where emp.DesgId=desg.SlNo  and emp.DesgId=" + clsEmployee.GetDesgId(cmbDesg.Text.Trim()) + " and emp.JobType=" + clsEmployee.GetJobTypeId(cmbEmpType.Text.Trim()) + "");
                if (dt.Rows.Count > 0)
                {
                    cmbdEmpId.LookUpTable = dt;
                    cmbdEmpId.ReturnIndex = 1;
                }
            }           
        }

        private void cmbdEmpId_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            lblEmpName.Text = cmbdEmpId.ReturnValue;
        }

        private void cmbYear_DropDown(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
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

        private void DgAttendance_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ERPMessageBox.ERPMessage.Show("Please Enter a Valid "+ DgAttendance.Columns[e.ColumnIndex].HeaderText);
        }

        private void DgAttendance_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    if (DgAttendance.Rows[DgAttendance.CurrentRow.Index].Cells["LeaveTaken"].Value.ToString() != "")
                    {
                        clsEmployee.FirstHalf = DgAttendance.Rows[DgAttendance.CurrentRow.Index].Cells["LeaveTaken"].Value.ToString().Substring(0, DgAttendance.Rows[DgAttendance.CurrentRow.Index].Cells["LeaveTaken"].Value.ToString().IndexOf("+"));
                        clsEmployee.SecondHalf = DgAttendance.Rows[DgAttendance.CurrentRow.Index].Cells["LeaveTaken"].Value.ToString().Substring(DgAttendance.Rows[DgAttendance.CurrentRow.Index].Cells["LeaveTaken"].Value.ToString().IndexOf("+") + 1, DgAttendance.Rows[DgAttendance.CurrentRow.Index].Cells["LeaveTaken"].Value.ToString().Length - DgAttendance.Rows[DgAttendance.CurrentRow.Index].Cells["LeaveTaken"].Value.ToString().IndexOf("+") - 1);
                        clsEmployee.Remarks = DgAttendance.Rows[DgAttendance.CurrentRow.Index].Cells["Remarks"].Value.ToString();
                    }
                    //frmDailyAttendance frmadd = new frmDailyAttendance(cmbYear.Text, cmbdEmpId.Text);
                    //frmadd.ShowDialog();
                    //DgAttendance.Rows[DgAttendance.CurrentRow.Index].Cells["LeaveTaken"].Value = clsEmployee.FirstHalf + "+" + clsEmployee.SecondHalf;
                    //DgAttendance.Rows[DgAttendance.CurrentRow.Index].Cells["Remarks"].Value = clsEmployee.Remarks;
                }
            }
            catch (Exception ex)
            {
                ERPMessageBox.ERPMessage.Show(ex.Message);
            }
        }            
    }
}