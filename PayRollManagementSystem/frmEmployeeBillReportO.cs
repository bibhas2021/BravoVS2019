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
using System.IO;
//using System.IO.File;
using FirstTimeNeed;
using System.Net.Mail;
using System.Threading;
using System.Net;

namespace PayRollManagementSystem
{
    public partial class frmEmployeeBillReportO : MstFrmDialog
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        public string Item_Code = "", Tentry_code = "",vSes="";
        string tc = ""; string path = "";
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataSet ds_img = new DataSet();
        DataTable dt = new DataTable();
        DataTable dtMainDesgDt = new DataTable();
        string Frm_Type = "";
        int Head_Cou = 0, SacGst=0;
        string Locations = "";
        public int Company_id = 0, Location_id = 0, Client_id = 0, vl = 0, email=0;

        string current_company;
        string address = "";
        string address1 = "";
        string pan;
        string DURATION;
        string sq1;

        ArrayList arritem = new ArrayList();
        string arrayItem = "";

        ArrayList LocList = new ArrayList();
        string strLocList = "";

        //Hashtable getcode = new Hashtable();
        Hashtable getcode_Group = new Hashtable();
        Hashtable getcode_item = new Hashtable();
        Hashtable getLoc_item = new Hashtable();


        string company = "", Agentadd = "", Agentadd1 = "", phone = "", Area = "", BillDate = "", User_Voucher = "";
        string challan = "", challandt = "", AmtWord = "", narrsn = "";
        string conName = "", ConAdd1 = "", Conadd2 = "";
        string amtvalue = "";
        string lorry_no = "", locname = "", modtranport = "", prtyname = "", prtyadd1 = "", prtyadd2 = "", prtycity = "", prtyctypin = "", prtytele1 = "", prtytele2 = "", prtyfax = "", prtyemail = "", prtyeccno = "", prtytin = "";
        string partycodeeee = "";
        string tentry = "", FinalAmount = "", Refvoucher = "";

        string termsconditions = "", ODetails = "",onote="";
        string setting_type = "";
        string IsST = "F";
        string isScAdd = "False";
        string startPath = "",refno="",pono="";
        string SelectedACNo = "";
        string strBillFormatNo = "";
        public string client_id = "";
        Boolean boolSingleDesignationBillingPermission = false;
        Boolean boolAdPrintingPermission = false;
        bool boolsign = false;
        string hsn, sper, samt, cper, camt,txnAmt, tval, ptype;

