using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.IO;
using Edpcom;
using EDPComponent;
using System.Collections;
using System.Globalization;


namespace PayRollManagementSystem
{
    public partial class frmEmpSalWage_Rpt : Form
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon con = new Edpcom.EDPCommon();

        int Head_Cou = 0, EHSPOS = 0, DHSPOS = 0;
        DataTable dt = new DataTable();
  
        public frmEmpSalWage_Rpt()
        {
            InitializeComponent();
        }

        SqlCommand cmd = new SqlCommand();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        ArrayList arritem = new ArrayList();
        Hashtable getcode_item = new Hashtable();
        string Item_Code = "";

        ArrayList DeductionHeads = new ArrayList();
        ArrayList EarningHeads = new ArrayList();

        string month = "", compid = "";



        private void btnclient_Click(object sender, EventArgs e)
        {
            try
            {
                string month = AttenDtTmPkr.Value.ToString("MMMM"); //clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

                string sqlstmnt = "Select distinct (select ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS 'Employee Name' from tbl_Employee_Mast e where e.ID=s.emp_id) as 'EmpName',s.emp_id as 'ID',month from tbl_Employee_SalaryMast s where (Month='" + month + "') and (session='"+cmbYear.Text +"') "; //and s.Location_id= '" + get_LocationID(cmbsalstruc.Text) + "'

                EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Employee", "Select Employee", 0, "CMPN", 0);

                arritem.Clear();
                arritem = EDPCommon.arr_mod;

                if (arritem.Count > 0)
                {
                    getcode_item.Clear();
                    arritem = EDPCommon.arr_mod;
                    getcode_item = EDPCommon.get_code;

                    Item_Code = null;
                    Item_Code = "''";

                    for (int i = 0; i <= arritem.Count - 1; i++)
                    {
                        Item_Code = Item_Code + "," + "'" + getcode_item[i].ToString() + "'";

                    }

                }
            }
            catch { }

            if (Item_Code == "")
            {
                ERPMessageBox.ERPMessage.Show("Employee  must be selected");
                return;
           
            }
            cmbcompany.Text = clsDataAccess.GetresultS("select c.CO_NAME from Company c ,tbl_Employee_Mast em where em.Company_id=c.CO_CODE");

            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            retreivedata(1);
        }

        private void retreivedata(int ptype)
        {
            Boolean flug_deduction = false;


            month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");
            DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as Slno,sm.Emp_Id as ID,((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmployeeName ,"+
            "((case when FathFN!='' then FathFN + ' '  else '' End)+(case when FathMN!='' then FathMN + ' '  else '' End)+(case when FathLN!='' then FathLN + ' '  else '' End)) AS FathersName,case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Designation,(select Location_Name from tbl_Emp_Location   where (Location_ID=sm.Location_id))as 'location',"
                   + "sm.DaysPresent as WDay,sm.OT as OT,sm.TotalDays as TotalDays ,sm.desig_id, (case when em.status=1 then 'paid' else 'unpaid'end) as 'status' ,"
                +"em.PF as pfno,em.ESIno as esino,em.PassportNo as uan,em.Bank_Name as BankName,em.BankAcountNo as BankAcNo,cast(ROUND((sm.[Basic]/sm.[Calculate_day]),2) as numeric(18,2)) as 'col36',cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,cast(sm.NetPay as varchar(50)) NetPay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Emp_Id in( " + Item_Code + ") and em.ID = sm.Emp_Id");


            DataTable salary_details = clsDataAccess.RunQDTbl("select * from (SELECT EmpId,SalId,TableName,Slno,Amount, 0 as Designation_id FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and EmpId in (" + Item_Code + ") and TableName<>'tbl_Employer_Contribution' union SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + cmbYear.Text + "' and Month ='" + month + "' and EmpId in (" + Item_Code + ")  and TableName<>'tbl_Employer_Contribution') main order by Designation_id,Slno");
            DataView dv = new DataView(salary_details);
            int table_count = tot_employ.Columns.Count;

            int dt_count = tot_employ.Rows.Count;

            int counter = 0;

            for (int i = 0; i < tot_employ.Rows.Count; i++)
            {
                dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["desig_id"] + "'";

                for (int j = 0; j <= dv.Count - 1; j++)
                {
                    if (i == 0)
                    {
                        if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                        {
                            table_count = tot_employ.Columns.Count;
                            flug_deduction = true;
                            counter = j;
                        }

                        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                        tot_employ.Columns.Add(Salary_Head, typeof(string));
                        tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                        if (flug_deduction)
                            DeductionHeads.Add(Salary_Head);
                        else
                            EarningHeads.Add(Salary_Head);
                    }
                    else
                    {
                                                
                            if (!flug_deduction)
                            {
                                table_count = tot_employ.Columns.Count;
                                flug_deduction = true;
                            }

                            //string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                            //try
                            //{
                                //tot_employ.Columns.Add(Salary_Head, typeof(string));
                            //}
                            //catch { }
                          tot_employ.Rows[i][j + 18] = dv[j]["Amount"];

                         // if (!flug_deduction)
                           //   DeductionHeads.Add(Salary_Head);
                          //else
                              //EarningHeads.Add(Salary_Head);
 
                            
                                
                            

                    }
                }

                tot_employ.Rows[i]["Slno"] = i + 1;
            }

            tot_employ.Columns.Remove("desig_id");

            EHSPOS = tot_employ.Columns["TotalEarning"].Ordinal;

            tot_employ.Columns["TotalEarning"].SetOrdinal(table_count - 2);
            tot_employ.Columns["TotalDeduction"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns["NetPay"].SetOrdinal(tot_employ.Columns.Count - 1);

            DHSPOS = tot_employ.Columns["TotalEarning"].Ordinal + 1;

            tot_employ.AcceptChanges();

            dt = tot_employ.Copy();

            string co_addr = clsDataAccess.GetresultS("select CO_ADD from Company where CO_NAME='"+cmbcompany.Text+"'");
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(AttenDtTmPkr.Value.Month);
            //DataTable dtClientInfo = clsDataAccess.RunQDTbl("select Client_Name,[Client_ADD1] from tbl_Employee_CliantMaster cm,[tbl_Emp_Location] l where cm.Client_id = l.Cliant_ID and l.Location_ID = " + Locations);
            //string clname = dtClientInfo.Rows[0]["Client_Name"].ToString();
            //string clAddress = dtClientInfo.Rows[0]["Client_ADD1"].ToString();
           

            MidasReport.Form1 mr = new MidasReport.Form1();
            //string strFormat = "";
            //if (rbNew.Checked)
            //    strFormat = "new";
            //else if (rbOld.Checked)
            //    strFormat = "old";

            mr.empsalwage(dt, EarningHeads, DeductionHeads, EHSPOS, DHSPOS, cmbcompany.Text, co_addr, monthName, AttenDtTmPkr.Value.Year.ToString(), ptype);
            mr.Show();
            dt.Dispose();
            EarningHeads.Clear();
            DeductionHeads.Clear();
            EHSPOS = 0;
            DHSPOS = 0;

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
                    cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                    cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }
       
        }

        private void frmEmpSalWage_Rpt_Load(object sender, EventArgs e)
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

        }

        private void cmbcompany_CloseUp(object sender, ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
            {
                compid = Convert.ToString(cmbcompany.ReturnValue);
                //lbl_company.Text = cmbcompany.Text;
            }
       
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {

        }

        
    }
}
