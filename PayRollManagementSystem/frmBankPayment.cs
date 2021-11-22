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
using System.IO;
using System.Diagnostics;
//using Excel;

namespace PayRollManagementSystem
{
    public partial class frmBankPayment : Form //EDPComponent.FormBaseRptMidium
    {
        Edpcom.EDPConnection Edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon Edpcom = new EDPCommon();

        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        DataTable tot_employ = new DataTable();
        string Item_code = "", Tentry_code = "";
        SqlCommand Cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();      
        DataTable DT = new DataTable();
        string Frm_type = "";
        int Head_cou = 0;
        string Location = "";
          string  LocName="";
        int company_id=0;
        string arrayItm = "";
        //Hashtable getcode = new Hashtable();
        Hashtable getcode_Group = new Hashtable();
        Hashtable getcode_Item = new Hashtable();

        string Current_Company = "";
        string Address = "";
        string Address1 = "";
        string Pan;
        string Duration="";
        string sq1;

        ArrayList arritm = new ArrayList();
        int Client_id = 0;



        string Company = "", AgentAdd = "", AgentAdd1 = "", Phone = "", area = "", Billdate = "", User_voucher = "";
        string Challan = "", Challandt = "", Amtword = "", Narrsn = "";
        string ConName = "", Conadd1 = "", ConAdd2 = "";
        string Amtvalue = "";
        string Lorry_no = "", Locname = "", Modtranport = "", Prtyname = "", Prtyadd1 = "", Prtyadd2 = "", Prtycity = "", Prtyctypin = "", Prtytele1 = "", Prtytele2 = "", Prtyfax = "", Prtyemail = "", Prtyeccno = "", Prtytin = "";
        string Partycodeeee = "";
        string Tentry = "", Finalamount = "", RefVoucher = "";

        string setting_type = "";
        string startPath = "";

