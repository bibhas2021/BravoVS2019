using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;



using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System.Collections;

namespace PayRollManagementSystem
{
    public partial class rptPaySlip : EDPComponent.FormBaseERP
    {
       public Decimal decTotalDeduc = 0;
        int j = 0;
        double dbearn,dbDeduc;
        public rptPaySlip()
        {
            InitializeComponent();
        }

        private Boolean ChekAllExRecord()
        {
            Boolean boolStatus = false;

            DataTable dt = clsDataAccess.RunQDTbl("select emp.*,desg.DesignationName,job.JobType from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg, tbl_Employee_JobType job where emp.DesgId=desg.SlNo and emp.JobType=job.SlNo and emp.Session='" + cmbSession.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }
            return boolStatus;
        }

        private DataTable GetSalaryHeads()
        {                     

            DataTable dtSalaryHead = new DataTable("SalaryHead");
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");
            DataTable dtPF = clsDataAccess.RunQDTbl("select ShortName,SlNo from tbl_Employee_Config_PFHeads ");
            DataTable dtSummary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryMast where Emp_Id='" + cmbdEmpId.Text + "' and Month='" + cmbMonth.Text + "' and Session='" + cmbSession.Text + "'");

            //String[,] strArr = new String[dtErn.Rows.Count + dtDeduction.Rows.Count, strColCount];
            dtSalaryHead.Columns.Add("DESCRIPTION");
            dtSalaryHead.Columns.Add("DETAILS");
            dtSalaryHead.Columns.Add("AMOUNT");
            dtSalaryHead.Columns.Add("ID");
            dtSalaryHead.Columns.Add("TableName");
            //dtSalaryHead.Columns.Add("Amount");

            for (Int32 i = 0; i < dtErn.Rows.Count; i++)
            {
                dtSalaryHead.Rows.Add();
                dtSalaryHead.Rows[i]["DESCRIPTION"] = Convert.ToString(dtErn.Rows[i]["SalaryHead_Short"]);
                dtSalaryHead.Rows[i]["DETAILS"] = "0.00";
                dtSalaryHead.Rows[i]["ID"] = Convert.ToString(dtErn.Rows[i]["SlNo"]);
                dtSalaryHead.Rows[i]["TableName"] = Convert.ToString("tbl_Employee_ErnSalaryHead");
            }
            dtSalaryHead.Rows.Add();
            if (dtSummary.Rows.Count > 0)
            {
                dtSalaryHead.Rows[dtErn.Rows.Count]["DESCRIPTION"] = "Special";
                dtSalaryHead.Rows[dtErn.Rows.Count]["DETAILS"] = dtSummary.Rows[0]["Special"].ToString();
            }
            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DETAILS"] = "-----------";

            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "Total Salary";

            dtSalaryHead.Rows.Add();
           

            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "Gross Salary";

            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "Salary for P.F Due";

            dtSalaryHead.Rows.Add();
            

            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "P.F Contribution";


            for (Int32 i = 0; i < dtPF.Rows.Count; i++)
            {
                dtSalaryHead.Rows.Add();
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "\t" + Convert.ToString(dtPF.Rows[i]["ShortName"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DETAILS"] = "0.00";
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["ID"] = Convert.ToString(dtPF.Rows[i]["SlNo"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["TableName"] = Convert.ToString("tbl_Employee_Config_PFHeads");
            }


            for (Int32 i = 0; i < dtDeduction.Rows.Count; i++)
            {
                dtSalaryHead.Rows.Add();
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = Convert.ToString(dtDeduction.Rows[i]["SalaryHead_Short"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DETAILS"] = "0.00";

                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["ID"] = Convert.ToString(dtDeduction.Rows[i]["SlNo"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["TableName"] = Convert.ToString("tbl_Employee_DeductionSalayHead");
            }
            //
            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DETAILS"] = "-----------";
            
            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "Total Deduction";

            dtSalaryHead.Rows.Add();
            dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["DESCRIPTION"] = "Net Amount Payable";

            DataTable dtAmount = new DataTable();
            for (int i = 0; i < dtSalaryHead.Rows.Count; i++)
            {
                dtAmount = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where Session='" + cmbSession.Text + "' and Month='" + cmbMonth.Text.Trim() + "' and TableName='" + dtSalaryHead.Rows[i]["TableName"] + "' and SalId='" + dtSalaryHead.Rows[i]["ID"] + "' and EmpId='" + cmbdEmpId.Text + "'");
                if (dtAmount.Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(dtAmount.Rows[0]["Amount"].ToString()))
                    {
                        dtSalaryHead.Rows[i]["DETAILS"] = dtAmount.Rows[0]["Amount"].ToString();
                    }
                    else
                    {
                        dtSalaryHead.Rows[i]["DETAILS"] = "0.00";
                    }
                }
            }
            if (dtSummary.Rows.Count > 0)
            {
                dtSalaryHead.Rows[dtErn.Rows.Count + 2]["AMOUNT"] = dtSummary.Rows[0]["GrossAmount"];
                dtSalaryHead.Rows[dtErn.Rows.Count + 4]["DETAILS"] = dtSummary.Rows[0]["GrossAmount"];
                dtSalaryHead.Rows[dtErn.Rows.Count + 5]["DETAILS"] = dtSummary.Rows[0]["PFDue"];
                decTotalDeduc += Convert.ToDecimal(dtSummary.Rows[0]["TotalDec"]);
            }
            
            //  int j;

            //for (j = dtErn.Rows.Count + 5; j <  dtErn.Rows.Count +dtPF.Rows.Count + dtDeduction.Rows.Count+5; j++)
            //{
            //    if (!String.IsNullOrEmpty(dtSalaryHead.Rows[j]["DETAILS"].ToString()))
            //    {
            
            //    }
            //}

            dtSalaryHead.Rows[dtErn.Rows.Count + dtPF.Rows.Count + dtDeduction.Rows.Count + 5 + 4]["AMOUNT"] = decTotalDeduc.ToString("0.00");
            //if (!String.IsNullOrEmpty(dtSalaryHead.Rows[dtErn.Rows.Count + 3]["DETAILS"].ToString()))
            //{
            //    decTotalDeduc = Convert.ToDecimal();
               
            //}
            if (dtSummary.Rows.Count > 0)
            {
                dtSalaryHead.Rows[dtErn.Rows.Count + dtPF.Rows.Count + dtDeduction.Rows.Count + 5 + 5]["AMOUNT"] = Convert.ToString(dtSummary.Rows[0]["NetPay"]);
            }
            return dtSalaryHead;          
        }


        private DataTable CalculateAttndance()
        {
            DataTable dtMast = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryMast where Emp_Id='" + cmbdEmpId.Text + "' and Session='" + cmbSession.Text.Trim() + "' and Month='" + cmbMonth.Text.Trim() + "'");
            DataTable dtLeavetype = clsDataAccess.RunQDTbl("select LeaveId,LeaveHead,TotalLeaves from tbl_Employee_Config_LeaveDetails");
            DataTable dtAtt = new DataTable();
            DataTable dt=new DataTable ();
            int year = clsEmployee.GetYear(cmbMonth.Text, cmbSession.Text);
            int maxday = clsEmployee.GetTotalDaysByMonth(cmbMonth.Text, year);
            DateTime dtto = Convert.ToDateTime("01/" + clsEmployee.GetMonth_DoubleDigit(cmbMonth.Text.Trim()) + "/" + year);
            DateTime dtfr = Convert.ToDateTime(maxday + "/" + clsEmployee.GetMonth_DoubleDigit(cmbMonth.Text.Trim()) + "/" + year);

            dtAtt.Columns.Add("Present Days");
            dtAtt.Columns.Add("Leave With Pay");
            dtAtt.Columns.Add("Leave Without Pay");
            dtAtt.Columns.Add("Total Days Charged");
               dtAtt.Rows.Add();
               //int i = 0;
            if (dtLeavetype.Rows.Count > 0)
            {
                for (int i = 0; i < dtLeavetype.Rows.Count; i++)
                {
                    dtAtt.Columns.Add("Column"+(i+1));
                    dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_LeaveDetails cld,tbl_Employee_Attendance ea where cld.LeaveId=ea.LeaveTaken and ea.ID='" + cmbdEmpId.Text + "' and ea.Date>='" + new Edpcom.EDPCommon().getSqlDateStr(dtto) + "' and ea.Date<='" + new Edpcom.EDPCommon().getSqlDateStr(dtfr) + "' and ea.LeaveTaken='" + dtLeavetype.Rows[i]["LeaveId"] + "'");
                    if (dt.Rows.Count > 0)
                    {
                        dtAtt.Rows[0]["Column" + (i + 1)] = dt.Rows.Count.ToString();
                    }
                    else
                    {
                        dtAtt.Rows[0]["Column" + (i + 1)] = "0";
                    }
                }
                for (int j = 0; j < dtLeavetype.Rows.Count; j++)
                {
                    dtAtt.Columns.Add("Column" + (dtLeavetype.Rows.Count + j + 1));
                    DataTable dtLeave = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_LeaveDetails cld,tbl_Employee_Attendance ea where cld.LeaveId=ea.LeaveTaken and ea.ID='" + cmbdEmpId.Text + "' and ea.Date<='" + new Edpcom.EDPCommon().getSqlDateStr(dtfr) + "' and ea.LeaveTaken='" + dtLeavetype.Rows[j]["LeaveId"] + "'");
                    if (dtLeave.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtLeavetype.Rows[j]["TotalLeaves"]) > Convert.ToInt32(dtLeave.Rows[0]["LeaveTaken"]))
                        {
                            dtAtt.Rows[0]["Column" + (dtLeavetype.Rows.Count + j + 1)] = Convert.ToInt32(dtLeavetype.Rows[j]["TotalLeaves"]) - Convert.ToInt32(dtLeave.Rows[0]["LeaveTaken"]);
                        }
                        else
                        {
                            dtAtt.Rows[0]["Column" + (dtLeavetype.Rows.Count + j + 1)] = "0";
                        }
                    }
                    else
                    {
                        dtAtt.Rows[0]["Column" + (dtLeavetype.Rows.Count + j + 1)] = Convert.ToString(dtLeavetype.Rows[j]["TotalLeaves"]);
                    }
                }
            }
            if (dtMast.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(dtMast.Rows[0]["DaysPresent"].ToString()))
                {
                    dtAtt.Rows[0]["Present Days"] = dtMast.Rows[0]["DaysPresent"];
                }
                else
                {
                    dtAtt.Rows[0]["Present Days"] = "0";
                }

                if (!String.IsNullOrEmpty(dtMast.Rows[0]["LeaveWithPay"].ToString()))
                {
                    dtAtt.Rows[0]["Leave With Pay"] = dtMast.Rows[0]["LeaveWithPay"];
                }
                else
                {
                    dtAtt.Rows[0]["Leave With Pay"] = "0";
                }

                if (!String.IsNullOrEmpty(dtMast.Rows[0]["LeaveWithoutPay"].ToString()))
                {
                    dtAtt.Rows[0]["Leave Without Pay"] = dtMast.Rows[0]["LeaveWithoutPay"];
                }
                else
                {
                    dtAtt.Rows[0]["Leave Without Pay"] = "0";
                }

                if (!String.IsNullOrEmpty(dtMast.Rows[0]["TotalDays"].ToString()))
                {
                    dtAtt.Rows[0]["Total Days Charged"] = dtMast.Rows[0]["TotalDays"];
                }
                else
                {
                    dtAtt.Rows[0]["Total Days Charged"] = "0";

                }
            }
            else
            {
                dtAtt.Rows[0]["Present Days"] = "0";
                dtAtt.Rows[0]["Leave With Pay"] = "0";
                dtAtt.Rows[0]["Leave Without Pay"] = "0";
                dtAtt.Rows[0]["Total Days Charged"] = "0";

            }
           

            return dtAtt;
        }


        private void SubmitDetails()
        {            
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

        private void cmbdEmpId_DropDown(object sender, EventArgs e)
        {
            if (clsValidation.ValidateComboBox(cmbSession, "", "Please Select Session"))
            {
                if (ChekAllExRecord())
                {

                    DataTable dt = clsDataAccess.RunQDTbl("select emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name],desg.DesignationName from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg where emp.DesgId=desg.SlNo and emp.Session='" + cmbSession.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                    {
                        cmbdEmpId.LookUpTable = dt;
                    }
                }
            }
        }

        private DataTable MergeDt()
        {
            DataTable dtAtt = CalculateAttndance();
            DataTable dtSal = GetSalaryHeads();
            foreach (DataColumn dc in dtAtt.Columns)
            {
                dtSal.Columns.Add(dc.ColumnName);
                dtSal.Rows[0][dc.ColumnName] = dtAtt.Rows[0][dc.ColumnName];
            }
            return dtSal;
          
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            decTotalDeduc = 0;
            Decimal decNetPay=0.00m ;
            DataTable dtLeavetype = clsDataAccess.RunQDTbl("select LeaveId,ShortName from tbl_Employee_Config_LeaveDetails");            
            
            if (clsValidation.ValidateComboBox(cmbMonth, "", "Please Select Month."))
            {
                if (clsValidation.ValidateEdpCombo(cmbdEmpId, "", "Please Select Employee Id."))
                {
                    DataTable dtemp = clsDataAccess.RunQDTbl("select FirstName+' '+MiddleName+' '+LastName as [Employee Name] from tbl_Employee_Mast where ID='"+cmbdEmpId.Text+"'");
                    if (dtemp.Rows.Count > 0)
                    {
                        string strName = dtemp.Rows[0]["Employee Name"].ToString();
                        DataTable dt = MergeDt();
                        if (!String.IsNullOrEmpty(dt.Rows[dt.Rows.Count - 1]["AMOUNT"].ToString()))
                        {
                            decNetPay = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1]["AMOUNT"].ToString());
                        }
                        ReportDocument reportDocument;
                        ParameterFields paramFields;
                        ParameterField paramField;
                        ParameterDiscreteValue paramDiscreteValue;
                        reportDocument = new ReportDocument();
                        paramFields = new ParameterFields();

                        int columnNo = 0;
                        for (int i = 0; i < dtLeavetype.Rows.Count; i++)
                        {
                            columnNo++;
                            paramField = new ParameterField();
                            paramField.Name = "col" + columnNo.ToString();
                            paramDiscreteValue = new ParameterDiscreteValue();
                            paramDiscreteValue.Value = dtLeavetype.Rows[i]["ShortName"].ToString()+" Taken";
                            paramField.CurrentValues.Add(paramDiscreteValue);
                            paramFields.Add(paramField);
                        }
                        for (int i = 0; i < dtLeavetype.Rows.Count; i++)
                        {
                            columnNo++;
                            paramField = new ParameterField();
                            paramField.Name = "col" + columnNo.ToString();
                            paramDiscreteValue = new ParameterDiscreteValue();
                            paramDiscreteValue.Value ="Due "+ dtLeavetype.Rows[i]["ShortName"].ToString();
                            paramField.CurrentValues.Add(paramDiscreteValue);
                            paramFields.Add(paramField);
                        }

                        for (int i = columnNo; i < 10; i++)
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
                        PaySlipreport sb = new PaySlipreport();
                        sb.SetDataSource(dt);
                        crystalReportViewer1.ReportSource = sb;

                        String strRupee = new digit_figer.RUPPES().RUPEES(Convert.ToString(Convert.ToInt32(decNetPay))) + " ONLY.";

                        //sb.SetParameterValue("session", cmbSession.Text.Trim());
                        sb.SetParameterValue("month", cmbMonth.Text.Trim());

                        sb.SetParameterValue("year", clsEmployee.GetYear(cmbMonth.Text.Trim(), cmbSession.Text.Trim()));

                        sb.SetParameterValue("rupee", strRupee);
                        if (dtemp.Rows.Count > 0)
                        {
                            sb.SetParameterValue("name", strName);
                        }
                    }
                    else
                    {
                        crystalReportViewer1.ReportSource = null;
                        ERPMessageBox.ERPMessage.Show("No Such Record Found.");
                    }
                    
                }
            }
        }

        private void rptPaySlip_Load(object sender, EventArgs e)
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
            //
        }

        private void cmbdEmpId_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            crystalReportViewer1.ReportSource = null;
        }
    }
}