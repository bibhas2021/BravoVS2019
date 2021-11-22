using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using System.Collections;

namespace PayRollManagementSystem
{
    public partial class frmRegister_Bonus : Form
    {
        public frmRegister_Bonus()
        {
            InitializeComponent();
        }
        string Locations = "", Item_Code = "", co_name = "", co_add = "", sub = "", month = "";

        int Company_id = 0, Loc_id = 0;
        Edpcom.EDPCommon edpcom = new EDPCommon();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        DataTable dt = new DataTable();

        private void frmRegister_Bonus_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(CmbSession, 2015, System.DateTime.Now.Year, 1);
            try
            {
                if (DateTime.Now.Month >= 4)
                {
                    try
                    { CmbSession.SelectedItem = DateTime.Now.Year + "-" + DateTime.Now.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    CmbSession.SelectedItem = DateTime.Now.AddYears(-1).Year + "-" + DateTime.Now.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }

            string[] yr = CmbSession.Text.Split('-');

            dtpFrom.Value = Convert.ToDateTime("01/April/" + yr[0].Trim());
            dtpUpto.Value = Convert.ToDateTime("31/March/" + yr[1].Trim());
            rdb_loc.Checked = false;
            rdb_Co.Checked = true;
            CmbCompany.PopUp();
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                CmbCompany.Text = dta.Rows[0][0].ToString();

                Company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                CmbCompany.ReturnValue = Company_id.ToString();
                CmbCompany.Enabled = false;
            }
            else if (dta.Rows.Count > 1)
            {
                CmbCompany.LookUpTable = dta;
                CmbCompany.ReturnIndex = 1;
             //   CmbCompany.PopUp();
            }
        }

