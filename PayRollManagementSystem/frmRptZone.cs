using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace PayRollManagementSystem
{
    public partial class frmRptZone : Form
    {
        public frmRptZone()
        {
            InitializeComponent();
        }
        string val_code = "";
        DataTable dt_view = new DataTable();
        public void zone_view()
        {
            string sql = "", condt = "";
            if (rdballzone.Checked == true)
            {
                condt = " where zid in (select zid from (Select zid,zone,(select count(*) from tbl_Emp_Location where zid=tz.zid)as active from tbl_Zone tz) tzn where active>0)";

            }
            else
            {
                if (cmbcompany.ReturnValue.Trim() != "")
                {
                    val_code = Convert.ToString(cmbcompany.ReturnValue);


                    if (rdbCompany.Checked == true)
                    {

                        condt = " where (CompanyID='" + val_code + "')";
                    }
                    else
                    {
                        condt = " where (zid ='" + val_code + "')";

                    }


                }

            }
            sql = "select Zone,LocationName,ClientName,Company from (SELECT cr.Company_ID as 'CompanyID',cr.Location_ID as 'LocationID',el.Cliant_ID as 'ClientID',el.zid," +
"(Select zone from tbl_Zone where zid=el.zid)as 'Zone',el.Location_Name as 'LocationName'," +
"(select Client_Name from tbl_Employee_CliantMaster where Client_id=el.Cliant_ID)as 'ClientName'," +
"(select CO_NAME from Company where CO_CODE=cr.Company_ID) as 'Company'" +
" FROM Companywiseid_Relation AS cr INNER JOIN tbl_Emp_Location AS el ON cr.Location_ID = el.Location_ID)as ztbl " + condt + " order by zid,LocationName,CompanyID ";

            dt_view = clsDataAccess.RunQDTbl(sql);


            dgvZone.DataSource = dt_view;
            dgvZone.AutoResizeColumns();
            if (dt_view.Rows.Count > 0)
            {
                btn_exp.Visible = true;
            }
            else{
                btn_exp.Visible=false;
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {

            zone_view();
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            string sql = "";
            if (rdballzone.Checked == true)
            {

                sql = "select '' as name,'' as code";
            }
            else if (rdbCompany.Checked == true)
            {
                sql = "Select CO_NAME as 'Company Name',CO_CODE as 'Company Code' from Company";
            }
            else
            {

                sql = "select zone as 'Zone Name',zid as 'Zone ID' from (Select zid,zone,(select count(*) from tbl_Emp_Location where zid=tz.zid)as active from tbl_Zone tz) zn where active>0";
            }

            DataTable dt = clsDataAccess.RunQDTbl(sql);
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
            }
        }

        private void rdbZone_CheckedChanged(object sender, EventArgs e)
        {
            cmbcompany.Enabled = true;
            try
            {
                dgvZone.Rows.Clear();
            }
            catch { }
            try{
            dgvZone.Columns.Clear();
            }
            catch { }
            
            if (rdballzone.Checked == true)
            {
                lbltype.Text = "";
                cmbcompany.Text = "";
                cmbcompany.Enabled=false;
                zone_view();

            }
            else if (rdbCompany.Checked == true)
            {
                lbltype.Text = "Select Company";
                cmbcompany.Text = "";
            }
            else
            {
                lbltype.Text = "Select Zone";
                cmbcompany.Text = "";

            }
        }

        private void frmRptZone_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_exp_Click(object sender, EventArgs e)
        {
            string head = "", val_range = "";

            //excel

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 0, irw = 0; ;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            iCol = dgvZone.Columns.Count-1;

            if (rdballzone.Checked == true)
            {

                head = "Zone wise report";
            }
            else if (rdbCompany.Checked == true)
            {
                head = "Company wise Zone Report";
                val_range = "For the Company : " + cmbcompany.Text;
            }
            else
            {
                head = "Zone Report";
                val_range = "Selected Zone : " + cmbcompany.Text;
            }
           
            



            excel.Cells[1, 1] = head;

            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);
            range.Merge(true);
            range.Font.Bold = true;


            range.HorizontalAlignment = HorizontalAlign.Center;
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

            excel.Cells[3, 1] = "";
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();

            string[] cell_head = new string[] { };
            string old_head = "";
            int ind_st = 0, ind_fin = 0;

            
            range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, iCol]);
            range.Font.Bold = true;
            old_head="";
            int ix = 3;
            for (int i = 0; i < dgvZone.Rows.Count; i++)
            {
                cell_head = Convert.ToString(dgvZone.Rows[i].Cells[0].Value.ToString()).Split('.');
                ix++;
                if (old_head != cell_head[0])
                {
                    old_head = Convert.ToString(dgvZone.Rows[i].Cells[0].Value.ToString());
                    excel.Cells[ix, 1] = "Zone : " + dgvZone.Rows[i].Cells["Zone"].Value.ToString();
                    excel.Cells[ix, 2] = "";
                    excel.Cells[ix, 3] = "";
                    range = worksheet.get_Range(worksheet.Cells[ix, 1], worksheet.Cells[ix, iCol]);
                    range.Merge(true);
                    ix++;
                    excel.Cells[ix, 1] = "Location Name";
                    excel.Cells[ix, 2] = "Client Name";
                    excel.Cells[ix, 3] = "Company Name";
                    range = worksheet.get_Range(worksheet.Cells[ix, 1], worksheet.Cells[ix, iCol]);
                    range.Font.Bold = true;
                    ix++;
                }
                excel.Cells[ix, 1] = dgvZone.Rows[i].Cells["LocationName"].Value.ToString();
                excel.Cells[ix, 2] = dgvZone.Rows[i].Cells["ClientName"].Value.ToString();
                excel.Cells[ix, 3] = dgvZone.Rows[i].Cells["Company"].Value.ToString();
                  
            }

            irw = ix;
            object missing = System.Reflection.Missing.Value;



            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[irw, 3]);
            Excel.Borders borders = range.Borders;
            //Set the thick lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 2d;
            range.WrapText = true;

            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();

            //((Excel._Application)excel).Quit();

            MessageBox.Show("Export To Excel Completed!", "Export");


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
