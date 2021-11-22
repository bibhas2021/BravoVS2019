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

namespace Edpcom
{    
    /// <summary>
    /// Summary description for the class.
    /// </summary>

    public class EDPCommon
    {
        public static string Query, Caption, Header, ClmHeader;
        public static int columnindex;
        public static int qry_dt = 0;        
        public static string StckTb;
        public static ArrayList arr_mod = new ArrayList();        
        public static Hashtable get_code = new Hashtable();
        public static DataSet STCK_DS = new DataSet();
        

        //-------------API Declarations
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32", SetLastError = true)]
        static extern int SetLocaleInfo(int LOCALE_SYSTEM_DEFAULT, int LOCALE_SSHORTDATE, string lpLCData);

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,int Msg, int wParam, int lParam);

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
                (new Microsoft.VisualBasic.Devices.Computer()).Registry.SetValue(@"HKEY_CURRENT_USER\Midasgold\ColorScheme", "Test", this.ApplicationName );
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
                if (value !=Thousand_Sep)
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
                if (value !=CurrentBranch)
                CurrentBranch=value;
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
        public void SetInRegistry(string Settext,string Headname,string path)//leave blank path name if default path name need
        {
            if (path=="")
             path="HKEY_CURRENT_USER\\Midasgold";
            else
             path = "HKEY_CURRENT_USER\\" + path;
            (new Microsoft.VisualBasic.Devices.Computer()).Registry.SetValue(path, Headname, Settext);
        }
        public string GetFromRegisrty(string Headname,string path)//leave blank path name if default path name need
        {
            if (path=="")
             path="HKEY_CURRENT_USER\\Midasgold";
            else
             path = "HKEY_CURRENT_USER\\" + path;
            return (string)((new Microsoft.VisualBasic.Devices.Computer()).Registry.GetValue(path, Headname, null));
        }
        public void CreateSubkey(string path)//registry subkey creation
        {
            path="HKEY_CURRENT_USER\\"+path;
            (new Microsoft.VisualBasic.Devices.Computer()).Registry.CurrentUser.CreateSubKey(path);
        }
        public string readFromIni(string IniFilePath, string Section, string Key)
        {
          string path = IniFilePath;
          StringBuilder temp = new StringBuilder(255);
          int i = GetPrivateProfileString(Section,Key,"",temp,255, path);
          return temp.ToString();
        }
        public void writeToIni(string IniFilePath, string Section, string Key, string Value)
        {
          string path = IniFilePath;
          try
          {
            if(System.IO.File.Exists(path) == false)
            {
                System.IO.File.Create(path);
            }
            WritePrivateProfileString(Section,Key,Value,path);
          }
          catch
          {}
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

        }*///------------------------------------------------------------------
        //generate document nymber for respective voucher
        public string GetDocNumber(Int64 Desccode,string Tentry)
        {
            try
            {
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
                    mycmd = new SqlCommand("select * from docgen where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'", edpcon.mycon);
                    mydr = mycmd.ExecuteReader();
                    mydr.Read();
                    docnumber = mydr.GetValue(4).ToString();
                    mydr.Close();
                    string sep="",num=""; int i = 0;
                    Int64 newnum =0;
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
        public void MaketheformMovable(Label MoveWith,Form ToMove)
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
                if ((Tentry.Trim() == "S") || (Tentry.Trim() == "8") || (Tentry.Trim() == "9") || (Tentry.Trim() == "C"))
                    command = "insert into typedoc(FICode, GCODE, T_ENTRY, Desccode, Type_Desc, Specific_Acc, METHOD, Effect_Amt, Req_Acc) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'" + Type + "',1, 'A',1,1)";
                else if (Tentry.Trim() == "M")
                    command = "insert into typedoc(FICode, GCODE, T_ENTRY, Desccode, Type_Desc, Specific_Acc, METHOD, Effect_Amt, Req_Acc) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'" + Type + "',0, 'A',null,1)";
                else 
                    command = "insert into typedoc(FICode, GCODE, T_ENTRY, Desccode, Type_Desc, Specific_Acc, METHOD, Effect_Amt, Req_Acc) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'" + Type + "',0, 'A',null,0)";
                SqlCommand mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                mycmd.ExecuteNonQuery();

                command = "insert into docnumber(FICode, GCODE, T_ENTRY, TYPE_NAME, DESCCODE, TYPE_DESC, METHOD, PREPOS, SUFPOS, padding, doc_pos, no_sep, prefix, suffix) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "','" + Type + "'," + code + ",'" + Type + "D','A','1','3','4','2','1','" + prefix + "','" + suffix + "')";
                mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                mycmd.ExecuteNonQuery();

                command = "insert into docgen values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'0')";
                mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                mycmd.ExecuteNonQuery();
                //Auto Account Posting for sale ,purchase and Short sale
                if ((Tentry.Trim() == "S") || (Tentry.Trim() == "8") || (Tentry.Trim() == "9") || (Tentry.Trim() == "C"))
                {
                    DataSet ds = new DataSet();
                    ArrayList glcode=new ArrayList();
                    glcode.Add(5); glcode.Add(8); glcode.Add(9); glcode.Add(10); glcode.Add(13); glcode.Add(20); glcode.Add(21); glcode.Add(22); glcode.Add(23);
                    string ttype = "", PlusMinus = "";
                    if ((Tentry.Trim() == "S") || (Tentry.Trim() == "9"))
                        ttype = "S";
                    else ttype = "P";
                    command = "select Description from BillTerms where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and TERMSTYPE='" + ttype + "'";
                    mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                    SqlDataAdapter da = new SqlDataAdapter(mycmd);
                    da.Fill(ds, "billterms");
                    string form = "", Effect = "";
                    for (int i = 1; i <= ds.Tables["billterms"].Rows.Count; i++)
                    {
                        if (i == 1 || i == 2 || i == 3)
                        {
                            if (i == 1)
                            {
                                PlusMinus = "Plus";
                                Effect = "1";
                            }
                            else
                            {
                                Effect = "0";
                                if ((Tentry.Trim() == "S") || (Tentry.Trim() == "9"))
                                    PlusMinus = "Minus";
                                else PlusMinus = "Plus";
                            }
                        }
                        else
                        {
                            if (i == 8 || i == 9)
                            {
                                Effect = "1";
                            }
                            else
                            {
                                Effect = "0";
                            }
                            if ((Tentry.Trim() == "S") || (Tentry.Trim() == "9"))
                                PlusMinus = "Minus";
                            else PlusMinus = "Plus";
                        }
                        command = "insert into accpost(FICode, GCODE, T_ENTRY, DESCCODE, Sl_No, BTerms_Desc, Term_Type, Tax, Glcode, Formula, PlusMinus, Type_Code, EffectAmt) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'" + i.ToString() + "','" + ds.Tables["billterms"].Rows[i - 1][0] + "','" + ttype + "',null," + glcode[i-1] + ",'" + form + "','" + PlusMinus + "',1," + Effect+")";
                        mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                        mycmd.ExecuteNonQuery();
                        if (i == 1)
                        {
                            form = form + i.ToString();
                        }
                        else
                        {
                            form = form + "+" + i.ToString();
                        }
                    }
                }
                else if ((Tentry.Trim() == "M"))
                {
                    DataSet ds = new DataSet();
                    ArrayList glcode = new ArrayList();
                    glcode.Add(25); //glcode.Add(8); glcode.Add(9); glcode.Add(10); glcode.Add(13); glcode.Add(20); glcode.Add(21); glcode.Add(22); glcode.Add(23);
                    string ttype = "P", PlusMinus = "Plus";
                    command = "select Description from BillTerms where ficode='" + CurrentFicode + "' and gcode='" + PCURRENT_GCODE + "' and TERMSTYPE='" + ttype + "'";
                    mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                    SqlDataAdapter da = new SqlDataAdapter(mycmd);
                    da.Fill(ds, "billterms");
                    string form = "", Effect = "";
                    Effect = "1";
                    command = "insert into accpost(FICode, GCODE, T_ENTRY, DESCCODE, Sl_No, BTerms_Desc, Term_Type, Tax, Glcode, Formula, PlusMinus, Type_Code, EffectAmt) values('" + CurrentFicode + "','" + PCURRENT_GCODE + "','" + Tentry + "'," + code + ",'1','" + ds.Tables["billterms"].Rows[0][0] + "','" + ttype + "',null," + glcode[0] + ",'" + form + "','" + PlusMinus + "',1," + Effect + ")";
                    mycmd = new SqlCommand(command, edpcon.mycon, Tran);
                    mycmd.ExecuteNonQuery();
                }
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
            string sql = "",PCurrGcode="";
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
                sql = "insert into iglmst(ficode,pcode,gcode,CO_NAME,CO_ALIAS,INV_TYPECODE,CLASSCODE,FACE_VALUE,BUS_TYPE,OPSTK,CURSTK,ISIN_NO,Applied_Stat,invs_ac,ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac,Exp_Date,Unit_Of_Mez,Strike_Price,Lot_Size,Lot_Unit) select '" + Ficode + "',pcode,'" + Gcode + "',CO_NAME,CO_ALIAS,INV_TYPECODE,CLASSCODE,FACE_VALUE,BUS_TYPE,OPSTK,CURSTK,ISIN_NO,Applied_Stat,invs_ac,ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac,Exp_Date,Unit_Of_Mez,Strike_Price,Lot_Size,Lot_Unit from iglmst WHERE FICODE='" + Ficode + "' and gcode='" + PCurrGcode + "'";
                SqlCommand cmd = new SqlCommand(sql, edpcon.mycon);
                cmd.ExecuteNonQuery();
                sql = "update iglmst set OPSTK=0,CURSTK=0 where FICODE='" + Ficode + "' and gcode='" + Gcode + "'";
                cmd = new SqlCommand(sql, edpcon.mycon);
                cmd.ExecuteNonQuery();
            }
            catch { //EDPMessage.Show("Product transfer unsuccessfull.");
            }
        }
        public string getCurrGcode(string ficode)
        {
            string currg = "";
            EDPConnection con = new EDPConnection();
            EDPCommon com=new EDPCommon();
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
        public void UpdateMidasLog(Form FormName,Boolean Opn_Close)
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
                    SqlDataReader dr ;
                    dr = sqlcmd.ExecuteReader();
                    dr.Read();
                    FormName.Tag = dr.GetInt32(0);
                }
                else
                {
                    string Sql = "Update Midaslog set DATE_TO='" + getSqlDateStr(DateTime.Today) + "',TIME_TO='" + DateTime.Now.ToLongTimeString() + "' where autoincre="+FormName.Tag;
                    SqlCommand  sqlcmd = new SqlCommand(Sql, edpcon.mycon);
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
            try
            {

                int xlsv;
                edpcon.Open();
                if (Opn_Close)
                {
                    if (Exclusive)
                    {
                        xlsv = 1;
                    }
                    else
                    {
                        xlsv = 0;
                    }

                    string Sql = "insert into wacclog(LOG_UCODE, LOG_GCODE, LOG_CCODE,FORM_NAME, FORM_CODE, DATE_FROM, TIME_FROM,LOG_STAT, MACHINE_NAME, Exclusive, session_no)";
                    Sql = Sql + "values('" + PCURRENT_USER + "','" + PCURRENT_GCODE + "','" + CurrentFicode + "','" + FormName.Name + "'," + 0 + ",'" + getSqlDateStr(DateTime.Today) + "','" + DateTime.Now.ToLongTimeString() + "'," + 0 + ",'" + Environment.MachineName.ToString() + "'," + xlsv + "," + CURRENTSESSION + ")";
                    SqlCommand sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                    Sql = "select max(autoincre) from wacclog";
                    sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    SqlDataReader dr;
                    dr = sqlcmd.ExecuteReader();
                    dr.Read();
                    FormName.Tag = dr.GetInt32(0);
                }
                else
                {
                    string Sql = "Update wacclog set DATE_TO='" + getSqlDateStr(DateTime.Today) + "',TIME_TO='" + DateTime.Now.ToLongTimeString() + "' where autoincre=" + FormName.Tag;
                    SqlCommand sqlcmd = new SqlCommand(Sql, edpcon.mycon);
                    sqlcmd.ExecuteNonQuery();
                }
                edpcon.Close();
            }
            catch (Exception ex)
            {
                edpcon.Close();
                MessageBox.Show(ex.ToString());
            }


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
        public void ChangeTabColor(object sender,DrawItemEventArgs e,TabControl TabControlName,Color FocusedBackColor, Color FocusedForeColor, Color NonFocusedBackColor, Color NonFocusedForeColor)
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
        public bool CheckMdiChild(Form childform,Form parent)
        {
            try
            {
                bool childopen = false;
                Form[] frmall = parent.MdiChildren;
                foreach (Form frm in frmall)
                {
                    Type tp = frm.GetType();
                    Type tp1 = childform.GetType();
                    EDPComponent.FormBaseERP from;
                    EDPComponent.FormBase from1;
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
                    if (tp.BaseType.Name == "Form")
                    {
                        from2 = (Form)frm;
                        name1 = from2.Text;
                    }
                    if (name == name1)
                    {
                        childopen = true;
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
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg,IntPtr wParam, IntPtr lParam);
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
        public DataTable  Import_Sql(string source)
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
                    MessageBox.Show(ex.GetBaseException().ToString());
                }
                return ds.Tables["FORMULATAB"];
        }

        public bool RunCommand(string Command)
        {
            EDPConnection edpcon = new EDPConnection();
            edpcon.Open();
            bool ret = RunCommand(Command, edpcon.mycon);
            return ret;
        }
        public bool RunCommand(string Command, SqlConnection Con)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand(Command, Con);
            result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            return result;
        }
        public bool RunCommand(string Command, SqlConnection Con,SqlTransaction SqlT)
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

        public DataSet GetDataset(string SelectCommand,DataSet ds)
        {
            return GetDataset(SelectCommand, "data", ds);
        }
        public DataSet GetDataset(string SelectCommand,string TableName,DataSet ds)
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
            string s1, s2, s10 = "",str,strl="";
            double GetVal=0.00;
            try
            {
                if (Val < 0)
                    GetVal = Val*(-1);
                else
                    GetVal = Val;

                string ss = DesmPlc_Edpcom(GetVal.ToString());
                s10 = ss+" ";
                int StrLen = ss.Length;
                int sl = ss.IndexOf(".");
                str = ss.Substring(0, sl);
                strl = ss.Substring(sl , StrLen - sl);
                switch (sl.ToString())
                {
                    case "4":
                        s1 = str.Substring(0, 1);
                        s2 = str.Substring(1, sl - 1);
                        s10 = s1 + "," + s2 +" ";
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

        public string GetAmountFormat(double Val,int DV)
        {
            string s1, s2, s10 = "", str, strl = "";
            double GetVal=0.00;
            try
            {
                if (Val < 0)
                    GetVal = Val * (-1);
                else
                    GetVal = Val;

                string ss = GetVal.ToString(SetDecimalPlace(DV));
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

        public string GetAmountFormat(double Val, int DV,string CT,string Sep)
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

                    string ss = GetVal.ToString(SetDecimalPlace(DV));
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

                    string ss = GetVal.ToString(SetDecimalPlace(DV));
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
            string CT="";
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

        public static void MLOV_EDP(string query, string caption, string header, string clmheader, int index, string stcktb)
        {
            Query = query;
            Caption = caption;
            Header = header;
            ClmHeader = clmheader;
            columnindex = index;
            StckTb = stcktb;
            qry_dt = 0;
            frmListAddRemoveTree lstadd = new frmListAddRemoveTree();
            lstadd.ShowDialog();
        }
    }
}
