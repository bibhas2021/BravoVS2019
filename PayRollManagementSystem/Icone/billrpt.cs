using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Edpcom;
using System.Collections;
using Microsoft.VisualBasic;
using Investment_Report;
using EDPComponent;
using EDPMessageBox;

namespace AccordFour
{
    public partial class billrpt : FormBase
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        DataTable billing = new DataTable();
        DataSet dsBRANCH = new DataSet();
        DataTable de = new DataTable();
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter();
        int AID, CHK, partycode, Conparty;
        SqlCommand cmd;
        string tentry = "", FinalAmount = "",Refvoucher="";
        string current_company = "", address = "", address1 = "", pan = "", DURATION = "", TinNo1 = "";
        string company = "", Agentadd = "", Agentadd1="", phone = "", Area = "", BillDate = "", User_Voucher = "";
        string challan = "", challandt = "", AmtWord = "";        
        string conName = "", ConAdd1 = "", Conadd2 = "";

        public billrpt()
        {
            InitializeComponent();
        }
        public void Get(string Page)
        {
            tentry = Page;
        }
        public void voucher(string vch,string Tentry,int vouno)
        {
            txtto.Text = vch;
            txtfrom.Text = vch;
            tentry = Tentry;
            AID = vouno;
        }

        public void getrec(string uv, int ck)
        {
            txtto.Text = uv;
            CHK = ck;
            txtto.Enabled = false;
            txtfrom.Enabled = false;
            RunData();
        }

        public void RunData()
        {
            try
            {
                txtfrom.Text = txtto.Text;
                bill();
            }
            catch { }
        }

