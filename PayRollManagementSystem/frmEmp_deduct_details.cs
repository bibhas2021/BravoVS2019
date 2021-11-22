using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data.SqlClient;
using Edpcom;

namespace PayRollManagementSystem
{
    public partial class frmEmp_deduct_details : Form
    {
        Edpcom.EDPCommon edpcom = new EDPCommon();
        //ArrayList arr = new ArrayList();
        //Hashtable getcode = new Hashtable();
        string Item_Code = "", comp = "", month = "";
        ArrayList arritem = new ArrayList();
        string arrayItem = "";

        Hashtable getcode_Group = new Hashtable();
        Hashtable getcode_item = new Hashtable();

        DataTable dt = new DataTable();
        DataTable dtc = new DataTable();
        int company_id = 0, Location_id = 0;


        public frmEmp_deduct_details()
        {
            InitializeComponent();
        }

        private void frmEmp_deduct_details_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
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

            AttenDtTmPkr.Value = DateAndTime.Now;


            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                CmbCompany.Text = dta.Rows[0][0].ToString();

                company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                CmbCompany.ReturnValue = company_id.ToString();

            }
            else if (dta.Rows.Count > 1)
            {
                CmbCompany.PopUp();
            }


            this.WindowState = FormWindowState.Maximized;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            string cond = "";
            try
            {
                //string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

                //string sqlstmnt = "Select  ( e.Title+' '+e.FirstName+' '+e.MiddleName+' '+ e.LastName )as'EmpName',ID from tbl_Employee_Mast where Company_id='" + company_id + "' and Session ='" + cmbYear.Text + "' "; //and s.Location_id= '" + get_LocationID(cmbsalstruc.Text) + "'
                //sqlstmnt = sqlstmnt + " AND s.emp_id IN ( select emp_id from tbl_Employee_SalaryMast group by emp_id,month having COUNT(*)>1 ) ";
                if (radioButton1.Checked == true)
                {
                    cond = "WHERE em.Company_id = '" + company_id + "' ORDER BY ID";
                }
                else if (radioButton2.Checked == true)
                {
                    cond = "WHERE em.Location_id= '" + Location_id+ "' ORDER BY ID";
                }

                    string sqlstmnt = ("SELECT   ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
                  "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName , em.ID,em.Company_id FROM tbl_Employee_Mast em "+cond);
                
                EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Employee", "Select Employee", 0, "CMPN", 0);

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
                        Item_Code = Item_Code + "," + "'" + getcode_item[i].ToString() + "'";

                    }

                }
            }
            catch { }

        }

        //public void Load_Data1(string qry, ComboBox cb, int i)
        //{

        //    DataTable dt = new DataTable();
        //    dt.Clear();
        //    dt = clsDataAccess.RunQDTbl(qry);
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int d = 0; d < dt.Rows.Count; d++)
        //        {
        //            cb.Items.Add(dt.Rows[d][0].ToString());
        //        }
        //        if (i >= 0)
        //            cb.SelectedIndex = i;
        //    }
        //}
        //public int get_CompID(string name)
        //{

        //    DataTable dt = new DataTable();
        //    dt.Clear();
        //    string s = " select GCODE  from Company where CO_Name='" + name + "'";
        //    dt = clsDataAccess.RunQDTbl(s);
        //    return Convert.ToInt32(dt.Rows[0][0]);
        //}

        //comp = clsDataAccess.GetresultS("Select CO_NAME from Company where CO_CODE ='" + company_id+"'");
        //month = AttenDtTmPkr.Value.ToString("MMMM/yyyy");

        //MidasReport.Form1 edd = new MidasReport.Form1();
        //edd.empdeddetail(comp,month,dt);
        //edd.Show();



        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            
            if (edpcom.CurrentLocation.Trim() != "")
            {

                dtc = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dtc = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            }
            
           
            
            
            if (dtc.Rows.Count > 0)
            {
                CmbCompany.LookUpTable = dtc;
                CmbCompany.ReturnIndex = 1;

            }
            
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                company_id = Convert.ToInt32(CmbCompany.ReturnValue);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            get_data();
        }
        public void get_data()
        {
            if (Item_Code != "")
            {
                
                string qry = "", my = "";
                int idx = 0;

                //qry=" select em.ID as ID,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END)+(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EMPName "+
                //"(select Location_Name from tbl_Emp_Location where Location_ID=em.Location_id)as 'location', "+
                //"isnull((select EADEDUCT from  tbl_Employee_Advance where EAEID=em.ID and EAMONTH ='" + AttenDtTmPkr.Value.ToString("MMMM") + "/ " + AttenDtTmPkr.Value.Year + "'),0) as AdvanceDeductAmount," +
                //"(select (case when EADEDUCT=0 then isnull((EADEDUCTDT),'')else  EADEDUCTDT end) from  tbl_Employee_Advance where EAEID=em.ID and EAMONTH ='"+ AttenDtTmPkr.Value.ToString("MMMM") + "/ " + AttenDtTmPkr.Value.Year +"')as'AdvanceDeductDate',"+
                //"isnull((select EAAMT from tbl_Employee_Advance where EAEID=em.ID and EAMONTH ='" + AttenDtTmPkr.Value.ToString("MMMM") + "/ " + AttenDtTmPkr.Value.Year + "'),0) as 'AdvanceAmount'," +
                //"(SELECT CONVERT(VARCHAR(10), EADT, 101) AS [DD/MM/YYYY] from tbl_Employee_Advance where EAEID=em.ID and EAMONTH ='" + AttenDtTmPkr.Value.ToString("MMMM") + "/ " + AttenDtTmPkr.Value.Year + "') as AdvanceDate," +
                //"isnull((select ELAMT from tbl_Employee_LOAN where ELEID=em.ID and ELMONTH ='" + AttenDtTmPkr.Value.ToString("MMMM") + "/ " + AttenDtTmPkr.Value.Year + "'),0) as 'loanAmount'," +
                //"(SELECT CONVERT(VARCHAR(10), ELDT, 101) AS [DD/MM/YYYY]from tbl_Employee_LOAN where ELEID=em.ID and  ELMONTH ='" + AttenDtTmPkr.Value.ToString("MMMM") + "/ " + AttenDtTmPkr.Value.Year + "') as loanDate," +
                //"isnull((select EKAMT from tbl_Employee_KIT where EKEID=em.ID and  EKMONTH ='" + AttenDtTmPkr.Value.ToString("MMMM") + "/ " + AttenDtTmPkr.Value.Year + "'),0) as'kitAmt'," +
                //"(SELECT CONVERT(VARCHAR(10), EKDT, 101) AS [DD/MM/YYYY]from tbl_Employee_KIT where EKEID=em.ID and EKMONTH ='" + AttenDtTmPkr.Value.ToString("MMMM") + "/ " + AttenDtTmPkr.Value.Year + "')as kitDate," +
                //"isnull((select FAMT from tbl_fine_log where eid=em.ID and FMONTH ='" + AttenDtTmPkr.Value.ToString("MMMM") + "/ " + AttenDtTmPkr.Value.Year + "'),0) as 'fineAmt'," +
                //"(select CONVERT(VARCHAR(10),FDT , 101) AS [DD/MM/YYYY]from tbl_fine_log where eid=em.ID and FMONTH ='" + AttenDtTmPkr.Value.ToString("MMMM") + "/ " + AttenDtTmPkr.Value.Year + "')as fineDate,  " +
                //"isnull((select soc_amt from society where eid=em.ID),0) as 'SocietyAmt'" +
                //"from tbl_Employee_Mast em where  em.Company_id='"+ company_id+"' and Session='"+cmbYear.Text+"'and em.ID in("+Item_Code+")";


                //DataTable dt_em = clsDataAccess.RunQDTbl("select em.ID as ID,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END)+(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EMPName, " +
                //    "'' as Month,'' as ADV_DT,'' as ADV_AMT,'' as ADV_DedDT,'' as ADV_DedAMT,'' as ADV_OS,'' as L_DT,'' as L_AMT,'' as L_DedDT,'' as L_DedAMT, " +
                //    "'' as K_DT,'' as K_AMT,'' as K_DedDT,'' as K_DedAMT,'' as F_DT,'' as F_AMT,'' as F_DedDT,'' as F_DedAMT " +
                //    "from tbl_Employee_Mast em where  em.Company_id='" + company_id + "' and Session='" + cmbYear.Text + "'and em.ID in(" + Item_Code + ")");


                DataTable dt_em = clsDataAccess.RunQDTbl("select '' as ID,'' AS EMPName, " +
                   "'' as Month,'' as ADV_DT,'' as ADV_AMT,'' as ADV_DedDT,'' as ADV_DedAMT,'' as ADV_OS,'' as L_DT,'' as L_AMT,'' as L_DedDT,'' as L_DedAMT, " +
                   "'' as K_DT,'' as K_AMT,'' as K_DedDT,'' as K_DedAMT,'' as F_DT,'' as F_AMT,'' as F_DedDT,'' as F_DedAMT " );
                   //"from tbl_Employee_Mast em where  em.Company_id='" + company_id + "' and Session='" + cmbYear.Text + "'and em.ID in(" + Item_Code + ")");

                //while (idx < dt_em.Rows.Count)
                // {

                string[] yr = cmbYear.Text.Split('-');
                string[] mon = ("April|May|June|July|August|September|October|November|December|January|February|March").Split('|');

                for (int idc = 0; idc < mon.Length; idc++)
                {
                    if (idc >= 9)
                        my = mon[idc].Trim() + "/" + " " + yr[1].Trim();
                    else
                        my = mon[idc].Trim() + "/" + " " + yr[0].Trim();



                    qry = "select * from (select em.ID as ID,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END)+(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EMPName, " +
                    "isnull((select cast(convert(char(11), EADT, 103) as VARCHAR) from tbl_Employee_Advance where EADEDUCT=0 and EAEID=em.ID and  EAMONTH ='" + my + "' ),'')as ADV_DT," +
                    "isnull((select EAAMT from tbl_Employee_Advance where EADEDUCT=0 and EAEID=em.ID and EAMONTH ='" + my + "' ),0)as ADV_AMT, " +
                    "isnull((select cast(convert(char(11), EADEDUCTDT, 103) as VARCHAR) from tbl_Employee_Advance where EAAMT=0 and EAEID=em.ID and  EAMONTH ='" + my + "' ),'')as ADV_DedDT," +
                    " isnull((select EADEDUCT from tbl_Employee_Advance where EAAMT=0 and EAEID=em.ID and EAMONTH ='" + my + "' ),0)as ADV_DedAMT," +
                    "ISNULL ((select sum(EAAMT - EADEDUCT) FROM tbl_Employee_Advance WHERE EAEID = em.ID and EAMONTH ='" + my + "'),0)AS ADV_OS," +

                    "isnull((SELECT cast(convert(char(11), ELDT, 103) as VARCHAR)from tbl_Employee_LOAN where ELEID=em.ID and  ELMONTH ='" + my + "'),'') as 'L_DT'," +
                    "isnull((select ELAMT from tbl_Employee_LOAN where ELEID=em.ID and ELMONTH ='" + my + "'),0) as 'L_AMT'," +
                    "isnull((select cast(convert(char(11), ELDEDUCTDT, 103) as VARCHAR) from tbl_Employee_LOAN  where ELEID=em.ID and  ELMONTH ='" + my + "' ),'')as 'L_DedDT'," +
                    "isnull((select ELDEDUCT from tbl_Employee_LOAN where  ELEID=em.ID and ELMONTH ='" + my + "' ),0)as 'L_DedAMT'," +

                    "isnull((SELECT cast(convert(char(11), EKDT, 103) as VARCHAR)from tbl_Employee_KIT where EKEID=em.ID and EKMONTH ='" + my + "'),'')as 'K_DT'," +
                    "isnull((select EKAMT from tbl_Employee_KIT where EKEID=em.ID and  EKMONTH ='" + my + "'),0) as'K_AMT'," +
                    "isnull((SELECT cast(convert(char(11), EKDEDUCTDT, 103) as VARCHAR)from tbl_Employee_KIT where EKEID=em.ID and EKMONTH ='" + my + "'),'')as 'K_DedDT'," +
                    "isnull((select EKDEDUCT from tbl_Employee_KIT where EKEID=em.ID and  EKMONTH ='" + my + "'),0) as'K_DedAMT'," +

                    "isnull((select cast(convert(char(11), FDT, 103) as VARCHAR)from tbl_fine_log where eid=em.ID and FMONTH ='" + my + "'),'')as 'F_DT'," +
                    "isnull((select FAMT from tbl_fine_log where eid=em.ID and FMONTH ='" + my + "'),0) as 'F_Amt'," +
                    "isnull((SELECT cast(convert(char(11), FDT, 103) as VARCHAR)from tbl_fine_log where EID=em.ID and FMONTH ='" + my + "'),'')as 'F_DedDT'," +
                    "isnull((select FDEDUCT from tbl_fine_log where EID=em.ID and  FMONTH ='" + my + "'),0) as'F_DedAMT','" + my + "'as'Month'" +

                    "from tbl_Employee_Mast em where  em.Company_id='" + company_id + "' and Session='" + cmbYear.Text + "'and em.ID in(" + Item_Code + ")) E where (adv_amt!=0) or  (L_AMT!=0) or (K_AMT!=0) or (F_Amt!=0)";

                    dt = clsDataAccess.RunQDTbl(qry);
                    DataView dv = new DataView(dt);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        dv.RowFilter = "ID = '" + dt.Rows[j]["ID"] + "'";
                        //if (dt.Rows[j]["ID"] == dv[0]["ID"])
                        //{
                            dt_em.Rows[idx]["ID"] = dv[0]["ID"];
                            dt_em.Rows[idx]["EMPName"] = dv[0]["EMPName"];
                            dt_em.Rows[idx]["Month"] = dv[0]["Month"];
                            dt_em.Rows[idx]["ADV_DT"] = dv[0]["ADV_DT"];
                            dt_em.Rows[idx]["ADV_AMT"] = dv[0]["ADV_AMT"];
                            dt_em.Rows[idx]["ADV_DedDT"] = dv[0]["ADV_DedDT"];
                            dt_em.Rows[idx]["ADV_DedAMT"] = dv[0]["ADV_DedAMT"];
                            dt_em.Rows[idx]["ADV_OS"] = dv[0]["ADV_OS"];

                            dt_em.Rows[idx]["L_DT"] = dv[0]["L_DT"];
                            dt_em.Rows[idx]["L_AMT"] = dv[0]["L_AMT"];
                            dt_em.Rows[idx]["L_DedDT"] = dv[0]["L_DedDT"];
                            dt_em.Rows[idx]["L_DedAMT"] = dv[0]["L_DedAMT"];

                            dt_em.Rows[idx]["K_DT"] = dv[0]["K_DT"];
                            dt_em.Rows[idx]["K_AMT"] = dv[0]["K_AMT"];
                            dt_em.Rows[idx]["K_DedDT"] = dv[0]["K_DedDT"];
                            dt_em.Rows[idx]["K_DedAMT"] = dv[0]["K_DT"];

                            dt_em.Rows[idx]["F_DT"] = dv[0]["F_DT"];
                            dt_em.Rows[idx]["F_AMT"] = dv[0]["F_AMT"];
                            dt_em.Rows[idx]["F_DedDT"] = dv[0]["F_DedDT"];
                            dt_em.Rows[idx]["F_DedAMT"] = dv[0]["F_DedAMT"];


                            dt_em.Rows.Add();
                            idx++;
                        //}

                    }
                    if (dt.Rows.Count != 0)
                    {
                        dt_em.Rows.Add();
                        idx++;
                    }


                }
                dgv_show.DataSource = dt_em;
                dgv_show.Columns[0].Width = 45;
                dgv_show.Columns[1].Width = 200;
                dgv_show.Columns[2].Width = 100;
                dgv_show.Columns[3].Width = 77;
                dgv_show.Columns[4].Width = 77;
                dgv_show.Columns[5].Width = 77;
                dgv_show.Columns[6].Width = 77;
                dgv_show.Columns[7].Width = 77;
                dgv_show.Columns[8].Width = 77;
                dgv_show.Columns[9].Width = 77;
                dgv_show.Columns[10].Width = 77;
                dgv_show.Columns[11].Width = 77;
                dgv_show.Columns[12].Width = 77;
                dgv_show.Columns[13].Width = 77;
                dgv_show.Columns[14].Width = 77;
                dgv_show.Columns[15].Width = 77;
                dgv_show.Columns[16].Width = 77;
                dgv_show.Columns[17].Width = 77;
                dgv_show.Columns[18].Width = 77;
                dgv_show.Columns[19].Width = 77;

                dgv_show.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_show.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_show.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_show.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_show.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_show.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_show.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_show.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_show.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_show.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_show.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_show.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_show.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_show.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_show.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_show.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_show.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_show.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_show.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_show.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgv_show.Columns["ID"].Frozen = true;
                dgv_show.Columns["EMPName"].Frozen = true;
                //idx++;
                //}
            }
            else
            { MessageBox.Show("Please select Employee"); }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            get_data();
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 0, irw = 0; ;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            iCol = dgv_show.Columns.Count;


            excel.Cells[1, 1] = CmbCompany.Text;
            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);

            range.Merge(true);
            range.Font.Bold = true;


            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.RowHeight = 25.00;
            //range.Columns.AutoFit();
            //range.Rows.AutoFit();


            excel.Cells[2, 1] = "Employee Deduct details";

            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 3]);
            range.Merge(true);
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            //excel.Cells[2, 4] = AttenDtTmPkr.Value.ToString("MMMM yyyy") + Environment.NewLine + "Date of Payment : ";

            range = worksheet.get_Range(worksheet.Cells[2, 4], worksheet.Cells[2, 6]);
            range.Merge(true);
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;


            //excel.Cells[2, 7] = "Unit : " + cmbLocation.Text + Environment.NewLine + "Address " + clAddress;

            range = worksheet.get_Range(worksheet.Cells[2, 7], worksheet.Cells[2, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;


            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);

            range.Columns.AutoFit();
            //  range.Rows.AutoFit();
            range.RowHeight = 55.00;

            excel.Cells[3, 1] = "";
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
            range.Merge(true);
            range.Columns.AutoFit();
            range.Rows.AutoFit();
            string[] cell_head = new string[] { };
            string old_head = "";
            int ind_st = 0, ind_fin = 0;

            for (int i = 1; i <= dgv_show.Columns.Count; i++)
            {
                cell_head = Convert.ToString(dgv_show.Columns[i - 1].HeaderText).Split('.');
                if (cell_head.Length > 1)
                {
                    if (old_head == cell_head[0])
                    {
                        ind_fin = i;
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
                            range.Merge(Type.Missing);
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
                            range.Merge(Type.Missing);
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
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


                    excel.Cells[4, i] = dgv_show.Columns[i - 1].HeaderText;
                    try
                    {
                        range = worksheet.get_Range(worksheet.Cells[4, i], worksheet.Cells[5, i]);
                        range.Merge(Type.Missing);
                        range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    }
                    catch { }
                }

            }

            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
            range.Font.Bold = true;
            DateTime MyDate;
            for (int i = 0; i < dgv_show.Rows.Count; i++)
            {
                for (int j = 1; j <= dgv_show.Columns.Count; j++)
                {
                    try
                    {
                        irw = i + 6;
                        if (j != 20 || j != 22)
                        {
                            range = worksheet.get_Range(worksheet.Cells[i + 6, j], worksheet.Cells[i + 6, j]);
                            range.NumberFormat = "@";
                        }
                        if (!DateTime.TryParse(dgv_show.Rows[i].Cells[j - 1].Value.ToString(), out MyDate))
                        {
                            excel.Cells[i + 6, j] = dgv_show.Rows[i].Cells[j - 1].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 6, j] = "'" + dgv_show.Rows[i].Cells[j - 1].Value.ToString();
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
            // range.WrapText = true;

            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();

            //((Excel._Application)excel).Save();

            MessageBox.Show("Export To Excel Completed!", "Export");

        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButton2.Checked == true)
            //{
            //    CmbCompany.Text = "";
            //    LblCompany.Text = "Location";
            //}
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
             string s = "select l.Location_Name,l.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l ,Companywiseid_Relation r where  l.Location_ID =r.Location_ID and (company_ID='" + company_id + "')";
            DataTable dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;

            }
       
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                Location_id = Convert.ToInt32(cmbLocation.ReturnValue);
        
        } 
        
    }
}
