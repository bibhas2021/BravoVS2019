using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.VisualBasic;
using EDPComponent;

namespace MidasReport
{
    public partial class frmRptJurnal : Form
    {        
        Edpcom.EDPConnection conn = new EDPConnection();
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon comm = new EDPCommon();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataSet dsDESC = new DataSet();
        DataSet dsBRANCH = new DataSet();
        DataSet dsNAR = new DataSet();

        DataTable Dt_JURNAL = new DataTable("DT");
        DataColumn DC_VDATE = new DataColumn("Date");
        DataColumn DC_VNO = new DataColumn("VoucherNo");
        DataColumn DC_LDESC = new DataColumn("Particulars");
        DataColumn DC_DB = new DataColumn("DebitAmt");
        DataColumn DC_CR = new DataColumn("CreditAmt");
        DataRow DR;
        
        
        int i;
        String s, SV, DURATION;
        Int64 vchno1, vchno2;

        public frmRptJurnal()
        {
            InitializeComponent();
        }

        private void btnDosPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string address="";
                CollectionJLedger();
                RequiredDataSet();

                dsBRANCH.Clear();
                cmd = new SqlCommand("SELECT BRNCH_ADD1,BRNCH_ADD2,BRNCH_CITY,BRNCH_STATE,BRNCH_PIN FROM BRANCH WHERE FICODE=" + comm.CurrentFicode + " AND GCODE=" + comm.PCURRENT_GCODE + " AND BRNCH_CODE=0", conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(dsBRANCH, "BR");
                
                DURATION = "" + dtpFormDate.Value.ToShortDateString() + "";
                DURATION = DURATION + "  To " + dtpToDate.Value.ToShortDateString() + "";
                SimpleTextReport stxt = new SimpleTextReport();
                stxt.MainPageHeaders.Add();
                stxt.MainPageHeaders[0].Text = ""+edpcom.CURRENT_COMPANY+"";
                stxt.MainPageHeaders[0].Bold = true;
                stxt.MainPageHeaders[0].Expanded = true;

                if (dsBRANCH.Tables["BR"].Rows.Count > 0)
                {
                    address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][0]);
                    address = address + ", " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]);
                }
                stxt.MainPageHeaders.Add();
                stxt.MainPageHeaders[1].Text = "" + address + "";
                stxt.MainPageHeaders[1].Bold = true;

                if (dsBRANCH.Tables["BR"].Rows.Count > 0)
                {
                    address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                    if(dsBRANCH.Tables["BR"].Rows[0][4]!=null)
                        address = address + " - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                    address = address + ", " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]);
                }
                stxt.MainPageHeaders.Add();
                stxt.MainPageHeaders[2].Text = "" + address + "";
                stxt.MainPageHeaders[2].Bold = true;

                stxt.MainPageHeaders.Add();
                stxt.MainPageHeaders[3].Text = ""+DURATION+"";
                stxt.MainPageHeaders[3].Bold = true;
                //stxt.MainPageHeaders[1].Expanded = true;
               
                //i = 0;
                //stxt.CustomisedSection.Add();
                //stxt.CustomisedSection[0].Lines.Add();
                //stxt.CustomisedSection[0].Lines[i].Cells.Add();
                //stxt.CustomisedSection[0].Lines[i].Cells[0].DataTable = Dt_JURNAL;
                //stxt.CustomisedSection[0].Lines[i].Cells[0].DataField = "Date";
                //stxt.CustomisedSection[0].Lines[i].Cells[0].Condensed = true;
                //stxt.CustomisedSection[0].Lines[i].Cells[0].Width = 12;
              
                //i++;
                //stxt.CustomisedSection[0].Lines.Add();
                //stxt.CustomisedSection[0].Lines[i].Cells.Add();
                //stxt.CustomisedSection[0].Lines[i].Cells[0].DataTable = Dt_JURNAL;
                //stxt.CustomisedSection[0].Lines[i].Cells[0].DataField = "VoucherNo";
                //stxt.CustomisedSection[0].Lines[i].Cells[0].Condensed = true;
                //stxt.CustomisedSection[0].Lines[i].Cells[0].Width = 14;

                //i++;
                //stxt.CustomisedSection[0].Lines.Add();
                //stxt.CustomisedSection[0].Lines[i].Cells.Add();
                //stxt.CustomisedSection[0].Lines[i].Cells[0].DataTable = Dt_JURNAL;
                //stxt.CustomisedSection[0].Lines[i].Cells[0].DataField = "Particulars";
                //stxt.CustomisedSection[0].Lines[i].Cells[0].Condensed = true;
                //stxt.CustomisedSection[0].Lines[i].Cells[0].Width = 25;

                //i++;
                //stxt.CustomisedSection[0].Lines.Add();
                //stxt.CustomisedSection[0].Lines[i].Cells.Add();
                //stxt.CustomisedSection[0].Lines[i].Cells[0].DataTable = Dt_JURNAL;
                //stxt.CustomisedSection[0].Lines[i].Cells[0].DataField = "DebitAmt";
                //stxt.CustomisedSection[0].Lines[i].Cells[0].Condensed = true;
                //stxt.CustomisedSection[0].Lines[i].Cells[0].Width = 8;

                //i++;
                //stxt.CustomisedSection[0].Lines.Add();
                //stxt.CustomisedSection[0].Lines[i].Cells.Add();
                //stxt.CustomisedSection[0].Lines[i].Cells[0].DataTable = Dt_JURNAL;
                //stxt.CustomisedSection[0].Lines[i].Cells[0].DataField = "CreditAmt";
                //stxt.CustomisedSection[0].Lines[i].Cells[0].Condensed = true;
                //stxt.CustomisedSection[0].Lines[i].Cells[0].Width = 8;
                //stxt.CustomisedSection[0].Lines[i].Cells[0].SysData = SimpleTextReport.STSysDataType.Date;
