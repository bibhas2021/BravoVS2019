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
using System.Globalization;

namespace PayRollManagementSystem
{
    public partial class frmRegisterOfWages_FormXVII : Form//EDPComponent.FormBaseERP
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        string Item_Code = "", Tentry_code = "";
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Frm_Type = "";
        string Location_Name = "";
        int Head_Cou = 0,EHSPOS = 0, DHSPOS = 0;
        string Locations = "", compid = "";
        string Odet = "", Oamt = "", Agent = "";
        TextBoxX.TextBoxX[] txte = new TextBoxX.TextBoxX[32];
        Label[] lbe = new Label[32];
        Label[] lbd = new Label[32];

        ArrayList DeductionHeads =new ArrayList();
        ArrayList EarningHeads = new ArrayList();

        string month = "";


        ArrayList sa_col = new ArrayList();
        ArrayList sa_col2 = new ArrayList();

        public frmRegisterOfWages_FormXVII()
        {
            InitializeComponent();
        }

        private void frmRegisterOfWages_FormXVII_Load(object sender, EventArgs e)
        {
            rbOld.Checked = true;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.HeaderText = "Register Of Wages";
            //this.Text = "Register of Wages Form-XVII";
            AttenDtTmPkr.Value = DateAndTime.Now.AddMonths(-1);
            clsValidation.GenerateYear(cmbYear, 2000, System.DateTime.Now.Year, 1);
            radioButton1.Checked = true;
            //set session
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
            cmbLocation.Select();
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            string s = "select  l.Location_Name, l.Location_ID,(SELECT top 1 Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls where l.Location_ID = ls.Location_ID";
            DataTable dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;

            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
            {
                Locations = Convert.ToString(cmbLocation.ReturnValue);
                cmbLocation.Text = cmbLocation.Text + " - " + clsDataAccess.ReturnValue("select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l where l.Location_ID =" + Locations);

                Location_Name = Convert.ToString(cmbLocation.Text);
                cmbLocationid();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Location  must be entered");
                return;
            }
            AttenDtTmPkr.Focus();
        }
        private void cmbLocationid()
        {
            DataTable dt = new DataTable();
            lbl_company.Text = "";
            cmbcompany.Text = "";
            compid = "";
            dt.Clear();
            string s = "SELECT CO_NAME, GCODE  FROM Company WHERE  (CO_CODE IN " +
            "(SELECT Company_ID FROM Companywiseid_Relation WHERE (Location_ID =" + Locations + ")))";
            dt = clsDataAccess.RunQDTbl(s);
            try
            {
                if (dt.Rows.Count > 1)
                {

                    cmbcompany.LookUpTable = dt;
                    cmbcompany.ReturnIndex = 1;
                    lbl_company.Text = "";

                }
                if (dt.Rows.Count == 1)
                {
                    cmbcompany.Text = Convert.ToString(dt.Rows[0][0]);
                    lbl_company.Text = Convert.ToString(dt.Rows[0][0]);
                    compid = Convert.ToString(dt.Rows[0][1]);
                }
                if (dt.Rows.Count == 0)
                {
                    lbl_company.Text = "";
                    compid = "";
                    cmbcompany.Visible = false;
                    MessageBox.Show("No Company linked with Location");
                }
                label3.Visible = true;
                lbl_company.Visible = false;
                cmbcompany.Visible = true;
            }
            catch
            {
                lbl_company.Text = "No Company linked with Location";
                MessageBox.Show("No Company linked with Location");
                label3.Visible = false;
                lbl_company.Visible = false;
                cmbcompany.Visible = false;
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
            {
                compid = Convert.ToString(cmbcompany.ReturnValue);
                lbl_company.Text = cmbcompany.Text;
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

        private void LoadDataTable(int ptype)
        {
            DataTable dt = new DataTable();
            //if salary has been alloted to the employees then only the report will be shown
            string s = "SELECT  ' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as empname,' '+em.FathFN+' '+em.FathMN+' '+em.FathLN as fname,"+
                "em.PF as pfno,em.ESIno as esino,em.PassportNo as uan,em.Bank_Name as bankname,em.BankAcountNo as acno," +
                "(select ' '+DesignationName+' ('+dm.ShortForm+') ' from tbl_Employee_DesignationMaster dm where dm.SlNo=em.DesgId and em.ID=sm.Emp_Id) as deg ,"+
                "sm.Emp_Id as empid,sm.Basic as tbasis,sm.DaysPresent as present,sm.OT as othrs,sm.TotalSal as gross,TotalDec as tdbt," +
                "sm.NetPay as netpay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em"+
                " where sm.Session='" + cmbYear.Text + "' and em.active=1 and sm.Month ='" + clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month) + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT = sm.Emp_Id";
            dt = clsDataAccess.RunQDTbl(s);

            Boolean flug_deduction = false;
            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' order by Slno");

            DataTable leave_details = clsDataAccess.RunQDTbl("Select ShortName,TotalLeaves from tbl_Employee_Config_LeaveDetails where Session='" + cmbYear.Text + "' and Location_id = '" + Locations + "'");


            DataView dv = new DataView(salary_details);
            int table_count = dt.Columns.Count;

            int dt_count = dt.Rows.Count;
            int counter = 0;

            DataColumn dc = new DataColumn();
            dc.ColumnName = "thra";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "tca";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "twa";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "tspl";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "tedu";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "tcca";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "basicwithda";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "hra";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "spl";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "edu";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "conv";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "cca";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "subtotal";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "wa";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "ot";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "wagesta";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "pf";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "wf";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "othwf";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "esi";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "pt";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "bf";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "adv";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "misc";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "loan";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "oth";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "ph";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);dc = new DataColumn();
            dc.ColumnName = "wo";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "Sno";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "tda";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "tcea";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "tot";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "toa";
            dc.DataType = typeof(System.String);
            dc.DefaultValue = "0";
            dt.Columns.Add(dc);

            if (dt.Rows.Count > 0)
            {
                for(int j = 0;j<dt.Rows.Count;j++)
                {
                    string qryForGettingErnSalStrucId = "select P_TYPE,SAL_HEAD,C_TYPE,C_DET from tbl_Employee_Assign_SalStructure eass,tbl_Employee_Link_SalaryStructure elss where SAL_STRUCT = elss.SalaryStructure_ID and elss.Location_ID = " + Locations + " and P_TYPE = 'E'";
                    DataTable tempForSalStructId = new DataTable();
                    tempForSalStructId = clsDataAccess.RunQDTbl(qryForGettingErnSalStrucId);
                    if (tempForSalStructId.Rows.Count > 0)
                    {
                        for (int i = 0; i < tempForSalStructId.Rows.Count; i++)
                        {
                            string salHeadShortForm = get_sal_head_name(Convert.ToInt32(tempForSalStructId.Rows[i]["SAL_HEAD"]), tempForSalStructId.Rows[i]["P_TYPE"].ToString());

                            if (tempForSalStructId.Rows[i]["C_TYPE"].ToString() == "COMPANY LUMPSUM")
                            {
                                String qForLumpAmnt = "select AMOUNT from tbl_Employee_Lumpsum where LUMPID = " + tempForSalStructId.Rows[i]["C_DET"].ToString();
                                DataTable LumpAmnt = clsDataAccess.RunQDTbl(qForLumpAmnt);
                                try
                                {
                                    if (salHeadShortForm.ToLower() == "bs")
                                        dt.Rows[j]["tbasis"] = LumpAmnt.Rows[0][0];
                                    else if (salHeadShortForm.ToLower() == "cov")
                                        dt.Rows[j]["tca"] = LumpAmnt.Rows[0][0];
                                    else if (salHeadShortForm.ToLower() == "ota")
                                        dt.Rows[j]["tot"] = LumpAmnt.Rows[0][0];
                                    else
                                        dt.Rows[j]["t" + salHeadShortForm.ToLower()] = LumpAmnt.Rows[0][0];
                                }
                                catch
                                {
                                    if (salHeadShortForm.ToLower() == "bs")
                                        dt.Rows[j]["tbasis"] = 0;
                                    else if (salHeadShortForm.ToLower() == "cov")
                                        dt.Rows[j]["tca"] = 0;
                                    else if (salHeadShortForm.ToLower() == "ota")
                                        dt.Rows[j]["tot"] = 0;
                                    //else
                                        //dt.Rows[j]["t" + salHeadShortForm.ToLower()] = 0;
                                }
                            }
                        }


                        dv.RowFilter = "EmpId = '" + dt.Rows[j]["empid"] + "' ";

                        for (int i = 0; i <= dv.Count - 1; i++)
                        {
                            string _tablename = "";
                            if (Convert.ToString(dv[i]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                            {
                                table_count = dt.Columns.Count;
                                flug_deduction = true;
                                counter = i;
                            }


                            if (dv[i]["TableName"].ToString().Trim() != "tbl_Employer_Contribution")
                            {
                                string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[i]["TableName"] + " where SlNo ='" + dv[i]["SalId"] + "' ");
                                if (Salary_Head.ToLower() == "ca")
                                    Salary_Head = "conv";
                                if (Salary_Head.ToLower() == "bs")
                                    Salary_Head = "basicwithda";
                                if (Salary_Head.ToLower() == "ptax")
                                    Salary_Head = "pt";
                                try
                                {
                                    dt.Rows[j][Salary_Head.ToLower()] = dv[i]["Amount"];
                                }
                                catch { continue; }
                            }
                        } 
                    }

                    dt.Rows[j]["ph"] = clsDataAccess.RunQDTbl("select count(HolDate) from tbl_Employee_Holiday where HolSession = '" + "' and HolDate between '" + AttenDtTmPkr.Value.Year + "/" + AttenDtTmPkr.Value.Month + "/01' and '" + AttenDtTmPkr.Value.Year + "/" + AttenDtTmPkr.Value.Month + "/" + DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month) + "'").Rows[0][0];

                    dt.Rows[j]["subtotal"] = Convert.ToInt32(Convert.ToDouble(dt.Rows[j]["hra"]) + Convert.ToDouble(dt.Rows[j]["basicwithda"]) + Convert.ToDouble(dt.Rows[j]["conv"]) + Convert.ToDouble(dt.Rows[j]["spl"]) + Convert.ToDouble(dt.Rows[j]["edu"]) + Convert.ToDouble(dt.Rows[j]["cca"]));
                    

                    dt.Rows[j]["sno"] = j + 1;

                }
                string co_addr = clsDataAccess.RunQDTbl("select CO_ADD from Company where GCODE = " + compid).Rows[0][0].ToString();
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(AttenDtTmPkr.Value.Month);
                string clname = clsDataAccess.RunQDTbl("select Client_Name from tbl_Employee_CliantMaster cm,[tbl_Emp_Location] l where cm.Client_id = l.Cliant_ID and l.Location_ID = " + Locations).Rows[0][0].ToString(); ;
                RadioButton rb = null;
                if (radioButton1.Checked == true)
                    rb = radioButton1;
                else
                    rb = radioButton2;
                MidasReport.Form1 MR = new MidasReport.Form1();
                MR.frmRegWageXVII(dt, lbl_company.Text, co_addr, monthName, AttenDtTmPkr.Value.Year.ToString(), Location_Name, clname,ptype,rb.Text);
                MR.Show();
            }
            else
            {
                MessageBox.Show("Check if Salary has been alloted to the employees for this Location or not.", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        public string get_sal_head_name(int id, string type)
        {
            string res = "";
            if (type == "E")
            {
                string s = "select SalaryHead_Short from tbl_Employee_ErnSalaryHead where slno=" + id;
                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    res = dts.Rows[0][0].ToString();

            }
            else if (type == "D")
            {
                string s = "select SalaryHead_Short from tbl_Employee_DeductionSalayHead where slno=" + id;

                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    res = dts.Rows[0][0].ToString();
            }
            return res;
        }

        public void nc()
        {

            lbl_NC.Text = clsDataAccess.ReturnValue("select COUNT(*) from tbl_Employee_Assign_SalStructure where (Location_id=" + Locations + ") and NCompliance=1");

            lbl_OT.Text = clsDataAccess.ReturnValue("select count(SAL_HEAD) from tbl_Employee_Assign_SalStructure eas where (Location_id=" + Locations + ") and NCompliance=1 and Proxy_day=1");  // OTA

            lbl_ED.Text = clsDataAccess.ReturnValue("select count(SAL_HEAD) from tbl_Employee_Assign_SalStructure eas where (Location_id=" + Locations + ") and NCompliance=1 and Proxy_day=2");  // ED


        }
        private void Retrive_Data(int ptype)
        {
            Boolean flug_deduction = false;
            //string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);


            nc();

            month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");
            DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as Slno,sm.Emp_Id as ID,"+
    "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) as EmployeeName ,"+
    "' '+em.FathFN+' '+em.FathMN+' '+em.FathLN as FathersName,case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Designation,sm.DaysPresent as WDay,"+
    "(case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as OT ," +
    //"(case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as ED," +

    "(sm.TotalDays-(case when " + lbl_OT.Text.Trim() + "='0' then 0 else sm.OT end)-(case when " + lbl_ED.Text.Trim() + "='0' then 0 else sm.ed end)) as TotalDays ,"+
    "sm.desig_id,em.PF as pfno,em.ESIno as esino,em.PassportNo as uan,em.Bank_Name as BankName,em.BankAcountNo as BankAcNo,em.GMIno as IFSC,cast(ROUND((sm.[Basic]/sm.[Calculate_day]),2) as numeric(18,2)) as 'col36',cast(sm.TotalSal as Numeric(18,2)) TotalEarning,cast(sm.TotalDec as Numeric(18,2)) TotalDeduction,cast(sm.NetPay as Numeric(18,2)) NetPay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID = sm.Emp_Id");


            DataTable salary_details = clsDataAccess.RunQDTbl("select * from (SELECT EmpId,SalId,TableName,Slno,Amount, 0 as Designation_id FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' and TableName<>'tbl_Employer_Contribution' union SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' and TableName<>'tbl_Employer_Contribution') main order by Designation_id,Slno");
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
                        tot_employ.Columns.Add(Salary_Head, typeof(Double));
                        tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                        if (Salary_Head.ToUpper() == "BS")
                        {
                            tot_employ.Rows[i]["col36"] =(Convert.ToDouble(tot_employ.Rows[i][Salary_Head]) / Convert.ToDouble(tot_employ.Rows[i]["WDay"])).ToString("0.00");

                        }
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
                        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                        
                        tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                        if (Salary_Head.ToUpper() == "BS")
                        {
                            tot_employ.Rows[i]["col36"] = (Convert.ToDouble(tot_employ.Rows[i][Salary_Head]) / Convert.ToDouble(tot_employ.Rows[i]["WDay"])).ToString("0.00");

                        }
                        //tot_employ.Rows[i][j + 18] = dv[j]["Amount"];
                    }
                }

                tot_employ.Rows[i]["Slno"] = i + 1;
            }
            tot_employ.Rows.Add();
             int rwc = tot_employ.Rows.Count-1;
            string col_Name = "";
            tot_employ.Rows[rwc]["EmployeeName"]= "TOTAL :";
            tot_employ.Rows[rwc]["WDay"] = tot_employ.Compute("SUM([WDay])", "");
            tot_employ.Rows[rwc]["OT"] = tot_employ.Compute("SUM([OT])", "");
            //tot_employ.Rows[rwc]["ED"] = tot_employ.Compute("SUM([ED])", "");
            tot_employ.Rows[rwc]["TotalDays"] = tot_employ.Compute("SUM([TotalDays])", "");
            for (int clc = 16; clc < tot_employ.Columns.Count; clc++)
            {
                col_Name = tot_employ.Columns[clc].ColumnName;

                tot_employ.Rows[rwc][col_Name] = tot_employ.Compute("SUM([" + col_Name + "])", "");
                    //tot_employ.AsEnumerable().Sum(x => Convert.ToDouble(x[col_Name]));
                    //tot_employ.Compute("SUM([" + col_Name + "])", "");
            }
            
            tot_employ.Columns.Remove("desig_id");

            EHSPOS = tot_employ.Columns["TotalEarning"].Ordinal;

            tot_employ.Columns["TotalEarning"].SetOrdinal(table_count - 2);
            tot_employ.Columns["TotalDeduction"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns["NetPay"].SetOrdinal(tot_employ.Columns.Count - 1);


            //--------------------------------------------------------------------
            int salary_structure = 0;
            DataTable SalaryLocation = clsDataAccess.RunQDTbl("select SalaryStructure_ID from tbl_Employee_Link_SalaryStructure where Location_ID=" + Locations + " ");
            if (SalaryLocation.Rows.Count > 0)
            {
                salary_structure = Convert.ToInt32(SalaryLocation.Rows[0]["SalaryStructure_ID"]);

            }
            string sql = "select sal_head, p_type from tbl_Employee_Assign_SalStructure where (sal_struct=" + salary_structure + ") and chkHide=2";
            DataTable dt_hide = new DataTable();
            dt_hide = clsDataAccess.RunQDTbl(sql);
            sa_col.Clear();

            for (int ind = 0; ind < dt_hide.Rows.Count; ind++)
            {
                sa_col.Add(0);
                sa_col[ind] = get_sal_head_name(Convert.ToInt32(dt_hide.Rows[ind]["sal_head"]), dt_hide.Rows[ind]["p_type"].ToString());
            }

            //--------------31/07/" + yr[0].Trim() + "---------------------------------------------
            int ixd = Convert.ToInt32(tot_employ.Columns["NETPAY"].Ordinal) - 1;
            try
            {
                for (int ind = 0; ind < sa_col.Count; ind++)
                {
                    ixd = ixd + 1;
                    tot_employ.Columns[sa_col[ind].ToString()].SetOrdinal(ixd);
                    ixd--;
                }
            }
            catch { }
            //---------------------------------------------------------------------
            if (Convert.ToInt32(lbl_NC.Text) > 0)
            {
                tot_employ.Columns.Add("EXTRA PAY", typeof(string));
                tot_employ.Columns.Add("GROSS PAY", typeof(string));

                DataTable nc_Col = clsDataAccess.RunQDTbl("select (select SalaryHead_Short from tbl_Employee_ErnSalaryHead where slno=eas.SAL_HEAD) HEAD,SAL_HEAD from tbl_Employee_Assign_SalStructure eas where Location_id=" + Locations + " and NCompliance=1");
                if (nc_Col.Rows.Count > 0)
                {
                    for (int ix = 0; ix < tot_employ.Rows.Count; ix++)
                    {
                        if (tot_employ.Rows[ix]["EmployeeName"].ToString().Trim() != "")
                        {
                            tot_employ.Rows[ix]["EXTRA PAY"] = "0";
                            for (int idx = 0; idx < nc_Col.Rows.Count; idx++)
                            {
                                try
                                {
                                    tot_employ.Rows[ix]["EXTRA PAY"] = Convert.ToString(Convert.ToDouble(tot_employ.Rows[ix][nc_Col.Rows[idx]["HEAD"].ToString()].ToString()) + Convert.ToDouble(tot_employ.Rows[ix]["EXTRA PAY"]));
                                }
                                catch { }
                            }

                            tot_employ.Rows[ix]["GROSS PAY"] = (Convert.ToDouble(tot_employ.Rows[ix]["EXTRA PAY"]) + Convert.ToDouble(tot_employ.Rows[ix]["NetPay"])).ToString();
                        }
                    }
                }

            }
            //-------------------------------------------------------------------------------------------------


            DHSPOS = tot_employ.Columns["TotalEarning"].Ordinal+1;

           

            tot_employ.AcceptChanges();

            dt = tot_employ.Copy();

            string co_addr = clsDataAccess.RunQDTbl("select CO_ADD from Company where GCODE = " + compid).Rows[0][0].ToString();
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(AttenDtTmPkr.Value.Month);
            DataTable dtClientInfo = clsDataAccess.RunQDTbl("select Client_Name,[Client_ADD1] from tbl_Employee_CliantMaster cm,[tbl_Emp_Location] l where cm.Client_id = l.Cliant_ID and l.Location_ID = " + Locations);
            string clname = dtClientInfo.Rows[0]["Client_Name"].ToString();
            string clAddress = dtClientInfo.Rows[0]["Client_ADD1"].ToString();
            RadioButton rb = null;
            if (radioButton1.Checked == true)
                rb = radioButton1;
            else
                rb = radioButton2;

            MidasReport.Form1 MR = new MidasReport.Form1();
            string strFormat = "";
            if (rbNew.Checked)
                strFormat = "new";
            else if (rbOld.Checked)
                strFormat = "old";
            MR.frmRegWageXVII_Updated(dt, EarningHeads, DeductionHeads, EHSPOS, DHSPOS, lbl_company.Text, co_addr, monthName, AttenDtTmPkr.Value.Year.ToString(), Location_Name, clname, ptype, rb.Text,clAddress,strFormat);
            MR.Show();
            dt.Dispose();
            EarningHeads.Clear();
            DeductionHeads.Clear();
            EHSPOS = 0;
            DHSPOS = 0;

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //LoadDataTable(1);
            Retrive_Data(1);
            cmbLocation.Focus();
        }

     
        private void btnPrnt_Click(object sender, EventArgs e)
        {
            //LoadDataTable(2);
            Retrive_Data(2);
            cmbLocation.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void opt()
        {
            int asign = 0;
            bool lv_col = false;
            try
            {
                asign = Convert.ToInt32(clsDataAccess.GetresultS("select lv from CompanyLimiter"));
            }
            catch
            {
                asign = 0;
            }

            if (asign == 1)
            {
                lv_col = true;
            }
            else
            {
                lv_col = false;
            }
            try
            {
                dgv_show.Columns["Leave.Prev Bal"].Visible = lv_col;
                 }
            catch { }
            try
            {
                dgv_show.Columns["Leave.Availed"].Visible = lv_col;
            }
            catch { }
            try
            {
                dgv_show.Columns["Leave.Earned"].Visible = lv_col;
            }
            catch { }
            try
            {
                dgv_show.Columns["Leave.Cur Bal"].Visible = lv_col;
            }
            catch { }


        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Boolean flug_deduction = false;
            int asign = 0;
            nc();
            month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");
            DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as Slno,sm.Emp_Id as ID," +
    "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
    "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmployeeName ," +
    "' '+em.FathFN+' '+em.FathMN+' '+em.FathLN as FathersName,case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Designation,sm.DaysPresent as WDay,"+
    "(case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as OT ," +
    "(case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as EDuty," +

    "(sm.TotalDays-(case when " + lbl_OT.Text.Trim() + "='0' then 0 else sm.OT end)-(case when " + lbl_ED.Text.Trim() + "='0' then 0 else sm.ed end)) as TotalDays ,"+
    "sm.desig_id,em.PF as EPF,em.ESIno as ESIC,em.PassportNo as UAN,em.Bank_Name as Bank,em.BankAcountNo as BankAccountNo,em.GMIno as IFSC,cast(ROUND((sm.[Basic]/sm.[Calculate_day]),2) as numeric(18,2)) as 'col36',cast(sm.TotalSal as Numeric(18,2)) TotalEarning,cast(sm.TotalDec as Numeric(18,2)) TotalDeduction,cast(sm.NetPay as Numeric(18,2)) NetPay, " +
                "(select lv_pbal from tbl_Employee_Attend where ID=sm.Emp_Id and LOcation_ID=sm.Location_id and Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "' and DesgId=(case when sm.desig_id =0 then em.DesgId else sm.desig_id end)) as 'Leave.Prev Bal'," +
                "(select lv_adj from tbl_Employee_Attend where ID=sm.Emp_Id and LOcation_ID=sm.Location_id and Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "' and DesgId=(case when sm.desig_id =0 then em.DesgId else sm.desig_id end)) as 'Leave.Availed'," +
                "(select lv_earn from tbl_Employee_Attend where ID=sm.Emp_Id and LOcation_ID=sm.Location_id and Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "' and DesgId=(case when sm.desig_id =0 then em.DesgId else sm.desig_id end)) as 'Leave.Earned'," +
                "(select ((lv_pbal - lv_adj) + lv_earn) from tbl_Employee_Attend where ID=sm.Emp_Id and LOcation_ID=sm.Location_id and Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "' and DesgId=(case when sm.desig_id =0 then em.DesgId else sm.desig_id end))as 'Leave.Cur Bal' " +
                "FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID = sm.Emp_Id");

            if (tot_employ.Rows.Count == 0)
            {
                MessageBox.Show("No Data Present!", "BRAVO");

                return;
            }
            
          

           

            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");
          

            DataTable salary_details = clsDataAccess.RunQDTbl("select * from (SELECT EmpId,SalId,TableName,Slno,Amount, 0 as Designation_id FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' and TableName<>'tbl_Employer_Contribution' union SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' and TableName<>'tbl_Employer_Contribution') main order by Designation_id,Slno");
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
                        tot_employ.Columns.Add(Salary_Head, typeof(Double));
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
                        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");

                        tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                        //tot_employ.Rows[i][j + 18] = dv[j]["Amount"];
                    }
                }