         public frmBankPayment(string type)
        {
            InitializeComponent();
            Frm_type = type;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmEmployee_PayAdvice_Load(object sender, EventArgs e)
        {
            
        }


        public void Configuration_Menu_TypeDoc_companySetting()
        {
            try
            {
                string filePath = "";
                filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
                string line;
                if (File.Exists(filePath))
                {
                    StreamReader file = null;
                    try
                    {
                        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
                        edpcon.Close();
                        file = new StreamReader(filePath);
                        if (file.ReadLine() != null)
                        {
                            int chk_str = 0;
                            while ((line = file.ReadLine()) != null)
                            {
                                string[] StrSTAR = line.Trim().Split('*');
                                if (StrSTAR.Length == 2)
                                {
                                    if (StrSTAR[0].Trim() == "")
                                        continue;
                                }

                                string[] StrLine = line.Trim().Split('[');
                                if (StrLine.Length == 2)
                                {
                                    string str = line.Substring(1, line.Length - 2);
                                    if (str == "Company_Details")
                                        chk_str = 1;
                                    else if (str == "Environment_Envelope")
                                        chk_str = 2;
                                    else if (str == "SDATE")
                                        chk_str = 3;
                                    else
                                        chk_str = 0;
                                }

                                string[] StrLine_WACC = line.Trim().Split(';');

                                if ((chk_str == 1) && (StrLine_WACC.Length > 2))
                                {
                                    if (StrLine_WACC[0] == "Country")
                                    {
                                        //cmbCountry.Text = StrLine_WACC[1];
                                        //DataTable Coun = edpcom.GetDatatable("SELECT Country_CODE FROM Country where Country_Name='" + cmbCountry.Text + "'");
                                        //if (Coun.Rows.Count > 0)
                                        // string   COUNTRYCODE = Convert.ToInt32(Coun.Rows[0][0]);
                                        //MoneyName = edpcom.GetresultS("SELECT Currency_Name From Country Where Country_Name='" + cmbCountry.Text + "'");
                                    }
                                    else if (StrLine_WACC[0] == "State")
                                    {
                                       // this.cmbstate.Text = StrLine_WACC[1];
                                        //DataTable stat = edpcom.GetDatatable("SELECT STATE_CODE FROM StateMaster where State_Name='" + cmbstate.Text + "'");
                                        //if (stat.Rows.Count > 0)
                                        //    STATECODE = Convert.ToInt32(stat.Rows[0][0]);
                                    }
                                    else if (StrLine_WACC[0] == "City")
                                    {
                                        this.txtCity.Text = StrLine_WACC[1].ToUpper();

                                        //DataTable stat = edpcom.GetDatatable("SELECT STATE_CODE FROM StateMaster where State_Name='" + cmbstate.Text + "'");
                                        //if (stat.Rows.Count > 0)
                                        //    STATECODE = Convert.ToInt32(stat.Rows[0][0]);
                                    }
                                }
                                //else if ((chk_str == 2) && (StrLine_WACC.Length > 1))
                                //{
                                //    if (StrLine_WACC[0].ToUpper() == "PETROL")
                                //        edpcom.EnvironMent_Envelope = "Petrol";
                                //    else if (StrLine_WACC[0].ToUpper() == "PRINTING")
                                //        edpcom.EnvironMent_Envelope = "PRINTING";
                                //    else
                                //        edpcom.EnvironMent_Envelope = "";
                                //}
                                //else if ((chk_str == 3) && (StrLine_WACC.Length > 1))
                                //{
                                //    if (StrLine_WACC[1].ToUpper() != "")
                                //    {
                                //        Config_Date_Start = Convert.ToString(StrLine_WACC[0]);
                                //        Config_Month_Start = Convert.ToString(StrLine_WACC[1]);
                                //        chk_Date_First = true;
                                //    }
                                //}
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }

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
        //public int get_CompID(string name)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Clear();
        //    string s = " select GCODE  from Company where CO_Name='" + name + "'";
        //    dt = clsDataAccess.RunQDTbl(s);
        //    return Convert.ToInt32(dt.Rows[0][0]);
        //}
        private void Retrive_Data()
        {
            Boolean flug_deduction = false;
            //string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            //string strssql = "";
            //strssql = strssql + " select p.Cliant_ID,sum(p.billamt) as 'BillAmount',sum(s.NetPay) as 'Netpay',case when sum(p.billamt)>sum(s.NetPay) then (sum(p.billamt)-sum(s.NetPay)) ";
            //strssql = strssql + " when sum(p.billamt)<sum(s.NetPay) then (sum(s.NetPay)-sum(p.billamt)) end as 'Profit/loss' from tbl_Employee_SalaryMast s inner join paybillD p on s.Month=p.Month";
            //strssql = strssql + " and s.Location_id=p.Location_ID and s.Company_id=p.Company_id and s.Session=p.Session where s.MONTH='" + month + "' ";
            //strssql = strssql + " and s.Company_id='" + get_CompID(cmbcompany.Text) + "' and s.Location_id='" + get_LocationID(cmbsalstruc.Text) + "' and p.Cliant_ID=" + clsEmployee.GetClintID(cmbclintname.Text) + " and s.Session= '" + cmbYear.Text + "'";
            //strssql = strssql + " group by s.MONTH,p.Cliant_ID";


            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");
            tot_employ = clsDataAccess.RunQDTbl("strssql");

            DT = tot_employ.Copy();

        }
        //========= test code ==================================
        public void tstcod()
        {

            String sql = "SELECT BRNCH_NAME,BRNCH_ADD1,Cmpimage FROM Branch";
            DataTable test_code = clsDataAccess.RunQDTbl(sql);



            ds.Tables.Add(test_code);
            ds.Tables[0].TableName = "Test_Code";
        }
        //======================================================


        private void btnPreview_Click(object sender, EventArgs e)
        {
            //---------Testing Block---------
            //tstcod();
            //opening.tstPrint(DS);
            //opening.Show();
            //DS.Tables.Clear();
            //DS.Dispose();
            //------------------


            //if (dt.Rows.Count > 0)
            //{
            //    PrintDetails(1);
            //}
            //else
            //{
            //    ERPMessageBox.ERPMessage.Show("No record Found");
            //    return;
            //}

            //dt.Dispose();
            //dt.Clear();





        }
        public void Printheader()
        {

            DataSet dsBRANCH = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();

            Edpcon. Close();
            Edpcon.Open();
            dsBRANCH.Clear();
            Cmd = new SqlCommand("select b.BRNCH_ADD1,b.BRNCH_ADD2,b.BRNCH_CITY,s.State_Name,b.BRNCH_PIN,b.BRNCH_PAN1 FROM BRANCH b,StateMaster s WHERE b.FICODE=" + Edpcom.CurrentFicode + " AND b.GCODE=" + Edpcom.PCURRENT_GCODE + " AND b.BRNCH_CODE=0 and s.STATE_CODE=b.BRNCH_STATE ",Edpcon.mycon);
            //edpcon.mycon.Open();

            adp.SelectCommand = Cmd;

            try
            {
                adp.Fill(dsBRANCH, "BR");

                Duration = "As On : " + "" + AttenDtTmPkr.Value.ToShortDateString() + "";


                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][0]) != "")
                    Address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][0]) + ",";

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]) != "")
                    Address = Address + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]);


                Address = "";
                if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    Address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                    Address = Address + " - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                    Address = Address + ", " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    Address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                    Address = Address + " - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() == ""))
                {
                    Address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]) + "," + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    Address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]) + ", PIN No. - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() == ""))
                {
                    Address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() == ""))
                {
                    Address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    Address = "PIN No. - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                }
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][5]) != "")
                    Pan = "PAN No. : " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][5]);
                else
                    Pan = "";

                string Query = "select co_name from company where ficode='" + Edpcom.CurrentFicode + "' and Gcode='" + Edpcom.PCURRENT_GCODE + "'";
                DataTable dtre = clsDataAccess.RunQDTbl(Query);
                Current_Company= (dtre.Rows[0][0].ToString());
            }
            catch
            {
            }

        }

        public static DataTable RunQDTbl(String strSql)
        {
            return new EDPCommon().GetDatatable(strSql);
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
            Retrieve_DataEsi();
            MidasReport.Form1 opening = new MidasReport.Form1();
            opening.bankpaymentrpt(TxtBankName.Text, TxtAccountNo.Text, CmbCompany.Text, TxtDesignation.Text, txtCity.Text, txtTagline.Text, lblAdd.Text, lblContact.Text, tot_employ, 2);

            ds.Tables.Clear();
            ds.Dispose();


            //LoadDataTable();
            //PrintDetails(2);
        }

        public void PrintDetails(int flug)
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = DT.Copy();
                for (int i = 0; i <= DT.Columns.Count - 1; i++)
                {
                    int s = i + 1;
                    DT.Columns[i].ColumnName = "col" + s;
                }
                //dt1 = dt.Copy();
                MidasReport.Form1 MR = new MidasReport.Form1();
                DataTable dt_Sal_Pur_Reg_Final = DT;

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

                Report_Header[0] = Edpcom.CURRENT_COMPANY;
                Report_Header[1] = "P.TAX Report for the location " + Locname;
                Report_Header[2] = "Session " + CmbYear.SelectedItem;//" ";
                Report_Header[3] = " For the month of  " + AttenDtTmPkr.Text;//+ Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString();

                //Report_Header[3] = "Form " + Convert.ToDateTime(dtpForm.Value).ToShortDateString() + " TO " + Convert.ToDateTime(dtpto.Value).ToShortDateString();


                //Report_Header[4] = ""; //"Periodical Stock Transaction";

                for (int i = 0; i <= Report_Header.Length - 1; i++)
                {
                    Report_Header_FontName[i] = "Arial";
                    Report_Header_FontSize[i] = "10";
                    Report_Header_FontStyle[i] = "B";
                }
                MR.ReportHeaderArrenge(Report_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Header_FontName, Report_Header_FontSize, Report_Header_FontStyle);
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

                Report_Page_Header[0] = "Pay Slip for the location " + Locname;
                Report_Page_Header[1] = "Session " + CmbYear.SelectedItem + " For the month of  " + AttenDtTmPkr.Text;

                Report_PageHeader_FontName[0] = "Arial";
                Report_PageHeader_FontName[1] = "Arial";
                Report_PageHeader_FontSize[0] = "8";
                Report_PageHeader_FontSize[1] = "8";
                Report_PageHeader_FontStyle[0] = "B";
                Report_PageHeader_FontStyle[1] = "B";
                MR.ReportPageHeaderArrenge(Report_Page_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageHeader_FontName, Report_PageHeader_FontSize, Report_PageHeader_FontStyle);
                //====================================End===========================================

                //============================Report Page Footer============================================
                string[] Report_PageFooter = new string[1];
                string[] Report_PageFooter_FontName = new string[1];
                string[] Report_PageFooter_FontSize = new string[1];
                string[] Report_PageFooter_FontStyle = new string[1];

                TopVal = "1";
                WidthVal = "33";
                HeightVal = "2";// "226,226,226,226";
                LeftVal = "2";
                AlignVal = "R";

                Report_PageFooter[0] = " ";
                Report_PageFooter_FontName[0] = "Arial";
                Report_PageFooter_FontName[0] = "8";
                Report_PageFooter_FontStyle[0] = "B";
                MR.ReportPageFooterArrenge(Report_PageFooter, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageFooter_FontName, Report_PageFooter_FontName, Report_PageFooter_FontStyle);
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
                Report_Footer_FontSize[0] = "10";
                //Report_Footer_FontSize[1] = "10";
                Report_Footer_FontStyle[0] = "B";
                //Report_Footer_FontStyle[1] = "B";
                MR.ReportFooterArrenge(Report_Footer, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Footer_FontName, Report_Footer_FontSize, Report_Footer_FontStyle);
                //====================================End===========================================

                //============================Details Columns Header============================================
                int Col_Count = dt1.Columns.Count;
                string[] Report_Columns_Header = new string[Col_Count];
                string[] Report_Columns_Header_FontName = new string[Col_Count];
                string[] Report_Columns_Header_FontSize = new string[Col_Count];
                string[] Report_Columns_Header_FontStyle = new string[Col_Count];



             /*  if (CmbReport.SelectedIndex == 0)
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
                }*/

                for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                {
                    Report_Columns_Header_FontName[i] = "Times New Roman";
                    Report_Columns_Header_FontSize[i] = "8";
                    Report_Columns_Header_FontStyle[i] = "R";
                }

                int Head_width = 0;
                if (Head_cou == 0)
                {
                    TopVal = "1,1,1";
                    WidthVal = "6,40,10";
                    HeightVal = "4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0";
                    AlignVal = "L,L,L";
                    Head_width = 274;

                }
                else if (Head_cou == 1)
                {
                    TopVal = "1,1,1,1";
                    WidthVal = "6,40,10,14";
                    HeightVal = "4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0";
                    AlignVal = "L,L,L,L";
                    Head_width = 260;
                }
                else if (Head_cou == 2)
                {
                    TopVal = "1,1,1,1,1";
                    WidthVal = "6,40,10,14,14";
                    HeightVal = "4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0";
                    AlignVal = "L,L,L,L,L";
                    Head_width = 246;
                }
                else if (Head_cou == 3)
                {
                    TopVal = "1,1,1,1,1,1";
                    WidthVal = "6,40,10,14,14,14";
                    HeightVal = "4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L";
                    Head_width = 232;

                }
                else if (Head_cou == 4)
                {
                    TopVal = "1,1,1,1,1,1,1";
                    WidthVal = "6,40,10,14,14,14,14";
                    HeightVal = "4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L";
                    Head_width = 218;
                }
                else if (Head_cou == 5)
                {
                    TopVal = "1,1,1,1,1,1";
                    WidthVal = "8,70,70,60,60";
                    HeightVal = "4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0";
                    AlignVal = "L,L,L,L,L";
                    Head_width = 300;
                }

                else if (Head_cou == 6)
                {
                    TopVal = "1,1,1,1,1,1";
                    WidthVal = "8,70,40,40,40,40";
                    HeightVal = "4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L";
                    Head_width = 300;
                }
                else if (Head_cou == 8)
                {
                    TopVal = "1,1,1,1,1,1,1,1,1";
                    WidthVal = "6,60,40,40,40,40,40,40,40";
                    HeightVal = "4,4,4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L,L";
                    Head_width = 310;
                }

                else if (Head_cou == 9)
                {
                    TopVal = "1,1,1,1,1,1,1,1,1";
                    WidthVal = "6,50,25,25,25,25,25,25,25";
                    HeightVal = "4,4,4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L,L";
                    Head_width = 230;
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

                MR.DetailsColumnsHeaderArrenge(Report_Columns_Header, Report_Columns_Header_FontName, Report_Columns_Header_FontSize, Report_Columns_Header_FontStyle);
                MR.DetailsColumnsArrenge(TopVal, WidthVal, HeightVal, LeftVal, AlignVal);

                //===================================End====================================================
                if (flug == 1)
                {
                    MR.Graphic_Preview(dt_Sal_Pur_Reg_Final);
                    MR.Show();
                }
                else
                    MR.Graphic_Print(dt_Sal_Pur_Reg_Final);
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

        private void CmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Retrieve_DataEsi()
        {

            //string Str_ErHead_basic = "";
            //DataTable ErHead_basic = clsDataAccess.RunQDTbl("select top 1  SalaryHead_Short from tbl_Employee_ErnSalaryHead");
            //Str_ErHead_basic = ErHead_basic.Rows[0][0].ToString();

            string strssql = "";
            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            string yr = Convert.ToString(AttenDtTmPkr.Value.Year);
            string strssql1 = "";
            DataTable tot_employ1;

            strssql1 = "";
            strssql1 = strssql1 + " select ";
            strssql1 = strssql1 + " (select c.co_name from Company c where c.CO_CODE=S.Company_id ) as 'coname',";
            strssql1 = strssql1 + " (select c.CO_ADD  from Company c where c.CO_CODE=s.Company_id ) as 'Add1',(select c.CO_ADD1   from Company c where c.CO_CODE=s.Company_id ) as 'Add2', ";
            strssql1 = strssql1 + " (select Location_Name from tbl_Emp_Location where Location_ID=S.Location_ID ) as 'locname',";

            strssql1 = strssql1 + " '' as 'designation'";
            strssql1 = strssql1 + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'ClientName'";
            strssql1 = strssql1 + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )  as 'ClientCity'";
            strssql1 = strssql1 + " ,(select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'Contract_Person'";

            strssql1 = strssql1 + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )) AS mis1,";
            strssql1 = strssql1 + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) AS mis2,";
            strssql1 = strssql1 + " '" + month + "," + yr + "' AS mis3,'' AS mis4,'' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,(select distinct BRNCH_TELE1 from Branch B where B.GCODE=s.Company_id ) AS mis10,";
            strssql1 = strssql1 + " '' AS id, ODName as EmpName, Bank as Bank_Name, Branch as Branch_Name, AcNo as BankAcountNo, IFSC as IFSCCODE,'' AS Bank_AC_Type, Amount as NetPay";

            /*if (chkNC.Checked == true)
            {
                strssql1 = strssql1 + "(select sum(Amount) from  tbl_Employee_SalaryDetails where  (Month='" + month + "') and (Session='" + CmbYear.Text + "') and (Location_id='" + Location + "') and "+
                "SalId in (select  SAL_HEAD from tbl_Employee_Assign_SalStructure where NCompliance='1' and location_id='" + Location + "') "+
                "and  EmpId=s.Emp_Id)  as NetPay ";
            }
            else
            {
               strssql1 = strssql1 + " Amount as NetPay ";
            }*/
            if (chk_multiSelect.Checked == true)
            {

                strssql1 = strssql1 + " FROM tbl_Employee_Sal_OCharges AS s  where (s.Location_id in (" + Location + ")) and s.Month='" + month + "' and (s.Session ='" + CmbYear.Text + "')";
            }
            else if (chkCompany.Checked == true)
            {
                strssql1 = strssql1 + " FROM tbl_Employee_Sal_OCharges AS s  where (s.Location_id in (select distinct(Location_ID) from Companywiseid_Relation where Company_ID="+company_id+")) and s.Month='" + month + "' and (s.Session ='" + CmbYear.Text + "')";

            }
            else
            {
                strssql1 = strssql1 + " FROM tbl_Employee_Sal_OCharges AS s  where (s.Location_id= '" + Location + "') and s.Month='" + month + "' and (s.Session ='" + CmbYear.Text + "')";
            }

            if (rdbSalary.Checked==true)
            {
            strssql = strssql + " select ";
            strssql = strssql + " (select c.co_name from Company c where c.CO_CODE=S.Company_id ) as 'coname',";
            strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=s.Company_id ) as 'Add1',(select c.CO_ADD1   from Company c where c.CO_CODE=s.Company_id ) as 'Add2', ";
            strssql = strssql + " (select Location_Name from tbl_Emp_Location where Location_ID=S.Location_ID ) as 'locname',";

            strssql = strssql + " (select e.DesignationName  from tbl_Employee_DesignationMaster e where e.SlNo=S.desig_ID )as 'designation'";
            strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'ClientName'";
            strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )  as 'ClientCity'";
            strssql = strssql + " ,(select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'Contract_Person'";

            strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )) AS mis1,";
            strssql = strssql + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) AS mis2,";
            strssql = strssql + " '" + month + "," + yr + "' AS mis3,'' AS mis4,'' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,'' AS mis10,";
            strssql = strssql + "  e.id,(case when e.Mobile=0 then '' else cast(e.Mobile as nvarchar) end)Mobile,e.emailid as 'EMail',' '+(case when isNull(e.bankAc_name,'')='' then ((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + " +
            "(CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) else e.bankAc_name end) as 'EmpName',";
            strssql = strssql + " e.Bank_Name,e.Branch_Name,e.BankAcountNo,GMIno as 'IFSCCODE',e.Bank_AC_Type,";
                
            if (chkNC.Checked == true)
            {
                strssql = strssql + "(select sum(Amount) from  tbl_Employee_SalaryDetails where  (Month='" + month + "') and (Session='" + CmbYear.Text + "') and (Location_id='" + Location + "') and " +
                "SalId in (select  SAL_HEAD from tbl_Employee_Assign_SalStructure where NCompliance='1' and location_id='" + Location + "') " +
                "and  EmpId=s.Emp_Id)  as NetPay ";
            }
            else
            {
               strssql = strssql + " s.NetPay ";
            }

            strssql = strssql + ",(select distinct Cmpimage from branch b where b.GCODE=S.Company_id ) as 'Cmpimage'," +
            "((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) as 'InFavourof'  ";
            
            strssql = strssql + " from tbl_Employee_Mast e inner join tbl_Employee_SalaryMast s";
            strssql = strssql + " on e.ID=s.Emp_Id ";
            if (chk_multiSelect.Checked == true)
            {

                if (chk_All_Emp.Checked == false)
                {
                    strssql = strssql + " where (s.Location_id in (" + Location + ")) and (s.Month='" + month + "') and (s.Session ='" + CmbYear.Text + "')" + " and s.Emp_Id in (" + Item_code + ") and ((ltrim(rtrim(e.BankAcountNo))!='') and (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1) and (s.netpay<>0)";
                }

                else
                {
                    strssql = strssql + " where (s.Location_id in (" + Location + ")) and (s.Month='" + month + "') and (s.Session ='" + CmbYear.Text + "') and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1) and (s.netpay<>0)";
                }
            }
            else if (chkCompany.Checked == true)
            {
                if (chk_All_Emp.Checked == false)
                {
                    strssql = strssql + " where (s.Location_id in (select distinct(Location_ID) from Companywiseid_Relation where Company_ID=" + company_id + ")) and s.Month='" + month + "' and (s.Session ='" + CmbYear.Text + "') and s.Emp_Id in (" + Item_code + ") and ((ltrim(rtrim(e.BankAcountNo))!='') and (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1) and (s.netpay<>0)";
                }
                else
                {
                    strssql = strssql + " where (s.Location_id in (select distinct(Location_ID) from Companywiseid_Relation where Company_ID=" + company_id + ")) and s.Month='" + month + "' and (s.Session ='" + CmbYear.Text + "') and ((ltrim(rtrim(e.BankAcountNo))!='') and (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1) and (s.netpay<>0)";

                }
            }
            else
            {
                if (chk_All_Emp.Checked == false)
                {
                    strssql = strssql + " where (s.Location_id= '" + Location + "') and (s.Month='" + month + "') and (s.Session ='" + CmbYear.Text + "')" + " and s.Emp_Id in (" + Item_code + ") and ((ltrim(rtrim(e.BankAcountNo))!='') and (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1) and (s.netpay<>0)";
                }

                else
                {
                    strssql = strssql + " where (s.Location_id= '" + Location + "') and (s.Month='" + month + "') and (s.Session ='" + CmbYear.Text + "') and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1) and (s.netpay<>0)";
                }
            }
            tot_employ = clsDataAccess.RunQDTbl(strssql);
            tot_employ1 = clsDataAccess.RunQDTbl(strssql1);
            DataTable tb = new DataTable();
            int ind = 0,ind_2=0,rw=0 ;

                while (ind < tot_employ1.Rows.Count)
                {
                    ind_2 = 0;
                    while (ind_2 < tot_employ.Rows.Count)
                    {
                        if (tot_employ1.Rows[ind]["EmpName"].ToString().Trim() == "PRABIR  CHATTOPADHYAY")
                        {
                            //For bench mark testing
                        }
                        if (tot_employ.Rows[ind_2]["EmpName"].ToString().Trim() == "PRABIR  CHATTOPADHYAY")
                        {
                            //For bench mark testing
                        }
                        if (tot_employ1.Rows[ind]["EmpName"].ToString().Trim() == tot_employ.Rows[ind_2]["EmpName"].ToString().Trim())
                        {
                            rw = 1;
                            tot_employ.Rows[ind_2]["NetPay"] =Convert.ToDouble( tot_employ.Rows[ind_2]["NetPay"]) + Convert.ToDouble(tot_employ1.Rows[ind]["NetPay"]);
                            //exit(0) while;
                        }
                        //tb = foundRows.Clone;
                        ind_2++;
                    }
                    if (rw==0)
                    {
                        tot_employ.ImportRow(tot_employ1.Rows[ind]);
                        rw = 0;
                    }
                    ind++;
                }

                if (chkCompany.Checked)
                {
                    int orginalEmpIdPos = 0;
                    string empid = "";
                    bool boolDuplicateEmpIdFlag = false;
                    for (int i = 0; i < tot_employ.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            empid = tot_employ.Rows[i]["ID"].ToString();
                            orginalEmpIdPos = i;
                        }
                        else
                        {
                            if (empid == tot_employ.Rows[i]["ID"].ToString())
                            {
                                //" [" + tot_employ.Rows[orginalEmpIdPos]["ClientName"].ToString() + "]; "
                                //+ " [" + tot_employ.Rows[i]["ClientName"].ToString() + "]"
                                tot_employ.Rows[orginalEmpIdPos]["locname"] = tot_employ.Rows[orginalEmpIdPos]["locname"].ToString() + ", " + tot_employ.Rows[i]["locname"].ToString();

                                //string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[orginalEmpIdPos]["WDay"]) + Convert.ToDouble(tot_employ.Rows[i]["WDay"]));
                                tot_employ.Rows[orginalEmpIdPos]["NetPay"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[orginalEmpIdPos]["NetPay"]) + Convert.ToDouble(tot_employ.Rows[i]["NetPay"]));

                                DataRow drDuplicateEmpId = tot_employ.Rows[i];
                                drDuplicateEmpId.Delete();
                                //i--;

                            }
                            else
                            {
                                empid = tot_employ.Rows[i]["ID"].ToString();
                                orginalEmpIdPos = i;
                                boolDuplicateEmpIdFlag = true;
                            }
                        }
                    }

                    tot_employ.AcceptChanges();
                }
            

            }
            else if (rdbAdvance.Checked == true)
            {
                //strssql = strssql + " select ";
                //strssql = strssql + " (select c.co_name from Company c where c.CO_CODE=s.CoID ) as 'coname',";
                //strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=s.CoID ) as 'Add1',(select c.CO_ADD1   from Company c where c.CO_CODE=s.CoID ) as 'Add2', ";
                //strssql = strssql + " (select Location_Name from tbl_Emp_Location where Location_ID=s.LocID ) as 'locname',";

                //strssql = strssql + " '' as 'designation'";
                //strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) ) as 'ClientName'";
                //strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) )  as 'ClientCity'";
                //strssql = strssql + " ,(select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) ) as 'Contract_Person'";

                //strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) )) AS mis1,";
                //strssql = strssql + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) ) AS mis2,";
                //strssql = strssql + " '" + month + "," + yr + "' AS mis3,'' AS mis4,'' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,'' AS mis10,";
                //strssql = strssql + "  e.id,' '+e.FirstName+' '+e.MiddleName+' '+e.LastName as 'EmpName',";
                //strssql = strssql + " e.Bank_Name,e.Branch_Name,e.BankAcountNo,GMIno as 'IFSCCODE',e.Bank_AC_Type,s.EAAMT as NetPay,(select distinct Cmpimage from branch b where b.GCODE=s.CoID ) as 'Cmpimage'  ";
                //strssql = strssql + " from tbl_Employee_Mast e inner join tbl_Employee_Advance s";
                //strssql = strssql + " on e.ID=s.EAEID ";
                //if (chk_All_Emp.Checked == false)
                //{
                //    strssql = strssql + " where s.LocID= '" + Location + "' and (s.EAMONTH='" + month + "/ " + yr + "') and s.EAEID in (" + Item_code + ") ";
                //}

                //else
                //{
                //    strssql = strssql + " where s.LocID= '" + Location + "' and (s.EAMONTH='" + month + "/ " + yr + "')";
                //}



                strssql = strssql + " select ";
                strssql = strssql + " (select c.co_name from Company c where c.CO_CODE=s.CoID ) as 'coname',";
                strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=s.CoID ) as 'Add1',(select c.CO_ADD1   from Company c where c.CO_CODE=s.CoID ) as 'Add2', ";
                strssql = strssql + " (select Location_Name from tbl_Emp_Location where Location_ID=s.LocID ) as 'locname',";

                strssql = strssql + " '' as 'designation'";
                strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) ) as 'ClientName'";
                strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) )  as 'ClientCity'";
                strssql = strssql + " ,(select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) ) as 'Contract_Person'";

                strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) )) AS mis1,";
                strssql = strssql + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) ) AS mis2,";
                strssql = strssql + " '" + month + "," + yr + "' AS mis3,'' AS mis4,'' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,'' AS mis10,";
                strssql = strssql + "  e.id,(case when e.Mobile=0 then '' else cast(e.Mobile as nvarchar) end)Mobile,e.emailid as 'EMail',' '+(case when isNull(e.bankAc_name,'')='' then ((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + " +
            "(CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) else e.bankAc_name end)as 'EmpName',";
                strssql = strssql + " e.Bank_Name,e.Branch_Name,e.BankAcountNo,GMIno as 'IFSCCODE',e.Bank_AC_Type,s.EAAMT as NetPay,(select distinct Cmpimage from branch b where b.GCODE=s.CoID ) as 'Cmpimage',((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) as 'InFavourof' ";
                strssql = strssql + " from tbl_Employee_Mast e inner join tbl_Employee_Advance s";
                strssql = strssql + " on e.ID=s.EAEID ";
                if (chkCompany.Checked == true)
                {
                    if (chk_All_Emp.Checked == false)
                    {
                        strssql = strssql + " where (CoID=" + company_id + ") and (s.EAMONTH='" + month + "/ " + yr + "') and (s.EAEID in (" + Item_code + "))";
                    }
                    else
                    {
                        strssql = strssql + " where (CoID=" + company_id + ") and (s.EAMONTH='" + month + "/ " + yr + "')";
                    }
                }
                else
                {
                    if (chk_All_Emp.Checked == false)
                    {
                        strssql = strssql + " where (CoID=" + company_id + ") and (s.LocID IN (" + Location + ")) and (s.EAMONTH='" + month + "/ " + yr + "') and (s.EAEID in (" + Item_code + "))";
                    }
                    else
                    {
                        strssql = strssql + " where (CoID=" + company_id + ") and (s.LocID IN (" + Location + ")) and (s.EAMONTH='" + month + "/ " + yr + "')";
                    }
                }

                tot_employ = clsDataAccess.RunQDTbl(strssql);

                if (tot_employ.Rows.Count == 0)
                {

                    MessageBox.Show("No Record Present","Bravo");
                    return;
                }
            }
            else if (rdbLoan.Checked == true)
            {
                strssql = strssql + " select ";
                strssql = strssql + " (select c.co_name from Company c where c.CO_CODE=s.CoID ) as 'coname',";
                strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=s.CoID ) as 'Add1',(select c.CO_ADD1   from Company c where c.CO_CODE=s.CoID ) as 'Add2', ";
                strssql = strssql + " (select Location_Name from tbl_Emp_Location where Location_ID=s.LocID ) as 'locname',";

                strssql = strssql + " '' as 'designation'";
                strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) ) as 'ClientName'";
                strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) )  as 'ClientCity'";
                strssql = strssql + " ,(select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) ) as 'Contract_Person'";

                strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) )) AS mis1,";
                strssql = strssql + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.LocID ) ) AS mis2,";
                strssql = strssql + " '" + month + "," + yr + "' AS mis3,'' AS mis4,'' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,'' AS mis10,";
                strssql = strssql + "  e.id,(case when e.Mobile=0 then '' else cast(e.Mobile as nvarchar) end)Mobile,e.emailid as 'EMail',' '+(case when isNull(e.bankAc_name,'')='' then ((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + " +
            "(CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) else e.bankAc_name end)as 'EmpName',";
                strssql = strssql + " e.Bank_Name,e.Branch_Name,e.BankAcountNo,GMIno as 'IFSCCODE',e.Bank_AC_Type,s.ELAMT as NetPay,(select distinct Cmpimage from branch b where b.GCODE=s.CoID ) as 'Cmpimage',((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) as 'InFavourof' ";
                strssql = strssql + " from tbl_Employee_Mast e inner join tbl_Employee_LOAN s";
                strssql = strssql + " on e.ID=s.ELEID ";
                if (chkCompany.Checked == true)
                {
                    if (chk_All_Emp.Checked == false)
                    {
                        strssql = strssql + " where (CoID=" + company_id + ") and (s.ELMONTH='" + month + "/ " + yr + "') and (s.ELEID in (" + Item_code + "))";
                    }
                    else
                    {
                        strssql = strssql + " where (CoID=" + company_id + ") and (s.ELMONTH='" + month + "/ " + yr + "')";
                    }
                }
                else
                {
                    if (chk_All_Emp.Checked == false)
                    {
                        strssql = strssql + " where (CoID=" + company_id + ") and (s.LocID IN (" + Location + ")) and (s.ELMONTH='" + month + "/ " + yr + "') and (s.ELEID in (" + Item_code + "))";
                    }
                    else
                    {
                        strssql = strssql + " where (CoID=" + company_id + ") and (s.LocID IN (" + Location + ")) and (s.ELMONTH='" + month + "/ " + yr + "')";
                    }
                }
                tot_employ = clsDataAccess.RunQDTbl(strssql);

                if (tot_employ.Rows.Count == 0)
                {
                    MessageBox.Show("No Record Present", "Bravo");
                    return;
                }
            }
            


            DataTable dtimage = clsDataAccess.RunQDTbl("select distinct Cmpimage from branch where GCODE='" + company_id + "' ");//where id='" + CmbEmpId.Text + "'");
            ds.Tables.Add(tot_employ);


            //DS.Tables.Add(dtimage);
            ds.Tables[0].TableName = "paymentAdvice";
            //DS.Tables[1].TableName = "Branch";


            //if (data_ESI.Rows.Count > 0)
            //{
            //    Str_ESI = data_ESI.Rows[0][0].ToString();
            //    Str_ESI_SLNO = data_ESI.Rows[0][1].ToString();

            //}
            //else
            //{
            //    Str_ESI = "";
            //    ERPMessageBox.ERPMessage.Show("There is no PTAX Head in this Salary Structure");
            //    return;
            //}


        }

        private void cmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Edpcom.CurrentLocation.Trim() != "")
            {
                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + Edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            }
            if (dt.Rows.Count > 0)
            {
                CmbCompany.LookUpTable=dt;
                CmbCompany. ReturnIndex = 1;
                CmbLocation.Text = "";
            }
        }

        private void cmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
            { company_id = Convert.ToInt32(CmbCompany.ReturnValue); }

            BANK_DETAILS();

            chk_multiSelect.Checked = false;
        }
        public void BANK_DETAILS()
        { string cont="";
        DataTable dt = clsDataAccess.RunQDTbl("Select distinct bank,acno,ifsc,BRNCH_ADD1,BRNCH_ADD2,BRNCH_TELE1,Email,Website,Fax,bank_br,bank_br_add,bank_br_code from branch where (GCode='" + company_id + "')");
             if (dt.Rows.Count > 0)
             {
                 TxtBankName.Text = dt.Rows[0]["bank"].ToString();

                 if (TxtBankName.Text.Trim().ToLower() == "sbi" || TxtBankName.Text.Trim().ToLower() == "state bank of india")
                 {
                     rdbCMS.Enabled = true;
                 }
                 else if (TxtBankName.Text.Trim().ToLower() == "hdfc" || TxtBankName.Text.Trim().ToLower() == "hdfc bank" || TxtBankName.Text.Trim().ToLower() == "h.d.f.c")
                 {
                     rdbHDFC.Checked = true;
                 }
                 else if (TxtBankName.Text.Trim().ToLower() == "karur vysya bank" || TxtBankName.Text.Trim().ToLower() == "karur vysya")
                 {
                     rdbKVB.Checked = true;
                 }
                 else if (TxtBankName.Text.Trim().ToLower() == "bob" || TxtBankName.Text.Trim().ToLower() == "bank of baroda")
                 {
                     rdbBob.Checked = true;
                     rdbBob.Visible = true;
                 }
                 else
                 {
                     rdbCMS.Checked = false;
                     rdbCMS.Enabled = false;
                 }


                 lblBnkCode.Text = dt.Rows[0]["bank_br_Code"].ToString();
                 TxtAccountNo.Text = dt.Rows[0]["acno"].ToString();
                 lbl_ifsc.Text = dt.Rows[0]["ifsc"].ToString();
                 if (dt.Rows[0]["bank_br_add"].ToString().Trim() == "")
                 {
                     lblAdd.Text = "";
                 }
                 else
                 {
                     lblAdd.Text = dt.Rows[0]["bank_br_add"].ToString().Trim();
                 }

                 if (dt.Rows[0]["bank_br"].ToString().Trim() == "")
                 {
                     lblBr.Text = "";
                 }
                 else
                 {
                     lblBr.Text = dt.Rows[0]["bank_br"].ToString().Trim();
                 }
                 //BRNCH_TELE1,Email,Website,Fax
                
                 //if (dt.Rows[0]["BRNCH_TELE1"].ToString().Trim() != "")
                 //{
                 cont = "Phone Office :" + dt.Rows[0]["BRNCH_TELE1"].ToString().Trim() + "\n\r" +
                         "Fax                : " + dt.Rows[0]["Fax"].ToString().Trim() + "\n\r" +
                         "E-mail           : " + dt.Rows[0]["Email"].ToString().Trim() + "\n\r" +
                         "Website          : " + dt.Rows[0]["Website"].ToString().Trim();
                 //}
                 //else
                 //{
                 //     cont = "";

                 //}



                 lblContact.Text = cont;
             }

        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            Retrieve_DataEsi();

            if (DT.Rows.Count > 1)
            {
                System.Data.DataTable dtCloned = DT.Clone();
                dtCloned.AcceptChanges();
                foreach (DataRow row in DT.Rows)
                {
                    dtCloned.ImportRow(row);
                }
                dtCloned.AcceptChanges();

                //excel

                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                int iCol = 0;
                foreach (DataColumn c in dtCloned.Columns)
                {
                    iCol++;
                    excel.Cells[1, iCol] = c.ColumnName;
                }
                int iRow = 0;
                foreach (DataRow r in dtCloned.Rows)
                {
                    iRow++;
                    iCol = 0;
                    foreach (DataColumn c in dtCloned.Columns)
                    {
                        try
                        {
                            iCol++;
                            excel.Cells[iRow + 1, iCol] = r[c.ColumnName];
                        }
                        catch
                        {

                        }
                    }

                }
                object missing = System.Reflection.Missing.Value;

                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;

                ((Excel._Worksheet)worksheet).Activate();

                ((Excel._Application)excel).Quit();

                MessageBox.Show("Export To ExcelCompleted!", "Export");
            }
            else
            {
                MessageBox.Show("There is no Record to export to excel!", "Export");
            }

            DT.Dispose();
            DT.Clear();

            // excel
        }

        private void cmbclintname_DropDown(object sender, EventArgs e)
        {
            //DataTable dt = clsDataAccess.RunQDTbl("select Client_Name,Contract_Person from tbl_Employee_CliantMaster");
            //if (dt.Rows.Count > 0)
            //{
            //    cmbclintname.LookUpTable = dt;
            //}
        }

        private void cmbclintname_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            //if (Information.IsNumeric(cmbclintname.ReturnValue) == true)
            //    Client_id = Convert.ToInt32(cmbclintname.ReturnValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            if (CmbCompany.Text.Trim() == "")
            {

                MessageBox.Show("Please select Company Name");


            }
            else
            {
                string s = " select  l.Location_Name,l.Location_ID,(SELECT top 1 Client_Name FROM  tbl_Employee_CliantMaster where client_id=L.Cliant_ID)as ClientName  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID = " + company_id;
                DataTable dt = clsDataAccess.RunQDTbl(s);
                if (dt.Rows.Count > 0)
                {
                    CmbLocation.LookUpTable = dt;
                    CmbLocation.ReturnIndex = 1;
                    //cmbsalstruc.Items.Clear();
                }
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbLocation.ReturnValue) == true)
            {
                Location = Convert.ToString(CmbLocation.ReturnValue);
              
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBankPayment_Load(object sender, EventArgs e)
        {
            chk_multiSelect.Checked = true;
            lbl_ifsc.Text = "";
        this.Text = "Bank Payment Advice";
            //dtpForm.Text = Convert.ToString(edpcom.CURRCO_SDT);
            //dtpto.Text = Convert.ToString(edpcom.CURRCO_EDT);
            //cheDescription.Checked = true;
            //raddetails.Checked = true;
            //radAlphabetically.Checked = true;
            //this.Text = "Stock Statement";
            //txttransaction.Text = "0";
            //txtitem.Text = "0";

            chk_All_Emp.Checked = true;
            chk_multiSelect.Checked = false;
            //dtpidate.Value = System.DateTime.Now;
            clsValidation.GenerateYear(CmbYear, 2015, System.DateTime.Now.Year, 1);
            //set session
            //if (System.DateTime.Now.Month >= 4)
            //{
            //    CmbYear.SelectedIndex = 0;
            //}
            //else
            //{
            //    CmbYear.SelectedIndex = 1;
            //}
            AttenDtTmPkr.Value = DateTime.Now.Date.AddMonths(-1);

            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { CmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    CmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }

            readFile();

            Configuration_Menu_TypeDoc_companySetting();


            CmbCompany.ReadOnlyText = true;

            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                CmbCompany.Text = Convert.ToString(dt_co.Rows[0][0]);

                company_id = Convert.ToInt32(dt_co.Rows[0][1]);

                BANK_DETAILS();

            }
            else if (dt_co.Rows.Count > 1)
            {
                CmbCompany.PopUp();

            }

            btnPreview.Enabled = true;
            chkNC.Checked = false;
            chkNC.Visible = false;
            if (clsDataAccess.ReturnValue("select sal_nc FROM CompanyLimiter") == "1")
            {
                chkNC.Visible = true;
            }
        }

        string issueby = "";
        public void writeFile()
        {
            issueby = TxtDesignation.Text;

            System.IO.File.WriteAllText(startPath + "\\" + setting_type + "\\issueby.txt", issueby);

            System.IO.File.WriteAllText(startPath + "\\" + setting_type + "\\tagline.txt", txtTagline.Text);

        }

        public void readFile()
        {

            startPath = Application.StartupPath;

            string[] type_setting = System.IO.File.ReadAllLines(startPath + "\\type_settings.txt");

            foreach (string line in type_setting)
            {
                if (!line.Contains("*"))
                {
                    setting_type = line;
                }
            }

            issueby = System.IO.File.ReadAllText(startPath + "\\" + setting_type + "\\issueby.txt");


             TxtDesignation.Text=issueby;

             txtTagline.Text = System.IO.File.ReadAllText(startPath + "\\" + setting_type + "\\tagline.txt");



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { CmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    CmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_All_Emp.Checked == true)
            {
                Button1.Enabled = false;
            }
            else
            {
                Button1.Enabled = true;
            }
        }

        private void btnPreview_Click_1(object sender, EventArgs e)
        {
            double count_ift = 0, count_neft = 0, amt_ift = 0, amt_neft = 0;
            writeFile();
            Retrieve_DataEsi();

            //Calling the Crystal Report viewer page 
            MidasReport.Form1 opening = new MidasReport.Form1();
            // Passing records to print page
            if (rdbBob.Checked == true)
            {
                count_ift = 0; count_neft = 0; amt_ift = 0; amt_neft = 0;
                if (tot_employ.Rows.Count > 0)
                {
                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                    excel.Visible = true;
                    Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;

                    excel.Cells[1, 1] = "CUSTOM_DETAILS1";	
                    excel.Cells[1, 2] = "Value Date";
                    excel.Cells[1, 3] = "Message Type";	
                    excel.Cells[1, 4] = "Debit Account No.";	
                    excel.Cells[1, 5] = "Beneficiary Name";	
                    excel.Cells[1, 6] = "Payment Amount";	
                    excel.Cells[1, 7] = "Beneficiary Bank Swift Code / IFSC Code";	
                    excel.Cells[1, 8] = "Beneficiary Account No.";	
                    excel.Cells[1, 9] = "Transaction Type Code";	
                    excel.Cells[1, 10] = "CUSTOM_DETAILS2";	
                    excel.Cells[1, 11] = "CUSTOM_DETAILS3";	
                    excel.Cells[1, 12] = "CUSTOM_DETAILS4";	
                    excel.Cells[1, 13] = "CUSTOM_DETAILS5";	
                    excel.Cells[1, 14] = "CUSTOM_DETAILS6";	
                    excel.Cells[1, 15] = "Remarks";
                    excel.Cells[1, 16] = "Purpose Of Payment";

                    Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 16]);
                    //range.Merge(true);
                    range.Font.Bold = true;
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    range.Columns.AutoFit();
                    range.Rows.AutoFit();

                    int rw = 8, rw1 = 1;
                    for (int ix = 0; ix < tot_employ.Rows.Count; ix++)
                    {
                       
                        rw1++;
                        excel.Cells[rw1, 1] = "";
                        excel.Cells[rw1, 2] = System.DateTime.Now.ToString("dd/MM/yyyy");
                        range = worksheet.get_Range(worksheet.Cells[rw1, 2], worksheet.Cells[rw1, 2]);
                        //range.NumberFormat = "@@/@@/@@@@";
                        //.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                        if (tot_employ.Rows[ix]["Bank_Name"].ToString().Trim().ToLower() == "bob" || tot_employ.Rows[ix]["Bank_Name"].ToString().Trim().ToLower() == "bank of baroda")
                        {
                            excel.Cells[rw1, 3] = "IFT";
                            excel.Cells[rw1, 9] = "IFT";
                            count_ift = count_ift + 1;
                            amt_ift = amt_ift + Convert.ToDouble(tot_employ.Rows[ix]["NetPay"]);
                        }
                        else
                        {
                            excel.Cells[rw1, 3] = "NEFT";
                            excel.Cells[rw1, 9] = "NEFT";

                            count_neft = count_neft + 1;
                            amt_neft = amt_neft + Convert.ToDouble(tot_employ.Rows[ix]["NetPay"]);
                        }
                       
                       
                        range = worksheet.get_Range(worksheet.Cells[rw1, 4], worksheet.Cells[rw1, 4]);
                        range.NumberFormat = "@";
                        excel.Cells[rw1, 4] = TxtAccountNo.Text;
                        

                        excel.Cells[rw1, 5] = tot_employ.Rows[ix]["InFavourof"].ToString().Trim();
                        excel.Cells[rw1, 6] = Convert.ToDouble(tot_employ.Rows[ix]["NetPay"]).ToString("0.00");

                        
                        range = worksheet.get_Range(worksheet.Cells[rw1, 7], worksheet.Cells[rw1, 7]);
                        range.NumberFormat = "@";
                        excel.Cells[rw1, 7] = tot_employ.Rows[ix]["IFSCCODE"].ToString().Trim();

                        
                        range = worksheet.get_Range(worksheet.Cells[rw1, 8], worksheet.Cells[rw1, 8]);
                        range.NumberFormat = "@";
                        excel.Cells[rw1, 8] = tot_employ.Rows[ix]["BankAcountNo"].ToString().Trim();
                        
                        excel.Cells[rw1, 16] = "PAY REIM"; 
                        
                    }

                    
                    

                    range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rw1, 16]);
                    
                    Excel.Borders borders = range.Borders;
                    //Set the thick lines style.
                    borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    borders.Weight = 2d;
                    range.WrapText = true;

                    range.Columns.AutoFit();
                    range.Rows.AutoFit();


                }

                opening.bankpaymentrpt_bob(TxtBankName.Text, TxtAccountNo.Text, CmbCompany.Text, TxtDesignation.Text, txtCity.Text, txtTagline.Text, lblAdd.Text, lblContact.Text, tot_employ, 1, lblBnkCode.Text, Edpcom.UserDesc, count_ift.ToString("00"), count_neft.ToString("00"), amt_ift.ToString("0.00"), amt_neft.ToString("0.00"));
            }
            else
            {
                opening.bankpaymentrpt(TxtBankName.Text, TxtAccountNo.Text, CmbCompany.Text, TxtDesignation.Text, txtCity.Text, txtTagline.Text, lblAdd.Text, lblContact.Text, tot_employ, 1);
            }
            opening.ShowDialog();

            ds.Tables.Clear();
            ds.Dispose();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string month = "";
                //clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

                string sqlstmnt = "";

                if (rdbLoan.Checked==true)
                {
                    month = AttenDtTmPkr.Value.ToString("MMMM/ yyyy");
                    if (chkCompany.Checked == true)
                    {
                        sqlstmnt = "Select (select e.Title+' '+e.FirstName+' '+e.MiddleName+' '+ e.LastName from tbl_Employee_Mast e where e.ID=l.ELEID) as 'EmpName',l.ELEID as 'ID',ELID,ELDT from  tbl_Employee_LOAN l where (l.ELMONTH='" + month + "') and (CoID=" + company_id + ")";
                    }
                    else
                    {
                        if (Location.Trim() == "")
                        {
                            sqlstmnt = "Select (select e.Title+' '+e.FirstName+' '+e.MiddleName+' '+ e.LastName from tbl_Employee_Mast e where e.ID=l.ELEID) as 'EmpName',l.ELEID as 'ID',ELID,ELDT from  tbl_Employee_LOAN l where (l.ELMONTH='" + month + "') (CoID=" + company_id + ")";
                        }
                        else
                        {
                            sqlstmnt = "Select (select e.Title+' '+e.FirstName+' '+e.MiddleName+' '+ e.LastName from tbl_Employee_Mast e where e.ID=l.ELEID) as 'EmpName',l.ELEID as 'ID',ELID,ELDT from  tbl_Employee_LOAN l where (l.ELMONTH='" + month + "') (CoID=" + company_id + ") and (LocID in (" + Location + "))";
                        }
                    }
                }
                else
                {
                    month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

                    if (chkCompany.Checked==true)
                    {
                        sqlstmnt = "Select (select e.Title+' '+e.FirstName+' '+e.MiddleName+' '+ e.LastName from tbl_Employee_Mast e where e.ID=s.emp_id) as 'EmpName',s.emp_id as 'ID',Date_of_Insert from tbl_Employee_SalaryMast s where (s.Month='" + month + "') and (s.Session ='" + CmbYear.Text + "') and (s.Location_id in (select distinct(Location_ID) from Companywiseid_Relation where Company_ID=" + company_id + "))";
                    }
                   else
                    {
                        sqlstmnt = "Select (select e.Title+' '+e.FirstName+' '+e.MiddleName+' '+ e.LastName from tbl_Employee_Mast e where e.ID=s.emp_id) as 'EmpName',s.emp_id as 'ID',Date_of_Insert from tbl_Employee_SalaryMast s where (s.Month='" + month + "') and (s.Session ='" + CmbYear.Text + "') and (s.Location_id= '" + Location + "')";
                      
                    }
                }
                EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Employee", "Select Employee", 0, "CMPN", 0);
                arritm.Clear();
                arritm = EDPCommon.arr_mod;

                if (arritm.Count > 0)
                {
                    getcode_Item.Clear();
                    arritm = EDPCommon.arr_mod;
                    getcode_Item = EDPCommon.get_code;
                    //lblproduct.Items.Clear();
                    Item_code = null;
                    //for (int i = 0; i <= (arritem.Count - 1); i++)
                    //{
                    //    //lblproduct.Items.Add(arritem[i].ToString());
                    //    Item_Code = Item_Code + getcode_item[i].ToString();
                    //    if (i != getcode_item.Count - 1)
                    //    {
                    //        Item_Code = "'" + Item_Code + "'" + "," + "'";
                    //    }
                    //}

                    Item_code = "";

                    for (int i = 0; i <= arritm.Count - 1; i++)
                    {
                        if (Item_code.Trim() == "")
                        {
                            Item_code = "'" + getcode_Item[i].ToString() + "'";
                        }
                        else
                        {
                            Item_code = Item_code + ",'" + getcode_Item[i].ToString() + "'";
                        }
                    }


                }


            }
            catch { }
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnMultiLocation_Click(object sender, EventArgs e)
        {
            try
            {
                string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

                string sqlstmnt = " select  l.Location_Name,l.Location_ID,(SELECT top 1 Client_Name FROM  tbl_Employee_CliantMaster where client_id=L.Cliant_ID)as ClientName  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID = " + company_id;
                EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Location", "Select Location", 0, "CMPN", 0);
                arritm.Clear();
                arritm = EDPCommon.arr_mod;

                if (arritm.Count > 0)
                {
                    getcode_Item.Clear();
                    arritm = EDPCommon.arr_mod;
                    getcode_Item = EDPCommon.get_code;
                    //lblproduct.Items.Clear();
                    Location = null;
                    //for (int i = 0; i <= (arritem.Count - 1); i++)
                    //{
                    //    //lblproduct.Items.Add(arritem[i].ToString());
                    //    Item_Code = Item_Code + getcode_item[i].ToString();
                    //    if (i != getcode_item.Count - 1)
                    //    {
                    //        Item_Code = "'" + Item_Code + "'" + "," + "'";
                    //    }
                    //}

                    Location = "";

                    for (int i = 0; i <= arritm.Count - 1; i++)
                    {
                        if (Location.Trim() == "")
                        {
                            Location =  "'" + getcode_Item[i].ToString() + "'";

                        }
                        else
                        {
                            Location = Location + "," + "'" + getcode_Item[i].ToString() + "'";
                        }
                    }


                }


            }
            catch { }
        }

        private void chk_multiSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_multiSelect.Checked == true)
            {
                btnMultiLocation.Enabled = true;
                CmbLocation.Enabled = false;
                chkCompany.Checked = false;
            }
            else
            {
                btnMultiLocation.Enabled = false;
                CmbLocation.Enabled = true;
            }
        }
        public string ConvertNumbertoWords(long number)
        {
            if (number == 0) return "Zero";
            if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " Lakh ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " Thousand ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " Hundred ";
                number %= 100;
            }
            //if ((number / 10) > 0)  
            //{  
            // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
            // number %= 10;  
            //}  
            if (number > 0)
            {
                if (words != "") words += "AND ";
                var unitsMap = new[]   
                {  
                    "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"  
                };
                var tensMap = new[]   
                {  
                    "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"  
                };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }  
        private void vistaButton1_Click_1(object sender, EventArgs e)
        {
            double tot = 0;
            if (rdbBankLetter.Checked == true)
            {
                if (rdbXL1.Checked == true)
                {
                    Retrieve_DataEsi();
                    DataTable dtLoc = new DataTable();
                    if (chkCompany.Checked == false)
                    {
                        dtLoc = clsDataAccess.RunQDTbl("select l.Location_ID,(l.Location_Name +' - '+ (SELECT top 1 Client_Name FROM  tbl_Employee_CliantMaster where client_id=L.Cliant_ID)) as ClientName  from tbl_Emp_Location l where (location_id in (" + Location + "))");
                    }
                    else
                    {
                        dtLoc = clsDataAccess.RunQDTbl("select l.Location_ID,(l.Location_Name +' - '+ (SELECT top 1 Client_Name FROM  tbl_Employee_CliantMaster where client_id=L.Cliant_ID)) as ClientName  from tbl_Emp_Location l where (location_id in (select distinct(Location_ID) from Companywiseid_Relation where Company_ID=" + company_id + "))");

                    }
                    string loc = "";
                    if (rdbSalary.Checked == true)
                    {
                        for (int ix = 0; ix < dtLoc.Rows.Count; ix++)
                        {
                            if (loc == "")
                            {
                                loc = dtLoc.Rows[ix]["ClientName"].ToString().Trim();
                            }
                            else
                            {
                                loc = loc + "," + dtLoc.Rows[ix]["ClientName"].ToString().Trim();
                            }
                        }

                    }
                    else
                    {
                        string lc_old = "", lc_new = "";

                        for (int ix = 0; ix < tot_employ.Rows.Count; ix++)
                        {
                            lc_new = tot_employ.Rows[ix]["ClientName"].ToString().Trim() + " - " + tot_employ.Rows[ix]["locname"].ToString().Trim();
                            if (lc_new.Trim().ToLower() != lc_old.Trim().ToLower())
                            {
                                lc_old = lc_new;
                                if (loc == "")
                                {
                                    loc = lc_new;
                                        //dtLoc.Rows[ix]["ClientName"].ToString().Trim() + " - " + dtLoc.Rows[ix]["locname"].ToString().Trim();
                                }
                                else
                                {
                                    loc = loc + "," + lc_new;
                                        //dtLoc.Rows[ix]["ClientName"].ToString().Trim() + " - " + dtLoc.Rows[ix]["locname"].ToString().Trim();
                                }
                            }
                        }
                        

                    }
                    tot = 0;
                    if (tot_employ.Rows.Count > 0)
                    {
                        Excel.Application excel = new Excel.Application();
                        Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                        excel.Visible = true;
                        int iCol = 0;
                        string words = "";
                        Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;

                        excel.Cells[1, 1] = "Amount";
                        excel.Cells[1, 2] = "Debit Account No";
                        excel.Cells[1, 3] = "IFSC Code";
                        excel.Cells[1, 4] = "Beneficiary a/c No";
                        excel.Cells[1, 5] = "Name of Beneficiary";
                        excel.Cells[1, 6] = "SITE NAME";
                        excel.Cells[1, 7] = "Debit a/c name";
                        excel.Cells[1, 8] = "In favour of";
                        Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 8]);
                        //range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();

                        int rw = 8, rw1 = 1;
                        for (int ix = 0; ix < tot_employ.Rows.Count; ix++)
                        {
                            tot = tot + Convert.ToDouble(tot_employ.Rows[ix]["NetPay"].ToString());

                            rw1++;
                            excel.Cells[rw1, 1] = Convert.ToDouble(tot_employ.Rows[ix]["NetPay"]);
                            
                            range = worksheet.get_Range(worksheet.Cells[rw1, 2], worksheet.Cells[rw1, 2]);
                            range.NumberFormat = "@";

                            excel.Cells[rw1, 2] = TxtAccountNo.Text.Trim().ToString();

                            excel.Cells[rw1, 3] = tot_employ.Rows[ix]["IFSCCODE"].ToString().Trim();
                            
                            range = worksheet.get_Range(worksheet.Cells[rw1, 4], worksheet.Cells[rw1, 4]);
                            range.NumberFormat = "@";
                            excel.Cells[rw1, 4] = tot_employ.Rows[ix]["BankAcountNo"].ToString().Trim();
                            excel.Cells[rw1, 5] = tot_employ.Rows[ix]["EmpName"].ToString().Trim();
                            excel.Cells[rw1, 6] = tot_employ.Rows[ix]["locname"].ToString().Trim() + " - " + tot_employ.Rows[ix]["ClientName"].ToString().Trim();
                            excel.Cells[rw1, 7] = CmbCompany.Text;
                            excel.Cells[rw1, 8] = tot_employ.Rows[ix]["InFavourof"].ToString().Trim();
                        }

                        words = "Rupees " + ConvertNumbertoWords((long)Convert.ToDouble(tot)) + " Only";
                        rw1++;
                        excel.Cells[rw1, 1] = tot;
                        rw1++;
                        excel.Cells[rw1, 1] = words;

                        range = worksheet.get_Range(worksheet.Cells[rw1, 1], worksheet.Cells[rw1, 8]);
                        range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();

                        range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rw1, 8]);
                        Excel.Borders borders = range.Borders;
                        //Set the thick lines style.
                        borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        borders.Weight = 2d;
                        range.WrapText = true;

                        range.Columns.AutoFit();
                        range.Rows.AutoFit();


                        DataTable dt_sal = new DataTable();
                        dt_sal.Columns.Add("bank");
                        dt_sal.Columns.Add("bAdd");
                        dt_sal.Columns.Add("location");
                        dt_sal.Columns.Add("month");
                        dt_sal.Columns.Add("accno");
                        dt_sal.Columns.Add("amt");
                        dt_sal.Columns.Add("inwords");
                        dt_sal.Columns.Add("company");
                        dt_sal.Columns.Add("signature");
                        if (chkCompany.Checked == true)
                        {
                            loc = "All Locations";

                        }

                        dt_sal.Rows.Add();
                        dt_sal.Rows[0]["bank"] = TxtBankName.Text;
                        dt_sal.Rows[0]["bAdd"] = lblBr.Text.Trim() + Environment.NewLine + lblAdd.Text.Trim();
                        dt_sal.Rows[0]["location"] = loc;
                        dt_sal.Rows[0]["month"] = AttenDtTmPkr.Value.ToString("MMMM,yyyy");
                        dt_sal.Rows[0]["accno"] = TxtAccountNo.Text;
                        dt_sal.Rows[0]["amt"] = tot;
                        dt_sal.Rows[0]["inwords"] = "";
                        dt_sal.Rows[0]["company"] = CmbCompany.Text;
                        dt_sal.Rows[0]["signature"] = TxtDesignation.Text;

                        MidasReport.Form1 opening = new MidasReport.Form1();
                        // Passing records to print page
                        opening.bank_letter(TxtBankName.Text, TxtAccountNo.Text, CmbCompany.Text, TxtDesignation.Text, txtCity.Text, txtTagline.Text, lblAdd.Text, lblContact.Text, dt_sal, 1);

                        opening.ShowDialog();
                    }
                }
                else if (rdbKVB.Checked == true )
                {
                    string strssql = "";
                    string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
                    string yr = Convert.ToString(AttenDtTmPkr.Value.Year);
                    if (chkNC.Checked == true)
                    {
                        strssql = "(select sum(Amount) from  tbl_Employee_SalaryDetails where  (Month='" + month + "') and (Session='" + CmbYear.Text + "') and (Location_id='" + Location + "') and " +
                        "SalId in (select  SAL_HEAD from tbl_Employee_Assign_SalStructure where NCompliance='1' and location_id='" + Location + "') " +
                        "and  EmpId=s.Emp_Id)  as Amount ";
                    }
                    else
                    {
                        strssql = " s.NetPay as Amount";
                    }
                    tot_employ = clsDataAccess.RunQDTbl("select (case when Lower(e.Bank_Name)='karur vysya bank' then 'INTERNAL TRANSFER' else 'NEFT TRANSFER' end)'Transfer Type','" + TxtAccountNo.Text + "' as 'Debting Account No',GMIno as 'Bene IFSC Code',e.BankAcountNo as 'Bene A/C No.'," +
 "(case when isNull(e.bankAc_name,'')='' then ((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) else e.bankAc_name end) as 'Bene Name',"+
 "'' as 'Bene Add Line 1','' as 'Bene Add Line 2','' as 'Bene Add Line 3','' as 'Bene Add line 4','' as 'Txn Ref No', "+strssql+ ", 'Salary "+AttenDtTmPkr.Value.ToString("MMMM yyyy")+"' as 'Sender To Rcvr Info','SAVING ACCOUNT' as 'Add Info 1/ Account Type',''as 'Add Info 2/Mobile Number',''as 'Add Info 3/ MMID',	" +
 "(case when isNull(e.bankAc_name,'')='' then ((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) else e.bankAc_name end) as 'Add Info 4' "+
 "from tbl_Employee_Mast e inner join tbl_Employee_SalaryMast s on e.ID=s.Emp_Id  where (s.Location_id= '" + CmbLocation.ReturnValue + "') and (s.Month='" + AttenDtTmPkr.Value.ToString("MMMM") + "') and (s.Session ='" + CmbYear.Text + "') and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1) and (s.netpay<>0)");



                    if (tot_employ.Rows.Count > 0 )
                    {
                        Excel.Application excel = new Excel.Application();
                        Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                        excel.Visible = true;
                        int iCol = 0, iRow = 0, rw1 = tot_employ.Rows.Count;
                        string vtot = clsDataAccess.ReturnValue("select SUM(s.NetPay) from tbl_Employee_Mast e inner join tbl_Employee_SalaryMast s on e.ID=s.Emp_Id  where (s.Location_id= '" + CmbLocation.ReturnValue + "') and (s.Month='" + AttenDtTmPkr.Value.ToString("MMMM") + "') and (s.Session ='" + CmbYear.Text + "') and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1)");
                        string vcount = clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Mast e inner join tbl_Employee_SalaryMast s on e.ID=s.Emp_Id  where (s.Location_id= '" + CmbLocation.ReturnValue + "') and (s.Month='" + AttenDtTmPkr.Value.ToString("MMMM") + "') and (s.Session ='" + CmbYear.Text + "') and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1)");
                        string words = "";
                        Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;


                        excel.Cells[1, 1] = "Karur Vysya Bank Bulk Upload Sheet";
                        Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 3]);
                        range.Merge(true);
                        range.Font.Size = 8;
                        //range.Width = 45;
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();

                        excel.Cells[1, 4] = "Bulk Upload Date";
                        excel.Cells[2, 4] = DateTime.Now.ToString("dd/MM/yyyy");


                        excel.Cells[1, 5] = "Total Amount";
                        excel.Cells[2, 5] = vtot;


                        excel.Cells[1, 6] = "Record Count";
                        excel.Cells[2, 6] = vcount;


                        excel.Cells[3, 1] = "Ordering Customer Name ";
                        range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, 3]);
                        range.Merge(true);

                        excel.Cells[3, 4] = CmbCompany.Text;
                        range = worksheet.get_Range(worksheet.Cells[3, 4], worksheet.Cells[3, 6]);
                        range.Merge(true);

                        range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, 6]);
                        
                        range.Font.Size = 8;
                        //range.Width = 45;
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();

                        excel.Cells[3, 7] = "Address Line1";
                        excel.Cells[3, 8] = CmbLocation.Text;
                        range = worksheet.get_Range(worksheet.Cells[3, 8], worksheet.Cells[3, 10]);

                        range.Font.Size = 8;
                        //range.Width = 45;
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();


                        excel.Cells[3, 11] = "Address Line2";
                        excel.Cells[3, 12] = "";

                        excel.Cells[3, 13] = "Address Line3";
                        excel.Cells[3, 14] = "";


                        iCol = 1; iRow = 5;
                        for (int ihd = 0; ihd < tot_employ.Columns.Count; ihd++)
                        {

                            excel.Cells[iRow, iCol] = tot_employ.Columns[ihd].ColumnName;

                            iCol++;
                        }

                        range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, 16]);
                        //range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();

                        iCol = 1; iRow = 6;
                        for (int idx = 0; idx < tot_employ.Rows.Count; idx++)
                        {
                            iCol = 1;
                            for (int ihd = 0; ihd < tot_employ.Columns.Count; ihd++)
                            {
                                if (ihd == 9)
                                {
                                    excel.Cells[iRow, iCol] = idx + 1;
                                }
                                else if (ihd == 10)
                                {
                                    excel.Cells[iRow, iCol] = tot_employ.Rows[idx][ihd].ToString();
                                }
                                else
                                {
                                    range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                    range.NumberFormat = "@";
                                    excel.Cells[iRow, iCol] = tot_employ.Rows[idx][ihd].ToString();
                                }
                                iCol++;
                            }
                            iRow++;
                        }


                        range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[iRow, 16]);
                        Excel.Borders borders = range.Borders;
                        //Set the thick lines style.
                        borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        range.Font.Size = 8;
                        borders.Weight = 2d;
                        range.WrapText = true;
                        range.Select();
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();
                        MessageBox.Show("Record Exported","Bravo");

                    }
                }
                else if (rdbHDFC.Checked == true)
                {
                    string strssql = "",str_tot="";
                    string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
                    string yr = Convert.ToString(AttenDtTmPkr.Value.Year);
                    if (chkNC.Checked == true)
                    {
                        strssql = "(select sum(Amount) from  tbl_Employee_SalaryDetails where  (Month='" + month + "') and (Session='" + CmbYear.Text + "') and (Location_id='" + Location + "') and " +
                        "SalId in (select  SAL_HEAD from tbl_Employee_Assign_SalStructure where NCompliance='1' and location_id='" + Location + "') " +
                        "and  EmpId=s.Emp_Id)  as Amount ";
                        str_tot ="select sum(Amount) from  tbl_Employee_SalaryDetails where  (Month='" + month + "') and (Session='" + CmbYear.Text + "') and (Location_id='" + Location + "') and " +
                        "SalId in (select  SAL_HEAD from tbl_Employee_Assign_SalStructure where NCompliance='1' and location_id='" + Location + "') ";
                    }
                    else
                    {
                        strssql = " s.NetPay as Amount";
                        str_tot = "select SUM(s.NetPay) from tbl_Employee_Mast e inner join tbl_Employee_SalaryMast s on e.ID=s.Emp_Id  where (s.Location_id= '" + CmbLocation.ReturnValue + "') and (s.Month='" + AttenDtTmPkr.Value.ToString("MMMM") + "') and (s.Session ='" + CmbYear.Text + "') and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1)";
                    }

                    tot_employ = clsDataAccess.RunQDTbl("select '' as 'Transaction Ref.No',"+strssql+",'" + DateTime.Now.ToString("dd/MM/yyyy") + "' as 'Value Date','" + lblBnkCode.Text + "' as 'Branch Code','CURRENT' as 'Sender A/C Type','" + TxtAccountNo.Text + "' as 'Remitter A/c No',(select c.co_name from Company c where c.CO_CODE=S.Company_id ) as 'Remitter Name'," +
 "GMIno as 'IFSC CODE','" + TxtAccountNo.Text + "' as 'Debit Account',e.Bank_AC_Type as 'Beneficiary A/c.type',e.BankAcountNo as 'Bank A/c Number'," +
 "(case when isNull(e.bankAc_name,'')='' then ((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) else e.bankAc_name end) as 'Beneficiary Name','SALARY' AS 'Remittance Details','" + TxtAccountNo.Text + "' as 'Debit A/c System'," +
 "(select c.co_name from Company c where c.CO_CODE=S.Company_id ) as 'Originator Of Remmittance' " +
    "from tbl_Employee_Mast e inner join tbl_Employee_SalaryMast s on e.ID=s.Emp_Id  where (s.Location_id= '" + CmbLocation.ReturnValue + "') and (s.Month='" + AttenDtTmPkr.Value.ToString("MMMM") + "') and (s.Session ='" + CmbYear.Text + "') and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1) and (s.netpay<>0)");


                    if (tot_employ.Rows.Count > 0)
                    {
                        Excel.Application excel = new Excel.Application();
                        Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                        excel.Visible = true;
                        int iCol = 0, iRow = 0, rw1 = tot_employ.Rows.Count;
                        string vtot = clsDataAccess.ReturnValue(str_tot);
                        string words = "";
                        Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;

                        iCol = 1; iRow = 1;
                        for (int ihd = 0; ihd < tot_employ.Columns.Count; ihd++)
                        {

                            excel.Cells[iRow, iCol] = tot_employ.Columns[ihd].ColumnName;

                            iCol++;
                        }

                        Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 15]);
                        //range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();

                        iCol = 1; iRow = 2;
                        for (int idx = 0; idx < tot_employ.Rows.Count; idx++)
                        {
                            iCol = 1;
                            for (int ihd = 0; ihd < tot_employ.Columns.Count; ihd++)
                            {
                                if (ihd == 0)
                                {
                                    excel.Cells[iRow, iCol] = idx + 1;
                                }
                                else if (ihd == 1)
                                {
                                    excel.Cells[iRow, iCol] = tot_employ.Rows[idx][ihd].ToString();
                                    range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                    range.NumberFormat = "0";
                                }
                                else if (ihd == 2)
                                {
                                    excel.Cells[iRow, iCol] = tot_employ.Rows[idx][ihd].ToString();
                                    
                                }
                                else if (ihd == 5 || ihd == 8 || ihd == 10 || ihd == 13)
                                {
                                    range = worksheet.get_Range(worksheet.Cells[iRow, iCol], worksheet.Cells[iRow, iCol]);
                                    range.NumberFormat = "@";
                                    excel.Cells[iRow, iCol] = tot_employ.Rows[idx][ihd].ToString();

                                }
                                else
                                {

                                        excel.Cells[iRow, iCol] = tot_employ.Rows[idx][ihd].ToString();

                                    


                                }
                                iCol++;
                            }
                            iRow++;
                        }

                        excel.Cells[iRow, 2] = vtot;
                        range = worksheet.get_Range(worksheet.Cells[iRow, 2], worksheet.Cells[iRow, 2]);
                        range.NumberFormat = "0";

                        range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[iRow, 15]);
                        Excel.Borders borders = range.Borders;
                        //Set the thick lines style.
                        borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        borders.Weight = 2d;
                        range.WrapText = true;
                        range.Select();
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();
                        MessageBox.Show("Record Exported", "Bravo");

                    }
                }

                else if (rdbXL2.Checked == true)
                {
                    Retrieve_DataEsi();


                    tot = 0;
                    if (tot_employ.Rows.Count > 0)
                    {
                        Excel.Application excel = new Excel.Application();
                        Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                        excel.Visible = true;
                        int iCol = 0;
                        string words = "";
                        Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;

                        excel.Cells[1, 1] = "Transaction Type";
                        excel.Cells[1, 2] = "Beneficiary Code";
                        excel.Cells[1, 3] = "Value Date";
                        excel.Cells[1, 4] = "Debit A/C Number";
                        excel.Cells[1, 5] = "Transaction Amount";
                        excel.Cells[1, 6] = "Beneficiary Name";
                        excel.Cells[1, 7] = "Beneficiary  A/c No.";
                        excel.Cells[1, 8] = "IFSC Code";
                        excel.Cells[1, 9] = "Beneficiary Email ID";
                        excel.Cells[1, 10] = "Beneficiary Mobile No";
                        excel.Cells[1, 11] = "Customer Ref No.";
                        excel.Cells[1, 12] = "Payment Narration";



                        Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 12]);
                        //range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();

                        int rw = 8, rw1 = 1;
                        for (int ix = 0; ix < tot_employ.Rows.Count; ix++)
                        {
                            tot = tot + Convert.ToDouble(tot_employ.Rows[ix]["NetPay"].ToString());

                            rw1++;
                            excel.Cells[rw1, 1] = "N";//Transaction Type

                            excel.Cells[rw1, 2] = ""; //Beneficiary Code

                            excel.Cells[rw1, 3] = "'" + System.DateTime.Now.ToString("dd-MM-yyyy");//Value Date
                            range = worksheet.get_Range(worksheet.Cells[rw1, 4], worksheet.Cells[rw1, 4]);
                            range.NumberFormat = "@";
                            excel.Cells[rw1, 4] = TxtAccountNo.Text.Trim().ToString();//Debit A/C Number
                            range = worksheet.get_Range(worksheet.Cells[rw1, 4], worksheet.Cells[rw1, 4]);
                            range.NumberFormat = "#";
                            excel.Cells[rw1, 5] = Convert.ToDouble(tot_employ.Rows[ix]["NetPay"]).ToString("0.00");//Transaction Amount
                            excel.Cells[rw1, 6] = tot_employ.Rows[ix]["InFavourof"].ToString().Trim();//Beneficiary Name
                            
                            range = worksheet.get_Range(worksheet.Cells[rw1, 7], worksheet.Cells[rw1, 7]);
                            range.NumberFormat = "@";
                            excel.Cells[rw1, 7] = tot_employ.Rows[ix]["BankAcountNo"].ToString().Trim();//Beneficiary  A/c No.
                            range = worksheet.get_Range(worksheet.Cells[rw1, 7], worksheet.Cells[rw1, 7]);
                            range.NumberFormat = "#";
                            excel.Cells[rw1, 8] = tot_employ.Rows[ix]["IFSCCODE"].ToString().Trim();//IFSC Code

                            excel.Cells[rw1, 9] = tot_employ.Rows[ix]["EMail"].ToString().Trim(); //Beneficiary Email ID
                            excel.Cells[rw1, 10] = tot_employ.Rows[ix]["MOBILE"].ToString().Trim();//Beneficiary Mobile No
                            excel.Cells[rw1, 11] = tot_employ.Rows[ix]["ID"].ToString().Trim();//Customer Ref No.
                            excel.Cells[rw1, 12] = tot_employ.Rows[ix]["locname"].ToString().Trim() + "_" + AttenDtTmPkr.Value.ToString("MMM_yyyy"); //Payment Narration


                        }


                        //range = worksheet.get_Range(worksheet.Cells[rw1, 1], worksheet.Cells[rw1, 12]);
                        //range.Merge(true);
                        //range.Font.Bold = true;
                        //range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
                        //range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        //range.Columns.AutoFit();
                        //range.Rows.AutoFit();

                        range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rw1, 12]);
                        Excel.Borders borders = range.Borders;
                        //Set the thick lines style.
                        borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        borders.Weight = 2d;
                        range.WrapText = true;
                        range.Select();
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();
                    }
                    //Transaction Type
                    //Beneficiary Code
                    //Value Date
                    //Debit A/C Number
                    //Transaction Amount
                    //Beneficiary Name
                    //Beneficiary  A/c No.
                    //IFSC Code
                    //Beneficiary Email ID
                    //Beneficiary Mobile No
                    //Customer Ref No.
                    //Payment Narration


                }
                else if (rdbXL3.Checked == true)
                {
                    Retrieve_DataEsi();


                    tot = 0;
                    if (tot_employ.Rows.Count > 0)
                    {
                        Excel.Application excel = new Excel.Application();
                        Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                        excel.Visible = true;
                        int iCol = 0;
                        string words = "";
                        Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;

                        excel.Cells[1, 1] = "Debit A/c No";
                        excel.Cells[1, 2] = "Beneficiary A/c No";
                        excel.Cells[1, 3] = "Beneficiary Name";
                        excel.Cells[1, 4] = "Amount";
                        excel.Cells[1, 5] = "Payment Mode (I=FT, N=NEFT, R=RTGS)";
                        excel.Cells[1, 6] = "Date(DD-MMM-YYYY)";
                        excel.Cells[1, 7] = "IFSC";
                        excel.Cells[1, 8] = "Payable Location";
                        excel.Cells[1, 9] = "Print Location";
                        excel.Cells[1, 10] = "Beneficiary Mobile";
                        excel.Cells[1, 11] = "Beneficiary Email";
                        excel.Cells[1, 12] = "Beneficiary Address 1";
                        excel.Cells[1, 13] = "Beneficiary Address 2";
                        excel.Cells[1, 14] = "Beneficiary Address 3";
                        excel.Cells[1, 15] = "Beneficiary Address 4";
                        excel.Cells[1, 16] = "Additional details 1";
                        excel.Cells[1, 17] = "Additional details 2";
                        excel.Cells[1, 18] = "Additional details 3";
                        excel.Cells[1, 19] = "Additional details 4";
                        excel.Cells[1, 20] = "Additional details 5";
                        excel.Cells[1, 21] = "Remarks";

                        Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 21]);
                        //range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();

                        int rw = 8, rw1 = 1;
                        for (int ix = 0; ix < tot_employ.Rows.Count; ix++)
                        {
                            tot = tot + Convert.ToDouble(tot_employ.Rows[ix]["NetPay"].ToString());

                            rw1++;

                            range = worksheet.get_Range(worksheet.Cells[rw1, 1], worksheet.Cells[rw1, 1]);
                            range.NumberFormat = "@";
                            excel.Cells[rw1, 1] =  TxtAccountNo.Text.Trim().ToString();//Debit A/c No
                            
                            range = worksheet.get_Range(worksheet.Cells[rw1, 2], worksheet.Cells[rw1, 2]);
                            
                            range.NumberFormat = "@";
                            excel.Cells[rw1, 2] =  tot_employ.Rows[ix]["BankAcountNo"].ToString().Trim();//Beneficiary A/c No
                            
                            excel.Cells[rw1, 3] = tot_employ.Rows[ix]["InFavourof"].ToString().Trim();//Beneficiary Name
                            excel.Cells[rw1, 4] = Convert.ToDouble(tot_employ.Rows[ix]["NetPay"]).ToString("0.00");//Amount
                            excel.Cells[rw1, 5] = "N"; //Payment Mode (I=FT, N=NEFT, R=RTGS)
                            excel.Cells[rw1, 6] = "'" + System.DateTime.Now.ToString("dd-MMM-yyyy").ToUpper();//Date(DD-MMM-YYYY)	
                            excel.Cells[rw1, 7] = tot_employ.Rows[ix]["IFSCCODE"].ToString().Trim();//IFSC Code
                            excel.Cells[rw1, 8] = "";//Payable Location	

                            excel.Cells[rw1, 9] = ""; //Print Location
                            excel.Cells[rw1, 10] = tot_employ.Rows[ix]["MOBILE"].ToString().Trim();//Beneficiary Mobile No
                            excel.Cells[rw1, 11] = tot_employ.Rows[ix]["EMail"].ToString().Trim();//Beneficiary Email
                            excel.Cells[rw1, 12] = "";//Beneficiary Address 1

                            excel.Cells[rw1, 13] = "";//Beneficiary Address 2
                            excel.Cells[rw1, 14] = "";//Beneficiary Address 3
                            excel.Cells[rw1, 15] = "";//Beneficiary Address 4
                            excel.Cells[rw1, 16] = "";//Additional details 1
                            excel.Cells[rw1, 17] = "";//Additional details 2
                            excel.Cells[rw1, 18] = "";//Additional details 3
                            excel.Cells[rw1, 19] = "";//Additional details 4
                            excel.Cells[rw1, 20] = "";//Additional details 5
                            excel.Cells[rw1, 21] = "";//Remarks


                        }


                        range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rw1, 21]);
                        Excel.Borders borders = range.Borders;
                        //Set the thick lines style.
                        borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        borders.Weight = 2d;
                        range.WrapText = true;
                        range.Select();
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();
                    }
                    //Debit A/c No
                    //Beneficiary A/c No
                    //Beneficiary Name
                    //Amount	
                    //Payment Mode (I=FT, N=NEFT, R=RTGS)	
                    //Date(DD-MMM-YYYY)	
                    //IFSC	
                    //Payable Location	
                    //Print Location
                    //Beneficiary Mobile
                    //Beneficiary Email
                    //Beneficiary Address 1
                    //Beneficiary Address 2
                    //Beneficiary Address 3
                    //Beneficiary Address 4
                    //Additional details 1
                    //Additional details 2
                    //Additional details 3
                    //Additional details 4
                    //Additional details 5
                    //Remarks

                }
                else if (rdbBL.Checked == true)
                {
                    btnPreview_Click_1(sender, e);
                }
                else if (rdbBob.Checked == true)
                {
                    btnPreview_Click_1(sender, e);

                }
                else if (rdbCMS.Checked == true)
                {
                    string condt = "", emp_condt = "", sqry = "'' as 'ref','' as 'narration'", file1 = "", file2 = "", remarks = "";
                    DataTable tot_employ_neft = new DataTable();
                    StringBuilder sb = new StringBuilder();
                    string fst = TxtAccountNo.Text.Trim() + "#" + lbl_ifsc.Text.Trim() + "#" + System.DateTime.Now.ToString("dd/MM/yyyy") + "#" + tot + "##";
                    if (chkCompany.Checked == true)
                    {

                        condt = "(Location_id in (select distinct(Location_ID) from Companywiseid_Relation where Company_ID=" + company_id + ")) ";
                    }
                    else
                    {
                        condt = "(Location_id in (" + Location + ")) ";

                    }
                    emp_condt = "";
                    if (chk_All_Emp.Checked == false)
                    {
                        emp_condt = " and ( Emp_Id in (" + Item_code + "))";

                    }

                    //   tot_employ = clsDataAccess.RunQDTbl("select row_number() over(partition by e.id order by e.ID) as Slno," +
                    //"((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) as 'ENAME'," +
                    //"e.Bank_Name as 'BankName',e.Branch_Name as 'BranchName',e.BankAcountNo as 'BankAcNo',GMIno as 'Ifsc','" +
                    //System.DateTime.Now.ToString("dd/MM/yyyy") + "#' as dt,s.[NETPay],'' as 'ref','' as 'narration','' as 'neft' from tbl_Employee_Mast e," +
                    //"(select Emp_Id, sum(NetPay) as 'NETPay' from tbl_Employee_SalaryMast where "+ condt +" and (Month='" +
                    //AttenDtTmPkr.Value.ToString("MMMM") + "') and (Session ='" + CmbYear.Text.Trim() + "') group by Emp_Id)s where (e.ID=s.Emp_Id)  and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1)");


                    tot_employ = clsDataAccess.RunQDTbl("select row_number() over(order by e.ID) as Slno," +
                                     "((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) as 'ENAME'," +
                                     "e.Bank_Name as 'BankName',e.Branch_Name as 'BranchName',e.BankAcountNo as 'BankAcNo',Right(GMIno,5) as 'Ifsc','" +
                                     System.DateTime.Now.ToString("dd/MM/yyyy") + "' as dt,s.[NETPay]," + sqry + ",'SBI' as 'neft' from tbl_Employee_Mast e," +
                                     "(select Emp_Id, sum(NetPay) as 'NETPay' from tbl_Employee_SalaryMast where  " + condt + " and (Month='" +
                                     AttenDtTmPkr.Value.ToString("MMMM") + "') and (Session ='" + CmbYear.Text.Trim() + "')" + emp_condt + " group by Emp_Id)s where (e.ID=s.Emp_Id)  and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1) and ({ fn LCASE(e.Bank_Name)} in ('sbi','state bank of india')) and (s.netpay<>0)");

                    tot_employ_neft = clsDataAccess.RunQDTbl("select row_number() over(order by e.ID) as Slno," +
                 "((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) as 'ENAME'," +
                 "e.Bank_Name as 'BankName',e.Branch_Name as 'BranchName',e.BankAcountNo as 'BankAcNo',GMIno as 'Ifsc','" +
                 System.DateTime.Now.ToString("dd/MM/yyyy") + "' as dt,s.[NETPay]," + sqry + ",'NEFT' as 'neft' from tbl_Employee_Mast e," +
                 "(select Emp_Id, sum(NetPay) as 'NETPay' from tbl_Employee_SalaryMast where " + condt + " and (Month='" +
                 AttenDtTmPkr.Value.ToString("MMMM") + "') and (Session ='" + CmbYear.Text.Trim() + "')" + emp_condt + " group by Emp_Id)s where (e.ID=s.Emp_Id)  and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1) and ({ fn LCASE(e.Bank_Name)} not in ('sbi','state bank of india'))  and (s.netpay<>0)");




                    tot = 0;
                    file1 = "";
                    if (tot_employ.Rows.Count > 0)
                    {

                        for (int ix = 0; ix < tot_employ.Rows.Count; ix++)
                        {
                            tot = tot + Convert.ToDouble(tot_employ.Rows[ix]["NetPay"].ToString());
                            if (file1.Trim() == "")
                            {
                                file1 = Environment.NewLine + tot_employ.Rows[ix]["BankAcNo"].ToString().Trim() + "#" +
                                tot_employ.Rows[ix]["Ifsc"].ToString().Trim() + "#" + tot_employ.Rows[ix]["dt"].ToString().Trim() + "##" +
                                Convert.ToDouble(tot_employ.Rows[ix]["NETPay"]).ToString("0").Trim() + "#" + CmbLocation.Text.Trim() + " SAL FINAL" + "#" + CmbLocation.Text.Trim() + " " + AttenDtTmPkr.Value.ToString("MMM yy") + " SAL FINAL#";
                            }
                            else
                            {

                                file1 = file1 + Environment.NewLine + tot_employ.Rows[ix]["BankAcNo"].ToString().Trim() + "#" +
                             tot_employ.Rows[ix]["Ifsc"].ToString().Trim() + "#" + tot_employ.Rows[ix]["dt"].ToString().Trim() + "##" +
                              Convert.ToDouble(tot_employ.Rows[ix]["NETPay"]).ToString("0").Trim() + "#" + CmbLocation.Text.Trim() + " SAL FINAL" + "#" + CmbLocation.Text.Trim() + " " + AttenDtTmPkr.Value.ToString("MMM yy") + " SAL FINAL#";
                            }
                        }

                        remarks = TxtAccountNo.Text.Trim() + "#" + lbl_ifsc.Text.Trim().Substring(lbl_ifsc.Text.Trim().Length - 5) + "#" + System.DateTime.Now.ToString("dd/MM/yyyy") + "#" + tot + "##" + CmbLocation.Text.Trim() + " " + AttenDtTmPkr.Value.ToString("MMM yy") + " SAL";



                        saveFileDialog1.FileName = CmbLocation.Text.Trim() + " " + AttenDtTmPkr.Value.ToString("MMM yy") + " SAL FINAL ON " + System.DateTime.Now.ToString("dd.MM.yyyy") + " TXT";
                        saveFileDialog1.ShowDialog();
                        string fpath = saveFileDialog1.FileName;

                        string filePath = fpath;
                        if (!File.Exists(filePath))
                        {
                            File.Create(filePath).Close();
                        }
                        File.AppendAllText(filePath, (remarks + file1).ToString());
                        MessageBox.Show("File Created at : " + fpath, "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    tot = 0;
                    file2 = "";
                    if (tot_employ_neft.Rows.Count > 0)
                    {

                        for (int ix = 0; ix < tot_employ_neft.Rows.Count; ix++)
                        {
                            tot = tot + Convert.ToDouble(tot_employ_neft.Rows[ix]["NetPay"].ToString());
                            if (file2.Trim() == "")
                            {
                                file2 = Environment.NewLine + tot_employ_neft.Rows[ix]["BankAcNo"].ToString().Trim() + "#" +
                                tot_employ_neft.Rows[ix]["Ifsc"].ToString().Trim() + "#" + tot_employ_neft.Rows[ix]["dt"].ToString().Trim() + "##" +
                               Convert.ToDouble(tot_employ_neft.Rows[ix]["NETPay"]).ToString("0").Trim() + "#" + CmbLocation.Text.Trim() + " " + AttenDtTmPkr.Value.ToString("MMM yy") + " SAL NEFT" + "#" + CmbLocation.Text.Trim() + " " + AttenDtTmPkr.Value.ToString("MMM yy") + " SAL NEFT#NEFT";
                            }
                            else
                            {
                                file2 = file2 + Environment.NewLine + tot_employ_neft.Rows[ix]["BankAcNo"].ToString().Trim() + "#" +
                            tot_employ_neft.Rows[ix]["Ifsc"].ToString().Trim() + "#" + tot_employ_neft.Rows[ix]["dt"].ToString().Trim() + "##" +
                            Convert.ToDouble(tot_employ_neft.Rows[ix]["NETPay"]).ToString("0").Trim() + "#" + CmbLocation.Text.Trim() + " " + AttenDtTmPkr.Value.ToString("MMM yy") + " SAL NEFT" + "#" + CmbLocation.Text.Trim() + " " + AttenDtTmPkr.Value.ToString("MMM yy") + " SAL NEFT#NEFT";

                            }
                        }

                        remarks = TxtAccountNo.Text.Trim() + "#" + lbl_ifsc.Text.Trim().Substring(lbl_ifsc.Text.Trim().Length - 5) + "#" + System.DateTime.Now.ToString("dd/MM/yyyy") + "#" + tot + "##" + CmbLocation.Text.Trim() + " " + AttenDtTmPkr.Value.ToString("MMM yy") + " SAL NEFT";



                        saveFileDialog1.FileName = CmbLocation.Text.Trim() + " " + AttenDtTmPkr.Value.ToString("MMM yy") + " SAL NEFT ON " + System.DateTime.Now.ToString("dd.MM.yyyy") + " TXT";
                        saveFileDialog1.ShowDialog();
                        string fpath = saveFileDialog1.FileName;

                        string filePath = fpath;
                        if (!File.Exists(filePath))
                        {
                            File.Create(filePath).Close();
                        }
                        File.AppendAllText(filePath, (remarks + file2).ToString());
                        MessageBox.Show("File Created at : " + fpath, "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void TxtBankName_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select distinct bank,acno,ifsc,bank_br,bank_br_add,bank_br_code from branch where (GCode='" + company_id + "') and (acno!='')");
            if (dt.Rows.Count > 0)
            {
                TxtBankName.LookUpTable = dt;
                TxtBankName.ReturnIndex = 1;
                //cmbsalstruc.Items.Clear();
            }
        }

        private void TxtBankName_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            string cont = "";
            lbl_ifsc.Text = "";
            rdbBob.Visible = false;
            DataTable dt = clsDataAccess.RunQDTbl("Select distinct bank,acno,ifsc,BRNCH_ADD1,BRNCH_ADD2,BRNCH_TELE1,Email,Website,Fax,bank_br,bank_br_add,bank_br_code from branch where (GCode='" + company_id + "') and (acno='" + TxtBankName.ReturnValue + "')");
            if (dt.Rows.Count > 0)
            {
                TxtBankName.Text = dt.Rows[0]["bank"].ToString();

                if (TxtBankName.Text.Trim().ToLower() == "sbi" || TxtBankName.Text.Trim().ToLower() == "state bank of india")
                {
                    rdbCMS.Enabled = true;
                }
                else if (TxtBankName.Text.Trim().ToLower() == "hdfc" || TxtBankName.Text.Trim().ToLower() == "hdfc bank" || TxtBankName.Text.Trim().ToLower() == "h.d.f.c")
                {
                    rdbHDFC.Checked = true;
                }
                else if (TxtBankName.Text.Trim().ToLower().Contains("indusind") || TxtBankName.Text.Trim().ToLower() == "indusind bank" || TxtBankName.Text.Trim().ToLower() == "indusind")
                {
                    rdbXL2.Checked = true;
                }
                else if (TxtBankName.Text.Trim().ToLower().Contains("icici") || TxtBankName.Text.Trim().ToLower() == "icici" || TxtBankName.Text.Trim().ToLower() == "icici bank")
                {
                    rdbXL3.Checked = true;
                }
                else if (TxtBankName.Text.Trim().ToLower() == "karur vysya bank" || TxtBankName.Text.Trim().ToLower() == "karur vysya") 
                {
                    rdbKVB.Checked = true;
                }
                else if (TxtBankName.Text.Trim().ToLower() == "bob" || TxtBankName.Text.Trim().ToLower() == "bank of baroda")
                {
                    rdbBob.Checked = true;
                    rdbBob.Visible = true;
                }
                else
                {
                    rdbCMS.Checked = false;
                    rdbCMS.Enabled = false;
                }
                lblBnkCode.Text = dt.Rows[0]["bank_br_code"].ToString();
                TxtAccountNo.Text = dt.Rows[0]["acno"].ToString();
                lbl_ifsc.Text = dt.Rows[0]["ifsc"].ToString();
                if (dt.Rows[0]["bank_br_add"].ToString().Trim() == "")
                {
                    lblAdd.Text = "";
                }
                else
                {
                    lblAdd.Text = dt.Rows[0]["bank_br_add"].ToString().Trim();
                }

                if (dt.Rows[0]["bank_br"].ToString().Trim() == "")
                {
                    lblBr.Text = "";
                }
                else
                {
                    lblBr.Text = dt.Rows[0]["bank_br"].ToString().Trim();
                }
                

            }
        }

        private void chkCompany_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkCompany.Checked == true)
            {
                chk_multiSelect.Checked = false;
                CmbLocation.Enabled = false;
                btnMultiLocation.Enabled = false;
            }
            else
            {
                if (rdbSalary.Checked == true)
                CmbLocation.Enabled = true;

            }
        }

        private void rdbBankLetter_CheckedChanged(object sender, EventArgs e)
        {
           
            if (rdbBankLetter.Checked == true)
            {
                btnPreview.Enabled = true;

            }
           
        }

        private void rdbCMS_CheckedChanged(object sender, EventArgs e)
        {
            chkCompany.Enabled = true;
            chk_multiSelect.Enabled = true;
            btnMultiLocation.Enabled = true;
            if (rdbCMS.Checked == true)
            {
                btnPreview.Enabled = false;
                chkCompany.Checked = false;
                chkCompany.Enabled = true;
                chk_multiSelect.Checked = false;
                chk_multiSelect.Enabled = true;
                btnMultiLocation.Enabled = false;
                chk_multiSelect.Checked = true;
            }
        }

        private void rdbSalary_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLoan.Checked == true)
            {
                CmbLocation.Text = "";
                chkCompany.Checked = true;
                chk_multiSelect.Checked = false;
                CmbLocation.Enabled = true;
                chk_multiSelect.Enabled = true;
                btnMultiLocation.Enabled = false;
                rdbCMS.Enabled = false;
                rdbCMS.Checked = false;
            }
            else if (rdbAdvance.Checked == true)
            {
                CmbLocation.Text = "";
                chkCompany.Checked = true;
                chk_multiSelect.Checked = false;
                CmbLocation.Enabled = true;
                chk_multiSelect.Enabled = true;
                btnMultiLocation.Enabled = false;
                rdbCMS.Enabled = false;
                rdbCMS.Checked = false;

            }
            else
            {
                chkCompany.Checked = true;
                CmbLocation.Enabled = true;
                chk_multiSelect.Enabled = true;
                btnMultiLocation.Enabled = true;
                rdbCMS.Enabled = true;
            }
        }

       


        

      
       


    }

}