        private void rdb_Co_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Co.Checked == false && rdb_loc.Checked==true)
            {
                btnlog.Enabled = true;
            }
            else if (rdb_Co.Checked == true && rdb_loc.Checked == false)
            {
                btnlog.Enabled = false;
            }
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            string sqlstmnt = "";
            Company_id =Convert.ToInt32(CmbCompany.ReturnValue);
            sqlstmnt = "select l.Location_Name,l.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l ,Companywiseid_Relation r where  l.Location_ID =r.Location_ID and (company_ID='" + Company_id + "')";
            EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Location", "Select Location", 0, "CMPN", 0);
            arr.Clear();
            arr = EDPCommon.arr_mod;
            //lbllog.Items.Clear();
            if (arr.Count > 0)
            {
                getcode.Clear();
                arr = EDPCommon.arr_mod;
                getcode = EDPCommon.get_code;
                //lbllog.Items.Clear();
                Item_Code = "";

                for (int i = 0; i <= (arr.Count - 1); i++)
                {
                    //lbllog.Items.Add(arr[i].ToString());
                    Item_Code = Item_Code + getcode[i].ToString();
                    if (i != getcode.Count - 1)
                    {
                        Item_Code = Item_Code + ",";
                    }
                }
                Locations = Item_Code;
            }
        }

        private void CmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFrom.MaxDate=Convert.ToDateTime("31/12/9998");
            dtpFrom.MinDate = Convert.ToDateTime("01/01/1753");

            dtpUpto.MaxDate = Convert.ToDateTime("31/12/9998");
            dtpUpto.MinDate = Convert.ToDateTime("01/01/1753");

            string[] yr = CmbSession.Text.Split('-');

            dtpFrom.Value = Convert.ToDateTime("01/April/" + yr[0].Trim());
            dtpUpto.Value = Convert.ToDateTime("31/March/" + yr[1].Trim());

            dtpFrom.MaxDate=Convert.ToDateTime("31/March/" + yr[1].Trim());
            dtpFrom.MinDate=Convert.ToDateTime("01/April/" + yr[0].Trim());

            dtpUpto.MaxDate=Convert.ToDateTime("31/March/" + yr[1].Trim());
            dtpUpto.MinDate=Convert.ToDateTime("01/April/" + yr[0].Trim());
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string qry = "", condt_mon = "", condt1 = "", condt2 = "",oCondt="", _inMonths = "", _inMon = "";


            string lst = DateTime.DaysInMonth(dtpUpto.Value.Year, dtpUpto.Value.Month).ToString("00");

            DateTime month = Convert.ToDateTime(dtpFrom.Value.ToString("01/MMMM/yyyy"));
            DateTime monthEnd = Convert.ToDateTime(dtpUpto.Value.ToString(lst+"/MMMM/yyyy"));
            DateTime start = Convert.ToDateTime(dtpFrom.Value.ToString("01/MMMM/yyyy"));
            DateTime end = Convert.ToDateTime(dtpUpto.Value.ToString(lst + "/MMMM/yyyy"));
            double tdays =(monthEnd - month).TotalDays+1;

            month = Convert.ToDateTime(dtpFrom.Value.ToString("15/MMMM/yyyy"));
            monthEnd = Convert.ToDateTime(dtpUpto.Value.ToString("15/MMMM/yyyy"));
            string add = clsDataAccess.ReturnValue("SELECT BRNCH_ADD1 FROM Branch where GCODE ='" + Company_id + "' and BRNCH_CODE='1'");
            //dgvSalary.Columns.Add("eid", "eid");
            //dgvSalary.Columns.Add("ecode", "ecode");
            //dgvSalary.Columns.Add("ename", "Name");
            string[] bhead = txtBonusHead.Text.Trim().ToLower().Split('+');
            
            string bon_Head = "",bon="";

            double bon_Per =0;
            try
            {
                bon_Per = Convert.ToDouble(txtBonus.Text.Trim());
            }
            catch
            {
                bon_Per=8.33;
            }
           
            for (int idx = 0; idx < bhead.Length; idx++)
            {
                if (bon_Head.Trim() == "")
                {
                    bon_Head = "'" + bhead[idx].Trim() + "'";
                }
                else
                {
                    bon_Head = bon_Head+",'" + bhead[idx].Trim() + "'";
                }

            }

                while (month <= monthEnd)
                {
                    if (condt_mon == "")
                    {
                        _inMonths = "'" + month.ToString("M/yyyy") + "'";
                        _inMon = "'" + month.ToString("MMMM") + "'";
                        condt1 = "[" + month.ToString("MMM-yyyy") + "]";
                        condt2 = "[" + month.ToString("MMM-yyyy") + "]";
                        condt_mon = "isNull((select isNull(wday,0) FROM tbl_Employee_Attend where (id=em.ID) and (Company_id=em.Company_id) and ((month)='" + month.ToString("M/yyyy") + "')),0) as '" + month.ToString("MMM-yyyy") + "'";
                    }
                    else
                    {
                        _inMonths = _inMonths + ",'" + month.ToString("M/yyyy") + "'";
                        _inMon = _inMon+ ",'" + month.ToString("MMMM") + "'";
                        condt1 = condt1 + ",[" + month.ToString("MMM-yyyy") + "]";
                        condt2 = condt2 + "+[" + month.ToString("MMM-yyyy") + "]";
                        condt_mon = condt_mon + ",isNull((select isNull(wday,0) FROM tbl_Employee_Attend where (id=em.ID) and (Company_id=em.Company_id) and ((month)='" + month.ToString("M/yyyy") + "')),0) as '" + month.ToString("MMM-yyyy") + "'";
                    }
                    // dgvSalary.Columns.Add(month.ToString("MMM-yyyy"), month.ToString("MMM-yyyy"));
                    month = month.AddMonths(1);
                }
                condt2 = "isNull((select isNull(Sum(wday),0) FROM tbl_Employee_Attend where (id=em.ID) and (Company_id=em.Company_id) and (month in (" + _inMonths + "))),0)";

                condt1 = "select isNull((select SUM(Amount)amt from tbl_Employee_SalaryDet where (TableName='tbl_Employee_ErnSalaryHead') and (SalId in (select Slno from tbl_Employee_ErnSalaryHead where (SalaryHead_Short in (" + bon_Head + ")))) and (EmpId=em.ID) and (Company_id=em.Company_id) and (Session='" + CmbSession.Text.Trim() + "') and (month in (" + _inMon + "))),0)" +
             "+"+
             "isNull((select SUM(Amount)amt from  tbl_Employee_SalaryDet_MultiDesignation where (TableName='tbl_Employee_ErnSalaryHead') and (SalId in (select Slno from tbl_Employee_ErnSalaryHead where (SalaryHead_Short in (" + bon_Head + ")))) and (EmpId=em.ID) and (Company_id=em.Company_id) and (Session='" + CmbSession.Text.Trim() + "') and (month in (" + _inMon + "))),0)";
                if (rdb_loc.Checked == true)
                {
                    oCondt = " where (Location_id in (" + Locations + ")) order by [Location]";
                }
                else
                {

                    oCondt = " order by [Location]";
                }
                bon = "CAST(((" + condt1 + ")*" + bon_Per + "/100) AS numeric(18,0))";
            //ROW_NUMBER() OVER (ORDER BY [Location])
                qry = "select  0 AS Slno,ID as [Employee No]," +
