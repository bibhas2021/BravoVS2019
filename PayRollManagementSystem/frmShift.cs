using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmShift : Form
    {
        public frmShift()
        {
            InitializeComponent();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            int hrs = 0;
            try
            {
                if (cmbShiftHrs.SelectedIndex == 0)
                {
                    hrs = 8;
                }
                else
                {
                    hrs = 12;
                }
            }
            catch { }
            try
            {
                dtpUpto.Value = dtpFrom.Value.AddHours(hrs);
            }
            catch
            {
                dtpUpto.Value = dtpFrom.Value.AddHours(8);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtShift.Text.Trim() != "")
            { string qry,sid,sno,sname,shrs,time_from,time_upto;
                

                if (btnSave.Text.ToLower() == "save")
                {
                   
                    if (lblsid.Text.Trim() == "")
                    {
                        lblsid.Text = clsDataAccess.GetresultS("select max(sid)+1 from tbl_shift");
                    }
                    if (lblsno.Text.Trim() == "")
                    {
                        lblsno.Text = "1";
                    }
                    else
                    {
                        lblsno.Text = (Convert.ToInt32(lblsno.Text) + 1).ToString();
                    }

                    sid=lblsid.Text;
                    sno=lblsno.Text;
                    sname=txtShift.Text.Trim();
                    shrs=cmbShiftHrs.SelectedItem.ToString();
                    time_from=dtpFrom.Value.ToString("hh:mm tt");
                    time_upto=dtpUpto.Value.ToString("hh:mm tt");


                    qry="INSERT INTO tbl_shift(sid,sno,sname,shrs,time_from,time_upto) VALUES ('"+ 
                        sid +"','"+sno +"','"+sname +"','"+shrs +"','"+time_from +"','"+time_upto +"')";
                    bool bl = clsDataAccess.RunQry(qry);
                    if (bl == true)
                    {

                        ERPMessageBox.ERPMessage.Show("Shift Created.."+Environment.NewLine+
                            " Want to continue with current selected shift ?", "BRAVO", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
                        if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
                        {
                            lblsid.Text = "";
                            dtpFrom.Value = Convert.ToDateTime("06:00:00 AM");
                            dtpUpto.Value = Convert.ToDateTime("06:00:00 PM");
                            cmbShiftHrs.SelectedIndex = 0;
                            getShift();
                        }
                        else
                        {
                            txtShift.Text = "";
                            lblsid.Text = "";
                            lblsno.Text = "";
                            dtpFrom.Value =Convert.ToDateTime( "06:00:00 AM");
                            dtpUpto.Value = Convert.ToDateTime("06:00:00 PM");
                            cmbShiftHrs.SelectedIndex = 0;
                            getShift();
                        }
                    }
                }
                else if (btnSave.Text.ToLower() == "update")
                {
                    sid=lblsid.Text;
                    sno=lblsno.Text;
                    sname=txtShift.Text.Trim();
                    shrs=cmbShiftHrs.SelectedItem.ToString();
                    time_from=dtpFrom.Value.ToString("hh:mm tt");
                    time_upto=dtpUpto.Value.ToString("hh:mm tt");

                    qry= "UPDATE tbl_shift SET sname='"+sname+"', shrs ='"+shrs+"', time_from ='"+time_from+"', time_upto ='"+time_upto+"' where (sid ='"+sid+"') and (sno ='"+sno+"')";

                    bool bl = clsDataAccess.RunQry(qry);
                    if (bl == true)
                    {

                        ERPMessageBox.ERPMessage.Show("Shift Modified.." , "BRAVO");
                        
                            txtShift.Text = "";
                            lblsid.Text = "";
                            lblsno.Text = "";
                            dtpFrom.Value = Convert.ToDateTime("06:00:00 AM");
                            dtpUpto.Value = Convert.ToDateTime("06:00:00 PM");

                            getShift();
                    }
                }
                try
                {
                    dtpFrom_ValueChanged(sender, e);
                }
                catch { }

            }

            
           
           }

        private void frmShift_Load(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            dtpFrom.Value = Convert.ToDateTime("06:00:00 AM");
            dtpUpto.Value = Convert.ToDateTime("06:00:00 PM");
            cmbShiftHrs.SelectedIndex = 0;
            txtShift.Text = "";
            getShift();

        }
        public void getShift()
        {
            btnDelete.Enabled = false;
            btnSave.Text = "Save";
            dgShift.Rows.Clear();
            DataTable dt = clsDataAccess.RunQDTbl("select sid,sno,sname,shrs,time_from,time_upto FROM tbl_shift");
            for (int ind = 0; ind < dt.Rows.Count; ind++)
            {
                dgShift.Rows.Add();
                if (dt.Rows[ind]["sid"].ToString() == "0")
                {
                    dgShift.Rows[ind].ReadOnly = true;

                }
                dgShift.Rows[ind].Cells["colsid"].Value = dt.Rows[ind]["sid"].ToString();
                dgShift.Rows[ind].Cells["colshift"].Value = dt.Rows[ind]["sname"].ToString();
                dgShift.Rows[ind].Cells["colsno"].Value = dt.Rows[ind]["sno"].ToString();
                dgShift.Rows[ind].Cells["colshifthr"].Value = dt.Rows[ind]["shrs"].ToString();
                dgShift.Rows[ind].Cells["colshift_timefrom"].Value = dt.Rows[ind]["time_from"].ToString();
                dgShift.Rows[ind].Cells["colshift_timeto"].Value = dt.Rows[ind]["time_upto"].ToString();

            }
        }

        
        private void dgShift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = dgShift.CurrentCell.RowIndex;
           txtShift.Text = dgShift.Rows[ind].Cells["colshift"].Value.ToString().Trim();
            
           lblsid.Text = dgShift.Rows[ind].Cells["colsid"].Value.ToString().Trim();

          lblsno.Text= dgShift.Rows[ind].Cells["colsno"].Value.ToString().Trim();
          if (lblsid.Text.Trim() != "")
          {
              cmbShiftHrs.SelectedItem = dgShift.Rows[ind].Cells["colshifthr"].Value.ToString().Trim();
              dtpFrom.Value = Convert.ToDateTime(dgShift.Rows[ind].Cells["colshift_timefrom"].Value);
              dtpUpto.Value = Convert.ToDateTime(dgShift.Rows[ind].Cells["colshift_timeto"].Value);

              btnSave.Text = "Update";
              btnDelete.Enabled = true;
          }

        }

        private void dgShift_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sid, sno,qry;
            if (btnSave.Text.ToLower() == "update")
            {
                sid = lblsid.Text;
                sno = lblsno.Text;

                int count = Convert.ToInt32(clsDataAccess.GetresultS("select count(*) from tbl_link_shift where (sid ='" + sid + "')"));
                if (count == 0)
                {
                    qry = "delete from tbl_shift where (sid ='" + sid + "') and (sno ='" + sno + "')";

                    bool bl = clsDataAccess.RunQry(qry);
                    if (bl == true)
                    {

                        ERPMessageBox.ERPMessage.Show("Shift Deleted..", "BRAVO");

                        txtShift.Text = "";
                        lblsid.Text = "";
                        lblsno.Text = "";
                        dtpFrom.Value = Convert.ToDateTime("06:00:00 AM");
                        dtpUpto.Value = Convert.ToDateTime("06:00:00 PM");

                        getShift();
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Shift linked with location, cannot be deleted..", "BRAVO");
                }
            }
        }

        private void cmbShiftHrs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtpFrom_ValueChanged(sender, e);
            }
            catch { }
        }

        private void dtpFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                dtpFrom_ValueChanged(sender, e);
            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
