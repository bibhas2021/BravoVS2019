using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Edpcom;
using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;


namespace PayRollManagementSystem
{
    public partial class frmempdetailsexport : Form
    {
        int Company_ID = 0;
        DataTable dt_em = new DataTable();
        string qry = "";
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        public frmempdetailsexport()
        {
            InitializeComponent();
        }

        private void BtnDisp_Bio_Click(object sender, EventArgs e)
        {
            DataTable dt_em = new DataTable();
            string qry = "", condt="",Header="";
            if (rdb_all.Checked == true)
            {
               condt = "";
               Header = "For All Company";
            }
            else 
            {
                Header = CmbCompany.Text.Trim();
              condt = " where (em.company_id='" + Company_ID + "')";
            }



            if (rdbActive.Checked == true)
            {
                if (condt.Trim() == "")
                {
                    condt = " where Active=1";
                }
                else
                {
                    condt = condt + " and Active=1";
                }
            }
            else if (rdbInActive.Checked == true)
            {
                if (condt.Trim() == "")
                {
                    condt = " where Active=0";
                }
                else
                {
                    condt =condt + " and Active=0";
                }

            }
            

           qry = "select ID,"+ 
"((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS 'EmployeeName',"+
"((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN em.FathMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN em.FathLN+ ' ' ELSE '' END)) AS 'FatherName',"+
"((CASE WHEN ltrim(rtrim(em.MothFN)) != '' THEN em.MothFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MothMN)) != '' THEN em.MothMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MothLN)) != '' THEN em.MothLN+ ' ' ELSE '' END)) AS 'MotherName',"+
"((CASE WHEN ltrim(rtrim(em.HusFN)) != '' THEN em.HusFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.HusMN)) != '' THEN em.HusMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.HusLN)) != '' THEN em.HusLN+ ' ' ELSE '' END)) AS 'SpouseName',"+
"CONVERT(VARCHAR(11),DateOfBirth,103) as 'Date Of Birth',CONVERT(VARCHAR(11),DateOfJoining,103) as 'Date Of Joining',CONVERT(VARCHAR(11),DateOfRetirement,103) as 'Date Of Retirement',"+
"Religion,Cast,Gender,MaritalStatus as 'Marital Status',"+
"((CASE WHEN ltrim(rtrim(em.PresentAddress)) != '' THEN em.PresentAddress+ ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.PermanentAddress)) != '' THEN em.PermanentAddress+ ' ' ELSE '' END)) AS 'Address',"+
"cast(Mobile as nvarchar(Max)) as 'Contact No',PF as 'EPF',esino as 'ESIC',PassportNo as 'UAN',PANno,PenssionNo as 'Pension',REPLACE(aadhar, ' ', '') as 'Aadhar'," +
"(select p.DesignationName from tbl_Employee_DesignationMaster p where p.SlNo=em.DesgID) AS 'Designation',"+
"(select JobType from tbl_Employee_JobType where SlNo=em.JobType)as 'Job Type',"+
"Bank_Name as 'Bank',Branch_Name as 'Bank Branch',BankAcountNo as 'Bank Account No',GMIno as 'Bank IFSC',"+
"(Select CO_NAME from Company where CO_CODE=em.Company_id)as 'Company',"+
"(Select isNull(Location_Name,'') from tbl_emp_location where Location_ID=em.Location_id) as 'Location',"+
"(select isnull((SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID),'' ) from tbl_Emp_Location EL where Location_ID=em.Location_id ) as 'Client',"+
"EMPBASIC as 'Emp Basic',EMPSAL as 'Emp Salary'," +
"(case when Active='1' then (case when x.lpay>3 then 'Dormant' else (case when x.lpay>1 then 'Pre-Dormant' else 'Active' end ) end) else 'In Active' end ) as 'Status' "+
" from tbl_Employee_Mast em join (SELECT EmpId ,DATEDIFF(month, max(cast(('01-'+ [Month]) as Date)), CAST( GETDATE() AS Date ))lpay FROM tbl_Employee_SalaryGross group by EmpId)x on x.EmpId=em.ID " + condt + " ORDER BY 'Company','Client','Location','EmployeeName'";
           dt_em = clsDataAccess.RunQDTbl(qry);
            


            DataTable dt_copy = dt_em.Copy();
            DataTable dt = new DataTable();
            for (int ind = 0; ind < chkFields.Items.Count; ind++)
            {

                if (chkFields.GetItemChecked(ind) == false)
                {
                    dt_copy.Columns.Remove(chkFields.Items[ind].ToString());
                }

            }

            DataView dv = new DataView(dt_copy);
            //try
            //{
            //    if (rdb_Selected.Checked == true)
            //    {
            //        dv.RowFilter = "Company = '" + cmbCompany.Text.ToLower() + "'";

            //    }
            //}
            //catch { }


            dt = dv.Table;

            dgvShow.DataSource = dt;
            MidasReport.Form1 f1= new MidasReport.Form1();
            f1.empdetails(Header, dt);
            f1.Show();
           // ExportToPdf(dt);

          
         // "excel"

               // Excel.Application excel = new Excel.Application();
               // Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
               // excel.Visible = true;
               // int iCol = 0, irw = 0; ;
               // Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
               // iCol = dgvShow.Columns.Count;


               // excel.Cells[1, 1] = "Employee Detail List";
               // Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);

            
               // range.Merge(true);
               // range.Font.Bold = true;


               // range.HorizontalAlignment = HorizontalAlign.Center;
               // range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
               // range.Columns.AutoFit();
               // range.Rows.AutoFit();


               // excel.Cells[2, 1] =Header;

               // range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);
               // range.Merge(true);
               // range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
               // range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

               // range.Columns.AutoFit();
               // range.Rows.AutoFit();

               // //excel.Cells[3, 1] = sub;
               // range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
               // range.Merge(true);
               // range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
               // range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
               // range.Columns.AutoFit();
               // range.Rows.AutoFit();
               // string[] cell_head = new string[] { };
               // string old_head = "";
               // int ind_st = 0, ind_fin = 0;

               // for (int i = 1; i <= dgvShow.Columns.Count; i++)
               // {
               //     cell_head = Convert.ToString(dgvShow.Columns[i - 1].HeaderText).Split('.');
               //     if (cell_head.Length > 1)
               //     {
               //         if (old_head == cell_head[0])
               //         {
               //             ind_fin = i;
               //         }
               //         else
               //         {
               //             try
               //             {
               //                 range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
               //                 range.Merge(Type.Missing);
               //                 range.HorizontalAlignment = HorizontalAlign.Center;
               //                 range.VerticalAlignment = VerticalAlign.Top;
               //             }
               //             catch { }
               //             ind_st = i;
               //             excel.Cells[4, i] = cell_head[0];
               //             old_head = cell_head[0];
               //         }
               //         excel.Cells[5, i] = cell_head[1];
               //     }
               //     else if (cell_head.Length > 0)
               //     {


               //         excel.Cells[4, i] = dgvShow.Columns[i - 1].HeaderText;
               //         try
               //         {
               //             range = worksheet.get_Range(worksheet.Cells[4, i], worksheet.Cells[5, i]);
               //             range.Merge(Type.Missing);
               //             range.HorizontalAlignment = HorizontalAlign.Left;
               //             range.VerticalAlignment = VerticalAlign.Top;
               //         }
               //         catch { }
               //     }

               // }

               // range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
               // range.Font.Bold = true;
               // DateTime MyDate;
               // for (int i = 0; i < dgvShow.Rows.Count; i++)
               // {
               //     for (int j = 1; j <= dgvShow.Columns.Count; j++)
               //     {
               //         try
               //         {
               //             irw = i + 6;
               //             if (j != 20 || j != 22)
               //             {
               //                 range = worksheet.get_Range(worksheet.Cells[i + 6, j], worksheet.Cells[i + 6, j]);
               //                 range.NumberFormat = "@";
               //             }
               //             if (!DateTime.TryParse(dgvShow.Rows[i].Cells[j - 1].Value.ToString(), out MyDate))
               //             {
               //                 excel.Cells[i + 6, j] = dgvShow.Rows[i].Cells[j - 1].Value.ToString();
               //             }
               //             else
               //             {
               //                 excel.Cells[i + 6, j] = "'" + dgvShow.Rows[i].Cells[j - 1].Value.ToString();
               //             }
               //         }
               //         catch { }
               //     }
               // }

               // object missing = System.Reflection.Missing.Value;



               // range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[irw, iCol]);
               // Excel.Borders borders = range.Borders;
               // //Set the thick lines style.
               // borders.LineStyle = Excel.XlLineStyle.xlContinuous;
               // borders.Weight = 2d;
               // range.WrapText = true;

               // ((Excel._Worksheet)worksheet).Activate();
               // worksheet.UsedRange.Select();

               // worksheet.Columns.AutoFit();

               ////((Excel._Application)excel).Save();

               // MessageBox.Show("Export To Excel Completed!", "Export");
        

        
    }




