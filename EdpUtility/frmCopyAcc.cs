using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using EDPMessageBox;
using EDPComponent;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections;
using EDPProgressBar;

namespace Utility
{
    public partial class frmCopyAcc : FormBase
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();        
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();        
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        Hashtable gcodeh = new Hashtable();
        Hashtable NodeBackup = new Hashtable();
        string SFIC = "", SGC = "", TFIC = "", TGC = "", Company_Name = "";
        DateTime SCFI, TFI, SCFIED;
        bool Chk_InstalationTime = false;

        public frmCopyAcc()
        {
            InitializeComponent();
        }

        private void frmCopyAcc_Load(object sender, EventArgs e)
        {
            
            //this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            chkBranch.Visible = false;
            chkUserProfile.Visible = false;
            chk_Consignee.Visible = false;
            chepricelist.Visible = false;
            edpcom.UpdateMidasLog(this, true);
            edpcom.setFormPosition(this);
            Company_List();
            if (Chk_InstalationTime)
            {
                TRV_COMPNY.Enabled = false;
                lbl_Select_Company.Text = "Copy From Company  :  " + Company_Name + " [ " + SCFI.ToShortDateString() + "-" + SCFIED.ToShortDateString() + " ]";
            }
        }

        public void GetData(string SourceFICode, string SourceGCode, string TergetFICode, string TergetGCode, DateTime SC_FIYear, DateTime Terget_FIYear, DateTime SC_FIYearEnd,string CName)
        {
            SFIC = SourceFICode; SGC = SourceGCode;
            TFIC = TergetFICode; TGC = TergetGCode;
            SCFI = SC_FIYear; TFI = Terget_FIYear; SCFIED = SC_FIYearEnd;
            Chk_InstalationTime = true; Company_Name = CName;
        }

