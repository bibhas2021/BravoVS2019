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
    public partial class frmEmployee_PayAdvice : Form //EDPComponent.FormBaseRptMidium
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
        string Locations = "",LocName="",client="";
        int Company_id = 0;
        string arrayItem = "";
        //Hashtable getcode = new Hashtable();
        Hashtable getcode_Group = new Hashtable();
        Hashtable getcode_item = new Hashtable();

        string current_company;
        string address = "";
        string address1 = "";
        string pan;
        string DURATION;
        string sq1;

        ArrayList arritem = new ArrayList();
        int Client_id = 0;
      


        string company = "", Agentadd = "", Agentadd1 = "", phone = "", Area = "", BillDate = "", User_Voucher = "";
        string challan = "", challandt = "", AmtWord = "", narrsn = "";
        string conName = "", ConAdd1 = "", Conadd2 = "";
        string amtvalue = "";
        string lorry_no = "", locname = "", modtranport = "", prtyname = "", prtyadd1 = "", prtyadd2 = "", prtycity = "", prtyctypin = "", prtytele1 = "", prtytele2 = "", prtyfax = "", prtyemail = "", prtyeccno = "", prtytin = "";
        string partycodeeee = "";
        string tentry = "", FinalAmount = "", Refvoucher = "";

        public frmEmployee_PayAdvice(string type)
        {
            InitializeComponent();
            Frm_Type = type;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmEmployee_PayAdvice_Load(object sender, EventArgs e)
        {
            //this.Text = "Payment Advice";

            //dtpForm.Text = Convert.ToString(edpcom.CURRCO_SDT);
            //dtpto.Text = Convert.ToString(edpcom.CURRCO_EDT);
            //cheDescription.Checked = true;
            //raddetails.Checked = true;
            //radAlphabetically.Checked = true;
            //this.Text = "Stock Statement";
            //txttransaction.Text = "0";
            //txtitem.Text = "0";

            chkAllEmp.Checked = false;
            //dtpidate.Value = System.DateTime.Now;
            clsValidation.GenerateYear(cmbYear, 2000, System.DateTime.Now.Year, 1);
            //set session

            //if (DateTime.Now.Month >= 4)

                try
                {
                    if (DateTime.Now.Month >= 4)
                    {
                        try
                        { cmbYear.SelectedItem = DateTime.Now.Year + "-" + DateTime.Now.AddYears(1).Year; }
                        catch { }

                    }
                    else
                    {
                        cmbYear.SelectedItem = DateTime.Now.AddYears(-1).Year + "-" + DateTime.Now.Year;

                    }
                }
                catch
                { }

            AttenDtTmPkr.Value =DateTime.Now.Date.AddMonths(-1);

            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                cmbcompany.Text = dta.Rows[0][0].ToString();

                Company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                cmbcompany.ReturnValue = Company_id.ToString();
                cmbcompany.Enabled = false;

            }
            else if (dta.Rows.Count > 1)
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

            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            //string strssql = "";
            //strssql = strssql + " select p.Cliant_ID,sum(p.billamt) as 'BillAmount',sum(s.NetPay) as 'Netpay',case when sum(p.billamt)>sum(s.NetPay) then (sum(p.billamt)-sum(s.NetPay)) ";
            //strssql = strssql + " when sum(p.billamt)<sum(s.NetPay) then (sum(s.NetPay)-sum(p.billamt)) end as 'Profit/loss' from tbl_Employee_SalaryMast s inner join paybillD p on s.Month=p.Month";
            //strssql = strssql + " and s.Location_id=p.Location_ID and s.Company_id=p.Company_id and s.Session=p.Session where s.MONTH='" + month + "' ";
            //strssql = strssql + " and s.Company_id='" + get_CompID(cmbcompany.Text) + "' and s.Location_id='" + get_LocationID(cmbsalstruc.Text) + "' and p.Cliant_ID=" + clsEmployee.GetClintID(cmbclintname.Text) + " and s.Session= '" + cmbYear.Text + "'";
            //strssql = strssql + " group by s.MONTH,p.Cliant_ID";


            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");
            DataTable tot_employ = clsDataAccess.RunQDTbl("strssql");

            dt = tot_employ.Copy();

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
            if (chkCompany.Checked == false)
            {
                if (Locations.Trim() != "")
                {
                    Retrive_DataESI();
                    if (Item_Code != "")
                    {
                        //Calling the Crystal Report viewer page 
                        MidasReport.Form1 opening = new MidasReport.Form1();
                        // Passing records to print page
                        opening.paymentAdvice_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1);

                        opening.ShowDialog();

                        ds.Tables.Clear();
                        ds.Dispose();
                    }
                    else if (chkAllEmp.Checked == true)
                    {
                        //Calling the Crystal Report viewer page 
                        MidasReport.Form1 opening = new MidasReport.Form1();
                        // Passing records to print page
                        opening.paymentAdvice_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1);

                        opening.ShowDialog();

                        ds.Tables.Clear();
                        ds.Dispose();
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Please select location");
                    return;
                }
            }
            else
            {
                Retrive_DataESI_2();
                MidasReport.Form1 opening = new MidasReport.Form1();
                // Passing records to print page
                opening.paymentAdvice_2_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1);

                opening.ShowDialog();

                ds.Tables.Clear();
                ds.Dispose();
            }
            //---------Testing Block---------
            //tstcod();
            //opening.tstPrint(ds);
            //opening.Show();
            //ds.Tables.Clear();
            //ds.Dispose();
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
            if (chkCompany.Checked == false)
            {
                if (cmbLocation.Text != "")
                {
                    Retrive_DataESI();
                    if (Item_Code != "")
                    {
                        //Calling the Crystal Report viewer page 
                        MidasReport.Form1 opening = new MidasReport.Form1();
                        // Passing records to print page
                        // opening.paymentAdvice_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1);
                        opening.paybill_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2);

                        opening.ShowDialog();

                        ds.Tables.Clear();
                        ds.Dispose();
                    }
                    else if (chkAllEmp.Checked == true)
                    {
                        //Calling the Crystal Report viewer page 
                        MidasReport.Form1 opening = new MidasReport.Form1();
                        // Passing records to print page
                        //opening.paymentAdvice_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1);
                        opening.paybill_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2);

                        opening.ShowDialog();

                        ds.Tables.Clear();
                        ds.Dispose();
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Please select location");
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
                Report_Header[1] = "P.TAX Report for the location " + locname;
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

                Report_Page_Header[0] = "Pay Slip for the location " + locname;
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
            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            string yr = Convert.ToString(AttenDtTmPkr.Value.Year);
            //strssql="";
            //strssql = strssql + " select h.BILLNO,h.BILLDATE,(select c.co_name from Company c where c.CO_CODE=h.Comany_id ) as 'coname',";
            //strssql=strssql +" (select c.CO_ADD  from Company c where c.CO_CODE=h.Comany_id ) as 'Add1',(select c.CO_ADD1   from Company c where c.CO_CODE=h.Comany_id ) as 'Add2',";
            //strssql=strssql +" (select Location_Name from tbl_Emp_Location where Location_ID=d.Location_ID ) as 'locname',h.Month,h.Session,h.TotAMT ,h.IsService,h.ServiceAmount,";
            //strssql=strssql +" d.Attendance ,d.BILLAMT,d.Dtl_id ,d.Hour,d.MonthDays,d.RATE,(select e.DesignationName  from tbl_Employee_DesignationMaster e where e.SlNo=d.desig_ID )as 'designation'";
            //strssql=strssql +"  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) ) as 'ClientName'";
            //strssql=strssql +" ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) )  as 'ClientCity'";
            //strssql=strssql +" ,(select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) ) as 'Contract_Person'";

            //strssql = strssql + " ,(select c.Contract_No    from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) ) as 'Contract_No'";
            //strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) )) AS mis1,";
            //strssql = strssql + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) ) AS mis2,";
            //strssql = strssql + " '' AS mis3,'' AS mis4,'' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,'' AS mis10";

            //strssql=strssql +" from paybill h inner join paybillD d on h.BILLNO=d.BILLNO";
            //strssql = strssql + " where h.Session='" + cmbYear.Text + "' and d.Month ='" + month + "'";
            //strssql = strssql + " and d.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and h.Comany_id='" + get_CompID(cmbcompany.Text.ToString().Trim()) + "'";


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
            strssql = strssql + " '" + month + "," + yr + "' AS mis3,'' AS mis4,'' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,(select distinct BRNCH_TELE1 from Branch B where B.GCODE=s.Company_id ) AS mis10,";
            strssql = strssql + "  e.id,' '+(CASE WHEN e.bankAc_name != '' THEN e.bankAc_name ELSE ((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) END) as 'EmpName',(case when e.pay_mod='1' then 'Bank Payment' else (case when e.pay_mod='2' then 'Cash Payment' else 'Cheque Payment' end) end) as 'ModeOfPayment',";
            strssql = strssql + " e.Bank_Name,e.Branch_Name,e.BankAcountNo,GMIno as 'IFSCCODE',e.Bank_AC_Type,s.NetPay  ";
            strssql = strssql + " from tbl_Employee_Mast e inner join tbl_Employee_SalaryMast s";
            strssql = strssql + " on e.ID=s.Emp_Id ";

            strssql = strssql + " where s.Location_id in (" + Locations + ") and (e.Bank_Name != '' or e.Bank_Name is not null) and s.Month='" + month + "' and (s.Session ='" + cmbYear.Text + "')";
            if (chkAllEmp.Checked==false )
            {
                if (Item_Code != "")
                {
                    strssql = strssql + " and s.Emp_Id in (" + Item_Code + ") ";
                }
                else
                {
                    MessageBox.Show("Please select employee");
                    return;
                }
            }
          
            DataTable tot_employ = clsDataAccess.RunQDTbl(strssql);
           
            // DataTable dtimage = clsDataAccess.RunQDTbl("select distinct Cmpimage from branch where GCODE='" + Company_id + "' ");//where id='" + CmbEmpId.Text + "'");
            ds.Tables.Add(tot_employ);
            strssql = "";
           strssql = strssql + " select ";
            strssql = strssql + " (select c.co_name from Company c where c.CO_CODE=S.Company_id ) as 'coname',";
            strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=s.Company_id ) as 'Add1',(select c.CO_ADD1   from Company c where c.CO_CODE=s.Company_id ) as 'Add2', ";
            strssql = strssql + " (select Location_Name from tbl_Emp_Location where Location_ID=S.Location_ID ) as 'locname',";

            strssql = strssql + " '' as 'designation'";
            strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'ClientName'";
            strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )  as 'ClientCity'";
            strssql = strssql + " ,(select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'Contract_Person'";

            strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )) AS mis1,";
            strssql = strssql + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) AS mis2,";
            strssql = strssql + " '" + month + "," + yr + "' AS mis3,'' AS mis4,'' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,(select distinct BRNCH_TELE1 from Branch B where B.GCODE=s.Company_id ) AS mis10,";
            strssql = strssql + " '' AS id, ODName as EmpName, Bank as Bank_Name, Branch as Branch_Name, AcNo as BankAcountNo, IFSC as IFSCCODE,'' as Bank_AC_Type, Amount as NetPay";
            strssql = strssql + " FROM tbl_Employee_Sal_OCharges AS s  where s.Location_id in (" + Locations + ") and s.Month='" + month + "' and (s.Session ='" + cmbYear.Text + "')";
            //ds.Tables.Add(dtimage);
            DataTable tot_employ2 = clsDataAccess.RunQDTbl(strssql);

            ds.Tables[0].Merge(tot_employ2);
            ds.Tables[0].TableName = "paymentAdvice";
            //ds.Tables[1].TableName = "Branch";


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


        private void Retrive_DataESI_2()
        {


            //string Str_ErHead_basic = "";
            //DataTable ErHead_basic = clsDataAccess.RunQDTbl("select top 1  SalaryHead_Short from tbl_Employee_ErnSalaryHead");
            //Str_ErHead_basic = ErHead_basic.Rows[0][0].ToString();

            string strssql = "";
            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            string yr = Convert.ToString(AttenDtTmPkr.Value.Year);
            
            strssql = strssql + " select ";
            strssql = strssql + " (select c.co_name from Company c where c.CO_CODE=S.Company_id ) as 'coname',";
            strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=s.Company_id ) as 'Add1',(select c.CO_ADD1   from Company c where c.CO_CODE=s.Company_id ) as 'Add2', ";
            strssql = strssql + " (select Location_Name + ' ' from tbl_Emp_Location where Location_ID=S.Location_ID FOR XML PATH('')) as 'locname',";

            strssql = strssql + " (select e.DesignationName  from tbl_Employee_DesignationMaster e where e.SlNo=S.desig_ID )as 'designation'";
            strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'ClientName'";
            strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )  as 'ClientCity'";
            strssql = strssql + " ,(select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'Contract_Person'";

            strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )) AS mis1,";
            strssql = strssql + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) AS mis2,";
            strssql = strssql + " '" + month + "," + yr + "' AS mis3,'' AS mis4,'' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,(select distinct BRNCH_TELE1 from Branch B where B.GCODE=s.Company_id ) AS mis10,";
            strssql = strssql + "  e.id,' '+(CASE WHEN e.bankAc_name != '' THEN e.bankAc_name ELSE ((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) END) as 'EmpName',(case when e.pay_mod='1' then 'Bank Payment' else (case when e.pay_mod='2' then 'Cash Payment' else 'Cheque Payment' end) end) as 'ModeOfPayment',";
            strssql = strssql + " e.Bank_Name,e.Branch_Name,e.BankAcountNo,GMIno as 'IFSCCODE',e.Bank_AC_Type,e.Bank_AC_Type,s.NetPay  ";
            strssql = strssql + " from tbl_Employee_Mast e inner join tbl_Employee_SalaryMast s";
            strssql = strssql + " on e.ID=s.Emp_Id ";

            strssql = strssql + " where (s.Location_id in (select distinct(Location_ID) from Companywiseid_Relation where Company_ID='"+Company_id+"')) and (s.Month='" + month + "') and (s.Session ='" + cmbYear.Text + "')";
            //if (chkAllEmp.Checked == false)
            //{
            //    if (Item_Code != "")
            //    {
            //        strssql = strssql + " and s.Emp_Id in (" + Item_Code + ") ";
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please select employee");
            //        return;
            //    }
            //}

            DataTable tot_employ = clsDataAccess.RunQDTbl(strssql);
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
                            tot_employ.Rows[orginalEmpIdPos]["locname"] = tot_employ.Rows[orginalEmpIdPos]["locname"].ToString() +", "+ tot_employ.Rows[i]["locname"].ToString();
                                
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
            // DataTable dtimage = clsDataAccess.RunQDTbl("select distinct Cmpimage from branch where GCODE='" + Company_id + "' ");//where id='" + CmbEmpId.Text + "'");
            ds.Tables.Add(tot_employ);
            strssql = "";
            strssql = strssql + " select ";
            strssql = strssql + " (select c.co_name from Company c where c.CO_CODE=S.Company_id ) as 'coname',";
            strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=s.Company_id ) as 'Add1',(select c.CO_ADD1   from Company c where c.CO_CODE=s.Company_id ) as 'Add2', ";
            strssql = strssql + " (select Location_Name from tbl_Emp_Location where Location_ID=S.Location_ID ) as 'locname',";

            strssql = strssql + " '' as 'designation'";
            strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'ClientName'";
            strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )  as 'ClientCity'";
            strssql = strssql + " ,(select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) as 'Contract_Person'";

            strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) )) AS mis1,";
            strssql = strssql + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=S.Location_ID ) ) AS mis2,";
            strssql = strssql + " '" + month + "," + yr + "' AS mis3,'' AS mis4,'' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,(select distinct BRNCH_TELE1 from Branch B where B.GCODE=s.Company_id ) AS mis10,";
            strssql = strssql + " '' AS id, ODName as EmpName, Bank as Bank_Name, Branch as Branch_Name, AcNo as BankAcountNo, IFSC as IFSCCODE,'' AS Bank_AC_Type, Amount as NetPay";
            strssql = strssql + " FROM tbl_Employee_Sal_OCharges AS s  where (s.Location_id in (select distinct(Location_ID) from Companywiseid_Relation where Company_ID='" + Company_id + "')) and s.Month='" + month + "' and (s.Session ='" + cmbYear.Text + "')";
            //ds.Tables.Add(dtimage);
            DataTable tot_employ2 = clsDataAccess.RunQDTbl(strssql);

            ds.Tables[0].Merge(tot_employ2);
            ds.Tables[0].TableName = "paymentAdvice";

            

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


            if (dt.Rows.Count > 1)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
                cmbLocation.Text = "";
            }
            else if (dt.Rows.Count > 0)
            {
                cmbcompany.Text = dt.Rows[0][0].ToString();

                Company_id = Convert.ToInt32(dt.Rows[0][1].ToString());
                cmbcompany.ReturnValue = Company_id.ToString();
                cmbLocation.Text = "";
            }
            else
            {
                Company_id = 0;
                cmbcompany.Text = "";
                MessageBox.Show("No Company");
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
            if (rdbRegular.Checked == true)
            {
                if (chkCompany.Checked == false)
                {
                    Retrive_DataESI();

                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
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
                        Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                        excel.Visible = true;
                        int iCol = 0;

                        excel.Cells[1, 1] = dtCloned.Rows[0]["coname"].ToString().Trim();
                        Excel.Range range = range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 9]);
                        range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        excel.Cells[2, 1] = dtCloned.Rows[0]["Add1"].ToString().Trim();
                        range = range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 9]);
                        range.Merge(true);
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        excel.Cells[3, 1] = dtCloned.Rows[0]["Add2"].ToString().Trim();
                        range = range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, 9]);
                        range.Merge(true);
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        excel.Cells[4, 1] = "Phone : " + dtCloned.Rows[0]["Mis10"].ToString().Trim();
                        range = range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, 9]);
                        range.Merge(true);
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        excel.Cells[5, 1] = "Payment Advice for the month of " + dtCloned.Rows[0]["Mis3"].ToString().Trim();
                        range = range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, 9]);
                        range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        if (rdbLocation_multi.Checked == true)
                        {
                            excel.Cells[6, 1] = "Multi Location";
                        }
                        else
                        {
                            excel.Cells[6, 1] = "Location : " + dtCloned.Rows[0]["locname"].ToString().Trim();
                        }
                        range = range = worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[6, 9]);
                        range.Merge(true);
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        //foreach (DataColumn c in dtCloned.Columns)
                        //{
                        //iCol++;
                        //excel.Cells[7, iCol] = c.ColumnName;
                        // }

                        excel.Cells[7, 1] = "Slno";
                        excel.Cells[7, 2] = "Employee Name";
                        excel.Cells[7, 3] = "Bank Name";
                        excel.Cells[7, 4] = "Branch Name";
                        excel.Cells[7, 5] = "A/c No";
                        excel.Cells[7, 6] = "Ifsc Code";
                        excel.Cells[7, 7] = "Type";
                        excel.Cells[7, 8] = "Mode of Payment";
                        excel.Cells[7, 9] = "Net Pay";

                        range = range = worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[7, 9]);
                        // range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        int iRow = 7;
                        iCol = 0;
                        foreach (DataRow r in dtCloned.Rows)
                        {
                            iRow++;
                            iCol++;
                            //foreach (DataColumn c in dtCloned.Columns)
                            //{
                            try
                            {
                                // iCol++;
                                excel.Cells[iRow, 1] = iCol;
                                excel.Cells[iRow, 2] = r["EmpName"].ToString().Trim();
                                excel.Cells[iRow, 3] = r["Bank_Name"].ToString().Trim();
                                excel.Cells[iRow, 4] = r["Branch_Name"].ToString().Trim();
                                excel.Cells[iRow, 5] = "'" + r["BankAcountNo"].ToString().Trim();
                                excel.Cells[iRow, 6] = "'" + r["IfscCode"].ToString().Trim();
                                excel.Cells[iRow, 7] = r["Bank_Ac_Type"].ToString().Trim();
                                excel.Cells[iRow, 8] = r["ModeOfPayment"].ToString().Trim();
                                excel.Cells[iRow, 9] = r["Netpay"].ToString().Trim();
                            }
                            catch
                            {

                            }
                            //}

                        }
                        iRow++;
                        iCol = 0;
                        excel.Cells[iRow, 1] = "";
                        excel.Cells[iRow, 2] = "Total : ";
                        excel.Cells[iRow, 3] = "";
                        excel.Cells[iRow, 4] = "";
                        excel.Cells[iRow, 5] = "";
                        excel.Cells[iRow, 6] = "";
                        excel.Cells[iRow, 7] = "";
                        excel.Cells[iRow, 8] = "";
                        excel.Cells[iRow, 9] = dtCloned.Compute("SUM([Netpay])", "");

                        range = range = worksheet.get_Range(worksheet.Cells[iRow, 1], worksheet.Cells[iRow, 9]);
                        // range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;


                        object missing = System.Reflection.Missing.Value;

                        //Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;



                        range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[iRow, 9]);
                        Excel.Borders borders = range.Borders;
                        //Set the thick lines style.
                        borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        borders.Weight = 2d;
                        // range.WrapText = true;

                        ((Excel._Worksheet)worksheet).Activate();
                        worksheet.UsedRange.Select();

                        worksheet.Columns.AutoFit();

                        MessageBox.Show("Export To ExcelCompleted!", "Export");
                        ds.Tables.Clear();
                        ds.Dispose();
                        // ((Excel._Worksheet)worksheet).Activate();

                        //((Excel._Application)excel).Quit();
                    }
                    else
                    {
                        MessageBox.Show("There is no Record to export to excel!", "Export");
                    }

                    dt.Dispose();
                    dt.Clear();
                }
                else
                {

                    Retrive_DataESI_2();

                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
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
                        Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                        excel.Visible = true;
                        int iCol = 0;

                        excel.Cells[1, 1] = dtCloned.Rows[0]["coname"].ToString().Trim();
                        Excel.Range range = range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 10]);
                        range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        excel.Cells[2, 1] = dtCloned.Rows[0]["Add1"].ToString().Trim();
                        range = range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 10]);
                        range.Merge(true);
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        excel.Cells[3, 1] = dtCloned.Rows[0]["Add2"].ToString().Trim();
                        range = range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, 10]);
                        range.Merge(true);
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        excel.Cells[4, 1] = "Phone : " + dtCloned.Rows[0]["Mis10"].ToString().Trim();
                        range = range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, 10]);
                        range.Merge(true);
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        excel.Cells[5, 1] = "Payment Advice for the month of " + dtCloned.Rows[0]["Mis3"].ToString().Trim();
                        range = range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, 10]);
                        range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;


                        excel.Cells[6, 1] = "Slno";
                        excel.Cells[6, 2] = "Employee Name";
                        excel.Cells[6, 3] = "Locations";
                        excel.Cells[6, 4] = "Bank Name";
                        excel.Cells[6, 5] = "Branch Name";
                        excel.Cells[6, 6] = "A/c No";
                        excel.Cells[6, 7] = "Ifsc Code";
                        excel.Cells[6, 8] = "Type";
                        excel.Cells[6, 9] = "Mode of Payment";
                        excel.Cells[6, 10] = "Net Pay";

                        range = range = worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[6, 10]);
                        // range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        int iRow = 6;
                        iCol = 0;
                        foreach (DataRow r in dtCloned.Rows)
                        {
                            iRow++;

                            //foreach (DataColumn c in dtCloned.Columns)
                            //{
                            try
                            {
                                // iCol++;
                                excel.Cells[iRow, 1] = iCol++;
                                excel.Cells[iRow, 2] = r["EmpName"].ToString().Trim();
                                excel.Cells[iRow, 3] = r["locname"].ToString().Trim();
                                excel.Cells[iRow, 4] = r["Bank_Name"].ToString().Trim();
                                excel.Cells[iRow, 5] = r["Branch_Name"].ToString().Trim();
                                excel.Cells[iRow, 6] = "'" + r["BankAcountNo"].ToString().Trim();
                                excel.Cells[iRow, 7] = "'" + r["IfscCode"].ToString().Trim();
                                excel.Cells[iRow, 8] = r["Bank_Ac_Type"].ToString().Trim();
                                excel.Cells[iRow, 9] = r["ModeOfPayment"].ToString().Trim();
                                excel.Cells[iRow, 10] = r["Netpay"].ToString().Trim();
                            }
                            catch
                            {

                            }
                            //}

                        }
                        iRow++;
                        iCol = 0;
                        excel.Cells[iRow, 1] = "";
                        excel.Cells[iRow, 2] = "Total : ";
                        excel.Cells[iRow, 3] = "";
                        excel.Cells[iRow, 4] = "";
                        excel.Cells[iRow, 5] = "";
                        excel.Cells[iRow, 6] = "";
                        excel.Cells[iRow, 7] = "";
                        excel.Cells[iRow, 8] = "";
                        excel.Cells[iRow, 9] = "";
                        excel.Cells[iRow, 10] = dtCloned.Compute("SUM([Netpay])", "");

                        range = range = worksheet.get_Range(worksheet.Cells[iRow, 1], worksheet.Cells[iRow, 10]);
                        // range.Merge(true);
                        range.Font.Bold = true;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;


                        object missing = System.Reflection.Missing.Value;

                        //Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;



                        range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[iRow, 10]);
                        Excel.Borders borders = range.Borders;
                        //Set the thick lines style.
                        borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        borders.Weight = 2d;
                        // range.WrapText = true;

                        ((Excel._Worksheet)worksheet).Activate();
                        worksheet.UsedRange.Select();

                        worksheet.Columns.AutoFit();

                        MessageBox.Show("Export To ExcelCompleted!", "Export");
                        ds.Tables.Clear();
                        ds.Dispose();

                    }
                    else
                    {
                        MessageBox.Show("There is no Record to export to excel!", "Export");
                    }

                    dt.Dispose();
                    dt.Clear();
                }
            }
            else
            {
                string sub = "",sqry="";

                if (chkCompany.Checked == true)
                {
                  sub= "Multi Location";
                  sqry = "'' as 'ref','' as 'narration'";

                  Locations = " select distinct Location_id from tbl_Employee_SalaryMast where (Month='" + AttenDtTmPkr.Value.ToString("MMMM") + "') and (Session ='" + cmbYear.Text.Trim() + "') and (company_id=" + Company_id + ")";
                }
                else
                {

                    sub = "Location : " + cmbLocation.Text.Trim();

                    sqry = "'" + LocName.Trim() + "' as 'ref','"+client+", "+LocName.Trim()+", "+ AttenDtTmPkr.Value.ToString("MMMM yyyy")+"' as 'narration'";
                }
                DataTable tot_employ = new DataTable();
                if (rdbCMS_sbi.Checked==true)
                {
                    tot_employ = clsDataAccess.RunQDTbl("select row_number() over(order by e.ID) as Slno," +
                              "((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) as 'ENAME'," +
                              "e.Bank_Name as 'BankName',e.Branch_Name as 'BranchName',e.BankAcountNo as 'BankAcNo',GMIno as 'Ifsc','" +
                              System.DateTime.Now.ToString("dd/MM/yyyy") + "#' as dt,s.[NETPay]," + sqry + ",'SBI' as 'neft' from tbl_Employee_Mast e," +
                              "(select Emp_Id, sum(NetPay) as 'NETPay' from tbl_Employee_SalaryMast where (Location_id in (" + Locations + ")) and (Month='" +
                              AttenDtTmPkr.Value.ToString("MMMM") + "') and (Session ='" + cmbYear.Text.Trim() + "') group by Emp_Id)s where (e.ID=s.Emp_Id)  and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1) and ({ fn LCASE(e.Bank_Name)} in ('sbi','state bank of india'))");

                }
                else if (rdbCms_Neft.Checked == true)
                {
                    tot_employ = clsDataAccess.RunQDTbl("select row_number() over(order by e.ID) as Slno," +
          "((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) as 'ENAME'," +
          "e.Bank_Name as 'BankName',e.Branch_Name as 'BranchName',e.BankAcountNo as 'BankAcNo',GMIno as 'Ifsc','" +
          System.DateTime.Now.ToString("dd/MM/yyyy") + "#' as dt,s.[NETPay]," + sqry + ",'NEFT' as 'neft' from tbl_Employee_Mast e," +
          "(select Emp_Id, sum(NetPay) as 'NETPay' from tbl_Employee_SalaryMast where (Location_id in (" + Locations + ")) and (Month='" +
          AttenDtTmPkr.Value.ToString("MMMM") + "') and (Session ='" + cmbYear.Text.Trim() + "') group by Emp_Id)s where (e.ID=s.Emp_Id)  and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=1) and ({ fn LCASE(e.Bank_Name)} not in ('sbi','state bank of india'))");

                }
                else
                {
                    tot_employ = clsDataAccess.RunQDTbl("select row_number() over(order by e.ID) as Slno," +
          "((CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.MiddleName)) != '' THEN e.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN e.LastName + ' ' ELSE '' END)) as 'ENAME'," +
          "e.Bank_Name as 'BankName',e.Branch_Name as 'BranchName',e.BankAcountNo as 'BankAcNo',GMIno as 'Ifsc','" +
          System.DateTime.Now.ToString("dd/MM/yyyy") + "#' as dt,s.[NETPay]," + sqry + ",'CASH' as 'neft' from tbl_Employee_Mast e," +
          "(select Emp_Id, sum(NetPay) as 'NETPay' from tbl_Employee_SalaryMast where (Location_id in (" + Locations + ")) and (Month='" +
          AttenDtTmPkr.Value.ToString("MMMM") + "') and (Session ='" + cmbYear.Text.Trim() + "') group by Emp_Id)s where (e.ID=s.Emp_Id)  and ((ltrim(rtrim(e.BankAcountNo))!='') or (ltrim(rtrim( e.GMIno))!='')) and (e.pay_mod=2)");


                }

               


                double tot = 0;
                if (tot_employ.Rows.Count > 0)
                {
                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                    excel.Visible = true;
                    int iCol = tot_employ.Columns.Count;
                    string words = "";
                    Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;

                    excel.Cells[1, 1] = "Payment Advice for the month of " + AttenDtTmPkr.Value.ToString("MMMM,yyyy");

                    Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);
                    range.Merge(true);
                    range.Font.Bold = true;
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; 
                    //Excel.XlHAlign.xlHAlignCenter;
                    range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    range.Columns.AutoFit();
                    range.Rows.AutoFit();


                    excel.Cells[2, 1] = sub;
                    range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);
                    range.Merge(true);
                    range.Font.Bold = true;
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //Excel.XlHAlign.xlHAlignCenter;
                    range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    range.Columns.AutoFit();
                    range.Rows.AutoFit();



                    int rw1 = 3;

                    excel.Cells[rw1, 1] = "Slno";
                    excel.Cells[rw1, 2] = "Employee Name";
                    excel.Cells[rw1, 3] = "Bank Name";
                    excel.Cells[rw1, 4] = "Branch Name";
                    excel.Cells[rw1, 5] = "A/c No";
                    excel.Cells[rw1, 6] = "Ifsc Code";
                    excel.Cells[rw1, 7] = "DT";
                    excel.Cells[rw1, 8] = "Net Pay";
                    excel.Cells[rw1, 9] = "Ref";
                    excel.Cells[rw1, 10] = "Narration";
                    excel.Cells[rw1, 11] = "Pay Mode";

                    rw1 = rw1 + 1;
                    tot = 0;
                    for (int ix = 0; ix < tot_employ.Rows.Count; ix++)
                    {
                        tot = tot + Convert.ToDouble(tot_employ.Rows[ix]["NetPay"].ToString());

                        rw1++;
                        excel.Cells[rw1, 1] = Convert.ToDouble(tot_employ.Rows[ix]["Slno"]).ToString("0");
                        excel.Cells[rw1, 2] = tot_employ.Rows[ix]["ENAME"].ToString().Trim();
                        excel.Cells[rw1, 3] = tot_employ.Rows[ix]["BankName"].ToString().Trim();
                        excel.Cells[rw1, 4] = tot_employ.Rows[ix]["BranchName"].ToString().Trim();
                        excel.Cells[rw1, 5] = "'" + tot_employ.Rows[ix]["BankAcNo"].ToString().Trim();
                        excel.Cells[rw1, 6] = "'" + tot_employ.Rows[ix]["Ifsc"].ToString().Trim();
                        excel.Cells[rw1, 7] = tot_employ.Rows[ix]["dt"].ToString().Trim();
                        excel.Cells[rw1, 8] = Convert.ToDouble(tot_employ.Rows[ix]["NETPay"]).ToString("0").Trim();

                        excel.Cells[rw1, 9] = tot_employ.Rows[ix]["ref"].ToString().Trim();
                        excel.Cells[rw1, 10] = tot_employ.Rows[ix]["narration"].ToString().Trim();
                        excel.Cells[rw1, 11] = tot_employ.Rows[ix]["neft"].ToString().Trim();
                    }

                    rw1++;
                    //iCol = 0;
                    excel.Cells[rw1, 1] = "";
                    excel.Cells[rw1, 2] = "Total : ";
                    excel.Cells[rw1, 3] = "";
                    excel.Cells[rw1, 4] = "";
                    excel.Cells[rw1, 5] = "";
                    excel.Cells[rw1, 6] = "";
                    excel.Cells[rw1, 7] = "";
                    excel.Cells[rw1, 8] = tot.ToString("0");
                    excel.Cells[rw1, 9] = "";
                    excel.Cells[rw1, 10] = "";
                    excel.Cells[rw1, 11] = "";

                    range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rw1, iCol]);
                    Excel.Borders borders = range.Borders;
                    //Set the thick lines style.
                    borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    borders.Weight = 2d;
                    range.WrapText = true;

                    range.Columns.AutoFit();
                    range.Rows.AutoFit();

                }
                else
                {
                    MessageBox.Show("No Record Found", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
            if (cmbLocation.Text != "")
            {
                try
                {
                    string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

                    string sqlstmnt = "Select (select e.Title+' '+e.FirstName+' '+e.MiddleName+' '+ e.LastName from tbl_Employee_Mast e where e.ID=s.emp_id) as 'EmpName',s.emp_id as 'ID',Date_of_Insert from tbl_Employee_SalaryMast s where s.Month='" + month + "' and s.Session ='" + cmbYear.Text + "' and s.Location_id in (" + Locations + ")";
                    EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Employee", "Select Employee", 0, "CMPN", 0);

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

                        Item_Code = "''";

                        for (int i = 0; i <= arritem.Count - 1; i++)
                        {
                            Item_Code = Item_Code + "," + "'" + getcode_item[i].ToString() + "'";

                        }


                    }


                }
                catch { }
            }
            else
            {
                MessageBox.Show("Please select location");
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllEmp.Checked == true)
            {
                button1.Enabled = false;
                chkCompany.Checked = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            string s = "";
            if (rdbLocation_multi.Checked == true)
            {
                s = " select  l.Location_Name,l.Location_ID  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID = '" + Company_id + "'";
            }
            else if (rdbLocation_single.Checked == true)
            {
                s = " select  l.Location_Name,l.Location_ID  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID = '" + Company_id + "'";
            }
            else
            {
                s = "select distinct (select Client_Name FROM tbl_Employee_CliantMaster where  Client_id= l.Cliant_ID) as 'Client', l.Cliant_ID  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where (l.Location_ID = ls.Location_ID) and (l.Location_ID =r.Location_ID) and (company_ID = '" + Company_id + "')";
            }
          DataTable dt = clsDataAccess.RunQDTbl(s);
          if (dt.Rows.Count > 0)
          {
              cmbLocation.LookUpTable = dt;
              cmbLocation.ReturnIndex = 1;
              //cmbsalstruc.Items.Clear();
          }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
            {
                Locations = Convert.ToString(cmbLocation.ReturnValue);
                LocName = Convert.ToString(cmbLocation.Text);

                client = clsDataAccess.ReturnValue("Select (SELECT top 1 Client_Name FROM  tbl_Employee_CliantMaster where client_id=L.Cliant_ID)as ClientName from tbl_Emp_Location L where Location_ID="+ Locations);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
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

        private void chkCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompany.Checked == true)
            {
                chkAllEmp.Checked = false;
                cmbLocation.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                cmbLocation.Enabled = true;
            }
        }

        private void rdbRegular_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRegular.Checked == true)
            {
                btnPreview.Enabled = true;
                lblMsg.Text = "";
            }
            else
            {
                btnPreview.Enabled = false;
                if (rdbCms_Cash.Checked == true)
                {
                    lblMsg.Text = "On Select of Cash Empployee with Payment mode 'Cash' will be generated";
                }
                else
                {
                    lblMsg.Text = "On Select of SBI / NEFT Employees who's Payment mode is 'Bank' will be generated.";
                }
            }
        }

        private void btnloc_Click(object sender, EventArgs e)
        {
            string s = "";
            if (rdbLocation_multi.Checked == true)
            {
                s = " select  l.Location_Name,l.Location_ID ,(select Client_Name FROM tbl_Employee_CliantMaster where  Client_id= l.Cliant_ID) as 'Client' from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and c(ompany_ID = '" + Company_id + "')";
            }
            else
            {
                MessageBox.Show("Select Location wise");
                return;
            }

            EDPCommon.MLOV_EDP(s, "Tag Item", "Select Location", "Select Location", 0, "CMPN", 0);
            arr.Clear();
            arr = EDPCommon.arr_mod;
           // lbllog.Items.Clear();
            if (arr.Count > 0)
            {
                getcode.Clear();
                arr = EDPCommon.arr_mod;
                getcode = EDPCommon.get_code;
                //lbllog.Items.Clear();
                Item_Code = "";

                for (int i = 0; i <= (arr.Count - 1); i++)
                {
                   // lbllog.Items.Add(arr[i].ToString());
                    Item_Code = Item_Code + getcode[i].ToString();
                    if (i != getcode.Count - 1)
                    {
                        Item_Code = Item_Code + ",";
                    }
                }
                Locations = Item_Code;
            }
        }

        private void rdbLocation_multi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLocation_multi.Checked == true)
            {
                btnloc.Visible = true;
                cmbLocation.Visible = false;
            }
            else
            {
                btnloc.Visible = false;
            }
        }

        private void rdbLocation_single_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLocation_single.Checked == true)
            {
                cmbLocation.Visible = true;
                btnloc.Visible = false;
            }
            else
            {
                cmbLocation.Visible = false;
            }
        }


    }

}