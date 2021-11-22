using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EDPMessageBox;
using System.Linq;

namespace PayRollManagementSystem
{
    public partial class ProductKey : Form
    {
        Edpcom.EDPCommon edpcomm = new Edpcom.EDPCommon();
        Conn cnn = new Conn();
        private bool reg;
        string KeyCode = "";
        bool Period_Check = false;
        string STRRESULT = "";

        DataTable DT_TRANS = new DataTable();
        DataTable DT_SESSION = new DataTable();
        DataTable DT_COMPANY = new DataTable();

        public ProductKey()
        {
            InitializeComponent();
        }
        public ProductKey(bool regis)
        {
            InitializeComponent();
            reg = regis;
        }

        public void GetKeyCode(string KC)
        {
            KeyCode = KC;
        }

        public void GetKeyCode(string KC,bool PC)
        {
            KeyCode = KC;
            Period_Check = PC;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void vistaButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void vistaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim().Length == 0)
                {
                    EDPMessage.Show("Enter key", "Message..");
                    textBox1.Focus();
                    return;
                }
                //if (textBox1.Text.Trim().Length != 11)
                //{
                //    EDPMessage.Show("String length must be 11 like ***********", "Message..");
                //    textBox1.Focus();
                //    return;
                //}                
                if (textBox1.Text.Trim().Length == 11 && (textBox1.Text.Trim().Substring(0, 1) == "A" || textBox1.Text.Trim().Substring(0, 1) == "B" || textBox1.Text.Trim().Substring(0, 1) == "C" || textBox1.Text.Trim().Substring(0, 1) == "D" || textBox1.Text.Trim().Substring(0, 1) == "E" || textBox1.Text.Trim().Substring(0, 1) == "F"))
                {
                    string strKey = textBox1.Text.Trim().Substring(0, 8);
                    string strDayNO = textBox1.Text.Trim().Substring(8, 3);
                    string strTODAY = System.DateTime.Now.ToShortDateString();

                    string[] s = new string[] { };
                    s = strTODAY.Split('/');
                    string StrD = s[2] + s[1] + s[0];

                    try
                    {
                        int INTKey = int.Parse(strKey.Trim(), System.Globalization.NumberStyles.HexNumber);
                        int INTdATE = int.Parse(StrD.Trim(), System.Globalization.NumberStyles.HexNumber);
                        int INTEC = INTKey - INTdATE;

                        byte[] EC = BitConverter.GetBytes(INTEC);
                        string ss = BitConverter.ToString(EC);
                        string[] STRSPLIT = new string[] { };
                        STRSPLIT = ss.Trim().Split('-');
                        STRRESULT = STRSPLIT[3] + STRSPLIT[2] + STRSPLIT[1] + STRSPLIT[0];

                        if (KeyCode != STRRESULT)
                        {
                            EDPMessage.Show("Wrong Key Entered.", "Message..");
                            textBox1.Focus();
                            return;
                        }

                        Master_Transaction();

                        string strNewKey = "";
                        if (STRRESULT.Substring(0, 1) == "A")
                        {
                            int SLNO = 0;
                            DataView dv = new DataView(DT_TRANS);
                            dv.RowFilter = "Trans_Code='" + KeyCode + "'";
                            if (dv.Count > 0)
                                SLNO = Convert.ToInt32(dv[0][3]);
                            SLNO++;
                            dv = new DataView(DT_TRANS);
                            dv.RowFilter = "SL='" + SLNO.ToString() + "'";
                            if (dv.Count > 0)
                                strNewKey = Convert.ToString(dv[0][0]);
                        }
                        if (STRRESULT.Substring(0, 1) == "B")
                        {
                            int SLNO = 0;
                            DataView dv = new DataView(DT_SESSION);
                            dv.RowFilter = "Session_Code='" + KeyCode + "'";
                            if (dv.Count > 0)
                                SLNO = Convert.ToInt32(dv[0][3]);
                            SLNO++;
                            dv = new DataView(DT_SESSION);
                            dv.RowFilter = "SL='" + SLNO.ToString() + "'";
                            if (dv.Count > 0)
                                strNewKey = Convert.ToString(dv[0][0]);
                        }
                        if (STRRESULT.Substring(0, 1) == "C")
                        {
                            int SLNO = 0;
                            DataView dv = new DataView(DT_COMPANY);
                            dv.RowFilter = "Company_Code='" + KeyCode + "'";
                            if (dv.Count > 0)
                                SLNO = Convert.ToInt32(dv[0][3]);
                            SLNO++;
                            dv = new DataView(DT_COMPANY);
                            dv.RowFilter = "SL='" + SLNO.ToString() + "'";
                            if (dv.Count > 0)
                                strNewKey = Convert.ToString(dv[0][0]);
                        }

                        if (!Period_Check)
                        {
                            if (STRRESULT.Substring(0, 1) == "A")
                            {
                                //Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR", true).SetValue("EC_TRANS", strNewKey);
                                edpcomm.SetInRegistry(strNewKey, "EC_TRANS", "SOFTWARE\\DATARAM");
                            }
                            if (STRRESULT.Substring(0, 1) == "B")
                            {
                                //Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR", true).SetValue("EC_SESSION", strNewKey);
                                edpcomm.SetInRegistry(strNewKey, "EC_SESSION", "SOFTWARE\\DATARAM");
                            }
                            if (STRRESULT.Substring(0, 1) == "C")
                            {
                                //Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR", true).SetValue("EC_COMPANY", strNewKey);
                                edpcomm.SetInRegistry(strNewKey, "EC_COMPANY", "SOFTWARE\\DATARAM");
                                 
                            }
                            //Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR", true).SetValue("EC_NDATE", strDayNO);
                            //Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR", true).SetValue("EC_DATE", DateTime.Now.ToShortDateString());
                            //Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR", true).SetValue("EC_LDATE", DateTime.Now.ToShortDateString());

                            edpcomm.SetInRegistry(strDayNO, "EC_NDATE", "SOFTWARE\\DATARAM");
                            edpcomm.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_DATE", "SOFTWARE\\DATARAM");
                            edpcomm.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_LDATE", "SOFTWARE\\DATARAM");

                            DataTable dt_Co_Details = edpcomm.GetDatatable("SELECT * FROM Company WHERE (CO_CODE=1)");

                            cnn.SP_Dync_Proc_reg(dt_Co_Details.Rows[0]["coid"].ToString(),dt_Co_Details.Rows[0]["EC_COMPANY"].ToString(),
                            DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), strDayNO, strNewKey, strNewKey, 
                            DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MMM/yyyy"), textBox1.Text);
                        }
                        else
                        {
                            edpcomm.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_LDATE", "SOFTWARE\\DATARAM");
                        }

                        this.Close();
                    }
                    catch { }
                }
                else
                {
                    EDPMessage.Show("Please reenter the key.");
                    textBox1.Focus();
                }
                //if (Activation(textBox1.Text))
                //{
                //    try
                //    {
                //        Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE", true).CreateSubKey("Mclass").SetValue("key", textBox1.Text);
                //        Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("MDT").SetValue("ID", DateTime.Today);
                //        EDPMessage.Show("Activation successful", "AccordFour");

