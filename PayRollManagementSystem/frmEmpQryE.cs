using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmEmpQryE : Form
    {
        public frmEmpQryE()
        {
            InitializeComponent();
        }
        string location_id="", Company_id="", sql="", columnName="";
        DataTable dt = new DataTable();
        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 1)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;

            }
            else if (dt.Rows.Count == 1)
            {
                cmbcompany.ReturnValue = dt.Rows[0]["CO_CODE"].ToString();
                cmbcompany.Text = dt.Rows[0]["CO_NAME"].ToString();
                Company_id = (cmbcompany.ReturnValue);
            }
            else
            {
                MessageBox.Show("No Company Record Found", "BRAVO");
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Company_id = (cmbcompany.ReturnValue);
        }


        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            sql = "";
            sql = ("Select Location_Name,Location_ID,(select client_name from tbl_Employee_CliantMaster where Client_id= el.Cliant_ID) as Client  from tbl_Emp_Location el where (Location_ID IN (select Location_ID from Companywiseid_Relation where (Company_ID='" + Company_id + "'))) order by Location_Name");
            dt = clsDataAccess.RunQDTbl(sql);
            if (dt.Rows.Count > 1)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                cmbLocation.Text = dt.Rows[0]["Location_Name"].ToString();
                cmbLocation.ReturnValue = dt.Rows[0]["Location_ID"].ToString();
                location_id = dt.Rows[0]["Location_ID"].ToString();
                lblClient.Text = dt.Rows[0]["Client"].ToString();
                //fill_emp();
            }
            else
            {
                MessageBox.Show("No Location Record Found", "BRAVO");
            }
        }
        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {

            location_id = cmbLocation.ReturnValue;

            lblClient.Text = clsDataAccess.ReturnValue("Select (select client_name from tbl_Employee_CliantMaster where Client_id=el.Cliant_ID) as Client from tbl_Emp_Location el where (Location_ID ='" + location_id + "')");
            //fill_emp();
        }

        private void frmEmpQryE_Load(object sender, EventArgs e)
        {
            
            cmbcompany.PopUp();
            cmbLocation.Enabled = false;
        }



        private void fill_emp()
        {
            try
            {
                dgView.Rows.Clear();
                dgView.Columns.Clear();
            }
            catch { }

            if (rdbComWise.Checked == true)
            {
                sql = "select EID,ECode,EmpName,Designation,[Base Client],[Base Location],STD,Phone,Mobile,EmailId,"+
         "(case when lmon>3 then 'Dormant' else (case when lmon>1 then 'Pre-Dormant' else 'Active' end) end )'Status' from (SELECT em.Code as EID,em.ID as ECode," +
         "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))'EmpName'," +
         "(SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE (SlNo = em.DesgId)) AS Designation,"+
         "IsNull((SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id=el.Cliant_ID) as Client FROM tbl_Emp_Location el WHERE (Location_ID = em.Location_id)),'-') AS 'Base Client'," +
         "IsNull((SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = em.Location_id)),'-') AS 'Base Location'," +
         "STD, Phone, Mobile, EmailId,(SELECT DATEDIFF(month, max(cast(('01-'+ [Month]) as Date)), CAST( GETDATE() AS Date )) FROM tbl_Employee_SalaryGross where empid=em.ID) lmon " +
         " from tbl_Employee_Mast em where (Company_id='" + Company_id + "') and (active=1))x";
            }
            else
            {
                 sql="select EID,ECode,EmpName,Designation,[Base Client],[Base Location],STD,Phone,Mobile,EmailId,"+
         "(case when lmon>3 then 'Dormant' else (case when lmon>1 then 'Pre-Dormant' else 'Active' end) end )'Status' from (SELECT em.Code as EID,em.ID as ECode," +
         "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))'EmpName'," +
         "(SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE (SlNo = em.DesgId)) AS Designation,"+
         "IsNull((SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id=el.Cliant_ID) as Client FROM tbl_Emp_Location el WHERE (Location_ID = em.Location_id)),'-') AS 'Base Client'," +
         "IsNull((SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = em.Location_id)),'-') AS 'Base Location'," +
         "STD, Phone, Mobile, EmailId,(SELECT DATEDIFF(month, max(cast(('01-'+ [Month]) as Date)), CAST( GETDATE() AS Date )) FROM tbl_Employee_SalaryGross where empid=em.ID) lmon " +
         " from tbl_Employee_Mast em where (Location_id='" + location_id +"') and (active=1))x";
            }
            dt = clsDataAccess.RunQDTbl(sql);

                if (dt.Rows.Count > 0)
                {
                    dgView.DataSource = dt;
                    dgView.AllowUserToAddRows = false;
                    try
                    {
                        dgView.Columns["EID"].Visible = false;
                        dgView.Columns["ECode"].ReadOnly = true;
                        dgView.Columns["EmpName"].ReadOnly = true;
                        
                        dgView.Columns["Designation"].ReadOnly = true;

                        try
                        {
                            dgView.Columns["Base Client"].Width = 175;
                            dgView.Columns["Base Location"].Width = 175;
                        }
                        catch { }
                        dgView.Columns["Base Client"].ReadOnly = true;
                        dgView.Columns["Base Location"].ReadOnly = true;

                        dgView.Columns["ECode"].Width = 30;
                        dgView.Columns["EmpName"].Width = 200;
                        dgView.Columns["Designation"].Width = 70;
                        
                        dgView.Columns["STD"].Width = 20;
                        dgView.Columns["Phone"].Width = 30; 
                        dgView.Columns["Mobile"].Width = 30;
                        dgView.Columns["EmailId"].Width = 70;
                        dgView.Columns["Status"].Width = 70;

                           
                        dgView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        dgView.AutoSizeRowsMode= DataGridViewAutoSizeRowsMode.AllCells;

                    }
                    catch { }
                }

           
            
        }

        private void btnclose_frm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Close ?", "Bravo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            fill_emp();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to process ?", "Bravo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                string eid = "", ecode = "", std = "", phone = "", mob = "", email = "", msg = "";
                bool bl;
                if (dgView.Rows.Count > 0)
                {
                    msg = "";
                    for (int idx = 0; idx < dgView.Rows.Count; idx++)
                    {

                        eid = dgView.Rows[idx].Cells["EID"].Value.ToString().Trim();
                        ecode = dgView.Rows[idx].Cells["ECode"].Value.ToString().Trim();

                        std = dgView.Rows[idx].Cells["STD"].Value.ToString().Trim();
                        phone = dgView.Rows[idx].Cells["Phone"].Value.ToString().Trim();
                        mob = dgView.Rows[idx].Cells["Mobile"].Value.ToString().Trim();
                        email = dgView.Rows[idx].Cells["EmailId"].Value.ToString().Trim();


                        bl = clsDataAccess.RunNQwithStatus("UPDATE tbl_Employee_Mast set STD='" + std +
                        "', Phone='" + phone + "', Mobile='" + mob + "', EmailId='" + email + "' where (ID='" + ecode + "')");
                        if (bl == false)
                        {
                            if (msg.Trim() == "")
                            {
                                msg = ecode;
                            }
                            else
                            {
                                msg = msg + ", " + ecode;
                            }

                        }
                    }
                    if (msg.Trim() == "")
                    {
                        msg = "All Employee record updated";

                    }
                    else
                    {
                        msg = "Following Employee record not updated, ECODE : " + msg;

                    }

                    MessageBox.Show(msg, "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {


            if (dgView.Rows.Count > 0)
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                int iCol = 0, cCol = 0;

                if (rdbComWise.Checked == true)
                {
                    cCol = 10;
                }
                else
                {
                    cCol = 10;
                }


                excel.Cells[1, 1] = "Employee Query Report";
                Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 10]);
                range.Font.Bold = true;
                range.Merge(true);
                range.RowHeight = 25;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                //range.Rows.AutoFit();

                if (rdbComWise.Checked == true)
                {
                    excel.Cells[2, 1] = cmbcompany.Text.ToString().Trim();
                }
                else
                {
                    excel.Cells[2, 1] = cmbcompany.Text.ToString().Trim() + Environment.NewLine +
                        "For the location : " + cmbLocation.Text.ToString().Trim();
                    
                }
                range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 10]);
                
                range.RowHeight = 35;
                range.WrapText = true;
                
                range.Font.Bold = true;
                range.Merge(true);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                //range.Rows.AutoFit();




                excel.Cells[3, 1] = "ECODE";
                excel.Cells[3, 2] = "Employee Name";
                excel.Cells[3, 3] = "Designation";
                excel.Cells[3, 4] = "Base Client";
                excel.Cells[3, 5] = "Base Location";
                excel.Cells[3, 6] = "STD";
                excel.Cells[3, 7] = "PHONE";
                excel.Cells[3, 8] = "MOBILE";
                excel.Cells[3, 9] = "EMAIL";
                excel.Cells[3, 10] = "STATUS";

                range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, 10]);
                range.Font.Bold = true;
                range.RowHeight = 20;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                //range.Rows.AutoFit();

                int iRow = 4;


                for (int idx = 0; idx < dgView.Rows.Count; idx++)
                {

                    
                    excel.Cells[iRow, 1] = dgView.Rows[idx].Cells["ECode"].Value.ToString().Trim();
                    excel.Cells[iRow, 2] = dgView.Rows[idx].Cells["EmpName"].Value.ToString().Trim();
                    excel.Cells[iRow, 3] = dgView.Rows[idx].Cells["Designation"].Value.ToString().Trim();
                    if (rdbComWise.Checked == true)
                    {
                        excel.Cells[iRow, 4] = dgView.Rows[idx].Cells["Base Client"].Value.ToString().Trim();
                        excel.Cells[iRow, 5] = dgView.Rows[idx].Cells["Base Location"].Value.ToString().Trim();
                    }
                    else
                    {
                        excel.Cells[iRow, 4] = lblClient.Text;
                        excel.Cells[iRow, 5] = cmbLocation.Text;
                    }
                    excel.Cells[iRow, 6] = dgView.Rows[idx].Cells["STD"].Value.ToString().Trim();
                    excel.Cells[iRow, 7] = dgView.Rows[idx].Cells["Phone"].Value.ToString().Trim();
                    excel.Cells[iRow, 8] = dgView.Rows[idx].Cells["Mobile"].Value.ToString().Trim();
                    excel.Cells[iRow, 9] = dgView.Rows[idx].Cells["EmailId"].Value.ToString().Trim();
                    excel.Cells[iRow, 10] = dgView.Rows[idx].Cells["Status"].Value.ToString().Trim();


                    range = worksheet.get_Range(worksheet.Cells[iRow, 1], worksheet.Cells[iRow, 10]);

                    
                    if (Convert.ToString(dgView.Rows[idx].Cells["Status"].Value.ToString().ToLower()) == "pre-Dormant")
                    {

                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        //Color.Yellow;
                    }
                    else if (Convert.ToString(dgView.Rows[idx].Cells["Status"].Value.ToString().ToLower()) == "Dormant" || Convert.ToString(dgView.Rows[idx].Cells["Status"].Value.ToString().ToLower()) == "inactive")
                    {
                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    }
                    else
                    {
                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        //range.Interior.Color = Color.Green;
                    }
                    range.NumberFormat = "@";
                    iRow++;


                }




                object missing = System.Reflection.Missing.Value;
                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[iRow ,10]);
                Excel.Borders borders = range.Borders;
                //Set the thick lines style.
                borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                borders.Weight = 2d;
                //range.WrapText = true;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                ((Excel._Worksheet)worksheet).Activate();
                worksheet.UsedRange.Select();

                worksheet.Columns.AutoFit();


                MessageBox.Show("Export To ExcelCompleted!", "Export");
            }

        }

        private void rdbComWise_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rdbLocWise.Checked == true)
            {
                if (cmbLocation.Enabled == false)
                {
                    cmbLocation.Enabled = true;
                    cmbLocation.PopUp();
                }
            }
            else
            {
                cmbLocation.Enabled = false;
            }
        }

        private void dgView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
               try
               {
                   columnName = dt.Columns[dgView.CurrentCell.ColumnIndex].ColumnName;
               }
               catch
               {
                   columnName = dt.Columns[0].ColumnName;
               }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                try
                {
                    //DataRow[] dt = dt_val.Select(columnName + " like '%" + txtSearch.Text + "%'");
                    dt.DefaultView.RowFilter = (columnName + " Like '" + txtSearch.Text + "%' or " + columnName + " = '" + txtSearch.Text + "'");
                    // qry = sql_frm + " where (" + columnName + "='" + txtSearch.Text + "')";
                }
                catch { }
            }
            else
            {
                try
                {
                    dt.DefaultView.RowFilter = "";
                    //qry = sql_frm + " order by " + columnName;
                }
                catch { }
            }
        }

        private void dgView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            columnName = dgView.Columns[e.ColumnIndex].Name;
            txtSearch.Focus();
        }
    }
}
