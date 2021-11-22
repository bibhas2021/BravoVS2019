using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;

namespace PayRollManagementSystem
{
    public partial class frmPaymentRegisterReport : Form
    {
        int Company_ID = 0, Client_ID = 0, Location_ID = 0, zone = 0, ed_zone=0;
       // string BillNo = "";
        //string sql2 = "";
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        public frmPaymentRegisterReport()
        {
            InitializeComponent();
        }

        private void frmPaymentRegisterReport_Load(object sender, EventArgs e)
        {
          //  this.HeaderText = "Receipt Register";
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            OnLoad();
        }

        private void OnLoad()
        {
            rdb_all.Checked = true;
           // dtp_from.Value = DateTime.Now;
            //dtp_to.Value =DateTime.Now;


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
                grpZone.Visible = true;
            }
            else
            {
                rdbZone.Visible = false;
                grpZone.Visible = false;
            }
        }

       
       
        
        private void btnPreview_Click(object sender, EventArgs e)
        {
            DataTable dtMainTable = new DataTable();
          
            if (rdb_all.Checked == true) // it is used for all company
            {
                //dtMainTable = clsDataAccess.RunQDTbl("Select d.Client_Name,c.Location_Name,CONVERT(varchar(10),[dateOfInsertion],103), a.vchrNo,a.reciptMmode,a.bankName,a.branchName ,a.instrumentNo,a.instumentDate  from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and dateOfInsertion BETWEEN '" + dtp_from.Value + "' and '" + dtp_to.Value + "' order by dateOfInsertion asc ");


                //dtMainTable = clsDataAccess.RunQDTbl("select CONVERT(varchar(10),[dateOfInsertion],103) as 'Date',[userVchNo] as 'VoucherNo',[billNo] as 'BillNo',(select CONVERT(varchar(10),[BILLDATE],103) as 'BillDate' from [paybill] where BILLNO = tpr.[billNo]) as 'BillDate',[tblName],(select [Client_Name] from [tbl_Employee_CliantMaster] where [Client_id] = tpr.[ClientId]) as 'ClientName',(select [Location_Name] from [tbl_Emp_Location] where [Location_ID] = tpr.[LocationId]) as 'LocationName' from [tbl_Payment_Register] tpr where dateOfInsertion BETWEEN '" + dtp_from.Value + "' and '" + dtp_to.Value + "'  order by dateOfInsertion asc");


                dtMainTable = clsDataAccess.RunQDTbl("Select d.Client_Name,c.Location_Name, b.dateOfInsertion, a.vchrNo,(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)) AS 'reciptMmode',a.bankName,a.branchName ,a.instrumentNo,a.instumentDate ,b.billNo, a.amount from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and dateOfInsertion BETWEEN '" + dtp_from.Value.ToString("dd/MMM/yyyy") + "' and '" + dtp_to.Value.ToString("dd/MMM/yyyy") + "'  order by dateOfInsertion asc ");
            
               // dtMainTable=clsDataAccess.RunQDTbl("select ");
            
            }

            else if (rdb_company.Checked == true)   // it is used for a given company
            {

                string str;
               // str = "Select d.Client_Name,c.Location_Name,b.dateOfInsertion, a.vchrNo,a.reciptMmode,a.bankName,a.branchName ,a.instrumentNo,a.instumentDate ,b.billNo, a.amount from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and dateOfInsertion BETWEEN '" + dtp_from.Value.ToString("dd/MMM/yyyy") + "' and '" + dtp_to.Value.ToString("dd/MMM/yyyy") + "'   and [CompanyId] = " + Company_ID + " order by dateOfInsertion asc ";
                str = str = "Select d.Client_Name,c.Location_Name,b.dateOfInsertion, a.vchrNo,(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)) AS 'reciptMmode',a.bankName,a.branchName ,a.instrumentNo,a.instumentDate ,b.billNo, a.amount from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and dateOfInsertion BETWEEN '" + dtp_from.Value.ToString("dd/MMM/yyyy") + "' and '" + dtp_to.Value.ToString("dd/MMM/yyyy") + "'   and [CompanyId] = " + Company_ID + " order by dateOfInsertion asc ";
                
                dtMainTable = clsDataAccess.RunQDTbl(str);
            }
            else if (rdb_client.Checked == true) // it is used for a specific client
            {
                string str1;

                str1 = "Select d.Client_Name,c.Location_Name, b.dateOfInsertion, a.vchrNo,(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)) AS 'reciptMmode',a.bankName,a.branchName ,a.instrumentNo,a.instumentDate ,b.billNo, a.amount from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and dateOfInsertion BETWEEN '" + dtp_from.Value.ToString("dd/MMM/yyyy") + "' and '" + dtp_to.Value.ToString("dd/MMM/yyyy") + "'   and [ClientId] = " + Client_ID + " order by dateOfInsertion asc ";
                dtMainTable = clsDataAccess.RunQDTbl(str1);
                
            }
            else if (rdbZone.Checked == true)
            {
                string str1;

                str1 = "Select d.Client_Name,c.Location_Name, b.dateOfInsertion, a.vchrNo,(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)) AS 'reciptMmode',a.bankName,a.branchName ,a.instrumentNo,a.instumentDate ,b.billNo, a.amount from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and (dateOfInsertion BETWEEN '" + dtp_from.Value.ToString("dd/MMM/yyyy") + "' and '" + dtp_to.Value.ToString("dd/MMM/yyyy") + "') and ([Location_ID] in (select Location_ID from tbl_Emp_Location where (zid='" + cmbZone.ReturnValue + "'))) order by dateOfInsertion asc ";
                dtMainTable = clsDataAccess.RunQDTbl(str1);

            }
            else    // it is used for a specific location
            {
                string str2;

                str2 = "Select d.Client_Name,c.Location_Name, b.dateOfInsertion, a.vchrNo,(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)) AS 'reciptMmode',a.bankName,a.branchName ,a.instrumentNo,a.instumentDate ,b.billNo, a.amount from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and dateOfInsertion BETWEEN '" + dtp_from.Value.ToString("dd/MMM/yyyy") + "' and '" + dtp_to.Value.ToString("dd/MMM/yyyy") + "' and [Location_ID] = " + Location_ID + " order by dateOfInsertion asc ";
                dtMainTable = clsDataAccess.RunQDTbl(str2);
            }



            
            String Start_d = dtp_from.Value.ToString("dd/MMM/yyyy");
            String End_d = dtp_to.Value.ToString("dd/MMM/yyyy");
            string sub = "";
            if (rdbZone.Checked == true)
            {
                sub = "Receipt Register Report for zone ["+cmbZone.Text+"] During the period From " + dtp_from.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                sub = "Receipt  Register Report During the period From " + dtp_from.Value.ToString("dd/MM/yyyy");
            }
            sub = sub + " To " + dtp_to.Value.ToString("dd/MM/yyyy");
            string sa = cmbcompany.Text;
            String CO_ADD = "";
             CO_ADD=   clsDataAccess.GetresultS("SELECT isNull(CO_ADD,'') FROM Company WHERE CO_CODE = '" + Company_ID + "'");
            //if (CO_ADD.Trim() == "" || CO_ADD == null)
             if (sa.Trim() == "")
            {
                CO_ADD = "For all Company";

            }

            MidasReport.Form1 mr = new MidasReport.Form1();
            mr.PaymentRegisterReportPrint(sa,sub,CO_ADD,dtMainTable,0);
            mr.Show();

            dtMainTable.Dispose();

            
        }

       

     

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtMainTable = new DataTable();

