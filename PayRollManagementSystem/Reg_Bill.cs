
//ANURAG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class Reg_Bill : Form// EDPComponent.FormBaseERP
    {
        int Company_id=0, ed_zone=0;
        string bill_from = "", bill_to = "";
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        public Reg_Bill()
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

        private void cmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
                Company_id = Convert.ToInt32(cmbCompany.ReturnValue);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'");
            String str = "";
            string ord = "";
            string type = "";
            if (rdb_ord_Date.Checked == true)
            {
                ord = "order by BILLDATE";
            }
            else if (rdb_ord_bill.Checked == true)
            {
                ord = "order by BILLNO";
            }
            else if (rdb_ord_party.Checked == true)
            {
                ord = "order by Party,BILLDATE,BILLNO";
            }
            if (rbtPeriod.Checked == true)
            {
                type = "For the period of " + dtpDOI.Value.ToString("dd/MM/yyyy") + " to " + dtp_DOV.Value.ToString("dd/MM/yyyy");
                str = "SELECT BILLNO, CONVERT(char(10), BILLDATE, 103) AS BILLDATE," +
              "(SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE (Client_id = b.Cliant_ID)) AS Party,(select top 1 ref_order_no FROM paybillD where BILLNO=b.BILLNO)as ref_order_no, '' AS STRENGTH,(TotAMT+ServiceAmount+ScAmt) AS Amount," +
              "'' AS Remarks FROM paybill AS b WHERE (Session='" + CmbSession.Text + "') AND (Comany_id ='" + Company_id +
              "') AND (BillStatus = 'ACTIVE') AND (BILLDATE between '" + dtpDOI.Value.ToString("yyyy/MMM/dd") + "' AND '" + dtp_DOV.Value.ToString("yyyy/MMM/dd") + "') order by billno";
            }
            else if (rbtVoucher.Checked == true)
            {
                type = "For the bill range  between " + bill_from + " AND " + bill_to;

                str = "SELECT BILLNO, CONVERT(char(10), BILLDATE, 103) AS BILLDATE," +
             "(SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE (Client_id = b.Cliant_ID)) AS Party,(select top 1 ref_order_no FROM paybillD where BILLNO=b.BILLNO)as ref_order_no, '' AS STRENGTH,(TotAMT+ServiceAmount+ScAmt) AS Amount," +
             "'' AS Remarks FROM paybill AS b WHERE (Session='" + CmbSession.Text + "') AND (Comany_id ='" + Company_id +
             "') AND (BillStatus = 'ACTIVE') AND (BILLNO between '" + bill_from + "' AND '" + bill_to + "') order by billno";

            }
            else if (rdbZone.Checked == true)
            {
                type = "For the zone "+ cmbZone.Text;
                string where1stclause = " (b.Location_ID in (SELECT Location_ID FROM tbl_Emp_Location WHERE (zid ='" + cmbZone.ReturnValue + "')))";

                str = "SELECT BILLNO, CONVERT(char(10), BILLDATE, 103) AS BILLDATE," +
            "(SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE (Client_id = b.Cliant_ID)) AS Party,(select top 1 ref_order_no FROM paybillD where BILLNO=b.BILLNO)as ref_order_no, '' AS STRENGTH,(TotAMT+ServiceAmount+ScAmt) AS Amount," +
            "'' AS Remarks FROM paybill AS b WHERE (Session='" + CmbSession.Text + "') AND (Comany_id ='" + Company_id +
            "') AND (BillStatus = 'ACTIVE') AND " + where1stclause + " order by billno";
            }
           
            dt = clsDataAccess.RunQDTbl(str);
            String Start_d = dtpDOI.Value.ToString("dd/MMM/yyyy");
            String End_d = dtp_DOV.Value.ToString("dd/MMM/yyyy");
            string sub = "";

            if (rbtPeriod.Checked == true)
            {
                sub = "Bill Register Report for the period " + dtpDOI.Value.ToString("dd/MM/yyyy");
                sub = sub + " To " + dtp_DOV.Value.ToString("dd/MM/yyyy");
            }
            else if (rbtVoucher.Checked == true)
            {
                sub = "Bill Register Report Voucherwise ("+ CmbSession.Text +")";
            }
            MidasReport.Form1 rpt = new MidasReport.Form1();
            rpt.Bill_Register(cmbCompany.Text, CO_ADD, CmbSession.Text, sub, End_d, dt,type);
            rpt.Show();
            cmbCompany.PopUp();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Bill_Register_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(CmbSession, 2015, System.DateTime.Now.Year, 1);
            if (DateTime.Now.Month >= 4)

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
            cmbCompany.ReadOnlyText = true;
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt.Rows.Count == 1)
            {
                cmbCompany.Text = Convert.ToString(dt.Rows[0][0]);

                Company_id = Convert.ToInt32(dt.Rows[0][1]);
                
            }
            else if (dt.Rows.Count > 1)
            {
                cmbCompany.PopUp();
            }
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


            rbtPeriod_CheckedChanged(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtpDOI_ValueChanged(object sender, EventArgs e)
        {

        }

        //private void CmbSession_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string[] StrLine = this.CmbSession.Text.Trim().Split('-');
        //    dtpDOI.MinDate = DateTimePicker.MinimumDateTime;
        //    dtpDOI.MaxDate = DateTimePicker.MaximumDateTime;

        //    dtp_DOV.MinDate = DateTimePicker.MinimumDateTime;
        //    dtp_DOV.MaxDate = DateTimePicker.MaximumDateTime;

        //    dtpDOI.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
        //    dtpDOI.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

        //    dtp_DOV.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
        //    dtp_DOV.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

        //    dtpDOI.Value = Convert.ToDateTime("01/April/" + StrLine[0]);

           

        //    dtp_DOV.Value = Convert.ToDateTime("31/March/" + StrLine[1]);
            
        //}

        private void CmbSession_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string[] StrLine = this.CmbSession.Text.Trim().Split('-');
            dtpDOI.MinDate = DateTimePicker.MinimumDateTime;
            dtpDOI.MaxDate = DateTimePicker.MaximumDateTime;

            dtp_DOV.MinDate = DateTimePicker.MinimumDateTime;
            dtp_DOV.MaxDate = DateTimePicker.MaximumDateTime;

            dtpDOI.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            dtpDOI.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

            dtp_DOV.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            dtp_DOV.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

            dtpDOI.Value = Convert.ToDateTime("01/April/" + StrLine[0]);



            dtp_DOV.Value = Convert.ToDateTime("31/March/" + StrLine[1]);
        }

        private void rbtPeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPeriod.Checked == true)
            {
               grpBill.Visible = false;
               grp_period.Visible = true;
               grp_zone.Visible = false;
            }
            else if (rbtVoucher.Checked == true)
            {
                grpBill.Visible = true;
                grp_period.Visible = false;
                grp_zone.Visible = false;
            }
            else if (rdbZone.Checked==true)
            {
                grpBill.Visible = false;
                grp_period.Visible = false;
                grp_zone.Visible = true;
            }


        }

        private void cmbBill_from_DropDown(object sender, EventArgs e)
        {

            DataTable dt = clsDataAccess.RunQDTbl("Select BILLNO,BILLDATE,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client - Location'  from paybill pb WHERE (Session = '" + CmbSession.Text + "') and (Comany_id='" + Company_id + "') ORDER BY BILLNO,BILLDATE");
            if (dt.Rows.Count > 0)
            {
                cmbBill_from.LookUpTable = dt;
                cmbBill_from.ReturnIndex = 0;
            }
        }

        private void cmbBill_To_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select BILLNO,BILLDATE,(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = pb.Cliant_ID)+' - '+(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = pb.Location_ID) as 'Client - Location'  from paybill pb WHERE (Session = '" + CmbSession.Text + "') and (Comany_id='" + Company_id + "') ORDER BY BILLNO,BILLDATE");
            if (dt.Rows.Count > 0)
            {
                cmbBill_To.LookUpTable = dt;
                cmbBill_To.ReturnIndex = 0;
            }
        }
       
        private void cmbBill_from_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if ((cmbBill_from.ReturnValue != null) && (cmbBill_from.ReturnValue != ""))
                bill_from = Convert.ToString(cmbBill_from.ReturnValue);

            cmbBill_To.Text=bill_from;
            bill_to = bill_from;
        }

        private void cmbBill_To_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if ((cmbBill_To.ReturnValue != null) && (cmbBill_To.ReturnValue != ""))
                bill_to = Convert.ToString(cmbBill_To.ReturnValue);

           
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