                tot_employ.Rows[i]["Slno"] = i + 1;
            }
            tot_employ.Rows.Add();
            int rwc = tot_employ.Rows.Count - 1;
            string col_Name = "";
            tot_employ.Rows[rwc]["EmployeeName"] = "TOTAL :";
            for (int clc = 16; clc < tot_employ.Columns.Count; clc++)
            {
                col_Name = tot_employ.Columns[clc].ColumnName;

                tot_employ.Rows[rwc][col_Name] = tot_employ.Compute("SUM([" + col_Name + "])", "");
                //tot_employ.AsEnumerable().Sum(x => Convert.ToDouble(x[col_Name]));
                //tot_employ.Compute("SUM([" + col_Name + "])", "");
            }

         

            EHSPOS = tot_employ.Columns["TotalEarning"].Ordinal;

            tot_employ.Columns["TotalEarning"].SetOrdinal(table_count - 1);
            tot_employ.Columns["TotalDeduction"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns["NetPay"].SetOrdinal(tot_employ.Columns.Count - 1);


            //--------------------------------------------------------------------
            int salary_structure = 0;
            DataTable SalaryLocation = clsDataAccess.RunQDTbl("select SalaryStructure_ID from tbl_Employee_Link_SalaryStructure where Location_ID=" + Locations + " ");
            if (SalaryLocation.Rows.Count > 0)
            {
                salary_structure = Convert.ToInt32(SalaryLocation.Rows[0]["SalaryStructure_ID"]);

            }
            string sql = "select sal_head, p_type from tbl_Employee_Assign_SalStructure where (sal_struct=" + salary_structure + ") and chkHide=2";
            DataTable dt_hide = new DataTable();
            dt_hide = clsDataAccess.RunQDTbl(sql);
            sa_col.Clear();

            for (int ind = 0; ind < dt_hide.Rows.Count; ind++)
            {
                sa_col.Add(0);
                sa_col[ind] = get_sal_head_name(Convert.ToInt32(dt_hide.Rows[ind]["sal_head"]), dt_hide.Rows[ind]["p_type"].ToString());
            }

            //--------------31/07/" + yr[0].Trim() + "---------------------------------------------
            int ixd = Convert.ToInt32(tot_employ.Columns["NETPAY"].Ordinal) - 1;
            try
            {
                for (int ind = 0; ind < sa_col.Count; ind++)
                {
                    ixd = ixd + 1;
                    tot_employ.Columns[sa_col[ind].ToString()].SetOrdinal(ixd);
                    ixd--;
                }
            }
            catch { }
            //---------------------------------------------------------------------
            if (Convert.ToInt32(lbl_NC.Text) > 0)
            {
                tot_employ.Columns.Add("EXTRA PAY", typeof(string));
                tot_employ.Columns.Add("GROSS PAY", typeof(string));

                DataTable nc_Col = clsDataAccess.RunQDTbl("select (select SalaryHead_Short from tbl_Employee_ErnSalaryHead where slno=eas.SAL_HEAD) HEAD,SAL_HEAD from tbl_Employee_Assign_SalStructure eas where Location_id=" + Locations + " and NCompliance=1");
                if (nc_Col.Rows.Count > 0)
                {
                    for (int ix = 0; ix < tot_employ.Rows.Count; ix++)
                    {
                        if (tot_employ.Rows[ix]["EmployeeName"].ToString().Trim() != "")
                        {
                            tot_employ.Rows[ix]["EXTRA PAY"] = "0";
                            for (int idx = 0; idx < nc_Col.Rows.Count; idx++)
                            {
                                try
                                {
                                    tot_employ.Rows[ix]["EXTRA PAY"] = Convert.ToString(Convert.ToDouble(tot_employ.Rows[ix][nc_Col.Rows[idx]["HEAD"].ToString()].ToString()) + Convert.ToDouble(tot_employ.Rows[ix]["EXTRA PAY"]));
                                }
                                catch { }
                            }

                            tot_employ.Rows[ix]["GROSS PAY"] = (Convert.ToDouble(tot_employ.Rows[ix]["EXTRA PAY"]) + Convert.ToDouble(tot_employ.Rows[ix]["NetPay"])).ToString();
                        }
                    }
                }

            }
            //-------------------------------------------------------------------------------------------------


            DHSPOS = tot_employ.Columns["TotalEarning"].Ordinal + 1;

            tot_employ.Columns["Leave.Prev Bal"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns["Leave.Earned"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns["Leave.Availed"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns["Leave.Cur Bal"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns.Add("Signature");


            tot_employ.Columns.Remove("desig_id");
            tot_employ.Columns.Remove("col36");

            try
            {
                asign = Convert.ToInt32(clsDataAccess.GetresultS("select lv from CompanyLimiter"));
            }
            catch
            {
                asign = 0;
            }
            if (asign == 0)
            {
                 tot_employ.Columns.Remove("Leave.Prev Bal");
                 tot_employ.Columns.Remove("Leave.Earned");
                 tot_employ.Columns.Remove("Leave.Availed");
                 tot_employ.Columns.Remove("Leave.Cur Bal");
            }
            tot_employ.AcceptChanges();

            dt = tot_employ.Copy();


            //onload(dt);

            //for (int ind = 0; ind < checkedListBox1.Items.Count; ind++)
            //{

            //    if (checkedListBox1.GetItemChecked(ind) == false)
            //    {
            //        dt.Columns.Remove(checkedListBox1.Items[ind].ToString());
            //    }

            //}

            dgv_show.DataSource = dt;

            opt();


            string co_addr = clsDataAccess.RunQDTbl("select CO_ADD from Company where GCODE = " + compid).Rows[0][0].ToString();
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(AttenDtTmPkr.Value.Month);
            DataTable dtClientInfo = clsDataAccess.RunQDTbl("select Client_Name,[Client_ADD1] from tbl_Employee_CliantMaster cm,[tbl_Emp_Location] l where cm.Client_id = l.Cliant_ID and l.Location_ID = " + Locations);
            string clname = dtClientInfo.Rows[0]["Client_Name"].ToString();
            string clAddress = dtClientInfo.Rows[0]["Client_ADD1"].ToString();



           // *excel

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 0, irw = 0; ;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            iCol = dgv_show.Columns.Count;


            excel.Cells[1, 1] = cmbcompany.Text + Environment.NewLine + co_addr;
            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);
                       
            range.Merge(true);
            range.Font.Bold = true;


            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.RowHeight= 25.00;
            //range.Columns.AutoFit();
            //range.Rows.AutoFit();


            excel.Cells[2, 1] = "Form XVII"+Environment.NewLine + "Register of Wages"+Environment.NewLine +"Rule 78(1)(a)(i)" ;

            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 3]);
            range.Merge(true);
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            excel.Cells[2, 4] = AttenDtTmPkr.Value.ToString("MMMM yyyy") + Environment.NewLine+ "Date of Payment : " ;

            range = worksheet.get_Range(worksheet.Cells[2, 4], worksheet.Cells[2, 6]);
            range.Merge(true);
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;


            excel.Cells[2, 7] = "Unit : " + cmbLocation.Text + Environment.NewLine + "Address " + clAddress;

            range = worksheet.get_Range(worksheet.Cells[2, 7], worksheet.Cells[2, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;


            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);

            range.Columns.AutoFit();
          //  range.Rows.AutoFit();
            range.RowHeight = 55.00;

            excel.Cells[3, 1] = "";
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
            range.Merge(true);
            range.Columns.AutoFit();
            range.Rows.AutoFit();
            string[] cell_head = new string[] { };
            string old_head = "";
            int ind_st = 0, ind_fin = 0;

            for (int i = 1; i <= dgv_show.Columns.Count; i++)
            {
                cell_head = Convert.ToString(dgv_show.Columns[i - 1].HeaderText).Split('.');
                if (cell_head.Length > 1)
                {
                    if (old_head == cell_head[0])
                    {
                        ind_fin = i;
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
                            range.Merge(Type.Missing);
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
                            range.Merge(Type.Missing);
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        }
                        catch { }
                        ind_st = i;
                        excel.Cells[4, i] = cell_head[0];
                        old_head = cell_head[0];
                    }
                    excel.Cells[5, i] = cell_head[1];
                }
                else if (cell_head.Length > 0)
                {


                    excel.Cells[4, i] = dgv_show.Columns[i - 1].HeaderText;
                    try
                    {
                        range = worksheet.get_Range(worksheet.Cells[4, i], worksheet.Cells[5, i]);
                        range.Merge(Type.Missing);
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    }
                    catch { }
                }

            }

            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
            range.Font.Bold = true;
            DateTime MyDate;
            for (int i = 0; i < dgv_show.Rows.Count; i++)
            {
                for (int j = 1; j <= dgv_show.Columns.Count; j++)
                {
                    try
                    {
                        irw = i + 6;
                        if (j != 20 || j != 22)
                        {
                            range = worksheet.get_Range(worksheet.Cells[i + 6, j], worksheet.Cells[i + 6, j]);
                            range.NumberFormat = "@";
                        }
                        if (!DateTime.TryParse(dgv_show.Rows[i].Cells[j - 1].Value.ToString(), out MyDate))
                        {
                            excel.Cells[i + 6, j] = dgv_show.Rows[i].Cells[j - 1].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 6, j] = "'" + dgv_show.Rows[i].Cells[j - 1].Value.ToString();
                        }
                    }
                    catch { }
                }
            }

            object missing = System.Reflection.Missing.Value;



            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[irw, iCol]);
            Excel.Borders borders = range.Borders;
            //Set the thick lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 2d;
           // range.WrapText = true;

            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();

            //((Excel._Application)excel).Save();

            MessageBox.Show("Export To Excel Completed!", "Export");


        }

    }
}
