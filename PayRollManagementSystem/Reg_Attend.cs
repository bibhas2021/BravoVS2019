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
    public partial class Reg_Attend : Form
    {
        string Locations = "";
        string Location_Name="";
        int Company_id = 0, Loc_id = 0;

        public Reg_Attend()
        {
            InitializeComponent();
        }

        //private void cmbLocation_DropDown(object sender, EventArgs e)
        //{
        //    //string s = "select  l.Location_Name, l.Location_ID  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls where l.Location_ID = ls.Location_ID";
        //    //DataTable dt = clsDataAccess.RunQDTbl(s);
        //    //if (dt.Rows.Count > 0)
        //    //{
        //    //    cmbLocation.LookUpTable = dt;
        //    //    cmbLocation.ReturnIndex = 1;

        //    //}
        //}
        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
         private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
            {
                //Locations = Convert.ToString(cmbLocation.ReturnValue);
                //Location_Name = Convert.ToString(cmbLocation.Text);
                //cmbLocationid();
                Loc_id = Convert.ToInt32(cmbLocation.ReturnValue);
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Location  must be entered");
                return;
            }
            AttenDtTmPkr.Focus();
            
        }
        //private void cmbLocationid()
        //{
        //    DataTable dt = new DataTable();
        //    lbl_company.Text = "";
        //    cmbcompany.Text = "";
        //    compid = "";
        //    dt.Clear();
        //    string s = "SELECT CO_NAME, GCODE  FROM Company WHERE  (CO_CODE IN " +
        //    "(SELECT Company_ID FROM Companywiseid_Relation WHERE (Location_ID =" + Locations + ")))";
        //    dt = clsDataAccess.RunQDTbl(s);
        //    try
        //    {
        //        if (dt.Rows.Count > 1)
        //        {

        //            cmbcompany.LookUpTable = dt;
        //            cmbcompany.ReturnIndex = 1;
        //            lbl_company.Text = "";

        //        }
        //        if (dt.Rows.Count == 1)
        //        {
        //            cmbcompany.Text = Convert.ToString(dt.Rows[0][0]);
        //            lbl_company.Text = Convert.ToString(dt.Rows[0][0]);
        //            compid = Convert.ToString(dt.Rows[0][1]);
        //        }
        //        if (dt.Rows.Count == 0)
        //        {
        //            lbl_company.Text = "";
        //            compid = "";
        //            cmbcompany.Visible = false;
        //            MessageBox.Show("No Company linked with Location");
        //        }
        //        label3.Visible = true;
        //        lbl_company.Visible = false;
        //        cmbcompany.Visible = true;
        //    }
        //    catch
        //    {
        //        lbl_company.Text = "No Company linked with Location";
        //        MessageBox.Show("No Company linked with Location");
        //        label3.Visible = false;
        //        //    lbl_company.Visible = false;
        //        //    cmbcompany.Visible = false;
        //        //}
        //    }
        //}
        
        private void cmbLocation_DropDown_1(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            string s = "Select EL.Location_Name,EL.Location_ID from tbl_Emp_Location EL,Companywiseid_Relation cr where cr.Location_ID=EL.Location_ID and  cr.Company_ID='" + Company_id + "'";
            DataTable dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;

            }
       
        }

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {
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
    
        }
        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt;
            dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
                // cmbLocation.Text = "";
            }
        }
       
        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
            {
                //compid = Convert.ToString(cmbcompany.ReturnValue);
                //lbl_company.Text = cmbcompany.Text;
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);
 
            }
        }

        
        private void frmRegAttend_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2000, System.DateTime.Now.Year, 1);
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

            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                cmbcompany.Text = dta.Rows[0][0].ToString();

                Company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                cmbcompany.ReturnValue = Company_id.ToString();
                cmbcompany.Enabled = false;

            }
            else if (dta.Rows.Count > 1)
            {
                cmbcompany.PopUp();
            }
            AttenDtTmPkr.Value = DateTime.Now.AddMonths(-1);
            cmbLocation.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt_regatt = new DataTable();
            string coadd = "", Sub = "", head = "", head1 = "";
            if (cmbLocation.Text != "")
            {
                DataTable dtLid = clsDataAccess.RunQDTbl("SELECT Distinct Location_ID,(Select Location_Name from tbl_Emp_Location where Location_ID=ea.Location_ID)as Site FROM tbl_Employee_Attend AS ea WHERE (Location_ID='" + Loc_id + "') AND (Month='" + AttenDtTmPkr.Value.ToString("M/yyy") + "') Order BY Location_id");
                if (dtLid.Rows.Count > 0)
                {
                    string id = dtLid.Rows[0]["Location_ID"].ToString();
                    string strClientName = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);
                    string cltadd = clsDataAccess.GetresultS("select (select cm.Client_ADD1  from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);

                    //string qry = "SELECT ID as Code,(SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
                    //"cast(sum(MOD) as numeric(18,0))totaldays,cast(SUM(days_wd)as numeric(18,0)) AS wd,cast(SUM(ed)as numeric(18,0)) AS ed, cast(SUM(Absent)as numeric(18,0)) AS Absent, cast(SUM(days_ot)as numeric(18,0)) AS proxy, cast(SUM(days_wd) + SUM(ed)+SUM(days_ot)as numeric(18,0)) AS Total FROM tbl_Employee_Attend AS ea WHERE (Location_ID='" + Loc_id + "') AND (Month='" + AttenDtTmPkr.Value.ToString("M/yyy") +
                    //            "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id,Desgid, Month ORDER BY ID";

                    string qry = "SELECT null as Slno,ID as EmpID,(SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as Designation ," +
                    "cast(MOD as int) totaldays,(select sname from tbl_shift where sid=ea.sfid)shift,(select MOD from Companywiseid_Relation where Location_ID='" + Loc_id + "') contracteddays," +
                    "cast(days_wd as numeric(18,0))  wd,cast(ed as numeric(18,0)) AS ed, cast(Absent as numeric(18,0)) AS Absent, cast(days_ot as varchar)  proxy, cast(days_wd + ed+days_ot as varchar)  Total FROM tbl_Employee_Attend  ea WHERE (Location_ID='" + Loc_id + "') AND (Month='" + AttenDtTmPkr.Value.ToString("M/yyy") +
                    "') and (LOcation_ID=" + id + ") GROUP BY ID,days_wd,ed,Absent,days_ot,MOD,sfid,Desgid, Month ORDER BY sfid";
                    DataTable dt = clsDataAccess.RunQDTbl(qry);

                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    if (dt.Rows[i]["sfid"].ToString() == "0")
                    //    {
                    //        dt.Rows[i]["sfid"] = clsDataAccess.GetresultS("select s.sname from tbl_shift s,tbl_Employee_Attend  ea where s.sid=ea.sfid");
                    //    }
                    //}

                    DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as numeric(18,0)) AS wd,cast(SUM(ed)as numeric(18,0)) AS ed, cast(SUM(Absent)as numeric(18,0)) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Month='" + AttenDtTmPkr.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") GROUP BY Company_id,Location_ID, Month");

                    dt_regatt.Merge(dt);
                    dt_regatt.Merge(rw_total);

                    coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + 1 + "'");
                    Sub = "Attendance for the month of " + AttenDtTmPkr.Value.ToString("MMMM,yyyy") + " for location:" + cmbLocation.Text + "";
                    head = cmbcompany.Text;
                    head1 = cmbLocation.Text;

                    MidasReport.Form1 mr = new MidasReport.Form1();

                    mr.regattnd(id, strClientName, cltadd, coadd, Sub, head, head1, dt_regatt, 0);
                    mr.Show();



                }
                else
                { 
                    MessageBox.Show("No record");
                    //return;
                }
            }
            else
            {
                MessageBox.Show("Please select location");
                //return;
            }
            cmbLocation.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt_regatt = new DataTable();
            string coadd = "", Sub = "", head = "", head1 = "";
            if (cmbLocation.Text != "")
            {
                DataTable dtLid = clsDataAccess.RunQDTbl("SELECT Distinct Location_ID,(Select Location_Name from tbl_Emp_Location where Location_ID=ea.Location_ID)as Site FROM tbl_Employee_Attend AS ea WHERE (Location_ID='" + Loc_id + "') AND (Month='" + AttenDtTmPkr.Value.ToString("M/yyy") + "') Order BY Location_id");
                if (dtLid.Rows.Count > 0)
                {
                    string id = dtLid.Rows[0]["Location_ID"].ToString();
                    string strClientName = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);
                    string cltadd = clsDataAccess.GetresultS("select (select cm.Client_ADD1  from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);

                    //string qry = "SELECT ID as Code,(SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
                    //"cast(sum(MOD) as numeric(18,0))totaldays,cast(SUM(days_wd)as numeric(18,0)) AS wd,cast(SUM(ed)as numeric(18,0)) AS ed, cast(SUM(Absent)as numeric(18,0)) AS Absent, cast(SUM(days_ot)as numeric(18,0)) AS proxy, cast(SUM(days_wd) + SUM(ed)+SUM(days_ot)as numeric(18,0)) AS Total FROM tbl_Employee_Attend AS ea WHERE (Location_ID='" + Loc_id + "') AND (Month='" + AttenDtTmPkr.Value.ToString("M/yyy") +
                    //            "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id,Desgid, Month ORDER BY ID";

                    string qry = "SELECT null as Slno,ID as EmpID,(SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as Designation ," +
                    "cast(MOD as int) totaldays,(select sname from tbl_shift where sid=ea.sfid)shift,(select MOD from Companywiseid_Relation where Location_ID='" + Loc_id + "') contracteddays," +
                    "cast(days_wd as numeric(18,0))  wd,cast(ed as numeric(18,0)) AS ed, cast(Absent as numeric(18,0)) AS Absent, cast(days_ot as varchar)  proxy, cast(days_wd + ed+days_ot as varchar)  Total FROM tbl_Employee_Attend  ea WHERE (Location_ID='" + Loc_id + "') AND (Month='" + AttenDtTmPkr.Value.ToString("M/yyy") +
                    "') and (LOcation_ID=" + id + ") GROUP BY ID,days_wd,ed,Absent,days_ot,MOD,sfid,Desgid, Month ORDER BY sfid";
                    DataTable dt = clsDataAccess.RunQDTbl(qry);

                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    if (dt.Rows[i]["sfid"].ToString() == "0")
                    //    {
                    //        dt.Rows[i]["sfid"] = clsDataAccess.GetresultS("select s.sname from tbl_shift s,tbl_Employee_Attend  ea where s.sid=ea.sfid");
                    //    }
                    //}

                    DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as numeric(18,0)) AS wd,cast(SUM(ed)as numeric(18,0)) AS ed, cast(SUM(Absent)as numeric(18,0)) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Month='" + AttenDtTmPkr.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") GROUP BY Company_id,Location_ID, Month");

                    dt_regatt.Merge(dt);
                    dt_regatt.Merge(rw_total);

                    coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + 1 + "'");
                    Sub = "Attendance for the month of " + AttenDtTmPkr.Value.ToString("MMMM,yyyy") + " for location:" + cmbLocation.Text + "";
                    head = cmbcompany.Text;
                    head1 = cmbLocation.Text;

                    MidasReport.Form1 mr = new MidasReport.Form1();

                    mr.regattnd(id, strClientName, cltadd, coadd, Sub, head, head1, dt_regatt, 1);
                    //mr.Show();



                }
                else
                {
                    MessageBox.Show("No record");
                    //return;
                }
            }
            else
            {
                MessageBox.Show("Please select location");
                //return;
            }
            cmbLocation.Focus();
        }



    }
}
