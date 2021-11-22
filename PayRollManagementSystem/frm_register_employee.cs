using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.IO;

namespace PayRollManagementSystem
{
    public partial class frm_register_employee : Form
    {
        public frm_register_employee()
        {
            InitializeComponent();
        }

        private void cmbLoc_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            DataTable dt_em = new DataTable();
            string qry = "", condt = "", Header = "";


            string sql = "Select Location_Name,Location_ID," +
         "(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName," +
         "(SELECT (select co_name from Company where CO_CODE=ec.coid) FROM  tbl_Employee_CliantMaster ec where client_id=EL.Cliant_ID)as Company  from tbl_Emp_Location EL where (Location_id ='" + cmbLoc.ReturnValue + "')";


            DataTable DT1 = clsDataAccess.RunQDTbl(sql);
            if (DT1.Rows.Count > 0)
            {
                lblClient.Text = DT1.Rows[0]["ClientName"].ToString();
                lblCo.Text = DT1.Rows[0]["Company"].ToString();
                lblLoc.Text = DT1.Rows[0]["Location_Name"].ToString();
            }

            qry = "select ID,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS 'EmployeeName',"+
            "em.Gender,((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN em.FathMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN em.FathLN+ ' ' ELSE '' END)) AS 'FatherName',"+
            "((CASE WHEN ltrim(rtrim(em.MothFN)) != '' THEN em.MothFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MothMN)) != '' THEN em.MothMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MothLN)) != '' THEN em.MothLN+ ' ' ELSE '' END)) AS 'MotherName',"+
            "((CASE WHEN ltrim(rtrim(em.HusFN)) != '' THEN em.HusFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.HusMN)) != '' THEN em.HusMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.HusLN)) != '' THEN em.HusLN+ ' ' ELSE '' END)) AS 'SpouseName',"+
            "CONVERT(VARCHAR(11),DateOfBirth,103) as 'Date Of Birth','Indian' as 'Nationality',"+
            "(SELECT ltrim(rtrim(isNUll((select Quali_Name from Qualification_Master qm where Quali_Code=eq.Qualification),''))) + ', ' FROM tbl_Employee_QualificationDetails eq WHERE  ID=em.ID order by SlNo FOR XML PATH('')) as 'Education'," +
            "CONVERT(VARCHAR(11),DateOfJoining,103) as 'Date Of Joining',"+
            "(select p.DesignationName from tbl_Employee_DesignationMaster p where p.SlNo=em.DesgID) AS 'Designation','' as Category,"+
            "(select JobType from tbl_Employee_JobType where SlNo=em.JobType)as 'Job Type', "+
            "cast((case when (em.phone=0) then '' else (case when (em.STD=0) then '' else '('+cast(em.STD as nvarchar(Max))+')' end)+ cast(em.phone as nvarchar(Max)) end) as nvarchar(Max)) 'Phone',"+
            " cast((case when (em.Mobile=0) then '' else cast(em.mobile as nvarchar(Max)) end) as nvarchar(Max)) 'Mobile',"+
            "(case when (ltrim(rtrim(em.Permanentstreet))='')then '' else em.Permanentstreet + ','+ em.Permanentcity+ ','+(select State_Name from StateMaster where STATE_CODE=em.Permanentstate)+' - '+em.Permanentpin end) as 'PermanentAddress',"+
            "(case when (ltrim(rtrim(em.Presentstreet))='')then '' else em.Presentstreet + ','+ em.Presentcity+ ','+(select State_Name from StateMaster where STATE_CODE=em.Presentstate)+' - '+em.Presentpin end)'PresentAddress',"+
            "CONVERT(VARCHAR(11),DateOfRetirement,103) as 'Date Of Retirement',PF as 'EPF',esino as 'ESIC',PassportNo as 'UAN',PANno as 'PAN',PenssionNo as 'Pension',"+
            "REPLACE(aadhar, ' ', '') as 'AADHAR',Bank_Name as 'Bank',BankAcountNo as 'Bank A/C No',GMIno as 'IFSC',"+
            "isNull((SELECT top 1 CONVERT(VARCHAR(11),sdate,103) as sdate FROM (SELECT slid, eid,(SELECT status FROM tbl_StatusMst WHERE (sid = sl.sid)) AS Status,ucode,sdate,reason FROM tbl_statuslog AS sl) AS st WHERE (Status IN ('InActive','Resign','Leave') and eid=em.ID) order by eid,sdate),'') as 'Date of Exit',"+
            "isNull((SELECT top 1 reason FROM (SELECT slid, eid,(SELECT status FROM tbl_StatusMst WHERE (sid = sl.sid)) AS Status,ucode,sdate,reason FROM tbl_statuslog AS sl) AS st WHERE (Status IN ('InActive','Resign','Leave') and eid=em.ID) order by eid,sdate),'') as 'Reason for Exit',"+
            "em.[identity] as 'Mark of Identification', em.Empimage as 'Photo',(SELECT sign FROM tbl_employee_fscan WHERE (ID =em.ID)) as 'Speciment Signature / Thumb Impression','' as Remarks "+
            "from tbl_Employee_Mast em  where Active=1 and (em.Location_id='" + cmbLoc.ReturnValue + "') ORDER BY ID";
            dt_em = clsDataAccess.RunQDTbl(qry);

