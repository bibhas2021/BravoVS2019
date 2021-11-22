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

namespace PayRollManagementSystem
{
    public partial class frmEmployeeCompositePaySlipRpt : EDPComponent.FormBaseRptMidium
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
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        string Frm_Type = "";
        int Head_Cou = 0, cdoj = 0, cWD_MOD = 0;
        string Locations = "";
        int Company_id = 0;

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
        //021115

        DataTable billing = new DataTable();
        string tentry = "", FinalAmount = "", Refvoucher = "";
        //string current_company = "", address = "", address1 = "", pan = "", DURATION = "", TinNo1 = "";
        string company = "", Agentadd = "", Agentadd1 = "", phone = "", Area = "", BillDate = "", User_Voucher = "";
        string challan = "", challandt = "", AmtWord = "", narrsn = "";
        string conName = "", ConAdd1 = "", Conadd2 = "";
        string amtvalue = "";
        string lorry_no = "", locname = "", modtranport = "", prtyname = "", prtyadd1 = "", prtyadd2 = "", prtycity = "", prtyctypin = "", prtytele1 = "", prtytele2 = "", prtyfax = "", prtyemail = "", prtyeccno = "", prtytin = "";
        string partycodeeee = "";

        //021115

        public frmEmployeeCompositePaySlipRpt(string type)
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
            this.Text = "Composite Pay Slip";
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
            checkBox1.Checked = true;

            //set session

            AttenDtTmPkr.Value = DateTime.Now.AddMonths(-1);
            cmbcompany.PopUp();


            cWD_MOD = 0; cdoj = 0; // designation wise mod

            try
            {
                cWD_MOD = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select desgday from CompanyLimiter")));
            }
            catch
            {
                cWD_MOD = 0;
            }
            try
            {
                cdoj = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select ps_hide_doj from CompanyLimiter")));
            }
            catch
            {
                cdoj = 0;
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
            //Retrive_DataESI();
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
            if (button1.Enabled == true)
            {
                retreive_data1();
            }
            else
            Retrive_Data();
            company = cmbcompany.Text;
            //Printheader();
            MidasReport.Form1 opening = new MidasReport.Form1();
            //opening.CompositePayslip_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, AttenDtTmPkr.Value.ToString("yyyy"));

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

                DURATION = "As On : " + "" + AttenDtTmPkr.Value.ToShortDateString() + "";


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
            if (button1.Enabled == true)
            {
                retreive_data1();
            }
            else
                Retrive_Data();
            company = cmbcompany.Text;
            //Printheader();
            MidasReport.Form1 opening = new MidasReport.Form1();
           // opening.CompositePayslip_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2,AttenDtTmPkr.Value.ToString("yyyy"));

          //  opening.ShowDialog();

            ds.Tables.Clear();
            ds.Dispose();
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
                Report_Header[1] = "Pay Slip for the location " + cmbsalstruc.SelectedItem;
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

                Report_Page_Header[0] = "Pay Slip for the location " + cmbsalstruc.SelectedItem;
                Report_Page_Header[1] = "Session " + cmbYear.SelectedItem + " For the month of  " + AttenDtTmPkr.Text;

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


        private void cmbsalstruc_DropDown(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                cmbsalstruc.Items.Clear();
                //////s = "select  l.Location_Name  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls where l.Location_ID = ls.Location_ID and Location_ID = '" + get_LocationID(cmbsalstruc.Text) + "'";
                s = " select  l.Location_Name  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID = '" + get_CompID(cmbcompany.Text) + "'";
               
                Load_Data1(s, cmbsalstruc, -1);
                //clear_txt();
            }
            catch (Exception x) { }
        }
        public int get_LocationID(string name)
        {
            
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select Location_ID from tbl_Emp_Location where Location_Name='" + name + "'"; //MBE WATER PROJECT'
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
            if (cmbsalstruc.Text=="")
            {
                ERPMessageBox.ERPMessage.Show("Location  must be entered");
                return ;
            }
            else
            {
                Locations = Convert.ToString(get_LocationID(cmbsalstruc.Text));
            }
        }

