using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EDPComponent
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        public static bool FormBaseSizeable = true; 
        public Edpcom.EDPCommon EDPComm = new Edpcom.EDPCommon();
        private bool showmin = true, normal = false, showclose = true;
        private int x = 0, y = 0;
        private Point Hold;
        public string HeaderText
        {
            get { return lblHead.Text.Trim(); }
            set { lblHead.Text = "        " + value; }
        }
        public bool ShowMin
        {
            get { return btnMin.Visible; }
            set { btnMin.Visible = value; }
        }
        public bool ShowClose
        {
            get { return btnCl.Visible; }
            set { btnCl.Visible = value; }
        }
        private void FormBase_SizeChanged(object sender, EventArgs e)
        {
            btnCl.Location = new Point(this.Width - 28, 0);
            btnMin.Location = new Point(this.Width - 51, 0);
            if ((this.WindowState == FormWindowState.Normal) && (!normal))
            {
                normal = true;
                this.Text = ""; this.Size = new Size(x, y);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
         //pal   string str= "C://Documents and Settings//PradiptaNT//Desktop//button pics//popover-close-button.gif";
           //pal this.btnCl.BackgroundImage = System.Drawing.Image.FromFile(str);
            //this.Close();
            EDPMessageBox.EDPMessage.Show("Are you sure exit the form?", "Acknowledgment...", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_INFORMATION);
            if (EDPMessageBox.EDPMessage.ButtonResult == "edpYES")
            {
                //this.Dispose();
                this.Close();
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Text = this.HeaderText; normal = false;
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            btnMin.Visible = showmin;
            btnCl.Visible = showclose;
            session.Text = "Session : " + EDPComm.CURRENTSESSION;
            company_name.Text = "User : " + EDPComm.UserDesc;
            branchname.Text = "Branch Name : " + EDPComm.CURRENT_COMPANY + " (" + EDPComm.CurrentFicode + ")";
            EDPComm.UpdateMidasLog(this, true);
            EDPComm.setFormPosition(this);
        }

        private void lblHead_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.SizeAll;
                Hold = new Point(e.X, e.Y);
            }
        }

        private void lblHead_MouseMove(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            if (e.Button == MouseButtons.Left)
            {
                //this.Left += e.X - Hold.X;
                //this.Top += e.Y - Hold.Y;
            }
            this.ResumeLayout();
        }

        private void lblHead_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    Hold = new Point(0, 0);
            //    this.Cursor = Cursors.Default;
            //    Screen.FromControl(this);
            //}
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - Hold.X;
                this.Top += e.Y - Hold.Y;
                this.Cursor = Cursors.Default;
                Screen.FromControl(this);
            }
        }

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
                        //this.Dispose();
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
           // EDPComm.saveFormPosition(this.Name,this.Location);
            EDPComm.saveFormPosition(this.Name, this.Location);
            if (this.Name.ToUpper() != "FRMBILL")
                EDPComm.Form_Controls_Status_Save(this, this.Name);
        }

        private void lblHead_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}