using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ERPMessageBox;

namespace PayRollManagementSystem
{
    public partial class frmPTRateEditor : EDPComponent.FormBaseERP
    {
        public frmPTRateEditor()
        {
            InitializeComponent();
        }
        Int32 slno = 0,flag_add=0;
        string flag_sess = "";
        private void frmPTRateEditor_Load(object sender, EventArgs e)
        {  clsValidation.GenerateYear(cmbYear, 2015, DateTime.Now.Year, 1);
        if (System.DateTime.Now.Month >= 4)
        {
            cmbYear.SelectedIndex = 0;
        }
        else
        {
            cmbYear.SelectedIndex = 1;
        }
           
            flag_sess = cmbYear.Text;
            try
            {
                dtpEdate.Text = "01/Apr/" + flag_sess.Substring(0, 4);
            }
            catch { 
            
            }
            if (txtState.Text==""){
                txtState.Text = "West Bengal";
            }

            try
            {
                DataTable dt = clsDataAccess.RunQDTbl("select distinct estate from tbl_Employee_PTRate");

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                 this.lstState.Items.Add(dt.Rows[i]["estate"]);
            }
            catch { }
            
            LoadDT();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            slno = 0;
            txtMax.Text = ""; txtMin.Text = "";  txtPT.Text = "";
        }

        //ANURAG
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool boolstatus = false;
            int rwno = 0;
            rwno = Convert.ToInt32(clsDataAccess.GetresultS(" select count(*) from tbl_Employee_PTRate"));
            if (Validation())
            {
                String st = "select * from tbl_Employee_PTRate where  ( { fn LCASE(estate)}='" +
            txtState.Text.Trim().ToLower() + "') and (edate='" + dtpEdate.Text + "') order by slno";
                    DataTable dt = clsDataAccess.RunQDTbl(st);
                    if (dt.Rows.Count > 0)
                    {
                        clsDataAccess.RunNQwithStatus("delete from tbl_Employee_PTRate where ( { fn LCASE(estate)}='" + 
                txtState.Text.Trim().ToLower() + "') and (edate='" + dtpEdate.Text + "')");
                    }
               string Sess = cmbYear.Text, edate=dtpEdate.Text, estate = txtState.Text.Trim();
               double wfrom = 0, wto = 0, pt = 0, pt2=0;string gen = "";
               try
               {
                 //  clsDataAccess.RunNQwithStatus("SET IDENTITY_INSERT tbl_Employee_PTRate ON");
               }
               catch
               { }
                    for (int rw_c = 0; rw_c < dgv.Rows.Count-1; rw_c++)
                    {
                         rwno=rwno+1;
                         wfrom= Convert.ToDouble(dgv.Rows[rw_c].Cells[1].Value);
                         wto = Convert.ToDouble(dgv.Rows[rw_c].Cells[2].Value);
                         pt =Convert.ToDouble(dgv.Rows[rw_c].Cells[3].Value);
                         try
                         {
                             pt2 = Convert.ToDouble(dgv.Rows[rw_c].Cells[4].Value);
                         }
                         catch { pt2 = 0; }

                         gen = Convert.ToString(dgv.Rows[rw_c].Cells[5].Value);
                         if (gen.Trim() == "")
                         {
                             gen = "All";

                         }
                         else if (gen.Trim().ToUpper() == "M")
                         {
                             gen = "Male";

                         }

                         else if (gen.Trim().ToUpper() == "F")
                         {
                             gen = "Female";

                         }
                         else if (gen.Trim().ToUpper() == "O")
                         {
                             gen = "Other";

                         }
                        
                        /*String str = "SET IDENTITY_INSERT tbl_Employee_PTRate ON" + Environment.NewLine +
                          "INSERT INTO tbl_Employee_PTRate (Slno,Session,wfrom,wto,pt,edate,estate,alt_pt,gender) VALUES ('" +
                             rwno + "','" + Sess + "','" + wfrom + "','" + wto + "','" + pt + "','" + edate + "','" + estate + "')" + Environment.NewLine +
                             "SET IDENTITY_INSERT tbl_Employee_PTRate OFF";
                        boolstatus = clsDataAccess.RunNQwithStatus(str);*/


                         boolstatus = clsDataAccess.RunNQwithStatus("INSERT INTO tbl_Employee_PTRate (Slno,Session,wfrom,wto,pt,edate,estate,alt_pt,gender) VALUES ('" + 
                          rwno + "','" + Sess + "','" + wfrom + "','" + wto + "','" + pt + "','" + edate + "','" + estate + "','"+pt2+"','"+ gen +"')");
                        
                       
                    }

                    try
                    {
                      //  clsDataAccess.RunNQwithStatus("SET IDENTITY_INSERT tbl_Employee_PTRate OFF");
                    }
                    catch
                    { }
                    if (boolstatus)
                        ERPMessage.Show("Successfully Saved.");
                
            }
        }

