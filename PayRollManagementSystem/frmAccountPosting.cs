//---------------------------------------AccountPosting---------------------------------------
//---------------------------------------Coded By Sourav Manna----09/06/08--------------------
//---------------------------------------EDP Soft Ltd.----------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.VisualBasic;
using Edpcom;
using EDPMessageBox;

namespace PayRollManagementSystem
{
    public partial class frmAccountPosting : EDPComponent.FormBaseERP
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        SqlTransaction Tran;
        SqlCommand cmd;
        SqlDataAdapter adp = new SqlDataAdapter();

        DataSet ds = new DataSet();
        string t_entry, demo_value;
        ArrayList arList = new ArrayList();
        ListBox lst = new ListBox();
        Label lbl = new Label();
        int typ_code, flg = 0, rollback_flg = 0;
        string g_cod, fi_cod, spc_acc, mtd, t_type = null, ef_amt = null, post_ef_amt = null;
        string b_desc = null, trm = null, tx = null, gl_cod = null, frm = null, pls_mns = null, sln = null;

        int evnt_flg = 0, d_code, temp_dcode, t_sprt, req_acc;
        int sp_ac, acp_req; int r_count,r_doc=0;
        Boolean ins_updt_chk = false, bol = false, error = false;
        DataTable dt_doc = new DataTable();
        public frmAccountPosting()
        {
            InitializeComponent();
        }

        private void frmAccountPosting_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            //pnlAuto.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            //gbxNum.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);

            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
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
            //

            edpcon.Open();
            Tran = edpcon.mycon.BeginTransaction();

            g_cod = "1";
            fi_cod = "1";
            clear_function();
            edpcom.UpdateMidasLog(this, true);
            edpcom.setFormPosition(this);

