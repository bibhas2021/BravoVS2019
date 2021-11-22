using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Server;
using Edpcom;
using System.Diagnostics;
using System.Threading;
using EDPComponent;
using EDPMessageBox;
namespace Utility
{
    public partial class frmRestore : EDPComponent.FormBase
    {
        Edpcom.EDPCommon com = new EDPCommon();
        SqlConnection mycon = new SqlConnection();//" Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Master;Data Source=SANDIP");
        SqlDataAdapter myda = new SqlDataAdapter();
        DataSet myds = new DataSet();
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
        //MyXPButton btnpath = new MyXPButton();
        EDPComponent.VistaButton btnpath = new VistaButton();
        EDPComponent.VistaButton btnok = new VistaButton();
        EDPComponent.VistaButton btnclose = new VistaButton();
        //MyXPButton btnok = new MyXPButton();
        //MyXPButton btnclose = new MyXPButton();
        OpenFileDialog svpath = new OpenFileDialog();
        EDPComponent.ProgressBar pr = new EDPComponent.ProgressBar();

        public EDPVersion.versionEDP version1 = new EDPVersion.versionEDP();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();      
        
        Thread th;
        public frmRestore()
        {
            InitializeComponent();
        }

        public void Full_Back_Data()
        {
            //for groupbox

            grpbxBackdet.Font = new Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            grpbxBackdet.Location = new Point(7, 82);
            grpbxBackdet.Size = new Size(463, 109);
            grpbxBackdet.ForeColor = Color.Black;
            grpbxBackdet.TabIndex = 5;
            grpbxBackdet.TabStop = false;
            grpbxBackdet.Text = "Backup Details";
            Controls.Add(grpbxBackdet);
            // lblbckupno
            lblbckupno.AutoSize = true;
            lblbckupno.Font = new Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblbckupno.Location = new Point(6, 23);
            lblbckupno.Size = new Size(76, 16);
            lblbckupno.TabIndex = 4;
            lblbckupno.Text = "Backup No.";
            grpbxBackdet.Controls.Add(lblbckupno);
            // txtbckno
            txtbckno.Location = new Point(88, 18);
            txtbckno.ReadOnly = true;
            txtbckno.Size = new Size(136, 23);
            txtbckno.TabIndex = 6;
            grpbxBackdet.Controls.Add(txtbckno);
            // lblbckdt
            lblbckdt.AutoSize = true;
            lblbckdt.Font = new Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblbckdt.Location = new Point(230, 19);
            lblbckdt.Size = new Size(84, 16);
            lblbckdt.TabIndex = 7;
            lblbckdt.Text = "Backup Date";
            grpbxBackdet.Controls.Add(lblbckdt);
            //txtbckdt
            txtbckdt.Location = new Point(323, 18);
            txtbckdt.ReadOnly = true;
            txtbckdt.Size = new Size(136, 23);
            txtbckdt.TabIndex = 8;
            grpbxBackdet.Controls.Add(txtbckdt);
            // lblver
            lblver.AutoSize = true;
            lblver.Location = new Point(6, 48);
            lblver.Size = new Size(59, 18);
            lblver.TabIndex = 6;
            lblver.Text = "Version";
            grpbxBackdet.Controls.Add(lblver);
            // txtver
            txtver.Location = new Point(88, 48);
            txtver.ReadOnly = true;
            txtver.Size = new Size(136, 23);
            txtver.TabIndex = 9;
            grpbxBackdet.Controls.Add(txtver);
            // lblbuilddt
            lblbuilddt.AutoSize = true;
            lblbuilddt.Location = new Point(230, 48);
            lblbuilddt.Size = new Size(77, 18);
            lblbuilddt.TabIndex = 10;
            lblbuilddt.Text = "Build Date";
            grpbxBackdet.Controls.Add(lblbuilddt);
            //txtbuilddt
            txtbuilddt.Location = new Point(323, 48);
            txtbuilddt.ReadOnly = true;
            txtbuilddt.Size = new Size(136, 23);
            txtbuilddt.TabIndex = 9;
            grpbxBackdet.Controls.Add(txtbuilddt);
            //lblbckpath
            lblbckpath.AutoSize = true;
            lblbckpath.Location = new Point(6, 78);
            lblbckpath.Size = new Size(86, 18);
            lblbckpath.TabIndex = 16;
            lblbckpath.Text = "Backup File";
            grpbxBackdet.Controls.Add(lblbckpath);
            //txtbckpath
            txtbckpath.Location = new Point(91, 76);
            txtbckpath.Size = new Size(324, 23);
            txtbckpath.TabIndex = 6;
            grpbxBackdet.Controls.Add(txtbckpath);
            //btnpath
            btnpath.Image = Properties.Resources.openHS;// global::RestorBack.Properties.Resources.openHS;
            btnpath.Location = new Point(418, 75);
            btnpath.Size = new Size(42, 23);

            btnpath.CornerRadius = 4;
            btnpath.ButtonColor = Color.CornflowerBlue;
            btnpath.GlowColor = Color.White;
            btnpath.TabIndex = 17;
            // btnpath.UseVisualStyleBackColor = true;
            grpbxBackdet.Controls.Add(btnpath);
            btnpath.Click += new System.EventHandler(btnpath_Click);
            // btnok
            // btnok.AdjustImageLocation = new System.Drawing.Point(0, 0);
            // btnok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("myXPButton1.BackgroundImage")));
            //btnok.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            //btnok.BtnStyle = EDPComponent.emunType.XPStyle.OliveGreen;
            btnok.Image = Properties.Resources.DISK04;
            btnok.ImageAlign = ContentAlignment.MiddleLeft;
            btnok.ImageSize = new Size(18, 18);
            btnok.Location = new Point(305, 195);
            btnok.Size = new Size(80, 30);
            btnok.CornerRadius = 4;
            btnok.ButtonColor = Color.CornflowerBlue;
            btnok.GlowColor = Color.White;

            btnok.TextAlign = ContentAlignment.MiddleRight;
            btnok.TabIndex = 6;
            btnok.Text = "Restore";
            //  btnok.UseVisualStyleBackColor = true;
            btnok.Click += new System.EventHandler(btnok_Click);
            Controls.Add(btnok);
            // btnclose

            //  btnclose.AdjustImageLocation = new System.Drawing.Point(0, 0);
            //  btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //   btnclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("myXPButton1.BackgroundImage")));
            //btnclose.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            //btnclose.BtnStyle = EDPComponent.emunType.XPStyle.OliveGreen;
            btnclose.Image = Properties.Resources.W95MBX01;
            btnclose.ImageAlign = ContentAlignment.MiddleLeft;
            btnclose.ImageSize = new Size(18, 18);
            btnclose.Location = new Point(390, 195);
            btnclose.Size = new Size(80, 30);
            btnclose.CornerRadius = 4;
            btnclose.ButtonColor = Color.CornflowerBlue;
            btnclose.GlowColor = Color.White;
            btnclose.TabIndex = 7;
            btnclose.Text = "Close";
            btnclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //   btnclose.UseVisualStyleBackColor = true;
            btnclose.Click += new System.EventHandler(btnclose_Click);
            Controls.Add(btnclose);

            pr.BackColor = System.Drawing.Color.Transparent;
            pr.HighlightColor = System.Drawing.Color.Gold;
            pr.Location = new System.Drawing.Point(16, 195);
            pr.ShowPercentage = false;
            pr.Size = new System.Drawing.Size(270, 23);
            pr.TabIndex = 8;
            pr.ShowPercentage = true;
            Controls.Add(pr);
            //   this.AcceptButton = btnok;
            //    this.CancelButton = btnclose;
            Size = new Size(483, 300);
        }
        private void btnpath_Click(object sender, EventArgs e)
        {
            try
            {
                svpath.Filter = com.ApplicationName + " Backup File (*." + com.ApplicationExtension + ")|*." + com.ApplicationExtension;
                svpath.ShowDialog();

                if (svpath.FileName.ToString().Length == 0)
                {
                }
                else
                {
                    txtbckpath.Text = svpath.FileName.ToString();
                    txtbckdt.Text = Convert.ToString(File.GetCreationTime(txtbckpath.Text).ToShortDateString());
                }
            }
            catch
            {
            }
        }
              
        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void rbfullRestore_CheckedChanged(object sender, EventArgs e)
        {
            if (rbfullRestore.Checked == true)
            {
                grpbxBackdet.Enabled = true;
                grpbxBackdet.Visible = true;
                Full_Back_Data();
                txtbckno.Text = "1";
                txtbckdt.Text = DateAndTime.Now.ToShortDateString();
                txtbuilddt.Text = com.PBUILD_DATE.ToShortDateString();
                txtver.Text = com.PEXE_VERSION;
                txtbckpath.Text = Environment.CurrentDirectory + "\\" + com.ApplicationName + "." + com.ApplicationExtension;
            }
        }

