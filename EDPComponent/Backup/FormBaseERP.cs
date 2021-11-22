using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
namespace EDPComponent
{
    public partial class FormBaseERP : Form
    {
        private Boolean Max,Min;
        private Boolean normal = false;
        private int x, y;
        public FormBaseERP()
        {
            InitializeComponent();
        }
        public bool ShowMin
        {
            get { return Min; }
            set { Min = value; }
        }
        public bool ShowMax
        {
            get { return Max; }
            set { Max = value; }
        }
        public string HeaderText
        {
            get { return lblHead.Text.Trim(); }
            set { lblHead.Text = value; }
        }
        private void FormBase_SizeChanged(object sender, EventArgs e)
        {
            picMin.Location = new Point(this.Width - 73, 2);
            picMax.Location = new Point(this.Width - 52, 2);
            picClose.Location = new Point(this.Width - 31, 2);
            if ((this.WindowState == FormWindowState.Normal) && (!normal))
            {
                normal = true;
                this.Text = ""; this.Size = new Size(x, y);
            }
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            EDPCommon com = new EDPCommon();
            com.MaketheformMovable(picTitle, this);
            this.Text = "";
            picMin.Enabled = Min;
            picMax.Enabled = Max;
            com.setFormPosition(this);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Text = this.HeaderText; normal = false;
        }

        private void picMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.toolTip1.SetToolTip(this.picMax, "Maximize");
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.toolTip1.SetToolTip(this.picMax, "Normal");
            }
        }

        private void FormBaseERP_Shown(object sender, EventArgs e)
        {
            x = this.Width; y = this.Height;
        }

        private void FormBaseERP_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            EDPCommon com = new EDPCommon();
            com.saveFormPosition(this.Name, this.Location);
        }

        private void FormBaseERP_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch { }
        }

       
    }
}