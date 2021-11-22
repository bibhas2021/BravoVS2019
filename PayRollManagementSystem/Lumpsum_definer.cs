using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using Edpcom;

namespace PayRollManagementSystem
{
    public partial class Lumpsum_definer : EDPComponent.FormBaseERP
    {
        Edpcom.EDPCommon edpcom = new EDPCommon();
        public Lumpsum_definer()
        {
            InitializeComponent();

        }
        Hashtable chk_lid=new Hashtable();
        Hashtable hsh_lumpid = new Hashtable();
        Hashtable hsh_lumpname = new Hashtable();
        Hashtable hsh_lumpamt = new Hashtable();
        Hashtable hsh_lumpgrade = new Hashtable();
        DataTable dt_lm=new DataTable();
        int lid=0,lumid=0;
        DataColumn dc1=new DataColumn("Sal Structure");
        DataColumn dc2=new DataColumn("Name");
        DataColumn dc3=new DataColumn("Type");
        DataColumn dc4=new DataColumn("Grade");
        DataColumn dc5=new DataColumn("Amount");
        DataColumn dc6 = new DataColumn("desgid");  
        DataRow dr;

        private void btnclose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Lumpsum_definer_Load(object sender, EventArgs e)
        {
            //cmbgrade.Items.Clear();
            ////string s = "select section from tbl_Employee_Sectionmaster";
            //string s = "select DesignationName from tbl_Employee_DesignationMaster";
            //Load_Data(s, cmbgrade, -1);
            this.HeaderText = "Lumpsum Defination";

            try
            {
                get_Lumpsum(0, 0);
            }
            catch { }
            //if (cmbsal_structure.Visible)
            //    get_Lumpsum(Get_SalID(cmbsal_structure.Text.Trim()), 1);
            //else
            //    get_Lumpsum(0,0);          
        }

