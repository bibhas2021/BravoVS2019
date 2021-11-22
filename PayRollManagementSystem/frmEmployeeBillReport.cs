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
    public partial class frmEmployeeBillReport : MstFrmDialog
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        string Item_Code = "", Tentry_code = "";
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataSet ds_img = new DataSet();
        DataTable dt = new DataTable();
        string Frm_Type = "";
        int Head_Cou = 0;
        string Locations = "";
        int Company_id = 0, Location_id=0;

        string current_company;
        string address = "";
        string address1 = "";
        string pan;
        string DURATION;
        string sq1;

        ArrayList arritem = new ArrayList();
        string arrayItem = "";
        //Hashtable getcode = new Hashtable();
        Hashtable getcode_Group = new Hashtable();
        Hashtable getcode_item = new Hashtable();


        string company = "", Agentadd = "", Agentadd1 = "", phone = "", Area = "", BillDate = "", User_Voucher = "";
        string challan = "", challandt = "", AmtWord = "", narrsn = "";
        string conName = "", ConAdd1 = "", Conadd2 = "";
        string amtvalue = "";
        string lorry_no = "", locname = "", modtranport = "", prtyname = "", prtyadd1 = "", prtyadd2 = "", prtycity = "", prtyctypin = "", prtytele1 = "", prtytele2 = "", prtyfax = "", prtyemail = "", prtyeccno = "", prtytin = "";
        string partycodeeee = "";
        string tentry = "", FinalAmount = "", Refvoucher = "";

        public frmEmployeeBillReport(string type)
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
            this.lblTitle.Text = "Bill Print";
            //dtpForm.Text = Convert.ToString(edpcom.CURRCO_SDT);
            //dtpto.Text = Convert.ToString(edpcom.CURRCO_EDT);
            //cheDescription.Checked = true;
            //raddetails.Checked = true;
            //radAlphabetically.Checked = true;
            //this.Text = "Stock Statement";
            //txttransaction.Text = "0";
            //txtitem.Text = "0";


            //dtpidate.Value = System.DateTime.Now;
            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }

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
            Retrive_DataESI();
            MidasReport.Form1 opening = new MidasReport.Form1();
            opening.paybill_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1);

            opening.ShowDialog();

            ds.Tables.Clear();
            ds.Dispose();
        }
        public void Printheader()
        {

            DataSet dsBRANCH = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();

            edpcon.Close();
            edpcon.Open();
            dsBRANCH.Clear();
            cmd = new SqlCommand("select b.BRNCH_ADD1,b.BRNCH_ADD2,b.BRNCH_CITY,s.State_Name,b.BRNCH_PIN,b.BRNCH_PAN1 FROM BRANCH b,StateMaster s WHERE b.FICODE=" + edpcom.CurrentFicode + " AND b.GCODE=" + edpcom.PCURRENT_GCODE + " AND b.BRNCH_CODE=0 and s.STATE_CODE=b.BRNCH_STATE ", edpcon.mycon);
            //edpcon.mycon.Open();

            adp.SelectCommand = cmd;

            try
            {
                adp.Fill(dsBRANCH, "BR");

                DURATION = "As On : " + "" + dateTimePicker1.Value.ToShortDateString() + "";


                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][0]) != "")
                    address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][0]) + ",";

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]) != "")
                    address = address + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]);


                address1 = "";
                if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                    address1 = address1 + " - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                    address1 = address1 + ", " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                    address1 = address + " - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() == ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]) + "," + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]) + ", PIN No. - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() == ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() == ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    address1 = "PIN No. - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                }
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][5]) != "")
                    pan = "PAN No. : " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][5]);
                else
                    pan = "";

                string query = "select co_name from company where ficode='" + edpcom.CurrentFicode + "' and Gcode='" + edpcom.PCURRENT_GCODE + "'";
                DataTable dtre = RunQDTbl(query);
                current_company = (dtre.Rows[0][0].ToString());
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
            Retrive_DataESI();
            MidasReport.Form1 opening = new MidasReport.Form1();
            opening.paybill_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2);

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

                Report_Header[0] = edpcom.CURRENT_COMPANY;
                Report_Header[1] = "P.TAX Report for the location " + cmbLocation.Text;
                Report_Header[2] = "Session " + cmbYear.SelectedItem;//" ";
                Report_Header[3] = " For the month of  " + dateTimePicker1.Text;//+ Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString();

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

                Report_Page_Header[0] = "Pay Slip for the location " + cmbLocation.Text;
                Report_Page_Header[1] = "Session " + cmbYear.SelectedItem + " For the month of  " + dateTimePicker1.Text;

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
                    TopVal = "1,1,1,1,1,1";
                    WidthVal = "8,70,70,60,60";
                    HeightVal = "4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0";
                    AlignVal = "L,L,L,L,L";
                    Head_width = 300;
                }

                else if (Head_Cou == 6)
                {
                    TopVal = "1,1,1,1,1,1";
                    WidthVal = "8,70,40,40,40,40";
                    HeightVal = "4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L";
                    Head_width = 300;
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


        

        private void Retrive_Data()
        {

            string Str_ErHead_basic="";
            DataTable ErHead_basic = clsDataAccess.RunQDTbl("select top 1  SalaryHead_Short from tbl_Employee_ErnSalaryHead");
            Str_ErHead_basic = ErHead_basic.Rows[0][0].ToString ();
            
            string Str_PF="";
            DataTable data_PF = clsDataAccess.RunQDTbl("select SalaryHead_Short from tbl_Employee_DeductionSalayHead d,tbl_Employee_Assign_SalStructure e,tbl_Employee_Link_SalaryStructure l where d.SlNo=e.SAL_HEAD and e.PF_PER=1 and e.SAL_STRUCT=l.SalaryStructure_ID and Location_ID = '" + Location_id + "'");
            Str_PF = data_PF.Rows[0][0].ToString();

            Boolean flug_deduction = false;
            //string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

            string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

            DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,(select pf.PF_Code from Companywiseid_Relation pf where pf.location_id='" + Location_id + "' ) as 'PF NO',sm.Emp_Id as ID,'" + cmbLocation.Text + "' as 'Site'  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + cmbLocation.Text + "' and em.ID = sm.Emp_Id");

            if (tot_employ.Rows.Count > 0)
            {
                DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Location_id + "' order by Slno");
                DataView dv = new DataView(salary_details);
                int table_count = tot_employ.Columns.Count;

                tot_employ.Rows.Add();
                int dt_count = tot_employ.Rows.Count;
                tot_employ.Rows.Add();
                tot_employ.Rows.Add();

                int counter = 0;

                tot_employ.Columns.Add("Employer (3.67%)", typeof(string));
                tot_employ.Columns.Add("EPFBasic", typeof(string));
                tot_employ.Columns.Add("EPS(8.33%)", typeof(string));

                for (int i = 0; i <= tot_employ.Rows.Count - 4; i++)
                {
                    dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' ";

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
                                tot_employ.Columns.Add(Salary_Head, typeof(string));
                                tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                                tot_employ.Rows[dt_count - 1][Salary_Head] = "---------------";
                                tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                            }
                            else if (Salary_Head == Str_ErHead_basic)
                            {
                                tot_employ.Columns.Add(Salary_Head, typeof(string));
                                tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                                if (Convert.ToDouble((tot_employ.Rows[i][Salary_Head])) > 15000)
                                {
                                    tot_employ.Rows[i]["EPFBasic"] = 15000;
                                }
                                else
                                {
                                    tot_employ.Rows[i]["EPFBasic"] = Convert.ToDouble(tot_employ.Rows[i][Salary_Head]);
                                }

                                tot_employ.Rows[i]["EPS(8.33%)"] = string.Format("{0:F}", Convert.ToDouble(System.Math.Round((((Convert.ToDouble(tot_employ.Rows[i][Salary_Head])) * 8.33) / 100), 0)));
                                tot_employ.Rows[dt_count - 1][Salary_Head] = "---------------";
                                tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                            }

                        }
                        else
                        {
                            string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                            if (Salary_Head == Str_PF)
                            {
                                tot_employ.Rows[i][j + 8] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count][j + 8] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][j + 8]) + Convert.ToDouble(dv[j]["Amount"]));
                            }
                            else if (Salary_Head == Str_ErHead_basic)
                            {
                                tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                                if (Convert.ToDouble((tot_employ.Rows[i][Salary_Head])) > 15000)
                                {
                                    tot_employ.Rows[i]["EPFBasic"] = 15000;
                                }
                                else
                                {
                                    tot_employ.Rows[i]["EPFBasic"] = Convert.ToDouble(tot_employ.Rows[i][Salary_Head]);
                                }

                                tot_employ.Rows[i]["EPS(8.33%)"] = string.Format("{0:F}", Convert.ToDouble(System.Math.Round((((Convert.ToDouble(tot_employ.Rows[i][Salary_Head])) * 8.33) / 100), 0)));


                                tot_employ.Rows[dt_count - 1][Salary_Head] = "---------------";
                                tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                            }

                        }
                    }

                    tot_employ.Rows[dt_count - 1]["BA"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["EPFBasic"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["EPS(8.33%)"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["Employer (3.67%)"] = "---------------";


                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["BA"]) == false)
                        tot_employ.Rows[dt_count]["BA"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPFBasic"]) == false)
                        tot_employ.Rows[dt_count]["EPFBasic"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPS(8.33%)"]) == false)
                        tot_employ.Rows[dt_count]["EPS(8.33%)"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["Employer (3.67%)"]) == false)
                        tot_employ.Rows[dt_count]["Employer (3.67%)"] = 0;

                    tot_employ.Rows[dt_count + 1]["BA"] = "========";
                    tot_employ.Rows[dt_count + 1]["EPFBasic"] = "========";
                    tot_employ.Rows[dt_count + 1]["EPS(8.33%)"] = "========";
                    tot_employ.Rows[dt_count + 1]["Employer (3.67%)"] = "========";

                    tot_employ.Rows[i]["sl"] = i + 1;

                    tot_employ.Rows[dt_count]["BA"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["BA"]) + Convert.ToDouble(tot_employ.Rows[i]["BA"]));
                    tot_employ.Rows[dt_count]["EPFBasic"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPFBasic"]) + Convert.ToDouble(tot_employ.Rows[i]["EPFBasic"]));
                    tot_employ.Rows[dt_count]["EPS(8.33%)"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPS(8.33%)"]) + Convert.ToDouble(tot_employ.Rows[i]["EPS(8.33%)"]));
                    tot_employ.Rows[i]["Employer (3.67%)"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[i]["PF"]) - Convert.ToDouble(tot_employ.Rows[i]["EPS(8.33%)"]));
                    tot_employ.Rows[dt_count]["Employer (3.67%)"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Employer (3.67%)"]) + Convert.ToDouble(tot_employ.Rows[i]["Employer (3.67%)"]));

                }

                tot_employ.Columns["BA"].SetOrdinal(table_count - 1);
                tot_employ.Columns["EPFBasic"].SetOrdinal(tot_employ.Columns.Count - 1);
                tot_employ.Columns["EPS(8.33%)"].SetOrdinal(tot_employ.Columns.Count - 1);

                tot_employ.Columns.Remove("ID");

                tot_employ.Columns["BA"].SetOrdinal(4);
                tot_employ.Columns["EPFBasic"].SetOrdinal(5);
                tot_employ.Columns["PF"].SetOrdinal(6);
                tot_employ.Columns["EPS(8.33%)"].SetOrdinal(7);
                tot_employ.Columns["Employer (3.67%)"].SetOrdinal(8);

                tot_employ.Columns["PF"].ColumnName = "Employee Contribution (12%)";

                dt = tot_employ.Copy();

                dt.AcceptChanges();
                Head_Cou = dt.Columns.Count;
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
            string[] blno = Item_Code.Split(',');
            string strssql = "";
            string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
            DataTable tot_employ= new DataTable("");
            DataTable tot_employ_main = new DataTable("");
            foreach (string billcode in blno)
            {
                if (billcode.Trim() != "''")
                {
                    strssql = "";
                    strssql = strssql + " select h.BILLNO,CONVERT(VARCHAR(10),h.BILLDATE,103) as BILLDATE,(select c.co_name from Company c where c.CO_CODE=h.Comany_id ) as 'coname',";
                    strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=h.Comany_id ) as 'Add1',(select distinct BRNCH_TELE1 from Branch B where B.GCODE=h.Comany_id ) as 'Add2',";
                    strssql = strssql + " (select Location_Name from tbl_Emp_Location where Location_ID=d.Location_ID ) as 'locname',h.Month,h.Session,h.TotAMT ,h.IsService,h.ServiceAmount,";
                    strssql = strssql + " d.Attendance ,d.BILLAMT,d.Dtl_id ,d.Hour,d.MonthDays,d.RATE,(select e.DesignationName  from tbl_Employee_DesignationMaster e where e.SlNo=d.desig_ID )as 'designation'";
                    strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) ) as 'ClientName'";
                    strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) )  as 'ClientCity'";
                    strssql = strssql + " ,(select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) ) as 'Contract_Person'";

                    strssql = strssql + " ,(select c.Contract_No  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) ) as 'Contract_No'";
                    strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) )) AS mis1,";
                    strssql = strssql + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) ) AS mis2,";
                    strssql = strssql + " '' AS mis3,'' AS mis4,'' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,'' AS mis10,(SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "') as Cmpimage";

                    strssql = strssql + " from paybill h inner join paybillD d on h.BILLNO=d.BILLNO";
                    strssql = strssql + " where h.Session='" + cmbYear.Text + "' and d.Month ='" + month + "'";
                    strssql = strssql + " and d.Location_id = '" + Location_id + "' and h.Comany_id='" + Company_id + "'";

                    if (checkBox1.Checked == false)
                    {
                        strssql = strssql + " and h.BILLNO in (" + billcode + ") ";
                    }

                    tot_employ = clsDataAccess.RunQDTbl(strssql);
                    //  DataRow destRow= new DataRow();
                    DataTable dtimage = clsDataAccess.RunQDTbl("SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "' ");
                    DataTable Ord = clsDataAccess.RunQDTbl("Select OCHARGES,ORate,OQty,OAMT,BILLNO from paybillO where BILLNO in (" + billcode + ") ");
                    for (int rw_ord = 0; rw_ord < Ord.Rows.Count; rw_ord++)
                    {
                        DataRow destRow = tot_employ.NewRow();

                        destRow[0] = tot_employ.Rows[0][0];
                        destRow[1] = tot_employ.Rows[0][1];
                        destRow[2] = tot_employ.Rows[0][2];
                        destRow[3] = tot_employ.Rows[0][3];
                        destRow[4] = tot_employ.Rows[0][4];
                        destRow[5] = tot_employ.Rows[0][5];
                        destRow[6] = tot_employ.Rows[0][6];
                        destRow[7] = tot_employ.Rows[0][7];
                        destRow[8] = tot_employ.Rows[0][8];
                        destRow["designation"] = Ord.Rows[rw_ord]["OCHARGES"];
                        destRow[9] = tot_employ.Rows[0][9];
                        destRow[10] = tot_employ.Rows[0][10];
                        destRow[11] = Ord.Rows[rw_ord]["OQty"];//tot_employ.Rows[0][11];
                        destRow["BILLAMT"] = Ord.Rows[rw_ord]["OAMT"];
                        destRow[13] = tot_employ.Rows[0][13];
                        destRow[14] = tot_employ.Rows[0][14];
                        destRow[15] = tot_employ.Rows[0][15];
                        destRow[16] = Ord.Rows[rw_ord]["ORate"];//tot_employ.Rows[0][16];
                        //destRow[17] = tot_employ.Rows[0][17];
                        destRow[18] = tot_employ.Rows[0][18];
                        destRow[19] = tot_employ.Rows[0][19];
                        destRow[20] = tot_employ.Rows[0][20];
                        destRow[21] = tot_employ.Rows[0][21];
                        destRow[22] = tot_employ.Rows[0][22];
                        destRow[23] = tot_employ.Rows[0][23];
                        destRow[24] = tot_employ.Rows[0][24];
                        destRow[25] = tot_employ.Rows[0][25];
                        destRow[26] = tot_employ.Rows[0][26];
                        destRow[27] = tot_employ.Rows[0][27];
                        destRow[28] = tot_employ.Rows[0][28];
                        destRow[29] = tot_employ.Rows[0][29];
                        destRow[30] = tot_employ.Rows[0][30];
                        destRow[31] = tot_employ.Rows[0][31];
                        destRow[32] = tot_employ.Rows[0][32];


                        tot_employ.Rows.Add(destRow);
                        
                    }
                    tot_employ_main.Merge(tot_employ);
                     Ord = clsDataAccess.RunQDTbl("Select ScPer,ScAmt from paybill where IsSC='True' and BILLNO in (" + billcode + ")");
                    for (int rw_ord = 0; rw_ord < Ord.Rows.Count; rw_ord++)
                    {
                        DataRow destRow = tot_employ.NewRow();

                        destRow[0] = tot_employ.Rows[0][0];
                        destRow[1] = tot_employ.Rows[0][1];
                        destRow[2] = tot_employ.Rows[0][2];
                        destRow[3] = tot_employ.Rows[0][3];
                        destRow[4] = tot_employ.Rows[0][4];
                        destRow[5] = tot_employ.Rows[0][5];
                        destRow[6] = tot_employ.Rows[0][6];
                        destRow[7] = tot_employ.Rows[0][7];
                        destRow[8] = tot_employ.Rows[0][8];
                        destRow["designation"] = "Service Charge @ " + Ord.Rows[rw_ord]["SCPer"] + " % ";
                        destRow[9] = tot_employ.Rows[0][9];
                        destRow[10] = tot_employ.Rows[0][10];
                        destRow[11] = Ord.Rows[rw_ord]["OQty"];//tot_employ.Rows[0][11];
                        destRow["BILLAMT"] = Ord.Rows[rw_ord]["ScAmt"];
                        destRow[13] = tot_employ.Rows[0][13];
                        destRow[14] = tot_employ.Rows[0][14];
                        destRow[15] = tot_employ.Rows[0][15];
                        destRow[16] = "";//tot_employ.Rows[0][16];
                        //destRow[17] = tot_employ.Rows[0][17];
                        destRow[18] = tot_employ.Rows[0][18];
                        destRow[19] = tot_employ.Rows[0][19];
                        destRow[20] = tot_employ.Rows[0][20];
                        destRow[21] = tot_employ.Rows[0][21];
                        destRow[22] = tot_employ.Rows[0][22];
                        destRow[23] = tot_employ.Rows[0][23];
                        destRow[24] = tot_employ.Rows[0][24];
                        destRow[25] = tot_employ.Rows[0][25];
                        destRow[26] = tot_employ.Rows[0][26];
                        destRow[27] = tot_employ.Rows[0][27];
                        destRow[28] = tot_employ.Rows[0][28];
                        destRow[29] = tot_employ.Rows[0][29];
                        destRow[30] = tot_employ.Rows[0][30];
                        destRow[31] = tot_employ.Rows[0][31];
                        destRow[32] = tot_employ.Rows[0][32];


                        tot_employ.Rows.Add(destRow);

                    }
                    tot_employ_main.Merge(tot_employ);
                   
                }
            }
            ds.Tables.Add(tot_employ_main);
            ds.Tables[0].TableName = "paybill";
            //ds.Tables.Add(Ord);
            //ds.Tables[1].TableName = "paybillO";
           
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

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
                cmbLocation.Text = "";
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
            Retrive_DataESI();

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

            dt.Dispose();
            dt.Clear();

            // excel
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

                string sqlstmnt = "Select distinct s.BILLNO as 'BillNo',s.BILLNO as 'BillNo',s.BILLDATE as 'BillDate' from paybilld s where s.Month='" + month + "' and s.Session ='" + cmbYear.Text + "' and company_ID = '" + Company_id + "' and s.Location_id= '" + Location_id + "'";
                EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Bill", "Select Bill", 0, "CMPN", 0);

                arritem.Clear();
                arritem = EDPCommon.arr_mod;

                if (arritem.Count > 0)
                {
                    getcode_item.Clear();
                    arritem = EDPCommon.arr_mod;
                    getcode_item = EDPCommon.get_code;

                    Item_Code = null;
                    Item_Code = "''";

                    for (int i = 0; i <= arritem.Count - 1; i++)
                    {
                        Item_Code = Item_Code + "," + "'" + getcode_item[i].ToString() + "'";

                    }

                }
            }
            catch { }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                cmbLocation.Text = "";

                s = " select  l.Location_Name,l.Location_ID  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID = '" + Company_id + "'";
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
                Location_id = Convert.ToInt32(cmbLocation.ReturnValue);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }


    }

}