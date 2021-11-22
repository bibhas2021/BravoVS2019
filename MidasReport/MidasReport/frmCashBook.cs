using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using EDPComponent;
using Edpcom;
using System.Collections;
using Microsoft.VisualBasic;

namespace MidasReport
{
    public partial class frmCashBook : Form
    {
        Int64 vchno;
        int p, i, j, k, cv;
        string Str, T1, T2, em, stds, stde, mm, yy, DURATION, strledg;
        double OPB, COPB, CRDAMT, CRDAMT1, DBTAMT, DBTAMT1, CLOSEAMT, CCLOSEAMT, TOTALAMT, BALANCE, BAL, OLDBAL;
        DateTime CD;
        bool CHK = true,CHKNAR=false;
        ArrayList s = new ArrayList();
        ArrayList AllLedg = new ArrayList();
        ArrayList Ledg = new ArrayList();
        Edpcom.EDPConnection conn = new EDPConnection();
        //Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        static Edpcom.EDPCommon edpcom = new EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon comm = new EDPCommon();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable Dt = new DataTable("DT");
        DataColumn DC = new DataColumn("Ledger Name");
        DataColumn DC1 = new DataColumn("Ledger Code");
        DataRow Dr;
        DataSet ds = new DataSet();
        DataSet test = new DataSet();
        DataSet test1 = new DataSet();
        DataSet NDS1 = new DataSet();
        DataSet NDS2 = new DataSet();
        DataSet SEDATE = new DataSet();
        DataSet SGL = new DataSet();
        DataSet dsBRANCH = new DataSet();
        ArrayList SplitStr = new ArrayList();
     
        DataTable DtCollection = new DataTable("DT");
        DataColumn DTC1 = new DataColumn("Date");
        DataColumn DTC2 = new DataColumn("VoucherNo");
        DataColumn DTC3 = new DataColumn("Description");
        DataColumn DTC4 = new DataColumn("SubDesc");
        DataColumn DTC5 = new DataColumn("DebitAmt");
        DataColumn DTC6 = new DataColumn("CreditAmt");
        DataColumn DTC7 = new DataColumn("Balance");
        DataRow Dr1;
        DateTime DT11;
        private int SubGroup;

        public frmCashBook()
        {
            InitializeComponent();
        }

        public frmCashBook(int subgroup)
        {
            //InitializeComponent();
            try
            {
                InitializeComponent();
                conn.Open();

                conn.Close();
                SubGroup = subgroup;
                if (subgroup == 1)
                    label13.Text = "          Cash Book";
                if (subgroup == 2)
                    label13.Text = "          Bank Book";
                if (subgroup == 3)
                    label13.Text = "          General Ledger";
            }
            catch { }

        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_Minz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void chbConsolidated_Click(object sender, EventArgs e)
        {
            if (chbConsolidated.Checked == true)
            {
                chbNaration.Checked = false;
                chbNaration.Enabled = false;
                chbVoucher.Checked = false;
                chbVoucher.Enabled = false;
            }
            else
            {
                chbNaration.Enabled = true;
                chbVoucher.Enabled = true;
            }
        }

        private void comboDialog1_Click(object sender, EventArgs e)
        {
            try
            {
                Dt.Clear();
                Dt.Columns.Clear();
                AllLedg.Clear();
                Dt.Columns.Add(DC);
                Dt.Columns.Add(DC1);

                conn.Open();
                    if (SubGroup == 1)
                        AllLedg.Add(14);
                    if (SubGroup == 2)
                    {
                        AllLedg.Add(4);
                        AllLedg.Add(15);
                    }
                    if (SubGroup == 3)
                    {

                        //=========================================================================
                        SGL.Clear();
                        cmd = new SqlCommand("SELECT LDESC,GLCODE FROM GLMST WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND MTYPE='L' AND PREV_GROUP = 0 AND SGROUP=0 ORDER BY GLCODE ", conn.mycon);
                        adp.SelectCommand = cmd;
                        adp.Fill(SGL, "SG");

                        for (i = 0; i <= SGL.Tables["SG"].Rows.Count - 1; i++)
                        {

                            Dr = Dt.NewRow();
                            Dr[0] = Convert.ToString(SGL.Tables["SG"].Rows[i][0]);
                            Dr[1] = Convert.ToString(SGL.Tables["SG"].Rows[i][1]);
                            Dt.Rows.Add(Dr);
                        }

                        if (SGL.Tables["SG"].Rows.Count > 0)
                        {
                            SGL.Reset();
                            SGL.Clear();
                        }
                        //=========================================================================

                        cmd = new SqlCommand("SELECT SGROUP FROM glmst WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND MTYPE='S' AND PREV_GROUP = 0 AND SGROUP<>4 AND SGROUP<>14 AND SGROUP<>15", conn.mycon);
                        adp.SelectCommand = cmd;
                        adp.Fill(SGL, "SG");
                        for (i = 0; i <= SGL.Tables["SG"].Rows.Count - 1; i++)
                        {
                            AllLedg.Add(Convert.ToInt32(SGL.Tables["SG"].Rows[i][0]));
                        }

                        if (SGL.Tables["SG"].Rows.Count > 0)
                        {
                            SGL.Reset();
                            SGL.Clear();
                        }

                    }

                for (p = 0; p <= AllLedg.Count - 1; p++)
                {
                    s.Clear();
                    s.Add(Convert.ToInt32(AllLedg[p]));
                    for (j = 0; j <= s.Count - 1; j++)
                    {
                        if (Information.IsNothing(ds.Tables["Sl"]) == false)
                        {
                            ds.Tables["Sl"].Clear();
                            ds.Clear();
                        }

                        k = Convert.ToInt32(s[j]);
                        cmd = new SqlCommand("SELECT DISTINCT SGROUP,Prev_Group,MType,LDESC,GLCODE FROM glmst WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND (PREV_GROUP = " + k + ")", conn.mycon);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "Sl");
                        conn.Close();
                        for (i = 0; i <= ds.Tables["Sl"].Rows.Count - 1; i++)
                        {
                            if (k != Convert.ToInt32(ds.Tables["Sl"].Rows[i][0]))
                                s.Add(Convert.ToInt32(ds.Tables["Sl"].Rows[i][0]));

                            if ((Convert.ToChar(ds.Tables["Sl"].Rows[i][2]) == 'L') & (Convert.ToInt32(ds.Tables["Sl"].Rows[i][0]) == Convert.ToInt32(ds.Tables["Sl"].Rows[i][1])))
                            {
                                Dr = Dt.NewRow();
                                Dr[0] = Convert.ToString(ds.Tables["Sl"].Rows[i][3]);
                                Dr[1] = Convert.ToString(ds.Tables["Sl"].Rows[i][4]);
                                Dt.Rows.Add(Dr);
                            }

                        }

                    }

                }
                comboDialog1.Heading = "Select Cash A/C";
                comboDialog1.LookUpTable = Dt;
                comboDialog1.ReturnIndex = 1;
                comboDialog1.Connection = conn.mycon;
               
            }
            catch { }
            }

        private void comboDialog1_CloseUp(object sender, EventArgs e)
        {
            try
            {
                if ((comboDialog1.ReturnValue != null) && (comboDialog1.ReturnValue != ""))
                   vchno = Convert.ToInt64(comboDialog1.ReturnValue);
            }
                
            catch { }
        }       
       
        private void GetDetails()
        {
            try
            {
                    ds.Clear();
                    test.Clear();
                    cmd = new SqlCommand("SELECT T_ENTRY,VOUCHER,GLCODE,VCHDATE FROM VCHR WHERE (FICode = " + comm.CurrentFicode + " ) AND (GCode = " + comm.PCURRENT_GCODE + " ) AND (GLCODE=" + vchno + ") ORDER BY VCHDATE", conn.mycon);
                    adp.SelectCommand = cmd;
                    adp.Fill(ds, "Grid");

                    if (ds.Tables["Grid"].Rows.Count > 0)
                    {
                        for (i = 0; i <= ds.Tables["Grid"].Rows.Count - 1; i++)
                        {
                            Str = "SELECT DISTINCT V.VCHDATE AS Date,V.USER_VCH AS Voucher_No,G.LDESC AS Description,V.CRAMT AS Debit,V.DBAMT AS Credit,";
                            Str = Str + "V.T_ENTRY AS T,V.VOUCHER AS V FROM VCHR V,GLMST G WHERE ";
                            Str = Str + "V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.GLCODE=" + ds.Tables["Grid"].Rows[i][2] + " AND V.T_ENTRY='" + Convert.ToString(ds.Tables["Grid"].Rows[i][0]) + "' AND V.VOUCHER=" + ds.Tables["Grid"].Rows[i][1] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "' AND '" + edpcom.getSqlDateStr(Convert.ToDateTime((dtpFromDate.Value).AddDays(-1))) + "' AND G.MTYPE='L' ";
                            string stri = Convert.ToString(dtpFromDate.Value.Month);
                            cmd = new SqlCommand(Str, conn.mycon);
                            adp.SelectCommand = cmd;
                            adp.Fill(test, "FINLEDG");
                        }
                        cmd = new SqlCommand("SELECT OPBAL FROM GLMST WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND GLCODE=" + vchno + "", conn.mycon);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "OPBAL");
                        OPB = Convert.ToDouble(ds.Tables["OPBAL"].Rows[0][0]);

                        CRDAMT = 0.00;
                        DBTAMT = 0.00;
                        for (i = 0; i <= test.Tables["FINLEDG"].Rows.Count - 1; i++)
                        {
                            CRDAMT = CRDAMT + Convert.ToDouble(test.Tables["FINLEDG"].Rows[i][3]);
                            DBTAMT = DBTAMT + Convert.ToDouble(test.Tables["FINLEDG"].Rows[i][4]);

                        }
                        cv = i + 1;

                    }
                    else
                    {
                        ds.Clear();
                        adp.Fill(test, "FINLEDG");
                        CLOSEAMT = OPB;
                    }


                    conn.Close();
                    if (test.Tables["FINLEDG"].Rows.Count > 0)
                    {

                        if (OPB < 0)
                        {
                            CRDAMT = CRDAMT + OPB;
                            COPB = OPB;
                        }
                        else
                            DBTAMT = DBTAMT + OPB;



                        if (DBTAMT >= CRDAMT)
                            CLOSEAMT = DBTAMT - CRDAMT;

                        else
                            CLOSEAMT = DBTAMT - CRDAMT;

                    }
                    else
                        CLOSEAMT = OPB;
                    //========================================================For Display=============================
                    if (rbDaily.Checked == true)
                    {
                        if (chbConsolidated.Checked == false)
                            ShowDetails();
                        else
                            GetConsolidatedDaily();
                    }
                    if (rbSide.Checked == true)
                    {
                        if (chbConsolidated.Checked == false)
                            ShowSideBalance();
                        else
                        {
                            MessageBox.Show("If Consolidated is checked then Side Balance can not be displayed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            CHK = false;
                            return;
                        }
                    }

                    if (rbMonthly.Checked == true)
                        if (chbConsolidated.Checked == true)
                            GetConsolidatedMonthly();
                        else
                            GetMonthlyBalance();
                
            }
            catch { }
        }

//=================================================Start Monthly Balance with voucher and naration=================
        private void GetMonthlyBalance()
        {
            try
            {
                string str = dtpFromDate.Value.ToShortDateString();
                 yy = str.Substring(str.Length - 4, 4);
                 mm = str.Substring(str.Length - 7, 2);
                String mm1 = mm;
                String dd = str.Substring(str.Length - 10, 2);
                Boolean ch, ch1, b1=true, b2=true;
               // string DT;
                
                int nom;
                int pp;
                string str11 = dtpToDate.Value.ToShortDateString();
                String mm11 = str11.Substring(str11.Length - 7, 2);

                if (Convert.ToInt32(mm1) < Convert.ToInt32(mm11))
                    nom = Convert.ToInt32(mm11);
                else
                    nom = Convert.ToInt32(mm11) + 12;


                ch = true;
                ch1 = true;

                conn.Open();
                DtCollection.Clear();
                DtCollection.Columns.Clear();
                DtCollection.Columns.Add(DTC1);
                DtCollection.Columns.Add(DTC2);
                DtCollection.Columns.Add(DTC3);
                DtCollection.Columns.Add(DTC4);
                DtCollection.Columns.Add(DTC5);
                DtCollection.Columns.Add(DTC6);
               // DtCollection.Columns.Add(DTC7);
                cmd = new SqlCommand("SELECT T_ENTRY,VOUCHER,GLCODE,VCHDATE FROM VCHR WHERE (FICode = " + comm.CurrentFicode + " ) AND (GCode = " + comm.PCURRENT_GCODE + " ) AND (GLCODE=" + vchno + ") AND VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' ORDER BY VCHDATE", conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(ds, "Grid");

                BALANCE = CLOSEAMT;

                Dr1 = DtCollection.NewRow();
                Dr1[0] =Convert.ToString(dtpFromDate.Value.ToShortDateString());
                Dr1[1] = "         ";
                Dr1[2] = "         ";
                Dr1[3] = "Opening Bal.";
                if (BALANCE >= 0)
                {
                    Dr1[4] = BALANCE.ToString(frmCashBook.SetDecimalPlace());;
                    Dr1[5] = "         ";
                }
                else
                {
                    double BAl;
                    BAl = BALANCE * (-1);
                    Dr1[4] = "         ";
                    Dr1[5] = BAl.ToString(frmCashBook.SetDecimalPlace());
                }
                   
                DtCollection.Rows.Add(Dr1);

                for (pp = Convert.ToInt32(mm1); pp <= nom; pp++)
                {
                    ds.Clear();
                    test1.Clear();
                    DBTAMT1 = 0;
                    CRDAMT1 = 0;
                    DBTAMT = 0;
                    CRDAMT = 0;

                    if (ch1 == true)
                    {
                        mm = Convert.ToString(Convert.ToInt32(mm) + 0);
                        ch1 = false;
                    }
                    else
                        mm = Convert.ToString(Convert.ToInt32(mm) + 1);

                    if (Convert.ToInt32(mm) == 13)
                        mm = "1";

                    if ((Convert.ToInt32(mm) == 1) & (mm1 != "01") & (ch == true))
                    {
                        yy = Convert.ToString(Convert.ToInt32(yy) + 1);
                        ch = false;
                    }

                    if ((Convert.ToInt32(mm) == 1) || (Convert.ToInt32(mm) == 3) || (Convert.ToInt32(mm) == 5) || (Convert.ToInt32(mm) == 7) || (Convert.ToInt32(mm) == 8) || (Convert.ToInt32(mm) == 10) || (Convert.ToInt32(mm) == 12))
                        em = "31";
                    else
                    {
                        if (Convert.ToInt32(mm) == 2)
                        {
                            if (((Convert.ToInt32(yy) % 4) == 0) || ((Convert.ToInt32(yy) % 100) == 0))
                                em = "29";
                            else
                                em = "28";
                        }
                        else
                            em = "30";
                    }

                    if ((Convert.ToInt32(mm) > 0) & (Convert.ToInt32(mm) <= 9))
                        mm = "0" + mm + "";

                    stds = "01/" + mm + "/" + Convert.ToInt32(yy) + "";
                    stde = "" + em + "/" + mm + "/" + Convert.ToInt32(yy) + "";

                    DateTime stds1 = Convert.ToDateTime(stds);
                    DateTime stde1 = Convert.ToDateTime(stde);
                    cmd = new SqlCommand("SELECT T_ENTRY,VOUCHER,GLCODE,VCHDATE FROM VCHR WHERE (FICode = " + comm.CurrentFicode + " ) AND (GCode = " + comm.PCURRENT_GCODE + " ) AND (GLCODE=" + vchno + ") AND VCHDATE BETWEEN '" + edpcom.getSqlDateStr(stds1) + "' AND '" + edpcom.getSqlDateStr(stde1) + "' ORDER BY VCHDATE", conn.mycon);
                    adp.SelectCommand = cmd;
                    adp.Fill(ds, "Grid");

                    if (ds.Tables["Grid"].Rows.Count > 0)
                    {

                        for (i = 0; i <= ds.Tables["Grid"].Rows.Count - 1; i++)
                        {
                            Str = "SELECT DISTINCT V.VCHDATE AS Date,V.USER_VCH AS Voucher_No,G.LDESC AS Description,V.CRAMT AS Credit,V.DBAMT AS Debit,";
                            Str = Str + "V.T_ENTRY AS T,V.VOUCHER AS V,V.GLCODE FROM VCHR V,GLMST G WHERE ";
                            Str = Str + "V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.GLCODE=" + ds.Tables["Grid"].Rows[i][2] + " AND V.T_ENTRY='" + Convert.ToString(ds.Tables["Grid"].Rows[i][0]) + "' AND V.VOUCHER=" + ds.Tables["Grid"].Rows[i][1] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(stds1) + "' AND '" + edpcom.getSqlDateStr(stde1) + "' AND G.MTYPE='L' ";

                            cmd = new SqlCommand(Str, conn.mycon);
                            adp.SelectCommand = cmd;
                            adp.Fill(test1, "FINLEDG1");

                            CRDAMT1 = CRDAMT1 + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][3]);
                            DBTAMT1 = DBTAMT1 + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][4]);
                            CRDAMT = CRDAMT1;
                            DBTAMT = DBTAMT1;
                           
                            Dr1 = DtCollection.NewRow();
                            //if (b1 == true)
                            //{
                            //    b1 = false;
                            //    getMonth();
                            //}
                            //else
                                // Dr1[0] = "       ";


                            if (b1 == true)
                            {
                                Dr1[0] = Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]).ToShortDateString();
                                DT11 = Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]);