        private void txtto_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            txtfrom.Text = txtto.Text;
            try
            {
                //RunData();
                //if (txtto.ReturnValue != "")
                //    AID = Convert.ToInt32(txtto.ReturnValue);
                //else AID = 0;                
            }
            catch { }
        }

        private void txtto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtto.PopUp(sender, new EventArgs());
            }
        }

        private void billrpt_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            this.HeaderText = "Bill Report";
            if (CHK != 1)
                LoadDataTable();
        }

        private void LoadDataTable()
        {
            if(tentry=="9")
            this.HeaderText = "BILL";
            else if(tentry=="n")
            this.HeaderText = "Challan";
            else
            this.HeaderText = "Stock Out";

            billing.Columns.Add("sl", typeof(string));
            billing.Columns.Add("Particular", typeof(string));
            billing.Columns.Add("Quentity", typeof(string));
            billing.Columns.Add("Rate", typeof(string));
            billing.Columns.Add("StdDis", typeof(string));
            billing.Columns.Add("ExtraDis", typeof(string));
            billing.Columns.Add("SpecialDis", typeof(string));
            billing.Columns.Add("Amount", typeof(string));
            billing.Columns.Add("units", typeof(string));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void bill()
        {
            if (CHK == 1)
                LoadDataTable();
            int Baseper = 0;
            billing.Clear();
            string sq1 = null;
            string sq11 = null;
            int dgrowcou, s;
            int sl = 1;
            float TQuenty, Tstddis, TExtraDis, TSpecialDis, TAmount, NTAmount;
            double NAmount;
            try
            {
                TQuenty = 0; Tstddis = 0; TExtraDis = 0; TSpecialDis = 0; TAmount = 0; NAmount = 0; NTAmount = 0;
                //sq1 = "select distinct bo.book_name,it.qty,it.rate,it.StdDis,it.ExtraDis,it.SpecialDis,it.amt,it.units,it.FreeCopy from book_master bo , itran it,idata id where it.ficode='" + edpcom.CurrentFicode + "' and it.gcode='" + edpcom.PCURRENT_GCODE + "' and bo.ficode = it.ficode and bo.gcode = it.gcode and it.pcode = bo.book_id and id.ficode = it.ficode and id.gcode=bo.gcode and id.voucher =it.voucher and it.t_entry = id.t_entry and it.t_entry ='" + tentry + "' and id.user_vch = '" + txtto.Text + "' ";
                //sq1 = "select distinct IG.PALIAS,it.BaseQty,it.rate,it.DIS_AMT,it.amt,IG.PDESC,It.Size,id.Party_Code,it.pcode,it.voucher,it.Volume,id.Party_code,id.USER_VCH,id.VCH_DATE,it.ucode,it.qty,it.RefPCODE from Iglmst IG , itran it,idata id where it.ficode='" + edpcom.CurrentFicode + "' and it.gcode='" + edpcom.PCURRENT_GCODE + "' and IG.ficode = it.ficode and IG.gcode = it.gcode and it.pcode = IG.pcode and id.ficode = it.ficode and id.gcode=IG.gcode and id.voucher =it.voucher and it.t_entry = id.t_entry and it.t_entry ='9' and id.user_vch = '" + txtto.Text + "' and it.RefPCODE ="+dt.rows[i][1]+" ";
                if (tentry == "9" || tentry == "n")
                {
                    sq1 = "select distinct IG.PDESC,it.RefPCODE,it.RefPCODE,it.RefPCODE,id.party_code,id.vch_date,id.user_vch,id.voucher,it.RefPCODE,it.RefUcode ,it.RefPCODE,it.REF_VOUCHER,id.ReffpartyCode from Iglmst IG , itran it,idata id where it.ficode='" + edpcom.CurrentFicode + "' and it.gcode='" + edpcom.PCURRENT_GCODE + "' and IG.ficode = it.ficode and IG.gcode = it.gcode and it.RefPCODE = IG.pcode and id.ficode = it.ficode and id.gcode=IG.gcode and id.voucher =it.voucher and it.t_entry = id.t_entry and it.t_entry ='" + tentry + "' and id.user_vch = '" + txtto.Text + "'  ";
                    de = RunQDTbl(sq1);
                    TQuenty = 0; Tstddis = 0; TExtraDis = 0; TSpecialDis = 0; TAmount = 0; NAmount = 0; NTAmount = 0;
                    for (int i = 0; i <= de.Rows.Count - 1; i++)
                    {
                        BillDate = Convert.ToDateTime(de.Rows[0][5]).ToShortDateString();
                        Conparty =Convert.ToInt32(de.Rows[i][12]);
                        partycode = Convert.ToInt32(de.Rows[0][4]);
                        if (i > 0)
                            billing.Rows.Add();
                        string Baseunit = "";
                        if (Information.IsNumeric(de.Rows[i][9]) == true)
                        {
                            string sq3 = "select UDESC from UNIT where UCODE=" + de.Rows[i][9] + " ";
                            DataTable dt1 = RunQDTbl(sq3);
                            if (dt1.Rows.Count > 0)
                                Baseunit = dt1.Rows[0][0].ToString();

                        }
                        dgrowcou = Convert.ToInt32(billing.Rows.Count);
                        billing.Rows.Add();
                        string sq7 = "select distinct IG.PDESC,it.RefSize,it.RefVolume,it.refqty,it.RefUcode,it.Volume,it.ITEMNO from Iglmst IG , itran it,idata id where it.ficode='" + edpcom.CurrentFicode + "' and it.gcode='" + edpcom.PCURRENT_GCODE + "' and IG.ficode = it.ficode and IG.gcode = it.gcode and it.PCODE = IG.pcode and id.ficode = it.ficode and id.gcode=IG.gcode and id.voucher =it.voucher and it.t_entry = id.t_entry and it.t_entry ='" + tentry + "' and id.user_vch = '" + txtto.Text + "' and it.RefPCODE=" + de.Rows[i][1] + " and ig.SERVICE=1 and ig.AmtCalOnVolume=1 order by it.ITEMNO";
                        DataTable de1 = RunQDTbl(sq7);
                        if (tentry == "n")
                        {
                            billing.Rows[Convert.ToInt32(dgrowcou)][2] = de1.Rows[0][3] + " " + Baseunit;
                            billing.Rows[Convert.ToInt32(dgrowcou)][1] = de.Rows[i][0].ToString();
                            if(de1.Rows.Count>0)
                            billing.Rows[Convert.ToInt32(dgrowcou)][5] = de1.Rows[0][2];
                            Refvoucher = de.Rows[i][11].ToString();
                        }
                        else
                        {
                            billing.Rows[Convert.ToInt32(dgrowcou)][5] = de.Rows[i][0].ToString();
                            if (de1.Rows.Count > 0)
                            {
                                billing.Rows[Convert.ToInt32(dgrowcou)][0] = de1.Rows[0][3];                               
                                dgrowcou = Convert.ToInt32(billing.Rows.Count);
                                billing.Rows.Add();
                                billing.Rows[Convert.ToInt32(dgrowcou)][5] = "Size : " + de1.Rows[0][1] + ", Volume : " + de1.Rows[0][2];
                            }
                            billing.Rows[Convert.ToInt32(dgrowcou)][0] = Baseunit;                           
                        }
                        if (tentry == "9")
                        {
                            dt.Rows.Clear();
                            string sq2 = "select distinct IG.PALIAS,it.BaseQty,it.rate,it.DIS_AMT,it.amt,IG.PDESC,It.Size,id.Party_Code,it.pcode,it.voucher,it.Volume,id.Party_code,id.USER_VCH,id.VCH_DATE,it.ucode,it.qty,it.RefPCODE,ig.AmtBasePercent,it.useries,id.ReffpartyCode,it.REF_VOUCHER,it.ITEMNO  from Iglmst IG , itran it,idata id where it.ficode='" + edpcom.CurrentFicode + "' and it.gcode='" + edpcom.PCURRENT_GCODE + "' and IG.ficode = it.ficode and IG.gcode = it.gcode and it.pcode = IG.pcode and id.ficode = it.ficode and id.gcode=IG.gcode and id.voucher =it.voucher and it.t_entry = id.t_entry and it.t_entry ='" + tentry + "' and id.user_vch = '" + txtto.Text + "' and it.RefPCODE =" + de.Rows[i][1] + " order by it.ITEMNO";
                            dt = RunQDTbl(sq2);
                            for (int j = 0; j <= dt.Rows.Count - 1; j++)
                            {
                                Refvoucher = dt.Rows[0][20].ToString();
                                partycode = Convert.ToInt32(dt.Rows[0][7]);
                                string unit = "";
                                if (Information.IsNumeric(dt.Rows[j][14]) == true)
                                {
                                    string sq3 = "select UDESC from UNIT where UCODE=" + dt.Rows[j][14] + " ";
                                    DataTable dt1 = RunQDTbl(sq3);
                                    unit = dt1.Rows[0][0].ToString();
                                }
                                dgrowcou = Convert.ToInt32(billing.Rows.Count);
                                billing.Rows.Add();
                                billing.Rows[Convert.ToInt32(dgrowcou)][1] = dt.Rows[j][5].ToString();
                                billing.Rows[Convert.ToInt32(dgrowcou)][2] = dt.Rows[j][15] + " " + unit;
                                if (Information.IsNumeric(dt.Rows[j][2]) == true)
                                    if (Convert.ToDouble(dt.Rows[j][2]) != 0)
                                        billing.Rows[Convert.ToInt32(dgrowcou)][3] = dt.Rows[j][2];
                                    else
                                        billing.Rows[Convert.ToInt32(dgrowcou)][3] = "";
                                else
                                    billing.Rows[Convert.ToInt32(dgrowcou)][3] = "";
                                //billing.Rows[Convert.ToInt32(dgrowcou)][4] = dt.Rows[j][4];
                                if (Information.IsNumeric(dt.Rows[j][4]) == true)
                                    if (Convert.ToDouble(dt.Rows[j][4]) != 0)
                                        billing.Rows[Convert.ToInt32(dgrowcou)][4] = dt.Rows[j][4];
                                    else
                                        billing.Rows[Convert.ToInt32(dgrowcou)][4] = "";
                                else
                                    billing.Rows[Convert.ToInt32(dgrowcou)][4] = "";
                                billing.Rows[Convert.ToInt32(dgrowcou)][8] = unit;
                                if (unit.ToUpper() == "LOT")
                                {
                                    unit = "";
                                    string sq3 = "select UDESC from UNIT where UCODE=" + de.Rows[i][9] + " ";
                                    DataTable dt1 = RunQDTbl(sq3);
                                    unit = dt1.Rows[0][0].ToString();
                                    billing.Rows[Convert.ToInt32(dgrowcou)][2] = de.Rows[i][8] + " " + unit;
                                }
                                if (unit == "NIL")
                                {
                                    billing.Rows[Convert.ToInt32(dgrowcou)][8] = "";
                                    billing.Rows[Convert.ToInt32(dgrowcou)][2] = "";
                                    billing.Rows[Convert.ToInt32(dgrowcou)][3] = " ";
                                }
                                unit = "";
                                if (Convert.ToInt32(dt.Rows[j][17]) > 0)
                                    Baseper = Convert.ToInt32(dt.Rows[j][17]);
                                float Amount = 0;
                                if (Information.IsNumeric(billing.Rows[dgrowcou][4]) == true)
                                    Amount = Convert.ToSingle(billing.Rows[dgrowcou][4]);                               
                                TAmount = TAmount + Amount;
                                dgrowcou++;
                                sl++;
                            }
                        }
                    }
                   
                }
                if (de.Rows.Count == 0)
                {
                    dt.Rows.Clear();
                    string sq2 = "select distinct IG.PALIAS,it.BaseQty,it.rate,it.DIS_AMT,it.amt,IG.PDESC,It.Size,id.Party_Code,it.pcode,it.voucher,it.Volume,id.Party_code,id.USER_VCH,id.VCH_DATE,it.ucode,it.qty,it.RefPCODE,ig.AmtBasePercent,it.useries,id.ReffpartyCode,it.REF_VOUCHER from Iglmst IG , itran it,idata id where it.ficode='" + edpcom.CurrentFicode + "' and it.gcode='" + edpcom.PCURRENT_GCODE + "' and IG.ficode = it.ficode and IG.gcode = it.gcode and it.pcode = IG.pcode and id.ficode = it.ficode and id.gcode=IG.gcode and id.voucher =it.voucher and it.t_entry = id.t_entry and it.t_entry ='" + tentry + "' and id.user_vch = '" + txtto.Text + "'";
                    dt = RunQDTbl(sq2);
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {
                        Refvoucher = dt.Rows[0][20].ToString();
                        partycode = Convert.ToInt32(dt.Rows[0][7]);
                        Conparty = Convert.ToInt32(dt.Rows[0][19]);
                        string unit = "";
                        if ((Information.IsNumeric(dt.Rows[j][18]) == true) && (dt.Rows[j][18].ToString() != "0"))
                        {
                            string sq3 = "select SM_Name from UnitSeriesMaster where SM_ID=" + dt.Rows[j][18] + " ";
                            DataTable dt1 = RunQDTbl(sq3);
                            unit = dt1.Rows[0][0].ToString();
                            unit = unit.Replace('-', '/');
                        }
                        else
                        {
                            if ((Information.IsNumeric(dt.Rows[j][14]) == true))
                            {
                                string sq3 = "select UDESC from UNIT where UCODE=" + dt.Rows[j][14] + " ";
                                DataTable dt1 = RunQDTbl(sq3);
                                unit = dt1.Rows[0][0].ToString();
                            }
                        }
                        dgrowcou = Convert.ToInt32(billing.Rows.Count);
                        billing.Rows.Add();
                        billing.Rows[Convert.ToInt32(dgrowcou)][1] = dt.Rows[j][5].ToString();
                        billing.Rows[Convert.ToInt32(dgrowcou)][2] = dt.Rows[j][15] + " " + unit;
                        billing.Rows[Convert.ToInt32(dgrowcou)][3] = dt.Rows[j][2];
                        billing.Rows[Convert.ToInt32(dgrowcou)][4] = dt.Rows[j][4];
                        if (tentry == "n" || tentry == "SO")
                            billing.Rows[Convert.ToInt32(dgrowcou)][5] = dt.Rows[j][10];
                        //billing.Rows[Convert.ToInt32(dgrowcou)][8] = unit;
                        if (unit == "NIL")
                        {
                            billing.Rows[Convert.ToInt32(dgrowcou)][8] = "";
                            billing.Rows[Convert.ToInt32(dgrowcou)][2] = "";
                            billing.Rows[Convert.ToInt32(dgrowcou)][3] = " ";
                        }
                        unit = "";
                        if (Convert.ToInt32(dt.Rows[j][17]) > 0)
                            Baseper = Convert.ToInt32(dt.Rows[j][17]);
                        float Amount = Convert.ToSingle(billing.Rows[dgrowcou][4]);
                        //float Quenty = Convert.ToSingle(billing.Rows[dgrowcou][2]);
                        //TQuenty = TQuenty + Quenty;
                        TAmount = TAmount + Amount;
                        dgrowcou++;
                        sl++;
                    }
                    BillDate = Convert.ToDateTime(dt.Rows[0][13]).ToShortDateString();
                }

                int count2 = billing.Rows.Count;
                billing.Rows.Add();
                //billing.Rows[count2][2] = " ..............";
                billing.Rows[count2][6] = "------------------------------";

                int count = billing.Rows.Count;
                billing.Rows.Add();
                billing.Rows[count][7] = "Sub Total";

                //========== Checking For Adhok Amount
                dt.Rows.Clear();
                //string sq2 = "select distinct IG.PALIAS,it.BaseQty,it.rate,it.DIS_AMT,it.amt,IG.PDESC,It.Size,id.Party_Code,it.pcode,it.voucher,it.Volume,id.Party_code,id.USER_VCH,id.VCH_DATE,it.ucode,it.qty,it.RefPCODE,ig.AmtBasePercent,it.useries,id.ReffpartyCode,it.REF_VOUCHER  from Iglmst IG , itran it,idata id where it.ficode='" + edpcom.CurrentFicode + "' and it.gcode='" + edpcom.PCURRENT_GCODE + "' and IG.ficode = it.ficode and IG.gcode = it.gcode and it.pcode = IG.pcode and id.ficode = it.ficode and id.gcode=IG.gcode and id.voucher =it.voucher and it.t_entry = id.t_entry and it.t_entry ='" + tentry + "' and id.user_vch = '" + txtto.Text + "' and it.RefPCODE =" + de.Rows[i][1] + " ";
                string sq22 = "select Distinct v.CRAMT from vchr v,bill b where b.ficode='" + edpcom.CurrentFicode + "' and b.gcode='" + edpcom.PCURRENT_GCODE + "' and b.t_entry='" + tentry + "' and b.BILLNO = '" + txtto.Text + "' and" +
                " b.ficode=v.ficode and b.gcode=v.gcode and b.t_entry=v.t_entry and b.voucher=v.voucher and b.SALES_GLCODE=v.GLCODE";
                dt = RunQDTbl(sq22);
                //=========== End ====================

                if (TAmount != 0)
                    billing.Rows[count][6] = edpcom.GetAmountFormat(Convert.ToDouble(TAmount), 2);
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0] != null)
                            if (dt.Rows[0][0].ToString() != "")
                            {
                                TAmount = Convert.ToSingle(dt.Rows[0][0]);
                                billing.Rows[count][6] = edpcom.GetAmountFormat(Convert.ToDouble(TAmount), 2);                            }
                    }
                }
                int ab1 = billing.Rows.Count;
                for (int k = ab1; k <= 20 - 1; k++)
                {
                    billing.Rows.Add();
                }
                sq11 = "select ad.AddLessDESC,convert(varchar(50),ad.Per)+'%',ad.Amt,ad.Per,ad.AddLessCode,id.OnVATPer from AddLess ad,idata id where ad.ficode='" + edpcom.CurrentFicode + "' and ad.gcode='" + edpcom.PCURRENT_GCODE + "' and id.ficode=ad.ficode and id.gcode=ad.gcode and id.voucher = ad.voucher and id.t_entry = ad.t_entry and id.t_entry ='" + tentry + "' and id.user_vch = '" + txtto.Text + "' ";
                DataTable dr1 = RunQDTbl(sq11);
                string vatname = "";
                for (int i = 0; i <= dr1.Rows.Count - 1; i++)
                {
                    if (i == 0)
                    {
                        for (int j = 0; j <= dr1.Rows.Count - 1; j++)
                        {
                            sq11 = "select Ldesc,T_Filter from glmst where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and glcode=" + dr1.Rows[j][4] + " and T_Filter in(31,32) ";
                            DataTable dr2 = RunQDTbl(sq11);
                            if (dr2.Rows.Count > 0)
                                vatname = dr1.Rows[j][0].ToString();
                        }
                        if (Convert.ToBoolean(dr1.Rows[i][5])== true)
                        {
                            string sql4 = "select distinct  STR_VAL from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno='3.10.1.1'";
                            DataTable dr2 = RunQDTbl(sql4);
                            billing.Rows.Add();
                            count = billing.Rows.Count;
                            billing.Rows.Add();
                            billing.Rows[count][1] = " " + dr2.Rows[0][0].ToString();
                            count = billing.Rows.Count;
                            billing.Rows.Add();
                            billing.Rows[count][1] = " Total Value Rs." + edpcom.GetAmountFormat(Convert.ToDouble(TAmount), 2);
                            float amtvat = (TAmount * Baseper) / 100;
                            count = billing.Rows.Count;
                            billing.Rows.Add();
                            billing.Rows[count][1] = " Less:" + Baseper + "% on Rs. " + Convert.ToDecimal(TAmount).ToString(EDPCommon.SetDecimalPlace(2)) + " Rs. " + Convert.ToDecimal(amtvat).ToString(EDPCommon.SetDecimalPlace(2));
                            count = billing.Rows.Count;
                            billing.Rows.Add();
                            float am = TAmount - amtvat;
                            billing.Rows[count][1] = " Add :" + vatname + "on Rs. " + Convert.ToDecimal(am).ToString(EDPCommon.SetDecimalPlace(2));
                            billing.Rows.Add();
                        }
                    }

                    if (Convert.ToDouble(dr1.Rows[i][2]) >= 0.50)
                    {
                        int count1 = billing.Rows.Count;
                        billing.Rows.Add();
                        if (vatname == dr1.Rows[i][0].ToString())
                            billing.Rows[count1][5] = " VAT";
                        else
                            billing.Rows[count1][5] = dr1.Rows[i][0];
                        if (dr1.Rows[i][1].ToString() != "0%")
                            billing.Rows[count1][7] = "       " + dr1.Rows[i][1].ToString();
                        //billing.Rows[count1][1] = "  Add  " + dr1.Rows[i][0];
                        billing.Rows[count1][4] = edpcom.GetAmountFormat(Convert.ToDouble(dr1.Rows[i][2]), 2);
                        double amo = Convert.ToDouble(billing.Rows[count1][4]);
                        NAmount += amo;
                    }
                    else if (Convert.ToDouble(dr1.Rows[i][2]) < 0.50)
                    {
                        int count1 = billing.Rows.Count;
                        billing.Rows.Add();
                        //billing.Rows[count1][1] = "  Less  " + dr1.Rows[i][0] + " " + dr1.Rows[i][1];
                        billing.Rows[count1][1] = "  Less  " + dr1.Rows[i][0];
                        billing.Rows[count1][4] = edpcom.GetAmountFormat(Convert.ToDouble(dr1.Rows[i][2]), 2);
                        float amo = Convert.ToSingle(billing.Rows[count1][4]);
                        NAmount += amo;
                    }
                }

                NTAmount = Convert.ToSingle(NAmount) + TAmount;
                FinalAmount = edpcom.GetAmountFormat(Convert.ToDouble(NTAmount), 2);

                amt.Text = Convert.ToDecimal(NTAmount).ToString(common.SetDecimalPlace(2));
                digit_figer.RUPPES AA = new digit_figer.RUPPES();
                string SS = null;
                string KK = null;
                int LL = 0;

                LL = (amt.Text.IndexOf(".", 0) + 1);
                if (LL == 0)
                {
                    SS = AA.RUPEES(amt.Text);
                    SS = SS + " " + "ONLY";
                }
                else
                {
                    KK = amt.Text.Substring(0, LL - 1);
                    SS = AA.RUPEES(KK);
                    SS = SS + " " + AA.PAISA1(amt.Text);
                }
                AmtWord = "(RUPEES " + SS + ")";

                ab1 = billing.Rows.Count;
                for (int j = ab1; j <= 30 - 1; j++)
                {
                    billing.Rows.Add();
                }
            }
            catch { }
        }

        public static DataTable RunQDTbl(String strSql)
        {
            SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AccordFour;Data Source=.\\SQLEXPRESS");

            conn.Open();
            SqlDataAdapter dtAdap = new SqlDataAdapter(strSql, conn);

            DataTable dtTbl = new DataTable();

            SqlCommand cmd = new SqlCommand(strSql);
            cmd.Connection = conn;
            dtAdap.SelectCommand = cmd;

            try
            {
                cmd = new SqlCommand(strSql);
                cmd.Connection = conn;
                dtAdap.SelectCommand = cmd;

                dtAdap.Fill(dtTbl);

            }
            catch { }

            finally
            {
                conn.Close();
            }
            return dtTbl;
        }

        private void txtto_DropDown(object sender, EventArgs e)
        {
            try
            {
                edpcon.Close();
                edpcon.Open();
                //txtto.CommandString = "select USER_VCH,VCH_DATE from idata where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_Entry = '" + tentry + "' order by USER_VCH";
                txtto.CommandString = "select id.USER_VCH,id.VCH_DATE,G.LDESC from idata id,Glmst G where id.ficode='" + edpcom.CurrentFicode + "' and id.gcode='" + edpcom.PCURRENT_GCODE + "' and id.T_Entry = '" + tentry + "' and id.party_code = G.GLCODE order by USER_VCH ";
                txtto.Heading = "Select Voucher";
                txtto.Connection = edpcon.mycon;
                txtto.ReturnIndex = 1;
                edpcon.Close();
            }
            catch { }
        }

        public void Printheader()
        {
            string stat = "";
            edpcon.Close();
            edpcon.Open();
            dsBRANCH.Clear();
            cmd = new SqlCommand("SELECT BRNCH_ADD1,BRNCH_ADD2,BRNCH_CITY,BRNCH_STATE,BRNCH_PIN,BRNCH_PAN1,Tin,BRNCH_TELE1,BRNCH_TELE2,BRNCH_FAX,BRNCH_CST,BRNCH_EMAIL FROM BRANCH WHERE FICODE=" + edpcom.CurrentFicode + " AND GCODE=" + edpcom.PCURRENT_GCODE + " AND BRNCH_CODE=0", edpcon.mycon);
            adp.SelectCommand = cmd;
            edpcon.Close();
            try
            {
                adp.Fill(dsBRANCH, "BR");

                DURATION = "From " + "" + Convert.ToDateTime(edpcom.CURRCO_SDT).ToShortDateString() + "";
                DURATION = DURATION + "  To " + Convert.ToDateTime(edpcom.CURRCO_EDT).ToShortDateString() + "";

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][0]) != "")
                    address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][0]) + ",";

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]) != "")
                    address = address + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]);


                if (dsBRANCH.Tables["BR"].Rows[0][3].ToString() != "")
                {
                    cmd = new SqlCommand("select State_Name from StateMaster where STATE_CODE=" + dsBRANCH.Tables["BR"].Rows[0][3] + " ", edpcon.mycon);
                    adp.SelectCommand = cmd;
                    adp.Fill(dsBRANCH, "state");
                    stat = dsBRANCH.Tables["state"].Rows[0][0].ToString(); ;
                }
                address1 = "";
                if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                    address1 = address1 + " - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                    address1 = address1 + ", " + stat;
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (stat != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                    address1 = address + " - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (stat != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() == ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]) + "," + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() == "") && (stat != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    address1 = stat + ", PIN No. - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (stat != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() == ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() == "") && (stat != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() == ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["state"].Rows[0][0]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() == "") && (stat != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    address1 = "PIN No. - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                }
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][7]) != "")
                {
                    pan = "TEL NO - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][7]);
                }
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][8]) != "")
                {
                    pan = pan + ", " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][8]);
                }
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][9]) != "")
                {
                    pan = pan + " .FAX NO." + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][9]);
                }
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][6]) != "")
                {
                    TinNo1 = "VAT NO :" + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][6]);
                }
                //string query = "select co_name from company where ficode='" + edpcom.CurrentFicode + "' and Gcode='" + edpcom.PCURRENT_GCODE + "'";
                //DataTable dtre = RunQDTbl(query);
                //current_company = (dtre.Rows[0][0].ToString());
            }
            catch { }
            cmd = new SqlCommand("select ldesc from glmst where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and  glcode=" + partycode + " ", edpcon.mycon);
            adp.SelectCommand = cmd;
            adp.Fill(dsBRANCH, "Company");

            if (dsBRANCH.Tables["Company"].Rows.Count > 0)
            {
                if (Convert.ToString(dsBRANCH.Tables["Company"].Rows[0][0]) != "")
                {
                    company = Convert.ToString(dsBRANCH.Tables["Company"].Rows[0][0]);
                }
            }

            cmd = new SqlCommand("select g.ldesc,p.ACC_ADD1,p.ACC_CITY,p.ACC_STATE,p.ACC_PIN from glmst g ,prtyms p where g.glcode=p.glcode and p.glcode=" + partycode + " ", edpcon.mycon);
            adp.SelectCommand = cmd;
            adp.Fill(dsBRANCH, "address");

            try
            {
                if (dsBRANCH.Tables["Address"].Rows.Count > 0)
                {
                    if (Convert.ToString(dsBRANCH.Tables["address"].Rows[0][1]) != "")
                    {
                        Agentadd = Convert.ToString(dsBRANCH.Tables["address"].Rows[0][1]);
                    }
                    if (Convert.ToString(dsBRANCH.Tables["address"].Rows[0][2]) != "")
                    {
                        Agentadd1 = Convert.ToString(dsBRANCH.Tables["address"].Rows[0][2]);
                        if (Convert.ToString(dsBRANCH.Tables["address"].Rows[0][4]) != "")
                        {
                            Agentadd1 = Agentadd1 + "-" + Convert.ToString(dsBRANCH.Tables["address"].Rows[0][4]);
                        }
                    }

                }
                conName = "Self";
                if (Conparty != 0)
                {
                    cmd = new SqlCommand("select ldesc from glmst where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and  glcode=" + Conparty + " ", edpcon.mycon);
                    adp.SelectCommand = cmd;
                    adp.Fill(dsBRANCH, "conNam");

                    if (dsBRANCH.Tables["conNam"].Rows.Count > 0)
                    {
                        if (Convert.ToString(dsBRANCH.Tables["conNam"].Rows[0][0]) != "")
                        {
                            conName = Convert.ToString(dsBRANCH.Tables["conNam"].Rows[0][0]);
                        }
                    }
                    cmd = new SqlCommand("select g.ldesc,p.ACC_ADD1,p.ACC_CITY,p.ACC_STATE,p.ACC_PIN from glmst g ,prtyms p where g.glcode=p.glcode and p.glcode=" + Conparty + " ", edpcon.mycon);
                    adp.SelectCommand = cmd;
                    adp.Fill(dsBRANCH, "condetails");

                    try
                    {
                        if (dsBRANCH.Tables["condetails"].Rows.Count > 0)
                        {
                            if (Convert.ToString(dsBRANCH.Tables["condetails"].Rows[0][1]) != "")
                            {
                                ConAdd1 = Convert.ToString(dsBRANCH.Tables["condetails"].Rows[0][1]);
                            }
                            if (Convert.ToString(dsBRANCH.Tables["condetails"].Rows[0][2]) != "")
                            {
                                Conadd2 = Convert.ToString(dsBRANCH.Tables["condetails"].Rows[0][2]);
                                if (Convert.ToString(dsBRANCH.Tables["condetails"].Rows[0][4]) != "")
                                {
                                    Conadd2 = Conadd2 + "-" + Convert.ToString(dsBRANCH.Tables["condetails"].Rows[0][4]);
                                }
                            }

                        }
                    }
                    catch { }
                }
                User_Voucher = "";
                User_Voucher = txtto.Text.ToString();               
                if (tentry == "9")
                {
                    cmd = new SqlCommand("select id.user_vch,id.Vch_Date,it.REF_TENTRY,it.REF_VOUCHER  from idata id ,itran it where id.ficode=" + edpcom.CurrentFicode + " and id.gcode=" + edpcom.PCURRENT_GCODE + " and id.ficode=it.ficode and id.gcode=it.gcode and it.voucher = id.voucher and it.t_entry=id.t_entry and id.T_entry='n'and id.voucher=" + Refvoucher + " ", edpcon.mycon);
                    adp.SelectCommand = cmd;
                    adp.Fill(dsBRANCH, "voucher");
                    challan = ""; challandt = "";
                    if (dsBRANCH.Tables["voucher"].Rows.Count > 0)
                    {

                        challan = dsBRANCH.Tables["voucher"].Rows[0][0].ToString();
                        challandt = Convert.ToDateTime(dsBRANCH.Tables["voucher"].Rows[0][1]).ToShortDateString();
                    }
                    if (dsBRANCH.Tables["voucher"].Rows[0][2].ToString() == "OS")
                    {
                        cmd = new SqlCommand("select id.user_vch,id.Vch_Date  from idata id  where id.ficode=" + edpcom.CurrentFicode + " and id.gcode=" + edpcom.PCURRENT_GCODE + " and  id.T_entry='OS'and id.voucher=" + dsBRANCH.Tables["voucher"].Rows[0][3] + " ", edpcon.mycon);
                        adp.SelectCommand = cmd;
                        adp.Fill(dsBRANCH, "Order");
                        Area = ""; phone = "";
                        if (dsBRANCH.Tables["Order"].Rows.Count > 0)
                        {
                            Area = "Your Order No : " + dsBRANCH.Tables["Order"].Rows[0][0].ToString();
                            phone = Convert.ToDateTime(dsBRANCH.Tables["Order"].Rows[0][1]).ToShortDateString();
                        }
                    }
                }
                else
                {
                    cmd = new SqlCommand("select id.user_vch,id.Vch_Date  from idata id  where id.ficode=" + edpcom.CurrentFicode + " and id.gcode=" + edpcom.PCURRENT_GCODE + " and  id.T_entry='OS'and id.voucher=" + Refvoucher + " ", edpcon.mycon);
                    adp.SelectCommand = cmd;
                    adp.Fill(dsBRANCH, "Order");
                    Area = ""; phone = "";
                    if (dsBRANCH.Tables["Order"].Rows.Count > 0)
                    {
                        Area = ""; phone = "";
                        Area = "Your Order No : " + dsBRANCH.Tables["Order"].Rows[0][0].ToString();
                        phone = Convert.ToDateTime(dsBRANCH.Tables["Order"].Rows[0][1]).ToShortDateString();
                    }
                }
            }
            catch { }
        }

        private void btnprnt_Click(object sender, EventArgs e)
        {
            RunData();
            Printheader();
            MidasReport.Form1 opening = new MidasReport.Form1();
            if (tentry == "n" || tentry == "SO")
            {
                if (tentry == "n")
                    challan = "CHALLAN";
                else
                    challan = "STOCK OUT";
                opening.Challan(edpcom.CURRENT_COMPANY, billing, DURATION, address, pan, address1, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, TinNo1, FinalAmount, challandt, conName, ConAdd1, Conadd2, 2);
            }
            opening.sellbillfull(edpcom.CURRENT_COMPANY, billing, DURATION, address, pan, address1, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, TinNo1, FinalAmount, challandt, 2);
        }

        private void btnPrvw_Click(object sender, EventArgs e)
        {
            try
            {
                RunData();
                Printheader();
                MidasReport.Form1 opening = new MidasReport.Form1();
                if (tentry == "n" || tentry == "SO")
                {
                    if (tentry == "n")
                        challan = "CHALLAN";
                    else
                        challan = "STOCK OUT";
                    opening.Challan(edpcom.CURRENT_COMPANY, billing, DURATION, address, pan, address1, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, TinNo1, FinalAmount, challandt, conName, ConAdd1, Conadd2, 1);
                }
                else
                {
                    opening.sellbillfull(edpcom.CURRENT_COMPANY, billing, DURATION, address, pan, address1, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, TinNo1, FinalAmount, challandt, 1);
                }

                opening.ShowDialog();
            }
            catch { }
        }
    }
}