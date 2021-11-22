using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using Edpcom;
using EDPVersion;
using FirstTimeNeed;
using EDPMessageBox;
using EDPProgressBar;
namespace PayRollManagementSystem
{
    public partial class frmSuperuser : EDPComponent.FormBase
    {
        SqlCommand mycmd;
        SqlDataAdapter myda = new SqlDataAdapter();
        DataSet myds = new DataSet();
        public frmSuperuser()
        {
            InitializeComponent();
        }
        string open_dt, close_dt;
        string form_name, machine_name, open_time, close_time;
        int form_code;
        bool CloseAccept;
        Boolean flug_newuser = false;
        Edpcom.EDPCommon edpcom = new EDPCommon();
        FirstTimeNeed.clsfirsttime first = new clsfirsttime();
        //-------------------------------------
        public void newuser()
        {
            flug_newuser = true;
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //lbl_Message.Width = 185;  
            PB.Visible = true;
            PB.Minimum = 0;
            PB.Maximum = 7;
            PB.Value = 0;

            label1.Visible = true;
            label1.Refresh();

            if (txtUser.Text.Trim() == "")
            {
                EDPMessage.Show("Enter User Name", "Message");
                txtUser.Focus();
                return;
            }
            if (txtPass.Text.Trim() == "")
            {
                EDPMessage.Show("Enter Password", "Message");
                txtPass.Focus();
                return;
            }
            if (txtConpass.Text.Trim() == "")
            {
                EDPMessage.Show("Enter Confirm Password", "Message");
                txtConpass.Focus();
                return;
            }
            if (txtPass.Text == txtConpass.Text)
            {
                PB.Value = PB.Value + 1;
                string user, pass, confirm, user1, user2, pass1, pass2;
                Edpcom.EDPCommon edpcomm = new EDPCommon();
                EDPVersion.versionEDP version1 = new versionEDP();
                user = edpcomm.edpcrypt(txtUser.Text,true);
                pass = edpcomm.edpcrypt(txtPass.Text, true);
                user1 = edpcomm.edpcrypt("2", true);
                user2 = edpcomm.edpcrypt("3", true);
                pass1 = edpcomm.edpcrypt("2", true);
                pass2 = edpcomm.edpcrypt("3", true);
                confirm = edpcomm.edpcrypt(txtConpass.Text, true); 
                Edpcom.EDPConnection edpcon = new EDPConnection();
                SqlCommand sqlcmd;
                DateTime ddate = DateTime.Now;
                ddate = ddate.AddDays(365);
                string d1;
                d1=edpcomm.getSqlDateStr(ddate);
                edpcon.Open();
                int ucode = 1;              
                if (flug_newuser == true)
                {
                    ucode = Convert.ToInt32(edpcom.GetresultS("select max(user_code) from pasword"));
                    ucode++;
                }
                sqlcmd = new SqlCommand("insert into pasword values('" + ucode + "','" + user + "','" + "0" + "','" + "Superuser" + "','" + pass + "'," + 0 + ",'" + d1 + "'," + 0 + "," + 0 + ",'" + "D" + "'," + 0 + ")", edpcon.mycon);
                sqlcmd.ExecuteNonQuery();
                PB.Value = PB.Value + 1;
                if (flug_newuser == false)
                {
                    sqlcmd = new SqlCommand("insert into pasword values('" + 2 + "','" + user1 + "','" + "0" + "','" + "EveryOne" + "','" + pass1 + "'," + 0 + ",'" + d1 + "'," + 0 + "," + 0 + ",'" + "D" + "'," + 0 + ")", edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                    PB.Value = PB.Value + 1;
                    sqlcmd = new SqlCommand("insert into pasword values('" + 3 + "','" + user2 + "','" + "0" + "','" + "NoOne" + "','" + pass2 + "'," + 0 + ",'" + d1 + "'," + 0 + "," + 0 + ",'" + "D" + "'," + 0 + ")", edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                    PB.Value = PB.Value + 1;
                    sqlcmd = new SqlCommand("insert into UserControl(Ficode,Gcode,UGcode,USGcode,SuperUser,USER_CODE) values('" + 1 + "','" + 1 + "','1','0','" + ucode + "','" + ucode + "')", edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                    PB.Value = PB.Value + 1;

                    close_dt = edpcom.getSqlDateStr(DateTime.Today);
                    close_time = System.DateTime.Now.ToLongTimeString();

                    int xlsv;
                    if (Edpcom.EDPCommon.UserCount == 1)
                        xlsv = 1;
                    else
                        xlsv = 0;

                    string Sql = "insert into AccordFourlog(LOG_UCODE, LOG_GCODE, LOG_CCODE,FORM_NAME, FORM_CODE, DATE_FROM, TIME_FROM, DATE_TO, TIME_TO, LOG_STAT, MACHINE_NAME, Exclusive, session_no)";
                    Sql = Sql + "values('" + ucode + "','" + 0 + "','" + 0 + "','" + form_name + "'," + form_code + ",'" + open_dt + "','" + open_time + "','" + close_dt + "','" + close_time + "'," + 0 + ",'" + machine_name + "'," + xlsv + "," + 0 + ")";
                    sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                    PB.Value = PB.Value + 1;
                    edpcom.SetInRegistry("1", "First", "PayRollManagementSystem\\Firsttime");
                    edpcomm.CreateSubkey("PayRollManagementSystem\\Company");
                    edpcomm.SetInRegistry("2", "Lusercode", "PayRollManagementSystem\\Company");
                    gbxConfirm.Visible = false;
                    edpcomm.FirstTimeInstall = true;
                    lblSession.Text = "";
                    lblSession.Visible = true;
                    if (first.firsttimeData(edpcon.mycon))
                    {
                        lblSession.Text = "Database created succesfully";
                        //mycmd = new SqlCommand("SELECT table_name from information_schema.tables WHERE table_type ='base table'", edpcon.mycon);

                        //myda.SelectCommand = mycmd;
                        //myda.Fill(myds, "CNT");

                        //EDPProgressBar.ThreadingProgress ThrdProgrs = new ThreadingProgress(myds.Tables["CNT"]);
                        //ThrdProgrs.ShowDialog();
                    }
                    else lblSession.Text = " Cannot create Database";
                    if (first.firstimemethod(edpcon.mycon)) lblSession.Text = "Methods created succesfully";
                    else lblSession.Text = "Cannot create Methods";
                    edpcon.Close();
                    CloseAccept = false;
                    this.Close();
                    try
                    {
                        if (Microsoft.Win32.Registry.CurrentUser.OpenSubKey("CID") != null)
                        {
                            Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("CID");
                        }
                        if (Microsoft.Win32.Registry.CurrentUser.OpenSubKey("DPID") != null)
                        {
                            Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("DPID");
                        }
                        if (Microsoft.Win32.Registry.CurrentUser.OpenSubKey("DP NAME") != null)
                        {
                            Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("DP NAME");
                        }
                    }
                    catch { }
                }
                else
                {
                    int gcode = Convert.ToInt32(edpcom.GetresultS("select max(gcode) from Access"));
                    gcode++;
                    int usercode = Convert.ToInt32(edpcom.GetresultS("select max(gcode) from UserControl"));
                    usercode++;
                    sqlcmd = new SqlCommand("insert into access(USER_CODE,FICode,GCODE) values('" + ucode + "','1','" + gcode + "')", edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                    PB.Value = PB.Value + 1;
                    sqlcmd = new SqlCommand("insert into ACCESSBRANCH(USER_CODE,FICode,GCODE,BRNCH_CODE) values('" + ucode + "','1','" + gcode + "'," + 0 + ")", edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                    PB.Value = PB.Value + 1;
                    sqlcmd = new SqlCommand("insert into ACCESSBRANCH(USER_CODE,FICode,GCODE,BRNCH_CODE) values('" + ucode + "','1','" + gcode + "'," + 1 + ")", edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                    PB.Value = PB.Value + 1;
                    sqlcmd = new SqlCommand("insert into UserControl(Ficode,Gcode,UGcode,USGcode,SuperUser,USER_CODE) values('" + 1 + "','" + gcode + "','" + usercode + "','0','" + ucode + "','" + ucode + "')", edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                    PB.Value = PB.Value + 1;
                    this.Close();
                }
            }
            else
            {
                EDPMessage.Show("Password Mismatch", "Message");
                txtConpass.Text = "";
                txtPass.Text = "";
                txtPass.Focus();
                return;
            }
        }

        private void frmSuperuser_Load(object sender, EventArgs e)
        {
            this.Text = "Accord Four Super User Creation Wizard";
            rdbAgre.Checked = true;
            form_name = "Super User Create";
            form_code = 0;
            open_dt = edpcom.getSqlDateStr(DateTime.Today);
            open_time = System.DateTime.Now.ToLongTimeString();
            machine_name = Environment.MachineName.ToString();
            CloseAccept = false;
            btnNext.Focus();
            btnNext.Select();
            //lbl_Message.Width = 1;
        }
        private void frmSuperuser_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (CloseAccept)
            //{
            //    Environment.Exit(0);
            //}
            //else
            //{
            //    string dr=MessageBox.Show("Do you want to Exit from Super user setup?", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString();
            //    if (dr == System.Windows.Forms.DialogResult.Yes.ToString())
            //        Environment.Exit(0);
            //    else
            //        return;
            //}
        }
        private void rdbAgre_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAgre.Checked) btnNext.Enabled = true;                
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (rdbAgre.Checked == true)
            {
                //this.Height = 200;
                //lblConfirmation.Height = 60;
                //groupBox1.Height = 142;
                //groupBox2.Height = 128;
                this.Height = 232;
                lblConfirmation.Height = 130;
                groupBox1.Height = 180;
                groupBox2.Height = 164;
                gbxConfirm.Visible = true;               
                lblSession.Visible = false;
                lblConfirmation.Visible = false;
                gbxConfirm.Height = 147;
                label1.Visible = false;                
                //lbl_Message.Visible = true;
                txtPass.ForeColor = Color.Maroon;
                txtPass.BackColor = Color.Snow;
                txtPass.ForeColor = Color.Maroon;
                txtPass.BackColor = Color.Snow;
                txtConpass.ForeColor = Color.Maroon;
                txtConpass.BackColor = Color.Snow;

                txtUser.Focus();
            }
            else
            {
                EDPMessage.Show("To proceed please select I agree", "Super User Creation", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_WARNING);
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            if (CloseAccept)
            {
                Environment.Exit(0);
            }
            else
            {
                EDPMessage.Show("Do you want to Exit from Super user setup?", "Confirm!",EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
                if(EDPMessage.ButtonResult.ToString() == "edpYES")
                    Environment.Exit(0);
                else
                    return;
            }
        }
        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtConpass.Focus();
            }
        }
        private void txtConpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Minimized;
        //}

        private void frmSuperuser_Resize(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Minimized)
            //{
            //    this.Text = "PayRollManagementSystem Gold Super User Creation Wizard";
            //}
            //else if (this.WindowState == FormWindowState.Normal)
            //{
            //    this.Text = "";
            //}
        }

        private void rdbDonot_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdbAgre.Checked) btnNext.Enabled = true;
            //else btnNext.Enabled = false;  
        }

        private void frmSuperuser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }      

