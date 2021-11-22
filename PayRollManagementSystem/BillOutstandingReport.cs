using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class BillOutstandingReport : Form
    {
        public BillOutstandingReport()
        {
            InitializeComponent();
        }
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        private void btnPreview_Click(object sender, EventArgs e)
        {
            MidasReport.Form1 rpt = new MidasReport.Form1();
           


            string head = "BILL" + Environment.NewLine + "Pymt" + Environment.NewLine + "TDS" + Environment.NewLine + "DED" + Environment.NewLine + "DUE";
            string sql = "";
            
            int idx = 0, coid = 1;
            double bill = 0, pymt = 0, tds = 0, ded = 0, due = 0;
            coid = Convert.ToInt32(cmbCompany.ReturnValue);
            DataTable dt_amt = new DataTable();
            DataTable dt_bo = new DataTable();
            string[] yr = CmbSession.Text.Split('-');
            string[] mon = ("April|May|June|July|August|September|October|November|December|January|February|March").Split('|');
            string my="";
            //DataTable dt = new DataTable();
            //dt.Columns.Add("client_loc");
            //dt.Columns.Add("head");
            //dt.Columns.Add("total");
            //dt.Columns.Add("opening");
            //dt.Columns.Add("april");
            //dt.Columns.Add("may");
            //dt.Columns.Add("june");
            //dt.Columns.Add("july");
            //dt.Columns.Add("august");
            //dt.Columns.Add("september");
            //dt.Columns.Add("october");
            //dt.Columns.Add("november");
            //dt.Columns.Add("december");
            //dt.Columns.Add("january");
            //dt.Columns.Add("february");
            //dt.Columns.Add("march");

            DataTable dt = clsDataAccess.RunQDTbl("SELECT ec.Client_Name + CHAR(13) + CHAR(10) + '['+ el.Location_Name + ']' as 'client_loc',"+
            " el.Cliant_ID as 'clid',el.Location_ID as 'locid','" + head + "' as 'head',"+
           " '' as total, '' as opening,'' as april, ''as may, '' as june, '' as july, '' as august, '' as september,'' as october,'' as november,"+
           "''as december,'' as january, ''as february, ''as march FROM tbl_Employee_CliantMaster AS ec INNER JOIN tbl_Emp_Location AS el ON ec.Client_id = el.Cliant_ID WHERE (ec.coid = " + coid + ") order by client_loc");
            while (idx < dt.Rows.Count)
            {
                bill = 0; pymt = 0; tds = 0; ded = 0; due = 0;
                sql = "SELECT opid,ROUND(isNull(opBill,0),0)opBill,ROUND(isNull(opPay,0),0)opPay,ROUND(isNull(opTds,0),0)opTds,ROUND(isNull(opOth,0),0)opOth,isNull(opNetLedger,0)opLedger FROM tbl_op_balance where (clid=" + dt.Rows[idx]["clid"].ToString() + ") and (locid=" + dt.Rows[idx]["locid"].ToString() + ") and (coid='" + coid + "') and (sess='" + CmbSession.Text + "')";
                dt_amt = clsDataAccess.RunQDTbl(sql);

               
               
                if (dt_amt.Rows.Count > 0)
                {
                    dt.Rows[idx]["opening"] = Convert.ToDouble(dt_amt.Rows[0]["opBill"].ToString()) + Environment.NewLine +
                    Convert.ToDouble(dt_amt.Rows[0]["opPay"].ToString()) + Environment.NewLine +
                    Convert.ToDouble(dt_amt.Rows[0]["opTds"].ToString()) + Environment.NewLine +
                    Convert.ToDouble(dt_amt.Rows[0]["opOth"].ToString()) + Environment.NewLine +
                    (Convert.ToDouble(dt_amt.Rows[0]["opBill"].ToString()) - Convert.ToDouble(Convert.ToDouble(dt_amt.Rows[0]["opPay"].ToString()) + Convert.ToDouble(dt_amt.Rows[0]["opTds"].ToString()) + Convert.ToDouble(dt_amt.Rows[0]["opOth"].ToString())));

                    bill =bill+Convert.ToDouble(dt_amt.Rows[0]["opBill"].ToString());
                    pymt =pymt+Convert.ToDouble(dt_amt.Rows[0]["opPay"].ToString());
                    tds = tds+Convert.ToDouble(dt_amt.Rows[0]["opTds"].ToString());
                    ded = ded+Convert.ToDouble(dt_amt.Rows[0]["opOth"].ToString());
                    due = due + (Convert.ToDouble(dt_amt.Rows[0]["opBill"].ToString()) - Convert.ToDouble(Convert.ToDouble(dt_amt.Rows[0]["opPay"].ToString()) + Convert.ToDouble(dt_amt.Rows[0]["opTds"].ToString()) + Convert.ToDouble(dt_amt.Rows[0]["opOth"].ToString())));
                }

                for (int idc = 0; idc < mon.Length; idc++)
                {
                    if(idc>=9)
                        my=mon[idc].Trim()+ " - " + yr[1].Trim();
                    else
                        my=mon[idc].Trim()+ " - " + yr[0].Trim();

               //     sql = "select ROUND(sum(bill),0)bill,ROUND(SUM(pymt),0)pymt,ROUND(SUM(tds),0)tds,ROUND(sum(othr),0)othr from (SELECT ISNULL((TotAMT + ServiceAmount + ScAmt), 0) AS BILL," +
               //"isNull((select sum(AMOUNT) FROM tbl_payment_receipt_register where vchrNo in " +
               //"(SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id))),0)as pymt," +
               //"isNull((select sum(AMOUNT) FROM tbl_TDS_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id))),0)as tds," +
               //"isNull((select sum(AMOUNT) FROM tbl_OTH_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id))),0)as othr," +
               //"Comany_id,Cliant_ID,Location_ID,BILLNO,BILLDATE FROM paybill pb WHERE (Comany_id=" + coid + ") AND (Location_ID =" + dt.Rows[idx]["locid"].ToString() + ") AND (Cliant_ID =" + dt.Rows[idx]["clid"].ToString() +
               //") AND (Session = '" + CmbSession.Text + "') AND (Month ='" + my + "')) bo group by Comany_id,Cliant_ID,Location_ID";

                    sql = "select ROUND(sum(bill),0)bill,ROUND(SUM(pymt),0)pymt,ROUND(SUM(tds),0)tds,ROUND(sum(othr),0)othr from (SELECT ISNULL((TotAMT + ServiceAmount + ScAmt), 0) AS BILL," +
              "isNull((select sum(AMOUNT) FROM tbl_payment_receipt_register where vchrNo in " +
              "(SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (ClientId=pb.cliant_id))),0)as pymt," +
              "isNull((select sum(AMOUNT) FROM tbl_TDS_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (ClientId=pb.cliant_id))),0)as tds," +
              "isNull((select sum(AMOUNT) FROM tbl_OTH_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (ClientId=pb.cliant_id))),0)as othr," +
              "Comany_id,Cliant_ID,Location_ID,BILLNO,BILLDATE FROM paybill pb WHERE  (BillStatus='ACTIVE') and (Comany_id=" + coid + ") AND (Location_ID =" + dt.Rows[idx]["locid"].ToString() + ") AND (Cliant_ID =" + dt.Rows[idx]["clid"].ToString() +
              ") AND (Session = '" + CmbSession.Text + "') AND (Month ='" + my + "')) bo group by Comany_id,Cliant_ID,Location_ID";

                    dt_bo = clsDataAccess.RunQDTbl(sql);

                    if (dt_bo.Rows.Count > 0)
                    {

                        bill = bill + Convert.ToDouble(dt_bo.Rows[0]["bill"].ToString());
                        pymt = pymt + Convert.ToDouble(dt_bo.Rows[0]["pymt"].ToString());
                        tds = tds + Convert.ToDouble(dt_bo.Rows[0]["tds"].ToString());
                        ded = ded + Convert.ToDouble(dt_bo.Rows[0]["othr"].ToString());
                        due = due + (Convert.ToDouble(dt_bo.Rows[0]["bill"].ToString()) - Convert.ToDouble(Convert.ToDouble(dt_bo.Rows[0]["pymt"].ToString()) + Convert.ToDouble(dt_bo.Rows[0]["tds"].ToString()) + Convert.ToDouble(dt_bo.Rows[0]["othr"].ToString())));


                        dt.Rows[idx][mon[idc].Trim().ToLower()] = Convert.ToDouble(dt_bo.Rows[0]["bill"].ToString()) + Environment.NewLine +
                            Convert.ToDouble(dt_bo.Rows[0]["pymt"].ToString()) + Environment.NewLine +
                            Convert.ToDouble(dt_bo.Rows[0]["tds"].ToString()) + Environment.NewLine +
                            Convert.ToDouble(dt_bo.Rows[0]["othr"].ToString()) + Environment.NewLine +
                        (Convert.ToDouble(dt_bo.Rows[0]["bill"].ToString()) - Convert.ToDouble(Convert.ToDouble(dt_bo.Rows[0]["pymt"].ToString()) + Convert.ToDouble(dt_bo.Rows[0]["tds"].ToString()) + Convert.ToDouble(dt_bo.Rows[0]["othr"].ToString())));
                    }
                    else
                    {
                        dt.Rows[idx][mon[idc].Trim().ToLower()] = "0" + Environment.NewLine + "0" + Environment.NewLine + "0" + Environment.NewLine + "0" + Environment.NewLine + "0";

                    }
                }



                    dt.Rows[idx]["total"] = Convert.ToDouble(bill) + Environment.NewLine +
                       Convert.ToDouble(pymt) + Environment.NewLine +
                       Convert.ToDouble(tds) + Environment.NewLine +
                       Convert.ToDouble(ded) + Environment.NewLine +
                       (Convert.ToDouble(bill) - Convert.ToDouble(Convert.ToDouble(pymt) + Convert.ToDouble(tds) + Convert.ToDouble(ded)));



                idx++;
            }
            //d.DataSource = dt;


            rpt.Bill_outstanding(cmbCompany.Text, "As on "+ dtpDOI.Value.ToString("MMMM dd, yyyy"), CmbSession.Text, dt);
            rpt.Show();
        }

        private void BillOutstandingReport_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(CmbSession, 2015, System.DateTime.Now.Year, 1);
           
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
                cmbCompany.ReturnValue = dt.Rows[0][1].ToString();
             // coid  = Convert.ToInt32(dt.Rows[0][1]);

            }
            else if (dt.Rows.Count > 1)
            {
                cmbCompany.PopUp();

            }
        

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