                                b1 = false;
                            }
                            if (DT11 == Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]))
                            {
                                if (b2 == false)
                                Dr1[0] = "           ";
                            }
                            else
                            {
                                Dr1[0] = Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]).ToShortDateString();
                                DT11 = Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]);
                            }

                            b2 = false;
                               
                            if (chbVoucher.Checked == true)
                                Dr1[1] = Convert.ToString(test1.Tables["FINLEDG1"].Rows[i][1]);
                            else
                                Dr1[1] = "    ";
      //==================================================For Retriving The Ledger Name of Respect To Choosing Account Ledger=========== 
                            //NDS1.Clear();
                            //cmd = new SqlCommand("SELECT DISTINCT GLCODE,T_ENTRY,VOUCHER FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND GLCODE <> " + test1.Tables["FINLEDG1"].Rows[i][7] + "", conn.mycon);
                            //adp.SelectCommand = cmd;
                            //adp.Fill(NDS1, "LEDG1");
                            //if (NDS1.Tables["LEDG1"].Rows.Count >= 2)
                            //{
                            //    T1 = Convert.ToString(test1.Tables["FINLEDG1"].Rows[i][5]);
                            //    TE(T1);
                            //    Dr1[2] = T2;
                            //}
                            //else if (NDS1.Tables["LEDG1"].Rows.Count == 1)
                            //{
                            //    cmd = new SqlCommand("SELECT DISTINCT G.LDESC FROM VCHR V,GLMST G WHERE V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.GLCODE=" + NDS1.Tables["LEDG1"].Rows[0][0] + " AND V.T_ENTRY='" + Convert.ToString(NDS1.Tables["LEDG1"].Rows[0][1]) + "' AND V.VOUCHER=" + NDS1.Tables["LEDG1"].Rows[0][2] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ", conn.mycon);
                            //    adp.SelectCommand = cmd;
                            //    adp.Fill(NDS1, "LEDG2");
                            //    Dr1[2] = Convert.ToString(NDS1.Tables["LEDG2"].Rows[0][0]);
                            //}


                            NDS1.Clear();
                            NDS2.Clear();

                            cmd = new SqlCommand("SELECT TOBY FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND GLCODE = " + test1.Tables["FINLEDG1"].Rows[i][7] + "", conn.mycon);
                            adp.SelectCommand = cmd;
                            adp.Fill(NDS1, "LEDG2");
                            if (NDS1.Tables["LEDG2"].Rows.Count >= 1)
                            {
                                cmd = new SqlCommand("SELECT TOBY FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND TOBY='" + NDS1.Tables["LEDG2"].Rows[0][0] + "'", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS1, "LEDG3");
                            }

                            if (NDS1.Tables["LEDG3"].Rows.Count >= 2)
                            {
                                cmd = new SqlCommand("SELECT DISTINCT GLCODE,T_ENTRY,VOUCHER FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND GLCODE <> " + test1.Tables["FINLEDG1"].Rows[i][7] + "", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS1, "LEDG1");

                                T1 = Convert.ToString(test1.Tables["FINLEDG1"].Rows[i][5]);
                                TE(T1);

                                Dr1[2] = MakeBold(T2 + "  ( As per Details )");

                                CHKNAR = true;

                                cmd = new SqlCommand("SELECT DISTINCT G.LDESC,V.CRAMT,V.DBAMT FROM VCHR V,GLMST G WHERE V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.T_ENTRY='" + Convert.ToString(NDS1.Tables["LEDG1"].Rows[0][1]) + "' AND V.VOUCHER=" + NDS1.Tables["LEDG1"].Rows[0][2] + " AND V.TOBY='By' AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS2, "LEDG1");
                                if (NDS2.Tables["LEDG1"].Rows.Count >= 1)
                                {
                                    for (int p = 0; p <= NDS2.Tables["LEDG1"].Rows.Count - 1; p++)
                                    {
                                        strledg = "";
                                        int slen;
                                        string space = " ";
                                        string space1 = "";
                                        double strlp = Convert.ToDouble(NDS2.Tables["LEDG1"].Rows[p][2]);
                                        strledg = Convert.ToString(NDS2.Tables["LEDG1"].Rows[p][0]).Trim();
                                        slen = strledg.Length;
                                        strledg = "";
                                        strledg = strlp.ToString(frmCashBook.SetDecimalPlace()).Trim();
                                        slen = slen + strledg.Length;
                                        for (int p1 = 0; p1 < (35 - slen); p1++)
                                        {
                                            space1 = space1 + space;
                                        }
                                        strledg = "";
                                        strledg = Convert.ToString(NDS2.Tables["LEDG1"].Rows[p][0]).Trim() + space1 + strlp.ToString(frmCashBook.SetDecimalPlace()).Trim() + " Db";
                                        Ledg.Add(strledg.Trim());
                                    }
                                }
                                cmd = new SqlCommand("SELECT DISTINCT G.LDESC,V.CRAMT,V.DBAMT FROM VCHR V,GLMST G WHERE V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.T_ENTRY='" + Convert.ToString(NDS1.Tables["LEDG1"].Rows[0][1]) + "' AND V.VOUCHER=" + NDS1.Tables["LEDG1"].Rows[0][2] + " AND V.TOBY='To' AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS2, "LEDG2");
                                if (NDS2.Tables["LEDG2"].Rows.Count >= 1)
                                {
                                    for (int p = 0; p <= NDS2.Tables["LEDG2"].Rows.Count - 1; p++)
                                    {
                                        strledg = "";
                                        int slen;
                                        string space = " ";
                                        string space1 = "";
                                        double strlp = Convert.ToDouble(NDS2.Tables["LEDG2"].Rows[p][1]);
                                        strledg = Convert.ToString(NDS2.Tables["LEDG2"].Rows[p][0]).Trim();
                                        slen = strledg.Length;
                                        strledg = "";
                                        strledg = strlp.ToString(frmCashBook.SetDecimalPlace()).Trim();
                                        slen = slen + strledg.Length;
                                        for (int p1 = 0; p1 < (50 - slen); p1++)
                                        {
                                            space1 = space1 + space;
                                        }
                                        strledg = "";
                                        strledg = Convert.ToString(NDS2.Tables["LEDG2"].Rows[p][0]).Trim() + space1 + strlp.ToString(frmCashBook.SetDecimalPlace()).Trim() + " Cr";
                                        Ledg.Add(strledg.Trim());
                                    }
                                }
                                NDS1.Clear();
                                NDS2.Clear();

                            }


                            if (NDS1.Tables["LEDG3"].Rows.Count == 1)
                            {

                                cmd = new SqlCommand("SELECT DISTINCT GLCODE,T_ENTRY,VOUCHER FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND GLCODE <> " + test1.Tables["FINLEDG1"].Rows[i][7] + "", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS1, "LEDG1");

                                cmd = new SqlCommand("SELECT DISTINCT G.LDESC FROM VCHR V,GLMST G WHERE V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.GLCODE=" + NDS1.Tables["LEDG1"].Rows[0][0] + " AND V.T_ENTRY='" + Convert.ToString(NDS1.Tables["LEDG1"].Rows[0][1]) + "' AND V.VOUCHER=" + NDS1.Tables["LEDG1"].Rows[0][2] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS2, "LEDG2");
                                Dr1[2] = MakeBold(Convert.ToString(NDS2.Tables["LEDG2"].Rows[0][0]));
                                NDS2.Clear();
                            }

       //==================================================End of Retriving The Ledger Name of Respect To Choosing Account Ledger===========                      
                            Dr1[3] = "         ";
                            Double ZZ;
                            ZZ = Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][4]);
                            if (ZZ != 0)
                                Dr1[4] = ZZ.ToString(frmCashBook.SetDecimalPlace());
                            else
                                Dr1[4] = "  ";
                            ZZ = Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][3]);
                            if (ZZ != 0)
                                Dr1[5] = ZZ.ToString(frmCashBook.SetDecimalPlace());
                            else
                                Dr1[5] = "  ";
                           
                            DtCollection.Rows.Add(Dr1);

                            if (CHKNAR == true)
                            {
                                CHKNAR = false;
                                //for (int p = 0; p <= SplitStr.Count - 1; p++)
                                for (int p = 0; p <= Ledg.Count - 1; p++)
                                {
                                    Dr1 = DtCollection.NewRow();
                                    Dr1[0] = "         ";
                                    Dr1[1] = "         ";
                                    // Dr1[2] = "     " + SplitStr[p];
                                    Dr1[2] = "   " + Ledg[p];
                                    Dr1[3] = "       ";
                                    Dr1[4] = "       ";
                                    Dr1[5] = "       ";
                                    DtCollection.Rows.Add(Dr1);
                                }
                                Ledg.Clear();
                                NDS1.Reset();
                                NDS2.Reset();
                            }
      //======================================================================Naration Retriveing======================
                            //if (chbNaration.Checked == true)
                            //{
                            //    Dr1 = DtCollection.NewRow();
                            //    Dr1[0] = "         ";
                            //    Dr1[1] = "         ";

                            //    SEDATE.Clear();
                            //    cmd = new SqlCommand("SELECT NAR1 FROM narr WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND NTYPE='N' ", conn.mycon);
                            //    adp.SelectCommand = cmd;
                            //    adp.Fill(SEDATE, "NAR");
                            //    if (SEDATE.Tables["NAR"].Rows.Count > 0)
                            //        Dr1[2] = Convert.ToString(SEDATE.Tables["NAR"].Rows[0][0]);
                            //    else
                            //        Dr1[2] = "    ";


                            //    Dr1[3] = "       ";
                            //    Dr1[4] = "       ";
                            //    Dr1[5] = "       ";
                               
                            //    DtCollection.Rows.Add(Dr1);

                            //}

                            if (chbNaration.Checked == true)
                            {

                                SEDATE.Clear();
                                cmd = new SqlCommand("SELECT NAR1 FROM narr WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND NTYPE='N' ", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(SEDATE, "NAR");
                                if (SEDATE.Tables["NAR"].Rows.Count > 0)
                                {
                                    string ss1 = Convert.ToString(SEDATE.Tables["NAR"].Rows[0][0]);
                                    StringRapping(ss1, 53);
                                    for (int p = 0; p <= SplitStr.Count - 1; p++)
                                    {
                                        Dr1 = DtCollection.NewRow();
                                        Dr1[0] = "         ";
                                        Dr1[1] = "         ";
                                        Dr1[2] = "     " + SplitStr[p];
                                        Dr1[3] = "       ";
                                        Dr1[4] = "       ";
                                        Dr1[5] = "       ";
                                        DtCollection.Rows.Add(Dr1);
                                    }

                                }

                            }
  //===========================================================================End Naration Retriveing======================
     
                        }
                       // b1 = true;
                        OLDBAL = BALANCE; 
                        BALANCE = BALANCE + (DBTAMT1 - CRDAMT1);
                        Dr1 = DtCollection.NewRow();
                        Dr1[0] = "       ";
                        Dr1[1] = "       ";
                        Dr1[2] = "       ";
                        Dr1[3] = "Balance c/0";
                        if (BALANCE >= 0)
                        {
                            Dr1[4] = "       ";
                            Dr1[5] = BALANCE.ToString(frmCashBook.SetDecimalPlace()); 
                        }
                        else
                        {
                            BAL=BALANCE * (-1);
                            Dr1[4] =BAL.ToString(frmCashBook.SetDecimalPlace());
                            Dr1[5] = "      "; 
                        }
                        
                        DtCollection.Rows.Add(Dr1);


                        Dr1 = DtCollection.NewRow();
                        Dr1[0] = "       ";
                        Dr1[1] = "       ";
                        Dr1[2] = "       ";
                        Dr1[3] = "       ";
                        Dr1[4] = "-----------------";
                        Dr1[5] = "-----------------";
                        
                        DtCollection.Rows.Add(Dr1);
