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
    public partial class frmEmployeePfEsiExcel : Form
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        int Head_Cou = 0;
        public frmEmployeePfEsiExcel()
        {
            InitializeComponent();
        }

        private void frmEmployeePfEsiExcel_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //excel

                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                int iCol = 0;
                //dt2 = ((DataTable)dgvCsv.Rows).Copy();
                for (int c=0; c <= this.dgvCsv.Columns.Count - 1; c++ )
                {
                    iCol++;
                    //if (c.ColumnName == "EmployName")
                    //{
                    //    excel.Cells[1, iCol] = "EmployeeTitle";
                    //        iCol++;
                    //        excel.Cells[1, iCol] = "EmployeeName";
                    //}
                    //else if (c.ColumnName == "PF NO")
                    //{
                    //    excel.Cells[1, iCol] = "PF Code";
                    //    iCol++;
                    //    excel.Cells[1, iCol] = "PF No";
                    //}
                    //else
                    //{
                    excel.Cells[1, iCol] = dgvCsv.Columns[c].HeaderText; //c.ColumnName;
                    //}
                    excel.Cells.BorderAround(Excel.XlLineStyle.xlContinuous,
        Excel.XlBorderWeight.xlThin,
        Excel.XlColorIndex.xlColorIndexNone,
        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
                    //(BorderStyle.FixedSingle);
                    excel.Cells.Font.Bold = true;
                }
                int iRow = 0;
                string cell_val = "";

                for (int r = 0; r <= this.dgvCsv.Rows.Count - 1; r++)
                {
                    iRow++;
                    iCol = 0;
                    for (int c = 0; c <= this.dgvCsv.Columns.Count - 1; c++)
                    {
                        excel.Cells.Font.Bold = false;
                        try
                        {
                            iCol++;
                            cell_val = Convert.ToString(dgvCsv.Rows[r].Cells[c].Value);//r[c.ColumnName]);
                            excel.Cells[iRow + 1, iCol] = cell_val;
                        }
                        catch
                        {

                        }
                    }
                }
                object missing = System.Reflection.Missing.Value;

                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;


                ((Excel._Worksheet)worksheet).Activate();
                ((Excel._Worksheet)worksheet).Columns.AutoFit();
                ((Excel._Application)excel).Quit();

                MessageBox.Show("Export To ExcelCompleted!", "Export");
                dt.Dispose();
                dt.Clear();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }


        public void Retrive_Data(string sess, string Loc, int Mon, string Loc_id, int co_id, int yr,double ECont,string chk,int opt)
        {


            //string Str_ErHead_basic = "";
            //DataTable ErHead_basic = clsDataAccess.RunQDTbl("select top 1  SalaryHead_Short from tbl_Employee_ErnSalaryHead");
            //Str_ErHead_basic = ErHead_basic.Rows[0][0].ToString();
            
            string Str_ESI = "";
            string Str_ESI_SLNO = "";
            int final_rw=0;
                string EmpID="";
                DataTable data_ESI = clsDataAccess.RunQDTbl("select distinct d.SalaryHead_Short,d.SLNO  from tbl_Employee_DeductionSalayHead d,tbl_Employee_Assign_SalStructure e,tbl_Employee_Link_SalaryStructure l where d.SlNo=e.SAL_HEAD and esi_per=1 and e.SAL_STRUCT=l.SalaryStructure_ID and l.Location_ID  IN (" + Loc_id + ")");
            //Str_ESI = data_ESI.Rows[0][0].ToString();
            //Str_ESI_SLNO = data_ESI.Rows[0][1].ToString();

            if (data_ESI.Rows.Count > 0)
            {
                Str_ESI = data_ESI.Rows[0][0].ToString();
                Str_ESI_SLNO = data_ESI.Rows[0][1].ToString();
            }
            else
            {
                Str_ESI = "";
                ERPMessageBox.ERPMessage.Show("There is no ESI Head in this Salary Structure");
                return;
            }



            Boolean flug_deduction = false;
            string month = clsEmployee.GetMonthName(Mon);


            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,(select pf.PF_Code from Companywiseid_Relation pf where pf.location_id='" + get_LocationID(cmbsalstruc.Text) + "' ) as 'PF NO','" + get_LocationID(cmbsalstruc.Text) + "' as 'Location' ,cast(sm.Basic as varchar(50)) as 'Basic',cast(case when sm.basic>15000 then 15000 else sm.basic end as varchar(50)) as 'EPFBasic',cast(round(((sm.Basic*8.33)/100),2) as varchar(50)) as 'EPS(8.33%)' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + sess + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");

            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,(select pf.esi_code from Companywiseid_Relation pf where pf.location_id='" + get_LocationID(cmbsalstruc.Text) + "' ) as 'ESI NO',sm.Emp_Id as ID,'" + cmbsalstruc.Text + "' as 'Site',sm.DaysPresent as W_Day,cast(sm.TotalSal as varchar(50)) 'Gross Salary'  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + sess + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");

          ////  DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT distinct null as sl,(CASE WHEN em.esi_name != '' THEN em.esi_name ELSE ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          ////"(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) END) as EmployName ,' ' + em.ESIno as 'ESI NO',sm.Emp_Id as ID,'" + Loc + "' as 'Site',sm.DaysPresent as W_Day,(SELECT sum(esi_bs) FROM tbl_employers_contribution WHERE (emp_id = sm.Emp_Id) AND (month = '" + lblMonth.Text + "') AND (lid = sm.Location_id) and (desgid=sm.desig_id)) 'Gross Salary',sm.desig_id as Designation_id,sm.Location_id   FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where (sm.Session='" + sess + "') " + chk + " and (sm.Month ='" + month + "') and (sm.Location_id IN (" + Loc_id + ")) and (em.ID = sm.Emp_Id)");

          ////  DataTable salary_details = clsDataAccess.RunQDTbl("select emp_id as 'EmpId','" + Str_ESI_SLNO + "'as 'SalId','tbl_Employee_DeductionSalayHead' as 'TableName',0 as 'Slno',esi as 'Amount',lid as Location_id,0 as Designation_id from tbl_employers_contribution where month='" + month + " - " + yr + "' and session='" + sess + "' and coid='" + co_id + "' and lid IN (" + Loc_id + ")");

          ////  DataTable dt_test = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,cast(Amount as numeric)Amount,Location_id,0 as Designation_id FROM tbl_Employee_SalaryDet where Session='" + sess + "' and Month ='" + month + "' and Location_id  IN (" + Loc_id + ") and salid='" + Str_ESI_SLNO + "' and TableName='tbl_Employee_DeductionSalayHead' order by Slno");
            
           
          ////  DataTable salary_details1 = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,cast(Amount as numeric)Amount,Location_id,Designation_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + sess + "' and Month ='" + month + "' and Location_id  IN (" + Loc_id + ") and salid='" + Str_ESI_SLNO + "' and TableName='tbl_Employee_DeductionSalayHead' order by Slno");
          ////  DataView dv1 = new DataView(salary_details1);



            DataTable tot_employ = new DataTable();
            DataTable salary_details = new DataTable();
            if (opt==1)
            {
                tot_employ = clsDataAccess.RunQDTbl("select null as [sl],(select (CASE WHEN em.esi_name != '' THEN em.esi_name ELSE ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) END) from tbl_Employee_Mast em where ID=x.ID)  as 'Employee Name',"+
            "(select em.ESIno from tbl_Employee_Mast em where ID=x.ID) as 'ESI NO',ID,(SELECT Location_Name FROM tbl_Emp_Location AS el WHERE (Location_ID = x.Location_id)) as Location,SUM(W_Day)as W_Day,SUM(TotalEarning)as TotalEarning, SUM([Gross Salary]) as [Gross Salary],0 as desig_id,0 as Location_id   from " +
            "(SELECT distinct sm.Emp_Id as ID,em.Location_id,sm.DaysPresent as 'W_Day',sm.TotalSal as TotalEarning," +
            "(case when sm.desig_id=0 then (SELECT sum(esi_bs) FROM tbl_employers_contribution WHERE (emp_id = sm.Emp_Id) AND (month = '" + lblMonth.Text + "') AND (lid = sm.Location_id)) else (SELECT sum(esi_bs) FROM tbl_employers_contribution WHERE (emp_id = sm.Emp_Id) AND (month = '" + lblMonth.Text + "') AND (lid = sm.Location_id) and (desgid=sm.desig_id)) end) AS 'Gross Salary' FROM tbl_Employee_SalaryMast AS sm INNER JOIN tbl_Employee_Mast em ON sm.Emp_Id = em.ID where (sm.Session='" + sess + "')" + chk + " and (Month ='" + month + "') and sm.Location_id IN (" + Loc_id + ") and (em.ESI_Deduction=0 or em.ESI_Deduction is Null))x group by ID,Location_id");

                salary_details = clsDataAccess.RunQDTbl("Select distinct EmpId,SalId,TableName,Slno, SUM(Amount)as Amount,0 as Designation_id,0 as Location_id from (SELECT EmpId,SalId,TableName,0 as Slno,Amount,0 as Designation_id,Location_id FROM tbl_Employee_SalaryDet where Session='" + sess + "' and Month ='" + month + "' and Location_id IN (" + Loc_id + ") and salid='" + Str_ESI_SLNO + "' and TableName='tbl_Employee_DeductionSalayHead' union SELECT EmpId,SalId,TableName,0 as Slno,Amount,Designation_id,Location_id FROM [tbl_Employee_SalaryDet_MultiDesignation] where Session='" + sess + "' and Month ='" + month + "' and Location_id IN (" + Loc_id + ") and salid='" + Str_ESI_SLNO + "' and TableName='tbl_Employee_DeductionSalayHead') main group by EmpId,SalId,TableName,Slno");
            }
            else
            {
                tot_employ = clsDataAccess.RunQDTbl("SELECT distinct null as sl,(CASE WHEN em.esi_name != '' THEN em.esi_name ELSE ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) END) as 'Employee Name' ," +
                    "' ' + em.ESIno as 'ESI NO',sm.Emp_Id as ID, (SELECT Location_Name FROM tbl_Emp_Location AS el WHERE (Location_ID = sm.Location_id)) as 'Location',sm.DaysPresent as 'W_Day',cast(sm.TotalSal as varchar(50)) TotalEarning," +
                    "(case when sm.desig_id=0 then (SELECT sum(esi_bs) FROM tbl_employers_contribution WHERE (emp_id = sm.Emp_Id) AND (month = '" + lblMonth.Text + "') AND (lid = sm.Location_id)) else (SELECT sum(esi_bs) FROM tbl_employers_contribution WHERE (emp_id = sm.Emp_Id) AND (month = '" + lblMonth.Text + "') AND (lid = sm.Location_id) and desgid=sm.desig_id) end) AS 'Gross Salary',sm.desig_id,sm.Location_id " +
                    " FROM tbl_Employee_SalaryMast AS sm INNER JOIN tbl_Employee_Mast em ON sm.Emp_Id = em.ID where (sm.Session='" + sess + "') " + chk + " and sm.Month ='" + month + "' and sm.Location_id IN (" + Loc_id + ")  and (em.ESI_Deduction=0 or em.ESI_Deduction is Null) order by Location,[Employee Name]");

                salary_details = clsDataAccess.RunQDTbl("Select * from (SELECT EmpId,SalId,TableName,Slno,Amount,0 as Designation_id,Location_id FROM tbl_Employee_SalaryDet where Session='" + sess + "' and Month ='" + month + "' and Location_id IN (" + Loc_id + ") and salid='" + Str_ESI_SLNO + "' and TableName='tbl_Employee_DeductionSalayHead' union SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id,Location_id FROM [tbl_Employee_SalaryDet_MultiDesignation] where Session='" + sess + "' and Month ='" + month + "' and Location_id IN (" + Loc_id + ") and salid='" + Str_ESI_SLNO + "' and TableName='tbl_Employee_DeductionSalayHead') main order by Designation_id,Slno");
            }
             

            ////if (dv1.Count > 0)
            ////{
            ////    try
            ////    {
            ////        salary_details.Merge(salary_details1, true, MissingSchemaAction.Ignore);
            ////    }
            ////    catch
            ////    {

            ////    }
            ////  //  dv.Table.Merge(dv1.Table);
            ////}

            DataView dv = new DataView(salary_details);
            int table_count = tot_employ.Columns.Count;
            final_rw = tot_employ.Rows.Count;
            //tot_employ.Rows.Add();  ///

            tot_employ.Rows.Add();
            int dt_count = tot_employ.Rows.Count;
            tot_employ.Rows.Add();
            tot_employ.Rows.Add();

            int counter = 0;

            tot_employ.Columns.Add("Employer's (" + ECont + "%)", typeof(string));
            //tot_employ.Columns.Add("EPFBasic", typeof(string));
            //tot_employ.Columns.Add("EPS(8.33%)", typeof(string));
            string Salary_Head = "";

            for (int i = 0; i <= tot_employ.Rows.Count - 4; i++)
            {
                //dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' ";
                dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["Desig_id"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "'";
                if (dv.Table.Rows.Count > 0)
                {
                    try
                    {
                        Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[0]["TableName"] + " where SlNo ='" + dv[0]["SalId"] + "'");
                    }
                    catch
                    {
                        Salary_Head = "ESI";
                    }
                
                }
                else
                    continue;
                

                tot_employ.Rows[dt_count][1] = "                Total :";

                if (i == 0)
                {
                    if (Salary_Head == Str_ESI)
                    {
                        tot_employ.Columns.Add(Salary_Head, typeof(string));
                        tot_employ.Rows[i][Salary_Head] = " " + dv[0]["Amount"];

                        tot_employ.Rows[dt_count - 1][Salary_Head] = "---------------";
                        tot_employ.Rows[dt_count][Salary_Head] = " " + dv[0]["Amount"];
                        tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                    }
                }
                else
                {
                    //string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[0]["TableName"] + " where SlNo ='" + dv[0]["SalId"] + "'  ");
                    if (Salary_Head == Str_ESI)
                    {
                        tot_employ.Rows[i][Salary_Head] = " " + dv[0]["Amount"];
                        tot_employ.Rows[dt_count][Salary_Head] = " " + string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(dv[0]["Amount"]));
                    }
                }

                tot_employ.Rows[dt_count - 1]["Employer's (" + ECont + "%)"] = "---------------";

                if (Information.IsNumeric(tot_employ.Rows[dt_count][Salary_Head]) == false)
                    tot_employ.Rows[dt_count][Salary_Head] = " " + 0;
                //if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPFBasic"]) == false)
                //    tot_employ.Rows[dt_count]["EPFBasic"] = 0;
                //if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPS(8.33%)"]) == false)
                //    tot_employ.Rows[dt_count]["EPS(8.33%)"] = 0;
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["Employer's (" + ECont + "%)"]) == false)

                    tot_employ.Rows[dt_count]["Employer's (" + ECont + "%)"] = 0;

                tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                //tot_employ.Rows[dt_count + 1]["EPFBasic"] = "========";
                //tot_employ.Rows[dt_count + 1]["EPS(8.33%)"] = "========";
                tot_employ.Rows[dt_count + 1]["Employer's (" + ECont + "%)"] = "========";

                tot_employ.Rows[i]["sl"] = i + 1;

                //tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(tot_employ.Rows[i][Salary_Head]));
                //tot_employ.Rows[dt_count]["EPFBasic"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPFBasic"]) + Convert.ToDouble(tot_employ.Rows[i]["EPFBasic"]));
                //tot_employ.Rows[dt_count]["EPS(8.33%)"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPS(8.33%)"]) + Convert.ToDouble(tot_employ.Rows[i]["EPS(8.33%)"]));

               
                //tot_employ.Rows[i]["Employer ("+ txtEmpContribut.Text +"%)"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[i]["Gross Salary"]) * Convert.ToDouble(txtEmpContribut.Text.Trim()) / 100));
                try
                {
                    tot_employ.Rows[i]["Employer's (" + ECont + "%)"] = " " + string.Format("{0:F}", System.Math.Ceiling(Convert.ToDouble(tot_employ.Rows[i]["Gross Salary"]) * Convert.ToDouble(ECont) / 100));
                }
                catch { }
                tot_employ.Rows[dt_count]["Employer's (" + ECont + "%)"] = " " + string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Employer's (" + ECont + "%)"]) + Convert.ToDouble(tot_employ.Rows[i]["Employer's (" + ECont + "%)"]));

            }
            if (Salary_Head != "")
            {
                tot_employ.Columns[Salary_Head].SetOrdinal(table_count - 1);
                tot_employ.Columns.Remove("ID");

                tot_employ.Columns[Salary_Head].SetOrdinal(6);
                //tot_employ.Columns["EPFBasic"].SetOrdinal(5);
                //tot_employ.Columns["PF"].SetOrdinal(6);
                //tot_employ.Columns["EPS(8.33%)"].SetOrdinal(7);
                tot_employ.Columns["Employer's (" + ECont + "%)"].SetOrdinal(7);

                //tot_employ.Columns["PF"].ColumnName = "Employee Contribution (12%)";

                dt = tot_employ.Copy();
                dt.Rows.RemoveAt(final_rw + 2);
                dt.Rows.RemoveAt(final_rw + 1);
                dt.Rows.RemoveAt(final_rw);
                dt.AcceptChanges();
                Head_Cou = dt.Columns.Count;

            }

            dgv_pfesi_csv.DataSource = dt;

            //****** convert the pf report in csv challan format ******
            //dgvCsv.Columns.Add("ID", "ID");
            dgvCsv.Columns.Add("IpNo", "IP Number  (10 Digits)");
            dgvCsv.Columns.Add("IpName", "IP Name( Only alphabets and space )");
            dgvCsv.Columns.Add("Wdays", "No of Days for which wages paid/payable during the month");
            dgvCsv.Columns.Add("GSal", "Total Monthly Wages");
            dgvCsv.Columns.Add("Rcode", "Reason Code for Zero workings days(numeric only; provide 0 for all other reasons)");
            dgvCsv.Columns.Add("LWday", "Last Working Day ( Format DD/MM/YYYY  or DD-MM-YYYY)");

            int ind_gv = 0;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                EmpID = Convert.ToString(dt.Rows[i]["ESI NO"]).Trim();
                if (EmpID != "")
                {
                    ind_gv = dgvCsv.Rows.Add();
                    dgvCsv.Rows[ind_gv].Cells["IpNo"].Value = EmpID;
                    dgvCsv.Rows[ind_gv].Cells["IpName"].Value = Convert.ToString(dt.Rows[i]["Employee Name"]).Trim(); ;
                    dgvCsv.Rows[ind_gv].Cells["Wdays"].Value = Convert.ToString(Convert.ToInt32(dt.Rows[i]["W_Day"])); ;
                    dgvCsv.Rows[ind_gv].Cells["GSal"].Value = Convert.ToString(Convert.ToInt32(Convert.ToDouble(dt.Rows[i]["Gross Salary"])));
                    dgvCsv.Rows[ind_gv].Cells["Rcode"].Value = 0;
                    dgvCsv.Rows[ind_gv].Cells["LWday"].Value = "";
                }

            }
        }



    }
}
