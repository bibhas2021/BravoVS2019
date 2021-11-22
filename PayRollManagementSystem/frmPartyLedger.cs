using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StackedHeader;
using System.Web.UI.WebControls;

namespace PayRollManagementSystem
{
    public partial class frmPartyLedger : Form
    {
        public frmPartyLedger()
        {
            InitializeComponent();
            StackedHeaderDecorator objREnderer = new StackedHeaderDecorator(dgvALK);
        }
        DataTable dt_alk=new DataTable();
        DataTable dt_sal = new DataTable();
        string coid = "",val_sal="";
        string[] salhead;

        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public void alk()
        {
            try{
                dt_alk.Rows.Clear();
            }catch{}
            try{
                dt_alk.Columns.Clear();
            }
            catch{}
            double tbal = 0;
            dt_alk.Columns.Add("eid");
            dt_alk.Columns.Add("Names");
            //dt_alk.Columns.Add("date");
            if (chkAdv.Checked == true)
            {
                dt_alk.Columns.Add("Advance.Opening balance");
                dt_alk.Columns.Add("Advance.Dr");
                dt_alk.Columns.Add("Advance.Cr");
                dt_alk.Columns.Add("Advance.Balance");
            }

            if (chkLoan.Checked == true)
            {
                dt_alk.Columns.Add("Loan.Opening");
                dt_alk.Columns.Add("Loan.Dr");
                dt_alk.Columns.Add("Loan.Cr");
                dt_alk.Columns.Add("Loan.Balance");
            }
            if (chkKit.Checked == true)
            {
                dt_alk.Columns.Add("Kit.Opening");
                dt_alk.Columns.Add("Kit.Dr");
                dt_alk.Columns.Add("Kit.Cr");
                dt_alk.Columns.Add("Kit.Balance");
            }
            
            dt_alk.Columns.Add("Total.Balance");

            
            DataTable emp =new DataTable();
            if (chkZero.Checked == false)
            {
                emp = clsDataAccess.RunQDTbl("select ID,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
             "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))'Ename'," +
             "(select isnull(SUM(EAAMT)-SUM(EADEDUCT),0)OPa from tbl_Employee_Advance where Company_id=em.Company_id  and convert(datetime,'01/'+eamonth,101)< convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and (EAEID=em.id))AdvOp," +
             "(select isnull(SUM(EAAMT),0)OPa from tbl_Employee_Advance where Company_id=em.Company_id  and convert(datetime,'01/'+eamonth,101)= convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and (EAEID=em.id))AdvDr," +
             "(select isNull(sum(amount),0) from tbl_Employee_SalaryDet where (TableName='tbl_Employee_DeductionSalayHead') and (SalId in (select distinct SAL_HEAD from tbl_Employee_Assign_SalStructure where chkALK=1 and Company_id=em.Company_id )) and (MONTH='" + dtp_ALK_month.Value.ToString("MMMM") + "') and (Session='" + cmbYear.Text + "') and (EmpId=em.ID))'AdvCr'," +
                    //"(select isnull(SUM(EADEDUCT),0)OPa from tbl_Employee_Advance where Company_id=em.Company_id  and convert(datetime,'01/'+eamonth,101)= convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and (EAEID=em.id))AdvCr," +

             "(select isnull(SUM(ELAMT)-SUM(ElDEDUCT),0)opl from tbl_Employee_LOAN where Company_id=em.Company_id  and convert(datetime,'01/'+elmonth,101)< convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and ElEID=em.id)LoanOp," +
             "(select isnull(SUM(ELAMT),0)opl from tbl_Employee_LOAN where Company_id=em.Company_id  and convert(datetime,'01/'+elmonth,101)= convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and ElEID=em.id)LoanDr," +
              "(select isNull(sum(amount),0) from tbl_Employee_SalaryDet where (TableName='tbl_Employee_DeductionSalayHead') and (SalId in (select distinct SAL_HEAD from tbl_Employee_Assign_SalStructure where chkALK=2 and Company_id=em.Company_id )) and (MONTH='" + dtp_ALK_month.Value.ToString("MMMM") + "') and (Session='" + cmbYear.Text + "') and (EmpId=em.ID))'LoanCr'," +
                    //"(select isnull(SUM(ElDEDUCT),0)opl from tbl_Employee_LOAN where Company_id=em.Company_id  and convert(datetime,'01/'+elmonth,101)= convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and ElEID=em.id)LoanCr," +

             "(select isnull(SUM(EkAMT)-SUM(EkDEDUCT),0)opk from tbl_Employee_KIT where Company_id=em.Company_id  and convert(datetime,'01/'+ekmonth,101)< convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and EkEID=em.id)KitOp," +
             "(select isnull(SUM(EkAMT),0)opk from tbl_Employee_KIT where Company_id=em.Company_id  and convert(datetime,'01/'+ekmonth,101)= convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and EkEID=em.id)KitDr," +
              "(select isNull(sum(amount),0) from tbl_Employee_SalaryDet where (TableName='tbl_Employee_DeductionSalayHead') and (SalId in (select distinct SAL_HEAD from tbl_Employee_Assign_SalStructure where chkALK=3 and Company_id=em.Company_id )) and (MONTH='" + dtp_ALK_month.Value.ToString("MMMM") + "') and (Session='" + cmbYear.Text + "') and (EmpId=em.ID))'KitCr'" +
                    //"(select isnull(SUM(EkDEDUCT),0)opk from tbl_Employee_KIT where Company_id=em.Company_id  and convert(datetime,'01/'+ekmonth,101)=convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and EkEID=em.id)KitCr
             " from tbl_Employee_Mast em where (Company_id='" + coid + "')");
            }
            else
            {

                emp = clsDataAccess.RunQDTbl("select ID,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
             "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))'Ename'," +
             "(select isnull(SUM(EAAMT)-SUM(EADEDUCT),0)OPa from tbl_Employee_Advance where Company_id=em.Company_id  and convert(datetime,'01/'+eamonth,101)< convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and (EAEID=em.id))AdvOp," +
             "(select isnull(SUM(EAAMT),0)OPa from tbl_Employee_Advance where Company_id=em.Company_id  and convert(datetime,'01/'+eamonth,101)= convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and (EAEID=em.id))AdvDr," +
             "(select isNull(sum(amount),0) from tbl_Employee_SalaryDet where (TableName='tbl_Employee_DeductionSalayHead') and (SalId in (select distinct SAL_HEAD from tbl_Employee_Assign_SalStructure where chkALK=1 and Company_id=em.Company_id )) and (MONTH='" + dtp_ALK_month.Value.ToString("MMMM") + "') and (Session='" + cmbYear.Text + "') and (EmpId=em.ID))'AdvCr'," +
                    //"(select isnull(SUM(EADEDUCT),0)OPa from tbl_Employee_Advance where Company_id=em.Company_id  and convert(datetime,'01/'+eamonth,101)= convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and (EAEID=em.id))AdvCr," +

             "(select isnull(SUM(ELAMT)-SUM(ElDEDUCT),0)opl from tbl_Employee_LOAN where Company_id=em.Company_id  and convert(datetime,'01/'+elmonth,101)< convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and ElEID=em.id)LoanOp," +
             "(select isnull(SUM(ELAMT),0)opl from tbl_Employee_LOAN where Company_id=em.Company_id  and convert(datetime,'01/'+elmonth,101)= convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and ElEID=em.id)LoanDr," +
              "(select isNull(sum(amount),0) from tbl_Employee_SalaryDet where (TableName='tbl_Employee_DeductionSalayHead') and (SalId in (select distinct SAL_HEAD from tbl_Employee_Assign_SalStructure where chkALK=2 and Company_id=em.Company_id )) and (MONTH='" + dtp_ALK_month.Value.ToString("MMMM") + "') and (Session='" + cmbYear.Text + "') and (EmpId=em.ID))'LoanCr'," +
                    //"(select isnull(SUM(ElDEDUCT),0)opl from tbl_Employee_LOAN where Company_id=em.Company_id  and convert(datetime,'01/'+elmonth,101)= convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and ElEID=em.id)LoanCr," +

             "(select isnull(SUM(EkAMT)-SUM(EkDEDUCT),0)opk from tbl_Employee_KIT where Company_id=em.Company_id  and convert(datetime,'01/'+ekmonth,101)< convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and EkEID=em.id)KitOp," +
             "(select isnull(SUM(EkAMT),0)opk from tbl_Employee_KIT where Company_id=em.Company_id  and convert(datetime,'01/'+ekmonth,101)= convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and EkEID=em.id)KitDr," +
              "(select isNull(sum(amount),0) from tbl_Employee_SalaryDet where (TableName='tbl_Employee_DeductionSalayHead') and (SalId in (select distinct SAL_HEAD from tbl_Employee_Assign_SalStructure where chkALK=3 and Company_id=em.Company_id )) and (MONTH='" + dtp_ALK_month.Value.ToString("MMMM") + "') and (Session='" + cmbYear.Text + "') and (EmpId=em.ID))'KitCr'" +
                    //"(select isnull(SUM(EkDEDUCT),0)opk from tbl_Employee_KIT where Company_id=em.Company_id  and convert(datetime,'01/'+ekmonth,101)=convert(datetime,'01/" + dtp_ALK_month.Value.ToString("MMMM/yyyy") + "',101) and EkEID=em.id)KitCr
             " from tbl_Employee_Mast em where (Company_id='" + coid + "')");
            }
            if (emp.Rows.Count > 0)
            {
                btn_exp_alk.Visible = true;
                for (int ind = 0; ind < emp.Rows.Count; ind++)
                {tbal=0;
                    dt_alk.Rows.Add();
                    dt_alk.Rows[ind]["eid"]=emp.Rows[ind]["ID"].ToString();
                    dt_alk.Rows[ind]["Names"]=emp.Rows[ind]["Ename"].ToString();
                    if (chkAdv.Checked == true)
                    {
                        dt_alk.Rows[ind]["Advance.Opening balance"] = emp.Rows[ind]["AdvOp"].ToString();
                        dt_alk.Rows[ind]["Advance.Dr"] = emp.Rows[ind]["AdvDr"].ToString();
                        dt_alk.Rows[ind]["Advance.Cr"] = emp.Rows[ind]["AdvCr"].ToString();
                        dt_alk.Rows[ind]["Advance.Balance"] = ((Convert.ToDouble(emp.Rows[ind]["AdvOp"].ToString()) + Convert.ToDouble(emp.Rows[ind]["AdvDr"].ToString())) - Convert.ToDouble(emp.Rows[ind]["AdvCr"].ToString()));
                        tbal = tbal + Convert.ToDouble(dt_alk.Rows[ind]["Advance.balance"].ToString());
                    
                    }

                    if (chkLoan.Checked == true)
                    {
                        dt_alk.Rows[ind]["Loan.Opening"] = emp.Rows[ind]["LoanOp"].ToString();
                    dt_alk.Rows[ind]["Loan.Dr"] = emp.Rows[ind]["LoanDr"].ToString();
                    dt_alk.Rows[ind]["Loan.Cr"] = emp.Rows[ind]["LoanCr"].ToString();
                    dt_alk.Rows[ind]["Loan.Balance"] = ((Convert.ToDouble(emp.Rows[ind]["LoanOp"].ToString()) + Convert.ToDouble(emp.Rows[ind]["LoanDr"].ToString()))) - Convert.ToDouble(emp.Rows[ind]["LoanCr"].ToString());
                    tbal= tbal+ Convert.ToDouble(dt_alk.Rows[ind]["Loan.balance"].ToString());
                    }
                    if (chkKit.Checked == true)
                    {
                        dt_alk.Rows[ind]["Kit.Opening"] = emp.Rows[ind]["KitOp"].ToString();
                        dt_alk.Rows[ind]["Kit.Dr"] = emp.Rows[ind]["KitDr"].ToString();
                        dt_alk.Rows[ind]["Kit.Cr"] = emp.Rows[ind]["KitCr"].ToString();
                        dt_alk.Rows[ind]["Kit.Balance"] = ((Convert.ToDouble(emp.Rows[ind]["KitOp"].ToString()) + Convert.ToDouble(emp.Rows[ind]["KitDr"].ToString()))) - Convert.ToDouble(emp.Rows[ind]["KitCr"].ToString());

                        tbal = tbal + Convert.ToDouble(dt_alk.Rows[ind]["Kit.balance"].ToString());
                    }

                    dt_alk.Rows[ind]["Total.Balance"] = tbal.ToString("0.00");
                        //Convert.ToDouble(dt_alk.Rows[ind]["Advance.blance"].ToString()) + Convert.ToDouble(dt_alk.Rows[ind]["Loan.blance"].ToString()) + Convert.ToDouble(dt_alk.Rows[ind]["Kit.blance"].ToString());


                }

            }

           
            dgvALK.DataSource = dt_alk;
        }


