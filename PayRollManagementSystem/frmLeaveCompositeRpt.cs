using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frmLeaveCompositeRpt : Form
    {
        public frmLeaveCompositeRpt()
        {
            InitializeComponent();
        }
        string Locations = "",session="";
        string Accyr;
        string Company_id = "0", Location_id = "0";


        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 1)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
                cmbLocation.Text = "";
            }
            else if (dt.Rows.Count == 1)
            {
                Company_id = dt.Rows[0]["Co_Code"].ToString();
            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                Company_id = (CmbCompany.ReturnValue);
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                cmbLocation.Text = "";

                s = " select  l.Location_Name,l.Location_ID from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID = '" + Company_id + "'";
                DataTable dt = clsDataAccess.RunQDTbl(s);
                if (dt.Rows.Count > 0)
                {
                    cmbLocation.LookUpTable = dt;
                    cmbLocation.ReturnIndex = 1;

                }

            }
            catch
            {
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                Location_id = (cmbLocation.ReturnValue);
        }

        private void frmLeaveCompositeRpt_Load(object sender, EventArgs e)
        {
            CmbCompany.PopUp();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Company_id = (CmbCompany.ReturnValue);
            Location_id = (cmbLocation.ReturnValue);
            //session = cmbYear.Text;
            Accyr = dtpYear.Text;//session.Split('-');

            DataTable dtCloned = new DataTable();

            DataTable dtEmp =clsDataAccess.RunQDTbl("select distinct ID,(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS 'NAME OF WORKMAN',"+
"(SELECT DateOfJoining FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS 'DOJ',DATEDIFF(month, (SELECT DateOfJoining FROM tbl_Employee_Mast em WHERE (ID = ea.ID)),'"+ Accyr +"/01/01')diff,"+
"(select DesignationName from tbl_Employee_DesignationMaster where slno=ea.Desgid)as 'Designation',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='1/"+ Accyr +"')),0) as 'WD1',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='January-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal1',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='2/"+ Accyr +"')),0) as 'WD2',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='February-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal2',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='3/"+ Accyr +"')),0) as 'WD3',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='March-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal3',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='4/"+ Accyr +"')),0) as 'WD4',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='April-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal4',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='5/"+ Accyr +"')),0) as 'WD5',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='May-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal5',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='6/"+ Accyr +"')),0) as 'WD6',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='June-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal6',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='7/"+ Accyr +"')),0) as 'WD7',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='July-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal7',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='8/"+ Accyr +"')),0) as 'WD8',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='August-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal8',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='9/"+ Accyr +"')),0) as 'WD9',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='September-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal9',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='10/"+ Accyr +"')),0) as 'WD10',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='October-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal10',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='11/"+ Accyr +"')),0) as 'WD11',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='November-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal11',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='12/"+ Accyr +"')),0) as 'WD12',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='December-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal12' FROM tbl_Employee_Attend ea where (month like '%"+ Accyr +"') and (LOcation_ID="+Location_id+")  order by [doj]");
            string rpt_qry = "", mid_body = "", tdays = "", nodwork = "", nSal = "", old_qry="",fTotal="";
            double old_val = 0, new_val = 0;

            old_qry="select distinct ID,(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS 'NAME OF WORKMAN',"+
"(SELECT DateOfJoining FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS 'DOJ',DATEDIFF(month, (SELECT DateOfJoining FROM tbl_Employee_Mast em WHERE (ID = ea.ID)),'"+ Accyr +"/01/01')diff,"+
"(select DesignationName from tbl_Employee_DesignationMaster where slno=ea.Desgid)as 'Designation',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='1/"+ Accyr +"')),0) as 'WD1',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='January-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal1',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='2/"+ Accyr +"')),0) as 'WD2',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='February-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal2',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='3/"+ Accyr +"')),0) as 'WD3',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='March-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal3',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='4/"+ Accyr +"')),0) as 'WD4',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='April-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal4',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='5/"+ Accyr +"')),0) as 'WD5',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='May-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal5',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='6/"+ Accyr +"')),0) as 'WD6',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='June-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal6',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='7/"+ Accyr +"')),0) as 'WD7',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='July-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal7',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='8/"+ Accyr +"')),0) as 'WD8',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='August-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal8',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='9/"+ Accyr +"')),0) as 'WD9',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='September-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal9',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='10/"+ Accyr +"')),0) as 'WD10',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='October-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal10',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='11/"+ Accyr +"')),0) as 'WD11',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='November-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal11',"+
"isNull((select isNull(days_wd,0) FROM tbl_Employee_Attend att where (ID=ea.ID)and LOcation_ID=ea.LOcation_ID and (month='12/"+ Accyr +"')),0) as 'WD12',"+
"isNull((select sum(Amount) from [tbl_Employee_SalaryGross] where (EmpId=ea.ID) and (Location_id=ea.Location_id) and (month='December-"+ Accyr +"') and (hd in ('BS','DS'))),0) as 'Sal12' FROM tbl_Employee_Attend ea where (month like '%"+ Accyr +"') and (LOcation_ID="+Location_id+") ";

            if (dtEmp.Rows.Count > 0)
            {
                rpt_qry = "Select  row_number() over(order by [NAME OF WORKMAN]) as 'SR NO',[NAME OF WORKMAN],[Designation]";
                for(int imon = 0; imon < 12; imon++)
                {
                    new_val = Convert.ToDouble(dtEmp.Rows[0]["sal" + (imon + 1)].ToString());
                    if (imon == 0)
                    {
                        old_val =Convert.ToDouble(dtEmp.Rows[0]["sal" + (imon + 1)].ToString());
                        tdays="WD" + (imon + 1);
                        rpt_qry = rpt_qry + ",WD" + (imon + 1) + " as '" + lstMon.Items[imon].ToString().Substring(0, 3) + "-" + Accyr + "'";
                    }
                    else if (old_val == new_val)
                    {
                        rpt_qry = rpt_qry + ",WD" + (imon + 1) +" as '"+ lstMon.Items[imon].ToString().Substring(0,3)+"-"+Accyr+"'";
                        tdays = tdays + "+WD" + (imon + 1);

                    }
                    else
                    {
                        rpt_qry = rpt_qry + ",(" + tdays + ") as 'Total Days', ((" + tdays + ")/20) as 'No of Days Work',(Sal" + (imon)+ "*((" + tdays + ")/20))/26 as 'Net Salary'";
                        if (fTotal.Trim() == "") { fTotal = "((Sal" + (imon) + "*((" + tdays + ")/20))/26)"; } else { fTotal=fTotal+"+((Sal" + (imon) + "*((" + tdays + ")/20))/26)"; }
                        old_val = Convert.ToDouble(dtEmp.Rows[0]["sal" + (imon + 1)].ToString());
                        rpt_qry = rpt_qry + ",WD" + (imon + 1) + " as '" + lstMon.Items[imon].ToString().Substring(0, 3) + "-" + Accyr + "'";
                        tdays = "WD" + (imon + 1);
                    }

                }
                if (fTotal.Trim() == "") { fTotal = "((Sal12*((" + tdays + ")/20))/26)"; } else { fTotal = fTotal + "+((Sal12*((" + tdays + ")/20))/26)"; }
                rpt_qry = rpt_qry + ",(" + tdays + ") as 'Total Days', ((" + tdays + ")/20) as 'No of Days Work',(Sal12*((" + tdays + ")/20))/26 as 'Net Salary',("+fTotal+") as 'TOTAL'";
                rpt_qry = rpt_qry + " from (" + old_qry + ")x order by [NAME OF WORKMAN]";

                dtCloned = clsDataAccess.RunQDTbl(rpt_qry);

            }
            else
            {
                MessageBox.Show("No Record for this location", "Bravo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                

            }

            if (dtCloned.Rows.Count > 0)
            {

                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                excel.Visible = true;
                int iCol = 0,tCol=0;

                iCol = dtCloned.Columns.Count;
                tCol = iCol;
                excel.Cells[1, 1] = CmbCompany.Text;
                Excel.Range range = excel.get_Range(excel.Cells[1, 1], excel.Cells[1, iCol]);
                range.Merge(true);
                range.Font.Bold = true;
                range.Font.Size = 12;

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Center;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                //range.Columns.AutoFit();
                ////range.Rows.AutoFit();


                excel.Cells[2, 1] = "Leave Wages Report for the location : "+ cmbLocation.Text + "    For the Year : "+ Accyr;

                range = excel.get_Range(excel.Cells[2, 1], excel.Cells[2, iCol]);
                range.Merge(true);
                range.Font.Bold = true;
                range.Font.Size = 10;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Center;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                iCol = 0;
                foreach (DataColumn c in dtCloned.Columns)
                {
                    iCol++;
                    excel.Cells[3, iCol] = c.ColumnName;
                }

                range = excel.get_Range(excel.Cells[3, 1], excel.Cells[3, tCol]);
                // range.Merge(true);
                range.Font.Bold = true;
                range.Font.Size = 9;
                range.WrapText = true;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// System.Web.UI.WebControls.HorizontalAlign.Center;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                int iRow = 3;
                foreach (DataRow r in dtCloned.Rows)
                {
                    iRow++;
                    iCol = 0;
                    foreach (DataColumn c in dtCloned.Columns)
                    {
                        try
                        {
                            iCol++;
                            if (iCol == 1)
                            {

                                range = excel.get_Range(excel.Cells[iRow, iCol],excel.Cells[iRow, iCol]);
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                excel.Cells[iRow, iCol] = r[c.ColumnName];
                                
                            }
                            else if (iCol == 2 || iCol == 3)
                            {
                                range = excel.get_Range(excel.Cells[iRow, iCol], excel.Cells[iRow, iCol]);
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                excel.Cells[iRow, iCol] = r[c.ColumnName];
                            }
                            else
                            {
                                range = excel.get_Range(excel.Cells[iRow, iCol], excel.Cells[iRow, iCol]);
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                range.NumberFormat = "0.00";
                                excel.Cells[iRow, iCol] = r[c.ColumnName];
                            }
                        }
                        catch
                        {

                        }
                    }

                }
                object missing = System.Reflection.Missing.Value;

               


                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[iRow + 1, tCol]);
                Excel.Borders borders = range.Borders;
                //Set the thick lines style.
                borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                borders.Weight = 2d;
                //range.WrapText = true;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                ((Excel._Worksheet)worksheet).Activate();
                worksheet.UsedRange.Select();

                worksheet.Columns.AutoFit();

                MessageBox.Show("Export To ExcelCompleted!", "Export");
            }


        }

        
    }
}