            if (rdb_all.Checked == true) // it is used for all company
            {
                //dtMainTable = clsDataAccess.RunQDTbl("Select d.Client_Name,c.Location_Name,CONVERT(varchar(10),[dateOfInsertion],103), a.vchrNo,a.reciptMmode,a.bankName,a.branchName ,a.instrumentNo,a.instumentDate  from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and dateOfInsertion BETWEEN '" + dtp_from.Value + "' and '" + dtp_to.Value + "' order by dateOfInsertion asc ");


                //dtMainTable = clsDataAccess.RunQDTbl("select CONVERT(varchar(10),[dateOfInsertion],103) as 'Date',[userVchNo] as 'VoucherNo',[billNo] as 'BillNo',(select CONVERT(varchar(10),[BILLDATE],103) as 'BillDate' from [paybill] where BILLNO = tpr.[billNo]) as 'BillDate',[tblName],(select [Client_Name] from [tbl_Employee_CliantMaster] where [Client_id] = tpr.[ClientId]) as 'ClientName',(select [Location_Name] from [tbl_Emp_Location] where [Location_ID] = tpr.[LocationId]) as 'LocationName' from [tbl_Payment_Register] tpr where dateOfInsertion BETWEEN '" + dtp_from.Value + "' and '" + dtp_to.Value + "'  order by dateOfInsertion asc");


                dtMainTable = clsDataAccess.RunQDTbl("Select d.Client_Name,c.Location_Name, b.dateOfInsertion, a.vchrNo,(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)) AS 'reciptMmode',a.bankName,a.branchName ,a.instrumentNo,a.instumentDate ,b.billNo, a.amount from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and dateOfInsertion BETWEEN '" + dtp_from.Value.ToString("dd/MMM/yyyy") + "' and '" + dtp_to.Value.ToString("dd/MMM/yyyy") + "'  order by dateOfInsertion asc ");

                // dtMainTable=clsDataAccess.RunQDTbl("select ");

            }

