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
using CrystalDecisions.Shared;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;

//ANURAG

namespace PayRollManagementSystem
{
    public partial class frmEmployeePaySlipRpt : EDPComponent.FormBaseRptMidium
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
        DataTable tot_employ = new DataTable();
        DataTable tot_employ1 = new DataTable();
        DataTable tot_employ2 = new DataTable();
        string Frm_Type = "";
        int Head_Cou = 0;
        string Locations = "", vw_sql="";
        int Company_id = 0, Location_id = 0, cWD_MOD = 0, cdoj = 0, email = 0, cnt_lv = 0, Woff=0;
        DataTable dtps = new DataTable();
        string current_company;
        string address = "";
        string address1 = "";
        string pan;
        string DURATION;
        string sq1;

        //021115

        DataTable billing = new DataTable();
        string tentry = "", FinalAmount = "", Refvoucher = "";
        //string current_company = "", address = "", address1 = "", pan = "", DURATION = "", TinNo1 = "";
        string company = "", Agentadd = "", Agentadd1 = "", phone = "", Area = "", BillDate = "", User_Voucher = "";
        string challan = "", challandt = "", AmtWord = "", narrsn = "";
        string conName = "", ConAdd1 = "", Conadd2 = "";
        string amtvalue = "";
        string lorry_no = "", locname = "", modtranport = "", prtyname = "", prtyadd1 = "", prtyadd2 = "", prtycity = "", prtyctypin = "", prtytele1 = "", prtytele2 = "", prtyfax = "", prtyemail = "", prtyeccno = "", prtytin = "";
        string partycodeeee = "",sub = "";
        int psgs = 0;
        //021115
        string path = "";
        DataTable dt_emp = new DataTable();

        public frmEmployeePaySlipRpt(string type)
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
            this.Text = "Pay Slip";
            //dtpForm.Text = Convert.ToString(edpcom.CURRCO_SDT);
            //dtpto.Text = Convert.ToString(edpcom.CURRCO_EDT);
            //cheDescription.Checked = true;
            //raddetails.Checked = true;
            //radAlphabetically.Checked = true;
            //this.Text = "Stock Statement";
            //txttransaction.Text = "0";
            //txtitem.Text = "0";

