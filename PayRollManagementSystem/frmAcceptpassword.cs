using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Edpcom;
using EDPMessageBox;
namespace PayRollManagementSystem
{
    public partial class frmAcceptpassword : Form
    {
        ToolTip tlp = new ToolTip();
        Edpcom.EDPConnection edpcon = new EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        SqlDataAdapter myda=new SqlDataAdapter();
        SqlCommand mycmd;
        DataSet myds=new DataSet();
        int pcount, MAX_FAILED_ATTEMPT=2;
        string user, Pass, Type;
        public bool paccept;
        public frmAcceptpassword(string name)
        {
            InitializeComponent();
            Type = name;
        }

        public void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //edpcom.UpdateWaccLog(this, false);     
            
            if (txtUsername.Text.Trim() != "")
            
            {
                if (txtPassword.Text.Trim() != "")
                {
                    paccept = false;
                    user = edpcom.edpcrypt(txtUsername.Text,true);
                    Pass = edpcom.edpcrypt(txtPassword.Text,true);
                    //sqlstr = "select * from pasword where USER_DESC= " + user + " and PSWD_DESC= " + Pass;
                    EDPConnection edpcon = new EDPConnection();
                    edpcon.Open();
                    mycmd = new SqlCommand("select * from pasword where USER_DESC= \'" + user + "\' and PSWD_DESC= \'" + Pass + "\'",edpcon.mycon);
                    myda.SelectCommand=mycmd;
                    bool bu=System.Convert.ToBoolean(myda.Fill(myds, "chk_pass"));
                    edpcon.Close();
                    myds.Tables["chk_pass"].Clear();


                    /*if (mydr.Read())
                    {
                        edpcom.PCURRENT_USER = mydr.GetString(0);
                        paccept = true;
                        tmrCheck.Enabled = false;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Details.", "Inavild!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pcount = pcount + 1;
                        paccept = false;
                    }*/


                    if (bu)
                    {
                        edpcon.Open();
                        mycmd = new SqlCommand("select USER_CODE,USER_LEV from pasword where USER_DESC='" + user + "' and PSWD_DESC='" + Pass + "'", edpcon.mycon);
                        myda.SelectCommand = mycmd;
                        myda.Fill(myds, "get_code");
                        edpcon.Close();
                        edpcom.UserDesc = edpcom.edpcrypt(user, false);
                        user = myds.Tables["get_code"].Rows[0][0].ToString();
                        edpcom.CurrentUserLev = myds.Tables["get_code"].Rows[0][1].ToString();
                        myds.Tables["get_code"].Clear();
                        edpcom.PCURRENT_USER = user;                        
                        paccept = true;
                        this.Close();                       
                    }
                    else
                    {
                        EDPMessage.Show("Invalid Details.", "Inavild!", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_ERROR);
                        
                        txtPassword.Text = "";
                        txtUsername.Text = "";
                        txtUsername.Focus();
                        pcount = pcount + 1;
                        paccept = false;
                        return;
                    }
                }
                else
                {
                    EDPMessage.Show("Password field Cannot be left blank.", "Inavild!", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_ERROR);
                    txtPassword.Focus();
                }
            }
            else
            {
                EDPMessage.Show("Username field Cannot be left blank.", "Inavild!", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_ERROR);
                txtUsername.Focus();
            }
        }

        private void frmAcceptpassword_Load(object sender, EventArgs e)
        {
           // edpcom.UpdatePayRollManagementSystemLog(this, true);
            pcount = 0;
            tmrCheck.Enabled = true;
            txtUsername.Focus();
            //this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
           // Modual1.set_toltip(btnAccept, btnAccept.Text);
           // Modual1.set_toltip(btnClose,btnClose.Text);
            common.set_toltip(txtUsername, "Please Type User Name");
            common.set_toltip(txtPassword, "Please Type Password");
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
        }
        private void tmrCheck_Tick(object sender, EventArgs e)
        {
            if (pcount > MAX_FAILED_ATTEMPT)
            {
                Application.Exit();
            }
        }

        private void frmAcceptpassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrCheck.Enabled = false;
           // edpcom.UpdatePayRollManagementSystemLog(this, false);          
           //edpcom.UpdateWaccLog(this,true);
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                txtPassword.Focus();
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
        }

        private void btnAccept_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void frmAcceptpassword_KeyDown(object sender, KeyEventArgs e)
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

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txtPassword_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}