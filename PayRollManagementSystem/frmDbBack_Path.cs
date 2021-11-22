using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using EDPMessageBox;

namespace PayRollManagementSystem
{
    public partial class frmDbBack_Path : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        OleDbConnection conCopmany = new OleDbConnection();
        OleDbConnection conDATA = new OleDbConnection();
        DataSet dsRetrievedData = new DataSet();
        DataTable dt_IGLMST = new DataTable();
        SqlConnection con = new SqlConnection();
        SqlConnection new_mycon = new SqlConnection();

        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        SqlDataAdapter daSql = new SqlDataAdapter();
        SqlTransaction Tran;

        string CurrentFICode = "1", CurrentGCode = "1", OldFICode = "1", OldGCode = "";
        string TEntryOld = "", TEntryNew = "";
        string path, TblName, DESC;
        bool Auto_BackUp_Path = false;


        public void Auto_Back_Up_Path(bool ABP)
        {
            Auto_BackUp_Path = ABP;
        }

        public frmDbBack_Path()
        {
            InitializeComponent();
        }

        private void btnAccordDir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Auto_BackUp_Path)
                {
                    try
                    {
                        folderBrowserDialog1.ShowDialog();
                        path = "";
                        path = folderBrowserDialog1.SelectedPath.ToString();

                        if (path == "")
                        {
                            EDPMessage.Show("Please Select the right path.", "Information");
                            return;
                        }
                        path = path + "\\";
                        txtAccordDir.Text = path;

                        conCopmany.Close();
                        StringBuilder ConnectionString = new StringBuilder("");
                        ConnectionString.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;");
                        ConnectionString.Append(@"Extended Properties=Paradox 5.x;");
                        ConnectionString.Append(@"Data Source='" + path + "';");
                        conCopmany.ConnectionString = ConnectionString.ToString();
                        try
                        {
                            conCopmany.Open();
                        }
                        catch { }

                        common.ClearDataTable(dsRetrievedData.Tables["COMPANY"]);
                        conCopmany.Close();
                        conCopmany.Open();
                        OleDbDataAdapter command = new OleDbDataAdapter("SELECT DISTINCT CO_NAME FROM company", conCopmany);
                        command.Fill(dsRetrievedData, "COMPANY");
                        conCopmany.Close();

                        if (dsRetrievedData.Tables["COMPANY"].Rows.Count > 0)
                        {
                            cmbCompanyName.Items.Clear();
                            for (int i = 0; i <= dsRetrievedData.Tables["COMPANY"].Rows.Count - 1; i++)
                            {
                                cmbCompanyName.Items.Add(Convert.ToString(dsRetrievedData.Tables["COMPANY"].Rows[i]["CO_NAME"]));
                            }
                            cmbCompanyName.Text = Convert.ToString(dsRetrievedData.Tables["COMPANY"].Rows[0]["CO_NAME"]);
                            cmbCompanyName.SelectedIndex = 0;
                            cmbCompanyName.Focus();
                        }
                        else
                        {
                            EDPMessage.Show("Please Select the right path.", "Information");
                            return;
                        }
                    }
                    catch { }
                }
                else
                {
                    folderBrowserDialog1.ShowDialog();
                    path = "";
                    path = folderBrowserDialog1.SelectedPath.ToString();

                    if (path == "")
                    {
                        EDPMessage.Show("Please Select the right path.", "Information");
                        return;
                    }
                    //path = path + "\\";
                    txtAccordDir.Text = path;
                }
            }
            catch { }
        }

        private void btn_Save_Path_Click(object sender, EventArgs e)
        {
            edpcom.SetInRegistry(txtAccordDir.Text, "PATH_", "SOFTWARE\\DATAPATH_");
            EDPMessage.Show("Save the Path Succesfuly.");
            this.Close();
        }

        private void frmDbBack_Path_Load(object sender, EventArgs e)
        {
            lblRecordCounter.Visible = false;
            lblRecord.Visible = false;
            PB1.Visible = false;
            //this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            if (Auto_BackUp_Path)
            {
                this.Text = "Change the Backup Path";
                btn_Save_Path.Visible = true;
                //groupBox1.Height = 92;
                //btnledgertagin.Visible = false;
                //btnMigrate.Visible = false;
                PB1.Visible = false;
                this.Height = 200;
                label1.Text = "Auto Backup Path";
                txtAccordDir.Text = Convert.ToString(edpcom.GetFromRegisrty("PATH_", "SOFTWARE\\DATAPATH_"));
                try
                {
                    if (txtAccordDir.Text == null)
                        txtAccordDir.Text = Environment.CurrentDirectory;
                    if (txtAccordDir.Text == "")
                        txtAccordDir.Text = Environment.CurrentDirectory;
                }
                catch { }
            }
            else
            {
                btn_Save_Path.Visible = false;
                this.Text = "Migrate";
            }
        }
    }
}
