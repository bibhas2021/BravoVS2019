using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Edpcom;
using System.IO;
using FirstTimeNeed;


namespace PayRollManagementSystem
{
    public partial class Multi_Bill_Print : Form
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        ArrayList arritem = new ArrayList();
        Hashtable getcode_item = new Hashtable();
        DataSet ds = new DataSet();

        DataTable dt_mb = new DataTable();


        string arrayItem = "";
        string Frm_Type = "", strBillFormatNo = "", SelectedACNo = "", startPath = "", termsconditions = "", ODetails = "", onote = "";
        string setting_type = "", refno = "", pono = "", tc = "", IsST = "F", isScAdd = "False";
        string company = "", Agentadd = "", Agentadd1 = "", phone = "", Area = "", BillDate = "", User_Voucher = "";
        string challan = "", challandt = "", AmtWord = "", narrsn = "";
        string conName = "", ConAdd1 = "", Conadd2 = "";
        string amtvalue = "";
        string lorry_no = "", locname = "", modtranport = "", prtyname = "", prtyadd1 = "", prtyadd2 = "", prtycity = "", prtyctypin = "", prtytele1 = "", prtytele2 = "", prtyfax = "", prtyemail = "", prtyeccno = "", prtytin = "";
        string partycodeeee = "";
        string tentry = "", FinalAmount = "", Refvoucher = "";

        public int Company_id = 0;
        public string vSes = "", Item_Code = "";
        bool boolsign = false;
        Boolean boolAdPrintingPermission = false;

        string hsn, sper, samt, cper, camt, txnAmt, tval, ptype;

        public Multi_Bill_Print(string type)
        {
            InitializeComponent();
            Frm_Type = type;
        }

