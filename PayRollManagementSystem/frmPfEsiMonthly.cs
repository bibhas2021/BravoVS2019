using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using StackedHeader;

namespace PayRollManagementSystem
{
    public partial class frmPfEsiMonthly : Form
    {
        public frmPfEsiMonthly()
        {
            InitializeComponent();
            StackedHeaderDecorator objREnderer = new StackedHeaderDecorator(dgvPfEsi);
        }
        int Company_id = 0, Location_id = 0, Client_id=0;
        string[] yr;


        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();


        private void rdbCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCompany.Checked == true)
            {
                cmbLocation.Enabled = false;
            }
            else
            {
                cmbLocation.Enabled = true;
            }
        }

        private void frmPfEsiMonthly_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            AttenDtTmPkr.Value = System.DateTime.Now;
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
        }


        private void cmbcompany_DropDown(object sender, EventArgs e)
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

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(CmbCompany.ReturnValue);

            //data_retrive_Company();
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID,(select client_name from tbl_Employee_CliantMaster where Client_id= el.Cliant_ID) as Client  from tbl_Emp_Location el where (Location_ID IN (select Location_ID from Companywiseid_Relation where (Company_ID='" + Company_id + "'))) order by Location_Name");
               
            
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                Location_id = Convert.ToInt32(cmbLocation.ReturnValue);

                    dt = clsDataAccess.RunQDTbl("SELECT Cliant_ID as Client_ID,(SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE (Client_id = el.Cliant_ID)) AS ClientName FROM tbl_Emp_Location AS el WHERE (Location_ID='" + Location_id + "')");

                    Client_id = Convert.ToInt32(dt.Rows[0]["Client_ID"].ToString());
                    cmbClient.Text = dt.Rows[0]["ClientName"].ToString();
            }
            catch { }
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
            iCol = dgvPfEsi.Columns.Count;

            head = CmbCompany.Text;
            val_range = "";

            if (rdbCompany.Checked == true)
            {

                val_range = "Month wise PF & ESI Report [Location wise]" + Environment.NewLine + "For the Session of " + cmbYear.Text;
            }
            else
            {
                val_range = "Month wise PF & ESI Report for the location : " + cmbLocation.Text + "["+ cmbClient.Text +"]"+Environment.NewLine + "For the Session of " + cmbYear.Text;
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
            string old_head = "", Sub_old_head = "" ;
            int ind_st = 0, ind_fin = 0;
            int ind_st_sub = 0, ind_fin_sub = 0;

            for (int i = 1; i <= dgvPfEsi.Columns.Count; i++)
            {
                cell_head = Convert.ToString(dgvPfEsi.Columns[i - 1].HeaderText).Split('.');
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


                    excel.Cells[3, i] = dgvPfEsi.Columns[i - 1].HeaderText;
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

            for (int i = 0; i < dgvPfEsi.Rows.Count; i++)
            {
                for (int j = 1; j <= dgvPfEsi.Columns.Count; j++)
                {
                    try
                    {
                        irw = i + 6;
                        if (dgvPfEsi.Columns[j - 1].HeaderText.Trim().ToLower() == "esi no" || dgvPfEsi.Columns[j - 1].HeaderText.Trim().ToLower() =="pf no" || dgvPfEsi.Columns[j - 1].HeaderText.Trim().ToLower() =="uan no")
                        {
                            excel.Cells[i + 6, j] = "'"+dgvPfEsi.Rows[i].Cells[j - 1].Value.ToString();
                        }
                        else
                        {
                          excel.Cells[i + 6, j] = dgvPfEsi.Rows[i].Cells[j - 1].Value.ToString();
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            yr = cmbYear.Text.Split('-');


            string sql = "";
            if (rdbCompany.Checked == true)
            {
                sql = "select distinct lid,(SELECT (SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE (Client_id = el.Cliant_ID)) AS ClientName FROM tbl_Emp_Location AS el WHERE (Location_ID=x.lid))as 'Client',(select Location_Name FROM tbl_Emp_Location where location_id=x.lid )'Location'," +
              "Max(case when month='April - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'April-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='April - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'April-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='April - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'April-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='April - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'April-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='May - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'May-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='May - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'May-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='May - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'May-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='May - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'May-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='June - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'June-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='June - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'June-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='June - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'June-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='June - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'June-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='July - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'July-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='July - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'July-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='July - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'July-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='July - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'July-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='August - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'August-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='August - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'August-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='August - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'August-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='August - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'August-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='September - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'September-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='September - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'September-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='September - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'September-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='September - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'September-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='October - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'October-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='October - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'October-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='October - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'October-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='October - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'October-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='November - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'November-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='November - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'November-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='November - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'November-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='November - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'November-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='December - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'December-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='December - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'December-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='December - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'December-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='December - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'December-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='January - " + yr[1].Trim() + "' then [PF_EmplCont] else 0 end) as 'January-" + yr[1].Trim() + ".PF.Employer'," +
              "Max(case when month='January - " + yr[1].Trim() + "' then [PF_EmpCont] else 0 end) as 'January-" + yr[1].Trim() + ".PF.Employee'," +
              "Max(case when month='January - " + yr[1].Trim() + "' then [Esi_EmplCont] else 0 end) as 'January-" + yr[1].Trim() + ".Esi.Employer'," +
              "Max(case when month='January - " + yr[1].Trim() + "' then [Esi_EmpCont] else 0 end) as 'January-" + yr[1].Trim() + ".Esi.Employee'," +

              "Max(case when month='February - " + yr[1].Trim() + "' then [PF_EmplCont] else 0 end) as 'February-" + yr[1].Trim() + ".PF.Employer'," +
              "Max(case when month='February - " + yr[1].Trim() + "' then [PF_EmpCont] else 0 end) as 'February-" + yr[1].Trim() + ".PF.Employee'," +
              "Max(case when month='February - " + yr[1].Trim() + "' then [Esi_EmplCont] else 0 end) as 'February-" + yr[1].Trim() + ".Esi.Employer'," +
              "Max(case when month='February - " + yr[1].Trim() + "' then [Esi_EmpCont] else 0 end) as 'February-" + yr[1].Trim() + ".Esi.Employee'," +

              "Max(case when month='March - " + yr[1].Trim() + "' then [PF_EmplCont] else 0 end) as 'March-" + yr[1].Trim() + ".PF.Employer'," +
              "Max(case when month='March - " + yr[1].Trim() + "' then [PF_EmpCont] else 0 end) as 'March-" + yr[1].Trim() + ".PF.Employee'," +
              "Max(case when month='March - " + yr[1].Trim() + "' then [Esi_EmplCont] else 0 end) as 'March-" + yr[1].Trim() + ".Esi.Employer'," +
              "Max(case when month='March - " + yr[1].Trim() + "' then [Esi_EmpCont] else 0 end) as 'March-" + yr[1].Trim() + ".Esi.Employee' " +
              "from (select lid,month, sum(pf_employer_cont+pf) as 'PF_EmplCont', sum(pf) as 'PF_EmpCont', sum(CEILING(esi_employer_cont)) as 'Esi_EmplCont', sum(esi) as 'Esi_EmpCont' FROM  tbl_employers_contribution ec where session='" + cmbYear.Text + "' and coid=" + Company_id + " and emp_id<>'' group by lid,month)x group by lid";
            }
            else
            {
                sql = "select distinct (select (CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
             "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END) from tbl_Employee_Mast em where ID=x.emp_id)'Employee Name',"+
              "x.emp_id 'Employee ID',(select PassportNo from tbl_Employee_Mast em where ID=x.emp_id)'UAN No',(select pf from tbl_Employee_Mast em where ID=x.emp_id)'PF No',(select ESIno from tbl_Employee_Mast em where ID=x.emp_id)'ESI No'," +
              "Max(case when month='April - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'April-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='April - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'April-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='April - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'April-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='April - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'April-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='May - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'May-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='May - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'May-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='May - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'May-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='May - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'May-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='June - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'June-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='June - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'June-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='June - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'June-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='June - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'June-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='July - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'July-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='July - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'July-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='July - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'July-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='July - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'July-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='August - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'August-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='August - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'August-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='August - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'August-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='August - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'August-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='September - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'September-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='September - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'September-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='September - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'September-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='September - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'September-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='October - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'October-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='October - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'October-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='October - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'October-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='October - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'October-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='November - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'November-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='November - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'November-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='November - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'November-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='November - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'November-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='December - " + yr[0].Trim() + "' then [PF_EmplCont] else 0 end) as 'December-" + yr[0].Trim() + ".PF.Employer'," +
              "Max(case when month='December - " + yr[0].Trim() + "' then [PF_EmpCont] else 0 end) as 'December-" + yr[0].Trim() + ".PF.Employee'," +
              "Max(case when month='December - " + yr[0].Trim() + "' then [Esi_EmplCont] else 0 end) as 'December-" + yr[0].Trim() + ".Esi.Employer'," +
              "Max(case when month='December - " + yr[0].Trim() + "' then [Esi_EmpCont] else 0 end) as 'December-" + yr[0].Trim() + ".Esi.Employee'," +

              "Max(case when month='January - " + yr[1].Trim() + "' then [PF_EmplCont] else 0 end) as 'January-" + yr[1].Trim() + ".PF.Employer'," +
              "Max(case when month='January - " + yr[1].Trim() + "' then [PF_EmpCont] else 0 end) as 'January-" + yr[1].Trim() + ".PF.Employee'," +
              "Max(case when month='January - " + yr[1].Trim() + "' then [Esi_EmplCont] else 0 end) as 'January-" + yr[1].Trim() + ".Esi.Employer'," +
              "Max(case when month='January - " + yr[1].Trim() + "' then [Esi_EmpCont] else 0 end) as 'January-" + yr[1].Trim() + ".Esi.Employee'," +

              "Max(case when month='February - " + yr[1].Trim() + "' then [PF_EmplCont] else 0 end) as 'February-" + yr[1].Trim() + ".PF.Employer'," +
              "Max(case when month='February - " + yr[1].Trim() + "' then [PF_EmpCont] else 0 end) as 'February-" + yr[1].Trim() + ".PF.Employee'," +
              "Max(case when month='February - " + yr[1].Trim() + "' then [Esi_EmplCont] else 0 end) as 'February-" + yr[1].Trim() + ".Esi.Employer'," +
              "Max(case when month='February - " + yr[1].Trim() + "' then [Esi_EmpCont] else 0 end) as 'February-" + yr[1].Trim() + ".Esi.Employee'," +

              "Max(case when month='March - " + yr[1].Trim() + "' then [PF_EmplCont] else 0 end) as 'March-" + yr[1].Trim() + ".PF.Employer'," +
              "Max(case when month='March - " + yr[1].Trim() + "' then [PF_EmpCont] else 0 end) as 'March-" + yr[1].Trim() + ".PF.Employee'," +
              "Max(case when month='March - " + yr[1].Trim() + "' then [Esi_EmplCont] else 0 end) as 'March-" + yr[1].Trim() + ".Esi.Employer'," +
              "Max(case when month='March - " + yr[1].Trim() + "' then [Esi_EmpCont] else 0 end) as 'March-" + yr[1].Trim() + ".Esi.Employee' " +
              "from (select lid,emp_id,month, sum(pf_employer_cont+pf) as 'PF_EmplCont', sum(pf) as 'PF_EmpCont', sum(CEILING(esi_employer_cont)) as 'Esi_EmplCont', sum(esi) as 'Esi_EmpCont' FROM  tbl_employers_contribution ec where (session='" + cmbYear.Text + "') and (coid=" + Company_id + ") and (lid=" + Location_id + ") and (emp_id<>'') group by lid,emp_id,month)x group by lid,emp_id";

            }
            DataTable dt = clsDataAccess.RunQDTbl(sql);

            dgvPfEsi.DataSource = dt;
           // dgvPfEsi.AutoResizeColumns();
        }

    }
}
