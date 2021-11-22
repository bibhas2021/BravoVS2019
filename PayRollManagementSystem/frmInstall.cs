using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using Edpcom;
using EDPMessageBox;
using Microsoft.VisualBasic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace PayRollManagementSystem
{
    public partial class frmInstall : Form//EDPComponent.FormBase//EDPComponent.FormBaseMidium
    {
        SqlCommand mycmd;
        Edpcom.EDPConnection edpcon = new EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        SqlDataReader myrd;
        ArrayList cocode = new ArrayList();
        ArrayList ficodelist = new ArrayList();
        SqlTransaction tran;
        private string gcode;
        private string ficode;
        private bool NewIns;
        int copy=0;
        int cmbIndex = 0, STATECODE = 0, COUNTRYCODE = 0;
        int ChkCount = 0;
        string MoneyName;
        bool chk_Date_First = false;
        string Config_Date_Start = "", Config_Month_Start = "";

        public frmInstall()
        {
            InitializeComponent();
        }
        private void GetGcode()//FOR CHECKING GCODE IS UNIQUE OR NOT
        {
            if ((NewIns) && (!edpcom.FirstTimeInstall))
            {
                string sqlstr = "select * from company WHERE CO_NAME='"+cboCompanyname.Text.Trim()+"'";
                mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                myrd = mycmd.ExecuteReader();
                if (myrd.Read())
                {
                    gcode = myrd.GetString(0);
                    myrd.Close();
                }
                else 
                {
                    myrd.Close();
                    sqlstr = "select max(gcode) from company ";
                    mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                    myrd = mycmd.ExecuteReader();
                    if (myrd.Read())
                    {
                        gcode = myrd.GetString(0);
                        myrd.Close();
                        sqlstr = "select * from company where gcode>"+gcode;
                        mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                        myrd = mycmd.ExecuteReader();  
                        while (myrd.Read())
                            gcode = myrd.GetString(2);
                        gcode = Convert.ToString(int.Parse(gcode) + 1);
                        myrd.Close();
                    }       
                }
            }
            else if ((NewIns) && (edpcom.FirstTimeInstall))
            {
                gcode = "1";
            }
            if (!NewIns)
            {
                gcode = cocode[cboCompanyname.SelectedIndex].ToString();
            }
            myrd.Close();
        }
        private void GetFICode()//FOR UNIQUE FICODE (FINANACIAL YEAR CODE)
        {
            if (!edpcom.FirstTimeInstall)
            {
                string sqlstr = "select * from FICODEGEN where START_DATE='" + edpcom.getSqlDateStr(mtxStrdate.Value) + "' AND END_DATE='" + edpcom.getSqlDateStr(mtxEnddate.Value) + "'";
                mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                myrd.Close();
                myrd = mycmd.ExecuteReader();
                if (myrd.Read())
                {
                    ficode = myrd.GetString(2);
                }
                else
                {
                    myrd.Close();
                    sqlstr = "select max(ficode) from ficodegen";
                    mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                    myrd = mycmd.ExecuteReader();
                    if (myrd.Read())
                    {
                        ficode = myrd.GetString(0);
                        myrd.Close();
                        sqlstr = "select * from ficodegen where ficode>" + ficode;
                        mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                        myrd = mycmd.ExecuteReader();
                        while (myrd.Read())
                            ficode = myrd.GetString(2);
                        ficode = Convert.ToString(long.Parse(ficode) + 1);
                        myrd.Close();
                    }
                    sqlstr = "INSERT INTO FICODEGEN VALUES('" + edpcom.getSqlDateStr(mtxStrdate.Value) + " ','" + edpcom.getSqlDateStr(mtxEnddate.Value) + "','" + ficode + "')";
                    mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                    myrd.Close();
                    myrd = mycmd.ExecuteReader();
                }
                myrd.Close();
            }
            else
            {
                ficode = "1";
                string sqlstr = "INSERT INTO FICODEGEN VALUES('" + edpcom.getSqlDateStr(mtxStrdate.Value) + " ','" + edpcom.getSqlDateStr(mtxEnddate.Value) + "','" + ficode + "')";
                mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                myrd.Close();
                myrd = mycmd.ExecuteReader();
                myrd.Close();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)// insert company
        {
            if (COUNTRYCODE == 0)
            {
                EDPMessage.Show("Country Code can't null. Please select the Country.");
                return;
            }
            if (STATECODE == 0)
            {
                EDPMessage.Show("State Code can't null. Please select the State.");
                return;
            }
            this.Height = 440;
            Control_Enable_False();
            if (mtxStrdate.Value < mtxEnddate.Value)
            {
                if (cboCompanyname.Text != "")
                {                    
                    GetFICode();
                    GetGcode();
                    myrd.Close();
                    string name = cboCompanyname.Text.Trim();
                    string sqlstr = "select * from COMPANY where CO_NAME='" + name + "' and FICODE='" + ficode + "'";
                    mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                    myrd.Close();
                    myrd = mycmd.ExecuteReader();
                    if (myrd.Read())
                    {
                        EDPMessage.Show("Comapany Already exist please change the Name or Financial period.", "Change!", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                        myrd.Close();
                        Control_Enable_True();
                        return;
                    }
                    sqlstr = "";
                    sqlstr = "delete  from TypeMast_Config where GCODE='" + gcode.Trim() + "' and FICODE='" + ficode + "'";
                    mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                    myrd.Close();
                    myrd = mycmd.ExecuteReader();

                    sqlstr = "";
                    sqlstr = "delete  from TypeMast where GCODE='" + gcode.Trim() + "' and FICODE='" + ficode + "'";
                    mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                    myrd.Close();
                    myrd = mycmd.ExecuteReader();

                    sqlstr = "INSERT INTO company(CO_CODE, GCODE,ficode, CO_NAME, CO_SDATE, CO_EDATE, CO_VER, CO_CDT, State_Code,Country_Code) ";
                    sqlstr = sqlstr + "values('" + gcode.Trim() + "','" + gcode.Trim() + "','" + ficode.Trim() + "','" + name + "','" + edpcom.getSqlDateStr(mtxStrdate.Value) + "','" + edpcom.getSqlDateStr(mtxEnddate.Value) + "','" + edpcom.PEXE_VERSION + "','" + edpcom.getSqlDateStr(DateTime.Now) + "'," + STATECODE + "," + COUNTRYCODE + ")";
                    try
                    {
                        myrd.Close();
                        mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                        mycmd.ExecuteNonQuery();
                        if (Information.IsNumeric(edpcom.CurrentSuperuser) == true)
                        {
                            if (edpcom.CurrentSuperuser.Trim() != "1")
                            {
                                sqlstr = "insert into ACCESSBRANCH(USER_CODE,ficode,GCODE,BRNCH_CODE) VALUES('" + edpcom.CurrentSuperuser + "','" + ficode.Trim() + "','" + gcode.Trim() + "',0)";
                                myrd.Close();
                                mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                                mycmd.ExecuteNonQuery();
                                sqlstr = "insert into ACCESSBRANCH(USER_CODE,ficode,GCODE,BRNCH_CODE) VALUES('" + edpcom.CurrentSuperuser + "','" + ficode.Trim() + "','" + gcode.Trim() + "',1)";
                                myrd.Close();
                                mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                                mycmd.ExecuteNonQuery();
                                sqlstr = "INSERT INTO ACCESS(USER_CODE,ficode,GCODE) VALUES('" + edpcom.CurrentSuperuser + "','" + ficode.Trim() + "','" + gcode.Trim() + "')";
                                myrd.Close();
                                mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                                mycmd.ExecuteNonQuery();
                                //sqlstr = "insert into UserControl(Ficode,Gcode,UGcode,USGcode,SuperUser,USER_CODE) values('" + ficode.Trim() + "','" + gcode.Trim() + "','" + EDPComm.CurrentUGcode + "','0','" + EDPComm.CurrentSuperuser + "','" + EDPComm.PCURRENT_USER + "')";
                                //myrd.Close();
                                //mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
                                //mycmd.ExecuteNonQuery();
                            }
                        }
                        tran.Commit();
                        globallocal();

                        // S Dutta (30.11.13) if EnvironMent Envolop (text file) is petrol thent Account Operating Charce , Salse A/C & Service Tax Ledger Creat Otherwise Not Create.
                        if (edpcom.EnvironMent_Envelope != "Petrol")
                        {
                            edpcom.RunCommand("delete from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and glcode in(51,52,1251)");
                            edpcom.RunCommand("delete from vatmaster where ficode='" + ficode + "' and gcode='" + gcode + "' and VAT_CODE in(1251)");
                        }
                        //End (30.11.13)

                        //if (!NewIns)
                        //{
                        //    try
                        //    {
                        //        if (edpcom.GetDatatable("Select * from company where ficode='" + ficode + "' and gcode<>'" + gcode + "'").Rows.Count == 0)
                        //        {
                        //            string fi = ficodelist[ficodelist.Count - 1].ToString();
                        //            edpcom.RunCommand("delete from invmst where ficode='" + ficode + "'");
                        //            string sql = "insert into invmst(FICode, Itype, Icode, Idesc, Iparent, IAlias, invs_ac, ltcg_ac, ltcl_ac, stcg_ac, stcl_ac, prch_ac, sls_ac, stck_ac, T_entryIn, T_entryOut, Actv_Val) select  '" + ficode + "', Itype, Icode, Idesc, Iparent, IAlias, invs_ac, ltcg_ac, ltcl_ac, stcg_ac, stcl_ac, prch_ac, sls_ac, stck_ac, T_entryIn, T_entryOut, Actv_Val from invmst where ficode='" + fi + "'";
                        //            edpcom.RunCommand(sql);
                        //            sql = "insert into iglmst(ficode,pcode,gcode,CO_NAME,CO_ALIAS,INV_TYPECODE,CLASSCODE,FACE_VALUE,BUS_TYPE,OPSTK,CURSTK,ISIN_NO,Applied_Stat,invs_ac,ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac,Exp_Date,Unit_Of_Mez,Strike_Price,Lot_Size,Lot_Unit) select '" + ficode + "',pcode,'" + gcode + "',CO_NAME,CO_ALIAS,INV_TYPECODE,CLASSCODE,FACE_VALUE,BUS_TYPE,0,0,ISIN_NO,Applied_Stat,invs_ac,ltcg_ac,ltcl_ac,stcg_ac,stcl_ac,prch_ac,sls_ac,stck_ac,'',0,Strike_Price,Lot_Size,0 from iglmst WHERE FICODE='" + fi + "' and gcode='" + gcode + "'";
                        //            edpcom.RunCommand(sql);
                        //        }
                        //    }
                        //    catch { }
                        //}
                       
                        //edpcom.UpdateExchang(ficode, gcode);                       
                        edpcom.UpdateIGLMST(ficode, gcode);                        
                        //AdvancedledgerSetting();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        EDPMessage.Show(ex.Message);
                    }
                    //this.Size = new Size(389, 331);
                    timer1.Enabled = true;
                }
                else
                {
                    EDPMessage.Show("Company Name Can not left blank!", "CheckName", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_WARNING);
                    Control_Enable_True();
                    cboCompanyname.Focus();
                    return;
                }
            }
            else
            {
                EDPMessage.Show("Starting Date Must be less then End date", "CheckDate", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_WARNING);
                Control_Enable_True();
                mtxEnddate.Focus();
                return;
            }

            //=================== Supper Set Configuration  For Waccoption / Menu Creation =========== (Pradipta 29-04-2013)
            common.First_Time_Load = false;
            edpcom.FirstTimeInstall = true;

            DataTable dt_T_Entry = edpcom.GetDatatable("SELECT DISTINCT T_ENTRY FROM TypeMast WHERE FICODE='" + ficode + "' AND GCODE='" + gcode + "'");
            if (dt_T_Entry.Rows.Count > 0)
            {
                for (int i = 0; i <= dt_T_Entry.Rows.Count - 1; i++)
                {
                    string str_T_Entry = Convert.ToString(dt_T_Entry.Rows[i]["T_ENTRY"]);
                    edpcom.AutoDocTypeCreate(ficode, gcode, Convert.ToString(str_T_Entry), "1");
                }
            }
            Configuration_Menu_TypeDoc_Settings();

            timer1.Enabled = true;            
            //============================== End ===========================================================================
                    
        }

        private void Configuration_Menu_TypeDoc_Settings()
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
                                    else if (str == "UNIT_UNIT")
                                        chk_str = 4;
                                    else
                                        chk_str = 0;
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
                                        edpcom.RunCommand("UPDATE WACCOPTN SET BOOL_VAL='" + Bool_Value + "',STR_VAL='" + Str_Val + "' WHERE FICODE='" + ficode + "' AND GCODE='" + gcode + "' AND SeriesNo='" + Series_Code.Trim() + "'");
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
                                if ((chk_str == 3) && (StrLine_WACC.Length > 2))
                                {
                                    edpcon.Open();
                                    string Tentry = "", OptionCode = "", Script = "";

                                    OptionCode = StrLine_WACC[0];
                                    Tentry = StrLine_WACC[1];
                                    //if (StrLine_WACC[2] == "")
                                    //    ENABLE_MENU = "FALSE";
                                    //else
                                    //    ENABLE_MENU = StrLine_WACC[2];
                                    Script = StrLine_WACC[2];
                                    //if (StrLine_WACC[4] == "")
                                    //    TOOLBARBTN = "FALSE";
                                    //else
                                    //    TOOLBARBTN = StrLine_WACC[4];

                                    try
                                    {
                                        edpcom.RunCommand("UPDATE TypeDoc_Config SET Script='" + Script + "' WHERE OPTION_CODE='" + OptionCode.Trim() + "' and T_ENTRY='" + Tentry + "' and Ficode='" + ficode + "' and gcode='" + gcode + "' ");
                                    }
                                    catch { }
                                    edpcon.Close();
                                }
                                if ((chk_str == 4) && (StrLine_WACC.Length > 0))
                                {
                                    if (Convert.ToString(StrLine_WACC[0]) != "[UNIT_UNIT]")
                                    {
                                        int uc = 1;
                                        for (int P = 0; P <= StrLine_WACC.Length - 1; P++)
                                        {
                                            uc++;
                                            edpcom.RunCommand("INSERT INTO UNIT (FICODE,GCODE,UCODE,UDESC,DESM_PLACE) VALUES('" + ficode + "','" + gcode + "'," + uc + ",'" + StrLine_WACC[P] + "',0)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }

        }

        //============================= Pradipta ===============================
        //private void AdvancedledgerSetting()
        //{
        //    try
        //    {
        //        Int64 invcode;
        //        Int64 ltcgcode;
        //        Int64 ltclcode;
        //        Int64 stcgcode;
        //        Int64 stclcode;
        //        Int64 prchcode;
        //        Int64 slscode;
        //        Int64 stckcode;
        //        Int64 profcode;
        //        Int64 losscode;

        //        Int64 EQLDiv,Debn,MFDiv,InsBonus,FDInt,BondInt,BGSInt,PIRent;
        //        string iglmstupdt;

        //        prchcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Purchase of Shares'"));
        //        slscode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Sale of Shares'"));
        //        stckcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Stock of Shares'"));
        //        profcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Profit on Sales'"));
        //        losscode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Loss on Sales'"));
        //        invcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Investment In Shares'"));
        //        ltcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Gain'"));
        //        ltclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Loss'"));
        //        stcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Gain'"));
        //        stclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Loss'"));
        //        EQLDiv = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Dividend Income Received'"));
        //        iglmstupdt = "update InvMst set prch_ac=" + prchcode + ",sls_ac=" + slscode + ",stck_ac=" + stckcode + ",invs_ac=" + invcode + ",   ltcg_ac=" + ltcgcode + ",ltcl_ac=" + ltclcode + ",stcg_ac=" + stcgcode + " ,stcl_ac=" + stclcode + " ,Proftrad_ac=" + profcode + ",Losstrad_ac=" + losscode + ",rs_Div=" + EQLDiv;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 18 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== Eq shares 19

        //        iglmstupdt = "";
        //        invcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Investment in Debentures'"));
        //        ltcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Gain'"));
        //        ltclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Loss'"));
        //        stcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Gain'"));
        //        stclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Loss'"));
        //        Debn = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Interest Received on Debenture'"));
        //        iglmstupdt = "update InvMst set invs_ac=" + invcode + ", ltcg_ac=" + ltcgcode + ",ltcl_ac=" + ltclcode + ",stcg_ac=" + stcgcode + " ,stcl_ac=" + stclcode + ",rs_Deb=" + Debn; 
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 19 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== Deb 20

        //        iglmstupdt = "";
        //        invcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Investment In Mutual Funds'"));
        //        ltcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Gain'"));
        //        ltclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Loss'"));
        //        stcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Gain'"));
        //        stclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Loss'"));
        //        MFDiv = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Dividend Income Received'"));
        //        iglmstupdt = "update InvMst set invs_ac=" + invcode + ", ltcg_ac=" + ltcgcode + ",ltcl_ac=" + ltclcode + ",stcg_ac=" + stcgcode + " ,stcl_ac=" + stclcode + ",rs_Div=" + MFDiv;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 24 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== Units 25

        //        iglmstupdt = "";
        //        invcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Investment In Mutual Funds'"));
        //        ltcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Gain'"));
        //        ltclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Loss'"));
        //        stcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Gain'"));
        //        stclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Loss'"));
        //        MFDiv = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Dividend Income Received'"));
        //        iglmstupdt = "update InvMst set invs_ac=" + invcode + ", ltcg_ac=" + ltcgcode + ",ltcl_ac=" + ltclcode + ",stcg_ac=" + stcgcode + " ,stcl_ac=" + stclcode + ",rs_Div=" + MFDiv;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 29 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== ETFund

        //        iglmstupdt = "";
        //        invcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Insurance Premium Paid'"));
        //        InsBonus = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Insurance Bonus Received'"));
        //        iglmstupdt = "update InvMst set invs_ac=" + invcode + ",rs_Bonus=" + InsBonus;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 13 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== traditional 16

        //        iglmstupdt = "";
        //        invcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Investment in ULIP'"));
        //        iglmstupdt = "update InvMst set invs_ac=" + invcode;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 14 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== Ulip 17

        //        iglmstupdt = "";
        //        invcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Investment in Fixed Deposit'"));
        //        FDInt = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Interest Received from FD'"));
        //        iglmstupdt = "update InvMst set invs_ac=" + invcode + ",rs_Interest=" + FDInt;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 22 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== FD Banks 23

        //        iglmstupdt = "";
        //        invcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Investment in Bullion'"));
        //        ltcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Gain'"));
        //        ltclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Loss'"));
        //        stcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Gain'"));
        //        stclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Loss'"));
        //        iglmstupdt = "update InvMst set invs_ac=" + invcode + ", ltcg_ac=" + ltcgcode + ",ltcl_ac=" + ltclcode + ",stcg_ac=" + stcgcode + " ,stcl_ac=" + stclcode;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 30 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== Bulln

        //        iglmstupdt = "";
        //        invcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Investment in Bonds'"));
        //        ltcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Gain'"));
        //        ltclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Loss'"));
        //        stcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Gain'"));
        //        stclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Loss'"));
        //        BondInt = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Interest Received from Bonds'"));
        //        iglmstupdt = "update InvMst set invs_ac=" + invcode + ", ltcg_ac=" + ltcgcode + ",ltcl_ac=" + ltclcode + ",stcg_ac=" + stcgcode + " ,stcl_ac=" + stclcode + ",rs_Interest=" + BondInt;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 31 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== Bnds

        //        iglmstupdt = "";
        //        invcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Investment in Govt. Securities'"));
        //        ltcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Gain'"));
        //        ltclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Loss'"));
        //        stcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Gain'"));
        //        stclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Loss'"));
        //        BGSInt = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Interest Received from Govt. Securities'"));
        //        iglmstupdt = "update InvMst set invs_ac=" + invcode + ", ltcg_ac=" + ltcgcode + ",ltcl_ac=" + ltclcode + ",stcg_ac=" + stcgcode + " ,stcl_ac=" + stclcode + ",rs_Interest=" + BGSInt;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 32 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== GovtSec

        //        iglmstupdt = "";
        //        invcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Investment in Immovable'"));
        //        ltcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Gain'"));
        //        ltclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Long Term Capital Loss'"));
        //        stcgcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Gain'"));
        //        stclcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Short Term Capital Loss'"));
        //        PIRent = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Rent Received from House hold properties'"));
        //        iglmstupdt = "update InvMst set invs_ac=" + invcode + ", ltcg_ac=" + ltcgcode + ",ltcl_ac=" + ltclcode + ",stcg_ac=" + stcgcode + ",stcl_ac=" + stclcode + " ,rs_Rent=" + PIRent;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 33 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== Prop
                                
        //        iglmstupdt = "";
        //        prchcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Trading in Commodity Purchase'"));                
        //        slscode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Trading in Commodity Sales'"));
        //        stckcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Outstanding Contracts Commodity Futures'"));
        //        profcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Profit from Trading in Commodities'"));
        //        losscode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Loss from Trading in Commodities'"));                
        //        iglmstupdt = "update InvMst set prch_ac=" + prchcode + ",sls_ac=" + slscode + ",stck_ac=" + stckcode + ",Proftrad_ac=" + profcode + ",Losstrad_ac=" + losscode;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 25 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== Metals 26

        //        iglmstupdt = "";
        //        prchcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Trading in Commodity Purchase'"));
        //        slscode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Trading in Commodity Sales'"));
        //        stckcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Outstanding Contracts Commodity Futures'"));
        //        profcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Profit from Trading in Commodities'"));
        //        losscode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Loss from Trading in Commodities'"));
        //        iglmstupdt = "update InvMst set prch_ac=" + prchcode + ",sls_ac=" + slscode + ",stck_ac=" + stckcode + ",Proftrad_ac=" + profcode + ",Losstrad_ac=" + losscode;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 26 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== Agricultural 27

        //        iglmstupdt = "";
        //        prchcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Trading in Forex Derivatives Purchase'"));
        //        slscode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Trading in Forex Derivatives Sales'"));
        //        stckcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Outstanding Contracts Forex Derivatives'"));
        //        profcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Profit from Trading in Forex Derivatives'"));
        //        losscode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Loss from Trading in Forex Derivatives'"));
        //        iglmstupdt = "update InvMst set prch_ac=" + prchcode + ",sls_ac=" + slscode + ",stck_ac=" + stckcode + ",Proftrad_ac=" + profcode + ",Losstrad_ac=" + losscode;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 34 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== Forex

        //        iglmstupdt = "";
        //        prchcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Trading in F&O Purchase'"));
        //        slscode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Trading in F&O Sales'"));
        //        stckcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Outstanding Contracts Futures'"));
        //        profcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Profit from Trading in F&O'"));
        //        losscode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Loss from Trading in F&O'"));
        //        iglmstupdt = "update InvMst set prch_ac=" + prchcode + ",sls_ac=" + slscode + ",stck_ac=" + stckcode + ",Proftrad_ac=" + profcode + ",Losstrad_ac=" + losscode;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 20 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== Deriv-Fut 21

        //        iglmstupdt = "";
        //        prchcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Trading in F&O Purchase'"));
        //        slscode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Trading in F&O Sales'"));
        //        stckcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Outstanding Contracts Option'"));
        //        profcode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Profit from Trading in F&O'"));
        //        losscode = Convert.ToInt64(Getresult("select glcode from glmst where ficode='" + ficode + "' and gcode='" + gcode + "' and ldesc='Loss from Trading in F&O'"));
        //        iglmstupdt = "update InvMst set prch_ac=" + prchcode + ",sls_ac=" + slscode + ",stck_ac=" + stckcode + ",Proftrad_ac=" + profcode + ",Losstrad_ac=" + losscode;
        //        iglmstupdt = iglmstupdt + "where ficode='" + ficode + "' and Icode=" + 21 + " ";
        //        edpcom.RunCommand(iglmstupdt);  //=== Deriv-Optn 22

              
        //    }
        //    catch { }
        //}

        private string Getresult(string command)
        {
            try
            {
                edpcon.Open();
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
        }
        //=============================End Pradipta ============================

        private void frmInstall_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            this.Text = "Company Creation";
            rdb_select();

            Configuration_Menu_TypeDoc_companySetting();
            if (common.First_Time_Load)
            {
                btnNext.Focus();
                btnNext.Select();
                common.First_Time_Load = true;
            }
            else
            {
                cboCompanyname.Focus();
                cboCompanyname.Select();
            }
            //Cmbcountry.Text = "India";
            //COUNTRYCODE = 91;
        }
        public void Configuration_Menu_TypeDoc_companySetting()
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
                                    if (str == "Company_Details")
                                        chk_str = 1;
                                    else if (str == "Environment_Envelope")
                                        chk_str = 2;
                                    else if (str == "SDATE")
                                        chk_str = 3;
                                    else
                                        chk_str = 0;
                                }

                                string[] StrLine_WACC = line.Trim().Split(';');

                                if ((chk_str == 1) && (StrLine_WACC.Length > 2))
                                {
                                    if (StrLine_WACC[0] == "Country")
                                    {
                                        Cmbcountry.Text = StrLine_WACC[1];
                                        DataTable Coun = edpcom.GetDatatable("SELECT Country_CODE FROM Country where Country_Name='" + Cmbcountry.Text + "'");
                                        if (Coun.Rows.Count > 0)
                                            COUNTRYCODE = Convert.ToInt32(Coun.Rows[0][0]);
                                        MoneyName = edpcom.GetresultS("SELECT Currency_Name From Country Where Country_Name='" + Cmbcountry.Text + "'");
                                    }
                                    else if (StrLine_WACC[0] == "State")
                                    {
                                        txtState.Text = StrLine_WACC[1];
                                        DataTable stat = edpcom.GetDatatable("SELECT STATE_CODE FROM StateMaster where State_Name='" + txtState.Text + "'");
                                        if (stat.Rows.Count > 0)
                                            STATECODE = Convert.ToInt32(stat.Rows[0][0]);
                                    }
                                }
                                else if ((chk_str == 2) && (StrLine_WACC.Length > 1))
                                {
                                    if (StrLine_WACC[0].ToUpper() == "PETROL")
                                        edpcom.EnvironMent_Envelope = "Petrol";
                                    else if (StrLine_WACC[0].ToUpper() == "PRINTING")
                                        edpcom.EnvironMent_Envelope = "PRINTING";
                                    else
                                        edpcom.EnvironMent_Envelope = "";
                                }
                                else if ((chk_str == 3) && (StrLine_WACC.Length > 1))
                                {
                                    if (StrLine_WACC[1].ToUpper() != "")
                                    {
                                        Config_Date_Start = Convert.ToString(StrLine_WACC[0]);
                                        Config_Month_Start = Convert.ToString(StrLine_WACC[1]);
                                        chk_Date_First = true;
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            Next();
        }
        public void rdb_select()
        {
            rdbNew.Checked = true;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            NewIns = rdbNew.Checked;
            gpbMain.Visible = true;
            gpbIns.Visible = false;
            gpbIns.SendToBack();
            gpbMain.BringToFront();
            btnAdd.Enabled = true;
            lbxFi.Visible = false;
        }
        public void Next() 
        {
            NewIns = rdbNew.Checked;
            gpbMain.Visible = false;
            gpbIns.Visible = true;
            gpbMain.SendToBack();
            gpbIns.BringToFront();
            LOAD(true);  
            if (NewIns)
            {                
                cboCompanyname.DropDownStyle = ComboBoxStyle.Simple;
                cboCompanyname.Text = "";
            }
            else
            {                
                cboCompanyname.DropDownStyle = ComboBoxStyle.DropDownList;                
            }
            if (edpcom.FirstTimeInstall) lbxFi.Visible = false;
            else if ((!edpcom.FirstTimeInstall) && (!NewIns)) lbxFi.Visible = true;

            cboCompanyname.Focus();
            cboCompanyname.Select();
        }
        private void mtxStrdate_CloseUp(object sender, EventArgs e)
        {
            if (edpcom.GetDemoDays == 0)
            {
                if (DateTime.IsLeapYear(mtxStrdate.Value.Year + 1))
                    mtxEnddate.Value = mtxStrdate.Value.AddDays(365);
                else
                {
                    mtxEnddate.Value = mtxStrdate.Value.AddDays(364);
                    //mtxEnddate.Enabled = true;
                }
            }
            else
            {
                mtxEnddate.Value = mtxStrdate.Value.AddDays(edpcom.GetDemoDays);                
            }
        }

        ////Sujoy...................................
        //private void mtxStrdate_ValueChange(object sender,EventArgs e)
        //{
        //    //string date = mtxStrdate.Text;
        //    mtxEnddate.Value = mtxStrdate.Value.AddDays(364);
        //}
        ////Sujoy...................................
        private void cboCompanyname_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIndex = cboCompanyname.SelectedIndex;
            myrd.Close();
            //string sqlstr = "select  CO_SDATE, CO_EDATE,ficode from company WHERE GCODE='" + cocode[cboCompanyname.SelectedIndex].ToString() + "' order by CO_SDATE";

            string sqlstr = "select  CO.CO_SDATE, CO.CO_EDATE,CO.ficode,CU.Country_Name,CO.Country_CODE,S.State_Name,CO.State_Code from company CO,Country CU,StateMaster S" +
                            " WHERE GCODE='" + cocode[cboCompanyname.SelectedIndex].ToString() + "' AND CU.Country_CODE=CO.Country_Code AND S.STATE_CODE=CO.State_Code order by CO_SDATE";

            mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
            myrd = mycmd.ExecuteReader();
            lbxFi.Items.Clear();
            ficodelist.Clear();
            lbxFi.Items.Add("Existing Financial Years of");
            //lbxFi.Items.Add("The Selected Company.");
            lbxFi.Items.Add("---------------------------");
            while (myrd.Read())
            {
                lbxFi.Items.Add(myrd.GetDateTime(0).ToShortDateString() + "-" + myrd.GetDateTime(1).ToShortDateString());
                ficodelist.Add(myrd.GetString(2));
                try
                {
                    Cmbcountry.Text = myrd.GetString(3);
                    COUNTRYCODE = Convert.ToInt32(myrd.GetValue(4));
                    txtState.Text = myrd.GetString(5);
                    STATECODE = Convert.ToInt32(myrd.GetValue(6));
                }
                catch { }
            }

            
            myrd.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (copy >100)
            {
                copy = 0;
                Control_Enable_True();
                timer1.Enabled = false;
                this.Height = 362;
                //this.Size = new Size(389, 226);
                EDPMessage.Show("Successfully Installed.", "Message", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_OK);
                //if (COUNTRYCODE != 91)
                //{
                //    vistaButton1.Visible = true;
                //    vistaButton1_Click(vistaButton1, e);
                //}
                //else
                //{
                    if (edpcom.FirstTimeInstall == true)
                    {
                        this.Close();
                        return;
                    }
                    LOAD(false);
                    //if (gcode.Trim() == edpcom.PCURRENT_GCODE)
                    //{
                    //    if (Convert.ToInt32(ficode) > Convert.ToInt32(edpcom.CurrentFicode))
                    //    {
                    //        EDPMessage.Show("Do you want to run Copy Master ?", "Confirmation...", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
                    //        if (EDPMessage.ButtonResult == "edpYES")
                    //        {
                    //            string SourceGC = edpcom.PCURRENT_GCODE, SourceFIC = edpcom.CurrentFicode, TergetGC = gcode.Trim(), TergetFIC = ficode.Trim();
                    //            DateTime Source_FIYear = edpcom.CURRCO_SDT, Terget_FIYear = mtxStrdate.Value;

                    //            Utility.frmCopyAcc CA = new Utility.frmCopyAcc();
                    //            CA.GetData(SourceFIC, SourceGC, TergetFIC, TergetGC, Source_FIYear, Terget_FIYear, edpcom.CURRCO_EDT, edpcom.CURRENT_COMPANY);
                    //            CA.ShowDialog();
                    //        }
                    //    }
                    //}
                //}
            }
            else
                copy=copy+10;
        }     

        private void LOAD(bool T)
        {
            cboCompanyname.Focus();
            cboCompanyname.Items.Clear();
            cocode.Clear();         

            if ((DateTime.Today.Month == 1) || (DateTime.Today.Month == 2) || (DateTime.Today.Month == 3))
                mtxStrdate.Value = Convert.ToDateTime("1/4/" + Convert.ToInt32(DateTime.Today.Year - 1));
            else
                mtxStrdate.Value = Convert.ToDateTime("1/4/" + DateTime.Today.Year);
            //mtxStrdate.Focus();
            cboCompanyname.Focus();
      //Sujoy...............................................................................
            if (edpcom.GetDemoDays == 0)
            {
                if (DateTime.IsLeapYear(mtxStrdate.Value.Year + 1))
                {
                    //mtxStrdate.ShowUpDown = true;
                    mtxEnddate.Value = mtxStrdate.Value.AddDays(365);
                    mtxEnddate.Enabled = true;
                }
                else
                {
                    //mtxStrdate.ShowUpDown = true;
                    mtxEnddate.Value = mtxStrdate.Value.AddDays(364);
                    mtxEnddate.Enabled = true;
                }
            }
            else
            {
                //mtxStrdate.ShowUpDown = true;
                mtxEnddate.Value = mtxStrdate.Value.AddDays(edpcom.GetDemoDays);
                mtxEnddate.Enabled = true; 
            }
                     
            if (chk_Date_First)
            {
                DateTime dtS = mtxStrdate.Value;
                DateTime dtE = mtxEnddate.Value;
                bool flag_STED = false;
                if (Information.IsNumeric(Config_Date_Start) == true)
                {
                    if ((Convert.ToInt32(Config_Date_Start) > 0) && (Convert.ToInt32(Config_Date_Start) <= 31))
                    {
                    }
                    else
                    {
                        flag_STED = true;
                    }
                }
                else
                {
                    flag_STED = true;
                }

                if (Information.IsNumeric(Config_Month_Start) == true)
                {
                    if ((Convert.ToInt32(Config_Month_Start) > 0) && (Convert.ToInt32(Config_Month_Start) <= 12))
                    {
                    }
                    else
                    {
                        flag_STED = true;
                    }
                }
                else
                {
                    flag_STED = true;
                }

                if (!flag_STED)
                {
                    string sss = Config_Date_Start + "/" + Config_Month_Start + "/" + DateTime.Now.Year;
                    mtxStrdate.Value = Convert.ToDateTime(sss);
                    mtxEnddate.Value = mtxStrdate.Value.AddYears(1).AddDays(-1);
                }
                else
                {
                    mtxStrdate.Value = dtS;
                    mtxEnddate.Value = dtE;
                }
            }
            
            string sqlstr = "select DISTINCT CO_CODE, GCODE, CO_NAME from company";
            edpcon.Open();
            tran = edpcon.mycon.BeginTransaction();
            mycmd = new SqlCommand(sqlstr, edpcon.mycon, tran);
            myrd = mycmd.ExecuteReader();
            while (myrd.Read())
            {
                cboCompanyname.Items.Add(myrd.GetString(2));
                cocode.Add(myrd.GetString(0));
            }
            myrd.Close();
            if (T)             
                cboCompanyname.SelectedItem = edpcom.CURRENT_COMPANY;
            else
                cboCompanyname.SelectedIndex = cmbIndex;


        }
        private void Control_Enable_True()
        {
            btnClo.Enabled = true;
            btnBack.Enabled = true;
            //ShowMin = true;
            //ShowClose = true;
            btnAdd.Enabled = true;
            cboCompanyname.Enabled = true;
            mtxStrdate.Enabled = true;
            mtxEnddate.Enabled = true;
            this.KeyPreview = true;
        }
        private void Control_Enable_False()
        {
            btnClo.Enabled = false;
            btnBack.Enabled = false;
            btnAdd.Enabled = false;
            cboCompanyname.Enabled = false;
            mtxStrdate.Enabled = false;
            mtxEnddate.Enabled = false;
            //ShowMin = false;
            //ShowClose = false;
            this.KeyPreview = false;
        }

        private void frmInstall_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClo_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void mtxStrdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DateTime.IsLeapYear(mtxStrdate.Value.Year + 1))
                {
                    mtxEnddate.Value = mtxStrdate.Value.AddDays(365);
                    //mtxEnddate.Enabled = true;
                }
                else
                {
                    mtxEnddate.Value = mtxStrdate.Value.AddDays(364);
                    //mtxEnddate.Enabled = true;
                }
                mtxEnddate.Focus();
            }
        }

        private void mtxEnddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (COUNTRYCODE == 91)
                    btnAdd.Focus();
                else
                    vistaButton1.Focus();
            }
        }

        private void frmInstall_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                common.RuntheLastBuildUpdate();
            }
            if (e.KeyCode == Keys.F5)
            {
                btnAdd_Click(sender, e);
            }

            if (e.KeyCode == Keys.Escape)
            {
                EDPMessageBox.EDPMessage.Show("Are you sure exit the form?", "Acknowledgment...", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                if (EDPMessageBox.EDPMessage.ButtonResult == "edpYES")
                {
                    this.Close();
                }
            }
        }
        //global Unit & Currency stop for new company Creation
        public void globallocal()
        {
            SqlDataAdapter adp;
            SqlCommand cmd;
            ////Units
            //try
            //{
            //    string selcomgcod = "Select distinct UCODE,UDESC,DESM_PLACE from UNIT where ficode='" + ficode  + "'";
            //    adp = new SqlDataAdapter();
            //    edpcon.Open();
            //    cmd = new SqlCommand(selcomgcod, edpcon.mycon);
            //    adp.SelectCommand = cmd;
            //    DataTable dtt = new DataTable();
            //    adp.Fill(dtt);
            //    edpcon.Close();
            //    if (dtt.Rows.Count > 0)
            //    {
            //        for (int a = 0; a < dtt.Rows.Count; a++)
            //        {
            //            string sqlstr = "INSERT INTO unit(ficode, GCODE,UCODE,UDESC,DESM_PLACE) ";
            //            sqlstr = sqlstr + "values('" + ficode  + "','" + gcode + "'," + Convert.ToDecimal(dtt.Rows[a][0]) + ",'" + Convert.ToString(dtt.Rows[a][1]) + "'," + Convert.ToDecimal(dtt.Rows[a][2]) + ")";
            //            try
            //            {
            //                edpcon.Open();
            //                SqlCommand mycmd = new SqlCommand(sqlstr, edpcon.mycon);
            //                mycmd.ExecuteNonQuery();
            //                edpcon.Close();

            //            }
            //            catch { }

            //        }
            //    }
            //}
            //catch { }

            ////frmCurrency
            try
            {
                string selcurrency = "Select distinct curr_code,curr_desc,curr_str,curr_substr,DFLT_FLG,THOU_SEP,DEC_SEP,Curr_Type from currency where ficode='" + ficode + "'";
                SqlDataAdapter adpp = new SqlDataAdapter();
                edpcon.Open();
                cmd = new SqlCommand(selcurrency, edpcon.mycon);
                adpp.SelectCommand = cmd;
                DataTable dttt = new DataTable();
                adpp.Fill(dttt);
                edpcon.Close();
                if (common.dtCurrency.Rows.Count > 0)
                {
                    //string sql = "insert into currency(ficode,gcode,curr_code,curr_desc,curr_str,curr_substr,DFLT_FLG,thou_sep,DEC_SEP,Curr_Type) values(";
                    //sql = sql + "'" + ficode + "','" + gcode + "','" + Convert.ToString(dttt.Rows[0][0]) + "','" + Convert.ToString(dttt.Rows[0][1]) + "','" + Convert.ToString(dttt.Rows[0][2]) + "','" + Convert.ToString(dttt.Rows[0][3]) + "','" + Convert.ToBoolean(dttt.Rows[0][4]) + "','" + Convert.ToString(dttt.Rows[0][5]) + "','" + Convert.ToString(dttt.Rows[0][6]) + "','" + Convert.ToString(dttt.Rows[0][7]) + "')";
                    string st = "";
                    if (Convert.ToString(common.dtCurrency.Rows[0][5]) == "Million")
                        st = "D";
                    else if (Convert.ToString(common.dtCurrency.Rows[0][5]) == "Lac_Thou")
                        st = "R";
                    string sql = "update currency set curr_desc='" + Convert.ToString(common.dtCurrency.Rows[0][0]) + "',curr_str='" + Convert.ToString(common.dtCurrency.Rows[0][1]) + "',curr_substr='" + Convert.ToString(common.dtCurrency.Rows[0][2]) + "',DEC_SEP='" + Convert.ToString(common.dtCurrency.Rows[0][3]) + "',thou_sep='" + Convert.ToString(common.dtCurrency.Rows[0][4]) + "',Curr_Type='" + st + "',DFLT_FLG='1' Where Ficode='" + ficode + "' and gcode='" + gcode + "' and curr_code=1";
                    edpcon.Open();
                    cmd = new SqlCommand(sql, edpcon.mycon);
                    cmd.ExecuteNonQuery();
                    edpcon.Close();
                }
                else
                {
                    if (dttt.Rows.Count > 0)
                    {
                        for (int a = 0; a < dttt.Rows.Count; a++)
                        {
                            //if (Convert.ToInt32(dttt.Rows[a][0]) != 1) //Global concept is off 26-09-2014
                            if (Convert.ToInt32(dttt.Rows[a][0]) == 1)
                            {
                                string sql = "insert into currency(ficode,gcode,curr_code,curr_desc,curr_str,curr_substr,DFLT_FLG,thou_sep,DEC_SEP,Curr_Type) values(";
                                sql = sql + "'" + ficode + "','" + gcode + "','" + Convert.ToString(dttt.Rows[a][0]) + "','" + Convert.ToString(dttt.Rows[a][1]) + "','" + Convert.ToString(dttt.Rows[a][2]) + "','" + Convert.ToString(dttt.Rows[a][3]) + "','" + Convert.ToBoolean(dttt.Rows[a][4]) + "','" + Convert.ToString(dttt.Rows[a][5]) + "','" + Convert.ToString(dttt.Rows[a][6]) + "','" + Convert.ToString(dttt.Rows[a][7]) + "')";
                                edpcon.Open();
                                cmd = new SqlCommand(sql, edpcon.mycon);
                                cmd.ExecuteNonQuery();
                                edpcon.Close();
                            }
                        }
                    }
                }
                common.ClearDataTable(common.dtCurrency);
            }
            catch { }
            ////Fund Creation
            ////try
            ////{
            //    //string selcurrencyy = "Select distinct FUND_CODE,FUND_DESC,FUND_PROFILE,Fund_Type from INSURANCEFUND where ficode='" +ficode  + "'";
            //    //SqlDataAdapter addp = new SqlDataAdapter();
            //    //edpcon.Open();
            //    //cmd = new SqlCommand(selcurrencyy, edpcon.mycon);
            //    //addp.SelectCommand = cmd;
            //    //DataTable dtfund = new DataTable();
            //    //addp.Fill(dtfund);
            //    //edpcon.Close();
            //    //if (dtfund.Rows.Count > 0)
            //    //{

            //        //for (int a = 0; a < dtfund.Rows.Count; a++)
            //        //{
            //        //    string str = "INSERT INTO INSURANCEFUND (FICODE,GCODE,FUND_CODE,FUND_DESC,FUND_PROFILE,Fund_Type) VALUES('" + ficode + "','" + gcode + "'," + Convert.ToDecimal(dtfund.Rows[a][0]) + ",'" + Convert.ToString(dtfund.Rows[a][1]) + "','" + Convert.ToString(dtfund.Rows[a][2]) + "','" + Convert.ToString(dtfund.Rows[a][3]) + "')";
            //        //    edpcon.Open();
            //        //    cmd = new SqlCommand(str, edpcon.mycon);
            //        //    try
            //        //    {
            //        //        cmd.ExecuteNonQuery();
            //        //        edpcon.Close();
            //        //    }
            //        //    catch
            //        //    {
            //        //        edpcon.Close();
            //        //    }
            //        //}
            ////    }
            ////}
            ////catch { }
        }
        //End Transfar Unit and gurrency fro new company creation
        private void txtState_DropDown(object sender, EventArgs e)
        {
            try
            {
                string str = "SELECT State_Name,STATE_CODE FROM StateMaster";

                ////////frmStateMaster SM = new frmStateMaster();
                //edpcon.Open();
                //////////common.LOV("SELECT STATE NAME", str, textBox1, 1, SM, true, "Click here to create new State / Press Insert");
                txtState.Text = textBox1.Text;
                STATECODE = Convert.ToInt32(common.LovReturnValue);
                ChkCount = 0;
                mtxStrdate.Focus();
            }
            catch { }
        }

        private void Cmbcountry_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (ChkCount == 0)
                {
                    ChkCount = 1;
                    string str = "SELECT Country_Name,Country_CODE FROM Country";
                    //edpcon.Open();
                    common.LOV("SELECT COUNTRY NAME", str, textBox1, 1);
                    Cmbcountry.Text = textBox1.Text;
                    COUNTRYCODE = Convert.ToInt32(common.LovReturnValue);

                    txtState.Text = "";
                    STATECODE = 0;
                    vistaButton1.Visible = false;
                    if (COUNTRYCODE != 91)
                    {
                        vistaButton1.Visible = true;
                        MoneyName = edpcom.GetresultS("SELECT Currency_Name From Country Where Country_Name='" + Cmbcountry.Text + "'");
                        txtState.Text = "OTHERS";
                        STATECODE = 36;                        
                        mtxStrdate.Focus();
                    }
                    else
                    {
                        txtState.Focus();
                        txtState.PopUp();
                    }
                }
            }
            catch { }
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            //////////frmCurrency curr = new frmCurrency();
            //////////curr.load_curr();
            //////////curr.GetFICODEGCODE(ficode, gcode, MoneyName);
            //////////curr.ShowDialog();
            btnAdd.Focus();
            btnAdd.Select();
            //LOAD(false);
            //btnAdd.Focus();
        }      

        private void txtState_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
                mtxStrdate.Focus();
            //}
        }

        private void cboCompanyname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (cboCompanyname.Text.Trim() == "")
                //    Cmbcountry.PopUp();
                //else
                //    mtxStrdate.Focus();
                try
                {
                    string Str = "Select distinct State_Code,Country_Code from Company where CO_NAME='" + cboCompanyname.Text + "'";
                    SqlDataAdapter adp = new SqlDataAdapter();
                    //edpcon.Open();
                    SqlCommand cmd = new SqlCommand(Str, edpcon.mycon, tran);
                    adp.SelectCommand = cmd;
                    DataTable dtt = new DataTable();
                    adp.Fill(dtt);
                    //edpcon.Close();

                    if (dtt.Rows.Count > 0)
                    {
                        if (Information.IsNumeric(dtt.Rows[0][0]) == true)
                        {
                            txtState.Text = edpcom.GetresultS("SELECT State_Name FROM StateMaster WHERE STATE_CODE=" + Convert.ToInt32(dtt.Rows[0][0]) + "");
                            STATECODE = Convert.ToInt32(dtt.Rows[0][0]);
                        }
                        if (Information.IsNumeric(dtt.Rows[0][1]) == true)
                        {
                            Cmbcountry.Text = edpcom.GetresultS("SELECT Country_Name FROM Country WHERE Country_CODE=" + Convert.ToInt32(dtt.Rows[0][1]) + "");
                            COUNTRYCODE = Convert.ToInt32(dtt.Rows[0][1]);
                            if (COUNTRYCODE == 91)
                                vistaButton1.Visible = false;
                            else
                                vistaButton1.Visible = true;
                        }
                        mtxStrdate.Focus();
                    }
                    else
                    {
                        if (Cmbcountry.Text == "")
                            Cmbcountry.PopUp();
                        else if (txtState.Text == "")
                            txtState.PopUp();
                        mtxStrdate.Focus();
                    }
                }
                catch { }
            }
        }

        private void mtxStrdate_Leave(object sender, EventArgs e)
        {
            ChkCount = 0;
        }

        private void cboCompanyname_Leave(object sender, EventArgs e)
        {
            if (cboCompanyname.Text.Length > 60)
            {
                EDPMessage.Show("Company name is within 60 charecters.");
                cboCompanyname.Focus();
                return;
            }
        }

       
    }
}