        public void sal_details()
        {
            if (cmbSalhead.Text != "")
            {
                salhead = val_sal.Split('|');
                try
                {
                    dt_sal.Rows.Clear();
                }
                catch { }
                try
                {
                    dt_sal.Columns.Clear();
                }
                catch { }
                double tbal = 0;
                //dt_sal.Columns.Add("Date");
                dt_sal.Columns.Add("eid");

                dt_sal.Columns.Add("Names");
                dt_sal.Columns.Add("Location");

                dt_sal.Columns.Add("PaidAmt");



                int ind = 0;
                DataTable emp = clsDataAccess.RunQDTbl("SELECT em.ID,(CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + " +
                "(CASE WHEN ltrim(rtrim(em.MiddleName))!= '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END) AS 'Ename'," +
                "esd.Amount,esd.Location_id,(SElect location_name from tbl_Emp_Location where Location_ID=esd.Location_id)Location FROM tbl_Employee_Mast AS em CROSS JOIN tbl_Employee_SalaryDet esd WHERE (em.Company_id = '" + coid + "') and (esd.EmpId=em.ID) and esd.SalId='" + salhead[0].Trim() + "' and esd.TableName='" + salhead[1].Trim() + "' and esd.Month='" + dtp_sal_month.Value.ToString("MMMM") + "' and esd.Session='" + cmbYear_sal.Text + "' and (esd.Company_id='" + coid + "') order by em.ID");

                if (emp.Rows.Count > 0)
                {
                    tbal = 0;
                    vistaButton3.Visible = true;
                    for (ind = 0; ind < emp.Rows.Count; ind++)
                    {

                        dt_sal.Rows.Add();
                        dt_sal.Rows[ind]["eid"] = emp.Rows[ind]["ID"].ToString();
                        dt_sal.Rows[ind]["Names"] = emp.Rows[ind]["Ename"].ToString();
                        dt_sal.Rows[ind]["Location"] = emp.Rows[ind]["Location"].ToString();
                        dt_sal.Rows[ind]["PaidAmt"] = emp.Rows[ind]["Amount"].ToString();
                        tbal = tbal + Convert.ToDouble(emp.Rows[ind]["Amount"].ToString());
                        //Convert.ToDouble(dt_alk.Rows[ind]["Advance.blance"].ToString()) + Convert.ToDouble(dt_alk.Rows[ind]["Loan.blance"].ToString()) + Convert.ToDouble(dt_alk.Rows[ind]["Kit.blance"].ToString());


                    }
                    dt_sal.Rows.Add();
                    dt_sal.Rows[ind]["eid"] = "";// emp.Rows[ind]["ID"].ToString();
                    dt_sal.Rows[ind]["Names"] = "Total";// emp.Rows[ind]["Ename"].ToString();
                    dt_sal.Rows[ind]["Location"] = "";//emp.Rows[ind]["Location"].ToString();
                    dt_sal.Rows[ind]["PaidAmt"] = tbal.ToString("0.00"); //emp.Rows[ind]["Amount"].ToString();

                }
                else
                {
                    MessageBox.Show("There is no record");
                    return;
                }


                dgv_sal.DataSource = dt_sal;
            }
            else
            {
                MessageBox.Show("Please select salary head");
                return;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            alk();
        }

        private void frmPartyLedger_Load(object sender, EventArgs e)
        {
            dtp_sal_month.Value = DateTime.Now.AddMonths(-1);
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }

            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                cmbcompany.Text = dta.Rows[0][0].ToString();

                coid = Convert.ToString(dta.Rows[0][1].ToString());
                cmbcompany.ReturnValue = coid;
                cmbcompany.Enabled = false;

            }
            else if (dta.Rows.Count > 1)
            {
                cmbcompany.PopUp();
            }
           