            cWD_MOD = 0; cdoj = 0; email = 0; // designation wise mod

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
                email = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select email from CompanyLimiter")));
            }
            catch
            {
                email = 0;
            }


            try
            {
                cdoj = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select ps_hide_doj from CompanyLimiter")));
            }
            catch
            {
                cdoj = 0;
            }
            //dtpidate.Value = System.DateTime.Now;
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            AttenDtTmPkr.Value = DateTime.Now.AddMonths(-1);
            cnt_lv = 0;
            try
            {
                cnt_lv = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select lv from CompanyLimiter")));
            }
            catch { cnt_lv = 0; }
            //set session
            //if (System.DateTime.Now.Month >= 4)
            //{
            //    cmbYear.SelectedIndex = 0;
            //}
            //else
            //{
            //    cmbYear.SelectedIndex = 1;
            //}
            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbcompany.Text = Convert.ToString(dt_co.Rows[0][0]);

                Company_id = Convert.ToInt32(dt_co.Rows[0][1]);
                cmbcompany.ReturnValue = Company_id.ToString();
                cmbcompany.Enabled = false;
                cmbLoc.Enabled = false;

            }
            else if (dt_co.Rows.Count > 1)
            {
                cmbcompany.PopUp();
                cmbLoc.Enabled = false;

            }
       
      
            
            psgs = Convert.ToInt32(clsDataAccess.GetresultS("select payslip FROM CompanyLimiter"));

            if (email == 1)
            {
                pnlMail.Visible = false;
                btnEmail_prev.Visible = true;
                DataTable dt_config = clsDataAccess.RunQDTbl("SELECT MailSign,usr,pass,host,ssl,port,coid FROM config_mail");
                if (dt_config.Rows.Count > 0)
                {
                    txtSignature.Text = dt_config.Rows[0]["MailSign"].ToString();
                    TxtEmail.Text = dt_config.Rows[0]["usr"].ToString();
                    txtPassword.Text = dt_config.Rows[0]["pass"].ToString();
                    txtPort.Text = dt_config.Rows[0]["port"].ToString();
                    txthost.Text = dt_config.Rows[0]["host"].ToString();

                    if (dt_config.Rows[0]["ssl"].ToString() == "1")
                    {
                        chk_enableSsl.Checked = true;
                    }
                    else
                    {
                        chk_enableSsl.Checked = false;
                    }

                    //groupBox1.Visible = true;
                }
                else
                {
                    txtSignature.Text = "";
                    TxtEmail.Text = "";
                    txtPassword.Text = "";
                    txtPort.Text = "";
                    txthost.Text = "";
                    chk_enableSsl.Checked = false;
                    //groupBox1.Visible = false;
                }
            }
            else
            {
                pnlMail.Visible = false;
                txtSignature.Text = "";
                TxtEmail.Text = "";
                txtPassword.Text = "";
                txtPort.Text = "";
                txthost.Text = "";
                chk_enableSsl.Checked = false;
                btnEmail_prev.Visible = false;
            }


            if (rdbLocation.Checked == true)
            {
                btnWS.Visible = true;
            }
            else
            {
                btnWS.Visible = false;

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

        //ANURAG

        public void nc()
        {

            lbl_NC.Text = clsDataAccess.ReturnValue("select COUNT(*) from tbl_Employee_Assign_SalStructure where (Location_id=" + Location_id + ") and NCompliance=1");

            lbl_OT.Text = clsDataAccess.ReturnValue("select count(SAL_HEAD) from tbl_Employee_Assign_SalStructure eas where (Location_id=" + Location_id + ") and NCompliance=1 and Proxy_day=1");  // OTA

            lbl_ED.Text = clsDataAccess.ReturnValue("select count(SAL_HEAD) from tbl_Employee_Assign_SalStructure eas where (Location_id=" + Location_id + ") and NCompliance=1 and Proxy_day=2");  // ED


        }
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


            try
            {
                Woff = Convert.ToInt32(clsDataAccess.GetresultS("select PsWO from Companywiseid_Relation where (Location_ID='" + Locations + "')"));// location wise wo
            }
            catch { Woff = 0; }



            if (cmbcompany.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Please Select the Company Name", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
            else
            {
                if (Convert.ToInt32(clsDataAccess.ReturnValue("select isNull(payslip,0) FROM CompanyLimiter")) == 3)
                {
                    Retrive_Data_rate();
                }
                else
                {
                    Retrive_Data();
                }
                //Printheader();
                if (psgs==5)
                {
                    if (ds.Tables["sss"].Rows.Count > 0)
                    {
                        for (int idx = 0; idx < ds.Tables["sss"].Rows.Count; idx++)
                        {
                            ds.Tables["sss"].Rows[idx]["Salary"] = ds.Tables["sss"].Rows[idx]["Total_Earning"].ToString();
                        }
                    }

                }
                MidasReport.Form1 opening = new MidasReport.Form1();
                //edpcom.CURRENT_COMPANY
                if (rdbLocation.Checked == true)
                {
                    opening.grn_print(txtDept.Text, ds, "", Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, psgs,0);
                }
                else if (rdbCompany.Checked == true)
                {

                    opening.CompositePayslip_print(edpcom.CURRENT_COMPANY, ds, narrsn, 3, "");

                }
                opening.Show();

                if (email == 1)
                {

                    DataTable dt_emp = clsDataAccess.RunQDTbl(vw_sql);
                        //cnn.SP_Dync_Proc_Val("select * FROM tbl_Employee_Attend AS ea WHERE (month= '" + dtpSal.Value.ToString("MMM") + "' ) AND (year ='" + dtpSal.Value.ToString("yyyy") + "') and (coid='" + lblcoid.Text + "')");



                }

                ds.Tables.Clear();
                ds.Dispose();
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
            Retrive_Data();
            MidasReport.Form1 opening = new MidasReport.Form1();
            opening.grn_print(edpcom.CURRENT_COMPANY, ds, sub, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2,1);
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
                Report_Header[1] = "Pay Slip for the location " + cmbLoc.Text;
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

                Report_Page_Header[0] = "Pay Slip for the location " + cmbLoc.Text;
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



                //if (CmbReport.SelectedIndex == 0)
                //{
                //    for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                //    {
                //        string ao = dt1.Columns[i].ToString();
                //        //Report_Columns_Header[i] = ao+ "              ";

                //        Report_Columns_Header[i] = ao + "                     ";
                //    }
                //}
                //else
                //{
                //    for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                //    {
                //        string ao = dt1.Columns[i].ToString();
                //        Report_Columns_Header[i] = ao + "                                       ";
                //    }
                //}

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
              //  cmbsalstruc.Items.Clear();
                //////s = "select  l.Location_Name  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls where l.Location_ID = ls.Location_ID and Location_ID = '" + get_LocationID(cmbsalstruc.Text) + "'";
                s = " select  l.Location_Name,l.Location_ID  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID = '" + get_CompID(cmbcompany.Text) + "'";
               
               // Load_Data1(s, cmbsalstruc, -1);
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
            if (cmbLoc.Text=="")
            {
                ERPMessageBox.ERPMessage.Show("Location  must be entered");
                return ;
            }
            else
            {
                Locations = Convert.ToString(get_LocationID(cmbLoc.Text));
            }
        }

        //ANURAG
        private void Retrive_Data()
        {
            Boolean flug_deduction = false;
            //string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            sub = AttenDtTmPkr.Value.ToString("yyyy");
            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,(em.BankAcountNo + ' IFSC : '+ em.GMIno ) as BankAcountNo,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.id)  as Rank,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.TotalSal as varchar(50)) Total_Earning,cast(sm.TotalDec as varchar(50)) Total_Deduction,cast(sm.NetPay as varchar(50)) Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");

            string strsql = "";
            nc();

            //311015
            vw_sql = "SELECT (cast(em.Code as nvarchar) +'-'+ cast(sm.Location_id as nvarchar)+'-'+cast(sm.desgid as nvarchar))link,Code as Sl,ID,"+
            "(SELECT DISTINCT (CASE WHEN FirstName != '' THEN FirstName + ' ' ELSE '' END) + (CASE WHEN MiddleName != '' THEN MiddleName + ' ' ELSE '' END) + (CASE WHEN LastName != '' THEN LastName + ' ' ELSE '' END) AS 'ename' FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS ename," +
            "(select (case when (gender='Male' or gender='M' or gender='' ) then 'Mr.' else (case when MaritalStatus='Married' then 'Mrs.' else 'Miss' end) end) title FROM tbl_Employee_Mast WHERE (ID = ea.ID)) title, "+
            "(select EmailId FROM tbl_Employee_Mast WHERE (ID = ea.ID))as email,Season, Month, LOcation_ID, Company_id, Desgid FROM tbl_Employee_Attend as ea";
            //------------------------------------------------------------------------------------------------------------------------

            strsql = " SELECT (cast(em.Code as nvarchar) +'-'+ cast(sm.Location_id as nvarchar)+'-'+cast(sm.desgid as nvarchar))link,em.Code as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,";
            strsql = strsql + "sm.Emp_Id as ID,(em.BankAcountNo + ' IFSC : '+ em.GMIno ) as BankAcountNo,";
            strsql = strsql + "(case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desgid) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desgid) end) as Rank,";
                //"case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Rank,";
            if (cWD_MOD == 0)
            {

                strsql = strsql + "sm.Basic as Salary, cast(sm.DaysPresent as nvarchar)+ (case when sm.OT!=0 then '  OT : '+ CAST((case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar(max)) else '' end) + cast((case when cast(sm.ed as int)!=0 then ' ED : '+ CAST((case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as nvarchar(max)) else '' end) + "+
                " (case when (select cast(PsWO as nvarchar) from Companywiseid_Relation where (Location_ID=sm.Location_id))='1' then ' Woff : '+ (select cast(woff as nvarchar) FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (ID=em.ID) and desgid=(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (ID=em.ID)) else sm.desig_id end)) else '' end) as nvarchar) as W_Day,";
                strsql = strsql + "(case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as O_T,sm.TotalDays as Tot_Day ,cast(sm.desgid as varchar) as desig_id,";
            }
            else if (cWD_MOD == 1)
            {

                strsql = strsql + "sm.Basic as Salary, (case when CAST(isNull((select CAST(cWD AS  numeric(18,2)) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0) AS  numeric(18,2))!=0 then cast(isNull((select CAST(cWD AS  numeric(18,2)) from tbl_employee_attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0)  as nvarchar) else cast(sm.DaysPresent as nvarchar) end) + (case when sm.OT!=0 then '  OT : '+ CAST((case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar(max)) else '' end) + cast((case when cast(sm.ed as int)!=0 then ' ED : '+ CAST((case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as nvarchar(max)) else '' end) + "+
             " (case when (select cast(PsWO as nvarchar) from Companywiseid_Relation where (Location_ID=sm.Location_id))='1' then ' Woff : '+ (select cast(woff as nvarchar) FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (ID=em.ID) and desgid=(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (ID=em.ID)) else sm.desig_id end)) else '' end) as nvarchar) as W_Day,";
                strsql = strsql + "(case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as O_T,(case when CAST(isNull((select CAST(cWD AS  numeric(18,2)) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID) and (Desgid =sm.desgid )),0) AS  numeric(18,2))!=0 then cast(isNull((select CAST(cWD AS  numeric(18,2)) from tbl_employee_attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID) and (Desgid =sm.desgid )),0)  as nvarchar) else cast(sm.DaysPresent as nvarchar) end) + sm.ot as Tot_Day ,cast(sm.desgid as varchar) as desig_id,";
            }
            strsql = strsql + "(case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as O_T,sm.TotalDays as Tot_Day ,cast(sm.desgid as varchar) as DesgId,";
            strsql = strsql + "cast(sm.TotalSal as  numeric(18,2)) Total_Earning,cast(sm.TotalDec as  numeric(18,2)) Total_Deduction,cast(sm.NetPay as  numeric(18,2)) Net_Pay ,";
            //--sd.EmpId,sd.SalId,sd.TableName,sd.Slno,sd.Amount, "
            strsql = strsql + "em.FathTitle,"+
             
                "(Case when "+ cnt_lv+ "=1 then (SELECT ('Op Bal : '+ cast(lv_pbal as nvarchar) + '  Earned : ' + cast(lv_earn as nvarchar) + '  Adjusted : ' + cast(lv_adj as nvarchar) + ' Cur Bal : '+cast((lv_pbal+lv_earn)-lv_adj as nvarchar) ) FROM  tbl_Employee_Attend WHERE (LOcation_ID = sm.Location_id ) and (id=sm.Emp_Id) and (month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "' and DesgId=(case when sm.desig_id='0' then em.DesgId else sm.desig_id end))) else '' end) as FathFN,"+

                "em.FathMN,em.FathLN,em.MothTitle,em.MothFN,em.MothMN,em.MothLN,em.HusTitle,em.HusFN,em.HusMN,em.HusLN,CAST(convert(datetime, em.DateOfBirth ,103) AS DATETIME) as 'DateOfBirth',em.MaritalStatus,em.Gender,em.JobType,em.PresentAddress,em.PermanentAddress,em.STD,em.Phone,em.Mobile,em.PANno,em.PassportNo,em.PF,em.PenssionNo,em.EDLI,em.ESIno,CAST(convert(datetime,em.DateOfJoining ,103) AS DATETIME) as 'DateOfJoining',em.DateOfRetirement, (CASE WHEN Bank_Name != '' THEN Bank_Name + (CASE WHEN GMIno != '' THEN ' (' + GMIno + ')' ELSE '' END) ELSE '' END) as GMIno,em.PenssionDate,em.EmailId,em.Location_id as 'salid',em.SecId,em.EmpWorkingStatus,em.Presentbuilding,em.Presentstreet,em.Presentareia,em.Presentcity,em.Presentpin,em.Presentstate,em.Presentcountry,em.Permanentbuilding,em.Permanentstreet,em.Permanentareia,em.Permanentcity,em.Permanentpin,em.Permanentstate,em.Permanentcountry,em.Religion,sm.Location_id,sm.Company_id,em.PF_Deduction,";
            strsql = strsql + "(select Cmpimage from Branch where GCODE=sm.Company_id and BRNCH_CODE=1) as 'CO_CODE',(select BRNCH_NAME from Branch where GCODE=sm.Company_id and BRNCH_CODE=1) as 'CO_NAME',(select BRNCH_ADD1 + ' ' + BRNCH_ADD2 from Branch where GCODE=sm.Company_id and BRNCH_CODE=1) as 'CO_ADD',(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID=sm.Location_id )as 'CO_ADD1',"; //cm.BRNCH_TELE1 as 'CO_ADD1',";
            
            strsql = strsql + "(select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=sm.Location_id )";
            strsql = strsql + " as 'LocationName',sm.Session as 'Session','" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "' as 'Misc',(case when ltrim(rtrim(em.dept))='' then '" + txtDept.Text.Trim() + "' else em.dept end) as 'Misc2',em.PassportNo as 'Misc3','" + cdoj + "'as 'slno' ";
            strsql = strsql + "FROM ";//--tbl_Employee_SalaryDet sd inner join 
            strsql = strsql + " tbl_Employee_Mast em ";//--on sd.EmpId=em.ID 
            strsql = strsql + " inner join tbl_Employee_SalaryMast sm on  cast(em.ID as varchar) COLLATE DATABASE_DEFAULT = cast(sm.Emp_Id as varchar) COLLATE DATABASE_DEFAULT ";
            //strsql = strsql + " inner join company cm on sm.Company_id=cm.CO_CODE ";
            //strsql = strsql + " inner join branch cm on cast(sm.Company_id as varchar) COLLATE DATABASE_DEFAULT= cast(cm.gcode as varchar) COLLATE DATABASE_DEFAULT ";
            strsql = strsql + " where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Company_id = '" + Company_id + "' ";
            //strsql = strsql + " order by sm.Emp_Id";

            
            string strsql1 = "";
            //strsql1 = "select * from ";
            //strsql1 = strsql1 + " (SELECT (select code from  tbl_Employee_Mast where ID=d.EmpId)as eid,d.EmpId as 'id',d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',isNull((SELECT Amount FROM tbl_Employee_SalaryGross where Empid=d.EmpId and salid=d.SalId and month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "' and location_id=d.Location_id),0) as 'TableName',d.Slno as 'slno',d.Amount as 'amount','0' as Designation_id,Location_id  ";
            //strsql1 = strsql1 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "'  ";
            //strsql1 = strsql1 + " and Company_id = '" + Company_id + "' and TableName ='tbl_Employee_ErnSalaryHead' ";
            //strsql1 = strsql1 + " union ";
            //strsql1 = strsql1 + " SELECT (select code from  tbl_Employee_Mast where ID=d.EmpId)as eid,d.EmpId as 'id',d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',isNull((SELECT Amount FROM tbl_Employee_SalaryGross where Empid=d.EmpId and salid=d.SalId and month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "' and location_id=d.Location_id and desgid=d.Designation_id),0) as 'TableName',d.Slno as 'slno',d.Amount as 'amount',cast (d.Designation_id as varchar) as Designation_id ,Location_id ";
            //strsql1 = strsql1 + " FROM tbl_Employee_SalaryDet_MultiDesignation d where Session='" + cmbYear.Text + "' and Month ='" + month + "'  ";
            //strsql1 = strsql1 + " and Company_id = '" + Company_id + "' and TableName ='tbl_Employee_ErnSalaryHead') main ";

            strsql1 = "select (cast(eid as nvarchar) +'-'+ cast(Location_id as nvarchar)+'-'+cast(Designation_id as nvarchar))link,* from (SELECT (select  top 1 code from  tbl_Employee_Mast where ID=d.EmpId)as eid,d.EmpId as 'id'," +
            "d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',"+
            "isNull((SELECT Amount FROM tbl_Employee_SalaryGross where Empid=d.EmpId and salid=d.SalId and month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "' and location_id=d.Location_id and desgid=d.Designation_id),0) as 'TableName',"+
            "d.Slno as 'slno',d.Amount as 'amount',cast (Designation_id  as varchar) as Designation_id,Location_id,(select NCompliance from tbl_Employee_Assign_SalStructure where Location_id = d.Location_id and sal_head=d.salid and p_type='E') ncomp  " +
            "FROM tbl_Employee_SalaryDetails d where Session='" + cmbYear.Text + "' and Month ='" + month + 
            "' and Company_id = '" + Company_id + "' and TableName ='tbl_Employee_ErnSalaryHead') main ";



            //strsql1 = strsql1 + " order by EmpId";

            string strsql2 = "";
            //strsql2 = "select * from ";
            //strsql2 = strsql2 + " (SELECT (select code from  tbl_Employee_Mast where ID=d.EmpId)as eid,d.EmpId as 'id',d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount','0' as Designation_id,Location_id  ";
            //strsql2 = strsql2 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            //strsql2 = strsql2 + " and Company_id ='" + Company_id + "' and TableName ='tbl_Employee_DeductionSalayHead'";
            //strsql2 = strsql2 + " union ";
            //strsql2 = strsql2 + " SELECT (select code from  tbl_Employee_Mast where ID=d.EmpId)as eid,d.EmpId as 'id',d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount',cast (d.Designation_id as varchar) as Designation_id,Location_id  ";
            //strsql2 = strsql2 + " FROM tbl_Employee_SalaryDet_MultiDesignation d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            //strsql2 = strsql2 + " and Company_id ='" + Company_id + "' and TableName ='tbl_Employee_DeductionSalayHead') main ";
            //strsql2 = strsql2 + " order by EmpId";

            strsql2 = "select (cast(eid as nvarchar) +'-'+ cast(Location_id as nvarchar)+'-'+cast(Designation_id as nvarchar))link,* from (SELECT (select  top 1 code from  tbl_Employee_Mast where ID=d.EmpId)as eid,d.EmpId as 'id',d.Location_id as 'salid'," +
            "(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',"+
            "d.Slno as 'slno',d.Amount as 'amount',cast (Designation_id  as varchar) as Designation_id,Location_id,(select NCompliance from tbl_Employee_Assign_SalStructure where Location_id = d.Location_id and sal_head=d.salid and p_type='D') ncomp FROM tbl_Employee_SalaryDetails d " +
            "where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Company_id ='" + Company_id + "' and TableName ='tbl_Employee_DeductionSalayHead') main ";

            //311015

            if (rdbCompany.Checked == true && rdbLocation.Checked == false)
            {
                vw_sql = vw_sql + " where Company_id='" + Company_id + "' and Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "'";
                tot_employ = clsDataAccess.RunQDTbl(strsql + " order by sm.Emp_Id,sm.desig_id");
                tot_employ1 = clsDataAccess.RunQDTbl(strsql1 + " where (ncomp=0) order by id,salid,Designation_id");
                tot_employ2 = clsDataAccess.RunQDTbl(strsql2 + " where (ncomp=0) order by id,salid,Designation_id");
                ds.Tables.Add(tot_employ);
                ds.Tables.Add(tot_employ1);
                ds.Tables.Add(tot_employ2);
                ds.Tables[0].TableName = "psM";
                ds.Tables[1].TableName = "psE";
                ds.Tables[2].TableName = "psD";
            }
            else if (rdbLocation.Checked == true && rdbLocation.Checked == true)
            {
                //String st = strsql1 + " AND d.Location_id = '" + Location_id + "' order by EmpId";
                //st = strsql + " AND sm.Location_id = '" + Location_id + "' order by sm.Emp_Id";
                //st = strsql2 + " AND d.Location_id = '" + Location_id + "' order by EmpId";
                vw_sql = vw_sql + " where Company_id='" + Company_id + "' and LOcation_ID='" + Location_id + "' and Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "'";
                DataTable tot_employ = clsDataAccess.RunQDTbl(strsql + " AND sm.Location_id = '" + Location_id + "' order by sm.Emp_Id,sm.desig_id");
                DataTable tot_employ1 = clsDataAccess.RunQDTbl(strsql1 + " where Location_id = '" + Location_id + "' and (ncomp=0) order by id,Designation_id,slno");
                DataTable tot_employ2 = clsDataAccess.RunQDTbl(strsql2 + " where Location_id = '" + Location_id + "' and (ncomp=0) order by id,Designation_id,slno");
                ds.Tables.Add(tot_employ);
                ds.Tables.Add(tot_employ1);
                ds.Tables.Add(tot_employ2);
                ds.Tables[0].TableName = "sss";
                ds.Tables[1].TableName = "ppp";
                ds.Tables[2].TableName = "ppq";
            }
            
            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,(em.BankAcountNo + ' IFSC : '+ em.GMIno ) as BankAcountNo,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.id)  as Rank,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.TotalSal as varchar(50)) Total_Earning,cast(sm.TotalDec as varchar(50)) Total_Deduction,cast(sm.NetPay as varchar(50)) Net_Pay ,sd.EmpId,sd.SalId,sd.TableName,sd.Slno,sd.Amount FROM tbl_Employee_SalaryDet sd inner join tbl_Employee_Mast em on sd.EmpId=em.ID inner join tbl_Employee_SalaryMast sm on  em.ID = sm.Emp_Id where sd.Session='" + cmbYear.Text + "' and sd.Month ='" + month + "' and sd.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' order by Slno");
            
            //041115 

            //tot_employ.Columns.Add("EarningHeads", typeof(string));


            //DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' order by Slno");
            //DataView dv = new DataView(salary_details);


            //if (tot_employ.Rows.Count > 1)
            //{


            //    for (int i = 0; i <= tot_employ.Rows.Count-1 ; i++)
            //    {
            //        dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' ";
            //        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + tot_employ.Rows[i]["TableName"] + " where SlNo ='" + tot_employ.Rows[i]["SalId"] + "'  ");
            //        tot_employ.Rows[i]["EarningHeads"] = Salary_Head;
            //        tot_employ.Rows[i]["sl"] = i + 1;
            //    }

            //    tot_employ.AcceptChanges();
            //}


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


            
            

        }

        private void Retrive_Data_rate()
        {
            Boolean flug_deduction = false;
            
            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            sub = AttenDtTmPkr.Value.ToString("yyyy");
            
            string strsql = "";
            

            //311015
            vw_sql = "SELECT Code as Sl,ID,(SELECT DISTINCT (CASE WHEN FirstName != '' THEN FirstName + ' ' ELSE '' END) + (CASE WHEN MiddleName != '' THEN MiddleName + ' ' ELSE '' END) + (CASE WHEN LastName != '' THEN LastName + ' ' ELSE '' END) AS 'ename' FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS ename," +
            "(select (case when (gender='Male' or gender='M' or gender='' ) then 'Mr.' else (case when MaritalStatus='Married' then 'Mrs.' else 'Miss' end) end) title FROM tbl_Employee_Mast WHERE (ID = ea.ID)) title, " +
            "(select EmailId FROM tbl_Employee_Mast WHERE (ID = ea.ID))as email," +
            "Season, Month, LOcation_ID, Company_id, Desgid FROM tbl_Employee_Attend as ea";

            strsql = " SELECT em.Code as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,";
            strsql = strsql + "sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,";
            strsql = strsql + "(case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (ID=em.ID))) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end) as Rank,";
            //"case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Rank,";
            if (cWD_MOD == 0)
            {

                strsql = strsql + "sm.Basic as Salary, cast(sm.DaysPresent as nvarchar)+ "+
               "(case when sm.OT!=0 then '  OT : '+ CAST((select cast(Proxy as nvarchar)  + (case when (proxy<>days_ot) then cast((case when Proxy>0 then  ' hrs' else '' end) as nvarchar)  else ' days' end) from tbl_Employee_Attend WHERE (Month = '"+AttenDtTmPkr.Value.ToString("M/yyyy")+"') AND (LOcation_ID = sm.Location_id) and (ID=sm.Emp_Id) and (Desgid =sm.desgid)) as nvarchar) else '' end) + "+
               "cast((case when cast(sm.ed as int)!=0 then ' ED : '+ CAST(sm.ed as nvarchar(max)) else '' end) as nvarchar) as W_Day,";
                strsql = strsql + "sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.desig_id as varchar) as desig_id,";
            }
            else if (cWD_MOD == 1)
            {

                strsql = strsql + "sm.Basic as Salary, (case when CAST(isNull((select CAST(cWD AS  numeric(18,2)) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0) AS  numeric(18,2))!=0 then cast(isNull((select CAST(cWD AS  numeric(18,2)) from tbl_employee_attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0)  as nvarchar) else cast(sm.DaysPresent as nvarchar) end) + "+
                "(case when sm.OT!=0 then '  OT : '+ CAST((select cast(Proxy as nvarchar)  + (case when (proxy<>days_ot) then cast((case when Proxy>0 then  ' hrs' else '' end) as nvarchar)  else ' days' end) from tbl_Employee_Attend WHERE (Month = '"+AttenDtTmPkr.Value.ToString("M/yyyy")+"') AND (LOcation_ID = sm.Location_id) and (ID=sm.Emp_Id) and (Desgid =sm.desgid)) as nvarchar) else '' end) + "+
                "cast((case when cast(sm.ed as int)!=0 then ' ED : '+ CAST(sm.ed as nvarchar(max)) else '' end) as nvarchar) as W_Day,";
                strsql = strsql + "sm.OT as O_T,(case when CAST(isNull((select CAST(cWD AS  numeric(18,2)) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0) AS  numeric(18,2))!=0 then cast(isNull((select CAST(cWD AS  numeric(18,2)) from tbl_employee_attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0)  as nvarchar) else cast(sm.DaysPresent as nvarchar) end) +sm.ot as Tot_Day ,cast(sm.desig_id as varchar) as desig_id,";
            }
            strsql = strsql + "sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.desig_id as varchar) as DesgId,";
            strsql = strsql + "cast(sm.TotalSal as  numeric(18,2)) Total_Earning,cast(sm.TotalDec as  numeric(18,2)) Total_Deduction,cast(sm.NetPay as  numeric(18,2)) Net_Pay ,";
            //--sd.EmpId,sd.SalId,sd.TableName,sd.Slno,sd.Amount, "
            strsql = strsql + "em.FathTitle," +

                "(Case when " + cnt_lv + "=1 then (SELECT ('Op Bal : '+ cast(lv_pbal as nvarchar) + '  Earned : ' + cast(lv_earn as nvarchar) + '  Adjusted : ' + cast(lv_adj as nvarchar) + ' Cur Bal : '+cast((lv_pbal+lv_earn)-lv_adj as nvarchar) ) FROM  tbl_Employee_Attend WHERE (LOcation_ID = sm.Location_id ) and (id=sm.Emp_Id) and (month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "' and DesgId=(case when sm.desig_id='0' then em.DesgId else sm.desig_id end))) else '' end) as FathFN," +

                "em.FathMN,em.FathLN,em.MothTitle,em.MothFN,em.MothMN,em.MothLN,em.HusTitle,em.HusFN,em.HusMN,em.HusLN,CAST(convert(datetime, em.DateOfBirth ,103) AS DATETIME) as 'DateOfBirth',em.MaritalStatus,em.Gender,em.JobType,em.PresentAddress,em.PermanentAddress,em.STD,em.Phone,em.Mobile,em.PANno,em.PassportNo,em.PF,em.PenssionNo,em.EDLI,em.ESIno,CAST(convert(datetime,em.DateOfJoining ,103) AS DATETIME) as 'DateOfJoining',em.DateOfRetirement,em.GMIno,em.PenssionDate,em.EmailId,em.Location_id as 'salid',em.SecId,em.EmpWorkingStatus,em.Presentbuilding,em.Presentstreet,em.Presentareia,em.Presentcity,em.Presentpin,em.Presentstate,em.Presentcountry,em.Permanentbuilding,em.Permanentstreet,em.Permanentareia,em.Permanentcity,em.Permanentpin,em.Permanentstate,em.Permanentcountry,em.Religion,sm.Location_id,sm.Company_id,em.PF_Deduction,";
            strsql = strsql + "(select Cmpimage from Branch where GCODE=sm.Company_id and BRNCH_CODE=1) as 'CO_CODE',(select BRNCH_NAME from Branch where GCODE=sm.Company_id and BRNCH_CODE=1) as 'CO_NAME',(select BRNCH_ADD1 + ' ' + BRNCH_ADD2 from Branch where GCODE=sm.Company_id and BRNCH_CODE=1) as 'CO_ADD',(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID=sm.Location_id )as 'CO_ADD1',"; //cm.BRNCH_TELE1 as 'CO_ADD1',";

            strsql = strsql + "(select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=sm.Location_id )";
            strsql = strsql + " as 'LocationName',sm.Session as 'Session',sm.Month as 'Misc',(case when ltrim(rtrim(em.dept))='' then '" + txtDept.Text.Trim() + "' else em.dept end) as 'Misc2',em.PassportNo as 'Misc3','" + cdoj + "'as 'slno' ";
            strsql = strsql + "FROM ";//--tbl_Employee_SalaryDet sd inner join 
            strsql = strsql + " tbl_Employee_Mast em ";//--on sd.EmpId=em.ID 
            strsql = strsql + " inner join tbl_Employee_SalaryMast sm on  cast(em.ID as varchar) COLLATE DATABASE_DEFAULT = cast(sm.Emp_Id as varchar) COLLATE DATABASE_DEFAULT ";
            
            strsql = strsql + " where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Company_id = '" + Company_id + "' ";
           
            //==============================================================
            string val_multi = "CAST((select top 1 (case when GRADE=1 then (select isNull(amount,0) FROM tbl_Employee_Lumpsum where LUMPID=(select top 1 C_DET from tbl_Employee_Assign_SalStructure where sal_struct in (" + lblStructureID.Text + ") and (Location_id=d.Location_id) and (SAL_HEAD=d.SalId) and (NCompliance=0)) and GRADE=d.Designation_id) else  (select isNull(amount,0) FROM tbl_Employee_Lumpsum where LUMPID=(select top 1 C_DET from tbl_Employee_Assign_SalStructure where sal_struct in (" + lblStructureID.Text + ") and (Location_id=d.Location_id) and (SAL_HEAD=d.SalId)) and GRADE=0) end) val FROM tbl_Employee_Lumpsum where LUMPID=1 ) as nvarchar(max))";
            string val = "CAST((select top 1 (case when GRADE=1 then (select isNull(amount,0) FROM tbl_Employee_Lumpsum where LUMPID=(select top 1 C_DET from tbl_Employee_Assign_SalStructure where sal_struct in (" + lblStructureID.Text + ") and (Location_id=d.Location_id) and (SAL_HEAD=d.SalId) and (NCompliance=0)) and GRADE=(select DesgId FROM tbl_Employee_Mast where ID=d.EmpId)) else  (select isNull(amount,0) FROM tbl_Employee_Lumpsum where LUMPID=(select top 1 C_DET from tbl_Employee_Assign_SalStructure where sal_struct in (" + lblStructureID.Text + ") and (Location_id=d.Location_id) and (SAL_HEAD=d.SalId) and (NCompliance=0)) and GRADE=0) end) val FROM tbl_Employee_Lumpsum where LUMPID=1 ) as nvarchar(max))";
            //===============================================================
            string strsql1 = "";
            strsql1 = "select * from ";
            strsql1 = strsql1 + " (SELECT (select code from  tbl_Employee_Mast where ID=d.EmpId)as eid,d.EmpId as 'id',d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',"+
            "cast((case when (select top 1 Proxy_day from tbl_Employee_Assign_SalStructure where sal_struct in (" + lblStructureID.Text + ") and (Location_id=d.Location_id) and (SAL_HEAD=d.SalId) and (NCompliance=0) and (P_TYPE='E'))=1 then (select top 1 OT from tbl_employers_contribution where lid=d.Location_id and coid=d.Company_id and session='" + cmbYear.Text + "' and month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "' and desgid=(case when isNull(d.Designation_id,0)=0 then (SELECT DesgId FROM tbl_Employee_Mast WHERE ID = d.EmpId)  else isNull(d.Designation_id,0) end))" +
            //"(case when (select top 1 Daily_wages from tbl_Employee_Assign_SalStructure where sal_struct in (" + lblStructureID.Text + ") and (Location_id=d.Location_id) and (SAL_HEAD=d.SalId))=2 then " + val + "+'/hrs' else (case when (select top 1 Daily_wages from tbl_Employee_Assign_SalStructure where sal_struct in (" + lblStructureID.Text + ") and (Location_id=d.Location_id) and (SAL_HEAD=d.SalId))=1 then "+val+"+'/day' else "+val+"+'/mon' end) end) "+
            " else Cast(isNull((SELECT Amount FROM tbl_Employee_SalaryGross where Empid=d.EmpId and salid=d.SalId and month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "' and location_id=d.Location_id),0)as nvarchar) end)  as nvarchar(max)) as 'TableName',d.Slno as 'slno',d.Amount as 'amount','0' as Designation_id,Location_id  ";
            strsql1 = strsql1 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "'  ";
            strsql1 = strsql1 + " and Company_id = '" + Company_id + "' and TableName ='tbl_Employee_ErnSalaryHead' ";
            strsql1 = strsql1 + " union ";
            strsql1 = strsql1 + " SELECT (select code from  tbl_Employee_Mast where ID=d.EmpId)as eid,d.EmpId as 'id',d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',"+
            "cast((case when (select top 1 Proxy_day from tbl_Employee_Assign_SalStructure where sal_struct in (" + lblStructureID.Text + ") and (Location_id=d.Location_id) and (SAL_HEAD=d.SalId) and (NCompliance=0) and (P_TYPE='E'))=1 then (select top 1 OT from tbl_employers_contribution where lid=d.Location_id and coid=d.Company_id and session='" + cmbYear.Text + "' and month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "' and desgid=d.Designation_id)" +
            //"(case when (select top 1 Daily_wages from tbl_Employee_Assign_SalStructure where sal_struct in (" + lblStructureID.Text + ") and (Location_id=d.Location_id) and (SAL_HEAD=d.SalId))=2 then " + val_multi + "+'/hrs' else (case when (select top 1 Daily_wages from tbl_Employee_Assign_SalStructure where sal_struct in (" + lblStructureID.Text + ") and (Location_id=d.Location_id) and (SAL_HEAD=d.SalId))=1 then " + val_multi + "+'/day' else " + val_multi + "+'/mon' end) end)"+
            " else Cast(isNull((SELECT Amount FROM tbl_Employee_SalaryGross where Empid=d.EmpId and salid=d.SalId and month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "' and location_id=d.Location_id and desgid=d.Designation_id),0)as nvarchar) end)  as nvarchar(max)) as 'TableName',d.Slno as 'slno',d.Amount as 'amount',cast (d.Designation_id as varchar) as Designation_id ,Location_id ";
            strsql1 = strsql1 + " FROM tbl_Employee_SalaryDet_MultiDesignation d where Session='" + cmbYear.Text + "' and Month ='" + month + "'  ";
            strsql1 = strsql1 + " and Company_id = '" + Company_id + "' and TableName ='tbl_Employee_ErnSalaryHead') main ";

            //strsql1 = strsql1 + " order by EmpId";

            string strsql2 = "";
            strsql2 = "select * from ";
            strsql2 = strsql2 + " (SELECT (select code from  tbl_Employee_Mast where ID=d.EmpId)as eid,d.EmpId as 'id',d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount','0' as Designation_id,Location_id  ";
            strsql2 = strsql2 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            strsql2 = strsql2 + " and Company_id ='" + Company_id + "' and TableName ='tbl_Employee_DeductionSalayHead'";
            strsql2 = strsql2 + " union ";
            strsql2 = strsql2 + " SELECT (select code from  tbl_Employee_Mast where ID=d.EmpId)as eid,d.EmpId as 'id',d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount',cast (d.Designation_id as varchar) as Designation_id,Location_id  ";
            strsql2 = strsql2 + " FROM tbl_Employee_SalaryDet_MultiDesignation d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            strsql2 = strsql2 + " and Company_id ='" + Company_id + "' and TableName ='tbl_Employee_DeductionSalayHead') main ";
            //strsql2 = strsql2 + " order by EmpId";

            //311015

            if (rdbCompany.Checked == true && rdbLocation.Checked == false)
            {
                vw_sql = vw_sql + " where Company_id='" + Company_id + "' and Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "'";
                tot_employ = clsDataAccess.RunQDTbl(strsql + " order by sm.Emp_Id,sm.desig_id");
                tot_employ1 = clsDataAccess.RunQDTbl(strsql1 + " order by id,salid,Designation_id");
                tot_employ2 = clsDataAccess.RunQDTbl(strsql2 + " order by id,salid,Designation_id");
                ds.Tables.Add(tot_employ);
                ds.Tables.Add(tot_employ1);
                ds.Tables.Add(tot_employ2);
                ds.Tables[0].TableName = "sss";
                ds.Tables[1].TableName = "ppp";
                ds.Tables[2].TableName = "ppq";
            }
            else if (rdbLocation.Checked == true )
            {
                //String st = strsql1 + " AND d.Location_id = '" + Location_id + "' order by EmpId";
                //st = strsql + " AND sm.Location_id = '" + Location_id + "' order by sm.Emp_Id";
                //st = strsql2 + " AND d.Location_id = '" + Location_id + "' order by EmpId";
                vw_sql = vw_sql + " where Company_id='" + Company_id + "' and LOcation_ID='" + Location_id + "' and Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "'";
                DataTable tot_employ = clsDataAccess.RunQDTbl(strsql + " AND sm.Location_id = '" + Location_id + "' order by sm.Emp_Id,sm.desig_id");
                DataTable tot_employ1 = clsDataAccess.RunQDTbl(strsql1 + " where Location_id = '" + Location_id + "' order by id,Designation_id,slno");
                DataTable tot_employ2 = clsDataAccess.RunQDTbl(strsql2 + " where Location_id = '" + Location_id + "' order by id,Designation_id,slno");
                ds.Tables.Add(tot_employ);
                ds.Tables.Add(tot_employ1);
                ds.Tables.Add(tot_employ2);
                ds.Tables[0].TableName = "sss";
                ds.Tables[1].TableName = "ppp";
                ds.Tables[2].TableName = "ppq";
            }          
        }

        private void CmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (CmbReport.SelectedIndex == 1)
            //{
            //    this.txtEmpContribut.Visible = true;
            //    this.label4.Visible = true;
            //}
            //else
            //{
            //    this.txtEmpContribut.Visible = false ;
            //    this.label4.Visible = false;
            //}

        }

        private void Retrive_DataESI()
        {

            //string Str_ErHead_basic = "";
            //DataTable ErHead_basic = clsDataAccess.RunQDTbl("select top 1  SalaryHead_Short from tbl_Employee_ErnSalaryHead");
            //Str_ErHead_basic = ErHead_basic.Rows[0][0].ToString();

            string Str_ESI = "";
            string Str_ESI_SLNO = "";

            DataTable data_ESI = clsDataAccess.RunQDTbl("select d.SalaryHead_Short,d.SLNO  from tbl_Employee_DeductionSalayHead d,tbl_Employee_Assign_SalStructure e,tbl_Employee_Link_SalaryStructure l where d.SlNo=e.SAL_HEAD and e.pt=1 and e.SAL_STRUCT=l.SalaryStructure_ID and Location_ID = '" + get_LocationID(cmbLoc.Text) + "'");

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

            DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,'" + cmbLoc.Text + "' as 'Site',cast(sm.TotalSal as varchar(50)) 'Gross Salary'  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbLoc.Text) + "' and em.ID = sm.Emp_Id");


            DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + get_LocationID(cmbLoc.Text) + "' and salid='" + Str_ESI_SLNO + "' order by Slno");
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
                    //tot_employ.Rows[dt_count - 1]["Employer ("+ txtEmpContribut.Text +"%)"] = "---------------";


                    if (Information.IsNumeric(tot_employ.Rows[dt_count][Str_ESI]) == false)
                        tot_employ.Rows[dt_count][Str_ESI] = 0;
                    //if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPFBasic"]) == false)
                    //    tot_employ.Rows[dt_count]["EPFBasic"] = 0;
                    //if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPS833"]) == false)
                    //    tot_employ.Rows[dt_count]["EPS833"] = 0;
                    //if (Information.IsNumeric(tot_employ.Rows[dt_count]["Employer ("+ txtEmpContribut.Text +"%)"]) == false)
                    //    tot_employ.Rows[dt_count]["Employer ("+ txtEmpContribut.Text +"%)"] = 0;

                    tot_employ.Rows[dt_count + 1][Str_ESI] = "========";
                    //tot_employ.Rows[dt_count + 1]["EPFBasic"] = "========";
                    //tot_employ.Rows[dt_count + 1]["EPS833"] = "========";
                    //tot_employ.Rows[dt_count + 1]["Employer ("+ txtEmpContribut.Text +"%)"] = "========";

                    tot_employ.Rows[i]["sl"] = i + 1;

                    //tot_employ.Rows[dt_count][Str_ESI] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Str_ESI]) + Convert.ToDouble(tot_employ.Rows[i][Str_ESI]));
                    //tot_employ.Rows[dt_count]["EPFBasic"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPFBasic"]) + Convert.ToDouble(tot_employ.Rows[i]["EPFBasic"]));
                    //tot_employ.Rows[dt_count]["EPS833"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPS833"]) + Convert.ToDouble(tot_employ.Rows[i]["EPS833"]));

                    //tot_employ.Rows[i]["Employer ("+ txtEmpContribut.Text +"%)"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[i]["Gross Salary"]) * Convert.ToDouble(txtEmpContribut.Text.Trim()) / 100));

                    //tot_employ.Rows[dt_count]["Employer ("+ txtEmpContribut.Text +"%)"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Employer ("+ txtEmpContribut.Text +"%)"]) + Convert.ToDouble(tot_employ.Rows[i]["Employer ("+ txtEmpContribut.Text +"%)"]));

                }

                tot_employ.Columns[Str_ESI].SetOrdinal(table_count - 1);
                //tot_employ.Columns["EPFBasic"].SetOrdinal(tot_employ.Columns.Count - 1);
                //tot_employ.Columns["EPS833"].SetOrdinal(tot_employ.Columns.Count - 1);

                tot_employ.Columns.Remove("ID");

                tot_employ.Columns[Str_ESI].SetOrdinal(4);
                tot_employ.Columns["Gross Salary"].SetOrdinal(3);
                //tot_employ.Columns["PF"].SetOrdinal(6);
                //tot_employ.Columns["EPS833"].SetOrdinal(7);
                //tot_employ.Columns["Employer ("+ txtEmpContribut.Text +"%)"].SetOrdinal(7);

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

            if (dt.Rows.Count > 1)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
                cmbLoc.Text = "";
            }
            if (dt.Rows.Count == 1)
            {
                cmbcompany.Text = Convert.ToString(dt.Rows[0][0]);
                cmbcompany.ReturnValue = Convert.ToString(dt.Rows[0][1]);
                cmbLoc.Text = "";
            }
            if (dt.Rows.Count == 0)
            {                
                cmbcompany.Text = "";
                cmbcompany.ReturnValue = "0";
                cmbLoc.Text = "";
                MessageBox.Show("No Company linked with Location");
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);

            //data_retrive_Company();
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
        }

        private void cmbsalstruc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Locations = Convert.ToString(get_LocationID(cmbLoc.Text));
            }
            catch
            {

            }
        }

        //ANURAG   
        private void rdbCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCompany.Checked == true)
            {
                DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
                if (dt_co.Rows.Count == 1)
                {
                                                                         //cmbcompany.Text = Convert.ToString(dt_co.Rows[0][0]);
                                                                         //Company_id = Convert.ToInt32(dt_co.Rows[0][1]);
                                                                         // cmbcompany.ReturnValue = Company_id.ToString();
                    cmbcompany.Enabled = false;
                    cmbLoc.Text = "";
                    cmbLoc.Enabled = false;

                    btnPreview.Enabled = true;
                    btnPrnt.Enabled = true;

                }
                else if (dt_co.Rows.Count > 1)
                {
                                                                             //cmbcompany.PopUp();
                    cmbcompany.Enabled = true;
                    cmbLoc.Text = "";
                    cmbLoc.Enabled = false;

                }
       
                
            }
            else if (rdbCompany.Checked == false)
            {
                DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
                if (dt_co.Rows.Count == 1)
                {
                    cmbcompany.Enabled = false;
                    cmbLoc.Enabled = true;
                }
                else if (dt_co.Rows.Count > 1)
                {
                    cmbcompany.Enabled = true;
                    cmbLoc.Enabled = true;
                }
            }
        }

        private void rdbLocation_CheckedChanged(object sender, EventArgs e)
        {
            //cmbLoc.Enabled = true;
            //cmbcompany.Enabled = true;

            if (rdbLocation.Checked == true)
            {
                btnWS.Visible = true;
            }
            else
            {
                btnWS.Visible = false;
            }
        }
        
        private void cmbLoc_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID," +
            "(select client_name from tbl_Employee_CliantMaster where Client_id= el.Cliant_ID) as Client,"+
            "el.Cliant_ID as ClientID  from tbl_Emp_Location el where "+
            "(Location_ID IN (select Location_ID from Companywiseid_Relation where (Company_ID='" + Company_id + 
            "'))) order by Location_Name");
                //dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL");
            if (dt.Rows.Count > 0)
            {
                cmbLoc.LookUpTable = dt;
                cmbLoc.ReturnIndex = 1;
            }
        }

        private void cmbLoc_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLoc.ReturnValue) == true)
                Location_id = Convert.ToInt32(cmbLoc.ReturnValue);


            lblStructureID.Text = clsDataAccess.ReturnValue("select top 1 ls.SalaryStructure_ID from tbl_Employee_Link_SalaryStructure ls where (Location_ID="+Location_id+") order by Link_ID desc");

            cmbLoc.Text = cmbLoc.Text + " - " + clsDataAccess.ReturnValue("select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l where l.Location_ID =" + Location_id);

            int data = Convert.ToInt32(clsDataAccess.GetresultS("select count(*) FROM tbl_Employee_SalaryMast where (Location_id='"+ Location_id +"') and (Company_id='"+Company_id+"') and (Month='"+AttenDtTmPkr.Value.ToString("MMMM")+"') and (Session='"+cmbYear.Text+"')"));

            if (data <= 0)
            {
                MessageBox.Show("No Salary Found for Location : "+cmbLoc.Text.Trim()+" this Month ","BRAVO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnPreview.Enabled = false;
                btnPrnt.Enabled = false;
            }
            else
            {
                btnPreview.Enabled = true;
                btnPrnt.Enabled = true;
            }
        }

        private void btnEmail_prev_Click(object sender, EventArgs e)
        {
            if (cmbcompany.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Please Select the Company Name", "BRAVO", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
            else
            {
                
                vw_sql = "SELECT ID,(SELECT DISTINCT (CASE WHEN FirstName != '' THEN FirstName + ' ' ELSE '' END) + (CASE WHEN MiddleName != '' THEN MiddleName + ' ' ELSE '' END) + (CASE WHEN LastName != '' THEN LastName + ' ' ELSE '' END) AS 'ename' FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS ename," +
          "(select (case when (gender='Male' or gender='M' or gender='' ) then 'Mr.' else (case when MaritalStatus='Married' then 'Mrs.' else 'Miss' end) end) title FROM tbl_Employee_Mast WHERE (ID = ea.ID)) title, " +
          "(select EmailId FROM tbl_Employee_Mast WHERE (ID = ea.ID))as email," +
          "Season, Month, LOcation_ID, Company_id, Desgid FROM tbl_Employee_Attend as ea ";

                if (rdbCompany.Checked == true && rdbLocation.Checked == false)
                {
                    vw_sql = vw_sql + " where Company_id='" + Company_id + "' and Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "' and (select EmailId FROM tbl_Employee_Mast WHERE (ID = ea.ID))!=''";
                   
                }
                else if (rdbLocation.Checked == true && rdbLocation.Checked == true)
                {

                    vw_sql = vw_sql + " where Company_id='" + Company_id + "' and LOcation_ID='" + Location_id + "' and Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "' and (select EmailId FROM tbl_Employee_Mast WHERE (ID = ea.ID))!=''";
                    
                }

                dt_emp = clsDataAccess.RunQDTbl(vw_sql);

                if (dt_emp.Rows.Count > 0)
                {
                   
                    //folderBrowserDialog1.InitialDirectory = "C:\\Users";
                    //openFileDialog1.IsFolderPicker = true;
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        path = folderBrowserDialog1.SelectedPath + "\\";
                        lbl_path.Text = folderBrowserDialog1.SelectedPath + "\\";

                        path = lbl_path.Text.Trim() + "\\Log" + System.DateTime.Now.Day + System.DateTime.Now.Month + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".txt";
                        lbl_load_msg.Text = "Please Wait..";
                        pnl_load.Visible = true;
                    }

                    MidasReport.Form1 opening = new MidasReport.Form1();
                    for (int ind = 0; ind < dt_emp.Rows.Count; ind++)
                    {
                        lbl_load_msg.Text = "Please Wait... Payslip Generating";
                        mail_payslip(dt_emp.Rows[ind]["ID"].ToString());
                        opening.payslip_save(ds, 0, ds, AttenDtTmPkr.Value.ToString("yyyy"), 0, lbl_path.Text + dt_emp.Rows[ind]["ID"].ToString() + "_" + AttenDtTmPkr.Value.ToString("MMM_yyyy") + ".pdf");
                        

                        ds.Tables.Clear();
                        ds.Dispose();
                    }

                    backgroundWorker1.RunWorkerAsync();
                    pnl_load.Visible = false;

                }
                else
                {

                    MessageBox.Show("No Record / Email id found", "Bravo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                //Printheader();
               
                //edpcom.CURRENT_COMPANY
               

                ds.Tables.Clear();
                ds.Dispose();
            }            
        }

        public void mail_payslip(string eid)
        {

            Boolean flug_deduction = false;
            //string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            sub = AttenDtTmPkr.Value.ToString("yyyy");
            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,(em.BankAcountNo + ' IFSC : '+ em.GMIno ) as BankAcountNo,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.id)  as Rank,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.TotalSal as varchar(50)) Total_Earning,cast(sm.TotalDec as varchar(50)) Total_Deduction,cast(sm.NetPay as varchar(50)) Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");

            string strsql = "";
         
 
            strsql = " SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,";
            strsql = strsql + "sm.Emp_Id as ID,(em.BankAcountNo + ' IFSC : '+ em.GMIno ) as BankAcountNo,";
            strsql = strsql + "case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Rank,";
            if (cWD_MOD == 0)
            {

                strsql = strsql + "sm.Basic as Salary, cast(sm.DaysPresent as nvarchar)+ (case when sm.OT!=0 then '  OT : '+ CAST( sm.OT as nvarchar(max)) else '' end) + cast((case when cast(sm.ed as int)!=0 then ' ED : '+ CAST(sm.ed as nvarchar(max)) else '' end) as nvarchar) as W_Day,";
                strsql = strsql + "sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.desig_id as varchar) as desig_id,";
            }
            else if (cWD_MOD == 1)
            {

                strsql = strsql + "sm.Basic as Salary, (case when CAST(isNull((select CAST(cWD AS  numeric(18,2)) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0) AS  numeric(18,2))!=0 then cast(isNull((select CAST(cWD AS  numeric(18,2)) from tbl_employee_attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0)  as nvarchar) else cast(sm.DaysPresent as nvarchar) end) + (case when sm.OT!=0 then '  OT : '+ CAST( sm.OT as nvarchar(max)) else '' end) + cast((case when cast(sm.ed as int)!=0 then ' ED : '+ CAST(sm.ed as nvarchar(max)) else '' end) as nvarchar) as W_Day,";
                strsql = strsql + "sm.OT as O_T,(case when CAST(isNull((select CAST(cWD AS  numeric(18,2)) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0) AS  numeric(18,2))!=0 then cast(isNull((select CAST(cWD AS  numeric(18,2)) from tbl_employee_attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID = sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0)  as nvarchar) else cast(sm.DaysPresent as nvarchar) end) +sm.ot as Tot_Day ,cast(sm.desig_id as varchar) as desig_id,";
            }
            strsql = strsql + "sm.OT as O_T,sm.TotalDays as Tot_Day ,cast(sm.desig_id as varchar) as desig_id,";
            strsql = strsql + "cast(sm.TotalSal as  numeric(18,2)) Total_Earning,cast(sm.TotalDec as  numeric(18,2)) Total_Deduction,cast(sm.NetPay as  numeric(18,2)) Net_Pay ,";
            //--sd.EmpId,sd.SalId,sd.TableName,sd.Slno,sd.Amount, "
            strsql = strsql + "em.FathTitle,(Case when " + cnt_lv + "=1 then (SELECT ('Op Bal : '+ cast(lv_pbal as nvarchar) + '  Earned : ' + cast(lv_earn as nvarchar) + '  Adjusted : ' + cast(lv_adj as nvarchar) + ' Cur Bal : '+cast((lv_pbal+lv_earn)-lv_adj as nvarchar) ) FROM  tbl_Employee_Attend WHERE (LOcation_ID = sm.Location_id ) and (id=sm.Emp_Id) and (month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "' and DesgId=(case when sm.desig_id='0' then em.DesgId else sm.desig_id end))) else '' end) as FathFN,em.FathMN,em.FathLN,em.MothTitle,em.MothFN,em.MothMN,em.MothLN,em.HusTitle,em.HusFN,em.HusMN,em.HusLN,CAST(convert(datetime, em.DateOfBirth ,103) AS DATETIME) as 'DateOfBirth',em.MaritalStatus,em.Gender,em.DesgId,em.JobType,em.PresentAddress,em.PermanentAddress,em.STD,em.Phone,em.Mobile,em.PANno,em.PassportNo,em.PF,em.PenssionNo,em.EDLI,em.ESIno,CAST(convert(datetime,em.DateOfJoining ,103) AS DATETIME) as 'DateOfJoining',em.DateOfRetirement,em.GMIno,em.PenssionDate,em.EmailId,em.Location_id as 'salid',em.SecId,em.EmpWorkingStatus,em.Presentbuilding,em.Presentstreet,em.Presentareia,em.Presentcity,em.Presentpin,em.Presentstate,em.Presentcountry,em.Permanentbuilding,em.Permanentstreet,em.Permanentareia,em.Permanentcity,em.Permanentpin,em.Permanentstate,em.Permanentcountry,em.Religion,em.Location_id,em.Company_id,em.PF_Deduction,";
            strsql = strsql + " cm.Cmpimage as 'CO_CODE',cm.BRNCH_NAME as 'CO_NAME',cm.BRNCH_ADD1 + ' ' + cm.BRNCH_ADD2 as 'CO_ADD',(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID=sm.Location_id )as 'CO_ADD1',"; //cm.BRNCH_TELE1 as 'CO_ADD1',";
            
            strsql = strsql + "(select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=sm.Location_id )";
            strsql = strsql + " as 'LocationName',sm.Session as 'Session',sm.Month as 'Misc',(case when ltrim(rtrim(em.dept))='' then '" + txtDept.Text.Trim() + "' else em.dept end) as 'Misc2',em.PassportNo as 'Misc3','"+cdoj+"'as 'slno' ";
            strsql = strsql + "FROM ";//--tbl_Employee_SalaryDet sd inner join 
            strsql = strsql + " tbl_Employee_Mast em ";//--on sd.EmpId=em.ID 
            strsql = strsql + " inner join tbl_Employee_SalaryMast sm on  cast(em.ID as varchar) COLLATE DATABASE_DEFAULT = cast(sm.Emp_Id as varchar) COLLATE DATABASE_DEFAULT ";
            //strsql = strsql + " inner join company cm on sm.Company_id=cm.CO_CODE ";
            strsql = strsql + " inner join branch cm on cast(sm.Company_id as varchar) COLLATE DATABASE_DEFAULT= cast(cm.gcode as varchar) COLLATE DATABASE_DEFAULT ";
            strsql = strsql + " where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Company_id = '" + Company_id + "' ";
           
            string strsql1 = "";
            strsql1 = "select * from ";
            strsql1 = strsql1 + " (SELECT d.EmpId as 'id',d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',isNull((SELECT Amount FROM tbl_Employee_SalaryGross where Empid=d.EmpId and salid=d.SalId and month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "' and location_id=d.Location_id),0) as 'TableName',d.Slno as 'slno',d.Amount as 'amount','0' as Designation_id,Location_id  ";
            strsql1 = strsql1 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "'  ";
            strsql1 = strsql1 + " and Company_id = '" + Company_id + "' and TableName ='tbl_Employee_ErnSalaryHead' ";
            strsql1 = strsql1 + " union ";
            strsql1 = strsql1 + " SELECT d.EmpId as 'id',d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_ErnSalaryHead where SlNo=d.SalId  ) as 'EarningHead',isNull((SELECT Amount FROM tbl_Employee_SalaryGross where Empid=d.EmpId and salid=d.SalId and month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "' and location_id=d.Location_id and desgid=d.Designation_id),0) as 'TableName',d.Slno as 'slno',d.Amount as 'amount',cast (d.Designation_id as varchar) as Designation_id ,Location_id ";
            strsql1 = strsql1 + " FROM tbl_Employee_SalaryDet_MultiDesignation d where Session='" + cmbYear.Text + "' and Month ='" + month + "'  ";
            strsql1 = strsql1 + " and Company_id = '" + Company_id + "' and TableName ='tbl_Employee_ErnSalaryHead') main ";

            //strsql1 = strsql1 + " order by EmpId";

            string strsql2 = "";
            strsql2 = "select * from ";
            strsql2 = strsql2 + " (SELECT d.EmpId as 'id',d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount','0' as Designation_id,Location_id  ";
            strsql2 = strsql2 + " FROM tbl_Employee_SalaryDet d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            strsql2 = strsql2 + " and Company_id ='" + Company_id + "' and TableName ='tbl_Employee_DeductionSalayHead'";
            strsql2 = strsql2 + " union ";
            strsql2 = strsql2 + " SELECT d.EmpId as 'id',d.Location_id as 'salid',(select salaryhead_full from tbl_Employee_DeductionSalayHead where SlNo=d.SalId  ) as 'DeductHead',d.TableName as 'TableName',d.Slno as 'slno',d.Amount as 'amount',cast (d.Designation_id as varchar) as Designation_id,Location_id  ";
            strsql2 = strsql2 + " FROM tbl_Employee_SalaryDet_MultiDesignation d where Session='" + cmbYear.Text + "' and Month ='" + month + "' ";
            strsql2 = strsql2 + " and Company_id ='" + Company_id + "' and TableName ='tbl_Employee_DeductionSalayHead') main ";
            //strsql2 = strsql2 + " order by EmpId";

            //311015

            if (rdbCompany.Checked == true && rdbLocation.Checked == false)
            {
               
                tot_employ = clsDataAccess.RunQDTbl(strsql + " and ID='"+ eid +"' order by sm.Emp_Id,sm.desig_id");
                tot_employ1 = clsDataAccess.RunQDTbl(strsql1 + " where ID='" + eid + "' order by id,salid,Designation_id");
                tot_employ2 = clsDataAccess.RunQDTbl(strsql2 + " where ID='" + eid + "' order by id,salid,Designation_id");
                ds.Tables.Add(tot_employ);
                ds.Tables.Add(tot_employ1);
                ds.Tables.Add(tot_employ2);
                ds.Tables[0].TableName = "sss";
                ds.Tables[1].TableName = "ppp";
                ds.Tables[2].TableName = "ppq";
            }
            else if (rdbLocation.Checked == true && rdbLocation.Checked == true)
            {
                DataTable tot_employ = clsDataAccess.RunQDTbl(strsql + " and ID='" + eid + "' AND sm.Location_id = '" + Location_id + "' order by sm.Emp_Id,sm.desig_id");
                DataTable tot_employ1 = clsDataAccess.RunQDTbl(strsql1 + " where Location_id = '" + Location_id + "' and ID='" + eid + "' order by id,Designation_id,slno");
                DataTable tot_employ2 = clsDataAccess.RunQDTbl(strsql2 + " where Location_id = '" + Location_id + "' and ID='" + eid + "' order by id,Designation_id,slno");
                ds.Tables.Add(tot_employ);
                ds.Tables.Add(tot_employ1);
                ds.Tables.Add(tot_employ2);
                ds.Tables[0].TableName = "sss";
                ds.Tables[1].TableName = "ppp";
                ds.Tables[2].TableName = "ppq";
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int ind = 0; ind < dt_emp.Rows.Count; ind++)
            {

                // simulateHeavyWork();
                backgroundWorker1.ReportProgress(ind);
            }
        }
        int ind;
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this is updated from dowork..its where GUI Components are updated
            // receives updates after 100 ms
            string strEmpName = "";

            if (!File.Exists(path))
            {
                //File.Create(path);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                using (var tw = new StreamWriter(fs))
                {
                    tw.WriteLine("#Company: " + cmbcompany.Text.Trim());
                    tw.WriteLine("#Version: " +edpcom.PBUILD_DATE.ToString("dd/MM/yyyy"));
                    tw.WriteLine("#Date: " + System.DateTime.Now);
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                //File.Delete(path);
                //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                //using (var tw = new StreamWriter(fs))
                //{
                //    tw.WriteLine("#Company: " + CompanyName.Trim());
                //    tw.WriteLine("#Version: " + cnn.PBUILD_DATE.ToString("dd/MM/yyyy"));
                //    tw.WriteLine("#Date: " + System.DateTime.Now);
                //    tw.Close();
                //}
            }
            string ecode = "",title="",ename="",noMail="1",off_email="",off_email_1="",snd="0";

            //progressBar1.Value = e.ProgressPercentage;
            ind = (Convert.ToInt32(e.ProgressPercentage.ToString())); //+ " %";
            try
            {
                ecode = dt_emp.Rows[ind]["ID"].ToString();
                title = dt_emp.Rows[ind]["Title"].ToString();
                ename = dt_emp.Rows[ind]["ename"].ToString();
                //noMail = dataGridView1.Rows[ind].Cells["col_nomail"].Value.ToString();
                off_email = dt_emp.Rows[ind]["email"].ToString(); 
                off_email_1 = "bibhas.ch@gmail.com";
                
                if (noMail == "1" & snd == "0")
                {
                    if (TxtEmail.Text.Trim() == "" || off_email.Trim() == "")
                    {
                        MessageBox.Show("Check User name / To ", "Bravo");
                        return;

                    }
                    // using (MailMessage mm = new MailMessage("kudostechindia@gmail.com", "bibhas.ch@gmail.com"))
                    using (MailMessage mm = new MailMessage(TxtEmail.Text, off_email.Trim()))
                    {

                        mm.From = new MailAddress(TxtEmail.Text, "HR<"+TxtEmail.Text+">");
                        mm.Subject = "Pay Slip " + AttenDtTmPkr.Value.ToString("MMMM-yyyy");//System.DateTime.Now.ToString("MMM-yyyy");
                        mm.ReplyTo = new System.Net.Mail.MailAddress(TxtEmail.Text);
                       

                        mm.IsBodyHtml = true;

                        mm.Body = "Dear " + title + " " + ename + "," + Environment.NewLine + "\n<br /><br />Please find the attached payslip below." + Environment.NewLine + " \n<br /><b> Thanks & Regards,<br/>"+txtSignature.Text + Environment.NewLine + "\n<br /><br /><html><div style='font-size:8px; font-family:Arial;'> This is a system generated mail</div></html>";

                        string fileName = Path.GetFileName(lbl_path.Text + dt_emp.Rows[ind]["ID"].ToString() + "_" + AttenDtTmPkr.Value.ToString("MMM_yyyy") + ".pdf");
                        if (File.Exists(lbl_path.Text + dt_emp.Rows[ind]["ID"].ToString() + "_" + AttenDtTmPkr.Value.ToString("MMM_yyyy") + ".pdf"))
                        {

                            mm.Attachments.Add(new Attachment(lbl_path.Text + dt_emp.Rows[ind]["ID"].ToString() + "_" + AttenDtTmPkr.Value.ToString("MMM_yyyy") + ".pdf"));
                        }
                                            
                       
                      
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = txthost.Text.Trim();
                        if (chk_enableSsl.Checked == true)
                            smtp.EnableSsl = true;
                        else
                            smtp.EnableSsl = false;

                        NetworkCredential NetworkCred = new NetworkCredential(TxtEmail.Text.Trim(), txtPassword.Text.Trim());
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = Convert.ToInt32(txtPort.Text);


                        try
                        {
                            smtp.Send(mm);
                            lbl_load_msg.Text = ("Email sent." + ecode);
                            lbl_load_msg.Text = "Please Wait... " + lbl_load_msg.Text;
                            sq1 = ("INSERT INTO mail_log(mdate, uid, mto, cc, bcc, subject, month)VALUES (GETDATE(),'" + edpcom.UserDesc + "','" + off_email + "','','','Payslip for the month of " + AttenDtTmPkr.Value.ToString("MMM-yyyy") + "','" + System.DateTime.Now.ToString("MMM-yyyy") + "')");
                            bool rs = clsDataAccess.RunQry(sq1);
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                            {

                                file.WriteLine("Mail sent for Employee ID: " + ecode + " and Employee Name: " + strEmpName + " :: " +
                         "Mailed To : " + off_email + " :: Month : " + AttenDtTmPkr.Value.ToString("MMM-yyyy"));
                            }
                        }
                        catch (Exception ex)
                        {
                            lbl_load_msg.Text = ("Email failed.." + ecode);
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                            {

                                file.WriteLine("Mail not sent for Employee ID: " +  ecode + " and Employee Name: " + strEmpName + " :: " +
                         "Mailed To : " + off_email + " :: Month : " + AttenDtTmPkr.Value.ToString("MMM-yyyy"));
                            }
                        }
                    }
                }

            }
            catch { }




        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Called when the heavy operation in bg is over. can also accept GUI components
            display("Mail Send Completed...");

        }

        //simulate complex calculations
        private void simulateHeavyWork()
        {
            Thread.Sleep(100);
        }
        //for messages
        private void display(string text)
        {
            lbl_load_msg.Text = text;
            MessageBox.Show("Mail send completed.. Check log file for details : " + path, "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnWS_Click(object sender, EventArgs e)
        {
            string sql = "", sql_ded = "", month = AttenDtTmPkr.Value.ToString("MMMM"), MMYY = AttenDtTmPkr.Value.ToString("MMMM,yyyy");


            DataTable dtExcl = new DataTable();
            DataTable dtDed = new DataTable();

            dtDed = clsDataAccess.RunQDTbl("select distinct SalId,(select salaryhead_short from tbl_Employee_DeductionSalayHead where SlNo=d.SalId)Ded FROM tbl_Employee_SalaryDetails d where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Company_id ='" + Company_id + "' and Location_id="+Location_id+" and TableName ='tbl_Employee_DeductionSalayHead' and (select NCompliance from tbl_Employee_Assign_SalStructure where Location_id = d.Location_id and sal_head=d.salid and p_type='D')=0");

            if (dtDed.Rows.Count > 0)
            {
                for (int idx = 0; idx < dtDed.Rows.Count; idx++)
                {
                    if (sql_ded.Trim() == "")
                    {
                        sql_ded = "(select  d.Amount FROM tbl_Employee_SalaryDetails d where EmpId=sm.Emp_Id and (Designation_id=sm.desgid) and SalId='" + dtDed.Rows[idx]["SalId"].ToString() + "' and Session='" + cmbYear.Text + "' and Month ='" + month + "' and Company_id ='" + Company_id + "' and Location_id='" + Location_id + "' and TableName ='tbl_Employee_DeductionSalayHead')as '" + dtDed.Rows[idx]["ded"].ToString() + "'";

                    }
                    else
                    {
                        sql_ded = sql_ded + ",(select  d.Amount FROM tbl_Employee_SalaryDetails d where EmpId=sm.Emp_Id and (Designation_id=sm.desgid) and SalId='" + dtDed.Rows[idx]["SalId"].ToString() + "' and Session='" + cmbYear.Text + "' and Month ='" + month + "' and Company_id ='" + Company_id + "' and Location_id='" + Location_id + "' and TableName ='tbl_Employee_DeductionSalayHead')as '" + dtDed.Rows[idx]["ded"].ToString() + "'";

                    }

                }
                sql_ded = sql_ded+",";
            }
            else
            {
                //sql_ded = "'' as ''";
            }
            sql = "SELECT (select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID=sm.Location_id )as 'Name and Address of Contractor'," +
"(select (SELECT Client_ADD1 FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID=sm.Location_id ) as 'Address'," +

/*"--(cast(em.Code as nvarchar) +'-'+ cast(sm.Location_id as nvarchar)+'-'+cast(sm.desgid as nvarchar))link, em.Code as sl,"*/
 "(case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desgid) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desgid) end)+ ' at' +(select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=sm.Location_id ) as 'Nature and Location of Work'," +
 "((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS 'Name',sm.Emp_Id as ID," +
 "((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN em.FathMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN em.FathLN+ ' ' ELSE '' END)) as 'Father''s / Husband''s name of the workman'," +
 " '"+MMYY+"' as 'For the Week / Fortnight / Month ending'," +
 "cast(sm.DaysPresent as nvarchar) as 'No. of days worked','---' as 'No. of units worked in case of piece-rate workers'," +
 "cast(cast((select distinct amount FROM tbl_Employee_SalaryDetails d where (empid=sm.emp_id) and (Session=sm.Session) and (Month =sm.Month) and (Company_id = sm.Company_id) and (Location_id=sm.Location_id) and (TableName ='tbl_Employee_ErnSalaryHead') and (salid=1) and (Designation_id=sm.desgid)) as numeric(18,2))/cast(sm.DaysPresent as numeric(18,2)) as numeric(18,2)) 'Rate of daily wages /piece - rate'," +
 "'---' as 'Amount of overtime wages'," +
 "cast(sm.TotalSal as  numeric(18,2)) 'Gross wages payable'," + sql_ded + "cast(sm.TotalDec as  numeric(18,2)) 'Deductions, if any',cast(sm.NetPay as  numeric(18,2)) 'Net amount of wages paid' ," +
 "em.PassportNo as 'UAN',em.ESIno as 'ESIC'" +

 //--(select BRNCH_NAME from Branch where GCODE=sm.Company_id and BRNCH_CODE=1) as 'CO_NAME',
                //--(select BRNCH_ADD1 + ' ' + BRNCH_ADD2 from Branch where GCODE=sm.Company_id and BRNCH_CODE=1) as 'CO_ADD',

 "FROM  tbl_Employee_Mast em  inner join tbl_Employee_SalaryMast sm on  cast(em.ID as varchar) COLLATE DATABASE_DEFAULT = cast(sm.Emp_Id as varchar) COLLATE DATABASE_DEFAULT " +
 "where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Company_id = '" + Company_id + "' AND sm.Location_id = '" + Location_id + "' and (em.Company_id='"+Company_id+"')  order by sm.Emp_Id,sm.desig_id";


            dtExcl = clsDataAccess.RunQDTbl(sql);


            if (dtExcl.Rows.Count > 0)
            {

                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                int icol = 1, irow = 1,Row=0,Col=0;
                Excel.Range range;


                
                for (int irw=0;irw<dtExcl.Rows.Count;irw++)
                {
                    Col = icol;
                    Row = irow;


                    excel.Cells[irow, icol] = cmbcompany.Text + Environment.NewLine +
                        clsDataAccess.ReturnValue("(select BRNCH_ADD1 + ' ' + BRNCH_ADD2 from Branch where GCODE="+cmbcompany.ReturnValue+" and BRNCH_CODE=1)");
                        //"FORM XIX" + Environment.NewLine + "[See Rule 78 (1) (b)]";
                    range = worksheet.get_Range(worksheet.Cells[irow, icol], worksheet.Cells[irow, icol+1]);
                    range.Font.Bold = true;
                    range.Merge(true);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    //range.Columns.AutoFit();
                    range.RowHeight=55;

                    irow++;
                    excel.Cells[irow, icol] = "WAGE SLIP";
                    range = worksheet.get_Range(worksheet.Cells[irow, icol], worksheet.Cells[irow, icol+1]);
                    range.Font.Bold = true;
                    range.Merge(true);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    range.Columns.AutoFit();
                    range.Rows.AutoFit();
                    irow = irow + 1;
                    icol = 1;
                    for (int icl=0;icl<dtExcl.Columns.Count;icl++)
                    {

                        if (dtExcl.Columns[icl].ColumnName == "UAN" || dtExcl.Columns[icl].ColumnName == "ESIC")
                        { if (dtExcl.Columns[icl].ColumnName == "UAN" )
                            {
                                excel.Cells[irow, 1] = "";
                                excel.Cells[irow, 2] = "";

                                excel.Cells[irow+1, 1] = "";
                                excel.Cells[irow+1, 2] = "";

                                excel.Cells[irow+1, 1] = "";
                                excel.Cells[irow+1, 2] = "";



                               irow= irow + 3;
                            }
                            excel.Cells[irow, 1] = dtExcl.Columns[icl].ColumnName.Replace("(R&E)","");
                            // icol++;
                            excel.Cells[irow, 2] = "'" + dtExcl.Rows[irw][icl].ToString();
                            //icol++;
                        }
                        else
                        {
                            excel.Cells[irow, 1] = dtExcl.Columns[icl].ColumnName.Replace("(R&E)", "");
                           
                            excel.Cells[irow, 2] = dtExcl.Rows[irw][icl].ToString();
                           
                        }
                        irow++;
                     }

                    excel.Cells[irow, 1] = "";
                    excel.Cells[irow, 2] = "";

                    excel.Cells[irow + 1, 1] = "";
                    excel.Cells[irow + 1, 2] = "";

                    excel.Cells[irow + 1, 1] = "This is a computer generated document, no stamp or sign required";
                    range = worksheet.get_Range(worksheet.Cells[irow + 1, 1], worksheet.Cells[irow + 1, 2]);
                    range.Font.Size = 8;
                    range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    range.Merge(true);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    //excel.Cells[irow + 1, 2] = "";



                    irow = irow + 3;


                    range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[irow, 2]);
                    range.BorderAround(Excel.XlLineStyle.xlContinuous,
        Excel.XlBorderWeight.xlThin,
        Excel.XlColorIndex.xlColorIndexNone,
        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
                    Excel.Borders borders = range.Borders;
                    //Set the thick lines style.
                    borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    borders.Weight = 2d;
                    //range.WrapText = true;
                    range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    range.Columns.AutoFit();
                    irow++;
                }

                MessageBox.Show("Export Complete", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }




    }

}