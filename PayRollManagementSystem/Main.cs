using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//partha
using Edpcom;
using PayRollManagementSystem.Properties;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.IO;
using System.Collections;
using EDPComponent;
using EDPMessageBox;
using Microsoft.VisualBasic.FileIO;
using System.Threading;
using System.Runtime.InteropServices;
using EDPVersion;
using FirstTimeNeed;
//using EDPComponent;
//using EDPMessageBox;
//using System.Threading;

//partha

namespace PayRollManagementSystem
{
    public partial class Main : Form
    {
        Conn cnn = new Conn(); 
        string aa = "";
        public Edpcom.EDPCommon EDPComm;
        //partha
        ToolStrip tlstrp = new ToolStrip();
        DataSet ds = new DataSet();
        DataSet DS = new DataSet();
        SqlCommand com = new SqlCommand();
        public SqlDataAdapter da = new SqlDataAdapter();
        bool TOOLBARBTN = false;
        public MenuStrip mms = new MenuStrip();
        MenuStrip MenuC = new MenuStrip();
        MenuGen MEG = new MenuGen();
        public string CurrUser, DataVersion;
        public SqlCommand mycmd;

        int openindex = 0, SI = 0;
        double cnt_lv = 0,empsal=0;
        private string databaseName;
        private string serverName;
        String[] instances123;
        bool chk_Control = false, Form_Exit = false;
        string typeOfEnvironment = "";
       
        public EDPVersion.versionEDP version1 = new versionEDP();

        

        public Main()
        {
            InitializeComponent();
        }
        
       

        private void getApplicationParameters()
        {
            int iiii = 0;
           
            try
            {
                String[] arguments = Environment.GetCommandLineArgs();


                Edpcom.EDPCommon edpcom = new EDPCommon();

                openindex = Array.IndexOf(arguments, "-t");

                if (openindex < 0)
                    openindex = Array.IndexOf(arguments, "-T");

                int svrindex = Array.IndexOf(arguments, "-s");
                if (svrindex < 0)
                {
                    serverName = Environment.MachineName;
                    edpcom.Remote = false;
                    SI = svrindex;
                }
                else
                {
                    serverName = arguments[svrindex + 1];
                    edpcom.Remote = true;
                    SI = svrindex;
                }
                int dbindex = Array.IndexOf(arguments, "-d");
                if (dbindex < 0)
                {
                    databaseName = "EDP_Payroll";
                    //databaseName = "win3009_swingdb";
                }
                else
                {
                    databaseName = arguments[dbindex + 1];
                }
                int data = Array.IndexOf(arguments, "-v");
                //if (data < 0)
                if (iiii == 1)
                {
                    DataVersion = "2005";
                }
                else
                {
                    DataVersion = arguments[data + 1];
                }
                int demoindex = Array.IndexOf(arguments, "-L");


            }
            catch { }
           
        }

        //======================================end of block2 =========================================//
        //=====================================start of block 3========================================//
        // SuperUser calling & create for first time if existing user not found
        //checkversion() is clling from here checkversion() written in version dll

        private void sqlinstance()
        {
            //int iiii = 0;
            try
            {
                Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\");
                String[] instances = (String[])rk.GetValue("InstalledInstances");
                instances123 = instances;

                if (Information.IsNothing(instances[0]) != true)
                {
                    if (Convert.ToString(instances[0]).Trim().ToUpper() == "SQLEXPRESS")
                    {
                       // iiii = 1;
                        EDPMessage.Show("SQL Express Detected." + "\r\n" + "Press OK to continue.", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                    else
                    {
                        EDPMessage.Show("SQL Express not detected." + "\r\n" + "Press OK to continue.", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                    }
                }
            }
            catch
            {
                EDPMessage.Show("SqlServer Not Detected");
                Environment.Exit(0);
                Application.Exit();
            }

        }

        private void employeeJoiningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpJoining objempjoin = new EmpJoining();
            objempjoin.ShowDialog();
        }

        private void salaryStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salaryHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private void salaryAlertmentToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    EmployeeSalaryAlert objsalalt = new EmployeeSalaryAlert();
        //    objsalalt.ShowDialog();
        //}

        private void jobTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void designationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void employeeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpAttendance Ea = new frmEmpAttendance();
            Ea.Show();
        }

        private void configureSalaryStractureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config_SalaryStructure_Formula css = new Config_SalaryStructure_Formula();
            css.ShowDialog();
        }

        private void configureRetirementDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config_RetirementDetails rd = new Config_RetirementDetails();
            rd.ShowDialog();
        }

