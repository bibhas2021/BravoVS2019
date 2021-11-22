using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace PayRollManagementSystem
{
    public partial class frmEmpMonitor : Form
    {
        public frmEmpMonitor()
        {
            InitializeComponent();
        }
        string sql = "",coid="1",dur="2",cmon="";
        DataTable dtComp;
        DataTable dt_emp;
        DataTable dt_Count;
        DataSet ds;
       

        private void cmbCompany_DropDown(object sender, EventArgs e)
        {
            sql = "select * from (select '0' CO_CODE,'All Company' CO_name union select CO_CODE,CO_name from Company)comp order by CO_CODE";
            dtComp = clsDataAccess.RunQDTbl(sql);
            if (dtComp.Rows.Count > 1)
            {
                cmbCompany.LookUpTable = dtComp;
                cmbCompany.ReturnIndex = 0;
            }
            else if (dtComp.Rows.Count == 1)
            {                
                cmbCompany.Text = dtComp.Rows[0]["CO_name"].ToString().Trim();
                coid = dtComp.Rows[0]["CO_CODE"].ToString().Trim();
                cmbCompany.ReturnValue = coid;
                if (coid.Trim() != "")
                {
                    BtnView_Click(sender, e);
                }
            }
        }

        private void cmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            coid = Convert.ToString(cmbCompany.ReturnValue).Trim();
            cmbCompany.Text = clsDataAccess.ReturnValue("select CO_name from (select '0' CO_CODE,'All Company' CO_name union select CO_CODE,CO_name from Company)comp where (CO_CODE='" + coid + "')");
            if (coid.Trim() != "")
            {
                BtnView_Click(sender, e);
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            cmon = AttenDtTmPkr.Value.ToString("MMMM-yyyy");
            ds = clsDataAccess.sp_EmpMonitoring(cmon, Convert.ToInt32(coid), Convert.ToInt32(dur));
            //dt_emp = clsDataAccess.sp_EmpMonitoring(cmon,Convert.ToInt32(coid),Convert.ToInt32(dur));
            dt_emp = ds.Tables[0];
            dt_Count = ds.Tables[1];
            if (dt_emp.Rows.Count > 0)
            {
                dgvCount.DataSource = dt_Count;
                dgvShow.DataSource = dt_emp;

                dgvShow.Columns["lsal_mon"].Visible = false;
                dgvShow.Columns["status_date"].Visible = false;
                dgvShow.Columns["locid"].Visible = false;
                dgvShow.Columns["Code"].Visible = false;

                dgvShow.Visible = true;
                dgvCount.Visible = true;
                btnSave.Enabled = true;
            }
            else
            {
                dgvCount.Visible = false;
                dgvShow.Visible = false;
                lblMsg.Text = "No Record Found";
            }

        }

        private void frmEmpMonitor_Load(object sender, EventArgs e)
        {
            dur = clsDataAccess.ReturnValue("select DormentDur from CompanyLimiter");
            if (dur.Trim() == "" || dur == "0")
            {
                dur = "2";
            }

            btnSave.Enabled = false;
            lblDormentDur.Text = dur + " Months";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            backgroundWorker1.RunWorkerAsync(2000);

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            backgroundWorker1.ReportProgress(1);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            clsDataAccess.RunQry("Delete from tbl_EmpDormentDur where coid='" + coid + "' and mon='" + cmon + "'");
            for (int idx = 0; idx < dgvShow.Rows.Count; idx++)
            {
                if (dgvShow.Rows[idx].Cells["Code"].Value.ToString().Trim() != "")
                {
                    sql = "INSERT INTO tbl_EmpDormentDur (id, coid, locid, lsal_mon, duration, status_date, status, mon) VALUES ('" +
                     dgvShow.Rows[idx].Cells["Code"].Value.ToString() + "','" +
                     coid + "','" + dgvShow.Rows[idx].Cells["locid"].Value.ToString() + "','15-" + dgvShow.Rows[idx].Cells["Last Paid Month"].Value.ToString() + "','" +
                     dgvShow.Rows[idx].Cells["Duration"].Value.ToString() + "','15-" + dgvShow.Rows[idx].Cells["Current Month"].Value.ToString() + "','" +
                     dgvShow.Rows[idx].Cells["Status"].Value.ToString() + "-" + dgvShow.Rows[idx].Cells["Active"].Value.ToString() + "','" +
                     cmon.ToString() + "')";
                    clsDataAccess.RunQry(sql);
                }

            }


            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 0, irw = 0, Dormant = 0, predorment = 0, inactive = 0, active = 0;


            dgvShow.Columns.Remove("lsal_mon");
            dgvShow.Columns.Remove("status_date");
            dgvShow.Columns.Remove("locid");
            dgvShow.Columns.Remove("Code");

            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            iCol = dgvShow.Columns.Count;


            excel.Cells[1, 1] = "Employee Count Monitoring";
            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);


            range.Merge(true);
            range.Font.Bold = true;


            range.HorizontalAlignment = HorizontalAlign.Center;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[2, 1] = cmbCompany.Text;

            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            range.Columns.AutoFit();
            range.Rows.AutoFit();

            excel.Cells[3, 1] = "For the month of "+ cmon;
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();
            string[] cell_head = new string[] { };
            string old_head = "";
            int ind_st = 0, ind_fin = 0;
            //dgvShow.Columns["lsal_mon"].Visible = false;
            //dgvShow.Columns["status_date"].Visible = false;
            //dgvShow.Columns["locid"].Visible = false;
            //dgvShow.Columns["Code"].Visible = false;
            for (int i = 1; i <= dgvShow.Columns.Count; i++)
            {
                //if (dgvShow.Columns[i - 1].HeaderText.Trim().ToLower() != "code" && dgvShow.Columns[i - 1].HeaderText.Trim().ToLower() != "lsal_mon" && dgvShow.Columns[i - 1].HeaderText.Trim().ToLower() != "status_date" && dgvShow.Columns[i - 1].HeaderText.Trim().ToLower() != "locid")
                //{
                    cell_head = Convert.ToString(dgvShow.Columns[i - 1].HeaderText).Split('.');
                    if (cell_head.Length > 1)
                    {
                        if (old_head == cell_head[0])
                        {
                            ind_fin = i;
                        }
                        else
                        {
                            try
                            {
                                range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
                                range.Merge(Type.Missing);
                                range.HorizontalAlignment = HorizontalAlign.Center;
                                range.VerticalAlignment = VerticalAlign.Top;
                            }
                            catch { }
                            ind_st = i;
                            excel.Cells[4, i] = cell_head[0];
                            old_head = cell_head[0];
                        }
                        excel.Cells[5, i] = cell_head[1];
                    }
                    else if (cell_head.Length > 0)
                    {


                        excel.Cells[4, i] = dgvShow.Columns[i - 1].HeaderText;
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[4, i], worksheet.Cells[5, i]);
                            range.Merge(Type.Missing);
                            range.HorizontalAlignment = HorizontalAlign.Left;
                            range.VerticalAlignment = VerticalAlign.Top;
                        }
                        catch { }
                    }
                //}
            }

            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
            range.Font.Bold = true;
            DateTime MyDate;
            for (int i = 0; i < dgvShow.Rows.Count; i++)
            {
                for (int j = 1; j <= dgvShow.Columns.Count; j++)
                {
                    //if (dgvShow.Columns[j - 1].HeaderText.Trim().ToLower() != "code" && dgvShow.Columns[j - 1].HeaderText.Trim().ToLower() != "lsal_mon" && dgvShow.Columns[j - 1].HeaderText.Trim().ToLower() != "status_date" && dgvShow.Columns[j - 1].HeaderText.Trim().ToLower() != "locid")
                    //{
                        try
                        {
                            irw = i + 6;
                            if (j != 20 || j != 22)
                            {
                                range = worksheet.get_Range(worksheet.Cells[i + 6, j], worksheet.Cells[i + 6, j]);
                                range.NumberFormat = "@";
                            }
                            if (!DateTime.TryParse(dgvShow.Rows[i].Cells[j - 1].Value.ToString(), out MyDate))
                            {
                                excel.Cells[i + 6, j] = dgvShow.Rows[i].Cells[j - 1].Value.ToString();
                            }
                            else
                            {
                                excel.Cells[i + 6, j] = dgvShow.Rows[i].Cells[j - 1].Value.ToString();
                            }
                        }
                        catch { }
                    //}
                }
                try
                {
                    range = worksheet.get_Range(worksheet.Cells[i + 6, 1], worksheet.Cells[i + 6, iCol]);
                    if (Convert.ToString(dgvShow.Rows[i].Cells["Status"].Value.ToString().ToLower()) == "pre-Dormant" && Convert.ToString(dgvShow.Rows[i].Cells["Active"].Value.ToString().ToLower()) == "active")
                    {

                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        //Color.Yellow;
                        predorment++;
                    }
                    else if (Convert.ToString(dgvShow.Rows[i].Cells["Status"].Value.ToString().ToLower()) == "Dormant" && Convert.ToString(dgvShow.Rows[i].Cells["Active"].Value.ToString().ToLower()) == "active")
                    {
                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.IndianRed);
                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

                        Dormant++;
                    }
                    else if (Convert.ToString(dgvShow.Rows[i].Cells["Active"].Value.ToString().ToLower()) == "inactive")
                    {
                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                        inactive++;
                    }
                    else
                    {
                        // range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        //range.Interior.Color = Color.Green;
                        active++;
                    }
                }
                catch
                { }
            }

            object missing = System.Reflection.Missing.Value;



            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[irw, iCol]);
            Excel.Borders borders = range.Borders;
            //Set the thick lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 2d;
            range.WrapText = true;

            excel.Cells[irw + 1, 1] = "Company : " + cmbCompany.Text + Environment.NewLine +
                                    "Total Employee Count : " + dgvShow.Rows.Count + Environment.NewLine +
                                    "Active : " + active + Environment.NewLine +
                                    "Inactive : " + inactive + Environment.NewLine +
                                    "Dormant : " + Dormant + Environment.NewLine +
                                    "Predormet : " + predorment;

            try
            {
                range = worksheet.get_Range(worksheet.Cells[irw + 1, 1], worksheet.Cells[irw + 1, 4]);
                range.Merge(Type.Missing);
                range.HorizontalAlignment = HorizontalAlign.Left;
                range.VerticalAlignment = VerticalAlign.Top;

                borders = range.Borders;
                borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                borders.Weight = 2d;
                range.WrapText = true;
            }
            catch { }

            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();

            //((Excel._Application)excel).Save();

            MessageBox.Show("Export To Excel Completed!", "Export");
        
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblMsg.Text = "Process Completed";
            MessageBox.Show("Record Insertion Completed","Bravo");
        }
    }
}
