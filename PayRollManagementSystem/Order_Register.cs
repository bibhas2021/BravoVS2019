
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using Edpcom;

namespace PayRollManagementSystem
{
    public partial class Order_Register : Form//MstFrmDialog
    {
        int Company_id, Location_id;
        String sub;
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        public Order_Register()
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

        private void cmbCompany_Closeup(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbCompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbCompany.ReturnValue);
        }


        private void vistaButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Order_Register_Load(object sender, EventArgs e)
        {
            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbCompany.Text = Convert.ToString(dt_co.Rows[0][0]);

                Company_id = Convert.ToInt32(dt_co.Rows[0][1]);
                cmbCompany.ReturnValue = Company_id.ToString();
                cmbCompany.Enabled = false;


            }
            else if (dt_co.Rows.Count > 1)
            {
                cmbCompany.PopUp();

            }
          

            if (rdbloc.Checked)
            {

                cmbloc.Enabled = true;

            }
            if (rdbcomp.Checked)
            {

                cmbloc.Enabled = false;
            }

            fromdt.Value = Convert.ToDateTime("01/April/" + System.DateTime.Now.Year);
        }



        private void cmbloc_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID," +
            "(select client_name from tbl_Employee_CliantMaster where Client_id= el.Cliant_ID) as Client,el.Cliant_ID as ClientID  from tbl_Emp_Location el where (Location_ID IN (select Location_ID from Companywiseid_Relation where (Company_ID='" + Company_id + "'))) order by Location_Name");
               
            if (dt.Rows.Count > 0)
            {
                cmbloc.LookUpTable = dt;
                cmbloc.ReturnIndex = 1;
            }
        }

        private void cmbloc_DropDown_Closeup(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {

            if (Information.IsNumeric(cmbloc.ReturnValue) == true)
                Location_id = Convert.ToInt32(cmbloc.ReturnValue);
        }







        private void btnPreview_Click(object sender, EventArgs e)
        {
            int flag = 1;
            if (rdbloc.Checked == true)
            {
                DataTable dt = new DataTable();
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                String str = "SELECT o.Order_Name,od.Order_Date, (SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE Client_id = o.Cliant_ID) AS Party, ";
                str = str + "(SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE SlNo = od.desig_ID) AS Rank, od.Hour, od.MonthDays, od.RATE, Location ";
                str = str + "FROM tbl_Employee_OrderDetails o, tbl_Employee_OrderDetails_Dtl od WHERE od.Order_Date between '" + fromdt.Value.Year + "-" + fromdt.Value.Month + "-" + fromdt.Value.Day + "' AND '" + todt.Value.Year + "-" + todt.Value.Month + "-" + todt.Value.Day + "' AND Co_Code = '" + Company_id + "' AND Location = '" + cmbloc.Text + "' AND ( o.Order_Name=od.Order_Name )";
                dt = clsDataAccess.RunQDTbl(str);

                String Start_d = fromdt.Value.ToString("dd/MM/yyyy");
                String End_d = todt.Value.ToString("dd/MM/yyyy");


                sub = "Order Register Report During the period From " + fromdt.Value.ToString("dd/MM/yyyy");
                sub = sub + " To " + todt.Value.ToString("dd/MM/yyyy");
                MidasReport.Form1 rpt = new MidasReport.Form1();
                rpt.Order_Register(cmbCompany.Text, CO_ADD, sub, End_d, dt,flag);
                rpt.Show();
                //cmbCompany.ResetText();
                //cmbloc.ResetText();
            }
            else
            {
                DataTable dt = new DataTable();
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                String str = "SELECT o.Order_Name,od.Order_Date, (SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE Client_id = o.Cliant_ID) AS Party, ";
                str = str + "(SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE SlNo = od.desig_ID) AS Rank, od.Hour, od.MonthDays, od.RATE, Location ";
                str = str + "FROM tbl_Employee_OrderDetails o, tbl_Employee_OrderDetails_Dtl od WHERE od.Order_Date between '" + fromdt.Value.Year + "-" + fromdt.Value.Month + "-" + fromdt.Value.Day + "' AND '" + todt.Value.Year + "-" + todt.Value.Month + "-" + todt.Value.Day + "' AND Co_Code = '" + Company_id + "'  AND ( o.Order_Name=od.Order_Name )";
                dt = clsDataAccess.RunQDTbl(str);

                String Start_d = fromdt.Value.ToString("dd/MM/yyyy");
                String End_d = todt.Value.ToString("dd/MM/yyyy");


                sub = "Order Register Report During the period From " + fromdt.Value.ToString("dd/MM/yyyy");
                sub = sub + " To " + todt.Value.ToString("dd/MM/yyyy");
                MidasReport.Form1 rpt = new MidasReport.Form1();
                rpt.Order_Register(cmbCompany.Text, CO_ADD, sub, End_d, dt,flag);
                rpt.Show();
                //cmbCompany.ResetText();
               // cmbloc.ResetText();
            
            }
        }

        

        private void rdbloc_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdbcomp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbloc.Checked == true)
            {

                cmbloc.Enabled = true;
            }
            else
            {

                cmbloc.Text = "";
                cmbloc.Enabled = false;

            }
        }

        private void btnPrnt_Click(object sender, EventArgs e)
        {
            int flag = 2;
            if (rdbloc.Checked == true)
            {
                DataTable dt = new DataTable();
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                String str = "SELECT o.Order_Name,od.Order_Date, (SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE Client_id = o.Cliant_ID) AS Party, ";
                str = str + "(SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE SlNo = od.desig_ID) AS Rank, od.Hour, od.MonthDays, od.RATE, Location ";
                str = str + "FROM tbl_Employee_OrderDetails o, tbl_Employee_OrderDetails_Dtl od WHERE od.Order_Date between '" + fromdt.Value.Year + "-" + fromdt.Value.Month + "-" + fromdt.Value.Day + "' AND '" + todt.Value.Year + "-" + todt.Value.Month + "-" + todt.Value.Day + "' AND Co_Code = '" + Company_id + "' AND Location = '" + cmbloc.Text + "' AND ( o.Order_Name=od.Order_Name )";
                dt = clsDataAccess.RunQDTbl(str);

                String Start_d = fromdt.Value.ToString("dd/MM/yyyy");
                String End_d = todt.Value.ToString("dd/MM/yyyy");


                sub = "Order Register Report During the period From " + fromdt.Value.ToString("dd/MM/yyyy");
                sub = sub + " To " + todt.Value.ToString("dd/MM/yyyy");
                MidasReport.Form1 rpt = new MidasReport.Form1();
                rpt.Order_Register(cmbCompany.Text, CO_ADD, sub, End_d, dt, flag);
                //rpt.Show();
                
            }
            else
            {
                DataTable dt = new DataTable();
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                String str = "SELECT o.Order_Name,od.Order_Date, (SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE Client_id = o.Cliant_ID) AS Party, ";
                str = str + "(SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE SlNo = od.desig_ID) AS Rank, od.Hour, od.MonthDays, od.RATE, Location ";
                str = str + "FROM tbl_Employee_OrderDetails o, tbl_Employee_OrderDetails_Dtl od WHERE od.Order_Date between '" + fromdt.Value.Year + "-" + fromdt.Value.Month + "-" + fromdt.Value.Day + "' AND '" + todt.Value.Year + "-" + todt.Value.Month + "-" + todt.Value.Day + "' AND Co_Code = '" + Company_id + "'  AND ( o.Order_Name=od.Order_Name )";
                dt = clsDataAccess.RunQDTbl(str);

                String Start_d = fromdt.Value.ToString("dd/MM/yyyy");
                String End_d = todt.Value.ToString("dd/MM/yyyy");


                sub = "Order Register Report During the period From " + fromdt.Value.ToString("dd/MM/yyyy");
                sub = sub + " To " + todt.Value.ToString("dd/MM/yyyy");
                MidasReport.Form1 rpt = new MidasReport.Form1();
                rpt.Order_Register(cmbCompany.Text, CO_ADD, sub, End_d, dt, flag);
                //rpt.Show();
                

            }
      
        }

 }

       
        

      
        //private void btnPreview_Click(object sender, EventArgs e)
        // {
        //    DataTable dt = new DataTable();
        //    String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'");
        //    String str = "SELECT o.Order_ID, o.Order_Name, o.Order_Date, (SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE Client_id = o.Cliant_ID) AS Party, "; 
        //    str = str + "(SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE SlNo = od.desig_ID) AS Rank, od.Hour, od.MonthDays, od.RATE, Location ";
        //    str = str + "FROM tbl_Employee_OrderDetails o, tbl_Employee_OrderDetails_Dtl od WHERE Co_Code = '" + Company_id + "' AND Location = '" + cmbLocation.Text + "' AND o.Order_Name = od.Order_Name";
        //    dt = clsDataAccess.RunQDTbl(str);

        //    MidasReport.Form1 rpt = new MidasReport.Form1();
        //    rpt.Order_Register(cmbCompany.Text, CO_ADD, dt);
        //    rpt.Show();
        //    cmbCompany.ResetText();
        //    //cmbLocation.ResetText();
        //}
    }
