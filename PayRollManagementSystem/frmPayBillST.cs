using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmPayBillST : Form
    {
        public frmPayBillST()
        {
            InitializeComponent();
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int SLNO = 0, STID = 0;
            double STPER = 0;
            string STNAME = "", STMONTH = "";
            DateTime FROMDATE;

            bool Status = false;
            try
            {

                STID = Convert.ToInt32(clsDataAccess.GetresultS("Select Max(STID) from [paybillST]")) + 1;
            }
            catch
            {
                STID = STID + 1;
            }

            FROMDATE = Convert.ToDateTime(this.dtpto.Text);
            STMONTH = dtpto.Value.ToString("MMMM") + "/" + dtpto.Value.ToString("yyyy");
            Status = clsDataAccess.RunNQwithStatus("Delete [paybillST] where ([FromDate]='" + dtpto.Value.ToString("dd/MMM/yyyy") + "')");
            for (int ind_dgv = 0; ind_dgv < dgv_Kit.Rows.Count - 1; ind_dgv++)
            {
                SLNO = ind_dgv + 1;
                STNAME = Convert.ToString(dgv_Kit.Rows[ind_dgv].Cells["STNAME"].Value);
                STPER = Convert.ToDouble(dgv_Kit.Rows[ind_dgv].Cells["STVAL"].Value);
                Status = clsDataAccess.RunNQwithStatus("INSERT INTO [paybillST]([STID],[FromDATE],[STMonth],[Slno],[STNAME],[STPER]) VALUES (" + STID + ",cast(convert(datetime,'" + dtpto.Text + "',103) as datetime),'" + STMONTH + "'," + SLNO + ",'" + STNAME + "'," + STPER + ")");
            }

            if (Status == true)
            {
                MessageBox.Show("Record Modified", "BRAVO");

            }

        }

        private void frmPayBillST_Load(object sender, EventArgs e)
        {
            //[paybillST]
            int ind_dgv = 0;
            //"[STID],[FromDATE],[Slno],[STNAME],[STPER],[STMonth]";
            DataTable dt = clsDataAccess.RunQDTbl("select [STID],CONVERT(VARCHAR(10),[FromDATE],103) as FromDate ,[STMonth],[Slno],[STNAME],[STPER] from [paybillST] as [pbst] where [FromDATE]= (SELECT MAX(FromDATE) FROM paybillST WHERE FromDATE = paybillST.FromDATE)");
            if (dt.Rows.Count == 0)
            {
                ind_dgv = dgv_Kit.Rows.Add();
                dgv_Kit.Rows[ind_dgv].Cells["STNO"].Value = ind_dgv;
                dgv_Kit.Rows[ind_dgv].Cells["STNAME"].Value = "Service Tax";
                dgv_Kit.Rows[ind_dgv].Cells["STVAL"].Value = 0;
                ind_dgv = dgv_Kit.Rows.Add();
                dgv_Kit.Rows[ind_dgv].Cells["STNO"].Value = ind_dgv;
                dgv_Kit.Rows[ind_dgv].Cells["STNAME"].Value = "Swach Bharat Cess";
                dgv_Kit.Rows[ind_dgv].Cells["STVAL"].Value = 0;
                
            }
            for (ind_dgv = 0; ind_dgv < dt.Rows.Count; ind_dgv++)
            {
                dgv_Kit.Rows.Add();
                dgv_Kit.Rows[ind_dgv].Cells["STNO"].Value = dt.Rows[ind_dgv]["Slno"];
                dgv_Kit.Rows[ind_dgv].Cells["STNAME"].Value = dt.Rows[ind_dgv]["STNAME"];
                dgv_Kit.Rows[ind_dgv].Cells["STVAL"].Value = dt.Rows[ind_dgv]["STPER"];

                dtpto.Text = Convert.ToDateTime(dt.Rows[ind_dgv]["FromDATE"]).ToString("dd/MM/yyyy");
                lblSTID.Text = Convert.ToString(dt.Rows[ind_dgv]["STID"]);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            int SLNO = 0, STID = 0;
            double STPER = 0;
            string STNAME = "", STMONTH = "";
            DateTime FROMDATE;
            if (lblSTID.Text != "")
            {

                bool Status = clsDataAccess.RunNQwithStatus("Delete from [paybillST] where [STID]=" + Convert.ToInt32(lblSTID.Text));
                try
                {

                    STID = Convert.ToInt32(lblSTID.Text);
                }
                catch
                {
                    STID = STID + 1;
                }

                FROMDATE = Convert.ToDateTime(this.dtpto.Text);
                STMONTH = dtpto.Value.ToString("MMMM") + "/" + dtpto.Value.ToString("yyyy");

                for (int ind_dgv = 0; ind_dgv < dgv_Kit.Rows.Count - 1; ind_dgv++)
                {
                    SLNO = ind_dgv + 1;
                    STNAME = Convert.ToString(dgv_Kit.Rows[ind_dgv].Cells["STNAME"].Value);
                    STPER = Convert.ToDouble(dgv_Kit.Rows[ind_dgv].Cells["STVAL"].Value);
                    Status = clsDataAccess.RunNQwithStatus("INSERT INTO [paybillST]([STID],[FromDATE],[STMonth],[Slno],[STNAME],[STPER]) VALUES (" + STID + ",cast(convert(datetime,'" + dtpto.Text + "',103) as datetime),'" + STMONTH + "'," + SLNO + ",'" + STNAME + "'," + STPER + ")");
                }

                if (Status == true)
                {
                    MessageBox.Show("Record Modified", "BRAVO");

                }
            }
        }
    }
}