            else if (rdb_company.Checked == true)   // it is used for a given company
            {

                string str;
                // str = "Select d.Client_Name,c.Location_Name,b.dateOfInsertion, a.vchrNo,a.reciptMmode,a.bankName,a.branchName ,a.instrumentNo,a.instumentDate ,b.billNo, a.amount from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and dateOfInsertion BETWEEN '" + dtp_from.Value.ToString("dd/MMM/yyyy") + "' and '" + dtp_to.Value.ToString("dd/MMM/yyyy") + "'   and [CompanyId] = " + Company_ID + " order by dateOfInsertion asc ";
                str = str = "Select d.Client_Name,c.Location_Name,b.dateOfInsertion, a.vchrNo,(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)) AS 'reciptMmode',a.bankName,a.branchName ,a.instrumentNo,a.instumentDate ,b.billNo, a.amount from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and dateOfInsertion BETWEEN '" + dtp_from.Value.ToString("dd/MMM/yyyy") + "' and '" + dtp_to.Value.ToString("dd/MMM/yyyy") + "'   and [CompanyId] = " + Company_ID + " order by dateOfInsertion asc ";

                dtMainTable = clsDataAccess.RunQDTbl(str);
            }
            else if (rdb_client.Checked == true) // it is used for a specific client
            {
                string str1;

                str1 = "Select d.Client_Name,c.Location_Name, b.dateOfInsertion, a.vchrNo,(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)) AS 'reciptMmode',a.bankName,a.branchName ,a.instrumentNo,a.instumentDate ,b.billNo, a.amount from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and dateOfInsertion BETWEEN '" + dtp_from.Value.ToString("dd/MMM/yyyy") + "' and '" + dtp_to.Value.ToString("dd/MMM/yyyy") + "'   and [ClientId] = " + Client_ID + " order by dateOfInsertion asc ";
                dtMainTable = clsDataAccess.RunQDTbl(str1);

            }
            else if (rdbZone.Checked == true)
            {
                string str1;

                str1 = "Select d.Client_Name,c.Location_Name, b.dateOfInsertion, a.vchrNo,(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)) AS 'reciptMmode',a.bankName,a.branchName ,a.instrumentNo,a.instumentDate ,b.billNo, a.amount from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and (dateOfInsertion BETWEEN '" + dtp_from.Value.ToString("dd/MMM/yyyy") + "' and '" + dtp_to.Value.ToString("dd/MMM/yyyy") + "') and ([Location_ID] in (select Location_ID from tbl_Emp_Location where (zid='" + cmbZone.ReturnValue + "'))) order by dateOfInsertion asc ";
                dtMainTable = clsDataAccess.RunQDTbl(str1);

            }
            else    // it is used for a specific location
            {
                string str2;

                str2 = "Select d.Client_Name,c.Location_Name, b.dateOfInsertion, a.vchrNo,(select (case[reciptMmode] when 'H' THEN 'CASH' when 'C' THEN 'CHEQUE' WHEN 'N' THEN 'NEFT' END)) AS 'reciptMmode',a.bankName,a.branchName ,a.instrumentNo,a.instumentDate ,b.billNo, a.amount from tbl_Payment_Receipt_Register a ,tbl_Payment_Register b ,tbl_Emp_Location c,tbl_Employee_CliantMaster d where a.vchrNo=b.userVchNo and b.LocationId=c.Location_ID and b.ClientId=d.Client_id and dateOfInsertion BETWEEN '" + dtp_from.Value.ToString("dd/MMM/yyyy") + "' and '" + dtp_to.Value.ToString("dd/MMM/yyyy") + "' and [Location_ID] = " + Location_ID + " order by dateOfInsertion asc ";
                dtMainTable = clsDataAccess.RunQDTbl(str2);
            }