"(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=em.Location_id)+' - '+(select Location_Name from tbl_Emp_Location EL where Location_ID=em.Location_id) as [Location],"+
"(CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ' ' + em.MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ' ' + em.LastName ELSE '' END) AS [Name of the Employee]," +
"(CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN ELSE '' END)  + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN ' ' + em.FathMN ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN ' ' + em.FathLN ELSE '' END) AS [Father's Name]," +
"(case when DATEDIFF(year, em.DateOfBirth, '"+start+"')>=15 then '-' else '' end) as [Whether employee has completed 15 years of age at beginning of the accounting year]," +
"(select d.ShortForm from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)AS 'Designation'," + condt2 + " as [No of days worked],(" + condt1 + ") as [Total Salary or Wages]," + bon + " as [Bonus Amount Payable undersection 10 or section 11 as case may be]," +
"'-' as [Deduction.Puja Bonus or other customary bonus paid during the accounting year],'-' as [Deduction.Interim Bonus or Bonus paid in advance],'-' as [Deduction.Amount of the Income tax deducted],'-' as [Deduction.Deduction on Account of financial loss if any caused by misconduct of the employee],'-' as [Deduction.Total Sum deducted (Col 9,10,11)],'-' as [Deduction.Net amount payable (col 8 minus col 12)],"+
"(" + bon + ") as [Amount actually paid],'' as [Date on whice paid],'                   ' as [Signature / Thumb impression of the Employee]   from tbl_Employee_Mast em " + oCondt;
            dt = clsDataAccess.RunQDTbl(qry);


            if (dt.Rows.Count > 0)
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                int iCol = 0, irw = 0; ;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                iCol = dt.Columns.Count;
                Excel.Borders borders;


                excel.Cells[1, 1] = "FORM C"+Environment.NewLine+"[See rule 4( c )]";
                Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);
                range.Merge(true);
                range.Font.Bold = true;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                //range.RowHeight = 25.00;
                //range.Columns.AutoFit();
                //range.Rows.AutoFit();
                //cmbcompany.Text + Environment.NewLine + co_addr;
                excel.Cells[2, 1] = "Bonus Paid to Employee for the Period "+start.ToString("dd/MM/yyyy")+" - "+ end.ToString("dd/MM/yyyy");
                range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);
                range.Merge(true);
                range.Font.Bold = true;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                excel.Cells[3, 1] = "Name of the Establishment : " ;
                range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, 12]);
                range.Merge(true);
                excel.Cells[3, 13] = "No of working days in the period : "+ tdays;
                range = worksheet.get_Range(worksheet.Cells[3, 13], worksheet.Cells[3, 18]);
                range.Merge(true);
               
                range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;// Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                excel.Cells[4, 1] = " " + CmbCompany.Text.Trim().ToUpper();
                range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, 12]);
                range.Merge(true);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;// Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                excel.Cells[5, 1] = "    " + add;
                range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, 12]);
                range.Merge(true);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;// Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;


                string[] cell_head = new string[] { };
                string old_head = "";
                int ind_st = 0, ind_fin = 0, idx = 0, irx = 0;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    idx++;
                    cell_head = Convert.ToString(dt.Columns[i].ColumnName).Split('.');
                   
                    if (cell_head.Length > 1)
                    {
                        if (old_head == cell_head[0])
                        {
                            ind_fin = idx;
                            try
                            {
                                range = worksheet.get_Range(worksheet.Cells[6, ind_st], worksheet.Cells[6, idx]);
                                range.Merge(Type.Missing);
                                range.Font.Bold = true;
                                range.Font.Size = 8;
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                range = worksheet.get_Range(worksheet.Cells[6, idx], worksheet.Cells[6, idx]);
                                //range.Merge(Type.Missing);
                                range.Font.Bold = true;
                                range.Font.Size = 8;
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                            }
                            catch { }
                            ind_st = idx;
                            excel.Cells[6, idx] = cell_head[0];
                            old_head = cell_head[0];
                        }
                        excel.Cells[7, idx] = cell_head[1];
                        range = worksheet.get_Range(worksheet.Cells[7, idx], worksheet.Cells[7, idx]);
                        range.Font.Bold = true;
                        range.Font.Size = 8;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.WrapText = true;
                    }
                    else if (cell_head.Length > 0)
                    {


                        excel.Cells[6, idx] = dt.Columns[i].ColumnName;
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[6, idx], worksheet.Cells[7, idx]);
                            range.Merge(Type.Missing);
                            range.Font.Bold = true;
                            range.Font.Size = 8;
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                            range.WrapText = true;
                            //range.Width = 75;
                        }
                        catch { }
                    }

                }
                idx = 0;
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    idx++;
                    if (idx == 11)
                    {
                        excel.Cells[8, idx] = "'10 a";
                    }
                    else if (idx > 11)
                    {
                        excel.Cells[8, idx] = idx-1;
                    }
                    else
                    {
                        excel.Cells[8, idx] = idx;
                    }
                }
                range = worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[8, idx]);
                range.Font.Bold = true;
                range.Font.Size = 8;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.WrapText = true;
                idx = 0;
                irx = 8;
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    irx++;
                    idx = 0;
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        idx++;
                        if (idx == 1)
                        {
                            excel.Cells[irx, idx] = r+1;
                        }
                        else
                        {
                            excel.Cells[irx, idx] = dt.Rows[r][c].ToString();
                        }
                    }
                }
                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[irx, iCol]);
                borders = range.Borders;
                borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                borders.Weight = 2d;
                

                object missing = System.Reflection.Missing.Value;

                ((Excel._Worksheet)worksheet).Activate();
                worksheet.UsedRange.Select();

                //worksheet.Columns.AutoFit();

                MessageBox.Show("Export To ExcelCompleted!", "Export");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
