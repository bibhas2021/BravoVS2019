using System;
using System.Data.SqlClient;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;
using System.Data.OleDb;
using EDPMessageBox;
using System.IO;
using System.IO.Compression;
using System.ComponentModel;
using System.Windows.Forms;


namespace Edpcom
{
    /// <summary>
    /// Summary description for the class.
    /// </summary>

    public class EDPCommon
    {
        public static bool Chk_3rd_Position_Value = false;
        public static bool Chk_4th_Position_Value = false;
        public static string Query, Caption, Header, ClmHeader;
        public static int columnindex;
        public static int qry_dt = 0, AssetBlock = 0;
        public static string StckTb;
        public static ArrayList arr_mod = new ArrayList();
        public static DataTable dtss = new DataTable();
        public static Hashtable Hsdtss = new Hashtable();
        public static Hashtable get_code = new Hashtable();
        public static DataSet STCK_DS = new DataSet();
        public static bool RCount;
        public static string LOVReturnValue, LOVReturnText;
        public static int UserCount = 0;
        public static DataSet STCK_DS_EDP = new DataSet();
        public static string Query_Existing_Item;
        public static bool chk_Key_Press;
        public static string Column_Hide_Index = "";
        public static string RoundOff_Service_Tax_Type = "", RoundOff_Exceise_Type = "";
        public static string FormName_EDPC, ComponentName_EDPC;
        public static bool chk_appropriation = false;
        public static int Key_Press_Value = 0;

        //-------------API Declarations
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32", SetLastError = true)]
        static extern int SetLocaleInfo(int LOCALE_SYSTEM_DEFAULT, int LOCALE_SSHORTDATE, string lpLCData);

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //------------Private Variables
        private static string SvrName = "";
        private static string CurrentUser = "";
        private static string DatabaseName = "";
        private static string DeveloperName = "";
        private static string ExeVersion = "";
        private static string CurrGco = "";
        private static DateTime BuildDate;
        private static bool firsttimeinstall;
        private static int CURRENTSES;
        private static string CURRENCOMP;
        private static string Envelope;
        private static string Menutype;
        private static string Bittype;
        private static string CurrentBranch;
        private static string CurrFIcode;
        private static string UserDescription;
        private static string UserLev, Thousand_Sep;
        private static int CurrCode;
        private SqlCommand mycmd;
        private SqlDataReader mydr;
        private Point Hold;
        private Form MoveForm;
        private static bool remote;
        private static bool getMsg;
        private static DateTime CURCO_SDT;
        private static DateTime CURCO_EDT;
        private static int Decimal_Place;
        private static bool restoremode;
        private static bool exclusive;
        public static int Red_Color;
        private static int[] R_G_B ={ 252, 250, 214 };
        private static int DemoDays;
        private static string dataversion;
        private static string applicationname;
        private static string applicationExt;
        private static string NetLibrary;
        private static string Inte_Security;
        private static string user_id;
        private static string password;
        private static string Trusted_con;
        private static string connection_TOut;
        private static bool PSI;
        private static string DSE;
        //Form AccordFour Company Details
        private static string company =" ";
        private static string Phone=" ";
        private static string address2 = " ";
        private static string address3 = " ";
        private static string Reg = " ";
        private static string Div = " ";
        private static string Comm = " ";
        private static string Ecc = " ";
        private static string Email = " ";
        private static string Pan = " ";
        private static string Tin = " ";
        private static string Vat = " ";
        private static string Cst = " ";
        
        //End AccordFour Company Details 

        private static string company1 = " ";
        private static string Phone1 = " ";
        private static string address21 = " ";
        private static string address31 = " ";
        private static string Reg1 = " ";
        private static string Div1 = " ";
        private static string Comm1 = " ";
        private static string Ecc1 = " ";
        private static string Email1 = " ";
        private static string Pan1 = " ";
        private static string Tin1 = " ";       
        //Form AccordFour Party Details

        private static string pPhone = " ";
        private static string paddress2 = " ";
        private static string paddress3 = " ";
        private static string pEmail = " ";
        //End AccordFour Party Details 
        //Form AccordFour BillAdditional Details
        private static string transPortName;
        private static string ConsingmentNo;
        private static string ConsingmentDate;
        private static string NoofPackages;
        private static string SRVNO;
        private static string SRVNODate;
        private static string LorryNo;
        private static string Weight;
        private static string Delivery_At;
        private static string Kind_Attention;
        private static string PhoneNo;
        private static string Mode_Of_Transport;
        private static string Prepared_by;
        private static string Indent;
        private static string Advance;
        private static string Invoice_Preparetion;
        private static string Removal_Date;
        private static string Removal_Time;
        private static string InvoiceIssueDate;
        private static string InvoiceIssueTime;
        private static string Your_Order_No;
        private static string Your_Order_Date;
        private static string Payment_Terms;
        private static string Payment_Date;
        private static string Superuser_code;
        private static string UG_code;

        int cou = 0;
        //End AccordFour BillAdditional Details

        //------------Public Properties
        public string ApplicationExtension
        {
            get { return applicationExt; }
            set { applicationExt = value; }
        }
        public string ApplicationName
        {
            get { return applicationname; }
            set { applicationname = value; }
        }
        public string DataVersion
        {
            get { return dataversion; }
            set { dataversion = value; }
        }
        public int[] Get_Color
        {
            get
            {
                (new Microsoft.VisualBasic.Devices.Computer()).Registry.SetValue(@"HKEY_CURRENT_USER\AccordFour\ColorScheme", "Test", this.ApplicationName);
                return R_G_B;
            }
            set
            {
                R_G_B = value;
            }
        }
        public bool Exclusive
        {
            get
            {
                return exclusive;
            }
            set
            {
                exclusive = value;
            }
        }
        public bool RestoreMode
        {
            get
            {
                return restoremode;
            }
            set
            {
                restoremode = value;
            }
        }
        public bool GetMsg
        {
            get
            {
                return getMsg;
            }
            set
            {
                if (value != getMsg)
                {
                    getMsg = value;
                }
            }
        }
        public int GetDecimal_Place
        {
            get
            {
                return Decimal_Place;
            }
            set
            {
                if (value != Decimal_Place)
                {
                    Decimal_Place = value;
                }
            }
        }
        public string GetThousand_Sep
        {
            get
            {
                return Thousand_Sep;
            }
            set
            {
                if (value != Thousand_Sep)
                {
                    Thousand_Sep = value;
                }
            }
        }
        public int GetDemoDays
        {
            get
            {
                return DemoDays;
            }
            set
            {
                if (value != DemoDays)
                {
                    DemoDays = value;
                }
            }
        }
        public bool Remote
        {
            get
            {
                return remote;
            }
            set
            {
                if (value != remote)
                {
                    remote = value;
                }
            }
        }
        public string UserDesc
        {
            get
            {
                return UserDescription;
            }
            set
            {
                if (value != UserDescription)
                {
                    UserDescription = value;
                }
            }
        }
        public string CurrentFicode
        {
            get
            {
                return CurrFIcode;
            }
            set
            {
                if (value != CurrFIcode)
                {
                    CurrFIcode = value;
                }
            }
        }
        public string CurrentUserLev
        {
            get
            {
                return UserLev;
            }
            set
            {
                if (value != UserLev)
                {
                    UserLev = value;
                }
            }
        }
        public string CurrentBranchname
        {
            get
            {
                return CurrentBranch;
            }
            set
            {
                if (value != CurrentBranch)
                    CurrentBranch = value;
            }
        }

        public string CURRENT_COMPANY
        {
            get
            {
                return CURRENCOMP;
            }
            set
            {
                if (value != CURRENCOMP)
                {
                    CURRENCOMP = value;
                }
            }
        }
        public int CURRENTSESSION
        {
            get
            {
                return CURRENTSES;
            }
            set
            {
                if (value != CURRENTSES)
                {
                    CURRENTSES = value;
                }
            }
        }
        public string PCURRENT_GCODE
        {
            get
            {
                return CurrGco;
            }
            set
            {
                if (value != CurrGco)
                {
                    CurrGco = value;
                }
            }
        }
        public string PCURRENT_USER
        {
            get
            {
                return CurrentUser;
            }
            set
            {
                if (value != CurrentUser)
                {
                    CurrentUser = value;
                }
            }
        }
        public string PDATABASE_NAME
        {
            get
            {
                return DatabaseName;
            }
            set
            {
                if (value != DatabaseName)
                {
                    DatabaseName = value;
                }
            }
        }
        public string PDEVELOPER_NAME
        {
            get
            {
                return DeveloperName;
            }
            set
            {
                if (value != DeveloperName)
                {
                    DeveloperName = value;
                }
            }
        }
        public string PSERVER_NAME
        {
            get
            {
                return SvrName;
            }
            set
            {
                if (value != SvrName)
                {
                    SvrName = value;
                }
            }
        }
        public string PEXE_VERSION
        {
            get
            {
                return ExeVersion;
            }
            set
            {
                if (value != ExeVersion)
                {
                    ExeVersion = value;
                }
            }
        }
        public DateTime PBUILD_DATE
        {
            get
            {
                return BuildDate;
            }
            set
            {
                if (value != BuildDate)
                {
                    BuildDate = value;
                }
            }
        }
        public bool FirstTimeInstall
        {
            get
            {
                return firsttimeinstall;
            }
            set
            {
                if (value != firsttimeinstall)
                    firsttimeinstall = value;
            }
        }
        public int CurrentCurrcode
        {
            get
            {
                return CurrCode;
            }
            set
            {
                if (value != CurrCode)
                {
                    CurrCode = value;
                }
            }
        }
        public DateTime CURRCO_SDT
        {
            get
            {
                return CURCO_SDT;
            }
            set
            {
                if (value != CURCO_SDT)
                {
                    CURCO_SDT = value;
                }
            }
        }
        public DateTime CURRCO_EDT
        {
            get
            {
                return CURCO_EDT;
            }
            set
            {
                if (value != CURCO_EDT)
                {
                    CURCO_EDT = value;
                }
            }
        }

        public string NetWork_library
        {
            get
            {
                return NetLibrary;
            }
            set
            {
                if (value != NetLibrary)
                {
                    NetLibrary = value;
                }
            }
        }
        public string Integrated_Security
        {
            get
            {
                return Inte_Security;
            }
            set
            {
                if (value != Inte_Security)
                {
                    Inte_Security = value;
                }
            }
        }
        public string User_ID
        {
            get
            {
                return user_id;
            }
            set
            {
                if (value != user_id)
                {
                    user_id = value;
                }
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value != password)
                {
                    password = value;
                }
            }
        }
        public string Trusted_Conection
        {
            get
            {
                return Trusted_con;
            }
            set
            {
                if (value != Trusted_con)
                {
                    Trusted_con = value;
                }
            }
        }
        public string Conection_TimeOut
        {
            get
            {
                return connection_TOut;
            }
            set
            {
                if (value != connection_TOut)
                {
                    connection_TOut = value;
                }
            }
        }
        public bool Persist_Security_Info
        {
            get
            {
                return PSI;
            }
            set
            {
                if (value != PSI)
                {
                    PSI = value;
                }
            }
        }
        public string DataSourceExtention
        {
            get
            {
                return DSE;
            }
            set
            {
                if (value != DSE)
                {
                    DSE = value;
                }
            }
        }


