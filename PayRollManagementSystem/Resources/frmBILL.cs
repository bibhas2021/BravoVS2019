using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Edpcom;
using System.Data.SqlClient;
using EDPMessageBox;
using System.Collections;
using Finance;


namespace AccordFour
{
    public partial class frmBILL : EDPComponent.FormBase
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlTransaction SQLT;
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        Boolean flgDgvAdl = true;
        Int32 currcode, PartyCode, ReffPartyCode, CashCode, SalesCode, vno, RefVno, JVNO, LINKVNO;
        Int64 Desccode;
        SqlConnection SQLCNN = new SqlConnection();

        double Qty, Rate, Amt, TotalAmt, ADLPER, ADLVAL, AdhokAmt;
        string Tentry, LTE, JTentry, LINKTE, action, SBType, ChlnVchNo, Pcode_sl, RefChal, PartyType;
        bool Check, Flag_Printing, Flag_Deying, Flag_Cash, MultiSalePurAC, flgMrpVat, Flgaddless, Flag_ReffBill, CHKORD;
        int delRowindex = 0;
        int delColindex = 0;
        int dgvadlesRowCou = 0, RCOUNT = 0;
        char OrderType = 'A';

        public frmBILL()
        {
            InitializeComponent();
        }

        public frmBILL(string SB,char OT)
        {
            InitializeComponent();
            SBType = SB;
            OrderType = OT;
        }

        private void coloumnhide()
        {
            try
            {
                //Flag_Printing = false;
                chkIncVAT.Visible = false;
                chkOnVATPer.Visible = false;
                MultiSalePurAC = false;
                Flag_Deying = false;
                Flag_Printing = false;
                Flag_Cash = false;
                if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno = '3.10.1'") == "TRUE")
                    Flag_Printing = true;

                if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno = '3.10.2'") == "TRUE")
                {
                    Flag_Deying = true;
                    dgvItem.Columns[30].HeaderText = "Refference Item";
                }

                if (edpcom.GetresultS("select distinct upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno = '3.4.8.5'") == "TRUE")
                    Flag_ReffBill = true;

                if (edpcom.GetresultS("select distinct upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno = '3.4.8.9'") == "TRUE")
                    Flag_Cash = true;

                if (edpcom.GetresultS("select distinct upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.4.8.4'") == "TRUE")
                {
                    MultiSalePurAC = true;
                    label7.Enabled = false;
                    cmbSales.Enabled = false;
                }
                else
                {
                    label7.Enabled = true;
                    cmbSales.Enabled = true;         
                }
                //if (Flag_Printing)
                //{
                //    dgvItem.Columns[40].Visible = false;
                //    dgvItem.Columns[41].Visible = false;
                //}

                if (!Flag_ReffBill)
                {
                    groupBox5.Visible = false;
                }

                if (Flag_Cash)
                {                    
                    chkCash.Checked = true;
                    cmbCash.Enabled = true;
                }
                if (Tentry == "OS")
                {
                    if (Flag_Printing)
                    {
                        dgvItem.Columns[7].Visible = false;
                        dgvItem.Columns[8].Visible = false;
                        dgvItem.Columns[9].Visible = false;
                        dgvItem.Columns[10].Visible = false;
                        dgvItem.Columns[11].Visible = false;
                        dgvItem.Columns[12].Visible = false;
                        dgvItem.Columns[13].Visible = false;
                        dgvItem.Columns[16].Visible = false;
                        dgvItem.Columns[17].Visible = false;
                        //dgvItem.Columns[29].Visible = true;
                        //dgvItem.Columns[30].Visible = true;
                        //dgvItem.Columns[32].Visible = true;
                        dgvItem.Columns[33].Visible = true;
                        dgvItem.Columns[35].Visible = true;
                        dgvItem.Columns[36].Visible = true;
                        //dgvItem.Columns[37].Visible = true;
                        dgvItem.Columns[43].Visible = true;
                        if (OrderType == 'O')
                        {
                            dgvItem.Columns[14].Visible = false;
                            dgvItem.Columns[15].Visible = false;
                            dgvItem.Columns[29].Visible = false;
                            dgvItem.Columns[30].Visible = false;
                            dgvItem.Columns[32].Visible = false;
                            dgvItem.Columns[37].Visible = false;
                        }
                        else
                        {
                            dgvItem.Columns[14].Visible = true;
                            dgvItem.Columns[15].Visible = true;
                            dgvItem.Columns[29].Visible = true;
                            dgvItem.Columns[30].Visible = true;
                            dgvItem.Columns[32].Visible = true;
                            dgvItem.Columns[37].Visible = true;
                        }

                        chkIncVAT.Visible = true;
                        chkOnVATPer.Visible = true;                     

                        //btnStockTransfer.Visible = true;
                    }
                    else if (Flag_Deying)
                    {
                        dgvItem.Columns[7].Visible = false;
                        dgvItem.Columns[8].Visible = false;
                        dgvItem.Columns[9].Visible = false;
                        dgvItem.Columns[10].Visible = false;
                        dgvItem.Columns[11].Visible = false;
                        dgvItem.Columns[12].Visible = false;
                        dgvItem.Columns[13].Visible = false;
                        dgvItem.Columns[14].Visible = false;
                        dgvItem.Columns[15].Visible = false;
                        dgvItem.Columns[16].Visible = false;
                        dgvItem.Columns[17].Visible = false;
                        dgvItem.Columns[30].Visible = true;
                        dgvItem.Columns[43].Visible = false;
                        OrderType = 'P';
                    }
                    else
                    {
                        dgvItem.Columns[7].Visible = false;
                        dgvItem.Columns[8].Visible = false;
                        dgvItem.Columns[9].Visible = false;
                        dgvItem.Columns[10].Visible = false;
                        dgvItem.Columns[11].Visible = false;
                        dgvItem.Columns[12].Visible = false;
                        dgvItem.Columns[13].Visible = false;
                        dgvItem.Columns[14].Visible = false;
                        dgvItem.Columns[15].Visible = false;
                        dgvItem.Columns[16].Visible = false;
                        dgvItem.Columns[17].Visible = false;
                    }
                }
                if (Tentry == "n")
                {
                    if (Flag_Printing)
                    {
                        dgvItem.Columns[7].Visible = false;
                        dgvItem.Columns[8].Visible = false;
                        dgvItem.Columns[9].Visible = false;
                        dgvItem.Columns[10].Visible = false;
                        dgvItem.Columns[11].Visible = false;
                        dgvItem.Columns[12].Visible = false;
                        dgvItem.Columns[13].Visible = false;
                        dgvItem.Columns[16].Visible = false;
                        dgvItem.Columns[17].Visible = false;
                        //dgvItem.Columns[29].Visible = true;
                        //dgvItem.Columns[30].Visible = true;
                        //dgvItem.Columns[32].Visible = true;
                        dgvItem.Columns[33].Visible = true;
                        dgvItem.Columns[35].Visible = true;
                        dgvItem.Columns[36].Visible = true;
                        //dgvItem.Columns[37].Visible = true;
                        dgvItem.Columns[43].Visible = true;
                        if (OrderType == 'O')
                        {
                            dgvItem.Columns[14].Visible = false;
                            dgvItem.Columns[15].Visible = false;
                            dgvItem.Columns[29].Visible = false;
                            dgvItem.Columns[30].Visible = false;
                            dgvItem.Columns[32].Visible = false;
                            dgvItem.Columns[37].Visible = false;
                        }
                        else
                        {
                            dgvItem.Columns[14].Visible = true;
                            dgvItem.Columns[15].Visible = true;
                            dgvItem.Columns[29].Visible = true;
                            dgvItem.Columns[30].Visible = true;
                            dgvItem.Columns[32].Visible = true;
                            dgvItem.Columns[37].Visible = true;
                        }


                        chkIncVAT.Visible = true;
                        chkOnVATPer.Visible = true;
                    }
                    else if (Flag_Deying)
                    {
                        dgvItem.Columns[7].Visible = false;
                        dgvItem.Columns[8].Visible = false;
                        dgvItem.Columns[9].Visible = false;
                        dgvItem.Columns[10].Visible = false;
                        dgvItem.Columns[11].Visible = false;
                        dgvItem.Columns[12].Visible = false;
                        dgvItem.Columns[13].Visible = false;
                        dgvItem.Columns[14].Visible = false;
                        dgvItem.Columns[15].Visible = false;
                        dgvItem.Columns[16].Visible = false;
                        dgvItem.Columns[17].Visible = false;
                        dgvItem.Columns[30].Visible = true;
                        OrderType = 'P';
                        //dgvItem.Columns[43].Visible = true;
                    }
                    else
                    {
                        dgvItem.Columns[7].Visible = false;
                        dgvItem.Columns[8].Visible = false;
                        dgvItem.Columns[9].Visible = false;
                        dgvItem.Columns[10].Visible = false;
                        dgvItem.Columns[11].Visible = false;
                        dgvItem.Columns[12].Visible = false;
                        dgvItem.Columns[13].Visible = false;
                        dgvItem.Columns[14].Visible = false;
                        dgvItem.Columns[15].Visible = false;
                        dgvItem.Columns[16].Visible = false;
                        dgvItem.Columns[17].Visible = false;
                    }
                }
                if (Tentry == "9")
                {
                    if (Flag_Printing)
                    {
                        dgvItem.Columns[5].Visible = false;
                        dgvItem.Columns[7].Visible = false;
                        dgvItem.Columns[8].Visible = false;
                        dgvItem.Columns[9].Visible = false;
                        dgvItem.Columns[10].Visible = false;
                        dgvItem.Columns[11].Visible = false;
                        dgvItem.Columns[12].Visible = false;
                        dgvItem.Columns[13].Visible = false;
                        dgvItem.Columns[16].Visible = false;
                        dgvItem.Columns[17].Visible = false;
                        dgvItem.Columns[18].Visible = false;
                        dgvItem.Columns[43].Visible = true;
                        chkIncVAT.Visible = true;
                        chkOnVATPer.Visible = true;
                        if (MultiSalePurAC)
                        {
                            dgvItem.Columns[20].Visible = true;
                            dgvItem.Columns[21].Visible = true;
                        }
                        //dgvItem.Columns[29].Visible = true;
                        //dgvItem.Columns[30].Visible = true;
                        //dgvItem.Columns[32].Visible = true;
                        dgvItem.Columns[33].Visible = true;
                        dgvItem.Columns[35].Visible = true;
                        dgvItem.Columns[36].Visible = true;
                        //dgvItem.Columns[37].Visible = true;
                        if (OrderType == 'O')
                        {
                            dgvItem.Columns[14].Visible = false;
                            dgvItem.Columns[15].Visible = false;
                            dgvItem.Columns[29].Visible = false;
                            dgvItem.Columns[30].Visible = false;
                            dgvItem.Columns[32].Visible = false;
                            dgvItem.Columns[37].Visible = false;
                        }
                        else
                        {
                            dgvItem.Columns[14].Visible = true;
                            dgvItem.Columns[15].Visible = true;
                            dgvItem.Columns[29].Visible = true;
                            dgvItem.Columns[30].Visible = true;
                            dgvItem.Columns[32].Visible = true;
                            dgvItem.Columns[37].Visible = true;
                        }

                    }
                    else if (Flag_Deying)
                    {
                        if (MultiSalePurAC)
                        {
                            dgvItem.Columns[20].Visible = true;
                            dgvItem.Columns[21].Visible = true;
                            dgvItem.Columns[22].Visible = true;
                            dgvItem.Columns[23].Visible = true;
                        }
                        OrderType = 'P';
                        Flag_Printing = false;
                        dgvItem.Columns[7].Visible = false;
                        dgvItem.Columns[8].Visible = false;
                        dgvItem.Columns[9].Visible = false;
                        dgvItem.Columns[10].Visible = false;
                        dgvItem.Columns[11].Visible = false;
                        dgvItem.Columns[12].Visible = false;
                        dgvItem.Columns[13].Visible = false;
                        dgvItem.Columns[14].Visible = false;
                        dgvItem.Columns[15].Visible = false;
                        dgvItem.Columns[16].Visible = false;
                        dgvItem.Columns[17].Visible = false;
                        dgvItem.Columns[19].Visible = false;
                        dgvItem.Columns[22].Visible = false;
                        dgvItem.Columns[23].Visible = false;
                        dgvItem.Columns[30].Visible = true;
                        dgvItem.Columns[43].Visible = true;
                    }
                    else
                    {
                        if (MultiSalePurAC)
                        {
                            dgvItem.Columns[20].Visible = true;
                            dgvItem.Columns[21].Visible = true;
                            dgvItem.Columns[22].Visible = true;
                            dgvItem.Columns[23].Visible = true;
                        }
                        Flag_Printing = false;
                        dgvItem.Columns[7].Visible = false;
                        dgvItem.Columns[8].Visible = false;
                        dgvItem.Columns[9].Visible = false;
                        dgvItem.Columns[10].Visible = false;
                        dgvItem.Columns[11].Visible = false;
                        dgvItem.Columns[12].Visible = false;
                        dgvItem.Columns[13].Visible = false;
                        dgvItem.Columns[14].Visible = false;
                        dgvItem.Columns[15].Visible = false;
                        dgvItem.Columns[16].Visible = false;
                        dgvItem.Columns[17].Visible = false;
                        dgvItem.Columns[19].Visible = false;
                        dgvItem.Columns[22].Visible = false;
                        dgvItem.Columns[23].Visible = false;
                    }
                }
                if (Tentry == "8")
                {
                    dgvItem.Columns[7].Visible = false;
                    dgvItem.Columns[8].Visible = false;
                    dgvItem.Columns[9].Visible = false;
                    dgvItem.Columns[10].Visible = false;
                    dgvItem.Columns[11].Visible = false;
                    dgvItem.Columns[12].Visible = false;
                    dgvItem.Columns[13].Visible = false;
                    dgvItem.Columns[14].Visible = false;
                    dgvItem.Columns[15].Visible = false;
                    dgvItem.Columns[16].Visible = false;
                    dgvItem.Columns[17].Visible = false;
                    if (Flag_Printing)
                        rbtAdditional.Visible = false;

                    if (MultiSalePurAC)
                    {
                        dgvItem.Columns[20].Visible = true;
                        dgvItem.Columns[21].Visible = true;
                        dgvItem.Columns[20].HeaderText = "Purchase A/C";
                    }
                }
                if (Tentry == "a")
                {
                    dgvItem.Columns[7].Visible = false;
                    dgvItem.Columns[8].Visible = false;
                    dgvItem.Columns[9].Visible = false;
                    dgvItem.Columns[10].Visible = false;
                    dgvItem.Columns[11].Visible = false;
                    dgvItem.Columns[12].Visible = false;
                    dgvItem.Columns[13].Visible = false;
                    dgvItem.Columns[14].Visible = false;
                    dgvItem.Columns[15].Visible = false;
                    dgvItem.Columns[16].Visible = false;
                    dgvItem.Columns[17].Visible = false;
                    if (Flag_Printing)
                        rbtAdditional.Visible = false;
                }
                if (Tentry == "OP")
                {
                    dgvItem.Columns[7].Visible = false;
                    dgvItem.Columns[8].Visible = false;
                    dgvItem.Columns[9].Visible = false;
                    dgvItem.Columns[10].Visible = false;
                    dgvItem.Columns[11].Visible = false;
                    dgvItem.Columns[12].Visible = false;
                    dgvItem.Columns[13].Visible = false;
                    dgvItem.Columns[14].Visible = false;
                    dgvItem.Columns[15].Visible = false;
                    dgvItem.Columns[16].Visible = false;
                    dgvItem.Columns[17].Visible = false;
                    if (Flag_Printing)
                        rbtAdditional.Visible = false;
                }
                if (Tentry == "SI")
                {
                    dgvItem.Columns[7].Visible = false;
                    dgvItem.Columns[8].Visible = false;
                    dgvItem.Columns[9].Visible = false;
                    dgvItem.Columns[10].Visible = false;
                    dgvItem.Columns[11].Visible = false;
                    dgvItem.Columns[12].Visible = false;
                    dgvItem.Columns[13].Visible = false;
                    dgvItem.Columns[14].Visible = false;
                    dgvItem.Columns[15].Visible = false;
                    dgvItem.Columns[16].Visible = false;
                    dgvItem.Columns[17].Visible = false;
                    if (Flag_Printing)
                    {
                        rbtAdditional.Visible = false;
                        //cmbRefOrd.Enabled = false;
                    }
                }
                if (Tentry == "SO")
                {
                    dgvItem.Columns[7].Visible = false;
                    dgvItem.Columns[8].Visible = false;
                    dgvItem.Columns[9].Visible = false;
                    dgvItem.Columns[10].Visible = false;
                    dgvItem.Columns[11].Visible = false;
                    dgvItem.Columns[12].Visible = false;
                    dgvItem.Columns[13].Visible = false;
                    //dgvItem.Columns[14].Visible = false;
                    dgvItem.Columns[15].Visible = false;
                    dgvItem.Columns[16].Visible = false;
                    dgvItem.Columns[17].Visible = false;
                    if (Flag_Printing)
                    {
                        rbtAdditional.Visible = false;
                        //cmbRefOrd.Enabled = false;
                    }
                }
                if (Flag_Printing)
                {
                    dgvItem.Columns[33].Visible = false;
                    dgvItem.Columns[35].Visible = false;
                    dgvItem.Columns[36].Visible = false;
                    dgvItem.Columns[43].Visible = false;                   
                }
            }
            catch { }
        }

        private void ChooseTEntry()
        {
            try
            {
                //dtpRefBilDate.Enabled = false;
                //dtpRefOrdDate.Enabled = false;
                cmbLocation.Enabled = false;

                if (SBType == "SALES")
                {
                    groupBox4.Text = "Sales Invoice Entry";
                    label10.Text = "Ref. Chln";
                    label11.Visible = true;
                    txtVoucherChallan.Visible = true;
                    Tentry = "9";
                    LTE = "n";
                    if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.8' ") == "TRUE")
                        flgMrpVat = true;
                }
                else if (SBType == "STKOUT")
                {
                    groupBox4.Text = "Stock Out Entry";
                    chkCash.Enabled = false;
                    label5.Enabled = false;
                    cmbCash.Enabled = false;
                    label7.Enabled = false;
                    cmbSales.Enabled = false;
                    btnRefChallan.Enabled = false;
                    lbRC.Enabled = false;
                    RBAddless.Visible = false;
                    Tentry = "SO";
                    LTE = "SO";
                    cmbRefOrd.Visible = true;
                    lbcmp.Visible = false;
                    btnRefOrd.Visible = false;
                }
                else if (SBType == "OS")
                {
                    groupBox4.Text = "Sales Order Entry";
                    label5.Enabled = false;
                    label7.Enabled = false;
                    label9.Enabled = false;
                    label10.Enabled = false;
                    label14.Enabled = false;
                    label15.Enabled = false;
                    cmbSales.Enabled = false;
                    dateTimePickerEDP3.Enabled = false;
                    lbcmp.Enabled = false;
                    lbRC.Enabled = false;
                    Tentry = "OS";
                    LTE = "OS";
                    RBAddless.Visible = false;
                    btnRefChallan.Enabled = false;
                    btnRefOrd.Enabled = false;
                    label5.Visible = false;
                    cmbCash.Visible = false;
                    label7.Visible = false;
                    cmbSales.Visible = false;
                    cmbSales.Visible = false;
                    lbcmp.Visible = false;
                    btnRefOrd.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    lbRC.Visible = false;
                    btnRefChallan.Visible = false;
                    //label11.Visible = false;
                    //dtpRefOrdDate.Visible = false;
                    //label12.Visible = false;
                    //dtpRefBilDate.Visible = false;

                }
                else if (SBType == "SI")
                {
                    groupBox4.Text = "Stock In Entry";
                    Tentry = "SI";
                    LTE = "SI";
                    chkCash.Enabled = false;
                    label5.Enabled = false;
                    cmbCash.Enabled = false;
                    label7.Enabled = false;
                    cmbSales.Enabled = false;
                    btnRefChallan.Enabled = false;
                    lbRC.Enabled = false;
                    RBAddless.Visible = false;
                    btnRefChallan.Enabled = false;
                    cmbRefOrd.Visible = true;
                    chkStopSI.Visible = true;
                    lbcmp.Visible = false;
                    btnRefOrd.Visible = false;
                }
                else if (SBType == "CHLN")
                {
                    groupBox4.Text = "Sales Challan Entry";
                    Tentry = "n";
                    LTE = "n";
                    chkCash.Enabled = false;
                    label5.Enabled = false;
                    cmbCash.Enabled = false;
                    label7.Enabled = false;
                    cmbSales.Enabled = false;
                    btnRefChallan.Enabled = false;
                    lbRC.Enabled = false;
                    RBAddless.Visible = false;
                    btnRefChallan.Enabled = false;

                    label5.Visible = false;
                    cmbCash.Visible = false;
                    label7.Visible = false;
                    cmbSales.Visible = false;
                    cmbSales.Visible = false;
                    //lbcmp.Visible = false;
                    //btnRefOrd.Visible = false;
                    label10.Visible = false;
                    lbRC.Visible = false;
                    btnRefChallan.Visible = false;
                    //label9.Visible = false;
                }
                else if (SBType == "PO")
                {
                    groupBox4.Text = "Purchase Order Entry";
                    label7.Enabled = false;
                    cmbSales.Enabled = false;
                    Tentry = "OP";
                    LTE = "OP";
                    RBAddless.Visible = false;
                    btnRefChallan.Enabled = false;
                    btnRefOrd.Enabled = false;

                    label5.Visible = false;
                    cmbCash.Visible = false;
                    label7.Visible = false;
                    cmbSales.Visible = false;
                    cmbSales.Visible = false;
                    lbcmp.Visible = false;
                    btnRefOrd.Visible = false;
                    label10.Visible = false;
                    lbRC.Visible = false;
                    btnRefChallan.Visible = false;
                    label9.Visible = false;
                    //label11.Visible = false;
                    //dtpRefOrdDate.Visible = false;
                    //label12.Visible = false;
                    //dtpRefBilDate.Visible = false;
                }
                else if (SBType == "PURCHLN")
                {
                    groupBox4.Text = "Purchase Challan Entry";
                    Tentry = "a";
                    LTE = "a";
                    chkCash.Enabled = false;
                    label5.Enabled = false;
                    cmbCash.Enabled = false;
                    label7.Enabled = false;
                    cmbSales.Enabled = false;
                    btnRefChallan.Enabled = false;
                    lbRC.Enabled = false;
                    RBAddless.Visible = false;
                    btnRefChallan.Enabled = false;

                    label5.Visible = false;
                    cmbCash.Visible = false;
                    label7.Visible = false;
                    cmbSales.Visible = false;
                    cmbSales.Visible = false;
                    //lbcmp.Visible = false;
                    //btnRefOrd.Visible = false;
                    label10.Visible = false;
                    lbRC.Visible = false;
                    btnRefChallan.Visible = false;
                    //label9.Visible = false;


                }
                else if (SBType == "PUR")
                {
                    groupBox4.Text = "Purchase Invoice Entry";
                    label10.Text = "Ref. Chln";
                    label7.Text = "Purchase A/C";
                    Tentry = "8";
                    LTE = "a";
                    label11.Visible = true;
                    txtVoucherChallan.Visible = true;
                }
                else if (SBType == "SRETURN")
                {
                    groupBox4.Text = "Sales Return Entry";
                    label10.Text = "Ref. Bill";
                    btnRefOrd.Enabled = false;
                    lbcmp.Enabled = false;
                    btnRefChallan.Text = "Sales Return";
                    Tentry = "SR";
                    LTE = "SR";
                    btnRefOrd.Enabled = false;
                }
                else if (SBType == "PR")
                {
                    groupBox4.Text = "Purchase Return Entry";
                    label10.Text = "Ref. Bill";
                    label7.Text = "Purchase A/C";
                    Tentry = "PR";
                    LTE = "PR";
                    btnRefOrd.Enabled = false;
                    lbcmp.Enabled = false;
                    btnRefChallan.Text = "Return Challan";
                    btnRefOrd.Enabled = false;
                }

                dtp.Value = System.DateTime.Now;
                dtpBillDue.Value = System.DateTime.Now;
                if (!edpcom.ChkDocType(Convert.ToString(Tentry)))
                {
                    EDPMessage.Show("Document Type Not found for the Sales Transaction  " + Environment.NewLine + "Do you Want to Create For this Transaction?" + Environment.NewLine + "Click Yes for Default Creation or No to Create Manually.", "Must Create", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
                    if (EDPMessage.ButtonResult == "edpYES")
                    {
                        edpcom.AutoDocTypeCreate(Convert.ToString(Tentry));
                        if (edpcom.GetresultS("select * from docgen where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='n'") == null)
                            edpcom.AutoDocTypeCreate(Convert.ToString("n"));
                        if (edpcom.GetresultS("select * from docgen where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='a'") == null)
                            edpcom.AutoDocTypeCreate(Convert.ToString("a"));
                    }
                    else
                    {
                        frmAccountPosting fa = new frmAccountPosting();
                        fa.ShowDialog();
                    }
                }
                if ((SBType == "SALES" || SBType == "PURCHLN" || SBType == "CHLN" || SBType == "PUR") && Flag_Printing == false)
                {
                    rbtAdditional.Visible = true;
                    if (dgvAdditional.Rows.Count == 1 && dgvAdditional.Rows[0].Cells[0].Value != null)
                    {
                    }
                    else
                        dgvAdditional.Rows.Add();
                    dgvAdditional.Rows[dgvAdditional.Rows.Count - 1].HeaderCell.Value = "Transport Name";
                    dgvAdditional.Rows.Add();
                    dgvAdditional.Rows[dgvAdditional.Rows.Count - 1].HeaderCell.Value = "Consingment No.";
                    dgvAdditional.Rows.Add();
                    dgvAdditional.Rows[dgvAdditional.Rows.Count - 1].HeaderCell.Value = "Consingment Date";
                    dgvAdditional.Rows.Add();
                    dgvAdditional.Rows[dgvAdditional.Rows.Count - 1].HeaderCell.Value = "No of Packages";
                    dgvAdditional.Rows.Add();
                    dgvAdditional.Rows[dgvAdditional.Rows.Count - 1].HeaderCell.Value = "SRV NO.";
                    dgvAdditional.Rows.Add();
                    dgvAdditional.Rows[dgvAdditional.Rows.Count - 1].HeaderCell.Value = "SRV Date";
                    dgvAdditional.Rows.Add();
                    dgvAdditional.Rows[dgvAdditional.Rows.Count - 1].HeaderCell.Value = "Lorry NO.";
                    dgvAdditional.Rows.Add();
                    dgvAdditional.Rows[dgvAdditional.Rows.Count - 1].HeaderCell.Value = "Weight";
                    dgvAdditional.Rows.Add();
                    dgvAdditional.Rows[dgvAdditional.Rows.Count - 1].HeaderCell.Value = "Delivery At";
                }
            }
            catch { }
        }

        private void frmBILL_Load(object sender, EventArgs e)
        {
            try
            {
                this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
                pnlMamata.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
                label17.Text = edpcom.CURRENT_COMPANY;
                cmbCash.Enabled = false;
                ChooseTEntry();
                coloumnhide();
                PanelRate.Visible = false;
                label16.Visible = false;
                cmbVoucher.Visible = false;

                edpcom.UpdateAccordFourLog(this, true);
                edpcom.setFormPosition(this);

                cmbAct.SelectedIndex = 0;
                if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.2' ") == "FALSE")
                {
                    dgvItem.Columns[3].Visible = false;
                    dgvItem.Columns[9].Visible = false;
                }
                if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.9' ") == "TRUE")
                {
                    dgvItem.Columns[18].Visible = true;
                }
                if (edpcom.GetresultS("select distinct upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.10' ") == "TRUE")
                {
                    dgvItem.Columns[5].Visible = true;
                }
                if (!Flag_Cash)
                    dgvItem.Rows.Add();
                RBItemDetail.Checked = true;
                if (!Flag_Cash)
                    dgvItem_CellDoubleClick(sender, new DataGridViewCellEventArgs(0, 0));

                if (Flag_Printing && SBType == "OS" && OrderType=='P')
                {
                    string st = "SELECT DISTINCT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE] FROM IDATA ID,itran it,ConsumeProduct C WHERE ID.FICODE=it.ficode and ID.gcode=it.gcode and ID.FICODE='" + edpcom.CurrentFicode + "' AND " +
                      " ID.voucher=it.voucher and ID.t_entry=it.T_entry and ID.GCODE='" + edpcom.PCURRENT_GCODE + "' AND ID.T_ENTRY='OS' AND ID.Party_code=" + PartyCode + " and it.DSTATUS<>'RUNNING' And ID.OrderType='P'" +// And it.voucher=" + vno + "";
                      " AND C.FICODE=ID.FICODE AND C.GCODE=ID.GCODE AND C.VOUCHER=ID.VOUCHER AND C.T_ENTRY='OS'";
                    edpcon.Open();
                    common.ClearDataTable(ds.Tables["ChOrd"]);
                    cmd = new SqlCommand(st, edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "ChOrd");
                    edpcon.Close();
                    if (ds.Tables["ChOrd"].Rows.Count > 0)
                    {
                        //btnStockTransfer.Visible = true;
                        dgvStockTransfer.Visible = true;
                        dgvStockTransfer.Enabled = true;
                        for (int i = 0; i <= ds.Tables["ChOrd"].Rows.Count - 1; i++)
                        {
                            dgvStockTransfer.Rows.Add();
                            dgvStockTransfer.Rows[i].Cells[0].Value = ds.Tables["ChOrd"].Rows[i][0].ToString();
                            dgvStockTransfer.Rows[i].Cells[1].Value = ds.Tables["ChOrd"].Rows[i][1].ToString();
                            dgvStockTransfer.Rows[i].Cells[2].Value = Convert.ToDateTime(ds.Tables["ChOrd"].Rows[i][2]).ToShortDateString();
                        }
                    }
                }
            }
            catch { }
        }

        private void cmbPartyName_DropDown(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                if ((SBType == "SALES") || (SBType == "CHLN") || (SBType == "SRETURN") || (SBType == "OS"))
                    str = "SELECT LDESC,GLCODE,LALIAS FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND SGROUP=12";
                else if (SBType == "STKOUT" || SBType == "SI")
                    str = "SELECT LDESC,GLCODE,LALIAS FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND SGROUP IN(5,12)";
                else
                    str = "SELECT LDESC,GLCODE,LALIAS FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND SGROUP=5";

                Finance.frmLedgerOpen AM = new Finance.frmLedgerOpen();
                edpcon.Open();
                common.LOV("SELECT PARTY NAME", str, textBox1, 1, AM, true, "Click here to create new party");
                if (textBox1.Text.Trim() != "")
                    cmbPartyName.Text = textBox1.Text;
                else
                    cmbPartyName.Text = EDPCommon.LOVReturnText;
                EDPCommon.LOVReturnText = "";
                PartyCode = Convert.ToInt32(common.LovReturnValue);
                cmbSales_DropDown(cmbSales, e);
                cmbSales.Focus();
                if ((!MultiSalePurAC) && (chkCash.Checked))
                {
                    cmbCash.PopUp();
                }
            }
            catch { }
        }

        private void cmbPartyName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Space)
            //    cmbPartyName.PopUp(sender, new EventArgs());
            if (e.KeyCode == Keys.Enter)
                cmbCash.PopUp();
        }

        private void chkCash_Click(object sender, EventArgs e)
        {
            if (chkCash.Checked)
                cmbCash.Enabled = true;
            else
                cmbCash.Enabled = false;
        }

        private void cmbSales_DropDown(object sender, EventArgs e)
        {
            edpcon.Open();
            if (Tentry == "9" || Tentry == "SR")
                cmbSales.CommandString = "SELECT LDESC,GLCODE FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND SGROUP=0 AND MGROUP=9 AND ACTV_FLG='1'";
            else if (Tentry == "8" || Tentry == "PR")
                cmbSales.CommandString = "SELECT LDESC,GLCODE FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND SGROUP=18 AND MGROUP=8 AND ACTV_FLG='1'";
            cmbSales.Heading = "Select Sales A/C";
            cmbSales.Connection = edpcon.mycon;
            cmbSales.ReturnIndex = 1;
            edpcon.Close();
        }

        private void cmbSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                cmbSales.PopUp(sender, new EventArgs());
        }

        private void cmbSales_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (cmbSales.ReturnValue != "")
                SalesCode = Convert.ToInt32(cmbSales.ReturnValue);
            dgvItem.Focus();
            dgvItem_CellDoubleClick(sender, new DataGridViewCellEventArgs(0, dgvItem.CurrentCell.RowIndex));
        }

        private void cmbCash_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (cmbCash.ReturnValue != "")
                CashCode = Convert.ToInt32(cmbCash.ReturnValue);
            if ((!MultiSalePurAC) && (chkCash.Checked))
            {
                cmbSales.PopUp();
            }
            else if (chkCash.Checked)
            {
                dgvItem.Focus();
                if (dgvItem.Rows.Count <= 0)
                    dgvItem.Rows.Add();
                dgvItem.ClearSelection();
                dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[0].Selected = true;
                dgvItem.CurrentCell = dgvItem[0, dgvItem.CurrentCell.RowIndex];
                //return;
            }
        }

        private void cmbCash_DropDown(object sender, EventArgs e)
        {
            edpcon.Close();
            edpcon.Open();
            cmbCash.CommandString = "SELECT LDESC,GLCODE FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND (SGROUP=14 or SGROUP=15)";
            cmbCash.Heading = "Select Cash A/C";
            cmbCash.Connection = edpcon.mycon;
            cmbCash.ReturnIndex = 1;
        }

        private void cmbCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                cmbCash.PopUp(sender, new EventArgs());
        }

        private void RBItemDetail_Click(object sender, EventArgs e)
        {
            if (RBItemDetail.Checked)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
            }
        }

        private void RBAddless_Click(object sender, EventArgs e)
        {
            if (RBAddless.Checked)
            {
                panel2.Visible = true;
                panel1.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
            }
        }

        private void RBNarration_Click(object sender, EventArgs e)
        {
            if (RBNarration.Checked)
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel4.Visible = false;
                panel3.Visible = true;
            }
        }

        private void rbtAdditional_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
        }

        private void txtcurrency_DropDown(object sender, EventArgs e)
        {
            edpcon.Close();
            edpcon.Open();
            txtcurrency.CommandString = "select curr_desc as 'CURRENCY',curr_code as 'Code' from currency where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' ";
            txtcurrency.Heading = "Select Currency";
            txtcurrency.Connection = edpcon.mycon;
            txtcurrency.ReturnIndex = 1;
        }

        private void txtcurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                txtcurrency.PopUp(sender, new EventArgs());
        }

        private void txtcurrency_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (txtcurrency.ReturnValue != "")
                currcode = Convert.ToInt32(txtcurrency.ReturnValue);
        }

        private void txtDesc_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (txtDesc.ReturnValue != "")
            {
                Desccode = Convert.ToInt64(txtDesc.ReturnValue);
                txtvoucher.Text = edpcom.GetDocNumber(Desccode, Convert.ToString(Tentry));
            }
            else Desccode = 0;
        }

        private void txtDesc_DropDown(object sender, EventArgs e)
        {
            cmbAct.Text = "ADD";
            if (cmbAct.Text == "ADD")
            {
                edpcon.Close();
                edpcon.Open();
                txtDesc.CommandString = "select type_desc as 'Description',desccode as 'Code'  from typedoc where ficode='" + edpcom.CurrentFicode + "'and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + Tentry + "'";
                txtDesc.Heading = "Select Descripton";
                txtDesc.Connection = edpcon.mycon;
                txtDesc.ReturnIndex = 1;
            }
        }

        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = "";
                try
                {
                    if (e.ColumnIndex == 2 && dgvItem.Columns[2].HeaderText == "Unit" && Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) > 0 && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE"))//SB 
                    {
                        string str = "SELECT DISTINCT U.UDESC,U.UCODE FROM UNIT U,UnitSeriesMaster US,IGLMST IG WHERE IG.FICODE='" + edpcom.CurrentFicode + "' AND IG.GCODE='" + edpcom.PCURRENT_GCODE + "' AND"
                        + " IG.Series_ID=US.SM_ID AND IG.FICODE=US.FICODE AND IG.GCODE=US.GCODE AND IG.FICODE=U.FICODE AND IG.GCODE=U.GCODE AND U.UCODE=US.UCODE AND IG.SERIES_ID= " + dgvItem.Rows[e.RowIndex].Cells[10].Value + " ";
                        frmProductMaster AM = new frmProductMaster();
                        AM.OpenPage(0, "ADD");
                        common.LOV("SELECT UNIT DESC.", str, textBox1, 1, AM, true, "Click here to create new Product");
                        if (common.LOVRESULT == "NO")
                        {
                            common.LOVRESULT = null;
                            return;
                        }
                        //dgvItem.Rows[e.RowIndex].Cells[2].Value = textBox1.Text;
                        if (textBox1.Text.Trim() != "")
                            dgvItem.Rows[e.RowIndex].Cells[2].Value = textBox1.Text;
                        else
                            dgvItem.Rows[e.RowIndex].Cells[2].Value = common.LovReturnText;
                        dgvItem.Rows[e.RowIndex].Cells[9].Value = common.LovReturnValue;

                        if (Flag_Printing == false)
                        {
                            //if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[41].Value))
                            //{
                            //    //if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[1].Value))
                            //    //    dgvItem.Rows[e.RowIndex].Cells[42].Value = edpcom.GetresultS(" select distinct conv_fig * " + Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) + " from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[41].Value) + "");
                            //    dgvItem.Rows[e.RowIndex].Cells[40].Value = textBox1.Text;
                            //    dgvItem.Rows[e.RowIndex].Cells[41].Value = common.LovReturnValue;
                            //    dgvItem.Rows[e.RowIndex].Cells[42].Value = dgvItem.Rows[e.RowIndex].Cells[1].Value;

                            //}
                            //else
                            {
                                dgvItem.Rows[e.RowIndex].Cells[40].Value = textBox1.Text;
                                dgvItem.Rows[e.RowIndex].Cells[41].Value = common.LovReturnValue;
                                if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[1].Value))
                                    dgvItem.Rows[e.RowIndex].Cells[42].Value = dgvItem.Rows[e.RowIndex].Cells[1].Value;
                            }
                        }
                    }
                    if (e.ColumnIndex == 40 && dgvItem.Columns[40].HeaderText == "Printing Qty. Unit" && Flag_Printing == false && Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[10].Value) == true)//SB 
                    {
                        if (Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) > 0)
                        {
                            string str = "SELECT DISTINCT U.UDESC,U.UCODE FROM UNIT U,UnitSeriesMaster US,IGLMST IG WHERE IG.FICODE='" + edpcom.CurrentFicode + "' AND IG.GCODE='" + edpcom.PCURRENT_GCODE + "' AND"
                            + " IG.Series_ID=US.SM_ID AND IG.FICODE=US.FICODE AND IG.GCODE=US.GCODE AND IG.FICODE=U.FICODE AND IG.GCODE=U.GCODE AND U.UCODE=US.UCODE AND IG.SERIES_ID= " + dgvItem.Rows[e.RowIndex].Cells[10].Value + " ";
                            frmProductMaster AM = new frmProductMaster();
                            AM.OpenPage(0, "ADD");
                            common.LOV("SELECT UNIT DESC.", str, textBox1, 1, AM, true, "Click here to create new Product");
                            if (common.LOVRESULT == "NO")
                            {
                                common.LOVRESULT = null;
                                return;
                            }
                            int uc = 0;
                            if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[38].Value))
                            {
                                uc = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[41].Value);
                            }
                            if (textBox1.Text.Trim() != "")
                                dgvItem.Rows[e.RowIndex].Cells[40].Value = textBox1.Text;
                            else
                                dgvItem.Rows[e.RowIndex].Cells[40].Value = common.LovReturnText;
                            //dgvItem.Rows[e.RowIndex].Cells[40].Value = textBox1.Text;
                            dgvItem.Rows[e.RowIndex].Cells[41].Value = common.LovReturnValue;
                            if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[38].Value) && (uc == Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[41].Value)))
                            {
                                dgvItem.Rows[e.RowIndex].Cells[42].Value = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[38].Value);
                            }
                            dgvItem.Rows[e.RowIndex].Cells[42].Value = edpcom.GetresultS(" select distinct conv_fig * " + Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) + " from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[41].Value) + "");
                        }
                    }
                    //if (e.ColumnIndex == 4 && dgvItem.Columns[4].HeaderText == "Rate" && Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) > 0 && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE"))//SB 
                    //{
                    //    string str = "SELECT DISTINCT U.UDESC,U.UCODE FROM UNIT U,UnitSeriesMaster US,IGLMST IG WHERE IG.FICODE='" + edpcom.CurrentFicode + "' AND IG.GCODE='" + edpcom.PCURRENT_GCODE + "' AND"
                    //    + " IG.Series_ID=US.SM_ID AND IG.FICODE=US.FICODE AND IG.GCODE=US.GCODE AND IG.FICODE=U.FICODE AND IG.GCODE=U.GCODE AND U.UCODE=US.UCODE AND IG.SERIES_ID= " + dgvItem.Rows[e.RowIndex].Cells[10].Value + " ";
                    //    frmProductMaster AM = new frmProductMaster();
                    //    AM.OpenPage(0, "ADD");
                    //    common.LOV("SELECT UNIT DESC.", str, textBox1, 1, AM, true, "Click here to create new Product");
                    //    if (common.LOVRESULT == "NO")
                    //    {
                    //        common.LOVRESULT = null;
                    //        return;
                    //    }
                    //   // dgvItem.Rows[e.RowIndex].Cells[2].Value = textBox1.Text;
                    //    dgvItem.Rows[e.RowIndex].Cells[39].Value = common.LovReturnValue;
                    //}
                }
                catch { }

                if (e.ColumnIndex == 0 && dgvItem.Columns[0].HeaderText == "Item Description")
                {
                    string str="";
                    if ((Flag_Printing) && (SBType == "OS" || SBType == "CHLN") && (OrderType=='P'))
                        str = "select distinct ig.pdesc,ig.pcode from iglmst ig where ig.ficode='" + edpcom.CurrentFicode + "' And ig.GCode='" + edpcom.PCURRENT_GCODE + "' And SERVICE='1'";
                    else if (Flag_Printing && OrderType=='O')
                    {
                        str = "select distinct ig.pdesc,ig.pcode from iglmst ig where ig.ficode='" + edpcom.CurrentFicode + "' And ig.GCode='" + edpcom.PCURRENT_GCODE + "' And SERVICE='0' And Series_ID<>0";
                    }
                    else
                        str = "select distinct ig.pdesc,ig.pcode from iglmst ig where ig.ficode='" + edpcom.CurrentFicode + "' And ig.GCode='" + edpcom.PCURRENT_GCODE + "'";
                    frmProductMaster AM = new frmProductMaster();
                    AM.OpenPage(0, "ADD");
                    common.LOV("SELECT PRODUCT NAME", str, textBox1, 1, AM, true, "Click here to create new Product");
                    if (common.LOVRESULT == "NO")
                    {
                        common.LOVRESULT = null;
                        return;
                    }
                    if (textBox1.Text.Trim() != "")
                        dgvItem.Rows[e.RowIndex].Cells[0].Value = textBox1.Text;
                    else
                        dgvItem.Rows[e.RowIndex].Cells[0].Value = common.LovReturnText;

                    dgvItem.Rows[e.RowIndex].Cells[7].Value = common.LovReturnValue;

                    edpcon.Open();
                    common.ClearDataTable(ds.Tables["UnitTable"]);
                    cmd = new SqlCommand("select distinct ig.ucode,ig.series_id,u.udesc,s.SM_NAME,ig.vatpercent,ig.BILLonMRP,ig.AmtCalOnVolume,ig.PaperConsume from iglmst ig,UNIT u ,UnitSeriesMaster s where ig.ficode=u.ficode and ig.gcode=u.gcode and ig.ucode=u.ucode and ig.ficode=s.ficode and ig.gcode=s.gcode and ig.series_id=s.sm_id and ig.FICode='" + edpcom.CurrentFicode + "' And ig.GCode='" + edpcom.PCURRENT_GCODE + "' And ig.pcode=" + common.LovReturnValue + "", edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "UnitTable");
                    edpcon.Close();
                    decimal vatper = 0;
                    if (ds.Tables["UnitTable"].Rows.Count > 0)
                    {
                        dgvItem.Rows[e.RowIndex].Cells["Column12"].Value = ds.Tables["UnitTable"].Rows[0][0].ToString();
                        dgvItem.Rows[e.RowIndex].Cells["Column13"].Value = ds.Tables["UnitTable"].Rows[0][1].ToString();
                        dgvItem.Rows[e.RowIndex].Cells[2].Value = ds.Tables["UnitTable"].Rows[0][2].ToString();
                        dgvItem.Rows[e.RowIndex].Cells[3].Value = ds.Tables["UnitTable"].Rows[0][3].ToString();
                        if ((Flag_Printing) || (Flag_Deying))
                        {
                            dgvItem.Rows[e.RowIndex].Cells[45].Value = ds.Tables["UnitTable"].Rows[0]["PaperConsume"].ToString();
                        }
                        //dgvItem.Rows[e.RowIndex].Cells[39].Value = ds.Tables["UnitTable"].Rows[0][0].ToString();
                        //dgvItem.Rows[e.RowIndex].Cells[40].Value = dgvItem.Rows[e.RowIndex].Cells[2].Value;
                        dgvItem.Rows[e.RowIndex].Cells[44].Value = ds.Tables["UnitTable"].Rows[0]["AmtCalOnVolume"].ToString();
                        if ((SBType == "SALES" || SBType == "PUR") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.4.8.4' ") == "TRUE"))
                        {
                            if (Information.IsNumeric(ds.Tables["UnitTable"].Rows[0][4]) == true)
                            {
                                vatper = Convert.ToDecimal(ds.Tables["UnitTable"].Rows[0][4].ToString());
                                dgvItem.Rows[e.RowIndex].Cells[26].Value = Convert.ToDecimal(ds.Tables["UnitTable"].Rows[0][4].ToString());
                            }
                        }
                        if (Flag_Printing == false && (SBType == "SALES" || SBType == "PUR" || SBType == "OS"))
                        {
                            dgvItem.Rows[e.RowIndex].Cells[4].Value = 0;
                            if (ds.Tables["UnitTable"].Rows[0][5].ToString() == "True")
                            {
                                dgvItem.Rows[e.RowIndex].Cells[4].Value = edpcom.GetresultS("Select Distinct Rate from MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[7].Value)) + " and Rate_Type='M'  and Effective_Date=(select max(Effective_Date) from  MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Rate_Type='M' and Pcode=" + Convert.ToInt32(Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[7].Value)) + " )");
                            }
                            else
                            {
                                dgvItem.Rows[e.RowIndex].Cells[4].Value = edpcom.GetresultS("Select Distinct Rate from MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[7].Value)) + " and Rate_Type='S'  and Effective_Date=(select max(Effective_Date) from  MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Rate_Type='S' and Pcode=" + Convert.ToInt32(Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[7].Value)) + " )");
                            }
                        }

                        string[] a = new string[] { };
                        try
                        {
                            if (Flag_Printing == true)
                                a = ds.Tables["UnitTable"].Rows[0][3].ToString().Trim().Split('-');
                            if (a.Length > 0)
                            {
                                string creatSlash = "";
                                for (int s = 0; s < a.Length - 1; s++)
                                {
                                    creatSlash = "   " + creatSlash + "/" + "   ";
                                }
                                dgvItem.Rows[e.RowIndex].Cells[1].Value = creatSlash;
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        edpcon.Open();
                        common.ClearDataTable(ds.Tables["SingleUnitTable"]);
                        cmd = new SqlCommand("select distinct u.udesc,u.ucode,ig.vatpercent,ig.BILLonMRP,ig.AmtCalOnVolume,ig.PaperConsume from iglmst ig,UNIT u  where ig.ficode=u.ficode and ig.gcode=u.gcode and ig.ucode=u.ucode and ig.FICode='" + edpcom.CurrentFicode + "' And ig.GCode='" + edpcom.PCURRENT_GCODE + "' And ig.pcode=" + common.LovReturnValue + "", edpcon.mycon);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "SingleUnitTable");
                        edpcon.Close();
                        if (ds.Tables["SingleUnitTable"].Rows.Count > 0)
                        {
                            dgvItem.Rows[e.RowIndex].Cells["Column12"].Value = ds.Tables["SingleUnitTable"].Rows[0][1].ToString();
                            dgvItem.Rows[e.RowIndex].Cells["Column13"].Value = 0;
                            dgvItem.Rows[e.RowIndex].Cells[2].Value = ds.Tables["SingleUnitTable"].Rows[0][0].ToString();
                            dgvItem.Rows[e.RowIndex].Cells[3].Value = 0;
                            if (Flag_Printing == true)
                            {
                                dgvItem.Rows[e.RowIndex].Cells[45].Value = ds.Tables["SingleUnitTable"].Rows[0]["PaperConsume"].ToString();
                            }
                            //dgvItem.Rows[e.RowIndex].Cells[39].Value = ds.Tables["SingleUnitTable"].Rows[0][0].ToString();
                            dgvItem.Rows[e.RowIndex].Cells[44].Value = ds.Tables["SingleUnitTable"].Rows[0]["AmtCalOnVolume"].ToString();
                            if ((SBType == "PUR" || SBType == "SALES") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.4.8.4' ") == "TRUE"))
                            {
                                if (Information.IsNumeric(ds.Tables["SingleUnitTable"].Rows[0][2]) == true)
                                    vatper = Convert.ToDecimal(ds.Tables["SingleUnitTable"].Rows[0][2].ToString());
                                dgvItem.Rows[e.RowIndex].Cells[26].Value = Convert.ToDecimal(ds.Tables["SingleUnitTable"].Rows[0][2].ToString());
                            }
                            if (Flag_Printing == false && (SBType == "SALES" || SBType == "PUR" || SBType == "CHLN" || SBType == "OS" || SBType == "PURCHLN" || SBType == "PO"))
                            {
                                if (ds.Tables["SingleUnitTable"].Rows[0][3].ToString() == "True")
                                {
                                    dgvItem.Rows[e.RowIndex].Cells[4].Value = edpcom.GetresultS("Select Distinct Rate from MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[7].Value)) + " and Rate_Type='M'  and Effective_Date=(select max(Effective_Date) from  MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Rate_Type='S' and Pcode=" + Convert.ToInt32(Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[7].Value)) + " )");
                                }
                                else
                                {
                                    dgvItem.Rows[e.RowIndex].Cells[4].Value = edpcom.GetresultS("Select Distinct Rate from MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[7].Value)) + " and Rate_Type='S'  and Effective_Date=(select max(Effective_Date) from  MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Rate_Type='M' and Pcode=" + Convert.ToInt32(Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[7].Value)) + " )");
                                }
                            }
                        }
                    }

                    if ((SBType == "PUR" || SBType == "SALES") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.4.8.4' ") == "TRUE"))
                    {
                        if (vatper > 0)
                        {
                            string query = "";
                            if (SBType == "PUR")
                                query = "SELECT distinct G.LDESC,L.GLCODE FROM LinkVATGLMST L,glmst G,IGLMST I WHERE L.FICODE=G.FICODE AND L.GCODE=G.GCODE AND L.GLCODE=G.GLCODE AND " +
                                  " L.STATE_CODE=" + Edpcom.EDPCommon.CurrentStateCode() + " AND L.FICODE=I.FICODE AND L.GCODE=I.GCODE AND L.VAT_PER=I.VATPERCENT AND I.PCODE=" + dgvItem.Rows[e.RowIndex].Cells[7].Value + " AND L.VAT_PER=" + vatper + " AND L.FICode='" + edpcom.CurrentFicode + "' And L.GCode='" + edpcom.PCURRENT_GCODE + "'  and G.MGROUP=8 AND G.SGROUP=18 AND G.ACTV_FLG='True' ";
                            if (SBType == "SALES")
                                query = "SELECT distinct G.LDESC,L.GLCODE FROM LinkVATGLMST L,glmst G,IGLMST I WHERE L.FICODE=G.FICODE AND L.GCODE=G.GCODE AND L.GLCODE=G.GLCODE AND " +
                                   " L.STATE_CODE=" + Edpcom.EDPCommon.CurrentStateCode() + " AND L.FICODE=I.FICODE AND L.GCODE=I.GCODE AND L.VAT_PER=I.VATPERCENT AND I.PCODE=" + dgvItem.Rows[e.RowIndex].Cells[7].Value + " AND L.VAT_PER=" + vatper + " AND L.FICode='" + edpcom.CurrentFicode + "' And L.GCode='" + edpcom.PCURRENT_GCODE + "'  and G.MGROUP=9 AND G.SGROUP=0 AND G.ACTV_FLG='True' ";

                            DataTable DTDATAVAT = edpcom.GetDatatable(query);
                            if (DTDATAVAT.Rows.Count > 0)
                            {
                                if (DTDATAVAT.Rows.Count == 1)
                                {
                                    query = "SELECT distinct  V.VAT_DESC,V.VAT_CODE,V.AmtBasePercent FROM VATMaster V,LinkVATGLMST L,GLMST G WHERE L.FICODE=V.FICODE AND L.GCODE=V.GCODE AND L.GLCODE=" + Convert.ToInt32(DTDATAVAT.Rows[0][1]) + " AND  " +
                                                             " L.STATE_CODE=V.STATE_CODE AND L.VAT_PER=V.VAT_PERCENT AND L.VAT_PER=" + vatper + " AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND G.GLCODE=V.VAT_CODE AND G.ACTV_FLG='True'  AND L.FICode='" + edpcom.CurrentFicode + "' And L.GCode='" + edpcom.PCURRENT_GCODE + "' AND L.VAT_CODE=V.VAT_CODE ";
                                    DataTable DTtaxAVAT = edpcom.GetDatatable(query);
                                    if (DTtaxAVAT.Rows.Count > 0)
                                    {
                                        if (DTtaxAVAT.Rows.Count == 1)
                                        {

                                            dgvItem.Rows[e.RowIndex].Cells[21].Value = DTtaxAVAT.Rows[0][0].ToString().Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[23].Value = DTtaxAVAT.Rows[0][1].ToString().Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[20].Value = DTDATAVAT.Rows[0][0].ToString().Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[22].Value = DTDATAVAT.Rows[0][1].ToString().Trim();
                                        }
                                        else
                                        {
                                            common.LOV("SELECT VAT NAME", DTtaxAVAT, textBox1, 1);
                                            if (common.LOVRESULT == "NO")
                                            {
                                                common.LOVRESULT = null;
                                                return;
                                            }
                                            dgvItem.Rows[e.RowIndex].Cells[21].Value = textBox1.Text.Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[23].Value = common.LovReturnValue;
                                            dgvItem.Rows[e.RowIndex].Cells[20].Value = DTDATAVAT.Rows[0][0].ToString().Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[22].Value = DTDATAVAT.Rows[0][1].ToString().Trim();
                                        }
                                    }
                                }
                                else
                                {
                                    common.LOV("SELECT VAT NAME", DTDATAVAT, textBox1, 1);

                                    if (common.LOVRESULT == "NO")
                                    {
                                        common.LOVRESULT = null;
                                        return;
                                    }
                                    Int32 V_code = Convert.ToInt32(common.LovReturnValue);
                                    string V_Desc = textBox1.Text.Trim();

                                    query = "SELECT distinct  V.VAT_DESC,V.VAT_CODE ,V.AmtBasePercent FROM VATMaster V,LinkVATGLMST L,GLMST G  WHERE L.FICODE=V.FICODE AND L.GCODE=V.GCODE AND L.GLCODE=" + Convert.ToInt32(common.LovReturnValue) + " AND  " +
                                                             " L.STATE_CODE=V.STATE_CODE AND L.VAT_PER=V.VAT_PERCENT AND L.VAT_PER=" + vatper + " AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND G.GLCODE=V.VAT_CODE AND G.ACTV_FLG='True' AND L.FICode='" + edpcom.CurrentFicode + "' And L.GCode='" + edpcom.PCURRENT_GCODE + "' AND L.VAT_CODE=V.VAT_CODE ";
                                    DataTable DTtaxAVATmAIN = edpcom.GetDatatable(query);
                                    if (DTtaxAVATmAIN.Rows.Count > 0)
                                    {
                                        if (DTtaxAVATmAIN.Rows.Count == 1)
                                        {
                                            dgvItem.Rows[e.RowIndex].Cells[21].Value = DTtaxAVATmAIN.Rows[0][0].ToString().Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[23].Value = DTtaxAVATmAIN.Rows[0][1].ToString().Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[20].Value = textBox1.Text.Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[22].Value = common.LovReturnValue;
                                        }
                                        else
                                        {
                                            common.LOV("SELECT VAT NAME", DTtaxAVATmAIN, textBox1, 1);
                                            if (common.LOVRESULT == "NO")
                                            {
                                                common.LOVRESULT = null;
                                                return;
                                            }
                                            dgvItem.Rows[e.RowIndex].Cells[21].Value = textBox1.Text.Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[23].Value = common.LovReturnValue;
                                            dgvItem.Rows[e.RowIndex].Cells[20].Value = V_Desc;
                                            dgvItem.Rows[e.RowIndex].Cells[22].Value = V_code;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            EDPMessage.Show("No Vat leger match.Please select or insert the vat .", "Information");
                            dgvItem_CellDoubleClick(sender, new DataGridViewCellEventArgs(20, dgvItem.CurrentCell.RowIndex));
                        }

                        //}
                    }
                    try
                    {
                        dgvItem.Focus();
                        dgvItem.ClearSelection();
                        dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[1].Selected = true;
                        dgvItem.CurrentCell = dgvItem[1, dgvItem.CurrentCell.RowIndex];
                        return;
                    }
                    catch { }
                }
                //====================================
                if (e.ColumnIndex == 30)
                {
                    string str;                   
                    if ((Flag_Printing) && (SBType == "OS" || SBType == "CHLN"))
                        str = "select distinct ig.pdesc,ig.pcode from iglmst ig where ig.ficode='" + edpcom.CurrentFicode + "' And ig.GCode='" + edpcom.PCURRENT_GCODE + "' And SERVICE='0' AND Series_ID=0";
                    else
                        str = "select distinct ig.pdesc,ig.pcode from iglmst ig where ig.ficode='" + edpcom.CurrentFicode + "' And ig.GCode='" + edpcom.PCURRENT_GCODE + "'";

                    frmProductMaster AM = new frmProductMaster();
                    AM.OpenPage(0, "ADD");
                    AM.GetingValue(true);
                    common.LOV("SELECT PRODUCT NAME", str, textBox1, 1, AM, true, "Click here to create new Product");
                    if (common.LOVRESULT == "NO")
                    {
                        common.LOVRESULT = null;
                        return;
                    }
                    if (textBox1.Text.Trim() != "")
                        dgvItem.Rows[e.RowIndex].Cells[30].Value = textBox1.Text;
                    else
                        dgvItem.Rows[e.RowIndex].Cells[30].Value = common.LovReturnText;
                    //dgvItem.Rows[e.RowIndex].Cells[30].Value = textBox1.Text;
                    dgvItem.Rows[e.RowIndex].Cells[31].Value = common.LovReturnValue;

                    edpcon.Open();
                    common.ClearDataTable(ds.Tables["SingleUnitTable"]);
                    cmd = new SqlCommand("select distinct u.udesc,u.ucode,ig.vatpercent from iglmst ig,UNIT u  where ig.ficode=u.ficode and ig.gcode=u.gcode and ig.ucode=u.ucode and ig.FICode='" + edpcom.CurrentFicode + "' And ig.GCode='" + edpcom.PCURRENT_GCODE + "' And ig.pcode=" + common.LovReturnValue + "", edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "SingleUnitTable");
                    edpcon.Close();
                    if (ds.Tables["SingleUnitTable"].Rows.Count > 0)
                    {
                        dgvItem.Rows[e.RowIndex].Cells[33].Value = ds.Tables["SingleUnitTable"].Rows[0][0].ToString();
                        dgvItem.Rows[e.RowIndex].Cells[34].Value = ds.Tables["SingleUnitTable"].Rows[0][1].ToString();
                    }
                }
                //====================================
                if (e.ColumnIndex == 20 && (SBType == "PUR" || SBType == "SALES"))
                {
                    char RateType;
                    if (SBType == "PUR")
                        RateType = 'M';
                    else
                        RateType = 'S';
                    TextBox txb = new TextBox();
                    string qry = "";
                    Finance.frmLedgerOpen AM = new Finance.frmLedgerOpen();
                    if (Tentry == "9" || Tentry == "SR")
                        qry = "SELECT LDESC,GLCODE FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND SGROUP=0 AND MGROUP=9 AND ACTV_FLG='True'";
                    else if (Tentry == "8" || Tentry == "PR")
                        qry = "SELECT LDESC,GLCODE FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND SGROUP=18 AND MGROUP=8 AND ACTV_FLG='True'";
                    common.LOV("SELECT LEGER NAME", qry, txb, 1, AM, true, "Click here to create new Leger");
                    if (common.LOVRESULT == "NO")
                    {
                        common.LOVRESULT = null;
                        return;
                    }
                    dgvItem.Rows[e.RowIndex].Cells[20].Value = txb.Text;
                    dgvItem.Rows[e.RowIndex].Cells[22].Value = common.LovReturnValue;
                    DataTable dtAmtBasePer = edpcom.GetDatatable("SELECT AmtBasePercent FROM iglmst WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' AND pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " ");
                    DataTable dtvat = edpcom.GetDatatable("SELECT v.VAT_DESC,v.VAT_CODE,l.vat_per,v.AmtBasePercent FROM VATMaster v, LinkVATGLMST l WHERE l.FICODE='" + EDPComm.CurrentFicode + "' AND l.GCODE='" + EDPComm.PCURRENT_GCODE + "' AND v.VAT_CODE=l.VAT_CODE and l.glcode=" + Convert.ToInt32(common.LovReturnValue) + " ");
                    if (dtvat.Rows.Count > 0)
                    {
                        dgvItem.Rows[e.RowIndex].Cells[21].Value = dtvat.Rows[0][0].ToString().Trim();
                        dgvItem.Rows[e.RowIndex].Cells[23].Value = Convert.ToInt32(dtvat.Rows[0][1]);
                        dgvItem.Rows[e.RowIndex].Cells[26].Value = Convert.ToDouble(dtvat.Rows[0][2]);

                        if (Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[26].Value) > 0)
                        {
                            if (Flag_Printing)
                            {
                                dgvItem.Rows[e.RowIndex].Cells[24].Value = ((Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[6].Value)) * (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[26].Value))) / 100;
                                dgvItem.Rows[e.RowIndex].Cells[25].Value = (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[6].Value)) + (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[24].Value));
                            }
                            else
                            {
                                if (edpcom.GetresultS("SELECT VATONMRP FROM IGLMST WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " ") == "True")
                                {
                                    decimal vatmrpprice = Convert.ToDecimal(edpcom.GetresultS("Select Distinct Rate from MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and Rate_Type='M'  and Effective_Date=(select max(Effective_Date) from  MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Rate_Type='M' and Pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " )"));

                                    if ((edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.2'") == "TRUE") || (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11'") == "TRUE"))
                                    {
                                        decimal TotalMrpAmt = vatmrpprice * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[8].Value);
                                        dgvItem.Rows[e.RowIndex].Cells[24].Value = ((Convert.ToDecimal(dtvat.Rows[0][2])) * (TotalMrpAmt - (TotalMrpAmt * Convert.ToDecimal(dtAmtBasePer.Rows[0][0]) / 100)) / 100);//SSSS
                                        dgvItem.Rows[e.RowIndex].Cells[25].Value = (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[6].Value)) + (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[24].Value));
                                    }
                                    else
                                    {
                                        decimal TotalMrpAmt = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * vatmrpprice;
                                        dgvItem.Rows[e.RowIndex].Cells[24].Value = ((Convert.ToDecimal(dtvat.Rows[0][2])) * (TotalMrpAmt - (TotalMrpAmt * Convert.ToDecimal(dtAmtBasePer.Rows[0][0]) / 100)) / 100);//SSSS
                                        dgvItem.Rows[e.RowIndex].Cells[25].Value = (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[6].Value)) + (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[24].Value));
                                    }
                                }
                                else
                                {
                                    decimal vatmrpprice = Convert.ToDecimal(edpcom.GetresultS("Select Distinct Rate from MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and Rate_Type='S'  and Effective_Date=(select max(Effective_Date) from  MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Rate_Type='S' and Pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " )"));
                                    if ((edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.2'") == "TRUE") || (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11'") == "TRUE"))
                                    {
                                        decimal TotalMrpAmt = vatmrpprice * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[8].Value);
                                        dgvItem.Rows[e.RowIndex].Cells[24].Value = ((Convert.ToDecimal(dtvat.Rows[0][2])) * (TotalMrpAmt - (TotalMrpAmt * Convert.ToDecimal(dtAmtBasePer.Rows[0][0]) / 100)) / 100);//SSSS
                                        dgvItem.Rows[e.RowIndex].Cells[25].Value = (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[6].Value)) + (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[24].Value));

                                    }
                                    else
                                    {

                                        decimal TotalMrpAmt = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * vatmrpprice;
                                        dgvItem.Rows[e.RowIndex].Cells[24].Value = ((Convert.ToDecimal(dtvat.Rows[0][2])) * (TotalMrpAmt - (TotalMrpAmt * Convert.ToDecimal(dtAmtBasePer.Rows[0][0]) / 100)) / 100);//SSSS
                                        dgvItem.Rows[e.RowIndex].Cells[25].Value = (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[6].Value)) + (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[24].Value));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void dgvItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (action == "MODIFY" && (SBType == "SALES" || SBType == "PUR"))
                {
                    if (dgvItem.CurrentCell.ColumnIndex == 1 || dgvItem.CurrentCell.ColumnIndex == 4)
                    {
                        if (dgvAddless.Rows.Count > 0)
                        {
                            for (int s = 0; s < dgvAddless.Rows.Count; s++)
                            {
                                if (dgvAddless.Rows[s].Cells[5].Value.ToString() == "31" || dgvAddless.Rows[s].Cells[5].Value.ToString() == "30")
                                {
                                    dgvAddless.Rows.RemoveAt(s);
                                    s = 0;
                                    Flgaddless = false;
                                }
                            }
                        }
                    }
                }

                if (dgvItem.CurrentCell.ColumnIndex == 3)
                {
                    Rate = 0;
                    if (dgvItem.CurrentCell.ColumnIndex == 3)
                    {
                        if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[dgvItem.CurrentCell.ColumnIndex].Value) == false)
                        {
                            if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[dgvItem.CurrentCell.ColumnIndex].Value) == true)
                            {
                                Rate = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[dgvItem.CurrentCell.ColumnIndex].Value);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    //common.ClearDataTable(ds.Tables["GetComForBook"]);
                    //string str = "SELECT StandardCommission FROM BookAgentMasterDetails WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' AND Book_ID=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value) + "";
                    //cmd = new SqlCommand(str, edpcon.mycon);
                    //SqlDataAdapter dac = new SqlDataAdapter(cmd);
                    //dac.Fill(ds, "GetComForBook");
                }
                if (dgvItem.CurrentCell.ColumnIndex == 3)
                {
                    Rate = 0;
                    if (dgvItem.CurrentCell.ColumnIndex == 3)
                    {
                        if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[dgvItem.CurrentCell.ColumnIndex].Value) == false)
                        {
                            if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[dgvItem.CurrentCell.ColumnIndex].Value) == true)
                            {
                                Rate = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[dgvItem.CurrentCell.ColumnIndex].Value);
                            }
                            else
                                return;
                        }
                        else
                            return;
                    }
                    //common.ClearDataTable(ds.Tables["GetComForBook"]);
                    //string str = "SELECT StandardCommission FROM BookAgentMasterDetails WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' AND Book_ID=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value) + "";
                    //cmd = new SqlCommand(str, edpcon.mycon);
                    //SqlDataAdapter dac = new SqlDataAdapter(cmd);
                    //dac.Fill(ds, "GetComForBook");
                }
                if (dgvItem.CurrentCell.ColumnIndex == 5)
                {
                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[5].Value) == true)
                    {
                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value = 0;
                    }
                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[5].Value) == true)
                    {
                        dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[6].Value = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[6].Value) - Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[5].Value);
                    }
                }
                //if (dgvItem.CurrentCell.ColumnIndex == 4)
                //{
                //    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[4].Value) == false)
                //    {
                //        try
                //        {
                //            if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[3].Value) == false)

                //            {
                //                string[] a = new string[] { };
                //                string[] b = new string[] { };
                //                a = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[3].Value.ToString().Trim().Split('-');
                //                b = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value.ToString().Trim().Split('/');
                //                decimal CalCulatedQty = 0;

                //                if ((dgvItem.CurrentCell.ColumnIndex == 4) && (SBType == "SALES" || SBType == "PUR") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE") && (Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) > 0))
                //                {
                //                    int unitcode = Convert.ToInt32(edpcom.GetresultS("select distinct ucode from iglmst where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + ""));
                //                    decimal rate = 0;
                //                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[4].Value))
                //                        rate = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value);

                //                    string convRate = "1";
                //                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[38].Value))//SB
                //                        convRate = dgvItem.Rows[e.RowIndex].Cells[38].Value.ToString();
                //                    else
                //                        convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column12"].Value) + " and unitT=" + unitcode + "");

                //                    if (convRate == null)
                //                    {
                //                        EDPMessage.Show("No series relation Found for this product.Please Create \nseries relation First.", "Information");
                //                        frmUnitRelation url = new frmUnitRelation();
                //                        url.actionstatus("ADD", 1);
                //                        url.getinfoFrmProdMAS(dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString(), Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value), Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value));
                //                        url.ShowDialog();
                //                        convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column12"].Value) + " and unitT=" + unitcode + "");
                //                    }

                //                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDecimal(convRate);
                //                    dgvItem.Rows[e.RowIndex].Cells[6].Value = Convert.ToDecimal(convRate) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value);
                //                }
                //                else
                //                {
                //                    if (a.Length > 1)
                //                    {
                //                        edpcon.Open();
                //                        for (int c = 0; c < a.Length; c++)
                //                        {
                //                            string q = Getresult1("select ucode from unit where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and udesc='" + a[c].Trim() + "'");
                //                            string w = Getresult1("select conv_fig*'" + Convert.ToDecimal(b[c]) + "' from UnitRelationMaster where ficode='" + EDPComm.CurrentFicode + "' and gcode='" + EDPComm.PCURRENT_GCODE + "' and pcode=" + dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[7].Value.ToString().Trim() + " and sm_id=" + dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[10].Value.ToString().Trim() + " and unitf=" + Convert.ToInt32(q) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[9].Value.ToString().Trim()) + " ");
                //                            if (w == null)
                //                            {
                //                                EDPMessage.Show("Please atfirst create Relation between require Units");
                //                                frmUnitRelation ur = new frmUnitRelation();
                //                                ur.actionstatus("ADD", 1);
                //                                ur.ShowDialog();
                //                            }
                //                            CalCulatedQty = CalCulatedQty + Convert.ToDecimal(w);
                //                        }
                //                        edpcon.Close();
                //                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal((CalCulatedQty * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)) - Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value)).ToString(common.SetDecimalPlace(2));
                //                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = CalCulatedQty;
                //                        if (txtAmt.Text == "")
                //                            txtAmt.Text = "0";
                //                        txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();

                //                    }
                //                    else
                //                    {
                //                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal((Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)) - Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value)).ToString(common.SetDecimalPlace(2));
                //                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value);
                //                        if (txtAmt.Text == "")
                //                            txtAmt.Text = "0";
                //                        txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                if ((dgvItem.CurrentCell.ColumnIndex == 4) && (SBType == "SALES" || SBType == "PUR") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE"))
                //                {
                //                }
                //                else
                //                {
                //                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal((Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)) - Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value)).ToString(common.SetDecimalPlace(2));
                //                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value);
                //                    if (txtAmt.Text == "")
                //                        txtAmt.Text = "0";
                //                    txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();
                //                }
                //            }
                //        }
                //        catch { edpcon.Close(); }
                //    }
                //}

                if (dgvItem.CurrentCell.ColumnIndex == 4)
                {
                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[4].Value) == false)
                    {
                        try
                        {
                            if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[3].Value) == false)
                            {
                                string[] a = new string[] { };
                                string[] b = new string[] { };
                                a = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[3].Value.ToString().Trim().Split('-');
                                b = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value.ToString().Trim().Split('/');
                                decimal CalCulatedQty = 0;

                                if ((dgvItem.CurrentCell.ColumnIndex == 4) && (SBType == "SALES" || SBType == "PUR" || SBType == "OS" || SBType == "PURCHLN" || SBType == "CHLN") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE") && (Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) > 0))//SB
                                {
                                    int unitcode = Convert.ToInt32(edpcom.GetresultS("select distinct ucode from iglmst where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + ""));
                                    decimal rate = 0;
                                    string RateCalON = "1";
                                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[4].Value))
                                        rate = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value);
                                    string convRate = "1";
                                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[45].Value))//090512
                                        convRate = dgvItem.Rows[e.RowIndex].Cells[45].Value.ToString();
                                    else if (Convert.ToString(unitcode) == dgvItem.Rows[e.RowIndex].Cells[41].Value.ToString().Trim())
                                        convRate = "1";
                                    else
                                        convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + unitcode + "");
                                    //if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[39].Value))//200412
                                    //{
                                    //    RateCalON = convRate;
                                    //}
                                    //else
                                    //    RateCalON = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[39].Value) + "");

                                    if (convRate == null)
                                    {
                                        EDPMessage.Show("No series relation Found for this product.Please Create \nseries relation First.", "Information");
                                        frmUnitRelation url = new frmUnitRelation();
                                        url.actionstatus("ADD", 1);
                                        url.getinfoFrmProdMAS(dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString(), Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value), Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value));
                                        url.ShowDialog();
                                        if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[45].Value))
                                            convRate = dgvItem.Rows[e.RowIndex].Cells[45].Value.ToString();

                                        else if (Convert.ToString(unitcode) == dgvItem.Rows[e.RowIndex].Cells[41].Value.ToString().Trim())
                                            convRate = "1";//090512
                                        else
                                            convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + unitcode + "");

                                        //if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[39].Value))//200412
                                        //    RateCalON = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[39].Value) + "");
                                    }
                                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[38].Value))
                                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[38].Value) * Convert.ToDecimal(convRate);

                                    else
                                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDecimal(convRate);

                                    

                                    //if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[39].Value))//03/05/2012
                                    //    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[42].Value = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value;
                                    //SB==============
                                    //if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[39].Value))
                                    //{
                                    //   // RateCalON = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[39].Value) + "");
                                    //    if (RateCalON !=null )
                                    //    {
                                    //        dgvItem.Rows[e.RowIndex].Cells[6].Value = Convert.ToString( Convert.ToDecimal(( Convert.ToDecimal(RateCalON) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value))).ToString(common.SetDecimalPlace(2)));
                                    //    }
                                    //}
                                    //else
                                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[38].Value))//090512
                                        dgvItem.Rows[e.RowIndex].Cells[6].Value = Convert.ToDecimal(Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[38].Value) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value)).ToString(common.SetDecimalPlace(2));
                                    else
                                        dgvItem.Rows[e.RowIndex].Cells[6].Value = Convert.ToDecimal(Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value)).ToString(common.SetDecimalPlace(2));
                                }
                                else
                                {
                                    if ((a.Length > 1) && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.2' ") == "TRUE"))//SB
                                    {
                                        edpcon.Open();

                                        for (int c = 0; c < a.Length; c++)
                                        {
                                            string q = Getresult1("select ucode from unit where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and udesc='" + a[c].Trim() + "'");
                                            string w = Getresult1("select conv_fig*'" + Convert.ToDecimal(b[c]) + "' from UnitRelationMaster where ficode='" + EDPComm.CurrentFicode + "' and gcode='" + EDPComm.PCURRENT_GCODE + "' and pcode=" + dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[7].Value.ToString().Trim() + " and sm_id=" + dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[10].Value.ToString().Trim() + " and unitf=" + Convert.ToInt32(q) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[9].Value.ToString().Trim()) + " ");
                                            if (w == null)
                                            {
                                                EDPMessage.Show("Please atfirst create Relation between require Units");
                                                frmUnitRelation ur = new frmUnitRelation();
                                                ur.actionstatus("ADD", 1);
                                                ur.ShowDialog();
                                            }
                                            CalCulatedQty = CalCulatedQty + Convert.ToDecimal(w);
                                        }
                                        edpcon.Close();
                                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal((CalCulatedQty * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)) - Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value)).ToString(common.SetDecimalPlace(2));
                                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = CalCulatedQty;
                                        if (txtAmt.Text == "")
                                            txtAmt.Text = "0";
                                        txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();

                                    }
                                    else
                                    {
                                        if (Flag_Printing)
                                        {
                                        }
                                        else
                                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal((Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)) - Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value)).ToString(common.SetDecimalPlace(2));
                                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value);
                                        if (txtAmt.Text == "")
                                            txtAmt.Text = "0";
                                        txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();
                                    }
                                }
                            }
                            else
                            {
                                if ((dgvItem.CurrentCell.ColumnIndex == 4) && (SBType == "SALES" || SBType == "PUR") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE"))
                                {
                                }
                                else
                                {
                                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal((Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)) - Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value)).ToString(common.SetDecimalPlace(2));
                                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value);
                                    if (txtAmt.Text == "")
                                        txtAmt.Text = "0";
                                    txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();
                                }
                            }
                        }
                        catch { edpcon.Close(); }
                    }
                }
                if (dgvItem.CurrentCell.ColumnIndex == 6)
                {
                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[6].Value) == true)
                    {
                        EDPMessageBox.EDPMessage.Show("Quantity should not be blanked", "Information.....");
                        return;
                    }
                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[6].Value) != true)
                    {
                        EDPMessageBox.EDPMessage.Show("Quantity should be numeric", "Information.....");
                        return;
                    }
                }

                if (dgvItem.CurrentCell.ColumnIndex == 1 && Flag_Printing == false && (SBType == "SALES" || SBType == "PUR" || SBType == "OS"))
                {
                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[1].Value) == false)
                    {
                        if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[10].Value))
                        {
                            if (Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[10].Value) > 0)
                            {
                                //string[] a = new string[] { };
                                //string[] b = new string[] { };
                                //a = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[3].Value.ToString().Trim().Split('-');
                                //string q = Getresult1("select ucode from unit where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and udesc='" + a[0].Trim() + "'");
                                //string w = Getresult1("select conv_fig*'" + Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[1].Value) + "' from UnitRelationMaster where ficode='" + EDPComm.CurrentFicode + "' and gcode='" + EDPComm.PCURRENT_GCODE + "' and pcode=" + dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[7].Value.ToString().Trim() + " and sm_id=" + dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[10].Value.ToString().Trim() + " and unitf=" + Convert.ToInt32(q) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[9].Value.ToString().Trim()) + " ");
                                //dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = w;
                                //if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value))
                                //    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value) * Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value);
                                //dgvItem_CellEndEdit(sender, new DataGridViewCellEventArgs(4, dgvItem.CurrentCell.RowIndex));
                                // dgvItem_CellLeave(sender, new DataGridViewCellEventArgs(4, dgvItem.CurrentCell.RowIndex));


                                if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[4].Value) == false)
                                {
                                    try
                                    {
                                        if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[3].Value) == false)
                                        {
                                            string[] a = new string[] { };
                                            string[] b = new string[] { };
                                            a = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[3].Value.ToString().Trim().Split('-');
                                            b = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value.ToString().Trim().Split('/');
                                            decimal CalCulatedQty = 0;

                                            if ((SBType == "SALES" || SBType == "PUR") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE") && (Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) > 0))
                                            {
                                                int unitcode = Convert.ToInt32(edpcom.GetresultS("select distinct ucode from iglmst where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + ""));
                                                decimal rate = 0;
                                                string RateCalON = "1";
                                                if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[4].Value))
                                                    rate = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value);
                                                string convRate = "1";
                                                if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[45].Value))
                                                    convRate = dgvItem.Rows[e.RowIndex].Cells[45].Value.ToString();
                                                else
                                                    convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column12"].Value) + " and unitT=" + unitcode + "");
                                                //if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[38].Value))//200412
                                                //    RateCalON = dgvItem.Rows[e.RowIndex].Cells[38].Value.ToString();
                                                //else 
                                                //    RateCalON = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[39].Value) + "");

                                                if (convRate == null)
                                                {
                                                    EDPMessage.Show("No series relation Found for this product.Please Create \nseries relation First.", "Information");
                                                    frmUnitRelation url = new frmUnitRelation();
                                                    url.actionstatus("ADD", 1);
                                                    url.getinfoFrmProdMAS(dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString(), Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value), Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value));
                                                    url.ShowDialog();
                                                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[45].Value))
                                                        convRate = dgvItem.Rows[e.RowIndex].Cells[45].Value.ToString();
                                                    else
                                                        convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column12"].Value) + " and unitT=" + unitcode + "");
                                                    //if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[39].Value))//200412
                                                    //    RateCalON = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[39].Value) + "");
                                                }

                                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(convRate) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value);
                                                //SB========================================
                                                //if (Flag_Printing == false && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE") && Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[39].Value))//200412
                                                //{
                                                //    //int unitcodeee = Convert.ToInt32(edpcom.GetresultS("select distinct ucode from iglmst where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + ""));
                                                //    //convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) + " and unitF=" + unitcode + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[39].Value) + "");
                                                //    dgvItem.Rows[e.RowIndex].Cells[6].Value =Convert.ToDecimal( Convert.ToDecimal(RateCalON) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value)).ToString(common.SetDecimalPlace(2));
                                                //}
                                                //else
                                                dgvItem.Rows[e.RowIndex].Cells[6].Value = Convert.ToDecimal(Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value)).ToString(common.SetDecimalPlace(2));
                                            }
                                            else
                                            {
                                                if (a.Length > 1 && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.2' ") == "TRUE"))
                                                {
                                                    edpcon.Open();
                                                    for (int c = 0; c < a.Length; c++)
                                                    {
                                                        string q = Getresult1("select ucode from unit where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and udesc='" + a[c].Trim() + "'");
                                                        string w = Getresult1("select conv_fig*'" + Convert.ToDecimal(b[c]) + "' from UnitRelationMaster where ficode='" + EDPComm.CurrentFicode + "' and gcode='" + EDPComm.PCURRENT_GCODE + "' and pcode=" + dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[7].Value.ToString().Trim() + " and sm_id=" + dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[10].Value.ToString().Trim() + " and unitf=" + Convert.ToInt32(q) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[9].Value.ToString().Trim()) + " ");
                                                        if (w == null)
                                                        {
                                                            EDPMessage.Show("Please atfirst create Relation between require Units");
                                                            frmUnitRelation ur = new frmUnitRelation();
                                                            ur.actionstatus("ADD", 1);
                                                            ur.ShowDialog();
                                                        }
                                                        CalCulatedQty = CalCulatedQty + Convert.ToDecimal(w);
                                                    }
                                                    edpcon.Close();
                                                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal((CalCulatedQty * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)) - Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value)).ToString(common.SetDecimalPlace(2));
                                                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = CalCulatedQty;
                                                    if (txtAmt.Text == "")
                                                        txtAmt.Text = "0";
                                                    txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();

                                                }
                                                else
                                                {
                                                    if (Flag_Printing)
                                                    {
                                                    }
                                                    else
                                                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal((Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)) - Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value)).ToString(common.SetDecimalPlace(2));
                                                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value);
                                                    if (txtAmt.Text == "")
                                                        txtAmt.Text = "0";
                                                    txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if ((dgvItem.CurrentCell.ColumnIndex == 4) && (SBType == "SALES" || SBType == "PUR") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE"))
                                            {
                                            }
                                            else
                                            {
                                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal((Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)) - Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value)).ToString(common.SetDecimalPlace(2));
                                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value);
                                                if (txtAmt.Text == "")
                                                    txtAmt.Text = "0";
                                                txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();
                                            }
                                        }
                                    }
                                    catch { edpcon.Close(); }

                                }
                            }
                            else
                            {
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value;
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value) * Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value);
                            }
                        }
                        else
                        {
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value;
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value) * Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value);
                        }
                    }
                    if (SBType == "SALES" || SBType == "PUR")
                    {
                        if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[41].Value))
                        {
                            if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[1].Value))
                                dgvItem.Rows[e.RowIndex].Cells[42].Value = edpcom.GetresultS(" select distinct conv_fig * " + Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) + " from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[41].Value) + "");

                        }
                        else
                        {
                            dgvItem.Rows[e.RowIndex].Cells[40].Value = dgvItem.Rows[e.RowIndex].Cells[2].Value;
                            dgvItem.Rows[e.RowIndex].Cells[41].Value = dgvItem.Rows[e.RowIndex].Cells[9].Value;
                            if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[1].Value))
                                dgvItem.Rows[e.RowIndex].Cells[42].Value = dgvItem.Rows[e.RowIndex].Cells[1].Value;
                        }
                    }
                }

                if (dgvItem.CurrentCell.ColumnIndex == 1 && Flag_Printing == true)
                {
                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[3].Value) == false)
                    {
                        string[] a = new string[] { };
                        string[] b = new string[] { };
                        a = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[3].Value.ToString().Trim().Split('-');
                        b = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value.ToString().Trim().Split('/');
                        if (a.Length != b.Length)
                        {
                            string aa = "";
                            for (int q = 0; q < a.Length - 1; q++)
                            {
                                aa = aa + "000/";
                            }
                            aa = aa + "000";
                            return;
                        }
                        if (a.Length == b.Length)
                        {
                            for (int q = 0; q < a.Length; q++)
                            {
                                if (Information.IsNumeric(b[q]) == false)
                                {
                                    EDPMessage.Show("The '" + a[q] + "' Quantity should be Numeric Value in the Quantity Columns.");
                                    return;
                                }
                            }
                        }
                    }
                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[4].Value) == false)
                    {
                        try
                        {
                            if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[3].Value) == false)
                            {
                                string[] a = new string[] { };
                                string[] b = new string[] { };
                                a = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[3].Value.ToString().Trim().Split('-');
                                b = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value.ToString().Trim().Split('/');
                                decimal CalCulatedQty = 0;
                                if (a.Length > 1)
                                {
                                    edpcon.Open();
                                    for (int c = 0; c < a.Length; c++)
                                    {
                                        string q = Getresult1("select ucode from unit where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and udesc='" + a[c].Trim() + "'");
                                        string w = Getresult1("select conv_fig*'" + Convert.ToDecimal(b[c]) + "' from UnitRelationMaster where ficode='" + EDPComm.CurrentFicode + "' and gcode='" + EDPComm.PCURRENT_GCODE + "' and pcode=" + dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[7].Value.ToString().Trim() + " and sm_id=" + dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[10].Value.ToString().Trim() + " and unitf=" + Convert.ToInt32(q) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[9].Value.ToString().Trim()) + " ");
                                        if (w == null)
                                        {
                                            EDPMessage.Show("Please atfirst create Relation between require Units");
                                            frmUnitRelation ur = new frmUnitRelation();
                                            ur.actionstatus("ADD", 1);
                                            ur.ShowDialog();
                                        }
                                        CalCulatedQty = CalCulatedQty + Convert.ToDecimal(w);
                                    }
                                    edpcon.Close();
                                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal(CalCulatedQty * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)).ToString(common.SetDecimalPlace(2));
                                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = CalCulatedQty.ToString(common.SetDecimalPlace(6));
                                    if (txtAmt.Text == "")
                                        txtAmt.Text = "0";
                                    txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString(common.SetDecimalPlace(2));
                                }
                                else
                                {
                                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal(Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)).ToString(common.SetDecimalPlace(2));
                                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value);
                                    if (txtAmt.Text == "")
                                        txtAmt.Text = "0";
                                    txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();
                                }
                            }
                            else
                            {
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal(Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)).ToString(common.SetDecimalPlace(2));
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value);
                                if (txtAmt.Text == "")
                                    txtAmt.Text = "0";
                                txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();
                            }
                        }
                        catch { edpcon.Close(); }
                    }
                }
                if (dgvItem.CurrentCell.ColumnIndex == 18 && Flag_Printing == true)
                {
                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[18].Value) == false)
                    {
                        string[] a = new string[] { };
                        string[] b = new string[] { };
                        a = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[3].Value.ToString().Trim().Split('-');
                        b = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[18].Value.ToString().Trim().Split('/');
                        if (a.Length != b.Length)
                        {
                            string aa = "";
                            for (int q = 0; q < a.Length - 1; q++)
                            {
                                aa = aa + "000/";
                            }
                            aa = aa + "000";
                            EDPMessage.Show("The Input Format does not match with the Unit series.It will be like  " + aa + "");
                            return;
                        }
                        if (a.Length == b.Length)
                        {
                            for (int q = 0; q < a.Length; q++)
                            {
                                if (Information.IsNumeric(b[q]) == false)
                                {
                                    EDPMessage.Show("The '" + a[q] + "' Quantity should be Numeric Value in the Quantity Columns.");
                                    return;
                                }
                            }
                        }
                    }
                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[18].Value) == false)
                    {
                        int scode = 0;
                        if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[10].Value) == false)
                            scode = Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[10].Value);

                        string freeqtBasQt = common.BalQtyCalCulation(Convert.ToString(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[18].Value), Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value), Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value), scode);
                        if (freeqtBasQt == null)
                            dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[19].Value = 0;
                        else
                            dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[19].Value = freeqtBasQt;
                    }
                }
                if (dgvItem.CurrentCell.ColumnIndex == 4 && (SBType == "SALES" || SBType == "PUR"))
                {
                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[26].Value) && Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[23].Value))
                    {
                        decimal amtBase = 0;
                        amtBase = Convert.ToDecimal(edpcom.GetresultS("select distinct AmtBasePercent from VATMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and vat_code=" + dgvItem.Rows[e.RowIndex].Cells[23].Value + "  "));
                        if (flgMrpVat == true)
                        {
                            char RateType;
                            if (SBType == "PUR")
                                RateType = 'M';
                            else
                                RateType = 'S';

                            DataTable dtMrp = edpcom.GetDatatable("Select Distinct Rate from MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[7].Value)) + " and Rate_Type='" + RateType + "' and Rate>0   and Effective_Date=(select max(Effective_Date) from  MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Rate_Type='" + RateType + "' and Pcode=" + Convert.ToInt32(Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[7].Value)) + " )");
                            if (dtMrp.Rows.Count > 0)
                            {
                                decimal TotalMrpAmt = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDecimal(dtMrp.Rows[0][0]);
                                dgvItem.Rows[e.RowIndex].Cells[24].Value = ((Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[26].Value)) * (TotalMrpAmt - (TotalMrpAmt * amtBase / 100)) / 100);
                                dgvItem.Rows[e.RowIndex].Cells[25].Value = (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[6].Value)) + (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[24].Value));
                            }
                            else
                            {
                                EDPMessage.Show("MRP not found.Please Insert MRP.", "Information");
                                frmProductMaster pm = new frmProductMaster();
                                pm.OpenPage(Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[6].Value), "MODIFY");
                                pm.ShowDialog();
                                DataTable dtMrpp = edpcom.GetDatatable("Select Distinct Rate from MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[7].Value)) + "  and Rate_Type='" + RateType + "' and Rate>0 and Effective_Date=(select max(Effective_Date) from  MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Rate_Type='" + RateType + "' and Pcode=" + Convert.ToInt32(Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[7].Value)) + " )");
                                if (dtMrpp.Rows.Count > 0)
                                {
                                    decimal TotalMrpAmt = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDecimal(dtMrpp.Rows[0][0]);
                                    dgvItem.Rows[e.RowIndex].Cells[24].Value = ((Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[26].Value)) * (TotalMrpAmt - (TotalMrpAmt * amtBase / 100)) / 100);
                                    dgvItem.Rows[e.RowIndex].Cells[25].Value = (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[6].Value)) + (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[24].Value));
                                }
                                else
                                {
                                    EDPMessage.Show("Please Input Price Greater than Zero.", "Information");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            dgvItem.Rows[e.RowIndex].Cells[24].Value = ((Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[26].Value)) * ((Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[6].Value)) - ((Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[6].Value)) * amtBase / 100))) / 100;
                            dgvItem.Rows[e.RowIndex].Cells[25].Value = (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[6].Value)) + (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[24].Value));
                        }
                    }
                }
                if (dgvItem.CurrentCell.ColumnIndex == 1)
                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[32].Value = dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[1].Value;
            }
            catch { }
        }

        private void dgvItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    dgvItem_CellDoubleClick(sender, new DataGridViewCellEventArgs(dgvItem.CurrentCell.ColumnIndex, dgvItem.CurrentCell.RowIndex));
                }
                if ((e.KeyCode == Keys.Space) && (SBType == "SALES" || SBType == "PUR" || SBType == "OS") && (dgvItem.CurrentCell.ColumnIndex == 29) && (dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Index > 0) && Flag_Printing == true)
                {
                    if (Convert.ToBoolean(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[29].Value) == true)
                    {
                        dgvItem.CurrentRow.Cells[29].Value = false;
                    }
                    else
                    {
                        dgvItem.CurrentRow.Cells[29].Value = true;
                    }
                }
            }
            catch { }
        }

        private void dgvItem_Enter(object sender, EventArgs e)
        {
            TotalAmt = 0;
            Amt = 0;
            txtAmt.Text = "0.00";
            if ((SBType == "SALES" || SBType == "PUR") && (action == "ADD"))
            {
                txtVoucherChallan.Text = txtvoucher.Text;
                string ss = edpcom.GetresultS(" SELECT DISTINCT USER_VCH FROM IDATA WHERE Ficode='" + edpcom.CurrentFicode + "' And gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + Tentry + "'  And USER_VCH='" + txtvoucher.Text.Trim() + "'");
                if (ss != null)
                {
                    EDPMessage.Show("This voucher already exist.", "Information");
                    txtvoucher.Focus();
                    return;
                }
            }
        }

        private void dgvItem_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int INo = 0, uc = 0;
                double TQty = 0;
                bool chuc = false;               
                lblQty.Visible = true;
                try
                {
                    for (int i = 0; i <= dgvItem.Rows.Count - 1; i++)
                    {
                        if (Information.IsNothing(dgvItem.Rows[i].Cells[0].Value) == false)
                            INo++;
                        if (Information.IsNumeric(dgvItem.Rows[0].Cells[9].Value) == Information.IsNumeric(dgvItem.Rows[i].Cells[9].Value))
                        {
                            if (Convert.ToInt32(dgvItem.Rows[0].Cells[9].Value) != Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value))
                                chuc = true;
                        }
                        TQty = TQty + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value);
                    }
                    if (chuc)
                        lblQty.Visible = false;
                    else
                        lblQty.Text = "Qty  " + TQty.ToString(common.SetDecimalPlace());
                    lblItemNo.Text = "Total Item No  " + Convert.ToString(INo);
                }
                catch { }
                txtAmt.Text = "";
                Qty = 0;
                if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value) == false)
                {
                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value) == true)
                        Qty = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value);
                    else
                        return;
                }

                if (dgvItem.CurrentCell.ColumnIndex == 1 && Information.IsNothing(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value) == true)
                {
                    EDPMessage.Show("Quentity can't be null.Please Insert Quentity.");
                    // dgvItem.CurrentCell = dgvItem[1, dgvItem.CurrentCell.RowIndex];
                    dgvItem.CurrentCell = dgvItem[1, dgvItem.CurrentCell.RowIndex];

                    return;
                }

                if (dgvItem.CurrentCell.ColumnIndex == 4)
                {
                    Rate = 0;

                    if (dgvItem.CurrentCell.ColumnIndex == 4)
                    {
                        if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[dgvItem.CurrentCell.ColumnIndex].Value) == false)
                        {
                            if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[dgvItem.CurrentCell.ColumnIndex].Value) == true)
                            {
                                Rate = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[dgvItem.CurrentCell.ColumnIndex].Value);
                            }
                            else
                                return;
                        }
                        else
                            return;
                    }
                    if (dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value != null)
                    {
                        if (dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value != "")
                            Qty = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value);
                    }
                    if (dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value != null)
                    {
                        if (dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value != "")
                            Rate = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value);
                    }
                    //SB=====================
                    if (Flag_Printing == false && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE") && Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[45].Value))//200412
                    {
                        //string convRate = "1";
                        //int unitcode = Convert.ToInt32(edpcom.GetresultS("select distinct ucode from iglmst where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + ""));   
                        //if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[45].Value))
                        //    convRate = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[45].Value.ToString();                        
                        // else
                        //convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + unitcode + "");
                        //Rate = Rate * Convert.ToDouble(convRate);
                        //dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal(Rate * Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value)).ToString(common.SetDecimalPlace(2));//
                    }
                    else
                    {
                        if (SBType == "SI" || SBType == "STKOUT")
                        {
                            Amt = Qty * Rate;
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Amt.ToString(common.SetDecimalPlace(2));
                        }
                        else
                        {
                            if (!Flag_Printing)
                            {
                                Amt = Qty * Rate;
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Amt.ToString(common.SetDecimalPlace(2));
                            }
                            else
                            {
                                if (SBType == "OS" || SBType == "CHLN" || SBType == "SALES")
                                {
                                    bool F1 = false;
                                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[44].Value) == false)
                                        F1 = Convert.ToBoolean(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[44].Value);
                                    PanelRate.Visible = true;
                                    txtRatingQty.Clear();
                                    txtVolume.Clear();
                                    txtRatingQty.Focus();
                                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[14].Value) == false)
                                        txtVolume.Text = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[14].Value.ToString();
                                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[43].Value) == false)
                                        txtRatingQty.Text = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[43].Value.ToString();
                                    //if (!F1)
                                    //{
                                    //    PanelRate.Width = 160;
                                    //    if (txtRatingQty.Text.Trim() == "")
                                    //        txtRatingQty.Text = "1";
                                    //}
                                    //else
                                    //{
                                        PanelRate.Width = 300;
                                        if (txtRatingQty.Text.Trim() == "")
                                            txtRatingQty.Text = "1000";
                                    //}
                                }
                                else
                                {
                                    Amt = Qty * Rate;
                                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Amt.ToString(common.SetDecimalPlace(2));
                                }
                            }
                        }
                    }
                }
                TotalAmt = 0;
                for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                {
                    try
                    {
                        if (dgvItem.Rows[i].Cells[6].Value != null)
                        {
                            if (dgvItem.Rows[i].Cells[6].Value != "")
                                dgvItem.Rows[i].Cells[27].Value = dgvItem.Rows[i].Cells[6].Value;
                        }

                        //if (dgvItem.Rows[i].Cells[8].Value != null)
                        //{
                        //    if (dgvItem.Rows[i].Cells[8].Value != "")
                        //        Qty = Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value);
                        //}
                        //if (dgvItem.Rows[i].Cells[4].Value != null)
                        //{
                        //    if (dgvItem.Rows[i].Cells[4].Value != "")
                        //        Rate = Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value);
                        //}

                        ////SB======================
                        //if (Flag_Printing == false && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE") && Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[39].Value))
                        //{
                        //    int unitcode = Convert.ToInt32(edpcom.GetresultS("select distinct ucode from iglmst where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + ""));
                        //    string convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) + " and unitF=" + unitcode + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[39].Value) + "");
                        //    Rate = Rate * Convert.ToDouble( convRate);

                        //}
                        //else                       
                        //    Amt = Qty * Rate;
                        TotalAmt = TotalAmt + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value);

                    }
                    catch { }
                }
                for (int i = 0; i <= dgvAddless.RowCount - 1; i++)
                {
                    try
                    {
                        TotalAmt = TotalAmt + Convert.ToDouble(dgvAddless.Rows[i].Cells[3].Value);
                    }
                    catch { }
                }
                txtAmt.Text = TotalAmt.ToString(common.SetDecimalPlace());

                if (dgvItem.CurrentCell.ColumnIndex == 18 && (SBType == "SALES" || SBType == "PUR"))
                {
                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[18].Value) == false)
                    {
                        string[] a = new string[] { };
                        string[] b = new string[] { };
                        a = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[3].Value.ToString().Trim().Split('-');
                        b = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[18].Value.ToString().Trim().Split('/');
                        string ss = "";
                        if (a.Length != b.Length)
                        {
                            string aa = "";
                            for (int q = 0; q < a.Length - 1; q++)
                            {
                                aa = aa + "000/";
                            }
                            aa = aa + "000";
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[18].Value = aa;
                        }
                        else
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[18].Value = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[18].Value.ToString().Replace(" ", "0");
                    }
                }

                if (dgvItem.CurrentCell.ColumnIndex == 18 && (SBType == "SALES" || SBType == "PUR") && Flag_Printing == false)
                {
                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[18].Value) == false)
                    {
                        int unitcode = Convert.ToInt32(edpcom.GetresultS("select distinct ucode from iglmst where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + ""));

                        string convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column12"].Value) + " and unitT=" + unitcode + "");
                        {
                            if (convRate == null)
                            {
                                EDPMessage.Show("No series relation Found for this product.Please Create \nseries relation First.", "Information");
                                frmUnitRelation url = new frmUnitRelation();
                                url.actionstatus("ADD", 1);
                                url.getinfoFrmProdMAS(dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString(), Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value), Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value));
                                url.ShowDialog();
                                convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column12"].Value) + " and unitT=" + unitcode + "");

                            }
                        }
                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[19].Value = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[18].Value) * Convert.ToDecimal(convRate);
                    }

                }

                if (dgvItem.CurrentCell.ColumnIndex == 18 && (SBType == "SALES" || SBType == "PUR") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "FALSE") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.10' ") == "FALSE"))
                {
                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[19].Value = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[18].Value;
                }

                //if (dgvItem.CurrentCell.ColumnIndex == 40)
                //{

                //}

                if (dgvItem.CurrentCell.ColumnIndex == 4)
                {
                    if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[4].Value) == false)
                    {
                        try
                        {
                            if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[3].Value) == false)
                            {
                                string[] a = new string[] { };
                                string[] b = new string[] { };
                                a = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[3].Value.ToString().Trim().Split('-');
                                b = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value.ToString().Trim().Split('/');
                                decimal CalCulatedQty = 0;

                                if ((dgvItem.CurrentCell.ColumnIndex == 4) && (SBType == "SALES" || SBType == "PUR" || SBType == "OS" || SBType == "CHLN") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE") && (Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) > 0))
                                {
                                    int unitcode = Convert.ToInt32(edpcom.GetresultS("select distinct ucode from iglmst where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + ""));
                                    decimal rate = 0;
                                    string RateCalON = "1";
                                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[4].Value))
                                        rate = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value);
                                    string convRate = "1";
                                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[45].Value))
                                        convRate = dgvItem.Rows[e.RowIndex].Cells[45].Value.ToString();
                                    else if (Convert.ToString(unitcode) == dgvItem.Rows[e.RowIndex].Cells[41].Value.ToString())//090512
                                        convRate = "1";

                                    else
                                        convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column12"].Value) + " and unitT=" + unitcode + "");
                                    //if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[38].Value))//200412
                                    //    RateCalON = dgvItem.Rows[e.RowIndex].Cells[38].Value.ToString();
                                    //else 
                                    //    RateCalON = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[39].Value) + "");

                                    if (convRate == null)
                                    {
                                        EDPMessage.Show("No series relation Found for this product.Please Create \nseries relation First.", "Information");
                                        frmUnitRelation url = new frmUnitRelation();
                                        url.actionstatus("ADD", 1);
                                        url.getinfoFrmProdMAS(dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString(), Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value), Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value));
                                        url.ShowDialog();
                                        if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[45].Value))
                                            convRate = dgvItem.Rows[e.RowIndex].Cells[45].Value.ToString();
                                        else if (Convert.ToString(unitcode) == dgvItem.Rows[e.RowIndex].Cells[41].Value.ToString())//090512
                                            convRate = "1";
                                        else
                                            convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column12"].Value) + " and unitT=" + unitcode + "");
                                        //if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[39].Value))//200412
                                        //    RateCalON = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[39].Value) + "");
                                    }
                                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[38].Value))
                                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(convRate) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[38].Value);
                                    else
                                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(convRate) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value);
                                    //SB========================================
                                    //if (Flag_Printing == false && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE") && Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[39].Value))//200412
                                    //{
                                    //    //int unitcodeee = Convert.ToInt32(edpcom.GetresultS("select distinct ucode from iglmst where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + ""));
                                    //    //convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Column13"].Value) + " and unitF=" + unitcode + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[39].Value) + "");
                                    //    dgvItem.Rows[e.RowIndex].Cells[6].Value =Convert.ToDecimal( Convert.ToDecimal(RateCalON) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value)).ToString(common.SetDecimalPlace(2));
                                    //}
                                    //else
                                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[38].Value))
                                        dgvItem.Rows[e.RowIndex].Cells[6].Value = Convert.ToDecimal(Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[38].Value) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value)).ToString(common.SetDecimalPlace(2));
                                    else
                                        dgvItem.Rows[e.RowIndex].Cells[6].Value = Convert.ToDecimal(Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value)).ToString(common.SetDecimalPlace(2));
                                }
                                else
                                {
                                    if (a.Length > 1 && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.2' ") == "TRUE"))
                                    {
                                        edpcon.Open();
                                        for (int c = 0; c < a.Length; c++)
                                        {
                                            string q = Getresult1("select ucode from unit where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and udesc='" + a[c].Trim() + "'");
                                            string w = Getresult1("select conv_fig*'" + Convert.ToDecimal(b[c]) + "' from UnitRelationMaster where ficode='" + EDPComm.CurrentFicode + "' and gcode='" + EDPComm.PCURRENT_GCODE + "' and pcode=" + dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[7].Value.ToString().Trim() + " and sm_id=" + dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[10].Value.ToString().Trim() + " and unitf=" + Convert.ToInt32(q) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[9].Value.ToString().Trim()) + " ");
                                            if (w == null)
                                            {
                                                EDPMessage.Show("Please atfirst create Relation between require Units");
                                                frmUnitRelation ur = new frmUnitRelation();
                                                ur.actionstatus("ADD", 1);
                                                ur.ShowDialog();
                                            }
                                            CalCulatedQty = CalCulatedQty + Convert.ToDecimal(w);
                                        }
                                        edpcon.Close();
                                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal((CalCulatedQty * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)) - Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value)).ToString(common.SetDecimalPlace(2));
                                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = CalCulatedQty;
                                        if (txtAmt.Text == "")
                                            txtAmt.Text = "0";
                                        //txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();
                                        txtAmt.Text = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value).ToString(common.SetDecimalPlace());

                                    }
                                    else
                                    {
                                        if (Flag_Printing)
                                        {
                                        }
                                        else
                                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal((Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)) - Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value)).ToString(common.SetDecimalPlace(2));
                                        dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value);
                                        if (txtAmt.Text == "")
                                            txtAmt.Text = "0";
                                        //txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();
                                        //txtAmt.Text = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value).ToString(common.SetDecimalPlace());
                                    }
                                }
                            }
                            else
                            {
                                if ((dgvItem.CurrentCell.ColumnIndex == 4) && (SBType == "SALES" || SBType == "PUR") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11' ") == "TRUE"))
                                {
                                }
                                else
                                {
                                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value = Convert.ToDecimal((Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[4].Value)) - Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[5].Value)).ToString(common.SetDecimalPlace(2));
                                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[8].Value = Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[1].Value);
                                    if (txtAmt.Text == "")
                                        txtAmt.Text = "0";
                                    //txtAmt.Text = (Convert.ToDouble(txtAmt.Text) + Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value)).ToString();
                                    txtAmt.Text = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[6].Value).ToString(common.SetDecimalPlace());
                                }
                            }

                            //if (Flag_Cash)
                            //{
                            //    dgvItem.RowsAdded();
                            //    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[0].Selected = true;
                            //    dgvItem.CurrentCell = dgvItem[0, dgvItem.CurrentCell.RowIndex];
                            //    dgvItem_CellDoubleClick(sender, new DataGridViewCellEventArgs(0, dgvItem.CurrentCell.RowIndex));
                            //}

                        }
                        catch { edpcon.Close(); }
                    }
                }


                if (dgvItem.CurrentCell.ColumnIndex == 4 && (SBType == "SALES" || SBType == "PUR") && (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.4.8.4' ") == "TRUE") && Information.IsNothing(dgvItem.Rows[e.RowIndex].Cells[22].Value))
                {
                    common.ClearDataTable(ds.Tables["UnitTable"]);
                    edpcon.Open();
                    cmd = new SqlCommand("select distinct vatpercent from iglmst  where FICode='" + edpcom.CurrentFicode + "' And GCode='" + edpcom.PCURRENT_GCODE + "' And pcode=" + dgvItem.Rows[e.RowIndex].Cells[7].Value + "", edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "UnitTable");
                    edpcon.Close();
                    decimal vatper = 0;
                    if (ds.Tables["UnitTable"].Rows.Count > 0)
                    {
                        if (Information.IsNumeric(ds.Tables["UnitTable"].Rows[0][0]) == true)
                        {
                            vatper = Convert.ToDecimal(ds.Tables["UnitTable"].Rows[0][0].ToString());
                            dgvItem.Rows[e.RowIndex].Cells[26].Value = Convert.ToDecimal(ds.Tables["UnitTable"].Rows[0][0].ToString());
                        }
                    }

                    if (SBType == "PUR" || SBType == "SALES")
                    {
                        if (vatper > 0)
                        {
                            string query = "";
                            if (SBType == "PUR")
                                query = "SELECT distinct G.LDESC,L.GLCODE FROM LinkVATGLMST L,glmst G,IGLMST I WHERE L.FICODE=G.FICODE AND L.GCODE=G.GCODE AND L.GLCODE=G.GLCODE AND " +
                                  " L.STATE_CODE=19 AND L.FICODE=I.FICODE AND L.GCODE=I.GCODE AND L.VAT_PER=I.VATPERCENT AND I.PCODE=" + dgvItem.Rows[e.RowIndex].Cells[7].Value + " AND L.VAT_PER=" + vatper + " AND L.FICode='" + edpcom.CurrentFicode + "' And L.GCode='" + edpcom.PCURRENT_GCODE + "'  and G.MGROUP=8 AND G.SGROUP=18 AND G.ACTV_FLG='True' ";
                            if (SBType == "SALES")
                                query = "SELECT distinct G.LDESC,L.GLCODE FROM LinkVATGLMST L,glmst G,IGLMST I WHERE L.FICODE=G.FICODE AND L.GCODE=G.GCODE AND L.GLCODE=G.GLCODE AND " +
                                   " L.STATE_CODE=19 AND L.FICODE=I.FICODE AND L.GCODE=I.GCODE AND L.VAT_PER=I.VATPERCENT AND I.PCODE=" + dgvItem.Rows[e.RowIndex].Cells[7].Value + " AND L.VAT_PER=" + vatper + " AND L.FICode='" + edpcom.CurrentFicode + "' And L.GCode='" + edpcom.PCURRENT_GCODE + "'  and G.MGROUP=9 AND G.SGROUP=0 AND G.ACTV_FLG='True' ";

                            DataTable DTDATAVAT = edpcom.GetDatatable(query);
                            if (DTDATAVAT.Rows.Count > 0)
                            {
                                if (DTDATAVAT.Rows.Count == 1)
                                {
                                    query = "SELECT distinct  V.VAT_DESC,V.VAT_CODE,V.AmtBasePercent FROM VATMaster V,LinkVATGLMST L,GLMST G WHERE L.FICODE=V.FICODE AND L.GCODE=V.GCODE AND L.GLCODE=" + Convert.ToInt32(DTDATAVAT.Rows[0][1]) + " AND  " +
                                                             " L.STATE_CODE=V.STATE_CODE AND L.VAT_PER=V.VAT_PERCENT AND L.VAT_PER=" + vatper + " AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND G.GLCODE=V.VAT_CODE AND G.ACTV_FLG='True'  AND L.FICode='" + edpcom.CurrentFicode + "' And L.GCode='" + edpcom.PCURRENT_GCODE + "' AND L.VAT_CODE=V.VAT_CODE ";
                                    DataTable DTtaxAVAT = edpcom.GetDatatable(query);
                                    if (DTtaxAVAT.Rows.Count > 0)
                                    {
                                        if (DTtaxAVAT.Rows.Count == 1)
                                        {

                                            dgvItem.Rows[e.RowIndex].Cells[21].Value = DTtaxAVAT.Rows[0][0].ToString().Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[23].Value = DTtaxAVAT.Rows[0][1].ToString().Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[20].Value = DTDATAVAT.Rows[0][0].ToString().Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[22].Value = DTDATAVAT.Rows[0][1].ToString().Trim();
                                        }
                                        else
                                        {
                                            common.LOV("SELECT VAT NAME", DTtaxAVAT, textBox1, 1);
                                            if (common.LOVRESULT == "NO")
                                            {
                                                common.LOVRESULT = null;
                                                return;
                                            }
                                            dgvItem.Rows[e.RowIndex].Cells[21].Value = textBox1.Text.Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[23].Value = common.LovReturnValue;
                                            dgvItem.Rows[e.RowIndex].Cells[20].Value = DTDATAVAT.Rows[0][0].ToString().Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[22].Value = DTDATAVAT.Rows[0][1].ToString().Trim();
                                        }
                                    }
                                }
                                else
                                {
                                    common.LOV("SELECT VAT NAME", DTDATAVAT, textBox1, 1);

                                    if (common.LOVRESULT == "NO")
                                    {
                                        common.LOVRESULT = null;
                                        return;
                                    }
                                    Int32 V_code = Convert.ToInt32(common.LovReturnValue);
                                    string V_Desc = textBox1.Text.Trim();

                                    query = "SELECT distinct  V.VAT_DESC,V.VAT_CODE ,V.AmtBasePercent FROM VATMaster V,LinkVATGLMST L,GLMST G  WHERE L.FICODE=V.FICODE AND L.GCODE=V.GCODE AND L.GLCODE=" + Convert.ToInt32(common.LovReturnValue) + " AND  " +
                                                             " L.STATE_CODE=V.STATE_CODE AND L.VAT_PER=V.VAT_PERCENT AND L.VAT_PER=" + vatper + " AND G.FICODE=V.FICODE AND G.GCODE=V.GCODE AND G.GLCODE=V.VAT_CODE AND G.ACTV_FLG='True' AND L.FICode='" + edpcom.CurrentFicode + "' And L.GCode='" + edpcom.PCURRENT_GCODE + "' AND L.VAT_CODE=V.VAT_CODE ";
                                    DataTable DTtaxAVATmAIN = edpcom.GetDatatable(query);
                                    if (DTtaxAVATmAIN.Rows.Count > 0)
                                    {
                                        if (DTtaxAVATmAIN.Rows.Count == 1)
                                        {
                                            dgvItem.Rows[e.RowIndex].Cells[21].Value = DTtaxAVATmAIN.Rows[0][0].ToString().Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[23].Value = DTtaxAVATmAIN.Rows[0][1].ToString().Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[20].Value = textBox1.Text.Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[22].Value = common.LovReturnValue;
                                        }
                                        else
                                        {
                                            common.LOV("SELECT VAT NAME", DTtaxAVATmAIN, textBox1, 1);
                                            if (common.LOVRESULT == "NO")
                                            {
                                                common.LOVRESULT = null;
                                                return;
                                            }
                                            dgvItem.Rows[e.RowIndex].Cells[21].Value = textBox1.Text.Trim();
                                            dgvItem.Rows[e.RowIndex].Cells[23].Value = common.LovReturnValue;
                                            dgvItem.Rows[e.RowIndex].Cells[20].Value = V_Desc;
                                            dgvItem.Rows[e.RowIndex].Cells[22].Value = V_code;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                EDPMessage.Show("No Vat leger match.Please select or insert the vat .", "Information");
                                dgvItem_CellDoubleClick(sender, new DataGridViewCellEventArgs(20, dgvItem.CurrentCell.RowIndex));
                            }
                        }
                    }               
                }
                bool chch = false;
                if ((SBType == "SALES" || SBType == "PUR" || SBType == "OS") && (dgvItem.CurrentCell.ColumnIndex == 29) && (Flag_Printing == true) && dgvItem.CurrentCell.RowIndex > 0)
                {
                    try
                    {
                        if (Convert.ToBoolean(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[29].Value) == true && dgvItem.CurrentRow.Index > 0)
                        {
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[30].Value = dgvItem.Rows[dgvItem.CurrentRow.Index - 1].Cells[30].Value;
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[31].Value = dgvItem.Rows[dgvItem.CurrentRow.Index - 1].Cells[31].Value;
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[32].Value = dgvItem.Rows[dgvItem.CurrentRow.Index - 1].Cells[32].Value;
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[33].Value = dgvItem.Rows[dgvItem.CurrentRow.Index - 1].Cells[33].Value;
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[34].Value = dgvItem.Rows[dgvItem.CurrentRow.Index - 1].Cells[34].Value;
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[35].Value = dgvItem.Rows[dgvItem.CurrentRow.Index - 1].Cells[35].Value;
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[36].Value = dgvItem.Rows[dgvItem.CurrentRow.Index - 1].Cells[36].Value;
                            dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[37].Value = dgvItem.Rows[dgvItem.CurrentRow.Index - 1].Cells[37].Value;
                            chch = true;
                        }
                        if (Convert.ToBoolean(dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[29].Value) == false && dgvItem.CurrentRow.Index > 0)
                        {
                            if (!Flag_Printing)
                            {
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[30].Value = "";
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[31].Value = "";
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[32].Value = "";
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[33].Value = "";
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[34].Value = "";
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[35].Value = "";
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[36].Value = "";
                                dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[37].Value = "";
                            }
                        }
                    }
                    catch { }
                }
                if (!chch)
                {
                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[35].Value = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[14].Value;
                    dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[36].Value = dgvItem.Rows[dgvItem.CurrentRow.Index].Cells[15].Value;
                }
            }
            catch { }
        }

        private string Getresult1(string command)
        {
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
                return data;
            }
            catch
            {
                return null;
            }
        }

        public void PassingValueFromOrder(string PName, int PC, string UVCH, int VN, SqlConnection SC, SqlTransaction ST)
        {
            SQLCNN = SC;
            CHKORD = true;
            Tentry = "SI";
            cmbPartyName.Text = PName;
            PartyCode = PC;
            cmbRefOrd.Text = UVCH;
            Pcode_sl = VN.ToString();
            SQLT = ST;
            cmbAct.SelectedIndex = 0;
            cmbAct_SelectedIndexChanged(cmbAct, new EventArgs());
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            try
            {
                //  string qq = dgvItem.Rows[0].Cells[42].Value.ToString();
                if (action == "MODIFY" && (SBType == "SALES" || SBType == "PUR") && (lbRC.Items.Count == 0) && (Flag_Deying || Flag_Printing))
                {
                    EDPMessage.Show("This Voucher Can't be Modified.", "Information");
                    return;
                }
                if (!validation())
                    return;
                if ((btnAcc.ButtonText.Trim() == "Accept") || (btnAcc.ButtonText.Trim() == "Modify"))
                {
                    //====================================Insert===============================   
                    bool multipleLeger = false;
                    if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.4.8.4' ") == "TRUE")
                    {
                        multipleLeger = true;
                    }

                    int cash = 0;
                    if (action == "MODIFY" && (SBType == "SALES" || SBType == "PUR") && lbRC.Items.Count == 0)
                    {
                    }
                    else
                        ChlnVchNo = "";
                    if (chkCash.Checked)
                    {
                        cash = 1;
                        if (CashCode == 0)
                        {
                            EDPMessage.Show("Cash A/C Ledger can't be null.", "Message");
                            return;
                        }
                    }
                    if (!CHKORD)
                    {
                        edpcon.Open();
                        SQLT = edpcon.mycon.BeginTransaction();
                    }
                    //===============================================
                    if (cmbPartyName.Text.Trim() != "" && PartyCode == 0)
                    {
                        int SG = 0, MG = 0, TF = 0;
                        if (SBType == "SALES" || SBType == "CHLN" || SBType == "SRETURN" || SBType == "OS")
                        {
                            MG = 6; SG = 12; TF = 22;
                        }
                        else if (SBType == "PUR" || SBType == "PURCHLN" || SBType == "PURCHLN" || SBType == "PR")
                        {
                            MG = 3; SG = 5; TF = 23;
                        }
                        common.ClearDataTable(ds.Tables["ds_party"]);
                        cmd = new SqlCommand("select max(glcode) from glmst where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and MType='L'", edpcon.mycon, SQLT);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "ds_party");

                        if (Information.IsDBNull(ds.Tables["ds_party"].Rows[0][0]))
                            PartyCode = 1;
                        else
                        {
                            PartyCode = Convert.ToInt32(ds.Tables["ds_party"].Rows[0][0]);
                            PartyCode++;
                        }
                        cmd = new SqlCommand("insert into glmst(Ficode,GCODE,MType,MGROUP,SGROUP,GLCODE,LDESC,T_FILTER,PREV_GROUP,OP_LBAL,FC_OPLBAL) VALUES('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','L'," + MG + "," + SG + "," + PartyCode + ",'" + cmbPartyName.Text.Trim() + "'," + TF + "," + SG + ",0,0)", edpcon.mycon, SQLT);
                        cmd.ExecuteNonQuery();
                    }
                    //===============================================
                    if (btnAcc.ButtonText.Trim() == "Accept")
                    {
                        common.ClearDataTable(ds.Tables["voucher_no995"]);
                        if (!CHKORD)
                            cmd = new SqlCommand("select max(VOUCHER) from idata where T_entry='" + Tentry + "' and ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "'", edpcon.mycon, SQLT);
                        else
                            cmd = new SqlCommand("select max(VOUCHER) from idata where T_entry='" + Tentry + "' and ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "'", SQLCNN, SQLT);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "voucher_no995");
                        if (Information.IsDBNull(ds.Tables["voucher_no995"].Rows[0][0]))
                        {
                            vno = 1;
                        }
                        else
                        {
                            vno = Convert.ToInt32(ds.Tables["voucher_no995"].Rows[0][0]);
                            vno++;
                        }
                        if ((SBType == "SALES") && (lbRC.Items.Count == 0))
                        {
                            common.ClearDataTable(ds.Tables["voucher_no"]);
                            cmd = new SqlCommand("select max(VOUCHER) from idata where T_entry='n' and ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "'", edpcon.mycon, SQLT);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "voucher_no");
                            if (Information.IsDBNull(ds.Tables["voucher_no"].Rows[0][0]))
                            {
                                RefVno = 1;
                            }
                            else
                            {
                                RefVno = Convert.ToInt32(ds.Tables["voucher_no"].Rows[0][0]);
                                RefVno++;
                            }
                            //ChlnVchNo = edpcom.GetDocNumber(1, Convert.ToString("n"));
                        }
                        if ((SBType == "PUR") && (lbRC.Items.Count == 0))
                        {
                            common.ClearDataTable(ds.Tables["voucher_no"]);
                            cmd = new SqlCommand("select max(VOUCHER) from idata where T_entry='a' and ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "'", edpcon.mycon, SQLT);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "voucher_no");
                            if (Information.IsDBNull(ds.Tables["voucher_no"].Rows[0][0]))
                            {
                                RefVno = 1;
                            }
                            else
                            {
                                RefVno = Convert.ToInt32(ds.Tables["voucher_no"].Rows[0][0]);
                                RefVno++;
                            }
                            //ChlnVchNo = edpcom.GetDocNumber(1, Convert.ToString("a"));
                        }

                        //========== Check The ReffParty is exsist or not

                        common.ClearDataTable(ds.Tables["ReffParty"]);
                        if (!CHKORD)
                            cmd = new SqlCommand("SELECT * FROM ReffPartyDetails WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND PartyCode=" + PartyCode + " AND reffPartyCode=" + ReffPartyCode + "", edpcon.mycon, SQLT);
                        else
                            cmd = new SqlCommand("SELECT * FROM ReffPartyDetails WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND PartyCode=" + PartyCode + " AND reffPartyCode=" + ReffPartyCode + "", SQLCNN, SQLT);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "ReffParty");
                        int RP_ID = 0;
                        if (ds.Tables["ReffParty"].Rows.Count > 0)
                        {
                        }
                        else
                        {
                            common.ClearDataTable(ds.Tables["ReffPartyMAXID"]);
                            if (!CHKORD)
                                cmd = new SqlCommand("select max(RP_ID) from ReffPartyDetails where FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'", edpcon.mycon, SQLT);
                            else
                                cmd = new SqlCommand("select max(RP_ID) from ReffPartyDetails where FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'", SQLCNN, SQLT);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "ReffPartyMAXID");
                            if (Information.IsDBNull(ds.Tables["ReffPartyMAXID"].Rows[0][0]))
                            {
                                RP_ID = 1;
                            }
                            else
                            {
                                RP_ID = Convert.ToInt32(ds.Tables["ReffPartyMAXID"].Rows[0][0]);
                                RP_ID++;
                            }
                            if (PartyCode != 0 && ReffPartyCode != 0)
                            {
                                if (!CHKORD)
                                    cmd = new SqlCommand("insert into ReffPartyDetails(Ficode,GCODE,RP_ID,PartyType,PartyCode,ReffPartyCode) VALUES('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "'," + RP_ID + ",'" + PartyType + "'," + PartyCode + "," + ReffPartyCode + ")", edpcon.mycon, SQLT);
                                else
                                    cmd = new SqlCommand("insert into ReffPartyDetails(Ficode,GCODE,RP_ID,PartyType,PartyCode,ReffPartyCode) VALUES('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "'," + RP_ID + ",'" + PartyType + "'," + PartyCode + "," + ReffPartyCode + ")", SQLCNN, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else if (btnAcc.ButtonText.Trim().ToUpper() == "MODIFY")
                    {
                        btnDel_Click(btnDel, e);
                    }

                    //====================================== Challan To LOG Entry
                    //if (SBType == "CHLN" && action == "ADD" && Flag_Printing == true)
                    //{
                    //    DataTable DTVAL = new DataTable();
                    //    DTVAL.Columns.Add("ItemDesc", typeof(string));
                    //    DTVAL.Columns.Add("Qty", typeof(string));
                    //    DTVAL.Columns.Add("UnitDesc", typeof(string));
                    //    DTVAL.Columns.Add("PCODE", typeof(string));
                    //    DTVAL.Columns.Add("UCODE", typeof(string));

                    //    for (int i = 0; i <= dgvItem.Rows.Count - 1; i++)
                    //    {
                    //        DTVAL.Rows.Add();
                    //        DTVAL.Rows[i][0] = dgvItem.Rows[i].Cells[30].Value;
                    //        DTVAL.Rows[i][1] = dgvItem.Rows[i].Cells[32].Value;
                    //        DTVAL.Rows[i][2] = dgvItem.Rows[i].Cells[33].Value;
                    //        DTVAL.Rows[i][3] = dgvItem.Rows[i].Cells[31].Value;
                    //        DTVAL.Rows[i][4] = dgvItem.Rows[i].Cells[34].Value;
                    //    }
                    //    frmLOG LG = new frmLOG();
                    //    LG.PassingValueFromChallan(cmbPartyName.Text, PartyCode, txtvoucher.Text, vno, edpcon.mycon, SQLT, DTVAL);
                    //    LG.ShowDialog();
                    //}
                    //====================================== End
                    //====================================== Order To Stock In Entry
                    //if (SBType == "OS" && action == "ADD" && Flag_Printing == true)
                    //{
                    //    frmBILL FB = new frmBILL("SI");
                    //    FB.PassingValueFromOrder(cmbPartyName.Text, PartyCode, txtvoucher.Text, vno, edpcon.mycon, SQLT);
                    //    FB.ShowDialog();
                    //}
                    //====================================== End


                    if ((Flag_Printing || Flag_Deying) && SBType == "OS" && OrderType == 'P')
                    {
                        for (int ii = 0; ii <= common.HTAddress.Count-1; ii++)
                        {
                            DataTable dtnew = new DataTable();
                            if (common.HTAddress.Count > 0)
                                dtnew = (DataTable)common.HTAddress[ii];
                            if (Information.IsNothing(dtnew) == true)// < 1)
                            {
                                //EDPMessage.Show("Paper statement not entered in this voucher. So field it properly.", "Information");
                                //return;
                            }
                            else
                            {
                                for (int i = 0; i <= dtnew.Rows.Count - 1; i++)
                                {
                                    double spper = 0;
                                    if (Information.IsNumeric(dtnew.Rows[i][14]) == true)
                                        spper = Convert.ToDouble(dtnew.Rows[i][14]);
                                    cmd = new SqlCommand("INSERT INTO ConsumeProduct (FICode,GCode,T_Entry,PTYPE,User_Vch,Voucher,Vch_Date,PCODE,Qty,BASEQTY,USeries,Spoil_per,Size,Volume,RowIndex,ItemNo,ReffFGPcode,Order_VCH_No,Order_UserVCH_No,Party_Code,BaseUCode,PSide)" +
                                      " values ( " + edpcom.CurrentFicode + "," + edpcom.PCURRENT_GCODE + ",'" + Tentry + "','R','" + txtvoucher.Text + "' ," + vno + ",'" + edpcom.getSqlDateStr(Convert.ToDateTime(dtp.Text)) + "'," + Convert.ToDouble(dtnew.Rows[i][8]) + "," +
                                       "  '" + dtnew.Rows[i][1] + "'," + Convert.ToDouble(dtnew.Rows[i][9]).ToString(common.SetDecimalPlace(2)) + "," + Convert.ToInt32(dtnew.Rows[i][11]) + ",'" + spper + "','" + Convert.ToString(dtnew.Rows[i][17]) + "','" + Convert.ToString(dtnew.Rows[i][16]) + "'," + Convert.ToInt32(dtnew.Rows[i][13]) + "," + (i + 1) + "," + Convert.ToInt32(dtnew.Rows[i][12]) + ", " +
                                        "  " + vno + ",'" + txtvoucher.Text.Trim() + "', " + PartyCode + "," + Convert.ToInt32(dtnew.Rows[i][10]) + ",'" + Convert.ToString(dtnew.Rows[i][15]) + "' )", edpcon.mycon, SQLT);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    if (Flag_Printing)
                    {
                        common.ClearDataTable(ds.Tables["CHKTYPE"]);
                        cmd = new SqlCommand("SELECT OrderType FROM idata WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND T_Entry='OS' AND Voucher=" + Convert.ToInt32(Pcode_sl) + "", edpcon.mycon, SQLT);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "CHKTYPE");

                        if (ds.Tables["CHKTYPE"].Rows.Count > 0)
                        {
                            if (Convert.ToString(ds.Tables["CHKTYPE"].Rows[0][0]).Trim() == "P")
                                OrderType = 'P';
                        }
                    }
                    if ((Flag_Printing || Flag_Deying) && SBType == "CHLN" && OrderType == 'P')
                    {
                        common.ClearDataTable(ds.Tables["TOTALROWINDEX"]);
                        cmd = new SqlCommand("SELECT Distinct RowIndex FROM ConsumeProduct WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND T_Entry='OS' AND PTYPE='R' AND Voucher=" + Convert.ToInt32(Pcode_sl) + "", edpcon.mycon, SQLT);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "TOTALROWINDEX");

                        common.ClearDataTable(ds.Tables["TOTALPCODE"]);
                        cmd = new SqlCommand("SELECT IG.PDESC,IG.PCODE,IG.PALIAS,C.RowIndex,G.PDESC FROM ConsumeProduct C,IGLMST IG,IGLMST G WHERE C.FICODE='" + edpcom.CurrentFicode + "' AND C.GCODE='" + edpcom.PCURRENT_GCODE + "' AND C.T_Entry='OS' AND C.PTYPE='R' AND C.Voucher=" + Convert.ToInt32(Pcode_sl) + " AND C.PCODE=IG.PCODE AND C.FICODE=IG.FICODE AND C.GCODE=IG.GCODE AND C.ReffFGPcode=G.PCODE AND C.FICODE=G.FICODE AND C.GCODE=G.GCODE", edpcon.mycon, SQLT);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "TOTALPCODE");

                        for (int kk = 0; kk <= ds.Tables["TOTALROWINDEX"].Rows.Count - 1; kk++)
                        {
                            DataView dv = new DataView(ds.Tables["TOTALPCODE"]);
                            dv.RowFilter = "RowIndex=" + Convert.ToInt32(ds.Tables["TOTALROWINDEX"].Rows[kk][0]) + "";

                            if (dv.Count > 1)
                            {
                                string ss = "Paper Choosing For " + Convert.ToString(dv[0][4]);
                                string st = "SELECT IG.PDESC,IG.PCODE,IG.PALIAS FROM ConsumeProduct C,IGLMST IG WHERE C.FICODE='" + edpcom.CurrentFicode + "' AND C.GCODE='" + edpcom.PCURRENT_GCODE + "' AND C.T_Entry='OS' AND C.PTYPE='R' AND C.Voucher=" + Convert.ToInt32(Pcode_sl) + " AND C.PCODE=IG.PCODE AND C.FICODE=IG.FICODE AND C.GCODE=IG.GCODE AND C.RowIndex=" + Convert.ToInt32(ds.Tables["TOTALROWINDEX"].Rows[kk][0]) + "";
                                common.MLOV(st, "Paper Choosing", ss, "Paper Choosing", 0, "CMPN", 0);
                                string PC = "";
                                for (int i = 0; i <= (common.get_code.Count - 1); i++)
                                {
                                    PC = PC + Convert.ToString(common.get_code[i]) + ",";
                                }
                                PC = PC.Substring(0, PC.Length - 1);

                                common.ClearDataTable(ds.Tables["RawMetDetail"]);
                                cmd = new SqlCommand("SELECT * FROM ConsumeProduct WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND T_Entry='OS' AND PTYPE='R' AND Voucher=" + Convert.ToInt32(Pcode_sl) + "  AND PCODE IN (" + PC + ") AND RowIndex=" + Convert.ToInt32(ds.Tables["TOTALROWINDEX"].Rows[kk][0]) + "", edpcon.mycon, SQLT);
                                da.SelectCommand = cmd;
                                da.Fill(ds, "RawMetDetail");
                            }
                            else
                            {
                                common.ClearDataTable(ds.Tables["RawMetDetail"]);
                                cmd = new SqlCommand("SELECT * FROM ConsumeProduct WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND T_Entry='OS' AND PTYPE='R' AND Voucher=" + Convert.ToInt32(Pcode_sl) + " AND RowIndex=" + Convert.ToInt32(ds.Tables["TOTALROWINDEX"].Rows[kk][0]) + "", edpcon.mycon, SQLT);
                                da.SelectCommand = cmd;
                                da.Fill(ds, "RawMetDetail");
                            }

                            common.ClearDataTable(ds.Tables["FPBaseQty"]);
                            cmd = new SqlCommand("SELECT BASEQTY FROM ITRAN WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND T_ENTRY='OS' AND VOUCHER=" + Convert.ToInt32(Pcode_sl) + "", edpcon.mycon, SQLT);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "FPBaseQty");

                            double FPTotalQty = Convert.ToDouble(ds.Tables["FPBaseQty"].Rows[0][0]);
                            double CurrentQty = Convert.ToDouble(dgvItem.Rows[0].Cells[8].Value);
                            string QQTY = "";
                            for (int i = 0; i <= ds.Tables["RawMetDetail"].Rows.Count - 1; i++)
                            {
                                double RequiredQty = 0;
                                if (Flag_Printing)
                                {
                                    RequiredQty = Convert.ToDouble(ds.Tables["RawMetDetail"].Rows[i]["BASEQTY"]);
                                    RequiredQty = RequiredQty * 500;
                                    RequiredQty = CurrentQty * RequiredQty / FPTotalQty;
                                    RequiredQty = RequiredQty / 500;
                                    //QQTY = common.BalQtySlashForm(Convert.ToString(RequiredQty), Convert.ToInt32(ds.Tables["RawMetDetail"].Rows[i]["PCODE"]), Convert.ToInt32(ds.Tables["RawMetDetail"].Rows[i]["BaseUCode"]), Convert.ToInt32(ds.Tables["RawMetDetail"].Rows[i]["USeries"]));
                                    QQTY = common.BalQtySlashForm(Convert.ToString(RequiredQty), Convert.ToInt32(ds.Tables["RawMetDetail"].Rows[i]["PCODE"]));
                                }
                                if (Flag_Deying)
                                {
                                    RequiredQty = Convert.ToDouble(ds.Tables["RawMetDetail"].Rows[i]["BASEQTY"]);                                    
                                    RequiredQty = CurrentQty * RequiredQty / FPTotalQty;                                                                       
                                    //QQTY = common.BalQtySlashForm(Convert.ToString(RequiredQty), Convert.ToInt32(ds.Tables["RawMetDetail"].Rows[i]["PCODE"]));
                                    QQTY = Convert.ToString(RequiredQty);
                                }
                                double spper = 0;
                                if (Information.IsNumeric(ds.Tables["RawMetDetail"].Rows[i]["Spoil_per"]) == true)
                                    spper = Convert.ToDouble(ds.Tables["RawMetDetail"].Rows[i]["Spoil_per"]);
                                cmd = new SqlCommand("INSERT INTO ConsumeProduct (FICode,GCode,T_Entry,PTYPE,User_Vch,Voucher,Vch_Date,PCODE,Qty,BASEQTY,USeries,Spoil_per,Size,Volume,RowIndex,ItemNo,ReffFGPcode,Order_VCH_No,Order_UserVCH_No,Party_Code,BaseUCode,PSide)" +
                                  " values ( " + edpcom.CurrentFicode + "," + edpcom.PCURRENT_GCODE + ",'" + Tentry + "','R','" + txtvoucher.Text + "' ," + vno + ",'" + edpcom.getSqlDateStr(Convert.ToDateTime(dtp.Text)) + "'," + Convert.ToInt32(ds.Tables["RawMetDetail"].Rows[i]["PCODE"]) + "," +
                                   "  '" + QQTY + "'," + RequiredQty + "," + Convert.ToInt32(ds.Tables["RawMetDetail"].Rows[i]["USeries"]) + ",'" + spper + "','" + Convert.ToString(ds.Tables["RawMetDetail"].Rows[i]["Size"]) + "','" + Convert.ToString(ds.Tables["RawMetDetail"].Rows[i]["Volume"]) + "'," + (i + 1) + "," + (i + 1) + "," + Convert.ToInt32(ds.Tables["RawMetDetail"].Rows[i]["ReffFGPcode"]) + ", " +
                                    "  " + Convert.ToInt32(Pcode_sl) + ",'" + Convert.ToString(ds.Tables["RawMetDetail"].Rows[i]["Order_UserVCH_No"]) + "', " + PartyCode + "," + Convert.ToInt32(ds.Tables["RawMetDetail"].Rows[i]["BaseUCode"]) + ",'" + Convert.ToString(ds.Tables["RawMetDetail"].Rows[i]["PSide"]) + "' )", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                        }

                    }

                    if ((SBType != "STKOUT") && (SBType != "OS") && (SBType != "CHLN") && (SBType != "SI") && (SBType != "PO") && (SBType != "PURCHLN"))
                    {
                        if (SBType == "SALES" || SBType == "SRETURN")
                        {
                            cmd = new SqlCommand("insert into BILL(Ficode,GCODE,T_ENTRY,VOUCHER,BILLDATE,USER_VCH,CURR_CODE,BILLAMT,BALAMT,PARTYCODE,REF_TENTRY,REF_VOUCHER,DUEDATE,DB_CR,CASH_CHECK,CASH_GLCODE,SALES_GLCODE,BILLNO,MultiLeger)"
                                + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                                + " " + currcode + "," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + Convert.ToDouble(txtAmt.Text.Trim()) + ",'" + PartyCode + "','n'," + RefVno + ",'" + edpcom.getSqlDateStr(dtpBillDue.Value) + "','" + "1" + "'," + cash + "," + CashCode + "," + SalesCode + ",'" + txtvoucher.Text.Trim() + "','" + multipleLeger + "')", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }
                        else if (SBType == "PUR" || SBType == "PR")
                        {
                            cmd = new SqlCommand("insert into BILL(Ficode,GCODE,T_ENTRY,VOUCHER,BILLDATE,USER_VCH,CURR_CODE,BILLAMT,BALAMT,PARTYCODE,REF_TENTRY,REF_VOUCHER,DUEDATE,DB_CR,CASH_CHECK,CASH_GLCODE,SALES_GLCODE,BILLNO,MultiLeger)"
                                + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                                + " " + currcode + "," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + Convert.ToDouble(txtAmt.Text.Trim()) + ",'" + PartyCode + "','a'," + RefVno + ",'" + edpcom.getSqlDateStr(dtpBillDue.Value) + "','" + "1" + "'," + cash + "," + CashCode + "," + SalesCode + ",'" + txtvoucher.Text.Trim() + "','" + multipleLeger + "')", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (SBType == "STKOUT")
                    {
                        string TE = "", LITE = "";
                        TE = "SO";
                        LITE = "SO";
                        cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,ReffPartyCode)"
                            + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                            + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + vno + "," + ReffPartyCode + ")", edpcon.mycon, SQLT);
                        cmd.ExecuteNonQuery();
                    }
                    else if (SBType == "OS")
                    {                        
                        string TE = "", LITE = "";                        
                        TE = "OS";
                        LITE = "OS";
                        AdhokAmt = 0;
                        if (Information.IsNumeric(txtTotalAmt.Text) == true)
                            AdhokAmt = Convert.ToDouble(txtTotalAmt.Text);
                        cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,ReffPartyCode,OrderType,IncluciveVAT,OnVATPer,AdhokAmt)"
                            + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                            + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + vno + "," + ReffPartyCode + ",'" + OrderType + "','" + chkIncVAT.Checked + "','" + chkOnVATPer.Checked + "'," + AdhokAmt + ")", edpcon.mycon, SQLT);
                        cmd.ExecuteNonQuery();
                    }
                    else if (SBType == "SI")
                    {
                        string TE = "", LITE = "";
                        TE = "SI";
                        LITE = "SI";
                        if (Pcode_sl == null || Pcode_sl == "")
                            Pcode_sl = "0";
                        if (!CHKORD)
                        {
                            cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,ReffPartyCode)"
                                + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                                + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + Pcode_sl + "," + ReffPartyCode + ")", edpcon.mycon, SQLT);
                        }
                        else
                        {
                            cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,ReffPartyCode)"
                                + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                                + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + Pcode_sl + "," + ReffPartyCode + ")", SQLCNN, SQLT);
                        }
                        cmd.ExecuteNonQuery();
                    }
                    else if (SBType == "CHLN")
                    {
                        string TE = "", LITE = "";
                        TE = "n";
                        LITE = "n";
                        AdhokAmt = 0;
                        if (Information.IsNumeric(txtTotalAmt.Text) == true)
                            AdhokAmt = Convert.ToDouble(txtTotalAmt.Text);
                        cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,ReffPartyCode,IncluciveVAT,OnVATPer,AdhokAmt)"
                            + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                            + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + vno + "," + ReffPartyCode + ",'" + chkIncVAT.Checked + "','" + chkOnVATPer.Checked + "'," + AdhokAmt + ")", edpcon.mycon, SQLT);
                        cmd.ExecuteNonQuery();
                    }
                    else if (SBType == "PO")
                    {
                        string TE = "", LITE = "";
                        TE = "OP";
                        LITE = "OP";
                        cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,ReffPartyCode)"
                            + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                            + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + vno + "," + ReffPartyCode + ")", edpcon.mycon, SQLT);
                        cmd.ExecuteNonQuery();
                    }
                    else if (SBType == "PURCHLN")
                    {
                        string TE = "", LITE = "";
                        TE = "a";
                        LITE = "a";
                        cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,ReffPartyCode)"
                            + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                            + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + vno + "," + ReffPartyCode + ")", edpcon.mycon, SQLT);
                        cmd.ExecuteNonQuery();
                    }
                    else if (SBType == "SRETURN")
                    {
                        string TE = "", LITE = "";
                        TE = "SR";
                        LITE = "SR";
                        cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,ReffPartyCode)"
                            + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                            + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + vno + "," + ReffPartyCode + ")", edpcon.mycon, SQLT);
                        cmd.ExecuteNonQuery();
                    }
                    else if (SBType == "PR")
                    {
                        string TE = "", LITE = "";
                        TE = "PR";
                        LITE = "PR";
                        cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,ReffPartyCode)"
                            + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                            + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + vno + "," + ReffPartyCode + ")", edpcon.mycon, SQLT);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        for (int i = 0; i <= 1; i++)
                        {
                            if (SBType == "SALES")
                            {
                                AdhokAmt = 0;
                                if (Information.IsNumeric(txtTotalAmt.Text) == true)
                                    AdhokAmt = Convert.ToDouble(txtTotalAmt.Text);
                                string TE = "", LITE = "";
                                if (i == 0)
                                {
                                    TE = "9";
                                    LITE = "n";
                                }
                                else
                                {
                                    TE = "n";
                                    LITE = "9";
                                }
                                if (i == 0)
                                {
                                    cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,ReffPartyCode,IncluciveVAT,OnVATPer,AdhokAmt)"
                                        + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                                        + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + RefVno + "," + ReffPartyCode + ",'" + chkIncVAT.Checked + "','" + chkOnVATPer.Checked + "'," + AdhokAmt + ")", edpcon.mycon, SQLT);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (lbRC.Items.Count == 0)
                                {
                                    cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,AutoChalan,ReffPartyCode,IncluciveVAT,OnVATPer,AdhokAmt)"
                                        + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + RefVno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtVoucherChallan.Text.Trim() + "',"
                                        + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + vno + ",'True'," + ReffPartyCode + ",'" + chkIncVAT.Checked + "','" + chkOnVATPer.Checked + "'," + AdhokAmt + ")", edpcon.mycon, SQLT);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else if (SBType == "PUR")
                            {
                                string TE = "", LITE = "";
                                if (i == 0)
                                {
                                    TE = "8";
                                    LITE = "a";
                                }
                                else
                                {
                                    TE = "a";
                                    LITE = "8";
                                }
                                if (i == 0)
                                {
                                    cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,ReffPartyCode)"
                                        + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + vno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtvoucher.Text.Trim() + "',"
                                        + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + RefVno + "," + ReffPartyCode + ")", edpcon.mycon, SQLT);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (lbRC.Items.Count == 0)
                                {
                                    cmd = new SqlCommand("insert into idata(Ficode,GCODE,T_ENTRY,VOUCHER,VCH_DATE,USER_VCH,CURR_CODE,VCH_TIME,NetAmt,Party_code,DESCCODE,Link_DataT_entry,Link_DataVoucher,AutoChalan,ReffPartyCode)"
                                        + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + TE + "'," + RefVno + ",'" + edpcom.getSqlDateStr(dtp.Value) + "','" + txtVoucherChallan.Text.Trim() + "',"
                                        + " " + currcode + ",'" + dtp.Value.ToShortTimeString() + "'," + Convert.ToDouble(txtAmt.Text.Trim()) + "," + PartyCode + "," + Desccode + ",'" + LITE + "'," + vno + ",'True'," + ReffPartyCode + ")", edpcon.mycon, SQLT);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    if (SBType == "SI" && cmbRefOrd.Text != "" && (Pcode_sl != "" || Pcode_sl != null) && chkStopSI.Checked)
                    {
                        cmd = new SqlCommand(" Update itran set SISTATUS='STOP' where ficode ='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and autoincre in (select it.autoincre from itran it,idata i where it.ficode=i.ficode and it.gcode=i.gcode and it.voucher=i.voucher and it.t_entry=i.t_entry and i.voucher=" + Pcode_sl + " and i.user_vch='" + cmbRefOrd.Text.Trim() + "'  and i.ficode ='" + edpcom.CurrentFicode + "' and i.gcode='" + edpcom.PCURRENT_GCODE + "')", edpcon.mycon, SQLT);
                        cmd.ExecuteNonQuery();
                    }

                    if ((SBType != "STKOUT") && (SBType != "OS") && (SBType != "CHLN") && (SBType != "SI") && (SBType != "PO") && (SBType != "PURCHLN"))
                    {
                        //------------------------------- Auto Round Off Calculation--------------------
                        if (action == "ADD")
                        {                         
                            decimal pa = 0;
                            for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                            {
                                if (Information.IsNumeric(dgvItem.Rows[i].Cells[6].Value) == true)
                                    pa = pa + Convert.ToDecimal(dgvItem.Rows[i].Cells[6].Value.ToString());
                            }
                            if ((Flag_Printing) && (Convert.ToDouble(txtTotalAmt.Text) != 0) && (pa == 0))
                                pa = Convert.ToDecimal(txtTotalAmt.Text);
                            for (int i = 0; i <= dgvAddless.RowCount - 1; i++)
                            {
                                if (dgvAddless.Rows[i].Cells[3].Value != null)
                                    pa = pa + Convert.ToDecimal(dgvAddless.Rows[i].Cells[3].Value.ToString());
                            }
                            decimal RAmt = Math.Round(Convert.ToDecimal(pa));
                            decimal BalAmt = Convert.ToDecimal(pa) - RAmt;
                            double amt = Convert.ToDouble(BalAmt);
                            if (BalAmt == Convert.ToDecimal(.5))
                            {
                                pa = pa + (1) * BalAmt;
                                BalAmt = Convert.ToDecimal(.5);
                            }
                            else if (BalAmt >= 0)
                            {
                                pa = pa - BalAmt;
                                BalAmt = BalAmt * (-1);
                            }

                            else
                            {
                                pa = pa + (-1) * BalAmt;
                                BalAmt = BalAmt * (-1);
                            }

                            //decimal RAmt = Math.Round(Convert.ToDecimal(pa));
                            //decimal BalAmt = Convert.ToDecimal(pa) - RAmt;
                            //if (BalAmt >= 0)
                            //{
                            //    pa = pa - BalAmt;
                            //    BalAmt = BalAmt * (-1);
                            //}
                            //else
                            //{
                            //    pa = pa + (-1) * BalAmt;
                            //    BalAmt = BalAmt * (-1);
                            //}
                            if ((dgvAddless.Rows.Count == 1) && (dgvAddless.Rows[0].Cells[2].Value == null))
                            {

                            }
                            else
                            {
                                if (BalAmt != 0)
                                    dgvAddless.Rows.Add();
                            }
                            if (BalAmt != 0)
                            {
                                int count = 0;
                                count = dgvAddless.Rows.Count - 1;
                                dgvAddless.Rows[count].Cells[0].Value = Getresult("select ldesc from glmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and mtype='L'  and (ACTV_FLG IS NULL OR ACTV_FLG='True')  and glcode=10");//glcode
                                if (BalAmt > 0)
                                    dgvAddless.Rows[count].Cells[2].Value = "NA";
                                else
                                    dgvAddless.Rows[count].Cells[2].Value = "LESS";
                                dgvAddless.Rows[count].Cells[3].Value = BalAmt;
                            }
                        }
                        //-------------------------------End Auto Round Off Calculation--------------------
                        for (int i = 0; i <= dgvAddless.RowCount - 1; i++)
                        {
                            double PerCent = 0;
                            if (dgvAddless.Rows[i].Cells[1].Value != null)
                            {
                                if (dgvAddless.Rows[i].Cells[1].Value.ToString() != "")
                                {
                                    PerCent = Convert.ToDouble(dgvAddless.Rows[i].Cells[1].Value.ToString());
                                }
                            }
                            int AC = Convert.ToInt32(Getresult("select glcode from glmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and mtype='L'  and (ACTV_FLG IS NULL OR ACTV_FLG='True')  and ldesc='" + dgvAddless.Rows[i].Cells[0].Value.ToString() + "'"));//glcode;
                            cmd = new SqlCommand("insert into AddLess(Ficode,GCODE,T_ENTRY,VOUCHER,AddLessDESC,AddLessCode,Per,Amt,ONAMT)"
                            + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ",'" + dgvAddless.Rows[i].Cells[0].Value.ToString() + "'," + AC + ","
                            + " " + PerCent + "," + Convert.ToDouble(dgvAddless.Rows[i].Cells[3].Value) + ",'" + dgvAddless.Rows[i].Cells[2].Value + "')", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }
                        string pva = "PVT";
                        if ((MultiSalePurAC) && (pva != "PVT"))
                        {
                            for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                            {
                                if ((Information.IsNothing(dgvItem.Rows[i].Cells[21].Value) == false) && (Information.IsNumeric(dgvItem.Rows[i].Cells[23].Value) == true))
                                {
                                    double PerCent = 0;
                                    PerCent = Convert.ToDouble(Getresult("select VAT_PERCENT from VATMaster where  VAT_CODE=" + dgvItem.Rows[i].Cells[23].Value + ""));//glcode;
                                    cmd = new SqlCommand("insert into AddLess(Ficode,GCODE,T_ENTRY,VOUCHER,AddLessDESC,AddLessCode,Per,Amt)"
                                    + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ",'" + dgvItem.Rows[i].Cells[21].Value.ToString() + "'," + dgvItem.Rows[i].Cells[23].Value.ToString() + ","
                                    + " " + PerCent + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[24].Value.ToString()) + ")", edpcon.mycon, SQLT);
                                    cmd.ExecuteNonQuery();

                                    double AddAmt = Convert.ToDouble(dgvItem.Rows[i].Cells[24].Value);
                                    int AC = Convert.ToInt32(dgvItem.Rows[i].Cells[23].Value); //Convert.ToInt32(Getresult("select glcode from glmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and mtype='L'  and (ACTV_FLG IS NULL OR ACTV_FLG='True')  and ldesc='" + dgvAddless.Rows[j].Cells[0].Value.ToString() + "'"));//glcode;
                                    cmd = new SqlCommand("insert into AddlessLineItem(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,AddlessCode,AddlessDesc,Per,AMT,LineItem)"
                                        + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                        + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + "," + AC + ",'" + dgvItem.Rows[i].Cells[21].Value.ToString() + "',"
                                        + " " + PerCent + "," + AddAmt + "," + (Convert.ToInt32(i) + 1) + ")", edpcon.mycon, SQLT);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    
                    int ino = 0;
                    for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                    {
                        ino = i + 1;
                        double DISAMT = 0;
                        if (dgvItem.Rows[i].Cells[5] != null)
                            if (dgvItem.Rows[i].Cells[5].Value != null)
                                if (dgvItem.Rows[i].Cells[5].Value != "")
                                    DISAMT = Convert.ToDouble(dgvItem.Rows[i].Cells[5].Value);

                        string RefTE = "";
                        if (((SBType == "SALES") || (SBType == "PUR")) && (lbcmp.Items.Count == 0) && (lbRC.Items.Count == 0))
                        {
                            if (SBType == "SALES")
                                RefTE = "n";
                            else if (SBType == "PUR")
                                RefTE = "a";
                        }
                        else
                        {
                            if (dgvItem.Rows[i].Cells[11] != null)
                                if (dgvItem.Rows[i].Cells[11].Value != null)
                                    if (dgvItem.Rows[i].Cells[11].Value != "")
                                        RefTE = dgvItem.Rows[i].Cells[11].Value.ToString().Trim();
                        }

                        int RefVch = 0;
                        if (((SBType == "SALES") || (SBType == "PUR")) && (lbcmp.Items.Count == 0) && (lbRC.Items.Count == 0))
                        {
                            RefVch = RefVno;
                        }
                        else
                        {
                            if (dgvItem.Rows[i].Cells[12] != null)
                                if (dgvItem.Rows[i].Cells[12].Value != null)
                                    if (dgvItem.Rows[i].Cells[12].Value != "")
                                        RefVch = Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value);
                        }
                        int RefINO = 0;
                        if (dgvItem.Rows[i].Cells[13] != null)
                            if (dgvItem.Rows[i].Cells[13].Value != null)
                                if (dgvItem.Rows[i].Cells[13].Value != "")
                                    RefINO = Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value);

                        decimal Vol = 0;
                        if (dgvItem.Rows[i].Cells[14] != null)
                            if (dgvItem.Rows[i].Cells[14].Value != null)
                                if (dgvItem.Rows[i].Cells[14].Value != "")
                                    Vol = Convert.ToDecimal(dgvItem.Rows[i].Cells[14].Value);

                        int PPF = 0;
                        if (dgvItem.Rows[i].Cells[16] != null)
                            if (dgvItem.Rows[i].Cells[16].Value != null)
                                if (dgvItem.Rows[i].Cells[16].Value != "")
                                    PPF = Convert.ToInt32(dgvItem.Rows[i].Cells[16].Value);

                        string freeqty = "0";
                        if (dgvItem.Rows[i].Cells[19] != null)
                            if (dgvItem.Rows[i].Cells[19].Value != null)
                                if (dgvItem.Rows[i].Cells[19].Value != "")
                                    freeqty = dgvItem.Rows[i].Cells[19].Value.ToString();

                        if (Tentry == "n" && cmbAct.Text == "ADD")
                        {
                            if (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) == Convert.ToDouble(dgvItem.Rows[i].Cells[17].Value))
                            {
                                cmd = new SqlCommand("Update itran set DSTATUS='STOP' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='OS' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and itemno=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        if (Tentry == "a" && cmbAct.Text == "ADD")
                        {
                            if (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) == Convert.ToDouble(dgvItem.Rows[i].Cells[17].Value))
                            {
                                cmd = new SqlCommand("Update itran set DSTATUS='STOP' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='OP' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and itemno=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        if (Tentry == "SI" && cmbAct.Text == "ADD")
                        {
                            if (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) == Convert.ToDouble(dgvItem.Rows[i].Cells[17].Value))
                            {
                                //cmd = new SqlCommand("Update RawMeterialDetails set SISTATUS='STOP' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='OS' and Raw_PCODE=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and Iteam_No=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                //cmd.ExecuteNonQuery();
                            }
                        }

                        if (Tentry == "9" && cmbAct.Text == "ADD" && lbcmp.Items.Count > 0)//SB
                        {
                            if (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) == Convert.ToDouble(dgvItem.Rows[i].Cells[17].Value))
                            {
                                cmd = new SqlCommand("Update itran set DSTATUS='STOP' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='OS' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and itemno=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        if (Tentry == "9" && cmbAct.Text == "ADD" && lbRC.Items.Count > 0)//SB
                        {
                            if (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) == Convert.ToDouble(dgvItem.Rows[i].Cells[17].Value))
                            {
                                cmd = new SqlCommand("Update itran set DSTATUS='STOP' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='n' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and itemno=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        if (Tentry == "8" && cmbAct.Text == "ADD" && lbcmp.Items.Count > 0)//SB
                        {
                            if (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) == Convert.ToDouble(dgvItem.Rows[i].Cells[17].Value))
                            {
                                cmd = new SqlCommand("Update itran set DSTATUS='STOP' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='OP' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and itemno=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        if (Tentry == "8" && cmbAct.Text == "ADD" && lbRC.Items.Count > 0)//SB
                        {
                            if (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) == Convert.ToDouble(dgvItem.Rows[i].Cells[17].Value))
                            {
                                cmd = new SqlCommand("Update itran set DSTATUS='STOP' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='a' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and itemno=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        //----------------- Sales For ITRAN---------------------
                        double FBQ = 0;
                        double PUC = 0; double PU = 0;
                        double RQ = 0;
                        bool F1 = false;

                        decimal OnlnBSQtConVal = 0;
                        if (Information.IsNumeric(dgvItem.Rows[i].Cells[45].Value) == true)
                            OnlnBSQtConVal = Convert.ToDecimal(dgvItem.Rows[i].Cells[45].Value);

                        if (Information.IsNumeric(dgvItem.Rows[i].Cells[43].Value) == true)
                            RQ = Convert.ToDouble(dgvItem.Rows[i].Cells[43].Value);

                        if (Information.IsNothing(dgvItem.Rows[i].Cells[44].Value) == false)
                        {
                            if (dgvItem.Rows[i].Cells[44].Value.ToString() != "")
                                F1 = Convert.ToBoolean(dgvItem.Rows[i].Cells[44].Value);
                            else
                                F1 = false;
                        }

                        if (Information.IsNumeric(dgvItem.Rows[i].Cells[41].Value) == true)
                            PUC = Convert.ToDouble(dgvItem.Rows[i].Cells[41].Value);
                        if (Information.IsNumeric(dgvItem.Rows[i].Cells[42].Value) == true)
                            PU = Convert.ToDouble(dgvItem.Rows[i].Cells[42].Value);

                        int UnitOnrate = 0;
                        if (Information.IsNumeric(dgvItem.Rows[i].Cells[9].Value) == true)
                            UnitOnrate = Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value);

                        if (Information.IsNumeric(dgvItem.Rows[i].Cells[19].Value) == false)
                            FBQ = 0;
                        else
                            FBQ = Convert.ToDouble(dgvItem.Rows[i].Cells[19].Value);
                        if ((SBType == "SALES") && (lbcmp.Items.Count > 0) && (lbRC.Items.Count == 0))
                        {
                            if (Flag_Printing)
                            {
                                double refqty = 0;
                                if (Information.IsNumeric(dgvItem.Rows[i].Cells[32].Value) == true)
                                    refqty = Convert.ToDouble(dgvItem.Rows[i].Cells[32].Value);

                                cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,FreeQTY,FreeBASEQTY,RefPCODE,RefQty,RefUCODE,RefVolume,RefSize,RefPagePerFormat,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume)"
                                   + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                   + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                   + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                   + " '" + LTE + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + LTE + "'," + RefVno + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING','" + freeqty + "'," + FBQ + ","
                                   + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[31].Value) + "," + refqty + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[34].Value) + ",'" + dgvItem.Rows[i].Cells[35].Value + "','" + dgvItem.Rows[i].Cells[36].Value + "','" + dgvItem.Rows[i].Cells[37].Value + "'," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "')", edpcon.mycon, SQLT);
                            }
                            else
                            {
                                cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,FreeQTY,FreeBASEQTY,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                    + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                    + " '" + LTE + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + LTE + "'," + RefVno + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING','" + freeqty + "'," + FBQ + "," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                            }
                            cmd.ExecuteNonQuery();
                        }
                        else if ((SBType == "SALES") && (lbcmp.Items.Count == 0) && (lbRC.Items.Count > 0))
                        {
                            if (Flag_Printing == true || Flag_Deying == true)
                            {
                                double refqty = 0;
                                bool CPrd = false;
                                if (dgvItem.Rows[i].Cells[45] != null)
                                    if (dgvItem.Rows[i].Cells[45].Value != "")
                                        if (dgvItem.Rows[i].Cells[45].Value.ToString() != null)
                                            CPrd = Convert.ToBoolean(dgvItem.Rows[i].Cells[45].Value);
                                if (Information.IsNumeric(dgvItem.Rows[i].Cells[32].Value) == true)
                                    refqty = Convert.ToDouble(dgvItem.Rows[i].Cells[32].Value);
                                cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,FreeQTY,FreeBASEQTY,RefPCODE,RefQty,RefUCODE,RefVolume,RefSize,RefPagePerFormat,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,PaperConsume)"
                                   + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                   + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                   + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                   + " '9'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + RefVch + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING','" + freeqty + "'," + FBQ + ", "
                                   + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[31].Value) + "," + refqty + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[34].Value) + ",'" + dgvItem.Rows[i].Cells[35].Value + "','" + dgvItem.Rows[i].Cells[36].Value + "','" + dgvItem.Rows[i].Cells[37].Value + "'," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "','" + CPrd + "')", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,FreeQTY,FreeBASEQTY,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                    + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                    + " '9'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + RefVch + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING','" + freeqty + "'," + FBQ + "," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else if ((SBType == "SALES") && (lbcmp.Items.Count == 0) && (lbRC.Items.Count == 0))
                        {
                            if (Flag_Printing == true || Flag_Deying == true)
                            {
                                double refqty = 0;
                                if (Information.IsNumeric(dgvItem.Rows[i].Cells[32].Value) == true)
                                    refqty = Convert.ToDouble(dgvItem.Rows[i].Cells[32].Value);

                                cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,FreeQTY,FreeBASEQTY,RefPCODE,RefQty,RefUCODE,RefVolume,RefSize,RefPagePerFormat,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume)"
                                   + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                   + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                   + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                   + " '" + LTE + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + RefVch + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING','" + freeqty + "'," + FBQ + ","
                                   + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[31].Value) + "," + refqty + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[34].Value) + ",'" + dgvItem.Rows[i].Cells[35].Value + "','" + dgvItem.Rows[i].Cells[36].Value + "','" + dgvItem.Rows[i].Cells[37].Value + "'," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "')", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,FreeQTY,FreeBASEQTY,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                    + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                    + " '" + LTE + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + RefVch + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING','" + freeqty + "'," + FBQ + "," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else if ((SBType == "SRETURN") && (lbcmp.Items.Count == 0) && (lbRC.Items.Count > 0))
                        {
                            cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                + " 'SR'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + RefVch + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING'," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }
                        else if ((SBType != "PUR") && (SBType != "PO") && (SBType != "PURCHLN") && (SBType != "PR"))
                        {
                            if (SBType == "SI")
                            {
                                if (!CHKORD)
                                {
                                    if (Pcode_sl == "" || Pcode_sl == "")
                                        Pcode_sl = "0";
                                    else
                                        RefTE = Getresult("select distinct  t_entry from idata where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and voucher=" + Pcode_sl + " and user_vch='" + cmbRefOrd.Text.Trim() + "'");
                                }
                                else
                                    RefTE = "OS";
                                if (!CHKORD)
                                {
                                    cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                        + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                        + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                        + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                        + " '" + LTE + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + Pcode_sl + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING'," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                                }
                                else
                                {
                                    cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                        + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                        + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                        + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                        + " '" + LTE + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + Pcode_sl + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING'," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", SQLCNN, SQLT);
                                }
                                cmd.ExecuteNonQuery();
                            }
                            else if (SBType == "STKOUT" && Flag_Printing == true)
                            {
                                if (Pcode_sl == "")
                                    Pcode_sl = "0";
                                else
                                    RefTE = Getresult("select distinct  t_entry from idata where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and voucher=" + Pcode_sl + " and user_vch='" + cmbRefOrd.Text.Trim() + "'");

                                cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume)"
                                    + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                    + " '" + LTE + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + Pcode_sl + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING'," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "')", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                if (Flag_Printing == true || Flag_Deying == true)
                                {
                                    double refqty = 0;
                                    bool CPrd = false;
                                    if (dgvItem.Rows[i].Cells[45] != null)
                                        if (dgvItem.Rows[i].Cells[45].Value != "")
                                            if (dgvItem.Rows[i].Cells[45].Value.ToString() != null)
                                                CPrd = Convert.ToBoolean(dgvItem.Rows[i].Cells[45].Value);


                                    if (Information.IsNumeric(dgvItem.Rows[i].Cells[32].Value) == true)
                                        refqty = Convert.ToDouble(dgvItem.Rows[i].Cells[32].Value);
                                    cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,RefPCODE,RefQty,RefUCODE,RefVolume,RefSize,RefPagePerFormat,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,PaperConsume)"
                                                                        + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                                                        + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                                                        + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                                                        + " '" + LTE + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + RefVch + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING', "
                                                                        + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[31].Value) + "," + refqty + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[34].Value) + ",'" + dgvItem.Rows[i].Cells[35].Value + "','" + dgvItem.Rows[i].Cells[36].Value + "','" + dgvItem.Rows[i].Cells[37].Value + "'," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "','" + CPrd + "')", edpcon.mycon, SQLT);
                                    cmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                                                       + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                                                       + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                                                       + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                                                       + " '" + LTE + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + RefVch + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING'," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        if ((SBType == "SALES") || (SBType == "PUR"))
                        {
                            cmd = new SqlCommand("INSERT INTO TaxAssasable (FICode,GCODE,Tax_Type,T_entry,Voucher,Pcode,Vatcode,VatPercent,AssableValue,VatAmt) VALUES('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','VAT','" + Tentry + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[23].Value) + "," + Convert.ToDecimal(dgvItem.Rows[i].Cells[26].Value) + "," + Convert.ToDecimal(dgvItem.Rows[i].Cells[28].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[24].Value) + ")", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }
                        //----------------- Purchase For ITRAN---------------------

                        if ((SBType == "PUR") && (lbcmp.Items.Count > 0) && (lbRC.Items.Count == 0))
                        {
                            cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,FreeQTY,FreeBASEQTY,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                + " '" + LTE + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + LTE + "'," + RefVno + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING','" + freeqty + "'," + FBQ + "," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }
                        else if ((SBType == "PUR") && (lbcmp.Items.Count == 0) && (lbRC.Items.Count > 0))
                        {
                            cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,FreeQTY,FreeBASEQTY,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                + " '8'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + RefVch + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING','" + freeqty + "'," + FBQ + "," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }
                        else if ((SBType == "PUR") && (lbcmp.Items.Count == 0) && (lbRC.Items.Count == 0))
                        {
                            cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,FreeQTY,FreeBASEQTY,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                + " '" + LTE + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + RefVch + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING','" + freeqty + "'," + FBQ + "," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }
                        else if ((SBType != "SALES") && (SBType != "OS") && (SBType != "CHLN") && (SBType != "SRETURN") && (SBType != "SI") && (SBType != "STKOUT"))
                        {
                            cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,Link_TEntry,Link_Voucher,UCODE,DIS_AMT,DSTATUS,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,Volume,Size,PPF,SISTATUS,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ","
                                + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                + " '" + LTE + "'," + vno + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'RUNNING','" + RefTE + "'," + RefVch + "," + RefINO + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING'," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }

                        if ((SBType != "STKOUT") && (SBType != "OS") && (SBType != "CHLN") && (SBType != "SI") && (SBType != "PO") && (SBType != "PURCHLN"))
                        {
                            if ((SBType == "SALES") && (lbcmp.Items.Count == 0) && (lbRC.Items.Count == 0))
                            {
                                if (Flag_Printing == true || Flag_Deying == true)
                                {
                                    double refqty = 0;
                                    if (Information.IsNumeric(dgvItem.Rows[i].Cells[32].Value) == true)
                                        refqty = Convert.ToDouble(dgvItem.Rows[i].Cells[32].Value);

                                    cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,UCODE,DIS_AMT,Volume,Size,PPF,SISTATUS,RefPCODE,RefQty,RefUCODE,RefVolume,RefSize,RefPagePerFormat,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume)"
                                       + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','n'," + RefVno + ","
                                       + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ",'" + Convert.ToDouble(dgvItem.Rows[i].Cells[10].Value) + "',"
                                       + " " + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                       + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING',"//)", edpcon.mycon, SQLT); 
                                       + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[31].Value) + "," + refqty + "," + Convert.ToInt32(dgvItem.Rows[i].Cells[34].Value) + ",'" + dgvItem.Rows[i].Cells[35].Value + "','" + dgvItem.Rows[i].Cells[36].Value + "','" + dgvItem.Rows[i].Cells[37].Value + "'," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "')", edpcon.mycon, SQLT);

                                    cmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,UCODE,DIS_AMT,Volume,Size,PPF,SISTATUS,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                        + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','n'," + RefVno + ","
                                        + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ",'" + Convert.ToDouble(dgvItem.Rows[i].Cells[10].Value) + "',"
                                        + " " + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                        + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + "," + Vol + ",'" + dgvItem.Rows[i].Cells[15].Value + "'," + PPF + ",'RUNNING'," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            if ((SBType == "SALES") && (lbcmp.Items.Count > 0) && (lbRC.Items.Count == 0))
                            {
                                cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,UCODE,DIS_AMT,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                    + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','n'," + RefVno + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ",'" + Convert.ToDouble(dgvItem.Rows[i].Cells[10].Value) + "',"
                                    + " " + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'" + RefTE + "'," + RefVch + "," + RefINO + "," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                            if ((SBType == "PUR") && (lbcmp.Items.Count == 0) && (lbRC.Items.Count == 0))
                            {
                                cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,UCODE,DIS_AMT,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"//,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO)"
                                    + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','a'," + RefVno + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ",'" + Convert.ToDouble(dgvItem.Rows[i].Cells[10].Value) + "',"
                                    + " " + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + "," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT); //,'" + RefTE + "'," + RefVch + "," + RefINO + ")", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                            if ((SBType == "PUR") && (lbcmp.Items.Count > 0) && (lbRC.Items.Count == 0))
                            {
                                cmd = new SqlCommand("insert into itran(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,QTY,BASEQTY,USeries,RATE,AMT,ItemNo,UCODE,DIS_AMT,REF_TENTRY,REF_VOUCHER,REFF_ITEM_NO,RateOnUnitCode,PrintQtyUcode,PrintQty,RatingQty,AmtCalOnVolume,OnlnBSQtConVal)"
                                    + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','a'," + RefVno + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ",'" + dgvItem.Rows[i].Cells[1].Value + "'," + Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) + ",'" + Convert.ToDouble(dgvItem.Rows[i].Cells[10].Value) + "',"
                                    + " " + Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value) + "," + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) + "," + ino + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + "," + DISAMT + ",'" + RefTE + "'," + RefVch + "," + RefINO + "," + UnitOnrate + "," + PUC + "," + PU + "," + RQ + ",'" + F1 + "'," + OnlnBSQtConVal + ")", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        if ((SBType != "STKOUT") && (SBType != "OS") && (SBType != "CHLN") && (SBType != "SI") && (SBType != "PO") && (SBType != "PURCHLN"))
                        {
                            double PerCent = 0, AddAmt = 0;
                            int AC = 0;
                            if (MultiSalePurAC)
                            {
                                PerCent = Convert.ToDouble(dgvItem.Rows[i].Cells[26].Value);
                                AddAmt = Convert.ToDouble(dgvItem.Rows[i].Cells[24].Value);
                                dgvItem.Rows[i].Cells[27].Value = Convert.ToDouble(dgvItem.Rows[i].Cells[27].Value) + AddAmt;
                                AC = Convert.ToInt32(Getresult("select glcode from glmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and mtype='L'  and (ACTV_FLG IS NULL OR ACTV_FLG='True')  and ldesc='" + dgvItem.Rows[i].Cells[21].Value.ToString() + "'"));//glcode;
                                cmd = new SqlCommand("insert into AddlessLineItem(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,AddlessCode,AddlessDesc,Per,AMT,LineItem)"
                                    + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                    + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + "," + AC + ",'" + dgvItem.Rows[i].Cells[21].Value.ToString() + "',"
                                    + " " + PerCent + "," + AddAmt + "," + ino + ")", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                            for (int j = 0; j <= dgvAddless.RowCount - 1; j++)
                            {
                                PerCent = 0; AddAmt = 0;
                                //j = 1;
                                if (Information.IsNumeric(dgvAddless.Rows[j].Cells[5].Value) == true)
                                {
                                }
                                else
                                {
                                    if (dgvAddless.Rows[j].Cells[1].Value != null)
                                    {
                                        if (dgvAddless.Rows[j].Cells[1].Value.ToString() != "")
                                            PerCent = Convert.ToDouble(dgvAddless.Rows[j].Cells[1].Value.ToString());
                                    }
                                    if (PerCent > 0)
                                    {
                                        if (dgvAddless.Rows[j].Cells[2].Value != null)
                                            if (dgvAddless.Rows[j].Cells[2].Value.ToString() != "")
                                                if (dgvAddless.Rows[j].Cells[2].Value.ToString() == "LESS")
                                                {
                                                    AddAmt = ((Convert.ToDouble(dgvItem.Rows[i].Cells[27].Value) * PerCent) / 100) * (-1);
                                                    dgvItem.Rows[i].Cells[27].Value = Convert.ToDouble(dgvItem.Rows[i].Cells[27].Value) + AddAmt;
                                                }
                                                else
                                                {
                                                    AddAmt = (Convert.ToDouble(dgvItem.Rows[i].Cells[27].Value) * PerCent) / 100;
                                                    dgvItem.Rows[i].Cells[27].Value = Convert.ToDouble(dgvItem.Rows[i].Cells[27].Value) + AddAmt;
                                                }
                                            else
                                            {
                                                AddAmt = (Convert.ToDouble(dgvItem.Rows[i].Cells[27].Value) * PerCent) / 100;
                                                dgvItem.Rows[i].Cells[27].Value = Convert.ToDouble(dgvItem.Rows[i].Cells[27].Value) + AddAmt;
                                            }
                                        else
                                        {
                                            AddAmt = (Convert.ToDouble(dgvItem.Rows[i].Cells[27].Value) * PerCent) / 100;
                                            dgvItem.Rows[i].Cells[27].Value = Convert.ToDouble(dgvItem.Rows[i].Cells[27].Value) + AddAmt;
                                        }
                                    }
                                    else
                                    {
                                        double TA = 0;
                                        for (int l = 0; l <= dgvItem.Rows.Count - 1; l++)
                                        {
                                            TA = TA + Convert.ToDouble(dgvItem.Rows[l].Cells[6].Value);
                                        }
                                        double pera = (Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value) * 100) / TA;
                                        AddAmt = (Convert.ToDouble(dgvAddless.Rows[j].Cells[3].Value.ToString()) * pera) / 100;
                                        dgvItem.Rows[i].Cells[27].Value = Convert.ToDouble(dgvItem.Rows[i].Cells[27].Value) + AddAmt;
                                    }
                                    AC = 0;
                                    if (!Flag_Printing)
                                    {
                                        AC = Convert.ToInt32(Getresult("select glcode from glmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and mtype='L'  and (ACTV_FLG IS NULL OR ACTV_FLG='True')  and ldesc='" + dgvAddless.Rows[j].Cells[0].Value.ToString() + "'"));//glcode;
                                        cmd = new SqlCommand("insert into AddlessLineItem(Ficode,GCODE,T_ENTRY,VOUCHER,PCODE,AddlessCode,AddlessDesc,Per,AMT,LineItem)"
                                            + " values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ","
                                            + " " + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + "," + AC + ",'" + dgvAddless.Rows[j].Cells[0].Value.ToString() + "',"
                                            + " " + PerCent + "," + AddAmt + "," + ino + ")", edpcon.mycon, SQLT);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            if ((SBType == "SI" || SBType == "SRETURN" || SBType == "PUR" || SBType == "PURCHLN") && (lbRC.Items.Count <= 0))
                            {
                                double Stock = Convert.ToDouble(Getresult("select CUR_QTY from iglmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ""));
                                double frqty = 0;
                                if (Information.IsNumeric(dgvItem.Rows[i].Cells[19].Value))
                                    frqty = Convert.ToDouble(dgvItem.Rows[i].Cells[19].Value);
                                Stock = Stock + (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value)) + frqty;// + Convert.ToDouble(dgvItem.Rows[i].Cells[11].Value));                                
                                cmd = new SqlCommand("Update iglmst Set CUR_QTY=" + Stock + " Where Ficode='" + edpcom.CurrentFicode + "' And gcode='" + edpcom.PCURRENT_GCODE + "' And pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                            else if ((SBType == "STKOUT" || SBType == "PR" || SBType == "CHLN" || SBType == "SALES") && (lbRC.Items.Count <= 0))
                            {
                                double Stock = Convert.ToDouble(Getresult("select CUR_QTY from iglmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ""));
                                double freqtyy = 0;
                                if (Information.IsNumeric(dgvItem.Rows[i].Cells[19].Value))
                                    freqtyy = Convert.ToDouble(dgvItem.Rows[i].Cells[19].Value);
                                Stock = Stock - (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value)) - freqtyy;// + Convert.ToDouble(dgvItem.Rows[i].Cells[11].Value));

                                cmd = new SqlCommand("Update iglmst Set CUR_QTY=" + Stock + " Where Ficode='" + edpcom.CurrentFicode + "' And gcode='" + edpcom.PCURRENT_GCODE + "' And pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    try
                    {
                        if (SBType == "SALES" && dgvAdditional.Rows.Count > 0 && dgvAdditional.Rows[0].Cells[0].Value != null && Flag_Printing == false)
                        {
                            string tpn = "", conNo = "", noPCK = "", srvNo = "", loryno = "", Dlvat = ""; decimal weight = 0;
                            string ConDate = "", SRVDATE = "";

                            for (int s = 0; s < dgvAdditional.Rows.Count; s++)
                            {
                                switch (dgvAdditional.Rows[s].HeaderCell.Value.ToString().Trim())
                                {
                                    case "Transport Name":
                                        {
                                            if (Information.IsNothing(dgvAdditional.Rows[s].Cells[0].Value) == false)
                                                tpn = dgvAdditional.Rows[s].Cells[0].Value.ToString();
                                            break;
                                        }
                                    case "Consingment No.":
                                        {
                                            if (Information.IsNothing(dgvAdditional.Rows[s].Cells[0].Value) == false)
                                                conNo = dgvAdditional.Rows[s].Cells[0].Value.ToString();
                                            break;
                                        }
                                    case "Consingment Date":
                                        {
                                            if (Information.IsNothing(dgvAdditional.Rows[s].Cells[0].Value) == false)
                                                ConDate = dgvAdditional.Rows[s].Cells[0].Value.ToString();
                                            break;
                                        }

                                    case "No of Packages":
                                        {
                                            if (Information.IsNothing(dgvAdditional.Rows[s].Cells[0].Value) == false)
                                                noPCK = dgvAdditional.Rows[s].Cells[0].Value.ToString();
                                            break;
                                        }

                                    case "SRV NO.":
                                        {
                                            if (Information.IsNothing(dgvAdditional.Rows[s].Cells[0].Value) == false)
                                                srvNo = dgvAdditional.Rows[s].Cells[0].Value.ToString();
                                            break;
                                        }
                                    case "SRV Date":
                                        {
                                            if (Information.IsNothing(dgvAdditional.Rows[s].Cells[0].Value) == false)
                                                SRVDATE = dgvAdditional.Rows[s].Cells[0].Value.ToString();
                                            break;
                                        }

                                    case "Lorry NO.":
                                        {
                                            if (Information.IsNothing(dgvAdditional.Rows[s].Cells[0].Value) == false)
                                                loryno = dgvAdditional.Rows[s].Cells[0].Value.ToString();
                                            break;
                                        }
                                    case "Weight":
                                        {
                                            if (Information.IsNumeric(dgvAdditional.Rows[s].Cells[0].Value))
                                                weight = Convert.ToDecimal(dgvAdditional.Rows[s].Cells[0].Value.ToString());
                                            break;
                                        }
                                    case "Delivery At":
                                        {
                                            if (Information.IsNothing(dgvAdditional.Rows[s].Cells[0].Value) == false)
                                                Dlvat = dgvAdditional.Rows[s].Cells[0].Value.ToString();
                                            break;
                                        }
                                    default: break;
                                }

                            }

                            cmd = new SqlCommand("insert into BillAdditionalDetails(FICode,GCODE,t_entry,voucher,transPortName,ConsingmentNo,ConsingmentDate,NoofPackages,SRVNO,SRVNODate,LorryNo,Weight,Delivery_At) "
                                + " values ('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + Tentry + "'," + vno + ", "
                               + " '" + tpn + "','" + conNo + "','" + ConDate + "','" + noPCK + "','" + srvNo + "','" + SRVDATE + "','" + loryno + "'," + weight + ",'" + Dlvat + "')", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch { }

                    if ((SBType != "STKOUT") && (SBType != "OS") && (SBType != "CHLN") && (SBType != "SI") && (SBType != "PO") && (SBType != "PURCHLN"))
                    {
                        if (!SaveJournal(vno))
                        {
                            SQLT.Rollback();
                            edpcon.Close();
                        }
                    }
                    if (!CHKORD)
                    {
                        SQLT.Commit();
                        edpcon.Close();
                    }
                    if (action == "ADD")
                    {
                        string[] s = new string[] { };
                        s = txtvoucher.Text.Trim().Split('/');
                        if (s.Length == 3)
                        {
                            int ss = Convert.ToInt32(s[2]);
                            edpcom.UpdateDocNumber(Desccode, Convert.ToString(Tentry), ss);
                        }
                        //if ((SBType == "SALES") && (lbcmp.Items.Count==0) && (lbRC.Items.Count==0))
                        //{
                        //    string[] s1 = new string[] { };
                        //    s1 = txtVoucherChallan.Text.Trim().Split('/');
                        //    int ss1 = Convert.ToInt32(s1[2]);
                        //    edpcom.UpdateDocNumber(Desccode, Convert.ToString("n"), ss1);
                        //}
                        //else if ((SBType == "SALES") && (lbcmp.Items.Count > 0) && (lbRC.Items.Count == 0))
                        //{
                        //    string[] s1 = new string[] { };
                        //    s1 = txtVoucherChallan.Text.Trim().Split('/');
                        //    int ss1 = Convert.ToInt32(s1[2]);
                        //    edpcom.UpdateDocNumber(1, Convert.ToString("n"), ss1);
                        //}

                        //if ((SBType == "PUR") && (lbcmp.Items.Count == 0) && (lbRC.Items.Count == 0))
                        //{
                        //    string[] s1 = new string[] { };
                        //    s1 = txtVoucherChallan.Text.Trim().Split('/');
                        //    int ss1 = Convert.ToInt32(s1[2]);
                        //    edpcom.UpdateDocNumber(1, Convert.ToString("a"), ss1);
                        //}
                        
                        if (!CHKORD)
                            EDPMessage.Show("Save this record.", "Message");
                    }
                    else
                        EDPMessage.Show("Modify this record.", "Message");
                    if (Tentry == "9")
                    {
                        if (EDPComm.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno='3.10.1'") == "TRUE")
                        {
                            if (Flag_Printing)
                            {
                                billrpt bill = new billrpt();
                                bill.voucher(txtvoucher.Text, Tentry,vno);
                                bill.ShowDialog();
                            }
                        }
                        else
                        {
                            string voucher = txtvoucher.Text;
                            FinanceReport.sellbillrpt sb = new FinanceReport.sellbillrpt();
                            sb.voucher(voucher, vno);
                            sb.ShowDialog();
                        }
                        //}
                    }
                    if (Tentry == "n")
                    {
                        if (EDPComm.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno='3.10.1'") == "TRUE")
                            if (Flag_Printing)
                            {
                                billrpt bill = new billrpt();
                                bill.voucher(txtvoucher.Text, Tentry,vno);
                                bill.ShowDialog();
                            }
                    }
                    if (CHKORD)
                        this.Close();
                    clearcontrol();
                    cleardgvAdditional();
                }
                flgDgvAdl = true;
                if (cmbAct.Text == "Accept")
                    cmbAct.SelectedIndex = 0;
                if (cmbAct.Text == "MODIFY")
                    cmbAct.SelectedIndex = 1;

                cmbAct_SelectedIndexChanged(cmbAct, e);
            }
            catch
            {
                SQLT.Rollback();
                edpcon.Close();
                if (action == "ADD")
                    EDPMessage.Show("Can't save this record, check line item.", "Message");
                else
                    EDPMessage.Show("Can't modify this record, check line item.", "Message");
                return;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAct.Text.Trim() == "DELETE")
                {
                    EDPMessage.Show("Are you sure to delete this record?", "Information", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
                    if (EDPMessage.ButtonResult == "edpYES")
                    {
                        if (Tentry == "SO")
                        {
                            string qry = " select  distinct id.user_vch, n.voucher from itran i,itran n,idata id where i.ficode=n.ficode and i.gcode=n.gcode and n.t_entry='n' and i.t_entry=n.ref_tentry and i.voucher=n.link_voucher and i.voucher=" + vno + " and i.t_entry='OS' " +
                                       " and n.ficode=id.ficode and n.gcode=id.gcode and n.voucher=id.voucher and n.t_entry=id.t_entry  and id.link_datat_entry='n' and i.ficode='" + edpcom.CurrentFicode + "' and i.gcode='" + edpcom.PCURRENT_GCODE + "'";

                            DataTable dtSO = edpcom.GetDatatable(qry);
                            if (dtSO.Rows.Count > 0)
                            {
                                EDPMessage.Show(" This Voucher is already used in voucher no  '" + dtSO.Rows[0][0] + " ' ,so it can't be deleted.");
                                return;
                            }
                        }
                        if (Tentry == "OP")
                        {
                            string qry = " select  distinct id.user_vch, n.voucher from itran i,itran n,idata id where i.ficode=n.ficode and i.gcode=n.gcode and n.t_entry='a' and i.t_entry=n.ref_tentry and i.voucher=n.link_voucher and i.voucher=" + vno + " and i.t_entry='OP' " +
                                       " and n.ficode=id.ficode and n.gcode=id.gcode and n.voucher=id.voucher and n.t_entry=id.t_entry  and id.link_datat_entry='a' and  i.ficode='" + edpcom.CurrentFicode + "' and i.gcode='" + edpcom.PCURRENT_GCODE + "'";

                            DataTable dtSO = edpcom.GetDatatable(qry);
                            if (dtSO.Rows.Count > 0)
                            {
                                EDPMessage.Show(" This Voucher is already used in voucher no  '" + dtSO.Rows[0][0] + " ' ,so it can't be deleted.");
                                return;
                            }
                        }
                        edpcon.Open();
                        SQLT = edpcon.mycon.BeginTransaction();
                        if (action == "DELETE" && SBType == "SALES" && lbRC.Items.Count > 0)
                        {
                            cmd = new SqlCommand("delete from BILL where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry in('" + Tentry + "') and voucher=" + vno + " and user_vch='" + txtvoucher.Text + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("delete from idata where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry in('" + Tentry + "') and voucher=" + vno + " and user_vch='" + txtvoucher.Text + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("delete from inarr where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + Tentry + "' and voucher=" + vno + "", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM itran WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY IN ('" + Tentry + "')", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM data WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND linkvoucher = " + vno + " AND T_ENTRY='" + Tentry + "' and linkTentry='" + LTE + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM vchr WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND linkvoucher = " + vno + " AND T_ENTRY='" + Tentry + "' and linkTentry='" + LTE + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM narr WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND linkvoucher = " + vno + " AND T_ENTRY='" + Tentry + "' and linkTentry='" + LTE + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM AddLess WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY IN ('" + Tentry + "')", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM AddlessLineItem WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY='" + Tentry + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM ConsumeProduct WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY='" + Tentry + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM BillAdditionalDetails WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND voucher = " + vno + " AND t_entry='" + Tentry + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd = new SqlCommand("delete from BILL where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry in('" + Tentry + "') and voucher=" + vno + " and user_vch='" + txtvoucher.Text + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("delete from idata where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry in('" + Tentry + "','" + LTE + "') and voucher=" + vno + "", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("delete from inarr where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + Tentry + "' and voucher=" + vno + "", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM itran WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY IN ('" + Tentry + "','" + LTE + "')", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM data WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND linkvoucher = " + vno + " AND T_ENTRY='" + Tentry + "' and linkTentry='" + LTE + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM vchr WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND linkvoucher = " + vno + " AND T_ENTRY='" + Tentry + "' and linkTentry='" + LTE + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM narr WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND linkvoucher = " + vno + " AND T_ENTRY='" + Tentry + "' and linkTentry='" + LTE + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM AddLess WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY IN ('" + Tentry + "')", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM AddlessLineItem WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY='" + Tentry + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM ConsumeProduct WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY='" + Tentry + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM BillAdditionalDetails WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND voucher = " + vno + " AND t_entry='" + Tentry + "'", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }

                        for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                        {
                            if ((SBType == "SI" || SBType == "SRETURN" || SBType == "PUR" || SBType == "PURCHLN") && (lbRC.Items.Count <= 0))
                            {
                                double Stock = Convert.ToDouble(Getresult("select CUR_QTY from iglmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ""));
                                Stock = Stock - (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value));// + Convert.ToDouble(dgvItem.Rows[i].Cells[11].Value));
                                cmd = new SqlCommand("Update iglmst Set CUR_QTY=" + Stock + " Where Ficode='" + edpcom.CurrentFicode + "' And gcode='" + edpcom.PCURRENT_GCODE + "' And pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                            else if ((SBType == "STKOUT" || SBType == "PR" || SBType == "CHLN" || SBType == "SALES") && (lbRC.Items.Count <= 0))
                            {
                                double Stock = Convert.ToDouble(Getresult("select CUR_QTY from iglmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ""));
                                Stock = Stock + (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value));// + Convert.ToDouble(dgvItem.Rows[i].Cells[11].Value));
                                cmd = new SqlCommand("Update iglmst Set CUR_QTY=" + Stock + " Where Ficode='" + edpcom.CurrentFicode + "' And gcode='" + edpcom.PCURRENT_GCODE + "' And pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }

                            if (Tentry == "n" && cmbAct.Text == "DELETE")
                            {
                                cmd = new SqlCommand("Update itran set DSTATUS='RUNNING' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='OS' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and itemno=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                            if (Tentry == "9" && cmbAct.Text == "DELETE" && lbRC.Items.Count > 0)
                            {
                                cmd = new SqlCommand("Update itran set DSTATUS='RUNNING' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='n' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and itemno=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                            if (Tentry == "a" && cmbAct.Text == "DELETE")
                            {
                                cmd = new SqlCommand("Update itran set DSTATUS='RUNNING' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='OP' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and itemno=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }

                            if (Tentry == "9" && cmbAct.Text == "DELETE" && lbcmp.Items.Count > 0)
                            {
                                cmd = new SqlCommand("Update itran set DSTATUS='RUNNING' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='OS' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and itemno=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }

                            if (Tentry == "8" && cmbAct.Text == "DELETE" && lbcmp.Items.Count > 0)
                            {
                                cmd = new SqlCommand("Update itran set DSTATUS='RUNNING' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='OP' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and itemno=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }
                            if (Tentry == "8" && cmbAct.Text == "DELETE" && lbRC.Items.Count > 0)
                            {
                                cmd = new SqlCommand("Update itran set DSTATUS='RUNNING' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='a' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and ucode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and  voucher=" + Convert.ToInt32(dgvItem.Rows[i].Cells[12].Value) + "  and itemno=" + Convert.ToInt32(dgvItem.Rows[i].Cells[13].Value) + "", edpcon.mycon, SQLT);
                                cmd.ExecuteNonQuery();
                            }

                        }
                        SQLT.Commit();
                        edpcon.Close();
                        edpcom.delCurrentVoucher(Tentry, vno);
                        EDPMessage.Show("Successfully Deleted.", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                        cmbAct_SelectedIndexChanged(cmbAct, e);
                    }
                }
                if (action == "MODIFY")
                {
                    for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                    {
                        if ((SBType == "STKOUT" || SBType == "PR" || SBType == "CHLN" || SBType == "SALES") && (lbRC.Items.Count <= 0))
                        {
                            double Stock = Convert.ToDouble(Getresult("select CUR_QTY from iglmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and PCODE=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ""));
                            double VchStock = Convert.ToDouble(Getresult("select BASEQTY from itran where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and PCODE=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " AND T_Entry='" + Tentry + "' AND VOUCHER=" + vno + ""));
                            Stock = Stock + VchStock;
                            cmd = new SqlCommand("Update iglmst Set CUR_QTY=" + Stock + " Where Ficode='" + edpcom.CurrentFicode + "' And gcode='" + edpcom.PCURRENT_GCODE + "' And PCODE=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + "", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }
                        else if ((SBType == "SI" || SBType == "SRETURN" || SBType == "PUR" || SBType == "PURCHLN") && (lbRC.Items.Count <= 0))
                        {
                            double Stock = Convert.ToDouble(Getresult("select CUR_QTY from iglmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and PCODE=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + ""));
                            double VchStock = Convert.ToDouble(Getresult("select BASEQTY from itran where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and PCODE=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " AND T_Entry='" + Tentry + "' AND VOUCHER=" + vno + ""));
                            Stock = Stock - VchStock;
                            cmd = new SqlCommand("Update iglmst Set CUR_QTY=" + Stock + " Where Ficode='" + edpcom.CurrentFicode + "' And gcode='" + edpcom.PCURRENT_GCODE + "' And PCODE=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + "", edpcon.mycon, SQLT);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    cmd = new SqlCommand("delete from BILL where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry in('" + Tentry + "') and voucher=" + vno + " and user_vch='" + txtvoucher.Text + "'", edpcon.mycon, SQLT);
                    cmd.ExecuteNonQuery();
                    if (lbRC.Items.Count <= 0)
                        cmd = new SqlCommand("delete from idata where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry in('" + Tentry + "','" + LTE + "') and voucher=" + vno + "", edpcon.mycon, SQLT);
                    else
                        cmd = new SqlCommand("delete from idata where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry in('" + Tentry + "') and voucher=" + vno + "", edpcon.mycon, SQLT);
                        cmd.ExecuteNonQuery();
                    
                    cmd = new SqlCommand("delete from inarr where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + Tentry + "' and voucher=" + vno + "", edpcon.mycon, SQLT);
                    cmd.ExecuteNonQuery();
                    if (lbRC.Items.Count <= 0)
                        cmd = new SqlCommand("DELETE FROM itran WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY IN ('" + Tentry + "','" + LTE + "')", edpcon.mycon, SQLT);
                    else
                        cmd = new SqlCommand("DELETE FROM itran WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY IN ('" + Tentry + "')", edpcon.mycon, SQLT);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("DELETE FROM data WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND linkvoucher = " + vno + " AND T_ENTRY='" + Tentry + "' and linkTentry='" + LTE + "'", edpcon.mycon, SQLT);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("DELETE FROM vchr WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND linkvoucher = " + vno + " AND T_ENTRY='" + Tentry + "' and linkTentry='" + LTE + "'", edpcon.mycon, SQLT);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("DELETE FROM narr WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND linkvoucher = " + vno + " AND T_ENTRY='" + Tentry + "' and linkTentry='" + LTE + "'", edpcon.mycon, SQLT);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("DELETE FROM AddLess WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY IN ('" + Tentry + "')", edpcon.mycon, SQLT);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("DELETE FROM AddlessLineItem WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY='" + Tentry + "'", edpcon.mycon, SQLT);
                    cmd.ExecuteNonQuery();
                    //cmd = new SqlCommand("DELETE FROM RawMeterialDetails WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY='" + Tentry + "'", edpcon.mycon, SQLT);
                    //cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("DELETE FROM BillAdditionalDetails WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND voucher = " + vno + " AND t_entry='" + Tentry + "'", edpcon.mycon, SQLT);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("DELETE FROM ConsumeProduct WHERE FICode = '" + edpcom.CurrentFicode + "' AND GCODE = '" + edpcom.PCURRENT_GCODE + "' AND VOUCHER = " + vno + " AND T_ENTRY='" + Tentry + "'", edpcon.mycon, SQLT);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { SQLT.Rollback(); edpcon.Close(); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string Getresult(string command)
        {
            try
            {
                SqlCommand mycmd = new SqlCommand(command, edpcon.mycon, SQLT);
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
                return data;
            }
            catch
            {
                return null;
            }
        }

        bool SaveJournal(Int32 voucher1)
        {
            //Checkdata();//check all the exceptions (validating)
            Check = true;
            if (Check)
            {
                errProv.Clear();
                try
                {
                    DataSet ds = new DataSet(); SqlCommandBuilder cmb;
                    DataRow dr; SqlCommand cmd;
                    string sql = "select * from data where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + Tentry + "'";
                    cmd = new SqlCommand(sql, edpcon.mycon, SQLT);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    cmb = new SqlCommandBuilder(da);
                    cmb.QuotePrefix = "[";
                    cmb.QuoteSuffix = "]";
                    da.Fill(ds, "DATA");
                    sql = "Select * from narr where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + Tentry + "'";
                    cmd = new SqlCommand(sql, edpcon.mycon, SQLT);
                    SqlDataAdapter daN = new SqlDataAdapter();
                    daN.SelectCommand = cmd;
                    cmb = new SqlCommandBuilder(daN);
                    cmb.QuotePrefix = "[";
                    cmb.QuoteSuffix = "]";
                    daN.Fill(ds, "NARR");
                    sql = "Select * from narr where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + Tentry + "'";
                    cmd = new SqlCommand(sql, edpcon.mycon, SQLT);
                    SqlDataAdapter daNC = new SqlDataAdapter();
                    daNC.SelectCommand = cmd;
                    cmb = new SqlCommandBuilder(daNC);
                    cmb.QuotePrefix = "[";
                    cmb.QuoteSuffix = "]";
                    daNC.Fill(ds, "NARR_CHQ");

                    /*action= add*/
                    if ((cmbAct.SelectedIndex == 0) || (cmbAct.SelectedIndex == 1))//add voucher into data table
                    {
                        dr = ds.Tables["DATA"].NewRow();//data table
                        dr[0] = edpcom.CurrentFicode;
                        dr[1] = edpcom.PCURRENT_GCODE;
                        dr[2] = Tentry;
                        dr[3] = vno;//voucher
                        dr[4] = dtp.Value;
                        dr[5] = txtvoucher.Text.Trim();
                        dr[6] = currcode;//currencycode
                        //dr[9] = brnchcode;//branchcode
                        dr[10] = Desccode;//Desccode
                        dr[11] = true;
                        dr[12] = vno;
                        dr[13] = LTE;
                        //dr[15] = Getresult("select glcode from glmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and mtype='L'  and (ACTV_FLG IS NULL OR ACTV_FLG='True')  and ldesc='" + cmbPartyName.Text.Trim() + "'");//glcode;
                        //dr[16] = '3';
                        //dr[17] = JVNO;
                        ds.Tables["DATA"].Rows.Add(dr);
                        da.Update(ds, "DATA");// add to the database server   

                        dr = ds.Tables["NARR"].NewRow();
                        dr["FICODE"] = edpcom.CurrentFicode;
                        dr["GCODE"] = edpcom.PCURRENT_GCODE;
                        dr["T_ENTRY"] = Tentry;
                        dr["VOUCHER"] = vno;//voucher
                        //dr["BRNCH_CODE"] = brnchcode;//branch code
                        dr["CURR_CODE"] = currcode;//currency code
                        dr["NTYPE"] = 'N';
                        dr["NAR1"] = txtNarr.Text;
                        dr["linkvoucher"] = vno;
                        dr["linkTentry"] = LTE;
                        ds.Tables["NARR"].Rows.Add(dr);
                        daN.Update(ds, "NARR");// add to the database server     
                    }

                    double ItemVAL = 0, AdlesVal = 0;
                    for (int i = 0; i <= dgvItem.Rows.Count - 1; i++)
                    {
                        ItemVAL = ItemVAL + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value);
                    }

                    if ((Flag_Printing) && (Convert.ToDouble(txtTotalAmt.Text)) > 0)
                    {
                        ItemVAL = Convert.ToDouble(txtTotalAmt.Text);
                    }

                    for (int i = 0; i <= dgvAddless.Rows.Count - 1; i++)
                    {
                        AdlesVal = AdlesVal + Convert.ToDouble(dgvAddless.Rows[i].Cells[3].Value);
                    }
                    double PartyAmt=0;
                    if ((chkIncVAT.Checked) && (Convert.ToDouble(txtTotalAmt.Text) > 0))
                    {
                        PartyAmt = ItemVAL;
                    }
                    else
                        PartyAmt = ItemVAL + AdlesVal;

                    sql = "delete from vchr where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and linkTentry='" + LTE + "' and t_entry='" + Tentry + "' and voucher=" + vno;
                    cmd = new SqlCommand(sql, edpcon.mycon, SQLT);
                    cmd.ExecuteNonQuery();
                    sql = "select * from vchr where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + Tentry + "'";
                    cmd = new SqlCommand(sql, edpcon.mycon, SQLT);
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    cmb = new SqlCommandBuilder(da);
                    cmb.QuotePrefix = "[";
                    cmb.QuoteSuffix = "]";
                    da.Fill(ds, "VCHR");
                    //========================== Party A/C Or Cash A/C ===                    
                    dr = ds.Tables["VCHR"].NewRow();
                    dr[0] = edpcom.CurrentFicode;
                    dr[1] = edpcom.PCURRENT_GCODE;
                    dr[2] = Tentry;
                    dr[3] = vno;//voucher
                    dr[5] = txtvoucher.Text;//user vocher number
                    //dr[6] = edpcom.getSqlDateStr(dtp.Value);
                    dr[6] = dtp.Value.ToShortDateString();
                    if (chkCash.Checked)
                        dr[7] = CashCode;//glcode                    
                    else
                        dr[7] = PartyCode;//glcode                          
                    dr[8] = 0;
                    dr[9] = "By";
                    dr[13] = PartyAmt.ToString(common.SetDecimalPlace());
                    dr[14] = 0;
                    dr[16] = PartyAmt.ToString(common.SetDecimalPlace());
                    dr[20] = vno;
                    dr[21] = LTE;
                    ds.Tables["VCHR"].Rows.Add(dr);
                    //==========================

                    //========================== Sales A/C ===
                    if (!MultiSalePurAC)
                    {
                        dr = ds.Tables["VCHR"].NewRow();
                        dr[0] = edpcom.CurrentFicode;
                        dr[1] = edpcom.PCURRENT_GCODE;
                        dr[2] = Tentry;
                        dr[3] = vno;//voucher
                        dr[5] = txtvoucher.Text;//user vocher number
                        //dr[6] = edpcom.getSqlDateStr(dtp.Value);
                        dr[6] = dtp.Value.ToShortDateString();
                        dr[7] = SalesCode;//glcode          
                        if ((chkIncVAT.Checked) && (Convert.ToDouble(txtTotalAmt.Text) > 0))
                        {
                            ItemVAL = ItemVAL - AdlesVal;
                            dr[8] = ItemVAL.ToString(common.SetDecimalPlace());
                        }
                        else
                            dr[8] = ItemVAL.ToString(common.SetDecimalPlace());
                        dr[9] = "To";
                        dr[13] = 0;
                        dr[14] = ItemVAL.ToString(common.SetDecimalPlace());
                        dr[16] = 0;
                        dr[20] = vno;
                        dr[21] = LTE;
                        ds.Tables["VCHR"].Rows.Add(dr);
                    }
                    else
                    {
                        for (int l = 0; l <= dgvItem.RowCount - 1; l++)
                        {
                            dr = ds.Tables["VCHR"].NewRow();
                            dr[0] = edpcom.CurrentFicode;
                            dr[1] = edpcom.PCURRENT_GCODE;
                            dr[2] = Tentry;
                            dr[3] = vno;//voucher
                            dr[5] = txtvoucher.Text;//user vocher number
                            //dr[6] = edpcom.getSqlDateStr(dtp.Value);
                            dr[6] = dtp.Value.ToShortDateString();
                            //dr[7] = SalesCode;//glcode                    
                            dr[7] = dgvItem.Rows[l].Cells[22].Value;//glcode                    
                            //dr[8] = ItemVAL.ToString(common.SetDecimalPlace());
                            dr[8] = Convert.ToDouble(dgvItem.Rows[l].Cells[6].Value);
                            dr[9] = "To";
                            dr[13] = 0;
                            //dr[14] = ItemVAL.ToString(common.SetDecimalPlace());
                            dr[14] = Convert.ToDouble(dgvItem.Rows[l].Cells[6].Value);
                            dr[16] = 0;
                            dr[20] = vno;
                            dr[21] = LTE;
                            ds.Tables["VCHR"].Rows.Add(dr);
                        }
                    }
                    //==========================
                    string pva = "PVA";
                    if ((MultiSalePurAC) && (pva != "PVA"))
                    {
                        for (int i = 0; i <= dgvItem.Rows.Count - 1; i++)
                        {
                            dr = ds.Tables["VCHR"].NewRow();
                            dr[0] = edpcom.CurrentFicode;
                            dr[1] = edpcom.PCURRENT_GCODE;
                            dr[2] = Tentry;
                            dr[3] = vno;//voucher
                            dr[5] = txtvoucher.Text;//user vocher number
                            //dr[6] = edpcom.getSqlDateStr(dtp.Value);
                            dr[6] = dtp.Value.ToShortDateString();
                            dr[7] = dgvItem.Rows[i].Cells[23].Value;//Getresult("select glcode from glmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and mtype='L'  and (ACTV_FLG IS NULL OR ACTV_FLG='True')  and ldesc='" + dgvAddless.Rows[i].Cells[0].Value + "'");//glcode
                            dr[8] = Convert.ToDouble(dgvItem.Rows[i].Cells[24].Value);
                            dr[9] = "To";
                            dr[13] = 0;
                            dr[14] = Convert.ToDouble(dgvItem.Rows[i].Cells[24].Value);
                            dr[16] = 0;
                            dr[20] = vno;
                            dr[21] = LTE;
                            ds.Tables["VCHR"].Rows.Add(dr);
                        }
                    }

                    for (int i = 0; i <= dgvAddless.Rows.Count - 1; i++)
                    {
                        dr = ds.Tables["VCHR"].NewRow();
                        dr[0] = edpcom.CurrentFicode;
                        dr[1] = edpcom.PCURRENT_GCODE;
                        dr[2] = Tentry;
                        dr[3] = vno;//voucher
                        dr[5] = txtvoucher.Text;//user vocher number
                        //dr[6] = edpcom.getSqlDateStr(dtp.Value);
                        dr[6] = dtp.Value.ToShortDateString();
                        dr[7] = Getresult("select glcode from glmst where  gcode='" + edpcom.PCURRENT_GCODE + "' and ficode='" + edpcom.CurrentFicode + "' and mtype='L'  and (ACTV_FLG IS NULL OR ACTV_FLG='True')  and ldesc='" + dgvAddless.Rows[i].Cells[0].Value + "'");//glcode
                        dr[8] = Convert.ToDouble(dgvAddless.Rows[i].Cells[3].Value);
                        dr[9] = "To";
                        dr[13] = 0;
                        dr[14] = Convert.ToDouble(dgvAddless.Rows[i].Cells[3].Value);
                        dr[16] = 0;
                        dr[20] = vno;
                        dr[21] = LTE;
                        ds.Tables["VCHR"].Rows.Add(dr);
                    }
                    da.Update(ds, "VCHR");// add to the database server                    
                    ds.Tables.Clear();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }

        private void cmbAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblQty.Text = "";
                lblItemNo.Text = "";
                Flgaddless = true;
                clearcontrol();
                action = cmbAct.SelectedItem.ToString();
                dgvItem.Rows.Clear();
                //dgvItem.Columns[0].ReadOnly = true;
                dgvItem.Columns[1].ReadOnly = false;
                if (SBType == "SALES" || SBType == "PUR")
                {
                    label11.Visible = true;
                    txtVoucherChallan.Visible = true;
                }
                if (action == "ADD")
                {
                    btnAcc.Text = " Accept";
                    btnAcc.Enabled = true;
                    btnDel.Enabled = false;
                    txtDesc.ReadOnly = false;
                    dgvItem.ReadOnly = false;
                    dgvAddless.ReadOnly = false;
                    dgvItem.Columns[0].ReadOnly = true;
                    txtNarr.ReadOnly = false;
                    txtcurrency.PopUp(sender, e);
                    txtDesc.PopUp(sender, e);
                    txtvoucher.Text = edpcom.GetDocNumber(Desccode, Convert.ToString(Tentry));
                    //if (SBType == "PUR")
                    //    txtVoucherChallan.Text = edpcom.GetDocNumber(1, Convert.ToString("a"));
                    //else if (SBType == "SALES")
                    //    txtVoucherChallan.Text = edpcom.GetDocNumber(1, Convert.ToString("n"));
                    txtVoucherChallan.Text = txtvoucher.Text;
                    if (Flag_Cash)
                        cmbCash.PopUp();
                    else
                    {
                        if (!CHKORD)
                            cmbPartyName_DropDown(cmbPartyName, e);
                    }
                    RBItemDetail_Click(RBItemDetail, e);
                }
                else if (action == "MODIFY")
                {
                    btnAcc.Text = " Modify";
                    btnDel.Enabled = false;
                    btnAcc.Enabled = true;
                    txtDesc.ReadOnly = false;
                    txtNarr.ReadOnly = false;
                    dgvItem.Columns[0].ReadOnly = true;
                    txtvoucher.PopUp();
                    RBItemDetail.Checked = true;
                    RBItemDetail_Click(RBItemDetail, e);
                }
                else if (action == "VIEW")
                {
                    btnDel.Enabled = false;
                    btnAcc.Enabled = false;
                    txtDesc.ReadOnly = true;
                    dgvItem.ReadOnly = true;
                    dgvAddless.ReadOnly = true;
                    txtNarr.ReadOnly = true;
                    txtvoucher.PopUp();
                }
                else if (action == "DELETE")
                {
                    txtvoucher.Text = "";
                    btnAcc.Enabled = false;
                    btnDel.Enabled = true;
                    txtDesc.ReadOnly = true;
                    dgvItem.ReadOnly = true;
                    dgvAddless.ReadOnly = true;
                    txtNarr.ReadOnly = true;
                    txtvoucher.PopUp();
                }
            }
            catch { }
        }

        private void btnRefOrd_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!validation())
                //    return;

                common.arr_mod.Clear();
                common.get_code.Clear();
                if (Tentry == "9")
                {
                    if (lbRC.Items.Count > 0)
                    {
                        DialogResult dr = new DialogResult();
                        dr = MessageBox.Show("Do you want to Invoice  from Refference Order ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            lbRC.Items.Clear();
                            RefChal = null;
                        }
                        else
                            return;
                    }
                }

                string st = "";
                if (SBType == "SI")
                {
                    st = " SELECT DISTINCT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE] FROM IDATA ID,itran it WHERE ID.FICODE=it.ficode and ID.gcode=it.gcode and ID.FICODE='" + edpcom.CurrentFicode + "' AND " +
                      " ID.voucher=it.voucher and ID.t_entry=it.T_entry and  ID.GCODE='" + edpcom.PCURRENT_GCODE + "' AND ID.T_ENTRY='OS' AND ID.Party_code=" + PartyCode + " and it.DSTATUS='RUNNING'";
                }
                else if (SBType == "CHLN")
                {
                    st = " SELECT DISTINCT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE] FROM IDATA ID,itran it WHERE ID.FICODE=it.ficode and ID.gcode=it.gcode and ID.FICODE='" + edpcom.CurrentFicode + "' AND " +
                      " ID.voucher=it.voucher and ID.t_entry=it.T_entry and  ID.GCODE='" + edpcom.PCURRENT_GCODE + "' AND ID.T_ENTRY='OS' AND ID.Party_code=" + PartyCode + " and it.DSTATUS='RUNNING'";
                }
                else if (SBType == "PURCHLN")
                {
                    st = " SELECT DISTINCT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE] FROM IDATA ID,itran it WHERE ID.FICODE=it.ficode and ID.gcode=it.gcode and ID.FICODE='" + edpcom.CurrentFicode + "' AND " +
                      " ID.voucher=it.voucher and ID.t_entry=it.T_entry and  ID.GCODE='" + edpcom.PCURRENT_GCODE + "' AND ID.T_ENTRY='OP' AND ID.Party_code=" + PartyCode + " and it.DSTATUS='RUNNING'";
                }
                else if (SBType == "SALES")
                {
                    st = " SELECT DISTINCT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE] FROM IDATA ID,itran it WHERE ID.FICODE=it.ficode and ID.gcode=it.gcode and ID.FICODE='" + edpcom.CurrentFicode + "' AND " +
                      " ID.voucher=it.voucher and ID.t_entry=it.T_entry and  ID.GCODE='" + edpcom.PCURRENT_GCODE + "' AND ID.T_ENTRY='OS' AND ID.Party_code=" + PartyCode + " and it.DSTATUS='RUNNING'";
                }
                else if (SBType == "PUR")
                {
                    st = " SELECT DISTINCT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE] FROM IDATA ID,itran it WHERE ID.FICODE=it.ficode and ID.gcode=it.gcode and ID.FICODE='" + edpcom.CurrentFicode + "' AND " +
                      " ID.voucher=it.voucher and ID.t_entry=it.T_entry and  ID.GCODE='" + edpcom.PCURRENT_GCODE + "' AND ID.T_ENTRY='OP' AND ID.Party_code=" + PartyCode + " and it.DSTATUS='RUNNING'";
                }
                common.MLOV(st, "Tag Order User Vch", "Select User Vch", "List of Order User Vch", 0, "CMPN", 0);

                arr.Clear();
                arr = common.arr_mod;
                if (arr.Count > 0)
                {
                    getcode.Clear();
                    arr = common.arr_mod;
                    getcode = common.get_code;
                    lbcmp.Items.Clear();
                    Pcode_sl = null;
                    for (int i = 0; i <= (arr.Count - 1); i++)
                    {
                        lbcmp.Items.Add(arr[i].ToString());
                        Pcode_sl = Pcode_sl + getcode[i].ToString();
                        if (i != getcode.Count - 1)
                        {
                            Pcode_sl = Pcode_sl + ",";
                        }
                    }
                    if (SBType == "SI")
                        RefOrderForStockIn();

                    else
                        RefBill();
                }
            }
            catch
            {
            }
        }

        private void RefOrderForStockIn()
        {
            try
            {
                bool flagforRow = true;
                if (Pcode_sl == "")
                    return;

                string str = "";
                common.ClearDataTable(ds.Tables["ItemDls"]);
                str = "SELECT DISTINCT IG.PDESC,IT.QTY,U.UDESC,IT.USeries,IT.RATE,IT.DIS_AMT,IT.AMT,IT.PCODE,IT.BASEQTY,IT.UCODE,B.T_ENTRY,B.VOUCHER,IT.REFF_ITEM_NO,IT.Volume,IT.Size,IT.RefPagePerFormat,IT.FreeQTY"
                           + " FROM itran IT,IGLMST IG,UNIT U,IDATA B WHERE"
                           + " B.FICODE='" + edpcom.CurrentFicode + "' AND B.GCODE='" + edpcom.PCURRENT_GCODE + "' AND B.T_ENTRY='OS' AND B.Party_code=" + PartyCode + " AND B.VOUCHER IN(" + Pcode_sl + ") AND"
                           + " B.FICODE=IT.FICODE AND B.GCODE=IT.GCODE AND B.T_ENTRY=IT.T_ENTRY AND B.VOUCHER=IT.VOUCHER AND"
                           + " IT.FICODE=IG.FICODE AND IT.GCODE=IG.GCODE AND"
                           + " IT.PCODE =IG.PCODE "
                           + " AND IT.FICODE=U.FICODE AND IT.GCODE=U.GCODE AND IT.UCODE=U.UCODE";

                cmd = new SqlCommand(str, edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "ItemDls");

                if (dgvItem.Rows.Count > 0)
                    dgvItem.Rows.Clear();

                if (dgvItem.Rows.Count == 1)
                    flagforRow = false;
                TotalAmt = 0;

                if (ds.Tables["ItemDls"].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables["ItemDls"].Rows.Count - 1; i++)
                    {
                        int SMID = 0;
                        if (ds.Tables["ItemDls"].Rows[i][3] != null)
                            if (ds.Tables["ItemDls"].Rows[i][3] != "")
                                if (ds.Tables["ItemDls"].Rows[i][3].ToString() != "")
                                    SMID = Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][3].ToString());

                        common.ClearDataTable(ds.Tables["restQty"]);
                        string qryss = "select sum(n.baseqty) from itran n where n.ficode='" + edpcom.CurrentFicode + "' and n.gcode='" + edpcom.PCURRENT_GCODE + "' and n.t_entry='SI' and n.ref_voucher=" + ds.Tables["ItemDls"].Rows[i][11].ToString() + " and n.ref_tentry='" + ds.Tables["ItemDls"].Rows[i][10].ToString() + "' and n.pcode=" + ds.Tables["ItemDls"].Rows[i][7] + "";
                        cmd = new SqlCommand(qryss, edpcon.mycon);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "restQty");

                        if (Information.IsNumeric(ds.Tables["restQty"].Rows[0][0]))
                        {
                            double a = Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]);
                            double b = Convert.ToDouble(ds.Tables["restQty"].Rows[0][0]);
                            if ((a - b) == 0)
                                continue;
                        }
                        if (flagforRow == true)
                            dgvItem.Rows.Add();
                        flagforRow = true;
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[0].Value = ds.Tables["ItemDls"].Rows[i][0].ToString();

                        if (Information.IsNumeric(ds.Tables["restQty"].Rows[0][0]))
                        {
                            //string aa = common.BalQtySlashForm(Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0])), Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][7]), Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][9]), Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][3]));
                            string aa = common.BalQtySlashForm(Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0])), Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][7]));
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[1].Value = aa;
                        }
                        else
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[1].Value = ds.Tables["ItemDls"].Rows[i][1].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[2].Value = ds.Tables["ItemDls"].Rows[i][2].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[3].Value = Getresult1("SELECT DISTINCT SM_NAME FROM UnitSeriesMaster WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND SM_ID=" + SMID + "");
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[4].Value = ds.Tables["ItemDls"].Rows[i][4].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[5].Value = ds.Tables["ItemDls"].Rows[i][5].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[6].Value = ds.Tables["ItemDls"].Rows[i][6].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[7].Value = ds.Tables["ItemDls"].Rows[i][7].ToString();

                        if (Information.IsNumeric(ds.Tables["restQty"].Rows[0][0]))
                        {
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[8].Value = Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0]));
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[17].Value = Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0]));
                        }
                        else
                        {
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[8].Value = ds.Tables["ItemDls"].Rows[i][8].ToString();
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[17].Value = ds.Tables["ItemDls"].Rows[i][8].ToString();
                        }
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[9].Value = ds.Tables["ItemDls"].Rows[i][9].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[10].Value = ds.Tables["ItemDls"].Rows[i][3].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[11].Value = ds.Tables["ItemDls"].Rows[i][10].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[12].Value = ds.Tables["ItemDls"].Rows[i][11].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[13].Value = ds.Tables["ItemDls"].Rows[i][12].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[14].Value = ds.Tables["ItemDls"].Rows[i][13].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[15].Value = ds.Tables["ItemDls"].Rows[i][14].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[16].Value = ds.Tables["ItemDls"].Rows[i][15].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[17].Value = ds.Tables["ItemDls"].Rows[i][16].ToString();
                        try
                        {
                            TotalAmt = TotalAmt + Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][6].ToString());
                        }
                        catch { }
                    }
                }
                txtAmt.Text = TotalAmt.ToString(common.SetDecimalPlace());
                dgvItem.Columns[0].ReadOnly = true;
                dgvItem.Columns[1].ReadOnly = false;
                dgvItem.Columns[2].ReadOnly = true;
                dgvItem.Columns[3].ReadOnly = true;
            }
            catch { }
        }

        private void RefBill()
        {
            try
            {
                bool flagforRow = true;
                if (Pcode_sl == "")
                    return;

                string str = "";
                common.ClearDataTable(ds.Tables["ItemDls"]);
                if ((SBType == "PURCHLN") || (SBType == "PUR") || (SBType == "PO"))
                {
                    str = "SELECT IG.PDESC,IT.QTY,U.UDESC,IT.USeries,IT.RATE,IT.DIS_AMT,IT.AMT,IT.PCODE,IT.BASEQTY,IT.UCODE,B.T_ENTRY,B.VOUCHER,IT.ITEMNO,IT.Volume,IT.Size,IT.PPF,IT.RatingQty,IT.AmtCalOnVolume,B.ReffPartyCode"
                               + " FROM ITRAN IT,IGLMST IG,UNIT U,IDATA B WHERE"
                               + " B.FICODE='" + edpcom.CurrentFicode + "' AND B.GCODE='" + edpcom.PCURRENT_GCODE + "' AND B.T_ENTRY='OP' AND B.Party_code=" + PartyCode + " AND B.VOUCHER IN(" + Pcode_sl + ") AND" // B.DSTATUS<>'COMPLETED' AND"
                               + " B.FICODE=IT.FICODE AND B.GCODE=IT.GCODE AND B.T_ENTRY=IT.T_ENTRY AND B.VOUCHER=IT.VOUCHER AND"
                               + " IT.FICODE=IG.FICODE AND IT.GCODE=IG.GCODE AND IT.PCODE=IG.PCODE AND"
                               + " IT.FICODE=U.FICODE AND IT.GCODE=U.GCODE AND IT.UCODE=U.UCODE";
                }
                else
                {
                    str = "SELECT IG.PDESC,IT.QTY,U.UDESC,IT.USeries,IT.RATE,IT.DIS_AMT,IT.AMT,IT.PCODE,IT.BASEQTY,IT.UCODE,B.T_ENTRY,B.VOUCHER,IT.ITEMNO,IT.Volume,IT.Size,IT.PPF,IT.RefPCODE,IT.RefQty,IT.RefUCODE,IT.RefVolume,IT.RefSize,IT.RefPagePerFormat,IT.Freeqty,IT.RefPCODE,IT.RefQty,IT.RefUCODE,IT.RefVolume,IT.RefSize,IT.RefPagePerFormat,IT.Freeqty,IT.RatingQty,IT.AmtCalOnVolume,B.ReffPartyCode,IT.PrintQtyUcode,IT.PrintQty,IT.PaperConsume,B.IncluciveVAT,B.OnVATPer,B.AdhokAmt"
                                + " FROM ITRAN IT,IGLMST IG,UNIT U,IDATA B WHERE"
                                + " B.FICODE='" + edpcom.CurrentFicode + "' AND B.GCODE='" + edpcom.PCURRENT_GCODE + "' AND B.T_ENTRY='OS' AND B.Party_code=" + PartyCode + " AND B.VOUCHER IN(" + Pcode_sl + ") AND" // B.DSTATUS<>'COMPLETED' AND"
                                + " B.FICODE=IT.FICODE AND B.GCODE=IT.GCODE AND B.T_ENTRY=IT.T_ENTRY AND B.VOUCHER=IT.VOUCHER AND"
                                + " IT.FICODE=IG.FICODE AND IT.GCODE=IG.GCODE AND IT.PCODE=IG.PCODE AND"
                                + " IT.FICODE=U.FICODE AND IT.GCODE=U.GCODE AND IT.UCODE=U.UCODE";
                }
                cmd = new SqlCommand(str, edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "ItemDls");

                if (dgvItem.Rows.Count > 0)
                {
                    dgvItem.Rows.Clear();
                }

                if (dgvItem.Rows.Count == 1)
                    flagforRow = false;
                TotalAmt = 0;

                if (ds.Tables["ItemDls"].Rows.Count > 0)
                {
                    if (ds.Tables["ItemDls"].Rows[0]["IncluciveVAT"] != null)
                        if (Convert.ToString(ds.Tables["ItemDls"].Rows[0]["IncluciveVAT"]) != "")
                            chkIncVAT.Checked = Convert.ToBoolean(ds.Tables["ItemDls"].Rows[0]["IncluciveVAT"]);
                    if (ds.Tables["ItemDls"].Rows[0]["OnVATPer"] != null)
                        if (Convert.ToString(ds.Tables["ItemDls"].Rows[0]["OnVATPer"]) != "")
                            chkOnVATPer.Checked = Convert.ToBoolean(ds.Tables["ItemDls"].Rows[0]["OnVATPer"]);
                    if (ds.Tables["ItemDls"] != null)
                        if (Convert.ToString(ds.Tables["ItemDls"].Rows[0]["AdhokAmt"]) != "")
                            txtTotalAmt.Text = Convert.ToString(ds.Tables["ItemDls"].Rows[0]["AdhokAmt"]);
                    if (Information.IsNumeric(txtTotalAmt.Text) == false)
                        txtTotalAmt.Text = "0.00";

                    if (Information.IsNumeric(ds.Tables["ItemDls"].Rows[0]["ReffPartyCode"]) == true)
                    {
                        edpcon.Open();
                        ReffPartyCode = Convert.ToInt32(ds.Tables["ItemDls"].Rows[0]["ReffPartyCode"]);
                        cmbReffParty.Text = Getresult1("SELECT LDESC FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND GLCODE=" + ReffPartyCode + "");
                        edpcon.Close();
                    }
                    for (int i = 0; i <= ds.Tables["ItemDls"].Rows.Count - 1; i++)
                    {
                        int SMID = 0;
                        if (ds.Tables["ItemDls"].Rows[i][3] != null)
                            if (ds.Tables["ItemDls"].Rows[i][3] != "")
                                if (ds.Tables["ItemDls"].Rows[i][3].ToString() != "")
                                    SMID = Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][3].ToString());

                        common.ClearDataTable(ds.Tables["restQty"]);
                        string qryss = "";
                        if ((SBType == "OS") || (SBType == "CHLN") || (SBType == "SALES") || (SBType == "SI"))
                            qryss = "select sum(n.baseqty),sum(n.RefQty) from itran n where n.ficode='" + edpcom.CurrentFicode + "' and n.gcode='" + edpcom.PCURRENT_GCODE + "' and n.t_entry='n'  and n.ref_voucher=" + ds.Tables["ItemDls"].Rows[i][11].ToString() + " and n.REFF_ITEM_NO=" + ds.Tables["ItemDls"].Rows[i][12].ToString() + " and n.ref_tentry='" + ds.Tables["ItemDls"].Rows[i][10].ToString() + "' and n.pcode=" + ds.Tables["ItemDls"].Rows[i][7] + "";
                        else if ((SBType == "PO") || (SBType == "PURCHLN") || (SBType == "PUR"))
                            qryss = "select sum(n.baseqty),sum(n.RefQty) from itran n where n.ficode='" + edpcom.CurrentFicode + "' and n.gcode='" + edpcom.PCURRENT_GCODE + "' and n.t_entry='a'  and n.ref_voucher=" + ds.Tables["ItemDls"].Rows[i][11].ToString() + " and n.REFF_ITEM_NO=" + ds.Tables["ItemDls"].Rows[i][12].ToString() + " and n.ref_tentry='" + ds.Tables["ItemDls"].Rows[i][10].ToString() + "' and n.pcode=" + ds.Tables["ItemDls"].Rows[i][7] + "";
                        cmd = new SqlCommand(qryss, edpcon.mycon);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "restQty");

                        if (Information.IsNumeric(ds.Tables["restQty"].Rows[0][0]))
                        {
                            double a = Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]);
                            double b = Convert.ToDouble(ds.Tables["restQty"].Rows[0][0]);
                            if ((a - b) == 0)
                                continue;
                        }
                        if (flagforRow == true)
                            dgvItem.Rows.Add();
                        flagforRow = true;
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[0].Value = ds.Tables["ItemDls"].Rows[i][0].ToString();

                        if (Information.IsNumeric(ds.Tables["restQty"].Rows[0][0]))
                        {
                            //string aa = common.BalQtySlashForm(Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0])), Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][7]), Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][9]), Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][3]));
                            string aa = common.BalQtySlashForm(Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0])), Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][7]));
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[1].Value = aa;
                        }
                        else
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[1].Value = ds.Tables["ItemDls"].Rows[i][1].ToString();
                        edpcon.Open();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[2].Value = ds.Tables["ItemDls"].Rows[i][2].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[3].Value = Getresult1("SELECT DISTINCT SM_NAME FROM UnitSeriesMaster WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND SM_ID=" + SMID + "");
                        edpcon.Close();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[4].Value = ds.Tables["ItemDls"].Rows[i][4].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[5].Value = ds.Tables["ItemDls"].Rows[i][5].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[6].Value = ds.Tables["ItemDls"].Rows[i][6].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[7].Value = ds.Tables["ItemDls"].Rows[i][7].ToString();

                        if (Information.IsNumeric(ds.Tables["restQty"].Rows[0][0]))
                        {
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[8].Value = Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0]));
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[17].Value = Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0]));
                        }
                        else
                        {
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[8].Value = ds.Tables["ItemDls"].Rows[i][8].ToString();
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[17].Value = ds.Tables["ItemDls"].Rows[i][8].ToString();
                        }

                        //====================
                        if (Information.IsNumeric(ds.Tables["restQty"].Rows[0][1]))
                        {
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[32].Value = Convert.ToDouble(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][17]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][1]));
                        }
                        else
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[32].Value = ds.Tables["ItemDls"].Rows[i][17].ToString();

                        //====================

                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[9].Value = ds.Tables["ItemDls"].Rows[i][9].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[10].Value = ds.Tables["ItemDls"].Rows[i][3].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[11].Value = ds.Tables["ItemDls"].Rows[i][10].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[12].Value = ds.Tables["ItemDls"].Rows[i][11].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[13].Value = ds.Tables["ItemDls"].Rows[i][12].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[14].Value = ds.Tables["ItemDls"].Rows[i][13].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[15].Value = ds.Tables["ItemDls"].Rows[i][14].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[16].Value = ds.Tables["ItemDls"].Rows[i][15].ToString();

                        if ((Flag_Printing) && (Tentry == "n" || Tentry == "9"))
                        {
                            dgvItem.Rows[i].Cells[31].Value = ds.Tables["ItemDls"].Rows[i][16].ToString();
                            DataTable dtRef = edpcom.GetDatatable(" select distinct i.pdesc,i.ucode,u.UDESC from iglmst i,unit u where i.ficode='" + edpcom.CurrentFicode + "' and i.gcode='" + edpcom.PCURRENT_GCODE + "' and i.ficode=u.ficode and i.gcode=u.gcode and i.ucode=u.ucode and i.pcode=" + Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][16].ToString()) + " ");
                            if (dtRef.Rows.Count > 0)
                            {
                                dgvItem.Rows[i].Cells[30].Value = dtRef.Rows[0][0].ToString();
                                dgvItem.Rows[i].Cells[33].Value = dtRef.Rows[0][2].ToString();
                            }
                            //dgvItem.Rows[i].Cells[32].Value = ds.Tables["ItemDls"].Rows[i][17].ToString();
                            dgvItem.Rows[i].Cells[34].Value = ds.Tables["ItemDls"].Rows[i][18].ToString();
                            dgvItem.Rows[i].Cells[35].Value = ds.Tables["ItemDls"].Rows[i][19].ToString();
                            dgvItem.Rows[i].Cells[36].Value = ds.Tables["ItemDls"].Rows[i][20].ToString();
                            dgvItem.Rows[i].Cells[37].Value = ds.Tables["ItemDls"].Rows[i][21].ToString();
                            dgvItem.Rows[i].Cells[43].Value = ds.Tables["ItemDls"].Rows[i]["RatingQty"].ToString();
                            dgvItem.Rows[i].Cells[44].Value = ds.Tables["ItemDls"].Rows[i]["AmtCalOnVolume"].ToString();
                            dgvItem.Rows[i].Cells[45].Value = ds.Tables["ItemDls"].Rows[i]["PaperConsume"].ToString();
                        }
                        if (Flag_Deying == true && (Tentry == "n" || Tentry == "9"))
                        {
                            dgvItem.Rows[i].Cells[31].Value = ds.Tables["ItemDls"].Rows[i][16].ToString();
                            DataTable dtRef = edpcom.GetDatatable(" select distinct i.pdesc,i.ucode,u.UDESC from iglmst i,unit u where i.ficode='" + edpcom.CurrentFicode + "' and i.gcode='" + edpcom.PCURRENT_GCODE + "' and i.ficode=u.ficode and i.gcode=u.gcode and i.ucode=u.ucode and i.pcode=" + Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][16].ToString()) + " ");
                            if (dtRef.Rows.Count > 0)                         //IT.PrintQtyUcode  PrintQty
                                dgvItem.Rows[i].Cells[30].Value = dtRef.Rows[0][0].ToString();
                            dgvItem.Rows[i].Cells[41].Value = ds.Tables["ItemDls"].Rows[i]["PrintQtyUcode"].ToString();
                            dgvItem.Rows[i].Cells[42].Value = ds.Tables["ItemDls"].Rows[i]["PrintQty"].ToString();
                            dgvItem.Rows[i].Cells[45].Value = ds.Tables["ItemDls"].Rows[i]["PaperConsume"].ToString();
                        }
                        try
                        {
                            TotalAmt = TotalAmt + Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][6].ToString());
                        }
                        catch { }
                    }
                }
                txtAmt.Text = TotalAmt.ToString(common.SetDecimalPlace());
                dgvItem.Columns[0].ReadOnly = true;
                dgvItem.Columns[1].ReadOnly = false;
                dgvItem.Columns[2].ReadOnly = true;
                dgvItem.Columns[3].ReadOnly = true;
            }
            catch { }
        }

        private void btnRefChallan_Click(object sender, EventArgs e)
        {
            try
            {
                common.arr_mod.Clear();
                common.get_code.Clear();
                if (Tentry == "9")
                {
                    if (lbcmp.Items.Count > 0)
                    {
                        DialogResult dr = new DialogResult();
                        dr = MessageBox.Show("Do you want to Invoice  from Refference Challan ? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            lbcmp.Items.Clear();
                            Pcode_sl = null;
                        }
                        else
                            return;
                    }
                }
                string st = "";
                if (Tentry == "PR")
                {
                    st = " SELECT DISTINCT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE] FROM IDATA ID,itran it WHERE ID.FICODE=it.ficode and ID.gcode=it.gcode and ID.FICODE='" + edpcom.CurrentFicode + "' AND " +
                         " ID.voucher=it.voucher and ID.t_entry=it.T_entry and  ID.GCODE='" + edpcom.PCURRENT_GCODE + "' AND ID.T_ENTRY='8' AND ID.Party_code=" + PartyCode + " and it.DSTATUS='RUNNING'";
                }
                else if (Tentry == "SR")
                {
                    st = " SELECT DISTINCT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE] FROM IDATA ID,itran it WHERE ID.FICODE=it.ficode and ID.gcode=it.gcode and ID.FICODE='" + edpcom.CurrentFicode + "' AND " +
                                             " ID.voucher=it.voucher and ID.t_entry=it.T_entry and  ID.GCODE='" + edpcom.PCURRENT_GCODE + "' AND ID.T_ENTRY='9' AND ID.Party_code=" + PartyCode + " and it.DSTATUS='RUNNING'";
                }
                else if (Tentry == "9")
                {
                    st = " SELECT DISTINCT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE] FROM IDATA ID,itran it WHERE ID.FICODE=it.ficode and ID.gcode=it.gcode and ID.FICODE='" + edpcom.CurrentFicode + "' AND " +
                         " ID.voucher=it.voucher and ID.t_entry=it.T_entry and  ID.GCODE='" + edpcom.PCURRENT_GCODE + "' AND ID.T_ENTRY='n' AND ID.Party_code=" + PartyCode + " and it.DSTATUS='RUNNING'";
                }
                else if (Tentry == "8")
                {
                    st = " SELECT DISTINCT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE] FROM IDATA ID,itran it WHERE ID.FICODE=it.ficode and ID.gcode=it.gcode and ID.FICODE='" + edpcom.CurrentFicode + "' AND " +
                        " ID.voucher=it.voucher and ID.t_entry=it.T_entry and  ID.GCODE='" + edpcom.PCURRENT_GCODE + "' AND ID.T_ENTRY='a' AND ID.Party_code=" + PartyCode + " and it.DSTATUS='RUNNING'";
                }

                common.MLOV(st, "Tag Challan User Vch", "Select User Vch", "List of Challan User Vch", 0, "CMPN", 0);

                label11.Visible = true;
                txtVoucherChallan.Visible = true;
                arr.Clear();
                arr = common.arr_mod;
                if (arr.Count > 0)
                {
                    getcode.Clear();
                    arr = common.arr_mod;
                    getcode = common.get_code;
                    lbRC.Items.Clear();
                    RefChal = null;
                    for (int i = 0; i <= (arr.Count - 1); i++)
                    {
                        lbRC.Items.Add(arr[i].ToString());
                        RefChal = RefChal + getcode[i].ToString();
                        if (i != getcode.Count - 1)
                        {
                            RefChal = RefChal + ",";
                        }
                    }
                    RefChallan();
                    label11.Visible = false;
                    txtVoucherChallan.Visible = false;
                }
            }
            catch
            {
            }
        }

        private void RefChallan()
        {
            try
            {
                bool flagforRow = true;
                if (Pcode_sl == "")
                {
                    return;
                }
                string str = "";
                common.ClearDataTable(ds.Tables["ItemDls"]);
                if (Tentry == "SR")
                {
                    str = "SELECT  distinct IG.PDESC,IT.QTY,U.UDESC,IT.USeries,IT.RATE,IT.DIS_AMT,IT.AMT,IT.PCODE,IT.BASEQTY,IT.UCODE,B.T_ENTRY,B.VOUCHER,IT.ITEMNO,IT.RatingQty,IT.AmtCalOnVolume,B.ReffPartyCode"
                                + " FROM ITRAN IT,IGLMST IG,UNIT U,IDATA B WHERE"
                                + " B.FICODE='" + edpcom.CurrentFicode + "' AND B.GCODE='" + edpcom.PCURRENT_GCODE + "' AND B.T_ENTRY='9' AND B.Party_code=" + PartyCode + " AND B.VOUCHER IN(" + RefChal + ") AND" // B.DSTATUS<>'COMPLETED' AND"
                                + " B.FICODE=IT.FICODE AND B.GCODE=IT.GCODE AND B.T_ENTRY=IT.T_ENTRY AND B.VOUCHER=IT.VOUCHER AND"
                                + " IT.FICODE=IG.FICODE AND IT.GCODE=IG.GCODE AND IT.PCODE=IG.PCODE AND"
                                + " IT.FICODE=U.FICODE AND IT.GCODE=U.GCODE AND IT.UCODE=U.UCODE";
                }
                else if (Tentry == "PR")
                {
                    str = "SELECT  distinct IG.PDESC,IT.QTY,U.UDESC,IT.USeries,IT.RATE,IT.DIS_AMT,IT.AMT,IT.PCODE,IT.BASEQTY,IT.UCODE,B.T_ENTRY,B.VOUCHER,IT.ITEMNO,B.ReffPartyCode"
                                + " FROM ITRAN IT,IGLMST IG,UNIT U,IDATA B WHERE"
                                + " B.FICODE='" + edpcom.CurrentFicode + "' AND B.GCODE='" + edpcom.PCURRENT_GCODE + "' AND B.T_ENTRY='8' AND B.Party_code=" + PartyCode + " AND B.VOUCHER IN(" + RefChal + ") AND" // B.DSTATUS<>'COMPLETED' AND"
                                + " B.FICODE=IT.FICODE AND B.GCODE=IT.GCODE AND B.T_ENTRY=IT.T_ENTRY AND B.VOUCHER=IT.VOUCHER AND"
                                + " IT.FICODE=IG.FICODE AND IT.GCODE=IG.GCODE AND IT.PCODE=IG.PCODE AND"
                                + " IT.FICODE=U.FICODE AND IT.GCODE=U.GCODE AND IT.UCODE=U.UCODE";
                }
                else if (Tentry == "9")
                {
                    str = "SELECT  distinct IG.PDESC,IT.QTY,U.UDESC,IT.USeries,IT.RATE,IT.DIS_AMT,IT.AMT,IT.PCODE,IT.BASEQTY,IT.UCODE,B.T_ENTRY,B.VOUCHER,IT.ITEMNO,IT.RefPCODE,IT.RefQty,IT.RefUCODE,IT.RefVolume,IT.RefSize,IT.RefPagePerFormat,IT.Freeqty,IT.Volume,IT.Size,IT.RatingQty,IT.AmtCalOnVolume,B.ReffPartyCode,IT.PrintQtyUcode,IT.PrintQty,IT.PaperConsume,B.IncluciveVAT,B.OnVATPer,B.AdhokAmt"
                                + " FROM ITRAN IT,IGLMST IG,UNIT U,IDATA B WHERE"
                                + " B.FICODE='" + edpcom.CurrentFicode + "' AND B.GCODE='" + edpcom.PCURRENT_GCODE + "' AND B.T_ENTRY='n' AND B.Party_code=" + PartyCode + " AND B.VOUCHER IN(" + RefChal + ") AND" // B.DSTATUS<>'COMPLETED' AND"
                                + " B.FICODE=IT.FICODE AND B.GCODE=IT.GCODE AND B.T_ENTRY=IT.T_ENTRY AND B.VOUCHER=IT.VOUCHER AND"
                                + " IT.FICODE=IG.FICODE AND IT.GCODE=IG.GCODE AND IT.PCODE=IG.PCODE AND"
                                + " IT.FICODE=U.FICODE AND IT.GCODE=U.GCODE AND IT.UCODE=U.UCODE Order By IT.ITEMNO";
                }
                else if (Tentry == "8")
                {
                    str = "SELECT  distinct IG.PDESC,IT.QTY,U.UDESC,IT.USeries,IT.RATE,IT.DIS_AMT,IT.AMT,IT.PCODE,IT.BASEQTY,IT.UCODE,B.T_ENTRY,B.VOUCHER,IT.ITEMNO,B.ReffPartyCode"
                                + " FROM ITRAN IT,IGLMST IG,UNIT U,IDATA B WHERE"
                                + " B.FICODE='" + edpcom.CurrentFicode + "' AND B.GCODE='" + edpcom.PCURRENT_GCODE + "' AND B.T_ENTRY='a' AND B.Party_code=" + PartyCode + " AND B.VOUCHER IN(" + RefChal + ") AND" // B.DSTATUS<>'COMPLETED' AND"
                                + " B.FICODE=IT.FICODE AND B.GCODE=IT.GCODE AND B.T_ENTRY=IT.T_ENTRY AND B.VOUCHER=IT.VOUCHER AND"
                                + " IT.FICODE=IG.FICODE AND IT.GCODE=IG.GCODE AND IT.PCODE=IG.PCODE AND"
                                + " IT.FICODE=U.FICODE AND IT.GCODE=U.GCODE AND IT.UCODE=U.UCODE";
                }

                cmd = new SqlCommand(str, edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "ItemDls");

                if (dgvItem.Rows.Count > 0)
                {
                    dgvItem.Rows.Clear();
                }
                if (dgvItem.Rows.Count == 1)
                    flagforRow = false;
                TotalAmt = 0;

                if (ds.Tables["ItemDls"].Rows.Count > 0)
                {
                    if (ds.Tables["ItemDls"].Rows[0]["IncluciveVAT"] != null)
                        if (Convert.ToString(ds.Tables["ItemDls"].Rows[0]["IncluciveVAT"]) != "")
                            chkIncVAT.Checked = Convert.ToBoolean(ds.Tables["ItemDls"].Rows[0]["IncluciveVAT"]);
                    if (ds.Tables["ItemDls"].Rows[0]["OnVATPer"] != null)
                        if (Convert.ToString(ds.Tables["ItemDls"].Rows[0]["OnVATPer"]) != "")
                            chkOnVATPer.Checked = Convert.ToBoolean(ds.Tables["ItemDls"].Rows[0]["OnVATPer"]);
                    if (ds.Tables["ItemDls"].Rows[0]["AdhokAmt"] != null)
                        if (Convert.ToString(ds.Tables["ItemDls"].Rows[0]["AdhokAmt"]) != "")
                            txtTotalAmt.Text = Convert.ToString(ds.Tables["ItemDls"].Rows[0]["AdhokAmt"]);
                    if (Information.IsNumeric(txtTotalAmt.Text) == false)
                        txtTotalAmt.Text = "0.00";

                    if (Information.IsNumeric(ds.Tables["ItemDls"].Rows[0]["ReffPartyCode"]) == true)
                    {
                        edpcon.Open();
                        ReffPartyCode = Convert.ToInt32(ds.Tables["ItemDls"].Rows[0]["ReffPartyCode"]);
                        cmbReffParty.Text = Getresult1("SELECT LDESC FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND GLCODE=" + ReffPartyCode + "");
                        edpcon.Close();
                    }
                    for (int i = 0; i <= ds.Tables["ItemDls"].Rows.Count - 1; i++)
                    {
                        int SMID = 0;
                        if (ds.Tables["ItemDls"].Rows[i][3] != null)
                            if (ds.Tables["ItemDls"].Rows[i][3] != "")
                                if (ds.Tables["ItemDls"].Rows[i][3].ToString() != "")
                                    SMID = Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][3].ToString());

                        common.ClearDataTable(ds.Tables["restQty"]);
                        string qryss = "select sum(n.baseqty) from itran n where n.ficode='" + edpcom.CurrentFicode + "' and n.gcode='" + edpcom.PCURRENT_GCODE + "' and n.t_entry='" + Tentry + "'  and n.ref_voucher=" + ds.Tables["ItemDls"].Rows[i][11].ToString() + " and n.REFF_ITEM_NO=" + ds.Tables["ItemDls"].Rows[i][12].ToString() + " and n.ref_tentry='" + ds.Tables["ItemDls"].Rows[i][10].ToString() + "' and n.pcode=" + ds.Tables["ItemDls"].Rows[i][7] + "";
                        cmd = new SqlCommand(qryss, edpcon.mycon);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "restQty");

                        if (Information.IsNumeric(ds.Tables["restQty"].Rows[0][0]))
                        {
                            double a = Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]);
                            double b = Convert.ToDouble(ds.Tables["restQty"].Rows[0][0]);
                            if ((a - b) == 0)
                                continue;
                        }
                        if (flagforRow == true)
                            dgvItem.Rows.Add();
                        flagforRow = true;
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[0].Value = ds.Tables["ItemDls"].Rows[i][0].ToString();

                        if (Information.IsNumeric(ds.Tables["restQty"].Rows[0][0]))
                        {
                            //string aa = common.BalQtySlashForm(Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0])), Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][7]), Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][9]), Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][3]));
                            string aa = common.BalQtySlashForm(Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0])), Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][7]));
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[1].Value = aa;
                        }
                        else
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[1].Value = ds.Tables["ItemDls"].Rows[i][1].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[2].Value = ds.Tables["ItemDls"].Rows[i][2].ToString();
                        edpcon.Open();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[3].Value = Getresult("SELECT DISTINCT SM_NAME FROM UnitSeriesMaster WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND SM_ID=" + SMID + "");
                        edpcon.Close();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[4].Value = ds.Tables["ItemDls"].Rows[i][4].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[5].Value = ds.Tables["ItemDls"].Rows[i][5].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[6].Value = ds.Tables["ItemDls"].Rows[i][6].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[7].Value = ds.Tables["ItemDls"].Rows[i][7].ToString();

                        if (Information.IsNumeric(ds.Tables["restQty"].Rows[0][0]))
                        {
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[8].Value = Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0]));
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[17].Value = Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0]));
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[38].Value = Convert.ToString(Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][8]) - Convert.ToDouble(ds.Tables["restQty"].Rows[0][0]));
                        }
                        else
                        {
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[8].Value = ds.Tables["ItemDls"].Rows[i][8].ToString();
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[17].Value = ds.Tables["ItemDls"].Rows[i][8].ToString();
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[38].Value = ds.Tables["ItemDls"].Rows[i][8].ToString();
                        }
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[9].Value = ds.Tables["ItemDls"].Rows[i][9].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[10].Value = ds.Tables["ItemDls"].Rows[i][3].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[11].Value = ds.Tables["ItemDls"].Rows[i][10].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[12].Value = ds.Tables["ItemDls"].Rows[i][11].ToString();
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[13].Value = ds.Tables["ItemDls"].Rows[i][12].ToString();


                        if ((Flag_Printing == true || Flag_Deying == true) && Tentry == "9")
                        {
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[14].Value = ds.Tables["ItemDls"].Rows[i][20].ToString();
                            dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[15].Value = ds.Tables["ItemDls"].Rows[i][21].ToString();

                            dgvItem.Rows[i].Cells[31].Value = ds.Tables["ItemDls"].Rows[i][13].ToString();
                            DataTable dtRef = edpcom.GetDatatable(" select distinct i.pdesc,i.ucode,u.UDESC from iglmst i,unit u where i.ficode='" + edpcom.CurrentFicode + "' and i.gcode='" + edpcom.PCURRENT_GCODE + "' and i.ficode=u.ficode and i.gcode=u.gcode and i.ucode=u.ucode and i.pcode=" + Convert.ToInt32(ds.Tables["ItemDls"].Rows[i][13].ToString()) + " ");
                            if (dtRef.Rows.Count > 0)
                            {
                                dgvItem.Rows[i].Cells[30].Value = dtRef.Rows[0][0].ToString();
                                dgvItem.Rows[i].Cells[33].Value = dtRef.Rows[0][2].ToString();
                            }
                            dgvItem.Rows[i].Cells[32].Value = ds.Tables["ItemDls"].Rows[i][14].ToString();
                            dgvItem.Rows[i].Cells[34].Value = ds.Tables["ItemDls"].Rows[i][15].ToString();
                            dgvItem.Rows[i].Cells[35].Value = ds.Tables["ItemDls"].Rows[i][16].ToString();
                            dgvItem.Rows[i].Cells[36].Value = ds.Tables["ItemDls"].Rows[i][17].ToString();
                            dgvItem.Rows[i].Cells[37].Value = ds.Tables["ItemDls"].Rows[i][18].ToString();
                            dgvItem.Rows[i].Cells[41].Value = ds.Tables["ItemDls"].Rows[i]["PrintQtyUcode"].ToString();
                            dgvItem.Rows[i].Cells[42].Value = ds.Tables["ItemDls"].Rows[i]["PrintQty"].ToString();
                            dgvItem.Rows[i].Cells[43].Value = ds.Tables["ItemDls"].Rows[i]["RatingQty"].ToString();
                            dgvItem.Rows[i].Cells[44].Value = ds.Tables["ItemDls"].Rows[i]["AmtCalOnVolume"].ToString();
                            if (ds.Tables["ItemDls"].Rows[i]["PaperConsume"] != null)
                                if (ds.Tables["ItemDls"].Rows[i]["PaperConsume"].ToString() != "")
                                    dgvItem.Rows[i].Cells[45].Value = ds.Tables["ItemDls"].Rows[i]["PaperConsume"].ToString();
                        }
                        try
                        {
                            TotalAmt = TotalAmt + Convert.ToDouble(ds.Tables["ItemDls"].Rows[i][6].ToString());
                        }
                        catch { }
                    }
                }
                txtAmt.Text = TotalAmt.ToString(common.SetDecimalPlace());
                dgvItem.Columns[0].ReadOnly = true;
                dgvItem.Columns[1].ReadOnly = false;
                dgvItem.Columns[2].ReadOnly = true;
                dgvItem.Columns[3].ReadOnly = true;
            }
            catch { }
        }

        private void txtvoucher_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (cmbAct.Text != "MODIFY" && cmbAct.Text != "DELETE" && cmbAct.Text != "VIEW")
                {
                    txtvoucher.CommandString = null;
                    return;
                }
                edpcon.Open();
                if (cmbAct.SelectedIndex == 1 || cmbAct.SelectedIndex == 2 || cmbAct.SelectedIndex == 3)
                {
                    string SqlStr = "";
                    SqlStr = " SELECT D.USER_VCH [USER VCH],D.VOUCHER [VCH CODE],D.VCH_DATE [VCH DATE],GP.LDESC [PARTY NAME] FROM IDATA D,GLMST GP" +
                            " WHERE D.FICODE='" + EDPComm.CurrentFicode + "' AND D.GCODE='" + EDPComm.PCURRENT_GCODE + "' AND D.T_ENTRY='" + Tentry + "' " +
                            " AND D.FICODE=GP.FICODE AND D.GCODE=GP.GCODE AND D.PARTY_CODE=GP.GLCODE AND GP.MTYPE='L' AND D.PARTY_CODE<>0" +
                            " UNION SELECT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE],NULL [PARTY NAME] FROM IDATA ID" +
                            " WHERE ID.FICODE='" + EDPComm.CurrentFicode + "' AND ID.GCODE='" + EDPComm.PCURRENT_GCODE + "' AND ID.T_ENTRY='" + Tentry + "' " +
                            " AND ID.PARTY_CODE=0";

                    txtvoucher.CommandString = SqlStr;
                    txtvoucher.Heading = "Select Voucher";
                    txtvoucher.Connection = edpcon.mycon;
                    txtvoucher.ReturnIndex = 1;
                }
                edpcon.Close();
            }
            catch { }
        }

        private void txtvoucher_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            try
            {
                btnStockTransfer.Visible = false;
                if (txtvoucher.ReturnValue != "")
                {
                    vno = Convert.ToInt32(txtvoucher.ReturnValue);
                    GetInformation();
                }
                else
                {
                    return;
                }
            }
            catch { }
        }

        public void GetInformation()
        {
            try
            {
                Boolean flug = false;
                Boolean flug1 = false;
                dgvItem.Rows.Clear();
                dgvAddless.Rows.Clear();
                if (dgvItem.Rows.Count > 0)
                    flug = true;
                if (dgvAddless.Rows.Count > 0)
                    flug1 = true;
                int index = 0;
                lbRC.Items.Clear();
                lbcmp.Items.Clear();
                cmbCash.Text = "";
                cmbSales.Text = "";
                edpcon.Open();
                common.ClearDataTable(ds.Tables["Voucher_Desc"]);
                cmd = new SqlCommand("select i.pcode,i.Qty,i.Ucode,i.Useries,i.Rate,i.Dis_Amt,i.Amt,i.BaseQty,i.voucher,i.REF_TENTRY,i.REF_VOUCHER,i.REFF_ITEM_NO,i.Volume,i.Size,i.PPF,i.RefPCODE,i.RefQty,i.RefUCODE,i.RefVolume,i.RefSize,i.RefPagePerFormat,i.Freeqty,i.RateOnUnitCode,i.PrintQtyUcode,i.PrintQty,i.RatingQty,i.AmtCalOnVolume,i.OnlnBSQtConVal,i.PaperConsume from itran i where i.ficode=" + edpcom.CurrentFicode + " and i.gcode=" + edpcom.PCURRENT_GCODE + " and i.T_ENTRY='" + Tentry + "' and i.voucher='" + vno + "' Order by i.ITEMNO", edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "Voucher_Desc");

                if (Flag_Printing)
                {
                    common.ClearDataTable(ds.Tables["dsCheck"]);
                    cmd = new SqlCommand("select IncluciveVAT,OnVATPer,AdhokAmt from idata where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and T_entry='" + Tentry + "' and voucher=" + vno + "", edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "dsCheck");
                    if (ds.Tables["dsCheck"].Rows.Count > 0)
                    {
                        if (ds.Tables["dsCheck"] != null)
                            if (Convert.ToString(ds.Tables["dsCheck"].Rows[0][0]) != "")
                                chkIncVAT.Checked = Convert.ToBoolean(ds.Tables["dsCheck"].Rows[0][0]);
                        if (ds.Tables["dsCheck"] != null)
                            if (Convert.ToString(ds.Tables["dsCheck"].Rows[0][1]) != "")
                                chkOnVATPer.Checked = Convert.ToBoolean(ds.Tables["dsCheck"].Rows[0][1]);
                        if (ds.Tables["dsCheck"] != null)
                            if (Convert.ToString(ds.Tables["dsCheck"].Rows[0][2]) != "")
                                txtTotalAmt.Text = Convert.ToString(ds.Tables["dsCheck"].Rows[0][2]);
                        if (Information.IsNumeric(txtTotalAmt.Text) == false)
                            txtTotalAmt.Text = "0.00";
                    }

#region RETRIVE PAPER STATEMENT
                    common.ClearDataTable(ds.Tables["dsPAPER"]);
                    cmd = new SqlCommand("SELECT DISTINCT RowIndex FROM ConsumeProduct WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND T_ENTRY='" + Tentry + "' AND VOUCHER=" + vno + " ORDER BY RowIndex", edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "dsPAPER");
                    for (int ii = 0; ii <= ds.Tables["dsPAPER"].Rows.Count - 1; ii++)
                    {
                        string ss = "SELECT DISTINCT IG.PDESC,CP.QTY,U.UDESC,US.SM_NAME,null,null,null [Discount],null [Amount],IG.PCODE,CP.BASEQTY,U.UCODE,US.SM_ID [SeriesCode],CP.ReffFGPcode [FPC]," +
                        " CP.RowIndex,CP.Spoil_per [SpoilPer],CP.PSide [PaperSide],CP.Volume [Volume],CP.Size" +
                        " FROM ConsumeProduct CP,IGLMST IG,UNIT U,UnitSeriesMaster US WHERE CP.FICODE='" + edpcom.CurrentFicode + "' AND CP.GCODE='" + edpcom.PCURRENT_GCODE + "' AND CP.T_ENTRY='" + Tentry + "' AND CP.VOUCHER=" + vno + " AND CP.ROWINDEX=" + Convert.ToDouble(ds.Tables["dsPAPER"].Rows[ii][0]) + "" +
                        " AND CP.FICODE=IG.FICODE AND CP.GCODE=IG.GCODE AND CP.PCODE=IG.PCODE AND CP.BaseUCode=U.UCODE AND" +
                        " CP.FICODE=US.FICODE AND CP.GCODE=US.GCODE AND CP.USeries=US.SM_ID";

                        DataTable DT = edpcom.GetDatatable(ss);
                        common.HTAddress.Add(Convert.ToInt32(ds.Tables["dsPAPER"].Rows[ii][0]), DT);
                    }
#endregion
                }    

                if (Tentry != "OS")
                {
                    if (ds.Tables["Voucher_Desc"].Rows.Count > 0)
                    {
                        int REFVCHNO = 0;
                        common.ClearDataTable(ds.Tables["ORVch"]);
                        if (ds.Tables["Voucher_Desc"].Rows[0][10] != null)
                            if (ds.Tables["Voucher_Desc"].Rows[0][10].ToString() != "")
                                REFVCHNO = Convert.ToInt32(ds.Tables["Voucher_Desc"].Rows[0][10]);
                        if ((SBType == "PUR" || SBType == "SALES") && action == "MODIFY")
                            RefVno = REFVCHNO;
                        cmd = new SqlCommand("select d.user_vch,d.Voucher from idata d  where d.ficode=" + edpcom.CurrentFicode + " and d.gcode=" + edpcom.PCURRENT_GCODE + " and  d.t_entry='" + ds.Tables["Voucher_Desc"].Rows[0][9] + "'and d.voucher=" + REFVCHNO + " and AutoChalan is null", edpcon.mycon);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "ORVch");
                        if (ds.Tables["ORVch"].Rows.Count > 0)
                        {
                            if (action == "MODIFY" && SBType == "SI")
                            {
                                cmbRefOrd.Text = ds.Tables["ORVch"].Rows[0][0].ToString();
                                Pcode_sl = ds.Tables["ORVch"].Rows[0][1].ToString();
                            }
                            if (Tentry == "9" || Tentry == "SR")// || Tentry == "PUR" || Tentry == "a")
                            {
                                lbRC.Items.Clear();
                                lbRC.Items.Add(ds.Tables["ORVch"].Rows[0][0].ToString());
                                if (SBType == "SALES" || SBType == "PUR")
                                {
                                    label11.Visible = false;
                                    txtVoucherChallan.Visible = false;
                                }
                                if (Information.IsNumeric(ds.Tables["ORVch"].Rows[0][1]))
                                {
                                    common.ClearDataTable(ds.Tables["ORit"]);
                                    cmd = new SqlCommand("select distinct ref_tentry,ref_voucher from itran where ficode=1 and gcode=1 and  t_entry='" + ds.Tables["Voucher_Desc"].Rows[0][9] + "'and voucher='" + ds.Tables["Voucher_Desc"].Rows[0][10] + "' ", edpcon.mycon);
                                    da.SelectCommand = cmd;
                                    da.Fill(ds, "ORit");

                                    if (Information.IsNumeric(ds.Tables["ORit"].Rows[0][1]))
                                    {
                                        if (Information.IsNothing(ds.Tables["ORit"].Rows[0][0]) == true && Information.IsNumeric(ds.Tables["ORit"].Rows[0][1]))
                                        {
                                            if (Convert.ToInt32(ds.Tables["ORit"].Rows[0][1]) > 0)
                                            {
                                                common.ClearDataTable(ds.Tables["ORCha"]);
                                                cmd = new SqlCommand("select distinct user_vch,Voucher from idata where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and  t_entry='" + ds.Tables["ORit"].Rows[0][0] + "'and voucher='" + ds.Tables["ORit"].Rows[0][1] + "' ", edpcon.mycon);
                                                da.SelectCommand = cmd;
                                                da.Fill(ds, "ORCha");
                                                lbcmp.Items.Clear();
                                                lbcmp.Items.Add(ds.Tables["ORCha"].Rows[0][0].ToString());
                                            }
                                        }
                                    }
                                }
                                common.ClearDataTable(ds.Tables["Bill"]);
                                cmd = new SqlCommand("select Cash_Check,Cash_Glcode,SALES_GLCODE from Bill where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and  t_entry='" + Tentry + "'and voucher='" + vno + "' ", edpcon.mycon);
                                da.SelectCommand = cmd;
                                da.Fill(ds, "Bill");
                                if (Convert.ToInt32(ds.Tables["Bill"].Rows[0][1]) > 0)
                                {
                                    common.ClearDataTable(ds.Tables["Cash"]);
                                    cmd = new SqlCommand("select LDESC from glmst where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and  mtype='L'and glcode=" + ds.Tables["Bill"].Rows[0][1] + " ", edpcon.mycon);
                                    da.SelectCommand = cmd;
                                    da.Fill(ds, "Cash");
                                    cmbCash.Text = ds.Tables["Cash"].Rows[0][0].ToString();
                                }
                                else
                                {
                                    common.ClearDataTable(ds.Tables["Salse"]);
                                    cmd = new SqlCommand("select LDESC from glmst where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and  mtype='L'and glcode=" + ds.Tables["Bill"].Rows[0][2] + " ", edpcon.mycon);
                                    da.SelectCommand = cmd;
                                    da.Fill(ds, "Salse");
                                    if (ds.Tables["Salse"].Rows.Count > 0)
                                        cmbSales.Text = ds.Tables["Salse"].Rows[0][0].ToString();
                                }
                                if (Convert.ToBoolean(ds.Tables["Bill"].Rows[0][1]) == true)
                                    chkCash.Checked = true;
                                else
                                    chkCash.Checked = false;
                            }
                            else
                            {
                                if (SBType != "SI")
                                {
                                    string RT = "";
                                    if (ds.Tables["Voucher_Desc"].Rows[0][9] != null)
                                        if (ds.Tables["Voucher_Desc"].Rows[0][9].ToString() != "")
                                            RT = ds.Tables["Voucher_Desc"].Rows[0][9].ToString();
                                    if (RT == "a" || RT == "n")
                                    {
                                        lbRC.Items.Clear();
                                        lbRC.Items.Add(ds.Tables["ORVch"].Rows[0][0].ToString());
                                    }
                                    else if (RT == "OP" || RT == "SO")
                                    {
                                        lbcmp.Items.Clear();
                                        lbcmp.Items.Add(ds.Tables["ORVch"].Rows[0][0].ToString());
                                    }
                                    else if (RT == "8" || RT == "9")
                                    {
                                    }
                                }
                            }
                        }
                        else
                            ChlnVchNo = edpcom.GetresultS("select d.user_vch,d.Voucher from idata d  where d.ficode=" + edpcom.CurrentFicode + " and d.gcode=" + edpcom.PCURRENT_GCODE + " and  d.t_entry='" + ds.Tables["Voucher_Desc"].Rows[0][9] + "'and d.voucher=" + REFVCHNO + "");
                        //if(!MultiSalePurAC)
                        //{
                        string sc = edpcom.GetresultS("select B.SALES_GLCODE from Bill B  where B.ficode=" + edpcom.CurrentFicode + " and B.gcode=" + edpcom.PCURRENT_GCODE + " and  B.t_entry='" + Tentry + "'and B.voucher=" + vno + "");
                        if (sc != "")
                        {
                            SalesCode = Convert.ToInt32(sc);
                            cmbSales.Text = edpcom.GetresultS("select G.LDESC from GLMST G  where G.ficode=" + edpcom.CurrentFicode + " and G.gcode=" + edpcom.PCURRENT_GCODE + " AND Mtype='L' AND GLCODE=" + SalesCode + "");
                        }
                        string CA = edpcom.GetresultS("select B.Cash_Glcode from Bill B  where B.ficode=" + edpcom.CurrentFicode + " and B.gcode=" + edpcom.PCURRENT_GCODE + " and  B.t_entry='" + Tentry + "'and B.voucher=" + vno + "");
                        if (CA == null)
                            CA = "";
                        if ((CA != "") && (CA!="0"))
                        {
                            chkCash.Checked = true;
                            cmbCash.Enabled = true;
                            CashCode = Convert.ToInt32(CA);
                            cmbCash.Text = edpcom.GetresultS("select G.LDESC from GLMST G  where G.ficode=" + edpcom.CurrentFicode + " and G.gcode=" + edpcom.PCURRENT_GCODE + " AND Mtype='L' AND GLCODE=" + CashCode + "");
                        }
                        else
                        {
                            chkCash.Checked = false;
                            cmbCash.Enabled = false;
                        }
                        //}


                        txtVoucherChallan.Text = txtvoucher.Text;
                    }
                }
                common.ClearDataTable(ds.Tables["party"]);
                cmd = new SqlCommand("select distinct Party_code,DESCCODE,CURR_CODE,vch_date,ReffPartyCode from idata where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and USER_VCH='" + txtvoucher.Text + "'and t_entry='" + Tentry + "'", edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "party");

                //if (ds.Tables["party"].Rows[0][0].ToString().Trim() != "0")
                //{
                common.ClearDataTable(ds.Tables["partyName"]);
                cmd = new SqlCommand("select LDESC,glcode from glmst where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and MTYPE='L' and glcode=" + ds.Tables["party"].Rows[0][0] + "", edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "partyName");
                //}

                int RPC = 0;
                if (Information.IsNumeric(ds.Tables["party"].Rows[0]["ReffPartyCode"]) == true)
                    RPC = Convert.ToInt32(ds.Tables["party"].Rows[0]["ReffPartyCode"]);
                common.ClearDataTable(ds.Tables["reffpartyName"]);
                cmd = new SqlCommand("select LDESC,glcode from glmst where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and MTYPE='L' and glcode=" + RPC + "", edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "reffpartyName");
                if (ds.Tables["reffpartyName"].Rows.Count > 0)
                    cmbReffParty.Text = ds.Tables["reffpartyName"].Rows[0][0].ToString();

                common.ClearDataTable(ds.Tables["Description"]);
                cmd = new SqlCommand("select Type_Desc,Desccode from TypeDoc where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and t_entry='" + Tentry + "' and Desccode='" + ds.Tables["party"].Rows[0][1] + "' ", edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "Description");

                common.ClearDataTable(ds.Tables["Currency"]);
                cmd = new SqlCommand("select curr_desc,curr_code from Currency where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and curr_code='" + ds.Tables["party"].Rows[0][2] + "'", edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "Currency");

                txtDesc.Text = ds.Tables["Description"].Rows[0][0].ToString();
                if (ds.Tables["partyName"].Rows.Count > 0)
                    cmbPartyName.Text = ds.Tables["partyName"].Rows[0][0].ToString();
                txtcurrency.Text = ds.Tables["Currency"].Rows[0][0].ToString();
                string dp = Convert.ToDateTime(ds.Tables["party"].Rows[0][3]).ToShortDateString();
                dtp.Value = Convert.ToDateTime(ds.Tables["party"].Rows[0][3]);
                int i = 0;
                for (i = 0; i <= ds.Tables["Voucher_Desc"].Rows.Count - 1; i++)
                {
                    common.ClearDataTable(ds.Tables["Item"]);
                    cmd = new SqlCommand("SELECT pdesc,pcode FROM iglmst WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' AND pcode='" + ds.Tables["Voucher_Desc"].Rows[i][0] + "'", edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Item");

                    common.ClearDataTable(ds.Tables["Units"]);
                    cmd = new SqlCommand("SELECT udesc,ucode from unit WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and ucode='" + ds.Tables["Voucher_Desc"].Rows[i][2] + "'", edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Units");

                    common.ClearDataTable(ds.Tables["Serise"]);
                    cmd = new SqlCommand("SELECT SM_Name,SM_ID from UnitSeriesMaster WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and SM_ID='" + ds.Tables["Voucher_Desc"].Rows[i][3] + "'", edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Serise");
                    edpcon.Close();

                    if (ds.Tables["partyName"].Rows.Count > 0)
                        PartyCode = Convert.ToInt32(ds.Tables["partyName"].Rows[0][1]);
                    Desccode = Convert.ToInt32(ds.Tables["Description"].Rows[0][1]);
                    currcode = Convert.ToInt32(ds.Tables["Currency"].Rows[0][1]);

                    if (Tentry == "n")
                    {
                        try
                        {
                            common.ClearDataTable(ds.Tables["TotalQty"]);
                            common.ClearDataTable(ds.Tables["TotalChalanQty"]);
                            string qqrrry = "select distinct sum(baseqty) from itran i where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and voucher=" + ds.Tables["Voucher_Desc"].Rows[i][10] + " and itemno=" + ds.Tables["Voucher_Desc"].Rows[i][11] + " and pcode=" + ds.Tables["Voucher_Desc"].Rows[i][0] + " and t_entry='" + ds.Tables["Voucher_Desc"].Rows[i][9] + "'";
                            cmd = new SqlCommand(qqrrry, edpcon.mycon);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "TotalQty");
                            qqrrry = " select distinct sum(baseqty)  from itran i where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and ref_voucher=" + ds.Tables["Voucher_Desc"].Rows[i][10] + " and reff_item_no=" + ds.Tables["Voucher_Desc"].Rows[i][11] + " and pcode=" + ds.Tables["Voucher_Desc"].Rows[i][0] + " and REF_tentry='OS' and t_entry='n'";
                            cmd = new SqlCommand(qqrrry, edpcon.mycon);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "TotalChalanQty");
                            if (Information.IsNumeric(ds.Tables["TotalQty"].Rows[0][0]))
                            {
                                double a = Convert.ToDouble(ds.Tables["TotalQty"].Rows[0][0]);
                                double b = Convert.ToDouble(ds.Tables["TotalChalanQty"].Rows[0][0]);
                                dgvItem.Rows[i].Cells[17].Value = (a - b);
                            }
                        }
                        catch { }
                    }
                    if (Tentry == "a")
                    {
                        try
                        {
                            common.ClearDataTable(ds.Tables["TotalQty"]);
                            common.ClearDataTable(ds.Tables["TotalChalanQty"]);
                            string qqrrry = "select distinct sum(baseqty) from itran i where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and voucher=" + ds.Tables["Voucher_Desc"].Rows[i][10] + " and itemno=" + ds.Tables["Voucher_Desc"].Rows[i][11] + " and pcode=" + ds.Tables["Voucher_Desc"].Rows[i][0] + " and t_entry='" + ds.Tables["Voucher_Desc"].Rows[i][9] + "'";
                            cmd = new SqlCommand(qqrrry, edpcon.mycon);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "TotalQty");
                            qqrrry = " select distinct sum(baseqty)  from itran i where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and ref_voucher=" + ds.Tables["Voucher_Desc"].Rows[i][10] + " and reff_item_no=" + ds.Tables["Voucher_Desc"].Rows[i][11] + " and pcode=" + ds.Tables["Voucher_Desc"].Rows[i][0] + " and REF_tentry='OP' and t_entry='a'";
                            cmd = new SqlCommand(qqrrry, edpcon.mycon);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "TotalChalanQty");
                            if (Information.IsNumeric(ds.Tables["TotalQty"].Rows[0][0]))
                            {
                                double a = Convert.ToDouble(ds.Tables["TotalQty"].Rows[0][0]);
                                double b = Convert.ToDouble(ds.Tables["TotalChalanQty"].Rows[0][0]);
                                dgvItem.Rows[i].Cells[17].Value = (a + b);
                            }
                        }
                        catch { }
                    }
                    else if (Tentry == "SI")
                    {
                        try
                        {
                            common.ClearDataTable(ds.Tables["TotalQty"]);
                            common.ClearDataTable(ds.Tables["TotalChalanQty"]);
                            string qqrrry = "select distinct sum(baseqty) from RawMeterialDetails i where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and voucher=" + ds.Tables["Voucher_Desc"].Rows[i][10] + " and Raw_PCODE=" + ds.Tables["Voucher_Desc"].Rows[i][0] + " and t_entry='" + ds.Tables["Voucher_Desc"].Rows[i][9] + "'";
                            cmd = new SqlCommand(qqrrry, edpcon.mycon);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "TotalQty");
                            qqrrry = " select distinct sum(baseqty)  from itran i where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and ref_voucher=" + ds.Tables["Voucher_Desc"].Rows[i][10] + " and reff_item_no=" + ds.Tables["Voucher_Desc"].Rows[i][11] + " and pcode=" + ds.Tables["Voucher_Desc"].Rows[i][0] + " and REF_tentry='OS' and t_entry='SI'";
                            cmd = new SqlCommand(qqrrry, edpcon.mycon);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "TotalChalanQty");
                            if (Information.IsNumeric(ds.Tables["TotalQty"].Rows[0][0]))
                            {
                                double a = Convert.ToDouble(ds.Tables["TotalQty"].Rows[0][0]);
                                double b = Convert.ToDouble(ds.Tables["TotalChalanQty"].Rows[0][0]);
                                dgvItem.Rows[i].Cells[17].Value = (a - b);
                            }
                        }
                        catch { }
                    }
                    if (Tentry == "SR")
                    {
                        try
                        {
                            common.ClearDataTable(ds.Tables["TotalQty"]);
                            common.ClearDataTable(ds.Tables["TotalChalanQty"]);
                            string qqrrry = "select distinct sum(baseqty) from itran i where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and voucher=" + ds.Tables["Voucher_Desc"].Rows[i][10] + " and itemno=" + ds.Tables["Voucher_Desc"].Rows[i][11] + " and pcode=" + ds.Tables["Voucher_Desc"].Rows[i][0] + " and t_entry='" + ds.Tables["Voucher_Desc"].Rows[i][9] + "'";
                            cmd = new SqlCommand(qqrrry, edpcon.mycon);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "TotalQty");
                            qqrrry = " select distinct sum(baseqty)  from itran i where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and ref_voucher=" + ds.Tables["Voucher_Desc"].Rows[i][10] + " and reff_item_no=" + ds.Tables["Voucher_Desc"].Rows[i][11] + " and pcode=" + ds.Tables["Voucher_Desc"].Rows[i][0] + " and REF_tentry='9' and t_entry='SR'";
                            cmd = new SqlCommand(qqrrry, edpcon.mycon);
                            da.SelectCommand = cmd;
                            da.Fill(ds, "TotalChalanQty");
                            if (Information.IsNumeric(ds.Tables["TotalQty"].Rows[0][0]))
                            {
                                double a = Convert.ToDouble(ds.Tables["TotalQty"].Rows[0][0]);
                                double b = Convert.ToDouble(ds.Tables["TotalChalanQty"].Rows[0][0]);
                                dgvItem.Rows[i].Cells[17].Value = (a - b);
                            }
                        }
                        catch { }
                    }

                    if (flug == false)
                        dgvItem.Rows.Add();
                    if (ds.Tables["Item"].Rows.Count > 0)
                        dgvItem.Rows[i].Cells[0].Value = ds.Tables["Item"].Rows[0][0].ToString();
                    dgvItem.Rows[i].Cells[1].Value = ds.Tables["Voucher_Desc"].Rows[i][1].ToString();
                    if (ds.Tables["Units"].Rows.Count > 0)
                        dgvItem.Rows[i].Cells[2].Value = ds.Tables["Units"].Rows[0][0].ToString();
                    if (ds.Tables["Serise"].Rows.Count > 0)
                        dgvItem.Rows[i].Cells[3].Value = ds.Tables["Serise"].Rows[0][0].ToString();
                    else
                        dgvItem.Rows[i].Cells[3].Value = 0;
                    dgvItem.Rows[i].Cells[4].Value = ds.Tables["Voucher_Desc"].Rows[i][4].ToString();
                    dgvItem.Rows[i].Cells[5].Value = ds.Tables["Voucher_Desc"].Rows[i][5].ToString();
                    dgvItem.Rows[i].Cells[6].Value = ds.Tables["Voucher_Desc"].Rows[i][6].ToString();
                    dgvItem.Rows[i].Cells[7].Value = ds.Tables["Voucher_Desc"].Rows[i][0].ToString();
                    dgvItem.Rows[i].Cells[8].Value = ds.Tables["Voucher_Desc"].Rows[i][7].ToString();
                    dgvItem.Rows[i].Cells[9].Value = ds.Tables["Voucher_Desc"].Rows[i][2].ToString();
                    dgvItem.Rows[i].Cells[10].Value = ds.Tables["Voucher_Desc"].Rows[i][3].ToString();
                    dgvItem.Rows[i].Cells[11].Value = ds.Tables["Voucher_Desc"].Rows[i][9].ToString();
                    dgvItem.Rows[i].Cells[12].Value = ds.Tables["Voucher_Desc"].Rows[i][10].ToString();
                    dgvItem.Rows[i].Cells[13].Value = ds.Tables["Voucher_Desc"].Rows[i][11].ToString();
                    dgvItem.Rows[i].Cells[14].Value = ds.Tables["Voucher_Desc"].Rows[i][12].ToString();
                    dgvItem.Rows[i].Cells[15].Value = ds.Tables["Voucher_Desc"].Rows[i][13].ToString();
                    dgvItem.Rows[i].Cells[16].Value = ds.Tables["Voucher_Desc"].Rows[i][14].ToString();
                    dgvItem.Rows[i].Cells[18].Value = ds.Tables["Voucher_Desc"].Rows[i][21].ToString();
                    dgvItem.Rows[i].Cells[43].Value = ds.Tables["Voucher_Desc"].Rows[i]["RatingQty"].ToString();
                    dgvItem.Rows[i].Cells[44].Value = ds.Tables["Voucher_Desc"].Rows[i]["AmtCalOnVolume"].ToString();
                    if (ds.Tables["Voucher_Desc"].Rows[i]["PaperConsume"] != null)
                        if (Convert.ToString(ds.Tables["Voucher_Desc"].Rows[i]["PaperConsume"]) != "")
                            dgvItem.Rows[i].Cells[45].Value = ds.Tables["Voucher_Desc"].Rows[i]["PaperConsume"].ToString();
                    

                    if (Information.IsNumeric(ds.Tables["Voucher_Desc"].Rows[i][24]))//090512
                        if (Convert.ToDecimal(ds.Tables["Voucher_Desc"].Rows[i][24]) > 0)
                            dgvItem.Rows[i].Cells[38].Value = ds.Tables["Voucher_Desc"].Rows[i][24].ToString();


                    if (Information.IsNumeric(ds.Tables["Voucher_Desc"].Rows[i][27]))//090512
                        if (Convert.ToDecimal(ds.Tables["Voucher_Desc"].Rows[i][27]) > 0)
                            dgvItem.Rows[i].Cells[45].Value = ds.Tables["Voucher_Desc"].Rows[i][27].ToString();


                    TotalAmt = TotalAmt + Convert.ToDouble(ds.Tables["Voucher_Desc"].Rows[i][6].ToString());
                    txtAmt.Text = edpcom.GetAmountFormat(Convert.ToDouble(TotalAmt), 2);

                    if (Flag_Printing == false && (SBType == "SALES" || SBType == "PUR"))
                    {
                        dgvItem.Rows[i].Cells[40].Value = edpcom.GetresultS("SELECT udesc from unit WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and ucode='" + ds.Tables["Voucher_Desc"].Rows[i][23] + "'");
                        dgvItem.Rows[i].Cells[41].Value = ds.Tables["Voucher_Desc"].Rows[i][23].ToString();
                        dgvItem.Rows[i].Cells[42].Value = ds.Tables["Voucher_Desc"].Rows[i][24].ToString();
                    }

                    if ((SBType == "SALES" && Tentry == "9") || Tentry == "n" || Tentry == "OS" || Tentry == "8")
                    {
                        if (Flag_Printing == false)
                        {
                            DataTable dt_tblAdditional = edpcom.GetDatatable(" Select * from BillAdditionalDetails where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and voucher=" + vno + " and t_entry='" + Tentry + "' ");
                            if (dt_tblAdditional.Rows.Count > 0)
                            {
                                for (int s = 0; s < dgvAdditional.Rows.Count; s++)
                                {
                                    switch (dgvAdditional.Rows[s].HeaderCell.Value.ToString().Trim())
                                    {
                                        case "Transport Name":
                                            dgvAdditional.Rows[s].Cells[0].Value = dt_tblAdditional.Rows[0][5].ToString();
                                            break;
                                        case "Consingment No.":
                                            dgvAdditional.Rows[s].Cells[0].Value = dt_tblAdditional.Rows[0][6].ToString();
                                            break;
                                        case "Consingment Date":
                                            dgvAdditional.Rows[s].Cells[0].Value = dt_tblAdditional.Rows[0][7].ToString();
                                            break;
                                        case "No of Packages":
                                            dgvAdditional.Rows[s].Cells[0].Value = dt_tblAdditional.Rows[0][8].ToString();
                                            break;
                                        case "SRV NO.":
                                            dgvAdditional.Rows[s].Cells[0].Value = dt_tblAdditional.Rows[0][9].ToString();
                                            break;
                                        case "SRV Date":
                                            dgvAdditional.Rows[s].Cells[0].Value = dt_tblAdditional.Rows[0][10].ToString();
                                            break;
                                        case "Lorry NO.":
                                            dgvAdditional.Rows[s].Cells[0].Value = dt_tblAdditional.Rows[0][11].ToString();
                                            break;
                                        case "Weight":
                                            dgvAdditional.Rows[s].Cells[0].Value = dt_tblAdditional.Rows[0][12].ToString();
                                            break;
                                        case "Delivery At":
                                            dgvAdditional.Rows[s].Cells[0].Value = dt_tblAdditional.Rows[0][13].ToString();//210412
                                            break;
                                        default: break;
                                    }
                                }
                            }
                        }
                        if (Flag_Printing == true)
                        {
                            dgvItem.Rows[i].Cells[31].Value = ds.Tables["Voucher_Desc"].Rows[i][15].ToString();
                            DataTable dtRef = edpcom.GetDatatable(" select distinct i.pdesc,i.ucode,u.UDESC from iglmst i,unit u where i.ficode='" + edpcom.CurrentFicode + "' and i.gcode='" + edpcom.PCURRENT_GCODE + "' and i.ficode=u.ficode and i.gcode=u.gcode and i.ucode=u.ucode and i.pcode=" + Convert.ToInt32(ds.Tables["Voucher_Desc"].Rows[i][15].ToString()) + " ");
                            if (dtRef.Rows.Count > 0)
                            {
                                dgvItem.Rows[i].Cells[30].Value = dtRef.Rows[0][0].ToString();
                                dgvItem.Rows[i].Cells[33].Value = dtRef.Rows[0][2].ToString();
                            }
                            dgvItem.Rows[i].Cells[32].Value = ds.Tables["Voucher_Desc"].Rows[i][16].ToString();
                            dgvItem.Rows[i].Cells[34].Value = ds.Tables["Voucher_Desc"].Rows[i][17].ToString();
                            dgvItem.Rows[i].Cells[35].Value = ds.Tables["Voucher_Desc"].Rows[i][18].ToString();
                            dgvItem.Rows[i].Cells[36].Value = ds.Tables["Voucher_Desc"].Rows[i][19].ToString();
                            dgvItem.Rows[i].Cells[37].Value = ds.Tables["Voucher_Desc"].Rows[i][20].ToString();
                        }
                        else if (Flag_Deying == true)
                        {
                            dgvItem.Rows[i].Cells[31].Value = ds.Tables["Voucher_Desc"].Rows[i][15].ToString();
                            DataTable dtRef = edpcom.GetDatatable(" select distinct i.pdesc,i.ucode,u.UDESC from iglmst i,unit u where i.ficode='" + edpcom.CurrentFicode + "' and i.gcode='" + edpcom.PCURRENT_GCODE + "' and i.ficode=u.ficode and i.gcode=u.gcode and i.ucode=u.ucode and i.pcode=" + Convert.ToInt32(ds.Tables["Voucher_Desc"].Rows[i][15].ToString()) + " ");
                            if (dtRef.Rows.Count > 0)
                                dgvItem.Rows[i].Cells[30].Value = dtRef.Rows[0][0].ToString();
                        }
                    }
                    try
                    {
                        if (Tentry != "n")
                        {
                            DataTable vchr = edpcom.GetDatatable("SELECT v.glcode,v.CRAMT FROM vchr v WHERE v.FICODE='" + EDPComm.CurrentFicode + "' AND v.GCODE='" + EDPComm.PCURRENT_GCODE + "' and v.voucher=" + ds.Tables["Voucher_Desc"].Rows[i][8] + " and v.TOBY='TO'  and  v.linkTentry='" + ds.Tables["Voucher_Desc"].Rows[i][9] + "' ");//SB                            
                            DataTable glmst = edpcom.GetDatatable("SELECT glcode,ldesc FROM glmst WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and glcode=" + vchr.Rows[i][0] + "");
                            DataTable dtvat = edpcom.GetDatatable("SELECT  distinct v.VAT_DESC,v.VAT_CODE,l.vat_per,v.AmtBasePercent FROM VATMaster v, LinkVATGLMST l WHERE l.FICODE='" + EDPComm.CurrentFicode + "' AND l.GCODE='" + EDPComm.PCURRENT_GCODE + "' AND v.VAT_CODE=l.VAT_CODE and l.glcode=" + vchr.Rows[i][0] + " ");
                            dgvItem.Rows[i].Cells[20].Value = glmst.Rows[0][1].ToString();
                            dgvItem.Rows[i].Cells[22].Value = glmst.Rows[0][0].ToString();
                            dgvItem.Rows[i].Cells[21].Value = dtvat.Rows[0][0].ToString();
                            dgvItem.Rows[i].Cells[23].Value = dtvat.Rows[0][1].ToString();
                            if (Information.IsNumeric(dtvat.Rows[0][2]))
                                dgvItem.Rows[i].Cells[26].Value = dtvat.Rows[0][2].ToString();
                        }
                    }
                    catch { }
                    flug = false;
                }
                common.ClearDataTable(ds.Tables["AddLess"]);//sb
                // cmd = new SqlCommand("select AddLessDESC,Per,Amt,VOUCHER,AddLessCode from AddLess where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'and voucher=" + ds.Tables["Voucher_Desc"].Rows[0][8] + " and T_ENTRY='" + Tentry + "'", edpcon.mycon);
                cmd = new SqlCommand("select distinct  a.AddLessDESC,a.Per,a.Amt,a.VOUCHER,a.AddLessCode,g.sgroup from AddLess a,glmst g where  a.ficode=g.ficode and a.gcode=g.gcode and a.AddLessCode=g.glcode and a.FICODE='" + EDPComm.CurrentFicode + "' AND a.GCODE='" + edpcom.PCURRENT_GCODE + "'and a.voucher=" + ds.Tables["Voucher_Desc"].Rows[0][8] + " and a.T_ENTRY='" + Tentry + "'", edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "AddLess");
                for (int j = 0; j <= ds.Tables["AddLess"].Rows.Count - 1; j++)
                {
                    if (flug1 == false)
                        dgvAddless.Rows.Add();
                    dgvAddless.Rows[j].Cells[0].Value = ds.Tables["AddLess"].Rows[j][0].ToString();
                    dgvAddless.Rows[j].Cells[1].Value = ds.Tables["AddLess"].Rows[j][1].ToString();
                    dgvAddless.Rows[j].Cells[3].Value = ds.Tables["AddLess"].Rows[j][2].ToString();
                    dgvAddless.Rows[j].Cells[4].Value = ds.Tables["AddLess"].Rows[j][4].ToString();
                    dgvAddless.Rows[j].Cells[5].Value = ds.Tables["AddLess"].Rows[j][5].ToString();
                    if (ds.Tables["AddLess"].Rows[j][5].ToString() == "30" || ds.Tables["AddLess"].Rows[j][5].ToString() == "31")
                        dgvAddless.Rows[j].Cells[6].Value = "False";
                    else
                        dgvAddless.Rows[j].Cells[6].Value = "True";

                    if (Convert.ToInt32(ds.Tables["AddLess"].Rows[j][2]) >= 0)
                        dgvAddless.Rows[j].Cells[2].Value = "NA";
                    else
                        dgvAddless.Rows[j].Cells[2].Value = "LESS";
                    flug1 = false;
                }

                if (Flag_Printing && SBType == "OS")
                {
                    string st = " SELECT DISTINCT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE] FROM IDATA ID,itran it WHERE ID.FICODE=it.ficode and ID.gcode=it.gcode and ID.FICODE='" + edpcom.CurrentFicode + "' AND " +
                      " ID.voucher=it.voucher and ID.t_entry=it.T_entry and  ID.GCODE='" + edpcom.PCURRENT_GCODE + "' AND ID.T_ENTRY='OS' AND ID.Party_code=" + PartyCode + " and it.DSTATUS<>'RUNNING' And it.voucher=" + vno + "";
                    edpcon.Open();
                    common.ClearDataTable(ds.Tables["ChOrd"]);
                    cmd = new SqlCommand(st, edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "ChOrd");
                    edpcon.Close();
                    if (ds.Tables["ChOrd"].Rows.Count > 0)
                        btnStockTransfer.Visible = true;
                }

            }
            catch { }
        }

        public void clearcontrol()
        {
            RCOUNT = 0;
            AdhokAmt = 0;
            dgvItem.Rows.Clear();
            dgvAddless.Rows.Clear();
            txtDesc.Text = "";
            if (!CHKORD)
            {
                cmbPartyName.Text = "";
                txtcurrency.Text = "";
                txtVoucherChallan.Text = "";
                txtvoucher.Text = "";
                Pcode_sl = null;
                cmbPartyName.Text = "";
                PartyCode = 0;
                currcode = 0;
                cmbReffParty.Text = "";
                ReffPartyCode = 0;
                PartyType = "";
                textBox1.Text = "";
            }
            ds.Tables.Clear();
            common.HTAddress.Clear();             
            lbcmp.Items.Clear();               
            lbRC.Items.Clear();            
            txtNarr.Text = "";
            txtTotalAmt.Text = "0.00";
            cmbSales.Text = "";
            SalesCode = 0;
            txtTotalAmt.Text = "0.00";
        }

        private void cleardgvAdditional()
        {
            for (int s = 0; s <= dgvAdditional.Rows.Count - 1; s++)
            {
                dgvAdditional.Rows[s].Cells[0].Value = null;
            }
        }

        private bool validation()
        {
            try
            {
                if (cmbAct.Text == "")
                {
                    EDPMessage.Show("Please Select the Action", "Information");
                    return false;
                }
                if (txtvoucher.Text == "")
                {
                    EDPMessage.Show(" Voucher no can't be null", "Information");
                    return false;
                }
                if (!Flag_Cash)
                {
                    if ((cmbPartyName.Text == "") || (PartyCode == 0))
                    {
                        EDPMessage.Show(" Please Select Party Name", "Information");
                        return false;
                    }
                }
                if (Tentry == "n" || Tentry == "9" || Tentry == "a" || Tentry == "8")
                {
                    for (int s = 0; s < dgvItem.Rows.Count; s++)
                    {
                        if (((Convert.ToDecimal(dgvItem.Rows[s].Cells[1].Value)) > (Convert.ToDecimal(dgvItem.Rows[s].Cells[17].Value))) && dgvItem.Rows[s].Cells[17].Value != null)
                        {
                            EDPMessage.Show("The Quentity in row no " + (Convert.ToInt32(s) + 1) + " is greater than remaining quantity.Check it. ", "Information");
                            return false;
                        }
                    }
                }
                for (int s = 0; s < dgvItem.Rows.Count; s++)
                {
                    if (Information.IsNothing(dgvItem.Rows[s].Cells[0].Value))
                    {
                        EDPMessage.Show(" Please select product in the row number " + Convert.ToInt16(s + 1) + "  and first coloumn.", "Information");
                        return false;
                    }
                    if (Information.IsNothing(dgvItem.Rows[s].Cells[1].Value) == true)
                    {
                        EDPMessage.Show(" Please input quentity in the row number " + Convert.ToInt16(s + 1) + "   and second coloumn.", "Information");
                        return false;
                    }
                    if ((Information.IsNumeric(dgvItem.Rows[s].Cells[6].Value) == false) && (SBType=="SALES") && (SBType=="PUR"))
                    {
                        EDPMessage.Show(" Please input rate in the row number " + Convert.ToInt16(s + 1) + "   in the rate coloumn and press ENTER KEY.", "Information");
                        return false;
                    }
                }
                if (Flgaddless == false)//sb
                {
                    EDPMessage.Show("Please Press F9 for vat calculation", "Information");
                    return false;
                }
            }
            catch { }
            return true;
        }

        //private void coloumnhide()
        //{
        //    try
        //    {
        //        //Flag_Printing = false;
        //        MultiSalePurAC = false;
        //        Flag_Deying = false;
        //        Flag_Printing = false;
        //        Flag_Cash = false;
        //        if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno = '3.10.1'") == "TRUE")
        //            Flag_Printing = true;

        //        if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno = '3.10.2'") == "TRUE")
        //        {
        //            Flag_Deying = true;
        //            dgvItem.Columns[30].HeaderText = "Refference Item";
        //        }

        //        if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno = '3.4.8.5'") == "TRUE")
        //            Flag_ReffBill = true;

        //        if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno = '3.4.8.9'") == "TRUE")
        //            Flag_Cash = true;

        //        if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.4.8.4'") == "TRUE")
        //        {
        //            MultiSalePurAC = true;
        //            label7.Enabled = false;
        //            cmbSales.Enabled = false;
        //        }
        //        else
        //        {
        //            label7.Enabled = true;
        //            chkCash.Checked = true;
        //            cmbSales.Enabled = true;
        //            cmbCash.Enabled = true;
        //        }
        //        //if (Flag_Printing)
        //        //{
        //        //    dgvItem.Columns[40].Visible = false;
        //        //    dgvItem.Columns[41].Visible = false;
        //        //}

        //        if (!Flag_ReffBill)
        //        {
        //            groupBox5.Visible = false;
        //        }

        //        if (Flag_Cash)
        //        {
        //            chkCash.Checked = true;
        //            cmbCash.Enabled = true;
        //        }
        //        if (Tentry == "OS")
        //        {
        //            if (Flag_Printing)
        //            {
        //                dgvItem.Columns[7].Visible = false;
        //                dgvItem.Columns[8].Visible = false;
        //                dgvItem.Columns[9].Visible = false;
        //                dgvItem.Columns[10].Visible = false;
        //                dgvItem.Columns[11].Visible = false;
        //                dgvItem.Columns[12].Visible = false;
        //                dgvItem.Columns[13].Visible = false;
        //                dgvItem.Columns[16].Visible = false;
        //                dgvItem.Columns[17].Visible = false;
        //                dgvItem.Columns[29].Visible = true;
        //                dgvItem.Columns[30].Visible = true;
        //                dgvItem.Columns[32].Visible = true;
        //                dgvItem.Columns[33].Visible = true;
        //                dgvItem.Columns[35].Visible = true;
        //                dgvItem.Columns[36].Visible = true;
        //                dgvItem.Columns[37].Visible = true;
        //                dgvItem.Columns[43].Visible = true;
        //                //btnStockTransfer.Visible = true;
        //            }
        //            else if (Flag_Deying)
        //            {
        //                dgvItem.Columns[7].Visible = false;
        //                dgvItem.Columns[8].Visible = false;
        //                dgvItem.Columns[9].Visible = false;
        //                dgvItem.Columns[10].Visible = false;
        //                dgvItem.Columns[11].Visible = false;
        //                dgvItem.Columns[12].Visible = false;
        //                dgvItem.Columns[13].Visible = false;
        //                dgvItem.Columns[14].Visible = false;
        //                dgvItem.Columns[15].Visible = false;
        //                dgvItem.Columns[16].Visible = false;
        //                dgvItem.Columns[17].Visible = false;
        //                dgvItem.Columns[30].Visible = true;
        //                dgvItem.Columns[43].Visible = true;
        //            }
        //            else
        //            {
        //                dgvItem.Columns[7].Visible = false;
        //                dgvItem.Columns[8].Visible = false;
        //                dgvItem.Columns[9].Visible = false;
        //                dgvItem.Columns[10].Visible = false;
        //                dgvItem.Columns[11].Visible = false;
        //                dgvItem.Columns[12].Visible = false;
        //                dgvItem.Columns[13].Visible = false;
        //                dgvItem.Columns[14].Visible = false;
        //                dgvItem.Columns[15].Visible = false;
        //                dgvItem.Columns[16].Visible = false;
        //                dgvItem.Columns[17].Visible = false;
        //            }
        //        }
        //        if (Tentry == "n")
        //        {
        //            if (Flag_Printing)
        //            {
        //                dgvItem.Columns[7].Visible = false;
        //                dgvItem.Columns[8].Visible = false;
        //                dgvItem.Columns[9].Visible = false;
        //                dgvItem.Columns[10].Visible = false;
        //                dgvItem.Columns[11].Visible = false;
        //                dgvItem.Columns[12].Visible = false;
        //                dgvItem.Columns[13].Visible = false;
        //                dgvItem.Columns[16].Visible = false;
        //                dgvItem.Columns[17].Visible = false;
        //                dgvItem.Columns[29].Visible = true;
        //                dgvItem.Columns[30].Visible = true;
        //                dgvItem.Columns[32].Visible = true;
        //                dgvItem.Columns[33].Visible = true;
        //                dgvItem.Columns[35].Visible = true;
        //                dgvItem.Columns[36].Visible = true;
        //                dgvItem.Columns[37].Visible = true;
        //                dgvItem.Columns[43].Visible = true;
        //            }
        //            else if (Flag_Deying)
        //            {
        //                dgvItem.Columns[7].Visible = false;
        //                dgvItem.Columns[8].Visible = false;
        //                dgvItem.Columns[9].Visible = false;
        //                dgvItem.Columns[10].Visible = false;
        //                dgvItem.Columns[11].Visible = false;
        //                dgvItem.Columns[12].Visible = false;
        //                dgvItem.Columns[13].Visible = false;
        //                dgvItem.Columns[14].Visible = false;
        //                dgvItem.Columns[15].Visible = false;
        //                dgvItem.Columns[16].Visible = false;
        //                dgvItem.Columns[17].Visible = false;
        //                dgvItem.Columns[30].Visible = true;
        //                //dgvItem.Columns[43].Visible = true;
        //            }
        //            else
        //            {
        //                dgvItem.Columns[7].Visible = false;
        //                dgvItem.Columns[8].Visible = false;
        //                dgvItem.Columns[9].Visible = false;
        //                dgvItem.Columns[10].Visible = false;
        //                dgvItem.Columns[11].Visible = false;
        //                dgvItem.Columns[12].Visible = false;
        //                dgvItem.Columns[13].Visible = false;
        //                dgvItem.Columns[14].Visible = false;
        //                dgvItem.Columns[15].Visible = false;
        //                dgvItem.Columns[16].Visible = false;
        //                dgvItem.Columns[17].Visible = false;
        //            }
        //        }
        //        if (Tentry == "9")
        //        {
        //            if (Flag_Printing)
        //            {
        //                dgvItem.Columns[5].Visible = false;
        //                dgvItem.Columns[7].Visible = false;
        //                dgvItem.Columns[8].Visible = false;
        //                dgvItem.Columns[9].Visible = false;
        //                dgvItem.Columns[10].Visible = false;
        //                dgvItem.Columns[11].Visible = false;
        //                dgvItem.Columns[12].Visible = false;
        //                dgvItem.Columns[13].Visible = false;
        //                dgvItem.Columns[16].Visible = false;
        //                dgvItem.Columns[17].Visible = false;
        //                dgvItem.Columns[18].Visible = false;
        //                dgvItem.Columns[43].Visible = true;
        //                if (MultiSalePurAC)
        //                {
        //                    dgvItem.Columns[20].Visible = true;
        //                    dgvItem.Columns[21].Visible = true;
        //                }
        //                dgvItem.Columns[29].Visible = true;
        //                dgvItem.Columns[30].Visible = true;
        //                dgvItem.Columns[32].Visible = true;
        //                dgvItem.Columns[33].Visible = true;
        //                dgvItem.Columns[35].Visible = true;
        //                dgvItem.Columns[36].Visible = true;
        //                dgvItem.Columns[37].Visible = true;
        //            }
        //            else if (Flag_Deying)
        //            {
        //                if (MultiSalePurAC)
        //                {
        //                    dgvItem.Columns[20].Visible = true;
        //                    dgvItem.Columns[21].Visible = true;
        //                    dgvItem.Columns[22].Visible = true;
        //                    dgvItem.Columns[23].Visible = true;
        //                }
        //                Flag_Printing = false;
        //                dgvItem.Columns[7].Visible = false;
        //                dgvItem.Columns[8].Visible = false;
        //                dgvItem.Columns[9].Visible = false;
        //                dgvItem.Columns[10].Visible = false;
        //                dgvItem.Columns[11].Visible = false;
        //                dgvItem.Columns[12].Visible = false;
        //                dgvItem.Columns[13].Visible = false;
        //                dgvItem.Columns[14].Visible = false;
        //                dgvItem.Columns[15].Visible = false;
        //                dgvItem.Columns[16].Visible = false;
        //                dgvItem.Columns[17].Visible = false;
        //                dgvItem.Columns[19].Visible = false;
        //                dgvItem.Columns[22].Visible = false;
        //                dgvItem.Columns[23].Visible = false;
        //                dgvItem.Columns[30].Visible = true;
        //                dgvItem.Columns[43].Visible = true;
        //            }
        //            else
        //            {
        //                if (MultiSalePurAC)
        //                {
        //                    dgvItem.Columns[20].Visible = true;
        //                    dgvItem.Columns[21].Visible = true;
        //                    dgvItem.Columns[22].Visible = true;
        //                    dgvItem.Columns[23].Visible = true;
        //                }
        //                Flag_Printing = false;
        //                dgvItem.Columns[7].Visible = false;
        //                dgvItem.Columns[8].Visible = false;
        //                dgvItem.Columns[9].Visible = false;
        //                dgvItem.Columns[10].Visible = false;
        //                dgvItem.Columns[11].Visible = false;
        //                dgvItem.Columns[12].Visible = false;
        //                dgvItem.Columns[13].Visible = false;
        //                dgvItem.Columns[14].Visible = false;
        //                dgvItem.Columns[15].Visible = false;
        //                dgvItem.Columns[16].Visible = false;
        //                dgvItem.Columns[17].Visible = false;
        //                dgvItem.Columns[19].Visible = false;
        //                dgvItem.Columns[22].Visible = false;
        //                dgvItem.Columns[23].Visible = false;
        //            }
        //        }
        //        if (Tentry == "8")
        //        {
        //            dgvItem.Columns[7].Visible = false;
        //            dgvItem.Columns[8].Visible = false;
        //            dgvItem.Columns[9].Visible = false;
        //            dgvItem.Columns[10].Visible = false;
        //            dgvItem.Columns[11].Visible = false;
        //            dgvItem.Columns[12].Visible = false;
        //            dgvItem.Columns[13].Visible = false;
        //            dgvItem.Columns[14].Visible = false;
        //            dgvItem.Columns[15].Visible = false;
        //            dgvItem.Columns[16].Visible = false;
        //            dgvItem.Columns[17].Visible = false;
        //            if (Flag_Printing)
        //                rbtAdditional.Visible = false;

        //            if (MultiSalePurAC)
        //            {
        //                dgvItem.Columns[20].Visible = true;
        //                dgvItem.Columns[21].Visible = true;
        //                dgvItem.Columns[20].HeaderText = "Purchase A/C";
        //            }
        //        }
        //        if (Tentry == "a")
        //        {
        //            dgvItem.Columns[7].Visible = false;
        //            dgvItem.Columns[8].Visible = false;
        //            dgvItem.Columns[9].Visible = false;
        //            dgvItem.Columns[10].Visible = false;
        //            dgvItem.Columns[11].Visible = false;
        //            dgvItem.Columns[12].Visible = false;
        //            dgvItem.Columns[13].Visible = false;
        //            dgvItem.Columns[14].Visible = false;
        //            dgvItem.Columns[15].Visible = false;
        //            dgvItem.Columns[16].Visible = false;
        //            dgvItem.Columns[17].Visible = false;
        //            if (Flag_Printing)
        //                rbtAdditional.Visible = false;
        //        }
        //        if (Tentry == "OP")
        //        {
        //            dgvItem.Columns[7].Visible = false;
        //            dgvItem.Columns[8].Visible = false;
        //            dgvItem.Columns[9].Visible = false;
        //            dgvItem.Columns[10].Visible = false;
        //            dgvItem.Columns[11].Visible = false;
        //            dgvItem.Columns[12].Visible = false;
        //            dgvItem.Columns[13].Visible = false;
        //            dgvItem.Columns[14].Visible = false;
        //            dgvItem.Columns[15].Visible = false;
        //            dgvItem.Columns[16].Visible = false;
        //            dgvItem.Columns[17].Visible = false;
        //            if (Flag_Printing)
        //                rbtAdditional.Visible = false;
        //        }
        //        if (Tentry == "SI")
        //        {
        //            dgvItem.Columns[7].Visible = false;
        //            dgvItem.Columns[8].Visible = false;
        //            dgvItem.Columns[9].Visible = false;
        //            dgvItem.Columns[10].Visible = false;
        //            dgvItem.Columns[11].Visible = false;
        //            dgvItem.Columns[12].Visible = false;
        //            dgvItem.Columns[13].Visible = false;
        //            dgvItem.Columns[14].Visible = false;
        //            dgvItem.Columns[15].Visible = false;
        //            dgvItem.Columns[16].Visible = false;
        //            dgvItem.Columns[17].Visible = false;
        //            if (Flag_Printing)
        //            {
        //                rbtAdditional.Visible = false;
        //                //cmbRefOrd.Enabled = false;
        //            }
        //        }
        //        if (Tentry == "SO")
        //        {
        //            dgvItem.Columns[7].Visible = false;
        //            dgvItem.Columns[8].Visible = false;
        //            dgvItem.Columns[9].Visible = false;
        //            dgvItem.Columns[10].Visible = false;
        //            dgvItem.Columns[11].Visible = false;
        //            dgvItem.Columns[12].Visible = false;
        //            dgvItem.Columns[13].Visible = false;
        //            //dgvItem.Columns[14].Visible = false;
        //            dgvItem.Columns[15].Visible = false;
        //            dgvItem.Columns[16].Visible = false;
        //            dgvItem.Columns[17].Visible = false;
        //            if (Flag_Printing)
        //            {
        //                rbtAdditional.Visible = false;
        //                //cmbRefOrd.Enabled = false;
        //            }
        //        }
        //    }
        //    catch { }
        //}

        private void dgvAddless_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && dgvAddless.Columns[0].HeaderText == "Addless Perticular")
                {
                    string str;
                    common.Plist = "ADDLESS";
                    str = "SELECT LDESC,GLCODE,SGROUP FROM GLMST WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' AND MTYPE='L' AND (SGROUP IN (0,19,30) OR MGROUP IN (8,7,10))";
                    frmLedgerOpen AM = new frmLedgerOpen();
                    common.LOV("SELECT Addless", str, textBox1, 1, AM, true, "Click here to create new LEDGER");
                    if (common.LOVRESULT == "NO")
                    {
                        common.LOVRESULT = null;
                        return;
                    }
                    dgvAddless.Rows[e.RowIndex].Cells[0].Value = textBox1.Text;
                    dgvAddless.Rows[e.RowIndex].Cells[4].Value = common.LovReturnValue;
                    dgvAddless.Rows[e.RowIndex].Cells[5].Value = common.AddlessSub;
                }
            }
            catch { }
        }

        private void dgvAddless_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAddless.CurrentCell.ColumnIndex == 1)
                {
                    ADLPER = 0; ADLVAL = 0;
                    if (Information.IsNothing(dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[dgvAddless.CurrentCell.ColumnIndex].Value) == false)
                    {
                        if (Information.IsNumeric(dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[dgvAddless.CurrentCell.ColumnIndex].Value) == true)
                        {
                            ADLPER = Convert.ToDouble(dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[dgvAddless.CurrentCell.ColumnIndex].Value);
                        }
                        else
                        {
                            EDPMessageBox.EDPMessage.Show("Value should be numeric.");
                            return;
                        }
                    }
                }

                if (dgvAddless.CurrentCell.ColumnIndex == 3)
                {
                    TotalAmt = 0;
                    for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                    {
                        try
                        {
                            TotalAmt = TotalAmt + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value);
                        }
                        catch { }
                    }
                    for (int i = 0; i <= dgvAddless.RowCount - 1; i++)
                    {
                        try
                        {
                            TotalAmt = TotalAmt + Convert.ToDouble(dgvAddless.Rows[i].Cells[3].Value);
                        }
                        catch { }
                    }
                    txtAmt.Text = TotalAmt.ToString(common.SetDecimalPlace());
                }
            }
            catch { }
        }

        private void dgvAddless_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                    dgvAddless_CellDoubleClick(sender, new DataGridViewCellEventArgs(dgvAddless.CurrentCell.ColumnIndex, dgvAddless.CurrentCell.RowIndex));
            }
            catch { }
        }

        private void cmbVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SI = cmbVoucher.SelectedIndex;
            switch (SI)
            {
                case 0://Sales Order                    
                    break;
                case 1://Sales Challan
                    break;
                case 2://Sales Bill
                    break;
                case 3://Sales Return
                    break;
                case 4://Purchase Order
                    break;
                case 5://Purchase Challan
                    break;
                case 6://Purchase Bill
                    break;
                case 7://Purchase Return
                    break;
            }
        }

        private void ShowForm(Form ToShow, Form parent)
        {
            if (EDPComm.CheckMdiChild(ToShow, parent))
                return;
            ToShow.MdiParent = parent;
            ToShow.Show();
        }

        private void frmOrderForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F12 && Flag_Printing && (SBType=="SALES" || SBType=="CHLN" || SBType=="OS"))//Key Pressing for Total amount entry
                {
                    PanelTotalAmt.Visible = true;                    
                    PanelTotalAmt.Width = 200;
                    PanelTotalAmt.Height = 26;
                    PanelTotalAmt.Left = 450;
                    PanelTotalAmt.Top = 10;
                    //lblTotalAmt.Width = 85;
                    //lblTotalAmt.Height = 20;
                    lblTotalAmt.Left = 20;
                    lblTotalAmt.Top = 6;
                    lblTotalAmt.Text = "Enter Total Amt.";
                    txtTotalAmt.Width = 85;
                    txtTotalAmt.Height = 20;
                    txtTotalAmt.Left = 110;
                    txtTotalAmt.Top = 3;
                }

                if (e.KeyCode == Keys.F6)//for the event: pressing of F6 keys to save
                {
                    if (action.ToUpper() == "ADD" || action.ToUpper() == "MODIFY")
                        btnAcc_Click(sender, new EventArgs());
                    if (action.ToUpper() == "DELETE")
                        btnDel_Click(sender, new EventArgs());
                    PanelTotalAmt.Visible = false; 
                }
                else if (e.KeyCode == Keys.Escape)//for the event: pressing of Esc keys
                {
                    this.Close();
                }
                if (e.KeyCode == Keys.F1)
                {
                    if (RBItemDetail.Checked)
                    {

                        if (RBAddless.Visible == true)
                        {
                            RBAddless.Checked = true;
                            panel2.Visible = true;
                            panel1.Visible = false;
                            panel3.Visible = false;
                            panel4.Visible = false;
                        }
                        else if (rbtAdditional.Visible == true)
                        {
                            rbtAdditional.Checked = true;
                            panel1.Visible = false;
                            panel2.Visible = false;
                            panel3.Visible = false;
                            panel4.Visible = true;
                            dgvAdditional.CurrentCell = dgvAdditional[0, 0];
                        }
                        else if (RBNarration.Visible == true)
                        {
                            RBNarration.Checked = true;
                            panel1.Visible = false;
                            panel2.Visible = false;
                            panel4.Visible = false;
                            panel3.Visible = true;
                        }
                    }
                    else if (RBAddless.Checked)
                    {
                        if (rbtAdditional.Visible == true)
                        {
                            rbtAdditional.Checked = true;
                            panel1.Visible = false;
                            panel2.Visible = false;
                            panel3.Visible = false;
                            panel4.Visible = true;
                        }
                        else if (RBNarration.Visible == true)
                        {
                            RBNarration.Checked = true;
                            panel1.Visible = false;
                            panel2.Visible = false;
                            panel4.Visible = false;
                            panel3.Visible = true;
                        }
                        else if (RBItemDetail.Visible == true)
                        {
                            RBItemDetail.Checked = true;
                            panel1.Visible = true;
                            panel2.Visible = false;
                            panel3.Visible = false;
                            panel4.Visible = false;
                        }
                    }
                    else if (rbtAdditional.Checked)
                    {

                        if (RBNarration.Visible == true)
                        {
                            RBNarration.Checked = true;
                            panel1.Visible = false;
                            panel2.Visible = false;
                            panel4.Visible = false;
                            panel3.Visible = true;
                            dgvAdditional.CurrentCell = dgvAdditional[0, 0];
                        }
                        else if (RBItemDetail.Visible == true)
                        {
                            RBItemDetail.Checked = true;
                            panel1.Visible = true;
                            panel2.Visible = false;
                            panel3.Visible = false;
                            panel4.Visible = false;
                        }
                        else if (rbtAdditional.Visible == true)
                        {
                            rbtAdditional.Checked = true;
                            panel1.Visible = false;
                            panel2.Visible = false;
                            panel3.Visible = false;
                            panel4.Visible = true;
                            dgvAdditional.CurrentCell = dgvAdditional[0, 0];
                        }
                    }
                    else if (RBNarration.Checked)
                    {
                        if (RBItemDetail.Visible == true)
                        {
                            RBItemDetail.Checked = true;
                            panel1.Visible = true;
                            panel2.Visible = false;
                            panel3.Visible = false;
                            panel4.Visible = false;
                        }
                        else if (RBAddless.Visible == true)
                        {
                            RBAddless.Checked = true;
                            panel2.Visible = true;
                            panel1.Visible = false;
                            panel3.Visible = false;
                            panel4.Visible = false;
                        }
                        else if (rbtAdditional.Visible == true)
                        {
                            rbtAdditional.Checked = true;
                            panel1.Visible = false;
                            panel2.Visible = false;
                            panel3.Visible = false;
                            panel4.Visible = true;
                            dgvAdditional.CurrentCell = dgvAdditional[0, 0];
                        }
                    }
                }

                if (e.KeyValue == 120 && (SBType == "SALES" || SBType == "PUR") && (!MultiSalePurAC))
                {
                    RBAddless.Checked = true;
                    panel2.Visible = true;
                    panel1.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;

                    double vatmrpprice = 0;
                    double TA = 0;
                    double TAA = 0;
                    //double AfterAddlessAmt = 0;
                    double TotalItemAmt = 0;
                    double VATPER = 0;
                    double AMTBASEDPER = 0;
                    double VATAMT = 0;
                    DataTable dtAmtBasePer = new DataTable();
                    for (int s = 0; s < dgvAddless.Rows.Count; s++)
                    {
                        if (Convert.ToString(dgvAddless.Rows[s].Cells[6].Value) == "False")
                        {
                            dgvAddless.Rows.RemoveAt(Convert.ToInt16(s));
                            s = 0;
                        }
                    }
                    if (dgvAddless.Rows.Count > 0)
                    {
                        if (Convert.ToString(dgvAddless.Rows[0].Cells[6].Value) == "False")
                            dgvAddless.Rows.RemoveAt(Convert.ToInt16(0));
                    }
                    
                    DataTable dtvat = edpcom.GetDatatable("SELECT v.VAT_DESC,v.VAT_CODE,l.vat_per,v.AmtBasePercent FROM VATMaster v, LinkVATGLMST l WHERE l.FICODE='" + EDPComm.CurrentFicode + "' AND l.GCODE='" + EDPComm.PCURRENT_GCODE + "' AND v.VAT_CODE=l.VAT_CODE and l.glcode=" + SalesCode + " ");
                    for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                    {
                        vatmrpprice = 0;
                        common.ClearDataTable(dtAmtBasePer);
                        dtAmtBasePer = edpcom.GetDatatable("SELECT AmtBasePercent FROM iglmst WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' AND pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " ");//SSSS
                        if (edpcom.GetresultS("SELECT VATONMRP FROM IGLMST WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " ") == "True")
                        {
                            vatmrpprice = Convert.ToDouble(edpcom.GetresultS("Select Distinct Rate from MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and Rate_Type='M'  and Effective_Date=(select max(Effective_Date) from  MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Rate_Type='M' and Pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " )"));
                            if (vatmrpprice == 0)
                                EDPMessage.Show("MRP Value is not assigned on selected product.");
                        }
                        else
                            vatmrpprice = Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value);                       

                        //===================
                        string RateCalON = "1";
                        if (Flag_Printing)
                        {
                            double Vol = 0, RQ = 0;
                            if (Information.IsNumeric(dgvItem.Rows[i].Cells[14].Value) == true)
                            {
                                Vol = Convert.ToDouble(dgvItem.Rows[i].Cells[14].Value);
                            }
                            if (Information.IsNumeric(dgvItem.Rows[i].Cells[43].Value) == true)
                            {
                                RQ = Convert.ToDouble(dgvItem.Rows[i].Cells[43].Value);
                            }
                            if (Information.IsNothing(dgvItem.Rows[i].Cells[44].Value) == false)
                            {
                                if (Convert.ToBoolean(dgvItem.Rows[i].Cells[44].Value))
                                {
                                    if (Information.IsNumeric(dgvItem.Rows[i].Cells[39].Value))
                                    {
                                        TA = TA + ((Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice * Convert.ToDouble(RateCalON)) * Math.Round(Vol)) / RQ;
                                    }
                                    else
                                        TA = TA + ((Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice * Math.Round(Vol)) / RQ);
                                }
                                else
                                {
                                    if (Information.IsNumeric(dgvItem.Rows[i].Cells[39].Value))
                                    {
                                        TA = TA + ((Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice * Convert.ToDouble(RateCalON))) / RQ;
                                    }
                                    else
                                        TA = TA + ((Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice) / RQ);
                                }
                            }
                        }
                        else
                        {
                            if (Information.IsNumeric(dgvItem.Rows[i].Cells[38].Value))
                                TA = TA + (Convert.ToDouble(dgvItem.Rows[i].Cells[38].Value) * vatmrpprice);
                            else
                                TA = TA + (Convert.ToDouble(dgvItem.Rows[i].Cells[1].Value) * vatmrpprice);
                        }
                    //}
                        //===================
                    }

                    if ((Flag_Printing) && (Convert.ToDouble(txtTotalAmt.Text)) > 0 && (chkIncVAT.Checked))
                    {
                        TA = Convert.ToDouble(txtTotalAmt.Text);
                    }

                    for (int i = 0; i <= dgvAddless.Rows.Count - 1; i++)
                        TAA = TAA + Convert.ToDouble(dgvAddless.Rows[i].Cells[3].Value);
                    TotalItemAmt = TA + TAA;
                    if (dtvat.Rows.Count > 0)
                    {                        
                        if (Flag_Printing)
                        {
                            if (chkOnVATPer.Checked)
                                AMTBASEDPER = 20;
                            else
                                AMTBASEDPER = 0;
                        }
                        else
                        {
                            if (Information.IsNumeric(dtvat.Rows[0][3]) == true)
                                AMTBASEDPER = Convert.ToDouble(dtvat.Rows[0][3]);
                        }
                        if (Information.IsNumeric(dtvat.Rows[0][2]) == true)
                            VATPER = Convert.ToDouble(dtvat.Rows[0][2]);
                        //if (Information.IsNumeric(dtAmtBasePer.Rows[0][0]) == true)
                        //    AMTBASEDPER = Convert.ToDouble(dtAmtBasePer.Rows[0][0]);//
                    }

                    TotalItemAmt = TotalItemAmt * (100 - AMTBASEDPER) / 100;
                    if ((Convert.ToDouble(txtTotalAmt.Text) > 0) && (chkIncVAT.Checked))
                    {
                        double VATPERCAL = (100 + VATPER) / 100;
                        TotalItemAmt = TotalItemAmt / VATPERCAL;
                        VATAMT = TotalItemAmt * 4 / 100;
                    }
                    else
                    {
                        VATAMT = TotalItemAmt * VATPER / 100;
                    }
                    if (dgvAddless.Rows.Count == 1 && dgvAddless.Rows[0].Cells[0].Value == null && dgvAddless.Rows[0].Cells[1].Value == null)
                    {
                    }
                    else
                        dgvAddless.Rows.Add();
                    if (dtvat.Rows.Count > 0)
                    {
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[0].Value = dtvat.Rows[0][0];
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[1].Value = VATPER;
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[2].Value = "NA";
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[3].Value = VATAMT.ToString(common.SetDecimalPlace(2));
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[4].Value = dtvat.Rows[0][1].ToString();
                        edpcon.Open();
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[5].Value = Getresult1("SELECT DISTINCT SGROUP FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND LDESC='" + dtvat.Rows[0][0].ToString() + "'");
                        edpcon.Close();
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[6].Value = "False";
                    }
                    TA = 0;
                    for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                    {
                        TA = TA + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value);
                    }
                    if ((chkIncVAT.Checked) && (Convert.ToDouble(txtTotalAmt.Text) > 0))
                    {
                        TotalItemAmt = Convert.ToDouble(txtTotalAmt.Text);
                    }
                    else
                    {
                        TotalItemAmt = TA + TAA + VATAMT;
                        txtAmt.Text = TotalItemAmt.ToString(common.SetDecimalPlace());
                    }
                }

                if (e.KeyValue == 120 && (SBType == "SALES" || SBType == "PUR") && MultiSalePurAC)
                {
                    RBAddless.Checked = true;
                    panel2.Visible = true;
                    panel1.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;

                    Flgaddless = true;
                    if (flgDgvAdl)
                        dgvadlesRowCou = dgvAddless.Rows.Count;
                    flgDgvAdl = false;
                    for (int s = 0; s < dgvAddless.Rows.Count; s++)
                    {
                        if (Convert.ToString(dgvAddless.Rows[s].Cells[6].Value) == "False")
                        {
                            dgvAddless.Rows.RemoveAt(Convert.ToInt16(s));
                            s = 0;
                        }
                    }
                    if (dgvAddless.Rows.Count > 0)
                    {
                        if (Convert.ToString(dgvAddless.Rows[0].Cells[6].Value) == "False")
                            dgvAddless.Rows.RemoveAt(Convert.ToInt16(0));
                    }
                    double TAA = 0;
                    double AfterAddlessAmt = 0;
                    double TotalItemAmt = 0;
                    double TA = 0;
                    double vatmrpprice = 0;
                    double AmtBasedPer = 0;
                    double FinalAmt = 0;
                    double salvalamt = 0;
                    /*
                           int unitcode = Convert.ToInt32(edpcom.GetresultS("select distinct ucode from iglmst where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + ""));
                           decimal rate = 0;
                           string RateCalON = "1";
                           if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[4].Value))
                               rate = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells[4].Value);
                           string convRate = "1";
                           if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[38].Value))//SB
                               convRate = dgvItem.Rows[e.RowIndex].Cells[38].Value.ToString();
                           else
                               convRate = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[9].Value) + " and unitT=" + unitcode + "");
                           if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[39].Value))//200412
                               RateCalON = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[10].Value) + " and unitF=" + unitcode + " and unitT=" + Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[39].Value) + "");
                                   
       */

                    for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                    {
                        vatmrpprice = 0;
                        DataTable dtvat = edpcom.GetDatatable("SELECT v.VAT_DESC,v.VAT_CODE,l.vat_per,v.AmtBasePercent FROM VATMaster v, LinkVATGLMST l WHERE l.FICODE='" + EDPComm.CurrentFicode + "' AND l.GCODE='" + EDPComm.PCURRENT_GCODE + "' AND v.VAT_CODE=l.VAT_CODE and l.glcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[22].Value) + " ");
                        if (edpcom.GetresultS("SELECT VATONMRP FROM IGLMST WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " ") == "True")
                        {
                            vatmrpprice = Convert.ToDouble(edpcom.GetresultS("Select Distinct Rate from MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and Rate_Type='M'  and Effective_Date=(select max(Effective_Date) from  MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Rate_Type='M' and Pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " )"));
                            if (vatmrpprice == 0)
                                EDPMessage.Show("MRP Value is not assigned on selected product.");
                        }
                        else
                            vatmrpprice = Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value);
                        // TA = TA + (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice);

                        string RateCalON = "1";
                        //if (Information.IsNumeric(dgvItem.Rows[i].Cells[39].Value))//200412
                        //    RateCalON = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[i].Cells[39].Value) + "");

                        if (Flag_Printing)
                        {
                            double Vol = 0, RQ = 0;
                            if (Information.IsNumeric(dgvItem.Rows[i].Cells[14].Value) == true)
                            {
                                Vol = Convert.ToDouble(dgvItem.Rows[i].Cells[14].Value);
                            }
                            if (Information.IsNumeric(dgvItem.Rows[i].Cells[43].Value) == true)
                            {
                                RQ = Convert.ToDouble(dgvItem.Rows[i].Cells[43].Value);
                            }
                            if (Information.IsNothing(dgvItem.Rows[i].Cells[44].Value) == false)
                            {
                                if (Convert.ToBoolean(dgvItem.Rows[i].Cells[44].Value))
                                {
                                    if (Information.IsNumeric(dgvItem.Rows[i].Cells[39].Value))
                                    {
                                        TA = TA + ((Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice * Convert.ToDouble(RateCalON)) * Math.Round(Vol)) / RQ;
                                    }
                                    else
                                        TA = TA + ((Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice * Math.Round(Vol)) / RQ);
                                }
                                else
                                {
                                    if (Information.IsNumeric(dgvItem.Rows[i].Cells[39].Value))
                                    {
                                        TA = TA + ((Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice * Convert.ToDouble(RateCalON))) / RQ;
                                    }
                                    else
                                        TA = TA + ((Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice) / RQ);
                                }
                            }
                        }
                        else
                        {
                            //if (Information.IsNumeric(dgvItem.Rows[i].Cells[39].Value))
                            //{
                            //    TA = TA + (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice * Convert.ToDouble(RateCalON));
                            //}
                            //else
                            //if(Flag_Printing==true )
                            //    TA = TA + (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice);
                            //else

                            if (Information.IsNumeric(dgvItem.Rows[i].Cells[38].Value))
                                TA = TA + (Convert.ToDouble(dgvItem.Rows[i].Cells[38].Value) * vatmrpprice);
                            else
                                TA = TA + (Convert.ToDouble(dgvItem.Rows[i].Cells[1].Value) * vatmrpprice);
                        }
                    }

                    for (int i = 0; i <= dgvAddless.Rows.Count - 1; i++)
                        TAA = TAA + Convert.ToDouble(dgvAddless.Rows[i].Cells[3].Value);
                    TotalItemAmt = TA + TAA;

                    double vatper = 0;
                    for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                    {
                        vatper = 0;
                        DataTable dtAmtBasePer = edpcom.GetDatatable("SELECT AmtBasePercent FROM iglmst WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' AND pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " ");//SSSS
                        vatmrpprice = 0;
                        DataTable dtvat = edpcom.GetDatatable("SELECT v.VAT_DESC,v.VAT_CODE,l.vat_per,v.AmtBasePercent FROM VATMaster v, LinkVATGLMST l WHERE l.FICODE='" + EDPComm.CurrentFicode + "' AND l.GCODE='" + EDPComm.PCURRENT_GCODE + "' AND v.VAT_CODE=l.VAT_CODE and l.glcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[22].Value) + " ");
                        if (edpcom.GetresultS("SELECT VATONMRP FROM IGLMST WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " ") == "True")
                        {
                            vatmrpprice = Convert.ToDouble(edpcom.GetresultS("Select Distinct Rate from MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and Rate_Type='M'  and Effective_Date=(select max(Effective_Date) from  MarketRateUpdate where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and Rate_Type='M' and Pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " )"));
                            if (vatmrpprice == 0)
                                EDPMessage.Show("MRP Value is not assigned on selected product.");
                        }
                        else
                            vatmrpprice = Convert.ToDouble(dgvItem.Rows[i].Cells[4].Value);


                        //

                        string RateCalON = "1";
                        double VATCALAMT = 0;
                        //if (Information.IsNumeric(dgvItem.Rows[i].Cells[39].Value))//200412
                        //    RateCalON = edpcom.GetresultS(" select distinct conv_fig from UnitRelationMaster where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode=" + Convert.ToInt32(dgvItem.Rows[i].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[i].Cells[10].Value) + " and unitF=" + Convert.ToInt32(dgvItem.Rows[i].Cells[9].Value) + " and unitT=" + Convert.ToInt32(dgvItem.Rows[i].Cells[39].Value) + "");

                        if (Flag_Printing)
                        {
                            double Vol = 0, RQ = 0;
                            if (Information.IsNumeric(dgvItem.Rows[i].Cells[14].Value) == true)
                            {
                                Vol = Convert.ToDouble(dgvItem.Rows[i].Cells[14].Value);
                            }
                            if (Information.IsNumeric(dgvItem.Rows[i].Cells[43].Value) == true)
                            {
                                RQ = Convert.ToDouble(dgvItem.Rows[i].Cells[43].Value);
                            }
                            if (Information.IsNothing(dgvItem.Rows[i].Cells[44].Value) == false)
                            {
                                if (Convert.ToBoolean(dgvItem.Rows[i].Cells[44].Value))
                                {
                                    if (Information.IsNumeric(dgvItem.Rows[i].Cells[39].Value))
                                    {
                                        VATCALAMT = ((Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice * Convert.ToDouble(RateCalON)) * Math.Round(Vol)) / RQ;
                                    }
                                    else
                                        VATCALAMT = ((Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice * Math.Round(Vol)) / RQ);
                                }
                                else
                                {
                                    if (Information.IsNumeric(dgvItem.Rows[i].Cells[39].Value))
                                    {
                                        VATCALAMT = ((Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice * Convert.ToDouble(RateCalON))) / RQ;
                                    }
                                    else
                                        VATCALAMT = ((Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice) / RQ);
                                }
                            }
                        }
                        else
                        {
                            //if (Information.IsNumeric(dgvItem.Rows[i].Cells[39].Value))
                            //{
                            //    VATCALAMT = (Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value) * vatmrpprice * Convert.ToDouble(RateCalON));
                            //}
                            //else
                            if (Information.IsNumeric(dgvItem.Rows[i].Cells[38].Value))
                                VATCALAMT = (Convert.ToDouble(dgvItem.Rows[i].Cells[38].Value) * vatmrpprice);
                            else
                                VATCALAMT = (Convert.ToDouble(dgvItem.Rows[i].Cells[1].Value) * vatmrpprice);
                        }

                        // VATCALAMT = vatmrpprice * Convert.ToDouble(dgvItem.Rows[i].Cells[8].Value);

                        vatper = (TAA * VATCALAMT) / TA;
                        double IV = VATCALAMT + vatper;
                        //double VatAmt = (IV - (IV * Convert.ToDouble(dtvat.Rows[0][3]) / 100)) * Convert.ToDouble(dgvItem.Rows[i].Cells[26].Value) / 100;
                        double VatAmt = (IV - (IV * Convert.ToDouble(dtAmtBasePer.Rows[0][0]) / 100)) * Convert.ToDouble(dgvItem.Rows[i].Cells[26].Value) / 100;//SSSS
                        dgvItem.Rows[i].Cells[28].Value = IV;
                        dgvItem.Rows[i].Cells[24].Value = VatAmt;
                    }
                    decimal pa = 0;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Item", typeof(string));
                    dt.Columns.Add("ItemCode", typeof(string));
                    dt.Columns.Add("VATDESC", typeof(string));
                    dt.Columns.Add("VATCODE", typeof(string));
                    dt.Columns.Add("Amt", typeof(string));
                    dt.Columns.Add("VATAmt", typeof(string));
                    dt.Columns.Add("VATPer", typeof(string));

                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add("Item", typeof(string));
                    dt1.Columns.Add("ItemCode", typeof(string));
                    dt1.Columns.Add("VATDESC", typeof(string));
                    dt1.Columns.Add("VATCODE", typeof(string));
                    dt1.Columns.Add("Amt", typeof(string));
                    dt1.Columns.Add("VATAmt", typeof(string));
                    dt1.Columns.Add("VATPer", typeof(string));

                    for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                    {
                        dt.Rows.Add();
                        dt.Rows[i][0] = dgvItem.Rows[i].Cells[0].Value.ToString();
                        dt.Rows[i][1] = dgvItem.Rows[i].Cells[7].Value.ToString();
                        dt.Rows[i][2] = dgvItem.Rows[i].Cells[21].Value.ToString();
                        dt.Rows[i][3] = dgvItem.Rows[i].Cells[23].Value.ToString();
                        dt.Rows[i][4] = dgvItem.Rows[i].Cells[6].Value.ToString();
                        dt.Rows[i][5] = dgvItem.Rows[i].Cells[24].Value.ToString();
                        dt.Rows[i][6] = dgvItem.Rows[i].Cells[26].Value.ToString();
                    }
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        double VA = 0;
                        DataView dv = new DataView(dt);
                        dv.RowFilter = "VATCODE=" + dt.Rows[i][3] + "";
                        for (int j = 0; j <= dv.Count - 1; j++)
                            VA = VA + Convert.ToDouble(dv[j][5]);

                        dt1.Rows.Add();
                        int abc = 0;
                        for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                        {
                            abc = 1;
                            try
                            {
                                if (dt1.Rows[j][3].ToString() == dv[0][3].ToString())
                                {
                                    abc = 0;
                                    dt1.Rows.RemoveAt(dt1.Rows.Count - 1);
                                    break;
                                }
                            }
                            catch { }
                        }
                        if (abc == 1)
                        {
                            dt1.Rows[dt1.Rows.Count - 1][0] = dv[0][0];
                            dt1.Rows[dt1.Rows.Count - 1][1] = dv[0][1];
                            dt1.Rows[dt1.Rows.Count - 1][2] = dv[0][2];
                            dt1.Rows[dt1.Rows.Count - 1][3] = dv[0][3];
                            dt1.Rows[dt1.Rows.Count - 1][4] = dv[0][4];
                            dt1.Rows[dt1.Rows.Count - 1][5] = VA;
                            dt1.Rows[dt1.Rows.Count - 1][6] = dv[0][6];
                        }
                    }

                    for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                    {
                        if (dgvAddless.Rows.Count == 1 && dgvAddless.Rows[0].Cells[0].Value == null && dgvAddless.Rows[0].Cells[1].Value == null)
                        {
                        }
                        else
                            dgvAddless.Rows.Add();
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[0].Value = dt1.Rows[j][2].ToString();
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[1].Value = dt1.Rows[j][6].ToString();
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[2].Value = "NA";
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[3].Value = Convert.ToDecimal(dt1.Rows[j][5].ToString()).ToString(common.SetDecimalPlace(2));
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[4].Value = dt1.Rows[j][3].ToString();
                        edpcon.Open();
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[5].Value = Getresult1("SELECT DISTINCT SGROUP FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND LDESC='" + dt1.Rows[j][2].ToString() + "'");
                        edpcon.Close();
                        dgvAddless.Rows[dgvAddless.Rows.Count - 1].Cells[6].Value = "False";
                    }
                }

                //if (e.KeyCode == Keys.Insert && dgvItem.CurrentCell.ColumnIndex == 40)//SSSS
                //{
                //    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[4].Value))
                //    {
                //        if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11'") == "TRUE")
                //        {

                //            cmbUnit.Items.Clear();
                //            pnlMamata.Visible = true;
                //            pnlMamata.BringToFront();
                //            int x = MousePosition.X;
                //            int y = MousePosition.Y;
                //            this.pnlMamata.Location = new System.Drawing.Point(630, (30 + ((dgvItem.CurrentRow.Index + 1) * 14)));
                //            if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value))
                //            {
                //                DataTable dtunit = edpcom.GetDatatable("select distinct u.udesc,u.ucode from unit u,iglmst i,UnitSeriesMaster s where i.ficode=u.ficode and i.gcode=u.gcode AND u.ucode=s.ucode  and i.ficode=s.ficode and i.gcode=s.gcode and i.Series_ID=s.sm_id and i.pcode=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value) + " AND i.Series_ID=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[10].Value) + "");
                //                if (dtunit.Rows.Count > 0)
                //                {
                //                    for (int a = 0; a < dtunit.Rows.Count; a++)
                //                    {
                //                        cmbUnit.Items.Add(dtunit.Rows[a][0].ToString().Trim());
                //                        //cmbFromPrint.Items.Add(dtunit.Rows[a][0].ToString().Trim());

                //                    }
                //                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[41].Value))
                //                    {
                //                        for (int q = 0; q < dtunit.Rows.Count; q++)
                //                        {
                //                            if (Convert.ToInt32(dtunit.Rows[q][1]) == Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[41].Value))
                //                            {
                //                                cmbUnit.SelectedIndex = Convert.ToInt32(q);
                //                            }
                //                        }
                //                    }
                //                    else
                //                        cmbUnit.SelectedIndex = 0;
                //                }


                //                lblPartha.Text = " 1 " + dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[2].Value.ToString();
                //                if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[38].Value))
                //                    txtMukul.Text = dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[38].Value.ToString();
                //                txtMukul.Focus();
                //            }
                //            //string baseUnit = (edpcom.GetresultS("select distinct U.UDESC from iglmst I,UNIT U where I.FICODE=U.FICODE AND I.GCODE=U.GCODE AND I.UCODE=U.UCODE AND  I.FICODE='" + EDPComm.CurrentFicode + "' AND I.GCODE='" + edpcom.PCURRENT_GCODE + "' and I.pcode=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value) + ""));
                //            //if (baseUnit != null)
                //            //    lblMadan.Text = baseUnit;

                //        }
                //    }
                //    else
                //    {
                //        EDPMessage.Show("Please Input Rate", "Information");
                //        return;
                //    }
                //}

                if (e.KeyCode == Keys.Insert && dgvItem.CurrentCell.ColumnIndex == 4)
                {
                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[4].Value))
                    {
                        if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='3.1.11'") == "TRUE")
                        {
                            cmbUnit.Items.Clear();
                            txtMukul.Text = "";
                            pnlMamata.Visible = true;
                            pnlMamata.BringToFront();
                            this.pnlMamata.Location = new System.Drawing.Point(297, (32 + ((dgvItem.CurrentRow.Index + 1) * 14)));
                            if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value))
                            {
                                lblPartha.Text = dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[1].Value + " " + dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[2].Value.ToString() + " =";

                                DataTable dtunit = edpcom.GetDatatable("select distinct u.udesc,u.ucode from unit u,iglmst i,UnitSeriesMaster s where i.ficode=u.ficode and i.gcode=u.gcode AND u.ucode=s.ucode  and i.ficode=s.ficode and i.gcode=s.gcode and i.Series_ID=s.sm_id and i.pcode=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value) + " AND i.Series_ID=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[10].Value) + " and u.ucode not in( " + dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[9].Value + ") ");
                                if (dtunit.Rows.Count > 0)
                                {
                                    for (int a = 0; a < dtunit.Rows.Count; a++)
                                    {
                                        cmbUnit.Items.Add(dtunit.Rows[a][0].ToString().Trim());
                                        // cmbFromPrint.Items.Add(dtunit.Rows[a][0].ToString().Trim());

                                    }
                                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[41].Value))
                                    {
                                        for (int q = 0; q < dtunit.Rows.Count; q++)
                                        {
                                            if (Convert.ToInt32(dtunit.Rows[q][1]) == Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[41].Value))
                                            {
                                                cmbUnit.SelectedIndex = Convert.ToInt32(q);
                                                //if(Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[42].Value))
                                                //    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[41].Value=
                                            }
                                        }
                                    }
                                    else
                                        cmbUnit.SelectedIndex = 0;
                                    //DataTable dtunit=edpcom.GetDatatable ("select distinct U.UDESC,U.ucode from iglmst I,UNIT U where I.FICODE=U.FICODE AND I.GCODE=U.GCODE AND I.UCODE=U.UCODE AND  I.FICODE='" + EDPComm.CurrentFicode + "' AND I.GCODE='" + edpcom.PCURRENT_GCODE + "' and I.pcode=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value) + "");
                                    //lblBaseUnit.Text = dtunit.Rows[0][0].ToString();
                                    //int ufrom = Convert.ToInt32(edpcom.GetresultS(" select distinct ucode from unit where udesc='" + dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[2].Value + "' and  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'"));                               
                                    //txtStock.Text = edpcom.GetresultS(" select distinct Conv_Fig from UnitRelationMaster  where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode= " + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[10].Value) + " and unitf=" + ufrom + " and unitt=" + Convert.ToInt32(dtunit.Rows[0][1].ToString()) + "");
                                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[38].Value))
                                        txtMukul.Text = dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[38].Value.ToString();
                                    txtMukul.Focus();
                                }
                                //string baseUnit = edpcom.GetresultS("select distinct U.UDESC from iglmst I,UNIT U where I.FICODE=U.FICODE AND I.GCODE=U.GCODE AND I.UCODE=U.UCODE AND  I.FICODE='" + EDPComm.CurrentFicode + "' AND I.GCODE='" + edpcom.PCURRENT_GCODE + "' and I.pcode=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value) + ""));
                                //if (baseUnit != null)
                                //    lblMadan.Text = baseUnit;

                            }
                            else
                            {
                                EDPMessage.Show("Please Input Rate", "Information");
                                return;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void cmbRefOrd_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (SBType == "SI" || SBType == "STKOUT")
                {                    
                    string st = "";
                    st = " SELECT DISTINCT ID.USER_VCH [USER VCH],ID.VOUCHER [VCH CODE],ID.VCH_DATE [VCH DATE] FROM IDATA ID,itran it,ConsumeProduct C WHERE  ID.FICODE='" + edpcom.CurrentFicode + "' AND " +
                      " ID.GCODE='" + edpcom.PCURRENT_GCODE + "' AND ID.T_ENTRY='OS' AND ID.Party_code=" + PartyCode + " and it.SISTATUS='RUNNING' AND ID.FICODE=it.FICODE AND ID.GCODE=it.GCODE AND ID.voucher=it.voucher and ID.t_entry=it.t_entry AND ID.OrderType='P'" +
                      " AND C.FICODE=ID.FICODE AND C.GCODE=ID.GCODE AND C.VOUCHER=ID.VOUCHER AND C.T_ENTRY='OS'";
                    edpcon.Open();
                    cmbRefOrd.CommandString = st;
                    cmbRefOrd.Heading = "Select Voucher";
                    cmbRefOrd.Connection = edpcon.mycon;
                    cmbRefOrd.ReturnIndex = 1;
                    edpcon.Close();
                }
            }
            catch { edpcon.Close(); }
        }

        private void cmbRefOrd_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Pcode_sl = null;
            try
            {
                if (cmbRefOrd.ReturnValue != "")
                {
                    Pcode_sl = Convert.ToString(cmbRefOrd.ReturnValue);

                    edpcon.Open();
                    string PC = Getresult1("SELECT ReffPartyCode FROM IDATA WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND T_ENTRY='OS' AND VOUCHER=" + Pcode_sl + "");
                    if (PC != "")
                        ReffPartyCode = Convert.ToInt32(PC);
                    cmbReffParty.Text = Getresult1("SELECT LDESC FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND GLCODE=" + ReffPartyCode + "");
                    edpcon.Close();


                    //RefOrderForStockIn();
                    if ((Flag_Printing || Flag_Deying) && (SBType == "SI" || SBType == "STKOUT"))
                    {
                        string str = "";
                        //str = " select distinct ig.pdesc,i.RefQty,u.udesc,i.RefPCODE,i.RefUCODE,i.RefQty from iglmst ig,unit u,itran i where ig.ficode=i.ficode and ig.gcode=i.gcode and ig.pcode=i.RefPCODE and u.ficode=i.ficode  and u.gcode=i.gcode and u.ucode=i.RefUCODE " +
                        //" and i.ficode='" + edpcom.CurrentFicode + "' and i.gcode='" + edpcom.PCURRENT_GCODE + "' and i.voucher=" + Pcode_sl + " and i.t_entry='OS'";
                        if (Flag_Printing)
                        {
                            str = "SELECT Distinct IG.PDESC,IG.PCODE,U.UDESC,U.UCODE,US.SM_NAME,US.SM_ID FROM IGLMST IG,ConsumeProduct CP,UNIT U,UnitSeriesMaster US" +
                            " WHERE CP.FICODE='" + edpcom.CurrentFicode + "' AND CP.GCODE='" + edpcom.PCURRENT_GCODE + "' AND CP.T_ENTRY='OS' AND CP.VOUCHER=" + Convert.ToInt32(Pcode_sl) + " AND" +
                            " CP.FICODE=IG.FICODE AND CP.GCODE=IG.GCODE AND CP.PCODE=IG.PCODE AND IG.SERVICE='0' AND" +
                            " IG.FICODE=U.FICODE AND IG.GCODE=U.GCODE AND IG.UCODE=U.UCODE AND" +
                            " IG.FICODE=US.FICODE AND IG.GCODE=US.GCODE AND IG.Series_ID=US.SM_ID AND IG.UCODE=US.UCODE";
                        }
                        if (Flag_Deying)
                        {
                            str = "SELECT Distinct IG.PDESC,IG.PCODE,U.UDESC,U.UCODE,null,0 FROM IGLMST IG,ConsumeProduct CP,UNIT U" +
                           " WHERE CP.FICODE='" + edpcom.CurrentFicode + "' AND CP.GCODE='" + edpcom.PCURRENT_GCODE + "' AND CP.T_ENTRY='OS' AND CP.VOUCHER=" + Convert.ToInt32(Pcode_sl) + " AND" +
                           " CP.FICODE=IG.FICODE AND CP.GCODE=IG.GCODE AND CP.PCODE=IG.PCODE AND IG.SERVICE='0' AND" +
                           " IG.FICODE=U.FICODE AND IG.GCODE=U.GCODE AND IG.UCODE=U.UCODE";// AND" +
                           //" IG.FICODE=US.FICODE AND IG.GCODE=US.GCODE AND IG.Series_ID=US.SM_ID AND IG.UCODE=US.UCODE";
                        }
                        DataTable dtret = edpcom.GetDatatable(str);
                        if (dtret.Rows.Count > 0)
                        {
                            if (dgvItem.Rows.Count > 0)
                                dgvItem.Rows.Clear();
                            for (int s = 0; s < dtret.Rows.Count; s++)
                            {
                                if (dgvItem.Rows.Count == 1 && dgvItem.Rows[0].Cells[0].Value == null)
                                {
                                }
                                else
                                    dgvItem.Rows.Add();
                                dgvItem.Rows[s].Cells[0].Value = dtret.Rows[s][0];
                                dgvItem.Rows[s].Cells[7].Value = dtret.Rows[s][1];
                                dgvItem.Rows[s].Cells[2].Value = dtret.Rows[s][2];
                                dgvItem.Rows[s].Cells[9].Value = dtret.Rows[s][3];
                                dgvItem.Rows[s].Cells[3].Value = dtret.Rows[s][4];
                                dgvItem.Rows[s].Cells[10].Value = dtret.Rows[s][5];
                                dgvItem.Rows[s].Cells[4].Value = 0;
                                dgvItem.Rows[s].Cells[6].Value = 0;
                                


                                // dgvFGItem.Rows[dgvFGItem.Rows.Count - 1].Cells[3].Value = edpcom.GetresultS("select distinct SM_NAME from UnitSeriesMaster where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and SM_ID="+dtret.Rows[s][5]+"");
                                
                                //dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[9].Value = dtret.Rows[s][4];
                                // dgvFGItem.Rows[dgvFGItem.Rows.Count - 1].Cells[7].Value = dtret.Rows[s][5];
                                //dgvItem.Rows[dgvItem.Rows.Count - 1].Cells[8].Value = dtret.Rows[s][5];
                            }
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch { }
        }

        private void fillSaleInvoice(int finPcode, int vouNo, int inx)
        {
            if (SBType == "SALES")
            {
                common.ClearDataTable(ds.Tables["QTy"]);
                cmd = new SqlCommand("select rw.Raw_PCODE,rw.QTY,rw.UCODE,rw.USeries,rw.RATE,rw.Dis_Amt,rw.Amt,rw.BASEQTY,rw.Finish_PCODE,rw.Iteam_No,rw.Spoil_PER,rw.paper_side,rw.RatingQty,rw.Volume,rw.PText from RawMeterialDetails rw where rw.FICODE='" + EDPComm.CurrentFicode + "' AND rw.GCODE='" + edpcom.PCURRENT_GCODE + "'and rw.voucher=" + vouNo + " and rw.Finish_PCODE=" + finPcode + " ", edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "QTy");
                DataTable dt = new DataTable();
                dt.Columns.Clear();
                dt.Columns.Add("Item", typeof(string));
                dt.Columns.Add("qty", typeof(string));
                dt.Columns.Add("unite", typeof(string));
                dt.Columns.Add("series", typeof(string));
                dt.Columns.Add("rate", typeof(string));
                dt.Columns.Add("disamt", typeof(string));
                dt.Columns.Add("amount", typeof(string));
                dt.Columns.Add("pcode", typeof(string));
                dt.Columns.Add("baseqty", typeof(string));
                dt.Columns.Add("baseucode", typeof(string));
                dt.Columns.Add("Sesiescode", typeof(string));
                dt.Columns.Add("Fpcode", typeof(string));
                dt.Columns.Add("itemno", typeof(string));
                dt.Columns.Add("spoilpre", typeof(string));
                dt.Columns.Add("pside", typeof(string));
                dt.Columns.Add("ratingQty", typeof(string));
                dt.Columns.Add("Volume", typeof(string));
                dt.Columns.Add("Text", typeof(string));
                int index = inx;
                for (int j = 0; j <= ds.Tables["QTy"].Rows.Count - 1; j++)
                {
                    common.ClearDataTable(ds.Tables["Item"]);
                    cmd = new SqlCommand("SELECT pdesc,pcode FROM iglmst WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' AND pcode='" + ds.Tables["QTy"].Rows[j][0] + "'", edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Item");

                    common.ClearDataTable(ds.Tables["Units"]);
                    cmd = new SqlCommand("SELECT udesc,ucode from unit WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and ucode='" + ds.Tables["QTy"].Rows[j][2] + "'", edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Units");

                    common.ClearDataTable(ds.Tables["Serise"]);
                    cmd = new SqlCommand("SELECT SM_Name,SM_ID from UnitSeriesMaster WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and SM_ID='" + ds.Tables["QTy"].Rows[j][3] + "'", edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Serise");
                    int count = dt.Rows.Count;
                    dt.Rows.Add();

                    if (ds.Tables["Item"].Rows.Count > 0)
                        dt.Rows[count][0] = ds.Tables["Item"].Rows[0][0].ToString();
                    dt.Rows[count][1] = ds.Tables["QTy"].Rows[j][1].ToString();
                    if (ds.Tables["Units"].Rows.Count > 0)
                        dt.Rows[count][2] = ds.Tables["Units"].Rows[0][0].ToString();
                    if (ds.Tables["Serise"].Rows.Count > 0)
                        dt.Rows[count][3] = ds.Tables["Serise"].Rows[0][0].ToString();
                    dt.Rows[count][4] = ds.Tables["QTy"].Rows[j][4].ToString();
                    dt.Rows[count][5] = ds.Tables["QTy"].Rows[j][5].ToString();
                    dt.Rows[count][6] = ds.Tables["QTy"].Rows[j][6].ToString();
                    dt.Rows[count][7] = ds.Tables["QTy"].Rows[j][0].ToString();
                    dt.Rows[count][8] = ds.Tables["QTy"].Rows[j][7].ToString();
                    dt.Rows[count][9] = ds.Tables["QTy"].Rows[j][2].ToString();
                    dt.Rows[count][10] = ds.Tables["QTy"].Rows[j][3].ToString();
                    dt.Rows[count][11] = ds.Tables["QTy"].Rows[j][8].ToString();
                    dt.Rows[count][12] = ds.Tables["QTy"].Rows[j][9].ToString();
                    dt.Rows[count][13] = ds.Tables["QTy"].Rows[j][10].ToString();
                    dt.Rows[count][14] = ds.Tables["QTy"].Rows[j][11].ToString();
                    dt.Rows[count][15] = ds.Tables["QTy"].Rows[j][12].ToString();
                    dt.Rows[count][16] = ds.Tables["QTy"].Rows[j][13].ToString();
                    dt.Rows[count][17] = ds.Tables["QTy"].Rows[j][14].ToString();
                }
                common.HTAddress[index] = dt;
                index++;
            }
        }

        private void dgvAddless_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAddless.CurrentCell.ColumnIndex == 1)
                {
                    ADLPER = 0; ADLVAL = 0;
                    if (Information.IsNothing(dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[dgvAddless.CurrentCell.ColumnIndex].Value) == false)
                    {
                        if (Information.IsNumeric(dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[dgvAddless.CurrentCell.ColumnIndex].Value) == true)
                        {
                            ADLPER = Convert.ToDouble(dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[dgvAddless.CurrentCell.ColumnIndex].Value);
                        }
                        else
                        {
                            EDPMessageBox.EDPMessage.Show("Value should be numeric.");
                            return;
                        }
                    }
                }

                if (dgvAddless.CurrentCell.ColumnIndex == 2)
                {
                    double VAL = 0;
                    double TT = 0;
                    TotalAmt = 0;
                    for (int i = 0; i <= dgvItem.RowCount - 1; i++)
                        TotalAmt = TotalAmt + Convert.ToDouble(dgvItem.Rows[i].Cells[6].Value);

                    for (int i = 0; i <= dgvAddless.RowCount - 1; i++)
                        VAL = VAL + Convert.ToDouble(dgvAddless.Rows[i].Cells[3].Value);
                    TT = TotalAmt + VAL;

                    if (Information.IsNothing(dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[5].Value) == true)
                    {
                        ADLVAL = (TotalAmt * ADLPER) / 100;
                        if (dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[2].Value.ToString() == "LESS")
                            ADLVAL = ADLVAL * (-1);
                        if (ADLVAL != 0)
                            dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[3].Value = ADLVAL;
                        if (dgvAddless.CurrentRow.Index == dgvAddless.Rows.Count)
                            TT = TT + Convert.ToDouble(dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[3].Value);
                    }
                    else
                    {
                        if ((dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[5].Value.ToString() == "30") || (dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[5].Value.ToString() == "31"))
                        {
                            if (!MultiSalePurAC)
                            {
                                ADLVAL = (TotalAmt * ADLPER) / 100;
                                if (dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[2].Value.ToString() == "LESS")
                                    ADLVAL = ADLVAL * (-1);
                                if (ADLVAL != 0)
                                    dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[3].Value = ADLVAL;
                                if (dgvAddless.CurrentRow.Index == dgvAddless.Rows.Count)
                                    TT = TT + Convert.ToDouble(dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[3].Value);
                            }
                        }
                        else
                        {
                            ADLVAL = (TotalAmt * ADLPER) / 100;
                            if (dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[2].Value.ToString() == "LESS")
                                ADLVAL = ADLVAL * (-1);
                            if (ADLVAL != 0)
                                dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[3].Value = ADLVAL;
                            if (dgvAddless.CurrentRow.Index == dgvAddless.Rows.Count)
                                TT = TT + Convert.ToDouble(dgvAddless.Rows[dgvAddless.CurrentRow.Index].Cells[3].Value);
                        }
                    }
                    txtAmt.Text = TT.ToString(common.SetDecimalPlace());
                }
            }
            catch { }
        }

        private void btnSudip_Click(object sender, EventArgs e)
        {
            if (txtMukul.Text != "")
            {
                if (btnSudip.Text == "OK")
                {
                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[38].Value = txtMukul.Text;
                    // dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[9].Value = edpcom.GetresultS("select distinct ucode from unit where udesc='" + cmbUnit.Text.Trim() + "' and  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'");
                    //  string aa = dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[9].Value.ToString();
                    //  dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[42].Value = Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[1].Value) * Convert.ToDecimal(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[38].Value);
                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[42].Value = txtMukul.Text;
                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[40].Value = cmbUnit.Text.Trim();
                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[41].Value = edpcom.GetresultS("select distinct ucode from unit where udesc='" + cmbUnit.Text.Trim() + "' and  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'");

                    DataTable dtunit = edpcom.GetDatatable("select distinct u.udesc,u.ucode from unit u,iglmst i where i.ficode=u.ficode and i.gcode=u.gcode and u.ucode=i.ucode and i.pcode=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value) + " ");
                    if (dtunit.Rows.Count > 0)
                    {
                        // int s =Convert.ToInt32( edpcom.GetresultS(" SELECT DISTINCT UCODE FROM IGLMST WHERE FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' "));
                        if (Convert.ToInt32(dtunit.Rows[0][1].ToString()) != Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[41].Value))
                        {
                            cmbUnit.Visible = false;
                            cmbUnit.SendToBack();
                            lblBaseUnit.BringToFront();
                            lblBaseUnit.Visible = true;
                            txtMukul.Text = "";
                            lblPartha.Text = "1 " + cmbUnit.Text.Trim() + "=";
                            lblBaseUnit.Text = dtunit.Rows[0][0].ToString();
                            if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[45].Value))
                                txtMukul.Text = dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[45].Value.ToString();
                            txtMukul.Focus();
                            btnSudip.Text = "OK.";
                        }
                        //else if (Flag_Deying)
                        //{
                        //    cmbUnit.Visible = false;
                        //    cmbUnit.SendToBack();
                        //    lblBaseUnit.BringToFront();
                        //    lblBaseUnit.Visible = true;

                        //    //if(Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[42].Value==true)
                        //    //dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[42].Value


                        //    txtMukul.Text = "";
                        //    lblPartha.Text = "1 " + cmbUnit.Text.Trim() + "=";
                        //    lblBaseUnit.Text = dtunit.Rows[0][0].ToString();
                        //    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[45].Value))
                        //        txtMukul.Text = dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[45].Value.ToString();
                        //    txtMukul.Focus();
                        //    btnSudip.Text = "OK.";
                        //}
                        else
                        {
                            pnlMamata.Visible = false;
                            pnlMamata.SendToBack();
                            dgvItem.ReadOnly = false;
                            dgvItem.Columns[0].ReadOnly = true;
                            dgvItem.CurrentCell = dgvItem[4, dgvItem.CurrentCell.RowIndex];
                            dgvItem.Focus();
                        }
                    }
                }
                else
                {
                    //dgvItem_CellEndEdit(sender, new DataGridViewCellEventArgs(4, dgvItem.CurrentCell.RowIndex));
                    //dgvItem_CellLeave(sender, new DataGridViewCellEventArgs(4, dgvItem.CurrentCell.RowIndex));

                    //if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[45].Value))
                    //    txtMukul.Text = dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[45].Value.ToString();
                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[45].Value = txtMukul.Text;
                    btnSudip.Text = "OK";
                    cmbUnit.Visible = true;
                    cmbUnit.BringToFront();
                    lblBaseUnit.SendToBack();
                    lblBaseUnit.Visible = false;
                    pnlMamata.Visible = false;
                    pnlMamata.SendToBack();
                    dgvItem.ReadOnly = false;
                    dgvItem.Columns[0].ReadOnly = true;
                    dgvItem.CurrentCell = dgvItem[4, dgvItem.CurrentCell.RowIndex];
                    dgvItem.Focus();
                }
            }
            else
            {
                EDPMessage.Show("Please input conversion value", "Information");
                return;
            }
        }

        private void txtMukul_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSudip.Focus();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtvoucher.Text = listBox1.SelectedItem.ToString();
                txtVoucherChallan.Text = listBox1.SelectedItem.ToString();
                string[] ssa = txtvoucher.Text.Split('/');
                int VNo = Convert.ToInt32(ssa[2]) - 1;

                edpcon.Open();
                SqlCommand cmd = new SqlCommand("Update DOCGEN Set State='RUNNING' Where Ficode='" + edpcom.CurrentFicode + "' And gcode='" + edpcom.PCURRENT_GCODE + "' And T_Entry='" + Tentry + "' And DESCCODE=" + Desccode + " And VOUCHERNO=" + VNo + "", edpcon.mycon);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("Update DOCGEN Set State='' Where Ficode='" + edpcom.CurrentFicode + "' And gcode='" + edpcom.PCURRENT_GCODE + "' And T_Entry='" + Tentry + "' And DESCCODE=" + Desccode + " And VOUCHERNO<>" + VNo + "", edpcon.mycon);
                cmd.ExecuteNonQuery();
                edpcon.Close();
                listBox1.Visible = false;
            }
            catch { }
        }

        private void btnDocNo_Click(object sender, EventArgs e)
        {
            try
            {
                Hashtable ht = new Hashtable();
                listBox1.Items.Clear();
                ht = edpcom.GetNumberOfDocNumber(Desccode, Tentry);
                for (int i = 0; i <= ht.Count - 1; i++)
                {
                    listBox1.Items.Add((string)ht[i]);
                }
                listBox1.Visible = true;
            }
            catch { }
        }

        private void txtvoucher_Leave(object sender, EventArgs e)
        {
            //if (SBType == "SALES" || SBType == "PUR")
            //    txtVoucherChallan.Text = txtvoucher.Text;
            if (SBType == "SALES" || SBType == "PUR")
            {
                txtVoucherChallan.Text = txtvoucher.Text;
                string ss = edpcom.GetresultS(" SELECT DISTINCT USER_VCH FROM IDATA WHERE Ficode='" + edpcom.CurrentFicode + "' And gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry='" + Tentry + "'  And USER_VCH='" + txtvoucher.Text.Trim() + "'");
                if (ss != null)
                {
                    EDPMessage.Show("This voucher already exist.", "Information");
                    txtvoucher.Focus();
                    return;
                }
            }
        }

        private void txtRatingQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool F1 = false;
                if (Information.IsNothing(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[44].Value) == false)
                    F1 = Convert.ToBoolean(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[44].Value);
                if (F1)
                    txtVolume.Focus();
                else
                {
                    double PRate = 0, PQty = 0, PAMT = 0, RatingQty = 0;

                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[4].Value) == true)
                        PRate = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[4].Value);
                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[8].Value) == true)
                        PQty = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[8].Value);
                    if (Information.IsNumeric(txtRatingQty.Text.Trim()) == true)
                        RatingQty = Convert.ToDouble(txtRatingQty.Text.Trim());

                    PAMT = (PRate * PQty) / RatingQty;

                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[6].Value = PAMT;
                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[43].Value = txtRatingQty.Text;
                    PanelRate.Visible = false;

                    dgvItem.Focus();
                    dgvItem.ClearSelection();
                    if (dgvItem.Columns[14].Visible == true)
                    {
                        dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[14].Selected = true;
                        dgvItem.CurrentCell = dgvItem[14, dgvItem.CurrentCell.RowIndex];
                    }
                    return;

                }
            }

        }

        private void txtVolume_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    double PRate = 0, PQty = 0, PAMT = 0, PVolume = 0, RatingQty = 0;

                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[4].Value) == true)
                        PRate = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[4].Value);
                    if (Information.IsNumeric(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[8].Value) == true)
                        PQty = Convert.ToDouble(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[8].Value);                    
                    if (Information.IsNumeric(txtRatingQty.Text.Trim()) == true)
                        RatingQty = Convert.ToDouble(txtRatingQty.Text.Trim());
                    //if (Information.IsNumeric(txtVolume.Text.Trim()) == true)
                    //    PVolume = Math.Round(Convert.ToDouble(txtVolume.Text.Trim()));

                    ////////////////////////////////////////
                    if (Information.IsNumeric(txtVolume.Text.Trim()) == true)
                        PVolume = Convert.ToDouble(txtVolume.Text.Trim());
                    string[] a = new string[] { };
                    a = txtVolume.Text.Trim().Split('.');
                    if (a.Length > 1)
                    {
                        if (Convert.ToDouble(a[1]) == 5)                        
                            PVolume = Math.Round(PVolume) + 1;
                        
                        else                       
                            PVolume = Math.Round(PVolume);                        
                    }
                    else
                        PVolume = Math.Round(PVolume);

                    //decimal RAmt = Math.Round(Convert.ToDecimal(pa));
                    //decimal BalAmt = Convert.ToDecimal(pa) - RAmt;
                    //double amt = Convert.ToDouble(BalAmt);
                    //if (PVolume == Convert.ToDecimal(.5))
                    //{
                    //    //pa = pa + (1) * BalAmt;
                    //    BalAmt = Convert.ToDecimal(.5);
                    //}
                    //else if (BalAmt >= 0)
                    //{
                    //    pa = pa - BalAmt;
                    //    BalAmt = BalAmt * (-1);
                    //}

                    //else
                    //{
                    //    pa = pa + (-1) * BalAmt;
                    //    BalAmt = BalAmt * (-1);
                    //}
                    ////////////////////////////////////////


                    PAMT = (PRate * PQty * PVolume) / RatingQty;

                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[6].Value = PAMT;
                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[14].Value = txtVolume.Text;
                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[43].Value = txtRatingQty.Text;
                    PanelRate.Visible = false;

                    dgvItem.Focus();
                    dgvItem.ClearSelection();
                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[15].Selected = true;
                    dgvItem.CurrentCell = dgvItem[15, dgvItem.CurrentCell.RowIndex];

                }
            }
            catch { }
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[38].Value = txtMukul.Text;
            txtMukul.Text = "";
            try
            {
                // dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[9].Value = edpcom.GetresultS("select distinct ucode from unit where udesc='" + cmbUnit.Text.Trim() + "' and  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'");
                // string ssq = lblPartha.Text.Substring(2);
                int ufrom = Convert.ToInt32(edpcom.GetresultS(" select distinct ucode from unit where udesc='" + dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[2].Value + "' and  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'"));
                int uto = Convert.ToInt32(edpcom.GetresultS("select distinct ucode from unit where udesc='" + cmbUnit.SelectedItem.ToString().Trim() + "' and  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'"));
                // txtMukul.Text= edpcom.GetDatatable("select distinct u.udesc,u.ucode from unit u,iglmst i,UnitSeriesMaster s where i.ficode=u.ficode and i.gcode=u.gcode AND u.ucode=s.ucode  and i.ficode=s.ficode and i.gcode=s.gcode and i.Series_ID=s.sm_id and i.pcode=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value) + " AND i.Series_ID=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[10].Value) + "");
                txtMukul.Text = edpcom.GetresultS(" select distinct Conv_Fig from UnitRelationMaster  where FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and pcode= " + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[7].Value) + " and sm_id=" + Convert.ToInt32(dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[10].Value) + " and unitf=" + ufrom + " and unitt=" + uto + "");
            }
            catch { }
        }

        private void cmbReffParty_DropDown(object sender, EventArgs e)
        {
            //panel5.Visible = true;
            //panel5.Top = 75;
            //panel5.Left = 642;
            //txtReffAddress.Focus();

            try
            {
                if (PartyCode == 0)
                {
                    EDPMessage.Show("Please select a party at first.", "Information");
                    return;
                }
                string str = "";
                if ((SBType == "SALES") || (SBType == "CHLN") || (SBType == "SRETURN") || (SBType == "OS"))
                {
                    str = "SELECT LDESC,GLCODE,LALIAS FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND SGROUP=12 AND GLCODE<>" + PartyCode + "";
                    PartyType = "SD";
                }
                else if (SBType == "STKOUT" || SBType == "SI")
                {
                    str = "SELECT LDESC,GLCODE,LALIAS FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND SGROUP IN(5,12) AND GLCODE<>" + PartyCode + "";
                }
                else
                {
                    str = "SELECT LDESC,GLCODE,LALIAS FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND SGROUP=5 AND GLCODE<>" + PartyCode + "";
                    PartyType = "SC";
                }
                Finance.frmLedgerOpen AM = new Finance.frmLedgerOpen();
                edpcon.Open();
                common.LOV("SELECT PARTY NAME", str, textBox1, 1, AM, true, "Click here to create new party");
                //cmbReffParty.Text = textBox1.Text;
                if (textBox1.Text.Trim() != "")
                    cmbReffParty.Text = textBox1.Text;
                else
                    cmbReffParty.Text = EDPCommon.LOVReturnText;
                EDPCommon.LOVReturnText = "";
                ReffPartyCode = Convert.ToInt32(common.LovReturnValue);
                if (SBType == "STKOUT" || SBType == "SI")
                {
                    int SG = 0;
                    SG = Convert.ToInt32(Getresult1("SELECT SGROUP FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MTYPE='L' AND GLCODE=" + ReffPartyCode + ""));
                    if (SG == 5)
                        PartyType = "SC";
                    else if (SG == 12)
                        PartyType = "SD";
                }
            }
            catch { }
        }

        private void cmbReffParty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                cmbPartyName.PopUp(sender, new EventArgs());
        }


        private void txtMukul_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cmbUnit.Visible == true)
                cmbUnit.Focus();
            if (e.KeyCode == Keys.Enter && cmbUnit.Visible == false)
                btnSudip.Focus();
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSudip.Focus();
        }

        private void btnStockTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                string OrdUserVch = "", PN = "";
                int OrdVch = 0, PC = 0;
                if (action == "MODIFY" || action == "VIEW")
                {
                    OrdUserVch = txtvoucher.Text;
                    OrdVch = vno;
                    PN = cmbPartyName.Text;
                    PC = PartyCode;
                    frmStockTransfer ST = new frmStockTransfer();
                    ST.StockTransferDetails(OrdUserVch, OrdVch, PN, PC);
                    ST.ShowDialog();
                }
            }
            catch { }
        }

        private void frmOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            edpcom.UpdateAccordFourLog(this, false);
            edpcom.saveFormPosition(this.Name, this.Location);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    dgvItem_CellDoubleClick(sender, new DataGridViewCellEventArgs(0, 0));
                    dgvItem.Focus();
                    dgvItem.ClearSelection();
                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[1].Selected = true;
                    dgvItem.CurrentCell = dgvItem[1, dgvItem.CurrentCell.RowIndex];
                    textBox1.Text = "";
                }
                else
                {
                    dgvItem.Focus();
                    dgvItem.ClearSelection();
                    dgvItem.Rows[dgvItem.CurrentCell.RowIndex].Cells[0].Selected = true;
                    dgvItem.CurrentCell = dgvItem[0, dgvItem.CurrentCell.RowIndex];
                    textBox1.Text = "";
                }
            }
            catch { }
        }

        private void dgvStockTransfer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string OrdUserVch = "", PN = "";
                int OrdVch = 0, PC = 0;
                if (action == "ADD")
                {
                    OrdUserVch = dgvStockTransfer.Rows[dgvStockTransfer.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    OrdVch = Convert.ToInt32(dgvStockTransfer.Rows[dgvStockTransfer.CurrentCell.RowIndex].Cells[1].Value);
                    PN = cmbPartyName.Text;
                    PC = PartyCode;
                    frmStockTransfer ST = new frmStockTransfer();
                    ST.StockTransferDetails(OrdUserVch, OrdVch, PN, PC);
                    ST.ShowDialog();
                }
            }
            catch { }
        }

        private void dgvItem_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool PCon = false;
                if (dgvItem.Rows[e.RowIndex].Cells[45] != null)
                    if (dgvItem.Rows[e.RowIndex].Cells[45].Value != "")
                        if (Convert.ToString(dgvItem.Rows[e.RowIndex].Cells[45].Value) != "")
                            PCon = Convert.ToBoolean(dgvItem.Rows[e.RowIndex].Cells[45].Value);
                //if ((Flag_Printing) && (dgvItem.CurrentCell.RowIndex == 0) && (dgvItem.CurrentCell.ColumnIndex == 43) && (RCOUNT == 0) && (OrderType=='P'))
                if ((Flag_Printing) && (dgvItem.CurrentCell.ColumnIndex == 37) && (PCon) && (OrderType == 'P') && (SBType=="OS"))
                {
                    double vol = 0, BQty = 0, NOP = 0;// PPF = 0;
                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[35].Value) == true)
                        vol = Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[35].Value);
                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[32].Value) == true)
                        BQty = Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[32].Value);
                    //if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[37].Value) == true)
                    //    PPF = Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[37].Value);
                    NOP = vol * BQty;
                    //RCOUNT = 1;
                    frmRawMeterialDetails rm = new frmRawMeterialDetails();
                    rm.RawDataInfo(e.RowIndex, Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[31].Value), NOP, Convert.ToString(dgvItem.Rows[e.RowIndex].Cells[14].Value), Convert.ToString(dgvItem.Rows[e.RowIndex].Cells[15].Value));
                    rm.ShowDialog();
                    try
                    {
                        if (common.HTfrmLogRet.Count > 0)
                        {
                            common.HTAddress.Remove(e.RowIndex);
                            DataTable dtnew = new DataTable();
                            //  common.HTAddress.Add(e.RowIndex, common.dtCP1);
                            dtnew = (DataTable)common.HTfrmLogRet[0];
                            if (dtnew.Rows.Count > 0)
                                common.HTAddress.Add(e.RowIndex, dtnew);
                        }
                    }
                    catch { }
                }
                if ((Flag_Deying) && (dgvItem.CurrentCell.ColumnIndex == 30) && (PCon) && (SBType=="OS"))
                {
                    double vol = 1, BQty = 0, NOP = 0;// PPF = 0;
                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[35].Value) == true)
                        vol = Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[35].Value);
                    if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[32].Value) == true)
                        BQty = Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[32].Value);
                    //if (Information.IsNumeric(dgvItem.Rows[e.RowIndex].Cells[37].Value) == true)
                    //    PPF = Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[37].Value);
                    NOP = vol * BQty;
                    //RCOUNT = 1;
                    frmRawMeterialDetails rm = new frmRawMeterialDetails();
                    rm.RawDataInfo(e.RowIndex, Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[31].Value), NOP, "1", Convert.ToString(dgvItem.Rows[e.RowIndex].Cells[15].Value));
                    rm.ShowDialog();
                    try
                    {
                        if (common.HTfrmLogRet.Count > 0)
                        {
                            common.HTAddress.Remove(e.RowIndex);
                            DataTable dtnew = new DataTable();
                            //  common.HTAddress.Add(e.RowIndex, common.dtCP1);
                            dtnew = (DataTable)common.HTfrmLogRet[0];
                            if (dtnew.Rows.Count > 0)
                                common.HTAddress.Add(e.RowIndex, dtnew);
                        }
                    }
                    catch { }
                }                
            }
            catch{}
        }

        private void txtTotalAmt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAmt.Text = txtTotalAmt.Text;
                    PanelTotalAmt.Visible = false;
                }
            }
            catch { }
        }

    }
}