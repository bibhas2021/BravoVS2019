
/*
        * 
       ----------------------------------------------------------------------------
       ***********  Not In Use ***********
       Pay Days
       Present Days
       Pay Days-Daily Basis
       Present Days-Daily Basis          
       -----------------------------------------------------------------------------
       Independent
        * In General Formula       
                
       Residual Consolidated
        * It is a calculation basis which is applicable on Other Allowance.
        * Its function is to calculate total O.A and then deduct with Total Salary.
        
       Conditional
        * If we want to create any head which must be Conditional [like BS*35/100-1600]
                  
       Inflow
        * If we want to create any formula with *some added condition* and then 
         the condition value is added with some other head, then we create it 
         with Inflow Calculation Basis.
        * The final Fig is deducted with the Total Earning Salary
         
        * 
        ============================================================================ 
        */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Microsoft.VisualBasic;
namespace PayRollManagementSystem
{
    public partial class frmSalaryStructure_Define : Form //EDPComponent.FormBaseERP
    {
        public frmSalaryStructure_Define()
        {
            InitializeComponent();


        }
        string show_calc_basic = "", show_calc_type = "";
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        DataRow dr;
        string year = "";
        DataTable dt_ass = new DataTable();
        DataColumn dc1 = new DataColumn("Pay Type");
        DataColumn dc2 = new DataColumn("Salary Head");
        DataColumn dc3 = new DataColumn("Print Name");
        DataColumn dc4 = new DataColumn("Valid From");
        DataColumn dc5 = new DataColumn("Valid To");
        DataColumn dc6 = new DataColumn("Calc Basis");
        DataColumn dc7 = new DataColumn("Calc Type");
        DataColumn dc8 = new DataColumn("Formula/Slab/Lum");
        DataColumn dc9 = new DataColumn("PF");
        DataColumn dc10 = new DataColumn("PF %");
        DataColumn dc11 = new DataColumn("PF VOL");
        DataColumn dc12 = new DataColumn("ESI");
        DataColumn dc13 = new DataColumn("ESI %");
        DataColumn dc14 = new DataColumn("PT");
        DataColumn dc15 = new DataColumn("Round Off");
        DataColumn dc16 = new DataColumn("Round Type");
        DataColumn dc17 = new DataColumn("TDS");
        DataColumn dc18 = new DataColumn("TDS Exempt");
        DataColumn dc19 = new DataColumn("TDS Exempt Max");
        DataColumn dc20 = new DataColumn("Carry");
        DataColumn dc21 = new DataColumn("TDS Extrapolate");
        DataColumn dc22 = new DataColumn("Remarks");
       
        DataColumn dc24 = new DataColumn("slno");
        DataColumn dc26 = new DataColumn("Atten Day");
        DataColumn dc27 = new DataColumn("Over Time");
        DataColumn dc28 = new DataColumn("Daily Wages");
        DataColumn dc29 = new DataColumn("Revenue Stamp");
        DataColumn dc30 = new DataColumn("Stamp Amount");

        //testless
        DataColumn dc31 = new DataColumn("Empbasic");

        DataColumn dc32 = new DataColumn("wd");
        //================================================
        DataColumn dc23 = new DataColumn("PT_basis");


        //
        DataColumn dc33 = new DataColumn("chkALK");
        DataColumn dc34 = new DataColumn("chkHide");
        DataColumn dc35 = new DataColumn("mod");
        //--------------------------------------------------
        DataColumn dc36 = new DataColumn("no_round");
        DataColumn dc37 = new DataColumn("limit_day");
        DataColumn dc38 = new DataColumn("ldays");
        DataColumn dc39 = new DataColumn("alt_mon");
        DataColumn dc40 = new DataColumn("lvless");
        DataColumn dc41 = new DataColumn("GS");
        DataColumn dc42 = new DataColumn("Flag");
        DataColumn dc43 = new DataColumn("NCompliance");
        //[no_round]=0, [limit_day]=0, [ldays]=0
        //--------------------------------------------------
        Hashtable hsg_ass_head_sal_struc = new Hashtable();
        int sl_no = 0, Locations = 0, company_Id = 0, Structure_ID = 0, salflag=0, salafterdeduction=0;

        string _paytype = "";
        int vLv = 0, vEd = 0, cWD_MOD = 0, vEmpSal=0,flag=0;

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnsave.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsals_Click(object sender, EventArgs e)
        {
            try
            {
                Employee_Salary_Structure ess = new Employee_Salary_Structure();
                ess.ShowDialog();
            }
            catch (Exception x) { }
        }


