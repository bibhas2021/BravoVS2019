using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace EDPComponent
{
    public partial class EDPPrintPreviewDialog : PrintPreviewDialog
    {
        public SimpleTextReport str;
        public EDPPrintPreviewDialog()
        {
            InitializeComponent();
            ToolStrip ts = (ToolStrip)this.Controls["toolStrip1"];
            ToolStripComboBox toolStripComboBox1 = new ToolStripComboBox();
            toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            toolStripComboBox1.Items.AddRange(new object[] {
            "DOS Print",
            "Graphical Print"});
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            ToolStripSeparator tsp = new ToolStripSeparator();
            ts.Items.Add(tsp);
            ts.Items.Add(toolStripComboBox1);
            ToolStripButton tsbExport = new ToolStripButton();
            tsbExport.Text = "Export";
            tsbExport.Click += new EventHandler(tsbExport_Click);
            ts.Items.Add(tsp);
            ts.Items.Add(tsbExport);
            ts.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            ToolStripManager.Renderer = new EDPMenuRenderer();
        }

        void tsbExport_Click(object sender, EventArgs e)
        {
            PrintDocument pvd = this.Document;
            string str = pvd.ToString();
        }
         
        void btn_Click(object sender, EventArgs e)
        {
            ToolStrip ts = (ToolStrip)this.Controls["toolStrip1"];
            ToolStripButton btn = (ToolStripButton)ts.Items[0];
            ToolStripComboBox toolStripComboBox1 = (ToolStripComboBox)ts.Items["toolStripComboBox1"];
            if (toolStripComboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select one Printing Type","Please Select");
                toolStripComboBox1.Focus();
            }
            else if (toolStripComboBox1.SelectedIndex == 0) // DOS Print
            {
                str.Print();
            }
            else if (toolStripComboBox1.SelectedIndex == 1) // Windows Print
            {
                btn.PerformClick();
            }
        }

        private void EDPPrintPreviewDialog_Load(object sender, EventArgs e)
        {
            ToolStrip ts = (ToolStrip)this.Controls["toolStrip1"];
            Form frm = (Form)ts.Parent;
            frm.WindowState = FormWindowState.Maximized;

            //new CrystalDecisions.CrystalReports.Engine.
            //this.Document.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PageSetupDialog pst = new PageSetupDialog();
            pst.PageSettings = this.Document.DefaultPageSettings;
            pst.ShowDialog();
            this.Document.DefaultPageSettings = pst.PageSettings;
        }
    }
}
