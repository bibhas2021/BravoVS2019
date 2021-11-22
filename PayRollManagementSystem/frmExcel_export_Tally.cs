using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Edpcom;
using System.Collections;

namespace PayRollManagementSystem
{
    public partial class frmExcel_export_Tally : Form
    {
        public frmExcel_export_Tally()
        {
            InitializeComponent();
        }
        string company_id = "", coadd="";
        ArrayList arritem = new ArrayList();
        Hashtable getcode_item = new Hashtable();
        string Item_Code = "";

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
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
                company_id = (cmbcompany.ReturnValue);

            coadd = clsDataAccess.GetresultS("Select CO_ADD + ' ' + CO_ADD1 from Company where (CO_CODE='" + company_id + "')");
        }

        private void frmExcel_export_Tally_Load(object sender, EventArgs e)
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
            cmbcompany.PopUp();
        }

        private void CmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] StrLine = this.CmbSession.Text.Trim().Split('-');

            DTP_FROM.Value = Convert.ToDateTime("01/April/" + StrLine[0]);
            DTP_UPTO.Value = Convert.ToDateTime("31/March/" + StrLine[1]);
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            try
            {


                string sqlstmnt = "SELECT Client_Name AS ClientName,Client_id AS ClID,coid AS CoID FROM tbl_Employee_CliantMaster " +
               "where client_id in (SELECT DISTINCT pb.Cliant_ID FROM paybill AS pb " +
               "WHERE (pb.Comany_id ='" + company_id + "') AND (pb.Session='" + CmbSession.Text + "') AND (pb.BILLDATE BETWEEN '" + DTP_FROM.Value.ToString("dd/MMM/yyyy") + "' AND '" + DTP_UPTO.Value.ToString("dd/MMM/yyyy") + "'))";
                EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Client", "Select Client", 0, "CMPN", 0);

                arritem.Clear();
                arritem = EDPCommon.arr_mod;

                if (arritem.Count > 0)
                {
                    getcode_item.Clear();
                    arritem = EDPCommon.arr_mod;
                    getcode_item = EDPCommon.get_code;
                   
                    Item_Code = "";
                   


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

        private void btnPreview_Click(object sender, EventArgs e)
        {int idx=0;
            DataTable dt_bill = new DataTable();

            dt_bill.Columns.Add("Reference No.");
            dt_bill.Columns.Add("Date");	
            dt_bill.Columns.Add("Party A/c Name");	
            dt_bill.Columns.Add("Address Type");	
            dt_bill.Columns.Add("Sales Ledger");	
            dt_bill.Columns.Add("Name of Item");	
            dt_bill.Columns.Add("Quantity");	
            dt_bill.Columns.Add("Rate");	
            dt_bill.Columns.Add("Amount");
            dt_bill.Columns.Add("Total Amount Value");	
            dt_bill.Columns.Add("Accounting Ledger");	
            dt_bill.Columns.Add("Tax Amount");	
            dt_bill.Columns.Add("Total Tax Amount");	
            dt_bill.Columns.Add("Invoice Value");
            dt_bill.Columns.Add("Narration");

            DataTable pb = clsDataAccess.RunQDTbl("SELECT (SELECT DesignationName FROM tbl_Employee_DesignationMaster where SlNo=pb.desig_ID) 'Designation',"+
            "NoOfPersonnel,RATE,BILLAMT,ref_order_no,ref_order_date,Month,Session,Cliant_ID,Company_id,Location_ID,rmrks,SAC,BILLNO,cast(convert(datetime,BILLDATE,103) as datetime)'BILLDATE'," +
            "(SELECT (CASE WHEN isGST = 'true' THEN (SERVICEAmount / TotAmt) * 100 ELSE 0 END) AS gst FROM paybill where BILLNO=pb.BILLNO)'gst',"+
            "(SELECT Client_Name FROM tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)'client',"+
            "(SELECT Location_Name FROM tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)'location'  FROM paybillD pb "+
            " where (pb.Company_id='" + company_id + "') and (Cliant_ID in (" + Item_Code + ")) AND (pb.Session='" + CmbSession.Text + "') AND (pb.BILLDATE BETWEEN '" + DTP_FROM.Value.ToString("dd/MMM/yyyy") + "' AND '" + DTP_UPTO.Value.ToString("dd/MMM/yyyy") + "')");
                
                
            //    "SELECT BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,"+
            //"Cliant_ID,Descord,isGST,SAC,Designation_Id,BillStatus,IsSC,SCPer,ScAmt,isRound,isScAdd,DUEDATE,status FROM paybill pb "+
            //"WHERE (pb.Comany_id='" + company_id + "') and (Cliant_ID in " + Item_Code + ") AND (pb.Session='" + CmbSession.Text + "') AND (pb.BILLDATE BETWEEN '" + DTP_FROM.Value.ToString("dd/MMM/yyyy") + "' AND '" + DTP_UPTO.Value.ToString("dd/MMM/yyyy") + "')");
           string tgst = "0";
            DataTable pbd=new DataTable();
            if (pb.Rows.Count > 0)
            {
                for (int ind = 0; ind < pb.Rows.Count; ind++)
                {
                    if (Convert.ToDouble(pb.Rows[ind]["gst"].ToString()) > 0)
                    {
                        dt_bill.Rows.Add();

                        dt_bill.Rows[idx]["Reference No."] = pb.Rows[ind]["BILLNO"].ToString();
                        dt_bill.Rows[idx]["Date"] = pb.Rows[ind]["BILLDATE"].ToString();

                        dt_bill.Rows[idx]["Party A/c Name"] = pb.Rows[ind]["client"].ToString();
                        dt_bill.Rows[idx]["Address Type"] = pb.Rows[ind]["location"].ToString();
                        dt_bill.Rows[idx]["Sales Ledger"] = "Sales";
                        dt_bill.Rows[idx]["Name of Item"] = pb.Rows[ind]["Designation"].ToString();
                        dt_bill.Rows[idx]["Quantity"] = pb.Rows[ind]["NoOfPersonnel"].ToString();

                        dt_bill.Rows[idx]["Rate"] = pb.Rows[ind]["RATE"].ToString();
                        dt_bill.Rows[idx]["Amount"] = pb.Rows[ind]["BILLAMT"].ToString();
                        dt_bill.Rows[idx]["Total Amount Value"] = pb.Rows[ind]["BILLAMT"].ToString();

                        dt_bill.Rows[idx]["Accounting Ledger"] = "CGST";
                        tgst = (Convert.ToDouble(pb.Rows[ind]["BILLAMT"].ToString()) * Convert.ToDouble(pb.Rows[ind]["gst"].ToString()) / 100).ToString("0.00");
                        dt_bill.Rows[idx]["Tax Amount"] = Convert.ToDouble(tgst) / 2;


                        dt_bill.Rows[idx]["Total Tax Amount"] = tgst;

                        dt_bill.Rows[idx]["Invoice Value"] = Convert.ToDouble(pb.Rows[ind]["BILLAMT"].ToString()) + Convert.ToDouble(tgst);
                        dt_bill.Rows[idx]["Narration"] = "";


                        idx = idx + 1;

                        dt_bill.Rows.Add();

                        dt_bill.Rows[idx]["Reference No."] = pb.Rows[ind]["BILLNO"].ToString();
                        dt_bill.Rows[idx]["Date"] = "";

                        dt_bill.Rows[idx]["Party A/c Name"] = "";
                        dt_bill.Rows[idx]["Address Type"] = "";
                        dt_bill.Rows[idx]["Sales Ledger"] = "";
                        dt_bill.Rows[idx]["Name of Item"] = pb.Rows[ind]["Designation"].ToString();
                        dt_bill.Rows[idx]["Quantity"] = "0";

                        dt_bill.Rows[idx]["Rate"] = "";
                        dt_bill.Rows[idx]["Amount"] = "";
                        dt_bill.Rows[idx]["Total Amount Value"] = "";

                        dt_bill.Rows[idx]["Accounting Ledger"] = "SGST";
                        tgst = (Convert.ToDouble(pb.Rows[ind]["BILLAMT"].ToString()) * Convert.ToDouble(pb.Rows[ind]["gst"].ToString()) / 100).ToString("0.00");
                        dt_bill.Rows[idx]["Tax Amount"] = Convert.ToDouble(tgst) / 2;


                        dt_bill.Rows[idx]["Total Tax Amount"] = "";

                        dt_bill.Rows[idx]["Invoice Value"] = "";
                        dt_bill.Rows[idx]["Narration"] = "";


                        idx = idx + 1;
                    }
                    else
                    {
                        dt_bill.Rows.Add();

                        dt_bill.Rows[idx]["Reference No."] = pb.Rows[ind]["BILLNO"].ToString();
                        dt_bill.Rows[idx]["Date"] = pb.Rows[ind]["BILLDATE"].ToString();

                        dt_bill.Rows[idx]["Party A/c Name"] = pb.Rows[ind]["client"].ToString();
                        dt_bill.Rows[idx]["Address Type"] = pb.Rows[ind]["location"].ToString();
                        dt_bill.Rows[idx]["Sales Ledger"] = "Sales";
                        dt_bill.Rows[idx]["Name of Item"] = pb.Rows[ind]["Designation"].ToString();
                        dt_bill.Rows[idx]["Quantity"] = pb.Rows[ind]["NoOfPersonnel"].ToString();

                        dt_bill.Rows[idx]["Rate"] = pb.Rows[ind]["RATE"].ToString();
                        dt_bill.Rows[idx]["Amount"] = pb.Rows[ind]["BILLAMT"].ToString();
                        dt_bill.Rows[idx]["Total Amount Value"] = pb.Rows[ind]["BILLAMT"].ToString();

                        dt_bill.Rows[idx]["Accounting Ledger"] = "";
                        tgst = (Convert.ToDouble(pb.Rows[ind]["BILLAMT"].ToString()) * Convert.ToDouble(pb.Rows[ind]["gst"].ToString()) / 100).ToString("0.00");
                        dt_bill.Rows[idx]["Tax Amount"] ="0";


                        dt_bill.Rows[idx]["Total Tax Amount"] = "0";

                        dt_bill.Rows[idx]["Invoice Value"] = Convert.ToDouble(pb.Rows[ind]["BILLAMT"].ToString());
                        dt_bill.Rows[idx]["Narration"] = "";


                        idx = idx + 1;

                    }
                    //--------------------------------------------
                }
            }

            if (dt_bill.Rows.Count>0)
            {
            DataTable dtCloned=dt_bill.Clone();
               dtCloned.AcceptChanges();

                foreach (DataRow row in dt_bill.Rows)
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

                // excel
            }
            else
            {
                MessageBox.Show("There is no Record to export to excel!", "Export");
            }

            dt_bill.Dispose();
            dt_bill.Clear();

        }
    }
}