//=====================================================Total Calculation====================
                        Dr1 = DtCollection.NewRow();
                        Dr1[0] = "       ";
                        Dr1[1] = "       ";
                        Dr1[2] = "       ";
                        Dr1[3] = "Total";
                        Double DD;
                        if (OLDBAL >= 0)
                        {
                            DD = OLDBAL + DBTAMT;
                            Dr1[4] = DD.ToString(frmCashBook.SetDecimalPlace());
                            Dr1[5] = DD.ToString(frmCashBook.SetDecimalPlace());
                        }
                        else
                        {
                            OLDBAL = OLDBAL * (-1);
                            if(BALANCE>=0)
                                DD = OLDBAL + CRDAMT + BALANCE;
                            else
                                DD = OLDBAL + CRDAMT + BAL;

                            Dr1[4] = DD.ToString(frmCashBook.SetDecimalPlace());
                            Dr1[5] = DD.ToString(frmCashBook.SetDecimalPlace());
                        }
                        
                        DtCollection.Rows.Add(Dr1);
//=====================================================Total Calculation====================
                        Dr1 = DtCollection.NewRow();
                        Dr1[0] = "       ";
                        Dr1[1] = "       ";
                        Dr1[2] = "       ";
                        Dr1[3] = "       ";
                        Dr1[4] = "=================";
                        Dr1[5] = "=================";
                       
                        DtCollection.Rows.Add(Dr1);


                        Dr1 = DtCollection.NewRow();
                        Dr1[0] = "       ";
                        Dr1[1] = "       ";
                        Dr1[2] = "       ";
                        Dr1[3] = "Balance b/f";
                        if (BALANCE >= 0)
                        {
                            Dr1[4] = BALANCE.ToString(frmCashBook.SetDecimalPlace());
                            Dr1[5] = "       ";
                        }
                        else
                        {
                            BAL = BALANCE * (-1);
                            Dr1[4] = "       ";
                            Dr1[5] = BAL.ToString(frmCashBook.SetDecimalPlace());
                        }
                        
                        DtCollection.Rows.Add(Dr1);

                    }

                }
              
                int Co;
                Co=DtCollection.Rows.Count;
                DtCollection.Rows.RemoveAt(Co-1);
            }
            catch { }
        }
//=================================================End Monthly Balance with voucher and naration=================

//======================================================Start Consolidated==========================================
        private void GetConsolidatedDaily()
        {
            try
            {
                Boolean b1 = true, b2 = true;
                CRDAMT = 0.00;
                DBTAMT = 0.00;
                CRDAMT1 = 0.00;
                DBTAMT1 = 0.00;
                test1.Clear();
                ds.Clear();

                cmd = new SqlCommand("SELECT T_ENTRY,VOUCHER,GLCODE,VCHDATE FROM VCHR WHERE (FICode = " + comm.CurrentFicode + " ) AND (GCode = " + comm.PCURRENT_GCODE + " ) AND (GLCODE=" + vchno + ") AND VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' ORDER BY VCHDATE", conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(ds, "Grid");


                if (ds.Tables["Grid"].Rows.Count > 0)
                {
                    DtCollection.Clear();
                    DtCollection.Columns.Clear();
                    DtCollection.Columns.Add(DTC1);
                    DtCollection.Columns.Add(DTC2);
                    DtCollection.Columns.Add(DTC3);
                    DtCollection.Columns.Add(DTC4);
                    DtCollection.Columns.Add(DTC5);
                    DtCollection.Columns.Add(DTC6);
                  
                    for (i = 0; i <= ds.Tables["Grid"].Rows.Count - 1; i++)
                    {
                        Str = "SELECT DISTINCT V.VCHDATE AS Date,V.USER_VCH AS Voucher_No,G.LDESC AS Description,V.CRAMT AS Credit,V.DBAMT AS Debit,";
                        Str = Str + "V.T_ENTRY AS T,V.VOUCHER AS V,V.GLCODE FROM VCHR V,GLMST G WHERE ";
                        Str = Str + "V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.GLCODE=" + ds.Tables["Grid"].Rows[i][2] + " AND V.T_ENTRY='" + Convert.ToString(ds.Tables["Grid"].Rows[i][0]) + "' AND V.VOUCHER=" + ds.Tables["Grid"].Rows[i][1] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ";

                        cmd = new SqlCommand(Str, conn.mycon);
                        adp.SelectCommand = cmd;
                        adp.Fill(test1, "FINLEDG1");

                          if (b1 == true) 
                        {
                            b1 = false;
                            CD = Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]);
                            BALANCE = CLOSEAMT;
                           
                        }

                        if (CD == Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]))
                        {

                            CRDAMT1 = CRDAMT1 + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][3]);
                            DBTAMT1 = DBTAMT1 + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][4]);

                            CRDAMT = CRDAMT + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][3]);
                            DBTAMT = DBTAMT + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][4]);

                            b2 = false;
                                   
                        }
                        else
                        {
                           if (b2 == false)
                            {
                            
                                Dr1 = DtCollection.NewRow();
                                Dr1[0] = Convert.ToString(CD.ToShortDateString());
                  
                                if (BALANCE >= 0)
                                {
                                    Dr1[1] = BALANCE.ToString(frmCashBook.SetDecimalPlace()) + " Db";
                                }
                                else
                                {
                                    BAL = BALANCE * (-1);
                                    Dr1[1] = BAL.ToString(frmCashBook.SetDecimalPlace()) + " Cr";
                                }
                                 Dr1[2] = "  ";
                  
                                if (DBTAMT1 != 0)
                                    Dr1[3] = DBTAMT1.ToString(frmCashBook.SetDecimalPlace());
                                else
                                    Dr1[3] = " ";
                                if (CRDAMT1 != 0)
                                    Dr1[4] = CRDAMT1.ToString(frmCashBook.SetDecimalPlace());
                                else
                                    Dr1[4] = " ";

                                BALANCE = BALANCE + (DBTAMT1 - CRDAMT1);
                                if (BALANCE >= 0)
                                {
                                    Dr1[5] = BALANCE.ToString(frmCashBook.SetDecimalPlace()) + " Db";
                                }
                                else
                                {
                                    BAL = BALANCE * (-1);
                                    Dr1[5] = BAL.ToString(frmCashBook.SetDecimalPlace()) + " Cr";
                                }
                                

                                DtCollection.Rows.Add(Dr1);
                                                           
                                b2 = true;

                            }
                           
                            CD = Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]);
                            test1.Tables["FINLEDG1"].Rows.RemoveAt(i);
                            i = i - 1;
                            CRDAMT1 = 0;
                            DBTAMT1 = 0;
                        
                        }

                    }
                    Dr1 = DtCollection.NewRow();
                    Dr1[0] = Convert.ToString(CD.ToShortDateString());
                  
                    if (BALANCE >= 0)
                    {
                        Dr1[1] = BALANCE.ToString(frmCashBook.SetDecimalPlace()) + " Db";
                    }
                    else
                    {
                        BAL = BALANCE * (-1);
                        Dr1[1] = BAL.ToString(frmCashBook.SetDecimalPlace()) + " Cr";
                    }
                    Dr1[2] = "  ";
                    if (DBTAMT1 != 0)
                        Dr1[3] = DBTAMT1.ToString(frmCashBook.SetDecimalPlace());
                    else
                        Dr1[3] = " ";
                    if (CRDAMT1 != 0)
                        Dr1[4] = CRDAMT1.ToString(frmCashBook.SetDecimalPlace());
                    else
                        Dr1[4] = " ";
                  
                    BALANCE = BALANCE + (DBTAMT1 - CRDAMT1);
                    if (BALANCE >= 0)
                    {
                        Dr1[5] = BALANCE.ToString(frmCashBook.SetDecimalPlace()) + " Db";
                    }
                    else
                    {
                        BAL = BALANCE * (-1);
                        Dr1[5] = BAL.ToString(frmCashBook.SetDecimalPlace()) + " Cr";
                    }
                    DtCollection.Rows.Add(Dr1);

                    Dr1 = DtCollection.NewRow();
                    Dr1[0] = "          ";
                    Dr1[1] = "          ";
                    Dr1[2] = "          ";
                    Dr1[3] = "====================";
                    Dr1[4] = "====================";
                    Dr1[5] = "          ";
                    DtCollection.Rows.Add(Dr1);

                    Dr1 = DtCollection.NewRow();
                    Dr1[0] = "          ";
                    Dr1[1] = "          ";
                    Dr1[2] = "Total";
                    Dr1[3] = DBTAMT.ToString(frmCashBook.SetDecimalPlace());
                    Dr1[4] = CRDAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                    Dr1[5] = "          ";
                    DtCollection.Rows.Add(Dr1);

                    Dr1 = DtCollection.NewRow();
                    Dr1[0] = "          ";
                    Dr1[1] = "          ";
                    Dr1[2] = "          ";
                    Dr1[3] = "====================";
                    Dr1[4] = "====================";
                    Dr1[5] = "          ";
                    DtCollection.Rows.Add(Dr1);
                }
            }
            catch { }
        }
        //======================================================End Consolidated==========================================


