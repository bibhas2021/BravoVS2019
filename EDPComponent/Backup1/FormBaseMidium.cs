using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EDPMessageBox;
//sing System.Runtime.InteropServices;

namespace EDPComponent
{
    public partial class FormBaseMidium : Form
    {
        public FormBaseMidium()
        {
            InitializeComponent();
            if (FormBase.FormBaseSizeable == false)
            {
                this.MaximumSize = new Size(465, 365);
                this.MinimumSize = new Size(465, 365);
            }
            this.ShowInTaskbar = false;
            this.KeyPreview = true;
        }
        
        public Edpcom.EDPCommon EDPComm = new Edpcom.EDPCommon();
        private bool showmin = true, normal = false, showclose = true;
        private int x = 465, y = 365;
        private Point Hold;        

        //[DllImport("User32.dll", CharSet = CharSet.Auto)]
        //public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        //[DllImport("User32.dll")]
        //private static extern IntPtr GetWindowDC(IntPtr hWnd);

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    const int WM_NCPAINT = 0x85;
        //    if (m.Msg == WM_NCPAINT)
        //    {
        //        IntPtr hdc = GetWindowDC(m.HWnd);
        //        if ((int)hdc != 0)
        //        {
        //            Graphics g = Graphics.FromHdc(hdc);
        //            g.FillRectangle(Brushes.LightSteelBlue, new Rectangle(0, 0, 3800, 29));
        //            g.Flush();
        //            ReleaseDC(m.HWnd, hdc);
        //        }
        //    }
        //}

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            FormBase.FormBaseSizeable = false;
        }

        //public string HeaderText
        //{
        //    get { return lblHead.Text.Trim(); }
        //    set { lblHead.Text = "        " + value; }
        //}
        //public bool ShowMin
        //{
        //    get { return btnMin.Visible; }
        //    set { btnMin.Visible = value; }
        //}
        //public bool ShowClose
        //{
        //    get { return btnCl.Visible; }
        //    set { btnCl.Visible = value; }
        //}
        private void FormBase_SizeChanged(object sender, EventArgs e)
        {
            //btnCl.Location = new Point(this.Width - 28, 0);
            //btnMin.Location = new Point(this.Width - 56, 0);
            if ((this.WindowState == FormWindowState.Normal) && (!normal))
            {
                normal = true;
                this.Text = ""; //this.Size = new Size(x, y);
                //this.Size = new Size(465, 365);
            }
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                //this.Close();
            }
        }

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void btnMin_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Minimized;
        //    this.Text = this.HeaderText; normal = false;
        //}

        private void FormBase_Load(object sender, EventArgs e)
        {
            //btnMin.Visible = showmin;
            //btnCl.Visible = showclose;
            session.Text = "Session : " + EDPComm.CURRENTSESSION;
            company_name.Text = " User : " + EDPComm.UserDesc;
            branchname.Text = " Branch Name : " + EDPComm.CURRENT_COMPANY + " (" + EDPComm.CurrentFicode + ")";
            EDPComm.UpdateAccordFourLog(this, true);
            EDPComm.setFormPosition(this);
            if (this.Name.ToUpper() == "")
                EDPComm.Form_Controls_Status_Read(this, this.Name);
        }

        //private void lblHead_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        this.Cursor = Cursors.SizeAll;
        //        Hold = new Point(e.X, e.Y);
        //    }
        //}

        //private void lblHead_MouseMove(object sender, MouseEventArgs e)
        //{
        //    this.SuspendLayout();
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        //this.Left += e.X - Hold.X;
        //        //this.Top += e.Y - Hold.Y;
        //    }
        //    this.ResumeLayout();
        //}

        //private void lblHead_MouseUp(object sender, MouseEventArgs e)
        //{
        //    //if (e.Button == MouseButtons.Left)
        //    //{
        //    //    Hold = new Point(0, 0);
        //    //    this.Cursor = Cursors.Default;
        //    //    Screen.FromControl(this);
        //    //}
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        this.Left += e.X - Hold.X;
        //        this.Top += e.Y - Hold.Y;
        //        this.Cursor = Cursors.Default;
        //        Screen.FromControl(this);
        //    }
        //}

        private void FormBase_Shown(object sender, EventArgs e)
        {
            session.Width = this.Width / 3;
            company_name.Width = this.Width / 3;
            branchname.Width = this.Width / 3;
            x = this.Width; y = this.Height;
        }

        private void FormBase_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    EDPMessageBox.EDPMessage.Show("Are you sure exit the form?", "Acknowledgment...", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                    if (EDPMessageBox.EDPMessage.ButtonResult == "edpYES")
                    {
                        this.Close();
                    }
                }

                //if (e.KeyCode == Keys.Enter)
                //{
                //    SendKeys.Send("{Tab}");
                //}
            }
            catch { }
        }

        private void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {            
            EDPComm.saveFormPosition(this.Name, this.Location);
            EDPComm.Form_Controls_Status_Save(this, this.Name);
            //this.Dispose();
        }

        private void myXPButton3_Click(object sender, EventArgs e)
        {
            //string aa = MessageBox.Show("Are you sure exit the form?", "Acknowledgment...", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            //if (aa == System.Windows.Forms.DialogResult.Yes.ToString())
            //this.Close();
            EDPMessageBox.EDPMessage.Show("Are you sure exit the form?", "Acknowledgment...", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_INFORMATION);
            if (EDPMessageBox.EDPMessage.ButtonResult == "edpYES")
            {
                //this.Dispose();
                this.Close();
            }
        }

        private void myXPButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            normal = false;
        }

    }
}