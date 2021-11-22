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
    public partial class frmLvEncashment : Form
    {
        public frmLvEncashment()
        {
            InitializeComponent();
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            string sql = "";
            if (chkAllLocation.Checked == true)
            {
                sql = "select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID in (" + edpcom.CurrentLocation + ") and (zid='" + cmbZone.ReturnValue.Trim() + "')";
            }
            else
            {
                sql = "select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID in (" + edpcom.CurrentLocation + ")";
            }
            DataTable dt = clsDataAccess.RunQDTbl(sql);
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
            else
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;

            }

           // clr_heads();
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                lblLid.Text = Convert.ToString(cmbLocation.ReturnValue);

            if (Information.IsNumeric(lblLid.Text) == false)
            {
                lblLid.Text = "0";
                Lbl_coid.Text ="0";
                    txtClient.Text = "0";
                    lblClid.Text = "0";
            }
            else
            {
                Lbl_coid.Text = clsEmployee.GetCompany_ID(Convert.ToInt32(lblLid.Text)).ToString();

                txtClient.Text = clsDataAccess.GetresultS("SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=(select distinct Cliant_ID from tbl_Emp_Location where Location_ID='" + lblLid.Text + "')");
                lblClid.Text = clsDataAccess.GetresultS("select distinct Cliant_ID from tbl_Emp_Location where (Location_ID='" + lblLid.Text + "')");
                dgvLv.Rows.Clear();
                dgvLv.Columns.Clear();

                string[] ss = cmbYear.Text.Split('-');
                dgvLv.Columns.Add("col_eid", "EID");
                
                dgvLv.Columns.Add("col_ename", "EName");
                dgvLv.Columns.Add("col_tot", "TOTAL");

                dgvLv.Columns.Add("col_apr", "April-"+ss[0].ToString());

                dgvLv.Columns.Add("col_may", "May-" + ss[0].ToString());
                dgvLv.Columns.Add("col_jun", "June-" + ss[0].ToString());
                dgvLv.Columns.Add("col_jul", "July-" + ss[0].ToString());
                dgvLv.Columns.Add("col_aug", "August-" + ss[0].ToString());
                dgvLv.Columns.Add("col_sep", "September-" + ss[0].ToString());
                dgvLv.Columns.Add("col_oct", "October-" + ss[0].ToString());
                dgvLv.Columns.Add("col_nov", "November-" + ss[0].ToString());
                dgvLv.Columns.Add("col_dec", "December-" + ss[0].ToString());

                dgvLv.Columns.Add("col_jan", "January-" + ss[1].ToString());
                dgvLv.Columns.Add("col_feb", "February-" + ss[1].ToString());
                dgvLv.Columns.Add("col_mar", "March-" + ss[1].ToString());

                dgvLv.Columns.Add("col_rem", "rem");
                dgvLv.Columns.Add("col_rate", "Salary");
                dgvLv.Columns.Add("col_amt", "Amount");

                dgvLv.Columns["col_eid"].ReadOnly = true;
                dgvLv.Columns["col_ename"].ReadOnly = true;
                dgvLv.Columns["col_tot"].ReadOnly = true;
                dgvLv.Columns["col_apr"].ReadOnly = true;
                dgvLv.Columns["col_may"].ReadOnly = true;
                dgvLv.Columns["col_jun"].ReadOnly = true;

                dgvLv.Columns["col_aug"].ReadOnly = true;
                dgvLv.Columns["col_sep"].ReadOnly = true;
                dgvLv.Columns["col_oct"].ReadOnly = true;
                dgvLv.Columns["col_nov"].ReadOnly = true;
                dgvLv.Columns["col_dec"].ReadOnly = true;

                dgvLv.Columns["col_jan"].ReadOnly = true;
                dgvLv.Columns["col_feb"].ReadOnly = true;
                dgvLv.Columns["col_mar"].ReadOnly = true;

                dgvLv.Columns["col_rem"].ReadOnly = true;
                dgvLv.Columns["col_amt"].ReadOnly = true;

                DataTable dt_bal=new DataTable();
                DataTable EmployeeID = clsDataAccess.RunQDTbl("SELECT distinct em.ID as EID," +
          " ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))EName from tbl_Employee_Mast AS em where (Location_ID ='" + lblLid.Text + "') and (active=1) ORDER BY EName");

                if (EmployeeID.Rows.Count > 0)
                {
                    for (int rw = 0; rw < EmployeeID.Rows.Count; rw++)
                    {
                        dgvLv.Rows.Add();
                        dgvLv.Rows[rw].Cells["col_eid"].Value= EmployeeID.Rows[rw]["EID"].ToString();
                        dgvLv.Rows[rw].Cells["col_ename"].Value=EmployeeID.Rows[rw]["EName"].ToString();
                        dt_bal=clsDataAccess.RunQDTbl("SELECT isNull(cur_lv_bal,0)cur_bal, isNull(st_lv_bal,0)lv_bal FROM tbl_Emp_Leave_Balance where (eid='"+EmployeeID.Rows[rw]["EID"].ToString()+"') and (session='"+cmbYear.Text+"')");
                        try
                        {
                            dgvLv.Rows[rw].Cells["col_tot"].Value = dt_bal.Rows[0]["lv_bal"].ToString();
                        }
                        catch
                        {
                            dgvLv.Rows[rw].Cells["col_tot"].Value = 0;
                        }
                        try{
                        dgvLv.Rows[rw].Cells["col_rem"].Value = dt_bal.Rows[0]["cur_bal"].ToString();
                        }
                        catch
                        {
                            dgvLv.Rows[rw].Cells["col_rem"].Value = 0;
                        }
                        dgvLv.Rows[rw].Cells["col_apr"].Value = clsDataAccess.ReturnValue("SELECT isNull(sum(lv_adj),0) FROM tbl_Employee_Attend where (id='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (season='" + cmbYear.Text + "') and (month='4/"+ss[0].ToString()+"')");

                        dgvLv.Rows[rw].Cells["col_may"].Value= clsDataAccess.ReturnValue("SELECT isNull(sum(lv_adj),0) FROM tbl_Employee_Attend where (id='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (season='" + cmbYear.Text + "') and (month='5/"+ss[0].ToString()+"')");
                        dgvLv.Rows[rw].Cells["col_jun"].Value= clsDataAccess.ReturnValue("SELECT isNull(sum(lv_adj),0) FROM tbl_Employee_Attend where (id='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (season='" + cmbYear.Text + "') and (month='6/"+ss[0].ToString()+"')");
                        dgvLv.Rows[rw].Cells["col_jul"].Value= clsDataAccess.ReturnValue("SELECT isNull(sum(lv_adj),0) FROM tbl_Employee_Attend where (id='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (season='" + cmbYear.Text + "') and (month='7/"+ss[0].ToString()+"')");
                        dgvLv.Rows[rw].Cells["col_aug"].Value= clsDataAccess.ReturnValue("SELECT isNull(sum(lv_adj),0) FROM tbl_Employee_Attend where (id='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (season='" + cmbYear.Text + "') and (month='8/"+ss[0].ToString()+"')");
                        dgvLv.Rows[rw].Cells["col_sep"].Value= clsDataAccess.ReturnValue("SELECT isNull(sum(lv_adj),0) FROM tbl_Employee_Attend where (id='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (season='" + cmbYear.Text + "') and (month='9/"+ss[0].ToString()+"')");
                        dgvLv.Rows[rw].Cells["col_oct"].Value= clsDataAccess.ReturnValue("SELECT isNull(sum(lv_adj),0) FROM tbl_Employee_Attend where (id='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (season='" + cmbYear.Text + "') and (month='10/"+ss[0].ToString()+"')");
                        dgvLv.Rows[rw].Cells["col_nov"].Value= clsDataAccess.ReturnValue("SELECT isNull(sum(lv_adj),0) FROM tbl_Employee_Attend where (id='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (season='" + cmbYear.Text + "') and (month='11/"+ss[0].ToString()+"')");
                        dgvLv.Rows[rw].Cells["col_dec"].Value= clsDataAccess.ReturnValue("SELECT isNull(sum(lv_adj),0) FROM tbl_Employee_Attend where (id='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (season='" + cmbYear.Text + "') and (month='12/"+ss[0].ToString()+"')");

                        dgvLv.Rows[rw].Cells["col_jan"].Value= clsDataAccess.ReturnValue("SELECT isNull(sum(lv_adj),0) FROM tbl_Employee_Attend where (id='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (season='" + cmbYear.Text + "') and (month='1/"+ss[1].ToString()+"')");
                        dgvLv.Rows[rw].Cells["col_feb"].Value=clsDataAccess.ReturnValue("SELECT isNull(sum(lv_adj),0) FROM tbl_Employee_Attend where (id='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (season='" + cmbYear.Text + "') and (month='2/"+ss[1].ToString()+"')");
                        dgvLv.Rows[rw].Cells["col_mar"].Value = clsDataAccess.ReturnValue("SELECT isNull(sum(lv_adj),0) FROM tbl_Employee_Attend where (id='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (season='" + cmbYear.Text + "') and (month='3/" + ss[1].ToString() + "')");


                        dgvLv.Rows[rw].Cells["col_rate"].Value = clsDataAccess.ReturnValue("select isNull(salary,0) from tbl_lv_balance where (eid='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (month='Mar-" + ss[1].ToString() + "') and (session='" + cmbYear.Text + "')");
                        dgvLv.Rows[rw].Cells["col_amt"].Value = clsDataAccess.ReturnValue("select isNull(amt,0) from tbl_lv_balance where (eid='" + EmployeeID.Rows[rw]["EID"].ToString() + "') and (month='Mar-" + ss[1].ToString() + "') and (session='" + cmbYear.Text + "')");

                        if (dgvLv.Rows[rw].Cells["col_rate"].Value.ToString().Trim() == "")
                        {
                            dgvLv.Rows[rw].Cells["col_rate"].Value = 0;
                        }

                        if (dgvLv.Rows[rw].Cells["col_amt"].Value.ToString().Trim() == "")
                        {
                            dgvLv.Rows[rw].Cells["col_amt"].Value = 0;
                        }

                    }

                }
            }
        }

        private void frmLvEncashment_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2018, System.DateTime.Now.Year, 1);

             AttenDtTmPkr.Value= System.DateTime.Now.AddMonths(-1);


             clsGeneralShow genralshow = new clsGeneralShow();
             genralshow.getCurLocID();

        }

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }

            try
            {
                if (AttenDtTmPkr.Value.Month == 3)
                {
                    btnSubmit.Visible = true;
                }
                else
                {
                    btnSubmit.Visible = false;
                }
            }
            catch { }
        }

        private void btnclose_frm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //dgvLv.Columns.Add("col_rem", "rem");
            //dgvLv.Columns.Add("col_rate", "Salary");
            //dgvLv.Columns.Add("col_amt", "Amount");
            switch (e.ColumnIndex)
            {
                case 16:
                    var row = dgvLv.Rows[e.RowIndex];

                    double rate=0, rem=0;

                    double.TryParse(row.Cells["col_rem"].Value.ToString(), out rem);
                    double.TryParse(row.Cells["col_rate"].Value.ToString(), out rate);

                    row.Cells["col_amt"].Value = Math.Round(((rem * rate)/30),0).ToString("0.00");
                    break;
            }
        }

        public void export()
        {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                int iCol = 0,cCol=dgvLv.Columns.Count;
            
                excel.Cells[1, 1] = clsDataAccess.ReturnValue("select CO_Name from Company where CO_Code='" + Lbl_coid.Text + "'");
                Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, cCol]);
                range.Font.Bold = true;
                range.Font.Size = 12;
                range.Merge(true);

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                range.Rows.AutoFit();
                
                excel.Cells[2, 1] = "Payment Sheet for all Locations of : " + cmbLocation.Text.ToString().Trim();
                
                range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, cCol]);
                range.Font.Bold = true;
                range.Font.Size = 10;
                range.Merge(true);

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Font.Bold = true;
                range.Columns.AutoFit();
                range.Rows.AutoFit();

                excel.Cells[3, 1] = "Session : " + cmbYear.Text.ToString().Trim();
                range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, cCol]);
                range.Font.Bold = true;
                range.Font.Size = 10;
                range.Merge(true);

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                range.Rows.AutoFit();

                excel.Cells[4, 1] = "For the month of " + AttenDtTmPkr.Value.ToString("MMMM - yyyy");
                range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, cCol]);
                range.Font.Bold = true;
                range.Font.Size = 10;
                range.Merge(true);

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                range.Rows.AutoFit();


                //foreach (DataColumn c in dgvLv.Columns)
                //{
                //    iCol++;
                //    excel.Cells[5, iCol] = c.ColumnName;
                //}

                for (int i = 0; i < dgvLv.Columns.Count ; i++)
                {
                    iCol++;
                    excel.Cells[5, iCol] = dgvLv.Columns[i].HeaderText;
                }  
                range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, cCol]);
                range.Font.Bold = true;
                range.Font.Size = 8;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                range.Rows.AutoFit();

                int iRow = 5;

                for (int rw = 0; rw < dgvLv.Rows.Count; rw++)
                {
                    iRow++;
                    iCol = 0;
                    for (int i = 0; i < dgvLv.Columns.Count; i++)
                    {
                        try
                        {
                            iCol++;
                            excel.Cells[iRow, iCol] = dgvLv.Rows[rw].Cells[i].Value ;

                            if (iCol > 2)
                            {
                                range = worksheet.get_Range(worksheet.Cells[iRow,3], worksheet.Cells[iRow, cCol - 1]);
                                range.Font.Size = 8;
                                range.NumberFormat = "0.00";

                            }
                            else
                            {
                               
                                range = worksheet.get_Range(worksheet.Cells[iRow, 1], worksheet.Cells[iRow, 2]);
                                range.Font.Size = 8;
                                range.NumberFormat = "@";
                            }

                        }
                        catch
                        {

                        }
                    }
                }

                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[iRow, cCol]);
                Excel.Borders borders = range.Borders;
                //Set the thick lines style.
                borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                borders.Weight = 2d;
                //range.WrapText = true;


                object missing = System.Reflection.Missing.Value;

                worksheet = (Excel.Worksheet)excel.ActiveSheet;
                ((Excel._Worksheet)worksheet).Activate();

                worksheet.UsedRange.Select();
               
                    //BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexNone, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
                worksheet.Columns.AutoFit();

                ((Excel._Application)excel).Quit();

                MessageBox.Show("Export To ExcelCompleted!", "Export");

                // excel
            
            
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string sql = "",sql1="";

            sql1 = "delete from tbl_lv_balance where (locid='" + lblLid.Text + "') and (month='" + dtp_DOE.Value.ToString("MMM-yyyy") + "')";
            clsDataAccess.RunQry(sql1);
           
               sql1 = "";
            
            for (int rw = 0; rw < dgvLv.Rows.Count; rw++)
            {
                if (sql1.Trim() == "")
                {
                    sql1 = "( '" + dgvLv.Rows[rw].Cells["col_eid"].Value + "','" + lblLid.Text + "','" + dtp_DOE.Value.ToString("MMM-yyyy") + "','" + cmbYear.Text + "','" + txtcalculated_days.Text + "','" + dgvLv.Rows[rw].Cells["col_tot"].Value + "','" + dgvLv.Rows[rw].Cells["col_apr"].Value + "','" + dgvLv.Rows[rw].Cells["col_may"].Value + "','" + dgvLv.Rows[rw].Cells["col_jun"].Value + "','" + dgvLv.Rows[rw].Cells["col_jul"].Value +
                        "','"+dgvLv.Rows[rw].Cells["col_aug"].Value+"','"+dgvLv.Rows[rw].Cells["col_sep"].Value+"','"+dgvLv.Rows[rw].Cells["col_oct"].Value+"','"+ dgvLv.Rows[rw].Cells["col_nov"].Value+"','"+dgvLv.Rows[rw].Cells["col_dec"].Value+
                        "','"+dgvLv.Rows[rw].Cells["col_jan"].Value+"','"+dgvLv.Rows[rw].Cells["col_feb"].Value+"','"+dgvLv.Rows[rw].Cells["col_mar"].Value +"','"+ dgvLv.Rows[rw].Cells["col_rem"].Value+"','"+dgvLv.Rows[rw].Cells["col_rate"].Value+"','"+ dgvLv.Rows[rw].Cells["col_amt"].Value+"')";

                }
                else
                {

                    sql1 = sql1 + ",( '" + dgvLv.Rows[rw].Cells["col_eid"].Value + "','" + lblLid.Text + "','" + dtp_DOE.Value.ToString("MMM-yyyy") + "','" + cmbYear.Text + "','" + txtcalculated_days.Text + "','" + dgvLv.Rows[rw].Cells["col_tot"].Value + "','" + dgvLv.Rows[rw].Cells["col_apr"].Value + "','" + dgvLv.Rows[rw].Cells["col_may"].Value + "','" + dgvLv.Rows[rw].Cells["col_jun"].Value + "','" + dgvLv.Rows[rw].Cells["col_jul"].Value +
                        "','"+dgvLv.Rows[rw].Cells["col_aug"].Value+"','"+dgvLv.Rows[rw].Cells["col_sep"].Value+"','"+dgvLv.Rows[rw].Cells["col_oct"].Value+"','"+ dgvLv.Rows[rw].Cells["col_nov"].Value+"','"+dgvLv.Rows[rw].Cells["col_dec"].Value+
                        "','"+dgvLv.Rows[rw].Cells["col_jan"].Value+"','"+dgvLv.Rows[rw].Cells["col_feb"].Value+"','"+dgvLv.Rows[rw].Cells["col_mar"].Value +"','"+ dgvLv.Rows[rw].Cells["col_rem"].Value+"','"+dgvLv.Rows[rw].Cells["col_rate"].Value+"','"+ dgvLv.Rows[rw].Cells["col_amt"].Value+"')";
                }

            }
                // eid,locid,month,session,doc,total,apr,may,jun,jul,aug,sep,oct,nov,dec,jan,feb,mar,rem,salary,amt
             sql = "INSERT INTO tbl_lv_balance(eid,locid,month,session,doc,total,apr,may,jun,jul,aug,sep,oct,nov,dec,jan,feb,mar,rem,salary,amt) VALUES " + sql1;

             bool bl=   clsDataAccess.RunQry(sql);

             if (bl == true)
             {
                if  (MessageBox.Show("Record Accepted.. Want to export to Excel?", "BRAVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    export();
                }
             }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            export();
        }
    }
}
