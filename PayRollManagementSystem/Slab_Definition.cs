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
    public partial class Slab_Definition : EDPComponent.FormBaseERP
    {
        public Slab_Definition()
        {
            InitializeComponent();
        }
        Hashtable chk_slb = new Hashtable();
        Hashtable hsh_name = new Hashtable();
        Hashtable hsh_des = new Hashtable();
        Hashtable hsh_fmula = new Hashtable();
        int slbid = 0;
        DataRow dr;
        DataTable dt_slab = new DataTable();
        DataColumn dc1 = new DataColumn("SL.No");
        DataColumn dc2 = new DataColumn("Name");
        DataColumn dc3 = new DataColumn("Description");
        DataColumn dc4 = new DataColumn("Formula");

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                del();
                get_slb();
            }
            catch (Exception x) { }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                save_slab();
                get_slb();
            }
            catch (Exception x) { }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     

        private void rbbof_CheckedChanged(object sender, EventArgs e)
        {
            if (rbbof.Checked)
            {
                cmbfmula.Enabled = true;
                btnfmula.Enabled = true;
                new frmSalaryStructure_Define().Load_Data("select fname from tbl_Employee_Sal_Structure_Formula", cmbfmula, 0);
            }
            else
            {
                cmbfmula.Enabled = false;
                btnfmula.Enabled = false;
                cmbfmula.Items.Clear();
            }
        }

        private void btnfmula_Click(object sender, EventArgs e)
        {
            try
            {
                Config_SalaryStructure_Formula cs = new Config_SalaryStructure_Formula();
                cs.ShowDialog();
            }
            catch (Exception x) { }
        }
        public void get_slb()
        {
            dt_slab.Columns.Clear();
            dt_slab.Clear();
            dt_slab.Columns.Add(dc1);
            dt_slab.Columns.Add(dc2);
            dt_slab.Columns.Add(dc3);
            dt_slab.Columns.Add(dc4);
            chk_slb.Clear();
            hsh_des.Clear();
            hsh_fmula.Clear();
            hsh_name.Clear();
            
            string s = "";
            s = "select slabid,slabname,slabdesc,fid from tbl_Employee_Slab_Def";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                for (int sl = 0; sl < dt.Rows.Count; sl++)
                {
                    dr = dt_slab.NewRow();
                    dr[0] = dt.Rows[sl][0].ToString();
                    dr[1] = dt.Rows[sl][1].ToString();
                    dr[2] = dt.Rows[sl][2].ToString();
                    if(dt.Rows[sl][3].ToString()!="")
                    dr[3] = get_fname1(Convert.ToInt32(dt.Rows[sl][3]));
                    dt_slab.Rows.Add(dr);
                    if (!chk_slb.ContainsKey(dt.Rows[sl][0].ToString()))
                        chk_slb.Add(dt.Rows[sl][0].ToString(), dt.Rows[sl][1].ToString());
                    if (!hsh_name.ContainsKey(dt.Rows[sl][0].ToString()))
                        hsh_name.Add(dt.Rows[sl][0].ToString(), dt.Rows[sl][1].ToString());
                    if (!hsh_des.ContainsKey(dt.Rows[sl][0].ToString()))
                        hsh_des.Add(dt.Rows[sl][0].ToString(), dt.Rows[sl][2].ToString());
                    if (dt.Rows[sl][3].ToString() != "")
                    {
                        if (!hsh_fmula.ContainsKey(dt.Rows[sl][0].ToString()))
                            hsh_fmula.Add(dt.Rows[sl][0].ToString(), get_fname1(Convert.ToInt32(dt.Rows[sl][3])));
                    }
                }
            }
            slbid = dt.Rows.Count;
            dgvfmula.DataSource = "";
            dgvfmula.DataSource = dt_slab;
        }
        public void save_slab()
        {
            bool status = false;string qry="";
            slbid+=1;
            if (clsValidation.ValidateTextBox(txtslno, "", "Please Enter SL No."))
            {
                if (clsValidation.ValidateTextBox(txtname, "", "Please Enter Name"))
                {
                    if (!chk_slb.ContainsKey(txtslno.Text.Trim()))
                    {
                        if (!rbbof.Checked)
                            qry = "insert into tbl_Employee_Slab_Def(SLABID,SLABNAME,SLABDESC) values(" + Convert.ToInt32(txtslno.Text.Trim()) + ", '" + txtname.Text.Trim() + "', '" + txtdes.Text.Trim() + "')";
                        else
                        {
                            if (clsValidation.ValidateComboBox(cmbfmula, "", "Please Select Formula"))
                            {
                                qry = "insert into tbl_Employee_Slab_Def values(" + Convert.ToInt32(txtslno.Text.Trim()) + ", '" + txtname.Text.Trim() + "', '" + txtdes.Text.Trim() + "', " + get_fid(cmbfmula.Text) + ")";
                            }
                        }
                        status = clsDataAccess.RunNQwithStatus(qry);
                    }
                    else
                    {
                        if (!rbbof.Checked)
                        {
                            ERPMessageBox.ERPMessage.Show("Do You Want To Update SL.No. " + txtslno.Text.Trim(), "Question", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
                            if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
                            {
                                qry = "update tbl_Employee_Slab_Def set SLABNAME='" + txtname.Text.Trim() + "', SLABDESC='" + txtdes.Text.Trim() + "' where SLABID=" + txtslno.Text.Trim();
                                status = clsDataAccess.RunNQwithStatus(qry);
                            }
                        }
                        else
                        {
                            if (clsValidation.ValidateComboBox(cmbfmula, "", "Please Select Formula"))
                            {
                                ERPMessageBox.ERPMessage.Show("Do You Want To Update SL.No." + txtslno.Text.Trim(), "Question", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
                                if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
                                {
                                    qry = "UPDATE tbl_Employee_Slab_Def set SLABNAME='" + txtname.Text.Trim() + "', SLABDESC='" + txtdes.Text.Trim() + "', FID=" + get_fid(cmbfmula.Text) + " where SLABID=" + txtslno.Text.Trim();
                                    status = clsDataAccess.RunNQwithStatus(qry);
                                }
                            }
                        }
                    }
                    //status = clsDataAccess.RunNQwithStatus(qry);

                    if (status)
                        ERPMessageBox.ERPMessage.Show("Record Saved Successfully");

                }
            }
        }
        public int get_fid(string fname)
        {
            int res=0;string x="";
            DataTable de=new DataTable();
            
             x="select fid from tbl_Employee_Sal_Structure_Formula where fname='"+fname+"'";
            de=clsDataAccess.RunQDTbl(x);
            if(de.Rows.Count>0)
                res=Convert.ToInt32(de.Rows[0][0]);
            return res;

        }
        public string get_fname1(int id)
        {
            string res = ""; string x = "";
            DataTable de = new DataTable();

            x = "select fname from tbl_Employee_Sal_Structure_Formula where fid=" + id;
            de = clsDataAccess.RunQDTbl(x);
            if (de.Rows.Count > 0)
                res = de.Rows[0][0].ToString();
            return res;
        }

        private void Slab_Definition_Load(object sender, EventArgs e)
        {
            try
            {
                get_slb();
            }
            catch (Exception x) { }
        }

        private void dgvfmula_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtslno.Text = dgvfmula.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtname.Text = dgvfmula.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtdes.Text = dgvfmula.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (dgvfmula.Rows[e.RowIndex].Cells[3].Value.ToString() != "")
                {
                    rbbof.Checked = true;
                    cmbfmula.Text = dgvfmula.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
                else
                {
                    rbte.Checked = true;
                    cmbfmula.Text = string.Empty;
                }
            }
            catch (Exception x) { }
        }
        public void del()
        {
            bool sta = false;
            if (clsValidation.ValidateTextBox(txtslno, "", "Sl. No. can't be blank"))
            {
                //if (clsValidation.ValidateTextBox(txtFormula, "", "Formula Expression can't be blank"))
                //{
                    ERPMessageBox.ERPMessage.Show("Do U Want to Delete " + txtslno.Text.Trim(), "Question", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
                    if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
                        sta = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Slab_Def where SLABID=" + txtslno.Text.Trim()+ "");
                    if (sta)
                    {
                        ERPMessageBox.ERPMessage.Show("Formula Deleted Sucessfully");
                        txtslno.Text = string.Empty;
                        txtname.Text = string.Empty;
                        txtdes.Text = string.Empty;
                        cmbfmula.Text = string.Empty;
                        

                    }

                //}
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            string s = ""; DataTable dt = new DataTable(); dt.Clear();
            try
            {
                txtslno.Text = string.Empty;
                txtname.Text = string.Empty;
                txtdes.Text = string.Empty;
                rbte.Checked = true;
                cmbfmula.Text = string.Empty;
                s = "select max(slabid) from tbl_Employee_Slab_Def";
                dt = clsDataAccess.RunQDTbl(s);
                if (dt.Rows.Count > 0)
                {
                    txtslno.Text = Convert.ToString(Convert.ToInt32(dt.Rows[0][0]) + 1);
                }
 
            }
            catch (Exception x) { }
        }

        private void txtslno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hsh_name.ContainsKey(txtslno.Text.Trim()))
                    txtname.Text = hsh_name[txtslno.Text.Trim()].ToString();
                else
                    txtname.Text = string.Empty;

                if (hsh_des.ContainsKey(txtslno.Text.Trim()))
                    txtdes.Text = hsh_des[txtslno.Text.Trim()].ToString();
                else
                    txtdes.Text = string.Empty;
                if (hsh_fmula.ContainsKey(txtslno.Text.Trim()))
                {
                    rbbof.Checked = true;
                    cmbfmula.Text = hsh_fmula[txtslno.Text.Trim()].ToString();

                }
                else
                {
                    rbte.Checked = true;
                    cmbfmula.Text = string.Empty;
                }
            


            }
            catch (Exception x) { };
        }

        private void cmbfmula_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                cmbfmula.Items.Clear();
                new frmSalaryStructure_Define().Load_Data("select fname from tbl_Employee_Sal_Structure_Formula", cmbfmula, 0);
            }
            catch (Exception x) { }
        }


    }
}