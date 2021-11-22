//--------------------------------------------------PayRollManagementSystemGold(2012)---------------------------------
//-----------------------------------------------EDP Software Limited-------------------------------------------
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
using Microsoft.Win32;
using System.Resources;
using System.Collections;
using Microsoft.VisualBasic;
using EDPMessageBox;
namespace PayRollManagementSystem
{
    public partial class frmSelectcomp :EDPComponent.FormBase
    {
        ToolTip tlp = new ToolTip();
        Edpcom.EDPConnection edpcon = new EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        SqlDataAdapter myda = new SqlDataAdapter();
        SqlCommand mycmd;
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        int numeric_chk = 0;
        //bool SLC_COMP;
        public frmSelectcomp()
        {
            InitializeComponent();
        }
        private void frmSelectcomp_Load(object sender, EventArgs e)
        {
            this.Text = "Select Company";
            //this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            //groupBox1.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            //////////edpcom.UpdatePayRollManagementSystemLog(this, true);
            edpcom.setFormPosition(this);
            common.FormX = this.Location.X;
            common.FormY = this.Location.Y;
            try
            {                
                if (Information.IsNothing(ds.Tables["chk_access"]) == false)
                {
                    ds.Tables["chk_access"].Clear();
                }
                string user = edpcom.PCURRENT_USER;
                edpcon.Open();
                mycmd = new SqlCommand("select distinct(GCODE) from access where USER_CODE='" + user + "'", edpcon.mycon);
                myda.SelectCommand = mycmd;
                bool bu = Convert.ToBoolean(myda.Fill(ds, "chk_access"));
                edpcon.Close();
                if (bu)
                {
                    int coun = ds.Tables["chk_access"].Rows.Count - 1;
                    int i = 0;
                    while (i <= coun)
                    {
                        arr.Add(ds.Tables["chk_access"].Rows[i][0]);
                        i++;
                    }
                    coun = arr.Count - 1;
                    i = 0;
                    
                    while (i <= coun)
                    {
                        if (Information.IsNothing(ds.Tables["com_info"]) == false)
                        {
                            ds.Tables["com_info"].Clear();
                        }
                        string gcode = Convert.ToString(arr[i]);
                        edpcon.Open();

                        
                        
                        mycmd = new SqlCommand("SELECT CO.CO_NAME,CO.CO_SDATE,CO.CO_EDATE,CO.FICode," +
                        "BR.Comp_Type from company CO INNER JOIN Branch BR ON CO.FICode=BR.FICode AND " +
                        " CO.GCODE=BR.GCODE where CO.GCODE='" + gcode + "' AND BR.BRNCH_CODE='0'", edpcon.mycon);
                        
                        myda.SelectCommand = mycmd;
                        myda.Fill(ds, "com_info");
                        edpcon.Close();
                        string[] CompType = new string[] { };
                        CompType = ds.Tables["com_info"].Rows[0]["Comp_Type"].ToString().Split('-');
                        if (CompType.Length > 1)
                            btnSelect.Tag = CompType[1].Trim();
                        else
                            btnSelect.Tag = "";

                        lbxSelectname.Items.Add(ds.Tables["com_info"].Rows[0][0].ToString() + " - " + btnSelect.Tag.ToString());
                        btnSelect.Tag = "";
                        i++;
                    }
                    lbxSelectname.SelectedIndex = Convert.ToInt16(edpcom.GetFromRegisrty("LastSel", "PayRollManagementSystem\\LastSel"));
                    lbxSelectyear.SelectedIndex = Convert.ToInt16(edpcom.GetFromRegisrty("LastYear", "PayRollManagementSystem\\LastYear"));
                }
                else
                {
                    EDPMessage.Show("No permission found against this User");
                    ds.Tables["chk_access"].Clear();
                    this.Close();
                }
            }
            catch
            {
                //lbxSelectname.SelectedIndex = 0;
                //lbxSelectyear.SelectedIndex = 0;
            }
        }