        private void Retrive_Data()
        {
            Boolean flug_deduction = false;
            //string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.id)  as Rank,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.TotalSal as varchar(50)) Total_Earning,cast(sm.TotalDec as varchar(50)) Total_Deduction,cast(sm.NetPay as varchar(50)) Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");

            string strsql = "";
            //strsql = "SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.id)  as Rank,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.TotalSal as varchar(50)) Total_Earning,cast(sm.TotalDec as varchar(50)) Total_Deduction,cast(sm.NetPay as varchar(50)) Net_Pay ,sd.EmpId,sd.SalId,sd.TableName,sd.Slno,sd.Amount, ";
            //strsql = strsql + "em.FathTitle,em.FathFN,em.FathMN,em.FathLN,em.MothTitle,em.MothFN,em.MothMN,em.MothLN,";
            //strsql = strsql + "em.HusTitle,em.HusFN,em.HusMN,em.HusLN,CAST(convert(datetime, em.DateOfBirth ,103) AS DATETIME) as 'DateOfBirth',em.MaritalStatus,em.Gender,em.DesgId,";
            //strsql = strsql + "em.JobType,em.PresentAddress,em.PermanentAddress,em.STD,em.Phone,em.Mobile,em.PANno,em.PassportNo,";
            //strsql = strsql + "em.PF,em.PenssionNo,em.EDLI,em.ESIno,CAST(convert(datetime,em.DateOfJoining ,103) AS DATETIME) as 'DateOfJoining',em.DateOfRetirement,em.GMIno,";
            //strsql = strsql + "em.PenssionDate,em.EmailId,em.salid,em.SecId,em.EmpWorkingStatus,em.Presentbuilding,em.Presentstreet,";
            //strsql = strsql + "em.Presentareia,em.Presentcity,em.Presentpin,em.Presentstate,em.Presentcountry,em.Permanentbuilding,";
            //strsql = strsql + "em.Permanentstreet,em.Permanentareia,em.Permanentcity,em.Permanentpin,em.Permanentstate,em.Permanentcountry,em.Religion,em.Location_id,em.Company_id,em.PF_Deduction,";
            //strsql = strsql + "cm.CO_CODE,cm.CO_NAME,cm.CO_ADD,cm.CO_ADD1,(select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=sd.Location_id ) as 'LocationName',sd.Session as 'Session','' as 'Misc','' as 'Misc2','' as 'Misc3'";
            //strsql = strsql + " FROM tbl_Employee_SalaryDet sd inner join tbl_Employee_Mast em on sd.EmpId=em.ID inner join tbl_Employee_SalaryMast sm on  em.ID = sm.Emp_Id ";
            //strsql = strsql + "inner join company cm on sd.Company_id=cm.CO_CODE ";
            //strsql = strsql + "where sd.Session='" + cmbYear.Text + "' and sd.Month ='" + month + "' and sd.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' order by Slno";


            //311015

            //  **  strsql = " SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,";
            //strsql = strsql + "sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,";
            //strsql = strsql + "(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as Rank,";
            //strsql = strsql + "sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,";
            //strsql = strsql + "cast(sm.TotalSal as numeric(18,0)) Total_Earning,cast(sm.TotalDec as varchar(50)) Total_Deduction,cast(sm.NetPay as varchar(50)) Net_Pay ,";
            ////--sd.EmpId,sd.SalId,sd.TableName,sd.Slno,sd.Amount, "
            //strsql = strsql + "em.FathTitle,em.FathFN,em.FathMN,em.FathLN,em.MothTitle,em.MothFN,em.MothMN,em.MothLN,em.HusTitle,em.HusFN,em.HusMN,em.HusLN,CAST(convert(datetime, em.DateOfBirth ,103) AS DATE) as 'DateOfBirth',em.MaritalStatus,em.Gender,em.DesgId,em.JobType,em.PresentAddress,em.PermanentAddress,em.STD,em.Phone,em.Mobile,em.PANno,em.PassportNo,em.PF,em.PenssionNo,em.EDLI,em.ESIno,CAST(convert(datetime,em.DateOfJoining ,103) AS DATE) as 'DateOfJoining',em.DateOfRetirement,em.GMIno,em.PenssionDate,em.EmailId,em.salid,em.SecId,em.EmpWorkingStatus,em.Presentbuilding,em.Presentstreet,em.Presentareia,em.Presentcity,em.Presentpin,em.Presentstate,em.Presentcountry,em.Permanentbuilding,em.Permanentstreet,em.Permanentareia,em.Permanentcity,em.Permanentpin,em.Permanentstate,em.Permanentcountry,em.Religion,sm.Location_id,em.Company_id,em.PF_Deduction,";
            //strsql = strsql + " cm.Cmpimage as 'CO_CODE',cm.BRNCH_NAME as 'CO_NAME',cm.BRNCH_ADD1 + ' ' + cm.BRNCH_ADD2 as 'CO_ADD',cm.BRNCH_TELE1 as 'CO_ADD1',";

            //strsql = strsql + "(select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=sm.Location_id )";
            //strsql = strsql + " as 'LocationName',sm.Session as 'Session',sm.Month as 'Misc','' as 'Misc2',sm.Location_id as 'Misc3' ";
            //strsql = strsql + "FROM ";//--tbl_Employee_SalaryDet sd inner join 
            //strsql = strsql + " tbl_Employee_Mast em ";//--on sd.EmpId=em.ID 
            //strsql = strsql + " inner join tbl_Employee_SalaryMast sm on  em.ID = sm.Emp_Id ";
            ////strsql = strsql + " inner join company cm on sm.Company_id=cm.CO_CODE ";
            //strsql = strsql + " inner join branch cm on sm.Company_id=cm.gcode ";
            //strsql = strsql + " where sm.Session='" + cmbYear.Text + "' AND CM.BRNCH_CODE >0 and sm.Month ='" + month + "' "; //and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' 
            //strsql = strsql + " AND SM.Emp_Id IN ( select emp_id from tbl_Employee_SalaryMast  group by emp_id,month having COUNT(*)>1)";

            //strsql = strsql + " order by sm.Emp_Id";**

           //my code:- strsql = " select (em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName) as EmployName ,sm.Emp_Id as ID, em.BankAcountNo  , CAST(convert(datetime,em.DateOfJoining ,103) AS DATE) as 'DateOfJoining' ,em.PF,em.ESIno , (case when sm.desig_id=0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId) else (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end)  as Rank,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.TotalSal as numeric(18,0)) Total_Earning,cast(sm.TotalDec as varchar(50)) Total_Deduction,cast(sm.NetPay as varchar(50)) Net_Pay ,sm.Location_id,(select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=sm.Location_id ) as 'LocationName',sm.Session as 'Session',sm.Month as 'Misc' from tbl_Employee_SalaryMast sm inner join tbl_Employee_Mast em on  em.ID = sm.Emp_Id  where sm.Session='" + cmbYear.Text + "'and sm.Month ='" + month + "' AND sm.Emp_Id IN ( select emp_id from tbl_Employee_SalaryMast  group by emp_id,month having COUNT(*)>1)  order by sm.Emp_Id";

            strsql = "select EmployName,ID,BankAcountNo,CAST(convert(datetime,DateOfJoining ,103) AS DATETIME) as 'DateOfJoining',PF,ESIno,sum(W_Day)W_Day,sum( O_T)O_T,sum(Tot_Day)Tot_Day,sum(Total_Earning)Total_Earning,sum(Total_Deduction)Total_Deduction,sum(Net_Pay )Net_Pay,Location_id,LocationName,Session, '" + cmbcompany.Text + "' as CO_NAME,'" + lbl_Co_Add.Text + "' as CO_ADD,Misc,Misc2,Misc3,'" + cdoj + "'as 'slno'  from (select (em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName) as EmployName ,sm.Emp_Id as ID, em.BankAcountNo  , CAST(convert(datetime,em.DateOfJoining ,103) AS DATE) as 'DateOfJoining' ,em.PF,em.ESIno , (case when sm.desig_id=0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId) else (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end)  as Rank,sm.Basic as Salary,isNull((select (Case when isNUll(cWD,0)!=0 then CAST(cWD AS numeric(18,2)) else Wday end) from tbl_employee_attend WHERE (Month = '"+AttenDtTmPkr.Value.ToString("M/yyyy")+"') AND (LOcation_ID =sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '"+AttenDtTmPkr.Value.ToString("M/yyyy")+"') AND (LOcation_ID =sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0) as W_Day,(case when sm.ed>0 then (CAST( sm.OT as numeric(18,2))+ CHAR(13)+CHAR(10) + 'ED - '+ CAST(sm.ed as numeric(18,2)) ) else CAST(sm.OT as numeric(18,2)) end) as O_T,(isNull((select CAST((Case when isNUll(cWD,0)!=0 then CAST(cWD AS numeric(18,2)) else Wday end)+ days_ot AS numeric(18,2)) from tbl_employee_attend WHERE (Month = '"+AttenDtTmPkr.Value.ToString("M/yyyy")+"') AND (LOcation_ID =sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '"+AttenDtTmPkr.Value.ToString("M/yyyy")+"') AND (LOcation_ID =sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0)) as Tot_Day ,cast(sm.TotalSal as numeric(18,0)) Total_Earning,cast(sm.TotalDec as numeric(18,0)) Total_Deduction,cast(sm.NetPay as numeric(18,0)) Net_Pay ,sm.Location_id,(select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=sm.Location_id ) as 'LocationName',sm.Session as 'Session',sm.Month as 'Misc',(case when ltrim(rtrim(em.dept))='' then '" + txtDept.Text.Trim() + "' else em.dept end) as 'Misc2',em.PassportNo as 'Misc3' from tbl_Employee_SalaryMast sm inner join tbl_Employee_Mast em on  em.ID = sm.Emp_Id  where sm.Session='" + cmbYear.Text + "'and sm.Month ='" + month + "' and (sm.Company_id='" + cmbcompany.ReturnValue + "') AND sm.Emp_Id IN ( select emp_id from tbl_Employee_SalaryMast where Company_id='" + cmbcompany.ReturnValue + "' Group by emp_id,month having COUNT(*)>1))e group by EmployName,ID,BankAcountNo,DateOfJoining,PF,ESIno,Location_id,LocationName,Session,Misc,Misc2,Misc3";

            string strsql1 = "";
            //strsql1 = " SELECT d.EmpId as 'id',d.Location_id,d.SalId as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount'  ";
            //strsql1 = strsql1 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "'  ";
            ////strsql1 = strsql1 + " and Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' ";
            //strsql1 = strsql1 + " and TableName ='tbl_Employee_ErnSalaryHead' ";
            //strsql1 = strsql1 + " AND D.EmpId IN ( select emp_id from tbl_Employee_SalaryMast group by emp_id,month having COUNT(*)>1)";

            //strsql1 = strsql1 + " order by EmpId";


            strsql1 = "select id,salid,EarningHead,TableName,sum(amount) amount,Location_id from ";
            strsql1 = strsql1 + " (SELECT d.EmpId as 'id',d.SalId as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount','0' as Designation_id,Location_id ";
            strsql1 = strsql1 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            strsql1 = strsql1 + "   and TableName ='tbl_Employee_ErnSalaryHead' and d.Company_id='" + cmbcompany.ReturnValue + "' and d.EmpId IN ( select emp_id from tbl_Employee_SalaryMast where Company_id='" + cmbcompany.ReturnValue + "' group by emp_id,month having COUNT(*)>1)";
            strsql1 = strsql1 + " union ";
            strsql1 = strsql1 + " SELECT d.EmpId as 'id',d.SalId as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount',cast (d.Designation_id as varchar) as Designation_id ,Location_id ";
            strsql1 = strsql1 + " FROM tbl_Employee_SalaryDet_MultiDesignation d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            strsql1 = strsql1 + "  and TableName ='tbl_Employee_ErnSalaryHead' and d.Company_id='" + cmbcompany.ReturnValue + "' and d.EmpId IN ( select emp_id from tbl_Employee_SalaryMast where Company_id='" + cmbcompany.ReturnValue + "' group by emp_id,month having COUNT(*)>1)) main group by  id,salid,EarningHead,TableName,Location_id";
            


