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
using System.Web.UI.WebControls;
namespace PayRollManagementSystem
{
    public partial class BillingRRpt : Form//EDPComponent.FormBaseRptMidium
    {
        public BillingRRpt()
        {
            InitializeComponent();
        }
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        ArrayList arritem = new ArrayList();
        Hashtable getcode_item = new Hashtable();
        string Item_Code = "";
        int company_id = 0, ed_zone=0;
        string coadd = "";
        String sub;
        

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
        public int get_CompID(string name)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            string s = " select GCODE  from Company where CO_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
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
                //cmbsalstruc.Items.Clear();
                
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                company_id = Convert.ToInt32(cmbcompany.ReturnValue);

            coadd = clsDataAccess.GetresultS("Select CO_ADD from Company where (CO_CODE='" + company_id + "')");
        }

        private void BillingRRpt_Load(object sender, EventArgs e)
        {
            grp_bill.Visible = false;
            grp_month.Visible = false;
            grp_period.Visible = false;
            grp_zone.Visible = false;
            chk_All_Client.Checked = true;

            rdbdtwise_CheckedChanged(sender, e);
            clsValidation.GenerateYear(CmbSession, 2015, System.DateTime.Now.Year, 1);
            
            try
            {
                ed_zone = Convert.ToInt32(clsDataAccess.GetresultS("select zone from CompanyLimiter"));
            }
            catch
            {
                ed_zone = 0;
            }

            if (ed_zone == 1)
            {
                rdbZone.Visible = true;
            }
            else
            {
                rdbZone.Visible = false;
            }

            if (DateTime.Now.Month>=4)

                try
                {
                    if (DateTime.Now.Month >= 4)
                    {
                        try
                        { CmbSession.SelectedItem = DateTime.Now.Year + "-" + DateTime.Now.AddYears(1).Year; }
                        catch { }
                       
                    }
                    else
                    {
                        CmbSession.SelectedItem = DateTime.Now.AddYears(-1).Year + "-" + DateTime.Now.Year;
                       
                    }
                }
                catch
                { }
            cmbcompany.ReadOnlyText = true;
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt.Rows.Count == 1)
            {
                cmbcompany.Text = Convert.ToString(dt.Rows[0][0]);

                company_id = Convert.ToInt32(dt.Rows[0][1]);
               
            }
            else if (dt.Rows.Count > 1)
            {
                cmbcompany.PopUp();
               
            }
            
            rdbMonth.Checked = true;