        private void Select_Branch(string brn_name)
        {
            try
            {
                edpcon.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                mycmd = new SqlCommand("select session_no,AUTOINCRE from AccordFourlog order by session_no", edpcon.mycon);
                da.SelectCommand = mycmd;
                da.Fill(ds, "incre_sess");
                edpcon.Close();
                int cou1 = ds.Tables["incre_sess"].Rows.Count - 1;
                int session = Convert.ToInt32(ds.Tables["incre_sess"].Rows[cou1][0]);   // Session Creation 
                int auto = Convert.ToInt32(ds.Tables["incre_sess"].Rows[cou1][1]);
                session++;
                auto++;
                ds.Tables["incre_sess"].Clear();
                edpcom.CURRENTSESSION = session;
                //edpcom.CURRENT_COMPANY = lbxbranch_name.SelectedItem.ToString();
                //edpcom.CURRENT_COMPANY = brn_name;
                numeric_chk = 100;
                string ucode, gcode, opti, clti;
                ucode = edpcom.PCURRENT_USER;
                gcode = edpcom.PCURRENT_GCODE;
                opti = DateTime.Now.ToLongTimeString();
                clti = DateTime.Now.ToLongTimeString();
                string open_dt, close_dt;
                open_dt = edpcom.getSqlDateStr(DateTime.Today);
                close_dt = edpcom.getSqlDateStr(DateTime.Today);
                edpcon.Open();
                int xlsv;
                if (Edpcom.EDPCommon.UserCount == 1)
                    xlsv = 1;
                else
                    xlsv = 0;
                string Sql = "insert into AccordFourlog(LOG_UCODE, LOG_GCODE, LOG_CCODE,FORM_NAME, FORM_CODE, DATE_FROM, TIME_FROM, DATE_TO, TIME_TO, LOG_STAT, MACHINE_NAME, Exclusive, session_no)";
                Sql = Sql + "values('" + ucode + "','" + gcode + "','" + gcode + "','Company Change'," + 0 + ",'" + open_dt + "','" + opti + "','" + close_dt + "','" + clti + "'," + 0 + ",'" + Environment.MachineName + "'," + xlsv + "," + session + ")";
                mycmd = new SqlCommand(Sql, edpcon.mycon);
                mycmd.ExecuteNonQuery();
                edpcon.Close();
                //Slct_Brnch = true;
                this.Close();
                edpcom.SetInRegistry(Convert.ToString(0), "LastBr", "PayRollManagementSystem\\LastBr");
                //new frmConfig().get_CNFGCode();
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            common.CompanyNameFinancialYear = lblDisplay.Text;
            edpcom.CURRENT_COMPANY = ds.Tables["com_info1"].Rows[lbxSelectyear.SelectedIndex]["CO_NAME"].ToString().Trim();
            edpcom.PCURRENT_GCODE = arr[lbxSelectname.SelectedIndex].ToString().Trim();
            edpcom.CurrentFicode = ds.Tables["com_info1"].Rows[lbxSelectyear.SelectedIndex][3].ToString().Trim();
            edpcom.CURRCO_SDT = Convert.ToDateTime(ds.Tables["com_info1"].Rows[lbxSelectyear.SelectedIndex][1].ToString());
            edpcom.CURRCO_EDT = Convert.ToDateTime(ds.Tables["com_info1"].Rows[lbxSelectyear.SelectedIndex][2].ToString());
          
            
            int Branch_Count = Convert.ToInt32(edpcom.GetresultS("SELECT COUNT(DISTINCT BRNCH_NAME) FROM Branch WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'"));
            if (Branch_Count > 1)
            {
                ////////////frmselect_branch bran = new frmselect_branch();
                //////////bran.ShowDialog();
            }
            else
            {
                string Branch_Name = edpcom.GetresultS("SELECT DISTINCT BRNCH_NAME FROM Branch WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'");
                Select_Branch(Branch_Name);
            }
            if (common.Undo == 100)
            {
                common.Undo = 0;
                return;
            }
            ds.Tables["com_info"].Clear();
            numeric_chk = 100;
            this.Close();
            try
            {
                edpcom.SetInRegistry(Convert.ToString(lbxSelectname.SelectedIndex), "LastSel", "PayRollManagementSystem\\LastSel");
                edpcom.SetInRegistry(Convert.ToString(lbxSelectyear.SelectedIndex), "LastYear", "PayRollManagementSystem\\LastYear");
            }
            catch { }

            try
            {
                try
                {
                    string S1 = "";
                    try
                    {
                        //S1 = Convert.ToString(Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").GetValue("EC_NDATE"));
                        //S1 = Convert.ToString(edpcom.GetFromRegisrty("EC_NDATE", "PayRollManagementSystem\\Company"));

                        S1 = Convert.ToString(edpcom.GetFromRegisrty("EC_NDATE", "SOFTWARE\\DATARAM"));
                    }
                    catch { }
                    if (S1 == null)
                    {
                        edpcom.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_DATE", "SOFTWARE\\DATARAM");
                        edpcom.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_LDATE", "SOFTWARE\\DATARAM");
                        edpcom.SetInRegistry("180", "EC_NDATE", "SOFTWARE\\DATARAM");
                        edpcom.SetInRegistry("A0000100", "EC_TRANS", "SOFTWARE\\DATARAM");
                        edpcom.SetInRegistry("B0000200", "EC_SESSION", "SOFTWARE\\DATARAM");
                        edpcom.SetInRegistry("C0000011", "EC_COMPANY", "SOFTWARE\\DATARAM");

                        //Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").SetValue("EC_DATE", DateTime.Now.ToShortDateString());
                        //Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").SetValue("EC_LDATE", DateTime.Now.ToShortDateString());
                        //Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").SetValue("EC_NDATE", "0");
                        //Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").SetValue("EC_TRANS", "A0000100");
                        //Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").SetValue("EC_SESSION", "B0000200");
                        //Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").SetValue("EC_COMPANY", "C0000011");
                    }
                    if (S1 == "")
                    {
                        edpcom.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_DATE", "SOFTWARE\\DATARAM");
                        edpcom.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_LDATE", "SOFTWARE\\DATARAM");
                        edpcom.SetInRegistry("180", "EC_NDATE", "SOFTWARE\\DATARAM");
                        edpcom.SetInRegistry("A0000100", "EC_TRANS", "SOFTWARE\\DATARAM");
                        edpcom.SetInRegistry("B0000200", "EC_SESSION", "SOFTWARE\\DATARAM");
                        edpcom.SetInRegistry("C0000011", "EC_COMPANY", "SOFTWARE\\DATARAM");

                        //Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").SetValue("EC_DATE", DateTime.Now.ToShortDateString());
                        //Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").SetValue("EC_LDATE", DateTime.Now.ToShortDateString());
                        //Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").SetValue("EC_NDATE", "0");
                        //Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").SetValue("EC_TRANS", "A0000100");
                        //Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").SetValue("EC_SESSION", "B0000200");
                        //Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ERROR").SetValue("EC_COMPANY", "C0000011");
                    } 
                }
                catch { }

                //DateTime LDate = Convert.ToDateTime(Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR").GetValue("EC_LDATE"));

                DateTime LDate = Convert.ToDateTime(edpcom.GetFromRegisrty("EC_LDATE", "SOFTWARE\\DATARAM"));

                if (LDate > Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    EDPMessage.Show("Plese Correct the system date.");
                    //Environment.Exit(0);
                    string TTN = Convert.ToString(edpcom.GetFromRegisrty("EC_TRANS", "SOFTWARE\\DATARAM"));
                    //////////ProductKey PK = new ProductKey();
                    ////////PK.GetKeyCode(TTN, true);
                    ////////PK.ShowDialog();
                }
                //Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR", true).SetValue("EC_LDATE", DateTime.Now.ToShortDateString());
                //DateTime PDate = Convert.ToDateTime(Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR").GetValue("EC_DATE"));
                //int NDATE = Convert.ToInt32(Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR").GetValue("EC_NDATE"));

                edpcom.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_LDATE", "SOFTWARE\\DATARAM");
                DateTime PDate = Convert.ToDateTime(edpcom.GetFromRegisrty("EC_DATE", "SOFTWARE\\DATARAM"));
                int NDATE = Convert.ToInt32(edpcom.GetFromRegisrty("EC_NDATE", "SOFTWARE\\DATARAM"));

                int sd = LDate.DayOfYear;
                int ed = PDate.DayOfYear;
                if (NDATE == 0)
                {
                    //////////ClassActivation CA = new ClassActivation();
                    //CA.Check_All_Transactions();
                    ////////////CA.Chk_Days_Error(true);
                    //ProductKey PK = new ProductKey();
                    //PK.ShowDialog();
                }
                else if (sd - ed >= NDATE)
                {
                    ////////////ClassActivation CA = new ClassActivation();
                    //////////////CA.Chk_Days_Error(false);
                }

            }
            catch { }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (common.SLCOMFLAG == 23)
                this.Close();
            else
                Environment.Exit(0);
        }
        private void lbxSelectname_SelectedIndexChanged(object sender, EventArgs e)
        {
            common.ClearDataTable(ds.Tables["com_info1"]);
            lbxSelectyear.Items.Clear();
            int index = lbxSelectname.SelectedIndex;
            DateTime fyear, fyear1;
            string str;
            string gco = arr[index].ToString();
            edpcon.Open();
            mycmd = new SqlCommand("select CO_NAME,CO_SDATE,CO_EDATE,FICode from company where GCODE='" + gco + "'", edpcon.mycon);
            myda.SelectCommand = mycmd;
            myda.Fill(ds, "com_info1");
            edpcon.Close();
            int co = ds.Tables["com_info1"].Rows.Count - 1;
            for (int z = 0; z <= co; z++)
            {
                fyear = Convert.ToDateTime(ds.Tables["com_info1"].Rows[z][1]);
                fyear1 = Convert.ToDateTime(ds.Tables["com_info1"].Rows[z][2]);
                str = fyear.Date.ToShortDateString();
                str = str + "-" + fyear1.Date.ToShortDateString();
                lbxSelectyear.Items.Add(str);
            }
            lbxSelectyear.SelectedIndex = 0;
        }
        private void frmSelectcomp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (numeric_chk == 0)
                common.SLCOMFLAG1 = 25;
            ////////////edpcom.UpdatePayRollManagementSystemLog(this, false);
            edpcom.saveFormPosition(this.Name, this.Location);
            //if (common.SLC_COMP)
            //    if (numeric_chk == 0)
            //        Environment.Exit(0);
            //this.Close();
        }
        private void lbxSelectyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDisplay.Text = lbxSelectname.SelectedItem + " (" + lbxSelectyear.SelectedItem.ToString() + ")";
        }
        private void lbxSelectyear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSelect_Click(sender, e);
            }
        }
        private void lbxSelectname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbxSelectyear.Focus();
            }
        }

        private void frmSelectcomp_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.Close();
            //}
            //else
            //{
            //    return;
            //}
        }

        private void lbxSelectname_Enter(object sender, EventArgs e)
        {
            if (sender == lbxSelectname)
                lbxSelectname.BackColor = Color.Cornsilk;
            else lbxSelectyear.BackColor = Color.Cornsilk;
        }

        private void lbxSelectname_Leave(object sender, EventArgs e)
        {
            if (sender == lbxSelectname)
                lbxSelectname.BackColor = Color.White;
            else lbxSelectyear.BackColor = Color.White;
        }

        private void frmSelectcomp_Shown(object sender, EventArgs e)
        {
            if (lbxSelectname.Items.Count == 1)
            {
                lbxSelectname.SelectedIndex = 0;
                if (lbxSelectyear.Items.Count == 1)
                {
                    lbxSelectyear.SelectedIndex = 0;
                    btnSelect_Click(sender, e);
                }
            }
        }


    }
}

//--------------------------------------------------PayRollManagementSystem---------------------------------
//-----------------------------------------------EDP Software Limited-------------------------------------------