        private void clear()
        {
            slno = 0;
            txtMin.Text = "";
            txtMax.Text = "";
            txtPT.Text = "";
        }
        private void LoadDT()
        {
            try
            {
                DataTable dt = clsDataAccess.RunQDTbl("SELECT SlNo,wfrom as Minimum,wto as Maximum,pt as PT,alt_pt as AltPT,gender as Gender FROM tbl_Employee_PTRate WHERE ( { fn LCASE(estate)}='" +
                    txtState.Text.Trim().ToLower() + "') and (edate='" + dtpEdate.Text + "') order by slno");

                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;
            }
            catch { }
           
        }
        private bool Validation()
        {
            bool ret = true;
            if (!clsValidation.ValidateComboBox(cmbYear, "", "Please select Session."))
                ret = false;
            else if (!Information.IsNumeric(txtMin.Text))
            {
                ERPMessage.Show("Please Enter Numeric value.");
                txtMin.Focus();
                ret = false;
            }
            else if (!Information.IsNumeric(txtPT.Text))
            {
                ERPMessage.Show("Please Enter Numeric value.");
                txtPT.Focus();
                ret = false;
            }
            return ret;
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDT();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_PTRate where SLNo=" + slno);
            ERPMessage.Show("Successfully Deleted.");
            clear();
            LoadDT();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                slno = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);
                txtMin.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMax.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPT.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch { }
        }

        private void lstState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtState.Text = lstState.SelectedItem.ToString();
            }
            catch { }
            LoadDT();

        }

        private void txtestate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                btnSH_Click(sender,e);

            }
            catch { }

            //ANURAG
            LoadDT();
        }

        private void btnSH_Click(object sender, EventArgs e)
        {
            lstedate.Items.Clear();
            try
            {
                DataTable dt = clsDataAccess.RunQDTbl("select distinct edate from tbl_Employee_PTRate where ( { fn LCASE(estate)}='" + txtState.Text.Trim().ToLower() + "')");

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    this.lstedate.Items.Add(dt.Rows[i]["edate"]);
            }
            catch { }
            if (lstedate.Items.Count == 1)
            {
                dtpEdate.Text = lstedate.Items[0].ToString();
            }
            else if (lstedate.Items.Count > 1)
            {
                lstedate.Visible = true;
            }
        }

        private void lstedate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtpEdate.Text = lstedate.SelectedItem.ToString();
                lstedate.Visible = false;

            }

            catch { }

            //try
            //{
            //    DataTable dt = clsDataAccess.RunQDTbl("select  Slno, wfrom, wto, pt from tbl_Employee_PTRate where ( { fn LCASE(estate)}='" + txtestate.Text.Trim().ToLower() + "') and (edate='" + dtpEdate.Text + "') order by slno");

            //    for (int i = 0; i <= dt.Rows.Count - 1; i++)
            //        this.lstedate.Items.Add(dt.Rows[i]["edate"]);
            //}
            //catch { }
             LoadDT();
        }

        //ANURAG
        private void dtpEdate_ValueChanged(object sender, EventArgs e)
        {
            LoadDT();
        }

        private void txtState_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            try
            {
                btnSH_Click(sender, e);

            }
            catch { }

            //ANURAG
            LoadDT();
        }

        private void txtState_DropDown(object sender, EventArgs e)
        {
           string stateName = "";
            DataTable dt = clsDataAccess.RunQDTbl("SELECT [State_Name],[STATE_CODE] FROM StateMaster");
            if (dt.Rows.Count > 0)
            {
                txtState.LookUpTable = dt;
                txtState.ReturnIndex = 1;
            }
        }

        
    }
}