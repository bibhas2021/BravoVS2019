using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class PF_ESI_Eligibility : Form
    {
        int code;
        DataTable DT1, DT2;
        int Head_Cou = 0;
        string Odet = "", Oamt = "", Agent = "";
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        public PF_ESI_Eligibility()
        {
            InitializeComponent();
        }

        private void cmbCompany_DropDown(object sender, EventArgs e)
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
                cmbCompany.LookUpTable = dt;
                cmbCompany.ReturnIndex = 1;
            }
        }

        private void cmbCompany_DropDown(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            code = Convert.ToInt32(cmbCompany.ReturnValue);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (chkALL.Checked == true)
            {
                String Header = "PF & ESI ELIGIBILITY";
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + code + "'");
                String str = "SELECT 'ID' AS Column1,'EMPLOYEE_NAME' AS Column2,'PF ELIGIBILITY' AS Column3,'ESI ELIGIBILITY' AS Column4";
                String strALL = "SELECT ID AS Column1,(Title+' '+FirstName+' '+MiddleName+' '+LastName) AS Column2,(case when PF_Deduction='0'then 'YES'else 'NO'end) AS Column3,(case when ESI_Deduction=0 or ESI_Deduction is null then  'YES'else 'NO'end) AS Column4 FROM tbl_Employee_Mast WHERE Company_id = '" + code + "'";            
            
                DT2 = clsDataAccess.RunQDTbl(str); 
                DT1 = clsDataAccess.RunQDTbl(strALL);
                //DT2.Merge(DT1, true, MissingSchemaAction.Ignore);
            
                MidasReport.Form1 join = new MidasReport.Form1();
                join.PfEsiEligibility(cmbCompany.Text, CO_ADD, Header, DT1, "ID", "Employee Name", "PF ELIGIBILITY","ESI ELIGIBILITY","");
                join.Show();
               // cmbCompany.ResetText();
            }

            else if (chkACNames.Checked == true)
            {
                String Header = "ACCOUNT HOLDER NAMES";
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + code + "'");
                String str = "SELECT 'ID' AS Column1,'EMPLOYEE_NAME' AS Column2,'PF A/C NAME' AS Column3,'ESI A/C NAME' AS Column4,'BANK A/C NAME' AS Column5";
                String strAC = "SELECT ID AS Column1,(Title+' '+FirstName+' '+MiddleName+' '+LastName) AS Column2,pf_name AS Column3,esi_name AS Column4,bankAc_name AS Column5 FROM tbl_Employee_Mast WHERE Company_id = '" + code + "'";

                if (rdbMatched.Checked == true)
                {
                    DT1 = clsDataAccess.RunQDTbl(strAC + " AND pf_name = esi_name AND pf_name = bankAc_name AND esi_name = bankAc_name order by ID");
                }
                else if (rdbNotMatched.Checked == true)
                {
                    DT1 = clsDataAccess.RunQDTbl(strAC + " AND (pf_name != esi_name OR pf_name != bankAc_name OR esi_name != bankAc_name OR pf_name IS NULL OR esi_name IS NULL OR bankAc_name IS NULL) order by ID");
                }

                DT2 = clsDataAccess.RunQDTbl(str);
                //DT1 = clsDataAccess.RunQDTbl(strAC);
                //DT2.Merge(DT1, true, MissingSchemaAction.Ignore);

                MidasReport.Form1 join = new MidasReport.Form1();
                join.PfEsiEligibility(cmbCompany.Text, CO_ADD, Header, DT1, "ID", "EMPLOYEE NAME", "PF A/C NAME", "ESI A/C NAME", "BANK A/C NAME");
                join.Show();
                //cmbCompany.ResetText();
            }
            else
            {
                MessageBox.Show("Please select any one of the checkboxes");
                return;
            }
        }

        private void PF_ESI_Eligibility_Load(object sender, EventArgs e)
        {
            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbCompany.Text = Convert.ToString(dt_co.Rows[0][0]);

                code = Convert.ToInt32(dt_co.Rows[0][1]);
                cmbCompany.ReturnValue = code.ToString();
                cmbCompany.Enabled = false;
                

            }
            else if (dt_co.Rows.Count > 1)
            {
                cmbCompany.PopUp();
                

            }
            rdbMatched.Visible = false;
            rdbNotMatched.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkACNames_CheckedChanged(object sender, EventArgs e)
        {
            rdbMatched.Visible = true;
            rdbNotMatched.Visible = true;
            chkALL.Checked = false;
            rdbMatched.Checked = true;
        }

        private void chkALL_CheckedChanged(object sender, EventArgs e)
        {
            chkACNames.Checked = false;
            rdbMatched.Visible = false;
            rdbNotMatched.Visible = false;

        }

        private void btnPrnt_Click(object sender, EventArgs e)
        {
            if (chkALL.Checked == true)
            {
                String Header = "PF & ESI ELIGIBILITY";
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + code + "'");
                String str = "SELECT 'ID' AS Column1,'EMPLOYEE_NAME' AS Column2,'PF ELIGIBILITY' AS Column3,'ESI ELIGIBILITY' AS Column4";
                String strALL = "SELECT ID AS Column1,(Title+' '+FirstName+' '+MiddleName+' '+LastName) AS Column2,(case when PF_Deduction='0'then 'YES'else 'NO'end) AS Column3,(case when ESI_Deduction=0 or ESI_Deduction is null then  'YES'else 'NO'end) AS Column4 FROM tbl_Employee_Mast WHERE Company_id = '" + code + "'";

                DT2 = clsDataAccess.RunQDTbl(str);
                DT1 = clsDataAccess.RunQDTbl(strALL);
               

                MidasReport.Form1 join = new MidasReport.Form1();
                join.PfEsiEligibility_print(cmbCompany.Text, CO_ADD, Header, DT1, "ID", "Employee Name", "PF ELIGIBILITY", "ESI ELIGIBILITY", "");
               // join.Show();
              
            }

            else if (chkACNames.Checked == true)
            {
                String Header = "ACCOUNT HOLDER NAMES";
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + code + "'");
                String str = "SELECT 'ID' AS Column1,'EMPLOYEE_NAME' AS Column2,'PF A/C NAME' AS Column3,'ESI A/C NAME' AS Column4,'BANK A/C NAME' AS Column5";
                String strAC = "SELECT ID AS Column1,(Title+' '+FirstName+' '+MiddleName+' '+LastName) AS Column2,pf_name AS Column3,esi_name AS Column4,bankAc_name AS Column5 FROM tbl_Employee_Mast WHERE Company_id = '" + code + "'";

                if (rdbMatched.Checked == true)
                {
                    DT1 = clsDataAccess.RunQDTbl(strAC + " AND pf_name = esi_name AND pf_name = bankAc_name AND esi_name = bankAc_name order by ID");
                }
                else if (rdbNotMatched.Checked == true)
                {
                    DT1 = clsDataAccess.RunQDTbl(strAC + " AND (pf_name != esi_name OR pf_name != bankAc_name OR esi_name != bankAc_name OR pf_name IS NULL OR esi_name IS NULL OR bankAc_name IS NULL) order by ID");
                }

                DT2 = clsDataAccess.RunQDTbl(str);
                //DT1 = clsDataAccess.RunQDTbl(strAC);
                

                MidasReport.Form1 join = new MidasReport.Form1();
                join.PfEsiEligibility_print(cmbCompany.Text, CO_ADD, Header, DT1, "ID", "EMPLOYEE NAME", "PF A/C NAME", "ESI A/C NAME", "BANK A/C NAME");
               // join.Show();
              
            }
            else
            {
                MessageBox.Show("Please select any one of the checkboxes");
                return;
            }
            
        }

        //int CAR_L = 0;
        //public void PrintDetails(int flug, string Header, string CO_ADD)
        //{
        //    try
        //    {
        //        DataTable dt1 = new DataTable();
        //        dt1 = DT1.Copy();
        //        for (int i = 0; i <= DT1.Columns.Count - 1; i++)
        //        {
        //            int s = i + 1;
        //            DT1.Columns[i].ColumnName = "col" + s;
        //        }
        //        //dt1 = dt.Copy();
        //        MidasReport.Form1 MR = new MidasReport.Form1();
        //        DataTable dt_Sal_Pur_Reg_Final = DT1;

        //        //string[] Report_Columns_Header = new string[6];

        //        //============================Report Header============================================
        //        string[] Report_Header = new string[4];
        //        string[] Report_Header_FontName = new string[4];
        //        string[] Report_Header_FontSize = new string[4];
        //        string[] Report_Header_FontStyle = new string[4];

        //        string TopVal = "1,0,0,0";
        //        string WidthVal = "1150,1150,1150,1150";
        //        string HeightVal = "6,5,4,5";// "226,226,226,226";
        //        string HeightVal_T = "4,4,4,4";
        //        string LeftVal = "0,0,0,0";
        //        string AlignVal = "M,M,M,M";

        //        Report_Header[0] = cmbCompany.Text; //edpcom.CURRENT_COMPANY;
        //        Report_Header[1] = CO_ADD;
        //        Report_Header[2] = Header;
        //       // Report_Header[3] = " For the month of  " + AttenDtTmPkr.Text;//+ Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString();

                

        //        for (int i = 0; i <= Report_Header.Length - 1; i++)
        //        {
        //            Report_Header_FontName[i] = "Arial";
        //            Report_Header_FontSize[i] = "10";
        //            Report_Header_FontStyle[i] = "B";
        //        }

        //        if (chkALL.Checked == true)
        //        {
        //            CAR_L = 1;
        //        }
        //        else if (chkACNames.Checked== true)
        //        {
        //            CAR_L = 2;
        //        }
        //        MR.opt = CAR_L;
        //        if (CAR_L == 1)
        //        {
        //            MR.ReportHeaderArrenge(Report_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Header_FontName, Report_Header_FontSize, Report_Header_FontStyle);
        //        }
        //        else
        //        {
        //            MR.ReportHeaderArrenge(Report_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Header_FontName, Report_Header_FontSize, Report_Header_FontStyle);
        //        }
        //        //=================================End===========================================

        //        //============================Report Page Header============================================
        //        string[] Report_Page_Header = new string[2];
        //        string[] Report_PageHeader_FontName = new string[2];
        //        string[] Report_PageHeader_FontSize = new string[2];
        //        string[] Report_PageHeader_FontStyle = new string[2];

        //        TopVal = "2,0";
        //        WidthVal = "200,200";
        //        //HeightVal = "6,6";// "226,226,226,226";
        //        HeightVal = "0,0";// "226,226,226,226";
        //        LeftVal = "2,2";
        //        AlignVal = "L,L";  //L for Left,R for Right,M for center

        //        //Report_Page_Header[0] = Header;
        //        //Report_Page_Header[1] = "Session " + cmbYear.SelectedItem + " For the month of  " + AttenDtTmPkr.Text;

        //        Report_PageHeader_FontName[0] = "Arial";
        //        Report_PageHeader_FontName[1] = "Arial";
        //        Report_PageHeader_FontSize[0] = "8";
        //        Report_PageHeader_FontSize[1] = "8";
        //        Report_PageHeader_FontStyle[0] = "B";
        //        Report_PageHeader_FontStyle[1] = "B";
        //        if (CAR_L == 1)
        //        {
        //            MR.ReportPageHeaderArrenge(Report_Page_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageHeader_FontName, Report_PageHeader_FontSize, Report_PageHeader_FontStyle);
        //        }
        //        else
        //        {
        //            MR.ReportPageHeaderArrenge(Report_Page_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageHeader_FontName, Report_PageHeader_FontSize, Report_PageHeader_FontStyle);
        //        }
        //        //====================================End===========================================

        //        //============================Report Page Footer============================================
        //        string[] Report_PageFooter = new string[1];
        //        string[] Report_PageFooter_FontName = new string[1];
        //        string[] Report_PageFooter_FontSize = new string[1];
        //        string[] Report_PageFooter_FontStyle = new string[1];

        //        TopVal = "1";
        //        WidthVal = "33";
        //        HeightVal = "2";// "226,226,226,226";
        //        LeftVal = "2";
        //        AlignVal = "R";

        //        Report_PageFooter[0] = " ";
        //        Report_PageFooter_FontName[0] = "Arial";
        //        Report_PageFooter_FontName[0] = "8";
        //        Report_PageFooter_FontStyle[0] = "B";
        //        if (CAR_L == 1)
        //        {
        //            MR.ReportPageFooterArrenge(Report_PageFooter, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageFooter_FontName, Report_PageFooter_FontName, Report_PageFooter_FontStyle);
        //        }
        //        else
        //        {
        //            MR.ReportPageFooterArrenge(Report_PageFooter, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageFooter_FontName, Report_PageFooter_FontName, Report_PageFooter_FontStyle, "L");
        //        }
        //        ////====================================End===========================================

        //        ////============================Report Footer============================================
        //        string[] Report_Footer = new string[1];
        //        string[] Report_Footer_FontName = new string[1];
        //        string[] Report_Footer_FontSize = new string[1];
        //        string[] Report_Footer_FontStyle = new string[1];

        //        TopVal = "2";
        //        WidthVal = "155";
        //        HeightVal = "2";// "226,226,226,226";
        //        LeftVal = "2";
        //        AlignVal = "L";

        //        Report_Footer[0] = " ";
        //        //Report_Footer[1] = Convert.ToString(total_Qty);
        //        Report_Footer_FontName[0] = "Times New Roman";
        //        //Report_Footer_FontName[1] = "Times New Roman";
        //        Report_Footer_FontSize[0] = "10";
        //        //Report_Footer_FontSize[1] = "10";
        //        Report_Footer_FontStyle[0] = "B";
        //        //Report_Footer_FontStyle[1] = "B";
        //        if (CAR_L == 1)
        //        {
        //            MR.ReportFooterArrenge(Report_Footer, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Footer_FontName, Report_Footer_FontSize, Report_Footer_FontStyle);
        //        }
        //        else
        //        {
        //            MR.ReportFooterArrenge(Report_Footer, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Footer_FontName, Report_Footer_FontSize, Report_Footer_FontStyle, "L");
        //        }
        //        //====================================End===========================================

        //        //============================Details Columns Header============================================
        //        int Col_Count = dt1.Columns.Count;
        //        string[] Report_Columns_Header = new string[Col_Count];
        //        string[] Report_Columns_Header_FontName = new string[Col_Count];
        //        string[] Report_Columns_Header_FontSize = new string[Col_Count];
        //        string[] Report_Columns_Header_FontStyle = new string[Col_Count];

        //        for (int i = 0; i <= dt1.Columns.Count - 1; i++)
        //        {
        //            string ao = dt1.Columns[i].ToString();
        //            Report_Columns_Header[i] = ao;

        //        }
        //        for (int i = 0; i <= dt1.Columns.Count - 1; i++)
        //        {
        //            Report_Columns_Header_FontName[i] = "Times New Roman";
        //            Report_Columns_Header_FontSize[i] = "8";
        //            Report_Columns_Header_FontStyle[i] = "L";
        //        }

        //        int Head_width = 0;
        //        if (Head_Cou == 0)
        //        {
        //            TopVal = "1,1,1";
        //            WidthVal = "6,40,10";
        //            HeightVal = "20,20,20";//"4,4,4";// "226,226,226,226";
        //            HeightVal_T = "4,4,4";
        //            LeftVal = "2,0,0";
        //            AlignVal = "L,L,L";
        //            Head_width = 274;

        //        }
        //        else if (Head_Cou == 1)
        //        {
        //            TopVal = "1,1,1,1";
        //            WidthVal = "6,40,10,14";
        //            HeightVal = "20,20,20,20";//"4,4,4,4";// "226,226,226,226";
        //            HeightVal_T = "4,4,4,4";
        //            LeftVal = "2,0,0,0";
        //            AlignVal = "L,L,L,L";
        //            Head_width = 260;
        //        }
        //        else if (Head_Cou == 2)
        //        {
        //            TopVal = "1,1,1,1,1";
        //            WidthVal = "6,40,10,14,14";
        //            HeightVal = "20,20,20,20,20";//"4,4,4,4,4";// "226,226,226,226";
        //            HeightVal_T = "4,4,4,4,4";
        //            LeftVal = "2,0,0,0,0";
        //            AlignVal = "L,L,L,L,L";
        //            Head_width = 246;
        //        }
        //        else if (Head_Cou == 3)
        //        {
        //            TopVal = "1,1,1,1,1,1";
        //            WidthVal = "6,40,10,14,14,14";
        //            HeightVal = "20,20,20,20,20,20";//"4,4,4,4,4,4";// "226,226,226,226";
        //            HeightVal_T = "4,4,4,4,4,4";
        //            LeftVal = "2,0,0,0,0,0";
        //            AlignVal = "L,L,L,L,L,L";
        //            Head_width = 232;

        //        }
        //        else if (Head_Cou == 4)
        //        {
        //            TopVal = "1,1,1,1,1,1,1";
        //            WidthVal = "40,60,60,60,14,14,14";
        //            HeightVal = "20,20,20,20,20,20,20";//"4,4,4,4,4,4,4";// "226,226,226,226";
        //            HeightVal_T = "4,4,4,4,4,4,4";
        //            LeftVal = "2,0,0,0,0,0,0";
        //            AlignVal = "C,C,C,C,L,L,L";
        //            Head_width = 218;
        //        }
        //        else if (Head_Cou == 5)
        //        {
        //            TopVal = "1,1,1,1,1,1,1,1";
        //            WidthVal = "30,50,50,50,50,14,14,10";
        //            HeightVal = "20,20,20,20,20,20,20,20";//"4,4,4,4,4,4,4,4";// "226,226,226,226";
        //            HeightVal_T = "4,4,4,4,4,4,4,4";
        //            LeftVal = "2,0,0,0,0,0,0,0";
        //            AlignVal = "C,C,C,C,C,L,L,L";
        //            Head_width = 218;
        //        }
        //        else if (Head_Cou == 6)
        //        {
        //            TopVal = "1,1,1,1,1,1,1,1,1";
        //            WidthVal = "6,37,10,20,14,14,14,10,10";
        //            HeightVal = "20,20,20,20,20,20,20,20,20";//"4,4,4,4,4,4,4,4,4";// "226,226,226,226";
        //            HeightVal_T = "4,4,4,4,4,4,4,4,4";
        //            LeftVal = "2,0,0,0,0,0,0,0,0";
        //            AlignVal = "L,L,L,L,L,L,L,L,L";
        //            Head_width = 200;
        //        }

        //        //int a = DT1.Columns.Count;
        //        //a = a - (Head_Cou + 5);
        //        //int ab = Head_width / a;
        //        //Head_Cou = Head_Cou + 3;
        //        //for (int i = Head_Cou; i <= DT1.Columns.Count - 1; i++)
        //        //{
        //        //    TopVal = TopVal + "," + 1;
        //        //    WidthVal = WidthVal + "," + ab;

        //        //    HeightVal = HeightVal + "," + 8;
        //        //    LeftVal = LeftVal + "," + 0;
        //        //    AlignVal = AlignVal + "," + "R";
        //        //}
        //        if (CAR_L == 1)
        //        {
        //            MR.DetailsColumnsHeaderArrenge(Report_Columns_Header, Report_Columns_Header_FontName, Report_Columns_Header_FontSize, Report_Columns_Header_FontStyle);
        //            MR.DetailsColumnsArrenge(TopVal, WidthVal, HeightVal, LeftVal, AlignVal);
        //        }
        //        else
        //        {
        //            MR.DetailsColumnsHeaderArrenge(Report_Columns_Header, Report_Columns_Header_FontName, Report_Columns_Header_FontSize, Report_Columns_Header_FontStyle);
        //            MR.DetailsColumnsArrenge(TopVal, WidthVal, HeightVal, LeftVal, AlignVal);
        //        }
        //        //===================================End====================================================
        //        if (flug == 1)
        //        {
        //            if (CAR_L == 1)
        //            {
        //                MR.Graphic_Preview(dt_Sal_Pur_Reg_Final);
        //            }
        //            else
        //            {
        //                MR.Graphic_Preview(dt_Sal_Pur_Reg_Final);
        //            }
        //            MR.Show();
        //        }
        //        else
        //            if (CAR_L == 1)
        //            {
        //                MR.Graphic_Preview(dt_Sal_Pur_Reg_Final);
        //            }
        //            else
        //            {
        //                MR.Graphic_Preview(dt_Sal_Pur_Reg_Final);
        //            }
        //        MR.Show();
        //    }
        //    catch { }
        //}


    }
}