            if (clsDataAccess.ReturnValue("select bill_doc_type from CompanyLimiter") == "3")
            {
                lblMsg.Visible = true;
            }
            else
            {
                lblMsg.Visible = false;
            }

        }
        public void docnumberInfo_Fill()
        {
            cmd = new SqlCommand("select METHOD from TypeDoc where Gcode='1' and FICODE='1' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + " and Session='" + cmbYear.Text + "'", edpcon.mycon, Tran);
            adp.SelectCommand = cmd;
            Boolean boln1 = false;
            if (Information.IsNothing(ds.Tables["tb_typ"]) == false)
            {
                ds.Tables["tb_typ"].Clear();
            }
            try
            {
                boln1 = Convert.ToBoolean(adp.Fill(ds, "tb_typ"));
            }
            catch
            {
            }
            if (boln1 == true)
            {
                string x = Convert.ToString(ds.Tables["tb_typ"].Rows[0][0]);
                if (x == "A")
                {
                    rdbAuto.Checked = true;
                    pnlAuto.Enabled = true;
                    cmd = new SqlCommand("select * from docnumber where Gcode='" + g_cod + "' and FICODE='" + fi_cod + "' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + " and Session='" + cmbYear.Text + "'", edpcon.mycon, Tran);
                    adp.SelectCommand = cmd;
                    if (Information.IsNothing(ds.Tables["tb_doc"]) == false)
                    {
                        ds.Tables["tb_doc"].Clear();
                    }
                    Boolean data_chk = Convert.ToBoolean(adp.Fill(ds, "tb_doc"));
                    if (data_chk == true)
                    {
                        clear_function();
                        //int x = ds.Tables["tb_doc"].Rows.Count - 1;
                        txtPref.Text = Convert.ToString(ds.Tables["tb_doc"].Rows[0][12]).Trim();
                        txtSuf.Text = Convert.ToString(ds.Tables["tb_doc"].Rows[0][13]).Trim();
                        nudPref.Value = Convert.ToInt32(ds.Tables["tb_doc"].Rows[0][7]);
                        nudSuf.Value = Convert.ToInt32(ds.Tables["tb_doc"].Rows[0][8]);
                        txtPad.Text = Convert.ToString(ds.Tables["tb_doc"].Rows[0][9]).Trim();
                        txtNumsep.Text = Convert.ToString(ds.Tables["tb_doc"].Rows[0][11]).Trim();
                        txtPos.Text = Convert.ToString(ds.Tables["tb_doc"].Rows[0][10]).Trim();

                        txtPref.ReadOnly = true;
                        txtSuf.ReadOnly = true;
                        txtPad.ReadOnly = true;
                        rdbAuto.Enabled = false;
                        rdbMan.Enabled = false;
                        cmd = new SqlCommand("select VOUCHERNO from DOCGEN where Gcode='" + g_cod + "' and FICODE='" + fi_cod + "' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + " and Session='" + cmbYear.Text + "'", edpcon.mycon, Tran);
                        adp.SelectCommand = cmd;
                        if (Information.IsNothing(ds.Tables["tb_gen"]) == false)
                        {
                            ds.Tables["tb_gen"].Clear();
                        }
                        Boolean data_chk1 = Convert.ToBoolean(adp.Fill(ds, "tb_gen"));
                        if (data_chk1 == true)
                        {
                            txtDoc.Text = Convert.ToString(ds.Tables["tb_gen"].Rows[0][0]);
                        }
                        else
                        {
                            //clear_function();
                        }
                    }
                }
                else { pnlAuto.Enabled = false; rdbMan.Checked = true; }
            }
        }
        public void clear_function()
        {
            r_doc = 0;
            txtPref.Text = "";
            txtSuf.Text = "";
            nudPref.Value = 1;
            nudSuf.Value = 2;
            txtPad.Text = "";
            txtNumsep.Text = "";
            txtPos.Text = "";
            txtDemo.Text = "";
            select_doc();

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Tran.Commit();
            try
            {
                this.Close();
            }
            catch
            {
            }
        }

        //private void txtSeldoc_DoubleClick(object sender, EventArgs e)
        //{
        //    t_entry = "";
        //    txtDesc.Text = "";
        //    page_clear();
        //    tbcMain.SelectedIndex = 0;
        //   //common.LOV("Select Document Type", "select TypeName as 'Type Name' from TypeMast where ficode='1'and gcode='1'", txtSeldoc, 0);
        //    DataTable dt = clsDataAccess.RunQDTbl("select TypeName as 'Type Name' from TypeMast where ficode='1'and gcode='1'");
        //    if (dt.Rows.Count > 0)
        //    {
        //        txtSeldoc.LookUpTable = dt;
        //        txtSeldoc.ReturnIndex = 1;
        //    }

        //    //if (txtSeldoc.Text != "")
        //    //{
        //    //    cmd = new SqlCommand("select T_ENTRY from TypeMast where FICODE='1'and GCode='1' and TypeName='" + txtSeldoc.Text + "'", edpcon.mycon, Tran);
        //    //   adp.SelectCommand=cmd;
        //    //   if (Information.IsNothing(ds.Tables["TENTRY_FILL"]) == false)
        //    //   {
        //    //       ds.Tables["TENTRY_FILL"].Clear();
        //    //   }
        //    //   Boolean bln=Convert.ToBoolean(adp.Fill(ds,"TENTRY_FILL"));
        //    //   if(bln==true)
        //    //   {

        //    //       t_entry=Convert.ToString(ds.Tables["TENTRY_FILL"].Rows[0][0]).Trim();                  

        //    //   }

        //    //}
        //}

        private void lblMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void rdbAuto_Click(object sender, EventArgs e)
        {
            pnlAuto.Enabled = rdbAuto.Checked;
            txtPref.Text = txtDesc.Text;
            txtSuf.Text = cmbYear.Text;
            txtPad.Text = "4";
            txtNumsep.Text = "1";
            txtPos.Text = "3";
            txtPref.Focus();
        }

        private void rdbSing_Click(object sender, EventArgs e)
        {
            if (txtSeldoc.Text != "" && txtDesc.Text != "")
            {
                //dgvPost.Rows.Clear();
                //GRID_FILL();
                tbcActype.SelectedIndex = 0;
                dgvPost.Rows.Clear();
                dgvPost.Columns.Clear();
                lstbox_fill();
                if (txtSelected.Text != "")
                {
                    lbxList.SelectedItem = txtSelected.Text;
                }
            }

        }

        private void txtDesc_DoubleClick(object sender, EventArgs e)
        {

            if (txtSeldoc.Text != "")
            {
                clear_function();


                DataTable dt = clsDataAccess.RunQDTbl("select Type_Desc,desccode from TypeDoc where FICODE='" + fi_cod + "' AND GCode='" + g_cod + "' and T_ENTRY='" + t_entry + "',Session='" + cmbYear.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    txtSeldoc.LookUpTable = dt;
                    txtSeldoc.ReturnIndex = 1;

                }
                //common.LOV("Select Description", "select Type_Desc,desccode from TypeDoc where FICODE='" + fi_cod + "' AND GCode='" + g_cod + "' and T_ENTRY='" + t_entry + "'", txtDesc, 1);
                //if (common.LOVRESULT == "NO")
                //{
                //    common.LOVRESULT = null;
                //    return;
                //}
                if (txtSeldoc.ReturnIndex >0)
                {
                    string s1 = "select Desccode,Specific_Acc,Req_Acc from TypeDoc where GCode='" + g_cod + "' and FICODE='" + fi_cod + "' and Type_Desc='" + txtDesc.Text + "'and Session='" + cmbYear.Text + "'";
                    cmd = new SqlCommand(s1, edpcon.mycon, Tran);
                    adp.SelectCommand = cmd;
                    if (Information.IsNothing(ds.Tables["tb_ck"]) == false)
                    {
                        ds.Tables["tb_ck"].Clear();
                    }
                    Boolean b1 = Convert.ToBoolean(adp.Fill(ds, "tb_ck"));
                    if (b1 == true)
                    {
                        d_code = Convert.ToInt32(ds.Tables["tb_ck"].Rows[0][0]);
                        sp_ac = Convert.ToInt32(ds.Tables["tb_ck"].Rows[0][1]);
                        req_acc = Convert.ToInt32(ds.Tables["tb_ck"].Rows[0][2]);
                        if (req_acc == 1)
                        {
                            rdbYes.Checked = true;
                            if (sp_ac == 0)
                            {
                                lbxList.Items.Clear();
                                dgvPost.Rows.Clear();
                                lstbox_fill();
                                rdbSing.Checked = true;
                            }
                            else
                            {
                                lbxList.Items.Clear();
                                dgvPost.Rows.Clear();
                                GRID_FILL();
                                rdbMul.Checked = true;
                            }

                        }
                        else rdbNo.Checked = true;
                        t_sprt = 1;
                        rdbAuto.Checked = true;
                        docnumberInfo_Fill();
                    }
                }
            }
            else
            {
                EDPMessage.Show("Plese Select Document Type", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
            }

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            preview();
            txtDemo.Focus();
        }
        //-----------------------------------------------------------------------------------------------
        public void preview()
        {
            bol = check_function();
            if (bol == false)
            {
                if (Information.IsNothing(txtPos.Text) == false)
                {

                    string pad = "";
                    for (int i = 1; i <= Convert.ToInt32(txtPad.Text.Trim()); i++)
                    {
                        pad += "0";
                    }
                    string septr = null;
                    for (int i = 1; i <= Convert.ToInt32(txtNumsep.Text.Trim()); i++)
                    {
                        septr += "/";
                    }
                    position();
                    if (demo_value == "1+2+3")
                    {
                        if (pad != "")
                        {
                            txtDemo.Text = txtPref.Text.Trim() + septr + txtSuf.Text.Trim() + septr + pad.Trim();
                        }
                        else
                        {
                            txtDemo.Text = txtPref.Text.Trim() + septr + txtSuf.Text.Trim();
                        }
                    }
                    else if (demo_value == "1+3+2")
                    {
                        if (pad != "")
                        {
                            txtDemo.Text = txtPref.Text.Trim() + septr + pad.Trim() + septr + txtSuf.Text.Trim();
                        }
                        else
                        {
                            txtDemo.Text = txtPref.Text.Trim() + septr + txtSuf.Text.Trim();
                        }
                    }
                    else if (demo_value == "2+1+3")
                    {
                        if (pad != "")
                        {
                            txtDemo.Text = txtSuf.Text.Trim() + septr + txtPref.Text.Trim() + septr + pad.Trim();
                        }
                        else
                        {
                            txtDemo.Text = txtSuf.Text.Trim() + septr + txtPref.Text.Trim();
                        }
                    }
                    else if (demo_value == "3+1+2")
                    {
                        if (pad != "")
                        {
                            txtDemo.Text = pad.Trim() + septr + txtPref.Text.Trim() + septr + txtSuf.Text.Trim();
                        }
                        else
                        {
                            txtDemo.Text = txtPref.Text.Trim() + septr + txtSuf.Text.Trim();
                        }
                    }
                    else if (demo_value == "2+3+1")
                    {
                        if (pad != "")
                        {
                            txtDemo.Text = txtSuf.Text.Trim() + septr + pad.Trim() + septr + txtPref.Text.Trim();
                        }
                        else
                        {
                            txtDemo.Text = txtSuf.Text.Trim() + septr + txtPref.Text.Trim();
                        }
                    }
                    else if (demo_value == "3+2+1")
                    {
                        if (pad != "")
                        {
                            txtDemo.Text = pad.Trim() + septr + txtSuf.Text.Trim() + septr + txtPref.Text.Trim();
                        }
                        else
                        {
                            txtDemo.Text = txtSuf.Text.Trim() + septr + txtPref.Text.Trim();
                        }
                    }

                }
            }
            bol = false;
        }
        //-----------------------------------------------------------------------------------------------
        private void txtNumsep_Leave(object sender, EventArgs e)
        {
            if (t_sprt != 1)
            {
                if (txtNumsep.Text == "")
                {
                    try
                    {
                        errorProvider1.SetError(txtNumsep, "Value Not Acceptable");
                        txtNumsep.Focus();
                    }
                    catch
                    {
                        //errorProvider1.SetError(txtPad, "Enter Numeric Value"); 
                    }
                }
                else
                {
                    errorProvider1.Dispose();
                    position();
                }

            }
            t_sprt += 1;
        }
        //----------------------------------------------------------------
        public void position()
        {
            int pad = Convert.ToInt32(txtPad.Text.Trim());
            if (nudPref.Value == 1 && nudSuf.Value == 2)
            {
                txtPos.Text = "3";
                demo_value = "1+2+3";
            }
            else if (nudPref.Value == 1 && nudSuf.Value == 3)
            {
                txtPos.Text = "2";
                demo_value = "1+3+2";
            }
            else if (nudPref.Value == 2 && nudSuf.Value == 1)
            {
                txtPos.Text = "3";
                demo_value = "2+1+3";
            }
            else if (nudPref.Value == 2 && nudSuf.Value == 3)
            {
                txtPos.Text = "1";
                demo_value = "3+1+2";
            }
            else if (nudPref.Value == 3 && nudSuf.Value == 1)
            {
                txtPos.Text = "2";
                demo_value = "2+3+1";
            }
            else if (nudPref.Value == 3 && nudSuf.Value == 2)
            {
                txtPos.Text = "1";
                demo_value = "3+2+1";
            }
            
        }
        //--------------------------------------------------------------------------


        private void nudSuf_Leave(object sender, EventArgs e)
        {
            if (nudSuf.Value == nudPref.Value)
            {
                try
                {
                    errorProvider1.SetError(nudSuf, "Select Different Value");
                    nudSuf.Focus();
                }
                catch
                {
                    //errorProvider1.SetError(nudSuf, "Select Different Value");
                }
            }
            else
            {
                errorProvider1.Dispose();
                position();
            }

        }

        private void rdbMul_Click(object sender, EventArgs e)
        {
            if (txtSeldoc.Text != "" && txtDesc.Text != "")
            {
                dgvPost.Rows.Clear();
                GRID_FILL();
            }
        }
        public void lstbox_fill()
        {
            //------------------------------For Sales--------------------------------------------
            if (t_entry.Trim() == "9" || t_entry.Trim() == "S")
            {
                lbxList.Items.Clear();
                cmd = new SqlCommand("select LDESC from glmst where GCODE='" + g_cod + "' and FICODE='" + fi_cod + "' and MGroup=9 and MTYPE='L' and (ACTV_FLG IS NULL OR ACTV_FLG='True')  ", edpcon.mycon, Tran);
                adp.SelectCommand = cmd;
                ds.Clear();
                Boolean b1 = Convert.ToBoolean(adp.Fill(ds, "tb1"));
                string s = null;
                if (b1 == true)
                {
                    int cnt = ds.Tables["tb1"].Rows.Count - 1;
                    lbxList.Items.Clear();
                    for (int i = 0; i <= cnt; i++)
                    {
                        s = Convert.ToString(ds.Tables["tb1"].Rows[i][0]);
                        lbxList.Items.Add(s);
                    }
                    s = null;
                    b1 = false;
                }
            }
            //---------------------------Recursion For Purchase-------------------------------
            if (t_entry.Trim() == "8")
            {
                try
                {
                    if (Information.IsNothing(ds.Tables["ChkBro"]) == false)
                    {
                        ds.Tables["ChkBro"].Clear();
                    }
                    DataTable dt = new DataTable("LOV");
                    DataColumn brokername = new DataColumn("BrokerName");
                    DataColumn code = new DataColumn("BrokerCode");
                    dt.Columns.Add(brokername);
                    dt.Columns.Add(code);
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd = new SqlCommand("select LDESC,GLCODE,MTYPE,SGROUP from glmst where PREV_GROUP=" + 18 + " and Ficode='" + edpcom.CurrentFicode + "' and GCODE='" + edpcom.PCURRENT_GCODE + "'", edpcon.mycon, Tran);
                    da.SelectCommand = cmd;
                    bool cb = Convert.ToBoolean(da.Fill(ds, "ChkBro"));
                    if (cb != true)
                    {
                        EDPMessage.Show("No Ledger found against Purchase,First Create Ledger.", "Information....");
                        //Finance.frmBaseBrowse fi = new frmBaseBrowse();
                        //fi.value_pass(edpcom.CurrentFicode, edpcom.PCURRENT_GCODE, edpcon.connectionstr, 2);
                        //fi.ShowDialog();
                        return;
                    }
                    int i = Convert.ToInt32(ds.Tables["ChkBro"].Rows.Count - 1), f = 0, glcode, sgroup;
                    string ldesc;
                    char mtype;
                    for (f = 0; f <= i; f++)
                    {
                        ldesc = ds.Tables["ChkBro"].Rows[f][0].ToString();
                        glcode = Convert.ToInt32(ds.Tables["ChkBro"].Rows[f][1]);
                        mtype = Convert.ToChar(ds.Tables["ChkBro"].Rows[f][2]);
                        sgroup = Convert.ToInt32(ds.Tables["ChkBro"].Rows[f][3]);
                        if (mtype == 'L')
                        {
                            DataRow dr;
                            dr = dt.NewRow();
                            dr[0] = ldesc;
                            dr[1] = glcode;
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            if (Information.IsNothing(ds.Tables["ChkBro1"]) == false)
                            {
                                ds.Tables["ChkBro1"].Clear();
                            }
                            cmd = new SqlCommand("select LDESC,GLCODE,MTYPE,SGROUP from glmst where PREV_GROUP=" + sgroup + " and GCODE='" + edpcom.PCURRENT_GCODE + "'", edpcon.mycon, Tran);
                            da.SelectCommand = cmd;
                            bool cb1 = Convert.ToBoolean(da.Fill(ds, "ChkBro1"));
                            if (cb1 == true)
                            {
                                int ii = Convert.ToInt32(ds.Tables["ChkBro1"].Rows.Count - 1), jj = 0, glc, sg;
                                string ld;
                                char mt;
                                for (jj = 0; jj <= ii; jj++)
                                {
                                    ld = ds.Tables["ChkBro1"].Rows[jj][0].ToString();
                                    glc = Convert.ToInt32(ds.Tables["ChkBro1"].Rows[jj][1]);
                                    mt = Convert.ToChar(ds.Tables["ChkBro1"].Rows[jj][2]);
                                    sg = Convert.ToInt32(ds.Tables["ChkBro1"].Rows[jj][3]);
                                    if (mt == 'L')
                                    {
                                        DataRow dr;
                                        dr = dt.NewRow();
                                        dr[0] = ld;
                                        dr[1] = glc;
                                        dt.Rows.Add(dr);
                                    }
                                    else
                                    {
                                        if (Information.IsNothing(ds.Tables["ChkBro2"]) == false)
                                        {
                                            ds.Tables["ChkBro2"].Clear();
                                        }
                                        cmd = new SqlCommand("select LDESC,GLCODE,MTYPE,SGROUP from glmst where PREV_GROUP=" + sg + " and GCODE='" + edpcom.PCURRENT_GCODE + "'", edpcon.mycon, Tran);
                                        da.SelectCommand = cmd;
                                        bool cb2 = Convert.ToBoolean(da.Fill(ds, "ChkBro2"));
                                        if (cb2 == true)
                                        {
                                            int i1 = Convert.ToInt32(ds.Tables["ChkBro2"].Rows.Count - 1), j1 = 0, glc1, sg1;
                                            string ld1;
                                            char mt1;
                                            for (j1 = 0; j1 <= i1; j1++)
                                            {
                                                ld1 = ds.Tables["ChkBro2"].Rows[j1][0].ToString();
                                                glc1 = Convert.ToInt32(ds.Tables["ChkBro2"].Rows[j1][1]);
                                                mt1 = Convert.ToChar(ds.Tables["ChkBro2"].Rows[j1][2]);
                                                sg1 = Convert.ToInt32(ds.Tables["ChkBro2"].Rows[j1][3]);
                                                if (mt1 == 'L')
                                                {
                                                    DataRow dr;
                                                    dr = dt.NewRow();
                                                    dr[0] = ld1;
                                                    dr[1] = glc1;
                                                    dt.Rows.Add(dr);
                                                }
                                                else
                                                {
                                                    int flg = 0, sg11 = 0;
                                                    while (true)
                                                    {
                                                        if (Information.IsNothing(ds.Tables["ChkBro3"]) == false)
                                                        {
                                                            ds.Tables["ChkBro3"].Clear();
                                                        }
                                                        if (flg == 0)
                                                        {
                                                            cmd = new SqlCommand("select LDESC,GLCODE,MTYPE,SGROUP from glmst where PREV_GROUP=" + sg1 + " and GCODE='" + edpcom.PCURRENT_GCODE + "'", edpcon.mycon, Tran);
                                                            da.SelectCommand = cmd;
                                                        }
                                                        else
                                                        {
                                                            cmd = new SqlCommand("select LDESC,GLCODE,MTYPE,SGROUP from glmst where PREV_GROUP=" + sg11 + " and GCODE='" + edpcom.PCURRENT_GCODE + "'", edpcon.mycon, Tran);
                                                            da.SelectCommand = cmd;
                                                        }
                                                        bool cb3 = Convert.ToBoolean(da.Fill(ds, "ChkBro3"));
                                                        if (cb3 == true)
                                                        {
                                                            int i11 = Convert.ToInt32(ds.Tables["ChkBro3"].Rows.Count - 1), j11 = 0, glc11;
                                                            string ld11;
                                                            string mt11 = null;
                                                            for (j11 = 0; j11 <= i11; j11++)
                                                            {
                                                                ld11 = ds.Tables["ChkBro3"].Rows[j11][0].ToString();
                                                                glc11 = Convert.ToInt32(ds.Tables["ChkBro3"].Rows[j11][1]);
                                                                mt11 = Convert.ToString(ds.Tables["ChkBro3"].Rows[j11][2]);
                                                                sg11 = Convert.ToInt32(ds.Tables["ChkBro3"].Rows[j11][3]);
                                                                if (mt11 == "L")
                                                                {
                                                                    DataRow dr;
                                                                    dr = dt.NewRow();
                                                                    dr[0] = ld11;
                                                                    dr[1] = glc11;
                                                                    dt.Rows.Add(dr);
                                                                }
                                                            }
                                                            if (mt11 == "S")
                                                                flg = 1;
                                                            else
                                                            {
                                                                flg = 0;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    Boolean b2 = Information.IsNothing(dt);
                    string s1 = null;
                    if (b2 == false)
                    {
                        lbxList.Items.Clear();
                        for (int j = 0; j <= dt.Rows.Count - 1; j++)
                        {
                            s1 = Convert.ToString(dt.Rows[j][0]);
                            lbxList.Items.Add(s1);
                        }
                        s1 = null;
                        b2 = false;
                    }
                }
                catch
                {
                }
            }
        }
        //----------------------------------------------------------------------------
        public void GRID_FILL()
        {
            string sqlstr = null;
            //t_entry = "9";
            t_entry = t_entry.Trim();
            if (t_entry == "8")
            {
                t_type = "P";
                sqlstr = "select * from AccPost where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and Term_Type='" + t_type + "' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + "";
                fill_function(sqlstr);
            }
            else if (t_entry == "9")
            {
                t_type = "S";
                sqlstr = "select * from AccPost where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and Term_Type='" + t_type + "' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + "";
                fill_function(sqlstr);
            }
            else if (t_entry == "S")
            {
                t_type = "S";
                sqlstr = "select * from AccPost where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and Term_Type='" + t_type + "' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + "";
                fill_function(sqlstr);
            }
            else if (t_entry == "M")
            {
                t_type = "P";
                sqlstr = "select * from AccPost where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and Term_Type='" + t_type + "' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + "";
                fill_function(sqlstr);
            }
            else if (t_entry == "C")
            {
                t_type = "P";
                sqlstr = "select * from AccPost where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and Term_Type='" + t_type + "' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + "";
                fill_function(sqlstr);
            }
            else if (t_entry != "8" || t_entry != "9" || t_entry != "S" || t_entry != "M" || t_entry != "C")
            {
                dgvPost.Rows.Clear();
                dgvPost.Columns.Clear();
                rdbNo.Checked = true;
                tbcActype.Enabled = false;
                gbxRel.Enabled = false;
            }

        }
        public void fill_function(string sqlstr)
        {
            arList.Clear();
            //int r_count,
            int r_count1, chk_val;
            cmd = new SqlCommand(sqlstr, edpcon.mycon, Tran);
            adp.SelectCommand = cmd;
            if (!Information.IsNothing(ds.Tables["frm_accpost"]))
            {
                ds.Tables["frm_accpost"].Clear();
            }
            Boolean bln1 = Convert.ToBoolean(adp.Fill(ds, "frm_accpost"));
            if (bln1)
            {
                r_count = ds.Tables["frm_accpost"].Rows.Count - 1;
            }
            sqlstr = "select * from BillTerms where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and TERMSTYPE='" + t_type + "'";// and T_ENTRY='" + t_entry + "'";
            cmd = new SqlCommand(sqlstr, edpcon.mycon, Tran);
            adp.SelectCommand = cmd;
            if (!Information.IsNothing(ds.Tables["frm_billtrm"]))
            {
                ds.Tables["frm_billtrm"].Clear();
            }
            Boolean bln2 = Convert.ToBoolean(adp.Fill(ds, "frm_billtrm"));
            if (bln2)
            {
                r_count1 = ds.Tables["frm_billtrm"].Rows.Count - 1;
                dgvPost.Rows.Clear();
                grd_create();
                dgvPost.Rows.Clear();
                int gl_code; string gl_name = null, mgroup = "";
                for (int i = 0; i <= r_count1; i++)
                {
                    dgvPost.Rows.Add();
                    if (!Information.IsNothing(ds.Tables["frm_billtrm"].Rows[i][3]))
                    {
                        dgvPost.Rows[i].Cells[0].Value = Convert.ToString(ds.Tables["frm_billtrm"].Rows[i][3]);
                    }
                    if (!Information.IsNothing(ds.Tables["frm_billtrm"].Rows[i][4]))
                    {
                        dgvPost.Rows[i].Cells[1].Value = Convert.ToString(ds.Tables["frm_billtrm"].Rows[i][4]);
                    }
                    if (bln1)
                    {
                        if (i <= r_count)
                        {
                            if (ds.Tables["frm_billtrm"].Rows[i][4].ToString() == ds.Tables["frm_accpost"].Rows[i][5].ToString())
                            {
                                dgvPost.Rows[i].Cells[2].Value = Convert.ToString(ds.Tables["frm_accpost"].Rows[i][7]).Trim();

                                if (!Information.IsDBNull(ds.Tables["frm_accpost"].Rows[i][8]))
                                {
                                    string x = Convert.ToString(ds.Tables["frm_accpost"].Rows[i][8]);
                                    if (x == "")
                                        gl_name = null;
                                    else
                                    {
                                        gl_code = Convert.ToInt32(ds.Tables["frm_accpost"].Rows[i][8]);
                                        cmd = new SqlCommand("select LDESC,mgroup from glmst where GCODE='" + g_cod + "' and FICODE='" + fi_cod + "' and MTYPE='L'  and (ACTV_FLG IS NULL OR ACTV_FLG='True')  and GLCODE=" + gl_code + "", edpcon.mycon, Tran);
                                        adp.SelectCommand = cmd;
                                        if (!Information.IsNothing(ds.Tables["gl"]))
                                            ds.Tables["gl"].Clear();
                                        Boolean booln = Convert.ToBoolean(adp.Fill(ds, "gl"));
                                        if (booln)
                                        {
                                            gl_name = ds.Tables["gl"].Rows[0][0].ToString();
                                            mgroup = ds.Tables["gl"].Rows[0][1].ToString();
                                        }
                                    }
                                }
                                dgvPost.Rows[i].Cells[3].Value = gl_name;
                                if (!Information.IsDBNull(ds.Tables["frm_accpost"].Rows[i][12]))
                                {
                                    chk_val = Convert.ToInt32(ds.Tables["frm_accpost"].Rows[i][12]);
                                    dgvPost.Rows[i].Cells[6].Value = chk_val;
                                }
                                if ((mgroup.Trim() == "8") || (mgroup.Trim() == "9") || (mgroup.Trim() == "10") || (mgroup.Trim() == "11"))
                                {
                                    dgvPost.Rows[i].Cells[6].Value = false;
                                    dgvPost.Rows[i].Cells[6].ReadOnly = true;
                                }
                                else dgvPost.Rows[i].Cells[6].ReadOnly = false;
                            }
                            //--------------------------------------------------------------------------------------------------------------
                            //combo_status();
                            //--------------------------------------------------------------------------------------------------------------
                        }
                    }
                    if (!Information.IsNothing(ds.Tables["frm_billtrm"].Rows[i][7]))
                    {
                        dgvPost.Rows[i].Cells[4].Value = Convert.ToString(ds.Tables["frm_billtrm"].Rows[i][7]).Trim();
                    }
                    if (!Information.IsNothing(ds.Tables["frm_billtrm"].Rows[i][6]))
                    {
                        dgvPost.Rows[i].Cells[5].Value = Convert.ToString(ds.Tables["frm_billtrm"].Rows[i][6]).Trim();
                    }
                    if (!Information.IsNothing(ds.Tables["frm_billtrm"].Rows[i][8]))
                    {
                        arList.Add(ds.Tables["frm_billtrm"].Rows[i][8]);
                    }
                }
                dgvPost.Rows[0].Cells[6].Value = 1;
                dgvPost.Rows[0].Cells[6].ReadOnly = true;
                dgvPost.Columns[5].ReadOnly = true;
                dgvPost.Columns[4].ReadOnly = true;
                dgvPost.Columns[3].ReadOnly = true;
                // dgvPost.Columns[2].ReadOnly = true;
                dgvPost.Columns[1].ReadOnly = true;
                dgvPost.Columns[0].ReadOnly = true;
            }
            else
            {
                EDPMessage.Show("Bill Terms Not Set!!", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
        }
        //------------------------------------------------------------------------------------------
        public void combo_status()
        {
            if (arList.Count != -1)
            {
                // arList.Add(ds.Tables["frm_billtrm"].Rows[i][8]);
                //---------------------------------------------------------------------------------------------------------
                int x, x1, x2;
                if ((arList.Count - 1) >= 0)
                {

                    x2 = dgvPost.CurrentCell.RowIndex;
                    x = Convert.ToInt32(arList[x2]);
                    string s = "select TaxStatus from TaxMaster where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and Type_Code=" + x + "";
                    cmd = new SqlCommand(s, edpcon.mycon, Tran);
                    adp.SelectCommand = cmd;
                    if (Information.IsNothing(ds.Tables["t1"]) == false)
                    {
                        ds.Tables["t1"].Clear();
                    }
                    Boolean bl = Convert.ToBoolean(adp.Fill(ds, "t1"));
                    if (bl == true)
                    {
                        x1 = Convert.ToInt32(ds.Tables["t1"].Rows[0][0]);
                        if (x1 == 0)
                        {
                            dgvPost.Rows[x2].Cells[2].ReadOnly = true;
                            //dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[2].ReadOnly = true;
                            dgvPost.Rows[x2].Cells[2].Dispose();

                        }
                        else
                        {
                            //dgvPost.Columns[2].ReadOnly = false;
                            dgvPost.Rows[x2].Cells[2].ReadOnly = false;
                            if (Information.IsNothing(dgvPost.Rows[x2].Cells[2].Value) == false)
                            {
                                if (Information.IsDBNull(dgvPost.Rows[x2].Cells[2].Value) == false)
                                {
                                    string txval = dgvPost.Rows[x2].Cells[2].Value.ToString();
                                    if (txval == "YES")
                                    {
                                        dgvPost.Rows[x2].Cells[3].Value = "";
                                    }
                                }
                            }

                        }

                    }


                }
                //---------------------------------------------------------------------------------------------------------
            }
        }
        //-----------------------------------------------------------------------------------------
        public void grd_create()
        {

            dgvPost.Columns.Clear();
            dgvPost.Rows.Clear();
            DataGridViewTextBoxColumn clmTxtSlno = new DataGridViewTextBoxColumn();

            clmTxtSlno.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //clmTxtSlno.DefaultCellStyle = dataGridViewCellStyle2;.Save("bill_terms")
            //clmTxtSlno.FillWeight = 37.99392F;
            clmTxtSlno.HeaderText = "Sl.No.";
            //clmSl.Name = "clmSl";
            clmTxtSlno.Width = 40;

            DataGridViewTextBoxColumn clmTxtDesc = new DataGridViewTextBoxColumn();
            clmTxtDesc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clmTxtDesc.HeaderText = "Description";
            clmTxtDesc.Width = 180;
            DataGridViewComboBoxColumn clmComboTax = new DataGridViewComboBoxColumn();
            clmComboTax.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clmComboTax.FlatStyle = FlatStyle.Flat;
            clmComboTax.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            clmComboTax.HeaderText = "Tax";
            clmComboTax.Width = 60;
            //clmComboTax.Items.Add("YES");
            //clmComboTax.Items.Add("NO");
            clmComboTax.Items.AddRange(new object[]{
                    "YES","NO"});
            DataGridViewTextBoxColumn clmTxtAChead = new DataGridViewTextBoxColumn();
            clmTxtAChead.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clmTxtAChead.HeaderText = "Account Head";
            clmTxtAChead.Width = 180;
            DataGridViewTextBoxColumn clmTxtPlsMins = new DataGridViewTextBoxColumn();
            //clmComboPlsMins.FlatStyle=FlatStyle.Flat;
            //clmComboPlsMins.DisplayStyle=DataGridViewComboBoxDisplayStyle.Nothing;
            clmTxtPlsMins.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clmTxtPlsMins.HeaderText = "Plus/Minus";
            clmTxtPlsMins.Width = 70;
            //clmComboPlsMins.Items.AddRange(new object[]{
            //    "Plus","Minus"});
            DataGridViewTextBoxColumn clmTxtFrml = new DataGridViewTextBoxColumn();
            clmTxtFrml.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clmTxtFrml.HeaderText = "Formula";
            clmTxtFrml.Width = 142;
            DataGridViewCheckBoxColumn clmChkEfctvAmt = new DataGridViewCheckBoxColumn();
            clmChkEfctvAmt.FlatStyle = FlatStyle.Flat;
            clmChkEfctvAmt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clmChkEfctvAmt.HeaderText = "Add In Effective Amount";
            clmChkEfctvAmt.Width = 100;
            dgvPost.Columns.AddRange(new DataGridViewColumn[]{
                clmTxtSlno,clmTxtDesc,clmComboTax,clmTxtAChead,clmTxtPlsMins,clmTxtFrml,clmChkEfctvAmt});
        }
        //-----------------------------------------------------------------------------------------

        private void tbcActype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbSing.Checked == true)
            {
                tbcActype.SelectedIndex = 0;
            }
            else if (rdbMul.Checked == true)
            {
                tbcActype.SelectedIndex = 1;
            }

        }

        private void lbxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSelected.Text = lbxList.SelectedItem.ToString();
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //yesNoflg += 1;
            if (txtSeldoc.Text == "" || txtDesc.Text == "")
            {
                tbcMain.SelectedIndex = 0;
            }
            else if (tbcMain.SelectedIndex == 1)
            {
                if (d_code != 0)
                {
                    if (req_acc == 0)
                    {
                        rdbNo.Checked = true;
                        gbxRel.Enabled = false;
                        tbcActype.Enabled = false;
                        if (t_entry.Trim() == "9")
                        {
                            lblHead.Text = "List of Sales A/C";
                        }
                        if (t_entry.Trim() == "8")
                        {
                            lblHead.Text = "List of  Purchase A/C";
                        }

                    }
                    else          //if(req_acc==1)
                    {
                        //req_acc = 1;
                        rdbYes.Checked = true;
                        gbxRel.Enabled = true;
                        tbcActype.Enabled = true;
                        if (t_entry.Trim() == "9")
                        {
                            lblHead.Text = "List of Sales A/C";
                        }
                        if (t_entry.Trim() == "8")
                        {
                            lblHead.Text = "List of  Purchase A/C";
                        }
                        if (sp_ac == 0)
                        {
                            lst.Items.Clear();
                            lstbox_fill();
                            tbcActype.SelectedIndex = 0;
                            rdbSing.Checked = true;
                        }
                        else
                        {
                            //if (rdbSing.Checked == true)
                            //{
                            //    tbcActype.SelectedIndex = 0;
                            //    lst.Items.Clear();
                            //    lstbox_fill();
                            //}
                            //else
                            //{
                            rdbMul.Checked = true;
                            tbcActype.SelectedIndex = 1;
                            //}

                        }

                    }
                    if (t_entry == "8" || t_entry == "9" || t_entry == "S" || t_entry == "M")
                    {
                    }
                    else
                    {
                        rdbNo.Checked = true;
                        tbcActype.Enabled = false;
                        gbxRel.Enabled = false;
                    }
                }//----
                else
                {
                    if (rdbYes.Checked == true)
                    {
                        //GRID_FILL();
                        rdbNo.Checked = true;
                        tbcActype.Enabled = false;
                        gbxRel.Enabled = false;
                    }

                }

            }//---else end---
        }



        private void dgvPost_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPost.Columns[3].ReadOnly = true;
            if (Information.IsNothing(dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[1].Value) == false)
            {
                //dgvPost.Columns[2].ReadOnly = true;
                //dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[2].Dispose();
                dgvPost.Columns[3].ReadOnly = true;
                //----------------------------------------------------------------------------------------------------

                if (dgvPost.CurrentCell.ColumnIndex == 2)
                {

                    if (Information.IsNothing(dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[1].Value) == true)
                    {
                        //dgvPost.Columns[2].ReadOnly = true;
                    }
                    else
                    {
                        combo_status();
                    }
                }

                //----------------------------------------------------------------------------------------------------
            }
            else
            {
                // dgvPost.Columns[2].ReadOnly = true;
                dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[2].Dispose();
                dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[6].Dispose();
            }
            if (Information.IsNothing(dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[1].Value) == false)
            {
                dgvPost.Columns[3].ReadOnly = false;
                //Information.IsNothing(dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[2].Value) == false 
                if (dgvPost.CurrentCell.ColumnIndex == 3)
                {
                    int x, x1, x2;
                    x2 = dgvPost.CurrentCell.RowIndex;
                    x = Convert.ToInt32(arList[x2]);
                    string s = "select TaxStatus from TaxMaster where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and Type_Code=" + x + "";
                    cmd = new SqlCommand(s, edpcon.mycon, Tran);
                    adp.SelectCommand = cmd;
                    if (Information.IsNothing(ds.Tables["t2"]) == false)
                    {
                        ds.Tables["t2"].Clear();
                    }
                    Boolean bl2 = Convert.ToBoolean(adp.Fill(ds, "t2"));
                    if (bl2 == true)
                    {
                        x1 = Convert.ToInt32(ds.Tables["t2"].Rows[0][0]);
                        if (x1 == 0)
                        {
                            list_show();
                        }
                        else if (x1 == 1)
                        {
                            string s1 = Convert.ToString(dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[2].Value);
                            if (s1 == "NO")
                            {
                                list_show();
                                dgvPost.Columns[3].ReadOnly = true;
                            }

                            else if (s1 == "YES")
                            {
                                dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[3].Value = "";
                                dgvPost.Columns[3].ReadOnly = true;
                            }
                        }
                    }
                    else { }//dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[2].Dispose(); }
                }
                else
                {
                    dgvPost.Columns[3].ReadOnly = true;
                    //dgvPost.Columns[2].ReadOnly = true;
                    dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[2].Dispose();
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------
        public void list_show()
        {
            lbl.Location = new Point(0, 0);
            lbl.Text = "Double Click OR Tab TO Select";
            lbl.Size = new Size(306, 15);
            lbl.ForeColor = Color.BlueViolet;
            dgvPost.Controls.Add(lbl);
            lst.Location = new Point(0, 15);
            lst.Size = new Size(306, 185);
            lst.ScrollAlwaysVisible = true;
            dgvPost.Controls.Add(lst);
            lst.Visible = true;
            lbl.Visible = true;
            listBoxFill_grid();
            evnt_flg += 1;
            if (evnt_flg == 1)
            {
                lst.DoubleClick += new EventHandler(lst_DoubleClick);
                lst.Enter += new EventHandler(lst_Enter);
                lst.PreviewKeyDown += new PreviewKeyDownEventHandler(lst_PreviewKeyDown);
            }
        }
        //-----------------------------------------------------------------------------------------------------

        void lst_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            if (e.KeyCode == Keys.Tab)
            {
                if (Information.IsNothing(lst.SelectedItem) == false)
                {
                    dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[3].Value = Convert.ToString(lst.SelectedItem);
                    lst.Visible = false;
                    lbl.Visible = false;

                }
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                if (Information.IsNothing(lst.SelectedIndex) == true)
                {
                    lst.SelectedIndex = 0;
                }
                else
                {
                    int x = lst.Items.Count - 1;
                    if (lst.SelectedIndex < x)
                    {
                        lst.SelectedIndex += 1;
                    }
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                if (Information.IsNothing(lst.SelectedIndex) == true)
                {
                    lst.SelectedIndex = 0;
                }
                else
                {
                    //int x = lst.Items.Count - 1;
                    if (lst.SelectedIndex > 0)
                    {
                        lst.SelectedIndex -= 1;
                    }
                }
            }
        }

        void lst_Enter(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            if (Information.IsNothing(lst.SelectedItem) == false)
            {
                dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[3].Value = Convert.ToString(lst.SelectedItem);

            }
        }

        void lst_DoubleClick(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            if (Information.IsNothing(lst.SelectedItem) == false)
            {
                dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[3].Value = Convert.ToString(lst.SelectedItem);
                lst.Visible = false;
                lbl.Visible = false;
            }
        }

        private void dgvPost_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            lst.Visible = false;
            lbl.Visible = false;
            dgvPost.Columns[3].ReadOnly = true;
            dgvPost.Rows[0].Cells[2].ReadOnly = true;
            //dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[2].ReadOnly = true;
            dgvPost.Rows[0].Cells[2].Dispose();
            if (Information.IsNothing(dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[1].Value) == true)
            {
                dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[2].ReadOnly = true;
                dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[2].Dispose();
                dgvPost.Columns[3].ReadOnly = true;
                dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[6].ReadOnly = true;
                dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[6].Dispose();
            }
            else
            {
                combo_status();
            }

        }

        //---------------------------------------------------------------------------------------------
        public void listBoxFill_grid()
        {
            cmd = new SqlCommand("select LDESC from glmst where GCODE='" + g_cod + "' and FICODE='" + fi_cod + "' and MTYPE='L' and (ACTV_FLG IS NULL OR ACTV_FLG='True')  ", edpcon.mycon, Tran);
            adp.SelectCommand = cmd;
            if (Information.IsNothing(ds.Tables["ldgr_fill"]) == false)
            {
                ds.Tables["ldgr_fill"].Clear();
            }
            Boolean bln_chk = Convert.ToBoolean(adp.Fill(ds, "ldgr_fill"));
            if (bln_chk == true)
            {
                int x = ds.Tables["ldgr_fill"].Rows.Count - 1;
                lst.Items.Clear();
                //for (int i = 0; i < x; i++)
                //{
                //    lst.Items.Add(ds.Tables["ldgr_fill"].Rows[i][0]);
                //}
                int i = 0;
                while (i < x)
                {
                    lst.Items.Add(ds.Tables["ldgr_fill"].Rows[i][0]);
                    i++;
                }
                lst.Sorted = true;

            }
        }

        private void txtPad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumsep_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPref_Leave(object sender, EventArgs e)
        {
            string s = txtPref.Text.ToString();
            //txtPref.Text = slschk(s);
            if (txtPref.Text == "")
            {
                txtPref.Focus();
            }
        }
        public string slschk(string st)
        {
            int x = st.IndexOf("/", 0);

            //x1=txtPref.Text.IndexOf("",0);
            if (x != -1)
            {
                EDPMessage.Show(" / Not Allowed", "Warning");
                st = "";
            }
            return st;
        }

        private void txtSuf_Leave(object sender, EventArgs e)
        {
            string s = txtSuf.Text.ToString();
            //txtSuf.Text=slschk(s);
            if (txtSuf.Text == "")
            {
                txtSuf.Focus();
            }
        }

        private void txtPref_TextChanged(object sender, EventArgs e)
        {
            if (Information.IsNothing(txtPref.Text) == false)
            {
                errorProvider1.Dispose();
            }
        }

        private void txtSuf_TextChanged(object sender, EventArgs e)
        {
            if (Information.IsNothing(txtSuf.Text) == false)
            {
                errorProvider1.Dispose();
            }
        }

        private void txtPad_Leave(object sender, EventArgs e)
        {

        }
        //------------------------------------------------------------------------------------------
        public Boolean check_function()
        {
            Boolean boln = false;
            if (Information.IsNumeric(txtNumsep.Text) == false || Information.IsNothing(txtNumsep.Text) == true)
            {
                txtNumsep.Text = "";
                txtNumsep.Focus();
                try
                {
                    errorProvider1.SetError(txtNumsep, "Enter Proper Value");
                    boln = true;

                }
                catch
                {
                    //errorProvider1.SetError(txtPad, "Enter Numeric Value"); 
                }
            }
            else
            {
                errorProvider1.Dispose();
            }
            //--->
            if (Information.IsNumeric(txtPad.Text) == false || Information.IsNothing(txtPad.Text) == true)
            {
                try
                {
                    errorProvider1.SetError(txtPad, "Enter Proper Value");
                    txtPad.Focus();
                    boln = true;
                }
                catch
                {
                    //errorProvider1.SetError(txtPad, "Enter Numeric Value"); 
                }
            }
            else { errorProvider1.Dispose(); }
            if (txtSuf.Text == "")
            {
                try
                {
                    errorProvider1.SetError(txtSuf, "Enter Proper Value");
                    txtSuf.Focus();
                    boln = true;
                }
                catch
                {
                    //errorProvider1.SetError(txtPad, "Enter Numeric Value"); 
                }
            }
            else { errorProvider1.Dispose(); }
            if (txtPref.Text == "")
            {
                try
                {
                    errorProvider1.SetError(txtPref, "Enter Proper Value");
                    txtPref.Focus();
                    boln = true;
                }
                catch
                {
                    //errorProvider1.SetError(txtPad, "Enter Numeric Value"); 
                }
            }
            else { errorProvider1.Dispose(); }
            if (txtPos.Text == "")
            {
                try
                {
                    errorProvider1.SetError(txtPos, "Enter Proper Value");
                    txtPos.Focus();
                    boln = true;
                }
                catch
                {
                    //errorProvider1.SetError(txtPad, "Enter Numeric Value"); 
                }
            }
            else { errorProvider1.Dispose(); }
            //if (txtDemo.Text == "")
            //{
            //    try
            //    {
            //        errorProvider1.SetError(btnPrev, "Click Here For Preview Number");
            //        btnPrev.Focus();
            //        boln=true;
            //    }
            //    catch
            //    {
            //        //errorProvider1.SetError(txtPad, "Enter Numeric Value"); 
            //    }
            //}
            //else { errorProvider1.Dispose(); }
            if (nudPref.Value == nudSuf.Value)
            {
                try
                {
                    errorProvider1.SetError(nudSuf, "Select Different Value");
                    txtPref.Focus();
                    boln = true;
                }
                catch
                {
                    //errorProvider1.SetError(txtPad, "Enter Numeric Value"); 
                }
            }
            else { errorProvider1.Dispose(); }
            return boln;
        }
        //---------------------------------SAVE SECTION---------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDesc.Text == "" || txtSeldoc.Text == "" || txtDesc.Text == null || txtSeldoc.Text == null)
                {

                }
                else
                {
                    //------------------------------------------------------------------------------------------------
                    if (rdbAuto.Checked == true)
                    {
                        mtd = "A";
                        // bol = check_function();
                        preview();
                    }
                    else if (rdbMan.Checked == true)
                    {
                        mtd = "M";
                    }
                    if (bol == false)
                    {

                        if (rdbNo.Checked == true)
                        {
                            spc_acc = null;
                            acp_req = 0;

                        }
                        else if (rdbYes.Checked == true)
                        {
                            acp_req = 1;
                            if (rdbSing.Checked == true)
                            {
                                spc_acc = "0";
                            }
                            else if (rdbMul.Checked == true)
                            {
                                spc_acc = "1";
                            }
                        }

                        //ins_updt_chk = tran_check();
                        if (d_code == 0)
                            ins_updt_chk = false;
                        else
                            ins_updt_chk = true;

                        if (ins_updt_chk == true)
                        {
                            EDPMessage.Show("Document Numbering Updated Y/N", "Information", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);

                            if (EDPMessage.ButtonResult == "edpYES")
                            {
                                docnumber_insert();
                                docgen();
                                Tran.Commit();
                                EDPMessage.Show("Document Numbering Updated ", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_OK);
                                page_clear();
                            }
                            else
                            {
                                page_clear();
                                return;
                            }
                        }
                        else
                        {
                            type_doc_insert();
                            //Acc_post_insert();
                            if (error == true)
                            {
                                MessageBox.Show("Plese Select A/C Head", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dgvPost.Focus();
                                error = false;
                            }
                            else
                            {
                                docnumber_insert();
                                docgen();
                                Tran.Commit();
                                MessageBox.Show("Details Saved", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                page_clear();
                            }

                            edpcon.mycon.Close();
                            edpcon.mycon.Open();
                            Tran = edpcon.mycon.BeginTransaction();
                        }
                    }
                }
            }
            catch
            {
                try
                {
                    Tran.Rollback();
                }
                catch{              }
                edpcon.mycon.Close();
                edpcon.mycon.Open();
                MessageBox.Show("Error In SaveDetails." + Environment.NewLine + "Try Again", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // this.Close();
            }
        }
        //------------------------------------------------------------------------------------------
        public void page_clear()
        {
            txtPref.ReadOnly = false;
            txtSuf.ReadOnly = false;
            txtPad.ReadOnly = false;
            rdbAuto.Enabled = true;
            rdbMan.Enabled = true;
            txtDoc.Text = "";
            txtSeldoc.Text = "";
            txtDesc.Text = "";
            d_code = 0;
            clear_function();
            txtSelected.Text = "";
            lst.Items.Clear();
            dgvPost.Rows.Clear();
            rdbMan.Checked = true;
            pnlAuto.Enabled = false;
            typ_code = 0; flg = 0; rollback_flg = 0;
            evnt_flg = 0; temp_dcode = 0; t_sprt = 0; req_acc = 0; sp_ac = 0; acp_req = 0; r_count = 0; ;
            b_desc = null; trm = null; tx = null; gl_cod = null; frm = null; pls_mns = null; sln = null; spc_acc = null;
            common.LovReturnValue = "";
            lbxList.Items.Clear();
            lblHead.Text = "";
            
        }

        public void select_doc()
        {
            DataTable dc = clsDataAccess.RunQDTbl("select TypeName,T_ENTRY from TypeMast where ficode='1'and gcode='1' and T_Entry='9'");
            if (dc.Rows.Count > 0)
            {


                txtSeldoc.Text = dc.Rows[0]["TypeName"].ToString().Trim();
                txtSeldoc.ReturnValue = dc.Rows[0]["T_ENTRY"].ToString().Trim();
                t_entry = txtSeldoc.ReturnValue;
            }
        }
        //----------------------------------------------------------------------------
        public void docgen()
        {
            string s, s1 = "0";
            if (ins_updt_chk)
            {
                s = "update DOCGEN set VOUCHERNO='" + txtDoc.Text + "' where FICODE='" + fi_cod + "' and Gcode='" + g_cod + "' and T_ENTRY='" + t_entry + "' and DESCCODE='" + d_code + "' and Session='" + cmbYear.Text + "'";
                cmd = new SqlCommand(s, edpcon.mycon, Tran);
                adp.UpdateCommand = cmd;
                cmd.ExecuteNonQuery();
            }
            else
            {
                if (txtDoc.Text.Trim() == "")
                {
                    s1 = "0";
                }
                else
                {
                    s1 = txtDoc.Text;
                }
                s = "insert into DOCGEN values('" + fi_cod + "','" + g_cod + "','" + t_entry + "'," + temp_dcode + ",'" + s1 + "','" + edpcom.PCURRENT_USER + "','" + cmbYear.Text + "')";
                cmd = new SqlCommand(s, edpcon.mycon, Tran);
                adp.InsertCommand = cmd;
                cmd.ExecuteNonQuery();
            }  cmd.ExecuteNonQuery();
        }

        //}
        //----------------------------------------------------------------------------
        public void docnumber_insert()
        {
            string s = null, prfpso = null, sufpos = null, pad = null, docpos = null, numsp = null, prf = null, suf = null;
            if (mtd == "M")
            {
                prfpso = null; sufpos = null; pad = null; docpos = null; numsp = null; prf = null; suf = null;

            }
            else if (mtd == "A")
            {
                prfpso = Convert.ToString(nudPref.Value).Trim(); sufpos = Convert.ToString(nudSuf.Value).Trim(); pad = Convert.ToString(txtPad.Text).Trim();
                docpos = Convert.ToString(txtPos.Text).Trim(); numsp = Convert.ToString(txtNumsep.Text).Trim(); prf = txtPref.Text.Trim(); suf = txtSuf.Text.Trim();
            }
            if (d_code != 0)
            {
                //if (ins_updt_chk == false)
                //{
                s = "update docnumber set TYPE_DESC='" + txtDesc.Text + "',METHOD='" + mtd + "',";//SPECIFIC_ACC='" + spc_acc + "',";
                s += "PREPOS='" + prfpso + "',SUFPOS='" + sufpos + "',padding='" + pad + "',doc_pos='" + docpos + "',";
                s += "no_sep='" + numsp + "',prefix='" + prf + "',suffix='" + suf + "'";
                s += "where FICODE='" + fi_cod + "' and Gcode='" + g_cod + "' and T_ENTRY='" + t_entry + "' and TYPE_NAME='" + txtSeldoc.Text + "' and DESCCODE=" + d_code + " and Session='" + cmbYear.Text + "'";
                cmd = new SqlCommand(s, edpcon.mycon, Tran);
                adp.UpdateCommand = cmd;
                cmd.ExecuteNonQuery();
                //}
            }
            else
            {
                s = "insert into docnumber values('" + fi_cod + "','" + g_cod + "','" + t_entry + "','" + txtSeldoc.Text + "'," + temp_dcode + ",'" + txtDesc.Text + "',";
                s += "'" + mtd + "','" + prfpso + "','" + sufpos + "','" + pad + "','" + docpos + "'";
                s += ",'" + numsp + "','" + prf + "','" + suf + "','" + edpcom.PCURRENT_USER + "','" + cmbYear.Text + "','0','0','0')";//'" + spc_acc + "',
                cmd = new SqlCommand(s, edpcon.mycon, Tran);
                adp.InsertCommand = cmd;
                cmd.ExecuteNonQuery();
            }
        }

        //}
        //----------------------------------------------------------------------------
        public void Acc_post_insert()
        {
            string s1;

            //string b_desc=null, trm=null, tx=null, gl_cod=null, frm=null, pls_mns=null, sln=null,
            string x4_ldgr = null;
            trm = t_type;
            if (spc_acc == "0")
            {
                if (Information.IsNothing(txtSelected.Text) == false)
                {
                    gl_cod = null;
                    x4_ldgr = txtSelected.Text.ToString();
                    s1 = "select GLCODE from glmst where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and LDESC='" + x4_ldgr + "'";
                    cmd = new SqlCommand(s1, edpcon.mycon, Tran);
                    adp.SelectCommand = cmd;
                    if (Information.IsNothing(ds.Tables["glcode_slct"]) == false)
                    {
                        ds.Tables["glcode_slct"].Clear();
                    }
                    Boolean b3 = Convert.ToBoolean(adp.Fill(ds, "glcode_slct"));
                    if (b3 == true)
                    {
                        gl_cod = Convert.ToString(ds.Tables["glcode_slct"].Rows[0][0]);
                    }
                    sln = "1"; b_desc = null; trm = t_type; tx = null; pls_mns = null; typ_code = 0; post_ef_amt = "0"; frm = null;
                    acc_ins();
                }
                else
                {
                    error = true;
                    Tran.Rollback();
                    edpcon.mycon.Close();
                    edpcon.mycon.Open();
                    Tran = edpcon.mycon.BeginTransaction();
                    return;
                }

            }
            else if (spc_acc == "1")
            {
                int x = dgvPost.Rows.Count - 1;
                if (x > 0)
                {
                    int z, z1, z2;
                    for (int i = 0; i <= (x - 1); i++)
                    {
                        if (Information.IsNothing(dgvPost.Rows[i].Cells[0].Value) == false)
                        {

                            sln = Convert.ToString(dgvPost.Rows[i].Cells[0].Value);
                            b_desc = Convert.ToString(dgvPost.Rows[i].Cells[1].Value);
                            tx = Convert.ToString(dgvPost.Rows[i].Cells[2].Value);
                            gl_cod = null;
                            if (Information.IsNothing(dgvPost.Rows[i].Cells[3].Value) == false)
                            {
                                x4_ldgr = Convert.ToString(dgvPost.Rows[i].Cells[3].Value);
                                s1 = "select GLCODE from glmst where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and LDESC='" + x4_ldgr + "' and MTYPE='L' and (ACTV_FLG IS NULL OR ACTV_FLG='True')  ";
                                cmd = new SqlCommand(s1, edpcon.mycon, Tran);
                                adp.SelectCommand = cmd;
                                if (Information.IsNothing(ds.Tables["glcode_slct"]) == false)
                                {
                                    ds.Tables["glcode_slct"].Clear();
                                }
                                Boolean b2 = Convert.ToBoolean(adp.Fill(ds, "glcode_slct"));
                                if (b2 == true)
                                {
                                    gl_cod = Convert.ToString(ds.Tables["glcode_slct"].Rows[0][0]);
                                }
                            }

                            z2 = i;//dgvPost.CurrentCell.RowIndex;
                            z = Convert.ToInt32(arList[z2]);
                            string s2 = "select TaxStatus from TaxMaster where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and Type_Code=" + z + "";
                            cmd = new SqlCommand(s2, edpcon.mycon, Tran);
                            adp.SelectCommand = cmd;
                            if (Information.IsNothing(ds.Tables["t21"]) == false)
                            {
                                ds.Tables["t21"].Clear();
                            }
                            Boolean bl21 = Convert.ToBoolean(adp.Fill(ds, "t21"));
                            if (bl21 == true)
                            {
                                z1 = Convert.ToInt32(ds.Tables["t21"].Rows[0][0]);
                                if (z1 == 1)
                                {
                                    if (tx == "NO")
                                    {
                                        if (gl_cod == null || gl_cod == "")
                                        {
                                            error = true;
                                            if (rollback_flg != 1)
                                            {
                                                Tran.Rollback();
                                            }
                                            rollback_flg = 1;
                                            return;
                                        }
                                    }
                                    else if (tx == "YES")
                                    {
                                        gl_cod = "";
                                    }
                                    else if (tx == null || tx == "")
                                    {
                                        error = true;
                                        if (rollback_flg != 1)
                                        {
                                            Tran.Rollback();
                                        }
                                        rollback_flg = 1;
                                        return;
                                    }
                                }

                                frm = Convert.ToString(dgvPost.Rows[i].Cells[5].Value);
                                pls_mns = Convert.ToString(dgvPost.Rows[i].Cells[4].Value);
                                typ_code = Convert.ToInt32(arList[i]);
                                post_ef_amt = Convert.ToString(dgvPost.Rows[i].Cells[6].Value);
                                acc_ins();
                            }
                        }
                    }
                }
                else if (spc_acc == null)
                {
                    sln = null; b_desc = null; trm = t_type; tx = null; pls_mns = null; typ_code = 0; post_ef_amt = null; frm = null;
                    acc_ins();
                }
            }
        }

        //}
        //----------------------------------------------------------------------------
        public void acc_ins()
        {
            string st; flg += 1;
            if (d_code != 0)
            {
                if (ins_updt_chk == false)
                {
                    if (flg == 1)
                    {
                        st = "delete from AccPost where FICODE='" + fi_cod + "' and GCode='" + g_cod + "' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + "";
                        cmd = new SqlCommand(st, edpcon.mycon, Tran);
                        adp.DeleteCommand = cmd;
                        cmd.ExecuteNonQuery();
                    }
                    if (post_ef_amt == "True")
                    {
                        post_ef_amt = "1";
                    }
                    else if (post_ef_amt == "False")
                    {
                        post_ef_amt = "0";
                    }
                    st = "insert into AccPost values('" + fi_cod + "','" + g_cod + "','" + t_entry + "'," + d_code + ",'" + sln + "','" + b_desc + "','" + trm + "','" + tx + "'," + gl_cod + ",'" + frm + "','" + pls_mns + "'," + typ_code + ",'" + post_ef_amt + "')";
                    cmd = new SqlCommand(st, edpcon.mycon, Tran);
                    adp.InsertCommand = cmd;
                    cmd.ExecuteNonQuery();

                    //st = "update AccPost set BTerms_Desc='" + b_desc + "',Term_Type='" + trm + "',Tax='" + tx + "',Glcode='" + gl_cod + "',Formula='" + frm + "',PlusMinus='" + pls_mns + "'";
                    //st += "where FICODE='" + fi_cod + "' and GCode='" + g_cod + "' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + " and Sl_No='" + sln + "' and Type_Code='"+typ_code+"'";
                    //cmd = new SqlCommand(st, edpcon.mycon, Tran);
                    //adp.UpdateCommand = cmd;
                    //cmd.ExecuteNonQuery();
                }
            }
            else
            {
                if (post_ef_amt == "True")
                {
                    post_ef_amt = "1";
                }

                st = "insert into AccPost values('" + fi_cod + "','" + g_cod + "','" + t_entry + "'," + temp_dcode + ",'" + sln + "','" + b_desc + "','" + trm + "','" + tx + "','" + gl_cod + "','" + frm + "','" + pls_mns + "'," + typ_code + ",'" + post_ef_amt + "')";
                cmd = new SqlCommand(st, edpcon.mycon, Tran);
                adp.InsertCommand = cmd;
                cmd.ExecuteNonQuery();
            }
        }
        //----------------------------------------------------------------------------
        public void type_doc_insert()
        {
            string s, st1;
            //int j;
            int x = dgvPost.Rows.Count - 1;
            if (x >= 0)
            {
                for (int i = 0; i <= x; i++)
                {
                    st1 = Convert.ToString(dgvPost.Rows[i].Cells[6].Value);
                    if (st1 == "1" || st1 == "True")
                    {
                        ef_amt = "1";
                        break;
                    }
                }

            }
            if (ef_amt != "1")
            {
                ef_amt = "0";
            }
            if (d_code != 0)
            {
                if (ins_updt_chk == false)
                {
                    s = "update TypeDoc set Type_Desc='" + txtDesc.Text + "',Specific_Acc='" + spc_acc + "',METHOD='" + mtd + "',Effect_Amt='" + ef_amt + "',Req_Acc='" + acp_req + "'";
                    s += "where GCode='" + g_cod + "' and FICODE='" + fi_cod + "' and T_ENTRY='" + t_entry + "' and Desccode=" + d_code + " and Session = '" + cmbYear.Text + "' ";
                    cmd = new SqlCommand(s, edpcon.mycon, Tran);
                    adp.UpdateCommand = cmd;
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                temp_dcode = desc_code();
                s = "insert into TypeDoc (FICode,GCODE,T_ENTRY,Desccode,Type_Desc,Specific_Acc,METHOD,Effect_Amt,Req_Acc,User_Code,Bill_Type,Bill_Format,Session, locid,clid,coid) values('" + fi_cod + "','" + g_cod + "','" + t_entry + "'," + temp_dcode + ",'" + txtDesc.Text + "','" + spc_acc + "','" + mtd + "','" + ef_amt + "','" + acp_req + "','" + edpcom.PCURRENT_USER + "','','','" + cmbYear.Text + "','0','0','0')";
                cmd = new SqlCommand(s, edpcon.mycon, Tran);
                adp.InsertCommand = cmd;
                cmd.ExecuteNonQuery();
            }
        }

        //Tran.Commit(); 
        //}
        //-----------------------------------------------------------------------------
        public int desc_code()
        {
            int rtrn_val = 0;
            string s = "select max(isNull(Desccode,0)) from TypeDoc where GCode='" + g_cod + "' and FICODE='" + fi_cod + "' and T_ENTRY='" + t_entry + "' and Session='" + cmbYear.Text + "'";// and Type_Desc='" + txtDesc.Text + "'";
            DataTable dt = clsDataAccess.RunQDTbl(s);
            //cmd = new SqlCommand(s, edpcon.mycon, Tran);
            //adp.InsertCommand = cmd;
            //Boolean blnMax = Convert.ToBoolean(adp.Fill(ds, "tb_max"));
            if (dt.Rows.Count >0)
            {
                try
                {
                    rtrn_val = Convert.ToInt32(dt.Rows[0][0].ToString());
                    rtrn_val += 1;
                }
                catch
                {
                    rtrn_val = 1;
                }
            }
            else
            {
                rtrn_val = 1;
            }
            return rtrn_val;
        }

        private void dgvPost_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[3].Value != null) && (dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[3].Value.ToString().ToUpper() != "BASIC"))
            {
                string mgroup = edpcom.GetresultS("select mgroup from glmst where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and ldesc='" + dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[3].Value.ToString() + "' and mtype='L' and (ACTV_FLG IS NULL OR ACTV_FLG='True')  ");
                if ((mgroup.Trim() == "8") || (mgroup.Trim() == "9") || (mgroup.Trim() == "10") || (mgroup.Trim() == "11"))
                {
                    dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[6].ReadOnly = true;
                    dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[6].Value = false;
                }
                else dgvPost.Rows[dgvPost.CurrentCell.RowIndex].Cells[6].ReadOnly = false;
            }
        }

        private void rdbMul_CheckedChanged(object sender, EventArgs e)
        {
            rdbNo.Checked = false;
            //rdbSing.Checked = true;
            tbcActype.SelectedIndex = 1;
            lbxList.Items.Clear();
            txtSelected.Text = "";
            //lstbox_fill();
            GRID_FILL();
        }

        private void txtDesc_Leave(object sender, EventArgs e)
        {
            if (d_code == 0)
            {
                clear_function();
                lst.Items.Clear();
                txtSelected.Text = "";

                string Des_Name = edpcom.GetresultS("select Type_Desc,desccode from TypeDoc where FICODE='" + fi_cod + "' AND GCode='" + g_cod + "' and T_ENTRY='" + t_entry + "' and Type_Desc='" + txtDesc.Text + "' and Session='" + cmbYear.Text + "' ",edpcon.mycon, Tran);
                if (Des_Name != null && Des_Name != "")
                {
                    EDPMessage.Show("Description Name ALready Exit");
                    txtDesc.Focus();
                }
            }
        }



        private void rdbYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbYes.Checked == true)
            {
                gbxRel.Enabled = true;
                tbcActype.Enabled = true;
                rdbNo.Checked = false;
                //req_acc = 1;
            }
        }

        private void rdbNo_CheckedChanged(object sender, EventArgs e)
        {
            gbxRel.Enabled = false;
            tbcActype.Enabled = false;
            req_acc = 0;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string str = null;
                Boolean del_chk = tran_check();
                if (del_chk == false)
                {
                    //string dc= MessageBox.Show("Transaction Exists..You Are Not Allowed To Delete Account Posting. But You can change doc. Numbering", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString();
                    EDPMessage.Show("Transaction Exists..You Are Not Allowed To" + Environment.NewLine + "Delete Account Posting. But You can change doc. Numbering", "Information", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
                    if (EDPMessage.ButtonResult == "edpYES")
                    {
                        tbcMain.SelectedIndex = 0;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {

                    EDPMessage.Show("Do you want to Delete?", "Deletion!", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
                    if (EDPMessage.ButtonResult == "edpYES")
                    {
                        str = "delete from TypeDoc where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and T_ENTRY='" + t_entry + "' and DESCCODE='" + d_code + "' and Session = '" + cmbYear.Text + "'";
                        cmd = new SqlCommand(str, edpcon.mycon, Tran);
                        cmd.ExecuteNonQuery();
                        str = "delete from AccPost where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and T_ENTRY='" + t_entry + "' and DESCCODE='" + d_code + "'";// and Session ='" + cmbYear.Text + "'";
                        cmd = new SqlCommand(str, edpcon.mycon, Tran);
                        cmd.ExecuteNonQuery();
                        str = "delete from docnumber where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and T_ENTRY='" + t_entry + "' and DESCCODE='" + d_code + "' and Session ='" + cmbYear.Text + "'";
                        cmd = new SqlCommand(str, edpcon.mycon, Tran);
                        cmd.ExecuteNonQuery();
                        str = "delete from DOCGEN where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and T_ENTRY='" + t_entry + "' and DESCCODE='" + d_code + "' and Session ='" + cmbYear.Text + "'";
                        cmd = new SqlCommand(str, edpcon.mycon, Tran);
                        cmd.ExecuteNonQuery();
                        EDPMessage.Show("Information Deleted", "Information");
                        page_clear();
                        Tran.Commit();
                        edpcon.mycon.Close();
                        edpcon.mycon.Open();
                        Tran = edpcon.mycon.BeginTransaction();
                    }
                    else
                    {
                        return;
                    }

                }
            }
            catch
            {
                Tran.Rollback();
                EDPMessage.Show("Error In Delete Operation..Form Will Be Closed", "Warning", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_WARNING);
                edpcon.mycon.Close();
                edpcon.mycon.Open();
                //Tran = edpcon.mycon.BeginTransaction();
                this.Close();
            }
        }
        //---------------------------------------------------------------------------
        public Boolean tran_check()
        {
            Boolean del = false;
            try
            {
                string strQryDocNoBillExists = "select count(*) from paybill where (Descord=" + d_code + ") and (session='" + cmbYear.Text + "')";
                int intNoOfBill = Convert.ToInt32(clsDataAccess.GetresultS(strQryDocNoBillExists));
                if (intNoOfBill>0)
                {
                    //string str = null;// "SELECT * FROM DATA CROSS JOIN idata CROSS JOIN Idocmast WHERE (DATA.FICode = '" + fi_cod + "') AND (DATA.GCODE = '" + g_cod + "') AND (DATA.T_ENTRY = '" + t_entry + "') AND (DATA.DESCCODE = '" + d_code + "')";
                    //str = "select * from DATA where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + "";
                    //cmd = new SqlCommand(str, edpcon.mycon, Tran);
                    //adp.SelectCommand = cmd;
                    //if (Information.IsNothing(ds.Tables["d1"]) == false)
                    //{
                    //    ds.Tables["d1"].Clear();
                    //}
                    //del = Convert.ToBoolean(adp.Fill(ds, "d1"));
                    //str = null;
                    //str = "select * from idata where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + "";
                    //cmd = new SqlCommand(str, edpcon.mycon, Tran);
                    //adp.SelectCommand = cmd;
                    //if (Information.IsNothing(ds.Tables["d2"]) == false)
                    //{
                    //    ds.Tables["d2"].Clear();
                    //}
                    //del = Convert.ToBoolean(adp.Fill(ds, "d2"));
                    del = false;
                }
                else
                {
                    del = true;
                }
                //str = null;
                //str = "select * from Idocmast where FICODE='" + fi_cod + "' and GCODE='" + g_cod + "' and T_ENTRY='" + t_entry + "' and DESCCODE=" + d_code + "";
                //cmd = new SqlCommand(str, edpcon.mycon, Tran);
                //adp.SelectCommand = cmd;
                //if (Information.IsNothing(ds.Tables["d3"]) == false)
                //{
                //    ds.Tables["d3"].Clear();
                //}
                //del = Convert.ToBoolean(adp.Fill(ds, "d3"));                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return del;
        }

        private void frmAccountPosting_FormClosing(object sender, FormClosingEventArgs e)
        {
            edpcom.UpdateMidasLog(this, false);
            edpcom.saveFormPosition(this.Name, this.Location);
        }

        private void txtSeldoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSeldoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDesc.Focus();
            }
            else if (e.KeyCode == Keys.Space)
            {
                cmbDesg_DropDown(sender, new EventArgs());
            }
        }

        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rdbAuto.Focus();
                txtPref.Focus();
            }
            else if (e.KeyCode == Keys.Space)
            {
                txtDesc_DoubleClick(sender, new EventArgs());
            }
        }

        private void txtPref_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nudPref.Focus();
            }
        }

        private void nudPref_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSuf.Focus();
            }
        }

        private void txtSuf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nudSuf.Focus();
            }
        }

        private void nudSuf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPad.Focus();
            }
        }

        private void txtPad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNumsep.Focus();
            }
        }

        private void txtNumsep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPrev.Focus();
            }
        }

        private void txtDemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbcMain.SelectedTab = tbcMain.TabPages[1];
            }
        }

        private void frmAccountPosting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void cmbDesg_DropDown(object sender, EventArgs e)
        {
            t_entry = "";
            txtDesc.Text = "";
            page_clear();
            tbcMain.SelectedIndex = 0;

            DataTable dt = clsDataAccess.RunQDTbl("select TypeName as 'Type Name',T_ENTRY from TypeMast where ficode='1'and gcode='1'");
            if (dt.Rows.Count > 0)
            {
                txtSeldoc.LookUpTable = dt;
                txtSeldoc.ReturnIndex = 1;
            }
        }

        private void cmbDesg_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            t_entry = txtSeldoc.ReturnValue;
        }

        private void rdbAuto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtDesc_DropDown(object sender, EventArgs e)
        {
            if (txtSeldoc.Text != "")
            {
                if (r_doc == 0)
                {
                    clear_function();
                    dt_doc = clsDataAccess.RunQDTbl("select distinct Type_Desc,desccode,Session from TypeDoc where FICODE='" + fi_cod + "' AND GCode='" + g_cod + "' and T_ENTRY='" + t_entry + "' and Session ='" + cmbYear.Text + "'");
                    if (dt_doc.Rows.Count > 0)
                    {
                        txtDesc.LookUpTable = dt_doc;
                        txtDesc.ReturnIndex = 1;
                    }
                    else
                    {
                        dt_doc = clsDataAccess.RunQDTbl("select distinct Type_Desc,desccode,Session from TypeDoc where FICODE='" + fi_cod + "' AND GCode='" + g_cod + "' and T_ENTRY='" + t_entry + "'");//and Session ='" + cmbYear.Text + "'");
                        if (dt_doc.Rows.Count > 0)
                        {
                            txtDesc.LookUpTable = dt_doc;
                            txtDesc.ReturnIndex = 1;
                        }

                    }
                }
                else
                {
                    clear_function();
                    dt_doc = clsDataAccess.RunQDTbl("select distinct Type_Desc,desccode,Session from TypeDoc where FICODE='" + fi_cod + "' AND GCode='" + g_cod + "' and T_ENTRY='" + t_entry + "'");
                    if (dt_doc.Rows.Count > 0)
                    {
                        txtDesc.LookUpTable = dt_doc;
                        txtDesc.ReturnIndex = 1;
                    }
                    

                }
            }
            else
            {
                EDPMessage.Show("Plese Select Document Type", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
        }

        private void txtDesc_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (txtDesc.Text != "")
            {
                string s1 = "select Desccode,Specific_Acc,Req_Acc from TypeDoc where GCode='" + g_cod + "' and FICODE='" + fi_cod + "' and Type_Desc='" + txtDesc.Text + "' and Session ='" + cmbYear.Text + "'";
                cmd = new SqlCommand(s1, edpcon.mycon, Tran);
                adp.SelectCommand = cmd;
                if (Information.IsNothing(ds.Tables["tb_ck"]) == false)
                {
                    ds.Tables["tb_ck"].Clear();
                }
                Boolean b1 = Convert.ToBoolean(adp.Fill(ds, "tb_ck"));
                if (b1 == true)
                {
                    d_code = Convert.ToInt32(ds.Tables["tb_ck"].Rows[0][0]);
                    sp_ac = Convert.ToInt32(ds.Tables["tb_ck"].Rows[0][1]);
                    req_acc = Convert.ToInt32(ds.Tables["tb_ck"].Rows[0][2]);
                    if (req_acc == 1)
                    {
                        rdbYes.Checked = true;
                        if (sp_ac == 0)
                        {
                            lbxList.Items.Clear();
                            dgvPost.Rows.Clear();
                            lstbox_fill();
                            rdbSing.Checked = true;
                        }
                        else
                        {
                            lbxList.Items.Clear();
                            dgvPost.Rows.Clear();
                            GRID_FILL();
                            rdbMul.Checked = true;
                        }

                    }
                    else rdbNo.Checked = true;
                    t_sprt = 1;
                    rdbAuto.Checked = true;
                    docnumberInfo_Fill();
                }
            }
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            page_clear();
            txtSeldoc.Focus();
        }

        private void btn_showall_Click(object sender, EventArgs e)
        {
            r_doc = 1;
            txtDesc.PopUp();
            r_doc = 0;
        }



        //----------------------------------------------------------------------------
    }
}