//=====================================================================================
                if (cbVchNo.Checked == true)
                {
                    stxt.ActiveDataTable = true;
                    stxt.DataTable = Dt_JURNAL;
                    stxt.ReportColumns.Add();
                    stxt.ReportColumns[0].TDataTable = Dt_JURNAL;
                    stxt.ReportColumns[0].LinesToAColumn = 12;
                    stxt.ReportColumns[0].DataField = "Date";
                    stxt.ReportColumns[0].Borderget = true;
                    stxt.ReportColumns[0].Alignment = SimpleTextReport.PutTextAlign.Center;
                    stxt.ReportColumns[0].Header.Bold = true;
                    stxt.ReportColumns[0].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                    stxt.ReportColumns[0].Header.Text.Add("DATE");

                    stxt.ReportColumns.Add();
                    stxt.ReportColumns[1].TDataTable = Dt_JURNAL;
                    stxt.ReportColumns[1].LinesToAColumn = 14;
                    stxt.ReportColumns[1].Alignment = SimpleTextReport.PutTextAlign.Center;
                    stxt.ReportColumns[1].DataField = "VoucherNo";
                    stxt.ReportColumns[1].Borderget = true;
                    stxt.ReportColumns[1].Header.Bold = true;
                    stxt.ReportColumns[1].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                    stxt.ReportColumns[1].Header.Text.Add("Voucher No.");

                    stxt.ReportColumns.Add();
                    stxt.ReportColumns[2].TDataTable = Dt_JURNAL;
                    stxt.ReportColumns[2].LinesToAColumn = 35;
                    stxt.ReportColumns[2].Alignment = SimpleTextReport.PutTextAlign.Left;
                    stxt.ReportColumns[2].DataField = "Particulars";
                    stxt.ReportColumns[2].Borderget = true;
                    stxt.ReportColumns[2].Header.Bold = true;
                    stxt.ReportColumns[2].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                    stxt.ReportColumns[2].Header.Text.Add("Particulars");

                    stxt.ReportColumns.Add();
                    stxt.ReportColumns[3].TDataTable = Dt_JURNAL;
                    stxt.ReportColumns[3].LinesToAColumn = 15;

                    stxt.ReportColumns[3].Alignment = SimpleTextReport.PutTextAlign.Right;
                    stxt.ReportColumns[3].DataField = "DebitAmt";
                    stxt.ReportColumns[3].Borderget = true;
                    stxt.ReportColumns[3].Header.Bold = true;
                    stxt.ReportColumns[3].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                    stxt.ReportColumns[3].Header.Text.Add("Debit Amt.");

                    stxt.ReportColumns.Add();
                    stxt.ReportColumns[4].TDataTable = Dt_JURNAL;
                    stxt.ReportColumns[4].LinesToAColumn = 15;
                    stxt.ReportColumns[4].Alignment = SimpleTextReport.PutTextAlign.Right;
                    stxt.ReportColumns[4].DataField = "CreditAmt";
                    stxt.ReportColumns[4].Borderget = true;
                    stxt.ReportColumns[4].Header.Bold = true;
                    stxt.ReportColumns[4].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                    stxt.ReportColumns[4].Header.Text.Add("Credit Amt.");
                   
                }
                else
                {
                    stxt.ActiveDataTable = true;
                    stxt.DataTable = Dt_JURNAL;
                    stxt.ReportColumns.Add();
                    stxt.ReportColumns[0].TDataTable = Dt_JURNAL;
                    stxt.ReportColumns[0].LinesToAColumn = 12;
                    stxt.ReportColumns[0].DataField = "Date";
                    stxt.ReportColumns[0].Borderget = true;
                    stxt.ReportColumns[0].Alignment = SimpleTextReport.PutTextAlign.Center;
                    stxt.ReportColumns[0].Header.Bold = true;
                    stxt.ReportColumns[0].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                    stxt.ReportColumns[0].Header.Text.Add("DATE");

                    stxt.ReportColumns.Add();
                    stxt.ReportColumns[1].TDataTable = Dt_JURNAL;
                    stxt.ReportColumns[1].LinesToAColumn = 45;
                    stxt.ReportColumns[1].Alignment = SimpleTextReport.PutTextAlign.Left;
                    stxt.ReportColumns[1].DataField = "Particulars";
                    stxt.ReportColumns[1].Borderget = true;
                    stxt.ReportColumns[1].Header.Bold = true;
                    stxt.ReportColumns[1].Header.Alignment = SimpleTextReport.PutTextAlign.Center;
                    stxt.ReportColumns[1].Header.Text.Add("Particulars");

                    stxt.ReportColumns.Add();
                    stxt.ReportColumns[2].TDataTable = Dt_JURNAL;
                    stxt.ReportColumns[2].LinesToAColumn = 16;
                    stxt.ReportColumns[2].Alignment = SimpleTextReport.PutTextAlign.Right;
                    stxt.ReportColumns[2].DataField = "DebitAmt";
                    stxt.ReportColumns[2].Borderget = true;
                    stxt.ReportColumns[2].Header.Bold = true;
                    stxt.ReportColumns[2].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                    stxt.ReportColumns[2].Header.Text.Add("Debit Amt.");

                    stxt.ReportColumns.Add();
                    stxt.ReportColumns[3].TDataTable = Dt_JURNAL;
                    stxt.ReportColumns[3].LinesToAColumn = 16;
                    stxt.ReportColumns[3].Alignment = SimpleTextReport.PutTextAlign.Right;
                    stxt.ReportColumns[3].DataField = "CreditAmt";
                    stxt.ReportColumns[3].Borderget = true;
                    stxt.ReportColumns[3].Header.Bold = true;
                    stxt.ReportColumns[3].Header.Alignment = SimpleTextReport.PutTextAlign.Right;
                    stxt.ReportColumns[3].Header.Text.Add("Credit Amt.");
                   
                }
                string aa = MessageBox.Show("Are you sure to Print?", "Acknowledgment...", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (aa == System.Windows.Forms.DialogResult.Yes.ToString())
                {
                    stxt.Print();
                }
                dsDESC.Tables["DESC"].Clear();
                Dt_JURNAL.Clear();
            }
            catch { }
        }
        //public void CollectionJLedger()
        //{
        //    try
        //    {
        //        conn.Open();
        //        ds.Clear();
        //        if (radioPeriod.Checked == true)
        //        {
        //            s = "SELECT DISTINCT VOUCHER FROM VCHR WHERE FICODE=" + comm.CurrentFicode + " AND GCODE=" + comm.PCURRENT_GCODE + " AND T_ENTRY='3' AND VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFormDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "'";
        //        }
        //        else
        //        {
        //            s = "SELECT DISTINCT VOUCHER FROM VCHR WHERE FICODE=" + comm.CurrentFicode + " AND GCODE=" + comm.PCURRENT_GCODE + " AND T_ENTRY='3' AND VOUCHER BETWEEN '" + vchno1 + "' AND '" + vchno2 + "'";
        //        }
        //        cmd = new SqlCommand(s, conn.mycon);
        //        adp.SelectCommand = cmd;
        //        adp.Fill(ds, "VOU");
                
        //        s = "";
                
        //        for(i = 0; i <= ds.Tables["VOU"].Rows.Count-1; i++)
        //        {
        //             s = "SELECT DISTINCT VOUCHER,GLCODE,TOBY FROM VCHR WHERE FICODE="+comm.CurrentFicode+" AND GCODE="+comm.PCURRENT_GCODE+" AND T_ENTRY='3'AND VOUCHER="+ds.Tables["VOU"].Rows[i][0]+"";
        //             cmd = new SqlCommand(s, conn.mycon);
        //             adp.SelectCommand = cmd;
        //             adp.Fill(ds, "GC");
                     
        //        }
        //        conn.Close();
        //    }
        //    catch { }
        //}
        public void CollectionJLedger()
        {
            try
            {
                conn.Open();
                ds.Clear();
                if (radioPeriod.Checked == true)
                {
                    s = "SELECT DISTINCT VOUCHER,VCHDATE FROM VCHR WHERE FICODE=" + comm.CurrentFicode + " AND GCODE=" + comm.PCURRENT_GCODE + " AND T_ENTRY='3' AND VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFormDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "' ORDER BY VCHDATE";
                }
                else
                {
                    s = "SELECT DISTINCT VOUCHER,VCHDATE FROM VCHR WHERE FICODE=" + comm.CurrentFicode + " AND GCODE=" + comm.PCURRENT_GCODE + " AND T_ENTRY='3' AND VOUCHER BETWEEN '" + vchno1 + "' AND '" + vchno2 + "' ORDER BY VCHDATE";
                }
                cmd = new SqlCommand(s, conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(ds, "VOU");

                s = "";

                for (i = 0; i <= ds.Tables["VOU"].Rows.Count - 1; i++)
                {
                    s = "SELECT VOUCHER,GLCODE,TOBY FROM VCHR WHERE FICODE=" + comm.CurrentFicode + " AND GCODE=" + comm.PCURRENT_GCODE + " AND T_ENTRY='3'AND VOUCHER=" + ds.Tables["VOU"].Rows[i][0] + " ORDER BY VCHDATE";
                    cmd = new SqlCommand(s, conn.mycon);
                    adp.SelectCommand = cmd;
                    adp.Fill(ds, "GC");

                }
                conn.Close();
            }
            catch { }
        }

        //public void RequiredDataSet()
        //{
        //    try
        //    {
        //        Boolean B = true;
        //        Boolean chfirst = true;
        //        double CRA = 0.0, DBA = 0.0;
        //       // if(Dt_JURNAL.Columns==null)
        //            Dt_JURNAL.Columns.Clear();
                
        //        Dt_JURNAL.Columns.Add(DC_VDATE);
        //        Dt_JURNAL.Columns.Add(DC_VNO);
        //        Dt_JURNAL.Columns.Add(DC_LDESC);
        //        Dt_JURNAL.Columns.Add(DC_DB);
        //        Dt_JURNAL.Columns.Add(DC_CR);

        //        if (radioPeriod.Checked == true)
        //        {
        //            conn.Open();
        //            s = "";
        //            if (cbNar.Checked == false)
        //            {
        //                for (i = 0; i <= ds.Tables["GC"].Rows.Count - 1; i++)
        //                {
        //                    s = "SELECT DISTINCT V.VCHDATE, V.VOUCHER, G.LDESC, V.DBAMT, V.CRAMT FROM VCHR V,GLMST G WHERE G.GLCODE=V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE ";
        //                    s = s + "AND V.FICODE=" + comm.CurrentFicode + " AND V.GCODE=" + comm.PCURRENT_GCODE + " AND V.T_ENTRY='3' AND G.MTYPE='L' AND ";
        //                    s = s + "V.GLCODE=" + ds.Tables["GC"].Rows[i][1] + " AND V.VOUCHER=" + ds.Tables["GC"].Rows[i][0] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFormDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "'";

        //                    cmd = new SqlCommand(s, conn.mycon);
        //                    adp.SelectCommand = cmd;
        //                    adp.Fill(dsDESC, "DESC");
        //                    if (B == true)
        //                        SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[0][1]);
        //                    if (SV != Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]))
        //                    {
        //                        SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);

        //                        DR = Dt_JURNAL.NewRow();
        //                        DR[0] = "            ";
        //                        DR[3] = "---------------";
        //                        DR[4] = "---------------";
        //                        Dt_JURNAL.Rows.Add(DR);

        //                        DR = Dt_JURNAL.NewRow();
        //                        DR[0] = "            ";
        //                        DR[3] = Convert.ToString(DBA);
        //                        DR[4] = Convert.ToString(CRA);
        //                        Dt_JURNAL.Rows.Add(DR);

        //                        DR = Dt_JURNAL.NewRow();
        //                        DR[0] = "            ";
        //                        DR[3] = "---------------";
        //                        DR[4] = "---------------";
        //                        Dt_JURNAL.Rows.Add(DR);

        //                        CRA = 0.0;
        //                        DBA = 0.0;
        //                        B = false;
        //                        chfirst = true;
        //                    }
        //                    CRA = CRA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
        //                    DBA = DBA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
        //                    DR = Dt_JURNAL.NewRow();
        //                    double amt;
        //                    DateTime dd1;
        //                    if (chfirst == true)
        //                    {
        //                        dd1 = Convert.ToDateTime(dsDESC.Tables["DESC"].Rows[i][0]);
        //                        DR[0] = dd1.ToShortDateString();
        //                        DR[1] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);
        //                        chfirst = false;
        //                    }
        //                    else
        //                    {
        //                        DR[0] = "            ";
        //                    }
        //                    DR[2] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][2]);

        //                    amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
        //                    if (amt == 0)
        //                        DR[3] = "";
        //                    else
        //                        DR[3] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]));

        //                    amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
        //                    if (amt == 0)
        //                        DR[4] = "";
        //                    else
        //                        DR[4] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]));

        //                    Dt_JURNAL.Rows.Add(DR);
        //                }

        //                DR = Dt_JURNAL.NewRow();
        //                DR[0] = "            ";
        //                DR[3] = "--------------------";
        //                DR[4] = "--------------------";
        //                Dt_JURNAL.Rows.Add(DR);

        //                DR = Dt_JURNAL.NewRow();
        //                DR[0] = "            ";
        //                DR[3] = Convert.ToString(DBA);
        //                DR[4] = Convert.ToString(CRA);
        //                Dt_JURNAL.Rows.Add(DR);

        //                DR = Dt_JURNAL.NewRow();
        //                DR[0] = "            ";
        //                DR[3] = "--------------------";
        //                DR[4] = "--------------------";
        //                Dt_JURNAL.Rows.Add(DR);
        //            }
        //            else
        //            {
        //                int j = 0;
        //                for (i = 0; i <= ds.Tables["GC"].Rows.Count - 1; i++)
        //                {

        //                    s = "SELECT DISTINCT V.VCHDATE, V.VOUCHER, G.LDESC, V.DBAMT, V.CRAMT FROM VCHR V,GLMST G WHERE G.GLCODE=V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE ";
        //                    s = s + "AND V.FICODE=" + comm.CurrentFicode + " AND V.GCODE=" + comm.PCURRENT_GCODE + " AND V.T_ENTRY='3' AND G.MTYPE='L' AND ";
        //                    s = s + "V.GLCODE=" + ds.Tables["GC"].Rows[i][1] + " AND V.VOUCHER=" + ds.Tables["GC"].Rows[i][0] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFormDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "'";
        //                    cmd = new SqlCommand(s, conn.mycon);
        //                    adp.SelectCommand = cmd;
        //                    adp.Fill(dsDESC, "DESC");
        //                    if (B == true)
        //                        SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[0][1]);
        //                    if (SV != Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]))
        //                    {
        //                        SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);

        //                        //=======================================================
        //                        s = "";
        //                        s = "SELECT N.NAR1 FROM NARR N WHERE N.FICODE=" + comm.CurrentFicode + " AND N.GCODE=" + comm.PCURRENT_GCODE + " AND N.T_ENTRY='3' AND N.VOUCHER=" + ds.Tables["VOU"].Rows[j][0] + " AND N.NTYPE='N'";
        //                        cmd = new SqlCommand(s, conn.mycon);
        //                        adp.SelectCommand = cmd;
        //                        adp.Fill(dsNAR, "NAR");
        //                        if (dsNAR.Tables["NAR"].Rows.Count > 0)
        //                        {
        //                            DR = Dt_JURNAL.NewRow();
        //                            DR[0] = "            ";
        //                            DR[2] = Convert.ToString(dsNAR.Tables["NAR"].Rows[0][0]);
        //                            Dt_JURNAL.Rows.Add(DR);
        //                            dsNAR.Reset();
        //                        }
        //                        dsNAR.Clear();
        //                        j = j + 1;
        //                        //========================================================


        //                        DR = Dt_JURNAL.NewRow();
        //                        DR[0] = "            ";
        //                        DR[3] = "---------------";
        //                        DR[4] = "---------------";
        //                        Dt_JURNAL.Rows.Add(DR);

        //                        DR = Dt_JURNAL.NewRow();
        //                        DR[0] = "            ";
        //                        DR[3] = Convert.ToString(DBA);
        //                        DR[4] = Convert.ToString(CRA);
        //                        Dt_JURNAL.Rows.Add(DR);

        //                        DR = Dt_JURNAL.NewRow();
        //                        DR[0] = "            ";
        //                        DR[3] = "---------------";
        //                        DR[4] = "---------------";
        //                        Dt_JURNAL.Rows.Add(DR);

        //                        CRA = 0.0;
        //                        DBA = 0.0;
        //                        B = false;
        //                        chfirst = true; ;
        //                    }
        //                    CRA = CRA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
        //                    DBA = DBA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
        //                    DR = Dt_JURNAL.NewRow();
        //                    double amt;
        //                    DateTime dd;
        //                    if (chfirst == true)
        //                    {
        //                        dd = Convert.ToDateTime(dsDESC.Tables["DESC"].Rows[i][0]);
        //                        DR[0] = dd.ToShortDateString();
        //                        DR[1] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);
        //                        chfirst = false;
        //                    }
        //                    else
        //                    {
        //                        DR[0] = "            ";
        //                    }

        //                    //dd = Convert.ToDateTime(dsDESC.Tables["DESC"].Rows[i][0]);
        //                    //DR[0] = dd.ToShortDateString();
        //                    //DR[1] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);
        //                    DR[2] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][2]);

        //                    amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
        //                    if (amt == 0)
        //                        DR[3] = "";
        //                    else
        //                        DR[3] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]));

        //                    amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
        //                    if (amt == 0)
        //                        DR[4] = "";
        //                    else
        //                        DR[4] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]));

        //                    Dt_JURNAL.Rows.Add(DR);
        //                }

        //                DR = Dt_JURNAL.NewRow();
        //                DR[0] = "            ";
        //                DR[3] = "--------------------";
        //                DR[4] = "--------------------";
        //                Dt_JURNAL.Rows.Add(DR);

        //                DR = Dt_JURNAL.NewRow();
        //                DR[0] = "    ";
        //                DR[3] = Convert.ToString(DBA);
        //                DR[4] = Convert.ToString(CRA);
        //                Dt_JURNAL.Rows.Add(DR);

        //                DR = Dt_JURNAL.NewRow();
        //                DR[0] = "            ";
        //                DR[3] = "--------------------";
        //                DR[4] = "--------------------";
        //                Dt_JURNAL.Rows.Add(DR);
        //            }
        //        }
        //        else if (radioVoucher.Checked == true)
        //        {
        //            conn.Open();
        //            s = "";
        //            if (cbNar.Checked == false)
        //            {
        //                for (i = 0; i <= ds.Tables["GC"].Rows.Count - 1; i++)
        //                {
        //                    s = "SELECT DISTINCT V.VCHDATE, V.VOUCHER, G.LDESC, V.DBAMT, V.CRAMT FROM VCHR V,GLMST G WHERE G.GLCODE=V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE ";
        //                    s = s + "AND V.FICODE=" + comm.CurrentFicode + " AND V.GCODE=" + comm.PCURRENT_GCODE + " AND V.T_ENTRY='3' AND G.MTYPE='L' AND ";
        //                    s = s + "V.GLCODE=" + ds.Tables["GC"].Rows[i][1] + " AND V.VOUCHER=" + ds.Tables["GC"].Rows[i][0] + " AND V.VOUCHER BETWEEN '" + vchno1 + "' AND '" + vchno2 + "'";

        //                    cmd = new SqlCommand(s, conn.mycon);
        //                    adp.SelectCommand = cmd;
        //                    adp.Fill(dsDESC, "DESC");
        //                    if (B == true)
        //                        SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[0][1]);
        //                    if (SV != Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]))
        //                    {
        //                        SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);

        //                        DR = Dt_JURNAL.NewRow();
        //                        DR[0] = "            ";
        //                        DR[3] = "---------------";
        //                        DR[4] = "---------------";
        //                        Dt_JURNAL.Rows.Add(DR);

        //                        DR = Dt_JURNAL.NewRow();
        //                        DR[0] = "            ";
        //                        DR[3] = Convert.ToString(DBA);
        //                        DR[4] = Convert.ToString(CRA);
        //                        Dt_JURNAL.Rows.Add(DR);

        //                        DR = Dt_JURNAL.NewRow();
        //                        DR[0] = "            ";
        //                        DR[3] = "---------------";
        //                        DR[4] = "---------------";
        //                        Dt_JURNAL.Rows.Add(DR);

        //                        CRA = 0.0;
        //                        DBA = 0.0;
        //                        B = false;
        //                        chfirst = true;
        //                    }
        //                    CRA = CRA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
        //                    DBA = DBA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
        //                    DR = Dt_JURNAL.NewRow();
        //                    double amt;
        //                    DateTime dd1;
        //                    if (chfirst == true)
        //                    {
        //                        dd1 = Convert.ToDateTime(dsDESC.Tables["DESC"].Rows[i][0]);
        //                        DR[0] = dd1.ToShortDateString();
        //                        DR[1] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);
        //                        chfirst = false;
        //                    }
        //                    else
        //                    {
        //                        DR[0] = "            ";
        //                    }
        //                    DR[2] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][2]);

        //                    amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
        //                    if (amt == 0)
        //                        DR[3] = "";
        //                    else
        //                        DR[3] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]));

        //                    amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
        //                    if (amt == 0)
        //                        DR[4] = "";
        //                    else
        //                        DR[4] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]));

        //                    Dt_JURNAL.Rows.Add(DR);
        //                }

        //                DR = Dt_JURNAL.NewRow();
        //                DR[0] = "            ";
        //                DR[3] = "--------------------";
        //                DR[4] = "--------------------";
        //                Dt_JURNAL.Rows.Add(DR);

        //                DR = Dt_JURNAL.NewRow();
        //                DR[0] = "            ";
        //                DR[3] = Convert.ToString(DBA);
        //                DR[4] = Convert.ToString(CRA);
        //                Dt_JURNAL.Rows.Add(DR);

        //                DR = Dt_JURNAL.NewRow();
        //                DR[0] = "            ";
        //                DR[3] = "--------------------";
        //                DR[4] = "--------------------";
        //                Dt_JURNAL.Rows.Add(DR);
        //            }
        //            else
        //            {
        //                int j = 0;
        //                for (i = 0; i <= ds.Tables["GC"].Rows.Count - 1; i++)
        //                {

        //                    s = "SELECT DISTINCT V.VCHDATE, V.VOUCHER, G.LDESC, V.DBAMT, V.CRAMT FROM VCHR V,GLMST G WHERE G.GLCODE=V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE ";
        //                    s = s + "AND V.FICODE=" + comm.CurrentFicode + " AND V.GCODE=" + comm.PCURRENT_GCODE + " AND V.T_ENTRY='3' AND G.MTYPE='L' AND ";
        //                    s = s + "V.GLCODE=" + ds.Tables["GC"].Rows[i][1] + " AND V.VOUCHER=" + ds.Tables["GC"].Rows[i][0] + " AND V.VOUCHER BETWEEN '" + vchno1 + "' AND '" + vchno2 + "'";
        //                    cmd = new SqlCommand(s, conn.mycon);
        //                    adp.SelectCommand = cmd;
        //                    adp.Fill(dsDESC, "DESC");
        //                    if (B == true)
        //                        SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[0][1]);
        //                    if (SV != Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]))
        //                    {
        //                        SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);

        //                        //=======================================================
        //                        s = "";
        //                        s = "SELECT N.NAR1 FROM NARR N WHERE N.FICODE=" + comm.CurrentFicode + " AND N.GCODE=" + comm.PCURRENT_GCODE + " AND N.T_ENTRY='3' AND N.VOUCHER=" + ds.Tables["VOU"].Rows[j][0] + " AND N.NTYPE='N'";
        //                        cmd = new SqlCommand(s, conn.mycon);
        //                        adp.SelectCommand = cmd;
        //                        adp.Fill(dsNAR, "NAR");
        //                        if (dsNAR.Tables["NAR"].Rows.Count > 0)
        //                        {
        //                            DR = Dt_JURNAL.NewRow();
        //                            DR[0] = "            ";
        //                            DR[2] = Convert.ToString(dsNAR.Tables["NAR"].Rows[0][0]);
        //                            Dt_JURNAL.Rows.Add(DR);
        //                            dsNAR.Reset();
        //                        }
        //                        dsNAR.Clear();
        //                        j = j + 1;
        //                        //========================================================


        //                        DR = Dt_JURNAL.NewRow();
        //                        DR[0] = "            ";
        //                        DR[3] = "---------------";
        //                        DR[4] = "---------------";
        //                        Dt_JURNAL.Rows.Add(DR);

        //                        DR = Dt_JURNAL.NewRow();
        //                        DR[0] = "            ";
        //                        DR[3] = Convert.ToString(DBA);
        //                        DR[4] = Convert.ToString(CRA);
        //                        Dt_JURNAL.Rows.Add(DR);

        //                        DR = Dt_JURNAL.NewRow();
        //                        DR[0] = "            ";
        //                        DR[3] = "---------------";
        //                        DR[4] = "---------------";
        //                        Dt_JURNAL.Rows.Add(DR);

        //                        CRA = 0.0;
        //                        DBA = 0.0;
        //                        B = false;
        //                        chfirst = true; ;
        //                    }
        //                    CRA = CRA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
        //                    DBA = DBA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
        //                    DR = Dt_JURNAL.NewRow();
        //                    double amt;
        //                    DateTime dd;
        //                    if (chfirst == true)
        //                    {
        //                        dd = Convert.ToDateTime(dsDESC.Tables["DESC"].Rows[i][0]);
        //                        DR[0] = dd.ToShortDateString();
        //                        DR[1] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);
        //                        chfirst = false;
        //                    }
        //                    else
        //                    {
        //                        DR[0] = "            ";
        //                    }

        //                    //dd = Convert.ToDateTime(dsDESC.Tables["DESC"].Rows[i][0]);
        //                    //DR[0] = dd.ToShortDateString();
        //                    //DR[1] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);
        //                    DR[2] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][2]);

        //                    amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
        //                    if (amt == 0)
        //                        DR[3] = "";
        //                    else
        //                        DR[3] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]));

        //                    amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
        //                    if (amt == 0)
        //                        DR[4] = "";
        //                    else
        //                        DR[4] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]));

        //                    Dt_JURNAL.Rows.Add(DR);
        //                }

        //                DR = Dt_JURNAL.NewRow();
        //                DR[0] = "            ";
        //                DR[3] = "--------------------";
        //                DR[4] = "--------------------";
        //                Dt_JURNAL.Rows.Add(DR);

        //                DR = Dt_JURNAL.NewRow();
        //                DR[0] = "    ";
        //                DR[3] = Convert.ToString(DBA);
        //                DR[4] = Convert.ToString(CRA);
        //                Dt_JURNAL.Rows.Add(DR);

        //                DR = Dt_JURNAL.NewRow();
        //                DR[0] = "            ";
        //                DR[3] = "--------------------";
        //                DR[4] = "--------------------";
        //                Dt_JURNAL.Rows.Add(DR);
        //            }
        //        }
               
        //    }
        //    catch { }
        //}
        public void RequiredDataSet()
        {
            try
            {
                int j = 0;
                Boolean B = true;
                Boolean chfirst = true;
                double CRA = 0.0, DBA = 0.0;
                // if(Dt_JURNAL.Columns==null)
                Dt_JURNAL.Columns.Clear();

                Dt_JURNAL.Columns.Add(DC_VDATE);
                Dt_JURNAL.Columns.Add(DC_VNO);
                Dt_JURNAL.Columns.Add(DC_LDESC);
                Dt_JURNAL.Columns.Add(DC_DB);
                Dt_JURNAL.Columns.Add(DC_CR);

                if (radioPeriod.Checked == true)
                {
                    conn.Open();
                    s = "";
                    if (cbNar.Checked == false)
                    {
                        for (i = 0; i <= ds.Tables["GC"].Rows.Count - 1; i++)
                        {
                            // s = "SELECT DISTINCT V.VCHDATE, V.VOUCHER, G.LDESC, V.DBAMT, V.CRAMT FROM VCHR V,GLMST G WHERE G.GLCODE=V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE ";
                            s = "SELECT DISTINCT V.VCHDATE, V.USER_VCH, G.LDESC, V.DBAMT, V.CRAMT FROM VCHR V,GLMST G WHERE G.GLCODE=V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE ";
                            s = s + "AND V.FICODE=" + comm.CurrentFicode + " AND V.GCODE=" + comm.PCURRENT_GCODE + " AND V.T_ENTRY='3' AND G.MTYPE='L' AND ";
                            s = s + "V.GLCODE=" + ds.Tables["GC"].Rows[i][1] + " AND V.VOUCHER=" + ds.Tables["GC"].Rows[i][0] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFormDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "'";

                            cmd = new SqlCommand(s, conn.mycon);
                            adp.SelectCommand = cmd;
                            adp.Fill(dsDESC, "DESC");
                            if (B == true)
                                SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[0][1]);
                            if (SV != Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]))
                            {
                                SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);

                                DR = Dt_JURNAL.NewRow();
                                DR[0] = "            ";
                                DR[3] = "---------------------------------------";
                                DR[4] = "---------------------------------------";
                                Dt_JURNAL.Rows.Add(DR);

                                DR = Dt_JURNAL.NewRow();
                                DR[0] = "            ";
                                DR[3] = Convert.ToString(DBA);
                                DR[4] = Convert.ToString(CRA);
                                Dt_JURNAL.Rows.Add(DR);

                                DR = Dt_JURNAL.NewRow();
                                DR[0] = "            ";
                                DR[3] = "===================";
                                DR[4] = "===================";
                                Dt_JURNAL.Rows.Add(DR);

                                CRA = 0.0;
                                DBA = 0.0;
                                B = false;
                                chfirst = true;
                            }
                            CRA = CRA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
                            DBA = DBA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
                            DR = Dt_JURNAL.NewRow();
                            double amt;
                            DateTime dd1;
                            if (chfirst == true)
                            {
                                dd1 = Convert.ToDateTime(dsDESC.Tables["DESC"].Rows[i][0]);
                                DR[0] = dd1.ToShortDateString();
                                DR[1] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);
                                chfirst = false;
                            }
                            else
                            {
                                DR[0] = "            ";
                            }
                            DR[2] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][2]);

                            amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
                            if (amt == 0)
                                DR[3] = "";
                            else
                                DR[3] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]));

                            amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
                            if (amt == 0)
                                DR[4] = "";
                            else
                                DR[4] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]));

                            Dt_JURNAL.Rows.Add(DR);
                        }

                        DR = Dt_JURNAL.NewRow();
                        DR[0] = "            ";
                        DR[3] = "---------------------------------------";
                        DR[4] = "---------------------------------------";
                        Dt_JURNAL.Rows.Add(DR);

                        DR = Dt_JURNAL.NewRow();
                        DR[0] = "            ";
                        DR[3] = Convert.ToString(DBA);
                        DR[4] = Convert.ToString(CRA);
                        Dt_JURNAL.Rows.Add(DR);

                        DR = Dt_JURNAL.NewRow();
                        DR[0] = "            ";
                        DR[3] = "===================";
                        DR[4] = "===================";
                        Dt_JURNAL.Rows.Add(DR);
                    }
                    else
                    {
                        // int j = 0;
                        for (i = 0; i <= ds.Tables["GC"].Rows.Count - 1; i++)
                        {

                            //s = "SELECT DISTINCT V.VCHDATE, V.VOUCHER, G.LDESC, V.DBAMT, V.CRAMT FROM VCHR V,GLMST G WHERE G.GLCODE=V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE ";
                            s = "SELECT DISTINCT V.VCHDATE, V.USER_VCH, G.LDESC, V.DBAMT, V.CRAMT FROM VCHR V,GLMST G WHERE G.GLCODE=V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE ";
                            s = s + "AND V.FICODE=" + comm.CurrentFicode + " AND V.GCODE=" + comm.PCURRENT_GCODE + " AND V.T_ENTRY='3' AND G.MTYPE='L' AND ";
                            s = s + "V.GLCODE=" + ds.Tables["GC"].Rows[i][1] + " AND V.VOUCHER=" + ds.Tables["GC"].Rows[i][0] + " AND V.VCHDATE BETWEEN '" + edpcom.getSqlDateStr(dtpFormDate.Value) + "' AND '" + edpcom.getSqlDateStr(dtpToDate.Value) + "'";
                            cmd = new SqlCommand(s, conn.mycon);
                            adp.SelectCommand = cmd;
                            adp.Fill(dsDESC, "DESC");
                            if (B == true)
                                SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[0][1]);
                            if (SV != Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]))
                            {
                                SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);

                                //=======================================================
                                s = "";
                                s = "SELECT N.NAR1 FROM NARR N WHERE N.FICODE=" + comm.CurrentFicode + " AND N.GCODE=" + comm.PCURRENT_GCODE + " AND N.T_ENTRY='3' AND N.VOUCHER=" + ds.Tables["VOU"].Rows[j][0] + " AND N.NTYPE='N'";
                                cmd = new SqlCommand(s, conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(dsNAR, "NAR");
                                if (dsNAR.Tables["NAR"].Rows.Count > 0)
                                {
                                    DR = Dt_JURNAL.NewRow();
                                    DR[0] = "            ";
                                    DR[2] = Convert.ToString(dsNAR.Tables["NAR"].Rows[0][0]);
                                    Dt_JURNAL.Rows.Add(DR);
                                    dsNAR.Reset();
                                }
                                dsNAR.Clear();
                                j = j + 1;
                                //========================================================


                                DR = Dt_JURNAL.NewRow();
                                DR[0] = "            ";
                                DR[3] = "---------------------------------------";
                                DR[4] = "---------------------------------------";
                                Dt_JURNAL.Rows.Add(DR);

                                DR = Dt_JURNAL.NewRow();
                                DR[0] = "            ";
                                DR[3] = Convert.ToString(DBA);
                                DR[4] = Convert.ToString(CRA);
                                Dt_JURNAL.Rows.Add(DR);

                                DR = Dt_JURNAL.NewRow();
                                DR[0] = "            ";
                                DR[3] = "===================";
                                DR[4] = "===================";
                                Dt_JURNAL.Rows.Add(DR);

                                CRA = 0.0;
                                DBA = 0.0;
                                B = false;
                                chfirst = true; ;
                            }
                            CRA = CRA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
                            DBA = DBA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
                            DR = Dt_JURNAL.NewRow();
                            double amt;
                            DateTime dd;
                            if (chfirst == true)
                            {
                                dd = Convert.ToDateTime(dsDESC.Tables["DESC"].Rows[i][0]);
                                DR[0] = dd.ToShortDateString();
                                DR[1] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);
                                chfirst = false;
                            }
                            else
                            {
                                DR[0] = "            ";
                            }

                            //dd = Convert.ToDateTime(dsDESC.Tables["DESC"].Rows[i][0]);
                            //DR[0] = dd.ToShortDateString();
                            //DR[1] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);
                            DR[2] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][2]);

                            amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
                            if (amt == 0)
                                DR[3] = "";
                            else
                                DR[3] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]));

                            amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
                            if (amt == 0)
                                DR[4] = "";
                            else
                                DR[4] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]));

                            Dt_JURNAL.Rows.Add(DR);
                        }
                        s = "";
                        s = "SELECT N.NAR1 FROM NARR N WHERE N.FICODE=" + comm.CurrentFicode + " AND N.GCODE=" + comm.PCURRENT_GCODE + " AND N.T_ENTRY='3' AND N.VOUCHER=" + ds.Tables["VOU"].Rows[j][0] + " AND N.NTYPE='N'";
                        cmd = new SqlCommand(s, conn.mycon);
                        adp.SelectCommand = cmd;
                        adp.Fill(dsNAR, "NAR");
                        if (dsNAR.Tables["NAR"].Rows.Count > 0)
                        {
                            DR = Dt_JURNAL.NewRow();
                            DR[0] = "            ";
                            DR[2] = Convert.ToString(dsNAR.Tables["NAR"].Rows[0][0]);
                            Dt_JURNAL.Rows.Add(DR);
                            dsNAR.Reset();
                        }
                        DR = Dt_JURNAL.NewRow();
                        DR[0] = "            ";
                        DR[3] = "---------------------------------------";
                        DR[4] = "---------------------------------------";
                        Dt_JURNAL.Rows.Add(DR);

                        DR = Dt_JURNAL.NewRow();
                        DR[0] = "    ";
                        DR[3] = Convert.ToString(DBA);
                        DR[4] = Convert.ToString(CRA);
                        Dt_JURNAL.Rows.Add(DR);

                        DR = Dt_JURNAL.NewRow();
                        DR[0] = "            ";
                        DR[3] = "===================";
                        DR[4] = "===================";
                        Dt_JURNAL.Rows.Add(DR);
                    }
                }
                else if (radioVoucher.Checked == true)
                {
                    if ((comboDialog1.Text != "") && (comboDialog2.Text != ""))
                    {
                        conn.Open();
                        s = "";
                        if (cbNar.Checked == false)
                        {
                            for (i = 0; i <= ds.Tables["GC"].Rows.Count - 1; i++)
                            {

                                //s = "SELECT DISTINCT V.VCHDATE, V.VOUCHER, G.LDESC, V.DBAMT, V.CRAMT FROM VCHR V,GLMST G WHERE G.GLCODE=V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE ";
                                s = "SELECT DISTINCT V.VCHDATE, V.USER_VCH, G.LDESC, V.DBAMT, V.CRAMT FROM VCHR V,GLMST G WHERE G.GLCODE=V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE ";
                                s = s + "AND V.FICODE=" + comm.CurrentFicode + " AND V.GCODE=" + comm.PCURRENT_GCODE + " AND V.T_ENTRY='3' AND G.MTYPE='L' AND ";
                                s = s + "V.GLCODE=" + ds.Tables["GC"].Rows[i][1] + " AND V.VOUCHER=" + ds.Tables["GC"].Rows[i][0] + " AND V.VOUCHER BETWEEN '" + vchno1 + "' AND '" + vchno2 + "'";

                                cmd = new SqlCommand(s, conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(dsDESC, "DESC");
                                if (B == true)
                                    SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[0][1]);
                                if (SV != Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]))
                                {
                                    SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);

                                    DR = Dt_JURNAL.NewRow();
                                    DR[0] = "            ";
                                    DR[3] = "---------------------------------------";
                                    DR[4] = "---------------------------------------";
                                    Dt_JURNAL.Rows.Add(DR);

                                    DR = Dt_JURNAL.NewRow();
                                    DR[0] = "            ";
                                    DR[3] = Convert.ToString(DBA);
                                    DR[4] = Convert.ToString(CRA);
                                    Dt_JURNAL.Rows.Add(DR);

                                    DR = Dt_JURNAL.NewRow();
                                    DR[0] = "            ";
                                    DR[3] = "===================";
                                    DR[4] = "===================";
                                    Dt_JURNAL.Rows.Add(DR);

                                    CRA = 0.0;
                                    DBA = 0.0;
                                    B = false;
                                    chfirst = true;
                                }
                                CRA = CRA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
                                DBA = DBA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
                                DR = Dt_JURNAL.NewRow();
                                double amt;
                                DateTime dd1;
                                if (chfirst == true)
                                {
                                    dd1 = Convert.ToDateTime(dsDESC.Tables["DESC"].Rows[i][0]);
                                    DR[0] = dd1.ToShortDateString();
                                    DR[1] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);
                                    chfirst = false;
                                }
                                else
                                {
                                    DR[0] = "            ";
                                }
                                DR[2] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][2]);

                                amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
                                if (amt == 0)
                                    DR[3] = "";
                                else
                                    DR[3] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]));

                                amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
                                if (amt == 0)
                                    DR[4] = "";
                                else
                                    DR[4] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]));

                                Dt_JURNAL.Rows.Add(DR);
                            }

                            DR = Dt_JURNAL.NewRow();
                            DR[0] = "            ";
                            DR[3] = "---------------------------------------";
                            DR[4] = "---------------------------------------";
                            Dt_JURNAL.Rows.Add(DR);

                            DR = Dt_JURNAL.NewRow();
                            DR[0] = "            ";
                            DR[3] = Convert.ToString(DBA);
                            DR[4] = Convert.ToString(CRA);
                            Dt_JURNAL.Rows.Add(DR);

                            DR = Dt_JURNAL.NewRow();
                            DR[0] = "            ";
                            DR[3] = "===================";
                            DR[4] = "===================";
                            Dt_JURNAL.Rows.Add(DR);
                        }
                        else
                        {
                            // int j = 0;
                            for (i = 0; i <= ds.Tables["GC"].Rows.Count - 1; i++)
                            {

                                //s = "SELECT DISTINCT V.VCHDATE, V.VOUCHER, G.LDESC, V.DBAMT, V.CRAMT FROM VCHR V,GLMST G WHERE G.GLCODE=V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE ";
                                s = "SELECT DISTINCT V.VCHDATE, V.USER_VCH, G.LDESC, V.DBAMT, V.CRAMT FROM VCHR V,GLMST G WHERE G.GLCODE=V.GLCODE AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE ";
                                s = s + "AND V.FICODE=" + comm.CurrentFicode + " AND V.GCODE=" + comm.PCURRENT_GCODE + " AND V.T_ENTRY='3' AND G.MTYPE='L' AND ";
                                s = s + "V.GLCODE=" + ds.Tables["GC"].Rows[i][1] + " AND V.VOUCHER=" + ds.Tables["GC"].Rows[i][0] + " AND V.VOUCHER BETWEEN '" + vchno1 + "' AND '" + vchno2 + "'";
                                cmd = new SqlCommand(s, conn.mycon);
                                adp.SelectCommand = cmd;
                                adp.Fill(dsDESC, "DESC");
                                if (B == true)
                                    SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[0][1]);
                                if (SV != Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]))
                                {
                                    SV = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);

                                    //=======================================================
                                    s = "";
                                    s = "SELECT N.NAR1 FROM NARR N WHERE N.FICODE=" + comm.CurrentFicode + " AND N.GCODE=" + comm.PCURRENT_GCODE + " AND N.T_ENTRY='3' AND N.VOUCHER=" + ds.Tables["VOU"].Rows[j][0] + " AND N.NTYPE='N'";
                                    cmd = new SqlCommand(s, conn.mycon);
                                    adp.SelectCommand = cmd;
                                    adp.Fill(dsNAR, "NAR");
                                    if (dsNAR.Tables["NAR"].Rows.Count > 0)
                                    {
                                        DR = Dt_JURNAL.NewRow();
                                        DR[0] = "            ";
                                        DR[2] = Convert.ToString(dsNAR.Tables["NAR"].Rows[0][0]);
                                        Dt_JURNAL.Rows.Add(DR);
                                        dsNAR.Reset();
                                    }
                                    dsNAR.Clear();
                                    j = j + 1;
                                    //========================================================


                                    DR = Dt_JURNAL.NewRow();
                                    DR[0] = "            ";
                                    DR[3] = "---------------------------------------";
                                    DR[4] = "---------------------------------------";
                                    Dt_JURNAL.Rows.Add(DR);

                                    DR = Dt_JURNAL.NewRow();
                                    DR[0] = "            ";
                                    DR[3] = Convert.ToString(DBA);
                                    DR[4] = Convert.ToString(CRA);
                                    Dt_JURNAL.Rows.Add(DR);

                                    DR = Dt_JURNAL.NewRow();
                                    DR[0] = "            ";
                                    DR[3] = "===================";
                                    DR[4] = "===================";
                                    Dt_JURNAL.Rows.Add(DR);

                                    CRA = 0.0;
                                    DBA = 0.0;
                                    B = false;
                                    chfirst = true; ;
                                }
                                CRA = CRA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
                                DBA = DBA + Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
                                DR = Dt_JURNAL.NewRow();
                                double amt;
                                DateTime dd;
                                if (chfirst == true)
                                {
                                    dd = Convert.ToDateTime(dsDESC.Tables["DESC"].Rows[i][0]);
                                    DR[0] = dd.ToShortDateString();
                                    DR[1] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);
                                    chfirst = false;
                                }
                                else
                                {
                                    DR[0] = "            ";
                                }

                                //dd = Convert.ToDateTime(dsDESC.Tables["DESC"].Rows[i][0]);
                                //DR[0] = dd.ToShortDateString();
                                //DR[1] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][1]);
                                DR[2] = Convert.ToString(dsDESC.Tables["DESC"].Rows[i][2]);

                                amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]);
                                if (amt == 0)
                                    DR[3] = "";
                                else
                                    DR[3] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][3]));

                                amt = Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]);
                                if (amt == 0)
                                    DR[4] = "";
                                else
                                    DR[4] = Convert.ToString(Convert.ToDouble(dsDESC.Tables["DESC"].Rows[i][4]));

                                Dt_JURNAL.Rows.Add(DR);
                            }
                            s = "";
                            s = "SELECT N.NAR1 FROM NARR N WHERE N.FICODE=" + comm.CurrentFicode + " AND N.GCODE=" + comm.PCURRENT_GCODE + " AND N.T_ENTRY='3' AND N.VOUCHER=" + ds.Tables["VOU"].Rows[j][0] + " AND N.NTYPE='N'";
                            cmd = new SqlCommand(s, conn.mycon);
                            adp.SelectCommand = cmd;
                            adp.Fill(dsNAR, "NAR");
                            if (dsNAR.Tables["NAR"].Rows.Count > 0)
                            {
                                DR = Dt_JURNAL.NewRow();
                                DR[0] = "            ";
                                DR[2] = Convert.ToString(dsNAR.Tables["NAR"].Rows[0][0]);
                                Dt_JURNAL.Rows.Add(DR);
                                dsNAR.Reset();
                            }
                            dsNAR.Clear();
                            DR = Dt_JURNAL.NewRow();
                            DR[0] = "            ";
                            DR[3] = "---------------------------------------";
                            DR[4] = "---------------------------------------";
                            Dt_JURNAL.Rows.Add(DR);

                            DR = Dt_JURNAL.NewRow();
                            DR[0] = "    ";
                            DR[3] = Convert.ToString(DBA);
                            DR[4] = Convert.ToString(CRA);
                            Dt_JURNAL.Rows.Add(DR);

                            DR = Dt_JURNAL.NewRow();
                            DR[0] = "            ";
                            DR[3] = "===================";
                            DR[4] = "===================";
                            Dt_JURNAL.Rows.Add(DR);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Required field is not set properly!");
                    }
                }


            }
            catch { }
        }
        private void lbl_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptJurnal_Load(object sender, EventArgs e)
        {
            dtpFormDate.Value = comm.CURRCO_SDT;
            dtpToDate.Value = comm.CURRCO_EDT;
            radioPeriod.Checked = true;
        }

        private void lbl_Minz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comboDialog1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DtForm = new DataTable();
                DataColumn DC_uvn = new DataColumn("Voucher No.");
                DataColumn DC_vn = new DataColumn("Voucher Code");
                DataSet DSFORM = new DataSet();
                int c;
                DtForm.Columns.Add(DC_uvn);
                DtForm.Columns.Add(DC_vn);
                if (DSFORM.Tables["FVCH"] != null)
                {
                    DSFORM.Tables["FVCH"].Clear();
                }
                conn.Open();
                cmd = new SqlCommand("SELECT DISTINCT USER_VCH,VOUCHER FROM VCHR WHERE FICODE=" + comm.CurrentFicode + " AND GCODE=" + comm.PCURRENT_GCODE + " AND T_ENTRY='3'", conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(DSFORM, "FVCH");
                conn.Close();
                for (c = 0; c <= DSFORM.Tables["FVCH"].Rows.Count - 1; c++)
                {
                    DataRow DRVCH;
                    DRVCH = DtForm.NewRow();
                    DRVCH[0] = Convert.ToString(DSFORM.Tables["FVCH"].Rows[c][0]);
                    DRVCH[1] = Convert.ToString(DSFORM.Tables["FVCH"].Rows[c][1]);
                    DtForm.Rows.Add(DRVCH);
                }
                comboDialog1.Heading = "Select Jurnal Ledger A/C";
                comboDialog1.LookUpTable = DtForm;
                comboDialog1.ReturnIndex = 1;
                //t1.Text = comboDialog1.ReturnValue;
                comboDialog1.Connection = conn.mycon;
            }
            catch { }
        }

        private void comboDialog1_CloseUp(object sender, EventArgs e)
        {
            try
            {
                if ((comboDialog1.ReturnValue != null) && (comboDialog1.ReturnValue != ""))
                    vchno1 = Convert.ToInt64(comboDialog1.ReturnValue);
            }
            catch { }
        }

        private void comboDialog2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DtForm = new DataTable();
                DataColumn DC_uvn = new DataColumn("Voucher No.");
                DataColumn DC_vn = new DataColumn("Voucher Code");
                DataSet DSFORM = new DataSet();
                int c;
                DtForm.Columns.Add(DC_uvn);
                DtForm.Columns.Add(DC_vn);
                if (DSFORM.Tables["FVCH"] != null)
                {
                    DSFORM.Tables["FVCH"].Clear();
                }
                conn.Open();
                cmd = new SqlCommand("SELECT DISTINCT USER_VCH,VOUCHER FROM VCHR WHERE FICODE=" + comm.CurrentFicode + " AND GCODE=" + comm.PCURRENT_GCODE + " AND T_ENTRY='3'", conn.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(DSFORM, "FVCH");
                conn.Close();
                for (c = 0; c <= DSFORM.Tables["FVCH"].Rows.Count - 1; c++)
                {
                    DataRow DRVCH;
                    DRVCH = DtForm.NewRow();
                    DRVCH[0] = Convert.ToString(DSFORM.Tables["FVCH"].Rows[c][0]);
                    DRVCH[1] = Convert.ToString(DSFORM.Tables["FVCH"].Rows[c][1]);
                    DtForm.Rows.Add(DRVCH);
                }
                comboDialog2.Heading = "Select Jurnal Ledger A/C";
                comboDialog2.LookUpTable = DtForm;
                comboDialog2.ReturnIndex = 1;
                //t1.Text = comboDialog1.ReturnValue;
                comboDialog2.Connection = conn.mycon;
            }
            catch { }
        }

        private void comboDialog2_CloseUp(object sender, EventArgs e)
        {
            try
            {
                if ((comboDialog2.ReturnValue!=null) && (comboDialog2.ReturnValue!=""))
                    vchno2 = Convert.ToInt64(comboDialog2.ReturnValue);
            }
            catch { }
        }

        private void radioPeriod_Click(object sender, EventArgs e)
        {
            comboDialog1.Enabled = false;
            comboDialog2.Enabled = false;
            dtpFormDate.Enabled = true;
            dtpToDate.Enabled = true;

        }

        private void radioVoucher_Click(object sender, EventArgs e)
        {
            dtpFormDate.Enabled = false;
            dtpToDate.Enabled = false;
            comboDialog1.Enabled = true;
            comboDialog2.Enabled = true;
            //comboDialog1.ReadOnly = true;
            //comboDialog2.ReadOnly = true;
        }

       
       
    }
}