        private void rbgradewise_CheckedChanged(object sender, EventArgs e)
        {
            if (rbgradewise.Checked)
            {
                cmbDesignation.Enabled = true;
                cmbDesignation.Text = "";
                //cmbgrade.SelectedIndex = -1;
                //cmbgrade.Enabled = true;
            }
            else
            {
                cmbDesignation.Enabled = false;
                cmbDesignation.Text = "";
                //cmbgrade.SelectedIndex = -1;
                //cmbgrade.Enabled = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsValidation.ValidateTextBox(txtname, "", "Please Enter Lumpsum Name"))
                {
                    if (rbgradewise.Checked)
                    {
                       // if (clsValidation.ValidateComboBox(cmbgrade, "", "Please Select Grade"))
                        if (cmbDesignation.Text.Trim()=="")
                        {
                            MessageBox.Show("Please Select Designation", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }else
                        {
                            save_ls();
                        }
                    }
                    else
                        save_ls();

                }
                if (cmbsal_structure.Visible)
                    get_Lumpsum(Get_SalID(cmbsal_structure.Text.Trim()), 1);
                else
                    get_Lumpsum(0, 0);
                
            }
            catch (Exception x) { }
        }
        public void save_ls()
        {
            bool st = false;
            string s = "";
            txtpfamt.Text = "0";
            string desgid = cmbDesignation.ReturnValue;
            if (desgid.Trim() == "" || cmbDesignation.Text.Trim()=="")
            {
                desgid = "0";
            }
            s = "Select max(LUMPID) from tbl_Employee_Lumpsum";
            DataTable max_No = clsDataAccess.RunQDTbl(s);
            if (Information.IsNumeric(max_No.Rows[0][0])== true)
                lid = Convert.ToInt32(max_No.Rows[0][0]) + 1;
            else
                lid = 1;            
           

            //Get_Grade(cmbgrade.Text.Trim())
            if (cmbsal_structure.Visible)
            {
                if (!hsh_lumpname.ContainsKey(txtname.Text.Trim() + "/" + "1"))
                {
                    if (rbgradewise.Checked)
                        s = "insert into tbl_Employee_Lumpsum(LUMPID,LUMPNAME,LUMPTYPE,GRADE,STRUCID,AMOUNT,Pf_Amt) values(" + lid + ", '" + txtname.Text.Trim() + "', 1, " + desgid + "," + Get_SalID(cmbsal_structure.Text.Trim()) + ", " + Convert.ToDouble(txtamt.Text.Trim()) + ",'"+txtpfamt.Text+"')";   //
                    
                    else
                        s = "insert into tbl_Employee_Lumpsum(LUMPID,LUMPNAME,LUMPTYPE,STRUCID,AMOUNT,Pf_Amt) values(" + lid + ", '" + txtname.Text.Trim() + "', 1, " + Get_SalID(cmbsal_structure.Text.Trim()) + ", " + Convert.ToDouble(txtamt.Text.Trim()) + ",'" + txtpfamt.Text + "')";   //
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Do you Want To Update ?" + txtname.Text.Trim(), "Question", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
                    if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
                    {
                        if (rbgradewise.Checked)
                            s = "update tbl_Employee_Lumpsum set LUMPNAME='" + txtname.Text.Trim() + "', GRADE=" + desgid + ", AMOUNT=" + txtamt.Text.Trim() + " ,Pf_Amt='" + txtpfamt.Text + "' where strucid=" + Get_SalID(cmbsal_structure.Text.Trim()) + " and lumpid=" + get_LumpID(txtname.Text.Trim(), 1);
                        
                        else
                            s = "update tbl_Employee_Lumpsum set LUMPNAME='" + txtname.Text.Trim() + "', AMOUNT=" + Convert.ToDouble(txtamt.Text.Trim()) + " ,Pf_Amt='" + txtpfamt.Text + "' where strucid=" + Get_SalID(cmbsal_structure.Text.Trim()) + " and lumpid=" + get_LumpID(txtname.Text.Trim(), 1);                        
                    }
                }
                
            }
            else
            {
                //if (!hsh_lumpname.ContainsKey(txtname.Text.Trim() + "/" + "0"))
                 s = "select LUMPNAME from tbl_Employee_Lumpsum where LUMPID=" + get_LumpID(txtname.Text.Trim(), 0)+" and GRADE=" + desgid + " ";
                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count == 0)
                {
                    s = "select LUMPNAME from tbl_Employee_Lumpsum where LUMPID=" + get_LumpID(txtname.Text.Trim(), 0) + " ";
                    dts.Rows.Clear();
                    dts = clsDataAccess.RunQDTbl(s);
                    if (dts.Rows.Count == 0)
                    {
                        if (rbgradewise.Checked)
                            s = "insert into tbl_Employee_Lumpsum(LUMPID,LUMPNAME,LUMPTYPE,GRADE,AMOUNT,Pf_Amt) values(" + lid + ", '" + txtname.Text.Trim() + "', 0, " + desgid + ", " + Convert.ToDouble(txtamt.Text.Trim()) + ",'" + txtpfamt.Text + "')";

                        else
                            s = "insert into tbl_Employee_Lumpsum(LUMPID,LUMPNAME,LUMPTYPE,AMOUNT,Pf_Amt,GRADE) values(" + lid + ", '" + txtname.Text.Trim() + "', 0, " + Convert.ToDouble(txtamt.Text.Trim()) + ",'" + txtpfamt.Text + "','0')"; 
                    }
                    else
                    {
                        if (rbgradewise.Checked)
                            s = "insert into tbl_Employee_Lumpsum(LUMPID,LUMPNAME,LUMPTYPE,GRADE,AMOUNT,Pf_Amt) values(" + get_LumpID(txtname.Text.Trim(), 0) + ", '" + txtname.Text.Trim() + "', 0, " + desgid + ", " + Convert.ToDouble(txtamt.Text.Trim()) + ",'" + txtpfamt.Text + "')";

                        else
                            s = "insert into tbl_Employee_Lumpsum(LUMPID,LUMPNAME,LUMPTYPE,AMOUNT,GRADE,Pf_Amt) values(" + get_LumpID(txtname.Text.Trim(), 0) + ", '" + txtname.Text.Trim() + "', 0, " + Convert.ToDouble(txtamt.Text.Trim()) + ",'0','" + txtpfamt.Text + "')";
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Do You Want To Update ?", "Question", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
                    if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
                    {
                        
                        if (rbgradewise.Checked)
                            s = "update tbl_Employee_Lumpsum set LUMPNAME='" + txtname.Text.Trim() + "', AMOUNT=" + txtamt.Text.Trim() + ",Pf_Amt='" + txtpfamt.Text + "' where lumpid=" + get_LumpID(txtname.Text.Trim(), 0) + " and GRADE=" + desgid + " ";

                        else
                            s = "update tbl_Employee_Lumpsum set LUMPNAME='" + txtname.Text.Trim() + "',GRADE='0', AMOUNT=" + Convert.ToDouble(txtamt.Text.Trim()) + ",Pf_Amt='" + txtpfamt.Text + "' where lumpid=" + get_LumpID(txtname.Text.Trim(), 0);
                    }
                }
            }
            st = clsDataAccess.RunNQwithStatus(s);
            if (st)
            {
                ERPMessageBox.ERPMessage.Show("Data Saved Successfully", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                Clear_Data();
            }
        }
        private void Clear_Data()
        {
            cmbsal_structure.Text = "";
            txtname.Text = "";
            rbeveryone.Checked = true;
            //cmbgrade.Text = "";
            cmbDesignation.Text = "";

            txtamt.Text = "";
        }
        public void get_Lumpsum(int strID, int ltype)     
        {
            dt_lm.Clear();
            dt_lm.Columns.Clear();
            DataTable dt=new DataTable();
            string s1="";
            if (txtSearch.Text == "")
            {
                if (ltype == 1)
                    s1 = "select LUMPNAME,LUMPTYPE,GRADE,STRUCID,AMOUNT,LUMPID from tbl_Employee_Lumpsum where STRUCID=" + strID + " and LUMPTYPE=" + ltype + " order by LUMPNAME ";
                else
                    s1 = "select LUMPNAME,LUMPTYPE,GRADE,STRUCID,AMOUNT,LUMPID from tbl_Employee_Lumpsum where LUMPTYPE=" + ltype + " order by LUMPNAME ";
            }
            else
            {
                if (ltype == 1)
                    s1 = "select LUMPNAME,LUMPTYPE,GRADE,STRUCID,AMOUNT,LUMPID from tbl_Employee_Lumpsum where (LUMPNAME like '" + txtSearch.Text.Trim() + "%') and STRUCID=" + strID + " and LUMPTYPE=" + ltype + " order by LUMPNAME ";
                else
                    s1 = "select LUMPNAME,LUMPTYPE,GRADE,STRUCID,AMOUNT,LUMPID from tbl_Employee_Lumpsum where (LUMPNAME like '" + txtSearch.Text.Trim() + "%') and LUMPTYPE=" + ltype + " order by LUMPNAME ";
            }
            dt=clsDataAccess.RunQDTbl(s1);
            if(dt.Rows.Count>0)
            {
                if (ltype==1)
                {
                    dt_lm.Columns.Add(dc1);
                    dt_lm.Columns.Add(dc2);
                    dt_lm.Columns.Add(dc3);
                    dt_lm.Columns.Add(dc4);
                    dt_lm.Columns.Add(dc5);
                    dt_lm.Columns.Add(dc6);
                    for (int c = 0; c < dt.Rows.Count; c++)
                    {

                        dr = dt_lm.NewRow();
                        dr[0] = Get_SalName(Convert.ToInt32(dt.Rows[c][3]));
                        dr[1] = dt.Rows[c][0].ToString();
                        if (dt.Rows[c][2].ToString() != "")
                        {
                            dr[2] = rbgradewise.Text;
                            dr[3] = Get_Section(Convert.ToInt32(dt.Rows[c][2]));// dt.Rows[c][2].ToString();
                            dr[5] = dt.Rows[c][2].ToString();
                        }
                        else
                        {
                            dr[2] = rbeveryone.Text;
                            dr[3] = " ";
                            dr[5] = "0";
                        }
                        //dr[4] = string.Format("{0:N}", Convert.ToDouble(dt.Rows[c][4]));
                        dr[4] = Convert.ToDouble(dt.Rows[c][4]).ToString(EDPCommon.SetDecimalPlace(2));                        
                        dt_lm.Rows.Add(dr);
                        if (!hsh_lumpid.ContainsKey(dt.Rows[c][5].ToString() + "/" + dt.Rows[c][1].ToString()))
                            hsh_lumpid.Add(dt.Rows[c][5].ToString() + "/" + dt.Rows[c][1].ToString(), dt.Rows[c][0].ToString());
                        if (!hsh_lumpname.ContainsKey(dt.Rows[c][0].ToString() + "/" + dt.Rows[c][1].ToString()))
                            hsh_lumpname.Add(dt.Rows[c][0].ToString() + "/" + dt.Rows[c][1].ToString(), dt.Rows[c][0].ToString());

                    }
                }
                else
                {
                    dt_lm.Columns.Add(dc2);
                    dt_lm.Columns.Add(dc3);
                    dt_lm.Columns.Add(dc4);
                    dt_lm.Columns.Add(dc5);
                    dt_lm.Columns.Add(dc6);   
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        dr = dt_lm.NewRow();
                        dr[0] = dt.Rows[k][0].ToString();
                        if (dt.Rows[k][2].ToString() != "")
                        {
                            if (dt.Rows[k][2].ToString() != "0")
                            {
                                dr[1] = rbgradewise.Text;
                                dr[2] = Get_Section(Convert.ToInt32(dt.Rows[k][2]));
                                dr[4] = dt.Rows[k][2].ToString();
                            }
                            else
                            {
                                dr[1] = "Everyone";
                                dr[2] = Get_Section(Convert.ToInt32(dt.Rows[k][2]));
                                dr[4] = dt.Rows[k][2].ToString();
                            }
                        }
                        else
                        {
                            dr[1] = rbeveryone.Text;
                            dr[2] = " ";
                        }
                        //dr[3] = string.Format("{0:N}", Convert.ToDouble(dt.Rows[k][4]));
                        dr[3] = Convert.ToDouble(dt.Rows[k][4]).ToString(EDPCommon.SetDecimalPlace(2));                      
                        
                        dt_lm.Rows.Add(dr);
                        if (!hsh_lumpid.ContainsKey(dt.Rows[k][5].ToString() + "/" + dt.Rows[k][1].ToString()))
                            hsh_lumpid.Add(dt.Rows[k][5].ToString() + "/" + dt.Rows[k][1].ToString(), dt.Rows[k][0].ToString());
                        if (!hsh_lumpname.ContainsKey(dt.Rows[k][0].ToString() + "/" + dt.Rows[k][1].ToString()))
                            hsh_lumpname.Add(dt.Rows[k][0].ToString() + "/" + dt.Rows[k][1].ToString(), dt.Rows[k][0].ToString());
                    }
                }
                dgvlsum.DataSource = "";
                dgvlsum.DataSource = dt_lm;
                lid = dt.Rows.Count + 1;
                dgvlsum.Columns["Desgid"].Visible = false;
                if (dt_lm.Rows.Count >= 1)
                {
                    try
                    {
                        //cmbgrade.SelectedIndex = -1;
                        if (cmbsal_structure.Visible)
                        {
                            txtname.Text = dgvlsum.Rows[0].Cells[1].Value.ToString();
                            if (dgvlsum.Rows[0].Cells[2].Value.ToString() == "Everyone")
                                rbeveryone.Checked = true;
                            else
                            {
                                rbgradewise.Checked = true;
                               // cmbgrade.Text = dgvlsum.Rows[0].Cells[3].Value.ToString();
                                 cmbDesignation.Text = dgvlsum.Rows[0].Cells["Grade"].Value.ToString();
                                 cmbDesignation.ReturnValue = dgvlsum.Rows[0].Cells["DesgId"].Value.ToString();
                            }
                            txtamt.Text = dgvlsum.Rows[0].Cells[4].Value.ToString();
                            txtpfamt.Text = dgvlsum.Rows[0].Cells[5].Value.ToString();
                        }
                        else
                        {
                            txtname.Text = dgvlsum.Rows[0].Cells[0].Value.ToString();
                            if (dgvlsum.Rows[0].Cells[1].Value.ToString() == "Everyone")
                                rbeveryone.Checked = true;
                            else
                            {
                                rbgradewise.Checked = true;
                                //cmbgrade.Enabled = true;
                                //cmbgrade.SelectedIndex = 0;
                                //cmbgrade.Text = dgvlsum.Rows[0].Cells[2].Value.ToString();
                                cmbDesignation.Text = dgvlsum.Rows[0].Cells["Grade"].Value.ToString();
                                cmbDesignation.ReturnValue = dgvlsum.Rows[0].Cells["DesgId"].Value.ToString();
                            }
                            txtamt.Text = dgvlsum.Rows[0].Cells[3].Value.ToString();
                            txtpfamt.Text = dgvlsum.Rows[0].Cells[4].Value.ToString();
                        }
                    }
                    catch (Exception x) { }
                }

            }
        }
        public string Get_SalName(int t)
        {
            string res="",sss="";
            DataTable dt5=new DataTable();
            sss="select salarycategory from tbl_Employee_SalaryStructure where slno="+t;
            dt5=clsDataAccess.RunQDTbl( sss);
            res=dt5.Rows[0][0].ToString();
            return res;
        }
        public int Get_SalID(string sname)
        {
            int res = 0;string sss = "";
            DataTable dt5=new DataTable();
            sss = "select slno from tbl_Employee_SalaryStructure where salarycategory='" + sname + "'";
            dt5=clsDataAccess.RunQDTbl( sss);
            res = Convert.ToInt32(dt5.Rows[0][0]);
            return res;
        }
        public int get_LumpID(string lname, int ltype)
        {
            int res = 0; string sss = "";
            DataTable dt5 = new DataTable();
            sss = "select lumpid from tbl_Employee_Lumpsum where lumpname='" + lname + "' and lumptype=" + ltype;
            dt5 = clsDataAccess.RunQDTbl(sss);
            if(dt5.Rows.Count>0)
            res = Convert.ToInt32(dt5.Rows[0][0]);
            return res;
        }

        private void dgvlsum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
              //  cmbgrade.SelectedIndex = -1;
                if (cmbsal_structure.Visible)
                {
                    txtname.Text = dgvlsum.Rows[e.RowIndex].Cells[1].Value.ToString();
                    if (dgvlsum.Rows[e.RowIndex].Cells[2].Value.ToString() == "Everyone")
                        rbeveryone.Checked = true;
                    else
                    {
                        rbgradewise.Checked = true;
                        //cmbgrade.Text = dgvlsum.Rows[e.RowIndex].Cells["Grade"].Value.ToString();
                        cmbDesignation.Text = dgvlsum.Rows[e.RowIndex].Cells["Grade"].Value.ToString();
                        cmbDesignation.ReturnValue = dgvlsum.Rows[e.RowIndex].Cells["DesgId"].Value.ToString();
                    }
                    txtamt.Text = dgvlsum.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtpfamt.Text = dgvlsum.Rows[e.RowIndex].Cells[5].Value.ToString();
                }
                else
                {
                    txtname.Text = dgvlsum.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (dgvlsum.Rows[e.RowIndex].Cells[1].Value.ToString() == "Everyone")
                    {
                        rbeveryone.Checked = true;
                         cmbDesignation.Text = "";
                         cmbDesignation.ReturnValue = "0";
                    }
                    else
                    {
                        rbgradewise.Checked = true;
                        //cmbgrade.Enabled = true;
                        //cmbgrade.SelectedIndex = 0;
                        //cmbgrade.Text = dgvlsum.Rows[e.RowIndex].Cells["Grade"].Value.ToString();
                        cmbDesignation.Text = dgvlsum.Rows[e.RowIndex].Cells["Grade"].Value.ToString();
                        cmbDesignation.ReturnValue = dgvlsum.Rows[e.RowIndex].Cells["DesgId"].Value.ToString();

                    }
                    txtamt.Text = dgvlsum.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtpfamt.Text = dgvlsum.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
            }
            catch (Exception x) { }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbsal_structure.Visible)
                {
                    del(1);
                    get_Lumpsum(Get_SalID(cmbsal_structure.Text.Trim()), 1);
                }
                else
                {
                    del(0);
                    get_Lumpsum(0, 0);
                }
                
            }
            catch (Exception x) { }
        }

        public int chk_lum(string fname)
        {

            return Convert.ToInt32(clsDataAccess.ReturnValue("select COUNT(*) from tbl_Employee_Assign_SalStructure "+
           "where (C_TYPE in ('COMPANY LUMPSUM','SAL STRUCTURE LUMPSUM','LUMPSUM')) and (C_DET in "+
           "(select LUMPID from tbl_Employee_Lumpsum where LUMPNAME='"+fname+"'))"));
        }
        public void del(int ltype)
        {
            bool sta = false;
            string desgid = cmbDesignation.ReturnValue;
            if (clsValidation.ValidateTextBox(txtname, "", "Lumpsum Name can't be blank"))
            {
                if (chk_lum(txtname.Text.Trim()) == 0)
                {
                    ERPMessageBox.ERPMessage.Show("Do U Want to Delete " + txtname.Text.Trim() + " ?", "Question", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
                    if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
                        sta = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Lumpsum where LUMPID=" + get_LumpID(txtname.Text.Trim(), ltype) + " and lumptype=" + ltype + " and GRADE ='" + desgid + "' ");
                    if (sta)
                    {
                        ERPMessageBox.ERPMessage.Show("Formula Deleted Sucessfully");
                        txtname.Text = string.Empty;
                        rbeveryone.Checked = true;
                        txtamt.Text = string.Empty;
                        txtpfamt.Text = string.Empty;
                        // cmbgrade.Text = string.Empty;
                        cmbDesignation.Text = "";
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Lumpsum already tagged in salary structure,Cannot delete");
                    return;

                }
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            try
            {
                txtname.Text = string.Empty;
                rbeveryone.Checked = true;
                txtamt.Text = string.Empty;
                txtpfamt.Text = string.Empty;
                //cmbgrade.Text = string.Empty;
                cmbDesignation.Text = "";
            }
            catch (Exception x) { }
        }

        //private void cmbgrade_DropDown(object sender, EventArgs e)
        //{
        //    cmbgrade.Items.Clear();
        //    //string s = "select section from tbl_Employee_Sectionmaster";
        //    string s = "select DesignationName from tbl_Employee_DesignationMaster";
        //    Load_Data(s, cmbgrade, -1);

            
        //}
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
        public string Get_Section(int SecId)
        {
            string qry = ""; string res = "";
            //qry = "select section from tbl_Employee_Sectionmaster where slno=" + SecId;
            qry = "select DesignationName from tbl_Employee_DesignationMaster where SlNo='" + SecId + "'";
            DataTable dtqry = new DataTable();
            dtqry = clsDataAccess.RunQDTbl(qry);
            if (dtqry.Rows.Count > 0)
            {
                res = dtqry.Rows[0][0].ToString();
            }
            return res;
        }

        private void txtamt_Validated(object sender, EventArgs e)
        {
            if (txtpfamt.Text == "")
                txtpfamt.Text = txtamt.Text;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                get_Lumpsum(0, 0);
            }
            catch { }
        }

        private void cmbDesignation_DropDown(object sender, EventArgs e)
        {
            string s = "select DesignationName,ShortForm,Slno,(select type from tbl_desg_type where slno=edm.type)Type from tbl_Employee_DesignationMaster edm order by SlNo";
            DataTable dt = clsDataAccess.RunQDTbl(s);
            cmbDesignation.LookUpTable = dt;
            cmbDesignation.ReturnIndex = 2;
        }

        private void cmbDesignation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            
        }

        



    }
}