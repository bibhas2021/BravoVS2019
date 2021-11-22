using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using Edpcom;
using System.Threading;

namespace PayRollManagementSystem
{
    public partial class frmClientOutstandingReport : Form
    {
        int Company_ID = 0, ed_zone=0;
        ArrayList alGetClientList = new ArrayList();
        EDPCommon edpcom = new EDPCommon();
        public frmClientOutstandingReport()
        {
            InitializeComponent();
        }

        private void frmClientOutstandingReport_Load(object sender, EventArgs e)
        {
            rbBillWise.Checked = true;


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


            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            if (DateTime.Now.Month >= 4)

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

            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbCompany.Text = Convert.ToString(dt_co.Rows[0][0]);

                Company_ID = Convert.ToInt32(dt_co.Rows[0][1]);
                cmbCompany.ReturnValue = Company_ID.ToString();
                cmbCompany.Enabled = false;


            }
            else if (dt_co.Rows.Count > 1)
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

        private void cmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbCompany.ReturnValue))
            {
                Company_ID = Convert.ToInt32(cmbCompany.ReturnValue);
            }
        }

        private void btnSelectClient_Click(object sender, EventArgs e)
        {
            if (Company_ID != 0)
            {
                string sqlstmnt = "";
                if (rdb_location.Checked == true)
                {
                    sqlstmnt = "SELECT  Location_ID, Location_Name,(SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE (Client_id = el.Cliant_ID)) AS ClientName FROM tbl_Emp_Location AS el  order by Clientname, Location_ID";
                }
                else if (rdbZone.Checked == true)
                {
                    sqlstmnt = "select zid,zone,'' as '-' from tbl_zone order by zid";
                }
                else
                {
                    sqlstmnt = "Select Client_id,Client_Name,'' as '-' from tbl_Employee_CliantMaster where (coid = " + Company_ID + ") order by Client_name";
                }
                
                EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Item Name", "List of Item Name", 0, "CMPN", 0);

                alGetClientList.Clear();
                alGetClientList = EDPCommon.arr_mod;
            }
            else
                EDPMessageBox.EDPMessage.Show("Please select company first.");
        }

        private void rbBillWise_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBillWise.Checked )
            {
                btnSelectClient.Enabled = false;
                cbSelectAllClient.Enabled = false;
            }
            else if (rdbZone.Checked)
            {
                btnSelectClient.Text = "Select Zone";
                btnSelectClient.Enabled = true;
                cbSelectAllClient.Checked = false;
                cbSelectAllClient.Enabled = false;
            }
        }

        private void rbClientWise_CheckedChanged(object sender, EventArgs e)
        {
            if (rbClientWise.Checked || rdb_location.Checked)
            {
                btnSelectClient.Text = "Select Clients / Location";
                btnSelectClient.Enabled = true;
                cbSelectAllClient.Enabled = true;
            }
        }

        private void cbSelectAllClient_Click(object sender, EventArgs e)
        {
            if (Company_ID == 0)
            {
                cbSelectAllClient.Checked = false;
                EDPMessageBox.EDPMessage.Show("Please select company first.");
            }
        }
        
        private void btnPreview_Click(object sender, EventArgs e)
        {
            string SQLFromDate = "";
            DataTable dtMain = new DataTable();
            if (rbClientWise.Checked)
            {
                if (cbSelectAllClient.Checked)
                {
                    Double ClientBillAmtSubTotal = 0;
                    Double ClientBillReceiptAmtSubTotal = 0;
                    Double ClientBillBalanceSubTotal = 0;
                    Double ClientBillAmtTotal = 0;
                    Double ClientBillReceiptAmtTotal = 0;
                    Double ClientBillBalanceTotal = 0;
                    string strSQLFromDate = dtpFromDate.Value.Year + "-" + dtpFromDate.Value.Month + "-" + dtpFromDate.Value.Day;
                    string strSQLToDate = dtpDateTo.Value.Year + "-" + dtpDateTo.Value.Month + "-" + dtpDateTo.Value.Day;
                    string strGetBillDetails = "select BILLNO  + (case when BillStatus='CANCELED' then char(10) +'[ CANCELED ]' else '' end ) as 'BILLNO'," +
                    "(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = Cliant_ID) as 'ClientName',"+
                    "(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = paybill.Location_ID) as 'LocationName',"+
                    "convert(varchar,[BILLDATE],103) as 'BILLDATE',(case when BillStatus='CANCELED' then 0 else round(cast((TotAMT+ScAmt+ServiceAmount) as varchar),0) end) as 'NETBILLAMOUNT'," +
                    "Cliant_ID,'' as 'ReciveAmount','' as 'Balance' from [paybill] where Comany_id = " + Company_ID + " and BILLDATE between '" + strSQLFromDate + "' and '" + strSQLToDate + "' order by Cliant_ID,BILLDATE asc";
                    DataTable dtGetBillDetails = clsDataAccess.RunQDTbl(strGetBillDetails);
                    if (dtGetBillDetails.Rows.Count > 0)
                        dtGetBillDetails.Rows.Add();

                    for (int i = 0; i < dtGetBillDetails.Rows.Count-1; i++)
                    {
                        if (dtGetBillDetails.Rows[i]["LocationName"].ToString() == "Sub Total")
                        {
                            ClientBillAmtTotal = ClientBillAmtTotal + ClientBillAmtSubTotal;
                            ClientBillReceiptAmtTotal = ClientBillReceiptAmtTotal + ClientBillReceiptAmtSubTotal;
                            ClientBillBalanceTotal = ClientBillBalanceTotal + ClientBillBalanceSubTotal;


                            ClientBillAmtSubTotal = 0;
                            ClientBillReceiptAmtSubTotal = 0;
                            ClientBillBalanceSubTotal = 0;

                            dtGetBillDetails.Rows[i]["NETBILLAMOUNT"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"].ToString()),2);
                            dtGetBillDetails.Rows[i]["ReciveAmount"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"].ToString()),2);
                            dtGetBillDetails.Rows[i]["Balance"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"].ToString()),2);
                            continue;
                        }
                        if (i == dtGetBillDetails.Rows.Count - 1)
                        {
                            break;
                        }
                        Boolean boolBillStatus = false;
                        string strGetReceipt = "select [userVchNo],[tblName] from [tbl_Payment_Register] where [billNo] = '" + dtGetBillDetails.Rows[i]["BILLNO"].ToString() + "'";
                        DataTable dtGetReceipt = clsDataAccess.RunQDTbl(strGetReceipt);
                        Double doubleTotalAmount = 0.00;
                        for (int j = 0; j < dtGetReceipt.Rows.Count; j++)
                        {
                            string strGetReceiptDetailsAmount = clsDataAccess.GetresultS("select [amount] from " + dtGetReceipt.Rows[j]["tblName"].ToString() + " where vchrNo = '" + dtGetReceipt.Rows[j]["userVchNo"].ToString() + "'");
                            doubleTotalAmount = doubleTotalAmount + System.Math.Round(Convert.ToDouble(strGetReceiptDetailsAmount));
                            string strGetStatus = "";
                            try
                            {
                                strGetStatus = clsDataAccess.GetresultS("SELECT (case when instrumentClearDate is not null then 'C' end) as 'Status' FROM [tbl_Payment_Receipt_Register] where (reciptMmode = 'C' or reciptMmode = 'N') and vchrNo = '" + dtGetReceipt.Rows[j]["userVchNo"].ToString() + "'");
                            }
                            catch
                            {
                                strGetStatus = "";
                            }
                            if (strGetStatus == "C")
                                boolBillStatus = true;

                        }
                        dtGetBillDetails.Rows[i]["ReciveAmount"] = doubleTotalAmount;
                        dtGetBillDetails.Rows[i]["Balance"] = Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount;
                        if (boolBillStatus && (Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount)==0)
                        {
                            dtGetBillDetails.Rows.RemoveAt(i);
                            continue;
                        }
                        ClientBillAmtSubTotal = ClientBillAmtSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]);
                        ClientBillReceiptAmtSubTotal = ClientBillReceiptAmtSubTotal + doubleTotalAmount;
                        ClientBillBalanceSubTotal = ClientBillBalanceSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount;

                        try
                        {
                            if (dtGetBillDetails.Rows[i]["Cliant_ID"].ToString() != dtGetBillDetails.Rows[i+1]["Cliant_ID"].ToString())
                            {

                                DataRow dr = dtGetBillDetails.NewRow();
                                dr["LocationName"] = "Sub Total";
                                dr["ReciveAmount"] = ClientBillReceiptAmtSubTotal;
                                dr["Balance"] = ClientBillBalanceSubTotal;
                                dr["NETBILLAMOUNT"] = ClientBillAmtSubTotal;
                                if ((i + 1) < (dtGetBillDetails.Rows.Count - 1))
                                    dtGetBillDetails.Rows.InsertAt(dr, i + 1);
                                else if ((i + 1) == (dtGetBillDetails.Rows.Count - 1))
                                {
                                    dtGetBillDetails.Rows[i + 1].Delete();
                                    dtGetBillDetails.Rows.InsertAt(dr, i + 1);
                                }
                            }
                        }
                        catch
                        { }

                        dtGetBillDetails.Rows[i]["NETBILLAMOUNT"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"].ToString()),2);
                        dtGetBillDetails.Rows[i]["ReciveAmount"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"].ToString()), 2);
                        dtGetBillDetails.Rows[i]["Balance"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"].ToString()),2);
                    }
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["LocationName"] = "Total";
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["NETBILLAMOUNT"] = edpcom.GetAmountFormat( ClientBillAmtTotal,2);
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["ReciveAmount"] = edpcom.GetAmountFormat(ClientBillReceiptAmtTotal,2);
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["Balance"] = edpcom.GetAmountFormat(ClientBillBalanceTotal,2);
                    dtMain = dtGetBillDetails;
                }
                else
                {
                    string arrayItem = "";
                    for (int i = 0; i < alGetClientList.Count; i++)
                    {
                        if (arrayItem.Trim() == "")
                        {
                            arrayItem = alGetClientList[i].ToString();
                        }
                        else
                        {
                            arrayItem = arrayItem + "," + alGetClientList[i].ToString();
                        }
                    }

                    string strSQLFromDate = dtpFromDate.Value.Year + "-" + dtpFromDate.Value.Month + "-" + dtpFromDate.Value.Day;
                    string strSQLToDate = dtpDateTo.Value.Year + "-" + dtpDateTo.Value.Month + "-" + dtpDateTo.Value.Day;
                    Double ClientBillAmtSubTotal = 0;
                    Double ClientBillReceiptAmtSubTotal = 0;
                    Double ClientBillBalanceSubTotal = 0;

                    Double ClientBillAmtTotal = 0;
                    Double ClientBillReceiptAmtTotal = 0;
                    Double ClientBillBalanceTotal = 0;

                    string strGetBillDetails = "select BILLNO + (case when BillStatus='CANCELED' then char(10) +'[ CANCELED ]' else '' end ) as 'BillNo',"+
                    "(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = Cliant_ID) as 'ClientName',"+
                    "(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = paybill.Location_ID) as 'LocationName',"+
                    "convert(varchar,[BILLDATE],103) as 'BILLDATE',(case when BillStatus='CANCELED' then 0 else round(cast((TotAMT+ScAmt+ServiceAmount) as varchar),0) end) as 'NETBILLAMOUNT'," +
                    "Cliant_ID,'' as 'ReciveAmount','' as 'Balance' from [paybill] where Comany_id = " + Company_ID + " and BILLDATE between '" + strSQLFromDate + "' and '" + strSQLToDate + "' and Cliant_ID in (" + arrayItem + ") order by Cliant_ID,BILLDATE asc";
                    DataTable dtGetBillDetails = clsDataAccess.RunQDTbl(strGetBillDetails);
                    if(dtGetBillDetails.Rows.Count>0)
                        dtGetBillDetails.Rows.Add();

                    for (int i = 0; i < dtGetBillDetails.Rows.Count; i++)
                    {
                        if (dtGetBillDetails.Rows[i]["BILLNO"].ToString() == "Sub Total")
                        {
                            ClientBillAmtTotal = ClientBillAmtTotal + ClientBillAmtSubTotal;
                            ClientBillReceiptAmtTotal = ClientBillReceiptAmtTotal + ClientBillReceiptAmtSubTotal;
                            ClientBillBalanceTotal = ClientBillBalanceTotal + ClientBillBalanceSubTotal;



                            ClientBillAmtSubTotal = 0;
                            ClientBillReceiptAmtSubTotal = 0;
                            ClientBillBalanceSubTotal = 0;

                            dtGetBillDetails.Rows[i]["NETBILLAMOUNT"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"].ToString()),2);
                            dtGetBillDetails.Rows[i]["ReciveAmount"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"].ToString()),2);
                            dtGetBillDetails.Rows[i]["Balance"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"].ToString()),2);
                            continue;
                        }
                        if (i == dtGetBillDetails.Rows.Count - 1)
                        {
                            break;
                        }
                        Boolean boolBillStatus = false;
                        string strGetReceipt = "select [userVchNo],[tblName] from [tbl_Payment_Register] where [billNo] = '" + dtGetBillDetails.Rows[i]["BILLNO"].ToString() + "'";
                        DataTable dtGetReceipt = clsDataAccess.RunQDTbl(strGetReceipt);
                        Double doubleTotalAmount = 0.00;
                        for (int j = 0; j < dtGetReceipt.Rows.Count; j++)
                        {
                            string strGetReceiptDetailsAmount = clsDataAccess.GetresultS("select [amount] from " + dtGetReceipt.Rows[j]["tblName"].ToString() + " where vchrNo = '" + dtGetReceipt.Rows[j]["userVchNo"].ToString() + "'");
                            doubleTotalAmount = doubleTotalAmount + System.Math.Round(Convert.ToDouble(strGetReceiptDetailsAmount));
                            string strGetStatus = "";
                            try
                            {
                                strGetStatus = clsDataAccess.GetresultS("SELECT (case when instrumentClearDate is not null then 'C' end) as 'Status' FROM [tbl_Payment_Receipt_Register] where (reciptMmode = 'C' or reciptMmode = 'N') and vchrNo = '" + dtGetReceipt.Rows[j]["userVchNo"].ToString() + "'");
                            }
                            catch
                            {
                                strGetStatus = "";
                            }
                            if (strGetStatus == "C")
                                boolBillStatus = true;

                        }
                        
                        dtGetBillDetails.Rows[i]["ReciveAmount"] = doubleTotalAmount;
                        dtGetBillDetails.Rows[i]["Balance"] = Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount;

                        if (boolBillStatus && (Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount) == 0)
                        {
                            //dtGetBillDetails.Rows.RemoveAt(i);
                            //continue;
                        }

                        ClientBillAmtSubTotal = ClientBillAmtSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]);
                        ClientBillReceiptAmtSubTotal = ClientBillReceiptAmtSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"]);
                        ClientBillBalanceSubTotal = ClientBillBalanceSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"]);

                        try
                        {
                            if (dtGetBillDetails.Rows[i]["Cliant_ID"].ToString() != dtGetBillDetails.Rows[i + 1]["Cliant_ID"].ToString() && dtGetBillDetails.Rows[i]["Cliant_ID"].ToString().Trim() != "")
                            {
                                DataRow dr = dtGetBillDetails.NewRow();
                                dr["BILLNO"] = "Sub Total";
                                dr["ReciveAmount"] = ClientBillReceiptAmtSubTotal;
                                dr["Balance"] = ClientBillBalanceSubTotal;
                                dr["NETBILLAMOUNT"] = ClientBillAmtSubTotal;
                                if ((i + 1) < (dtGetBillDetails.Rows.Count - 1))
                                    dtGetBillDetails.Rows.InsertAt(dr, i + 1);
                                else if ((i + 1) == (dtGetBillDetails.Rows.Count - 1))
                                {
                                    dtGetBillDetails.Rows[i + 1].Delete();
                                    dtGetBillDetails.Rows.InsertAt(dr, i + 1);
                                }
                            }
                        }
                        catch (Exception E)
                        {
                            string str = E.ToString();
                        }

                        dtGetBillDetails.Rows[i]["NETBILLAMOUNT"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"].ToString()),2);
                        dtGetBillDetails.Rows[i]["ReciveAmount"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"].ToString()),2);
                        dtGetBillDetails.Rows[i]["Balance"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"].ToString()),2);
                    }
                    dtGetBillDetails.Rows.Add();
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["BILLDATE"] = "Total";
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["NETBILLAMOUNT"] = edpcom.GetAmountFormat( ClientBillAmtTotal,2);
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["ReciveAmount"] = edpcom.GetAmountFormat( ClientBillReceiptAmtTotal,2);
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["Balance"] = edpcom.GetAmountFormat( ClientBillBalanceTotal,2);
                    dtMain = dtGetBillDetails;
                }
                SQLFromDate = "Receipt Register BillWise Summary Report During  " + dtpFromDate.Value.ToString("dd/MM/yyyy");
                SQLFromDate = SQLFromDate + "  To  " + dtpDateTo.Value.ToString("dd/MM/yyyy");
            }

            else if (rdb_location.Checked)
            {
                if (cbSelectAllClient.Checked)
                {
                    Double ClientBillAmtSubTotal = 0;
                    Double ClientBillReceiptAmtSubTotal = 0;
                    Double ClientBillBalanceSubTotal = 0;
                    Double ClientBillAmtTotal = 0;
                    Double ClientBillReceiptAmtTotal = 0;
                    Double ClientBillBalanceTotal = 0;
                    string strSQLFromDate = dtpFromDate.Value.Year + "-" + dtpFromDate.Value.Month + "-" + dtpFromDate.Value.Day;
                    string strSQLToDate = dtpDateTo.Value.Year + "-" + dtpDateTo.Value.Month + "-" + dtpDateTo.Value.Day;
                    string strGetBillDetails = "select BILLNO + (case when BillStatus='CANCELED' then char(10) +'[ CANCELED ]' else '' end ) as 'BILLNO'," +
                    "(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = Cliant_ID) as 'ClientName',"+
                    "(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = paybill.Location_ID) as 'LocationName',"+
                    "convert(varchar,[BILLDATE],103) as 'BILLDATE',(case when BillStatus='CANCELED' then 0 else round(cast((TotAMT+ScAmt+ServiceAmount) as varchar),0) end) as 'NETBILLAMOUNT'," +
                    "Cliant_ID,'' as 'ReciveAmount','' as 'Balance' from [paybill] where Comany_id = " + Company_ID + " and BILLDATE between '" + strSQLFromDate + "' and '" + strSQLToDate + "' order by Cliant_ID,BILLDATE asc";
                    DataTable dtGetBillDetails = clsDataAccess.RunQDTbl(strGetBillDetails);
                    if (dtGetBillDetails.Rows.Count > 0)
                        dtGetBillDetails.Rows.Add();

                    for (int i = 0; i < dtGetBillDetails.Rows.Count - 1; i++)
                    {
                        if (dtGetBillDetails.Rows[i]["LocationName"].ToString() == "Sub Total")
                        {
                            ClientBillAmtTotal = ClientBillAmtTotal + ClientBillAmtSubTotal;
                            ClientBillReceiptAmtTotal = ClientBillReceiptAmtTotal + ClientBillReceiptAmtSubTotal;
                            ClientBillBalanceTotal = ClientBillBalanceTotal + ClientBillBalanceSubTotal;


                            ClientBillAmtSubTotal = 0;
                            ClientBillReceiptAmtSubTotal = 0;
                            ClientBillBalanceSubTotal = 0;

                            dtGetBillDetails.Rows[i]["NETBILLAMOUNT"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"].ToString()), 2);
                            dtGetBillDetails.Rows[i]["ReciveAmount"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"].ToString()), 2);
                            dtGetBillDetails.Rows[i]["Balance"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"].ToString()), 2);
                            continue;
                        }
                        if (i == dtGetBillDetails.Rows.Count - 1)
                        {
                            break;
                        }
                        Boolean boolBillStatus = false;
                        string strGetReceipt = "select [userVchNo],[tblName] from [tbl_Payment_Register] where [billNo] = '" + dtGetBillDetails.Rows[i]["BILLNO"].ToString() + "'";
                        DataTable dtGetReceipt = clsDataAccess.RunQDTbl(strGetReceipt);
                        Double doubleTotalAmount = 0.00;
                        for (int j = 0; j < dtGetReceipt.Rows.Count; j++)
                        {
                            string strGetReceiptDetailsAmount = clsDataAccess.GetresultS("select [amount] from " + dtGetReceipt.Rows[j]["tblName"].ToString() + " where vchrNo = '" + dtGetReceipt.Rows[j]["userVchNo"].ToString() + "'");
                            doubleTotalAmount = doubleTotalAmount +System.Math.Round( Convert.ToDouble(strGetReceiptDetailsAmount));
                            string strGetStatus = "";
                            try
                            {
                                strGetStatus = clsDataAccess.GetresultS("SELECT (case when instrumentClearDate is not null then 'C' end) as 'Status' FROM [tbl_Payment_Receipt_Register] where (reciptMmode = 'C' or reciptMmode = 'N') and vchrNo = '" + dtGetReceipt.Rows[j]["userVchNo"].ToString() + "'");
                            }
                            catch
                            {
                                strGetStatus = "";
                            }
                            if (strGetStatus == "C")
                                boolBillStatus = true;

                        }
                        dtGetBillDetails.Rows[i]["ReciveAmount"] = doubleTotalAmount;
                        dtGetBillDetails.Rows[i]["Balance"] = Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount;
                        if (boolBillStatus && (Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount) == 0)
                        {
                            dtGetBillDetails.Rows.RemoveAt(i);
                            continue;
                        }
                        ClientBillAmtSubTotal = ClientBillAmtSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]);
                        ClientBillReceiptAmtSubTotal = ClientBillReceiptAmtSubTotal + doubleTotalAmount;
                        ClientBillBalanceSubTotal = ClientBillBalanceSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount;

                        try
                        {
                            if (dtGetBillDetails.Rows[i]["Cliant_ID"].ToString() != dtGetBillDetails.Rows[i + 1]["Cliant_ID"].ToString())
                            {

                                DataRow dr = dtGetBillDetails.NewRow();
                                dr["LocationName"] = "Sub Total";
                                dr["ReciveAmount"] = ClientBillReceiptAmtSubTotal;
                                dr["Balance"] = ClientBillBalanceSubTotal;
                                dr["NETBILLAMOUNT"] = ClientBillAmtSubTotal;
                                if ((i + 1) < (dtGetBillDetails.Rows.Count - 1))
                                    dtGetBillDetails.Rows.InsertAt(dr, i + 1);
                                else if ((i + 1) == (dtGetBillDetails.Rows.Count - 1))
                                {
                                    dtGetBillDetails.Rows[i + 1].Delete();
                                    dtGetBillDetails.Rows.InsertAt(dr, i + 1);
                                }
                            }
                        }
                        catch
                        { }

                        dtGetBillDetails.Rows[i]["NETBILLAMOUNT"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"].ToString()), 2);
                        dtGetBillDetails.Rows[i]["ReciveAmount"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"].ToString()), 2);
                        dtGetBillDetails.Rows[i]["Balance"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"].ToString()), 2);
                    }
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["LocationName"] = "Total";
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["NETBILLAMOUNT"] = edpcom.GetAmountFormat(ClientBillAmtTotal, 2);
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["ReciveAmount"] = edpcom.GetAmountFormat(ClientBillReceiptAmtTotal, 2);
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["Balance"] = edpcom.GetAmountFormat(ClientBillBalanceTotal, 2);
                    dtMain = dtGetBillDetails;
                }
                else
                {
                    string arrayItem = "";
                    for (int i = 0; i < alGetClientList.Count; i++)
                    {
                        if (arrayItem.Trim() == "")
                        {
                            arrayItem = alGetClientList[i].ToString();
                        }
                        else
                        {
                            arrayItem = arrayItem + "," + alGetClientList[i].ToString();
                        }
                    }

                    string strSQLFromDate = dtpFromDate.Value.Year + "-" + dtpFromDate.Value.Month + "-" + dtpFromDate.Value.Day;
                    string strSQLToDate = dtpDateTo.Value.Year + "-" + dtpDateTo.Value.Month + "-" + dtpDateTo.Value.Day;
                    Double ClientBillAmtSubTotal = 0;
                    Double ClientBillReceiptAmtSubTotal = 0;
                    Double ClientBillBalanceSubTotal = 0;

                    Double ClientBillAmtTotal = 0;
                    Double ClientBillReceiptAmtTotal = 0;
                    Double ClientBillBalanceTotal = 0;

                    string strGetBillDetails = "select BILLNO + (case when BillStatus='CANCELED' then char(10) +'[ CANCELED ]' else '' end ) as 'BILLNO'," +
                    "(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = Cliant_ID) as 'ClientName'," +
                    "(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = paybill.Location_ID) as 'LocationName',"+
                    "convert(varchar,[BILLDATE],103) as 'BILLDATE',(case when BillStatus='CANCELED' then 0 else round(cast((TotAMT+ScAmt+ServiceAmount) as varchar),0) end)  as 'NETBILLAMOUNT',Cliant_ID,'' as 'ReciveAmount'," +
                    "'' as 'Balance' from [paybill] where Comany_id = " + Company_ID + " and BILLDATE between '" + strSQLFromDate + "' and '" + strSQLToDate + 
                    "' and Location_ID in (" + arrayItem + ") order by Cliant_ID,BILLDATE asc";
                   
                    DataTable dtGetBillDetails = clsDataAccess.RunQDTbl(strGetBillDetails);
                    if (dtGetBillDetails.Rows.Count > 0)
                    {
                        dtGetBillDetails.Rows.Add();
                    }
                    else
                    { 
                        MessageBox.Show("NO RECORD");
                        return;
                    }

                    for (int i = 0; i < dtGetBillDetails.Rows.Count; i++)
                    {
                        if (dtGetBillDetails.Rows[i]["BILLNO"].ToString() == "Sub Total")
                        {
                            ClientBillAmtTotal = ClientBillAmtTotal + ClientBillAmtSubTotal;
                            ClientBillReceiptAmtTotal = ClientBillReceiptAmtTotal + ClientBillReceiptAmtSubTotal;
                            ClientBillBalanceTotal = ClientBillBalanceTotal + ClientBillBalanceSubTotal;



                            ClientBillAmtSubTotal = 0;
                            ClientBillReceiptAmtSubTotal = 0;
                            ClientBillBalanceSubTotal = 0;

                            dtGetBillDetails.Rows[i]["NETBILLAMOUNT"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"].ToString()), 2);
                            dtGetBillDetails.Rows[i]["ReciveAmount"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"].ToString()), 2);
                            dtGetBillDetails.Rows[i]["Balance"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"].ToString()), 2);
                            continue;
                        }
                        if (i == dtGetBillDetails.Rows.Count - 1)
                        {
                            break;
                        }
                        Boolean boolBillStatus = false;
                        string strGetReceipt = "select [userVchNo],[tblName] from [tbl_Payment_Register] where [billNo] = '" + dtGetBillDetails.Rows[i]["BILLNO"].ToString() + "'";
                        DataTable dtGetReceipt = clsDataAccess.RunQDTbl(strGetReceipt);
                        Double doubleTotalAmount = 0.00;
                        for (int j = 0; j < dtGetReceipt.Rows.Count; j++)
                        {
                            string strGetReceiptDetailsAmount = clsDataAccess.GetresultS("select [amount] from " + dtGetReceipt.Rows[j]["tblName"].ToString() + " where vchrNo = '" + dtGetReceipt.Rows[j]["userVchNo"].ToString() + "'");
                            doubleTotalAmount = doubleTotalAmount + System.Math.Round(Convert.ToDouble(strGetReceiptDetailsAmount));
                            string strGetStatus = "";
                            try
                            {
                                strGetStatus = clsDataAccess.GetresultS("SELECT (case when instrumentClearDate is not null then 'C' end) as 'Status' FROM [tbl_Payment_Receipt_Register] where (reciptMmode = 'C' or reciptMmode = 'N') and vchrNo = '" + dtGetReceipt.Rows[j]["userVchNo"].ToString() + "'");
                            }
                            catch
                            {
                                strGetStatus = "";
                            }
                            if (strGetStatus == "C")
                                boolBillStatus = true;

                        }

                        dtGetBillDetails.Rows[i]["ReciveAmount"] = doubleTotalAmount;
                        dtGetBillDetails.Rows[i]["Balance"] = Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount;

                        if (boolBillStatus && (Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount) == 0)
                        {
                            //dtGetBillDetails.Rows.RemoveAt(i);
                            //continue;
                        }

                        ClientBillAmtSubTotal = ClientBillAmtSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]);
                        ClientBillReceiptAmtSubTotal = ClientBillReceiptAmtSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"]);
                        ClientBillBalanceSubTotal = ClientBillBalanceSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"]);

                        try
                        {
                            if (dtGetBillDetails.Rows[i]["Cliant_ID"].ToString() != dtGetBillDetails.Rows[i + 1]["Cliant_ID"].ToString() && dtGetBillDetails.Rows[i]["Cliant_ID"].ToString().Trim() !="")
                            {
                                DataRow dr = dtGetBillDetails.NewRow();
                                dr["BILLNO"] = "Sub Total";
                                dr["ReciveAmount"] = ClientBillReceiptAmtSubTotal;
                                dr["Balance"] = ClientBillBalanceSubTotal;
                                dr["NETBILLAMOUNT"] = ClientBillAmtSubTotal;
                                if ((i + 1) < (dtGetBillDetails.Rows.Count - 1))
                                    dtGetBillDetails.Rows.InsertAt(dr, i + 1);
                                else if ((i + 1) == (dtGetBillDetails.Rows.Count - 1))
                                {
                                    dtGetBillDetails.Rows[i + 1].Delete();
                                    dtGetBillDetails.Rows.InsertAt(dr, i + 1);
                                }
                            }
                        }
                        catch (Exception E)
                        {
                            string str = E.ToString();
                        }

                        dtGetBillDetails.Rows[i]["NETBILLAMOUNT"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"].ToString()), 2);
                        dtGetBillDetails.Rows[i]["ReciveAmount"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"].ToString()), 2);
                        dtGetBillDetails.Rows[i]["Balance"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"].ToString()), 2);
                    }
                    dtGetBillDetails.Rows.Add();
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["BILLDATE"] = "Total";
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["NETBILLAMOUNT"] = edpcom.GetAmountFormat(ClientBillAmtTotal, 2);
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["ReciveAmount"] = edpcom.GetAmountFormat(ClientBillReceiptAmtTotal, 2);
                    dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["Balance"] = edpcom.GetAmountFormat(ClientBillBalanceTotal, 2);
                    dtMain = dtGetBillDetails;
                }
                SQLFromDate = "Receipt Register BillWise Summary Report During  " + dtpFromDate.Value.ToString("dd/MM/yyyy");
                SQLFromDate = SQLFromDate + "  To  " + dtpDateTo.Value.ToString("dd/MM/yyyy");
            }
            else if (rdbZone.Checked)
            {
                string arrayItem = "";
                
                for (int i = 0; i < alGetClientList.Count; i++)
                {
                    if (arrayItem.Trim() == "")
                    {
                        arrayItem = alGetClientList[i].ToString();
                    }
                    else
                    {
                        arrayItem = arrayItem + "," + alGetClientList[i].ToString();
                    }
                }

                string strSQLFromDate = dtpFromDate.Value.Year + "-" + dtpFromDate.Value.Month + "-" + dtpFromDate.Value.Day;
                string strSQLToDate = dtpDateTo.Value.Year + "-" + dtpDateTo.Value.Month + "-" + dtpDateTo.Value.Day;
                Double ClientBillAmtSubTotal = 0;
                Double ClientBillReceiptAmtSubTotal = 0;
                Double ClientBillBalanceSubTotal = 0;

                Double ClientBillAmtTotal = 0;
                Double ClientBillReceiptAmtTotal = 0;
                Double ClientBillBalanceTotal = 0;

                string strGetBillDetails = "select BILLNO + (case when BillStatus='CANCELED' then char(10) +'[ CANCELED ]' else '' end ) as 'BILLNO'," +
                "(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = Cliant_ID) as 'ClientName'," +
                "(select lm.Location_Name  + '\n\r [Zone: '+ (select zone from tbl_zone where zid=lm.zid) +']' from tbl_Emp_Location lm where lm.Location_ID = paybill.Location_ID) as 'LocationName'," +
                "convert(varchar,[BILLDATE],103) as 'BILLDATE',(case when BillStatus='CANCELED' then 0 else round(cast((TotAMT+ScAmt+ServiceAmount) as varchar),0) end)  as 'NETBILLAMOUNT',Cliant_ID,'' as 'ReciveAmount'," +
                "'' as 'Balance',(select zid from tbl_Emp_Location lm where lm.Location_ID = paybill.Location_ID) as 'zid' from [paybill] where Comany_id = " + Company_ID + " and BILLDATE between '" + strSQLFromDate + "' and '" + strSQLToDate +
                "' and (Location_ID in (SELECT Location_ID FROM tbl_Emp_Location WHERE (zid in (" + arrayItem + ")))) order by zid,Cliant_ID,BILLDATE asc";

                DataTable dtGetBillDetails = clsDataAccess.RunQDTbl(strGetBillDetails);
                if (dtGetBillDetails.Rows.Count > 0)
                {
                    dtGetBillDetails.Rows.Add();
                }
                else
                {
                    MessageBox.Show("NO RECORD");
                    return;
                }

                for (int i = 0; i < dtGetBillDetails.Rows.Count; i++)
                {
                    if (dtGetBillDetails.Rows[i]["BILLNO"].ToString() == "Sub Total")
                    {
                        ClientBillAmtTotal = ClientBillAmtTotal + ClientBillAmtSubTotal;
                        ClientBillReceiptAmtTotal = ClientBillReceiptAmtTotal + ClientBillReceiptAmtSubTotal;
                        ClientBillBalanceTotal = ClientBillBalanceTotal + ClientBillBalanceSubTotal;



                        ClientBillAmtSubTotal = 0;
                        ClientBillReceiptAmtSubTotal = 0;
                        ClientBillBalanceSubTotal = 0;

                        dtGetBillDetails.Rows[i]["NETBILLAMOUNT"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"].ToString()), 2);
                        dtGetBillDetails.Rows[i]["ReciveAmount"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"].ToString()), 2);
                        dtGetBillDetails.Rows[i]["Balance"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"].ToString()), 2);
                        continue;
                    }
                    if (i == dtGetBillDetails.Rows.Count - 1)
                    {
                        break;
                    }
                    Boolean boolBillStatus = false;
                    string strGetReceipt = "select [userVchNo],[tblName] from [tbl_Payment_Register] where [billNo] = '" + dtGetBillDetails.Rows[i]["BILLNO"].ToString() + "'";
                    DataTable dtGetReceipt = clsDataAccess.RunQDTbl(strGetReceipt);
                    Double doubleTotalAmount = 0.00;
                    for (int j = 0; j < dtGetReceipt.Rows.Count; j++)
                    {
                        string strGetReceiptDetailsAmount = clsDataAccess.GetresultS("select [amount] from " + dtGetReceipt.Rows[j]["tblName"].ToString() + " where vchrNo = '" + dtGetReceipt.Rows[j]["userVchNo"].ToString() + "'");
                        doubleTotalAmount = doubleTotalAmount + System.Math.Round(Convert.ToDouble(strGetReceiptDetailsAmount));
                        string strGetStatus = "";
                        try
                        {
                            strGetStatus = clsDataAccess.GetresultS("SELECT (case when instrumentClearDate is not null then 'C' end) as 'Status' FROM [tbl_Payment_Receipt_Register] where (reciptMmode = 'C' or reciptMmode = 'N') and vchrNo = '" + dtGetReceipt.Rows[j]["userVchNo"].ToString() + "'");
                        }
                        catch
                        {
                            strGetStatus = "";
                        }
                        if (strGetStatus == "C")
                            boolBillStatus = true;

                    }

                    dtGetBillDetails.Rows[i]["ReciveAmount"] = doubleTotalAmount;
                    dtGetBillDetails.Rows[i]["Balance"] = Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount;

                    if (boolBillStatus && (Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount) == 0)
                    {
                        //dtGetBillDetails.Rows.RemoveAt(i);
                        //continue;
                    }

                    ClientBillAmtSubTotal = ClientBillAmtSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]);
                    ClientBillReceiptAmtSubTotal = ClientBillReceiptAmtSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"]);
                    ClientBillBalanceSubTotal = ClientBillBalanceSubTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"]);

                    try
                    {
                        if (dtGetBillDetails.Rows[i]["Cliant_ID"].ToString() != dtGetBillDetails.Rows[i + 1]["Cliant_ID"].ToString() && dtGetBillDetails.Rows[i]["Cliant_ID"].ToString().Trim() != "")
                        {
                            DataRow dr = dtGetBillDetails.NewRow();
                            dr["BILLNO"] = "Sub Total";
                            dr["ReciveAmount"] = ClientBillReceiptAmtSubTotal;
                            dr["Balance"] = ClientBillBalanceSubTotal;
                            dr["NETBILLAMOUNT"] = ClientBillAmtSubTotal;
                            if ((i + 1) < (dtGetBillDetails.Rows.Count - 1))
                                dtGetBillDetails.Rows.InsertAt(dr, i + 1);
                            else if ((i + 1) == (dtGetBillDetails.Rows.Count - 1))
                            {
                                dtGetBillDetails.Rows[i + 1].Delete();
                                dtGetBillDetails.Rows.InsertAt(dr, i + 1);
                            }
                        }
                    }
                    catch (Exception E)
                    {
                        string str = E.ToString();
                    }

                    dtGetBillDetails.Rows[i]["NETBILLAMOUNT"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"].ToString()), 2);
                    dtGetBillDetails.Rows[i]["ReciveAmount"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"].ToString()), 2);
                    dtGetBillDetails.Rows[i]["Balance"] = edpcom.GetAmountFormat(Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"].ToString()), 2);
                }
                dtGetBillDetails.Rows.Add();
                dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["BILLDATE"] = "Total";
                dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["NETBILLAMOUNT"] = edpcom.GetAmountFormat(ClientBillAmtTotal, 2);
                dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["ReciveAmount"] = edpcom.GetAmountFormat(ClientBillReceiptAmtTotal, 2);
                dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["Balance"] = edpcom.GetAmountFormat(ClientBillBalanceTotal, 2);
                dtMain = dtGetBillDetails;

                SQLFromDate = "Zone wise Receipt Register BillWise Summary Report During  " + dtpFromDate.Value.ToString("dd/MM/yyyy");
                SQLFromDate = SQLFromDate + "  To  " + dtpDateTo.Value.ToString("dd/MM/yyyy");
            }

            else if (rbBillWise.Checked)
            {
                Double BillAmtTotal = 0;
                Double BillReceiptAmtTotal = 0;
                Double BillBalanceTotal = 0;
                
                SQLFromDate = "Receipt Register BillWise Summary Report During  " + dtpFromDate.Value.ToString("dd/MM/yyyy");
                SQLFromDate = SQLFromDate + "  To  " + dtpDateTo.Value.ToString("dd/MM/yyyy");

                string strSQLFromDate = dtpFromDate.Value.Year + "-" + dtpFromDate.Value.Month + "-" + dtpFromDate.Value.Day;
                string strSQLToDate = dtpDateTo.Value.Year + "-" + dtpDateTo.Value.Month + "-" + dtpDateTo.Value.Day;
                string strGetBillDetails = "select BILLNO + (case when BillStatus='CANCELED' then char(10) +'[ CANCELED ]' else '' end ) as 'BillNo',"+
                "(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = Cliant_ID) as 'ClientName',"+
                "(select lm.Location_Name from tbl_Emp_Location lm where lm.Location_ID = paybill.Location_ID) as 'LocationName',"+
                "convert(varchar,[BILLDATE],103) as 'BILLDATE',"+
                "(case when BillStatus='CANCELED' then 0 else round(cast((TotAMT+ScAmt+ServiceAmount) as varchar),0) end) as 'NETBILLAMOUNT',"+
                "Cliant_ID,'' as 'ReciveAmount','' as 'Balance' from [paybill] where Comany_id = " + Company_ID + " and BILLDATE between '" + strSQLFromDate + "' and '" + strSQLToDate + "' order by BILLDATE asc";
                DataTable dtGetBillDetails = clsDataAccess.RunQDTbl(strGetBillDetails);
                //dtGetBillDetails.Rows.Add();

                for (int i = 0; i < dtGetBillDetails.Rows.Count; i++)
                {
                    Boolean boolBillStatus = false;
                    string strGetReceipt = "select [userVchNo],[tblName] from [tbl_Payment_Register] where [billNo] = '" + dtGetBillDetails.Rows[i]["BILLNO"].ToString() + "'";
                    DataTable dtGetReceipt = clsDataAccess.RunQDTbl(strGetReceipt);
                    Double doubleTotalAmount = 0.00;
                    for (int j = 0; j < dtGetReceipt.Rows.Count; j++)
                    {
                        string strGetReceiptDetailsAmount = clsDataAccess.GetresultS("select [amount] from " + dtGetReceipt.Rows[j]["tblName"].ToString() + " where vchrNo = '" + dtGetReceipt.Rows[j]["userVchNo"].ToString() + "'");
                        doubleTotalAmount = doubleTotalAmount + System.Math.Round(Convert.ToDouble(strGetReceiptDetailsAmount));
                        string strGetStatus = "";
                        try
                        {
                            strGetStatus = clsDataAccess.GetresultS("SELECT (case when instrumentClearDate is not null then 'C' end) as 'Status' FROM [tbl_Payment_Receipt_Register] where (reciptMmode = 'C' or reciptMmode = 'N') and vchrNo = '" + dtGetReceipt.Rows[j]["userVchNo"].ToString() + "'");
                        }
                        catch
                        {
                            strGetStatus = "";
                        }
                        if (strGetStatus == "C")
                            boolBillStatus = true;

                    }
                    dtGetBillDetails.Rows[i]["ReciveAmount"] = doubleTotalAmount;
                    dtGetBillDetails.Rows[i]["Balance"] = Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount;

                    if (boolBillStatus && (Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]) - doubleTotalAmount) == 0)
                    {
                        //dtGetBillDetails.Rows.RemoveAt(i);
                        //continue;
                    }

                    BillAmtTotal = BillAmtTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"]);
                    BillReceiptAmtTotal = BillReceiptAmtTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"]);
                    BillBalanceTotal = BillBalanceTotal + Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"]); ;

                    dtGetBillDetails.Rows[i]["NETBILLAMOUNT"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["NETBILLAMOUNT"].ToString()),2);
                    dtGetBillDetails.Rows[i]["ReciveAmount"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["ReciveAmount"].ToString()),2);
                    dtGetBillDetails.Rows[i]["Balance"] = edpcom.GetAmountFormat( Convert.ToDouble(dtGetBillDetails.Rows[i]["Balance"].ToString()),2);
                }
                dtGetBillDetails.Rows.Add();
                dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["BILLNO"] = "Total";
                dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["NETBILLAMOUNT"] = edpcom.GetAmountFormat(BillAmtTotal,2);
                dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["ReciveAmount"] = edpcom.GetAmountFormat(BillReceiptAmtTotal,2);
                dtGetBillDetails.Rows[dtGetBillDetails.Rows.Count - 1]["Balance"] = edpcom.GetAmountFormat(BillBalanceTotal,2);
                dtMain = dtGetBillDetails;

                SQLFromDate = "Receipt Register BillWise Summary Report During  " + dtpFromDate.Value.ToString("dd/MM/yyyy");
                SQLFromDate = SQLFromDate + "  To  " + dtpDateTo.Value.ToString("dd/MM/yyyy");
            }

            //Midasreport part
           

            string SQLToDate = dtpDateTo.Value.Day + "/" + dtpDateTo.Value.Month + "/" + dtpDateTo.Value.Year;
            string strCompanyAddress = clsDataAccess.GetresultS("select CO_ADD+' '+CO_ADD1 from Company where CO_CODE = " + Company_ID);
            MidasReport.Form1 mr = new MidasReport.Form1();
            mr.BillOutstandingReport(dtMain,cmbCompany.Text,strCompanyAddress,SQLFromDate,SQLToDate,"1");
            mr.Show();



        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] StrLine = this.cmbYear.Text.Trim().Split('-');
            dtpFromDate.MinDate = DateTimePicker.MinimumDateTime;
            dtpFromDate.MaxDate = DateTimePicker.MaximumDateTime;

            dtpDateTo.MinDate = DateTimePicker.MinimumDateTime;
            dtpDateTo.MaxDate = DateTimePicker.MaximumDateTime;

            dtpFromDate.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            dtpFromDate.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

            dtpDateTo.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            dtpDateTo.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

            dtpFromDate.Value = Convert.ToDateTime("01/April/" + StrLine[0]);



            dtpDateTo.Value = Convert.ToDateTime("31/March/" + StrLine[1]);

        }

        private void btnCLear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSelectAllClient_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAllClient.Checked == true)
            {
                btnSelectClient.Enabled = false;
            }
            else if (cbSelectAllClient.Checked == false)
            {
                btnSelectClient.Enabled = true;
            }
        }

        //private void vistaButton1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
