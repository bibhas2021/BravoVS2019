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
    public partial class frmAttendBill_diff : Form
    {
        int company_id = 0;
        DataTable dt = new DataTable();
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();


        public frmAttendBill_diff()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAttendBill_diff_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }

            AttenDtTmPkr.Value = DateAndTime.Now;


            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                CmbCompany.Text = dta.Rows[0][0].ToString();

                company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                CmbCompany.ReturnValue = company_id.ToString();

            }
            else if (dta.Rows.Count > 1)
            {
                CmbCompany.PopUp();
            }


          
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
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
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;

            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                company_id = Convert.ToInt32(CmbCompany.ReturnValue);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            get_data();
        }
        public void get_data()
        {
            string mon = AttenDtTmPkr.Value.ToString("M/yyyy");
            string month = AttenDtTmPkr.Value.ToString("MMMM");
            string qry = "";
            qry = "Select Location_ID,loc,wd,proxy,Total,(case when bd='Hrs' then (b_at/Hrs) else b_at end)as b_at,bd,(case when bd='Hrs' then ((b_at/Hrs)-Total) else (b_at-Total) end)as 'diff' from (select Location_ID,(Location_Name +'\n\r'+ (select Client_Name from tbl_Employee_CliantMaster where Client_id=el.Cliant_ID))as 'loc'," +
                     "(select isnull(cast(SUM(days_wd)as varchar),0)FROM tbl_Employee_Attend AS ea WHERE LOcation_ID=el.Location_ID and Company_id='"+company_id+"' AND (Month='"+mon+"') and Season='"+cmbYear.Text+"') AS wd,"+
                     "(select isnull(cast(SUM(days_ot)as varchar),0)FROM tbl_Employee_Attend AS ea WHERE LOcation_ID=el.Location_ID and Company_id='" + company_id + "' AND (Month='" + mon + "')and Season='" + cmbYear.Text + "') AS proxy," +
                     "(select ISNULL( cast(SUM(days_wd) +SUM(days_ot)as varchar),0)  FROM tbl_Employee_Attend AS ea WHERE LOcation_ID=el.Location_ID and Company_id='" + company_id + "' AND (Month='" + mon + "')and Season='" + cmbYear.Text + "')AS Total," +
                "(select isnull(sum(convert(float,Attendance)),0) from paybillD da where da.Location_ID=el.Location_ID and Company_id='" + company_id + "' and Month='" + month + "' and [Session]='" + cmbYear.Text + "' )as b_at ," +
                "(case when (select count(MonthDays) from paybillD da where da.Location_ID=el.Location_ID and (MonthDays='PerHour') and (Company_id='" + company_id + "') and (Month='" + month + "') and [Session]='" + cmbYear.Text + "' )>0 then 'Hrs' else '' end)as bd,"+
                "(select [Hour] from paybillD da where (da.Location_ID=el.Location_ID) and (MonthDays='PerHour') and (Company_id='" + company_id + "') and (Month='" + month + "') and ([Session]='" + cmbYear.Text + "')) as 'Hrs' " +
                 "from tbl_Emp_Location el where Cliant_ID in (select Client_id from tbl_Employee_CliantMaster where coid='"+company_id+"'))e order by loc";
            dt = clsDataAccess.RunQDTbl(qry);

            string sub = "For the month of "+AttenDtTmPkr.Value.ToString("MMMM,yyyy");
            string coadd=clsDataAccess.GetresultS("select CO_ADD from Company where GCODE = '" + company_id+ "' ");
            MidasReport.Form1 bat = new MidasReport.Form1();
            bat.attbill(CmbCompany.Text,coadd,sub,dt);
            bat.Show();

        }
    }
}