        private void frmRestore_Load(object sender, EventArgs e)
        {
            this.Text = "Normal DataBase Restore";
            // Environment.Exit(1);
            //---rbfullRestore.Checked = true;
            // mycon.ConnectionString = "Data Source=" + com.PSERVER_NAME + ";Initial Catalog=Master;Integrated Security=True;pooling=true;";

            // mycon.ConnectionString = "Initial Catalog=;Integrated Security=True;pooling=true;";

            //  SqlConnection mycon = new SqlConnection("Data Source=" + com.PSERVER_NAME + ";Initial Catalog=Master;Integrated Security=True;pooling=true;");
            //  SqlConnection mycon = new SqlConnection(" Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Master;Data Source=SANDIP");
            //Process[] pr = Process.GetProcesses(Environment.MachineName);
            //foreach (Process i in pr)
            //{
            //    if (i.ProcessName == "MidasGoldP.vshost")
            //        i.Kill();
            //}
            rbfullRestore.Checked =true;
            rbotherRestore.Enabled = false; 
        }

        private void rbotherRestore_CheckedChanged(object sender, EventArgs e)
        {
            if (rbotherRestore.Checked == true)
            {
                this.Size = new Size(473, 475);
                btnok.Location = new Point(335, 383);
                btnclose.Location = new Point(399, 383);
                grpbxBackdet.Enabled = false;
                grpbxBackdet.Visible = false;
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            if (th != null)
            {
                if (th.IsAlive)
                    EDPMessage.Show("Process Already Running");
                else
                    this.Close();
            }
            else this.Close();
        }
        private void btnok_Click(object sender, EventArgs e)
        {
             EDPMessage.Show("Existing data of current company and Financial Year may be lost due to restoration.", "Confirmation", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
             if (EDPMessage.ButtonResult == "edpYES")
             {
                 //if (th != null)
                 //{
                 //    if (th.IsAlive)
                 //    {
                 //        EDPMessage.Show("Process Already Running");
                 //        return;
                 //    }
                 //}
                 Restore();
                 //ThreadStart ts = new ThreadStart(Restore);
                 //th = new Thread(ts);
                 //th.Priority = ThreadPriority.Lowest;
                 //th.Start();
                 //pr.Value = 0;
                 //tmrPr.Enabled = true;                 
             }
        }
        void Restore()
        {
            SqlConnection sqlCn ;
            if (com.DataVersion == "2005")
                sqlCn = new SqlConnection("Initial Catalog=;Integrated Security=True;pooling=true;Data Source=" + com.PSERVER_NAME + "\\SQLEXPRESS;");
            else
                sqlCn = new SqlConnection("Initial Catalog=;Integrated Security=True;pooling=true;Data Source=" + com.PSERVER_NAME + ";");
            ServerConnection sqlServercn;
            Server server;
            Database db;
            //Restore rstdb = new Restore();
            sqlServercn = new ServerConnection(sqlCn);
            server = new Server(sqlServercn);
            server.KillAllProcesses(com.PDATABASE_NAME);
            db = new Database(server, com.PDATABASE_NAME);
            string strFileName = txtbckpath.Text.Trim();            
            
            string[] path1 = new string[] { };
            path1 = strFileName.Split('.');
            string pp = path1[0].ToString()+".txt";

            try
            {
                FileStream aFile = new FileStream(@pp, FileMode.Open, FileAccess.Write);
                StreamWriter sw = new StreamWriter(aFile);
            }
            catch { }

            System.Diagnostics.Process.Start("notepad.exe", @pp);

            //rstdb.Database = db.Name;
            //rstdb.Action = RestoreActionType.Database;
            //rstdb.Devices.Add(new BackupDeviceItem(strFileName, DeviceType.File));
            //rstdb.ReplaceDatabase = true;
            //rstdb.Restart = true;
            try
            {
                sqlCn.Close();
                sqlCn.Open();
                SqlCommand cmd = new SqlCommand("RESTORE DATABASE [AccordFour] FROM  DISK = N'" + strFileName + "' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10", sqlCn);
                cmd.ExecuteNonQuery();

                //rstdb.SqlRestore(server);
                EDPMessage.Show("Restored SuccessFully.", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_OK);
                sqlCn.Close();
                //th.Abort();
            }
            catch(Exception ex)
            {
                EDPMessage.Show("Failed to Restored.", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_ERROR);
                EDPMessage.Show(ex.Message);
               // th.Abort();
            }
        }

        private void DataRestorationColumnsUpdate()
        {
            try
            {
                //new_mycon.Close();
                //new_mycon.Open();

                //string sql = "Select * from AccordFour_db_info order by build_date desc";
                //edpcon.Open();
                //cmd = new SqlCommand(sql, new_mycon);
                //da = new SqlDataAdapter();
                //DateTime Pre_PBuildDate = new DateTime();
                //da.SelectCommand = cmd;
                //new_mycon.Close();
                //if (Convert.ToBoolean(da.Fill(ds, "Pre_db")))
                //{
                //    Pre_PBuildDate = (DateTime)ds.Tables["Pre_db"].Rows[0][3];
                //}


                edpcon.Close();
                edpcon.Open();
                //common.ConSrting = edpcon.mycon.ConnectionString;
               
                string sql = "Select * from AccordFour_db_info order by build_date desc";
                edpcon.Open();
                cmd = new SqlCommand(sql, edpcon.mycon);
                //DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter();
                DateTime PBuildDate;
                DateTime Pre_PBuildDate;
                dap.SelectCommand = cmd;
                version1.Versionflg = true;

                if (Convert.ToBoolean(dap.Fill(ds, "db")))
                {
                    Pre_PBuildDate = (DateTime)ds.Tables["db"].Rows[0][3];
                    PBuildDate = System.DateTime.Now;
                    if (PBuildDate != Pre_PBuildDate)
                    {
                        edpcon.Close();
                        edpcon.Open();
                        version1.ChkVersion(edpcon.mycon, PBuildDate, Pre_PBuildDate);
                        edpcon.Close();
                    }
                }
            }
            catch { }
        }

        private void tmrPr_Tick(object sender, EventArgs e)
        {
            if (th.IsAlive)
                pr.Value = pr.Value + 1;
            else
            {
                pr.Value = pr.MaxValue;
               // EDPMessage.Show("Please re-log into the application.", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
        }

        private void frmRestore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (th != null)
                if (th.ThreadState == System.Threading.ThreadState.Running)
                    th.Abort();

            try
            {
                DataRestorationColumnsUpdate();
            }
            catch { }
        }
    }
}