        //------------------------Constructors & Methods
        public bool CheckInstalledCompany()// for first time insallation
        {
            try
            {
                string sqlstr = "select Count(*) as count from company";
                EDPConnection edpcon = new EDPConnection();
                edpcon.Open();
                mycmd = new SqlCommand(sqlstr, edpcon.mycon);
                mydr = mycmd.ExecuteReader();
                if (mydr.Read())
                {
                    if (mydr.GetInt32(0) == 0)
                    {
                        firsttimeinstall = true;
                        edpcon.Close();
                        return true;
                    }
                    else
                    {
                        firsttimeinstall = false;
                        edpcon.Close();
                        return false;
                    }
                }
                else
                {
                    firsttimeinstall = false;
                    edpcon.Close();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public string edpcrypt(string text, bool crtype) // Encryption technology
        {
            if (crtype)
            {
                string aa;
                string bb = "";
                int i;
                int j;
                int cc;
                i = text.Length;
                j = 1;
                while (j <= i)
                {
                    aa = text.Substring(j - 1, 1);
                    cc = Strings.Asc(aa);
                    bb = bb + cc + " ";
                    j++;
                }
                return bb;
            }
            else
            {
                string aa;
                string bb;
                string dd = "";
                string ff;
                string gg;
                int i;
                int j;
                int k;
                char ch;
                ff = text;
                j = 1;
                i = ff.Length;
                while (j <= i)
                {
                    aa = ff.Substring(j - 1, 1);
                    if (aa == " ")
                    {
                        bb = ff.Substring(0, j - 1);
                        k = bb.Length + 1;
                        ch = Strings.ChrW(int.Parse(bb));
                        dd = dd + ch;
                        gg = ff.Substring(j + 1 - 1);
                        ff = gg;
                        j = 0;
                        i = i - k;
                    }
                    j++;
                }
                return dd;
            }
        }
        public string getSqlDateStr(DateTime dtVal)
        {

            string TmpStr = " ";
            //string sday = dtVal.Day.ToString();
            //string smon = dtVal.Month.ToString();
            //string syear = dtVal.Year.ToString();
            //TmpStr = smon + "/" + sday + "/" + syear;
            TmpStr = dtVal.Date.ToString("MM/dd/yyyy");
            return TmpStr;
        }
        public void SetInRegistry(string Settext, string Headname, string path)//leave blank path name if default path name need
        {
            if (path == "")
                path = "HKEY_CURRENT_USER\\AccordFour";
            else
                path = "HKEY_CURRENT_USER\\" + path;
            (new Microsoft.VisualBasic.Devices.Computer()).Registry.SetValue(path, Headname, Settext);
        }
        public string GetFromRegisrty(string Headname, string path)//leave blank path name if default path name need
        {
            if (path == "")
                path = "HKEY_CURRENT_USER\\AccordFour";
            else
                path = "HKEY_CURRENT_USER\\" + path;
            return (string)((new Microsoft.VisualBasic.Devices.Computer()).Registry.GetValue(path, Headname, null));
        }
        public void CreateSubkey(string path)//registry subkey creation
        {
            path = "HKEY_CURRENT_USER\\" + path;
            (new Microsoft.VisualBasic.Devices.Computer()).Registry.CurrentUser.CreateSubKey(path);
        }
        public string readFromIni(string IniFilePath, string Section, string Key)
        {
            string path = IniFilePath;
            StringBuilder temp = new StringBuilder(30000);//255
            int i = GetPrivateProfileString(Section, Key, "", temp, 30000, path);//255
            return temp.ToString();
        }
        public void writeToIni(string IniFilePath, string Section, string Key, string Value)
        {
            string path = IniFilePath;
            try
            {
                if (System.IO.File.Exists(path) == false)
                {
                    System.IO.File.Create(path);
                }
                WritePrivateProfileString(Section, Key, Value, path);
            }
            catch
            { }
        }
        public bool CheckDb()
        {
            EDPConnection edpcon = new EDPConnection();
            edpcon.Open();
            mycmd = new SqlCommand(" select * from pasword", edpcon.mycon);
            try
            {
                mycmd.ExecuteReader();
                edpcon.Close();
                return true;
            }
            catch
            {
                edpcon.Close();
                return false;
            }
        }//check whether the database exsist or not
        /*public void saveFormPosition(string IniFilePath, string FormName, Point Location)
        {
                writeToIni(IniFilePath,FormName,"X",Location.X.ToString());
          writeToIni(IniFilePath,FormName,"Y",Location.Y.ToString());
        }
        public void setFormPosition(string  FormName)
        {
            try
          {
            int x = Convert.ToInt32(readFromIni(IniFilePath,FormName.Name,"X"));
            int y = Convert.ToInt32(readFromIni(IniFilePath,FormName.Name,"Y"));

            FormName.StartPosition = FormStartPosition.Manual;
            FormName.Location = new Point(x,y);
          }
          catch
          {
            FormName.StartPosition = FormStartPosition.CenterScreen;
          }

        }*/
        //------------------------------------------------------------------

        public Hashtable GetNumberOfDocNumber(Int64 Desccode, string Tentry)
        {
            try
            {
                Hashtable MultiDocNo = new Hashtable();
                EDPConnection edpcon = new EDPConnection();
                edpcon.Open();
                string docnumber = "";
                mycmd = new SqlCommand("select method from typedoc where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'", edpcon.mycon);
                mydr = mycmd.ExecuteReader();
                mydr.Read();
                if (mydr.GetString(0).Trim() == "A")
                {
                    mydr.Close();
                    mycmd = new SqlCommand("select * from docnumber where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'", edpcon.mycon);
                    mydr = mycmd.ExecuteReader();
                    mydr.Read();
                    string PREPOS = mydr.GetString(7);
                    string SUFPOS = mydr.GetString(8);
                    string padding = mydr.GetString(9);
                    string doc_pos = mydr.GetString(10);
                    string no_sep = mydr.GetString(11);
                    string prefix = mydr.GetString(12).Trim();
                    string suffix = mydr.GetString(13).Trim();
                    mydr.Close();
                    DataSet ds = new DataSet();
                    mycmd = new SqlCommand("select VOUCHERNO from docgen where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'", edpcon.mycon);
                    SqlDataAdapter dac = new SqlDataAdapter(mycmd);
                    dac.Fill(ds, "GetNo");
                    for (int k = 0; k <= ds.Tables["GetNo"].Rows.Count - 1; k++)
                    {
                        docnumber = ds.Tables["GetNo"].Rows[k][0].ToString();
                        mydr.Close();
                        string sep = "", num = ""; int i = 0;
                        Int64 newnum = 0;
                        for (i = 1; i <= Convert.ToInt16(no_sep); i++) sep = sep + "/";
                        newnum = Convert.ToInt64(docnumber) + 1;
                        string form = "";
                        for (i = 1; i <= (Convert.ToInt16(padding) - Convert.ToString(newnum).Length); i++) form = form + "0";
                        num = form + Convert.ToString(newnum);
                        switch (PREPOS.Trim())
                        {
                            case "1": if (SUFPOS.Trim() == "3") docnumber = prefix + sep + num + sep + suffix;
                                else if (SUFPOS.Trim() == "2") docnumber = prefix + sep + suffix + sep + num;
                                break;
                            case "2": if (SUFPOS.Trim() == "1") docnumber = suffix + sep + prefix + sep + num;
                                else if (SUFPOS.Trim() == "3") docnumber = num + sep + prefix + sep + suffix;
                                break;
                            case "3": if (SUFPOS.Trim() == "1") docnumber = suffix + sep + num + sep + prefix;
                                else if (SUFPOS.Trim() == "2") docnumber = num + sep + suffix + sep + prefix;
                                break;
                            default: docnumber = prefix + sep + num + sep + suffix;
                                break;
                        }
                        MultiDocNo.Add(k, docnumber);
                    }

                }
                else
                {
                    mydr.Close();
                    mycmd = new SqlCommand("select VOUCHERNO from docgen where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'", edpcon.mycon);
                    DataSet ds = new DataSet();
                    SqlDataAdapter dac = new SqlDataAdapter(mycmd);
                    dac.Fill(ds, "GetNo");
                    for (int i = 0; i <= ds.Tables["GetNo"].Rows.Count - 1; i++)
                    {
                        MultiDocNo.Add(i, ds.Tables["GetNo"].Rows[0][0].ToString());
                    }
                    //mydr = mycmd.ExecuteReader();
                    //mydr.Read();
                    //docnumber = mydr.GetString(0);
                }
                edpcon.Close();
                return MultiDocNo;
            }
            catch
            {
                return null;
            }
        }


        //generate document nymber for respective voucher
        //public string GetDocNumber(Int64 Desccode,string Tentry)
        //{
        //    try
        //    {
        //        EDPConnection edpcon = new EDPConnection();
        //        edpcon.Open();
        //        string docnumber = "";
        //        mycmd = new SqlCommand("select method from typedoc where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'", edpcon.mycon);
        //        mydr = mycmd.ExecuteReader();
        //        mydr.Read();
        //        if (mydr.GetString(0).Trim() == "A")
        //        {
        //            mydr.Close();
        //            mycmd = new SqlCommand("select * from docnumber where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'", edpcon.mycon);
        //            mydr = mycmd.ExecuteReader();
        //            mydr.Read();
        //            string PREPOS = mydr.GetString(7);
        //            string SUFPOS = mydr.GetString(8);
        //            string padding = mydr.GetString(9);
        //            string doc_pos = mydr.GetString(10);
        //            string no_sep = mydr.GetString(11);
        //            string prefix = mydr.GetString(12).Trim();
        //            string suffix = mydr.GetString(13).Trim();
        //            mydr.Close();
        //            mycmd = new SqlCommand("select * from docgen where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "' and State='RUNNING'", edpcon.mycon);
        //            mydr = mycmd.ExecuteReader();
        //            mydr.Read();
        //            docnumber = mydr.GetValue(4).ToString();                 
        //            mydr.Close();
        //            string sep="",num=""; int i = 0;
        //            Int64 newnum =0;
        //            for (i = 1; i <= Convert.ToInt16(no_sep); i++) sep = sep + "/";
        //            newnum = Convert.ToInt64(docnumber) + 1;
        //            string form = "";
        //            for (i = 1; i <= (Convert.ToInt16(padding) - Convert.ToString(newnum).Length); i++) form = form + "0";
        //            num = form + Convert.ToString(newnum);
        //            switch (PREPOS.Trim())
        //            {
        //                case "1": if (SUFPOS.Trim() == "3") docnumber = prefix + sep + num + sep + suffix;
        //                    else if (SUFPOS.Trim() == "2") docnumber = prefix + sep + suffix + sep + num;
        //                    break;
        //                case "2": if (SUFPOS.Trim() == "1") docnumber = suffix + sep + prefix + sep + num;
        //                    else if (SUFPOS.Trim() == "3") docnumber = num + sep + prefix + sep + suffix;
        //                    break;
        //                case "3": if (SUFPOS.Trim() == "1") docnumber = suffix + sep + num + sep + prefix;
        //                    else if (SUFPOS.Trim() == "2") docnumber = num + sep + suffix + sep + prefix;
        //                    break;
        //                default: docnumber = prefix + sep + num + sep + suffix;
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            mydr.Close();
        //            mycmd = new SqlCommand("select VOUCHERNO from docgen where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'", edpcon.mycon);
        //            mydr = mycmd.ExecuteReader();
        //            mydr.Read();
        //            docnumber = mydr.GetString(0);
        //        }
        //        edpcon.Close();
        //        return docnumber;
        //    }
        //    catch 
        //    {
        //        return null;
        //    }
        //}

        public string GetDocNumber(Int64 Desccode, string Tentry)
        {
            try
            {
                EDPConnection edpcon = new EDPConnection();
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                edpcon.Open();
                string docnumber = "";
                int doc_vchlock = 0, docno = 0, vch_lock = 0;
                Boolean flag_pending = false, flug_dublicate = false;
                ClearDataTable_EDP(ds.Tables["Status"]);
                mycmd = new SqlCommand("select min(Voucher) from vchlock where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and Des_Code='" + Desccode + "' and t_entry='" + Tentry + "' and (Status='PENDING' or Status='RUNNING')  and USERCODE=" + PCURRENT_USER + " ", edpcon.mycon);
                SqlDataAdapter da = new SqlDataAdapter(mycmd);
                da.Fill(ds, "Status");
                if (ds.Tables["Status"].Rows.Count > 0)
                    if (Information.IsNumeric(ds.Tables["Status"].Rows[0][0]) == true)
                    {
                        vch_lock = Convert.ToInt32(ds.Tables["Status"].Rows[0][0]) - 1;
                        flag_pending = true;
                    }
                ClearDataTable_EDP(ds.Tables["Status1"]);
                //mycmd = new SqlCommand("select max(Voucher) from vchlock where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and Des_Code='" + Desccode + "' and t_entry='" + Tentry + "' and (Status='PENDING' or Status='RUNNING')  and USERCODE=" + PCURRENT_USER + " ", edpcon.mycon);
                mycmd = new SqlCommand("select min(Voucher) from vchlock where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and Des_Code='" + Desccode + "' and t_entry='" + Tentry + "' and Status='PENDING' ", edpcon.mycon);
                SqlDataAdapter da1 = new SqlDataAdapter(mycmd);
                da1.Fill(ds, "Status1");
                if (ds.Tables["Status1"].Rows.Count > 0)
                    if (Information.IsNumeric(ds.Tables["Status1"].Rows[0][0]) == true)
                    {
                        vch_lock = Convert.ToInt32(ds.Tables["Status1"].Rows[0][0]) - 1;
                        flag_pending = true;
                    }
                mycmd = new SqlCommand("select max(Voucher) from vchlock where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and Des_Code='" + Desccode + "' and t_entry='" + Tentry + "' ", edpcon.mycon);
                SqlDataAdapter dac = new SqlDataAdapter(mycmd);
                dac.Fill(ds, "doc_no");

                if (ds.Tables["doc_no"].Rows.Count > 0)
                {
                    if (Information.IsNumeric(ds.Tables["doc_no"].Rows[0][0]) == true)
                        doc_vchlock = Convert.ToInt32(ds.Tables["doc_no"].Rows[0][0]);
                }

                mycmd = new SqlCommand("select method from typedoc where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'", edpcon.mycon);
                mydr = mycmd.ExecuteReader();
                mydr.Read();
                if (mydr.GetString(0).Trim() == "A")
                {
                    mydr.Close();
                    mycmd = new SqlCommand("select * from docnumber where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'", edpcon.mycon);
                    mydr = mycmd.ExecuteReader();
                    mydr.Read();
                    string PREPOS = mydr.GetString(7);
                    string SUFPOS = mydr.GetString(8);
                    string padding = mydr.GetString(9);
                    string doc_pos = mydr.GetString(10);
                    string no_sep = mydr.GetString(11);
                    string prefix = mydr.GetString(12).Trim();
                    string suffix = mydr.GetString(13).Trim();
                    mydr.Close();
                    mycmd = new SqlCommand("select * from docgen where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "' and State='RUNNING'", edpcon.mycon);
                    mydr = mycmd.ExecuteReader();
                    mydr.Read();
                    docnumber = mydr.GetValue(4).ToString();
                    mydr.Close();
                    //if (Convert.ToInt64(docnumber) < doc_vchlock)
                    //    docnumber = doc_vchlock.ToString();
                    //if (flag_pending == true)
                    //{
                    //    docnumber = vch_lock.ToString();
                    //}
                    if (doc_vchlock != 0)
                    {
                        if (Convert.ToInt64(docnumber) > doc_vchlock)
                        {
                            docnumber = doc_vchlock.ToString();
                            flug_dublicate = true;
                        }
                        else
                        {
                            if (flag_pending == false)
                                docnumber = Convert.ToString(Convert.ToInt32(docnumber) + 1);
                            ClearDataTable_EDP(ds.Tables["doc_no1"]);
                            mycmd = new SqlCommand("select voucher from vchlock where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and Des_Code='" + Desccode + "' and t_entry='" + Tentry + "'and voucher='" + docnumber + "' and Status='PENDING'", edpcon.mycon);
                            SqlDataAdapter dac1 = new SqlDataAdapter(mycmd);
                            dac1.Fill(ds, "doc_no1");
                            if (ds.Tables["doc_no1"].Rows.Count > 0)
                                docnumber = doc_vchlock.ToString();
                        }
                    }
                    if (vch_lock != 0)
                    {
                        if (flag_pending == true)
                        {
                            if (Convert.ToInt64(docnumber) > vch_lock)
                            {
                                docnumber = vch_lock.ToString();
                                flug_dublicate = true;
                            }
                            else
                            {
                                ClearDataTable_EDP(ds.Tables["doc_no2"]);
                                mycmd = new SqlCommand("select voucher from vchlock where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and Des_Code='" + Desccode + "' and t_entry='" + Tentry + "'and voucher='" + docnumber + "' and Status='PENDING' ", edpcon.mycon);
                                SqlDataAdapter dac2 = new SqlDataAdapter(mycmd);
                                dac2.Fill(ds, "doc_no2");
                                if (ds.Tables["doc_no2"].Rows.Count > 0)
                                    docnumber = doc_vchlock.ToString();
                            }
                        }
                    }
                    docno = Convert.ToInt32(docnumber);

                    string sep = "", num = ""; int i = 0;
                    Int64 newnum = 0;
                    for (i = 1; i <= Convert.ToInt16(no_sep); i++) sep = sep + "/";
                    newnum = Convert.ToInt64(docnumber) + 1;
                    string form = "";
                    for (i = 1; i <= (Convert.ToInt16(padding) - Convert.ToString(newnum).Length); i++) form = form + "0";
                    num = form + Convert.ToString(newnum);
                    switch (PREPOS.Trim())
                    {
                        case "1": if (SUFPOS.Trim() == "3") docnumber = prefix + sep + num + sep + suffix;
                            else if (SUFPOS.Trim() == "2") docnumber = prefix + sep + suffix + sep + num;
                            break;
                        case "2": if (SUFPOS.Trim() == "1") docnumber = suffix + sep + prefix + sep + num;
                            else if (SUFPOS.Trim() == "3") docnumber = num + sep + prefix + sep + suffix;
                            break;
                        case "3": if (SUFPOS.Trim() == "1") docnumber = suffix + sep + num + sep + prefix;
                            else if (SUFPOS.Trim() == "2") docnumber = num + sep + suffix + sep + prefix;
                            break;
                        default: docnumber = prefix + sep + num + sep + suffix;
                            break;
                    }
                    //if (Tentry != "1" && Tentry != "2" && Tentry != "3" && Tentry != "4" && Tentry != "5" && Tentry != "6" && Tentry != "7")
                    //{


                    //string dublicate = "";
                    //if (flug_dublicate == false)
                    //{
                    //    docno = docno + 1;
                    //    dublicate = GetresultS("select voucher from idata  where ficode=" + CurrentFicode + " and gcode=" + PCURRENT_GCODE + " and  t_entry='" + Tentry + "'and DESCCODE='" + Desccode + "' and user_vch='" + docnumber + "'");
                    //    if (dublicate != null)
                    //    {
                    //        if (dublicate != "")
                    //        {
                    //            RunCommand("update docgen set Voucherno=" + docno + " where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and t_entry='" + Tentry + "' and DESCCODE='" + Desccode + "' and state='RUNNING'");
                    //            flag_pending = false;
                    //            flug_dublicate = false;
                    //            blockdublicatevoucher(Desccode, Tentry);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    docno = docno + 1;
                    //    dublicate = GetresultS("select voucher from idata  where ficode=" + CurrentFicode + " and gcode=" + PCURRENT_GCODE + " and  t_entry='" + Tentry + "'and DESCCODE='" + Desccode + "' and user_vch='" + docnumber + "'");
                    //    if (dublicate != null)
                    //    {
                    //        if (dublicate != "")
                    //        {
                    //            RunCommand("delete from vchlock where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "'and t_entry ='" + Tentry + "' and voucher=" + docno + " and user_vch='" + docnumber + "'  and Trans_Type='ADD' and Des_Code='" + Desccode + "'");
                    //            flag_pending = false;
                    //            flug_dublicate = false;
                    //            blockdublicatevoucher(Desccode, Tentry);
                    //        }
                    //    }
                    //}
                    if (flag_pending == false)
                    {
                        docno = docno + 1;
                        cmd = new SqlCommand("insert into vchlock(Ficode,GCODE,VTYPE,T_ENTRY,VOUCHER,USER_VCH,USERCODE,Trans_Type,Cancel_Flag,Computer_Name,Status,Des_Code) VALUES(" +
                            " '" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "','" + Tentry + "'," + docno + ",'" + docnumber + "'," + PCURRENT_USER + ",'ADD','0','" + PSERVER_NAME + "','RUNNING','" + Desccode + "')", edpcon.mycon);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        docno = docno + 1;
                        cmd = new SqlCommand("update vchlock set Status='RUNNING',USERCODE=" + PCURRENT_USER + " where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and t_entry ='" + Tentry + "' and voucher=" + docno + " and user_vch='" + docnumber + "'  and Trans_Type='ADD' and Des_Code='" + Desccode + "'", edpcon.mycon);
                        cmd.ExecuteNonQuery();
                    }
                    flag_pending = false;
                    //}
                }
                else
                {
                    mydr.Close();
                    mycmd = new SqlCommand("select VOUCHERNO from docgen where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'", edpcon.mycon);
                    mydr = mycmd.ExecuteReader();
                    mydr.Read();
                    docnumber = mydr.GetString(0);
                }
                edpcon.Close();
                return docnumber;
            }
            catch
            {
                return null;
            }
        }

        public void blockdublicatevoucher(Int64 Desccode, string Tentry)
        {
            GetDocNumber(Desccode, Tentry);
        }
        public void Autobackup()
        {
            EDPConnection edpcon = new EDPConnection();
            try
            {
                writeToIni(Application.StartupPath + "\\Settings.edp", "BACK_UP", "FLAG", "FALSE");
                string backuppath = Convert.ToString(GetFromRegisrty("PATH_", "SOFTWARE\\DATAPATH_"));
                try
                {
                    if (backuppath == null)
                    {
                        backuppath = Environment.CurrentDirectory;                        
                    }
                    if (backuppath == "")
                    {
                        backuppath = Environment.CurrentDirectory;                      
                    }
                    if (backuppath == Environment.CurrentDirectory)
                        backuppath = backuppath.Substring(0, 2) + "\\Backup";
                }
                catch { }
                //string backuppath = Environment.CurrentDirectory;
                //backuppath = backuppath.Substring(0, 2) + "\\Backup";
                if (!Microsoft.VisualBasic.FileIO.FileSystem.DirectoryExists(backuppath))
                    Microsoft.VisualBasic.FileIO.FileSystem.CreateDirectory(backuppath);
                string path = backuppath + "\\" + DateAndTime.Now.ToString("MMddyyyyhhmmss") + "." + ApplicationExtension;
                edpcon.Open();
                mycmd = new SqlCommand("backup database " + PDATABASE_NAME + " to disk='" + path + " '", edpcon.mycon);
                mycmd.ExecuteNonQuery();
                edpcon.Close();

                string zipFileName = path + ".zip";
                try
                {                    
                    using (FileStream __fStream = File.Open(zipFileName, FileMode.Create))
                    {
                        GZipStream obj = new GZipStream(__fStream, CompressionMode.Compress);
                        byte[] bt = File.ReadAllBytes(path);
                        obj.Write(bt, 0, bt.Length);
                        obj.Close();
                        obj.Dispose();
                    }
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(path);
                }
                catch { }

                long File_Size = 0, File_Size_Previous = 0;

                try
                {
                    File_Size_Previous = Convert.ToInt64(readFromIni(Application.StartupPath + "\\Settings.edp", "BACK_UP", "FILE_SIZE"));
                }
                catch { }

                try
                {                    
                    File_Size = Microsoft.VisualBasic.FileSystem.FileLen(zipFileName);
                    if (File_Size > 0)
                    {
                        File_Size = File_Size / 1024;
                        File_Size = Convert.ToInt64(Math.Round(Convert.ToDouble(File_Size)));
                    }
                }
                catch { }

                if (File_Size_Previous > File_Size)
                    EDPMessageBox.EDPMessage.Show("Previous Backup Size is " + File_Size_Previous.ToString() + " KB and new Backup size is " + File_Size.ToString() + " KB" + "\r\n" + "Please check and verified.", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);

                writeToIni(Application.StartupPath + "\\Settings.edp", "BACK_UP", "FLAG", "TRUE");
                writeToIni(Application.StartupPath + "\\Settings.edp", "BACK_UP", "FILE_SIZE", File_Size.ToString());
                EDPMessageBox.EDPMessage.Show("Back Up Successful!" + "\r\n" + "Path : - " + path + "", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
            }
            catch(Exception ex)
            {
                edpcon.Close();
                EDPMessage.Show(ex.Message + "\n Auto Backup process can not be generate.", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_ERROR);
            }
        }

        //public void Autobackup()
        //{
        //    EDPConnection edpcon = new EDPConnection();
        //    try
        //    {
        //        string backuppath = Environment.CurrentDirectory;
        //        // string backuppath = txtDatabasePath.Text;
        //        // txtDatabasePath.Text = dbpath;
        //        backuppath = backuppath.Substring(0, 2) + "\\Backup";
        //        //if(EDPComm.Remote)
        //        //backuppath = serverName + "\\" + backuppath;
        //        if (!Microsoft.VisualBasic.FileIO.FileSystem.DirectoryExists(backuppath))
        //            Microsoft.VisualBasic.FileIO.FileSystem.CreateDirectory(backuppath);
        //        string path = backuppath + "\\" + DateAndTime.Now.ToString("MMddyyyyhhmmss") + "." + ApplicationExtension;
        //        edpcon.Open();
        //        mycmd = new SqlCommand("backup database " + PDATABASE_NAME + " to disk='" + path + " '", edpcon.mycon);
        //        mycmd.ExecuteNonQuery();
        //        edpcon.Close();
        //        string zipFileName = path + "z";
        //        try
        //        {
        //            java.io.FileOutputStream foss = new java.io.FileOutputStream(zipFileName);
        //            java.util.zip.ZipOutputStream zoss = new java.util.zip.ZipOutputStream(foss);
        //        }
        //        catch { MessageBox.Show("Auto Back up Can't be genereted because JSHARP is not install."); }
        //        java.io.FileOutputStream fos = new java.io.FileOutputStream(zipFileName);
        //        java.util.zip.ZipOutputStream zos = new java.util.zip.ZipOutputStream(fos);
        //        string sourceFile = path;
        //        java.io.FileInputStream fis = new java.io.FileInputStream(sourceFile);
        //        // File name format in zip file is:
        //        // folder/subfolder/filename
        //        // Let's delete drive name and replace '\' with '/':
        //        string file = sourceFile.Substring(3).Replace('\\', '/');
        //        string[] format = file.Split('/');
        //        file = format[format.Length - 1];
        //        java.util.zip.ZipEntry ze = new java.util.zip.ZipEntry(file);
        //        zos.putNextEntry(ze);
        //        sbyte[] buffer = new sbyte[1024];
        //        int len;
        //        while ((len = fis.read(buffer)) >= 0)
        //        {
        //            zos.write(buffer, 0, len);
        //        }
        //        zos.closeEntry();
        //        fis.close();
        //        zos.close();
        //        fos.close();
        //        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(path);
        //        EDPMessageBox.EDPMessage.Show("Back Up Successful! Path:" + path + "");
        //    }
        //    catch (Exception ex)
        //    {
        //        edpcon.Close();
        //        EDPMessage.Show(ex.Message + "\n Auto Backup process can not be generate.", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_OK);
        //    }
        //}

        //public void UpdateDocNumber(Int64 Desccode, string Tentry, int vouno)
        //{
        //    try
        //    {
        //        EDPConnection con = new EDPConnection();
        //        con.Open();
        //        //=========================                
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        int no = vouno - 1;
        //        EDPCommon.ClearDataTable_EDP(ds.Tables["VNO"]);
        //        SqlCommand cmd = new SqlCommand("select * from DOCGEN where FICode='" + CurrentFicode + "' And GCode='" + PCURRENT_GCODE + "' And T_ENTRY='" + Tentry + "' And DESCCODE=" + Desccode + " And VOUCHERNO=" + no + "", con.mycon);
        //        da.SelectCommand = cmd;
        //        da.Fill(ds, "VNO");
        //        if (ds.Tables["VNO"].Rows.Count > 0)
        //        {
        //        }
        //        else
        //        {
        //            try
        //            {
        //                no = no + 1;

        //                cmd = new SqlCommand("insert into DOCGEN(Ficode,GCODE,T_ENTRY,DESCCODE,VOUCHERNO,State,User_Code) Values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + Desccode + "," + no + ",'RUNNING','" + UserDesc + "')", con.mycon);
        //                cmd.ExecuteNonQuery();
        //            }
        //            catch { }
        //        }
        //        //=========================                
        //        SqlDataReader mydr;
        //        mycmd = new SqlCommand("select voucherno from docgen where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "' And State='RUNNING'", con.mycon);
        //        mydr = mycmd.ExecuteReader();
        //        mydr.Read();
        //        int ss = Convert.ToInt32(mydr.GetString(0).Trim());
        //        mydr.Close();
        //        if (vouno >= ss)
        //        {
        //            //Change S.Dutta(14.01.13)
        //            string docnumber = Convert.ToString(vouno);
        //            //string docnumber = Convert.ToString(Convert.ToInt64(ss) + 1);
        //            //End 14.01.13
        //            cmd = new SqlCommand("delete from DOCGEN where voucherno='" + docnumber + "' and ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "' ", con.mycon);
        //            cmd.ExecuteNonQuery();
        //            string command = "update docgen set voucherno='" + docnumber + "' where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "' And State='RUNNING'";
        //            SqlCommand com = new SqlCommand(command, con.mycon);
        //            com.ExecuteNonQuery();
        //        }
        //        con.Close();
        //    }
        //    catch { }
        //}

        public void UpdateDocNumber(Int64 Desccode, string Tentry, int vouno)
        {
            try
            {
                EDPConnection con = new EDPConnection();
                con.Open();
                //=========================                
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                int no = vouno - 1;
                EDPCommon.ClearDataTable_EDP(ds.Tables["VNO"]);
                SqlCommand cmd = new SqlCommand("select * from DOCGEN where FICode='" + CurrentFicode + "' And GCode='" + PCURRENT_GCODE + "' And T_ENTRY='" + Tentry + "' And DESCCODE=" + Desccode + " And VOUCHERNO=" + no + "", con.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "VNO");
                if (ds.Tables["VNO"].Rows.Count > 0)
                {
                }
                else
                {
                    try
                    {
                        no = no + 1;

                        cmd = new SqlCommand("insert into DOCGEN(Ficode,GCODE,T_ENTRY,DESCCODE,VOUCHERNO,State,User_Code) Values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + Desccode + "," + no + ",'RUNNING','" + User_ID + "')", con.mycon);
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                }
                //=========================                
                SqlDataReader mydr;
                mycmd = new SqlCommand("select voucherno from docgen where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "' And State='RUNNING'", con.mycon);
                mydr = mycmd.ExecuteReader();
                mydr.Read();
                int ss = Convert.ToInt32(mydr.GetString(0).Trim());
                mydr.Close();
                if (vouno >= ss)
                {
                    //Change S.Dutta(14.01.13)
                    string docnumber = Convert.ToString(vouno);
                    //string docnumber = Convert.ToString(Convert.ToInt64(ss) + 1);
                    //End 14.01.13

                    EDPCommon.ClearDataTable_EDP(ds.Tables["dogno"]);
                    cmd = new SqlCommand("select * from DOCGEN where FICode='" + CurrentFicode + "' And GCode='" + PCURRENT_GCODE + "' And T_ENTRY='" + Tentry + "' And DESCCODE=" + Desccode + " And VOUCHERNO <>" + docnumber + "", con.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "dogno");
                    if (ds.Tables["dogno"].Rows.Count > 0)
                    {
                        cmd = new SqlCommand("delete from DOCGEN where voucherno='" + docnumber + "' and ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "' ", con.mycon);
                        cmd.ExecuteNonQuery();
                        string command = "update docgen set voucherno='" + docnumber + "' where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "' And State='RUNNING'";
                        SqlCommand com = new SqlCommand(command, con.mycon);
                        com.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new SqlCommand("delete from DOCGEN where voucherno='" + docnumber + "' and ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "' ", con.mycon);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("insert into DOCGEN(Ficode,GCODE,T_ENTRY,DESCCODE,VOUCHERNO,State,User_Code) Values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + Desccode + "," + docnumber + ",'RUNNING','" + User_ID + "')", con.mycon);
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
            catch { }
        }

        public void UpdateDocNumber(Int64 Desccode, string Tentry)
        {
            try
            {
                EDPConnection con = new EDPConnection();
                con.Open();
                SqlDataReader mydr;
                mycmd = new SqlCommand("select voucherno from docgen where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'", con.mycon);
                mydr = mycmd.ExecuteReader();
                mydr.Read();
                string docnumber = mydr.GetString(0).Trim();
                mydr.Close();
                docnumber = Convert.ToString(Convert.ToInt64(docnumber) + 1);
                string command = "update docgen set voucherno='" + docnumber + "' where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'";
                SqlCommand com = new SqlCommand(command, con.mycon);
                com.ExecuteNonQuery();
            }
            catch { }
        }
        /// <summary>
        /// check whether the any decription type created or not
        /// </summary>
        /// <param name="Tentry"></param>
        /// <returns></returns>
        public bool ChkDocType(string Tentry)
        {
            EDPConnection edpcon = new EDPConnection();
            edpcon.Open();
            mycmd = new SqlCommand("select * from typedoc where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and t_entry='" + Tentry + "'", edpcon.mycon);
            mydr = mycmd.ExecuteReader();
            if (mydr.Read())
            {
                edpcon.Close();
                return true;
            }
            else
            {
                edpcon.Close();
                return false;
            }
        }
        /// <summary>
        /// make the  given form movable.label should be the head label and the respective form as parameter.
        /// </summary>
        /// <param name="MoveWith"></param>
        /// <param name="ToMove"></param>
        public void MaketheformMovable(Label MoveWith, Form ToMove)
        {
            MoveForm = ToMove;
            MoveWith.MouseDown += Title_MouseDown;
            MoveWith.MouseMove += Title_MouseMove;
            MoveWith.MouseUp += Title_MouseUp;
        }
        //overloading
        /// <summary>
        /// make the  given form movable.picturebox should be the head picturebox and the respective form as parameter.
        /// </summary>
        /// <param name="MoveWith"></param>
        /// <param name="ToMove"></param>
        public void MaketheformMovable(PictureBox MoveWith, Form ToMove)
        {
            MoveForm = ToMove;
            MoveWith.MouseDown += Title_MouseDown;
            MoveWith.MouseMove += Title_MouseMove;
            MoveWith.MouseUp += Title_MouseUp;
        }
        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.Cursor = Cursors.SizeAll;
                Hold = new Point(e.X, e.Y);
            }
        }
        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            MoveForm.SuspendLayout();
            if (e.Button == MouseButtons.Left)
            {

            }
            MoveForm.ResumeLayout();
        }
        private void Title_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.Left += e.X - Hold.X;
                MoveForm.Top += e.Y - Hold.Y;
                MoveForm.Cursor = Cursors.Default;
                Screen.FromControl(MoveForm);
            }

        }
        public void AutoDocTypeCreate(string Tentry)
        {
            EDPConnection edpcon = new EDPConnection();
            SqlTransaction Tran;
            edpcon.Open();
            Tran = edpcon.mycon.BeginTransaction();
            string prefix = "", suffix = "", Type = "", command = "";
            Int32 code;
            try
            {
                prefix = GetresultS("select tran_head from typemast where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and t_entry='" + Tentry + "'");
                suffix = GetresultS("select Start_Date from ficodegen where ficode='" + CurrentFicode + "'").Substring(8, 2) + "-" + GetresultS("select End_Date from ficodegen where ficode='" + CurrentFicode + "'").Substring(8, 2);
                Type = GetresultS("select typename from typemast where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and t_entry='" + Tentry + "'");
                if (GetresultS("select desccode from docnumber where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and t_entry='" + Tentry + "'") != null)
                    code = Convert.ToInt32(GetresultS("select desccode from docnumber where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and t_entry='" + Tentry + "'")) + 1;
                else code = 1;
                if ((Tentry.Trim() == "S") || (Tentry.Trim() == "8") || (Tentry.Trim() == "9") || (Tentry.Trim() == "C") || (Tentry.Trim() == "SR") || (Tentry.Trim() == "PR"))
                    command = "insert into typedoc(FICode, GCODE, T_ENTRY, Desccode, Type_Desc, Specific_Acc, METHOD, Effect_Amt, Req_Acc,User_Code) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'" + Type + "',0, 'A',null,0,'" + PCURRENT_USER + "')";
                else if (Tentry.Trim() == "M")
                    command = "insert into typedoc(FICode, GCODE, T_ENTRY, Desccode, Type_Desc, Specific_Acc, METHOD, Effect_Amt, Req_Acc,User_Code) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'" + Type + "',0, 'A',null,0,'" + PCURRENT_USER + "')";
                else
                    command = "insert into typedoc(FICode, GCODE, T_ENTRY, Desccode, Type_Desc, Specific_Acc, METHOD, Effect_Amt, Req_Acc,User_Code) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'" + Type + "',0, 'A',null,0,'" + PCURRENT_USER + "')";
                SqlCommand mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                mycmd.ExecuteNonQuery();
                switch (Tentry.Trim())
                {
                    case "OP":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1001','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1005','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1008','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        //command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1023','False', 'False','False')";
                        //mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        //mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1024','True', 'False','Stander')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1025','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1026','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1033','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1036','False', 'False','Sales Order')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        break;
                    case "8":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1003','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1005','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1008','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1012','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1022','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1028','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1029','False', 'False','No')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1032','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1033','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1034','False', 'False','ST,EC,HEC')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1036','False', 'False','Purchase Order')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        break;
                    case "PR":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1003','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1005','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1008','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1022','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1028','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1033','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "a":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1005','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1008','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                                               
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1024','True', 'False','Stander')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1025','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1026','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1031','False', 'False','Purchase Challan')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();          
                        break;

                    case "PI":

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1024','True', 'False','Stander')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "9":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1003','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1004','True', 'False','Dos full Page Invoice')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1005','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1008','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1011','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1012','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1013','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1020','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1021','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1022','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1027','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1028','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1029','False', 'False','No')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1031','False', 'False','Tax Invoice')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1032','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1033','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1034','False', 'False','ST,EC,HEC')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1036','False', 'False','Sales Order')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        break;

                    case "SR":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1003','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1004','True', 'False','Dos full Page Invoice')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1005','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1008','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1022','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        //command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1027','False', 'False','False')";
                        //mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        //mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1028','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1033','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "n":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1031','False', 'False','Sales Challan')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "OS":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1001','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1033','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "1":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1010','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1014','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1015','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "2":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1010','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1014','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1015','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1016','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "3":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1010','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1015','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "5":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1010','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1015','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "6":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "7":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1010','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1015','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "4":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1010','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1015','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "LT":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "PN":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "FG":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1036','False', 'False','Production Order')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "GR":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1036','False', 'False','Production Order')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "MI":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1036','False', 'False','Production Order')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "MR":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1036','False', 'False','Production Order')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "NI":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1036','False', 'False','Production Order')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "NM":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1036','False', 'False','Production Order')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "SI":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "SO":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;
                }
                //end 01.10.12

                command = "insert into docnumber(FICode, GCODE, T_ENTRY, TYPE_NAME, DESCCODE, TYPE_DESC, METHOD, PREPOS, SUFPOS, padding, doc_pos, no_sep, prefix, suffix,User_Code) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "','" + Type + "'," + code + ",'" + Type + "D','A','1','2','4','2','1','" + prefix + "','" + suffix + "','" + PCURRENT_USER + "')";
                mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                mycmd.ExecuteNonQuery();

                command = "insert into docgen values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'0','RUNNING','" + PCURRENT_USER + "')";
                mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                mycmd.ExecuteNonQuery();
                //Auto Account Posting for sale ,purchase and Short sale
                //if ((Tentry.Trim() == "S") || (Tentry.Trim() == "8") || (Tentry.Trim() == "9") || (Tentry.Trim() == "C") || (Tentry.Trim() == "M"))
                //{
                //    DataSet ds = new DataSet();
                //    ArrayList glcode=new ArrayList();
                //    glcode.Add(5); glcode.Add(8); glcode.Add(9); glcode.Add(10); glcode.Add(13); glcode.Add(20); glcode.Add(21); glcode.Add(22); glcode.Add(23);
                //    string ttype = "", PlusMinus = "";
                //    if ((Tentry.Trim() == "S") || (Tentry.Trim() == "9"))
                //        ttype = "S";
                //    else ttype = "P";
                //    command = "select Description from BillTerms where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and TERMSTYPE='" + ttype + "'";
                //    mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                //    SqlDataAdapter da = new SqlDataAdapter(mycmd);
                //    da.Fill(ds, "billterms");
                //    string form = "", Effect = "";
                //    for (int i = 1; i <= ds.Tables["billterms"].Rows.Count; i++)
                //    {
                //        if (i == 1 || i == 2 || i == 3)
                //        {
                //            if (i == 1)
                //            {
                //                PlusMinus = "Plus";
                //                Effect = "1";
                //            }
                //            else
                //            {
                //                Effect = "0";
                //                if ((Tentry.Trim() == "S") || (Tentry.Trim() == "9"))
                //                    PlusMinus = "Minus";
                //                else PlusMinus = "Plus";
                //            }
                //        }
                //        else
                //        {
                //            if (i == 8 || i == 9)
                //            {
                //                Effect = "1";
                //            }
                //            else
                //            {
                //                Effect = "0";
                //            }
                //            if ((Tentry.Trim() == "S") || (Tentry.Trim() == "9"))
                //                PlusMinus = "Minus";
                //            else PlusMinus = "Plus";
                //        }
                //        command = "insert into accpost(FICode, GCODE, T_ENTRY, DESCCODE, Sl_No, BTerms_Desc, Term_Type, Tax, Glcode, Formula, PlusMinus, Type_Code, EffectAmt) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'" + i.ToString() + "','" + ds.Tables["billterms"].Rows[i - 1][0] + "','" + ttype + "',null," + glcode[i-1] + ",'" + form + "','" + PlusMinus + "',1," + Effect+")";
                //        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                //        mycmd.ExecuteNonQuery();
                //        if (i == 1)
                //        {
                //            form = form + i.ToString();
                //        }
                //        else
                //        {
                //            form = form + "+" + i.ToString();
                //        }
                //    }
                //}
                //else if ((Tentry.Trim() == "M"))
                //{
                //    DataSet ds = new DataSet();
                //    ArrayList glcode = new ArrayList();


                //    glcode.Add(8); glcode.Add(9); glcode.Add(10); glcode.Add(13); glcode.Add(20); glcode.Add(21); glcode.Add(22); glcode.Add(23); //glcode.Add(43);



                //    string ttype = "P", PlusMinus = "Plus";
                //    command = "select Description from BillTerms where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and TERMSTYPE='" + ttype + "'";
                //    mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                //    SqlDataAdapter da = new SqlDataAdapter(mycmd);
                //    da.Fill(ds, "billterms");
                //    string form = "", Effect = "";
                //    Effect = "1";
                //    command = "insert into accpost(FICode, GCODE, T_ENTRY, DESCCODE, Sl_No, BTerms_Desc, Term_Type, Tax, Glcode, Formula, PlusMinus, Type_Code, EffectAmt) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1','" + ds.Tables["billterms"].Rows[0][0] + "','" + ttype + "',null," + glcode[0] + ",'" + form + "','" + PlusMinus + "',1," + Effect + ")";
                //    mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                //    mycmd.ExecuteNonQuery();


                //}
                Tran.Commit();
            }
            catch
            {
                Tran.Rollback();
            }
        }

        public void AutoDocTypeCreate(string FIC, string GC, string Tentry, string Current_Super_User)
        {
            EDPConnection edpcon = new EDPConnection();
            SqlTransaction Tran;
            edpcon.Open();
            Tran = edpcon.mycon.BeginTransaction();
            string prefix = "", suffix = "", Type = "", command = "";
            Int32 code;
            try
            {
                prefix = GetresultS("select tran_head from typemast where ficode='" + FIC + "' and gcode='" + GC + "' and t_entry='" + Tentry + "'");
                suffix = GetresultS("select Start_Date from ficodegen where ficode='" + FIC + "'").Substring(8, 2) + "-" + GetresultS("select End_Date from ficodegen where ficode='" + FIC + "'").Substring(8, 2);
                Type = GetresultS("select typename from typemast where ficode='" + FIC + "' and gcode='" + GC + "' and t_entry='" + Tentry + "'");
                if (GetresultS("select desccode from docnumber where ficode='" + FIC + "' and gcode='" + GC + "' and t_entry='" + Tentry + "'") != null)
                    code = Convert.ToInt32(GetresultS("select desccode from docnumber where ficode='" + FIC + "' and gcode='" + GC + "' and t_entry='" + Tentry + "'")) + 1;
                else code = 1;
                if ((Tentry.Trim() == "S") || (Tentry.Trim() == "8") || (Tentry.Trim() == "9") || (Tentry.Trim() == "C") || (Tentry.Trim() == "SR") || (Tentry.Trim() == "PR"))
                    command = "insert into typedoc(FICode, GCODE, T_ENTRY, Desccode, Type_Desc, Specific_Acc, METHOD, Effect_Amt, Req_Acc,User_Code) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'" + Type + "',0, 'A',null,0,'" + Current_Super_User + "')";
                else if (Tentry.Trim() == "M")
                    command = "insert into typedoc(FICode, GCODE, T_ENTRY, Desccode, Type_Desc, Specific_Acc, METHOD, Effect_Amt, Req_Acc,User_Code) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'" + Type + "',0, 'A',null,0,'" + Current_Super_User + "')";
                else
                    command = "insert into typedoc(FICode, GCODE, T_ENTRY, Desccode, Type_Desc, Specific_Acc, METHOD, Effect_Amt, Req_Acc,User_Code) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'" + Type + "',0, 'A',null,0,'" + Current_Super_User + "')";
                SqlCommand mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                mycmd.ExecuteNonQuery();
                switch (Tentry.Trim())
                {
                    case "OP":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1001','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1005','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1008','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1024','True', 'False','Stander')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1025','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1026','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1033','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1036','False', 'False','Sales Order')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        break;
                    case "8":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1003','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1005','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1008','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1012','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1022','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1028','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1029','False', 'False','No')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1032','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1033','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1034','False', 'False','ST,EC,HEC')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;
                    case "PR":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1003','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1005','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1008','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1022','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1028','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1033','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "a":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1005','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1008','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1024','True', 'False','Stander')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1025','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1026','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1031','False', 'False','Purchase Challan')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "PI":

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1024','True', 'False','Stander')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "9":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1003','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1004','True', 'False','Dos full Page Invoice')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1005','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1008','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1011','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1012','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1013','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1020','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1021','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1022','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1027','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1028','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1029','False', 'False','No')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1031','False', 'False','Tax Invoice')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1032','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1033','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1034','False', 'False','ST,EC,HEC')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "SR":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1003','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1004','True', 'False','Dos full Page Invoice')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1005','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1008','True', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1022','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();                       

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1028','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1033','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "n":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1031','False', 'False','Sales Challan')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "OS":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1001','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1006','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1007','False', 'False','Null')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1009','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1019','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1033','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "1":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1010','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1014','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1015','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "2":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1010','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1014','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1015','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1016','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "3":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1010','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1015','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "5":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1010','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1015','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "6":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "7":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1010','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1015','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "4":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1010','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1015','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1018','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "LT":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "PN":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();                       
                        break;

                    case "FG":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "GR":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "MI":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "MR":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "NI":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "NM":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1002','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1035','False', 'False','Not Applicable')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1038','False', 'False','False')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "SI":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;

                    case "SO":
                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1030','True', 'False','Yes')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();

                        command = "insert into TypeDoc_Config(FICode, GCODE, T_ENTRY, Desccode,OPTION_CODE,BOOL_VAL,DFLT_VAL,Script) values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'1037','True', 'False','True')";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        break;
                }
                command = "insert into docnumber(FICode, GCODE, T_ENTRY, TYPE_NAME, DESCCODE, TYPE_DESC, METHOD, PREPOS, SUFPOS, padding, doc_pos, no_sep, prefix, suffix,User_Code) values('" + FIC + "','" + GC + "','" + Tentry + "','" + Type + "'," + code + ",'" + Type + "D','A','1','2','4','2','1','" + prefix + "','" + suffix + "','" + PCURRENT_USER + "')";
                mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                mycmd.ExecuteNonQuery();

                command = "insert into docgen values('" + FIC + "','" + GC + "','" + Tentry + "'," + code + ",'0','RUNNING','" + PCURRENT_USER + "')";
                mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                mycmd.ExecuteNonQuery();                
                Tran.Commit();
            }
            catch
            {
                Tran.Rollback();
            }
        }

        public string GetresultS(string command)
        {
            EDPConnection edpcon = new EDPConnection();
            edpcon.Open();
            try
            {
                SqlCommand mycmd = new SqlCommand(command, edpcon.mycon);
                SqlDataReader dr;
                string data = null;
                dr = mycmd.ExecuteReader();
                if ((dr.Read()) && (!dr.IsDBNull(0)))
                {
                    data = Convert.ToString(dr.GetValue(0));
                }
                else
                {
                    data = null;
                }
                dr.Close();
                edpcon.Close();
                return data;
            }
            catch
            {
                edpcon.Close();
                return null;
            }
        }//return string value
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns>return boolean value default false</returns>
        public bool GetResultB(string command)
        {
            EDPConnection edpcon = new EDPConnection();
            edpcon.Open();
            try
            {
                SqlCommand mycmd = new SqlCommand(command, edpcon.mycon);
                SqlDataReader dr;
                bool data = false;
                dr = mycmd.ExecuteReader();
                if ((dr.Read()) && (!dr.IsDBNull(0)))
                {
                    data = Convert.ToBoolean(dr.GetValue(0));
                }
                else
                {
                    data = false;
                }
                dr.Close();
                edpcon.Close();
                return data;
            }
            catch
            {
                edpcon.Close();
                return false;
            }
        }
        public void MakeTabCustom()
        {

        }
        public void UpdateIGLMST(string Ficode, string Gcode)
        {
            EDPConnection edpcon = new EDPConnection();
            EDPCommon edpcom = new EDPCommon();
            DataSet ds = new DataSet();
            string sql = "", PCurrGcode = "";
            edpcon.Open();
            try
            {
                PCurrGcode = getCurrGcode(Ficode);
                //SqlCommand cmd = new SqlCommand("SELECT  ficode,pcode,gcode,CO_NAME,CO_ALIAS,INV_TYPECODE,CLASSCODE,FACE_VALUE,BUS_TYPE,OPSTK,CURSTK,ISIN_NO,Applied_Stat,invs_ac,ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac from iglmst WHERE FICODE='" + Ficode + "' and gcode='" + PCurrGcode + "'", edpcon.mycon);
                //SqlDataAdapter dac = new SqlDataAdapter(cmd);
                //dac.Fill(ds, "LGCODE");
                //int i = 0;
                //while (i <= ds.Tables["LGCODE"].Rows.Count - 1)
                //{
                //    sql = "insert into iglmst(ficode,pcode,gcode,CO_NAME,CO_ALIAS,INV_TYPECODE,CLASSCODE,FACE_VALUE,BUS_TYPE,OPSTK,CURSTK,ISIN_NO,Applied_Stat,invs_ac,ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac) values('" + Ficode + "'," + ds.Tables["LGCODE"].Rows[i][1] + ",'" + Gcode + "','" + ds.Tables["LGCODE"].Rows[i][3] + "','" + ds.Tables["LGCODE"].Rows[i][4] + "'," + ds.Tables["LGCODE"].Rows[i][5] + "," + ds.Tables["LGCODE"].Rows[i][6] + "," + ds.Tables["LGCODE"].Rows[i][7] + ",'" + ds.Tables["LGCODE"].Rows[i][8] + "'," + ds.Tables["LGCODE"].Rows[i][9] + "," + ds.Tables["LGCODE"].Rows[i][10] + ",'" + ds.Tables["LGCODE"].Rows[i][11] + "','" + ds.Tables["LGCODE"].Rows[i][12] + "'," + ds.Tables["LGCODE"].Rows[i][13] + "," + ds.Tables["LGCODE"].Rows[i][14] + "," + ds.Tables["LGCODE"].Rows[i][15] + "," + ds.Tables["LGCODE"].Rows[i][16] + "," + ds.Tables["LGCODE"].Rows[i][17] + "," + ds.Tables["LGCODE"].Rows[i][18] + "," + ds.Tables["LGCODE"].Rows[i][19] + "," + ds.Tables["LGCODE"].Rows[i][20] + ")";
                //    cmd = new SqlCommand(sql, edpcon.mycon);
                //    cmd.ExecuteNonQuery();
                //    i++;
                //}
                if ((Ficode.Trim() == "1") && (Gcode.Trim() == "1") && (PCurrGcode.Trim() == ""))
                {
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    sql = "delete from iglmst where ficode='" + Ficode + "' and gcode='" + Gcode + "'";
                    cmd = new SqlCommand(sql, edpcon.mycon);
                    cmd.ExecuteNonQuery();

                    sql = "insert into iglmst(ficode,pcode,gcode,CO_NAME,CO_ALIAS,INV_TYPECODE,CLASSCODE,FACE_VALUE,BUS_TYPE,OPSTK,CURSTK,ISIN_NO,Applied_Stat,invs_ac,ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac,Exp_Date,Unit_Of_Mez,Strike_Price,Lot_Size,Lot_Unit) select '" + Ficode + "',pcode,'" + Gcode + "',CO_NAME,CO_ALIAS,INV_TYPECODE,CLASSCODE,FACE_VALUE,BUS_TYPE,OPSTK,CURSTK,ISIN_NO,Applied_Stat,invs_ac,ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac,Exp_Date,Unit_Of_Mez,Strike_Price,Lot_Size,Lot_Unit from iglmst WHERE FICODE='" + Ficode + "' and gcode='" + PCurrGcode + "'";
                    cmd = new SqlCommand(sql, edpcon.mycon);
                    cmd.ExecuteNonQuery();
                    sql = "update iglmst set OPSTK=0,CURSTK=0 where FICODE='" + Ficode + "' and gcode='" + Gcode + "'";
                    cmd = new SqlCommand(sql, edpcon.mycon);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            { //EDPMessage.Show("Product transfer unsuccessfull.");
            }
        }
        //===Pradipta
        public void UpdateExchang(string Ficode, string Gcode)
        {
            EDPConnection edpcon = new EDPConnection();
            EDPCommon edpcom = new EDPCommon();
            DataSet ds = new DataSet();
            string sql = "", PCurrGcode = "";
            edpcon.Open();
            try
            {
                PCurrGcode = getCurrGcode(Ficode);
                if ((Ficode.Trim() == "1") && (Gcode.Trim() == "1") && (PCurrGcode.Trim() == ""))
                {
                }
                else
                {
                    //sql = "insert into iglmst(ficode,pcode,gcode,CO_NAME,CO_ALIAS,INV_TYPECODE,CLASSCODE,FACE_VALUE,BUS_TYPE,OPSTK,CURSTK,ISIN_NO,Applied_Stat,invs_ac,ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac,Exp_Date,Unit_Of_Mez,Strike_Price,Lot_Size,Lot_Unit) select '" + Ficode + "',pcode,'" + Gcode + "',CO_NAME,CO_ALIAS,INV_TYPECODE,CLASSCODE,FACE_VALUE,BUS_TYPE,OPSTK,CURSTK,ISIN_NO,Applied_Stat,invs_ac,ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac,Exp_Date,Unit_Of_Mez,Strike_Price,Lot_Size,Lot_Unit from iglmst WHERE FICODE='" + Ficode + "' and gcode='" + PCurrGcode + "'";
                    SqlCommand cmd = new SqlCommand();
                    sql = "delete from Exchng_Mst where ficode='" + Ficode + "' and gcode='" + Gcode + "' and Exchng_Name<>'NSE'";
                    cmd = new SqlCommand(sql, edpcon.mycon);
                    cmd.ExecuteNonQuery();

                    sql = "insert into Exchng_Mst(ficode,gcode,Exchng_Code,Exchng_Name,Exchng_Alias,Dflt_Flg) select '" + Ficode + "','" + Gcode + "',Exchng_Code,Exchng_Name,Exchng_Alias,Dflt_Flg from Exchng_Mst WHERE FICODE='" + Ficode + "' and gcode='" + PCurrGcode + "' and Exchng_Name<>'NSE'";
                    cmd = new SqlCommand(sql, edpcon.mycon);
                    cmd.ExecuteNonQuery();

                    sql = "delete from ExBrRel where ficode='" + Ficode + "' and gcode='" + Gcode + "' and Exchng_Code<>1";
                    cmd = new SqlCommand(sql, edpcon.mycon);
                    cmd.ExecuteNonQuery();

                    sql = "insert into ExBrRel(ficode,gcode,Exchng_Code,GLCODE) select '" + Ficode + "','" + Gcode + "',Exchng_Code,GLCODE from ExBrRel WHERE FICODE='" + Ficode + "' and gcode='" + PCurrGcode + "' and Exchng_Code<>1";
                    cmd = new SqlCommand(sql, edpcon.mycon);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }
        //End Pradipta

        public string getCurrGcode(string ficode)
        {
            string currg = "";
            EDPConnection con = new EDPConnection();
            EDPCommon com = new EDPCommon();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            if (Information.IsNothing(ds.Tables["currgcode"]) == false)
                ds.Tables["currgcode"].Clear();
            con.Open();
            cmd.CommandText = "select  distinct gcode from IGLMST where ficode='" + ficode + "'";
            cmd.Connection = con.mycon;
            da.SelectCommand = cmd;
            bool bu = Convert.ToBoolean(da.Fill(ds, "currgcode"));
            if (bu)
                currg = ds.Tables["currgcode"].Rows[0][0].ToString();
            else
                currg = com.PCURRENT_GCODE;

            return currg;
        }
        public void UpdateAccordFourLog(Form FormName, Boolean Opn_Close)
        {
            EDPConnection edpcon = new EDPConnection();
            try
            {
                int xlsv;
                edpcon.Open();
                if (UserCount == 1)
                    xlsv = 1;
                else
                    xlsv = 0;



                //if (xlsv == 1)
                //{
                //    DataTable DT_FormName = GetDatatable("SELECT * FROM AccordFourlog WHERE LOG_GCODE='" + PCURRENT_GCODE + "' AND LOG_CCODE='" + CurrentFicode + "' AND session_no='" + CURRENTSESSION + "' AND FORM_NAME='" + FormName.Name + "'");
                //    if (DT_FormName.Rows.Count > 0)
                //    {
                //        EDPMessage.Show("Multi User Not Supported.");
                //        Environment.Exit(0);
                //        Application.Exit();
                //    }


                //}

                if (Opn_Close)
                {
                    //if (Exclusive)
                    //    xlsv = 1;
                    //else
                    //    xlsv = 0;
                    string Sql = "insert into AccordFourlog(LOG_UCODE, LOG_GCODE, LOG_CCODE,FORM_NAME, FORM_CODE, DATE_FROM, TIME_FROM,LOG_STAT, MACHINE_NAME, Exclusive, session_no)";
                    Sql = Sql + "values('" + PCURRENT_USER + "','" + PCURRENT_GCODE + "','" + CurrentFicode + "','" + FormName.Name + "'," + 0 + ",'" + getSqlDateStr(DateTime.Today) + "','" + DateTime.Now.ToLongTimeString() + "'," + 0 + ",'" + Environment.MachineName.ToString() + "'," + xlsv + "," + CURRENTSESSION + ")";
                    SqlCommand sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                    Sql = "select max(autoincre) from AccordFourlog";
                    sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    SqlDataReader dr;
                    dr = sqlcmd.ExecuteReader();
                    dr.Read();
                    FormName.Tag = dr.GetInt32(0);
                }
                else
                {
                    string Sql = "Update AccordFourlog set DATE_TO='" + getSqlDateStr(DateTime.Today) + "',TIME_TO='" + DateTime.Now.ToLongTimeString() + "' where autoincre=" + FormName.Tag;
                    SqlCommand sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                }
                edpcon.Close();
            }
            catch
            {
                edpcon.Close();
            }
        }

        public void UpdateWaccLog(Form FormName, Boolean Opn_Close)
        {
            EDPConnection edpcon = new EDPConnection();
            EDPCommon edpcom = new EDPCommon();
            try
            {

                int xlsv;
                if (UserCount == 1)
                    xlsv = 1;
                else
                    xlsv = 0;
                edpcon.Open();
                if (Opn_Close)
                {
                    //xlsv = 0;
                    //wacclog

                    //if (!Check_Back_Up())
                    //{

                    if (PSERVER_NAME == Environment.MachineName)
                    {
                        SqlCommand sqlcmd1 = new SqlCommand("DELETE FROM AccordFourlogDetail WHERE Exclusive='0'", edpcon.mycon);
                        sqlcmd1.ExecuteNonQuery();
                    }
                    //}
                    //edpcon.Close();
                    DataTable DT_CURUSER = GetDatatable("SELECT USER_LEV FROM pasword P,AccordFourlogDetail A WHERE A.LOG_UCODE=P.USER_CODE AND Exclusive='0'", edpcon.mycon);
                    try
                    {
                         string str_User = "";
                         if (DT_CURUSER.Rows.Count > 0)
                         {
                             str_User = Convert.ToString(DT_CURUSER.Rows[0][0]);
                             for (int i = 1; i <= DT_CURUSER.Rows.Count - 1; i++)
                                 str_User = str_User + "," + Convert.ToString(DT_CURUSER.Rows[i][0]);
                             MessageBox.Show(str_User + " Useres already access this project.");
                         }
                         
                    }
                    catch{}
                    //edpcon.Open();
                    string Sql = "insert into AccordFourlogDetail(LOG_UCODE, LOG_GCODE, LOG_CCODE,Company_NAME, FORM_CODE, DATE_FROM, TIME_FROM,LOG_STAT, MACHINE_NAME, Exclusive, session_no)";
                    Sql = Sql + "values('" + PCURRENT_USER + "','" + edpcom.PCURRENT_GCODE + "','" + edpcom.CurrentFicode + "','" + edpcom.CURRENT_COMPANY + "'," + 0 + ",'" + getSqlDateStr(DateTime.Today) + "','" + DateTime.Now.ToLongTimeString() + "'," + 0 + ",'" + Environment.MachineName.ToString() + "'," + xlsv + "," + CURRENTSESSION + ")";
                    SqlCommand sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                    Sql = "select max(autoincre) from AccordFourlogDetail";
                    sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    SqlDataReader dr;
                    dr = sqlcmd.ExecuteReader();
                    dr.Read();
                    FormName.Tag = dr.GetInt32(0);
                }
                else
                {
                    //Sql = "select max(autoincre) from AccordFourlogDetail";
                    //sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    //SqlDataReader dr;
                    //dr = sqlcmd.ExecuteReader();
                    //dr.Read();
                    //FormName.Tag = dr.GetInt32(0);

                    string Sql = "Update AccordFourlogDetail set DATE_TO='" + getSqlDateStr(DateTime.Today) + "',TIME_TO='" + DateTime.Now.ToLongTimeString() + "',Exclusive='True',LOG_GCODE='" + edpcom.PCURRENT_GCODE + "',LOG_CCODE= '" + edpcom.CurrentFicode + "',Company_NAME='" + edpcom.CURRENT_COMPANY + "'   where LOG_UCODE='" + PCURRENT_USER + "'and Exclusive='False'and MACHINE_NAME='" + Environment.MachineName.ToString() + "'";
                    SqlCommand sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                }
                edpcon.Close();
            }
            catch (Exception ex)
            {
                edpcon.Close();
                EDPMessage.Show(ex.ToString());
            }
        }


        //public void UpdateWaccLog(Form FormName, Boolean Opn_Close)
        //{
        //    EDPConnection edpcon = new EDPConnection();
        //    try
        //    {

        //        int xlsv;
        //        edpcon.Open();
        //        if (Opn_Close)
        //        {
        //            if (Exclusive)
        //            {
        //                xlsv = 1;
        //            }
        //            else
        //            {
        //                xlsv = 0;
        //            }

        //            string Sql = "insert into wacclog(LOG_UCODE, LOG_GCODE, LOG_CCODE,FORM_NAME, FORM_CODE, DATE_FROM, TIME_FROM,LOG_STAT, MACHINE_NAME, Exclusive, session_no)";
        //            Sql = Sql + "values('" + PCURRENT_USER + "','" + PCURRENT_GCODE + "','" + CurrentFicode + "','" + FormName.Name + "'," + 0 + ",'" + getSqlDateStr(DateTime.Today) + "','" + DateTime.Now.ToLongTimeString() + "'," + 0 + ",'" + Environment.MachineName.ToString() + "'," + xlsv + "," + CURRENTSESSION + ")";
        //            SqlCommand sqlcmd = new SqlCommand(Sql, edpcon.mycon);
        //            sqlcmd.ExecuteNonQuery();
        //            Sql = "select max(autoincre) from wacclog";
        //            sqlcmd = new SqlCommand(Sql, edpcon.mycon);
        //            SqlDataReader dr;
        //            dr = sqlcmd.ExecuteReader();
        //            dr.Read();
        //            FormName.Tag = dr.GetInt32(0);
        //        }
        //        else
        //        {
        //            string Sql = "Update wacclog set DATE_TO='" + getSqlDateStr(DateTime.Today) + "',TIME_TO='" + DateTime.Now.ToLongTimeString() + "' where autoincre=" + FormName.Tag;
        //            SqlCommand sqlcmd = new SqlCommand(Sql, edpcon.mycon);
        //            sqlcmd.ExecuteNonQuery();
        //        }
        //        edpcon.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        edpcon.Close();
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        public void delCurrentVoucher(string tentry, int vouc ,Int64 doc)
        {
            EDPConnection edpcon = new EDPConnection();
            EDPCommon edpcom = new EDPCommon();
            try
            {
                edpcon.Open();
                string sql = "Select Voucherno from docgen where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + tentry + "' and DESCCODE='" + doc + "'and state='RUNNING'";
                SqlCommand cmd = new SqlCommand(sql, edpcon.mycon);
                SqlDataReader dr = cmd.ExecuteReader();
                int ss;
                int a;
                if (dr.Read())
                {
                    ss = Convert.ToInt32(dr["Voucherno"].ToString());
                    a = ss - 1;
                    if (ss == vouc)
                    {
                        try
                        {
                            string max_bill = "";
                            if(tentry =="1" || tentry =="2" || tentry =="3" || tentry =="4" || tentry =="5" || tentry =="6" || tentry =="7")
                                 max_bill = edpcom.GetresultS("select max(USER_VCH) from data  where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and  t_entry='" + tentry + "'and DESCCODE='" + doc + "'");                            
                            else
                                 max_bill = edpcom.GetresultS("select max(user_vch) from idata  where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and  t_entry='" + tentry + "'and DESCCODE='" + doc + "'");
                            //ss = 0;
                             if (max_bill != null)
                             {
                                 if (max_bill != "")
                                 {
                                     string[] s = new string[] { };
                                     s = max_bill.Trim().Split('/');
                                     if (s.Length == 3)
                                     {
                                         ss = Convert.ToInt32(s[2]);
                                         if (a > ss)
                                             a = ss;
                                     }
                                 }
                             }
                             else
                                 a = 0;
                            //double vch_lock=
                        }
                        catch { }
                        edpcom.RunCommand("delete from docgen where Voucherno=" + a + " and ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + tentry + "' and DESCCODE='" + doc + "'");
                        edpcom.RunCommand("update docgen set Voucherno=" + a + " where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + tentry + "' and DESCCODE='" + doc + "' and state='RUNNING'");
                    }
                    dr.Close();
                    edpcon.Close();
                }
            }
            catch { edpcon.Close(); }
        }

        public void saveFormPosition(string FormName, Point Location)
        {
            writeToIni(Application.StartupPath + "\\Settings.edp", FormName, "X", Location.X.ToString());
            writeToIni(Application.StartupPath + "\\Settings.edp", FormName, "Y", Location.Y.ToString());
        }
        public void setFormPosition(Form FormName)
        {
            try
            {
                int x = Convert.ToInt32(readFromIni(Application.StartupPath + "\\Settings.edp", FormName.Name, "X"));
                int y = Convert.ToInt32(readFromIni(Application.StartupPath + "\\Settings.edp", FormName.Name, "Y"));

                FormName.StartPosition = FormStartPosition.Manual;
                FormName.Location = new Point(x, y);
            }
            catch
            {
                FormName.StartPosition = FormStartPosition.CenterScreen;
            }

        }
        /// <summary>
        /// List of ledger.
        /// </summary>
        /// <param name="Code">subgroup or maingroup code</param>
        /// <param name="Type">'M' or 'S' denote main group or sub group</param>
        /// <returns>returns datatable</returns>
        public DataTable SelectLedger(Int32[] Code, char Type)
        {
            try
            {
                EDPConnection edpcon = new EDPConnection();
                EDPCommon edpcom = new EDPCommon();
                edpcon.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand com;
                DataTable dt;
                DataRow Dr;
                ArrayList s = new ArrayList();
                Int32 k;
                if (Type == 'S')
                {
                    if (Information.IsNothing(ds.Tables["ChkBro"]) == false)
                    {
                        ds.Tables["ChkBro"].Clear();
                    }
                    dt = new DataTable("LOV");
                    DataColumn brokername = new DataColumn("BrokerName");
                    DataColumn code = new DataColumn("BrokerCode");
                    dt.Columns.Add(brokername);
                    dt.Columns.Add(code);
                    for (int p = 0; p <= Code.Length - 1; p++)
                    {
                        s.Clear();
                        s.Add(Convert.ToInt32(Code.GetValue(p)));
                        for (int j = 0; j <= s.Count - 1; j++)
                        {
                            if (Information.IsNothing(ds.Tables["Sl"]) == false)
                            {
                                ds.Tables["Sl"].Clear();
                                ds.Clear();
                            }

                            k = Convert.ToInt32(s[j]);
                            com = new SqlCommand("SELECT DISTINCT SGROUP,Prev_Group,MType,LDESC,GLCODE FROM glmst WHERE FICode = " + edpcom.CurrentFicode + " AND GCode = " + edpcom.PCURRENT_GCODE + " AND (PREV_GROUP = " + k + ")", edpcon.mycon);
                            da.SelectCommand = com;
                            da.Fill(ds, "Sl");
                            edpcon.Close();
                            for (int i = 0; i <= ds.Tables["Sl"].Rows.Count - 1; i++)
                            {
                                if (k != Convert.ToInt32(ds.Tables["Sl"].Rows[i][0]))
                                    s.Add(Convert.ToInt32(ds.Tables["Sl"].Rows[i][0]));

                                if ((Convert.ToChar(ds.Tables["Sl"].Rows[i][2]) == 'L') & (Convert.ToInt32(ds.Tables["Sl"].Rows[i][0]) == Convert.ToInt32(ds.Tables["Sl"].Rows[i][1])))
                                {
                                    Dr = dt.NewRow();
                                    Dr[0] = Convert.ToString(ds.Tables["Sl"].Rows[i][3]);
                                    Dr[1] = Convert.ToString(ds.Tables["Sl"].Rows[i][4]);
                                    dt.Rows.Add(Dr);
                                }
                            }
                        }
                    }
                }
                else
                {
                    com = new SqlCommand("select LDESC,GLCODE,MTYPE,SGROUP from glmst where mgroup=" + Code + " and Ficode='" + edpcom.CurrentFicode + "' and GCODE='" + edpcom.PCURRENT_GCODE + "' and mtype='L'", edpcon.mycon);
                    da.SelectCommand = com;
                    da.Fill(ds, "ledger");
                    dt = new DataTable();
                    dt = ds.Tables["ledger"];
                }
                return dt;
            }
            catch { return null; }
        }
        public DataTable SelectLedger(Int32 Code, char Type)
        {
            return SelectLedger(new Int32[] { Code }, Type);
        }

        public Bitmap getImage(string TableName, string GivenField, string GivenFldVal, string SeekField)
        {
            Bitmap retBMP = null;
            string sqlstr = "select " + SeekField + " from " + TableName
                                        + " where " + GivenField + "=" + Convert.ToInt32(GivenFldVal);

            try
            {
                EDPConnection edpcon = new EDPConnection();
                edpcon.Open();
                mycmd = new SqlCommand(sqlstr, edpcon.mycon);
                SqlDataAdapter da = new SqlDataAdapter(mycmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "photo");
                byte[] b = (byte[])(ds.Tables["photo"].Rows[0][0]);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(b, true);
                stream.Write(b, 0, b.Length);
                retBMP = new Bitmap(stream);

                edpcon.Close();
            }
            catch
            {
                retBMP = null;
            }

            return retBMP;
        }
        public void ChangeTabColor(object sender, DrawItemEventArgs e, TabControl TabControlName, Color FocusedBackColor, Color FocusedForeColor, Color NonFocusedBackColor, Color NonFocusedForeColor)
        {
            Font myFont; Brush backColorBrush, foreColorBrush;
            StringFormat myFormat = new StringFormat();
            if (e.Index == TabControlName.SelectedIndex)
            {
                myFont = new Font(e.Font, FontStyle.Regular);
                backColorBrush = new System.Drawing.SolidBrush(FocusedBackColor);
                foreColorBrush = new System.Drawing.SolidBrush(FocusedForeColor);
                TabControlName.TabPages[e.Index].BackColor = FocusedBackColor;
                string tabName = TabControlName.TabPages[e.Index].Text;
                Rectangle rect = new Rectangle(e.Bounds.X + 4, e.Bounds.Y, e.Bounds.Width - 6, e.Bounds.Height);
                myFormat.Alignment = StringAlignment.Center;
                e.Graphics.FillRectangle(backColorBrush, rect);
                RectangleF r = new RectangleF(e.Bounds.X + 1, e.Bounds.Y + 4, e.Bounds.Width, e.Bounds.Height - 4);
                e.Graphics.DrawString(tabName, myFont, foreColorBrush, r, myFormat);
            }
            else
            {
                myFont = new Font(e.Font, FontStyle.Regular);
                backColorBrush = new System.Drawing.SolidBrush(NonFocusedBackColor);
                foreColorBrush = new System.Drawing.SolidBrush(NonFocusedForeColor);
                TabControlName.TabPages[e.Index].BackColor = FocusedBackColor;
                string tabName = TabControlName.TabPages[e.Index].Text;
                Rectangle rect = new Rectangle(e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height + 1);
                myFormat.Alignment = StringAlignment.Center;
                e.Graphics.FillRectangle(backColorBrush, rect);
                RectangleF r = new RectangleF(e.Bounds.X, e.Bounds.Y + 4, e.Bounds.Width, e.Bounds.Height - 4);
                e.Graphics.DrawString(tabName, myFont, foreColorBrush, r, myFormat);
            }
            myFormat.Dispose();
            myFont.Dispose();
            backColorBrush.Dispose();
            foreColorBrush.Dispose();
        }
        //public bool CheckMdiChild(Form childform, Form parent)
        //{
        //    try
        //    {
        //        bool childopen = false;
        //        Form[] frmall = parent.MdiChildren;
        //        foreach (Form frm in frmall)
        //        {
        //            Type tp = frm.GetType();
        //            Type tp1 = childform.GetType();
        //            EDPComponent.FormBaseERP from;
        //            EDPComponent.FormBase from1;
        //            Form from2; string name = "", name1 = "";
        //            if (tp1.BaseType.Name == "FormBaseERP")
        //            {
        //                from = (EDPComponent.FormBaseERP)childform;
        //                name = from.HeaderText;
        //            }
        //            if (tp1.BaseType.Name == "FormBase")
        //            {
        //                from1 = (EDPComponent.FormBase)childform;
        //                name = from1.HeaderText;
        //            }
        //            if (tp1.BaseType.Name == "Form")
        //            {
        //                from2 = (Form)childform;
        //                name = from2.Text;
        //            }
        //            if (tp.BaseType.Name == "FormBaseERP")
        //            {
        //                from = (EDPComponent.FormBaseERP)frm;
        //                name1 = from.HeaderText;
        //            }
        //            if (tp.BaseType.Name == "FormBase")
        //            {
        //                from1 = (EDPComponent.FormBase)frm;
        //                name1 = from1.HeaderText;
        //            }
        //            if (tp.BaseType.Name == "Form")
        //            {
        //                from2 = (Form)frm;
        //                name1 = from2.Text;
        //            }
        //            if (name == name1)
        //            {
        //                childopen = true;
        //                if (parent.ActiveMdiChild != childform)
        //                {
        //                    SetParent((int)childform.Handle, (int)parent.Handle);
        //                }
        //                break;
        //            }
        //            else childopen = false;
        //        }
        //        return childopen;
        //    }
        //    catch { return false; }
        //}

        public bool CheckMdiChild(Form childform, Form parent)//Chance By Prodipta Da (27.07.13)
        {
            try
            {
                string ab = "";
                  string[] s = new string[] { };
                  string[] ss = new string[] { };
                bool childopen = false;
                for (int i = 0; i <= parent.MdiChildren.Length - 1; i++)
                {
                    ab = parent.MdiChildren[i].ToString();
                    s = ab.Split(',');
                    ss = childform.ToString().Split(',');
                    if (s[0] == ss[0])
                    {
                        EDPMessage.Show("Another " + s[1] + " Already open");
                        childopen = true;
                        return true;
                    }
                }
                Form[] frmall = parent.MdiChildren;
                
                foreach (Form frm in frmall)
                {
                    Type tp = frm.GetType();
                    Type tp1 = childform.GetType();
                    EDPComponent.FormBaseERP from;
                    EDPComponent.FormBase from1;

                    EDPComponent.FormBaseLarge FormL;
                    EDPComponent.FormBaseMidium FormM;
                    EDPComponent.FormBaseQryMidium FormQM;
                    EDPComponent.FormBaseQueryLarge FormQL;
                    EDPComponent.FormBaseQuerySmall FormQS;
                    EDPComponent.FormBaseRptMidium FormRM;
                    EDPComponent.FormBaseRptSmall FormRS;
                    EDPComponent.FormBaseSmall FormS;


                    Form from2; string name = "", name1 = "";
                    if (tp1.BaseType.Name == "FormBaseERP")
                    {
                        from = (EDPComponent.FormBaseERP)childform;
                        name = from.HeaderText;
                    }
                    if (tp1.BaseType.Name == "FormBase")
                    {
                        from1 = (EDPComponent.FormBase)childform;
                        name = from1.HeaderText;
                    }
                    if (tp1.BaseType.Name == "Form")
                    {
                        from2 = (Form)childform;
                        name = from2.Text;
                    }
                    if (tp.BaseType.Name == "FormBaseERP")
                    {
                        from = (EDPComponent.FormBaseERP)frm;
                        name1 = from.HeaderText;
                    }
                    if (tp.BaseType.Name == "FormBase")
                    {
                        from1 = (EDPComponent.FormBase)frm;
                        name1 = from1.HeaderText;
                    }

                    if (tp1.BaseType.Name == "FormBaseLarge")
                    {
                        FormL = (EDPComponent.FormBaseLarge)childform;
                        name = FormL.Text;
                    }
                    if (tp.BaseType.Name == "FormBaseLarge")
                    {
                        FormL = (EDPComponent.FormBaseLarge)frm;
                        name1 = FormL.Text;
                    }

                    if (tp1.BaseType.Name == "FormBaseMidium")
                    {
                        FormM = (EDPComponent.FormBaseMidium)childform;
                        name = FormM.Text;
                    }
                    if (tp.BaseType.Name == "FormBaseMidium")
                    {
                        FormM = (EDPComponent.FormBaseMidium)frm;
                        name1 = FormM.Text;
                    }

                    if (tp1.BaseType.Name == "FormBaseQryMidium")
                    {
                        FormQM = (EDPComponent.FormBaseQryMidium)childform;
                        name = FormQM.Text;
                    }
                    if (tp.BaseType.Name == "FormBaseQryMidium")
                    {
                        FormQM = (EDPComponent.FormBaseQryMidium)frm;
                        name1 = FormQM.Text;
                    }

                    if (tp1.BaseType.Name == "FormBaseQueryLarge")
                    {
                        FormQL = (EDPComponent.FormBaseQueryLarge)childform;
                        name = FormQL.Text;
                    }
                    if (tp.BaseType.Name == "FormBaseQueryLarge")
                    {
                        FormQL = (EDPComponent.FormBaseQueryLarge)frm;
                        name1 = FormQL.Text;
                    }

                    if (tp1.BaseType.Name == "FormBaseQuerySmall")
                    {
                        FormQS = (EDPComponent.FormBaseQuerySmall)childform;
                        name = FormQS.Text;
                    }
                    if (tp.BaseType.Name == "FormBaseQuerySmall")
                    {
                        FormQS = (EDPComponent.FormBaseQuerySmall)frm;
                        name1 = FormQS.Text;
                    }

                    if (tp1.BaseType.Name == "FormBaseRptMidium")
                    {
                        FormRM = (EDPComponent.FormBaseRptMidium)childform;
                        name = FormRM.Text;
                    }
                    if (tp.BaseType.Name == "FormBaseRptMidium")
                    {
                        FormRM = (EDPComponent.FormBaseRptMidium)frm;
                        name1 = FormRM.Text;
                    }

                    if (tp1.BaseType.Name == "FormBaseRptSmall")
                    {
                        FormRS = (EDPComponent.FormBaseRptSmall)childform;
                        name = FormRS.Text;
                    }
                    if (tp.BaseType.Name == "FormBaseRptSmall")
                    {
                        FormRS = (EDPComponent.FormBaseRptSmall)frm;
                        name1 = FormRS.Text;
                    }

                    if (tp1.BaseType.Name == "FormBaseSmall")
                    {
                        FormS = (EDPComponent.FormBaseSmall)childform;
                        name = FormS.Text;
                    }
                    if (tp.BaseType.Name == "FormBaseSmall")
                    {
                        FormS = (EDPComponent.FormBaseSmall)frm;
                        name1 = FormS.Text;
                    }

                    if (tp.BaseType.Name == "Form")
                    {
                        from2 = (Form)frm;
                        name1 = from2.Text;
                    }
                    if (name == name1)
                    {
                        //childopen = true;
                        if (parent.ActiveMdiChild != childform)
                        {
                            SetParent((int)childform.Handle, (int)parent.Handle);
                        }
                        break;
                    }
                    else childopen = false;
                }
                return childopen;
            }
            catch { return false; }
        }


        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32")]
        public static extern int SetParent(int hWndChild, int hWndNewParent);
        public const int WM_MDINEXT = 0x224;
        public MdiClient GetMDIClient(Form parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is MdiClient)
                    return (MdiClient)c;
            }
            return null;
        }
        public DataTable Import_Sql(string source)
        {
            //
            string Con_Str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + source + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
            OleDbConnection conn = new OleDbConnection(Con_Str);

            //String qry = "SELECT PR_FirstName,PR_MiddleName,PR_LastName,SA_Address1,SA_Address2 FROM [sheet1$],[sheet2$] where PR_PatientID = SA_PatientID";
            String qry = "SELECT Tntry,Ttype,Slno,Desc,Trate,Tover,Tcode,Rndoff FROM [Sheet1$]";
            OleDbDataAdapter odp = new OleDbDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            if (Information.IsNothing(ds.Tables["FORMULATAB"]) == false)
            {
                ds.Tables["FORMULATAB"].Clear();
            }
            try
            {
                odp.Fill(ds, "FORMULATAB");
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.GetBaseException().ToString());
            }
            return ds.Tables["FORMULATAB"];
        }

        public bool RunCommand(string Command)
        {
            EDPConnection edpcon = new EDPConnection();
            edpcon.Open();
            bool ret = RunCommand(Command, edpcon.mycon);
            edpcon.Close();
            return ret;
        }
        public bool RunCommand(string Command, SqlConnection Con)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand(Command, Con);
            result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            return result;
        }
        public bool RunCommand(string Command, SqlConnection Con, SqlTransaction SqlT)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand(Command, Con, SqlT);
            result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            return result;
        }

        public DataTable GetDatatable(string SelectCommand)
        {
            EDPConnection edpcon = new EDPConnection();
            edpcon.Open();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SelectCommand, edpcon.mycon);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.Message, "Error", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_ERROR);
            }
            edpcon.Close();
            return dt;
        }

        public DataTable GetDatatable(string SelectCommand, SqlConnection Con)
        {           
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SelectCommand, Con);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.Message, "Error", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_ERROR);
            }           
            return dt;
        }

        public DataTable GetDatatable(string SelectCommand, SqlConnection Con, SqlTransaction SqlT)
        {            
            DataTable dt = new DataTable();           
            try
            {
                SqlCommand cmd = new SqlCommand(SelectCommand, Con, SqlT);
                SqlDataAdapter da = new SqlDataAdapter(cmd);              
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.Message, "Error", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_ERROR);
            }            
            return dt;
        }

        public DataSet GetDataset(string SelectCommand, DataSet ds)
        {
            return GetDataset(SelectCommand, "data", ds);
        }
        public DataSet GetDataset(string SelectCommand, string TableName, DataSet ds)
        {
            EDPConnection edpcon = new EDPConnection();
            edpcon.Open();
            if (!Information.IsNothing(ds.Tables[TableName]))
                ds.Tables.Remove(TableName);
            string tablename = TableName;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SelectCommand, edpcon.mycon);
                da.Fill(ds, tablename);
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.Message, "Error", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_ERROR);
            }
            edpcon.Close();
            return ds;
        }

        public string GetAmountFormat(double Val)
        {
            string s1, s2, s10 = "", str, strl = "";
            double GetVal = 0.00;
            try
            {
                if (Val < 0)
                    GetVal = Val * (-1);
                else
                    GetVal = Val;

                string ss = DesmPlc_Edpcom(GetVal.ToString());
                s10 = ss + " ";
                int StrLen = ss.Length;
                int sl = ss.IndexOf(".");
                str = ss.Substring(0, sl);
                strl = ss.Substring(sl, StrLen - sl);
                switch (sl.ToString())
                {
                    case "4":
                        s1 = str.Substring(0, 1);
                        s2 = str.Substring(1, sl - 1);
                        s10 = s1 + "," + s2 + " ";
                        break;
                    case "5":
                        s1 = str.Substring(0, 2);
                        s2 = str.Substring(2, sl - 2);
                        s10 = s1 + "," + s2 + " ";
                        break;
                    case "6":
                        s1 = str.Substring(0, 1);
                        s2 = str.Substring(1, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(3, sl - 3);
                        s10 = s1 + "," + s2 + " ";
                        break;
                    case "7":
                        s1 = str.Substring(0, 2);
                        s2 = str.Substring(2, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(4, sl - 4);
                        s10 = s1 + "," + s2 + " ";
                        break;
                    case "8":
                        s1 = str.Substring(0, 1);
                        s2 = str.Substring(1, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(3, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(5, sl - 5);
                        s10 = s1 + "," + s2 + " ";
                        break;
                    case "9":
                        s1 = str.Substring(0, 2);
                        s2 = str.Substring(2, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(4, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(6, sl - 6);
                        s10 = s1 + "," + s2 + " ";
                        break;
                    case "10":
                        s1 = str.Substring(0, 3);
                        s2 = str.Substring(3, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(5, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(7, sl - 7);
                        s10 = s1 + "," + s2 + " ";
                        break;
                    case "11":
                        s1 = str.Substring(0, 1);
                        s2 = str.Substring(1, 3);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(4, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(6, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(8, sl - 8);
                        s10 = s1 + "," + s2 + " ";
                        break;
                }
                if (Val < 0)
                    s10 = "-" + s10;
            }
            catch { }
            return s10;
        }

        public string GetAmountFormat(double Val, int DV)
        {
            string s1, s2, s10 = "", str, strl = "";
            double GetVal = 0.00;
            try
            {
                if (Val < 0)
                    GetVal = Val * (-1);
                else
                    GetVal = Val;

                //string ss = GetVal.ToString(SetDecimalPlace(DV));
                string ss = GetVal.ToString(SetDecimalPlace_Edpcom(DV));
                s10 = ss + " ";
                int StrLen = ss.Length;
                int sl = ss.IndexOf(".");
                str = ss.Substring(0, sl);
                strl = ss.Substring(sl, StrLen - sl);
                switch (sl.ToString())
                {
                    case "4":
                        s1 = str.Substring(0, 1);
                        s2 = str.Substring(1, sl - 1);
                        s10 = s1 + "," + s2 + strl + " ";
                        break;
                    case "5":
                        s1 = str.Substring(0, 2);
                        s2 = str.Substring(2, sl - 2);
                        s10 = s1 + "," + s2 + strl + " ";
                        break;
                    case "6":
                        s1 = str.Substring(0, 1);
                        s2 = str.Substring(1, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(3, sl - 3);
                        s10 = s1 + "," + s2 + strl + " ";
                        break;
                    case "7":
                        s1 = str.Substring(0, 2);
                        s2 = str.Substring(2, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(4, sl - 4);
                        s10 = s1 + "," + s2 + strl + " ";
                        break;
                    case "8":
                        s1 = str.Substring(0, 1);
                        s2 = str.Substring(1, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(3, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(5, sl - 5);
                        s10 = s1 + "," + s2 + strl + " ";
                        break;
                    case "9":
                        s1 = str.Substring(0, 2);
                        s2 = str.Substring(2, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(4, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(6, sl - 6);
                        s10 = s1 + "," + s2 + strl + " ";
                        break;
                    case "10":
                        s1 = str.Substring(0, 3);
                        s2 = str.Substring(3, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(5, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(7, sl - 7);
                        s10 = s1 + "," + s2 + strl + " ";
                        break;
                    case "11":
                        s1 = str.Substring(0, 1);
                        s2 = str.Substring(1, 3);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(4, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(6, 2);
                        s1 = s1 + "," + s2;
                        s2 = str.Substring(8, sl - 8);
                        s10 = s1 + "," + s2 + strl + " ";
                        break;
                }
                if (Val < 0)
                    s10 = "-" + s10;
            }
            catch { }
            return s10;
        }

        public string GetAmountFormat(double Val, int DV, string CT, string Sep)
        {
            string s1, s2, s10 = "", str, strl = "";
            double GetVal = 0.00;
            if (CT == "R")
            {
                try
                {
                    if (Val < 0)
                        GetVal = Val * (-1);
                    else
                        GetVal = Val;

                    //string ss = GetVal.ToString(SetDecimalPlace(DV));
                    string ss = GetVal.ToString(SetDecimalPlace_Edpcom(DV));
                    s10 = ss + " ";
                    int StrLen = ss.Length;
                    int sl = ss.IndexOf(".");
                    str = ss.Substring(0, sl);
                    strl = ss.Substring(sl, StrLen - sl);
                    switch (sl.ToString())
                    {
                        case "4":
                            s1 = str.Substring(0, 1);
                            s2 = str.Substring(1, sl - 1);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "5":
                            s1 = str.Substring(0, 2);
                            s2 = str.Substring(2, sl - 2);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "6":
                            s1 = str.Substring(0, 1);
                            s2 = str.Substring(1, 2);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(3, sl - 3);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "7":
                            s1 = str.Substring(0, 2);
                            s2 = str.Substring(2, 2);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(4, sl - 4);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "8":
                            s1 = str.Substring(0, 1);
                            s2 = str.Substring(1, 2);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(3, 2);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(5, sl - 5);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "9":
                            s1 = str.Substring(0, 2);
                            s2 = str.Substring(2, 2);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(4, 2);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(6, sl - 6);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "10":
                            s1 = str.Substring(0, 3);
                            s2 = str.Substring(3, 2);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(5, 2);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(7, sl - 7);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "11":
                            s1 = str.Substring(0, 1);
                            s2 = str.Substring(1, 3);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(4, 2);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(6, 2);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(8, sl - 8);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                    }
                    if (Val < 0)
                        s10 = "-" + s10;
                }
                catch { }
            }
            else if (CT == "D")
            {
                try
                {
                    if (Val < 0)
                        GetVal = Val * (-1);
                    else
                        GetVal = Val;

                    //string ss = GetVal.ToString(SetDecimalPlace(DV));
                    string ss = GetVal.ToString(SetDecimalPlace_Edpcom(DV));
                    s10 = ss + " ";
                    int StrLen = ss.Length;
                    int sl = ss.IndexOf(".");
                    str = ss.Substring(0, sl);
                    strl = ss.Substring(sl, StrLen - sl);
                    switch (sl.ToString())
                    {
                        case "4":
                            s1 = str.Substring(0, 1);
                            s2 = str.Substring(1, sl - 1);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "5":
                            s1 = str.Substring(0, 2);
                            s2 = str.Substring(2, sl - 2);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "6":
                            s1 = str.Substring(0, 3);
                            s2 = str.Substring(3, sl - 3);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "7":
                            s1 = str.Substring(0, 1);
                            s2 = str.Substring(1, 3);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(4, sl - 4);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "8":
                            s1 = str.Substring(0, 2);
                            s2 = str.Substring(2, 3);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(5, sl - 5);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "9":
                            s1 = str.Substring(0, 3);
                            s2 = str.Substring(3, 3);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(6, sl - 6);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "10":
                            s1 = str.Substring(0, 1);
                            s2 = str.Substring(1, 3);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(4, 3);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(7, sl - 7);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                        case "11":
                            s1 = str.Substring(0, 2);
                            s2 = str.Substring(2, 3);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(5, 3);
                            s1 = s1 + Sep + s2;
                            s2 = str.Substring(8, sl - 8);
                            s10 = s1 + Sep + s2 + strl + " ";
                            break;
                    }
                    if (Val < 0)
                        s10 = "-" + s10;
                }
                catch { }
            }
            return s10;
        }

        public string GetCurrencyType()
        {
            string CT = "";
            try
            {
                EDPConnection edpcon = new EDPConnection();
                EDPCommon edpcom = new EDPCommon();
                edpcon.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand com;

                com = new SqlCommand("SELECT DISTINCT Curr_Type FROM currency WHERE FICode = " + edpcom.CurrentFicode + " AND GCode = " + edpcom.PCURRENT_GCODE + " AND DFLT_FLG = 1 ", edpcon.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "CT");
                edpcon.Close();
                CT = ds.Tables["CT"].Rows[0][0].ToString().ToUpper();
            }
            catch { }
            return CT;
        }

        public string GetCurrencySeparator()
        {
            string TS = "";
            try
            {
                EDPConnection edpcon = new EDPConnection();
                EDPCommon edpcom = new EDPCommon();
                edpcon.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand com;

                com = new SqlCommand("SELECT DISTINCT THOU_SEP FROM currency WHERE FICode = " + edpcom.CurrentFicode + " AND GCode = " + edpcom.PCURRENT_GCODE + " AND DFLT_FLG = 1 ", edpcon.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "TS");
                edpcon.Close();
                TS = ds.Tables["TS"].Rows[0][0].ToString().ToUpper();
            }
            catch { }
            return TS;
        }

        public static string SetDecimalPlace_Edpcom(int Dplace)
        {
            //EDPConnection edpcon = new EDPConnection();
            //DataSet ds = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter();
            //SqlCommand com;
            //EDPCommon edpcom = new EDPCommon();

            //edpcon.Open();
            //com = new SqlCommand("SELECT DISTINCT DEC_SEP FROM currency WHERE FICode = " + edpcom.CurrentFicode + " AND GCode = " + edpcom.PCURRENT_GCODE + " AND  CURR_CODE='" + Curr_Code + "'", edpcon.mycon);
            //da.SelectCommand = com;
            //da.Fill(ds, "Curr_Sep");
            //edpcon.Close();
            //int Dplace = 0;
            //if (ds.Tables["Curr_Sep"].Rows.Count > 0)
            //{
            //    Dplace = Convert.ToInt32(ds.Tables["Curr_Sep"].Rows[0][0]);
            //}
            //else
            //    Dplace = Decimal_Place;

            string RetStr = "0.";
            if (Dplace == 0)
            {
                RetStr = "0";
            }
            for (int i = 1; i <= Dplace; i++)
            {
                RetStr = RetStr + "0";
            }
            return RetStr;
        }

        public static string SetDecimalPlace_Edpcom(string Curr_Code)
        {
            EDPConnection edpcon = new EDPConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand com;
            EDPCommon edpcom = new EDPCommon();

            edpcon.Open();
            com = new SqlCommand("SELECT DISTINCT DEC_SEP FROM currency WHERE FICode = " + edpcom.CurrentFicode + " AND GCode = " + edpcom.PCURRENT_GCODE + " AND  CURR_CODE='" + Curr_Code + "'", edpcon.mycon);
            da.SelectCommand = com;
            da.Fill(ds, "Curr_Sep");
            edpcon.Close();
            int Dplace = 0;
            if (ds.Tables["Curr_Sep"].Rows.Count > 0)
            {
                Dplace = Convert.ToInt32(ds.Tables["Curr_Sep"].Rows[0][0]);
            }
            else
                Dplace = Decimal_Place;

            string RetStr = "0.";
            if (Dplace == 0)
            {
                RetStr = "0";
            }
            for (int i = 1; i <= Dplace; i++)
            {
                RetStr = RetStr + "0";
            }
            return RetStr;
        }

        public static string SetDecimalPlace(int DecPlace)
        {
            int Dplace = DecPlace;
            string RetStr = "0.";
            if (Dplace == 0)
            {
                RetStr = "0";
            }
            for (int i = 1; i <= Dplace; i++)
            {
                RetStr = RetStr + "0";
            }
            return RetStr;
        }

        public static string SetDecimalPlace_Edpcom()
        {
            int Dplace = Decimal_Place;
            string RetStr = "0.";
            if (Dplace == 0)
            {
                RetStr = "0";
            }
            for (int i = 1; i <= Dplace; i++)
            {
                RetStr = RetStr + "0";
            }
            return RetStr;
        }
        public static string DesmPlc_Edpcom(string value)
        {
            try
            {
                decimal dc = Convert.ToDecimal(value);
                string rtstr = dc.ToString(SetDecimalPlace_Edpcom());
                return rtstr;
            }
            catch { throw new Exception("Not a integer or decimal value."); }

        }

        public static void Itemselect_EDP(string query, string caption, string header, string clmheader, int index, string stcktb, int assetrem)
        {
            Query = query;
            Caption = caption;
            Header = header;
            ClmHeader = clmheader;
            columnindex = index;
            StckTb = stcktb;
            qry_dt = 0;
            AssetBlock = assetrem;
            ItemSelaction ise = new ItemSelaction();
            ise.ShowDialog();
        }
        public static void MLOV_EDP(string query, string caption, string header, string clmheader, int index, string stcktb, int assetrem)
        {
            Query = query;
            Caption = caption;
            Header = header;
            ClmHeader = clmheader;
            columnindex = index;
            StckTb = stcktb;
            qry_dt = 0;
            AssetBlock = assetrem;
            frmListAddRemoveTree lstadd = new frmListAddRemoveTree();
            lstadd.ShowDialog();
        }
        public static void MLOV_EDP(string query, string caption, string header, string clmheader, int index, string stcktb, int assetrem, string FormName, string ComponentName)
        {
            Query = query;
            Caption = caption;
            Header = header;
            ClmHeader = clmheader;
            columnindex = index;
            StckTb = stcktb;
            qry_dt = 0;
            AssetBlock = assetrem;
            FormName_EDPC = FormName;
            ComponentName_EDPC = ComponentName;
            frmListAddRemoveTree lstadd = new frmListAddRemoveTree();
            lstadd.ShowDialog();
            FormName_EDPC = "";
            ComponentName_EDPC = "";
        }

        public static void MLOV_EDP(string query, string caption, string header, string clmheader, int index, string stcktb, int assetrem, string query_Existing_Item)
        {
            Query = query;
            Query_Existing_Item = query_Existing_Item;
            Caption = caption;
            Header = header;
            ClmHeader = clmheader;
            columnindex = index;
            StckTb = stcktb;
            qry_dt = 0;
            AssetBlock = assetrem;
            frmListAddRemoveTree lstadd = new frmListAddRemoveTree();
            lstadd.ShowDialog();
        }

        public static void MLOV_EDP(DataTable dt, string caption, string header, string clmheader, int index)
        {
            //   Query = query;
            Caption = caption;
            Header = header;
            ClmHeader = clmheader;
            columnindex = index;
            //        StckTb = stcktb;
            qry_dt = 1;
            if (Information.IsNothing(EDPCommon.STCK_DS_EDP.Tables["MLOV"]) == false)
            {
                EDPCommon.STCK_DS_EDP.Tables.Remove("MLOV");
            }
            //EDPCommon.STCK_DS_EDP.Tables.Add(dt);
            EDPCommon.dtss = dt;
            frmListAddRemoveTree lstadd = new frmListAddRemoveTree();
            lstadd.ShowDialog();
        }

        public static void ClearDataTable_EDP(DataTable dt)
        {
            if (!Information.IsNothing(dt))
                dt.Reset();
        }

        public static int CurrentStateCode()
        {
            int SC = 0;
            try
            {
                SC = Convert.ToInt32(new EDPCommon().GetresultS("Select Distinct BRNCH_STATE from BRANCH where ficode='" + new EDPCommon().CurrentFicode + "' and gcode='" + new EDPCommon().PCURRENT_GCODE + "' and BRNCH_CODE=0"));
            }
            catch { }
            return SC;
        }
        public static string CurrentStateName(int SC)
        {
            string StateName = "";
            try
            {
                StateName = new EDPCommon().GetresultS("Select Distinct State_Name from StateMaster where STATE_CODE=" + SC + "");
            }
            catch { }
            return StateName;
        }

        public void UpdateMidasLog(Form FormName, Boolean Opn_Close)
        {
            EDPConnection edpcon = new EDPConnection();
            try
            {
                int xlsv;
                edpcon.Open();
                if (Opn_Close)
                {
                    if (Exclusive)
                        xlsv = 1;
                    else
                        xlsv = 0;
                    string Sql = "insert into Midaslog(LOG_UCODE, LOG_GCODE, LOG_CCODE,FORM_NAME, FORM_CODE, DATE_FROM, TIME_FROM,LOG_STAT, MACHINE_NAME, Exclusive, session_no)";
                    Sql = Sql + "values('" + PCURRENT_USER + "','" + PCURRENT_GCODE + "','" + CurrentFicode + "','" + FormName.Name + "'," + 0 + ",'" + getSqlDateStr(DateTime.Today) + "','" + DateTime.Now.ToLongTimeString() + "'," + 0 + ",'" + Environment.MachineName.ToString() + "'," + xlsv + "," + CURRENTSESSION + ")";
                    SqlCommand sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                    Sql = "select max(autoincre) from midaslog";
                    sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    SqlDataReader dr;
                    dr = sqlcmd.ExecuteReader();
                    dr.Read();
                    FormName.Tag = dr.GetInt32(0);
                }
                else
                {
                    string Sql = "Update Midaslog set DATE_TO='" + getSqlDateStr(DateTime.Today) + "',TIME_TO='" + DateTime.Now.ToLongTimeString() + "' where autoincre=" + FormName.Tag;
                    SqlCommand sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                }
                edpcon.Close();
            }
            catch
            {
                edpcon.Close();
            }
        }

        //public static DateTime GET_DEFAULT_DATE()
        //{            
        //        EDPCommon edpcom = new EDPCommon();
        //        DateTime dt = System.DateTime.Now;

        //        if (dt <= edpcom.CURRCO_SDT)
        //        {
        //            dt = edpcom.CURRCO_SDT;
        //            goto pp;
        //        }
        //        if (dt >= edpcom.CURRCO_EDT)
        //        {
        //            dt = edpcom.CURRCO_EDT;
        //            goto pp;
        //        }
        //        if ((dt >= edpcom.CURRCO_SDT) && (dt <= edpcom.CURRCO_EDT))
        //        {
        //            dt = edpcom.CURRCO_SDT;
        //            goto pp;
        //        }
        //    pp:
        //        {
        //        }
        //        return dt;            
        //}

        //public static bool GET_ENDVALIDATION(DateTime TranDate)
        //{
        //    EDPCommon edpcom = new EDPCommon();
        //    bool LEGACY_ALLOWED = true;
        //    bool permission = true;
        //    if (LEGACY_ALLOWED)
        //    {
        //        if (TranDate > edpcom.CURRCO_EDT)
        //        {
        //            EDPMessage.Show("Transaction Date must be lower than the Financial Date", "Information...");
        //            permission = false;
        //        }
        //        if (TranDate < edpcom.CURRCO_SDT)
        //        {
        //            EDPMessage.Show("Transaction Date must be grater than the Financial Date", "Information...");
        //            permission = false;
        //        }
        //    }
        //    return permission;
        //}

        public string GetresultS(string command, SqlConnection sqc)
        {
            //EDPConnection edpcon = new EDPConnection();
            //edpcon.Open();
            try
            {
                SqlCommand mycmd = new SqlCommand(command, sqc);
                SqlDataReader dr;
                string data = null;
                dr = mycmd.ExecuteReader();
                if ((dr.Read()) && (!dr.IsDBNull(0)))
                {
                    data = Convert.ToString(dr.GetValue(0));
                }
                else
                {
                    data = null;
                }
                dr.Close();
                //edpcon.Close();
                return data;
            }
            catch
            {
                //edpcon.Close();
                return null;
            }
        }

        public string GetresultS(string command, SqlConnection sqc, SqlTransaction SqlT)
        {
            //EDPConnection edpcon = new EDPConnection();
            //edpcon.Open();
            try
            {
                SqlCommand mycmd = new SqlCommand(command, sqc, SqlT);
                SqlDataReader dr;
                string data = null;
                dr = mycmd.ExecuteReader();
                if ((dr.Read()) && (!dr.IsDBNull(0)))
                {
                    data = Convert.ToString(dr.GetValue(0));
                }
                else
                {
                    data = null;
                }
                dr.Close();
                //edpcon.Close();
                return data;
            }
            catch
            {
                //edpcon.Close();
                return null;
            }
        }

        public void Printheader()
        {
            try
            {
                EDPConnection conn = new EDPConnection();
                DataSet dsBRANCH = new DataSet();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adp = new SqlDataAdapter();

                company = ""; Phone = ""; address2 = ""; address3 = "";Reg = ""; Div = "";
                Comm = ""; Ecc = ""; Email = ""; Pan = ""; Tin = ""; Vat = ""; Cst = "";
                conn.Open();
                dsBRANCH.Clear();
                //cmd = new SqlCommand("SELECT BRNCH_ADD1,BRNCH_ADD2,BRNCH_CITY,BRNCH_STATE,BRNCH_PIN,BRNCH_NAME,BRNCH_TELE1,BRNCH_TELE2,EX_REG_NO,EX_DIV,EX_COMM,ECC_NO,BRNCH_EMAIL,CONTACT_PERSON,BRNCH_PAN1,VAT_DET,TIN,BRNCH_CST FROM BRANCH WHERE FICODE=" + CurrentFicode + " AND GCODE=" + PCURRENT_GCODE + " AND BRNCH_Name='" + CURRENT_COMPANY + "'AND BRNCH_CODE<>'1'", conn.mycon);
                cmd = new SqlCommand("SELECT BRNCH_ADD1,BRNCH_ADD2,BRNCH_CITY,BRNCH_STATE,BRNCH_PIN,BRNCH_NAME,BRNCH_TELE1,BRNCH_TELE2,EX_REG_NO,EX_DIV,EX_COMM,ECC_NO,BRNCH_EMAIL,CONTACT_PERSON,BRNCH_PAN1,VAT_DET,TIN,BRNCH_CST FROM BRANCH WHERE FICODE=" + CurrentFicode + " AND GCODE=" + PCURRENT_GCODE + " AND BRNCH_CODE ='0'", conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(dsBRANCH, "BR");
                conn.Close();
                string address = "";
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][5]) != "")
                {
                    company = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][5]);
                }

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][6]) != "")
                {
                    Phone = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][6]);
                }
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][7]) != "")
                {
                    if (Phone == "")
                        Phone = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][7]);
                    else
                        Phone = Phone + " / " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][7]);
                }

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][0]) != "")
                    address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][0]);

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]) != "")
                    if (address == "")
                        address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]);
                    else
                        address = address + " ," + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]);

                address2 = "" + address + "";
                address = "";

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]) != "")
                    address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]) != "")
                    if (address == "")
                        address = "PIN No.-" + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                    else
                        address = address + "-" + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);

                address3 = "" + address + "";


                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][8]) != "")
                {
                    Reg = "Registration No :" + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][8]);
                }

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][9]) != "")
                {
                    Div = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][9]);
                }

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][10]) != "")
                {
                    Comm = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][10]);
                }

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][11]) != "")
                {
                    Ecc = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][11]);
                }

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][12]) != "")
                {
                    Email = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][12]);
                }

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BRNCH_PAN1"]) != "")
                {
                    Pan = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BRNCH_PAN1"]);
                }

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["TIN"]) != "")
                {
                    Tin = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["TIN"]);
                }

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["VAT_DET"]) != "")
                {
                    Vat = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["VAT_DET"]);
                }
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BRNCH_CST"]) != "")
                {
                    Cst= Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BRNCH_CST"]);
                }
            }
            catch { }
        }
        //public void RefreshPartyDetails()
        //{
        //    company1 = ""; Phone1 = ""; address21 = "";
        //}

        public void PartyDetails(string PartyCode)
        {
            try
            {
                EDPConnection conn = new EDPConnection();
                DataSet dsBRANCH = new DataSet();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adp = new SqlDataAdapter();
                company1 = ""; Phone1 = ""; address21 = ""; address31 = ""; Reg1 = ""; Div1 = ""; Comm1 = ""; Ecc1 = ""; Email1 = ""; Pan1 = ""; Tin1 = ""; pPhone = ""; paddress2 = ""; paddress3 = ""; pEmail = "";
                conn.Close();
                conn.Open();
                dsBRANCH.Clear();
                ClearDataTable_EDP(dsBRANCH.Tables["PartyName"]);
                cmd = new SqlCommand("select g.ldesc from glmst g where g.glcode=" + PartyCode + " and g.ficode=" + CurrentFicode + " and g.gcode=" + PCURRENT_GCODE + " ", conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(dsBRANCH, "PartyName");
                conn.Close();

                conn.Open();
                ClearDataTable_EDP(dsBRANCH.Tables["BR"]);
                cmd = new SqlCommand("select g.ldesc,p.ACC_ADD1,p.ACC_ADD2,p.ACC_TELE1,p.ACC_TELE2,p.ACC_CITY,p.ACC_STATE,p.ACC_PIN,p.ACC_Email,p.IT_PAN,p.ECC_NO,p.EX_REG_NO,p.EX_DIV,p.EX_RANGE,p.EX_COMM,p.BAdd1,p.BAdd2,p.BCity,p.BState,p.BCountry,p.BPin,p.BTele1,p.BTele2,p.BFax,p.BEmail,p.TAN_NO,p.TIN from glmst g ,prtyms p where g.glcode=p.glcode and p.glcode=" + PartyCode + " and g.ficode=" + CurrentFicode + " and g.gcode=" + PCURRENT_GCODE + " and p.ficode=g.ficode and p.gcode=g.gcode ", conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(dsBRANCH, "BR");
                conn.Close();
                string address = "";
                if (dsBRANCH.Tables["PartyName"].Rows.Count > 0)
                {
                    if (Convert.ToString(dsBRANCH.Tables["PartyName"].Rows[0]["ldesc"]) != "")
                    {
                        company1 = Convert.ToString(dsBRANCH.Tables["PartyName"].Rows[0]["ldesc"]);
                    }
                }
                if (dsBRANCH.Tables["BR"].Rows.Count > 0)
                {
                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_TELE1"]) != "")
                    {
                        Phone1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_TELE1"]);
                    }
                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_TELE2"]) != "")
                    {
                        if (Phone1 == "")
                            Phone1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_TELE2"]);
                        else
                            Phone1 = Phone1 + " / " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_TELE2"]);
                    }
                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_ADD1"]) != "")
                        address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_ADD1"]);

                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_ADD2"]) != "")
                        if (address == "")
                            address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_ADD2"]);
                        else
                            address = address + "\n" + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_ADD2"]);

                    address21 = "" + address + "";
                    address = "";

                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_CITY"]) != "")
                        address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_CITY"]);

                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_PIN"]) != "")
                        if (address == "")
                            address = "PIN No.-" + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_PIN"]);
                        else
                            address = address + "-" + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_PIN"]);

                    address31 = "" + address + "";


                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["EX_REG_NO"]) != "")
                        Reg1 = "Registration No :" + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["EX_REG_NO"]);
                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["EX_DIV"]) != "")
                        Div1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["EX_DIV"]);
                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["EX_COMM"]) != "")
                        Comm1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["EX_COMM"]);
                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ECC_NO"]) != "")
                        Ecc1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ECC_NO"]);
                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_Email"]) != "")
                        Email1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ACC_Email"]);
                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["IT_PAN"]) != "")
                        Pan1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["IT_PAN"]);
                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["TIN"]) != "")
                        Tin1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["TIN"]);
                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BTele1"]) != "")
                        pPhone = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BTele1"]);
                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BTele2"]) != "")
                    {
                        if (pPhone == "")
                            pPhone = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BTele2"]);
                        else
                            pPhone = Phone + " / " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BTele2"]);
                    }

                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BAdd1"]) != "")
                        address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BAdd1"]);

                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BAdd2"]) != "")
                        if (address == "")
                            address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BAdd2"]);
                        else
                            address = address + " ," + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BAdd2"]);

                    paddress2 = "" + address + "";
                    address = "";

                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BCity"]) != "")
                        address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BCity"]);

                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BPin"]) != "")
                        if (address == "")
                            address = "PIN No.-" + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BPin"]);
                        else
                            address = address + "-" + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BPin"]);

                    paddress3 = "" + address + "";

                    if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BEmail"]) != "")
                        pEmail = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["BEmail"]);
                }
            }
            catch { }
        }
        public void BillAditional_Details(string VoucherNo, string Tentry)
        {
            try
            {
                EDPConnection conn = new EDPConnection();
                DataSet dsBRANCH = new DataSet();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adp = new SqlDataAdapter();
                conn.Open();
                dsBRANCH.Clear();
                cmd = new SqlCommand("select transPortName,ConsingmentNo,ConsingmentDate,NoofPackages,SRVNO,SRVNODate,LorryNo,Weight,Delivery_At,Kind_Attention,Phone,Mode_Of_Transport,Prepared_by,Indent,Advance,Invoice_Preparetion,Removal_Date,Removal_Time,InvoiceIssueDate,InvoiceIssueTime,Your_Order_No,Your_Order_Date,Payment_Terms,Payment_Date  from BillAdditionalDetails where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and voucher='" + VoucherNo + "' and t_entry='" + Tentry + "' ", conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(dsBRANCH, "BR");
                conn.Close();
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["transPortName"]) != "")
                    transPortName = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["transPortName"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ConsingmentNo"]) != "")
                    ConsingmentNo = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ConsingmentNo"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ConsingmentDate"]) != "")
                    ConsingmentDate = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["ConsingmentDate"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["NoofPackages"]) != "")
                    NoofPackages = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["NoofPackages"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["SRVNO"]) != "")
                    SRVNO = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["SRVNO"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["SRVNODate"]) != "")
                    SRVNODate = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["SRVNODate"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["LorryNo"]) != "")
                    LorryNo = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["LorryNo"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Weight"]) != "")
                    Weight = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Weight"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Delivery_At"]) != "")
                    Delivery_At = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Delivery_At"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Kind_Attention"]) != "")
                    Kind_Attention = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Kind_Attention"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Phone"]) != "")
                    PhoneNo = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Phone"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Mode_Of_Transport"]) != "")
                    Mode_Of_Transport = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Mode_Of_Transport"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Prepared_by"]) != "")
                    Prepared_by = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Prepared_by"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Indent"]) != "")
                    Indent = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Indent"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Advance"]) != "")
                    Advance = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Advance"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Invoice_Preparetion"]) != "")
                    Invoice_Preparetion = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Invoice_Preparetion"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Removal_Date"]) != "")
                    Removal_Date = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Removal_Date"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Removal_Time"]) != "")
                    Removal_Time = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Removal_Time"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["InvoiceIssueDate"]) != "")
                    InvoiceIssueDate = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["InvoiceIssueDate"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["InvoiceIssueTime"]) != "")
                    InvoiceIssueTime = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["InvoiceIssueTime"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Your_Order_No"]) != "")
                    Your_Order_No = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Your_Order_No"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Your_Order_Date"]) != "")
                    Your_Order_Date = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Your_Order_Date"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Payment_Terms"]) != "")
                    Payment_Terms = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Payment_Terms"]);
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Payment_Date"]) != "")
                    Payment_Date = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0]["Payment_Date"]);
            }
            catch { }
        }

        //BillAdditional Details      
        
        public string Details_Transport_Name
        {
            get
            {
                return transPortName;
            }
            set
            {
                if (value != transPortName)
                {
                    transPortName = value;
                }
            }
        }

        public string Details_Consingmaent_No
        {
            get
            {
                return ConsingmentNo;
            }
            set
            {
                if (value != ConsingmentNo)
                {
                    ConsingmentNo = value;
                }
            }
        }
        public string Details_ConsingmentDate
        {
            get
            {
                return ConsingmentDate;
            }
            set
            {
                if (value != ConsingmentDate)
                {
                    ConsingmentDate = value;
                }
            }
        }
        public string Details_SupplierChallan_No
        {
            get
            {
                return SRVNO;
            }
            set
            {
                if (value != SRVNO)
                {
                    SRVNO = value;
                }
            }
        }
        public string Details_SupplierChallan_Date
        {
            get
            {
                return SRVNODate;
            }
            set
            {
                if (value != SRVNODate)
                {
                    SRVNODate = value;
                }
            }
        }

        public string Details_LOrry_No
        {
            get
            {
                return LorryNo;
            }
            set
            {
                if (value != LorryNo)
                {
                    LorryNo = value;
                }
            }
        }
        public string Details_Weight
        {
            get
            {
                return Weight;
            }
            set
            {
                if (value != Weight)
                {
                    Weight = value;
                }
            }
        }
        public string Details_Delivery_At
        {
            get
            {
                return Delivery_At;
            }
            set
            {
                if (value != Delivery_At)
                {
                    Delivery_At = value;
                }
            }
        }
        public string Details_Kind_Attention
        {
            get
            {
                return Kind_Attention;
            }
            set
            {
                if (value != Kind_Attention)
                {
                    Kind_Attention = value;
                }
            }
        }

        public string Details_Phone_No
        {
            get
            {
                return PhoneNo;
            }
            set
            {
                if (value != PhoneNo)
                {
                    PhoneNo = value;
                }
            }
        }
        public string Details_Mode_Transport
        {
            get
            {
                return Mode_Of_Transport;
            }
            set
            {
                if (value != Mode_Of_Transport)
                {
                    Mode_Of_Transport = value;
                }
            }
        }

        public string Details_Prepared_By
        {
            get
            {
                return Prepared_by;
            }
            set
            {
                if (value != Prepared_by)
                {
                    Prepared_by = value;
                }
            }
        }

        public string Details_Indent
        {
            get
            {
                return Indent;
            }
            set
            {
                if (value != Indent)
                {
                    Indent = value;
                }
            }
        }

        public string Details_Advance
        {
            get
            {
                return Advance;
            }
            set
            {
                if (value != Advance)
                {
                    Advance = value;
                }
            }
        }
        public string Details_Preparetion
        {
            get
            {
                return Invoice_Preparetion;
            }
            set
            {
                if (value != Invoice_Preparetion)
                {
                    Invoice_Preparetion = value;
                }
            }
        }
        public string Details_Removal_Date
        {
            get
            {
                return Removal_Date;
            }
            set
            {
                if (value != Removal_Date)
                {
                    Removal_Date = value;
                }
            }
        }
        public string Details_Removal_Time
        {
            get
            {
                return Removal_Time;
            }
            set
            {
                if (value != Removal_Time)
                {
                    Removal_Time = value;
                }
            }
        }
        public string Details_InvoiceIssue_Date
        {
            get
            {
                return InvoiceIssueDate;
            }
            set
            {
                if (value != InvoiceIssueDate)
                {
                    InvoiceIssueDate = value;
                }
            }
        }
        public string Details_InvoiceIssu_Time
        {
            get
            {
                return InvoiceIssueTime;
            }
            set
            {
                if (value != InvoiceIssueTime)
                {
                    InvoiceIssueTime = value;
                }
            }
        }
        public string Details_YourOrder_No
        {
            get
            {
                return Your_Order_No;
            }
            set
            {
                if (value != Your_Order_No)
                {
                    Your_Order_No = value;
                }
            }
        }
        public string Details_YourOrder_Date
        {
            get
            {
                return Your_Order_Date;
            }
            set
            {
                if (value != Your_Order_Date)
                {
                    Your_Order_Date = value;
                }
            }
        }

        public string Details_Payment_Terms
        {
            get
            {
                return Payment_Terms;
            }
            set
            {
                if (value != Payment_Terms)
                {
                    Payment_Terms = value;
                }
            }
        }
        public string Details_Payment_Date
        {
            get
            {
                return Payment_Date;
            }
            set
            {
                if (value != Payment_Date)
                {
                    Payment_Date = value;
                }
            }
        }
       
        //End BillAdditional Details

        //Start Branch Details
        public string Branch_Name
        {
            get
            {
                return company;
            }
            set
            {
                if (value != company)
                {
                    company = value;
                }
            }
        }

        public string Branch_Phone
        {
            get
            {
                return Phone;
            }
            set
            {
                if (value != Phone)
                {
                    Phone = value;
                }
            }
        }
        public string Branch_Address
        {
            get
            {
                return address2;
            }
            set
            {
                if (value != address2)
                {
                    address2 = value;
                }
            }
        }
        public string Branch_Address2
        {
            get
            {
                return address3;
            }
            set
            {
                if (value != address3)
                {
                    address3 = value;
                }
            }
        }
        public string Branch_Excise_Reg_No
        {
            get
            {
                return Reg;
            }
            set
            {
                if (value != Reg)
                {
                    Reg = value;
                }
            }
        }
        public string Branch_Excise_Divition
        {
            get
            {
                return Div;
            }
            set
            {
                if (value != Div)
                {
                    Div = value;
                }
            }
        }
        public string Branch_Excise_commision
        {
            get
            {
                return Comm;
            }
            set
            {
                if (value != Comm)
                {
                    Comm = value;
                }
            }
        }
        public string Branch_Excise_ECC
        {
            get
            {
                return Ecc;
            }
            set
            {
                if (value != Ecc)
                {
                    Ecc = value;
                }
            }
        }
        public string Branch_Email
        {
            get
            {
                return Email;
            }
            set
            {
                if (value != Email)
                {
                    Email = value;
                }
            }
        }

        public string Branch_Pan
        {
            get
            {
                return Pan;
            }
            set
            {
                if (value != Pan)
                {
                    Pan = value;
                }
            }
        }
        public string Branch_Tin
        {
            get
            {
                return Tin;
            }
            set
            {
                if (value != Tin)
                {
                    Tin = value;
                }
            }
        }
        public string Branch_Vat
        {
            get
            {
                return Vat;
            }
            set
            {
                if (value != Vat)
                {
                    Vat = value;
                }
            }
        }
        public string Branch_Cst
        {
            get
            {
                return Cst;
            }
            set
            {
                if (value != Cst)
                {
                    Cst = value;
                }
            }
        }
        //End Company Details

        //Start Party Details
        public string Party_Name
        {
            get
            {
                return company1;
            }
            set
            {
                if (value != company1)
                {
                    company1 = value;
                }
            }
        }

        public string Party_Phone
        {
            get
            {
                return Phone1;
            }
            set
            {
                if (value != Phone1)
                {
                    Phone1 = value;
                }
            }
        }
        public string Party_Address
        {
            get
            {
                return address21;
            }
            set
            {
                if (value != address21)
                {
                    address21 = value;
                }
            }
        }
        public string Party_Address2
        {
            get
            {
                return address31;
            }
            set
            {
                if (value != address31)
                {
                    address31 = value;
                }
            }
        }
        public string Party_Excise_Reg_No
        {
            get
            {
                return Reg1;
            }
            set
            {
                if (value != Reg1)
                {
                    Reg1 = value;
                }
            }
        }
        public string Party_Divition
        {
            get
            {
                return Div1;
            }
            set
            {
                if (value != Div1)
                {
                    Div1 = value;
                }
            }
        }
        public string Party_Excise_commision
        {
            get
            {
                return Comm1;
            }
            set
            {
                if (value != Comm1)
                {
                    Comm1 = value;
                }
            }
        }
        public string Party_Excise_ECC
        {
            get
            {
                return Ecc1;
            }
            set
            {
                if (value != Ecc1)
                {
                    Ecc1 = value;
                }
            }
        }
        public string Party_Email
        {
            get
            {
                return Email1;
            }
            set
            {
                if (value != Email1)
                {
                    Email1 = value;
                }
            }
        }

        public string Party_Pan
        {
            get
            {
                return Pan1;
            }
            set
            {
                if (value != Pan1)
                {
                    Pan1 = value;
                }
            }
        }
        public string Party_Tin
        {
            get
            {
                return Tin1;
            }
            set
            {
                if (value != Tin1)
                {
                    Tin1 = value;
                }
            }
        }
        public string Other_Party_Phone
        {
            get
            {
                return pPhone;
            }
            set
            {
                if (value != pPhone)
                {
                    pPhone = value;
                }
            }
        }
        public string Other_Party_Address
        {
            get
            {
                return paddress2;
            }
            set
            {
                if (value != paddress2)
                {
                    paddress2 = value;
                }
            }
        }
        public string Other_Party_Address2
        {
            get
            {
                return paddress3;
            }
            set
            {
                if (value != paddress3)
                {
                    paddress3 = value;
                }
            }
        }
        public string Other_Party_Email
        {
            get
            {
                return pEmail;
            }
            set
            {
                if (value != pEmail)
                {
                    pEmail = value;
                }
            }
        }
        //End Party Details

        public string EnvironMent_Envelope
        {
            get
            {
                return Envelope;
            }
            set
            {
                if (value != Envelope)
                {
                    Envelope = value;
                }
            }
        }
        public string EnvironMent_Menu
        {
            get
            {
                return Menutype;
            }
            set
            {
                if (value != Menutype)
                {
                    Menutype = value;
                }
            }
        }
        public string EnvironMent_Bittype
        {
            get
            {
                return Bittype;
            }
            set
            {
                if (value != Bittype)
                {
                    Bittype = value;
                }
            }
        }
        public string CurrentSuperuser
        {
            get
            {
                return Superuser_code;
            }
            set
            {
                if (value != Superuser_code)
                {
                    Superuser_code = value;
                }
            }
        }
        public string CurrentUGcode
        {
            get
            {
                return UG_code;
            }
            set
            {
                if (value != UG_code)
                {
                    UG_code = value;
                }
            }
        }
        public int Stock_Mantanance(string TE,int PC)
        {
            int Stock_Status = 0;
            if (TE == "n" || TE == "9" || TE == "SO" || TE == "PR" || TE == "FG" || TE == "MR")
            {
                try
                {
                    EDPConnection edpcon = new EDPConnection();
                    SqlCommand com = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    EDPCommon edpcom = new EDPCommon();
                    DataSet ds = new DataSet();
                    edpcon.Open();

                    edpcon.Open();
                    com = new SqlCommand("SELECT IG.REORDER_LEVEL,IG.MINIMUM_LEVEL,IG.CUR_QTY,U.UDESC FROM IGLMST IG,UNIT U WHERE IG.FICode = " + edpcom.CurrentFicode + " AND IG.GCode = " + edpcom.PCURRENT_GCODE + " AND IG.PCODE=" + PC + " AND IG.FICODE=U.FICODE AND IG.GCODE=U.GCODE AND IG.UCODE=U.UCODE", edpcon.mycon);
                    da.SelectCommand = com;
                    da.Fill(ds, "Stock_Level");
                    edpcon.Close();

                    if (ds.Tables["Stock_Level"].Rows.Count > 0)
                    {
                        if ((Information.IsNumeric(ds.Tables["Stock_Level"].Rows[0]["MINIMUM_LEVEL"]) == true) && (Information.IsNumeric(ds.Tables["Stock_Level"].Rows[0]["CUR_QTY"]) == true))
                        {
                            if (Convert.ToDouble(ds.Tables["Stock_Level"].Rows[0]["MINIMUM_LEVEL"]) >= Convert.ToDouble(ds.Tables["Stock_Level"].Rows[0]["CUR_QTY"]))
                            {
                                Stock_Status = 2;
                                EDPMessage.Show("Stock is now in minimum level.Current stock is " + Convert.ToDouble(ds.Tables["Stock_Level"].Rows[0]["CUR_QTY"]).ToString(SetDecimalPlace(2)) + " " + Convert.ToString(ds.Tables["Stock_Level"].Rows[0]["UDESC"]) + "");
                                return Stock_Status;
                            }
                        }

                        if ((Information.IsNumeric(ds.Tables["Stock_Level"].Rows[0]["REORDER_LEVEL"]) == true) && (Information.IsNumeric(ds.Tables["Stock_Level"].Rows[0]["CUR_QTY"]) == true))
                        {
                            if (Convert.ToDouble(ds.Tables["Stock_Level"].Rows[0]["REORDER_LEVEL"]) >= Convert.ToDouble(ds.Tables["Stock_Level"].Rows[0]["CUR_QTY"]))
                            {
                                Stock_Status = 1;
                                EDPMessage.Show("Stock is now in reorder level.Current stock is " + Convert.ToString(ds.Tables["Stock_Level"].Rows[0]["CUR_QTY"]) + " " + Convert.ToString(ds.Tables["Stock_Level"].Rows[0]["UDESC"]) + "");
                            }
                        }
                    }
                }
                catch { }
            }
            return Stock_Status;
        }

        public bool Check_Back_Up()
        {
            bool x = true;
            try
            {
                x = Convert.ToBoolean(readFromIni(Application.StartupPath + "\\Settings.edp", "BACK_UP", "FLAG"));
            }
            catch { }
            return x;
        }

        public void Insert_Last_Backup_Normaly()
        {
            try
            {
                writeToIni(Application.StartupPath + "\\Settings.edp", "BACK_UP", "FLAG", "FALSE");
            }
            catch { }
        }

        public void Manu_Update()
        {
            SqlCommand mycmd = new SqlCommand();
            EDPConnection CON = new EDPConnection();
            CON.Close();
            CON.Open();
            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020208000 ", CON.mycon);
            mycmd.ExecuteNonQuery();
            mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020209000 ", CON.mycon);
            mycmd.ExecuteNonQuery();
            CON.Close();
            if (EnvironMent_Envelope == "Brand Purchase")
            {
                CON.Close();
                CON.Open();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010302000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010303000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010305000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010306000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010500000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010600000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20020301000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20020303000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20020400000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20020500000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20030000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20040000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
               CON.Close();
            }
            else if (EnvironMent_Envelope == "Petrol")
            {
               CON.Close();
                CON.Open();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=50230000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
               CON.Close();
            }
            else if (EnvironMent_Envelope == "PRINTING")
            {
               CON.Close();
                CON.Open();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010303000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010305000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010306000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010400000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010500000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20010600000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20020403000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20030000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=20040000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30010105000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30010108000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30010109000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30010110000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30010300000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30020300000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30020400000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30030000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30040000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=30050000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010107000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010108000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010109000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010110000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010204000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010205000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010206000 ", CON.mycon);
                mycmd.ExecuteNonQuery();               
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010305000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010306000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010307000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010308000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010309000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010400000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020500000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030400000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40040000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40030300000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=40020208000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=40020209000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50050000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50060000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50070000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50110000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50120000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50150000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50160000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50170000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50220000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50230000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60030000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60040000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=40020212000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=40020213000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=40020214000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                CON.Close();                
                CON.Open();
                try
                {
                    mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=6005000000 ", CON.mycon);
                    mycmd.ExecuteNonQuery();
                    mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60060000000 ", CON.mycon);
                    mycmd.ExecuteNonQuery();
                    mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60070000000 ", CON.mycon);
                    mycmd.ExecuteNonQuery();
                    mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60080000000 ", CON.mycon);
                    mycmd.ExecuteNonQuery();
                    mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60090000000 ", CON.mycon);
                    mycmd.ExecuteNonQuery();
                    mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60100000000 ", CON.mycon);
                    mycmd.ExecuteNonQuery();                   
                }
                catch { }
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60110000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60140000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60170000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60180000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020201000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020204000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020205000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020206000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=60170007000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020300000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020400000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
               
                CON.Close();                
                CON.Open();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='TRUE' where MENUCODE=40010400000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010401000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010403000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='TRUE' where MENUCODE=40010402000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010404000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010405000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010406000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010408000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010410000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010413000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010419000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010421000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010422001 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010422100 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40010422220 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020203000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020207000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                CON.Close();
            }
            else
            {
                CON.Close();
                CON.Open();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=20010302000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=20020301000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=20020400000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=20020500000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=20030000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=20040000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=50230000000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020212000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020213000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='False' where MENUCODE=40020214000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                mycmd = new SqlCommand("update MenuTable set ENABLE_MENU='True' where MENUCODE=40010304000 ", CON.mycon);
                mycmd.ExecuteNonQuery();
                CON.Close();
            }
        }
        public static int CurrentCountryCode()
        {
            int SC = 0;
            try
            {
                SC = Convert.ToInt32(new EDPCommon().GetresultS("Select Distinct COUNTRY from BRANCH where ficode='" + new EDPCommon().CurrentFicode + "' and gcode='" + new EDPCommon().PCURRENT_GCODE + "' and BRNCH_CODE=0"));
            }
            catch { }
            return SC;
        }
        public static string CurrentCountryName(int CC)
        {
            string StateName = "";
            try
            {
                StateName = new EDPCommon().GetresultS("Select Distinct Country_Name from Country where Country_CODE=" + CC + "");
            }
            catch { }
            return StateName;
        }

        public void Form_Controls_ListView_Status_Save(Form Form_Test, string FormName)
        {
            try
            {
                foreach (Control c in Form_Test.Controls)
                {
                    if (c is ListView)
                    {
                        //ListView++;

                        string ss2 = c.Name;

                        ListView L1 = (ListView)c;
                        string ss3 = L1.Items[0].Text;
                        string ss4 = L1.Items[0].SubItems[0].Text;

                        
                    }
                }
            }
            catch { }
        }

        public void Form_Controls_Status_Save(Form Form_Test, string FormName)
        {
            try
            {
                FormName = FormName + CurrFIcode + PCURRENT_GCODE;
                foreach (Control c in Form_Test.Controls)
                {
                    string ControlName = "";
                    if (c.GetType() == typeof(CheckBox))
                    {
                        CheckBox CB = (CheckBox)c;
                        ControlName = CB.Name + "[CheckBox]";
                        string Chk_Value = "False";
                        if (CB.Checked)
                            Chk_Value = "True";
                        writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                    }
                    else if (c is TextBox)
                    {
                        TextBox TB = (TextBox)c;
                        ControlName = TB.Name + "[TextBox]";
                        string Chk_Value = TB.Text;
                        writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                    }
                    else if (c is RadioButton)
                    {
                        RadioButton RB = (RadioButton)c;
                        ControlName = RB.Name + "[RadioButton]";
                        string Chk_Value = "False";
                        if (RB.Checked)
                            Chk_Value = "True";
                        writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                    }
                    else if (c.GetType() == typeof(ComboBox))
                    {
                        ComboBox CB = (ComboBox)c;
                        ControlName = CB.Name + "[ComboBox]";
                        string Chk_Value = CB.Text;
                        writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                    }
                    else if (c is Label)
                    {
                        Label LB = (Label)c;
                        ControlName = LB.Name + "[Label]";
                        string Chk_Value = LB.Text;
                        writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                    }
                    else if (c is EDPComponent.ComboDialog)
                    {
                        EDPComponent.ComboDialog CD = (EDPComponent.ComboDialog)c;
                        ControlName = CD.Name + "[ComboDialog]";
                        string Chk_Value = CD.Text;
                        writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                    }
                    else if (c is DateTimePicker)
                    {
                        DateTimePicker DTP = (DateTimePicker)c;
                        ControlName = DTP.Name + "[DateTimePicker]";
                        string Chk_Value = DTP.Text;
                        writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                    }
                    else if (c is EDPComponent.DateTimePickerEDP)
                    {
                        EDPComponent.DateTimePickerEDP DTP = (EDPComponent.DateTimePickerEDP)c;
                        ControlName = DTP.Name + "[DateTimePickerEDP]";
                        string Chk_Value = DTP.Text;
                        writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                    }                   
                    else if (c is GroupBox)
                    {                       
                        Check_Last_Control(c, FormName);
                    }
                    else if (c is Panel)
                    {                     
                        Check_Last_Control(c, FormName);
                    }
                }
            }
            catch { }
        }

        private void Check_Last_Control(Control C1,string FormName)
        {
            //FormName = FormName + CurrFIcode + PCURRENT_GCODE;
            foreach (Control c in C1.Controls)
            {
                string ControlName = "";
                if (c is GroupBox)
                {
                    Check_Last_Control(c, FormName);
                }
                else if (c is Panel)
                {
                    Check_Last_Control(c, FormName);
                }
                else if (c.GetType() == typeof(CheckBox))
                {
                    CheckBox CB = (CheckBox)c;
                    ControlName = CB.Name + "[CheckBox]";
                    string Chk_Value = "False";
                    if (CB.Checked)
                        Chk_Value = "True";
                    //writeToIni(Application.StartupPath + "\\ControlSettings.edp", "BACK_UP", "FLAG", "FALSE");
                    writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                }
                else if (c is TextBox)
                {
                    TextBox TB = (TextBox)c;
                    ControlName = TB.Name + "[TextBox]";
                    string Chk_Value = TB.Text;
                    writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                }
                else if (c is RadioButton)
                {
                    RadioButton RB = (RadioButton)c;
                    ControlName = RB.Name + "[RadioButton]";
                    string Chk_Value = "False";
                    if (RB.Checked)
                        Chk_Value = "True";
                    writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                }
                else if (c.GetType() == typeof(ComboBox))
                {
                    ComboBox CB = (ComboBox)c;
                    ControlName = CB.Name + "[ComboBox]";
                    string Chk_Value = CB.Text;
                    writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                }
                else if (c is Label)
                {
                    Label LB = (Label)c;
                    ControlName = LB.Name + "[Label]";
                    string Chk_Value = LB.Text;
                    writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                }
                else if (c is EDPComponent.ComboDialog)
                {
                    EDPComponent.ComboDialog CD = (EDPComponent.ComboDialog)c;
                    ControlName = CD.Name + "[ComboDialog]";
                    string Chk_Value = CD.Text;
                    writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                }
                else if (c is DateTimePicker)
                {
                    DateTimePicker DTP = (DateTimePicker)c;
                    ControlName = DTP.Name + "[DateTimePicker]";
                    string Chk_Value = DTP.Text;
                    writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                }
                else if (c is EDPComponent.DateTimePickerEDP)
                {
                    EDPComponent.DateTimePickerEDP DTP = (EDPComponent.DateTimePickerEDP)c;
                    ControlName = DTP.Name + "[DateTimePickerEDP]";
                    string Chk_Value = DTP.Text;
                    writeToIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName, Chk_Value);
                }
                //else if (c is GroupBox)
                //{
                //    //Control cc = new Control();       
                //    Check_Last_Control(c, FormName);
                //}
                //else if (c is Panel)
                //{
                //    //Control cc = new Control();       
                //    Check_Last_Control(c, FormName);
                //}
            }
        }

        public void Form_Controls_Status_Read(Form Form_Test, string FormName)
        {
            try
            {
                FormName = FormName + CurrFIcode + PCURRENT_GCODE;
                foreach (Control c in Form_Test.Controls)
                {
                    string ControlName = "";
                    if (c.GetType() == typeof(CheckBox))
                    {
                        CheckBox CB = (CheckBox)c;
                        ControlName = CB.Name + "[CheckBox]";                       
                        try
                        {
                            string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                            if (str_val != "" && str_val != null)
                                CB.Checked = Convert.ToBoolean(str_val);
                        }
                        catch { }
                    }
                    else if (c is TextBox)
                    {
                        TextBox TB = (TextBox)c;
                        ControlName = TB.Name + "[TextBox]";
                        try
                        {
                            string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                            if (str_val != "" && str_val != null)
                                TB.Text = str_val;
                        }
                        catch { }
                    }
                    else if (c is RadioButton)
                    {
                        RadioButton RB = (RadioButton)c;
                        ControlName = RB.Name + "[RadioButton]";
                        try
                        {
                            string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                            if (str_val != "" && str_val != null)
                                RB.Checked = Convert.ToBoolean(str_val);
                        }
                        catch { }
                    }
                    else if (c.GetType() == typeof(ComboBox))
                    {
                        ComboBox CB = (ComboBox)c;
                        ControlName = CB.Name + "[ComboBox]";
                        try
                        {
                            string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                            if (str_val != "" && str_val != null)
                                CB.Text = str_val;
                        }
                        catch { }
                    }
                    else if (c is Label)
                    {
                        Label LB = (Label)c;
                        ControlName = LB.Name + "[Label]";
                        try
                        {
                            string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                            if (str_val != "" && str_val != null)
                                LB.Text = str_val;
                        }
                        catch { }
                    }
                    else if (c is EDPComponent.ComboDialog)
                    {
                        EDPComponent.ComboDialog CD = (EDPComponent.ComboDialog)c;
                        ControlName = CD.Name + "[ComboDialog]";
                        try
                        {
                            string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                            if (str_val != "" && str_val != null)
                                CD.Text = str_val;
                        }
                        catch { }
                    }
                    else if (c is DateTimePicker)
                    {
                        DateTimePicker DTP = (DateTimePicker)c;
                        ControlName = DTP.Name + "[DateTimePicker]";
                        try
                        {
                            string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                            if (str_val != "" && str_val != null)
                                DTP.Value = Convert.ToDateTime(str_val);
                        }
                        catch { }
                    }
                    else if (c is EDPComponent.DateTimePickerEDP)
                    {
                        EDPComponent.DateTimePickerEDP DTP = (EDPComponent.DateTimePickerEDP)c;
                        ControlName = DTP.Name + "[DateTimePickerEDP]";
                        try
                        {
                            string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                            if (str_val != "" && str_val != null)
                                DTP.Value = Convert.ToDateTime(str_val); ;
                        }
                        catch { }
                    }
                    else if (c is GroupBox)
                    {
                        Control_Read_And_Set_Upto_Last(c, FormName);
                    }
                    else if (c is Panel)
                    {
                        Control_Read_And_Set_Upto_Last(c, FormName);
                    }                    
                }
            }
            catch { }
        }

        private void Control_Read_And_Set_Upto_Last(Control C1, string FormName)
        {
            //FormName = FormName + CurrFIcode + PCURRENT_GCODE;
            foreach (Control c in C1.Controls)
            {
                string ControlName = "";
                if (c is GroupBox)
                {
                    Control_Read_And_Set_Upto_Last(c, FormName);
                }
                else if (c is Panel)
                {
                    Control_Read_And_Set_Upto_Last(c, FormName);
                }
                else if (c.GetType() == typeof(CheckBox))
                {
                    CheckBox CB = (CheckBox)c;
                    ControlName = CB.Name + "[CheckBox]";
                    try
                    {
                        string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                        if (str_val != "" && str_val != null)
                            CB.Checked = Convert.ToBoolean(str_val);
                    }
                    catch { }
                }
                else if (c is TextBox)
                {
                    TextBox TB = (TextBox)c;
                    ControlName = TB.Name + "[TextBox]";
                    try
                    {
                        string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                        if (str_val != "" && str_val != null)
                            TB.Text = str_val;
                    }
                    catch { }
                }
                else if (c is RadioButton)
                {
                    RadioButton RB = (RadioButton)c;
                    ControlName = RB.Name + "[RadioButton]";
                    try
                    {
                        string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                        if (str_val != "" && str_val != null)
                            RB.Checked = Convert.ToBoolean(str_val);
                    }
                    catch { }
                }
                else if (c.GetType() == typeof(ComboBox))
                {
                    ComboBox CB = (ComboBox)c;
                    ControlName = CB.Name + "[ComboBox]";
                    try
                    {
                        string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                        if (str_val != "" && str_val != null)
                            CB.Text = str_val;
                    }
                    catch { }
                }
                else if (c is Label)
                {
                    Label LB = (Label)c;
                    ControlName = LB.Name + "[Label]";
                    try
                    {
                        string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                        if (str_val != "" && str_val != null)
                            LB.Text = str_val;
                    }
                    catch { }
                }
                else if (c is EDPComponent.ComboDialog)
                {
                    EDPComponent.ComboDialog CD = (EDPComponent.ComboDialog)c;
                    ControlName = CD.Name + "[ComboDialog]";
                    try
                    {
                        string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                        if (str_val != "" && str_val != null)
                            CD.Text = str_val;
                    }
                    catch { }
                }
                else if (c is DateTimePicker)
                {
                    DateTimePicker DTP = (DateTimePicker)c;
                    ControlName = DTP.Name + "[DateTimePicker]";
                    try
                    {
                        string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                        if (str_val != "" && str_val != null)
                            DTP.Value = Convert.ToDateTime(str_val);
                    }
                    catch { }
                }
                else if (c is EDPComponent.DateTimePickerEDP)
                {
                    EDPComponent.DateTimePickerEDP DTP = (EDPComponent.DateTimePickerEDP)c;
                    ControlName = DTP.Name + "[DateTimePickerEDP]";
                    try
                    {
                        string str_val = Convert.ToString(readFromIni(Application.StartupPath + "\\ControlSettings.edp", FormName, ControlName));
                        if (str_val != "" && str_val != null)
                            DTP.Value = Convert.ToDateTime(str_val);
                    }
                    catch { }
                }
            }
        }

        public static void HScrollBarVisible(DataGridView dg)
        {
            bool Scroll_H = false;
            bool Scroll_V = false;
            foreach (Control ctrl in dg.Controls)
            {
                if (ctrl.GetType().ToString() == "System.Windows.Forms.VScrollBar")
                {
                    if (ctrl.Visible == true)
                        Scroll_V = true;
                    else
                        Scroll_V = false;
                }
                else if (ctrl.GetType().ToString() == "System.Windows.Forms.HScrollBar")
                {
                    if (ctrl.Visible == true)
                        Scroll_H = true;
                    else
                        Scroll_H = false;
                }
            }
            //if (!Scroll_V)
            //{
            int Columns_Count = dg.Columns.Count;
            int Total_Columns_Width = 0;
            int Total_Effected_Columns = 0;
            int Last_Visible_Column_Index = 0;
            for (int i = 0; i <= Columns_Count - 1; i++)
            {
                if (dg.Columns[i].Visible == true)
                {
                    if (dg.Columns[i].Width >= 90)
                        Total_Effected_Columns = Total_Effected_Columns + 1;
                    Total_Columns_Width = Total_Columns_Width + dg.Columns[i].Width;
                    Last_Visible_Column_Index = i;
                }
            }

            int Width_Difference = 0;
            int Width_Ratio = 0;
            if (dg.RowHeadersVisible)
                Width_Difference = Math.Abs(Convert.ToInt32((dg.Width - dg.RowHeadersWidth - Total_Columns_Width)));
            else
                Width_Difference = Math.Abs(Convert.ToInt32((dg.Width - Total_Columns_Width)));
            Width_Ratio = Convert.ToInt32(Width_Difference / Total_Effected_Columns);

            if (dg.Width > Total_Columns_Width)
            {
                for (int i = 0; i <= Columns_Count - 1; i++)
                {
                    if (dg.Columns[i].Visible == true)
                    {
                        if (dg.Columns[i].Width >= 90)
                            dg.Columns[i].Width = dg.Columns[i].Width + Width_Ratio;
                    }
                }
            }
            else
            {
                for (int i = 0; i <= Columns_Count - 1; i++)
                {
                    if (dg.Columns[i].Visible == true)
                    {
                        if (dg.Columns[i].Width >= 90)
                            dg.Columns[i].Width = dg.Columns[i].Width - Width_Ratio;
                    }
                }
            }

            Total_Columns_Width = 0;
            for (int i = 0; i <= Columns_Count - 1; i++)
            {
                if (dg.Columns[i].Visible == true)
                    Total_Columns_Width = Total_Columns_Width + dg.Columns[i].Width;
            }
            if (dg.RowHeadersVisible)
                Total_Columns_Width = Total_Columns_Width + dg.RowHeadersWidth;

            dg.Columns[Last_Visible_Column_Index].Width = dg.Columns[Last_Visible_Column_Index].Width - Math.Abs(Total_Columns_Width - dg.Width) - 1;

            if (Scroll_V)
                dg.Columns[Last_Visible_Column_Index].Width = dg.Columns[Last_Visible_Column_Index].Width - 18;
            try
            {
                int Row_Height = dg.Rows[0].Height;
                int Avg_Row_Height = Convert.ToInt32(dg.Height / Row_Height);
                int Total_Row_Height = Avg_Row_Height * Row_Height;
                dg.Height = dg.Height - Math.Abs(dg.Height - Total_Row_Height);
            }
            catch { }
            try
            {
                dg.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dg.AllowUserToResizeColumns = false;
                dg.AllowUserToResizeRows = false;
            }
            catch { }
        }
    }
}