            string strsql2 = "";
            //strsql2 = " SELECT d.EmpId as 'id',d.Location_id,d.SalId as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount'  ";
            //strsql2 = strsql2 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            ////strsql2 = strsql2 + " and Location_id ='" + get_LocationID(cmbsalstruc.Text) + "' 
            //strsql2 = strsql2 + " and TableName ='tbl_Employee_DeductionSalayHead'";
            //strsql2 = strsql2 + " AND D.EmpId IN ( select emp_id from tbl_Employee_SalaryMast group by emp_id,month having COUNT(*)>1)";

            //strsql2 = strsql2 + " order by EmpId";

            strsql2 = "select id,salid,DeductHead,TableName,sum(amount) amount,Location_id from ";
            strsql2 = strsql2 + " (SELECT d.EmpId as 'id',d.SalId as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount','0' as Designation_id,Location_id  ";
            strsql2 = strsql2 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            strsql2 = strsql2 + "  and TableName ='tbl_Employee_DeductionSalayHead' and d.Company_id='" + cmbcompany.ReturnValue + "' and d.EmpId IN ( select emp_id from tbl_Employee_SalaryMast where Company_id='" + cmbcompany.ReturnValue + "' group by emp_id,month having COUNT(*)>1) ";
            strsql2 = strsql2 + " union ";
            strsql2 = strsql2 + " SELECT d.EmpId as 'id',d.SalId as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount',cast (d.Designation_id as varchar) as Designation_id ,Location_id  ";
            strsql2 = strsql2 + " FROM tbl_Employee_SalaryDet_MultiDesignation d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            strsql2 = strsql2 + "  and TableName ='tbl_Employee_DeductionSalayHead' and d.Company_id='" + cmbcompany.ReturnValue + "' and d.EmpId IN ( select emp_id from tbl_Employee_SalaryMast where Company_id='" + cmbcompany.ReturnValue + "' group by emp_id,month having COUNT(*)>1)) main group by  id,salid,DeductHead,TableName,Location_id";
            


            //311015

            DataTable tot_employ = clsDataAccess.RunQDTbl(strsql);
            tot_employ.Columns.Add("Rank");

            for (int i = 0; i < tot_employ.Rows.Count; i++)
            {
                DataTable dtr = clsDataAccess.RunQDTbl("select (case when sm.desig_id=0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select DesgId from tbl_Employee_Mast em where ID=sm.Emp_Id) ) else (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end) from tbl_Employee_SalaryMast sm where sm.Emp_Id='" + tot_employ.Rows[i]["ID"] + "' and (sm.Location_id='" + tot_employ.Rows[i]["Location_id"] + "') and (sm.Month='" + month + "') and (sm.Session='" + cmbYear.Text + "')");
                    //"select d.DesignationName from tbl_Employee_DesignationMaster d,tbl_Employee_SalaryMast sm where d.SlNo=sm.desig_id and sm.Location_id='"+tot_employ.Rows[i]["Location_id"]+"' and sm.Month='" + month + "'");
                string rnk = "";
                for (int ij = 0; ij < dtr.Rows.Count; ij++)
                {
                    if (rnk == "")
                    {
                        rnk = dtr.Rows[ij][0].ToString();
                    }
                    else
                    {
                        rnk = rnk +"|"+dtr.Rows[ij][0].ToString();
                    }
                }
                tot_employ.Rows[i]["Rank"] = rnk;

            }
            DataTable tot_employ1 = clsDataAccess.RunQDTbl(strsql1 );
            DataTable tot_employ2 = clsDataAccess.RunQDTbl(strsql2 );


            //DataView dv = new DataView(tot_employ);
            //DataTable tot_employ3;
            ////tot_employ3 = new DataTable("columnname");
            //tot_employ3.Columns.Add("EmpId");
            //tot_employ3.Columns.Add("Earning_Tot");
            //tot_employ3.Columns.Add("Deduct_Tot");
            //if (tot_employ.Rows.Count > 0)
            //{
            //    for (int i = 0; i <= tot_employ.Rows.Count - 1; i++)
            //    {
            //        dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' ";

            //        if (dv.Count > 0)
            //        {
            //            foreach (DataRow drForm in dv.ToTable().Rows)
            //            {
            //                DataRow dataRow = tot_employ3.NewRow();

            //                dataRow["EmpId"] = drForm["EmpId"];
            //                dataRow["Earning_Tot"] = drForm["Earning_Tot"];
            //                dataRow["Deduct_Tot"] = drForm["Deduct_Tot"];
            //                dtNew.Rows.Add(drNew);
            //            }
            //        }


                   
            //        dataRow["Column_Name"] = dt7.Columns[i].ColumnName;
            //        dataRow["Ref_Column_slno"] = dt7.Rows[0][i].ToString();
            //        tot_employ3.Rows.Add(dataRow);
            //    }

            //}
            //tot_employ3.AcceptChanges();


            
            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.id)  as Rank,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.TotalSal as varchar(50)) Total_Earning,cast(sm.TotalDec as varchar(50)) Total_Deduction,cast(sm.NetPay as varchar(50)) Net_Pay ,sd.EmpId,sd.SalId,sd.TableName,sd.Slno,sd.Amount FROM tbl_Employee_SalaryDet sd inner join tbl_Employee_Mast em on sd.EmpId=em.ID inner join tbl_Employee_SalaryMast sm on  em.ID = sm.Emp_Id where sd.Session='" + cmbYear.Text + "' and sd.Month ='" + month + "' and sd.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' order by Slno");
            
            //041115 

            ////////tot_employ.Columns.Add("EarningHeads", typeof(string));
           

            ////////DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' order by Slno");
            ////////DataView dv = new DataView(salary_details);

           
            ////////if (tot_employ.Rows.Count > 1)
            ////////{
               

            ////////    for (int i = 0; i <= tot_employ.Rows.Count-1 ; i++)
            ////////    {
            ////////        dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' ";
            ////////        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + tot_employ.Rows[i]["TableName"] + " where SlNo ='" + tot_employ.Rows[i]["SalId"] + "'  ");
            ////////        tot_employ.Rows[i]["EarningHeads"] = Salary_Head;
            ////////        tot_employ.Rows[i]["sl"] = i + 1;
            ////////    }

            ////////    tot_employ.AcceptChanges();
            ////////}


            //041115 partha





            //DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' order by Slno");
            //DataView dv = new DataView(salary_details);
            //int table_count = tot_employ.Columns.Count;

            ////tot_employ.Rows.Add();  ///

            //tot_employ.Rows.Add();
            //int dt_count = tot_employ.Rows.Count;
            //tot_employ.Rows.Add();
            //tot_employ.Rows.Add();

            

            //int counter = 0;
            //for (int i = 0; i <= tot_employ.Rows.Count - 4; i++)
            //{
            //    dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' ";

            //    for (int j = 0; j <= dv.Count - 1; j++)
            //    {
            //        if (i == 0)
            //        {
            //            if (j == 0)
            //                tot_employ.Rows[dt_count][1] = "                Total :";

            //            if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
            //            {
            //                table_count = tot_employ.Columns.Count;
            //                flug_deduction = true;
            //                counter = j;
            //            }

            //            string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
            //            tot_employ.Columns.Add(Salary_Head, typeof(string));
            //            tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

            //            tot_employ.Rows[dt_count - 1][Salary_Head] = "---------------";
            //            tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
            //            tot_employ.Rows[dt_count + 1][Salary_Head] = "========";

            //            //if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead")
            //            //{
            //            //    lbd[j - counter].Text = Salary_Head;
            //            //}
            //            //else
            //            //{
            //            //    lbe[j].Text = Salary_Head;

            //            //}

            //        }
            //        else
            //        {
            //            tot_employ.Rows[i][j + 12] = dv[j]["Amount"];
            //            tot_employ.Rows[dt_count][j + 12] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][j + 12]) + Convert.ToDouble(dv[j]["Amount"]));

            //        }
            //    }

            //    tot_employ.Rows[dt_count - 1]["Total_Earning"] = "---------------";
            //    tot_employ.Rows[dt_count - 1]["Total_Deduction"] = "---------------";
            //    tot_employ.Rows[dt_count - 1]["Net_Pay"] = "---------------";

            //    if (Information.IsNumeric(tot_employ.Rows[dt_count]["Total_Earning"]) == false)
            //        tot_employ.Rows[dt_count]["Total_Earning"] = 0;
            //    if (Information.IsNumeric(tot_employ.Rows[dt_count]["Total_Deduction"]) == false)
            //        tot_employ.Rows[dt_count]["Total_Deduction"] = 0;
            //    if (Information.IsNumeric(tot_employ.Rows[dt_count]["Net_Pay"]) == false)
            //        tot_employ.Rows[dt_count]["Net_Pay"] = 0;

            //    tot_employ.Rows[dt_count + 1]["Total_Earning"] = "========";
            //    tot_employ.Rows[dt_count + 1]["Total_Deduction"] = "========";
            //    tot_employ.Rows[dt_count + 1]["Net_Pay"] = "========";


            //    tot_employ.Rows[i]["sl"] = i + 1;

            //    tot_employ.Rows[dt_count]["Total_Earning"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Total_Earning"]) + Convert.ToDouble(tot_employ.Rows[i]["Total_Earning"]));
            //    tot_employ.Rows[dt_count]["Total_Deduction"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Total_Deduction"]) + Convert.ToDouble(tot_employ.Rows[i]["Total_Deduction"]));
            //    tot_employ.Rows[dt_count]["Net_Pay"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Net_Pay"]) + Convert.ToDouble(tot_employ.Rows[i]["Net_Pay"]));
            //}

            //tot_employ.Columns["Total_Earning"].SetOrdinal(table_count - 1);
            //tot_employ.Columns["Total_Deduction"].SetOrdinal(tot_employ.Columns.Count - 1);
            //tot_employ.Columns["Net_Pay"].SetOrdinal(tot_employ.Columns.Count - 1);




            //dt = tot_employ.Copy();


            ds.Tables.Add(tot_employ);
            ds.Tables.Add(tot_employ1);
            ds.Tables.Add(tot_employ2);
            ds.Tables[0].TableName = "sss1";
            ds.Tables[1].TableName = "ppp1";
            ds.Tables[2].TableName = "ppq1";
            

        }

        public void retreive_data1()
        {
            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            string strsql = ""; 
                                                
            
            //strsql = " SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,";
            //strsql = strsql + "sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,";
            //strsql = strsql + "(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as Rank,";
            //strsql = strsql + "sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,";
            //strsql = strsql + "cast(sm.TotalSal as numeric(18,0)) Total_Earning,cast(sm.TotalDec as varchar(50)) Total_Deduction,cast(sm.NetPay as varchar(50)) Net_Pay ,";
            //strsql = strsql + "em.FathTitle,em.FathFN,em.FathMN,em.FathLN,em.MothTitle,em.MothFN,em.MothMN,em.MothLN,em.HusTitle,em.HusFN,em.HusMN,em.HusLN,CAST(convert(datetime, em.DateOfBirth ,103) AS DATE) as 'DateOfBirth',em.MaritalStatus,em.Gender,em.DesgId,em.JobType,em.PresentAddress,em.PermanentAddress,em.STD,em.Phone,em.Mobile,em.PANno,em.PassportNo,em.PF,em.PenssionNo,em.EDLI,em.ESIno,CAST(convert(datetime,em.DateOfJoining ,103) AS DATE) as 'DateOfJoining',em.DateOfRetirement,em.GMIno,em.PenssionDate,em.EmailId,em.salid,em.SecId,em.EmpWorkingStatus,em.Presentbuilding,em.Presentstreet,em.Presentareia,em.Presentcity,em.Presentpin,em.Presentstate,em.Presentcountry,em.Permanentbuilding,em.Permanentstreet,em.Permanentareia,em.Permanentcity,em.Permanentpin,em.Permanentstate,em.Permanentcountry,em.Religion,sm.Location_id,em.Company_id,em.PF_Deduction,";
            //strsql = strsql + " cm.Cmpimage as 'CO_CODE',cm.BRNCH_NAME as 'CO_NAME',cm.BRNCH_ADD1 + ' ' + cm.BRNCH_ADD2 as 'CO_ADD',cm.BRNCH_TELE1 as 'CO_ADD1',";
            //strsql = strsql + "(select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=sm.Location_id )";
            //strsql = strsql + " as 'LocationName',sm.Session as 'Session',sm.Month as 'Misc','' as 'Misc2',sm.Location_id as 'Misc3' ";
            //strsql = strsql + "FROM ";
            //strsql = strsql + " tbl_Employee_Mast em ";//--on sd.EmpId=em.ID 
            //strsql = strsql + " inner join tbl_Employee_SalaryMast sm on  em.ID = sm.Emp_Id ";
            //strsql = strsql + " inner join branch cm on sm.Company_id=cm.gcode ";
            //strsql = strsql + " where sm.Session='" + cmbYear.Text + "' AND CM.BRNCH_CODE >0 and sm.Month ='" + month + "' "; //and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' 
            //strsql = strsql + " AND SM.Emp_Id IN ( select emp_id from tbl_Employee_SalaryMast  group by emp_id,month having COUNT(*)>1) AND (sm.Emp_Id in (" + Item_Code + "))";
            //strsql = strsql + " order by sm.Emp_Id";

           //my code:- strsql = " select (em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName) as EmployName ,sm.Emp_Id as ID, em.BankAcountNo  , CAST(convert(datetime,em.DateOfJoining ,103) AS DATE) as 'DateOfJoining' ,em.PF,em.ESIno ,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as Rank,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.TotalSal as numeric(18,0)) Total_Earning,cast(sm.TotalDec as varchar(50)) Total_Deduction,cast(sm.NetPay as varchar(50)) Net_Pay ,sm.Location_id,(select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=sm.Location_id ) as 'LocationName',sm.Session as 'Session',sm.Month as 'Misc' from tbl_Employee_SalaryMast sm inner join tbl_Employee_Mast em on  em.ID = sm.Emp_Id  where sm.Session='" + cmbYear.Text + "'and sm.Month ='" + month + "' AND sm.Emp_Id IN ( select emp_id from tbl_Employee_SalaryMast  group by emp_id,month having COUNT(*)>1)  AND (sm.Emp_Id in (" + Item_Code + "))order by sm.Emp_Id";


            strsql = "select EmployName,ID,BankAcountNo,DateOfJoining,PF,ESIno,sum(W_Day)W_Day,sum( O_T)O_T,sum(Tot_Day)Tot_Day,sum(Total_Earning)Total_Earning,sum(Total_Deduction)Total_Deduction,sum(Net_Pay )Net_Pay,Location_id,LocationName,Session,Misc, '" + cmbcompany.Text + "' as CO_NAME,'" + lbl_Co_Add.Text + "' as CO_ADD,'" + cdoj + "'as 'slno' from (select (em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName) as EmployName ,sm.Emp_Id as ID, em.BankAcountNo  , CAST(convert(datetime,em.DateOfJoining ,103) AS DATE) as 'DateOfJoining' ,em.PF,em.ESIno , (case when sm.desig_id=0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId) else (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end)  as Rank,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.TotalSal as numeric(18,0)) Total_Earning,cast(sm.TotalDec as numeric(18,0)) Total_Deduction,cast(sm.NetPay as numeric(18,0)) Net_Pay ,sm.Location_id,(select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=sm.Location_id ) as 'LocationName',sm.Session as 'Session',sm.Month as 'Misc', '" + cmbcompany.Text + "' as CO_NAME,'" + lbl_Co_Add.Text + "' as CO_ADD from tbl_Employee_SalaryMast sm inner join tbl_Employee_Mast em on  em.ID = sm.Emp_Id  where sm.Session='" + cmbYear.Text + "'and sm.Month ='" + month + "' and sm.Company_id='" + cmbcompany.ReturnValue + "' AND sm.Emp_Id IN ( select emp_id from tbl_Employee_SalaryMast where Company_id='" + cmbcompany.ReturnValue + "'  group by emp_id,month having COUNT(*)>1) AND (sm.Emp_Id in (" + Item_Code + ")))e group by EmployName,ID,BankAcountNo,DateOfJoining,PF,ESIno,Location_id,LocationName,Session,Misc";



            
            string strsql1 = "";
            ////strsql1 = " SELECT d.EmpId as 'id',d.Location_id,d.SalId as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount'  ";
            ////strsql1 = strsql1 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "'  ";
            //////strsql1 = strsql1 + " and Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' ";
            ////strsql1 = strsql1 + " and TableName ='tbl_Employee_ErnSalaryHead' ";
            ////strsql1 = strsql1 + " AND D.EmpId IN ( select emp_id from tbl_Employee_SalaryMast group by emp_id,month having COUNT(*)>1) AND (D.EmpId in (" + Item_Code + "))";

            ////strsql1 = strsql1 + " order by EmpId";

            strsql1 = " select id,salid,EarningHead,TableName,sum(amount) amount,Location_id from  ";
            strsql1 = strsql1 + " (SELECT d.EmpId as 'id',d.SalId as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount','0' as Designation_id,Location_id  ";
            strsql1 = strsql1 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "'  ";
            strsql1 = strsql1 + " and d.Company_id='" + cmbcompany.ReturnValue + "'  and TableName ='tbl_Employee_ErnSalaryHead' ";
            strsql1 = strsql1 + " union ";
            strsql1 = strsql1 + " SELECT d.EmpId as 'id',d.SalId as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount',cast (d.Designation_id as varchar) as Designation_id ,Location_id ";
            strsql1 = strsql1 + " FROM tbl_Employee_SalaryDet_MultiDesignation d where Session='" + cmbYear.Text + "' and Month ='" + month + "'  ";
            strsql1 = strsql1 + " and d.Company_id='" + cmbcompany.ReturnValue + "' and TableName ='tbl_Employee_ErnSalaryHead') main ";
            

            //strsql1 = "SELECT d.EmpId as 'id',d.Location_id,d.SalId as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',d.TableName as 'TableName',(select dm.DesignationName from tbl_Employee_DesignationMaster dm where dm.SlNo=d.Designation_id)  as Rank,d.Slno as 'slno',d.Amount as 'amount'   FROM tbl_Employee_SalaryDet_MultiDesignation d where Session='" + cmbYear.Text + "' and Month ='" + month + "' and TableName ='tbl_Employee_ErnSalaryHead'  AND   (D.EmpId in (" + Item_Code + ")) order by EmpId,Designation_id";

            string strsql2 = "";
            //strsql2 = " SELECT d.EmpId as 'id',d.Location_id,d.SalId as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount'  ";
            //strsql2 = strsql2 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            ////strsql2 = strsql2 + " and Location_id ='" + get_LocationID(cmbsalstruc.Text) + "' 
            //strsql2 = strsql2 + " and TableName ='tbl_Employee_DeductionSalayHead'";
            //strsql2 = strsql2 + " AND D.EmpId IN ( select emp_id from tbl_Employee_SalaryMast group by emp_id,month having COUNT(*)>1) AND (D.EmpId in (" + Item_Code + "))";

            //strsql2 = strsql2 + " order by EmpId";

            strsql2 = "select id,salid,DeductHead,TableName,sum(amount) amount,Location_id from";
            strsql2 = strsql2 + " (SELECT d.EmpId as 'id',d.SalId as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount','0' as Designation_id,Location_id  ";
            strsql2 = strsql2 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            strsql2 = strsql2 + "  and d.Company_id='" + cmbcompany.ReturnValue + "' and TableName ='tbl_Employee_DeductionSalayHead'";
            strsql2 = strsql2 + " union ";
            strsql2 = strsql2 + " SELECT d.EmpId as 'id',d.SalId as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount',cast (d.Designation_id as varchar) as Designation_id,Location_id  ";
            strsql2 = strsql2 + " FROM tbl_Employee_SalaryDet_MultiDesignation d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            strsql2 = strsql2 + "  and d.Company_id='" + cmbcompany.ReturnValue + "' and TableName ='tbl_Employee_DeductionSalayHead') main ";
            

            //strsql2 = "SELECT d.EmpId as 'id',d.Location_id,d.SalId as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',(select dm.DesignationName from tbl_Employee_DesignationMaster dm where dm.SlNo=d.Designation_id)  as Rank,d.Slno as 'slno',d.Amount as 'amount'   FROM tbl_Employee_SalaryDet_MultiDesignation d  where Session='" + cmbYear.Text + "' and Month ='" + month + "' and TableName ='tbl_Employee_DeductionSalayHead'  AND (D.EmpId in (" + Item_Code + ")) order by EmpId, Designation_id";

            DataTable tot_employ = clsDataAccess.RunQDTbl(strsql );

            tot_employ.Columns.Add("Rank");

            for (int i = 0; i < tot_employ.Rows.Count; i++)
            {
                DataTable dtr = clsDataAccess.RunQDTbl("select (case when sm.desig_id=0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select DesgId from tbl_Employee_Mast em where ID=sm.Emp_Id) ) else (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end) from tbl_Employee_SalaryMast sm where sm.Emp_Id='" + tot_employ.Rows[i]["ID"] + "' and (sm.Location_id='" + tot_employ.Rows[i]["Location_id"] + "') and (sm.Month='" + month + "') and (sm.Session='" + cmbYear.Text + "')");

                string rnk = "";
                for (int ij = 0; ij < dtr.Rows.Count; ij++)
                {
                    if (rnk == "")
                    {
                        rnk = dtr.Rows[ij][0].ToString();
                    }
                    else
                    {
                        rnk = rnk + "|" + dtr.Rows[ij][0].ToString();
                    }
                }
                tot_employ.Rows[i]["Rank"] = rnk;

            }
            DataTable tot_employ1 = clsDataAccess.RunQDTbl(strsql1 + " where (id in (" + Item_Code + ")) group by  id,salid,EarningHead,TableName,Location_id");
            DataTable tot_employ2 = clsDataAccess.RunQDTbl(strsql2 + " where (id in (" + Item_Code + ")) group by  id,salid,DeductHead,TableName,Location_id");

           
            ds.Tables.Add(tot_employ);
            ds.Tables.Add(tot_employ1);
            ds.Tables.Add(tot_employ2);
            ds.Tables[0].TableName = "sss1";
            ds.Tables[1].TableName = "ppp1";
            ds.Tables[2].TableName = "ppq1";


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

            string Str_ESI = "";
            string Str_ESI_SLNO = "";

            DataTable data_ESI = clsDataAccess.RunQDTbl("select d.SalaryHead_Short,d.SLNO  from tbl_Employee_DeductionSalayHead d,tbl_Employee_Assign_SalStructure e,tbl_Employee_Link_SalaryStructure l where d.SlNo=e.SAL_HEAD and e.pt=1 and e.SAL_STRUCT=l.SalaryStructure_ID and Location_ID = '" + get_LocationID(cmbsalstruc.Text) + "'");

            if (data_ESI.Rows.Count > 0)
            {
                Str_ESI = data_ESI.Rows[0][0].ToString();
                Str_ESI_SLNO = data_ESI.Rows[0][1].ToString();

            }
            else
            {
                Str_ESI = "";
                ERPMessageBox.ERPMessage.Show("There is no PTAX Head in this Salary Structure");
                return;
            }

            Boolean flug_deduction = false;
            //string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);


            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,(select pf.PF_Code from Companywiseid_Relation pf where pf.location_id='" + get_LocationID(cmbsalstruc.Text) + "' ) as 'PFNO','" + get_LocationID(cmbsalstruc.Text) + "' as 'Location' ,cast(sm.Basic as varchar(50)) as 'Basic',cast(case when sm.basic>15000 then 15000 else sm.basic end as varchar(50)) as 'EPFBasic',cast(round(((sm.Basic*8.33)/100),2) as varchar(50)) as 'EPS833' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");

            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,(select pf.esi_code from Companywiseid_Relation pf where pf.location_id='" + get_LocationID(cmbsalstruc.Text) + "' ) as 'PTAX NO',sm.Emp_Id as ID,'" + cmbsalstruc.Text + "' as 'Site',cast(sm.TotalSal as varchar(50)) 'Gross Salary'  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");

            DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,'" + cmbsalstruc.Text + "' as 'Site',cast(sm.TotalSal as varchar(50)) 'Gross Salary'  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");


            DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and salid='" + Str_ESI_SLNO + "' order by Slno");
            DataView dv = new DataView(salary_details);
            int table_count = tot_employ.Columns.Count;

            //tot_employ.Rows.Add();  ///

           

            if (tot_employ.Rows.Count > 0)
            {
                tot_employ.Rows.Add();
                int dt_count = tot_employ.Rows.Count;
                tot_employ.Rows.Add();
                tot_employ.Rows.Add();

                int counter = 0;
                for (int i = 0; i <= tot_employ.Rows.Count - 4; i++)
                {
                    dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' ";

                    string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[0]["TableName"] + " where SlNo ='" + dv[0]["SalId"] + "'  ");
                    tot_employ.Rows[dt_count][1] = "                Total :";

                    if (i == 0)
                    {
                        if (Salary_Head == Str_ESI)
                        {
                            tot_employ.Columns.Add(Salary_Head, typeof(string));
                            tot_employ.Rows[i][Salary_Head] = dv[0]["Amount"];

                            tot_employ.Rows[dt_count - 1][Salary_Head] = "---------------";
                            tot_employ.Rows[dt_count][Salary_Head] = dv[0]["Amount"];
                            tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                        }
                    }
                    else
                    {

                        //string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                        if (Salary_Head == Str_ESI)
                        {
                            tot_employ.Rows[i][Salary_Head] = dv[0]["Amount"];
                            tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Str_ESI]) + Convert.ToDouble(dv[0]["Amount"]));
                        }
                    }


                    //for (int j = 0; j <= dv.Count - 1; j++)
                    //{
                    //    if (i == 0)
                    //    {
                    //        if (j == 0)
                    //            tot_employ.Rows[dt_count][1] = "                Total :";

                    //        if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                    //        {
                    //            table_count = tot_employ.Columns.Count;
                    //            flug_deduction = true;
                    //            counter = j;
                    //        }

                    //        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");

                    //        //if (Salary_Head == Str_ErHead_basic || Str_PF) //'"PF" 
                    //        if (Salary_Head == Str_ESI)
                    //        {
                    //            tot_employ.Columns.Add(Salary_Head, typeof(string));
                    //            tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                    //            tot_employ.Rows[dt_count - 1][Salary_Head] = "---------------";
                    //            tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                    //            tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                    //        }

                    //    }
                    //    else
                    //    {

                    //        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                    //        if (Salary_Head == Str_ESI)
                    //        {
                    //            tot_employ.Rows[i][j-1] = dv[j]["Amount"];
                    //            tot_employ.Rows[dt_count][Str_ESI] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Str_ESI]) + Convert.ToDouble(dv[j]["Amount"]));
                    //        }

                    //    }
                    //}

                    //tot_employ.Rows[dt_count - 1]["EPFBasic"] = "---------------";
                    //tot_employ.Rows[dt_count - 1]["EPS833"] = "---------------";
                    //tot_employ.Rows[dt_count - 1]["Employer (4.75%)"] = "---------------";


                    if (Information.IsNumeric(tot_employ.Rows[dt_count][Str_ESI]) == false)
                        tot_employ.Rows[dt_count][Str_ESI] = 0;
                    //if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPFBasic"]) == false)
                    //    tot_employ.Rows[dt_count]["EPFBasic"] = 0;
                    //if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPS833"]) == false)
                    //    tot_employ.Rows[dt_count]["EPS833"] = 0;
                    //if (Information.IsNumeric(tot_employ.Rows[dt_count]["Employer (4.75%)"]) == false)
                    //    tot_employ.Rows[dt_count]["Employer (4.75%)"] = 0;

                    tot_employ.Rows[dt_count + 1][Str_ESI] = "========";
                    //tot_employ.Rows[dt_count + 1]["EPFBasic"] = "========";
                    //tot_employ.Rows[dt_count + 1]["EPS833"] = "========";
                    //tot_employ.Rows[dt_count + 1]["Employer (4.75%)"] = "========";

                    tot_employ.Rows[i]["sl"] = i + 1;

                    //tot_employ.Rows[dt_count][Str_ESI] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Str_ESI]) + Convert.ToDouble(tot_employ.Rows[i][Str_ESI]));
                    //tot_employ.Rows[dt_count]["EPFBasic"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPFBasic"]) + Convert.ToDouble(tot_employ.Rows[i]["EPFBasic"]));
                    //tot_employ.Rows[dt_count]["EPS833"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPS833"]) + Convert.ToDouble(tot_employ.Rows[i]["EPS833"]));

                    //tot_employ.Rows[i]["Employer (4.75%)"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[i]["Gross Salary"]) * Convert.ToDouble(txtEmpContribut.Text.Trim()) / 100));

                    //tot_employ.Rows[dt_count]["Employer (4.75%)"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Employer (4.75%)"]) + Convert.ToDouble(tot_employ.Rows[i]["Employer (4.75%)"]));

                }

                tot_employ.Columns[Str_ESI].SetOrdinal(table_count - 1);
                //tot_employ.Columns["EPFBasic"].SetOrdinal(tot_employ.Columns.Count - 1);
                //tot_employ.Columns["EPS833"].SetOrdinal(tot_employ.Columns.Count - 1);

                tot_employ.Columns.Remove("ID");

                tot_employ.Columns[Str_ESI].SetOrdinal(4);
                tot_employ.Columns["Gross Salary"].SetOrdinal(3);
                //tot_employ.Columns["PF"].SetOrdinal(6);
                //tot_employ.Columns["EPS833"].SetOrdinal(7);
                //tot_employ.Columns["Employer (4.75%)"].SetOrdinal(7);

                //tot_employ.Columns["PF"].ColumnName = "Employee Contribution (12%)";



                dt = tot_employ.Copy();

                dt.AcceptChanges();
                Head_Cou = dt.Columns.Count;

            }


          

        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 1)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
                cmbsalstruc.Items.Clear();
            }
            else if (dt.Rows.Count == 1)
            {
                cmbcompany.Text = dt.Rows[0]["CO_NAME"].ToString();
                cmbcompany.ReturnValue=dt.Rows[0]["CO_CODE"].ToString();
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);
                lbl_Co_Add.Text = clsDataAccess.ReturnValue("select CO_ADD from Company where CO_CODE='" + Company_id + "'");
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
            {
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);


                lbl_Co_Add.Text = clsDataAccess.ReturnValue("select CO_ADD from Company where CO_CODE='" + Company_id + "'");

            }
            //data_retrive_Company();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

                string sqlstmnt = "Select distinct (select e.Title+' '+e.FirstName+' '+e.MiddleName+' '+ e.LastName from tbl_Employee_Mast e where e.ID=s.emp_id) as 'EmpName',s.emp_id as 'ID',month from tbl_Employee_SalaryMast s where (s.Month='" + month + "') and (s.Session ='" + cmbYear.Text + "') and (s.Company_id='"+ cmbcompany.ReturnValue +"')"; //and s.Location_id= '" + get_LocationID(cmbsalstruc.Text) + "'
                sqlstmnt = sqlstmnt + " AND s.emp_id IN ( select emp_id from tbl_Employee_SalaryMast group by emp_id,month having COUNT(*)>1 ) ";
                EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Employee", "Select Employee", 0, "CMPN", 0);

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

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
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
        }

        


    }

}