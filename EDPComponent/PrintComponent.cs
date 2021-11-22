using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Drawing.Printing;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace EDPComponent
{
    public class PrintComponent : DataGridView
    {

        PrintDocument PD;
        public string Header1;
        public string Header2;
        public string Header3;
        public string SchoolName;
        public string CircleName;
        public string EmpRegNo;
        public string AcadYear;
        private PageSetupDialog PSetup = new PageSetupDialog();
        private EDPPrintPreviewDialog PrV = new EDPPrintPreviewDialog();
        private int vSpacing = 6;
        Int32 startItem = 0;
        public DataTable PrintDataTable;
        ToolStripComboBox toolStripComboBox1;
        public SimpleTextReport.TMainPageHeaders mph;
        public SimpleTextReport.TCustomisedSections cms;
        public SimpleTextReport str;
        //Dim BillCategNo As Integer = 1


        #region  Component Designer generated code

        public PrintComponent(System.ComponentModel.IContainer Container)
            : this()
        //TODO: INSTANT C# TODO TASK: C# does not have an equivalent to VB.NET's 'MyClass' keyword
        //ORIGINAL LINE: MyClass.New()
        {

            //Required for Windows.Forms Class Composition Designer support
        }

        public PrintComponent()
            : base()
        {

            //This call is required by the Component Designer.
            //InitializeComponent();

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
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            //PD.PrintPage += PD_PrintPage;

        }

        #endregion

        //TODO: INSTANT C# TODO TASK: Insert the following converted event handler wireups at the end of the 'InitializeComponent' method for forms, 'Page_Init' for web pages, or into a constructor for other classes:

        //INSTANT C# NOTE: These were formerly VB static local variables:
        //private int PD_PrintPage_startItem;

        public void Print()
        {
            DialogResult PrntDlgRslt = 0;

            PD = new PrintDocument();
            PD.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PD_PrintPage);
            this.DataSource = PrintDataTable;
            PSetup.PageSettings = PD.DefaultPageSettings;
            PrntDlgRslt = PSetup.ShowDialog();
            if (PrntDlgRslt == DialogResult.Cancel)
            {
                return;
            }

            PrV.Document = PD;
            PrV.str = str;
            PrV.ShowDialog();

        }

        private void PD_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int[] ColWidths = new int[this.Columns.Count];


            int i = 0;
            int totWidth = 0;
            for (i = 0; i < this.Columns.Count; i++)
            {
                ColWidths[i] = this.Columns[i].Width;
                totWidth = totWidth + ColWidths[i];
            }

            int X = 0;
            float Y = 0;
            float ColSepTop = 0;
            int cellWidth = 0;
            float cellHeight = 0;
            X = PD.DefaultPageSettings.Margins.Left;
            Y = PD.DefaultPageSettings.Margins.Top;
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


            RectangleF RF = new RectangleF();
            string caption = null;
            Font titleFont = this.Font;
            Font itemFont = null;
            SolidBrush titleBrush = new SolidBrush(Color.Black);
            System.Drawing.Brush itemBrush = null;
            itemBrush = Brushes.Black;
            Pen borderPen = new Pen(Color.Black, 1F);
            //int txtWidth = 0;
            int TempLeft = 0;
            StringFormat fmt = new StringFormat();
            SizeF txtSize = new SizeF();


            RF = new RectangleF((float)(X), (float)(Y - 30), (float)(PageWidth), 36F);

            fmt.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(Header1, new System.Drawing.Font("Courier New", 10.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), titleBrush, RF, fmt);
            RF = new RectangleF((float)(X), (float)(Y - 15), (float)(PageWidth), 36F);
            e.Graphics.DrawString(Header2, new System.Drawing.Font("Courier New", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), titleBrush, RF, fmt);
            RF = new RectangleF((float)(X), (float)(Y), (float)(PageWidth), 36F);
            e.Graphics.DrawString(Header3, new System.Drawing.Font("Courier New", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), titleBrush, RF, fmt);

            fmt.Alignment = StringAlignment.Far;
            RF.Height = 26;

            fmt.Alignment = StringAlignment.Near;
            fmt.Alignment = StringAlignment.Center;


            RF.Y = Y;

            fmt.Alignment = StringAlignment.Near;

            Y = Y + 20;
            RF.Y = Y;
            int Cnt = 0;


            for (Cnt = 0; Cnt < mph.Count; Cnt++)
            {
                caption = mph[Cnt].Text;
                if (caption != null)
                    caption = caption.Replace("^", "");
                txtSize = e.Graphics.MeasureString(caption, titleFont);
                TempLeft = Convert.ToInt32(txtSize.Width);
                e.Graphics.DrawString(caption, new System.Drawing.Font("Courier New", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0)), System.Drawing.Brushes.Black, RF, fmt);
                Y = Y + 12;
                RF.Y = Y;
            }
            RF.X = RF.X + TempLeft;

            RF.Width = txtSize.Width;
            TempLeft = Convert.ToInt32(txtSize.Width); //+ PD.DefaultPageSettings.Margins.Left




            RF.X = RF.X + TempLeft;

            fmt.Alignment = StringAlignment.Near;

            Y = RF.Y - 10;

            //=======End Header========


            fmt.Alignment = StringAlignment.Center; //'TextAlign = HorizontalAlignment.Center
            titleFont = new System.Drawing.Font("Courier New", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));

            e.Graphics.DrawLine(Pens.Black, PD.DefaultPageSettings.Margins.Left, Y + RF.Height, PD.DefaultPageSettings.Margins.Left + PageWidth, Y + RF.Height);

            Y = Y + RF.Height; // + vSpacing / 2
            ColSepTop = Y;
           // int tallestHCell = 0;

            SizeF SF = new SizeF();
            int tallestCell = 0;
            for (i = 0; i < this.Columns.Count; i++)
            {

                //
                caption = this.str.ReportColumns[i].Header.Text[0].ToString(); //(itm).SubItems(sitm).Text
                caption = caption.Replace("^", "");
                cellWidth = ColWidths[i] * PageWidth / totWidth;
                itemFont = this.Font; //(itm).Font
                SF = new SizeF((float)(cellWidth), 100F);

                txtSize = e.Graphics.MeasureString(caption, itemFont, SF, fmt);
                txtSize.Height = txtSize.Height + vSpacing / 2;
                if (txtSize.Height > tallestCell)
                {
                    tallestCell = Convert.ToInt32(txtSize.Height);
                }

                fmt.Alignment = StringAlignment.Near;

                RF = new RectangleF((float)(X), (float)(Y), (float)(cellWidth), (float)(txtSize.Height));

                e.Graphics.DrawString(caption, itemFont, itemBrush, RF, fmt);
                X = X + cellWidth;

            }


            cellHeight = tallestCell;

            int itm = 0;
            int sitm = 0;
            Y = Y + cellHeight + 5; // + vSpacing / 2+ tallestHCell


            for (itm = startItem; itm < this.Rows.Count - 1; itm++)
            {
                Console.WriteLine(itm);
                X = PD.DefaultPageSettings.Margins.Left;
                tallestCell = 0;
                for (sitm = 0; sitm < this.Columns.Count; sitm++)
                {

                    //
                    caption = this.Rows[itm].Cells[sitm].Value.ToString(); //(itm).SubItems(sitm).Text
                    caption = caption.Replace("^", "");
                    cellWidth = ColWidths[sitm] * PageWidth / totWidth;
                    itemFont = this.Font; //(itm).Font
                    SF = new SizeF((float)(cellWidth), 100F);

                    txtSize = e.Graphics.MeasureString(caption, itemFont, SF, fmt);
                    txtSize.Height = txtSize.Height + vSpacing / 2;
                    if (txtSize.Height > tallestCell)
                    {
                        tallestCell = Convert.ToInt32(txtSize.Height);
                    }

                    fmt.Alignment = StringAlignment.Near;

                    RF = new RectangleF((float)(X), (float)(Y), (float)(cellWidth), (float)(txtSize.Height));

                    e.Graphics.DrawString(caption, itemFont, itemBrush, RF, fmt);
                    e.Graphics.DrawLine(Pens.Black, PD.DefaultPageSettings.Margins.Left, Y, PD.DefaultPageSettings.Margins.Left + PageWidth, Y);

                    X = X + cellWidth;
                }

                Y = Y + tallestCell + vSpacing / 2;

                if (Y > (0.95 * (PHeight - PD.DefaultPageSettings.Margins.Bottom)) - 100)
                {
                    X = PD.DefaultPageSettings.Margins.Left;
                    for (i = 0; i < this.Columns.Count; i++)
                    {
                        e.Graphics.DrawLine(Pens.Black, X, ColSepTop, X, Y);
                        cellWidth = ColWidths[i] * PageWidth / totWidth;
                        X = X + cellWidth;
                    }

                    TempLeft = PD.DefaultPageSettings.Margins.Left + (PageWidth / 2);


                    e.Graphics.DrawLine(Pens.Black, PD.DefaultPageSettings.Margins.Left + PageWidth + 1, +
                    ColSepTop, PD.DefaultPageSettings.Margins.Left + PageWidth + 1, Y);

                    e.Graphics.DrawLine(Pens.Black, PD.DefaultPageSettings.Margins.Left, +
                        Y, PD.DefaultPageSettings.Margins.Left + PageWidth, Y);

                    RF.X = PD.DefaultPageSettings.Margins.Left;
                    RF.Y = PD.DefaultPageSettings.Margins.Bottom + PageHeight - 30;
                    RF.Width = PageWidth;
                    RF.Height = 20;
                    fmt.Alignment = StringAlignment.Far;


                    e.HasMorePages = true;

                    itm++;
                    startItem = itm;

                    return;
                }
            }
            //draw the grid of the last page, which is usually smaller than
            //the other pages
            //Exit Sub
            X = PD.DefaultPageSettings.Margins.Left;

            //PD.DefaultPageSettings.Margins.Top
            for (i = 0; i < this.Columns.Count; i++)
            {
                e.Graphics.DrawLine(Pens.Black, X, ColSepTop, X, Y);
                cellWidth = ColWidths[i] * PageWidth / totWidth;//
                X = X + cellWidth;
            }

            // TempLeft = PD.DefaultPageSettings.Margins.Left + (PageWidth / 2);
            e.Graphics.DrawLine(Pens.Black, PD.DefaultPageSettings.Margins.Left + PageWidth + 1, +
                ColSepTop, PD.DefaultPageSettings.Margins.Left + PageWidth + 1, Y);


            e.Graphics.DrawLine(Pens.Black, PD.DefaultPageSettings.Margins.Left, Y, PD.DefaultPageSettings.Margins.Left + PageWidth, Y);

            RF.X = PD.DefaultPageSettings.Margins.Left;
            RF.Y = PD.DefaultPageSettings.Margins.Bottom + PageHeight - 30;
            RF.Width = PageWidth;
            RF.Height = 20;
            fmt.Alignment = StringAlignment.Far;

            e.HasMorePages = false;
            startItem = 0;

        }


        enum PutTextAlign
        {
            Center,
            Left
        }

        public static SqlConnection SqlConn(string DataBaseName)
        {
            SqlConnection DataConn = new SqlConnection("Integrated Security=SSPI;" +
                "Persist Security Info=False;Initial Catalog=" + DataBaseName + ";Data Source=.\\SQLEXPRESS");
            if (DataConn.State == ConnectionState.Connecting || DataConn.State == ConnectionState.Open)
            {
                DataConn.Close();
            }
            DataConn.Open();
            return DataConn;
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SS");

        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select printing type...");
                return;
            }
            if (toolStripComboBox1.SelectedIndex == 0)
            {
                SimpleTextReport ArrearPS = new SimpleTextReport();

                //   ArrearPS = Prnt.GetPrint(PrintDataTable);
                ArrearPS.Print();

            }
            else
            {
                PD.Print();
            }


        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //this.Dispose();

        }


    }


}
