using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frm_Register_FrmD : Form
    {
        public frm_Register_FrmD()
        {
            InitializeComponent();
        }
        int Company_id=0, Location_id = 0;
        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            if (dt.Rows.Count > 1)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                CmbCompany.Text = dt.Rows[0]["Co_Name"].ToString();
                Company_id = Convert.ToInt32(dt.Rows[0]["CO_CODE"].ToString());
            }
            
        }

        private void CmbCompany_DropDown_Closeup(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(CmbCompany.ReturnValue);
        }

        private void CmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("Select EL.Location_Name,EL.Location_ID from tbl_Emp_Location EL,Companywiseid_Relation cr where cr.Location_ID=EL.Location_ID and  cr.Company_ID='" + Company_id + "'");
            if (dt.Rows.Count > 1)
            {
                CmbLocation.LookUpTable = dt;
                CmbLocation.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                CmbLocation.Text = dt.Rows[0]["Location_Name"].ToString();
                Location_id = Convert.ToInt32(dt.Rows[0]["Location_ID"].ToString());
            }
        }

        private void CmbLocation_DropDown_Closeup(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbLocation.ReturnValue) == true)
                Location_id = Convert.ToInt32(CmbLocation.ReturnValue);

            dateTimePicker1_ValueChanged(sender, e);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            if (lbl_nodays.Text == "31")
            {
                dt = clsDataAccess.RunQDTbl("select (select CO_NAME from Company where GCODE=ea.Company_id)as 'Company',(select LIN FROM Branch where GCODE=ea.Company_id and BRNCH_CODE=1)as 'LIN', " +
"(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=ea.Location_ID)+' - '+(select Location_Name from tbl_Emp_Location EL where Location_ID=ea.Location_ID) as 'location', " +
"'" + AttenDtTmPkr.Value.ToString("01/MM/yyyy") + " - " + lbl_EndDate.Text.Trim() + "' as 'Period','" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "' as 'month',ID as 'Sl No in Employee Register', " +
"((SELECT (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS ename FROM tbl_Employee_Mast WHERE (ID = ea.ID)))as 'Name','' as 'Relay# or set work','' as 'Place of Work*', " +
"''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("01/MMM/yyyy")).ToString("dddd")) + ".01',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("02/MMM/yyyy")).ToString("dddd")) + ".02',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("03/MMM/yyyy")).ToString("dddd")) + ".03',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("04/MMM/yyyy")).ToString("dddd")) + ".04',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("05/MMM/yyyy")).ToString("dddd")) + ".05',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("06/MMM/yyyy")).ToString("dddd")) + ".06',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("07/MMM/yyyy")).ToString("dddd")) + ".07',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("08/MMM/yyyy")).ToString("dddd")) + ".08',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("09/MMM/yyyy")).ToString("dddd")) + ".09',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("10/MMM/yyyy")).ToString("dddd")) + ".10'," +
"''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("11/MMM/yyyy")).ToString("dddd")) + ".11',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("12/MMM/yyyy")).ToString("dddd")) + ".12',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("13/MMM/yyyy")).ToString("dddd")) + ".13',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("14/MMM/yyyy")).ToString("dddd")) + ".14',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("15/MMM/yyyy")).ToString("dddd")) + ".15',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("16/MMM/yyyy")).ToString("dddd")) + ".16',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("17/MMM/yyyy")).ToString("dddd")) + ".17',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("18/MMM/yyyy")).ToString("dddd")) + ".18',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("19/MMM/yyyy")).ToString("dddd")) + ".19',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("20/MMM/yyyy")).ToString("dddd")) + ".20'," +
"''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("21/MMM/yyyy")).ToString("dddd")) + ".21',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("22/MMM/yyyy")).ToString("dddd")) + ".22',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("23/MMM/yyyy")).ToString("dddd")) + ".23',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("24/MMM/yyyy")).ToString("dddd")) + ".24',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("25/MMM/yyyy")).ToString("dddd")) + ".25',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("26/MMM/yyyy")).ToString("dddd")) + ".26',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("27/MMM/yyyy")).ToString("dddd")) + ".27',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("28/MMM/yyyy")).ToString("dddd")) + ".28',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("29/MMM/yyyy")).ToString("dddd")) + ".29',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("30/MMM/yyyy")).ToString("dddd")) + ".30',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("31/MMM/yyyy")).ToString("dddd")) + ".31', " +
"Wday as 'Summary No of Days','' as 'Remarks No of Hours', '' as '**Signature of Register Keeper' " +
"from tbl_Employee_Attend ea where (MONTH='"+AttenDtTmPkr.Value.ToString("M/yyyy")+"') and (Location_ID='"+Location_id+"') order by 'Name'");
            }
            else if (lbl_nodays.Text == "30")
            {
                dt = clsDataAccess.RunQDTbl("select (select CO_NAME from Company where GCODE=ea.Company_id)as 'Company',(select LIN FROM Branch where GCODE=ea.Company_id and BRNCH_CODE=1)as 'LIN', " +
"(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=ea.Location_ID)+' - '+(select Location_Name from tbl_Emp_Location EL where Location_ID=ea.Location_ID) as 'location', " +
"'" + AttenDtTmPkr.Value.ToString("01/MM/yyyy") + " - " + lbl_EndDate.Text.Trim() + "' as 'Period','" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "' as 'month',ID as 'Sl No in Employee Register', " +
"((SELECT (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS ename FROM tbl_Employee_Mast WHERE (ID = ea.ID)))as 'Name','' as 'Relay# or set work','' as 'Place of Work*', " +
"''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("01/MMM/yyyy")).ToString("dddd")) + ".01',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("02/MMM/yyyy")).ToString("dddd")) + ".02',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("03/MMM/yyyy")).ToString("dddd")) + ".03',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("04/MMM/yyyy")).ToString("dddd")) + ".04',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("05/MMM/yyyy")).ToString("dddd")) + ".05',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("06/MMM/yyyy")).ToString("dddd")) + ".06',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("07/MMM/yyyy")).ToString("dddd")) + ".07',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("08/MMM/yyyy")).ToString("dddd")) + ".08',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("09/MMM/yyyy")).ToString("dddd")) + ".09',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("10/MMM/yyyy")).ToString("dddd")) + ".10'," +
"''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("11/MMM/yyyy")).ToString("dddd")) + ".11',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("12/MMM/yyyy")).ToString("dddd")) + ".12',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("13/MMM/yyyy")).ToString("dddd")) + ".13',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("14/MMM/yyyy")).ToString("dddd")) + ".14',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("15/MMM/yyyy")).ToString("dddd")) + ".15',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("16/MMM/yyyy")).ToString("dddd")) + ".16',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("17/MMM/yyyy")).ToString("dddd")) + ".17',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("18/MMM/yyyy")).ToString("dddd")) + ".18',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("19/MMM/yyyy")).ToString("dddd")) + ".19',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("20/MMM/yyyy")).ToString("dddd")) + ".20'," +
"''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("21/MMM/yyyy")).ToString("dddd")) + ".21',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("22/MMM/yyyy")).ToString("dddd")) + ".22',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("23/MMM/yyyy")).ToString("dddd")) + ".23',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("24/MMM/yyyy")).ToString("dddd")) + ".24',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("25/MMM/yyyy")).ToString("dddd")) + ".25',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("26/MMM/yyyy")).ToString("dddd")) + ".26',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("27/MMM/yyyy")).ToString("dddd")) + ".27',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("28/MMM/yyyy")).ToString("dddd")) + ".28',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("29/MMM/yyyy")).ToString("dddd")) + ".29',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("30/MMM/yyyy")).ToString("dddd")) + ".30'," +
"Wday as 'Summary No of Days','' as 'Remarks No of Hours', '' as '**Signature of Register Keeper' " +
"from tbl_Employee_Attend ea where (MONTH='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') and (Location_ID='" + Location_id + "') order by 'Name'");
            }
            else if (lbl_nodays.Text == "28")
            {
                dt = clsDataAccess.RunQDTbl("select (select CO_NAME from Company where GCODE=ea.Company_id)as 'Company',(select LIN FROM Branch where GCODE=ea.Company_id and BRNCH_CODE=1)as 'LIN', " +
"(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=ea.Location_ID)+' - '+(select Location_Name from tbl_Emp_Location EL where Location_ID=ea.Location_ID) as 'location', " +
"'" + AttenDtTmPkr.Value.ToString("01/MM/yyyy") + " - " + lbl_EndDate.Text.Trim() + "' as 'Period','" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "' as 'month',ID as 'Sl No in Employee Register', " +
"((SELECT (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS ename FROM tbl_Employee_Mast WHERE (ID = ea.ID)))as 'Name','' as 'Relay# or set work','' as 'Place of Work*'," +
"''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("01/MMM/yyyy")).ToString("dddd")) + ".01',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("02/MMM/yyyy")).ToString("dddd")) + ".02',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("03/MMM/yyyy")).ToString("dddd")) + ".03',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("04/MMM/yyyy")).ToString("dddd")) + ".04',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("05/MMM/yyyy")).ToString("dddd")) + ".05',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("06/MMM/yyyy")).ToString("dddd")) + ".06',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("07/MMM/yyyy")).ToString("dddd")) + ".07',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("08/MMM/yyyy")).ToString("dddd")) + ".08',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("09/MMM/yyyy")).ToString("dddd")) + ".09',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("10/MMM/yyyy")).ToString("dddd")) + ".10'," +
"''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("11/MMM/yyyy")).ToString("dddd")) + ".11',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("12/MMM/yyyy")).ToString("dddd")) + ".12',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("13/MMM/yyyy")).ToString("dddd")) + ".13',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("14/MMM/yyyy")).ToString("dddd")) + ".14',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("15/MMM/yyyy")).ToString("dddd")) + ".15',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("16/MMM/yyyy")).ToString("dddd")) + ".16',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("17/MMM/yyyy")).ToString("dddd")) + ".17',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("18/MMM/yyyy")).ToString("dddd")) + ".18',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("19/MMM/yyyy")).ToString("dddd")) + ".19',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("20/MMM/yyyy")).ToString("dddd")) + ".20'," +
"''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("21/MMM/yyyy")).ToString("dddd")) + ".21',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("22/MMM/yyyy")).ToString("dddd")) + ".22',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("23/MMM/yyyy")).ToString("dddd")) + ".23',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("24/MMM/yyyy")).ToString("dddd")) + ".24',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("25/MMM/yyyy")).ToString("dddd")) + ".25',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("26/MMM/yyyy")).ToString("dddd")) + ".26',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("27/MMM/yyyy")).ToString("dddd")) + ".27',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("28/MMM/yyyy")).ToString("dddd")) + ".28',Wday as 'Summary No of Days','' as 'Remarks No of Hours', '' as '**Signature of Register Keeper' "+
"from tbl_Employee_Attend ea where (MONTH='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') and (Location_ID='" + Location_id + "') order by 'Name'");
            }
            else if (lbl_nodays.Text == "29")
            {
                dt = clsDataAccess.RunQDTbl("select (select CO_NAME from Company where GCODE=ea.Company_id)as 'Company',(select LIN FROM Branch where GCODE=ea.Company_id and BRNCH_CODE=1)as 'LIN', " +
"(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=ea.Location_ID)+' - '+(select Location_Name from tbl_Emp_Location EL where Location_ID=ea.Location_ID) as 'location', " +
"'" + AttenDtTmPkr.Value.ToString("01/MM/yyyy") + " - " + lbl_EndDate.Text.Trim() + "' as 'Period','" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "' as 'month',ID as 'Sl No in Employee Register', " +
"((SELECT (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS ename FROM tbl_Employee_Mast WHERE (ID = ea.ID)))as 'Name','' as 'Relay# or set work','' as 'Place of Work*'," +
"''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("01/MMM/yyyy")).ToString("dddd")) + ".01',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("02/MMM/yyyy")).ToString("dddd")) + ".02',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("03/MMM/yyyy")).ToString("dddd")) + ".03',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("04/MMM/yyyy")).ToString("dddd")) + ".04',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("05/MMM/yyyy")).ToString("dddd")) + ".05',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("06/MMM/yyyy")).ToString("dddd")) + ".06',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("07/MMM/yyyy")).ToString("dddd")) + ".07',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("08/MMM/yyyy")).ToString("dddd")) + ".08',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("09/MMM/yyyy")).ToString("dddd")) + ".09',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("10/MMM/yyyy")).ToString("dddd")) + ".10'," +
"''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("11/MMM/yyyy")).ToString("dddd")) + ".11',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("12/MMM/yyyy")).ToString("dddd")) + ".12',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("13/MMM/yyyy")).ToString("dddd")) + ".13',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("14/MMM/yyyy")).ToString("dddd")) + ".14',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("15/MMM/yyyy")).ToString("dddd")) + ".15',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("16/MMM/yyyy")).ToString("dddd")) + ".16',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("17/MMM/yyyy")).ToString("dddd")) + ".17',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("18/MMM/yyyy")).ToString("dddd")) + ".18',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("19/MMM/yyyy")).ToString("dddd")) + ".19',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("20/MMM/yyyy")).ToString("dddd")) + ".20'," +
"''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("21/MMM/yyyy")).ToString("dddd")) + ".21',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("22/MMM/yyyy")).ToString("dddd")) + ".22',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("23/MMM/yyyy")).ToString("dddd")) + ".23',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("24/MMM/yyyy")).ToString("dddd")) + ".24',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("25/MMM/yyyy")).ToString("dddd")) + ".25',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("26/MMM/yyyy")).ToString("dddd")) + ".26',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("27/MMM/yyyy")).ToString("dddd")) + ".27',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("28/MMM/yyyy")).ToString("dddd")) + ".28',''as '" + (Convert.ToDateTime(AttenDtTmPkr.Value.ToString("29/MMM/yyyy")).ToString("dddd")) + ".29'," +
"Wday as 'Summary No of Days','' as 'Remarks No of Hours', '' as '**Signature of Register Keeper' " +
"from tbl_Employee_Attend ea where (MONTH='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') and (Location_ID='" + Location_id + "') order by 'Name'");
            }


            if (dt.Rows.Count > 0)
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                int iCol = 0, irw = 0; ;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                iCol = dt.Columns.Count-5;
                Excel.Borders borders;


                excel.Cells[1, 1] = "FORM D";
                Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);
                range.Merge(true);
                range.Font.Bold = true;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                //range.RowHeight = 25.00;
                //range.Columns.AutoFit();
                //range.Rows.AutoFit();
                //cmbcompany.Text + Environment.NewLine + co_addr;
                excel.Cells[2, 1] = "FORMAT OF ATTENDANCE REGISTER";
                range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);
                range.Merge(true);
                range.Font.Bold = true;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                excel.Cells[3, 1] = "Name of the Establishment : "+ CmbCompany.Text.Trim();
                range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, 12]);
                range.Merge(true);
                excel.Cells[3, 13] = "Name of Owner ________________________";
                range = worksheet.get_Range(worksheet.Cells[3, 13], worksheet.Cells[3, 18]);
                range.Merge(true);
                excel.Cells[3, 19] = "LIN " + dt.Rows[0]["LIN"].ToString();
                range = worksheet.get_Range(worksheet.Cells[3, 19], worksheet.Cells[3, 22]);
                range.Merge(true);
                excel.Cells[3, 23] = "Location : " + dt.Rows[0]["location"].ToString();
                range = worksheet.get_Range(worksheet.Cells[3, 23], worksheet.Cells[3, iCol]);
                range.Merge(true);
                //range.Font.Bold = true;
                range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;// Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                excel.Cells[4, 1] = "For the period : " + dt.Rows[0]["Period"].ToString(); 
                range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, iCol]);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;// Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                excel.Cells[5, 1] = "    " + AttenDtTmPkr.Value.ToString("MMMM - yyyy");
                range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;// Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;


                string[] cell_head = new string[] { };
                string old_head = "";
                int ind_st = 0, ind_fin = 0,idx=0,irx=0;
                for (int i = 5; i < dt.Columns.Count; i++)
                {
                    idx++;
                    cell_head = Convert.ToString(dt.Columns[i].ColumnName).Split('.');
                    if (i == 9)
                    {
                        excel.Cells[6, idx] = "Date";
                        range = worksheet.get_Range(worksheet.Cells[6, idx], worksheet.Cells[6, iCol - 3]);
                        range.Merge(Type.Missing);
                        range.Font.Bold = true;
                        range.Font.Size = 8;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        excel.Cells[7, idx] = "IN";
                        range = worksheet.get_Range(worksheet.Cells[7, idx], worksheet.Cells[7, iCol - 3]);
                        range.Merge(Type.Missing);
                        range.Font.Bold = true;
                        range.Font.Size = 8;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                        excel.Cells[8, idx] = "OUT";
                        range = worksheet.get_Range(worksheet.Cells[8, idx], worksheet.Cells[8, iCol - 3]);
                        range.Merge(Type.Missing);
                        range.Font.Bold = true;
                        range.Font.Size = 8;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                    }
                    if (cell_head.Length > 1)
                    {
                        if (old_head == cell_head[0])
                        {
                            ind_fin = idx;
                            try
                            {
                                range = worksheet.get_Range(worksheet.Cells[9, idx], worksheet.Cells[9, idx]);
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
                                range = worksheet.get_Range(worksheet.Cells[9, idx], worksheet.Cells[9, idx]);
                                //range.Merge(Type.Missing);
                                range.Font.Bold = true;
                                range.Font.Size = 8;
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                            }
                            catch { }
                            ind_st = i;
                            excel.Cells[9, idx] = cell_head[0];
                            old_head = cell_head[0];
                        }
                        excel.Cells[10, idx] = cell_head[1];
                    }
                    else if (cell_head.Length > 0)
                    {


                        excel.Cells[6, idx] = dt.Columns[i].ColumnName;
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[6, idx], worksheet.Cells[10, idx]);
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

                idx=0;
                irx = 10;
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    irx++;
                    idx = 0;
                    for (int c = 5; c < dt.Columns.Count; c++)
                    {
                        idx++;
                        excel.Cells[r+11, idx] = dt.Rows[r][c].ToString();
                    }
                }
                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[irx, iCol]);
                borders = range.Borders;

                irx++;
                range = worksheet.get_Range(worksheet.Cells[irx, 25], worksheet.Cells[irx+5, iCol]);
                range.Merge(Type.Missing);
                excel.Cells[irx, 25] = "M/S " + CmbCompany.Text.ToUpper() + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "Authorised Signatory";
                
                excel.Cells[irx, 1] = "#Relay and *Place of Work in case of Mines only (Underground/Opencast/Surface)";
                range = worksheet.get_Range(worksheet.Cells[irx, 1], worksheet.Cells[irx, 20]);
                range.Merge(Type.Missing);

                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[irx + 5, iCol]);
                borders = range.Borders;
                //Set the thick lines style.
                borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                borders.Weight = 1d;

                irx++;
                excel.Cells[irx, 1] = "In case an employee is not present the following to be entered: (R for Rest/L for Paid Leave/A for absent/O for Weekly Off/C for Establishment Closed)";
                range = worksheet.get_Range(worksheet.Cells[irx, 1], worksheet.Cells[irx, 20]);
                range.Merge(Type.Missing);

                irx++;
                excel.Cells[irx, 1] = "** Not necessary in case of E Form maintenance.";
                range = worksheet.get_Range(worksheet.Cells[irx, 1], worksheet.Cells[irx, 20]);
                range.Merge(Type.Missing);

                
                object missing = System.Reflection.Missing.Value;

                ((Excel._Worksheet)worksheet).Activate();
                worksheet.UsedRange.Select();

                worksheet.Columns.AutoFit();

                // ((Excel._Application)excel).Quit();

                MessageBox.Show("Export To ExcelCompleted!", "Export");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lbl_nodays.Text = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month).ToString();
            lbl_EndDate.Text = lbl_nodays.Text + AttenDtTmPkr.Value.ToString("/MM/yyyy");
        }

        private void frm_Register_FrmD_Load(object sender, EventArgs e)
        {
            CmbCompany.PopUp();
            CmbLocation.PopUp();
        }
    }
}
