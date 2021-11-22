using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmBillGSTDetailsDateWise : Form//EDPComponent.FormBaseERP
    {
        string CompID = "";
        DataSet ds = new DataSet();
        DataTable dtCloned = new DataTable();

        public frmBillGSTDetailsDateWise()
        {
            InitializeComponent();
        }

        private void cmbcompanyname_DropDown(object sender, EventArgs e)
        {
            //DataTable dt = clsDataAccess.RunQDTbl("select CO_NAME,CO_CODE from Company");
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
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
                cmbcompanyname.LookUpTable = dt;
                cmbcompanyname.ReturnIndex = 1;
            }
        }

        private void cmbcompanyname_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            CompID = cmbcompanyname.ReturnValue.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CompID != "")
                GetDetails();
            else
                EDPMessageBox.EDPMessage.Show("Enter the company name first.");
        }

        private void GetDetails()
        {
            string sql = "";

            Double tgst = 0, tsgst = 0, tcgst = 0, tigst = 0;

//            sql = "select pb.BILLDATE,pb.BILLNO,pb.ServiceAmount as 'GST',cwr.GSTTYPE from " +
//"(SELECT pb.[BILLNO]" +
//      ",cast(convert(char(11), pb.[BILLDATE], 105) as VARCHAR) as 'BILLDATE',pb.Location_ID,pb.ServiceAmount " +
//  "FROM [paybill] pb where pb.BILLDATE between '" + dateFrom.Value.Year + "-" + dateFrom.Value.Month + "-" + dateFrom.Value.Day + "' and '" + dateTo.Value.Year + "-" + dateTo.Value.Month + "-" + dateTo.Value.Day + "' and (pb.isGST is not null and pb.isGST != '0' and pb.BillStatus = 'ACTIVE' and pb.Comany_id = " + CompID + "))pb " +
//  "left join " +
//  "Companywiseid_Relation cwr on pb.Location_ID=cwr.Location_ID and cwr.GSTTYPE is not null";

            sql = "SELECT CAST(CONVERT(char(11), BILLDATE, 105) AS VARCHAR) AS 'BILLDATE',BILLNO, ServiceAmount as 'GST', (select GSTTYPE from Companywiseid_Relation cwr where pb.Location_ID=cwr.Location_ID and Company_ID=pb.Comany_id) as 'GSTTYPE',(select Location_Name from tbl_Emp_Location where Location_ID=pb.Location_ID)as 'Location' FROM paybill AS pb WHERE (BILLDATE BETWEEN '" + dateFrom.Value.Year + "-" + dateFrom.Value.Month + "-" + dateFrom.Value.Day + "' and '" + dateTo.Value.Year + "-" + dateTo.Value.Month + "-" + dateTo.Value.Day + "') AND (isGST IS NOT NULL) AND (isGST <> '0') AND (BillStatus = 'ACTIVE') AND (Comany_id = " + CompID + ")";
            //in above statement pb.BillStatus = 'ACTIVE' has been added by dwipraj dutta 24102017
            
            DataTable dtPaybill = clsDataAccess.RunQDTbl(sql);
            int countPaybill = dtPaybill.Rows.Count;

            dtPaybill.Columns.Add("CGST",typeof(string));
            dtPaybill.Columns.Add("SGST", typeof(string));
            dtPaybill.Columns.Add("IGST", typeof(string));

            for (int i = 0; i < countPaybill; i++)
            {
                if (dtPaybill.Rows[i]["GSTTYPE"].ToString() == "LOCAL")
                {
                    try
                    {
                        string gstval = Convert.ToString(Convert.ToDouble(dtPaybill.Rows[i]["GST"])/2);
                        gstval = String.Format("{0:n}", (Convert.ToDouble(dtPaybill.Rows[i]["GST"])/2));
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
                        gstval = String.Format("{0:n}",igstVal);
                        dtPaybill.Rows[i]["IGST"] = gstval;
                    }
                    catch
                    { }
                }

                double gstVal = Convert.ToDouble(dtPaybill.Rows[i]["GST"]);
                tgst = tgst + gstVal;
                dtPaybill.Rows[i]["GST"] = String.Format("{0:n}", Convert.ToDouble(dtPaybill.Rows[i]["GST"]));

            }

            dtPaybill.Rows.Add();

            dtCloned = dtPaybill.Clone();
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

            dgvGSTStatement.DataSource = dtCloned;

            dgvGSTStatement.Columns["BILLDATE"].DisplayIndex = 0;
            dgvGSTStatement.Columns["BILLNO"].DisplayIndex = 1;
            dgvGSTStatement.Columns["BILLNO"].Width = 150;
            dgvGSTStatement.Columns["CGST"].DisplayIndex = 2;
            dgvGSTStatement.Columns["CGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGSTStatement.Columns["SGST"].DisplayIndex = 3;
            dgvGSTStatement.Columns["SGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGSTStatement.Columns["IGST"].DisplayIndex = 4;
            dgvGSTStatement.Columns["IGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGSTStatement.Columns["GST"].DisplayIndex = 5;
            dgvGSTStatement.Columns["GST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGSTStatement.Columns["GSTTYPE"].Visible = false;



            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgvGSTStatement.Font, FontStyle.Bold);

            dgvGSTStatement.Rows[countPaybill].DefaultCellStyle = style;
            //this.dgvGSTStatement.ShowTotals = true;
            //this.dgvGSTStatement.Rows[0].PinPosition = PinnedRowPosition.Bottom;
        }

        private void frmBillGSTDetailsDateWise_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            OnLoad();
        }

        private void btnCLear_Click(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void OnLoad()
        {
            CompID = "";
            cmbcompanyname.Text = "";
            dateFrom.Value = DateTime.Now;
            dateTo.Value = DateTime.Now;
            dgvGSTStatement.DataSource = null;
            dgvGSTStatement.Refresh();

            cmbcompanyname.ReadOnlyText = true;

            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbcompanyname.Text = Convert.ToString(dt_co.Rows[0][0]);

                CompID = (dt_co.Rows[0][1].ToString());

            }
            else if (dt_co.Rows.Count > 1)
            {
                cmbcompanyname.PopUp();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            String Start_d = dateFrom.Value.ToString("dd/MMM/yyyy");
            String End_d = dateTo.Value.ToString("dd/MMM/yyyy");
            string sub = "";
            sub = "GST  Summary During the period From " + dateFrom.Value.ToString("dd/MM/yyyy");
            sub = sub + " To " + dateTo.Value.ToString("dd/MM/yyyy");
            string sa = cmbcompanyname.Text;
            String CO_ADD = "";
            CO_ADD = clsDataAccess.GetresultS("SELECT isNull(CO_ADD,'') FROM Company WHERE CO_CODE = '" + CompID + "'");
            btnSave_Click(sender, e);
            MidasReport.Form1 mr = new MidasReport.Form1();
            //DataTable dt = new DataTable();

            mr.GstReport(sa, sub, CO_ADD, dtCloned);
            mr.Show();
           // dtCloned.Disposed();


        }

        private void dgvGSTStatement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
               
                //GetDetails();

          

        }

    }
}
