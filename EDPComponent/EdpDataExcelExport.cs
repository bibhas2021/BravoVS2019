using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using Excel;

namespace EDPComponent
{
    public partial class EdpDataExcelExport : Component
    {
        bool Chk;

        public EdpDataExcelExport()
        {
            InitializeComponent();
        }

        public EdpDataExcelExport(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool ExcelExport(System.Data.DataTable dt)
        {
            try
            {
                Chk = false;
                saveFileDialog1.Filter = "All Microsoft Excel files(*.xls)|*.xls";
                saveFileDialog1.ShowDialog();
               
                Excel.ApplicationClass excel = new ApplicationClass();
                excel.Application.Workbooks.Add(true);
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    excel.Cells[1, col + 1] = dt.Columns[col].ToString();
                }
                int rowIndex = 1;
                int row = 0;
                for (row = 0; row < dt.Rows.Count; row++)
                {
                    if (rowIndex <= dt.Rows.Count)
                        rowIndex++;
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        excel.Cells[rowIndex, col + 1] = dt.Rows[row][col].ToString();
                    }
                }

                Worksheet worksheet = (Worksheet)excel.ActiveSheet;
                worksheet.Activate();
                //DirectoryInfo dr = new DirectoryInfo("c:\\Test\\");
                //dr.Create();
                FileInfo fi = new FileInfo(saveFileDialog1.FileName);
                if (fi.Exists == true)
                    fi.Delete();
                worksheet.SaveAs(saveFileDialog1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
                , Type.Missing, Type.Missing, Type.Missing);

                excel.Workbooks.Close();
                excel.Quit();               
                Chk = true;
                
                //excel.Workbooks.Add(saveFileDialog1.FileName);
                //excel.Visible = true;
                //excel.Sheets.PrintPreview(true);
                //excel.Sheets._PrintOut(1, true, 1, false, true, false, false);


            }
            catch 
            {
            }
            return Chk;
        }
    }
}