            if (rdbdtwise.Checked)
            {   
                cmbMonth.Enabled = false;
                groupBox1.Enabled = false;
            }
            
        }
        string[] ar = new string[12];
        DataTable billdt=new DataTable();




        private void FrmBillingReport_Click(object sender, EventArgs e)
        {
            string ord = "";
            if (rdb_ord_Date.Checked == true)
            {
                ord = "order by pb.BILLDATE";
            }
            else if (rdb_ord_bill.Checked == true)
            {
                ord = "order by pb.BILLNO, pb.BILLDATE";
            }
            else if (rdb_ord_party.Checked == true)
            {
                ord = "order by Client,pb.BILLDATE,pb.BILLNO";
            }
            
            if (rdbdtwise.Checked)
            {
                if (CmbSession.Text.Trim() != "" && cmbMonth.Text.Trim() != "" && cmbcompany.Text.Trim() != "")
                {
                string[] StrLine = this.CmbSession.Text.Trim().Split('-');
            string yr = ""; string mon = "", sql = "", where1stclause = "", lastDayOfMonth = "";
            Double tgst = 0, tsgst = 0, tcgst = 0, tigst = 0, tgrossamt = 0, tnetamt = 0;

            /*
            if (rdbSession.Checked == true)
            {
                ar[0] = "April";
                ar[1] = "May";
                ar[2] = "June";
                ar[3] = "July";
                ar[4] = "August";
                ar[5] = "September";
                ar[6] = "October";
                ar[7] = "November";
                ar[8] = "December";
                ar[9] = "January";
                ar[10] = "February";
                ar[11] = "March";
            }
            else
            {
                ar[0] = cmbMonth.SelectedItem.ToString();
            }
            billdt.Clear();

            int ind_ar = 0;
            if (rdbMonth.Checked == true)
            {
                ind_ar = 1;
            }
            else if (rdbBDMonth.Checked == true)
            {
                ind_ar = 1;
            }
            else
            {
                ind_ar = ar.Length;
            }
            
            //RADIO BUTTON CHECKING
            if (rdbMonth.Checked == true)
            {
                int mnval = 0;
                if (cmbMonth.SelectedIndex > 9)
                {
                    mnval = (cmbMonth.SelectedIndex) - 9;
                    yr = StrLine[1].Trim();
                }
                else if (cmbMonth.SelectedIndex <= 9)
                {
                    mnval = cmbMonth.SelectedIndex + 3;
                    yr = StrLine[0].Trim();
                }
                else if (cmbMonth.SelectedIndex == 0)
                {
                    mnval = 0;
                    yr = "";
                    EDPMessageBox.EDPMessage.Show("Please Select a particular month.");
                    return;
                }

                where1stclause = "pb.Month = '"+cmbMonth.Text+" - "+yr+"'";
            }
            else if (rdbBDMonth.Checked == true)
            {
                int mnval = 0;
                if (cmbMonth.SelectedIndex > 9)
                {
                    mnval = (cmbMonth.SelectedIndex) - 9;
                    yr = StrLine[1].Trim();
                }
                else if (cmbMonth.SelectedIndex <= 9)
                {
                    mnval = cmbMonth.SelectedIndex + 3;
                    yr = StrLine[0].Trim();
                }
                else if (cmbMonth.SelectedIndex == 0)
                {
                    mnval = 0;
                    yr = "";
                    EDPMessageBox.EDPMessage.Show("Please Select a particular month.");
                    return;
                }

                lastDayOfMonth = DateTime.DaysInMonth(Convert.ToInt32(yr), mnval).ToString(); ;
                where1stclause = "";

                where1stclause = "pb.BILLDATE between '" + yr + "-" + mnval + "-01' and '" + yr + "-" + mnval + "-"+lastDayOfMonth+"'";
                lastDayOfMonth = "";
                mnval = 0;
                yr = "";
            }
            else
            {
                lastDayOfMonth = DateTime.DaysInMonth(Convert.ToInt32(StrLine[1]), 3).ToString();
                where1stclause = "pb.BILLDATE between '" + StrLine[0] + "-" + "04" + "-01' and '" + StrLine[1] + "-" + "03" + "-" + lastDayOfMonth + "'";
            }
                    */
            if (chkCancel.Checked == true)
            {
                if (chk_All_Client.Checked==true)
                {
                    sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO + (case when pb.BillStatus='CANCELED' then char(10) + '[ CANCELED ]' else '' end ) as 'BILLNO',(case when pb.BillStatus='CANCELED' then 0 else pb.ServiceAmount end) as 'GST',cwr.GSTTYPE,pb.Client as CLIENT," +
        "(case when pb.BillStatus='CANCELED' then 0 else (pb.TotAMT+pb.ScAmt) end)  as 'GROSSAMT',"+
        "(case when pb.BillStatus='CANCELED' then 0 else pb.NetAmt end) as 'NETAMT',"+
        "(case when pb.BillStatus='CANCELED' then 0 else pb.ScAmt end) as 'SCAMT',pb.GstNo as 'GstNo' from " +
        "(SELECT pb.[BILLNO],pb.BillStatus" +
              ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
          ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where (BILLDATE between '" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MMM/yyyy") + "') and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null   and (pb.Comany_id = " + company_id + ")))pb " +
          "left join " +
          "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;
                }
                else
                {
                    sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO + (case when pb.BillStatus='CANCELED' then char(10) + '[ CANCELED ]' else '' end ),(case when pb.BillStatus='CANCELED' then 0 else pb.ServiceAmount end) as 'GST',cwr.GSTTYPE,pb.Client as 'CLIENT'," +
         "(case when pb.BillStatus='CANCELED' then 0 else (pb.TotAMT+pb.ScAmt) end) as 'GROSSAMT',"+
         "(case when pb.BillStatus='CANCELED' then 0 else pb.NetAmt end) as 'NETAMT',"+
         "(case when pb.BillStatus='CANCELED' then 0 else pb.ScAmt end) as 'SCAMT',pb.GstNo as 'GstNo' from " +
         "(SELECT pb.[BILLNO],pb.BillStatus" +
               ",pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as Client " +
           ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where (BILLDATE between '" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MMM/yyyy") + "') and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null  and (pb.Comany_id = " + company_id + ") and (pb.Location_ID in (Select Location_ID from tbl_Emp_Location where (Cliant_ID in (" + Item_Code + "))))))pb " +
           "left join " +
           "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;

                }
            }
            else
            {
                if (chk_All_Client.Checked)
                {
                    sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT,(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
        "(SELECT pb.[BILLNO]" +
              ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
          ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where (BILLDATE between '" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MMM/yyyy") + "') and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null   and (pb.Comany_id = " + company_id + ") and pb.BillStatus = 'ACTIVE'))pb " +
          "left join " +
          "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;
                }
                else
                {
                    sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as 'CLIENT',(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
         "(SELECT pb.[BILLNO]" +
               ",pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as Client " +
           ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where (BILLDATE between '" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MMM/yyyy") + "') and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null  and (pb.Comany_id = " + company_id + ") and (pb.Location_ID in (Select Location_ID from tbl_Emp_Location where (Cliant_ID in (" + Item_Code + ")))) and pb.BillStatus = 'ACTIVE'))pb " +
           "left join " +
           "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;

                }
            }
            DataTable dtPaybill = clsDataAccess.RunQDTbl(sql);

            int countPaybill = dtPaybill.Rows.Count;

            dtPaybill.Columns.Add("CGST", typeof(double));
            dtPaybill.Columns.Add("SGST", typeof(double));
            dtPaybill.Columns.Add("IGST", typeof(double));
            dtPaybill.Columns.Add("Total", typeof(double));
            double roff_val = 0;
            for (int i = 0; i < countPaybill; i++)
            {
                if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "LOCAL")
                {
                    try
                    {
                        string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                        gstval = String.Format("{0:n}", (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2));
                        
                        double sgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                        double cgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);

                        dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(sgstVal),2));
                        dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}",  Math.Round(Convert.ToDouble(cgstVal),2));
                        dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                       
                        tsgst = tsgst + sgstVal;
                        tcgst = tcgst + cgstVal;
                    }
                    catch
                    { }
                }
                else if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "INTERSTATE")
                {
                    try
                    {
                        string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                        double igstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                        tigst = tigst + igstVal;
                        gstval = String.Format("{0:n}", igstVal);
                        dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}",Convert.ToDouble(0));
                        dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                        dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}",  Math.Round(Convert.ToDouble(igstVal),2));
                    }
                    catch
                    { }
                }

                double gstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                tgst = tgst + gstVal;
               // dtPaybill.Rows[i]["GST"] = String.Format("{0:n}",  Math.Round(Convert.ToDouble(dtPaybill.Rows[i]["GST"])));
                double grossVal = Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]);
                tgrossamt = tgrossamt + grossVal;
                //dtPaybill.Rows[i]["GROSSAMT"] = String.Format("{0:n}",  Math.Round(Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"])));
                double netVal = Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"]);
                tnetamt = tnetamt + netVal;
                dtPaybill.Rows[i]["NETAMT"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"])));
                double scVal = Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]);
                roff_val = Convert.ToDouble(string.Format("{0:N}", Math.Round((Convert.ToInt32(dtPaybill.Rows[i]["GST"]) +
                    Convert.ToInt32(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToInt32(dtPaybill.Rows[i]["GROSSAMT"])) - (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) + Convert.ToDouble(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"])), 2)));
                //tscamt = tscamt + scVal;
                //dtPaybill.Rows[i]["SCAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]));
                dtPaybill.Rows[i]["Total"] = String.Format("{0:n}", roff_val);
            }

           // dtPaybill.Rows.Add();

            DataTable dtCloned = dtPaybill.Clone();
            dtCloned.Columns["BILLDATE"].DataType = typeof(String);
            foreach (DataRow row in dtPaybill.Rows)
            {
                dtCloned.ImportRow(row);
            }
                    /*
            dtCloned.Rows[countPaybill]["BILLDATE"] = "";
            dtCloned.Rows[countPaybill]["BILLNO"] = "Grand Total";
            //dtCloned.Rows[countPaybill]["CLIENT & LOCATION"] = "Grand Total ";
            dtCloned.Rows[countPaybill]["CGST"] = String.Format("{0:n}", tcgst);
            dtCloned.Rows[countPaybill]["SGST"] = String.Format("{0:n}", tsgst);
            dtCloned.Rows[countPaybill]["IGST"] = String.Format("{0:n}", tigst);
            dtCloned.Rows[countPaybill]["GST"] = String.Format("{0:n}", tgst);
            dtCloned.Rows[countPaybill]["NETAMT"] = String.Format("{0:n}", tnetamt);
            dtCloned.Rows[countPaybill]["GROSSAMT"] = String.Format("{0:n}", tgrossamt);
            //dtCloned.Rows[countPaybill]["SCAMT"] = String.Format("{0:n}", tscamt);
                    */
            sub = "GST Bill Summary During the period From " + dateTimePicker1.Value.ToString("dd/MM/yyyy");
            sub = sub + " To " + dateTimePicker2.Value.ToString("dd/MM/yyyy");
            MidasReport.Form1 bill = new MidasReport.Form1();
            bill.prntgststmntrpt(cmbcompany.Text,coadd,sub,dtCloned);
            bill.Show();
 
                }
            }


            else if (rbdVoucher.Checked)
            {
                 if (CmbSession.Text.Trim() != "" && cmbMonth.Text.Trim() != "" && cmbcompany.Text.Trim() != "")
                {
                    string[] StrLine = this.CmbSession.Text.Trim().Split('-');
                    string yr = ""; string mon = "", sql = "", where1stclause = "", lastDayOfMonth = "";
                    Double tgst = 0, tsgst = 0, tcgst = 0, tigst = 0, tgrossamt = 0, tnetamt = 0, roff_val=0;


                    if (chkCancel.Checked == true)
                    {
                        if (chk_All_Client.Checked == true)
                        {
                            sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO + (case when pb.BillStatus='CANCELED' then char(10) + '[ CANCELED ]' else '' end ) as 'BILLNO',pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT," +
                "(case when pb.BillStatus='CANCELED' then 0 else (pb.TotAMT+pb.ScAmt) end)  as 'GROSSAMT'," +
                "(case when pb.BillStatus='CANCELED' then 0 else pb.NetAmt end) as 'NETAMT'," +
                "(case when pb.BillStatus='CANCELED' then 0 else pb.ScAmt end) as 'SCAMT',pb.GstNo as 'GstNo' from " +
                "(SELECT pb.[BILLNO],pb.BillStatus" +
                      ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
                  ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where (BILLDATE between '" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MMM/yyyy") + "') and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null   and (pb.Comany_id = " + company_id + ")))pb " +
                  "left join " +
                  "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;
                        }
                        else
                        {
                            sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO + (case when pb.BillStatus='CANCELED' then char(10) + '[ CANCELED ]' else '' end ),pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as 'CLIENT'," +
                 "(case when pb.BillStatus='CANCELED' then 0 else (pb.TotAMT+pb.ScAmt) end) as 'GROSSAMT'," +
                 "(case when pb.BillStatus='CANCELED' then 0 else pb.NetAmt end) as 'NETAMT'," +
                 "(case when pb.BillStatus='CANCELED' then 0 else pb.ScAmt end) as 'SCAMT',pb.GstNo as 'GstNo' from " +
                 "(SELECT pb.[BILLNO],pb.BillStatus" +
                       ",pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as Client " +
                   ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where (BILLDATE between '" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MMM/yyyy") + "') and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null  and (pb.Comany_id = " + company_id + ") and (pb.Location_ID in (Select Location_ID from tbl_Emp_Location where (Cliant_ID in (" + Item_Code + "))))))pb " +
                   "left join " +
                   "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;

                        }
                    }
                    else
                    {

                        if (chk_All_Client.Checked)
                        {
                            sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT,(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
                "(SELECT pb.[BILLNO]" +
                      ",pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
                  ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where (BILLNO between '" + bill_from + "' and '" + bill_to + "') and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null   and pb.Comany_id = " + company_id + " and pb.BillStatus = 'ACTIVE'))pb " +
                  "left join " +
                  "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;
                        }
                        else
                        {
                            sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as 'CLIENT',(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
                 "(SELECT pb.[BILLNO]" +
                       ",pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as Client " +
                   ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where (BILLNO between '" + bill_from + "' and '" + bill_to + "') and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null   and pb.Comany_id = " + company_id + " and (pb.Location_ID in (Select Location_ID from tbl_Emp_Location where (Cliant_ID in (" + Item_Code + ")))) and pb.BillStatus = 'ACTIVE'))pb " +
                   "left join " +
                   "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;

                        }
                    }
                    DataTable dtPaybill = clsDataAccess.RunQDTbl(sql);

                    int countPaybill = dtPaybill.Rows.Count;

                    dtPaybill.Columns.Add("CGST", typeof(double));
                    dtPaybill.Columns.Add("SGST", typeof(double));
                    dtPaybill.Columns.Add("IGST", typeof(double));
                    dtPaybill.Columns.Add("Total", typeof(double));
                    for (int i = 0; i < countPaybill; i++)
                    {
                        if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "LOCAL")
                        {
                            try
                            {
                                string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                                gstval = String.Format("{0:n}", (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2));

                                double sgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                                double cgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);

                                dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}",  (Convert.ToDouble(sgstVal)));
                                dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}",  (Convert.ToDouble(cgstVal)));
                                dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(0));

                                tsgst = tsgst + sgstVal;
                                tcgst = tcgst + cgstVal;
                            }
                            catch
                            { }
                        }
                        else if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "INTERSTATE")
                        {
                            try
                            {
                                string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                                double igstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                                tigst = tigst + igstVal;
                                gstval = String.Format("{0:n}", igstVal);
                                dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                                dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                                dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", (Convert.ToDouble(igstVal)));
                            }
                            catch
                            { }
                        }

                        double gstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                        tgst = tgst + gstVal;
                        dtPaybill.Rows[i]["GST"] = String.Format("{0:n}", (Convert.ToDouble(dtPaybill.Rows[i]["GST"])));
                        double grossVal = Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]);
                        tgrossamt = tgrossamt + grossVal;
                        dtPaybill.Rows[i]["GROSSAMT"] = String.Format("{0:n}",  (Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"])));
                        double netVal = Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"]);
                        tnetamt = tnetamt + netVal;
                        dtPaybill.Rows[i]["NETAMT"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"])));
                        double scVal = Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]);
                        //tscamt = tscamt + scVal;
                        //dtPaybill.Rows[i]["SCAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]));


                        roff_val = Convert.ToDouble(string.Format("{0:N}", Math.Round((Convert.ToInt32(dtPaybill.Rows[i]["GST"]) +
                    Convert.ToInt32(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToInt32(dtPaybill.Rows[i]["GROSSAMT"])) - (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) + Convert.ToDouble(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"])), 2)));
                        
                        dtPaybill.Rows[i]["Total"] = String.Format("{0:n}", roff_val);
                    }

                   // dtPaybill.Rows.Add();

                    DataTable dtCloned = dtPaybill.Clone();
                    dtCloned.Columns["BILLDATE"].DataType = typeof(String);
                    foreach (DataRow row in dtPaybill.Rows)
                    {
                        dtCloned.ImportRow(row);
                    }

                    //dtCloned.Rows[countPaybill]["BILLDATE"] = "";
                    //dtCloned.Rows[countPaybill]["BILLNO"] = "Grand Total";
                    ////dtCloned.Rows[countPaybill]["CLIENT & LOCATION"] = "Grand Total ";
                    //dtCloned.Rows[countPaybill]["CGST"] = String.Format("{0:n}", tcgst);
                    //dtCloned.Rows[countPaybill]["SGST"] = String.Format("{0:n}", tsgst);
                    //dtCloned.Rows[countPaybill]["IGST"] = String.Format("{0:n}", tigst);
                    //dtCloned.Rows[countPaybill]["GST"] = String.Format("{0:n}", tgst);
                    //dtCloned.Rows[countPaybill]["NETAMT"] = String.Format("{0:n}", tnetamt);
                    //dtCloned.Rows[countPaybill]["GROSSAMT"] = String.Format("{0:n}", tgrossamt);
                    ////dtCloned.Rows[countPaybill]["SCAMT"] = String.Format("{0:n}", tscamt);
                    if (rdbdtwise.Checked)
                    {
                        sub = "GST Bill Summary for the period " + dateTimePicker1.Value.ToString("dd/MM/yyyy");
                        sub = sub + " To " + dateTimePicker2.Value.ToString("dd/MM/yyyy");
                    }
                    else if (rbdVoucher.Checked)
                    {
                        sub = "GST Bill Summary Voucherwise (" + CmbSession.Text + ")";
                    }
                    else
                    {
                        if (cmbMonth.SelectedText.ToUpper() == "ALL")
                        {
                            sub = "GST Bill Summary During the Months of April - March (" + CmbSession.Text + ")";

                        }
                        else
                        {

                            sub = "GST Bill Summary For the Month of "+cmbMonth.SelectedText.ToUpper()+" (" + CmbSession.Text + ")";
                        }
                        //rdbmnthwise
                    }
                    MidasReport.Form1 bill = new MidasReport.Form1();
                    bill.prntgststmntrpt(cmbcompany.Text, coadd, sub, dtCloned);
                    bill.Show();

                }
            }
            else if (rdbZone.Checked == true)
            {
               string where1stclause = " (pb.Location_ID in (SELECT Location_ID FROM tbl_Emp_Location WHERE (zid ='" + cmbZone.ReturnValue + "')))";

                   if (CmbSession.Text.Trim() != "" && cmbMonth.Text.Trim() != "" && cmbcompany.Text.Trim() != "")
                   {
                       string[] StrLine = this.CmbSession.Text.Trim().Split('-');
                       string yr = ""; string mon = "", sql = "",  lastDayOfMonth = "";
                       Double tgst = 0, tsgst = 0, tcgst = 0, tigst = 0, tgrossamt = 0, tnetamt = 0;

            
                       if (chkCancel.Checked == true)
                       {
                           if (chk_All_Client.Checked == true)
                           {
                               sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO + (case when pb.BillStatus='CANCELED' then char(10) + '[ CANCELED ]' else '' end ) as 'BILLNO',(case when pb.BillStatus='CANCELED' then 0 else pb.ServiceAmount end) as 'GST',cwr.GSTTYPE,pb.Client as CLIENT," +
                   "(case when pb.BillStatus='CANCELED' then 0 else (pb.TotAMT+pb.ScAmt) end)  as 'GROSSAMT'," +
                   "(case when pb.BillStatus='CANCELED' then 0 else pb.NetAmt end) as 'NETAMT'," +
                   "(case when pb.BillStatus='CANCELED' then 0 else pb.ScAmt end) as 'SCAMT',pb.GstNo as 'GstNo' from " +
                   "(SELECT pb.[BILLNO],pb.BillStatus" +
                         ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
                     ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null   and (pb.Comany_id = " + company_id + ")))pb " +
                     "left join " +
                     "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;
                           }
                           else
                           {
                               sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO + (case when pb.BillStatus='CANCELED' then char(10) + '[ CANCELED ]' else '' end ),(case when pb.BillStatus='CANCELED' then 0 else pb.ServiceAmount end) as 'GST',cwr.GSTTYPE,pb.Client as 'CLIENT'," +
                    "(case when pb.BillStatus='CANCELED' then 0 else (pb.TotAMT+pb.ScAmt) end) as 'GROSSAMT'," +
                    "(case when pb.BillStatus='CANCELED' then 0 else pb.NetAmt end) as 'NETAMT'," +
                    "(case when pb.BillStatus='CANCELED' then 0 else pb.ScAmt end) as 'SCAMT',pb.GstNo as 'GstNo' from " +
                    "(SELECT pb.[BILLNO],pb.BillStatus" +
                          ",pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as Client " +
                      ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null  and (pb.Comany_id = " + company_id + ") and (pb.Location_ID in (Select Location_ID from tbl_Emp_Location where (Cliant_ID in (" + Item_Code + "))))))pb " +
                      "left join " +
                      "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;

                           }
                       }
                       else
                       {
                           if (chk_All_Client.Checked)
                           {
                               sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT,(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
                   "(SELECT pb.[BILLNO]" +
                         ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
                     ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null   and (pb.Comany_id = " + company_id + ") and pb.BillStatus = 'ACTIVE'))pb " +
                     "left join " +
                     "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;
                           }
                           else
                           {
                               sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as 'CLIENT',(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
                    "(SELECT pb.[BILLNO]" +
                          ",pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as Client " +
                      ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null  and (pb.Comany_id = " + company_id + ") and (pb.Location_ID in (Select Location_ID from tbl_Emp_Location where (Cliant_ID in (" + Item_Code + ")))) and pb.BillStatus = 'ACTIVE'))pb " +
                      "left join " +
                      "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;

                           }
                       }
                       DataTable dtPaybill = clsDataAccess.RunQDTbl(sql);

                       int countPaybill = dtPaybill.Rows.Count;

                       dtPaybill.Columns.Add("CGST", typeof(double));
                       dtPaybill.Columns.Add("SGST", typeof(double));
                       dtPaybill.Columns.Add("IGST", typeof(double));
                       dtPaybill.Columns.Add("Total", typeof(double));
                       double roff_val = 0;
                       for (int i = 0; i < countPaybill; i++)
                       {
                           if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "LOCAL")
                           {
                               try
                               {
                                   string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                                   gstval = String.Format("{0:n}", (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2));

                                   double sgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                                   double cgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);

                                   dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(sgstVal), 2));
                                   dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(cgstVal), 2));
                                   dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(0));

                                   tsgst = tsgst + sgstVal;
                                   tcgst = tcgst + cgstVal;
                               }
                               catch
                               { }
                           }
                           else if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "INTERSTATE")
                           {
                               try
                               {
                                   string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                                   double igstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                                   tigst = tigst + igstVal;
                                   gstval = String.Format("{0:n}", igstVal);
                                   dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                                   dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                                   dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(igstVal), 2));
                               }
                               catch
                               { }
                           }

                           double gstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                           tgst = tgst + gstVal;
                           // dtPaybill.Rows[i]["GST"] = String.Format("{0:n}",  Math.Round(Convert.ToDouble(dtPaybill.Rows[i]["GST"])));
                           double grossVal = Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]);
                           tgrossamt = tgrossamt + grossVal;
                           //dtPaybill.Rows[i]["GROSSAMT"] = String.Format("{0:n}",  Math.Round(Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"])));
                           double netVal = Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"]);
                           tnetamt = tnetamt + netVal;
                           dtPaybill.Rows[i]["NETAMT"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"])));
                           double scVal = Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]);
                           roff_val = Convert.ToDouble(string.Format("{0:N}", Math.Round((Convert.ToInt32(dtPaybill.Rows[i]["GST"]) +
                               Convert.ToInt32(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToInt32(dtPaybill.Rows[i]["GROSSAMT"])) - (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) + Convert.ToDouble(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"])), 2)));
                           //tscamt = tscamt + scVal;
                           //dtPaybill.Rows[i]["SCAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]));
                           dtPaybill.Rows[i]["Total"] = String.Format("{0:n}", roff_val);
                       }

                       // dtPaybill.Rows.Add();

                       DataTable dtCloned = dtPaybill.Clone();
                       dtCloned.Columns["BILLDATE"].DataType = typeof(String);
                       foreach (DataRow row in dtPaybill.Rows)
                       {
                           dtCloned.ImportRow(row);
                       }
                      
                       sub = "GST Bill Summary zone [" + cmbZone.Text + "] For the Session " + CmbSession.Text ;
                       sub = sub + " To " + dateTimePicker2.Value.ToString("dd/MM/yyyy");
                       MidasReport.Form1 bill = new MidasReport.Form1();
                       bill.prntgststmntrpt(cmbcompany.Text, coadd, sub, dtCloned);
                       bill.Show();

                   }
               }

            

                else if (rdbmnthwise.Checked)
                {

                    string[] StrLine = this.CmbSession.Text.Trim().Split('-');
                    string yr = ""; string mon = "", sql = "", where1stclause = "", lastDayOfMonth = "";
                    Double tgst = 0, tsgst = 0, tcgst = 0, tigst = 0, tgrossamt = 0, tnetamt = 0, roff_val=0;


                    if (rdbSession.Checked == true)
                    {
                        ar[0] = "April";
                        ar[1] = "May";
                        ar[2] = "June";
                        ar[3] = "July";
                        ar[4] = "August";
                        ar[5] = "September";
                        ar[6] = "October";
                        ar[7] = "November";
                        ar[8] = "December";
                        ar[9] = "January";
                        ar[10] = "February";
                        ar[11] = "March";
                    }
                    else
                    {
                        ar[0] = cmbMonth.SelectedItem.ToString();
                    }
                    billdt.Clear();

                    int ind_ar = 0;
                    if (rdbMonth.Checked == true)
                    {
                        ind_ar = 1;
                    }
                    else if (rdbBDMonth.Checked == true)
                    {
                        ind_ar = 1;
                    }
                    else
                    {
                        ind_ar = ar.Length;
                    }

                    //RADIO BUTTON CHECKING
                    if (rdbMonth.Checked == true)
                    {
                        int mnval = 0;
                        if (cmbMonth.SelectedIndex > 9)
                        {
                            mnval = (cmbMonth.SelectedIndex) - 9;
                            yr = StrLine[1].Trim();
                        }
                        else if (cmbMonth.SelectedIndex <= 9)
                        {
                            mnval = cmbMonth.SelectedIndex + 3;
                            yr = StrLine[0].Trim();
                            
                        }
                        else if (cmbMonth.SelectedIndex == 0)
                        {
                            mnval = 0;
                            yr = "";
                            EDPMessageBox.EDPMessage.Show("Please Select a particular month.");
                            return;
                        }

                        where1stclause = "pb.Month = '" + cmbMonth.Text + " - " + yr + "'";
                    }
                    else if (rdbBDMonth.Checked == true)
                    {
                        int mnval = 0;
                        if (cmbMonth.SelectedIndex > 9)
                        {
                            mnval = (cmbMonth.SelectedIndex) - 9;
                            yr = StrLine[1].Trim();
                        }
                        else if (cmbMonth.SelectedIndex <= 9)
                        {
                            mnval = cmbMonth.SelectedIndex + 3;
                            yr = StrLine[0].Trim();
                        }
                        else if (cmbMonth.SelectedIndex == 0)
                        {
                            mnval = 0;
                            yr = "";
                            EDPMessageBox.EDPMessage.Show("Please Select a particular month.");
                            return;
                        }

                        lastDayOfMonth = DateTime.DaysInMonth(Convert.ToInt32(yr), mnval).ToString(); ;
                        where1stclause = "";

                        where1stclause = "pb.BILLDATE between '" + yr + "-" + mnval + "-01' and '" + yr + "-" + mnval + "-" + lastDayOfMonth + "'";
                        lastDayOfMonth = "";
                        mnval = 0;
                        yr = "";
                    }
                    
                    else
                    {
                        lastDayOfMonth = DateTime.DaysInMonth(Convert.ToInt32(StrLine[1]), 3).ToString();
                        where1stclause = "pb.BILLDATE between '" + StrLine[0] + "-" + "04" + "-01' and '" + StrLine[1] + "-" + "03" + "-" + lastDayOfMonth + "'";
                    }

                    if (chkCancel.Checked == true)
                    {
                        if (chk_All_Client.Checked == true)
                        {
                            sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO + (case when pb.BillStatus='CANCELED' then char(10) + '[ CANCELED ]' else '' end ) as 'BILLNO',pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT," +
                "(case when pb.BillStatus='CANCELED' then 0 else (pb.TotAMT+pb.ScAmt) end)  as 'GROSSAMT'," +
                "(case when pb.BillStatus='CANCELED' then 0 else pb.NetAmt end) as 'NETAMT'," +
                "(case when pb.BillStatus='CANCELED' then 0 else pb.ScAmt end) as 'SCAMT',pb.GstNo as 'GstNo' from " +
                "(SELECT pb.[BILLNO],pb.BillStatus" +
                      ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
                  ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (Session='" + CmbSession.Text + "') and (pb.isGST is not null  and pb.Comany_id = " + company_id + " and pb.BillStatus = 'ACTIVE'))pb " +
                  "left join " +
                  "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null";
                        }
                        else
                        {
                            sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO + (case when pb.BillStatus='CANCELED' then char(10) + '[ CANCELED ]' else '' end ),pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as 'CLIENT'," +
                 "(case when pb.BillStatus='CANCELED' then 0 else (pb.TotAMT+pb.ScAmt) end) as 'GROSSAMT'," +
                 "(case when pb.BillStatus='CANCELED' then 0 else pb.NetAmt end) as 'NETAMT'," +
                 "(case when pb.BillStatus='CANCELED' then 0 else pb.ScAmt end) as 'SCAMT',pb.GstNo as 'GstNo' from " +
                 "(SELECT pb.[BILLNO],pb.BillStatus" +
                       ",pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as Client " +
                   ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb  where " + where1stclause + " and (Session='" + CmbSession.Text + "') and (pb.isGST is not null  and pb.Comany_id = " + company_id + " and pb.BillStatus = 'ACTIVE'))pb " +
                  "left join " +
                  "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null";

                        }
                    }
                    else
                    {
                        if (chk_All_Client.Checked)
                        {
                            sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT,(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
                "(SELECT pb.[BILLNO]" +
                      ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id =pb.Cliant_ID )+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
                  ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (Session='" + CmbSession.Text + "') and (pb.isGST is not null  and pb.Comany_id = " + company_id + " and pb.BillStatus = 'ACTIVE'))pb " +
                  "left join " +
                  "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null";
                        }
                        else
                        {
                            sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT,(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
                    "(SELECT pb.[BILLNO]" +
                          ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id =pb.cliant_ID )+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
                      ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (Session='" + CmbSession.Text + "') and (pb.isGST is not null  and pb.Comany_id = " + company_id + "  and (pb.Location_ID in (Select Location_ID from tbl_Emp_Location where (Cliant_ID in (" + Item_Code + ")))) and pb.BillStatus = 'ACTIVE'))pb " +
                      "left join " +
                      "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null";
                        }
                    }
                    DataTable dtPaybill = clsDataAccess.RunQDTbl(sql);

                    int countPaybill = dtPaybill.Rows.Count;

                    dtPaybill.Columns.Add("CGST", typeof(double));
                    dtPaybill.Columns.Add("SGST", typeof(double));
                    dtPaybill.Columns.Add("IGST", typeof(double));
                    dtPaybill.Columns.Add("Total", typeof(double));
                    for (int i = 0; i < countPaybill; i++)
                    {
                        if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "LOCAL")
                        {
                            try
                            {
                                string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                                gstval = String.Format("{0:n}", (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2));

                                double sgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                                double cgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);

                                dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", (Convert.ToDouble(sgstVal)));
                                dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}",  (Convert.ToDouble(cgstVal)));
                                dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(0));

                                tsgst = tsgst + sgstVal;
                                tcgst = tcgst + cgstVal;
                            }
                            catch
                            { }
                        }
                        else if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "INTERSTATE")
                        {
                            try
                            {
                                string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                                double igstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                                tigst = tigst + igstVal;
                                gstval = String.Format("{0:n}", igstVal);
                                dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                                dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                                dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}",  (Convert.ToDouble(igstVal)));
                            }
                            catch
                            { }
                        }

                        double gstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                        tgst = tgst + gstVal;
                        dtPaybill.Rows[i]["GST"] = String.Format("{0:n}",  (Convert.ToDouble(dtPaybill.Rows[i]["GST"])));
                        double grossVal = Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]);
                        tgrossamt = tgrossamt + grossVal;
                        dtPaybill.Rows[i]["GROSSAMT"] = String.Format("{0:n}", (Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"])));
                        double netVal = Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"]);
                        tnetamt = tnetamt + netVal;
                        dtPaybill.Rows[i]["NETAMT"] = String.Format("{0:n}",  Math.Round(Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"])));
                        double scVal = Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]);
                        //tscamt = tscamt + scVal;
                        //dtPaybill.Rows[i]["SCAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]));
                        roff_val = Convert.ToDouble(string.Format("{0:N}", Math.Round((Convert.ToInt32(dtPaybill.Rows[i]["GST"]) +
                   Convert.ToInt32(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToInt32(dtPaybill.Rows[i]["GROSSAMT"])) - (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) + Convert.ToDouble(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"])), 2)));

                        dtPaybill.Rows[i]["Total"] = String.Format("{0:n}", roff_val);
                    }

                    //dtPaybill.Rows.Add();

                    DataTable dtCloned = dtPaybill.Clone();
                    dtCloned.Columns["BILLDATE"].DataType = typeof(String);
                    foreach (DataRow row in dtPaybill.Rows)
                    {
                        dtCloned.ImportRow(row);
                    }

                    //dtCloned.Rows[countPaybill]["BILLDATE"] = " ";
                    //dtCloned.Rows[countPaybill]["BILLNO"] = "Grand Total ";
                    ////dtCloned.Rows[countPaybill]["CLIENT & LOCATION"] = "Grand Total ";
                    //dtCloned.Rows[countPaybill]["CGST"] = String.Format("{0:n}", tcgst);
                    //dtCloned.Rows[countPaybill]["SGST"] = String.Format("{0:n}", tsgst);
                    //dtCloned.Rows[countPaybill]["IGST"] = String.Format("{0:n}", tigst);
                    //dtCloned.Rows[countPaybill]["GST"] = String.Format("{0:n}", tgst);
                    //dtCloned.Rows[countPaybill]["NETAMT"] = String.Format("{0:n}", tnetamt);
                    //dtCloned.Rows[countPaybill]["GROSSAMT"] = String.Format("{0:n}", tgrossamt);
                    ////dtCloned.Rows[countPaybill]["SCAMT"] = String.Format("{0:n}", tscamt);


                    sub = "GST Bill Summary During the period " ;
                   
                    MidasReport.Form1 bill = new MidasReport.Form1();
                    bill.prntgststmntrpt(cmbcompany.Text, coadd, sub + "  " + cmbMonth.Text + " , " + dateTimePicker2.Value.ToString("yyyy"), dtCloned);
                    bill.Show(); 
                }

                else
                {
                    EDPMessageBox.EDPMessage.Show("Please select session,month,company first.");
                
                }

            }
        

        private void GSTRpt()
        {
            string[] StrLine = this.CmbSession.Text.Trim().Split('-');
            string yr = ""; string mon = "", sql = "", where1stclause = "", lastDayOfMonth = "";
            Double tgst = 0, tsgst = 0, tcgst = 0, tigst = 0, tgrossamt = 0, tnetamt = 0;


            if (rdbSession.Checked == true)
            {
                ar[0] = "April";
                ar[1] = "May";
                ar[2] = "June";
                ar[3] = "July";
                ar[4] = "August";
                ar[5] = "September";
                ar[6] = "October";
                ar[7] = "November";
                ar[8] = "December";
                ar[9] = "January";
                ar[10] = "February";
                ar[11] = "March";
            }
            else
            {
                ar[0] = cmbMonth.SelectedItem.ToString();
            }
            billdt.Clear();

            int ind_ar = 0;
            if (rdbMonth.Checked == true)
            {
                ind_ar = 1;
            }
            else if (rdbBDMonth.Checked == true)
            {
                ind_ar = 1;
            }
            else
            {
                ind_ar = ar.Length;
            }
            
            //RADIO BUTTON CHECKING
            if (rdbMonth.Checked == true)
            {
                int mnval = 0;
                if (cmbMonth.SelectedIndex > 9)
                {
                    mnval = (cmbMonth.SelectedIndex) - 9;
                    yr = StrLine[1].Trim();
                }
                else if (cmbMonth.SelectedIndex <= 9)
                {
                    mnval = cmbMonth.SelectedIndex + 3;
                    yr = StrLine[0].Trim();
                }
                else if (cmbMonth.SelectedIndex == 0)
                {
                    mnval = 0;
                    yr = "";
                    EDPMessageBox.EDPMessage.Show("Please Select a particular month.");
                    return;
                }

                where1stclause = "pb.Month = '"+cmbMonth.Text+" - "+yr+"'";
            }
            else if (rdbBDMonth.Checked == true)
            {
                int mnval = 0;
                if (cmbMonth.SelectedIndex > 9)
                {
                    mnval = (cmbMonth.SelectedIndex) - 9;
                    yr = StrLine[1].Trim();
                }
                else if (cmbMonth.SelectedIndex <= 9)
                {
                    mnval = cmbMonth.SelectedIndex + 3;
                    yr = StrLine[0].Trim();
                }
                else if (cmbMonth.SelectedIndex == 0)
                {
                    mnval = 0;
                    yr = "";
                    EDPMessageBox.EDPMessage.Show("Please Select a particular month.");
                    return;
                }

                lastDayOfMonth = DateTime.DaysInMonth(Convert.ToInt32(yr), mnval).ToString(); ;
                where1stclause = "";

                where1stclause = "pb.BILLDATE between '" + yr + "-" + mnval + "-01' and '" + yr + "-" + mnval + "-"+lastDayOfMonth+"'";
                lastDayOfMonth = "";
                mnval = 0;
                yr = "";
            }
            else
            {
                lastDayOfMonth = DateTime.DaysInMonth(Convert.ToInt32(StrLine[1]), 3).ToString();
                where1stclause = "pb.BILLDATE between '" + StrLine[0] + "-" + "04" + "-01' and '" + StrLine[1] + "-" + "03" + "-" + lastDayOfMonth + "'";
            }

            sql = "select pb.BILLDATE,pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT,(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT' from " +
"(SELECT pb.[BILLNO]" +
      ",cast(convert(char(11), pb.[BILLDATE], 105) as VARCHAR) as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
  "FROM [paybill] pb where " + where1stclause + " and (pb.isGST is not null and pb.isGST != '0'  and pb.Comany_id = " + company_id + " and pb.BillStatus = 'ACTIVE'))pb " +
  "left join " +
  "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null";

            DataTable dtPaybill = clsDataAccess.RunQDTbl(sql);

            int countPaybill = dtPaybill.Rows.Count;

            dtPaybill.Columns.Add("CGST", typeof(string));
            dtPaybill.Columns.Add("SGST", typeof(string));
            dtPaybill.Columns.Add("IGST", typeof(string));

            for (int i = 0; i < countPaybill; i++)
            {
                if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "LOCAL")
                {
                    try
                    {
                        string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                        gstval = String.Format("{0:n}", (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2));
                        dtPaybill.Rows[i]["CGST"] = gstval;
                        dtPaybill.Rows[i]["SGST"] = gstval;

                        double sgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                        double cgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                        tsgst = tsgst + sgstVal;
                        tcgst = tcgst + cgstVal;
                    }
                    catch
                    { }
                }
                else if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "INTERSTATE")
                {
                    try
                    {
                        string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                        double igstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                        tigst = tigst + igstVal;
                        gstval = String.Format("{0:n}", igstVal);
                        dtPaybill.Rows[i]["IGST"] = gstval;
                    }
                    catch
                    { }
                }

                double gstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                tgst = tgst + gstVal;
                dtPaybill.Rows[i]["GST"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                double grossVal = Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]);
                tgrossamt = tgrossamt + grossVal;
                dtPaybill.Rows[i]["GROSSAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]));
                double netVal = Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"]);
                tnetamt = tnetamt + netVal;
                dtPaybill.Rows[i]["NETAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"]));
                double scVal = Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]);
                //tscamt = tscamt + scVal;
                //dtPaybill.Rows[i]["SCAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]));

            }

            dtPaybill.Rows.Add();

            DataTable dtCloned = dtPaybill.Clone();
            dtCloned.Columns["BILLDATE"].DataType = typeof(String);
            foreach (DataRow row in dtPaybill.Rows)
            {
                dtCloned.ImportRow(row);
            }

            dtCloned.Rows[countPaybill]["BILLDATE"] = "Total :";
            dtCloned.Rows[countPaybill]["BILLNO"] = countPaybill + " no of Bills";
            dtCloned.Rows[countPaybill]["CGST"] = String.Format("{0:n}", tcgst);
            dtCloned.Rows[countPaybill]["SGST"] = String.Format("{0:n}", tsgst);
            dtCloned.Rows[countPaybill]["IGST"] = String.Format("{0:n}", tigst);
            dtCloned.Rows[countPaybill]["GST"] = String.Format("{0:n}", tgst);
            dtCloned.Rows[countPaybill]["NETAMT"] = String.Format("{0:n}", tnetamt);
            dtCloned.Rows[countPaybill]["GROSSAMT"] = String.Format("{0:n}", tgrossamt);
            //dtCloned.Rows[countPaybill]["SCAMT"] = String.Format("{0:n}", tscamt);


            sub = "GST Bill Summary During the period From " + dateTimePicker1.Value.ToString("dd/MM/yyyy");
            sub = sub + " To " + dateTimePicker2.Value.ToString("dd/MM/yyyy");
            MidasReport.Form1 bill = new MidasReport.Form1();
            bill.prntgststmntrpt(cmbcompany.Text,coadd,CmbSession.Text+ " " + cmbMonth.Text,dtCloned);
            bill.Show();
        }

        //private void STRpt()
        //{
        //    //DataTable dtdate = clsDataAccess.RunQDTbl("select distinct Month(dateofjoining) as mnth from tbl_employee_mast");
        //    string[] StrLine = this.CmbSession.Text.Trim().Split('-');
        //    string yr = ""; string mon = "", sql = "";
        //    if (rdbSession.Checked == true)
        //    {
        //        ar[0] = "April";
        //        ar[1] = "May";
        //        ar[2] = "June";
        //        ar[3] = "July";
        //        ar[4] = "August";
        //        ar[5] = "September";
        //        ar[6] = "October";
        //        ar[7] = "November";
        //        ar[8] = "December";
        //        ar[9] = "January";
        //        ar[10] = "February";
        //        ar[11] = "March";
        //    }
        //    else
        //    {
        //        ar[0] = cmbMonth.SelectedItem.ToString();
        //    }
        //    billdt.Clear();

        //    int ind_ar = 0;
        //    if (rdbMonth.Checked == true)
        //    {
        //        ind_ar = 1;
        //    }
        //    else if (rdbBDMonth.Checked == true)
        //    {
        //        ind_ar = 1;
        //    }
        //    else
        //    {
        //        ind_ar = ar.Length;
        //    }
        //    for (int i = 0; i < ind_ar; i++)
        //    {
        //        if (i > 8)
        //            yr = StrLine[1].ToString();
        //        else
        //            yr = StrLine[0].ToString();

        //        mon = ar[i].ToString() + " - " + yr;

        //        //  DataTable dt = clsDataAccess.RunQDTbl("select (select sum(d.billamt) from paybilld d where session='" + CmbSession.Text + "' and month='" + mon +"')as monthly_Amt, d.Billno,d.Billdate,d.billamt,"+
        //        //"(SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE (Client_id = l.Cliant_ID)) + '  -  ' + l.location_name as location_Name,t.designationname,d.hour,d.attendance,d.monthdays,d.rate " +
        //        //"from tbl_employee_designationmaster t ,Tbl_emp_location l,paybilld d where l.location_id=d.location_id and t.slno=d.desig_id and session='" + CmbSession.Text + "'and month='" + mon + "' and company_id=" + company_id);
        //        if (rdbBDMonth.Checked == true)
        //        {
        //            sql = "SELECT MONTH AS Attendance,(select sum(TotAMT+ ServiceAmount + ScAmt) from paybill " +
        //                  "where ((DATENAME(mm,BillDate)+' - '+DATENAME(YYYY,BILLDATE)) ='" + mon + "') group by (DATENAME(mm,BillDate)+' - '+DATENAME(YYYY,BILLDATE)))AS monthly_Amt,d.BILLNO, d.BILLDATE,d.TotAMT as Designationname,d.ScAmt as MonthDays," +
        //                  "d.ServiceAmount as Hour,(TotAMT+ ServiceAmount+ ScAmt) as BillAmt,(select (SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE " +
        //                  "(Client_id = l.Cliant_ID)) + '  -  ' + l.Location_Name from tbl_Emp_Location AS l where " +
        //                  " d.Location_ID = l.Location_ID) AS location_Name FROM paybill as d  where ((DATENAME(mm,BillDate)+' - '+DATENAME(YYYY,BILLDATE)) ='" + mon + "') and BillStatus = 'ACTIVE' order by BILLDATE, BILLNO";      //and BillStatus = 'ACTIVE'  HAS BEEN ADDED BY DWIPRAJ DUTTA 24102017


        //        }
        //        else
        //        {
        //            sql = "SELECT MONTH AS Attendance,(select sum(TotAMT+ ServiceAmount + ScAmt) from paybill " +
        //               "where BILLNO=d.BILLNO group by MONTH,session)AS monthly_Amt,d.BILLNO, d.BILLDATE,d.TotAMT as Designationname,d.ScAmt as MonthDays," +
        //               "d.ServiceAmount as Hour,(TotAMT+ ServiceAmount+ ScAmt) as BillAmt,(select (SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE " +
        //               "(Client_id = l.Cliant_ID)) + '  -  ' + l.Location_Name from tbl_Emp_Location AS l where " +
        //               " d.Location_ID = l.Location_ID) AS location_Name FROM paybill as d  where (MONTH ='" + mon + "') and (Session='" + this.CmbSession.Text.Trim() + "') and BillStatus = 'ACTIVE' order by BILLDATE, BILLNO";      //and BillStatus = 'ACTIVE'  HAS BEEN ADDED BY DWIPRAJ DUTTA 24102017
        //        }

        //        DataTable dt = clsDataAccess.RunQDTbl(sql);

        //        billdt.Merge(dt);
        //    }
        //    MidasReport.Form1 bill = new MidasReport.Form1();
        //    if (ind_ar == 1)
        //    {
        //        bill.Bill_Report(cmbcompany.Text, CmbSession.Text, billdt, coadd);
        //    }
        //    else
        //    {
        //        bill.Bill_ReportO(cmbcompany.Text, CmbSession.Text, billdt);
        //    }
        //    try
        //    {
        //        bill.Show();
        //    }
        //    catch { }
        //}




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rdbSession_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMonth.Checked==true || rdbBDMonth.Checked==true)
            {
                cmbMonth.SelectedIndex = 1;

            }
            else if (rdbSession.Checked == true)
            {
                cmbMonth.SelectedIndex = 0;
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonth.Text.ToLower() == "all")
            {
                rdbSession.Enabled = true;
                rdbMonth.Enabled = false;
                rdbBDMonth.Enabled = false;
                
                rdbSession.Checked = true;
            }
            else
            {
                rdbSession.Enabled = false;
                rdbMonth.Enabled = true;
                rdbBDMonth.Enabled = true;
                
                rdbMonth.Checked = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbTypOfTax_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rdbdtwise_CheckedChanged(object sender, EventArgs e)
        {
           
            if (rdbmnthwise.Checked)
            {
                grp_month.Visible = true;
                grp_bill.Visible = false;
                grp_period.Visible = false;
                //dateTimePicker1.Enabled = false;
                //dateTimePicker2.Enabled = false;
                ////label3.Enabled = false;
                ////label4.Enabled = false;
                groupBox1.Enabled = true;
                cmbMonth.Enabled = true;
                grp_zone.Visible = false;

            }
            else if (rbdVoucher.Checked == true)
            {
                grp_month.Visible = false;
                grp_bill.Visible = true;
                grp_period.Visible = false;
                cmbMonth.Enabled = false;
                groupBox1.Enabled = false;
                grp_zone.Visible = false;
            }
            else if (rdbZone.Checked == true)
            {
                grp_zone.Visible = true;
                cmbZone.Visible = true;

                grp_month.Visible = false;
                grp_bill.Visible = false;
                grp_period.Visible = false;
                cmbMonth.Enabled = false;
                groupBox1.Enabled = false;
            }
            else
            {
                grp_zone.Visible = false;
                grp_month.Visible = false;
                grp_bill.Visible = false;
                grp_period.Visible = true;
                //dateTimePicker1.Enabled = true;
                //dateTimePicker2.Enabled = true;
                ////label3.Enabled = true;
                ////label4.Enabled = true;
                cmbMonth.Enabled = false;
                groupBox1.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_All_Client.Checked)
            {
                btnclient.Enabled = false;


            }
            else
            {
                btnclient.Enabled = true;
            }

        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            try
            {


                string sqlstmnt = "SELECT Client_Name AS ClientName, Client_id AS ID, coid AS ID1  FROM tbl_Employee_CliantMaster";
                EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Client", "Select Client", 0, "CMPN", 0);

                arritem.Clear();
                arritem = EDPCommon.arr_mod;

                if (arritem.Count > 0)
                {
                    getcode_item.Clear();
                    arritem = EDPCommon.arr_mod;
                    getcode_item = EDPCommon.get_code;
                    //lblproduct.Items.Clear();
                    Item_Code ="";
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
                        if (Item_Code == "")
                        {
                            Item_Code = "'" + getcode_item[i].ToString() + "'";
                        }
                        else
                        {
                            Item_Code = Item_Code + ",'" + getcode_item[i].ToString() + "'";
                        }

                    }


                }


            }
            catch { }

        }

        private void CmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] StrLine = this.CmbSession.Text.Trim().Split('-');

            dateTimePicker1.Value =Convert.ToDateTime ("01/April/" + StrLine[0]);
            dateTimePicker2.Value = Convert.ToDateTime("31/March/" + StrLine[1]);
        }


        private void cmbBill_from_DropDown(object sender, EventArgs e)
        {

            DataTable dt = clsDataAccess.RunQDTbl("Select BILLNO,BILLDATE,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client - Location'  from paybill pb WHERE (Session = '" + CmbSession.Text + "') and (Comany_id='" + company_id + "') ORDER BY BILLNO,BILLDATE");
            if (dt.Rows.Count > 0)
            {
                cmbBill_from.LookUpTable = dt;
                cmbBill_from.ReturnIndex = 0;
            }
        }

        private void cmbBill_To_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select BILLNO,BILLDATE,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client - Location'  from paybill pb WHERE (Session = '" + CmbSession.Text + "') and (Comany_id='" + company_id + "') ORDER BY BILLNO,BILLDATE");
            if (dt.Rows.Count > 0)
            {
                cmbBill_To.LookUpTable = dt;
                cmbBill_To.ReturnIndex = 0;
            }
        }
        string bill_from = "", bill_to = "";
        private void cmbBill_from_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if ((cmbBill_from.ReturnValue != null) && (cmbBill_from.ReturnValue != ""))
                bill_from = Convert.ToString(cmbBill_from.ReturnValue);

            cmbBill_To.Text = bill_from;
            bill_to = bill_from;
        }

        private void cmbBill_To_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if ((cmbBill_To.ReturnValue != null) && (cmbBill_To.ReturnValue != ""))
                bill_to = Convert.ToString(cmbBill_To.ReturnValue);


        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            DataTable dtPaybill = new DataTable();
            DataTable dtexpExcel = new DataTable();
            DataTable dtRcpt = new DataTable();

            double roff_val = 0,tot_roff=0;
            string ord = "";
            if (rdb_ord_Date.Checked == true)
            {
                ord = "order by pb.BILLDATE";
            }
            else if (rdb_ord_bill.Checked == true)
            {
                ord = "order by pb.BILLNO, pb.BILLDATE";
            }
            else if (rdb_ord_party.Checked == true)
            {
                ord = "order by Client,pb.BILLDATE,pb.BILLNO";
            }

            if (rdbdtwise.Checked)
            {
                if (CmbSession.Text.Trim() != "" && cmbMonth.Text.Trim() != "" && cmbcompany.Text.Trim() != "")
                {
                    string[] StrLine = this.CmbSession.Text.Trim().Split('-');
                    string sql = "";
                    Double tgst = 0, tsgst = 0, tcgst = 0, tigst = 0, tgrossamt = 0, tnetamt = 0;
                    tot_roff = 0;
                    roff_val = 0;

                    if (chk_All_Client.Checked)
                    {
                        sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT,(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
            "(SELECT pb.[BILLNO]" +
                  ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
              ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where (BILLDATE between '" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MMM/yyyy") + "') and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null and pb.Comany_id = " + company_id + " and pb.BillStatus = 'ACTIVE'))pb " +
              "left join " +
              "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null order by pb.BILLDATE,pb.BILLNO";
                    }
                    else
                    {
                        sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as 'CLIENT',(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
             "(SELECT pb.[BILLNO]" +
                   ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as Client " +
               ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where (BILLDATE between '" + dateTimePicker1.Value.ToString("dd/MMM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MMM/yyyy") + "') and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null and pb.Comany_id = " + company_id + " and (pb.Location_ID in (Select Location_ID from tbl_Emp_Location where (Cliant_ID in (" + Item_Code + ")))) and pb.BillStatus = 'ACTIVE'))pb " +
               "left join " +
               "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null order by pb.BILLDATE,pb.BILLNO";

                    }

                    dtPaybill = clsDataAccess.RunQDTbl(sql);

                    int countPaybill = dtPaybill.Rows.Count;

                    dtPaybill.Columns.Add("CGST", typeof(double));
                    dtPaybill.Columns.Add("SGST", typeof(double));
                    dtPaybill.Columns.Add("IGST", typeof(double));
                    dtPaybill.Columns.Add("ROFF", typeof(double));

                    for (int i = 0; i < countPaybill; i++)
                    {
                        if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "LOCAL")
                        {
                            try
                            {
                                string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                                gstval = String.Format("{0:n}", (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2));

                                double sgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                                double cgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);

                                dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(sgstVal));
                                dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(cgstVal));
                                dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(0));

                                tsgst = tsgst + sgstVal;
                                tcgst = tcgst + cgstVal;
                            }
                            catch
                            { }
                        }
                        else if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "INTERSTATE")
                        {
                            try
                            {
                                string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                                double igstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                                tigst = tigst + igstVal;
                                gstval = String.Format("{0:n}", igstVal);
                                dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                                dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                                dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(igstVal));
                            }
                            catch
                            { }
                        }
                        else
                        {
                            dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                            dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                            dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                        }

                        double gstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                        tgst = tgst + gstVal;
                        dtPaybill.Rows[i]["GST"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                        double grossVal = Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]);
                        tgrossamt = tgrossamt + grossVal;
                        dtPaybill.Rows[i]["GROSSAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]));
                        double netVal = Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"]);
                        tnetamt = tnetamt + netVal;
                        dtPaybill.Rows[i]["NETAMT"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"])));
                        double scVal = Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]);
                        //tscamt = tscamt + scVal;
                        //dtPaybill.Rows[i]["SCAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]));
                        roff_val = Convert.ToDouble(string.Format("{0:N}", Math.Round((Convert.ToInt32(dtPaybill.Rows[i]["GST"]) +
                   Convert.ToInt32(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToInt32(dtPaybill.Rows[i]["GROSSAMT"])) - (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) + Convert.ToDouble(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"])), 2)));
                        dtPaybill.Rows[i]["ROFF"] = roff_val;
                        tot_roff = tot_roff + roff_val;
                    }

                    dtPaybill.Rows.Add();

                    //DataTable dtCloned = dtPaybill.Clone();
                    //dtCloned.Columns["BILLDATE"].DataType = typeof(String);
                    //foreach (DataRow row in dtPaybill.Rows)
                    //{
                    //    dtCloned.ImportRow(row);
                    //}

                    dtPaybill.Rows[countPaybill]["BILLDATE"] = "";
                    dtPaybill.Rows[countPaybill]["BILLNO"] = "Grand Total";
                    //dtCloned.Rows[countPaybill]["CLIENT & LOCATION"] = "Grand Total ";
                    dtPaybill.Rows[countPaybill]["CGST"] = String.Format("{0:n}", tcgst);
                    dtPaybill.Rows[countPaybill]["SGST"] = String.Format("{0:n}", tsgst);
                    dtPaybill.Rows[countPaybill]["IGST"] = String.Format("{0:n}", tigst);
                    dtPaybill.Rows[countPaybill]["GST"] = String.Format("{0:n}", tgst);
                    dtPaybill.Rows[countPaybill]["NETAMT"] = String.Format("{0:n}", tnetamt);
                    dtPaybill.Rows[countPaybill]["GROSSAMT"] = String.Format("{0:n}", tgrossamt);
                    //dtCloned.Rows[countPaybill]["SCAMT"] = String.Format("{0:n}", tscamt);
                    dtPaybill.Rows[countPaybill]["ROFF"] = String.Format("{0:n}", tot_roff);
                    sub = "Bill Summary During the period From " + dateTimePicker1.Value.ToString("dd/MM/yyyy");
                    sub = sub + " To " + dateTimePicker2.Value.ToString("dd/MM/yyyy");
                    //MidasReport.Form1 bill = new MidasReport.Form1();
                    //bill.prntgststmntrpt(cmbcompany.Text, coadd, sub, dtCloned);
                    //bill.Show();

                }
            }

            else if (rdbZone.Checked)
            {
                string where1stclause = " (pb.Location_ID in (SELECT Location_ID FROM tbl_Emp_Location WHERE (zid ='" + cmbZone.ReturnValue + "')))";

                if (CmbSession.Text.Trim() != "" && cmbMonth.Text.Trim() != "" && cmbcompany.Text.Trim() != "")
                {
                    string[] StrLine = this.CmbSession.Text.Trim().Split('-');
                    string yr = ""; string mon = "", sql = "";
                    Double tgst = 0, tsgst = 0, tcgst = 0, tigst = 0, tgrossamt = 0, tnetamt = 0;


                    if (chkCancel.Checked == true)
                    {
                        if (chk_All_Client.Checked == true)
                        {
                            sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO + (case when pb.BillStatus='CANCELED' then char(10) + '[ CANCELED ]' else '' end ) as 'BILLNO',(case when pb.BillStatus='CANCELED' then 0 else pb.ServiceAmount end) as 'GST',cwr.GSTTYPE,pb.Client as CLIENT," +
                "(case when pb.BillStatus='CANCELED' then 0 else (pb.TotAMT+pb.ScAmt) end)  as 'GROSSAMT'," +
                "(case when pb.BillStatus='CANCELED' then 0 else pb.NetAmt end) as 'NETAMT'," +
                "(case when pb.BillStatus='CANCELED' then 0 else pb.ScAmt end) as 'SCAMT',pb.GstNo as 'GstNo' from " +
                "(SELECT pb.[BILLNO],pb.BillStatus" +
                      ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
                  ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null   and (pb.Comany_id = " + company_id + ")))pb " +
                  "left join " +
                  "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;
                        }
                        else
                        {
                            sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO + (case when pb.BillStatus='CANCELED' then char(10) + '[ CANCELED ]' else '' end ),(case when pb.BillStatus='CANCELED' then 0 else pb.ServiceAmount end) as 'GST',cwr.GSTTYPE,pb.Client as 'CLIENT'," +
                 "(case when pb.BillStatus='CANCELED' then 0 else (pb.TotAMT+pb.ScAmt) end) as 'GROSSAMT'," +
                 "(case when pb.BillStatus='CANCELED' then 0 else pb.NetAmt end) as 'NETAMT'," +
                 "(case when pb.BillStatus='CANCELED' then 0 else pb.ScAmt end) as 'SCAMT',pb.GstNo as 'GstNo' from " +
                 "(SELECT pb.[BILLNO],pb.BillStatus" +
                       ",pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as Client " +
                   ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null  and (pb.Comany_id = " + company_id + ") and (pb.Location_ID in (Select Location_ID from tbl_Emp_Location where (Cliant_ID in (" + Item_Code + "))))))pb " +
                   "left join " +
                   "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;

                        }
                    }
                    else
                    {
                        if (chk_All_Client.Checked)
                        {
                            sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT,(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
                "(SELECT pb.[BILLNO]" +
                      ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
                  ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null   and (pb.Comany_id = " + company_id + ") and pb.BillStatus = 'ACTIVE'))pb " +
                  "left join " +
                  "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;
                        }
                        else
                        {
                            sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as 'CLIENT',(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
                 "(SELECT pb.[BILLNO]" +
                       ",pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as Client " +
                   ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null  and (pb.Comany_id = " + company_id + ") and (pb.Location_ID in (Select Location_ID from tbl_Emp_Location where (Cliant_ID in (" + Item_Code + ")))) and pb.BillStatus = 'ACTIVE'))pb " +
                   "left join " +
                   "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null " + ord;

                        }
                    }
                     dtPaybill = clsDataAccess.RunQDTbl(sql);

                    int countPaybill = dtPaybill.Rows.Count;

                    dtPaybill.Columns.Add("CGST", typeof(double));
                    dtPaybill.Columns.Add("SGST", typeof(double));
                    dtPaybill.Columns.Add("IGST", typeof(double));
                    dtPaybill.Columns.Add("ROFF", typeof(double));
                    roff_val = 0;
                    for (int i = 0; i < countPaybill; i++)
                    {
                        if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "LOCAL")
                        {
                            try
                            {
                                string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                                gstval = String.Format("{0:n}", (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2));

                                double sgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                                double cgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);

                                dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(sgstVal), 2));
                                dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(cgstVal), 2));
                                dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(0));

                                tsgst = tsgst + sgstVal;
                                tcgst = tcgst + cgstVal;
                            }
                            catch
                            { }
                        }
                        else if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "INTERSTATE")
                        {
                            try
                            {
                                string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                                double igstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                                tigst = tigst + igstVal;
                                gstval = String.Format("{0:n}", igstVal);
                                dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                                dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                                dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(igstVal), 2));
                            }
                            catch
                            { }
                        }

                        double gstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                        tgst = tgst + gstVal;
                       
                        double grossVal = Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]);
                        tgrossamt = tgrossamt + grossVal;
                       
                        double netVal = Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"]);
                        tnetamt = tnetamt + netVal;
                        dtPaybill.Rows[i]["NETAMT"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"])));
                        double scVal = Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]);
                        roff_val = Convert.ToDouble(string.Format("{0:N}", Math.Round((Convert.ToInt32(dtPaybill.Rows[i]["GST"]) +
                            Convert.ToInt32(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToInt32(dtPaybill.Rows[i]["GROSSAMT"])) - (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) + Convert.ToDouble(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"])), 2)));
                        dtPaybill.Rows[i]["ROFF"] = String.Format("{0:n}", roff_val);
                    }


                    dtPaybill.Rows.Add();

                    //DataTable dtCloned = dtPaybill.Clone();
                    //dtCloned.Columns["BILLDATE"].DataType = typeof(String);
                    //foreach (DataRow row in dtPaybill.Rows)
                    //{
                    //    dtCloned.ImportRow(row);
                    //}
                   

                    dtPaybill.Rows[countPaybill]["BILLDATE"] = "";
                    dtPaybill.Rows[countPaybill]["BILLNO"] = "Grand Total";
                    //dtCloned.Rows[countPaybill]["CLIENT & LOCATION"] = "Grand Total ";
                    dtPaybill.Rows[countPaybill]["CGST"] = String.Format("{0:n}", tcgst);
                    dtPaybill.Rows[countPaybill]["SGST"] = String.Format("{0:n}", tsgst);
                    dtPaybill.Rows[countPaybill]["IGST"] = String.Format("{0:n}", tigst);
                    dtPaybill.Rows[countPaybill]["GST"] = String.Format("{0:n}", tgst);
                    dtPaybill.Rows[countPaybill]["NETAMT"] = String.Format("{0:n}", tnetamt);
                    dtPaybill.Rows[countPaybill]["GROSSAMT"] = String.Format("{0:n}", tgrossamt);
                    //dtCloned.Rows[countPaybill]["SCAMT"] = String.Format("{0:n}", tscamt);
                    dtPaybill.Rows[countPaybill]["ROFF"] = String.Format("{0:n}", tot_roff);

                    sub = "GST Bill Summary zone [" + cmbZone.Text + "] For the Session " + CmbSession.Text;
                    //sub = sub + " To " + dateTimePicker2.Value.ToString("dd/MM/yyyy");
                    //MidasReport.Form1 bill = new MidasReport.Form1();
                    //bill.prntgststmntrpt(cmbcompany.Text, coadd, sub, dtCloned);
                    //bill.Show();

                }
            }

            else if (rbdVoucher.Checked)
            {
                if (CmbSession.Text.Trim() != "" && cmbMonth.Text.Trim() != "" && cmbcompany.Text.Trim() != "")
                {
                    string[] StrLine = this.CmbSession.Text.Trim().Split('-');
                    string yr = ""; string mon = "", sql = "", where1stclause = "", lastDayOfMonth = "";
                    Double tgst = 0, tsgst = 0, tcgst = 0, tigst = 0, tgrossamt = 0, tnetamt = 0;
                    roff_val = 0;
                    tot_roff = 0;



                    if (chk_All_Client.Checked)
                    {
                        sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT,(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
            "(SELECT pb.[BILLNO]" +
                  ",pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
              ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where (BILLNO between '" + bill_from + "' and '" + bill_to + "') and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null and pb.isGST != '0'  and pb.Comany_id = " + company_id + " and pb.BillStatus = 'ACTIVE'))pb " +
              "left join " +
              "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null order by pb.BILLNO";
                    }
                    else
                    {
                        sql = "select cast(convert(char(11), pb.BILLDATE, 105) as VARCHAR)as 'BILLDATE',pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as 'CLIENT',(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
             "(SELECT pb.[BILLNO]" +
                   ", pb.[BILLDATE] as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as Client " +
               ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where (BILLNO between '" + bill_from + "' and '" + bill_to + "') and (Session='" + CmbSession.Text + "') and  (pb.isGST is not null and pb.isGST != '0'  and pb.Comany_id = " + company_id + " and (pb.Location_ID in (Select Location_ID from tbl_Emp_Location where (Cliant_ID in (" + Item_Code + ")))) and pb.BillStatus = 'ACTIVE'))pb " +
               "left join " +
               "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null order by pb.BILLNO";

                    }

                    dtPaybill = clsDataAccess.RunQDTbl(sql);

                    int countPaybill = dtPaybill.Rows.Count;

                    dtPaybill.Columns.Add("CGST", typeof(double));
                    dtPaybill.Columns.Add("SGST", typeof(double));
                    dtPaybill.Columns.Add("IGST", typeof(double));
                    dtPaybill.Columns.Add("ROFF", typeof(double));
                    for (int i = 0; i < countPaybill; i++)
                    {
                        if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "LOCAL")
                        {
                            try
                            {
                                string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                                gstval = String.Format("{0:n}", (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2));

                                double sgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                                double cgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);

                                dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(sgstVal));
                                dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(cgstVal));
                                dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(0));

                                tsgst = tsgst + sgstVal;
                                tcgst = tcgst + cgstVal;
                            }
                            catch
                            { }
                        }
                        else if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "INTERSTATE")
                        {
                            try
                            {
                                string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                                double igstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                                tigst = tigst + igstVal;
                                gstval = String.Format("{0:n}", igstVal);
                                dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                                dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                                dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(igstVal));
                            }
                            catch
                            { }
                        }
                        else
                        {
                            dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                            dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                            dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                        }
                        double gstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                        tgst = tgst + gstVal;
                        dtPaybill.Rows[i]["GST"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                        double grossVal = Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]);
                        tgrossamt = tgrossamt + grossVal;
                        dtPaybill.Rows[i]["GROSSAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]));
                        double netVal = Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"]);
                        tnetamt = tnetamt + netVal;
                        dtPaybill.Rows[i]["NETAMT"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"])));
                        double scVal = Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]);
                        //tscamt = tscamt + scVal;
                        //dtPaybill.Rows[i]["SCAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]));
                        roff_val = Convert.ToDouble(string.Format("{0:N}", Math.Round((Convert.ToInt32(dtPaybill.Rows[i]["GST"]) +
                   Convert.ToInt32(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToInt32(dtPaybill.Rows[i]["GROSSAMT"])) - (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) + Convert.ToDouble(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"])), 2)));
                        dtPaybill.Rows[i]["ROFF"] = roff_val;
                        tot_roff = tot_roff + roff_val;
                    }

                    dtPaybill.Rows.Add();

                    //DataTable dtCloned = dtPaybill.Clone();
                    //dtCloned.Columns["BILLDATE"].DataType = typeof(String);
                    //foreach (DataRow row in dtPaybill.Rows)
                    //{
                    //    dtCloned.ImportRow(row);
                    //}

                    dtPaybill.Rows[countPaybill]["BILLDATE"] = "";
                    dtPaybill.Rows[countPaybill]["BILLNO"] = "Grand Total";
                    //dtCloned.Rows[countPaybill]["CLIENT & LOCATION"] = "Grand Total ";
                    dtPaybill.Rows[countPaybill]["CGST"] = String.Format("{0:n}", tcgst);
                    dtPaybill.Rows[countPaybill]["SGST"] = String.Format("{0:n}", tsgst);
                    dtPaybill.Rows[countPaybill]["IGST"] = String.Format("{0:n}", tigst);
                    dtPaybill.Rows[countPaybill]["GST"] = String.Format("{0:n}", tgst);
                    dtPaybill.Rows[countPaybill]["NETAMT"] = String.Format("{0:n}", tnetamt);
                    dtPaybill.Rows[countPaybill]["GROSSAMT"] = String.Format("{0:n}", tgrossamt);
                    //dtCloned.Rows[countPaybill]["SCAMT"] = String.Format("{0:n}", tscamt);
                    dtPaybill.Rows[countPaybill]["ROFF"] = String.Format("{0:n}", tot_roff);
                    if (rdbdtwise.Checked)
                    {
                        sub = "Bill Summary for the period " + dateTimePicker1.Value.ToString("dd/MM/yyyy");
                        sub = sub + " To " + dateTimePicker2.Value.ToString("dd/MM/yyyy");
                    }
                    else if (rbdVoucher.Checked)
                    {
                        sub = "Bill Summary Voucherwise (" + CmbSession.Text + ")";
                    }
                    else
                    {
                        if (cmbMonth.SelectedText.ToUpper() == "ALL")
                        {
                            sub = "Bill Summary During the Months of April - March (" + CmbSession.Text + ")";

                        }
                        else
                        {

                            sub = "Bill Summary For the Month of " + cmbMonth.SelectedText.ToUpper() + " (" + CmbSession.Text + ")";
                        }
                        //rdbmnthwise
                    }
                    //MidasReport.Form1 bill = new MidasReport.Form1();
                    //bill.prntgststmntrpt(cmbcompany.Text, coadd, sub, dtCloned);
                    //bill.Show();

                }
            }


            else if (rdbmnthwise.Checked)
            {

                string[] StrLine = this.CmbSession.Text.Trim().Split('-');
                string yr = ""; string mon = "", sql = "", where1stclause = "", lastDayOfMonth = "";
                Double tgst = 0, tsgst = 0, tcgst = 0, tigst = 0, tgrossamt = 0, tnetamt = 0;
                roff_val = 0;
                tot_roff = 0;

                if (rdbSession.Checked == true)
                {
                    ar[0] = "April";
                    ar[1] = "May";
                    ar[2] = "June";
                    ar[3] = "July";
                    ar[4] = "August";
                    ar[5] = "September";
                    ar[6] = "October";
                    ar[7] = "November";
                    ar[8] = "December";
                    ar[9] = "January";
                    ar[10] = "February";
                    ar[11] = "March";
                }
                else
                {
                    ar[0] = cmbMonth.SelectedItem.ToString();
                }
                billdt.Clear();

                int ind_ar = 0;
                if (rdbMonth.Checked == true)
                {
                    ind_ar = 1;
                }
                else if (rdbBDMonth.Checked == true)
                {
                    ind_ar = 1;
                }
                else
                {
                    ind_ar = ar.Length;
                }

                //RADIO BUTTON CHECKING
                if (rdbMonth.Checked == true)
                {
                    int mnval = 0;
                    if (cmbMonth.SelectedIndex > 9)
                    {
                        mnval = (cmbMonth.SelectedIndex) - 9;
                        yr = StrLine[1].Trim();
                    }
                    else if (cmbMonth.SelectedIndex <= 9)
                    {
                        mnval = cmbMonth.SelectedIndex + 3;
                        yr = StrLine[0].Trim();

                    }
                    else if (cmbMonth.SelectedIndex == 0)
                    {
                        mnval = 0;
                        yr = "";
                        EDPMessageBox.EDPMessage.Show("Please Select a particular month.");
                        return;
                    }

                    where1stclause = "pb.Month = '" + cmbMonth.Text + " - " + yr + "'";
                }
                else if (rdbBDMonth.Checked == true)
                {
                    int mnval = 0;
                    if (cmbMonth.SelectedIndex > 9)
                    {
                        mnval = (cmbMonth.SelectedIndex) - 9;
                        yr = StrLine[1].Trim();
                    }
                    else if (cmbMonth.SelectedIndex <= 9)
                    {
                        mnval = cmbMonth.SelectedIndex + 3;
                        yr = StrLine[0].Trim();
                    }
                    else if (cmbMonth.SelectedIndex == 0)
                    {
                        mnval = 0;
                        yr = "";
                        EDPMessageBox.EDPMessage.Show("Please Select a particular month.");
                        return;
                    }

                    lastDayOfMonth = DateTime.DaysInMonth(Convert.ToInt32(yr), mnval).ToString(); ;
                    where1stclause = "";

                    where1stclause = "pb.BILLDATE between '" + yr + "-" + mnval + "-01' and '" + yr + "-" + mnval + "-" + lastDayOfMonth + "'";
                    lastDayOfMonth = "";
                    mnval = 0;
                    yr = "";
                }
                else
                {
                    lastDayOfMonth = DateTime.DaysInMonth(Convert.ToInt32(StrLine[1]), 3).ToString();
                    where1stclause = "pb.BILLDATE between '" + StrLine[0] + "-" + "04" + "-01' and '" + StrLine[1] + "-" + "03" + "-" + lastDayOfMonth + "'";
                }


                if (chk_All_Client.Checked)
                {
                    sql = "select pb.BILLDATE,pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT,(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
        "(SELECT pb.[BILLNO]" +
              ",cast(convert(char(11), pb.[BILLDATE], 105) as VARCHAR) as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id =pb.Cliant_ID )+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
          ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (pb.isGST is not null and pb.isGST != '0'  and pb.Comany_id = " + company_id + " and pb.BillStatus = 'ACTIVE'))pb " +
          "left join " +
          "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null";
                }
                else
                {
                    sql = "select pb.BILLDATE,pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE,pb.Client as CLIENT,(pb.TotAMT+pb.ScAmt) as 'GROSSAMT',pb.NetAmt as 'NETAMT',pb.ScAmt as 'SCAMT',pb.GstNo as 'GstNo' from " +
            "(SELECT pb.[BILLNO]" +
                  ",cast(convert(char(11), pb.[BILLDATE], 105) as VARCHAR) as 'BILLDATE',pb.Location_ID,pb.ServiceAmount,pb.TotAMT,(pb.TotAMT+pb.ServiceAmount+pb.ScAmt) as NetAmt,pb.ScAmt,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = bp.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client' " +
              ",(select cm.GSTINNO from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)'GstNo' FROM [paybill] pb where " + where1stclause + " and (pb.isGST is not null and pb.isGST != '0'  and pb.Comany_id = " + company_id + " and (pb.Location_ID in (Select Location_ID from tbl_Emp_Location where (Cliant_ID in (" + Item_Code + ")))) and pb.BillStatus = 'ACTIVE'))pb " +
              "left join " +
              "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null";
                }

                dtPaybill = clsDataAccess.RunQDTbl(sql);

                int countPaybill = dtPaybill.Rows.Count;

                dtPaybill.Columns.Add("CGST", typeof(double));
                dtPaybill.Columns.Add("SGST", typeof(double));
                dtPaybill.Columns.Add("IGST", typeof(double));
                dtPaybill.Columns.Add("ROFF", typeof(double));
                for (int i = 0; i < countPaybill; i++)
                {
                    if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "LOCAL")
                    {
                        try
                        {
                            string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                            gstval = String.Format("{0:n}", (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2));

                            double sgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);
                            double cgstVal = Convert.ToDouble(Convert.ToDouble(dtPaybill.Rows[i]["GST"]) / 2);

                            dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(sgstVal));
                            dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(cgstVal));
                            dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(0));

                            tsgst = tsgst + sgstVal;
                            tcgst = tcgst + cgstVal;
                        }
                        catch
                        { }
                    }
                    else if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "INTERSTATE")
                    {
                        try
                        {
                            string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                            double igstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                            tigst = tigst + igstVal;
                            gstval = String.Format("{0:n}", igstVal);
                            dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                            dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                            dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(igstVal));
                        }
                        catch
                        { }
                    }
                    else
                    {
                        dtPaybill.Rows[i]["CGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                        dtPaybill.Rows[i]["SGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                        dtPaybill.Rows[i]["IGST"] = String.Format("{0:n}", Convert.ToDouble(0));
                    }
                    double gstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                    tgst = tgst + gstVal;
                    dtPaybill.Rows[i]["GST"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["GST"]));
                    double grossVal = Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]);
                    tgrossamt = tgrossamt + grossVal;
                    dtPaybill.Rows[i]["GROSSAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"]));
                    double netVal = Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"]);
                    tnetamt = tnetamt + netVal;
                    dtPaybill.Rows[i]["NETAMT"] = String.Format("{0:n}", Math.Round(Convert.ToDouble(dtPaybill.Rows[i]["NETAMT"])));
                    double scVal = Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]);
                    //tscamt = tscamt + scVal;
                    //dtPaybill.Rows[i]["SCAMT"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["SCAMT"]));
                    roff_val = Convert.ToDouble(string.Format("{0:N}", Math.Round((Convert.ToInt32(dtPaybill.Rows[i]["GST"]) +
                   Convert.ToInt32(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToInt32(dtPaybill.Rows[i]["GROSSAMT"])) - (Convert.ToDouble(dtPaybill.Rows[i]["GST"]) + Convert.ToDouble(dtPaybill.Rows[i]["SCAmt"]) + Convert.ToDouble(dtPaybill.Rows[i]["GROSSAMT"])), 2)));

                    dtPaybill.Rows[i]["ROFF"] = roff_val;
                    tot_roff = tot_roff + roff_val;
                }

                dtPaybill.Rows.Add();

                //DataTable dtCloned = dtPaybill.Clone();
                //dtCloned.Columns["BILLDATE"].DataType = typeof(String);
                //foreach (DataRow row in dtPaybill.Rows)
                //{
                //    dtCloned.ImportRow(row);
                //}

                dtPaybill.Rows[countPaybill]["BILLDATE"] = " ";
                dtPaybill.Rows[countPaybill]["BILLNO"] = "Grand Total ";
                //dtCloned.Rows[countPaybill]["CLIENT & LOCATION"] = "Grand Total ";
                dtPaybill.Rows[countPaybill]["CGST"] = String.Format("{0:n}", tcgst);
                dtPaybill.Rows[countPaybill]["SGST"] = String.Format("{0:n}", tsgst);
                dtPaybill.Rows[countPaybill]["IGST"] = String.Format("{0:n}", tigst);
                dtPaybill.Rows[countPaybill]["GST"] = String.Format("{0:n}", tgst);
                dtPaybill.Rows[countPaybill]["NETAMT"] = String.Format("{0:n}", tnetamt);
                dtPaybill.Rows[countPaybill]["GROSSAMT"] = String.Format("{0:n}", tgrossamt);
                dtPaybill.Rows[countPaybill]["ROFF"] = String.Format("{0:n}", tot_roff);
                //dtCloned.Rows[countPaybill]["SCAMT"] = String.Format("{0:n}", tscamt);


                sub = "Complete Bill  During the period ";

                //MidasReport.Form1 bill = new MidasReport.Form1();
                //bill.prntgststmntrpt(cmbcompany.Text, coadd, sub + "  " + cmbMonth.Text + " , " + dateTimePicker2.Value.ToString("yyyy"), dtCloned);
                //bill.Show();
            }

            else
            {
                EDPMessageBox.EDPMessage.Show("Please select session,month,company first.");

            }


            if (dtPaybill.Rows.Count > 0)
            {

                dtexpExcel.Columns.Add("Bill.Date");
                dtexpExcel.Columns.Add("Bill.Number");
                dtexpExcel.Columns.Add("Client");
                dtexpExcel.Columns.Add("Gross");
                dtexpExcel.Columns.Add("ScAmt");
                dtexpExcel.Columns.Add("GST.Number");
                dtexpExcel.Columns.Add("GST.Type");
                dtexpExcel.Columns.Add("GST.CGST");
                dtexpExcel.Columns.Add("GST.SGST");
                dtexpExcel.Columns.Add("GST.IGST");
                dtexpExcel.Columns.Add("GST.Total");
                dtexpExcel.Columns.Add("ROFF");
                dtexpExcel.Columns.Add("Net");
                dtexpExcel.Columns.Add("Receipt.Date");
                dtexpExcel.Columns.Add("Receipt.VNO");
                dtexpExcel.Columns.Add("Receipt.Amount");
                dtexpExcel.Columns.Add("Receipt.TDS");
                dtexpExcel.Columns.Add("Receipt.Other");
                dtexpExcel.Columns.Add("Receipt.MOD");
                dtexpExcel.Columns.Add("Receipt.Bank");
                dtexpExcel.Columns.Add("Receipt.Branch");
                dtexpExcel.Columns.Add("Receipt.InstrumentNo");
                dtexpExcel.Columns.Add("Receipt.InstrumentDate");
                int ind=0;
                for (int ipb = 0; ipb < dtPaybill.Rows.Count; ipb++)
                {
                    dtRcpt = clsDataAccess.RunQDTbl("SELECT distinct pr.userVchNo,pr.billNo,replace(convert(NVARCHAR, pr.dateOfInsertion, 106), ' ', '/')'doi'," +
                    "pr.pay_month,pr.pid,prr.reciptMmode,prr.amount,replace(convert(NVARCHAR,prr.instumentDate, 106), ' ', '/')'instDt',prr.instrumentNo,prr.bankName,prr.branchName," +
                    "ISNULL((select ISNULL(amount,0) from tbl_TDS_Register where vchrNo=pr.userVchNo),0) AS TDS," +
                    "ISNULL((select ISNULL(amount,0) from tbl_OTH_Register where vchrNo=pr.userVchNo),0) AS Oth " +
                    " FROM tbl_Payment_Receipt_Register AS prr JOIN tbl_Payment_Register AS pr  on ( pr.userVchNo=prr.vchrNo) WHERE (pr.billNo='" + dtPaybill.Rows[ipb]["BILLNO"].ToString() + "') and (prr.activation=1)");
                    if (dtRcpt.Rows.Count>0)
                    {
                     for (int irc = 0; irc < dtRcpt.Rows.Count; irc++)
                       {
                        dtexpExcel.Rows.Add();
                        dtexpExcel.Rows[ind]["Bill.Date"]=dtPaybill.Rows[ipb]["BILLDATE"].ToString();
                        dtexpExcel.Rows[ind]["Bill.Number"]=dtPaybill.Rows[ipb]["BILLNO"].ToString();
                        dtexpExcel.Rows[ind]["Client"]=dtPaybill.Rows[ipb]["CLIENT"].ToString();
                        dtexpExcel.Rows[ind]["Gross"]=dtPaybill.Rows[ipb]["GROSSAMT"].ToString();
                        dtexpExcel.Rows[ind]["ScAmt"]=dtPaybill.Rows[ipb]["SCAMT"].ToString();
                        dtexpExcel.Rows[ind]["GST.Number"]=dtPaybill.Rows[ipb]["GstNo"].ToString();
                        dtexpExcel.Rows[ind]["GST.Type"]=dtPaybill.Rows[ipb]["GSTTYPE"].ToString();
                        dtexpExcel.Rows[ind]["GST.CGST"]=dtPaybill.Rows[ipb]["CGST"].ToString();
                        dtexpExcel.Rows[ind]["GST.SGST"]=dtPaybill.Rows[ipb]["SGST"].ToString();
                        dtexpExcel.Rows[ind]["GST.IGST"]=dtPaybill.Rows[ipb]["IGST"].ToString();
                        dtexpExcel.Rows[ind]["GST.Total"]=dtPaybill.Rows[ipb]["GST"].ToString();
                        dtexpExcel.Rows[ind]["ROFF"] = dtPaybill.Rows[ipb]["ROFF"].ToString();
                        dtexpExcel.Rows[ind]["Net"]=dtPaybill.Rows[ipb]["NETAMT"].ToString();
                        dtexpExcel.Rows[ind]["Receipt.Date"] =Convert.ToDateTime(dtRcpt.Rows[irc]["doi"]).ToString("dd/MM/yyyy");
                        dtexpExcel.Rows[ind]["Receipt.VNO"] = dtRcpt.Rows[irc]["userVchNo"].ToString();
                        dtexpExcel.Rows[ind]["Receipt.Amount"] = dtRcpt.Rows[irc]["amount"].ToString();
                        dtexpExcel.Rows[ind]["Receipt.TDS"] = dtRcpt.Rows[irc]["TDS"].ToString();
                        dtexpExcel.Rows[ind]["Receipt.Other"] = dtRcpt.Rows[irc]["Oth"].ToString();
                        dtexpExcel.Rows[ind]["Receipt.MOD"] = dtRcpt.Rows[irc]["reciptMmode"].ToString();
                        dtexpExcel.Rows[ind]["Receipt.Bank"] = dtRcpt.Rows[irc]["bankName"].ToString();
                        dtexpExcel.Rows[ind]["Receipt.Branch"] = dtRcpt.Rows[irc]["branchName"].ToString();
                        dtexpExcel.Rows[ind]["Receipt.InstrumentNo"] = dtRcpt.Rows[irc]["instrumentNo"].ToString();
                        dtexpExcel.Rows[ind]["Receipt.InstrumentDate"] = Convert.ToDateTime(dtRcpt.Rows[irc]["instDt"]).ToString("dd/MM/yyyy");

                        ind++;
                       }
                    }
                    else
                    {
                        dtexpExcel.Rows.Add();
                        dtexpExcel.Rows[ind]["Bill.Date"]=dtPaybill.Rows[ipb]["BILLDATE"].ToString();
                        dtexpExcel.Rows[ind]["Bill.Number"]=dtPaybill.Rows[ipb]["BILLNO"].ToString();
                        dtexpExcel.Rows[ind]["Client"]=dtPaybill.Rows[ipb]["CLIENT"].ToString();
                        dtexpExcel.Rows[ind]["Gross"]=dtPaybill.Rows[ipb]["GROSSAMT"].ToString();
                        dtexpExcel.Rows[ind]["ScAmt"]=dtPaybill.Rows[ipb]["SCAMT"].ToString();
                        dtexpExcel.Rows[ind]["GST.Number"]=dtPaybill.Rows[ipb]["GstNo"].ToString();
                        dtexpExcel.Rows[ind]["GST.Type"]=dtPaybill.Rows[ipb]["GSTTYPE"].ToString();
                        dtexpExcel.Rows[ind]["GST.CGST"]=dtPaybill.Rows[ipb]["CGST"].ToString();
                        dtexpExcel.Rows[ind]["GST.SGST"]=dtPaybill.Rows[ipb]["SGST"].ToString();
                        dtexpExcel.Rows[ind]["GST.IGST"]=dtPaybill.Rows[ipb]["IGST"].ToString();
                        dtexpExcel.Rows[ind]["GST.Total"]=dtPaybill.Rows[ipb]["GST"].ToString();
                        dtexpExcel.Rows[ind]["ROFF"] = dtPaybill.Rows[ipb]["ROFF"].ToString();
                        dtexpExcel.Rows[ind]["Net"]=dtPaybill.Rows[ipb]["NETAMT"].ToString();
                        dtexpExcel.Rows[ind]["Receipt.Date"]="";
                        dtexpExcel.Rows[ind]["Receipt.VNO"]="";
                        dtexpExcel.Rows[ind]["Receipt.Amount"]="";
                        dtexpExcel.Rows[ind]["Receipt.TDS"]="";
                        dtexpExcel.Rows[ind]["Receipt.Other"]="";
                        dtexpExcel.Rows[ind]["Receipt.MOD"]="";
                        dtexpExcel.Rows[ind]["Receipt.Bank"]="";
                        dtexpExcel.Rows[ind]["Receipt.Branch"]="";
                        dtexpExcel.Rows[ind]["Receipt.InstrumentNo"]="";
                        dtexpExcel.Rows[ind]["Receipt.InstrumentDate"]="";
                        ind++;
                    }


                }

                dgvShow.DataSource = dtexpExcel;

                

                    //excel

                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                    excel.Visible = true;
                    int iCol = 0, irw = 0; ;
                    Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                    iCol = dgvShow.Columns.Count;

                    Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);

                   
                        excel.Cells[1, 1] = "Bill Complete Report";


                        range.Merge(true);
                        range.Font.Bold = true;


                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();


                        excel.Cells[2, 1] = cmbcompany.Text.ToUpper();

                        range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);
                        range.Merge(true);
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        range.Columns.AutoFit();
                        range.Rows.AutoFit();

                        excel.Cells[3, 1] = sub;
                        range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
                        range.Merge(true);
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.Columns.AutoFit();
                        range.Rows.AutoFit();
                        string[] cell_head = new string[] { };
                        string old_head = "";
                        int ind_st = 0, ind_fin = 0;
                       
                            for (int i = 1; i <= dgvShow.Columns.Count; i++)
                            {
                                cell_head = Convert.ToString(dgvShow.Columns[i - 1].HeaderText).Split('.');
                                if (cell_head.Length > 1)
                                {
                                    if (old_head == cell_head[0])
                                    {
                                        ind_fin = i;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
                                            range.Merge(Type.Missing);
                                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                                        }
                                        catch { }
                                        ind_st = i;
                                        excel.Cells[4, i] = cell_head[0];
                                        old_head = cell_head[0];
                                    }
                                    excel.Cells[5, i] = cell_head[1];
                                }
                                else if (cell_head.Length > 0)
                                {


                                    excel.Cells[4, i] = dgvShow.Columns[i - 1].HeaderText;
                                    try
                                    {
                                        range = worksheet.get_Range(worksheet.Cells[4, i], worksheet.Cells[5, i]);
                                        range.Merge(Type.Missing);
                                        range.HorizontalAlignment = HorizontalAlign.Left;
                                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                                    }
                                    catch { }
                                }

                            }
                            try
                            {
                                range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
                                range.Merge(Type.Missing);
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                            }
                            catch { }
                    range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
                    range.Font.Bold = true;
                    DateTime MyDate;
                    for (int i = 0; i < dgvShow.Rows.Count; i++)
                    {
                        for (int j = 1; j <= dgvShow.Columns.Count; j++)
                        {
                            try
                            {
                                irw = i + 6;

                                //if (!DateTime.TryParse(dgvShow.Rows[i].Cells[j - 1].Value.ToString(), out MyDate))
                                if ((j - 1) == 0 || (j - 1) == 5 || (j - 1) == 13 || (j - 1) == 22 || (j - 1) == 21)
                                {
                                    excel.Cells[i + 6, j] = "'" + dgvShow.Rows[i].Cells[j - 1].Value.ToString();
                                }
                                else
                                {
                                    excel.Cells[i + 6, j] =  dgvShow.Rows[i].Cells[j - 1].Value.ToString();
                                }
                            }
                            catch { }
                        }
                    }

                    object missing = System.Reflection.Missing.Value;



                    range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[irw, iCol]);
                    Excel.Borders borders = range.Borders;
                    //Set the thick lines style.
                    borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    borders.Weight = 2d;
                    range.WrapText = true;

                    ((Excel._Worksheet)worksheet).Activate();
                    worksheet.UsedRange.Select();

                    worksheet.Columns.AutoFit();

                    ((Excel._Application)excel).Quit();

                    MessageBox.Show("Export To Excel Completed!", "Export");


                

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet("DataSet");





            // Table for parents


            DataTable parentTable = new DataTable("Parents");


            parentTable.Columns.Add("ParentId", typeof(int));


            parentTable.Columns.Add("ParentName", typeof(string));


            //Create some parents.


            parentTable.Rows.Add(new object[] { 1, "Parent # 1" });


            parentTable.Rows.Add(new object[] { 2, "Parent # 2" });


            parentTable.Rows.Add(new object[] { 3, "Parent # 3" });


            ds.Tables.Add(parentTable);





            // Table for childrend


            DataTable childTable = new DataTable("Childs");


            childTable.Columns.Add("ChildId", typeof(int));


            childTable.Columns.Add("ChildName", typeof(string));


            childTable.Columns.Add("ParentId", typeof(int));


            //Create some childs.


            childTable.Rows.Add(new object[] { 1, "Child # 1", 1 });


            childTable.Rows.Add(new object[] { 2, "Child # 2", 2 });


            childTable.Rows.Add(new object[] { 3, "Child # 3", 1 });


            childTable.Rows.Add(new object[] { 4, "Child # 4", 3 });


            childTable.Rows.Add(new object[] { 5, "Child # 5", 3 });


            ds.Tables.Add(childTable);





            // Create their relation.


            DataRelation parentChildRelation = new DataRelation("ParentChild", parentTable.Columns["ParentId"], childTable.Columns["ParentId"]);


            ds.Relations.Add(parentChildRelation);





            // Display each parent and their children based on the relation.


            //foreach (DataRow parent in parentTable.Rows)
            //{


            //    // Get children


            //    DataRow[] children = parent.GetChildRows(parentChildRelation);


            //   // Console.WriteLine("\n{0}, has {1} children", parent["ParentName"].ToString(), children.Count<DataRow>());


            //    foreach (DataRow child in children)
            //    {


            //      //  Console.WriteLine("\t{0}", child["ChildName"].ToString());


            //    }


            //}


        }

        private void chkCancel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCancel.Checked == true)
            {
                btnPrev.Visible = false;
            }
            else
            {
                btnPrev.Visible = true;
            }
        }

        private void cmbZone_DropDown(object sender, EventArgs e)
        {
            cmbZone.ReturnValue = "0";
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("select zone,zid from tbl_zone order by zid");
            if (dt.Rows.Count > 0)
            {
                cmbZone.LookUpTable = dt;
                cmbZone.ReturnIndex = 1;
            }
        }
            
    }
}
