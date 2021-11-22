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
    public partial class frmSalesQury : EDPComponent.FormBase
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();       
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();

        DataRow Dr;
        DataTable DtMonth = new DataTable("DM");       
        DataRow Drm;

        string em;
        public string stds, stde;

        public frmSalesQury()
        {
            InitializeComponent();
        }

        private void frmSalesQury_Load(object sender, EventArgs e)
        {
            try
            {
                this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
                DtMonth.Columns.Clear();
                DataColumn D1 = new DataColumn();
                DataColumn D2 = new DataColumn();
                DataColumn D3 = new DataColumn();
                DataColumn D4 = new DataColumn();
                DataColumn D5 = new DataColumn();

                DtMonth.Columns.Add(D1);
                DtMonth.Columns.Add(D2);
                DtMonth.Columns.Add(D3);
                DtMonth.Columns.Add(D4);
                DtMonth.Columns.Add(D5);
            }
            catch { }
            SalesGridCalculation();
        }

        public void SalesGridCalculation()
        {
            try
            {
                DtMonth.Clear();

                string str = edpcom.CURRCO_SDT.ToShortDateString();
                String yy = str.Substring(str.Length - 4, 4);
                String mm = str.Substring(str.Length - 7, 2);
                String mm1 = mm;
                String dd = str.Substring(str.Length - 10, 2);
                Boolean ch, ch1;
                int nom, pp;
                double SalesAmt=0;
                double TotalAmt = 0;

                nom = Convert.ToInt32(mm1) + 12;
                ch = true;
                ch1 = true;

                for (pp = Convert.ToInt32(mm1); pp < nom; pp++)
                {
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
                    //======================================================================================
                    DateTime stds1 = Convert.ToDateTime(stds);
                    DateTime stde2 = Convert.ToDateTime(stde);

                    string STRVCH = "SELECT SUM(DBAMT) FROM VCHR WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND T_ENTRY='9' AND (VCHDATE BETWEEN '" + EDPComm.getSqlDateStr(stds1) + "' AND '" + EDPComm.getSqlDateStr(stde2) + "')";
                    DataTable dtSales = edpcom.GetDatatable(STRVCH);
                    SalesAmt = 0;
                    Drm = DtMonth.NewRow();
                    if (dtSales.Rows.Count > 0)
                    {
                        if (Information.IsNumeric(dtSales.Rows[0][0]) == true)
                            SalesAmt = Convert.ToDouble(dtSales.Rows[0][0]);
                        TotalAmt = TotalAmt + SalesAmt;
                    }
                    Drm[1] = SalesAmt;
                    Drm[2] = TotalAmt;
                    Drm[3] = stds;
                    Drm[4] = stde;

                    if (mm == "01")
                        Drm[0] = "January                               " + mm + "/" + yy + "";
                    else
                    {
                        if (mm == "02")
                            Drm[0] = "February                             " + mm + "/" + yy + "";
                        else
                        {
                            if (mm == "03")
                                Drm[0] = "March                                 " + mm + "/" + yy + "";
                            else
                            {
                                if (mm == "04")
                                    Drm[0] = "April                                    " + mm + "/" + yy + "";
                                else
                                {
                                    if (mm == "05")
                                        Drm[0] = "May                                     " + mm + "/" + yy + "";
                                    else
                                    {
                                        if (mm == "06")
                                            Drm[0] = "June                                   " + mm + "/" + yy + "";
                                        else
                                        {
                                            if (mm == "07")
                                                Drm[0] = "Jully                                     " + mm + "/" + yy + "";
                                            else
                                            {
                                                if (mm == "08")
                                                    Drm[0] = "August                                " + mm + "/" + yy + "";
                                                else
                                                {
                                                    if (mm == "09")
                                                        Drm[0] = "September                          " + mm + "/" + yy + "";
                                                    else
                                                    {
                                                        if (mm == "10")
                                                            Drm[0] = "October                              " + mm + "/" + yy + "";
                                                        else
                                                        {
                                                            if (mm == "11")
                                                                Drm[0] = "November                           " + mm + "/" + yy + "";
                                                            else
                                                                Drm[0] = "December                           " + mm + "/" + yy + "";
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
                    DtMonth.Rows.Add(Drm);
                }
               
                if (dgvSalesQry1.Rows.Count > 0)
                    dgvSalesQry1.Rows.Clear();
              
                for (int i = 0; i <= DtMonth.Rows.Count - 1; i++)
                {
                    dgvSalesQry1.Rows.Add();
                    dgvSalesQry1.Rows[i].Cells[0].Value = Convert.ToString(DtMonth.Rows[i][0]);
                    dgvSalesQry1.Rows[i].Cells[1].Value = Convert.ToString(DtMonth.Rows[i][1]);
                    dgvSalesQry1.Rows[i].Cells[2].Value = Convert.ToString(DtMonth.Rows[i][2]);
                    dgvSalesQry1.Rows[i].Cells[3].Value = Convert.ToString(DtMonth.Rows[i][3]);
                    dgvSalesQry1.Rows[i].Cells[4].Value = Convert.ToString(DtMonth.Rows[i][4]);
                }
            }
            catch { }          

       
        }

        private void dgvSalesQry1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double CrSalesAmt = 0;
                double DbSalesAmt = 0;
                double TotalSales = 0;

                dgvSalesQry2.Rows.Clear();
                dgvSalesQry3.Rows.Clear();
                common.ClearDataTable(DtMonth);
                DataColumn D1 = new DataColumn();
                DataColumn D2 = new DataColumn();
                DataColumn D3 = new DataColumn();
                DataColumn D4 = new DataColumn();
                DataColumn D5 = new DataColumn();

                DtMonth.Columns.Add(D1);
                DtMonth.Columns.Add(D2);
                DtMonth.Columns.Add(D3);
                DtMonth.Columns.Add(D4);
                DtMonth.Columns.Add(D5);                

                DateTime DDTTS = Convert.ToDateTime(dgvSalesQry1.Rows[dgvSalesQry1.CurrentCell.RowIndex].Cells[3].Value);
                DateTime DDTTE = Convert.ToDateTime(dgvSalesQry1.Rows[dgvSalesQry1.CurrentCell.RowIndex].Cells[4].Value);

                string ss = "SELECT DISTINCT BILLDATE FROM BILL WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND T_ENTRY='9' AND (BILLDATE BETWEEN '" + EDPComm.getSqlDateStr(DDTTS) + "' AND '" + EDPComm.getSqlDateStr(DDTTE) + "')";
                DataTable DT11 = EDPComm.GetDatatable(ss);

                ss = "SELECT V.USER_VCH,V.DBAMT,V.VCHDATE,B.Cash_Check FROM VCHR V,BILL B WHERE V.FICODE='" + edpcom.CurrentFicode + "' AND V.GCODE='" + edpcom.PCURRENT_GCODE + "' AND" +
                " V.T_ENTRY='9' AND (V.VCHDATE BETWEEN '" + EDPComm.getSqlDateStr(DDTTS) + "' AND '" + EDPComm.getSqlDateStr(DDTTE) + "') AND DBAMT<>0 AND B.FICODE=V.FICODE AND" +
                " B.GCODE=V.GCODE AND B.T_ENTRY=V.T_ENTRY AND V.VOUCHER=B.VOUCHER ORDER BY V.VCHDATE";
                DataTable DT22 = EDPComm.GetDatatable(ss);

                
                for (int i = 0; i <= DT11.Rows.Count - 1; i++)
                {
                    CrSalesAmt = 0;
                    DbSalesAmt = 0;
                    TotalSales = 0;
                    Drm = DtMonth.NewRow();
                    DataView dv = new DataView(DT22);
                    dv.RowFilter = "VCHDATE='" + Convert.ToDateTime(DT11.Rows[i][0]) + "' AND Cash_Check=1";
                    for (int j = 0; j <= dv.Count - 1; j++)
                    {
                        if (dv.Count > 0)
                        {
                            if (Information.IsNumeric(dv[j][1]) == true)
                                CrSalesAmt = CrSalesAmt + Convert.ToDouble(dv[j][1]);
                        }
                    }
                    DataView dv1 = new DataView(DT22);
                    dv1.RowFilter = "VCHDATE='" + Convert.ToDateTime(DT11.Rows[i][0]) + "' AND Cash_Check=0";
                    for (int j = 0; j <= dv1.Count - 1; j++)
                    {
                        if (dv1.Count > 0)
                        {
                            if (Information.IsNumeric(dv1[j][1]) == true)
                                DbSalesAmt = DbSalesAmt + Convert.ToDouble(dv1[j][1]);
                        }
                    }
                    TotalSales = CrSalesAmt + DbSalesAmt;
                    

                    Drm[0] = Convert.ToString(DT11.Rows[i][0]);
                    Drm[1] = CrSalesAmt;
                    Drm[2] = DbSalesAmt;
                    Drm[3] = TotalSales;
                    DtMonth.Rows.Add(Drm);
                }
                if (dgvSalesQry2.Rows.Count > 0)
                    dgvSalesQry2.Rows.Clear();

                for (int i = 0; i <= DtMonth.Rows.Count - 1; i++)
                {
                    dgvSalesQry2.Rows.Add();
                    dgvSalesQry2.Rows[i].Cells[0].Value = Convert.ToString(DtMonth.Rows[i][0]);
                    dgvSalesQry2.Rows[i].Cells[1].Value = Convert.ToString(DtMonth.Rows[i][1]);
                    dgvSalesQry2.Rows[i].Cells[2].Value = Convert.ToString(DtMonth.Rows[i][2]);
                    dgvSalesQry2.Rows[i].Cells[3].Value = Convert.ToString(DtMonth.Rows[i][3]);
                    //dgvSalesQry2.Rows[i].Cells[4].Value = Convert.ToString(DtMonth.Rows[i][4]);
                }
            }
            catch { }
        }

        private void dgvSalesQry2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double SalesAmt = 0;                
                double TotalSales = 0;

                common.ClearDataTable(DtMonth);
                DataColumn D1 = new DataColumn();
                DataColumn D2 = new DataColumn();
                DataColumn D3 = new DataColumn();
                DataColumn D4 = new DataColumn();
                DataColumn D5 = new DataColumn();

                DtMonth.Columns.Add(D1);
                DtMonth.Columns.Add(D2);
                DtMonth.Columns.Add(D3);
                DtMonth.Columns.Add(D4);
                DtMonth.Columns.Add(D5);

                DateTime DDTTS = Convert.ToDateTime(dgvSalesQry2.Rows[dgvSalesQry2.CurrentCell.RowIndex].Cells[0].Value);

                string ss = "SELECT G.LDESC,V.USER_VCH,V.DBAMT,V.VCHDATE,B.Cash_Check FROM VCHR V,BILL B,GLMST G WHERE V.FICODE='" + edpcom.CurrentFicode + "' AND V.GCODE='" + edpcom.PCURRENT_GCODE + "' AND" +
                 " V.T_ENTRY='9' AND V.VCHDATE='" + edpcom.getSqlDateStr(DDTTS) + "' AND DBAMT<>0 AND B.FICODE=V.FICODE AND" +
                 " B.GCODE=V.GCODE AND B.T_ENTRY=V.T_ENTRY AND V.VOUCHER=B.VOUCHER AND G.FICODE=B.FICODE AND G.GCODE=B.FICODE AND" +
                 " G.GLCODE=B.PARTYCODE AND G.MTYPE='L'" +
                " UNION SELECT NULL,V.USER_VCH,V.DBAMT,V.VCHDATE,B.Cash_Check FROM VCHR V,BILL B WHERE" +
                " V.FICODE='" + edpcom.CurrentFicode + "' AND V.GCODE='" + edpcom.PCURRENT_GCODE + "' AND V.T_ENTRY='9' AND V.VCHDATE='" + edpcom.getSqlDateStr(DDTTS) + "' AND DBAMT<>0 AND" +
                " B.FICODE=V.FICODE AND B.GCODE=V.GCODE AND B.T_ENTRY=V.T_ENTRY AND V.VOUCHER=B.VOUCHER AND B.PARTYCODE=0 ORDER BY V.VCHDATE";
            
                DataTable DT11 = EDPComm.GetDatatable(ss);

                for (int i = 0; i <= DT11.Rows.Count - 1; i++)
                {
                    Drm = DtMonth.NewRow();
                    Drm[0] = Convert.ToString(DT11.Rows[i][1]);
                    if (Convert.ToBoolean(DT11.Rows[i][4]) == true)
                        Drm[1] = "Cr";
                    else
                        Drm[1] = "Cash";
                    if (Information.IsNothing(DT11.Rows[i][0]) == false)
                        Drm[2] = Convert.ToString(DT11.Rows[i][0]);
                    Drm[3] = Convert.ToDouble(DT11.Rows[i][2]);
                    DtMonth.Rows.Add(Drm);
                }

                if (dgvSalesQry3.Rows.Count > 0)
                    dgvSalesQry3.Rows.Clear();

                for (int i = 0; i <= DtMonth.Rows.Count - 1; i++)
                {
                    dgvSalesQry3.Rows.Add();
                    dgvSalesQry3.Rows[i].Cells[0].Value = Convert.ToString(DtMonth.Rows[i][0]);
                    dgvSalesQry3.Rows[i].Cells[1].Value = Convert.ToString(DtMonth.Rows[i][1]);
                    dgvSalesQry3.Rows[i].Cells[2].Value = Convert.ToString(DtMonth.Rows[i][2]);
                    dgvSalesQry3.Rows[i].Cells[3].Value = Convert.ToString(DtMonth.Rows[i][3]);
                    //dgvSalesQry2.Rows[i].Cells[4].Value = Convert.ToString(DtMonth.Rows[i][4]);
                }
            }
            catch { }
        }
    }
}