        private void salaryAllotmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeSalaryDetails empsal = new EmployeeSalaryDetails();
            empsal.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Employee_Salary_Structure objempsalarystruct = new Employee_Salary_Structure();
            objempsalarystruct.ShowDialog();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salary_Head objempsalaryhead = new Salary_Head();
            objempsalaryhead.ShowDialog();
        }

        private void jobMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee_Type emptype = new Employee_Type();
            emptype.ShowDialog();
        }

        private void designationMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Designation_Master designation = new Designation_Master();
            designation.ShowDialog();
        }

        private void leaveDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config_LeaveDetails lv = new Config_LeaveDetails();
            lv.ShowDialog();
        }

        private void leaveEncashmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeaveEncashment lcash = new LeaveEncashment();
            lcash.ShowDialog();
        }

        private void paySlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee_PaySlip ps = new Employee_PaySlip();
            ps.Show();
        }

        private void salaryBillToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void leaveEncashmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Report_LeaveEnCashment lec = new Report_LeaveEnCashment();
            lec.ShowDialog();
        }

        private void exgratiaMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config_ExGratia exg = new Config_ExGratia();
            exg.ShowDialog();
        }

        private void exGratiaCalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExgratiaCalculation exg_cal = new ExgratiaCalculation();
            exg_cal.ShowDialog();
        }

        private void leaveStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Leave_Statement ls = new Leave_Statement();
            ls.ShowDialog();
        }

        private void salaryIncrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncrementSalary inc = new IncrementSalary();
            inc.ShowDialog();
        }

        private void statementOfExgratiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statement_of_Exgratia soe = new Statement_of_Exgratia();
            soe.ShowDialog();
        }

        private void billOfExgratiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bill_of_Exgratia be = new Bill_of_Exgratia();
            be.ShowDialog();
        }

        private void incrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Increment inc = new Increment();
            inc.ShowDialog();
        }



        private void aquitanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salary_Bill sb = new Salary_Bill();
            sb.ShowDialog();
        }

        private void aquittanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AquittanceReport ar = new AquittanceReport();
            //ar.ShowDialog();
            frmAquittance ar = new frmAquittance();
            ar.ShowDialog();
        }

        private void arrearsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Arrears ar = new Arrears();
            ar.ShowDialog();
        }

        private void arrearPayslipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrearPaySlip ap = new ArrearPaySlip();
            ap.ShowDialog();
        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrearPaySlipReport apr = new ArrearPaySlipReport();
            apr.ShowDialog();
        }

        private void billToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ArrearBillReport ab = new ArrearBillReport();
            ab.ShowDialog();
        }

        private void aquittanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ArrearAquittanceReport aq = new ArrearAquittanceReport();
            aq.ShowDialog();
        }

        private void pTRateEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmPTRateEditor().ShowDialog();
        }

        private void pFESIRateEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config_PFandESI pf = new Config_PFandESI();
            pf.ShowDialog();
        }

        private void sectionMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmSectionMaster().ShowDialog();
        }

        private void pFRep1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PFReport1 pf = new PFReport1();
            pf.ShowDialog();
        }

        private void sSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Employee_Heads_to_Structure hts = new Employee_Heads_to_Structure();
            //hts.ShowDialog();
        }

        private void sSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmAddErnDeduc().ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MnthlySalRate msr = new MnthlySalRate();
            msr.ShowDialog();
        }
       
        private void Main_Load(object sender, EventArgs e)
        {
            
            textBox1.Text = "";
            //int i;
            //int ab = 0;

            try
            {
                this.Opacity = 40;
                //Following code block has been added by dwipraj dutta 24102017 in order to identify if the date format is in correct format or not.
                string sysUIFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (sysUIFormat != "dd/MM/yyyy")
                {
                    EDPMessageBox.EDPMessage.Show("Please change date format to [dd/MM/yyyy] first.");
                    return;
                }
                getApplicationParameters();
                EDPComm = new Edpcom.EDPCommon();

                EDPComm.PSERVER_NAME = serverName;
                EDPComm.DataSourceExtention = "SQLEXPRESS";

               
                EdpConnectionDetails ec = new EdpConnectionDetails("FC");
                ec.PASSINGVALUE(instances123); //QC Block 9
                ec.ShowDialog();
               
                EDPComm.PDEVELOPER_NAME = "EDP SOFT";
                EDPComm.GetMsg = true;
                EDPComm.DataVersion = DataVersion;
                EDPComm.ApplicationName = EDPComm.PDATABASE_NAME;// "EDP_Payroll";
                EDPComm.ApplicationExtension = "mbf";
                Edpcom.EDPConnection EDPConn = new EDPConnection();
                Edpcom.EDPCommon edpcom = new EDPCommon();
                Edpcom.EDPConnection edpcon = new EDPConnection();
                FirstTimeNeed.clsfirsttime First = new FirstTimeNeed.clsfirsttime();
                

                databaseName= EDPComm.PDATABASE_NAME;
                try
                {
                  //  bool flag_Instance = false;
                    string str_instances = "";
                    if (EDPComm.DataSourceExtention.Length > 0)
                        str_instances = EDPComm.DataSourceExtention.Substring(1, EDPComm.DataSourceExtention.Length - 1);
                    str_instances = "MSSQL$" + str_instances;

                }
                catch { }
                //======== Block 10 =======END ==== Coding For SQL Server Services Status in Running/Stop mode and status can change through this code
                //End 02.08.13

                
                try
                {
                   
                    edpcon.Open();                 

                }
                catch
                {
                    //Block 13
                    string st = "";
                    //Add S Dutta 25.08.12
                    if (new EDPCommon().DataVersion == "2005")
                    {
                        st = "Data Version " + new EDPCommon().DataVersion;
                        if (edpcom.Integrated_Security == "" && edpcom.NetWork_library == "")
                        {
                            EDPMessage.Show("Press OK to continue.");
                                //" " + st + ";Data Source=" + edpcom.PSERVER_NAME + "" + edpcom.DataSourceExtention + ";" + "\r\n" + "Persist Security Info=" + EDPComm.Persist_Security_Info + ";Initial Catalog=" + edpcom.PDATABASE_NAME + ";" + "\r\n" + "User ID=" + edpcom.User_ID + ";Password=" + edpcom.Password + ";Trusted_Connection=" + edpcom.Trusted_Conection + ";Connection Timeout=" + edpcom.Conection_TimeOut + ";" + "\r\n" + "Press OK to continue.");
                        }
                        else if (edpcom.Integrated_Security == "")
                        {
                            EDPMessage.Show("Press OK to continue.");
                            //" " + st + ";Data Source=" + edpcom.PSERVER_NAME + "" + edpcom.DataSourceExtention + ";" + "\r\n" + "Network Library=" + edpcom.NetWork_library + ";Persist Security Info=" + EDPComm.Persist_Security_Info + ";Initial Catalog=" + edpcom.PDATABASE_NAME + ";" + "\r\n" + "User ID=" + edpcom.User_ID + ";Password=" + edpcom.Password + ";Trusted_Connection=" + edpcom.Trusted_Conection + ";Connection Timeout=" + edpcom.Conection_TimeOut + ";" + "\r\n" + "Press OK to continue.");
                        }
                        else if (edpcom.NetWork_library == "")
                            EDPMessage.Show("Press OK to continue.");
                        //" " + st + "; Data Source=" + edpcom.PSERVER_NAME + "" + edpcom.DataSourceExtention + ";" + "\r\n" + "Integrated Security=" + edpcom.Integrated_Security + ";Persist Security Info=" + EDPComm.Persist_Security_Info + ";Initial Catalog=" + edpcom.PDATABASE_NAME + ";" + "\r\n" + "User ID=" + edpcom.User_ID + ";Password=" + edpcom.Password + ";Trusted_Connection=" + edpcom.Trusted_Conection + ";Connection Timeout=" + edpcom.Conection_TimeOut + ";" + "\r\n" + "Press OK to continue.");
                        else
                            EDPMessage.Show("Press OK to continue.");
                                             
                    }
                    else
                    {
                        st = "Data Version " + new EDPCommon().DataVersion;
                        if (edpcom.Integrated_Security == "" && edpcom.NetWork_library == "")
                            EDPMessage.Show("Press OK to continue.");
                        //" " + st + ";Data Source=" + edpcom.PSERVER_NAME + "" + edpcom.DataSourceExtention + ";" + "\r\n" + "Persist Security Info=" + EDPComm.Persist_Security_Info + ";Initial Catalog=" + edpcom.PDATABASE_NAME + ";" + "\r\n" + "User ID=" + edpcom.User_ID + ";Password=" + edpcom.Password + ";Trusted_Connection=" + edpcom.Trusted_Conection + ";Connection Timeout=" + edpcom.Conection_TimeOut + ";" + "\r\n" + "Press any key to continue.");
                        else if (edpcom.Integrated_Security == "")
                        {
                            EDPMessage.Show("Press OK to continue.");
                            //" " + st + ";Data Source=" + edpcom.PSERVER_NAME + "" + edpcom.DataSourceExtention + ";" + "\r\n" + "Network Library=" + edpcom.NetWork_library + ";Persist Security Info=" + EDPComm.Persist_Security_Info + ";Initial Catalog=" + edpcom.PDATABASE_NAME + ";" + "\r\n" + "User ID=" + edpcom.User_ID + ";Password=" + edpcom.Password + ";Trusted_Connection=" + edpcom.Trusted_Conection + ";Connection Timeout=" + edpcom.Conection_TimeOut + ";" + "\r\n" + "Press OK to continue.");
                        }
                        else if (edpcom.NetWork_library == "")
                            EDPMessage.Show("Press OK to continue.");
                        //" " + st + ";Data Source=" + edpcom.PSERVER_NAME + "" + edpcom.DataSourceExtention + ";" + "\r\n" + "Integrated Security=" + edpcom.Integrated_Security + ";Persist Security Info=" + EDPComm.Persist_Security_Info + ";Initial Catalog=" + edpcom.PDATABASE_NAME + ";" + "\r\n" + "User ID=" + edpcom.User_ID + ";Password=" + edpcom.Password + ";Trusted_Connection=" + edpcom.Trusted_Conection + ";Connection Timeout=" + edpcom.Conection_TimeOut + ";" + "\r\n" + "Press OK to continue.");
                        else
                            EDPMessage.Show("Press OK to continue.");
                        //" " + st + ";Data Source=" + edpcom.PSERVER_NAME + "" + edpcom.DataSourceExtention + ";" + "\r\n" + "Network Library=" + edpcom.NetWork_library + ";Integrated Security=" + edpcom.Integrated_Security + ";Persist Security Info=" + EDPComm.Persist_Security_Info + ";Initial Catalog=" + edpcom.PDATABASE_NAME + ";" + "\r\n" + "User ID=" + edpcom.User_ID + ";Password=" + edpcom.Password + ";Trusted_Connection=" + edpcom.Trusted_Conection + ";Connection Timeout=" + edpcom.Conection_TimeOut + ";" + "\r\n" + "Press OK to continue.");
                    }
                    //End 25.08.12
                    SqlConnection con;
                    string ID = "edp1";
                    if (new EDPCommon().DataVersion == "2005")
                        if (edpcom.Remote)
                            con = new SqlConnection("Initial Catalog=master;Data Source=" + EDPComm.PSERVER_NAME + "" + edpcom.DataSourceExtention + ";User ID=" + ID + "; Password=" + edpcom.Password + "; Connection Timeout=" + edpcom.Conection_TimeOut + ";");
                        else
                            con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=master;Data Source=" + EDPComm.PSERVER_NAME + "" + edpcom.DataSourceExtention + "; Connection Timeout=" + edpcom.Conection_TimeOut + ";");
                    else
                        con = new SqlConnection("Data Source=" + EDPComm.PSERVER_NAME + "" + edpcom.DataSourceExtention + ";Initial Catalog=master;Integrated Security=True;pooling=true; Connection Timeout=" + edpcom.Conection_TimeOut + ";");
                    //con = new SqlConnection("Data Source=" + EDPComm.PSERVER_NAME + "" + edpcom.DataSourceExtention + ";Initial Catalog=master;Integrated Security=SSPI; Connection Timeout=" + edpcom.Conection_TimeOut + ";Persist Security Info=False;");

                    if (!edpcom.Remote)
                    {
                       
                        try
                        {
                          
                            con.Open();
                             //if you dttach database then database attach automaticaly
                            try
                            {
                                string sq3 = "SELECT name FROM sys.sysdatabases where name ='" + edpcom.PSERVER_NAME + "'";
                                mycmd = new SqlCommand(sq3, con);
                                da.SelectCommand = mycmd;
                                DataSet ds2 = new DataSet();
                                da.Fill(ds2, "SqlRoot2");
                                if (ds2.Tables["SqlRoot2"].Rows.Count > 0)
                                {
                                    EDPMessage.Show(" Sql Server is not ready");
                                    return;
                                }

                                string sq2 = "SELECT SUBSTRING(physical_name, 1, CHARINDEX(N'master.mdf', LOWER(physical_name)) - 1)  FROM master.sys.master_files   WHERE database_id = 1 AND file_id = 1";
                                mycmd = new SqlCommand(sq2, con);
                                da.SelectCommand = mycmd;
                                DataSet ds1 = new DataSet();
                                da.Fill(ds1, "SqlRoot");
                                if (ds1.Tables["SqlRoot"].Rows.Count > 0)
                                {
                                    try
                                    {
                                        mycmd = new SqlCommand("CREATE DATABASE [EDP_Payroll] ON ( FILENAME = N'" + ds1.Tables["SqlRoot"].Rows[0][0] + "EDP_Payroll.mdf' ),( FILENAME = N'" + ds1.Tables["SqlRoot"].Rows[0][0] + "EDP_Payroll_log.LDF' ) FOR ATTACH", con);
                                        mycmd.ExecuteNonQuery();

                                        TextBox T1 = new TextBox();
                                        for (long ii = 0; ii <= 3000000; ii++)
                                        {
                                            T1.Text = Convert.ToString(ii);
                                            T1.Refresh();
                                        }

                                        EDPMessage.Show(" Attach EDP_Payroll DataBase ");

                                        edpcon.Open();
                                        conectiondetails_insert();//Block 11                              
                                        con.Close();
                                        edpcon.Close();
                                    }
                                    catch
                                    {
                                        //EDPMessage.Show(ex.Message);

                                        //FirstTimeNeed.clsfirsttime First1 = new clsfirsttime();
                                        if (First.database_creation(Environment.CurrentDirectory, con, databaseName))
                                        {
                                            if (First.use_db(con, databaseName))
                                            {
                                                con.Close();
                                                con.Dispose();
                                            }
                                            else
                                            {
                                                First.database_creation(Environment.CurrentDirectory, con, databaseName);
                                                First.use_db(con, databaseName);
                                            }
                                        }
                                        else
                                        {
                                            First.database_creation(Environment.CurrentDirectory, con, databaseName);
                                            First.use_db(con, databaseName);
                                        }

                                    }
                                }
                            }
                            catch 
                            {
                                EDPMessage.Show(" Sql Server is not ready");                               
                            }                            
                        }
                        catch (Exception ex)
                        { EDPMessage.Show(ex.Message); }
                        //}
                        try
                        {
                                                     
                            edpcon.Open();
                        }
                        catch { }
                    }
                }
                EDPVersion.clsMenuEntry Edpvr = new EDPVersion.clsMenuEntry();
                try
                {
                    //dwipraj dutta 14092017 when version willbe upgrade from CONFIGURATION_SETTINGS.txt 
                    //the newly added menus will not be shown if the below line is commented. 
                    //But using below line every time when applications loads menus are insertted again and again so it takes much time to sturtup 
                    Edpvr.Entermenufirst(edpcon.mycon);

                }
                catch { }
                Configuration_Menu_TypeDoc_companySetting();
                if (!edpcom.CheckDb())
                {

                    First.veryfirst(edpcon.mycon);
                    edpcom.writeToIni(Application.StartupPath + "\\Settings.edp", "Envelope", "FLAG", edpcom.EnvironMent_Envelope);
                }
                // Environment Configaration

                //
                try
                {
                    Menu_Authority(); // bibhas - 15/03/2018
                    //go to the function to see its details
                }
                catch { }
              
                int chk, chk1;
                mycmd = new SqlCommand("select * from pasword", edpcon.mycon);
                da.SelectCommand = mycmd;
                da.Fill(DS, "chk1");
                mycmd = new SqlCommand("select * from AccordFourlog", edpcon.mycon);
                da.SelectCommand = mycmd;
                da.Fill(DS, "chk2");
                edpcon.Close();
                chk = DS.Tables["chk1"].Rows.Count;
                chk1 = DS.Tables["chk2"].Rows.Count;
                if (chk == 0 && chk1 == 0)
                {
                    edpcom.CreateSubkey("EDP_Payroll\\Firsttime");
                    edpcom.CreateSubkey("EDP_Payroll\\LastSel");
                    edpcom.CreateSubkey("EDP_Payroll\\LastYear");
                    edpcom.CreateSubkey("EDP_Payroll\\LastBr");
                    frmSuperuser frmsu = new frmSuperuser();        //SuperUser call & create for first time
                    frmsu.ShowDialog();
                }
                edpcon.Open();
                common.ConSrting = edpcon.mycon.ConnectionString;
                edpcon.Close();
                // prog.CbuildDate;
                string sql = "Select * from ACCORD_DB_INFO order by build_date desc";
                edpcon.Open();
                mycmd = new SqlCommand(sql, edpcon.mycon);
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter();
                DateTime PBuildDate;
                dap.SelectCommand = mycmd;
                version1.Versionflg = true;

                if (Convert.ToBoolean(dap.Fill(ds, "db")))
                {
                    PBuildDate = (DateTime)ds.Tables["db"].Rows[0][3];
                    if (PBuildDate != edpcom.PBUILD_DATE)
                    {
                        EDPConn.Open();
                        version1.ChkVersion(EDPConn.mycon, edpcom.PBUILD_DATE, PBuildDate);
                        EDPConn.Close();
                    }
                  
                }
                else
                {
                    edpcom.CurrentFicode = "1";
                    edpcom.PCURRENT_GCODE = "1";

                    PBuildDate = Convert.ToDateTime(Resources.Release_Date);
                    edpcom.FirstTimeInstall = true;
                    version1.ChkVersion(edpcon.mycon, edpcom.PBUILD_DATE, PBuildDate);//EDPConn.mycon

                }
                if (!version1.Versionflg)
                    Environment.Exit(0);
                if (edpcom.CheckInstalledCompany()) //Block 12 // Auto display for company install form if first time
                {
                    edpcom.SetInRegistry("1", "First", "EDP_Payroll\\Firsttime");
                    edpcon.Open();
                    mycmd = new SqlCommand("delete from ficodegen", edpcon.mycon);//delete all the Previous ficode list
                    mycmd.ExecuteNonQuery();
                    edpcon.Close();
                    ////////frmInstall frmins = new frmInstall();
                    int co_code = 0; 
                    frmcompanyMaster frmins = new frmcompanyMaster();
                    frmins.getcode(co_code, "C");
                    edpcom.GetMsg = false;
                    //////////frmins.rdb_select();
                    //////////frmins.Next();
                    frmins.ShowDialog();

                    if (frmins.DialogResult == DialogResult.Cancel)
                    {
                        edpcon.Open();
                        mycmd = new SqlCommand("select * from company", edpcon.mycon);
                        da.SelectCommand = mycmd;
                        da.Fill(DS, "chk_com");
                        edpcon.Close();
                        int temp = DS.Tables["chk_com"].Rows.Count;
                        DS.Tables["chk_com"].Clear();
                        if (temp == 1)
                            PasswordChk();
                        else
                            this.Close();
                    }
                }
                else
                {
                    //create Multiple superuser for One DataBase (03.01.14)
                    //frmnewuser fu = new frmnewuser();
                    //fu.ShowDialog();
                    //End (03.01.14)
                    PasswordChk();
                }

                if (cnt_lv == 0)
                {
                    clsDataAccess.RunQry(" Update MenuTable set Enable_Menu='False' where (MenuCode='20020090000')" + Environment.NewLine +
                        "Update MenuTable set Enable_Menu='False' where (MenuCode='40030000002')");

                }
                //=====================================Configuration=============================//
                Edpcom.ConfigChk cnfg = new ConfigChk();
                cnfg.Config_Set(EDPComm.CurrentFicode, EDPComm.PCURRENT_GCODE, EDPComm.PCURRENT_USER, edpcon.mycon);

                //=====================================Configuration=============================//
                ToolStripManager.Renderer = new EDPMenuRenderer();

                common.AutoMessageFieldUpdate();

                
                common.AutoDisplayMessage();

               
                lb_Shortcut.Visible = false;
            }
            catch (Exception ex)
            //{
            //    EDPMessage.Show("0p : " + openindex + "SI : " + SI + "serverName : " + serverName + "AB : " + ab);
            //}
            { EDPMessage.Show(ex.Message); }

         
            //==========alter add tables or fields=====================================================
           int mn = Convert.ToInt32(clsDataAccess.GetresultI("Midaslog", "job"));
           if (mn == 0)
           {
               string str = "ALTER TABLE Midaslog ADD [function] nvarchar(5) null, [job] nvarchar(Max) null";
               bool rs = clsDataAccess.RunNQwithStatus(str);
               //str = "ALTER TABLE Midaslog ADD [function] [nvarchar] (5) NULL";
               //rs = clsDataAccess.RunNQwithStatus(str);

               str = "Update Midaslog set [job]='', [function]=''";
               rs = clsDataAccess.RunNQwithStatus(str);
           }
           else
           {
               string str = "ALTER TABLE Midaslog ALTER COLUMN [job] nvarchar(Max) null";
               bool rs = clsDataAccess.RunNQwithStatus(str);

           }
            //Added by dwipraj dutta 100820170350PM
           try
           {
               MenuAccessGenerationOrUpdate();
           }
           catch (Exception ex)
           {
               EDPMessage.Show("Error : "+ex);
           }

          
            this.KeyPreview = true;

            lbl_server.Text = EDPComm.PSERVER_NAME;


            
        }

        public void conectiondetails_insert()
        {
            Edpcom.EDPCommon EDPComm = new Edpcom.EDPCommon();
            string p = Convert.ToString(EDPComm.Persist_Security_Info);
            EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "MachinName", EDPComm.PSERVER_NAME);
            EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "DataSourceExtention", EDPComm.DataSourceExtention);
            EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "NetworkLibary", EDPComm.NetWork_library);
            EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "IntergrateSecurity", EDPComm.Integrated_Security);
            EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "PersistSecurityInfo", p);
            EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "TrustedConnection", EDPComm.Trusted_Conection);
            EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "UserID", EDPComm.User_ID);
            if (EDPComm.Password == "2477147edp")
            {
                EDPComm.Password = "***";
                EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "PassWord", EDPComm.Password);
                EDPComm.Password = "2477147edp";
            }
            else
                EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "PassWord", EDPComm.Password);
            EDPComm.writeToIni(Application.StartupPath + "\\Conectioninfo.edp", "Conection", "DataBaseName", EDPComm.PDATABASE_NAME);
        }

        private void pFLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPFLoan mpl = new frmPFLoan();
            mpl.ShowDialog();
        }

        private void holidayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHolidayEntry mpl = new frmHolidayEntry();
            mpl.Show();
        }

        private void tempToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            MnthlySalRate msr = new MnthlySalRate();
            msr.ShowDialog();
        }

        private void pFRep2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PFReport2 PF = new PFReport2();
            PF.Show();
        }

        private void pFRep3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PFReport3 PF = new PFReport3();
            PF.Show();
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            statemaster exg = new statemaster();
            exg.ShowDialog();
        }

        private void countryNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Employee_Attendance exg = new Employee_Attendance();            
            Countrymaster exg = new Countrymaster();
            exg.ShowDialog();
        }

        private void qualificationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Employee_Attendance exg = new Employee_Attendance();
            Qualificationmaster exg = new Qualificationmaster();
            exg.ShowDialog();
        }

        private void relationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAllocateEmployDetails exg = new FrmAllocateEmployDetails();
            //Relation_Master exg = new Relation_Master();
            exg.ShowDialog();
        }

        private void companyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmcompanyMasterQuery exg = new FrmcompanyMasterQuery();
            exg.ShowDialog();
        }

        private void clientMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcontractPartyMaster exg = new frmcontractPartyMaster();
            exg.ShowDialog();
        }

        private void orderDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmorderdetails od = new frmorderdetails();
            od.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {           
            FrmLocationMaster lm = new FrmLocationMaster();
            lm.ShowDialog();
        }

        private void linkLocationWiseSalaryStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employ_Link_LocationSalary ls = new Employ_Link_LocationSalary();
            ls.ShowDialog();
        } 
  
        // partha
        private void Select_Branch(string brn_name)
        {
            try
            {
                Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

                edpcon.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                //Bellow line has been changed from [AccordFourlog] to [AccordFourlogDetail] 19092017
                mycmd = new SqlCommand("select session_no,AUTOINCRE from [AccordFourlogDetail] order by session_no", edpcon.mycon);
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
                edpcom.CurrentBranchname = brn_name;
                //numeric_chk = 100;
                string ucode, gcode, opti, clti;
                ucode = edpcom.PCURRENT_USER;
                gcode = edpcom.PCURRENT_GCODE;
                opti = DateTime.Now.ToLongTimeString();
                clti = DateTime.Now.ToLongTimeString();
                string open_dt, close_dt;
                open_dt = edpcom.getSqlDateStr(DateTime.Today);
                close_dt = edpcom.getSqlDateStr(DateTime.Today);
                edpcon.Open();
                int xlsv=0;
                if (Edpcom.EDPCommon.UserCount == 1)
                    xlsv = 1;
                else
                    xlsv = 0;
                
                edpcon.Close();
                
                edpcom.SetInRegistry(Convert.ToString(0), "LastBr", "EDP_Payroll\\LastBr");
                //new frmConfig().get_CNFGCode();
            }
            catch
               // Exception ex)
            {
                ////////////EDPMessage.Show(ex.Message);
            }
        }
        private void Select_Company_Count(int cO_cODE)
        {
            try
            {
                Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
                DataTable dt_Co_Details = edpcom.GetDatatable("SELECT * FROM Company WHERE CO_CODE=" + cO_cODE + "");

                //common.CompanyNameFinancialYear = lblDisplay.Text;
                common.CompanyNameFinancialYear = Convert.ToString(dt_Co_Details.Rows[0]["CO_NAME"]) + " - ( " + Convert.ToDateTime(dt_Co_Details.Rows[0]["CO_SDATE"]).ToShortDateString() + " - " + Convert.ToDateTime(dt_Co_Details.Rows[0]["CO_EDATE"]).ToShortDateString() + " )";
                edpcom.PCURRENT_GCODE = Convert.ToString(dt_Co_Details.Rows[0]["GCODE"]);
                edpcom.CurrentFicode = Convert.ToString(dt_Co_Details.Rows[0]["FICode"]);
                edpcom.CURRCO_SDT = Convert.ToDateTime(dt_Co_Details.Rows[0]["CO_SDATE"]);
                edpcom.CURRCO_EDT = Convert.ToDateTime(dt_Co_Details.Rows[0]["CO_EDATE"]);
                edpcom.CURRENT_COMPANY = Convert.ToString(dt_Co_Details.Rows[0]["CO_NAME"]);
                edpcom.EC_COMPANY = dt_Co_Details.Rows[0]["EC_COMPANY"].ToString();
                int Branch_Count = Convert.ToInt32(edpcom.GetresultS("SELECT COUNT(DISTINCT BRNCH_NAME) FROM Branch WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'"));
                if (Branch_Count > 1)
                {
                    ////////frmselect_branch bran = new frmselect_branch();
                    ////////////bran.ShowDialog();
                }
                else
                {
                    string Branch_Name = edpcom.GetresultS("SELECT DISTINCT BRNCH_NAME FROM Branch WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'");
                    Select_Branch(Branch_Name);
                }

                if (edpcom.CurrentFicode.Trim() == "")
                {
                    edpcom.CurrentFicode = "1";

                    clsDataAccess.RunQry("update Company set FICode='1'");
                }

                if (common.Undo == 100)
                {
                    common.Undo = 0;
                    return;
                }
                //ds.Tables["com_info"].Clear();
                //numeric_chk = 100;
                //this.Close();
                try
                {
                    edpcom.SetInRegistry(Convert.ToString(0), "LastSel", "EDP_Payroll\\LastSel");
                    edpcom.SetInRegistry(Convert.ToString(0), "LastYear", "EDP_Payroll\\LastYear");
                }
                catch { }

                try
                {
                    try
                    {
                        string S1 = "";
                        try
                        {
                            S1 = Convert.ToString(edpcom.GetFromRegisrty("EC_NDATE", "SOFTWARE\\DATARAM"));
                        }
                        catch { }
                        if (S1 == null )
                        {
                            edpcom.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_DATE", "SOFTWARE\\DATARAM");
                            edpcom.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_LDATE", "SOFTWARE\\DATARAM");
                            edpcom.SetInRegistry("180", "EC_NDATE", "SOFTWARE\\DATARAM");
                            edpcom.SetInRegistry("A0000100", "EC_TRANS", "SOFTWARE\\DATARAM");
                            edpcom.SetInRegistry("B0000200", "EC_SESSION", "SOFTWARE\\DATARAM");
                            edpcom.SetInRegistry(edpcom.EC_COMPANY, "EC_COMPANY", "SOFTWARE\\DATARAM");

                            cnn.SP_Dync_Proc_reg(dt_Co_Details.Rows[0]["coid"].ToString(), edpcom.EC_COMPANY, DateTime.Now.ToString("dd/MM/yyyy"),
                        DateTime.Now.ToString("dd/MM/yyyy"), "180", "B0000200",
         "A0000100", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MMM/yyyy"), "");
                        }
                        if (S1 == "" || S1 == "000" || S1 == "00" || S1 == "0")
                        {
                            edpcom.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_DATE", "SOFTWARE\\DATARAM");
                            edpcom.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_LDATE", "SOFTWARE\\DATARAM");
                            edpcom.SetInRegistry("180", "EC_NDATE", "SOFTWARE\\DATARAM");
                            edpcom.SetInRegistry("A0000100", "EC_TRANS", "SOFTWARE\\DATARAM");
                            edpcom.SetInRegistry("B0000200", "EC_SESSION", "SOFTWARE\\DATARAM");
                            edpcom.SetInRegistry(edpcom.EC_COMPANY, "EC_COMPANY", "SOFTWARE\\DATARAM");

                            cnn.SP_Dync_Proc_reg(dt_Co_Details.Rows[0]["coid"].ToString(), edpcom.EC_COMPANY, DateTime.Now.ToString("dd/MM/yyyy"),
                        DateTime.Now.ToString("dd/MM/yyyy"), "180", "B0000200",
         "A0000100", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MMM/yyyy"), "");
                        }

                        
                    }
                    catch { }
                    DateTime LDate = Convert.ToDateTime(edpcom.GetFromRegisrty("EC_LDATE", "SOFTWARE\\DATARAM"));

                    if (LDate > Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                    {
                        EDPMessage.Show("Plese Correct the system date.");
                        string TTN = Convert.ToString(edpcom.GetFromRegisrty("EC_TRANS", "SOFTWARE\\DATARAM"));
                        ProductKey PK = new ProductKey();
                        PK.GetKeyCode(TTN, true);
                        PK.ShowDialog();
                    }
                    edpcom.SetInRegistry(DateTime.Now.ToShortDateString(), "EC_LDATE", "SOFTWARE\\DATARAM");
                    DateTime PDate = Convert.ToDateTime(edpcom.GetFromRegisrty("EC_DATE", "SOFTWARE\\DATARAM"));
                    int NDATE = Convert.ToInt32(edpcom.GetFromRegisrty("EC_NDATE", "SOFTWARE\\DATARAM"));

                    int sd = LDate.Day;
                    int ed = PDate.Day;
                    double tdays = (LDate - PDate).TotalDays;
                    if (NDATE == 0)
                    {
                        ClassActivation CA = new ClassActivation();
                        CA.Chk_Days_Error(true);
                    }
                    else if (tdays >= NDATE)
                    {
                        ClassActivation CA = new ClassActivation();
                        CA.Chk_Days_Error(false);
                    }
                }
                catch { }
            }
            catch { }
        }
        public void PasswordChk()
        {
           
                Edpcom.EDPConnection EDPConn = new EDPConnection();
                Edpcom.EDPCommon edpcom = new EDPCommon();

                Edpcom.EDPConnection edpcon = new EDPConnection();
            try{
                frmAcceptpassword passwd = new frmAcceptpassword("Out"); //User name & Password verify
                passwd.ShowDialog();
                EDPComm = new EDPCommon();  
                
                if (passwd.paccept)
                {
                    CurrUser = EDPComm.PCURRENT_USER;///////// EDPComm.PCURRENT_USER;

                    int Copmany_Count = Convert.ToInt32(edpcom.GetresultS("SELECT COUNT(CO_CODE) FROM Company where GCODE ='1'"));
                    int OL_CoID = Convert.ToInt32(edpcom.GetresultS("SELECT coid FROM Company where GCODE ='1'"));
                    int OL_comp = 0;
                    string EC_COMPANY = "", comp = clsDataAccess.ReturnValue("SELECT CO_NAME FROM Company where GCODE ='1'");
                    if (OL_CoID == 0)
                    {
                        try
                        {
                            OL_CoID = Convert.ToInt32(cnn.SP_Dync_Proc_Val("SELECT isNull(coid,0) FROM tbl_mst_company where LOWER(name)='" + EC_COMPANY.ToLower() + "'").Rows[0][0].ToString());

                        }
                        catch { OL_CoID = -1; }

                        if (OL_CoID < 0)
                        {
                            string comp1 = clsDataAccess.ReturnValue("SELECT CO_Name FROM Company  where GCODE ='1'"),
                           add = clsDataAccess.ReturnValue("SELECT BRNCH_ADD1 FROM Branch where GCODE ='1' and BRNCH_CODE='1'"),
                           contact = clsDataAccess.ReturnValue("SELECT BRNCH_TELE1 FROM Branch where GCODE ='1' and BRNCH_CODE='1'"),
                           email = clsDataAccess.ReturnValue("SELECT BRNCH_EMAIL FROM Branch where GCODE ='1' and BRNCH_CODE='1'").ToLower(),
                           build_dt = edpcom.PBUILD_DATE.ToString("dd/MMM/yyyy");
                           bool bl= cnn.SP_Dync_Proc_Company(comp, add, contact, email, build_dt,1);
                           try
                           {
                               if (bl == true)
                               {

                                   OL_CoID = Convert.ToInt32(cnn.SP_Dync_Proc_Val("SELECT isNull(coid,0) FROM tbl_mst_company where (LOWER(name)='" + comp.ToLower() + "')").Rows[0][0].ToString());
                                   EC_COMPANY = cnn.SP_Dync_Proc_Val("SELECT EC_COMPANY FROM tbl_mst_company where (LOWER(name)='" + comp.ToLower() + "')").Rows[0][0].ToString();
                               }

                               clsDataAccess.RunQry("UPDATE Company SET coid ='" + OL_CoID + "', EC_COMPANY ='" + EC_COMPANY + "'");
                           }
                           catch { }
                        }
                        else if (OL_CoID == 0)
                        {
                            string comp1 = clsDataAccess.ReturnValue("SELECT CO_Name FROM Company  where GCODE ='1'"),
                           add = clsDataAccess.ReturnValue("SELECT BRNCH_ADD1 FROM Branch where GCODE ='1' and BRNCH_CODE='1'"),
                           contact = clsDataAccess.ReturnValue("SELECT BRNCH_TELE1 FROM Branch where GCODE ='1' and BRNCH_CODE='1'"),
                           email = clsDataAccess.ReturnValue("SELECT BRNCH_EMAIL FROM Branch where GCODE ='1' and BRNCH_CODE='1'").ToLower(),
                           build_dt = edpcom.PBUILD_DATE.ToShortDateString();
                            bool bl = cnn.SP_Dync_Proc_bool("update tbl_mst_company set  build_date ='" + build_dt + "', reg =1");
                            try
                            {
                                if (bl == true)
                                {

                                    OL_CoID = Convert.ToInt32(cnn.SP_Dync_Proc_Val("SELECT isNull(coid,0) FROM tbl_mst_company where (LOWER(name)='" + comp.ToLower() + "')").Rows[0][0].ToString());
                                    EC_COMPANY = cnn.SP_Dync_Proc_Val("SELECT EC_COMPANY FROM tbl_mst_company where (LOWER(name)='" + comp.ToLower() + "')").Rows[0][0].ToString();
                                }

                                clsDataAccess.RunQry("UPDATE Company SET coid ='" + OL_CoID + "', EC_COMPANY ='" + EC_COMPANY + "'");
                            }
                            catch { }
                        }

                    }

                    if (Copmany_Count > 1)
                    {
                        common.SLC_COMP = true;
                        frmSelectcomp selc = new frmSelectcomp();
                        selc.ShowDialog();
                    }
                    else
                    {
                        common.SLC_COMP = true;
                        Select_Company_Count(Convert.ToInt32(edpcom.GetresultS("SELECT CO_CODE FROM Company  where GCODE ='1'")));
                    }


                    edpcom.UpdateWaccLog(this, true);
                    //if (selc.DialogResult == DialogResult.Cancel)
                    bool Passing_Chk = true;
                    if (Passing_Chk)
                    {
                        edpcon.Close();
                        MenuC.Items.Clear();
                        try
                        {
                            //Retrive Current SuperUser and UserGroupCode
                            edpcom.CurrentSuperuser = EDPComm.GetresultS("select superUser from usercontrol where  USER_CODE = '" + edpcom.PCURRENT_USER + "'").Trim();
                            edpcom.CurrentUGcode = EDPComm.GetresultS("select ugcode from usercontrol where USER_CODE = '" + edpcom.PCURRENT_USER + "'").Trim();
                            //End 03.04.14

                            //Retrive Location Permition from current user
                            edpcom.CurrentLocation = "";
                            if (edpcom.PCURRENT_USER == "1")
                            {
                                DataTable dt_company = edpcom.GetDatatable("SELECT Location_ID FROM tbl_Emp_Location ");
                                for (int i = 0; i <= dt_company.Rows.Count - 1; i++)
                                {
                                    edpcom.CurrentLocation = edpcom.CurrentLocation + Convert.ToString(dt_company.Rows[i]["Location_ID"]);
                                    if (i < dt_company.Rows.Count - 1)
                                        edpcom.CurrentLocation = edpcom.CurrentLocation + ",";
                                }
                                
                            }
                            else
                            {
                                DataTable dt_company = edpcom.GetDatatable("SELECT LOC_CODE FROM AccessLocation WHERE USER_CODE=" + edpcom.PCURRENT_USER + " and LOC_CODE !=0 ");
                                for (int i = 0; i <= dt_company.Rows.Count - 1; i++)
                                {
                                    edpcom.CurrentLocation = edpcom.CurrentLocation + Convert.ToString(dt_company.Rows[i]["LOC_CODE"]);
                                    if (i < dt_company.Rows.Count - 1)
                                        edpcom.CurrentLocation = edpcom.CurrentLocation + ",";
                                }
                            }
                            // End 18.11.15
                        }
                        catch { }
                        edpcon.Close();
                        common.ClearDataTable(ds.Tables["GetSap"]);
                        edpcon.Open();
                        mycmd = new SqlCommand("select THOU_SEP,DEC_SEP from currency where ficode='" + EDPComm.CurrentFicode + "' and gcode='" + EDPComm.PCURRENT_GCODE + "' and DFLT_FLG=" + 1 + "", edpcon.mycon);
                        da.SelectCommand = mycmd;
                        bool bull = Convert.ToBoolean(da.Fill(ds, "GetSap"));
                        edpcon.Close();
                        if (bull)
                        {
                            EDPComm.GetThousand_Sep = ds.Tables["GetSap"].Rows[0][0].ToString();
                            if (Information.IsNumeric(ds.Tables["GetSap"].Rows[0][1]) == true)
                                EDPComm.GetDecimal_Place = Convert.ToInt32(ds.Tables["GetSap"].Rows[0][1]);
                            else
                                EDPComm.GetDecimal_Place = 2;
                        }
                        else
                        {
                            EDPComm.GetThousand_Sep = ",";
                            EDPComm.GetDecimal_Place = 2;
                        }

                        Configuration_Menu_TypeDoc_companySetting();

                        string ficode = edpcom.CurrentFicode.Trim();
                        string gcode = edpcom.PCURRENT_GCODE.Trim();
                        string UL = EDPComm.CurrentUserLev;

                        //Following two lines has been changed by dwipraj dutta 20092017
                        string str_Type = "";
                        str_Type = typeOfEnvironment;
                        
                        try
                        {
                            lblsess.Text = "Session : " + EDPComm.CURRENTSESSION;
                           lblcom_name.Text = " User: " + EDPComm.UserDesc + " Type:" + str_Type;


                           lblbr_name.Text = " Branch Name: " + EDPComm.CURRENT_COMPANY + " (F:" + ficode + " G:" + gcode + ") ";


                           
                            txtEXEVersion.Text = " Build Date: " + edpcom.PBUILD_DATE.ToShortDateString();
                        }
                        catch { }
                       
                        try
                        {

                            if (UL == "Superuser")//Superuser
                            {
                                string x = Convert.ToString(edpcom.readFromIni(Application.StartupPath + "\\Settings.edp", "Envelope", "FLAG"));
                                if (x != edpcom.EnvironMent_Envelope)
                                {
                                    edpcom.Menu_Update();
                                    edpcom.writeToIni(Application.StartupPath + "\\Settings.edp", "Envelope", "FLAG", edpcom.EnvironMent_Envelope);

                                }
                            }
                            else
                            {
                                edpcon.Open();
                                //if (EDPComm.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno = '3.10.4'") == "TRUE")
                                if (edpcom.EnvironMent_Envelope == "Brand Purchase")
                                {
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20010302000  and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20010303000  and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20010305000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20010306000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20010500000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20010600000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20020301000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20020303000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20020400000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20020500000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20030000000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=20040000000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='True' where MENUCODE=20010302000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='True' where MENUCODE=20020301000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='True' where MENUCODE=20020400000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='True' where MENUCODE=20020500000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='True' where MENUCODE=20030000000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='True' where MENUCODE=20040000000 and USER_CODE ='" + EDPComm.PCURRENT_USER + "' AND GCODE ='" + EDPComm.PCURRENT_GCODE + "'", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                }
                                if (edpcom.EnvironMent_Envelope != "Petrol")
                                {
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='False' where MENUCODE=50230000000 ", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    mycmd = new SqlCommand("update MenuUser set ENABLE_MENU='True' where MENUCODE=50230000000 ", edpcon.mycon);
                                    mycmd.ExecuteNonQuery();
                                }
                                edpcon.Close();

                                ///21.08.14
                                string x = Convert.ToString(edpcom.readFromIni(Application.StartupPath + "\\Settings.edp", "Envelope", "FLAG"));
                                if (x != edpcom.EnvironMent_Envelope)
                                {
                                    edpcom.Menu_Update();
                                    edpcom.writeToIni(Application.StartupPath + "\\Settings.edp", "Envelope", "FLAG", edpcom.EnvironMent_Envelope);

                                }
                            }

                            ///End 21.08.14
                        }
                        catch { edpcon.Close(); }

                        Configuration_Menu_TypeDoc_Settings_For_Menue();

                        MenuC = Menu_Gen(UL, common.ConSrting);

                        //-------------17-10-08 for ToolsBar------------//
                        if (tlstrp.Items.Count > 0)
                        {
                            tlstrp.Font = new Font("Tahoma", 10, FontStyle.Bold);
                            this.Controls.Add(tlstrp);
                        }
                        //-----------------------------------------------//
                        MenuC.Font = new Font("Tahoma", 10, FontStyle.Regular);
                        MainMenuStrip = MenuC;
                        this.Controls.Add(MenuC);
                    }
                }
                else
                {
                    //////////EDPMessage.Show("Time out. Application Terminated!", "Message!", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_OK);
                    Environment.Exit(0);
                }
                                                                   }
         
              
            
            catch { }
       
           
        }
        public void Configuration_Menu_TypeDoc_companySetting()
        {
            try
            {
            
                Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                
               
                string filePath = "";
                filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
                string line;
                if (File.Exists(filePath))
                {
                    StreamReader file = null;
                    try
                    {
                        
                        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
                        edpcon.Close();
                        file = new StreamReader(filePath);
                        if (file.ReadLine() != null)
                        {
                            int chk_str = 0;
                            while ((line = file.ReadLine()) != null)
                            {
                                string[] StrSTAR = line.Trim().Split('*');
                                if (StrSTAR.Length == 2)
                                {
                                    if (StrSTAR[0].Trim() == "")
                                        continue;
                                }

                                string[] StrLine = line.Trim().Split('[');
                                if (StrLine.Length == 2)
                                {
                                    string str = line.Substring(1, line.Length - 2);
                                    if (str == "Environment_Envelope")
                                        chk_str = 1;
                                    else if (str == "Environment_Menu")
                                        chk_str = 2;
                                    else if (str == "Environment_Bit")
                                        chk_str = 3;
                                }

                                string[] StrLine_WACC = line.Trim().Split(';');

                                if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                                {
                                    //if (StrLine_WACC[0].ToUpper() == "PETROL")
                                    //    edpcom.EnvironMent_Envelope = "Petrol";
                                    //else if (StrLine_WACC[0].ToUpper() == "PRINTING")
                                    //    edpcom.EnvironMent_Envelope = "PRINTING";
                                    //else if (StrLine_WACC[0].ToUpper() == "BRANDPURCHASE")
                                    //    edpcom.EnvironMent_Envelope = "Brand Purchase";
                                    //else if (StrLine_WACC[0].ToUpper() == "BRANDSALES")
                                    //    edpcom.EnvironMent_Envelope = "Brand Sales";
                                    //else if (StrLine_WACC[0].ToUpper() == "SCHOOL")
                                    //    edpcom.EnvironMent_Envelope = "School";
                                    //else
                                    //    edpcom.EnvironMent_Envelope = "";

                                    if (StrLine_WACC[0].ToUpper() == "LITE")
                                    {
                                        edpcom.EnvironMent_Envelope = "Lite";
                                        typeOfEnvironment = StrLine_WACC[0].ToUpper();
                                    }
                                    else if (StrLine_WACC[0].ToUpper() == "MEDIUM")
                                    {
                                        edpcom.EnvironMent_Envelope = "Medium";
                                        typeOfEnvironment = StrLine_WACC[0].ToUpper();
                                    }
                                    else if (StrLine_WACC[0].ToUpper() == "DEMO")
                                    {
                                        edpcom.EnvironMent_Envelope = "Demo";
                                        typeOfEnvironment = StrLine_WACC[0].ToUpper();
                                    }
                                    else if (StrLine_WACC[0].ToUpper() == "ENTERPRISE")
                                    {
                                        edpcom.EnvironMent_Envelope = "Enterprise";
                                        typeOfEnvironment = StrLine_WACC[0].ToUpper();
                                    }
                                    else
                                    {
                                        edpcom.EnvironMent_Envelope = "";
                                        typeOfEnvironment = "";
                                    }
                                    chk_str = 0;
                                    


                                    edpcom.Menu_Update();

                                }
                                if ((chk_str == 2) && (StrLine_WACC.Length > 1))
                                {
                                    if (StrLine_WACC[0].ToUpper() == "NEW")
                                        edpcom.EnvironMent_Menu = "NewMenu";
                                    else
                                        edpcom.EnvironMent_Menu = "OldMenu";
                                    chk_str = 0;
                                }
                                if ((chk_str == 3) && (StrLine_WACC.Length > 1))
                                {
                                    if (StrLine_WACC[0].ToUpper() == "64")
                                        edpcom.EnvironMent_Bittype = "64";
                                    else
                                        edpcom.EnvironMent_Bittype = "32";
                                    chk_str = 0;
                                }
                            }
                        }
                    }
                    catch { }
                }

                
            }
            catch { }
           
        }
        private void Configuration_Menu_TypeDoc_Settings_For_Menue()
        {
            try
            {
                string filePath = "";
                filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
                string line;
                if (File.Exists(filePath))
                {
                    StreamReader file = null;
                    try
                    {
                        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
                        edpcon.Close();
                        file = new StreamReader(filePath);
                        if (file.ReadLine() != null)
                        {
                            int chk_str = 0;
                            while ((line = file.ReadLine()) != null)
                            {
                                string[] StrSTAR = line.Trim().Split('*');
                                if (StrSTAR.Length == 2)
                                {
                                    if (StrSTAR[0].Trim() == "")
                                        continue;
                                }

                                string[] StrLine = line.Trim().Split('[');
                                if (StrLine.Length == 2)
                                {
                                    string str = line.Substring(1, line.Length - 2);
                                    if (str == "WACCOPTION")
                                        chk_str = 1;
                                    else if (str == "MENU")
                                        chk_str = 2;
                                    else if (str == "TypeDoc_Config")
                                        chk_str = 3;
                                }

                                string[] StrLine_WACC = line.Trim().Split(';');

                                if ((chk_str == 1) && (StrLine_WACC.Length > 2))
                                {
                                    edpcon.Open();
                                    string Series_Code = "", Bool_Value = "", Str_Val = "";

                                    Series_Code = StrLine_WACC[0];
                                    if (StrLine_WACC[1] == "")
                                        Bool_Value = "FALSE";
                                    else
                                        Bool_Value = StrLine_WACC[1];
                                    Str_Val = StrLine_WACC[2];
                                    try
                                    {
                                        edpcom.RunCommand("UPDATE WACCOPTN SET BOOL_VAL='" + Bool_Value + "',STR_VAL='" + Str_Val + "' WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND SeriesNo='" + Series_Code.Trim() + "'");
                                    }
                                    catch { }
                                    edpcon.Close();
                                }

                                if ((chk_str == 2) && (StrLine_WACC.Length > 2))
                                {
                                    edpcon.Open();
                                    string MENUCODE = "", MENUDESC = "", ENABLE_MENU = "", SHORTCUT_KEY = "", TOOLBARBTN = "";

                                    MENUCODE = StrLine_WACC[0];
                                    MENUDESC = StrLine_WACC[1];
                                    if (StrLine_WACC[2] == "")
                                        ENABLE_MENU = "FALSE";
                                    else
                                        ENABLE_MENU = StrLine_WACC[2];
                                    SHORTCUT_KEY = StrLine_WACC[3];
                                    if (StrLine_WACC[4] == "")
                                        TOOLBARBTN = "FALSE";
                                    else
                                        TOOLBARBTN = StrLine_WACC[4];

                                    try
                                    {
                                        edpcom.RunCommand("UPDATE MenuTable SET MENUDESC='" + MENUDESC + "',ENABLE_MENU='" + ENABLE_MENU + "',SHORTCUT_KEY='" + SHORTCUT_KEY + "',TOOLBARBTN='" + TOOLBARBTN + "' WHERE MENUCODE='" + MENUCODE.Trim() + "'");
                                    }
                                    catch { }
                                    edpcon.Close();
                                }

                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }

        }
        //public void value()
        //{
        //    aa = "10000000000";
        //}

        public void MenuClick(Object sender, EventArgs e)
        {
            if (aa == "20020301030")
                lb_Shortcut.Visible = false;

            EDPComm = new EDPCommon();
            common.SLC_COMP = true;
            EDPComm.FirstTimeInstall = false;
            Edpcom.EDPConnection edpcon = new EDPConnection();
            common.mcode = sender.ToString();
            //aa = "";
            ToolStripMenuItem mm1 = new ToolStripMenuItem();
            mm1 = (System.Windows.Forms.ToolStripMenuItem)common.arr[common.mcode];
            if (mm1 != null)
                aa = mm1.Name.ToString();

            clsGeneralShow genralshow = new clsGeneralShow();
            if (aa == "10010000000")// 101000000
            {
                frmInstall frmins = new frmInstall();
                frmins.ShowDialog();
            }
            else if (aa == "60150300000")
            {
                common.Flug_Save = false;
                HotKeys hk = new HotKeys();
                hk.ShowDialog();
                if (common.Flug_Save == true)
                    PasswordChk();
            }
            else if (aa == "10020000000")// 102000000
            {
                EDPComm = new EDPCommon();
                //frmSelectcomp fsc = new frmSelectcomp();
                ////common.SLC_COMP = false;
                //fsc.ShowDialog();
                Edpcom.EDPCommon edpcom = new EDPCommon();

                int Copmany_Count = Convert.ToInt32(edpcom.GetresultS("SELECT COUNT(CO_CODE) FROM Company"));
                frmSelectcomp selc = new frmSelectcomp();
                if (Copmany_Count > 1)
                {
                    common.SLC_COMP = true;
                    selc.ShowDialog();
                }
                else
                {
                    common.SLC_COMP = true;
                    Select_Company_Count(Convert.ToInt32(edpcom.GetresultS("SELECT CO_CODE FROM Company")));
                }

                if (selc.DialogResult == DialogResult.Cancel)
                {
                    if (common.SLCOMFLAG1 == 25)
                    {
                        common.SLCOMFLAG1 = 0;
                        return;
                    }
                    else
                    {
                        wait wt = new wait();
                        wt.ShowDialog();
                        tlstrp.Items.Clear();
                        this.Controls.Remove(tlstrp);
                        MenuC.Items.Clear();

                        Configuration_Menu_TypeDoc_companySetting();

                        string str_Type = "Standard";
                        if (EDPComm.EnvironMent_Envelope == "Petrol")
                            str_Type = "Petrol";
                        else if (EDPComm.EnvironMent_Envelope == "PRINTING")
                            str_Type = "Printing Software";
                        else if (EDPComm.EnvironMent_Envelope == "Brand Purchase")
                            str_Type = "Brand Purchase";
                        else if (EDPComm.EnvironMent_Envelope == "Brand Sales")
                            str_Type = "Brand Sales";
                        else if (EDPComm.EnvironMent_Envelope == "School")
                            str_Type = "School";



                        session.Text = "Session: " + EDPComm.CURRENTSESSION;
                        company_name.Text = " User : " + EDPComm.UserDesc + " Type:" + str_Type;
                        //branchname.Text = " Branch Name : " + EDPComm.CURRENT_COMPANY + " (" + EDPComm.CurrentFicode + ")";
                        //comcode.Text = "('" + EDPComm.PCURRENT_GCODE + "')";// EDPComm.getCurrGcode(EDPComm.CurrentFicode) + ")";
                        if (edpcom.CurrentFicode.Trim() == "")
                        {
                            edpcom.CurrentFicode = "1";
                        }
                        string ficode = edpcom.CurrentFicode.Trim();
                        string gcode = edpcom.PCURRENT_GCODE.Trim();
                        branchname.Text = " Branch Name: " + EDPComm.CURRENT_COMPANY + " (F:" + ficode + " G:" + gcode + ") ";
                        //comcode.Text = "( Gcode: " + gcode + ")";// EDPComm.getCurrGcode(EDPComm.CurrentFicode) + ")";


                        //session.Text = "Session : " + EDPComm.CURRENTSESSION;
                        //company_name.Text = "User : " + EDPComm.UserDesc;
                        //branchname.Text = "Branch Name : " + EDPComm.CURRENT_COMPANY + " (" + EDPComm.CurrentFicode + ")";
                        //comcode.Text = "('" + EDPComm.PCURRENT_GCODE + "')";

                        ////comcode.Text = "('" + edpcom.PCURRENT_GCODE + "')"; 
                        ////Edpcom.frmConfigarationVariable CV = new frmConfigarationVariable();
                        ////CV.CollectAssetDetails();

                        Configuration_Menu_TypeDoc_Settings_For_Menue();

                        MenuC = Menu_Gen(EDPComm.CurrentUserLev, common.ConSrting);
                        if (tlstrp.Items.Count > 0)
                        {
                            // tlstrp.BackColor = SystemColors.Control;
                            tlstrp.Font = new Font("Tahoma", 10, FontStyle.Bold);
                            this.Controls.Add(tlstrp);
                        }
                        MenuC.Font = new Font("Tahoma", 10, FontStyle.Regular);
                        MainMenuStrip = MenuC;
                        this.Controls.Add(MenuC);
                        //common.LoadConfigData();
                        int dmo = EDPComm.GetDemoDays;
                        if (dmo == 0)
                            this.Text = "EDP_Payroll   " + "Current Company - " + common.CompanyNameFinancialYear;
                        else
                            this.Text = "EDP_Payroll   " + "Current Company - " + common.CompanyNameFinancialYear + "  (Demo Application For " + dmo + " days )";

                    }

                   

                }
               
            }
            else if (aa == "10080000000")// 110000000
                Application.Exit();
            else if (aa == "10070100000")// 109010000
            {
                frmUserdetails ud = new frmUserdetails();
                ud.MdiParent = this;
                ud.Show();
            }
            else if (aa == "30020101010") // 202040000
            {
                //Opening pr = new Opening();
                //if (EDPComm.CheckMdiChild(pr, this))
                //    return;
                //pr.MdiParent = this;
                //pr.Show();
            }
            else if (aa == "50200000000")// 109010000
                PasswordChk();
            //frmMain.ActiveForm.Refresh();
            genralshow.listBoxStatus(lb_Shortcut);
            genralshow.GeneralShow(aa, this);

        }

        private string GetSpace(string Menue)
        {
            string str_space = "";
            try
            {
                int str_count = Menue.Length;
                for (int i = 0; i <= 22 - Menue.Length; i++)
                {
                    str_space = str_space + " ";
                }
            }
            catch { }
            return str_space;
        }
        public MenuStrip Menu_Gen(string user_name, string conn)
        {
            try
            {
                //lb_Shortcut.Visible = true;
                lb_Shortcut.Items.Clear();
                lb_Shortcut.Top = 50;
                //////////lb_Shortcut.Height = this.Height - this.statusBar1.Height - 75;
                lb_Shortcut.Left = this.Width - 275;
                lb_Shortcut.Width = 275;
                tlstrp.Items.Clear();
                int change = 0;
                common.SLCOMFLAG = 23;
                common.arr.Clear();
                //con = new SqlConnection(conn);
                common.ClearDataTable(ds.Tables["aa"]);
                //con.Open();

                
                Edpcom.EDPConnection EDPConn = new EDPConnection();
                //EDPConn.SvrName=".";
                //EDPConn.DatabaseName = "EDP_Payroll";
                
                EDPConn.Open();


                if (user_name == "Superuser") //"Superuser"
                    com = new SqlCommand("select * from MENUTABLE WHERE ENABLE_MENU='1'", EDPConn.mycon);//
                else
                    com = new SqlCommand("SELECT MenuUser.MENUCODE, MENUTABLE.PARENTCODE, MENUTABLE.MENUDESC, MENUTABLE.DETAILDESC, MenuUser.ENABLE_MENU,MENUTABLE.FORMCODE, MENUTABLE.SHORTCUT_KEY,MENUTABLE.TOOLBARBTN FROM MenuUser INNER JOIN MENUTABLE ON MenuUser.MENUCODE = MENUTABLE.MENUCODE WHERE (MenuUser.USER_CODE ='" + EDPComm.PCURRENT_USER + "') AND (MenuUser.GCODE =(select MAX(GCODE) from  MenuUser where USER_CODE='" + EDPComm.PCURRENT_USER + "'))", EDPConn.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "aa");
                EDPConn.Close();

                
                int i = 0;
                int j = 0;
                string code;
                string des;
                string perent;
                string sor;
                string bu;

                i = ds.Tables["aa"].Rows.Count - 1;
                while (j <= i)
                {
                    code = (string)ds.Tables["aa"].Rows[j][0];
                    des = (string)ds.Tables["aa"].Rows[j][2];
                    perent = (string)ds.Tables["aa"].Rows[j][1];

                    if (code == "30020000000")
                    {
                        String a = "";
                    }
                    bu = ds.Tables["aa"].Rows[j][4].ToString();
                    TOOLBARBTN = (bool)ds.Tables["aa"].Rows[j][7];
                   
                    if (Information.IsDBNull(ds.Tables["aa"].Rows[j][6]) == false)
                    {
                        sor = (string)ds.Tables["aa"].Rows[j][6];
                        if (sor.Trim() != "")
                        {
                            try
                            {
                                string str_space = GetSpace(des);
                                string Short = des + str_space + sor;
                                lb_Shortcut.Items.Add(Short);
                            }
                            catch
                            { }
                        }
                    }
                    else
                        sor = "";

                    Boolean checkparent = true;
                    Boolean cheSubMenu = true;

                    if (perent == "0" && checkparent == true)
                    {
                        ToolStripMenuItem mm = new ToolStripMenuItem();
                        mm.Name = des;
                        mm.Text = des;
                        mms.Items.Add(mm);
                        if (bu == false.ToString())
                        {
                            mm.Visible = false;
                            mm.Enabled = false;
                        }
                        common.arr.Add(des, mm);
                    }
                    else if (cheSubMenu)
                    {
                        EDPConn.Open();
                        string strdb1 = "MENU_GENERATE";
                        //com = new SqlCommand("select * from " + "MENUTABLE" + " where menucode=\'" + perent + "\'", EDPConn.mycon);
                        com = new SqlCommand(strdb1, EDPConn.mycon);
                        com.CommandType = CommandType.StoredProcedure;
                        SqlParameter MENU_PARENT1 = new SqlParameter("@PARENT", perent);
                        com.Parameters.Add(MENU_PARENT1);
                        da.SelectCommand = com;
                        da.Fill(ds, "aa1");
                        EDPConn.Close();
                        string co;
                        string per;
                        string de;
                        co = (string)ds.Tables["aa1"].Rows[0][0];
                        de = (string)ds.Tables["aa1"].Rows[0][2];
                        per = (string)ds.Tables["aa1"].Rows[0][1];
                        ds.Tables["aa1"].Clear();
                        if (long.Parse(per) == 0)
                        {
                            ToolStripMenuItem mm = new ToolStripMenuItem();
                            mm = (System.Windows.Forms.ToolStripMenuItem)common.arr[de];
                            ToolStripMenuItem dd;
                            Bitmap BMP = Resources.chkbox;
                            //-------------17-10-08 for ToolsBar------------//
                            Image IMG = Resources.go2;
                            //----------------------------------------------//
                            if (sor == "")
                            {
                                dd = new ToolStripMenuItem(des, BMP, new System.EventHandler((this.MenuClick)), code);
                                //-------------17-10-08 for ToolsBar------------//
                                if (TOOLBARBTN)
                                {
                                    tlstrp.Items.Add(des, IMG, new System.EventHandler(this.MenuClick));
                                    tlstrp.Items.Add(new ToolStripSeparator());
                                }
                                //----------------------------------------------//
                            }
                            else
                            {
                                dd = new ToolStripMenuItem(des, BMP, new System.EventHandler((this.MenuClick)), code);
                                //-------------17-10-08 for ToolsBar------------//
                                if (TOOLBARBTN)
                                {
                                    tlstrp.Items.Add(des, IMG, new System.EventHandler(this.MenuClick));
                                    tlstrp.Items.Add(new ToolStripSeparator());
                                }
                                int a, b, c, d, e;
                                ArrayList arrlis = new ArrayList();
                                arrlis = MEG.Index(sor);
                                a = arrlis.Count - 1;
                                switch (a)
                                {
                                    case 0: b = (int)arrlis[0];
                                        dd.ShortcutKeys = (System.Windows.Forms.Keys)b;
                                        dd.ShowShortcutKeys = true;
                                        break;
                                    case 1: b = (int)arrlis[0];
                                        c = (int)arrlis[1];
                                        dd.ShortcutKeys = (System.Windows.Forms.Keys)b + c;
                                        dd.ShowShortcutKeys = true;
                                        break;
                                    case 2: b = (int)arrlis[0];
                                        c = (int)arrlis[1];
                                        d = (int)arrlis[2];
                                        dd.ShortcutKeys = (System.Windows.Forms.Keys)b + c + d;
                                        dd.ShowShortcutKeys = true;
                                        break;
                                    case 3: b = (int)arrlis[0];
                                        c = (int)arrlis[1];
                                        d = (int)arrlis[2];
                                        e = (int)arrlis[3];
                                        dd.ShortcutKeys = (System.Windows.Forms.Keys)b + c + d + e;
                                        dd.ShowShortcutKeys = true;
                                        break;
                                }
                            }
                            mm.DropDownItems.Add(dd);
                            if (bu == false.ToString())
                            {
                                dd.Visible = false;
                                dd.Enabled = false;
                            }
                            common.arr.Add(des, dd);
                        }
                        else
                        {
                            ToolStripMenuItem mm = new ToolStripMenuItem();
                            mm = (System.Windows.Forms.ToolStripMenuItem)common.arr[de];
                            ToolStripMenuItem dd;
                            Bitmap BMP = null;
                            Image IMG = Resources.go2;
                            if (change == 0)
                            {
                                //////////BMP = Resources.RightArrow2HS;
                                change = 1;
                            }
                            else if (change == 1)
                            {
                                ////////////BMP = Resources.RightArrowHS;
                                change = 0;
                            }
                            if (sor == "")
                            {
                                dd = new ToolStripMenuItem(des, BMP, new System.EventHandler((this.MenuClick)), code);
                                //-------------17-10-08 for ToolsBar------------//
                                if (TOOLBARBTN)
                                {
                                    tlstrp.Items.Add(des, IMG, new System.EventHandler(this.MenuClick));
                                    tlstrp.Items.Add(new ToolStripSeparator());
                                }
                                //---------------------------------------------//
                            }
                            else
                            {
                                dd = new ToolStripMenuItem(des, BMP, new System.EventHandler((this.MenuClick)), code);
                                //-------------17-10-08 for ToolsBar------------//
                                if (TOOLBARBTN)
                                {
                                    tlstrp.Items.Add(des, IMG, new System.EventHandler(this.MenuClick));
                                    tlstrp.Items.Add(new ToolStripSeparator());
                                }
                                //---------------------------------------------//
                                int a, b = 0, c = 0, d = 0, e = 0;
                                ArrayList arrlis = new ArrayList();
                                arrlis = MEG.Index(sor);
                                a = arrlis.Count - 1;
                                switch (a)
                                {
                                    case 0: b = (int)arrlis[0];
                                        dd.ShortcutKeys = (System.Windows.Forms.Keys)b;
                                        dd.ShowShortcutKeys = true;
                                        break;
                                    case 1: b = (int)arrlis[0];
                                        c = (int)arrlis[1];
                                        dd.ShortcutKeys = (System.Windows.Forms.Keys)b + c;
                                        dd.ShowShortcutKeys = true;
                                        break;
                                    case 2: b = (int)arrlis[0];
                                        c = (int)arrlis[1];
                                        d = (int)arrlis[2];
                                        dd.ShortcutKeys = (System.Windows.Forms.Keys)b + c + d;
                                        dd.ShowShortcutKeys = true;
                                        break;
                                    case 3: b = (int)arrlis[0];
                                        c = (int)arrlis[1];
                                        d = (int)arrlis[2];
                                        e = (int)arrlis[3];
                                        dd.ShortcutKeys = (System.Windows.Forms.Keys)b + c + d + e;
                                        dd.ShowShortcutKeys = true;
                                        break;
                                }
                            }
                            try
                            {
                                mm.DropDownItems.Add(dd);
                                if (bu == false.ToString())
                                {
                                    dd.Visible = false;
                                    dd.Enabled = false;
                                }
                                common.arr.Add(des, dd);
                            }
                            catch { }
                        }
                    }
                    j++;
                }
                return mms;
            }
            catch
            { return mms; }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Form_Exit == false)
            {
                //AutoBackUp();
                if (!chk_Control)
                    EDPComm.Autobackup();
                if (!EDPComm.RestoreMode)
                {
                    if (EDPComm.GetMsg)
                    {
                        //DialogResult dr = (MessageBox.Show("Quit AccordFour! (" + EDPComm.PEXE_VERSION.Trim() + ")", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information));
                        EDPMessage.Show("Quit Payroll Software Management Software! (" + EDPComm.PEXE_VERSION.Trim() + ")", "Confirm", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
                        //if (dr == DialogResult.Yes)
                        //{
                        if (EDPMessage.ButtonResult == "edpYES")
                        {
                            ntyMid.Dispose();
                            //EDPComm.UpdateAccordFourLog(this,false);
                            //Below line has been commented for a test purpose and above line has been added
                            EDPComm.UpdateWaccLog(this, false);
                            Environment.Exit(0);
                            
                        }
                        else e.Cancel = true;
                    }
                    else
                    {
                        ntyMid.Dispose();
                        if (EDPComm.FirstTimeInstall == false)
                            Environment.Exit(0);
                    }
                }
            }
            else
            {
                e.Cancel = true;
                Form_Exit = false;
            }
            Form_Exit = false;
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            Form_Exit = false;
            chk_Control = false;
            if (e.Control)
            {
                chk_Control = true;
            }

            else
            {
                chk_Control = false;
            }
            if (e.KeyCode == Keys.F6)
            {
                if (grp_shortcut.Visible == true)
                {
                    grp_shortcut.Visible = false;
                }
                else
                {
                    grp_shortcut.Visible = true;
                }

            }
        }

        private void cmuMid_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            string q = Convert.ToString(e.KeyChar);
            if (e.KeyChar == (char)Keys.Escape)
                textBox1.Text = "";
            else
                textBox1.Text = textBox1.Text + q;
            if (textBox1.Text == "ghost")
            {
                //ERPMessageBox.ERPMessage.Show("Welcome to Devoloper's Option.");
                frmDevolopersAccess fda = new frmDevolopersAccess();
                fda.MdiParent = this;
                fda.Show();
            }
            else if (textBox1.Text == "delete")
            {
                //ERPMessageBox.ERPMessage.Show("Welcome to Devoloper's Option.");
                frmDeleteModule dm = new frmDeleteModule();
                dm.MdiParent = this;
                dm.Show();
            }
            else if (textBox1.Text.ToLower() == "acct")
            {
               string str = "AC000100";
               Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
               string TTN = Convert.ToString(edpcom.GetFromRegisrty("EC_TRANS", "SOFTWARE\\DATARAM"));
             
                    ProductKey PK = new ProductKey();
                    //PK.GetKeyCode(str);
                    PK.GetKeyCode(TTN, true);
                    PK.ShowDialog();
                  

            }



            
        }

        // partha

        //added by dwipraj dutta 100820170352PM
        private void MenuAccessGenerationOrUpdate()
        {
            bool status = false;
            DataTable MenuAccessList;
            string qryGetInsertValidity = "select MENUCODE,MENUDESC from MenuTable where MENUCODE not in (select MENUCODE from MenuAccessList) and ENABLE_MENU = 1";
            string qryGetDeleteValidity = "select mal.MENUCODE from MenuAccessList mal,MenuTable mt where mt.MENUCODE = mal.MENUCODE and mt.ENABLE_MENU = '0'";
            MenuAccessList = clsDataAccess.RunQDTbl(qryGetInsertValidity);
            for (int i = 0; i < MenuAccessList.Rows.Count; i++)
            {
                status = clsDataAccess.RunNQwithStatus("insert into MenuAccessList (MENUCODE,MENUDESC) values ('" + MenuAccessList.Rows[i]["MENUCODE"] + "','" + MenuAccessList.Rows[i]["MENUDESC"] + "')");
            }

            MenuAccessList.Clear();
            MenuAccessList = clsDataAccess.RunQDTbl(qryGetDeleteValidity);
            for (int i = 0; i < MenuAccessList.Rows.Count; i++)
            {
                status = clsDataAccess.RunNQwithStatus("delete from MenuAccessList where MENUCODE = '" + MenuAccessList.Rows[i]["MENUCODE"] + "'");
            }
            MenuAccessList.Clear();
        }
        //added by bibhas - 15/03/2018
        private void Menu_Authority()  // compare betweeen MenuUser and MenuTable - any menu code missing in MenuUser will be updated
        {
          string qry=  "INSERT INTO MenuUser(USER_CODE, GCODE, MENUCODE, ENABLE_MENU, TOOLBARBTN)" + Environment.NewLine +
"select u.USER_CODE,u.GCODE, p.MENUCODE,1,0" + Environment.NewLine +
"from (select * from MenuTable where MENUCODE not in (select MENUCODE from MenuUser) and ENABLE_MENU='true')as p" + Environment.NewLine +
"Join (select distinct user_code,GCODE from MenuUser) u on 1=1";

         // bool bl = clsDataAccess.RunQry(qry);


          cnt_lv = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select lv from CompanyLimiter")));
          if (cnt_lv == 0)
          {
              clsDataAccess.RunQry(" Update MenuTable set Enable_Menu='False' where (MenuCode='20020090000')" + Environment.NewLine +
                  "Update MenuTable set Enable_Menu='False' where (MenuCode='40030000002')");

          }


          empsal = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select empsal from CompanyLimiter")));
          if (empsal == 0)
          {
              clsDataAccess.RunQry(" Update MenuTable set Enable_Menu='False' where (MenuCode='40020000002')");

          }

        }


    }
}