//===========================================================Consolidated Monthly==========================

        private void GetConsolidatedMonthly()
        {
            try
            {
                        string str = dtpFromDate.Value.ToShortDateString();
                        String yy = str.Substring(str.Length - 4, 4);
                        String mm = str.Substring(str.Length - 7, 2);
                        String mm1 = mm;
                        String dd = str.Substring(str.Length - 10, 2);
                        Boolean ch, ch1;
                        int nom;
                        int pp;
                        string str11 = dtpToDate.Value.ToShortDateString();
                        String mm11 = str11.Substring(str11.Length - 7, 2);
                        
                        if (Convert.ToInt32(mm1) < Convert.ToInt32(mm11))
                            nom = Convert.ToInt32(mm11);
                        else
                            nom = Convert.ToInt32(mm11) + 12;
                            

                        ch = true;
                        ch1 = true;

                        conn.Open();
                        DtCollection.Clear();
                        DtCollection.Columns.Clear();
                        DtCollection.Columns.Add(DTC1);
                        DtCollection.Columns.Add(DTC2);
                        DtCollection.Columns.Add(DTC3);
                        DtCollection.Columns.Add(DTC4);
                        DtCollection.Columns.Add(DTC5);
                        DtCollection.Columns.Add(DTC6);
                        //DtCollection.Columns.Add(DTC7);
                        cmd = new SqlCommand("SELECT T_ENTRY,VOUCHER,GLCODE,VCHDATE FROM VCHR WHERE (FICode = " + comm.CurrentFicode + " ) AND (GCode = " + comm.PCURRENT_GCODE + " ) AND (GLCODE=" + vchno + ") AND VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' ORDER BY VCHDATE", conn.mycon);
                        adp.SelectCommand = cmd;
                        adp.Fill(ds, "Grid");

                        BALANCE = CLOSEAMT;

                        for (pp = Convert.ToInt32(mm1); pp <= nom; pp++)
                        {
                            ds.Clear();
                            test1.Clear();
                            DBTAMT1 = 0;
                            CRDAMT1 = 0;

                            if (ch1 == true)
                            {
                                mm = Convert.ToString(Convert.ToInt32(mm) + 0);
                                ch1 = false;
                            }
                            else
                                mm = Convert.ToString(Convert.ToInt32(mm) + 1);

                            if (Convert.ToInt32(mm) == 13)
                                mm = "1";

                            if ((Convert.ToInt32(mm) == 1) & (mm1 != "01") & (ch == true))
                            {
                                yy = Convert.ToString(Convert.ToInt32(yy) + 1);
                                ch = false;
                            }

                            if ((Convert.ToInt32(mm) == 1) || (Convert.ToInt32(mm) == 3) || (Convert.ToInt32(mm) == 5) || (Convert.ToInt32(mm) == 7) || (Convert.ToInt32(mm) == 8) || (Convert.ToInt32(mm) == 10) || (Convert.ToInt32(mm) == 12))
                                em = "31";
                            else
                            {
                                if (Convert.ToInt32(mm) == 2)
                                {
                                    if (((Convert.ToInt32(yy) % 4) == 0) || ((Convert.ToInt32(yy) % 100) == 0))
                                        em = "29";
                                    else
                                        em = "28";
                                }
                                else
                                    em = "30";
                            }

                            if ((Convert.ToInt32(mm) > 0) & (Convert.ToInt32(mm) <= 9))
                                mm = "0" + mm + "";

                            stds = "01/" + mm + "/" + Convert.ToInt32(yy) + "";
                            stde = "" + em + "/" + mm + "/" + Convert.ToInt32(yy) + "";

                            DateTime stds1 = Convert.ToDateTime(stds);
                            DateTime stde1 = Convert.ToDateTime(stde);
                            cmd = new SqlCommand("SELECT T_ENTRY,VOUCHER,GLCODE,VCHDATE FROM VCHR WHERE (FICode = " + comm.CurrentFicode + " ) AND (GCode = " + comm.PCURRENT_GCODE + " ) AND (GLCODE=" + vchno + ") AND VCHDATE BETWEEN '" + edpcom.getSqlDateStr(stds1) + "' AND '" + edpcom.getSqlDateStr(stde1) + "' ORDER BY VCHDATE", conn.mycon);
                            adp.SelectCommand = cmd;
                            adp.Fill(ds, "Grid");



                if (ds.Tables["Grid"].Rows.Count > 0)
                {
                    
                    for (i = 0; i <= ds.Tables["Grid"].Rows.Count - 1; i++)
                    {
                        Str = "SELECT DISTINCT V.VCHDATE AS Date,V.USER_VCH AS Voucher_No,G.LDESC AS Description,V.CRAMT AS Credit,V.DBAMT AS Debit,";
                        Str = Str + "V.T_ENTRY AS T,V.VOUCHER AS V,V.GLCODE FROM VCHR V,GLMST G WHERE ";
                        Str = Str + "V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.GLCODE=" + ds.Tables["Grid"].Rows[i][2] + " AND V.T_ENTRY='" + Convert.ToString(ds.Tables["Grid"].Rows[i][0]) + "' AND V.VOUCHER=" + ds.Tables["Grid"].Rows[i][1] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(stds1) + "' AND '" + edpcom.getSqlDateStr(stde1) + "' AND G.MTYPE='L' ";

                        cmd = new SqlCommand(Str, conn.mycon);
                        adp.SelectCommand = cmd;
                        adp.Fill(test1, "FINLEDG1");

                        CRDAMT1 = CRDAMT1 + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][3]);
                        DBTAMT1 = DBTAMT1 + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][4]);

                        CRDAMT = CRDAMT + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][3]);
                        DBTAMT = DBTAMT + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][4]);

                    }
                    Dr1 = DtCollection.NewRow();
                    if (mm == "01")
                        Dr1[0] = "January   " + yy + "";
                    else
                    {
                        if (mm == "02")
                            Dr1[0] = "February  " + yy + "";
                        else
                        {
                            if (mm == "03")
                                Dr1[0] = "March     " + yy + "";
                            else
                            {
                                if (mm == "04")
                                    Dr1[0] = "April     " + yy + "";
                                else
                                {
                                    if (mm == "05")
                                        Dr1[0] = "May       " + yy + "";
                                    else
                                    {
                                        if (mm == "06")
                                            Dr1[0] = "June       " + yy + "";
                                        else
                                        {
                                            if (mm == "07")
                                                Dr1[0] = "Jully     " + yy + "";
                                            else
                                            {
                                                if (mm == "08")
                                                    Dr1[0] = "August    " + yy + "";
                                                else
                                                {
                                                    if (mm == "09")
                                                        Dr1[0] = "September " + yy + "";
                                                    else
                                                    {
                                                        if (mm == "10")
                                                            Dr1[0] = "October   " + yy + "";
                                                        else
                                                        {
                                                            if (mm == "11")
                                                                Dr1[0] = "November  " + yy + "";
                                                            else
                                                                Dr1[0] = "December  " + yy + "";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //Dr1[1] = "  ";
                    if (BALANCE >= 0)
                        Dr1[1] = BALANCE.ToString(frmCashBook.SetDecimalPlace()) + " Db";
                    else
                    {
                        BAL = BALANCE * (-1);
                        Dr1[1] = BAL.ToString(frmCashBook.SetDecimalPlace()) + " Cr";
                    }
                    Dr1[2] = "    ";
                    if (DBTAMT1 != 0)
                        Dr1[3] = DBTAMT1.ToString(frmCashBook.SetDecimalPlace());
                    else
                        Dr1[3] = " ";
                    if (CRDAMT1 != 0)
                        Dr1[4] = CRDAMT1.ToString(frmCashBook.SetDecimalPlace());
                    else
                        Dr1[4] = " ";
                    BALANCE = BALANCE + (DBTAMT1 - CRDAMT1);
                    //Dr1[5] = BALANCE.ToString(frmCashBook.SetDecimalPlace()); 
                    if (BALANCE >= 0)
                        Dr1[5] = BALANCE.ToString(frmCashBook.SetDecimalPlace()) + " Db";
                    else
                    {
                        BAL = BALANCE * (-1);
                        Dr1[5] = BAL.ToString(frmCashBook.SetDecimalPlace()) + " Cr";
                    }
                    DtCollection.Rows.Add(Dr1);

                }

              }
                Dr1 = DtCollection.NewRow();
                Dr1[0] = "       ";
                Dr1[1] = "       ";
                Dr1[2] = "       ";
                Dr1[3] = "======================";
                Dr1[4] = "======================";
                Dr1[5] = "        ";
                DtCollection.Rows.Add(Dr1);

                Dr1 = DtCollection.NewRow();
                Dr1[0] = "       ";
                Dr1[1] = "       ";
                Dr1[2] = "Total";
                Dr1[3] = DBTAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                Dr1[4] = CRDAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                Dr1[5] = "        ";
                DtCollection.Rows.Add(Dr1);

                Dr1 = DtCollection.NewRow();
                Dr1[0] = "       ";
                Dr1[1] = "       ";
                Dr1[2] = "       ";
                Dr1[3] = "======================";
                Dr1[4] = "======================";
                Dr1[5] = "        ";
                DtCollection.Rows.Add(Dr1);
            }
            catch { }
        }

//===========================================================End Consolidated Monthly==========================
        

        private void ShowDetails()
        {
            try
            {
                Boolean b1=true,b2=true,b3=true;
                CRDAMT = 0.00;
                DBTAMT = 0.00;
                test1.Clear();
                ds.Clear();

                cmd = new SqlCommand("SELECT T_ENTRY,VOUCHER,GLCODE,VCHDATE FROM VCHR WHERE (FICode = " + comm.CurrentFicode + " ) AND (GCode = " + comm.PCURRENT_GCODE + " ) AND (GLCODE=" + vchno + ") AND VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' ORDER BY VCHDATE", conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(ds, "Grid");


                if (ds.Tables["Grid"].Rows.Count > 0)
                {
                    DtCollection.Clear();
                    DtCollection.Columns.Clear();
                    DtCollection.Columns.Add(DTC1);
                    DtCollection.Columns.Add(DTC2);
                    DtCollection.Columns.Add(DTC3);
                    DtCollection.Columns.Add(DTC4);
                    DtCollection.Columns.Add(DTC5);
                    DtCollection.Columns.Add(DTC6);
                    
                    for (i = 0; i <= ds.Tables["Grid"].Rows.Count -1; i++)
                    {
                            Str = "SELECT DISTINCT V.VCHDATE AS Date,V.USER_VCH AS Voucher_No,G.LDESC AS Description,V.CRAMT AS Credit,V.DBAMT AS Debit,";
                            Str = Str + "V.T_ENTRY AS T,V.VOUCHER AS V,V.GLCODE FROM VCHR V,GLMST G WHERE ";
                            Str = Str + "V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.GLCODE=" + ds.Tables["Grid"].Rows[i][2] + " AND V.T_ENTRY='" + Convert.ToString(ds.Tables["Grid"].Rows[i][0]) + "' AND V.VOUCHER=" + ds.Tables["Grid"].Rows[i][1] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ";

                            cmd = new SqlCommand(Str, conn.mycon);
                            adp.SelectCommand = cmd;
                            adp.Fill(test1, "FINLEDG1");
            
                        if ((b1 == true) && (b1==true))
                        {
                            b1 = false;
                           
                               OPB = CLOSEAMT;

                            CD = Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]);
                            Dr1 = DtCollection.NewRow();
                            Dr1[0] = Convert.ToString(dtpFromDate.Value.ToShortDateString());
                            Dr1[1] = "         ";
                            Dr1[2] = "         ";
                            Dr1[3] = "Opening Balance";
                            if (OPB >= 0)
                            {
                                Dr1[4] = OPB.ToString(frmCashBook.SetDecimalPlace()); ;
                                Dr1[5] = "       ";
                            }
                            else
                            {
                                OPB = OPB * (-1);
                                Dr1[4] = "        ";
                                Dr1[5] = OPB.ToString(frmCashBook.SetDecimalPlace()); ;
                            }
                            DtCollection.Rows.Add(Dr1);

                            CCLOSEAMT = CLOSEAMT;
                            if (CLOSEAMT < 0)
                                CLOSEAMT = CLOSEAMT * (-1);
                        }

                        if (CD == Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]))
                        {
                            if ((b1 == false) && (b3==false))
                            {
                                
                                Dr1 = DtCollection.NewRow();
                                Dr1[0] = "         ";
                                Dr1[1] = "         ";
                                Dr1[2] = "         ";
                                Dr1[3] = "Balance b/f";
                                if (CCLOSEAMT >= 0)
                                {
                                    Dr1[4] = CLOSEAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                                    Dr1[5] = "       ";
                                }
                                else
                                {                                   
                                    Dr1[4] = "        ";
                                    Dr1[5] = CLOSEAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                                }
                               DtCollection.Rows.Add(Dr1);
                            }
                               
                            CRDAMT = CRDAMT + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][3]);
                            DBTAMT = DBTAMT + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][4]);
                            
                            Dr1 = DtCollection.NewRow();
                            if (b2 == true)
                            {
                                DateTime DTP;
                                DTP =Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]);
                                Dr1[0] = Convert.ToString(DTP.ToShortDateString());
                            }
                            else
                                Dr1[0] = "        ";
                            if(chbVoucher.Checked==true)
                                Dr1[1] = Convert.ToString(test1.Tables["FINLEDG1"].Rows[i][1]);
                            else
                                Dr1[1] = "    ";
                            //===================================================For Retriving The Ledger Name of Respect To Choosing Account Ledger=========== 
                            NDS1.Clear();
                            NDS2.Clear();

                            cmd = new SqlCommand("SELECT TOBY FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND GLCODE = " + test1.Tables["FINLEDG1"].Rows[i][7] + "", conn.mycon);
                            adp.SelectCommand = cmd;
                            adp.Fill(NDS1, "LEDG2");
                            if (NDS1.Tables["LEDG2"].Rows.Count >= 1)
                            {
                                cmd = new SqlCommand("SELECT TOBY FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND TOBY='" + NDS1.Tables["LEDG2"].Rows[0][0] + "'", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS1, "LEDG3");
                            }

                            if (NDS1.Tables["LEDG3"].Rows.Count >= 2)
                            {
                                cmd = new SqlCommand("SELECT DISTINCT GLCODE,T_ENTRY,VOUCHER FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND GLCODE <> " + test1.Tables["FINLEDG1"].Rows[i][7] + "", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS1, "LEDG1");
                                
                                    T1 = Convert.ToString(test1.Tables["FINLEDG1"].Rows[i][5]);
                                    TE(T1);

                                    Dr1[2] = MakeBold(T2 + "  ( As per Details )");

                                    CHKNAR = true;
                                    
                                    cmd = new SqlCommand("SELECT DISTINCT G.LDESC,V.CRAMT,V.DBAMT FROM VCHR V,GLMST G WHERE V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.T_ENTRY='" + Convert.ToString(NDS1.Tables["LEDG1"].Rows[0][1]) + "' AND V.VOUCHER=" + NDS1.Tables["LEDG1"].Rows[0][2] + " AND V.TOBY='By' AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ", conn.mycon);
                                    adp.SelectCommand = cmd;
                                    adp.Fill(NDS2, "LEDG1");
                                    if (NDS2.Tables["LEDG1"].Rows.Count >= 1)
                                    {
                                        for (int p = 0; p <= NDS2.Tables["LEDG1"].Rows.Count - 1; p++)
                                        {
                                            strledg = "";
                                            int slen;
                                            string space=" ";
                                            string space1 = "";
                                            double strlp = Convert.ToDouble(NDS2.Tables["LEDG1"].Rows[p][2]);
                                            strledg = Convert.ToString(NDS2.Tables["LEDG1"].Rows[p][0]).Trim();
                                            slen = strledg.Length;
                                            strledg = "";
                                            strledg = strlp.ToString(frmCashBook.SetDecimalPlace()).Trim();
                                            slen = slen + strledg.Length;
                                            for (int p1 = 0; p1 < (32 - slen); p1++)
                                            {
                                                space1 = space1 + space;
                                            }
                                            strledg = "";
                                            strledg = Convert.ToString(NDS2.Tables["LEDG1"].Rows[p][0]).Trim() + space1 + strlp.ToString(frmCashBook.SetDecimalPlace()).Trim() + " Db";
                                            Ledg.Add(strledg.Trim());
                                        }
                                    }
                                    cmd = new SqlCommand("SELECT DISTINCT G.LDESC,V.CRAMT,V.DBAMT FROM VCHR V,GLMST G WHERE V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.T_ENTRY='" + Convert.ToString(NDS1.Tables["LEDG1"].Rows[0][1]) + "' AND V.VOUCHER=" + NDS1.Tables["LEDG1"].Rows[0][2] + " AND V.TOBY='To' AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ", conn.mycon);
                                    adp.SelectCommand = cmd;
                                    adp.Fill(NDS2, "LEDG2");
                                    if (NDS2.Tables["LEDG2"].Rows.Count >= 1)
                                    {
                                        for (int p = 0; p <= NDS2.Tables["LEDG2"].Rows.Count - 1; p++)
                                        {
                                            strledg = "";
                                            int slen;
                                            string space = " ";
                                            string space1 = "";
                                            double strlp = Convert.ToDouble(NDS2.Tables["LEDG2"].Rows[p][1]);
                                            strledg = Convert.ToString(NDS2.Tables["LEDG2"].Rows[p][0]).Trim();
                                            slen = strledg.Length;
                                            strledg = "";
                                            strledg = strlp.ToString(frmCashBook.SetDecimalPlace()).Trim();
                                            slen = slen + strledg.Length;
                                            for (int p1 = 0; p1 < (45 - slen); p1++)
                                            {
                                                space1 = space1 + space;
                                            }
                                            strledg = "";
                                            strledg = Convert.ToString(NDS2.Tables["LEDG2"].Rows[p][0]).Trim() + space1 + strlp.ToString(frmCashBook.SetDecimalPlace()).Trim() + " Cr";
                                            strledg = strledg.Trim();
                                            strledg = "  " + strledg;
                                            Ledg.Add(strledg);
                                        }
                                    }
                                    NDS1.Clear();
                                    NDS2.Clear();
                                    
                            }


                            if (NDS1.Tables["LEDG3"].Rows.Count == 1)
                            {
                               
                                cmd = new SqlCommand("SELECT DISTINCT GLCODE,T_ENTRY,VOUCHER FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND GLCODE <> " + test1.Tables["FINLEDG1"].Rows[i][7] + "", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS1, "LEDG1");
                                
                                    cmd = new SqlCommand("SELECT DISTINCT G.LDESC FROM VCHR V,GLMST G WHERE V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.GLCODE=" + NDS1.Tables["LEDG1"].Rows[0][0] + " AND V.T_ENTRY='" + Convert.ToString(NDS1.Tables["LEDG1"].Rows[0][1]) + "' AND V.VOUCHER=" + NDS1.Tables["LEDG1"].Rows[0][2] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ", conn.mycon);
                                    adp.SelectCommand = cmd;
                                    adp.Fill(NDS2, "LEDG2");
                                    Dr1[2] = MakeBold(Convert.ToString(NDS2.Tables["LEDG2"].Rows[0][0]));
                                    NDS2.Clear();
                            }

                            //=====================================================================================
                            Dr1[3] = "         ";
                            Double ZZ;
                            ZZ = Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][4]);
                            if (ZZ != 0)
                                Dr1[4] = ZZ.ToString(frmCashBook.SetDecimalPlace());
                            else
                                Dr1[4] = "  ";
                            ZZ = Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][3]);
                            if (ZZ != 0)
                                Dr1[5] = ZZ.ToString(frmCashBook.SetDecimalPlace());
                            else
                                Dr1[5] = "  ";
                            
                            DtCollection.Rows.Add(Dr1);

                            if (CHKNAR == true)
                            {
                                CHKNAR = false;
                                //for (int p = 0; p <= SplitStr.Count - 1; p++)
                                for (int p = 0; p <= Ledg.Count - 1; p++)
                                {
                                    Dr1 = DtCollection.NewRow();
                                    Dr1[0] = "         ";
                                    Dr1[1] = "         ";
                                   // Dr1[2] = "     " + SplitStr[p];
                                    Dr1[2] = "   " + Ledg[p];
                                    Dr1[3] = "       ";
                                    Dr1[4] = "       ";
                                    Dr1[5] = "       ";
                                    DtCollection.Rows.Add(Dr1);
                                }
                                Ledg.Clear();
                                NDS1.Reset();
                                NDS2.Reset();
                            }
                            //======================================================================Naration Retriveing======================
                            if (chbNaration.Checked == true)
                            {
                               
                                SEDATE.Clear();
                                cmd = new SqlCommand("SELECT NAR1 FROM narr WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND NTYPE='N' ", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(SEDATE, "NAR");
                                if (SEDATE.Tables["NAR"].Rows.Count > 0)
                                {
                                    string ss1=Convert.ToString(SEDATE.Tables["NAR"].Rows[0][0]);
                                    StringRapping(ss1, 48);
                                    for (int p = 0; p <= SplitStr.Count - 1; p++)
                                    {
                                        Dr1 = DtCollection.NewRow();
                                        Dr1[0] = "         ";
                                        Dr1[1] = "         ";
                                        Dr1[2] = "     " + SplitStr[p];
                                        Dr1[3] = "       ";
                                        Dr1[4] = "       ";
                                        Dr1[5] = "       ";
                                        DtCollection.Rows.Add(Dr1);
                                    }
                               
                                }
                              
                            }
                            //====================================================================================
                            b2 = false;
                            b3 = true;
                        }
                        else
                        {
                            b3 = false;
                            if (b2 == false)
                            {
                                if (CCLOSEAMT >= 0)
                                    DBTAMT = DBTAMT + CLOSEAMT;
                                else
                                    CRDAMT = CRDAMT + CLOSEAMT;

                                Dr1 = DtCollection.NewRow();
                                Dr1[0] = "        ";
                                Dr1[1] = "        ";
                                Dr1[2] = "        ";
                                Dr1[3] = "Balance c/o";
                                if (DBTAMT >= CRDAMT)
                                {
                                    CLOSEAMT = DBTAMT - CRDAMT;
                                    Dr1[4] = "        ";
                                    Dr1[5] = CLOSEAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                                }
                                else
                                {
                                    CLOSEAMT = DBTAMT - CRDAMT;
                                    CCLOSEAMT = CLOSEAMT;
                                    CLOSEAMT = CLOSEAMT * (-1);
                                    Dr1[4] = CLOSEAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                                    Dr1[5] = "        ";
                                }
                                
                                DtCollection.Rows.Add(Dr1);
                                b2 = true;
                                
                            }
                            Dr1 = DtCollection.NewRow();
                            Dr1[0] = "         ";
                            Dr1[1] = "         ";
                            Dr1[2] = "         ";
                            Dr1[3] = "         ";
                            Dr1[4] = "--------------------------------";
                            Dr1[5] = "--------------------------------";
                            DtCollection.Rows.Add(Dr1);

                            Dr1 = DtCollection.NewRow();
                            Dr1[0] = "         ";
                            Dr1[1] = "         ";
                            Dr1[2] = "         ";
                            Dr1[3] = "         ";
                            if (CCLOSEAMT >= 0)
                            {
                                TOTALAMT = DBTAMT;
                            }
                            else
                            {
                                TOTALAMT = CRDAMT;
                            }

                            Dr1[4] = TOTALAMT.ToString(frmCashBook.SetDecimalPlace()); 
                            Dr1[5] = TOTALAMT.ToString(frmCashBook.SetDecimalPlace());
                            DtCollection.Rows.Add(Dr1);
                            
                            Dr1 = DtCollection.NewRow();
                            Dr1[0] = "         ";
                            Dr1[1] = "         ";
                            Dr1[2] = "         ";
                            Dr1[3] = "         ";
                            Dr1[4] = "====================";
                            Dr1[5] = "====================";
                            DtCollection.Rows.Add(Dr1);

                            CD =Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]);
                            test1.Tables["FINLEDG1"].Rows.RemoveAt(i);
                            i = i - 1;
                            DBTAMT = 0;
                            CRDAMT = 0;
                            
                        }

                   }

                }
                b3 = false;
                if (b2 == false)
                {
                    if (CCLOSEAMT >= 0)
                        DBTAMT = DBTAMT + CLOSEAMT;
                    else
                        CRDAMT = CRDAMT + CLOSEAMT;

                    Dr1 = DtCollection.NewRow();
                    Dr1[0] = "        ";
                    Dr1[1] = "        ";
                    Dr1[2] = "        ";
                    Dr1[3] = "Balance c/o"; 
                    if (DBTAMT >= CRDAMT)
                    {
                        CLOSEAMT = DBTAMT - CRDAMT;
                        Dr1[4] = "        ";
                        Dr1[5] = CLOSEAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                    }
                    else
                    {
                        CLOSEAMT = DBTAMT - CRDAMT;
                        CCLOSEAMT = CLOSEAMT;
                        CLOSEAMT = CLOSEAMT * (-1);
                        Dr1[4] = CLOSEAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                        Dr1[5] = "        ";
                    }

                    DtCollection.Rows.Add(Dr1);
                    b2 = true;
                }

                Dr1 = DtCollection.NewRow();
                Dr1[0] = "         ";
                Dr1[1] = "         ";
                Dr1[2] = "         ";
                Dr1[3] = "         ";
                Dr1[4] = "--------------------------------";
                Dr1[5] = "--------------------------------";
                DtCollection.Rows.Add(Dr1);

                Dr1 = DtCollection.NewRow();
                Dr1[0] = "         ";
                Dr1[1] = "         ";
                Dr1[2] = "         ";
                Dr1[3] = "         ";
                if (CCLOSEAMT >= 0)
                {
                    TOTALAMT = DBTAMT;
                }
                else
                {
                    TOTALAMT = CRDAMT;
                }


                Dr1[4] = TOTALAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                Dr1[5] = TOTALAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                DtCollection.Rows.Add(Dr1);

                Dr1 = DtCollection.NewRow();
                Dr1[0] = "         ";
                Dr1[1] = "         ";
                Dr1[2] = "         ";
                Dr1[2] = "         ";
                Dr1[4] = "====================";
                Dr1[5] = "====================";
                DtCollection.Rows.Add(Dr1);
            }
            catch { }
        }

        private string MakeBold(string S)
        {
            string S1 = Strings.ChrW(27).ToString() + Strings.ChrW(69).ToString() + S;// +Strings.ChrW(27).ToString() + Strings.ChrW(70).ToString();
           // string S1 = Strings.ChrW(69).ToString() + S;
            return S1;
        }

        string  s1,s3;
        private void StringRapping(string SS,int SLen)
        {
            string SS2 =  SS.Trim();
            string SS1 =  SS.Trim();
            int a,b=2, total;//, chstr=1;
            int StrLen = SS1.Length;
            SplitStr.Clear();

          //  for (int j = 0; j < StrLen-b; j++)
            for (int j = 0; j < SS2.Length-2; j++)
            {
                //if (SS2.Length > j+2) 
                //{
                    s3 = SS2.Substring(j, 2);
                    if (s3 == "\r\n")
                    {
                        SplitStr.Add(SS2.Substring(0, j));
                        total = SS2.Length - (j + 2);
                        SS2 = SS2.Substring(j + 2, total);
                        j = 0;
                       // b = b + 2;
                    }
                //}
            }
            SplitStr.Add(SS2);
            SS1 = "";
            for (int j = 0; j < SplitStr.Count; j++)
            {
                SS1 = SS1 + " " + SplitStr[j];
            }
           // SS1 = "     " + SS1;
            SplitStr.Clear();
            if (StrLen > SLen)
            {
                for (a = 0; StrLen > SLen; a++)
                {
                    s1 = SS1.Substring(SLen, 1);
                    if ((s1 == " ") || (s1 == ",") || (s1 == ".") || (s1 == ";"))
                    {
                        s1 = SS1.Substring(1, SLen);
                        SplitStr.Add(s1);
                        StrLen = (StrLen - SLen);
                        SS1 = SS1.Substring(SLen , StrLen-2);

                    }
                    else
                    {
                        s1 = SS1.Substring(1, SLen-1) + "-";
                        SplitStr.Add(s1);
                        StrLen = (StrLen - SLen);
                        SS1 = SS1.Substring(SLen, StrLen-3);
                    }
                }
                SplitStr.Add(SS1);
            }
            else
            {
                SplitStr.Add(SS1);
            }

        }

        private void ShowSideBalance()
        {
            try
            {
                Boolean b1 = true, b2 = true;
                CRDAMT = 0.00;
                DBTAMT = 0.00;
                CRDAMT1 = 0.00;
                DBTAMT1 = 0.00;
                test1.Clear();
                ds.Clear();

                cmd = new SqlCommand("SELECT T_ENTRY,VOUCHER,GLCODE,VCHDATE FROM VCHR WHERE (FICode = " + comm.CurrentFicode + " ) AND (GCode = " + comm.PCURRENT_GCODE + " ) AND (GLCODE=" + vchno + ") AND VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' ORDER BY VCHDATE", conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(ds, "Grid");


                if (ds.Tables["Grid"].Rows.Count > 0)
                {
                    DtCollection.Clear();
                    DtCollection.Columns.Clear();
                    DtCollection.Columns.Add(DTC1);
                    DtCollection.Columns.Add(DTC2);
                    DtCollection.Columns.Add(DTC3);
                    DtCollection.Columns.Add(DTC4);
                    DtCollection.Columns.Add(DTC5);
                    DtCollection.Columns.Add(DTC6);
                    DtCollection.Columns.Add(DTC7);
                    for (i = 0; i <= ds.Tables["Grid"].Rows.Count - 1; i++)
                    {
                        Str = "SELECT DISTINCT V.VCHDATE AS Date,V.USER_VCH AS Voucher_No,G.LDESC AS Description,V.CRAMT AS Credit,V.DBAMT AS Debit,";
                        Str = Str + "V.T_ENTRY AS T,V.VOUCHER AS V,V.GLCODE FROM VCHR V,GLMST G WHERE ";
                        Str = Str + "V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.GLCODE=" + ds.Tables["Grid"].Rows[i][2] + " AND V.T_ENTRY='" + Convert.ToString(ds.Tables["Grid"].Rows[i][0]) + "' AND V.VOUCHER=" + ds.Tables["Grid"].Rows[i][1] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ";

                        cmd = new SqlCommand(Str, conn.mycon);
                        adp.SelectCommand = cmd;
                        adp.Fill(test1, "FINLEDG1");

                        if (b1 == true) 
                        {
                            b1 = false;

                            OPB = CLOSEAMT;

                            CD = Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]);
                            Dr1 = DtCollection.NewRow();
                            Dr1[0] = Convert.ToString(dtpFromDate.Value.ToShortDateString());
                            Dr1[1] = "         ";
                            Dr1[2] = "         ";
                            Dr1[3] = "         ";
                            Dr1[4] = "         ";
                            Dr1[5] = "         ";
                            if (OPB >= 0)
                            {
                                Dr1[6] = OPB.ToString(frmCashBook.SetDecimalPlace()) + " Db";
                               // Dr1[5] = "       ";
                            }
                            else
                            {
                                OPB = OPB * (-1);
                               // Dr1[4] = "        ";
                                Dr1[6] = OPB.ToString(frmCashBook.SetDecimalPlace()) + " Cr"; 
                            }
                            DtCollection.Rows.Add(Dr1);

                            BALANCE = CLOSEAMT;
                            if (CLOSEAMT < 0)
                                CLOSEAMT = CLOSEAMT * (-1);
                        }

                        if (CD == Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]))
                        {

                            CRDAMT1 = Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][3]);
                            DBTAMT1 = Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][4]);

                            CRDAMT = CRDAMT + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][3]);
                            DBTAMT = DBTAMT + Convert.ToDouble(test1.Tables["FINLEDG1"].Rows[i][4]);

                            if (DBTAMT1 != 0)
                                BALANCE = BALANCE + DBTAMT1;
                            if (CRDAMT1 != 0)
                                BALANCE = BALANCE - CRDAMT1;

                            Dr1 = DtCollection.NewRow();
                            if (b2 == true)
                            {
                                DateTime DTP;
                                DTP = Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]);
                                Dr1[0] = Convert.ToString(DTP.ToShortDateString());
                            }
                            else
                                Dr1[0] = "        ";
                            if (chbVoucher.Checked == true)
                                Dr1[1] = Convert.ToString(test1.Tables["FINLEDG1"].Rows[i][1]);
                            else
                                Dr1[1] = "    ";
                            //===================================================For Retriving The Ledger Name of Respect To Choosing Account Ledger=========== 
                            //NDS1.Clear();
                            //cmd = new SqlCommand("SELECT DISTINCT GLCODE,T_ENTRY,VOUCHER FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND GLCODE <> " + test1.Tables["FINLEDG1"].Rows[i][7] + "", conn.mycon);
                            //adp.SelectCommand = cmd;
                            //adp.Fill(NDS1, "LEDG1");
                            //if (NDS1.Tables["LEDG1"].Rows.Count >= 2)
                            //{
                            //    T1 = Convert.ToString(test1.Tables["FINLEDG1"].Rows[i][5]);
                            //    TE(T1);
                            //    Dr1[2] = T2;
                            //}
                            //else if (NDS1.Tables["LEDG1"].Rows.Count == 1)
                            //{
                            //    cmd = new SqlCommand("SELECT DISTINCT G.LDESC FROM VCHR V,GLMST G WHERE V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.GLCODE=" + NDS1.Tables["LEDG1"].Rows[0][0] + " AND V.T_ENTRY='" + Convert.ToString(NDS1.Tables["LEDG1"].Rows[0][1]) + "' AND V.VOUCHER=" + NDS1.Tables["LEDG1"].Rows[0][2] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ", conn.mycon);
                            //    adp.SelectCommand = cmd;
                            //    adp.Fill(NDS1, "LEDG2");
                            //    Dr1[2] = Convert.ToString(NDS1.Tables["LEDG2"].Rows[0][0]);
                            //}


                            NDS1.Clear();
                            NDS2.Clear();

                            cmd = new SqlCommand("SELECT TOBY FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND GLCODE = " + test1.Tables["FINLEDG1"].Rows[i][7] + "", conn.mycon);
                            adp.SelectCommand = cmd;
                            adp.Fill(NDS1, "LEDG2");
                            if (NDS1.Tables["LEDG2"].Rows.Count >= 1)
                            {
                                cmd = new SqlCommand("SELECT TOBY FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND TOBY='" + NDS1.Tables["LEDG2"].Rows[0][0] + "'", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS1, "LEDG3");
                            }

                            if (NDS1.Tables["LEDG3"].Rows.Count >= 2)
                            {
                                cmd = new SqlCommand("SELECT DISTINCT GLCODE,T_ENTRY,VOUCHER FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND GLCODE <> " + test1.Tables["FINLEDG1"].Rows[i][7] + "", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS1, "LEDG1");

                                T1 = Convert.ToString(test1.Tables["FINLEDG1"].Rows[i][5]);
                                TE(T1);

                                Dr1[2] = MakeBold(T2 + "  ( As per Details )");

                                CHKNAR = true;

                                cmd = new SqlCommand("SELECT DISTINCT G.LDESC,V.CRAMT,V.DBAMT FROM VCHR V,GLMST G WHERE V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.T_ENTRY='" + Convert.ToString(NDS1.Tables["LEDG1"].Rows[0][1]) + "' AND V.VOUCHER=" + NDS1.Tables["LEDG1"].Rows[0][2] + " AND V.TOBY='By' AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS2, "LEDG1");
                                if (NDS2.Tables["LEDG1"].Rows.Count >= 1)
                                {
                                    for (int p = 0; p <= NDS2.Tables["LEDG1"].Rows.Count - 1; p++)
                                    {
                                        strledg = "";
                                        int slen;
                                        string space = " ";
                                        string space1 = "";
                                        double strlp = Convert.ToDouble(NDS2.Tables["LEDG1"].Rows[p][2]);
                                        strledg = Convert.ToString(NDS2.Tables["LEDG1"].Rows[p][0]).Trim();
                                        slen = strledg.Length;
                                        strledg = "";
                                        strledg = strlp.ToString(frmCashBook.SetDecimalPlace()).Trim();
                                        slen = slen + strledg.Length;
                                        for (int p1 = 0; p1 < (35 - slen); p1++)
                                        {
                                            space1 = space1 + space;
                                        }
                                        strledg = "";
                                        strledg = Convert.ToString(NDS2.Tables["LEDG1"].Rows[p][0]).Trim() + space1 + strlp.ToString(frmCashBook.SetDecimalPlace()).Trim() + " Db";
                                        Ledg.Add(strledg.Trim());
                                    }
                                }
                                cmd = new SqlCommand("SELECT DISTINCT G.LDESC,V.CRAMT,V.DBAMT FROM VCHR V,GLMST G WHERE V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.T_ENTRY='" + Convert.ToString(NDS1.Tables["LEDG1"].Rows[0][1]) + "' AND V.VOUCHER=" + NDS1.Tables["LEDG1"].Rows[0][2] + " AND V.TOBY='To' AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS2, "LEDG2");
                                if (NDS2.Tables["LEDG2"].Rows.Count >= 1)
                                {
                                    for (int p = 0; p <= NDS2.Tables["LEDG2"].Rows.Count - 1; p++)
                                    {
                                        strledg = "";
                                        int slen;
                                        string space = " ";
                                        string space1 = "";
                                        double strlp = Convert.ToDouble(NDS2.Tables["LEDG2"].Rows[p][1]);
                                        strledg = Convert.ToString(NDS2.Tables["LEDG2"].Rows[p][0]).Trim();
                                        slen = strledg.Length;
                                        strledg = "";
                                        strledg = strlp.ToString(frmCashBook.SetDecimalPlace()).Trim();
                                        slen = slen + strledg.Length;
                                        for (int p1 = 0; p1 < (50 - slen); p1++)
                                        {
                                            space1 = space1 + space;
                                        }
                                        strledg = "";
                                        strledg = Convert.ToString(NDS2.Tables["LEDG2"].Rows[p][0]).Trim() + space1 + strlp.ToString(frmCashBook.SetDecimalPlace()).Trim() + " Cr";
                                        Ledg.Add(strledg.Trim());
                                    }
                                }
                                NDS1.Clear();
                                NDS2.Clear();

                            }


                            if (NDS1.Tables["LEDG3"].Rows.Count == 1)
                            {

                                cmd = new SqlCommand("SELECT DISTINCT GLCODE,T_ENTRY,VOUCHER FROM VCHR WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND GLCODE <> " + test1.Tables["FINLEDG1"].Rows[i][7] + "", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS1, "LEDG1");

                                cmd = new SqlCommand("SELECT DISTINCT G.LDESC FROM VCHR V,GLMST G WHERE V.FICode = " + comm.CurrentFicode + " AND V.GCode = " + comm.PCURRENT_GCODE + " AND G.GLCODE = V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND V.GLCODE=" + NDS1.Tables["LEDG1"].Rows[0][0] + " AND V.T_ENTRY='" + Convert.ToString(NDS1.Tables["LEDG1"].Rows[0][1]) + "' AND V.VOUCHER=" + NDS1.Tables["LEDG1"].Rows[0][2] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFromDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' AND G.MTYPE='L' ", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(NDS2, "LEDG2");
                                Dr1[2] = MakeBold(Convert.ToString(NDS2.Tables["LEDG2"].Rows[0][0]));
                                NDS2.Clear();
                            }


                            //=====================================================================================
                            Dr1[3] = "         ";
                            if (DBTAMT1 != 0)
                                Dr1[4] = DBTAMT1.ToString(frmCashBook.SetDecimalPlace());
                            else
                                Dr1[4] = "  ";
                            if (CRDAMT1 != 0)
                                Dr1[5] = CRDAMT1.ToString(frmCashBook.SetDecimalPlace());
                            else
                                Dr1[5] = "  ";
                            if (BALANCE >= 0)
                                Dr1[6] = BALANCE.ToString(frmCashBook.SetDecimalPlace()) + "Db";
                            else
                            {
                                BAL = BALANCE * (-1);
                                Dr1[6] = BAL.ToString(frmCashBook.SetDecimalPlace()) + " Cr";
                            }
                            DtCollection.Rows.Add(Dr1);

                            if (CHKNAR == true)
                            {
                                CHKNAR = false;
                                //for (int p = 0; p <= SplitStr.Count - 1; p++)
                                for (int p = 0; p <= Ledg.Count - 1; p++)
                                {
                                    Dr1 = DtCollection.NewRow();
                                    Dr1[0] = "         ";
                                    Dr1[1] = "         ";
                                    // Dr1[2] = "     " + SplitStr[p];
                                    Dr1[2] = "   " + Ledg[p];
                                    Dr1[3] = "       ";
                                    Dr1[4] = "       ";
                                    Dr1[5] = "       ";
                                    DtCollection.Rows.Add(Dr1);
                                }
                                Ledg.Clear();
                                NDS1.Reset();
                                NDS2.Reset();
                            }

                            //======================================================================Naration Retriveing======================
                            //if (chbNaration.Checked == true)
                            //{
                            //    Dr1 = DtCollection.NewRow();
                            //    Dr1[0] = "         ";
                            //    Dr1[1] = "         ";

                            //    SEDATE.Clear();
                            //    cmd = new SqlCommand("SELECT NAR1 FROM narr WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND NTYPE='N' ", conn.mycon);
                            //    adp.SelectCommand = cmd;
                            //    adp.Fill(SEDATE, "NAR");
                            //    if (SEDATE.Tables["NAR"].Rows.Count > 0)
                            //        Dr1[2] = Convert.ToString(SEDATE.Tables["NAR"].Rows[0][0]);
                            //    else
                            //        Dr1[2] = "    ";


                            //    Dr1[3] = "       ";
                            //    Dr1[4] = "       ";
                            //    Dr1[5] = "       ";
                            //    Dr1[6] = "       ";
                            //    DtCollection.Rows.Add(Dr1);

                            //}

                            if (chbNaration.Checked == true)
                            {

                                SEDATE.Clear();
                                cmd = new SqlCommand("SELECT NAR1 FROM narr WHERE FICode = " + comm.CurrentFicode + " AND GCode = " + comm.PCURRENT_GCODE + " AND VOUCHER=" + test1.Tables["FINLEDG1"].Rows[i][6] + " AND T_ENTRY='" + test1.Tables["FINLEDG1"].Rows[i][5] + "' AND NTYPE='N' ", conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(SEDATE, "NAR");
                                if (SEDATE.Tables["NAR"].Rows.Count > 0)
                                {
                                    string ss1 = Convert.ToString(SEDATE.Tables["NAR"].Rows[0][0]);
                                    StringRapping(ss1, 48);
                                    for (int p = 0; p <= SplitStr.Count - 1; p++)
                                    {
                                        Dr1 = DtCollection.NewRow();
                                        Dr1[0] = "         ";
                                        Dr1[1] = "         ";
                                        Dr1[2] = "     " + SplitStr[p];
                                        Dr1[3] = "       ";
                                        Dr1[4] = "       ";
                                        Dr1[5] = "       ";
                                        DtCollection.Rows.Add(Dr1);
                                    }

                                }

                            }
                            b2 = false;
                            //====================================================================================
                       
                        }
                        else
                        {
                           if (b2 == false)
                            {
                                                              
                                b2 = true;

                            }
                           
                            CD = Convert.ToDateTime(test1.Tables["FINLEDG1"].Rows[i][0]);
                            test1.Tables["FINLEDG1"].Rows.RemoveAt(i);
                            i = i - 1;
                        
                        }

                    }

                }

                Dr1 = DtCollection.NewRow();
                Dr1[0] = "         ";
                Dr1[1] = "         ";
                Dr1[2] = "         ";
                Dr1[3] = "         ";
                Dr1[4] = "--------------------------------";
                Dr1[5] = "--------------------------------";
                Dr1[6] = "         ";
                DtCollection.Rows.Add(Dr1);

                Dr1 = DtCollection.NewRow();
                Dr1[0] = "         ";
                Dr1[1] = "         ";
                Dr1[2] = "         ";
                Dr1[3] = "Total";
                Dr1[4] = DBTAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                Dr1[5] = CRDAMT.ToString(frmCashBook.SetDecimalPlace()); ;
                Dr1[6] = "         ";
                DtCollection.Rows.Add(Dr1);

                Dr1 = DtCollection.NewRow();
                Dr1[0] = "         ";
                Dr1[1] = "         ";
                Dr1[2] = "         ";
                Dr1[3] = "         ";
                Dr1[4] = "======================";
                Dr1[5] = "======================";
                Dr1[6] = "         ";
                DtCollection.Rows.Add(Dr1);

            }
            catch { }
        }

        private void frmCashBook_Load(object sender, EventArgs e)
        {
            rbDaily.Checked = true;
            dtpFromDate.Value = edpcom.CURRCO_SDT;//edpcom.getSqlDateStr(edpcom.CURRCO_SDT);
            dtpToDate.Value = edpcom.CURRCO_EDT;
        }
        public void TE(string TEN)
        {
            TEN = TEN.Trim();
            if (TEN == "1")
                T2 = "Receipt";
            else if (TEN == "2")
                T2 = "Payment";
            else if (TEN == "3")
                T2 = "Journal";
            else if (TEN == "4")
                T2 = "Credit Note";
            else if (TEN == "5")
                T2 = "Contra";
            else if (TEN == "6")
                T2 = "Cheque Return";
            else if (TEN == "7")
                T2 = "Debit Note";
            else if (TEN == "8")
                T2 = "Purchase";
            else if (TEN == "9")
                T2 = "Sales";
            else if (TEN == "S")
                T2 = "Short Sale";
            else if (TEN == "8o")
                T2 = "Opening";
            else if (TEN == "C")
                T2 = "Composit";
        }

        public static string SetDecimalPlace()
        {
            int Dplace = edpcom.GetDecimal_Place;
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

        private void btnDosPrnt_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string address = "";
                if ((comboDialog1.Text != "") || (comboDialog1.Text != null))
                    GetDetails();
                else
                    MessageBox.Show("Ledger Account must be selected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dsBRANCH.Clear();
                cmd = new SqlCommand("SELECT BRNCH_ADD1,BRNCH_ADD2,BRNCH_CITY,BRNCH_STATE,BRNCH_PIN FROM BRANCH WHERE FICODE=" + comm.CurrentFicode + " AND GCODE=" + comm.PCURRENT_GCODE + " AND BRNCH_CODE=0", conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(dsBRANCH, "BR");

                DURATION = "" + dtpFromDate.Value.ToShortDateString() + "";
                DURATION = DURATION + "  To " + dtpToDate.Value.ToShortDateString() + "";
                SimpleTextReport stxt = new SimpleTextReport();
                stxt.MainPageHeaders.Add();
                stxt.MainPageHeaders[0].Text = "" + edpcom.CURRENT_COMPANY + "";
                stxt.MainPageHeaders[0].Bold = true;
                stxt.MainPageHeaders[0].Expanded = true;

                if (dsBRANCH.Tables["BR"].Rows.Count > 0)
                {
                    address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][0]);
                    address = address + ", " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]);

                    stxt.MainPageHeaders.Add();
                    stxt.MainPageHeaders[1].Text = "" + address + "";
                    stxt.MainPageHeaders[1].Bold = true;

                }
                
                if (dsBRANCH.Tables["BR"].Rows.Count > 0)
                {
                    address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                    if (dsBRANCH.Tables["BR"].Rows[0][4] != null)
                        address = address + " - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                    address = address + ", " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]);

                    stxt.MainPageHeaders.Add();
                    stxt.MainPageHeaders[2].Text = "" + address + "";
                    stxt.MainPageHeaders[2].Bold = true;

                }
               
                stxt.MainPageHeaders.Add();
                stxt.MainPageHeaders[3].Text = comboDialog1.Text + " Book";
                stxt.MainPageHeaders[3].Expanded=true;
                stxt.MainPageHeaders[3].Bold = true;

                stxt.MainPageHeaders.Add();
                stxt.MainPageHeaders[4].Text = "" + DURATION + "";
                stxt.MainPageHeaders[4].Bold = true;

                stxt.ShowSubPageHeaders = true;

                stxt.SubPageHeaders.Add();
                stxt.SubPageHeaders[0].Bold = true;
                stxt.SubPageHeaders[0].Alignment = SimpleTextReport.PutTextAlign.Left;
                stxt.SubPageHeaders[0].Expanded = true;
                stxt.SubPageHeaders[0].Text = "" + edpcom.CURRENT_COMPANY + "";

                stxt.SubPageHeaders.Add();
                stxt.SubPageHeaders[1].Bold = true;
                stxt.SubPageHeaders[1].Alignment = SimpleTextReport.PutTextAlign.Left;
                stxt.SubPageHeaders[1].Expanded = false;
                stxt.SubPageHeaders[1].Text = comboDialog1.Text + " Book";

                stxt.SubPageHeaders.Add();
                stxt.SubPageHeaders[2].Bold = true;
                stxt.SubPageHeaders[2].Alignment = SimpleTextReport.PutTextAlign.Left;
                stxt.SubPageHeaders[2].Expanded = false;
                stxt.SubPageHeaders[2].Text = "" + DURATION + "";

                stxt.DrawLineAtEndofPage = true;
                stxt.DrawLineAtEndofReport = true;
                stxt.ActiveDataTable = true;
                stxt.DataTable = DtCollection;



                if (rbDaily.Checked == true)
                {
                    if (chbConsolidated.Checked == false)
                    {   
                        //ShowDetails();
                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[0].TDataTable = DtCollection;
                        stxt.ReportColumns[0].LinesToAColumn = 12;      //15
                        stxt.ReportColumns[0].DataField = "Date";
                        stxt.ReportColumns[0].Condensed = true;
                        stxt.ReportColumns[0].Borderget = true;
                        stxt.ReportColumns[0].Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[0].Header.Bold = true;
                        stxt.ReportColumns[0].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[0].Header.Condensed = true;
                        stxt.ReportColumns[0].Header.Text.Add("DATE");

                        //stxt.CustomisedSection.Add();
                        //stxt.CustomisedSection[0].Lines.Add();
                        //stxt.CustomisedSection[0].Lines[i].Cells.Add();
                        //stxt.CustomisedSection[0].Lines[i].Cells[0].Bold = true;
                        //stxt.CustomisedSection[0].Lines[i].Cells[0].Text = DtCollection.Rows[i][0];
                        
                        
                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[1].TDataTable = DtCollection;
                        stxt.ReportColumns[1].LinesToAColumn = 18;      //20
                        stxt.ReportColumns[1].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[1].DataField = "VoucherNo";
                        stxt.ReportColumns[1].Condensed = true;
                        stxt.ReportColumns[1].Borderget = true;
                        stxt.ReportColumns[1].Header.Bold = true;
                        stxt.ReportColumns[1].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[1].Header.Condensed = true;
                        stxt.ReportColumns[1].Header.Text.Add("Voucher No.");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[2].TDataTable = DtCollection;
                        stxt.ReportColumns[2].LinesToAColumn = 56;   //65
                        stxt.ReportColumns[2].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[2].DataField = "Description";
                        stxt.ReportColumns[2].Condensed = true;
                        stxt.ReportColumns[2].Borderget = true;
                        stxt.ReportColumns[2].Header.Bold = true;
                        stxt.ReportColumns[2].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[2].Header.Condensed = true;
                        stxt.ReportColumns[2].Header.Text.Add("Description");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[3].TDataTable = DtCollection;
                        stxt.ReportColumns[3].LinesToAColumn = 16;      //18
                        stxt.ReportColumns[3].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[3].DataField = "SubDesc";
                        stxt.ReportColumns[3].Condensed = true;
                        stxt.ReportColumns[3].Borderget = true;
                        stxt.ReportColumns[3].Header.Bold = true;
                        stxt.ReportColumns[3].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[3].Header.Condensed = true;
                        stxt.ReportColumns[3].Header.Text.Add("            ");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[4].TDataTable = DtCollection;
                        stxt.ReportColumns[4].LinesToAColumn = 14;      //19
                        stxt.ReportColumns[4].Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[4].DataField = "DebitAmt";
                        stxt.ReportColumns[4].Condensed = true;
                        stxt.ReportColumns[4].Borderget = true;
                        stxt.ReportColumns[4].Header.Bold = true;
                        stxt.ReportColumns[4].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[4].Header.Condensed = true;
                        stxt.ReportColumns[4].Header.Text.Add("Debit Amt.");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[5].TDataTable = DtCollection;
                        stxt.ReportColumns[5].LinesToAColumn = 14;      //19
                        stxt.ReportColumns[5].Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[5].DataField = "CreditAmt";
                        stxt.ReportColumns[5].Condensed = true;
                        stxt.ReportColumns[5].Borderget = false;
                        stxt.ReportColumns[5].Header.Bold = true;
                        stxt.ReportColumns[5].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[5].Header.Condensed = true;
                        stxt.ReportColumns[5].Header.Text.Add("Credit Amt.");
                    }
                    else
                    {
                     //   GetConsolidatedDaily();
                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[0].TDataTable = DtCollection;
                        stxt.ReportColumns[0].LinesToAColumn = 25;
                        stxt.ReportColumns[0].DataField = "Date";
                        stxt.ReportColumns[0].Borderget = true;
                        stxt.ReportColumns[0].Condensed = true;
                        stxt.ReportColumns[0].Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[0].Header.Bold = true;
                        stxt.ReportColumns[0].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[0].Header.Condensed = true;
                        stxt.ReportColumns[0].Header.Text.Add("Period");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[1].TDataTable = DtCollection;
                        stxt.ReportColumns[1].LinesToAColumn = 25;
                        stxt.ReportColumns[1].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[1].DataField = "VoucherNo";
                        stxt.ReportColumns[1].Borderget = true;
                        stxt.ReportColumns[1].Condensed = true;
                        stxt.ReportColumns[1].Header.Bold = true;
                        stxt.ReportColumns[1].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[1].Header.Condensed = true;
                        stxt.ReportColumns[1].Header.Text.Add("Opening Balance");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[2].TDataTable = DtCollection;
                        stxt.ReportColumns[2].LinesToAColumn = 17;
                        stxt.ReportColumns[2].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[2].DataField = "Description";
                        stxt.ReportColumns[2].Borderget = true;
                        stxt.ReportColumns[2].Condensed = true;
                        stxt.ReportColumns[2].Header.Bold = true;
                        stxt.ReportColumns[2].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[2].Header.Condensed = true;
                        stxt.ReportColumns[2].Header.Text.Add("        ");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[3].TDataTable = DtCollection;
                        stxt.ReportColumns[3].LinesToAColumn = 25;
                        stxt.ReportColumns[3].Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[3].DataField = "SubDesc";
                        stxt.ReportColumns[3].Borderget = true;
                        stxt.ReportColumns[3].Condensed = true;
                        stxt.ReportColumns[3].Header.Bold = true;
                        stxt.ReportColumns[3].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[3].Header.Condensed = true;
                        stxt.ReportColumns[3].Header.Text.Add("Debit Amt.");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[4].TDataTable = DtCollection;
                        stxt.ReportColumns[4].LinesToAColumn = 25;
                        stxt.ReportColumns[4].Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[4].DataField = "DebitAmt";
                        stxt.ReportColumns[4].Borderget = true;
                        stxt.ReportColumns[4].Condensed = true;
                        stxt.ReportColumns[4].Header.Bold = true;
                        stxt.ReportColumns[4].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[4].Header.Condensed = true;
                        stxt.ReportColumns[4].Header.Text.Add("Credit Amt.");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[5].TDataTable = DtCollection;
                        stxt.ReportColumns[5].LinesToAColumn = 25;
                        stxt.ReportColumns[5].Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[5].DataField = "CreditAmt";
                        stxt.ReportColumns[5].Borderget = false;
                        stxt.ReportColumns[5].Condensed = true;
                        stxt.ReportColumns[5].Header.Bold = true;
                        stxt.ReportColumns[5].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[5].Header.Condensed = true;
                        stxt.ReportColumns[5].Header.Text.Add("Balance");
  
                    }
                }
                if (rbSide.Checked == true)
                {
                    if (chbConsolidated.Checked == false)
                    {
                        //ShowSideBalance();
                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[0].TDataTable = DtCollection;
                        stxt.ReportColumns[0].LinesToAColumn = 15;
                        stxt.ReportColumns[0].DataField = "Date";
                        stxt.ReportColumns[0].Borderget = true;
                        stxt.ReportColumns[0].Condensed = true;
                        stxt.ReportColumns[0].Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[0].Header.Bold = true;
                        stxt.ReportColumns[0].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[0].Header.Condensed = true;
                        stxt.ReportColumns[0].Header.Text.Add("DATE");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[1].TDataTable = DtCollection;
                        stxt.ReportColumns[1].LinesToAColumn = 20;
                        stxt.ReportColumns[1].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[1].DataField = "VoucherNo";
                        stxt.ReportColumns[1].Borderget = true;
                        stxt.ReportColumns[1].Condensed = true;
                        stxt.ReportColumns[1].Header.Bold = true;
                        stxt.ReportColumns[1].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[1].Header.Condensed = true;
                        stxt.ReportColumns[1].Header.Text.Add("Opening Balance");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[2].TDataTable = DtCollection;
                        stxt.ReportColumns[2].LinesToAColumn = 55;
                        stxt.ReportColumns[2].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[2].DataField = "Description";
                        stxt.ReportColumns[2].Borderget = true;
                        stxt.ReportColumns[2].Condensed = true;
                        stxt.ReportColumns[2].Header.Bold = true;
                        stxt.ReportColumns[2].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[2].Header.Condensed = true;
                        stxt.ReportColumns[2].Header.Text.Add("Description");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[3].TDataTable = DtCollection;
                        stxt.ReportColumns[3].LinesToAColumn = 10;
                        stxt.ReportColumns[3].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[3].DataField = "SubDesc";
                        stxt.ReportColumns[3].Borderget = true;
                        stxt.ReportColumns[3].Condensed = true;
                        stxt.ReportColumns[3].Header.Bold = true;
                        stxt.ReportColumns[3].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[3].Header.Condensed = true;
                        stxt.ReportColumns[3].Header.Text.Add("          ");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[4].TDataTable = DtCollection;
                        stxt.ReportColumns[4].LinesToAColumn = 18;
                        stxt.ReportColumns[4].Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[4].DataField = "DebitAmt";
                        stxt.ReportColumns[4].Borderget = true;
                        stxt.ReportColumns[4].Condensed = true;
                        stxt.ReportColumns[4].Header.Bold = true;
                        stxt.ReportColumns[4].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[4].Header.Condensed = true;
                        stxt.ReportColumns[4].Header.Text.Add("Debit Amt.");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[5].TDataTable = DtCollection;
                        stxt.ReportColumns[5].LinesToAColumn = 18;
                        stxt.ReportColumns[5].Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[5].DataField = "CreditAmt";
                        stxt.ReportColumns[5].Borderget = true;
                        stxt.ReportColumns[5].Condensed = true;
                        stxt.ReportColumns[5].Header.Bold = true;
                        stxt.ReportColumns[5].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[5].Header.Condensed = true;
                        stxt.ReportColumns[5].Header.Text.Add("Credit Amt.");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[6].TDataTable = DtCollection;
                        stxt.ReportColumns[6].LinesToAColumn = 22;
                        stxt.ReportColumns[6].Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[6].DataField = "Balance";
                        stxt.ReportColumns[6].Borderget = false;
                        stxt.ReportColumns[6].Condensed = true;
                        stxt.ReportColumns[6].Header.Bold = true;
                        stxt.ReportColumns[6].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[6].Header.Condensed = true;
                        stxt.ReportColumns[6].Header.Text.Add("Balance");
                    }
                }

                if (rbMonthly.Checked == true)
                    if (chbConsolidated.Checked == true)
                    {
                        //   GetConsolidatedMonthly();
                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[0].TDataTable = DtCollection;
                        stxt.ReportColumns[0].LinesToAColumn = 30;
                        stxt.ReportColumns[0].DataField = "Date";
                        stxt.ReportColumns[0].Borderget = true;
                        stxt.ReportColumns[0].Condensed = true;
                        stxt.ReportColumns[0].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[0].Header.Bold = true;
                        stxt.ReportColumns[0].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[0].Header.Condensed = true;
                        stxt.ReportColumns[0].Header.Text.Add("Period");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[1].TDataTable = DtCollection;
                        stxt.ReportColumns[1].LinesToAColumn = 30;
                        stxt.ReportColumns[1].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[1].DataField = "VoucherNo";
                        stxt.ReportColumns[1].Borderget = true;
                        stxt.ReportColumns[1].Condensed = true;
                        stxt.ReportColumns[1].Header.Bold = true;
                        stxt.ReportColumns[1].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[1].Header.Condensed = true;
                        stxt.ReportColumns[1].Header.Text.Add("Opening Balance");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[2].TDataTable = DtCollection;
                        stxt.ReportColumns[2].LinesToAColumn = 15;
                        stxt.ReportColumns[2].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[2].DataField = "Description";
                        stxt.ReportColumns[2].Borderget = true;
                        stxt.ReportColumns[2].Condensed = true;
                        stxt.ReportColumns[2].Header.Bold = true;
                        stxt.ReportColumns[2].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[2].Header.Condensed = true;
                        stxt.ReportColumns[2].Header.Text.Add("          ");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[3].TDataTable = DtCollection;
                        stxt.ReportColumns[3].LinesToAColumn = 25;
                        stxt.ReportColumns[3].Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[3].DataField = "SubDesc";
                        stxt.ReportColumns[3].Borderget = true;
                        stxt.ReportColumns[3].Condensed = true;
                        stxt.ReportColumns[3].Header.Bold = true;
                        stxt.ReportColumns[3].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[3].Header.Condensed = true;
                        stxt.ReportColumns[3].Header.Text.Add("Debit Amt.");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[4].TDataTable = DtCollection;
                        stxt.ReportColumns[4].LinesToAColumn = 25;
                        stxt.ReportColumns[4].Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[4].DataField = "DebitAmt";
                        stxt.ReportColumns[4].Borderget = true;
                        stxt.ReportColumns[4].Condensed = true;
                        stxt.ReportColumns[4].Header.Bold = true;
                        stxt.ReportColumns[4].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[4].Header.Condensed = true;
                        stxt.ReportColumns[4].Header.Text.Add("Credit Amt.");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[5].TDataTable = DtCollection;
                        stxt.ReportColumns[5].LinesToAColumn = 25;
                        stxt.ReportColumns[5].Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[5].DataField = "CreditAmt";
                        stxt.ReportColumns[5].Borderget = false;
                        stxt.ReportColumns[5].Condensed = true;
                        stxt.ReportColumns[5].Header.Bold = true;
                        stxt.ReportColumns[5].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[5].Header.Condensed = true;
                        stxt.ReportColumns[5].Header.Text.Add("Balance");
                    }
                    else
                    {
                     //   GetMonthlyBalance();
                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[0].TDataTable = DtCollection;
                        stxt.ReportColumns[0].LinesToAColumn = 18;
                        stxt.ReportColumns[0].DataField = "Date";
                        stxt.ReportColumns[0].Borderget = true;
                        stxt.ReportColumns[0].Condensed = true;
                        stxt.ReportColumns[0].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[0].Header.Bold = true;
                        stxt.ReportColumns[0].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[0].Header.Condensed = true;
                        stxt.ReportColumns[0].Header.Text.Add("DATE");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[1].TDataTable = DtCollection;
                        stxt.ReportColumns[1].LinesToAColumn = 20;
                        stxt.ReportColumns[1].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[1].DataField = "VoucherNo";
                        stxt.ReportColumns[1].Borderget = true;
                        stxt.ReportColumns[1].Condensed = true;
                        stxt.ReportColumns[1].Header.Bold = true;
                        stxt.ReportColumns[1].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[1].Header.Condensed = true;
                        stxt.ReportColumns[1].Header.Text.Add("Voucher No.");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[2].TDataTable = DtCollection;
                        stxt.ReportColumns[2].LinesToAColumn = 60;
                        stxt.ReportColumns[2].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[2].DataField = "Description";
                        stxt.ReportColumns[2].Borderget = true;
                        stxt.ReportColumns[2].Condensed = true;
                        stxt.ReportColumns[2].Header.Bold = true;
                        stxt.ReportColumns[2].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[2].Header.Condensed = true;
                        stxt.ReportColumns[2].Header.Text.Add("Description");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[3].TDataTable = DtCollection;
                        stxt.ReportColumns[3].LinesToAColumn = 15;
                        stxt.ReportColumns[3].Alignment = SimpleTextReport.PutTextAlign.Left;
                        stxt.ReportColumns[3].DataField = "SubDesc";
                        stxt.ReportColumns[3].Borderget = true;
                        stxt.ReportColumns[3].Condensed = true;
                        stxt.ReportColumns[3].Header.Bold = true;
                        stxt.ReportColumns[3].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                        stxt.ReportColumns[3].Header.Condensed = true;
                        stxt.ReportColumns[3].Header.Text.Add("                 ");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[4].TDataTable = DtCollection;
                        stxt.ReportColumns[4].LinesToAColumn = 18;
                        stxt.ReportColumns[4].Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[4].DataField = "DebitAmt";
                        stxt.ReportColumns[4].Borderget = true;
                        stxt.ReportColumns[4].Condensed = true;
                        stxt.ReportColumns[4].Header.Bold = true;
                        stxt.ReportColumns[4].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[4].Header.Condensed = true;
                        stxt.ReportColumns[4].Header.Text.Add("Debit Amt.");

                        stxt.ReportColumns.Add();
                        stxt.ReportColumns[5].TDataTable = DtCollection;
                        stxt.ReportColumns[5].LinesToAColumn = 18;
                        stxt.ReportColumns[5].Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[5].DataField = "CreditAmt";
                        stxt.ReportColumns[5].Borderget = false;
                        stxt.ReportColumns[5].Condensed = true;
                        stxt.ReportColumns[5].Header.Bold = true;
                        stxt.ReportColumns[5].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                        stxt.ReportColumns[5].Header.Condensed = true;
                        stxt.ReportColumns[5].Header.Text.Add("Credit Amt.");

                    }
               
                if (CHK == true)
                {
                    string aa = MessageBox.Show("Are you sure to Print?", "Acknowledgment...", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                    if (aa == System.Windows.Forms.DialogResult.Yes.ToString())
                    {
                        try
                        {
                            stxt.Print();
                        }
                        catch { }
                    }
                }
                CHK = true;
                DtCollection.Clear();
                this.Cursor = Cursors.Default;
            }

            catch { }
        }

        private void getMonth()
        {

            if (mm == "01")
                Dr1[0] = "January   " + yy + "";
            else
            {
                if (mm == "02")
                    Dr1[0] = "February   " + yy + "";
                else
                {
                    if (mm == "03")
                        Dr1[0] = "March     " + yy + "";
                    else
                    {
                        if (mm == "04")
                            Dr1[0] = "April     " + yy + "";
                        else
                        {
                            if (mm == "05")
                                Dr1[0] = "May       " + yy + "";
                            else
                            {
                                if (mm == "06")
                                    Dr1[0] = "June      " + yy + "";
                                else
                                {
                                    if (mm == "07")
                                        Dr1[0] = "Jully     " + yy + "";
                                    else
                                    {
                                        if (mm == "08")
                                            Dr1[0] = "August    " + yy + "";
                                        else
                                        {
                                            if (mm == "09")
                                                Dr1[0] = "September " + yy + "";
                                            else
                                            {
                                                if (mm == "10")
                                                    Dr1[0] = "October   " + yy + "";
                                                else
                                                {
                                                    if (mm == "11")
                                                        Dr1[0] = "November  " + yy + "";
                                                    else
                                                        Dr1[0] = "December  " + yy + "";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }



        }
 
   
    }
}