            clsValidation.GenerateYear(cmbYear_sal, 2015, System.DateTime.Now.Year, 1);
            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear_sal.SelectedIndex = 0;
            }
            else
            {
                cmbYear_sal.SelectedIndex = 1;
            }

            DataTable dtc = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dtc.Rows.Count == 1)
            {
                cmbCompany_sal.Text = dtc.Rows[0][0].ToString();

                coid = Convert.ToString(dtc.Rows[0][1].ToString());
                cmbCompany_sal.ReturnValue = coid;
                cmbCompany_sal.Enabled = false;

            }
            else if (dta.Rows.Count > 1)
            {
                cmbCompany_sal.PopUp();
            }
           
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
            if (cmbcompany.ReturnValue.Trim() != "")
            {
                coid = Convert.ToString(cmbcompany.ReturnValue);

               
            }
        }

        private void dtp_ALK_month_ValueChanged(object sender, EventArgs e)
        {
            //cmbYear.Text = clsEmployee.GetMonthName(dtp_ALK_month.Value.Month);
           // int year = dtp_ALK_month.Value.Year;
          // int calculated_days = Convert.ToInt32(clsEmployee.GetTotalDaysByMonth(dtp_ALK_month.Text, year));

            //calculateAmt();
            SessionValueCheckAndAssignNoOfDays();
        }
        private void SessionValueCheckAndAssignNoOfDays()
        {
            int NumberOfDays = DateTime.DaysInMonth(dtp_ALK_month.Value.Year, dtp_ALK_month.Value.Month);
            //  txtDays.Text = NumberOfDays.ToString();

            if (dtp_ALK_month.Value.Month >= 4)
            {
                cmbYear.SelectedItem = dtp_ALK_month.Value.Year + "-" + dtp_ALK_month.Value.AddYears(1).Year;

                // cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedItem = dtp_ALK_month.Value.AddYears(-1).Year + "-" + dtp_ALK_month.Value.Year;
                // cmbYear.SelectedIndex = 1;
            }

        }
        private void SessionValueCheckAndAssignNoOfDays_sal()
        {
            int NumberOfDays = DateTime.DaysInMonth(dtp_sal_month.Value.Year, dtp_sal_month.Value.Month);
            //  txtDays.Text = NumberOfDays.ToString();

            if (dtp_sal_month.Value.Month >= 4)
            {
                cmbYear_sal.SelectedItem = dtp_sal_month.Value.Year + "-" + dtp_sal_month.Value.AddYears(1).Year;

                // cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear_sal.SelectedItem = dtp_sal_month.Value.AddYears(-1).Year + "-" + dtp_sal_month.Value.Year;
                // cmbYear.SelectedIndex = 1;
            }

        }

        private void cmbSalhead_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select salaryhead_short,(STR(SlNo)+' | tbl_Employee_ErnSalaryHead') as source from tbl_Employee_ErnSalaryHead" +
            " union " +
            "select salaryhead_short,(STR(SlNo)+' | tbl_Employee_DeductionSalayHead') as source from tbl_Employee_DeductionSalayHead");

            if (dt.Rows.Count > 0)
            {
                cmbSalhead.LookUpTable = dt;
                cmbSalhead.ReturnIndex = 1;
            }
        }

        private void cmbCompany_sal_DropDown(object sender, EventArgs e)
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
                cmbCompany_sal.LookUpTable = dt;
                cmbCompany_sal.ReturnIndex = 1;
            }
        }

        private void cmbCompany_sal_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (cmbCompany_sal.ReturnValue.Trim() != "")
            {
                coid = Convert.ToString(cmbCompany_sal.ReturnValue);
            }
        }

        private void dtp_sal_month_ValueChanged(object sender, EventArgs e)
        {
            SessionValueCheckAndAssignNoOfDays_sal();
        }

        private void cmbSalhead_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (cmbSalhead.ReturnValue.Trim() != "")
            {
                val_sal = (cmbSalhead.ReturnValue).ToString();
            }
        }

        private void vistaButton4_Click(object sender, EventArgs e)
        {
            sal_details();
        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            string head = "", val_range = "";

            //excel

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 0, irw = 0; ;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            iCol = dgvALK.Columns.Count;
            head = cmbcompany.Text;
            val_range = "";

            if (chkAdv.Checked == true)
            {
                val_range = "Advance";
            }
            if (chkLoan.Checked == true)
            {
                if (val_range == "")
                    val_range = "Loan";
                else
                {
                    val_range = val_range + ",Loan";
                }
            }
            if (chkKit.Checked == true)
            {
                if (val_range == "")
                    val_range = "Kit";
                else
                {
                    val_range =val_range + ", Kit";
                }
            }
            val_range = "Ledger Report for "+ val_range + Environment.NewLine + "For the month of "+ dtp_ALK_month.Text;

            excel.Cells[1, 1] = head;

            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);
            range.Merge(true);
            range.Font.Bold = true;


            range.HorizontalAlignment = HorizontalAlign.Center;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[2, 1] = val_range;

            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            range.Columns.AutoFit();
            range.Rows.AutoFit();

            excel.Cells[3, 1] = "";
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();

            string[] cell_head = new string[] { };
            string old_head = "";
            int ind_st = 0, ind_fin = 0;

            for (int i = 1; i <= dgvALK.Columns.Count; i++)
            {
                cell_head = Convert.ToString(dgvALK.Columns[i - 1].HeaderText).Split('.');
                if (cell_head.Length > 1)
                {
                    if (old_head == cell_head[0])
                    {
                        ind_fin = i;
                    }
                    else
                    {
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
                            range.Merge(Type.Missing);
                            range.HorizontalAlignment = HorizontalAlign.Center;
                            range.VerticalAlignment = VerticalAlign.Top;
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


                    excel.Cells[4, i] = dgvALK.Columns[i - 1].HeaderText;
                    try
                    {
                        range = worksheet.get_Range(worksheet.Cells[4, i], worksheet.Cells[5, i]);
                        range.Merge(Type.Missing);
                        range.HorizontalAlignment = HorizontalAlign.Left;
                        range.VerticalAlignment = VerticalAlign.Top;
                    }
                    catch { }
                }

            }
            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
            range.Font.Bold = true;

            for (int i = 0; i < dgvALK.Rows.Count; i++)
            {
                for (int j = 1; j <= dgvALK.Columns.Count; j++)
                {
                    try
                    {
                        irw = i + 6;
                        excel.Cells[i + 6, j] = dgvALK.Rows[i].Cells[j - 1].Value.ToString();
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
            range.WrapText = true;

            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();

            ((Excel._Application)excel).Quit();

            MessageBox.Show("Export To Excel Completed!", "Export");


        }

        private void vistaButton3_Click(object sender, EventArgs e)
        {
            string head = "", val_range = "";

            //excel

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 0, irw = 0; ;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            iCol = dgv_sal.Columns.Count;

            head = cmbCompany_sal.Text;
            val_range = "";

           
            val_range = "Ledger Report for salary head " + cmbSalhead.Text + Environment.NewLine + "For the month of " + dtp_sal_month.Text;

            excel.Cells[1, 1] = head;

            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);
            range.Merge(true);
            range.Font.Bold = true;


            range.HorizontalAlignment = HorizontalAlign.Center;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[2, 1] = val_range;

            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            range.Columns.AutoFit();
            range.Rows.AutoFit();

            excel.Cells[3, 1] = "";
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();

            string[] cell_head = new string[] { };
            string old_head = "";
            int ind_st = 0, ind_fin = 0;

            for (int i = 1; i <= dgv_sal.Columns.Count; i++)
            {
                cell_head = Convert.ToString(dgv_sal.Columns[i - 1].HeaderText).Split('.');
                if (cell_head.Length > 1)
                {
                    if (old_head == cell_head[0])
                    {
                        ind_fin = i;
                    }
                    else
                    {
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
                            range.Merge(Type.Missing);
                            range.HorizontalAlignment = HorizontalAlign.Center;
                            range.VerticalAlignment = VerticalAlign.Top;
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


                    excel.Cells[4, i] = dgv_sal.Columns[i - 1].HeaderText;
                    try
                    {
                        range = worksheet.get_Range(worksheet.Cells[4, i], worksheet.Cells[5, i]);
                        range.Merge(Type.Missing);
                        range.HorizontalAlignment = HorizontalAlign.Left;
                        range.VerticalAlignment = VerticalAlign.Top;
                    }
                    catch { }
                }

            }
            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
            range.Font.Bold = true;

            for (int i = 0; i < dgv_sal.Rows.Count; i++)
            {
                for (int j = 1; j <= dgv_sal.Columns.Count; j++)
                {
                    try
                    {
                        irw = i + 6;
                        excel.Cells[i + 6, j] = dgv_sal.Rows[i].Cells[j - 1].Value.ToString();
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
            range.WrapText = true;

            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();

            ((Excel._Application)excel).Quit();

            MessageBox.Show("Export To Excel Completed!", "Export");


        }
    }
}
