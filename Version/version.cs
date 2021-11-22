using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using System.Data.SqlClient;
using System.Data.Sql;
using FirstTimeNeed;
using Version.Properties;

namespace Version
{
    public partial class version : Form
    {
        Edpcom.EDPConnection edpcon = new EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        SqlDataAdapter SQLDA = new SqlDataAdapter();
        clsMenuEntry menu = new clsMenuEntry();
        clsfirsttime first = new clsfirsttime();
        public DateTime CBuildDate, PBuildDate;
        public bool Versionflg;
        public version()
        {
            edpcom.PBUILD_DATE = Convert.ToDateTime(Resources.Build_Date);
            InitializeComponent();
        }

        public void ChkVersion(SqlConnection CON, DateTime Pbuild_date, DateTime Cbuild_date)// EACH ANOTHER MODULE NEED A CONNECTION FROM MAIN_FORM
        {
            CBuildDate = Cbuild_date; PBuildDate = Pbuild_date;
            if (edpcom.FirstTimeInstall)
            {
                lblVersion.Text = "Application Updating for the First Time Installation And creating database on " + Application.StartupPath;
                lblPath.Text = "Creating DataBase";
                prbVersion.Increment(prbVersion.Value + 1);
                if (first.firsttimeData(CON)) lblPath.Text = "Database created succesfully";
                else lblPath.Text = " Cannot create Database";
                lblPath.Text = "Creating Method";
                prbVersion.Increment(prbVersion.Value + 1);
                if (first.firstimemethod(CON)) lblPath.Text = "Methods created succesfully";
                else lblPath.Text = "Cannot create Methods";
                prbVersion.Increment(prbVersion.Value + 1);
                lblVersion.Text = "Application Successfully Updated It'sself";
                lblPath.Text = "Thank You for using Midas Gold";
                lblVersion.Text = "Application Terminated auotomatically";
                prbVersion.Value = prbVersion.Maximum;
                Versionflg = true;
                menu.EnterIntomenu(CON, CBuildDate, PBuildDate);
                //  UpdtDBInfo(CON);
                Versionflg = true;
            }
            if (PBuildDate < CBuildDate)
            {
                MessageBox.Show("You are running an old Version.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Versionflg = false;
                return;
            }
            else
            {
                //if (Cbuild_date<Convert.ToDateTime("the next build date'"))
                //call the procedure
                if (Cbuild_date < Convert.ToDateTime("16/10/08"))
                    currency_alter(CON);
                if (Cbuild_date < Convert.ToDateTime("18/10/08"))
                {
                    TrnsType_alter(CON);
                    TypeMast_Updt(CON);
                }
                if (Cbuild_date < Convert.ToDateTime("27/10/08"))
                {

                    TypeMast_Updt(CON);
                }
                if (Cbuild_date < Convert.ToDateTime("28/10/08"))
                {

                    MenuUser_alter(CON);
                }
                if (Cbuild_date < Convert.ToDateTime("3/11/08"))
                {

                    RowIndx_alter(CON);
                    alloc_table_creation(CON);
                    TriggerAdjustPLtran_creation(CON);
                    Comment_alter(CON);
                }
                if (Cbuild_date < Convert.ToDateTime("15/11/08"))
                {

                    //   Asset_Class(CON);
                    //string strdbprc = "InvMst_ins";
                    //SqlCommand cmd = new SqlCommand(strdbprc, CON);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //SqlParameter FICODE = new SqlParameter("@pFICode", edpcom.CurrentFicode);

                    //cmd.Parameters.Add(FICODE);
                    //try
                    //{
                    //    cmd.ExecuteNonQuery();
                    //}
                    //catch { }
                    T_ENTRY_Entry(CON);
                    string strdbprc = "TypeMast_ins";
                    SqlCommand cmd = new SqlCommand(strdbprc, CON);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter FICODE = new SqlParameter("@pFICode", edpcom.CurrentFicode);
                    SqlParameter GCODE = new SqlParameter("@pGcode", edpcom.PCURRENT_GCODE);
                    cmd.Parameters.Add(FICODE);
                    cmd.Parameters.Add(GCODE);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch { }

                }
                if (Cbuild_date < Convert.ToDateTime("30/12/09"))
                {
                    string strmfmst = "CREATE TABLE [ShortSaleInfo]([FICode] [char](10) NOT NULL,[GCODE] [char](10) NOT NULL,[T_ENTRY] [char](2) NOT NULL," +
                              "[VOUCHER] [numeric](18, 0) NOT NULL,[AUTOINCRE] [numeric](18, 0) IDENTITY(1,1) NOT NULL,[PCODE] [numeric](18, 0) NULL," +
                              "[AgainstVoucher] [varchar](100) NULL,[AgainstVoucherDate] [datetime] NULL,[AgainstQty] [decimal](18, 0) NULL,[AgainstRate] [float] NULL," +
                              "[AgainstTentry] [char](2) NULL,[AgainstVoucherCode] [numeric](18, 0) NULL,[AgainstAutoIncre] [numeric](18, 0) NULL," +
                              "[AgainstRowIndex] [numeric](18, 0) NULL,[AgainstItemNo] [numeric](18, 0) NULL,[BalQty] [decimal](18, 0) NULL,[RowIndex] [numeric](18, 0) NULL,[Itemno] [numeric](18, 0) NULL,PRIMARY KEY CLUSTERED ([FICode] ASC,[GCODE] ASC,[T_ENTRY] ASC,[VOUCHER] ASC,[AUTOINCRE] ASC))";
                    try
                    {
                        edpcom.RunCommand(strmfmst, CON);
                    }
                    catch { }

                    strmfmst = "ALTER TABLE  ShortSaleInfo ADD ShortSale bit Null";
                    try
                    {
                        edpcom.RunCommand(strmfmst, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("05/01/10"))
                {
                    string strmfmst = "ALTER TABLE  etran ADD DPStatus char(1) Null";
                    try
                    {
                        edpcom.RunCommand(strmfmst, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("08/01/10"))
                {
                    UpdtDBForNominee(CON);
                    AlterProcCopyBrker(CON);
                }


                if (Cbuild_date < Convert.ToDateTime("09/01/10"))
                    IGLMST_alter(CON);
                if (Cbuild_date < Convert.ToDateTime("14/01/10"))
                    UpdateFrmMst(CON);
                if (Cbuild_date < Convert.ToDateTime("18/01/10"))
                {
                    string str = "ALTER TABLE FixedDepositeMaster ADD DepositPaybleTo varchar(25) null";
                    try
                    {
                        edpcom.RunCommand(str, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("19/01/10"))
                {
                    DividendTablecreation(CON);
                    AlterProcTypeMast(CON);
                    VchLockUpdate(CON);
                    FDIntUpdate(CON);
                }
                if (Cbuild_date < Convert.ToDateTime("22/01/10"))
                {
                    TriggerAdjustPLtran_creation(CON);
                    string str = "ALTER TABLE FDinfo ADD BasisofCal varchar(50) NULL,FDState varchar(50) NULL DEFAULT ('R')";
                    try
                    {
                        edpcom.RunCommand(str, CON);
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('30020206030','30020206000','FD Redemption','FD Redemption',1,' ',' ',0)");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('30020203030','30020203000','Sale For Equity Unlisted','Equity Unlisted',1,' ',' ',0)");
                    }
                    catch { }

                    try
                    {
                        str = "ALTER TABLE FixedDepositeMaster ADD DepositPaybleTo varchar(25) null";
                        edpcom.RunCommand(str, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("27/01/10"))
                {
                    createvchlocktable(CON);
                }
                if (Cbuild_date < Convert.ToDateTime("29/01/10"))
                {
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('30020202010','30020202000','Purchase For Equity Listed','Market Purchase',1,' ','F9',0)");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('30020202020','30020202000','Purchase For Equity Un-Listed','Market Purchase',1,' ',' ',0)");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand(" update menutable set SHORTCUT_KEY='' where menucode='30020202000'");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("30/01/10"))
                {
                    try
                    {
                        edpcom.RunCommand(" ALTER TABLE idata ADD assetcode numeric(18, 0) null");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("03/02/10"))
                {
                    UpdateMethods.ItranTriggerUpdate();
                    UpdateMethods.AdjustEtranUpdate();
                }
                if (Cbuild_date < Convert.ToDateTime("04/02/10"))
                    UpdateMethods.Mid_DELETE_COMPANYUpdate();

                if (Cbuild_date < Convert.ToDateTime("09/02/10"))
                    UpdateMethods.AddIDocTran_Nominee();
                if (Cbuild_date < Convert.ToDateTime("17/02/10"))
                {
                    UpdateMethods.CnfgmstUpdate();
                    UpdateMethods.TrigCompOnglmstInsUpdate();
                    UpdateForComodity();
                }
                if (Cbuild_date < Convert.ToDateTime("19/02/10"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE  COMMDITY_INFO ADD ShortSale bit Null", CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("22/02/10"))
                {
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('30020201020','30020200000','Opening Entry (Bulk)','Opening Entry (Bulk)',1,' ',' ',0)");
                    }
                    catch { }
                    UpdateMethods.TrigCompOnInsUpdate();
                }

                if (Cbuild_date < Convert.ToDateTime("13/03/10"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE  invmst ADD T_entryIn varchar(max) Null, T_entryOut varchar(max) Null", CON);
                    }
                    catch { }
                    UpdateMethods.InvMst_insUpdate();
                    AssetPropFld();
                }

                if (Cbuild_date < Convert.ToDateTime("16/03/10"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE  pltran ADD balqty float Null");
                        UpdateMenu();
                        UpdateMethods.TrigCompOnglmstInsUpdate();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("22/03/10"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE  iglmst alter column face_value money null");
                        edpcom.RunCommand("ALTER TABLE  iglmst alter column BUS_TYPE varchar(50) null");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("30/03/10"))
                {
                    try
                    {
                        string pk = edpcom.GetresultS(" select name from sys.objects where type='PK' and parent_object_id=(select id from sysobjects where xtype='U' and  name='inarr')");
                        edpcom.RunCommand("alter table inarr drop " + pk);
                        edpcom.RunCommand("alter TABLE inarr ADD CONSTRAINT PK_inarr primary KEY (ficode,GCODE,T_entry,voucher,autoincre) ");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("31/03/10"))
                {
                    UpdateMethods.InvMst_insUpdate();
                    UpdateMethods.Copy_BrksUpdate();
                    UpdateMethods.Copy_AccUpdate();
                }
                if (Cbuild_date < Convert.ToDateTime("03/04/10"))
                {
                    UpdateMethods.FICODEGENDELUpdate();
                }
                if (Cbuild_date < Convert.ToDateTime("12/05/10"))
                {
                    UpdateMethods.InvMst_insUpdate();
                    UpdateMethods.Typemas_InsUpdate();
                }
                if (Cbuild_date < Convert.ToDateTime("17/05/10"))
                {
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('30020214000','30020200000','Derivatives','Derivatives Entry',1,' ',' ',0)");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('30020214010','30020214000','Futures','Derivatives Entry',1,' ',' ',0)");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('30020214020','30020214000','Options','Derivatives Entry',1,' ',' ',0)");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE  iglmst add upcode numeric null");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("20/05/10"))
                    UpdateMethods.ItranTriggerUpdate();
                if (Cbuild_date < Convert.ToDateTime("24/05/10"))
                    UpdateMethods.AdjustEtranUpdate();
                if (Cbuild_date < Convert.ToDateTime("27/05/10"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE iglmst add OType char(1) null");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE iglmst add OStyle char(1) null");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE itran add ModeOfTran char(1) null");
                    }
                    catch { }
                    UpdateMethods.UpdtGrpForLedgTrig();
                }
                if (Cbuild_date < Convert.ToDateTime("28/05/10"))
                {
                    UpdateMethods.Typemas_InsUpdate();
                    UpdateMethods.AdjustEtranUpdate();
                }
                if (Cbuild_date < Convert.ToDateTime("31/05/10"))
                {
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('40020700000','40020000000','Stock Query DP Wise','Stock Query DP Wise',1,' ',' ',0)");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("02/06/10"))
                {
                    UpdateMethods.InvMst_insUpdate();
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('30020215000','30020200000','Cash','Cash Details',1,' ',' ',0)");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand("CREATE TABLE [cashDet]([Ficode] [char](10) NOT NULL,[Gcode] [char](10) NOT NULL,[Glcode] [numeric](18, 0) NOT NULL,[ACNo] [varchar](50) NULL,[Type] [varchar](10) NULL,[NomineeApp] [bit] NULL,[NCode] [numeric](18, 0) NULL,[CurrCode] [numeric](18, 0) NULL,[ACName] [varchar](100)  NULL,CONSTRAINT [PK_cashDet] PRIMARY KEY CLUSTERED ([Ficode] ASC,[Gcode] ASC,[Glcode] ASC))");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("08/06/10"))
                {
                    string sqlstr = "ALTER TABLE INSURANCEMST ADD Opening_Unit numeric(18, 0) Null,Closing_Unit numeric(18, 0) Null";
                    try
                    {
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('70100000000','70000000000','Change Color Scheme','Change Color Scheme',1,' ',' ',0)");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand("CREATE TABLE [CSTOCK]([SDate] [datetime] NOT NULL,[FICode] [varchar](20) NOT NULL,[GCODE] [varchar](20)  NOT NULL,[MGROUP] [int] NOT NULL,[SGROUP] [int] NOT NULL,[GLCODE] [numeric](18, 0) NOT NULL,[OPAMT] [numeric](18, 3) NULL,[CLAMT] [numeric](18, 3) NULL,[NCONV_FCTR] [float] NULL,[DCONV_FCTR] [float] NULL,[FC_OPAMT] [numeric](18, 3) NULL,[FC_CLAMT] [numeric](18, 3) NULL,[CURR_CODE] [varchar](6) NULL,CONSTRAINT [PK_CSTOCK] PRIMARY KEY CLUSTERED ([SDate] ASC,[FICode] ASC,[GCODE] ASC,[MGROUP] ASC,[SGROUP] ASC,[GLCODE] ASC))");
                    }
                    catch { }
                    UpdateMethods.AdjustEtranUpdate();
                }
                if (Cbuild_date < Convert.ToDateTime("10/06/10"))
                {
                    AddUpdateINFLT();
                }
                if (Cbuild_date < Convert.ToDateTime("12/06/10"))
                {
                    string sqlstr = "ALTER TABLE Formula_Master ADD DPCode numeric(18, 0) Null,Exchng_Code numeric(18, 0) Null";
                    try
                    {
                        edpcom.RunCommand(sqlstr, CON);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("14/06/10"))
                {
                    UpdateMethods.Typemas_InsUpdate();
                    UpdateMethods.ItranTriggerUpdate();
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('30020216000','30020200000','Bonus Entry','Bonus Entry',1,' ',' ',0)");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand("CREATE TABLE [BonusEntry]([Ficode] [char](10) NOT NULL,[Gcode] [char](10) NOT NULL,[User_Vch] [varchar](max) NULL,[Voucher] [numeric](18, 0) NOT NULL,[T_entry] [char](2) NOT NULL,[Vch_Date] [datetime] NOT NULL,[AutoIncNo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,[Pcode] [numeric](18, 0) NULL,[DPcode] [numeric](18, 0) NULL,[Declare_Date] [datetime] NULL,[Applicable_Date] [datetime] NULL,[Total_Qty] [decimal](18, 0) NULL,[Declare_Qty] [decimal](18, 0) NULL,[BonusRatio] [varchar](50) NULL,[ValOpt] [char](1) NULL,[OrgPrice] [money] NULL,[BQty] [decimal](18, 0) NULL,[Remqty] [decimal](18, 0) NULL,[MktPrice] [money] NULL,[Amount] [money] NULL,[Link_voucher] [numeric](18, 0) NULL,[Link_tentry] [char](2) NULL,[Desccode] [numeric](18, 0) NULL,CONSTRAINT [PK_BonusEntry] PRIMARY KEY CLUSTERED ([Ficode] ASC,[Gcode] ASC,[Voucher] ASC,[T_entry] ASC,[Vch_Date] ASC,[AutoIncNo] ASC)) ");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("15/06/10"))
                {
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('40020800000','40020000000','MIS','MIS',1,' ',' ',0)");
                        edpcom.RunCommand(" Insert into menutable values('40020801000','40020800000','Return At-A-Glance(EQ Listed)','Return At-A-Glance(EQ Listed)',1,' ',' ',0)");
                    }
                    catch { }
                    try
                    {
                        string sqlstr = "ALTER TABLE AddLess ADD Formula varchar(Max) Null";
                        edpcom.RunCommand(sqlstr);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("17/06/10"))
                {

                    string SqlStr = "ALTER TABLE Branch ADD [Comp_Type] [varchar](50) NULL CONSTRAINT [DF_Branch_Comp_Type]  DEFAULT ('-')";
                    try
                    {
                        edpcom.RunCommand(SqlStr);
                    }
                    catch { }
                    UpdateMethods.Typemas_InsUpdate();
                    UpdateMethods.Typemas_InsUpdate();
                    UpdateMethods.ItranTriggerUpdate();
                    UpdateMethods.AdjustEtranUpdate();
                    AlterCompanyTrigger();
                    try
                    {
                        edpcom.RunCommand(" Insert into menutable values('30020217000','30020200000','Bullion Entry','Bullion Entry',1,' ',' ',0)");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("19/06/10"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40020802000','40020800000','FD MSI Report','FD MSI Report',1,' ',' ','0')");
                    }
                    catch { }
                    try
                    {
                        UpdateMethods.AlterCompanyTriggerForLedger();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("25/06/10"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40020900000','40020000000','Portfolio Analysis','Portfolio Analysis',1,' ',' ','0')");

                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40020901000','40020900000','Equity','Equity',1,' ',' ','0')");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("29/06/10"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40020803000','40020800000','Mutual Fund At-A-Glance','Mutual Fund At-A-Glance',1,' ',' ','0')");


                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand("UPDATE MenuTable SET MENUDESC='FD MIS Report' WHERE MENUCODE='40020802000' AND PARENTCODE='40020800000'");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("03/07/10"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40030000000','40000000000','Maintainance','Maintainance',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40030100000','40030000000','Accounts','Accounts',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40030101000','40030100000','Main Groups','Main Groups',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40030102000','40030100000','Sub Groups','Sub Groups',1,' ',' ','0')");
                    }
                    catch { }

                }
                if (Cbuild_date < Convert.ToDateTime("06/07/10"))
                {
                    try
                    {
                        string sqlstr = "ALTER TABLE Iglmst ADD Proftrad_ac int Null,Losstrad_ac int Null";
                        sqlstr = sqlstr + " ALTER TABLE invmst ADD Proftrad_ac int Null,Losstrad_ac int Null";
                        edpcom.RunCommand(sqlstr);
                    }
                    catch { }
                    UpdateMethods.AdjustEtranUpdate();
                }
                if (Cbuild_date < Convert.ToDateTime("08/07/10"))
                {
                    InvUpdate(CON);
                    //UpdateMethods.InvMst_insUpdate();
                    UpdateMethods.TrigCompOnglmstInsUpdate();
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('30020209010','30020209000','Mutual Fund Entry','Mutual Fund',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('30020209020','30020209000','Mutual Fund Dividend Entry','Mutual Fund',1,' ',' ','0')");
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("13/07/10"))
                {
                    AlterFDInfo();
                }

                if (Cbuild_date < Convert.ToDateTime("15/07/10"))
                {
                    try
                    {
                        //edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU," +
                        //    "FORMCODE,SHORTCUT_KEY,TOOLBARBTN)VALUES('80050000000','80000000000'," +
                        //    " 'Closing Stock Transfer','Closing Stock Transfer','True','' ,'','True')");

                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('80050000000','80000000000','Inter-Fin.Yr.Transfer','Inter-Fin.Yr.Transfer',1,' ',' ','0')");

                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('80050100000','80050000000','Inter-Fin Yr. A/C Bal.Transfer','Inter-Fin Yr. A/C Bal.Transfer',1,' ',' ','0')");

                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('80050200000','80050000000','Inter-Fin Yr. Stock Bal.Transfer','Inter-Fin Yr. Stock Bal.Transfer',1,' ',' ','0')");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("16/07/10"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40030200000','40030000000','Instruments','Instruments',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40030201000','40030200000','Asset Class','Asset Class',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40030202000','40030200000','Classification','Classification',1,' ',' ','0')");
                    }
                    catch { }
                }


                if (Cbuild_date < Convert.ToDateTime("19/07/10"))
                {
                    try
                    {
                        string SqlStr = "CREATE TABLE [dbo].[AssetClassImportStat](" + Environment.NewLine +
                            "[FiCode] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," + Environment.NewLine +
                            "[GCode] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," + Environment.NewLine +
                            "[Voucher] [numeric](18, 0) NOT NULL," + Environment.NewLine +
                            "[AUTOINCRE] [numeric](18, 0) NOT NULL," + Environment.NewLine +
                            "[PCODE] [numeric](18, 0) NOT NULL," + Environment.NewLine +
                            "[ImportDate] [datetime] NULL," + Environment.NewLine +
                            "[ImportUser] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," + Environment.NewLine +
                             "CONSTRAINT [PK_AssetClassImportStat] PRIMARY KEY CLUSTERED " + Environment.NewLine +
                            "(" + Environment.NewLine +
                            "[FiCode] ASC," + Environment.NewLine +
                            "[GCode] ASC," + Environment.NewLine +
                            "[Voucher] ASC," + Environment.NewLine +
                            "[AUTOINCRE] ASC," + Environment.NewLine +
                            "[PCODE] ASC" + Environment.NewLine +
                            ")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]" + Environment.NewLine +
                            ") ON [PRIMARY]";
                        edpcom.RunCommand(SqlStr);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("20/07/10"))
                {
                    UpdateMethods.Typemas_InsUpdate();
                    //UpdateMethods.AlterCompanyTriggerForLedger();
                    try
                    {
                        edpcom.RunCommand("alter table bonusentry alter column remqty float null");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand("alter table iglmst alter column curstk numeric(18, 5) null");
                    }
                    catch { }
                    try { edpcom.RunCommand("update menutable set shortcut_key='F11' where menucode='20010100000'"); edpcom.RunCommand("update menutable set shortcut_key=' ' where menucode='30020203010'"); }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("26/07/10"))
                {
                    try
                    {
                        edpcom.RunCommand("ALTER TABLE itran ADD diffamt money Null");
                    }
                    catch { }
                    UpdateMethods.UpdtGrpForLedgTrig();
                    glmstRectification(CON);
                }
                if (Cbuild_date < Convert.ToDateTime("28/07/10"))
                {
                    try
                    {

                        //UpdateMethods.AlterCompanyTriggerForLedger();
                        
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("29/07/10"))
                {
                    try
                    {
                        UpdateMethods.Typemas_InsUpdate();//AlterProcTypeMast(CON);
                    }
                    catch{ }
                }
                
                if (Cbuild_date < Convert.ToDateTime("18/08/10"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table InvMst ADD [rs_Div] [int] NULL,[rs_Deb] [int] NULL,[rs_Bonus] [int] NULL,[rs_Interest] [int] NULL,[rs_Rent] [int] NULL");
                    }
                    catch { }
                }
                
                if (Cbuild_date < Convert.ToDateTime("09/09/10"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table currency ADD [Curr_Type] [varchar](10) NULL");
                        //edpcom.RunCommand("UPDATE currency SET [Curr_Type]='R' WHERE Curr_Type IS NULL");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("22/09/10"))
                {                    
                    try
                    {                                                                                                                               
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('40020804000','40020800000','Asset Wise Unrealized Gain','Asset Wise Unrealized Gain',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('40021000000','40020000000','Mutual Fund Transaction(Q)','Mutual Fund Transaction',1,' ',' ','0')");                        
                    }
                    catch { }
                }                
                if (Cbuild_date < Convert.ToDateTime("05/10/10"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table iglmst add Fund_Code numeric(18, 0) null");
                    }
                    catch { }
                    try
                    {
                        edpcom.RunCommand("update TypeMast set T_Entry='I' where T_Entry='8I'");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("08/09/10"))
                {
                    string strmfmst = "CREATE TABLE [ExngProduct]([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,[PCode] [numeric](18, 0) NOT NULL,[Exchng_Code] [numeric](18, 0) NOT NULL,[ExngSymbol] [varchar](50) NULL,[Active] [varchar](10) NULL)";
                    try
                    {
                        edpcom.RunCommand(strmfmst);
                    }
                    catch { }
                    //try
                    //{
                    //    UpdateMethods.Typemas_InsUpdate();
                    //}
                    //catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("13/10/10"))
                {
                    try
                    {
                        UpdateMethods.AlterCompanyTriggerForLedger();
                        UpdateMethods.Typemas_InsUpdate();
                        UpdateMethods.InvMst_insUpdate();
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("28/10/10"))
                {
                    try
                    {
                        UpdateMethods.ItranTriggerUpdate();
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('30020218000','30020200000','Public Provident Fund','PPF',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('30020218010','30020218000','PPF Subscription','PPFSubscription',1,' ',' ','0')");
                        //edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('30020218020','30020218000','PPF Intrest Payment','PPFIntPayment',1,' ',' ','0')");
                        string strmfmst = "CREATE TABLE [PPFMASTER]([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,[T_Entry] [char](2) NOT NULL,[PCode] [numeric](18, 0) NOT NULL,[Voucher] [numeric](18, 0) NOT NULL,[AUTO_INCR] numeric IDENTITY(1,1) not null,[PPFNO] [varchar](50) NOT NULL,[PPF_OPEN_AT] [varchar](50) NULL,[Amt_paid] [money] NULL,[Int_Rate] [money] NULL,[Lock_Period] [numeric](18, 0) NULL,[Lock_Time] [varchar](20) NULL,[Vch_Date] [datetime] NOT NULL,[Start_Date] [datetime] NULL,[Mature_Date] [datetime] NULL,[Remarks] [varchar](150) NULL,[Nominee_ID] [int] NULL,[Status] [varchar](30) NULL,[Action] [varchar] (30) NULL,[PPFNo_Status] [varchar] (30) NULL)";
                        edpcom.RunCommand(strmfmst);                        
                    }
                    catch { }
                } 
                if (Cbuild_date < Convert.ToDateTime("30/10/10"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('30020207040','30020207000','Insurance Surrender','Insurance Surrender',1,' ',' ','0')");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("02/11/10"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table InsRiskProfile add POLICY_NO Varchar (50) null");
                        edpcom.RunCommand("alter table itran add InstallNo [numeric] (18, 0) NULL");
                        edpcom.RunCommand("alter table etran add InstallNo [numeric] (18, 0) NULL");
                        edpcom.RunCommand("alter table InsRiskProfile add InstallNo [numeric] (18, 0) NULL");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("10/11/10"))
                {
                    try
                    {                        
                        edpcom.RunCommand("alter table INSURANCECHLD add MaturityAmt money NULL,SurrenderAmt money NULL,TDSAmt money NULL,NetAmt money NULL,FinalMD [datetime] NULL");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("08/12/10"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('90020000000','90000000000','Global Stock for FD','Global Stock for FD',1,' ',' ','0')");                        
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("09/12/10"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('40021100000','40020000000','Comparative Stock Query(Q)','Comparative Stock Query',1,' ',' ',0)");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("11/12/10"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table FDInfo add MaturityAmt [numeric] (18, 0) NULL");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("12/12/10"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('20100000000','20000000000','Symbol Entry Master','Symbol Entry Master',1,' ',' ',0)");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("24/12/10"))
                {
                    try
                    {                        
                        edpcom.RunCommand("alter table Etran add UnitType [numeric] (18, 0) NULL");
                        edpcom.RunCommand("alter table PLtran add UnitType [numeric] (18, 0) NULL");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("09/01/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table INSURANCEMST alter column Closing_Unit numeric(18, 4) null");
                        edpcom.RunCommand("alter table INSURANCECHLD add PremiumDepositedCumulated [numeric] (18, 2) NULL");

                        edpcom.RunCommand(" Insert into menutable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) values('20110000000','20000000000','Configuration Type','Configuration Type',1,' ',' ',0)");
                        edpcom.RunCommand(" Insert into menutable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) values('20110100000','20110000000','Category Configuration','Category Configuration',1,' ',' ',0)");
                        edpcom.RunCommand(" Insert into menutable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) values('20110200000','20110000000','Linking Category Configuration','Linking Category Configuration',1,' ',' ',0)");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("14/01/11"))
                {
                    string strmfmst = "CREATE TABLE [Vmast]([VCODE] [numeric](18, 0) NOT NULL,[VDESC] [varchar](50)  NOT NULL,[VTYPE] [numeric](18, 0) ,[PLV_CODE] [numeric](18, 0) ,[V_LEVEL] [numeric](18, 0) ,[M_LEVEL] [numeric](18, 0),[V_CAT] [numeric](18, 0) )";
                    string strmfmst1 = "CREATE TABLE [Vcmp]([VCODE] [numeric](18, 0) NOT NULL,[GCODE] [char](10)  NOT NULL,[VTYPE] [numeric](18, 0) ,[FICODE] [char](10) )";
                    try
                    {
                        edpcom.RunCommand(strmfmst);
                        edpcom.RunCommand(strmfmst1);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("20/01/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('40021200000','40020000000','Short Term Capital Gain (Trading)','Short Term Capital Gain (Trading)',1,' ',' ',0)");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('40021300000','40020000000','Long Term Capital Gain (Trading)','Long Term Capital Gain (Trading)',1,' ',' ',0)");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("24/01/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table INSURANCEMST add PremiumDepositedCumulated [numeric] (18, 2) NULL");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("11/02/11"))
                {
                    try
                    {
                        string sqlstr = "ALTER TABLE Iglmst ADD rs_div int Null";                        
                        edpcom.RunCommand(sqlstr);
                    }
                    catch { }                    
                }
                if (Cbuild_date < Convert.ToDateTime("16/02/11"))
                {
                    try
                    {                        
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('30020219000','30020200000','Immovable Properties','IMVPROP',1,' ',' ','0')");                        
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('30020219010','30020219000','Properties Purchase','PROPPUR',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('30020219020','30020219000','Properties Sale','PROPSALE',1,' ',' ','0')");

                        string strmfmst = "CREATE TABLE [ImmovableMaster]([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,[T_Entry] [char](2) NOT NULL,[Voucher] [numeric](18, 0) NOT NULL,[USER_VCH] [varchar](50) NOT NULL,[AUTO_INCR] numeric IDENTITY(1,1) not null,[PCODE] [numeric](18, 0),[VCH_DATE] [datetime] NULL,[PUR_DATE] [datetime] NULL,[SELL_DATE] [datetime] NULL,[DESC_CODE] [numeric](18, 0),[VENDOR_NAME] [varchar](100) NULL,[PUR_AMT] [money] NULL,[BROKER_NAME] [varchar](120) NULL,[PER_OF_BROKER] [numeric](18, 0) NULL,[BRKAMT] [money] NULL,[OTHEREXPANCE] [money] NULL,[TOTAL_AMT] [money] NULL,[FLAG] char(1) NULL,[REF_T_Entry] [char](2) NULL,[REF_Voucher] [numeric](18, 0) NULL,[REF_USER_VCH] [varchar](50) NULL)";
                        edpcom.RunCommand(strmfmst);
                        string strmfmst1 = "CREATE TABLE [ImmovableHoldingDetails]([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,[T_Entry] [char](2) NOT NULL,[Voucher] [numeric](18, 0) NOT NULL,[AUTO_INCR] numeric IDENTITY(1,1) not null,[HOLDING_TYPE] [varchar](100) NULL,[HOLDER_NAME] [varchar](100) NULL,[PER_OF_HOLDING] [numeric](18, 0) NULL,[NOMINEE_NAME] [numeric](18, 0) NULL,[PER_OF_NOMINEE] [numeric](18, 0) NULL,[FLAG] char(1) NULL)";
                        edpcom.RunCommand(strmfmst1);

                        string strmfmst2 = "CREATE TABLE [ImmovableAssetDetails]([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,[T_Entry] [char](2) NOT NULL,[Voucher] [numeric](18, 0) NOT NULL,[AUTO_INCR] numeric IDENTITY(1,1) not null,[REGNO] [varchar](50) NULL)";
                        edpcom.RunCommand(strmfmst2);
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("24/02/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('30020219030','30020219000','Properties Purchase Opening','PROPPUROPEN',1,' ',' ','0')");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("08/03/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('50020600000','50020000000','Share Dividend Received','ShareDividendReceived',1,' ',' ','0')");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("22/03/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('50020700000','50020000000','Opening for Equity','OpeningforEquity',1,' ',' ','0')");
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("28/03/11"))
                {
                    try
                    {
                        string strmfmst = "CREATE TABLE [PortFolioMaster]([Ficode] [char](10) NOT NULL,[PFCODE] [numeric](18, 0) NOT NULL,[PortFolio_ID] [varchar](50) NOT NULL,[PortFolio_Name] [varchar](80) NOT NULL,[PortFolio_Add] [varchar](120) NULL,[PortFolio_PH] [varchar](50) NULL,[PortFolio_Flag] char(1) NULL)";
                        edpcom.RunCommand(strmfmst);
                        edpcom.RunCommand("alter table data add PFCode [numeric] (18, 0) NULL");
                        edpcom.RunCommand("alter table itran add PFCode [numeric] (18, 0) NULL");
                        edpcom.RunCommand("alter table Divident_Schedlr add PFCode [numeric] (18, 0) NULL");
                        edpcom.RunCommand("alter table etran add PFCode [numeric] (18, 0) NULL");
                        edpcom.RunCommand("alter table pltran add PFCode [numeric] (18, 0) NULL");
                        edpcom.RunCommand("alter table vchr add PFCode [numeric] (18, 0) NULL");
                        edpcom.RunCommand(" Insert into menutable (MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) values('20120000000','20000000000','Portfolio Master','PortfolioMaster',1,' ',' ',0)");

                        strmfmst = "CREATE TABLE [AssetCategoryMaster]([AC_ID] [varchar](30) NOT NULL,[AC_Name] [varchar](80) NOT NULL,[AC_Changable_Name] [varchar](80) NULL,[AC_Flag] bit NULL,[Effective_Date] [datetime] NULL ,PRIMARY KEY CLUSTERED ([AC_ID] ASC))";
                        edpcom.RunCommand(strmfmst);
                        edpcom.RunCommand("INSERT INTO AssetCategoryMaster(AC_ID,AC_NAME,AC_Changable_Name,AC_Flag) values('AC01','Equities','Equities','1')");
                        edpcom.RunCommand("INSERT INTO AssetCategoryMaster(AC_ID,AC_NAME,AC_Changable_Name,AC_Flag) values('AC02','Fixed Income','Fixed Income','1')");
                        edpcom.RunCommand("INSERT INTO AssetCategoryMaster(AC_ID,AC_NAME,AC_Changable_Name,AC_Flag) values('AC03','Cash & Cash Equivalent','Cash & Cash Equivalent','1')");
                        edpcom.RunCommand("INSERT INTO AssetCategoryMaster(AC_ID,AC_NAME,AC_Changable_Name,AC_Flag) values('AC04','Gold','Gold','1')");
                        edpcom.RunCommand("INSERT INTO AssetCategoryMaster(AC_ID,AC_NAME,AC_Changable_Name,AC_Flag) values('AC05','Real Estate','Real Estate','1')");
                        edpcom.RunCommand("INSERT INTO AssetCategoryMaster(AC_ID,AC_NAME,AC_Changable_Name,AC_Flag) values('AC06','Others','Others','1')");
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("29/03/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40030300000','40030000000','Portfolio','Portfolio',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40030301000','40030300000','Portfolio Asset Category','PortfolioAssetCategory',1,' ',' ','0')");

                        

                        //edpcom.RunCommand("INSERT INTO AssetCategoryRelationMaster(Ficode,Gcode,AC_ID,ICODE,AC_Flag) values('AC01','Equities','Equities','1')");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("31/03/11"))
                {
                    try
                    {
                        string strmfmst = "CREATE TABLE [AssetCategoryRelation]([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,[AC_ID] [varchar](30) NOT NULL,[ICODE] [numeric](18, 0) NOT NULL,[AC_Flag] bit NULL,[StartDate] [datetime] NULL)";
                        edpcom.RunCommand(strmfmst);

                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('40030302000','40030300000','Portfolio Asset Relation','PortfolioAssetRelation',1,' ',' ','0')");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("05/04/11"))
                {
                    try
                    {                       
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('50030000000','50000000000','Portfolio Reports','PortfolioReports',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('50030100000','50030000000','Asset Under Management','AssetUnderManagement',1,' ',' ','0')");

                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('50020800000','50020000000','DP wise stock','DPwisestock',1,' ',' ','0')");
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("06/04/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table INSURANCECHLD add PFCode [numeric] (18, 0) NULL");
                        edpcom.RunCommand("alter table PPFMASTER add PFCode [numeric] (18, 0) NULL");
                        edpcom.RunCommand("alter table ImmovableMaster add PFCode [numeric] (18, 0) NULL");

                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('80060000000','80000000000','Voucher Statistics','VoucherStatistics',1,' ',' ','0')");
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("08/04/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('50030200000','50030000000','Performance History','PerformanceHistory',1,' ',' ','0')");
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("09/04/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table FDInt add PFCode [numeric] (18, 0) NULL");
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("13/04/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('50020900000','50020000000','DP Summary Report','DPSummaryReport',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('50021000000','50020000000','DP Stock Status Report','DPStockStatus',1,' ',' ','0')");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("16/04/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('50030300000','50030000000','Realized Gain and Loss Summary','RealizedGainandLossSummary',1,' ',' ','0')");
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("18/04/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('50021100000','50020000000','Checklist For FD','ChecklistforFD',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('50021200000','50020000000','Accrued Interest For FD','AccruedInterestForFD',1,' ',' ','0')");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("21/04/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('50021300000','50020000000','FD Performance Report','FDPerformanceReport',1,' ',' ','0')");
                    }
                    catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("10/05/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                           "VALUES('80070000000','80000000000','Sessionwise Report','SessionwiseReport',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                           "VALUES('80080000000','80000000000','Formwise Report','FormwiseReport',1,' ',' ','0')");
                    }
                    catch{ }
                }

                if (Cbuild_date < Convert.ToDateTime("11/05/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table FDInfo add [FIRSTPAYOUT_DATE] [datetime] NULL");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("19/05/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table FDInfo add ROI [numeric] (18, 2) NULL");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("24/05/11"))
                {
                    string strACR = "drop table AssetCategoryRelation CREATE TABLE [AssetCategoryRelation]([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,[AC_ID] [varchar](30) NOT NULL,[ICODE_Classi] [numeric](18, 0) NOT NULL,[ICODE_Asset] [numeric](18, 0) NOT NULL,[PER] [numeric](18, 2) NULL,[AC_Flag] bit NULL,[StartDate] [datetime] NULL)";
                        try
                        {
                            edpcom.RunCommand(strACR);
                        }
                        catch
                        { }                    
                }
                if (Cbuild_date < Convert.ToDateTime("25/05/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('50021400000','50020000000','FD Redemption Report','FDRedemption',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('50021500000','50020000000','FD Interest Received Report','FDInterestReceived',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('50021600000','50020000000','FD Subscription Report','FDSubscription',1,' ',' ','0')");
                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("31/05/11"))
                {
                    try
                    {
                        string strmfmst = "CREATE TABLE [SectorMaster]([Sec_CODE] [numeric](18, 0) NOT NULL,[Sec_NAME] [varchar](80) NOT NULL,[Sec_Flag] bit NULL,[Sec_Date] [datetime] NULL,PRIMARY KEY CLUSTERED ([Sec_CODE] ASC,[Sec_NAME] ASC))";
                        edpcom.RunCommand(strmfmst);
                        edpcom.RunCommand("alter table ExngProduct add [Sec_Code] [numeric] (18, 0) NULL");
                        SectorMasterInsert(CON);
                    }catch { }
                }

                if (Cbuild_date < Convert.ToDateTime("15/06/11"))
                {
                    try
                    {
                        string strmfmst = "drop table AssetCategoryMaster CREATE TABLE [AssetCategoryMaster]([AC_ID] [varchar](30) NOT NULL,[AC_Name] [varchar](80) NOT NULL,[AC_Changable_Name] [varchar](80) NULL,[AC_Flag] bit NULL,[Effective_Date] [datetime] NULL ,PRIMARY KEY CLUSTERED ([AC_ID] ASC))";
                        edpcom.RunCommand(strmfmst);
                        edpcom.RunCommand("INSERT INTO AssetCategoryMaster(AC_ID,AC_NAME,AC_Changable_Name,AC_Flag) values('AC01','Equities','Equities','1')");
                        edpcom.RunCommand("INSERT INTO AssetCategoryMaster(AC_ID,AC_NAME,AC_Changable_Name,AC_Flag) values('AC02','Fixed Income','Fixed Income','1')");
                        edpcom.RunCommand("INSERT INTO AssetCategoryMaster(AC_ID,AC_NAME,AC_Changable_Name,AC_Flag) values('AC03','Cash & Cash Equivalent','Cash & Cash Equivalent','1')");
                        edpcom.RunCommand("INSERT INTO AssetCategoryMaster(AC_ID,AC_NAME,AC_Changable_Name,AC_Flag) values('AC04','Gold','Gold','1')");
                        edpcom.RunCommand("INSERT INTO AssetCategoryMaster(AC_ID,AC_NAME,AC_Changable_Name,AC_Flag) values('AC05','Real Estate','Real Estate','1')");
                        edpcom.RunCommand("INSERT INTO AssetCategoryMaster(AC_ID,AC_NAME,AC_Changable_Name,AC_Flag) values('AC06','Others','Others','1')");

                    }
                    catch { }
                }
                if (Cbuild_date < Convert.ToDateTime("14/07/11"))
                {
                    try
                    {
                        string sqlstr = "ALTER TABLE FixedDepositeMaster ADD GLCODE int Null";
                        edpcom.RunCommand(sqlstr);
                        sqlstr = "ALTER TABLE DPMAST ADD GLCODE int Null";
                        edpcom.RunCommand(sqlstr);
                    }
                    catch { }                  
                }

                if (Cbuild_date < Convert.ToDateTime("29/07/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN) VALUES('50021700000','50020000000','Mutual Fund Report','FDSubscription',1,' ',' ','0')");
                    }
                    catch { }
                }
                if (CBuildDate < Convert.ToDateTime("30/07/11"))
                {                    
                    string sqlstr = "Delete from menutable where menucode='40030000000' and Parentcode='40000000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40030100000' and Parentcode='40030000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40030101000' and Parentcode='40030100000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40030102000' and Parentcode='40030100000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40030200000' and Parentcode='40030000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40030201000' and Parentcode='40030200000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40030202000' and Parentcode='40030200000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40030300000' and Parentcode='40030000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40030301000' and Parentcode='40030300000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40030302000' and Parentcode='40030300000'";
                    edpcom.RunCommand(sqlstr);
                    //new
                    sqlstr = "Delete from menutable where menucode='50020100000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50020200000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50020300000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50020400000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50020500000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50020600000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50020700000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50020800000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50020900000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50021000000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50021100000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50021200000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50021300000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50021400000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    //    sqlstr = "Delete from menutable where menucode='50021500000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50021600000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);

                    //  20120000000	20000000000  20120000000	20000000000
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                           "VALUES('20130000000','20000000000','Maintainance','Maintainance',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('20130100000','20130000000','Accounts','Accounts',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('20130101000','20130100000','Main Groups','Main Groups',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('20130102000','20130100000','Sub Groups','Sub Groups',1,' ',' ','0')");

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                           "VALUES('20130200000','20130000000','Instruments','Instruments',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('20130201000','20130200000','Asset Class','Asset Class',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('20130202000','20130200000','Classification','Classification',1,' ',' ','0')");

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                           "VALUES('20130300000','20130000000','Portfolio','Portfolio',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('20130301000','20130300000','Portfolio Asset Category','PortfolioAssetCategory',1,' ',' ','0')");

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                            "VALUES('20130302000','20130300000','Portfolio Asset Relation','PortfolioAssetRelation',1,' ',' ','0')");
                    //new           
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020100000','50020000000','General Reports','General Reports',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020101000','50020100000','Stock Valuation','Stock Valuation',1,' ',' ','0')");

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020200000','50020000000',' Registers','Registers',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020201000','50020200000','Purchase  Registers','Purchase  Registers',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020202000','50020200000','Sales Registers','Sales Registers',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020203000','50020200000',' Long Term Sales Registers','Long Term Sales Registers',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020204000','50020200000','Short Term Sales Registers','Short Term Sales Registers',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                              "VALUES('50020300000','50020000000','DP Related Reports','DP Related Reports',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020301000','50020300000','DP wise stock','DP wise stock',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020302000','50020300000',' DP Summary Report','DP Summary Report',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020303000','50020300000','DP Stock Status Report','DP Stock Status Report',1,' ',' ','0')");
                    //EQ listed Report Share Dividend Received	ShareDividendReceived
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020400000','50020000000','Eq Listed Report','Eq Listed Report',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020401000','50020400000',' Opening for Equity','OpeningforEquity',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020402000','50020400000','Share Dividend Received','ShareDividendReceived',1,' ',' ','0')");
                    //Mf Report
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020500000','50020000000','MF Reports','MF Reports',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020501000','50020500000','Mutual Fund Transaction Reports','Mutual Fund Transaction Reports',1,' ',' ','0')");

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                             "VALUES('50020600000','50020000000','FD Reports','FDReports',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020601000','50020600000','Checklist For FD','ChecklistforFD',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020602000','50020600000',' Accrued Interest For FD','AccruedInterestForFD',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020603000','50020600000','FD Performance Report','FDPerformanceReport',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020604000','50020600000','FD Redemption Report','FDRedemption',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020605000','50020600000',' FD Interest Received Report','FDInterestReceived',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020606000','50020600000','FD Subscription Report','FDSubscription',1,' ',' ','0')");

                }

                if (CBuildDate < Convert.ToDateTime("03/08/11"))
                {
                    //Subrata
                    //Report
                    string sqlstr = "Delete from menutable where menucode='50021500000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50021700000' and Parentcode='50020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50010100000' and Parentcode='50010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50010200000' and Parentcode='50010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50010300000' and Parentcode='50010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50010400000' and Parentcode='50010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50010800000' and Parentcode='50010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50010500000' and Parentcode='50010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50010600000' and Parentcode='50010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='50010700000' and Parentcode='50010000000'";
                    edpcom.RunCommand(sqlstr);
                    //Query
                    sqlstr = "Delete from menutable where menucode='40010100000' and Parentcode='40010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40010200000' and Parentcode='40010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40010300000' and Parentcode='40010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40010400000' and Parentcode='40010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40010500000' and Parentcode='40010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40010600000' and Parentcode='40010000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40010700000' and Parentcode='40010000000'";
                    edpcom.RunCommand(sqlstr);
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('40010100000','40010000000','Accounts Books(Q) ','AccountsBook(Q) ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40010101000','40010100000','Cash Book(Q)','Cash Book(Q)',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40010102000','40010100000','Bank Book(Q)','Bank Book(Q)',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40010103000','40010100000','Ledger(Q)','Ledger(Q)',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40010104000','40010100000','Journal(Q)','Journal(Q)',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40010200000','40010000000','Final Accounts(Q) ','Final Accounts(Q)',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                     "VALUES('40010201000','40010200000','Trial Balance','Trial Balance  ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40010202000','40010200000','Profit && Loss A/C(Q)','Profit && Loss A/C(Q) ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                      "VALUES('40010203000','40010200000','Balance Sheet(Q)','Balance Sheet(Q) ',1,' ',' ','0')");
                    //Reports                   
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('50010100000','50010000000','Accounts Book ','AccountsBook ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('50010101000','50010100000','Cash Book','Cash Book',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('50010102000','50010100000','Bank Book','Bank Book',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('50010103000','50010100000','Ledger','Ledger',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('50010104000','50010100000','Journal','Journal',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('50010200000','50010000000','A/C Documents ','A/C Documents  ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                      "VALUES('50010201000','50010200000','Voucher','Voucher  ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                       "VALUES('50010300000','50010000000','Final Account ','Final Account',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                      "VALUES('50010301000','50010300000','Trial Balance(R)','Trial Balance(R)  ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                      "VALUES('50010302000','50010300000','Profit && Loss A/C','Profit && Loss A/C ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                      "VALUES('50010303000','50010300000','Balance Sheet','Balance Sheet  ',1,' ',' ','0')");


                    //Query new 

                    edpcom.RunCommand("UPDATE menutable set menudesc='Investment/Trading Query' where menucode='40020000000' and Parentcode='40000000000'");
                    sqlstr = "Delete from menutable where menucode='40020200000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020300000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020100000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40021100000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020400000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020500000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40021200000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40021300000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020803000' and Parentcode='40020800000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40021000000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020900000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020801000' and Parentcode='40020800000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020700000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020804000' and Parentcode='40020800000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020802000' and Parentcode='40020800000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020600000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020800000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020900000' and Parentcode='40020000000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='40020901000' and Parentcode='40020900000'";
                    edpcom.RunCommand(sqlstr);
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                      "VALUES('40020100000','40020000000','Registers','Registers  ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('40020101000','40020100000','Purchase Registers Query ','Purchase Registers Query',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40020102000','40020100000','Sales Registers Query','Sales Registers Query',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                     "VALUES('40020200000','40020000000','Stocks','Stocks  ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('40020201000','40020200000','Stock Query as on Date','Stock Query as on Date',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40020202000','40020200000','Comparative Stock Query at Dates(Q)','Comparative Stock Query at Dates(Q)',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40020203000','40020200000','Stock Query DP Wise','Stock Query DP Wise',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                    "VALUES('40020300000','40020000000','Capital Gain /Loss Query','Capital Gain /Loss Query ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('40020301000','40020300000','Short Term Capital Gain (Invst)','Short Term Capital Gain (Invst)',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40020302000','40020300000','Long Term Capital Gain (Invst)','Long Term Capital Gain (Invst)',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('40020303000','40020300000','Short Term Capital Gain (Trading)','Short Term Capital Gain (Trading)',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40020304000','40020300000','Long Term Capital Gain (Trading)','Long Term Capital Gain (Trading)',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                           "VALUES('40020400000','40020000000','MIS','MIS ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                          "VALUES('40020401000','40020400000','Mutual Fund(Q)','Mutual Fund ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('40020401010','40020401000','Mutual Fund At-A-Glance(Q)','Mutual Fund At-A-Glance',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40020401020','40020401000','Mutual Fund Transaction(Q)','Mutual Fund Transaction',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('40020402000','40020400000','Eq Listed','Eq Listed ',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('40020402010','40020402000','Return At-A-Glance','Return At-A-Glance',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('40020402020','40020402000','Portfolio Analysis-Equity','Portfolio Analysis-Equity',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('40020403000','40020400000','General','General',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('40020403010','40020403000','Asset Wise Unrealized Gain','Asset Wise Unrealized Gain',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('40020404000','40020400000','FD','FD',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('40020404010','40020404000','FD MIS Query','FD MSI Query',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                          "VALUES('40020405000','40020400000','Security Transaction Tax','Security Transaction Tax',1,' ',' ','0')");


                    //   Investment Entry 30020000000	30000000000	Investment Entry

                    //  30020201000	30020200000	Opening
                    sqlstr = "Delete from menutable where menucode='30020100000' and Parentcode='30020000000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020101000' and Parentcode='30020100000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020200000' and Parentcode='30020000000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);

                    sqlstr = "Delete from menutable where menucode='30020201000' and Parentcode='30020200000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020201020' and Parentcode='30020200000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020202000' and Parentcode='30020200000'";//Mk pur
                    edpcom.RunCommand(sqlstr);


                    sqlstr = "Delete from menutable where menucode='30020202010' and Parentcode='30020202000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020202020' and Parentcode='30020202000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020203000' and Parentcode='30020200000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);

                    sqlstr = "Delete from menutable where menucode='30020203010' and Parentcode='30020203000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020203020' and Parentcode='30020203000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020203030' and Parentcode='30020203000'";//Sale For Equity Unlisted
                    edpcom.RunCommand(sqlstr);



                    sqlstr = "Delete from menutable where menucode='30020203030' and Parentcode='30020203000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020204000' and Parentcode='30020200000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020205000' and Parentcode='30020200000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);

                    sqlstr = "Delete from menutable where menucode='30020206000' and Parentcode='30020200000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020206010' and Parentcode='30020206000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020206020' and Parentcode='30020206000'";//Mk pur
                    edpcom.RunCommand(sqlstr);


                    sqlstr = "Delete from menutable where menucode='30020206030' and Parentcode='30020206000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020207000' and Parentcode='30020200000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020207010' and Parentcode='30020207000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);

                    sqlstr = "Delete from menutable where menucode='30020207020' and Parentcode='30020207000'";//OP Bulk Premium Entry
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020207030' and Parentcode='30020207000'";//OP Bulk
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020207040' and Parentcode='30020207000'";//Sale Insurance Surrender
                    edpcom.RunCommand(sqlstr);

                    sqlstr = "Delete from menutable where menucode='30020208000' and Parentcode='30020200000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020209000' and Parentcode='30020200000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020209010' and Parentcode='30020209000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020209020' and Parentcode='30020209000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020210000' and Parentcode='30020200000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020211000' and Parentcode='30020200000'";
                    edpcom.RunCommand(sqlstr);//Investment Expenses
                    sqlstr = "Delete from menutable where menucode='30020212000' and Parentcode='30020200000'";
                    edpcom.RunCommand(sqlstr);//Investment Revenues


                    sqlstr = "Delete from menutable where menucode='30020213000' and Parentcode='30020200000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020213010' and Parentcode='30020213000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020213020' and Parentcode='30020213000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020214000' and Parentcode='30020200000'";
                    edpcom.RunCommand(sqlstr);

                    sqlstr = "Delete from menutable where menucode='30020214010' and Parentcode='30020214000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020214020' and Parentcode='30020214000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020215000' and Parentcode='30020200000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020216000' and Parentcode='30020200000'";
                    edpcom.RunCommand(sqlstr);//Bonus Entry

                    sqlstr = "Delete from menutable where menucode='30020217000' and Parentcode='30020200000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020218000' and Parentcode='30020200000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020218010' and Parentcode='30020218000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020219000' and Parentcode='30020200000'";
                    edpcom.RunCommand(sqlstr);

                    sqlstr = "Delete from menutable where menucode='30020219010' and Parentcode='30020219000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020219020' and Parentcode='30020219000'";
                    edpcom.RunCommand(sqlstr);
                    sqlstr = "Delete from menutable where menucode='30020219030' and Parentcode='30020219000'";
                    edpcom.RunCommand(sqlstr);//Properties Purchase Opening
                   
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                           "VALUES('30020100000','30020000000','Secondary Market','Secondary Market',1,' ',' ','0')");


                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020101000','30020100000','Opening','Opening',1,' ',' ','0')");

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020101010','30020101000','Opening(F8)','Opening(F8)',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('30020101020','30020101000','Opening Entry (BULK)','Opening Entry (BULK)',1,' ',' ','0')");
                    
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020102000','30020100000','Equity Unlisted Entry','Equity Unlisted Entry',1,' ',' ','0')");

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020102010','30020102000','Purchase For Equity Un-Listed','Purchase For Equity Un-Listed',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('30020102020','30020102000','Sale For Equity Un-Listed','Sale For Equity Un-Listed',1,' ',' ','0')");
                                       
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020103000','30020100000','Equity Listed Entry','Equity Listed Entry',1,' ',' ','0')");

                    ////comp 30020204000	30020200000	Composite Entry	Composite Entry
                    
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020103010','30020103000','Composite Entry','Composite Entry',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020103020','30020103000','Short Sales','Short Sales',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020103030','30020103000','Dividend Entry','Dividend Entry',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020103040','30020103000','Bonus Entry','Bonus Entry',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                       "VALUES('30020103050','30020103000','Investment Expenses','Investment Expenses',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                       "VALUES('30020103060','30020103000','Investment Revenues','Investment Revenues',1,' ',' ','0')");

                    //////////////////////SSSSSSSSSSSSSSSSSSSSSSSSSSSS
                    //	Conversion
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                       "VALUES('30020104000','30020100000','Conversion','Conversion',1,' ',' ','0')");
                    //FD
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020105000','30020100000','Fixed Deposit','Fixed Deposit',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020105010','30020105000','Fixed Deposit Subscription','Fixed Deposit Subscription',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020105020','30020105000','FD Interest Collection','FD Interest Collection',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                       "VALUES('30020105030','30020105000','FD Redemption','FD Redemption',1,' ',' ','0')");
                    //insurances
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                       "VALUES('30020106000','30020100000','Insurance','Insurance',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                       "VALUES('30020106010','30020106000','Insurance Entry','Insurance Entry',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020106020','30020106000','Premium Entry ','Premium Entry',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020106030','30020106000','Insurance Charges','Insurance Charges',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                       "VALUES('30020106040','30020106000','Insurance Surrender','Insurance Surrender',1,' ',' ','0')");

                    //     	Commodity Entry

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                      "VALUES('30020107000','30020100000','Commodity Entry','Commodity Entry',1,' ',' ','0')");
                    //MF
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                       "VALUES('30020108000','30020100000','Mutual Fund','Mutual Fund',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020108010','30020108000','Mutual Fund Entry ','Mutual Fund Entry',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020108020','30020108000','Mutual Fund Dividend Entry','Mutual Fund Dividend Entry',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020108030','30020108000','MF at a Glance','MF at a Glance',1,' ',' ','0')");

                    //Diventure Entry

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                       "VALUES('30020109000','30020100000','Debenture Entry','Debenture Entry',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020109010','30020109000','Debenture Purchase ','Debenture Purchase',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020109020','30020109000','Debenture Sale','Debenture Sale',1,' ',' ','0')");

                    //Derivatives
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('30020110000','30020100000','Derivatives','Derivatives',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020110010','30020110000','Futures ','Derivatives Entry',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020110020','30020110000','Options','Derivatives Entry',1,' ',' ','0')");

                    //Cash
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020111000','30020100000','Cash','Cash',1,' ',' ','0')");
                    //   Bullion Entry
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                       "VALUES('30020112000','30020100000',' Bullion Entry',' Bullion Entry',1,' ',' ','0')");

                    //  30020218000	30020200000	Public Provident Fund	PPF

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020113000','30020100000','Public Provident Fund','PPF',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020113010','30020113000','PPF Subscription ','PPF Subscription',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020113020','30020113000','PPF Payment ','PPF Payment',1,' ',' ','0')");
                    //imP
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020114000','30020100000','Immovable Properties','Immovable Properties',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020114010','30020114000','Properties Purchase ','Properties Purchase',1,' ',' ','0')");
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020114020','30020114000','Properties Sale','Properties Sale',1,' ',' ','0')");

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                        "VALUES('30020114030','30020114000','Properties Purchase Opening','Properties Purchase Opening1',1,' ',' ','0')");

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('50020502000','50020500000','MF at a Glance','MF at a Glance',1,' ',' ','0')");
                    
                }
                if (CBuildDate < Convert.ToDateTime("04/08/11"))
                {
                    string sqlstr = "Delete from menutable where menucode='30020108030' and Parentcode='30020108000'";
                    edpcom.RunCommand(sqlstr);
                }

                if (CBuildDate < Convert.ToDateTime("05/08/11"))
                {
                    edpcom.RunCommand("Update MenuTable set SHORTCUT_KEY='F8' where MENUCODE='30020101010' and PARENTCODE='30020101000'");
                    edpcom.RunCommand("Update MenuTable set SHORTCUT_KEY='F3' where MENUCODE='30020103010' and PARENTCODE='30020103000'");
                    edpcom.RunCommand("Update MenuTable set SHORTCUT_KEY='Alt+L' where MENUCODE='40010103000' and PARENTCODE='40010100000'");
                    edpcom.RunCommand("Update MenuTable set SHORTCUT_KEY='Alt+Q' where MENUCODE='40020201000' and PARENTCODE='40020200000'");

                }
                if (CBuildDate < Convert.ToDateTime("06/08/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table Ins_Mkt_Rate add Asset_Type Varchar (20) null");
                    }
                    catch { }
                }
                if (CBuildDate < Convert.ToDateTime("08/08/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table Ins_Mkt_Rate add Expairy [datetime] NULL,Strick_Price numeric(18,2) NULL,Option_Type Varchar (20) null");
                    }
                    catch { }
                }
                if (CBuildDate < Convert.ToDateTime("09/08/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table ExngProduct add SERIES Varchar (50) NULL, Expairy [datetime] NULL,Strick_Price numeric(18,2) NULL,Option_Type Varchar (20) null");
                    }
                    catch { }
                }
                if (CBuildDate < Convert.ToDateTime("13/08/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table Ins_Mkt_Rate alter column PName Varchar (200) NULL");
                        edpcom.RunCommand("alter table Ins_Mkt_Rate alter column OpeningRate numeric(18,4) NULL");
                        edpcom.RunCommand("alter table Ins_Mkt_Rate alter column HighestRate numeric(18,4) NULL");
                        edpcom.RunCommand("alter table Ins_Mkt_Rate alter column LowestRate numeric(18,4) NULL");
                        edpcom.RunCommand("alter table Ins_Mkt_Rate alter column ClosingRate numeric(18,4) NULL");
                        edpcom.RunCommand("alter table Ins_Mkt_Rate alter column LastRate numeric(18,4) NULL");                        
                        edpcom.RunCommand("alter table ExngProduct alter column ExngSymbol Varchar (200) NULL");

                        //edpcom.RunCommand("update invmst set idesc='NCD',orgnidesc='NCD' where ficode='1' and Itype='C'and icode=19 and iparent=3");
                        //edpcom.RunCommand("insert into InvMst ([FICode],[Itype],[Icode],[Idesc],[Iparent],[IAlias],[invs_ac],[ltcg_ac],[ltcl_ac],[stcg_ac],[stcl_ac],[prch_ac],[sls_ac],[stck_ac],[T_entryIn],[T_entryOut],[OrgnIdesc],[Actv_Val])  values('1','C',37,'FMP',6,null,null,null,null,null,null,null,null,null,null,null,'FMP',1)");
                        //edpcom.RunCommand("insert into InvMst ([FICode],[Itype],[Icode],[Idesc],[Iparent],[IAlias],[invs_ac],[ltcg_ac],[ltcl_ac],[stcg_ac],[stcl_ac],[prch_ac],[sls_ac],[stck_ac],[T_entryIn],[T_entryOut],[OrgnIdesc],[Actv_Val])  values('1','C',38,'BllnExch',10,null,null,null,null,null,null,null,null,null,null,null,'BllnExch',1)");
                        //edpcom.RunCommand("alter table iglmst add Yield numeric(18,2) NULL");
                        //edpcom.RunCommand("update invmst set Iparent=28 where icode=34 and Itype='C'");
                        //edpcom.RunCommand("update invmst set Idesc='EQ Stock Fut',orgnidesc='EQ Stock Fut' where Iparent=4 and icode=20 and Itype='C'");
                        //edpcom.RunCommand("update invmst set Idesc='EQ Stock Optn',orgnidesc='EQ Stock Optn' where Iparent=16 and icode=21 and Itype='C'");
                        //edpcom.RunCommand("update invmst set icode=38 where Iparent=10 and Itype='C' and Idesc='BllnExch'");
                        //edpcom.RunCommand("insert into InvMst ([FICode],[Itype],[Icode],[Idesc],[Iparent],[IAlias],[invs_ac],[ltcg_ac],[ltcl_ac],[stcg_ac],[stcl_ac],[prch_ac],[sls_ac],[stck_ac],[T_entryIn],[T_entryOut],[OrgnIdesc],[Actv_Val])  values('1','C',39,'EQ Index Fut',4,null,null,null,null,null,null,null,null,null,null,null,'EQ Index Fut',1)");
                        //edpcom.RunCommand("insert into InvMst ([FICode],[Itype],[Icode],[Idesc],[Iparent],[IAlias],[invs_ac],[ltcg_ac],[ltcl_ac],[stcg_ac],[stcl_ac],[prch_ac],[sls_ac],[stck_ac],[T_entryIn],[T_entryOut],[OrgnIdesc],[Actv_Val])  values('1','C',40,'EQ Index Optn',16,null,null,null,null,null,null,null,null,null,null,null,'EQ Index Optn',1)");

                    }
                    catch { }
                }
                if (CBuildDate < Convert.ToDateTime("16/08/11"))
                {
                    try
                    {                                        
                        SqlDataAdapter adp=new SqlDataAdapter();
                        DataTable dtt=new DataTable();
                        SqlCommand cm = new SqlCommand("Select * from invmst", CON);
                        adp.SelectCommand=cm;
                        adp.Fill(dtt);                        
                        if (dtt.Rows.Count > 0)
                        {
                            edpcom.RunCommand("update invmst set idesc='NCD',orgnidesc='NCD' where ficode='1' and Itype='C'and icode=19 and iparent=3");
                            edpcom.RunCommand("insert into InvMst ([FICode],[Itype],[Icode],[Idesc],[Iparent],[IAlias],[invs_ac],[ltcg_ac],[ltcl_ac],[stcg_ac],[stcl_ac],[prch_ac],[sls_ac],[stck_ac],[T_entryIn],[T_entryOut],[OrgnIdesc],[Actv_Val])  values('1','C',37,'FMP',6,null,null,null,null,null,null,null,null,null,null,null,'FMP',1)");
                            edpcom.RunCommand("insert into InvMst ([FICode],[Itype],[Icode],[Idesc],[Iparent],[IAlias],[invs_ac],[ltcg_ac],[ltcl_ac],[stcg_ac],[stcl_ac],[prch_ac],[sls_ac],[stck_ac],[T_entryIn],[T_entryOut],[OrgnIdesc],[Actv_Val])  values('1','C',38,'BllnExch',10,null,null,null,null,null,null,null,null,null,null,null,'BllnExch',1)");
                            edpcom.RunCommand("alter table iglmst add Yield numeric(18,2) NULL");
                            edpcom.RunCommand("update invmst set Iparent=28 where icode=34 and Itype='C'");
                            edpcom.RunCommand("update invmst set Idesc='EQ Stock Fut',orgnidesc='EQ Stock Fut' where Iparent=4 and icode=20 and Itype='C'");
                            edpcom.RunCommand("update invmst set Idesc='EQ Stock Optn',orgnidesc='EQ Stock Optn' where Iparent=16 and icode=21 and Itype='C'");
                            edpcom.RunCommand("update invmst set icode=38 where Iparent=10 and Itype='C' and Idesc='BllnExch'");
                            edpcom.RunCommand("insert into InvMst ([FICode],[Itype],[Icode],[Idesc],[Iparent],[IAlias],[invs_ac],[ltcg_ac],[ltcl_ac],[stcg_ac],[stcl_ac],[prch_ac],[sls_ac],[stck_ac],[T_entryIn],[T_entryOut],[OrgnIdesc],[Actv_Val])  values('1','C',39,'EQ Index Fut',4,null,null,null,null,null,null,null,null,null,null,null,'EQ Index Fut',1)");
                            edpcom.RunCommand("insert into InvMst ([FICode],[Itype],[Icode],[Idesc],[Iparent],[IAlias],[invs_ac],[ltcg_ac],[ltcl_ac],[stcg_ac],[stcl_ac],[prch_ac],[sls_ac],[stck_ac],[T_entryIn],[T_entryOut],[OrgnIdesc],[Actv_Val])  values('1','C',40,'EQ Index Optn',16,null,null,null,null,null,null,null,null,null,null,null,'EQ Index Optn',1)");
                        }
                        else
                            UpdateMethods.InvMst_insUpdate();
                    }
                    catch { }
                }
                if (CBuildDate < Convert.ToDateTime("17/08/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK]) VALUES('1','1', 'L', 6,0,201,  'Deposit for Mark to Mkt Margin A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','1' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')");
                        edpcom.RunCommand(" INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK]) VALUES('1','1', 'L', 6, 0, 202,  'Initial Margin-Eq Index Fut A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','3' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')");
                        edpcom.RunCommand("INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK]) VALUES('1','1', 'L', 6,0,203,  'Mark to Mkt Margin-Eq index Fut A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','1' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')");
                        edpcom.RunCommand(" INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK]) VALUES('1','1', 'L', 6, 0, 204,  'Initial Margin-Eq Stock fut A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','3' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')");
                        edpcom.RunCommand("INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK]) VALUES('1','1', 'L', 6,0,205, 'Mark to Mkt Margin-Eq Stock Fut A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','1' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')");
                        edpcom.RunCommand(" INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK]) VALUES('1','1', 'L', 6, 0, 206,  'Eq Index Option Margin A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','3' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')");
                        edpcom.RunCommand("INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK]) VALUES('1','1', 'L', 6,0,207,  'Eq Index Option Premium A/C', null, 30, 0, 0, 0, 1, 14, '0000000000', 0, 'D','1' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')");
                        edpcom.RunCommand(" INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK]) VALUES('1','1', 'L', 6, 0, 208,  'Eq Index Stock Margin A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','3' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')");
                        edpcom.RunCommand("INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK]) VALUES('1','1', 'L', 6,0,209,  'Eq Index Stock Premium A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','1' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')");                        
                    }
                    catch { }
                }

                if (CBuildDate < Convert.ToDateTime("18/08/11"))
                {
                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                         "VALUES('90030000000','90000000000','Global Stock for MF ','Global Stock for MF',1,' ',' ','0')");

                    edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                               "VALUES('50020403000','50020400000','Sale Purchase Analytical','SalePurchaseAnalytical',1,' ',' ','0')");
                    UpdateMethods.AlterCompanyTriggerForLedger();
                }
                if (CBuildDate < Convert.ToDateTime("20/08/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table iglmst add Yield numeric(18,2) NULL");
                    }
                    catch { }
                }

                if (CBuildDate < Convert.ToDateTime("25/08/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('90040000000','90000000000','Global Dashboard','Global Dashboard',1,' ',' ','0')");
                    }
                    catch { }
                }

                if (CBuildDate < Convert.ToDateTime("08/09/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('50020700000','50020000000','F and O Reports','F&O Reports',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('50020701000','50020700000','F and O MIS Statement','F&OMISStatement',1,' ',' ','0')");
                    }
                    catch { }
                }

                if (CBuildDate < Convert.ToDateTime("09/09/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('50020800000','50020000000','Commodity Future Reports','Commodity Future Reports',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('50020801000','50020800000','Commodity Future MIS Statement','Commodity Future MIS Statement',1,' ',' ','0')");
                    }
                    catch { }
                }

                if (CBuildDate < Convert.ToDateTime("16/09/11"))
                {
                    try
                    {                        
                        edpcom.RunCommand("Update ExngProduct set [Sec_Code]=23 Where Sec_Code=0");

                        string str1 = "CREATE TABLE [ALERT_MASTER]([ALERT_ID] [varchar](30) NOT NULL,[ALERT_NAME] [varchar](80) NOT NULL,[ALERT_TYPE] [varchar](50) NULL,[ALERT_ACTIVE] bit NULL,PRIMARY KEY CLUSTERED ([ALERT_ID] ASC))";
                        edpcom.RunCommand(str1);

                        str1 = "CREATE TABLE [ALERT_MARKET_RATE]([MRA_ID] [varchar](30) NOT NULL,[ALERT_ID] [varchar](30) NOT NULL,[MR_TYPE] [varchar](30) NOT NULL,[MR_CODE] [numeric](18, 0) NOT NULL,[EQUALITY] [varchar](30) NULL,[ABSOLUTE_VALUE] [numeric](18, 0) NULL,[BASIS_PERCENT] [numeric](18, 0) NULL,[BASIS_ON] [varchar](50) NULL,[ACTIVE] bit NULL,[SERIES] [varchar](30) NULL,[Expairy] [datetime] NULL,[Strick_Price] [numeric](18, 0) NULL,[Option_Type] [varchar](30) NULL,PRIMARY KEY CLUSTERED ([MRA_ID] ASC))";
                        edpcom.RunCommand(str1);

                        str1 = "CREATE TABLE [ALERT_MARKET_RATE_DETAILS]([MRDA_ID] [numeric](18, 0) NOT NULL,[MRA_ID] [varchar](30) NOT NULL,[FICODE] [varchar](30) NOT NULL,[GCODE] [varchar](30) NOT NULL,[T_Entry] [varchar](30) NULL,[USER_VCH] [varchar](50) NULL,[CO_NAME] [varchar](150) NULL,[PCODE] [numeric](18, 0) NULL, VCH_DATE [datetime] NULL, BALQTY [numeric](18, 2) NULL,[COSTPRICE] [numeric](18, 2) NULL,[TMKT_PRICE] [numeric](18, 2) NULL,PRIMARY KEY CLUSTERED ([MRDA_ID] ASC))";
                        edpcom.RunCommand(str1);

                        str1 = "CREATE TABLE [ALERT_ANNOUNCEMENT_DETAILS]([MRDA_ID] [numeric](18, 0) NOT NULL,[MRA_ID] [varchar](30) NOT NULL,[FICODE] [varchar](30) NOT NULL,[GCODE] [varchar](30) NOT NULL,[T_Entry] [varchar](30) NULL,[CO_NAME] [varchar](150) NULL,[PCODE] [numeric](18, 0) NULL,[COSTPRICE] [numeric](18, 2) NULL,[TMKT_PRICE] [numeric](18, 2) NULL,PRIMARY KEY CLUSTERED ([MRDA_ID] ASC))";
                        edpcom.RunCommand(str1);

                        edpcom.RunCommand("INSERT INTO ALERT_MASTER(ALERT_ID,ALERT_NAME,ALERT_TYPE,ALERT_ACTIVE) values('A1','MARKET RATE ALERT','MR','1')");
                        edpcom.RunCommand("INSERT INTO ALERT_MASTER(ALERT_ID,ALERT_NAME,ALERT_TYPE,ALERT_ACTIVE) values('A2','MATURITY DATE ALERT','MD','1')");
                        edpcom.RunCommand("INSERT INTO ALERT_MASTER(ALERT_ID,ALERT_NAME,ALERT_TYPE,ALERT_ACTIVE) values('A3','INTEREST DATE RECEIVED ALERT','ID','1')");
                        edpcom.RunCommand("INSERT INTO ALERT_MASTER(ALERT_ID,ALERT_NAME,ALERT_TYPE,ALERT_ACTIVE) values('A4','BONUS DECLEARED ALERT','BA','1')");
                        edpcom.RunCommand("INSERT INTO ALERT_MASTER(ALERT_ID,ALERT_NAME,ALERT_TYPE,ALERT_ACTIVE) values('A5','DIVIDEND DECLEARED ALERT','DD','1')");

                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('60090000000','60000000000','Alert Settings','AlertSettings',1,' ',' ','0')");

                        //edpcom.RunCommand("update Menutable set enable_menu=false where menucode='40020404010'");
                    }
                    catch { }
                }
                if (CBuildDate < Convert.ToDateTime("23/11/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table BookMasterPageDetails add RatePerPlate [numeric](18, 2) NULL");                        
                    }
                    catch { }
                }

                if (CBuildDate < Convert.ToDateTime("24/11/11"))
                {
                    try
                    {
                        edpcom.RunCommand("alter table Book_Master add AliseName [varchar](30) NULL");
                    }
                    catch { }
                }

                if (CBuildDate < Convert.ToDateTime("25/11/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('50030000000','50000000000','Agent Reports','Agent Reports',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('50030100000','50030000000','Agent Performance','Agent Performance',1,' ',' ','0')");

                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                  "VALUES('50040000000','50000000000','Printing/Binding Reports','Agent Reports',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('50040100000','50040000000','Printing Order','Printing Order',1,' ',' ','0')");
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('50040200000','50040000000','Binding Order','Binding Order',1,' ',' ','0')");
                                                
                    }
                    catch { }
                }
                if (CBuildDate < Convert.ToDateTime("26/11/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK]) VALUES('1','1', 'L', 10,19,211,  'Extra Commission Receivable A/C', null, 31, 0, 0, 0, 1, 19, '0000000000', 0, 'D','2' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')");
                    }
                    catch { }
                }
                if (CBuildDate < Convert.ToDateTime("27/11/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO glmst ([FICode],[GCODE],[MType],[MGROUP],[SGROUP],[GLCODE],[LDESC],[LALIAS],[T_FILTER],[OPBAL],[CURBAL],[LBAL],[SGRP_LEV],[PREV_GROUP],[ALOC_CODE],[CONS_FLG],[PDF_TYPE],[PDF_CODE],[NBAL_FLG],[UNB_GROUP],[UNB_SGROUP],[ACTV_FLG],[CURR_CODE],[NCONV_FCTR],[DCONV_FCTR],[TRANS_CLOS],[EXCHG_DIFF],[FC_CURBAL],[BOOL_CODE],[FC_OPBAL],[FC_LBAL],[EXDIFF_VAL],[OP_LBAL],[FC_OPLBAL],[SCHD_NO],[CFLOW_GROUP],[MGCODE],[MMTYPE],[MMGROUP],[MSGROUP],[MGLCODE],[MLDESC],[LOCK]) VALUES('1','1', 'L', 10,19,212,  'Round Off', null, 31, 0, 0, 0, 1, 19, '0000000000', 0, 'D','2' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')");
                    }
                    catch { }
                }

                if (CBuildDate < Convert.ToDateTime("28/11/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('50030200000','50030000000','Agent Wise Sales Report','Agent Wise Sales Report',1,' ',' ','0')");
                        
                    }
                    catch { }
                }
                if (CBuildDate < Convert.ToDateTime("29/11/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('50020500000','50020000000','Daily Tally Sheet','Daily Tally Sheet',1,' ',' ','0')");
                    }
                    catch { }
                }
                if (CBuildDate < Convert.ToDateTime("09/12/11"))
                {
                    try
                    {
                        edpcom.RunCommand("INSERT INTO MenuTable(MENUCODE,PARENTCODE,MENUDESC,DETAILDESC,ENABLE_MENU,FORMCODE,SHORTCUT_KEY,TOOLBARBTN)" +
                                   "VALUES('50020600000','50020000000','Purchase Register','PurchaseRegister',1,' ',' ','0')");
                    }
                    catch { }
                }

                UpdtDBInfo(CON);    //this will be call only one time.
                Versionflg = true;
            }
            this.Close();
        }

        private void SectorMasterInsert(SqlConnection Con)
        {
            try
            {
                string sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (1,'Banks','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (2,'Energy','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (3,'Technology','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (4,'Pharma','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (5,'Eng Cons & Mch','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (6,'Financial','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (7,'Agriculture','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (8,'Metal & Mining','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (9,'FMCG','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (10,'Media & Ent','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (11,'Power','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (12,'Chemicals','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (13,'Auto','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (14,'Telecommunications','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (15,'Auto Ancillary','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (16,'Textiles','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (17,'Miscellaneous Manufacture','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (18,'Retail','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (19,'Metal Fabricate/Hardware','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (20,'Commercial Services','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (21,'Consumer Durable','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (22,'Building Materials','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (23,'Others','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (24,'Defence','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (25,'Healthcare','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (26,'Diversified','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (27,'Transportation & Logistics','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (28,'Airlines','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (29,'Forest  Products & Paper','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (30,'Distribution/wholesale','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (31,'Education','1')";
                edpcom.RunCommand(sqlstr);
                sqlstr = "Insert into SectorMaster (Sec_Code,Sec_NAME,Sec_Flag) VALUES (32,'Hotels & Motels','1')";
                edpcom.RunCommand(sqlstr);                
            }
            catch { }
        }

        private void glmstRectification(SqlConnection Con)
        {
            string qry = "Update glmst set [ALOC_CODE]='0000000000',[CONS_FLG]=0,[PDF_TYPE]='C',[PDF_CODE]='2',[ACTV_FLG]=1,[NCONV_FCTR]='1',[DCONV_FCTR]=1,[TRANS_CLOS]=1,";
            qry = qry + "[EXCHG_DIFF]=0,[FC_CURBAL]=0,[FC_OPBAL]=0,[FC_LBAL]=0,[EXDIFF_VAL]=0,[CFLOW_GROUP]='A',[LOCK]='0' Where Mtype='L' and aloc_code is null";
            try { edpcom.RunCommand(qry); }

            catch { }
        }

        private void InvUpdate(SqlConnection Con)
        {
            try
            {
                string sqlstr = "ALTER TABLE InvMst ADD OrgnIdesc varchar(150) null,Actv_Val bit null";
                edpcom.RunCommand(sqlstr);
            }
            catch { }
        }

        private void AlterCompanyTrigger()
        {
            string SqlStr = "";
            SqlStr = "ALTER TRIGGER [dbo].[TrigCompOnglmstIn] on [dbo].[Company] For insert as set nocount on " + Environment.NewLine +
            "Declare @gcode Char(10),@ficode varchar(10)" + Environment.NewLine +
            "select @gcode=gcode,@ficode=ficode from inserted" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',5,0,33,'Investment in Bullion',NULL,30,0,0,0,1,0,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0')" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',5,0,34,'Insurance Premium Paid','TRAD',30,0,0,0,1,0,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0')" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',5,0,35,'Investment in ULIP','ULIP',30,0,0,0,1,0,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0')" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',5,0,36,'Investment in Fixed Deposit',NULL,30,0,0,0,1,0,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0')" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',6,13,29,'Stock of Shares','STKS',70,0,0,0,1,13,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0')" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',8,18,28,'Purchase of Shares','POS',50,0,0,0,1,18,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0')" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',9,0,27,'Sale of Shares','SOS',60,0,0,0,1,0,'0000000000',0,'C','1',0,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0')" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',11,0,26,'Profit from Trading in Commodities','PTCOM',30,0,0,0,1,0,'0000000000',0,'C','1',0,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0')" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',11,0,30,'Profit from Trading in F&O','PTFO',30,0,0,0,1,0,'0000000000',0,'C','1',0,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0')" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',11,0,31,'Loss from Trading in F&O','LTFO',30,0,0,0,1,0,'0000000000',0,'D','1',1,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0')" + Environment.NewLine +
            "INSERT INTO glmst VALUES(@ficode,@gcode,'L',11,0,32,'Loss from Trading in Commodities','LTCOM',30,0,0,0,1,0,'0000000000',0,'C','2',0,NULL,NULL,1,'1',1,1,0,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 6,14,1,  'Cash Account', null, 20, 0, 0, 0, 1, 14, '0000000000', 0, 'D','1' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 12, 0, 2,  'Profit & Loss A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 6, 0, 3,  'Opening Balance Debit A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','3' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 3, 0, 4,  'Opening Balance Credit A/C', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','4' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 5, 0, 5,  'Investment In Shares', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 5, 0, 6,  'Investment In Mutual Funds', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 3, 27, 7,  'Broker A/C', null, 30, 0, 0, 0, 1, 27, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 8,  'Security Transaction Tax','STT', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 9,  'Service Tax', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 10,  'Transaction Charges', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 11,  'Long Term Capital Loss', 'LTCL', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 12,  'Short Term Capital Loss', 'STCL', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 13,  'Miscellenious Charges', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 11, 0, 14,  'Long Term Capital Gain', 'LTCG', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 11, 0, 15,  'Short Term Capital Gain', 'LTCL', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 16,  'Long Term Capital Loss On Mutual Fund', 'LTCLMF', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 17,  'Short Term Capital Loss On Mutual Fund', 'STCLMF', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 11, 0, 18,  'Long Term Capital Gain On Mutual Fund', 'LTCGMF', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 11, 0, 19,  'Short Term Capital Gain On Mutual Fund', 'STCGMF', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 20,  'Trn.Over Charges', 'TOC', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 8, 0, 21,  'Stamp Charges', 'SC', 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 3, 6, 22,  'Edu. CESS A/C', 'EC', 30, 0, 0, 0, 1, 6, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 3, 6, 23,  'Higher Edu. CESS A/C', 'HEC', 30, 0, 0, 0, 1, 6, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 1, 1, 0,  'Reserve & Surplus', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','13' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 2, 2, 0,  'Secured Loans', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','14' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 2, 3, 0,  'Unsecured Loans', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','15' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 2, 4, 0,  'Bank Overdraft', null, 21, 0, 0, 0, 1, 0, '0000000000', 0, 'C','16' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3, 5, 0,  'Sundry Creditors', null, 23, 0, 0, 0, 1, 0, '0000000000', 0, 'C','17' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',3,  6, 0,  'Duties & Taxes', null, 32, 0, 0, 0, 1, 0, '0000000000', 0, 'C','18' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3,  7, 0,  'Provision', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','19' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3,  8, 0,  'Provision for Taxation', null, 30, 0, 0, 0, 2, 7, '0000000000', 0, 'C','20' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3,  9, 0,  'Provision for Dividend', null, 30, 0, 0, 0, 2, 7, '0000000000', 0, 'C','21' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 4, 10, 0,  'Fixed Asstes at Cost', null, 30, 0, 0, 0,1, 0, '0000000000', 0, 'D','22' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 4, 11, 0,  'Less Accumulated Depreciation', null, 30, 0, 0, 0, 1,0, '0000000000', 0, 'C','23' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 12, 0,  'Sundry Debtors', null, 22, 0, 0, 0, 1, 0, '0000000000', 0, 'D','24' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 13, 0,  'Stock in Hand', null, 70, 0, 0, 0, 1, 0, '0000000000', 0, 'D','25' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 14, 0,  'Cash Balances', null, 20, 0, 0, 0, 1, 0, '0000000000', 0, 'D','26' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 15, 0,  'Bank Balances', null, 21, 0, 0, 0, 1, 0, '0000000000', 0, 'D','27' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 16, 0,  'Short Term Investments', null, 21, 0, 0, 0, 2, 15, '0000000000', 0, 'D','28' ,1, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 6, 17, 0,  'Loans and Advances', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 8, 18, 0,  'Purchase Account', null, 50, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',10, 19, 0,  'Administration & Selling Expenses', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',10, 20, 0,  'Finance Expenses', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',10, 21, 0,  'Interest Expenses', null, 31, 0, 0, 0, 2, 20, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',10, 22, 0,  'Dividend Expenses', null, 31, 0, 0, 0, 2, 20, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',11, 23, 0,  'Profit on Sale of Investments', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',11, 24, 0,  'Profit on Sale of Fixed Assets', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',11, 25, 0,  'Investment Income', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S',11, 26, 0,  'Extraordinary Expenses', null, 31, 0, 0, 0, 1, 0, '0000000000', 0, 'D','29' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 3, 27, 0, 'Broker', null, 23, 0, 0, 0, 2, 5, '0000000000', 0, 'C','40' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0') " + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 4, 28, 0,  'Less Depriciation Of Factory Equipments', null, 33, 0, 0, 0, 1,0, '0000000000', 0, 'C','41' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'S', 8, 29, 0,  'Opening Stock', null, 30, 0, 0, 0, 1,0, '0000000000', 0, 'C','41' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO glmst VALUES(@ficode,@gcode, 'L', 5, 0, 24,  'Investment In Commodities', null, 30, 0, 0, 0, 1, 0, '0000000000', 0, 'C','2' ,0, null, null, 1, '1', 1, 1,  0, 0,0,null,0, 0, 0, 0, 0, null,'A', null, null, null, null, null, null,'0')" + Environment.NewLine +
         "INSERT INTO prtyms(FICode,GCODE,GLCode,STT,SERVICE_TAX,brokShrtsl,brokPurchase,BRKG_PERCENTAGE,CRED_DAYS) VALUES(@ficode,@gcode, 7, 0.25, 12.36, 0.5, 0.5, 0.5,7)" + Environment.NewLine +
         "set nocount off";



        }

        private void AddUpdateINFLT()
        {
            try
            {
                edpcom.RunCommand(" Update INFLT Set indxval=582 Where stindxdt='04/01/2008'");
                edpcom.RunCommand(" Insert into INFLT Values('04/01/2009','03/31/2010',632)");
                edpcom.RunCommand(" Insert into INFLT Values('04/01/2010','03/31/2011',650)");
            }
            catch { }
        }

        private void UpdateMenu()
        {
            try
            {
                edpcom.RunCommand(" Update MenuTable Set MENUDESC='Investment/Trading Reports' Where MENUCODE='50020000000'");
            }
            catch { }
        }

        private void AssetPropFld()
        {
            string strmfmst = "CREATE TABLE [AssetPropFld]([Ficode] [char](10) NOT NULL,[Gcode] [char](10)  NOT NULL,[FieldID] [numeric](18, 0) NOT NULL,[AssetClass] [varchar](50) NULL,[TransactionClass] [varchar](50) NULL,[FieldName] [varchar](100) NULL,[FieldLength] [int] NULL,[FIeldType] [varchar](50)  NULL,[NullCheck] [bit] NULL,[PrintName] [varchar](50)NULL,[Dfltval] [varchar](max) NULL,CONSTRAINT [PK_AssetPropFld] PRIMARY KEY CLUSTERED ([Ficode] ASC,[Gcode] ASC,[FieldID] ASC))";
            try
            {
                edpcom.RunCommand(strmfmst);
            }
            catch { }
        }

        private void UpdateForComodity()
        {
            try
            {
                edpcom.RunCommand(" insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02090100000000000000','Order No.','02090000000000000000',0,'2.9.1',1,'S',null,null,null,null)");
            }
            catch { }
            try
            {
                edpcom.RunCommand(" insert into CNFGMST(CNFG_TYPE,CNFG_LEVEL,MENUCODE,CNFG_CODE,CNFG_DESC,PARENT_CODE,SERIAL_NO,ARTICLE_NO,DEFAULT_BOOL_VA,DEFAULT_VAL_TYPE,STR_VAL,Bool_VAL,NUM_VAL,DATE_VAL)values('A','C','0000','02090200000000000000','Trade No.','02090000000000000000',0,'2.9.2',1,'S',null,null,null,null)");
            }
            catch { }
        }

        private void createvchlocktable(SqlConnection CON)
        {
            string strvchlock = " Drop table vchlock ";
            strvchlock = strvchlock + " create table vchlock(FICode char(10) not null,GCODE char(10) not null,VTYPE char(1) not null,T_ENTRY char(2) not null,VOUCHER numeric not null,";
            strvchlock = strvchlock + " [AutoIncre] [numeric](18, 0) IDENTITY(1,1) NOT NULL,USER_VCH	varchar(100),EDITFLAG char(1),USERCODE varchar(6),MODIFIED bit,ZEROFLG char(1),ViewFlag bit";
            strvchlock = strvchlock + " primary key clustered(FICode,GCODE,VTYPE,T_ENTRY,VOUCHER,[AutoIncre]))";
            SqlCommand cmd = new SqlCommand(strvchlock, CON);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        private void FDIntUpdate(SqlConnection CON)
        {
            string str = "ALTER TABLE FDInt ADD NetInterest money null";
            try
            {
                edpcom.RunCommand(str, CON);
            }
            catch { }
        }

        private void VchLockUpdate(SqlConnection CON)
        {
            string strvchlock = "drop table vchlock create table vchlock(FICode char(10) not null,GCODE char(10) not null,VTYPE char(1) not null,T_ENTRY char(2) not null,VOUCHER numeric not null,";
            strvchlock = strvchlock + "[AutoIncre] [numeric](18, 0) IDENTITY(1,1) NOT NULL,USER_VCH	varchar(100),EDITFLAG char(1),USERCODE varchar(6),MODIFIED bit,ZEROFLG char(1),ViewFlag bit";
            strvchlock = strvchlock + "primary key clustered(FICode,GCODE,VTYPE,T_ENTRY,VOUCHER,[AutoIncre]))";
            SqlCommand cmd = new SqlCommand(strvchlock, CON);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            { }
        }

        private void AlterProcTypeMast(SqlConnection CON)
        {
            string sqlstr = " Alter proc TypeMast_ins @pFICode char(10),@pGcode char(10) as begin" + Environment.NewLine;
            sqlstr = sqlstr + " if  exists(select * from TypeMast where FIcode=@pFICode and GCODE=@PGcode)" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " declare @Ficode char(10),@Gcode char(10)" + Environment.NewLine;
            sqlstr = sqlstr + " Declare Cursor2 Cursor For  SELECT DISTINCT FICode,Gcode FROM TypeMast" + Environment.NewLine;
            sqlstr = sqlstr + " Open Cursor2" + Environment.NewLine;
            sqlstr = sqlstr + " Fetch Next From Cursor2  into @Ficode,@Gcode" + Environment.NewLine;
            sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
            sqlstr = sqlstr + " Begin" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'8G','GiftIn','GftIn')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'9G','GiftOut','GftOut') " + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'8S','StockIn','StckIn') " + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'9S','StockOut','StckOut')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'N','Conversion','Cnvsn')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'DE','Dividend Entry','Div')" + Environment.NewLine;
            sqlstr = sqlstr + " Fetch Next From Cursor2  into @Ficode,@Gcode" + Environment.NewLine;
            sqlstr = sqlstr + " End" + Environment.NewLine;
            sqlstr = sqlstr + " CLOSE Cursor2" + Environment.NewLine;
            sqlstr = sqlstr + " DEALLOCATE Cursor2" + Environment.NewLine;
            sqlstr = sqlstr + " END" + Environment.NewLine;
            sqlstr = sqlstr + " else" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'1','Receipt','Rcpt')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'2','Payment','Pymt')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'3','Journal ','Jrnl')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'4','Credit Note','Crnt')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'5','Contra','Cntra')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'6','Cheque Return','Chqrtrn')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'7','Debit Note','Dbnt')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8','Market Purchase','MP')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9','Sale','Sale')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8O','Opening','Opng')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'S','Short Sale','Shrtsle')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AA','Applied For','Appf')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AB','Allotment','Altmnt')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AC','Refund','Refnd')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'C','Composite Transaction','Cmpt')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8G','GiftIn','GftIn')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9G','GiftOut','GftOut')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8S','StockIn','StckIn')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9S','StockOut','StckOut')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'N','Conversion','Cnvsn')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8I','Insurance','Insu')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8F','Fixed Deposite','FD')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9F','Fixed Deposite Redeem','FDR')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'M','Commodities','Comm')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'U','Mutual Funds','MF')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'DE','Dividend Entry','Div')" + Environment.NewLine;
            sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'DE','Dividend Entry','Div')" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " end";
            SqlCommand cmd = new SqlCommand(sqlstr, CON);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        private void DividendTablecreation(SqlConnection CON)
        {
            string Divident_Schedlr = "Drop table Divident_Schedlr";
            SqlCommand cmd = new SqlCommand(Divident_Schedlr, CON);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            Divident_Schedlr = "CREATE TABLE [Divident_Schedlr]([Ficode] [char](10) NOT NULL,[Gcode] [char](10) NOT NULL,[User_Vch] [varchar](max) NULL,[Voucher] [numeric](18, 0) NOT NULL," +
                "[T_entry] [char](2) NOT NULL,[Vch_Date] [datetime] NOT NULL,[AutoIncNo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,[Pcode] [numeric](18, 0) NULL,[DPcode] [numeric](18, 0) NULL,[Declare_Date] [datetime] NULL," +
                "[Applicable_Date] [datetime] NULL,[Total_Qty] [decimal](18, 0) NULL,[Declare_Qty] [decimal](18, 0) NULL,[Div_Percent] [numeric](18, 2) NULL,[Div_pers] [numeric](18, 2) NULL,[Amount] [numeric](18, 2) NULL," +
                "[Note] [varchar](50) NULL,[Delv_Status] [varchar](50) NULL,[WarrantNo] [varchar](max) NULL,[WarrantDate] [datetime] NULL,[Options] [varchar](50) NULL,[Link_voucher] [numeric](18, 0) NULL,[Link_tentry] [char](2) NULL," +
                "[Desccode] [numeric](18, 0) NULL,[Financial_Year] [varchar](50) NULL,PRIMARY KEY CLUSTERED ([Ficode] ASC,[Gcode] ASC,[Voucher] ASC,[T_entry] ASC,[Vch_Date] ASC,[AutoIncNo] ASC))";
            cmd = new SqlCommand(Divident_Schedlr, CON);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
        }

        private void UpdateFrmMst(SqlConnection CON)
        {
            string sqlstr = "ALTER TABLE Formula_Master ADD Icode numeric(18, 0) Null";
            try
            {
                edpcom.RunCommand(sqlstr, CON);
            }
            catch { }
        }

        private void AlterProcCopyBrker(SqlConnection CON)
        {
            string sqlstr = "Alter PROCEDURE COPY_BRKS @DestFicode Char(10),@DestGcode Char(10),@SourceFicode char(10),@SourceGcode char(10),@Sdate datetime,@Edate datetime" + Environment.NewLine;
            sqlstr = sqlstr + " AS BEGIN" + Environment.NewLine;
            sqlstr = sqlstr + " execute COPY_ACC @DestFicode,@DestGcode,@SourceFicode,@SourceGcode" + Environment.NewLine;
            sqlstr = sqlstr + " DELETE FROM Formula_Master  WHERE Ficode=@DestFicode and GCODE = @DestGcode" + Environment.NewLine;
            sqlstr = sqlstr + " INSERT INTO Formula_Master( FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal)SELECT @DestFicode,@DestGcode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,@Sdate,@Edate,0 FROM Formula_Master WHERE Ficode=@SourceFicode and GCODE = @SourceGcode" + Environment.NewLine;
            sqlstr = sqlstr + " END";
            try
            {
                edpcom.RunCommand(sqlstr, CON);
            }
            catch { }
        }

        private void UpdtDBForNominee(SqlConnection con)
        {
            string strnominee = "CREATE TABLE NomineeMaster (GCODE char(10) NOT NULL,ID int NOT NULL ,Type char(2) NOT NULL ,Parent int NOT NULL ,";
            strnominee = strnominee + "Nominee_Name varchar(30) ,Nominee_DOB datetime ,Relation varchar (30) ,Nominee_Gur varchar(30) , Internal int ,Link_Gcode char(10)";
            strnominee = strnominee + "PRIMARY KEY  CLUSTERED(GCODE,ID,Type))";
            SqlCommand cmd = new SqlCommand(strnominee, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            string strmfmst = "ALTER TABLE DPMAST ADD Nominee_ID int Null";
            try
            {
                edpcom.RunCommand(strmfmst, con);
            }
            catch { }
            strmfmst = " ALTER TABLE FixedDepositeMaster ADD Location Varchar(50) Null,Nominee_ID int Null";
            try
            {
                edpcom.RunCommand(strmfmst, con);
            }
            catch { }
            //strmfmst = " ALTER TABLE itran ADD Nominee_ID int Null";
            //try
            //{
            //    edpcom.RunCommand(strmfmst, con);
            //}
            //catch { }
            strmfmst = " ALTER TABLE ETran ADD Nominee_ID int Null";
            try
            {
                edpcom.RunCommand(strmfmst, con);
            }
            catch { }
            strmfmst = " ALTER TABLE SHARE_INFO ADD Nominee_ID int Null";
            try
            {
                edpcom.RunCommand(strmfmst, con);
            }
            catch { }
            strmfmst = " ALTER TABLE INSURANCEMST drop column RELATION ";
            try
            {
                edpcom.RunCommand(strmfmst, con);
            }
            catch { }
        }

        private void UpdtDBInfo(SqlConnection con)
        {                                                //exe version  
            string cm = "insert into Midas_Db_Info values('DEMO','" + Environment.MachineName + "','" + edpcom.PEXE_VERSION + "','" + edpcom.getSqlDateStr(PBuildDate) + "','" + edpcom.getSqlDateStr(DateTime.Now.Date) + "')";
            SqlCommand cmd = new SqlCommand(cm, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Cannot Update DB Info.");
                con.Close();
            }
        }
        public bool chk_table_creation(SqlConnection con)
        {
            string straccss = "create table ch_k(FICode char(10) not null,USER_CODE varchar(6) not null,GCODE char(10) not null,OPTION_STRING varchar(6),";
            straccss = straccss + "ENTRY_OPTION char(2),REPORT_OPTION varchar(5),BRNCH_CODE numeric,";
            straccss = straccss + "RESTRICT_LOCN bit, primary key clustered(FICode ,USER_CODE,GCODE))";
            SqlCommand cmd = new SqlCommand(straccss, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool alt_table_creation(SqlConnection con)
        {
            string straccss = " Alter table ch_k drop primary key(USER_CODE)";
            SqlCommand cmd = new SqlCommand(straccss, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool currency_alter(SqlConnection con)
        {
            string straccss = " alter table currency alter column DFLT_FLG bit";
            SqlCommand cmd = new SqlCommand(straccss, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TrnsType_alter(SqlConnection con)
        {
            string str1 = "ALTER TABLE itran ADD TransType varchar(20)";
            string str2 = "ALTER TABLE ETran ADD  TransType varchar(20)";
            SqlCommand cmd = new SqlCommand(str1, con);
            SqlCommand cmd1 = new SqlCommand(str2, con);
            try
            {
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IGLMST_alter(SqlConnection con)
        {
            string str1 = "ALTER TABLE IGLMST ADD Exp_Date datetime   DEFAULT (getdate()),Unit_Of_Mez varchar(50)," +
                "Strike_Price numeric(18, 3),Lot_Size numeric(18, 0),Lot_Unit varchar(50)";
            SqlCommand cmd = new SqlCommand(str1, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool RowIndx_alter(SqlConnection con)
        {

            string str1 = "ALTER TABLE itran ADD RowIndex int";
            string str2 = "ALTER TABLE ETran ADD  RowIndex int";
            SqlCommand cmd = new SqlCommand(str1, con);
            SqlCommand cmd1 = new SqlCommand(str2, con);
            try
            {
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public void Comment_alter(SqlConnection con)
        {

            string str1 = "ALTER TABLE itran ADD Comment Varchar(50)";
            string str2 = "ALTER TABLE ETran ADD  Comment Varchar(50)";
            string str3 = "Alter table EffectTran add Comment varchar(50),ItemNo numeric";
            string str4 = "Alter table PLTran add Comment varchar(50),ItemNo numeric";
            SqlCommand cmd = new SqlCommand(str1, con);
            SqlCommand cmd1 = new SqlCommand(str2, con);
            SqlCommand cmd2 = new SqlCommand(str3, con);
            SqlCommand cmd3 = new SqlCommand(str4, con);
            try
            {
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
            }
            catch { }

        }
        public bool MenuUser_alter(SqlConnection con)
        {

            string str1 = "ALTER TABLE MenuUser ADD TOOLBARBTN bit";
            SqlCommand cmd = new SqlCommand(str1, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public void TypeMast_Updt(SqlConnection con)
        {
            string strdb = "TypeMast_ins";
            SqlCommand cmd = new SqlCommand(strdb, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter FICODE = new SqlParameter("@pFICode", edpcom.CurrentFicode);
            SqlParameter GCODE = new SqlParameter("@pGCODE", edpcom.PCURRENT_GCODE);
            cmd.Parameters.Add(FICODE);
            cmd.Parameters.Add(GCODE);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
        }
        public bool alloc_table_creation(SqlConnection con)
        {
            string stralloc = "create table alloc (FICODE char(10) NOT NULL,GCODE char(10) NOT NULL,VOUCHER numeric(18, 0) NOT NULL,AUTOINCRE int NOT NULL,";
            stralloc = stralloc + "ALLOC_NO numeric(18, 0) NULL,ALLOC_DATE datetime NOT NULL,PARTY_CODE numeric(18, 0) NOT NULL,BT_ENTRY char(2) NOT NULL,";
            stralloc = stralloc + "B_VOUCHER numeric(18, 0),B_USER_VCH varchar(50),RPT_ENTRY char(2) NULL,RP_VOUCHER numeric(18, 0),";
            stralloc = stralloc + "RP_USER_VCH varchar(50),AMT money NOT NULL,B_AMT money,RP_AMT money,CURR_CODE varchar(6),AllocFlg bit,";
            stralloc = stralloc + "primary key clustered(FICode ,GCODE,VOUCHER,AUTOINCRE))";
            SqlCommand cmd = new SqlCommand(stralloc, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public void TriggerAdjustPLtran_creation(SqlConnection con)
        {
            string sqlstr = "CREATE TRIGGER AdjustEtran ON PLtran" + Environment.NewLine;
            sqlstr = sqlstr + " FOR INSERT, DELETE AS" + Environment.NewLine;
            sqlstr = sqlstr + " set NoCount On" + Environment.NewLine;
            sqlstr = sqlstr + " declare @AgainstTentry char(2),@AgainstVoucherCode numeric,@AgainstAutoIncre numeric,@EffectiveQTY float,@T_Entry char(2)" + Environment.NewLine;
            sqlstr = sqlstr + " if exists(Select * from deleted where T_Entry in ('C8','C9','9M','8','9','8N','9N'))" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " Declare delcur Cursor For select AgainstTentry,AgainstVoucherCode,AgainstAutoIncre,EffectiveQTY,T_ENTRY from deleted" + Environment.NewLine;
            sqlstr = sqlstr + " Open delcur" + Environment.NewLine;
            sqlstr = sqlstr + " Fetch Next From delcur into @AgainstTentry,@AgainstVoucherCode,@AgainstAutoIncre,@EffectiveQTY,@T_Entry" + Environment.NewLine;
            sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " if(@T_Entry='C8') or (@T_Entry='8') or (@T_Entry='8N')" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " update etran set BALQTY=BALQTY+@EffectiveQTY,STATUS='PendingPurchase'  where T_ENTRY=@AgainstTentry and VOUCHER=@AgainstVoucherCode and AUTOINCRE=@AgainstAutoIncre and STATUS='PendingPurchase' or STATUS='Complete'" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " else if(@T_Entry='C9') or (@T_Entry='9M') or (@T_Entry='9') or (@T_Entry='9N')" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " update etran set BALQTY=BALQTY+@EffectiveQTY,STATUS='PendingSale'  where T_ENTRY=@AgainstTentry and VOUCHER=@AgainstVoucherCode and AUTOINCRE=@AgainstAutoIncre and STATUS in('PendingSale','Complete')" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " Fetch Next From delcur into @AgainstTentry,@AgainstVoucherCode,@AgainstAutoIncre,@EffectiveQTY,@T_Entry" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " Close delcur" + Environment.NewLine;
            sqlstr = sqlstr + " Deallocate delcur" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " if exists(Select * from inserted where T_Entry in ('9M','9','8','C8','C9','8N','9N'))" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " Declare delcur1 Cursor For select AgainstTentry,AgainstVoucherCode,AgainstAutoIncre,EffectiveQTY,T_ENTRY from inserted" + Environment.NewLine;
            sqlstr = sqlstr + " Open delcur1" + Environment.NewLine;
            sqlstr = sqlstr + " Fetch Next From delcur1 into @AgainstTentry,@AgainstVoucherCode,@AgainstAutoIncre,@EffectiveQTY,@T_Entry" + Environment.NewLine;
            sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " if (@T_Entry='9M') or (@T_Entry='9') or (@T_Entry='8') or (@T_Entry='C8') or (@T_Entry='C9') or (@T_Entry='9N')" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " declare @balQTY numeric" + Environment.NewLine;
            sqlstr = sqlstr + " Declare delcur2 Cursor For select BALQTY from etran where T_ENTRY=@AgainstTentry and VOUCHER=@AgainstVoucherCode and AUTOINCRE=@AgainstAutoIncre" + Environment.NewLine;
            sqlstr = sqlstr + " Open delcur2" + Environment.NewLine;
            sqlstr = sqlstr + " Fetch Next From delcur2 into @balQTY" + Environment.NewLine;
            sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " set @balQTY=@balQTY-@EffectiveQTY" + Environment.NewLine;
            sqlstr = sqlstr + " if (@balQTY=0)" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " update etran set BALQTY=BALQTY-@EffectiveQTY,STATUS='Complete'  where T_ENTRY=@AgainstTentry and VOUCHER=@AgainstVoucherCode and AUTOINCRE=@AgainstAutoIncre" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " else if(@balQTY>0)" + Environment.NewLine;
            sqlstr = sqlstr + " begin" + Environment.NewLine;
            sqlstr = sqlstr + " update etran set BALQTY=BALQTY-@EffectiveQTY,STATUS='PendingSale'  where T_ENTRY=@AgainstTentry and VOUCHER=@AgainstVoucherCode and AUTOINCRE=@AgainstAutoIncre" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " Fetch Next From delcur2 into @balQTY" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " Close delcur2" + Environment.NewLine;
            sqlstr = sqlstr + " Deallocate delcur2" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " Fetch Next From delcur1 into @AgainstTentry,@AgainstVoucherCode,@AgainstAutoIncre,@EffectiveQTY,@T_Entry" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " Close delcur1" + Environment.NewLine;
            sqlstr = sqlstr + " Deallocate delcur1" + Environment.NewLine;
            sqlstr = sqlstr + " end" + Environment.NewLine;
            sqlstr = sqlstr + " set NoCount Off";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        public void T_ENTRY_Entry(SqlConnection con)
        {

            string sqlstr = " if exists (select * from sysobjects where id = object_id('TypeMast_ins ')" + Environment.NewLine;
            sqlstr = sqlstr + " and OBJECTPROPERTY(id, 'IsProcedure') = 1)" + Environment.NewLine;
            sqlstr = sqlstr + " drop procedure TypeMast_ins" + Environment.NewLine;
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            try
            {
                cmd.ExecuteNonQuery();
                sqlstr = " create proc TypeMast_ins @pFICode char(10),@pGcode char(10) as begin" + Environment.NewLine;
                sqlstr = sqlstr + " if  exists(select * from TypeMast where FIcode=@pFICode and GCODE=@PGcode)" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " declare @Ficode char(10),@Gcode char(10)" + Environment.NewLine;
                sqlstr = sqlstr + " Declare Cursor2 Cursor For  SELECT DISTINCT FICode,Gcode FROM TypeMast" + Environment.NewLine;
                sqlstr = sqlstr + " Open Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From Cursor2  into @Ficode,@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + " While @@Fetch_Status=0" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'8G','GiftIn','GftIn')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'9G','GiftOut','GftOut') " + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'8S','StockIn','StckIn') " + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'9S','StockOut','StckOut')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@FICode,@Gcode,'CN','Convesion','Cnvsn')" + Environment.NewLine;
                sqlstr = sqlstr + " Fetch Next From Cursor2  into @Ficode,@Gcode" + Environment.NewLine;
                sqlstr = sqlstr + " End" + Environment.NewLine;
                sqlstr = sqlstr + " CLOSE Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " DEALLOCATE Cursor2" + Environment.NewLine;
                sqlstr = sqlstr + " END" + Environment.NewLine;
                sqlstr = sqlstr + " else" + Environment.NewLine;
                sqlstr = sqlstr + " begin" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'1','Receipt','Rcpt')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'2','Payment','Pymt')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'3','Journal ','Jrnl')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'4','Credit Note','Crnt')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'5','Contra','Cntra')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'6','Cheque Return','Chqrtrn')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'7','Debit Note','Dbnt')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8','Market Purchase','MP')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9','Sale','Sale')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8O','Opening','Opng')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'S','Short Sale','Shrtsle')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AA','Appliad For','Appf')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AB','Allotment','Altmnt')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'AC','Refund','Refnd')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'C','Composite Transaction','Cmpt')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8G','GiftIn','GftIn')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9G','GiftOut','GftOut')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'8S','StockIn','StckIn')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'9S','StockOut','StckOut')" + Environment.NewLine;
                sqlstr = sqlstr + " insert into TypeMast values(@pFICode,@pGcode,'N','Convesion','Cnvsn')" + Environment.NewLine;
                sqlstr = sqlstr + " end" + Environment.NewLine;
                sqlstr = sqlstr + " end";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }

            }
            catch { }

        }

        public static void AlterFDInfo()
        {
            Edpcom.EDPCommon edpcom = new EDPCommon();
            string StrSql = "";
            try
            {
                StrSql = "DROP TABLE FDInfo" + Environment.NewLine +
                " CREATE TABLE [dbo].[FDInfo]( " + Environment.NewLine +
                " [FICode] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," + Environment.NewLine +
                " [GCODE] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," + Environment.NewLine +
                " [T_ENTRY] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL," + Environment.NewLine +
                " [PCODE] [numeric](18, 0) NOT NULL," + Environment.NewLine +
                " [AUTOINCRE] [numeric](18, 0) IDENTITY(1,1) NOT NULL," + Environment.NewLine +
                " [VOUCHER] [numeric](18, 0) NOT NULL," + Environment.NewLine +
                " [IntType] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," + Environment.NewLine +
                " [ReceiptDate] [datetime] NULL," + Environment.NewLine +
                " [Period] [numeric](18, 0) NULL," + Environment.NewLine +
                " [PeriodUnit] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," + Environment.NewLine +
                " [StartDate] [datetime] NULL," + Environment.NewLine +
                " [MaturityDate] [datetime] NULL," + Environment.NewLine +
                " [PrincipalAmt] [money] NULL," + Environment.NewLine +
                " [AmtPaid] [money] NULL," + Environment.NewLine +
                " [IntRate] [float] NULL," + Environment.NewLine +
                " [IntUnit] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," + Environment.NewLine +
                " [FirstIntReceive] [datetime] NULL," + Environment.NewLine +
                " [Frequency] [numeric](18, 0) NULL," + Environment.NewLine +
                " [FrequencyUnit] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," + Environment.NewLine +
                " [PayOut] [numeric](18, 0) NULL," + Environment.NewLine +
                " [PayOutUnit] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL," + Environment.NewLine +
                " [TDSRate] [float] NULL," + Environment.NewLine +
                " [ItemNo] [numeric](18, 0) NULL," + Environment.NewLine +
                " [RowIndex] [numeric](18, 0) NULL," + Environment.NewLine +
                " [FDState] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL CONSTRAINT [DF__FDInfo__FDState__6CD828CA]  DEFAULT ('R')," + Environment.NewLine +
             " CONSTRAINT [PK__FDInfo__24927208] PRIMARY KEY CLUSTERED " + Environment.NewLine +
            " (" + Environment.NewLine +
                " [FICode] ASC," + Environment.NewLine +
                " [GCODE] ASC," + Environment.NewLine +
                " [T_ENTRY] ASC," + Environment.NewLine +
                " [PCODE] ASC," + Environment.NewLine +
                " [AUTOINCRE] ASC," + Environment.NewLine +
                " [VOUCHER] ASC" + Environment.NewLine +
            " )WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]" + Environment.NewLine +
            " ) ON [PRIMARY]";

                edpcom.RunCommand(StrSql);
            }
            catch { }

            try
            {
                StrSql = " ALTER TABLE dbo.FDInt ADD [PayOutAnt] [numeric](18, 2) NULL";
                edpcom.RunCommand(StrSql);
            }
            catch { }

        }

    }
}