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
    public partial class Leave_Statement : EDPComponent.FormBaseERP
    {
        public Leave_Statement()
        {
            InitializeComponent();
        }
        private Boolean ChekAllExRecord(String strSession)
        {
            Boolean boolStatus = false;

            DataTable dt = clsDataAccess.RunQDTbl("select emp.*,desg.DesignationName,job.JobType from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg, tbl_Employee_JobType job where emp.DesgId=desg.SlNo and emp.JobType=job.SlNo and emp.Session='" + strSession + "'");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }

            return boolStatus;
        }



       

        public String GetSessionByFromToDate(DateTime dtFrom, DateTime dtTo)
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

         private DataTable GetDetails(String strSession)
        {          
            strSession = GetSessionByFromToDate(dtpDate.Value, dtpToDate.Value);
            DataTable dt = clsDataAccess.RunQDTbl("SELECT LeaveId,ShortName,Amount,TotalLeaves from tbl_Employee_Config_LeaveDetails where Session='" + strSession + "'");
            DataTable dtGetDetails = new DataTable();

            DateTime dtto = Convert.ToDateTime("01/" + "01"+ "/" + cmbYear.Text.Trim());
            DateTime dtfr = Convert.ToDateTime("31"+ "/" + "12"+ "/" + cmbYear.Text.Trim());

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtGetDetails.Columns.Add(dt.Rows[i]["ShortName"].ToString() + " Period");
                dtGetDetails.Columns.Add(dt.Rows[i]["ShortName"].ToString() + " Days");
                dtGetDetails.Columns.Add(dt.Rows[i]["ShortName"].ToString() + " Date");
                dtGetDetails.Columns.Add(dt.Rows[i]["ShortName"].ToString() + " Leave Taken");
                dtGetDetails.Columns.Add(dt.Rows[i]["ShortName"].ToString() + " Bal Days");
            }
            dtGetDetails.Columns.Add("Leave B.F Days");
            dtGetDetails.Columns.Add("Remarks");
            DataTable dtGetLeaveNo = new DataTable();
            dtGetDetails.Rows.Add();
           
             for (int i = 0; i < dt.Rows.Count; i++)
             {                         
                dtGetLeaveNo = clsDataAccess.RunQDTbl("select * from tbl_Employee_Attendance where ID='" + cmbdEmpId.Text + "' and LeaveTaken='" + dt.Rows[i]["LeaveId"] + "' and Date>='" + new Edpcom.EDPCommon().getSqlDateStr(dtto) + "' and Date<='" + new Edpcom.EDPCommon().getSqlDateStr(dtfr) + "'");
                if (dtGetLeaveNo.Rows.Count > 0)
                {
                    for (int k = 0; k < dtGetLeaveNo.Rows.Count; k++)
                    {
                       // dtGetDetails.Rows.Add();
                        for (int j = 0; j < dtGetLeaveNo.Rows.Count; j++)
                        {
                            if (dtGetDetails.Rows.Count < dtGetLeaveNo.Rows.Count)
                            {
                                dtGetDetails.Rows.Add();
                            }
                            dtGetDetails.Rows[j][dt.Rows[i]["ShortName"].ToString() + " Date"] = dtGetLeaveNo.Rows[j]["Date"].ToString().Substring(0,10);
                        }
                        dtGetDetails.Rows[k][dt.Rows[i]["ShortName"].ToString() + " Leave Taken"] = "1";
                        dtGetDetails.Rows[k][dt.Rows[i]["ShortName"].ToString() + " Bal Days"] = Convert.ToInt32(dt.Rows[i]["TotalLeaves"]) - (k + 1);
                    }
                }             

                dtGetDetails.Rows[0][dt.Rows[i]["ShortName"].ToString() + " Period"] = cmbYear.Text.Trim();
                dtGetDetails.Rows[0][dt.Rows[i]["ShortName"].ToString() + " Days"] = dt.Rows[i]["TotalLeaves"].ToString();                 
             }

             //Leave B.F Days has taken as static for this time being ...because there is no entry for that.
             //It will be modified later on.

             if (dtGetLeaveNo.Rows.Count > 0)
             {
                 dtGetDetails.Rows[0]["Leave B.F Days"] = 10;
                 dtGetDetails.Rows[0]["Remarks"] = "";
             }
             dtGetDetails.Rows.Add();
             dtGetDetails.Rows[dtGetDetails.Rows.Count - 1][0] = "Total";
             
            
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 int intSum = 0;
                 dtGetDetails.Rows[dtGetDetails.Rows.Count - 1][dt.Rows[i]["ShortName"].ToString() + " Days"] = dt.Rows[i]["TotalLeaves"].ToString();

                 for (int j = 0; j < dtGetDetails.Rows.Count - 1; j++)
                 {
                     if (!String.IsNullOrEmpty(dtGetDetails.Rows[j][dt.Rows[i]["ShortName"].ToString() + " Leave Taken"].ToString()))
                     {
                         intSum += Convert.ToInt32(dtGetDetails.Rows[j][dt.Rows[i]["ShortName"].ToString() + " Leave Taken"]);
                     }
                 }
                 dtGetDetails.Rows[dtGetDetails.Rows.Count - 1][dt.Rows[i]["ShortName"].ToString() + " Leave Taken"] = intSum.ToString();
                 dtGetDetails.Rows[dtGetDetails.Rows.Count - 1][dt.Rows[i]["ShortName"].ToString() + " Bal Days"] = Convert.ToInt32(dtGetDetails.Rows[dtGetDetails.Rows.Count - 1][dt.Rows[i]["ShortName"].ToString() + " Days"]) - Convert.ToInt32(dtGetDetails.Rows[dtGetDetails.Rows.Count - 1][dt.Rows[i]["ShortName"].ToString() + " Leave Taken"]);
             }

             return dtGetDetails;
        }

        private bool Validation()
        {
            bool boolStatus = false;
            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Select Year."))
            {
                if (clsValidation.ValidateEdpCombo(cmbDesg, "", "Please Select Designation."))
                {
                    if (clsValidation.ValidateEdpCombo(cmbdEmpId, "", "Please Select Employee Id."))
                    {
                        boolStatus = true;
                    }
                }
            }

            return boolStatus;
        }

        private void GetPrint()
        {
            String strSession = GetSessionByFromToDate(dtpDate.Value, dtpToDate.Value);
            DataTable dtLeave = clsDataAccess.RunQDTbl("SELECT LeaveId,ShortName,Amount,TotalLeaves from tbl_Employee_Config_LeaveDetails where Session='" + strSession + "'");
            DataTable dt = GetDetails(strSession);
            SimpleTextReport LeaveStatement = new SimpleTextReport();
            LeaveStatement.CharactersToALine = 225;
            LeaveStatement.MainPageHeaders.Add();
            LeaveStatement.MainPageHeaders[0].Text = "Name " + lblEmpName.Text;
            LeaveStatement.MainPageHeaders[0].Alignment = SimpleTextReport.PutTextAlign.Left;
            LeaveStatement.MainPageHeaders.Add();
            LeaveStatement.MainPageHeaders[1].Text = "Leave Statement For The Year " + cmbYear.Text +" of VANI BHARATI";
            LeaveStatement.MainPageHeaders[1].Bold = true;
            LeaveStatement.MainPageHeaders[1].Expanded = true;
            LeaveStatement.MainPageHeaders[1].Alignment = SimpleTextReport.PutTextAlign.Left;
            LeaveStatement.MainPageHeaders.Add();
            LeaveStatement.MainPageHeaders[2].Text = "Designation " + cmbDesg.Text;
            LeaveStatement.MainPageHeaders[2].Alignment = SimpleTextReport.PutTextAlign.Right;

            LeaveStatement.ActiveDataTable = true;
            LeaveStatement.DataTable = dt;

            int intColNo = 0;
            foreach (DataColumn dc in dtLeave.Columns)
            {
                LeaveStatement.ReportColumns.Add();
                LeaveStatement.ReportColumns[intColNo].Header.Condensed = true;
                LeaveStatement.ReportColumns[intColNo].Header.Text.Add(dc.ColumnName);                
                LeaveStatement.ReportColumns[intColNo].Header.Text.Add(" PERIOD | DAYS | FROM | DATE | BAL. DAY ");
                LeaveStatement.ReportColumns[intColNo].LinesToAColumn = 35;
                LeaveStatement.ReportColumns[intColNo].Condensed = true;
                LeaveStatement.ReportColumns[intColNo].TDataTable = dt;
                LeaveStatement.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                LeaveStatement.ReportColumns[intColNo].Borderget = true;
                //LeaveStatement.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                intColNo += 1;
            }

            LeaveStatement.ReportColumns.Add();
            LeaveStatement.ReportColumns[intColNo].Header.Condensed = true;
            LeaveStatement.ReportColumns[intColNo].Header.Text.Add("Leave B.F Days");
            LeaveStatement.ReportColumns[intColNo].LinesToAColumn = 15;
            LeaveStatement.ReportColumns[intColNo].Condensed = true;
            LeaveStatement.ReportColumns[intColNo].TDataTable = dt;
            LeaveStatement.ReportColumns[intColNo].DataField = "Leave B.F Days";
            LeaveStatement.ReportColumns[intColNo].Borderget = true;
            //LeaveStatement.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;


            LeaveStatement.ReportColumns.Add();
            LeaveStatement.ReportColumns[intColNo].Header.Condensed = true;
            LeaveStatement.ReportColumns[intColNo + 1].Header.Text.Add("Remarks");
            LeaveStatement.ReportColumns[intColNo + 1].LinesToAColumn = 15;
            LeaveStatement.ReportColumns[intColNo + 1].Condensed = true;
            LeaveStatement.ReportColumns[intColNo + 1].TDataTable = dt;
            LeaveStatement.ReportColumns[intColNo + 1].DataField = "Remarks";
            LeaveStatement.ReportColumns[intColNo + 1].Borderget = true;
            //LeaveStatement.ReportColumns[intColNo + 1].Alignment = SimpleTextReport.PutTextAlign.Center;

            LeaveStatement.CustomisedSection.Add();
            LeaveStatement.CustomisedSection[0].Position = SimpleTextReport.Position.AtEndofPage;
            LeaveStatement.CustomisedSection[0].Lines.Add();
            LeaveStatement.CustomisedSection[0].Lines[0].Cells.Add();
            LeaveStatement.CustomisedSection[0].Lines[0].Cells[0].Text = "Prepared By:............";

            LeaveStatement.Print();

        }

        private void cmbYear_DropDown(object sender, EventArgs e)
        {
            clsEmployee.PopulateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
        }

        private void cmbdEmpId_DropDown(object sender, EventArgs e)
        
        {
            if (ChekAllExRecord(GetSessionByFromToDate(dtpDate.Value, dtpToDate.Value)))
            {
                DataTable dt = clsDataAccess.RunQDTbl("select emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name],desg.DesignationName from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg where emp.DesgId=desg.SlNo and emp.Session='" + GetSessionByFromToDate(dtpDate.Value, dtpToDate.Value) + "' and emp.DesgId=" + clsEmployee.GetDesgId(cmbDesg.Text.Trim()) + "");
                if (dt.Rows.Count > 0)
                {
                    cmbdEmpId.LookUpTable = dt;
                    cmbdEmpId.ReturnIndex = 1;
                }
            }   
        }

        private void cmbDesg_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select DesignationName,ShortForm,SlNo from tbl_Employee_DesignationMaster");
            if (dt.Rows.Count > 0)
            {
                cmbDesg.LookUpTable = dt;
                cmbDesg.ReturnIndex = 2;
            }
        }

        private void cmbdEmpId_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            lblEmpName.Text = cmbdEmpId.ReturnValue;
        }

        private void Leave_Statement_Load(object sender, EventArgs e)
        {
            dtpDate.Value = System.DateTime.Now;
            dtpToDate.Value = System.DateTime.Now;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            String  strSession = GetSessionByFromToDate(dtpDate.Value, dtpToDate.Value);
            if (Validation())
            {
                GetPrint();
            }
        }
    }
}