        private void btnfmula_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbctype.Text == "COMPANY LUMPSUM")
                {
                    Lumpsum_definer ld = new Lumpsum_definer();
                    ld.get_Lumpsum(Sal_ID(), 0);
                    ld.txtSearch.Text = cmboth.Text;

                    ld.ShowDialog();
                }
                else if (cmbctype.Text == "SAL STRUCTURE LUMPSUM")
                {
                    Lumpsum_definer ld1 = new Lumpsum_definer();
                    ld1.cmbsal_structure.Visible = true;
                    ld1.cmbsal_structure.Text = cmbsalstruc.Text;
                    ld1.cmbsal_structure.Enabled = false;

                    ld1.lblsalstruc.Visible = true;
                    ld1.get_Lumpsum(Sal_ID(), 1);

                    ld1.ShowDialog();
                }
                else if (cmbctype.Text == "FORMULA")
                {
                    Config_SalaryStructure_Formula cs = new Config_SalaryStructure_Formula();
                    cs.txtSearch.Text = cmboth.Text;
                    cs.StartPosition = FormStartPosition.CenterScreen;
                    cs.ShowDialog();
                }
                else if (cmbctype.Text == "SLAB")
                {
                    slab_details sd = new slab_details();
                    sd.ShowDialog();
                }
            }
            catch (Exception x) { }
        }

        private void btnsalhead_Click(object sender, EventArgs e)
        {
            try
            {
                Salary_Head sh = new Salary_Head();
                sh.ShowDialog();
            }
            catch (Exception x) { }
        }

        public void hide_settings()
        {
            grp_deduct.Visible = false;
            lbl_deduct_msg.Visible = false;
            //---------------------------------
            grp_add_opt.Visible = true;
            //lblMsg2.Visible = true; lbl_msg_addopt.Visible = true;
            lbl_adtn_click.Text = "Click +";
            lbl_ded_click.Text = "Click +";
            cheattendence.Visible = true; chedailywages.Checked = false;
            //---------------------------------
            grp_other_mode.Visible = false; lblMsg3.Visible = false;
            //---------------------------------
            pnl_joining.Visible = false;
            //chkPS_H.Checked = false;

        }

        private void Employee_Heads_to_Structure_Load(object sender, EventArgs e)
        {
            string s = "";
            show_calc_basic = "1";
            show_calc_type = "1";
            this.cmbcbasis.Items.Remove("Pay Days");
            this.cmbcbasis.Items.Remove("Present Days");
            this.cmbcbasis.Items.Remove("Pay Days-Daily Basis");
            this.cmbcbasis.Items.Remove("Present Days-Daily Basis");

            this.cmbctype.Items.Remove("SLAB"); this.cmbctype.Items.Remove("SAL STRUCTURE LUMPSUM");
            this.cmbctype.Items.Remove("LUMPSUM");
            //for (int i =  this.cmbcbasis.Items.Count - 1; i >= 0; i--)
            //{
            //    if (cmbcbasis.Items[i].ToString() != "Independent")
            //    {
            //        cmbcbasis.Items.RemoveAt(i);
            //    }
            //    elseif
            //}
            try
            {
                if (clsDataAccess.GetresultS("select sal_nc from CompanyLimiter") == "1")
                {
                    chkNC.Visible = true;
                }
                else
                {
                    chkNC.Visible = false;
                }
            }
            catch { }

            int mn = Convert.ToInt32(clsDataAccess.GetresultI("tbl_Employee_Assign_SalStructure", "chkALK"));
            if (mn == 0)
            {
                string str = "ALTER TABLE tbl_Employee_Assign_SalStructure ADD [chkALK] [int] NULL";
                bool rs = clsDataAccess.RunNQwithStatus(str);

                str = "Update tbl_Employee_Assign_SalStructure set chkALK=0";
                rs = clsDataAccess.RunNQwithStatus(str);
            }

            mn = Convert.ToInt32(clsDataAccess.GetresultI("tbl_Employee_Assign_SalStructure", "chkHide"));
            if (mn == 0)
            {
                string str = "ALTER TABLE tbl_Employee_Assign_SalStructure ADD [chkHide] [int] NULL";
                bool rs = clsDataAccess.RunNQwithStatus(str);

                str = "Update tbl_Employee_Assign_SalStructure set chkHide=0";
                rs = clsDataAccess.RunNQwithStatus(str);
            }

            try
            {
                
                this.cmbvfrom.SelectedItem = "April";
                this.cmbvto.SelectedItem = "March";
                //this.HeaderText = "Assign Heads To Salary Structure ";
                //s = "select salarycategory from tbl_Employee_SalaryStructure";
                //Load_Data(s, cmbsalstruc,-1);
                //s = "select salaryhead_short from tbl_Employee_ErnSalaryHead";
                //Load_Data(s, cmbsalhead,-1);
                //s = "select salaryhead_short from tbl_Employee_DeductionSalayHead";
                //Load_Data(s, cmbsalhead,-1);
                //s = "select shortname from tbl_Employee_Config_PFHeads";
                //Load_Data(s, cmbsalhead,-1);

                clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
                //

                //set session
                if (System.DateTime.Now.Month >= 4)
                {
                    cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedIndex = 1;
                }
            }
            catch (Exception x) { }
            clsGeneralShow genralshow = new clsGeneralShow();
            genralshow.getCurLocID();

            this.WindowState = FormWindowState.Maximized;

            hide_settings();

            grp_add_opt.Visible = false;
            lblMsg2.Visible = false; lbl_msg_addopt.Visible = false;
            chedailywages.Checked = false;

           
            try
            {
                vLv = Convert.ToInt32(clsDataAccess.GetresultS("select lv from CompanyLimiter"));
            }
            catch
            {
                vLv = 0;
            }

            try
            {
                vEd = Convert.ToInt32(clsDataAccess.GetresultS("select ed from CompanyLimiter"));
            }
            catch
            {
                vEd = 0;
            }

            cWD_MOD = 0;

            try
            {
                cWD_MOD = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select desgday from CompanyLimiter")));
            }
            catch
            {
                cWD_MOD = 0;
            }
            try
            {
                vEmpSal = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select empsal from CompanyLimiter")));
            }
            catch { }

             
            try
            {
                salflag = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select salflag from CompanyLimiter")));
            }
            catch { salflag = 0; }
            try
            {
                salafterdeduction = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select salafterdeduction from CompanyLimiter")));
            }
            catch { salafterdeduction = 0; }


            if (salflag == 0)
            {
                chkFlag.Visible = false;
            }
            else
            {
                chkFlag.Visible = true;
            }
            if (salafterdeduction == 0)
            {
                chkAfterDeductionEffect.Visible = false;
            }
            else
            {
                chkAfterDeductionEffect.Visible = true;
            }

            if (vEmpSal == 0)
            { chkEmpAmt.Checked = false;  }
            else { chkEmpAmt.Checked = true; }

            if (cWD_MOD == 1)
            {

                chkAtten_WD.Visible = true;
            }
            else
            {
                chkAtten_WD.Visible = false;
            }

            if (vLv == 1)
            {
                chkLv.Visible = true;
            }
            else
            {
                chkLv.Visible = false;
            }

            if (vEd == 1)
            {
                chkED.Visible = true;
            }
            else
            {
                chkED.Visible = false;
            }

        }

        public void Load_Data(string qry, ComboBox cb, int i)
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

        public void Load_Data_Sal(string qry, ComboBox cb, int i)
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



        public int Sal_ID()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select SlNo from tbl_Employee_SalaryStructure where SalaryCategory='" + cmbsalstruc.Text + "'";
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
        public int get_sal_head_ID(string head)
        {

            string s = "";
            int pb = 0;
            DataTable dt1 = new DataTable();

            s = "select SalaryHead_Short,slno from tbl_Employee_ErnSalaryHead";
            dt1 = clsDataAccess.RunQDTbl(s);
            if (dt1.Rows.Count > 0)
            {
                for (int f = 0; f < dt1.Rows.Count; f++)
                {
                    if (dt1.Rows[f][0].ToString().Trim() == head)
                        pb = Convert.ToInt32(dt1.Rows[f][1]);
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
                        pb = Convert.ToInt32(dt1.Rows[f][1]);
                }

            }

            return pb;
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
        public int get_OtherID(string typeName, string name)
        {
            string s = ""; int ret = 0; DataTable dts = new DataTable();
            if (typeName == "COMPANY LUMPSUM")
            {
                s = "select LUMPID from tbl_Employee_Lumpsum where LUMPNAME='" + name + "' and LUMPTYPE=0";

                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    ret = Convert.ToInt32(dts.Rows[0][0]);

            }
            else if (typeName == "SAL STRUCTURE LUMPSUM")
            {
                s = "select LUMPID from tbl_Employee_Lumpsum where LUMPNAME='" + name + "' and LUMPTYPE=1";
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    ret = Convert.ToInt32(dts.Rows[0][0]);
            }
            else if (typeName == "FORMULA")
            {
                s = "select fid from tbl_Employee_Sal_Structure_Formula where fname='" + name + "'";
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    ret = Convert.ToInt32(dts.Rows[0][0]);
            }
            else if (typeName == "SLAB")
            {
                s = "select slabid from tbl_Employee_Slab_Def where slabname='" + name + "'";
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    ret = Convert.ToInt32(dts.Rows[0][0]);
            }

            return ret;

        }
        public string get_OtherName(string typeName, int id)
        {
            string s = ""; string ret = ""; DataTable dts = new DataTable();
            if (typeName == "COMPANY LUMPSUM")
            {
                s = "select LUMPNAME from tbl_Employee_Lumpsum where LUMPID=" + id + " and LUMPTYPE=0";

                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    ret = dts.Rows[0][0].ToString();

            }
            else if (typeName == "SAL STRUCTURE LUMPSUM")
            {
                s = "select LUMPNAME from tbl_Employee_Lumpsum where LUMPID=" + id + " and LUMPTYPE=1";
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    ret = dts.Rows[0][0].ToString();
            }
            else if (typeName == "FORMULA")
            {
                s = "select fname from tbl_Employee_Sal_Structure_Formula where fid=" + id;
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    ret = dts.Rows[0][0].ToString();
            }
            else if (typeName == "SLAB")
            {
                s = "select slabname from tbl_Employee_Slab_Def where slabid=" + id;
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    ret = dts.Rows[0][0].ToString();
            }

            return ret;
        }


        private void cmbctype_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbsalstruc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cmbsalhead.Enabled = true;
                btnsalhead.Enabled = true;
            }
            catch (Exception x) { }
        }

        private void cmbsalhead_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                txtfull_name.Enabled = true;
                cmbvfrom.Enabled = true;
                cmbvto.Enabled = true;
                cmbcbasis.Enabled = true;
                //btncalcbs.Enabled = true;
                cmbctype.Enabled = true;
                cmboth.Enabled = true;
                btnfmula.Enabled = true;
                txtremarks.Enabled = true;
                txtpf.Enabled = true;
                chkpf.Enabled = true;
                chestump.Enabled = true;
                chkroundoff.Enabled = true;
                chkpt.Enabled = true;
                chkesi.Enabled = true;


            }
            catch (Exception x) { }

        }

        private void chkroundoff_CheckedChanged(object sender, EventArgs e)
        {
            if (chkroundoff.Checked)
            {
                cmbroundoff.Enabled = true;
                chkNetRoff.Checked = true;
            }
        }




        private void cmbsalstruc_DropDown(object sender, EventArgs e)
        {
            try
            {
                //if (clsValidation.ValidateComboBox(cmbLocation, "", "Please Select Location"))
                if (Locations != 0)
                {
                    cmbsalstruc.Items.Clear();
                    //string s = "select salarycategory from tbl_Employee_SalaryStructure";
                    string s = "";
                    Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
                    s = "select  l.salarycategory  from tbl_Employee_SalaryStructure l,tbl_Employee_Link_SalaryStructure ls where l.SlNo = ls.SalaryStructure_ID and ls.Location_ID = " + Locations + "";
                    Load_Data(s, cmbsalstruc, -1);
                    cmbsalstruc.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Please Select Location", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("No Salary Structure link found...", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void cmbsalhead_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbsalhead.Items.Clear();
                string s = "select salaryhead_short + ' - E' from tbl_Employee_ErnSalaryHead";
                Load_Data(s, cmbsalhead, -1);
                cmbsalhead.Items.Add("");
                s = "select salaryhead_short + ' - D' from tbl_Employee_DeductionSalayHead";
                Load_Data(s, cmbsalhead, -1);
                //s = "select shortname from tbl_Employee_Config_PFHeads";
                //Load_Data(s, cmbsalhead, -1);
                if (cmbsalhead.Text == "")
                    txtfull_name.Text = string.Empty;
            }
            catch (Exception x) { }
        }

        //private void cmboth_DropDown(object sender, EventArgs e)
        //{
        //    string s = "";
        //    cmboth.Items.Clear();

        //    if (cmbctype.Text == "FORMULA")
        //    {
        //        s = "select distinct fname from tbl_Employee_Sal_Structure_Formula";
        //        Load_Data(s, cmboth, -1);
        //    }
        //    else if (cmbctype.Text == "COMPANY LUMPSUM")
        //    {
        //        s = "select distinct lumpname from tbl_Employee_Lumpsum where lumptype=0";
        //        Load_Data(s, cmboth, -1);
        //    }
        //    else if (cmbctype.Text == "SAL STRUCTURE LUMPSUM")
        //    {
        //        s = "select lumpname from tbl_Employee_Lumpsum where strucid=" + Sal_ID() + " and lumptype=1";
        //        Load_Data(s, cmboth, -1);
        //    }
        //    else if (cmbctype.Text == "SLAB")
        //    {
        //        s = "select slabname from tbl_Employee_Slab_Def s,tbl_Employee_Slab_Det d where s.slabid=d.slabid";
        //        Load_Data(s, cmboth, -1);
        //    }

        //}

        //private void chkpf_Click(object sender, EventArgs e)
        //{
        //    if (chkpf.Checked)
        //    {
        //        chkpfvol.Enabled = true;
        //        txtpf.Enabled = true;
        //        txtpf.Text = string.Empty;
        //    }
        //    else
        //    {
        //        chkpfvol.Enabled = false;
        //        txtpf.Enabled = false;
        //        txtpf.Text = string.Empty;
        //    }
        //}

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (cmb_pt.SelectedIndex == 1)
            {
                if (txtPT.Text == "")
                {
                    MessageBox.Show("Provide heads for PT Calculation", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtPT.Focus();
                    return;
                }
            }

            try
            {
                //if (clsValidation.ValidateComboBox(comboBox1, "", "Please Select Location"))
                if (Locations != 0)
                {
                    if (clsValidation.ValidateComboBox(cmbsalstruc, "", "Please Select Salary Structure"))
                    {
                        if (clsValidation.ValidateComboBox(cmbsalhead, "", "Please Select Salary Head"))
                        {
                            if (clsValidation.ValidateComboBox(cmbcbasis, "", "Please select Calc. Basis"))
                            {
                                if (clsValidation.ValidateComboBox(cmbctype, "", "Please Select Calc. Type"))
                                {

                                    if (clsValidation.ValidateComboBox(cmbvfrom, "", "Please Select Month"))
                                    {
                                        if (clsValidation.ValidateComboBox(cmbvto, "", "Please Select Month"))
                                        {
                                            string[] salhead = cmbsalhead.Text.Trim().ToString().Split('-');
                                            _paytype = salhead[1].Trim();

                                            string s = cmbYear.Text.Trim() + "/" + get_SalStructID(cmbsalstruc.Text.Trim()) + "/" + get_sal_head_ID(salhead[0].Trim()) + "/" + cmbvfrom.Text.Trim() + "/" + cmbvto.Text.Trim();
                                            if (hsg_ass_head_sal_struc.ContainsKey(_paytype + "/" + cmbYear.Text.Trim() + "/" + get_SalStructID(cmbsalstruc.Text.Trim()) + "/" + get_sal_head_ID(salhead[0].Trim()) + "/" + cmbvfrom.Text.Trim() + "/" + cmbvto.Text.Trim()))
                                            {
                                                Update_st(Convert.ToInt32(hsg_ass_head_sal_struc[cmbYear.Text.Trim() + "/" + get_SalStructID(cmbsalstruc.Text.Trim()) + "/" + get_sal_head_ID(salhead[0].Trim()) + "/" + txtfull_name.Text.Trim() + "/" + cmbvfrom.Text.Trim() + "/" + cmbvto.Text.Trim()]));

                                                edpcom.InsertMidasLog(this, true, "mod", cmbsalstruc.Text.Trim());
                                            }
                                            else
                                            {
                                                save_st();
                                                edpcom.InsertMidasLog(this, true, "add", cmbsalstruc.Text.Trim());
                                            }


                                            //get_ass();
                                            //clea_all();
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                else { MessageBox.Show("Please Select Location", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
            }
            catch (Exception x) { }
        }

        public void save_st()
        {
            string ss = "", strMOD = "", strWD="",lvless="0",pt_basis=""; bool st = false;
            string[] salhead = cmbsalhead.Text.Trim().ToString().Split('-');
            int att_day = 0, ove_time = 0, daily_wages = 0, rev_stamp = 0, _chkbasic = 0, _chkSal = 0, _chkALK = 0, _chkHide = 0, sunday = 0, no_round = 0, limit_day = 0, ldays = 0, alt_mon = 0, gs = 0, _chkFlag = 0,_chkNC=0;

            if (chkNC.Checked == true)
            {
                _chkNC = 1;
            }
            else
            {
                _chkNC = 0;
            }

            if (chkFlag.Checked == true)
            {
                _chkFlag = 1;
            }
            else { _chkFlag = 0; }

            if (cheattendence.Checked == true)
                att_day = 1;

            if (chkGrossAs.Checked == true)
                gs = 1;

            if (cheovertime.Checked == true)
                ove_time = 1;
            if (chkED.Checked == true)
                ove_time = 2;

            if (chedailywages.Checked == true)
            {
               /* Wday
                  OT
                  TDays
                  ED */
                if (cmbDailyWages.SelectedIndex == 1)
                {
                    daily_wages = 11;
                }
                else if (cmbDailyWages.SelectedIndex == 2)
                {
                    daily_wages = 12;
                }
                else if (cmbDailyWages.SelectedIndex == 3)
                {
                    daily_wages = 13;
                }
                else if (cmbDailyWages.SelectedIndex == 4)
                {
                    daily_wages = 14;
                }
                else
                {
                    daily_wages = 1;
                }
            
            }
            else if (chkPerHour.Checked == true)
                daily_wages = 2;
            else if (chkAtten_WD.Checked == true)
                daily_wages = 3;
            else
                daily_wages = 0;

            if (chestump.Checked == true)
                rev_stamp = 1;

            if (chkSunday.Checked == true)
            {
                daily_wages = 5;
            }
            _chkbasic = 0;
            if (ChkEmpBasic.Checked == true)
                _chkbasic = 1;

            if (this.chkEmpBsTs.Checked == true)
                _chkbasic = 2;

            if (ChkEmpSal.Checked == true)
                _chkbasic = 3;


            if (chkGrossSub.Checked == true)
                _chkbasic = 4;

            if (chkEmpAmt.Checked == true)
                _chkbasic = 5;

            if (chkAdvance.Checked == true)
                _chkALK = 1;
            else if (chkLoan.Checked == true)
                _chkALK = 2;
            else if (chkKit.Checked == true)
                _chkALK = 3;
            else if (chkFine.Checked == true)
                _chkALK = 4;
            else if (chkGrossAdd.Checked == true)
                _chkALK = 6;
            else if (chkLv.Checked == true)
                _chkALK =7;
            else
                _chkALK = 0;

            if (this.chkHide.Checked == true)
                _chkHide = 1;
            else if (this.chkShowAfterNet.Checked == true)
                _chkHide = 2;
            else if (this.chkAfterDeductionEffect.Checked == true)
                _chkHide = 3;
            else
                _chkHide = 0;


            if (chkroundoff.Checked == true && chkNetRoff.Checked == false)
                no_round = 1;
            else if (chkroundoff.Checked == true && chkNetRoff.Checked == true)
                no_round = 2;
            else
                no_round = 0;
           
            if (chkMinDays.Checked==true)
            {
                limit_day = 1;
                try
                {
                    ldays = Convert.ToInt32(txtMinDays.Text);
                }
                catch
                {

                    ldays = 0;
                }

            }

            if (this.cbOtherOption.Checked)
            {
                if (cmbMOD.SelectedIndex == 0)
                {
                    strMOD = "MonthOfDays";//cmbMOD.Text;
                }
                else if (cmbMOD.SelectedIndex == 3 || cmbMOD.SelectedIndex == 4)
                {
                    strMOD = cmbMOD.Text + "[" + tbFrom.Text + "-" + tbTo + "]";
                }
                else if (cmbMOD.SelectedIndex == 2)
                {
                    strMOD = cmbMOD.Text;
                }
                else if (cmbMOD.SelectedIndex == 5)
                {
                    strMOD = cmbMOD.Text.Substring(0, 4) + tbFrom.Text.Trim();

                }
                else
                {
                    strMOD = tbFrom.Text;
                }
            }
            else
            {
                strMOD = "0";
            }
            //===============================Bibhas ------- 21-05-2018
            //MonthOfDays
            //Other
            //MOD-SUNDAYS
            //RANGE
            //RANGE-SUNDAYS
            //Mod-4
            if (chkpt.Checked == true)
            {
                if (cmb_pt.SelectedIndex == 0)
                    pt_basis = "GROSS";
                else
                    pt_basis = txtPT.Text.Trim().ToUpper();
            }
            else
            {
                if (chkActiveMonths.Checked == true)
                {
                    alt_mon = 1;
                    pt_basis = txtActiveMonths.Text.Trim().ToLower();
                }
                else
                {
                    alt_mon = 0;
                    pt_basis = "";
                }
            }

            if (this.chkOtherWD.Checked)
            {
                if (cmbWD.SelectedIndex == 0)
                {
                    strWD = "MonthOfDays";//cmbMOD.Text;
                }
                else if (cmbWD.SelectedIndex == 3 || cmbWD.SelectedIndex == 4)
                {
                    strWD = cmbWD.Text + "[" + tbFrom.Text + "-" + tbTo + "]";
                }
                else if (cmbWD.SelectedIndex == 2)
                {
                    strWD = cmbWD.Text;
                }
                else if (cmbWD.SelectedIndex == 5)
                {
                    strWD = cmbWD.Text.Substring(0, 4) + txt_wd_from.Text.Trim();

                }
                else if (cmbWD.SelectedIndex == 6)
                {
                    strWD = cmbWD.Text;
                }
                else
                {
                    strWD = tbFrom.Text;
                }
            }
            else
            {
                strWD = "0";
            }

            try
            {
                lvless = txtlessLv.Text.ToString();
            }
            catch
            {
                lvless = "0";
            }
            if (lvless.Trim() == "")
            {

                lvless = "0";
            }

            company_Id = clsEmployee.GetCompany_ID(Locations);
       //     SLNO,P_TYPE,SESSION,SAL_STRUCT,SAL_HEAD,V_FROM,V_TO,C_BASIS,C_TYPE,C_DET,PF_PER,PF_VOL,ESI_PER,PT,ROUND_TYPE,TDSREFNO,
       //TDS_EXEMPT,CARRY,TDS_EXTRAPOL,REMARKS,atten_day,Proxy_day,Daily_wages,Revenue_Stamp,Stamp_Amount,Location_id,Company_id,
       //EMP_BASIC,mod,chkALK,chkHide
            if (chkpf.Checked && chkesi.Checked)
            {
                if (chkpt.Checked)
                    ss = "insert into tbl_Employee_Assign_SalStructure(P_TYPE,SESSION,SAL_STRUCT,SAL_HEAD,V_FROM,V_TO,C_BASIS,C_TYPE,C_DET,PF_PER,PF_VOL,ESI_PER,PT,ROUND_TYPE,TDSREFNO,"+
       "TDS_EXEMPT,CARRY,TDS_EXTRAPOL,REMARKS,atten_day,Proxy_day,Daily_wages,Revenue_Stamp,Stamp_Amount,Location_id,Company_id,EMP_BASIC,chkALK,chkHide,mod,wd,pt_basis,[no_round], [limit_day], [ldays],[alt_mon],lvless,gs,lock,chkFlag,NCompliance) values(" + sal_head(salhead[0].Trim()) + "', '" + cmbYear.Text.Trim() + "', " + get_SalStructID(cmbsalstruc.Text.Trim()) + ", " + get_sal_head_ID(salhead[0].Trim()) + ", '" + cmbvfrom.Text.Trim() + "', '" + cmbvto.Text.Trim() + "', '" + cmbcbasis.Text.Trim() + "', '" + cmbctype.Text.Trim() + "', " + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ", '0' , 0, '0' , 1, '" + cmbroundoff.Text.Trim() + "',0,0,0,0, '" + txtremarks.Text.Trim() + "','" + att_day + "','" + ove_time + "','" + daily_wages + "','" + rev_stamp + "','" + txtstump.Text + "','" + Locations + "','" + company_Id + "','" + _chkbasic + "','" + _chkALK + "','" + _chkHide + "','" + strMOD + "','" + strWD + "','" + pt_basis + "','" + no_round + "','" + limit_day + "','" + ldays + "','" + alt_mon + "'," + lvless + "," + gs + ",1,'" + _chkFlag + "','"+ _chkNC +"')";
                else
                    ss = "insert into tbl_Employee_Assign_SalStructure(P_TYPE,SESSION,SAL_STRUCT,SAL_HEAD,V_FROM,V_TO,C_BASIS,C_TYPE,C_DET,PF_PER,PF_VOL,ESI_PER,PT,ROUND_TYPE,TDSREFNO,"+
       "TDS_EXEMPT,CARRY,TDS_EXTRAPOL,REMARKS,atten_day,Proxy_day,Daily_wages,Revenue_Stamp,Stamp_Amount,Location_id,Company_id,EMP_BASIC,chkALK,chkHide,mod,wd,pt_basis,[no_round], [limit_day], [ldays],[alt_mon],lvless,gs,lockchkFlag,NCompliance) values('" + sal_head(salhead[0].Trim()) + "', '" + cmbYear.Text.Trim() + "', " + get_SalStructID(cmbsalstruc.Text.Trim()) + ", " + get_sal_head_ID(salhead[0].Trim()) + ", '" + cmbvfrom.Text.Trim() + "', '" + cmbvto.Text.Trim() + "', '" + cmbcbasis.Text.Trim() + "', '" + cmbctype.Text.Trim() + "', " + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ", '0' , 0, '0' , 0, '" + cmbroundoff.Text.Trim() + "',0,0,0,0, '" + txtremarks.Text.Trim() + "','" + att_day + "','" + ove_time + "','" + daily_wages + "','" + rev_stamp + "','" + txtstump.Text + "','" + Locations + "','" + company_Id + "','" + _chkbasic + "','" + _chkALK + "','" + _chkHide + "','" + strMOD + "','" + strWD + "','" + pt_basis + "','" + no_round + "','" + limit_day + "','" + ldays + "','" + alt_mon + "'," + lvless + "," + gs + ",1,'" + _chkFlag + "','"+ _chkNC +"')";
                st = clsDataAccess.RunNQwithStatus(ss);
            }

            else if (!chkpf.Checked && chkesi.Checked)
            {
                if (chkpt.Checked)
                    ss = "insert into tbl_Employee_Assign_SalStructure(P_TYPE,SESSION,SAL_STRUCT,SAL_HEAD,V_FROM,V_TO,C_BASIS,C_TYPE,C_DET,PF_PER,PF_VOL,ESI_PER,PT,ROUND_TYPE,TDSREFNO,"+
       "TDS_EXEMPT,CARRY,TDS_EXTRAPOL,REMARKS,atten_day,Proxy_day,Daily_wages,Revenue_Stamp,Stamp_Amount,Location_id,Company_id,EMP_BASIC,chkALK,chkHide,mod,wd,pt_basis,[no_round], [limit_day], [ldays],[alt_mon],lvless,gs,lock,chkFlag,NCompliance) values('" + sal_head(salhead[0].Trim()) + "', '" + cmbYear.Text.Trim() + "', " + get_SalStructID(cmbsalstruc.Text.Trim()) + ", " + get_sal_head_ID(salhead[0].Trim()) + ", '" + cmbvfrom.Text.Trim() + "', '" + cmbvto.Text.Trim() + "', '" + cmbcbasis.Text.Trim() + "', '" + cmbctype.Text.Trim() + "', " + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ", 0 , 0, '1' , 1, '" + cmbroundoff.Text.Trim() + "',0,0,0,0, '" + txtremarks.Text.Trim() + "','" + att_day + "','" + ove_time + "','" + daily_wages + "','" + rev_stamp + "','" + txtstump.Text + "','" + Locations + "','" + company_Id + "','" + _chkbasic + "','" + _chkALK + "','" + _chkHide + "','" + strMOD + "','" + strWD + "','" + pt_basis + "','" + no_round + "','" + limit_day + "','" + ldays + "','" + alt_mon + "'," + lvless + "," + gs + ",1,'" + _chkFlag + "','" + _chkNC + "')";
                else
                    ss = "insert into tbl_Employee_Assign_SalStructure(P_TYPE,SESSION,SAL_STRUCT,SAL_HEAD,V_FROM,V_TO,C_BASIS,C_TYPE,C_DET,PF_PER,PF_VOL,ESI_PER,PT,ROUND_TYPE,TDSREFNO,"+
       "TDS_EXEMPT,CARRY,TDS_EXTRAPOL,REMARKS,atten_day,Proxy_day,Daily_wages,Revenue_Stamp,Stamp_Amount,Location_id,Company_id,EMP_BASIC,chkALK,chkHide,mod,wd,pt_basis,[no_round], [limit_day], [ldays],[alt_mon],lvless,gs,lock,chkFlag,NCompliance) values('" + sal_head(salhead[0].Trim()) + "', '" + cmbYear.Text.Trim() + "', " + get_SalStructID(cmbsalstruc.Text.Trim()) + ", " + get_sal_head_ID(salhead[0].Trim()) + ", '" + cmbvfrom.Text.Trim() + "', '" + cmbvto.Text.Trim() + "', '" + cmbcbasis.Text.Trim() + "', '" + cmbctype.Text.Trim() + "', " + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ", 0 , 0, '1' , 0, '" + cmbroundoff.Text.Trim() + "',0,0,0,0, '" + txtremarks.Text.Trim() + "','" + att_day + "','" + ove_time + "','" + daily_wages + "','" + rev_stamp + "','" + txtstump.Text + "','" + Locations + "','" + company_Id + "','" + _chkbasic + "','" + _chkALK + "','" + _chkHide + "','" + strMOD + "','" + strWD + "','" + pt_basis + "','" + no_round + "','" + limit_day + "','" + ldays + "','" + alt_mon + "'," + lvless + "," + gs + ",1,'" + _chkFlag + "','" + _chkNC + "')";
                st = clsDataAccess.RunNQwithStatus(ss);
            }
            else if (chkpf.Checked && !chkesi.Checked)
            {
                if (chkpt.Checked)
                    ss = "insert into tbl_Employee_Assign_SalStructure(P_TYPE,SESSION,SAL_STRUCT,SAL_HEAD,V_FROM,V_TO,C_BASIS,C_TYPE,C_DET,PF_PER,PF_VOL,ESI_PER,PT,ROUND_TYPE,TDSREFNO,"+
       "TDS_EXEMPT,CARRY,TDS_EXTRAPOL,REMARKS,atten_day,Proxy_day,Daily_wages,Revenue_Stamp,Stamp_Amount,Location_id,Company_id,EMP_BASIC,chkALK,chkHide,mod,wd,pt_basis,[no_round], [limit_day], [ldays],[alt_mon],lvless,gs,lock,chkFlag,NCompliance) values('" + sal_head(salhead[0].Trim()) + "', '" + cmbYear.Text.Trim() + "', " + get_SalStructID(cmbsalstruc.Text.Trim()) + ", " + get_sal_head_ID(salhead[0].Trim()) + ", '" + cmbvfrom.Text.Trim() + "', '" + cmbvto.Text.Trim() + "', '" + cmbcbasis.Text.Trim() + "', '" + cmbctype.Text.Trim() + "', " + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ", '1' , 0, 0 , 1, '" + cmbroundoff.Text.Trim() + "',0,0,0,0, '" + txtremarks.Text.Trim() + "','" + att_day + "','" + ove_time + "','" + daily_wages + "','" + rev_stamp + "','" + txtstump.Text + "','" + Locations + "','" + company_Id + "','" + _chkbasic + "','" + _chkALK + "','" + _chkHide + "','" + strMOD + "','" + strWD + "','" + pt_basis + "','" + no_round + "','" + limit_day + "','" + ldays + "','" + alt_mon + "'," + lvless + "," + gs + ",1,'" + _chkFlag + "','" + _chkNC + "')";
                else
                    ss = "insert into tbl_Employee_Assign_SalStructure(P_TYPE,SESSION,SAL_STRUCT,SAL_HEAD,V_FROM,V_TO,C_BASIS,C_TYPE,C_DET,PF_PER,PF_VOL,ESI_PER,PT,ROUND_TYPE,TDSREFNO,"+
       "TDS_EXEMPT,CARRY,TDS_EXTRAPOL,REMARKS,atten_day,Proxy_day,Daily_wages,Revenue_Stamp,Stamp_Amount,Location_id,Company_id,EMP_BASIC,chkALK,chkHide,mod,wd,pt_basis,[no_round], [limit_day], [ldays],[alt_mon],lvless,gs,lock,chkFlag,NCompliance) values('" + sal_head(salhead[0].Trim()) + "', '" + cmbYear.Text.Trim() + "', " + get_SalStructID(cmbsalstruc.Text.Trim()) + ", " + get_sal_head_ID(salhead[0].Trim()) + ", '" + cmbvfrom.Text.Trim() + "', '" + cmbvto.Text.Trim() + "', '" + cmbcbasis.Text.Trim() + "', '" + cmbctype.Text.Trim() + "', " + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ", '1' , 0, 0 , 0, '" + cmbroundoff.Text.Trim() + "',0,0,0,0, '" + txtremarks.Text.Trim() + "','" + att_day + "','" + ove_time + "','" + daily_wages + "','" + rev_stamp + "','" + txtstump.Text + "','" + Locations + "','" + company_Id + "','" + _chkbasic + "','" + _chkALK + "','" + _chkHide + "','" + strMOD + "','" + strWD + "','" + pt_basis + "','" + no_round + "','" + limit_day + "','" + ldays + "','" + alt_mon + "'," + lvless + "," + gs + ",1,'" + _chkFlag + "','" + _chkNC + "')";
                st = clsDataAccess.RunNQwithStatus(ss);
            }
            else if (!chkpf.Checked && !chkesi.Checked)
            {
                if (chkpt.Checked)
                    ss = "insert into tbl_Employee_Assign_SalStructure(P_TYPE,SESSION,SAL_STRUCT,SAL_HEAD,V_FROM,V_TO,C_BASIS,C_TYPE,C_DET,PF_PER,PF_VOL,ESI_PER,PT,ROUND_TYPE,TDSREFNO,"+
       "TDS_EXEMPT,CARRY,TDS_EXTRAPOL,REMARKS,atten_day,Proxy_day,Daily_wages,Revenue_Stamp,Stamp_Amount,Location_id,Company_id,EMP_BASIC,chkALK,chkHide,mod,wd,pt_basis,[no_round], [limit_day], [ldays],[alt_mon],lvless,gs,lock,chkFlag,NCompliance) values('" + sal_head(salhead[0].Trim()) + "', '" + cmbYear.Text.Trim() + "', " + get_SalStructID(cmbsalstruc.Text.Trim()) + ", " + get_sal_head_ID(salhead[0].Trim()) + ", '" + cmbvfrom.Text.Trim() + "', '" + cmbvto.Text.Trim() + "', '" + cmbcbasis.Text.Trim() + "', '" + cmbctype.Text.Trim() + "', " + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ", 0 , 0, 0 , 1, '" + cmbroundoff.Text.Trim() + "',0,0,0,0, '" + txtremarks.Text.Trim() + "','" + att_day + "','" + ove_time + "','" + daily_wages + "','" + rev_stamp + "','" + txtstump.Text + "','" + Locations + "','" + company_Id + "','" + _chkbasic + "','" + _chkALK + "','" + _chkHide + "','" + strMOD + "','" + strWD + "','" + pt_basis + "','" + no_round + "','" + limit_day + "','" + ldays + "','" + alt_mon + "'," + lvless + "," + gs + ",1,'" + _chkFlag + "','" + _chkNC + "')";
                else
                    ss = "insert into tbl_Employee_Assign_SalStructure(P_TYPE,SESSION,SAL_STRUCT,SAL_HEAD,V_FROM,V_TO,C_BASIS,C_TYPE,C_DET,PF_PER,PF_VOL,ESI_PER,PT,ROUND_TYPE,TDSREFNO,"+
       "TDS_EXEMPT,CARRY,TDS_EXTRAPOL,REMARKS,atten_day,Proxy_day,Daily_wages,Revenue_Stamp,Stamp_Amount,Location_id,Company_id,EMP_BASIC,chkALK,chkHide,mod,wd,pt_basis,[no_round], [limit_day], [ldays],[alt_mon],lvless,gs,lock,chkFlag,NCompliance) values('" + sal_head(salhead[0].Trim()) + "', '" + cmbYear.Text.Trim() + "', " + get_SalStructID(cmbsalstruc.Text.Trim()) + ", " + get_sal_head_ID(salhead[0].Trim()) + ", '" + cmbvfrom.Text.Trim() + "', '" + cmbvto.Text.Trim() + "', '" + cmbcbasis.Text.Trim() + "', '" + cmbctype.Text.Trim() + "', " + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ", 0 , 0, 0 , 0, '" + cmbroundoff.Text.Trim() + "',0,0,0,0, '" + txtremarks.Text.Trim() + "','" + att_day + "','" + ove_time + "','" + daily_wages + "','" + rev_stamp + "','" + txtstump.Text + "','" + Locations + "','" + company_Id + "','" + _chkbasic + "','" + _chkALK + "','" + _chkHide + "','" + strMOD + "','" + strWD + "','" + pt_basis + "','" + no_round + "','" + limit_day + "','" + ldays + "','" + alt_mon + "'," + lvless + "," + gs + ",1,'" + _chkFlag + "','" + _chkNC + "')";
                //25.02.15 (Serial No Identity true)
                //ss = "insert into tbl_Employee_Assign_SalStructure values(" + get_sl() + ",'" + sal_head(cmbsalhead.Text.Trim()) + "', '" + cmbYear.Text.Trim() + "', " + get_SalStructID(cmbsalstruc.Text.Trim()) + ", " + get_sal_head_ID(cmbsalhead.Text.Trim()) + ", '" + cmbvfrom.Text.Trim() + "', '" + cmbvto.Text.Trim() + "', '" + cmbcbasis.Text.Trim() + "', '" + cmbctype.Text.Trim() + "', " + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ", 0 , 0, 0 , 0, '" + cmbroundoff.Text.Trim() + "',0,0,0,0, '" + txtremarks.Text.Trim() + "')";
                st = clsDataAccess.RunNQwithStatus(ss);
            }



            //bool st = clsDataAccess.RunNQwithStatus(ss);
            if (st)
            {
                ERPMessageBox.ERPMessage.Show("Data Saved Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                get_ass();
                clea_all();
            }
        }
        public char sal_head(string head)
        {
            string s = "";
            char pb = ' ';
            DataTable dt1 = new DataTable();

            s = "select SalaryHead_Short from tbl_Employee_ErnSalaryHead";
            dt1 = clsDataAccess.RunQDTbl(s);
            if (dt1.Rows.Count > 0)
            {
                for (int f = 0; f < dt1.Rows.Count; f++)
                {
                    if (dt1.Rows[f][0].ToString().Trim() == head)
                        pb = 'E';
                }

            }

            dt1.Clear();
            dt1.Columns.Clear();
            s = "select SalaryHead_Short from tbl_Employee_DeductionSalayHead";
            dt1 = clsDataAccess.RunQDTbl(s);
            if (dt1.Rows.Count > 0)
            {
                for (int f = 0; f < dt1.Rows.Count; f++)
                {
                    if (dt1.Rows[f][0].ToString().Trim() == head)
                        pb = 'D';
                }

            }
            dt1.Clear();
            dt1.Columns.Clear();
            s = "select shortname from tbl_Employee_Config_PFHeads";
            dt1 = clsDataAccess.RunQDTbl(s);
            if (dt1.Rows.Count > 0)
            {
                for (int f = 0; f < dt1.Rows.Count; f++)
                {
                    if (dt1.Rows[f][0].ToString().Trim() == head)
                        pb = 'D';
                }

            }

            return pb;

        }
        public void get_ass()
        {
            sl_no = 0;
            dt_ass.Clear();
            dt_ass.Columns.Clear();
            hsg_ass_head_sal_struc.Clear();

            DataColumn[] dc25 = new DataColumn[] { dc1, dc2, dc3, dc4, dc5, dc6, dc7, dc8, dc9, dc10, dc11, dc12, dc13, dc14, dc15, dc16, dc17, dc18, dc19, dc20, dc21, dc22, dc24, dc26, dc27, dc28, dc29, dc30, dc31, dc33, dc34, dc35, dc32, dc23, dc36, dc37, dc38, dc39, dc40, dc41, dc42, dc43 };//, dc32
            dt_ass.Columns.AddRange(dc25);
            string s = "";
            s = "select P_TYPE,SESSION,SAL_STRUCT,SAL_HEAD,V_FROM,V_TO,C_BASIS,C_TYPE,C_DET,PF_PER,PF_VOL,ESI_PER,PT,ROUND_TYPE,TDSREFNO,TDS_EXEMPT,CARRY,TDS_EXTRAPOL,REMARKS,SLNO,atten_day,Proxy_day,Daily_wages,Revenue_Stamp,Stamp_Amount,EMP_BASIC,chkALK,chkHide,mod,wd,pt_basis,[no_round],[limit_day],[ldays],[alt_mon],[lvless],[GS],[chkFlag],NCompliance from tbl_Employee_Assign_SalStructure where sal_struct=" + get_SalStructID(cmbsalstruc.Text.Trim()) + "";// and session='" + cmbYear.Text.Trim() + "'";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {

                for (int y = 0; y < dt.Rows.Count; y++)
                {

                    if (dt.Rows[y][0].ToString().Trim() == "E")
                    {
                        dr = dt_ass.NewRow();
                        dr[0] = "Earnings";
                        dr[1] = get_sal_head_name(Convert.ToInt32(dt.Rows[y][3]), "E");
                        dr[2] = sal_Head_Name('E', get_sal_head_name(Convert.ToInt32(dt.Rows[y][3]), "E"));
                        dr[3] = dt.Rows[y][4].ToString() + "/" + dt.Rows[y][1].ToString();
                        dr[4] = dt.Rows[y][5].ToString() + "/" + dt.Rows[y][1].ToString();
                        dr[5] = dt.Rows[y][6].ToString();
                        dr[6] = dt.Rows[y][7].ToString();
                        dr[7] = get_OtherName(dt.Rows[y][7].ToString(), Convert.ToInt32(dt.Rows[y][8]));
                        if (Convert.ToInt32(dt.Rows[y][9]) == 0)
                        {
                            dr[8] = "NO";
                            dr[9] = "";
                        }
                        else
                        {
                            dr[8] = "YES";
                            dr[9] = dt.Rows[y][9].ToString();
                        }

                        if (Convert.ToInt32(dt.Rows[y][10]) == 0)
                            dr[10] = "NO";
                        else
                            dr[10] = "YES";



                        if (Convert.ToInt32(dt.Rows[y][11]) == 0)
                        {
                            dr[11] = "NO";
                            dr[12] = "";
                        }
                        else
                        {
                            dr[11] = "YES";
                            dr[12] = dt.Rows[y][11].ToString();
                        }
                        if (Convert.ToInt32(dt.Rows[y][12]) == 0)
                            dr[13] = "NO";
                        else
                            dr[13] = "YES";
                        if (dt.Rows[y][13].ToString() == "")
                        {
                            dr[14] = "NO";
                            dr[15] = dt.Rows[y][13].ToString();
                        }
                        else
                        {
                            dr[14] = "YES";
                            dr[15] = dt.Rows[y][13].ToString();
                        }
                        dr[21] = dt.Rows[y][18].ToString();
                        dr[22] = dt.Rows[y][19].ToString();

                        if (Convert.ToInt32(dt.Rows[y]["atten_day"]) == 0)
                            dr[23] = "NO";
                        else
                            dr[23] = "YES";

                        if (Convert.ToInt32(dt.Rows[y]["Proxy_day"]) == 0)
                            dr[24] = "NO";
                        else if (Convert.ToInt32(dt.Rows[y]["Proxy_day"]) == 2)
                            dr[24] = "ED";
                        else
                            dr[24] = "YES";


                        
                        /* Wday
                               OT
                               TDays
                               ED */
                        if (Convert.ToInt32(dt.Rows[y]["Daily_wages"]) == 0)
                            dr[25] = "NO";
                        else if (Convert.ToInt32(dt.Rows[y]["Daily_wages"]) == 2)
                            dr[25] = "HR";
                        else if (Convert.ToInt32(dt.Rows[y]["Daily_wages"]) == 3)
                            dr[25] = "cWD";
                        else if (Convert.ToInt32(dt.Rows[y]["Daily_wages"]) == 11)
                            dr[25] = "OT";
                        else if (Convert.ToInt32(dt.Rows[y]["Daily_wages"]) == 12)
                            dr[25] = "TDays";
                        else if (Convert.ToInt32(dt.Rows[y]["Daily_wages"]) == 13)
                            dr[25] = "ED";
                        else if (Convert.ToInt32(dt.Rows[y]["Daily_wages"]) == 14)
                            dr[25] = "Config";
                        else
                            dr[25] = "YES";

                        if (Convert.ToInt32(dt.Rows[y]["EMP_BASIC"]) == 0)
                            dr[28] = "0";
                        else if (Convert.ToInt32(dt.Rows[y]["EMP_BASIC"]) == 1)
                            dr[28] = "1";
                        else if (Convert.ToInt32(dt.Rows[y]["EMP_BASIC"]) == 2)
                            dr[28] = "2";
                        else if (Convert.ToInt32(dt.Rows[y]["EMP_BASIC"]) == 3)
                            dr[28] = "3";
                        else if (Convert.ToInt32(dt.Rows[y]["EMP_BASIC"]) == 4)
                            dr[28] = "4";
                        else if (Convert.ToInt32(dt.Rows[y]["EMP_BASIC"]) == 5)
                            dr[28] = "5";
                        //if (Convert.ToInt32(dt.Rows[y]["EMP_SAL"]) == 0)
                        //    dr[29] = "NO";
                        //else
                        //    dr[29] = "YES";

                        if (Convert.ToInt32(dt.Rows[y]["chkALK"]) == 0)
                            dr[29] = "0";
                        else if (Convert.ToInt32(dt.Rows[y]["chkALK"]) == 1)
                            dr[29] = "1";
                        else if (Convert.ToInt32(dt.Rows[y]["chkALK"]) == 2)
                            dr[29] = "2";
                        else if (Convert.ToInt32(dt.Rows[y]["chkALK"]) == 3)
                            dr[29] = "3";
                        else if (Convert.ToInt32(dt.Rows[y]["chkALK"]) == 6)
                            dr[29] = "6";
                        else if (Convert.ToInt32(dt.Rows[y]["chkALK"]) == 7)
                            dr[29] = "7";

                        if (Convert.ToInt32(dt.Rows[y]["chkHide"]) == 1)
                            dr[30] = "1";
                        else if (Convert.ToInt32(dt.Rows[y]["chkHide"]) == 2)
                            dr[30] = "2";
                        else if (Convert.ToInt32(dt.Rows[y]["chkHide"]) == 3)
                            dr[30] = "3";
                        else if (Convert.ToInt32(dt.Rows[y]["chkHide"]) == 31)
                            dr[30] = "31";
                        else
                            dr[30] = "0";

                        dr[31] = dt.Rows[y]["mod"].ToString().Trim();
                        dr[32] = dt.Rows[y]["wd"].ToString().Trim();
                        dr[33] = dt.Rows[y]["pt_basis"].ToString().Trim();

                        //no_round],[limit_day],[ldays
                        dr[34] = dt.Rows[y]["no_round"].ToString().Trim();
                        dr[35] = dt.Rows[y]["limit_day"].ToString().Trim();
                        dr[36] = dt.Rows[y]["ldays"].ToString().Trim();
                        dr[37] = dt.Rows[y]["alt_mon"].ToString().Trim();
                        dr[38] = dt.Rows[y]["lvless"].ToString().Trim();
                        dr[39] = dt.Rows[y]["GS"].ToString().Trim();
                        dr[40] = dt.Rows[y]["chkFlag"].ToString().Trim();
                        dr[41] = dt.Rows[y]["NCompliance"].ToString().Trim();
                        dt_ass.Rows.Add(dr);
                        if (!hsg_ass_head_sal_struc.ContainsKey(dt.Rows[y][0].ToString().Trim() + "/" + dt.Rows[y][1].ToString() + "/" + dt.Rows[y][2].ToString() + "/" + dt.Rows[y][3].ToString() + "/" + dt.Rows[y][4].ToString() + "/" + dt.Rows[y][5].ToString()))
                            //time
                            /////////hsg_ass_head_sal_struc.Add(dt.Rows[y][1].ToString() + "/" + dt.Rows[y][2].ToString() + "/" + dt.Rows[y][3].ToString() + "/" + dt.Rows[y][4].ToString() + "/" + dt.Rows[y][5].ToString(),dt.Rows[y]["SLNO"].ToString());
                            hsg_ass_head_sal_struc.Add(dt.Rows[y][0].ToString().Trim() + "/" + dt.Rows[y][1].ToString() + "/" + dt.Rows[y][2].ToString() + "/" + dt.Rows[y][3].ToString() + "/" + dt.Rows[y][4].ToString() + "/" + dt.Rows[y][5].ToString(), dt.Rows[y]["SLNO"].ToString());


                    }
                }
                dr = dt_ass.NewRow();
                dt_ass.Rows.Add(dr);
                for (int z = 0; z < dt.Rows.Count; z++)
                {

                    if (dt.Rows[z][0].ToString().Trim() == "D")
                    {
                        dr = dt_ass.NewRow();
                        dr[0] = "Deductions";
                        dr[1] = get_sal_head_name(Convert.ToInt32(dt.Rows[z][3]), "D");//dt.Rows[z][3].ToString();
                        dr[2] = sal_Head_Name('D', get_sal_head_name(Convert.ToInt32(dt.Rows[z][3]), "D"));
                        dr[3] = dt.Rows[z][4].ToString() + "/" + dt.Rows[z][1].ToString();
                        dr[4] = dt.Rows[z][5].ToString() + "/" + dt.Rows[z][1].ToString();
                        dr[5] = dt.Rows[z][6].ToString();
                        dr[6] = dt.Rows[z][7].ToString();
                        dr[7] = get_OtherName(dt.Rows[z][7].ToString(), Convert.ToInt32(dt.Rows[z][8]));//dt.Rows[z][8].ToString();
                        if (Convert.ToInt32(dt.Rows[z][9]) == 0)
                        {
                            dr[8] = "NO";
                            dr[9] = "";
                        }
                        else
                        {
                            dr[8] = "YES";
                            dr[9] = dt.Rows[z][9].ToString();
                        }
                        if (Convert.ToInt32(dt.Rows[z][10]) == 0)
                            dr[10] = "NO";
                        else
                            dr[10] = "YES";

                        if (Convert.ToInt32(dt.Rows[z][11]) == 0)
                        {
                            dr[11] = "NO";
                            dr[12] = "";
                        }
                        else
                        {
                            dr[11] = "YES";
                            dr[12] = dt.Rows[z][11].ToString();
                        }
                        if (Convert.ToInt32(dt.Rows[z][12]) == 0)
                            dr[13] = "NO";
                        else
                            dr[13] = "YES";
                        if (dt.Rows[z][13].ToString() == "")
                        {
                            dr[14] = "NO";
                            dr[15] = dt.Rows[z][13].ToString();
                        }
                        else
                        {
                            dr[14] = "YES";
                            dr[15] = dt.Rows[z][13].ToString();
                        }

                        dr[21] = dt.Rows[z][18].ToString();
                        dr[22] = dt.Rows[z][19].ToString();

                        if (Convert.ToInt32(dt.Rows[z]["atten_day"]) == 0)
                            dr[23] = "NO";
                        else
                            dr[23] = "YES";

                        if (Convert.ToInt32(dt.Rows[z]["Proxy_day"]) == 0)
                            dr[24] = "NO";
                        else
                            dr[24] = "YES";

                        //if (Convert.ToInt32(dt.Rows[z]["Daily_wages"]) == 0)
                        //    dr[25] = "NO";
                        //else if (Convert.ToInt32(dt.Rows[z]["Daily_wages"]) == 2)
                        //    dr[25] = "HR";
                        //else if (Convert.ToInt32(dt.Rows[z]["Daily_wages"]) == 3)
                        //    dr[25] = "cWD";
                        //else
                        //    dr[25] = "YES";


                        if (Convert.ToInt32(dt.Rows[z]["Daily_wages"]) == 0)
                            dr[25] = "NO";
                        else if (Convert.ToInt32(dt.Rows[z]["Daily_wages"]) == 2)
                            dr[25] = "HR";
                        else if (Convert.ToInt32(dt.Rows[z]["Daily_wages"]) == 3)
                            dr[25] = "cWD";
                        else if (Convert.ToInt32(dt.Rows[z]["Daily_wages"]) == 11)
                            dr[25] = "OT";
                        else if (Convert.ToInt32(dt.Rows[z]["Daily_wages"]) == 12)
                            dr[25] = "TDays";
                        else if (Convert.ToInt32(dt.Rows[z]["Daily_wages"]) == 13)
                            dr[25] = "ED";
                        else
                            dr[25] = "YES";


                        if (Convert.ToInt32(dt.Rows[z]["Revenue_Stamp"]) == 0)
                            dr[26] = "NO";
                        else
                            dr[26] = "YES";

                        dr[27] = Convert.ToString(dt.Rows[z]["Stamp_Amount"]);

                        if (Convert.ToInt32(dt.Rows[z]["EMP_BASIC"]) == 0)
                            dr[28] = "0";
                        else if (Convert.ToInt32(dt.Rows[z]["EMP_BASIC"]) == 1)
                            dr[28] = "1";
                        else if (Convert.ToInt32(dt.Rows[z]["EMP_BASIC"]) == 2)
                            dr[28] = "2";
                        else if (Convert.ToInt32(dt.Rows[z]["EMP_BASIC"]) == 3)
                            dr[28] = "3";
                        else if (Convert.ToInt32(dt.Rows[z]["EMP_BASIC"]) == 4)
                            dr[28] = "4";
                        else if (Convert.ToInt32(dt.Rows[z]["EMP_BASIC"]) == 5)
                            dr[28] = "5";

                        if (Convert.ToInt32(dt.Rows[z]["chkALK"]) == 0)
                            dr[29] = "0";
                        else if (Convert.ToInt32(dt.Rows[z]["chkALK"]) == 1)
                            dr[29] = "1";
                        else if (Convert.ToInt32(dt.Rows[z]["chkALK"]) == 2)
                            dr[29] = "2";
                        else if (Convert.ToInt32(dt.Rows[z]["chkALK"]) == 3)
                            dr[29] = "3";

                        if (Convert.ToInt32(dt.Rows[z]["chkHide"]) == 1)
                            dr[30] = "1";
                        else if (Convert.ToInt32(dt.Rows[z]["chkHide"]) == 2)
                            dr[30] = "2";
                        else if (Convert.ToInt32(dt.Rows[z]["chkHide"]) == 3)// effect after ded
                            dr[30] = "3";
                        else if (Convert.ToInt32(dt.Rows[z]["chkHide"]) == 31) //effect after ded and hide
                            dr[30] = "31";
                        else
                            dr[30] = "0";

                        dr[31] = dt.Rows[z]["mod"].ToString().Trim();
                        dr[32] = dt.Rows[z]["wd"].ToString().Trim();
                        dr[33] = dt.Rows[z]["pt_basis"].ToString().Trim();

                        dr[34] = dt.Rows[z]["no_round"].ToString().Trim();
                        dr[35] = dt.Rows[z]["limit_day"].ToString().Trim();
                        dr[36] = dt.Rows[z]["ldays"].ToString().Trim();

                        dr[37] = dt.Rows[z]["alt_mon"].ToString().Trim();
                        dr[38] = dt.Rows[z]["lvless"].ToString().Trim();
                        dr[39] = dt.Rows[z]["GS"].ToString().Trim();
                        dr[40] = dt.Rows[z]["chkFlag"].ToString().Trim();
                        dr[41] = dt.Rows[z]["NCompliance"].ToString().Trim();
                        dt_ass.Rows.Add(dr);
                        if (!hsg_ass_head_sal_struc.ContainsKey(dt.Rows[z][0].ToString().Trim() + "/" + dt.Rows[z][1].ToString() + "/" + dt.Rows[z][2].ToString() + "/" + dt.Rows[z][3].ToString() + "/" + dt.Rows[z][4].ToString() + "/" + dt.Rows[z][5].ToString()))
                            //time
                            /////////hsg_ass_head_sal_struc.Add(dt.Rows[z][1].ToString() + "/" + dt.Rows[z][2].ToString() + "/" + dt.Rows[z][3].ToString() + "/" + dt.Rows[z][4].ToString() + "/" + dt.Rows[z][5].ToString(), dt.Rows[z]["SLNO"].ToString());
                            hsg_ass_head_sal_struc.Add(dt.Rows[z][0].ToString().Trim() + "/" + dt.Rows[z][1].ToString() + "/" + dt.Rows[z][2].ToString() + "/" + dt.Rows[z][3].ToString() + "/" + dt.Rows[z][4].ToString() + "/" + dt.Rows[z][5].ToString(), dt.Rows[z]["SLNO"].ToString());



                    }

                }
                dgvfmula.DataSource = "";
                dgvfmula.DataSource = dt_ass;
                for (int col_ind = 0; col_ind < dgvfmula.Columns.Count; col_ind++)
                {
                    if (col_ind >= 8)
                    {
                        dgvfmula.Columns[col_ind].Visible = false;
                    }
                }

            }

        }

        private void cmbsalstruc_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                get_ass();
            }
            catch (Exception x) { }
        }
        public string sal_Head_Name(char type, string head)
        {
            string res = "";
            hide_settings();
            if (type == 'E')
            {
                chkGrossAs.Enabled = true;
                chkEmpAmt.Visible = true;
                //chkEmpAmt.Checked = false;
                grp_add_opt.Visible = true;
                //lblMsg2.Visible = true; lbl_msg_addopt.Visible = true;
                //---------------------------------
                grp_other_mode.Visible = true;// lblMsg3.Visible = true;
                //---------------------------------
                pnl_joining.Visible = true;

                string s = "select salaryhead_full,gs,nocpl from tbl_Employee_ErnSalaryHead where (salaryhead_short='" + head + "')";
                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                {
                    res = dts.Rows[0][0].ToString();


                    if (dts.Rows[0][0].ToString().Trim()=="0")
                         chkGrossAs.Checked = false;
                    else chkGrossAs.Checked = true;


                    if ((dts.Rows[0]["nocpl"].ToString().Trim() == "1") && (Convert.ToInt32(clsDataAccess.ReturnValue("select count(*)cnt from Companywiseid_Relation where (nocpl=1) and (Location_ID=" + Locations.ToString().Trim() + ")")) != 0))
                    {
                        chkNC.Checked = true; chkShowAfterNet.Checked = true;

                    }
                    else
                    {

                        if (chkNC.Checked != true)
                        {
                            chkNC.Checked = false;
                        }
                        
                        chkShowAfterNet.Checked = false;

                    }

                }
            }
            else if (type == 'D')
            {
                chkEmpAmt.Visible = true;
                string s = "select salaryhead_full,nocpl from tbl_Employee_DeductionSalayHead where (salaryhead_short='" + head + "')";

                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                {
                    res = dts.Rows[0][0].ToString();

                    if ((dts.Rows[0]["nocpl"].ToString().Trim() == "1") && (Convert.ToInt32(clsDataAccess.ReturnValue("select count(*)cnt from Companywiseid_Relation where (nocpl=1) and (Location_ID=" + Locations.ToString().Trim() + ")")) != 0))
                    {
                        chkNC.Checked = true; chkShowAfterNet.Checked = true;

                    }
                    else
                    {
                        chkNC.Checked = false; chkShowAfterNet.Checked = false;

                    }
                }

                chkGrossAs.Enabled = false;
                chkGrossAs.Checked = false;
                //grp_add_opt.Visible = true;

                cheattendence.Visible = true;
                chkPerHour.Visible = true;
                grp_deduct.Visible = true;
                
                //lbl_deduct_msg.Visible = true;
                //---------------------------------
                   grp_other_mode.Visible = true; //lblMsg3.Visible = true;

                //if (res == "")
                //{
                //    s = "select pfhead from tbl_Employee_Config_PFHeads where shortname='" + head + "'";
                //    dts = clsDataAccess.RunQDTbl(s);
                //    if (dts.Rows.Count > 0)
                //        res = dts.Rows[0][0].ToString();

                //}
            }

            return res;
        }
        private void ResetAllChkBox()
        {
            this.chkpt.Checked = false;
            this.chkesi.Checked = false;
            this.chkpf.Checked = false;
            this.chkLoan.Checked = false;
            this.chkAdvance.Checked = false;
            this.chkKit.Checked = false;
            this.cheattendence.Checked = false;
            this.cheattendence.Enabled = true;
            this.chedailywages.Checked = false;
            this.chedailywages.Enabled = true;
            this.cheovertime.Checked = false;
            chkED.Checked = false;
            chkED.Enabled = true;
            this.cheovertime.Enabled = true;
            chkED.Enabled = true;
            chkED.Checked = false;
            chkAfterDeductionEffect.Checked = false;
            chkAfterDeductionEffect.Enabled = true;
            this.chkHide.Checked = false;
            this.chkHide.Enabled = true;
            this.cbOtherOption.Checked = false;
            this.chkOtherWD.Checked = false;

            chkPerHour.Checked = false;
            cmboth.Enabled = true;
        }
        private void cmbsalhead_SelectedValueChanged(object sender, EventArgs e)
        {
            lbl_salHead_type.Text = "";
            lbl_salHead_id.Text = "";
            
            string[] salhead = cmbsalhead.Text.Trim().ToString().Split('-');
            if (salhead.Length==1)
            {
                ResetAllChkBox();
                return;
            }
            lbl_salHead_type.Text = salhead[1].ToString().Trim();
            try
            {
                if (lbl_salHead_type.Text.Trim() == "E")
                {
                    txtfull_name.Text = sal_Head_Name('E', salhead[0].ToString().Trim());
                    chkGrossAdd.Checked = false;
                }
                else
                {
                    txtfull_name.Text = sal_Head_Name('D', salhead[0].ToString().Trim());
                    chkGrossAdd.Checked = false;
                }
                //txtfull_name.Text = sal_Head_Name('E', cmbsalhead.Text.Trim());
                //if (txtfull_name.Text == "")
                //{
                //    txtfull_name.Text = sal_Head_Name('D', cmbsalhead.Text.Trim());
                //    chkGrossAdd.Checked = false;
                //}
                //else
                //{
                //    chkGrossAdd.Checked = false;
                //}
            }
            catch (Exception x) { }

            try
            {
                ResetAllChkBox();
                if (salhead[0].ToString().Trim().ToUpper() == "PF")
                {
                    chkpf.Checked = true;
                    cmbctype.SelectedItem= "FORMULA";
                }
                if (salhead[0].ToString().Trim().ToUpper() == "ESI")
                {
                    this.chkesi.Checked = true;
                    cmbctype.SelectedItem = "FORMULA";
                }
                if (salhead[0].ToString().Trim().ToUpper() == "P.TAX" || salhead[0].ToString().Trim().ToUpper() == "PTAX")
                {
                    this.chkpt.Checked = true;
                    cmbctype.SelectedItem = "COMPANY LUMPSUM";
                    cmboth.Enabled = false;
                }
                if (salhead[0].ToString().Trim().ToUpper() == "LOAN")
                {
                    this.chkLoan.Checked = true;
                    cmbctype.SelectedItem = "COMPANY LUMPSUM";
                    cmboth.Enabled = false;
                }
                if (salhead[0].ToString().Trim().ToUpper() == "ADV")
                {
                    this.chkAdvance.Checked = true;
                    cmbctype.SelectedItem = "COMPANY LUMPSUM";
                    cmboth.Enabled = false;
                }
                if (salhead[0].ToString().Trim().ToUpper() == "FINE")
                {
                    this.chkFine.Checked = true;
                    cmbctype.SelectedItem = "COMPANY LUMPSUM";
                    cmboth.Enabled = false;
                }
                if (salhead[0].ToString().Trim().ToUpper() == "KIT" || salhead[0].ToString().Trim().ToUpper() == "KT" || salhead[0].ToString().Trim().ToUpper() == "KITS" || salhead[0].ToString().Trim().ToUpper() == "UNIFORM")
                {
                    this.chkKit.Checked = true;
                    cmbctype.SelectedItem = "COMPANY LUMPSUM";
                    cmboth.Enabled = false;
                }
                if (salhead[0].ToString().Trim().ToUpper() == "BS")
                {
                    cheattendence.Checked = true;
                    cheovertime.Enabled = false;
                    chkED.Enabled = false;
                    chkED.Checked = false;
                    chkHide.Enabled = false;
                }
                if (salhead[0].ToString().Trim().ToUpper() == "OTA" || salhead[0].ToString().Trim().ToUpper() == "OT")
                {
                    cheovertime.Checked = true;
                    chkED.Checked = false;
                    cheattendence.Enabled = true;
                    chedailywages.Enabled = true;
                    chkGrossAdd.Checked = false;

                }
                if (salhead[0].ToString().Trim().ToUpper() == "SOCIETY" || salhead[0].ToString().Trim().ToUpper() == "SOC")
                {
                    cheattendence.Checked = false;
                    cheovertime.Enabled = false;
                    chkED.Enabled = false;
                    chkED.Checked = false;
                    chkHide.Enabled = false;
                    chkAtten_WD.Checked = false;
                    chkSociety.Checked = true;

                }

                if (salhead[0].ToString().Trim().ToUpper() == "ED" || salhead[0].ToString().Trim().ToUpper() == "ED")
                {
                    cheovertime.Checked =false;
                    chkED.Checked = true;
                    cheattendence.Enabled = true;
                    chedailywages.Enabled = true;
                    chkED.Enabled = true;

                }

                cmbcbasis.SelectedItem = "Independent";
            }
            catch { }
        }

        private void chkroundoff_Click(object sender, EventArgs e)
        {
            if (chkroundoff.Checked)
            { cmbroundoff.Enabled = true; chkNetRoff.Checked = true; }
            else
            { cmbroundoff.Enabled = false; chkNetRoff.Checked = false; }
        }

        private void cmbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    get_ass();
            //}
            //catch (Exception x) { }
        }

        private void dgvfmula_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sl_no = 0;
                txtfull_name.Enabled = true;
                cmbvfrom.Enabled = true;
                cmbvto.Enabled = true;
                cmbcbasis.Enabled = true;
                //btncalcbs.Enabled = true;
                cmbctype.Enabled = true;
                cmboth.Enabled = true;
                btnfmula.Enabled = true;
                txtremarks.Enabled = true;
                txtpf.Enabled = true;
                chkpf.Enabled = true;
                chkroundoff.Enabled = true;
                chkpt.Enabled = true;
                chkesi.Enabled = true;
                chestump.Enabled = true;
                chkFlag.Enabled = true;
                chkMinDays.Checked = false;
                chkActiveMonths.Checked = false;
                chkAtten_WD.Checked = false;
                txtlessLv.Text = "0";
                txtlessLv.Visible = false;
                chkShowAfterNet.Checked = false;
                chkFlag.Checked = false;
                //=========================================
                ChkEmpBasic.Checked = false;
                ChkEmpSal.Checked = false;
                chkEmpBsTs.Checked = false;
                chkGrossAdd.Checked = false;
                chkEmpAmt.Checked = false;
                chkNC.Checked = false;
                //=========================================
                cmbsalhead_DropDown(sender, e);

                if (dgvfmula.Rows[e.RowIndex].Cells[0].Value.ToString() == "Earnings")
                    _paytype = "E";
                else
                    _paytype = "D";

                if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells[28].Value) == "1")
                    ChkEmpBasic.Checked = true;
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells[28].Value) == "2")
                    chkEmpBsTs.Checked = true;
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells[28].Value) == "3")
                    ChkEmpSal.Checked = true;
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells[28].Value) == "4")
                    chkGrossAdd.Checked = true;
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells[28].Value) == "5")
                    chkEmpAmt.Checked = true;
                else
                {
                    ChkEmpBasic.Checked = false;
                    ChkEmpSal.Checked = false;
                    chkEmpBsTs.Checked = false;
                    chkGrossAdd.Checked = false;
                    chkEmpAmt.Checked = false;
                }

                this.chkAdvance.Checked = false;
                this.chkLoan.Checked = false;
                this.chkKit.Checked = false;


                if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["NCompliance"].Value) == "1")
                    chkNC.Checked = true;
                else
                    chkNC.Checked = false;

                if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["chkALK"].Value) == "1")
                    this.chkAdvance.Checked = true;
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["chkALK"].Value) == "2")
                    this.chkLoan.Checked = true;
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["chkALK"].Value) == "3")
                    this.chkKit.Checked = true;
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["chkALK"].Value) == "4")
                    this.chkFine.Checked = true;
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["chkALK"].Value) == "6")
                    this.chkGrossSub.Checked = true;
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["chkALK"].Value) == "7")
                    this.chkLv.Checked = true;
                else
                {
                    this.chkGrossSub.Checked = false;
                    this.chkAdvance.Checked = false;
                    this.chkLoan.Checked = false;
                    this.chkKit.Checked = false;
                    this.chkFine.Checked = false;
                    chkLv.Checked = false;
                }

                

                //if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells[29].Value) == "YES")
                //    ChkEmpSal.Checked = true;
                //else
                //    ChkEmpSal.Checked = false;
                cmboth.Text = dgvfmula.Rows[e.RowIndex].Cells[7].Value.ToString();
                cmbsalhead.Text = dgvfmula.Rows[e.RowIndex].Cells[1].Value.ToString() + " - " + _paytype;
                txtfull_name.Text = dgvfmula.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbvfrom.Text = dgvfmula.Rows[e.RowIndex].Cells[3].Value.ToString().Substring(0, dgvfmula.Rows[e.RowIndex].Cells[3].Value.ToString().IndexOf('/'));
                cmbvto.Text = dgvfmula.Rows[e.RowIndex].Cells[4].Value.ToString().Substring(0, dgvfmula.Rows[e.RowIndex].Cells[4].Value.ToString().IndexOf('/'));
                cmbcbasis.Text = dgvfmula.Rows[e.RowIndex].Cells[5].Value.ToString();
                cmbYear.Text = dgvfmula.Rows[e.RowIndex].Cells[3].Value.ToString().Substring(dgvfmula.Rows[e.RowIndex].Cells[3].Value.ToString().IndexOf('/') + 1, 9);
                //cmbctype.Text=dgvfmula.Rows[e.RowIndex].Cells[6].Value.ToString();
                cmbctype.SelectedItem = dgvfmula.Rows[e.RowIndex].Cells[6].Value.ToString();
                //cmboth_DropDown(sender, e);
                cmboth.Text = dgvfmula.Rows[e.RowIndex].Cells[7].Value.ToString();

                if (cmboth.Text.Trim() != "" && cmbctype.Text.Trim() == "FORMULA")
                {
                    if (btnsave.Enabled == false)
                    {
                        btnsave.Enabled = true;
                    }
                  
                }
                else if (cmboth.Text.Trim() == "" && cmbctype.Text.Trim() == "FORMULA")
                {
                    MessageBox.Show("Please tag a formula name", "Bravo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    btnsave.Enabled = false;
                }
                if (dgvfmula.Rows[e.RowIndex].Cells[8].Value.ToString().Trim() == "YES")
                {
                    chkpf.Checked = true;
                    txtpf.Enabled = true;
                    txtpf.Text = dgvfmula.Rows[e.RowIndex].Cells[9].Value.ToString();
                }
                else
                {
                    chkpf.Checked = false;
                    txtpf.Text = string.Empty;
                }
                if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["mod"].Value) != "0")
                {
                    string modVal = dgvfmula.Rows[e.RowIndex].Cells["mod"].Value.ToString().ToUpper();
                    cbOtherOption.Checked = true;
                    lblTo.Text = "to";
                    if (modVal == "MONTHOFDAYS")
                    {
                        cmbMOD.SelectedIndex = 0;
                        tbFrom.Text = "0";
                        tbTo.Text = "0";
                        cmbMOD.Text = "MONTHOFDAYS";
                        tbFrom.Visible = false;
                        tbTo.Visible = false;
                        // txtDays.Visible = false;
                    }
                    else if (modVal == "MOD-SUNDAYS")
                    {
                        cmbMOD.SelectedIndex = 2;
                        tbFrom.Text = "0";
                        tbTo.Text = "0";
                        cmbMOD.Text = "MOD-SUNDAYS";
                        tbFrom.Visible = false;
                        tbTo.Visible = false;
                        // txtDays.Visible = false;
                    }
                    else if (modVal.Contains("RANGE-SUNDAYS"))
                    {
                        cmbMOD.SelectedIndex = 4;
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                        tbFrom.Text = strFromTo[0];
                        tbTo.Text = strFromTo[1];
                        tbFrom.Visible = true;
                        tbTo.Visible = true;
                    }
                    else if (modVal.Contains("RANGE"))
                    {
                        cmbMOD.SelectedIndex = 3;
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                        tbFrom.Text = strFromTo[0];
                        tbTo.Text = strFromTo[1];
                        tbFrom.Visible = true;
                        tbTo.Visible = true;
                    }
                    else
                    {
                        try
                        {
                            if (modVal.Substring(0, 4) == "MOD-")
                            {
                                cmbMOD.SelectedIndex = 5;
                                tbFrom.Text = "0";
                                tbTo.Text = "0";
                                lblTo.Text = "x";
                                cmbMOD.Text = "MOD-x";
                                tbFrom.Visible = true;
                                tbFrom.Text = modVal.Substring(4, (modVal.Length - 4));
                                tbTo.Visible = false;
                                // txtDays.Visible = false;
                            }
                            else
                            {
                                cmbMOD.SelectedIndex = 1;
                                tbFrom.Text = dgvfmula.Rows[e.RowIndex].Cells["mod"].Value.ToString();
                                tbTo.Text = "0";
                                tbFrom.Visible = true;
                                tbTo.Visible = false;
                                // txtDays.Visible = true;
                            }
                        }
                        catch
                        {
                            cmbMOD.SelectedIndex = 1;
                            tbFrom.Text = dgvfmula.Rows[e.RowIndex].Cells["mod"].Value.ToString();
                            tbTo.Text = "0";
                            tbFrom.Visible = true;
                            tbTo.Visible = false;

                        }
                    }
                }


                //================21-05-2018==============================================================================

                if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["wd"].Value) != "0")
                {
                    string modVal = dgvfmula.Rows[e.RowIndex].Cells["wd"].Value.ToString().ToUpper();
                    chkOtherWD.Checked = true;
                    if (modVal == "MONTHOFDAYS")
                    {
                        cmbWD.SelectedIndex = 0;
                        txt_wd_from.Text = "0";
                        txt_wd_to.Text = "0";
                        cmbWD.Text = "MONTHOFDAYS";
                        txt_wd_from.Visible = false;
                        txt_wd_to.Visible = false;
                        // txtDays.Visible = false;
                    }
                    else if (modVal == "TDAYS")
                    {
                        cmbWD.SelectedIndex = 6;
                        txt_wd_from.Text = "0";
                        txt_wd_to.Text = "0";
                        txt_wd_from.Visible = false;
                        txt_wd_to.Visible = false;
                    }
                    else if (modVal == "MOD-SUNDAYS")
                    {
                        cmbWD.SelectedIndex = 2;
                        txt_wd_from.Text = "0";
                        txt_wd_to.Text = "0";
                        cmbWD.Text = "MOD-SUNDAYS";
                        txt_wd_from.Visible = false;
                        txt_wd_to.Visible = false;
                        // txtDays.Visible = false;
                    }

                    else if (modVal.Contains("RANGE-SUNDAYS"))
                    {
                        cmbWD.SelectedIndex = 4;
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                        txt_wd_from.Text = strFromTo[0];
                        txt_wd_to.Text = strFromTo[1];
                        txt_wd_from.Visible = true;
                        txt_wd_to.Visible = true;
                    }
                    else if (modVal.Contains("RANGE"))
                    {
                        cmbWD.SelectedIndex = 3;
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                        txt_wd_from.Text = strFromTo[0];
                        txt_wd_to.Text = strFromTo[1];
                        txt_wd_from.Visible = true;
                        txt_wd_to.Visible = true;
                    }
                    else
                    {
                        try
                        {
                            if (modVal.Substring(0, 4) == "MOD-")
                            {
                                cmbWD.SelectedIndex = 5;
                                txt_wd_from.Text = "0";
                                txt_wd_to.Text = "0";
                                cmbWD.Text = "MOD-x";
                                txt_wd_from.Visible = true;
                                txt_wd_from.Text = modVal.Substring(4, (modVal.Length - 4));
                                txt_wd_to.Visible = false;
                                // txtDays.Visible = false;
                            }
                            else
                            {
                                cmbWD.SelectedIndex = 1;
                                txt_wd_from.Text = dgvfmula.Rows[e.RowIndex].Cells["wd"].Value.ToString();
                                txt_wd_to.Text = "0";
                                txt_wd_from.Visible = true;
                                txt_wd_to.Visible = false;
                                // txtDays.Visible = true;
                            }
                        }
                        catch
                        {
                            cmbWD.SelectedIndex = 1;
                            txt_wd_from.Text = dgvfmula.Rows[e.RowIndex].Cells["wd"].Value.ToString();
                            txt_wd_to.Text = "0";
                            txt_wd_from.Visible = true;
                            txt_wd_to.Visible = false;

                        }
                    }
                }

                //=============================================================================================================================

                //if (dgvfmula.Rows[e.RowIndex].Cells[10].Value.ToString().Trim() == "YES")
                //    chkpfvol.Checked = true;
                //else
                //    chkpfvol.Checked = false;
                if (dgvfmula.Rows[e.RowIndex].Cells[11].Value.ToString().Trim() == "YES")
                {
                    chkesi.Checked = true;
                    txtesi.Text = dgvfmula.Rows[e.RowIndex].Cells[12].Value.ToString();
                }
                else
                {
                    chkesi.Checked = false;
                    txtesi.Text = string.Empty;
                }
                if (dgvfmula.Rows[e.RowIndex].Cells[13].Value.ToString().Trim() == "YES")
                    chkpt.Checked = true;
                else
                    chkpt.Checked = false;

                if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["alt_mon"].Value) == "1")
                    chkActiveMonths.Checked = true;
                else
                    chkActiveMonths.Checked=false;


                if (chkpt.Checked == true)
                {
                    string modVal = dgvfmula.Rows[e.RowIndex].Cells["pt_basis"].Value.ToString().ToUpper();
                    if (modVal.Trim().ToLower() == "gross")
                    {
                        cmb_pt.SelectedIndex = 0;

                        txtPT.Text = "";
                    }
                    else
                    {

                        cmb_pt.SelectedIndex = 1;

                        txtPT.Text = modVal.ToUpper();
                    }

                }
                else if (chkActiveMonths.Checked == true)
                    txtActiveMonths.Text = dgvfmula.Rows[e.RowIndex].Cells["pt_basis"].Value.ToString().Trim();
                else
                    txtActiveMonths.Text = "";

               

                if (dgvfmula.Rows[e.RowIndex].Cells[11].Value.ToString().Trim() == "YES")
                {
                    chkesi.Checked = true;
                    txtesi.Enabled = true;
                    txtesi.Text = dgvfmula.Rows[e.RowIndex].Cells[12].Value.ToString();
                }
                else
                {
                    chkesi.Checked = false;
                    txtesi.Text = string.Empty;
                }
                if (dgvfmula.Rows[e.RowIndex].Cells[14].Value.ToString().Trim() == "YES")
                {
                    chkroundoff.Checked = true;
                    cmbroundoff.Enabled = true;
                    cmbroundoff.Text = dgvfmula.Rows[e.RowIndex].Cells[15].Value.ToString().Trim();

                }
                else
                {
                    chkroundoff.Checked = false;
                    cmbroundoff.Enabled = false;
                    cmbroundoff.Text = " ";
                }


                if (dgvfmula.Rows[e.RowIndex].Cells[23].Value.ToString().Trim() == "YES")
                    cheattendence.Checked = true;
                else
                    cheattendence.Checked = false;

                if (dgvfmula.Rows[e.RowIndex].Cells[24].Value.ToString().Trim() == "YES")
                    cheovertime.Checked = true;
                else if (dgvfmula.Rows[e.RowIndex].Cells[24].Value.ToString().Trim() == "ED")
                    chkED.Checked = true;
                else
                {
                    cheovertime.Checked = false;
                    chkED.Checked = false;
                }

                /* Wday
                  OT
                  TDays
                  ED */
                ////if (cmbDailyWages.SelectedIndex == 1)
                ////{
                ////    daily_wages = 11;
                ////}
                ////else if (cmbDailyWages.SelectedIndex == 2)
                ////{
                ////    daily_wages = 12;
                ////}
                ////else if (cmbDailyWages.SelectedIndex == 3)
                ////{
                ////    daily_wages = 13;
                ////}
                ////else
                ////{
                ////    daily_wages = 1;
                ////}

                if (dgvfmula.Rows[e.RowIndex].Cells[25].Value.ToString().Trim() == "YES")
                { chedailywages.Checked = true; chkPerHour.Checked = false; chkAtten_WD.Checked = false; cmbDailyWages.SelectedIndex = 0; }
                else if (dgvfmula.Rows[e.RowIndex].Cells[25].Value.ToString().Trim() == "OT")
                { chedailywages.Checked = true; chkPerHour.Checked = false; chkAtten_WD.Checked = false; cmbDailyWages.SelectedIndex = 1; }
                else if (dgvfmula.Rows[e.RowIndex].Cells[25].Value.ToString().Trim() == "TDays")
                { chedailywages.Checked = true; chkPerHour.Checked = false; chkAtten_WD.Checked = false; cmbDailyWages.SelectedIndex = 2; }
                else if (dgvfmula.Rows[e.RowIndex].Cells[25].Value.ToString().Trim() == "ED")
                { chedailywages.Checked = true; chkPerHour.Checked = false; chkAtten_WD.Checked = false; cmbDailyWages.SelectedIndex = 3; }
                else if (dgvfmula.Rows[e.RowIndex].Cells[25].Value.ToString().Trim() == "Config")
                { chkAtten_WD.Checked = true; chedailywages.Checked = true; chkPerHour.Checked = false; cmbDailyWages.SelectedIndex = 4; }

                else if (dgvfmula.Rows[e.RowIndex].Cells[25].Value.ToString().Trim() == "HR")
                {
                    chkPerHour.Checked = true;
                    chedailywages.Checked = false;
                    chkAtten_WD.Checked = false;
                }

                else if (dgvfmula.Rows[e.RowIndex].Cells[25].Value.ToString().Trim() == "cWD")
                {
                    chkPerHour.Checked = false;
                    chedailywages.Checked = false;
                    chkAtten_WD.Checked = true;
                }
                else
                {
                    chedailywages.Checked = false;
                    chkPerHour.Checked = false;
                    chkAtten_WD.Checked = false;
                }

                this.chkHide.Checked = false;
                chkAfterDeductionEffect.Checked = false;
                if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["chkHide"].Value) == "1")
                    this.chkHide.Checked = true;
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["chkHide"].Value) == "2")
                    this.chkShowAfterNet.Checked = true;
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["chkHide"].Value) == "3")
                    this.chkAfterDeductionEffect.Checked = true;
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["chkHide"].Value) == "31")
                {
                    this.chkAfterDeductionEffect.Checked = true;
                    this.chkHide.Checked = true;
                }
                else
                {
                    this.chkHide.Checked = false;
                    this.chkShowAfterNet.Checked = false;
                    chkAfterDeductionEffect.Checked = false;
                }

                if (dgvfmula.Rows[e.RowIndex].Cells[26].Value.ToString().Trim() == "YES")
                    chestump.Checked = true;
                else
                    chestump.Checked = false;

                txtstump.Text = Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells[27].Value);

                txtremarks.Text = dgvfmula.Rows[e.RowIndex].Cells[21].Value.ToString();
                sl_no = Convert.ToInt32(dgvfmula.Rows[e.RowIndex].Cells[22].Value);

                if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["no_round"].Value) == "1")
                { this.chkroundoff.Checked = true; chkNetRoff.Checked = false; }
                else if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["no_round"].Value) == "2")
                { this.chkroundoff.Checked = true; chkNetRoff.Checked = true; }

                else
                { this.chkroundoff.Checked = false; chkNetRoff.Checked = false; }


                if (Convert.ToString(dgvfmula.Rows[e.RowIndex].Cells["limit_day"].Value) == "1")
                {
                    this.chkMinDays.Checked = true;
                    txtMinDays.Text = dgvfmula.Rows[e.RowIndex].Cells["ldays"].Value.ToString().Trim();
                }
                else
                {
                    this.chkMinDays.Checked = false;
                    txtMinDays.Text = "0";

                }


                try
                {
                    txtlessLv.Text = (dgvfmula.Rows[e.RowIndex].Cells["lvless"].Value.ToString());
                }
                catch
                {
                    txtlessLv.Text = "0";
                }

                try
                {
                    if ((dgvfmula.Rows[e.RowIndex].Cells["GS"].Value.ToString()) == "0")
                    {
                        chkGrossAs.Checked = false;
                    }
                    else
                    {
                        chkGrossAs.Checked = true;
                    }
                }
                catch
                {
                    txtlessLv.Text = "0";
                }

                try
                {
                    if (dgvfmula.Rows[e.RowIndex].Cells["Flag"].Value.ToString().Trim() == "0")
                        chkFlag.Checked = false;
                    else
                        chkFlag.Checked = true;

                }
                catch { chkFlag.Checked = false; }
               

            }
            catch (Exception x) { }
        }
        public void del()
        {
            bool sta = false;
            string[] salhead = cmbsalhead.Text.Trim().ToString().Split('-');
            if (clsValidation.ValidateComboBox(cmbsalstruc, "", "Please Select Salary Structure"))
            {

                ERPMessageBox.ERPMessage.Show("Do U Want to Delete " + salhead[0].Trim(), "Question ?", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
                if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
                    sta = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Assign_SalStructure where session='" + cmbYear.Text.Trim() + "' and sal_struct=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " and sal_head=" + get_sal_head_ID(salhead[0].Trim()) + " and V_FROM='" + cmbvfrom.Text.Trim() + "' and V_TO='" + cmbvto.Text.Trim() + "' and slno=" + sl_no + "");
                if (sta)
                {
                    ERPMessageBox.ERPMessage.Show("Formula Deleted Sucessfully");
                    txtfull_name.Text = string.Empty;
                    cmbsalhead.Text = string.Empty;

                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                del();
                get_ass();
                clea_all();
                edpcom.InsertMidasLog(this, true, "del", cmbsalstruc.Text.Trim());

            }
            catch (Exception x) { }
        }

        private void chkesi_Click(object sender, EventArgs e)
        {
            if (chkesi.Checked)
            {
                txtesi.Enabled = true;
                txtesi.Text = string.Empty;
            }
            else
            {
                txtesi.Enabled = false;
                txtesi.Text = string.Empty;
            }

        }
        public void clea_all()
        {
            //cmbsalstruc.Text = "";
            cmbsalhead.SelectedIndex = -1;
            //cmbsalstruc.Items.Clear();

            txtfull_name.Text = string.Empty;
            //cmbvfrom.SelectedIndex = -1;
            //cmbvto.SelectedIndex = -1;
            cmbcbasis.SelectedIndex = -1;
            cmbctype.SelectedIndex = -1;
            //cmboth.SelectedIndex = -1;
            cmboth.Text = "";
            
            txtremarks.Text = string.Empty;
            chkpf.Checked = false;
            chkesi.Checked = false;
            //chkpfvol.Checked = false;

            chkNC.Checked = false;
            chkpt.Checked = false;
            chkroundoff.Checked = false;
            cmbroundoff.SelectedIndex = -1;
            txtpf.Text = string.Empty;
            txtesi.Text = string.Empty;
            cheovertime.Checked = false;
            cheattendence.Checked = false;
            chedailywages.Checked = false;
            chestump.Checked = false;
            txtstump.Text = "";
            ChkEmpBasic.Checked = false;
            ChkEmpSal.Checked = false;
            chkEmpBsTs.Checked = false;
            chkEmpAmt.Checked = false;
            chkAdvance.Checked = false;
            chkLoan.Checked = false;
            chkKit.Checked = false;
            chkFine.Checked = false;
            cbOtherOption.Checked = false;
            chkLv.Checked = false;
            chkAtten_WD.Checked = false;
            txtPT.Text = "";
            cmb_pt.Visible = false;
            txtlessLv.Visible = false;
            txtlessLv.Text = "0";
            txtPT.Visible = false;
            lbl_pt_based.Visible = false;

            chkroundoff.Checked = false;
            chkNetRoff.Checked = false;
            chkMinDays.Checked = false;
            chkActiveMonths.Checked = false;
            txtActiveMonths.Text = "";

            hide_settings();
            chkShowAfterNet.Checked = false;

            chkFlag.Checked = false;
        }

        private void btnnentry_Click(object sender, EventArgs e)
        {
            try
            {
                cmbLocation.Text = "";
                Locations = 0;
                cmbsalstruc.Text = "";
                try
                {
                    dgvfmula.Rows.Clear();
                }
                catch { }
                dgvfmula.DataSource = "";
                clea_all();
                 Employee_Heads_to_Structure_Load(sender,e);
                 grp_add_opt.Visible = false;
                 lblMsg2.Visible = false; lbl_msg_addopt.Visible = false;
                 chedailywages.Checked = false;
                 
            }
            catch (Exception x) { }
        }
        public int get_sl()
        {
            string s = ""; int res = 0;
            s = "select max(slno) from tbl_Employee_Assign_SalStructure";
            DataTable dtt = new DataTable();
            dtt = clsDataAccess.RunQDTbl(s);
            if (dtt.Rows.Count > 0 && dtt.Rows[0][0].ToString() != "")
            {
                res = Convert.ToInt32(dtt.Rows[0][0]);
            }
            return res + 1;
        }
        public void Update_st(int i)
        {
            string ss = "", strMOD = "", strWD = "", pt_basis = "", lvless = "0"; bool st = false;

            int att_day = 0, ove_time = 0, daily_wages = 0, rev_stamp = 0, _chkbasic = 0, _chkSal = 0, _chkALK = 0, _chkHide = 0, no_round = 0, limit_day = 0, ldays = 0, alt_mon = 0, gs = 0, _chkFlag = 0, _chkNC=0;


            if (chkNC.Checked == true)
            {
                _chkNC = 1;
            }
            else
            {
                _chkNC = 0;
            }


            if (chkFlag.Checked == true)
            {
                _chkFlag = 1;
            }
            else { _chkFlag = 0; }

            if (cheattendence.Checked == true)
                att_day = 1;
            if (cheovertime.Checked == true)
                ove_time = 1;
            if (chkED.Checked == true)
                ove_time = 2;

            if (chedailywages.Checked == true)
            {
                /* Wday
                   OT
                   TDays
                   ED */
                if (cmbDailyWages.SelectedIndex == 1)
                {
                    daily_wages = 11;
                }
                else if (cmbDailyWages.SelectedIndex == 2)
                {
                    daily_wages = 12;
                }
                else if (cmbDailyWages.SelectedIndex == 3)
                {
                    daily_wages = 13;
                }
                else if (cmbDailyWages.SelectedIndex == 4)
                {
                    daily_wages = 14;
                }
                else
                {
                    daily_wages = 1;
                }

            }
            else if (chkPerHour.Checked == true)
                daily_wages = 2;
            else if (chkAtten_WD.Checked == true)
                daily_wages = 3;
            else
                daily_wages = 0;


            if (chestump.Checked == true)
                rev_stamp = 1;


            _chkbasic = 0;

            if (ChkEmpBasic.Checked == true)
                _chkbasic = 1;

            if (this.chkEmpBsTs.Checked == true)
                _chkbasic = 2;

            if (ChkEmpSal.Checked == true)
                _chkbasic = 3;

            if (chkGrossSub.Checked == true)
                _chkbasic = 4;

            if (chkEmpAmt.Checked == true)
                _chkbasic = 5;


            if (chkAdvance.Checked == true)
                _chkALK = 1;
            else if (chkLoan.Checked == true)
                _chkALK = 2;
            else if (chkKit.Checked == true)
                _chkALK = 3;
            else if (chkFine.Checked == true)
                _chkALK = 4;
            else if (chkGrossAdd.Checked == true)
                _chkALK = 6;
            else if (chkLv.Checked == true)
                _chkALK = 7;
            else
                _chkALK = 0;


            if (chkGrossAs.Checked == true)
                gs = 1;



            if (chkroundoff.Checked == true && chkNetRoff.Checked == false)
                no_round = 1;
            else if (chkroundoff.Checked == true && chkNetRoff.Checked == true)
                no_round = 2;
            else
                no_round = 0;

            if (chkMinDays.Checked == true)
            {
                limit_day = 1;
                try
                {
                    ldays = Convert.ToInt32(txtMinDays.Text);
                }
                catch
                {

                    ldays = 0;
                }

            }




            if (this.chkHide.Checked == true)
            {
                if (this.chkAfterDeductionEffect.Checked == true)
                    _chkHide = 31; else _chkHide = 1;
            }
            else if (this.chkShowAfterNet.Checked == true)
                _chkHide = 2;
            else if (this.chkAfterDeductionEffect.Checked == true)
                _chkHide = 3;
            else
                _chkHide = 0;

            if (this.cbOtherOption.Checked)
            {
                if (cmbMOD.SelectedIndex == 0)
                {
                    strMOD = "MonthOfDays";//cmbMOD.Text;
                }
                else if (cmbMOD.SelectedIndex == 3 || cmbMOD.SelectedIndex == 4)
                {
                    strMOD = cmbMOD.Text + "[" + tbFrom.Text + "-" + tbTo + "]";
                }
                else if (cmbMOD.SelectedIndex == 2)
                {
                    strMOD = cmbMOD.Text;
                }
                else if (cmbMOD.SelectedIndex == 5)
                {
                    strMOD = cmbMOD.Text.Substring(0, 4) + tbFrom.Text.Trim();

                }
                else
                {
                    strMOD = tbFrom.Text;
                }
            }
            else
            {
                strMOD = "0";
            }

            //===============================Bibhas ------- 21-05-2018
            //MonthOfDays
            //Other
            //MOD-SUNDAYS
            //RANGE
            //RANGE-SUNDAYS
            //Mod-4
            alt_mon = 0;
            if (chkpt.Checked == true)
            {
                if (cmb_pt.SelectedIndex == 0)
                    pt_basis = "GROSS";
                else
                    pt_basis = txtPT.Text.Trim().ToUpper();
            }
            else
            {
                if (chkActiveMonths.Checked == true)
                {
                    alt_mon = 1;
                    pt_basis = txtActiveMonths.Text.Trim().ToLower();
                }
                else
                {
                    alt_mon = 0;
                    pt_basis = "";
                }
            }
            if (this.chkOtherWD.Checked)
            {
                if (cmbWD.SelectedIndex == 0)
                {
                    strWD = "MonthOfDays";//cmbMOD.Text;
                }
                else if (cmbWD.SelectedIndex == 3 || cmbWD.SelectedIndex == 4)
                {
                    strWD = cmbWD.Text + "[" + txt_wd_from.Text + "-" + txt_wd_to + "]";
                }
                else if (cmbWD.SelectedIndex == 2 )
                {
                    strWD = cmbWD.Text;
                }
                else if (cmbWD.SelectedIndex == 5)
                {
                    strWD = cmbWD.Text.Substring(0,4)+ txt_wd_from.Text.Trim();

                }
                else if (cmbWD.SelectedIndex == 6)
                {
                    strWD = cmbWD.Text;
                }
                else
                {
                    strWD = txt_wd_from.Text;
                }
            }
            else
            {
                strWD = "0";
            }


            company_Id = clsEmployee.GetCompany_ID(Locations);
            try
            {
                lvless = (txtlessLv.Text.ToString());
            }
            catch
            {
                lvless = "0";
            }
            if (lvless.Trim() == "")
            {

                lvless = "0";
            }

            string[] salhead = cmbsalhead.Text.Trim().ToString().Split('-');
            if (chkpf.Checked && chkesi.Checked)
            {
                //if (clsValidation.ValidateTextBox(txtpf, "", "Please Enter PF % "))
                //{
                //    if (clsValidation.ValidateTextBox(txtesi, "", "Please Enter ESI %"))
                //    {
                if (chkpt.Checked)
                    //,'" + _chkbasic + "','" + _chkSal + "'
                    //EMP_BASIC='" + _chkbasic + "', EMP_SAL='" + _chkSal + "'
                    ss = "update tbl_Employee_Assign_SalStructure set mod='" + strMOD + "',wd='" + strWD + "', P_TYPE='" + sal_head(salhead[0].Trim()) + "', C_BASIS='" + cmbcbasis.Text.Trim() + "',C_TYPE='" + cmbctype.Text.Trim() + "',C_DET=" + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ",PF_PER= '1' ,PF_VOL=0,ESI_PER= '1',PT=1,ROUND_TYPE= '" + cmbroundoff.Text.Trim() + "',TDSREFNO=0,TDS_EXEMPT=0,CARRY=0,TDS_EXTRAPOL=0,REMARKS='" + txtremarks.Text.Trim() + "',atten_day='" + att_day + "',Proxy_day='" + ove_time + "',Daily_wages = '" + daily_wages + "',revenue_stamp='" + rev_stamp + "',stamp_Amount='" + txtstump.Text + "',Location_id='" + Locations + "',Company_id='" + company_Id + "',EMP_BASIC='" + _chkbasic + "',chkALK=" + _chkALK + ",chkHide=" + _chkHide + ",pt_basis='" + pt_basis + "',[no_round]='" + no_round + "', [limit_day]='" + limit_day + "', [ldays]='" + ldays + "',[alt_mon]='" + alt_mon + "',lvless=" + lvless + ",lock=1,gs=" + gs + ",chkFlag='" + _chkFlag + "',NCompliance='"+_chkNC+"' where SESSION='" + cmbYear.Text.Trim() + "' and SAL_STRUCT=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " and SAL_HEAD=" + get_sal_head_ID(salhead[0].Trim()) + " and V_FROM='" + cmbvfrom.Text.Trim() + "' and V_TO='" + cmbvto.Text.Trim() + "' and slno=" + sl_no;
                else
                    ss = "update tbl_Employee_Assign_SalStructure set mod='" + strMOD + "',wd='" + strWD + "',P_TYPE='" + sal_head(salhead[0].Trim()) + "', C_BASIS='" + cmbcbasis.Text.Trim() + "',C_TYPE='" + cmbctype.Text.Trim() + "',C_DET=" + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ",PF_PER= '1' ,PF_VOL=0,ESI_PER= '1' ,PT=0,ROUND_TYPE= '" + cmbroundoff.Text.Trim() + "',TDSREFNO=0,TDS_EXEMPT=0,CARRY=0,TDS_EXTRAPOL=0,REMARKS='" + txtremarks.Text.Trim() + "',atten_day='" + att_day + "',Proxy_day='" + ove_time + "',Daily_wages = '" + daily_wages + "',revenue_stamp='" + rev_stamp + "',stamp_Amount='" + txtstump.Text + "',Location_id='" + Locations + "',Company_id='" + company_Id + "',EMP_BASIC='" + _chkbasic + "',chkALK=" + _chkALK + ",chkHide=" + _chkHide + ",pt_basis='" + pt_basis + "',[no_round]='" + no_round + "', [limit_day]='" + limit_day + "', [ldays]='" + ldays + "',[alt_mon]='" + alt_mon + "',lvless=" + lvless + ",lock=1,gs=" + gs + ",chkFlag='" + _chkFlag + "',NCompliance='" + _chkNC + "' where SESSION='" + cmbYear.Text.Trim() + "' and SAL_STRUCT=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " and SAL_HEAD=" + get_sal_head_ID(salhead[0].Trim()) + " and V_FROM='" + cmbvfrom.Text.Trim() + "' and V_TO='" + cmbvto.Text.Trim() + "' and slno=" + sl_no;
                st = clsDataAccess.RunNQwithStatus(ss);
                //    }
                //}
            }
            else if (!chkpf.Checked && chkesi.Checked)
            {
                //if (clsValidation.ValidateTextBox(txtesi, "", "Please Enter ESI %"))
                //{  atten_day
                if (chkpt.Checked)
                    ss = "update tbl_Employee_Assign_SalStructure set mod='" + strMOD + "',wd='" + strWD + "',P_TYPE='" + sal_head(salhead[0].Trim()) + "', C_BASIS='" + cmbcbasis.Text.Trim() + "',C_TYPE='" + cmbctype.Text.Trim() + "',C_DET=" + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ",PF_PER=0 ,PF_VOL=0,ESI_PER='1' ,PT=1,ROUND_TYPE= '" + cmbroundoff.Text.Trim() + "',TDSREFNO=0,TDS_EXEMPT=0,CARRY=0,TDS_EXTRAPOL=0,REMARKS='" + txtremarks.Text.Trim() + "',atten_day='" + att_day + "',Proxy_day='" + ove_time + "',Daily_wages = '" + daily_wages + "',revenue_stamp='" + rev_stamp + "',stamp_Amount='" + txtstump.Text + "',Location_id='" + Locations + "',Company_id='" + company_Id + "',EMP_BASIC='" + _chkbasic + "',chkALK=" + _chkALK + ",chkHide=" + _chkHide + ",pt_basis='" + pt_basis + "',[no_round]='" + no_round + "', [limit_day]='" + limit_day + "', [ldays]='" + ldays + "',[alt_mon]='" + alt_mon + "',lvless=" + lvless + ",lock=1,gs=" + gs + ",chkFlag='" + _chkFlag + "',NCompliance='" + _chkNC + "' where SESSION='" + cmbYear.Text.Trim() + "' and SAL_STRUCT=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " and SAL_HEAD=" + get_sal_head_ID(salhead[0].Trim()) + " and V_FROM='" + cmbvfrom.Text.Trim() + "' and V_TO='" + cmbvto.Text.Trim() + "' and slno=" + sl_no;
                else
                    ss = "update tbl_Employee_Assign_SalStructure set mod='" + strMOD + "',wd='" + strWD + "',P_TYPE='" + sal_head(salhead[0].Trim()) + "', C_BASIS='" + cmbcbasis.Text.Trim() + "',C_TYPE='" + cmbctype.Text.Trim() + "',C_DET=" + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ",PF_PER=0 ,PF_VOL=0,ESI_PER='1' ,PT=0,ROUND_TYPE= '" + cmbroundoff.Text.Trim() + "',TDSREFNO=0,TDS_EXEMPT=0,CARRY=0,TDS_EXTRAPOL=0,REMARKS='" + txtremarks.Text.Trim() + "',atten_day='" + att_day + "',Proxy_day='" + ove_time + "',Daily_wages = '" + daily_wages + "',revenue_stamp='" + rev_stamp + "',stamp_Amount='" + txtstump.Text + "',Location_id='" + Locations + "',Company_id='" + company_Id + "',EMP_BASIC='" + _chkbasic + "',chkALK=" + _chkALK + ",chkHide=" + _chkHide + ",pt_basis='" + pt_basis + "',[no_round]='" + no_round + "', [limit_day]='" + limit_day + "', [ldays]='" + ldays + "',[alt_mon]='" + alt_mon + "',lvless=" + lvless + ",lock=1,gs=" + gs + ",chkFlag='" + _chkFlag + "',NCompliance='" + _chkNC + "' where SESSION='" + cmbYear.Text.Trim() + "' and SAL_STRUCT=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " and SAL_HEAD=" + get_sal_head_ID(salhead[0].Trim()) + " and V_FROM='" + cmbvfrom.Text.Trim() + "' and V_TO='" + cmbvto.Text.Trim() + "' and slno=" + sl_no;
                st = clsDataAccess.RunNQwithStatus(ss);
                //}
            }
            else if (chkpf.Checked && !chkesi.Checked)
            {
                //if (clsValidation.ValidateTextBox(txtpf, "", "Please Enter PF %"))
                //{
                if (chkpt.Checked)
                    ss = "update tbl_Employee_Assign_SalStructure set mod='" + strMOD + "',wd='" + strWD + "',P_TYPE='" + sal_head(salhead[0].Trim()) + "', C_BASIS='" + cmbcbasis.Text.Trim() + "',C_TYPE= '" + cmbctype.Text.Trim() + "',C_DET=" + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ",PF_PER= '1' ,PF_VOL=0,ESI_PER=0 ,PT=1,ROUND_TYPE='" + cmbroundoff.Text.Trim() + "',TDSREFNO=0,TDS_EXEMPT=0,CARRY=0,TDS_EXTRAPOL=0,REMARKS='" + txtremarks.Text.Trim() + "',atten_day='" + att_day + "',Proxy_day='" + ove_time + "',Daily_wages = '" + daily_wages + "',revenue_stamp='" + rev_stamp + "',stamp_Amount='" + txtstump.Text + "',Location_id='" + Locations + "',Company_id='" + company_Id + "',EMP_BASIC='" + _chkbasic + "',chkALK=" + _chkALK + ",chkHide=" + _chkHide + ",pt_basis='" + pt_basis + "',[no_round]='" + no_round + "', [limit_day]='" + limit_day + "', [ldays]='" + ldays + "',[alt_mon]='" + alt_mon + "',lvless=" + lvless + ",lock=1,gs=" + gs + ",chkFlag='" + _chkFlag + "',NCompliance='" + _chkNC + "' where SESSION='" + cmbYear.Text.Trim() + "' and SAL_STRUCT=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " and SAL_HEAD=" + get_sal_head_ID(salhead[0].Trim()) + " and V_FROM='" + cmbvfrom.Text.Trim() + "' and V_TO='" + cmbvto.Text.Trim() + "' and slno=" + sl_no;
                else
                    ss = "update tbl_Employee_Assign_SalStructure set mod='" + strMOD + "',wd='" + strWD + "',P_TYPE='" + sal_head(salhead[0].Trim()) + "', C_BASIS='" + cmbcbasis.Text.Trim() + "',C_TYPE= '" + cmbctype.Text.Trim() + "',C_DET=" + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ",PF_PER= '1' ,PF_VOL=0,ESI_PER=0 ,PT=0,ROUND_TYPE='" + cmbroundoff.Text.Trim() + "',TDSREFNO=0,TDS_EXEMPT=0,CARRY=0,TDS_EXTRAPOL=0,REMARKS='" + txtremarks.Text.Trim() + "',atten_day='" + att_day + "',Proxy_day='" + ove_time + "',Daily_wages = '" + daily_wages + "',revenue_stamp='" + rev_stamp + "',stamp_Amount='" + txtstump.Text + "',Location_id='" + Locations + "',Company_id='" + company_Id + "',EMP_BASIC='" + _chkbasic + "',chkALK=" + _chkALK + ",chkHide=" + _chkHide + ",pt_basis='" + pt_basis + "',[no_round]='" + no_round + "', [limit_day]='" + limit_day + "', [ldays]='" + ldays + "',[alt_mon]='" + alt_mon + "',lvless=" + lvless + ",lock=1,gs=" + gs + ",chkFlag='" + _chkFlag + "',NCompliance='" + _chkNC + "' where SESSION='" + cmbYear.Text.Trim() + "' and SAL_STRUCT=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " and SAL_HEAD=" + get_sal_head_ID(salhead[0].Trim()) + " and V_FROM='" + cmbvfrom.Text.Trim() + "' and V_TO='" + cmbvto.Text.Trim() + "' and slno=" + sl_no;

                st = clsDataAccess.RunNQwithStatus(ss);
                //}
            }
            else if (!chkpf.Checked && !chkesi.Checked)
            {
                if (chkpt.Checked)
                    ss = "update tbl_Employee_Assign_SalStructure set mod='" + strMOD + "',wd='" + strWD + "',P_TYPE='" + sal_head(salhead[0].Trim()) + "',C_BASIS='" + cmbcbasis.Text.Trim() + "',C_TYPE='" + cmbctype.Text.Trim() + "',C_DET= " + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ",PF_PER=0 ,PF_VOL=0,ESI_PER=0 ,PT=1,ROUND_TYPE= '" + cmbroundoff.Text.Trim() + "',TDSREFNO=0,TDS_EXEMPT=0,CARRY=0,TDS_EXTRAPOL=0,REMARKS= '" + txtremarks.Text.Trim() + "',atten_day='" + att_day + "',Proxy_day='" + ove_time + "',Daily_wages = '" + daily_wages + "',revenue_stamp='" + rev_stamp + "',stamp_Amount='" + txtstump.Text + "',Location_id='" + Locations + "',Company_id='" + company_Id + "',EMP_BASIC='" + _chkbasic + "',chkALK=" + _chkALK + ",chkHide=" + _chkHide + ",pt_basis='" + pt_basis + "',[no_round]='" + no_round + "', [limit_day]='" + limit_day + "', [ldays]='" + ldays + "',[alt_mon]='" + alt_mon + "',lvless=" + lvless + ",lock=1,gs=" + gs + ",chkFlag='" + _chkFlag + "',NCompliance='" + _chkNC + "'  where SESSION='" + cmbYear.Text.Trim() + "' and SAL_STRUCT=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " and SAL_HEAD=" + get_sal_head_ID(salhead[0].Trim()) + " and V_FROM='" + cmbvfrom.Text.Trim() + "' and V_TO='" + cmbvto.Text.Trim() + "' and slno=" + sl_no;
                else
                    ss = "update tbl_Employee_Assign_SalStructure set mod='" + strMOD + "',wd='" + strWD + "',P_TYPE='" + sal_head(salhead[0].Trim()) + "',C_BASIS='" + cmbcbasis.Text.Trim() + "',C_TYPE='" + cmbctype.Text.Trim() + "',C_DET= " + get_OtherID(cmbctype.Text.Trim(), cmboth.Text.Trim()) + ",PF_PER=0 ,PF_VOL=0,ESI_PER=0 ,PT=0,ROUND_TYPE= '" + cmbroundoff.Text.Trim() + "',TDSREFNO=0,TDS_EXEMPT=0,CARRY=0,TDS_EXTRAPOL=0,REMARKS= '" + txtremarks.Text.Trim() + "',atten_day='" + att_day + "',Proxy_day='" + ove_time + "',Daily_wages = '" + daily_wages + "',revenue_stamp='" + rev_stamp + "',stamp_Amount='" + txtstump.Text + "',Location_id='" + Locations + "',Company_id='" + company_Id + "',EMP_BASIC='" + _chkbasic + "',chkALK=" + _chkALK + ",chkHide=" + _chkHide + ",pt_basis='" + pt_basis + "',[no_round]='" + no_round + "', [limit_day]='" + limit_day + "', [ldays]='" + ldays + "',[alt_mon]='" + alt_mon + "',lvless=" + lvless + ",lock=1,gs=" + gs + ",chkFlag='" + _chkFlag + "',NCompliance='" + _chkNC + "'  where SESSION='" + cmbYear.Text.Trim() + "' and SAL_STRUCT=" + get_SalStructID(cmbsalstruc.Text.Trim()) + " and SAL_HEAD=" + get_sal_head_ID(salhead[0].Trim()) + " and V_FROM='" + cmbvfrom.Text.Trim() + "' and V_TO='" + cmbvto.Text.Trim() + "' and slno=" + sl_no;
                st = clsDataAccess.RunNQwithStatus(ss);
            }
            //bool st = clsDataAccess.RunNQwithStatus(ss);
            if (st)
            {
                ERPMessageBox.ERPMessage.Show("Data Saved Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                get_ass();
                clea_all();
            }
        }

        private void cmbctype_SelectedValueChanged(object sender, EventArgs e)
        {
            string s = "";
            //cmboth.Items.Clear();
            cmboth.Text = "";
            btnsave.Enabled = true;
            chkFlag.Enabled = false;

            if (cmbctype.Text == "FORMULA")
            {
                chkFlag.Enabled = true;
                btnfmula.Visible = true;
                cmboth.Visible = true;
                
                lbloth.Visible = true;
                lbloth.Text = cmbctype.Text;
                MessageBox.Show("Please tag a formula name", "Bravo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //s = "select fname from tbl_Employee_Sal_Structure_Formula";
                //Load_Data(s, cmboth, 0);
                btnsave.Enabled = false;
            }
            else if (cmbctype.Text == "COMPANY LUMPSUM")
            {
                btnfmula.Visible = true;
                cmboth.Visible = true;
                lbloth.Visible = true;
                lbloth.Text = "C. Lumpsum";// cmbctype.Text;
                //s = "select fname from tbl_Employee_Sal_Structure_Formula";
                //Load_Data(s, cmboth, 0);
            }
            else if (cmbctype.Text == "SAL STRUCTURE LUMPSUM")
            {
                btnfmula.Visible = true;
                cmboth.Visible = true;
                lbloth.Visible = true;
                lbloth.Text = "S.S.Lumpsum";
            }
            else if (cmbctype.Text == "SLAB")
            {
                lbloth.Text = cmbctype.Text;
                btnfmula.Visible = true;
                cmboth.Visible = true;
                lbloth.Visible = true;
            }
            else if (cmbctype.Text == "LUMPSUM")
            {
                btnfmula.Visible = false;
                cmboth.Visible = false;
                lbloth.Visible = false;
            }
            if (cmbLocation.Text.Trim() == "" || cmbsalhead.Text.Trim()=="")
            {
                return;
            }
           // cmboth.PopUp();
        }

        private void chestump_CheckedChanged(object sender, EventArgs e)
        {
            if (chestump.Checked == true)
            {
                chestump.Enabled = true;
                txtstump.Visible = true;
                label2.Visible = true;
            }
            else
            {
                txtstump.Text = "";
                txtstump.Visible = false;
                label2.Visible = false;
            }
        }

        //private void comboBox1_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string s = "";
        //        comboBox1.Items.Clear();
        //        ChkEmpBasic.Checked = false;
        //        //ChkEmpSal.Checked = false;

        //        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        //        s = "select Location_Name from tbl_Emp_Location where Location_ID in (" + edpcom.CurrentLocation + ")";
        //        Load_Data(s, comboBox1, -1);                
        //    }
        //    catch (Exception x) { }
        //}

        //private void comboBox1_DropDownClosed(object sender, EventArgs e)
        //{
        //    Locations = get_LocationID(comboBox1.Text);
        //}

        public int get_LocationID(string name)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select Location_ID from tbl_Emp_Location where Location_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0][0]);
            else
                return 0;
        }

        private void ChkEmpBasic_CheckedChanged(object sender, EventArgs e)
        {

            if (ChkEmpBasic.Checked)
            {
                chkEmpBsTs.Checked = false;
                ChkEmpSal.Checked = false;
                chkGrossAdd.Checked = false;
                chkEmpAmt.Checked = false;
                this.cmbcbasis.SelectedItem = "Independent";
                this.cmbctype.SelectedItem = "COMPANY LUMPSUM";
            }
            else if (chkEmpBsTs.Checked)
            {
                ChkEmpBasic.Checked = false;
                ChkEmpSal.Checked = false;
                chkGrossAdd.Checked = false; chkEmpAmt.Checked = false;
                this.cmbcbasis.SelectedItem = "Independent";
                this.cmbctype.SelectedItem = "COMPANY LUMPSUM";
            }
            else if (ChkEmpSal.Checked)
            {
                chkEmpBsTs.Checked = false;
                ChkEmpBasic.Checked = false;
                chkGrossAdd.Checked = false; chkEmpAmt.Checked = false;
                this.cmbcbasis.SelectedItem = "Independent";
                this.cmbctype.SelectedItem = "COMPANY LUMPSUM";
            }
            else if (chkGrossAdd.Checked)
            {
                chkEmpBsTs.Checked = false;
                ChkEmpSal.Checked = false;
                ChkEmpBasic.Checked = false; chkEmpAmt.Checked = false;
            }
            else if (chkEmpAmt.Checked)
            {
                ChkEmpBasic.Checked = false;
                chkEmpBsTs.Checked = false;
                ChkEmpSal.Checked = false;
                chkGrossAdd.Checked = false;
                //chkEmpAmt.Checked = false;
                this.cmbcbasis.SelectedItem = "Independent";
                this.cmbctype.SelectedItem = "COMPANY LUMPSUM";
            }
        }

        private void cmbcbasis_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbcbasis.SelectedItem.ToString().ToLower() == "independent")
                {
                    lblMsg.Text = "* In General Formula";
                }
                else if (cmbcbasis.SelectedItem.ToString().ToLower() == "residual consolidated")
                {
                    lblMsg.Text = "* It is a calculation basis which is applicable on Other Allowance." + Environment.NewLine +
                        "* Its function is to calculate total O.A and then deduct with Total Salary.";
                }
                else if (cmbcbasis.SelectedItem.ToString().ToLower() == "conditional")
                {
                    lblMsg.Text = "* If we want to create any head which must be Conditional [like BS*35/100-1600]";
                }
                else if (cmbcbasis.SelectedItem.ToString().ToLower() == "inflow")
                {
                    lblMsg.Text = "* If we want to create any formula with *some added condition* and then " +
                        "the condition value is added with some other head, then we create it " +
                     "with Inflow Calculation Basis." + Environment.NewLine +
                    "* The final Fig is deducted with the Total Earning Salary";
                }
            }
            catch { }
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            //s = "select Location_Name from tbl_Emp_Location where Location_ID in (" + edpcom.CurrentLocation + ")";

            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID in (" + edpcom.CurrentLocation + ")");
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            clea_all();
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
            {
                Locations = Convert.ToInt32(cmbLocation.ReturnValue);
            }

            cmbsalstruc_DropDown(sender, e);
            try
            {
             //   get_ass();
            }
            catch (Exception x) { }
            try
            {
                cmbsalhead.Enabled = true;
                btnsalhead.Enabled = true;

                //ANURAG
                int count = Convert.ToInt32(clsDataAccess.GetresultS("select count(SLNO) from tbl_Employee_Assign_SalStructure WHERE (SAL_STRUCT = '" + get_SalStructID(cmbsalstruc.Text.Trim()) + "')"));

                //if (dgvfmula.Columns.Count > 0)
                //{
                //    btnCOPY.Visible = false;
                //}
                //else 
                if (count > 0)
                {
                    btnCOPY.Visible = false;
                }
                else
                {
                    btnCOPY.Visible = true;
                }

                cmbLocation.Text = cmbLocation.Text + " - " + clsDataAccess.ReturnValue("select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l where l.Location_ID =" + Locations);
            }
            catch (Exception x) { }

            hide_settings();
        }

        private void chkALK_Click(object sender, EventArgs e)
        {
            if (chkLoan.Checked == true)
            {
                // chkLoan.Checked = false;
                chkKit.Checked = false;
                chkAdvance.Checked = false;
                chkGrossAdd.Checked = false;
                chkFine.Checked = false;
                chkPerHour.Checked = false;
            }
            else if (chkKit.Checked == true)
            {
                chkLoan.Checked = false;
                //chkKit.Checked = false;
                chkAdvance.Checked = false;
                chkGrossAdd.Checked = false;
                chkFine.Checked = false;
            }
            else if (chkAdvance.Checked == true)
            {
                chkLoan.Checked = false;
                chkKit.Checked = false;
                chkGrossAdd.Checked = false;
                // chkAdvance.Checked = false;
                chkFine.Checked = false;
            }
            else if (chkGrossAdd.Checked == true)
            {
                chkLoan.Checked = false;
                chkKit.Checked = false;
                chkAdvance.Checked = false;
                //chkGrossAdd.Checked = false;
                chkFine.Checked = false;
            }
            else if (chkFine.Checked == true)
            {
                chkLoan.Checked = false;
                chkKit.Checked = false;
                chkAdvance.Checked = false;
                //chkGrossAdd.Checked = false;
                chkGrossAdd.Checked = false;
            }
            else
            {
                chkLoan.Checked = false;
                chkKit.Checked = false;
                chkAdvance.Checked = false;
                chkGrossAdd.Checked = false;
                chkFine.Checked = false;
            }
        }

        private void btnLinkSalStruct_Click(object sender, EventArgs e)
        {
            try
            {
                Employ_Link_LocationSalary ls = new Employ_Link_LocationSalary();
                ls.ShowDialog();
            }
            catch { }
        }

        private void chedailywages_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cmbDailyWages.Visible = false;
                if (chedailywages.Checked == true)
                {
                    cheattendence.Checked = false;
                    chkPerHour.Checked = false;
                    chkED.Checked = false;
                    cmbDailyWages.Visible = true;

                    chkTdays.Checked = false;
                    chkAtten_WD.Checked = false;
                    chkED.Checked = false;
                    //cheovertime.Checked = false;
                    if (chkAtten_WD.Checked == true)
                    {
                        cmbDailyWages.SelectedIndex = 4;
                    }
                    else
                    {
                        cmbDailyWages.SelectedIndex = 0;
                    }
                }
                //else if (cheattendence.Checked == true)
                //{
                //    chedailywages.Checked = false;
                //    chkPerHour.Checked = false;
                //    chkED.Checked = false;
                //    cmbDailyWages.Visible = true;

                //    chkTdays.Checked = false;
                //    chkAtten_WD.Checked = false;
                //    chkED.Checked = false;
                //    cheovertime.Checked = false;
                //}
                //else if (chkPerHour.Checked == true)
                //{
                //    chedailywages.Checked = false;
                //    cheattendence.Checked = false;

                //    chkED.Checked = false;
                //    cmbDailyWages.Visible = false;

                //    chkTdays.Checked = false;
                //    chkAtten_WD.Checked = false;
                //    chkED.Checked = false;
                //}
                else
                {
                    cmbDailyWages.Visible = false;
                }
            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.ToString());
            }

        }

        private void cheattendence_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cheattendence.Checked==true)
                {
                chedailywages.Checked = false;

                
                chkPerHour.Checked = false;
                chkED.Checked = false;
               // cmbDailyWages.Visible = true;

                chkTdays.Checked = false;
                chkAtten_WD.Checked = false;
                chkED.Checked = false;
                cheovertime.Checked = false;
                }

            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.ToString());
            }
        }

        private void txtremarks_TextChanged(object sender, EventArgs e)
        {

        }
        //Anurag
        private void btnCOPY_Click(object sender, EventArgs e)
        {
            cmbSalStructure.Visible = true;
            lblMsg.Text = "* New Salary Structure will be copied with "
                                + "Existing Salary Structure Formula Heads";
            cmbSalStructure.PopUp();
        }

        private void cmbSalStructure_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT DISTINCT (SELECT SalaryCategory FROM tbl_Employee_SalaryStructure WHERE (SlNo = eas.SAL_STRUCT)) AS SalaryCategory,"+
            "SAL_STRUCT AS SlNo,(SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = eas.Location_ID)) AS Location,"+
            "(SELECT (SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE (Client_id = el.Cliant_ID)) AS Client FROM tbl_Emp_Location AS el WHERE (Location_ID = eas.Location_ID)) AS Client FROM tbl_Employee_Assign_SalStructure AS eas where Location_ID!='0'");
                
        //        "select SalaryCategory,SlNo,"+
        //"(select (select Location_Name from tbl_Emp_Location where Location_ID=els.Location_ID) from  tbl_Employee_Link_SalaryStructure els where  SalaryStructure_ID=ess.SlNo)Location,"+
        //"(select (select (select Client_Name from tbl_Employee_CliantMaster where Client_id=el.Cliant_ID) as Client from tbl_Emp_Location el where Location_ID=els.Location_ID) from tbl_Employee_Link_SalaryStructure els where SalaryStructure_ID=ess.SlNo)Client from tbl_Employee_SalaryStructure ess");
            if (dt.Rows.Count > 0)
            {
                cmbSalStructure.LookUpTable = dt;
                cmbSalStructure.ReturnIndex = 1;
            }
        }

        private void cmbSalStructure_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Boolean boolStatus = false;
            btnCOPY.Visible = false;
            ERPMessageBox.ERPMessage.Show("Do you want to Copy Salary Structure from " + cmbSalStructure.Text.Trim(), "Question ?", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
            if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
            {
                Structure_ID = Convert.ToInt32(cmbSalStructure.ReturnValue);
                int sal_id = Convert.ToInt32(clsDataAccess.GetresultS("select SlNo from tbl_Employee_SalaryStructure where SalaryCategory = '" + cmbsalstruc.Text + "'"));
                //String comp_id = clsDataAccess.GetresultS("select Company_id from tbl_Employee_Assign_SalStructure where SAL_STRUCT = '" + Structure_ID + "'")['" + comp_id + "' as ];
                String sql = "insert into tbl_Employee_Assign_SalStructure select [P_TYPE],[SESSION],'" + sal_id + "' as [SAL_STRUCT],[SAL_HEAD],[V_FROM],"+
                "[V_TO],[C_BASIS],[C_TYPE],[C_DET],[PF_PER],[PF_VOL],[ESI_PER],[PT],[ROUND_TYPE],[TDSREFNO],[TDS_EXEMPT],[CARRY],[TDS_EXTRAPOL],[REMARKS],"+
                "[atten_day],[Proxy_day],[Daily_wages],[Revenue_Stamp],[Stamp_Amount],'" + Locations + "' as [Location_id],[Company_id],[EMP_BASIC],[chkALK],"+
                "[chkHide],[mod],[wd],[pt_basis],[no_round],[limit_day],[ldays],[alt_mon],[lvless],[gs],[lock],[chkFlag],[NCompliance] "+
                "from (select * from tbl_Employee_Assign_SalStructure where SAL_STRUCT= '" + Structure_ID + "') as em";

                boolStatus = clsDataAccess.RunNQwithStatus(sql);

                if (boolStatus)
                {
                    ERPMessageBox.ERPMessage.Show("Data Saved Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                    cmbsalstruc_DropDown(sender, e);
                    clea_all();
                    cmbSalStructure.Visible = false;


                    int count = Convert.ToInt32(clsDataAccess.GetresultS("select count(SLNO) from tbl_Employee_Assign_SalStructure WHERE (SAL_STRUCT = '" + get_SalStructID(cmbsalstruc.Text.Trim()) + "')"));

                    if (count > 0)
                    {
                        btnCOPY.Visible = false;
                    }
                    else
                    {
                        btnCOPY.Visible = true;
                    }
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbOtherOption_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOtherOption.Checked)
            {
                //cheattendence.Checked = false;
                //chedailywages.Checked = false;
                //cheovertime.Checked = false;
                cmbMOD.Visible = true;

            }
            else
            {
                cmbMOD.Visible = false;
                lblTo.Visible = false;
                tbFrom.Visible = false;
                tbTo.Visible = false;
            }
        }

        private void cmbMOD_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTo.Text = "to";

            if (cmbMOD.SelectedIndex == 0 || cmbMOD.SelectedIndex == 2)
            {
                lblTo.Visible = false;
                tbFrom.Visible = false;
                tbTo.Visible = false;

            }
            else if (cmbMOD.SelectedIndex == 3 || cmbMOD.SelectedIndex == 4)
            {
                lblTo.Visible = true;
                tbFrom.Visible = true;
                tbTo.Visible = true;

            }
            else if (cmbMOD.SelectedIndex == 1)
            {
                lblTo.Visible = false;

                tbFrom.Visible = true;
                tbTo.Visible = false;

            }
            else if (cmbMOD.SelectedIndex == 5)
            {
                lblTo.Visible = true;
                lblTo.Text = "x";
                tbFrom.Visible = true;
                tbFrom.Text = "0";
                tbTo.Visible = false;

            }
        }

        private void cmbWD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWD.SelectedIndex == 0 || cmbWD.SelectedIndex == 2)
            {
                lbl_wd_to.Visible = false;
                lbl_wd_to.Text = "to";
                txt_wd_from.Visible = false;
                txt_wd_to.Visible = false;

            }
            else if (cmbWD.SelectedIndex == 6 )
            {
                lbl_wd_to.Visible = false;
                lbl_wd_to.Text = "to";
                txt_wd_from.Visible = false;
                txt_wd_to.Visible = false;

                txt_wd_from.Text = "0";
                txt_wd_to.Text = "0";
                
            }
            else if (cmbWD.SelectedIndex == 3 || cmbWD.SelectedIndex == 4)
            {
                lbl_wd_to.Visible = true;
                lbl_wd_to.Text = "to";
                txt_wd_from.Visible = true;
                txt_wd_to.Visible = true;

            }
            else if (cmbWD.SelectedIndex == 1)
            {
                lbl_wd_to.Visible = false;
                lbl_wd_to.Text = "to";
                txt_wd_from.Visible = true;
                txt_wd_to.Visible = false;

            }
            else if (cmbWD.SelectedIndex == 5)
            {
                lbl_wd_to.Visible = true;
                lbl_wd_to.Text = "x";
                txt_wd_from.Visible = true;
                txt_wd_to.Visible = false;

            }
        }

        private void chkOtherWD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherWD.Checked)
            {               
                cmbWD.Visible = true;
                cmbWD.SelectedIndex = 0;
            }
            else
            {
                cmbWD.SelectedIndex = 0;
                cmbWD.Visible = false;
                lbl_wd_to.Visible = false;
                txt_wd_from.Visible = false;
                txt_wd_to.Visible = false;
            }
        }

        private void chkpt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpt.Checked == true)
            {
                txtPT.Text = "";
                
                cmb_pt.Visible = true;
                cmb_pt.SelectedIndex = 0;
                if (cmb_pt.SelectedIndex == 1)
                {
                    txtPT.Visible = true;
                }
                else
                {
                    txtPT.Visible = false;
                }
                lbl_pt_based.Visible = true;
            }
            else
            {
                txtPT.Text = "";

                cmb_pt.Visible = false;
                
                    txtPT.Visible = false;
                
                lbl_pt_based.Visible = false;
            }
        }

        private void cmb_pt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_pt.SelectedIndex == 1)
                {
                    txtPT.Visible = true;
                }
                else
                {
                    txtPT.Visible = false;
                }
            }
            catch { }
        }

        private void chkMinDays_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMinDays.Checked == false)
            {
                txtMinDays.Text = "0";
                txtMinDays.Visible = false;
            }
            else
            {
                txtMinDays.Visible = true;
            }
        }

        private void chkActiveMonths_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActiveMonths.Checked == true)
            {
                txtActiveMonths.Text = "";
                txtActiveMonths.Visible = true;
            }
            else
            {
                txtActiveMonths.Text = "";
                txtActiveMonths.Visible = false;
            }
        }

        private void chkLv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLv.Checked == true)
            {
                txtlessLv.Visible = true;
                txtlessLv.Text = "0";

                chkED.Checked = false;
                chkPerHour.Checked = false;
                chedailywages.Checked = false;
            }
            else
            {
                txtlessLv.Visible = false;
                txtlessLv.Text = "0";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (lbl_deduct_msg.Visible == false)
            {
                lbl_deduct_msg.Visible = true;
                lbl_ded_click.Text = "Click -";
            }
            else if (lbl_deduct_msg.Visible == true)
            {
                lbl_deduct_msg.Visible =false;
                lbl_ded_click.Text = "Click +";
            }
        }

        private void lbl_adtn_click_Click(object sender, EventArgs e)
        {
            if (lblMsg2.Visible == false)
            {
                lbl_msg_addopt.Visible = true;
                lblMsg2.Visible = true;
                lbl_adtn_click.Text = "Click -";
            }
            else if (lblMsg2.Visible == true)
            {
                lbl_msg_addopt.Visible = false;
                lblMsg2.Visible = false;
                lbl_adtn_click.Text = "Click +";
            }
        }

        private void chkPerHour_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPerHour.Checked == true)
            {
                chedailywages.Checked = false;
                cheattendence.Checked = false;

               
                chkLv.Checked = false;
                chkTdays.Checked = false;
                chkAtten_WD.Checked = false;
                chkED.Checked = false;
            }
        }

        private void cheovertime_CheckedChanged(object sender, EventArgs e)
        {
            if (cheovertime.Checked == true)
            {
                
                cheattendence.Checked = false;

                //chkPerHour.Checked = false;
                chkED.Checked = false;
                //cmbDailyWages.Visible = true;

                chkTdays.Checked = false;
                chkAtten_WD.Checked = false;
                chkED.Checked = false;
                

            }
        }

        private void chkED_CheckedChanged(object sender, EventArgs e)
        {
            if (chkED.Checked == true)
            {

                chkLv.Checked = false;
                chkPerHour.Checked = false;
               

            }
        }

        private void cmb_SalHead_DropDown(object sender, EventArgs e)
        {
            //DataTable dt = clsDataAccess.RunQDTbl("select salaryhead_short,SlNo,'E' as Type from tbl_Employee_ErnSalaryHead order by Slno");

            //DataTable dt_D = clsDataAccess.RunQDTbl("select salaryhead_short,SlNo,'D' as Type from tbl_Employee_DeductionSalayHead order by Slno");

            //dt.Merge(dt_D);
            //if (dt.Rows.Count > 0)
            //{
            //    DataView dv = dt.DefaultView;
            //    dv.Sort = "Type";
            //    cmb_SalHead.LookUpTable = dv.Table;
            //    cmb_SalHead.ReturnIndex = 1;
            //}

            if (cmbLocation.Text.Trim() == "" || cmbsalhead.Text.Trim() == "")
            {
                MessageBox.Show("Select Location / Salary Head / Type", "BRAVO");
                return;
            }
            string s = ""; DataTable dt = new DataTable();
            //cmboth.Items.Clear();
            cmboth.Text = "";
            if (cmbctype.Text == "FORMULA")
            {
                s = "select distinct fname from tbl_Employee_Sal_Structure_Formula";
                //Load_Data(s, cmboth, -1);
            }
            else if (cmbctype.Text == "COMPANY LUMPSUM")
            {
                s = "select distinct lumpname from tbl_Employee_Lumpsum where lumptype=0";
               // Load_Data(s, cmboth, -1);
            }
            else if (cmbctype.Text == "SAL STRUCTURE LUMPSUM")
            {
                s = "select lumpname from tbl_Employee_Lumpsum where strucid=" + Sal_ID() + " and lumptype=1";
               // Load_Data(s, cmboth, -1);
            }
            else if (cmbctype.Text == "SLAB")
            {
                s = "select slabname from tbl_Employee_Slab_Def s,tbl_Employee_Slab_Det d where s.slabid=d.slabid";
                // Load_Data(s, cmboth, -1);
            }
            else
            {

                MessageBox.Show("Select Type first","BRAVO");
                return;
            }
            dt = clsDataAccess.RunQDTbl(s);
            cmboth.LookUpTable = dt;
            cmboth.ReturnIndex = 0;
        }

        private void cmb_SalHead_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            //try
            //{
            //    txtfull_name.Enabled = true;
            //    cmbvfrom.Enabled = true;
            //    cmbvto.Enabled = true;
            //    cmbcbasis.Enabled = true;
            //    //btncalcbs.Enabled = true;
            //    cmbctype.Enabled = true;
            //    cmboth.Enabled = true;
            //    btnfmula.Enabled = true;
            //    txtremarks.Enabled = true;
            //    txtpf.Enabled = true;
            //    chkpf.Enabled = true;
            //    chestump.Enabled = true;
            //    chkroundoff.Enabled = true;
            //    chkpt.Enabled = true;
            //    chkesi.Enabled = true;
            //}
            //catch (Exception x) { }
            //string[] salhead = cmbsalhead.Text.Trim().ToString().Split('-');
            //try
            //{
            //    txtfull_name.Text = sal_Head_Name('E', salhead[0].Trim());
            //    if (txtfull_name.Text == "")
            //    {
            //        txtfull_name.Text = sal_Head_Name('D', salhead[0].Trim());
            //        chkGrossAdd.Checked = false;
            //    }
            //    else
            //    {
            //        chkGrossAdd.Checked = false;
            //    }
            //}
            //catch (Exception x) { }

            //try
            //{
            //    ResetAllChkBox();
            //    if (cmbsalhead.Text.ToUpper() == "PF")
            //    {
            //        chkpf.Checked = true;
            //        cmbctype.SelectedItem = "FORMULA";
            //    }
            //    if (cmbsalhead.Text.ToUpper() == "ESI")
            //    {
            //        this.chkesi.Checked = true;
            //        cmbctype.SelectedItem = "FORMULA";
            //    }
            //    if (cmbsalhead.Text.ToUpper() == "P.TAX" || cmbsalhead.Text.ToUpper() == "PTAX")
            //    {
            //        this.chkpt.Checked = true;
            //        cmbctype.SelectedItem = "COMPANY LUMPSUM";
            //        cmboth.Enabled = false;
            //    }
            //    if (cmbsalhead.Text.ToUpper() == "LOAN")
            //    {
            //        this.chkLoan.Checked = true;
            //        cmbctype.SelectedItem = "COMPANY LUMPSUM";
            //        cmboth.Enabled = false;
            //    }
            //    if (cmbsalhead.Text.ToUpper() == "ADV")
            //    {
            //        this.chkAdvance.Checked = true;
            //        cmbctype.SelectedItem = "COMPANY LUMPSUM";
            //        cmboth.Enabled = false;
            //    }
            //    if (cmbsalhead.Text.ToUpper() == "FINE")
            //    {
            //        this.chkFine.Checked = true;
            //        cmbctype.SelectedItem = "COMPANY LUMPSUM";
            //        cmboth.Enabled = false;
            //    }
            //    if (cmbsalhead.Text.ToUpper() == "KIT" || cmbsalhead.Text.ToUpper() == "KT" || cmbsalhead.Text.ToUpper() == "KITS" || cmbsalhead.Text.ToUpper() == "UNIFORM")
            //    {
            //        this.chkKit.Checked = true;
            //        cmbctype.SelectedItem = "COMPANY LUMPSUM";
            //        cmboth.Enabled = false;
            //    }
            //    if (cmbsalhead.Text.ToUpper() == "BS")
            //    {
            //        cheattendence.Checked = true;
            //        cheovertime.Enabled = false;
            //        chkED.Enabled = false;
            //        chkED.Checked = false;
            //        chkHide.Enabled = false;
            //    }
            //    if (cmbsalhead.Text.ToUpper() == "OTA" || cmbsalhead.Text.ToUpper() == "OT")
            //    {
            //        cheovertime.Checked = true;
            //        chkED.Checked = false;
            //        cheattendence.Enabled = true;
            //        chedailywages.Enabled = true;
            //        chkGrossAdd.Checked = false;

            //    }
            //    if (cmbsalhead.Text.ToUpper() == "SOCIETY" || cmbsalhead.Text.ToUpper() == "SOC")
            //    {
            //        cheattendence.Checked = false;
            //        cheovertime.Enabled = false;
            //        chkED.Enabled = false;
            //        chkED.Checked = false;
            //        chkHide.Enabled = false;
            //        chkAtten_WD.Checked = false;
            //        chkSociety.Checked = true;

            //    }

            //    if (cmbsalhead.Text.ToUpper() == "ED" || cmbsalhead.Text.ToUpper() == "ED")
            //    {
            //        cheovertime.Checked = false;
            //        chkED.Checked = true;
            //        cheattendence.Enabled = true;
            //        chedailywages.Enabled = true;
            //        chkED.Enabled = true;

            //    }

            //    cmbcbasis.SelectedItem = "Independent";
            //}
            //catch { }


            if (cmboth.Text.Trim() != "" && cmbctype.Text.Trim() == "FORMULA")
            {
                if (btnsave.Enabled == false)
                {
                    btnsave.Enabled = true;
                }

            }

        }

        private void cmbctype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkAfterDeductionEffect_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkPS_H_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNC.Checked == true)
            {
                chkShowAfterNet.Checked = true;
            }
            else if (chkNC.Checked == false)
            {
                chkShowAfterNet.Checked = false;
            }
        }


      

       






    }
}