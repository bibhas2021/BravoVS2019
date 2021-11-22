using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PayRollManagementSystem
{
    public partial class Config_SalaryStructure_Formula : Form // EDPComponent .FormBaseERP 
    {
        public Config_SalaryStructure_Formula()
        {
            InitializeComponent();

        }

        public const Int32 strColCount = 3;
        DataTable dt_fm = new DataTable();        
            DataRow dr;
            DataColumn dc1 = new DataColumn("Name");
            DataColumn dc2 = new DataColumn("Expression");
            DataColumn dc3 = new DataColumn("Desg");
            DataColumn dc4 = new DataColumn("desgid");
            DataColumn dc5 = new DataColumn("fid");
        Hashtable SalHead = new Hashtable();
        Hashtable SalHead1 = new Hashtable();
        Hashtable chk_fmula = new Hashtable();
        Hashtable chk_op = new Hashtable(); 
        bool ok = false;
        
            
        #region Functions

        private String[,] GetSalaryHeads()
        {
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");
            String[,] strArr = new String[dtErn.Rows.Count + dtDeduction.Rows.Count, strColCount];
            for (Int32 i = 0; i < dtErn.Rows.Count; i++)
            {
                strArr[i,0] = Convert.ToString(dtErn.Rows[i]["SalaryHead_Short"]);
                strArr[i,1] = Convert.ToString(dtErn.Rows[i]["SlNo"]);
                strArr[i, 2] = Convert.ToString("tbl_Employee_ErnSalaryHead");
                if (!SalHead.ContainsKey(dtErn.Rows[i][0].ToString()))
                    SalHead.Add(dtErn.Rows[i][0].ToString(), Gen_ID("S", dtErn.Rows[i][1].ToString()));
                if (!SalHead1.ContainsKey(Gen_ID("S", dtErn.Rows[i][1].ToString())))
                    SalHead1.Add(Gen_ID("S", dtErn.Rows[i][1].ToString()), dtErn.Rows[i][0].ToString());
            }
            for (Int32 i = 0; i < dtDeduction.Rows.Count; i++)
            {
                strArr[dtErn.Rows.Count + i,0] = Convert.ToString(dtDeduction.Rows[i]["SalaryHead_Short"]);
                strArr[dtErn.Rows.Count + i,1] = Convert.ToString(dtDeduction.Rows[i]["SlNo"]);
                strArr[dtErn.Rows.Count + i, 2] = Convert.ToString("tbl_Employee_DeductionSalayHead");
                if (!SalHead.ContainsKey(dtDeduction.Rows[i][0].ToString()))
                    SalHead.Add(dtDeduction.Rows[i][0].ToString(), Gen_ID("D", dtDeduction.Rows[i][1].ToString()));
                if(!SalHead1.ContainsKey(Gen_ID("D", dtDeduction.Rows[i][1].ToString())))
                    SalHead1.Add(Gen_ID("D", dtDeduction.Rows[i][1].ToString()),dtDeduction.Rows[i][0].ToString());
            }
            return strArr;
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

        private String[] GetOperators()
        {
            //String[] strArrOp ={ "(", ")", "[", "]", "/", "*", "%", "+", "-", "=" };
            String[] strArrOp = { "/", "*", "+", "-", "=", "(", ")", ">", "<","trunc()" };
            return strArrOp;
        }

        private void PopulateSalaryHeadListBox()
        {
            for (Int32 i = 0; i < (GetSalaryHeads().Length / strColCount); i++)
            {
                lstSalaryHead.Items.Add(GetSalaryHeads()[i, 0]);
            } 
        }

        private void PopulateOperators()
        {
            for (Int32 i = 0; i < GetOperators().Length; i++)
            {
                lstOperators.Items.Add(GetOperators()[i]);
            }
        }

        private void DigitButtonClick(Button btn)
        {
            txtFormula.Text += btn.Text;
        }

        private Boolean IsOperator(String strText )
        {
            Boolean boolStatus = false;

            for (Int32 j = 0; j < GetOperators().Length; j++)
            {
                if (GetOperators()[j] == strText)
                {
                    boolStatus = true;
                }
            }

            return boolStatus;
        }

        private Boolean OperatorcanPlaceAtLast(String strOp)
        {
            Boolean boolStatus = false;
            //String[] strArrOp ={ "(", ")", "[", "]", "%"};
            String[] strArrOp ={ "%" };
            if (IsOperator(strOp))
            {
                for (Int32 i = 0; i < strArrOp.Length; i++)
                {
                    if (strOp == strArrOp[i])
                    {
                        boolStatus = true;
                    }
                }
            }
            return boolStatus;
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

        private Boolean CheckSalaryHeadInFormula()
        {
            Boolean boolStatus = false;
            Int32 intOpMatchCounter = 0;
            Int32 intTotalSalaryHead = 0;
            Int32 intHeadMatchCounter = 0;
            String strSalaryHead = String.Empty;
            String strFormula = txtFormula.Text.Trim();

            if (!String.IsNullOrEmpty(strFormula))
            {
                for (Int32 i = 0; i <= strFormula.Length; i++)
                {
                    if (i == strFormula.Length)
                    {
                        try
                        {
                            if (!OperatorcanPlaceAtLast(Convert.ToString(strFormula[strFormula.Length - 1])))
                            {
                                Int32 intSal = Convert.ToInt32(strSalaryHead);
                            }
                        }
                        catch
                        {
                            boolStatus = false;
                            for (Int32 k = 0; k < (GetSalaryHeads().Length / strColCount); k++)
                            {
                                if (strSalaryHead.ToLower() == GetSalaryHeads()[k, 0].ToLower())
                                {
                                    boolStatus = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        intOpMatchCounter = 0;
                        for (Int32 j = 0; j < (GetOperators().Length); j++)
                        {
                            if (Convert.ToString(strFormula[i]) == GetOperators()[j])
                            {
                                intOpMatchCounter += 1;
                            }
                        }
                        if (intOpMatchCounter > 0)
                        {
                            if (!String.IsNullOrEmpty(strSalaryHead))
                            {
                                try
                                {
                                    Int32 intSal = Convert.ToInt32(strSalaryHead);
                                }
                                catch
                                {
                                    intTotalSalaryHead += 1;
                                    for (Int32 k = 0; k < (GetSalaryHeads().Length / strColCount); k++)
                                    {
                                        if (strSalaryHead.ToLower() == GetSalaryHeads()[k, 0].ToLower())
                                        {
                                            intHeadMatchCounter += 1;
                                        }
                                    }
                                }

                            }
                            strSalaryHead = String.Empty;
                        }
                        else
                        {
                            strSalaryHead += strFormula[i];
                        }

                        if (intTotalSalaryHead == intHeadMatchCounter)
                        {
                            boolStatus = true;
                        }
                    }
                }
            }
            return boolStatus;
        }

        private void SaveFormula()
        {
            Boolean boolStatus = false;
            int hb = 0,desgid=0;// chk_fmula.Count + 1;
            string s = "";
            s = "Select max(FID) from tbl_Employee_Sal_Structure_Formula";
            DataTable max_No = clsDataAccess.RunQDTbl(s);
            if (Information.IsNumeric(max_No.Rows[0][0]) == true)
                hb = Convert.ToInt32(max_No.Rows[0][0]) + 1;
            else
                hb = 1;

            if (rbeveryone.Checked == true)
            {
                desgid = 0;
            }
            else
            {
                desgid = Convert.ToInt32(cmbDesignation.ReturnValue);
                    //Get_Grade(cmbgrade.Text.Trim());
            }

            if (clsValidation.ValidateTextBox(txtfname, "", "Please Enter Formula Name"))
            {
                if (clsValidation.ValidateTextBox(txtFormula, "", "Please Enter Formula"))
                {
                    int intMatchCounter = 0;
                    //String strFormula = txtFormula.Text.Substring(0, txtFormula.Text.LastIndexOf('='));
                    //for (Int32 i = 0; i < (GetSalaryHeads().Length / strColCount); i++)
                    //{
                    //    if (strFormula.ToLower() == GetSalaryHeads()[i, 0].ToLower())
                    //    {
                            //if (CheckSalaryHeadInFormula())
                            //{
                                //intMatchCounter += 1;
                    if (chk_fmula.ContainsKey(txtfname.Text) && lbl_fid.Text.Trim() != "")
                    {
                        boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Sal_Structure_Formula set fexp='" + Encode(1, txtFormula.Text.Trim()) + "',desgid='" + desgid + "' where (fname='" + txtfname.Text.Trim() + "') and (fid='" + lbl_fid.Text.Trim() + "')");
                    }
                    else
                    {
                        if (clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Sal_Structure_Formula where (fname='" + txtfname.Text.Trim() + "') and (desgid='" + desgid + "')") == "0")
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Sal_Structure_Formula values(" + hb + ",'" + txtfname.Text.Trim() + "','" + Encode(1, txtFormula.Text.Trim()) + "','" + desgid + "')");

                        }
                        else
                        {
                            boolStatus = false;
                            if (MessageBox.Show("Formula Already Saved with same designation and formula, Want to Add more?", "BRAVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {  txtFormula.Text = "";
                                //txtfname.Text ="";
                                lbl_fid.Text = "";
                                rbeveryone.Checked = true;
                                cmbDesignation.Text = "";
                            }
                            else
                            {
                                txtfname.Text = "";
                                txtFormula.Text = "";
                                lbl_fid.Text = "";
                                rbeveryone.Checked = true;
                                cmbDesignation.Text = "";
                            }
                        }

                    }
                                //Boolean boolStatus = clsDataAccess.RunNQwithStatus("update " + GetSalaryHeads()[i, 2] + " set FORMULA='" + txtFormula.Text.Trim() + "' where SlNo=" + GetSalaryHeads()[i, 1] + "");

                                if (boolStatus)
                                 {
                                     if (MessageBox.Show("Formula Saved Successfully, Want to Add more?", "BRAVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                     {

                                         txtFormula.Text = "";
                                         //txtfname.Text ="";
                                         lbl_fid.Text = "";
                                         rbeveryone.Checked = true;
                                         cmbDesignation.Text = "";
                                     }
                                     else
                                     {
                                         txtfname.Text = "";
                                         txtFormula.Text = "";
                                         lbl_fid.Text = "";
                                         rbeveryone.Checked = true;
                                         cmbDesignation.Text = "";
                                     }
                                }
                            //}
                        //}
                    //}
                    //if (intMatchCounter <= 0)
                    //{
                    //    ERPMessageBox.ERPMessage.Show("Formula Cannot Be Generated For a Invalid Salary Head");
                    //}

                }
            }
        }

        private void GetFormula()
        {
            dt_fm.Clear();
            dt_fm.Columns.Clear();

            DataTable dt = new DataTable();
            dt_fm.Columns.Add(dc1);
            dt_fm.Columns.Add(dc2);
            dt_fm.Columns.Add(dc3);
            dt_fm.Columns.Add(dc4);
            dt_fm.Columns.Add(dc5);
            string fname = "";
            if (txtSearch.Text=="")
                fname = "select fname,fexp,(case when esf.desgid=0 then 'Everyone' else (select isNUll(DesignationName,'') from tbl_Employee_DesignationMaster where SlNo=esf.desgid) end)'Desg',desgid,fid from tbl_Employee_Sal_Structure_Formula esf order by fname,fid";
            else
                fname = "select fname,fexp,(case when esf.desgid=0 then 'Everyone' else (select isNUll(DesignationName,'') from tbl_Employee_DesignationMaster where SlNo=esf.desgid) end)'Desg',desgid,fid from tbl_Employee_Sal_Structure_Formula esf where fname like '" + txtSearch.Text.Trim() + "%'  order by fname,fid";

            dt = clsDataAccess.RunQDTbl(fname);
            if (dt.Rows.Count > 0)
            {
                for(int y=0;y<dt.Rows.Count;y++)
                {
                     dr = dt_fm.NewRow();
                     dr[0] = dt.Rows[y][0].ToString();
                     dr[1] =Encode(2, dt.Rows[y][1].ToString());
                     dr[2] = dt.Rows[y]["Desg"].ToString();
                     dr[3] = dt.Rows[y]["desgid"].ToString();
                     dr[4] = dt.Rows[y]["fid"].ToString();
                     dt_fm.Rows.Add(dr);
                    if(!chk_fmula.ContainsKey(dt.Rows[y][0].ToString()))
                    chk_fmula.Add(dt.Rows[y][0].ToString(),Encode(2,dt.Rows[y][1].ToString()));

                }
            }
            dgvfmula.DataSource = "";
            dgvfmula.DataSource=dt_fm;
            dgvfmula.Columns[0].Width = 165;
            dgvfmula.Columns[1].Width = 185;
            dgvfmula.Columns["desgid"].Visible = false;
            dgvfmula.Columns["fid"].Visible = false;
            if (dt_fm.Rows.Count == 1)
            {
                try
                {
                    txtfname.Text = dgvfmula.Rows[0].Cells[0].Value.ToString();
                    txtFormula.Text = dgvfmula.Rows[0].Cells[1].Value.ToString();
                    lbl_fid.Text = dgvfmula.Rows[0].Cells["fid"].Value.ToString().Trim();
                }
                catch (Exception x) { }
                try
                {
                    if (dgvfmula.Rows[0].Cells["desgid"].Value.ToString().Trim() == "0")
                    {
                        rbeveryone.Checked = true;
                    }
                    else
                    {
                        rbgradewise.Checked = true;
                        //cmbgrade.Text = dgvfmula.Rows[0].Cells["Desg"].Value.ToString().Trim();
                        //cmbgrade.SelectedText = dgvfmula.Rows[0].Cells["Desg"].Value.ToString().Trim();

                        cmbDesignation.ReturnValue = dgvfmula.Rows[0].Cells["desgid"].Value.ToString().Trim();
                        cmbDesignation.Text = dgvfmula.Rows[0].Cells["Desg"].Value.ToString().Trim();

                    }
                }
                catch { }
            }
        }


        public int Get_Grade(string Gname)
        {
            string qry = ""; int res = 0;
            //qry = "select slno from tbl_Employee_Sectionmaster where section='" + Gname + "'";
            qry = "select SlNo from tbl_Employee_DesignationMaster where DesignationName='" + Gname + "'";
            DataTable dtqry = new DataTable();
            dtqry = clsDataAccess.RunQDTbl(qry);
            if (dtqry.Rows.Count > 0)
            {
                res = Convert.ToInt32(dtqry.Rows[0][0]);
            }

            if (Gname.Trim() == "")// 07-06-2018 set the value to 0 if designation name is blank
            {
                res = 0;
            }
            return res;
        }

        #endregion

        #region Events

        private void Config_SalaryStructure_Load(object sender, EventArgs e)
        {
             string s = "";
            try
            {

             s=clsDataAccess.ReturnValue("Select desg_formula from CompanyLimiter");
                if (s.Trim()=="0")
                {
                    rbeveryone.Checked=true;

                    rbeveryone.Visible=false;
                    rbgradewise.Visible=false;
                    lbltype.Visible=false;
                    lblgrade.Visible=false;
                    //cmbgrade.Visible=false;
                    cmbDesignation.Visible = false;
                }
            }
            catch { }

            try
            {
                PopulateSalaryHeadListBox();
                PopulateOperators();
                GetFormula();
                chk_op.Add("0","");
                chk_op.Add("1","");
                chk_op.Add("2","");
                chk_op.Add("3","");
                chk_op.Add("4","");
                chk_op.Add("5","");
                chk_op.Add("6","");
                chk_op.Add("7","");
                chk_op.Add("8","");
                chk_op.Add("9","");
                chk_op.Add("10","");
                chk_op.Add(".","");
            }
            catch (Exception x) { }


           //s="select DesignationName from tbl_Employee_DesignationMaster";
           // Load_Data(s, cmbgrade, -1);
        }

        private void lstSalaryHead_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtFormula.Text += lstSalaryHead.SelectedItem.ToString();
        }

        private void lstOperators_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstOperators.SelectedItem.ToString() != "trunc()")
                txtFormula.Text += lstOperators.SelectedItem.ToString();
            else
                txtFormula.Text += lstOperators.SelectedItem.ToString().Substring(0, lstOperators.SelectedItem.ToString().Length - 1);
        }

        private void txtFormula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Int32 intAscii = Convert.ToInt32(e.KeyChar);
            if (intAscii != 8)
            {
                e.Handled = true;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            DigitButtonClick(btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            DigitButtonClick(btn2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            DigitButtonClick(btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            DigitButtonClick(btn4);
        }

        private void b4n5_Click(object sender, EventArgs e)
        {
            DigitButtonClick(btn5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            DigitButtonClick(btn6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            DigitButtonClick(btn7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            DigitButtonClick(btn8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            DigitButtonClick(btn9);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            DigitButtonClick(btn0);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            DigitButtonClick(btnDot);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtFormula.Text = String.Empty;
                txtfname.Text = "";
                cmbDesignation.Text = "";
                rbeveryone.Checked = true;
            }
            catch (Exception x) { }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                verify_formula(txtFormula.Text.Trim());
                if (!ok)
                   ERPMessageBox.ERPMessage.Show("Formula is Not Correct", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                if (ok)
                {
                    SaveFormula();
                    GetFormula();
                }

            }
            catch (Exception x) { }
        }
        
        private void lstSalaryHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetFormula();
            //CheckConsicutiveSalaryHeads();
        }
        #endregion

        private void dgvfmula_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtfname.Text = dgvfmula.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtFormula.Text = dgvfmula.Rows[e.RowIndex].Cells[1].Value.ToString();

                lbl_fid.Text = dgvfmula.Rows[e.RowIndex].Cells["fid"].Value.ToString().Trim();
            }
            catch (Exception x) { }
            try
            {
                if (dgvfmula.Rows[e.RowIndex].Cells["desgid"].Value.ToString().Trim() == "0")
                {
                    rbeveryone.Checked = true;
                }
                else
                {
                    rbgradewise.Checked = true;
                    lblDesg.Text = dgvfmula.Rows[e.RowIndex].Cells["Desg"].Value.ToString().Trim();
                    //cmbgrade.Text = dgvfmula.Rows[e.RowIndex].Cells["Desg"].Value.ToString().Trim();
                    //cmbgrade.SelectedText = dgvfmula.Rows[e.RowIndex].Cells["Desg"].Value.ToString().Trim();

                    cmbDesignation.Text = dgvfmula.Rows[e.RowIndex].Cells["Desg"].Value.ToString().Trim();
                    cmbDesignation.ReturnValue = dgvfmula.Rows[e.RowIndex].Cells["desgid"].Value.ToString().Trim();

                }
            }
            catch { }
        }
        public string Encode(int i1, string str)
        {
            int g = 0, i = 0;
            string fmula = "";
            if (i1 == 1)
            {
                for (int f = 0; f < str.Length; f++)
                {

                    if (str.Substring(f, 1) == "=" || str.Substring(f, 1) == "*" || str.Substring(f, 1) == "+" || str.Substring(f, 1) == "-" || str.Substring(f, 1) == "/" || str.Substring(f, 1) == "%" || str.Substring(f, 1) == "(" || str.Substring(f, 1) == ")" || str.Substring(f, 1) == "<" || str.Substring(f, 1) == ">")
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

                    if (str.Substring(f, 1) == "=" || str.Substring(f, 1) == "*" || str.Substring(f, 1) == "+" || str.Substring(f, 1) == "-" || str.Substring(f, 1) == "/" || str.Substring(f, 1) == "%" || str.Substring(f, 1) == "(" || str.Substring(f, 1) == ")" || str.Substring(f, 1) == "<" || str.Substring(f, 1) == ">")
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                del();
                GetFormula();
            }
            catch (Exception x) { }
        }


        public int chk_frm(string fname)
        {

            return Convert.ToInt32(clsDataAccess.ReturnValue("select COUNT(*) from tbl_Employee_Assign_SalStructure where (C_TYPE='FORMULA') and (C_DET in (select fid from tbl_Employee_Sal_Structure_Formula where FName='"+fname+"'))"));
        }

        public void del()
        {
            bool sta = false;
            if (clsValidation.ValidateTextBox(txtfname, "", "Formula name can't be blank"))
            {
                if (clsValidation.ValidateTextBox(txtFormula, "", "Formula Expression can't be blank"))
                {
                    if (chk_frm(txtfname.Text.Trim()) == 0)
                    {

                        ERPMessageBox.ERPMessage.Show("Do U Want to Delete " + txtfname.Text.Trim(), "Question", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
                        if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
                            sta = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Sal_Structure_Formula where (fname='" + txtfname.Text.Trim() + "')");
                        if (sta)
                        {
                            ERPMessageBox.ERPMessage.Show("Formula Deleted Sucessfully");
                            txtfname.Text = string.Empty;
                            txtFormula.Text = string.Empty;
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Formula already tagged in salary structure,Cannot delete");
                        return;
                    }
                }
            }
        }

        private void btnverify_Click(object sender, EventArgs e)
        {
            try
            {
                verify_formula(txtFormula.Text.Trim());
                if (ok)
                    ERPMessageBox.ERPMessage.Show("Formula is Correct", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                else
                    ERPMessageBox.ERPMessage.Show("Formula is Not Correct", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
            catch (Exception x) { }


        }
        public void verify_formula(string str)
        {
           int g = 0, i = 0;
           bool shead = false, chrA2Z = false, equi = false, lastop = false, sd = false;
           ok = false;

/*---------------------------------------------------Coded by Dwipraj Dutta-------------------------------------------------------------------------*/            
           string exp = str;
           Stack<String> opearatorStack = new Stack<String>();
           Stack<String> opearendStack = new Stack<String>();

           //f will work as a (
           exp = exp.Replace("trunc(", "(");
           exp = exp.Replace("<=","<");
           exp = exp.Replace(">=", ">");
           exp = exp.Trim();

           if ((exp.IndexOf("<") != exp.LastIndexOf("<"))||(exp.IndexOf(">") != exp.LastIndexOf(">")))
           {
               if (exp.ToLower().Contains("if") == true || exp.ToLower().Contains("iif") == true)
               {

                   ok = true;
               }
               else
               {
                   ok = false;
               }
               return;
           }
           String result = "rslt";
           //this will work as stringtokenizer in java.... 
           string[] tokens = Regex.Split(exp, @"([\(\)\<\>/+*-])");
            //have to change above line as it is hardcoded...
           for (int tknl = 0; tknl < tokens.Length;tknl++ )
           {
               if (tokens[tknl] == "")
                   continue;
               if (Array.IndexOf(GetOperators(), tokens[tknl]) > -1 || SalHead.ContainsKey(tokens[tknl]) || IsDigitsOnly(tokens[tknl]))
               {
                   if (tokens[tknl] == "(")
                       opearendStack.Push(tokens[tknl]);
                   else if (tokens[tknl] == ")")
                   {
                       Boolean flag = false;
                       while (opearendStack.Count != 0)
                       {
                           String oprnd = opearendStack.Pop();
                           if (oprnd == "(")
                           {
                               flag = true;
                               break;
                           }
                           opearatorStack.Pop();
                           opearatorStack.Pop();
                           opearatorStack.Push(result);
                       }
                       if (!flag)
                       {
                           ok = false;
                           return;
                       }
                   }
                   else if (Array.IndexOf(GetOperators(), tokens[tknl]) > -1)
                   {
                       if (opearendStack.Count == 0)
                       {
                           opearendStack.Push(tokens[tknl]);
                       }
                       else
                       {
                           if (chkPrecedence(opearendStack.Peek(), tokens[tknl]))
                           {
                               if (opearatorStack.Count < 2)
                               {
                                   ok = false;
                                   return;
                               }
                               opearatorStack.Pop();
                               opearatorStack.Pop();
                               opearendStack.Pop();
                               opearatorStack.Push(result);
                               opearendStack.Push(tokens[tknl]);
                           }
                           else
                           {
                               opearendStack.Push(tokens[tknl]);
                           }
                       }
                   }
                   else if (tokens[tknl].Contains("="))
                   {
                       ok = false;
                       return;
                   }
                   else
                   {
                       if (tokens[tknl].IndexOf('.') != tokens[tknl].LastIndexOf('.'))
                       {
                           ok = false;
                           return;
                       }
                       opearatorStack.Push(tokens[tknl]);
                   }
               }
           }
            if(opearatorStack.Count-opearendStack.Count==1)
            {
                ok = true;
                return;
            }
            else
            { 
                ok = false;
                return;
            }

/*----------------------------------------------------------------End----------------------------------------------------------------------*/

/*            for (int f = 0; f < str.Length; f++)
            {
                string x1 = str.Substring(str.Length - 1, 1);
                if (str.Substring(str.Length - 1, 1) == "=" || str.Substring(str.Length - 1, 1) == "*" || str.Substring(str.Length - 1, 1) == "<=" || str.Substring(str.Length - 1, 1) == "+" || str.Substring(str.Length - 1, 1) == "-" || str.Substring(str.Length - 1, 1) == "/" || str.Substring(str.Length - 1, 1) == ".")
                    lastop = false;
                else
                    lastop = true;

                if (str.Substring(str.Length - 1, 1) == ")" && str.Substring(str.Length - 2, 1) == ")")
                    lastop = false;

                //|| str.Substring(str.Length - 1, 1) == "0"
                if (str.Substring(f, 1) == "=" || str.Substring(f, 1) == "*" || str.Substring(str.Length - 1, 1) == "<" || str.Substring(f, 1) == "+" || str.Substring(f, 1) == "-" || str.Substring(f, 1) == "/" || str.Substring(f, 1) == "%" || str.Substring(f, 1) == "(" || str.Substring(f, 1) == ")")
                {
                    string x = str.Substring(g, 1);
                    if (str.Substring(f, 1) == "=")
                        equi = true;
                    if (SalHead.ContainsKey(str.Substring(g, i)))
                        shead = true;
                    else
                    {
                        if (chk_op.ContainsKey(str.Substring(g, i)))
                            shead = true;
                        else
                        {
                            //string x5 = str.Substring(f + 1, 1);
                            //string x2 = str.Substring(f , 1);
                            //if (str.Substring(f, 1) == "(" || str.Substring(f, 1) == ")")
                            if ((str.Substring(f, 1) == "=" || str.Substring(f, 1) == "*" || str.Substring(f, 1) == "<" || str.Substring(f, 1) == "+" || str.Substring(f, 1) == "-" || str.Substring(f, 1) == "/" || str.Substring(f, 1) == "%" || str.Substring(f, 1) == "(" || str.Substring(f, 1) == ")") && (str.Substring(f + 1, 1) != "=" || str.Substring(f + 1, 1) != "*" || str.Substring(f + 1, 1) != "<=" || str.Substring(f + 1, 1) != "+" || str.Substring(f + 1, 1) != "-" || str.Substring(f + 1, 1) != "/" || str.Substring(f + 1, 1) != "%" || str.Substring(f + 1, 1) != "("))
                                shead = true;
                            else
                            {
                                shead = false;
                                break;
                            }
                        }
                    }
                    i = 0;
                    g = f + 1;
                }
                else
                {


                    //char x = Convert.ToChar(str.Substring(f, 1));
                    //string x1 = str.Substring(f, 1);
                    if ((Convert.ToChar(str.Substring(f, 1)) >= 'A' && Convert.ToChar(str.Substring(f, 1)) <= 'Z') || (Convert.ToChar(str.Substring(f, 1)) >= 'a' && Convert.ToChar(str.Substring(f, 1)) <= 'z') || (Convert.ToChar(str.Substring(f, 1)) >= '0' && Convert.ToChar(str.Substring(f, 1)) <= '9') || Convert.ToChar(str.Substring(f, 1)) == '.' || Convert.ToChar(str.Substring(f, 1)) == ' ' || Convert.ToChar(str.Substring(f, 1)) == '>' || Convert.ToChar(str.Substring(f, 1)) == '<')
                    {
                        chrA2Z = true;
                        i++;
                    }
                    else
                    {
                        chrA2Z = false;
                        break;
                    }

                }
            }
            //if (!shead)
            //{
            //if (SalHead.ContainsKey(str.Substring(g, i)))
            //        shead = true;
            //    else
            //        shead = false;

            //}  

            if (shead && chrA2Z && !equi && lastop)
                ok = true;
            else
                ok = false;

            //if (ok)
            //    ERPMessageBox.ERPMessage.Show("Formula is Correct", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
            //else
            //    ERPMessageBox.ERPMessage.Show("Formula is Not Correct", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
*/
        }
        private Boolean chkPrecedence(String str1, String str2)
        {
            // TODO Auto-generated method stub
            if (getPrecedence(str1) >= getPrecedence(str2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int getPrecedence(String str)
        {
            // TODO Auto-generated method stub
            int i = 0;
            switch (str)
            {
                case "-":
                    i = 1;
                    break;
                case "+":
                    i = 2;
                    break;
                case "*":
                    i = 3;
                    break;
                case "/":
                    i = 4;
                    break;
            }
            return i;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {GetFormula();}
            catch
            {}
        }
        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c!='.'&&(c < '0' || c > '9'))
                    return false;
            }

            return true;
        }

        private void rbgradewise_CheckedChanged(object sender, EventArgs e)
        {
            if (rbgradewise.Checked)
            {
                //cmbgrade.SelectedIndex = -1;
                //cmbgrade.Enabled = true;
                
                cmbDesignation.Enabled = true;
            }
            else
            {
                cmbDesignation.Enabled = false;
                
                //cmbgrade.SelectedIndex = -1;
                //cmbgrade.Enabled = false;
            }
        }

        //private void cmbgrade_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbgrade.Text == lblDesg.Text.Trim())
        //    {


        //    }
        //    else
        //    {
        //        lbl_fid.Text = "";
        //        DataTable dt_desg = clsDataAccess.RunQDTbl("select fid,Desg from (select fname,fexp,(case when esf.desgid=0 then 'Everyone' else (select isNUll(DesignationName,'') from tbl_Employee_DesignationMaster where SlNo=esf.desgid) end)'Desg',desgid,fid from tbl_Employee_Sal_Structure_Formula esf)x where (fname ='" + txtfname.Text.Trim() + "') and (desg='" + cmbgrade.Text.Trim() + "')");
        //        if (dt_desg.Rows.Count > 0)
        //        {
        //            lbl_fid.Text = dt_desg.Rows[0]["fid"].ToString();
        //            lblDesg.Text = dt_desg.Rows[0]["Desg"].ToString();
        //        }
        //    }


        //}

        private void cmbDesignation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (cmbDesignation.Text.Trim() == lblDesg.Text.Trim())
            {


            }
            else
            {
                lbl_fid.Text = "";
                DataTable dt_desg = clsDataAccess.RunQDTbl("select fid,Desg from (select fname,fexp,(case when esf.desgid=0 then 'Everyone' else (select isNUll(DesignationName,'') from tbl_Employee_DesignationMaster where SlNo=esf.desgid) end)'Desg',desgid,fid from tbl_Employee_Sal_Structure_Formula esf)x where (fname ='" + txtfname.Text.Trim() + "') and (desg='" + cmbDesignation.Text.Trim() + "')");
                if (dt_desg.Rows.Count > 0)
                {
                    lbl_fid.Text = dt_desg.Rows[0]["fid"].ToString();
                    lblDesg.Text = dt_desg.Rows[0]["Desg"].ToString();
                }
            }
        }

        private void cmbDesignation_DropDown(object sender, EventArgs e)
        {
            string s = "select DesignationName,ShortForm,Slno,(select type from tbl_desg_type where slno=edm.type)Type from tbl_Employee_DesignationMaster edm order by SlNo";
            DataTable dt = clsDataAccess.RunQDTbl(s);
            cmbDesignation.LookUpTable = dt;
            cmbDesignation.ReturnIndex = 2;
        }

    }
}