using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace PayRollManagementSystem
{
    public partial class frmHoliday : MstRptDialog
    {
        public frmHoliday()
        {
            InitializeComponent();
        }

        private void frmHoliday_Load(object sender, EventArgs e)
        {
            //AttenDtTmPkr.Items.Clear();
            //clsValidation.GenerateYear(CmbSession, 1950, System.DateTime.Now.Year, 1);
            DataTable dadt = clsDataAccess.RunQDTbl("select distinct Year(holdate) as HYear from tbl_employee_holiday");
            //for (int j = 0; j < dadt.Rows.Count; j++)
            //{
            //    AttenDtTmPkr.Items.Add( dadt.Rows[j]["HYear"].ToString());

            //}
            //AttenDtTmPkr.SelectedItem = System.DateTime.Now.Year.ToString();
        }

        private void CmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
           // compname();
        }
     
        DataTable dt = new DataTable();
        DataTable holdt = new DataTable();

        private void BtnHolidayList_Click(int ptype)
        {
            string[] ar = new string[12];
            ar[0] = "April";
            ar[1] = "May";
            ar[2] = "June";
            ar[3] = "July";
            ar[4] = "August";
            ar[5] = "September";
            ar[6] = "October";
            ar[7] = "November";
            ar[8] = "December";
            ar[9] = "January";
            ar[10] = "February";
            ar[11] = "March";
            int mon = 0;
            
            DateTime dat = new DateTime();
            int j;
            DataTable dadt = clsDataAccess.RunQDTbl("select distinct MONTH(holdate) as Mnth from tbl_employee_holiday where Year(holdate)='" + AttenDtTmPkr.Text + "'");
            int k = 0;


            for (j = 0; j < dadt.Rows.Count; j++)
            {
                mon = Convert.ToInt32(dadt.Rows[j]["Mnth"]);
                string monthn = clsEmployee.GetMonthName(mon);
                            
                     DataTable holdt = clsDataAccess.RunQDTbl("select holdate,holidayname,nationflag from tbl_employee_holiday where Year(holdate) ='" + AttenDtTmPkr.Text + "'and month(holdate)='" + mon + "'");

                        dt.Merge(holdt);
                     
                }


            MidasReport.Form1 hl =new  MidasReport.Form1();
           hl.Holiday_Rpt(AttenDtTmPkr.Text, dt, ptype);

           hl.Show();
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
           
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            BtnHolidayList_Click(1);
        }

        private void btnPrnt_Click(object sender, EventArgs e)
        {
            BtnHolidayList_Click(2);
        }

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {

        }

       


        //private void CmbLoction_selectedindexchanged(object sender, EventArgs e)
        //{
        //    CmbLocation_id.SelectedIndex = CmbCompany.SelectedIndex;
        //}
    }
    
}



