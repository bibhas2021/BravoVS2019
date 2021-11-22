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
    public partial class slab_details : EDPComponent.FormBaseERP
    {
        public slab_details()
        {
            InitializeComponent();
        }
        Hashtable hsh_slabid = new Hashtable();
        Hashtable hsh_slb_dtl=new Hashtable();

        Hashtable hsh_slno = new Hashtable();
        Hashtable hsh_min = new Hashtable();
        Hashtable hsh_max = new Hashtable();
        Hashtable hsh_amt = new Hashtable();
        DataTable dt_slb_dtl = new DataTable();
        DataColumn dc1=new DataColumn("Sl.No.");
        DataColumn dc2 = new DataColumn("Minimum");
        DataColumn dc3 = new DataColumn("Maximum");
        DataColumn dc4 = new DataColumn("Amount");
        DataRow dr;

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnslab_Click(object sender, EventArgs e)
        {
            try { Slab_Definition sd = new Slab_Definition(); sd.ShowDialog(); }
            catch (Exception x) { }
        }

        private void slab_details_Load(object sender, EventArgs e)
        {
            try
            {
                get_Slab_df();
             
            }
            catch (Exception x) { }

        }
        public void get_Slab_df()
        {
            string s = "";
            s = "select slabname,slabid from tbl_Employee_Slab_Def";
                        DataTable dt = new DataTable();
            dt.Clear();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                for (int d = 0; d < dt.Rows.Count; d++)
                {
                    cmbslab.Items.Add(dt.Rows[d][0].ToString());
                    if (!hsh_slabid.ContainsKey(dt.Rows[d][0].ToString()))
                        hsh_slabid.Add(dt.Rows[d][0].ToString(), dt.Rows[d][1].ToString());
                }
                //cmbslab.SelectedIndex = 0;
            }
        }
        public void get_slab_dtl()
        {
            dt_slb_dtl.Clear();
            dt_slb_dtl.Columns.Clear();
            dt_slb_dtl.Columns.Add(dc1);
            dt_slb_dtl.Columns.Add(dc2);
            dt_slb_dtl.Columns.Add(dc3);
            dt_slb_dtl.Columns.Add(dc4);
            hsh_amt.Clear();
            hsh_max.Clear();
            hsh_min.Clear();
            string s = "";
            s = "select slabid,slno,mini,maxim,amt from tbl_Employee_Slab_Det where slabid=" + get_SlabID(cmbslab.Text.Trim());
            DataTable dt = new DataTable();
            dt.Clear();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                for (int y = 0; y < dt.Rows.Count; y++)
                {
                    dr = dt_slb_dtl.NewRow();

                    dr[0] = dt.Rows[y][1].ToString();
                    dr[1] = dt.Rows[y][2].ToString();
                    dr[2] = dt.Rows[y][3].ToString();
                    dr[3] = dt.Rows[y][4].ToString();
                    if (!hsh_min.ContainsKey(get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + dt.Rows[y][1].ToString()))
                        hsh_min.Add(get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + dt.Rows[y][1].ToString(), dt.Rows[y][2].ToString());
                    if (!hsh_max.ContainsKey(get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + dt.Rows[y][1].ToString()))
                        hsh_max.Add(get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + dt.Rows[y][1].ToString(), dt.Rows[y][3].ToString());
                    if (!hsh_amt.ContainsKey(get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + dt.Rows[y][1].ToString()))
                        hsh_amt.Add(get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + dt.Rows[y][1].ToString(), dt.Rows[y][4].ToString());

                    dt_slb_dtl.Rows.Add(dr);
                }

            }
            dgvfmula.DataSource = " ";
            dgvfmula.DataSource = dt_slb_dtl;
            txtmin.Text = string.Empty;
            txtmax.Text = string.Empty;
            txtamt.Text = string.Empty;
            txtslno.Text = string.Empty;
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            string s = "";
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                txtslno.Text = string.Empty;
                txtmax.Text = string.Empty;
                txtmin.Text = string.Empty;
                txtamt.Text = string.Empty;

                s = "select max(slno) from tbl_Employee_Slab_Det where slabid=" + get_SlabID(cmbslab.Text.Trim());
                dt = clsDataAccess.RunQDTbl(s);
                if (dt.Rows.Count>0)
                {
                    if (dt.Rows[0][0].ToString() != "")
                        txtslno.Text = Convert.ToString(Convert.ToInt32(dt.Rows[0][0]) + 1);
                    else
                        txtslno.Text = "1";
                }
                

            }
            catch (Exception x) { }
        }

        private void Save()
        {
            Boolean boolStatus = false; 
            if (clsValidation.ValidateComboBox(cmbslab, "", "Please Select Slab"))
            {
                if (clsValidation.ValidateTextBox(txtslno, "", "Please Enter SL. No."))
                {
                    string s = "",t="";
                    if (!hsh_min.ContainsKey(get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + txtslno.Text.Trim()))
                    {
                        t = chk_save();
                        if (t == "1")
                            boolStatus = true;
                        else if (t == "2")
                            boolStatus = false;
                        else
                            boolStatus = clsDataAccess.RunNQwithStatus(t);
                        if (boolStatus)
                        {
                            s = "insert into tbl_Employee_Slab_Det values(" + get_SlabID(cmbslab.Text.Trim()) + "," + txtslno.Text.Trim() + ", " + Convert.ToDouble(txtmin.Text.Trim()) + ",'" + txtmax.Text.Trim() + "'," + Convert.ToDouble(txtamt.Text.Trim()) + ")";
                            boolStatus = clsDataAccess.RunNQwithStatus(s);
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Do U want to Update Sl.No. " + txtslno.Text.Trim(), "Question", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
                        if(ERPMessageBox.ERPMessage.ButtonResult=="edpYES")
                        {
                            t = chk_Update();
                            if (t == "2")
                                boolStatus = false;
                            else
                                boolStatus = clsDataAccess.RunNQwithStatus(t);
                            if (boolStatus)
                            {
                                s = "update tbl_Employee_Slab_Det set MINI=" + Convert.ToDouble(txtmin.Text.Trim()) + ", MAXIM='" + txtmax.Text.Trim() + "', AMT=" + Convert.ToDouble(txtamt.Text.Trim()) + " where SLABID=" + get_SlabID(cmbslab.Text.Trim()) + " and SLNO=" + txtslno.Text.Trim();
                                boolStatus = clsDataAccess.RunNQwithStatus(s);
                            }
                        }

                    }
                    if (boolStatus)
                    {
                       ERPMessageBox.ERPMessage.Show("Formula Saved Successfully");
                    }

                }
            }
        }
        public string chk_save()
        {
            string s = "",t="";
            double minm = 0, maxm = 0;

            s = "select mini,maxim,slno from tbl_Employee_Slab_Det where slabid=" + get_SlabID(cmbslab.Text.Trim());
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "")
                {
                    if (dt.Rows[dt.Rows.Count - 1][0].ToString() != "")
                    {
                        if (Convert.ToDouble(txtmin.Text.Trim()) <= Convert.ToDouble(dt.Rows[dt.Rows.Count - 1][0]))
                        {
                            t = "2";
                            ERPMessageBox.ERPMessage.Show("Minimum Can not be less than Previous Minimum", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                        }
                        else
                        {
                            if (dt.Rows[dt.Rows.Count - 1][1].ToString() != "")
                            {
                                maxm = Convert.ToDouble(txtmin.Text.Trim()) - .01;
                            }
                            t = "update tbl_Employee_Slab_Det set MAXIM='" + maxm.ToString() + "' where SLABID=" + get_SlabID(cmbslab.Text.Trim()) + " and SLNO=" + Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][2]);
                        }
                    }
                }
               

            }
            else
                t = "1";
            return t;

        }
        public string chk_Update()
        {
            string s = "", t = "";
            double minm = 0, maxm = 0;

            s = "select mini,maxim,slno from tbl_Employee_Slab_Det where slabid=" + get_SlabID(cmbslab.Text.Trim());
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                for (int y = 0; y < dt.Rows.Count; y++)
                {
                    if (dt.Rows[y][2].ToString()==txtslno.Text.Trim())
                    {

                        if (Convert.ToDouble(txtmin.Text.Trim()) <= Convert.ToDouble(dt.Rows[y - 1][0]))
                            {
                                t = "2";
                                ERPMessageBox.ERPMessage.Show("Minimum Can not be less than Previous Minimum", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                            }
                            else if (((y + 1) != dt.Rows.Count) && (Convert.ToDouble(txtmin.Text.Trim()) >= Convert.ToDouble(dt.Rows[y + 1][0])))
                            {
                                t = "2";
                                ERPMessageBox.ERPMessage.Show("Minimum Can not be greater than Next Minimum", "Information", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_OK, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_INFORMATION);
                            }
                            else
                            {
                                if (dt.Rows[y-1][1].ToString() != "")
                                {
                                    maxm = Convert.ToDouble(txtmin.Text.Trim()) - .01;
                                }
                                t = "update tbl_Employee_Slab_Det set MAXIM='" + maxm.ToString() + "' where SLABID=" + get_SlabID(cmbslab.Text.Trim()) + " and SLNO=" + Convert.ToInt32(dt.Rows[y-1][2]);
                            }
                        
                    }
                }


            }
           
            return t;
        }


        private void cmbslab_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                get_slab_dtl();
                txtslno.Text = string.Empty;
                txtamt.Text = string.Empty;
                txtmax.Text = string.Empty;
                txtmin.Text = string.Empty;
            }
            catch (Exception x) { }
        }

        private void cmbslab_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
                get_slab_dtl();
            }
            catch (Exception x) { }
        }

        private void cmbslab_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                cmbslab.Items.Clear();
                get_Slab_df();
            }
            catch (Exception x) { };
        }
        public int get_SlabID(string sname)
        {
            int res = -1;
            if (hsh_slabid.ContainsKey(sname))
                res= Convert.ToInt32(hsh_slabid[sname].ToString());
            return res;
        }

        private void txtmin_TextChanged(object sender, EventArgs e)
        {
            if (txtmax.Text.Trim() == "")
                txtmax.Text = "Max. Value";
        }

        private void dgvfmula_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtslno.Text = dgvfmula.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtmin.Text = dgvfmula.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtmax.Text = dgvfmula.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtamt.Text = dgvfmula.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception x) { }

        }
        public void del()
        {
            bool sta = false;
            if (clsValidation.ValidateComboBox(cmbslab, "", "Select Slab Name"))
            {
                if (clsValidation.ValidateTextBox(txtslno, "", "Sl. No. can't be blank"))
                {

                    ERPMessageBox.ERPMessage.Show("Do U Want to Delete SL. No. " + txtslno.Text.Trim(), "Question", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
                    if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
                        sta = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Slab_Det where SLABID=" + get_SlabID(cmbslab.Text.Trim())+" and slno="+txtslno.Text.Trim() + "");
                    if (sta)
                    {
                        ERPMessageBox.ERPMessage.Show("Formula Deleted Sucessfully");
                        txtslno.Text = string.Empty;
                        txtmin.Text = string.Empty;
                        txtmax.Text = string.Empty;
                        txtamt.Text = string.Empty;

                    }

                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                del();
                get_slab_dtl();

            }
            catch (Exception x) { }
        }

        private void txtslno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hsh_min.ContainsKey(get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + txtslno.Text.Trim()))
                    txtmin.Text = hsh_min[get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + txtslno.Text.Trim()].ToString();
                else
                    txtmin.Text = string.Empty;
                if (hsh_max.ContainsKey(get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + txtslno.Text.Trim()))
                    txtmax.Text = hsh_max[get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + txtslno.Text.Trim()].ToString();
                else
                    txtmax.Text = string.Empty;
                if (hsh_amt.ContainsKey(get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + txtslno.Text.Trim()))
                    txtamt.Text = hsh_amt[get_SlabID(cmbslab.Text.Trim()).ToString() + "/" + txtslno.Text.Trim()].ToString();
                else
                    txtamt.Text = string.Empty;
            }
            catch (Exception x) { }
        }

    }
}