            String Start_d = dtp_from.Value.ToString("dd/MMM/yyyy");
            String End_d = dtp_to.Value.ToString("dd/MMM/yyyy");
            string sub = "";
            sub = "Receipt  Register Report During the period From " + dtp_from.Value.ToString("dd/MM/yyyy");
            sub = sub + " To " + dtp_to.Value.ToString("dd/MM/yyyy");
            string sa = cmbcompany.Text;
            String CO_ADD = "";
            CO_ADD = clsDataAccess.GetresultS("SELECT isNull(CO_ADD,'') FROM Company WHERE CO_CODE = '" + Company_ID + "'");
            //if (CO_ADD.Trim() == "" || CO_ADD == null)
            if (sa.Trim() == "")
            {
                CO_ADD = "For all Company";

            }

            MidasReport.Form1 mr = new MidasReport.Form1();
            mr.PaymentRegisterReportPrint(sa, sub, CO_ADD, dtMainTable, 1);
            //mr.Show();

            dtMainTable.Dispose();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }







        private void cmbompany_DropDown(object sender, EventArgs e)
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
            cmbclient.Text = "";
            cmblocation.Text = "";
            
            if (Information.IsNumeric(cmbcompany.ReturnValue.Trim()))
                Company_ID = Convert.ToInt32(cmbcompany.ReturnValue.Trim());
        }

        private void cmbclient_DropDown(object sender, EventArgs e)
        {
            if (Company_ID == 0)
            {

            }
            else
            {
                DataTable dt = clsDataAccess.RunQDTbl("select [Client_Name],[Client_id] from [tbl_Employee_CliantMaster] where coid = " + Company_ID);
                if (dt.Rows.Count > 0)
                {
                    cmbclient.LookUpTable = dt;
                    cmbclient.ReturnIndex = 1;
                }
            }
        }

        private void cmbclient_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            cmblocation.Text = "";
           
            if (Information.IsNumeric(cmbclient.ReturnValue.Trim()))
                Client_ID = Convert.ToInt32(cmbclient.ReturnValue.Trim());
        }

        private void cmblocation_DropDown(object sender, EventArgs e)
        {
            if (Client_ID == 0)
            {

            }
            else
            {
                DataTable dt = clsDataAccess.RunQDTbl("select [Location_Name],[Location_ID] from tbl_Emp_Location where [Cliant_ID] = " + Client_ID);
                if (dt.Rows.Count > 0)
                {
                    cmblocation.LookUpTable = dt;
                    cmblocation.ReturnIndex = 1;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
           // cmbBill.Text = "";
           
            {
                Location_ID = Convert.ToInt32(cmblocation.ReturnValue);
            }
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

        private void cmbZone_DropDown(object sender, EventArgs e)
        {
            
            DataTable dt = clsDataAccess.RunQDTbl( "select zone as 'Zone Name',zid as 'Zone ID' from (Select zid,zone,(select count(*) from tbl_Emp_Location where zid=tz.zid)as active from tbl_Zone tz) zn where active>0");
            if (dt.Rows.Count > 0)
            {
                cmbZone.LookUpTable = dt;
                cmbZone.ReturnIndex = 1;
            }
        }

        private void cmbZone_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            try
            {
                zone = Convert.ToInt32(cmbZone.ReturnValue);
            }
            catch { zone = 0; }
        }

       

        private void rdb_all_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_all.Checked == true)
            {
                grpZone.Visible=false;
                cmbcompany.Enabled=false;
                cmblocation.Enabled=false;
                cmbclient.Enabled=false;

            }
            else if (rdb_company.Checked == true)
            {
                grpZone.Visible = false;
                cmbcompany.Enabled = true;
                cmblocation.Enabled = false;
                cmbclient.Enabled = false;

            }
            else if (rdb_client.Checked == true)
            {
                grpZone.Visible = false;
                cmbcompany.Enabled = true;
                cmblocation.Enabled = false;
                cmbclient.Enabled = true;

            }
            else if (rdb_location.Checked == true)
            {
                grpZone.Visible = false;
                cmbcompany.Enabled = true;
                cmblocation.Enabled = true;
                cmbclient.Enabled = true;

            }
            if (rdbZone.Checked == true)
            {
                grpZone.Visible = true;
                cmbcompany.Enabled = true;
                cmblocation.Enabled = false;
                cmbclient.Enabled = false;

            }

        }

       

       

        

    }
}
