using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StackedHeader;
using Edpcom;
using System.Collections;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frmSalMonthly : Form
    {
        public frmSalMonthly()
        {
            InitializeComponent();
            StackedHeaderDecorator objREnderer = new StackedHeaderDecorator(dgvSal);
        }
        int Company_id = 0;
        string Item_Code = "", Location_id = "0", Client_id = "0";
        string locid = "";
        string[] yr;
        ArrayList arritem = new ArrayList();
        Hashtable getcode_item = new Hashtable();

        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();


        private void frmSalMonthly_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            cmbYear.SelectedIndex = 0;
            rdbCompany.Checked = true;

            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                CmbCompany.Text = dta.Rows[0][0].ToString();

                Company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                CmbCompany.ReturnValue = Company_id.ToString();

            }
            else if (dta.Rows.Count > 1)
            {
                CmbCompany.PopUp();
            }
        }

        private void rdbCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCompany.Checked == true)
            {
                cmbLocation.Enabled = false;
                btnloc.Enabled = false;
            }
            else
            {
                btnloc.Enabled = true;
                //cmbLocation.Enabled = true;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                yr = cmbYear.Text.Split('-');
            }
            catch {
                MessageBox.Show("Select Session", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = "";
            try
            {
                dgvSal.DataSource = "";
            }
            catch { }
            if (rdbCompany.Checked == true)
            {
                sql = "select distinct Location_id,(SELECT (SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE (Client_id = el.Cliant_ID)) AS ClientName FROM tbl_Emp_Location AS el WHERE (Location_ID=x.Location_id))as 'Client',(select Location_Name FROM tbl_Emp_Location where location_id=x.Location_id )'Location',"+ 
"Max(case when month='April' then Gross else 0 end) as 'April-" + yr[0].Trim() + ".Gross',Max(case when month='April' then [Net] else 0 end) as 'April-" + yr[0].Trim() + ".Net'," +
"Max(case when month='May' then Gross else 0 end) as 'May-" + yr[0].Trim() + ".Gross',Max(case when month='May' then [Net] else 0 end) as 'May-" + yr[0].Trim() + ".Net'," +
"Max(case when month='June' then Gross else 0 end) as 'June-" + yr[0].Trim() + ".Gross',Max(case when month='June' then [Net] else 0 end) as 'June-" + yr[0].Trim() + ".Net'," +
"Max(case when month='July' then Gross else 0 end) as 'July-" + yr[0].Trim() + ".Gross',Max(case when month='July' then [Net] else 0 end) as 'July-" + yr[0].Trim() + ".Net'," +
"Max(case when month='August' then Gross else 0 end) as 'August-" + yr[0].Trim() + ".Gross',Max(case when month='August' then [Net] else 0 end) as 'August-" + yr[0].Trim() + ".Net'," +
"Max(case when month='September' then Gross else 0 end) as 'September-" + yr[0].Trim() + ".Gross',Max(case when month='September' then [Net] else 0 end) as 'September-" + yr[0].Trim() + ".Net'," +
"Max(case when month='October' then Gross else 0 end) as 'October-" + yr[0].Trim() + ".Gross',Max(case when month='October' then [Net] else 0 end) as 'October-" + yr[0].Trim() + ".Net'," +
"Max(case when month='November' then Gross else 0 end) as 'November-" + yr[0].Trim() + ".Gross',Max(case when month='November' then [Net] else 0 end) as 'November-" + yr[0].Trim() + ".Net'," +
"Max(case when month='December' then Gross else 0 end) as 'December-" + yr[0].Trim() + ".Gross',Max(case when month='December' then [Net] else 0 end) as 'December-" + yr[0].Trim() + ".Net'," +

"Max(case when month='January' then Gross else 0 end) as 'January-" + yr[1].Trim() + ".Gross',Max(case when month='January' then [Net] else 0 end) as 'January-" + yr[1].Trim() + ".Net'," +
"Max(case when month='February' then Gross else 0 end) as 'February-" + yr[1].Trim() + ".Gross',Max(case when month='February' then [Net] else 0 end) as 'February-" + yr[1].Trim() + ".Net'," +
"Max(case when month='March' then Gross else 0 end) as 'March-" + yr[1].Trim() + ".Gross',Max(case when month='March' then [Net] else 0 end) as 'March-" + yr[1].Trim() + ".Net'," +
"(Max(case when month='April' then Gross else 0 end)+Max(case when month='May' then Gross else 0 end)+Max(case when month='June' then Gross else 0 end)+Max(case when month='July' then Gross else 0 end)+Max(case when month='August' then Gross else 0 end)+Max(case when month='September' then Gross else 0 end)+Max(case when month='October' then Gross else 0 end)+Max(case when month='November' then Gross else 0 end)+Max(case when month='December' then Gross else 0 end)+Max(case when month='January' then Gross else 0 end)+Max(case when month='February' then Gross else 0 end)+Max(case when month='March' then Gross else 0 end)) 'Total.Gross',"+
"(Max(case when month='April' then [Net] else 0 end)+Max(case when month='May' then [Net] else 0 end)+Max(case when month='June' then [Net] else 0 end)+Max(case when month='July' then [Net] else 0 end)+Max(case when month='August' then [Net] else 0 end)+Max(case when month='September' then [Net] else 0 end)+Max(case when month='October' then [Net] else 0 end)+Max(case when month='November' then [Net] else 0 end)+Max(case when month='December' then [Net] else 0 end)+Max(case when month='January' then [Net] else 0 end)+Max(case when month='February' then [Net] else 0 end)+Max(case when month='March' then [Net] else 0 end)) 'Total.Net' "+
"from (select Location_id,MONTH,SUM(GrossAmount) as 'Gross',SUM(NetPay) as 'Net' FROM tbl_Employee_SalaryMast where (session='" + cmbYear.Text + "') and (Company_id=" + Company_id + ") and emp_id<>'' group by Location_id,month)x group by Location_id";
            }
            else
            {
                sql = "select distinct (select (CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END) from tbl_Employee_Mast em where ID=x.emp_id)'Employee Name',x.emp_id 'Employee ID',(select PassportNo from tbl_Employee_Mast em where ID=x.emp_id)'UAN No',(select pf from tbl_Employee_Mast em where ID=x.emp_id)'PF No',(select ESIno from tbl_Employee_Mast em where ID=x.emp_id)'ESI No'," +
"Max(case when month='April' then Gross else 0 end) as 'April-" + yr[0].Trim() + ".Gross',Max(case when month='April' then [Net] else 0 end) as 'April-" + yr[0].Trim() + ".Net'," +
"Max(case when month='May' then Gross else 0 end) as 'May-" + yr[0].Trim() + ".Gross',Max(case when month='May' then [Net] else 0 end) as 'May-" + yr[0].Trim() + ".Net'," +
"Max(case when month='June' then Gross else 0 end) as 'June-" + yr[0].Trim() + ".Gross',Max(case when month='June' then [Net] else 0 end) as 'June-" + yr[0].Trim() + ".Net'," +
"Max(case when month='July' then Gross else 0 end) as 'July-" + yr[0].Trim() + ".Gross',Max(case when month='July' then [Net] else 0 end) as 'July-" + yr[0].Trim() + ".Net'," +
"Max(case when month='August' then Gross else 0 end) as 'August-" + yr[0].Trim() + ".Gross',Max(case when month='August' then [Net] else 0 end) as 'August-" + yr[0].Trim() + ".Net'," +
"Max(case when month='September' then Gross else 0 end) as 'September-" + yr[0].Trim() + ".Gross',Max(case when month='September' then [Net] else 0 end) as 'September-" + yr[0].Trim() + ".Net'," +
"Max(case when month='October' then Gross else 0 end) as 'October-" + yr[0].Trim() + ".Gross',Max(case when month='October' then [Net] else 0 end) as 'October-" + yr[0].Trim() + ".Net'," +
"Max(case when month='November' then Gross else 0 end) as 'November-" + yr[0].Trim() + ".Gross',Max(case when month='November' then [Net] else 0 end) as 'November-" + yr[0].Trim() + ".Net'," +
"Max(case when month='December' then Gross else 0 end) as 'December-" + yr[0].Trim() + ".Gross',Max(case when month='December' then [Net] else 0 end) as 'December-" + yr[0].Trim() + ".Net'," +

"Max(case when month='January' then Gross else 0 end) as 'January-" + yr[1].Trim() + ".Gross',Max(case when month='January' then [Net] else 0 end) as 'January-" + yr[1].Trim() + ".Net'," +
"Max(case when month='February' then Gross else 0 end) as 'February-" + yr[1].Trim() + ".Gross',Max(case when month='February' then [Net] else 0 end) as 'February-" + yr[1].Trim() + ".Net'," +
"Max(case when month='March' then Gross else 0 end) as 'March-" + yr[1].Trim() + ".Gross',Max(case when month='March' then [Net] else 0 end) as 'March-" + yr[1].Trim() + ".Net'," +
"(Max(case when month='April' then Gross else 0 end)+Max(case when month='May' then Gross else 0 end)+Max(case when month='June' then Gross else 0 end)+Max(case when month='July' then Gross else 0 end)+Max(case when month='August' then Gross else 0 end)+Max(case when month='September' then Gross else 0 end)+Max(case when month='October' then Gross else 0 end)+Max(case when month='November' then Gross else 0 end)+Max(case when month='December' then Gross else 0 end)+Max(case when month='January' then Gross else 0 end)+Max(case when month='February' then Gross else 0 end)+Max(case when month='March' then Gross else 0 end)) 'Total.Gross',"+
"(Max(case when month='April' then [Net] else 0 end)+Max(case when month='May' then [Net] else 0 end)+Max(case when month='June' then [Net] else 0 end)+Max(case when month='July' then [Net] else 0 end)+Max(case when month='August' then [Net] else 0 end)+Max(case when month='September' then [Net] else 0 end)+Max(case when month='October' then [Net] else 0 end)+Max(case when month='November' then [Net] else 0 end)+Max(case when month='December' then [Net] else 0 end)+Max(case when month='January' then [Net] else 0 end)+Max(case when month='February' then [Net] else 0 end)+Max(case when month='March' then [Net] else 0 end)) 'Total.Net' "+
" from (select Emp_Id,Location_id,MONTH,SUM(GrossAmount) as 'Gross',SUM(NetPay) as 'Net' FROM tbl_Employee_SalaryMast where (session='" + cmbYear.Text + "') and (Company_id=" + Company_id + ") and (Location_id in ("+locid+")) and emp_id<>'' group by Emp_Id, Location_id,month)x group by Location_id,Emp_Id";
            }
            DataTable dt = clsDataAccess.RunQDTbl(sql);

            
            
            try
            {
                dt.Rows.Add();
                int ind = dt.Rows.Count-1;
                if (rdbCompany.Checked == true)
                {
                    dt.Rows[ind][1] = "Total";
                }
                else
                {
                    dt.Rows[ind][0] = "Total";
                }
                string col = "";
                for (int cl = 3; cl < dt.Columns.Count; cl++)
                {
                    col = dt.Columns[cl].ColumnName.ToString();
                    dt.Rows[ind][col] = dt.Compute("Sum("+col+"))","");
                }
            }
            catch { }
            dgvSal.DataSource = dt;
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            string sqlstmnt = "";

            sqlstmnt = "select distinct Location_id,(select Location_Name from tbl_Emp_Location where Location_ID=sm.Location_id)as Location,(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID) from tbl_Emp_Location l where Location_ID=sm.Location_id) as Client from  tbl_Employee_SalaryMast sm where (Company_id='" + Company_id + "') and (session='" + cmbYear.Text.Trim() + "')";
            EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Location", "Select Location", 0, "CMPN", 0);
            arritem.Clear();
            arritem = EDPCommon.arr_mod;

            if (arritem.Count > 0)
            {
                getcode_item.Clear();
                arritem = EDPCommon.arr_mod;
                getcode_item = EDPCommon.get_code;

                Item_Code = null;
                Item_Code = "''";

                for (int i = 0; i <= arritem.Count - 1; i++)
                {
                    if (Item_Code == "''") { Item_Code = "'" + arritem[i].ToString() + "'"; }
                    else
                    {
                        Item_Code = Item_Code + "," + "'" + arritem[i].ToString() + "'";
                    }
                }

                locid = Item_Code;
            }
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {

                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            }


            if (dt.Rows.Count > 0)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
                cmbLocation.Text = "";
            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(CmbCompany.ReturnValue);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string head = "", val_range = "";

            //excel

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 0, irw = 0; ;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            iCol = dgvSal.Columns.Count;

            head = CmbCompany.Text;
            val_range = "";

            if (rdbCompany.Checked == true)
            {

                val_range = "Month wise Salary Report [Location wise]" + Environment.NewLine + "For the Session of " + cmbYear.Text;
            }
            else
            {
                val_range = "Month wise Salary Report [Employee Wise]" + Environment.NewLine + "For the Session of " + cmbYear.Text;
            }
            excel.Cells[1, 1] = head;

            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);
            range.Merge(true);
            range.Font.Bold = true;


            range.HorizontalAlignment = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[2, 1] = val_range;

            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            range.Columns.AutoFit();
            range.Rows.AutoFit();

            //excel.Cells[3, 1] = "";
            //range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
            //range.Merge(true);
            //range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            //range.Columns.AutoFit();
            //range.Rows.AutoFit();

            string[] cell_head = new string[] { };
            string old_head = "", Sub_old_head = "";
            int ind_st = 0, ind_fin = 0;
            int ind_st_sub = 0, ind_fin_sub = 0;

            for (int i = 1; i <= dgvSal.Columns.Count; i++)
            {
                cell_head = Convert.ToString(dgvSal.Columns[i - 1].HeaderText).Split('.');
                if (cell_head.Length > 2)
                {
                    if (old_head == cell_head[0])
                    {
                        ind_fin = i;
                    }
                    else
                    {
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[3, ind_st], worksheet.Cells[3, ind_fin]);
                            range.Merge(Type.Missing);
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        }
                        catch { }
                        ind_st = i;
                        excel.Cells[3, i] = cell_head[0];
                        old_head = cell_head[0];
                    }
                    if (Sub_old_head == cell_head[1])
                    {
                        ind_fin_sub = i;
                    }
                    else
                    {
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[4, ind_st_sub], worksheet.Cells[4, ind_fin_sub]);
                            range.Merge(Type.Missing);
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        }
                        catch { }
                        ind_st_sub = i;
                        excel.Cells[4, i] = cell_head[1];
                        Sub_old_head = cell_head[1];
                    }
                    try
                    {
                        excel.Cells[5, i] = cell_head[2];

                    }
                    catch { }
                }
                else if (cell_head.Length > 0)
                {


                    excel.Cells[3, i] = dgvSal.Columns[i - 1].HeaderText;
                    try
                    {
                        range = worksheet.get_Range(worksheet.Cells[3, i], worksheet.Cells[5, i]);
                        range.Merge(Type.Missing);
                        range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    }
                    catch { }
                }

            }

            try
            {
                range = worksheet.get_Range(worksheet.Cells[3, ind_st], worksheet.Cells[3, ind_fin]);
                range.Merge(Type.Missing);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            }
            catch { }
            try
            {
                range = worksheet.get_Range(worksheet.Cells[4, ind_st_sub], worksheet.Cells[4, ind_fin_sub]);
                range.Merge(Type.Missing);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            }
            catch { }
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[5, iCol]);
            range.Font.Bold = true;

            for (int i = 0; i < dgvSal.Rows.Count; i++)
            {
                for (int j = 1; j <= dgvSal.Columns.Count; j++)
                {
                    try
                    {
                        irw = i + 6;
                        if (dgvSal.Columns[j - 1].HeaderText.Trim().ToLower() == "esi no" || dgvSal.Columns[j - 1].HeaderText.Trim().ToLower() == "pf no" || dgvSal.Columns[j - 1].HeaderText.Trim().ToLower() == "uan no")
                        {
                            excel.Cells[i + 6, j] = "'" + dgvSal.Rows[i].Cells[j - 1].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 6, j] = dgvSal.Rows[i].Cells[j - 1].Value.ToString();
                        }
                    }
                    catch { }
                }
            }

            object missing = System.Reflection.Missing.Value;



            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[irw, iCol]);
            Excel.Borders borders = range.Borders;
            //Set the thick lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 2d;
            range.WrapText = true;

            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();

            ((Excel._Application)excel).Quit();

            MessageBox.Show("Export To Excel Completed!", "Export");
        }
    }
}
