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
    public partial class Statement_of_Exgratia : EDPComponent.FormBaseERP 
    {
        public Statement_of_Exgratia()
        {
            InitializeComponent();
        }

        private void GetAllExgratia()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select ExGratia_Name,Session,ExGratia_Id from tbl_Employee_Config_Exgratia where Session=" + cmbYear.Text.Trim() + "");
            cmbExgratiaName.LookUpTable = dt;
            cmbExgratiaName.ReturnIndex = 2;
        }


        private DataTable GetHeader()
        {            
            String strSession = cmbYear.Text.Trim() + "-" + (Convert.ToInt32(cmbYear.Text.Trim()) + 1);
            DataTable dt = new DataTable();
            DataTable dtExgratia = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_Exgratia where Session='" + cmbYear.Text.Trim() + "' and ExGratia_Id=" + cmbExgratiaName.ReturnValue+ "");
            dt.Columns.Add("Name");
            for (int i = 1; i <= 12; i++)
            {
                dt.Columns.Add(clsEmployee.GetMonthName(i).Substring(0,3));
            }
            dt.Columns.Add("A.D.A");
            dt.Columns.Add("Total");
            dt.Columns.Add("Exgratia @ "+dtExgratia.Rows[0]["Amount"].ToString());
            return dt;
        }


        private Decimal GetExgratia(String strEmpID, Int32 intMnth, Int32 intExgId)
        {
            Decimal dcAmount = 0.00m;
            dcAmount = 0;
            DataTable dtExgConfig = clsDataAccess.RunQDTbl("select eeg.ExgAmount,ece.Month,eeg.EmpId,ece.ExGratia_Id from tbl_Employee_ExgratiaGiven eeg,tbl_Employee_Config_Exgratia ece where ece.ExGratia_Id=eeg.ExgratiaId and eeg.EmpId='" + strEmpID + "' and eeg.ExgratiaId='" + intExgId + "'");
            if (dtExgConfig.Rows.Count>0)
            {
                String[] intArrMnth = Convert.ToString(dtExgConfig.Rows[0]["Month"]).Split('|');
                for (int j = 0; j < intArrMnth.Length; j++)
                {
                    if (Convert.ToInt32(intArrMnth[j]) == intMnth)
                    {
                        dcAmount = Convert.ToDecimal(dtExgConfig.Rows[0]["ExgAmount"].ToString());
                    }
                }
            }
            return dcAmount;
        }

        private DataTable GetDetails()
        {
            decimal dcDA = 0.00m, dcBasic = 0.00m, dcTotal = 0.00m, dcExgratia = 0.00m,dcNet=0.00m;
            DataTable dtExgratia = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_Exgratia where Session='" + cmbYear.Text.Trim() + "' and ExGratia_Id=" + cmbExgratiaName.ReturnValue + "");
            DataTable dtDetails = GetHeader();
            String strSession = cmbYear.Text.Trim() + "-" + (Convert.ToInt32(cmbYear.Text.Trim()) + 1);
            DataTable dtEmployee = clsDataAccess.RunQDTbl("select ID,FirstName+' '+MiddleName+' '+LastName as [Employee Name] from tbl_Employee_Mast where Session='" + strSession + "'");
            if (dtEmployee.Rows.Count > 0)
            {
                for (int i = 0; i < dtEmployee.Rows.Count; i++)
                {
                    dcNet = 0;
                    dcExgratia = 0;
                    dtDetails.Rows.Add();
                    dtDetails.Rows[i]["Name"] = dtEmployee.Rows[i]["Employee Name"];
                    for (int j = 1; j <= 12; j++)
                    {
                        dcDA = 0;
                        dcBasic = 0;
                        dcTotal = 0;

                        DataTable dtBasicSalary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + dtEmployee.Rows[i]["ID"] + "' and SalId='3' and TableName='tbl_Employee_ErnSalaryHead' and Month='" + clsEmployee.GetMonthName(j) + "' and Session='" + strSession + "'");
                        DataTable dtDASalary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + dtEmployee.Rows[i]["ID"] + "' and SalId='6' and TableName='tbl_Employee_ErnSalaryHead' and Month='" + clsEmployee.GetMonthName(j) + "' and Session='" + strSession + "'");
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
                        if (dtDASalary.Rows.Count > 0)
                        {
                            if (!String.IsNullOrEmpty(dtDASalary.Rows[0]["Amount"].ToString()))
                            {
                                dcDA = Convert.ToDecimal(dtDASalary.Rows[0]["Amount"].ToString());
                            }
                            else
                            {
                                dcDA = 0;
                            }
                        }
                        dcTotal = dcBasic + dcDA;
                        dtDetails.Rows[i][clsEmployee.GetMonthName(j).Substring(0, 3)] = dcTotal.ToString("0.00");

                        
                        if (dtExgratia.Rows.Count > 0)
                        {                           
                          dcExgratia += GetExgratia(Convert.ToString(dtEmployee.Rows[i]["ID"]), j, Convert.ToInt32(cmbExgratiaName.ReturnValue));
                          dtDetails.Rows[i]["Exgratia @ " + dtExgratia.Rows[0]["Amount"].ToString()] = dcExgratia.ToString("0.00");
                        }
                        dcNet += dcTotal;
                    }
                    dtDetails.Rows[i]["Total"] = dcNet.ToString("0.00");

                }
            }

            return dtDetails;
        }

        private void GetPrint()
        {
            DataTable dt = GetDetails();
            DataTable dtExgratia = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_Exgratia where Session='" + cmbYear.Text.Trim() + "' and ExGratia_Id=" + cmbExgratiaName.ReturnValue + "");
            if (dtExgratia.Rows.Count > 0)
            {
                SimpleTextReport ExgratiaStatement = new SimpleTextReport();

                ExgratiaStatement.MainPageHeaders.Add();
                ExgratiaStatement.MainPageHeaders[0].Text = "Page No:-1" + Space(9) + "RISHRA VANI BHARATI";
                ExgratiaStatement.MainPageHeaders[0].Bold = true;
                ExgratiaStatement.MainPageHeaders[0].Expanded = true;
                ExgratiaStatement.MainPageHeaders[0].Alignment = SimpleTextReport.PutTextAlign.Left;

                ExgratiaStatement.MainPageHeaders.Add();
                ExgratiaStatement.MainPageHeaders[1].Text = "";


                ExgratiaStatement.MainPageHeaders.Add();
                ExgratiaStatement.MainPageHeaders[2].Text = "Statement of Exgratia('" + cmbExgratiaName.Text.Trim() + "') for '" + cmbYear.Text + "' @ '" + dtExgratia.Rows[0]["Amount"].ToString() + "'";
                ExgratiaStatement.MainPageHeaders[2].Bold = true;
                ExgratiaStatement.MainPageHeaders[2].Alignment = SimpleTextReport.PutTextAlign.Left;

                ExgratiaStatement.ActiveDataTable = true;
                ExgratiaStatement.DataTable = dt;


                int intColNo = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    ExgratiaStatement.ReportColumns.Add();
                    if (dc.ColumnName.ToString() == "Name")
                    {

                        ExgratiaStatement.ReportColumns[intColNo].Header.Text.Add(dc.ColumnName);
                        ExgratiaStatement.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;
                        ExgratiaStatement.ReportColumns[intColNo].LinesToAColumn = 35;
                        ExgratiaStatement.ReportColumns[intColNo].Header.Condensed = true;
                        ExgratiaStatement.ReportColumns[intColNo].TDataTable = dt;
                        ExgratiaStatement.ReportColumns[intColNo].Condensed = true;
                        ExgratiaStatement.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                        ExgratiaStatement.ReportColumns[intColNo].Borderget = true;
                    }
                    else if (dc.ColumnName.ToString() == "Jan")
                    {
                        ExgratiaStatement.ReportColumns[intColNo].Header.Text.Add("         Jan");
                        ExgratiaStatement.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                        ExgratiaStatement.ReportColumns[intColNo].LinesToAColumn = 13;
                        ExgratiaStatement.ReportColumns[intColNo].Header.Condensed = true;
                        ExgratiaStatement.ReportColumns[intColNo].TDataTable = dt;
                        ExgratiaStatement.ReportColumns[intColNo].Condensed = true;
                        ExgratiaStatement.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                        ExgratiaStatement.ReportColumns[intColNo].Borderget = true;

                    }
                    else if (dc.ColumnName.ToString() == "Exgratia @ " + dtExgratia.Rows[0]["Amount"].ToString())
                    {
                        ExgratiaStatement.ReportColumns[intColNo].Header.Text.Add("          Exgt. @" + dtExgratia.Rows[0]["Amount"].ToString());
                        ExgratiaStatement.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                        ExgratiaStatement.ReportColumns[intColNo].LinesToAColumn = 19;
                        ExgratiaStatement.ReportColumns[intColNo].Header.Condensed = true;
                        ExgratiaStatement.ReportColumns[intColNo].TDataTable = dt;
                        ExgratiaStatement.ReportColumns[intColNo].Condensed = true;
                        ExgratiaStatement.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                   

                    }
                    else
                    {
                        ExgratiaStatement.ReportColumns[intColNo].Header.Text.Add("         "+dc.ColumnName);
                        ExgratiaStatement.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;
                        ExgratiaStatement.ReportColumns[intColNo].LinesToAColumn = 13;
                        ExgratiaStatement.ReportColumns[intColNo].Header.Condensed = true;
                        ExgratiaStatement.ReportColumns[intColNo].TDataTable = dt;
                        ExgratiaStatement.ReportColumns[intColNo].Condensed = true;
                        ExgratiaStatement.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                        ExgratiaStatement.ReportColumns[intColNo].Borderget = true;
                    }
                    intColNo += 1;
                }
                ExgratiaStatement.CustomisedSection.Add();
                ExgratiaStatement.CustomisedSection[0].Lines.Add();
                ExgratiaStatement.CustomisedSection[0].Lines[0].Cells.Add();
                ExgratiaStatement.CustomisedSection[0].Lines[0].Cells[0].Text = " ";
                ExgratiaStatement.CustomisedSection.Add();
                ExgratiaStatement.CustomisedSection[1].Position = SimpleTextReport.Position.AtEndofPage;
                ExgratiaStatement.CustomisedSection[1].Lines.Add();
                ExgratiaStatement.CustomisedSection[1].Lines[0].Cells.Add();
                ExgratiaStatement.CustomisedSection[1].Lines[0].Cells[0].Text = "Prepared By:............";
                ExgratiaStatement.Print();
            }
        }




        private void cmbYear_DropDown(object sender, EventArgs e)
        {
            clsEmployee.PopulateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
        }

        private void cmbExgratiaName_DropDown(object sender, EventArgs e)
        {
            GetAllExgratia();
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Select Year."))
            {
                if (clsValidation.ValidateEdpCombo(cmbExgratiaName, "", "Please Select Year."))
                {
                    GetPrint();
                }
            }
        }
    }
}