        public frmEmployeeBillReportO(string type)
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
            try
            {
                SacGst = Convert.ToInt32(clsDataAccess.ReturnValue("select SacGst from CompanyLimiter"));
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
                    btnEmail.Visible = true;
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
                    btnEmail.Visible = false;
                    //groupBox1.Visible = false;
                }


            }
            catch { }
            string filePath = "";
            filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
            string lineForConfigSetting;
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    if (file.ReadLine() != null)
                    {
                        int chk_str = 0;
                        while ((lineForConfigSetting = file.ReadLine()) != null)
                        {
                            string[] StrSTAR = lineForConfigSetting.Trim().Split('*');
                            if (StrSTAR.Length == 2)
                            {
                             
                                if (StrSTAR[0].Trim() == "")
                                    continue;
                            }

                            string[] StrLine = lineForConfigSetting.Trim().Split('[');
                            if (StrLine.Length == 2)
                            {
                                string str = lineForConfigSetting.Substring(1, lineForConfigSetting.Length - 2);
                                if (str == "BILL_PRINTING_OPTIONS")
                                    chk_str = 1;


                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                if (StrLine_WACC[0] == "PRINT_BILLS_FOR_MULTIPLE_LOCATION_IN_SINGLE_CLICK")
                                    boolSingleDesignationBillingPermission = true;
                                chk_str = 0;
                            }
                        }
                    }

                }
                catch
                { }
            }
            if (!boolSingleDesignationBillingPermission)
                comboBox1.Items.Remove("Multi Location Selection");
            
            strBillFormatNo = BillFormatNo();


            string bill_format = strBillFormatNo;


            if (bill_format == "1") // Bill FOrmat
            {
                cmbBillType.SelectedIndex = 0;
            }
            else if (bill_format == "2")
            {
                cmbBillType.SelectedIndex = 1;
            }
            else if (bill_format == "3")
            {
                cmbBillType.SelectedIndex = 2;
            }
            else if (bill_format == "4")
            {
                cmbBillType.SelectedIndex = 3;
            }
            else if (bill_format == "5") // new format - with reverse charges
            {
                //cmbBillType.SelectedIndex = 4;
            }
            else if (bill_format == "6") // new format - Terms and condition CQ/DD/PO
            {
                cmbBillType.SelectedIndex = 4;
            }
            else if (bill_format == "7") // new format - Terms and condition CQ/DD/PO
            {
                cmbBillType.SelectedIndex = 5;
            }





            bool result;
            edpcon = new EDPConnection();

            switch (strBillFormatNo)
            {
                case "1":
                    //chkBlankHead.Visible = false; 
                    chkPrevBal.Visible = false; chkHide_BillDetails.Visible = false; chkHide_BillDetails.Checked = false; rdbDuplicate.Visible = false; rdbOrg.Visible = false; rdbTriple.Visible = false; rdbOrg.Checked = true;
                    break;
                case "2":
                    //chkBlankHead.Visible = false; 
                    chkPrevBal.Visible = false; chkHide_BillDetails.Visible = false; chkHide_BillDetails.Checked = false; rdbDuplicate.Visible = true; rdbOrg.Visible = true; rdbTriple.Visible = true; rdbOrg.Checked = true;
                    break;
                case "3":
                    //chkBlankHead.Visible = true;
                    chkPrevBal.Visible = true; chkHide_BillDetails.Visible = true; chkHide_BillDetails.Checked = false; chkPrevBal.Checked = false; rdbDuplicate.Visible = true; rdbOrg.Visible = true; rdbTriple.Visible = true; rdbOrg.Checked = true;
                    break;
                case "4":
                    //chkBlankHead.Visible = true;
                    chkPrevBal.Visible = true; chkHide_BillDetails.Visible = true; chkHide_BillDetails.Checked = false; chkPrevBal.Checked = false; rdbDuplicate.Visible = true; rdbOrg.Visible = true; rdbTriple.Visible = true; rdbOrg.Checked = true;
                    break;
            }

            FirstTimeNeed.clsfirsttime obj_CFT = new clsfirsttime();

            this.lblTitle.Text = "Bill Print";
            comboBox1.SelectedIndex = 0;
            multiLocationSelection.Visible = false;
            cmbLocation.Visible = true;
            
            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company where co_code='" + Company_id + "' order by co_code ");
            if (dta.Rows.Count == 1)
            {
                cmbcompany.Text = dta.Rows[0][0].ToString();

                Company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                cmbcompany.ReturnValue = Company_id.ToString();

            }
            else if (dta.Rows.Count > 1 && vl == 0)
            {
                cmbcompany.PopUp();
            }

            bnkDtl.Visible = true;
            othrs();
            if (chkBank.Checked == true)
            {
                SelectedACNo = clsDataAccess.GetresultS("select isNull(blAcNo,'') from Companywiseid_Relation where (Company_ID='" + Company_id + "') and (Location_ID='"+Location_id+"')");
                if (SelectedACNo.Trim() != "")
                {
                    dt = clsDataAccess.RunQDTbl("select top 1 bank,acno from Branch where ltrim(rtrim(bank))!='' and (gcode='" + Company_id + "') and (acno='" + SelectedACNo + "')");
                }
                else
                {
                    dt = clsDataAccess.RunQDTbl("select top 1 bank,acno from Branch where ltrim(rtrim(bank))!='' and (gcode='" + Company_id + "')");
                }
                 if (dt.Rows.Count > 0)
                 {
                     bnkDtl.Text = dt.Rows[0]["bank"].ToString();
                     SelectedACNo = dt.Rows[0]["acno"].ToString();
                     bnkDtl.ReturnValue = SelectedACNo;
                 }
            }
            //dtpForm.Text = Convert.ToString(edpcom.CURRCO_SDT);
            //dtpto.Text = Convert.ToString(edpcom.CURRCO_EDT);
            //cheDescription.Checked = true;
            //raddetails.Checked = true;
            //radAlphabetically.Checked = true;
            //this.Text = "Stock Statement";
            //txttransaction.Text = "0";
            //txtitem.Text = "0";
            int mn = Convert.ToInt32(clsDataAccess.GetresultIT("paybillOD"));
            if (mn == 0)
            {
                edpcon.Open();
                result = crt_billOD(edpcon.mycon);
            }
            else if (mn > 0)
            {
                DataTable dt8 = clsDataAccess.RunQDTbl("select * from paybillOD ");

               // txt_Odetails.Text = dt8.Rows[0][0].ToString();
               // Txt_TermsConditions.Text = dt8.Rows[0][1].ToString();
            }
          
            //dtpidate.Value = System.DateTime.Now;
            clsValidation.GenerateYear(cmbYear, 2014, System.DateTime.Now.Year, 1);
            //set session
            ////if (System.DateTime.Now.Month >= 4)
            ////{
            ////    cmbYear.SelectedIndex = 0;
            ////}
            ////else
            ////{
            ////    cmbYear.SelectedIndex = 1;
            ////}


            readFile();

            
             SessionValueCheckAndAssignNoOfDays();
        


            if (cmbYear.Text != vSes)
            {
                cmbYear.SelectedItem = vSes;
            }
            //if (dateTimePicker1.Value.Month >= 4)
            //{
            //    cmbYear.SelectedIndex = 0;
            //}
            //else
            //{
            //    cmbYear.SelectedIndex = 1;
            //}
            int asign = 0;
            try
            {
                asign = Convert.ToInt32(clsDataAccess.GetresultS("select bill_sign from CompanyLimiter"));
            }
            catch
            {
                asign = 0;
            }

            if (asign == 1)
            {
                boolsign = true;
            }
            else
            {
                boolsign = false;
            }
            grp_sign.Enabled = boolsign;

            try
            {
                email = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select email_bill from CompanyLimiter")));
            }
            catch
            {
                email = 0;
            }

            

            string blhd = clsDataAccess.ReturnValue("select bill_head from CompanyLimiter");
            if (blhd.Trim() == "1") { rdb_type_inv.Checked = true; }
            else if (blhd.Trim() == "2") { rdb_type_bill.Checked = true; }
            else if (blhd.Trim() == "3") { rdb_type_bos.Checked = true; }

            if (email == 1)
            {
                txtTo.Text = clsDataAccess.ReturnValue("select blEmail FROM Companywiseid_Relation where (company_id='"+Company_id+"') and (location_id='"+Location_id+"')");
                txtcc.Text = clsDataAccess.ReturnValue("select Email FROM tbl_Employee_CliantMaster where (client_id=(select Cliant_ID FROM tbl_Emp_Location where (Location_ID='" + Location_id + "')))");
                if (txtTo.Text.Trim() != "")
                {
                    btnEmail.Visible = true;
                }
                else
                {
                    btnEmail.Visible = false;
                }
                panel2.Visible = true;
            }
            else
            {
                btnEmail.Visible = false;
            }

            ODet();
            
        }
        public void ODet()
        {
            string details = clsDataAccess.ReturnValue("select distinct ODetails FROM Branch where (GCODE='" + Company_id + "') and (BRNCH_CODE=1)");
            string termscondition = clsDataAccess.ReturnValue("select distinct termscondition FROM Branch where (GCODE='" + Company_id + "') and (BRNCH_CODE=1)");

            if (details.Trim() != "")
            {
                txt_Odetails.Text = details.Trim();
            }

            if (termscondition.Trim() != "")
            {
                Txt_TermsConditions.Text = termscondition.Trim();
            }
        }
        public void othrs()
        {
            
                DataTable dt = clsDataAccess.RunQDTbl("SELECT nid, narration, remarks, note, others, termscondition,chkBank FROM tbl_BillNarr where (coid='"+ Company_id +"') and (clid='"+ client_id +"') and (locid='"+ Location_id +"')"); 
             

        //  DataTable dt = clsDataAccess.RunQDTbl("SELECT narration,remarks,note,others,termscondition,chkBank FROM tbl_BillNarr where ([coid]=" + lblCoid.Text + ") and ([clid]=" + LblClient.Text + ") and ([locid]=" + lblClientID.Text +")");  
           
            if (dt.Rows.Count>0)
            {
                
                     Txt_TermsConditions.Text= dt.Rows[0]["termscondition"].ToString();
            txt_Odetails.Text= dt.Rows[0]["others"].ToString();
            txtNote.Text= dt.Rows[0]["note"].ToString();
                if (dt.Rows[0]["note"].ToString().Trim() != "")
                {
                    lblNote.Text = dt.Rows[0]["note"].ToString();
                }
                if (dt.Rows[0]["remarks"].ToString() != "")
                {
                    txtDesc.Text = dt.Rows[0]["narration"].ToString() + "[" + dt.Rows[0]["remarks"].ToString() + "]";
                }
                else
                {
                    txtDesc.Text = dt.Rows[0]["narration"].ToString();

                }
                if (chkBank.Checked == false)
                {
                    if (dt.Rows[0]["chkBank"].ToString() == "1")
                    {
                        chkBank.Checked = true;
                    }
                    else
                    {
                        chkBank.Checked = false;
                    }
                }
            }
            else
            {
                txtDesc.Text = txtDesc.Text + Environment.NewLine + "PLACED AT YOUR DISPOSAL AT " + clsDataAccess.GetresultS("SELECT Location_Name  FROM tbl_Emp_Location where (Location_ID='" + Location_id + "') and (Cliant_ID='" + client_id + "')");
                //txtRemarks.Text = dt.Rows[0]["remarks"].ToString();
                //txtNote.Text = dt.Rows[0]["note"].ToString();
                //txt_Odetails.Text = dt.Rows[0]["others"].ToString();
                //Txt_TermsConditions.Text = dt.Rows[0]["termscondition"].ToString();
            }

             

        }

        public bool crt_billOD(SqlConnection con)
        {
            string Country = "create table [paybillOD]([ODetails] [nvarchar](max) NULL,[TC] [nvarchar](max) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]";
            SqlCommand cmd = new SqlCommand(Country, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
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
        string bankD = "";
        public void BANK_DETAILS()
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["mis4"].ToString().Trim() == "")
                {
                    if (SelectedACNo == "")
                    {
                        DataTable dt = clsDataAccess.RunQDTbl("Select distinct bank,acno,ifsc from branch where (GCode='" + Company_id + "')");
                        if (dt.Rows.Count > 0)
                        {
                            bankD = "BANK DETAILS FOR RTGS/NEFT/IMPS:\n\r" + dt.Rows[0][0].ToString() + "\n\rA/C NO. :" + dt.Rows[0][1].ToString() + "    IFSC :" + dt.Rows[0][2].ToString();
                            ds.Tables[0].Rows[i]["mis4"] = bankD;
                            //break;
                        }
                    }
                    else
                    {
                        DataTable dt = clsDataAccess.RunQDTbl("Select distinct bank,acno,ifsc,[bank_br],[bank_br_add] from branch where (GCode='" + Company_id + "') and acno = '" + SelectedACNo + "'");
                        if (dt.Rows.Count > 0)
                        {
                            //bankD = "Bank Name " + dt.Rows[0][0].ToString() + "\n\r Account No. " + dt.Rows[0][1].ToString() + "   RTGS/NEFT IFSC : " + dt.Rows[0][2].ToString();
                            bankD = "BANK DETAILS FOR RTGS/NEFT/IMPS:\n\r" + dt.Rows[0][0].ToString() + " - " + dt.Rows[0]["bank_br"].ToString() + "\n\rA/C NO. :" + dt.Rows[0][1].ToString() + "    IFSC :" + dt.Rows[0][2].ToString() + "\n\r Address :" + dt.Rows[0]["bank_br_add"].ToString();
                            ds.Tables[0].Rows[i]["mis4"] = bankD;
                            //break;
                        }
                    }
                }
            }

        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cmbBillType.SelectedIndex == 0)
            {
                strBillFormatNo = "1";
            }
            else if (cmbBillType.SelectedIndex == 1)
            {
                strBillFormatNo = "2";
            }
            else if (cmbBillType.SelectedIndex == 2)
            {
                strBillFormatNo = "3";
            }
            else if (cmbBillType.SelectedIndex == 3)
            {
                strBillFormatNo = "4";
            }
            else if (cmbBillType.SelectedIndex == 4) // Terms and condition
            {
                strBillFormatNo = "6";
            }
            else if (cmbBillType.SelectedIndex == 5) // GST
            {
                strBillFormatNo = "7";
            }



            hsn = ""; sper = "0"; samt = "0"; cper = "0"; camt = "0"; txnAmt = "0"; tval = "0"; ptype = "0";
            if (Item_Code.Trim() == "")
            {
                EDPMessageBox.EDPMessage.Show("Please select bill no first.");
                return;
            }
            string odetails="", termCon="",bill_type="Tax Invoice",bl_type="Invoice";
            onote = "";
            DataTable dt8 = clsDataAccess.RunQDTbl("select * from paybillOD ");

            if (rdb_type_bill.Checked == true)
            {
                bill_type = "BILL";
                bl_type = "BILL";
            }
            else if (rdb_type_bos.Checked == true)
            {
                bill_type = "BILL OF SUPPLY";
                bl_type = "Bill of Supply";
            }
            else
            {
                bl_type = "INVOICE";
                bill_type = "TAX INVOICE";
            }

            if (dt8.Rows.Count == 0)
            {
                if (txt_Odetails.Text == "" || Txt_TermsConditions.Text == "")
                {
                    MessageBox.Show("Other Details or Terms and Conditions is empty, Please Check", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               // bool rs = clsDataAccess.RunNQwithStatus("insert into paybillOD values('" + txt_Odetails.Text + "','" + Txt_TermsConditions.Text + "')");
            odetails= txt_Odetails.Text;
            termCon=Txt_TermsConditions.Text;
            
            }
            else
            {
                //txt_Odetails.Text = dt8.Rows[0][0].ToString();
                //Txt_TermsConditions.Text = dt8.Rows[0][1].ToString();
                odetails = txt_Odetails.Text;
                termCon = Txt_TermsConditions.Text;
            }
            
            Retrive_DataESI();
            //if (billcode.Trim() == "")
            //{

            //}
            MidasReport.Form1 opening = new MidasReport.Form1();
            string range="",mon="",nar = "",coname="";
            string[] dt_range;
            coname = ds.Tables[0].Rows[0]["coname"].ToString().Trim();
            if (ds.Tables[0].Rows[0]["Monthdays"].ToString().Trim().Contains("RANGE") == true)
            {
                //RANGE20-21
                //range
                mon = ds.Tables[0].Rows[0]["Month"].ToString();
                dt_range = ds.Tables[0].Rows[0]["Monthdays"].ToString().Replace("RANGE", "").Trim().Split('-');
                range = bl_type + " FOR THE PERIOD OF " + dt_range[0] + " " + (DateAndTime.DateAdd(DateInterval.Month, -1, Convert.ToDateTime("01/" + mon))).ToString("MMM-yyyy") + " TO " + dt_range[1] + " " + Convert.ToDateTime("01/" + mon).ToString("MMM-yyyy");
            }
            else
            {
                 mon = ds.Tables[0].Rows[0]["Month"].ToString();
                 range = bl_type + " FOR THE MONTH OF : " + mon; 
            }
            nar = clsDataAccess.GetresultS("select GSTTYPE from Companywiseid_Relation where Company_ID=" + Company_id + " and Location_ID =" + Location_id);
            if (nar.ToUpper().Trim() == "REVERSE CHARGES")
            {
                nar = "Tax on Reverse Charge : Yes";
            }
            else
            {
                nar = "";
            }
            double tamt = 0,stamtp=0;
            
            for (int ind = 0; ind < ds.Tables[0].Rows.Count; ind++)
            {
                try
                {
                    tamt = tamt + Convert.ToDouble(ds.Tables[0].Rows[ind]["BILLAMT"]);       //Changes made in this line 040820171011AM/
                }
                catch { }

            }

            if (chkBank.Checked == true)
            {
                BANK_DETAILS();
            }
            else
            {
                try
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["mis4"] = "";
                    }
                }
                catch { }
            }

            DataTable dtw, dts;
           
            double serper1 = 0,serper2=0;
            string serv1 = "",serva1 = "",serv2="",serva2 ="";
            //try
            //{
            //    dtw = clsDataAccess.RunQDTbl("select stname,stper from paybillst where stname='Service Tax' or stname='ST'");
            //    serv1 = dtw.Rows[0][0].ToString();
            //    serper1 = Convert.ToDouble(dtw.Rows[0][1]);
            //    stamtp = tamt * Convert.ToDouble(serper1) / 100;
            //    serva1 = serv1 + " @ " + Convert.ToString(serper1) + " %     Rs. " + stamtp;
            //}
            //catch
            //{
            //    MessageBox.Show("Service Tax not assigned","Bravo",MessageBoxButtons.OK , MessageBoxIcon.Warning );
            //    serv1 = ""; }
           
            //try{
            //    dts = clsDataAccess.RunQDTbl("Select stname,stper from paybillst where stname='Swach Bharat Cess' or stname='Swach' or stname='SBCess'");

            //serv2 = dts.Rows[0][0].ToString();
            //serper2 = Convert.ToDouble(dts.Rows[0][1]);
            //stamtp = tamt * Convert.ToDouble(serper2) / 100;
            //serva2 = serv2 + " @ " + Convert.ToString(serper2) + " %     Rs. " + stamtp;
            //    }
            //catch
            //{
            //    MessageBox.Show("Swach Bharat Cess not assigned", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    serva2 = ""; }
            try
            {
                serv1 = "";
                serv2 = "";
                string gsttype = "";
                Boolean flag = false;
                string[] blno = Item_Code.Split(',');
                foreach (string bill in blno)
                {
                    DataTable gst_det = clsDataAccess.RunQDTbl("select hsn,sum(billamt)BAmt, GstPer,SUM(Gst)GST  from (select CAST((CASE WHEN d.SAC is null then ' ' ELSE (select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) END) as varchar(50))HSN,BILLAMT,GstPer,Gst from paybillD as d where (BILLNO="+bill+")" +Environment.NewLine + 
                        "Union all"  + Environment.NewLine +
                   "select CAST((CASE WHEN d.SAC is null then ' ' ELSE (select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) END) as varchar(50))HSN,Oamt as BILLAMT,GstPer,Gst from paybillO as d where (BILLNO=" + bill + ") and IncGst=0 )x group by HSN,GstPer order by HSN,GstPer");

                    DataTable getGSTDetails = clsDataAccess.RunQDTbl("select Comany_id,Location_ID,isGST,ServiceAmount,ScAmt, (CASE WHEN isRound = 'True' THEN Round(TotAMT, 2) ELSE TotAmt END) AS TotAMT,isRound,IsService,GstPer,CAST((CASE WHEN d.SAC is null then ' ' ELSE (select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) END) as varchar(50))HSN from paybill d where BILLNO = " + bill);
                    if (getGSTDetails.Rows.Count > 0)
                    {
                        string chk = getGSTDetails.Rows[0]["isGST"].ToString().Trim();
                        if (getGSTDetails.Rows[0]["isGST"].ToString().Trim() == "True")
                        {
                            flag = true;
                            DataTable getIGSTOrNot = clsDataAccess.RunQDTbl("select distinct (isNull((select crm.GSTTYPE from Companywiseid_Relation crm where crm.Location_ID = pbd.Location_ID and crm.Company_ID = pbd.Comany_id),'LOCAL'))  as 'GSTTYPE' from paybill pbd where pbd.BILLNO = " + bill);
                            if (getIGSTOrNot.Rows[0][0].ToString().Trim() == "LOCAL")
                            {
                                //DataTable setGstPer = clsDataAccess.RunQDTbl("select GSTPER from Branch where GCODE = '" + getGSTDetails.Rows[0]["Comany_id"] + "'");
                                DataTable setGstPer = clsDataAccess.RunQDTbl("select GSTPER from Branch where GCODE = '" + getGSTDetails.Rows[0]["Comany_id"] + "'");
                                //double totper = Convert.ToDouble(setGstPer.Rows[0][0]);
                                double totper = Convert.ToDouble(getGSTDetails.Rows[0]["GstPer"]);//Math.Round(100 * Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / (Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"]) + Convert.ToDouble(getGSTDetails.Rows[0]["ScAmt"])));
                                serper1 = totper / 2;
                                stamtp = tamt * Convert.ToDouble(serper1) / 100;

                                string roff = "", roff_val = "";
                                if (getGSTDetails.Rows[0]["isRound"].ToString() == "True")
                                {
                                    roff = "Round off";
                                    roff_val = Convert.ToString(string.Format("{0:N}", Math.Round(Math.Round(Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) + Convert.ToDouble(getGSTDetails.Rows[0]["SCAmt"]) + Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"])) - (Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) + Convert.ToDouble(getGSTDetails.Rows[0]["SCAmt"]) + Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"])), 2)));

                                    //Convert.ToString(string.Format("{0:N}", Math.Round((Convert.ToInt32(getGSTDetails.Rows[0]["ServiceAmount"]) + Convert.ToInt32(getGSTDetails.Rows[0]["TotAMT"])) - (Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) + Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"])), 2)));
                                }
                                else
                                {
                                    roff_val = "";
                                    roff = "";
                                }
                                if (gst_det.Rows.Count > 0)
                                {
                                    for (int idx = 0; idx < gst_det.Rows.Count; idx++)
                                    {
                                        if (hsn.Trim() == "")
                                        {
                                            hsn = gst_det.Rows[idx]["HSN"].ToString();
                                            txnAmt = Convert.ToDouble(gst_det.Rows[idx]["BAmt"]).ToString("0.00");
                                            sper = Convert.ToDouble(Convert.ToDouble(gst_det.Rows[idx]["GstPer"]) / 2).ToString("0.00"); //serper1.ToString("0.00");
                                            samt = Convert.ToDouble(Convert.ToDouble(gst_det.Rows[idx]["GST"]) / 2).ToString("0.00");
                                            cper = Convert.ToDouble(Convert.ToDouble(gst_det.Rows[idx]["GstPer"]) / 2).ToString("0.00"); //serper1.ToString("0.00");
                                            camt = Convert.ToDouble(Convert.ToDouble(gst_det.Rows[idx]["GST"]) / 2).ToString("0.00");
                                            tval = Convert.ToDouble(gst_det.Rows[idx]["GST"]).ToString("0.00");// (stamtp + stamtp).ToString("0.00");
                                        }
                                        else
                                        {
                                            hsn = hsn + "\r\n" + gst_det.Rows[idx]["HSN"].ToString();
                                            txnAmt = txnAmt + "\r\n" + Convert.ToDouble(gst_det.Rows[idx]["BAmt"]).ToString("0.00");
                                            sper = sper + "\r\n" + Convert.ToDouble(Convert.ToDouble(gst_det.Rows[idx]["GstPer"]) / 2).ToString("0.00"); //serper1.ToString("0.00");
                                            samt = samt + "\r\n" + Convert.ToDouble(Convert.ToDouble(gst_det.Rows[idx]["GST"]) / 2).ToString("0.00");
                                            cper = cper + "\r\n" + Convert.ToDouble(Convert.ToDouble(gst_det.Rows[idx]["GstPer"]) / 2).ToString("0.00"); //serper1.ToString("0.00");
                                            camt = camt + "\r\n" + Convert.ToDouble(Convert.ToDouble(gst_det.Rows[idx]["GST"]) / 2).ToString("0.00");
                                            tval = tval + "\r\n" + Convert.ToDouble(gst_det.Rows[idx]["GST"]).ToString("0.00");//(stamtp + stamtp).ToString("0.00");

                                        }
                                    }
                                }

                                if (SacGst == 0)
                                {
                                    serva1 = "ADD : " + Environment.NewLine + "SGST @" + serper1 + "%" + Environment.NewLine + "CGST @" + serper1 + "%" + Environment.NewLine + roff;
                                }
                                else
                                {
                                    serva1 = "ADD : " + Environment.NewLine + "SGST " + Environment.NewLine + "CGST "  + Environment.NewLine + roff;
                                }
                                serva2 = Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + roff_val;
                                /*HAVE TO THINK THIS PART........
                                if (getGSTDetails.Rows[0]["isRound"].ToString().Trim() == "True")
                                {
                                    serva1 = "ADD : " + Environment.NewLine + "SGST @" + serper1 + "%" + Environment.NewLine + "Rounded off(+/-)" + Environment.NewLine + "CGST @" + serper1 + "%" + Environment.NewLine + "Rounded off(+/-)";
                                    serva2 = Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + string.Format("{0:N}", ((Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) - Math.Round(Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2))) + Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + string.Format("{0:N}", ((Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) - Math.Round(Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2)));
                                }
                                else
                                {
                                    serva1 = "ADD : " + Environment.NewLine + "SGST @" + serper1 + "%" + Environment.NewLine + "CGST @" + serper1 + "%";
                                    serva2 = Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) ;
                                }
                                 */
                            }
                            else
                            {
                                DataTable setGstPer = clsDataAccess.RunQDTbl("select GSTPER from Branch where GCODE = '" + getGSTDetails.Rows[0]["Comany_id"] + "'");

                                //serper1 = Convert.ToDouble(setGstPer.Rows[0][0]);
                                serper1 = Convert.ToDouble(getGSTDetails.Rows[0]["GstPer"]);// Math.Round(100 * Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / (Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"]) + Convert.ToDouble(getGSTDetails.Rows[0]["ScAmt"])));
                                stamtp = tamt * Convert.ToDouble(serper1) / 100;
                                if (SacGst == 0)
                                {
                                    serva1 = "ADD : " + Environment.NewLine + "IGST @" + serper1 + "%";
                                }
                                else
                                {
                                    serva1 = "ADD : " + Environment.NewLine + "IGST ";
                                }
                                serva2 = Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]).ToString("0.00");//Math.Round(stamtp,2).ToString();
                                serva2 = Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(serva2));


                                if (gst_det.Rows.Count > 0)
                                {
                                    for (int idx = 0; idx < gst_det.Rows.Count; idx++)
                                    {
                                        if (hsn.Trim() == "")
                                        {
                                            hsn = gst_det.Rows[idx]["HSN"].ToString();
                                            sper = 0.ToString("0.00");
                                            samt = 0.ToString("0.00");
                                            cper = Convert.ToDouble(gst_det.Rows[idx]["Gstper"]).ToString("0.00");
                                            camt = Convert.ToDouble(gst_det.Rows[idx]["GST"]).ToString("0.00");
                                            tval = Convert.ToDouble(gst_det.Rows[idx]["GST"]).ToString("0.00");//(stamtp + stamtp).ToString("0.00");
                                            txnAmt = Convert.ToDouble(gst_det.Rows[idx]["BAmt"]).ToString("0.00");
                                        }
                                        else
                                        {
                                            hsn = hsn + "\r\n" + gst_det.Rows[idx]["HSN"].ToString();
                                            sper = sper + "\r\n" + 0.ToString("0.00");
                                            samt = samt + "\r\n" + 0.ToString("0.00");
                                            cper = cper + "\r\n" + Convert.ToDouble(gst_det.Rows[idx]["Gstper"]).ToString("0.00");
                                            camt = camt + "\r\n" + Convert.ToDouble(gst_det.Rows[idx]["GST"]).ToString("0.00");
                                            tval = tval + "\r\n" + Convert.ToDouble(gst_det.Rows[idx]["GST"]).ToString("0.00");//(stamtp + stamtp).ToString("0.00");

                                            txnAmt = txnAmt + "\r\n" + Convert.ToDouble(gst_det.Rows[idx]["BAmt"]).ToString("0.00");

                                        }
                                    }
                                }
                                //hsn = getGSTDetails.Rows[0]["HSN"].ToString();
                                //sper = 0.ToString("0.00");
                                //samt = 0.ToString("0.00");
                                //cper = serper1.ToString("0.00");
                                //camt = stamtp.ToString("0.00");
                                //tval = (stamtp).ToString("0.00");

                                if (getGSTDetails.Rows[0]["isRound"].ToString().Trim() == "True")
                                {
                                    double roffAmt = 0;//Math.Round(stamtp) - stamtp;
                                    string roff = "", roff_val = "";
                                    if (getGSTDetails.Rows[0]["isRound"].ToString() == "True")
                                    {
                                        roff = "Round off";
                                        roff_val = Convert.ToString(string.Format("{0:N}", Math.Round((Convert.ToInt32(getGSTDetails.Rows[0]["ServiceAmount"]) + Convert.ToInt32(getGSTDetails.Rows[0]["SCAmt"]) + Convert.ToInt32(getGSTDetails.Rows[0]["TotAMT"])) - (Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) + Convert.ToDouble(getGSTDetails.Rows[0]["SCAmt"]) + Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"])), 2)));


                                        roffAmt = Convert.ToDouble(roff_val);
                                    }
                                    else
                                    {
                                        roff_val = "0";
                                        roff = "";
                                        roffAmt = 0;
                                    }



                                    if (roffAmt > 0)
                                    {
                                        serva1 = serva1 + Environment.NewLine + roff;//"Rounded off(+/-)";
                                        serva2 = serva2 + Environment.NewLine + "+" + string.Format("{0:N}", roffAmt);
                                    }
                                    else if (roffAmt < 0)
                                    {
                                        serva1 = serva1 + Environment.NewLine + roff;//"Rounded off(+/-)";
                                        serva2 = serva2 + Environment.NewLine + string.Format("{0:N}", roffAmt);
                                    }
                                }
                            }
                        }

                        else if (getGSTDetails.Rows[0]["IsService"].ToString().Trim() == "True")
                        {
                            dtw = clsDataAccess.RunQDTbl("select stname,stper from paybillst");

                            for (int ind = 0; ind < dtw.Rows.Count; ind++)
                            {
                                //serv1 = edpcom.GetAmountFormat(0, 2);
                                serv1 = dtw.Rows[ind][0].ToString();
                                serper1 = Convert.ToDouble(dtw.Rows[ind][1]);
                                stamtp = tamt * Convert.ToDouble(serper1) / 100;
                                if (isScAdd == "False")
                                {
                                    serva2 = "";
                                    if (serva1 == "")
                                    {
                                        serva1 = serv1 + " @ " + Convert.ToString(serper1) + " %     Rs. " + Math.Round(stamtp, 2);
                                    }
                                    else
                                    {
                                        serva1 = serva1 + Environment.NewLine + serv1 + " @ " + Convert.ToString(serper1) + " %     Rs. " + Math.Round(stamtp, 2);
                                    }
                                }
                                else
                                {
                                    if (serva1 == "")
                                    {
                                        serva1 = "Add : " + serv1 + " @ " + Convert.ToString(serper1) + " %     ";
                                        serva2 = Math.Round(stamtp, 2).ToString();
                                    }
                                    else
                                    {
                                        serva1 = serva1 + Environment.NewLine + serv1 + " @ " + Convert.ToString(serper1) + " %     ";
                                        serva2 = serva2 + Environment.NewLine + Math.Round(stamtp, 2).ToString();
                                    }
                                }

                            }
                        }
                        else
                        {

                            if (gst_det.Rows.Count > 0)
                            {
                                for (int idx = 0; idx < gst_det.Rows.Count; idx++)
                                {
                                    if (hsn.Trim() == "")
                                    {
                                        hsn = gst_det.Rows[idx]["HSN"].ToString();
                                        sper = 0.ToString("0.00");
                                        samt = 0.ToString("0.00");
                                        cper = 0.ToString("0.00");
                                        camt = 0.ToString("0.00");
                                        tval = (stamtp + stamtp).ToString("0.00");
                                        txnAmt = Convert.ToDouble(gst_det.Rows[idx]["BAmt"]).ToString("0.00");//gst_det.Rows[idx]["BAmt"].ToString();
                                    }
                                    else
                                    {
                                        hsn = hsn + "\r\n" + gst_det.Rows[idx]["HSN"].ToString();
                                        sper = sper + "\r\n" + 0.ToString("0.00");
                                        samt = samt + "\r\n" + 0.ToString("0.00");
                                        cper = cper + "\r\n" + 0.ToString("0.00");
                                        camt = camt + "\r\n" + 0.ToString("0.00");
                                        tval = tval + "\r\n" + Convert.ToDouble(gst_det.Rows[idx]["GST"]).ToString("0.00");//(stamtp + stamtp).ToString("0.00");

                                        txnAmt = txnAmt + "\r\n" + Convert.ToDouble(gst_det.Rows[idx]["BAmt"]).ToString("0.00");
                                    }
                                }
                            }
                        }
                    }
                    

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if ("'"+ds.Tables[0].Rows[i]["BILLNO"].ToString()+"'" == bill)
                        {
                            ds.Tables[0].Rows[i]["mis6"] = serva1;
                            ds.Tables[0].Rows[i]["mis7"] = serva2;
                        }
                    }

                }
                /*if (!flag)
                {
                    dtw = clsDataAccess.RunQDTbl("select stname,stper from paybillst");
                    for (int ind = 0; ind < dtw.Rows.Count; ind++)
                    {

                        serv1 = dtw.Rows[ind][0].ToString();
                        serper1 = Convert.ToDouble(dtw.Rows[ind][1]);
                        stamtp = tamt * Convert.ToDouble(serper1) / 100;
                        if (isScAdd == "False")
                        {
                            serva2 = "";
                            if (serva1 == "")
                            {
                                serva1 = serv1 + " @ " + Convert.ToString(serper1) + " %     Rs. " + Math.Round(stamtp, 2);
                            }
                            else
                            {
                                serva1 = serva1 + Environment.NewLine + serv1 + " @ " + Convert.ToString(serper1) + " %     Rs. " + Math.Round(stamtp, 2);
                            }
                        }
                        else
                        {
                            if (serva1 == "")
                            {
                                serva1 = "Add : " + serv1 + " @ " + Convert.ToString(serper1) + " %     ";
                                serva2 = Math.Round(stamtp, 2).ToString();
                            }
                            else
                            {
                                serva1 = serva1 + Environment.NewLine + serv1 + " @ " + Convert.ToString(serper1) + " %     ";
                                serva2 = serva2 + Environment.NewLine + Math.Round(stamtp, 2).ToString();
                            }
                        }

                    }
                }*/
            }
            catch
            {
                MessageBox.Show("Service Tax not assigned", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                serv1 = "";
            }
            serv1 = "";
            serv2 = "";
           // serva2 = "0";
            if(cbSaveNewOtherDetails.Checked)
                writeFile();

            if (lblNote.Text.Trim() != "")
            {
                onote = lblNote.Text;
                    //onote + Environment.NewLine + Environment.NewLine + lblNote.Text;
            }

            advertisement();
            if (chkHide_BillDetails.Checked == true)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                   
                        ds.Tables[0].Rows[i]["NoofPersonnel"] = 0;
                        ds.Tables[0].Rows[i]["Attendance"] = "0.00";
                        ds.Tables[0].Rows[i]["Rate"] = "0.00";
                    
                }
            }

            string btc = clsDataAccess.ReturnValue("select BillTC from CompanyLimiter").Trim();
            switch (strBillFormatNo)
            { 
                case "1":
                    if (btc == "1")
                    {
                        termsconditions =  termCon;
                    }
                    else{
                    termsconditions = "Cheque / DD/ Pay Order Should be in favour of <b>" + coname + "</b>\n\r" + termCon;
                    }
                    opening.paybillO_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission,tc);
                    break;
                case "2":
                    if (btc == "1")
                    {
                        termsconditions = termCon;
                    }
                    else
                    {
                        termsconditions = "Cheque / DD/ Pay Order Should be in favour of <b>" + coname + ".</b> <br>" + termCon;
                    }
                    if (chkBlankHead.Checked == true)
                    {
                        opening.paybillO_Format1_blank_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, tc, bill_type, bl_type);
                    }
                    else
                    {
                        opening.paybillO_Format1_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, tc, bill_type, bl_type);
                    }
                    break;
                case "3":
                    if (btc == "1")
                    {
                        termsconditions = termCon;
                    }
                    else
                    {
                        termsconditions = "Cheque / DD/ Pay Order Should be in favour of \b" + coname + ". \b " + termCon;
                    }
                    string val="";
                    if (chkPrevBal.Checked==false){val="0";}else {val=lblprevbal.Text;}
                    if (chkBlankHead.Checked == true)
                    {

                        opening.paybillO_Format2_blank_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                    }
                    else
                    {
                        opening.paybillO_Format2_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                    }
                    break;

                case "4":
                    //string val = "";
                    if (btc == "1")
                    {
                        termsconditions = termCon;
                    }
                    else
                    {
                        termsconditions = "Cheque / DD/ Pay Order Should be in favour of <b>" + coname + "</b>\n\r" + termCon;
                    }
                    if (chkPrevBal.Checked == false) { val = "0"; } else { val = lblprevbal.Text; }
                    if (chkBlankHead.Checked == true)
                    {
                        opening.paybillO_Format2_blank_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                    }
                    else
                    {
                        opening.paybillO_Format3_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                    }
                    break;

                case "6":
                   // string val = "";
                    termsconditions = termCon;
                    if (chkPrevBal.Checked == false) { val = "0"; } else { val = lblprevbal.Text; }
                    if (chkBlankHead.Checked == true)
                    {

                        opening.paybillO_Format2_blank_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                        //opening.paybillO_Format2_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                    }
                    else
                    {
                        //opening.paybillO_Format2_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                        opening.paybillO_RTF_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                    }
                    break;

                case "7":
                    // string val = "";
                    termsconditions = termCon;
                    if (chkPrevBal.Checked == false) { val = "0"; } else { val = lblprevbal.Text; }
                    if (chkBlankHead.Checked == true)
                    {

                       // opening.paybillO_GST_blank_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                        
                    }
                    else
                    {

                        opening.paybillO_GST_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar, hsn, txnAmt, sper, samt, cper, camt, tval, "0");
                    }
                    break;
            }
            //opening.paybillO_print(serva1, serva2, ODetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono,"Security Guard",boolAdPrintingPermission);
            //opening.paybillO_Format1_print(serva1, serva2, ODetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission);
            opening.ShowDialog();
            //lblEnclosure.Text = "";
            //lblprevbal.Text = "0";
            ds.Tables.Clear();
            ds.Dispose();
        }

        private string BillFormatNo()
        {
            string FormatNo = "3";
            try
            {
                FormatNo = Convert.ToString(clsDataAccess.GetresultS("select bill_format from CompanyLimiter"));
            }
            catch
            {
                FormatNo = "3";
            }

          return FormatNo;
        }

       /*
        private string BillFormatNo_1()
        {
            string FormatNo = "1";
            string filePath = "";
            filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
            string lineForConfigSetting;
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    if (file.ReadLine() != null)
                    {
                        int chk_str = 0;
                        while ((lineForConfigSetting = file.ReadLine()) != null)
                        {
                            string[] StrSTAR = lineForConfigSetting.Trim().Split('*');
                            if (StrSTAR.Length == 2)
                            {
                                if (StrSTAR[0].Trim() == "")
                                    continue;
                            }

                            string[] StrLine = lineForConfigSetting.Trim().Split('[');
                            if (StrLine.Length == 2)
                            {
                                string str = lineForConfigSetting.Substring(1, lineForConfigSetting.Length - 2);
                                if (str.ToUpper() == "BILL_FORMAT_NO")
                                    chk_str = 1;
                                if (str.ToUpper() == "BILL_HEAD")
                                    chk_str = 2;


                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                int MonthIndex = System.DateTime.Now.Month;
                                switch (StrLine_WACC[0])
                                {
                                    case "1":
                                        FormatNo = "1";
                                        break;
                                    case "2":
                                        FormatNo = "2";
                                        break;
                                    case "3":
                                        FormatNo = "3";
                                        break;
                                    case "4":
                                        FormatNo = "4";
                                        break;
                                }
                                chk_str = 0;
                            }

                            if ((chk_str == 2) && (StrLine_WACC.Length > 1))
                            {
                                int MonthIndex = System.DateTime.Now.Month;
                                switch (StrLine_WACC[0])
                                {
                                    case "1":
                                        chkBlankHead.Visible = true;
                                        break;
                                    case "0":
                                        chkBlankHead.Visible=false;
                                        break;
                                    
                                }
                                chk_str = 0;
                            }
                        }
                    }

                }
                catch
                { }
            }
            return FormatNo;
        }
       */
        private void advertisement()
        {
            string filePath = "";
            filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
            string lineForConfigSetting;
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    if (file.ReadLine() != null)
                    {
                        int chk_str = 0;
                        while ((lineForConfigSetting = file.ReadLine()) != null)
                        {
                            string[] StrSTAR = lineForConfigSetting.Trim().Split('*');
                            if (StrSTAR.Length == 2)
                            {
                                if (StrSTAR[0].Trim() == "")
                                    continue;
                            }

                            string[] StrLine = lineForConfigSetting.Trim().Split('[');
                            if (StrLine.Length == 2)
                            {
                                string str = lineForConfigSetting.Substring(1, lineForConfigSetting.Length - 2);
                                if (str.ToUpper() == "BILL_ADVERTISEMENT")
                                    chk_str = 1;
                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                int MonthIndex = System.DateTime.Now.Month;
                                switch (StrLine_WACC[0])
                                { 
                                    case "ODD":
                                        if (MonthIndex % 2 == 1)
                                        {
                                            boolAdPrintingPermission = true;
                                        }
                                        break;
                                    case "EVEN":
                                        if (MonthIndex % 2 == 0)
                                        {
                                            boolAdPrintingPermission = true;
                                        }
                                        break;
                                    case "OFF":
                                        boolAdPrintingPermission = true;
                                        break;
                                }
                                chk_str = 0;
                            }
                        }
                    }

                }
                catch
                { }
            }
        }

        public void writeFile()
        {
            termsconditions=Txt_TermsConditions.Text;
            ODetails = txt_Odetails.Text;
            onote = txtNote.Text;
            System.IO.File.WriteAllText(startPath + "\\" + setting_type + "\\TermsConditions.txt", termsconditions);
            System.IO.File.WriteAllText(startPath + ("\\" + setting_type + "\\ODetails.txt"), ODetails);
            System.IO.File.WriteAllText(startPath + ("\\" + setting_type + "\\note.txt"), onote);

        }

        public void readFile()
        {

            startPath =  Application.StartupPath;
            
            string[] type_setting = System.IO.File.ReadAllLines(startPath + "\\type_settings.txt");

            foreach (string line in type_setting)
            {
                if (!line.Contains("*"))
                {
                   setting_type= line;
                }
            }


            termsconditions = System.IO.File.ReadAllText(startPath + "\\" + setting_type + "\\TermsConditions.txt");
            ODetails = System.IO.File.ReadAllText(startPath + "\\" + setting_type + "\\ODetails.txt");
            onote = System.IO.File.ReadAllText(startPath + "\\" + setting_type + "\\note.txt");
            Txt_TermsConditions.Text = termsconditions;
            txt_Odetails.Text = ODetails;
            txtNote.Text = onote;
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
             DataTable dtw = clsDataAccess.RunQDTbl("select stname,stper from paybillst where stname='service Tax'");
            string serv1 = dtw.Rows[0][0].ToString();
            string serper1=dtw.Rows[0][1].ToString();
            string serva1=serv1+ serper1;
            DataTable dts = clsDataAccess.RunQDTbl("Select stname,stper from paybillst where stper='swach Bharat Cess'");
             string serv2=dts.Rows[0][0].ToString();
           string serper2=dts.Rows[0][1].ToString();
            string serva2=serv2+serper2;
            opening.paybillO_print(serva1, serva2, ODetails, termsconditions, bankD,onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2, refno,pono,"",boolAdPrintingPermission,tc);
            opening.ShowDialog();
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

                Report_Page_Header[0] = "Invoice for the location " + cmbLocation.Text;
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

            string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month) + "," + (dateTimePicker1.Value.Year);

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
            string strssql = "", custid="";
            string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
            DataTable tot_employ= new DataTable("");
            DataTable tot_employ_main = new DataTable("");
            Int32 count_payBillD = 0;
            string st_Desc = "";
            string mon_name = clsEmployee.GetMonthName(dateTimePicker1.Value.Month) + " - " + (dateTimePicker1.Value.Year);
            

            string strDesgSQL = "";
            switch (strBillFormatNo)
            {
                case "1":
                    if (setting_type == "type 3")
                    {
                        st_Desc = txtDesc.Text + "\r\n" + "For the location " + cmbLocation.Text;
                    }
                    else
                    {
                        if (txtDesc.Text.Trim() == "Being the amount charged for the supply of service")
                        {
                            st_Desc = "";
                        }
                        else
                        {
                            st_Desc = txtDesc.Text.Trim() + Environment.NewLine + "IN THE MONTH OF " + mon_name + " AS PER DETAIL GIVEN BELOW :-";
                        }
                    }
                    break;
                case "2":
                    st_Desc = txtDesc.Text.Trim() + "IN THE MONTH OF " + mon_name + " :-";
                    break;
            }

            dateTimePicker1.Text = (dateTimePicker1.Value.Month) + "-" + (dateTimePicker1.Value.Year);

            string monthdisp = clsEmployee.GetMonthName(dateTimePicker1.Value.Month) + "  " + (dateTimePicker1.Value.Year);
            string sign = "";
            if (boolsign == true)
            {
                if (rdb_sign.Checked == true)
                {
                    sign = "[sign]";
                }
                else if (rdb_sign2.Checked == true)
                {
                    sign = "[sign2]";
                }
            }
            else
            {
                sign = "''";

            }
            //,(select c.CO_ADD1  from Company c where c.CO_CODE=h.Comany_id ) as 'Add3'
            foreach (string billcode in blno)
            {
                if (billcode.Trim() != "''")
                {
                    count_payBillD =Convert.ToInt32( clsDataAccess.GetresultS("select count(*) from paybillD where billno in (" + billcode + ")"));
                    custid=clsDataAccess.GetresultS("select cliant_id from paybill where billno in (" + billcode + ")");

                    DataTable dct = clsDataAccess.RunQDTbl("SELECT isAdd, blAdd, blPh, blFax, blEmail FROM Companywiseid_Relation where (Company_ID='"+ Company_id +"') and (Location_ID='"+ Location_id +"')");
                    DataTable dtLocWiseChk = clsDataAccess.RunQDTbl("select [Location_ID],[Cliant_ID],[Designation_Id],btype,BILLNO from [paybill] where [BILLNO] = " + billcode);

                    if (dtLocWiseChk.Rows[0][0].ToString() != "0")                              //SINGLE LOCATION BILLING
                    {
                        dct.Clear();
                        dct = clsDataAccess.RunQDTbl("SELECT isAdd, blAdd, blPh, blFax, blEmail FROM Companywiseid_Relation where (Company_ID='" + Company_id + "') and (Location_ID='" + Location_id + "')");
                        //and (Location_ID=(select distinct Location_ID from paybillD where BILLNO = " + billcode + "))");
                        strssql = "";
                        if (count_payBillD > 0)
                        {
                            //(select Location_Name from tbl_Emp_Location where Location_ID=h.Location_ID )
                            strssql = strssql + " select h.BILLNO,CONVERT(VARCHAR(10),h.BILLDATE,103) as BILLDATE,CONVERT(VARCHAR(10),h.DUEDATE,103) as duedate,(select c.co_name from Company c where c.CO_CODE=h.Comany_id ) as 'coname',";
                            strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=h.Comany_id ) as 'Add1',(select distinct (case when ltrim(rtrim(b.GSTINNO))!='' then ' GST No.: '+b.GSTINNO else '' end) from Branch b where b.gcode=h.comany_id)as 'Add2',(select distinct BRNCH_TELE1 from Branch B where B.GCODE=h.Comany_id ) as 'phone',";
                            strssql = strssql + "(select distinct Website from Branch b where b.gcode=h.comany_id )as 'Website' ,(select distinct Email from Branch b where b.gcode=h.comany_id) as 'Email',";
                            //strssql = strssql + " (select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) )) as 'locname','" + monthdisp + "' as Month,h.Session, (CASE WHEN h.isRound = 'True' THEN Round((h.TotAMT+h.ScAmt), 0) ELSE (h.TotAMT+h.ScAmt) END)  as 'TotAMT' ,h.IsService,h.ServiceAmount,";
                            strssql = strssql + " (select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) as 'locname','" + monthdisp + "' as Month,h.Session, (CASE WHEN h.isRound = 'True' THEN Round((h.TotAMT+h.ScAmt), 2) ELSE (h.TotAMT+h.ScAmt) END)  as 'TotAMT' ,h.IsService,h.ServiceAmount,";
                            strssql = strssql + " d.Attendance ,d.BILLAMT,d.Dtl_id ,d.Hour,d.MonthDays,d.RATE,((select e.DesignationName  from tbl_Employee_DesignationMaster e where e.SlNo=d.desig_ID ) + (CASE WHEN H.btype=1 THEN ' [ GST: ' + CAST(D.GstPer as nvarchar(max)) + ' %  Rs. '+CAST(d.Gst as nvarchar(max))+' ]' else '' end) + CAST( CASE WHEN d.rmrks<>'' then ' [' + d.rmrks +']' else '' END as nvarchar(max)) ) as 'designation',d.NoOfPersonnel";
                            //strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )) as 'ClientName'"; //(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )
                            strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )) as 'ClientName'"; //(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )



                            try
                            {
                                if (dtLocWiseChk.Rows[0][0].ToString() != "0")
                                {
                                    if (dct.Rows[0]["isAdd"].ToString() == "1")
                                    {
                                        strssql = strssql + " ,'' as 'ClientCity'";
                                        strssql = strssql + " ,(select 'GSTIN NO. : '+c.GSTINNO+', State Code-'+c.Client_State from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ) as 'Contract_Person'";
                                        strssql = strssql + " ,'' AS mis1,'' as 'Add3'";
                                    }
                                    else if (dct.Rows[0]["isAdd"].ToString() == "2")
                                    {
                                        strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )) as 'ClientCity'";
                                        strssql = strssql + " ,(select 'GSTIN NO. : '+c.GSTINNO+', State Code-'+c.Client_State   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ) as 'Contract_Person'";
                                        strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ))+ ', '+(SELECT Upper( Country_Name) FROM Country where Country_CODE=(select c.Country  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) )) AS mis1,'" + dct.Rows[0]["blAdd"].ToString() + "' as 'Add3'";
                                    }
                                    else
                                    {
                                        strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )) as 'ClientCity'";
                                        strssql = strssql + " ,(select 'GSTIN NO. : '+c.GSTINNO+', State Code-'+c.Client_State   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ) as 'Contract_Person'";
                                        strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ))+ ', '+(SELECT Upper( Country_Name) FROM Country where Country_CODE=(select c.Country  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) )) AS mis1,'' as 'Add3'";
                                    }
                                }
                                else if (dtLocWiseChk.Rows[0][0].ToString() == "0" && dtLocWiseChk.Rows[0][2].ToString() != "")
                                {
                                    strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )) as 'ClientCity'";
                                    strssql = strssql + " ,(select 'GSTIN NO. : '+c.GSTINNO+', State Code-'+c.Client_State   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ) as 'Contract_Person'";
                                    strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ))+ ', '+(SELECT Upper( Country_Name) FROM Country where Country_CODE=(select c.Country  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) )) AS mis1,'' as 'Add3'";
                                }
                            }
                            catch
                            {
                                strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )) as 'ClientCity'";
                                strssql = strssql + " ,(select 'GSTIN NO. : '+c.GSTINNO+', State Code-'+c.Client_State   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ) as 'Contract_Person'";
                                strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ))+ ', '+(SELECT Upper( Country_Name) FROM Country where Country_CODE=(select c.Country  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) )) AS mis1,'' as 'Add3'";
                            }
                            
                            
                           
                            try
                            {
                                if (dtLocWiseChk.Rows[0][0].ToString() != "0")
                                {
                                    if (dct.Rows[0]["isAdd"].ToString() == "1")
                                    {
                                        strssql = strssql + " ,'' as 'Contract_No'";
                                        strssql = strssql + ",'" + dct.Rows[0]["blAdd"].ToString() + "' AS mis2,";
                                    }
                                    else
                                    {
                                        strssql = strssql + " ,'' as 'Contract_No'";
                                        strssql = strssql + " ,(select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ) AS mis2,";
                                    }
                                }
                                else if (dtLocWiseChk.Rows[0][0].ToString() == "0" && dtLocWiseChk.Rows[0][2].ToString() != "")
                                {
                                    strssql = strssql + " ,'' as 'Contract_No'";
                                    strssql = strssql + " ,(select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=h.[Cliant_ID] ) AS mis2,";
                                }
                            }
                            catch
                            {
                                strssql = strssql + " ,'' as 'Contract_No'";
                                strssql = strssql + " ,(select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ) AS mis2,";
                            }
                            //Added by dwipraj dutta 21082017                                                                                                                 //Added by dwipraj 041826072017                         
                            strssql = strssql + " CAST(CASE WHEN d.SAC is null then ' ' ELSE (select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) END as varchar(50)) AS mis3,(select (select 'BANK DETAILS FOR RTGS/NEFT/IMPS:'+CHAR(13)+CHAR(10)+bm.bank +'    A/C NO. : ' + bm.acno + '    IFSC : ' + bm.ifsc from Branch bm where crm.Company_ID = bm.GCODE and crm.blAcNo = bm.acno) from Companywiseid_Relation crm where crm.Company_ID = h.Comany_id and crm.Location_ID = h.Location_ID) AS mis4,'" + st_Desc + "' AS mis5,'' AS mis6,'' AS mis7,h.IsScAdd AS mis9,h.isRound AS mis10,h.isGST as mis8,(SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "') as Cmpimage,(select " + sign + " from Company where GCODE='" + Company_id.ToString() + "') as authsign,'( ORIGINAL / DUPLICATE / TRIPLICATE )' as rmrks";

                            strssql = strssql + " from paybill h inner join paybillD d on h.BILLNO=d.BILLNO";
                            strssql = strssql + " where h.Session='" + cmbYear.Text + "' and d.Month ='" + month + "'";
                            //strssql = strssql + " and h.Location_ID = '" + Location_id + "' and h.Comany_id='" + Company_id + "'";
                            strssql = strssql + " and (h.Comany_id='" + Company_id + "')";
                        }
                        else
                        {

                            strssql = strssql + " select h.BILLNO,CONVERT(VARCHAR(10),h.BILLDATE,103) as BILLDATE,CONVERT(VARCHAR(10),h.DUEDATE,103) as duedate,(select c.co_name from Company c where c.CO_CODE=h.Comany_id ) as 'coname',";
                            strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=h.Comany_id ) as 'Add1',(select distinct (case when ltrim(rtrim(b.GSTINNO))!='' then ' GST No.: '+b.GSTINNO else '' end) from Branch b where b.gcode=h.comany_id)as 'Add2',";
                            if (dct.Rows[0]["isAdd"].ToString() == "2")
                            {
                                strssql = strssql + "'" + dct.Rows[0]["blAdd"].ToString() + "' as 'Add3',";
                            }else{
                                strssql = strssql + "'' as 'Add3',";
                               
                            }
                            strssql = strssql + "(select distinct BRNCH_TELE1 from Branch B where B.GCODE=h.Comany_id ) as 'phone',(select distinct Website from Branch b where b.gcode=h.comany_id )as 'Website' ,(select distinct Email from Branch b where b.gcode=h.comany_id) as 'Email',";
                            //'" + cmbLocation.Text + "'
                            strssql = strssql + " (select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) as 'locname','" + monthdisp + "' as Month,h.Session,(CASE WHEN h.isRound = 'True' THEN Round((h.TotAMT+h.ScAmt), 2) ELSE (h.TotAMT+h.ScAmt) END)  as 'TotAMT' ,h.IsService,h.ServiceAmount,";
                            //strssql = strssql + " (select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) )) as 'locname','" + monthdisp + "' as Month,h.Session,(CASE WHEN h.isRound = 'True' THEN Round((h.TotAMT+h.ScAmt), 0) ELSE (h.TotAMT+h.ScAmt) END)  as 'TotAMT' ,h.IsService,h.ServiceAmount,";
                            strssql = strssql + " '' as Attendance ,0.0000 as BILLAMT,'1' as Dtl_id ,'' as Hour,'' as MonthDays,'' as RATE,'' as 'designation','0' as NoOfPersonnel";
                            //strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )) as 'ClientName'"; //(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )
                            strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=" + custid + ") as 'ClientName'"; //(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )
                            strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=" + custid + " )  as 'ClientCity'";
                            strssql = strssql + " ,(select 'GSTIN NO. : '+c.GSTINNO+', State Code-'+c.Client_State   from tbl_Employee_CliantMaster c where c.Client_id=" + custid + " ) as 'Contract_Person'";
                            strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=" + custid + " ))+', '+(SELECT Upper(Country_Name) FROM Country where Country_CODE=(select c.Country  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) )) AS mis1";

                            try
                            {
                                if (dtLocWiseChk.Rows[0][0].ToString() != "0")
                                {
                                    if (dct.Rows[0]["isAdd"].ToString() == "1")
                                    {
                                        strssql = strssql + " ,'' as 'Contract_No'";
                                        strssql = strssql + ",'" + dct.Rows[0]["blAdd"].ToString() + "' AS mis2,";
                                    }
                                    else
                                    {
                                        strssql = strssql + " ,'' as 'Contract_No'";
                                        strssql = strssql + " ,(select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ) AS mis2,";
                                    }
                                }
                                else if (dtLocWiseChk.Rows[0][0].ToString() == "0" && dtLocWiseChk.Rows[0][2].ToString() != "")
                                {
                                    strssql = strssql + " ,'' as 'Contract_No'";
                                    strssql = strssql + " ,(select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=h.[Cliant_ID] ) AS mis2,";
                                }
                            }
                            catch
                            {
                                strssql = strssql + " ,'' as 'Contract_No'";
                                strssql = strssql + " ,(select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ) AS mis2,";
                            }
                            //strssql = strssql + " ,(select c.Contract_No  from tbl_Employee_CliantMaster c where c.Client_id=" + custid + " ) as 'Contract_No'";
                            
                            //strssql = strssql + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=" + custid + " ) AS mis2,";            //Added by dwipraj 041926072017      
                            strssql = strssql + " '' AS mis3,(select (select 'Bank Name '+bm.bank+CHAR(13)+CHAR(10) +' Account No. ' + bm.acno + '   RTGS/NEFT IFSC : ' + bm.ifsc from Branch bm where crm.Company_ID = bm.GCODE and crm.blAcNo = bm.acno) from Companywiseid_Relation crm where crm.Company_ID = h.Comany_id and crm.Location_ID = h.Location_ID) AS mis4,'" + st_Desc + "' AS mis5,'' AS mis6,'' AS mis7,IsScAdd AS mis9,h.isRound AS mis10,h.isGST as mis8,(SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "') as Cmpimage,(select " + sign + " from Company where GCODE='" + Company_id.ToString() + "') as authsign,'( ORIGINAL / DUPLICATE / TRIPLICATE )' as rmrks";// (ORIGINAL FOR RECIPIENT)

                            strssql = strssql + " from paybill h ";
                            strssql = strssql + " where h.Session='" + cmbYear.Text + "' and h.Month ='" + dateTimePicker1.Text + "'";
                            //strssql = strssql + " and h.Location_ID = '" + Location_id + "' and h.Comany_id='" + Company_id + "'";
                            strssql = strssql + " and (h.Comany_id='" + Company_id + "')";

                        }

                        if (checkBox1.Checked == false)
                        {
                            strssql = strssql + " and h.BILLNO in (" + billcode + ") ";
                        }

                        tot_employ = clsDataAccess.RunQDTbl(strssql);
                        //  DataRow destRow= new DataRow();
                        DataTable dtimage = clsDataAccess.RunQDTbl("SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "' ");
                        DataTable rfcode = clsDataAccess.RunQDTbl("SELECT Order_Date,Cliant_OrderNo,refno FROM tbl_Employee_OrderDetails where order_name=" +
                       "(select distinct ref_order_no from paybillD where BILLNO=" + billcode + " and ref_order_no!='')");
                        if (rfcode.Rows.Count > 0)
                        {
                            if (rfcode.Rows[0]["Cliant_OrderNo"].ToString().Trim() != "")
                            {
                                pono = "W.O. No : " + rfcode.Rows[0]["Cliant_OrderNo"].ToString().Trim() + " Date : " + rfcode.Rows[0]["Order_Date"].ToString().Trim();
                            }
                            else
                            {
                                pono = "";
                            }
                            if (rfcode.Rows[0]["refno"].ToString().Trim() != "")
                            {
                                refno = "Ref No: " + rfcode.Rows[0]["refno"].ToString().Trim();
                            }
                            else
                            {
                                refno = "";
                            }
                        }
                        else
                        {
                            pono = "";
                            refno = "";
                        }


                        DataTable Ord = clsDataAccess.RunQDTbl("Select (case when IncGst=1 then OCHARGES+' *' else OCHARGES + (CASE WHEN (select btype from [paybill] where [BILLNO]=d.BILLNO)=1 THEN ' [ GST: ' + CAST(D.GstPer as nvarchar(max)) + ' %  Rs. '+CAST(d.Gst as nvarchar(max))+' ]' else '' end) end ) as OCHARGES,ORate,OQty,OAMT,BILLNO,(select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) as 'SAC',IncGst,[OAttend] from paybillO d where BILLNO in (" + billcode + ") ");

                        for (int rw_ord = 0; rw_ord < Ord.Rows.Count; rw_ord++)
                        {
                            if (Convert.ToBoolean(Ord.Rows[rw_ord]["IncGst"]) == true)
                            {
                                tc = "( * ) non GST items";
                            }

                            DataRow destRow = tot_employ.NewRow();
                            if (tot_employ.Rows.Count > 0)
                            {
                                if (count_payBillD > 0)
                                {
                                    destRow[0] = tot_employ.Rows[0][0];
                                    destRow[1] = tot_employ.Rows[0][1];
                                    destRow[2] = tot_employ.Rows[0][2];
                                    destRow[3] = tot_employ.Rows[0][3];
                                    destRow[4] = tot_employ.Rows[0][4];
                                    destRow[5] = tot_employ.Rows[0][5];
                                    destRow[6] = tot_employ.Rows[0][6];
                                    destRow[7] = tot_employ.Rows[0][7];
                                    destRow[8] = tot_employ.Rows[0][8];

                                   
                                    // +" " + Ord.Rows[rw_ord]["rmrks"];
                                    destRow[9] = tot_employ.Rows[0][9];
                                    destRow[10] = tot_employ.Rows[0][10];
                                    destRow[11] = tot_employ.Rows[0][11];
                                    destRow[12] = tot_employ.Rows[0][12];
                                    //destRow[13] = tot_employ.Rows[0][13];
                                    //destRow[14] = tot_employ.Rows[0][14];
                                    destRow[15] = tot_employ.Rows[0][15];
                                   
                                    //destRow[17] = tot_employ.Rows[0][17];
                                    //destRow[18] = tot_employ.Rows[0][18];
                                    //destRow[19] = tot_employ.Rows[0][19];
                                    destRow[20] = tot_employ.Rows[0][20];
                                    destRow[21] = tot_employ.Rows[0][21];
                                    destRow[22] = tot_employ.Rows[0][22];
                                    destRow[23] = tot_employ.Rows[0][23];
                                    destRow[24] = tot_employ.Rows[0][24];
                                    destRow[25] = tot_employ.Rows[0][25];
                                    //destRow[26] = tot_employ.Rows[0][26];
                                    destRow[27] = tot_employ.Rows[0][27];
                                    destRow[28] = tot_employ.Rows[0][28];
                                    destRow[29] = tot_employ.Rows[0][29];
                                    destRow[30] = tot_employ.Rows[0][30];
                                    destRow[31] = tot_employ.Rows[0][31];
                                    destRow[32] = tot_employ.Rows[0][32];
                                    destRow[33] = tot_employ.Rows[0][33];
                                    destRow[34] = tot_employ.Rows[0][34];

                                    destRow[35] = tot_employ.Rows[0][35];
                                    destRow[36] = tot_employ.Rows[0][36];
                                    destRow[37] = tot_employ.Rows[0][37];
                                    destRow[38] = tot_employ.Rows[0][38];

                                    destRow["IsService"] = tot_employ.Rows[0]["IsService"];
                                    destRow["designation"] = Ord.Rows[rw_ord]["OCHARGES"];
                                    destRow["mis3"] = Convert.ToString(Ord.Rows[rw_ord]["SAC"]);
                                    if (strBillFormatNo == "1")
                                    {
                                        destRow["NoOfPersonnel"] = Ord.Rows[rw_ord]["OQty"];//tot_employ.Rows[0]["NoOfPersonnel"];
                                        destRow["Attendance"] = Convert.ToDouble(Ord.Rows[rw_ord]["OQty"]).ToString("0");
                                    }
                                    else
                                    {
                                        destRow["NoOfPersonnel"] = Ord.Rows[rw_ord]["OQty"];//tot_employ.Rows[0]["NoOfPersonnel"];
                                        destRow["Attendance"] = Ord.Rows[rw_ord]["OAttend"];
                                    }
                                    destRow["ServiceAmount"] = tot_employ.Rows[0]["ServiceAmount"];
                                    destRow["BILLAMT"] = Ord.Rows[rw_ord]["OAMT"];
                                    destRow["Rate"] = Ord.Rows[rw_ord]["ORate"];//tot_employ.Rows[0][16];
                                    destRow["Dtl_id"] = (rw_ord + 1).ToString();// tot_employ.Rows[0]["Dtl_id"];
                                    destRow["rmrks"] = tot_employ.Rows[0]["rmrks"];
                                    destRow["phone"] = tot_employ.Rows[0]["phone"];
                                    destRow["duedate"] = tot_employ.Rows[0]["duedate"];
                                   
                                    destRow["TotAMT"] = tot_employ.Rows[0]["TotAMT"];
                                    destRow["authsign"] = tot_employ.Rows[0]["authsign"];
                                    destRow["Cmpimage"] = tot_employ.Rows[0]["Cmpimage"];
                                    tot_employ.Rows.Add(destRow);
                                }
                                else
                                {


                                    tot_employ.Rows[0]["designation"] = Ord.Rows[rw_ord]["OCHARGES"];
                                    // destRow["designation"] = Ord.Rows[rw_ord]["OCHARGES"];
                                    tot_employ.Rows[0]["NoOfPersonnel"] = Ord.Rows[rw_ord]["OQty"];
                                    tot_employ.Rows[0]["Attendance"] = Ord.Rows[rw_ord]["OAttend"];
                                    // destRow["Attendance"] = Ord.Rows[rw_ord]["OQty"];//tot_employ.Rows[0][11];

                                    //  tot_employ.Rows[0]["ServiceAmount"] = Ord.Rows[rw_ord]["ServiceAmount"];
                                    //destRow["ServiceAmount"] = tot_employ.Rows[0]["ServiceAmount"];

                                    tot_employ.Rows[0]["BILLAMT"] = Ord.Rows[rw_ord]["OAMT"];
                                    //destRow["BILLAMT"] = Ord.Rows[rw_ord]["OAMT"];

                                    tot_employ.Rows[0]["mis3"] = Ord.Rows[rw_ord]["SAC"];

                                    tot_employ.Rows[0]["Rate"] = Ord.Rows[rw_ord]["ORate"];
                                    //destRow["Rate"] = Ord.Rows[rw_ord]["ORate"];//tot_employ.Rows[0][16];
                                    tot_employ.Rows[0]["Dtl_id"] = (rw_ord + 1).ToString();// tot_employ.Rows[0]["Dtl_id"];
                                    count_payBillD = 1;
                                }
                            }


                        }

                        //  tot_employ_main.Merge(tot_employ);

                        Ord = clsDataAccess.RunQDTbl("Select ScPer,ScAmt,(select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) as 'SAC' from paybill d where IsSC='True' and BILLNO in (" + billcode + ")");

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


                            // +" " + Ord.Rows[rw_ord]["rmrks"];
                            destRow[9] = tot_employ.Rows[0][9];
                            destRow[10] = tot_employ.Rows[0][10];
                            destRow[11] = tot_employ.Rows[0][11];
                            destRow[12] = tot_employ.Rows[0][12];
                            //destRow[13] = tot_employ.Rows[0][13];
                            //destRow[14] = tot_employ.Rows[0][14];
                            destRow[15] = tot_employ.Rows[0][15];

                            //destRow[17] = tot_employ.Rows[0][17];
                            //destRow[18] = tot_employ.Rows[0][18];
                            //destRow[19] = tot_employ.Rows[0][19];
                            destRow[20] = tot_employ.Rows[0][20];
                            destRow[21] = tot_employ.Rows[0][21];
                            destRow[22] = "0";// tot_employ.Rows[0][22];
                            destRow[23] = tot_employ.Rows[0][23];
                            destRow[24] = tot_employ.Rows[0][24];
                            destRow[25] = tot_employ.Rows[0][25];
                            //destRow[26] = tot_employ.Rows[0][26];
                            destRow[27] = tot_employ.Rows[0][27];
                            destRow[28] = tot_employ.Rows[0][28];
                            destRow[29] = "";//tot_employ.Rows[0][29];
                            destRow[30] = tot_employ.Rows[0][30];
                            destRow[31] = tot_employ.Rows[0][31];
                            destRow[32] = tot_employ.Rows[0][32];
                            destRow[33] = tot_employ.Rows[0][33];
                            destRow[34] = tot_employ.Rows[0][34];

                            destRow[35] = tot_employ.Rows[0][35];
                            destRow[36] = tot_employ.Rows[0][36];
                            destRow[37] = tot_employ.Rows[0][37];
                            destRow[38] = tot_employ.Rows[0][38];

                            destRow["Session"] = tot_employ.Rows[0]["Session"];
                            destRow["TotAmt"] = tot_employ.Rows[0]["TotAmt"];
                            destRow["IsService"] = tot_employ.Rows[0]["IsService"];
                            destRow["designation"] = "Service Charges @ " + Ord.Rows[rw_ord]["SCPer"] + " %";
                            destRow["mis3"] = Convert.ToString(Ord.Rows[rw_ord]["SAC"]);

                            destRow["IsService"] = tot_employ.Rows[0]["IsService"];
                            destRow["Attendance"] = "";//tot_employ.Rows[0][11];
                            destRow["ServiceAmount"] = tot_employ.Rows[0]["ServiceAmount"];
                            destRow["BILLAMT"] = Ord.Rows[rw_ord]["ScAmt"];

                            destRow["Rate"] = 0;
                            //destRow["rmrks"] = tot_employ.Rows[0]["rmrks"];
                            destRow["phone"] = tot_employ.Rows[0]["phone"];
                            destRow["duedate"] = tot_employ.Rows[0]["duedate"];
                            destRow["NoOfPersonnel"] = 0;//tot_employ.Rows[0]["NoOfPersonnel"];

                            destRow["authsign"] = tot_employ.Rows[0]["authsign"];
                            destRow["Cmpimage"] = tot_employ.Rows[0]["Cmpimage"];
                            
                            tot_employ.Rows.Add(destRow);

                        }
                    }
                    else if (dtLocWiseChk.Rows[0][0].ToString() == "0" && dtLocWiseChk.Rows[0][2].ToString() != "")
                    {
                        strssql = "";
                        if (count_payBillD > 0)
                        {
                            strssql = strssql + " select h.BILLNO,CONVERT(VARCHAR(10),h.BILLDATE,103) as BILLDATE,CONVERT(VARCHAR(10),h.BILLDATE,103) as BILLDATE,CONVERT(VARCHAR(10),h.DUEDATE,103) as duedate,(select c.co_name from Company c where c.CO_CODE=h.Comany_id ) as 'coname',";
                            strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=h.Comany_id ) as 'Add1',(select distinct (case when ltrim(rtrim(b.GSTINNO))!='' then ' GST No.: '+b.GSTINNO else '' end) from Branch b where b.gcode=h.comany_id)as 'Add2',(select c.CO_ADD1  from Company c where c.CO_CODE=h.Comany_id ) as 'Add3',(select distinct BRNCH_TELE1 from Branch B where B.GCODE=h.Comany_id ) as 'phone',";
                            strssql = strssql + "(select distinct Website from Branch b where b.gcode=h.comany_id )as 'Website' ,(select distinct Email from Branch b where b.gcode=h.comany_id) as 'Email',";
                            strssql = strssql + " (select Location_Name from tbl_Emp_Location where Location_ID=h.Location_ID ) as 'locname','" + monthdisp + "' as Month,h.Session,(CASE WHEN h.isRound = 'True' THEN Round((h.TotAMT), 0) ELSE (h.TotAMT) END)  as 'TotAMT' ,h.IsService,h.ServiceAmount,";
                            strssql = strssql + " d.Attendance ,d.BILLAMT,d.Dtl_id ,d.Hour,d.MonthDays,d.RATE,((select e.DesignationName  from tbl_Employee_DesignationMaster e where e.SlNo=d.desig_ID )  + (CASE WHEN H.btype=1 THEN ' [ GST: ' + CAST(D.GstPer as nvarchar(max)) + ' %  Rs. '+CAST(d.Gst as nvarchar(max))+' ]' else '' end) +  ' ' + CAST( CASE WHEN d.rmrks<>'' then d.rmrks else '' END as nvarchar(max)))+ '['+(select Location_Name from tbl_Emp_Location where Location_ID=d.Location_ID )+']' as 'designation',d.NoOfPersonnel";
                            //strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )) as 'ClientName'"; //(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )
                            strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=h.[Cliant_ID]) as 'ClientName'"; //(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )
                            strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=h.[Cliant_ID] ) as 'ClientCity'";
                            strssql = strssql + " ,(select 'GSTIN NO. : '+c.GSTINNO+', State Code-'+c.Client_State   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ) as 'Contract_Person'";
                            strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ))+','+(SELECT Upper(Country_Name) FROM Country where Country_CODE=(select c.Country  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) )) AS mis1";
                            try
                            {
                                strssql = strssql + " ,'' as 'Contract_No'";
                                strssql = strssql + " ,(select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=h.[Cliant_ID] ) AS mis2,";

                            }
                            catch
                            {
                                strssql = strssql + " ,'' as 'Contract_No'";
                                strssql = strssql + " ,(select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ) AS mis2,";
                            }
                            //Added by dwipraj dutta 21082017                                                                                                                 //Added by dwipraj 041826072017                         
                            strssql = strssql + " CAST(CASE WHEN d.SAC is null then ' ' ELSE (select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) END as varchar(50)) AS mis3,'' AS mis4,'" + st_Desc + "' AS mis5,'' AS mis6,'' AS mis7,h.IsScAdd AS mis9,h.isRound AS mis10,h.isGST as mis8,(SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "') as Cmpimage,(select " + sign + " from Company where GCODE='" + Company_id.ToString() + "') as authsign,'( ORIGINAL / DUPLICATE / TRIPLICATE )' as rmrks";

                            strssql = strssql + " from paybill h inner join (select pbd.Month,'' as Dtl_id,sum(cast(pbd.Attendance as numeric(18,2))) as 'Attendance',pbd.Hour,pbd.MonthDays,SUM(pbd.BILLAMT) as BILLAMT,pbd.RATE,pbd.desig_ID,pbd.rmrks,pbd.SAC,pbd.BILLNO,pbd.NoOfPersonnel,pbd.Location_ID from paybillD pbd group by pbd.RATE,pbd.Month,pbd.Hour,pbd.MonthDays,pbd.desig_ID,pbd.rmrks,pbd.SAC,pbd.BILLNO,pbd.RATE,pbd.NoOfPersonnel,pbd.Location_ID) d on h.BILLNO=d.BILLNO";
                            strssql = strssql + " where h.Session='" + cmbYear.Text + "' and d.Month ='" + month + "'";
                            //strssql = strssql + " and h.Location_ID = '" + Location_id + "' and h.Comany_id='" + Company_id + "'";
                            strssql = strssql + " and (h.Comany_id='" + Company_id + "')";
                        }
                        if (checkBox1.Checked == false)
                        {
                            strssql = strssql + " and h.BILLNO in (" + billcode.Trim() + ") ";
                        }

                        tot_employ = clsDataAccess.RunQDTbl(strssql);
                        //  DataRow destRow= new DataRow();
                        DataTable dtimage = clsDataAccess.RunQDTbl("SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "' ");
                        DataTable Ord = clsDataAccess.RunQDTbl("Select (case when IncGst=1 then OCHARGES+' *' else OCHARGES end ) as OCHARGES,ORate,OQty,OAMT,BILLNO,(select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) as 'SAC',IncGst,[OAttend] from paybillO d where BILLNO in (" + billcode.Trim() + ") ");

                        for (int rw_ord = 0; rw_ord < Ord.Rows.Count; rw_ord++)
                        {
                            if (Convert.ToBoolean(Ord.Rows[rw_ord]["IncGst"]) == true)
                            {
                                tc = "( * ) non GST items";
                            }

                            DataRow destRow = tot_employ.NewRow();
                            if (tot_employ.Rows.Count > 0)
                            {
                                if (count_payBillD > 0)
                                {
                                    destRow[0] = tot_employ.Rows[0][0];
                                    destRow[1] = tot_employ.Rows[0][1];
                                    destRow[2] = tot_employ.Rows[0][2];
                                    destRow[3] = tot_employ.Rows[0][3];
                                    destRow[4] = tot_employ.Rows[0][4];
                                    destRow[5] = tot_employ.Rows[0][5];
                                    destRow[6] = tot_employ.Rows[0][6];
                                    destRow[7] = tot_employ.Rows[0][7];
                                    destRow[8] = tot_employ.Rows[0][8];


                                    // +" " + Ord.Rows[rw_ord]["rmrks"];
                                    destRow[9] = tot_employ.Rows[0][9];
                                    destRow[10] = tot_employ.Rows[0][10];
                                    destRow[11] = tot_employ.Rows[0][11];
                                    destRow[12] = tot_employ.Rows[0][12];
                                    //destRow[13] = tot_employ.Rows[0][13];
                                    //destRow[14] = tot_employ.Rows[0][14];
                                    destRow[15] = tot_employ.Rows[0][15];

                                    //destRow[17] = tot_employ.Rows[0][17];
                                    //destRow[18] = tot_employ.Rows[0][18];
                                    //destRow[19] = tot_employ.Rows[0][19];
                                    destRow[20] = tot_employ.Rows[0][20];
                                    destRow[21] = tot_employ.Rows[0][21];
                                    destRow[22] = tot_employ.Rows[0][22];
                                    destRow[23] = tot_employ.Rows[0][23];
                                    destRow[24] = tot_employ.Rows[0][24];
                                    destRow[25] = tot_employ.Rows[0][25];
                                    //destRow[26] = tot_employ.Rows[0][26];
                                    destRow[27] = tot_employ.Rows[0][27];
                                    destRow[28] = tot_employ.Rows[0][28];
                                    destRow[29] = tot_employ.Rows[0][29];
                                    destRow[30] = tot_employ.Rows[0][30];
                                    destRow[31] = tot_employ.Rows[0][31];
                                    destRow[32] = tot_employ.Rows[0][32];
                                    destRow[33] = tot_employ.Rows[0][33];
                                    destRow[34] = tot_employ.Rows[0][34];

                                    destRow[35] = tot_employ.Rows[0][35];
                                    destRow[36] = tot_employ.Rows[0][36];
                                    destRow[37] = tot_employ.Rows[0][37];
                                    destRow[38] = tot_employ.Rows[0][38];

                                    destRow["IsService"] = tot_employ.Rows[0]["IsService"];
                                    destRow["designation"] = Ord.Rows[rw_ord]["OCHARGES"];
                                    destRow["mis3"] = Convert.ToString(Ord.Rows[rw_ord]["SAC"]);
                                    destRow["Attendance"] = Ord.Rows[0]["OAttend"];
                                    destRow["ServiceAmount"] = tot_employ.Rows[0]["ServiceAmount"];
                                    destRow["BILLAMT"] = Ord.Rows[rw_ord]["OAMT"];
                                    destRow["Rate"] = Ord.Rows[rw_ord]["ORate"];//tot_employ.Rows[0][16];
                                    destRow["Dtl_id"] = (rw_ord + 1).ToString();// tot_employ.Rows[0]["Dtl_id"];
                                    destRow["rmrks"] = tot_employ.Rows[0]["rmrks"];
                                    destRow["phone"] = tot_employ.Rows[0]["phone"];
                                    destRow["duedate"] = tot_employ.Rows[0]["duedate"];
                                    destRow["NoOfPersonnel"] = Ord.Rows[rw_ord]["OQty"];//tot_employ.Rows[0]["NoOfPersonnel"];
                                    destRow["TotAMT"] = tot_employ.Rows[0]["TotAMT"];

                                    destRow["authsign"] = tot_employ.Rows[0]["authsign"];
                                    destRow["Cmpimage"] = tot_employ.Rows[0]["Cmpimage"];

                                    tot_employ.Rows.Add(destRow);
                                }
                                else
                                {


                                    tot_employ.Rows[0]["designation"] = Ord.Rows[rw_ord]["OCHARGES"];
                                    // destRow["designation"] = Ord.Rows[rw_ord]["OCHARGES"];

                                    tot_employ.Rows[0]["Attendance"] = Ord.Rows[rw_ord]["OQty"];
                                    // destRow["Attendance"] = Ord.Rows[rw_ord]["OQty"];//tot_employ.Rows[0][11];

                                    //  tot_employ.Rows[0]["ServiceAmount"] = Ord.Rows[rw_ord]["ServiceAmount"];
                                    //destRow["ServiceAmount"] = tot_employ.Rows[0]["ServiceAmount"];

                                    tot_employ.Rows[0]["BILLAMT"] = Ord.Rows[rw_ord]["OAMT"];
                                    //destRow["BILLAMT"] = Ord.Rows[rw_ord]["OAMT"];

                                    tot_employ.Rows[0]["mis3"] = Ord.Rows[rw_ord]["SAC"];

                                    tot_employ.Rows[0]["Rate"] = Ord.Rows[rw_ord]["ORate"];
                                    //destRow["Rate"] = Ord.Rows[rw_ord]["ORate"];//tot_employ.Rows[0][16];
                                    tot_employ.Rows[0]["Dtl_id"] = (rw_ord + 1).ToString();// tot_employ.Rows[0]["Dtl_id"];
                                    count_payBillD = 1;
                                }
                            }
                        }

                        Ord = clsDataAccess.RunQDTbl("Select ScPer,ScAmt,(select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) as 'SAC' from paybill d where IsSC='True' and BILLNO in (" + billcode + ")");

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


                            // +" " + Ord.Rows[rw_ord]["rmrks"];
                            destRow[9] = tot_employ.Rows[0][9];
                            destRow[10] = tot_employ.Rows[0][10];
                            destRow[11] = tot_employ.Rows[0][11];
                            destRow[12] = tot_employ.Rows[0][12];
                            //destRow[13] = tot_employ.Rows[0][13];
                            //destRow[14] = tot_employ.Rows[0][14];
                            destRow[15] = tot_employ.Rows[0][15];

                            //destRow[17] = tot_employ.Rows[0][17];
                            //destRow[18] = tot_employ.Rows[0][18];
                            //destRow[19] = tot_employ.Rows[0][19];
                            destRow[20] = tot_employ.Rows[0][20];
                            destRow[21] = tot_employ.Rows[0][21];
                            destRow[22] = "0";// tot_employ.Rows[0][22];
                            destRow[23] = tot_employ.Rows[0][23];
                            destRow[24] = tot_employ.Rows[0][24];
                            destRow[25] = tot_employ.Rows[0][25];
                            //destRow[26] = tot_employ.Rows[0][26];
                            destRow[27] = tot_employ.Rows[0][27];
                            destRow[28] = tot_employ.Rows[0][28];
                            destRow[29] = "";//tot_employ.Rows[0][29];
                            destRow[30] = tot_employ.Rows[0][30];
                            destRow[31] = tot_employ.Rows[0][31];
                            destRow[32] = tot_employ.Rows[0][32];
                            destRow[33] = tot_employ.Rows[0][33];
                            destRow[34] = tot_employ.Rows[0][34];

                            destRow[35] = tot_employ.Rows[0][35];
                            destRow[36] = tot_employ.Rows[0][36];
                            destRow[37] = tot_employ.Rows[0][37];
                            destRow[38] = tot_employ.Rows[0][38];

                            destRow["Session"] = tot_employ.Rows[0]["Session"];
                            destRow["TotAmt"] = tot_employ.Rows[0]["TotAmt"];
                            destRow["IsService"] = tot_employ.Rows[0]["IsService"];
                            destRow["designation"] = "Service Charges @ " + Ord.Rows[rw_ord]["SCPer"] + " %";
                            destRow["mis3"] = Convert.ToString(Ord.Rows[rw_ord]["SAC"]);

                            destRow["IsService"] = tot_employ.Rows[0]["IsService"];
                            destRow["Attendance"] =0;//tot_employ.Rows[0][11];
                            destRow["ServiceAmount"] = tot_employ.Rows[0]["ServiceAmount"];
                            destRow["BILLAMT"] = Ord.Rows[rw_ord]["ScAmt"];

                            destRow["Rate"] = 0;
                            //destRow["rmrks"] = tot_employ.Rows[0]["rmrks"];
                            destRow["phone"] = tot_employ.Rows[0]["phone"];
                            destRow["duedate"] = tot_employ.Rows[0]["duedate"];
                            destRow["NoOfPersonnel"] = 0;//tot_employ.Rows[0]["NoOfPersonnel"];

                            destRow["authsign"] = tot_employ.Rows[0]["authsign"];
                            destRow["Cmpimage"] = tot_employ.Rows[0]["Cmpimage"];

                            tot_employ.Rows.Add(destRow);

                        }

                    }

                    tot_employ_main.Merge(tot_employ);

                    DataTable Ord1 = clsDataAccess.RunQDTbl("Select ScPer,ScAmt,(select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) as 'SAC' from paybill d where IsSC='True' and BILLNO in (" + billcode + ")");

                    for (int rw_ord = 0; rw_ord < Ord1.Rows.Count; rw_ord++)
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


                        // +" " + Ord.Rows[rw_ord]["rmrks"];
                        destRow[9] = tot_employ.Rows[0][9];
                        destRow[10] = tot_employ.Rows[0][10];
                        destRow[11] = tot_employ.Rows[0][11];
                        destRow[12] = tot_employ.Rows[0][12];
                        //destRow[13] = tot_employ.Rows[0][13];
                        //destRow[14] = tot_employ.Rows[0][14];
                        destRow[15] = tot_employ.Rows[0][15];

                        //destRow[17] = tot_employ.Rows[0][17];
                        //destRow[18] = tot_employ.Rows[0][18];
                        //destRow[19] = tot_employ.Rows[0][19];
                        destRow[20] = tot_employ.Rows[0][20];
                        destRow[21] = tot_employ.Rows[0][21];
                        destRow[22] = "0";// tot_employ.Rows[0][22];
                        destRow[23] = tot_employ.Rows[0][23];
                        destRow[24] = tot_employ.Rows[0][24];
                        destRow[25] = tot_employ.Rows[0][25];
                        //destRow[26] = tot_employ.Rows[0][26];
                        destRow[27] = tot_employ.Rows[0][27];
                        destRow[28] = tot_employ.Rows[0][28];
                        destRow[29] = "";//tot_employ.Rows[0][29];
                        destRow[30] = tot_employ.Rows[0][30];
                        destRow[31] = tot_employ.Rows[0][31];
                        destRow[32] = tot_employ.Rows[0][32];
                        destRow[33] = tot_employ.Rows[0][33];
                        destRow[34] = tot_employ.Rows[0][34];

                        destRow[35] = tot_employ.Rows[0][35];
                        destRow[36] = tot_employ.Rows[0][36];
                        destRow[37] = tot_employ.Rows[0][37];
                        destRow[38] = tot_employ.Rows[0][38];

                        destRow["Session"] = tot_employ.Rows[0]["Session"];
                        destRow["TotAmt"] = tot_employ.Rows[0]["TotAmt"];
                        destRow["IsService"] = tot_employ.Rows[0]["IsService"];
                        destRow["designation"] = "Service Charges @ " + Ord1.Rows[rw_ord]["SCPer"] + " %";
                        destRow["mis3"] = Convert.ToString(Ord1.Rows[rw_ord]["SAC"]);

                        destRow["IsService"] = tot_employ.Rows[0]["IsService"];
                        destRow["Attendance"] = "0";//tot_employ.Rows[0][11];
                        destRow["ServiceAmount"] = tot_employ.Rows[0]["ServiceAmount"];
                        destRow["BILLAMT"] = Ord1.Rows[rw_ord]["ScAmt"];

                        destRow["Rate"] = 0;
                        //destRow["rmrks"] = tot_employ.Rows[0]["rmrks"];
                        destRow["phone"] = tot_employ.Rows[0]["phone"];
                        destRow["duedate"] = tot_employ.Rows[0]["duedate"];
                        destRow["NoOfPersonnel"] = 0;//tot_employ.Rows[0]["NoOfPersonnel"];

                        destRow["authsign"] = tot_employ.Rows[0]["authsign"];
                        destRow["Cmpimage"] = tot_employ.Rows[0]["Cmpimage"];

                        tot_employ.Rows.Add(destRow);

                    }
                   
                }
                IsST = clsDataAccess.GetresultS("Select IsService from paybill where BILLNO in (" + billcode + ")");
                if (IsST == "True")
                {
                    isScAdd = clsDataAccess.GetresultS("Select IsScAdd from paybill where BILLNO in (" + billcode + ")");
                }
                else
                {
                    isScAdd = "False";
                }

            }
           
           /* DataTable dtTax = clsDataAccess.RunQDTbl("select stname,stper from paybillst");
            string[] artax=new string[dtTax.Rows.Count];
            for (int i = 0; i < artax.Length; i++)
            {
                string sertax = dtTax.Rows[i][0].ToString();
                string otax = dtTax.Rows[i][1].ToString();

            }*/
           // ds.Tables[0].TableName = "taxrpt";
          
             
            ds.Tables.Add(tot_employ_main);
            ds.Tables[0].TableName = "Bill";
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

        //Following method added by dwipraj dutta 010920170424
        private void Retrive_Data_SingleDesignation_Dtl()
        {
            string[] blno = Item_Code.Split(',');
            DataTable dtBillDesignationDtl = new DataTable("");
            DataTable dtBillDesignationDtl_main = new DataTable("");
            foreach (string billcode in blno)
            {
                string sqlGetBillingType = "select pbd.[Location_ID],(select dm.DesignationName from tbl_Employee_DesignationMaster dm where dm.SlNo = pbd.Designation_Id) as 'designation' from paybill pbd where pbd.[BILLNO] = " + billcode;
                DataTable dtGetBillingType = clsDataAccess.RunQDTbl(sqlGetBillingType);

                if (dtGetBillingType.Rows[0][0].ToString() == "0" && dtGetBillingType.Rows[0][1].ToString() != "")
                {
                    string sql = "select cast(ROW_NUMBER() over(order by pbd.Location_ID) as int)as 'slno',(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pbd.Location_ID) as 'locname',(select lm.usrdfinLoc_Id from tbl_Emp_Location lm where lm.Location_ID = pbd.Location_ID) as 'mis1',(select lm.Location_Address from tbl_Emp_Location lm where lm.Location_ID = pbd.Location_ID) as 'locaddress',(select dm.DesignationName from tbl_Employee_DesignationMaster dm where dm.SlNo = pbd.desig_ID) as 'designation',(select odm.FromDate from tbl_Employee_OrderDetails odm where odm.Order_Name=pbd.ref_order_no) as 'odrsdate',pbd.Attendance as 'attendence',pbd.RATE as 'ratepm'" +
                ",(select COUNT(*) from tbl_Employee_Attend empa where empa.LOcation_ID=pbd.Location_ID and empa.Desgid=pbd.desig_ID and empa.Season=pbd.Session and empa.Month = (select ( CASE pbd.Month " +
                "WHEN 'January' THEN '1'+'/'+SUBSTRING(pbd.Session,6,4) " +
                "WHEN 'February' THEN '2'+'/'+SUBSTRING(pbd.Session,6,4) " +
                "WHEN 'March' THEN '3'+'/'+SUBSTRING(pbd.Session,6,4) " +
                "WHEN 'April' THEN '4'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'May' THEN '5'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'June' THEN '6'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'July' THEN '7'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'August' THEN '8'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'September' THEN '9'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'October' THEN '10'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'November' THEN '11'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'December' THEN '12'+'/'+SUBSTRING(pbd.Session,1,4) " +
              "END ))) as 'head' " +
              ",(select STUFF((SELECT ', ' + (select em.FirstName+' ' + em.MiddleName + ' ' + em.LastName from tbl_Employee_Mast em where em.ID = rf.ID) " +
             "FROM tbl_Employee_Attend rf " +
             "WHERE rf.LOcation_ID=pbd.Location_ID and rf.Desgid=pbd.desig_ID and rf.Season=pbd.Session and rf.Month = (select ( CASE pbd.Month " +
                "WHEN 'January' THEN '1'+'/'+SUBSTRING(pbd.Session,6,4) " +
                "WHEN 'February' THEN '2'+'/'+SUBSTRING(pbd.Session,6,4) " +
                "WHEN 'March' THEN '3'+'/'+SUBSTRING(pbd.Session,6,4) " +
                "WHEN 'April' THEN '4'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'May' THEN '5'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'June' THEN '6'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'July' THEN '7'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'August' THEN '8'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'September' THEN '9'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'October' THEN '10'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'November' THEN '11'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'December' THEN '12'+'/'+SUBSTRING(pbd.Session,1,4) " +
              "END )) " +
             "FOR XML PATH('')),1,2,' ') from tbl_Employee_Attend empa where empa.LOcation_ID=pbd.Location_ID and empa.Desgid=pbd.desig_ID and empa.Season=pbd.Session and empa.Month = (select ( CASE pbd.Month " +
                "WHEN 'January' THEN '1'+'/'+SUBSTRING(pbd.Session,6,4) " +
                "WHEN 'February' THEN '2'+'/'+SUBSTRING(pbd.Session,6,4) " +
                "WHEN 'March' THEN '3'+'/'+SUBSTRING(pbd.Session,6,4) " +
                "WHEN 'April' THEN '4'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'May' THEN '5'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'June' THEN '6'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'July' THEN '7'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'August' THEN '8'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'September' THEN '9'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'October' THEN '10'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'November' THEN '11'+'/'+SUBSTRING(pbd.Session,1,4) " +
                "WHEN 'December' THEN '12'+'/'+SUBSTRING(pbd.Session,1,4) " +
              "END )) group by empa.LOcation_ID) as 'mis2'" +
              ",pbd.BILLAMT as 'tamt','' as mis3,'' as mis4,'' as mis5,'' as mis6,'' as mis7,'' as mis8,'' as mis9,'' as mis10 " +
              "from paybillD pbd where pbd.BILLNO = " + billcode ;

                    dtBillDesignationDtl = clsDataAccess.RunQDTbl(sql);
                }
                dtBillDesignationDtl_main.Merge(dtBillDesignationDtl);
            }
            dtMainDesgDt = dtBillDesignationDtl_main;
            
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
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    string month = dateTimePicker1.Text; //clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

                    // string sqlstmnt = "Select distinct s.BILLNO as 'BillNo',s.BILLNO as 'BillNo',s.BILLDATE as 'BillDate' from paybilld s where s.Month='" + month + "' and s.Session ='" + cmbYear.Text + "' and company_ID = '" + Company_id + "' and s.Location_id= '" + Location_id + "'";
                    if(client_id.Trim() == "")
                        client_id = Client_id.ToString();
                    string sqlstmnt = "Select distinct s.BILLNO as 'BillNo',s.BILLNO as 'BillNo',s.BILLDATE as 'BillDate' from paybill s where s.Month='" + month + "' and s.Session ='" + cmbYear.Text + "' and comany_ID = '" + Company_id + "' and cliant_id='" + client_id + "' and s.BillStatus = 'ACTIVE' and  s.[Location_ID] = " + Location_id;
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
                            if (Item_Code == "''") { Item_Code = "'" + getcode_item[i].ToString() + "'"; }
                            else
                            {
                                Item_Code = Item_Code + "," + "'" + getcode_item[i].ToString() + "'";
                            }
                        }

                    }
                }
                catch { }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    string month = dateTimePicker1.Text; //clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

                    // string sqlstmnt = "Select distinct s.BILLNO as 'BillNo',s.BILLNO as 'BillNo',s.BILLDATE as 'BillDate' from paybilld s where s.Month='" + month + "' and s.Session ='" + cmbYear.Text + "' and company_ID = '" + Company_id + "' and s.Location_id= '" + Location_id + "'";
                    string sqlstmnt = "Select distinct s.BILLNO as 'BillNo',s.BILLNO as 'BillNo',s.BILLDATE as 'BillDate' from paybill s where s.Month='" + month + "' and s.Session ='" + cmbYear.Text + "' and comany_ID = '" + Company_id + "' and s.BillStatus = 'ACTIVE'  and [Location_ID] in (" + strLocList + ")";
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
                            if (Item_Code == "''") { Item_Code = "'" + getcode_item[i].ToString() + "'"; }
                            else
                            {
                                Item_Code = Item_Code + "," + "'" + getcode_item[i].ToString() + "'";
                            }
                        }

                    }
                }
                catch { }
            }
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
        {  lblEnclosure.Text = "";
            lblprevbal.Text = "0";
            try
            {
                string s = "";
                cmbLocation.Text = "";

              //  s = " select l.Location_Name,l.Location_ID from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID='" + Company_id + "'";
                s = "SELECT l.Location_Name,l.Location_ID,l.ClientID from (SELECT l.Location_Name,l.Location_ID,Cliant_ID as ClientID FROM tbl_Emp_Location AS l where l.Cliant_ID = "+Client_id+") as l INNER JOIN Companywiseid_Relation AS r ON l.Location_ID = r.Location_ID WHERE (r.Company_ID='" + Company_id + "')";
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
            string esi="", pf="", pan="", streg="", ptax="",gstin="";
            DataTable dtt = clsDataAccess.RunQDTbl("SELECT * FROM Companywiseid_Relation where (Company_ID=" + Company_id + ") and (Location_ID ='" + Location_id + "')");
            DataTable gstinGet = clsDataAccess.RunQDTbl("select GSTINNO from Branch where GCODE = '"+Company_id+"'");
            client_id = clsDataAccess.GetresultS("select Cliant_id from tbl_Emp_Location where Location_ID='"+ Location_id +"'");
            if (dtt.Rows.Count > 0)
            {
                if (dtt.Rows[0]["Ptax_Code"] != "")
                {
                    ptax="P.TAX Reg no. : " + (dtt.Rows[0]["Ptax_Code"]);
                }
                if (dtt.Rows[0]["StReg_Code"] != "")
                {
                    streg = "Service Tax Reg no. : " + (dtt.Rows[0]["StReg_Code"]);
                }
                if (dtt.Rows[0]["Pan_Code"] != "")
                {
                    pan = "PAN : " + (dtt.Rows[0]["Pan_Code"]);
                }
                if (dtt.Rows[0]["PF_Code"] != "")
                {
                    pf = "PF Code : " + (dtt.Rows[0]["PF_Code"]);
                }
                if (dtt.Rows[0]["Esi_Code"] != "")
                {
                    esi = "ESI Code : " + (dtt.Rows[0]["Esi_Code"]);
                }

                if (gstinGet.Rows[0]["GSTINNO"] != "")
                {
                    gstin = "GSTIN Code : "+(gstinGet.Rows[0]["GSTINNO"]);
                }

                if (setting_type == "type 2")
                {
                    txt_Odetails.Clear();
                    txt_Odetails.Text = gstin + "\r\n" + streg + "\r\n" + pf + "    " + esi + "\r\n" + ptax + "\r\n" + pan;
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            int year = dateTimePicker1.Value.Year;
            

            //calculateAmt();
           // SessionValueCheckAndAssignNoOfDays();
        }

        private void SessionValueCheckAndAssignNoOfDays()
        {
            int NumberOfDays = DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);
            //  txtDays.Text = NumberOfDays.ToString();

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

        private void bnkDtl_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select bank,acno from Branch where ltrim(rtrim(bank))!='' and (gcode='" + Company_id + "')");
            if (dt.Rows.Count > 1)
            {
                bnkDtl.LookUpTable = dt;
                bnkDtl.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                bnkDtl.Text = dt.Rows[0]["Bank"].ToString();
                bnkDtl.ReturnValue = dt.Rows[0]["acno"].ToString();
                SelectedACNo = Convert.ToString(bnkDtl.ReturnValue);
            }
        }

        private void bnkDtl_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            SelectedACNo = Convert.ToString(bnkDtl.ReturnValue);
        }

        private void btnSubReport_Click(object sender, EventArgs e)
        {
            MidasReport.Form1 opening = new MidasReport.Form1();
            string[] billnos = Item_Code.Split(',');
            Boolean flagDesgDtl = false;
            string BillDesc = "";
            string LocType = "";
            string totamt = "";
            foreach (string billcode in billnos)
            {
                string sqlGetBillingType = "select pbd.[Location_ID],Month,cast(case when Designation_Id is null then '' when Designation_Id is not null then (select dm.DesignationName from tbl_Employee_DesignationMaster dm where pbd.Designation_Id = dm.SlNo) end as varchar(50)) as 'Desg',(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=pbd.[Cliant_ID] ) as 'clientname',pbd.TotAMT from paybill pbd where pbd.[BILLNO] = " + billcode;
                DataTable dtGetBillingType = clsDataAccess.RunQDTbl(sqlGetBillingType);
                if (dtGetBillingType.Rows[0]["Location_ID"].ToString() == "0" && dtGetBillingType.Rows[0]["Desg"].ToString() != "")
                {
                    DataTable dtGetLocationType = clsDataAccess.RunQDTbl("select distinct d.LocType from (select (select lm.Location_Type from tbl_Emp_Location lm where lm.Location_ID = pbd.Location_ID) as 'LocType' from paybillD pbd where pbd.BILLNO = "+billcode+") d");
                    flagDesgDtl = true;
                    Retrive_Data_SingleDesignation_Dtl();
                    for (int i = 0; i < dtGetLocationType.Rows.Count; i++)
                    {
                        if (dtGetLocationType.Rows[i]["LocType"].ToString().Trim() != "")
                        {
                            LocType = LocType + dtGetLocationType.Rows[i]["LocType"].ToString().Trim() + ", ";
                        }
                    }
                    LocType = LocType.Substring(0,LocType.Length-2);
                    BillDesc = "Bill for " + dtGetBillingType.Rows[0]["Desg"] + " jobs of " + dtGetBillingType.Rows[0]["clientname"] + " " + LocType + " for " + dtGetBillingType.Rows[0]["Month"] + "against Bill no. " + billcode;
                    totamt = String.Format("{0:N}",Convert.ToDouble(dtGetBillingType.Rows[0]["TotAMT"].ToString().Trim()));
                    break;
                }

            }
            if (flagDesgDtl)
            {
                opening.desgWiseBillPrint(dtMainDesgDt, BillDesc,totamt);
                opening.ShowDialog();
            }
            else
                EDPMessageBox.EDPMessage.Show("Selected Bills have no sub Report to show.");
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            { 
                case 0:
                    multiLocationSelection.Visible = false;
                    cmbLocation.Visible = true;
                    
                    bnkDtl.Visible = true;
                    break;
                case 1:
                    multiLocationSelection.Visible = true;
                    cmbLocation.Visible = false;
                    
                    bnkDtl.Visible = false;
                    break;
            
            }
        }
//have to code the following part...
        private void multiLocationSelection_Click(object sender, EventArgs e)
        {
            try
            {
                string month = dateTimePicker1.Text; //clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

                // string sqlstmnt = "Select distinct s.BILLNO as 'BillNo',s.BILLNO as 'BillNo',s.BILLDATE as 'BillDate' from paybilld s where s.Month='" + month + "' and s.Session ='" + cmbYear.Text + "' and company_ID = '" + Company_id + "' and s.Location_id= '" + Location_id + "'";
                string sqlstmnt = "select lm.Location_ID,lm.Location_Name,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Cliant_ID='" + cmbClient.ReturnValue + "' order by lm.Location_Name asc";
                EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Bill", "Select Bill", 0, "CMPN", 0);

                LocList.Clear();
                LocList = EDPCommon.arr_mod;

                if (LocList.Count > 0)
                {
                    getLoc_item.Clear();
                    LocList = EDPCommon.arr_mod;
                    getLoc_item = EDPCommon.get_code;

                    strLocList = null;
                    strLocList = "''";

                    for (int i = 0; i <= LocList.Count - 1; i++)
                    {
                        if (strLocList == "''") { strLocList =LocList[i].ToString(); }
                        else
                        {
                            strLocList = strLocList + "," + LocList[i].ToString();
                        }
                    }

                }
            }
            catch { }
        }

        private void cmbClient_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void cmbClient_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select [Client_Name],[Client_id] from tbl_Employee_CliantMaster");
            if (dt.Rows.Count > 0)
            {
                cmbClient.LookUpTable = dt;
                cmbClient.ReturnIndex = 1;
                cmbLocation.Text = "";
            }
        }

        private void cmbClient_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbClient.ReturnValue) == true)
                Client_id = Convert.ToInt32(cmbClient.ReturnValue);
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            path = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath + "\\";
                lbl_path.Text = folderBrowserDialog1.SelectedPath + "\\";

                path = lbl_path.Text.Trim() + "\\Log" + System.DateTime.Now.Day + System.DateTime.Now.Month + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".txt";
                //lbl_load_msg.Text = "Please Wait..";
                //pnl_load.Visible = true;
                //locname = lbl_path.Text;
            }


            if (Item_Code.Trim() == "")
            {
                EDPMessageBox.EDPMessage.Show("Please select bill no first.");
                return;
            }
            string odetails = "", termCon = "", bill_type = "Tax Invoice", bl_type = "Invoice";

            DataTable dt8 = clsDataAccess.RunQDTbl("select * from paybillOD ");

            if (rdb_type_bill.Checked == true)
            {
                bill_type = "BILL";
                bl_type = "BILL";
            }
            else if (rdb_type_bos.Checked == true)
            {
                bill_type = "BILL OF SUPPLY";
                bl_type = "Bill of Supply";
            }
            else
            {
                bl_type = "INVOICE";
                bill_type = "TAX INVOICE";
            }

            if (dt8.Rows.Count == 0)
            {
                if (txt_Odetails.Text == "" || Txt_TermsConditions.Text == "")
                {
                    MessageBox.Show("Other Details or Terms and Conditions is empty, Please Check", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // bool rs = clsDataAccess.RunNQwithStatus("insert into paybillOD values('" + txt_Odetails.Text + "','" + Txt_TermsConditions.Text + "')");
                odetails = txt_Odetails.Text;
                termCon = Txt_TermsConditions.Text;

            }
            else
            {
                //txt_Odetails.Text = dt8.Rows[0][0].ToString();
                //Txt_TermsConditions.Text = dt8.Rows[0][1].ToString();
                odetails = txt_Odetails.Text;
                termCon = Txt_TermsConditions.Text;
            }

            Retrive_DataESI();
            //if (billcode.Trim() == "")
            //{

            //}
            MidasReport.Form1 opening = new MidasReport.Form1();
            string range = "", mon = "", nar = "", coname = "";
            string[] dt_range;
            coname = ds.Tables[0].Rows[0]["coname"].ToString().Trim();
            if (ds.Tables[0].Rows[0]["Monthdays"].ToString().Trim().Contains("RANGE") == true)
            {
                //RANGE20-21
                //range
                mon = ds.Tables[0].Rows[0]["Month"].ToString();
                dt_range = ds.Tables[0].Rows[0]["Monthdays"].ToString().Replace("RANGE", "").Trim().Split('-');
                range = bl_type + " FOR THE PERIOD OF " + dt_range[0] + " " + (DateAndTime.DateAdd(DateInterval.Month, -1, Convert.ToDateTime("01/" + mon))).ToString("MMM-yyyy") + " TO " + dt_range[1] + " " + Convert.ToDateTime("01/" + mon).ToString("MMM-yyyy");
            }
            else
            {
                mon = ds.Tables[0].Rows[0]["Month"].ToString();
                range = bl_type + " FOR THE MONTH OF : " + mon;
            }
            nar = clsDataAccess.GetresultS("select GSTTYPE from Companywiseid_Relation where Company_ID=" + Company_id + " and Location_ID =" + Location_id);
            if (nar.ToUpper().Trim() == "REVERSE CHARGES")
            {
                nar = "Tax on Reverse Charge : Yes";
            }
            else
            {
                nar = "";
            }
            double tamt = 0, stamtp = 0;

            for (int ind = 0; ind < ds.Tables[0].Rows.Count; ind++)
            {
                try
                {
                    tamt = tamt + Convert.ToDouble(ds.Tables[0].Rows[ind]["BILLAMT"]);       //Changes made in this line 040820171011AM/
                }
                catch { }

            }

            if (chkBank.Checked == true)
            {
                BANK_DETAILS();
            }
            else
            {
                try
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["mis4"] = "";
                    }
                }
                catch { }
            }

            DataTable dtw, dts;

            double serper1 = 0, serper2 = 0;
            string serv1 = "", serva1 = "", serv2 = "", serva2 = "";
            
            try
            {
                serv1 = "";
                serv2 = "";
                string gsttype = "";
                Boolean flag = false;
                string[] blno = Item_Code.Split(',');
                foreach (string bill in blno)
                {
                    DataTable getGSTDetails = clsDataAccess.RunQDTbl("select Comany_id,Location_ID,isGST,ServiceAmount,ScAmt, (CASE WHEN isRound = 'True' THEN Round(TotAMT, 2) ELSE TotAmt END) AS TotAMT,isRound,IsService,GstPer from paybill where BILLNO = " + bill);
                    if (getGSTDetails.Rows.Count > 0)
                    {
                        string chk = getGSTDetails.Rows[0]["isGST"].ToString().Trim();
                        if (getGSTDetails.Rows[0]["isGST"].ToString().Trim() == "True")
                        {
                            flag = true;
                            DataTable getIGSTOrNot = clsDataAccess.RunQDTbl("select distinct (isNull((select crm.GSTTYPE from Companywiseid_Relation crm where crm.Location_ID = pbd.Location_ID and crm.Company_ID = pbd.Comany_id),'LOCAL'))  as 'GSTTYPE' from paybill pbd where pbd.BILLNO = " + bill);
                            if (getIGSTOrNot.Rows[0][0].ToString().Trim() == "LOCAL")
                            {
                                //DataTable setGstPer = clsDataAccess.RunQDTbl("select GSTPER from Branch where GCODE = '" + getGSTDetails.Rows[0]["Comany_id"] + "'");
                                DataTable setGstPer = clsDataAccess.RunQDTbl("select GSTPER from Branch where GCODE = '" + getGSTDetails.Rows[0]["Comany_id"] + "'");
                                //double totper = Convert.ToDouble(setGstPer.Rows[0][0]);
                                double totper = Convert.ToDouble(getGSTDetails.Rows[0]["GstPer"]);//Math.Round(100 * Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / (Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"]) + Convert.ToDouble(getGSTDetails.Rows[0]["ScAmt"])));
                                serper1 = totper / 2;
                                stamtp = tamt * Convert.ToDouble(serper1) / 100;

                                string roff = "", roff_val = "";
                                if (getGSTDetails.Rows[0]["isRound"].ToString() == "True")
                                {
                                    roff = "Round off";
                                    roff_val = Convert.ToString(string.Format("{0:N}", Math.Round(Math.Round(Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) + Convert.ToDouble(getGSTDetails.Rows[0]["SCAmt"]) + Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"])) - (Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) + Convert.ToDouble(getGSTDetails.Rows[0]["SCAmt"]) + Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"])), 2)));

                                    //Convert.ToString(string.Format("{0:N}", Math.Round((Convert.ToInt32(getGSTDetails.Rows[0]["ServiceAmount"]) + Convert.ToInt32(getGSTDetails.Rows[0]["TotAMT"])) - (Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) + Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"])), 2)));
                                }
                                else
                                {
                                    roff_val = "";
                                    roff = "";
                                }

                                serva1 = "ADD : " + Environment.NewLine + "SGST @" + serper1 + "%" + Environment.NewLine + "CGST @" + serper1 + "%" + Environment.NewLine + roff;
                                serva2 = Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + roff_val;
                                /*HAVE TO THINK THIS PART........
                                if (getGSTDetails.Rows[0]["isRound"].ToString().Trim() == "True")
                                {
                                    serva1 = "ADD : " + Environment.NewLine + "SGST @" + serper1 + "%" + Environment.NewLine + "Rounded off(+/-)" + Environment.NewLine + "CGST @" + serper1 + "%" + Environment.NewLine + "Rounded off(+/-)";
                                    serva2 = Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + string.Format("{0:N}", ((Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) - Math.Round(Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2))) + Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + string.Format("{0:N}", ((Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) - Math.Round(Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2)));
                                }
                                else
                                {
                                    serva1 = "ADD : " + Environment.NewLine + "SGST @" + serper1 + "%" + Environment.NewLine + "CGST @" + serper1 + "%";
                                    serva2 = Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) ;
                                }
                                 */
                            }
                            else
                            {
                                DataTable setGstPer = clsDataAccess.RunQDTbl("select GSTPER from Branch where GCODE = '" + getGSTDetails.Rows[0]["Comany_id"] + "'");

                                //serper1 = Convert.ToDouble(setGstPer.Rows[0][0]);
                                serper1 = Convert.ToDouble(getGSTDetails.Rows[0]["GstPer"]);// Math.Round(100 * Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / (Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"]) + Convert.ToDouble(getGSTDetails.Rows[0]["ScAmt"])));
                                stamtp = tamt * Convert.ToDouble(serper1) / 100;
                                serva1 = "ADD : " + Environment.NewLine + "IGST @" + serper1 + "%";
                                serva2 = Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]).ToString("0.00");//Math.Round(stamtp,2).ToString();
                                serva2 = Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(serva2));
                                if (getGSTDetails.Rows[0]["isRound"].ToString().Trim() == "True")
                                {
                                    double roffAmt = 0;//Math.Round(stamtp) - stamtp;
                                    string roff = "", roff_val = "";
                                    if (getGSTDetails.Rows[0]["isRound"].ToString() == "True")
                                    {
                                        roff = "Round off";
                                        roff_val = Convert.ToString(string.Format("{0:N}", Math.Round((Convert.ToInt32(getGSTDetails.Rows[0]["ServiceAmount"]) + Convert.ToInt32(getGSTDetails.Rows[0]["SCAmt"]) + Convert.ToInt32(getGSTDetails.Rows[0]["TotAMT"])) - (Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) + Convert.ToDouble(getGSTDetails.Rows[0]["SCAmt"]) + Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"])), 2)));


                                        roffAmt = Convert.ToDouble(roff_val);
                                    }
                                    else
                                    {
                                        roff_val = "0";
                                        roff = "";
                                        roffAmt = 0;
                                    }



                                    if (roffAmt > 0)
                                    {
                                        serva1 = serva1 + Environment.NewLine + roff;//"Rounded off(+/-)";
                                        serva2 = serva2 + Environment.NewLine + "+" + string.Format("{0:N}", roffAmt);
                                    }
                                    else if (roffAmt < 0)
                                    {
                                        serva1 = serva1 + Environment.NewLine + roff;//"Rounded off(+/-)";
                                        serva2 = serva2 + Environment.NewLine + string.Format("{0:N}", roffAmt);
                                    }
                                }
                            }
                        }

                        else if (getGSTDetails.Rows[0]["IsService"].ToString().Trim() == "True")
                        {
                            dtw = clsDataAccess.RunQDTbl("select stname,stper from paybillst");

                            for (int ind = 0; ind < dtw.Rows.Count; ind++)
                            {
                                //serv1 = edpcom.GetAmountFormat(0, 2);
                                serv1 = dtw.Rows[ind][0].ToString();
                                serper1 = Convert.ToDouble(dtw.Rows[ind][1]);
                                stamtp = tamt * Convert.ToDouble(serper1) / 100;
                                if (isScAdd == "False")
                                {
                                    serva2 = "";
                                    if (serva1 == "")
                                    {
                                        serva1 = serv1 + " @ " + Convert.ToString(serper1) + " %     Rs. " + Math.Round(stamtp, 2);
                                    }
                                    else
                                    {
                                        serva1 = serva1 + Environment.NewLine + serv1 + " @ " + Convert.ToString(serper1) + " %     Rs. " + Math.Round(stamtp, 2);
                                    }
                                }
                                else
                                {
                                    if (serva1 == "")
                                    {
                                        serva1 = "Add : " + serv1 + " @ " + Convert.ToString(serper1) + " %     ";
                                        serva2 = Math.Round(stamtp, 2).ToString();
                                    }
                                    else
                                    {
                                        serva1 = serva1 + Environment.NewLine + serv1 + " @ " + Convert.ToString(serper1) + " %     ";
                                        serva2 = serva2 + Environment.NewLine + Math.Round(stamtp, 2).ToString();
                                    }
                                }

                            }
                        }
                    }

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if ("'" + ds.Tables[0].Rows[i]["BILLNO"].ToString() + "'" == bill)
                        {
                            ds.Tables[0].Rows[i]["mis6"] = serva1;
                            ds.Tables[0].Rows[i]["mis7"] = serva2;
                        }
                    }

                }
                
            }
            catch
            {
                MessageBox.Show("Service Tax not assigned", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                serv1 = "";
            }
            serv1 = "";
            serv2 = "";
            // serva2 = "0";
            if (cbSaveNewOtherDetails.Checked)
                writeFile();

            if (lblNote.Text.Trim() != "")
            {
                onote = onote + Environment.NewLine + Environment.NewLine + lblNote.Text;
            }

            advertisement();
            if (chkHide_BillDetails.Checked == true)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    ds.Tables[0].Rows[i]["NoofPersonnel"] = 0;
                    ds.Tables[0].Rows[i]["Attendance"] = "0.00";
                    ds.Tables[0].Rows[i]["Rate"] = "0.00";

                }


            }
            string btc = clsDataAccess.ReturnValue("select BillTC from CompanyLimiter").Trim();
            switch (strBillFormatNo)
            {
                case "1":
                    if (btc == "1")
                    {
                        termsconditions = termCon;
                    }
                    else
                    {
                        termsconditions = "Cheque / DD/ Pay Order Should be in favour of <b>" + coname + "</b>\n\r" + termCon;
                    }
                    opening.paybillO_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, tc);
                    break;
                case "2":
                    if (btc == "1")
                    {
                        termsconditions = termCon;
                    }
                    else
                    {
                        termsconditions = "Cheque / DD/ Pay Order Should be in favour of <b>" + coname + "</b>\n\r" + termCon;
                    }
                    if (chkBlankHead.Checked == true)
                    {
                        opening.paybillO_Format1_blank_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, tc, bill_type, bl_type);
                    }
                    else
                    {
                        opening.paybillO_Format1_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, tc, bill_type, bl_type);
                    }
                    break;
                case "3":
                    if (btc == "1")
                    {
                        termsconditions = termCon;
                    }
                    else
                    {
                        termsconditions = "Cheque / DD/ Pay Order Should be in favour of <b>" + coname + "</b>\n\r" + termCon;
                    }
                    string val = "";
                    if (chkPrevBal.Checked == false) { val = "0"; } else { val = lblprevbal.Text; }

                    opening.paybillO_Format2_mail(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 3, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar, lbl_path.Text + "Invoice_" + Location_id + "_" + dateTimePicker1.Value.ToString("MMM_yyyy") + ".pdf");
                    
                    break;

                case "4":
                    //string val = "";
                    if (btc == "1")
                    {
                        termsconditions = termCon;
                    }
                    else
                    {
                        termsconditions = "Cheque / DD/ Pay Order Should be in favour of <b>" + coname + "</b>\n\r" + termCon;
                    }
                    if (chkPrevBal.Checked == false) { val = "0"; } else { val = lblprevbal.Text; }

                    opening.paybillO_Format3_mail(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 3, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar, lbl_path.Text + "Invoice_" + Location_id + "_" + dateTimePicker1.Value.ToString("MMM_yyyy") + ".pdf");
                    
                    break;

                case "6":
                    // string val = "";
                    termsconditions = termCon;
                    if (chkPrevBal.Checked == false) { val = "0"; } else { val = lblprevbal.Text; }

                    opening.paybillO_Format2_mail(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 3, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar, lbl_path.Text + "Invoice_" +Location_id + "_" + dateTimePicker1.Value.ToString("MMM_yyyy") + ".pdf");
                    
                    break;
            }

            backgroundWorker1.RunWorkerAsync();

            ds.Tables.Clear();
            ds.Dispose();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //if (ds.Tables[0].Rows.Count > 0)
            //{
                backgroundWorker1.ReportProgress(1);
            //}
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string strEmpName = "";

            if (!File.Exists(path))
            {
                //File.Create(path);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                using (var tw = new StreamWriter(fs))
                {
                    tw.WriteLine("#Company: " + cmbcompany.Text.Trim());
                    tw.WriteLine("#Version: " + edpcom.PBUILD_DATE.ToString("dd/MM/yyyy"));
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
            string ecode = "", title = "", ename = "", noMail = "1", off_email = "", off_email_1 = "", snd = "0";

            //progressBar1.Value = e.ProgressPercentage;
            //ind = (Convert.ToInt32(e.ProgressPercentage.ToString())); //+ " %";
            try
            {
               
                //noMail = dataGridView1.Rows[ind].Cells["col_nomail"].Value.ToString();
                off_email = txtTo.Text;
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

                        mm.From = new MailAddress(TxtEmail.Text, "HR<" + TxtEmail.Text + ">");
                        mm.Subject = "Invoice " +dateTimePicker1.Value.ToString("MMMM-yyyy");//System.DateTime.Now.ToString("MMM-yyyy");
                        mm.ReplyTo = new System.Net.Mail.MailAddress(TxtEmail.Text);


                        mm.IsBodyHtml = true;

                        mm.Body = "Sir / Madam, " + title + " " + ename + "," + Environment.NewLine + "\n<br /><br />Please find the attached Invoice below." + Environment.NewLine + " \n<br /><b> Thanks & Regards,<br/>" + txtSignature.Text + Environment.NewLine + "\n<br /><br /><html><div style='font-size:8px; font-family:Arial;'> This is a system generated mail</div></html>";
                        if (txtcc.Text.Trim() != "")
                        {
                            mm.CC.Add(txtcc.Text);
                        }
                        string fileName = Path.GetFileName(lbl_path.Text + "Invoice_" + Location_id + "_" + dateTimePicker1.Value.ToString("MMM_yyyy") + ".pdf");
                        if (File.Exists(lbl_path.Text + "Invoice_" + Location_id + "_" + dateTimePicker1.Value.ToString("MMM_yyyy") + ".pdf"))
                        {

                            mm.Attachments.Add(new Attachment(lbl_path.Text + "Invoice_" + Location_id + "_" + dateTimePicker1.Value.ToString("MMM_yyyy") + ".pdf"));
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
                           // lbl_load_msg.Text = ("Email sent." + ecode);
                            //lbl_load_msg.Text = "Please Wait... " + lbl_load_msg.Text;
                            sq1 = ("INSERT INTO mail_log(mdate, uid, mto, cc, bcc, subject, month)VALUES (GETDATE(),'" + edpcom.UserDesc + "','" + off_email + "','','','Invoice for the month of " +dateTimePicker1.Value.ToString("MMM-yyyy") + "','" + System.DateTime.Now.ToString("MMM-yyyy") + "')");
                            bool rs = clsDataAccess.RunQry(sq1);
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                            {

                                file.WriteLine("Mail sent for Employee ID: " + ecode + " and Employee Name: " + strEmpName + " :: " +
                         "Mailed To : " + off_email + " :: Month : " +dateTimePicker1.Value.ToString("MMM-yyyy"));
                            }
                        }
                        catch (Exception ex)
                        {
                            //lbl_load_msg.Text = ("Email failed.." + ecode);
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                            {

                                file.WriteLine("Mail not sent for Employee ID: " + ecode + " and Employee Name: " + strEmpName + " :: " +
                         "Mailed To : " + off_email + " :: Month : " + dateTimePicker1.Value.ToString("MMM-yyyy"));
                            }
                        }
                    }
                }

            }
            catch { }



        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            display("Mail Send Completed...");
        }

        private void display(string text)
        {
            //lbl_load_msg.Text = text;
            MessageBox.Show(text+".. Check log file for details : " + path, "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}