using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data.SqlClient;

using Edpcom;
//using Excel;
namespace PayRollManagementSystem
{
    public partial class frmEmployeePFESIReport : EDPComponent.FormBaseRptMidium
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();

        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        string Item_Code = "", Tentry_code = "";
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Frm_Type = "";
        int Head_Cou = 0;
        string Locations = "";
        int Company_id = 0;

        string acc1 = "";
        string acc2 = "";
        string acc3 = "";
        string acc4 = "";
        string acc5 = "";
        string acc6 = "";

        string sqlstmnt="",criteria="";
        string tag = "",nonpfesi="0";

        string ac02, ac21, ac22, ac01, ac10, ac_pf, ac_02, ac_21, ac_22, ac_01, ac_10; 
        public frmEmployeePFESIReport(string type)
        {
            InitializeComponent();
            Frm_Type = type;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmEmployeeSalarySheet_Load(object sender, EventArgs e)
        {
            this.Text = "PF / ESI Report";
            vistaButton2.Visible = false;
            //dtpForm.Text = Convert.ToString(edpcom.CURRCO_SDT);
            //dtpto.Text = Convert.ToString(edpcom.CURRCO_EDT);
            //cheDescription.Checked = true;
            //raddetails.Checked = true;
            //radAlphabetically.Checked = true;
            //this.Text = "Stock Statement";
            //txttransaction.Text = "0";
            //txtitem.Text = "0";


            //dtpidate.Value = System.DateTime.Now;
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            //set session
            //if (System.DateTime.Now.Month >= 4)
            //{
            //    cmbYear.SelectedIndex = 0;
            //}
            //else
            //{
            //    cmbYear.SelectedIndex = 1;
            //}
            AttenDtTmPkr.Value = DateTime.Now.Date.AddMonths(-1);

            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }

            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                cmbcompany.Text = dta.Rows[0][0].ToString();

                Company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                cmbcompany.ReturnValue = Company_id.ToString();
                cmbcompany.Enabled = false;
                btnlog.Enabled = false;

            }
            else if (dta.Rows.Count > 1)
            {
                cmbcompany.PopUp();
                btnlog.Enabled = false;
            }
           // txtEmpContribut.Text = clsDataAccess.GetresultS("select top 1 amount from tbl_Employer_Contribution_Esi order by InsertionDate desc");//"4.75";
            try
            {

                nonpfesi = clsDataAccess.ReturnValue("select nonpfesi from CompanyLimiter");
            }
            catch
            {
                nonpfesi = "0";
            }

