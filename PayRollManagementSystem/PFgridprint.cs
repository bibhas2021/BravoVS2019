using System.Windows.Forms;
using System.Drawing;
namespace PayRollManagementSystem
{

    public class PFGridPrint : DataGridView 
    {

        internal System.Drawing.Printing.PrintDocument PD;
        public string Header1;
        public string Header2;
        public string Header3;
        public string EmployeeName;
        public string SchoolName;
        public string CircleName;
        public string EmpRegNo;
        public string AcadYear;
        private PageSetupDialog PSetup = new PageSetupDialog();
        private PrintPreviewDialog PrV = new PrintPreviewDialog();
        private int vSpacing = 6;
        //Dim BillCategNo As Integer = 1


        #region  Component Designer generated code

        public PFGridPrint(System.ComponentModel.IContainer Container)
            : this()
        //TODO: INSTANT C# TODO TASK: C# does not have an equivalent to VB.NET's 'MyClass' keyword
        //ORIGINAL LINE: MyClass.New()
        {

            //Required for Windows.Forms Class Composition Designer support
        }

        public PFGridPrint()
            : base()
        {

            //This call is required by the Component Designer.
        //    InitializeComponent();

            //Add any initialization after the InitializeComponent() call

        }

        //Component overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        //Required by the Component Designer
        private System.ComponentModel.IContainer components;

        //NOTE: The following procedure is required by the Component Designer
        //It can be modified using the Component Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            //((System.ComponentModel.ISupportInitialize)this).BeginInit();
            //((System.ComponentModel.ISupportInitialize)this).EndInit();

            //INSTANT C# NOTE: Converted event handlers:
            PD.PrintPage += PD_PrintPage;

        }

        #endregion


        //INSTANT C# NOTE: These were formerly VB static local variables:
        private int PD_PrintPage_startItem;

        public void Print()
        {
            DialogResult PrntDlgRslt = 0;


            PD = new System.Drawing.Printing.PrintDocument();
            
            PSetup.PageSettings = PD.DefaultPageSettings;
            PrntDlgRslt = PSetup.ShowDialog();
            PD.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PD_PrintPage);
            if (PrntDlgRslt == DialogResult.Cancel)
            {
                return;
            }
            PSetup.PageSettings = PSetup.PageSettings; // PD.DefaultPageSettings
            //PSetup.ShowDialog()

