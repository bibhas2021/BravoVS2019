using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.VisualBasic;
using System.IO;
using Edpcom;
using EDPComponent;
using EDPMessageBox;
using System.Threading;
using EDPProgressBar;
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace Utility
{
    public partial class FrmGlobalBackup : FormBase
    {
        public FrmGlobalBackup()
        {
            InitializeComponent();
        }

        Edpcom.EDPCommon com = new EDPCommon();
        Edpcom.EDPConnection mycon = new EDPConnection();
        string constr = null;
        string Ficode, Gcode, exe_ver;
        DateTime buildt;
        SqlDataAdapter myda = new SqlDataAdapter();
        SqlCommand mycmd;
        DataSet myds = new DataSet();
        ArrayList myarr = new ArrayList();
        Hashtable myhashtb = new Hashtable();
        GroupBox grpbxBackdet = new GroupBox();
        Label lblbckupno = new Label();
        TextBox txtbckno = new TextBox();
        Label lblbckdt = new Label();
        TextBox txtbckdt = new TextBox();
        Label lblver = new Label();
        TextBox txtver = new TextBox();
        Label lblbuilddt = new Label();
        TextBox txtbuilddt = new TextBox();
        Label lblbckpath = new Label();
        TextBox txtbckpath = new TextBox();
        EDPComponent.VistaButton btnpath = new VistaButton();
        EDPComponent.VistaButton btnok = new VistaButton();
        EDPComponent.VistaButton btnclose = new VistaButton();
        SaveFileDialog svpath = new SaveFileDialog();
        SqlConnection sqlCn = new SqlConnection("Initial Catalog=;Integrated Security=True;pooling=true;");
        SaveFileDialog sfdBackupDatabase = new SaveFileDialog();
        OpenFileDialog ofdRestoreDatabase = new OpenFileDialog();


        public void Full_Back_Data()
        {
            //for groupbox

            this.grpbxBackdet.Font = new Font("Tahoma", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxBackdet.Location = new Point(9, 82);
            this.grpbxBackdet.ForeColor = Color.Black;
            this.grpbxBackdet.Size = new Size(463, 109);
            this.grpbxBackdet.TabIndex = 5;
            this.grpbxBackdet.TabStop = false;
            this.grpbxBackdet.Text = "Backup Details";
            this.Controls.Add(grpbxBackdet);
            // lblbckupno
            this.lblbckupno.AutoSize = true;
            this.lblbckupno.Font = new Font("Tahoma", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbckupno.Location = new Point(6, 23);
            this.lblbckupno.Size = new Size(76, 16);
            this.lblbckupno.TabIndex = 4;
            this.lblbckupno.Text = "Backup No.";
            grpbxBackdet.Controls.Add(lblbckupno);
            // txtbckno
            this.txtbckno.Location = new Point(88, 18);
            this.txtbckno.ReadOnly = true;
            this.txtbckno.Size = new Size(136, 23);
            this.txtbckno.TabIndex = 6;
            grpbxBackdet.Controls.Add(txtbckno);
            // lblbckdt
            this.lblbckdt.AutoSize = true;
            this.lblbckdt.Font = new Font("Tahoma", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbckdt.Location = new Point(230, 19);
            this.lblbckdt.Size = new Size(84, 16);
            this.lblbckdt.TabIndex = 7;
            this.lblbckdt.Text = "Backup Date";
            grpbxBackdet.Controls.Add(lblbckdt);
            //txtbckdt
            this.txtbckdt.Location = new Point(323, 18);
            this.txtbckdt.ReadOnly = true;
            this.txtbckdt.Size = new Size(136, 23);
            this.txtbckdt.TabIndex = 8;
            grpbxBackdet.Controls.Add(txtbckdt);
            // lblver
            this.lblver.AutoSize = true;
            this.lblver.Location = new Point(6, 48);
            this.lblver.Size = new Size(59, 18);
            this.lblver.TabIndex = 6;
            this.lblver.Text = "Version";
            grpbxBackdet.Controls.Add(lblver);
            // txtver
            this.txtver.Location = new Point(88, 48);
            this.txtver.ReadOnly = true;
            this.txtver.Size = new Size(136, 23);
            this.txtver.TabIndex = 9;
            grpbxBackdet.Controls.Add(txtver);
            // lblbuilddt
            this.lblbuilddt.AutoSize = true;
            this.lblbuilddt.Location = new Point(230, 48);
            this.lblbuilddt.Size = new Size(77, 18);
            this.lblbuilddt.TabIndex = 10;
            this.lblbuilddt.Text = "Build Date";
            grpbxBackdet.Controls.Add(lblbuilddt);
            //txtbuilddt
            this.txtbuilddt.Location = new Point(323, 48);
            this.txtbuilddt.ReadOnly = true;
            this.txtbuilddt.Size = new Size(136, 23);
            this.txtbuilddt.TabIndex = 9;
            grpbxBackdet.Controls.Add(txtbuilddt);

            this.lblbckpath.AutoSize = true;
            this.lblbckpath.Location = new Point(6, 78);
            this.lblbckpath.Size = new Size(86, 18);
            this.lblbckpath.TabIndex = 16;
            this.lblbckpath.Text = "Backup File";
            grpbxBackdet.Controls.Add(lblbckpath);
            this.txtbckpath.Location = new Point(88, 76);
            this.txtbckpath.Size = new Size(324, 23);
            this.txtbckpath.TabIndex = 6;
            grpbxBackdet.Controls.Add(txtbckpath);
            this.btnpath.Image = Properties.Resources.openHS;// global::RestorBack.Properties.Resources.openHS;
            this.btnpath.ImageSize = new Size(18, 18);
            this.btnpath.ImageAlign = ContentAlignment.MiddleCenter;
            this.btnpath.Location = new Point(416, 74);
            this.btnpath.Size = new Size(42, 23);
            this.btnpath.CornerRadius = 4;
            this.btnpath.ButtonColor = Color.CornflowerBlue;
            this.btnpath.GlowColor = Color.White;
            this.btnpath.TabIndex = 17;
            grpbxBackdet.Controls.Add(btnpath);
            this.btnpath.Click += new System.EventHandler(this.btnpath_Click);
            this.btnok.Location = new Point(310, 195);
            this.Controls.Add(btnok);
            this.btnclose.Location = new Point(393, 195);
            this.Size = new Size(500, 290);

        }

        private void btnpath_Click(object sender, EventArgs e)
        {
            try
            {
                svpath.OverwritePrompt = false;
                svpath.Filter = com.ApplicationName + " Backup File (*." + com.ApplicationExtension + ")|*." + com.ApplicationExtension;
                svpath.ShowDialog();
                if (svpath.FileName.ToString().Length == 0)
                {
                }
                else
                {
                    txtbckpath.Text = svpath.FileName.ToString();
                    string[] s = new string[] { };
                    s = txtbckpath.Text.Trim().Split('\\');
                    if (s.Length < 3)
                    {
                        EDPMessageBox.EDPMessage.Show("BackUp Path Not Correct \n ex. D:\\BackUp\\AccordFourBackUp");
                        txtbckpath.Text = "";
                        btnpath_Click(sender, e);
                    }
                }
            }
            catch
            {
            }
        }
        //private void company_treview()
        //{
        //    if (Information.IsNothing(myds.Tables["gcode1"]) == false)
        //    {
        //        myds.Tables["gcode1"].Clear();
        //    }
        //    tvcmpperiod.Nodes.Clear();
        //    myhashtb.Clear();
        //    myarr.Clear();
        //    mycon.Open();
        //    mycmd = new SqlCommand("Select distinct gcode from Company", mycon);
        //    myda.SelectCommand=mycmd;
        //    myda.Fill(myds, "gcode1");
        //    mycon.Close();
        //    int count = myds.Tables["gcode1"].Rows.Count - 1;
        //    int i=0;
        //    while (i <= count)
        //    {
        //        myarr.Add(myds.Tables["gcode1"].Rows[i][0]);
        //        i++;
        //    }
        //    count = myarr.Count - 1;
        //    i = 0;
        //    while (i <= count)
        //    {
        //        string gcode = Convert.ToString(myarr[i]);
        //        mycon.Open();
        //        mycmd = new SqlCommand("select ficode from company where gcode='" + gcode + " '", mycon);
        //        myda.SelectCommand = mycmd;
        //        myda.Fill(myds, "ficode");
        //        mycmd = new SqlCommand("select co_name from company where gcode='" + gcode + " '", mycon);
        //        mydr = mycmd.ExecuteReader();
        //        mydr.Read();
        //        myhashtb.Add(mydr.GetString(0), gcode);
        //        tvcmpperiod.Nodes.Add(mydr.GetString(0));
        //        mydr.Close();
        //        mycon.Close();
        //        TreeNode tn = new TreeNode();
        //        tn = tvcmpperiod.Nodes[i];
        //        for (int j = 0; j <= myds.Tables["ficode"].Rows.Count - 1; j++)
        //        {
        //            mycon.Open();
        //            mycmd = new SqlCommand("select co_sdate,co_edate from company where GCODE='" + gcode + "' and ficode='" + myds.Tables["ficode"].Rows[j][0].ToString() + "'", mycon);
        //           myda.SelectCommand = mycmd;
        //           myda.Fill(myds, "sdt_edt");
        //           string std_edt = Convert.ToDateTime(myds.Tables["sdt_edt"].Rows[0][0]).ToShortDateString() + "--" + Convert.ToDateTime(myds.Tables["sdt_edt"].Rows[0][1]).ToShortDateString();
        //           tn.Nodes.Add(std_edt);
        //           myds.Tables["sdt_edt"].Clear();
        //           mycon.Close();
        //        }
        //        tvcmpperiod.ExpandAll();
        //        myds.Tables["ficode"].Clear();
        //        i++;
        //    }
        // }

        private void grpbxBackdet_Enter(object sender, EventArgs e)
        {

        }
        private void frmRestrBack_Load(object sender, EventArgs e)
        {
            rbfullbckup.Checked = true;
            this.BackColor = Color.FromArgb(com.Get_Color[0], com.Get_Color[1], com.Get_Color[2]);
            this.Text = com.ApplicationName + " Database BackUp";
            groupBox1.Width = 465;
        }

        public void pass_value(string ficod, string gcod, string constr1, string ExeVersion1, DateTime BuildDate1)
        {
            constr = constr1;
            Ficode = ficod;
            Gcode = gcod;
            exe_ver = ExeVersion1;
            buildt = BuildDate1;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            string path = txtbckpath.Text;

            if (File.Exists(path) == true)
            {
                //MessageBox.Show("File already exist","Information");
                EDPMessage.Show("File Already Exist. Do you want to replace it?", "Information", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                String aa = EDPMessageBox.EDPMessage.ButtonResult;
                if (aa == "edpYES")
                {
                    File.Delete(path);
                    string[] path1 = new string[] { };
                    path1 = path.Split('.');
                    string pp = path1[0].ToString() + ".txt";
                    File.Delete(pp);
                    BackUp();
                }
                else
                {
                    return;
                }
            }
            else
            {
                BackUp();
            }

        }

        protected void NotePad_Page_Load(string Load_Path)
        {
            string MN = "Machine Name  : " + Environment.MachineName;
            string UN = "User Name     : " + com.UserDesc;
            string BD = "Build Date    : " + com.PBUILD_DATE;
            string BUD = "Back Up Date : " + System.DateTime.Now.Date;
            string BUT = "Back Up Time : " + System.DateTime.Now.TimeOfDay;

            string fp = Load_Path + ".txt";
            //string filePath = @"E:Employee.txt";

            string filePath = @fp;


            if (File.Exists(filePath))
            {
                //StreamWriter SW;
                //SW = File.CreateText(filePath);
                //SW.Write(text);
                //SW.Close();
                FileStream aFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(aFile);
                sw.WriteLine(MN);
                sw.WriteLine(UN);
                sw.WriteLine(BD);
                sw.WriteLine(BUD);
                sw.WriteLine(BUT);
                sw.WriteLine("**********************************************************************");

                sw.Close();
                aFile.Close();
            }
            else
            {
                //sw.Write(text);
                //sw.Flush();
                //sw.Close();
                //StreamWriter SW;
                //SW = File.AppendText(filePath);
                //SW.WriteLine(text);
                //SW.Close();

                FileStream aFile = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(aFile);

                sw.WriteLine(MN);
                sw.WriteLine(UN);
                sw.WriteLine(BD);
                sw.WriteLine(BUD);
                sw.WriteLine(BUT);
                sw.WriteLine("**********************************************************************");

                sw.Close();
                aFile.Close();
                //System.IO.File.WriteAllText(filePath, text);
            }
            //Response.Write("Employee Add Successfully.........");
        }

        private void BackUp()
        {
            string path = txtbckpath.Text;
            string[] path1 = new string[] { };
            path1 = path.Split('.');

            string pp = path1[0].ToString();
            NotePad_Page_Load(pp);
            System.Diagnostics.Process.Start("notepad.exe", @pp);
            mycon.Open();
            mycmd = new SqlCommand("backup database " + com.PDATABASE_NAME + " to disk='" + path + " '", mycon.mycon);
            try
            {
                mycmd.CommandTimeout = 0;
                mycmd.ExecuteNonQuery();

                string zipFileName = path + ".zip";
                using (FileStream __fStream = File.Open(zipFileName, FileMode.Create))
                {
                    GZipStream obj = new GZipStream(__fStream, CompressionMode.Compress);

                    byte[] bt = File.ReadAllBytes(path);
                    obj.Write(bt, 0, bt.Length);
                    obj.Close();
                    obj.Dispose();
                }
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(path);

                mycmd = new SqlCommand("SELECT table_name from information_schema.tables WHERE table_type ='base table'", mycon.mycon);
                myda.SelectCommand = mycmd;
                myda.Fill(myds, "CNT");
                EDPProgressBar.ThreadingProgress ThrdProgrs = new ThreadingProgress(myds.Tables["CNT"]);
                ThrdProgrs.ShowDialog();
                EDPMessage.Show("Backup Successfully", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_OK);
                mycon.Close();
            }
            catch (Exception ex)
            {
                mycon.Close();
                //EDPMessage.Show(ex.Message, "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_OK);
                EDPMessageBox.EDPMessage.Show("Your Data Size has Exceeded 1 GB.This is not Supported by the current version of Accord Four...Contact Support@edpsoft.com for further details ", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
        }

        private void rbotherbckup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbotherbckup.Checked == true)
            {
                this.Size = new Size(500, 290);
                btnok.Location = new Point(250, 373);
                btnclose.Location = new Point(334, 373);
                grpbxBackdet.Enabled = false;
                grpbxBackdet.Visible = false;
            }
        }

        private void rbfullbckup_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbfullbckup.Checked == true)
                {
                    grpbxBackdet.Enabled = true;
                    grpbxBackdet.Visible = true;
                    Full_Back_Data();
                    txtbckno.Text = "1";
                    txtbckdt.Text = DateAndTime.Now.ToShortDateString();
                    txtbuilddt.Text = com.PBUILD_DATE.ToShortDateString();
                    txtver.Text = com.PEXE_VERSION;
                    string backpath = Environment.CurrentDirectory + "\\" + "Backup";
                    if (!Microsoft.VisualBasic.FileIO.FileSystem.DirectoryExists(backpath))
                        Microsoft.VisualBasic.FileIO.FileSystem.CreateDirectory(backpath);
                    txtbckpath.Text = Environment.CurrentDirectory + "\\" + "Backup" + "\\" + com.ApplicationName + "." + com.ApplicationExtension;
                }
            }
            catch { }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBackUp_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.Close();
            //}
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }               

    }
}