        private void Multi_Bill_Print_Load(object sender, EventArgs e)
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
                                if (str == "BILL_PRINTING_OPTIONS")
                                    chk_str = 1;


                            }

                            //***string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            //if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            //{
                            //    if (StrLine_WACC[0] == "PRINT_BILLS_FOR_MULTIPLE_LOCATION_IN_SINGLE_CLICK")
                            //        boolSingleDesignationBillingPermission = true;
                            //    chk_str = 0;
                            //}***
                        }
                    }

                }
                catch
                { }
            }
            //***if (!boolSingleDesignationBillingPermission)
            //    comboBox1.Items.Remove("Multi Location Selection");***
            strBillFormatNo = BillFormatNo();
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

            //***this.lblTitle.Text = "Bill Print";
            //comboBox1.SelectedIndex = 0;
            //multiLocationSelection.Visible = false;
            //cmbLocation.Visible = true;//***

            bnkDtl.Visible = true;

            if (chkBank.Checked == true)
            {
                DataTable dt = clsDataAccess.RunQDTbl("select top 1 bank,acno from Branch where ltrim(rtrim(bank))!='' and (gcode='" + Company_id + "')");
                if (dt.Rows.Count > 0)
                {
                    bnkDtl.Text = dt.Rows[0]["bank"].ToString();
                    SelectedACNo = dt.Rows[0]["acno"].ToString();
                    bnkDtl.ReturnValue = SelectedACNo;
                }
            }

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
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }


            readFile();

            //***othrs();
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


            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                cmbcompany.Text = dta.Rows[0][0].ToString();

                Company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                cmbcompany.ReturnValue = Company_id.ToString();

            }
            else if (dta.Rows.Count > 1)
            {
                cmbcompany.PopUp();
            }
            lblprepby.Text = edpcom.UserDesc;

            string blhd = clsDataAccess.ReturnValue("select bill_head from CompanyLimiter");
            if (blhd.Trim() == "1") { rdb_type_inv.Checked = true; }
            else if (blhd.Trim() == "2") { rdb_type_bill.Checked = true; }
            else if (blhd.Trim() == "3") { rdb_type_bos.Checked = true; }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
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
                // cmbLocation.Text = "";
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);

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
        private string BillFormatNo()
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
                                        chkBlankHead.Visible = false;
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


            termsconditions = System.IO.File.ReadAllText(startPath + "\\" + setting_type + "\\TermsConditions.txt");
            ODetails = System.IO.File.ReadAllText(startPath + "\\" + setting_type + "\\ODetails.txt");
            onote = System.IO.File.ReadAllText(startPath + "\\" + setting_type + "\\note.txt");
            Txt_TermsConditions.Text = termsconditions;
            txt_Odetails.Text = ODetails;
            txtNote.Text = onote;
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
            DataTable dt = clsDataAccess.RunQDTbl("select bank,acno from Branch where ltrim(rtrim(bank))!=''");
            if (dt.Rows.Count > 0)
            {
                bnkDtl.LookUpTable = dt;
                bnkDtl.ReturnIndex = 1;
            }

        }

        private void bnkDtl_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            SelectedACNo = Convert.ToString(bnkDtl.ReturnValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string month = dateTimePicker1.Text;

            //string sqlstmnt = "Select distinct s.BILLNO as 'BillNo',(select Location_Name from tbl_Emp_Location where Location_ID =cr.Location_ID)as 'Location',s.BILLDATE as 'BillDate' from paybill s,Companywiseid_Relation cr where s.Month='" + month + "' and s.Session ='" + cmbYear.Text + "' and s.comany_ID = '" + Company_id + "' and cr.Company_ID='" + Company_id + "' and s.BillStatus = 'ACTIVE' ";
            string sqlstmnt = "Select distinct(select Location_Name from tbl_Emp_Location where Location_ID=s.Location_ID)as 'location', s.BILLNO as 'BillNo',s.BILLDATE as 'BillDate' from paybill s where s.Month='" + month + "' and s.Session ='" + cmbYear.Text + "' and s.comany_ID = '" + Company_id + "' and s.BillStatus = 'ACTIVE' order by location";
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


        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (Item_Code.Trim() == "")
            {
                EDPMessageBox.EDPMessage.Show("Please select bill no first.");
                return;
            }
            string odetails = "", termCon = "", bill_type = "TAX INVOICE", bl_type = "Invoice";


            //if (rdb_type_bill.Checked == true)
            //{
            //    bill_type = "BILL";
            //    bl_type="BILL";
            //}
            //else
            //{
            //    bill_type = "TAX INVOICE";
            //    bl_type="Invoice";

            //}
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
            string range = "", mon = "", nar = "";
            string[] dt_range;

            range = bl_type + "  FOR THE MONTH OF : " + dateTimePicker1.Value.ToString("MMMM-yyyy");

            DataTable dt8 = clsDataAccess.RunQDTbl("select * from paybillOD ");

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
            Retrive_Data();

            MidasReport.Form1 opening = new MidasReport.Form1();

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
                    DataTable getGSTDetails = clsDataAccess.RunQDTbl("select Comany_id,Location_ID,isGST,ServiceAmount,ScAmt, (CASE WHEN isRound = 'True' THEN Round(TotAMT, 0) ELSE TotAmt END) AS TotAMT,isRound,IsService,GstPer from paybill where BILLNO = " + bill);
                    if (getGSTDetails.Rows.Count > 0)
                    {
                        string chk = getGSTDetails.Rows[0]["isGST"].ToString().Trim();
                        if (getGSTDetails.Rows[0]["isGST"].ToString().Trim() == "True")
                        {
                            flag = true;
                            DataTable getIGSTOrNot = clsDataAccess.RunQDTbl("select distinct (isNull((select crm.GSTTYPE from Companywiseid_Relation crm where crm.Location_ID = pbd.Location_ID and crm.Company_ID = pbd.Comany_id),'LOCAL')) as 'GSTTYPE' from paybill pbd where pbd.BILLNO = " + bill);
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
                                    roff_val = Convert.ToString(string.Format("{0:N}", Math.Round(Convert.ToInt32(getGSTDetails.Rows[0]["ServiceAmount"]) - Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]), 2)));
                                }
                                else
                                {
                                    roff_val = "";
                                    roff = "";
                                }

                                serva1 = "ADD : " + Environment.NewLine + "SGST @" + serper1 + "%" + Environment.NewLine + "CGST @" + serper1 + "%" + Environment.NewLine + roff;
                                serva2 = Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + roff_val;

                            }
                            else
                            {
                                DataTable setGstPer = clsDataAccess.RunQDTbl("select GSTPER from Branch where GCODE = '" + getGSTDetails.Rows[0]["Comany_id"] + "'");

                                //serper1 = Convert.ToDouble(setGstPer.Rows[0][0]);
                                serper1 = Convert.ToDouble(getGSTDetails.Rows[0]["GstPer"]);// Math.Round(100 * Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / (Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"]) + Convert.ToDouble(getGSTDetails.Rows[0]["ScAmt"])));
                                stamtp = tamt * Convert.ToDouble(serper1) / 100;
                                serva1 = "ADD : " + Environment.NewLine + "IGST @" + serper1 + "%";
                                serva2 = Math.Round(stamtp, 2).ToString();
                                serva2 = Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(serva2));
                                if (getGSTDetails.Rows[0]["isRound"].ToString().Trim() == "True")
                                {
                                    double roffAmt = Math.Round(stamtp) - stamtp;
                                    if (roffAmt > 0)
                                    {
                                        serva1 = serva1 + Environment.NewLine + "Rounded off(+/-)";
                                        serva2 = serva2 + Environment.NewLine + "+" + string.Format("{0:N}", roffAmt);
                                    }
                                    else if (roffAmt < 0)
                                    {
                                        serva1 = serva1 + Environment.NewLine + "Rounded off(+/-)";
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
            switch (strBillFormatNo)
            {
                case "1":
                    opening.paybillO_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, tc);
                    break;
                case "2":

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
                    string val = "";
                    if (chkPrevBal.Checked == false) { val = "0"; } else { val = lblprevbal.Text; }
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
            opening.ShowDialog();
            ds.Tables.Clear();
            ds.Dispose();


        }

        public void Retrive_Data()
        {
            string custid = "", strssql = "", st_Desc = "''";
            int count_payBillD = 0;
            string mon_name = clsEmployee.GetMonthName(dateTimePicker1.Value.Month) + " - " + (dateTimePicker1.Value.Year);
            string monthdisp = clsEmployee.GetMonthName(dateTimePicker1.Value.Month) + "  " + (dateTimePicker1.Value.Year);
            string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
            dateTimePicker1.Text = (dateTimePicker1.Value.Month) + "-" + (dateTimePicker1.Value.Year);
            DataTable tot_employ = new DataTable("");
            DataTable tot_employ_main = new DataTable("");


            string qry = "";
            qry = "select Location_ID as 'lid',Cliant_ID as 'clid',BILLNO from paybill pb where Comany_id='" + Company_id + "' and BILLNO in (" + Item_Code + ") and MONTH='" + mon_name + "'";
            dt_mb = clsDataAccess.RunQDTbl(qry);

            switch (strBillFormatNo)
            {
                case "1":
                    if (setting_type == "type 3")
                    {
                        st_Desc ="'"+ txtDesc.Text + "\r\n" + "For the location ' + (select Location_Name  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )";
                            //+ (select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )";
                    }
                    else
                    {
                        if (txtDesc.Text.Trim() == "Being the amount charged for the supply of service")
                        {
                            st_Desc = "''";
                        }
                        else
                        {
                            st_Desc = "'" + txtDesc.Text.Trim() + Environment.NewLine + " placed at your disposal at '+ (select Location_Name  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) + ' in the month of " + mon_name + " AS PER DETAIL GIVEN BELOW :- '";
                        }
                    }
                    break;
                case "2":
                    st_Desc = "'" + txtDesc.Text.Trim() + Environment.NewLine + " placed at your disposal at '+ (select Location_Name  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) + ' in the month of " + mon_name + " '";
                    break;
            }

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


            for (int i = 0; i < dt_mb.Rows.Count; i++)
            {


                count_payBillD = Convert.ToInt32(clsDataAccess.GetresultS("select count(*) from paybillD where billno in ('" + dt_mb.Rows[i]["BILLNO"] + "')"));
                custid = clsDataAccess.GetresultS("select cliant_id from paybill where billno in ('" + dt_mb.Rows[i]["BILLNO"] + "')");

                DataTable dct = clsDataAccess.RunQDTbl("SELECT isAdd, blAdd, blPh, blFax, blEmail FROM Companywiseid_Relation where (Company_ID='" + Company_id + "') and (Location_ID='" + dt_mb.Rows[i]["lid"] + "')");
                DataTable dtLocWiseChk = clsDataAccess.RunQDTbl("select [Location_ID],[Cliant_ID],[Designation_Id] from [paybill] where [BILLNO] = '" + dt_mb.Rows[i]["BILLNO"] + "'");

                if (dtLocWiseChk.Rows[0][0].ToString() != "0")                              //SINGLE LOCATION BILLING
                {
                    dct.Clear();
                    dct = clsDataAccess.RunQDTbl("SELECT isAdd, blAdd, blPh, blFax, blEmail FROM Companywiseid_Relation where (Company_ID='" + Company_id + "') and (Location_ID='" + dt_mb.Rows[i]["lid"] + "')");
                    //and (Location_ID=(select distinct Location_ID from paybillD where BILLNO = " + billcode + "))");
                    strssql = "";
                    if (count_payBillD > 0)
                    {
                        //(select Location_Name from tbl_Emp_Location where Location_ID=h.Location_ID )
                        strssql = strssql + " select h.BILLNO,CONVERT(VARCHAR(10),h.BILLDATE,103) as BILLDATE,CONVERT(VARCHAR(10),h.DUEDATE,103) as duedate,(select c.co_name from Company c where c.CO_CODE=h.Comany_id ) as 'coname',";
                        strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=h.Comany_id ) as 'Add1',(select distinct (case when ltrim(rtrim(b.GSTINNO))!='' then ' GST No.: '+b.GSTINNO else '' end) from Branch b where b.gcode=h.comany_id)as 'Add2',(select c.CO_ADD1  from Company c where c.CO_CODE=h.Comany_id ) as 'Add3',(select distinct BRNCH_TELE1 from Branch B where B.GCODE=h.Comany_id ) as 'phone',";
                        strssql = strssql + "(select distinct Website from Branch b where b.gcode=h.comany_id )as 'Website' ,(select distinct Email from Branch b where b.gcode=h.comany_id) as 'Email',";
                        //strssql = strssql + " (select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) )) as 'locname','" + monthdisp + "' as Month,h.Session, (CASE WHEN h.isRound = 'True' THEN Round((h.TotAMT+h.ScAmt), 0) ELSE (h.TotAMT+h.ScAmt) END)  as 'TotAMT' ,h.IsService,h.ServiceAmount,";
                        strssql = strssql + " (select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) as 'locname','" + monthdisp + "' as Month,h.Session, (CASE WHEN h.isRound = 'True' THEN Round((h.TotAMT+h.ScAmt), 0) ELSE (h.TotAMT+h.ScAmt) END)  as 'TotAMT' ,h.IsService,h.ServiceAmount,";
                        strssql = strssql + " d.Attendance ,d.BILLAMT,cast(d.Dtl_id as nvarchar) Dtl_id ,d.Hour,d.MonthDays,cast(d.RATE as nvarchar)RATE,((select e.DesignationName  from tbl_Employee_DesignationMaster e where e.SlNo=d.desig_ID ) + CAST( CASE WHEN d.rmrks<>'' then ' [' + d.rmrks +']' else '' END as nvarchar) ) as 'designation',cast(d.NoOfPersonnel as nvarchar)NoOfPersonnel";
                        //strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )) as 'ClientName'"; //(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )
                        strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )) as 'ClientName'"; //(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )
                        strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID )) as 'ClientCity'";
                        strssql = strssql + " ,(select 'GSTIN NO. : '+c.GSTINNO+', State Code-'+c.Client_State   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ) as 'Contract_Person'";
                        strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) ))+ ', '+(SELECT Upper( Country_Name) FROM Country where Country_CODE=(select c.Country  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) )) AS mis1";
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

                        strssql = strssql + " CAST(CASE WHEN d.SAC is null then ' ' ELSE (select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) END as varchar(50)) AS mis3,(select (select 'BANK DETAILS FOR RTGS/NEFT/IMPS:'+CHAR(13)+CHAR(10)+bm.bank +'    A/C NO. : ' + bm.acno + '    IFSC : ' + bm.ifsc from Branch bm where crm.Company_ID = bm.GCODE and crm.blAcNo = bm.acno) from Companywiseid_Relation crm where crm.Company_ID = h.Comany_id and crm.Location_ID = h.Location_ID) AS mis4," +
                        st_Desc + " AS mis5,'' AS mis6,'' AS mis7,h.IsScAdd AS mis9,h.isRound AS mis10,h.isGST as mis8,(SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "') as Cmpimage,(select " + sign + " from Company where GCODE='" + Company_id.ToString() + "') as authsign,'( ORIGINAL / DUPLICATE / TRIPLICATE )' as rmrks";

                        strssql = strssql + " from paybill h inner join paybillD d on h.BILLNO=d.BILLNO";
                        strssql = strssql + " where h.Session='" + cmbYear.Text + "' and d.Month ='" + month + "'";
                        //strssql = strssql + " and h.Location_ID = '" + Location_id + "' and h.Comany_id='" + Company_id + "'";
                        strssql = strssql + " and (h.Comany_id='" + Company_id + "')";


                    }
                    else
                    {

                        strssql = strssql + " select h.BILLNO,CONVERT(VARCHAR(10),h.BILLDATE,103) as BILLDATE,CONVERT(VARCHAR(10),h.DUEDATE,103) as duedate,(select c.co_name from Company c where c.CO_CODE=h.Comany_id ) as 'coname',";
                        strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=h.Comany_id ) as 'Add1',(select distinct (case when ltrim(rtrim(b.GSTINNO))!='' then ' GST No.: '+b.GSTINNO else '' end) from Branch b where b.gcode=h.comany_id)as 'Add2',(select c.CO_ADD1  from Company c where c.CO_CODE=h.Comany_id ) as 'Add3',(select distinct BRNCH_TELE1 from Branch B where B.GCODE=h.Comany_id ) as 'phone',";
                        strssql = strssql + "(select distinct Website from Branch b where b.gcode=h.comany_id )as 'Website' ,(select distinct Email from Branch b where b.gcode=h.comany_id) as 'Email',";
                        //'" + cmbLocation.Text + "'
                        strssql = strssql + " (select l.Location_Name  from tbl_Emp_Location l where l.Location_ID=h.Location_ID ) as 'locname','" + monthdisp + "' as Month,h.Session,(CASE WHEN h.isRound = 'True' THEN Round((h.TotAMT+h.ScAmt), 0) ELSE (h.TotAMT+h.ScAmt) END)  as 'TotAMT' ,h.IsService,h.ServiceAmount,";
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
                        strssql = strssql + " '' AS mis3,(select (select 'Bank Name '+bm.bank+CHAR(13)+CHAR(10) +' Account No. ' + bm.acno + '   RTGS/NEFT IFSC : ' + bm.ifsc from Branch bm where crm.Company_ID = bm.GCODE and crm.blAcNo = bm.acno) from Companywiseid_Relation crm where crm.Company_ID = h.Comany_id and crm.Location_ID = h.Location_ID) AS mis4," +
                        st_Desc + " AS mis5,'' AS mis6,'' AS mis7,IsScAdd AS mis9,h.isRound AS mis10,h.isGST as mis8,(SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "') as Cmpimage,(select " + sign + " from Company where GCODE='" + Company_id.ToString() + "') as authsign,'( ORIGINAL / DUPLICATE / TRIPLICATE )' as rmrks";// (ORIGINAL FOR RECIPIENT)

                        strssql = strssql + " from paybill h ";
                        strssql = strssql + " where h.Session='" + cmbYear.Text + "' and h.Month ='" + dateTimePicker1.Text + "'";
                        //strssql = strssql + " and h.Location_ID = '" + Location_id + "' and h.Comany_id='" + Company_id + "'";
                        strssql = strssql + " and (h.Comany_id='" + Company_id + "')";

                    }

                    if (checkBox1.Checked == false)
                    {
                        strssql = strssql + " and h.BILLNO in ('" + dt_mb.Rows[i]["BILLNO"] + "') ";
                    }

                    tot_employ = clsDataAccess.RunQDTbl(strssql);

                    DataTable dtimage = clsDataAccess.RunQDTbl("SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "' ");
                    DataTable rfcode = clsDataAccess.RunQDTbl("SELECT Order_Date,Cliant_OrderNo,refno FROM tbl_Employee_OrderDetails where order_name in " +
                   "(select distinct ref_order_no from paybillD where BILLNO in('" + dt_mb.Rows[i]["BILLNO"] + "') and ref_order_no!='')");
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

                    DataTable Ord = clsDataAccess.RunQDTbl("Select (case when IncGst=1 then OCHARGES+' *' else OCHARGES end ) as OCHARGES,ORate,OQty,OAMT,BILLNO,(select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) as 'SAC',IncGst,OAttend from paybillO d where BILLNO in ('" + dt_mb.Rows[i]["BILLNO"] + "') ");

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
                                destRow["Attendance"] = Ord.Rows[rw_ord]["OAttend"];//tot_employ.Rows[0][11];
                                destRow["ServiceAmount"] = tot_employ.Rows[0]["ServiceAmount"];
                                destRow["BILLAMT"] = Ord.Rows[rw_ord]["OAMT"];
                                destRow["Rate"] = Ord.Rows[rw_ord]["ORate"];//tot_employ.Rows[0][16];
                                destRow["Dtl_id"] = (rw_ord + 1).ToString();// tot_employ.Rows[0]["Dtl_id"];
                                destRow["rmrks"] = tot_employ.Rows[0]["rmrks"];
                                destRow["phone"] = tot_employ.Rows[0]["phone"];
                                destRow["duedate"] = tot_employ.Rows[0]["duedate"];
                                destRow["NoOfPersonnel"] = Ord.Rows[rw_ord]["OQty"];//tot_employ.Rows[0]["NoOfPersonnel"];
                                destRow["TotAMT"] = tot_employ.Rows[0]["TotAMT"];
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
                    Ord = clsDataAccess.RunQDTbl("Select ScPer,ScAmt,(select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) as 'SAC' from paybill d where IsSC='True' and BILLNO in ('" + dt_mb.Rows[i]["BILLNO"] + "')");

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
                        strssql = strssql + " d.Attendance ,d.BILLAMT,d.Dtl_id ,d.Hour,d.MonthDays,d.RATE,((select e.DesignationName  from tbl_Employee_DesignationMaster e where e.SlNo=d.desig_ID )  + ' ' + CAST( CASE WHEN d.rmrks<>'' then d.rmrks else '' END as nvarchar))+ '['+(select Location_Name from tbl_Emp_Location where Location_ID=d.Location_ID )+']' as 'designation',d.NoOfPersonnel";
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
                        strssql = strssql + " CAST(CASE WHEN d.SAC is null then ' ' ELSE (select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) END as varchar(50)) AS mis3,'' AS mis4," + st_Desc + " AS mis5,'' AS mis6,'' AS mis7,h.IsScAdd AS mis9,h.isRound AS mis10,h.isGST as mis8,(SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "') as Cmpimage,(select " + sign + " from Company where GCODE='" + Company_id.ToString() + "') as authsign,'( ORIGINAL / DUPLICATE / TRIPLICATE )' as rmrks";

                        strssql = strssql + " from paybill h inner join (select pbd.Month,'' as Dtl_id,sum(cast(pbd.Attendance as numeric(18,2))) as 'Attendance',pbd.Hour,pbd.MonthDays,SUM(pbd.BILLAMT) as BILLAMT,pbd.RATE,pbd.desig_ID,pbd.rmrks,pbd.SAC,pbd.BILLNO,pbd.NoOfPersonnel,pbd.Location_ID from paybillD pbd group by pbd.RATE,pbd.Month,pbd.Hour,pbd.MonthDays,pbd.desig_ID,pbd.rmrks,pbd.SAC,pbd.BILLNO,pbd.RATE,pbd.NoOfPersonnel,pbd.Location_ID) d on h.BILLNO=d.BILLNO";
                        strssql = strssql + " where h.Session='" + cmbYear.Text + "' and d.Month ='" + month + "'";
                        //strssql = strssql + " and h.Location_ID = '" + Location_id + "' and h.Comany_id='" + Company_id + "'";
                        strssql = strssql + " and (h.Comany_id='" + Company_id + "')";
                    }
                    if (checkBox1.Checked == false)
                    {
                        strssql = strssql + " and h.BILLNO in ('" + dt_mb.Rows[0]["BILLNO"] + "') ";
                    }

                    tot_employ = clsDataAccess.RunQDTbl(strssql);
                    //  DataRow destRow= new DataRow();
                    DataTable dtimage = clsDataAccess.RunQDTbl("SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "' ");
                     DataTable Ord = clsDataAccess.RunQDTbl("Select (case when IncGst=1 then OCHARGES+' *' else OCHARGES end ) as OCHARGES,ORate,OQty,OAMT,BILLNO,(select csa.sacNo from CompanySACMaster csa where csa.slno = d.SAC) as 'SAC',IncGst from paybillO d where BILLNO in ('" + dt_mb.Rows[i]["BILLNO"] + "') ");

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
                                 destRow["Attendance"] = 0;//tot_employ.Rows[0][11];
                                 destRow["ServiceAmount"] = tot_employ.Rows[0]["ServiceAmount"];
                                 destRow["BILLAMT"] = Ord.Rows[rw_ord]["OAMT"];
                                 destRow["Rate"] = Ord.Rows[rw_ord]["ORate"];//tot_employ.Rows[0][16];
                                 destRow["Dtl_id"] = (rw_ord + 1).ToString();// tot_employ.Rows[0]["Dtl_id"];
                                 destRow["rmrks"] = tot_employ.Rows[0]["rmrks"];
                                 destRow["phone"] = tot_employ.Rows[0]["phone"];
                                 destRow["duedate"] = tot_employ.Rows[0]["duedate"];
                                 destRow["NoOfPersonnel"] = Ord.Rows[rw_ord]["OQty"];//tot_employ.Rows[0]["NoOfPersonnel"];
                                 destRow["TotAMT"] = tot_employ.Rows[0]["TotAMT"];
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

                }

                tot_employ_main.Merge(tot_employ);


                IsST = clsDataAccess.GetresultS("Select IsService from paybill where BILLNO in ('" + dt_mb.Rows[i]["BILLNO"] + "')");
                if (IsST == "True")
                {
                    isScAdd = clsDataAccess.GetresultS("Select IsScAdd from paybill where BILLNO in ('" + dt_mb.Rows[i]["BILLNO"] + "')");
                }
                else
                {
                    isScAdd = "False";
                }

            }

            ds.Tables.Add(tot_employ_main);
            ds.Tables[0].TableName = "Bill";




        }

        public void writeFile()
        {
            termsconditions = Txt_TermsConditions.Text;
            ODetails = txt_Odetails.Text;
            onote = txtNote.Text;
            System.IO.File.WriteAllText(startPath + "\\" + setting_type + "\\TermsConditions.txt", termsconditions);
            System.IO.File.WriteAllText(startPath + ("\\" + setting_type + "\\ODetails.txt"), ODetails);
            System.IO.File.WriteAllText(startPath + ("\\" + setting_type + "\\note.txt"), onote);

        }

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
                            bankD = "BANK DETAILS FOR RTGS/NEFT/IMPS:\n\r" + dt.Rows[0][0].ToString() + "    A/C NO. :" + dt.Rows[0][1].ToString() + "    IFSC :" + dt.Rows[0][2].ToString();
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
                            bankD = "BANK DETAILS FOR RTGS/NEFT/IMPS:\n\r" + dt.Rows[0][0].ToString() + " - " + dt.Rows[0]["bank_br"].ToString() + "    A/C NO. :" + dt.Rows[0][1].ToString() + "    IFSC :" + dt.Rows[0][2].ToString() + "\n\r Address :" + dt.Rows[0]["bank_br_add"].ToString();
                            ds.Tables[0].Rows[i]["mis4"] = bankD;
                            //break;
                        }
                    }
                }
            }

        }

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Item_Code.Trim() == "")
            {
                EDPMessageBox.EDPMessage.Show("Please select bill no first.");
                return;
            }
            string odetails = "", termCon = "", bill_type = "TAX INVOICE", bl_type = "Invoice";


            //if (rdb_type_bill.Checked == true)
            //{
            //    bill_type = "BILL";
            //    bl_type="BILL";
            //}
            //else
            //{
            //    bill_type = "TAX INVOICE";
            //    bl_type="Invoice";

            //}
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
            string range = "", mon = "", nar = "";
            string[] dt_range;

            DataTable dt8 = clsDataAccess.RunQDTbl("select * from paybillOD ");

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
            Retrive_Data();

            MidasReport.Form1 opening = new MidasReport.Form1();

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
                    DataTable getGSTDetails = clsDataAccess.RunQDTbl("select Comany_id,Location_ID,isGST,ServiceAmount,ScAmt, (CASE WHEN isRound = 'True' THEN Round(TotAMT, 0) ELSE TotAmt END) AS TotAMT,isRound,IsService,GstPer from paybill where BILLNO = " + bill);
                    if (getGSTDetails.Rows.Count > 0)
                    {
                        string chk = getGSTDetails.Rows[0]["isGST"].ToString().Trim();
                        if (getGSTDetails.Rows[0]["isGST"].ToString().Trim() == "True")
                        {
                            flag = true;
                            DataTable getIGSTOrNot = clsDataAccess.RunQDTbl("select distinct (isNull((select crm.GSTTYPE from Companywiseid_Relation crm where crm.Location_ID = pbd.Location_ID and crm.Company_ID = pbd.Comany_id),'LOCAL')) as 'GSTTYPE' from paybill pbd where pbd.BILLNO = " + bill);
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
                                    roff_val = Convert.ToString(string.Format("{0:N}", Math.Round(Convert.ToInt32(getGSTDetails.Rows[0]["ServiceAmount"]) - Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]), 2)));
                                }
                                else
                                {
                                    roff_val = "";
                                    roff = "";
                                }

                                serva1 = "ADD : " + Environment.NewLine + "SGST @" + serper1 + "%" + Environment.NewLine + "CGST @" + serper1 + "%" + Environment.NewLine + roff;
                                serva2 = Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / 2) + Environment.NewLine + roff_val;

                            }
                            else
                            {
                                DataTable setGstPer = clsDataAccess.RunQDTbl("select GSTPER from Branch where GCODE = '" + getGSTDetails.Rows[0]["Comany_id"] + "'");

                                //serper1 = Convert.ToDouble(setGstPer.Rows[0][0]);
                                serper1 = Convert.ToDouble(getGSTDetails.Rows[0]["GstPer"]);// Math.Round(100 * Convert.ToDouble(getGSTDetails.Rows[0]["ServiceAmount"]) / (Convert.ToDouble(getGSTDetails.Rows[0]["TotAMT"]) + Convert.ToDouble(getGSTDetails.Rows[0]["ScAmt"])));
                                stamtp = tamt * Convert.ToDouble(serper1) / 100;
                                serva1 = "ADD : " + Environment.NewLine + "IGST @" + serper1 + "%";
                                serva2 = Math.Round(stamtp, 2).ToString();
                                serva2 = Environment.NewLine + string.Format("{0:N}", Convert.ToDouble(serva2));
                                if (getGSTDetails.Rows[0]["isRound"].ToString().Trim() == "True")
                                {
                                    double roffAmt = Math.Round(stamtp) - stamtp;
                                    if (roffAmt > 0)
                                    {
                                        serva1 = serva1 + Environment.NewLine + "Rounded off(+/-)";
                                        serva2 = serva2 + Environment.NewLine + "+" + string.Format("{0:N}", roffAmt);
                                    }
                                    else if (roffAmt < 0)
                                    {
                                        serva1 = serva1 + Environment.NewLine + "Rounded off(+/-)";
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
            switch (strBillFormatNo)
            {
                case "1":
                    opening.paybillO_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2, refno, pono, "Security Guard", boolAdPrintingPermission, tc);
                    break;
                case "2":

                    if (chkBlankHead.Checked == true)
                    {
                        opening.paybillO_Format1_blank_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2, refno, pono, "Security Guard", boolAdPrintingPermission, tc, bill_type, bl_type);
                    }
                    else
                    {
                        opening.paybillO_Format1_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn,2, refno, pono, "Security Guard", boolAdPrintingPermission, tc, bill_type, bl_type);
                    }

                    break;
                case "3":
                    string val = "";
                    if (chkPrevBal.Checked == false) { val = "0"; } else { val = lblprevbal.Text; }
                    if (chkBlankHead.Checked == true)
                    {

                        opening.paybillO_Format2_blank_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                    }
                    else
                    {
                        opening.paybillO_Format_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                    }
                    break;
                case "4":
                    //string val = "";
                    if (chkPrevBal.Checked == false) { val = "0"; } else { val = lblprevbal.Text; }
                    if (chkBlankHead.Checked == true)
                    {

                        opening.paybillO_Format2_blank_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                    }
                    else
                    {
                        opening.paybillO_Format3_print(serva1, serva2, odetails, termsconditions, bankD, onote, edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 2, refno, pono, "Security Guard", boolAdPrintingPermission, lblprepby.Text, lblEnclosure.Text, cmbLocation.Text, val, tc, bill_type, bl_type, range, nar);
                    }
                    break;
            }
            opening.ShowDialog();
            ds.Tables.Clear();
            ds.Dispose();
        }


    }
}