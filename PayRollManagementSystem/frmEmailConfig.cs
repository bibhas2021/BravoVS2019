using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Net.Mail;

namespace PayRollManagementSystem
{
    public partial class frmEmailConfig : Form
    {
        public frmEmailConfig()
        {
            InitializeComponent();
        }
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (TxtEmail.Text.Trim() == "" || txtTo.Text.Trim() == "")
            {
                MessageBox.Show("Check User name / To ", "Bravo");
                return;

            }
            using (MailMessage mm = new MailMessage(TxtEmail.Text.Trim(), txtTo.Text.Trim()))
            {
                mm.Subject = txtSubject.Text;
                mm.Body = txtBody.Text;
                foreach (string filePath in openFileDialog1.FileNames)
                {
                    if (File.Exists(filePath))
                    {
                        string fileName = Path.GetFileName(filePath);
                        mm.Attachments.Add(new Attachment(filePath));
                    }
                }
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = txthost.Text.Trim();
                if (chk_enableSsl.Checked==true)
                smtp.EnableSsl =true;
                else 
                smtp.EnableSsl = false;

                NetworkCredential NetworkCred = new NetworkCredential(TxtEmail.Text.Trim(), txtPassword.Text.Trim());
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = Convert.ToInt32(txtPort.Text);
                try
                {
                    smtp.Send(mm);
                    MessageBox.Show("Email sent.", "Bravo");

                    clsDataAccess.RunQry("INSERT INTO mail_log(mdate, uid, mto, cc, bcc, subject, month)VALUES (GETDATE(),'" + edpcom.UserDesc + "','" + txtTo.Text + "','','','" + txtSubject.Text + "','" + System.DateTime.Now.ToString("MMM-yyyy") + "')");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Bravo");
                }
            }
        }






        private void lnkAttachment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            foreach (string filePath in openFileDialog1.FileNames)
            {
                if (File.Exists(filePath))
                {
                    string fileName = Path.GetFileName(filePath);
                    lblAttachments.Text += fileName + Environment.NewLine;
                }
            }
        }


        public void clear()
        {

         DataTable dt_config=   clsDataAccess.RunQDTbl("SELECT MailSign,usr,pass,host,ssl,port,coid FROM config_mail");
            if (dt_config.Rows.Count > 0)
             {
                txtSignature.Text=dt_config.Rows[0]["MailSign"].ToString();
                TxtEmail.Text = dt_config.Rows[0]["usr"].ToString();
                txtPassword.Text = dt_config.Rows[0]["pass"].ToString();
                txtPort.Text = dt_config.Rows[0]["port"].ToString();
                txthost.Text = dt_config.Rows[0]["host"].ToString();

                if (dt_config.Rows[0]["ssl"].ToString() == "1")
                {
                    chk_enableSsl.Checked = true;
                }
                else
                {
                    chk_enableSsl.Checked = false;
                }

                groupBox1.Visible = true;
             }
             else
             {
                txtSignature.Text="";
                TxtEmail.Text = "";
                txtPassword.Text = "";
                txtPort.Text = "";
                txthost.Text = "";
                chk_enableSsl.Checked = false;
                groupBox1.Visible = false;
             }


            txtTo.Text = "";
            txtSubject.Text = "Test Mail";
            txtBody.Text = "This is a test mail." + Environment.NewLine + "Please check the specified mail.";


        }


        private void frmEmailConfig_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        { DataTable dt_config=   clsDataAccess.RunQDTbl("SELECT MailSign,usr,pass,host,ssl,port,coid FROM config_mail where coid=1");
            if (dt_config.Rows.Count > 0)
             {
                clsDataAccess.RunQry("Delete from config_mail where coid=1");
             }

           string MailSign=txtSignature.Text.Trim(),
            usr=TxtEmail.Text.Trim(),
            pass=txtPassword.Text.Trim(),
            host= txthost.Text,
            port=txtPort.Text.Trim();
            int ssl=0;
            if (chk_enableSsl.Checked == false) {ssl=0; }else {ssl=1;};
            if (MailSign == "" || usr == "" || pass == "" || host == "" || port=="")
            {
                MessageBox.Show("Please fill proper server information", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool bl= clsDataAccess.RunQry("INSERT INTO config_mail(MailSign,usr,pass,host,ssl,port,coid) VALUES ('"+ MailSign +"','"+ usr +"','"+ pass +"','"+ host +"','"+ ssl +"','"+ port +"','1')");

                if (bl == true)
                {
                    MessageBox.Show("Information Saved", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();

                }
            }
        }
    }
}
