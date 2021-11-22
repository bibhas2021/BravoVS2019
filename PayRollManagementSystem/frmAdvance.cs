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
namespace PayRollManagementSystem
{
    public partial class frmAdvance : MstRptDialog
        //EDPComponent.FormBaseRptMidium
    {
    
        public frmAdvance()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        DataTable dts=new DataTable();
        int company_id = 0;
        int Location = 0;
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();


        private void frmKYCException_Load(object sender, EventArgs e)
        {
            
        }
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

        public int get_LocationID(string name)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select Location_ID from tbl_Emp_Location where Location_Name='" + name + "'";
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

            //data_retrive_Company();
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            string s = " select  l.Location_Name,l.Location_ID  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID = " + get_CompID(cmbcompany.Text);
            DataTable dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                CmbLocation.LookUpTable = dt;
                CmbLocation.ReturnIndex = 1;
                //cmbsalstruc.Items.Clear();
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbLocation.ReturnValue) == true)
            {
                Location = Convert.ToInt32(CmbLocation.ReturnValue);

            }

        }

        //private void frmAdvance_Load(object sender, EventArgs e)
        //{
        //    clsValidation.GenerateYear(CmbSession, 2015, System.DateTime.Now.Year, 1);
        //}

        private void BtnAdvReport_Click(int ptype)
        {
            DataTable dt1 = clsDataAccess.RunQDTbl("select id from tbl_Employee_Mast where Company_id=" + company_id + "");
            dts.Clear();
            dt.Clear();
            String str = "select EAEID as Emp_ID,EANAME as Emp_Name,EAAMT as Amount,(SELECT CONVERT(VARCHAR(10), EADT, 101) AS [MM/DD/YYYY]) as Adv_Date,l.Location_Name as Location,'0' as Deduction,EAMONTH as Adv_Month from tbl_Employee_Advance a,tbl_Emp_Location l where a.LocID = l.Location_ID and EAMONTH ='" + dtmMonthSelect.Value.ToString("MMMM") + "/ " + dtmMonthSelect.Value.Year + "' and CoID=" + company_id + "";
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string id1 = dt1.Rows[i][0].ToString();
                //"select EAEID as id,EANAME as FirstName,'' as MiddleName,'' as LastName,EADT as date,EAAMT as AdvAmount,EAMONTH,(select s.Amount from tbl_Employee_SalaryDet s,tbl_Employee_DeductionSalayHead d where s.SalId=d.SlNo and d.SlNo in(select SlNo from tbl_Employee_DeductionSalayHead where SalaryHead_Short='adv' )and s.empid='" + id1 + "') as 'Amount' from tbl_employee_advance a,tbl_employee_mast m where a.EAEID=m.id and  m.session='" + CmbSession.Text + "'and m.company_id=" + get_CompID(cmbcompany.Text) + "and m.Location_id=" + get_LocationID(CmbLocation.Text) + "and m.id='" + id1 + "'"
                if (rdbCompany_Wise.Checked == true)
                {
                    if (rdbAdvance.Checked == true)
                    {
                        dt = clsDataAccess.RunQDTbl(str);
                    }
                    else if (rdbLoan.Checked == true)
                    {
                        dt = clsDataAccess.RunQDTbl("select ELEID as Emp_ID,ELNAME as Emp_Name,ELAMT as Amount,(SELECT CONVERT(VARCHAR(10), ELDT, 101) AS [MM/DD/YYYY]) as Adv_Date,l.Location_Name as Location,'0' as Deduction,ELMONTH as Adv_Month from tbl_Employee_LOAN n, tbl_Emp_Location l where n.LocID = l.Location_ID and ELMONTH ='" + dtmMonthSelect.Value.ToString("MMMM") + "/ " + dtmMonthSelect.Value.Year + "' and CoID=" + company_id + "");
                    }
                    else if (rdbKit.Checked == true)
                    {
                        dt = clsDataAccess.RunQDTbl("select EKEID as Emp_ID,EKNAME as Emp_Name,EKAMT as Amount,(SELECT CONVERT(VARCHAR(10), EKDT, 101) AS [MM/DD/YYYY]) as Adv_Date,l.Location_Name as Location,'0' as Deduction,EKMONTH as Adv_Month from tbl_Employee_KIT k, tbl_Emp_Location l where k.LocID = l.Location_ID and EKMONTH ='" + dtmMonthSelect.Value.ToString("MMMM") + "/ " + dtmMonthSelect.Value.Year + "' and CoID=" + company_id + "");
                    }
                }
                else if (rdbLocation_Wise.Checked == true)
                {
                    if (rdbAdvance.Checked == true)
                    {
                        dt = clsDataAccess.RunQDTbl(str + " and LocID=" + Location + "");
                    }
                    else if (rdbLoan.Checked == true)
                    {
                        dt = clsDataAccess.RunQDTbl("select ELEID as Emp_ID,ELNAME as Emp_Name,ELAMT as Amount,(SELECT CONVERT(VARCHAR(10), ELDT, 101) AS [MM/DD/YYYY]) as Adv_Date,l.Location_Name as Location,'0' as Deduction,ELMONTH as Adv_Month from tbl_Employee_LOAN n, tbl_Emp_Location l where n.LocID = l.Location_ID and ELMONTH ='" + dtmMonthSelect.Value.ToString("MMMM") + "/ " + dtmMonthSelect.Value.Year + "' and CoID=" + company_id + " and LocID=" + Location + "");
                    }
                    else if (rdbKit.Checked == true)
                    {
                        dt = clsDataAccess.RunQDTbl("select EKEID as Emp_ID,EKNAME as Emp_Name,EKAMT as Amount,(SELECT CONVERT(VARCHAR(10), EKDT, 101) AS [MM/DD/YYYY]) as Adv_Date,l.Location_Name as Location,'0' as Deduction,EKMONTH as Adv_Month from tbl_Employee_KIT k, tbl_Emp_Location l where k.LocID = l.Location_ID and EKMONTH ='" + dtmMonthSelect.Value.ToString("MMMM") + "/ " + dtmMonthSelect.Value.Year + "' and CoID=" + company_id + " and LocID=" + Location + "");

                    }
                    //dt = clsDataAccess.RunQDTbl(str);                    
                }
            }
                dts.Merge(dt);
                MidasReport.Form1 adv = new MidasReport.Form1();
                adv.AdvRpt(cmbcompany.Text, dtmMonthSelect.Value.ToString("MMMM/yyyy"), dts, ptype);
                if (ptype == 1)
                    adv.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            BtnAdvReport_Click(1);
        }

        private void btnPrnt_Click(object sender, EventArgs e)
        {
            BtnAdvReport_Click(2);
        }
      
        private void frmAdvance_Load(object sender, EventArgs e)
        {
            rdbCompany_Wise.Checked = true;
            rdbAdvance.Checked = true;

            cmbcompany.ReadOnlyText = true;

            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbcompany.Text = Convert.ToString(dt_co.Rows[0][0]);

                company_id = Convert.ToInt32(dt_co.Rows[0][1]);

            }
            else if (dt_co.Rows.Count > 1)
            {
                cmbcompany.PopUp();

            }
        }

        private void rdbCompany_Wise_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCompany_Wise.Checked == true)
            {
                CmbLocation.Enabled = false;
            }
            else
            {
                CmbLocation.Enabled = true;
            }
        }
      
    }
}
