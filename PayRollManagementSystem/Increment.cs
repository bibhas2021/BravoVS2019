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
    public partial class Increment : EDPComponent.FormBaseERP 
    {
        public Increment()
        {
            InitializeComponent();
        }

        private DataTable GetHeader()
        {
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");
            DataTable dt = new DataTable();
            dt.Columns.Add("SlNo");
            dt.Columns.Add("Name");
            dt.Columns.Add("DOA");
            dt.Columns.Add("Inc Sal");
            dt.Columns.Add("Prev Amt");
            dt.Columns.Add("Inc of " + cmbYear.Text.Trim());
            if (dtErn.Rows.Count > 0)
            {
                for (int i = 0; i < dtErn.Rows.Count; i++)
                {
                    dt.Columns.Add(dtErn.Rows[i]["SalaryHead_Short"].ToString());
                }
            }
            dt.Columns.Add("Total Sal");
            dt.Columns.Add("YOS on 01/01/" + cmbYear.Text.Trim());
            dt.Columns.Add("DOB");
            dt.Columns.Add("Age on 01/01/" + cmbYear.Text.Trim());
            dt.Columns.Add("Remarks");
            return dt;
        }

        private Int32 GetTotalDayofMonth(Int32 intMonth, Int32 intYear)
        {
            Int32 LastDayOfMonth = 0;

            if (intMonth == 1 || intMonth == 3 || intMonth == 5 || intMonth == 7 || intMonth == 8 || intMonth == 10 || intMonth == 12)
            {
                LastDayOfMonth = 31;
            }
            else if (intMonth == 2)
            {
                if (intYear % 4 == 0)
                {
                    LastDayOfMonth = 29;
                }
                else
                {
                    LastDayOfMonth = 28;
                }
            }
            else
            {
                LastDayOfMonth = 30;
            }

            return LastDayOfMonth;
        }


        private String AgeCalculation(int today, int tomonth, int toyear, int fromday, int frommonth, int fromyear)
        {
            String strAge = String.Empty;
            int bb = 0;
            int cc = 0;
            int DAY = 0;
            int MONTH = 0;
            int YEAR = 0;

            //For Equal Condition Of Day
            if (today == fromday)
            {
                DAY = today - fromday;
                bb = tomonth - 1;
            }

            //For Greater Condition Of Day
            else if (today > fromday)
            {
                DAY = today - fromday;
                bb = tomonth;
            }

            //For Less Condition Of Day
            else if (today < fromday)
            {
                DAY = GetTotalDayofMonth(frommonth, fromyear) + today - fromday;
                bb = tomonth - 1;
            }

            if (Convert.ToInt32(bb.ToString()) < frommonth)
            {
                MONTH = 12 + bb - frommonth;
                cc = toyear - 1;
            }
            else if (Convert.ToInt32(bb.ToString()) > frommonth)
            {
                MONTH = bb - frommonth;
                cc = toyear;
                //label7.Text = DAY.ToString() + "/" + MONTH.ToString();                    
            }
            else if (Convert.ToInt32(bb.ToString()) == frommonth)
            {
                MONTH = bb - frommonth;
                cc = toyear;
                //label7.Text = DAY.ToString() + "/" + MONTH.ToString();
            }

            if (Convert.ToInt32(cc.ToString()) <= fromyear)
            {
                YEAR = fromyear - Convert.ToInt32(cc.ToString());

            }
            else
            {
                YEAR = Convert.ToInt32(cc.ToString()) - fromyear;
            }
            strAge = DAY.ToString() + "/" + MONTH.ToString() + "/" + YEAR.ToString();
            return strAge;

        }


        private DataTable GetDetails()
        {
            int count = 0;
            DataTable dt = GetHeader();
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");

            String strSession = cmbYear.Text.Trim() + "-" + (Convert.ToInt32(cmbYear.Text.Trim()) + 1);

            DataTable dtEmployee = clsDataAccess.RunQDTbl("select ID,FirstName+' '+MiddleName+' '+LastName as [Employee Name],DateOfJoining,DateOfBirth from tbl_Employee_Mast where Session='" + strSession + "'");
            int intRowCount = 0;
            if (dtEmployee.Rows.Count > 0)
            {
                for (int i = 0; i < dtEmployee.Rows.Count; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count-1]["SlNo"] = i+1;
                    dt.Rows[dt.Rows.Count - 1]["Name"] =" "+ dtEmployee.Rows[i]["Employee Name"];
                    dt.Rows[dt.Rows.Count - 1]["DOA"] = dtEmployee.Rows[i]["DateOfJoining"].ToString().Substring(0,10);
                    dt.Rows[dt.Rows.Count - 1]["DOB"] = dtEmployee.Rows[i]["DateOfBirth"].ToString().Substring(0, 10);

                    for (int ernHd = 0; ernHd < dtErn.Rows.Count; ernHd++)
                    {
                        DataTable dtSalAmount = clsDataAccess.RunQDTbl("select Amount from tbl_Employee_SalaryDet where EmpId='" + dtEmployee.Rows[i]["ID"] + "' and SalId='" + dtErn.Rows[ernHd]["SlNo"].ToString() + "' and TableName='tbl_Employee_ErnSalaryHead' and Month='December' and Session='" + clsEmployee.GetSessionByDate(12, (Convert.ToInt32(cmbYear.Text.Trim()) - 1)) + "'");
                        if (dtSalAmount.Rows.Count > 0)
                        {
                            dt.Rows[dt.Rows.Count - 1][dtErn.Rows[ernHd]["SalaryHead_Short"].ToString()] = dtSalAmount.Rows[0]["Amount"].ToString();
                        }
                        else
                        {
                            dt.Rows[dt.Rows.Count - 1][dtErn.Rows[ernHd]["SalaryHead_Short"].ToString()] = "0.00";
                        }
                    }

                    DataTable dtIncHead = clsDataAccess.RunQDTbl("SELECT EmpId,SalId from tbl_Employee_IncrementDetails where Session='" + cmbYear.Text.Trim() + "' and EmpId='" + dtEmployee.Rows[i]["ID"].ToString() + "'");
                   
                    if (dtIncHead.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtIncHead.Rows.Count; j++)
                        {                     
                            DataTable dtIncErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead where SlNo='" + dtIncHead.Rows[j]["SalId"].ToString() + "' ");
                            DataTable dtPrevAmount = clsDataAccess.RunQDTbl("select Amount from tbl_Employee_SalaryDet where EmpId='" + dtEmployee.Rows[i]["ID"] + "' and SalId='" + dtIncHead.Rows[j]["SalId"].ToString() + "' and TableName='tbl_Employee_ErnSalaryHead' and Month='December' and Session='"+clsEmployee.GetSessionByDate(12,(Convert.ToInt32( cmbYear.Text.Trim())-1))+"'");
                            DataTable dtIncAmount = clsDataAccess.RunQDTbl("select IncAmount,SalId from tbl_Employee_IncrementDetails where EmpId='" + dtEmployee.Rows[i]["ID"] + "' and SalId='" + dtIncHead.Rows[j]["SalId"].ToString() + "' and Month='December' and Session='" + cmbYear.Text.Trim() + "'");
                            if (dtIncErn.Rows.Count > 0)
                            {
                                dt.Rows[dt.Rows.Count - 1]["Inc Sal"] = dtIncErn.Rows[0]["SalaryHead_Short"].ToString();
                                if (dtPrevAmount.Rows.Count > 0)
                                {
                                    dt.Rows[dt.Rows.Count - 1]["Prev Amt"] = dtPrevAmount.Rows[0]["Amount"].ToString();
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1]["Prev Amt"] = "0.00";
                                }

                                if (dtIncAmount.Rows.Count > 0)
                                {
                                    dt.Rows[dt.Rows.Count - 1]["Inc of " + cmbYear.Text.Trim()] = dtIncAmount.Rows[0]["IncAmount"].ToString();
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1]["Inc of " + cmbYear.Text.Trim()] = "0.00";
                                }                        


                                for(int ernHd=0;ernHd<dtErn.Rows.Count;ernHd++)
                                {
                                    if (dt.Rows[dt.Rows.Count - 1]["Inc Sal"].ToString() == dtErn.Rows[ernHd]["SalaryHead_Short"].ToString())
                                    {
                                        dt.Rows[count][dt.Rows[j + intRowCount]["Inc Sal"].ToString()] = Convert.ToDecimal(dt.Rows[j + intRowCount]["Prev Amt"]) + Convert.ToDecimal(dt.Rows[j + intRowCount]["Inc of " + cmbYear.Text.Trim()]);
                                    }
                                }
                            }
                            if (dt.Rows.Count < dtIncHead.Rows.Count + count)
                            {
                                dt.Rows.Add();

                            }
                            else
                            {
                                count = dtIncHead.Rows.Count;
                            }
                        }
                    }

                    //dt.Rows[intRowCount]["Total Sal"] ="0.00";
                    decimal dcTotal = 0.00m;

                    for (int ernHd = 0; ernHd < dtErn.Rows.Count; ernHd++)
                    {
                        dcTotal +=Convert.ToDecimal( dt.Rows[intRowCount][dtErn.Rows[ernHd]["SalaryHead_Short"].ToString()]);

                    }
                    dt.Rows[intRowCount]["Total Sal"] = dcTotal.ToString("0.00");

                    DateTime DoJ = Convert.ToDateTime(dt.Rows[intRowCount]["DOA"].ToString());
                    String stryrService = AgeCalculation(1, 1, Convert.ToInt32(cmbYear.Text.Trim()), DoJ.Day, DoJ.Month, DoJ.Year);
                    dt.Rows[intRowCount]["YOS on 01/01/" + cmbYear.Text.Trim()] = stryrService;

                    DateTime DoB = Convert.ToDateTime(dt.Rows[intRowCount]["DOB"].ToString());
                    String strAge = AgeCalculation(1, 1, Convert.ToInt32(cmbYear.Text.Trim()), DoB.Day, DoB.Month, DoB.Year);
                    dt.Rows[intRowCount]["Age on 01/01/" + cmbYear.Text.Trim()] = strAge;

                    intRowCount += dtIncHead.Rows.Count;
                }
            }

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



        private void GetPrint()
        {
            DataTable dt = GetDetails();                      
            SimpleTextReport Increment = new SimpleTextReport();
            Increment.CharactersToALine = 225;
            Increment.MainPageHeaders.Add();
            Increment.MainPageHeaders[0].Text = "Page No:-1" + Space(9) + "RISHRA VANI BHARATI";
            Increment.MainPageHeaders[0].Bold = true;
            Increment.MainPageHeaders[0].Expanded = true;
            Increment.MainPageHeaders[0].Alignment = SimpleTextReport.PutTextAlign.Left;
            Increment.MainPageHeaders.Add();
            Increment.MainPageHeaders[1].Text = " ";
           
            Increment.MainPageHeaders.Add();
            Increment.MainPageHeaders[2].Text = "Increment for The Year " + cmbYear.Text.Trim();
            Increment.MainPageHeaders[2].Bold = true;
            Increment.MainPageHeaders[2].Alignment = SimpleTextReport.PutTextAlign.Left;

            Increment.ActiveDataTable = true;
            Increment.DataTable = dt;

            int intColNo = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                Increment.ReportColumns.Add();

                if (dc.ColumnName.ToString() == "SlNo")
                {
                    Increment.ReportColumns[intColNo].Header.Text.Add(dc.ColumnName);
                    Increment.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Center;
                    Increment.ReportColumns[intColNo].LinesToAColumn = 5;
                    Increment.ReportColumns[intColNo].Header.Condensed = true;
                    Increment.ReportColumns[intColNo].TDataTable = dt;
                    Increment.ReportColumns[intColNo].Condensed = true;
                    Increment.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Increment.ReportColumns[intColNo].Borderget = true;

                }

                else if (dc.ColumnName.ToString() == "Name")
                {
                    Increment.ReportColumns[intColNo].Header.Text.Add("       "+dc.ColumnName);
                    Increment.ReportColumns[intColNo].LinesToAColumn = 28;
                    Increment.ReportColumns[intColNo].Header.Condensed = true;
                    Increment.ReportColumns[intColNo].TDataTable = dt;
                    Increment.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;
                    Increment.ReportColumns[intColNo].Condensed = true;
                    Increment.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Increment.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "DOA")
                {
                    Increment.ReportColumns[intColNo].Header.Text.Add("    "+dc.ColumnName);
                    Increment.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;

                    Increment.ReportColumns[intColNo].LinesToAColumn = 10;
                    Increment.ReportColumns[intColNo].Header.Condensed = true;
                    Increment.ReportColumns[intColNo].TDataTable = dt;
                    Increment.ReportColumns[intColNo].Condensed = true;
                    Increment.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Increment.ReportColumns[intColNo].Borderget = true;
                }


                else if (dc.ColumnName.ToString() == "Inc Sal")
                {
                    Increment.ReportColumns[intColNo].Header.Text.Add("        " + dc.ColumnName);
                    Increment.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;

                    Increment.ReportColumns[intColNo].LinesToAColumn = 13;
                    Increment.ReportColumns[intColNo].Header.Condensed = true;
                    Increment.ReportColumns[intColNo].TDataTable = dt;
                    Increment.ReportColumns[intColNo].Condensed = true;
                    Increment.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Increment.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "Prev Amt")
                {
                    Increment.ReportColumns[intColNo].Header.Text.Add("        " + dc.ColumnName);
                    Increment.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;

                    Increment.ReportColumns[intColNo].LinesToAColumn = 13;
                    Increment.ReportColumns[intColNo].Header.Condensed = true;
                    Increment.ReportColumns[intColNo].TDataTable = dt;
                    Increment.ReportColumns[intColNo].Condensed = true;
                    Increment.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Increment.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "Inc of " + cmbYear.Text.Trim())
                {
                    Increment.ReportColumns[intColNo].Header.Text.Add("     " + dc.ColumnName);
                    Increment.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;

                    Increment.ReportColumns[intColNo].LinesToAColumn = 17;
                    Increment.ReportColumns[intColNo].Header.Condensed = true;
                    Increment.ReportColumns[intColNo].TDataTable = dt;
                    Increment.ReportColumns[intColNo].Condensed = true;
                    Increment.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Increment.ReportColumns[intColNo].Borderget = true;
                }

                
                else if (dc.ColumnName.ToString() == "YOS on 01/01/" + cmbYear.Text.Trim())
                {
                    Increment.ReportColumns[intColNo].Header.Text.Add("        YOS(1/1/"+cmbYear.Text.ToString().Substring(2,2)+")");
                    Increment.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;

                    Increment.ReportColumns[intColNo].LinesToAColumn = 17;
                    Increment.ReportColumns[intColNo].Header.Condensed = true;
                    Increment.ReportColumns[intColNo].TDataTable = dt;
                    Increment.ReportColumns[intColNo].Condensed = true;
                    Increment.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Increment.ReportColumns[intColNo].Borderget = true;
                }

                else if (dc.ColumnName.ToString() == "DOB")
                {
                    Increment.ReportColumns[intColNo].Header.Text.Add(dc.ColumnName);
                    Increment.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;

                    Increment.ReportColumns[intColNo].LinesToAColumn = 18;
                    Increment.ReportColumns[intColNo].Header.Condensed = true;
                    Increment.ReportColumns[intColNo].TDataTable = dt;
                    Increment.ReportColumns[intColNo].Condensed = true;
                    Increment.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Increment.ReportColumns[intColNo].Borderget = true;
                }
                else if (dc.ColumnName.ToString() == "Total Sal")
                {
                    Increment.ReportColumns[intColNo].Header.Text.Add("     Tot Sal");
                    Increment.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;

                    Increment.ReportColumns[intColNo].LinesToAColumn = 12;
                    Increment.ReportColumns[intColNo].Header.Condensed = true;
                    Increment.ReportColumns[intColNo].TDataTable = dt;
                    Increment.ReportColumns[intColNo].Condensed = true;
                    Increment.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Increment.ReportColumns[intColNo].Borderget = true;

                }

                else if (dc.ColumnName.ToString() == "Age on 01/01/" + cmbYear.Text.Trim())
                {
                    Increment.ReportColumns[intColNo].Header.Text.Add("           Age(1/1/"+cmbYear.Text.ToString().Substring(2,2)+")");
                    Increment.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;

                    Increment.ReportColumns[intColNo].LinesToAColumn = 24;
                    Increment.ReportColumns[intColNo].Header.Condensed = true;
                    Increment.ReportColumns[intColNo].TDataTable = dt;
                    Increment.ReportColumns[intColNo].Condensed = true;
                    Increment.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Increment.ReportColumns[intColNo].Borderget = true;

                }
                else if (dc.ColumnName.ToString() == "Remarks")
                {
                    Increment.ReportColumns[intColNo].Header.Text.Add("          Rem");
                    Increment.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Left;

                    Increment.ReportColumns[intColNo].LinesToAColumn = 12;
                    Increment.ReportColumns[intColNo].Header.Condensed = true;
                    Increment.ReportColumns[intColNo].TDataTable = dt;
                    Increment.ReportColumns[intColNo].Condensed = true;
                    Increment.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    
                }
                else
                {
                    
                    Increment.ReportColumns[intColNo].Header.Text.Add("      "+dc.ColumnName);
                    Increment.ReportColumns[intColNo].Alignment = SimpleTextReport.PutTextAlign.Right;

                    Increment.ReportColumns[intColNo].LinesToAColumn = 13;
                    Increment.ReportColumns[intColNo].Header.Condensed = true;
                    Increment.ReportColumns[intColNo].TDataTable = dt;
                    Increment.ReportColumns[intColNo].Condensed = true;
                    Increment.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    Increment.ReportColumns[intColNo].Borderget = true;
                }
                intColNo += 1;
            }

            Increment.CustomisedSection.Add();
            Increment.CustomisedSection[0].Position = SimpleTextReport.Position.AtEndofPage;
            Increment.CustomisedSection[0].Lines.Add();
            Increment.CustomisedSection[0].Lines[0].Cells.Add();
            Increment.CustomisedSection[0].Lines[0].Cells[0].Text = "Prepared By:............";
            
            Increment.Print();
        }
       

        private void cmbYear_DropDown(object sender, EventArgs e)
        {
            clsEmployee.PopulateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            GetPrint();
        }
    }
}