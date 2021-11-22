using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frmOrderHeadMaster : Form//EDPComponent.FormBaseERP
    {
        public frmOrderHeadMaster()
        {
            InitializeComponent();
        }

        DataTable dt_header = new DataTable();
        DataRow dr;
        DataColumn dc1 = new DataColumn("Header Name");
        DataColumn dc2 = new DataColumn("Description");

        private void frmOrderHeadMaster_Load(object sender, EventArgs e)
        {
          
           GetHeaderDetail();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                del();
                GetHeaderDetail();
            }
            catch (Exception x) { }
        }

        private void del()
        {
            bool sta = false;
            bool stat = false;
            if (clsValidation.ValidateTextBox(txtHead, "", "Header name can't be blank"))
            {
                ERPMessageBox.ERPMessage.Show("Do U Want to Delete " + txtHead.Text.Trim(), "Question", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
                if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
                {
                    DataTable dt_head_delete_validation;
                    int head_id = 0;
                    dt_head_delete_validation = clsDataAccess.RunQDTbl("select Hid from tbl_order_head_detail where Hname='" + txtHead.Text.Trim() + "'" + "");
                    if (Information.IsNumeric(dt_head_delete_validation.Rows[0][0]) == true)
                        head_id = Convert.ToInt32(dt_head_delete_validation.Rows[0][0]);
                    dt_head_delete_validation.Clear();
                    dt_head_delete_validation = clsDataAccess.RunQDTbl("select * from tbl_order_head_position where Hid = "+head_id);
                    if(dt_head_delete_validation.Rows.Count>0)
                        ERPMessageBox.ERPMessage.Show("You Can not Delete this Head. It's in use With other Process.");
                    else
                        sta = clsDataAccess.RunNQwithStatus("delete from tbl_order_head_detail where Hname='" + txtHead.Text.Trim() + "'" + "");
                    dt_head_delete_validation.Clear();
                }
                if (sta)
                {
                    ERPMessageBox.ERPMessage.Show("Head Deleted Sucessfully");
                    txtHead.Text = string.Empty;
                    txtDesc.Text = string.Empty;

                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtHead.Text == "" || txtHead.Text == null)
                ERPMessageBox.ERPMessage.Show("You have to enter the Header name in order to insert the data");
            else
            {
                if ((txtDesc.Text.ToUpper().Contains("GST")==false) && (txtHead.Text.ToUpper().Contains("GST")==false))
                {
                    SaveHeaderDetail();
                    GetHeaderDetail();
                }
            }
        }

        private void SaveHeaderDetail()
        {
            Boolean boolStatus = false;
            int max_head_id = 0;
            string s = "";
            
            s = "select MAX(Hid) from tbl_order_head_detail";
            DataTable max_No = clsDataAccess.RunQDTbl(s);
            if (Information.IsNumeric(max_No.Rows[0][0]) == true)
                max_head_id = Convert.ToInt32(max_No.Rows[0][0]) + 1;
            else
                max_head_id = 1;
            s = "insert into tbl_order_head_detail values(" + max_head_id+",'"+txtHead.Text.Trim()+"','"+txtDesc.Text+"')";
            txtHead.Text = "";
            txtDesc.Text = "";
            boolStatus = clsDataAccess.RunNQwithStatus(s);
        }

        private void GetHeaderDetail()
        {
            dt_header.Clear();
            dt_header.Columns.Clear();

            DataTable dt = new DataTable();
            dt_header.Columns.Add(dc1);
            dt_header.Columns.Add(dc2);
            string hname = "";
            if (txtSearch.Text == "")
                hname = "select Hname,Htext from tbl_order_head_detail";
            else
                hname = "select Hname,Htext from tbl_order_head_detail where Hname like '" + txtSearch.Text.Trim() + "%'";
            dt = clsDataAccess.RunQDTbl(hname);
            //if (dt.Rows.Count > 0)
            //{
            //    for (int y = 0; y < dt.Rows.Count; y++)
            //    {
            //        dr = dt_header.NewRow();
            //        dr[0] = dt.Rows[y][0].ToString();
            //        dr[1] = dt.Rows[y][1].ToString();
            //        dt_header.Rows.Add(dr);
            //    }
            //}
            dgView.DataSource = "";
            dgView.DataSource = dt;
            dgView.Columns[0].Width = 100;
            dgView.Columns[1].Width = 180;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            { GetHeaderDetail(); }
            catch
            { }
        }

        private void dgView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtHead.Text = dgView.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDesc.Text = dgView.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception x) { }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            
        }

           
    }
}