            dgvEmp.DataSource = dt_em;
            dgvEmp.Columns["ID"].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void cmbLoc_DropDown(object sender, EventArgs e)
        {
            string sql = "Select Location_Name,Location_ID,"+
           "(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName,"+
           "(SELECT (select co_name from Company where CO_CODE=ec.coid) FROM  tbl_Employee_CliantMaster ec where client_id=EL.Cliant_ID)as Company  from tbl_Emp_Location EL where (Location_id in (select distinct Location_id from tbl_employee_mast))  order by Location_Name";
            

            DataTable DT_Cmp = clsDataAccess.RunQDTbl(sql);
            if (DT_Cmp.Rows.Count > 0)
            {
                cmbLoc.LookUpTable = DT_Cmp;
                cmbLoc.ReturnIndex = 1;
            }
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 0, irw = 0; ;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            iCol = dgvEmp.Columns.Count;


            excel.Cells[1, 1] = "SCHEDULE";
            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);
            range.Merge(true);
            range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[2, 1] =  "[See Rule 2(1)]";
            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);
            range.Merge(true);
            range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[3, 1] ="FORM A";

            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[4, 1] = "FORMAT OF EMPLOYEE REGISTER";

            range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[5, 1] = "[Part - A: For all Establishments]";
            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[6, 1] = "Name of the Establishmen : "+ lblCo.Text.ToUpper();
            range = worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[6, Convert.ToInt32(iCol/2)]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();

            excel.Cells[6, Convert.ToInt32(iCol / 2)+1] = "Location : " + lblLoc.Text.ToUpper();
            range = worksheet.get_Range(worksheet.Cells[6, Convert.ToInt32(iCol / 2) + 1], worksheet.Cells[6, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();
            
            int ind_st = 0, ind_fin = 0;

            for (int i = 1; i <= dgvEmp.Columns.Count; i++)
            {               
              excel.Cells[7, i] = dgvEmp.Columns[i - 1].HeaderText;
            }
            range = worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[7, iCol]);
            
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Font.Bold = true;
            
            DateTime MyDate;

            for (int i = 0; i < dgvEmp.Rows.Count; i++)
            {
                for (int j = 1; j <= dgvEmp.Columns.Count; j++)
                {
                    try
                    {
                        irw = i + 8;                       
                       
                        DataGridViewCell cell = dgvEmp[j-1, i];
                        excel.Cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        excel.Columns.AutoFit();

                                     if (cell.Value.GetType() == typeof(byte[]))//condition is not all executing when it comes to image column
                                     {

                                         Byte[] imageData = (byte[])cell.Value;
                                         Bitmap image;
                                         string fpath="D:\\Backup";
                                         //========================================================
                                         MemoryStream stream1 = new MemoryStream();
                                         try
                                         {

                                             stream1.Write(imageData, 0, imageData.Length);
                                             //edpcon.Close();

                                             image = new Bitmap(stream1);
                                             image.Save(fpath + "\\" + dgvEmp.Rows[i].Cells["ID"].Value.ToString() + ".jpg");
                                             image.Dispose();
                                             //stream.Dispose();

                                         }
                                         catch
                                         {

                                         }

                                         //==========================================================



                                         Excel.Range oRange = (Excel.Range)excel.Cells[irw, j];
                                         //worksheet.Paste(oRange, null);
                                         
                                        
                                         float Left = (float)((double)oRange.Left);
                                         float Top =  (float)((double)oRange.Top);
                                         const float ImageSize = 35;

                                         if (dgvEmp.Columns["Photo"].Index == j-1)
                                             {
                                                 worksheet.Shapes.AddPicture(@"D:\Backup\" + dgvEmp.Rows[i].Cells["ID"].Value.ToString() + ".jpg",
                                                 Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);
                                             }
                                             else
                                             {
                                                 worksheet.Shapes.AddPicture(@"D:\Backup\" + dgvEmp.Rows[i].Cells["ID"].Value.ToString() + ".jpg",
                                                 Office.MsoTriState.msoFalse, Office.MsoTriState.msoCTrue, Left, Top, 160, ImageSize);
                                             }
                                         oRange.RowHeight = ImageSize + 2;
                                         File.Delete(@"D:\Backup\" + dgvEmp.Rows[i].Cells["ID"].Value.ToString() + ".jpg");
                                     }
                                     else
                                     {
                                         if (!DateTime.TryParse(dgvEmp.Rows[i].Cells[j - 1].Value.ToString(), out MyDate))
                                         {
                                             excel.Cells[irw, j] = "'" + dgvEmp.Rows[i].Cells[j - 1].Value.ToString();
                                         }
                                         else
                                         {
                                             excel.Cells[irw, j] = dgvEmp.Rows[i].Cells[j - 1].Value.ToString();
                                         }
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

            //((Excel._Application)excel).Save();

            MessageBox.Show("Export To Excel Completed!", "Export");
        }

        private void frm_register_employee_Load(object sender, EventArgs e)
        {
            cmbLoc.PopUp();

        }
    }
}