        private void txtUser_Enter(object sender, EventArgs e)
        {
            txtUser.ForeColor = Color.Black;
            txtUser.BackColor = Color.White;
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            txtPass.ForeColor = Color.Black;
            txtPass.BackColor = Color.White;
        }

        private void txtConpass_Enter(object sender, EventArgs e)
        {
            txtConpass.ForeColor = Color.Black;
            txtConpass.BackColor = Color.White;
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            txtUser.ForeColor = Color.Maroon;
            txtUser.BackColor = Color.Snow;
            //
            Edpcom.EDPConnection edpcon = new EDPConnection();
            edpcon.Open();
            mycmd = new SqlCommand("select * from pasword where USER_DESC='" + edpcom.edpcrypt(txtUser.Text, true) + "'", edpcon.mycon);
            myda.SelectCommand = mycmd;
            bool bul = Convert.ToBoolean(myda.Fill(myds, "chk_user_exist"));
            edpcon.Close();
            myds.Tables["chk_user_exist"].Clear();
            if (bul == true)
            {
                EDPMessage.Show(txtUser.Text + " User Already Exist", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                txtUser.Text = "";
                txtUser.Focus();
                return;
            }
            //
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            txtPass.ForeColor = Color.Maroon;
            txtPass.BackColor = Color.Snow;
        }

        private void txtConpass_Leave(object sender, EventArgs e)
        {
            txtConpass.ForeColor = Color.Maroon;
            txtConpass.BackColor = Color.Snow;
        }

       
    }
}