                //        this.Close();
                //    }
                //    catch 
                //    {
                //        this.Close();
                //    }
                //}
                //else
                //{
                //    EDPMessage.Show("Activation key invalid !", "AccordFour");
                //    textBox1.Text = "";
                //    textBox1.Focus();
                //    return;
                //}                
            }
            catch { }
        }
        //private bool Activation(string key)
        //{
        //    int value = 0;
        //    string val;
        //    //value = Convert.ToInt32(DateTime.Today.Day) * Convert.ToInt32(DateTime.Today.Month) + Convert.ToInt32(DateTime.Today.Year) + 100000;
        //    //val = value.ToString() + "-edp-mg-" + DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + "-" + edpcomm.GetDemoDays;
        //    val = "EDP";
        //    if (key == val)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}       

        public void Master_Transaction()
        {
            try
            {
                int RC = 0;
                #region Transaction Entry In DataTable
                DT_TRANS.Columns.Add("Trans_Code", typeof(string));
                DT_TRANS.Columns.Add("Trans_Value", typeof(string));
                DT_TRANS.Columns.Add("Trans_Comment", typeof(string));
                DT_TRANS.Columns.Add("SL", typeof(string));

                DT_TRANS.Rows.Add();
                DT_TRANS.Rows[RC][0] = "A0000100";
                DT_TRANS.Rows[RC][1] = "100";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 100";
                DT_TRANS.Rows[RC][3] = "0";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0000500";
                DT_TRANS.Rows[RC][1] = "500";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 500";
                DT_TRANS.Rows[RC][3] = "1";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0001000";
                DT_TRANS.Rows[RC][1] = "1000";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 1000";
                DT_TRANS.Rows[RC][3] = "2";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0005000";
                DT_TRANS.Rows[RC][1] = "5000";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 5000";
                DT_TRANS.Rows[RC][3] = "3";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0009999";
                DT_TRANS.Rows[RC][1] = "9999";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 9999";
                DT_TRANS.Rows[RC][3] = "4";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0099999";
                DT_TRANS.Rows[RC][1] = "99999";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 99999";
                DT_TRANS.Rows[RC][3] = "5";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0199999";
                DT_TRANS.Rows[RC][1] = "199999";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 199999";
                DT_TRANS.Rows[RC][3] = "6";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0499999";
                DT_TRANS.Rows[RC][1] = "499999";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 499999";
                DT_TRANS.Rows[RC][3] = "7";
                #endregion
                #region Session Entry In DataTable
                DT_SESSION.Columns.Add("Session_Code", typeof(string));
                DT_SESSION.Columns.Add("Session_Value", typeof(string));
                DT_SESSION.Columns.Add("Session_Comment", typeof(string));
                DT_SESSION.Columns.Add("SL", typeof(string));
                RC = 0;
                DT_SESSION.Rows.Add();
                DT_SESSION.Rows[RC][0] = "B0000200";
                DT_SESSION.Rows[RC][1] = "200";
                DT_SESSION.Rows[RC][2] = "Total Session are 200";
                DT_SESSION.Rows[RC][3] = "0";
                DT_SESSION.Rows.Add();
                RC++;
                DT_SESSION.Rows[RC][0] = "B0001000";
                DT_SESSION.Rows[RC][1] = "1000";
                DT_SESSION.Rows[RC][2] = "Total Session are 1000";
                DT_SESSION.Rows[RC][3] = "1";
                DT_SESSION.Rows.Add();
                RC++;
                DT_SESSION.Rows[RC][0] = "B0005000";
                DT_SESSION.Rows[RC][1] = "5000";
                DT_SESSION.Rows[RC][2] = "Total Session are 5000";
                DT_SESSION.Rows[RC][3] = "2";
                DT_SESSION.Rows.Add();
                RC++;
                DT_SESSION.Rows[RC][0] = "B0010000";
                DT_SESSION.Rows[RC][1] = "10000";
                DT_SESSION.Rows[RC][2] = "Total Session are 10000";
                DT_SESSION.Rows[RC][3] = "3";
                DT_SESSION.Rows.Add();
                RC++;
                DT_SESSION.Rows[RC][0] = "B0099999";
                DT_SESSION.Rows[RC][1] = "99999";
                DT_SESSION.Rows[RC][2] = "Total Session are 99999";
                DT_SESSION.Rows[RC][3] = "4";
                #endregion
                #region Company Entry In DataTable
                DT_COMPANY.Columns.Add("Company_Code", typeof(string));
                DT_COMPANY.Columns.Add("Company_Value", typeof(string));
                DT_COMPANY.Columns.Add("Company_Comment", typeof(string));
                DT_COMPANY.Columns.Add("SL", typeof(string));
                RC = 0;
                DT_COMPANY.Rows.Add();
                DT_COMPANY.Rows[RC][0] = "C0000011";
                DT_COMPANY.Rows[RC][1] = "11";
                DT_COMPANY.Rows[RC][2] = "Total Companies are 15";
                DT_COMPANY.Rows[RC][3] = "0";
                DT_COMPANY.Rows.Add();
                RC++;
                DT_COMPANY.Rows[RC][0] = "C0000041";
                DT_COMPANY.Rows[RC][1] = "41";
                DT_COMPANY.Rows[RC][2] = "Total Companies are 41";
                DT_COMPANY.Rows[RC][3] = "1";
                DT_COMPANY.Rows.Add();
                RC++;
                DT_COMPANY.Rows[RC][0] = "C0000091";
                DT_COMPANY.Rows[RC][1] = "91";
                DT_COMPANY.Rows[RC][2] = "Total Companies are 91";
                DT_COMPANY.Rows[RC][3] = "2";
                #endregion
            }
            catch { }

        }
        public string random()
        {
            int length = 5;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void ProductKey_Load(object sender, EventArgs e)
        {
            txtKeyCode.Text = KeyCode;
            lbl_Random.Text = random();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                vistaButton1.Focus();    
        }

        private void ProductKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KeyCode != STRRESULT)
                Environment.Exit(0);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }
    }
}