        private void Company_List()
        {
            TRV_COMPNY.Nodes.Clear();
            gcodeh.Clear();
            arr.Clear();
            try
            {
                string user = edpcom.PCURRENT_USER;
                edpcon.Open();
                cmd = new SqlCommand("select distinct gcode from access where USER_CODE='" + user + "' and gcode<>'" + edpcom.PCURRENT_GCODE + "' or ficode<>'" + edpcom.CurrentFicode + "' ", edpcon.mycon);
                da.SelectCommand = cmd;
                bool bu = Convert.ToBoolean(da.Fill(ds, "chk_access"));
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
                        string gcode = Convert.ToString(arr[i]);
                        edpcon.Open();
                        cmd = new SqlCommand("select FICode from access where GCODE='" + gcode + "' and user_code='" + user + "'", edpcon.mycon);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "com_info");
                        cmd = new SqlCommand("select distinct co_name from company where GCODE='" + gcode + "'", edpcon.mycon);
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        gcodeh.Add(dr.GetString(0), gcode);
                        TRV_COMPNY.Nodes.Add(dr.GetString(0));
                        dr.Close();
                        edpcon.Close();
                        TreeNode tn = new TreeNode();
                        tn = TRV_COMPNY.Nodes[i];
                        int j;
                        for (j = 0; j <= ds.Tables["com_info"].Rows.Count - 1; j++)
                        {
                            edpcon.Open();
                            cmd = new SqlCommand("select co_sdate,co_edate from company where GCODE='" + gcode + "' and ficode='" + ds.Tables["com_info"].Rows[j][0].ToString() + "'", edpcon.mycon);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "com_det");
                            string val = Convert.ToDateTime(ds.Tables["com_det"].Rows[0][0]).ToShortDateString() + "--" + Convert.ToDateTime(ds.Tables["com_det"].Rows[0][1]).ToShortDateString();
                            tn.Nodes.Add(val);
                            ds.Tables["com_det"].Clear();
                            edpcon.Close();
                        }
                        ds.Tables["com_info"].Clear();
                        i++;
                    }
                    ds.Tables["chk_access"].Clear();
                }
                else
                {
                    EDPMessage.Show("No permission found against this User");
                    ds.Tables["chk_access"].Clear();
                    this.Close();
                }
                ds.Tables.Clear();
                TRV_COMPNY.ExpandAll();
                TRV_COMPNY.Sort();
                TRV_COMPNY.SelectedNode = TRV_COMPNY.Nodes[0];

                try
                {
                    lbl_Select_Company.Text = "Selected Company  :  " + TRV_COMPNY.SelectedNode.Parent.Text.ToString() + " [ " + Convert.ToString(TRV_COMPNY.SelectedNode.Text.Substring(0, 10)) + "-" + Convert.ToString(TRV_COMPNY.SelectedNode.Text.Substring(12, 10)) + " ]";
                }
                catch { }
            }
            catch
            {
                edpcon.Close();
                // MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            COPY_MASTER();
            All_Clear();
        }
        private void COPY_MASTER()
        {
            try
            {
                if (TRV_COMPNY.SelectedNode != null)
                {
                    string s1 = "";
                    if (!Chk_InstalationTime)
                    {                        
                        try
                        {
                            s1 = TRV_COMPNY.SelectedNode.Parent.Text.ToString();
                        }
                        catch
                        {
                            EDPMessage.Show("Select Financial Year.", "Account Copy", EDPMessage.MessageBoxButton.EDP_OK);
                            return;
                        }
                    }
                    string Source_gcode = "";
                    if (Chk_InstalationTime)
                        Source_gcode = SGC;
                    else
                        Source_gcode = Convert.ToString(gcodeh[s1]);
                    edpcon.Open();
                    try
                    {
                        string S_FICODE = "", S_GCODE = "", D_FICODE = "", D_GCODE = "";

                        DateTime Source_Fiyear; DateTime Dest_Fiyear;
                        if (Chk_InstalationTime)
                        {
                            Source_Fiyear = SCFI;
                            Dest_Fiyear = TFI;

                            S_FICODE = SFIC;
                            S_GCODE = SGC;
                            D_FICODE = TFIC;
                            D_GCODE = TGC;
                        }
                        else
                        {
                            Source_Fiyear = Convert.ToDateTime(TRV_COMPNY.SelectedNode.Text.Substring(0, 10));
                            Dest_Fiyear = edpcom.CURRCO_SDT;

                            s1 = "select FICode from ficodegen where Start_Date='" + edpcom.getSqlDateStr(Convert.ToDateTime(TRV_COMPNY.SelectedNode.Text.Substring(0, 10))) + "' and End_Date='" + edpcom.getSqlDateStr(Convert.ToDateTime(TRV_COMPNY.SelectedNode.Text.Substring(12, 10))) + "'";
                            cmd = new SqlCommand(s1, edpcon.mycon);
                            SqlDataReader dr = cmd.ExecuteReader();
                            dr.Read();
                            string Source_ficode = dr.GetString(0);
                            dr.Close();

                            S_FICODE = Source_ficode;
                            S_GCODE = Source_gcode;
                            D_FICODE = edpcom.CurrentFicode;
                            D_GCODE = edpcom.PCURRENT_GCODE;
                        }
                        if (Source_Fiyear > Dest_Fiyear)
                        {
                            EDPMessage.Show("Please Select Previous Financial Year ", "Account Copy", EDPMessage.MessageBoxButton.EDP_OK);
                            return;
                        }
                        else
                        {
                            //s1 = "select FICode from ficodegen where Start_Date='" + edpcom.getSqlDateStr(Convert.ToDateTime(TRV_COMPNY.SelectedNode.Text.Substring(0, 10))) + "' and End_Date='" + edpcom.getSqlDateStr(Convert.ToDateTime(TRV_COMPNY.SelectedNode.Text.Substring(12, 10))) + "'";
                            //cmd = new SqlCommand(s1, edpcon.mycon);
                            //SqlDataReader dr = cmd.ExecuteReader();
                            //dr.Read();
                            //string Source_ficode = dr.GetString(0);
                            //dr.Close();

                            //if ((Source_gcode.Trim() == edpcom.PCURRENT_GCODE) && (Source_ficode.Trim() == edpcom.CurrentFicode))
                            if ((S_GCODE == D_GCODE) && (S_FICODE == D_FICODE))
                            {
                                EDPMessage.Show("Data Can Not Copy Itself", "Account Copy", EDPMessage.MessageBoxButton.EDP_OK);
                                return;
                            }
                            else
                            {
                                cmd = new SqlCommand("Select Count(*) from Data where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "'", edpcon.mycon);
                                SqlDataReader dr = cmd.ExecuteReader();
                                dr.Read();
                                int countacc = dr.GetInt32(0);
                                dr.Close();
                                cmd = new SqlCommand("Select Count(*) from idata where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "'", edpcon.mycon);
                                dr = cmd.ExecuteReader();
                                dr.Read();
                                int countstck = dr.GetInt32(0);
                                dr.Close();
                                if (countacc == 0 && countstck == 0)
                                {
                                    EDPMessage.Show("Data Should be Over Written", "Account Copy", EDPMessage.MessageBoxButton.EDP_YES_NO);
                                    if (EDPMessage.ButtonResult == "edpYES")
                                    {
                                        if (chkbx_Acc.Checked || chk_AllMst.Checked)
                                        {

                                            string sqlstr = " if exists (select * from sysobjects where id = object_id('UpdtGrpForLedgTrig')" + Environment.NewLine;
                                            sqlstr = sqlstr + " and OBJECTPROPERTY(id, 'IsTrigger') = 1)" + Environment.NewLine;
                                            sqlstr = sqlstr + " drop Trigger UpdtGrpForLedgTrig" + Environment.NewLine;
                                            cmd = new SqlCommand(sqlstr, edpcon.mycon);
                                            try
                                            {
                                                cmd.ExecuteNonQuery(); //Drop Tiger in glmst
                                            }
                                            catch { }


                                            string strdproc = "COPY_ACC";
                                            cmd = new SqlCommand(strdproc, edpcon.mycon);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            SqlParameter SFICODE = new SqlParameter("@SourceFicode", S_FICODE);
                                            SqlParameter SGCODE = new SqlParameter("@SourceGcode", S_GCODE);
                                            SqlParameter DFICODE = new SqlParameter("@DestFicode", D_FICODE);
                                            SqlParameter DGCODE = new SqlParameter("@DestGcode", D_GCODE);
                                            cmd.Parameters.Add(SFICODE);
                                            cmd.Parameters.Add(SGCODE);
                                            cmd.Parameters.Add(DFICODE);
                                            cmd.Parameters.Add(DGCODE);
                                            cmd.ExecuteNonQuery();
                                            if (Information.IsNothing(ds.Tables["CNT"]) == false)
                                            {
                                                ds.Tables["CNT"].Clear();
                                                ds.Tables["CNT"].Reset();
                                            }
                                            UpdtGrp_GlmstForLedgTrig(edpcon.mycon);//Add Tiger in glmst
                                            cmd = new SqlCommand("select SDESC from grp where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "' union select LDESC from glmst where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "'", edpcon.mycon);
                                            da.SelectCommand = cmd;
                                            da.Fill(ds, "CNT");                                       
                                           

                                            edpcon.Close();

                                            if (Dest_Fiyear >= Convert.ToDateTime("01/04/2013"))
                                            {
                                                edpcon.Open();
                                                bool Chk_ledg = false;
                                                cmd = new SqlCommand("select * from GLMST where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "' and MType='L' and LDESC='Purchases @ 4%'", edpcon.mycon);
                                                da.SelectCommand = cmd;
                                                da.Fill(ds, "Ledg1");
                                                if (ds.Tables["Ledg1"].Rows.Count > 1)
                                                    Chk_ledg = true;

                                                cmd = new SqlCommand("select * from GLMST where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "' and MType='L' and LDESC='Output VAT @ 25%  Special Rate'", edpcon.mycon);
                                                da.SelectCommand = cmd;
                                                da.Fill(ds, "Ledg2");
                                                if (ds.Tables["Ledg2"].Rows.Count > 1)
                                                    Chk_ledg = true;

                                                if (Chk_ledg)
                                                {
                                                    int MAXGLCODE = 0, LEDGER_CODE = 0;
                                                    EDPCommon.ClearDataTable_EDP(ds.Tables["tblGlmstMAXGlcode"]);
                                                    cmd = new SqlCommand("SELECT MAX(GLCODE) FROM GLMST WHERE FICODE='" + D_FICODE + "' AND GCODE='" + D_GCODE + "' AND MTYPE='L'", edpcon.mycon);
                                                    da.SelectCommand = cmd;
                                                    da.Fill(ds, "tblGlmstMAXGlcode");
                                                    if (Convert.ToInt32(ds.Tables["tblGlmstMAXGlcode"].Rows[0][0]) > 10000)
                                                        MAXGLCODE = Convert.ToInt32(ds.Tables["tblGlmstMAXGlcode"].Rows[0][0]);
                                                    else
                                                        MAXGLCODE = 10000;

                                                    MAXGLCODE++;

                                                    string STR = "INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES('" + D_FICODE + "','" + edpcom.PCURRENT_GCODE + "','L',8,18," + MAXGLCODE + ",'Purchases @ 5%','null',50,0,0,0,1,18,'0000000000',0,'D','2',0,NULL,NULL,0,'1',1,1,1,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    LEDGER_CODE = MAXGLCODE;
                                                    MAXGLCODE++;
                                                    STR = "INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES('" + D_FICODE + "','" + edpcom.PCURRENT_GCODE + "','L',3,30," + MAXGLCODE + ",'Input VAT @5%','null',31,0,0,0,1,30,'0000000000',0,'C','2',1,NULL,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    STR = "INSERT INTO VATMaster(ficode,gcode,VAT_CODE,STATE_CODE,VAT_DESC,VAT_PERCENT,UPD_DATE,Tax_Type ) VALUES('" + D_FICODE + "','" + D_GCODE + "'," + MAXGLCODE + ",19,'Input VAT @5%',5,'03/27/2012','vat')";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    STR = "INSERT INTO LinkVATGLMST(FICode,GCODE,LVG_ID,STATE_CODE,VAT_CODE,GLCODE,Vat_Per) VALUES('" + edpcom.CurrentFicode + "','" + D_GCODE + "',1,19," + MAXGLCODE + "," + LEDGER_CODE + ",1)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    MAXGLCODE++;

                                                    STR = "INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES('" + D_FICODE + "','" + D_GCODE + "','L',9,0," + MAXGLCODE + ",'Sales @5% ','null',60,0,0,0,1,0,'0000000000',0,'C','2',1,NULL,NULL,0,'1',1,1,1,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    LEDGER_CODE = MAXGLCODE;
                                                    MAXGLCODE++;
                                                    STR = "INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES('" + D_FICODE + "','" + D_GCODE + "','L',3,30," + MAXGLCODE + ",'Output VAT @ 5%','null',33,0,0,0,1,30,'0000000000',0,'C','2',1,NULL,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    STR = "INSERT INTO VATMaster(ficode,gcode,VAT_CODE,STATE_CODE,VAT_DESC,VAT_PERCENT,UPD_DATE,Tax_Type ) VALUES('" + D_FICODE + "','" + D_GCODE + "'," + MAXGLCODE + ",19,'Output VAT @ 5%',5,'03/27/2012','vat')";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    STR = "INSERT INTO LinkVATGLMST(FICode,GCODE,LVG_ID,STATE_CODE,VAT_CODE,GLCODE,Vat_Per) VALUES('" + D_FICODE + "','" + D_GCODE + "',1,19," + MAXGLCODE + "," + LEDGER_CODE + ",1)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    MAXGLCODE++;

                                                    STR = "INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES('" + D_FICODE + "','" + D_GCODE + "','L',8,18," + MAXGLCODE + ",'Purchases @ 14.5%','null',50,0,0,0,1,18,'0000000000',0,'D','2',0,NULL,NULL,0,'1',1,1,1,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    LEDGER_CODE = MAXGLCODE;
                                                    MAXGLCODE++;
                                                    STR = "INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES('" + D_FICODE + "','" + D_GCODE + "','L',3,30," + MAXGLCODE + ",'Input VAT @14.5%','null',31,0,0,0,1,30,'0000000000',0,'C','2',1,NULL,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    STR = "INSERT INTO VATMaster(ficode,gcode,VAT_CODE,STATE_CODE,VAT_DESC,VAT_PERCENT,UPD_DATE,Tax_Type ) VALUES('" + D_FICODE + "','" + D_GCODE + "'," + MAXGLCODE + ",19,'Input VAT @14.5%',14.5,'03/27/2012','vat')";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    STR = "INSERT INTO LinkVATGLMST(FICode,GCODE,LVG_ID,STATE_CODE,VAT_CODE,GLCODE,Vat_Per) VALUES('" + D_FICODE + "','" + D_GCODE + "',1,19," + MAXGLCODE + "," + LEDGER_CODE + ",1)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    MAXGLCODE++;

                                                    STR = "INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES('" + D_FICODE + "','" + D_GCODE + "','L',9,0," + MAXGLCODE + ",'Sales @14.5% ','null',60,0,0,0,1,0,'0000000000',0,'C','2',1,NULL,NULL,0,'1',1,1,1,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    LEDGER_CODE = MAXGLCODE;
                                                    MAXGLCODE++;
                                                    STR = "INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES('" + D_FICODE + "','" + D_GCODE + "','L',3,30," + MAXGLCODE + ",'Output VAT @14.5%','null',33,0,0,0,1,30,'0000000000',0,'C','2',1,NULL,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    STR = "INSERT INTO VATMaster(ficode,gcode,VAT_CODE,STATE_CODE,VAT_DESC,VAT_PERCENT,UPD_DATE,Tax_Type ) VALUES('" + D_FICODE + "','" + D_GCODE + "'," + MAXGLCODE + ",19,'Output VAT @14.5%',14.5,'03/27/2012','vat')";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    STR = "INSERT INTO LinkVATGLMST(FICode,GCODE,LVG_ID,STATE_CODE,VAT_CODE,GLCODE,Vat_Per) VALUES('" + D_FICODE + "','" + D_GCODE + "',1,19," + MAXGLCODE + "," + LEDGER_CODE + ",1)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    MAXGLCODE++;

                                                    STR = "INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES('" + D_FICODE + "','" + D_GCODE + "','L',8,18," + MAXGLCODE + ",'Purchase @ 25% Special Rate' ,'null',50,0,0,0,1,18,'0000000000',0,'D','2',0,NULL,NULL,0,'1',1,1,1,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    LEDGER_CODE = MAXGLCODE;
                                                    MAXGLCODE++;
                                                    STR = "INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES('" + D_FICODE + "','" + D_GCODE + "','L',3,30," + MAXGLCODE + ",'Input VAT @25% Special Rate ','null',31,0,0,0,1,30,'0000000000',0,'C','2',1,NULL,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    STR = "INSERT INTO VATMaster(ficode,gcode,VAT_CODE,STATE_CODE,VAT_DESC,VAT_PERCENT,UPD_DATE,Tax_Type ) VALUES('" + D_FICODE + "','" + D_GCODE + "'," + MAXGLCODE + ",19,'Input VAT @25% Special Rate ',25,'03/27/2012','vat')";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    STR = "INSERT INTO LinkVATGLMST(FICode,GCODE,LVG_ID,STATE_CODE,VAT_CODE,GLCODE,Vat_Per) VALUES('" + D_FICODE + "','" + D_GCODE + "',1,19," + MAXGLCODE + "," + LEDGER_CODE + ",1)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    MAXGLCODE++;

                                                    STR = "INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES('" + D_FICODE + "','" + D_GCODE + "','L',9,0," + MAXGLCODE + ",'Sales @ 25%  Special Rate','null',60,0,0,0,1,0,'0000000000',0,'C','2',1,NULL,NULL,0,'1',1,1,1,0,0,NULL,0,0,0,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    LEDGER_CODE = MAXGLCODE;
                                                    MAXGLCODE++;
                                                    STR = "INSERT INTO glmst (FICode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,LALIAS,T_FILTER,OPBAL,CURBAL,LBAL,SGRP_LEV,PREV_GROUP,ALOC_CODE,CONS_FLG,PDF_TYPE,PDF_CODE,NBAL_FLG,UNB_GROUP,UNB_SGROUP,ACTV_FLG,CURR_CODE,NCONV_FCTR,DCONV_FCTR,TRANS_CLOS,EXCHG_DIFF,FC_CURBAL,BOOL_CODE,FC_OPBAL,FC_LBAL,EXDIFF_VAL,OP_LBAL,FC_OPLBAL,SCHD_NO,CFLOW_GROUP,MGCODE,MMTYPE,MMGROUP,MSGROUP,MGLCODE,MLDESC,LOCK,Details,ACNO) VALUES('" + D_FICODE + "','" + D_GCODE + "','L',3,30," + MAXGLCODE + ",'Output VAT @ 25%  Special Rate ','null',33,0,0,0,1,30,'0000000000',0,'C','2',1,NULL,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,NULL,'A',NULL,NULL,NULL,NULL,NULL,NULL,'0','As Per Details',NULL)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    STR = "INSERT INTO VATMaster(ficode,gcode,VAT_CODE,STATE_CODE,VAT_DESC,VAT_PERCENT,UPD_DATE,Tax_Type ) VALUES('" + D_FICODE + "','" + D_GCODE + "'," + MAXGLCODE + ",19,'Output VAT @ 25%  Special Rate',25,'03/27/2012','vat')";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                    STR = "INSERT INTO LinkVATGLMST(FICode,GCODE,LVG_ID,STATE_CODE,VAT_CODE,GLCODE,Vat_Per) VALUES('" + D_FICODE + "','" + D_GCODE + "',1,19," + MAXGLCODE + "," + LEDGER_CODE + ",1)";
                                                    edpcom.RunCommand(STR, edpcon.mycon);
                                                }
                                                edpcon.Close();
                                            }

                                            //EDPProgressBar.ThreadingProgress ThrdProgrs = new ThreadingProgress(ds.Tables["CNT"]);
                                            //ThrdProgrs.ShowDialog();
                                            //EDPMessage.Show("Data Copy Successfully", "Account Copy", EDPMessage.MessageBoxButton.EDP_OK);
                                        }
                                        //else
                                        //    return;
                                        //}
                                       
                                        if (chkbx_InvMst.Checked || chk_AllMst.Checked)
                                        {
                                            //EDPMessage.Show("Data Should be Over Written", "Investment Copy", EDPMessage.MessageBoxButton.EDP_YES_NO);
                                            //if (EDPMessage.ButtonResult == "edpYES")
                                            //{
                                            edpcon.Close();
                                            edpcon.Open();
                                            string strdproc = "INVMST_COPY";
                                            cmd = new SqlCommand(strdproc, edpcon.mycon);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            SqlParameter SFICODE = new SqlParameter("@SourceFicode", S_FICODE);
                                            SqlParameter SGCODE = new SqlParameter("@SourceGcode", S_GCODE);
                                            SqlParameter DFICODE = new SqlParameter("@DestFicode", D_FICODE);
                                            SqlParameter DGCODE = new SqlParameter("@DestGcode", D_GCODE);
                                            cmd.Parameters.Add(SFICODE);
                                            cmd.Parameters.Add(SGCODE);
                                            cmd.Parameters.Add(DFICODE);
                                            cmd.Parameters.Add(DGCODE);
                                            cmd.ExecuteNonQuery();
                                            if (Information.IsNothing(ds.Tables["CNT"]) == false)
                                            {
                                                ds.Tables["CNT"].Clear();
                                                ds.Tables["CNT"].Reset();
                                            }
                                            cmd = new SqlCommand("select PDESC from IGLMST where ficode='" + D_FICODE + "'   and gcode='" + D_GCODE + "'", edpcon.mycon);
                                            da.SelectCommand = cmd;
                                            da.Fill(ds, "CNT");
                                            edpcon.Close();
                                            //EDPProgressBar.ThreadingProgress ThrdProgrs = new ThreadingProgress(ds.Tables["CNT"]);
                                            //ThrdProgrs.ShowDialog();
                                            //EDPMessage.Show("Data Copy Successfully", "Investment Copy", EDPMessage.MessageBoxButton.EDP_OK);
                                            edpcon.Close();
                                            //}
                                            //else
                                            //    return;
                                        }

                                        //Subrata                                   
                                        if (chepricelist.Checked == true)
                                        {
                                            edpcon.Open();
                                            EDPCommon.ClearDataTable_EDP(ds.Tables["Pricelist_Glmst"]);
                                            cmd = new SqlCommand("SELECT * FROM GLMST WHERE FICODE='" + D_FICODE + "' AND GCODE='" + D_GCODE + "' AND MTYPE='L' and glcode >10000", edpcon.mycon);
                                            da.SelectCommand = cmd;
                                            da.Fill(ds, "Pricelist_Glmst");

                                            EDPCommon.ClearDataTable_EDP(ds.Tables["Pricelist_Iglmst"]);
                                            cmd = new SqlCommand("SELECT * FROM iglmst WHERE FICODE='" + D_FICODE + "' AND GCODE='" + D_GCODE + "' ", edpcon.mycon);
                                            da.SelectCommand = cmd;
                                            da.Fill(ds, "Pricelist_Iglmst");
                                            //PriceList Master
                                            if (ds.Tables["Pricelist_Glmst"].Rows.Count > 0 && ds.Tables["Pricelist_Iglmst"].Rows.Count > 0)
                                            {
                                                string strdproc = "Price_List_Master_COPY";
                                                cmd = new SqlCommand(strdproc, edpcon.mycon);
                                                cmd.CommandType = CommandType.StoredProcedure;
                                                SqlParameter SFICODE = new SqlParameter("@SourceFicode", S_FICODE);
                                                SqlParameter SGCODE = new SqlParameter("@SourceGcode", S_GCODE);
                                                SqlParameter DFICODE = new SqlParameter("@DestFicode", D_FICODE);
                                                SqlParameter DGCODE = new SqlParameter("@DestGcode", D_GCODE);
                                                cmd.Parameters.Add(SFICODE);
                                                cmd.Parameters.Add(SGCODE);
                                                cmd.Parameters.Add(DFICODE);
                                                cmd.Parameters.Add(DGCODE);
                                                cmd.ExecuteNonQuery();
                                                //End PriceList Master

                                                //PriceList Details
                                                edpcon.Open();
                                                strdproc = "Price_List_Details_COPY";
                                                cmd = new SqlCommand(strdproc, edpcon.mycon);
                                                cmd.CommandType = CommandType.StoredProcedure;
                                                SFICODE = new SqlParameter("@SourceFicode", S_FICODE);
                                                SGCODE = new SqlParameter("@SourceGcode", S_GCODE);
                                                DFICODE = new SqlParameter("@DestFicode", D_FICODE);
                                                DGCODE = new SqlParameter("@DestGcode", D_GCODE);
                                                cmd.Parameters.Add(SFICODE);
                                                cmd.Parameters.Add(SGCODE);
                                                cmd.Parameters.Add(DFICODE);
                                                cmd.Parameters.Add(DGCODE);
                                                cmd.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                if (ds.Tables["Pricelist_Glmst"].Rows.Count == 0 && ds.Tables["Pricelist_Iglmst"].Rows.Count == 0)
                                                    EDPMessage.Show("Product Name And Party Name Not Exist", "Price List Copy", EDPMessage.MessageBoxButton.EDP_OK);
                                                else if (ds.Tables["Pricelist_Glmst"].Rows.Count == 0)
                                                    EDPMessage.Show("Party Name Not Exist", "Price List Copy", EDPMessage.MessageBoxButton.EDP_OK);
                                                else if (ds.Tables["Pricelist_Iglmst"].Rows.Count == 0)
                                                    EDPMessage.Show("Product Name Not Exist", "Price List Copy", EDPMessage.MessageBoxButton.EDP_OK);

                                            }

                                            //End PriceList Details
                                        }

                                        if (chkBranch.Checked || chk_AllMst.Checked)
                                        {
                                            //EDPMessage.Show("Data Should be Over Written", "Branch Copy", EDPMessage.MessageBoxButton.EDP_YES_NO);
                                            //if (EDPMessage.ButtonResult == "edpYES")
                                            //{
                                            edpcon.Close();
                                            edpcon.Open();
                                            string strdproc = "BRANCH_ACCESS_COPY";
                                            cmd = new SqlCommand(strdproc, edpcon.mycon);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            SqlParameter SFICODE = new SqlParameter("@SourceFicode", S_FICODE);
                                            SqlParameter SGCODE = new SqlParameter("@SourceGcode", S_GCODE);
                                            SqlParameter DFICODE = new SqlParameter("@DestFicode", D_FICODE);
                                            SqlParameter DGCODE = new SqlParameter("@DestGcode", D_GCODE);
                                            cmd.Parameters.Add(SFICODE);
                                            cmd.Parameters.Add(SGCODE);
                                            cmd.Parameters.Add(DFICODE);
                                            cmd.Parameters.Add(DGCODE); 
                                            cmd.ExecuteNonQuery();

                                            try
                                            {
                                                EDPCommon.ClearDataTable_EDP(ds.Tables["SOURCE_DEFAULT_BRNCH_NAME"]);
                                                cmd = new SqlCommand("select * from Branch where ficode='" + S_FICODE + "' and gcode='" + S_GCODE + "' AND BRNCH_CODE=1", edpcon.mycon);
                                                da.SelectCommand = cmd; 
                                                da.Fill(ds, "SOURCE_DEFAULT_BRNCH_NAME");

                                                if (ds.Tables["SOURCE_DEFAULT_BRNCH_NAME"].Rows.Count > 0)
                                                {
                                                    int BR_Code = Convert.ToInt32(edpcom.GetresultS("SELECT MAX(BRNCH_CODE) FROM Branch WHERE FICODE='" + D_FICODE + "' AND GCODE='" + D_GCODE + "'", edpcon.mycon));
                                                    BR_Code++;
                                                    edpcom.RunCommand("INSERT INTO BRANCH (FICode,GCode,BRNCH_CODE,BRNCH_NAME,BRNCH_ADD1,BRNCH_ADD2,BRNCH_CITY,BRNCH_STATE,BRNCH_PIN,BRNCH_CST,BRNCH_SST,BRNCH_TELE1,BRNCH_TELE2,BRNCH_TELE3,BRNCH_PAN1,BRNCH_PAN2,VAT_DET,BRNCH_FAX,BRNCH_EMAIL,CONTACT_PERSON,PERSON_DESIG,FREEZE_FROM,FREEZE_TO,COUNTRY,EX_REG_NO,EX_DIV,EX_COMM,ECC_NO,EX_RANGE,Brnch_Alias,Stax,STT,TAN,STAXNO,DIN1,DIN2,DIN3,DIN4,TIN,Comp_Type,Range,Website)" +
                                                        " SELECT '" + D_FICODE + "','" + D_GCODE + "'," + BR_Code + ",BRNCH_NAME,BRNCH_ADD1,BRNCH_ADD2,BRNCH_CITY,BRNCH_STATE,BRNCH_PIN,BRNCH_CST,BRNCH_SST,BRNCH_TELE1,BRNCH_TELE2,BRNCH_TELE3,BRNCH_PAN1,BRNCH_PAN2,VAT_DET,BRNCH_FAX,BRNCH_EMAIL,CONTACT_PERSON,PERSON_DESIG,FREEZE_FROM,FREEZE_TO,COUNTRY,EX_REG_NO,EX_DIV,EX_COMM,ECC_NO,EX_RANGE,Brnch_Alias,Stax,STT,TAN,STAXNO,DIN1,DIN2,DIN3,DIN4,TIN," +
                                                        " Comp_Type,Range,Website FROM BRANCH WHERE Ficode='" + S_FICODE + "' AND GCODE='" + S_GCODE + "' AND BRNCH_CODE=1", edpcon.mycon);
                                                        //" VALUES ('" + D_FICODE + "','" + D_GCODE + "'," + BR_Code + ",'" + ds.Tables["SOURCE_DEFAULT_BRNCH_NAME"].Rows[0]["BRNCH_NAME"] + "','" + ds.Tables["SOURCE_DEFAULT_BRNCH_NAME"].Rows[0]["BRNCH_ADD1"] + "','" + ds.Tables["SOURCE_DEFAULT_BRNCH_NAME"].Rows[0]["BRNCH_ADD2"] + "','" + ds.Tables["SOURCE_DEFAULT_BRNCH_NAME"].Rows[0]["BRNCH_CITY"] + "','" + ds.Tables["SOURCE_DEFAULT_BRNCH_NAME"].Rows[0]["BRNCH_STATE"] + "')", edpcon.mycon);
                                                }
                                            }
                                            catch { }

                                            if (Information.IsNothing(ds.Tables["CNT"]) == false)
                                            {
                                                ds.Tables["CNT"].Clear();
                                                ds.Tables["CNT"].Reset();
                                            }
                                            cmd = new SqlCommand("select BRNCH_NAME from Branch where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "'", edpcon.mycon);
                                            da.SelectCommand = cmd;
                                            da.Fill(ds, "CNT");
                                            edpcon.Close();
                                            //EDPProgressBar.ThreadingProgress ThrdProgrs = new ThreadingProgress(ds.Tables["CNT"]);
                                            //ThrdProgrs.ShowDialog();
                                            //EDPMessage.Show("Data Copy Successfully", "Branch Copy", EDPMessage.MessageBoxButton.EDP_OK);
                                            edpcon.Close();
                                            //}
                                            //else
                                            //    return;
                                        }
                                        if (chkUserProfile.Checked || chk_AllMst.Checked)
                                        {
                                            //EDPMessage.Show("Data Should be Over Written", "User Profile Copy", EDPMessage.MessageBoxButton.EDP_YES_NO);
                                            //if (EDPMessage.ButtonResult == "edpYES")
                                            //{
                                            edpcon.Close();
                                            edpcon.Open();
                                            string strdproc = "User_Profile_COPY";
                                            cmd = new SqlCommand(strdproc, edpcon.mycon);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            SqlParameter SFICODE = new SqlParameter("@SourceFicode", S_FICODE);
                                            SqlParameter SGCODE = new SqlParameter("@SourceGcode", S_GCODE);
                                            SqlParameter DFICODE = new SqlParameter("@DestFicode", D_FICODE);
                                            SqlParameter DGCODE = new SqlParameter("@DestGcode", D_GCODE);
                                            cmd.Parameters.Add(SFICODE);
                                            cmd.Parameters.Add(SGCODE);
                                            cmd.Parameters.Add(DFICODE);
                                            cmd.Parameters.Add(DGCODE);
                                            cmd.ExecuteNonQuery();
                                            if (Information.IsNothing(ds.Tables["CNT"]) == false)
                                            {
                                                ds.Tables["CNT"].Clear();
                                                ds.Tables["CNT"].Reset();
                                            }
                                            cmd = new SqlCommand("select * from AccessBranch where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "'", edpcon.mycon);
                                            da.SelectCommand = cmd;
                                            da.Fill(ds, "CNT");
                                            edpcon.Close();
                                            //EDPProgressBar.ThreadingProgress ThrdProgrs = new ThreadingProgress(ds.Tables["CNT"]);
                                            //ThrdProgrs.ShowDialog();
                                            //EDPMessage.Show("Data Copy Successfully", "User Profile Copy", EDPMessage.MessageBoxButton.EDP_OK);
                                            edpcon.Close();
                                            //}
                                            //else
                                            //    return;
                                        }
                                        if (chk_Currency.Checked || chk_AllMst.Checked)
                                        {
                                            //EDPMessage.Show("Data Should be Over Written", "Currency Copy", EDPMessage.MessageBoxButton.EDP_YES_NO);
                                            //if (EDPMessage.ButtonResult == "edpYES")
                                            //{
                                            edpcon.Close();
                                            edpcon.Open();
                                            string strdproc = "Curr_COPY";
                                            cmd = new SqlCommand(strdproc, edpcon.mycon);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            SqlParameter SFICODE = new SqlParameter("@SourceFicode", S_FICODE);
                                            SqlParameter SGCODE = new SqlParameter("@SourceGcode", S_GCODE);
                                            SqlParameter DFICODE = new SqlParameter("@DestFicode", D_FICODE);
                                            SqlParameter DGCODE = new SqlParameter("@DestGcode", D_GCODE);
                                            cmd.Parameters.Add(SFICODE);
                                            cmd.Parameters.Add(SGCODE);
                                            cmd.Parameters.Add(DFICODE);
                                            cmd.Parameters.Add(DGCODE);
                                            cmd.ExecuteNonQuery();
                                            if (Information.IsNothing(ds.Tables["CNT"]) == false)
                                            {
                                                ds.Tables["CNT"].Clear();
                                                ds.Tables["CNT"].Reset();
                                            }
                                            cmd = new SqlCommand("select CURR_DESC from currency where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "'", edpcon.mycon);
                                            da.SelectCommand = cmd;
                                            da.Fill(ds, "CNT");
                                            edpcon.Close();
                                            //EDPProgressBar.ThreadingProgress ThrdProgrs = new ThreadingProgress(ds.Tables["CNT"]);
                                            //ThrdProgrs.ShowDialog();
                                            //EDPMessage.Show("Data Copy Successfully", "Currency Copy", EDPMessage.MessageBoxButton.EDP_OK);
                                            edpcon.Close();
                                            //}
                                            //else
                                            //    return;
                                        }
                                        if (chkConfigaration.Checked || chk_AllMst.Checked)
                                        {
                                            try
                                            {
                                                //EDPMessage.Show("Data Should be Over Written", "Configaration Copy", EDPMessage.MessageBoxButton.EDP_YES_NO);
                                                //if (EDPMessage.ButtonResult == "edpYES")
                                                //{
                                                edpcon.Close();
                                                edpcon.Open();
                                                string strdproc = "CONFIGARATION_COPY";
                                                cmd = new SqlCommand(strdproc, edpcon.mycon);
                                                cmd.CommandType = CommandType.StoredProcedure;
                                                SqlParameter SFICODE = new SqlParameter("@SourceFicode", S_FICODE);
                                                SqlParameter SGCODE = new SqlParameter("@SourceGcode", S_GCODE);
                                                SqlParameter DFICODE = new SqlParameter("@DestFicode", D_FICODE);
                                                SqlParameter DGCODE = new SqlParameter("@DestGcode", D_GCODE);
                                                cmd.Parameters.Add(SFICODE);
                                                cmd.Parameters.Add(SGCODE);
                                                cmd.Parameters.Add(DFICODE);
                                                cmd.Parameters.Add(DGCODE);
                                                cmd.ExecuteNonQuery();
                                                if (Information.IsNothing(ds.Tables["CNT"]) == false)
                                                {
                                                    ds.Tables["CNT"].Clear();
                                                    ds.Tables["CNT"].Reset();
                                                }
                                                int fyear = 0, Lyear = 0;
                                                fyear = Convert.ToDateTime(TRV_COMPNY.SelectedNode.Text.Substring(0, 10)).Year;
                                                Lyear = Convert.ToDateTime(TRV_COMPNY.SelectedNode.Text.Substring(13)).Year;
                                                string jyear = fyear.ToString().Substring(2) + "-" + Lyear.ToString().Substring(2);
                                                string jyear2 = fyear.ToString().Substring(2) + "" + Lyear.ToString().Substring(2);

                                                fyear = edpcom.CURRCO_SDT.Year;
                                                Lyear = edpcom.CURRCO_EDT.Year;
                                                string Cyear = fyear.ToString().Substring(2) + "-" + Lyear.ToString().Substring(2);
                                                string Cyear2 = fyear.ToString().Substring(2) + "" + Lyear.ToString().Substring(2);

                                                edpcon.Close();
                                                edpcon.Open();

                                                cmd = new SqlCommand("select * from docnumber where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "'", edpcon.mycon);
                                                da.SelectCommand = cmd;
                                                da.Fill(ds, "suffix");
                                                for (int i = 0; i <= ds.Tables["suffix"].Rows.Count - 1; i++)
                                                {
                                                    if (Convert.ToString(ds.Tables["suffix"].Rows[i]["suffix"]).Trim() == jyear)
                                                    {
                                                        cmd = new SqlCommand("update docnumber set suffix='" + Cyear + "' where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "' and T_ENTRY ='" + ds.Tables["suffix"].Rows[i]["T_ENTRY"] + "' and DESCCODE ='" + ds.Tables["suffix"].Rows[i]["DESCCODE"] + "' ", edpcon.mycon);
                                                        cmd.ExecuteNonQuery();
                                                    }
                                                    else if (Convert.ToString(ds.Tables["suffix"].Rows[i]["suffix"]).Trim() == jyear2)
                                                    {
                                                        cmd = new SqlCommand("update docnumber set suffix='" + Cyear2 + "' where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "' and T_ENTRY ='" + ds.Tables["suffix"].Rows[i]["T_ENTRY"] + "' and DESCCODE ='" + ds.Tables["suffix"].Rows[i]["DESCCODE"] + "' ", edpcon.mycon);
                                                        cmd.ExecuteNonQuery();
                                                    }
                                                }



                                                
                                                //cmd = new SqlCommand("select * from WACCOPTN where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "'", edpcon.mycon);
                                                //da.SelectCommand = cmd;
                                                //da.Fill(ds, "CNT");
                                                //edpcon.Close();
                                                //EDPProgressBar.ThreadingProgress ThrdProgrs = new ThreadingProgress(ds.Tables["CNT"]);
                                                //ThrdProgrs.ShowDialog();
                                                //EDPMessage.Show("Data Copy Successfully", "Configaration Copy", EDPMessage.MessageBoxButton.EDP_OK);
                                                edpcon.Close();
                                                //}
                                                //else
                                                //    return;
                                            }
                                            catch { }
                                        }
                                        if (chk_Consignee.Checked || chk_AllMst.Checked)
                                        {
                                            //EDPMessage.Show("Data Should be Over Written", "Consignee Party Copy", EDPMessage.MessageBoxButton.EDP_YES_NO);
                                            //if (EDPMessage.ButtonResult == "edpYES")
                                            //{
                                            edpcon.Close();
                                            edpcon.Open();
                                            string strdproc = "CONSIGNING_PARTY_COPY";
                                            cmd = new SqlCommand(strdproc, edpcon.mycon);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            SqlParameter SFICODE = new SqlParameter("@SourceFicode", S_FICODE);
                                            SqlParameter SGCODE = new SqlParameter("@SourceGcode", S_GCODE);
                                            SqlParameter DFICODE = new SqlParameter("@DestFicode", D_FICODE);
                                            SqlParameter DGCODE = new SqlParameter("@DestGcode", D_GCODE);
                                            cmd.Parameters.Add(SFICODE);
                                            cmd.Parameters.Add(SGCODE);
                                            cmd.Parameters.Add(DFICODE);
                                            cmd.Parameters.Add(DGCODE); 
                                            cmd.ExecuteNonQuery();
                                            if (Information.IsNothing(ds.Tables["CNT"]) == false)
                                            {
                                                ds.Tables["CNT"].Clear();
                                                ds.Tables["CNT"].Reset();
                                            }
                                            cmd = new SqlCommand("select * from ReffPartyDetails where ficode='" + D_FICODE + "' and gcode='" + D_GCODE + "'", edpcon.mycon);
                                            da.SelectCommand = cmd;
                                            da.Fill(ds, "CNT");
                                            edpcon.Close();
                                            //EDPProgressBar.ThreadingProgress ThrdProgrs = new ThreadingProgress(ds.Tables["CNT"]);
                                            //ThrdProgrs.ShowDialog();                                            
                                            edpcon.Close();
                                            //}
                                            //else
                                            //    return;
                                        }
                                    }
                                    else
                                    {
                                        EDPMessage.Show("Transaction Exists. Data Can Not Copy ", "Data Copy", EDPMessage.MessageBoxButton.EDP_OK);
                                        return;
                                    }
                                    //EDPMessage.Show("Data Copy Successfully", "Configaration Copy", EDPMessage.MessageBoxButton.EDP_OK);
                                    //this.Close();
                                }
                            }
                            EDPMessage.Show("Data Copy Successfully", "Configaration Copy", EDPMessage.MessageBoxButton.EDP_OK);
                            this.Close();
                        }
                        //EDPMessage.Show("Data Copy Successfully", "Configaration Copy", EDPMessage.MessageBoxButton.EDP_OK);
                        //this.Close();
                    }
                    catch { }
                }
            }
            catch
            { }
        }
        private void All_Clear()
        {
            chkbx_Acc.Checked = false;
            chkbx_InvMst.Checked = false;
            chk_AllMst.Checked = false;           
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCopyAcc_FormClosing(object sender, FormClosingEventArgs e)
        {
            edpcom.UpdateMidasLog(this, false);
            edpcom.saveFormPosition(this.Name, this.Location);
        }

        private void chkbx_Acc_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkbx_Acc.Checked == true || chkbx_InvMst.Checked == true)
            {
                chk_AllMst.Enabled = false;
            }
            else
            {
                chk_AllMst.Enabled = true;
            }
        }

        private void chkbx_InvMst_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkbx_InvMst.Checked == true || chkbx_Acc.Checked == true)
            {
                chk_AllMst.Enabled = false;
            }
            else
            {
                chk_AllMst.Enabled = true;
            }
        }

        private void chk_AllMst_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk_AllMst.Checked == true)
            {
                chkbx_Acc.Enabled = false;
                chkbx_InvMst.Enabled = false;
            }
            else
            {
                chkbx_Acc.Enabled = true;
                chkbx_InvMst.Enabled = true;
            }
        }

        private void frmCopyAcc_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.Close();
            //}
            if (e.Control)
            {
                if (e.KeyCode == Keys.H)
                {
                    //chkBranch.Visible = true;
                    chkUserProfile.Visible = true;
                    chk_Consignee.Visible = true;
                    chepricelist.Visible = true;
                }
            }
        }

        private void chkUserProfile_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkUserProfile.Checked == true)
            {
                chkUserProfile.Enabled = false;
                chkUserProfile.Enabled = false;
            }
            else
            {
                chkUserProfile.Enabled = true;
                chkUserProfile.Enabled = true;
            }
        }

        private void chkBranch_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkBranch.Checked == true)
            {
                chkBranch.Enabled = false;
                chkBranch.Enabled = false;
            }
            else
            {
                chkBranch.Enabled = true;
                chkBranch.Enabled = true;
            }
        }

        private void chk_Currency_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk_Currency.Checked == true)
            {
                chk_Currency.Enabled = false;
                chk_Currency.Enabled = false;
            }
            else
            {
                chk_Currency.Enabled = true;
                chk_Currency.Enabled = true;
            }
        }

        private void chkConfigaration_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkConfigaration.Checked == true)
            {
                chkConfigaration.Enabled = false;
                chkConfigaration.Enabled = false;
            }
            else
            {
                chkConfigaration.Enabled = true;
                chkConfigaration.Enabled = true;
            }
        } 

        private void TRV_COMPNY_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                lbl_Select_Company.Text = "Selected Company  :  " + TRV_COMPNY.SelectedNode.Parent.Text.ToString() + " [ " + Convert.ToString(TRV_COMPNY.SelectedNode.Text.Substring(0, 10)) + "-" + Convert.ToString(TRV_COMPNY.SelectedNode.Text.Substring(12, 10)) + " ]";
            }
            catch { }
        }

        private void chkUserProfile_Click(object sender, EventArgs e)
        {
            //if (chkUserProfile.Checked)
            //    chkBranch.Checked = true;
            //else
            //    chkBranch.Checked = false;
        }

        private void chkUserProfile_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void UpdtGrp_GlmstForLedgTrig(SqlConnection con)
        {
            string sqlstr = " if exists (select * from sysobjects where id = object_id('UpdtGrpForLedgTrig')" + Environment.NewLine;
            sqlstr = sqlstr + " and OBJECTPROPERTY(id, 'IsTrigger') = 1)" + Environment.NewLine;
            sqlstr = sqlstr + " drop Trigger UpdtGrpForLedgTrig" + Environment.NewLine;
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { }

            try
            {
                sqlstr = "Create Trigger UpdtGrpForLedgTrig On glmst For Update As " + Environment.NewLine;
                sqlstr = sqlstr + " If Exists(Select I.* From Inserted as I,Deleted as D Where I.CurBal <> D.CurBal and I.Mtype='S')" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " Update glmst" + Environment.NewLine;
                sqlstr = sqlstr + " Set Glmst.CurBal = Glmst.CurBal + I.CurBal - D.CurBal " + Environment.NewLine;
                sqlstr = sqlstr + " From Glmst, Inserted as I, Deleted as D " + Environment.NewLine;
                sqlstr = sqlstr + " Where  Glmst.SGroup=I.Prev_Group  and Glmst.Mtype='S' and  Glmst.GCode= I.GCode and  Glmst.FIcode = I.FIcode " + Environment.NewLine;
                sqlstr = sqlstr + " End" + Environment.NewLine;
                sqlstr = sqlstr + " If Exists(Select I.* From Inserted as I,Deleted as D Where I.CurBal <> D.CurBal and I.Mtype='L')" + Environment.NewLine;
                sqlstr = sqlstr + " Begin" + Environment.NewLine;
                sqlstr = sqlstr + " Update grp" + Environment.NewLine;
                sqlstr = sqlstr + " Set Grp.CurBal = Grp.CurBal + I.CurBal - D.CurBal " + Environment.NewLine;
                sqlstr = sqlstr + " From Grp, Inserted as I, Deleted as D Where  Grp.MGroup= I.MGroup and Grp.GCode = I.GCode and  Grp.FIcode = I.FIcode" + Environment.NewLine;
                sqlstr = sqlstr + " Update Glmst" + Environment.NewLine;
                sqlstr = sqlstr + " Set Glmst.CurBal = Glmst.CurBal + I.CurBal - D.CurBal" + Environment.NewLine;
                sqlstr = sqlstr + " From Glmst, Inserted as I, Deleted as D Where  Glmst.SGroup=I.SGroup  and Glmst.Mtype='S'" + Environment.NewLine;
                sqlstr = sqlstr + " and  Glmst.GCode= I.GCode and  Glmst.FIcode = I.FIcode" + Environment.NewLine;

                sqlstr = sqlstr + " Update G1" + Environment.NewLine;
                sqlstr = sqlstr + " Set G1.CurBal = G1.CurBal + I.CurBal - D.CurBal" + Environment.NewLine;
                sqlstr = sqlstr + " From Glmst,GLMST AS G1, Inserted as I, Deleted as D" + Environment.NewLine;
                sqlstr = sqlstr + " Where  Glmst.SGroup=I.SGroup and Glmst.Mtype='S' and  Glmst.GCode= I.GCode and  Glmst.FIcode = I.FIcode" + Environment.NewLine;
                sqlstr = sqlstr + " AND Glmst.Prev_Group=G1.SGROUP AND Glmst.MTYPE=G1.MTYPE AND Glmst.FICODE=G1.FICODE AND Glmst.GCODE=G1.GCODE" + Environment.NewLine;

                sqlstr = sqlstr + " Update G2" + Environment.NewLine;
                sqlstr = sqlstr + " Set G2.CurBal = G2.CurBal + I.CurBal - D.CurBal" + Environment.NewLine;
                sqlstr = sqlstr + " From Glmst,GLMST AS G1,GLMST AS G2, Inserted as I, Deleted as D" + Environment.NewLine;
                sqlstr = sqlstr + " Where  Glmst.SGroup=I.SGroup and Glmst.Mtype='S' and  Glmst.GCode= I.GCode and  Glmst.FIcode = I.FIcode" + Environment.NewLine;
                sqlstr = sqlstr + " AND Glmst.Prev_Group=G1.SGROUP AND Glmst.MTYPE=G1.MTYPE AND Glmst.FICODE=G1.FICODE AND Glmst.GCODE=G1.GCODE" + Environment.NewLine;
                sqlstr = sqlstr + " AND G1.Prev_Group=G2.SGROUP AND G1.MTYPE=G2.MTYPE AND G1.FICODE=G2.FICODE AND G1.GCODE=G2.GCODE" + Environment.NewLine;

                sqlstr = sqlstr + " Update G3" + Environment.NewLine;
                sqlstr = sqlstr + " Set G3.CurBal = G3.CurBal + I.CurBal - D.CurBal" + Environment.NewLine;
                sqlstr = sqlstr + " From Glmst,GLMST AS G1,GLMST AS G2,GLMST AS G3, Inserted as I, Deleted as D" + Environment.NewLine;
                sqlstr = sqlstr + " Where  Glmst.SGroup=I.SGroup and Glmst.Mtype='S' and  Glmst.GCode= I.GCode and  Glmst.FIcode = I.FIcode" + Environment.NewLine;
                sqlstr = sqlstr + " AND Glmst.Prev_Group=G1.SGROUP AND Glmst.MTYPE=G1.MTYPE AND Glmst.FICODE=G1.FICODE AND Glmst.GCODE=G1.GCODE" + Environment.NewLine;
                sqlstr = sqlstr + " AND G1.Prev_Group=G2.SGROUP AND G1.MTYPE=G2.MTYPE AND G1.FICODE=G2.FICODE AND G1.GCODE=G2.GCODE" + Environment.NewLine;
                sqlstr = sqlstr + " AND G2.Prev_Group=G3.SGROUP AND G2.MTYPE=G3.MTYPE AND G2.FICODE=G3.FICODE AND G2.GCODE=G3.GCODE" + Environment.NewLine;

                sqlstr = sqlstr + " End";
                cmd = new SqlCommand(sqlstr, con);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
            }
            catch { }
        }

               
    }
}