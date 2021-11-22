using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.VisualBasic;

namespace MidasReport
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void fill_data(string reportName, DataTable ds1,string CompanyName,string CompanyAddress,string ReportTag,string FromTo,bool showPrintButton,bool showExportButton,double TOT1,double TOT2,double TOT3,double TOT4,double TOT5,double TOT6)
        {
            if (reportName == "TrialBalance1")
            {
                crysRptTrialBalance1 tr1 = new crysRptTrialBalance1();
                tr1.SetDataSource(ds1);
                tr1.SetParameterValue(0, CompanyName);
                tr1.SetParameterValue(1, CompanyAddress);
                tr1.SetParameterValue(2, ReportTag);
                tr1.SetParameterValue(3, FromTo);
                tr1.SetParameterValue(4, TOT1);
                tr1.SetParameterValue(5, TOT2);
                tr1.SetParameterValue(6, TOT3);
                tr1.SetParameterValue(7, TOT4);
                tr1.SetParameterValue(8, TOT5);
                tr1.SetParameterValue(9, TOT6);
                crystalReportViewer1.ShowPrintButton = showPrintButton;
                crystalReportViewer1.ShowExportButton = showExportButton;
                crystalReportViewer1.ReportSource = tr1;
            }
            else if (reportName == "TrialBalance2")
            {
                TrialBalance2 tr2 = new TrialBalance2();
                tr2.SetDataSource(ds1);
                tr2.SetParameterValue(0, CompanyName);
                tr2.SetParameterValue(1, CompanyAddress);
                tr2.SetParameterValue(2, ReportTag);
                tr2.SetParameterValue(3, FromTo);
                tr2.SetParameterValue(4, TOT3);
                tr2.SetParameterValue(5, TOT4);
                tr2.SetParameterValue(6, TOT5);
                tr2.SetParameterValue(7, TOT6);
                crystalReportViewer1.ShowPrintButton = showPrintButton;
                crystalReportViewer1.ShowExportButton = showExportButton;
                crystalReportViewer1.ReportSource = tr2;
            }
            else if (reportName == "TrialBalance3")
            {
                TrialBalance3 tr3 = new TrialBalance3();
                tr3.SetDataSource(ds1);
                tr3.SetParameterValue(0, CompanyName);
                tr3.SetParameterValue(1, CompanyAddress);
                tr3.SetParameterValue(2, ReportTag);
                tr3.SetParameterValue(3, FromTo);
                tr3.SetParameterValue(4, TOT1);
                tr3.SetParameterValue(5, TOT2);
                crystalReportViewer1.ShowPrintButton = showPrintButton;
                crystalReportViewer1.ShowExportButton = showExportButton;
                crystalReportViewer1.ReportSource = tr3;
            }
            else if (reportName == "TrialBalance4")
            {
                TrialBalance4 tr4 = new TrialBalance4();
                tr4.SetDataSource(ds1);
                tr4.SetParameterValue(0, CompanyName);
                tr4.SetParameterValue(1, CompanyAddress);
                tr4.SetParameterValue(2, ReportTag);
                tr4.SetParameterValue(3, FromTo);
                tr4.SetParameterValue(4, TOT5);
                tr4.SetParameterValue(5, TOT6);
                crystalReportViewer1.ShowPrintButton = showPrintButton;
                crystalReportViewer1.ShowExportButton = showExportButton;
                crystalReportViewer1.ReportSource = tr4;
            }
        }
        public void fill_data1(string reportName, DataTable dt, string CompanyName, string CompanyAddress, string ReportTag, string FromTo, bool showPrintButton, bool showExportButton,string TOT1,string  TOT2)
        {
            if (reportName == "RptStock")
            {
            StckwotdtlRpt tr1 = new StckwotdtlRpt();           
            tr1.SetDataSource(dt);
            tr1.SetParameterValue(0, CompanyName);
            tr1.SetParameterValue(1, CompanyAddress);
            tr1.SetParameterValue(2, ReportTag);
            tr1.SetParameterValue(3, FromTo);
            tr1.SetParameterValue(4, TOT1);
            tr1.SetParameterValue(5, TOT2);
            crystalReportViewer1.ShowPrintButton = showPrintButton;
            crystalReportViewer1.ShowExportButton = showExportButton;
            crystalReportViewer1.ReportSource = tr1;
            }
            else  if (reportName == "RptStockDt")
            {
                StockwdtRpt dtl = new StockwdtRpt();
                dtl.SetDataSource(dt);
                dtl.SetParameterValue(0, CompanyName);
                dtl.SetParameterValue(1, CompanyAddress);
                dtl.SetParameterValue(2, ReportTag);
                dtl.SetParameterValue(3, FromTo);
                dtl.SetParameterValue(4, TOT1);
                dtl.SetParameterValue(5, TOT2);
                crystalReportViewer1.ShowPrintButton = showPrintButton;
                crystalReportViewer1.ShowExportButton = showExportButton;
                crystalReportViewer1.ReportSource = dtl;
            }
        }

        public void fill_data2(string reportName, DataTable dt, string CompanyName, string CompanyAddress, string ReportTag, string FromTo, bool showPrintButton, bool showExportButton, string TOT1, string TOT2)
        {
            if (reportName == "RptStockDt")
            {
                StockwdtRpt dtl = new StockwdtRpt();
                dtl.SetDataSource(dt);
                dtl.SetParameterValue(0, CompanyName);
                dtl.SetParameterValue(1, CompanyAddress);
                dtl.SetParameterValue(2, ReportTag);
                dtl.SetParameterValue(3, FromTo);
                dtl.SetParameterValue(4, TOT1);
                dtl.SetParameterValue(5, TOT2);
                crystalReportViewer1.ShowPrintButton = showPrintButton;
                crystalReportViewer1.ShowExportButton = showExportButton;
                crystalReportViewer1.ReportSource = dtl;
                crystalReportViewer1.PrintReport();
            }
        }

        public void fill_CashRptView(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string cashbook, string From, string To, DataTable dt)
        {
            //if (reportName == "RptStock")
            //{
                //crysRptCash_Book cash = new crysRptCash_Book();
                CrystalReportCashBook cash = new CrystalReportCashBook();
                cash.SetDataSource(dt);
                cash.SetParameterValue(0, CompanyName);
                cash.SetParameterValue(1, CompanyAddress1);
                cash.SetParameterValue(2, CompanyAddress2);
                cash.SetParameterValue(3, PANNO);                
                cash.SetParameterValue(4, cashbook);
                cash.SetParameterValue(5, From);
                cash.SetParameterValue(6, To);              
                
                //crystalReportViewer1.ShowPrintButton = showPrintButton;
                //crystalReportViewer1.ShowExportButton = showExportButton;
                crystalReportViewer1.ReportSource = cash;
            //}
        }

        public void fill_CashRptPrint(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string cashbook, string From, string To, DataTable dt, int pn)
        {            
            CrystalReportCashBook cash = new CrystalReportCashBook();
            cash.SetDataSource(dt); 
            cash.SetParameterValue(0, CompanyName);
            cash.SetParameterValue(1, CompanyAddress1);
            cash.SetParameterValue(2, CompanyAddress2);
            cash.SetParameterValue(3, PANNO);
            cash.SetParameterValue(4, cashbook);
            cash.SetParameterValue(5, From);
            cash.SetParameterValue(6, To);
            //cash.PrintToPrinter(1, true, 1, pn);
            crystalReportViewer1.ReportSource = cash;
            crystalReportViewer1.PrintReport();           
        }

        private void simpleTextReport1_Load(object sender, EventArgs e)
        {

        }

        public void fill_SalesAnalysis_ShortTerm_View(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string To, DataTable dt)
        {
            CrystalReportSalesAnalysisShort SARS = new CrystalReportSalesAnalysisShort();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);
            SARS.SetParameterValue(6, To);
            crystalReportViewer1.ReportSource = SARS;            
        }

        public void fill_SalesAnalysis_ShortTerm_Print(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string To, DataTable dt, int pn)
        {
            CrystalReportSalesAnalysisShort SARS = new CrystalReportSalesAnalysisShort();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);
            SARS.SetParameterValue(6, To);
            crystalReportViewer1.ReportSource = SARS;
            crystalReportViewer1.PrintReport();
        }

        public void fill_DividendReceivedWOAC_View(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string To, DataTable dt)
        {
            CrystalReportDividendReceivedWOAC SARS = new CrystalReportDividendReceivedWOAC();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);
            SARS.SetParameterValue(6, To);
            crystalReportViewer1.ReportSource = SARS;
        }

        public void fill_DividendReceivedWOAC_Print(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string To, DataTable dt, int pn)
        {
            CrystalReportDividendReceivedWOAC SARS = new CrystalReportDividendReceivedWOAC();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);
            SARS.SetParameterValue(6, To);
            crystalReportViewer1.ReportSource = SARS;
            crystalReportViewer1.PrintReport();
        }

        public void fill_SalesAnalysis_LongTerm_View(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string To, DataTable dt)
        {
            CrystalReportSalesAnalysisLong SARS = new CrystalReportSalesAnalysisLong();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);
            SARS.SetParameterValue(6, To);            
            //SARS.Section3.ReportObjects[0].Left = 5;
            //SARS.Section3.ReportObjects[1].Left = SARS.Section3.ReportObjects[0].Left + SARS.Section3.ReportObjects[0].Width;
            crystalReportViewer1.ReportSource = SARS;
        }
               
        public void fill_SalesAnalysis_LongTerm_Print(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string To, DataTable dt, int pn)
        {
            CrystalReportSalesAnalysisLong SARS = new CrystalReportSalesAnalysisLong();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);
            SARS.SetParameterValue(6, To);
            crystalReportViewer1.ReportSource = SARS;            
            crystalReportViewer1.PrintReport();
        }

        public void fill_AssetUnderManagement_View(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string To, string Ptype, DataTable dtHeading, DataTable dt)
        {
            CRAssetUnderManagement SARS = new CRAssetUnderManagement();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);
            SARS.SetParameterValue(6, To);
            string HD1, HD2, HD3, HD4, HD5, HD6;
            HD1 = dtHeading.Rows[0][0].ToString();
            HD2 = dtHeading.Rows[1][0].ToString();
            HD3 = dtHeading.Rows[2][0].ToString();
            HD4 = dtHeading.Rows[3][0].ToString();
            HD5 = dtHeading.Rows[4][0].ToString();
            HD6 = dtHeading.Rows[5][0].ToString();

            SARS.SetParameterValue(7, HD1);
            SARS.SetParameterValue(8, HD2);
            SARS.SetParameterValue(9, HD3);
            SARS.SetParameterValue(10, HD4);
            SARS.SetParameterValue(11, HD5);
            SARS.SetParameterValue(12, HD6);     

            crystalReportViewer1.ReportSource = SARS;
            if (Ptype == "PRINT")
            {
                crystalReportViewer1.PrintReport();
            }
        }

        public void fill_PerformanceHistory(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string To, string Ptype, DataTable dt)
        {
            CRPerformanceHistory SARS = new CRPerformanceHistory();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);
            SARS.SetParameterValue(6, To);
            crystalReportViewer1.ReportSource = SARS;
            if (Ptype == "PRINT")
            {
                crystalReportViewer1.PrintReport();
            }
        }

        public void fill_FDAccruedInterest(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string Ptype, DataTable dt)
        {
            CRFDAccruedInterest SARS = new CRFDAccruedInterest();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);            
            if (Ptype == "PRINT")
            {
                //crystalReportViewer1.PrintReport();
                try
                {
                    SARS.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    SARS.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = SARS;
                }
                catch { }
            }
            else
            {
                crystalReportViewer1.ReportSource = SARS;
            }
        }

        public void fill_FDPerformanceReport(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string To, string Ptype, DataTable dt)
        {
            CRFDPerformanceReport SARS = new CRFDPerformanceReport();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);
            SARS.SetParameterValue(6, To);            
            if (Ptype == "PRINT")
            {
                //crystalReportViewer1.PrintReport();
                try
                {
                    SARS.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    SARS.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = SARS;
                }
                catch { }
            }
            else
            {
                crystalReportViewer1.ReportSource = SARS;
            }
        }

        public void fill_SummaryRealizedGainLoss(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string To, string Ptype, DataTable dt)
        {
            CRRealizedGainLossesSummary SARS = new CRRealizedGainLossesSummary();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);
            SARS.SetParameterValue(6, To);
            crystalReportViewer1.ReportSource = SARS;
            if (Ptype == "PRINT")
            {
                crystalReportViewer1.PrintReport();
            }
        }

        public void Opening_EquityPrint(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {
            // crysRptCash_Book cash = new crysRptCash_Book();
            OprningEqReport cash = new OprningEqReport();
            //MutualFund  cash = new MutualFund ();
            if (stp == 1)
            {
                cash.SetDataSource(dtshow);
                cash.SetParameterValue(0, companyName);
                cash.SetParameterValue(1, addre);
                cash.SetParameterValue(2, panno);
                cash.SetParameterValue(3, dura);
                cash.SetParameterValue(4, add1);
                //crystalReportViewer1.ReportSource = cash;
                crystalReportViewer1.ReportSource = cash;
                //string companyName,,DateTime fromdate,DateTime todate
            }
            else
            {
                cash.SetDataSource(dtshow);
                cash.SetParameterValue(0, companyName);
                cash.SetParameterValue(1, addre);
                cash.SetParameterValue(2, panno);
                cash.SetParameterValue(3, dura);
                cash.SetParameterValue(4, add1);
                try
                {
                    cash.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    cash.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = cash;
                }
                catch { }
                //crystalReportViewer1.ReportSource = cash;
                //crystalReportViewer1.PrintReport();

            }
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        public void puchageview(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1,int stp)
        {
            CrystalReportPurchageall purll = new CrystalReportPurchageall();

            if (stp == 1)
            {
                purll.SetDataSource(dtshow);
                purll.SetParameterValue(0, companyName);
                purll.SetParameterValue(1, dura);
                purll.SetParameterValue(2, addre);
                purll.SetParameterValue(3, panno);                
                purll.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = purll;
                //string companyName,,DateTime fromdate,DateTime todate
            }
            else
            {
                purll.SetDataSource(dtshow);
                purll.SetParameterValue(0, companyName);
                purll.SetParameterValue(1, dura);
                purll.SetParameterValue(2, addre);
                purll.SetParameterValue(3, panno);
                purll.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = purll;
                crystalReportViewer1.PrintReport();

            }
        }

        public void brokerview(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalReportbroker brk = new CrystalReportbroker();
            if (stp == 1)
            {
                brk.SetDataSource(dtshow);
                brk.SetParameterValue(0, companyName);
                brk.SetParameterValue(1, dura);
                brk.SetParameterValue(2, addre);
                brk.SetParameterValue(3, panno);
                brk.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = brk;
            }
            else
            {
                brk.SetDataSource(dtshow);
                brk.SetParameterValue(0, companyName);
                brk.SetParameterValue(1, dura);
                brk.SetParameterValue(2, addre);
                brk.SetParameterValue(3, panno);
                brk.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = brk;
                crystalReportViewer1.PrintReport();
            }
        }

        //dddddddddddddddddddddddddddd
        public void saleall(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalReportSaleAll sal = new CrystalReportSaleAll();
            if (stp == 1)
            {
                sal.SetDataSource(dtshow);
                sal.SetParameterValue(0, companyName);
                sal.SetParameterValue(1, dura);
                sal.SetParameterValue(2, addre);
                sal.SetParameterValue(3, panno);
                sal.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = sal;
            }
            else
            {
                sal.SetDataSource(dtshow);
                sal.SetParameterValue(0, companyName);
                sal.SetParameterValue(1, dura);
                sal.SetParameterValue(2, addre);
                sal.SetParameterValue(3, panno);
                sal.SetParameterValue(4, add1);
                try
                {
                    sal.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    sal.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = sal;
                }
                catch { }
                //crystalReportViewer1.ReportSource = sal;                
                //crystalReportViewer1.PrintReport();                
            }
        }

        public void salebroker(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalReportsalebroker salbrok = new CrystalReportsalebroker();
            if (stp == 1)
            {
            salbrok.SetDataSource(dtshow);
            salbrok.SetParameterValue(0, companyName);
            salbrok.SetParameterValue(1, dura);
            salbrok.SetParameterValue(2, addre);
            salbrok.SetParameterValue(3, panno);
            salbrok.SetParameterValue(4, add1);            
            crystalReportViewer1.ReportSource = salbrok;
            }
            else 
            {
                salbrok.SetDataSource(dtshow);
                salbrok.SetParameterValue(0, companyName);
                salbrok.SetParameterValue(1, dura);
                salbrok.SetParameterValue(2, addre);
                salbrok.SetParameterValue(3, panno);
                salbrok.SetParameterValue(4, add1);
                try
                {
                    salbrok.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    salbrok.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = salbrok;
                }
                catch { }
                //crystalReportViewer1.ReportSource = salbrok ;
                //crystalReportViewer1.PrintReport();
            }
        }       

        public void stockdp(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {

            CrystalReportdpwisestock salbrok = new CrystalReportdpwisestock();
            if (stp == 1)
            {
                salbrok.SetDataSource(dtshow);
                salbrok.SetParameterValue(0, companyName);
                salbrok.SetParameterValue(1, dura);
                salbrok.SetParameterValue(2, addre);
                salbrok.SetParameterValue(3, panno);
                salbrok.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = salbrok;
            }
            else
            {
                salbrok.SetDataSource(dtshow);
                salbrok.SetParameterValue(0, companyName);
                salbrok.SetParameterValue(1, dura);
                salbrok.SetParameterValue(2, addre);
                salbrok.SetParameterValue(3, panno);
                salbrok.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = salbrok;
                crystalReportViewer1.PrintReport();
            }
        }


        public void dpsummary(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalReportdpsummary dpsumm = new CrystalReportdpsummary();
            if (stp == 1)
            {
                dpsumm.SetDataSource(dtshow);
                dpsumm.SetParameterValue(0, companyName);
                dpsumm.SetParameterValue(1, dura);
                dpsumm.SetParameterValue(2, addre);
                dpsumm.SetParameterValue(3, panno);
                dpsumm.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = dpsumm;

            }
            else
            {
                dpsumm.SetDataSource(dtshow);
                dpsumm.SetParameterValue(0, companyName);
                dpsumm.SetParameterValue(1, dura);
                dpsumm.SetParameterValue(2, addre);
                dpsumm.SetParameterValue(3, panno);
                dpsumm.SetParameterValue(4, add1);
                try
                {
                    dpsumm.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    dpsumm.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = dpsumm;
                }
                catch { }
                //crystalReportViewer1.ReportSource = dpsumm;
                //crystalReportViewer1.PrintReport();
                
            }
        }

        public void dpclosing(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalReportdpclosing dpclose = new CrystalReportdpclosing();

            if (stp == 1)
            {
                dpclose.SetDataSource(dtshow);
                dpclose.SetParameterValue(0, companyName);
                dpclose.SetParameterValue(1, dura);
                dpclose.SetParameterValue(2, addre);
                dpclose.SetParameterValue(3, panno);
                dpclose.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = dpclose;
            }
            else
            {
                dpclose.SetDataSource(dtshow);
                dpclose.SetParameterValue(0, companyName);
                dpclose.SetParameterValue(1, dura);
                dpclose.SetParameterValue(2, addre);
                dpclose.SetParameterValue(3, panno);
                dpclose.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = dpclose;
                crystalReportViewer1.PrintReport();
            }
        }

        public void Opening_fdPrint(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalRptFixeddeposit fd = new CrystalRptFixeddeposit();
            if (stp == 1)
            {
                fd.SetDataSource(dtshow);
                fd.SetParameterValue(0, companyName);
                fd.SetParameterValue(1, addre);
                fd.SetParameterValue(2, panno);
                fd.SetParameterValue(3, dura);
                fd.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd;
            }
            else
            {
                fd.SetDataSource(dtshow);
                fd.SetParameterValue(0, companyName);
                fd.SetParameterValue(1, addre);
                fd.SetParameterValue(2, panno);
                fd.SetParameterValue(3, dura);
                fd.SetParameterValue(4, add1);                                
                try
                {
                    fd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    fd.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = fd;
                }
                catch { }                
                //crystalReportViewer1.PrintReport();
            }
        }

        public void Subscription_fdPrint(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {

            Crystalrptcreate fd1 = new Crystalrptcreate();

            if (stp == 1)
            {
                fd1.SetDataSource(dtshow);
                fd1.SetParameterValue(0, companyName);
                fd1.SetParameterValue(1, addre);
                fd1.SetParameterValue(2, panno);
                fd1.SetParameterValue(3, dura);
                fd1.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd1;

            }
            else
            {
                fd1.SetDataSource(dtshow);
                fd1.SetParameterValue(0, companyName);
                fd1.SetParameterValue(1, addre);
                fd1.SetParameterValue(2, panno);
                fd1.SetParameterValue(3, dura);
                fd1.SetParameterValue(4, add1);
                try
                {
                    fd1.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    fd1.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = fd1;
                }
                catch { }
                //crystalReportViewer1.ReportSource = fd1;
                //crystalReportViewer1.PrintReport();

            }
        }
        public void FDintarest_fdPrint(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {

          CrystalrptFDinterest fd2 = new CrystalrptFDinterest();

            if (stp == 1)
            {
                fd2.SetDataSource(dtshow);
                fd2.SetParameterValue(0, companyName);
                fd2.SetParameterValue(1, addre);
                fd2.SetParameterValue(2, panno);
                fd2.SetParameterValue(3, dura);
                fd2.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd2;

            }
            else
            {
                fd2.SetDataSource(dtshow);
                fd2.SetParameterValue(0, companyName);
                fd2.SetParameterValue(1, addre);
                fd2.SetParameterValue(2, panno);
                fd2.SetParameterValue(3, dura);
                fd2.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd2;
                crystalReportViewer1.PrintReport();

            }
        }

        public void fill_CashRptView1(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string cashbook, string From, string To, DataTable dt)
        {
            CryssalCashBook cash = new CryssalCashBook();
            cash.SetDataSource(dt);
            cash.SetParameterValue(0, CompanyName);
            cash.SetParameterValue(1, CompanyAddress1);
            cash.SetParameterValue(2, CompanyAddress2);
            cash.SetParameterValue(3, PANNO);
            cash.SetParameterValue(4, cashbook);
            cash.SetParameterValue(5, From);
            cash.SetParameterValue(6, To);

            crystalReportViewer1.ReportSource = cash;

        }
        public void fill_CashRptView2(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string cashbook, string From, string To, DataTable dt, int pn)
        {
            CryssalCashBook cash = new CryssalCashBook();
            cash.SetDataSource(dt);
            cash.SetParameterValue(0, CompanyName);
            cash.SetParameterValue(1, CompanyAddress1);
            cash.SetParameterValue(2, CompanyAddress2);
            cash.SetParameterValue(3, PANNO);
            cash.SetParameterValue(4, cashbook);
            cash.SetParameterValue(5, From);
            cash.SetParameterValue(6, To);
            crystalReportViewer1.ReportSource = cash;
            crystalReportViewer1.PrintReport();
        }

        public void FDRedemtion(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {

            CrystalrptFDRedemption fd2 = new CrystalrptFDRedemption();

            if (stp == 1)
            {
                fd2.SetDataSource(dtshow);
                fd2.SetParameterValue(0, companyName);
                fd2.SetParameterValue(1, addre);
                fd2.SetParameterValue(2, panno);
                fd2.SetParameterValue(3, dura);
                fd2.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd2;

            }
            else
            {
                fd2.SetDataSource(dtshow);
                fd2.SetParameterValue(0, companyName);
                fd2.SetParameterValue(1, addre);
                fd2.SetParameterValue(2, panno);
                fd2.SetParameterValue(3, dura);
                fd2.SetParameterValue(4, add1);
                try
                {
                    fd2.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    fd2.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = fd2;
                }
                catch { }
                //crystalReportViewer1.ReportSource = fd2;
                //crystalReportViewer1.PrintReport();

            }
        }

        public void mf_Print(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalRptmf fd2 = new CrystalRptmf();
            if (stp == 1)
            {
                fd2.SetDataSource(dtshow);
                fd2.SetParameterValue(0, companyName);
                fd2.SetParameterValue(1, addre);
                fd2.SetParameterValue(2, panno);
                fd2.SetParameterValue(3, dura);
                fd2.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd2;
            }
            else
            {
                fd2.SetDataSource(dtshow);
                fd2.SetParameterValue(0, companyName);
                fd2.SetParameterValue(1, addre);
                fd2.SetParameterValue(2, panno);
                fd2.SetParameterValue(3, dura);
                fd2.SetParameterValue(4, add1);
                //crystalReportViewer1.ReportSource = fd2;
                //crystalReportViewer1.PrintReport();
                try
                {
                    fd2.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    fd2.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = fd2;
                }
                catch { }
            }
        }

        public void MFglance(string companyName, DataTable dgv, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalReportMFglance fd2 = new CrystalReportMFglance();
            if (stp == 1)
            {
                fd2.SetDataSource(dgv);
                fd2.SetParameterValue(0, companyName);
                fd2.SetParameterValue(1, addre);
                fd2.SetParameterValue(2, panno);
                fd2.SetParameterValue(3, dura);
                fd2.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd2;
            }
            else
            {
                fd2.SetDataSource(dgv);
                fd2.SetParameterValue(0, companyName);
                fd2.SetParameterValue(1, addre);
                fd2.SetParameterValue(2, panno);
                fd2.SetParameterValue(3, dura);
                fd2.SetParameterValue(4, add1);
                //crystalReportViewer1.ReportSource = fd2;
                //crystalReportViewer1.PrintReport();
                try
                {
                    fd2.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    fd2.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = fd2;
                }
                catch { }
            }
        }

        public void fill_DividendReceived_View(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string To, DataTable dt)
        {

            CrystalRptMFDivRecived SARS = new CrystalRptMFDivRecived();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);
            SARS.SetParameterValue(6, To);
            crystalReportViewer1.ReportSource = SARS;
        }

        public void fill_DividendReceived_Print(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string BookType, string From, string To, DataTable dt, int pn)
        {
            CrystalRptMFDivRecived SARS = new CrystalRptMFDivRecived();
            SARS.SetDataSource(dt);
            SARS.SetParameterValue(0, CompanyName);
            SARS.SetParameterValue(1, CompanyAddress1);
            SARS.SetParameterValue(2, CompanyAddress2);
            SARS.SetParameterValue(3, PANNO);
            SARS.SetParameterValue(4, BookType);
            SARS.SetParameterValue(5, From);
            SARS.SetParameterValue(6, To);
            try
            {
                SARS.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                SARS.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = SARS;
            }
            catch { }
        }

        public void Bank_RptReconcilliation(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalRptReconcilliation fd = new CrystalRptReconcilliation();
            if (stp == 1)
            {
                fd.SetDataSource(dtshow);
                fd.SetParameterValue(0, companyName);
                fd.SetParameterValue(1, addre);
                fd.SetParameterValue(2, panno);
                fd.SetParameterValue(3, dura);
                fd.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd;
            }
            else
            {
                fd.SetDataSource(dtshow);
                fd.SetParameterValue(0, companyName);
                fd.SetParameterValue(1, addre);
                fd.SetParameterValue(2, panno);
                fd.SetParameterValue(3, dura);
                fd.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd;
                crystalReportViewer1.PrintReport();
            }
        }

        public void EquityBonous(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalRptequitybonous fd = new CrystalRptequitybonous();
            if (stp == 1)
            {
                fd.SetDataSource(dtshow);
                fd.SetParameterValue(0, companyName);
                fd.SetParameterValue(1, addre);
                fd.SetParameterValue(2, panno);
                fd.SetParameterValue(3, dura);
                fd.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd;
            }
            else
            {
                fd.SetDataSource(dtshow);
                fd.SetParameterValue(0, companyName);
                fd.SetParameterValue(1, addre);
                fd.SetParameterValue(2, panno);
                fd.SetParameterValue(3, dura);
                fd.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd;
                crystalReportViewer1.PrintReport();
            }
        }

        public void blancesheet_Print(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalRptBalreport bal = new CrystalRptBalreport();
            if (stp == 1)
            {
                bal.SetDataSource(dtshow);
                bal.SetParameterValue(0, companyName);
                bal.SetParameterValue(1, addre);
                bal.SetParameterValue(2, panno);
                bal.SetParameterValue(3, dura);
                bal.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = bal;
            }
            else
            {
                bal.SetDataSource(dtshow);
                bal.SetParameterValue(0, companyName);
                bal.SetParameterValue(1, addre);
                bal.SetParameterValue(2, panno);
                bal.SetParameterValue(3, dura);
                bal.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = bal;
                crystalReportViewer1.PrintReport();
            }
        }


        public void Derivative(string companyName, DataTable dtt, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalRptDerivative fd2 = new CrystalRptDerivative();
            if (stp == 1)
            {
                fd2.SetDataSource(dtt);
                fd2.SetParameterValue(0, companyName);
                fd2.SetParameterValue(1, addre);
                fd2.SetParameterValue(2, panno);
                fd2.SetParameterValue(3, dura);
                fd2.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd2;
            }
            else
            {
                fd2.SetDataSource(dtt);
                fd2.SetParameterValue(0, companyName);
                fd2.SetParameterValue(1, addre);
                fd2.SetParameterValue(2, panno);
                fd2.SetParameterValue(3, dura);
                fd2.SetParameterValue(4, add1);
                try
            {
                fd2.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                fd2.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = fd2;
            }
            catch { }
        }

            }
        
        public void Opening_eqPrint(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalRptopeningeq fd = new CrystalRptopeningeq();
            if (stp == 1)
            {
                fd.SetDataSource(dtshow);
                fd.SetParameterValue(0, companyName);
                fd.SetParameterValue(1, addre);
                fd.SetParameterValue(2, panno);
                fd.SetParameterValue(3, dura);
                fd.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = fd;
            }
            else
            {
                fd.SetDataSource(dtshow);
                fd.SetParameterValue(0, companyName);
                fd.SetParameterValue(1, addre);
                fd.SetParameterValue(2, panno);
                fd.SetParameterValue(3, dura);
                fd.SetParameterValue(4, add1);
                try
                {
                    fd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    fd.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = fd;
                }
                catch { }
                //crystalReportViewer1.PrintReport();
            }
        }

        public void Commodity(string companyName, DataTable dtt, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalRptCommodity comm = new CrystalRptCommodity();
            if (stp == 1)
            {
                comm.SetDataSource(dtt);
                comm.SetParameterValue(0, companyName);
                comm.SetParameterValue(1, addre);
                comm.SetParameterValue(2, panno);
                comm.SetParameterValue(3, dura);
                comm.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = comm;
            }
            else
            {
                comm.SetDataSource(dtt);
                comm.SetParameterValue(0, companyName);
                comm.SetParameterValue(1, addre);
                comm.SetParameterValue(2, panno);
                comm.SetParameterValue(3, dura);
                comm.SetParameterValue(4, add1);
                try
                {
                    comm.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    comm.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = comm;
                }
                catch { }
            }
        }

        public void sellbill(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, int stp)
        {
            Crystalrptsellbill bill = new Crystalrptsellbill();
            if (stp == 1)
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, dura);
                bill.SetParameterValue(4, add1);
                bill.SetParameterValue(5, company);
                bill.SetParameterValue(6, Agentadd);
                bill.SetParameterValue(7, Agentadd1);
                bill.SetParameterValue(8, phone);
                bill.SetParameterValue(9, Area);
                bill.SetParameterValue(10, BillDate);
                bill.SetParameterValue(11, User_Voucher);
                bill.SetParameterValue(12, challan);
                bill.SetParameterValue(13, AmtWord);

                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, dura);
                bill.SetParameterValue(4, add1);
                bill.SetParameterValue(5, company);
                bill.SetParameterValue(6, Agentadd);
                bill.SetParameterValue(7, Agentadd1);
                bill.SetParameterValue(8, phone);
                bill.SetParameterValue(9, Area);
                bill.SetParameterValue(10, BillDate);
                bill.SetParameterValue(11, User_Voucher);
                bill.SetParameterValue(12, challan);
                bill.SetParameterValue(13, AmtWord);

                crystalReportViewer1.ReportSource = bill;
                crystalReportViewer1.PrintReport();
            }
        }

        public void Specimentin(string companyName, DataTable dtshow, DataTable Transport, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string heading, string challan, int stp)
        {
            CrystalSpecimentChallan SC = new CrystalSpecimentChallan();
            if (stp == 1)
            {
                SC.SetDataSource(dtshow);
                //SC.SetDataSource(Transport);
                SC.SetParameterValue(0, companyName);
                SC.SetParameterValue(1, addre);
                SC.SetParameterValue(2, panno);
                SC.SetParameterValue(3, dura);
                SC.SetParameterValue(4, add1);
                SC.SetParameterValue(5, company);
                SC.SetParameterValue(6, Agentadd);
                SC.SetParameterValue(7, Agentadd1);
                SC.SetParameterValue(8, phone);
                SC.SetParameterValue(9, Area);
                SC.SetParameterValue(10, BillDate);
                SC.SetParameterValue(11, User_Voucher);
                SC.SetParameterValue(12, heading);
                SC.SetParameterValue(13, challan);

                crystalReportViewer1.ReportSource = SC;
            }
            else
            {
                try
                {
                    SC.SetDataSource(dtshow);
                    //SC.SetDataSource(Transport);
                    SC.SetParameterValue(0, companyName);
                    SC.SetParameterValue(1, addre);
                    SC.SetParameterValue(2, panno);
                    SC.SetParameterValue(3, dura);
                    SC.SetParameterValue(4, add1);
                    SC.SetParameterValue(5, company);
                    SC.SetParameterValue(6, Agentadd);
                    SC.SetParameterValue(7, Agentadd1);
                    SC.SetParameterValue(8, phone);
                    SC.SetParameterValue(9, Area);
                    SC.SetParameterValue(10, BillDate);
                    SC.SetParameterValue(11, User_Voucher);
                    SC.SetParameterValue(12, heading);
                    SC.SetParameterValue(13, challan);
                    crystalReportViewer1.ReportSource = SC;
                    //PrintDialog p = new PrintDialog();
                    //p.PrinterSettings.s
                    //p.PrinterSettings.Copies = 3;
                    for (int i = 0; i <= 3; i++)
                    {
                        crystalReportViewer1.PrintReport();

                    }
                }
                catch { }
            }
        }

        public void Cashbill(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, int stp)
        {
            CrystalrptCashmemo bill = new CrystalrptCashmemo();
            if (stp == 1)
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, dura);
                bill.SetParameterValue(4, add1);
                bill.SetParameterValue(5, company);
                bill.SetParameterValue(6, Agentadd);
                bill.SetParameterValue(7, Agentadd1);
                bill.SetParameterValue(8, phone);
                bill.SetParameterValue(9, Area);
                bill.SetParameterValue(10, BillDate);
                bill.SetParameterValue(11, User_Voucher);
                bill.SetParameterValue(12, challan);
                bill.SetParameterValue(13, AmtWord);

                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, dura);
                bill.SetParameterValue(4, add1);
                bill.SetParameterValue(5, company);
                bill.SetParameterValue(6, Agentadd);
                bill.SetParameterValue(7, Agentadd1);
                bill.SetParameterValue(8, phone);
                bill.SetParameterValue(9, Area);
                bill.SetParameterValue(10, BillDate);
                bill.SetParameterValue(11, User_Voucher);
                bill.SetParameterValue(12, challan);
                bill.SetParameterValue(13, AmtWord);

                crystalReportViewer1.ReportSource = bill;
                crystalReportViewer1.PrintReport();
            }
        }

        public void AgenrPerformence(string companyName, DataTable dtt, string dura, string addre, string panno, string add1,string agname, int stp)
        {
            Crystalrptagentperformence ag = new Crystalrptagentperformence();
            if (stp == 1)
            {
                ag.SetDataSource(dtt);
                ag.SetParameterValue(0, companyName);
                ag.SetParameterValue(1, addre);
                ag.SetParameterValue(2, panno);
                ag.SetParameterValue(3, dura);
                ag.SetParameterValue(4, add1);
                ag.SetParameterValue(5, agname);
                crystalReportViewer1.ReportSource = ag;
            }
            else
            {
                ag.SetDataSource(dtt);
                ag.SetParameterValue(0, companyName);
                ag.SetParameterValue(1, addre);
                ag.SetParameterValue(2, panno);
                ag.SetParameterValue(3, dura);
                ag.SetParameterValue(4, add1);
                ag.SetParameterValue(5, agname);
                try
                {
                    ag.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    ag.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = ag;
                }
                catch { }
            }

        }

        public void BookPrintOrder(string companyName, DataTable dtshow, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string User_Voucher, int stp)
        {
            crsFrmBookBindingOrder bill = new crsFrmBookBindingOrder();
            if (stp == 1)
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, add1);
                bill.SetParameterValue(4, company);
                bill.SetParameterValue(5, Agentadd);
                bill.SetParameterValue(6, Agentadd1);
                bill.SetParameterValue(7, phone);
                bill.SetParameterValue(8, User_Voucher);
                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, add1);
                bill.SetParameterValue(4, company);
                bill.SetParameterValue(5, Agentadd);
                bill.SetParameterValue(6, Agentadd1);
                bill.SetParameterValue(7, phone);
                bill.SetParameterValue(8, User_Voucher);
                crystalReportViewer1.ReportSource = bill;
                crystalReportViewer1.PrintReport();

            }
        }

        public void BookPrint(string companyName, DataTable dtshow, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string User_Voucher, int stp)
        {
            crsFrmBookBinding bill = new crsFrmBookBinding();
            if (stp == 1)
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, add1);
                bill.SetParameterValue(4, company);
                bill.SetParameterValue(5, Agentadd);
                bill.SetParameterValue(6, Agentadd1);
                bill.SetParameterValue(7, phone);
                bill.SetParameterValue(8, User_Voucher);
                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, add1);
                bill.SetParameterValue(4, company);
                bill.SetParameterValue(5, Agentadd);
                bill.SetParameterValue(6, Agentadd1);
                bill.SetParameterValue(7, phone);
                bill.SetParameterValue(8, User_Voucher);
                try
                {
                    bill.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    bill.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = bill;
                }
                catch { }

            }
        }
        public void Agentsalse(string companyName, DataTable dtt, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalRptAgentsales ag = new CrystalRptAgentsales();
            if (stp == 1)
            {
                ag.SetDataSource(dtt);
                ag.SetParameterValue(0, companyName);
                ag.SetParameterValue(1, addre);
                ag.SetParameterValue(2, panno);
                ag.SetParameterValue(3, dura);
                ag.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = ag;
            }
            else
            {
                ag.SetDataSource(dtt);
                ag.SetParameterValue(0, companyName);
                ag.SetParameterValue(1, addre);
                ag.SetParameterValue(2, panno);
                ag.SetParameterValue(3, dura);
                ag.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = ag;
                crystalReportViewer1.PrintReport();

            }

        }

        public void DailyTally(string companyName, DataTable dtt, string dura, string addre, string panno, string add1, int stp)
        {
            CrystalRptDailyTallySheet ag = new CrystalRptDailyTallySheet();
            if (stp == 1)
            {
                ag.SetDataSource(dtt);
                ag.SetParameterValue(0, companyName);
                ag.SetParameterValue(1, addre);
                ag.SetParameterValue(2, panno);
                ag.SetParameterValue(3, dura);
                ag.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = ag;
            }
            else
            {
                ag.SetDataSource(dtt);
                ag.SetParameterValue(0, companyName);
                ag.SetParameterValue(1, addre);
                ag.SetParameterValue(2, panno);
                ag.SetParameterValue(3, dura);
                ag.SetParameterValue(4, add1);
                crystalReportViewer1.ReportSource = ag;
                crystalReportViewer1.PrintReport();

            }

        }

        public void purchaseRegisterRpt(string current_company, DataTable dtshow, string address, string address1, string pan, string DURATION, int stp)
        {
            CrstPurchaseRegisterReport bill = new CrstPurchaseRegisterReport();
            if (stp == 1)
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, current_company);
                bill.SetParameterValue(1, address);
                bill.SetParameterValue(2, address1);
                bill.SetParameterValue(3, pan);
                bill.SetParameterValue(4, DURATION);
                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, current_company);
                bill.SetParameterValue(1, address);
                bill.SetParameterValue(2, address1);
                bill.SetParameterValue(3, pan);
                bill.SetParameterValue(4, DURATION);
                crystalReportViewer1.ReportSource = bill;
                crystalReportViewer1.PrintReport();
                

            }
        }

        public void sellbillfull(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, int stp)
        {
            CrystalRptsallfull bill = new CrystalRptsallfull();
            if (stp == 1)
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, dura);
                bill.SetParameterValue(4, add1);
                bill.SetParameterValue(5, company);
                bill.SetParameterValue(6, Agentadd);
                bill.SetParameterValue(7, Agentadd1);
                bill.SetParameterValue(8, phone);
                bill.SetParameterValue(9, Area);
                bill.SetParameterValue(10, BillDate);
                bill.SetParameterValue(11, User_Voucher);
                bill.SetParameterValue(12, challan);
                bill.SetParameterValue(13, AmtWord);

                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, dura);
                bill.SetParameterValue(4, add1);
                bill.SetParameterValue(5, company);
                bill.SetParameterValue(6, Agentadd);
                bill.SetParameterValue(7, Agentadd1);
                bill.SetParameterValue(8, phone);
                bill.SetParameterValue(9, Area);
                bill.SetParameterValue(10, BillDate);
                bill.SetParameterValue(11, User_Voucher);
                bill.SetParameterValue(12, challan);
                bill.SetParameterValue(13, AmtWord);

                crystalReportViewer1.ReportSource = bill;
                crystalReportViewer1.PrintReport();
            }
        }

        public void Cashbillhalf(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, int stp)
        {
            CrystalRptcashmemohalf bill = new CrystalRptcashmemohalf();
            if (stp == 1)
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, dura);
                bill.SetParameterValue(4, add1);
                bill.SetParameterValue(5, company);
                bill.SetParameterValue(6, Agentadd);
                bill.SetParameterValue(7, Agentadd1);
                bill.SetParameterValue(8, phone);
                bill.SetParameterValue(9, Area);
                bill.SetParameterValue(10, BillDate);
                bill.SetParameterValue(11, User_Voucher);
                bill.SetParameterValue(12, challan);
                bill.SetParameterValue(13, AmtWord);

                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, dura);
                bill.SetParameterValue(4, add1);
                bill.SetParameterValue(5, company);
                bill.SetParameterValue(6, Agentadd);
                bill.SetParameterValue(7, Agentadd1);
                bill.SetParameterValue(8, phone);
                bill.SetParameterValue(9, Area);
                bill.SetParameterValue(10, BillDate);
                bill.SetParameterValue(11, User_Voucher);
                bill.SetParameterValue(12, challan);
                bill.SetParameterValue(13, AmtWord);

                crystalReportViewer1.ReportSource = bill;
                crystalReportViewer1.PrintReport();
            }
        }
        public void Voucher(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1,string voucher, int stp)
        {
            CrystalRptVoucher vch = new CrystalRptVoucher();
            if (stp == 1)
            {
                vch.SetDataSource(dtshow);
                vch.SetParameterValue(0, companyName);
                vch.SetParameterValue(1, addre);
                vch.SetParameterValue(2, panno);
                vch.SetParameterValue(3, dura);
                vch.SetParameterValue(4, add1);
                vch.SetParameterValue(5, voucher);
                crystalReportViewer1.ReportSource = vch;
            }
            else
            {
                vch.SetDataSource(dtshow);
                vch.SetParameterValue(0, companyName);
                vch.SetParameterValue(1, addre);
                vch.SetParameterValue(2, panno);
                vch.SetParameterValue(3, dura);
                vch.SetParameterValue(4, add1);
                vch.SetParameterValue(5, voucher);
                crystalReportViewer1.ReportSource = vch;
                crystalReportViewer1.PrintReport();
            }
        }
        public void Voucherhalf(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string voucher, int stp)
        {
            CrystalRptVoucherhalf vch = new CrystalRptVoucherhalf();
            if (stp == 1)
            {
                vch.SetDataSource(dtshow);
                vch.SetParameterValue(0, companyName);
                vch.SetParameterValue(1, addre);
                vch.SetParameterValue(2, panno);
                vch.SetParameterValue(3, dura);
                vch.SetParameterValue(4, add1);
                vch.SetParameterValue(5, voucher);
                crystalReportViewer1.ReportSource = vch;
            }
            else
            {
                vch.SetDataSource(dtshow);
                vch.SetParameterValue(0, companyName);
                vch.SetParameterValue(1, addre);
                vch.SetParameterValue(2, panno);
                vch.SetParameterValue(3, dura);
                vch.SetParameterValue(4, add1);
                vch.SetParameterValue(5, voucher);
                crystalReportViewer1.ReportSource = vch;
                crystalReportViewer1.PrintReport();
            }
        }

    }
   
}