            CmbReport.SelectedIndex = 0;
        }
        //public void LoadDataTable()
        //{
        //    //dt.Columns.Clear();
        //    DataTable dt7 = clsDataAccess.RunQDTbl("select  e.RefBankAcountNo,e.RefDesignationName,e.RefBasic,e.RefDaysPresent,e.RefOT,e.RefTotalDays from tbl_Sal_Heads_Print e where e.Location_ID =" + Locations + "  ");
            
        //    DataTable data;
        //    data = new DataTable("columnname");
        //    DataColumn column_name = new DataColumn("Column_Name");
        //    DataColumn Ref_Column_slno = new DataColumn("Ref_Column_slno");
        //    data.Columns.Add(column_name);
        //    data.Columns.Add(Ref_Column_slno);
        //    if (dt7.Rows.Count > 0)
        //    {
        //        for (Int32 i = 0; i < dt7.Columns.Count; i++)
        //        {
        //            DataRow dataRow = data.NewRow();
        //            dataRow["Column_Name"] = dt7.Columns[i].ColumnName;
        //            dataRow["Ref_Column_slno"] = dt7.Rows[0][i].ToString();
        //            data.Rows.Add(dataRow);
        //        }

        //    }


        //    data.AcceptChanges();

        //    //DataTable dt8 = clsDataAccess.RunQDTbl("select  e.BankAcountNo,e.DesignationName,e.Basic,e.DaysPresent,e.OT,e.TotalDays  from tbl_Sal_Heads_Print e where e.Location_ID =" + Locations + "  ");
        //    DataTable dt8 = clsDataAccess.RunQDTbl("select  e.BankAcountNo as BankAcountNo,e.DesignationName as Rank,e.Basic as Salary,e.DaysPresent as W_Day,e.OT as O_T,e.TotalDays as Tot_Day  from tbl_Sal_Heads_Print e where e.Location_ID =" + Locations + "  ");

        //    //e.BankAcountNo as BankAcountNo,e.DesignationName as Rank,e.Basic as Salary,e.DaysPresent as W_Day,e.OT as O_T,e.TotalDays as Tot_Day
        //    DataTable data1;
        //    data1 = new DataTable("columnname1");

        //    DataColumn ColumnName = new DataColumn("ColumnName");
        //    DataColumn Check = new DataColumn("Check");

        //    data1.Columns.Add(ColumnName);
        //    data1.Columns.Add(Check);

        //    if (dt8.Rows.Count > 0)
        //    {
        //        for (Int32 i1 = 0; i1 < dt8.Columns.Count; i1++)
        //        {
        //            DataRow dataRow = data1.NewRow();
        //            dataRow["ColumnName"] = dt8.Columns[i1].ColumnName;
        //            dataRow["Check"] = dt8.Rows[0][i1];
        //            data1.Rows.Add(dataRow);
        //        }
        //    }
 
        //    data1.AcceptChanges();

        //    data.Columns.Add("ColumnName");
        //    data.Columns.Add("Check");
        //    for (int i = 0; i < data.Rows.Count; i++)
        //    {
        //        data.Rows[i]["ColumnName"] = data1.Rows[i]["ColumnName"];
        //        data.Rows[i]["Check"] = data1.Rows[i]["Check"];
        //    }

        //    data.Columns.Remove(data.Columns[0]);
        //    data.AcceptChanges();
        //    Head_Cou = 0;
        //    DataRow[] result = data.Select("Check = 'false'");
        //    DataRow[] result1 = data.Select("Check = 'True'");
        //    Head_Cou = result1.Length;
        //    Retrive_Data();
        
        //   for (int i = 0; i < result.Length; i++)
        //   {
        //       string y = result[i].ItemArray[1].ToString ();
        //       //y = dt.Columns[Convert.ToInt32(result[i].ItemArray[0])].ColumnName.ToString();
        //       dt.Columns.Remove(y);
        //   }

        //    dt.AcceptChanges();
         
        //}
        
        private void btnPreview_Click(object sender, EventArgs e)
        {
            int rw = 0;
            lstNonPfEsi.Items.Clear();
            if (rdb_Co.Checked == true)
            {
                Locations = "";
                string s = "";
                if (CmbReport.SelectedIndex == 0)
                {
                    //criteria = " WHERE ({ fn UCASE(d.SalaryHead_Short) }='PF') AND (e.Company_id='" + cmbcompany.ReturnValue + "')";
                             ////s = " select distinct l.Location_ID from tbl_Emp_Location AS l INNER JOIN tbl_Employee_Link_SalaryStructure AS ls ON l.Location_ID = ls.Location_ID INNER JOIN Companywiseid_Relation AS r ON l.Location_ID = r.Location_ID INNER JOIN tbl_Employee_Assign_SalStructure AS e ON ls.SalaryStructure_ID = e.SAL_STRUCT where (r.company_ID = '" + cmbcompany.ReturnValue + "')  AND (e.PF_PER != 1) ORDER BY l.Location_ID ";
                    //s = "SELECT DISTINCT e.Location_id FROM tbl_Employee_DeductionSalayHead AS d INNER JOIN tbl_Employee_Assign_SalStructure AS e ON d.SlNo = e.SAL_HEAD WHERE ({ fn UCASE(d.SalaryHead_Short) }='PF') AND (e.Company_id='" + cmbcompany.ReturnValue + "')";

                    s = " select distinct l.Location_ID from tbl_Emp_Location AS l INNER JOIN tbl_Employee_Link_SalaryStructure AS ls ON l.Location_ID = ls.Location_ID INNER JOIN Companywiseid_Relation AS r ON l.Location_ID = r.Location_ID INNER JOIN tbl_Employee_Assign_SalStructure AS e ON ls.SalaryStructure_ID = e.SAL_STRUCT where (r.company_ID = '" + cmbcompany.ReturnValue + "')  AND (e.PF_PER = 1) and (e.P_TYPE='D') and (isNUll(r.remit_pfesi,0)=0) ORDER BY l.Location_ID ";
                }
                else if (this.CmbReport.SelectedIndex == 1)
                {
                    criteria = " WHERE ({ fn UCASE(d.SalaryHead_Short) }='ESI') AND (e.Company_id='" + cmbcompany.ReturnValue + "')";
                    //s = " select distinct l.Location_ID from tbl_Emp_Location AS l INNER JOIN tbl_Employee_Link_SalaryStructure AS ls ON l.Location_ID = ls.Location_ID INNER JOIN Companywiseid_Relation AS r ON l.Location_ID = r.Location_ID INNER JOIN tbl_Employee_Assign_SalStructure AS e ON ls.SalaryStructure_ID = e.SAL_STRUCT where (r.company_ID = '" + cmbcompany.ReturnValue + "')  AND (e.ESI_PER = 1) ORDER BY l.Location_ID ";
                    s = " select distinct l.Location_ID from tbl_Emp_Location AS l INNER JOIN tbl_Employee_Link_SalaryStructure AS ls ON l.Location_ID = ls.Location_ID INNER JOIN Companywiseid_Relation AS r ON l.Location_ID = r.Location_ID INNER JOIN tbl_Employee_Assign_SalStructure AS e ON ls.SalaryStructure_ID = e.SAL_STRUCT where (r.company_ID = '" + cmbcompany.ReturnValue + "')  AND (e.ESI_PER = 1) and (e.P_TYPE='D') and (isNUll(r.remit_pfesi,0)=0) ORDER BY l.Location_ID ";
                    //s = "SELECT DISTINCT e.Location_id FROM tbl_Employee_DeductionSalayHead AS d INNER JOIN tbl_Employee_Assign_SalStructure AS e ON d.SlNo = e.SAL_HEAD WHERE ({ fn UCASE(d.SalaryHead_Short) }='ESI') AND (e.Company_id='" + cmbcompany.ReturnValue + "') and (e.P_TYPE='D')";
                }
                DataTable dt = clsDataAccess.RunQDTbl(s);
                for (int ind = 0; ind < dt.Rows.Count; ind++)
                {
                    if (Locations == "")
                        Locations = "'" + dt.Rows[ind][0].ToString() + "'";
                    else
                        Locations = Locations + ",'" + dt.Rows[ind][0].ToString() + "'";
                }
            }

            if (CmbReport.SelectedIndex == 0)
            {
                Retrive_Data(2);

                rw = lstNonPfEsi.Items.Count;
                if (dt.Rows.Count > 0)
                {
                   
                    PrintDetails(1);                  
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("No record Found");
                    return;
                }
            }
            else
            {
                acc1="";
                    acc2="";
                    acc3="";
                        acc4="";
                        acc5="";
                        acc6 = "";
                Retrive_DataESI();

                rw = lstNonPfEsi.Items.Count;
                if (dt.Rows.Count > 0)
                {
                    string sub = "", com = "", add = "";
                    com = cmbcompany.Text.ToString();
                    dt.Columns[7].ColumnName = "Employer";
                    add = clsDataAccess.GetresultS(" select CO_ADD +' '+CO_ADD1 from Company where GCODE = '" + cmbcompany.ReturnValue + "' ");
                    sub = "ESI Report for the month of " + AttenDtTmPkr.Value.ToString("MMMM, yyyy");
                    MidasReport.Form1 opening = new MidasReport.Form1();
                    opening.ESI(com, add, sub, dt, txtEmpContribut.Text+"%");

                    opening.ShowDialog();

                    //PrintDetails(1);


                    
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("No record Found");
                    return;
                }
            }
          
            dt.Dispose();
            dt.Clear();

            if (rw > 0)
            {
                vistaButton2.Visible = false;
               // createExcel(rw);
            }
            //LoadDataTable();          

           
        }
        public void createExcel(int rw)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 1;
            int iRow = 1;
            int ind=0;
            excel.Cells[iRow, 1] = "Check " + CmbReport.Text + " eligibility of the following Employees";
            iRow++;
            excel.Cells[iRow, 1] = "ID | EmployName | " + CmbReport.Text + " NO | Site";

            while (ind < rw)

            {
                excel.Cells[iRow + 1, 1] = lstNonPfEsi.Items[ind].ToString();
                ind++;
                iRow++;
            }

            object missing = System.Reflection.Missing.Value;

            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;


            ((Excel._Worksheet)worksheet).Activate();
            ((Excel._Worksheet)worksheet).Columns.AutoFit();
            ((Excel._Application)excel).Quit();


        }

        private void radGroupwise_CheckedChanged(object sender, EventArgs e)
        {
            //if (radGroupwise.Checked == true)
            //    btnItem.Text = "Select Item Group";
            //else
            //    btnItem.Text = "Select Item";
        }

        private void btnPrnt_Click(object sender, EventArgs e)
        {

            if (CmbReport.SelectedIndex == 0)
            {
                Retrive_Data(2);
                if (dt.Rows.Count > 0)
                {
                    PrintDetails(2);
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("No record Found");
                    return;
                }
            }
            else
            {
                Retrive_DataESI();
                if (dt.Rows.Count > 0)
                {
                    PrintDetails(2);
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("No record Found");
                    return;
                }
            }

            dt.Dispose();
            dt.Clear();


            //LoadDataTable();
           // PrintDetails(2);
        }

        public void PrintDetails(int flug)
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = dt.Copy();               
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    int s = i + 1;
                    dt.Columns[i].ColumnName = "col" + s;
                }
                 //dt1 = dt.Copy();
                MidasReport.Form1 MR = new MidasReport.Form1();
                DataTable dt_Sal_Pur_Reg_Final = dt;

                //string[] Report_Columns_Header = new string[6];

                //============================Report Header============================================
                string[] Report_Header = new string[4];
                string[] Report_Header_FontName = new string[4];
                string[] Report_Header_FontSize = new string[4];
                string[] Report_Header_FontStyle = new string[4];

                string TopVal = "1,0,0,0";
                string WidthVal = "1150,1150,1150,1150";
                string HeightVal = "6,5,4,5";// "226,226,226,226";
                string LeftVal = "0,0,0,0";
                string AlignVal = "M,M,M,M";

                Report_Header[0] =(this.cmbcompany.Text.ToUpper());//edpcom.CURRENT_COMPANY;

                if (CmbReport.SelectedIndex == 0)
                {
                    if (this.rdb_loc.Checked == true)
                        Report_Header[1] = " PF Report as per location ";//+ this.cmbLocation.Text;
                    else
                        Report_Header[1] = " PF Report for " + this.cmbcompany.Text;
                }
                else
                {
                    if (this.rdb_loc.Checked == true)
                    Report_Header[1] = " ESI Report as per location " + this.cmbLocation.Text;
                    else
                        Report_Header[1] = " ESI Report for " + this.cmbcompany.Text;
                }
                
                Report_Header[2] = "Session " + cmbYear.SelectedItem;//" ";
                Report_Header[3] = " For the month of  " + AttenDtTmPkr.Text;//+ Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString();

                //Report_Header[3] = "Form " + Convert.ToDateTime(dtpForm.Value).ToShortDateString() + " TO " + Convert.ToDateTime(dtpto.Value).ToShortDateString();
                

                //Report_Header[4] = ""; //"Periodical Stock Transaction";

                for (int i = 0; i <= Report_Header.Length - 1; i++)
                {
                    Report_Header_FontName[i] = "Arial";
                    Report_Header_FontSize[i] = "10";
                    Report_Header_FontStyle[i] = "B";
                }
                MR.opt = 3;
                MR.ReportHeaderArrenge_PE(Report_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Header_FontName, Report_Header_FontSize, Report_Header_FontStyle,"L");

                //=================================End===========================================

                //============================Report Page Header============================================
                string[] Report_Page_Header = new string[2];
                string[] Report_PageHeader_FontName = new string[2];
                string[] Report_PageHeader_FontSize = new string[2];
                string[] Report_PageHeader_FontStyle = new string[2];

                TopVal = "2,0";
                WidthVal = "200,200";
                //HeightVal = "6,6";// "226,226,226,226";
                HeightVal = "0,0";// "226,226,226,226";
                LeftVal = "2,2";
                AlignVal = "L,L";  //L for Left,R for Right,M for center

                Report_Page_Header[0] = "Salary Sheet for the location " + this.cmbLocation.Text;
                Report_Page_Header[1] = "Session " + cmbYear.SelectedItem + " For the month of  " + AttenDtTmPkr.Text;

                Report_PageHeader_FontName[0] = "Arial";
                Report_PageHeader_FontName[1] = "Arial";
                Report_PageHeader_FontSize[0] = "8";
                Report_PageHeader_FontSize[1] = "8";
                Report_PageHeader_FontStyle[0] = "B";
                Report_PageHeader_FontStyle[1] = "B";             
                MR.ReportPageHeaderArrenge_PE(Report_Page_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageHeader_FontName, Report_PageHeader_FontSize, Report_PageHeader_FontStyle,"L");
                //====================================End===========================================

                //============================Report Page Footer============================================
                string[] Report_PageFooter = new string[6];
                string[] Report_PageFooter_FontName = new string[6];
                string[] Report_PageFooter_FontSize = new string[6];
                string[] Report_PageFooter_FontStyle = new string[6];

                TopVal = "1,1,1,1,1,1";
                WidthVal = "250,250,250,250,250,250";
                HeightVal = "5,5,5,5,5,5";// "226,226,226,226";
                LeftVal = "2,2,2,2,2,2";
                AlignVal = "L,L,L,L,L,L";


                Report_PageFooter[0] = acc1;
                Report_PageFooter[1] = acc2;
                Report_PageFooter[2] = acc3;
                Report_PageFooter[3] = acc4;
                Report_PageFooter[4] = acc5;
                Report_PageFooter[5] = acc6;

                Report_PageFooter_FontName[0] = "Arial";
                Report_PageFooter_FontName[0] = "10";
                Report_PageFooter_FontStyle[0] = "B";

                Report_PageFooter_FontName[1] = "Arial";               
                Report_PageFooter_FontName[1] = "10";               
                Report_PageFooter_FontStyle[1] = "B";

                Report_PageFooter_FontName[2] = "Arial";
                Report_PageFooter_FontName[2] = "10";
                Report_PageFooter_FontStyle[2] = "B";

                Report_PageFooter_FontName[3] = "Arial";
                Report_PageFooter_FontName[3] = "10";
                Report_PageFooter_FontStyle[3] = "B";

                Report_PageFooter_FontName[4] = "Arial";
                Report_PageFooter_FontName[4] = "10";
                Report_PageFooter_FontStyle[4] = "B";

                Report_PageFooter_FontName[5] = "Arial";
                Report_PageFooter_FontName[5] = "10";
                Report_PageFooter_FontStyle[5] = "B";

               MR.ReportPageFooterArrenge_PE(Report_PageFooter, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageFooter_FontName, Report_PageFooter_FontName, Report_PageFooter_FontStyle,"L");
                ////====================================End===========================================
                
                ////============================Report Footer============================================
                string[] Report_Footer = new string[1];
                string[] Report_Footer_FontName = new string[1];
                string[] Report_Footer_FontSize = new string[1];
                string[] Report_Footer_FontStyle = new string[1];

                TopVal = "2";
                WidthVal = "155";
                HeightVal = "2";// "226,226,226,226";
                LeftVal = "2";
                AlignVal = "L";

                Report_Footer[0] = " ";
                //Report_Footer[1] = Convert.ToString(total_Qty);
                Report_Footer_FontName[0] = "Times New Roman";
                //Report_Footer_FontName[1] = "Times New Roman";
                Report_Footer_FontSize[0] = "12";
                //Report_Footer_FontSize[1] = "10";
                Report_Footer_FontStyle[0] = "B";
                //Report_Footer_FontStyle[1] = "B";
                MR.ReportFooterArrenge_PE(Report_Footer, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Footer_FontName, Report_Footer_FontSize, Report_Footer_FontStyle,"L");
                //====================================End===========================================

                //============================Details Columns Header============================================
                int Col_Count = dt1.Columns.Count;
                string[] Report_Columns_Header = new string[Col_Count];
                string[] Report_Columns_Header_FontName = new string[Col_Count];
                string[] Report_Columns_Header_FontSize = new string[Col_Count];
                string[] Report_Columns_Header_FontStyle = new string[Col_Count];



                if (CmbReport.SelectedIndex == 0)
                {
                    for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                    {
                        string ao = dt1.Columns[i].ToString();
                        //Report_Columns_Header[i] = ao+ "              ";

                        Report_Columns_Header[i] = ao + "                     ";
                    }
                }
                else
                {
                    for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                    {
                        string ao = dt1.Columns[i].ToString();
                        Report_Columns_Header[i] = ao + "                                       ";
                    }
                }

                for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                {
                    Report_Columns_Header_FontName[i] = "Times New Roman";
                    Report_Columns_Header_FontSize[i] = "8";
                    Report_Columns_Header_FontStyle[i] = "R";
                }

                int Head_width = 0;
                if (Head_Cou == 0)
                {
                    TopVal = "1,1,1";
                    WidthVal = "6,40,10";
                    HeightVal = "4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0";
                    AlignVal = "L,L,L";
                    Head_width = 274;

                }
                else if (Head_Cou == 1)
                {
                    TopVal = "1,1,1,1";
                    WidthVal = "6,40,10,14";
                    HeightVal = "4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0";
                    AlignVal = "L,L,L,L";
                    Head_width = 260;
                }
                else if (Head_Cou == 2)
                {
                    TopVal = "1,1,1,1,1";
                    WidthVal = "6,40,10,14,14";
                    HeightVal = "4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0";
                    AlignVal = "L,L,L,L,L";
                    Head_width = 246;
                }
                else if (Head_Cou == 3)
                {
                    TopVal = "1,1,1,1,1,1";
                    WidthVal = "6,40,10,14,14,14";
                    HeightVal = "4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L";
                    Head_width = 232;

                }
                else if (Head_Cou == 4)
                {
                    TopVal = "1,1,1,1,1,1,1";
                    WidthVal = "6,40,10,14,14,14,14";
                    HeightVal = "4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L";
                    Head_width = 218;
                }
                else if (Head_Cou == 5)
                {
                    TopVal = "1,1,1,1,1,1,1,1";
                    WidthVal = "6,37,10,14,14,14,14,10";
                    HeightVal = "4,4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L";
                    Head_width = 210;
                }
                else if (Head_Cou == 8)
                {
                    TopVal = "1,1,1,1,1,1,1,1,1";
                    WidthVal = "6,60,40,40,40,40,40,40,40";
                    HeightVal = "4,4,4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L,L";
                    Head_width = 310;
                }

                else if (Head_Cou == 9)
                {
                    TopVal = "1,1,1,1,1,1,1,1,1";
                    WidthVal = "6,55,35,40,40,40,45,45,40";
                    HeightVal = "4,4,4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L,L";
                    Head_width = 310;
                }

                else if (Head_Cou == 11)
                {
                    TopVal = "1,1,1,1,1,1,1,1,1,1,1";
                    WidthVal = "6,51,34,35,32,30,30,30,30,30,30";
                    HeightVal = "4,4,4,4,4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L,L,L,L";
                    Head_width = 310;
                }

                else if (Head_Cou == 12)
                {
                    TopVal = "1,1,1,1,1,1,1,1,1,1,1,1";
                    WidthVal = "6,51,34,40,26,26,26,26,26,26,26,26";
                    HeightVal = "4,4,4,4,4,4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L,L,L,L,L";
                    Head_width = 310;
                }


                else if (Head_Cou == 15)
                {
                    TopVal = "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1";
                    WidthVal = "6,55,25,25,25,25,25,25,25,25,25,25,25,25,25";
                    HeightVal = "4,4,4,4,4,4,4,4,4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L,L,L,L,L,L,L,L";
                    Head_width = 386;
                }

                    //int a = dt.Columns.Count;
                    //a = a - (Head_Cou + 3);
                    //int ab = Head_width / a;
                    //Head_Cou = Head_Cou + 3;
                    //for (int i = Head_Cou; i <= dt.Columns.Count - 1; i++)
                    //{
                    //    TopVal = TopVal + "," + 1;
                    //    WidthVal = WidthVal + "," +ab;
                    //    HeightVal = HeightVal + "," + 4;
                    //    LeftVal = LeftVal + "," + 0;
                    //    AlignVal = AlignVal + "," + "R";
                    //}


                    //int a = dt.Columns.Count;
                    //a = Head_Cou ;
                    //int ab = Head_width / a;
                    ////Head_Cou = Head_Cou ;
                    //for (int i = 0; i <= dt.Columns.Count - 1; i++)
                    //{
                    //    TopVal = TopVal + "," + 1;
                    //    WidthVal = WidthVal + "," + ab;
                    //    HeightVal = HeightVal + "," + 4;
                    //    LeftVal = LeftVal + "," + 0;
                    //    AlignVal = AlignVal + "," + "R";
                    //}      

                MR.DetailsColumnsHeaderArrenge_PE(Report_Columns_Header, Report_Columns_Header_FontName, Report_Columns_Header_FontSize, Report_Columns_Header_FontStyle,"L");
                MR.DetailsColumnsArrenge_PE(TopVal, WidthVal, HeightVal, LeftVal, AlignVal,"L");

                //===================================End====================================================
                if (flug == 1)
                {
                    MR.Graphic_Preview_PE(dt_Sal_Pur_Reg_Final, "L", "", "", "");
                    MR.Show();
                }
                else
                    MR.Graphic_Print_PE(dt_Sal_Pur_Reg_Final, "L", "", "", "");
            }
            catch { }
        }

        private void cmbYear_DropDown(object sender, EventArgs e)
        {
            //try
            //{
            //    clear_txt();
            //}
            //catch (Exception x) { }
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


        //private void cmbsalstruc_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string s = "";
        //        cmbsalstruc.Items.Clear();
        //        //////s = "select  l.Location_Name  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls where l.Location_ID = ls.Location_ID and Location_ID = '" + get_LocationID(cmbsalstruc.Text) + "'";
        //        s = " select l.Location_Name,l.Location_ID from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID = '" + get_CompID(cmbcompany.Text) + "'";
               
        //        Load_Data1(s, cmbsalstruc, -1);
        //        //clear_txt();
        //    }
        //    catch (Exception x) { }
        //}
        public int get_LocationID(string name)
        {
            
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select Location_ID from tbl_Emp_Location where Location_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public int get_CompID(string name)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            string s = " select GCODE  from Company where CO_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }


        private void cmbsalstruc_DropDownClosed(object sender, EventArgs e)
        {
            //salary_structure = 0;
            //hsh_rtype.Clear();
            //string Locations = "";
            //int day1 = 0, day2 = 0, month_no = 0, earning_count = 0;
            //double Tot_Leave = 0, calculateDay = 0;

            //if (cmbsalstruc.Text=="")
            //{
            //    ERPMessageBox.ERPMessage.Show("Location  must be entered");
            //    return ;
            //}
            //else
            //{
            //    Locations = Convert.ToString(get_LocationID(cmbsalstruc.Text));
            //}
        }
      
        private void Retrive_Data(int ix)
        {
            int pf_age_flag = 0;
            string Str_ErHead_basic="",chk="";
            DataTable ErHead_basic = clsDataAccess.RunQDTbl("select top 1  SalaryHead_Short from tbl_Employee_ErnSalaryHead");
            Str_ErHead_basic = ErHead_basic.Rows[0][0].ToString();
            string Str_PF_age = "";
            string Str_PF="";
            string Str_PF_SLNO = "";

            //DataTable data_PF = clsDataAccess.RunQDTbl("SELECT DISTINCT d.SalaryHead_Short, d.SlNo FROM tbl_Employee_DeductionSalayHead AS d INNER JOIN tbl_Employee_Assign_SalStructure AS e ON d.SlNo = e.SAL_HEAD WHERE (e.Location_ID in (" + Locations + ")) AND ({ fn UCASE(d.SalaryHead_Short) } = 'PF')");
            DataTable data_PF = clsDataAccess.RunQDTbl("select distinct d.SalaryHead_Short,d.SLNO from tbl_Employee_DeductionSalayHead d,tbl_Employee_Assign_SalStructure e,tbl_Employee_Link_SalaryStructure l where d.SlNo=e.SAL_HEAD and e.PF_PER=1 and e.SAL_STRUCT=l.SalaryStructure_ID and l.Location_ID IN (" + Locations + ")");
                ////"select distinct d.SalaryHead_Short,d.SLNO from tbl_Employee_DeductionSalayHead d,tbl_Employee_Assign_SalStructure e,tbl_Employee_Link_SalaryStructure l where d.SlNo=e.SAL_HEAD and e.PF_PER!=1 and e.SAL_STRUCT=l.SalaryStructure_ID and (l.Location_ID in (" + Locations +"))"); //get_LocationID(cmbsalstruc.Text)
            DataTable data_PFAge = clsDataAccess.RunQDTbl("select [PFAge] from [tbl_Employee_Config_Retirement] where SLNO =(select MAX(slno) from tbl_Employee_Config_Retirement)");//[Session]='"+ cmbYear.Text  +"'");
            if (data_PFAge.Rows.Count > 0)
            {
                Str_PF_age = data_PFAge.Rows[0][0].ToString();
            }
            else
            {
                Str_PF_age = "";
                ERPMessageBox.ERPMessage.Show("There is no assigned PF Age");
                return;
            }
            data_PF.DefaultView.RowFilter = "SalaryHead_Short = 'PF'";
            if (data_PF.DefaultView.Count>0)
           {
               Str_PF = data_PF.Rows[0][0].ToString();
               Str_PF_SLNO = data_PF.Rows[0][1].ToString();
           }
           else
           {
               Str_PF = "";
               ERPMessageBox.ERPMessage.Show("There is no PF Head in this Salary Structure");
               return;
           }

            Boolean flug_deduction = false;
            //string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
            if (chkNoPFESI_no.Checked == true || nonpfesi=="1")
            {
                // chk = " and (em.pf!='****' and em.pf!='') ";PassportNo
                chk = " and (em.PassportNo!='****' and em.PassportNo!='') ";
            }
            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            string sql_name = "",sql_Type="";
            if (rdb_Co.Checked==true){
                sql_name = "SELECT sm.Emp_Id as ID,' '+(CASE WHEN em.pf_name != '' THEN em.pf_name ELSE ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) END) as EmployName ,"+
          "(case when em.PF!='' then em.PF else '' end )'PF No', (case when em.PassportNo!='' then em.PassportNo else '' end ) as 'UAN No',"+
           "' ' +(case when em.PassportNo!='' then '(U) '+ em.PassportNo + CHAR(13) + CHAR(10)+ (case when em.PF!='' then '(P) '+ em.PF else '' end ) else (case when em.PF!='' then '(P) '+ em.PF else '' end ) end) as 'NO',"+
          "(SELECT Location_Name FROM tbl_Emp_Location AS el WHERE (Location_ID = sm.Location_id)) as 'Site',sm.Location_id  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where em.PF_Deduction!=1 " + chk + " and sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id IN (" + Locations + ")  and em.ID = sm.Emp_Id order by id,EmployName,site";
                //sql_Type = " Location_id in (" + Locations + ") ";
            }
            else{
                sql_name = "SELECT sm.Emp_Id as ID,' '+(CASE WHEN em.pf_name != '' THEN em.pf_name ELSE ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) END) as EmployName ,"+
           "(case when em.PF!='' then em.PF else '' end )'PF No', (case when em.PassportNo!='' then em.PassportNo else '' end ) as 'UAN No',"+
           "' ' +(case when em.PassportNo!='' then '(U) '+ em.PassportNo + CHAR(13) + CHAR(10)+ (case when em.PF!='' then '(P) '+ em.PF else '' end ) else (case when em.PF!='' then '(P) '+ em.PF else '' end ) end) as 'NO',"+
          "(SELECT Location_Name FROM tbl_Emp_Location AS el WHERE (Location_ID = sm.Location_id)) as 'Site',sm.Location_id  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where em.PF_Deduction!=1 " + chk + " and sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id in (" + Locations + ") and sm.Company_id='" + Company_id + "' and em.ID = sm.Emp_Id order by id,EmployName,site";
                //sql_Type = " Location_id in (" + Locations + ") ";
            }
            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,(select pf.PF_Code from Companywiseid_Relation pf where pf.location_id='" + get_LocationID(cmbsalstruc.Text) + "' ) as 'PF NO',sm.Emp_Id as ID,'" + cmbsalstruc.Text + "' as 'Site'  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and (em.PF_Deduction=0) and em.Company_id='" + get_CompID(cmbcompany.Text.ToString ().Trim()) + "' and em.ID = sm.Emp_Id");
            DataTable non_employ = clsDataAccess.RunQDTbl(sql_name);
          
            //lstNonPfEsi.DataBindings();
            for (int i = 0; i <= non_employ.Rows.Count -1; i++)
            {
                lstNonPfEsi.Items.Add(non_employ.Rows[i]["ID"].ToString() + " | " + non_employ.Rows[i]["EmployName"].ToString() + " | " + non_employ.Rows[i]["NO"].ToString() + " | " + non_employ.Rows[i]["Site"].ToString());
            }
            //,(sm.Calculate_day-10)Ncp, sm.DaysPresent as wday
            if (rdb_Co.Checked == true)
            {
                sql_name = "SELECT null as sl,' '+(CASE WHEN em.pf_name != '' THEN em.pf_name ELSE ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) END) as EmployName ,"+
                "(case when em.PF!='' then em.PF else '' end )'PF No', (case when em.PassportNo!='' then em.PassportNo else '' end ) as 'UAN No'," +
                    "' ' + (case when em.PassportNo!='' then '(U) '+ em.PassportNo + CHAR(13) + CHAR(10)+ (case when em.PF!='' then '(P) '+ em.PF else '' end ) else (case when em.PF!='' then '(P) '+ em.PF else '' end ) end) as 'UAN | PF No',sm.Emp_Id as ID,(SELECT Location_Name FROM tbl_Emp_Location AS el WHERE (Location_ID = sm.Location_id)) as 'Site', DATEDIFF(hour,em.DateOfBirth,GETDATE())/8766.0 AS AgeYearsDecimal,sm.desig_id,sm.Location_id,cast(sm.TotalSal as varchar(50)) TotalEarning  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where em.PF_Deduction=0 " + chk + " and sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id IN (" + Locations + ")  and em.ID = sm.Emp_Id order by id,EmployName,site";
                sql_Type = " Location_id in (" + Locations + ") ";
            }
            else
            {
                sql_name = "SELECT null as sl,' '+(CASE WHEN em.pf_name != '' THEN em.pf_name ELSE ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) END) as EmployName ,"+
          "(case when em.PF!='' then em.PF else '' end )'PF No', (case when em.PassportNo!='' then em.PassportNo else '' end ) as 'UAN No'," +
          "' ' + (case when em.PassportNo!='' then '(U) '+ em.PassportNo + CHAR(13) + CHAR(10)+ (case when em.PF!='' then '(P) '+ em.PF else '' end ) else (case when em.PF!='' then '(P) '+ em.PF else '' end ) end) as 'UAN | PF No',sm.Emp_Id as ID,(SELECT Location_Name FROM tbl_Emp_Location AS el WHERE (Location_ID = sm.Location_id)) as 'Site', DATEDIFF(hour,em.DateOfBirth,GETDATE())/8766.0 AS AgeYearsDecimal,sm.desig_id,sm.Location_id,cast(sm.TotalSal as varchar(50)) TotalEarning  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where em.PF_Deduction=0 " + chk + " and sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id in (" + Locations + ") and sm.Company_id='" + Company_id + "' and em.ID = sm.Emp_Id order by id,EmployName,site";
                sql_Type = " Location_id in (" + Locations + ") ";
            }
            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,(select pf.PF_Code from Companywiseid_Relation pf where pf.location_id='" + get_LocationID(cmbsalstruc.Text) + "' ) as 'PF NO',sm.Emp_Id as ID,'" + cmbsalstruc.Text + "' as 'Site'  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and (em.PF_Deduction=0) and em.Company_id='" + get_CompID(cmbcompany.Text.ToString ().Trim()) + "' and em.ID = sm.Emp_Id");
           DataTable  tot_employ = clsDataAccess.RunQDTbl(sql_name);
            if (tot_employ.Rows.Count > 0)
            {

                //DataTable contribution = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and TableName='tbl_Employer_Contribution' and Month ='" + month + "' and " + sql_Type + " order by Slno");
                DataTable contribution = clsDataAccess.RunQDTbl("select * from (SELECT EmpId,SalId,TableName,Slno,Amount,0 as Designation_id,location_id FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and TableName='tbl_Employer_Contribution' and Month ='" + month + "' and " + sql_Type + " union SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id,location_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + cmbYear.Text + "' and TableName='tbl_Employer_Contribution' and Month ='" + month + "' and " + sql_Type + ") main order by Designation_id,Slno");
                DataView dvcontri = new DataView(contribution);


                DataTable salary_details = clsDataAccess.RunQDTbl("select * from (SELECT EmpId,SalId,TableName,Slno,Amount,0 as Designation_id,location_id FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and " + sql_Type + " union SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id,location_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + cmbYear.Text + "' and Month ='" + month + "' and " + sql_Type + ") main order by Designation_id,Slno");
                DataView dv = new DataView(salary_details);
                int table_count = tot_employ.Columns.Count;

                tot_employ.Rows.Add();
                int dt_count = tot_employ.Rows.Count;
                tot_employ.Rows.Add();
                tot_employ.Rows.Add();

                int counter = 0;
                DataTable ec = new DataTable();

                if (Convert.ToInt32(clsDataAccess.ReturnValue("select isNull(chk_cont_type,0) from CompanyLimiter")) == 1)
                {
                    ec = clsDataAccess.RunQDTbl("select  top(1) ac02 ,ac21,ac22,ac01,ac10,(ac01+ac10)pf from tbl_loc_contribution where (locid in ("+Locations+"))");
                }
                else
                {
                    ec = clsDataAccess.RunQDTbl("select  top(1) ac02 ,ac21,ac22,ac01,ac10,(ac01+ac10)pf from tbl_employee_contribution_details where ecdt>='15/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "'  order by slno desc");

                }
                if (ec.Rows.Count == 0)
                {
                    ec = clsDataAccess.RunQDTbl("select  top(1) ac02 ,ac21,ac22,ac01,ac10,(ac01+ac10)pf from tbl_employee_contribution_details where ecdt<='15/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "'  order by slno desc");
                }
                ac02=ec.Rows[0]["ac02"].ToString();
                ac21 = ec.Rows[0]["ac21"].ToString(); ac22 = ec.Rows[0]["ac22"].ToString();

                ac01 = ec.Rows[0]["ac01"].ToString();
                ac10 = ec.Rows[0]["ac10"].ToString();
                string[] ap=ec.Rows[0]["pf"].ToString().Split('.');
                if (Convert.ToDouble(ap[1]) == 0)
                {
                    ac_pf = ap[0].ToString();
                }
                else
                {
                    ac_pf = ec.Rows[0]["pf"].ToString();
                }
                tot_employ.Columns.Add("Employer ("+ ac01 +"%)", typeof(string));
                tot_employ.Columns.Add("EPFBasic", typeof(string));
                tot_employ.Columns.Add("EPS("+ ac10 +"%)", typeof(string));

                tot_employ.Columns.Add("A/C01 "+ ac_pf +"%", typeof(string));
                tot_employ.Columns.Add("A/C01 "+ ac01 +"%", typeof(string));
                tot_employ.Columns.Add("A/C02 "+ ac02 +"%", typeof(string));
                tot_employ.Columns.Add("A/C10 "+ ac10 +"%", typeof(string));
                tot_employ.Columns.Add("A/C21 "+ac21+"%", typeof(string));
                tot_employ.Columns.Add("A/C22 "+ac22+"%", typeof(string));



                for (int i = 0; i <= tot_employ.Rows.Count - 4; i++)
                {
                    if (i == 179)
                    {
                       // MessageBox.Show("");

                    }
                    if (Convert.ToDouble(tot_employ.Rows[i]["AgeYearsDecimal"]) > Convert.ToDouble(Str_PF_age))
                    { 
                        pf_age_flag = 1; 
                    }
                    else 
                    { pf_age_flag = 0; }
                    //if (tot_employ.Rows[i]["ID"].ToString().Trim() == "CFS010114")
                    //{

                    //    MessageBox.Show("");
                    //}
                    dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["desig_id"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "'";

                    dvcontri.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["desig_id"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "'";

                    for (int j = 0; j <= dv.Count - 1; j++)
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                                tot_employ.Rows[dt_count][1] = "                Total :";

                            if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                            {
                                table_count = tot_employ.Columns.Count;
                                flug_deduction = true;
                                counter = j;
                            }

                            string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");

                            
                            if (Salary_Head == Str_PF)
                            {
                                try
                                {
                                    tot_employ.Columns.Add(Salary_Head, typeof(string));
                                }
                                catch { }
                                tot_employ.Rows[i][Salary_Head] = " " + string.Format("{0:F}",Math.Round(Convert.ToDouble(dv[j]["Amount"])));

                                tot_employ.Rows[dt_count - 1][Salary_Head] = "---------------";
                                tot_employ.Rows[dt_count][Salary_Head] = " " + string.Format("{0:F}",Math.Round(Convert.ToDouble(dv[j]["Amount"])));
                                tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                            }
                            else if (Salary_Head == Str_ErHead_basic)
                            {
                                try
                                {
                                    tot_employ.Columns.Add(Salary_Head, typeof(string));
                                }
                                catch { }
                                if (Salary_Head == "BS")
                                {
                                    tot_employ.Rows[i][Salary_Head] = clsDataAccess.GetresultS("SELECT pf_bs FROM tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"] + "') and (month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') and (lid='" + tot_employ.Rows[i]["location_id"] + "')");
                                }
                                else
                                {
                                    tot_employ.Rows[i][Salary_Head] = " " +
                                        string.Format("{0:F}", Math.Round(Convert.ToDouble(dv[j]["Amount"])));
                                }
                                if (Convert.ToDouble((tot_employ.Rows[i][Salary_Head])) > 15000)
                                {
                                    tot_employ.Rows[i]["EPFBasic"] = " " + string.Format("{0:F}",15000);
                                }
                                else
                                {
                                    tot_employ.Rows[i]["EPFBasic"] = " " + string.Format("{0:F}",Convert.ToDouble(tot_employ.Rows[i][Salary_Head]));
                                }

                                ////tot_employ.Rows[i]["EPS("+ ac10 +"%)"] = string.Format("{0:F}", Convert.ToDouble(System.Math.Round((((Convert.ToDouble(tot_employ.Rows[i][Salary_Head])) * ac10) / 100), 0)));

                                //tot_employ.Rows[i]["EPS("+ ac10 +"%)"] = string.Format("{0:F}", Convert.ToDouble(System.Math.Round((((Convert.ToDouble(tot_employ.Rows[i][Str_PF]) * 100) / ac_pf) * ac10), 0)));

                                //////tot_employ.Rows[dt_count - 1][Salary_Head] = "---------------";
                                //////tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                                //////tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                            }

                        }

                        else
                        {
                            string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                            if (Salary_Head == Str_PF)
                            {
                                tot_employ.Rows[i][Salary_Head] = " " + Math.Round(Convert.ToDouble(dv[j]["Amount"]));
                                tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(dv[j]["Amount"]))));
                            }
                            else if (Salary_Head == Str_ErHead_basic)
                            {
                                if (Salary_Head == "BS")
                                {
                                    dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id='" + tot_employ.Rows[i]["desig_id"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "' and  TableName='tbl_Employee_DeductionSalayHead' and SalId='1'";

                                    if (tot_employ.Rows[i]["desig_id"].ToString() != "0")
                                    {
                                        tot_employ.Rows[i][Salary_Head] = clsDataAccess.GetresultS("SELECT pf_bs FROM tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"] + "') and (month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') and (lid='" + tot_employ.Rows[i]["location_id"] + "') and (pf='" + dv[j]["Amount"] + "')");
                                    }
                                    else
                                    {
                                        tot_employ.Rows[i][Salary_Head] = clsDataAccess.GetresultS("SELECT pf_bs FROM tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"] + "') and (month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') and (lid='" + tot_employ.Rows[i]["location_id"] + "')");
                                    }
                                }
                                else
                                {
                                    tot_employ.Rows[i][Salary_Head] = " " + Math.Round(Convert.ToDouble(dv[j]["Amount"]));
                                }
                                if (Convert.ToDouble((tot_employ.Rows[i][Salary_Head])) > 15000)
                                {
                                    tot_employ.Rows[i]["EPFBasic"] = " " +  string.Format("{0:F}", 15000);
                                }
                                else
                                {
                                    tot_employ.Rows[i]["EPFBasic"] = " " + string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[i][Salary_Head]));
                                }

                                ////tot_employ.Rows[i]["EPS("+ ac10 +"%)"] = string.Format("{0:F}", Convert.ToDouble(System.Math.Round((((Convert.ToDouble(tot_employ.Rows[i][Salary_Head])) * ac10) / 100), 0)));
                                //tot_employ.Rows[i]["EPS("+ ac10 +"%)"] = string.Format("{0:F}", Convert.ToDouble(System.Math.Round((((Convert.ToDouble(tot_employ.Rows[i][Str_PF]) * 100) / ac_pf) * ac10), 0)));

                                //////tot_employ.Rows[dt_count - 1][Salary_Head] = "---------------";
                                //////tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                                //////tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                            }

                        }
                    }

                    tot_employ.Rows[dt_count - 1][Str_ErHead_basic] = "---------------";
                    tot_employ.Rows[dt_count - 1]["EPFBasic"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["EPS("+ ac10 +"%)"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["Employer ("+ ac01 +"%)"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["TotalEarning"] = "---------------";

                    //041215


                    tot_employ.Rows[dt_count - 1]["A/C01 "+ ac_pf +"%"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["A/C01 "+ ac01 +"%"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["A/C02 " + ac02 + "%"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["A/C10 "+ ac10 +"%"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["A/C21 " + ac21 + "%"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["A/C22 " + ac22 + "%"] = "---------------";


                    
                    //041215

                    if (Information.IsNumeric(tot_employ.Rows[dt_count][Str_ErHead_basic])== false )
                        tot_employ.Rows[dt_count][Str_ErHead_basic] = " " + 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPFBasic"]) == false)
                        tot_employ.Rows[dt_count]["EPFBasic"] = " " + 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPS("+ ac10 +"%)"]) == false)
                        tot_employ.Rows[dt_count]["EPS("+ ac10 +"%)"] = " " + 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["Employer ("+ ac01 +"%)"]) == false)
                        tot_employ.Rows[dt_count]["Employer ("+ ac01 +"%)"] = " " + 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["TotalEarning"]) == false)
                        tot_employ.Rows[dt_count]["TotalEarning"] = " " + 0;


                    //041215
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["A/C01 "+ ac_pf +"%"]) == false)
                        tot_employ.Rows[dt_count]["A/C01 "+ ac_pf +"%"] = " " + 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["A/C01 "+ ac01 +"%"]) == false)
                        tot_employ.Rows[dt_count]["A/C01 "+ ac01 +"%"] = " " + 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["A/C02 "+ ac02 +"%"]) == false)
                        tot_employ.Rows[dt_count]["A/C02 "+ ac02 +"%"] = " " + 0;

                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["A/C10 "+ ac10 +"%"]) == false)
                        tot_employ.Rows[dt_count]["A/C10 "+ ac10 +"%"] = " " + 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["A/C21 "+ ac21 +"%"]) == false)
                        tot_employ.Rows[dt_count]["A/C21 "+ ac21 +"%"] = " " + 0;

                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["A/C22 "+ ac22 +"%"]) == false)
                        tot_employ.Rows[dt_count]["A/C22 "+ ac22 +"%"] = " " + 0;



                    //041215

                    tot_employ.Rows[dt_count + 1][Str_ErHead_basic] = "========";
                    tot_employ.Rows[dt_count + 1]["EPFBasic"] = "========";
                    tot_employ.Rows[dt_count + 1]["EPS("+ ac10 +"%)"] = "========";
                    tot_employ.Rows[dt_count + 1]["Employer ("+ ac01 +"%)"] = "========";
                    tot_employ.Rows[dt_count + 1]["TotalEarning"] = "========";

                    //041215
                    tot_employ.Rows[dt_count + 1]["A/C01 "+ ac_pf +"%"] = "========";
                    tot_employ.Rows[dt_count + 1]["A/C01 "+ ac01 +"%"] = "========";
                    tot_employ.Rows[dt_count + 1]["A/C02 "+ ac02 +"%"] = "========";
                    tot_employ.Rows[dt_count + 1]["A/C10 "+ ac10 +"%"] = "========";
                    tot_employ.Rows[dt_count + 1]["A/C21 "+ ac21 +"%"] = "========";
                    tot_employ.Rows[dt_count + 1]["A/C22 "+ ac22 +"%"] = "========";

                    //041215

                    try
                    {
                        if (tot_employ.Rows[i][Str_PF].ToString().Trim() == "")
                        {

                            tot_employ.Rows[i][Str_PF] = Math.Round(Convert.ToDouble(clsDataAccess.ReturnValue("select pf from tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"].ToString() + "') and (month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') and (coid='" + Company_id + "') and (lid='" + tot_employ.Rows[i]["Location_ID"].ToString() + "')")));
                        }
                    }
                    catch
                    {
                        tot_employ.Columns.Add(Str_PF, typeof(string));
                        tot_employ.Rows[i][Str_PF] = Math.Round(Convert.ToDouble(clsDataAccess.ReturnValue("select pf from tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"].ToString() + "') and (month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') and (coid='" + Company_id + "') and (lid='" + tot_employ.Rows[i]["Location_ID"].ToString() + "')")));
                    }
                    try
                    {
                        tot_employ.Rows[i]["EPS("+ ac10 +"%)"] = " " + string.Format("{0:F}", Convert.ToDouble(System.Math.Round(((((Convert.ToDouble(tot_employ.Rows[i][Str_PF]) * 100) / Convert.ToDouble(ac_pf)) * Convert.ToDouble(ac10)) / 100), 0)));
                    }
                    catch {
                        //tot_employ.Rows[i][Str_PF] = " " + string.Format("{0:F}", 0);
                        tot_employ.Rows[i]["EPS("+ ac10 +"%)"] = " " + string.Format("{0:F}", 0); 
                       
                    }

                    tot_employ.Rows[dt_count][Str_ErHead_basic] = " " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) + Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]))));
                    tot_employ.Rows[dt_count]["EPFBasic"] = " " + string.Format("{0:F}",Math.Round(Convert.ToDouble( Convert.ToDouble(tot_employ.Rows[dt_count]["EPFBasic"]) + Convert.ToDouble(tot_employ.Rows[i]["EPFBasic"]))));
                    tot_employ.Rows[dt_count]["EPS("+ ac10 +"%)"] = " " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[dt_count]["EPS("+ ac10 +"%)"]) + Convert.ToDouble(tot_employ.Rows[i]["EPS("+ ac10 +"%)"]))));
                    tot_employ.Rows[i]["Employer ("+ ac01 +"%)"] = " " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[i]["PF"]) - Convert.ToDouble(tot_employ.Rows[i]["EPS("+ ac10 +"%)"]))));
                    tot_employ.Rows[dt_count]["Employer ("+ ac01 +"%)"] = " " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[dt_count]["Employer ("+ ac01 +"%)"]) + Convert.ToDouble(tot_employ.Rows[i]["Employer ("+ ac01 +"%)"]))));
                    tot_employ.Rows[dt_count]["TotalEarning"] = " " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[dt_count]["TotalEarning"]) + Convert.ToDouble(tot_employ.Rows[i]["TotalEarning"]))));

                    //041215
                    if (tot_employ.Rows[i]["UAN | PF NO"].ToString().Trim() == "")
                    {
                        tot_employ.Rows[i]["A/C01 "+ ac_pf +"%"] = " " + 0;
                       // tot_employ.Rows[dt_count]["A/C01 "+ ac_pf +"%"] = " " + 0;//string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) * Convert.ToDouble(12) / 100 + Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac_pf) / 100);

                        tot_employ.Rows[i]["A/C01 "+ ac01 +"%"] = " " + 0;
                        //tot_employ.Rows[dt_count]["A/C01 "+ ac01 +"%"] = " " + 0;//string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) * Convert.ToDouble("+ ac01 +")) / 100 + (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble("+ ac01 +")) / 100);

                        tot_employ.Rows[i]["A/C02 "+ ac02 +"%"] = " " + 0;
                      //  tot_employ.Rows[dt_count]["A/C02 "+ ac02 +"%"] = " " + 0;//string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count]["A/C02 "+ ac02 +"%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C02 "+ ac02 +"%"])));//Convert.ToDouble(dvcontri[0]["Amount"]))
                       
                        //tot_employ.Rows[dt_count]["A/C02 "+ ac02 +"%"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) * Convert.ToDouble(dvcontri[0]["Amount"])) / 100 + (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(dvcontri[0]["Amount"])) / 100);//Convert.ToDouble(dvcontri[0]["Amount"]))


                        tot_employ.Rows[i]["A/C10 "+ ac10 +"%"] = " " + 0;
                       // tot_employ.Rows[dt_count]["A/C10 "+ ac10 +"%"] = " " + 0;//string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) * Convert.ToDouble(ac10)) / 100 + (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac10)) / 100);

                        tot_employ.Rows[i]["A/C21 "+ ac21 +"%"] = " " + 0;
                        //tot_employ.Rows[dt_count]["A/C21 "+ ac21 +"%"] = " " + 0;//string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count]["A/C21 "+ ac21 +"%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C21 "+ ac21 +"%"])));

                        tot_employ.Rows[i]["A/C22 "+ ac22 +"%"] = " " + 0;
                      //  tot_employ.Rows[dt_count]["A/C22 "+ ac22 +"%"] = " " + 0;//string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count]["A/C22 "+ ac22 +"%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C22 "+ ac22 +"%"])));

                        //tot_employ.Rows[dt_count]["A/C22 "+ ac22 +"%"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) * Convert.ToDouble(dvcontri[2]["Amount"])) / 100 + (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(dvcontri[2]["Amount"])) / 100);

                    }
                    else
                    {
                        tot_employ.Rows[i]["A/C01 "+ ac_pf +"%"] = " " + string.Format("{0:F}", tot_employ.Rows[i]["PF"]);
                            //Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac_pf) / 100)));
                        //tot_employ.Rows[dt_count]["A/C01 "+ ac_pf +"%"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) * Convert.ToDouble(ac_pf) / 100 + Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac_pf) / 100);

                        tot_employ.Rows[dt_count]["A/C01 "+ ac_pf +"%"] = " " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[dt_count]["A/C01 "+ ac_pf +"%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C01 "+ ac_pf +"%"]))));
                       
                        
                        tot_employ.Rows[i]["A/C10 "+ ac10 +"%"] = " " + string.Format("{0:F}",Math.Round(Convert.ToDouble( (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac10)) / 100)));
                        tot_employ.Rows[i]["A/C01 "+ ac01 +"%"] = " " + string.Format("{0:F}",Math.Round(Convert.ToDouble( (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac01)) / 100)));
                        if (pf_age_flag > 0)
                        {
                            tot_employ.Rows[i]["A/C01 "+ ac01 +"%"] = " " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[i]["A/C10 "+ ac10 +"%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C01 "+ ac01 +"%"]))));
                            tot_employ.Rows[i]["A/C10 "+ ac10 +"%"] = " " + 0;
                            
                        }
                        
                            //tot_employ.Rows[dt_count]["A/C01 "+ ac01 +"%"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) * Convert.ToDouble(ac01)) / 100 + (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac01)) / 100);
                        tot_employ.Rows[dt_count]["A/C01 "+ ac01 +"%"] = " " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[dt_count]["A/C01 "+ ac01 +"%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C01 "+ ac01 +"%"]))));

                        try
                        {
                            tot_employ.Rows[i]["A/C02 " + ac02 + "%"] = Math.Round(Convert.ToDouble(clsDataAccess.ReturnValue("select (pf_bs*" + ac02 + "/100)'pf' from tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"].ToString() + "') and (month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') and (coid='" + Company_id + "') and (lid='" + tot_employ.Rows[i]["Location_ID"].ToString() + "')")));
                                //" " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(dvcontri[0]["Amount"]))));
                        }
                        catch
                        {
                            tot_employ.Rows[i]["A/C02 "+ ac02 +"%"] = " " + string.Format("{0:F}", Convert.ToDouble(0));

                        }
                        //tot_employ.Rows[i]["A/C02 "+ ac02 +"%"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble("+ ac02 +")) / 100);
                        tot_employ.Rows[dt_count]["A/C02 "+ ac02 +"%"] = " " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[dt_count]["A/C02 "+ ac02 +"%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C02 "+ ac02 +"%"]))));



                        tot_employ.Rows[dt_count]["A/C10 "+ ac10 +"%"] = " " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[dt_count]["A/C10 "+ ac10 +"%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C10 "+ ac10 +"%"]))));
                        try
                        {
                            tot_employ.Rows[i]["A/C21 " + ac21 + "%"] = Math.Round(Convert.ToDouble(clsDataAccess.ReturnValue("select (pf_bs*" + ac21 + "/100)'pf' from tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"].ToString() + "') and (month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') and (coid='" + Company_id + "') and (lid='" + tot_employ.Rows[i]["Location_ID"].ToString() + "')")));//" " + string.Format("{0:F}",Math.Round(Convert.ToDouble( Convert.ToDouble(dvcontri[1]["Amount"]))));
                        }
                        catch
                        {
                            tot_employ.Rows[i]["A/C21 "+ ac21 +"%"] = " " + string.Format("{0:F}", Convert.ToDouble(0));
                        }
                        //tot_employ.Rows[i]["A/C21 "+ ac21 +"%"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble("+ ac21 +")) / 100);
                        tot_employ.Rows[dt_count]["A/C21 "+ ac21 +"%"] = " " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(tot_employ.Rows[dt_count]["A/C21 "+ ac21 +"%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C21 "+ ac21 +"%"]))));
                        try
                        {
                            tot_employ.Rows[i]["A/C22 " + ac22 + "%"] = Math.Round(Convert.ToDouble(clsDataAccess.ReturnValue("select (pf_bs*" + ac22 + "/100)'pf' from tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"].ToString() + "') and (month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') and (coid='" + Company_id + "') and (lid='" + tot_employ.Rows[i]["Location_ID"].ToString() + "')"))); //" " + string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(dvcontri[2]["Amount"]))));
                        }
                        catch
                        {
                            tot_employ.Rows[i]["A/C22 "+ ac22 +"%"] = " " + string.Format("{0:F}", Convert.ToDouble(0));
                        }
                        //tot_employ.Rows[i]["A/C22 "+ ac22 +"%"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble("+ ac22 +")) / 100);
                        tot_employ.Rows[dt_count]["A/C22 "+ ac22 +"%"] = " " + string.Format("{0:F}",Math.Round(Convert.ToDouble( Convert.ToDouble(tot_employ.Rows[dt_count]["A/C22 "+ ac22 +"%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C22 "+ ac22 +"%"]))));


                    }
                    //041215

                    
                    tot_employ.Rows[i]["sl"] = i + 1;
                }

                tot_employ.Columns[Str_ErHead_basic].SetOrdinal(table_count - 1);
                tot_employ.Columns["TotalEarning"].SetOrdinal(tot_employ.Columns.Count - 1);
                tot_employ.Columns["EPFBasic"].SetOrdinal(tot_employ.Columns.Count - 1);
                tot_employ.Columns["EPS("+ ac10 +"%)"].SetOrdinal(tot_employ.Columns.Count - 1);

                if (chkCompac.Checked == true)
                {
                    int row = tot_employ.Rows.Count, rw = 0;
                    string id = "";
                    for (int ind = 0; ind < (row - 3); ind++)
                    {

                        if (tot_employ.Rows[ind]["id"].ToString().Trim() == id)
                        {
                            tot_employ.Rows[rw]["BS"] = Convert.ToDouble(tot_employ.Rows[rw]["BS"]) + Convert.ToDouble(tot_employ.Rows[ind]["BS"]);
                            tot_employ.Rows[rw]["TotalEarning"] = Convert.ToDouble(tot_employ.Rows[rw]["TotalEarning"]) + Convert.ToDouble(tot_employ.Rows[ind]["TotalEarning"]);
                            tot_employ.Rows[rw]["A/C01 "+ ac_pf +"%"] = Convert.ToDouble(tot_employ.Rows[rw]["A/C01 "+ ac_pf +"%"]) + Convert.ToDouble(tot_employ.Rows[ind]["A/C01 "+ ac_pf +"%"]);
                            tot_employ.Rows[rw]["A/C01 "+ ac01 +"%"] = Convert.ToDouble(tot_employ.Rows[rw]["A/C01 "+ ac01 +"%"]) + Convert.ToDouble(tot_employ.Rows[ind]["A/C01 "+ ac01 +"%"]);
                            tot_employ.Rows[rw]["A/C02 " + ac02 + "%"] = Convert.ToDouble(tot_employ.Rows[rw]["A/C02 " + ac02 + "%"]) + Convert.ToDouble(tot_employ.Rows[ind]["A/C02 " + ac02 + "%"]);
                            tot_employ.Rows[rw]["A/C10 "+ ac10 +"%"] = Convert.ToDouble(tot_employ.Rows[rw]["A/C10 "+ ac10 +"%"]) + Convert.ToDouble(tot_employ.Rows[ind]["A/C10 "+ ac10 +"%"]);
                            tot_employ.Rows[rw]["A/C21 " + ac21 + "%"] = Convert.ToDouble(tot_employ.Rows[rw]["A/C21 " + ac21 + "%"]) + Convert.ToDouble(tot_employ.Rows[ind]["A/C21 " + ac21 + "%"]);
                            tot_employ.Rows[rw]["A/C22 " + ac22 + "%"] = Convert.ToDouble(tot_employ.Rows[rw]["A/C22 " + ac22 + "%"]) + Convert.ToDouble(tot_employ.Rows[ind]["A/C22 " + ac22 + "%"]);

                            tot_employ.Rows.RemoveAt(ind);
                            ind = ind - 1;
                            row = tot_employ.Rows.Count;
                        }
                        else
                        {
                            id = tot_employ.Rows[ind]["id"].ToString().Trim();
                            rw = ind;
                        }

                    }
                }

                //if (chkCompac.Checked == false)
                //{
                    tot_employ.Columns.Remove("ID");
                //}
                tot_employ.Columns.Remove("desig_id");
                tot_employ.Columns.Remove("location_id");

                tot_employ.Columns[Str_ErHead_basic].SetOrdinal(4);
                tot_employ.Columns["TotalEarning"].SetOrdinal(5);
                tot_employ.Columns["EPFBasic"].SetOrdinal(6);
                tot_employ.Columns[Str_PF].SetOrdinal(7);
                tot_employ.Columns["EPS("+ ac10 +"%)"].SetOrdinal(8);
                tot_employ.Columns["Employer ("+ ac01 +"%)"].SetOrdinal(9);

                tot_employ.Columns[Str_PF].ColumnName = "Emp Cont."+ ac_pf +"%";

                tot_employ.Columns["A/C01 "+ ac_pf +"%"].SetOrdinal(10);
                tot_employ.Columns["A/C01 "+ ac01 +"%"].SetOrdinal(11);
                tot_employ.Columns["A/C02 "+ ac02 +"%"].SetOrdinal(12);
                tot_employ.Columns["A/C10 "+ ac10 +"%"].SetOrdinal(13);
                tot_employ.Columns["A/C21 "+ ac21 +"%"].SetOrdinal(14);
                tot_employ.Columns["A/C22 "+ ac22 +"%"].SetOrdinal(15);

                


                dt = tot_employ.Copy();

                if (ix == 1)
                {
                    dt.Columns.Remove("UAN | PF No");
                }
                else if (ix == 2)
                {
                    dt.Columns.Remove("PF No");
                    dt.Columns.Remove("UAN No");
                }

                dt.Columns.Remove("EPFBasic");
                dt.Columns.Remove("Emp Cont."+ ac_pf +"%");
                dt.Columns.Remove("EPS("+ ac10 +"%)");
                dt.Columns.Remove("Employer ("+ ac01 +"%)");
                dt.Columns.Remove("AgeYearsDecimal");
                
                //dt.Columns.Remove("Site");
                dt.AcceptChanges();
                Head_Cou = dt.Columns.Count;
                //int row = dt.Rows.Count,rw=0;
                //string id = "";
                //if (chkCompac.Checked == true)
                //{
                //    for (int ind = 0; ind < (row - 3); ind++)
                //    {

                //        if (dt.Rows[ind]["id"].ToString().Trim() == id)
                //        {
                //            dt.Rows[rw]["BS"] = Convert.ToDouble(dt.Rows[rw]["BS"]) + Convert.ToDouble(dt.Rows[ind]["BS"]);
                //            dt.Rows[rw]["TotalEarning"] = Convert.ToDouble(dt.Rows[rw]["TotalEarning"]) + Convert.ToDouble(dt.Rows[ind]["TotalEarning"]);
                //            dt.Rows[rw]["A/C01 "+ ac_pf +"%"] = Convert.ToDouble(dt.Rows[rw]["A/C01 "+ ac_pf +"%"]) + Convert.ToDouble(dt.Rows[ind]["A/C01 "+ ac_pf +"%"]);
                //            dt.Rows[rw]["A/C01 "+ ac01 +"%"] = Convert.ToDouble(dt.Rows[rw]["A/C01 "+ ac01 +"%"]) + Convert.ToDouble(dt.Rows[ind]["A/C01 "+ ac01 +"%"]);
                //            dt.Rows[rw]["A/C02 " + ac02 + "%"] = Convert.ToDouble(dt.Rows[rw]["A/C02 " + ac02 + "%"]) + Convert.ToDouble(dt.Rows[ind]["A/C02 " + ac02 + "%"]);
                //            dt.Rows[rw]["A/C10 "+ ac10 +"%"] = Convert.ToDouble(dt.Rows[rw]["A/C10 "+ ac10 +"%"]) + Convert.ToDouble(dt.Rows[ind]["A/C10 "+ ac10 +"%"]);
                //            dt.Rows[rw]["A/C21 " + ac21 + "%"] = Convert.ToDouble(dt.Rows[rw]["A/C21 " + ac21 + "%"]) + Convert.ToDouble(dt.Rows[ind]["A/C21 " + ac21 + "%"]);
                //            dt.Rows[rw]["A/C22 " + ac22 + "%"] = Convert.ToDouble(dt.Rows[rw]["A/C22 " + ac22 + "%"]) + Convert.ToDouble(dt.Rows[ind]["A/C22 " + ac22 + "%"]);

                //            dt.Rows.RemoveAt(ind);
                //            ind = ind - 1;
                //            row = dt.Rows.Count;
                //        }
                //        else
                //        {
                //            id = dt.Rows[ind]["id"].ToString().Trim();
                //            rw = ind;
                //        }

                //    }
                //    dt.Columns.Remove("ID");
                //    dt.Columns["Site"].SetOrdinal(3);
                //    tot_employ.Columns.Remove("ID");
                //    tot_employ.Columns["Site"].SetOrdinal(3);
                //}
                
                dt.Rows.Add();


                acc1 = "A/C 01 refers to Contributions towards PF made by Employee and Employer ("+ac_pf+" % of BASIC)" + " = "+"Rs. " + tot_employ.Rows[dt_count]["A/C01 "+ ac_pf +"%"];
                acc2 = "A/C 01 refers to Contributions towards PF made by Employee and Employer ("+ ac01 +"% of BASIC)" + " = " + "Rs. " + tot_employ.Rows[dt_count]["A/C01 "+ ac01 +"%"];
                acc3 = "A/C 02 refers to Admin Charges on A/C 01 ("+ ac02 +"% of Basic)" + " = " + "Rs. " + tot_employ.Rows[dt_count]["A/C02 "+ ac02 +"%"];
                acc4 = "A/C 10 refers to Contributions made towards EPS by the Emloyer ("+ ac10 +"% of BASIC)" + " = " + "Rs. " + tot_employ.Rows[dt_count]["A/C10 "+ ac10 +"%"];
                acc5 = "A/C 21 refers to Contributions made to EDLI by Employer ("+ ac21 +"% of BASIC)" + " = " + "Rs. " + tot_employ.Rows[dt_count]["A/C21 "+ ac21 +"%"];
                acc6 = "A/C 22 refers to Admin Charges on A/C 21 ("+ ac22 +"% of BASIC )" + " = " + "Rs. " + tot_employ.Rows[dt_count]["A/C22 "+ ac22 +"%"];


            }
        }

        private void CmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbReport.SelectedIndex == 1)
            {
                this.txtEmpContribut.Visible = true;
                this.label4.Visible = true;
            }
            else
            {
                this.txtEmpContribut.Visible = false ;
                this.label4.Visible = false;
            }

        }

        private void Retrive_DataESI()
        {

            //string Str_ErHead_basic = "";
            //DataTable ErHead_basic = clsDataAccess.RunQDTbl("select top 1  SalaryHead_Short from tbl_Employee_ErnSalaryHead");
            //Str_ErHead_basic = ErHead_basic.Rows[0][0].ToString();
            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            string Str_ESI = "",chk="";
            string Str_ESI_SLNO = "";
            DataTable data_ESI = clsDataAccess.RunQDTbl("SELECT DISTINCT d.SalaryHead_Short,d.SlNo FROM tbl_Employee_DeductionSalayHead AS d INNER JOIN tbl_Employee_Assign_SalStructure AS e ON d.SlNo = e.SAL_HEAD WHERE ({ fn UCASE(d.SalaryHead_Short) } = 'ESI') AND (e.Location_ID IN (" + Locations + "))");
                
            ////"select Distinct d.SalaryHead_Short,d.SLNO  from tbl_Employee_DeductionSalayHead d,tbl_Employee_Assign_SalStructure e,tbl_Employee_Link_SalaryStructure l where d.SlNo=e.SAL_HEAD and esi_per=1 and e.SAL_STRUCT=l.SalaryStructure_ID and l.Location_ID IN (" + Locations + ")");
            //Str_ESI = data_ESI.Rows[0][0].ToString();
            //Str_ESI_SLNO = data_ESI.Rows[0][1].ToString();
            if (chkNoPFESI_no.Checked == true || nonpfesi=="1")
            {
                chk = " and (em.ESIno!='****' and em.ESIno!='') ";
            }
            if (data_ESI.Rows.Count > 0)
            {
                Str_ESI = data_ESI.Rows[0][0].ToString();
                Str_ESI_SLNO = data_ESI.Rows[0][1].ToString();
            }
            else
            {
                Str_ESI = "";
                ERPMessageBox.ERPMessage.Show("There is no ESI Head in this Salary Structure");
                return;
            }

            DataTable non_employ = clsDataAccess.RunQDTbl("SELECT sm.Emp_Id as ID,(select (CASE WHEN em.esi_name != '' THEN em.esi_name ELSE ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) END) from tbl_Employee_Mast em where ID=sm.Emp_Id) as EmployeeName ,' ' + em.ESIno as 'NO', (SELECT Location_Name FROM tbl_Emp_Location AS el WHERE (Location_ID = sm.Location_id)) as 'Site',sm.Location_id  "+
            " FROM tbl_Employee_SalaryMast AS sm INNER JOIN tbl_Employee_Mast AS em ON sm.Emp_Id = em.ID  where (sm.Session='" + cmbYear.Text + "') " + chk + " and (sm.Month ='" + month + "') and (sm.Location_id IN (" + Locations + ")) and (em.ESI_Deduction<>0) and em.ID = sm.Emp_Id");
            lstNonPfEsi.Items.Clear();
            for (int i = 0; i <= non_employ.Rows.Count - 1; i++)
            {
                lstNonPfEsi.Items.Add(non_employ.Rows[i]["ID"].ToString() + " | " + non_employ.Rows[i]["EmployeeName"].ToString() + " | " + non_employ.Rows[i]["NO"].ToString() + " | " + non_employ.Rows[i]["Site"].ToString());
            }

            Boolean flug_deduction = false;
            


            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,(select pf.PF_Code from Companywiseid_Relation pf where pf.location_id='" + get_LocationID(cmbsalstruc.Text) + "' ) as 'PF NO','" + get_LocationID(cmbsalstruc.Text) + "' as 'Location' ,cast(sm.Basic as varchar(50)) as 'Basic',cast(case when sm.basic>15000 then 15000 else sm.basic end as varchar(50)) as 'EPFBasic',cast(round(((sm.Basic*8.33)/100),2) as varchar(50)) as 'EPS(8.33%)' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");

            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,(select pf.esi_code from Companywiseid_Relation pf where pf.location_id='" + get_LocationID(cmbsalstruc.Text) + "' ) as 'ESI NO',sm.Emp_Id as ID,'" + cmbsalstruc.Text + "' as 'Site',sm.DaysPresent as W_Day,cast(sm.TotalSal as varchar(50)) 'Gross Salary'  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");

            DataTable tot_employ = new DataTable();
            DataTable salary_details = new DataTable();
            if (chkCompac.Checked == true)
            {
                tot_employ = clsDataAccess.RunQDTbl("select null as [sl],(select (CASE WHEN em.esi_name != '' THEN em.esi_name ELSE ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) END) from tbl_Employee_Mast em where ID=x.ID)  as 'Employee Name',(select em.ESIno from tbl_Employee_Mast em where ID=x.ID) as 'ESI NO',ID,(SELECT Location_Name FROM tbl_Emp_Location AS el WHERE (Location_ID = x.Location_id)) as Location,SUM(W_Day)as W_Day,SUM(TotalEarning)as TotalEarning, SUM([Gross Salary]) as [Gross Salary],0 as desig_id,0 as Location_id   from " +
            "(SELECT distinct sm.Emp_Id as ID,em.Location_id,sm.DaysPresent as 'W_Day',sm.TotalSal as TotalEarning,"+
            "(case when sm.desig_id=0 then (SELECT sum(esi_bs) FROM tbl_employers_contribution WHERE (emp_id = sm.Emp_Id) AND (month = '" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') AND (lid = sm.Location_id)) else (SELECT sum(esi_bs) FROM tbl_employers_contribution WHERE (emp_id = sm.Emp_Id) AND (month = '" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') AND (lid = sm.Location_id) and (desgid=sm.desig_id)) end) AS 'Gross Salary' FROM tbl_Employee_SalaryMast AS sm INNER JOIN tbl_Employee_Mast em ON sm.Emp_Id = em.ID where (sm.Session='" + cmbYear.Text + "')" + chk + " and (Month ='" + month + "') and sm.Location_id IN (" + Locations + ") and (em.ESI_Deduction=0 or em.ESI_Deduction is Null))x group by ID,Location_id");

                salary_details = clsDataAccess.RunQDTbl("Select distinct EmpId,SalId,TableName,Slno, SUM(Amount)as Amount,0 as Designation_id,0 as Location_id from (SELECT EmpId,SalId,TableName,0 as Slno,Amount,0 as Designation_id,Location_id FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id IN (" + Locations + ") and salid='" + Str_ESI_SLNO + "' and TableName='tbl_Employee_DeductionSalayHead' union SELECT EmpId,SalId,TableName,0 as Slno,Amount,Designation_id,Location_id FROM [tbl_Employee_SalaryDet_MultiDesignation] where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id IN (" + Locations + ") and salid='" + Str_ESI_SLNO + "' and TableName='tbl_Employee_DeductionSalayHead') main group by EmpId,SalId,TableName,Slno");
            }
            else
            {
             tot_employ=   clsDataAccess.RunQDTbl("SELECT distinct null as sl,(CASE WHEN em.esi_name != '' THEN em.esi_name ELSE ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) END) as 'Employee Name' ," +
                 "' ' + em.ESIno as 'ESI NO',sm.Emp_Id as ID, (SELECT Location_Name FROM tbl_Emp_Location AS el WHERE (Location_ID = sm.Location_id)) as 'Location',sm.DaysPresent as 'W_Day',cast(sm.TotalSal as varchar(50)) TotalEarning," +
                 "(case when sm.desig_id=0 then (SELECT sum(esi_bs) FROM tbl_employers_contribution WHERE (emp_id = sm.Emp_Id) AND (month = '" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') AND (lid = sm.Location_id)) else (SELECT sum(esi_bs) FROM tbl_employers_contribution WHERE (emp_id = sm.Emp_Id) AND (month = '" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') AND (lid = sm.Location_id) and desgid=sm.desig_id) end) AS 'Gross Salary',sm.desig_id,sm.Location_id " +
                 " FROM tbl_Employee_SalaryMast AS sm INNER JOIN tbl_Employee_Mast em ON sm.Emp_Id = em.ID where (sm.Session='" + cmbYear.Text + "') " + chk + " and sm.Month ='" + month + "' and sm.Location_id IN (" + Locations + ")  and (em.ESI_Deduction=0 or em.ESI_Deduction is Null) order by Location,[Employee Name]");

                salary_details = clsDataAccess.RunQDTbl("Select * from (SELECT EmpId,SalId,TableName,Slno,Amount,0 as Designation_id,Location_id FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id IN (" + Locations + ") and salid='" + Str_ESI_SLNO + "' and TableName='tbl_Employee_DeductionSalayHead' union SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id,Location_id FROM [tbl_Employee_SalaryDet_MultiDesignation] where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id IN (" + Locations + ") and salid='" + Str_ESI_SLNO + "' and TableName='tbl_Employee_DeductionSalayHead') main order by Designation_id,Slno");
            }
             
            DataView dv = new DataView(salary_details);
            int table_count = tot_employ.Columns.Count;

            //tot_employ.Rows.Add();  ///

            tot_employ.Rows.Add();
            int dt_count = tot_employ.Rows.Count;
            tot_employ.Rows.Add();
            tot_employ.Rows.Add();

            int counter = 0;

            tot_employ.Columns.Add("Employer ("+ txtEmpContribut.Text +"%)", typeof(string));
            //tot_employ.Columns.Add("EPFBasic", typeof(string));
            //tot_employ.Columns.Add("EPS(8.33%)", typeof(string));
            string Salary_Head = "";

            for (int i = 0; i <= tot_employ.Rows.Count - 4; i++)
            {
                dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["desig_id"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "'";
                try
                {
                    Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[0]["TableName"] + " where SlNo ='" + dv[0]["SalId"] + "'  ");
                }
                catch {
                    Salary_Head = "ESI";
                
                }

                tot_employ.Rows[dt_count][4] = "                Total :";
                //====================================================
                ////if (Convert.ToDouble(dv[0]["Amount"]) == 0)
                ////{
                    //tot_employ.Rows[i][" Gross Salary"] = clsDataAccess.GetresultS("SELECT Amount FROM tbl_Employee_SalaryDet where EmpId='" + tot_employ.Rows[i]["ID"] + "' and Session='" + cmbYear.Text + "' and Month ='" + month + "' and (Location_id IN (" + Locations + ")) and TableName='tbl_Employee_ErnSalaryHead' AND (SalId = 1) order by Slno");

                    // string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");

                    //if (Salary_Head == "BS")
                    // {
                    //     tot_employ.Columns.Add(Salary_Head, typeof(string));
                    //     tot_employ.Rows[i][Salary_Head] = " " + dv[j]["Amount"];

                    //     if (Convert.ToDouble((tot_employ.Rows[i][Salary_Head])) > 15000)
                    //     {
                    //         tot_employ.Rows[i]["EPFBasic"] = " " + 15000;
                    //     }
                    //     else
                    //     {
                    //         tot_employ.Rows[i]["EPFBasic"] = " " + Convert.ToDouble(tot_employ.Rows[i][Salary_Head]);
                    //     }

                    // }
              // // }
                //======================================================
                if (i == 0)
                {
                    if (Salary_Head == Str_ESI)
                    {
                        tot_employ.Columns.Add(Salary_Head, typeof(string));
                        try
                        {
                            tot_employ.Rows[i][Salary_Head] = " " + dv[0]["Amount"];

                            tot_employ.Rows[dt_count - 1][Salary_Head] = "";
                            tot_employ.Rows[dt_count][Salary_Head] = " " + dv[0]["Amount"];
                            tot_employ.Rows[dt_count + 1][Salary_Head] = "";
                        }
                        catch
                        {
                            tot_employ.Rows[i][Salary_Head] = Math.Ceiling(Convert.ToDouble(clsDataAccess.ReturnValue("select esi from tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"].ToString() + "') and (month='" + (AttenDtTmPkr.Value.ToString("MMMM - yyyy")) + "') and (coid='" + Company_id + "') and (lid='" + tot_employ.Rows[i]["Location_ID"].ToString() + "')")));

                            tot_employ.Rows[dt_count - 1][Salary_Head] = "";
                            tot_employ.Rows[dt_count][Salary_Head] = " " + tot_employ.Rows[i][Salary_Head];
                            tot_employ.Rows[dt_count + 1][Salary_Head] = "";

                        }
                    }
                }
                else
                {
                    //string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[0]["TableName"] + " where SlNo ='" + dv[0]["SalId"] + "'  ");
                    if (Salary_Head == Str_ESI)
                    {
                        try
                        {
                        tot_employ.Rows[i][Salary_Head] = " " + dv[0]["Amount"];
                        
                        tot_employ.Rows[dt_count][Salary_Head] = " " + string.Format("{0:n}", Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(dv[0]["Amount"]));
                        }
                        catch
                        {
                            tot_employ.Rows[i][Salary_Head] = Math.Ceiling(Convert.ToDouble(clsDataAccess.ReturnValue("select esi from tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"].ToString() + "') and (month='" + (AttenDtTmPkr.Value.ToString("MMMM - yyyy")) + "') and (coid='" + Company_id + "') and (lid='" + tot_employ.Rows[i]["Location_ID"].ToString() + "')")));

                            tot_employ.Rows[dt_count - 1][Salary_Head] = "";
                            tot_employ.Rows[dt_count][Salary_Head] = " " + string.Format("{0:n}", Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(tot_employ.Rows[i][Salary_Head]));
                            tot_employ.Rows[dt_count + 1][Salary_Head] = "";

                        }
                    }
                }
                DataView d = new DataView(tot_employ);
                if (i == 0)
                {
                    tot_employ.Rows[i]["Gross Salary"] = " " + d[0]["Gross Salary"];
                    tot_employ.Rows[i]["TotalEarning"] = " " + d[0]["TotalEarning"];
                    //tot_employ.Rows[dt_count - 1]["Gross Salary"] = String.Empty;
                    tot_employ.Rows[dt_count]["Gross Salary"] =  d[0]["Gross Salary"];
                    tot_employ.Rows[dt_count]["TotalEarning"] = d[0]["TotalEarning"];
                    //tot_employ.Rows[dt_count + 1]["Gross Salary"] = "";
                }
                else
                {
                    tot_employ.Rows[i]["Gross Salary"] = d[i]["Gross Salary"];
                    tot_employ.Rows[i]["TotalEarning"] = d[i]["TotalEarning"];


                    tot_employ.Rows[dt_count]["Gross Salary"] = " " + string.Format("{0:n}", Convert.ToDouble(tot_employ.Rows[dt_count]["Gross Salary"]) + Convert.ToDouble(d[i]["Gross Salary"]));
                    tot_employ.Rows[dt_count]["TotalEarning"] = " " + string.Format("{0:n}", Convert.ToDouble(tot_employ.Rows[dt_count]["TotalEarning"]) + Convert.ToDouble(d[i]["TotalEarning"]));
                    
                }

                tot_employ.Rows[dt_count - 1]["Employer ("+ txtEmpContribut.Text +"%)"] = "";

                if (Information.IsNumeric(tot_employ.Rows[dt_count][Salary_Head]) == false)
                    tot_employ.Rows[dt_count][Salary_Head] = " " + 0;
                //if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPFBasic"]) == false)
                //    tot_employ.Rows[dt_count]["EPFBasic"] = 0;
                //if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPS(8.33%)"]) == false)
                //    tot_employ.Rows[dt_count]["EPS(8.33%)"] = 0;
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["Employer ("+ txtEmpContribut.Text +"%)"]) == false)

                    tot_employ.Rows[dt_count]["Employer ("+ txtEmpContribut.Text +"%)"] = 0;

                tot_employ.Rows[dt_count + 1][Salary_Head] = "";
                //tot_employ.Rows[dt_count + 1]["EPFBasic"] = "========";
                //tot_employ.Rows[dt_count + 1]["EPS(8.33%)"] = "========";
                tot_employ.Rows[dt_count + 1]["Employer ("+ txtEmpContribut.Text +"%)"] = "";

                tot_employ.Rows[i]["sl"] = i + 1;

                //tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(tot_employ.Rows[i][Salary_Head]));
                //tot_employ.Rows[dt_count]["EPFBasic"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPFBasic"]) + Convert.ToDouble(tot_employ.Rows[i]["EPFBasic"]));
                //tot_employ.Rows[dt_count]["EPS(8.33%)"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPS(8.33%)"]) + Convert.ToDouble(tot_employ.Rows[i]["EPS(8.33%)"]));

                if (txtEmpContribut.Text=="")
                {
                    txtEmpContribut.Text = "0";
                }
                //tot_employ.Rows[i]["Employer ("+ txtEmpContribut.Text +"%)"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[i]["Gross Salary"]) * Convert.ToDouble(txtEmpContribut.Text.Trim()) / 100));
                tot_employ.Rows[i]["Employer (" + txtEmpContribut.Text + "%)"] = " " + string.Format("{0:F}", System.Math.Ceiling(Convert.ToDouble(tot_employ.Rows[i]["Gross Salary"]) * Convert.ToDouble(txtEmpContribut.Text.Trim()) / 100));

                tot_employ.Rows[dt_count]["Employer ("+ txtEmpContribut.Text +"%)"] = " " + string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Employer ("+ txtEmpContribut.Text +"%)"]) + Convert.ToDouble(tot_employ.Rows[i]["Employer ("+ txtEmpContribut.Text +"%)"]));

            }
            if (Salary_Head != "")
            {
                 tot_employ.Columns[Salary_Head].SetOrdinal(table_count - 1);
                 tot_employ.Columns.Remove("ID");
                 tot_employ.Columns.Remove("desig_id");
                 //tot_employ.Columns.Remove("Location_id");

                 tot_employ.Columns[Salary_Head].SetOrdinal(6);
                 //tot_employ.Columns["EPFBasic"].SetOrdinal(5);
                 //tot_employ.Columns["PF"].SetOrdinal(6);
                 //tot_employ.Columns["EPS(8.33%)"].SetOrdinal(7);
                 tot_employ.Columns["Employer ("+ txtEmpContribut.Text +"%)"].SetOrdinal(7);

                 //tot_employ.Columns["PF"].ColumnName = "Employee Contribution (12%)";

                 dt = tot_employ.Copy();
                 dt.AcceptChanges();
                 Head_Cou = dt.Columns.Count;

            }

           
            
            

        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {
                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            }
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
               // cmbsalstruc.Items.Clear();
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);

            //data_retrive_Company();
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {

            if (rdb_Co.Checked == true)
            {
                Locations = "";
                string s = "";
                if (CmbReport.SelectedIndex == 0)
                {
                    //criteria = " WHERE ({ fn UCASE(d.SalaryHead_Short) }='PF') AND (e.Company_id='" + cmbcompany.ReturnValue + "')";
                    ////s = " select distinct l.Location_ID from tbl_Emp_Location AS l INNER JOIN tbl_Employee_Link_SalaryStructure AS ls ON l.Location_ID = ls.Location_ID INNER JOIN Companywiseid_Relation AS r ON l.Location_ID = r.Location_ID INNER JOIN tbl_Employee_Assign_SalStructure AS e ON ls.SalaryStructure_ID = e.SAL_STRUCT where (r.company_ID = '" + cmbcompany.ReturnValue + "')  AND (e.PF_PER != 1) ORDER BY l.Location_ID ";
                    //s = "SELECT DISTINCT e.Location_id FROM tbl_Employee_DeductionSalayHead AS d INNER JOIN tbl_Employee_Assign_SalStructure AS e ON d.SlNo = e.SAL_HEAD WHERE ({ fn UCASE(d.SalaryHead_Short) }='PF') AND (e.Company_id='" + cmbcompany.ReturnValue + "')";
                    s = " select distinct l.Location_ID from tbl_Emp_Location AS l INNER JOIN tbl_Employee_Link_SalaryStructure AS ls ON l.Location_ID = ls.Location_ID INNER JOIN Companywiseid_Relation AS r ON l.Location_ID = r.Location_ID INNER JOIN tbl_Employee_Assign_SalStructure AS e ON ls.SalaryStructure_ID = e.SAL_STRUCT where (r.company_ID = '" + cmbcompany.ReturnValue + "')  AND (e.PF_PER = 1) and (e.P_TYPE='D') and (isNUll(r.remit_pfesi,0)=0) ORDER BY l.Location_ID ";
                }
                else if (this.CmbReport.SelectedIndex == 1)
                {
                    criteria = " WHERE ({ fn UCASE(d.SalaryHead_Short) }='ESI') AND (e.Company_id='" + cmbcompany.ReturnValue + "')";
                    //s = " select distinct l.Location_ID from tbl_Emp_Location AS l INNER JOIN tbl_Employee_Link_SalaryStructure AS ls ON l.Location_ID = ls.Location_ID INNER JOIN Companywiseid_Relation AS r ON l.Location_ID = r.Location_ID INNER JOIN tbl_Employee_Assign_SalStructure AS e ON ls.SalaryStructure_ID = e.SAL_STRUCT where (r.company_ID = '" + cmbcompany.ReturnValue + "')  AND (e.ESI_PER != 1) ORDER BY l.Location_ID ";
                    s = "SELECT DISTINCT e.Location_id FROM tbl_Employee_DeductionSalayHead AS d INNER JOIN tbl_Employee_Assign_SalStructure AS e ON d.SlNo = e.SAL_HEAD WHERE ({ fn UCASE(d.SalaryHead_Short) }='ESI') AND (e.Company_id='" + cmbcompany.ReturnValue + "')";
                }
                DataTable dt1 = clsDataAccess.RunQDTbl(s);
                for (int ind = 0; ind < dt1.Rows.Count; ind++)
                {
                    if (Locations == "")
                        Locations = "'" + dt1.Rows[ind][0].ToString() + "'";
                    else
                        Locations = Locations + ",'" + dt1.Rows[ind][0].ToString() + "'";
                }
            }

            if (CmbReport.SelectedIndex == 0)
            {
                Retrive_Data(1);
                
            }
            else
            {
                Retrive_DataESI();
            }

            if (dt.Rows.Count > 1)
            {
                System.Data.DataTable dtCloned = dt.Clone();
                dtCloned.AcceptChanges();

                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }
                dtCloned.AcceptChanges();


                //excel

                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);

                excel.Visible = true;
                int iCol = 0;

                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;


                Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 1]);

               
                foreach (DataColumn c in dtCloned.Columns)
                {
                    iCol++;
                    if (c.ColumnName == "EmployName")
                    {
                        excel.Cells[1, iCol] = "EmployeeTitle";
                            iCol++;
                            excel.Cells[1, iCol] = "EmployeeName";
                    }
                    else if (c.ColumnName == "PF NO")
                    {
                        excel.Cells[1, iCol] = "PF Code";
                        iCol++;
                        excel.Cells[1, iCol] = "PF No";
                    }
                    else
                    {
                        excel.Cells[1, iCol] = c.ColumnName;
                    }
                    excel.Cells.Font.Bold = true;
                }
                int iRow = 0;
                string cell_val = "", c_val1, c_val2,c_tot="";
                
                foreach (DataRow r in dtCloned.Rows)
                {
                    iRow++;
                    iCol = 0;
                    foreach (DataColumn c in dtCloned.Columns)
                    {
                        excel.Cells.Font.Bold = false;
                        try
                        {
                            iCol++;
                            cell_val = Convert.ToString(r[c.ColumnName]);
                            if (c.ColumnName == "EmployName")
                            {
                                if (cell_val.Trim() == Convert.ToString("                Total :").Trim())
                                {
                                    c_tot = cell_val;
                                    iCol++;
                                    excel.Cells[iRow + 1, iCol] = cell_val;
                                    
                                }
                                else if (cell_val.Trim() == Convert.ToString("").Trim())
                                {
                                    iCol ++;
                                }
                                else
                                {
                                    String[] strArr_Name = new String[2];

                                    strArr_Name = cell_val.Split('.');

                                    c_val2 = cell_val.Substring(cell_val.IndexOf(".") + 1);
                                    c_val1 = cell_val.Substring(0, cell_val.IndexOf(".") + 1);
                                    excel.Cells[iRow + 1, iCol] = c_val1;
                                    iCol++;
                                    excel.Cells[iRow + 1, iCol] = c_val2;
                                }
                             }
                            else if (c.ColumnName == "PF NO")
                            {
                                if (c_tot.Trim() == Convert.ToString("                Total :").Trim())
                                {
                                    excel.Cells[iRow + 1, iCol] = cell_val;
                                    iCol++;
                                }
                                else if (cell_val.Trim() == Convert.ToString("").Trim())
                                {
                                    iCol++;
                                }
                                else
                                {
                                    c_val2 = cell_val.Substring(cell_val.LastIndexOf("/") + 1, 4);
                                    c_val1 = cell_val.Substring(0, cell_val.LastIndexOf("/") + 1);
                                    excel.Cells[iRow + 1, iCol] = c_val1;
                                    iCol++;
                                    excel.Cells[iRow + 1, iCol] = c_val2;
                                }
                            }
                            
                            else if (c.ColumnName.ToUpper() == "UAN NO")
                                {
                                    excel.Cells[iRow + 1, iCol] = cell_val;//r[c.ColumnName];
                                    range = worksheet.get_Range(worksheet.Cells[iRow + 1, iCol], worksheet.Cells[iRow + 1, iCol]);
                                    range.Cells.NumberFormat = "#";
                                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                }
                                else if (c.ColumnName.ToUpper() == "PF NO")
                                {
                                    excel.Cells[iRow + 1, iCol] = cell_val;//r[c.ColumnName];
                                    range = worksheet.get_Range(worksheet.Cells[iRow + 1, iCol], worksheet.Cells[iRow + 1, iCol]);
                                    range.NumberFormat = "#";
                                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                }
                                else
                                {
                                    excel.Cells[iRow + 1, iCol] = cell_val;
                                    range = worksheet.get_Range(worksheet.Cells[iRow + 1, iCol], worksheet.Cells[iRow + 1, iCol]);
                                    range.NumberFormat = "0";
                                }
                            
                        }
                        catch
                        {

                        }
                    }

                }
                object missing = System.Reflection.Missing.Value;

                //Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;


                ((Excel._Worksheet)worksheet).Activate();
                ((Excel._Worksheet)worksheet).Columns.AutoFit();
                ((Excel._Application)excel).Quit();

                MessageBox.Show("Export To ExcelCompleted!", "Export");
            }
            else
            {
                MessageBox.Show("There is no Record to export to excel!", "Export");
            }

            dt.Dispose();
            dt.Clear();

            // excel

        }

        private void btn_csv_Click(object sender, EventArgs e)
        {
            int month = (AttenDtTmPkr.Value.Month);
            int yr = AttenDtTmPkr.Value.Year;
            int opt = 0;
            if (chkCompac.Checked == true)
            {
                opt = 1;
            }
            string chk = "";
            if (rdb_Co.Checked == true)
            {
                Locations = "";
                string s = "";
                if (CmbReport.SelectedIndex == 0)
                    s = " select l.Location_ID from tbl_Emp_Location AS l INNER JOIN tbl_Employee_Link_SalaryStructure AS ls ON l.Location_ID = ls.Location_ID INNER JOIN Companywiseid_Relation AS r ON l.Location_ID = r.Location_ID INNER JOIN tbl_Employee_Assign_SalStructure AS e ON ls.SalaryStructure_ID = e.SAL_STRUCT where (r.company_ID = '" + cmbcompany.ReturnValue + "')  AND (e.PF_PER = 1) ORDER BY l.Location_ID ";
                else if (this.CmbReport.SelectedIndex == 1)
                    s = " select l.Location_ID from tbl_Emp_Location AS l INNER JOIN tbl_Employee_Link_SalaryStructure AS ls ON l.Location_ID = ls.Location_ID INNER JOIN Companywiseid_Relation AS r ON l.Location_ID = r.Location_ID INNER JOIN tbl_Employee_Assign_SalStructure AS e ON ls.SalaryStructure_ID = e.SAL_STRUCT where (r.company_ID = '" + cmbcompany.ReturnValue + "')  AND (e.ESI_PER = 1) ORDER BY l.Location_ID ";

                DataTable dt = clsDataAccess.RunQDTbl(s);
                for (int ind = 0; ind < dt.Rows.Count; ind++)
                {
                    if (Locations == "")
                        Locations = "'" + dt.Rows[ind][0].ToString() + "'";
                    else
                        Locations = Locations + ",'" + dt.Rows[ind][0].ToString() + "'";
                }
            }

            if (CmbReport.SelectedIndex == 0)
            {
                frmEmployeePfEsiCsv emp_pf_esi_csv = new frmEmployeePfEsiCsv();
                if (chkNoPFESI_no.Checked == true || nonpfesi=="1")
                {
                    // chk = " and (em.pf!='****' and em.pf!='') ";PassportNo
                    chk = " and (em.PassportNo!='****' and em.PassportNo!='') ";
                }
                emp_pf_esi_csv.lblMonth.Text = AttenDtTmPkr.Value.ToString("MMMM - yyyy");
                emp_pf_esi_csv.Retrive_Data(cmbYear.Text, this.cmbLocation.Text, month, Locations, Convert.ToString(Company_id), Convert.ToString(yr),chk,opt);
                emp_pf_esi_csv.ShowDialog();
            }
            else if (CmbReport.SelectedIndex == 1)
            {
                Double empCont= Convert.ToDouble(txtEmpContribut.Text);
                frmEmployeePfEsiExcel emp_pf_esi_exc = new frmEmployeePfEsiExcel();
                if (chkNoPFESI_no.Checked == true || nonpfesi=="1")
                {
                    chk = " and (em.ESIno!='****' and em.ESIno!='') ";
                }
                emp_pf_esi_exc.lblMonth.Text = AttenDtTmPkr.Value.ToString("MMMM - yyyy");
                emp_pf_esi_exc.Retrive_Data(cmbYear.Text, this.cmbLocation.Text, month, Locations, Company_id, yr, empCont,chk,opt);
                emp_pf_esi_exc.ShowDialog();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }

            txtEmpContribut.Text = clsDataAccess.GetresultS("select top 1 amount from tbl_Employer_Contribution_Esi where InsertionDate<='"+AttenDtTmPkr.Value.ToString("dd/MMMM/yyyy")+"'  order by InsertionDate desc");//"4.75";
        }

        //private void cmbsalstruc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbsalstruc.Text == "")
        //    {
        //        ERPMessageBox.ERPMessage.Show("Location  must be entered");
        //        return;
        //    }
        //    else
        //    {
        //        Locations = Convert.ToString(get_LocationID(cmbsalstruc.Text));
        //    }
        //}

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
           string s = " select l.Location_Name,l.Location_ID from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID = '" + get_CompID(cmbcompany.Text) + "'";

            DataTable dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
                //cmbLocation.Items.Clear();
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
            Locations = (this.cmbLocation.ReturnValue);
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
           
            string sqlstmnt = "";
            //if (tag == "SO")
            //{
            //    sqlstmnt = "select User_VCH,voucher,ficode from idata where VOUCHER in(select distinct Multi_Linkvch from idata where Reff_Data_T_entry='PN' and T_ENTRY in('n','PC','SO','LT','MI','NI','GR') and FICode='" + edpcom.CurrentFicode + "' and GCODE='" + edpcom.PCURRENT_GCODE + "' and Multi_Linkvch<>'' ) and T_ENTRY='PN' and FICode='" + edpcom.CurrentFicode + "' and GCODE='" + edpcom.PCURRENT_GCODE + "'  ";// and CAST(vch_date as DateTime) between '" + edpcom.getSqlDateStr(dtpfrom.Value) + "' and '" + edpcom.getSqlDateStr(dtpto.Value) + "'  ";
            //}
            //if (tag == "SI")
            //{
            //    sqlstmnt = "select User_VCH,voucher,ficode from idata where VOUCHER in(select distinct Multi_Linkvch from idata where Reff_Data_T_entry='PN' and T_ENTRY in('a','SC','SI','LT','FG','MR','NM') and FICode='" + edpcom.CurrentFicode + "' and GCODE='" + edpcom.PCURRENT_GCODE + "' and Multi_Linkvch<>'' ) and T_ENTRY='PN' and FICode='" + edpcom.CurrentFicode + "' and GCODE='" + edpcom.PCURRENT_GCODE + "'  ";// and CAST(vch_date as DateTime) between '" + edpcom.getSqlDateStr(dtpfrom.Value) + "' and '" + edpcom.getSqlDateStr(dtpto.Value) + "'  ";
            //}
           //// sqlstmnt = " select l.Location_Name,l.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName, ' ' AS ' ' from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and (company_ID='" + cmbcompany.ReturnValue + "')";

            sqlstmnt = "select l.Location_Name,l.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l ,Companywiseid_Relation r where  l.Location_ID =r.Location_ID and (company_ID='" + cmbcompany.ReturnValue + "') and (isNUll(r.remit_pfesi,0)=0)";
           EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Location", "Select Location", 0, "CMPN", 0);
            arr.Clear();
            arr = EDPCommon.arr_mod;
            lbllog.Items.Clear();
            if (arr.Count > 0)
            {
                getcode.Clear();
                arr = EDPCommon.arr_mod;
                getcode = EDPCommon.get_code;
                lbllog.Items.Clear();
                Item_Code = "";
               
                for (int i = 0; i <= (arr.Count - 1); i++)
                {
                    lbllog.Items.Add(arr[i].ToString());
                    Item_Code = Item_Code + getcode[i].ToString();
                    if (i != getcode.Count - 1)
                    {
                        Item_Code = Item_Code + ",";
                    }
                }
                Locations = Item_Code;
            }
        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {
           int rw = lstNonPfEsi.Items.Count;
            if (rw > 0)
            {
                createExcel(rw);
                lstNonPfEsi.Items.Clear();
                vistaButton2.Visible = false;
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdb_Co_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Co.Checked == true)
            {
                btnlog.Enabled = false;

            }

            else if (rdb_Co.Checked == false)
            {
                btnlog.Enabled = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

       


        //private void btnLedger_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (chebranch.Checked == true)
        //        {
        //            if (txtbranch.Text == "")
        //            {
        //                MessageBox.Show("select Branch Name.");
        //                return;
        //            }
        //        }
        //        sqlstmnt = "";
        //        if (SubGroup == 1)
        //        {
        //            sqlstmnt = "SELECT o.LDESC as Description,o.glcode,gr.SDESC as 'Main Group',g.ldesc as 'Sub Group',o.CURBAL as 'Current Balance' ,o.LALIAS as Code" +
        //                       " FROM glmst o,glmst g,grp gr where gr.MGROUP=o.MGROUP and gr.gcode='" + comm.PCURRENT_GCODE + "' and gr.ficode='" + comm.CurrentFicode + "'" +
        //                       " and g.sgroup=o.sgroup and g.mtype='S'   and (g.ACTV_FLG IS NULL OR g.ACTV_FLG='True')  and g.sgroup=14 and g.gcode='" + comm.PCURRENT_GCODE + "' and g.ficode='" + comm.CurrentFicode + "'" +
        //                       " and o.gcode='" + comm.PCURRENT_GCODE + "' and o.ficode='" + comm.CurrentFicode + "' and o.MTYPE='L'  and (o.ACTV_FLG IS NULL OR o.ACTV_FLG='True') order by o.ldesc";
        //        }
        //        else if (SubGroup == 2)
        //        {
        //            sqlstmnt = "SELECT o.LDESC as Description,o.glcode,gr.SDESC as 'Main Group',g.ldesc as 'Sub Group',o.CURBAL as 'Current Balance' ,o.LALIAS as Code" +
        //                       " FROM glmst o,glmst g,grp gr where gr.MGROUP=o.MGROUP and gr.gcode='" + comm.PCURRENT_GCODE + "' and gr.ficode='" + comm.CurrentFicode + "' and (GR.ACTV_FLG IS NULL OR GR.ACTV_FLG='True')and o.curbal<>0  " +
        //                       " and g.sgroup=o.sgroup and g.mtype='S'   and (g.ACTV_FLG IS NULL OR g.ACTV_FLG='True')  and (g.sgroup=4 or g.sgroup=15) and g.gcode='" + comm.PCURRENT_GCODE + "' and g.ficode='" + comm.CurrentFicode + "'" +
        //                       " and o.gcode='" + comm.PCURRENT_GCODE + "' and o.ficode='" + comm.CurrentFicode + "' and o.MTYPE='L'  and (o.ACTV_FLG IS NULL OR o.ACTV_FLG='True') order by o.ldesc";
        //        }
        //        else if (SubGroup == 3)
        //        {
        //            sqlstmnt = "SELECT o.LDESC as Description,o.glcode,gr.SDESC as 'Main Group',g.ldesc as 'Sub Group',o.CURBAL as 'Current Balance' ,o.LALIAS as Code" +
        //                       " FROM glmst o,glmst g,grp gr where gr.MGROUP=o.MGROUP and gr.gcode='" + comm.PCURRENT_GCODE + "' and gr.ficode='" + comm.CurrentFicode + "' and (GR.ACTV_FLG IS NULL OR GR.ACTV_FLG='True')  " +
        //                       " and g.sgroup=o.sgroup and g.mtype='S' and (g.ACTV_FLG IS NULL OR g.ACTV_FLG='True')  and g.sgroup<>0 and g.sgroup<>4 and g.sgroup<>14 and g.sgroup<>15 and g.gcode='" + comm.PCURRENT_GCODE + "' and g.ficode='" + comm.CurrentFicode + "'" +
        //                       " and o.gcode='" + comm.PCURRENT_GCODE + "' and o.ficode='" + comm.CurrentFicode + "' and o.MTYPE='L' and (o.ACTV_FLG IS NULL OR o.ACTV_FLG='True')  " + //and o.curbal<>0  (S Dutta Comes nill ledger Blance 10.07.13)
        //                       " union all select gl.LDESC as Description,gl.glcode,gr1.SDESC as 'Main Group',null Sub,gl.CURBAL as 'Current Balance' ,gl.LALIAS as Code" +
        //                       " From glmst gl,grp gr1 where gr1.MGROUP=gl.MGROUP and gr1.gcode=gl.gcode and gr1.ficode=gl.ficode and (gr1.ACTV_FLG IS NULL OR gr1.ACTV_FLG='True')  and gl.GCODE='" + comm.PCURRENT_GCODE + "'" +
        //                       " and gl.FICODE='" + comm.CurrentFicode + "' and gl.MTYPE='L'  and (GL.ACTV_FLG IS NULL OR GL.ACTV_FLG='True') and  gl.sgroup =0 order by o.ldesc";  //and gl.curbal<>0 (S Dutta Comes nill ledger Blance 10.07.13)
        //        }
        //        EDPCommon.MLOV_EDP(sqlstmnt, "Tag Ledgers", "Select Ledger", "List of Ledger", 0, "CMPN", 0);

        //        arr.Clear();
        //        arr = EDPCommon.arr_mod;
        //        if (arr.Count > 0)
        //        {
        //            getcode.Clear();
        //            arr = EDPCommon.arr_mod;
        //            getcode = EDPCommon.get_code;
        //            lbledger.Items.Clear();
        //            GLCODE = null;
        //            for (int i = 0; i <= (arr.Count - 1); i++)
        //            {
        //                lbledger.Items.Add(arr[i].ToString());
        //                GLCODE = GLCODE + getcode[i].ToString();
        //                if (i != getcode.Count - 1)
        //                {
        //                    GLCODE = GLCODE + ",";
        //                }
        //            }
        //        }
        //        //   PUR_SAL_DTLS();
        //    }

        //    catch { }
        //}



    }

}