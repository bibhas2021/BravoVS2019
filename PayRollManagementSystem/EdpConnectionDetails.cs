using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using EDPComponent;
using EDPMessageBox;

namespace PayRollManagementSystem
{
    public partial class EdpConnectionDetails : Form
    {
        Edpcom.EDPCommon EDPComm = new Edpcom.EDPCommon();
        string type_conection = "";
        public EdpConnectionDetails(string con_type)
        {
            type_conection = con_type;
            InitializeComponent();
        }
        // QC Block 9 Start ==frmMain==
        public void PASSINGVALUE(string[] ss)
        {
            try
            {
                string[] s = ss;
                for (int i = 0; i <= s.Length - 1; i++)
                {
                    DSExtention.Items.Add("\\" + s[i]);
                }
            }
            catch { }
            //DSExtention.Text = "\\" + EDPComm.DataSourceExtention;
        }
        // QC Block 9 End
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (type_conection == "FC")
            {
                string status = "";
                if (CheckTrustedConnection.Checked == false)
                    status = "False";
                else
                    status = "True";
                //ec.userdefineconnection(txtDataSourch.Text, TxtNetworkLibrary.Text, txtIntegratedSecurity.Text, txtuserID.Text, txtPassword.Text, txtConnectiontime.Text, status);
                EDPComm.PSERVER_NAME = txtDataSourch.Text;
                //if (TxtNetworkLibrary.Text != "")
                EDPComm.NetWork_library = TxtNetworkLibrary.Text;
                EDPComm.Integrated_Security = txtIntegratedSecurity.Text;
                EDPComm.User_ID = txtuserID.Text;
                EDPComm.Password = txtPassword.Text;
                EDPComm.Trusted_Conection = status;
                EDPComm.Conection_TimeOut = txtConnectiontime.Text;
                EDPComm.Persist_Security_Info = chkPersistSecurity.Checked;
                EDPComm.DataSourceExtention = DSExtention.Text;
                EDPComm.PDATABASE_NAME = txtdatabase.Text;
                this.Close();
            }
            else if (type_conection == "DC")
            {
                string status = "";
                if (CheckTrustedConnection.Checked == false)
                    status = "False";
                else
                    status = "True";
                //EDPComm.PSERVER_NAME_CLOUD = txtDataSourch.Text;
                //EDPComm.NetWork_library_CLOUD = TxtNetworkLibrary.Text;
                //EDPComm.Integrated_Security_CLOUD = txtIntegratedSecurity.Text;
                //EDPComm.User_ID_CLOUD = txtuserID.Text;
                //EDPComm.Password_CLOUD = txtPassword.Text;
                //EDPComm.Trusted_Conection_CLOUD = status;
                //EDPComm.Conection_TimeOut_CLOUD = txtConnectiontime.Text;
                //EDPComm.Persist_Security_Info_CLOUD = chkPersistSecurity.Checked;
                //EDPComm.DataSourceExtention_CLOUD = DSExtention.Text;
                //EDPComm.PDATABASE_NAME_CLOUD = txtdatabase.Text;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand com;
                    DataSet ds = new DataSet();

                    //EdpClConn.EDPClConnection clcom = new EdpClConn.EDPClConnection();
                    //clcom.Open();
                    //common.ClearDataTable(ds.Tables["aa"]);
                    //com = new SqlCommand("SELECT * FROM company", clcom.mycon);
                    //da.SelectCommand = com;
                    //da.Fill(ds, "aa");
                    //clcom.Close();
                    //if (ds.Tables["aa"].Rows.Count > 0)
                    //{
                    //    this.Width = 0;
                    //    this.Height = 0;
                    //    this.Top = 1;
                    //    this.Close();
                    //    frmAcceptpassword passwd = new frmAcceptpassword("CC"); //User name & Password verify
                    //    passwd.ShowDialog();

                    //    string p = Convert.ToString(EDPComm.Persist_Security_Info_CLOUD);
                    //    EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "MachinName", EDPComm.PSERVER_NAME_CLOUD);
                    //    EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "DataSourceExtention", EDPComm.DataSourceExtention_CLOUD);
                    //    EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "NetworkLibary", EDPComm.NetWork_library_CLOUD);
                    //    EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "IntergrateSecurity", EDPComm.Integrated_Security_CLOUD);
                    //    EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "PersistSecurityInfo", p);
                    //    EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "TrustedConnection", EDPComm.Trusted_Conection_CLOUD);
                    //    EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "UserID", EDPComm.User_ID_CLOUD);
                    //    if (EDPComm.Password_CLOUD == "2477147edp")
                    //        EDPComm.Password_CLOUD = "***";
                    //    EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "PassWord", EDPComm.Password_CLOUD);
                    //    EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "DataBaseName", EDPComm.PDATABASE_NAME_CLOUD);
                    //}
                }
                catch
                {
                    EDPMessage.Show("Database Link Not Successful");
                }
            }
        }
        private void EdpConnectionDetails_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Connection Details";
                //this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
                
                if (txtDataSourch.Text == "")
                {
                    txtDataSourch.Text = EDPComm.PSERVER_NAME;
                    txtIntegratedSecurity.Text = "True";
                    CheckTrustedConnection.Checked = true;
                    DSExtention.Text = "\\SQLEXPRESS";
                }
                txtuserID.Text = "edp";
                txtPassword.Text = "2477147edp";
                txtConnectiontime.Text = "100";
                chkHide.Checked = true;

                conectiondetails_retrive();

                //if (type_conection == "DC")
                    //txtdatabase.Text = "PayRollManagementSystem";
                //else
                //{
                //    groupBox1.Top = 200;
                //    txtdatabase.Visible = false;
                //    label8.Visible = false;
                //}
            }
            catch { }
            if (this.txtDataSourch.Text == Environment.MachineName)
            {
                btnSave_Click(sender, e);
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            if (type_conection == "DC")
                this.Close();
            else
                Environment.Exit(0);
            //Application.Exit();
        }
        private void EdpConnectionDetails_Activated(object sender, EventArgs e)
        {
            btnSave.Focus();
        }
        // Block 11 === Start
        public void conectiondetails_retrive()
        {
            try
            {
                string datasourch = "";
                if (type_conection == "FC")
                {
                    txtDataSourch.Text = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "MachinName"));
                    datasourch = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "DataSourceExtention"));
                    TxtNetworkLibrary.Text = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "NetworkLibary"));
                    txtIntegratedSecurity.Text = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "IntergrateSecurity"));
                    string p = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "PersistSecurityInfo"));
                    string t = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "TrustedConnection"));

                    txtuserID.Text = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "UserID"));
                    string password = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "PassWord"));
                    if (password != "***")
                        txtPassword.Text = password;
                    txtdatabase.Text = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "DataBaseName"));

                    //string vhide = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "Show"));
                    DSExtention.Text = datasourch;
                    if (t == "True")
                        CheckTrustedConnection.Checked = true;
                    else
                        CheckTrustedConnection.Checked = false;

                    if (p == "True")
                        chkPersistSecurity.Checked = true;
                    else
                        chkPersistSecurity.Checked = false;
                }
                else
                {
                    txtDataSourch.Text = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "MachinName"));
                    datasourch = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "DataSourceExtention"));
                    TxtNetworkLibrary.Text = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "NetworkLibary"));
                    txtIntegratedSecurity.Text = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "IntergrateSecurity"));
                    string p = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "PersistSecurityInfo"));
                    string t = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "TrustedConnection"));

                    txtuserID.Text = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "UserID"));
                    string password = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "PassWord"));
                    if (password != "***")
                        txtPassword.Text = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "PassWord"));
                    txtdatabase.Text = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection2", "DataBaseName"));
                    //string vhide = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "Show"));
                    DSExtention.Text = datasourch;
                    if (t == "True")
                        CheckTrustedConnection.Checked = true;
                    else
                        CheckTrustedConnection.Checked = false;

                    if (p == "True")
                        chkPersistSecurity.Checked = true;
                    else
                        chkPersistSecurity.Checked = false;
                }
            }
            catch { }
        }
        //Block 11 ===== End
        private void btnreset_Click(object sender, EventArgs e)
        {
            TxtNetworkLibrary.Text = "";
            chkPersistSecurity.Checked = false;
            txtDataSourch.Text = Environment.MachineName;// EDPComm.PSERVER_NAME;
            txtIntegratedSecurity.Text = "True";
            CheckTrustedConnection.Checked = true;
            DSExtention.Text = "\\SQLEXPRESS";
            txtuserID.Text = "edp";
            txtPassword.Text = "2477147edp";
            txtConnectiontime.Text = "100";
            txtdatabase.Text = "EDP_Payroll";
        }

        private void EdpConnectionDetails_FormClosing(object sender, FormClosingEventArgs e)
        {          
         
        }
    }
}