        public void ExportToPdf(DataTable dt)
        {

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("c://newchk.pdf", FileMode.Create));
            document.Open();
            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("c://ggi logo.bmp");
            //document.Add(img);
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);
            //float[] columnDefinitionSize = { 22F, 22F, 12F, 7.75F, 7.77F, 7.77F, 7.77F, 7.77F, 10.88F, 10.88F, 10.88F, 4.75F, 7.77F, 7.77F, 7.77F, 7.77F, 7.77F, 7.77F, 9F };

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f };

            table.SetWidths(widths);

            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("Products"));


            ////table.AddCell(cell);
            cell.Colspan = dt.Columns.Count;

            //cell.Border = 0;

            //cell.HorizontalAlignment = 1;
            foreach (DataColumn c in dt.Columns)
            {

                table.AddCell(new Phrase(c.ColumnName, font5));
            }

            //cell.BackgroundColor = new iTextSharp.text.Color(0xC0, 0xC0, 0xC0);


            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    table.AddCell(new Phrase(r[0].ToString(), font5));
                    table.AddCell(new Phrase(r[1].ToString(), font5));
                    table.AddCell(new Phrase(r[2].ToString(), font5));
                    table.AddCell(new Phrase(r[3].ToString(), font5));
                }
            } document.Add(table);
            document.Close();
        }

        //private void GeneratePDF(DataTable dataTable, string Name)
        //{
        //    try
        //    {
        //        string[] columnNames = (from dc in dataTable.Columns.Cast<DataColumn>()
        //                                select dc.ColumnName).ToArray();
        //        int Cell = 0;
        //        int count = columnNames.Length;
        //        object[] array = new object[count];

        //        dataTable.Rows.Add(array);

        //        Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
        //        System.IO.MemoryStream mStream = new System.IO.MemoryStream();
        //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, mStream);
        //        int cols = dataTable.Columns.Count;
        //        int rows = dataTable.Rows.Count;


        //        HeaderFooter header = new HeaderFooter(new Phrase(Name), false);

        //        // Remove the border that is set by default  
        //        header.Border = iTextSharp.text.Rectangle.TITLE;
        //        // Align the text: 0 is left, 1 center and 2 right.  
        //        header.Alignment = Element.ALIGN_CENTER;
        //        pdfDoc.Header = header;
        //        // Header.  
        //        pdfDoc.Open();
        //        iTextSharp.text.Table pdfTable = new iTextSharp.text.Table(cols, rows);
        //        pdfTable.BorderWidth = 1; pdfTable.Width = 100;
        //        pdfTable.Padding = 1; pdfTable.Spacing = 4;

        //        //creating table headers  
        //        for (int i = 0; i < cols; i++)
        //        {
        //            Cell cellCols = new Cell();
        //            Chunk chunkCols = new Chunk();
        //            cellCols.BackgroundColor = new iTextSharp.text.Color(System.Drawing.ColorTranslator.FromHtml("#548B54"));
        //            iTextSharp.text.Font ColFont = FontFactory.GetFont(FontFactory.HELVETICA, 14, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.WHITE);

        //            chunkCols = new Chunk(dataTable.Columns[i].ColumnName, ColFont);

        //            cellCols.Add(chunkCols);
        //            pdfTable.AddCell(cellCols);
        //        }
        //        //creating table data (actual result)   

        //        for (int k = 0; k < rows; k++)
        //        {
        //            for (int j = 0; j < cols; j++)
        //            {
        //                Cell cellRows = new Cell();
        //                if (k % 2 == 0)
        //                {
        //                    cellRows.BackgroundColor = new iTextSharp.text.Color(System.Drawing.ColorTranslator.FromHtml("#cccccc")); ;
        //                }
        //                else { cellRows.BackgroundColor = new iTextSharp.text.Color(System.Drawing.ColorTranslator.FromHtml("#ffffff")); }
        //                iTextSharp.text.Font RowFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
        //                Chunk chunkRows = new Chunk(dataTable.Rows[k][j].ToString(), RowFont);
        //                cellRows.Add(chunkRows);

        //                pdfTable.AddCell(cellRows);
        //            }
        //        }

        //        pdfDoc.Add(pdfTable);
        //        pdfDoc.Close();
        //        Response.ContentType = "application/octet-stream";
        //        Response.AddHeader("Content-Disposition", "attachment; filename=" + Name + "_" + DateTime.Now.ToString() + ".pdf");
        //        Response.Clear();
        //        Response.BinaryWrite(mStream.ToArray());
        //        Response.End();

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}   

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            string sql = "";

            if (rdb_co.Checked == true)
            {
                //sql = "select CO_name,CO_CODE from Company order by CO_CODE";

                if (edpcom.CurrentLocation.Trim() != "")
                {

                    sql = ("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
                }
                else
                {
                    sql = ("Select CO_NAME,CO_CODE from Company");
                }

            }
            else
            {
                if (edpcom.CurrentLocation.Trim() != "")
                {
                    sql = "Select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName,(SELECT (select co_name from Company where CO_CODE=ec.coid) FROM  tbl_Employee_CliantMaster ec where client_id=EL.Cliant_ID)as Company  from tbl_Emp_Location EL where (Location_id in (" + edpcom.CurrentLocation + "))  order by Location_Name";
                }
                else
                {
                    sql = "Select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName,(SELECT (select co_name from Company where CO_CODE=ec.coid) FROM  tbl_Employee_CliantMaster ec where client_id=EL.Cliant_ID)as Company  from tbl_Emp_Location EL where (Location_id in (select distinct Location_id from tbl_employee_mast))  order by Location_Name";
                }
            }

            DataTable DT_Cmp = clsDataAccess.RunQDTbl(sql);
            if (DT_Cmp.Rows.Count > 0)
            {
                CmbCompany.LookUpTable = DT_Cmp;
                CmbCompany.ReturnIndex = 1;
            }
        }
        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            //Extractcmd.Visible = true;
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                Company_ID= Convert.ToInt32(CmbCompany.ReturnValue);

        }
        private void LblCompany_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_all.Checked == true)
            {               
                CmbCompany.Text = "";
                CmbCompany.Enabled = false;
                LblCompany.Text = "Select";
            }
            else if (rdb_co.Checked == true)
            {

                CmbCompany.Text = "";
                CmbCompany.Enabled = true;
                LblCompany.Text = "Select Company";
            }
            else
            {
                LblCompany.Text = "Select Location";
                CmbCompany.Text = "";
                CmbCompany.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //int selected = checkedListBox1.SelectedIndex;
            //if (checkedListBox1.GetItemChecked(selected) == true)
            //{
                
            //    checkedListBox1.SelectedIndex = checkedListBox1.SelectedIndex;
            //    checkedListBox1.Items(Enabled, true);

            //    //chkShift_id.SetItemChecked(selected, true);
            //    //chkShift_no.SelectedIndex = chkShift.SelectedIndex;
            //    //chkShift_no.SetItemChecked(selected, true);
            //}
            //else
            //{
            //    //chkShift_id.SelectedIndex = chkShift.SelectedIndex;
            //    chkShift_id.SetItemChecked(selected, false);
            //    //chkShift_no.SelectedIndex = chkShift.SelectedIndex;
            //    chkShift_no.SetItemChecked(selected, false);
            //}

            
        }
        private void OnLoad()
        {
            rdb_all.Checked = true;
            for (int i = 0; i < chkFields.Items.Count; i++)
            {
                chkFields.SetItemChecked(i, true);
            }
           
        }

        private void frmempdetailsexport_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            DataTable dt_em = new DataTable();
            string qry = "", condt = "", Header = "";
            if (rdb_all.Checked == true)
            {
                condt = "";
                Header = "For All Company";
            }
            else if (rdb_co.Checked == true)
            {
                Header = CmbCompany.Text.Trim();
                condt = " where (em.company_id='" + Company_ID + "')";
            }
            else
            {
                Header = CmbCompany.Text.Trim();
                condt = " where (em.Location_id='" + Company_ID + "')";
            }


            if (rdbActive.Checked == true)
            {
                if (condt.Trim() == "")
                {
                    condt = " where Active=1";
                }
                else
                {
                    condt =  condt + " and Active=1";
                }
            }
            else if (rdbInActive.Checked == true)
            {
                if (condt.Trim() == "")
                {
                    condt = " where Active=0";
                }
                else
                {
                    condt = condt + " and Active=0";
                }

            }


            qry = "select ID," +
 "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS 'EmployeeName'," +
 "((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN em.FathMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN em.FathLN+ ' ' ELSE '' END)) AS 'FatherName'," +
 "((CASE WHEN ltrim(rtrim(em.MothFN)) != '' THEN em.MothFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MothMN)) != '' THEN em.MothMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MothLN)) != '' THEN em.MothLN+ ' ' ELSE '' END)) AS 'MotherName'," +
 "((CASE WHEN ltrim(rtrim(em.HusFN)) != '' THEN em.HusFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.HusMN)) != '' THEN em.HusMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.HusLN)) != '' THEN em.HusLN+ ' ' ELSE '' END)) AS 'SpouseName'," +
 "cast((case when (em.phone=0) then '' else (case when (em.STD=0) then '' else '('+cast(em.STD as nvarchar(Max))+')' end)+ cast(em.phone as nvarchar(Max)) end) as nvarchar(Max)) 'Phone',"+
 "cast((case when (em.Mobile=0) then '' else cast(em.mobile as nvarchar(Max)) end) as nvarchar(Max)) 'Mobile',"+
 "(case when (ltrim(rtrim(em.Permanentstreet))='')then '' else em.Permanentstreet + ','+ em.Permanentcity+ ','+(select State_Name from StateMaster where STATE_CODE=em.Permanentstate)+' - '+em.Permanentpin end)'PermanentAddress'," +
 "(case when (ltrim(rtrim(em.Presentstreet))='')then '' else em.Presentstreet + ','+ em.Presentcity+ ','+(select State_Name from StateMaster where STATE_CODE=em.Presentstate)+' - '+em.Presentpin end)'PresentAddress'," +
 "CONVERT(VARCHAR(11),DateOfBirth,103) as 'Date Of Birth',CONVERT(VARCHAR(11),DateOfJoining,103) as 'Date Of Joining',CONVERT(VARCHAR(11),DateOfRetirement,103) as 'Date Of Retirement'," +
 //"Religion,Cast,Gender,MaritalStatus as 'Marital Status'," +
 //"((CASE WHEN ltrim(rtrim(em.PresentAddress)) != '' THEN em.PresentAddress+ ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.PermanentAddress)) != '' THEN em.PermanentAddress+ ' ' ELSE '' END)) AS 'Address'," +
 //"cast(Mobile as nvarchar(Max)) as 'Contact No',"+
 "PF as 'EPF',esino as 'ESIC',PassportNo as 'UAN',PANno,PenssionNo as 'Pension',REPLACE(aadhar, ' ', '') as 'Aadhar'," +
 "(select p.DesignationName from tbl_Employee_DesignationMaster p where p.SlNo=em.DesgID) AS 'Designation'," +
 //"(select JobType from tbl_Employee_JobType where SlNo=em.JobType)as 'Job Type'," +
 "Bank_Name as 'Bank',Branch_Name as 'Bank Branch',BankAcountNo as 'Bank Account No',GMIno as 'Bank IFSC'," +
 "(Select CO_NAME from Company where CO_CODE=em.Company_id)as 'Company'," +
 "(Select isNull(Location_Name,'') from tbl_emp_location where Location_ID=em.Location_id) as 'Location'," +
 "(select isnull((SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID),'' ) from tbl_Emp_Location EL where Location_ID=em.Location_id ) as 'Client'," +
 //"EMPBASIC as 'Emp Basic',EMPSAL as 'Emp Salary'," +
 "(case when Active='1' then (case when x.lpay>3 then 'Dormant' else (case when x.lpay>1 then 'Pre-Dormant' else 'Active' end ) end) else 'In Active' end ) as 'Status' " +
 " from tbl_Employee_Mast em join (SELECT EmpId ,DATEDIFF(month, max(cast(('01-'+ [Month]) as Date)), CAST( GETDATE() AS Date ))lpay FROM tbl_Employee_SalaryGross group by EmpId)x on x.EmpId=em.ID " + condt + " ORDER BY 'Company','Client','Location','EmployeeName'";
            dt_em = clsDataAccess.RunQDTbl(qry);



            DataTable dt_copy = dt_em.Copy();
            DataTable dt = new DataTable();
            for (int ind = 0; ind < chkFields.Items.Count; ind++)
            {

                if (chkFields.GetItemChecked(ind) == false)
                {
                    dt_copy.Columns.Remove(chkFields.Items[ind].ToString());
                }

            }

            DataView dv = new DataView(dt_copy);
            //try
            //{
            //    if (rdb_Selected.Checked == true)
            //    {
            //        dv.RowFilter = "Company = '" + cmbCompany.Text.ToLower() + "'";

            //    }
            //}
            //catch { }


            dt = dv.Table;

            dgvShow.DataSource = dt;
            //MidasReport.Form1 f1 = new MidasReport.Form1();
            //f1.empdetails(Header, dt);
            //f1.Show();
            //// ExportToPdf(dt);


            // "excel"

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 0, irw = 0,Dormant=0,predorment=0,inactive=0,active=0 ;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            iCol = dgvShow.Columns.Count;


            excel.Cells[1, 1] = "Employee Detail List";
            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);


            range.Merge(true);
            range.Font.Bold = true;


            range.HorizontalAlignment = HorizontalAlign.Center;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[2, 1] = Header;

            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            range.Columns.AutoFit();
            range.Rows.AutoFit();

            //excel.Cells[3, 1] = sub;
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();
            string[] cell_head = new string[] { };
            string old_head = "";
            int ind_st = 0, ind_fin = 0;

            for (int i = 1; i <= dgvShow.Columns.Count; i++)
            {
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

            }

            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
            range.Font.Bold = true;
            DateTime MyDate;
            for (int i = 0; i < dgvShow.Rows.Count; i++)
            {
                for (int j = 1; j <= dgvShow.Columns.Count; j++)
                {
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
                }
                try
                {
                    range = worksheet.get_Range(worksheet.Cells[i + 6, 1], worksheet.Cells[i + 6, iCol]);
                    if (Convert.ToString(dgvShow.Rows[i].Cells["Status"].Value.ToString().ToLower()) == "pre-Dormant")
                    {

                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        //Color.Yellow;
                        predorment++;
                    }
                    else if (Convert.ToString(dgvShow.Rows[i].Cells["Status"].Value.ToString().ToLower()) == "Dormant")
                    {
                        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.IndianRed);
                        range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

                        Dormant++;
                    }
                    else if (Convert.ToString(dgvShow.Rows[i].Cells["Status"].Value.ToString().ToLower()) == "inactive")
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

            excel.Cells[irw+1, 1] = "Statement of Employee Status Count"+Environment.NewLine + 
                                    "Active : "+ active + Environment.NewLine + 
                                    "Inactive : "+ inactive + Environment.NewLine + 
                                    "Dormant : "+ Dormant+ Environment.NewLine + 
                                    "Predormet : "+ predorment;

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

        private void button1_Click(object sender, EventArgs e)
        {
            frm_register_employee re = new frm_register_employee();
            re.ShowDialog();
        }

        
    }
}
