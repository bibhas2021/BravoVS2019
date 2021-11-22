using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frmLedgerAccount : Form
    {
        int Location_ID = 0, Company_ID = 0, ed_zone=0;
        string cl = "", loc = "", comp = "", sub = "", Start_d = "", qry = "", Client_ID = "";
        DataTable dt_main = new DataTable();
        DataTable dt_com = new DataTable();
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        public frmLedgerAccount()
        {
            InitializeComponent();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] StrLine = this.cmbYear.Text.Trim().Split('-');
            dtp_from.MinDate = DateTimePicker.MinimumDateTime;
            dtp_from.MaxDate = DateTimePicker.MaximumDateTime;

            dtp_to.MinDate = DateTimePicker.MinimumDateTime;
            dtp_to.MaxDate = DateTimePicker.MaximumDateTime;

            dtp_from.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            dtp_from.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

            dtp_to.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            dtp_to.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

            dtp_from.Value = Convert.ToDateTime("01/April/" + StrLine[0]);



            dtp_to.Value = Convert.ToDateTime("31/March/" + StrLine[1]);

       
        }

        private void frmLedgerAccount_Load(object sender, EventArgs e)
        {
            rdbComp.Checked = true;

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

            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                cmbcompany.Text = dta.Rows[0][0].ToString();

                Company_ID = Convert.ToInt32(dta.Rows[0][1].ToString());
                cmbcompany.ReturnValue = Company_ID.ToString();
                cmbcompany.Enabled = false;

            }
            else if (dta.Rows.Count > 1)
            {
                cmbcompany.PopUp();
            }
           
      
        }

        private void cmbclient_DropDown(object sender, EventArgs e)
        {
            
            //DataTable dt = clsDataAccess.RunQDTbl(s);
            //if (dt.Rows.Count > 0)
            //{
            //    cmbclient.LookUpTable = dt;
            //    cmbclient.ReturnIndex = 1;
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbclient_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            //if (Information.IsNumeric(cmbclient.ReturnValue.Trim()))
            //    Client_ID = Convert.ToInt32(cmbclient.ReturnValue.Trim());
  
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
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue.Trim()))
                Company_ID = Convert.ToInt32(cmbcompany.ReturnValue.Trim());
       
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            string s = "";
            if (rdbLocation.Checked == true)
            {
                s = "select  l.Location_Name, l.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l,Companywiseid_Relation ls where l.Location_ID = ls.Location_ID and ls.Company_ID='" + Company_ID + "'";
            }
            else if (rdbZone.Checked==true)
            {
                s = "select zone as 'Zone Name',zid as 'Zone ID' from (Select zid,zone,(select count(*) from tbl_Emp_Location where zid=tz.zid)as active from tbl_Zone tz) zn where active>0";
            }
            DataTable dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (rdbLocation.Checked == true)
            {
                if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                {
                    Location_ID = Convert.ToInt32(cmbLocation.ReturnValue);
                    cmbLocation.Text = cmbLocation.Text + " - " + clsDataAccess.ReturnValue("select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l where l.Location_ID =" + Location_ID);
                    get_clientid();
                }
            }
        }

        //private void label6_Click(object sender, EventArgs e)
        //{

        //}

        public void get_clientid()
       {
           string ss = "select Cliant_ID from tbl_Emp_Location where Location_ID=" + Location_ID;
           DataTable dt = clsDataAccess.RunQDTbl(ss);
           Client_ID = dt.Rows[0]["Cliant_ID"].ToString();
       }

        public void getdata()
        {
            
            //string qry = "";

            //qry = "select BILLNO,cast(convert(datetime,BILLDATE,103)as date)as BILLDATE,Month," +
            //      "round(ISNULL((TotAMT + ServiceAmount + ScAmt), 0),0) AS BILL," +
            //      "(select Client_Name from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clientname' ," +
            //       "(select Client_id from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clid'," +
            //       "(select Location_Name from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'location'," +
            //       "(select Location_ID from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'lid'," +
            //       "isnull((select (opNetLedger) from tbl_op_balance where (locid=pb.location_id) and (coid=pb.comany_id) and (clid=pb.cliant_id)),0)as op," +
            //      "round((select (AMOUNT) FROM tbl_TDS_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id))),0)as tds," +
            //      "round((select (AMOUNT) FROM tbl_payment_receipt_register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id))),0)as pymt," +
            //      "(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)from tbl_Payment_Receipt_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id)))as 'mode'," +
            //      "(select cast(convert(datetime,instumentDate,103)as date) from tbl_Payment_Receipt_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id)))as 'reciptdate'," +
            //      "(select instrumentNo from tbl_Payment_Receipt_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id)))as 'chequeNo'," +
            //       "round((select (AMOUNT) FROM tbl_OTH_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id))),0)as othr " +
            //        "from paybill pb where pb.Cliant_ID='" + Client_ID + "' and pb.Location_ID='" + Location_ID + "'and pb.Comany_id='" + Company_ID + "' and pb.Session='" + cmbYear.Text + "'order by BILLDATE";

            int flag = 0;
            if (rdbLocation.Checked == true)
            {
                 
                    //"select pb.BILLNO,cast(convert(datetime,BILLDATE,103)as date)as BILLDATE,Month," +
                    // "round(ISNULL((TotAMT + ServiceAmount + ScAmt), 0),0) AS BILL," +
                    // "(select Client_Name from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clientname' ,(select Client_id from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clid',(select Location_Name from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'location',(select Location_ID from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'lid'," +
                    // "isnull((select (opNetLedger) from tbl_op_balance where (locid=pb.location_id) and (coid=pb.comany_id) and (clid=pb.cliant_id)),0)as op," +
                    // "round((select (AMOUNT) FROM tbl_TDS_Register where vchrNo  = pb.BillNo),0)as tds," +
                    // "round((select (AMOUNT) FROM tbl_payment_receipt_register where vchrNo  = pb.BillNo),0)as pymt," +
                    // "(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo) as 'mode'," +
                    // "(select cast(convert(datetime,instumentDate,103)as date) from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo )as 'reciptdate'," +
                    // "(select TOP 1 instrumentNo from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo )as 'chequeNo'," +
                    // "round((select (AMOUNT) FROM tbl_OTH_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_OTH_Register'))),0)as othr " +
                     
                qry ="select PB.BILLNO,cast(convert(datetime,BILLDATE,103)as date)as BILLDATE,Month,round(ISNULL((TotAMT + ServiceAmount + ScAmt), 0),0) AS BILL,(select Client_Name from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clientname' ,(select Client_id from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clid',(select Location_Name from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'location',(select Location_ID from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'lid'," +
                "isnull((select (opNetLedger) from tbl_op_balance where (locid=pb.location_id) and (coid=pb.comany_id) and (clid=pb.cliant_id) and (sess=pb.Session)),0)as op," +
                "isNull(round((select sum(AMOUNT) FROM tbl_TDS_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_TDS_Register'))),0),0) as tds," +
                "isNull(round((select sum(AMOUNT) FROM tbl_payment_receipt_register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_Payment_Receipt_Register'))),0),0) as pymt," +
                "isNull(substring((select distinct ', ' + (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END) from tbl_Payment_Receipt_Register where vchrNo in (SELECT distinct userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_Payment_Receipt_Register')) for xml path('')),2,1000),'') as 'mode'," +
                "isNull(substring((select distinct ', ' + cast(convert(VARCHAR(11),instumentDate,103)as nvarchar)  from tbl_Payment_Receipt_Register where vchrNo in (SELECT distinct userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_Payment_Receipt_Register')) for xml path('')),2,1000),'') as 'reciptdate'," +
                "isNull(substring((select distinct ', ' + instrumentNo from tbl_Payment_Receipt_Register where vchrNo in (SELECT distinct userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_Payment_Receipt_Register'))for xml path('')),2,1000),'')as 'chequeNo'," +
                "ISNULL(round((select sum(AMOUNT) FROM tbl_OTH_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_OTH_Register'))),0),0) as othr " +
                     
                     " from paybill as pb where (Cliant_ID='" + Client_ID + "') and (Location_ID='" + Location_ID + "') and (Comany_id='" + Company_ID + "') and (Session='" + cmbYear.Text + "') order by BILLDATE";
                
                
                //INNER JOIN tbl_Payment_Register AS PR ON pb.BILLNO = PR.billNo AND pb.Location_ID = PR.LocationId AND pb.Comany_id = PR.CompanyId AND pb.Cliant_ID = PR.ClientId " +
                //AND (PR.tblName='tbl_Payment_Receipt_Register')     

            }
            else if (rdbZone.Checked == true)
            {

                //"select pb.BILLNO,cast(convert(datetime,BILLDATE,103)as date)as BILLDATE,Month," +
                // "round(ISNULL((TotAMT + ServiceAmount + ScAmt), 0),0) AS BILL," +
                // "(select Client_Name from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clientname' ,(select Client_id from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clid',(select Location_Name from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'location',(select Location_ID from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'lid'," +
                // "isnull((select (opNetLedger) from tbl_op_balance where (locid=pb.location_id) and (coid=pb.comany_id) and (clid=pb.cliant_id)),0)as op," +
                // "round((select (AMOUNT) FROM tbl_TDS_Register where vchrNo  = pb.BillNo),0)as tds," +
                // "round((select (AMOUNT) FROM tbl_payment_receipt_register where vchrNo  = pb.BillNo),0)as pymt," +
                // "(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo) as 'mode'," +
                // "(select cast(convert(datetime,instumentDate,103)as date) from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo )as 'reciptdate'," +
                // "(select TOP 1 instrumentNo from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo )as 'chequeNo'," +
                // "round((select (AMOUNT) FROM tbl_OTH_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_OTH_Register'))),0)as othr " +

                qry = "select PB.BILLNO,cast(convert(datetime,BILLDATE,103)as date)as BILLDATE,Month,round(ISNULL((TotAMT + ServiceAmount + ScAmt), 0),0) AS BILL,(select Client_Name from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clientname' ,(select Client_id from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clid',(select Location_Name from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'location',(select Location_ID from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'lid'," +
                "isnull((select (opNetLedger) from tbl_op_balance where (locid=pb.location_id) and (coid=pb.comany_id) and (clid=pb.cliant_id) and (sess=pb.Session)),0)as op," +
                "isNull(round((select sum(AMOUNT) FROM tbl_TDS_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_TDS_Register'))),0),0) as tds," +
                "isNull(round((select sum(AMOUNT) FROM tbl_payment_receipt_register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_Payment_Receipt_Register'))),0),0) as pymt," +
                "isNull(substring((select distinct ', ' + (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END) from tbl_Payment_Receipt_Register where vchrNo in (SELECT distinct userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_Payment_Receipt_Register')) for xml path('')),2,1000),'') as 'mode',"+
                "isNull(substring((select distinct ', ' + cast(convert(VARCHAR(11),instumentDate,103)as nvarchar)  from tbl_Payment_Receipt_Register where vchrNo in (SELECT distinct userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_Payment_Receipt_Register')) for xml path('')),2,1000),'') as 'reciptdate',"+
                "isNull(substring((select distinct ', ' + instrumentNo from tbl_Payment_Receipt_Register where vchrNo in (SELECT distinct userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_Payment_Receipt_Register'))for xml path('')),2,1000),'')as 'chequeNo'," +
                "ISNULL(round((select sum(AMOUNT) FROM tbl_OTH_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_OTH_Register'))),0),0) as othr " +
                     
                    "from paybill as pb where (Location_ID in (select Location_ID from tbl_Emp_Location where (zid='" + cmbLocation.ReturnValue + "'))) and (Comany_id='" + Company_ID + "') and (Session='" + cmbYear.Text + "') order by BILLDATE";
                //INNER JOIN tbl_Payment_Register AS PR ON pb.BILLNO = PR.billNo AND pb.Location_ID = PR.LocationId AND pb.Comany_id = PR.CompanyId AND pb.Cliant_ID = PR.ClientId " +
                //AND (PR.tblName='tbl_Payment_Receipt_Register')
                    


            }
            dt_main = clsDataAccess.RunQDTbl(qry);

             cl ="" ;
             loc = "";
            comp = clsDataAccess.GetresultS("select CO_NAME from Company where CO_CODE=" + Company_ID  );
            sub = "FROM "+dtp_from.Value.ToString("dd/MM/yyyy")+"   TO "+dtp_to.Value.ToString("dd/MM/yyyy");
            Start_d = dtp_from.Value.ToString("dd/MM/yyyy");

            MidasReport.Form1 led = new MidasReport.Form1();
            led.ledacc(cl, loc, comp,sub,Start_d, dt_main,flag);
            led.Show();
            
        }

        public void getdata_1()
        {
            //DataTable dt_cl = new DataTable();
            //string sql = "";
            

            //sql = "SELECT ec.Client_Name + CHAR(13) + CHAR(10) + '['+ el.Location_Name + ']' as 'client_loc', el.Cliant_ID as 'clid',el.Location_ID as 'locid' FROM tbl_Employee_CliantMaster AS ec INNER JOIN tbl_Emp_Location AS el ON ec.Client_id = el.Cliant_ID WHERE (ec.coid = 1) order by client_loc";
            //dt_cl = clsDataAccess.RunQDTbl(sql);

            //for (int ind = 0; ind < dt_cl.Rows.Count; ind++)
            //{
            int flag = 0;

            //"select pb.BILLNO,cast(convert(datetime,BILLDATE,103)as date)as BILLDATE,Month," +
            // "round(ISNULL((TotAMT + ServiceAmount + ScAmt), 0),0) AS BILL," +
            // "(select Client_Name from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clientname' ,(select Client_id from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clid',(select Location_Name from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'location',(select Location_ID from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'lid'," +
            // "isnull((select (opNetLedger) from tbl_op_balance where (locid=pb.location_id) and (coid=pb.comany_id) and (clid=pb.cliant_id)),0)as op," +
            // "round((select (AMOUNT) FROM tbl_TDS_Register where vchrNo  = pb.BillNo),0)as tds," +
            // "round((select (AMOUNT) FROM tbl_payment_receipt_register where vchrNo  = pb.BillNo),0)as pymt," +
            // "(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo) as 'mode'," +
            // "(select cast(convert(datetime,instumentDate,103)as date) from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo )as 'reciptdate'," +
            // "(select TOP 1 instrumentNo from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo )as 'chequeNo'," +
            // "round((select (AMOUNT) FROM tbl_OTH_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_OTH_Register'))),0)as othr " +

            qry = "select PB.BILLNO,cast(convert(datetime,BILLDATE,103)as date)as BILLDATE,Month,round(ISNULL((TotAMT + ServiceAmount + ScAmt), 0),0) AS BILL,(select Client_Name from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clientname' ,(select Client_id from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clid',(select Location_Name from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'location',(select Location_ID from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'lid'," +
            "isnull((select (opNetLedger) from tbl_op_balance where (locid=pb.location_id) and (coid=pb.comany_id) and (clid=pb.cliant_id) and (sess=pb.Session)),0)as op," +
            "isNull(round((select sum(AMOUNT) FROM tbl_TDS_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_TDS_Register'))),0),0) as tds," +
            "isNull(round((select sum(AMOUNT) FROM tbl_payment_receipt_register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_Payment_Receipt_Register'))),0),0) as pymt," +
            "isNull(substring((select distinct ', ' + (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END) from tbl_Payment_Receipt_Register where vchrNo in (SELECT distinct userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_Payment_Receipt_Register')) for xml path('')),2,1000),'') as 'mode'," +
            "isNull(substring((select distinct ', ' + cast(convert(VARCHAR(11),instumentDate,103)as nvarchar)  from tbl_Payment_Receipt_Register where vchrNo in (SELECT distinct userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_Payment_Receipt_Register')) for xml path('')),2,1000),'') as 'reciptdate'," +
            "isNull(substring((select distinct ', ' + instrumentNo from tbl_Payment_Receipt_Register where vchrNo in (SELECT distinct userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_Payment_Receipt_Register'))for xml path('')),2,1000),'')as 'chequeNo'," +
            "ISNULL(round((select sum(AMOUNT) FROM tbl_OTH_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_OTH_Register'))),0),0) as othr " +
                     
             " from  paybill AS pb where Comany_id='" + Company_ID + "'  and Session='" + cmbYear.Text + "' order by lid,BILLDATE ";
            //INNER JOIN tbl_Payment_Register AS PR ON pb.BILLNO = PR.billNo AND pb.Location_ID = PR.LocationId AND " +
                //"pb.Comany_id = PR.CompanyId AND pb.Cliant_ID = PR.ClientId " +  AND (PR.tblName='tbl_Payment_Receipt_Register')

                      


                dt_main = clsDataAccess.RunQDTbl(qry);


                cl = "";
                loc = "";
                comp = clsDataAccess.GetresultS("select CO_NAME from Company where CO_CODE=" + Company_ID);
                sub = "FROM " + dtp_from.Value.ToString("dd/MM/yyyy") + "   TO " + dtp_to.Value.ToString("dd/MM/yyyy");
                Start_d = dtp_from.Value.ToString("dd/MM/yyyy");


                MidasReport.Form1 led = new MidasReport.Form1();
                led.ledacc(cl, loc, comp, sub, Start_d, dt_main,flag);
                led.Show();
            //}
            //dataGridView1.DataSource = dt_com;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (rdbLocation.Checked == true)
            {
                if (cmbLocation.Text != "")
                {
                    getdata();
                }
                else
                {
                    MessageBox.Show("Please select location");
                    return;
                }
            }
            else if (rdbZone.Checked == true)
            {
                if (cmbLocation.Text != "")
                {
                    getdata();
                }
                else
                {
                    MessageBox.Show("Please select Zone");
                    return;
                }
            }
            else
                if (rdbComp.Checked == true)
                {
                    getdata_1();
                }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {

                dta = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            }
            if (rdbComp.Checked == true)
            {
                
                if (dta.Rows.Count == 1)
                {
                    cmbcompany.Enabled = false;
                }
                else if (dta.Rows.Count > 1)
                {
                    cmbcompany.Enabled = true;
                }

                lbltype.Text = "";
                cmbLocation.Visible = false;
                //cmbclient.Enabled = false;
                cmbLocation.Enabled = false;
            }
            else if (rdbZone.Checked == true)
            {

                lbltype.Text = "Zone";
                if (dta.Rows.Count == 1)
                {
                    cmbcompany.Enabled = false;
                }
                else if (dta.Rows.Count > 1)
                {
                    cmbcompany.Enabled = true;
                }
                cmbLocation.Visible = true;
                cmbLocation.Enabled = true;
                //cmbLocation.PopUp();
            }
            else
            {
                lbltype.Text = "Location";
                if (dta.Rows.Count == 1)
                {
                    cmbcompany.Enabled = false;
                }
                else if (dta.Rows.Count > 1)
                {
                    cmbcompany.Enabled = true;
                }
                cmbLocation.Visible = true;
                cmbLocation.Enabled = true;
                //cmbclient.Enabled = true;
                //cmbLocation.PopUp();
            }
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            int flag = 1;
            if (rdbLocation.Checked == true)
            {
                if (cmbLocation.Text != "")
                {
                    qry = "select pb.BILLNO,cast(convert(datetime,BILLDATE,103)as date)as BILLDATE,Month," +
                    "round(ISNULL((TotAMT + ServiceAmount + ScAmt), 0),0) AS BILL," +
                    "(select Client_Name from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clientname' ,(select Client_id from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clid',(select Location_Name from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'location',(select Location_ID from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'lid'," +
                    "isnull((select (opNetLedger) from tbl_op_balance where (locid=pb.location_id) and (coid=pb.comany_id) and (clid=pb.cliant_id)),0)as op," +
                    "round((select (AMOUNT) FROM tbl_TDS_Register where vchrNo  = pb.BillNo),0)as tds," +
                    "round((select (AMOUNT) FROM tbl_payment_receipt_register where vchrNo  = pb.BillNo),0)as pymt," +
                    "(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo)as 'mode'," +
                    "(select cast(convert(datetime,instumentDate,103)as date) from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo )as 'reciptdate'," +
                    "(select TOP 1 instrumentNo from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo )as 'chequeNo'," +
                    "round((select (AMOUNT) FROM tbl_OTH_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_OTH_Register'))),0)as othr " +
                    " from paybill as pb where Cliant_ID='" + Client_ID + "' and Location_ID='" + Location_ID + "'and Comany_id='" + Company_ID + "' and Session='" + cmbYear.Text + "' order by BILLDATE"; 
                    //INNER JOIN tbl_Payment_Register AS PR ON pb.BILLNO = PR.billNo AND pb.Location_ID = PR.LocationId AND pb.Comany_id = PR.CompanyId AND pb.Cliant_ID = PR.ClientId " +
                    //AND (PR.tblName='tbl_Payment_Receipt_Register')
                    


                    dt_main = clsDataAccess.RunQDTbl(qry);

                    cl = "";
                    loc = "";
                    comp = clsDataAccess.GetresultS("select CO_NAME from Company where CO_CODE=" + Company_ID);
                    sub = "FROM " + dtp_from.Value.ToString("dd/MM/yyyy") + "   TO " + dtp_to.Value.ToString("dd/MM/yyyy");
                    Start_d = dtp_from.Value.ToString("dd/MM/yyyy");

                    MidasReport.Form1 led = new MidasReport.Form1();
                    led.ledacc(cl, loc, comp, sub, Start_d, dt_main, flag);
                    //led.Show();
                }
                else if (rdbZone.Checked == true)
                {
                    if (cmbLocation.Text != "")
                    {
                        qry = "select pb.BILLNO,cast(convert(datetime,BILLDATE,103)as date)as BILLDATE,Month," +
                        "round(ISNULL((TotAMT + ServiceAmount + ScAmt), 0),0) AS BILL," +
                        "(select Client_Name from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clientname' ,(select Client_id from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clid',(select Location_Name from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'location',(select Location_ID from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'lid'," +
                        "isnull((select (opNetLedger) from tbl_op_balance where (locid=pb.location_id) and (coid=pb.comany_id) and (clid=pb.cliant_id)),0)as op," +
                        "round((select (AMOUNT) FROM tbl_TDS_Register where vchrNo  = pb.BillNo),0)as tds," +
                        "round((select (AMOUNT) FROM tbl_payment_receipt_register where vchrNo  = pb.BillNo),0)as pymt," +
                        "(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo)as 'mode'," +
                        "(select cast(convert(datetime,instumentDate,103)as date) from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo )as 'reciptdate'," +
                        "(select TOP 1 instrumentNo from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo )as 'chequeNo'," +
                        "round((select (AMOUNT) FROM tbl_OTH_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_OTH_Register'))),0)as othr " +
                        " from paybill as pb where (Location_ID in (select Location_ID from tbl_Emp_Location where (zid='" + cmbLocation.ReturnValue + "'))) and Comany_id='" + Company_ID + "' and Session='" + cmbYear.Text + "' order by BILLDATE";
                        //INNER JOIN tbl_Payment_Register AS PR ON pb.BILLNO = PR.billNo AND pb.Location_ID = PR.LocationId AND pb.Comany_id = PR.CompanyId AND pb.Cliant_ID = PR.ClientId " +
                        //AND (PR.tblName='tbl_Payment_Receipt_Register')



                        dt_main = clsDataAccess.RunQDTbl(qry);

                        cl = "";
                        loc = "";
                        comp = clsDataAccess.GetresultS("select CO_NAME from Company where CO_CODE=" + Company_ID);
                        sub = "FROM " + dtp_from.Value.ToString("dd/MM/yyyy") + "   TO " + dtp_to.Value.ToString("dd/MM/yyyy");
                        Start_d = dtp_from.Value.ToString("dd/MM/yyyy");

                        MidasReport.Form1 led = new MidasReport.Form1();
                        led.ledacc(cl, loc, comp, sub, Start_d, dt_main, flag);
                        //led.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please select Zone");
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
                if (rdbComp.Checked == true)
                {
                    qry = "select " +
                        "PB.BILLNO,cast(convert(datetime,BILLDATE,103)as date)as BILLDATE,Month,round(ISNULL((TotAMT + ServiceAmount + ScAmt), 0),0) AS BILL," +
                        "(select Client_Name from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clientname' ," +
                        "(select Client_id from tbl_Employee_CliantMaster where Client_id=pb.Cliant_ID)as'clid'," +
                        "(select Location_Name from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'location'," +
                        "(select Location_ID from tbl_Emp_Location where Location_ID=pb.Location_ID and Cliant_ID=pb.Cliant_ID)as'lid'," +
                        "isnull((select (opNetLedger) from tbl_op_balance where (locid=pb.location_id) and (coid=pb.comany_id) and (clid=pb.cliant_id)),0)as op," +
                        "round((select (AMOUNT) FROM tbl_TDS_Register where vchrNo  = pb.BillNo),0)as tds," +
                        "round((select (AMOUNT) FROM tbl_payment_receipt_register where vchrNo  = pb.BillNo),0)as pymt," +
                        "(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo)as 'mode'," +
                        "(select cast(convert(datetime,instumentDate,103)as date) from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo )as 'reciptdate'," +
                        "(select TOP 1 instrumentNo from tbl_Payment_Receipt_Register where vchrNo = pb.BillNo )as 'chequeNo'," +
                        "ISNULL(round((select (AMOUNT) FROM tbl_OTH_Register where vchrNo in (SELECT userVchNo FROM tbl_Payment_Register WHERE (billNo=pb.BILLNO) and (LocationId=pb.location_id) and (CompanyId=pb.comany_id) and (ClientId=pb.cliant_id) and (tblName='tbl_OTH_Register'))),0),0)as othr " +
                         "from  paybill AS pb where  Comany_id='" + Company_ID + "' and Session='" + cmbYear.Text + "' order by BILLDATE ";
                    //INNER JOIN tbl_Payment_Register AS PR ON pb.BILLNO = PR.billNo AND pb.Location_ID = PR.LocationId AND " +              "pb.Comany_id = PR.CompanyId AND pb.Cliant_ID = PR.ClientId " + AND (PR.tblName='tbl_Payment_Receipt_Register')
                       


                    dt_main = clsDataAccess.RunQDTbl(qry);


                    cl = "";
                    loc = "";
                    comp = clsDataAccess.GetresultS("select CO_NAME from Company where CO_CODE=" + Company_ID);
                    sub = "FROM " + dtp_from.Value.ToString("dd/MM/yyyy") + "   TO " + dtp_to.Value.ToString("dd/MM/yyyy");
                    Start_d = dtp_from.Value.ToString("dd/MM/yyyy");


                    MidasReport.Form1 led = new MidasReport.Form1();
                    led.ledacc(cl, loc, comp, sub, Start_d, dt_main,flag);
                    //led.Show();

                }

        }
    }
}
