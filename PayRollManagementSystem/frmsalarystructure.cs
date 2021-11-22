using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using Edpcom;
using FirstTimeNeed;
using System.IO;
using System.Threading;


namespace PayRollManagementSystem
{

    public partial class frmsalarystructure : Form
    //EDPComponent.FormBaseERP
    {
        Hashtable emp_id = new Hashtable();
        public Hashtable SalHead1 = new Hashtable();
        Hashtable lbtxt = new Hashtable();
        Hashtable head_formula = new Hashtable();
        Hashtable hsh_cmp_lumpsum = new Hashtable();
        Hashtable hsh_slab = new Hashtable();
        Hashtable hsh_PF = new Hashtable();
        Hashtable hsh_ESI = new Hashtable();
        Hashtable hsh_PT = new Hashtable();
        Hashtable hsh_lst_mnth = new Hashtable();
        Hashtable hsh_All_Mnth = new Hashtable();
        Hashtable hsh_chk_SalErnHead = new Hashtable();
        Hashtable hsh_chk_SalDedHead = new Hashtable();
        Hashtable hsh_chk_SalPFHead = new Hashtable();
        Hashtable hsh_chk_PT = new Hashtable();
        Hashtable hsh_chk_esi = new Hashtable();
        Hashtable hsh_chk_pfVol = new Hashtable();
        Hashtable hsh_DayCount = new Hashtable();
        Hashtable hsh_CFwd_DayCount = new Hashtable();
        Hashtable hsh_PayLeave = new Hashtable();
        Hashtable hsh_emp_code = new Hashtable();
        Hashtable hsh_rtype = new Hashtable();
        ArrayList alMultiDesgEmpID = new ArrayList();
        DataTable tsal_table = new DataTable();
        public TextBoxX.TextBoxX[] txte = new TextBoxX.TextBoxX[32];
        TextBoxX.TextBoxX[] txtd = new TextBoxX.TextBoxX[32];
        TextBoxX.TextBoxX[] txtp = new TextBoxX.TextBoxX[4];
        DataTable EmploySalary_Details = new DataTable();
        DataTable DT_ALK = new DataTable();
        DataTable dt_atn = new DataTable();
        DataTable leaveCountRef = new DataTable();
        SqlTransaction sqltran = null;
        ArrayList arr = new ArrayList();
        SqlCommand cmd = new SqlCommand();
        double pfdue = 0, totpf = 0, besc_PF_Amt = 0;
        public Label[] lbe = new Label[32];
        Label[] lbd = new Label[32];
        Label[] lbp = new Label[4];

        public int salary_structure = 0;
        int deg_id = 0, company_Id = 0, woff = 0, E_D = 0;
        string eid_adv = "", eid_loan = "", eid_kit = "";
        string emply_id = "", lv_Type = "0";
        string Locations = "";
        ArrayList hd_col = new ArrayList();
        ArrayList sa_col = new ArrayList();
        EDPConnection edpcon;
        int chk_A = 0, chk_L = 0, chk_K = 0, chk_RC = 0, val_pf = 0, bak_earn = 0, bak_ded = 0;
        string cur_month = "", OT_Act = "";
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        Boolean total_Leave_visibility = false;

        Boolean boolPFESIManipulating = false;

        DataGridViewRow dgRowTotalCount;
        string vCountry = "", vCity = "", vState = "", ptstate = "";


        Hashtable SalHead = new Hashtable();
        Hashtable SalHead_1 = new Hashtable();
        double gross = 0, cntEmp = 0, cntEmp_tot = 0;
        DataTable EmpDet = new DataTable();
        double esi_empCont = 4.75;
        //Int32 _chkFlag = 0;
        public frmsalarystructure()
        {
            InitializeComponent();
        }

        public void clr_heads()
        {
            for (int t = 0; t < 16; t++)
            {
                lbe[t].Text = null;
                lbd[t].Text = null;
            }


        }
        //======================formula======================================================

        private string GetFormula(string fid)
        {
            string formula = clsDataAccess.GetresultS("select fexp from tbl_Employee_Sal_Structure_Formula where (FID='" + fid + "')");

            return Encode(2, formula.ToString());



        }
        public string Encode(int i1, string str)
        {
            int g = 0, i = 0;
            string fmula = "";
            if (i1 == 1)
            {
                for (int f = 0; f < str.Length; f++)
                {

                    if (str.Substring(f, 1) == "=" || str.Substring(f, 1) == "*" || str.Substring(f, 1) == "+" || str.Substring(f, 1) == "-" || str.Substring(f, 1) == "/" || str.Substring(f, 1) == "%" || str.Substring(f, 1) == "(" || str.Substring(f, 1) == ")")
                    {
                        if (SalHead.ContainsKey(str.Substring(g, i)))
                            fmula += SalHead[str.Substring(g, i)] + str.Substring(f, 1);
                        else
                            fmula += str.Substring(g, i) + str.Substring(f, 1);
                        i = 0;
                        g = f + 1;
                    }
                    else
                        i++;
                }
                fmula += str.Substring(g, i);
                return fmula;
            }
            else
            {
                for (int f = 0; f < str.Length; f++)
                {

                    if (str.Substring(f, 1) == "=" || str.Substring(f, 1) == "*" || str.Substring(f, 1) == "+" || str.Substring(f, 1) == "-" || str.Substring(f, 1) == "/" || str.Substring(f, 1) == "%" || str.Substring(f, 1) == "(" || str.Substring(f, 1) == ")")
                    {
                        if (SalHead1.ContainsKey(str.Substring(g, i)))
                            fmula += SalHead1[str.Substring(g, i)] + str.Substring(f, 1);
                        else
                            fmula += str.Substring(g, i) + str.Substring(f, 1);
                        i = 0;
                        g = f + 1;
                    }
                    else
                        i++;
                }
                fmula += str.Substring(g, i);
                return fmula;
            }
        }

        //==============================================================================================

        public void Configuration_Menu_TypeDoc_companySetting()
        {
            try
            {
                string filePath = "";
                filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
                string line;
                if (File.Exists(filePath))
                {
                    StreamReader file = null;
                    try
                    {
                        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
                        edpcon.Close();
                        file = new StreamReader(filePath);
                        if (file.ReadLine() != null)
                        {
                            int chk_str = 0;
                            while ((line = file.ReadLine()) != null)
                            {
                                string[] StrSTAR = line.Trim().Split('*');
                                if (StrSTAR.Length == 2)
                                {
                                    if (StrSTAR[0].Trim() == "")
                                        continue;
                                }

                                string[] StrLine = line.Trim().Split('[');
                                if (StrLine.Length == 2)
                                {
                                    string str = line.Substring(1, line.Length - 2);
                                    if (str == "Company_Details")
                                        chk_str = 1;
                                    else if (str == "Environment_Envelope")
                                        chk_str = 2;
                                    else if (str == "SDATE")
                                        chk_str = 3;
                                    else
                                        chk_str = 0;
                                }

                                string[] StrLine_WACC = line.Trim().Split(';');

                                if ((chk_str == 1) && (StrLine_WACC.Length > 2))
                                {
                                    if (StrLine_WACC[0] == "Country")
                                    {
                                        vCountry = StrLine_WACC[1];

                                    }
                                    else if (StrLine_WACC[0] == "State")
                                    {
                                        vState = StrLine_WACC[1].ToLower();
                                    }
                                    else if (StrLine_WACC[0] == "City")
                                    {
                                        vCity = StrLine_WACC[1].ToUpper();


                                    }
                                }

                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }

        }

        private void frmsalarystructure_Load(object sender, EventArgs e)
        {
            lblpf_limit.Text = "15000";
            lblEsi_limit.Text = "21000";

            lblEsi_empl.Text = clsDataAccess.GetresultS("select top 1 amount from tbl_Employer_Contribution_Esi order by InsertionDate desc");//"4.75";

            try
            {
                if (clsDataAccess.GetresultS("select SalOC from CompanyLimiter") == "1")
                {
                    grpOCP.Visible = true;
                    lblOCP.Visible = true;
                }
                else
                {
                    grpOCP.Visible = false;
                    lblOCP.Visible = false;
                }
            }
            catch { }

            try
            {
                woff = Convert.ToInt32(clsDataAccess.GetresultS("select woff from CompanyLimiter"));
            }
            catch
            {
                woff = 0;
            }


            try
            {
                lblPayslip.Text = clsDataAccess.GetresultS("select payslip from CompanyLimiter");
            }
            catch
            {
                lblPayslip.Text = "0";
            }

            try
            {
                E_D = Convert.ToInt32(clsDataAccess.GetresultS("select ed from CompanyLimiter"));
            }
            catch
            {
                E_D = 0;
            }

            lv_Type = clsDataAccess.GetresultS("select isNull(lv_type,1) from CompanyLimiter");

            PFESIManipulationChecking();
            Configuration_Menu_TypeDoc_companySetting();
            if (boolPFESIManipulating)
            {
                lblStatusCode.Text = "1";
                label7.Visible = true;
                lblStatusCode.Visible = true;
            }
            else
            {
                lblStatusCode.Text = "4";
                label7.Visible = false;
                lblStatusCode.Visible = false;
            }
            //this.lblTitle.Text = "Employee Salary";
            dtpidate.Value = System.DateTime.Now;
            this.KeyPreview = true;
            clsfirsttime obj_CFT = new clsfirsttime();
            bool result;

            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
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
            btnDeleteSal.Visible = false;
            btnSubmit.Visible = false;
            AttenDtTmPkr.Value = System.DateTime.Now.AddMonths(-1);

            GetSalaryHeads();
            load_txt();
            load_txtd();
            clsGeneralShow genralshow = new clsGeneralShow();
            genralshow.getCurLocID();

            edpcon = new EDPConnection();
            int var_mstcount = Convert.ToInt32(clsDataAccess.GetresultIT("tbl_Employee_Sal_OCharges"));
            if (var_mstcount == 0)
            {
                edpcon.Open();
                result = obj_CFT.Emp_Sal_Ocharge(edpcon.mycon);
            }

            var_mstcount = Convert.ToInt32(clsDataAccess.GetresultI("tbl_Employee_Sal_OCharges", "ODName"));
            if (var_mstcount == 0)
            {
                string str = "ALTER TABLE tbl_Employee_Sal_OCharges ADD [ODName] [nvarchar](150) NULL,[AcNo] [nvarchar](50) NULL,[Bank] [nvarchar](150) NULL,[Branch] [nvarchar](150) NULL,[IFSC] [nvarchar](50) NULL";
                bool rs = clsDataAccess.RunNQwithStatus(str);

            }
            int mn = Convert.ToInt32(clsDataAccess.GetresultI("tbl_Employee_SalaryMast", "chk_A"));
            if (mn == 0)
            {
                string str = "ALTER TABLE tbl_Employee_SalaryMast ADD Chk_A [numeric](18, 0) NULL,Chk_L [numeric](18, 0) NULL,Chk_K  [numeric](18, 0) NULL";
                bool rs = clsDataAccess.RunNQwithStatus(str);

                str = "Update tbl_Employee_SalaryMast set Chk_A=0,Chk_L=0,Chk_K=0";
                rs = clsDataAccess.RunNQwithStatus(str);
            }
            chkAllLocation.Checked = false;


            cmbZone.Text = "";
            cmbZone.Enabled = false;
        }



        private void cmbYear_DropDown(object sender, EventArgs e)
        {
            try
            {
                clear_txt();
            }
            catch (Exception x) { }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cmbMonth.Text = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            int year = AttenDtTmPkr.Value.Year;
            txtcalculated_days.Text = Convert.ToString(clsEmployee.GetTotalDaysByMonth(cmbMonth.Text, year));
            dtp_copy.Value = AttenDtTmPkr.Value.AddMonths(-1);
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


            lblEsi_empl.Text = clsDataAccess.GetresultS("select top 1 amount from tbl_Employer_Contribution_Esi where InsertionDate<='" + AttenDtTmPkr.Value.ToString("dd/MMMM/yyyy") + "'  order by InsertionDate desc");//"4.75";
        }


        private int Day_count(int month)
        {
            int day = 0;
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                day = 31;

            if (month == 4 || month == 6 || month == 9 || month == 11)
                day = 30;

            if (month == 2)
                day = 28;

            return day;
        }


        public void gr_earning(DataTable dtg, int cou)
        {

            try
            {
                get_data();
            }
            catch (Exception ex)
            {

            }

            try
            {
                sal_total();
            }
            catch { }
            string s = "";
            string _empbasic = "";
            string _empsal = "";
            int dt_cou = 8;
            int cnt2 = dgvGross.Rows.Count - 1;
            double earning_amt = 0, lamt = 0, hr_wd = 0, hr_ot = 0;
            //s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE from tbl_Employee_Assign_SalStructure where session='" + cmbYear.Text.Trim() + "' and sal_struct=" + salary_structure + " and p_type='E' ";
            s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE,atten_day,Proxy_day,Daily_wages,C_BASIS,chkAlK,chkHide,mod,wd,pt_basis,[no_round],[limit_day],[ldays],[alt_mon],lvless,gs from tbl_Employee_Assign_SalStructure where sal_struct=" + salary_structure + " and p_type='E' and gs=1 ";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            //if 

            try
            {
                deg_id = Convert.ToInt32(dtg.Rows[cou]["Desgid"].ToString());
            }
            catch { deg_id = 0; }




            if (deg_id == 0)
            {
                deg_id = Convert.ToInt32(clsDataAccess.GetresultS("select DesgId FROM tbl_Employee_Mast where id='" + dtg.Rows[cou]["ID"] + "'"));

            }
            try
            {
                hr_wd = Convert.ToDouble(dtg.Rows[cou]["W_day"]);
                txtattendence.Text = hr_wd.ToString();
            }
            catch
            { hr_wd = 0; txtattendence.Text = "0"; }
            try
            {
                hr_ot = Convert.ToDouble(dtg.Rows[cou]["O_T"]);
            }
            catch
            { hr_ot = 0; }


            try
            {
                cnt2 = dgvGross.Rows.Add();
            }
            catch
            {
                cnt2 = 0;
            }
            try
            {
                this.dgvGross.Rows[cnt2].Cells["Sl"].Value = cnt2 + 1;
                this.dgvGross.Rows[cnt2].Cells["EmployeeName"].Value = dtg.Rows[cou]["EmployeeName"].ToString();
                this.dgvGross.Rows[cnt2].Cells["eid"].Value = dtg.Rows[cou]["ID"].ToString();
                this.dgvGross.Rows[cnt2].Cells["did"].Value = deg_id;

            }
            catch { }

            DataTable dtE = clsDataAccess.RunQDTbl("SELECT EID,EmpId,SalId,TableName,Amount,Month,InsertionDate,Location_id,Client_id,Company_id,desgid,hd FROM tbl_Employee_SalaryGross where (empid='" + dtg.Rows[cou]["ID"].ToString() + "') and (month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "') and (location_id='" + Locations + "')  order by eid");
            for (int idx = 0; idx < dtE.Rows.Count; idx++)
            {
                dgvGross.Rows[cnt2].Cells[dtE.Rows[idx]["SalId"].ToString()].Value = dtE.Rows[idx]["Amount"].ToString();


            }


        }
        public void get_gr_head()
        {
            string s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE,C_BASIS,chkHide,gs from tbl_Employee_Assign_SalStructure where sal_struct=" + salary_structure + " and p_type='E' and gs=1";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (dt.Rows[i]["gs"].ToString().Trim() == "1")
                    {
                        dgvGross.Columns.Add(dt.Rows[i][0].ToString(), get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"));
                    }




                }
            }

        }
        public void get_data()
        {
            string s = ""; int j = 1; int lbl = 6, lbl1 = 6, jt = 0, cou = 0;
            //head_formula.Clear();
            hsh_PF.Clear();
            hsh_ESI.Clear();
            hsh_PT.Clear();

            //pfc = 0; pt = 0;
            //s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE from tbl_Employee_Assign_SalStructure where session='" + cmbYear.Text.Trim() + "' and sal_struct=" + salary_structure + " and p_type='E' ";
            s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE,C_BASIS,chkHide,gs from tbl_Employee_Assign_SalStructure where sal_struct=" + salary_structure + " and p_type='E' ";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][10].ToString().Trim() == "Independent") //Residual Consolidated
                    {
                        Label lb = new Label();
                        //TextBoxX.TextBoxX tx5 = new TextBoxX.TextBoxX();

                        //if (dt.Rows[i][1].ToString().Trim() == "E" && dateTimePicker1.Value.Month >= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][4].ToString()) && dateTimePicker1.Value.Month <= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][5].ToString()))
                        if (dt.Rows[i][1].ToString().Trim() == "E")
                        {
                            arr.Add(0);
                            EmploySalary_Details.Columns.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), typeof(string));
                            if (dt.Rows[i]["gs"].ToString().Trim() == "1")
                            {
                                dgvGross.Columns.Add(dt.Rows[i][0].ToString(), get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"));
                            }
                            lb = lbe[i];
                            lb.Text = get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E");
                            lbe[i] = lb;

                            //this.grpern.Controls.Add(lbe[i]);
                            if (dt.Rows[i][9].ToString().Trim() == "Nearest Rupee")
                            {
                                if (!hsh_rtype.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    hsh_rtype.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][9].ToString().Trim());
                            }
                            if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                            {
                                if (!head_formula.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    head_formula.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][3].ToString());

                            }
                            else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                            {
                                if (!hsh_cmp_lumpsum.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    hsh_cmp_lumpsum.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][3].ToString());
                            }
                            else if (dt.Rows[i][2].ToString().Trim() == "SLAB")
                            {
                                if (!hsh_slab.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    hsh_slab.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][3].ToString());
                            }
                            if (Convert.ToDouble(dt.Rows[i]["PF_PER"]) > 0)
                            {
                                if (!hsh_PF.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    hsh_PF.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), Convert.ToString(Convert.ToDouble(dt.Rows[i]["PF_PER"]) / 100));
                            }
                            if (Convert.ToDouble(dt.Rows[i]["ESI_PER"]) > 0)
                            {
                                if (!hsh_ESI.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    hsh_ESI.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), Convert.ToString(Convert.ToDouble(dt.Rows[i]["ESI_PER"]) / 100));
                            }
                            if (Convert.ToDouble(dt.Rows[i]["PT"]) > 0)
                            {
                                if (!hsh_PT.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    hsh_PT.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i]["PT"].ToString());
                            }
                        }
                    }
                    else
                    {
                        Label lb = new Label();
                        //TextBoxX.TextBoxX tx5 = new TextBoxX.TextBoxX();

                        //if (dt.Rows[i][1].ToString().Trim() == "E" && dateTimePicker1.Value.Month >= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][4].ToString()) && dateTimePicker1.Value.Month <= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][5].ToString()))
                        if (dt.Rows[i][1].ToString().Trim() == "E")
                        {
                            arr.Add(0);
                            EmploySalary_Details.Columns.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), typeof(string));
                            lb = lbe[i];
                            lb.Text = get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E");
                            lbe[i] = lb;

                            //this.grpern.Controls.Add(lbe[i]);
                            if (dt.Rows[i][9].ToString().Trim() == "Nearest Rupee")
                            {
                                if (!hsh_rtype.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    hsh_rtype.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][9].ToString().Trim());
                            }
                            if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                            {
                                if (!head_formula.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    head_formula.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][3].ToString());

                            }
                            else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                            {
                                if (!hsh_cmp_lumpsum.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    hsh_cmp_lumpsum.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][3].ToString());
                            }
                            else if (dt.Rows[i][2].ToString().Trim() == "SLAB")
                            {
                                if (!hsh_slab.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    hsh_slab.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i][3].ToString());
                            }
                            if (Convert.ToDouble(dt.Rows[i]["PF_PER"]) > 0)
                            {
                                if (!hsh_PF.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    hsh_PF.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), Convert.ToString(Convert.ToDouble(dt.Rows[i]["PF_PER"]) / 100));
                            }
                            if (Convert.ToDouble(dt.Rows[i]["ESI_PER"]) > 0)
                            {
                                if (!hsh_ESI.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    hsh_ESI.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), Convert.ToString(Convert.ToDouble(dt.Rows[i]["ESI_PER"]) / 100));
                            }
                            if (Convert.ToDouble(dt.Rows[i]["PT"]) > 0)
                            {
                                if (!hsh_PT.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E")))
                                    hsh_PT.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E"), dt.Rows[i]["PT"].ToString());
                            }
                        }
                    }

                }

            }
        }


        public void get_data1()
        {
            string s = ""; int j = 1; int lbl = 6, lbl1 = 6, jt = 0, cou = 0;
            //s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE from tbl_Employee_Assign_SalStructure where session='" + cmbYear.Text.Trim() + "' and sal_struct=" + salary_structure + " and p_type='D'";
            s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE,chkALK,chkHide from tbl_Employee_Assign_SalStructure where sal_struct=" + salary_structure + " and p_type='D'";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Label lb = new Label();

                    //if (dt.Rows[i][1].ToString().Trim() == "D" && dateTimePicker1.Value.Month >= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][4].ToString()) && dateTimePicker1.Value.Month <= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][5].ToString()))
                    if (dt.Rows[i][1].ToString().Trim() == "D")
                    {
                        arr.Add(0);
                        EmploySalary_Details.Columns.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D"), typeof(string));
                        lb = lbd[i];
                        lb.Text = get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D");
                        lbd[i] = lb;
                        //this.grpded.Controls.Add(lbd[i]);
                        if (dt.Rows[i][9].ToString().Trim() == "Nearest Rupee")
                        {
                            if (!hsh_rtype.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D")))
                                hsh_rtype.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D"), dt.Rows[i][9].ToString().Trim());
                        }
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            if (!head_formula.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D")))
                                head_formula.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D"), dt.Rows[i][3].ToString());
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                        {
                            if (!hsh_cmp_lumpsum.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D")))
                                hsh_cmp_lumpsum.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D"), dt.Rows[i][3].ToString());
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "SLAB")
                        {
                            if (!hsh_slab.ContainsKey(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D")))
                                hsh_slab.Add(get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D"), dt.Rows[i][3].ToString());
                        }

                    }
                }
            }
            //sal_total();

        }

        public void Get_mnth_detl()
        {
            string eid = "";
            hsh_All_Mnth.Clear();
            hsh_lst_mnth.Clear();
            //if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
            //    eid = emp_id[cmbempname1111.Text.Trim()].ToString();
            eid = "0";

            string s = "";
            s = "select session,month,emp_id from tbl_Employee_SalaryMast where session='" + cmbYear.Text.Trim() + "' and emp_id='" + eid + "' and slno=(select max(slno) from tbl_Employee_SalaryMast where emp_id='" + eid + "')";

            DataTable temp_dt = new DataTable();
            temp_dt = clsDataAccess.RunQDTbl(s);
            if (temp_dt.Rows.Count > 0)
            {
                hsh_lst_mnth.Add(temp_dt.Rows[0][0].ToString() + "/" + temp_dt.Rows[0][2].ToString(), temp_dt.Rows[0][1].ToString());
            }

            s = "select session,month,emp_id from tbl_Employee_SalaryMast where session='" + cmbYear.Text.Trim() + "' and emp_id='" + eid + "'";
            DataTable temp_dt1 = new DataTable();
            temp_dt1 = clsDataAccess.RunQDTbl(s);
            if (temp_dt1.Rows.Count > 0)
            {
                for (int te = 0; te < temp_dt1.Rows.Count; te++)
                {
                    string s1 = temp_dt1.Rows[te][0].ToString() + "/" + temp_dt1.Rows[te][1].ToString() + "/" + temp_dt1.Rows[te][2].ToString();
                    if (!hsh_All_Mnth.ContainsKey(temp_dt1.Rows[te][0].ToString() + "/" + temp_dt1.Rows[te][1].ToString() + "/" + temp_dt1.Rows[te][2].ToString()))
                        hsh_All_Mnth.Add(temp_dt1.Rows[te][0].ToString() + "/" + temp_dt1.Rows[te][1].ToString() + "/" + temp_dt1.Rows[te][2].ToString(), temp_dt1.Rows[te][1].ToString());
                }
            }
        }
        public void hide_col()
        {

            string sql = "select sal_head, p_type from tbl_Employee_Assign_SalStructure where (sal_struct=" + salary_structure + ") and (chkHide in (1,'31'))";
            DataTable dt_hide = new DataTable();
            dt_hide = clsDataAccess.RunQDTbl(sql);
            hd_col.Clear();
            //for (int ind_rowl=0; ind_rowl < dt_hide.Rows.Count; ind_rowl++)
            //{
            //    hd_col.Add(0);
            //}
            for (int ind = 0; ind < dt_hide.Rows.Count; ind++)
            {
                hd_col.Add(0);
                hd_col[ind] = get_sal_head_name(Convert.ToInt32(dt_hide.Rows[ind]["sal_head"]), dt_hide.Rows[ind]["p_type"].ToString());
                if (dt_hide.Rows[ind]["p_type"].ToString() == "E")
                {
                    earn_count.Text = (Convert.ToInt32(earn_count.Text) - 1).ToString();
                }

            }


            sql = "select sal_head, p_type from tbl_Employee_Assign_SalStructure where (sal_struct=" + salary_structure + ") and chkHide=2";
            dt_hide = new DataTable();
            dt_hide = clsDataAccess.RunQDTbl(sql);
            sa_col.Clear();
            //for (int ind_rowl=0; ind_rowl < dt_hide.Rows.Count; ind_rowl++)
            //{
            //    hd_col.Add(0);
            //}
            for (int ind = 0; ind < dt_hide.Rows.Count; ind++)
            {
                sa_col.Add(0);
                sa_col[ind] = get_sal_head_name(Convert.ToInt32(dt_hide.Rows[ind]["sal_head"]), dt_hide.Rows[ind]["p_type"].ToString());
                if (dt_hide.Rows[ind]["p_type"].ToString() == "E")
                {
                    earn_count.Text = (Convert.ToInt32(earn_count.Text) - 1).ToString();
                }

            }

        }

        public void back_earning(int rw)
        {
            string s = "", col_name = "";
            string _empbasic = "";

            s = "select sal_head,p_type,c_type,c_det,EMP_BASIC,chkAlK,chkHide from tbl_Employee_Assign_SalStructure where sal_struct=" + salary_structure + " and p_type='E' ";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["c_type"].ToString().Trim() == "COMPANY LUMPSUM")
                {
                    if (Information.IsNumeric(txtattendence.Text) == true)
                    {
                        //int Cur_Month = dateTimePicker1.Value.Month;
                        int Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                        string lum_amt = "", gross_val = "";
                        if (dt.Rows[i]["chkAlK"].ToString().Trim() == "6")
                        {
                            col_name = get_sal_head_name(Convert.ToInt32(dt.Rows[i]["sal_head"]), "E");
                            //testless
                            _empbasic = "select EMP_BASIC from tbl_Employee_Assign_SalStructure where sal_struct=" + salary_structure + " and p_type='E' and sal_head=" + dt.Rows[i]["sal_head"] + "";
                            DataTable dt1 = new DataTable();
                            dt1 = clsDataAccess.RunQDTbl(_empbasic);

                            if (dt1.Rows[0][0].ToString().Trim() == "1")
                            {
                                lum_amt = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                if (lum_amt == null || lum_amt == "")
                                    lum_amt = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                            }
                            else if (dt1.Rows[0][0].ToString().Trim() == "2")
                            {
                                lum_amt = clsDataAccess.GetresultS("Select EMPSAL-empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                if (lum_amt == null || lum_amt == "")
                                    lum_amt = clsDataAccess.GetresultS("Select EMPSAL-empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                            }
                            else if (dt1.Rows[0][0].ToString().Trim() == "3")
                            {
                                lum_amt = clsDataAccess.GetresultS("Select EMPSAL from tbl_Employee_Mast where id ='" + emply_id + "'");
                                if (lum_amt == null || lum_amt == "")
                                    lum_amt = clsDataAccess.GetresultS("Select EMPSAL from tbl_Employee_Mast where id ='" + emply_id + "'");
                            }
                            else if (dt1.Rows[0][0].ToString().Trim() == "4")
                            {
                                lum_amt = Convert.ToString(Convert.ToDouble(EmploySalary_Details.Rows[rw]["Total_Earning"]) - Convert.ToDouble(EmploySalary_Details.Rows[rw]["Total_Deduction"]));
                            }
                            else
                            {
                                lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                if (lum_amt == null || lum_amt == "")
                                    lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                            }

                            lum_amt = Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDouble(lum_amt) / Month_Day), 2));
                            EmploySalary_Details.Rows[rw][col_name] = lum_amt;
                            int ind = EmploySalary_Details.Columns.IndexOf(col_name);
                            arr[dt.Rows.Count + ind] = Convert.ToDouble(lum_amt);
                            gross_val = Convert.ToString(Convert.ToDouble(EmploySalary_Details.Rows[rw]["Total_Earning"]) + Convert.ToDouble(lum_amt));
                            EmploySalary_Details.Rows[rw]["Total_Earning"] = gross_val;
                            ind = EmploySalary_Details.Columns.IndexOf("Total_Earning");
                            arr[dt.Rows.Count + ind] = Convert.ToDouble(arr[dt.Rows.Count + ind]) + Convert.ToDouble(gross_val);//Convert.ToDouble(arr[dt.Rows.Count + 7]) + lum_amt;
                        }
                    }
                }


            }
        }

        public string other_WD(string exp, string wday, string tdays)
        {

            double atten = Convert.ToDouble(wday);
            double intMOD = 0;
            string modVal = exp.ToUpper();
            int Month_Day = Convert.ToInt32(txtcalculated_days.Text);
            if (exp != "0")
            {

                if (modVal == "MONTHOFDAYS")
                {
                    try
                    {
                        int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                        intMOD = NumberOfDays;
                        if (atten == intMOD)
                        {
                            atten = intMOD;
                        }
                    }
                    catch { }
                }
                else if (modVal == "TDAYS")
                {
                    intMOD = Convert.ToDouble(tdays);
                    if (atten == intMOD)
                    {
                        atten = intMOD;
                    }
                }
                else if (modVal == "MOD-4")
                {
                    try
                    {
                        int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                        intMOD = NumberOfDays - 4;
                    }
                    catch { }
                }
                else if (modVal == "MOD-SUNDAYS")
                {
                    try
                    {
                        int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value);
                        intMOD = NumberOfDays;
                    }
                    catch { }
                }
                else if (modVal.Contains("RANGE-SUNDAYS"))
                {
                    string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                    int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), true);
                    intMOD = NumberOfDays;

                    //tbTo.Text = strFromTo[1];
                }
                else if (modVal.Contains("RANGE"))
                {
                    string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                    int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), false);
                    intMOD = NumberOfDays;
                    if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1])))
                    {
                        atten = intMOD;
                    }
                    //tbTo.Text = strFromTo[1];
                }
                else
                {
                    try
                    {
                        if (exp.Substring(0, 4) == "MOD-")
                        {

                            try
                            {
                                int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                                intMOD = NumberOfDays - Convert.ToInt32(modVal.Substring(4, (modVal.Length - 4)));
                            }
                            catch { }
                        }
                        else
                        {
                            intMOD = Convert.ToDouble(exp);
                        }
                    }
                    catch { intMOD = Convert.ToDouble(exp); }
                }


            }

            return intMOD.ToString();
        }

        public void emp_earning()
        {
            string s = "";
            OT_Act = "";
            string _empbasic = "";
            string _empsal = "";
            int cou = 0, dt_cou = 8;
            int cnt2 = dgvGross.Rows.Count - 1;
            double tdays = 0;
            double earning_amt = 0, lamt = 0, hr_wd = 0, hr_ot = 0, cWD = 0, cWdMod = 0, hrs_ed = 0, config_days = 0, mod_days = 0;
            //s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE from tbl_Employee_Assign_SalStructure where session='" + cmbYear.Text.Trim() + "' and sal_struct=" + salary_structure + " and p_type='E' ";
            s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE,atten_day,Proxy_day,Daily_wages,C_BASIS,chkAlK,chkHide,mod,wd,pt_basis,[no_round],[limit_day],[ldays],[alt_mon],lvless,gs,chkFlag from tbl_Employee_Assign_SalStructure where (sal_struct=" + salary_structure + ") and (p_type='E') and (chkHide not in('3','31')) ";
            DataTable dt = new DataTable();

            DataTable dtround = clsDataAccess.RunQDTbl("select [no_round] from tbl_Employee_Assign_SalStructure where (location_id='"+cmbLocation.ReturnValue.Trim()+"') and (sal_struct=" + salary_structure + ") and (p_type='E') and ([no_round]=2) and (chkHide not in('3','31'))");
            dt = clsDataAccess.RunQDTbl(s);
            //if 

            try
            {
                sal_total();
            }
            catch { }
            try
            {
                hr_wd = Convert.ToDouble(dt_atn.Rows[0]["Wday"]);
            }
            catch
            { hr_wd = 0; }
            try
            {
                hr_ot = Convert.ToDouble(dt_atn.Rows[0]["Proxy"]);
            }
            catch
            { hr_ot = 0; }

            try
            {
                hrs_ed = Convert.ToDouble(dt_atn.Rows[0]["ed"]);
            }
            catch
            { hrs_ed = 0; }

            try
            {
                // _chkFlag = Convert.ToInt32();
            }
            catch
            { //_chkFlag = 0; 
            }
            try
            {
                if (lbl_mod.Text == "MOD-EWO")
                {
                    mod_days = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                }
                else
                {
                    mod_days = Convert.ToDouble(txtcalculated_days.Text);
                }
            }
            catch { mod_days = Convert.ToDouble(txtcalculated_days.Text); }

            try
            {
                cWD = Convert.ToDouble(dt_atn.Rows[0]["cWD"]);

                //Convert.ToDouble(clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Attend where ID ='" + emply_id + "' and Desgid='" + dt_atn.Rows[0]["Desgid"] + "' and (LOcation_ID ='" + dt_atn.Rows[0]["LOcation_id"] + "') AND (Month = '" + AttenDtTmPkr.Value.ToString("MM/yyyy") + "')"));
            }
            catch { cWD = 0; }


            try
            {

                cWdMod = Convert.ToDouble(clsDataAccess.ReturnValue("Select other from tbl_Site_mod_desg where (sid='" + dt_atn.Rows[0]["LOcation_id"] + "') and (desgid='" + dt_atn.Rows[0]["Desgid"] + "')"));
                if (cWdMod == 0)
                {
                    if (lbl_mod.Text.Trim().ToUpper() == "MOD-EWO")
                    {
                        cWdMod = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                    }
                    else
                    {
                        cWdMod = Convert.ToDouble(txtcalculated_days.Text);
                    }
                    cWD = hr_wd;
                }
            }
            catch { }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    cou = EmploySalary_Details.Rows.Count - 1;
                    tdays = Convert.ToDouble(EmploySalary_Details.Rows[cou]["Tot_Day"]);

                    int Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                    if (lbl_mod.Text == "MOD-EWO")
                    {
                        Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                    }
                    else
                    {
                        Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                    }

                    //"if ((select isNUll(salid,0) from tbl_Employee_Mast where ID='" + EmploySalary_Details.Rows[cou]["ID"].ToString() + "')=1) " + Environment.NewLine +
                    //             "Select '1' as EMP_BASIC" + Environment.NewLine +
                    //             "Else" + Environment.NewLine +
                    //testless
                    _empbasic = "select (case when eas.SAL_HEAD=1 then (case when (select top 1 isNUll(salid,0) from tbl_Employee_Mast em where em.ID='" + EmploySalary_Details.Rows[cou]["ID"].ToString() + "')=1 then '1' else eas.EMP_BASIC end) Else EMP_BASIC End)as EMP_BASIC from tbl_Employee_Assign_SalStructure eas where (sal_struct=" + salary_structure + ") and (p_type='E') and (sal_head=" + dt.Rows[i]["sal_head"] + ")";
                    DataTable dt1 = new DataTable();
                    dt1 = clsDataAccess.RunQDTbl(_empbasic);

                    //testless

                    if (dt1.Rows[0][0].ToString().Trim() == "1")
                    {
                        EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                        if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                            EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                    }
                    else if (dt1.Rows[0][0].ToString().Trim() == "2")
                    {
                        EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.GetresultS("Select EMPSAL - empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                        if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                            EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.GetresultS("Select EMPSAL - empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                    }
                    else if (dt1.Rows[0][0].ToString().Trim() == "3")
                    {
                        EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.GetresultS("Select EMPSAL from tbl_Employee_Mast where id ='" + emply_id + "'");
                        if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                            EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.GetresultS("Select EMPSAL from tbl_Employee_Mast where id ='" + emply_id + "'");
                    }
                    else
                    {
                        EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                        if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                            EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                    }


                    ////////EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                    ////////if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                    ////////    EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                    if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1" || Convert.ToString(dt.Rows[i]["Daily_wages"]) == "11" || Convert.ToString(dt.Rows[i]["Daily_wages"]) == "12" || Convert.ToString(dt.Rows[i]["Daily_wages"]) == "13" || Convert.ToString(dt.Rows[i]["Daily_wages"]) == "14")
                        if (Information.IsNumeric(EmploySalary_Details.Rows[cou]["Salary"]) == true)
                            EmploySalary_Details.Rows[cou]["Salary"] = Convert.ToString(Convert.ToDouble(EmploySalary_Details.Rows[cou]["Salary"]) * Month_Day);

                }
                //if (dt.Rows[i][1].ToString().Trim() == "E" && dateTimePicker1.Value.Month >= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][4].ToString()) && dateTimePicker1.Value.Month <= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][5].ToString()))
                if (dt.Rows[i][1].ToString().Trim() == "E")
                {
                    if (dt.Rows[i][13].ToString().Trim() == "Independent") //Residual Consolidated
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            string lum_amt = "";

                            lum_amt = cal_formula_desg(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(EmploySalary_Details.Rows[cou]["DesgID"]));
                            try
                            {
                                if (Convert.ToDecimal(EmploySalary_Details.Rows[cou]["Salary"]) == Convert.ToDecimal(0))
                                {
                                    lum_amt = "0";
                                }

                                if ((dt.Rows[i]["chkFLag"].ToString().Trim() == "1") && (Convert.ToDouble(lum_amt) < 0))
                                {
                                    lum_amt = "0";
                                }
                            }
                            catch
                            {
                                lum_amt = "0";
                            }
                            if (Convert.ToDouble(lum_amt) < 0)
                            {
                                lum_amt = "0";
                            }
                            int idx = 0;
                            if ((dt.Rows[i]["alt_mon"].ToString().Trim() == "1") && (dt.Rows[i]["pt"].ToString().Trim() == "0"))
                            {
                                string[] month = dt.Rows[i]["pt_basis"].ToString().Split(',');
                                string mon;
                                idx = 1;
                                for (int ind = 0; ind < month.Length; ind++)
                                {
                                    mon = (1 + "/" + month[ind].ToString().Substring(0, 3).ToUpper().Trim() + "/" + AttenDtTmPkr.Value.Year.ToString()).ToString();
                                    if (Convert.ToDateTime(mon).ToString("MMM/yyyy") == Convert.ToDateTime("01/" + AttenDtTmPkr.Value.ToString("MMM/yyyy")).ToString("MMM/yyyy"))
                                    {
                                        idx = 2;
                                    }


                                }

                            }

                            if (idx == 1)
                            {
                                lum_amt = "0";
                            }
                            if (Convert.ToString(dt.Rows[i]["gs"]) == "1")
                            {
                                if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                {
                                    dgvGross.Rows[cnt2].Cells[dt.Rows[i][0].ToString()].Value = Convert.ToString(Math.Round(Convert.ToDouble(lum_amt) * Convert.ToInt32(txtcalculated_days.Text)));
                                    gross = gross + Convert.ToDouble(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToInt32(txtcalculated_days.Text))));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "2")
                                {
                                    if (dt.Rows[i]["Proxy_day"].ToString() == "1")
                                    {
                                        dgvGross.Rows[cnt2].Cells[dt.Rows[i][0].ToString()].Value = Convert.ToString(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToDouble(lbl_ot_hrs.Text)) * Convert.ToInt32(txtcalculated_days.Text)));
                                        gross = gross + Convert.ToDouble(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToDouble(lbl_ot_hrs.Text)) * Convert.ToInt32(txtcalculated_days.Text)));
                                    }
                                    else
                                    {
                                        dgvGross.Rows[cnt2].Cells[dt.Rows[i][0].ToString()].Value = Convert.ToString(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToDouble(lbl_wd_hrs.Text)) * Convert.ToInt32(txtcalculated_days.Text)));
                                        gross = gross + Convert.ToDouble(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToDouble(lbl_wd_hrs.Text)) * Convert.ToInt32(txtcalculated_days.Text)));
                                    }
                                }
                                else
                                {

                                    if (Convert.ToDouble(lum_amt) != 0)
                                    {
                                        try
                                        {
                                            dgvGross.Rows[cnt2].Cells[dt.Rows[i][0].ToString()].Value = Convert.ToDouble(Math.Round((Math.Round(Convert.ToDouble(lum_amt)) * Convert.ToDouble(txtcalculated_days.Text)) / Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"])));
                                            gross = gross + Convert.ToDouble(Math.Round((Math.Round(Convert.ToDouble(lum_amt)) * Convert.ToDouble(txtcalculated_days.Text)) / Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"])));
                                        }
                                        catch
                                        {
                                            dgvGross.Rows[cnt2].Cells[dt.Rows[i][0].ToString()].Value = 0;
                                            gross = gross + 0;
                                        }
                                    }
                                    else
                                    {
                                        dgvGross.Rows[cnt2].Cells[dt.Rows[i][0].ToString()].Value = "0";
                                        gross = gross + 0;
                                    }
                                }
                            }
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;

                                int Month_Day = 0;
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }

                                if (Convert.ToString(dt.Rows[i]["mod"]) != "0")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    int intMOD = 0;
                                    string modVal = dt.Rows[i]["mod"].ToString().ToUpper();
                                    if (modVal == "MONTHOFDAYS")
                                    {
                                        try
                                        {
                                            int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                                            intMOD = NumberOfDays;
                                            if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value))
                                            {
                                                atten = intMOD;
                                            }
                                        }
                                        catch { }
                                    }
                                    else if (modVal == "MOD-SUNDAYS")
                                    {
                                        try
                                        {
                                            int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value);
                                            intMOD = NumberOfDays;
                                        }
                                        catch { }
                                    }
                                    else if (modVal.Contains("RANGE-SUNDAYS"))
                                    {
                                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                        int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), true);
                                        intMOD = NumberOfDays;

                                        //tbTo.Text = strFromTo[1];
                                    }
                                    else if (modVal.Contains("RANGE"))
                                    {
                                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                        int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), false);
                                        intMOD = NumberOfDays;
                                        if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1])))
                                        {
                                            atten = intMOD;
                                        }
                                        //tbTo.Text = strFromTo[1];
                                    }
                                    else
                                    {
                                        intMOD = Convert.ToInt32(dt.Rows[i]["mod"]);
                                    }

                                    Month_Day = intMOD;
                                }

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]) + Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);


                                    if (dt.Rows[i]["wd"].ToString().Trim() != "0")
                                    {
                                        atten = Convert.ToDouble(other_WD(dt.Rows[i]["wd"].ToString(), atten.ToString(), tdays.ToString()));

                                    }


                                    if (dt.Rows[i]["limit_day"].ToString() == "1")
                                    {
                                        if (Convert.ToDouble(dt.Rows[i]["ldays"]) > atten)
                                        {
                                            atten = 0;
                                        }
                                    }

                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    lum_amt = amt.ToString();
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt, MidpointRounding.AwayFromZero));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);

                                    if (dt.Rows[i]["limit_day"].ToString() == "1")
                                    {
                                        if (Convert.ToDouble(dt.Rows[i]["ldays"]) > atten)
                                        {
                                            atten = 0;
                                        }
                                    }
                                    if (dt.Rows[i]["wd"].ToString().Trim() != "0")
                                    {
                                        atten = Convert.ToDouble(other_WD(dt.Rows[i]["wd"].ToString(), atten.ToString(), tdays.ToString()));

                                    }
                                    if (dt.Rows[i]["limit_day"].ToString() == "1")
                                    {
                                        if (Convert.ToDouble(dt.Rows[i]["ldays"]) > atten)
                                        {
                                            atten = 0;
                                        }
                                    }

                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    lum_amt = amt.ToString();
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt, MidpointRounding.AwayFromZero));
                                }

                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                    //double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    //ANURAG
                                    double amt = 0;

                                    if (dt.Rows[i]["limit_day"].ToString() == "1")
                                    {
                                        if (Convert.ToDouble(dt.Rows[i]["ldays"]) > Proxy_day)
                                        {
                                            Proxy_day = 0;
                                        }
                                    }
                                    if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                    {
                                        amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day));
                                        if (amt > 0)
                                            OT_Act = lum_amt + " X " + Proxy_day + " days";
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "2")
                                    {
                                        amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                        //amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day));
                                        if (amt > 0)
                                            OT_Act = ((Convert.ToDouble(lum_amt) / Convert.ToDouble(Month_Day)) / Convert.ToDouble(lbl_ot_hrs.Text)).ToString("0.0000") + " / Hrs";
                                    }
                                    else
                                    {
                                        amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                        if (amt > 0)
                                            OT_Act = lum_amt + " / mon";
                                    }
                                    lum_amt = amt.ToString();
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt, MidpointRounding.AwayFromZero));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "2")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["E_D"]);
                                    //double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    //ANURAG
                                    double amt = 0;
                                    if (dt.Rows[i]["limit_day"].ToString() == "1")
                                    {
                                        if (Convert.ToDouble(dt.Rows[i]["ldays"]) > Proxy_day)
                                        {
                                            Proxy_day = 0;
                                        }
                                    }

                                    if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                    {
                                        amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day));
                                        if (amt > 0)
                                            OT_Act = lum_amt + " X " + Proxy_day + " Hrs";
                                    }
                                    else
                                    {
                                        amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    }
                                    lum_amt = amt.ToString();
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt, MidpointRounding.AwayFromZero));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    if (dt.Rows[i]["limit_day"].ToString() == "1")
                                    {
                                        if (Convert.ToDouble(dt.Rows[i]["ldays"]) > atten)
                                        {
                                            atten = 0;
                                        }
                                    }
                                    if (dt.Rows[i]["wd"].ToString().Trim() != "0")
                                    {
                                        atten = Convert.ToDouble(other_WD(dt.Rows[i]["wd"].ToString(), atten.ToString(), tdays.ToString()));

                                    }
                                    lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * atten);
                                    //Month_Day);

                                }



                            }

                            if (Information.IsNumeric(lum_amt) == true)
                            {
                                if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                {
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(lum_amt));
                                    txte[i].Text = string.Format("{0:F}", Convert.ToDouble(lum_amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["chkALK"]) == "7")
                                {
                                    string gs = "0", lv_adj = "0";
                                    int Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                    if (lbl_mod.Text == "MOD-EWO")
                                    {
                                        Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                    }
                                    else
                                    {
                                        Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                    }

                                    if (Convert.ToString(dt.Rows[i]["mod"]) != "0")
                                    {
                                        double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                        int intMOD = 0;
                                        string modVal = dt.Rows[i]["mod"].ToString().ToUpper();
                                        if (modVal == "MONTHOFDAYS")
                                        {
                                            try
                                            {
                                                int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                                                intMOD = NumberOfDays;
                                                if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value))
                                                {
                                                    atten = intMOD;
                                                }
                                            }
                                            catch { }
                                        }
                                        else if (modVal == "MOD-SUNDAYS")
                                        {
                                            try
                                            {
                                                int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value);
                                                intMOD = NumberOfDays;
                                            }
                                            catch { }
                                        }
                                        else if (modVal.Contains("RANGE-SUNDAYS"))
                                        {
                                            string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                            int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), true);
                                            intMOD = NumberOfDays;

                                            //tbTo.Text = strFromTo[1];
                                        }
                                        else if (modVal.Contains("RANGE"))
                                        {
                                            string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                            int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), false);
                                            intMOD = NumberOfDays;
                                            if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1])))
                                            {
                                                atten = intMOD;
                                            }
                                            //tbTo.Text = strFromTo[1];
                                        }
                                        else
                                        {
                                            intMOD = Convert.ToInt32(dt.Rows[i]["mod"]);
                                        }

                                        Month_Day = intMOD;
                                    }
                                    bool lv_allow = false;
                                    int imon = Convert.ToInt32(clsDataAccess.GetresultS("select lv_adj FROM Companywiseid_Relation where (Company_ID='" + company_Id + "') and (Location_ID='" + Locations + "')"));
                                    try
                                    {
                                        lv_allow = Convert.ToBoolean(clsDataAccess.ReturnValue("select cfw from tbl_Employee_Attend where (Month ='" + this.AttenDtTmPkr.Value.Month + "/" + this.AttenDtTmPkr.Value.Year + "') and  (Season = '" + cmbYear.Text + "') and (Location_ID ='" + Locations + "') and (ID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and (Desgid='" + EmploySalary_Details.Rows[cou]["DesgId"].ToString() + "')"));
                                    }
                                    catch { }
                                    _empbasic = "select (case when eas.SAL_HEAD=1 then (case when (select isNUll(salid,0) from tbl_Employee_Mast em where em.ID='" + EmploySalary_Details.Rows[cou]["ID"].ToString() + "')=1 then '1' else eas.EMP_BASIC end) Else EMP_BASIC End)as EMP_BASIC from tbl_Employee_Assign_SalStructure eas where (sal_struct=" + salary_structure + ") and (p_type='E') and (sal_head=" + dt.Rows[i]["sal_head"] + ")";
                                    DataTable dt1 = new DataTable();
                                    dt1 = clsDataAccess.RunQDTbl(_empbasic);

                                    //testless
                                    if (lv_Type == "1")
                                    {
                                        if ((imon == 0 || imon == AttenDtTmPkr.Value.Month) && lv_allow == true)
                                        {
                                            gs = lum_amt;
                                        }
                                        else
                                        {

                                            gs = "0";
                                        }
                                        //if (Convert.ToString(EmploySalary_Details.Rows[cou][i + dt_cou]) == "")
                                        //    gs = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                        //testless
                                        double lvamt = 0;
                                        lv_adj = clsDataAccess.GetresultS("SELECT ((lv_earn + lv_pbal) - lv_adj) AS lv FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID='" + Locations + "') AND (Company_id = '" + company_Id + "') and (ID='" + emply_id + "')");
                                        if (imon == 0 || imon == AttenDtTmPkr.Value.Month)
                                        {

                                            lvamt = Convert.ToDouble((Convert.ToDouble(gs) / Month_Day) * Convert.ToDouble(lv_adj));
                                            if (lvamt > 0)
                                            {
                                                EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(lvamt - Convert.ToDouble(dt.Rows[i]["lvless"])));
                                            }
                                            else
                                            {
                                                EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(lvamt));
                                            }
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou]), MidpointRounding.AwayFromZero));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = "0.00";
                                            txte[i].Text = "0.00";
                                        }

                                    }
                                    else if (lv_Type == "2")
                                    {

                                        if (imon == 0 || imon == AttenDtTmPkr.Value.Month)
                                        {
                                            gs = lum_amt;
                                        }
                                        else
                                        {

                                            gs = "0";
                                        }


                                        double lvamt = 0;
                                        lv_adj = clsDataAccess.GetresultS("SELECT lv_adj AS lv FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID='" + Locations + "') AND (Company_id = '" + company_Id + "') and (ID='" + emply_id + "')");

                                        lvamt = Convert.ToDouble((Convert.ToDouble(gs) / Month_Day) * Convert.ToDouble(lv_adj));
                                        if (lvamt > 0)
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(lvamt - Convert.ToDouble(dt.Rows[i]["lvless"])));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(lvamt));
                                        }
                                        txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou]), MidpointRounding.AwayFromZero));
                                        //}
                                        //else
                                        //{
                                        //    EmploySalary_Details.Rows[cou][i + dt_cou] = "0.00";
                                        //    txte[i].Text = "0.00";
                                        //}

                                    }
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));
                                }
                            }
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                        {   //if (i == 0)
                            //{
                            if (Convert.ToString(dt.Rows[i]["PT"]) == "1")
                            {
                                string ptax_amt = "";
                                string gender = clsDataAccess.GetresultS("select (case when ltrim(rtrim(Gender))='' then 'MALE' else Gender end ) FROM tbl_Employee_Mast where ID='" + EmploySalary_Details.Rows[cou]["ID"] + "'");
                                string estate = "";
                                string pt_basis = dt.Rows[i]["pt_basis"].ToString().ToLower();
                                string[] pt_bs;
                                double bs_pt = 0;

                                if (pt_basis == "gross")
                                {
                                    bs_pt = Convert.ToDouble(EmploySalary_Details.Rows[cou]["Total_Earning"]);
                                }
                                else
                                {
                                    pt_bs = dt.Rows[i]["pt_basis"].ToString().Split('+');

                                    for (int idx = 0; idx < pt_bs.Length; idx++)
                                    {
                                        bs_pt = bs_pt + Convert.ToDouble(EmploySalary_Details.Rows[cou][pt_bs[idx].ToString()]);
                                    }


                                }
                                if (AttenDtTmPkr.Value.ToString("MMM").ToUpper() == "FEB")
                                {
                                    ptax_amt = clsDataAccess.GetresultS("Select isNull((case when alt_pt>0 then alt_pt else pt end),0) pt from tbl_Employee_PTRate where (wfrom <=" + bs_pt + " and wto >=" + bs_pt + ") and (lower(estate)='" + vState.ToLower() + "') and (upper(gender) in ('" + gender.ToUpper() + "','ALL'))");
                                }
                                else
                                {

                                    ptax_amt = clsDataAccess.GetresultS("Select isNull(pt,0) from tbl_Employee_PTRate where (wfrom <=" + bs_pt + " and wto >=" + bs_pt + ") and (lower(estate)='" + vState.ToLower() + "') and (upper(gender) in ('" + gender.ToUpper() + "','ALL'))");
                                }

                                //string ptax_amt = clsDataAccess.GetresultS("Select pt from tbl_Employee_PTRate where wfrom <=" + EmploySalary_Details.Rows[cou]["Total_Earning"] + " and wto >=" + EmploySalary_Details.Rows[cou]["Total_Earning"] + " ");
                                if (Information.IsNumeric(ptax_amt) == true)
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", ptax_amt);
                                else
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = "0.00";
                                txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou])));
                            }
                            else if (Convert.ToString(dt.Rows[i]["chkALK"]) == "7")
                            {
                                string gs = "0", lv_adj = "0";
                                bool lv_allow = false;
                                int Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }

                                int imon = Convert.ToInt32(clsDataAccess.GetresultS("select lv_adj FROM Companywiseid_Relation where (Company_ID='" + company_Id + "') and (Location_ID='" + Locations + "')"));
                                try
                                {
                                    lv_allow = Convert.ToBoolean(clsDataAccess.ReturnValue("select cfw from tbl_Employee_Attend where (Month ='" + this.AttenDtTmPkr.Value.Month + "/" + this.AttenDtTmPkr.Value.Year + "') and  (Season = '" + cmbYear.Text + "') and (Location_ID ='" + Locations + "') and (ID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and (Desgid='" + EmploySalary_Details.Rows[cou]["DesgId"].ToString() + "')"));
                                }
                                catch { }
                                _empbasic = "select (case when eas.SAL_HEAD=1 then (case when (select isNUll(salid,0) from tbl_Employee_Mast em where em.ID='" + EmploySalary_Details.Rows[cou]["ID"].ToString() + "')=1 then '1' else eas.EMP_BASIC end) Else EMP_BASIC End)as EMP_BASIC from tbl_Employee_Assign_SalStructure eas where (sal_struct=" + salary_structure + ") and (p_type='E') and (sal_head=" + dt.Rows[i]["sal_head"] + ")";
                                DataTable dt1 = new DataTable();
                                dt1 = clsDataAccess.RunQDTbl(_empbasic);

                                //testless
                                if (lv_Type == "1")
                                {
                                    if ((imon == 0 || imon == AttenDtTmPkr.Value.Month) && lv_allow == true)
                                    {
                                        if (dt1.Rows[0][0].ToString().Trim() == "1")
                                        {
                                            gs = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");

                                        }
                                        else if (dt1.Rows[0][0].ToString().Trim() == "2")
                                        {
                                            gs = clsDataAccess.GetresultS("Select EMPSAL - empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");

                                        }
                                        else if (dt1.Rows[0][0].ToString().Trim() == "3")
                                        {
                                            gs = clsDataAccess.GetresultS("Select EMPSAL from tbl_Employee_Mast where id ='" + emply_id + "'");

                                        }
                                        else
                                        {
                                            gs = clsDataAccess.GetresultS("Select isNull(AMOUNT,0) from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                            if (gs == null || gs == "")
                                                gs = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                                        }
                                    }
                                    else
                                    {

                                        gs = "0";
                                    }
                                    //if (Convert.ToString(EmploySalary_Details.Rows[cou][i + dt_cou]) == "")
                                    //    gs = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                    //testless
                                    double lvamt = 0;
                                    lv_adj = clsDataAccess.GetresultS("SELECT ((lv_earn + lv_pbal) - lv_adj) AS lv FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID='" + Locations + "') AND (Company_id = '" + company_Id + "') and (ID='" + emply_id + "')");
                                    if (imon == 0 || imon == AttenDtTmPkr.Value.Month)
                                    {
                                        lvamt = Convert.ToDouble((Convert.ToDouble(gs) / Month_Day) * Convert.ToDouble(lv_adj));
                                        if (lvamt > 0)
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(lvamt - Convert.ToDouble(dt.Rows[i]["lvless"])));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(lvamt));
                                        }
                                        txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou]), MidpointRounding.AwayFromZero));
                                    }
                                    else
                                    {
                                        EmploySalary_Details.Rows[cou][i + dt_cou] = "0.00";
                                        txte[i].Text = "0.00";
                                    }

                                }
                                else if (lv_Type == "2")
                                {

                                    if (dt1.Rows[0][0].ToString().Trim() == "1")
                                    {
                                        gs = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");

                                    }
                                    else if (dt1.Rows[0][0].ToString().Trim() == "2")
                                    {
                                        gs = clsDataAccess.GetresultS("Select EMPSAL - empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");

                                    }
                                    else if (dt1.Rows[0][0].ToString().Trim() == "3")
                                    {
                                        gs = clsDataAccess.GetresultS("Select EMPSAL from tbl_Employee_Mast where id ='" + emply_id + "'");

                                    }
                                    else
                                    {
                                        gs = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                        if ((gs == "0") || (gs == null))
                                        {
                                            gs = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =0 ");

                                        }
                                    }


                                    double lvamt = 0;
                                    lv_adj = clsDataAccess.GetresultS("SELECT lv_adj AS lv FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID='" + Locations + "') AND (Company_id = '" + company_Id + "') and (ID='" + emply_id + "')");

                                    lvamt = Convert.ToDouble((Convert.ToDouble(gs) / Month_Day) * Convert.ToDouble(lv_adj));
                                    if (lvamt > 0)
                                    {
                                        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(lvamt - Convert.ToDouble(dt.Rows[i]["lvless"])));
                                    }
                                    else
                                    {
                                        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(lvamt));
                                    }
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou]), MidpointRounding.AwayFromZero));
                                    //}
                                    //else
                                    //{
                                    //    EmploySalary_Details.Rows[cou][i + dt_cou] = "0.00";
                                    //    txte[i].Text = "0.00";
                                    //}




                                }


                            }
                            else
                                if (Information.IsNumeric(txtattendence.Text) == true)
                                {
                                    //int Cur_Month = dateTimePicker1.Value.Month;
                                    int Month_Day = 0;// Convert.ToInt32(txtcalculated_days.Text);
                                    if (lbl_mod.Text == "MOD-EWO")
                                    {
                                        Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                    }
                                    else
                                    {
                                        Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                    }
                                    string lum_amt = "";

                                    //testless
                                    _empbasic = "select (case when eas.SAL_HEAD=1 then (case when (select Top 1 isNUll(salid,0) from tbl_Employee_Mast em where em.ID='" + EmploySalary_Details.Rows[cou]["ID"].ToString() + "')=1 then '1' else eas.EMP_BASIC end) Else EMP_BASIC End)as EMP_BASIC from tbl_Employee_Assign_SalStructure eas where (sal_struct=" + salary_structure + ") and (p_type='E') and (sal_head=" + dt.Rows[i]["sal_head"] + ")";
                                    //"if ((select isNUll(salid,0) from tbl_Employee_Mast where ID='" + EmploySalary_Details.Rows[cou]["ID"].ToString() + "')=1) " + Environment.NewLine +
                                    //                "select '1' as EMP_BASIC" + Environment.NewLine +
                                    //             "Else" + Environment.NewLine +
                                    //                "select EMP_BASIC from tbl_Employee_Assign_SalStructure where sal_struct=" + salary_structure + " and p_type='E' and sal_head=" + dt.Rows[i]["sal_head"] + "";
                                    DataTable dt1 = new DataTable();
                                    dt1 = clsDataAccess.RunQDTbl(_empbasic);

                                    if (dt1.Rows[0][0].ToString().Trim() == "1")
                                    {
                                        lum_amt = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                        if (lum_amt == null || lum_amt == "")
                                            lum_amt = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                    }
                                    else if (dt1.Rows[0][0].ToString().Trim() == "2")
                                    {
                                        lum_amt = clsDataAccess.GetresultS("Select EMPSAL-empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                        if (lum_amt == null || lum_amt == "")
                                            lum_amt = clsDataAccess.GetresultS("Select EMPSAL-empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                    }
                                    else if (dt1.Rows[0][0].ToString().Trim() == "3")
                                    {
                                        lum_amt = clsDataAccess.GetresultS("Select EMPSAL from tbl_Employee_Mast where id ='" + emply_id + "'");
                                        if (lum_amt == null || lum_amt == "")
                                            lum_amt = clsDataAccess.GetresultS("Select EMPSAL from tbl_Employee_Mast where id ='" + emply_id + "'");
                                    }
                                    else if (dt1.Rows[0][0].ToString().Trim() == "5")
                                    {
                                        if (clsDataAccess.ReturnValue("select eas.EMP_BASIC from tbl_Employee_Assign_SalStructure eas where (sal_struct=" + salary_structure + ") and (p_type='E') and (sal_head=" + dt.Rows[i]["sal_head"] + ")") == "5")
                                        {
                                            try
                                            {
                                                lum_amt = clsDataAccess.ReturnValue("SELECT value FROM tbl_other_deduction where (ecode='" +
                              EmploySalary_Details.Rows[cou]["ID"] + "') and (cast('28-'+ MONTH as date)<=cast('28-" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") +
                              "' as date)) and (head=(select SalaryHead_Short from  tbl_Employee_ErnSalaryHead where SlNo='" + dt.Rows[i]["sal_head"].ToString() +
                              "')) and (locid='" + Locations.Trim() + "') and (coid='" + company_Id + "') and (type='E') ");
                                            }
                                            catch { }
                                        }
                                    }
                                    else
                                    {
                                        lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                        if (lum_amt == null || lum_amt == "")
                                            lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                                    }

                                    //lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                    //if (lum_amt == null || lum_amt == "")
                                    //    lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                    //testless

                                    if (Information.IsNumeric(lum_amt) == false)
                                        lum_amt = "0";

                                    int idx = 0;
                                    if ((dt.Rows[i]["alt_mon"].ToString().Trim() == "1") && (dt.Rows[i]["pt"].ToString().Trim() == "0"))
                                    {
                                        string[] month = dt.Rows[i]["pt_basis"].ToString().Split(',');
                                        string mon;
                                        idx = 1;
                                        for (int ind = 0; ind < month.Length; ind++)
                                        {
                                            mon = (1 + "/" + month[ind].ToString().Substring(0, 3).ToUpper().Trim() + "/" + AttenDtTmPkr.Value.Year.ToString()).ToString();
                                            if (Convert.ToDateTime(mon).ToString("MMM/yyyy") == Convert.ToDateTime("01/" + AttenDtTmPkr.Value.ToString("MMM/yyyy")).ToString("MMM/yyyy"))
                                            {
                                                idx = 2;
                                            }


                                        }

                                    }
                                    if (idx == 1)
                                    {
                                        lum_amt = "0";
                                    }
                                    if (Convert.ToString(dt.Rows[i]["gs"]) == "1")
                                    {

                                        /* Wday - 1
                                        OT - 11
                                        TDays - 12
                                        ED - 13 */

                                        if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1" || Convert.ToString(dt.Rows[i]["Daily_wages"]) == "11" || Convert.ToString(dt.Rows[i]["Daily_wages"]) == "12" || Convert.ToString(dt.Rows[i]["Daily_wages"]) == "13" || Convert.ToString(dt.Rows[i]["Daily_wages"]) == "14")
                                        {
                                            dgvGross.Rows[cnt2].Cells[dt.Rows[i][0].ToString()].Value = Convert.ToString(Math.Round(Convert.ToDouble(lum_amt) * Convert.ToInt32(txtcalculated_days.Text)));
                                            gross = gross + Convert.ToDouble(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToInt32(txtcalculated_days.Text))));
                                        }


                                        else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "2")
                                        {
                                            if (dt.Rows[i]["Proxy_day"].ToString() == "1")
                                            {
                                                dgvGross.Rows[cnt2].Cells[dt.Rows[i][0].ToString()].Value = Convert.ToString(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToDouble(lbl_ot_hrs.Text)) * Convert.ToInt32(txtcalculated_days.Text)));
                                                gross = gross + Convert.ToDouble(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToDouble(lbl_ot_hrs.Text)) * Convert.ToInt32(txtcalculated_days.Text)));
                                            }
                                            else if (dt.Rows[i]["Proxy_day"].ToString() == "2" && Convert.ToString(dt.Rows[i]["Daily_wages"]) == "0")
                                            {
                                                dgvGross.Rows[cnt2].Cells[dt.Rows[i][0].ToString()].Value = Convert.ToString(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToDouble(lbl_wd_hrs.Text)) * Convert.ToInt32(txtcalculated_days.Text)));
                                                gross = gross + Convert.ToDouble(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToDouble(lbl_wd_hrs.Text)) * Convert.ToInt32(txtcalculated_days.Text)));
                                            }
                                            else if (dt.Rows[i]["Proxy_day"].ToString() == "2" && Convert.ToString(dt.Rows[i]["Daily_wages"]) == "2")
                                            {
                                                dgvGross.Rows[cnt2].Cells[dt.Rows[i][0].ToString()].Value = Convert.ToString(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToDouble(hrs_ed))));// * Convert.ToInt32(txtcalculated_days.Text)));
                                                gross = gross + Convert.ToDouble(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToDouble(hrs_ed))));//Convert.ToDouble(lbl_wd_hrs.Text)) * Convert.ToInt32(txtcalculated_days.Text)));
                                            }
                                            else
                                            {
                                                dgvGross.Rows[cnt2].Cells[dt.Rows[i][0].ToString()].Value = Convert.ToString(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToDouble(lbl_wd_hrs.Text)) * Convert.ToInt32(txtcalculated_days.Text)));
                                                gross = gross + Convert.ToDouble(Math.Round((Convert.ToDouble(lum_amt) * Convert.ToDouble(lbl_wd_hrs.Text)) * Convert.ToInt32(txtcalculated_days.Text)));
                                            }
                                        }
                                        else
                                        {
                                            dgvGross.Rows[cnt2].Cells[dt.Rows[i][0].ToString()].Value = Math.Round(Convert.ToDouble(lum_amt));

                                            gross = gross + Math.Round(Convert.ToDouble(lum_amt));
                                        }
                                    }


                                    if (Convert.ToString(dt.Rows[i]["mod"]) != "0")
                                    {
                                        double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                        int intMOD = 0;
                                        string modVal = dt.Rows[i]["mod"].ToString().ToUpper();
                                        if (modVal == "MONTHOFDAYS")
                                        {
                                            try
                                            {
                                                int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                                                intMOD = NumberOfDays;
                                                if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value))
                                                {
                                                    atten = intMOD;
                                                }
                                            }
                                            catch { }
                                        }
                                        else if (modVal == "MOD-SUNDAYS")
                                        {
                                            try
                                            {
                                                int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value);
                                                intMOD = NumberOfDays;
                                            }
                                            catch { }
                                        }
                                        else if (modVal.Contains("RANGE-SUNDAYS"))
                                        {
                                            string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                            int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), true);
                                            intMOD = NumberOfDays;

                                            //tbTo.Text = strFromTo[1];
                                        }
                                        else if (modVal.Contains("RANGE"))
                                        {
                                            string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                            int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), false);
                                            intMOD = NumberOfDays;
                                            if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1])))
                                            {
                                                atten = intMOD;
                                            }
                                            //tbTo.Text = strFromTo[1];
                                        }
                                        else
                                        {
                                            intMOD = Convert.ToInt32(dt.Rows[i]["mod"]);
                                        }

                                        Month_Day = intMOD;
                                    }

                                    if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "0")
                                    {
                                        double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);

                                        if (dt.Rows[i]["wd"].ToString().Trim() != "0")
                                        {
                                            atten = Convert.ToDouble(other_WD(dt.Rows[i]["wd"].ToString(), atten.ToString(), tdays.ToString()));

                                        }
                                        lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * atten);
                                        //atten);
                                        //Month_Day);
                                        if (dt.Rows[i]["chkHide"].ToString().Trim() == "1")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = Convert.ToDouble(lum_amt).ToString();
                                            txte[i].Text = Convert.ToDouble(lum_amt).ToString();
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));

                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                        }
                                    }
                                    if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "2" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "0")
                                    {
                                        double atten = hr_wd;//Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);

                                        if (dt.Rows[i]["wd"].ToString().Trim() != "0")
                                        {
                                            atten = Convert.ToDouble(other_WD(dt.Rows[i]["wd"].ToString(), atten.ToString(), tdays.ToString()));

                                        }
                                        lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * atten);
                                        //atten);
                                        //Month_Day);
                                        if (dt.Rows[i]["chkHide"].ToString().Trim() == "1")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = Convert.ToDouble(lum_amt).ToString();
                                            txte[i].Text = Convert.ToDouble(lum_amt).ToString();
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));

                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                        }
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "3" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "0" && Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                    {
                                        double atten = cWD;




                                        lum_amt = Convert.ToString((Convert.ToDouble(lum_amt) * atten) / cWdMod);
                                        //cWdMod);
                                        //atten);
                                        //Month_Day);
                                        if (dt.Rows[i]["chkHide"].ToString().Trim() == "1")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = Convert.ToDouble(lum_amt).ToString();
                                            txte[i].Text = Convert.ToDouble(lum_amt).ToString();
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));

                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                        }
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "3" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "0" && Convert.ToString(dt.Rows[i]["atten_day"]) == "0")
                                    {
                                        double atten = cWD;




                                        lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * cWdMod);
                                        //cWdMod);
                                        //atten);
                                        //Month_Day);
                                        if (dt.Rows[i]["chkHide"].ToString().Trim() == "1")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = Convert.ToDouble(lum_amt).ToString();
                                            txte[i].Text = Convert.ToDouble(lum_amt).ToString();
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));

                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                        }
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                    {
                                        double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                        OT_Act = lum_amt + " X " + Proxy_day + " days";
                                        lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * Proxy_day);
                                        //Month_Day);
                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(lum_amt));
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(lum_amt));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));
                                        }
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "2" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                    {
                                        double Proxy_day = hr_ot;//Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                        OT_Act = lum_amt + " X " + Proxy_day + " hrs";
                                        lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * Proxy_day);
                                        //Month_Day);
                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(lum_amt));
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(lum_amt));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));
                                        }
                                    }
                                    // Additional Modes in Daily wages 05/02/2019
                                    /* Wday - 1
                                          OT - 11
                                          TDays - 12
                                          ED - 13 */

                                    else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "12") // TDays - 12
                                    {
                                        double atten = 0, amt = 0;
                                        try
                                        {
                                            atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["Tot_Day"]);
                                        }
                                        catch { atten = 0; }
                                        amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten));

                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(amt));
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(amt));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt), MidpointRounding.AwayFromZero));
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt), MidpointRounding.AwayFromZero));
                                        }
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "11") // OT - 11
                                    {

                                        double atten = 0, amt = 0;
                                        try
                                        {
                                            atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                        }
                                        catch { atten = 0; }
                                        OT_Act = lum_amt + " X " + atten + " days";
                                        amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten));

                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(amt));
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(amt));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt), MidpointRounding.AwayFromZero));
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt), MidpointRounding.AwayFromZero));
                                        }
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "13") // ED - 13
                                    {
                                        double atten = 0, amt = 0;
                                        try
                                        {
                                            atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["E_D"]);
                                        }
                                        catch { atten = 0; }
                                        amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten));
                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(amt));
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(amt));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt), MidpointRounding.AwayFromZero));
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt), MidpointRounding.AwayFromZero));
                                        }

                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "14") //Config daily waiges - 14
                                    {
                                        double atten = 0, amt = 0;
                                        try
                                        {
                                            atten = Convert.ToDouble(cWD);
                                        }
                                        catch { atten = 0; }
                                        amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten));
                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(amt));
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(amt));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt), MidpointRounding.AwayFromZero));
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt), MidpointRounding.AwayFromZero));
                                        }

                                    }
                                    //ANURAG
                                    else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "5")
                                    {
                                        lum_amt = "0";
                                        double atten1 = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                        lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                        if (atten1 >= 26)
                                        {
                                            if (Convert.ToDouble(lum_amt) == 1250)
                                                lum_amt = Convert.ToString(600);
                                            else if (Convert.ToDouble(lum_amt) == 1050)
                                                lum_amt = Convert.ToString(400);
                                            else if (Convert.ToDouble(lum_amt) == 850)
                                                lum_amt = Convert.ToString(200);
                                        }
                                        else if (atten1 >= 21)
                                        {
                                            if (Convert.ToDouble(lum_amt) == 1250)
                                                lum_amt = Convert.ToString(450);
                                            else if (Convert.ToDouble(lum_amt) == 1050)
                                                lum_amt = Convert.ToString(300);
                                            else if (Convert.ToDouble(lum_amt) == 850)
                                                lum_amt = Convert.ToString(150);
                                        }
                                        else if (atten1 >= 14)
                                        {
                                            if (Convert.ToDouble(lum_amt) == 1250)
                                                lum_amt = Convert.ToString(300);
                                            else if (Convert.ToDouble(lum_amt) == 1050)
                                                lum_amt = Convert.ToString(200);
                                            else if (Convert.ToDouble(lum_amt) == 850)
                                                lum_amt = Convert.ToString(100);
                                        }
                                        else if (atten1 >= 6)
                                        {
                                            if (Convert.ToDouble(lum_amt) == 1250)
                                                lum_amt = Convert.ToString(150);
                                            else if (Convert.ToDouble(lum_amt) == 1050)
                                                lum_amt = Convert.ToString(100);
                                            else if (Convert.ToDouble(lum_amt) == 850)
                                                lum_amt = Convert.ToString(50);
                                        }
                                        else
                                            lum_amt = Convert.ToString(0);


                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(lum_amt));
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(lum_amt));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));
                                        }
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                    {
                                        double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]) + Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                        double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;

                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(amt));
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(amt));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt), MidpointRounding.AwayFromZero);
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt), MidpointRounding.AwayFromZero));
                                        }
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                    {
                                        double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);

                                        if (dt.Rows[i]["wd"].ToString().Trim() != "0")
                                        {
                                            atten = Convert.ToDouble(other_WD(dt.Rows[i]["wd"].ToString(), atten.ToString(), tdays.ToString()));

                                        }


                                        if (dt.Rows[i]["limit_day"].ToString() == "1")
                                        {
                                            if (Convert.ToDouble(dt.Rows[i]["ldays"]) > atten)
                                            {
                                                atten = 0;
                                            }
                                        }

                                        double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;

                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(amt));
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(amt));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt, MidpointRounding.AwayFromZero));
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt), MidpointRounding.AwayFromZero));
                                        }
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                    {
                                        double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                        //ANURAG
                                        double amt = 0;
                                        if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                        {
                                            amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day));
                                            if (amt > 0)
                                                OT_Act = lum_amt + " X " + Proxy_day + " days";
                                        }
                                        else
                                        {
                                            amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                            if (amt > 0)
                                                OT_Act = lum_amt + " /Mon";
                                        }
                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(amt));
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(amt));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt, MidpointRounding.AwayFromZero));
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt), MidpointRounding.AwayFromZero));
                                        }
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "2")
                                    {
                                        double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["E_D"]);
                                        //ANURAG
                                        double amt = 0;

                                        if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                        {
                                            amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day));
                                            if (amt > 0)
                                                OT_Act = lum_amt + " X " + Proxy_day + " Hrs";
                                        }
                                        else
                                        {
                                            amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                        }

                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", amt);
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(amt));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt, MidpointRounding.AwayFromZero));
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt), MidpointRounding.AwayFromZero));
                                        }
                                    }

                                    /*else if (Convert.ToString(dt.Rows[i]["mod"]) != "0")
                                    {
                                        double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                        int intMOD = 0;
                                        string modVal = dt.Rows[i]["mod"].ToString().ToUpper();
                                        if (modVal == "MONTHOFDAYS")
                                        {
                                            try
                                            {
                                                int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                                                intMOD = NumberOfDays;
                                                if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value))
                                                {
                                                    atten = intMOD;
                                                }
                                            }
                                            catch { }
                                        }
                                        else if (modVal == "MOD-SUNDAYS")
                                        {
                                            try
                                            {
                                                int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value);
                                                intMOD = NumberOfDays;
                                            }
                                            catch { }
                                        }
                                        else if (modVal.Contains("RANGE-SUNDAYS"))
                                        {
                                            string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                            int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), true);
                                            intMOD = NumberOfDays;

                                            //tbTo.Text = strFromTo[1];
                                        }
                                        else if (modVal.Contains("RANGE"))
                                        {
                                            string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                            int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), false);
                                            intMOD = NumberOfDays;
                                            if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1])))
                                            {
                                                atten = intMOD;
                                            }
                                        }
                                        else
                                        {
                                            intMOD = Convert.ToInt32(dt.Rows[i]["mod"]);
                                        }

                                        double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / intMOD;
                                        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                        txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                                    }*/
                                    else
                                    {

                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(lum_amt));
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(lum_amt));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt), MidpointRounding.AwayFromZero));
                                        }

                                    }

                                    //}
                                    //else
                                    //{
                                    //    EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                    //    if (Convert.ToString(EmploySalary_Details.Rows[cou][i + dt_cou]) == "")
                                    //        EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                    //    if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + dt_cou]) == true)
                                    //        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + 7])));
                                    //}
                                }

                                else
                                {
                                    //EmploySalary_Details.Rows[cou][i + 6] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " ");

                                    //testless

                                    EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                    if (Convert.ToString(EmploySalary_Details.Rows[cou][i + dt_cou]) == "")
                                        EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                    //testless

                                    if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + dt_cou]) == true)
                                    {
                                        if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou]));
                                            txte[i].Text = string.Format("{0:F}", Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou]));
                                        }
                                        else
                                        {
                                            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou])));
                                            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou]), MidpointRounding.AwayFromZero));
                                        }
                                    }
                                }
                        }
                    }
                    else if (dt.Rows[i][13].ToString().Trim() == "Inflow")
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            _empsal = "select EMPSAL from tbl_Employee_Mast where id='" + emply_id + "' ";
                            DataTable dt_empsal = new DataTable();
                            dt_empsal = clsDataAccess.RunQDTbl(_empsal);

                            string lum_amt = "";
                            double esi_amt = 0;
                            lum_amt = cal_formula(Convert.ToInt32(dt.Rows[i][3]));
                            if (Convert.ToDecimal(EmploySalary_Details.Rows[cou]["Salary"]) == Convert.ToDecimal(0))
                            {
                                lum_amt = "0";
                            }
                            if (Convert.ToDouble(lum_amt) < 0)
                            {
                                lum_amt = "0";
                            }
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                int Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                    {
                                        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(amt));

                                    }
                                    else
                                    {
                                        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt, MidpointRounding.AwayFromZero));
                                    }
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    double _sal_amt = (Convert.ToDouble(dt_empsal.Rows[0][0]) * Convert.ToDouble(atten)) / Month_Day;
                                    double amt = _sal_amt - (Convert.ToDouble(lum_amt));
                                    esi_amt = Convert.ToDouble(amt);
                                    if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                    {
                                        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", amt);

                                    }
                                    else
                                    {
                                        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt, MidpointRounding.AwayFromZero));
                                    }
                                    //double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    //double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    //EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                    {
                                        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", amt);

                                    }
                                    else
                                    {
                                        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt, MidpointRounding.AwayFromZero));
                                    }
                                }
                            }

                            if (Information.IsNumeric(lum_amt) == true)
                            {
                                if (dt.Rows[i]["no_round"].ToString().Trim() == "1" || dt.Rows[i]["no_round"].ToString().Trim() == "2")
                                {
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Convert.ToDouble(esi_amt));
                                    txte[i].Text = string.Format("{0:F}", Convert.ToDouble(esi_amt));
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(esi_amt)));
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(esi_amt), MidpointRounding.AwayFromZero));
                                }
                            }
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                            //if (i == 0)
                            //{
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                int Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }

                                string lum_amt = "";

                                //testless
                                _empbasic = "select EMP_BASIC from tbl_Employee_Assign_SalStructure where sal_struct=" + salary_structure + " and p_type='E' and sal_head=" + dt.Rows[i]["sal_head"] + "";
                                DataTable dt1 = new DataTable();
                                dt1 = clsDataAccess.RunQDTbl(_empbasic);

                                if (dt1.Rows[0][0].ToString().Trim() == "1")
                                {
                                    lum_amt = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "2")
                                {
                                    lum_amt = clsDataAccess.GetresultS("Select EMPSAL - empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.GetresultS("Select EMPSAL - empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "3")
                                {
                                    lum_amt = clsDataAccess.GetresultS("Select EMPSAL from tbl_Employee_Mast where id ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.GetresultS("Select EMPSAL from tbl_Employee_Mast where id ='" + emply_id + "'");
                                }
                                else
                                {
                                    lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                                }

                                //lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //if (lum_amt == null || lum_amt == "")
                                //    lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";

                                if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                    lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * Month_Day);

                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                }

                                //}
                                //else
                                //{
                                //    EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //    if (Convert.ToString(EmploySalary_Details.Rows[cou][i + dt_cou]) == "")
                                //        EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //    if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + dt_cou]) == true)
                                //        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + 7])));
                                //}
                            }
                            else
                            {
                                //EmploySalary_Details.Rows[cou][i + 6] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " ");

                                //testless

                                EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                if (Convert.ToString(EmploySalary_Details.Rows[cou][i + dt_cou]) == "")
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + dt_cou]) == true)
                                {
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou])));
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou])));
                                }
                            }
                    }
                    else if (dt.Rows[i][13].ToString().Trim() == "Conditional")
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            _empsal = "select EMPSAL from tbl_Employee_Mast where id='" + emply_id + "' ";
                            DataTable dt_empsal = new DataTable();
                            dt_empsal = clsDataAccess.RunQDTbl(_empsal);

                            string lum_amt = "";
                            double esi_amt = 0;

                            lum_amt = cal_formula(Convert.ToInt32(dt.Rows[i][3]));
                            if (Convert.ToDecimal(EmploySalary_Details.Rows[cou]["Salary"]) == Convert.ToDecimal(0))
                            {
                                lum_amt = "0";
                            }
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                int Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    double _sal_amt = (Convert.ToDouble(dt_empsal.Rows[0][0]) * Convert.ToDouble(atten)) / Month_Day;
                                    double amt = _sal_amt - (Convert.ToDouble(lum_amt));
                                    esi_amt = Convert.ToDouble(amt);
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));

                                    //double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    //double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    //EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    lum_amt = amt.ToString();
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                }
                            }

                            if (Information.IsNumeric(lum_amt) == true)
                            {
                                EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                            }


                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                            //if (i == 0)
                            //{
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                int Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }

                                string lum_amt = "";

                                //testless
                                _empbasic = "select EMP_BASIC from tbl_Employee_Assign_SalStructure where sal_struct=" + salary_structure + " and p_type='E' and sal_head=" + dt.Rows[i]["sal_head"] + "";
                                DataTable dt1 = new DataTable();
                                dt1 = clsDataAccess.RunQDTbl(_empbasic);

                                if (dt1.Rows[0][0].ToString().Trim() == "1")
                                {
                                    lum_amt = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "2")
                                {
                                    lum_amt = clsDataAccess.GetresultS("Select EMPSAL - empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.GetresultS("Select EMPSAL - empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "3")
                                {
                                    lum_amt = clsDataAccess.GetresultS("Select EMPSAL from tbl_Employee_Mast where id ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.GetresultS("Select EMPSAL from tbl_Employee_Mast where id ='" + emply_id + "'");
                                }
                                else
                                {
                                    lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                                }

                                //lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //if (lum_amt == null || lum_amt == "")
                                //    lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";

                                if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                {
                                    lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * Month_Day);
                                }

                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                }

                                //}
                                //else
                                //{
                                //    EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //    if (Convert.ToString(EmploySalary_Details.Rows[cou][i + dt_cou]) == "")
                                //        EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //    if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + dt_cou]) == true)
                                //        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + 7])));
                                //}
                            }
                            else
                            {
                                //EmploySalary_Details.Rows[cou][i + 6] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " ");

                                //testless

                                EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                if (Convert.ToString(EmploySalary_Details.Rows[cou][i + dt_cou]) == "")
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + dt_cou]) == true)
                                {
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou])));
                                    txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou])));
                                }
                            }
                    }
                    else
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            _empsal = "select EMPSAL from tbl_Employee_Mast where id='" + emply_id + "' ";
                            DataTable dt_empsal = new DataTable();
                            dt_empsal = clsDataAccess.RunQDTbl(_empsal);

                            string lum_amt = "";
                            double esi_amt = 0;
                            lum_amt = cal_formula(Convert.ToInt32(dt.Rows[i][3]));

                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                int Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    double _sal_amt = (Convert.ToDouble(dt_empsal.Rows[0][0]) * Convert.ToDouble(atten)) / Month_Day;
                                    double amt = _sal_amt - (Convert.ToDouble(lum_amt));
                                    esi_amt = Convert.ToDouble(amt);
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                                }
                            }

                            if (Information.IsNumeric(lum_amt) == true)
                            {
                                EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(esi_amt)));
                                txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(esi_amt)));
                            }
                        }
                        //else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                        //    //if (i == 0)
                        //    //{
                        //    if (Information.IsNumeric(txtattendence.Text) == true)
                        //    {
                        //        //int Cur_Month = dateTimePicker1.Value.Month;
                        //        int Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                        //        string lum_amt = "";

                        //        //testless
                        //        _empbasic = "select EMP_BASIC from tbl_Employee_Assign_SalStructure where sal_struct=" + salary_structure + " and p_type='E' and sal_head=" + dt.Rows[i]["sal_head"] + "";
                        //        DataTable dt1 = new DataTable();
                        //        dt1 = clsDataAccess.RunQDTbl(_empbasic);

                        //        if (dt1.Rows[0][0].ToString().Trim() == "1")
                        //        {
                        //            lum_amt = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                        //            if (lum_amt == null || lum_amt == "")
                        //                lum_amt = clsDataAccess.GetresultS("Select empbasic from tbl_Employee_Mast where id ='" + emply_id + "'");
                        //        }
                        //        else
                        //        {
                        //            lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                        //            if (lum_amt == null || lum_amt == "")
                        //                lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                        //        }

                        //        //lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                        //        //if (lum_amt == null || lum_amt == "")
                        //        //    lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                        //        //testless

                        //        if (Information.IsNumeric(lum_amt) == false)
                        //            lum_amt = "0";

                        //        if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                        //            lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * Month_Day);

                        //        if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                        //        {
                        //            double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                        //            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                        //            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                        //        }
                        //        else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                        //        {
                        //            double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                        //            double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                        //            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                        //            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                        //        }
                        //        else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                        //        {
                        //            double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                        //            double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                        //            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(amt));
                        //            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                        //        }
                        //        else
                        //        {
                        //            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                        //            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                        //        }

                        //        //}
                        //        //else
                        //        //{
                        //        //    EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                        //        //    if (Convert.ToString(EmploySalary_Details.Rows[cou][i + dt_cou]) == "")
                        //        //        EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                        //        //    if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + dt_cou]) == true)
                        //        //        EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + 7])));
                        //        //}
                        //    }
                        //    else
                        //    {
                        //        //EmploySalary_Details.Rows[cou][i + 6] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " ");

                        //        //testless

                        //        EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                        //        if (Convert.ToString(EmploySalary_Details.Rows[cou][i + dt_cou]) == "")
                        //            EmploySalary_Details.Rows[cou][i + dt_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                        //        //testless

                        //        if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + dt_cou]) == true)
                        //        {
                        //            EmploySalary_Details.Rows[cou][i + dt_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou])));
                        //            txte[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou])));
                        //        }
                        //    }
                    }


                    if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + dt_cou]) == true)
                    {
                        if (dt.Rows[i][15].ToString().Trim() == "0")
                        {
                            earning_amt = earning_amt + Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou]);
                            arr[i + dt_cou] = Convert.ToDouble(arr[i + dt_cou]) + Convert.ToDouble(EmploySalary_Details.Rows[cou][i + dt_cou]);
                        }
                        else
                        {
                            earning_amt = earning_amt + 0;
                            arr[i + dt_cou] = Convert.ToDouble(arr[i + dt_cou]) + 0;

                        }
                    }
                }
            }
            if (dtround.Rows.Count > 0)
            {
                earning_amt = Math.Round(earning_amt, MidpointRounding.AwayFromZero);
                EmploySalary_Details.Rows[cou]["Total_Earning"] = string.Format("{0:F}", earning_amt);
            }
            else
            {
                EmploySalary_Details.Rows[cou]["Total_Earning"] = string.Format("{0:F}", earning_amt);
            }
            arr[dt.Rows.Count + dt_cou] = Convert.ToDouble(arr[dt.Rows.Count + dt_cou]) + earning_amt;
                
        }

        public void emp_deduction(int col_cou)
        {
            string s = "", val_pf_bs = "", val_esi_bs = ""; int j = 1; int lbl = 6, lbl1 = 6, jt = 0, cou = 0;
            int indx = 0;
            double deduction_amt = 0;
            Boolean boolDedcHeadExists = false;
            //s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE from tbl_Employee_Assign_SalStructure where session='" + cmbYear.Text.Trim() + "' and sal_struct=" + salary_structure + " and p_type='D'";
            //  s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE,atten_day,Proxy_day,Revenue_Stamp,Stamp_Amount,C_BASIS,chkALK,chkHide,mod,wd,pt_basis,[no_round],[limit_day],[ldays],[alt_mon] from tbl_Employee_Assign_SalStructure where  sal_struct=" + salary_structure + " and p_type='D'";
            s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE,atten_day,Proxy_day,Revenue_Stamp,Stamp_Amount,Daily_wages,C_BASIS,chkAlK,chkHide,mod,wd,pt_basis,[no_round],[limit_day],[ldays],[alt_mon],[chkFlag] from tbl_Employee_Assign_SalStructure where sal_struct=" + salary_structure + " and p_type='D'  and (chkHide not in('3','31')) ";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            indx = dgPfEsi.Rows.Add();

            dgPfEsi.Rows[indx].Cells["pf_bs"].Value = 0;
            dgPfEsi.Rows[indx].Cells["pf_contribution"].Value = 0;
            dgPfEsi.Rows[indx].Cells["col_desgid"].Value = 0;
            dgPfEsi.Rows[indx].Cells["col_pf"].Value = 0;

            dgPfEsi.Rows[indx].Cells["esi_bs"].Value = 0;
            dgPfEsi.Rows[indx].Cells["esi_contribution"].Value = 0;
            dgPfEsi.Rows[indx].Cells["col_esi"].Value = 0;


            dgPfEsi.Rows[indx].Cells["col_OT_act"].Value = OT_Act;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                boolDedcHeadExists = true;
                if (i == 0)
                {
                    cou = EmploySalary_Details.Rows.Count - 1;
                    dgPfEsi.Rows[indx].Cells["eid"].Value = EmploySalary_Details.Rows[cou]["ID"].ToString();
                }
                dgPfEsi.Rows[indx].Cells["col_desgid"].Value = EmploySalary_Details.Rows[cou]["DesgID"].ToString().Trim();

                //if (dt.Rows[i][1].ToString().Trim() == "D" && dateTimePicker1.Value.Month >= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][4].ToString()) && dateTimePicker1.Value.Month <= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][5].ToString()))

                if (dt.Rows[i][1].ToString().Trim() == "D")
                {
                    if (dt.Rows[i]["C_BASIS"].ToString().Trim() == "Independent") //Residual Consolidated
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            double pf1 = besc_PF_Amt;
                            //double pf = 0;
                            //if (Convert.ToString(dt.Rows[i]["PF_PER"]) == "1")
                            //    pf = Math.Round(besc_PF_Amt);
                            //EmploySalary_Details.Rows[cou][i + col_cou] = cal_formula(Convert.ToInt32(dt.Rows[i][3]));

                            val_pf_bs = cal_formula_pfesi(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(EmploySalary_Details.Rows[cou]["DesgID"]));

                            if ((Convert.ToDouble(val_pf_bs) > Convert.ToDouble(lblpf_limit.Text)) && (Convert.ToDouble(lblpf_limit.Text) != 0))
                            {
                                val_pf_bs = Convert.ToDouble(lblpf_limit.Text).ToString("0.00");
                            }
                            string lum_amt = "", bs_amt = "";
                            lum_amt = cal_formula_desg(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(EmploySalary_Details.Rows[cou]["DesgID"]));
                            //cal_formula(Convert.ToInt32(dt.Rows[i][3]));
                            try
                            {
                                if ((dt.Rows[i]["chkFLag"].ToString().Trim() == "1") && (Convert.ToDouble(lum_amt) > 0))
                                {
                                    lum_amt = "0";
                                }
                            }
                            catch { lum_amt = "0"; }

                            if (dt.Rows[i]["PF_PER"].ToString() == "1")
                            {
                                string[] pfpr = (lbl_Pf_formula.Text.Split('*'));
                                pfpr = pfpr[1].Split('/');

                                lum_amt = get_pf_val(val_pf_bs, Convert.ToDouble(pfpr[0]));

                                if (lbl_limit_gross.Text != "0" && lbl_limit_gross.Text.Trim() != "")
                                {
                                    if (Convert.ToDouble(EmploySalary_Details.Rows[cou]["Total_Earning"]) < Convert.ToDouble(lbl_limit_gross.Text))
                                    {
                                        lum_amt = "0";
                                    }
                                }
                            }
                            if (Convert.ToDecimal(EmploySalary_Details.Rows[cou]["Salary"]) == Convert.ToDecimal(0))
                            {
                                lum_amt = "0";
                            }
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                int Cur_Month = AttenDtTmPkr.Value.Month;
                                double Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                if (Convert.ToString(dt.Rows[i]["mod"]) != "0")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    int intMOD = 0;
                                    string modVal = dt.Rows[i]["mod"].ToString().ToUpper();
                                    if (modVal == "MONTHOFDAYS")
                                    {
                                        try
                                        {
                                            int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                                            intMOD = NumberOfDays;
                                            if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value))
                                            {
                                                atten = intMOD;
                                            }
                                        }
                                        catch { }
                                    }
                                    else if (modVal == "MOD-SUNDAYS")
                                    {
                                        try
                                        {
                                            int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value);
                                            intMOD = NumberOfDays;
                                        }
                                        catch { }
                                    }
                                    else if (modVal.Contains("RANGE-SUNDAYS"))
                                    {
                                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                        int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), true);
                                        intMOD = NumberOfDays;

                                        //tbTo.Text = strFromTo[1];
                                    }
                                    else if (modVal.Contains("RANGE"))
                                    {
                                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                        int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), false);
                                        intMOD = NumberOfDays;
                                        if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1])))
                                        {
                                            atten = intMOD;
                                        }
                                        //tbTo.Text = strFromTo[1];
                                    }
                                    else
                                    {
                                        intMOD = Convert.ToInt32(dt.Rows[i]["mod"]);
                                    }

                                    Month_Day = intMOD;
                                }

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";

                                int idx = 0;
                                if ((dt.Rows[i]["alt_mon"].ToString().Trim() == "1") && (dt.Rows[i]["pt"].ToString().Trim() == "0"))
                                {
                                    string[] month = dt.Rows[i]["pt_basis"].ToString().Split(',');
                                    string mon;
                                    idx = 1;
                                    for (int ind = 0; ind < month.Length; ind++)
                                    {
                                        mon = (1 + "/" + month[ind].ToString().Substring(0, 3).ToUpper().Trim() + "/" + AttenDtTmPkr.Value.Year.ToString()).ToString();
                                        if (Convert.ToDateTime(mon).ToString("MMM/yyyy") == Convert.ToDateTime("01/" + AttenDtTmPkr.Value.ToString("MMM/yyyy")).ToString("MMM/yyyy"))
                                        {
                                            idx = 2;
                                        }


                                    }

                                }
                                if (idx == 1)
                                {
                                    lum_amt = "0";
                                }


                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);

                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                //if ( EmploySalary_Details.Rows[cou][2].ToString() == "12450")
                                //{

                                //}
                                /*else if (Convert.ToString(dt.Rows[i]["mod"]) != "0")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    int intMOD = 0;
                                    string modVal = dt.Rows[i]["mod"].ToString().ToUpper();
                                    if (modVal == "MONTHOFDAYS")
                                    {
                                        try
                                        {
                                            int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                                            intMOD = NumberOfDays;
                                            if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value))
                                            {
                                                atten = intMOD;
                                            }
                                        }
                                        catch { }
                                    }
                                    else if (modVal == "MOD-SUNDAYS")
                                    {
                                        try
                                        {
                                            int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value);
                                            intMOD = NumberOfDays;
                                        }
                                        catch { }
                                    }
                                    else if (modVal.Contains("RANGE-SUNDAYS"))
                                    {
                                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                        int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), true);
                                        intMOD = NumberOfDays;

                                        //tbTo.Text = strFromTo[1];
                                    }
                                    else if (modVal.Contains("RANGE"))
                                    {
                                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                        int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), false);
                                        intMOD = NumberOfDays;
                                        if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1])))
                                        {
                                            atten = intMOD;
                                        }
                                        //tbTo.Text = strFromTo[1];
                                    }
                                    else
                                    {
                                        intMOD = Convert.ToInt32(dt.Rows[i]["mod"]);
                                    }

                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / intMOD;
                                    lum_amt = amt.ToString();
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));

                                }*/
                                if (Information.IsNumeric(lum_amt) == true)
                                {
                                    if (Convert.ToString(dt.Rows[i]["ESI_PER"]) == "1")
                                    {
                                        if (lbl_limit_gross_esi.Text != "0" || lbl_limit_gross_esi.Text.Trim() != "")
                                        {
                                            if (Convert.ToDouble(EmploySalary_Details.Rows[cou]["Total_Earning"]) < Convert.ToDouble(lbl_limit_gross_esi.Text))
                                            {
                                                lum_amt = "0";
                                            }
                                        }
                                        EmploySalary_Details.Rows[cou][i + col_cou] = Convert.ToDouble(lum_amt);

                                    }
                                    else
                                        EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                    txtd[i].Text = string.Format("{0:F}", lum_amt);
                                }
                            }
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                        {
                            if (Convert.ToString(dt.Rows[i]["PT"]) == "1")
                            {
                                string ptax_amt = "";
                                string gender = clsDataAccess.GetresultS("select (case when ltrim(rtrim(Gender))='' then 'MALE' else Gender end ) FROM tbl_Employee_Mast where ID='" + EmploySalary_Details.Rows[cou]["ID"] + "'").ToUpper();
                                string estate = "";
                                string pt_basis = dt.Rows[i]["pt_basis"].ToString().ToLower();
                                string[] pt_bs;
                                double bs_pt = 0;

                                if (pt_basis == "gross")
                                {
                                    bs_pt = Convert.ToDouble(EmploySalary_Details.Rows[cou]["Total_Earning"]);
                                }
                                else
                                {
                                    pt_bs = dt.Rows[i]["pt_basis"].ToString().Split('+');

                                    for (int idx = 0; idx < pt_bs.Length; idx++)
                                    {
                                        bs_pt = bs_pt + Convert.ToDouble(EmploySalary_Details.Rows[cou][pt_bs[idx].ToString()]);
                                    }


                                }


                                if (AttenDtTmPkr.Value.ToString("MMM").ToUpper() == "FEB")
                                {
                                    ptax_amt = clsDataAccess.GetresultS("Select top 1 (case when alt_pt>0 then alt_pt else pt end) pt from tbl_Employee_PTRate where (wfrom <=" + bs_pt + " and wto >=" + bs_pt + ") and (lower(estate)='" + ptstate.ToLower() + "') and (upper(gender) in ('" + gender + "','ALL')) and (cast(convert(datetime,edate,103) as datetime)<=cast(convert(datetime,'01/" + AttenDtTmPkr.Value.ToString("MMM/yyy") + "',103) as datetime)) order by Slno");
                                }
                                else
                                {
                                    ptax_amt = clsDataAccess.GetresultS("Select top 1 pt from tbl_Employee_PTRate where (wfrom <=" + bs_pt + " and wto >=" + bs_pt + ") and (lower(estate)='" + ptstate.ToLower() + "') and (upper(gender) in ('" + gender + "','ALL')) and (cast(convert(datetime,edate,103) as datetime)<=cast(convert(datetime,'01/" + AttenDtTmPkr.Value.ToString("MMM/yyy") + "',103) as datetime)) order by Slno");
                                }

                                //string ptax_amt = clsDataAccess.GetresultS("Select pt from tbl_Employee_PTRate where wfrom <=" + EmploySalary_Details.Rows[cou]["Total_Earning"] + " and wto >=" + EmploySalary_Details.Rows[cou]["Total_Earning"] + " ");
                                if (Information.IsNumeric(ptax_amt) == true)
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", ptax_amt);
                                else
                                    EmploySalary_Details.Rows[cou][i + col_cou] = "0.00";
                                txtd[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou])));
                            }
                            else if (Convert.ToString(dt.Rows[i]["chkALK"]) == "1") // advance
                            {

                                string loan_amt = clsDataAccess.GetresultS("Select isNull(SUM(isnull(EAAMT,0)) - SUM(isnull(EADEDUCT,0)),0) from tbl_Employee_Advance where (EAEID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and (cast('28/'+ EAMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date))");// and (EAEID Not IN (" + eid_adv + "))");
                                //" and [EAID]=(select max([EAID]) from tbl_Employee_Advance where (EAEID='" + EmploySalary_Details.Rows[cou]["ID"] + "')) and ([EAAMT]-[EADEDUCT])>0 and ((DATENAME(mm, EADEDUCTDT))+' - '+(DATENAME(YYYY, EADEDUCTDT))!='10/2018')");
                                // if (Information.IsNumeric(loan_amt) == true)
                                if ((loan_amt != null) && (Information.IsNumeric(loan_amt) == true) && Convert.ToDouble(loan_amt) > 0)
                                {
                                    int rw_alfk = 0;
                                    bool bl = false;
                                    DataTable dtadv = clsDataAccess.RunQDTbl("Select  eaid,EAEID,EANAME,(EAAMT-recover)EAAMT from " +
                                   "(select *,isNull((select SUM(ramt) from tbl_recovery where transid=ea.eaid and eid=ea.EAEID and type='Advance'),0)[recover]  from tbl_Employee_Advance ea) ea where (EAEID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and (cast('28/'+ EAMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date)) and (EAAMT>EADEDUCT) and (EAAMT>[recover])");

                                    try
                                    {
                                        for (rw_alfk = 0; rw_alfk < dgvRecoveries.Rows.Count; rw_alfk++)
                                        {
                                            if ((dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value.ToString().ToLower() == EmploySalary_Details.Rows[cou]["ID"].ToString().Trim().ToLower()) && (dgvRecoveries.Rows[rw_alfk].Cells["type"].Value.ToString().Trim().ToLower() == "advance"))
                                            {
                                                bl = true;
                                                loan_amt = "0";
                                            }
                                        }
                                    }
                                    catch { }

                                    //(EAID not in (select transid FROM tbl_recovery where (eid='" + EmploySalary_Details.Rows[cou]["ID"] + "') and (type='Advance')))");
                                    if (dtadv.Rows.Count > 0 && bl == false)
                                    {
                                        rw_alfk = 0;
                                        for (int idx = 0; idx < dtadv.Rows.Count; idx++)
                                        {
                                            rw_alfk = dgvRecoveries.Rows.Add();
                                            dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = dtadv.Rows[idx]["eaid"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = dtadv.Rows[idx]["EAEID"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = EmploySalary_Details.Rows[cou]["desgID"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["ename"].Value = dtadv.Rows[idx]["EANAME"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = dtadv.Rows[idx]["EAAMT"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = "Advance";
                                        }
                                    }
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", loan_amt);
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][i + col_cou] = "0.00";
                                }
                                //else
                                //    EmploySalary_Details.Rows[cou][i + col_cou] = "0.00";
                                txtd[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou])));

                                if (eid_adv.Trim() == "")
                                {
                                    eid_adv = "'" + EmploySalary_Details.Rows[cou]["ID"].ToString().Trim() + "'";
                                }
                                else
                                {
                                    eid_adv = eid_adv + ",'" + EmploySalary_Details.Rows[cou]["ID"].ToString().Trim() + "'";
                                }
                            }
                            else if (Convert.ToString(dt.Rows[i]["chkALK"]) == "2") // loan
                            {
                                int rw_alfk = 0;
                                bool bl = false;
                                string loan_amt = clsDataAccess.GetresultS("Select sum(ELEMI) from tbl_Employee_LOAN where (ELEID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and [ELID] in (select ([ELID]) from tbl_Employee_LOAN where (ELEID='" + EmploySalary_Details.Rows[cou]["ID"] + "')) and ([ELAMT]-[ELDEDUCT])>0 and (cast('28/'+ ELMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date))");
                                string deduct_amt = clsDataAccess.GetresultS("Select isNull(sum([ELAMT]-[ELDEDUCT]),0)as lded from tbl_Employee_LOAN where (ELEID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and [ELID] in (select ([ELID]) from tbl_Employee_LOAN where (ELEID='" + EmploySalary_Details.Rows[cou]["ID"] + "')) and ([ELAMT]-[ELDEDUCT])>0 and (cast('28/'+ ELMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date))");
                                if (deduct_amt == null || deduct_amt == "")
                                {
                                    deduct_amt = "0";
                                }
                                if (loan_amt == null || loan_amt == "")
                                {
                                    loan_amt = "0";
                                }
                                if (Convert.ToDouble(deduct_amt) < Convert.ToDouble(loan_amt))
                                {

                                    loan_amt = deduct_amt;
                                }



                                loan_amt = clsDataAccess.GetresultS("Select SUM(case when (ELEMI)< (ELAMT-ELDEDUCT) then (ELEMI) else (ELAMT-ELDEDUCT) end ) as lded from tbl_Employee_LOAN where (ELEID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and [ELID] in (select ([ELID]) from tbl_Employee_LOAN where (ELEID='" + EmploySalary_Details.Rows[cou]["ID"] + "')) and ([ELAMT]-[ELDEDUCT])>0 and (cast('28/'+ ELMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date))");


                                try
                                {
                                    for (rw_alfk = 0; rw_alfk < dgvRecoveries.Rows.Count; rw_alfk++)
                                    {
                                        if ((dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value.ToString().ToLower().Trim() == EmploySalary_Details.Rows[cou]["ID"].ToString().ToLower().Trim()) && (dgvRecoveries.Rows[rw_alfk].Cells["type"].Value.ToString().Trim().ToLower() == "loan"))
                                        {
                                            bl = true;
                                            loan_amt = "0";
                                        }
                                    }
                                }
                                catch { }
                                if (Information.IsNumeric(loan_amt) == true && bl == false)
                                {
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", loan_amt);
                                    try
                                    {
                                        if (Convert.ToDouble(loan_amt) > 0)
                                        {
                                            rw_alfk = 0;
                                            DataTable dtadv = clsDataAccess.RunQDTbl("Select  ELID, ELEID, ELNAME,(case when ELEMI< (ELAMT-ELDEDUCT) then ELEMI else (ELAMT-ELDEDUCT) end ) ELEMI  from tbl_Employee_LOAN where (ELEID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and (cast('28/'+ ELMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date)) and (ELAMT>ELDEDUCT)");
                                            if (dtadv.Rows.Count > 0)
                                            {
                                                for (int idx = 0; idx < dtadv.Rows.Count; idx++)
                                                {
                                                    rw_alfk = dgvRecoveries.Rows.Add();
                                                    dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = dtadv.Rows[idx]["ELID"].ToString().Trim();
                                                    dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = dtadv.Rows[idx]["ELEID"].ToString().Trim();
                                                    dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = EmploySalary_Details.Rows[cou]["desgID"].ToString().Trim();
                                                    dgvRecoveries.Rows[rw_alfk].Cells["ename"].Value = dtadv.Rows[idx]["ELNAME"].ToString().Trim();
                                                    dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = dtadv.Rows[idx]["ELEMI"].ToString().Trim();
                                                    dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = "Loan";
                                                }
                                            }

                                        }
                                    }
                                    catch { }
                                }
                                else
                                    EmploySalary_Details.Rows[cou][i + col_cou] = "0.00";


                                txtd[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou])));
                            }
                            else if (Convert.ToString(dt.Rows[i]["chkALK"]) == "3") // kit
                            {

                                int rw_alfk = 0;
                                bool bl = false;

                                string loan_amt = clsDataAccess.GetresultS("Select isNull(sum(EKEMI),0) from tbl_Employee_KIT where (EKEID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and [EKID] in (select ([EKID]) from tbl_Employee_KIT where (EKEID='" + EmploySalary_Details.Rows[cou]["ID"] + "')) and ([EKAMT]-[EKDEDUCT])>0 and (cast('28/'+ EKMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date))");
                                string deduct_amt = clsDataAccess.GetresultS("Select isNull(sum([EKAMT]-[EKDEDUCT]),0) from tbl_Employee_KIT where (EKEID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and [EKID] in (select ([EKID]) from tbl_Employee_KIT where (EKEID='" + EmploySalary_Details.Rows[cou]["ID"] + "')) and ([EKAMT]-[EKDEDUCT])>0  and ((DATENAME(mm, EKDEDUCTDT))+' - '+(DATENAME(YYYY, EKDEDUCTDT))!='" + AttenDtTmPkr.Text + "') and (cast('28/'+ EKMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date))");
                                if (Convert.ToDouble(deduct_amt) < Convert.ToDouble(loan_amt))
                                {

                                    loan_amt = deduct_amt;
                                }

                                loan_amt = clsDataAccess.GetresultS("Select sum(case when (EKEMI)< [EKAMT]-[EKDEDUCT] then (EKEMI) else (EKAMT-EKDEDUCT) end )as kval from tbl_Employee_KIT where (EKEID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and [EKID] in (select ([EKID]) from tbl_Employee_KIT where (EKEID='" + EmploySalary_Details.Rows[cou]["ID"] + "')) and ([EKAMT]-[EKDEDUCT])>0  and ((DATENAME(mm, EKDEDUCTDT))+' - '+(DATENAME(YYYY, EKDEDUCTDT))!='" + AttenDtTmPkr.Text + "') and (cast('28/'+ EKMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date))");

                                try
                                {
                                    for (rw_alfk = 0; rw_alfk < dgvRecoveries.Rows.Count; rw_alfk++)
                                    {
                                        if ((dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value.ToString().ToLower().Trim() == EmploySalary_Details.Rows[cou]["ID"].ToString().ToLower().Trim()) && (dgvRecoveries.Rows[rw_alfk].Cells["type"].Value.ToString().Trim().ToLower() == "kit"))
                                        {
                                            bl = true;
                                            loan_amt = "0";
                                        }
                                    }
                                }
                                catch { }
                                if (Information.IsNumeric(loan_amt) == true && bl == false)
                                {
                                    rw_alfk = 0;
                                    DataTable dtadv = clsDataAccess.RunQDTbl("Select EKID,EKEID,EKNAME,(case when (EKEMI)< [EKAMT]-[EKDEDUCT] then (EKEMI) else (EKAMT-EKDEDUCT) end )EKEMI from tbl_Employee_KIT where (EKEID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and [EKID] in (select ([EKID]) from tbl_Employee_KIT where (EKEID='" + EmploySalary_Details.Rows[cou]["ID"] + "')) and ([EKAMT]-[EKDEDUCT])>0 and (cast('28/'+ EKMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date))");
                                    if (dtadv.Rows.Count > 0)
                                    {
                                        for (int idx = 0; idx < dtadv.Rows.Count; idx++)
                                        {
                                            rw_alfk = dgvRecoveries.Rows.Add();
                                            dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = dtadv.Rows[idx]["EKID"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = dtadv.Rows[idx]["EKEID"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = EmploySalary_Details.Rows[cou]["desgID"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["ename"].Value = dtadv.Rows[idx]["EKNAME"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = dtadv.Rows[idx]["EKEMI"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = "Kit";
                                        }
                                    }

                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", loan_amt);
                                }
                                else
                                    EmploySalary_Details.Rows[cou][i + col_cou] = "0.00";

                                txtd[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou])));
                            }
                            else if (Convert.ToString(dt.Rows[i]["chkALK"]) == "4") // fine
                            {
                                int rw_alfk = 0;
                                bool bl = false;

                                string loan_amt = clsDataAccess.GetresultS("Select isNull(sum(FEmi),0) from tbl_fine_log where (eid='" + EmploySalary_Details.Rows[cou]["ID"] + "') and (cast('28/'+ FMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date))");
                                // and [FLID]=(select max([FLID]) from tbl_fine_log where (eid='" + EmploySalary_Details.Rows[cou]["ID"] + "') and ([FAMT]-[FDEDUCT])>0) ");
                                string deduct_amt = clsDataAccess.GetresultS("Select isNull(sum([FAMT])-sum([FDEDUCT]),0)fa  from tbl_fine_log where (eid='" + EmploySalary_Details.Rows[cou]["ID"] + "') and (cast('28/'+ FMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date))");
                                //and [FLID]=(select max([FLID]) from tbl_fine_log where (eid='" + EmploySalary_Details.Rows[cou]["ID"] + "') and ([FAMT]-[FDEDUCT])>0) ");
                                if (Convert.ToDouble(deduct_amt) < Convert.ToDouble(loan_amt))
                                {
                                    loan_amt = deduct_amt;
                                }
                                try
                                {
                                    for (rw_alfk = 0; rw_alfk < dgvRecoveries.Rows.Count; rw_alfk++)
                                    {
                                        if ((dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value.ToString().ToLower().Trim() == EmploySalary_Details.Rows[cou]["ID"].ToString().ToLower().Trim()) && (dgvRecoveries.Rows[rw_alfk].Cells["type"].Value.ToString().Trim().ToLower() == "fine"))
                                        {
                                            bl = true;
                                            loan_amt = "0";
                                        }
                                    }
                                }
                                catch { }
                                if (Information.IsNumeric(loan_amt) == true && bl == false)
                                {
                                    rw_alfk = 0;
                                    DataTable dtadv = clsDataAccess.RunQDTbl("Select FLID,EID,FEMI," +
          "(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) FROM tbl_Employee_Mast em WHERE (ID = f.EID)) AS EFName from tbl_fine_log f " +
          "where (EID='" + EmploySalary_Details.Rows[cou]["ID"] + "') and [FID] in (select ([FID]) from tbl_fine_log where (EID='" + EmploySalary_Details.Rows[cou]["ID"] + "')) and ([FAMT]-[FDEDUCT])>0 and (cast('28/'+ FMONTH as date) <= cast('28/" + AttenDtTmPkr.Value.ToString("MMM/yyyy") + "' as date))");
                                    if (dtadv.Rows.Count > 0)
                                    {
                                        for (int idx = 0; idx < dtadv.Rows.Count; idx++)
                                        {
                                            rw_alfk = dgvRecoveries.Rows.Add();
                                            dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = dtadv.Rows[idx]["FLID"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = dtadv.Rows[idx]["EID"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = EmploySalary_Details.Rows[cou]["desgID"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["ename"].Value = dtadv.Rows[idx]["EFNAME"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = dtadv.Rows[idx]["FEMI"].ToString().Trim();
                                            dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = "Fine";
                                        }
                                    }

                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", loan_amt);
                                }
                                else
                                    EmploySalary_Details.Rows[cou][i + col_cou] = "0.00";


                                txtd[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou])));
                            }
                            else
                            {
                                double Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                string lum_amt = "";

                                if (Convert.ToString(dt.Rows[i]["mod"]) != "0")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    int intMOD = 0;
                                    string modVal = dt.Rows[i]["mod"].ToString().ToUpper();
                                    if (modVal == "MONTHOFDAYS")
                                    {
                                        try
                                        {
                                            int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                                            intMOD = NumberOfDays;
                                            if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value))
                                            {
                                                atten = intMOD;
                                            }
                                        }
                                        catch { }
                                    }
                                    else if (modVal == "MOD-SUNDAYS")
                                    {
                                        try
                                        {
                                            int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value);
                                            intMOD = NumberOfDays;
                                        }
                                        catch { }
                                    }
                                    else if (modVal.Contains("RANGE-SUNDAYS"))
                                    {
                                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                        int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), true);
                                        intMOD = NumberOfDays;

                                        //tbTo.Text = strFromTo[1];
                                    }
                                    else if (modVal.Contains("RANGE"))
                                    {
                                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                        int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), false);
                                        intMOD = NumberOfDays;
                                        if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1])))
                                        {
                                            atten = intMOD;
                                        }
                                        //tbTo.Text = strFromTo[1];
                                    }
                                    else
                                    {
                                        intMOD = Convert.ToInt32(dt.Rows[i]["mod"]);
                                    }

                                    Month_Day = intMOD;
                                }
                                if (clsDataAccess.ReturnValue("select eas.EMP_BASIC from tbl_Employee_Assign_SalStructure eas where (sal_struct=" + salary_structure + ") and (p_type='D') and (sal_head=" + dt.Rows[i]["sal_head"] + ")") == "5")
                                {
                                    try
                                    {
                                        lum_amt = clsDataAccess.ReturnValue("SELECT top 1 value FROM tbl_other_deduction where (ecode='" +
                      EmploySalary_Details.Rows[cou]["ID"] + "') and (cast('28-'+ MONTH as date)<=cast('28-" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") +
                      "' as date)) and (head=(select SalaryHead_Short from tbl_Employee_DeductionSalayHead where SlNo='" + dt.Rows[i]["sal_head"].ToString() +
                      "')) and (locid='" + Locations.Trim() + "') and (coid='" + company_Id + "') and (type='I')  order by cast('28-'+ MONTH as date) desc");
                                    }
                                    catch { }
                                }
                                else
                                {

                                    lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                                }
                                //EmploySalary_Details.Rows[cou][i + col_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //if (Convert.ToString(EmploySalary_Details.Rows[cou][i + col_cou]) == "")
                                //    EmploySalary_Details.Rows[cou][i + col_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";

                                int idx = 0;
                                if ((dt.Rows[i]["alt_mon"].ToString().Trim() == "1") && (dt.Rows[i]["pt"].ToString().Trim() == "0"))
                                {
                                    string[] month = dt.Rows[i]["pt_basis"].ToString().Split(',');
                                    string mon;
                                    idx = 1;
                                    for (int ind = 0; ind < month.Length; ind++)
                                    {
                                        mon = (1 + "/" + month[ind].ToString().Substring(0, 3).ToUpper().Trim() + "/" + AttenDtTmPkr.Value.Year.ToString()).ToString();
                                        if (Convert.ToDateTime(mon).ToString("MMM/yyyy") == Convert.ToDateTime("01/" + AttenDtTmPkr.Value.ToString("MMM/yyyy")).ToString("MMM/yyyy"))
                                        {
                                            idx = 2;
                                        }


                                    }

                                }
                                if (idx == 1)
                                {
                                    lum_amt = "0";
                                }


                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }

                                    /* Wday - 1
                                          OT - 11
                                          TDays - 12
                                          ED - 13 */
                                else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1") //Wday - 1
                                {
                                    double atten = 0, amt = 0;
                                    try
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    }
                                    catch { atten = 0; }
                                    amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten));
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "12") // TDays - 12
                                {
                                    double atten = 0, amt = 0;
                                    try
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["Tot_Day"]);
                                    }
                                    catch { atten = 0; }
                                    amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten));

                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "11") // OT - 11
                                {

                                    double atten = 0, amt = 0;
                                    try
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                    }
                                    catch { atten = 0; }
                                    amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten));

                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "13") // ED - 13
                                {
                                    double atten = 0, amt = 0;
                                    try
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["E_D"]);
                                    }
                                    catch { atten = 0; }
                                    amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten));
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));

                                }
                                /*else if (Convert.ToString(dt.Rows[i]["mod"]) != "0")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    int intMOD = 0;
                                    string modVal = dt.Rows[i]["mod"].ToString().ToUpper();
                                    if (modVal == "MONTHOFDAYS")
                                    {
                                        try
                                        {
                                            int NumberOfDays = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);
                                            intMOD = NumberOfDays;
                                            if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value))
                                            {
                                                atten = intMOD;
                                            }
                                        }
                                        catch { }
                                    }
                                    else if (modVal == "MOD-SUNDAYS")
                                    {
                                        try
                                        {
                                            int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value);
                                            intMOD = NumberOfDays;
                                        }
                                        catch { }
                                    }
                                    else if (modVal.Contains("RANGE-SUNDAYS"))
                                    {
                                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                        int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), true);
                                        intMOD = NumberOfDays;

                                        //tbTo.Text = strFromTo[1];
                                    }
                                    else if (modVal.Contains("RANGE"))
                                    {
                                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                                        int NumberOfDays = NoOfWorkingDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1]), false);
                                        intMOD = NumberOfDays;
                                        if (atten == intMOD - NoOfSunDays(AttenDtTmPkr.Value, Convert.ToInt32(strFromTo[0]), Convert.ToInt32(strFromTo[1])))
                                        {
                                            atten = intMOD;
                                        }
                                    }
                                    else
                                    {
                                        intMOD = Convert.ToInt32(dt.Rows[i]["mod"]);
                                    }

                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / intMOD;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                                }*/
                                else if (dt.Rows[i]["PF_PER"].ToString() == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    double pf_bs = Convert.ToDouble(((Convert.ToDouble(amt) * 100) / 12).ToString("0.00"));

                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));

                                    dgPfEsi.Rows[cou].Cells["pf_bs"].Value = string.Format("{0:F}", pf_bs);


                                    dgPfEsi.Rows[cou].Cells["pf_contribution"].Value = string.Format("{0:F}", get_pf_val(pf_bs.ToString(), 1));
                                    dgPfEsi.Rows[cou].Cells["col_pf"].Value = amt;
                                }
                                else if (dt.Rows[i]["ESI_PER"].ToString() == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    double esi_bs = Convert.ToDouble(((Convert.ToDouble(amt) * 100) / 0.75).ToString("0.00"));

                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(amt)));

                                    dgPfEsi.Rows[cou].Cells["esi_bs"].Value = string.Format("{0:F}", esi_bs);


                                    dgPfEsi.Rows[cou].Cells["esi_contribution"].Value = string.Format("{0:F}", get_pf_val(esi_bs.ToString(), 1));
                                    dgPfEsi.Rows[cou].Cells["col_esi"].Value = amt;
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                }
                            }

                        }

                        if (Convert.ToString(dt.Rows[i]["Revenue_Stamp"]) == "1")
                        {
                            if (Information.IsNumeric(dt.Rows[i]["Revenue_Stamp"]) == true)
                            {
                                double amount_Renge = Convert.ToDouble(dt.Rows[i]["Stamp_Amount"]);
                                if (amount_Renge > Convert.ToDouble(EmploySalary_Details.Rows[cou]["Total_Earning"]))
                                {
                                    EmploySalary_Details.Rows[cou][i + col_cou] = "0";
                                    txtd[i].Text = "0";
                                }
                            }
                        }

                        if (Convert.ToString(dt.Rows[i]["PF_PER"]) == "1")
                        {
                            string chk_pf = clsDataAccess.GetresultS("Select PF_Deduction from tbl_Employee_Mast where ID ='" + EmploySalary_Details.Rows[cou]["ID"] + "' ");

                            if (chk_pf == "0")
                            {

                                if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                                {
                                    double pf_bs = Convert.ToDouble(((Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]) * 100) / 12).ToString("0.00"));
                                    val_pf_bs = pf_bs.ToString("0.00");
                                }
                                else
                                {
                                    string pfno = clsDataAccess.GetresultS("Select PF from tbl_Employee_Mast where ID ='" + EmploySalary_Details.Rows[cou]["ID"] + "' ");
                                    val_pf_bs = cal_formula_pfesi(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(EmploySalary_Details.Rows[cou]["DesgID"]));

                                    if ((Convert.ToDouble(val_pf_bs) > Convert.ToDouble(lblpf_limit.Text)) && (Convert.ToDouble(lblpf_limit.Text) != 0))
                                    {
                                        val_pf_bs = Convert.ToDouble(lblpf_limit.Text).ToString();
                                    }

                                    if (pfno == "")
                                    {
                                        EmploySalary_Details.Rows[cou][i + col_cou] = "0";
                                        txtd[i].Text = "0";
                                        val_pf_bs = "0";

                                    }
                                }
                            }
                            else
                            {
                                EmploySalary_Details.Rows[cou][i + col_cou] = "0";
                                txtd[i].Text = "0";
                                val_pf_bs = "0";
                            }
                            dgPfEsi.Rows[indx].Cells["pf_bs"].Value = val_pf_bs;
                            dgPfEsi.Rows[indx].Cells["col_pf"].Value = EmploySalary_Details.Rows[cou][i + col_cou];
                            dgPfEsi.Rows[indx].Cells["pf_contribution"].Value = get_pf_val(val_pf_bs, 1);
                        }
                        if (Convert.ToString(dt.Rows[i]["ESI_PER"]) == "1")
                        {
                            string chk_esi = clsDataAccess.GetresultS("Select isNull(ESI_Deduction,0) AS ESI_Deduction from tbl_Employee_Mast where ID ='" + EmploySalary_Details.Rows[cou]["ID"] + "' ");
                            val_esi_bs = cal_formula_pfesi(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(EmploySalary_Details.Rows[cou]["DesgID"]));
                            //if (lblEsi_limit.Text == "0")
                            //{


                            //}
                            //else 
                            if ((Convert.ToDouble(val_esi_bs) > Convert.ToDouble(lblEsi_limit.Text)) && (Convert.ToDouble(lblEsi_limit.Text) != 0))
                            {

                                val_esi_bs = "0";
                            }

                            if (chk_esi == "0")
                            {
                                string Esino = clsDataAccess.GetresultS("Select ESIno from tbl_Employee_Mast where ID ='" + EmploySalary_Details.Rows[cou]["ID"] + "' ");
                                if (Esino == "")
                                { EmploySalary_Details.Rows[cou][i + col_cou] = "0"; val_esi_bs = "0"; }
                                else
                                {
                                    if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                                    {
                                        double esi_bs = Convert.ToDouble(((Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]) * 100) / 0.75).ToString("0.00"));
                                        val_esi_bs = esi_bs.ToString("0.00");
                                        if ((Convert.ToDouble(val_esi_bs) > Convert.ToDouble(lblEsi_limit.Text)) && (Convert.ToDouble(lblEsi_limit.Text) != 0))
                                        {
                                            val_esi_bs = "0";
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToDouble(val_esi_bs) > Convert.ToDouble(lblEsi_limit.Text) && (Convert.ToDouble(lblEsi_limit.Text) != 0))
                                        {
                                            EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", 0);
                                            val_esi_bs = "0";
                                        }
                                        else
                                        {
                                            if (Convert.ToDouble(val_esi_bs) == 0)
                                            {
                                                EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", 0);
                                                val_esi_bs = "0";
                                            }
                                            else
                                            {
                                                EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]));
                                            }
                                        }
                                        if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + col_cou]) == true)
                                        {

                                            EmploySalary_Details.Rows[cou][i + col_cou] = Math.Ceiling(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]));
                                        }
                                    }
                                    txtd[i].Text = string.Format("{0:F}", Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]));
                                }
                            }
                            else
                            {
                                EmploySalary_Details.Rows[cou][i + col_cou] = "0"; val_esi_bs = "0";
                            }

                            dgPfEsi.Rows[indx].Cells["esi_bs"].Value = val_esi_bs;
                            dgPfEsi.Rows[indx].Cells["col_esi"].Value = EmploySalary_Details.Rows[cou][i + col_cou];
                            dgPfEsi.Rows[indx].Cells["esi_contribution"].Value = get_pf_val(val_esi_bs, Convert.ToDouble(lblEsi_empl.Text));
                        }
                        if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + col_cou]) == true)
                        {
                            if (dt.Rows[i]["chkHide"].ToString().Trim() == "0")
                            {
                                deduction_amt = deduction_amt + Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]);
                                arr[i + col_cou] = Convert.ToDouble(arr[i + col_cou]) + Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]);
                            }
                            else
                            {
                                deduction_amt = deduction_amt + 0;
                                arr[i + col_cou] = Convert.ToDouble(arr[i + col_cou]) + 0;
                            }
                        }

                    }
                    else
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            //double pf = 0;
                            //if (Convert.ToString(dt.Rows[i]["PF_PER"]) == "1")
                            //    pf = Math.Round(besc_PF_Amt);
                            //EmploySalary_Details.Rows[cou][i + col_cou] = cal_formula(Convert.ToInt32(dt.Rows[i][3]));

                            string lum_amt = "";
                            lum_amt = cal_formula(Convert.ToInt32(dt.Rows[i][3]));

                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                int Cur_Month = AttenDtTmPkr.Value.Month;
                                double Month_Day = Convert.ToDouble(txtcalculated_days.Text);

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);

                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                if (Information.IsNumeric(lum_amt) == true)
                                {
                                    if (Convert.ToString(dt.Rows[i]["ESI_PER"]) == "1")
                                        EmploySalary_Details.Rows[cou][i + col_cou] = Convert.ToDouble(lum_amt);
                                    else
                                        EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                    txtd[i].Text = string.Format("{0:F}", lum_amt);
                                }
                            }
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM")
                        {
                            //--------------- PT Sector
                            if (Convert.ToString(dt.Rows[i]["PT"]) == "1")
                            {
                                string ptax_amt = "";
                                string gender = "";
                                string estate = "";
                                if (AttenDtTmPkr.Value.ToString("MMM").ToUpper() == "FEB")
                                {
                                    ptax_amt = clsDataAccess.GetresultS("Select (case when alt_pt>0 then alt_pt else pt end) pt from tbl_Employee_PTRate where (wfrom <=" + EmploySalary_Details.Rows[cou]["Total_Earning"] + " and wto >=" + EmploySalary_Details.Rows[cou]["Total_Earning"] + ") and (lower(estate)='" + estate + "') and (upper(gender) in ('" + gender + "','ALL'))");
                                }
                                else
                                {

                                    ptax_amt = clsDataAccess.GetresultS("Select pt from tbl_Employee_PTRate where (wfrom <=" + EmploySalary_Details.Rows[cou]["Total_Earning"] + " and wto >=" + EmploySalary_Details.Rows[cou]["Total_Earning"] + ") and (lower(estate)='" + estate + "') and (upper(gender) in ('" + gender + "','ALL'))");
                                }



                                if (Information.IsNumeric(ptax_amt) == true)
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", ptax_amt);
                                else
                                    EmploySalary_Details.Rows[cou][i + col_cou] = "0.00";
                                txtd[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou])));
                            }
                            else
                            {
                                double Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                string lum_amt = "";

                                lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                if (lum_amt == null || lum_amt == "")
                                    lum_amt = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //EmploySalary_Details.Rows[cou][i + col_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //if (Convert.ToString(EmploySalary_Details.Rows[cou][i + col_cou]) == "")
                                //    EmploySalary_Details.Rows[cou][i + col_cou] = clsDataAccess.GetresultS("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["W_Day"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["O_T"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                {
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)));
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                    txtd[i].Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                }
                            }

                        }

                        if (Convert.ToString(dt.Rows[i]["Revenue_Stamp"]) == "1")
                        {
                            if (Information.IsNumeric(dt.Rows[i]["Revenue_Stamp"]) == true)
                            {
                                double amount_Renge = Convert.ToDouble(dt.Rows[i]["Stamp_Amount"]);
                                if (amount_Renge > Convert.ToDouble(EmploySalary_Details.Rows[cou]["Total_Earning"]))
                                {
                                    EmploySalary_Details.Rows[cou][i + col_cou] = "0";
                                    txtd[i].Text = "0";
                                }
                            }
                        }

                        if (Convert.ToString(dt.Rows[i]["PF_PER"]) == "1")
                        {
                            string pfno = clsDataAccess.GetresultS("Select PF from tbl_Employee_Mast where ID ='" + EmploySalary_Details.Rows[cou]["ID"] + "' ");
                            if (pfno == "")
                            {
                                EmploySalary_Details.Rows[cou][i + col_cou] = "0";
                                txtd[i].Text = "0";
                            }
                        }
                        if (Convert.ToString(dt.Rows[i]["ESI_PER"]) == "1")
                        {
                            string Esino = clsDataAccess.GetresultS("Select ESIno from tbl_Employee_Mast where ID ='" + EmploySalary_Details.Rows[cou]["ID"] + "' ");
                            if (Esino == "")
                                EmploySalary_Details.Rows[cou][i + col_cou] = "0";
                            else
                            {
                                EmploySalary_Details.Rows[cou][i + col_cou] = string.Format("{0:F}", Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]));
                                if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + col_cou]) == true)
                                {

                                    EmploySalary_Details.Rows[cou][i + col_cou] = Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]));
                                }
                            }
                            txtd[i].Text = string.Format("{0:F}", Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]));
                        }
                        if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + col_cou]) == true)
                        {
                            if (dt.Rows[i]["chkHide"].ToString().Trim() == "0")
                            {
                                deduction_amt = deduction_amt + Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]);
                                arr[i + col_cou] = Convert.ToDouble(arr[i + col_cou]) + Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]);
                            }
                            else
                            {
                                deduction_amt = deduction_amt + 0;
                                arr[i + col_cou] = Convert.ToDouble(arr[i + col_cou]) + 0;
                            }
                        }

                    }
                }
            }

            //if (dt.Rows[i]["chkHide"].ToString().Trim() == "0")
            //{
            if (boolDedcHeadExists)
            {
                EmploySalary_Details.Rows[cou]["Total_Deduction"] = string.Format("{0:F}", deduction_amt);
                arr[dt.Rows.Count + col_cou] = Convert.ToDouble(arr[dt.Rows.Count + col_cou]) + deduction_amt;
                //}
                //else
                //{
                //    EmploySalary_Details.Rows[cou]["Total_Deduction"] = string.Format("{0:F}", deduction_amt);
                //    arr[dt.Rows.Count + col_cou] = Convert.ToDouble(arr[dt.Rows.Count + col_cou]) + deduction_amt;
                //}
                try
                {
                    EmploySalary_Details.Rows[cou]["Net_Pay"] = string.Format("{0:F}", Convert.ToDouble(EmploySalary_Details.Rows[cou]["Total_Earning"]) - deduction_amt);
                }
                catch { }

                try
                {
                    arr[dt.Rows.Count + col_cou + 1] = Convert.ToDouble(arr[dt.Rows.Count + col_cou + 1]) + Convert.ToDouble(EmploySalary_Details.Rows[cou]["Net_Pay"]);
                }
                catch { }
            }
            else
            {
                cou = EmploySalary_Details.Rows.Count - 1;
                EmploySalary_Details.Rows[cou]["Total_Deduction"] = string.Format("{0:F}", deduction_amt);
                arr[dt.Rows.Count + col_cou] = Convert.ToDouble(arr[dt.Rows.Count + col_cou]) + deduction_amt;
                try
                {
                    EmploySalary_Details.Rows[cou]["Net_Pay"] = string.Format("{0:F}", Convert.ToDouble(EmploySalary_Details.Rows[cou]["Total_Earning"]) - deduction_amt);
                }
                catch { }

                try
                {
                    arr[dt.Rows.Count + col_cou + 1] = Convert.ToDouble(arr[dt.Rows.Count + col_cou + 1]) + Convert.ToDouble(EmploySalary_Details.Rows[cou]["Net_Pay"]);
                }
                catch { }
            }

        }

        public void emp_earning_back()
        {
            string s = "";
            string _empbasic = "";
            string _empsal = "";
            int cou = 0, dt_cou = 8, desgid = 0;
            double earning_amt = 0;
            int idx = 0;
            //s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE from tbl_Employee_Assign_SalStructure where session='" + cmbYear.Text.Trim() + "' and Location_id=" + Locations + " and p_type='E' ";
            s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE,atten_day,Proxy_day,Daily_wages,C_BASIS,chkAlK,chkHide,mod,wd,pt_basis,[no_round],[limit_day],[ldays],[alt_mon],lvless,gs,chkFlag from tbl_Employee_Assign_SalStructure where (Location_id=" + Locations + ") and (p_type='E') and (chkHide in ('3','31')) ";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            //if 

            try
            {
                //   sal_total();
            }
            catch { }
            string col_head = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bak_earn = 1;
                desgid = Convert.ToInt32(EmploySalary_Details.Rows[cou]["DesgID"]);
                col_head = get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "E");
                idx = 0;
                while (idx < lbe.Length)
                {
                    if (lbe[idx].Text == col_head)
                    {
                        break;
                    }
                    idx++;
                }
                //idx =Convert.ToInt32(Array.FindIndex(lbe,0,8, col_head));
                if (i == 0)
                {
                    cou = EmploySalary_Details.Rows.Count - 1;
                    double Month_Day = 0; //Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);

                    if (lbl_mod.Text == "MOD-EWO")
                    {
                        Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                    }
                    else
                    {
                        Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                    }
                    //testless
                    _empbasic = "select EMP_BASIC from tbl_Employee_Assign_SalStructure where Location_id=" + Locations + " and p_type='E' and sal_head=" + dt.Rows[i]["sal_head"] + " ";
                    DataTable dt1 = new DataTable();
                    dt1 = clsDataAccess.RunQDTbl(_empbasic);

                    //testless

                    //if (dt1.Rows[0][0].ToString().Trim() == "1")
                    //{
                    //    EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                    //    if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                    //        EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                    //}
                    //else if (dt1.Rows[0][0].ToString().Trim() == "2")
                    //{
                    //    EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select EMPSAL - empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                    //    if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                    //        EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select EMPSAL - empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                    //}
                    //else if (dt1.Rows[0][0].ToString().Trim() == "3")
                    //{
                    //    EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                    //    if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                    //        EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                    //}
                    //else
                    //{
                    //    EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select isNUll(AMOUNT,0) from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                    //    if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                    //        EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select isNUll(AMOUNT,0) from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                    //}


                    //////////EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                    //////////if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                    //////////    EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                    //if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                    //    if (Information.IsNumeric(EmploySalary_Details.Rows[cou]["Salary"]) == true)
                    //        EmploySalary_Details.Rows[cou]["Salary"] = Convert.ToString(Convert.ToDouble(EmploySalary_Details.Rows[cou]["Salary"]) * Month_Day);

                }
                //if (dt.Rows[i][1].ToString().Trim() == "E" && dateTimePicker1.Value.Month >= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][4].ToString()) && dateTimePicker1.Value.Month <= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][5].ToString()))
                if (dt.Rows[i][1].ToString().Trim() == "E")
                {
                    if (dt.Rows[i][13].ToString().Trim() == "Independent") //Residual Consolidated
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            string lum_amt = "";

                            lum_amt = cal_formula(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(desgid), 2);
                            if (Convert.ToDecimal(EmploySalary_Details.Rows[cou]["Salary"]) == Convert.ToDecimal(0))
                            {
                                lum_amt = "0";
                            }
                            if (Convert.ToDouble(lum_amt) < 0 && Convert.ToInt32(dt.Rows[i]["chkFlag"]) == 1)
                            {
                                lum_amt = "0";
                            }
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0;//Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }
                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                            }

                            if (Information.IsNumeric(lum_amt) == true)
                            {

                                EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                txte[idx].Text = string.Format("{0:F}", lum_amt);
                            }
                        }

                        else if (dt.Rows[i][2].ToString().Trim() == "SLAB")
                        {
                            if (Convert.ToInt32(dt.Rows[i]["PT"]) == 0)
                            {

                                int cdid = Convert.ToInt32(dt.Rows[i]["c_det"]);
                                string bso = clsDataAccess.ReturnValue("select distinct basedon from tblposlab where (slid='" + cdid + "')");
                                double bso_val = 0;
                                if (bso == "BS")
                                {
                                    bso_val = Convert.ToDouble(EmploySalary_Details.Rows[cou]["BS"]);
                                }
                                else if (bso == "GS")
                                {
                                    bso_val = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TotalEarning"]);
                                }
                                else if (bso == "WD")
                                {
                                    bso_val = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                }
                                else if (bso == "OT")
                                {
                                    bso_val = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                }
                                else //if(bso=="TD")
                                {
                                    bso_val = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TDays"]);
                                }

                                double val = Convert.ToDouble(clsDataAccess.ReturnValue("SELECT amt FROM tblposlab WHERE (" + bso_val + " BETWEEN wfrom AND wto) AND (slid ='" + cdid + "')"));
                                EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", val);
                            }
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM" || dt.Rows[i][2].ToString().Trim() == "BULK")
                            //if (i == 0)
                            //{
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0;// Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }
                                string lum_amt = "";

                                //testless
                                _empbasic = "select EMP_BASIC from tbl_Employee_Assign_SalStructure where Location_id=" + Locations + " and p_type='E' and sal_head=" + dt.Rows[i]["sal_head"] + "";
                                DataTable dt1 = new DataTable();
                                dt1 = clsDataAccess.RunQDTbl(_empbasic);

                                if (dt1.Rows[0][0].ToString().Trim() == "1")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "2")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select EMPSAL-empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select EMPSAL-empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "3")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                                }

                                //lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //if (lum_amt == null || lum_amt == "")
                                //    lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //LUMPSUM OT

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";

                                if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                {

                                    double atten = 0;

                                    if (Convert.ToString(dt.Rows[i]["Tday"]) == "2")
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TDays"]);
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Tday"]) == "3")
                                    {
                                        if (lbl_mod.Text == "MOD-EWO")
                                        {
                                            Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                        }
                                        else
                                        {
                                            Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                        }
                                    }
                                    else
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    }

                                    if (Convert.ToString(dt.Rows[i]["Proxy_day"]) != "1")
                                    {
                                        lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * Convert.ToDouble(atten));
                                    }
                                }
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txte[idx].Text = string.Format("{0:F}", amt);
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = 0;
                                    if (Convert.ToString(dt.Rows[i]["Tday"]) == "2")
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TDays"]);
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Tday"]) == "3")
                                    {
                                        if (lbl_mod.Text == "MOD-EWO")
                                        {
                                            Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                        }
                                        else
                                        {
                                            Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                        }
                                    }
                                    else
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    }
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txte[idx].Text = string.Format("{0:F}", amt);
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    if (Convert.ToString(dt.Rows[i]["Tday"]) == "3")
                                    {
                                        if (lbl_mod.Text == "MOD-EWO")
                                        {
                                            Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                        }
                                        else
                                        {
                                            Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                        }
                                    }
                                    if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                    {

                                        double amt = Convert.ToDouble(Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day));
                                        EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                        txte[idx].Text = string.Format("{0:F}", amt);
                                    }
                                    else
                                    {
                                        double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                        EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                        txte[idx].Text = string.Format("{0:F}", amt);
                                    }
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                    txte[idx].Text = string.Format("{0:F}", lum_amt);
                                }

                                //}
                                //else
                                //{
                                //    EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //    if (Convert.ToString(EmploySalary_Details.Rows[cou][col_head]) == "")
                                //        EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //    if (Information.IsNumeric(EmploySalary_Details.Rows[cou][col_head]) == true)
                                //        EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + 7])));
                                //}
                            }
                            else
                            {
                                //EmploySalary_Details.Rows[cou][i + 6] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " ");

                                //testless

                                EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                if (Convert.ToString(EmploySalary_Details.Rows[cou][col_head]) == "")
                                    EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(EmploySalary_Details.Rows[cou][col_head]) == true)
                                {
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][col_head])));
                                    txte[idx].Text = string.Format("{0:F}", EmploySalary_Details.Rows[cou][col_head]);
                                }
                            }
                    }
                    else if (dt.Rows[i][13].ToString().Trim() == "Inflow")
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            _empsal = "select EMPSAL from tbl_EmpMst where eid='" + emply_id + "' ";
                            DataTable dt_empsal = new DataTable();
                            dt_empsal = clsDataAccess.RunQDTbl(_empsal);

                            string lum_amt = "";
                            double esi_amt = 0;
                            lum_amt = cal_formula(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(desgid), 2);
                            if (Convert.ToDecimal(EmploySalary_Details.Rows[cou]["Salary"]) == Convert.ToDecimal(0))
                            {
                                lum_amt = "0";
                            }
                            if (Convert.ToDouble(lum_amt) < 0)
                            {
                                lum_amt = "0";
                            }
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0;//Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                }

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {

                                    double atten = 0;
                                    if (Convert.ToString(dt.Rows[i]["Tday"]) == "2")
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TDays"]);
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Tday"]) == "3")
                                    {
                                        if (lbl_mod.Text == "MOD-EWO")
                                        {
                                            Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                        }
                                        else
                                        {
                                            Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                        }
                                    }
                                    else
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    }
                                    double _sal_amt = (Convert.ToDouble(dt_empsal.Rows[0][0]) * Convert.ToDouble(atten)) / Month_Day;
                                    double amt = _sal_amt - (Convert.ToDouble(lum_amt));
                                    esi_amt = Convert.ToDouble(amt);
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));

                                    //double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    //double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    //EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                            }

                            if (Information.IsNumeric(lum_amt) == true)
                            {
                                EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(esi_amt)));
                                txte[idx].Text = string.Format("{0:F}", esi_amt);
                            }
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM" || dt.Rows[i][2].ToString().Trim() == "BULK")
                            //if (i == 0)
                            //{
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0;//Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                }
                                string lum_amt = "";

                                //testless
                                _empbasic = "select EMP_BASIC from tbl_Employee_Assign_SalStructure where Location_id=" + Locations + " and p_type='E' and sal_head=" + dt.Rows[i]["sal_head"] + "";
                                DataTable dt1 = new DataTable();
                                dt1 = clsDataAccess.RunQDTbl(_empbasic);

                                if (dt1.Rows[0][0].ToString().Trim() == "1")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "2")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select EMPSAL - empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select EMPSAL - empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "3")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                                }

                                //lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //if (lum_amt == null || lum_amt == "")
                                //    lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";

                                if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                    lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * Month_Day);

                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txte[idx].Text = string.Format("{0:F}", amt);
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txte[idx].Text = string.Format("{0:F}", amt);
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txte[idx].Text = string.Format("{0:F}", amt);
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                    txte[idx].Text = string.Format("{0:F}", lum_amt);
                                }

                                //}
                                //else
                                //{
                                //    EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //    if (Convert.ToString(EmploySalary_Details.Rows[cou][col_head]) == "")
                                //        EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //    if (Information.IsNumeric(EmploySalary_Details.Rows[cou][col_head]) == true)
                                //        EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + 7])));
                                //}
                            }
                            else
                            {
                                //EmploySalary_Details.Rows[cou][i + 6] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " ");

                                //testless

                                EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                if (Convert.ToString(EmploySalary_Details.Rows[cou][col_head]) == "")
                                    EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(EmploySalary_Details.Rows[cou][col_head]) == true)
                                {
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][col_head])));
                                    txte[idx].Text = string.Format("{0:F}", EmploySalary_Details.Rows[cou][col_head]);
                                }
                            }
                    }
                    else if (dt.Rows[i][13].ToString().Trim() == "Conditional")
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            _empsal = "select EMPSAL from tbl_EmpMst where eid='" + emply_id + "' ";
                            DataTable dt_empsal = new DataTable();
                            dt_empsal = clsDataAccess.RunQDTbl(_empsal);

                            string lum_amt = "";
                            double esi_amt = 0;

                            lum_amt = cal_formula(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(desgid), 2);
                            if (Convert.ToDecimal(EmploySalary_Details.Rows[cou]["Salary"]) == Convert.ToDecimal(0))
                            {
                                lum_amt = "0";
                            }
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0;// Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                }
                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = 0;
                                    if (Convert.ToString(dt.Rows[i]["Tday"]) == "2")
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TDays"]);
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Tday"]) == "3")
                                    {
                                        if (lbl_mod.Text == "MOD-EWO")
                                        {
                                            Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                        }
                                        else
                                        {
                                            Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                        }
                                    }
                                    else
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    }
                                    double _sal_amt = (Convert.ToDouble(dt_empsal.Rows[0][0]) * Convert.ToDouble(atten)) / Month_Day;
                                    double amt = _sal_amt - (Convert.ToDouble(lum_amt));
                                    esi_amt = Convert.ToDouble(amt);
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));

                                    //double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    //double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    //EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                            }

                            if (Information.IsNumeric(lum_amt) == true)
                            {
                                EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                txte[idx].Text = string.Format("{0:F}", lum_amt);
                            }


                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM" || dt.Rows[i][2].ToString().Trim() == "BULK")
                            //if (i == 0)
                            //{
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0; //Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                }
                                string lum_amt = "";

                                //testless
                                _empbasic = "select EMP_BASIC from tbl_Employee_Assign_SalStructure where Location_id=" + Locations + " and p_type='E' and sal_head=" + dt.Rows[i]["sal_head"] + "";
                                DataTable dt1 = new DataTable();
                                dt1 = clsDataAccess.RunQDTbl(_empbasic);

                                if (dt1.Rows[0][0].ToString().Trim() == "1")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "2")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select EMPSAL - empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select EMPSAL - empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "3")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                                }

                                //lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //if (lum_amt == null || lum_amt == "")
                                //    lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";

                                if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                    lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * Month_Day);

                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txte[idx].Text = string.Format("{0:F}", amt);
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = 0;
                                    if (Convert.ToString(dt.Rows[i]["Tday"]) == "2")
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TDays"]);
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Tday"]) == "3")
                                    {
                                        if (lbl_mod.Text == "MOD-EWO")
                                        {
                                            Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                        }
                                        else
                                        {
                                            Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                        }
                                    }
                                    else
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    }
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txte[idx].Text = string.Format("{0:F}", amt);
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txte[idx].Text = string.Format("{0:F}", amt);
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                    txte[idx].Text = string.Format("{0:F}", lum_amt);
                                }

                                //}
                                //else
                                //{
                                //    EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //    if (Convert.ToString(EmploySalary_Details.Rows[cou][col_head]) == "")
                                //        EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //    if (Information.IsNumeric(EmploySalary_Details.Rows[cou][col_head]) == true)
                                //        EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + 7])));
                                //}
                            }
                            else
                            {
                                //EmploySalary_Details.Rows[cou][i + 6] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " ");

                                //testless

                                EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                if (Convert.ToString(EmploySalary_Details.Rows[cou][col_head]) == "")
                                    EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(EmploySalary_Details.Rows[cou][col_head]) == true)
                                {
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][col_head])));
                                    txte[idx].Text = string.Format("{0:F}", EmploySalary_Details.Rows[cou][col_head]);
                                }
                            }
                    }
                    else
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            _empsal = "select EMPSAL from tbl_EmpMst where eid='" + emply_id + "' ";
                            DataTable dt_empsal = new DataTable();
                            dt_empsal = clsDataAccess.RunQDTbl(_empsal);

                            string lum_amt = "";
                            double esi_amt = 0;
                            lum_amt = cal_formula(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(desgid), 2);

                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0;//Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }
                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    double _sal_amt = (Convert.ToDouble(dt_empsal.Rows[0][0]) * Convert.ToDouble(atten)) / Month_Day;
                                    double amt = _sal_amt - (Convert.ToDouble(lum_amt));
                                    esi_amt = Convert.ToDouble(amt);
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                            }

                            if (Information.IsNumeric(lum_amt) == true)
                            {
                                EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(esi_amt)));

                            }
                        }

                    }
                    //=================================================================================================

                    //===================================================================================================
                }
            }

        }

        public void emp_deduction_back()
        {
            string s = "";
            string _empbasic = "";
            string _empsal = "";
            int cou = 0, dt_cou = 8, desgid = 0;
            double earning_amt = 0;
            int idx = 0;
            //s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE from tbl_Employee_Assign_SalStructure where session='" + cmbYear.Text.Trim() + "' and Location_id=" + Locations + " and p_type='D' ";
            s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE,atten_day,Proxy_day,Daily_wages,C_BASIS,chkAlK,chkHide,mod,wd,pt_basis,[no_round],[limit_day],[ldays],[alt_mon],lvless,gs,chkFlag from tbl_Employee_Assign_SalStructure where (Location_id=" + Locations + ") and (p_type='D') and (chkHide in ('3','31')) ";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            //if 

            try
            {
                //   sal_total();
            }
            catch { }
            string col_head = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bak_ded = 1;
                desgid = Convert.ToInt32(EmploySalary_Details.Rows[cou]["DesgID"]);
                col_head = get_sal_head_name(Convert.ToInt32(dt.Rows[i][0]), "D");
                idx = 0;
                while (idx < lbd.Length)
                {
                    if (lbd[idx].Text == col_head)
                    {
                        break;
                    }
                    idx++;
                }
                //idx =Convert.ToInt32(Array.FindIndex(lbe,0,8, col_head));
                if (i == 0)
                {
                    cou = EmploySalary_Details.Rows.Count - 1;
                    double Month_Day = 0; //Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);

                    if (lbl_mod.Text == "MOD-EWO")
                    {
                        Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                    }
                    else
                    {
                        Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                    }
                    //testless
                    _empbasic = "select EMP_BASIC from tbl_Employee_Assign_SalStructure where Location_id=" + Locations + " and p_type='D' and sal_head=" + dt.Rows[i]["sal_head"] + " ";
                    DataTable dt1 = new DataTable();
                    dt1 = clsDataAccess.RunQDTbl(_empbasic);

                    //testless

                    //if (dt1.Rows[0][0].ToString().Trim() == "1")
                    //{
                    //    EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                    //    if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                    //        EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                    //}
                    //else if (dt1.Rows[0][0].ToString().Trim() == "2")
                    //{
                    //    EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select EMPSAL - empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                    //    if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                    //        EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select EMPSAL - empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                    //}
                    //else if (dt1.Rows[0][0].ToString().Trim() == "3")
                    //{
                    //    EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                    //    if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                    //        EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                    //}
                    //else
                    //{
                    //    EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select isNUll(AMOUNT,0) from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                    //    if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                    //        EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select isNUll(AMOUNT,0) from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                    //}


                    //////////EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                    //////////if (Convert.ToString(EmploySalary_Details.Rows[cou]["Salary"]) == "")
                    //////////    EmploySalary_Details.Rows[cou]["Salary"] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                    //if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                    //    if (Information.IsNumeric(EmploySalary_Details.Rows[cou]["Salary"]) == true)
                    //        EmploySalary_Details.Rows[cou]["Salary"] = Convert.ToString(Convert.ToDouble(EmploySalary_Details.Rows[cou]["Salary"]) * Month_Day);

                }
                //if (dt.Rows[i][1].ToString().Trim() == "E" && dateTimePicker1.Value.Month >= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][4].ToString()) && dateTimePicker1.Value.Month <= clsEmployee.GetMonth_SingleDigit(dt.Rows[i][5].ToString()))
                if (dt.Rows[i][1].ToString().Trim() == "D")
                {
                    if (dt.Rows[i][13].ToString().Trim() == "Independent") //Residual Consolidated
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            string lum_amt = "";

                            lum_amt = cal_formula(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(desgid), 2);
                            if (Convert.ToDecimal(EmploySalary_Details.Rows[cou]["Salary"]) == Convert.ToDecimal(0))
                            {
                                lum_amt = "0";
                            }
                            if (Convert.ToDouble(lum_amt) > 0 && Convert.ToInt32(dt.Rows[i]["chkFlag"]) == 1)
                            {
                                lum_amt = "0";
                            }
                            else if (Convert.ToDouble(lum_amt) <= 0)
                            {
                                lum_amt = lum_amt.Replace("-", "").ToString().Trim();

                            }
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0;//Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }
                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                            }

                            if (Information.IsNumeric(lum_amt) == true)
                            {

                                EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                txtd[idx].Text = string.Format("{0:F}", lum_amt);
                            }
                        }

                        else if (dt.Rows[i][2].ToString().Trim() == "SLAB")
                        {
                            if (Convert.ToInt32(dt.Rows[i]["PT"]) == 0)
                            {

                                int cdid = Convert.ToInt32(dt.Rows[i]["c_det"]);
                                string bso = clsDataAccess.ReturnValue("select distinct basedon from tblposlab where (slid='" + cdid + "')");
                                double bso_val = 0;
                                if (bso == "BS")
                                {
                                    bso_val = Convert.ToDouble(EmploySalary_Details.Rows[cou]["BS"]);
                                }
                                else if (bso == "GS")
                                {
                                    bso_val = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TotalEarning"]);
                                }
                                else if (bso == "WD")
                                {
                                    bso_val = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                }
                                else if (bso == "OT")
                                {
                                    bso_val = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                }
                                else //if(bso=="TD")
                                {
                                    bso_val = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TDays"]);
                                }

                                double val = Convert.ToDouble(clsDataAccess.ReturnValue("SELECT amt FROM tblposlab WHERE (" + bso_val + " BETWEEN wfrom AND wto) AND (slid ='" + cdid + "')"));
                                EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", val);
                            }
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM" || dt.Rows[i][2].ToString().Trim() == "BULK")
                            //if (i == 0)
                            //{
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0;// Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }
                                string lum_amt = "";

                                //testless
                                _empbasic = "select EMP_BASIC from tbl_Employee_Assign_SalStructure where Location_id=" + Locations + " and p_type='D' and sal_head=" + dt.Rows[i]["sal_head"] + "";
                                DataTable dt1 = new DataTable();
                                dt1 = clsDataAccess.RunQDTbl(_empbasic);

                                if (dt1.Rows[0][0].ToString().Trim() == "1")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "2")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select EMPSAL-empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select EMPSAL-empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "3")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                                }

                                //lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //if (lum_amt == null || lum_amt == "")
                                //    lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //LUMPSUM OT

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";

                                if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                {

                                    double atten = 0;

                                    if (Convert.ToString(dt.Rows[i]["Tday"]) == "2")
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TDays"]);
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Tday"]) == "3")
                                    {
                                        if (lbl_mod.Text == "MOD-EWO")
                                        {
                                            Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                        }
                                        else
                                        {
                                            Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                        }
                                    }
                                    else
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    }

                                    if (Convert.ToString(dt.Rows[i]["Proxy_day"]) != "1")
                                    {
                                        lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * Convert.ToDouble(atten));
                                    }
                                }
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[idx].Text = string.Format("{0:F}", amt);
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = 0;
                                    if (Convert.ToString(dt.Rows[i]["Tday"]) == "2")
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TDays"]);
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Tday"]) == "3")
                                    {
                                        if (lbl_mod.Text == "MOD-EWO")
                                        {
                                            Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                        }
                                        else
                                        {
                                            Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                        }
                                    }
                                    else
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    }
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[idx].Text = string.Format("{0:F}", amt);
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    if (Convert.ToString(dt.Rows[i]["Tday"]) == "3")
                                    {
                                        if (lbl_mod.Text == "MOD-EWO")
                                        {
                                            Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                        }
                                        else
                                        {
                                            Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                        }
                                    }
                                    if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                    {

                                        double amt = Convert.ToDouble(Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day));
                                        EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                        txtd[idx].Text = string.Format("{0:F}", amt);
                                    }
                                    else
                                    {
                                        double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                        EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                        txtd[idx].Text = string.Format("{0:F}", amt);
                                    }
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                    txtd[idx].Text = string.Format("{0:F}", lum_amt);
                                }

                                //}
                                //else
                                //{
                                //    EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //    if (Convert.ToString(EmploySalary_Details.Rows[cou][col_head]) == "")
                                //        EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //    if (Information.IsNumeric(EmploySalary_Details.Rows[cou][col_head]) == true)
                                //        EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + 7])));
                                //}
                            }
                            else
                            {
                                //EmploySalary_Details.Rows[cou][i + 6] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " ");

                                //testless

                                EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                if (Convert.ToString(EmploySalary_Details.Rows[cou][col_head]) == "")
                                    EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(EmploySalary_Details.Rows[cou][col_head]) == true)
                                {
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][col_head])));
                                    txtd[idx].Text = string.Format("{0:F}", EmploySalary_Details.Rows[cou][col_head]);
                                }
                            }
                    }
                    else if (dt.Rows[i][13].ToString().Trim() == "Inflow")
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            _empsal = "select EMPSAL from tbl_EmpMst where eid='" + emply_id + "' ";
                            DataTable dt_empsal = new DataTable();
                            dt_empsal = clsDataAccess.RunQDTbl(_empsal);

                            string lum_amt = "";
                            double esi_amt = 0;
                            lum_amt = cal_formula(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(desgid), 2);
                            if (Convert.ToDecimal(EmploySalary_Details.Rows[cou]["Salary"]) == Convert.ToDecimal(0))
                            {
                                lum_amt = "0";
                            }
                            if (Convert.ToDouble(lum_amt) < 0)
                            {
                                lum_amt = "0";
                            }
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0;//Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                }

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {

                                    double atten = 0;
                                    if (Convert.ToString(dt.Rows[i]["Tday"]) == "2")
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TDays"]);
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Tday"]) == "3")
                                    {
                                        if (lbl_mod.Text == "MOD-EWO")
                                        {
                                            Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                        }
                                        else
                                        {
                                            Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                        }
                                    }
                                    else
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    }
                                    double _sal_amt = (Convert.ToDouble(dt_empsal.Rows[0][0]) * Convert.ToDouble(atten)) / Month_Day;
                                    double amt = _sal_amt - (Convert.ToDouble(lum_amt));
                                    esi_amt = Convert.ToDouble(amt);
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));

                                    //double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    //double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    //EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                            }

                            if (Information.IsNumeric(lum_amt) == true)
                            {
                                EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(esi_amt)));
                                txtd[idx].Text = string.Format("{0:F}", esi_amt);
                            }
                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM" || dt.Rows[i][2].ToString().Trim() == "BULK")
                            //if (i == 0)
                            //{
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0;//Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                }
                                string lum_amt = "";

                                //testless
                                _empbasic = "select EMP_BASIC from tbl_Employee_Assign_SalStructure where Location_id=" + Locations + " and p_type='D' and sal_head=" + dt.Rows[i]["sal_head"] + "";
                                DataTable dt1 = new DataTable();
                                dt1 = clsDataAccess.RunQDTbl(_empbasic);

                                if (dt1.Rows[0][0].ToString().Trim() == "1")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "2")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select EMPSAL - empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select EMPSAL - empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "3")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                                }

                                //lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //if (lum_amt == null || lum_amt == "")
                                //    lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";

                                if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                    lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * Month_Day);

                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[idx].Text = string.Format("{0:F}", amt);
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[idx].Text = string.Format("{0:F}", amt);
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[idx].Text = string.Format("{0:F}", amt);
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                    txtd[idx].Text = string.Format("{0:F}", lum_amt);
                                }

                                //}
                                //else
                                //{
                                //    EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //    if (Convert.ToString(EmploySalary_Details.Rows[cou][col_head]) == "")
                                //        EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //    if (Information.IsNumeric(EmploySalary_Details.Rows[cou][col_head]) == true)
                                //        EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + 7])));
                                //}
                            }
                            else
                            {
                                //EmploySalary_Details.Rows[cou][i + 6] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " ");

                                //testless

                                EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                if (Convert.ToString(EmploySalary_Details.Rows[cou][col_head]) == "")
                                    EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(EmploySalary_Details.Rows[cou][col_head]) == true)
                                {
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][col_head])));
                                    txtd[idx].Text = string.Format("{0:F}", EmploySalary_Details.Rows[cou][col_head]);
                                }
                            }
                    }
                    else if (dt.Rows[i][13].ToString().Trim() == "Conditional")
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            _empsal = "select EMPSAL from tbl_EmpMst where eid='" + emply_id + "' ";
                            DataTable dt_empsal = new DataTable();
                            dt_empsal = clsDataAccess.RunQDTbl(_empsal);

                            string lum_amt = "";
                            double esi_amt = 0;

                            lum_amt = cal_formula(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(desgid), 2);
                            if (Convert.ToDecimal(EmploySalary_Details.Rows[cou]["Salary"]) == Convert.ToDecimal(0))
                            {
                                lum_amt = "0";
                            }
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0;// Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                }
                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = 0;
                                    if (Convert.ToString(dt.Rows[i]["Tday"]) == "2")
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TDays"]);
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Tday"]) == "3")
                                    {
                                        if (lbl_mod.Text == "MOD-EWO")
                                        {
                                            Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                        }
                                        else
                                        {
                                            Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                        }
                                    }
                                    else
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    }
                                    double _sal_amt = (Convert.ToDouble(dt_empsal.Rows[0][0]) * Convert.ToDouble(atten)) / Month_Day;
                                    double amt = _sal_amt - (Convert.ToDouble(lum_amt));
                                    esi_amt = Convert.ToDouble(amt);
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));

                                    //double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    //double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    //EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                            }

                            if (Information.IsNumeric(lum_amt) == true)
                            {
                                EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                txtd[idx].Text = string.Format("{0:F}", lum_amt);
                            }


                        }
                        else if (dt.Rows[i][2].ToString().Trim() == "COMPANY LUMPSUM" || dt.Rows[i][2].ToString().Trim() == "BULK")
                            //if (i == 0)
                            //{
                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0; //Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                }
                                string lum_amt = "";

                                //testless
                                _empbasic = "select EMP_BASIC from tbl_Employee_Assign_SalStructure where Location_id=" + Locations + " and p_type='D' and sal_head=" + dt.Rows[i]["sal_head"] + "";
                                DataTable dt1 = new DataTable();
                                dt1 = clsDataAccess.RunQDTbl(_empbasic);

                                if (dt1.Rows[0][0].ToString().Trim() == "1")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "2")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select EMPSAL - empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select EMPSAL - empbasic from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else if (dt1.Rows[0][0].ToString().Trim() == "3")
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select EMPSAL from tbl_EmpMst where eid ='" + emply_id + "'");
                                }
                                else
                                {
                                    lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                    if (lum_amt == null || lum_amt == "")
                                        lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");
                                }

                                //lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //if (lum_amt == null || lum_amt == "")
                                //    lum_amt = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";

                                if (Convert.ToString(dt.Rows[i]["Daily_wages"]) == "1")
                                    lum_amt = Convert.ToString(Convert.ToDouble(lum_amt) * Month_Day);

                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[idx].Text = string.Format("{0:F}", amt);
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = 0;
                                    if (Convert.ToString(dt.Rows[i]["Tday"]) == "2")
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["TDays"]);
                                    }
                                    else if (Convert.ToString(dt.Rows[i]["Tday"]) == "3")
                                    {
                                        if (lbl_mod.Text == "MOD-EWO")
                                        {
                                            Month_Day = Convert.ToDouble(dt_atn.Rows[0]["MOD"]);
                                        }
                                        else
                                        {
                                            Month_Day = Convert.ToDouble(txtcalculated_days.Text);
                                        }
                                    }
                                    else
                                    {
                                        atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    }
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(atten)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[idx].Text = string.Format("{0:F}", amt);
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                    txtd[idx].Text = string.Format("{0:F}", amt);
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(lum_amt)));
                                    txtd[idx].Text = string.Format("{0:F}", lum_amt);
                                }

                                //}
                                //else
                                //{
                                //    EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                //    if (Convert.ToString(EmploySalary_Details.Rows[cou][col_head]) == "")
                                //        EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //    if (Information.IsNumeric(EmploySalary_Details.Rows[cou][col_head]) == true)
                                //        EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][i + 7])));
                                //}
                            }
                            else
                            {
                                //EmploySalary_Details.Rows[cou][i + 6] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " ");

                                //testless

                                EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE =" + deg_id + " ");
                                if (Convert.ToString(EmploySalary_Details.Rows[cou][col_head]) == "")
                                    EmploySalary_Details.Rows[cou][col_head] = clsDataAccess.ReturnValue("Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + dt.Rows[i][3] + " and GRADE ='0' ");

                                //testless

                                if (Information.IsNumeric(EmploySalary_Details.Rows[cou][col_head]) == true)
                                {
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(EmploySalary_Details.Rows[cou][col_head])));
                                    txtd[idx].Text = string.Format("{0:F}", EmploySalary_Details.Rows[cou][col_head]);
                                }
                            }
                    }
                    else
                    {
                        if (dt.Rows[i][2].ToString().Trim() == "FORMULA")
                        {
                            _empsal = "select EMPSAL from tbl_EmpMst where eid='" + emply_id + "' ";
                            DataTable dt_empsal = new DataTable();
                            dt_empsal = clsDataAccess.RunQDTbl(_empsal);

                            string lum_amt = "";
                            double esi_amt = 0;
                            lum_amt = cal_formula(Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(desgid), 2);

                            if (Information.IsNumeric(txtattendence.Text) == true)
                            {
                                //int Cur_Month = dateTimePicker1.Value.Month;
                                double Month_Day = 0;//Convert.ToInt32(tdays_mod); //Convert.ToInt32(txtcalculated_days.Text);
                                if (lbl_mod.Text == "MOD-EWO")
                                {
                                    Month_Day = Convert.ToInt32(dt_atn.Rows[0]["MOD"]);
                                }
                                else
                                {
                                    Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                }
                                if (Information.IsNumeric(lum_amt) == false)
                                    lum_amt = "0";
                                if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1" && Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["atten_day"]) == "1")
                                {
                                    double atten = Convert.ToDouble(EmploySalary_Details.Rows[cou]["WDay"]);
                                    double _sal_amt = (Convert.ToDouble(dt_empsal.Rows[0][0]) * Convert.ToDouble(atten)) / Month_Day;
                                    double amt = _sal_amt - (Convert.ToDouble(lum_amt));
                                    esi_amt = Convert.ToDouble(amt);
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                                else if (Convert.ToString(dt.Rows[i]["Proxy_day"]) == "1")
                                {
                                    double Proxy_day = Convert.ToDouble(EmploySalary_Details.Rows[cou]["OT"]);
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(Proxy_day)) / Month_Day;
                                    EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(amt));
                                }
                            }

                            if (Information.IsNumeric(lum_amt) == true)
                            {
                                EmploySalary_Details.Rows[cou][col_head] = string.Format("{0:F}", Math.Round(Convert.ToDouble(esi_amt)));

                            }
                        }

                    }
                    //=================================================================================================


                    //if (Information.IsNumeric(EmploySalary_Details.Rows[cou][i + col_cou]) == true)
                    //{
                    //    if (dt.Rows[i]["chkHide"].ToString().Trim() == "0" || dt.Rows[i][15].ToString().Trim() == "3")
                    //    {
                    //        deduction_amt = deduction_amt + Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]);
                    //        arr[i + col_cou] = Convert.ToDouble(arr[i + col_cou]) + Convert.ToDouble(EmploySalary_Details.Rows[cou][i + col_cou]);
                    //    }
                    //    else
                    //    {
                    //        deduction_amt = deduction_amt + 0;
                    //        arr[i + col_cou] = Convert.ToDouble(arr[i + col_cou]) + 0;
                    //    }
                    //}
                    //===================================================================================================
                }
            }

        }

        private void cmbMonth_DropDown(object sender, EventArgs e)
        {
            try
            {
                clear_txt();
            }
            catch (Exception x) { }
        }

        private void cmbMonth_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                hsh_rtype.Clear();
                if (cmbMonth.Text != "" && Locations != "")
                {
                    string eid = "";
                    get_data();
                    get_data1();
                    Get_mnth_detl();
                    //if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
                    //    eid = emp_id[cmbempname1111.Text.Trim()].ToString();
                    eid = "0";
                    if (hsh_All_Mnth.ContainsKey(cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()))
                        view_sal(hsh_All_Mnth[cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()].ToString(), "Y");
                    else
                    {
                        if (hsh_lst_mnth.ContainsKey(cmbYear.Text.Trim() + "/" + eid.ToString()))
                            view_sal(hsh_lst_mnth[cmbYear.Text.Trim() + "/" + eid.ToString()].ToString(), "N");
                    }
                }

            }
            catch (Exception x) { }
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


        public int get_LocationID(string name)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select Location_ID from tbl_Emp_Location where Location_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }


        public int get_SalStructID(string name)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select SlNo from tbl_Employee_SalaryStructure where SalaryCategory='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public string get_SalStructName(int id)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select SalaryCategory from tbl_Employee_SalaryStructure where SlNo=" + id;
            dt = clsDataAccess.RunQDTbl(s);
            return dt.Rows[0][0].ToString();

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


        public void load_txt()
        {
            int lbl = 6, lbl1 = 7;
            for (int t = 0; t < 16; t++)
            {
                Label lb = new Label();
                TextBoxX.TextBoxX txt = new TextBoxX.TextBoxX();
                txt.Name = "txte" + t.ToString();
                lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.Name = "lble" + t.ToString();
                if (t < 8)
                {
                    lb.Location = new System.Drawing.Point(lbl, 18);

                    txt.Location = new System.Drawing.Point(lbl, 36);
                    lbl += 94;
                }
                else if (t < 16)
                {
                    lb.Location = new System.Drawing.Point(lbl1, 60);
                    txt.Location = new System.Drawing.Point(lbl1, 78);
                    lbl1 += 94;
                }
                lb.Size = new System.Drawing.Size(37, 15);
                txt.Size = new System.Drawing.Size(90, 22);

                lbe[t] = lb;
                txte[t] = txt;

            }
        }

        public void load_txtd()
        {
            int lbl = 6, lbl1 = 7;
            for (int t = 0; t < 16; t++)
            {
                Label lb1 = new Label();
                TextBoxX.TextBoxX txt1 = new TextBoxX.TextBoxX();
                txt1.Name = "txte" + t.ToString();
                lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb1.Name = "lble" + t.ToString();
                if (t < 8)
                {
                    lb1.Location = new System.Drawing.Point(lbl, 18);

                    txt1.Location = new System.Drawing.Point(lbl, 36);
                    lbl += 94;
                }
                else if (t < 16)
                {
                    lb1.Location = new System.Drawing.Point(lbl1, 60);
                    txt1.Location = new System.Drawing.Point(lbl1, 78);
                    lbl1 += 94;
                }
                lb1.Size = new System.Drawing.Size(37, 15);
                txt1.Size = new System.Drawing.Size(90, 22);
                lbd[t] = lb1;
                txtd[t] = txt1;
            }
        }

        public void sal_total()
        {
            double e1 = 0, d1 = 0;
            totpf = 0;

            for (int tc = 0; tc < 16; tc++)
            {

                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbe[tc];
                if (lbe[tc] != null && ll.Text.Trim() != "")
                {
                    if (head_formula.ContainsKey(ll.Text.Trim()))
                    {
                        tx = txte[tc];
                        if (hsh_rtype.ContainsKey(ll.Text.Trim()))
                            tx.Text = Convert.ToString(Math.Round(Convert.ToDouble(cal_formula(Convert.ToInt32(head_formula[ll.Text.Trim()])))));
                        else
                        {
                            //string amt = string.Format("{0:F}", Convert.ToDouble(cal_formula(Convert.ToInt32(head_formula[ll.Text.Trim()]))));
                            string amt = string.Format("{0:F}", (Math.Round(Convert.ToDouble(cal_formula(Convert.ToInt32(head_formula[ll.Text.Trim()]))))));
                            tx.Text = amt;
                        }

                        if (tx.Text == "")
                        {
                            tx.Text = "0";
                        }


                        txte[tc] = tx;

                    }
                    if (hsh_cmp_lumpsum.ContainsKey(ll.Text.Trim()))
                    {
                        tx = txte[tc];
                        if (hsh_rtype.ContainsKey(ll.Text.Trim()))
                            tx.Text = Convert.ToString(Math.Round(Convert.ToDouble(cal_Cmp_Lumpsum(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()])))));
                        else
                        {
                            if (tc == 0)
                            {
                                if (Information.IsNumeric(txtattendence.Text) == true)
                                {
                                    int Cur_Month = AttenDtTmPkr.Value.Month;
                                    //int Month_Day = Day_count(Cur_Month);
                                    int Month_Day = Convert.ToInt32(txtcalculated_days.Text);
                                    string lum_amt = cal_Cmp_Lumpsum(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()]));
                                    if (Information.IsNumeric(lum_amt) == false)
                                        lum_amt = "0";
                                    double amt = (Convert.ToDouble(lum_amt) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                    //tx.Text = Convert.ToString(Math.Round(amt)); string.Format("{0:F}", e1);
                                    tx.Text = string.Format("{0:F}", amt);

                                    //string besc_PF = cal_Cmp_LumpsumPF(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()]));
                                    //besc_PF_Amt = (Convert.ToDouble(besc_PF) * Convert.ToDouble(txtattendence.Text)) / Month_Day;
                                }
                                else
                                    tx.Text = cal_Cmp_Lumpsum(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()]));
                            }
                            else
                                tx.Text = cal_Cmp_Lumpsum(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()]));
                        }

                        if (tx.Text == "")
                        {
                            tx.Text = "0";
                        }
                        txte[tc] = tx;

                    }


                    //if (hsh_slab.ContainsKey(ll.Text.Trim()))
                    //{
                    //    tx = txte[tc];
                    //    tx.Text = cal_Slab(Convert.ToInt32(hsh_slab[ll.Text.Trim()]), e1);
                    //    txte[tc] = tx;
                    //    this.grpern.Controls.Add(txte[tc]);
                    //}

                }

            }

            for (int tc = 0; tc < 16; tc++)
            {
                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbd[tc];
                if (lbd[tc] != null)
                {
                    if (head_formula.ContainsKey(ll.Text.Trim()))
                    {
                        tx = txtd[tc];
                        if (hsh_rtype.ContainsKey(ll.Text.Trim()))
                            tx.Text = Convert.ToString(Math.Round(Convert.ToDouble(cal_formula(Convert.ToInt32(head_formula[ll.Text.Trim()])))));
                        else
                            tx.Text = string.Format("{0:F}", (Math.Round(Convert.ToDouble(cal_formula(Convert.ToInt32(head_formula[ll.Text.Trim()]))))));

                        if (tx.Text == "")
                        {
                            tx.Text = "0";
                        }
                        txtd[tc] = tx;

                    }
                    if (hsh_cmp_lumpsum.ContainsKey(ll.Text.Trim()))
                    {
                        tx = txtd[tc];
                        if (hsh_rtype.ContainsKey(ll.Text.Trim()))
                            tx.Text = Convert.ToString(Math.Round(Convert.ToDouble(cal_Cmp_Lumpsum(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()])))));
                        else
                            tx.Text = cal_Cmp_Lumpsum(Convert.ToInt32(hsh_cmp_lumpsum[ll.Text.Trim()]));

                        if (tx.Text == "")
                        {
                            tx.Text = "0";
                        }
                        txtd[tc] = tx;

                    }
                    //if (hsh_slab.ContainsKey(ll.Text.Trim()))
                    //{
                    //    tx = txtd[tc];
                    //    tx.Text = cal_Slab(Convert.ToInt32(hsh_slab[ll.Text.Trim()]));
                    //    txtd[tc] = tx;
                    //    this.grpded.Controls.Add(txtd[tc]);
                    //}
                }
            }

            for (int tc = 0; tc < 16; tc++)
            {
                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbe[tc];
                tx = txte[tc];
                if (tx.Text != "" && ll.Text != "")
                    e1 = e1 + Convert.ToDouble(tx.Text.Trim());
                tx = txtd[tc];
                ll = lbd[tc];
                if (tx.Text != "" && ll.Text != "")
                    d1 = d1 + Convert.ToDouble(tx.Text.Trim());
            }
            //************************
            for (int tc = 0; tc < 16; tc++)
            {

                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbe[tc];
                if (lbe[tc] != null)
                {
                    if (hsh_slab.ContainsKey(ll.Text.Trim()))
                    {
                        tx = txte[tc];
                        if (hsh_rtype.ContainsKey(ll.Text.Trim()))
                            tx.Text = Convert.ToString(Math.Round(Convert.ToDouble(cal_Slab(Convert.ToInt32(hsh_slab[ll.Text.Trim()]), e1))));
                        else
                            tx.Text = cal_Slab(Convert.ToInt32(hsh_slab[ll.Text.Trim()]), e1);
                        txte[tc] = tx;
                    }
                }
            }

            for (int tc = 0; tc < 16; tc++)
            {

                Label ll = new Label();
                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                ll = lbd[tc];
                if (lbd[tc] != null)
                {

                    if (hsh_slab.ContainsKey(ll.Text.Trim()))
                    {
                        tx = txtd[tc];
                        if (hsh_rtype.ContainsKey(ll.Text.Trim()))
                            tx.Text = Convert.ToString(Math.Round(Convert.ToDouble(cal_Slab(Convert.ToInt32(hsh_slab[ll.Text.Trim()]), e1))));//e1
                        else
                            tx.Text = cal_Slab(Convert.ToInt32(hsh_slab[ll.Text.Trim()]), e1);
                        txtd[tc] = tx;
                    }
                }
            }
            //*************************

            //for (int p = 0; p < 3; p++)
            //{
            //    Label lb = new Label();
            //    TextBoxX.TextBoxX tx1 = new TextBoxX.TextBoxX();
            //    lb = lbp[p];
            //    tx1 = txtp[p];
            //    if (tx1.Text.Trim() != "")
            //    {
            //        d1 += Convert.ToDouble(tx1.Text.Trim());
            //        if (lb.Text.Trim() != "ESI" && lb.Text.Trim() != "")
            //        {
            //            totpf += Convert.ToDouble(tx1.Text.Trim());
            //            if (!hsh_chk_SalPFHead.ContainsKey(get_sal_head_ID(lb.Text.Trim())))
            //                hsh_chk_SalPFHead.Add(get_sal_head_ID(lb.Text.Trim()), "");
            //        }
            //    }
            //    //else
            //    //{

            //    if (lb.Text.Trim() == "PFL" && lb.Text.Trim() != "")
            //    {
            //        pfloan_cal();
            //        if (!hsh_chk_SalPFHead.ContainsKey(get_sal_head_ID(lb.Text.Trim())))
            //            hsh_chk_SalPFHead.Add(get_sal_head_ID(lb.Text.Trim()), "");
            //        tx1 = txtp[1];
            //        if (tx1.Text.Trim() == "")
            //            tx1.Text = "0.00";


            //        txtp[1] = tx1;
            //    }
            //    if (lb.Text.Trim() == "PFLI" && lb.Text.Trim() != "")
            //    {
            //        tx1 = txtp[2];
            //        if (tx1.Text.Trim() == "")
            //            tx1.Text = "0.00";


            //        txtp[2] = tx1;
            //    }


            //    //if (lb.Text.Trim() != "ESI" && lb.Text.Trim()!="")
            //    //{
            //    //    tx1.Text = "0.00";
            //    //    if (!hsh_chk_SalPFHead.ContainsKey(get_sal_head_ID(lb.Text.Trim())))
            //    //        hsh_chk_SalPFHead.Add(get_sal_head_ID(lb.Text.Trim()), "");
            //    //    txtp[p] = tx1;
            //    //}

            //    //}
            //}

            //if (txteot1.Text.Trim() != "")
            //    e1 += Convert.ToDouble(txteot1.Text.Trim());

            //if (txteot2.Text.Trim() != "")
            //    e1 += Convert.ToDouble(txteot2.Text.Trim());



            //if (txtd19.Text.Trim() != "")
            //{
            //    d1 += Convert.ToDouble(txtd19.Text.Trim());
            //    //if (!hsh_chk_PT.ContainsKey("1"))
            //    //    hsh_chk_PT.Add("1", "");
            //}
            //if (txtd20.Text.Trim() != "")
            //{
            //    d1 += Convert.ToDouble(txtd20.Text.Trim());
            //}
            //if (chkpfvol.Checked && txtpfvol.Text.Trim() != "")
            //{
            //    d1 += Convert.ToDouble(txtpfvol.Text.Trim());
            //}


            //txtetot.Text = string.Format("{0:F}", e1);
            //txtdtot.Text = string.Format("{0:F}", d1);
            //txtnetamt.Text = string.Format("{0:F}", ((Convert.ToDouble(txtetot.Text.Trim()) - Convert.ToDouble(txtdtot.Text.Trim())) + LeaveAmt));

        }

        public void pfloan_cal()
        {
            //string s = "", eid = "", s1 = "";
            //double pflirate = 0;
            //PFSno = 0;
            //if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
            //    eid = emp_id[cmbempname1111.Text.Trim()].ToString();

            //s = "select LoanAmount,NoOfInstallment,InterestRate,LoanRepaid,SerialNo from tbl_Employee_PF_Loan where empcode='" + eid + "' and PFSession='" + cmbYear.Text.Trim() + "' and LoanType=1";
            //DataTable dtloan = new DataTable();
            //DataTable dtloan1 = new DataTable();
            //dtloan = clsDataAccess.RunQDTbl(s);
            //if (dtloan.Rows.Count > 0)
            //{
            //    for (int pfl = 0; pfl < dtloan.Rows.Count; pfl++)
            //    {
            //        if (Convert.ToDouble(dtloan.Rows[pfl][0]) > Convert.ToDouble(dtloan.Rows[pfl][3]))
            //        {
            //            TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
            //            tx = txtp[1];
            //            tx.Text = string.Format("{0:F}", Math.Round(Convert.ToDouble(Convert.ToDouble(dtloan.Rows[0][0]) / Convert.ToDouble(dtloan.Rows[pfl][1]))));

            //            txtp[1] = tx;

            //            //this.grpded.Controls.Add(txtp[1]);
            //            //s1 = "select amount from tbl_Employee_SalaryDet where EmpId='" + eid + "' and Session='" + cmbYear.Text.Trim() + "' and TableName='tbl_Employee_Config_PFHeads' and SalId=2";
            //            //dtloan1 = clsDataAccess.RunQDTbl(s1);
            //            //if (dtloan1.Rows.Count > 0)
            //            //{
            //            //    for (int x = 0; x < dtloan1.Rows.Count; x++)
            //            //    {
            //            //        pflirate += Convert.ToDouble(dtloan1.Rows[x][0]);
            //            //    }

            //            //}
            //            pflirate = Convert.ToDouble(((Convert.ToDouble(dtloan.Rows[pfl][0]) - Convert.ToDouble(dtloan.Rows[pfl][3])) * (Convert.ToDouble(dtloan.Rows[pfl][2]) / 100)) / 12);

            //            tx = txtp[2];
            //            tx.Text = string.Format("{0:F}", pflirate);

            //            txtp[2] = tx;

            //            this.grpded.Controls.Add(txtp[2]);
            //            PFSno = Convert.ToInt32(dtloan.Rows[pfl][4]);
            //        }
            //    }
            //}

        }


        public string cal_Cmp_Lumpsum(int lump_type)
        {
            string res = "", s = "";

            s = "Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + lump_type + " and GRADE =" + deg_id + " ";
            if (s == "")
                s = "Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + lump_type + " and GRADE ='0' ";
            DataTable dttemp = new DataTable();
            dttemp = clsDataAccess.RunQDTbl(s);
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0][0].ToString() != "")
                    res = dttemp.Rows[0][0].ToString();
            }
            else
            {
                s = "Select AMOUNT from tbl_Employee_Lumpsum where LUMPID =" + lump_type + " and GRADE ='0' ";

                dttemp = clsDataAccess.RunQDTbl(s);
                if (dttemp.Rows.Count > 0)
                {
                    if (dttemp.Rows[0][0].ToString() != "")
                        res = dttemp.Rows[0][0].ToString();
                }
            }
            return res;
        }

        public string cal_Cmp_LumpsumPF(int lump_type)
        {
            string res = "", s = "";

            s = "Select Pf_Amt from tbl_Employee_Lumpsum where LUMPID =" + lump_type + " and GRADE =" + deg_id + " ";
            if (s == "")
                s = "Select Pf_Amt from tbl_Employee_Lumpsum where LUMPID =" + lump_type + " and GRADE ='0' ";
            DataTable dttemp = new DataTable();
            dttemp = clsDataAccess.RunQDTbl(s);
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0][0].ToString() != "")
                    res = dttemp.Rows[0][0].ToString();
            }
            return res;
        }

        public int get_sal_head_ID(string head)
        {

            string s = "";
            int pb = 0, opt = 0;
            DataTable dt1 = new DataTable();

            s = "select SalaryHead_Short,slno from tbl_Employee_ErnSalaryHead";
            dt1 = clsDataAccess.RunQDTbl(s);
            if (dt1.Rows.Count > 0)
            {
                for (int f = 0; f < dt1.Rows.Count; f++)
                {
                    if (dt1.Rows[f][0].ToString() == head)
                    {
                        pb = Convert.ToInt32(dt1.Rows[f][1]);
                        break;
                    }
                }

            }

            dt1.Clear();
            dt1.Columns.Clear();
            s = "select SalaryHead_Short,slno from tbl_Employee_DeductionSalayHead";
            dt1 = clsDataAccess.RunQDTbl(s);
            if (dt1.Rows.Count > 0)
            {
                for (int f = 0; f < dt1.Rows.Count; f++)
                {
                    if (dt1.Rows[f][0].ToString() == head)
                    {
                        pb = Convert.ToInt32(dt1.Rows[f][1]);
                        break;
                    }
                }

            }

            dt1.Clear();
            dt1.Columns.Clear();
            s = "select ShortName,SlNo from tbl_Employee_Config_PFHeads";
            dt1 = clsDataAccess.RunQDTbl(s);
            if (dt1.Rows.Count > 0)
            {
                for (int f = 0; f < dt1.Rows.Count; f++)
                {
                    if (dt1.Rows[f][0].ToString() == head)
                        pb = Convert.ToInt32(dt1.Rows[f][1]);
                }

            }

            //testless
            dt1.Clear();
            dt1.Columns.Clear();
            s = "select SalaryHead_Full,slno from tbl_Employer_Contribution";
            dt1 = clsDataAccess.RunQDTbl(s);
            if (dt1.Rows.Count > 0)
            {
                for (int f = 0; f < dt1.Rows.Count; f++)
                {
                    if (dt1.Rows[f][0].ToString() == head)
                        pb = Convert.ToInt32(dt1.Rows[f][1]);
                }

            }
            //testless


            return pb;
        }

        public string cal_Slab(int slab_type, double erntot)
        {
            string res = "", s = "";
            s = "select amt,maxim from tbl_Employee_Slab_Det where slabid=" + slab_type + " and mini<=" + erntot;

            DataTable dttemp = new DataTable();
            dttemp = clsDataAccess.RunQDTbl(s);
            if (dttemp.Rows.Count > 0)
            {
                for (int j = 0; j < dttemp.Rows.Count; j++)
                {
                    if (dttemp.Rows[j][1].ToString().Trim() != "Max. Value" && Convert.ToInt32(dttemp.Rows[j][1]) >= erntot)
                    {
                        res = dttemp.Rows[j][0].ToString();
                    }
                    else
                        res = dttemp.Rows[j][0].ToString();
                }
            }
            return res;
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        public string cal_formula(int id)
        {
            string sal_struct = " + salary_structure + ";

            string exp = "", s = "", res = "", s1 = "";
            int g = 0, i = 0, p = 0;
            s = "select fexp from tbl_Employee_Sal_Structure_Formula where fid=" + id;
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            string a = dt.Rows[0][0].ToString().Trim();

            s1 = "select c_basis from tbl_Employee_Assign_SalStructure where (C_DET=" + id + ") and (sal_struct=" + salary_structure + ")";
            DataTable dt7 = new DataTable();
            dt7 = clsDataAccess.RunQDTbl(s1);
            string a3 = dt7.Rows[0][0].ToString().Trim();
            //string gs = dt7.Rows[0][1].ToString().Trim();
            //string ptype = dt7.Rows[0][2].ToString().Trim();

            if (dt.Rows.Count > 0)
            {
                res = puttingValueInFormula(a, g, i, p, dt, exp, a3, res);
            }
            return res;
        }
        public string cal_formula_desg(int id, int desgid)
        {
            string sal_struct = " + salary_structure + ";

            string exp = "", s = "", res = "", s1 = "";
            int g = 0, i = 0, p = 0;
            s = "(select FName from tbl_Employee_Sal_Structure_Formula where (fid=" + id + "))";

            string fname = clsDataAccess.ReturnValue(s);

            s = "Select (case when (select count(*) from tbl_Employee_Sal_Structure_Formula where (FName='" + fname + "') and (desgid=" + desgid + "))>0 then (select FExp from tbl_Employee_Sal_Structure_Formula where (FName='" + fname + "') and (desgid=" + desgid + ")) else (select FExp from tbl_Employee_Sal_Structure_Formula where FName='" + fname + "' and desgid=0) end) from tbl_Employee_Sal_Structure_Formula where (FName='" + fname + "')";//and (desgid=" + desgid + ")";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            string a = dt.Rows[0][0].ToString().Trim();

            s1 = "select c_basis from tbl_Employee_Assign_SalStructure where (C_DET=" + id + ") and (sal_struct=" + salary_structure + ")";
            DataTable dt7 = new DataTable();
            dt7 = clsDataAccess.RunQDTbl(s1);
            string a3 = dt7.Rows[0][0].ToString().Trim();
            //string gs = dt7.Rows[0][1].ToString().Trim();
            //string ptype = dt7.Rows[0][2].ToString().Trim();

            if (dt.Rows.Count > 0)
            {
                res = puttingValueInFormula(a, g, i, p, dt, exp, a3, res);
            }

            if (res.Trim() == "")
            {
                res = "0";
            }
            return res;
        }

        public string cal_formula(int id, int grade, int type)
        {
            string sal_struct = " + salary_structure + ";

            string exp = "", s = "", res = "", s1 = "";
            int g = 0, i = 0, p = 0;
            DataTable dtCalc = new DataTable();

            s = "select fexp from tbl_Employee_Sal_Structure_Formula where fname=(select FName from tbl_Employee_Sal_Structure_Formula where fid=" + id + ") and (desgid=" + grade + ")";
            //s = "select fexp from tbl_Employee_Sal_Structure_Formula where fid=" + id;
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);

            if (dt.Rows.Count == 0)
            {
                s = "select fexp from tbl_Employee_Sal_Structure_Formula where fname=(select FName from tbl_Employee_Sal_Structure_Formula where fid=" + id + ") and (desgid=0)";

                dt = clsDataAccess.RunQDTbl(s);
            }
            string a = dt.Rows[0][0].ToString().Trim();

            s1 = "select c_basis from tbl_Employee_Assign_SalStructure where C_DET=" + id + "  and Location_id=" + Locations + " ";
            DataTable dt7 = new DataTable();
            dt7 = clsDataAccess.RunQDTbl(s1);
            string a3 = dt7.Rows[0][0].ToString().Trim();


            if (dt.Rows.Count > 0)
            {

                // below code for conditiopnal and added valu with some other heads 
                if (a.Contains("<") || a.Contains(">"))
                {
                    int pos33 = a.IndexOf("(");
                    int pos34 = a.IndexOf(")");
                    string data33 = getBetween(a, "(", ")");
                    string b1 = "";
                    if (pos33 == 0)
                    {
                        b1 = "0";
                    }
                    else
                    {
                        b1 = a.ToString().Trim().Substring(0, pos33);
                    }

                    int pos35 = a.IndexOf(">");
                    pos35 = pos35 + 1;
                    string b2 = a.ToString().Trim().Substring(pos35);

                    dt.Rows[0][0] = b1;
                    dt.Rows.Add();
                    dt.Rows[1][0] = data33;

                    string val1 = "";
                    string val2 = "";

                    for (int x = 0; x <= dt.Rows.Count - 1; x++)
                    {
                        if (x == 0)
                        {
                            for (int f = 0; f < dt.Rows[x][0].ToString().Trim().Length; f++)
                            {
                                if (dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "=" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "*" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "+" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "-" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "/" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "%" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "(" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == ")")
                                {
                                    if (SalHead1.ContainsKey(dt.Rows[x][0].ToString().Trim().Substring(g, i)))
                                    {
                                        for (int lt = 0; lt < lbe.Length; lt++)
                                        {
                                            Label l = new Label();
                                            TextBoxX.TextBoxX t = new TextBoxX.TextBoxX();
                                            l = lbe[lt];
                                            t = txte[lt];
                                            string te = SalHead1[dt.Rows[x][0].ToString().Trim().Substring(g, i)].ToString();
                                            if (lbe[lt] != null && l.Text.Trim() == SalHead1[dt.Rows[x][0].ToString().Trim().Substring(g, i)].ToString())
                                            {
                                                exp += t.Text.Trim() + dt.Rows[x][0].ToString().Trim().Substring(f, 1);
                                            }
                                        }
                                    }
                                    else
                                        exp += dt.Rows[x][0].ToString().Trim().Substring(g, i) + dt.Rows[x][0].ToString().Trim().Substring(f, 1);
                                    i = 0;
                                    g = f + 1;
                                }
                                else
                                    i++;
                            }
                            exp += dt.Rows[0][0].ToString().Trim().Substring(g, i);
                            val1 = f_cal(exp);
                            //res = f_cal(exp);
                        }
                        else
                        {
                            exp = "";
                            g = 0;
                            for (int f = 0; f < dt.Rows[x][0].ToString().Trim().Length; f++)
                            {
                                if (dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "=" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "*" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "+" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "-" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "/" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "%" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "(" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == ")")
                                {
                                    if (SalHead1.ContainsKey(dt.Rows[x][0].ToString().Trim().Substring(g, p)))
                                    {
                                        for (int lt = 0; lt < lbe.Length; lt++)
                                        {
                                            Label l = new Label();
                                            TextBoxX.TextBoxX t = new TextBoxX.TextBoxX();
                                            l = lbe[lt];
                                            t = txte[lt];
                                            string te = SalHead1[dt.Rows[x][0].ToString().Trim().Substring(g, p)].ToString();
                                            if (lbe[lt] != null && l.Text.Trim() == SalHead1[dt.Rows[x][0].ToString().Trim().Substring(g, p)].ToString())
                                            {
                                                exp += t.Text.Trim() + dt.Rows[x][0].ToString().Trim().Substring(f, 1);
                                            }
                                        }
                                    }
                                    else
                                        exp += dt.Rows[x][0].ToString().Trim().Substring(g, p) + dt.Rows[x][0].ToString().Trim().Substring(f, 1);
                                    p = 0;
                                    g = f + 1;
                                }
                                else
                                    p++;
                            }
                            exp += dt.Rows[x][0].ToString().Trim().Substring(g, p);
                            val2 = f_cal(exp);

                            if (Convert.ToDouble(val2) > Convert.ToDouble(b2))
                            {
                                if (a3 == "Conditional")
                                {
                                    res = Convert.ToString((Convert.ToDouble(val1) + Convert.ToDouble(b2)));

                                }
                                else
                                {
                                    res = Convert.ToString((Convert.ToDouble(val1) + Convert.ToDouble(b2) + (Convert.ToDouble(val2) - Convert.ToDouble(b2))));
                                    //res =  Convert.ToString(Convert.ToDouble(val2) - Convert.ToDouble(b2));

                                }

                            }
                            else
                            {
                                if (a3 == "Conditional")
                                {
                                    res = Convert.ToString((Convert.ToDouble(val1) + Convert.ToDouble(val2)));

                                }
                                else
                                {
                                    res = Convert.ToString(Convert.ToDouble(val1) + Convert.ToDouble(val2));

                                }

                            }

                            //res = res;
                        }

                    }

                    // End of coditional value added with some other heads

                }
                else
                {
                    for (int f = 0; f < dt.Rows[0][0].ToString().Trim().Length; f++)
                    {
                        if (dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "=" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "*" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "+" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "-" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "/" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "%" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "(" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == ")")
                        {
                            if (SalHead1.ContainsKey(dt.Rows[0][0].ToString().Trim().Substring(g, i)))
                            {
                                for (int lt = 0; lt < lbe.Length; lt++)
                                {
                                    Label l = new Label();
                                    TextBoxX.TextBoxX t = new TextBoxX.TextBoxX();

                                    Label ld = new Label();
                                    TextBoxX.TextBoxX td = new TextBoxX.TextBoxX();

                                    l = lbe[lt];
                                    t = txte[lt];
                                    //try
                                    //{
                                    //    if (t.Text.Trim() == "")
                                    //    {
                                    //        t.Text = "0";
                                    //    }
                                    //}
                                    //catch { }

                                    ld = lbd[lt];
                                    td = txtd[lt];
                                    //try
                                    //{
                                    //    if (td.Text.Trim() == "")
                                    //    {
                                    //        td.Text = "0";
                                    //    }
                                    //}
                                    //catch { }
                                    string te = SalHead1[dt.Rows[0][0].ToString().Trim().Substring(g, i)].ToString();
                                    if (lbe[lt] != null && l.Text.Trim() == SalHead1[dt.Rows[0][0].ToString().Trim().Substring(g, i)].ToString())
                                    {
                                        try
                                        {
                                            if (val_pf == 2)
                                            {
                                                exp += t.Text.Trim() + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                            }
                                            else if (val_pf == 15000)
                                            {
                                                if (Convert.ToDouble(t.Text) < 15000)
                                                {
                                                    exp += t.Text.Trim() + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                                }
                                                else
                                                {
                                                    exp += "15000" + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                                }
                                            }
                                            else
                                            {


                                                exp += t.Text.Trim() + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    else if (lbd[lt] != null && ld.Text.Trim() == SalHead1[dt.Rows[0][0].ToString().Trim().Substring(g, i)].ToString())
                                    {
                                        try
                                        {
                                            if (val_pf == 2)
                                            {
                                                exp += td.Text.Trim() + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                            }
                                            else if (val_pf == 15000)
                                            {
                                                if (Convert.ToDouble(td.Text) < 15000)
                                                {
                                                    exp += td.Text.Trim() + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                                }
                                                else
                                                {
                                                    exp += "15000" + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                                }
                                            }
                                            else
                                            {


                                                exp += td.Text.Trim() + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    exp += dt.Rows[0][0].ToString().Trim().Substring(g, i) + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                }
                                catch
                                {

                                }
                            }
                            i = 0;
                            g = f + 1;
                        }
                        else
                            i++;
                    }
                    exp += dt.Rows[0][0].ToString().Trim().Substring(g, i);

                    if (type == 2)
                    {
                        res = dtCalc.Compute(exp, "").ToString();
                    }
                    else
                    {
                        res = f_cal(exp);
                    }
                }



            }
            return res;
        }

        public string cal_formula_pfesi(int id, int desgid)
        {
            string sal_struct = " + salary_structure + ";

            string exp = "", s = "", res = "", s1 = "";
            int g = 0, i = 0, p = 0;
            /*
            s = "select fexp from tbl_Employee_Sal_Structure_Formula where fid=" + id;
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            string a = dt.Rows[0][0].ToString().Trim();
            */

            s = "(select FName from tbl_Employee_Sal_Structure_Formula where (fid=" + id + "))";

            string fname = clsDataAccess.ReturnValue(s);

            s = "Select (case when (select count(*) from tbl_Employee_Sal_Structure_Formula where (FName='" + fname + "') and (desgid=" + desgid + "))>0 then (select FExp from tbl_Employee_Sal_Structure_Formula where (FName='" + fname + "') and (desgid=" + desgid + ")) else (select FExp from tbl_Employee_Sal_Structure_Formula where FName='" + fname + "' and desgid=0) end) from tbl_Employee_Sal_Structure_Formula where (FName='" + fname + "')";//and (desgid=" + desgid + ")";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);

            string a = "0";

            try
            {
                a = dt.Rows[0][0].ToString().Trim();
            }
            catch { a = "0"; }

            s1 = "select c_basis from tbl_Employee_Assign_SalStructure where C_DET=" + id + "  and sal_struct=" + salary_structure + " ";
            DataTable dt7 = new DataTable();
            dt7 = clsDataAccess.RunQDTbl(s1);
            string a3 = dt7.Rows[0][0].ToString().Trim();

            string[] hd_val = a.Split('*');
            dt.Rows[0][0] = hd_val[0] + "+0";
            a = hd_val[0] + "+0";
            if (dt.Rows.Count > 0)
            {
                res = puttingValue(a, g, i, p, dt, exp, a3, res);
            }
            return res;
        }



        private string puttingValue(string actualExpression, int g, int i, int p, DataTable dt, string exp, string a3, string res)
        {
            // below code for conditiopnal and added value with some other heads
            /////////////////////////in progress//////////////////////////////
            string a;
            a = actualExpression;
            int posofclosingb;
            if (a.IndexOf("trunc(") > -1)
            {
                posofclosingb = 0;
                string expintrunc = a.Substring(a.IndexOf("trunc(") + 6, a.LastIndexOf(")") - (a.IndexOf("trunc(") + 6));
                Stack<char> obStack = new Stack<char>();
                foreach (char c in expintrunc)
                {
                    if (c == '(')
                    {
                        obStack.Push('(');

                    }
                    else if (c == ')')
                    {
                        obStack.Pop();
                        if (obStack.Count == 0)
                        {
                            break;
                        }
                    }
                    posofclosingb++;
                }
                expintrunc = a.Substring(a.IndexOf("trunc(") + 6, posofclosingb);
                DataTable dt1 = new DataTable();
                dt1.Columns.Add();
                dt1.Rows.Add();
                dt1.Rows[0][0] = expintrunc;
                string result;
                result = Trunc(puttingValueInFormula(expintrunc, g, i, p, dt1, exp, a3, res));
                a = a.Replace("trunc(" + expintrunc + ")", result);
                dt.Rows[0][0] = a;

            }
            ///////////////////////////////////////////////////////////////////
            if (a.Contains("<") || a.Contains(">"))
            {
                int pos33 = a.IndexOf("(");
                int pos34 = a.IndexOf(")");
                string data33 = getBetween(a, "(", ")");
                string b1 = "";
                if (pos33 == 0)
                {
                    b1 = "0";
                }
                else
                {
                    b1 = a.ToString().Trim().Substring(0, pos33);
                }

                int pos35 = a.IndexOf(">");
                pos35 = pos35 + 1;
                string b2 = a.ToString().Trim().Substring(pos35);

                dt.Rows[0][0] = b1;
                dt.Rows.Add();
                dt.Rows[1][0] = data33;

                string val1 = "";
                string val2 = "";

                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                {
                    if (x == 0)
                    {
                        for (int f = 0; f < dt.Rows[x][0].ToString().Trim().Length; f++)
                        {
                            if (dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "=" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "*" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "+" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "-" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "/" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "%" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "(" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == ")")
                            {
                                if (SalHead1.ContainsKey(dt.Rows[x][0].ToString().Trim().Substring(g, i)))
                                {
                                    for (int lt = 0; lt < lbe.Length; lt++)
                                    {
                                        Label l = new Label();
                                        TextBoxX.TextBoxX t = new TextBoxX.TextBoxX();
                                        l = lbe[lt];
                                        t = txte[lt];
                                        string te = SalHead1[dt.Rows[x][0].ToString().Trim().Substring(g, i)].ToString();
                                        if (lbe[lt] != null && l.Text.Trim() == SalHead1[dt.Rows[x][0].ToString().Trim().Substring(g, i)].ToString())
                                        {
                                            exp += t.Text.Trim() + dt.Rows[x][0].ToString().Trim().Substring(f, 1);
                                        }
                                    }
                                }
                                else
                                    exp += dt.Rows[x][0].ToString().Trim().Substring(g, i) + dt.Rows[x][0].ToString().Trim().Substring(f, 1);
                                i = 0;
                                g = f + 1;
                            }
                            else
                                i++;
                        }
                        exp += dt.Rows[0][0].ToString().Trim().Substring(g, i);
                        val1 = f_cal(exp);
                        //res = f_cal(exp);
                    }
                    else
                    {
                        exp = "";
                        g = 0;
                        for (int f = 0; f < dt.Rows[x][0].ToString().Trim().Length; f++)
                        {
                            if (dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "=" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "*" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "+" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "-" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "/" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "%" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "(" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == ")")
                            {
                                if (SalHead1.ContainsKey(dt.Rows[x][0].ToString().Trim().Substring(g, p)))
                                {
                                    for (int lt = 0; lt < lbe.Length; lt++)
                                    {
                                        Label l = new Label();
                                        TextBoxX.TextBoxX t = new TextBoxX.TextBoxX();
                                        l = lbe[lt];
                                        t = txte[lt];
                                        string te = SalHead1[dt.Rows[x][0].ToString().Trim().Substring(g, p)].ToString();
                                        if (lbe[lt] != null && l.Text.Trim() == SalHead1[dt.Rows[x][0].ToString().Trim().Substring(g, p)].ToString())
                                        {
                                            exp += t.Text.Trim() + dt.Rows[x][0].ToString().Trim().Substring(f, 1);
                                        }
                                    }
                                }
                                else
                                    exp += dt.Rows[x][0].ToString().Trim().Substring(g, p) + dt.Rows[x][0].ToString().Trim().Substring(f, 1);
                                p = 0;
                                g = f + 1;
                            }
                            else
                                p++;
                        }
                        exp += dt.Rows[x][0].ToString().Trim().Substring(g, p);
                        val2 = f_cal(exp);

                        if (Convert.ToDouble(val2) > Convert.ToDouble(b2))
                        {
                            if (a3 == "Conditional")
                            {
                                res = Convert.ToString((Convert.ToDouble(val1) + Convert.ToDouble(b2)));

                            }
                            else
                            {
                                res = Convert.ToString((Convert.ToDouble(val1) + Convert.ToDouble(b2) + (Convert.ToDouble(val2) - Convert.ToDouble(b2))));
                                //res =  Convert.ToString(Convert.ToDouble(val2) - Convert.ToDouble(b2));

                            }

                        }
                        else
                        {
                            if (a3 == "Conditional")
                            {
                                res = Convert.ToString((Convert.ToDouble(val1) + Convert.ToDouble(val2)));

                            }
                            else
                            {
                                res = Convert.ToString(Convert.ToDouble(val1) + Convert.ToDouble(val2));

                            }

                        }

                        //res = res;
                    }

                }

                // End of coditional value added with some other heads

            }
            else
            {
                for (int f = 0; f < dt.Rows[0][0].ToString().Trim().Length; f++)
                {
                    if (dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "=" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "*" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "+" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "-" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "/" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "%" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "(" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == ")")
                    {
                        if (SalHead1.ContainsKey(dt.Rows[0][0].ToString().Trim().Substring(g, i)))
                        {
                            for (int lt = 0; lt < lbe.Length; lt++)
                            {
                                Label l = new Label();
                                TextBoxX.TextBoxX t = new TextBoxX.TextBoxX();
                                l = lbe[lt];
                                t = txte[lt];
                                string te = SalHead1[dt.Rows[0][0].ToString().Trim().Substring(g, i)].ToString();
                                if (lbe[lt] != null && l.Text.Trim() == SalHead1[dt.Rows[0][0].ToString().Trim().Substring(g, i)].ToString())
                                {
                                    exp += t.Text.Trim() + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                }
                            }
                        }
                        else
                            exp += dt.Rows[0][0].ToString().Trim().Substring(g, i) + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                        i = 0;
                        g = f + 1;
                    }
                    else
                        i++;
                }
                exp += dt.Rows[0][0].ToString().Trim().Substring(g, i);

                string[] sr = exp.Split('*');

                try
                {
                    DataTable dt_exp = new DataTable();
                    var v = dt_exp.Compute(exp, "");
                    res = v.ToString();
                    //res = f_cal(exp);
                }
                catch
                {
                    res = f_cal(exp);
                }
                //res = f_cal(sr[0]);
            }
            return res;
        }

        private string puttingValueInFormula(string actualExpression, int g, int i, int p, DataTable dt, string exp, string a3, string res)
        {
            // below code for conditiopnal and added value with some other heads
            /////////////////////////in progress//////////////////////////////
            string a, type = "";
            a = actualExpression;
            int posofclosingb;
            if (a.IndexOf("trunc(") > -1)
            {
                posofclosingb = 0;
                string expintrunc = a.Substring(a.IndexOf("trunc(") + 6, a.LastIndexOf(")") - (a.IndexOf("trunc(") + 6));
                Stack<char> obStack = new Stack<char>();
                foreach (char c in expintrunc)
                {
                    if (c == '(')
                    {
                        obStack.Push('(');

                    }
                    else if (c == ')')
                    {
                        obStack.Pop();
                        if (obStack.Count == 0)
                        {
                            break;
                        }
                    }
                    posofclosingb++;
                }
                expintrunc = a.Substring(a.IndexOf("trunc(") + 6, posofclosingb);
                DataTable dt1 = new DataTable();
                dt1.Columns.Add();
                dt1.Rows.Add();
                dt1.Rows[0][0] = expintrunc;
                string result;
                result = Trunc(puttingValueInFormula(expintrunc, g, i, p, dt1, exp, a3, res));
                a = a.Replace("trunc(" + expintrunc + ")", result);
                dt.Rows[0][0] = a;

            }
            ///////////////////////////////////////////////////////////////////
            if (a.Contains("<") || a.Contains(">"))
            {
                int pos33 = a.IndexOf("(");
                int pos34 = a.IndexOf(")");
                string data33 = getBetween(a, "(", ")");
                string b1 = "";
                if (pos33 == 0)
                {
                    b1 = "0";
                }
                else
                {
                    b1 = a.ToString().Trim().Substring(0, pos33);
                }

                int pos35 = a.IndexOf(">");
                type = ">";
                if (pos35 < 0)
                {
                    pos35 = a.IndexOf("<");
                    type = "<";
                }
                pos35 = pos35 + 1;
                string b2 = a.ToString().Trim().Substring(pos35);


                try
                {
                    double bl = Convert.ToDouble(b2);
                }
                catch
                {
                    for (int lt = 0; lt < lbe.Length; lt++)
                    {
                        try
                        {

                            if (b2 == lbe[lt].Text)
                            {
                                b2 = txte[lt].Text;
                                break;
                            }
                        }
                        catch { }
                    }
                }
                dt.Rows[0][0] = b1;
                dt.Rows.Add();
                dt.Rows[1][0] = data33;

                string val1 = "";
                string val2 = "";

                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                {
                    if (x == 0)
                    {
                        for (int f = 0; f < dt.Rows[x][0].ToString().Trim().Length; f++)
                        {
                            if (dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "=" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "*" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "+" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "-" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "/" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "%" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "(" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == ")" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "<" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == ">")
                            {
                                if (SalHead1.ContainsKey(dt.Rows[x][0].ToString().Trim().Substring(g, i)))
                                {
                                    for (int lt = 0; lt < lbe.Length; lt++)
                                    {
                                        Label l = new Label();
                                        TextBoxX.TextBoxX t = new TextBoxX.TextBoxX();
                                        l = lbe[lt];
                                        t = txte[lt];
                                        string te = SalHead1[dt.Rows[x][0].ToString().Trim().Substring(g, i)].ToString();
                                        if (lbe[lt] != null && l.Text.Trim() == SalHead1[dt.Rows[x][0].ToString().Trim().Substring(g, i)].ToString())
                                        {
                                            exp += t.Text.Trim() + dt.Rows[x][0].ToString().Trim().Substring(f, 1);
                                        }
                                    }
                                }
                                else
                                    exp += dt.Rows[x][0].ToString().Trim().Substring(g, i) + dt.Rows[x][0].ToString().Trim().Substring(f, 1);
                                i = 0;
                                g = f + 1;
                            }
                            else
                                i++;
                        }
                        exp += dt.Rows[0][0].ToString().Trim().Substring(g, i);
                        val1 = f_cal(exp);
                        //res = f_cal(exp);
                    }
                    else
                    {
                        exp = "";
                        g = 0;
                        for (int f = 0; f < dt.Rows[x][0].ToString().Trim().Length; f++)
                        {
                            if (dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "=" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "*" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "+" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "-" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "/" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "%" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "(" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == ")" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == "<" || dt.Rows[x][0].ToString().Trim().Substring(f, 1) == ">")
                            {
                                if (SalHead1.ContainsKey(dt.Rows[x][0].ToString().Trim().Substring(g, p)))
                                {
                                    for (int lt = 0; lt < lbe.Length; lt++)
                                    {
                                        Label l = new Label();
                                        TextBoxX.TextBoxX t = new TextBoxX.TextBoxX();
                                        l = lbe[lt];
                                        t = txte[lt];
                                        string te = SalHead1[dt.Rows[x][0].ToString().Trim().Substring(g, p)].ToString();
                                        if (lbe[lt] != null && l.Text.Trim() == SalHead1[dt.Rows[x][0].ToString().Trim().Substring(g, p)].ToString())
                                        {
                                            exp += t.Text.Trim() + dt.Rows[x][0].ToString().Trim().Substring(f, 1);
                                        }
                                    }
                                }
                                else
                                    exp += dt.Rows[x][0].ToString().Trim().Substring(g, p) + dt.Rows[x][0].ToString().Trim().Substring(f, 1);
                                p = 0;
                                g = f + 1;
                            }
                            else
                                p++;
                        }
                        try
                        {
                            exp += dt.Rows[x][0].ToString().Trim().Substring(g, p);
                        }
                        catch { exp = dt.Rows[x][0].ToString().Trim(); }
                        val2 = f_cal(exp);


                        if (Convert.ToDouble(val2) > Convert.ToDouble(b2))
                        {
                            if (a3 == "Conditional")
                            {
                                if (type.Trim() == ">")
                                {
                                    res = Convert.ToString((Convert.ToDouble(val1) + Convert.ToDouble(val2)));
                                }
                                else if (type.Trim() == "<")
                                {
                                    res = b2;//  Convert.ToString((Convert.ToDouble(val1) + Convert.ToDouble(val2)));
                                }
                                //res = Convert.ToString((Convert.ToDouble(val1) + Convert.ToDouble(b2)));

                            }
                            else
                            {
                                res = Convert.ToString((Convert.ToDouble(val1) + Convert.ToDouble(b2) + (Convert.ToDouble(val2) - Convert.ToDouble(b2))));
                                //res =  Convert.ToString(Convert.ToDouble(val2) - Convert.ToDouble(b2));

                            }

                        }
                        else
                        {
                            if (a3 == "Conditional")
                            {
                                if (type.Trim() == ">")
                                {
                                    res = "0"; //Convert.ToString((Convert.ToDouble(val1) + Convert.ToDouble(val2)));
                                }
                                else if (type.Trim() == "<")
                                {
                                    res = Convert.ToString((Convert.ToDouble(val1) + Convert.ToDouble(val2)));
                                }

                            }
                            else
                            {
                                res = Convert.ToString(Convert.ToDouble(val1) + Convert.ToDouble(val2));

                            }

                        }


                        //res = res;
                    }

                }

                // End of coditional value added with some other heads

            }
            else
            {
                for (int f = 0; f < dt.Rows[0][0].ToString().Trim().Length; f++)
                {
                    if (dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "=" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "*" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "+" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "-" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "/" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "%" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "(" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == ")")
                    {
                        if (SalHead1.ContainsKey(dt.Rows[0][0].ToString().Trim().Substring(g, i)))
                        {
                            for (int lt = 0; lt < lbe.Length; lt++)
                            {
                                Label l = new Label();
                                TextBoxX.TextBoxX t = new TextBoxX.TextBoxX();
                                l = lbe[lt];
                                t = txte[lt];
                                string te = SalHead1[dt.Rows[0][0].ToString().Trim().Substring(g, i)].ToString();
                                if (lbe[lt] != null && l.Text.Trim() == SalHead1[dt.Rows[0][0].ToString().Trim().Substring(g, i)].ToString())
                                {
                                    exp += t.Text.Trim() + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                }
                            }
                        }
                        else
                            exp += dt.Rows[0][0].ToString().Trim().Substring(g, i) + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                        i = 0;
                        g = f + 1;
                    }
                    else
                        i++;
                }
                exp += dt.Rows[0][0].ToString().Trim().Substring(g, i);

                try
                {
                    DataTable dt_exp = new DataTable();
                    var v = dt_exp.Compute(exp, "");
                    res = v.ToString();
                    //res = f_cal(exp);
                }
                catch
                {
                    res = f_cal(exp);
                }
            }
            return res;
        }

        private string Trunc(string value)
        {
            if (value.IndexOf(".") > -1)
                value = value.Substring(0, value.IndexOf("."));
            return value;
        }

        public void GetSalaryHeads()
        {
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");

            for (Int32 i = 0; i < dtErn.Rows.Count; i++)
            {

                if (!SalHead1.ContainsKey(Gen_ID("S", dtErn.Rows[i][1].ToString())))
                    SalHead1.Add(Gen_ID("S", dtErn.Rows[i][1].ToString()), dtErn.Rows[i][0].ToString());
            }
            for (Int32 i = 0; i < dtDeduction.Rows.Count; i++)
            {

                if (!SalHead1.ContainsKey(Gen_ID("D", dtDeduction.Rows[i][1].ToString())))
                    SalHead1.Add(Gen_ID("D", dtDeduction.Rows[i][1].ToString()), dtDeduction.Rows[i][0].ToString());
            }
        }
        public string Gen_ID(string h_type, string s)
        {
            string res = "";
            switch (s.Length)
            {
                case 1: res = h_type + "00" + s; break;
                case 2: res = h_type + "0" + s; break;
                case 3: res = h_type + s; break;
            }
            return res;
        }

        public string f_cal(string exp)
        {
            int g = 0, i = 0, ta = 0;
            double fl = 0, bs = 0;
            string res = "";
            Config_SalaryStructure_Formula cnfgss = new Config_SalaryStructure_Formula();
            if (!cnfgss.IsDigitsOnly(exp))
            {
                for (int f = 0; f < exp.Trim().Length; f++)
                {

                    if (exp.Trim().Substring(f, 1) == "*")
                    {
                        if (fl == 0)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                            {
                                fl = Convert.ToDouble(exp.Trim().Substring(g, i));
                                bs = Convert.ToDouble(exp.Trim().Substring(g, i));
                                /*
                                 fl = Convert.ToDouble(exp.Trim().Substring(g, f));
                                bs = Convert.ToDouble(exp.Trim().Substring(g, f));
                                 */
                                //ta = 1;
                            }
                            else
                                fl = 0;
                        }
                        if (ta == 1)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl * 0;
                        }
                        else if (ta == 2)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl + 0;
                        }
                        else if (ta == 3)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl - 0;
                        }
                        else if (ta == 4)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl / 0;
                        }
                        else if (ta == 5)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl % 0;
                        }
                        ta = 1;
                        i = 0;
                        g = f + 1;
                    }
                    else if (exp.Trim().Substring(f, 1) == "+")
                    {
                        if (fl == 0)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = Convert.ToDouble(exp.Trim().Substring(g, i));

                            else
                                fl = 0;

                            if (ta == 0)
                            {
                                bs = Convert.ToDouble(exp.Trim().Substring(g, i));
                            }
                        }
                        if (ta == 1)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl * 0;
                        }
                        else if (ta == 2)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl + 0;
                        }
                        else if (ta == 3)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl - 0;
                        }
                        else if (ta == 4)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl / 0;
                        }
                        else if (ta == 5)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl % 0;
                        }
                        ta = 2;
                        i = 0;
                        g = f + 1;
                    }
                    else if (exp.Trim().Substring(f, 1) == "-")
                    {
                        if (fl == 0)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = 0;
                            if (ta == 0)
                            {
                                bs = Convert.ToDouble(exp.Trim().Substring(g, i));
                            }
                        }
                        if (ta == 1)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl * 0;
                        }
                        else if (ta == 2)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl + 0;
                        }
                        else if (ta == 3)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl - 0;
                        }
                        else if (ta == 4)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl / 0;
                        }
                        else if (ta == 5)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl % 0;
                        }
                        ta = 3;
                        i = 0;
                        g = f + 1;
                    }
                    else if (exp.Trim().Substring(f, 1) == "/")
                    {
                        if (fl == 0)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = 0;
                            if (ta == 0)
                            {
                                bs = Convert.ToDouble(exp.Trim().Substring(g, i));
                            }
                        }
                        if (ta == 1)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl * 0;
                        }
                        else if (ta == 2)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl + 0;
                        }
                        else if (ta == 3)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl - 0;
                        }
                        else if (ta == 4)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl / 0;
                        }
                        else if (ta == 5)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl % 0;
                        }
                        ta = 4;
                        i = 0;
                        g = f + 1;
                    }
                    else if (exp.Trim().Substring(f, 1) == "%")
                    {
                        if (fl == 0)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = 0;
                            if (ta == 0)
                            {
                                bs = Convert.ToDouble(exp.Trim().Substring(g, i));
                            }
                        }
                        if (ta == 1)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl * 0;
                        }
                        else if (ta == 2)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl + 0;
                        }
                        else if (ta == 3)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl - 0;
                        }
                        else if (ta == 4)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl / 0;
                        }
                        else if (ta == 5)
                        {
                            if (exp.Trim().Substring(g, i) != "")
                                fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                            else
                                fl = fl % 0;
                        }
                        ta = 5;
                        i = 0;
                        g = f + 1;
                    }
                    else if (exp.Trim().Substring(f, 1) == "(")
                    {
                        i = 0;
                        g = f + 1;
                    }
                    else if (exp.Trim().Substring(f, 1) == ")")
                    {
                        i = 0;
                        g = f + 1;
                    }
                    else
                    {
                        i++;
                    }
                }
                if (ta == 1)
                {
                    if (exp.Trim().Substring(g, i) != "")
                    {
                        if (fl != 0) { fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i)); } else { fl = 0 * Convert.ToDouble(exp.Trim().Substring(g, i)); }
                    }
                    else
                        fl = fl * 0;
                }
                else if (ta == 2)
                {
                    if (exp.Trim().Substring(g, i) != "")
                    {
                        if (fl != 0) { fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i)); } else { fl = 0 + Convert.ToDouble(exp.Trim().Substring(g, i)); }
                    }
                    else
                        fl = fl + 0;
                }
                else if (ta == 3)
                {
                    if (exp.Trim().Substring(g, i) != "")
                    {
                        if (fl != 0) { fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i)); } else { fl = 0 - Convert.ToDouble(exp.Trim().Substring(g, i)); }
                    }
                    else
                        fl = fl - 0;
                }
                else if (ta == 4)
                {
                    if (exp.Trim().Substring(g, i) != "")
                    {
                        if (fl != 0) { fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i)); } else { fl = 0 / Convert.ToDouble(exp.Trim().Substring(g, i)); }
                    }
                    else
                        fl = fl / 0;
                }
                else if (ta == 5)
                {
                    if (exp.Trim().Substring(g, i) != "")
                    {
                        if (fl != 0) { fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i)); } else { fl = 0 % Convert.ToDouble(exp.Trim().Substring(g, i)); }
                    }
                    else
                        fl = fl % 0;
                }

                //if (bs==0)
                //{
                //    fl=bs;
                //}
                res = Convert.ToString(fl);
            }
            else
                res = exp;
            return res;
        }



        public void view_sal(string Mnth, string Exts)
        {
            //string w = ""; hsh_chk_SalErnHead.Clear(); hsh_chk_SalDedHead.Clear(); hsh_chk_SalPFHead.Clear(); hsh_chk_PT.Clear(); hsh_chk_esi.Clear(); hsh_chk_pfVol.Clear();
            //string eid = "";
            //if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
            //    eid = emp_id[cmbempname1111.Text.Trim()].ToString();

            //w = "select distinct salid,tablename,amount,TotalSal,TotalDec,NetPay from tbl_Employee_SalaryDet as esd inner join tbl_Employee_SalaryMast as esm on esd.EmpId=esm.Emp_Id";
            //w += " and esd.Month=esm.Month and esd.Session=esm.Session where esd.EmpId='" + eid + "' and esd.month='" + Mnth + "' and esd.session='" + cmbYear.Text.Trim() + "'";

            //DataTable ddt = new DataTable();
            //ddt = clsDataAccess.RunQDTbl(w);
            //if (ddt.Rows.Count > 0)
            //{
            //    PFlbTxt();
            //    for (int d = 0; d < ddt.Rows.Count; d++)
            //    {
            //        if (ddt.Rows[d][1].ToString() == "tbl_Employee_ErnSalaryHead")
            //        {
            //            for (int le = 0; le < 16; le++)
            //            {
            //                Label lb = new Label();
            //                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
            //                lb = lbe[le];
            //                tx = txte[le];
            //                if (Convert.ToInt32(ddt.Rows[d][0]) == get_sal_head_ID(lb.Text.Trim()))
            //                {
            //                    tx.Text = ddt.Rows[d][2].ToString();
            //                    if (!hsh_chk_SalErnHead.ContainsKey(ddt.Rows[d][0].ToString()))
            //                        hsh_chk_SalErnHead.Add(ddt.Rows[d][0].ToString(), "");
            //                }
            //                txte[le] = tx;
            //                this.grpern.Controls.Add(txte[le]);

            //            }

            //        }
            //        if (ddt.Rows[d][1].ToString() == "tbl_Employee_DeductionSalayHead")
            //        {
            //            for (int le = 0; le < 16; le++)
            //            {
            //                Label lb = new Label();
            //                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
            //                lb = lbd[le];
            //                tx = txtd[le];
            //                if (Convert.ToInt32(ddt.Rows[d][0]) == get_sal_head_ID(lb.Text.Trim()))
            //                {
            //                    tx.Text = ddt.Rows[d][2].ToString();
            //                    if (!hsh_chk_SalDedHead.ContainsKey(ddt.Rows[d][0].ToString()))
            //                        hsh_chk_SalDedHead.Add(ddt.Rows[d][0].ToString(), "");
            //                }
            //                txtd[le] = tx;
            //                this.grpded.Controls.Add(txtd[le]);
            //            }

            //        }

            //        if (ddt.Rows[d][1].ToString() == "tbl_Employee_Config_PFHeads")
            //        {

            //            for (int le = 0; le < 3; le++)
            //            {
            //                Label lb = new Label();
            //                TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
            //                lb = lbp[le];
            //                tx = txtp[le];
            //                if (Convert.ToInt32(ddt.Rows[d][0]) == get_sal_head_ID(lb.Text.Trim()))
            //                {
            //                    if (Exts == "N")
            //                    {
            //                        if (le >= 1)
            //                        {
            //                            pfloan_cal();
            //                        }
            //                        else
            //                        {
            //                            tx.Text = ddt.Rows[d][2].ToString();
            //                        }
            //                    }
            //                    else if (Exts == "Y")
            //                    {
            //                        tx.Text = ddt.Rows[d][2].ToString();
            //                    }
            //                    if (!hsh_chk_SalPFHead.ContainsKey(get_sal_head_ID(lb.Text.Trim())))
            //                        hsh_chk_SalPFHead.Add(get_sal_head_ID(lb.Text.Trim()), "");
            //                }

            //                txtp[le] = tx;

            //                this.grpded.Controls.Add(txtp[le]);
            //            }

            //        }
            //        if (ddt.Rows[d][1].ToString() == "tbl_Employee_Config_PFHeads" && Convert.ToInt32(ddt.Rows[d][0]) == 5)
            //        {
            //            if (lbld19.Text != "")

            //                txtd19.Text = ddt.Rows[d][2].ToString();
            //            if (!hsh_chk_PT.ContainsKey("5"))
            //                hsh_chk_PT.Add("5", "");

            //        }
            //        if (ddt.Rows[d][1].ToString() == "tbl_Employee_Config_PFHeads" && Convert.ToInt32(ddt.Rows[d][0]) == 4)
            //        {
            //            if (lbld20.Text != "")

            //                txtd20.Text = ddt.Rows[d][2].ToString();
            //            if (!hsh_chk_esi.ContainsKey("4"))
            //                hsh_chk_esi.Add("4", "");

            //        }
            //        if (ddt.Rows[d][1].ToString() == "tbl_Employee_Config_PFHeads" && Convert.ToInt32(ddt.Rows[d][0]) == 6)
            //        {
            //            if (Convert.ToDouble(ddt.Rows[d][2]) > 0)
            //            {
            //                chkpfvol.Checked = true;
            //                txtpfvol.Enabled = true;
            //                txtpfvol.Text = ddt.Rows[d][2].ToString();
            //            }
            //            if (!hsh_chk_pfVol.ContainsKey("6"))
            //                hsh_chk_pfVol.Add("6", "");
            //        }

            //    }
            //}
        }


        private void clear_txt()
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Information.IsNumeric(dgvSalary.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                    if (Convert.ToDouble(dgvSalary.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) < 0)
                    {
                        ERPMessageBox.ERPMessage.Show("Negative Value Not Allow");
                        dgvSalary.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0.00";
                    }

                double ear_total = 0, deduc_total = 0;
                int cou = 0;
                int earn_cnt = dgvSalary.Columns["Total_Earning"].Index;
                earn_count.Text = lblEarning.Text;
                cou = earn_cnt; //Convert.ToInt32(earn_count.Text);
                for (int i = 8; i < cou; i++)
                {
                    if (Information.IsNumeric(dgvSalary.Rows[e.RowIndex].Cells[i].Value) == true)
                    {
                        if (dgvSalary.Columns[i].HeaderText == "Total_Earning")
                            dgvSalary.Rows[e.RowIndex].Cells[i].Value = string.Format("{0:F}", ear_total);
                        else
                        {
                            try
                            {
                                if (dgvSalary.Columns[i].Visible == false)
                                {
                                    ear_total = ear_total + 0;

                                }
                                else
                                {
                                    ear_total = ear_total + Convert.ToDouble(dgvSalary.Rows[e.RowIndex].Cells[i].Value);
                                }
                            }
                            catch
                            {


                            }
                        }
                    }
                }
                dgvSalary.Rows[e.RowIndex].Cells[cou].Value = string.Format("{0:F}", ear_total);
                cou = earn_cnt + 1; //Convert.ToInt32(earn_count.Text)-1;
                for (int i = cou; i <= dgvSalary.Columns.Count - 1; i++)
                {
                    if (Information.IsNumeric(dgvSalary.Rows[e.RowIndex].Cells[i].Value) == true)
                    {
                        if (dgvSalary.Columns[i].HeaderText == "Total_Deduction")
                        {
                            dgvSalary.Rows[e.RowIndex].Cells[i].Value = string.Format("{0:F}", deduc_total);
                            dgvSalary.Rows[e.RowIndex].Cells["Net_Pay"].Value = string.Format("{0:F}", ear_total - deduc_total);
                        }
                        else
                            deduc_total = deduc_total + Convert.ToDouble(dgvSalary.Rows[e.RowIndex].Cells[i].Value);
                    }
                }
                ear_total = 0;
                double net_tot = 0, Total_Earning = 0, Total_Deduction = 0;
                for (int i = 0; i <= dgvSalary.Rows.Count - 2; i++)
                {
                    if (Information.IsNumeric(dgvSalary.Rows[i].Cells[e.ColumnIndex].Value) == true)
                        ear_total = ear_total + Convert.ToDouble(dgvSalary.Rows[i].Cells[e.ColumnIndex].Value);
                    if (Information.IsNumeric(dgvSalary.Rows[i].Cells["Net_Pay"].Value) == true)
                        net_tot = net_tot + Convert.ToDouble(dgvSalary.Rows[i].Cells["Net_Pay"].Value);

                    if (Information.IsNumeric(dgvSalary.Rows[i].Cells["Total_Earning"].Value) == true)
                        Total_Earning = Total_Earning + Convert.ToDouble(dgvSalary.Rows[i].Cells["Total_Earning"].Value);

                    if (Information.IsNumeric(dgvSalary.Rows[i].Cells["Total_Deduction"].Value) == true)
                        Total_Deduction = Total_Deduction + Convert.ToDouble(dgvSalary.Rows[i].Cells["Total_Deduction"].Value);
                }

                dgvSalary.Rows[dgvSalary.Rows.Count - 1].Cells[e.ColumnIndex].Value = string.Format("{0:F}", ear_total);
                dgvSalary.Rows[dgvSalary.Rows.Count - 1].Cells["Net_Pay"].Value = string.Format("{0:F}", net_tot);
                dgvSalary.Rows[dgvSalary.Rows.Count - 1].Cells["Total_Earning"].Value = string.Format("{0:F}", Total_Earning);
                dgvSalary.Rows[dgvSalary.Rows.Count - 1].Cells["Total_Deduction"].Value = string.Format("{0:F}", Total_Deduction);
                lbltot.Text = string.Format("{0:F}", net_tot);

            }
            catch { }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(true);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSalary.Rows.Count - 1; i++)
            {
                if (Convert.ToDouble(dgvSalary.Rows[i].Cells["Net_Pay"].Value) < 0)
                {
                    try
                    {
                        foreach (DataGridViewColumn col in dgvSalary.Columns)
                        {
                            if (col.HeaderText.ToLower().Trim() == "adv" || col.HeaderText.ToLower().Trim() == "advance")
                            {
                                dgvSalary.Rows[i].Cells[col.Index].ReadOnly = false;
                            }

                            if (col.HeaderText.ToLower().Trim() == ("kit") || col.HeaderText.ToLower().Trim() == ("unif") || col.HeaderText.ToLower().Trim() == ("uniform") || col.HeaderText.ToLower().Trim() == ("dress"))
                            {
                                dgvSalary.Rows[i].Cells[col.Index].ReadOnly = false;
                            }

                            if (col.HeaderText.ToLower().Trim() == "ln" || col.HeaderText.ToLower().Trim() == "loan")
                            {
                                dgvSalary.Rows[i].Cells[col.Index].ReadOnly = false;
                            }
                        }
                    }
                    catch { }
                    MessageBox.Show("Negative Value.Please check Employee ID : " + Convert.ToString(dgvSalary.Rows[i].Cells["ID"].Value), "BRAVO");
                    return;
                }


            }

            save_details();

        }
        public void Command_TR(string qry)
        {
            //cmd.Connection = clsDataAccess.conn;
            cmd.Transaction = sqltran;
            cmd.CommandText = qry;
            cmd.ExecuteNonQuery();
        }
        private void save_details()
        {
            try
            {
                //following block of code has been added by dwipraj dutta 02112017
                string temp = "";
                for (int i = 0; i <= dgvSalary.Rows.Count - 2; i++)
                {
                    if (temp == Convert.ToString(dgvSalary.Rows[i].Cells["ID"].Value))
                    {
                        if (alMultiDesgEmpID.Contains(Convert.ToString(dgvSalary.Rows[i].Cells["ID"].Value)))
                            continue;

                        alMultiDesgEmpID.Add(Convert.ToString(dgvSalary.Rows[i].Cells["ID"].Value));
                    }
                    else
                    {
                        temp = Convert.ToString(dgvSalary.Rows[i].Cells["ID"].Value);
                    }

                }
                Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                string month = cmbMonth.Text = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
                bool s_Msg = false;
                string sql_ocharge = "";
                //clsDataAccess.ConnectDB();
                edpcon.Open();
                cmd.Connection = edpcon.mycon;
                //edpcon.Open();
                sqltran = edpcon.mycon.BeginTransaction();

                //sqltran = edpcon.mycon.BeginTransaction();
                if (btnSubmit.Text == "Update")
                {
                    if (lblStatusCode.Text != "4")
                    {
                        EDPMessageBox.EDPMessage.Show("Can not update in this status");
                        return;
                    }
                    Delet_Rec(month);
                    edpcom.InsertMidasLog(this, true, "mod", "Mon:" + month.Trim() + ",Sess:" + cmbYear.Text.Trim() + ",Loc:" + Locations);
                }
                else
                {
                    edpcom.InsertMidasLog(this, true, "add", "Mon:" + month.Trim() + ",Sess:" + cmbYear.Text.Trim() + ",Loc:" + Locations);
                }

                int sts = 0;
                string type = "";
                if (chkAuthorise.Checked == true)
                {
                    sts = 1;
                }
                else
                {
                    sts = 0;
                }
                type = btnSubmit.Text;
                clsDataAccess.RunWorkflow_Log(edpcom.UserDesc, "Salary Allotement", sts.ToString(), DateAndTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt"), type, Environment.MachineName, AttenDtTmPkr.Value.ToString("MMM"), AttenDtTmPkr.Value.Year.ToString(), Locations.ToString(), company_Id.ToString(), "");


                for (int i = 0; i <= dgvSalary.Rows.Count - 2; i++)
                {
                    try
                    {
                        save_sal_Det(i, month);
                    }
                    catch
                    {
                        ERPMessageBox.ERPMessage.Show("Error");

                    }

                }
                int OCId = 0;
                double OAmt = 0;
                string OCName = "";
                double det_val = 0;
                string odname = "";
                string odbank = "";
                string Odbranch = "";
                string odacno = "";
                string oIfsc = "";

                for (int dgind = 0; dgind < dgvOtherCharges.Rows.Count - 1; dgind++)
                {
                    OCId = dgind + 1;
                    dgvOtherCharges.Rows[dgind].Cells["dgColID"].Value = OCId;
                    OCName = Convert.ToString(dgvOtherCharges.Rows[dgind].Cells["dgColOCharge"].Value);
                    OAmt = Convert.ToDouble(dgvOtherCharges.Rows[dgind].Cells["dgColVal"].Value);
                    odname = Convert.ToString(dgvOtherCharges.Rows[dgind].Cells["dgColOName"].Value);
                    odbank = Convert.ToString(dgvOtherCharges.Rows[dgind].Cells["dgColOBank"].Value);
                    Odbranch = Convert.ToString(dgvOtherCharges.Rows[dgind].Cells["dgColOBranch"].Value);
                    odacno = Convert.ToString(dgvOtherCharges.Rows[dgind].Cells["dgColOAc"].Value);
                    oIfsc = Convert.ToString(dgvOtherCharges.Rows[dgind].Cells["dgColOIfsc"].Value);
                    sql_ocharge = "INSERT INTO [tbl_Employee_Sal_OCharges]" +
            "([OCId],[OCName],[Amount],[ODName],[Bank],[Branch],[IFSC],[AcNo]," +
            "[Month],[Session],[InsertionDate],[Location_id],[Company_id]) VALUES(" +
             OCId + ",'" + OCName + "'," + OAmt + ",'" + odname + "','" + odbank + "','" + Odbranch + "','" +
                      oIfsc + "','" + odacno + "','" + month.Trim() + "','" + cmbYear.Text.Trim() + "',getdate(),'" +
                      Locations + "','" + company_Id + "')";
                    Command_TR(sql_ocharge);
                    det_val = det_val + OAmt;
                }
                //if (txtAgentName.Text == "" || txtAgentBank.Text == "" || txtAgentAcno.Text == "")
                //{
                //}
                //else
                //{
                //    string odname = txtAgentName.Text;
                //    string odbank = txtAgentBank.Text;
                //    string odacno = txtAgentAcno.Text;

                //    sql_ocharge = "INSERT INTO [tbl_Employee_Sal_ODet]" +
                //              "([ODName],[Bank],[AcNo],[Month],[Session],[InsertionDate],[Location_id],[Company_id]) VALUES('" +
                //               odname + "','" + odbank + "','" + odacno + "','" + month.Trim() + "','" + cmbYear.Text.Trim() + "',getdate(),'" + Locations + "','" + company_Id + "')";
                //    Command_TR(sql_ocharge);
                //}

                //s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells[ll.Text.Trim()].Value) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "')";
                //s = "select SalaryHead_Short,slno from tbl_Employee_ErnSalaryHead";
                //dt1 = clsDataAccess.RunQDTbl(s);
                det_val = det_val + Convert.ToDouble(lbltot.Text);
                try
                {
                    sqltran.Commit();
                }
                catch { }
                string qry = "";
                if (btnSubmit.Text.ToLower() == "submit")
                {
                    for (int idx = 0; idx < dgPfEsi.Rows.Count; idx++)
                    {
                        qry = "INSERT INTO tbl_employers_contribution(emp_id,month,session,coid,lid,pf_bs,esi_bs,pf_employer_cont,esi_employer_cont,pf,esi,OT,desgid)" +
           "VALUES('" + dgPfEsi.Rows[idx].Cells["eid"].Value + "','" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "','" + cmbYear.Text + "','" + company_Id + "','" +
           Locations + "','" + dgPfEsi.Rows[idx].Cells["pf_bs"].Value + "','" + dgPfEsi.Rows[idx].Cells["esi_bs"].Value + "','" + dgPfEsi.Rows[idx].Cells["pf_contribution"].Value + "','" +
           dgPfEsi.Rows[idx].Cells["esi_contribution"].Value + "','" + dgPfEsi.Rows[idx].Cells["col_pf"].Value + "','" + dgPfEsi.Rows[idx].Cells["col_esi"].Value + "','" +
           dgPfEsi.Rows[idx].Cells["col_OT_act"].Value + "','" + dgPfEsi.Rows[idx].Cells["col_desgid"].Value + "')";
                        Command_TR(qry);
                        //clsDataAccess.RunQry(qry);
                    }
                    try
                    {
                        if (dgPfEsi.Rows.Count > 0)
                        {
                            dgPfEsi.DataSource = null;
                        }
                    }
                    catch { }
                }

                MessageBox.Show("Record Inserted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmEmployeeSalarySheet ess = new frmEmployeeSalarySheet("P");
                //ess.cmbLocation.ReturnValue = cmbLocation.ReturnValue;
                //ess.AttenDtTmPkr.Text = AttenDtTmPkr.Text;
                //ess.cmbLocation.Text = cmbLocation.Text;
                //ess.cmbYear.SelectedItem = cmbYear.SelectedItem;
                //ess.cmbcompany.ReturnValue = company_Id.ToString();
                //string s = "SELECT CO_NAME FROM Company WHERE  (CO_CODE =" + company_Id.ToString() + ")";
                //ess.cmbcompany.Text = clsDataAccess.GetresultS(s);
                //ess.AttenDtTmPkr.Value = AttenDtTmPkr.Value.Date;

                ess.view_sal(AttenDtTmPkr.Value.Date, cmbLocation.ReturnValue.ToString(), cmbLocation.Text.ToString(), cmbYear.SelectedItem.ToString(), company_Id.ToString(), lbl_mod.Text.Trim());
                ess.ShowDialog();


                dgvSalary.DataSource = null;

                s_Msg = true;
                // this.Controls.Clear();
                dgvOtherCharges.Rows.Clear();
                dgvOtherCharges.Visible = false;
                dgPfEsi.Rows.Clear();
                txtcalculated_days.Text = "0";
                AttenDtTmPkr.Value = System.DateTime.Now.AddMonths(-1);
                groupBox4.Text = "";
                txtAgentAcno.Text = "";
                txtAgentBank.Text = "";
                txtAgentName.Text = "";
                lbltot.Text = "";
                cmbLocation.Text = "";
                chkAuthorise.Checked = false;
                dtp_DOE.Value = System.DateTime.Now;
                btnPreview.Visible = false;
                try
                {
                    dgvGross.Rows.Clear();
                    dgvGross.Columns.Clear();
                }
                catch { }
                try
                {
                    dgvRecoveries.Rows.Clear();
                    dgvRecoveries.Columns.Clear();
                }
                catch { }
                try
                {
                    dgPfEsi.Rows.Clear();
                }
                catch { }
                if (chkAllLocation.Checked == false)
                {
                    //MessageBox.Show("Record Inserted Successfully.." + Environment.NewLine +
                    //" Location : " + cmbLocation.Text.Trim() + ". for the month of " + AttenDtTmPkr.Value.ToString("MMMM - yyyy"), "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkAllLocation.Checked = false;
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Want to continue with current selected zone ?", "BRAVO", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
                    if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
                    {

                    }
                    else
                    {
                        chkAllLocation.Checked = false;
                        chkAllLocation.Checked = true;
                    }
                }
            }
            catch (Exception x)
            {
                sqltran.Rollback();
                clsDataAccess.DisconnectDB();
                ERPMessageBox.ERPMessage.Show("Error" + x.ToString());
            }
            finally
            {
                clsDataAccess.DisconnectDB();
            }

            lbl_wd_hrs.Text = "0";
            lbl_ot_hrs.Text = "0";
        }

        private void Delet_Rec(string mon)
        {
            //  del_ALK();
            string s = "";
            s = "delete from tbl_Employee_SalaryDet where  (Month='" + mon.Trim() + "') and (Session ='" + cmbYear.Text.Trim() + "') and (Location_id='" + Locations + "')";
            Command_TR(s);
            s = "delete from tbl_Employee_SalaryDetails where  (Month='" + mon.Trim() + "') and (Session ='" + cmbYear.Text.Trim() + "') and (Location_id='" + Locations + "')";
            Command_TR(s);
            s = "delete from tbl_Employee_SalaryMast where (Month='" + mon.Trim() + "') and (Session ='" + cmbYear.Text.Trim() + "') and (Location_id='" + Locations + "')";
            Command_TR(s);
            s = "delete from tbl_Employee_Sal_OCharges where (Month='" + mon.Trim() + "') and (Session ='" + cmbYear.Text.Trim() + "') and (Location_id='" + Locations + "')";
            Command_TR(s);
            s = "delete from tbl_Employee_Sal_ODet where (Month='" + mon.Trim() + "') and (Session ='" + cmbYear.Text.Trim() + "') and (Location_id='" + Locations + "')";
            Command_TR(s);

            s = ("DELETE FROM tbl_Employee_SalaryGross where (month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "') and (Location_id ='" + Locations + "')");
            Command_TR(s);

            try
            {
                s = "delete from tbl_Employee_SalaryDet_MultiDesignation where (Month='" + mon.Trim() + "') and (Session ='" + cmbYear.Text.Trim() + "') and (Location_id='" + Locations + "')";
                Command_TR(s);
            }
            catch
            { }
        }

        public void save_sal_Det(int dgv_count, string mon)
        {
            string s = ""; bool b = false;
            //int eid = 0;
            //eid = Convert.ToInt32(dataGridView1.Rows[dgv_count].Cells["ID"].Value);
            int sts = 0;

            if (chkAuthorise.Checked == true)
            {
                sts = 1;
            }
            else
            {
                sts = 0;
            }
            string eid = "", ename = "", designationid = "", ecode = "";
            bool lv_allow = false;
            eid = Convert.ToString(dgvSalary.Rows[dgv_count].Cells["ID"].Value);
            ename = Convert.ToString(dgvSalary.Rows[dgv_count].Cells["EmployeeName"].Value);
            designationid = Convert.ToString(dgvSalary.Rows[dgv_count].Cells["DesgID"].Value);

            try
            {
                lv_allow = Convert.ToBoolean(clsDataAccess.ReturnValue("select cfw from tbl_Employee_Attend where (Month ='" + this.AttenDtTmPkr.Value.Month + "/" + this.AttenDtTmPkr.Value.Year + "') and  (Season = '" + cmbYear.Text + "') and (Location_ID ='" + Locations + "') and (ID='" + eid + "') and (Desgid='" + designationid + "')"));
            }
            catch { }
            try
            {
                if (lv_Type == "1")
                {
                    int imon = Convert.ToInt32(clsDataAccess.GetresultS("select lv_adj FROM Companywiseid_Relation where (Company_ID='" + company_Id + "') and (Location_ID='" + Locations + "')"));

                    if ((imon == 0 || imon == AttenDtTmPkr.Value.Month) && lv_allow == true)
                    {
                        clsDataAccess.RunNQwithStatus("update tbl_Emp_Leave_Balance Set cur_lv_bal='0' where (eid='" + eid + "')");
                    }
                }
            }
            catch { }
            //if block has been added by dwipraj dutta 02112017 for calulating salary for single employee single location multi designation concept... 
            //else block is previously defined block for salary calculation...
            if (alMultiDesgEmpID.Contains(eid))
            {
                Save_Sal_mst_multidesignation_singleLoc(eid, designationid, mon, dgv_count, sts);

                for (int ind = 0; ind < hd_col.Count; ind++)
                {
                    // this.dataGridView1.Columns.Remove(hd_col[ind].ToString());

                }
                int conf = 0;

                for (int tc = 0; tc < 16; tc++)
                {
                    Label ll = new Label();
                    TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();

                    ll = lbe[tc];
                    tx = txte[tc];
                    for (int ind = 0; ind < hd_col.Count; ind++)
                    {
                        if (hd_col[ind].ToString() != ll.Text.Trim())
                        {
                            conf = 0;
                        }
                        else
                        {
                            conf = 1;
                            break;

                        }
                    }

                    if (ll.Text.Trim() != "" && conf == 0)
                    {
                        if (Convert.ToString(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) == "")
                            dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value = "0";
                        //commented for test on 27-02-2020 // 
                        s = "insert into tbl_Employee_SalaryDet_MultiDesignation(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,Designation_id) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "'," + designationid + ")";
                        //
                        s = s + Environment.NewLine + "insert into tbl_Employee_SalaryDetails(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,Designation_id) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "'," + designationid + ")";
                        Command_TR(s);

                        try
                        {
                            if (dgvGross.Columns.Contains(get_sal_head_ID(ll.Text.Trim()).ToString()))
                            {
                                s = "insert into tbl_Employee_SalaryGross(EID,EmpId,SalId,TableName,Amount,Month,InsertionDate,Location_id,Company_id,client_id,desgid,hd) values((select isNull(Max(eid),0)+1 from tbl_Employee_SalaryGross where EmpId='" + eid + "' and Month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "' and location_id='" + Locations + "' ),'" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(dgvGross.Rows[dgv_count].Cells[get_sal_head_ID(ll.Text.Trim()).ToString()].Value) + ",'" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "','" + DateTime.Now.Date.ToString("dd/MMM/yyyy") + "','" + Locations + "','" + company_Id + "','" + lblClid.Text + "','" + designationid + "','" + ll.Text.Trim() + "')";
                                Command_TR(s);
                            }
                        }
                        catch { }
                    }
                    //if (ll.Text.Trim() != "" && conf == 0)
                    //{
                    //    if (Convert.ToString(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) == "")
                    //        dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value = "0";
                    //    s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "')";
                    //    Command_TR(s);
                    //    try
                    //    {
                    //        if (dgvGross.Columns.Contains(get_sal_head_ID(ll.Text.Trim()).ToString()))
                    //        {
                    //            s = "insert into tbl_Employee_SalaryGross(EID,EmpId,SalId,TableName,Amount,Month,InsertionDate,Location_id,Company_id,client_id,desgid,hd) values((select isNull(Max(eid),0)+1 from tbl_Employee_SalaryGross where EmpId='" + eid + "' and Month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "' and location_id='" + Locations + "' ),'" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(dgvGross.Rows[dgv_count].Cells[get_sal_head_ID(ll.Text.Trim()).ToString()].Value) + ",'" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "','" + DateTime.Now.Date.ToString("dd/MMM/yyyy") + "','" + Locations + "','" + company_Id + "','" + lblClid.Text + "','" + designationid + "','" + ll.Text.Trim() + "')";
                    //            Command_TR(s);
                    //        }
                    //    }
                    //    catch { }
                    //}

                }

                DataTable dt_alk = new DataTable();
                string sql_update_alk = "", sql_alk = "";
                try
                {
                    sql_alk = "select SAL_HEAD,(select SalaryHead_Short FROM tbl_Employee_DeductionSalayHead where SlNo=eas.SAL_HEAD)as HEAD,chkALK from tbl_Employee_Assign_SalStructure eas where sal_struct=" + salary_structure + " and p_type='D' AND (chkALK > 0)";

                    dt_alk = clsDataAccess.RunQDTbl(sql_alk);
                }
                catch { }


                for (int tc = 0; tc < 16; tc++)
                {
                    Label ll = new Label();
                    TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                    ll = lbd[tc];
                    tx = txtd[tc];
                    if (ll.Text.Trim() != "")
                    {
                        if (Convert.ToString(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) == "")
                            dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value = "0";


                        //commented for test on 27-02-2020 //  
                        s = "insert into tbl_Employee_SalaryDet_MultiDesignation(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,Designation_id) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_DeductionSalayHead'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "'," + designationid + ")";
                        s = s + Environment.NewLine + "insert into tbl_Employee_SalaryDetails(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,Designation_id) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_DeductionSalayHead'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "'," + designationid + ")";
                        Command_TR(s);

                        for (int ind_alk = 0; ind_alk < dt_alk.Rows.Count; ind_alk++)
                        {
                            if (dt_alk.Rows[ind_alk]["HEAD"].ToString() == ll.Text)
                            {


                                Int32 colc = Convert.ToInt32(tsal_table.Columns.IndexOf(ll.Text));
                                double val = 0;
                                try
                                {
                                    DataRow[] dr = tsal_table.Select("ID='" + eid.ToString() + "'");

                                    if (dr.Length > 0 && btnSubmit.Text == "Update")
                                    {
                                        val = Convert.ToDouble(dr[0][colc].ToString());
                                    }
                                    else
                                    {
                                        val = 0;
                                    }
                                }
                                catch
                                {
                                    val = 0;
                                }


                                //                     string qry_alkf="INSERT INTO [tbl_recovery]([slno],[transid],[salid],[eid],[ename],[desgid],[ramt],[mon],[coid],[locid],[type]) VALUES (<slno, numeric(18,0),>
                                //,<transid, numeric(18,0),>
                                //,<salid, numeric(18,0),>
                                //,<eid, nvarchar(max),>
                                //,<ename, nvarchar(max),>
                                //,<desgid, numeric(18,0),>
                                //,<ramt, numeric(18,2),>
                                //,<mon, nvarchar(max),>
                                //,<coid, int,>
                                //,<locid, int,>
                                //,<type, nvarchar(max),>)

                                if (dt_alk.Rows[ind_alk]["chkALK"].ToString() == "1") //advance
                                {
                                    //string loan_amt = clsDataAccess.GetresultS("Select EADEDUCT from tbl_Employee_Advance where (EAEID='" + eid + "') and [EAID]=(select max([EAID]) from tbl_Employee_Advance where (EAEID='" + eid + "')) and ([EAAMT]-[EADEDUCT])>0");
                                    //if (Information.IsNumeric(loan_amt) != true)
                                    //{
                                    //    loan_amt = "0";
                                    //}

                                    int ind_Adv = 0;

                                    try
                                    {
                                        if (Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value.ToString()) > 0)
                                        {

                                            try
                                            {

                                                ind_Adv = Convert.ToInt32(clsDataAccess.GetresultS("Select (isNull(max(EAID),0)+1)advno from tbl_Employee_Advance"));
                                            }
                                            catch
                                            {
                                                ind_Adv = 1;
                                            }

                                            for (int idx = 0; idx < dgvRecoveries.Rows.Count; idx++)
                                            {
                                                if (dgvRecoveries.Rows[idx].Cells["eid"].Value.ToString().Trim().ToLower() == eid.Trim().ToLower() && dgvRecoveries.Rows[idx].Cells["type"].Value.ToString().Trim().ToLower() == "advance")
                                                {

                                                    sql_update_alk = "INSERT INTO tbl_recovery (slno,transid,salid,eid,ename,desgid,ramt,mon,coid,locid,type) VALUES (" +
                                     dgvRecoveries.Rows[idx].Cells["tid"].Value + "," + dgvRecoveries.Rows[idx].Cells["tid"].Value + "," + ind_Adv +
                                     ",'" + eid + "','" + dgvRecoveries.Rows[idx].Cells["ename"].Value + "'," + dgvRecoveries.Rows[idx].Cells["desgID"].Value + ",'" +
                                     dgvRecoveries.Rows[idx].Cells["amt"].Value + "','" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "'," + company_Id + "," + Locations + ",'Advance')";
                                                    clsDataAccess.RunQry(sql_update_alk);
                                                }
                                            }

                                            if (btnSubmit.Text == "Update")
                                            {
                                                sql_update_alk = "Delete from tbl_Employee_Advance where (EAEID='" + eid + "') and ([EAMONTH]='" + AttenDtTmPkr.Value.ToString("MMMM/ yyyy") + "') and ([CoID]='" + company_Id + "') and ([LocID]='" + Locations + "')";

                                                Command_TR(sql_update_alk);

                                            }

                                            sql_update_alk = "insert into tbl_Employee_Advance([EAID],[EAEID],[EANAME]," +
                                            "[EADT],[EAMONTH],[EAAMT],[EADEDUCT],[EADEDUCTDT],[SLNO],[CoID],[LocID],[LocName],[remarks]) values (" + ind_Adv + ",'" +
                                            eid + "','" + ename.Trim() + "','" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "','" + AttenDtTmPkr.Value.ToString("MMMM/ yyyy") +
                                            "',0," + (dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) + ",'" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") +
                                            "',1," + company_Id + "," + Locations + ",'" + cmbLocation.Text + "','Advance')";

                                            //               "update tbl_Employee_Advance set EADEDUCT=" +
                                            // Convert.ToDouble(Convert.ToDouble(loan_amt) + Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells[ll.Text].Value)) +
                                            //",EADEDUCTDT='"+ dateTimePicker1.Value.Date.ToString("dd/MMM/yyyy") +"' where (EAEID='" + eid + "') and [EAID]=(select max([EAID]) from tbl_Employee_Advance where (EAEID='" + 
                                            //  eid + "')) and ([EAAMT]-[EADEDUCT])>0 ";

                                            Command_TR(sql_update_alk);
                                        }

                                    }
                                    catch { }
                                    break;
                                }
                                if (dt_alk.Rows[ind_alk]["chkALK"].ToString() == "2") //loan
                                {

                                    string pay_Loan = dgvSalary.Rows[dgv_count].Cells[ll.Text].Value.ToString();
                                    if ((Convert.ToDouble(pay_Loan) - Convert.ToDouble(val)) != 0)
                                    {
                                        string loan_amt = "";

                                        for (int idx = 0; idx < dgvRecoveries.Rows.Count; idx++)
                                        {
                                            if (dgvRecoveries.Rows[idx].Cells["eid"].Value.ToString().Trim().ToLower() == eid.Trim().ToLower() && dgvRecoveries.Rows[idx].Cells["type"].Value.ToString().Trim().ToLower() == "loan")
                                            {
                                                if (btnSubmit.Text == "Update")
                                                {

                                                    sql_update_alk = "update tbl_Employee_LOAN set ELDEDUCT=((ELDEDUCT-" + Convert.ToDouble(val) + ")+" + Convert.ToDouble(dgvRecoveries.Rows[idx].Cells["amt"].Value) +
                                     "),ELDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (ELEID='" + eid + "') and ([ELID]='" + dgvRecoveries.Rows[idx].Cells["tid"].Value + "') and ([ELAMT]-[ELDEDUCT])>0 ";


                                                }
                                                else
                                                {

                                                    sql_update_alk = "update tbl_Employee_LOAN set ELDEDUCT=(ELDEDUCT+" + Convert.ToDouble(dgvRecoveries.Rows[idx].Cells["amt"].Value) +
                                        "),ELDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (ELEID='" + eid + "') and ([ELID]='" + dgvRecoveries.Rows[idx].Cells["tid"].Value + "') and ([ELAMT]-[ELDEDUCT])>0 ";
                                                }
                                                clsDataAccess.RunQry(sql_update_alk);
                                                //Command_TR(sql_update_alk);
                                                // break;


                                                sql_update_alk = "INSERT INTO tbl_recovery (slno,transid,salid,eid,ename,desgid,ramt,mon,coid,locid,type) VALUES (" +
                                 dgvRecoveries.Rows[idx].Cells["tid"].Value + "," + dgvRecoveries.Rows[idx].Cells["tid"].Value + ",0,'" + eid + "','" + dgvRecoveries.Rows[idx].Cells["ename"].Value + "'," + dgvRecoveries.Rows[idx].Cells["desgID"].Value + ",'" +
                                 dgvRecoveries.Rows[idx].Cells["amt"].Value + "','" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "'," + company_Id + "," + Locations + ",'Loan')";
                                                clsDataAccess.RunQry(sql_update_alk);
                                            }
                                        }

                                        ////       if (btnSubmit.Text == "Update")
                                        ////       {

                                        ////           sql_update_alk = "update tbl_Employee_LOAN set ELDEDUCT=((ELDEDUCT-" + Convert.ToDouble(val) + ")+" + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) +
                                        ////"),ELDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (ELEID='" + eid + "') and [ELID]=(select max([ELID]) from tbl_Employee_LOAN where (ELEID='" +
                                        ////eid + "')) and ([ELAMT]-[ELDEDUCT])>0 ";


                                        ////       }
                                        ////       else
                                        ////       {
                                        ////           //loan_amt = clsDataAccess.GetresultS("Select ELDEDUCT from tbl_Employee_LOAN where (ELEID='" + eid + "') and [ELID]=(select max([ELID]) from tbl_Employee_LOAN where (ELEID='" + eid + "')) and ([ELAMT]-[ELDEDUCT])>0");
                                        ////           //if (Information.IsNumeric(loan_amt) != true)
                                        ////           //{
                                        ////           //    loan_amt = "0";
                                        ////           //}

                                        ////           sql_update_alk = "update tbl_Employee_LOAN set ELDEDUCT=(ELDEDUCT+" +
                                        //// Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) +
                                        ////"),ELDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (ELEID='" + eid + "') and [ELID]=(select max([ELID]) from tbl_Employee_LOAN where (ELEID='" +
                                        ////eid + "')) and ([ELAMT]-[ELDEDUCT])>0 ";
                                        ////       }
                                        ////       Command_TR(sql_update_alk);
                                    }
                                    break;
                                }
                                if (dt_alk.Rows[ind_alk]["chkALK"].ToString() == "3") //kit
                                {
                                    string pay_Kit = dgvSalary.Rows[dgv_count].Cells[ll.Text].Value.ToString();
                                    if (Convert.ToDouble(pay_Kit) > 0)
                                    {
                                        for (int idx = 0; idx < dgvRecoveries.Rows.Count; idx++)
                                        {
                                            if (dgvRecoveries.Rows[idx].Cells["eid"].Value.ToString().Trim().ToLower() == eid.Trim().ToLower() && dgvRecoveries.Rows[idx].Cells["type"].Value.ToString().Trim().ToLower() == "kit")
                                            {
                                                if (btnSubmit.Text == "Update")
                                                {

                                                    sql_update_alk = "update tbl_Employee_KIT set EKDEDUCT=((EKDEDUCT-" + Convert.ToDouble(val) + ")+" + Convert.ToDouble(dgvRecoveries.Rows[idx].Cells["amt"].Value) +
                                       "),EKDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (EKEID='" + eid + "') and ([EKID]='" + dgvRecoveries.Rows[idx].Cells["tid"].Value + "') and ([EKAMT]-[EKDEDUCT])>0 ";

                                                }
                                                else
                                                {

                                                    sql_update_alk = "update tbl_Employee_KIT set EKDEDUCT=(EKDEDUCT+" + Convert.ToDouble(dgvRecoveries.Rows[idx].Cells["amt"].Value) +
                                         "),EKDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (EKEID='" + eid + "') and ([EKID]='" + dgvRecoveries.Rows[idx].Cells["tid"].Value + "') and ([EKAMT]-[EKDEDUCT])>0 ";
                                                }
                                                Command_TR(sql_update_alk);
                                                // break;

                                                sql_update_alk = "INSERT INTO tbl_recovery (slno,transid,salid,eid,ename,desgid,ramt,mon,coid,locid,type) VALUES (" +
                                     dgvRecoveries.Rows[idx].Cells["tid"].Value + "," + dgvRecoveries.Rows[idx].Cells["tid"].Value + ",0,'" + eid + "','" + dgvRecoveries.Rows[idx].Cells["ename"].Value + "'," + dgvRecoveries.Rows[idx].Cells["desgID"].Value + ",'" +
                                     dgvRecoveries.Rows[idx].Cells["amt"].Value + "','" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "'," + company_Id + "," + Locations + ",'Kit')";
                                                clsDataAccess.RunQry(sql_update_alk);
                                            }
                                        }
                                        ////       if (btnSubmit.Text == "Update")
                                        ////       {

                                        ////           sql_update_alk = "update tbl_Employee_KIT set EKDEDUCT=((EKDEDUCT-" + Convert.ToDouble(val) + ")+" + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) +
                                        ////"),EKDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (EKEID='" + eid + "') and [EKID]=(select max([EKID]) from tbl_Employee_KIT where (EKEID='" +
                                        ////eid + "')) and ([EKAMT]-[EKDEDUCT])>0 ";

                                        ////       }
                                        ////       else
                                        ////       {
                                        ////           sql_update_alk = "update tbl_Employee_KIT set EKDEDUCT=(EKDEDUCT+" +
                                        ////  Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) +
                                        ////"),EKDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (EKEID='" + eid + "') and [EKID]=(select max([EKID]) from tbl_Employee_KIT where (EKEID='" +
                                        ////eid + "')) and ([EKAMT]-[EKDEDUCT])>0 ";
                                        ////       }
                                        ////       Command_TR(sql_update_alk);
                                    }
                                    break;
                                }


                                if (dt_alk.Rows[ind_alk]["chkALK"].ToString() == "4") //Fine
                                {
                                    string pay_Kit = dgvSalary.Rows[dgv_count].Cells[ll.Text].Value.ToString();
                                    if (Convert.ToDouble(pay_Kit) > 0)
                                    {

                                        for (int idx = 0; idx < dgvRecoveries.Rows.Count; idx++)
                                        {
                                            if (dgvRecoveries.Rows[idx].Cells["eid"].Value.ToString().Trim().ToLower() == eid.Trim().ToLower() && dgvRecoveries.Rows[idx].Cells["type"].Value.ToString().Trim().ToLower() == "fine")
                                            {
                                                if (btnSubmit.Text == "Update")
                                                {




                                                    sql_update_alk = "update tbl_fine_log set FDEDUCT=((FDEDUCT-" + Convert.ToDouble(val) + ")+" + Convert.ToDouble(dgvRecoveries.Rows[idx].Cells["amt"].Value) +
                                         ") where (EID='" + eid + "') and ([FLID]='" + dgvRecoveries.Rows[idx].Cells["tid"].Value + "') and ([FAMT]-[FDEDUCT])>0 ";
                                                }
                                                else
                                                {


                                                    sql_update_alk = "update  tbl_fine_log set FDEDUCT=(FDEDUCT+" +
                                           Convert.ToDouble(dgvRecoveries.Rows[idx].Cells["amt"].Value) +
                                        ") where (eid='" + eid + "') and ([FLID]='" + dgvRecoveries.Rows[idx].Cells["tid"].Value + "') and ([FAMT]-[FDEDUCT])>0 ";
                                                }
                                                Command_TR(sql_update_alk);


                                                sql_update_alk = "INSERT INTO tbl_recovery (slno,transid,salid,eid,ename,desgid,ramt,mon,coid,locid,type) VALUES (" +
                                     dgvRecoveries.Rows[idx].Cells["tid"].Value + "," + dgvRecoveries.Rows[idx].Cells["tid"].Value + ",0,'" + eid + "','" + dgvRecoveries.Rows[idx].Cells["ename"].Value + "'," + dgvRecoveries.Rows[idx].Cells["desgID"].Value + ",'" +
                                     dgvRecoveries.Rows[idx].Cells["amt"].Value + "','" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "'," + company_Id + "," + Locations + ",'Fine')";
                                                clsDataAccess.RunQry(sql_update_alk);
                                            }
                                        }
                                    }
                                    break;
                                }


                            }
                        }
                    }
                }



                for (int tc = 0; tc < 1; tc++)
                {
                    Label ll = new Label();
                    TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                    ll = lbe[0];
                    tx = txte[0];
                    string _basic = "";
                    _basic = chk_pf_base(dgv_count).ToString();


                    //Convert.ToString(dataGridView1.Rows[dgv_count].Cells[ll.Text.Trim()].Value);
                    if (ll.Text.Trim() != "")
                    {
                        DataTable dt = clsDataAccess.RunQDTbl("select SlNo,SalaryHead_Full,SalaryHead_Short,Amount,Glcode from tbl_Employer_Contribution");
                        DataView dv = new DataView(dt);
                        for (int j = 0; j <= dv.Count - 1; j++)
                        {
                            string _salhead = "";
                            _salhead = dv[j]["SalaryHead_Full"].ToString().Trim();
                            double _amount = 0;
                            var v = Convert.ToDouble(_basic) * Convert.ToDouble(dv[j]["Amount"]) / 100;
                            _amount = Math.Round(v);

                            //commented for test on 27-02-2020 //  
                            s = "insert into tbl_Employee_SalaryDet_MultiDesignation(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,Designation_id) values('" + eid + "'," + get_sal_head_ID(_salhead.Trim()) + ",'tbl_Employer_Contribution'," + Convert.ToDouble(_amount) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "'," + designationid + ")";
                            s = s + Environment.NewLine + "insert into tbl_Employee_SalaryDetails(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,Designation_id) values('" + eid + "'," + get_sal_head_ID(_salhead.Trim()) + ",'tbl_Employer_Contribution'," + Convert.ToDouble(_amount) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "'," + designationid + ")";
                            Command_TR(s);
                        }
                    }
                }
            }
            else
            {
                Save_Sal_mst(eid, mon, dgv_count, sts, designationid);

                /*for (int ind = 0; ind < hd_col.Count; ind++)
                {
                    // this.dataGridView1.Columns.Remove(hd_col[ind].ToString());

                }*/
                int conf = 0;

                for (int tc = 0; tc < 16; tc++)
                {
                    Label ll = new Label();
                    TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();

                    ll = lbe[tc];
                    tx = txte[tc];
                    for (int ind = 0; ind < hd_col.Count; ind++)
                    {
                        if (hd_col[ind].ToString() != ll.Text.Trim())
                        {
                            conf = 0;
                        }
                        else
                        {
                            conf = 1;
                            break;

                        }
                    }

                    if (ll.Text.Trim() != "" && conf == 0)
                    {
                        if (Convert.ToString(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) == "")
                            dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value = "0";

                        s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,Designation_id) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "'," + designationid + ")";
                        s = s + Environment.NewLine + "insert into tbl_Employee_SalaryDetails(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,Designation_id) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "'," + designationid + ")";
                        Command_TR(s);
                        try
                        {
                            if (dgvGross.Columns.Contains(get_sal_head_ID(ll.Text.Trim()).ToString()))
                            {
                                s = "insert into tbl_Employee_SalaryGross(EID,EmpId,SalId,TableName,Amount,Month,InsertionDate,Location_id,Company_id,client_id,desgid,hd) values((select isNull(Max(eid),0)+1 from tbl_Employee_SalaryGross where EmpId='" + eid + "' and Month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "' and location_id='" + Locations + "' ),'" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(dgvGross.Rows[dgv_count].Cells[get_sal_head_ID(ll.Text.Trim()).ToString()].Value) + ",'" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "','" + DateTime.Now.Date.ToString("dd/MMM/yyyy") + "','" + Locations + "','" + company_Id + "','" + lblClid.Text + "','" + designationid + "','" + ll.Text.Trim() + "')";
                                Command_TR(s);
                            }
                        }
                        catch { }
                    }

                }
                //try
                //{
                //    for (int ix = 0; ix < dgvGross.Columns.Count;ix++ )
                //    {
                //        if (dataGridView_stocktransferlist.Columns.Contains("btn"))
                //        {
                //            s = "insert into tbl_Employee_SalaryGross(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,desgid,hd) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells[ll.Text.Trim()].Value) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "')";
                //            Command_TR(s);
                //        }
                //    }
                //}
                //catch { }
                DataTable dt_alk = new DataTable();
                string sql_update_alk = "", sql_alk = "";
                try
                {
                    sql_alk = "select SAL_HEAD,(select SalaryHead_Short FROM tbl_Employee_DeductionSalayHead where SlNo=eas.SAL_HEAD)as HEAD,chkALK from tbl_Employee_Assign_SalStructure eas where sal_struct=" + salary_structure + " and p_type='D' AND (chkALK > 0)";

                    dt_alk = clsDataAccess.RunQDTbl(sql_alk);
                }
                catch { }


                for (int tc = 0; tc < 16; tc++)
                {
                    Label ll = new Label();
                    TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                    ll = lbd[tc];
                    tx = txtd[tc];
                    if (ll.Text.Trim() != "")
                    {
                        try
                        {
                            if (Convert.ToString(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) == "")
                                dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value = "0";
                        }
                        catch { }
                        try
                        {
                            s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,Designation_id) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_DeductionSalayHead'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "'," + designationid + ")";
                            s = s + Environment.NewLine + "insert into tbl_Employee_SalaryDetails(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,Designation_id) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_DeductionSalayHead'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text.Trim()].Value) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "'," + designationid + ")";
                            Command_TR(s);
                        }
                        catch { }
                        for (int ind_alk = 0; ind_alk < dt_alk.Rows.Count; ind_alk++)
                        {
                            if (dt_alk.Rows[ind_alk]["HEAD"].ToString() == ll.Text)
                            {
                                //if (Convert.ToDouble(tx.Text) > 0)
                                //{
                                Int32 colc = Convert.ToInt32(tsal_table.Columns.IndexOf(ll.Text));
                                double val = 0;
                                try
                                {
                                    DataRow[] dr = tsal_table.Select("ID='" + eid.ToString() + "'");

                                    if (dr.Length > 0 && btnSubmit.Text == "Update")
                                    {
                                        val = Convert.ToDouble(dr[0][colc].ToString());
                                    }
                                    else
                                    {
                                        val = 0;
                                    }
                                }
                                catch
                                {
                                    val = 0;
                                }

                                if (dt_alk.Rows[ind_alk]["chkALK"].ToString() == "1") //advance
                                {
                                    //string loan_amt = clsDataAccess.GetresultS("Select EADEDUCT from tbl_Employee_Advance where (EAEID='" + eid + "') and [EAID]=(select max([EAID]) from tbl_Employee_Advance where (EAEID='" + eid + "')) and ([EAAMT]-[EADEDUCT])>0");
                                    //if (Information.IsNumeric(loan_amt) != true)
                                    //{
                                    //    loan_amt = "0";
                                    //}

                                    int ind_Adv = 0;

                                    try
                                    {
                                        if (Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value.ToString()) > 0)
                                        {

                                            try
                                            {

                                                ind_Adv = Convert.ToInt32(clsDataAccess.GetresultS("Select (isNull(max(EAID),0)+1)advno from tbl_Employee_Advance"));
                                            }
                                            catch
                                            {
                                                ind_Adv = 1;
                                            }
                                            for (int idx = 0; idx < dgvRecoveries.Rows.Count; idx++)
                                            {
                                                if (dgvRecoveries.Rows[idx].Cells["eid"].Value.ToString().Trim().ToLower() == eid.Trim().ToLower() && dgvRecoveries.Rows[idx].Cells["type"].Value.ToString().Trim().ToLower() == "advance")
                                                {

                                                    sql_update_alk = "INSERT INTO tbl_recovery (slno,transid,salid,eid,ename,desgid,ramt,mon,coid,locid,type) VALUES (" +
                                     dgvRecoveries.Rows[idx].Cells["tid"].Value + "," + dgvRecoveries.Rows[idx].Cells["tid"].Value + "," + ind_Adv +
                                     ",'" + eid + "','" + dgvRecoveries.Rows[idx].Cells["ename"].Value + "'," + dgvRecoveries.Rows[idx].Cells["desgID"].Value + ",'" +
                                     dgvRecoveries.Rows[idx].Cells["amt"].Value + "','" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "'," + company_Id + "," + Locations + ",'Advance')";
                                                    clsDataAccess.RunQry(sql_update_alk);
                                                }
                                            }

                                            if (btnSubmit.Text == "Update")
                                            {
                                                sql_update_alk = "Delete from tbl_Employee_Advance where (EAEID='" + eid + "') and ([EAMONTH]='" + AttenDtTmPkr.Value.ToString("MMMM/ yyyy") + "') and ([CoID]='" + company_Id + "') and ([LocID]='" + Locations + "')";

                                                Command_TR(sql_update_alk);

                                            }

                                            sql_update_alk = "insert into tbl_Employee_Advance([EAID],[EAEID],[EANAME]," +
                                            "[EADT],[EAMONTH],[EAAMT],[EADEDUCT],[EADEDUCTDT],[SLNO],[CoID],[LocID],[LocName],[remarks]) values (" + ind_Adv + ",'" +
                                            eid + "','" + ename.Trim() + "','" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "','" + AttenDtTmPkr.Value.ToString("MMMM/ yyyy") +
                                            "',0," + (dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) + ",'" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") +
                                            "',1," + company_Id + "," + Locations + ",'" + cmbLocation.Text + "','Advance')";

                                            //               "update tbl_Employee_Advance set EADEDUCT=" +
                                            // Convert.ToDouble(Convert.ToDouble(loan_amt) + Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells[ll.Text].Value)) +
                                            //",EADEDUCTDT='"+ dateTimePicker1.Value.Date.ToString("dd/MMM/yyyy") +"' where (EAEID='" + eid + "') and [EAID]=(select max([EAID]) from tbl_Employee_Advance where (EAEID='" + 
                                            //  eid + "')) and ([EAAMT]-[EADEDUCT])>0 ";
                                            clsDataAccess.RunQry(sql_update_alk);
                                            //Command_TR(sql_update_alk);
                                        }

                                    }
                                    catch { }
                                    break;
                                }
                                if (dt_alk.Rows[ind_alk]["chkALK"].ToString() == "2") //loan
                                {

                                    string pay_Loan = dgvSalary.Rows[dgv_count].Cells[ll.Text].Value.ToString();
                                    if ((Convert.ToDouble(pay_Loan) - Convert.ToDouble(val)) != 0)
                                    {

                                        string loan_amt = "";
                                        if (Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) > 0)
                                        {
                                            //dgvRecoveries.Columns.Add("tid", "trans id");
                                            //dgvRecoveries.Columns.Add("eid", "Emp code");
                                            //dgvRecoveries.Columns.Add("desgID", "desg id");
                                            //dgvRecoveries.Columns.Add("ename", "Name");
                                            //dgvRecoveries.Columns.Add("desg", "Designation");
                                            //dgvRecoveries.Columns.Add("amt", "Recover");
                                            //dgvRecoveries.Columns.Add("type", "Recovery");
                                            for (int idx = 0; idx < dgvRecoveries.Rows.Count; idx++)
                                            {
                                                if (dgvRecoveries.Rows[idx].Cells["eid"].Value.ToString().Trim().ToLower() == eid.Trim().ToLower() && dgvRecoveries.Rows[idx].Cells["type"].Value.ToString().Trim().ToLower() == "loan")
                                                {
                                                    if (btnSubmit.Text == "Update")
                                                    {

                                                        //           sql_update_alk = "update tbl_Employee_LOAN set ELDEDUCT=((ELDEDUCT-" + Convert.ToDouble(val) + ")+" + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) +
                                                        //"),ELDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (ELEID='" + eid + "') and [ELID]=(select max([ELID]) from tbl_Employee_LOAN where (ELEID='" +
                                                        //eid + "')) and ([ELAMT]-[ELDEDUCT])>0 ";


                                                        sql_update_alk = "update tbl_Employee_LOAN set ELDEDUCT=((ELDEDUCT-" + Convert.ToDouble(val) + ")+" + Convert.ToDouble(dgvRecoveries.Rows[idx].Cells["amt"].Value) +
                                         "),ELDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (ELEID='" + eid + "') and ([ELID]='" + dgvRecoveries.Rows[idx].Cells["tid"].Value + "') and ([ELAMT]-[ELDEDUCT])>0 ";


                                                    }
                                                    else
                                                    {
                                                        //loan_amt = clsDataAccess.GetresultS("Select ELDEDUCT from tbl_Employee_LOAN where (ELEID='" + eid + "') and [ELID]=(select max([ELID]) from tbl_Employee_LOAN where (ELEID='" + eid + "')) and ([ELAMT]-[ELDEDUCT])>0");
                                                        //if (Information.IsNumeric(loan_amt) != true)
                                                        //{
                                                        //    loan_amt = "0";
                                                        //}

                                                        //           sql_update_alk = "update tbl_Employee_LOAN set ELDEDUCT=(ELDEDUCT+" +
                                                        // Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) +
                                                        //"),ELDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (ELEID='" + eid + "') and [ELID]=(select max([ELID]) from tbl_Employee_LOAN where (ELEID='" +
                                                        //eid + "')) and ([ELAMT]-[ELDEDUCT])>0 ";
                                                        sql_update_alk = "update tbl_Employee_LOAN set ELDEDUCT=(ELDEDUCT+" + Convert.ToDouble(dgvRecoveries.Rows[idx].Cells["amt"].Value) +
                                            "),ELDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (ELEID='" + eid + "') and ([ELID]='" + dgvRecoveries.Rows[idx].Cells["tid"].Value + "') and ([ELAMT]-[ELDEDUCT])>0 ";
                                                    }
                                                    clsDataAccess.RunQry(sql_update_alk);
                                                    //Command_TR(sql_update_alk);
                                                    // break;


                                                    sql_update_alk = "INSERT INTO tbl_recovery (slno,transid,salid,eid,ename,desgid,ramt,mon,coid,locid,type) VALUES (" +
                                     dgvRecoveries.Rows[idx].Cells["tid"].Value + "," + dgvRecoveries.Rows[idx].Cells["tid"].Value + ",0,'" + eid + "','" + dgvRecoveries.Rows[idx].Cells["ename"].Value + "'," + dgvRecoveries.Rows[idx].Cells["desgID"].Value + ",'" +
                                     dgvRecoveries.Rows[idx].Cells["amt"].Value + "','" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "'," + company_Id + "," + Locations + ",'Loan')";
                                                    clsDataAccess.RunQry(sql_update_alk);
                                                }
                                            }

                                        }
                                    }

                                    break;
                                }
                                if (dt_alk.Rows[ind_alk]["chkALK"].ToString() == "3") //kit
                                {
                                    string pay_Kit = dgvSalary.Rows[dgv_count].Cells[ll.Text].Value.ToString();
                                    if (Convert.ToDouble(pay_Kit) > 0)
                                    {
                                        //string loan_amt = clsDataAccess.GetresultS("Select EKDEDUCT from tbl_Employee_KIT where (EKEID='" + eid + "') and [EKID]=(select max([EKID]) from tbl_Employee_KIT where (EKEID='" + eid + "')) and ([EKAMT]-[EKDEDUCT])>0");

                                        //if (Information.IsNumeric(loan_amt) != true)
                                        //{
                                        //    loan_amt = "0";
                                        //}

                                        //dgvRecoveries.Columns.Add("tid", "trans id");
                                        //dgvRecoveries.Columns.Add("eid", "Emp code");
                                        //dgvRecoveries.Columns.Add("desgID", "desg id");
                                        //dgvRecoveries.Columns.Add("ename", "Name");
                                        //dgvRecoveries.Columns.Add("desg", "Designation");
                                        //dgvRecoveries.Columns.Add("amt", "Recover");
                                        //dgvRecoveries.Columns.Add("type", "Recovery");
                                        for (int idx = 0; idx < dgvRecoveries.Rows.Count; idx++)
                                        {
                                            if (dgvRecoveries.Rows[idx].Cells["eid"].Value.ToString().Trim().ToLower() == eid.Trim().ToLower() && dgvRecoveries.Rows[idx].Cells["type"].Value.ToString().Trim().ToLower() == "kit")
                                            {
                                                if (btnSubmit.Text == "Update")
                                                {

                                                    //           sql_update_alk = "update tbl_Employee_KIT set EKDEDUCT=((EKDEDUCT-" + Convert.ToDouble(val) + ")+" + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) +
                                                    //"),EKDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (EKEID='" + eid + "') and [EKID]=(select max([EKID]) from tbl_Employee_KIT where (EKEID='" +
                                                    //eid + "')) and ([EKAMT]-[EKDEDUCT])>0 ";


                                                    sql_update_alk = "update tbl_Employee_KIT set EKDEDUCT=((EKDEDUCT-" + Convert.ToDouble(val) + ")+" + Convert.ToDouble(dgvRecoveries.Rows[idx].Cells["amt"].Value) +
                                       "),EKDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (EKEID='" + eid + "') and ([EKID]='" + dgvRecoveries.Rows[idx].Cells["tid"].Value + "') and ([EKAMT]-[EKDEDUCT])>0 ";

                                                }
                                                else
                                                {
                                                    //           sql_update_alk = "update tbl_Employee_KIT set EKDEDUCT=(EKDEDUCT+" +
                                                    //  Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) +
                                                    //"),EKDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (EKEID='" + eid + "') and [EKID]=(select max([EKID]) from tbl_Employee_KIT where (EKEID='" +
                                                    //eid + "')) and ([EKAMT]-[EKDEDUCT])>0 ";

                                                    sql_update_alk = "update tbl_Employee_KIT set EKDEDUCT=(EKDEDUCT+" + Convert.ToDouble(dgvRecoveries.Rows[idx].Cells["amt"].Value) +
                                         "),EKDEDUCTDT='" + AttenDtTmPkr.Value.Date.ToString("dd/MMM/yyyy") + "' where (EKEID='" + eid + "') and ([EKID]='" + dgvRecoveries.Rows[idx].Cells["tid"].Value + "') and ([EKAMT]-[EKDEDUCT])>0 ";
                                                }
                                                Command_TR(sql_update_alk);
                                                // break;

                                                sql_update_alk = "INSERT INTO tbl_recovery (slno,transid,salid,eid,ename,desgid,ramt,mon,coid,locid,type) VALUES (" +
                                     dgvRecoveries.Rows[idx].Cells["tid"].Value + "," + dgvRecoveries.Rows[idx].Cells["tid"].Value + ",0,'" + eid + "','" + dgvRecoveries.Rows[idx].Cells["ename"].Value + "'," + dgvRecoveries.Rows[idx].Cells["desgID"].Value + ",'" +
                                     dgvRecoveries.Rows[idx].Cells["amt"].Value + "','" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "'," + company_Id + "," + Locations + ",'Kit')";
                                                clsDataAccess.RunQry(sql_update_alk);
                                            }
                                        }
                                    }
                                    break;
                                }

                                if (dt_alk.Rows[ind_alk]["chkALK"].ToString() == "4") //Fine
                                {
                                    string pay_Kit = dgvSalary.Rows[dgv_count].Cells[ll.Text].Value.ToString();
                                    if (Convert.ToDouble(pay_Kit) > 0)
                                    {
                                        //string loan_amt = clsDataAccess.GetresultS("Select EKDEDUCT from tbl_Employee_KIT where (EKEID='" + eid + "') and [EKID]=(select max([EKID]) from tbl_Employee_KIT where (EKEID='" + eid + "')) and ([EKAMT]-[EKDEDUCT])>0");

                                        //if (Information.IsNumeric(loan_amt) != true)
                                        //{
                                        //    loan_amt = "0";
                                        //}
                                        for (int idx = 0; idx < dgvRecoveries.Rows.Count; idx++)
                                        {
                                            if (dgvRecoveries.Rows[idx].Cells["eid"].Value.ToString().Trim().ToLower() == eid.Trim().ToLower() && dgvRecoveries.Rows[idx].Cells["type"].Value.ToString().Trim().ToLower() == "fine")
                                            {
                                                if (btnSubmit.Text == "Update")
                                                {

                                                    //           sql_update_alk = "update tbl_fine_log set FDEDUCT=((FDEDUCT-" + Convert.ToDouble(val) + ")+" + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) +
                                                    //") where (EID='" + eid + "') and [FLID]=(select max([FLID]) from  tbl_fine_log where (eid='" +
                                                    //eid + "')) and ([FAMT]-[FDEDUCT])>0 ";


                                                    sql_update_alk = "update tbl_fine_log set FDEDUCT=((FDEDUCT-" + Convert.ToDouble(val) + ")+" + Convert.ToDouble(dgvRecoveries.Rows[idx].Cells["amt"].Value) +
                                         ") where (EID='" + eid + "') and ([FLID]='" + dgvRecoveries.Rows[idx].Cells["tid"].Value + "') and ([FAMT]-[FDEDUCT])>0 ";
                                                }
                                                else
                                                {
                                                    //           sql_update_alk = "update  tbl_fine_log set FDEDUCT=(FDEDUCT+" +
                                                    //  Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ll.Text].Value) +
                                                    //") where (eid='" + eid + "') and [FLID]=(select max([FLID]) from  tbl_fine_log where (eid='" +
                                                    //eid + "')) and ([FAMT]-[FDEDUCT])>0 ";

                                                    sql_update_alk = "update  tbl_fine_log set FDEDUCT=(FDEDUCT+" +
                                           Convert.ToDouble(dgvRecoveries.Rows[idx].Cells["amt"].Value) +
                                        ") where (eid='" + eid + "') and ([FLID]='" + dgvRecoveries.Rows[idx].Cells["tid"].Value + "') and ([FAMT]-[FDEDUCT])>0 ";
                                                }
                                                Command_TR(sql_update_alk);


                                                sql_update_alk = "INSERT INTO tbl_recovery (slno,transid,salid,eid,ename,desgid,ramt,mon,coid,locid,type) VALUES (" +
                                     dgvRecoveries.Rows[idx].Cells["tid"].Value + "," + dgvRecoveries.Rows[idx].Cells["tid"].Value + ",0,'" + eid + "','" + dgvRecoveries.Rows[idx].Cells["ename"].Value + "'," + dgvRecoveries.Rows[idx].Cells["desgID"].Value + ",'" +
                                     dgvRecoveries.Rows[idx].Cells["amt"].Value + "','" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "'," + company_Id + "," + Locations + ",'Fine')";
                                                clsDataAccess.RunQry(sql_update_alk);
                                            }
                                        }
                                    }
                                    break;
                                }

                                //}
                            }
                        }
                    }
                    else
                    {

                        break;
                    }
                }


                try
                {
                    for (int tc = 0; tc < 1; tc++)
                    {
                        Label ll = new Label();
                        TextBoxX.TextBoxX tx = new TextBoxX.TextBoxX();
                        ll = lbe[tc];
                        tx = txte[tc];
                        for (int ind = 0; ind < hd_col.Count; ind++)
                        {
                            if (hd_col[ind].ToString() != ll.Text.Trim())
                            {
                                conf = 0;
                            }
                            else
                            {
                                conf = 1;
                                break;

                            }
                        }
                        string _basic = "0";

                        if (ll.Text.Trim() != "" && conf == 0)
                        {
                            string[] ps_brk = lbl_Pf_formula.Text.Split('*');

                            string[] ps_hd = ps_brk[0].ToString().Replace("(", "").Replace(")", "").Trim().Split('+');
                            for (int id = 0; id < ps_hd.Length; id++)
                            {
                                try
                                {
                                    _basic = (Convert.ToDouble(_basic) + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ps_hd[id].ToString()].Value)).ToString();
                                }
                                catch
                                {
                                    _basic = (Convert.ToDouble(0) + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells[ps_hd[id].ToString()].Value)).ToString();
                                }
                                //Convert.ToString(dataGridView1.Rows[dgv_count].Cells[ll.Text.Trim()].Value);
                            }
                            DataTable dt = clsDataAccess.RunQDTbl("select SlNo,SalaryHead_Full,SalaryHead_Short,Amount,Glcode from tbl_Employer_Contribution");
                            DataView dv = new DataView(dt);
                            for (int j = 0; j <= dv.Count - 1; j++)
                            {
                                string _salhead = "";
                                _salhead = dv[j]["SalaryHead_Full"].ToString().Trim();
                                double _amount = 0;
                                _amount = Convert.ToDouble(_basic) * Convert.ToDouble(dv[j]["Amount"]) / 100;
                                s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,Designation_id) values('" + eid + "'," + get_sal_head_ID(_salhead.Trim()) + ",'tbl_Employer_Contribution'," + Convert.ToDouble(_amount) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "'," + designationid + ")";
                                s = s + Environment.NewLine + "insert into tbl_Employee_SalaryDetails(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id,Designation_id) values('" + eid + "'," + get_sal_head_ID(_salhead.Trim()) + ",'tbl_Employer_Contribution'," + Convert.ToDouble(_amount) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "'," + designationid + ")";
                                Command_TR(s);
                            }
                        }
                    }
                }
                catch { }
            }




        }



        public void Save_Sal_mst(string eid, string month, int dgv_count, int sts, string designation)
        {
            try
            {
                string s = "";
                //Following qry will be added after approving the multidesignation concept
                s = "insert into tbl_Employee_SalaryMast(Emp_Id,TotalSal,TotalDec,NetPay,Month,Session," +
                    "DaysPresent,LeaveWithPay,LeaveWithoutPay,TotalDays,GrossAmount,PFDue,TotalPF,Date_of_Insert," +
                    "Basic,Location_id,OT,Calculate_day,Company_id,Chk_A,Chk_L,Chk_K,[desig_id],[Acc_transfer],[bill_tag],status,ed,[desgid]) values('" + eid + "'," +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["Total_Earning"].Value) + "," +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["Total_Deduction"].Value) + "," +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["Net_Pay"].Value) + ",'" + month.Trim() + "','" +
                    cmbYear.Text.Trim() + "'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["W_Day"].Value) +
                    ",'0','0'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["Tot_Day"].Value) + "," +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["Total_Earning"].Value) + ",'0','0','" +
                    Convert.ToDateTime(dtp_DOE.Value).ToString("dd/MMM/yyyy") + "','" +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["Salary"].Value) + "','" + Locations + "','" +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["O_T"].Value) + "','" + txtcalculated_days.Text + "','" +
                    company_Id + "','" + chk_A + "','" + chk_L + "','" + chk_K + "',0,0,0,'" + sts + "','" +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["E_D"].Value) + "','" + designation + "')";
                /*s = "insert into tbl_Employee_SalaryMast(Emp_Id,TotalSal,TotalDec,NetPay,Month,Session," +
                    "DaysPresent,LeaveWithPay,LeaveWithoutPay,TotalDays,GrossAmount,PFDue,TotalPF,Date_of_Insert," +
                    "Basic,Location_id,OT,Calculate_day,Company_id,Chk_A,Chk_L,Chk_K) values('" + eid + "'," +
                    Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells["Total_Earning"].Value) + "," +
                    Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells["Total_Deduction"].Value) + "," +
                    Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells["Net_Pay"].Value) + ",'" + month.Trim() + "','" +
                    cmbYear.Text.Trim() + "'," + Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells["W_Day"].Value) +
                    ",'0','0'," + Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells["Tot_Day"].Value) + "," +
                    Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells["Total_Earning"].Value) + ",'0','0','" +
                    Convert.ToDateTime(dtpidate.Value).Date.ToString("MM/dd/yyyy") + "','" +
                    Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells["Salary"].Value) + "','" + Locations + "','" +
                    Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells["O_T"].Value) + "','" + txtcalculated_days.Text + "','" +
                    company_Id + "','" + chk_A + "','" + chk_L + "','" + chk_K + "')";*/
                Command_TR(s);
            }
            catch
            {

            }

        }

        public void Save_Sal_mst_multidesignation_singleLoc(string eid, string designation, string month, int dgv_count, int sts)
        {
            try
            {
                string s = "";
                s = "insert into tbl_Employee_SalaryMast(Emp_Id,TotalSal,TotalDec,NetPay,Month,Session," +
                    "DaysPresent,LeaveWithPay,LeaveWithoutPay,TotalDays,GrossAmount,PFDue,TotalPF,Date_of_Insert," +
                    "Basic,Location_id,OT,Calculate_day,Company_id,Chk_A,Chk_L,Chk_K,desig_id,status,[Acc_transfer],[bill_tag],[ed],[desgid]) values('" + eid + "'," +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["Total_Earning"].Value) + "," +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["Total_Deduction"].Value) + "," +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["Net_Pay"].Value) + ",'" + month.Trim() + "','" +
                    cmbYear.Text.Trim() + "'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["W_Day"].Value) +
                    ",'0','0'," + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["Tot_Day"].Value) + "," +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["Total_Earning"].Value) + ",'0','0','" +
                    Convert.ToDateTime(dtpidate.Value).Date.ToString("MM/dd/yyyy") + "','" +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["Salary"].Value) + "','" + Locations + "','" +
                    Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["O_T"].Value) + "','" + txtcalculated_days.Text + "','" +
                    company_Id + "','" + chk_A + "','" + chk_L + "','" + chk_K + "','" + designation + "','" + sts + "',0,0,'" + Convert.ToDouble(dgvSalary.Rows[dgv_count].Cells["E_D"].Value) + "','" + designation + "')";
                Command_TR(s);
            }
            catch
            {

            }

        }

        private void Retrive_Data()
        {
            Boolean flug_deduction = false;
            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            try
            {
                dgvGross.Rows.Clear();

                dgvGross.Columns.Clear();
            }
            catch { }
            this.dgvGross.Columns.Add("Sl", "SL");
            dgvGross.Columns.Add("EmployeeName", "Employee Name");
            dgvGross.Columns.Add("eid", "EID");
            dgvGross.Columns.Add("did", "Dsgid");
            //get_gr_head();

            int intConditionCase = 0;
            intConditionCase = Convert.ToInt32(lblStatusCode.Text);
            string strConditions = "";
            switch (intConditionCase)
            {
                case 2:
                    strConditions = " and em.PF_Deduction = 0 "; //Employee with pf deduction not elegible wont show 
                    break;
                case 3:
                    strConditions = " and em.ESI_Deduction = 0 "; //Employee with esi deduction not elegible wont show 
                    break;
                case 1:
                    strConditions = " and em.PF_Deduction = 0 and em.ESI_Deduction = 0 "; //Employee with pf and esi deduction not elegible wont show[THIS WILL BE THE DEFAULT CASE]
                    break;

            }

            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl, ' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployeeName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,cast(sm.OT as decimal(18,2)) O_T,cast(sm.TotalDays as decimal(18,2)) Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT = sm.Emp_Id COLLATE DATABASE_DEFAULT");
            DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT distinct null as sl,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmployeeName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,cast(sm.OT as decimal(18,2)) O_T,cast(isNUll(sm.ed,0) as decimal(18,2)) E_D,cast(sm.TotalDays as decimal(18,2)) Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay,sm.desgid as DesgID FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT = sm.Emp_Id COLLATE DATABASE_DEFAULT " + strConditions + " order by sm.Emp_Id asc");

            DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id FROM tbl_Employee_SalaryDetails where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' and TableName!='tbl_Employer_Contribution' order by Slno");

            DataTable salary_details_MultiDesignation = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' and TableName!='tbl_Employer_Contribution' order by Slno");

            DataTable dt_recov = clsDataAccess.RunQDTbl("SELECT slno,transid,salid,eid,ename,desgid,ramt,mon,coid,locid,type FROM tbl_recovery WHERE (mon = '" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "') AND (coid = '" + company_Id + "') AND (locid = '" + Locations + "')");
            DataTable leave_details = clsDataAccess.RunQDTbl("Select ShortName,TotalLeaves from tbl_Employee_Config_LeaveDetails where Session='" + cmbYear.Text + "' and Location_id = '" + Locations + "'");


            if (dt_recov.Rows.Count > 0)
            {
                try
                {
                    dgvRecoveries.Columns.Clear();

                    dgvRecoveries.Columns.Add("tid", "trans id");
                    dgvRecoveries.Columns.Add("eid", "Emp code");
                    dgvRecoveries.Columns.Add("desgID", "desg id");
                    dgvRecoveries.Columns.Add("ename", "Name");
                    dgvRecoveries.Columns.Add("desg", "Designation");
                    dgvRecoveries.Columns.Add("amt", "Recover");
                    dgvRecoveries.Columns.Add("type", "Recovery");

                    dgvRecoveries.Columns["tid"].Visible = false;
                    dgvRecoveries.Columns["desgid"].Visible = false;

                }
                catch { }

                //slno, transid, salid, eid, ename, desgid, ramt, mon, coid, locid, type 
                int rw_alfk = 0;
                for (int idx = 0; idx < dt_recov.Rows.Count; idx++)
                {
                    rw_alfk = dgvRecoveries.Rows.Add();
                    dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = dt_recov.Rows[idx]["transid"].ToString().Trim();
                    dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = dt_recov.Rows[idx]["eid"].ToString().Trim();
                    dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = dt_recov.Rows[idx]["desgid"].ToString().Trim();
                    dgvRecoveries.Rows[rw_alfk].Cells["ename"].Value = dt_recov.Rows[idx]["ename"].ToString().Trim();
                    dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = dt_recov.Rows[idx]["ramt"].ToString().Trim();
                    dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = dt_recov.Rows[idx]["type"].ToString().Trim();
                }





            }

            DataView dv = new DataView(salary_details);
            //DataView dv1 = new DataView(salary_details_MultiDesignation);
            int table_count = tot_employ.Columns.Count;
            //gr_earning(tot_employ);
            int dt_count = tot_employ.Rows.Count;
            tot_employ.Rows.Add();
            int counter = 0;
            Boolean flagEndOfSingleDesignation = false;

            for (int i = 0; i <= tot_employ.Rows.Count - 2; i++)
            {
                if (tot_employ.Rows[i]["DesgID"].ToString().Trim() == "0")
                {
                    flagEndOfSingleDesignation = false;
                    dv = new DataView(salary_details);
                    dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' ";

                    try { gr_earning(tot_employ, i); }
                    catch
                    { }
                    for (int j = 0; j <= dv.Count - 1; j++)
                    {
                        string _tablename = "";
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                tot_employ.Rows[dt_count][1] = "                Total :";
                                txtcalculated_days.Text = clsDataAccess.GetresultS("select Calculate_day from tbl_Employee_SalaryMast where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "'   ");
                            }

                            if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                            {
                                table_count = tot_employ.Columns.Count;
                                flug_deduction = true;
                                counter = j;
                            }


                            if (dv[j]["TableName"].ToString().Trim() != "tbl_Employer_Contribution")
                            {
                                string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "' ");
                                tot_employ.Columns.Add(Salary_Head, typeof(string));    //Add All Earning and Deduction head columns
                                tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                                tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];

                                if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead")
                                {
                                    lbd[j - counter].Text = Salary_Head;
                                }
                                else
                                {
                                    lbe[j].Text = Salary_Head;

                                }
                            }

                        }
                        else
                        {
                            if (dv[j]["TableName"].ToString().Trim() != "tbl_Employer_Contribution")
                            {
                                tot_employ.Rows[i][j + 12] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count][j + 12] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][j + 12]) + Convert.ToDouble(dv[j]["Amount"]));
                            }

                        }
                    }
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["Total_Earning"]) == false)
                        tot_employ.Rows[dt_count]["Total_Earning"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["Total_Deduction"]) == false)
                        tot_employ.Rows[dt_count]["Total_Deduction"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["Net_Pay"]) == false)
                        tot_employ.Rows[dt_count]["Net_Pay"] = 0;

                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["W_Day"]) == false)
                        tot_employ.Rows[dt_count]["W_Day"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["O_T"]) == false)
                        tot_employ.Rows[dt_count]["O_T"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["E_D"]) == false)
                        tot_employ.Rows[dt_count]["E_D"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["Tot_Day"]) == false)
                        tot_employ.Rows[dt_count]["Tot_Day"] = 0;

                    tot_employ.Rows[i]["sl"] = i + 1;

                    tot_employ.Rows[dt_count]["Total_Earning"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Total_Earning"]) + Convert.ToDouble(tot_employ.Rows[i]["Total_Earning"]));
                    tot_employ.Rows[dt_count]["Total_Deduction"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Total_Deduction"]) + Convert.ToDouble(tot_employ.Rows[i]["Total_Deduction"]));
                    tot_employ.Rows[dt_count]["Net_Pay"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Net_Pay"]) + Convert.ToDouble(tot_employ.Rows[i]["Net_Pay"]));

                    tot_employ.Rows[dt_count]["W_Day"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["W_Day"]) + Convert.ToDouble(tot_employ.Rows[i]["W_Day"]));
                    tot_employ.Rows[dt_count]["O_T"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["O_T"]) + Convert.ToDouble(tot_employ.Rows[i]["O_T"]));
                    tot_employ.Rows[dt_count]["E_D"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["E_D"]) + Convert.ToDouble(tot_employ.Rows[i]["E_D"]));
                    tot_employ.Rows[dt_count]["Tot_Day"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Tot_Day"]) + Convert.ToDouble(tot_employ.Rows[i]["Tot_Day"]));
                    continue;
                }
                if (!flagEndOfSingleDesignation)
                {
                    dv = new DataView(salary_details);
                    //(salary_details_MultiDesignation);
                    flagEndOfSingleDesignation = true;
                }


                dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["DesgID"] + "'";

                for (int j = 0; j <= dv.Count - 1; j++)
                {
                    string _tablename = "";
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            tot_employ.Rows[dt_count][1] = "                Total :";
                            txtcalculated_days.Text = clsDataAccess.GetresultS("select Calculate_day from tbl_Employee_SalaryMast where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "'   ");
                        }

                        if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                        {
                            table_count = tot_employ.Columns.Count;
                            flug_deduction = true;
                            counter = j;
                        }


                        if (dv[j]["TableName"].ToString().Trim() != "tbl_Employer_Contribution")
                        {
                            string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "' ");
                            tot_employ.Columns.Add(Salary_Head, typeof(string));    //Add All Earning and Deduction head columns
                            tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                            tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];

                            if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead")
                            {
                                lbd[j - counter].Text = Salary_Head;
                            }
                            else
                            {
                                lbe[j].Text = Salary_Head;

                            }
                        }

                    }
                    else
                    {
                        if (dv[j]["TableName"].ToString().Trim() != "tbl_Employer_Contribution")
                        {
                            tot_employ.Rows[i][j + 12] = dv[j]["Amount"];
                            tot_employ.Rows[dt_count][j + 12] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][j + 12]) + Convert.ToDouble(dv[j]["Amount"]));
                        }
                    }
                }
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["Total_Earning"]) == false)
                    tot_employ.Rows[dt_count]["Total_Earning"] = 0;
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["Total_Deduction"]) == false)
                    tot_employ.Rows[dt_count]["Total_Deduction"] = 0;
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["Net_Pay"]) == false)
                    tot_employ.Rows[dt_count]["Net_Pay"] = 0;

                if (Information.IsNumeric(tot_employ.Rows[dt_count]["W_Day"]) == false)
                    tot_employ.Rows[dt_count]["W_Day"] = 0;
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["O_T"]) == false)
                    tot_employ.Rows[dt_count]["O_T"] = 0;
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["Tot_Day"]) == false)
                    tot_employ.Rows[dt_count]["Tot_Day"] = 0;

                tot_employ.Rows[i]["sl"] = i + 1;

                tot_employ.Rows[dt_count]["Total_Earning"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Total_Earning"]) + Convert.ToDouble(tot_employ.Rows[i]["Total_Earning"]));
                tot_employ.Rows[dt_count]["Total_Deduction"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Total_Deduction"]) + Convert.ToDouble(tot_employ.Rows[i]["Total_Deduction"]));
                tot_employ.Rows[dt_count]["Net_Pay"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Net_Pay"]) + Convert.ToDouble(tot_employ.Rows[i]["Net_Pay"]));

                tot_employ.Rows[dt_count]["W_Day"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["W_Day"]) + Convert.ToDouble(tot_employ.Rows[i]["W_Day"]));
                tot_employ.Rows[dt_count]["O_T"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["O_T"]) + Convert.ToDouble(tot_employ.Rows[i]["O_T"]));
                tot_employ.Rows[dt_count]["Tot_Day"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Tot_Day"]) + Convert.ToDouble(tot_employ.Rows[i]["Tot_Day"]));

            }

            tot_employ.Columns["Total_Earning"].SetOrdinal(table_count - 1);
            tot_employ.Columns["Total_Deduction"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns["Net_Pay"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns["DesgID"].SetOrdinal(tot_employ.Columns.Count - 1);
            earn_count.Text = Convert.ToString(table_count - 3);

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

            //--------------31/07/2019---------------------------------------------
            //int ixd = Convert.ToInt32(tot_employ.Columns["NET_PAY"].Ordinal);
            //for (int ind = 0; ind < sa_col.Count; ind++)
            //{
            //    ixd = ixd + 1;
            //    tot_employ.Columns[sa_col[ind].ToString()].SetOrdinal(ixd);
            //}


            int ixd = Convert.ToInt32(tot_employ.Columns["NET_PAY"].Ordinal) - 1;
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


            tsal_table = tot_employ.Copy();
            leave_details = clsDataAccess.RunQDTbl("SELECT distinct LeaveId,ShortName from tbl_Employee_Config_LeaveDetails where Session='" + cmbYear.Text + "' and Location_id = '" + Locations + "'");
            if (leave_details.Rows.Count > 0)
            {
                dgvSalary.DataSource = addition_of_TotalLeave_Column(tot_employ);
            }
            else
            {
                DataColumn dc = new DataColumn("TotalLeave", typeof(System.String));
                tot_employ.Columns.Add(dc);
                dgvSalary.DataSource = (tot_employ);

            }
            dgvSalary.Columns["TotalLeave"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvSalary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSalary.Columns["TotalLeave"].DisplayIndex = dgvSalary.Columns["Tot_Day"].DisplayIndex + 1;
            if (!total_Leave_visibility)
                dgvSalary.Columns["TotalLeave"].Visible = false;

            dgvSalary.DataSource = addition_of_WeeklyOff_Column(tot_employ);
            dgvSalary.Columns["WeeklyOff"].DisplayIndex = dgvSalary.Columns["Tot_Day"].DisplayIndex + 2;

            lblEarning.Text = Convert.ToString(table_count - 3);
            //for (int i = 0; i <= leave_details.Columns.Count - 1; i++)
            //{
            //    dgvSalary.Rows[dgvSalary.RowCount - 1].Cells[i].Style.BackColor = Color.SkyBlue;
            //}

            this.lbltot.Text = clsDataAccess.GetresultS("SELECT sum (NetPay) as Net_Pay FROM tbl_Employee_SalaryMast sm where (sm.Session='" + cmbYear.Text + "') and (sm.Month ='" + month + "') and (sm.Location_id = '" + Locations + "')");

            dgvSalary.Columns["sl"].Width = 30;
            dgvSalary.Columns["EmployeeName"].Width = 130;
            dgvSalary.Columns["ID"].Width = 70;
            dgvSalary.Columns["Salary"].Width = 70;
            dgvSalary.Columns["W_Day"].Width = 50;
            dgvSalary.Columns["O_T"].Width = 50;
            dgvSalary.Columns["Tot_Day"].Width = 60;

            dgvSalary.Columns["sl"].ReadOnly = true;
            dgvSalary.Columns["EmployeeName"].ReadOnly = true;
            dgvSalary.Columns["ID"].ReadOnly = true;
            dgvSalary.Columns["Salary"].ReadOnly = true;
            dgvSalary.Columns["W_Day"].ReadOnly = true;
            dgvSalary.Columns["O_T"].ReadOnly = true;
            dgvSalary.Columns["Tot_Day"].ReadOnly = true;
            if (woff == 0)
            {
                dgvSalary.Columns["WeeklyOff"].Visible = false;

            }
            else
            {
                dgvSalary.Columns["WeeklyOff"].Visible = true;
            }

            if (E_D == 0)
            {
                dgvSalary.Columns["E_D"].Visible = false;

            }
            else
            {
                dgvSalary.Columns["E_D"].Visible = true;
            }

            dgvSalary.Columns["sl"].Frozen = true;
            dgvSalary.Columns["EmployeeName"].Frozen = true;
            dgvSalary.Columns["ID"].Frozen = true;

            dgvSalary.Columns["DesgID"].Visible = false;

            for (int i = 0; i <= dgvSalary.Columns.Count - 1; i++)
            {
                dgvSalary.Rows[dgvSalary.RowCount - 1].Cells[i].Style.BackColor = Color.SkyBlue;
                dgvSalary.Rows[dgvSalary.Rows.Count - 1].Cells[i].Style.Font = new Font("Times New Roman", 8, FontStyle.Bold);
            }
            int dg_od_rw = 0;
            DataTable salary_Odetails = clsDataAccess.RunQDTbl("SELECT [Slno],[OCId],[OCName],[Amount],[ODName],[AcNo],[Bank],[Branch],[IFSC] FROM [tbl_Employee_Sal_OCharges] where Session='" +
        cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' order by Slno");
            if (salary_Odetails.Rows.Count > 0)
            {
                for (int Odet_ind = 0; Odet_ind < salary_Odetails.Rows.Count; Odet_ind++)
                {
                    dg_od_rw = dgvOtherCharges.Rows.Add();
                    dgvOtherCharges.Rows[dg_od_rw].Cells["dgColID"].Value = Odet_ind + 1;
                    dgvOtherCharges.Rows[dg_od_rw].Cells["dgColOCharge"].Value = salary_Odetails.Rows[Odet_ind]["OCName"].ToString();
                    dgvOtherCharges.Rows[dg_od_rw].Cells["dgColVal"].Value = salary_Odetails.Rows[Odet_ind]["Amount"].ToString();

                    dgvOtherCharges.Rows[dg_od_rw].Cells["dgColOName"].Value = salary_Odetails.Rows[Odet_ind]["ODName"].ToString();
                    dgvOtherCharges.Rows[dg_od_rw].Cells["dgColOBank"].Value = salary_Odetails.Rows[Odet_ind]["Bank"].ToString();
                    dgvOtherCharges.Rows[dg_od_rw].Cells["dgColOBranch"].Value = salary_Odetails.Rows[Odet_ind]["Branch"].ToString();
                    dgvOtherCharges.Rows[dg_od_rw].Cells["dgColOAc"].Value = salary_Odetails.Rows[Odet_ind]["AcNo"].ToString();
                    dgvOtherCharges.Rows[dg_od_rw].Cells["dgColOIfsc"].Value = salary_Odetails.Rows[Odet_ind]["IFSC"].ToString();
                }
            }

            //      DataTable salary_Odet = clsDataAccess.RunQDTbl("SELECT [ODName],[AcNo],[Bank] FROM [tbl_Employee_Sal_ODet] where Session='" + 
            //cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' order by Slno");
            //     if (salary_Odetails.Rows.Count >0){


            //                 txtAgentName.Text=salary_Odet.Rows[0]["ODName"].ToString();
            //                 txtAgentBank.Text = salary_Odet.Rows[0]["Bank"].ToString();
            //                 txtAgentAcno.Text = salary_Odet.Rows[0]["AcNo"].ToString();
            //          }
        }
        public void del_alkf()
        {
            DataTable dt_recov = clsDataAccess.RunQDTbl("SELECT slno,transid,salid,eid,ename,desgid,ramt,mon,coid,locid,type FROM tbl_recovery WHERE (mon = '" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "') AND (coid = '" + company_Id + "') AND (locid = '" + Locations + "')");
            if (dt_recov.Rows.Count > 0)
            {
                //slno, transid, salid, eid, ename, desgid, ramt, mon, coid, locid, type 
                int rw_alfk = 0;
                string sql_alk = "", eid = "";


                for (int idx = 0; idx < dt_recov.Rows.Count; idx++)
                {
                    eid = dt_recov.Rows[idx]["eid"].ToString();
                    if (dt_recov.Rows[idx]["type"].ToString().ToLower() == "advance")
                    {

                        sql_alk = "Delete from tbl_Employee_Advance where (EAEID='" + eid + "') and (EAMONTH='" + AttenDtTmPkr.Value.ToString("MMMM/ yyyy") + "') and (CoID=" + company_Id + ") and (LocID=" + Locations + ") AND (EAID = " + dt_recov.Rows[idx]["salid"].ToString().Trim() + ")";
                    }
                    else if (dt_recov.Rows[idx]["type"].ToString().ToLower() == "loan")
                    {
                        sql_alk = "update tbl_Employee_LOAN set ELDEDUCT= ELDEDUCT - " + Convert.ToDouble(dt_recov.Rows[idx]["ramt"]) + ",ELDEDUCTDT='" + dtp_copy.Value.ToString("dd/MMM/yyyy") + "' where (ELEID='" + eid + "') and (ELID='" + dt_recov.Rows[idx]["transid"].ToString().Trim() + "')";
                    }
                    else if (dt_recov.Rows[idx]["type"].ToString().ToLower() == "kit")
                    {
                        sql_alk = "update tbl_Employee_KIT set EKDEDUCT= EKDEDUCT - " + Convert.ToDouble(dt_recov.Rows[idx]["ramt"]) + ",EKDEDUCTDT='" + dtp_copy.Value.ToString("dd/MMM/yyyy") + "' where (EKEID='" + eid + "') and (EKID='" + dt_recov.Rows[idx]["transid"].ToString().Trim() + "')";
                    }
                    else if (dt_recov.Rows[idx]["type"].ToString().ToLower() == "fine")
                    {
                        sql_alk = "update tbl_Employee_KIT set EKDEDUCT= EKDEDUCT - " + Convert.ToDouble(dt_recov.Rows[idx]["ramt"]) + ",EKDEDUCTDT='" + dtp_copy.Value.ToString("dd/MMM/yyyy") + "' where (EKEID='" + eid + "') and (EKID='" + dt_recov.Rows[idx]["transid"].ToString().Trim() + "')";
                    }

                    clsDataAccess.RunQry(sql_alk);

                }

                sql_alk = "Delete from tbl_recovery where (mon = '" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "') AND (coid = '" + company_Id + "') AND (locid = '" + Locations + "')";
                clsDataAccess.RunQry(sql_alk);
            }
        }
        private void vistaButton1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Want to delete", "BRAVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
                    try
                    {
                        del_alkf();
                    }
                    catch { }
                    clsDataAccess.RunNQwithStatus("delete from tbl_Employee_SalaryDet where  Month='" + month.Trim() + "' and Session ='" + cmbYear.Text.Trim() + "'   and Location_id='" + Locations + "' ");
                    clsDataAccess.RunNQwithStatus("delete from tbl_Employee_SalaryDetails where  Month='" + month.Trim() + "' and Session ='" + cmbYear.Text.Trim() + "'   and Location_id='" + Locations + "' ");
                    clsDataAccess.RunNQwithStatus("delete from tbl_Employee_SalaryMast where Month='" + month.Trim() + "' and Session ='" + cmbYear.Text.Trim() + "'   and Location_id='" + Locations + "' ");
                    clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Sal_OCharges where (Month='" + month.Trim() + "') and (Session ='" + cmbYear.Text.Trim() + "') and (Location_id='" + Locations + "')");
                    clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Sal_ODet where (Month='" + month.Trim() + "') and (Session ='" + cmbYear.Text.Trim() + "') and (Location_id='" + Locations + "')");
                    clsDataAccess.RunNQwithStatus("DELETE FROM tbl_employers_contribution where (month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "')and (session='" + cmbYear.Text.Trim() + "') and (lid ='" + Locations + "')");


                    clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_SalaryGross where (month='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "') and (Location_id ='" + Locations + "')");
                    try
                    {
                        clsDataAccess.RunNQwithStatus("delete from tbl_Employee_SalaryDet_MultiDesignation where (Month='" + month.Trim() + "') and (Session ='" + cmbYear.Text.Trim() + "') and (Location_id='" + Locations + "')");
                    }
                    catch
                    { }
                    edpcom.InsertMidasLog(this, true, "del", "Mon:" + month.Trim() + ",Sess:" + cmbYear.Text.Trim() + ",Loc:" + Locations);
                    ERPMessageBox.ERPMessage.Show("Record Delete Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    this.Close();
                }
                catch
                {
                    ERPMessageBox.ERPMessage.Show("Record Delete Problem", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                }
            }
        }

        private void del_ALK()
        {
            DataTable dt_alk = new DataTable();
            string sql_update_alk = "", sql_alk = "", eid = "", head_v = "";

            try
            {
                //sql_alk = "select SAL_HEAD,(select SalaryHead_Short FROM tbl_Employee_DeductionSalayHead where SlNo=eas.SAL_HEAD)as HEAD,chkALK from tbl_Employee_Assign_SalStructure eas where Location_id=" + Locations + " and p_type='D' AND (chkALK > 0)";
                sql_alk = "select SAL_HEAD,(select SalaryHead_Short FROM tbl_Employee_DeductionSalayHead where SlNo=eas.SAL_HEAD)as HEAD,chkALK from tbl_Employee_Assign_SalStructure eas where sal_struct=" + salary_structure + " and p_type='D' AND (chkALK > 0)";
                dt_alk = clsDataAccess.RunQDTbl(sql_alk);
            }
            catch { }

            try
            {
                //  dt_alk = clsDataAccess.RunQDTbl("SELECT * FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and em.active=1 and sm.Month ='" + cur_month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT = sm.Emp_Id");

            }
            catch { }
            double val = 0;
            for (int tc = 0; tc < this.dgvSalary.Rows.Count - 1; tc++)
            {
                if (Convert.ToString(dgvSalary.Rows[tc].Cells["ID"].Value) != "")
                {
                    eid = dgvSalary.Rows[tc].Cells["ID"].Value.ToString();
                    val = 0;


                    for (int ind_alk = 0; ind_alk < dt_alk.Rows.Count; ind_alk++)
                    {
                        head_v = dt_alk.Rows[ind_alk]["HEAD"].ToString();


                        try
                        {
                            DataRow[] dr = tsal_table.Select("ID='" + eid.ToString() + "'");

                            if (dr.Length > 0)
                            {
                                val = Convert.ToDouble(dr[0][head_v].ToString());
                            }
                        }
                        catch
                        {
                            val = 0;
                        }

                        if (dt_alk.Rows[ind_alk]["chkALK"].ToString() == "1") //advance
                        {
                            string loan_amt = dgvSalary.Rows[tc].Cells[head_v].Value.ToString(); //clsDataAccess.GetresultS("Select EADEDUCT from tbl_Employee_Advance where (EAEID='" + eid + "') and [EAID]=(select max([EAID]) from tbl_Employee_Advance where (EAEID='" + eid + "')) and ([EAAMT]-[EADEDUCT])>0");
                            if (Information.IsNumeric(loan_amt) != true)
                            {
                                loan_amt = "0";
                            }
                            //sql_update_alk = "update tbl_Employee_Advance set EADEDUCT=(Select EADEDUCT from tbl_Employee_Advance where (EAEID='" + eid + "') AND (EADT=(SELECT MAX(EADT) FROM tbl_Employee_Advance WHERE (EAEID = '"+ eid + "'))))-" + Convert.ToDouble(loan_amt) + " where (EAEID='" + eid + "') and (EADT =(SELECT MAX(EADT) FROM tbl_Employee_Advance WHERE (EAEID='" +  eid + "')))";
                            sql_update_alk = "Delete from tbl_Employee_Advance where (EAEID='" + eid + "') and (EAMONTH='" + AttenDtTmPkr.Value.ToString("MMMM/ yyyy") + "') and (CoID=" + company_Id + ") and (LocID=" + Locations + ") AND (EADEDUCT = " + loan_amt + ")";
                            clsDataAccess.RunNQwithStatus(sql_update_alk);
                            //Command_TR(sql_update_alk);
                            //  break;
                        }
                        if (dt_alk.Rows[ind_alk]["chkALK"].ToString() == "2") //loan
                        {
                            string loan_amt = dgvSalary.Rows[tc].Cells[head_v].Value.ToString();//clsDataAccess.GetresultS("Select ELDEDUCT from tbl_Employee_LOAN where (ELEID='" + eid + "') and [ELID]=(select max([ELID]) from tbl_Employee_LOAN where (ELEID='" + eid + "')) and ([ELAMT]-[ELDEDUCT])>0");
                            if (Information.IsNumeric(loan_amt) != true)
                            {
                                loan_amt = "0";
                            }
                            sql_update_alk = "update tbl_Employee_LOAN set ELDEDUCT=("
+ "Select ELDEDUCT from tbl_Employee_LOAN WHERE (ELEID = '" + eid + "') AND (ELDT=(" +
" SELECT MAX(ELDT) FROM tbl_Employee_LOAN  WHERE (ELEID = '" + eid + "')) )) -" +
                 Convert.ToDouble(val) +
                 ",ELDEDUCTDT='" + dtp_copy.Value.ToString("dd/MMM/yyyy") + "' where (ELEID='" + eid + "') AND (ELDT =(SELECT MAX(ELDT) FROM tbl_Employee_LOAN WHERE (ELEID = '" + eid + "')))";

                            clsDataAccess.RunNQwithStatus(sql_update_alk);
                            // Command_TR(sql_update_alk);
                            //break;
                        }
                        if (dt_alk.Rows[ind_alk]["chkALK"].ToString() == "3") //kit
                        {
                            string loan_amt = dgvSalary.Rows[tc].Cells[head_v].Value.ToString(); //clsDataAccess.GetresultS("Select EKDEDUCT from tbl_Employee_KIT where (EKEID='" + eid + "') and [EKID]=(select max([EKID]) from tbl_Employee_KIT where (EKEID='" + eid + "')) and ([EKAMT]-[EKDEDUCT])>0");
                            if (Information.IsNumeric(loan_amt) != true)
                            {
                                loan_amt = "0";
                            }
                            sql_update_alk = "update tbl_Employee_KIT set EKDEDUCT=(" +
     "Select EKDEDUCT from tbl_Employee_KIT where (EKEID='" + eid + "') and EKDT=(" +
   "Select max(EKDT) from tbl_Employee_Kit where EKEID='" + eid + "') )-" + Convert.ToDouble(val) +
     ",EKDEDUCTDT='" + dtp_copy.Value.ToString("dd/MMM/yyyy") + "' where (EKEID='" + eid + "') and EKDT=(" +
   "Select max(EKDT) from tbl_Employee_Kit where EKEID='" + eid + "')  ";

                            clsDataAccess.RunNQwithStatus(sql_update_alk);
                            //Command_TR(sql_update_alk);
                            //break;
                        }

                    }
                }
            }
        }




        private void clear_All()
        {
            dgvSalary.DataSource = null;
            lbe = null;
            lbp = null;
            lbd = null;
            txte = null;
            txtd = null;
            txtp = null;
        }

        private void count_hide()
        {
            string sql = "select sal_head, p_type from tbl_Employee_Assign_SalStructure where (sal_struct=" + salary_structure + ") and (chkHide in ('1','31'))";
            DataTable dt_hide = new DataTable();
            dt_hide = clsDataAccess.RunQDTbl(sql);
            hd_col.Clear();

            for (int ind = 0; ind < dt_hide.Rows.Count; ind++)
            {

                if (dt_hide.Rows[ind]["p_type"].ToString() == "E")
                {
                    lblEarning.Text = (Convert.ToInt32(earn_count.Text) - 1).ToString();
                }

            }


        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmsalarystructure_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                if (btnSubmit.Visible == false || btnDeleteSal.Visible == false)
                {
                    btnSubmit.Visible = true;
                    btnDeleteSal.Visible = true;
                }
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                if (btnSubmit.Visible == false || btnDeleteSal.Visible == false)
                {
                    btnSubmit.Visible = true;
                    btnDeleteSal.Visible = true;
                }
            }

            if (e.KeyCode == Keys.F9)
            {
                int col_ind = dgvSalary.CurrentCell.ColumnIndex;
                int row_ind = dgvSalary.CurrentCell.RowIndex;


                if (row_ind < dgvSalary.Rows.Count - 1)
                {
                    if (dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == "adv" || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == "advance")
                    {
                        if (Convert.ToDouble(dgvSalary.Rows[row_ind].Cells[col_ind].Value) != 0)
                        {

                            dgvSalary.Rows[row_ind].Cells[col_ind].ReadOnly = false;

                        }

                    }

                    if (dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == "ln" || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == "loan")
                    {

                        if (Convert.ToDouble(dgvSalary.Rows[row_ind].Cells[col_ind].Value) != 0)
                        {

                            dgvSalary.Rows[row_ind].Cells[col_ind].ReadOnly = false;

                        }
                    }

                    if (dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == ("kit") || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == ("unif") || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == ("uniform") || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == ("dress"))
                    {

                        if (Convert.ToDouble(dgvSalary.Rows[row_ind].Cells[col_ind].Value) != 0)
                        {

                            dgvSalary.Rows[row_ind].Cells[col_ind].ReadOnly = false;

                        }
                    }


                }

            }

            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    int col_ind = dgvSalary.CurrentCell.ColumnIndex;
                    int row_ind = dgvSalary.CurrentCell.RowIndex;

                    if (row_ind < dgvSalary.Rows.Count - 1)
                    {

                        if (dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == "adv" || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == "advance")
                        {
                            EDPMessageBox.EDPMessage.Show("Do you want to remove advance amount?", "Confirm!", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_QUESTION);
                            if (EDPMessageBox.EDPMessage.ButtonResult == "edpYES")
                            {

                                dgvSalary.Rows[row_ind].Cells[col_ind].Value = string.Format("{0:F}", 0);
                                calc_grid(row_ind, col_ind);
                            }

                        }

                        if (dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == ("kit") || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == ("unif") || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == ("uniform") || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == ("dress"))
                        {
                            EDPMessageBox.EDPMessage.Show("Do you want to remove kit amount?", "Confirm!", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_QUESTION);
                            if (EDPMessageBox.EDPMessage.ButtonResult == "edpYES")
                            {

                                dgvSalary.Rows[row_ind].Cells[col_ind].Value = string.Format("{0:F}", 0);
                                calc_grid(row_ind, col_ind);
                            }
                        }

                        if (dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == "ln" || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == "loan")
                        {
                            EDPMessageBox.EDPMessage.Show("Do you want to remove loan amount?", "Confirm!", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_QUESTION);
                            if (EDPMessageBox.EDPMessage.ButtonResult == "edpYES")
                            {

                                dgvSalary.Rows[row_ind].Cells[col_ind].Value = string.Format("{0:F}", 0);
                                calc_grid(row_ind, col_ind);
                            }
                        }
                        //  }


                    }

                }
                catch { }

            }
        }

        public void calc_grid_full()
        {

            try
            {
                double ear_total = 0, deduc_total = 0;
                int cou = 0;
                int earn_cnt = 0;
                int ded_cnt = 0;
                earn_cnt = EmploySalary_Details.Columns.IndexOf("Total_Earning");
                ded_cnt = EmploySalary_Details.Columns.IndexOf("Total_Deduction");
                earn_count.Text = lblEarning.Text;
                cou = earn_cnt; //Convert.ToInt32(earn_count.Text);
                double net_tot = 0, Total_Earning = 0, Total_Deduction = 0;
                for (int irw = 0; irw < EmploySalary_Details.Rows.Count; irw++)
                {

                    for (int i = 8; i < cou; i++)
                    {

                        if (Information.IsNumeric(EmploySalary_Details.Rows[irw][i]) == true)
                        {
                            if (EmploySalary_Details.Columns[i].ColumnName == "Total_Earning")
                            {
                                EmploySalary_Details.Rows[irw][i] = string.Format("{0:F}", ear_total);
                                ear_total = 0;
                            }

                            else
                            {
                                try
                                {
                                    ear_total = ear_total + Convert.ToDouble(EmploySalary_Details.Rows[irw][i]);
                                }
                                catch
                                {


                                }
                            }
                        }
                    }
                    EmploySalary_Details.Rows[irw][cou] = string.Format("{0:F}", ear_total);
                    //cou = earn_cnt + 1; //Convert.ToInt32(earn_count.Text)-1;
                    for (int i = cou + 1; i <= ded_cnt; i++)
                    {
                        if (Information.IsNumeric(EmploySalary_Details.Rows[irw][i]) == true)
                        {
                            if (EmploySalary_Details.Columns[i].ColumnName == "Total_Deduction")
                            {
                                EmploySalary_Details.Rows[irw][i] = string.Format("{0:F}", deduc_total);
                                EmploySalary_Details.Rows[irw]["Net_Pay"] = string.Format("{0:F}", ear_total - deduc_total);
                            }
                            else
                                deduc_total = deduc_total + Convert.ToDouble(EmploySalary_Details.Rows[irw][i]);
                        }
                    }
                    ear_total = 0;
                    deduc_total = 0;
                    net_tot = 0; Total_Earning = 0;
                    Total_Deduction = 0;

                    //if (Information.IsNumeric(EmploySalary_Details.Rows[irw].Cells[ear_total].Value) == true)
                    //    ear_total = ear_total + Convert.ToDouble(EmploySalary_Details.Rows[irw].Cells[e.ColumnIndex].Value);
                    if (Information.IsNumeric(EmploySalary_Details.Rows[irw]["Net_Pay"]) == true)
                        net_tot = net_tot + Convert.ToDouble(EmploySalary_Details.Rows[irw]["Net_Pay"]);

                    if (Information.IsNumeric(EmploySalary_Details.Rows[irw]["Total_Earning"]) == true)
                        Total_Earning = Total_Earning + Convert.ToDouble(EmploySalary_Details.Rows[irw]["Total_Earning"]);

                    if (Information.IsNumeric(EmploySalary_Details.Rows[irw]["Total_Deduction"]) == true)
                        Total_Deduction = Total_Deduction + Convert.ToDouble(EmploySalary_Details.Rows[irw]["Total_Deduction"]);
                }

                //EmploySalary_Details.Rows[EmploySalary_Details.Rows.Count - 1].Cells[e.ColumnIndex].Value = string.Format("{0:F}", ear_total);
                /* EmploySalary_Details.Rows[EmploySalary_Details.Rows.Count - 1]["Net_Pay"] = string.Format("{0:F}", net_tot);
                 EmploySalary_Details.Rows[EmploySalary_Details.Rows.Count - 1]["Total_Earning"] = string.Format("{0:F}", Total_Earning);
                 EmploySalary_Details.Rows[EmploySalary_Details.Rows.Count - 1]["Total_Deduction"] = string.Format("{0:F}", Total_Deduction);
                 lbltot.Text = string.Format("{0:F}", net_tot);
                 */

            }
            catch { }
        }
        public void calc_grid(int rw, int col)
        {
            try
            {
                if (Information.IsNumeric(dgvSalary.Rows[rw].Cells[col].Value) == true)
                    if (Convert.ToDouble(dgvSalary.Rows[rw].Cells[col].Value) < 0)
                    {
                        ERPMessageBox.ERPMessage.Show("Negative Value Not Allow");
                        dgvSalary.Rows[rw].Cells[col].Value = "0.00";
                    }

                double ear_total = 0, deduc_total = 0;
                int cou = 0;
                int earn_cnt = dgvSalary.Columns["Total_Earning"].Index;
                earn_count.Text = lblEarning.Text;
                cou = earn_cnt; //Convert.ToInt32(earn_count.Text);
                for (int i = 8; i < cou; i++)
                {
                    if (Information.IsNumeric(dgvSalary.Rows[rw].Cells[i].Value) == true)
                    {
                        if (dgvSalary.Columns[i].HeaderText == "Total_Earning")
                            dgvSalary.Rows[rw].Cells[i].Value = string.Format("{0:F}", ear_total);
                        else
                        {
                            if (dgvSalary.Columns[rw].Visible == false)
                            {
                                ear_total = ear_total + 0;
                            }
                            else
                            {
                                ear_total = ear_total + Convert.ToDouble(dgvSalary.Rows[rw].Cells[i].Value);
                            }
                        }
                    }
                }
                dgvSalary.Rows[rw].Cells[cou].Value = string.Format("{0:F}", ear_total);
                cou = earn_cnt + 1; //Convert.ToInt32(earn_count.Text)-1;
                for (int i = cou; i <= dgvSalary.Columns.Count - 1; i++)
                {
                    if (Information.IsNumeric(dgvSalary.Rows[rw].Cells[i].Value) == true)
                    {
                        if (dgvSalary.Columns[i].HeaderText == "Total_Deduction")
                        {
                            dgvSalary.Rows[rw].Cells[i].Value = string.Format("{0:F}", deduc_total);
                            dgvSalary.Rows[rw].Cells["Net_Pay"].Value = string.Format("{0:F}", ear_total - deduc_total);
                        }
                        else
                            deduc_total = deduc_total + Convert.ToDouble(dgvSalary.Rows[rw].Cells[i].Value);
                    }
                }
                ear_total = 0;
                double net_tot = 0, Total_Earning = 0;
                for (int i = 0; i <= dgvSalary.Rows.Count - 2; i++)
                {
                    if (Information.IsNumeric(dgvSalary.Rows[i].Cells[col].Value) == true)
                        ear_total = ear_total + Convert.ToDouble(dgvSalary.Rows[i].Cells[col].Value);
                    if (Information.IsNumeric(dgvSalary.Rows[i].Cells["Net_Pay"].Value) == true)
                        net_tot = net_tot + Convert.ToDouble(dgvSalary.Rows[i].Cells["Net_Pay"].Value);

                    if (Information.IsNumeric(dgvSalary.Rows[i].Cells["Total_Earning"].Value) == true)
                        Total_Earning = Total_Earning + Convert.ToDouble(dgvSalary.Rows[i].Cells["Total_Earning"].Value);
                }

                dgvSalary.Rows[dgvSalary.Rows.Count - 1].Cells[col].Value = string.Format("{0:F}", ear_total);
                dgvSalary.Rows[dgvSalary.Rows.Count - 1].Cells["Net_Pay"].Value = string.Format("{0:F}", net_tot);
                dgvSalary.Rows[dgvSalary.Rows.Count - 1].Cells["Total_Earning"].Value = string.Format("{0:F}", Total_Earning);
                lbltot.Text = string.Format("{0:F}", net_tot);

            }
            catch { }
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            string sql = "";
            if (chkAllLocation.Checked == true)
            {
                sql = "select Location_Name,Location_ID as LocationID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName,EL.Cliant_ID as ClientID from tbl_Emp_Location EL where Location_ID in (" + edpcom.CurrentLocation + ") and (zid='" + cmbZone.ReturnValue.Trim() + "')";
            }
            else
            {
                sql = "select Location_Name,Location_ID as LocationID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName,EL.Cliant_ID as ClientID  from tbl_Emp_Location EL where Location_ID in (" + edpcom.CurrentLocation + ")";
            }
            DataTable dt = clsDataAccess.RunQDTbl(sql);
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
            else
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;

            }

            clr_heads();
        }
        public string get_pf_val(string pf_bs, double per)
        {
            double tot_val = 0;
            if (per == 1)
            {
                DataTable dt = clsDataAccess.RunQDTbl("select SlNo,SalaryHead_Full,SalaryHead_Short,Amount,Glcode from tbl_Employer_Contribution");
                DataView dv = new DataView(dt);
                for (int j = 0; j <= dv.Count - 1; j++)
                {
                    string _salhead = "";
                    _salhead = dv[j]["SalaryHead_Full"].ToString().Trim();
                    double _amount = 0;
                    _amount = Convert.ToDouble(pf_bs) * Convert.ToDouble(dv[j]["Amount"]) / 100;
                    tot_val = tot_val + _amount;
                }
            }
            else
            {
                tot_val = Convert.ToDouble(pf_bs) * Convert.ToDouble(per) / 100;
            }
            return Math.Round(tot_val).ToString();
        }
        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            // lbl_load_msg.Text = "Please Wait..";
            eid_adv = ""; eid_loan = ""; eid_kit = "";
            lbl_Time_from.Text = DateTime.Now.ToString("hh:mm:ss tt");
            Thread.Sleep(100);
            lbl_mod.Text = "";
            try
            {
                dgvSalary.DataSource = "";

            }
            catch { }
            try
            {
                dgvGross.Rows.Clear();
            }
            catch { }
            //dgPfEsi.Rows.Clear();
            try
            {
                dgPfEsi.Rows.Clear();
            }
            catch { }
            pnl_load.Visible = true;

            try
            {
                btnDeleteSal.Visible = true;
                btnSubmit.Visible = true;
                salary_structure = 0;
                try
                {
                    hsh_rtype.Clear();
                }
                catch { }
                try
                {
                    dgPfEsi.Rows.Clear();
                }
                catch { }
                //lbe = new Label[32];
                //lbd = new Label[32];
                //lbp = new Label[4];
                dgvOtherCharges.Visible = true;
                dgvOtherCharges.Rows.Clear();
                int day1 = 0, day2 = 0, month_no = 0, earning_count = 0;
                double Tot_Leave = 0, calculateDay = 0;

                //DataTable SalaryLocation = clsDataAccess.RunQDTbl("select Location_ID from tbl_Employee_Link_SalaryStructure where SalaryStructure_ID=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " ");
                //for (int i = 0; i <= SalaryLocation.Rows.Count - 1; i++)
                //{
                //    Locations = Locations + SalaryLocation.Rows[i]["Location_ID"];
                //    if (i != SalaryLocation.Rows.Count - 1)
                //        Locations = Locations + ",";
                //}

                // Locations = Convert.ToString(Locations);

                txtAgentName.Text = "";
                txtAgentBank.Text = "";
                txtAgentAcno.Text = "";
                groupBox4.Text = "";
                if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                    Locations = Convert.ToString(cmbLocation.ReturnValue);
                groupBox4.Text = cmbLocation.Text;
                if (Information.IsNumeric(Locations) == false)
                    Locations = "0";

                try
                {
                    if (Convert.ToInt32(clsDataAccess.GetresultS("select count(*) from tbl_Employee_Attend  where (location_id='" + Locations + "') and (month ='" + AttenDtTmPkr.Value.Month + '/' + AttenDtTmPkr.Value.Year + "') and  (Season = '" + cmbYear.Text + "')")) == 0)
                    {
                        pnl_load.Visible = false;
                        MessageBox.Show("No Attendence Found", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch { }


                try
                {
                    lbl_WO.Text = clsDataAccess.GetresultS("select woff from tbl_Employee_Attend  where (location_id='" + Locations + "') and (month ='" + AttenDtTmPkr.Value.Month + '/' + AttenDtTmPkr.Value.Year + "') and  (Season = '" + cmbYear.Text + "')");

                }
                catch { lbl_WO.Text = "0"; }


                company_Id = clsEmployee.GetCompany_ID(Convert.ToInt32(Locations));

                DataTable dtConv = clsDataAccess.RunQDTbl("Select CR.MOD,isNUll(CR.[hrs_per_wd],8)[hrs_per_wd]," +
                "isNull(CR.[hrs_per_ot],4)[hrs_per_ot],isNull(CR.[apply_hrs_wd],0)[apply_hrs_wd],isNull(CR.[apply_hrs_ot],0)[apply_hrs_ot]," +
                "isNull(CR.[apply_hrs_ed],0)[apply_hrs_ed],isNull(CR.[hrs_per_ed],4)[hrs_per_ed] from Companywiseid_Relation CR where (CR.Location_ID='" + Locations + "')");
                lbl_wd_hrs.Text = "0";
                lbl_ot_hrs.Text = "0";
                try
                {
                    lbl_Accpt_wd_hrs.Text = dtConv.Rows[0]["apply_hrs_wd"].ToString().ToUpper();
                    lbl_Accpt_ot_hrs.Text = dtConv.Rows[0]["apply_hrs_ot"].ToString().ToUpper();

                    lbl_Accpt_ed_hrs.Text = dtConv.Rows[0]["apply_hrs_ed"].ToString().ToUpper();

                    lbl_wd_hrs.Text = dtConv.Rows[0]["hrs_per_wd"].ToString().ToUpper();
                    lbl_ot_hrs.Text = dtConv.Rows[0]["hrs_per_ot"].ToString().ToUpper();
                    lbl_ed_hrs.Text = dtConv.Rows[0]["hrs_per_ed"].ToString().ToUpper();

                    if (lbl_Accpt_wd_hrs.Text == "")
                    {
                        lbl_Accpt_wd_hrs.Text = "0";
                    }

                    if (lbl_ot_hrs.Text == "")
                    {
                        lbl_ot_hrs.Text = "0";
                    }

                    if (lbl_Accpt_ot_hrs.Text == "")
                    {
                        lbl_Accpt_ot_hrs.Text = "0";
                    }
                    if (lbl_wd_hrs.Text == "")
                    {
                        lbl_wd_hrs.Text = "0";
                    }


                    if (lbl_ed_hrs.Text == "")
                    {
                        lbl_ed_hrs.Text = "0";
                    }

                    if (lbl_Accpt_ed_hrs.Text == "")
                    {
                        lbl_Accpt_ed_hrs.Text = "0";
                    }
                }
                catch { }

                try
                {
                    lblpf_limit.Text = clsDataAccess.GetresultS("select isNUll(pf_limit,0) from  Companywiseid_Relation  where (location_id='" + Locations + "') and  ( Company_ID = '" + company_Id + "')");
                    lblEsi_limit.Text = clsDataAccess.GetresultS("select isNUll(esi_limit,0) from  Companywiseid_Relation  where (location_id='" + Locations + "') and  ( Company_ID = '" + company_Id + "')");
                }
                catch { }
                try
                {
                    lbl_limit_gross.Text = clsDataAccess.GetresultS("select (case when chk_active_limit=1 then limit_gross else 0 end) from CompanyLimiter");
                }
                catch { }

                try
                {
                    lbl_payslip.Text = clsDataAccess.GetresultS("select payslip from CompanyLimiter");
                }
                catch { }

                try
                {
                    lbl_limit_gross_esi.Text = clsDataAccess.GetresultS("select (case when chk_active_limit_esi=1 then limit_gross_esi else 0 end) from CompanyLimiter");
                }
                catch { }
                //lbl_wd_hrs.Text = "0";
                //lbl_ot_hrs.Text = "0";
                //try
                //{
                //    lbl_wd_hrs.Text = clsDataAccess.GetresultS("select hrs_per_wd FROM Companywiseid_Relation where (Company_ID='" + company_Id + "') and (Location_ID='" + Locations + "')");
                //}
                //catch { lbl_wd_hrs.Text = "0"; }


                //try
                //{
                //    lbl_ot_hrs.Text = clsDataAccess.GetresultS("select hrs_per_ot FROM Companywiseid_Relation where (Company_ID='" + company_Id + "') and (Location_ID='" + Locations + "')");
                //}
                //catch { lbl_ot_hrs.Text = "0"; }

                try
                {

                    lbl_mod.Text = clsDataAccess.GetresultS("select isNUll(MOD,'') from  Companywiseid_Relation  where (location_id='" + Locations + "') and  ( Company_ID = '" + company_Id + "')");
                }
                catch { lbl_mod.Text = ""; }
                DataTable SalaryLocation = clsDataAccess.RunQDTbl("select SalaryStructure_ID from tbl_Employee_Link_SalaryStructure where Location_ID=" + Locations + " ");
                if (SalaryLocation.Rows.Count > 0)
                {
                    salary_structure = Convert.ToInt32(SalaryLocation.Rows[0]["SalaryStructure_ID"]);

                }

                txtClient.Text = clsDataAccess.GetresultS("SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=(select distinct Cliant_ID from tbl_Emp_Location where Location_ID='" + Locations + "')");
                lblClid.Text = clsDataAccess.GetresultS("select distinct Cliant_ID from tbl_Emp_Location where (Location_ID='" + Locations + "')");



                ////  ptstate = clsDataAccess.GetresultS("Select (case when LOWER(state)<>'" + vState.Trim().ToLower() + "' then state else '" + vState.Trim().ToUpper() + "' end) 'State' from (SELECT (SELECT (State_Name) FROM StateMaster where STATE_CODE= ecm.Client_State)'State' FROM  tbl_Employee_CliantMaster ecm where (client_id='" + lblClid.Text.Trim() + "'))x").Trim();

                //-- 16-7-19 > configuration for ptaxt state / location wise
                ptstate = clsDataAccess.GetresultS("Select (case when LOWER(state)<>'" + vState.Trim().ToLower() + "' then state else '" + vState.Trim().ToUpper() + "' end) 'State' from (select (case when (select ptax from CompanyLimiter)='0' then (SELECT (SELECT (State_Name) FROM StateMaster where STATE_CODE= ecm.Client_State)'State' FROM  tbl_Employee_CliantMaster ecm where (client_id='" + lblClid.Text.Trim() + "')) else (SELECT blState 'State' FROM  Companywiseid_Relation ecm where  Company_ID='" + company_Id + "' and Location_ID='" + Locations + "') end) 'state') x");


                if (ptstate.Trim() == "")
                {
                    ptstate = vState;
                }
                cur_month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

                //  DataTable chk_ALK = clsDataAccess.RunQDTbl("SELECT  sm.chk_A,sm.chk_L,chk_K FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and em.active=1 and sm.Month ='" + cur_month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT = sm.Emp_Id");

                DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT distinct (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) as EmployeeName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay,sm.status FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and em.active=1 and sm.Month ='" + cur_month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT = sm.Emp_Id");

                //if (tot_employ.Rows.Count>0)
                //{
                //    btnSubmit.Text = "Update";
                //    Retrive_Data();
                //}

                string s = "select SAL_STRUCT ,SAL_HEAD , C_BASIS  ,C_TYPE ,C_DET , pt_basis  ,PF_PER,ESI_PER,PT from tbl_Employee_Assign_SalStructure where (sal_struct=" + salary_structure + ") and (p_type='D') and (pf_per=1 or esi_per=1 or pt=1)";
                //"select (cast(SAL_STRUCT as nvarchar)+  ' | ' + cast(SAL_HEAD as nvarchar) + ' | ' + cast(C_BASIS as nvarchar) + ' | ' + cast(C_TYPE as nvarchar) + ' | ' + cast(C_DET as nvarchar) + ' | ' + cast(pt_basis as nvarchar)) as Struct ,PF_PER,ESI_PER,PT from tbl_Employee_Assign_SalStructure where (sal_struct=" + salary_structure + ") and (p_type='D') and (pf_per=1 or esi_per=1 or pt=1)";
                DataTable dt_Form = new DataTable();
                dt_Form = clsDataAccess.RunQDTbl(s);
                //"SAL_STRUCT,SAL_HEAD,C_BASIS,C_TYPE,C_DET"
                if (dt_Form.Rows.Count > 0)
                {
                    for (int ind = 0; ind < dt_Form.Rows.Count; ind++)
                    {
                        if (dt_Form.Rows[ind]["PF_PER"].ToString().Trim() == "1")
                        {
                            try
                            {
                                lbl_Pf_formula.Text = GetFormula(dt_Form.Rows[ind]["C_DET"].ToString().Trim());
                            }
                            catch { MessageBox.Show("No PF Base found", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                        else if (dt_Form.Rows[ind]["ESI_PER"].ToString().Trim() == "1")
                        {
                            try
                            {
                                lbl_esi_formula.Text = GetFormula(dt_Form.Rows[ind]["C_DET"].ToString().Trim()); //dt_Form.Rows[ind]["Struct"].ToString().Trim();
                            }
                            catch { MessageBox.Show("No ESI Base found", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                        }

                        else if (dt_Form.Rows[ind]["PT"].ToString().Trim() == "1")
                        {
                            Lbl_pf_head.Text = clsDataAccess.GetresultS("select SalaryHead_Short from tbl_Employee_DeductionSalayHead where SlNo=(" + dt_Form.Rows[ind]["SAL_HEAD"].ToString().Trim() + ")");

                            lbl_pt_formula.Text = dt_Form.Rows[ind]["pt_basis"].ToString().Trim();
                        }
                    }

                }



                if (tot_employ.Rows.Count > 0)
                {
                    btnDeleteSal.Visible = true;
                    btnPreview.Visible = true;
                    btnSubmit.Text = "Update";
                    if (tot_employ.Rows[0]["status"].ToString().Trim() == "1")
                    {
                        chkAuthorise.Checked = true;
                    }
                    else if (tot_employ.Rows[0]["status"].ToString().Trim() == "0")
                    {
                        chkAuthorise.Checked = false;
                    }
                    int next_month = 0;



                    string edate = clsDataAccess.GetresultS("select top(1) RIGHT('0' + DATENAME(DAY, Date_of_Insert), 2) + '/' + DATENAME(MONTH,Date_of_Insert)+ '/' +  DATENAME(YEAR, Date_of_Insert)as edate FROM tbl_Employee_SalaryMast where (Session='" + cmbYear.Text + "') and (Month ='" + cur_month + "') and (Location_id = '" + Locations + "')");
                    try
                    {
                        dtp_DOE.Value = Convert.ToDateTime(edate);
                    }
                    catch
                    {
                        dtp_DOE.Value = DateTime.Now.Date;
                    }



                    Retrive_Data();

                    if (AttenDtTmPkr.Value.Month == 12)
                        next_month = 1;
                    else
                        next_month = AttenDtTmPkr.Value.Month + 1;


                    string n_month = clsEmployee.GetMonthName(next_month);

                    DataTable tot_employ1 = new DataTable();
                    if (next_month == 4)
                    {
                        string nyr = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(-1);//cmbYear.Items[0].ToString();
                        tot_employ1 = clsDataAccess.RunQDTbl("SELECT (select ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
         "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) from tbl_Employee_Mast AS em where em.ID=sm.Emp_Id) AS EmployeeName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.ed as E_D, sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + nyr + "' and sm.Month ='" + n_month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT = sm.Emp_Id COLLATE DATABASE_DEFAULT");
                    }
                    else
                    {
                        tot_employ1 = clsDataAccess.RunQDTbl("SELECT (select ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) from tbl_Employee_Mast AS em where em.ID=sm.Emp_Id) AS EmployeeName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.ed as E_D, sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + n_month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT = sm.Emp_Id COLLATE DATABASE_DEFAULT");

                    }
                    if (tot_employ1.Rows.Count > 0)
                    {
                        btnSubmit.Visible = false;
                        btnDeleteSal.Visible = false;
                        MessageBox.Show("Salary for next month(s) Already Computed. You cannot Modify / delete this salary.", "Bravo Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        MessageBox.Show("Salary Already Computed. To view any changes made in structure, this salary has to be deleted and regenerated", "Bravo Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dgvSalary.Columns["ID"].SortMode = DataGridViewColumnSortMode.Automatic;
                    dgPfEsi.Columns["eid"].SortMode = DataGridViewColumnSortMode.Automatic;

                }
                else
                {
                    btnDeleteSal.Visible = false;
                    btnSubmit.Text = "Submit";
                    //SALARY STRUCTURE APPLICABLE OR NOT CODE WILL BE IN HERE
                    dtp_DOE.Value = DateTime.Now.Date;
                    /*Now we have to check if salary structure for this location is ok or not*/
                    string strSalStructStatus = clsDataAccess.GetresultS("select distinct (select ss.status from tbl_Employee_SalaryStructure ss where ss.SlNo = ass.SAL_STRUCT) as 'Status' from tbl_Employee_Assign_SalStructure ass where Location_id = " + Locations);
                    if (strSalStructStatus != "1")
                    {
                        EDPMessageBox.EDPMessage.Show("Salary structure assigned for this location is not ready for salary computation.");
                        pnl_load.Visible = false;
                        return;
                    }
                    /**/
                    chkAuthorise.Checked = false;
                    Boolean boolBulk = true;
                    //DataTable EmployeeID = clsDataAccess.RunQDTbl("select ep.Employ_ID,em.Title +' '+ em.FirstName +' '+ em.MiddleName +' '+ em.LastName from tbl_Emp_Posting ep,tbl_Employee_Mast em  where ep.Employ_ID=em.ID and ep.Posting_Month = '" + clsEmployee.GetMonthName(dateTimePicker1.Value.Month) + "' and ep.LOcation_ID in(" + Locations + ")order by ep.FromDate ");
                    DataTable EmployeeID = clsDataAccess.RunQDTbl("SELECT distinct ep.ID as Employ_ID," +
          "(select top 1((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) from tbl_Employee_Mast AS em where em.ID=ep.ID) AS EmployeeName, ep.DesgId,Wday " +
" FROM tbl_Employee_Attend AS ep WHERE (ep.Month = '" + AttenDtTmPkr.Value.Month + '/' + AttenDtTmPkr.Value.Year + "') AND (ep.LOcation_ID = " + Locations + ") AND (ep.Season = '" + cmbYear.Text + "') ORDER BY EmployeeName,ID,Wday desc");

                    if (EmployeeID.Rows.Count <= 0)
                    {
                        EmployeeID.Clear();
                        EmployeeID = clsDataAccess.RunQDTbl("SELECT distinct ep.ID as Employ_ID," +
         "(select Top 1 ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
         "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) from tbl_Employee_Mast AS em where em.ID=ep.ID) AS EmployeeName, (Select em.DesgId from tbl_Employee_Mast as em where em.ID=ep.ID) as DesgId,Wday " +
         "FROM tbl_Employee_Attendance AS ep where ep.Season='" + cmbYear.Text + "' and ep.LOcation_ID = '" + Locations + "' and ep.LeaveDate between '" + AttenDtTmPkr.Value.Year + "/" + AttenDtTmPkr.Value.Month + "/01' and '" + AttenDtTmPkr.Value.Year + "/" + AttenDtTmPkr.Value.Month + "/" + DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month) + "' ORDER BY EmployeeName,ID,Wday desc");
                        boolBulk = false;
                    }
                    //"select distinct ID as Employ_ID,FirstName+' '+MiddleName+' '+LastName as EmployeeName,DesgId from tbl_Employee_Mast where Location_id in (" + Locations + ") and active=1 union select ep.Employ_ID,em.FirstName +' '+ em.MiddleName +' '+ em.LastName as EmployeeName,em.DesgId from tbl_Emp_Posting ep,tbl_Employee_Mast em  where ep.Employ_ID=em.ID and em.active=1 and ep.Posting_Month = '" + clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month) + "' and ep.LOcation_ID in(" + Locations + ") order by  EmployeeName");
                    if (EmployeeID.Rows.Count > 0)
                    {
                        EmpDet = EmployeeID.Copy();
                        if (boolBulk)
                        {
                            string strMOD = "select distinct MOD FROM tbl_Employee_Attend AS ep WHERE (ep.Month = '" + AttenDtTmPkr.Value.Month + '/' + AttenDtTmPkr.Value.Year + "') AND (ep.LOcation_ID = " + Locations + ") AND (ep.Season = '" + cmbYear.Text + "')";
                            DataTable dtMOD = clsDataAccess.RunQDTbl(strMOD);
                            txtcalculated_days.Text = Convert.ToInt32(Convert.ToDouble(dtMOD.Rows[0][0].ToString().Trim())).ToString();
                        }
                        else
                        {
                            //have to discuss this part...
                        }
                    }
                    arr.Clear();
                    if (AttenDtTmPkr.Value.Month.ToString() != "" && cmbLocation.Text != "")
                    {
                        //string eid = "";
                        dgvOtherCharges.Rows.Clear();
                        EmploySalary_Details.Rows.Clear();
                        EmploySalary_Details.Columns.Clear();
                        dgvGross.Columns.Clear();

                        EmploySalary_Details.Columns.Add("Sl", typeof(string));
                        EmploySalary_Details.Columns.Add("EmployeeName", typeof(string));
                        EmploySalary_Details.Columns.Add("ID", typeof(string));
                        //EmploySalary_Details.Columns.Add("DesgID", typeof(string));
                        EmploySalary_Details.Columns.Add("Salary", typeof(string));
                        EmploySalary_Details.Columns.Add("W_Day", typeof(string));
                        EmploySalary_Details.Columns.Add("O_T", typeof(string));
                        EmploySalary_Details.Columns.Add("E_D", typeof(string));
                        EmploySalary_Details.Columns.Add("Tot_Day", typeof(string));


                        this.dgvGross.Columns.Add("Sl", "SL");
                        dgvGross.Columns.Add("EmployeeName", "Employee Name");
                        dgvGross.Columns.Add("eid", "EID");
                        dgvGross.Columns.Add("did", "Dsgid");

                        try
                        {
                            dgvRecoveries.Columns.Clear();

                            dgvRecoveries.Columns.Add("tid", "trans id");
                            dgvRecoveries.Columns.Add("eid", "Emp code");
                            dgvRecoveries.Columns.Add("desgID", "desg id");
                            dgvRecoveries.Columns.Add("ename", "Name");
                            dgvRecoveries.Columns.Add("desg", "Designation");
                            dgvRecoveries.Columns.Add("amt", "Recover");
                            dgvRecoveries.Columns.Add("type", "Recovery");

                            dgvRecoveries.Columns["tid"].Visible = false;
                            dgvRecoveries.Columns["desgid"].Visible = false;

                        }
                        catch { }

                        //EmploySalary_Details.Columns.Add("Weekly_Off", typeof(string));
                        arr.Add(0);
                        arr.Add(0);
                        arr.Add(0);
                        arr.Add(0);
                        arr.Add(0);
                        arr.Add(0);
                        arr.Add(0);
                        arr.Add(0);
                        try
                        {
                            get_data();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        EmploySalary_Details.Columns.Add("Total_Earning", typeof(string));
                        arr.Add(0);
                        earning_count = EmploySalary_Details.Columns.Count;
                        earn_count.Text = (earning_count - 1).ToString();
                        count_hide();
                        lblEarning.Text = Convert.ToString(earning_count - 1);
                        try
                        {
                            get_data1();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        int deduction_count = EmploySalary_Details.Columns.Count;
                        ded_count.Text = deduction_count.ToString();
                        EmploySalary_Details.Columns.Add("Total_Deduction", typeof(string));
                        EmploySalary_Details.Columns.Add("Net_Pay", typeof(string));

                        //EmploySalary_Details.Columns.Add("Woff", typeof(string));
                        arr.Add(0);
                        arr.Add(0);
                        //Get_mnth_detl(); 

                        //EmploySalary_Details.Columns.Add("base_pf", typeof(string));
                        //EmploySalary_Details.Columns.Add("base_esi", typeof(string));
                    }
                    cntEmp_tot = EmployeeID.Rows.Count;
                    double atten = 0, proxy = 0, Tot_att = 0, TotED = 0;
                    bak_earn = 0; bak_ded = 0;
                    for (int j = 0; j <= EmployeeID.Rows.Count - 1; j++)
                    {
                        cntEmp = j + 1;
                        //try
                        //{
                        //    backgroundWorker1.RunWorkerAsync(2000);
                        //}
                        //catch
                        //{

                        //}
                        double Tot_Proxy = 0, Tot_Ed = 0;
                        calculateDay = 0; Tot_Leave = 0; deg_id = 0;
                        emply_id = Convert.ToString(EmployeeID.Rows[j]["Employ_ID"]);
                        if (emply_id == "DMF0003" || emply_id == "DMF0005" || emply_id == "11670")
                        {
                            //  MessageBox.Show("");
                        }
                        deg_id = Convert.ToInt32(EmployeeID.Rows[j]["DesgId"]);
                        DataTable AllocateEmploy = clsDataAccess.RunQDTbl("select FromDate,ToDate,Posting_Month,LOcation_ID,DesgId from tbl_Emp_Posting where Posting_Month = '" + clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month) + "'and Employ_ID='" + emply_id + "' and LOcation_ID='" + Locations + "'  order by FromDate ");

                        DataView dv = new DataView(SalaryLocation);
                        int Cur_Month = AttenDtTmPkr.Value.Month;
                        int Cur_year = AttenDtTmPkr.Value.Year;
                        int Month_Day = Day_count(Cur_Month);
                        DataTable leave_taken = clsDataAccess.RunQDTbl("select count(FstLeave) from tbl_Employee_Attendance where ID='" + emply_id + "' and LeaveDate between '" + Cur_Month + "/01/" + Cur_year + "' and '" + Cur_Month + "/" + Month_Day + "/" + Cur_year + "' and LOcation_ID in (" + Locations + ") and FstLeave>0");
                        if (leave_taken.Rows.Count > 0)
                        {
                            if (Information.IsNumeric(leave_taken.Rows[0][0]) == true)
                                Tot_Leave = Convert.ToInt32(leave_taken.Rows[0][0]);
                        }

                        leave_taken = clsDataAccess.RunQDTbl("select count(SndLeave) from tbl_Employee_Attendance where ID='" + emply_id + "' and LeaveDate between '" + Cur_Month + "/01/" + Cur_year + "' and '" + Cur_Month + "/" + Month_Day + "/" + Cur_year + "' and LOcation_ID in (" + Locations + ") and SndLeave>0");
                        if (leave_taken.Rows.Count > 0)
                        {
                            if (Information.IsNumeric(leave_taken.Rows[0][0]) == true)
                                Tot_Leave = Tot_Leave + Convert.ToInt32(leave_taken.Rows[0][0]);
                        }
                        if (Tot_Leave > 0)
                            Tot_Leave = Tot_Leave / 2;

                        //leave_taken = clsDataAccess.RunQDTbl("select count(FstProxy) from tbl_Employee_Attendance where ID='" + emply_id + "' and LeaveDate between '" + Cur_Month + "/01/" + Cur_year + "' and '" + Cur_Month + "/" + Month_Day + "/" + Cur_year + "' and LOcation_ID in (" + Locations + ") and FstProxy>0");
                        //if (leave_taken.Rows.Count > 0)
                        //{
                        //    if (Information.IsNumeric(leave_taken.Rows[0][0]) == true)
                        //        Tot_Proxy = Tot_Proxy + Convert.ToInt32(leave_taken.Rows[0][0]);
                        //}
                        //leave_taken = clsDataAccess.RunQDTbl("select count(SndProxy) from tbl_Employee_Attendance where ID='" + emply_id + "' and LeaveDate between '" + Cur_Month + "/01/" + Cur_year + "' and '" + Cur_Month + "/" + Month_Day + "/" + Cur_year + "' and LOcation_ID in (" + Locations + ") and SndProxy>0");
                        //if (leave_taken.Rows.Count > 0)
                        //{
                        //    if (Information.IsNumeric(leave_taken.Rows[0][0]) == true)
                        //        Tot_Proxy = Tot_Proxy + Convert.ToInt32(leave_taken.Rows[0][0]);
                        //}
                        //if (Tot_Proxy > 0)
                        //    Tot_Proxy = Tot_Proxy / 2;


                        string Day_Proxy = clsDataAccess.GetresultS("select Proxy_Day from tbl_Employee_Proxy_Attendance where Employee_ID ='" + emply_id + "' and Month ='" + clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month) + "' and  Session = '" + cmbYear.Text + "' and Location_ID in (" + Locations + ")    ");
                        if (Day_Proxy == null)
                            Tot_Proxy = 0;
                        else
                            Tot_Proxy = Convert.ToDouble(Day_Proxy);



                        string Employ_Location = clsDataAccess.GetresultS("select Location_id from tbl_Employee_Mast where ID ='" + emply_id + "'   ");
                        month_no = AttenDtTmPkr.Value.Month;

                        if (Employ_Location == Locations)
                        {
                            int day_absent = 0;
                            calculateDay = 0;
                            for (int i = 0; i <= AllocateEmploy.Rows.Count - 1; i++)
                            {

                                int co = i + 1;
                                int cou = AllocateEmploy.Rows.Count;
                                if (co < cou)
                                    //day2 = Convert.ToDateTime(AllocateEmploy.Rows[i + 1]["ToDate"]).Day;
                                    day2 = Convert.ToDateTime(AllocateEmploy.Rows[i]["ToDate"]).Day;
                                else
                                    if (Information.IsNumeric(txtcalculated_days.Text) == false)
                                        txtcalculated_days.Text = "0";

                                day2 = Convert.ToDateTime(AllocateEmploy.Rows[i]["ToDate"]).Day + 1;

                                day1 = Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day;


                                Employ_Location = Convert.ToString(AllocateEmploy.Rows[i]["LOcation_ID"]);
                                if (Employ_Location == Locations)
                                {
                                    //calculateDay = calculateDay + (day2 - day1);
                                    //if (i > 0)
                                    //    calculateDay = calculateDay + Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day - Convert.ToDateTime(AllocateEmploy.Rows[i ]["ToDate"]).Day;
                                    //else
                                    //    calculateDay = calculateDay + Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day - Convert.ToDateTime(AllocateEmploy.Rows[i]["ToDate"]).Day;
                                    calculateDay = calculateDay + (day2 - day1);


                                }
                                else
                                    if (i == 0)
                                    {
                                        //day_absent = Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day - 1;
                                    }
                                    else
                                        calculateDay = calculateDay + Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day - Convert.ToDateTime(AllocateEmploy.Rows[i]["ToDate"]).Day;

                            }


                            if (Information.IsNumeric(txtcalculated_days.Text) == false)
                                txtcalculated_days.Text = "0";
                            if (AllocateEmploy.Rows.Count == 0)
                            {
                                calculateDay = Convert.ToDouble(txtcalculated_days.Text) - Convert.ToDouble(calculateDay);
                            }



                        }

                        else
                        {
                            for (int i = 0; i <= AllocateEmploy.Rows.Count - 1; i++)
                            {
                                if (Locations == Convert.ToString(AllocateEmploy.Rows[i]["LOcation_ID"]).Trim())
                                {
                                    int co = i + 1;
                                    int cou = AllocateEmploy.Rows.Count;
                                    if (co < cou)
                                        //day2 = Convert.ToDateTime(AllocateEmploy.Rows[i + 1]["ToDate"]).Day;
                                        day2 = Convert.ToDateTime(AllocateEmploy.Rows[i]["ToDate"]).Day;
                                    else
                                        day2 = Day_count(month_no) + 1;


                                    day2 = Convert.ToDateTime(AllocateEmploy.Rows[i]["ToDate"]).Day + 1;

                                    day1 = Convert.ToDateTime(AllocateEmploy.Rows[i]["FromDate"]).Day;
                                    //calculateDay = calculateDay + (day2 - day1);
                                    calculateDay = Convert.ToInt32(txtcalculated_days.Text) - calculateDay;
                                }
                            }
                        }


                        ////////Leave Calculation ////

                        //080116
                        ////int Month_DayATT = Day_count(Cur_Month - 1);
                        ////double calculate_leave = 0;
                        ////DataTable Leave_config = clsDataAccess.RunQDTbl("select LeaveId,TotalLeaves from tbl_Employee_Config_LeaveDetails where Session = '" + cmbYear.Text + "' and Location_ID= '" + Locations + "' ");
                        ////DataTable Total_Leave_Taken1 = clsDataAccess.RunQDTbl("select Fstleave,SndLeave  from tbl_Employee_Attendance where ID ='" + emply_id + "' and Season = '" + cmbYear.Text + "'and LeaveDate > '" + (Cur_Month - 1) + "/" + Month_DayATT + "/" + Cur_year + "' and LeaveDate <= '" + Cur_Month + "/" + Month_Day + "/" + Cur_year + "'");
                        ////if (Total_Leave_Taken1.Rows.Count > 0)
                        ////{
                        ////    Tot_Leave = 0;
                        ////    for (int i = 0; i <= Leave_config.Rows.Count - 1; i++)
                        ////    {

                        ////        double cou1 = 0;
                        ////        DataView dv2 = new DataView(Total_Leave_Taken1);
                        ////        dv2.RowFilter = "Fstleave = " + Leave_config.Rows[i]["LeaveId"] + " ";
                        ////        cou1 = dv2.Count;
                        ////        dv2.RowFilter = "SndLeave = " + Leave_config.Rows[i]["LeaveId"] + "";
                        ////        cou1 = cou1 + dv2.Count;
                        ////        cou1 = cou1 / 2;

                        ////        double tot_lev = Convert.ToDouble(Leave_config.Rows[i]["TotalLeaves"]);
                        ////        cou1 = tot_lev - cou1;

                        ////        if (cou1 < 0)
                        ////        {
                        ////            calculate_leave = calculate_leave + Math.Abs(cou1);
                        ////            Tot_Leave = calculate_leave;
                        ////        }

                        ////    }
                        ////}
                        //080116

                        //080116
                        //Tot_Leave = 0;
                        string cur_month334 = AttenDtTmPkr.Value.AddMonths(-1).Month.ToString();
                        //string cur_month33 = clsEmployee.GetMonthName(dateTimePicker1.Value.Month );
                        string cur_mn = clsEmployee.GetMonthName(AttenDtTmPkr.Value.AddMonths(-1).Month);
                        int cur_yr = Convert.ToInt32(AttenDtTmPkr.Value.AddMonths(-1).Year);
                        int Month_DayATT = (clsEmployee.GetTotalDaysByMonth(cur_mn, cur_yr)); //Day_count(Convert.ToInt32(cur_month334));
                        //0801/15
                        double calculate_leave = 0;
                        DataTable Leave_config = clsDataAccess.RunQDTbl("select LeaveId,TotalLeaves from tbl_Employee_Config_LeaveDetails where Session = '" + cmbYear.Text + "' and Location_ID= '" + Locations + "' ");
                        DataTable Total_Leave_Taken = clsDataAccess.RunQDTbl("select Fstleave,SndLeave  from tbl_Employee_Attendance where ID ='" + emply_id + "' and Season = '" + cmbYear.Text + "' and Location_ID= '" + Locations + "' and LeaveDate <= '" + cur_month334 + "/" + Month_DayATT + "/" + Cur_year + "' "); //and Fstleave =" + Leave_config.Rows[i]["LeaveId"] + " 

                        DataTable dt = new DataTable();
                        dt.Clear();
                        dt.Columns.Add("LeaveId");
                        dt.Columns.Add("TotalLeaves");

                        if (Total_Leave_Taken.Rows.Count > 0)
                        {
                            for (int i = 0; i <= Leave_config.Rows.Count - 1; i++)
                            {
                                double cou = 0;
                                DataView dv1 = new DataView(Total_Leave_Taken);
                                dv1.RowFilter = "Fstleave = " + Leave_config.Rows[i]["LeaveId"] + " ";
                                cou = dv1.Count;
                                dv1.RowFilter = "SndLeave = " + Leave_config.Rows[i]["LeaveId"] + "";
                                cou = cou + dv1.Count;
                                cou = cou / 2;

                                double tot_lev = Convert.ToDouble(Leave_config.Rows[i]["TotalLeaves"]);
                                double cou1 = 0;
                                cou1 = tot_lev - cou;
                                double tot_lev1 = 0;
                                if (cou1 <= 0)
                                {
                                    DataRow _balleaveList = dt.NewRow();
                                    _balleaveList["LeaveId"] = Leave_config.Rows[i]["LeaveId"];
                                    _balleaveList["TotalLeaves"] = tot_lev1;
                                    dt.Rows.Add(_balleaveList);
                                }
                                else
                                {
                                    tot_lev1 = cou1;
                                    DataRow _balleaveList = dt.NewRow();
                                    _balleaveList["LeaveId"] = Leave_config.Rows[i]["LeaveId"];
                                    _balleaveList["TotalLeaves"] = Math.Abs(tot_lev1);
                                    dt.Rows.Add(_balleaveList);
                                }
                            }
                        }
                        else
                        {
                            dt = Leave_config.Copy();
                        }

                        dt.AcceptChanges();
                        int back_year = 0;
                        if (cur_month334 == "12")
                            back_year = Cur_year - 1;
                        else
                            back_year = Cur_year;
                        int count_attn = Convert.ToInt32(clsDataAccess.GetresultS("select count(*) from [tbl_Employee_Attend] where Month ='" + this.AttenDtTmPkr.Value.Month + "/" + this.AttenDtTmPkr.Value.Year + "' and  Season = '" + cmbYear.Text + "' and Location_ID ='" + Locations + "'"));
                        if (count_attn == 0)
                        {
                            DataTable Total_Leave_Taken1 = clsDataAccess.RunQDTbl("select Fstleave,SndLeave  from tbl_Employee_Attendance where ID ='" + emply_id + "' and Season = '" + cmbYear.Text + "' and Location_ID= '" + Locations + "' and LeaveDate > '" + cur_month334 + "/" + Month_DayATT + "/" + back_year + "' and LeaveDate <= '" + Cur_Month + "/" + Month_Day + "/" + Cur_year + "'");
                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                double cou2 = 0;
                                DataView dv1 = new DataView(Total_Leave_Taken1);
                                dv1.RowFilter = "Fstleave = " + dt.Rows[i]["LeaveId"] + " ";
                                cou2 = dv1.Count;
                                dv1.RowFilter = "SndLeave = " + dt.Rows[i]["LeaveId"] + "";
                                cou2 = cou2 + dv1.Count;
                                cou2 = cou2 / 2;

                                double tot_lev = Convert.ToDouble(dt.Rows[i]["TotalLeaves"]);
                                cou2 = tot_lev - cou2;

                                if (cou2 <= 0)
                                {
                                    Tot_Leave = Tot_Leave + Math.Abs(cou2);
                                }
                            }
                        }
                        else
                        {

                            //DataTable data_attn = clsDataAccess.RunQDTbl("select * from [tbl_Employee_Attend] where ID='" + emply_id + "' and Month ='" + this.AttenDtTmPkr.Value.Month + "/" + this.AttenDtTmPkr.Value.Year + "' and  Season = '" + cmbYear.Text + "' and Location_ID ='" + Locations + "'");
                            DataTable data_attn = clsDataAccess.RunQDTbl("select * from [tbl_Employee_Attend] where ID='" + emply_id + "' and Month ='" + this.AttenDtTmPkr.Value.Month + "/" + this.AttenDtTmPkr.Value.Year + "' and  Season = '" + cmbYear.Text + "' and Location_ID ='" + Locations + "' and Desgid = '" + deg_id + "'");

                            if (data_attn.Rows.Count > 1)
                            {

                                DataTable dtAttn = data_attn.Copy();

                                DataRow dr = dtAttn.Rows[dtAttn.Rows.Count - 1];
                                //               Wday, Absent, Proxy, Season, Month, LOcation_ID, Company_id, Desgid, status, edate, sfid, sno, days_wd, days_ot, apply_hrs_wd, apply_hrs_ot, 
                                //lv_earn, lv_adj, lv_pbal                       

                                for (int i = 1; i < data_attn.Rows.Count; i++)
                                {
                                    data_attn.Rows.RemoveAt(i);
                                }
                                double cWday = 0, cProxy = 0, cdays_wd = 0, cdays_ot = 0, capply_hrs_wd = 0, capply_hrs_ot = 0, clv_earn = 0, clv_adj = 0, cEd = 0; ;
                                for (int ind = 0; ind < dtAttn.Rows.Count; ind++)
                                {
                                    cWday = cWday + Convert.ToDouble(dtAttn.Rows[ind]["Wday"]);
                                    cProxy = cProxy + Convert.ToDouble(dtAttn.Rows[ind]["Proxy"]);
                                    cEd = cEd + Convert.ToDouble(dtAttn.Rows[ind]["ed"]);
                                    cdays_wd = cdays_wd + Convert.ToDouble(dtAttn.Rows[ind]["days_wd"]);
                                    cdays_ot = cdays_ot + Convert.ToDouble(dtAttn.Rows[ind]["days_ot"]);
                                    capply_hrs_wd = capply_hrs_wd + Convert.ToDouble(dtAttn.Rows[ind]["apply_hrs_wd"]);
                                    capply_hrs_ot = capply_hrs_ot + Convert.ToDouble(dtAttn.Rows[ind]["apply_hrs_ot"]);
                                    clv_earn = clv_earn + Convert.ToDouble(dtAttn.Rows[ind]["lv_earn"]);
                                    clv_adj = clv_adj + Convert.ToDouble(dtAttn.Rows[ind]["lv_adj"]);

                                }

                                data_attn.Rows[0]["Wday"] = cWday;
                                data_attn.Rows[0]["Proxy"] = cProxy;
                                data_attn.Rows[0]["days_wd"] = cdays_wd;
                                data_attn.Rows[0]["days_ot"] = cdays_ot;
                                data_attn.Rows[0]["apply_hrs_wd"] = capply_hrs_wd;
                                data_attn.Rows[0]["apply_hrs_ot"] = capply_hrs_ot;
                                data_attn.Rows[0]["lv_earn"] = clv_earn;
                                data_attn.Rows[0]["lv_adj"] = clv_adj;

                            }
                            dt_atn = data_attn.Copy();

                            try
                            {
                                Tot_Leave = 0;//Convert.ToDouble(data_attn.Rows[0]["Absent"]);
                            }
                            catch
                            {
                                Tot_Leave = 0;
                            }
                            try
                            {
                                calculateDay = Convert.ToDouble(data_attn.Rows[0]["days_wd"]);
                            }
                            catch
                            {
                                calculateDay = 0;
                            }

                            try
                            {
                                Tot_Proxy = Convert.ToDouble(data_attn.Rows[0]["days_ot"]);
                            }
                            catch
                            {
                                Tot_Proxy = 0;
                            }

                            try
                            {
                                Tot_Ed = Convert.ToDouble(data_attn.Rows[0]["days_ed"]);
                            }
                            catch
                            {
                                Tot_Ed = 0;
                            }
                        }




                        calculateDay = calculateDay - Tot_Leave;
                        txtattendence.Text = Convert.ToString(calculateDay + Tot_Proxy);

                        atten = atten + calculateDay;
                        proxy = proxy + Tot_Proxy;
                        Tot_att = Tot_att + (calculateDay + Tot_Proxy);
                        TotED = TotED + Tot_Ed;
                        //sal_struct=" + get_SalStructID(cmbsalstruc.Text.Trim()) + "

                        if (AttenDtTmPkr.Value.Month.ToString() != "" && Locations != "")
                        {
                            int count = EmploySalary_Details.Rows.Count;
                            EmploySalary_Details.Rows.Add();
                            EmploySalary_Details.Rows[j]["Sl"] = j + 1;
                            EmploySalary_Details.Rows[j]["EmployeeName"] = EmployeeID.Rows[j][1];
                            EmploySalary_Details.Rows[j]["ID"] = EmployeeID.Rows[j]["Employ_ID"];
                            //EmploySalary_Details.Rows[j]["DesgID"] = EmployeeID.Rows[j]["DesgId"];
                            EmploySalary_Details.Rows[j]["Salary"] = EmployeeID.Rows[j]["Employ_ID"];
                            EmploySalary_Details.Rows[j]["W_Day"] = string.Format("{0:F}", calculateDay);
                            EmploySalary_Details.Rows[j]["O_T"] = string.Format("{0:F}", Tot_Proxy);
                            EmploySalary_Details.Rows[j]["E_D"] = string.Format("{0:F}", Tot_Ed);
                            EmploySalary_Details.Rows[j]["Tot_Day"] = string.Format("{0:F}", (calculateDay + Tot_Proxy + Tot_Ed));

                            int cnt2 = dgvGross.Rows.Add();

                            dgvGross.Rows[cnt2].Cells["sl"].Value = cnt2 + 1;
                            dgvGross.Rows[cnt2].Cells["EmployeeName"].Value = EmployeeID.Rows[j][1];
                            dgvGross.Rows[cnt2].Cells["eid"].Value = EmployeeID.Rows[j]["Employ_ID"];
                            dgvGross.Rows[cnt2].Cells["did"].Value = EmployeeID.Rows[j]["DesgId"];

                            //EmploySalary_Details.Rows[j]["base_pf"] =0;
                            //      EmploySalary_Details.Rows[j]["base_esi"] =0;


                            string eid = "";
                            if (j == 0)
                            {
                                EmploySalary_Details.Columns.Add("DesgID", typeof(string));
                            }

                            EmploySalary_Details.Rows[j]["DesgID"] = EmployeeID.Rows[j]["DesgId"];


                            try
                            {
                                gross = 0;
                                emp_earning();

                                emp_deduction(earning_count);
                                emp_earning_back();
                                emp_deduction_back();
                                if (lblPayslip.Text.Trim() != "5")
                                {
                                     
                                    EmploySalary_Details.Rows[j]["Salary"] = (gross).ToString("0.00");
                                }
                                else
                                {
                                    EmploySalary_Details.Rows[j]["Salary"] = EmploySalary_Details.Rows[j]["Total_Earning"].ToString();
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Check formula of : " + EmployeeID.Rows[j][1], "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            //Get_mnth_detl();
                            //if (emp_id.ContainsKey(cmbempname1111.Text.Trim()))
                            //    eid = emp_id[cmbempname1111.Text.Trim()].ToString();

                            eid = "0";
                            if (hsh_All_Mnth.ContainsKey(cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()))
                                view_sal(hsh_All_Mnth[cmbYear.Text.Trim() + "/" + cmbMonth.Text.Trim() + "/" + eid.ToString()].ToString(), "Y");
                            else
                            {
                                if (hsh_lst_mnth.ContainsKey(cmbYear.Text.Trim() + "/" + eid.ToString()))
                                    view_sal(hsh_lst_mnth[cmbYear.Text.Trim() + "/" + eid.ToString()].ToString(), "N");
                            }
                        }
                    }
                    hide_col();

                    if (bak_earn == 1 || bak_ded == 1)
                    {
                        int ixd = Convert.ToInt32(EmploySalary_Details.Columns["NET_PAY"].Ordinal);
                        for (int ind = 0; ind < hd_col.Count; ind++)
                        {
                            //ixd = ixd + 1;
                            EmploySalary_Details.Columns[hd_col[ind].ToString()].SetOrdinal(ixd);

                        }
                        // int cind = dgvSalary.Columns["Total_Earning"].Index;//EmploySalary_Details.Columns.IndexOf("Total_Earning");
                        calc_grid_full();
                    }
                    for (int i = 0; i <= EmploySalary_Details.Rows.Count - 1; i++)
                    {
                        if ((EmploySalary_Details.Rows[i]["Total_Deduction"].ToString().Trim() == "0.00") || (EmploySalary_Details.Rows[i]["Total_Deduction"].ToString().Trim() == ""))
                        {
                            EmploySalary_Details.Rows[i]["Total_Deduction"] = string.Format("{0:F}", 0.00);
                            EmploySalary_Details.Rows[i]["NET_PAY"] = string.Format("{0:F}", Convert.ToDouble(EmploySalary_Details.Rows[i]["Total_Earning"]) - Convert.ToDouble(EmploySalary_Details.Rows[i]["Total_Deduction"]));
                        }
                        else
                        {
                            back_earning(i);
                        }
                    }


                    int dt_count = EmploySalary_Details.Rows.Count;
                    EmploySalary_Details.Rows.Add();

                    //dataGridView1.Rows[dataGridView1.Rows.Count-1].RowsDefaultCellStyle = Color.Red;
                    //next line i <= EmploySalary_Details.Columns.Count - 1 to i <= EmploySalary_Details.Columns.Count - 2  02112017
                    for (int i = 7; i <= EmploySalary_Details.Columns.Count - 2; i++)
                    {
                        if (i == 7)
                        {
                            EmploySalary_Details.Rows[dt_count][1] = "                Total :";
                            EmploySalary_Details.Rows[dt_count]["W_Day"] = string.Format("{0:F}", atten);
                            EmploySalary_Details.Rows[dt_count]["O_T"] = string.Format("{0:F}", proxy);
                            EmploySalary_Details.Rows[dt_count]["Tot_Day"] = string.Format("{0:F}", Tot_att);
                            EmploySalary_Details.Rows[dt_count]["E_D"] = string.Format("{0:F}", TotED);

                        }
                        EmploySalary_Details.Rows[dt_count][i] = string.Format("{0:F}", arr[i]);
                    }

                    lbltot.Text = EmploySalary_Details.Rows[dt_count]["NET_PAY"].ToString();


                    //--------------31/07/2019---------------------------------------------

                    if (bak_earn == 0 && bak_ded == 0)
                    {
                        int ixd = Convert.ToInt32(EmploySalary_Details.Columns["NET_PAY"].Ordinal);
                        for (int ind = 0; ind < sa_col.Count; ind++)
                        {
                            //ixd = ixd + 1;
                            EmploySalary_Details.Columns[sa_col[ind].ToString()].SetOrdinal(ixd);

                        }
                    }


                    //---------------------------------------------------------------------
                    //DataTable dt34;
                    //DataTable dt33 = clsDataAccess.RunQDTbl("select SlNo,SalaryHead_Full,SalaryHead_Short,Amount,Glcode from tbl_Employer_Contribution");
                    //for (int i = 0; i <= dt33.Rows.Count - 1; i++)
                    //{

                    //    dt34.Columns.Add("EmpId");
                    //    dt34.Columns.Add("EmpId");
                    //    dt34.Columns.Add("EmpId");
                    //}
                    //s = "insert into tbl_Employee_SalaryDet(EmpId,SalId,TableName,Amount,Month,Session,Location_id,Company_id) values('" + eid + "'," + get_sal_head_ID(ll.Text.Trim()) + ",'tbl_Employee_ErnSalaryHead'," + Convert.ToDouble(dataGridView1.Rows[dgv_count].Cells[ll.Text.Trim()].Value) + ",'" + mon.Trim() + "','" + cmbYear.Text.Trim() + "','" + Locations + "','" + company_Id + "')";
                    //s = "select SalaryHead_Short,slno from tbl_Employee_ErnSalaryHead";
                    //dt1 = clsDataAccess.RunQDTbl(s);

                    /*-----------------------------------Coded by Dwipraj-----------------------------------------------------------------------------------------------*/
                    #region CodedByDwipraj

                    dgvSalary.DataSource = addition_of_TotalLeave_Column(EmploySalary_Details);
                    dgvSalary.Columns["TotalLeave"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvSalary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvSalary.Columns["TotalLeave"].DisplayIndex = dgvSalary.Columns["Tot_Day"].DisplayIndex + 1;
                    if (!total_Leave_visibility)
                        dgvSalary.Columns["TotalLeave"].Visible = false;

                    dgvSalary.DataSource = addition_of_WeeklyOff_Column(EmploySalary_Details);
                    dgvSalary.Columns["WeeklyOff"].DisplayIndex = dgvSalary.Columns["Tot_Day"].DisplayIndex + 2;
                    #endregion
                    /*--------------------------------------------------------------End-------------------------------------------------------------------------------------*/

                    for (int ind = 0; ind < hd_col.Count; ind++)
                    {
                        this.dgvSalary.Columns.Remove(hd_col[ind].ToString());
                    }


                    ////for (int i = 0; i <= EmploySalary_Details.Columns.Count - 1; i++)
                    ////{


                    ////    if (i == 0)
                    ////    {
                    ////        dgvSalary.Columns["sl"].Width = 30;
                    ////        dgvSalary.Columns["EmployeeName"].Width = 130;
                    ////        dgvSalary.Columns["ID"].Width = 70;
                    ////        dgvSalary.Columns["Salary"].Width = 70;
                    ////        dgvSalary.Columns["W_Day"].Width = 50;
                    ////        dgvSalary.Columns["O_T"].Width = 50;
                    ////        dgvSalary.Columns["Tot_Day"].Width = 60;

                    ////        dgvSalary.Columns["sl"].ReadOnly = true;
                    ////        dgvSalary.Columns["EmployeeName"].ReadOnly = true;
                    ////        dgvSalary.Columns["ID"].ReadOnly = true;
                    ////        dgvSalary.Columns["Salary"].ReadOnly = true;
                    ////        dgvSalary.Columns["W_Day"].ReadOnly = true;
                    ////        dgvSalary.Columns["O_T"].ReadOnly = true;
                    ////        dgvSalary.Columns["Tot_Day"].ReadOnly = true;



                    ////        try
                    ////        {

                    ////            foreach (DataGridViewColumn col in dgvSalary.Columns)
                    ////            {
                    ////                if (col.HeaderText.ToLower().Trim() == "adv" || col.HeaderText.ToLower().Trim() == "advance")
                    ////                {
                    ////                    dgvSalary.Columns[col.Index].ReadOnly = true;
                    ////                }

                    ////                if (col.HeaderText.ToLower().Trim() == ("kit") || col.HeaderText.ToLower().Trim() == ("unif") || col.HeaderText.ToLower().Trim() == ("uniform") || col.HeaderText.ToLower().Trim() == ("dress"))
                    ////                {
                    ////                    dgvSalary.Columns[col.Index].ReadOnly = true;
                    ////                }

                    ////                if (col.HeaderText.ToLower().Trim() == "ln" || col.HeaderText.ToLower().Trim() == "loan")
                    ////                {
                    ////                    dgvSalary.Columns[col.Index].ReadOnly = true;
                    ////                }
                    ////            }


                    ////        }
                    ////        catch { }
                    ////        dgvSalary.Columns["TotalLeave"].ReadOnly = true;

                    ////        dgvSalary.Columns["sl"].Frozen = true;
                    ////        dgvSalary.Columns["EmployeeName"].Frozen = true;
                    ////        dgvSalary.Columns["ID"].Frozen = true;

                    ////        // dgvSalary.Columns["DesgID"].Visible = false;

                    ////    }
                    ////    dgvSalary.Rows[dgvSalary.RowCount - 1].Cells[i].Style.BackColor = Color.SkyBlue;
                    ////    dgvSalary.Rows[dgvSalary.Rows.Count - 1].Cells[i].Style.Font = new Font("Times New Roman", 8, FontStyle.Bold);

                    ////}
                    //dataGridView1.Rows[dataGridView1.RowCount - 1].Frozen = true;
                }

            }
            catch (Exception x) { }

            if (dgvSalary.Rows.Count == 0)
            {
                return;
            }
            dgvSalary.Columns["sl"].Width = 30;
            dgvSalary.Columns["EmployeeName"].Width = 130;
            dgvSalary.Columns["ID"].Width = 70;
            dgvSalary.Columns["Salary"].Width = 70;
            dgvSalary.Columns["W_Day"].Width = 50;
            dgvSalary.Columns["O_T"].Width = 50;
            dgvSalary.Columns["Tot_Day"].Width = 60;

            dgvSalary.Columns["sl"].ReadOnly = true;
            dgvSalary.Columns["EmployeeName"].ReadOnly = true;
            dgvSalary.Columns["ID"].ReadOnly = true;
            dgvSalary.Columns["Salary"].ReadOnly = true;
            dgvSalary.Columns["W_Day"].ReadOnly = true;
            dgvSalary.Columns["O_T"].ReadOnly = true;
            dgvSalary.Columns["Tot_Day"].ReadOnly = true;



            try
            {

                foreach (DataGridViewColumn col in dgvSalary.Columns)
                {
                    if (col.HeaderText.ToLower().Trim() == "adv" || col.HeaderText.ToLower().Trim() == "advance")
                    {
                        dgvSalary.Columns[col.Index].ReadOnly = true;
                    }

                    if (col.HeaderText.ToLower().Trim() == ("kit") || col.HeaderText.ToLower().Trim() == ("unif") || col.HeaderText.ToLower().Trim() == ("uniform") || col.HeaderText.ToLower().Trim() == ("dress"))
                    {
                        dgvSalary.Columns[col.Index].ReadOnly = true;
                    }

                    if (col.HeaderText.ToLower().Trim() == "ln" || col.HeaderText.ToLower().Trim() == "loan")
                    {
                        dgvSalary.Columns[col.Index].ReadOnly = true;
                    }
                }


            }
            catch { }
            dgvSalary.Columns["TotalLeave"].ReadOnly = true;

            dgvSalary.Columns["sl"].Frozen = true;
            dgvSalary.Columns["EmployeeName"].Frozen = true;
            dgvSalary.Columns["ID"].Frozen = true;
            dgvSalary.Columns["ID"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgPfEsi.Columns["eid"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvSalary.Rows[dgvSalary.RowCount - 1].DefaultCellStyle.BackColor = Color.SkyBlue;
            dgvSalary.Rows[dgvSalary.Rows.Count - 1].DefaultCellStyle.Font = new Font("Times New Roman", 8, FontStyle.Bold);

            try
            {
                DataTable pf_esi = clsDataAccess.RunQDTbl("Select emp_id as eid," +
          "(select ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) from tbl_Employee_Mast AS em where em.ID=ec.emp_id) AS EmployeeName," +
                "month,session,coid,lid,pf_bs,esi_bs,pf_employer_cont as pf_contribution,esi_employer_cont as esi_contribution,pf,esi,desgid,OT from tbl_employers_contribution ec where (month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "') and (lid='" + Locations + "') order by emp_id");

                pf_esi.Columns.Remove("EmployeeName");
                pf_esi.Columns.Remove("month");
                pf_esi.Columns.Remove("session");
                pf_esi.Columns.Remove("coid");
                pf_esi.Columns.Remove("lid");
                if (pf_esi.Rows.Count > 0)
                    dgPfEsi.DataSource = pf_esi;

                //for (int idx=0;idx<pf_esi.Rows.Count;idx++){
                //dgPfEsi.Rows[idx].Cells["eid"].Value 
                //dgPfEsi.Rows[idx].Cells["pf_bs"].Value 
                //dgPfEsi.Rows[idx].Cells["esi_bs"].Value 
                //dgPfEsi.Rows[idx].Cells["pf_contribution"].Value 
                //dgPfEsi.Rows[idx].Cells["esi_contribution"].Value
                //}

            }
            catch { }

            try
            {
                if (woff == 0)
                {
                    dgvSalary.Columns["WeeklyOff"].Visible = false;

                }
                else
                {
                    dgvSalary.Columns["WeeklyOff"].Visible = true;
                }
            }
            catch
            { try { dgvSalary.Columns["WeeklyOff"].Visible = false; } catch { } }

            try
            {
                if (E_D == 0)
                {
                    dgvSalary.Columns["E_D"].Visible = false;

                }
                else
                {
                    dgvSalary.Columns["E_D"].Visible = true;
                }
            }
            catch
            { try { dgvSalary.Columns["E_D"].Visible = false; } catch { } }
            lbl_time_to.Text = DateTime.Now.ToString("hh:mm:ss tt");
            pnl_load.Visible = false;


        }
        string odid = "";
        private void txtAgentName_DropDown(object sender, EventArgs e)
        {
            string sql = "SELECT FirstName+' '+MiddleName+' '+LastName as EmployeeName ,ID FROM tbl_Employee_Mast where active=1 and Location_id = '" + Locations + "'";
            DataTable dt = clsDataAccess.RunQDTbl(sql);
            if (dt.Rows.Count > 0)
            {
                txtAgentName.LookUpTable = dt;
                txtAgentName.ReturnIndex = 1;
            }
        }

        private void txtAgentName_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            odid = "";
            try
            {
                odid = txtAgentName.ReturnValue;

                DataTable dt = clsDataAccess.RunQDTbl("SELECT FirstName+' '+MiddleName+' '+LastName as EmployeeName,ID,BankAcountNo,Bank_Name,Branch_Name FROM tbl_Employee_Mast where (active=1) and (Location_id='" + Locations + "') and (Id='" + odid + "')");
                this.txtAgentAcno.Text = Convert.ToString(dt.Rows[0]["BankAcountNo"]);
                this.txtAgentName.Text = Convert.ToString(dt.Rows[0]["EmployeeName"]);
                this.txtAgentBank.Text = Convert.ToString(dt.Rows[0]["Bank_Name"]) + " (" + Convert.ToString(dt.Rows[0]["Branch_Name"]) + ")";
            }
            catch { }

        }


        private void dgvOtherCharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (dgvOtherCharges.CurrentCell.ColumnIndex == dgvOtherCharges.Columns["dgColOName"].Index)
                {

                    frmSalStruc_other frmSSO = new frmSalStruc_other();
                    frmSSO.val_qry = "SELECT distinct ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) as EmployeeName ,em.Bank_Name,em.Branch_Name,em.BankAcountNo,em.GMIno FROM  tbl_Employee_Attend ea,tbl_Employee_Mast em where ea.Season='" + cmbYear.Text + "' and em.active=1 and ea.Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "' and ea.Location_id ='" + Locations + "' and em.ID  = ea.ID";

                    //    "SELECT  ' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployeeName ,em.Bank_Name,em.Branch_Name,em.BankAcountNo,em.GMIno" +
                    //" FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text +
                    //"' and em.active=1 and sm.Month ='" + cur_month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT = sm.Emp_Id";
                    frmSSO.ShowDialog();
                    int ind = dgvOtherCharges.CurrentRow.Index;
                    dgvOtherCharges.Rows[ind].Cells["dgColOAc"].Value = frmSSO.val_Ac;
                    dgvOtherCharges.Rows[ind].Cells["dgColOIfsc"].Value = frmSSO.val_IFSC;

                    dgvOtherCharges.Rows[ind].Cells["dgColOBank"].Value = frmSSO.val_Bank;
                    dgvOtherCharges.Rows[ind].Cells["dgColOBranch"].Value = frmSSO.val_Branch;
                    dgvOtherCharges.Rows[ind].Cells["dgColOName"].Value = frmSSO.val_Name;
                }
            }
        }

        /*------------------------------------------------------------------Coded by Dwipraj Dutta-------------------------------------------------------------*/
        private DataTable addition_of_TotalLeave_Column(DataTable Emp)
        {
            DataTable leave_details = new DataTable();
            DataColumn dc = new DataColumn("TotalLeave", typeof(System.String));
            Emp.Columns.Add(dc);
            total_Leave_visibility = false;

            for (int i = 0; i < Emp.Rows.Count - 1; i++)
            {
                String empIddd = Emp.Rows[i][2].ToString();

                leave_details.Clear();
                leave_details = clsDataAccess.RunQDTbl("SELECT distinct LeaveId,ShortName from tbl_Employee_Config_LeaveDetails where Session='" + cmbYear.Text + "' and Location_id = '" + Locations + "'");
                DataColumn dc1 = new DataColumn("LeaveCount", typeof(System.Double));
                dc1.DefaultValue = 0;
                leave_details.Columns.Add(dc1);

                leaveCountRef.Clear();
                leaveCountRef = clsDataAccess.RunQDTbl("select FstLeave,SndLeave from tbl_Employee_Attendance where Season='" + cmbYear.Text + "' and LOcation_ID = '" + Locations + "' and ID='" + empIddd + "' and LeaveDate between '" + AttenDtTmPkr.Value.Year + "/" + AttenDtTmPkr.Value.Month + "/01' and '" + AttenDtTmPkr.Value.Year + "/" + AttenDtTmPkr.Value.Month + "/" + DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month) + "'");

                for (int j = 0; j < leaveCountRef.Rows.Count; j++)
                {
                    total_Leave_visibility = true;
                    for (int k = 0; k < leaveCountRef.Columns.Count; k++)
                    {
                        if (leaveCountRef.Rows[j][k].ToString() != "0")
                        {
                            DataRow[] dr = leave_details.Select("LeaveId=" + leaveCountRef.Rows[j][k].ToString());
                            if (dr.Length > 0)
                            {
                                String slvcnt = dr[0]["LeaveCount"].ToString();
                                Double dlvcnt = Convert.ToDouble(slvcnt);
                                dr[0]["LeaveCount"] = dlvcnt + 0.5;
                            }
                        }
                    }
                }

                for (int j = 0; j < leave_details.Rows.Count; j++)
                {
                    string nl = Environment.NewLine;
                    Emp.Rows[i]["TotalLeave"] = Emp.Rows[i]["TotalLeave"].ToString() + leave_details.Rows[j][1].ToString() + " : " + leave_details.Rows[j][2].ToString() + nl;

                }
            }
            return Emp;
        }
        private DataTable addition_of_WeeklyOff_Column(DataTable Emp)
        {
            DataTable leave_details = new DataTable();
            DataColumn dc = new DataColumn("WeeklyOff", typeof(System.String));
            Emp.Columns.Add(dc);
            //weeklyOff_visibility = false;

            //First We find out last date of mont
            //DateTime today = DateTime.Today;
            DateTime endOfMonth = new DateTime(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month, DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month));
            //get only last day of month
            int day = endOfMonth.Day;
            //DateTime now = DateTime.Now;
            int count;
            count = 0;
            for (int i = 0; i < day; ++i)
            {
                DateTime d = new DateTime(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month, i + 1);
                //Compare date with sunday
                if (d.DayOfWeek == DayOfWeek.Sunday)
                {
                    count = count + 1;
                }
            }

            for (int i = 0; i < Emp.Rows.Count - 1; i++)
            {
                if (lbl_mod.Text == "MOD-EWO")
                {
                    string desgid = Emp.Rows[i]["DesgID"].ToString().Trim();
                    if (desgid.Trim() == "0")
                    {
                        desgid = clsDataAccess.ReturnValue("select DesgId from  tbl_Employee_Mast where (ID='" + Emp.Rows[i]["ID"].ToString().Trim() + "')");
                    }

                    Emp.Rows[i]["WeeklyOff"] = clsDataAccess.ReturnValue("select woff from [tbl_Employee_Attend] where (ID='" + Emp.Rows[i]["ID"].ToString().Trim() + "') and (Month ='" + this.AttenDtTmPkr.Value.Month + "/" + this.AttenDtTmPkr.Value.Year + "') and (Season = '" + cmbYear.Text + "') and (Location_ID ='" + Locations + "') and (Desgid = '" + desgid + "')");

                }
                else
                {
                    Emp.Rows[i]["WeeklyOff"] = lbl_WO.Text; //count.ToString();
                }
            }
            return Emp;
        }

        private void frmsalarystructure_KeyDown(object sender, KeyEventArgs e)
        {
            string oldStatus = "", newStatus = "";
            if (e.Control && e.KeyCode == Keys.H)
            {
                oldStatus = lblStatusCode.Text;
                subfrmEmployeeSalarySheetPFESIStatus fda = new subfrmEmployeeSalarySheetPFESIStatus(Convert.ToInt32(lblStatusCode.Text));
                fda.ShowDialog();
                try
                {
                    lblStatusCode.Text = fda.intReturnValue.ToString();
                }
                catch
                {
                    lblStatusCode.Text = "1";
                }
                newStatus = lblStatusCode.Text;
                e.SuppressKeyPress = true;
            }
            if (oldStatus != newStatus)
            {
                dgvSalary.DataSource = null;
                dgvOtherCharges.Rows.Clear();
                dgvOtherCharges.Visible = false;
                Locations = "";
                cmbLocation.Text = "";
                txtcalculated_days.Text = "0";
                AttenDtTmPkr.Value = System.DateTime.Now;
                groupBox4.Text = "";
                txtAgentAcno.Text = "";
                txtAgentBank.Text = "";
                txtAgentName.Text = "";
                lbltot.Text = "";
                cmbLocation.Text = "";
            }
        }

        public void PFESIManipulationChecking()
        {
            string filePath = "";
            filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
            string lineForConfigSetting;
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    if (file.ReadLine() != null)
                    {
                        int chk_str = 0;
                        while ((lineForConfigSetting = file.ReadLine()) != null)
                        {
                            string[] StrSTAR = lineForConfigSetting.Trim().Split('*');
                            if (StrSTAR.Length == 2)
                            {
                                if (StrSTAR[0].Trim() == "")
                                    continue;
                            }

                            string[] StrLine = lineForConfigSetting.Trim().Split('[');
                            if (StrLine.Length == 2)
                            {
                                string str = lineForConfigSetting.Substring(1, lineForConfigSetting.Length - 2);
                                if (str.ToUpper() == "PFESI_MANIPULATION")
                                    chk_str = 1;
                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                if (StrLine_WACC[0] == "ON")
                                    boolPFESIManipulating = true;
                                else if (StrLine_WACC[0] == "OFF")
                                    boolPFESIManipulating = false;
                                chk_str = 0;
                            }
                        }
                    }

                }
                catch
                { }
            }
        }

        public int NoOfWorkingDays(DateTime dtpBillMon)
        {
            int count = 0;
            int Days = DateTime.DaysInMonth(dtpBillMon.Year, dtpBillMon.Month);
            for (int i = 0; i < Days; i++)
            {
                DateTime dt = new DateTime(dtpBillMon.Year, dtpBillMon.Month, i + 1);
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    count++;
                }
            }
            return (Days - count);
        }

        public int NoOfWorkingDays(DateTime dtpBillMon, int From, int To, Boolean WOSunday)
        {
            int count = 0;
            int DaysInFromMonth = DateTime.DaysInMonth(dtpBillMon.Year, dtpBillMon.Month - 1);
            int DaysInToMonth = DateTime.DaysInMonth(dtpBillMon.Year, dtpBillMon.Month);
            int Days = DaysInFromMonth - From + To + 1;     //1 has been added as the from date will also counted
            if (WOSunday)
            {
                for (int i = From; i <= DaysInFromMonth; i++)
                {
                    DateTime dt = new DateTime(dtpBillMon.Year, dtpBillMon.Month - 1, i);
                    if (dt.DayOfWeek == DayOfWeek.Sunday)
                    {
                        count++;
                    }
                }
                for (int i = 1; i <= To; i++)
                {
                    DateTime dt = new DateTime(dtpBillMon.Year, dtpBillMon.Month, i);
                    if (dt.DayOfWeek == DayOfWeek.Sunday)
                    {
                        count++;
                    }
                }
                return (Days - count);
            }
            return (Days);
        }

        public int NoOfSunDays(DateTime dtpBillMon)
        {
            int count = 0;
            int Days = DateTime.DaysInMonth(dtpBillMon.Year, dtpBillMon.Month);
            for (int i = 0; i < Days; i++)
            {
                DateTime dt = new DateTime(dtpBillMon.Year, dtpBillMon.Month, i + 1);
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    count++;
                }
            }
            return (count);
        }

        public int NoOfSunDays(DateTime dtpBillMon, int From, int To)
        {
            int count = 0;
            int DaysInFromMonth = DateTime.DaysInMonth(dtpBillMon.Year, dtpBillMon.Month - 1);
            int DaysInToMonth = DateTime.DaysInMonth(dtpBillMon.Year, dtpBillMon.Month);
            int Days = DaysInFromMonth - From + To + 1;
            for (int i = From; i <= DaysInFromMonth; i++)
            {
                DateTime dt = new DateTime(dtpBillMon.Year, dtpBillMon.Month - 1, i);
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    count++;
                }
            }
            for (int i = 1; i <= To; i++)
            {
                DateTime dt = new DateTime(dtpBillMon.Year, dtpBillMon.Month, i);
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    count++;
                }
            }

            return (count);
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            DataTable dtDGVCopy = new DataTable();
            foreach (DataGridViewColumn col in dgvSalary.Columns)
            {
                dtDGVCopy.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvSalary.Rows)
            {
                DataRow dRow = dtDGVCopy.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dtDGVCopy.Rows.Add(dRow);
            }
            dtDGVCopy.Rows.Add();
            for (int i = 0; i < dgRowTotalCount.Cells.Count - 1; i++)
            {
                dtDGVCopy.Rows[dtDGVCopy.Rows.Count - 1][i] = dgRowTotalCount.Cells[i].Value;
            }
            dgvSalary.DataSource = null;
            dgvSalary.DataSource = dtDGVCopy;
            for (int i = 0; i <= dgvSalary.Columns.Count - 1; i++)
            {
                if (i == 0)
                {
                    dgvSalary.Columns["sl"].Width = 30;
                    dgvSalary.Columns["EmployeeName"].Width = 130;
                    dgvSalary.Columns["ID"].Width = 70;
                    dgvSalary.Columns["Salary"].Width = 70;
                    dgvSalary.Columns["W_Day"].Width = 50;
                    dgvSalary.Columns["O_T"].Width = 50;
                    dgvSalary.Columns["Tot_Day"].Width = 60;

                    dgvSalary.Columns["sl"].ReadOnly = true;
                    dgvSalary.Columns["EmployeeName"].ReadOnly = true;
                    dgvSalary.Columns["ID"].ReadOnly = true;
                    dgvSalary.Columns["Salary"].ReadOnly = true;
                    dgvSalary.Columns["W_Day"].ReadOnly = true;
                    dgvSalary.Columns["O_T"].ReadOnly = true;
                    dgvSalary.Columns["Tot_Day"].ReadOnly = true;
                    dgvSalary.Columns["TotalLeave"].ReadOnly = true;

                    dgvSalary.Columns["sl"].Frozen = true;
                    dgvSalary.Columns["EmployeeName"].Frozen = true;
                    dgvSalary.Columns["ID"].Frozen = true;

                    dgvSalary.Columns["DesgID"].Visible = false;
                    dgvSalary.Columns["TotalLeave"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvSalary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvSalary.Columns["TotalLeave"].DisplayIndex = dgvSalary.Columns["Tot_Day"].DisplayIndex + 1;
                    if (!total_Leave_visibility)
                        dgvSalary.Columns["TotalLeave"].Visible = false;
                    dgvSalary.Columns["WeeklyOff"].DisplayIndex = dgvSalary.Columns["Tot_Day"].DisplayIndex + 2;

                }
                dgvSalary.Rows[dgvSalary.RowCount - 1].Cells[i].Style.BackColor = Color.SkyBlue;


            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                dgRowTotalCount = (DataGridViewRow)dgvSalary.Rows[((DataGridView)sender).Rows.Count - 1].Clone();
                for (Int32 index = 0; index < ((DataGridView)sender).Rows[((DataGridView)sender).Rows.Count - 1].Cells.Count; index++)
                {
                    dgRowTotalCount.Cells[index].Value = ((DataGridView)sender).Rows[((DataGridView)sender).Rows.Count - 1].Cells[index].Value;
                }

                if (((DataGridView)sender).Rows[((DataGridView)sender).Rows.Count - 1].Cells[1].Value.ToString().Trim().ToLower() == "total :")
                {
                    ((DataGridView)sender).Rows.RemoveAt(((DataGridView)sender).Rows.Count - 1);
                }





            }
            else if (e.RowIndex >= 0)
            {
                dgvSalary.DefaultCellStyle.BackColor = Color.White;

                //for (int i = 0; i <= dgvSalary.Columns.Count - 1; i++)
                //{
                //    dgvSalary.BackgroundColor = Color.White;

                for (int j = 0; j <= dgvSalary.Rows.Count - 1; j++)
                {
                    dgvSalary.Rows[j].DefaultCellStyle.BackColor = Color.White;
                }

                //    dgvSalary.Rows[dgvSalary.RowCount - 1].Cells[i].Style.BackColor = Color.SkyBlue;

                //}

                dgvSalary.Rows[dgvSalary.RowCount - 1].DefaultCellStyle.BackColor = Color.SkyBlue;
                dgvSalary.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Violet;



            }
        }

        private void cmbZone_DropDown(object sender, EventArgs e)
        {
            cmbZone.ReturnValue = "0";
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("select zone,zid from tbl_zone order by zid");
            if (dt.Rows.Count > 0)
            {
                cmbZone.LookUpTable = dt;
                cmbZone.ReturnIndex = 1;
            }

        }

        private void chkAllLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllLocation.Checked == true)
            {
                cmbZone.Enabled = true;
                cmbZone.PopUp();
            }
            else
            {
                cmbZone.Text = "";
                cmbZone.Enabled = false;
            }
        }
        public double chk_pf_base(int ind)
        {
            string[] pf = lbl_Pf_formula.Text.ToString().Replace("(", "").Replace(")", "").Trim().Split('*');
            string[] pfhead = pf[0].Split('+');

            double valpf = 0;
            double old_vpf = 0, new_vpf = 0;
            int ipf = 0;
            DataTable dt_pfesi = new DataTable();
            DataTable dt_pfesi_limit = new DataTable();
            DataTable dtcalc = new DataTable();
            string exp = "";

            //for (int ind = 0; ind < dataGridView1.Rows.Count - 1; ind++)
            //{
            ipf = 0;
            valpf = 0;
            old_vpf = 0; new_vpf = 0;

            dt_pfesi = clsDataAccess.RunQDTbl("SELECT PF_Deduction,ESI_Deduction, ISNULL(Gender, '') AS Gender FROM tbl_Employee_Mast where (ID='" + dgvSalary.Rows[ind].Cells["ID"].Value + "')");
            dt_pfesi_limit = clsDataAccess.RunQDTbl("SELECT pf_limit,esi_limit FROM CompanyLimiter");
            if (Convert.ToInt32(dt_pfesi.Rows[0]["PF_Deduction"].ToString()) > 0)
            {
                valpf = 0;
                ipf = 0;
                old_vpf = 0;
                new_vpf = 0;

            }
            else
            {
                try
                {
                    while (ipf < pfhead.Length)
                    {
                        valpf = valpf + Convert.ToDouble(dgvSalary.Rows[ind].Cells[pfhead[ipf]].Value);
                        ipf++;
                    }
                }
                catch
                { }
            }

            // }
            if (valpf > Convert.ToDouble(dt_pfesi_limit.Rows[0]["pf_limit"]) && Convert.ToDouble(dt_pfesi_limit.Rows[0]["pf_limit"]) != 0)
            {
                valpf = Convert.ToDouble(dt_pfesi_limit.Rows[0]["pf_limit"]);
            }

            return valpf;

        }

        public double chk_pf_base_add(int ind, DataTable dt1)
        {
            string[] pf = lbl_Pf_formula.Text.ToString().Replace("(", "").Replace(")", "").Trim().Split('*');
            string[] pfhead = pf[0].Split('+');

            double valpf = 0;
            double old_vpf = 0, new_vpf = 0;
            int ipf = 0;
            DataTable dt_pfesi = new DataTable();
            DataTable dt_pfesi_limit = new DataTable();
            DataTable dtcalc = new DataTable();
            string exp = "";

            //for (int ind = 0; ind < dataGridView1.Rows.Count - 1; ind++)
            //{
            ipf = 0;
            valpf = 0;
            old_vpf = 0; new_vpf = 0;

            dt_pfesi = clsDataAccess.RunQDTbl("SELECT PF_Deduction,ESI_Deduction, ISNULL(Gender, '') AS Gender FROM tbl_Employee_Mast where (ID='" + dt1.Rows[ind]["ID"].ToString() + "')");
            dt_pfesi_limit = clsDataAccess.RunQDTbl("SELECT pf_limit,esi_limit FROM CompanyLimiter");
            if (Convert.ToInt32(dt_pfesi.Rows[0]["PF_Deduction"].ToString()) > 0)
            {
                valpf = 0;
                ipf = 0;
                old_vpf = 0;
                new_vpf = 0;

            }
            else
            {
                try
                {
                    while (ipf < pfhead.Length)
                    {
                        valpf = valpf + Convert.ToDouble(dt1.Rows[ind][pfhead[ipf]].ToString());
                        ipf++;
                    }
                }
                catch
                { }
            }

            // }
            if (valpf > Convert.ToDouble(dt_pfesi_limit.Rows[0]["pf_limit"]) && Convert.ToDouble(dt_pfesi_limit.Rows[0]["pf_limit"]) != 0)
            {
                valpf = Convert.ToDouble(dt_pfesi_limit.Rows[0]["pf_limit"]);
            }

            return valpf;

        }



        private void btnCalc_Click(object sender, EventArgs e)
        {
            //string s = "select sal_head,p_type,c_type,c_det,v_from,v_to,PF_PER,ESI_PER,PT,ROUND_TYPE,atten_day,Proxy_day,Revenue_Stamp,Stamp_Amount,C_BASIS,chkALK,chkHide,mod,wd,pt_basis from tbl_Employee_Assign_SalStructure where  sal_struct=" + salary_structure + " and p_type='D' and (PF_PER=1 or ESI_PER=1 or PT=1)";
            //DataTable dt = new DataTable();
            //dt = clsDataAccess.RunQDTbl(s);

            string[] pf = lbl_Pf_formula.Text.ToString().Replace("(", "").Replace(")", "").Trim().Split('*');
            string[] pfhead = pf[0].Split('+');

            string[] esi = lbl_esi_formula.Text.ToString().Replace("(", "").Replace(")", "").Trim().Split('*');
            string[] esihead = esi[0].Split('+');

            string[] pt = lbl_pt_formula.Text.Split('+');
            double valesi = 0, valpf = 0, valPT = 0;
            double old_vpf = 0, new_vpf = 0, old_vesi = 0, new_vesi = 0, old_vpt = 0, new_vpt = 0;
            int ipf = 0, iesi = 0, ipt = 0;
            DataTable dt_pfesi = new DataTable();

            DataTable dtcalc = new DataTable();
            DataTable dt_pfesi_limit = clsDataAccess.RunQDTbl("SELECT pf_limit,esi_limit FROM CompanyLimiter");
            string exp = "", gender = "";
            for (int ind = 0; ind < dgvSalary.Rows.Count - 1; ind++)
            {
                ipf = 0; iesi = 0; ipt = 0;
                valesi = 0; valpf = 0; valPT = 0;
                old_vpf = 0; new_vpf = 0; old_vesi = 0; new_vesi = 0; old_vpt = 0; new_vpt = 0;
                if (dgvSalary.Rows[ind].Cells["ID"].Value.ToString().Trim() == "ESS0001")
                {
                    old_vpf = 0;
                }
                dt_pfesi = clsDataAccess.RunQDTbl("SELECT isNull(PF_Deduction,0)as 'PF_Deduction',isNull(ESI_Deduction,0)as 'ESI_Deduction', ISNULL(Gender, '') AS Gender FROM tbl_Employee_Mast where (ID='" + dgvSalary.Rows[ind].Cells["ID"].Value + "')");

                if (Convert.ToInt32(dt_pfesi.Rows[0]["PF_Deduction"].ToString()) > 0)
                {
                    valpf = 0;
                    ipf = 0;
                    old_vpf = 0;
                    new_vpf = 0;

                }
                else
                {
                    try
                    {
                        while (ipf < pfhead.Length)
                        {
                            valpf = valpf + Convert.ToDouble(dgvSalary.Rows[ind].Cells[pfhead[ipf]].Value);
                            ipf++;
                        }

                        if (valpf > Convert.ToDouble(dt_pfesi_limit.Rows[0]["pf_limit"]) && Convert.ToDouble(dt_pfesi_limit.Rows[0]["pf_limit"]) != 0)
                        {
                            valpf = Convert.ToDouble(dt_pfesi_limit.Rows[0]["pf_limit"]);
                        }

                        old_vpf = Convert.ToDouble(dgvSalary.Rows[ind].Cells["PF"].Value);

                        exp = valpf.ToString() + "*" + pf[1].ToString();
                        var v = Convert.ToDouble(dtcalc.Compute(exp, ""));
                        new_vpf = Math.Round(Convert.ToDouble(v.ToString()));

                        if (old_vpf > 0 && old_vpf != new_vpf)
                        {
                            dgPfEsi.Rows[ind].Cells["pf_bs"].Value = string.Format("{0:F}", valpf);
                            dgvSalary.Rows[ind].Cells["PF"].Value = string.Format("{0:F}", new_vpf);
                            dgPfEsi.Rows[ind].Cells["pf_contribution"].Value = string.Format("{0:F}", get_pf_val(valpf.ToString(), 1));
                            dgPfEsi.Rows[ind].Cells["col_pf"].Value = dgvSalary.Rows[ind].Cells["PF"].Value;
                        }

                    }
                    catch
                    {
                    }
                }
                try
                {
                    if (Convert.ToInt32(dt_pfesi.Rows[0]["ESI_Deduction"].ToString()) > 0)
                    {
                        valesi = 0;
                        iesi = 0;
                        old_vesi = 0;
                        new_vesi = 0;

                    }
                    else
                    {
                        try
                        {
                            while (iesi < esihead.Length)
                            {
                                valesi = valesi + Convert.ToDouble(dgvSalary.Rows[ind].Cells[esihead[iesi]].Value);
                                iesi++;
                            }

                            old_vesi = Convert.ToDouble(dgvSalary.Rows[ind].Cells["ESI"].Value);

                            exp = valesi.ToString() + "*" + esi[1].ToString();
                            var v = Convert.ToDouble(dtcalc.Compute(exp, ""));
                            new_vesi = Math.Ceiling(Convert.ToDouble(v.ToString()));

                            if (old_vesi > 0 && old_vesi != new_vesi)
                            {
                                dgPfEsi.Rows[ind].Cells["esi_bs"].Value = string.Format("{0:F}", valesi);
                                dgPfEsi.Rows[ind].Cells["esi_contribution"].Value = string.Format("{0:F}", dtcalc.Compute(Math.Ceiling(valesi * Convert.ToDouble(lblEsi_empl.Text) / 100).ToString(), ""));
                                dgvSalary.Rows[ind].Cells["ESI"].Value = string.Format("{0:F}", new_vesi);

                                dgPfEsi.Rows[ind].Cells["col_esi"].Value = dgvSalary.Rows[ind].Cells["ESI"].Value;

                            }
                        }
                        catch
                        { }
                    }
                }
                catch
                { }
                try
                {

                    while (ipt < pt.Length)
                    {
                        try
                        {
                            if (pt[ipt].Trim().ToLower() == "gross")
                            {
                                valPT = valPT + Convert.ToDouble(dgvSalary.Rows[ind].Cells["Total_Earning"].Value);
                            }
                            else
                            {
                                valPT = valPT + Convert.ToDouble(dgvSalary.Rows[ind].Cells[pt[ipt]].Value);
                            }
                        }
                        catch
                        {

                            valPT = valPT + 0;
                        }
                        ipt++;
                    }
                }
                catch
                { }
                try
                {
                    if (dt_pfesi.Rows[0]["Gender"].ToString().Trim() == "")
                    {
                        gender = "MALE";
                    }
                    else
                    {
                        gender = dt_pfesi.Rows[0]["Gender"].ToString().Trim();

                    }
                    try
                    {
                        old_vpt = Convert.ToDouble(dgvSalary.Rows[ind].Cells[Lbl_pf_head.Text.Trim()].Value);
                    }
                    catch
                    {
                        old_vpt = Convert.ToDouble(dgvSalary.Rows[ind].Cells["PTAX"].Value);

                    }
                    if (AttenDtTmPkr.Value.ToString("MMM").ToUpper() == "FEB")
                    {
                        new_vpt = Convert.ToDouble(clsDataAccess.GetresultS("Select (case when alt_pt>0 then alt_pt else pt end) pt from tbl_Employee_PTRate where (wfrom <=" + valPT + " and wto >=" + valPT + ") and (lower(estate)='" + vState + "') and (upper(gender) in ('" + gender + "','ALL'))"));
                    }
                    else
                    {
                        new_vpt = Convert.ToDouble(clsDataAccess.GetresultS("Select pt from tbl_Employee_PTRate where (wfrom <=" + valPT + " and wto >=" + valPT + ") and (lower(estate)='" + vState + "') and (upper(gender) in ('" + gender + "','ALL'))"));
                    }

                    dgvSalary.Rows[ind].Cells[Lbl_pf_head.Text.Trim()].Value = string.Format("{0:F}", Math.Round(new_vpt));

                }
                catch { }

            }
            //label10.Text = ConvertNumbertoWords((long)Convert.ToDouble(lbltot.Text.Trim()));
        }

        public string ConvertNumbertoWords(long number)
        {
            if (number == 0) return "ZERO";
            if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " LAKH ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            //if ((number / 10) > 0)  
            //{  
            // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
            // number %= 10;  
            //}  
            if (number > 0)
            {
                if (words != "") words += "AND ";
                var unitsMap = new[]   
        {  
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"  
        };
                var tensMap = new[]   
        {  
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"  
        };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int col_ind = dgvSalary.CurrentCell.ColumnIndex;
                int row_ind = dgvSalary.CurrentCell.RowIndex;
                //foreach (DataGridViewColumn col in dataGridView1.Columns)
                //{
                int col_TEarn = dgvSalary.Columns["Total_Earning"].Index;

                int col_BS = dgvSalary.Columns["BS"].Index;
                string empid = dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString().Trim();
                string emp = dgvSalary.Rows[row_ind].Cells[1].Value.ToString().Trim(), head = dgvSalary.Columns[col_ind].HeaderText.Trim();

                if (col_ind >= col_BS && col_ind < col_TEarn)
                {
                    SalaryStructureView ssv = new SalaryStructureView(Locations, cmbLocation.Text, AttenDtTmPkr.Value.ToString("MMMM/yyyy"), empid, emp, head, "E");
                    ssv.ShowDialog();

                }
                else if (col_ind > col_TEarn)
                {
                    SalaryStructureView ssv = new SalaryStructureView(Locations, cmbLocation.Text, AttenDtTmPkr.Value.ToString("MMMM/yyyy"), empid, emp, head, "D");
                    ssv.ShowDialog();
                }

                if (row_ind < dgvSalary.Rows.Count - 1)
                {

                    if (dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == "adv" || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == "advance")
                    {
                        if (Convert.ToDouble(dgvSalary.Rows[row_ind].Cells[col_ind].Value) > 0 && btnSubmit.Text.ToLower().Trim() == "submit")
                        {

                            frmALKF_Details rec = new frmALKF_Details(dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString(), dgvSalary.Rows[row_ind].Cells["DesgID"].Value.ToString(), "Advance", AttenDtTmPkr.Value.ToString("dd/MMMM/yyyy"));

                            rec.ShowDialog();

                            if (rec.vl > 0)
                            {
                                dgvSalary.Rows[row_ind].Cells[col_ind].Value = string.Format("{0:F}", rec.ramt);
                                if (rec.dtVal.Rows.Count > 0)
                                {

                                    for (int idx = 0; idx < dgvRecoveries.Rows.Count; idx++)
                                    {
                                        if (dgvRecoveries.Rows[idx].Cells["eid"].Value.ToString().Trim() == dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString().Trim() && dgvRecoveries.Rows[idx].Cells["type"].Value.ToString().Trim().ToLower() == "advance")
                                        {
                                            dgvRecoveries.Rows.RemoveAt(idx);
                                            idx--;
                                        }
                                    }
                                    int rw_alfk = 0;
                                    for (int idx = 0; idx < rec.dtVal.Rows.Count; idx++)
                                    {
                                        rw_alfk = dgvRecoveries.Rows.Add();
                                        dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = rec.dtVal.Rows[idx]["tid"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = rec.dtVal.Rows[idx]["eid"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = rec.dtVal.Rows[idx]["desgID"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["ename"].Value = rec.dtVal.Rows[idx]["ename"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = rec.dtVal.Rows[idx]["amt"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = "Advance";
                                    }
                                }
                            }
                        }
                        else if (Convert.ToDouble(dgvSalary.Rows[row_ind].Cells[col_ind].Value) == 0 && btnSubmit.Text.ToLower().Trim() == "submit")
                        {

                            frmSal_Advance sa = new frmSal_Advance();
                            sa.empcode = dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString();
                            sa.empname = dgvSalary.Rows[row_ind].Cells["EmployeeName"].Value.ToString();
                            sa.eval = dgvSalary.Rows[row_ind].Cells[col_ind].Value.ToString();
                            sa.emonth = AttenDtTmPkr.Value.ToString("MMMM/yyyy");
                            //dataGridView1.Columns[col_ind].HeaderText.ToLower().Trim();
                            sa.DTP_MON.Value = AttenDtTmPkr.Value;
                            sa.ecoid = clsEmployee.GetCompany_ID(Convert.ToInt32(Locations)).ToString();
                            //dataGridView1.Columns[col_ind].HeaderText.ToLower().Trim();
                            sa.elocid = Locations;//dataGridView1.Columns[col_ind].HeaderText.ToLower().Trim();
                            sa.eloc = cmbLocation.Text;//dataGridView1.Columns[col_ind].HeaderText.ToLower().Trim();
                            sa.ShowDialog();
                            try
                            {
                                dgvSalary.Rows[row_ind].Cells[col_ind].Value = Convert.ToDouble(sa.eval).ToString("0.00");
                            }
                            catch
                            {
                                dgvSalary.Rows[row_ind].Cells[col_ind].Value = "0.00";
                            }
                            int rw_alfk = 0;
                            try
                            {
                                rw_alfk = dgvRecoveries.Rows.Add();
                                dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = sa.tid;
                                dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString();
                                dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = dgvSalary.Rows[row_ind].Cells["DesgID"].Value.ToString();
                                dgvRecoveries.Rows[rw_alfk].Cells["ename"].Value = dgvSalary.Rows[row_ind].Cells["EmployeeName"].Value.ToString();
                                dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = Convert.ToDouble(sa.eval).ToString("0.00");
                                dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = "Advance";
                            }
                            catch { }
                        }
                        calc_grid(row_ind, col_ind);
                    }

                    if (dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == ("kit") || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == ("unif") || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == ("uniform") || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == ("dress"))
                    {
                        // MessageBox.Show("Kit edit not avialable now");
                        if (Convert.ToDouble(dgvSalary.Rows[row_ind].Cells[col_ind].Value) > 0 && btnSubmit.Text.ToLower().Trim() == "submit")
                        {

                            //dgvSalary.Rows[row_ind].Cells[col_ind].Value = string.Format("{0:F}", sa.eval);
                            frmALKF_Details rec = new frmALKF_Details(dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString(), dgvSalary.Rows[row_ind].Cells["DesgID"].Value.ToString(), "Kit", AttenDtTmPkr.Value.ToString("dd/MMMM/yyyy"));

                            rec.ShowDialog();
                            if (rec.vl > 0)
                            {
                                dgvSalary.Rows[row_ind].Cells[col_ind].Value = string.Format("{0:F}", rec.ramt);
                                if (rec.dtVal.Rows.Count > 0)
                                {

                                    for (int idx = 0; idx < dgvRecoveries.Rows.Count; idx++)
                                    {
                                        if (dgvRecoveries.Rows[idx].Cells["eid"].Value.ToString().Trim() == dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString().Trim() && dgvRecoveries.Rows[idx].Cells["type"].Value.ToString().Trim().ToLower() == "kit")
                                        {
                                            dgvRecoveries.Rows.RemoveAt(idx);
                                            idx--;
                                        }
                                    }
                                    int rw_alfk = 0;
                                    for (int idx = 0; idx < rec.dtVal.Rows.Count; idx++)
                                    {
                                        rw_alfk = dgvRecoveries.Rows.Add();
                                        dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = rec.dtVal.Rows[idx]["tid"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = rec.dtVal.Rows[idx]["eid"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = rec.dtVal.Rows[idx]["desgID"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["ename"].Value = rec.dtVal.Rows[idx]["ename"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = rec.dtVal.Rows[idx]["amt"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = "Kit";
                                    }
                                }
                            }
                        }
                        else if (Convert.ToDouble(dgvSalary.Rows[row_ind].Cells[col_ind].Value) == 0 && btnSubmit.Text.ToLower().Trim() == "submit")
                        {
                            /*
                            frmSal_Advance sa = new frmSal_Advance();
                            sa.empcode = dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString();
                            sa.empname = dgvSalary.Rows[row_ind].Cells["EmployeeName"].Value.ToString();
                            sa.eval = dgvSalary.Rows[row_ind].Cells[col_ind].Value.ToString();
                            sa.emonth = AttenDtTmPkr.Value.ToString("MMMM/yyyy");
                            //dataGridView1.Columns[col_ind].HeaderText.ToLower().Trim();
                            sa.DTP_MON.Value = AttenDtTmPkr.Value;
                            sa.ecoid = clsEmployee.GetCompany_ID(Convert.ToInt32(Locations)).ToString();
                            //dataGridView1.Columns[col_ind].HeaderText.ToLower().Trim();
                            sa.elocid = Locations;//dataGridView1.Columns[col_ind].HeaderText.ToLower().Trim();
                            sa.eloc = cmbLocation.Text;//dataGridView1.Columns[col_ind].HeaderText.ToLower().Trim();
                            sa.ShowDialog();

                            try
                            {
                                dgvSalary.Rows[row_ind].Cells[col_ind].Value = Convert.ToDouble(sa.eval).ToString("0.00");
                            }
                            catch
                            {
                                dgvSalary.Rows[row_ind].Cells[col_ind].Value = "0.00";
                            }
                            int rw_alfk = 0;
                            try
                            {
                                rw_alfk = dgvRecoveries.Rows.Add();
                                dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = sa.tid;
                                dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString();
                                dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = dgvSalary.Rows[row_ind].Cells["DesgID"].Value.ToString();
                                dgvRecoveries.Rows[rw_alfk].Cells["ename"].Value = dgvSalary.Rows[row_ind].Cells["EmployeeName"].Value.ToString();
                                dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = Convert.ToDouble(sa.eval).ToString("0.00");
                                dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = "Kit";
                            }
                            catch { }
                              */

                        }
                        calc_grid(row_ind, col_ind);
                    }

                    if (dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == "ln" || dgvSalary.Columns[col_ind].HeaderText.ToLower().Trim() == "loan")
                    {
                        // MessageBox.Show("loan edit not avialable now");
                        if (Convert.ToDouble(dgvSalary.Rows[row_ind].Cells[col_ind].Value) > 0 && btnSubmit.Text.ToLower().Trim() == "submit")
                        {

                            frmALKF_Details rec = new frmALKF_Details(dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString(), dgvSalary.Rows[row_ind].Cells["DesgID"].Value.ToString(), "Loan", AttenDtTmPkr.Value.ToString("dd/MMMM/yyyy"));

                            rec.ShowDialog();
                            if (rec.vl > 0)
                            {
                                dgvSalary.Rows[row_ind].Cells[col_ind].Value = string.Format("{0:F}", rec.ramt);
                                if (rec.dtVal.Rows.Count > 0)
                                {

                                    for (int idx = 0; idx < dgvRecoveries.Rows.Count; idx++)
                                    {
                                        if (dgvRecoveries.Rows[idx].Cells["eid"].Value.ToString().Trim() == dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString().Trim() && dgvRecoveries.Rows[idx].Cells["type"].Value.ToString().Trim().ToLower() == "loan")
                                        {
                                            dgvRecoveries.Rows.RemoveAt(idx);
                                            idx--;
                                        }
                                    }
                                    int rw_alfk = 0;
                                    for (int idx = 0; idx < rec.dtVal.Rows.Count; idx++)
                                    {
                                        rw_alfk = dgvRecoveries.Rows.Add();
                                        dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = rec.dtVal.Rows[idx]["tid"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = rec.dtVal.Rows[idx]["eid"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = rec.dtVal.Rows[idx]["desgID"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["ename"].Value = rec.dtVal.Rows[idx]["ename"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = rec.dtVal.Rows[idx]["amt"].ToString().Trim();
                                        dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = "Loan";
                                    }
                                }
                            }
                        }
                        else if (Convert.ToDouble(dgvSalary.Rows[row_ind].Cells[col_ind].Value) == 0 && btnSubmit.Text.ToLower().Trim() == "submit")
                        {

                            frmSal_Loan sa = new frmSal_Loan();
                            sa.empcode = dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString();
                            sa.empname = dgvSalary.Rows[row_ind].Cells["EmployeeName"].Value.ToString();
                            sa.eval = dgvSalary.Rows[row_ind].Cells[col_ind].Value.ToString();
                            sa.emonth = AttenDtTmPkr.Value.ToString("MMMM/yyyy");
                            //dataGridView1.Columns[col_ind].HeaderText.ToLower().Trim();
                            sa.DTP_MON.Value = AttenDtTmPkr.Value;
                            sa.ecoid = clsEmployee.GetCompany_ID(Convert.ToInt32(Locations)).ToString();
                            //dataGridView1.Columns[col_ind].HeaderText.ToLower().Trim();
                            sa.elocid = Locations;//dataGridView1.Columns[col_ind].HeaderText.ToLower().Trim();
                            sa.eloc = cmbLocation.Text;//dataGridView1.Columns[col_ind].HeaderText.ToLower().Trim();
                            sa.ShowDialog();
                            try
                            {
                                dgvSalary.Rows[row_ind].Cells[col_ind].Value = Convert.ToDouble(sa.eval).ToString("0.00");
                            }
                            catch
                            {
                                dgvSalary.Rows[row_ind].Cells[col_ind].Value = "0.00";
                            }
                            int rw_alfk = 0;
                            try
                            {
                                rw_alfk = dgvRecoveries.Rows.Add();
                                dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = sa.tid;
                                dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = dgvSalary.Rows[row_ind].Cells["ID"].Value.ToString();
                                dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = dgvSalary.Rows[row_ind].Cells["DesgID"].Value.ToString();
                                dgvRecoveries.Rows[rw_alfk].Cells["ename"].Value = dgvSalary.Rows[row_ind].Cells["EmployeeName"].Value.ToString();
                                dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = Convert.ToDouble(sa.eval).ToString("0.00");
                                dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = "Loan";
                            }
                            catch { }

                        }

                        //dgvSalary.Rows[row_ind].Cells[col_ind].Value = string.Format("{0:F}", sa.eval);
                        calc_grid(row_ind, col_ind);
                    }
                    //  }


                }
            }
            catch { }

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            frmEmployeeSalarySheet ess = new frmEmployeeSalarySheet("P");


            // ess.view_sal_prev(AttenDtTmPkr.Value.Date, cmbLocation.ReturnValue.ToString(), cmbLocation.Text.ToString(), cmbYear.SelectedItem.ToString(), company_Id.ToString(),sender,e);
            ess.view_sal(AttenDtTmPkr.Value.Date, cmbLocation.ReturnValue.ToString(), cmbLocation.Text.ToString(), cmbYear.SelectedItem.ToString(), company_Id.ToString(), lbl_mod.Text.Trim());
            ess.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(0);
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            display("Completed...");
            backgroundWorker1.CancelAsync();
        }
        //simulate complex calculations
        private void simulateHeavyWork()
        {
            Thread.Sleep(100);
        }
        //for messages
        private void display(string text)
        {
            lbl_load_msg.Text = text;

            // pnl_load.Visible = false;

            //MessageBox.Show("Mail send completed.. Check log file for details : " + path, "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lbl_load_msg.Text = "Processing... " + cntEmp + " of " + cntEmp_tot;
        }

        private void dgvSalary_SelectionChanged(object sender, EventArgs e)
        {


            dgvSalary.DefaultCellStyle.BackColor = Color.White;

            //for (int i = 0; i <= dgvSalary.Columns.Count - 1; i++)
            //{
            //    dgvSalary.BackgroundColor = Color.White;

            for (int j = 0; j <= dgvSalary.Rows.Count - 1; j++)
            {
                dgvSalary.Rows[j].DefaultCellStyle.BackColor = Color.White;
            }

            //    dgvSalary.Rows[dgvSalary.RowCount - 1].Cells[i].Style.BackColor = Color.SkyBlue;

            //}
            int idx = 0;
            try
            {
                idx = (sender as DataGridView).CurrentRow.Index;
            }
            catch { }
            if (idx > 0)
            {
                chk_RC = 2;
                dgvSalary.Rows[idx].DefaultCellStyle.BackColor = Color.SkyBlue;
                dgvSalary.Rows[idx].DefaultCellStyle.BackColor = Color.Violet;
                //(sender as DataGridView).CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Purple;
            }
            else if (idx == 0 && chk_RC != 1)
            {
                chk_RC = 1;
                dgvSalary.Rows[idx].DefaultCellStyle.BackColor = Color.SkyBlue;
                dgvSalary.Rows[idx].DefaultCellStyle.BackColor = Color.Violet;
                //(sender as DataGridView).CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Purple;
            }
            //  dgvSalary.DefaultCellStyle.BackColor = Color.White;


        }







        /*--------------------------------------------------------------------------End------------------------------------------------------------------------*/


    }
}
