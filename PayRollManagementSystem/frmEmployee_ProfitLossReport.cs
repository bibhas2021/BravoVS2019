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
    public partial class frmEmployee_ProfitLossReport : EDPComponent.FormBaseRptMidium
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        string Item_Code = "", Tentry_code = "";
        ArrayList arritem = new ArrayList();
        Hashtable getcode_item = new Hashtable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Frm_Type = "";
        int Head_Cou = 0;
        string Locations = "";
        int Company_id = 0;
        ArrayList arrecode = new ArrayList();
        string arrayEcode = "";
        Hashtable get_ecode = new Hashtable();

        string current_company;
        string address = "";
        string address1 = "";
        string pan;
        string DURATION;
        string sq1="",opt = "", coid = "", locid = "",clid="";

       
        int Client_id = 0;
      


        string company = "", Agentadd = "", Agentadd1 = "", phone = "", Area = "", BillDate = "", User_Voucher = "";
        string challan = "", challandt = "", AmtWord = "", narrsn = "";
        string conName = "", ConAdd1 = "", Conadd2 = "";
        string amtvalue = "";
        string lorry_no = "", locname = "", modtranport = "", prtyname = "", prtyadd1 = "", prtyadd2 = "", prtycity = "", prtyctypin = "", prtytele1 = "", prtytele2 = "", prtyfax = "", prtyemail = "", prtyeccno = "", prtytin = "";
        string partycodeeee = "";
        string tentry = "", FinalAmount = "", Refvoucher = "";

        public frmEmployee_ProfitLossReport(string type)
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
            this.Text = "Profit and Loss";
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
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }
            dateTimePicker1.Value = DateTime.Now.Date.AddMonths(-1);

            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbcompany.Text = Convert.ToString(dt_co.Rows[0][0]);

                Company_id = Convert.ToInt32(dt_co.Rows[0][1]);
                cmbcompany.ReturnValue = Company_id.ToString();
                cmbcompany.Enabled = false;


            }
            else if (dt_co.Rows.Count > 1)
            {
                cmbcompany.PopUp();


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

            string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

            string strssql = "";
            strssql = strssql + " select p.Cliant_ID,sum(p.billamt) as 'BillAmount',sum(s.NetPay) as 'Netpay',case when sum(p.billamt)>sum(s.NetPay) then (sum(p.billamt)-sum(s.NetPay)) ";
            strssql = strssql + " when sum(p.billamt)<sum(s.NetPay) then (sum(s.NetPay)-sum(p.billamt)) end as 'Profit/loss' from tbl_Employee_SalaryMast s inner join paybillD p on s.Month=p.Month";
            strssql = strssql + " and s.Location_id=p.Location_ID and s.Company_id=p.Company_id and s.Session=p.Session where s.MONTH='" + month + "' ";
            strssql = strssql + " and s.Company_id='" + get_CompID(cmbcompany.Text) + "' and s.Location_id='" + cmblocation.ReturnValue + "' and p.Cliant_ID=" + clid + " and s.Session= '" + cmbYear.Text + "'";
            strssql = strssql + " group by s.MONTH,p.Cliant_ID";


            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");
            DataTable tot_employ = clsDataAccess.RunQDTbl("strssql");

            dt = tot_employ.Copy();

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (cmbClient.Text != "")
                {
                    Retrive_DataESI();
                    MidasReport.Form1 opening = new MidasReport.Form1();
                    opening.Empprofitloss_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1);

                    opening.ShowDialog();

                    ds.Tables.Clear();
                    ds.Dispose();
                }
                else
                {
                    MessageBox.Show("Please select Client");
                    return;
                }



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
            else
            {
                if (cmbClient.Text != "")
                {
                    if (Item_Code != "")
                    {
                        Retrive_DataESI1();
                        MidasReport.Form1 opening = new MidasReport.Form1();
                        opening.Empprofitloss_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1);

                        opening.ShowDialog();

                        ds.Tables.Clear();
                        ds.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Please select location");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please select client");
                    return;
                }
            
            }
            
           


            
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
            if (checkBox1.Checked == true)
            {
                if (cmbClient.Text != "")
                {
                    Retrive_DataESI();
                    MidasReport.Form1 opening = new MidasReport.Form1();
                    //opening.Empprofitloss_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1);
                    opening.paybill_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2);
                    opening.ShowDialog();

                    ds.Tables.Clear();
                    ds.Dispose();
                }
                else
                {
                    MessageBox.Show("Please select Client");
                    return;
                }
            }
            else
            {
                if (cmbClient.Text != "")
                {
                    if (Item_Code != "")
                    {
                        Retrive_DataESI1();
                        MidasReport.Form1 opening = new MidasReport.Form1();
                        opening.paybill_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2);
            

                        opening.ShowDialog();

                        ds.Tables.Clear();
                        ds.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Please select location");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please select client");
                    return;
                }

            }

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
                Report_Header[1] = "P.TAX Report for the location " + cmblocation.Text;
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

                Report_Page_Header[0] = "Profit and loss for the location " + cmblocation.Text;
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

            string strssql = "";
            string strssql1 = "";
            string strssql2 = "";

            string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
            string mon = dateTimePicker1.Value.ToString("MMMM - yyyy");
            strssql="";
            //strssql = strssql + "select sum(amount) from (";
            //strssql = strssql + " select sum(BILLAMT)as 'amount' from paybilld where MONTH='" + month + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and Location_id='" + get_LocationID(cmbsalstruc.Text) + "' ";
            //strssql = strssql + "union all ";
            //strssql = strssql + " select sum(amount) as 'amount' from(";
            //strssql = strssql + " select empid,sum(amount) as 'amount' from (";
            //strssql = strssql + " select emp_id as 'empid',GrossAmount as 'amount' from tbl_Employee_SalaryMast where MONTH='" + month + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and Location_id='" + get_LocationID(cmbsalstruc.Text) + "' ";
            //strssql = strssql + " union all";
            //strssql = strssql + " select empid,SUM(amount) as 'amount' from tbl_Employee_SalaryDet ";
            //strssql = strssql + " where TableName='tbl_Employer_Contribution' and MONTH='" + month + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "'  and Location_id='" + get_LocationID(cmbsalstruc.Text) + "'";
            //strssql = strssql + " group by empid";
            //strssql = strssql + " union all";
            //strssql = strssql + " select empid,amount from tbl_Employee_SalaryDet s";
            //strssql = strssql + " where s.TableName='tbl_Employee_DeductionSalayHead' and s.MONTH='" + month + "' and s.Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and s.Location_id='" + get_LocationID(cmbsalstruc.Text) + "'";
            //strssql = strssql + " and s.SalId in (select SAL_HEAD from tbl_Employee_Assign_SalStructure where SESSION ='" + cmbYear.Text + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and Location_id='" + get_LocationID(cmbsalstruc.Text) + "' and PF_PER='1')";
            //strssql = strssql + " )x";
            //strssql = strssql + " group by empid";
            //strssql = strssql + " )y";
            //strssql = strssql + " )z";
            /*
            strssql = strssql + " select '' as BILLNO,sum(amount) as 'amount' from(";
            strssql = strssql + " select empid,sum(amount) as 'amount' from (";
            strssql = strssql + " select emp_id as 'empid',GrossAmount as 'amount' from tbl_Employee_SalaryMast where MONTH='" + month + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and Location_id='" + get_LocationID(cmbsalstruc.Text) + "' ";
            strssql = strssql + " union all ";
            strssql = strssql + " select empid,SUM(amount) as 'amount' from tbl_Employee_SalaryDet ";
            strssql = strssql + " where TableName='tbl_Employer_Contribution' and MONTH='" + month + "'  and Company_id=1 and Location_id='" + get_LocationID(cmbsalstruc.Text) + "'";
            strssql = strssql + " group by empid ";
            strssql = strssql + " union all ";
            strssql = strssql + " select empid,amount from tbl_Employee_SalaryDet s ";
            strssql = strssql + " where s.TableName='tbl_Employee_DeductionSalayHead' and s.MONTH='" + month + "'  and s.Company_id=1 and s.Location_id='" + get_LocationID(cmbsalstruc.Text) + "'";
            strssql = strssql + " and s.SalId in (select SAL_HEAD from tbl_Employee_Assign_SalStructure where SESSION ='" + cmbYear.Text + "' and Company_id=1 and Location_id='" + get_LocationID(cmbsalstruc.Text) + "' and PF_PER='1')";
            strssql = strssql + " )x ";
            strssql = strssql + " group by empid ";
            strssql = strssql + " )y ";
            strssql1 = "";
            strssql1 = strssql1 + " select BILLNO ,sum(BILLAMT)as 'amount' from paybilld where MONTH='" + month + "' and SESSION='" + cmbYear.Text + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and Location_id='" + get_LocationID(cmbsalstruc.Text) + "'  group by BILLNO ";
            strssql2 = "";
            strssql2 = strssql2 + " select distinct (select c.co_name from Company c where c.CO_CODE=S.Company_id ) as 'coname',"; 
            strssql2 = strssql2 + " (select c.CO_ADD  from Company c where c.CO_CODE=s.Company_id ) as 'Add1',";
            strssql2 = strssql2 + " (select c.CO_ADD1   from Company c where c.CO_CODE=s.Company_id ) as 'Add2',";  
            strssql2 = strssql2 + " (select Location_Name from tbl_Emp_Location where Location_ID=S.Location_ID ) as 'locname',";
            strssql2 = strssql2 + " (select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'ClientName' ,";
            strssql2 = strssql2 + " (select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )  as 'ClientCity' ,";
            strssql2 = strssql2 + " (select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'Contract_Person' ,";
            strssql2 = strssql2 + " (select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )) AS mis1, ";
            strssql2 = strssql2 + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) AS mis2, ";
            strssql2 = strssql2 + " '" + month + "' AS mis3,'" + cmbYear.Text + "' AS mis4,'" + cmbYear.Text + "' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,'' AS mis10 ";
            strssql2 = strssql2 + " from tbl_Employee_SalaryMast s";
            strssql2 = strssql2 + " where  MONTH='" + month + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and SESSION='" + cmbYear.Text + "' and Location_id='" + get_LocationID(cmbsalstruc.Text) + "'";
            */

            //strssql = strssql + " select '' as BILLNO,sum(amount) as 'amount' from(";
            //strssql = strssql + " select empid,sum(amount) as 'amount' from (";
            //strssql = strssql + " select emp_id as 'empid',GrossAmount as 'amount' from tbl_Employee_SalaryMast where MONTH='" + month + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and (Location_id='" + Locations + "') ";
            //strssql = strssql + " union all ";
            //strssql = strssql + " select empid,SUM(amount) as 'amount' from tbl_Employee_SalaryDet ";
            //strssql = strssql + " where TableName='tbl_Employer_Contribution' and MONTH='" + month + "'  and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and (Location_id='" + Locations + "') ";
            //strssql = strssql + " group by empid ";
            //strssql = strssql + " union all ";
            //strssql = strssql + " select empid,amount from tbl_Employee_SalaryDet s ";
            //strssql = strssql + " where s.TableName='tbl_Employee_DeductionSalayHead' and s.MONTH='" + month + "'  and s.Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and (s.Location_id='" + Locations + "') ";
            //strssql = strssql + " and s.SalId in (select SAL_HEAD from tbl_Employee_Assign_SalStructure where SESSION ='" + cmbYear.Text + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and (Location_id='" + Locations + "') and PF_PER='1')";
            //strssql = strssql + " )x ";
            //strssql = strssql + " group by empid ";
            //strssql = strssql + " )y ";
            strssql = "SELECT     '' AS 'BillNo', sum(GrossAmount) AS 'amount' FROM tbl_Employee_SalaryMast m, tbl_Emp_Location n WHERE (Month='" + month + "')and (Session='" + cmbYear.Text + "') AND (Company_id='" + Company_id + "') AND (m.Location_id = n.Location_ID)";
            strssql1 = "select BILLNO ,TotAMT from paybill b, tbl_Emp_Location o where (MONTH='" + mon + "') and (SESSION='" + cmbYear.Text + "') and (Comany_id='" + Company_id + "') and (b.Location_ID = o.Location_ID)";
           // strssql1 = strssql1 + " select BILLNO ,sum(BILLAMT)as 'amount' from paybilld where MONTH='" + month + "' and SESSION='" + cmbYear.Text + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' group by BILLNO ";
            strssql2 = "";
            strssql2 = strssql2 + " select distinct (select c.co_name from Company c where c.CO_CODE=S.Company_id ) as 'coname',";
            strssql2 = strssql2 + " (select c.CO_ADD from Company c where c.CO_CODE=s.Company_id ) as 'Add1',";
            strssql2 = strssql2 + " (select c.CO_ADD1 from Company c where c.CO_CODE=s.Company_id ) as 'Add2',";
            strssql2 = strssql2 + " (select Location_Name from tbl_Emp_Location where Location_ID = S.Location_ID ) as 'locname',";
            strssql2 = strssql2 + " (select c.Client_Name from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'ClientName' ,";
            strssql2 = strssql2 + " (select c.Client_City from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )  as 'ClientCity' ,";
            strssql2 = strssql2 + " (select c.Contract_Person from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'Contract_Person' ,";
            strssql2 = strssql2 + " (select State_Name from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )) AS mis1, ";
            strssql2 = strssql2 + " (select c.Client_ADD1 from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) AS mis2, ";
            strssql2 = strssql2 + " '" + month + "' AS mis3,'" + cmbYear.Text + "' AS mis4,'" + cmbYear.Text + "' AS mis5,'' AS mis6,'' AS mis7,"+
            "isNull((select sum(GrossAmount) AS 'amount' FROM tbl_Employee_SalaryMast WHERE (Month='" + month + "')and (Session=s.Session) AND (Company_id=s.Company_id) AND (Location_id=s.Location_id)),'0') AS mis8," +
           
            //"isNull((select sum(Amount) FROM tbl_Employee_SalaryDet where (Location_id=s.Location_id) and (Company_id=s.Company_id) and (MONTH=s.Month) and (Session = s.Session) and (TableName='tbl_Employer_Contribution')),0) AS mis9," +
            "isNull((SELECT SUM(pf_employer_cont) AS pf_cont FROM tbl_employers_contribution WHERE (month ='" + mon + "') AND (lid =S.Location_ID) AND (coid =s.Company_id) AND (session ='" + cmbYear.Text + "')),0) AS mis9," +
            "isNull((SELECT SUM(esi_employer_cont) AS esi_cont FROM tbl_employers_contribution WHERE (month ='" + mon + "') AND (lid =S.Location_ID) AND (coid =s.Company_id) AND (session ='" + cmbYear.Text + "')),0) AS mis10,s.Location_id ";
            strssql2 = strssql2 + " from tbl_Employee_SalaryMast as s";
            strssql2 = strssql2 + " where  ([MONTH]='" + month + "') and ([Company_id]='" + Company_id + "') AND (Location_id in (SELECT Location_ID FROM tbl_Emp_Location where (Cliant_ID='" + Client_id + "'))) and (SESSION='" + cmbYear.Text + "')";

            DataTable tot_employ = clsDataAccess.RunQDTbl(strssql);
            DataTable dt_bill = clsDataAccess.RunQDTbl(strssql1);

            DataTable tot_employ1 = new DataTable();
            tot_employ1.Columns.Add("BILLNO");
            tot_employ1.Columns.Add("amount");
            string blno = "";
            double blamt = 0;
            for (int ind = 0; ind < dt_bill.Rows.Count; ind++)
            {
                if (blno == "")
                {
                    blno = dt_bill.Rows[ind]["BILLNO"].ToString();

                }
                else
                {
                    blno = blno+ Environment.NewLine+ dt_bill.Rows[ind]["BILLNO"].ToString();

                }
                blamt = (blamt + Convert.ToDouble(dt_bill.Rows[ind]["TotAmt"].ToString()));
               

            }
            tot_employ1.Rows.Add();
            tot_employ1.Rows[0]["BILLNO"] =blno;
            tot_employ1.Rows[0]["amount"] = edpcom.GetAmountFormat(blamt);


            DataTable tot_employ2 = clsDataAccess.RunQDTbl(strssql2);

            for (int idx = 0; idx < tot_employ2.Rows.Count; idx++)
            {
                blamt = 0;
                blno = "";
                strssql1 = "select BILLNO ,TotAMT from paybill where (MONTH='" + mon +
                "') and (SESSION='" + tot_employ2.Rows[idx]["mis4"].ToString() + "') and (Comany_id='" + Company_id + 
                "') and (Location_ID =" + tot_employ2.Rows[idx]["Location_id"].ToString() + ")";
                dt_bill = clsDataAccess.RunQDTbl(strssql1);
                for (int ind = 0; ind < dt_bill.Rows.Count; ind++)
                {
                    if (blno == "")
                    {
                        blno = dt_bill.Rows[ind]["BILLNO"].ToString();

                    }
                    else
                    {
                        blno = blno + Environment.NewLine + dt_bill.Rows[ind]["BILLNO"].ToString();

                    }
                    blamt = blamt + Convert.ToDouble(dt_bill.Rows[ind]["TotAmt"].ToString());

                }
                tot_employ2.Rows[idx]["mis6"] = blno;
                tot_employ2.Rows[idx]["mis7"] = edpcom.GetAmountFormat(blamt);
            }

            ds.Tables.Add(tot_employ);
            ds.Tables.Add(tot_employ1);
            ds.Tables.Add(tot_employ2);
            ds.Tables[0].TableName = "ordamt";
            ds.Tables[1].TableName = "billamt";
            ds.Tables[2].TableName = "cmp";


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


        private void Retrive_DataESI1()
        {

            //string Str_ErHead_basic = "";
            //DataTable ErHead_basic = clsDataAccess.RunQDTbl("select top 1  SalaryHead_Short from tbl_Employee_ErnSalaryHead");
            //Str_ErHead_basic = ErHead_basic.Rows[0][0].ToString();
            

                string strssql = "";
                string strssql1 = "";
                string strssql2 = "";

                string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
                string mon = dateTimePicker1.Value.ToString("MMMM - yyyy");
                strssql = "";
                //strssql = strssql + "select sum(amount) from (";
                //strssql = strssql + " select sum(BILLAMT)as 'amount' from paybilld where MONTH='" + month + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and Location_id='" + get_LocationID(cmbsalstruc.Text) + "' ";
                //strssql = strssql + "union all ";
                //strssql = strssql + " select sum(amount) as 'amount' from(";
                //strssql = strssql + " select empid,sum(amount) as 'amount' from (";
                //strssql = strssql + " select emp_id as 'empid',GrossAmount as 'amount' from tbl_Employee_SalaryMast where MONTH='" + month + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and Location_id='" + get_LocationID(cmbsalstruc.Text) + "' ";
                //strssql = strssql + " union all";
                //strssql = strssql + " select empid,SUM(amount) as 'amount' from tbl_Employee_SalaryDet ";
                //strssql = strssql + " where TableName='tbl_Employer_Contribution' and MONTH='" + month + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "'  and Location_id='" + get_LocationID(cmbsalstruc.Text) + "'";
                //strssql = strssql + " group by empid";
                //strssql = strssql + " union all";
                //strssql = strssql + " select empid,amount from tbl_Employee_SalaryDet s";
                //strssql = strssql + " where s.TableName='tbl_Employee_DeductionSalayHead' and s.MONTH='" + month + "' and s.Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and s.Location_id='" + get_LocationID(cmbsalstruc.Text) + "'";
                //strssql = strssql + " and s.SalId in (select SAL_HEAD from tbl_Employee_Assign_SalStructure where SESSION ='" + cmbYear.Text + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and Location_id='" + get_LocationID(cmbsalstruc.Text) + "' and PF_PER='1')";
                //strssql = strssql + " )x";
                //strssql = strssql + " group by empid";
                //strssql = strssql + " )y";
                //strssql = strssql + " )z";
                /*
                strssql = strssql + " select '' as BILLNO,sum(amount) as 'amount' from(";
                strssql = strssql + " select empid,sum(amount) as 'amount' from (";
                strssql = strssql + " select emp_id as 'empid',GrossAmount as 'amount' from tbl_Employee_SalaryMast where MONTH='" + month + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and Location_id='" + get_LocationID(cmbsalstruc.Text) + "' ";
                strssql = strssql + " union all ";
                strssql = strssql + " select empid,SUM(amount) as 'amount' from tbl_Employee_SalaryDet ";
                strssql = strssql + " where TableName='tbl_Employer_Contribution' and MONTH='" + month + "'  and Company_id=1 and Location_id='" + get_LocationID(cmbsalstruc.Text) + "'";
                strssql = strssql + " group by empid ";
                strssql = strssql + " union all ";
                strssql = strssql + " select empid,amount from tbl_Employee_SalaryDet s ";
                strssql = strssql + " where s.TableName='tbl_Employee_DeductionSalayHead' and s.MONTH='" + month + "'  and s.Company_id=1 and s.Location_id='" + get_LocationID(cmbsalstruc.Text) + "'";
                strssql = strssql + " and s.SalId in (select SAL_HEAD from tbl_Employee_Assign_SalStructure where SESSION ='" + cmbYear.Text + "' and Company_id=1 and Location_id='" + get_LocationID(cmbsalstruc.Text) + "' and PF_PER='1')";
                strssql = strssql + " )x ";
                strssql = strssql + " group by empid ";
                strssql = strssql + " )y ";
                strssql1 = "";
                strssql1 = strssql1 + " select BILLNO ,sum(BILLAMT)as 'amount' from paybilld where MONTH='" + month + "' and SESSION='" + cmbYear.Text + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and Location_id='" + get_LocationID(cmbsalstruc.Text) + "'  group by BILLNO ";
                strssql2 = "";
                strssql2 = strssql2 + " select distinct (select c.co_name from Company c where c.CO_CODE=S.Company_id ) as 'coname',"; 
                strssql2 = strssql2 + " (select c.CO_ADD  from Company c where c.CO_CODE=s.Company_id ) as 'Add1',";
                strssql2 = strssql2 + " (select c.CO_ADD1   from Company c where c.CO_CODE=s.Company_id ) as 'Add2',";  
                strssql2 = strssql2 + " (select Location_Name from tbl_Emp_Location where Location_ID=S.Location_ID ) as 'locname',";
                strssql2 = strssql2 + " (select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'ClientName' ,";
                strssql2 = strssql2 + " (select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )  as 'ClientCity' ,";
                strssql2 = strssql2 + " (select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'Contract_Person' ,";
                strssql2 = strssql2 + " (select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )) AS mis1, ";
                strssql2 = strssql2 + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) AS mis2, ";
                strssql2 = strssql2 + " '" + month + "' AS mis3,'" + cmbYear.Text + "' AS mis4,'" + cmbYear.Text + "' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,'' AS mis10 ";
                strssql2 = strssql2 + " from tbl_Employee_SalaryMast s";
                strssql2 = strssql2 + " where  MONTH='" + month + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and SESSION='" + cmbYear.Text + "' and Location_id='" + get_LocationID(cmbsalstruc.Text) + "'";
                */

                //strssql = strssql + " select '' as BILLNO,sum(amount) as 'amount' from(";
                //strssql = strssql + " select empid,sum(amount) as 'amount' from (";
                //strssql = strssql + " select emp_id as 'empid',GrossAmount as 'amount' from tbl_Employee_SalaryMast where MONTH='" + month + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and (Location_id='" + Locations + "') ";
                //strssql = strssql + " union all ";
                //strssql = strssql + " select empid,SUM(amount) as 'amount' from tbl_Employee_SalaryDet ";
                //strssql = strssql + " where TableName='tbl_Employer_Contribution' and MONTH='" + month + "'  and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and (Location_id='" + Locations + "') ";
                //strssql = strssql + " group by empid ";
                //strssql = strssql + " union all ";
                //strssql = strssql + " select empid,amount from tbl_Employee_SalaryDet s ";
                //strssql = strssql + " where s.TableName='tbl_Employee_DeductionSalayHead' and s.MONTH='" + month + "'  and s.Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and (s.Location_id='" + Locations + "') ";
                //strssql = strssql + " and s.SalId in (select SAL_HEAD from tbl_Employee_Assign_SalStructure where SESSION ='" + cmbYear.Text + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' and (Location_id='" + Locations + "') and PF_PER='1')";
                //strssql = strssql + " )x ";
                //strssql = strssql + " group by empid ";
                //strssql = strssql + " )y ";
                strssql = "SELECT     '' AS 'BillNo', sum(GrossAmount) AS 'amount' FROM tbl_Employee_SalaryMast WHERE (Month='" + month + "')and (Session='" + cmbYear.Text + "') AND (Company_id='" + Company_id + "') AND (Location_id in (" + Item_Code + "))";
                strssql1 = "select BILLNO ,TotAMT from paybill where (MONTH='" + mon + "') and (SESSION='" + cmbYear.Text + "') and (Comany_id='" + Company_id + "') and (Location_ID in (" + Item_Code + "))";
                // strssql1 = strssql1 + " select BILLNO ,sum(BILLAMT)as 'amount' from paybilld where MONTH='" + month + "' and SESSION='" + cmbYear.Text + "' and Company_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "' group by BILLNO ";
                strssql2 = "";
                strssql2 = strssql2 + " select distinct (select c.co_name from Company c where c.CO_CODE=S.Company_id ) as 'coname',";
                strssql2 = strssql2 + " (select c.CO_ADD from Company c where c.CO_CODE=s.Company_id ) as 'Add1',";
                strssql2 = strssql2 + " (select c.CO_ADD1 from Company c where c.CO_CODE=s.Company_id ) as 'Add2',";
                strssql2 = strssql2 + " (select Location_Name from tbl_Emp_Location where Location_ID =s.Location_id) as 'locname',";
                strssql2 = strssql2 + " (select c.Client_Name from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID =s.Location_id ) ) as 'ClientName' ,";
                strssql2 = strssql2 + " (select c.Client_City from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID =s.Location_id ) )  as 'ClientCity' ,";
                strssql2 = strssql2 + " (select c.Contract_Person from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=s.Location_id) ) as 'Contract_Person' ,";
                strssql2 = strssql2 + " (select State_Name from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID =s.Location_id ) )) AS mis1, ";
                strssql2 = strssql2 + " (select c.Client_ADD1 from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID =s.Location_id) ) AS mis2, ";
                strssql2 = strssql2 + " '" + month + "' AS mis3,'" + cmbYear.Text + "' AS mis4,'" + cmbYear.Text + "' AS mis5,'' AS mis6,'' AS mis7," +
                "isNull((select sum(GrossAmount) AS 'amount' FROM tbl_Employee_SalaryMast WHERE (Month='" + month + "')and (Session=s.Session) AND (Company_id=s.Company_id) AND (Location_id=s.Location_id)),'0') AS mis8," +
                //"isNull((select sum(Amount) FROM tbl_Employee_SalaryDet where (Location_id =s.Location_id) and (Company_id=s.Company_id) and (MONTH=s.Month) and (Session = s.Session) and (TableName='tbl_Employer_Contribution')),0) AS mis9," +
                "isNull((SELECT SUM(pf_employer_cont) AS pf_cont FROM tbl_employers_contribution WHERE (month ='" + mon + "') AND (lid  =s.Location_id) AND (coid =s.Company_id) AND (session ='" + cmbYear.Text + "')),0) AS mis9,"+
                "isNull((SELECT SUM(esi_employer_cont) AS esi_cont FROM tbl_employers_contribution WHERE (month ='" + mon + "') AND (lid  =s.Location_id) AND (coid =s.Company_id) AND (session ='" + cmbYear.Text + "')),0) AS mis10,s.Location_id ";
                strssql2 = strssql2 + " from tbl_Employee_SalaryMast as s";
                strssql2 = strssql2 + " where  (MONTH='" + month + "') and (Company_id='" + Company_id + "') AND (Location_id in (" + Item_Code + ")) and (SESSION='" + cmbYear.Text + "')";

                DataTable tot_employ = clsDataAccess.RunQDTbl(strssql);
                DataTable dt_bill = clsDataAccess.RunQDTbl(strssql1);

                DataTable tot_employ1 = new DataTable();
                tot_employ1.Columns.Add("BILLNO");
                tot_employ1.Columns.Add("amount");
                string blno = "";
                double blamt = 0;
                for (int ind = 0; ind < dt_bill.Rows.Count; ind++)
                {
                    if (blno == "")
                    {
                        blno = dt_bill.Rows[ind]["BILLNO"].ToString();

                    }
                    else
                    {
                        blno = blno + Environment.NewLine + dt_bill.Rows[ind]["BILLNO"].ToString();

                    }
                    blamt = blamt + Convert.ToDouble(dt_bill.Rows[ind]["TotAmt"].ToString());

                }
                tot_employ1.Rows.Add();
                tot_employ1.Rows[0]["BILLNO"] = blno;
                tot_employ1.Rows[0]["amount"] = edpcom.GetAmountFormat(blamt);


                DataTable tot_employ2 = clsDataAccess.RunQDTbl(strssql2);

                for (int idx = 0; idx < tot_employ2.Rows.Count; idx++)
                {
                    blamt = 0;
                    blno = "";
                    strssql1 = "select BILLNO ,TotAMT from paybill where (MONTH='" + mon +
                    "') and (SESSION='" + tot_employ2.Rows[idx]["mis4"].ToString() + "') and (Comany_id='" +
                    Company_id + "') and (Location_ID =" + tot_employ2.Rows[idx]["Location_id"].ToString() + ")";
                    dt_bill = clsDataAccess.RunQDTbl(strssql1);
                    for (int ind = 0; ind < dt_bill.Rows.Count; ind++)
                    {
                        if (blno == "")
                        {
                            blno = dt_bill.Rows[ind]["BILLNO"].ToString();

                        }
                        else
                        {
                            blno = blno + Environment.NewLine + dt_bill.Rows[ind]["BILLNO"].ToString();

                        }
                        blamt = blamt + Convert.ToDouble(dt_bill.Rows[ind]["TotAmt"].ToString());

                    }
                    tot_employ2.Rows[idx]["mis6"] = blno;
                    tot_employ2.Rows[idx]["mis7"] = edpcom.GetAmountFormat(blamt);
                }
                ds.Tables.Add(tot_employ);
                ds.Tables.Add(tot_employ1);
                ds.Tables.Add(tot_employ2);
                ds.Tables[0].TableName = "ordamt";
                ds.Tables[1].TableName = "billamt";
                ds.Tables[2].TableName = "cmp";
            
            

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
        {  // populate company name combo box
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
                
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

        private void cmbclintname_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT Client_Name,client_id FROM  tbl_Employee_CliantMaster where (coid ='"+ Company_id +"')");
            if (dt.Rows.Count > 0)
            {
                cmbClient.LookUpTable = dt;
                cmbClient.ReturnIndex = 1;
            }
        }

        private void cmbclintname_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbClient.ReturnValue) == true)
                Client_id = Convert.ToInt32(cmbClient.ReturnValue);
            //string strsql = "select Location_Name  from tbl_Emp_Location where Cliant_ID=" + clsEmployee.GetClintID(cmbclintname.Text) + "";
            //DataTable dt2 = clsDataAccess.RunQDTbl(strsql);
            //DataGridViewComboBoxColumn dgcombo4 = dgemployjob.Columns["locationname"] as DataGridViewComboBoxColumn;
            //dgcombo4.Items.Clear();
            //for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            //{
            //    string st = Convert.ToString(dt2.Rows[i]["Location_Name"]);
            //    dgcombo4.Items.Add(st);
            //}
        }

        private void cmblocation_DropDown(object sender, EventArgs e)
        {
            opt = ""; coid = ""; locid = ""; clid = "";
            if (cmbcompany.ReturnValue.Trim() != "")
                coid = Convert.ToString(cmbcompany.ReturnValue.Trim());

            if (coid.Trim() != "")
            {
                opt = "Select Location_Name,Location_ID from tbl_Emp_Location where Location_ID in(select Location_ID from Companywiseid_Relation where Company_ID='" + coid.Trim() + "' )";
            }

            else
            {
                opt = "Select Location_Name,Location_ID from tbl_Emp_Location ";
            }


            DataTable dt = clsDataAccess.RunQDTbl(opt);
            if (dt.Rows.Count > 0)
            {
                cmblocation.LookUpTable = dt;
                cmblocation.ReturnIndex = 1;

            }
        }

        private void cmblocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (cmblocation.ReturnValue != "")
            {
                Locations = cmblocation.ReturnValue;

               clid= clsDataAccess.GetresultS("Select Cliant_ID from tbl_Emp_Location where (Location_ID='" + Locations + "')");


               calc_formula(cmbYear.Text, dateTimePicker1.Value.ToString("MMMM - yyyy"));

            }
        }
        public void calc_formula(string sess,string month )
        {
            string salary_structure = "";
            salary_structure = clsDataAccess.GetresultS("select SalaryStructure_ID from tbl_Employee_Link_SalaryStructure where Location_ID=" + Locations + " ");

            string s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE,atten_day,Proxy_day,Revenue_Stamp,Stamp_Amount,C_BASIS,chkALK,chkHide,mod from tbl_Employee_Assign_SalStructure where  sal_struct=" + salary_structure + " and p_type='D' and (PF_PER=1 or ESI_PER=1)";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

            }

        }

        private void dgPfEsi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button1.Enabled = false;

            }
            else
            {
                button1.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbClient.Text != "")
            {
                try
                {


                    string sqlstmnt = "SELECT Location_Name AS Location, Location_ID AS ID, Cliant_ID AS ID1  FROM tbl_Emp_Location where (Cliant_ID='" + Client_id + "')";
                    EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Location", "Select Location", 0, "CMPN", 0);

                    arritem.Clear();
                    arritem = EDPCommon.arr_mod;

                    if (arritem.Count > 0)
                    {
                        getcode_item.Clear();
                        arritem = EDPCommon.arr_mod;
                        getcode_item = EDPCommon.get_code;
                        //lblproduct.Items.Clear();
                        Item_Code = null;
                        //for (int i = 0; i <= (arritem.Count - 1); i++)
                        //{
                        //    //lblproduct.Items.Add(arritem[i].ToString());
                        //    Item_Code = Item_Code + getcode_item[i].ToString();
                        //    if (i != getcode_item.Count - 1)
                        //    {
                        //        Item_Code = "'" + Item_Code + "'" + "," + "'";
                        //    }
                        //}



                        for (int i = 0; i <= arritem.Count - 1; i++)
                        {
                            if (Item_Code == null) { Item_Code = "'" + getcode_item[i].ToString() + "'"; }
                            else { Item_Code = Item_Code + ",'" + getcode_item[i].ToString() + "'"; }
                        }


                    }


                }
                catch { }
            }
            else
            {
                MessageBox.Show("Please select client");
                return;
            }

     
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Month >= 4)
            {
                cmbYear.SelectedItem = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.AddYears(1).Year;

                // cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedItem = dateTimePicker1.Value.AddYears(-1).Year + "-" + dateTimePicker1.Value.Year;
                // cmbYear.SelectedIndex = 1;
            }


        }

        
    }

}