            PrV.Document = PD;
            PrV.ShowDialog();
        }

        private void PD_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            RectangleF RF = new RectangleF();
               //RF.X = 5;
               //RF.Y = 5;
               //RF.Width = 50;
               //RF.Height = 50;

            StringFormat fmt = new StringFormat();
            fmt.Alignment = StringAlignment.Center;

            //   //e.Graphics.DrawString("Bhotepatty H.B.L. High School (H.S)",
            //new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold,
            //    System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), 
            //System.Drawing.Brushes.Black, RF, fmt);
         
            
            
            float X = 0;
            float Y = 0;

            X = PD.DefaultPageSettings.Margins.Left;
            Y = PD.DefaultPageSettings.Margins.Top;
            SizeF txtSize = new SizeF();
            string caption = null;
            Font titleFont = this.Font;
            titleFont = new System.Drawing.Font("Arial", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));

            //caption = "Emp. Reg No : " + EmpRegNo + "    Employee Name :  " + EmployeeName + "    Circle Name : " + CircleName;
            txtSize = e.Graphics.MeasureString(caption, titleFont);
           // TempLeft = (int)txtSize.Width;
            RF = new RectangleF((float)(X), (float)(Y), PD.DefaultPageSettings.PaperSize.Width, PD.DefaultPageSettings.PaperSize.Height);

            e.Graphics.DrawString(caption, new System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), System.Drawing.Brushes.Black, RF, fmt);

            
            //INSTANT C# NOTE: VB local static variable moved to class level
            int startItem = 60;
            //int[] ColWidths = new int[this.get_Cols];
            //// calculate the width of each column and the total width of the grid    
            //int i = 0;
            //int totWidth = 0;
            //for (i = 0; i < this.get_Cols; i++)
            //{
            //    ColWidths[i] = this.get_ColWidth(i);
            //    totWidth = totWidth + ColWidths[i];
            //}

            
            // cellWidth and cellHeight are the width and height 
            // of the current subitem's cell
            int cellWidth = 0;
            int cellHeight = 0;
          
            int PWidth = PD.DefaultPageSettings.PaperSize.Width;
            int PHeight = PD.DefaultPageSettings.PaperSize.Height;
            if (PD.DefaultPageSettings.Landscape)
            {
                int tmp = 0;
                tmp = PWidth;
                PWidth = PHeight;
                PHeight = tmp;
            }

            int PageWidth = PWidth - (PD.DefaultPageSettings.Margins.Left + PD.DefaultPageSettings.Margins.Right);
            int PageHeight = PHeight - (PD.DefaultPageSettings.Margins.Top + PD.DefaultPageSettings.Margins.Bottom);
            
            Rectangle R = new Rectangle();
            //string caption = null;
            Font itemFont = null;
            SolidBrush titleBrush = new SolidBrush(Color.Black);
            System.Drawing.Brush itemBrush = null;
            itemBrush = Brushes.Black;
            Pen borderPen = new Pen(Color.Black, 1F);
            int txtWidth = 0;
            int TempLeft = 0;
            
            System.Drawing.Pen Pn = null;


            RF = new RectangleF((float)(X), (float)(Y - 30), (float)(PageWidth), 36F);

            fmt.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(Header1, new System.Drawing.Font("Arial", 10.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), titleBrush, RF, fmt);
            //"Bhotepatty H.B.L. High School (H.S)"
            RF = new RectangleF((float)(X), (float)(Y - 15), (float)(PageWidth), 36F);
            e.Graphics.DrawString(Header2, new System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), titleBrush, RF, fmt);
            RF = new RectangleF((float)(X), (float)(Y), (float)(PageWidth), 36F);
            e.Graphics.DrawString(Header3, new System.Drawing.Font("Arial", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), titleBrush, RF, fmt);

            fmt.Alignment = StringAlignment.Far;
            RF.Height = 26;
            e.Graphics.DrawString("Date : " + System.DateTime.Now.Day + " - " + Microsoft.VisualBasic.DateAndTime.MonthName(System.DateTime.Now.Month, true) + " - " + System.DateTime.Now.Year + '\r' + '\n' + "Time: " + Microsoft.VisualBasic.DateAndTime.TimeValue(System.DateTime.Now.ToString()), new System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), System.Drawing.Brushes.Black, RF, fmt);

            fmt.Alignment = StringAlignment.Near;
            //e.Graphics.DrawString("Recipt No.:" & Me.BillNoList.Items.Item(BillCategNo - 1), New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), titleBrush, RF, fmt)
            fmt.Alignment = StringAlignment.Center;

            //RF.Y = Y - 5 '- 20
            //RF.Height = 30
            //e.Graphics.DrawString("P.O. Bhotepatty, DIST. JALPAIGURI.", New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), System.Drawing.Brushes.Black, RF, fmt)

            Y = Y + (int)RF.Height - 5; // + vSpacing / 2
            e.Graphics.DrawLine(Pens.Black, PD.DefaultPageSettings.Margins.Left + 100, Y, PD.DefaultPageSettings.Margins.Left + PageWidth - 100, Y);

            RF.Y = Y;
            //e.Graphics.DrawString("Admission/Re-Admission Recipt  For The  Academic Year " & AcadYear, titleFont, titleBrush, RF, fmt)

            fmt.Alignment = StringAlignment.Near;

            Y = Y + 20;
            RF.Y = Y;

            RF.X = PD.DefaultPageSettings.Margins.Left;
            caption = "Emp. Reg No : " + EmpRegNo + "    Employee Name :  " + EmployeeName + "    Circle Name : " + CircleName;
            txtSize = e.Graphics.MeasureString(caption, titleFont);
            TempLeft = (int)txtSize.Width;

            e.Graphics.DrawString(caption, new System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), System.Drawing.Brushes.Black, RF, fmt);
            RF.X = RF.X + TempLeft;

            RF.Width = txtSize.Width;
            TempLeft = (int)txtSize.Width; //+ PD.DefaultPageSettings.Margins.Left




            RF.X = RF.X + TempLeft;

            fmt.Alignment = StringAlignment.Near;

            Y = (int)RF.Y - 10;
            e.Graphics.DrawLine(Pens.Black, PD.DefaultPageSettings.Margins.Left, Y + RF.Height, PD.DefaultPageSettings.Margins.Left + PageWidth, Y + RF.Height);

            //=======End Header========


            fmt.Alignment = StringAlignment.Center; //'TextAlign = HorizontalAlignment.Center
            titleFont = new System.Drawing.Font("Arial", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));


            Y = Y + (int)RF.Height; // + vSpacing / 2
            int tallestHCell = 0;

            //        for (var i = 0; i < this.get_Cols; i++)
            //        {
            //            caption = this.get_TextMatrix(0, i);
            //            cellWidth = ColWidths(i) * PageWidth / totWidth;
            //            titleFont = new System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
            //            txtSize = e.Graphics.MeasureString(caption, titleFont);
            //            //cellHeight = txtSize.Height
            //            if (txtSize.Height > tallestHCell)
            //            {
            //                tallestHCell = txtSize.Height;
            //            }
            //            cellHeight = tallestHCell;
            //            RF = new RectangleF((float)(X), (float)(Y), (float)(cellWidth), (float)(cellHeight));
            //////TODO: INSTANT C# TODO TASK: The following line could not be converted:
            ////            Select Case this.get_ColAlignment(i)
            //////TODO: INSTANT C# TODO TASK: The following line could not be converted:
            ////                Case 0

            ////fmt.Alignment = StringAlignment.Center;
            //////TODO: INSTANT C# TODO TASK: The following line could not be converted:
            ////                Case 4

            ////fmt.Alignment = StringAlignment.Center;
            //////TODO: INSTANT C# TODO TASK: The following line could not be converted:
            ////                Case 1

            ////fmt.Alignment = StringAlignment.Near;
            //////TODO: INSTANT C# TODO TASK: The following line could not be converted:
            ////                Case 9
            ////: fmt.Alignment = StringAlignment.Far;
            //            }
            e.Graphics.DrawString(caption, titleFont, titleBrush, RF, fmt);
            X = X + cellWidth;

            //Next;
            //Exit Sub
            //Exit Sub
            cellHeight = tallestHCell;

            int itm = 0;
            int sitm = 0;
            Y = Y + cellHeight + 5; // + vSpacing / 2
            SizeF SF = new SizeF();


            //        for (itm = startItem + 1; itm < this.Rows; itm++)
            //        {
            //            Console.WriteLine(itm);
            //            X = PD.DefaultPageSettings.Margins.Left;
            //            int tallestCell = 0;
            //            for (sitm = 0; sitm < this.get_Cols; sitm++)
            //            {

            //                //End If


            //                caption = this.get_TextMatrix(itm, sitm); //(itm).SubItems(sitm).Text
            //                cellWidth = ColWidths(sitm) * PageWidth / totWidth;
            //                itemFont = this.Font; //(itm).Font
            //                SF = new SizeF((float)(cellWidth), 100F);

            //                txtSize = e.Graphics.MeasureString(caption, itemFont, SF, fmt);
            //                txtSize.Height = txtSize.Height + vSpacing / 2;
            //                if (txtSize.Height > tallestCell)
            //                {
            //                    tallestCell = txtSize.Height;
            //                }
            //                switch (this.get_ColAlignment(sitm))
            //                {
            //                    case 0:

            //fmt.Alignment = StringAlignment.Center;
            //break;
            //                    case 4:

            //fmt.Alignment = StringAlignment.Center;
            //break;
            //                    case 1:

            //fmt.Alignment = StringAlignment.Near;
            //break;
            //                    case 9:

            //fmt.Alignment = StringAlignment.Far;
            //break;
            //                }
            //                RF = new RectangleF((float)(X), (float)(Y), (float)(cellWidth), (float)(txtSize.Height));

            //                e.Graphics.DrawString(caption, itemFont, itemBrush, RF, fmt);

            //                X = X + cellWidth;
            //            }

            //            Y = Y + tallestCell + vSpacing / 2;

            //            if (Y > (0.95 * (PHeight - PD.DefaultPageSettings.Margins.Bottom)) - 100)
            //            {
            //                X = PD.DefaultPageSettings.Margins.Left;
            //                for (var i = 0; i < this.get_Cols; i++)
            //                {
            //                    cellWidth = ColWidths(i) * PageWidth / totWidth;
            //                    X = X + cellWidth;
            //                }

            //                TempLeft = PD.DefaultPageSettings.Margins.Left + (PageWidth / 2);
            //                e.Graphics.DrawLine(Pens.Black, PD.DefaultPageSettings.Margins.Left + TempLeft, (PD.DefaultPageSettings.Margins.Bottom + PageHeight) - 30, PD.DefaultPageSettings.Margins.Left + PageWidth + 1, (PD.DefaultPageSettings.Margins.Bottom + PageHeight) - 30);

            //                RF.X = PD.DefaultPageSettings.Margins.Left;
            //                RF.Y = PD.DefaultPageSettings.Margins.Bottom + PageHeight - 30;
            //                RF.Width = PageWidth;
            //                RF.Height = 20;
            //                fmt.Alignment = StringAlignment.Far;
            //                e.Graphics.DrawString("Collector", new System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), titleBrush, RF, fmt);
            //                //==================
            //                e.HasMorePages = true;
            //                // store the index of the last printed item in the startItem variable
            startItem++;
            //                return;
            //            }
            //        }
            // draw the grid of the last page, which is usually smaller than
            // the other pages
            //Exit Sub
            X = PD.DefaultPageSettings.Margins.Left;
            //for (var i = 0; i < this.get_Cols; i++)
            //{
            //    //e.Graphics.DrawLine(Pens.Red, X, PD.DefaultPageSettings.Margins.Top, X, Y)
            //    cellWidth = ColWidths(i) * PageWidth / totWidth;
            //    X = X + cellWidth;
            //}

            TempLeft = PD.DefaultPageSettings.Margins.Left + (PageWidth / 2);
            e.Graphics.DrawLine(Pens.Black, PD.DefaultPageSettings.Margins.Left + TempLeft, (PD.DefaultPageSettings.Margins.Bottom + PageHeight) - 30, PD.DefaultPageSettings.Margins.Left + PageWidth + 1, (PD.DefaultPageSettings.Margins.Bottom + PageHeight) - 30);

            RF.X = PD.DefaultPageSettings.Margins.Left;
            RF.Y = PD.DefaultPageSettings.Margins.Bottom + PageHeight - 30;
            RF.Width = PageWidth;
            RF.Height = 20;
            fmt.Alignment = StringAlignment.Far;
            e.Graphics.DrawString("Collector", new System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), titleBrush, RF, fmt);
            //==================
            e.HasMorePages = false;
            // Reset the startItem variable so that it's ready for the next printout
            // This is a static variable and won't be reset automatically
            startItem = 0;
        }
    }
}