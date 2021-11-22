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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;
using System.ComponentModel.Design;
using System.IO;
using Edpcom;

namespace MidasReport
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CrystalAllReport CAR = new CrystalAllReport();
        CrystalAllReport_L CAR_L = new CrystalAllReport_L();
        CrystalReport_LetterFormat CARLF = new CrystalReport_LetterFormat();
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        
      
        int columnHeaderTop = 0;
        public bool PageNumberDisplay = true;

        public Form1()
        {
            InitializeComponent();
        }

        public void fill_CashRptView(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string cashbook, string From, string To, DataTable dt)
        {
            //if (reportName == "RptStock")
            //{
            //crysRptCash_Book cash = new crysRptCash_Book();
            CrystalReportCashBook cash = new CrystalReportCashBook();
            cash.SetDataSource(dt);
            cash.SetParameterValue(0, CompanyName);
            cash.SetParameterValue(1, CompanyAddress1);     //PPPPP
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
            cash.SetParameterValue(4, cashbook);            //PPPPP
            cash.SetParameterValue(5, From);
            cash.SetParameterValue(6, To);
            //cash.PrintToPrinter(1, true, 1, pn);
            crystalReportViewer1.ReportSource = cash;
            if (edpcom.EnvironMent_Bittype == "64")
            {
                try
                {
                    cash.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = cash;
                }
                catch { }
            }
            else
            {
                crystalReportViewer1.PrintReport();
            }    
        }

        public void fill_CashRptView1(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string cashbook, string From, string To, DataTable dt)
        {
            CryssalCashBook cash = new CryssalCashBook();
            cash.SetDataSource(dt);
            cash.SetParameterValue(0, CompanyName);
            cash.SetParameterValue(1, CompanyAddress1);
            cash.SetParameterValue(2, CompanyAddress2);//PPPPP
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
            cash.SetParameterValue(2, CompanyAddress2);//PPPPP
            cash.SetParameterValue(3, PANNO);
            cash.SetParameterValue(4, cashbook);
            cash.SetParameterValue(5, From);
            cash.SetParameterValue(6, To);
            crystalReportViewer1.ReportSource = cash;
            if (edpcom.EnvironMent_Bittype == "64")
            {
                try
                {
                    cash.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = cash;
                }
                catch { }
            }
            else
            {
                crystalReportViewer1.PrintReport();
            }    
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
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        fd.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = fd;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }    
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
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        bill.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bill;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }    
            }
        }



        public void sellbillfull(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, string Tan, string amount, string challandt,string type, int stp)
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
                bill.SetParameterValue(14, Tan);
                bill.SetParameterValue(15, amount);
                bill.SetParameterValue(16, challandt);
                bill.SetParameterValue(17, type);
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
                bill.SetParameterValue(14, Tan);
                bill.SetParameterValue(15, amount);
                bill.SetParameterValue(16, challandt);
                bill.SetParameterValue(17, type);

                crystalReportViewer1.ReportSource = bill;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        bill.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bill;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }               
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
                bal.SetParameterValue(2, panno);//PPPPP
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
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        bal.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bal;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }
            }
        }

        public void trailBlance(DataTable dt, string company, string BRNCH_ADD1, string BRNCH_PAN1, string date, string Heading, int b)
        {


            if (b == 1)
            {
                CrystalRptTrail tb = new CrystalRptTrail();
                tb.SetDataSource(dt);
                tb.SetParameterValue(0, company);
                tb.SetParameterValue(1, BRNCH_ADD1);
                tb.SetParameterValue(2, BRNCH_PAN1);//PPPPP
                tb.SetParameterValue(3, date);
                tb.SetParameterValue(4, Heading);
                crystalReportViewer1.ReportSource = tb;
            }
            if (b == 2)
            {
                CrystalRptTrail tb = new CrystalRptTrail();
                tb.SetDataSource(dt);
                tb.SetParameterValue(0, company);
                tb.SetParameterValue(1, BRNCH_ADD1);
                tb.SetParameterValue(2, BRNCH_PAN1);
                tb.SetParameterValue(3, date);
                tb.SetParameterValue(4, Heading);
                try
                {
                    tb.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    tb.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = tb;
                }
                catch { }
            }
            if (b == 3)
            {
                CrystalRptTrailBlance2 tb2 = new CrystalRptTrailBlance2();
                tb2.SetDataSource(dt);
                tb2.SetParameterValue(0, company);
                tb2.SetParameterValue(1, BRNCH_ADD1);
                tb2.SetParameterValue(2, BRNCH_PAN1);
                tb2.SetParameterValue(3, date);
                tb2.SetParameterValue(4, Heading);
                crystalReportViewer1.ReportSource = tb2;
            }
            if (b == 4)
            {
                CrystalRptTrailBlance2 tb2 = new CrystalRptTrailBlance2();
                tb2.SetDataSource(dt);
                tb2.SetParameterValue(0, company);
                tb2.SetParameterValue(1, BRNCH_ADD1);
                tb2.SetParameterValue(2, BRNCH_PAN1);
                tb2.SetParameterValue(3, date);
                tb2.SetParameterValue(4, Heading);
                crystalReportViewer1.ReportSource = tb2;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        tb2.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = tb2;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }

            }
            if (b == 5)
            {
                Crystarpttrialopening tb3 = new Crystarpttrialopening();
                tb3.SetDataSource(dt);
                tb3.SetParameterValue(0, company);
                tb3.SetParameterValue(1, BRNCH_ADD1);
                tb3.SetParameterValue(2, BRNCH_PAN1);
                tb3.SetParameterValue(3, date);
                tb3.SetParameterValue(4, Heading);
                crystalReportViewer1.ReportSource = tb3;
            }
            if (b == 6)
            {
                Crystarpttrialopening tb3 = new Crystarpttrialopening();
                tb3.SetDataSource(dt);
                tb3.SetParameterValue(0, company);
                tb3.SetParameterValue(1, BRNCH_ADD1);
                tb3.SetParameterValue(2, BRNCH_PAN1);
                tb3.SetParameterValue(3, date);
                tb3.SetParameterValue(4, Heading);
                crystalReportViewer1.ReportSource = tb3;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        tb3.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = tb3;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }
            }
        }
        public void blancesheet_PrintT(string companyName, DataTable dtt, string dura, string addre, string panno, string add1, string drtot, string crtot, int stp)
        {
            CrystalrptBSTshape bal = new CrystalrptBSTshape();

            if (stp == 1)
            {
                bal.SetDataSource(dtt);
                bal.SetParameterValue(0, companyName);
                bal.SetParameterValue(1, addre);
                bal.SetParameterValue(2, panno);
                bal.SetParameterValue(3, dura);
                bal.SetParameterValue(4, add1);
                bal.SetParameterValue(5, drtot);
                bal.SetParameterValue(6, crtot);//PPPPP
                crystalReportViewer1.ReportSource = bal;
            }
            else
            {
                bal.SetDataSource(dtt);
                bal.SetParameterValue(0, companyName);
                bal.SetParameterValue(1, addre);
                bal.SetParameterValue(2, panno);
                bal.SetParameterValue(3, dura);
                bal.SetParameterValue(4, add1);
                bal.SetParameterValue(5, drtot);
                bal.SetParameterValue(6, crtot);
                crystalReportViewer1.ReportSource = bal;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        bal.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bal;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }
            }

        }


        public void capital(string companyName, DataTable dtt, string dura, string addre, string panno, string add1, string drtot, string crtot, int stp)
        {
            Crystalrptcapital ca = new Crystalrptcapital();

            if (stp == 1)
            {
                ca.SetDataSource(dtt);
                ca.SetParameterValue(0, companyName);
                ca.SetParameterValue(1, addre);
                ca.SetParameterValue(2, panno);
                ca.SetParameterValue(3, dura);
                ca.SetParameterValue(4, add1);
                ca.SetParameterValue(5, drtot);
                ca.SetParameterValue(6, crtot);
                crystalReportViewer1.ReportSource = ca;
            }
            else
            {
                ca.SetDataSource(dtt);
                ca.SetParameterValue(0, companyName);
                ca.SetParameterValue(1, addre);
                ca.SetParameterValue(2, panno);
                ca.SetParameterValue(3, dura);
                ca.SetParameterValue(4, add1);
                ca.SetParameterValue(5, drtot);
                ca.SetParameterValue(6, crtot);
                crystalReportViewer1.ReportSource = ca;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        ca.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = ca;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }
            }

        }

        public void fill_CashRptView3(string CompanyName, string CompanyAddress1, string CompanyAddress2, string PANNO, string cashbook, string From, string To, DataTable dt, int pn)
        {
            CrystalrptBankBook Bank = new CrystalrptBankBook();
            if (pn == 1)
            {
                Bank.SetDataSource(dt);
                Bank.SetParameterValue(0, CompanyName);
                Bank.SetParameterValue(1, CompanyAddress1);
                Bank.SetParameterValue(2, CompanyAddress2);
                Bank.SetParameterValue(3, PANNO);
                Bank.SetParameterValue(4, cashbook);
                Bank.SetParameterValue(5, From);
                Bank.SetParameterValue(6, To);
                crystalReportViewer1.ReportSource = Bank;
            }
            else
            {
                Bank.SetDataSource(dt);
                Bank.SetParameterValue(0, CompanyName);
                Bank.SetParameterValue(1, CompanyAddress1);
                Bank.SetParameterValue(2, CompanyAddress2);
                Bank.SetParameterValue(3, PANNO);
                Bank.SetParameterValue(4, cashbook);
                Bank.SetParameterValue(5, From);
                Bank.SetParameterValue(6, To);
                crystalReportViewer1.ReportSource = Bank;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        Bank.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = Bank;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }
            }
        }
        public void StockRegister1(string current_company, DataTable dt, string address, string address1, string PANNO, string Phone, string Duration, int pn)
        {
            CrystalRptsal Bank = new CrystalRptsal();
            if (pn == 1)
            {
                Bank.SetDataSource(dt);
                Bank.SetParameterValue(0, current_company);
                Bank.SetParameterValue(1, address);
                Bank.SetParameterValue(2, address1);
                Bank.SetParameterValue(3, PANNO);
                Bank.SetParameterValue(4, Phone);
                Bank.SetParameterValue(5, Duration);
                crystalReportViewer1.ReportSource = Bank;
            }
            else
            {
                Bank.SetDataSource(dt);
                Bank.SetParameterValue(0, current_company);
                Bank.SetParameterValue(1, address);
                Bank.SetParameterValue(2, address1);
                Bank.SetParameterValue(3, PANNO);
                Bank.SetParameterValue(4, Phone);
                Bank.SetParameterValue(5, Duration);
                //crystalReportViewer1.ReportSource = Bank;
                crystalReportViewer1.PrintReport();
                try
                {
                    Bank.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    Bank.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = Bank;
                }
                catch { }
            }
        }
         public void StockRegister(string current_company,DataTable dt, string address, string address1, string PANNO, string Phone, string Duration, int pn)
         {
             CrystalRptRegister Bank = new CrystalRptRegister();
            if (pn == 1)
            {
                Bank.SetDataSource(dt);
                Bank.SetParameterValue(0, current_company);
                Bank.SetParameterValue(1, address);
                Bank.SetParameterValue(2, address1);
                Bank.SetParameterValue(3, PANNO);
                Bank.SetParameterValue(4, Phone);
                Bank.SetParameterValue(5, Duration);              
                crystalReportViewer1.ReportSource = Bank;
            }
            else
            {
                Bank.SetDataSource(dt);                
                Bank.SetParameterValue(0, current_company);
                Bank.SetParameterValue(1, address);
                Bank.SetParameterValue(2, address1);
                Bank.SetParameterValue(3, PANNO);
                Bank.SetParameterValue(4, Phone);
                Bank.SetParameterValue(5, Duration);   
                //crystalReportViewer1.ReportSource = Bank;
                crystalReportViewer1.PrintReport();                
                try
                {
                    Bank.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    Bank.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = Bank;
                }
                catch { }
            }
        }
         
        public void cashbank(string company, DataTable dt, string DURATION, string address, string address1, string pan, string Bank1, string Bank2, string Bank3, string Bank4, string Bank5, string Bank6, int stp)
        {
            CrystalRptCashBank CB = new CrystalRptCashBank();

            if (stp == 1)
            {
                CB.SetDataSource(dt);
                CB.SetParameterValue(0, company);
                CB.SetParameterValue(1, DURATION);
                CB.SetParameterValue(2, address);
                CB.SetParameterValue(3, address1);
                CB.SetParameterValue(4, pan);
                CB.SetParameterValue(5, Bank1);
                CB.SetParameterValue(6, Bank2);
                CB.SetParameterValue(7, Bank3);
                CB.SetParameterValue(8, Bank4);
                CB.SetParameterValue(9, Bank5);
                CB.SetParameterValue(10, Bank6);

                crystalReportViewer1.ReportSource = CB;
            }
            else
            {
                CB.SetDataSource(dt);
                CB.SetParameterValue(0, company);
                CB.SetParameterValue(1, DURATION);
                CB.SetParameterValue(2, address);
                CB.SetParameterValue(3, address1);
                CB.SetParameterValue(4, pan);
                CB.SetParameterValue(5, Bank1);
                CB.SetParameterValue(6, Bank2);
                CB.SetParameterValue(7, Bank3);
                CB.SetParameterValue(8, Bank4);
                CB.SetParameterValue(9, Bank5);
                CB.SetParameterValue(10, Bank6);

                crystalReportViewer1.ReportSource = CB;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        CB.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = CB;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }
            }
        }
        public void Accsellbillfull(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, string LorryNo, string TinNo, string VatAmtWord, string amountlen, string Details2, string Details3, string Tax, string header, string foder, string duedate, string ordertext, string orderno, string cstdec, string document, int stp)
        {          
            CrystalRpraccordsellbill bill = new CrystalRpraccordsellbill();
            if (stp == 1)
            {
                string co = "For  " + companyName;
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
                bill.SetParameterValue(14, LorryNo);
                bill.SetParameterValue(15, TinNo);
                bill.SetParameterValue(16, VatAmtWord);
                bill.SetParameterValue(17, amountlen);
                bill.SetParameterValue(18, Details2);
                bill.SetParameterValue(19, Details3);
                bill.SetParameterValue(20, Tax);
                bill.SetParameterValue(21, header);
                bill.SetParameterValue(22, foder);
                bill.SetParameterValue(23, duedate);
                bill.SetParameterValue(24, orderno);
                bill.SetParameterValue(25, ordertext);
                bill.SetParameterValue(26, cstdec);
                bill.SetParameterValue(27, co);
                bill.SetParameterValue(28, document);
                if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='4.15.18.01' ") == "TRUE")
                {
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["document1"].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["companyName1"].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["addre1"].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["add11"].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["panno1"].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                }
                else if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='4.15.18.02' ") == "TRUE")
                {
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["document1"].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["companyName1"].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["addre1"].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["add11"].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["panno1"].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                }
                else if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='4.15.18.03' ") == "TRUE")
                {
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["document1"].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["companyName1"].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["addre1"].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["add11"].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["panno1"].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                }

                //PictureBox pb = new PictureBox();
                //pb.Image = new Bitmap("C:\\Documents and Settings\\PradiptaNT\\Desktop\\about us.jpg");

                //bill.ReportDefinition.Sections["Section2"].ReportObjects["pb"].Left = 24;
                //bill.ReportDefinition.Sections["Section2"].ReportObjects["pb"].Top = 28;
                //bill.ReportDefinition.Sections["Section2"].ReportObjects["pb"].Width = 11;

                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                string co = "For  " + companyName;
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
                bill.SetParameterValue(14, LorryNo);
                bill.SetParameterValue(15, TinNo);
                bill.SetParameterValue(16, VatAmtWord);
                bill.SetParameterValue(17, amountlen);
                bill.SetParameterValue(18, Details2);
                bill.SetParameterValue(19, Details3);
                bill.SetParameterValue(20, Tax);
                bill.SetParameterValue(21, header);
                bill.SetParameterValue(22, foder);
                bill.SetParameterValue(23, duedate);
                bill.SetParameterValue(24, orderno);
                bill.SetParameterValue(25, ordertext);
                bill.SetParameterValue(26, cstdec);
                bill.SetParameterValue(27, co);
                bill.SetParameterValue(28, document);

                if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='4.15.18.01' ") == "TRUE")
                {
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["document1"].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["companyName1"].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["addre1"].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["add11"].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["panno1"].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                }
                else if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='4.15.18.02' ") == "TRUE")
                {
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["document1"].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["companyName1"].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["addre1"].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["add11"].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["panno1"].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                }
                else if (edpcom.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' and seriesno='4.15.18.03' ") == "TRUE")
                {
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["document1"].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["companyName1"].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["addre1"].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["add11"].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["panno1"].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                }
                
                bill.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = bill;
                //crystalReportViewer1.PrintReport();
            }
        }
        public void sellVat(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, int stp)
        {
            CrystalRptsalesvatreg bill = new CrystalRptsalesvatreg();
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

                bill.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                bill.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = bill;
                crystalReportViewer1.PrintReport();
            }
        }

        public void Papersheet(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string BillDate, string User_Voucher, string Tin, int stp)
        {
            CrystalRptPaperSheet PS = new CrystalRptPaperSheet();
            if (stp == 1)
            {
                PS.SetDataSource(dtshow);
                PS.SetParameterValue(0, companyName);
                PS.SetParameterValue(1, addre);
                PS.SetParameterValue(2, panno);
                PS.SetParameterValue(3, dura);
                PS.SetParameterValue(4, add1);
                PS.SetParameterValue(5, company);
                PS.SetParameterValue(6, Agentadd);
                PS.SetParameterValue(7, Agentadd1);
                PS.SetParameterValue(8, BillDate);
                PS.SetParameterValue(9, User_Voucher);
                PS.SetParameterValue(10, Tin);

                crystalReportViewer1.ReportSource = PS;
            }
            else
            {              
                PS.SetDataSource(dtshow);
                PS.SetParameterValue(0, companyName);
                PS.SetParameterValue(1, addre);
                PS.SetParameterValue(2, panno);
                PS.SetParameterValue(3, dura);
                PS.SetParameterValue(4, add1);
                PS.SetParameterValue(5, company);
                PS.SetParameterValue(6, Agentadd);
                PS.SetParameterValue(7, Agentadd1);
                PS.SetParameterValue(8, BillDate);
                PS.SetParameterValue(9, User_Voucher);
                PS.SetParameterValue(10, Tin);
                crystalReportViewer1.ReportSource = PS;

                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        PS.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = PS;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }

            }
        }

        public void threeinch(string companyName, DataTable dtshow, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string BillDate, string User_Voucher, string AmtWord, string amountlen, string VatAmt, string vat, string footer, string header, int stp)
        {
            CrystalRpt3incAccordSellBill bill = new CrystalRpt3incAccordSellBill();
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
                bill.SetParameterValue(7, BillDate);
                bill.SetParameterValue(8, User_Voucher);
                bill.SetParameterValue(9, AmtWord);
                bill.SetParameterValue(10, amountlen);
                bill.SetParameterValue(11, VatAmt);
                bill.SetParameterValue(12, vat);
                bill.SetParameterValue(13, footer);
                bill.SetParameterValue(14, header);

                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetDataSource(dtshow);
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, panno);
                bill.SetParameterValue(3, add1);
                bill.SetParameterValue(4, company);
                bill.SetParameterValue(5, Agentadd);
                bill.SetParameterValue(6, Agentadd1);
                bill.SetParameterValue(7, BillDate);
                bill.SetParameterValue(8, User_Voucher);
                bill.SetParameterValue(9, AmtWord);
                bill.SetParameterValue(10, amountlen);
                bill.SetParameterValue(11, VatAmt);
                bill.SetParameterValue(12, vat);
                bill.SetParameterValue(13, footer);
                bill.SetParameterValue(14, header);
                bill.PrintToPrinter(1, true, 1, 1);
                crystalReportViewer1.PrintReport();
            }
        }

        public void Challan(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, string Tan, string amount, string challandt, string ConName, string ConAdd, string ConAdd1, int stp)
        {
            if (edpcom.EnvironMent_Envelope == "PRINTING")
            {
                ConAdd ="TOTAL VOLUME";
                ConAdd1 = "QUANTITY";
            }
            else
            {
                ConAdd = "QUANTITY";
                ConAdd1 = "RATE";
            }

            CrystalRptChallan bill = new CrystalRptChallan();
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
                bill.SetParameterValue(14, Tan);
                bill.SetParameterValue(15, amount);
                bill.SetParameterValue(16, challandt);
                bill.SetParameterValue(17, ConName);
                bill.SetParameterValue(18, ConAdd);
                bill.SetParameterValue(19, ConAdd1);
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
                bill.SetParameterValue(14, Tan);
                bill.SetParameterValue(15, amount);
                bill.SetParameterValue(16, challandt);
                bill.SetParameterValue(17, ConName);
                bill.SetParameterValue(18, ConAdd);
                bill.SetParameterValue(19, ConAdd1);

                crystalReportViewer1.ReportSource = bill;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        bill.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bill;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }              
            }
        }

        public void Dyeningchallan(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string tin, string tqty, string tpqty, int stp)
        {
            CrystalRptDyeingchallan bill = new CrystalRptDyeingchallan();
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
                bill.SetParameterValue(13, tin);
                bill.SetParameterValue(14, tqty);
                bill.SetParameterValue(15, tpqty);

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
                bill.SetParameterValue(13, tin);
                bill.SetParameterValue(14, tqty);
                bill.SetParameterValue(15, tpqty);
                crystalReportViewer1.ReportSource = bill;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        bill.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bill;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }
            }
        }

        //added by rupak,anirban on 06.08.2012.................
        public void grn_print(string CompanyName, DataTable billng, string duration, string addr, string panno, string addr1, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string tin1, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin,string Narration, int stp)
        {
            CrystalRptGRN grn = new CrystalRptGRN();
            if (stp == 1)
            {
                grn.SetDataSource(billng);
                grn.SetParameterValue(0, CompanyName);
                grn.SetParameterValue(1, duration);
                grn.SetParameterValue(2, addr);
                grn.SetParameterValue(3, panno);
                grn.SetParameterValue(4, addr1);
                grn.SetParameterValue(5, agentcompany);
                grn.SetParameterValue(6, agentaddr);
                grn.SetParameterValue(7, agentaddr1);
                grn.SetParameterValue(8, phone);
                grn.SetParameterValue(9, area);
                grn.SetParameterValue(10, billdt);
                grn.SetParameterValue(11, uservouchar);
                grn.SetParameterValue(12, challan);
                grn.SetParameterValue(13, amtword);
                grn.SetParameterValue(14, tin1);
                grn.SetParameterValue(15, finalamt);
                grn.SetParameterValue(16, challandt);
                grn.SetParameterValue(17, amtvalue);
                grn.SetParameterValue(18, lorry_no);
                grn.SetParameterValue(19, locname);
                grn.SetParameterValue(20, modtran);
                grn.SetParameterValue(21, prtyname);
                grn.SetParameterValue(22, prtyadd1);
                grn.SetParameterValue(23, prtyadd2);
                grn.SetParameterValue(24, prtycity);
                grn.SetParameterValue(25, prtycitypinno);
                grn.SetParameterValue(26, prtytele1);
                grn.SetParameterValue(27, prtytele2);
                grn.SetParameterValue(28, prtyemailid);
                grn.SetParameterValue(29, prtyfax);
                grn.SetParameterValue(30, prtyeccno);
                grn.SetParameterValue(31, prtytin);
                grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;
            }
            else
            {
                grn.SetDataSource(billng);
                grn.SetParameterValue(0, CompanyName);
                grn.SetParameterValue(1, duration);
                grn.SetParameterValue(2, addr);
                grn.SetParameterValue(3, panno);
                grn.SetParameterValue(4, addr1);
                grn.SetParameterValue(5, agentcompany);
                grn.SetParameterValue(6, agentaddr);
                grn.SetParameterValue(7, agentaddr1);
                grn.SetParameterValue(8, phone);
                grn.SetParameterValue(9, area);
                grn.SetParameterValue(10, billdt);
                grn.SetParameterValue(11, uservouchar);
                grn.SetParameterValue(12, challan);
                grn.SetParameterValue(13, amtword);
                grn.SetParameterValue(14, tin1);
                grn.SetParameterValue(15, finalamt);
                grn.SetParameterValue(16, challandt);
                grn.SetParameterValue(17, amtvalue);
                grn.SetParameterValue(18, lorry_no);
                grn.SetParameterValue(19, locname);
                grn.SetParameterValue(20, modtran);
                grn.SetParameterValue(21, prtyname);
                grn.SetParameterValue(22, prtyadd1);
                grn.SetParameterValue(23, prtyadd2);
                grn.SetParameterValue(24, prtycity);
                grn.SetParameterValue(25, prtycitypinno);
                grn.SetParameterValue(26, prtytele1);
                grn.SetParameterValue(27, prtytele2);
                grn.SetParameterValue(28, prtyemailid);
                grn.SetParameterValue(29, prtyfax);
                grn.SetParameterValue(30, prtyeccno);
                grn.SetParameterValue(31, prtytin);
                grn.SetParameterValue(32, Narration);
                try
                {
                    grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }


        //ended by anirban,Rupak...........................................
        //added by rupak,anirban on 06.08.2012  purchaseorder.................
        public void po_order(string current_company, DataTable billng11, string brnadd, string brncity, string brnpin, string brnphone1, string brnphone2, string brnphone3, string brnfax, string email, string brnvttin, string brncsttin, string panno, string eccno, string brncomm, string brndiv, string brnrange, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtyphone1, string prtyphone2, string prtyphone3, string prtytin, string modstrnport, string locname, string locremarks, string contcprsn, string phno, string pan1, string prtyctypin, string narrsnn, string orderno, string orderdate, string attnsnprsn, string personphnno,string brncitypagefter, string lphn1, string lphn2, string lphn3, string lfax, string prdby, string locrmrkspgefter, string webste, string qtnno, string qtndate,string tax, int stp)
        {
            brncity = "For " + current_company;
            
            //CrystalReporttestani porder12 = new CrystalReporttestani();
            CrystalRptpurchaseorder porder12 = new CrystalRptpurchaseorder();
            if (stp == 1)
            {
                porder12.SetDataSource(billng11);
                porder12.SetParameterValue(0, current_company);
                porder12.SetParameterValue(1, brnadd);
                porder12.SetParameterValue(2, brncity);
                porder12.SetParameterValue(3, brnpin);
                porder12.SetParameterValue(4, brnphone1);
                porder12.SetParameterValue(5, brnphone2);
                porder12.SetParameterValue(6, brnphone3);
                porder12.SetParameterValue(7, brnfax);
                porder12.SetParameterValue(8, email);
                porder12.SetParameterValue(9, brnvttin);
                porder12.SetParameterValue(10, brncsttin);
                porder12.SetParameterValue(11, panno);
                porder12.SetParameterValue(12, eccno);
                porder12.SetParameterValue(13, brncomm);
                porder12.SetParameterValue(14, brndiv);
                porder12.SetParameterValue(15, brnrange);
                porder12.SetParameterValue(16, prtyname);
                porder12.SetParameterValue(17, prtyadd1);
                porder12.SetParameterValue(18, prtyadd2);
                porder12.SetParameterValue(19, prtycity);
                porder12.SetParameterValue(20, prtyphone1);
                porder12.SetParameterValue(21, prtyphone2);
                porder12.SetParameterValue(22, prtyphone3);
                porder12.SetParameterValue(23, prtytin);
                porder12.SetParameterValue(24, modstrnport);
                porder12.SetParameterValue(25, locname);
                porder12.SetParameterValue(26, locremarks);
                porder12.SetParameterValue(27, contcprsn);
                porder12.SetParameterValue(28, phno);
                porder12.SetParameterValue(29, pan1);
                porder12.SetParameterValue(30, prtyctypin);
                porder12.SetParameterValue(31, narrsnn);
                porder12.SetParameterValue(32, orderno);
                porder12.SetParameterValue(33, orderdate);
                porder12.SetParameterValue(34, attnsnprsn);
                porder12.SetParameterValue(35, personphnno);
                //porder12.SetParameterValue(36, amtword);
                //porder12.SetParameterValue(37, amtvalue);
                porder12.SetParameterValue(38, brncitypagefter);
                porder12.SetParameterValue(39, lphn1);
                porder12.SetParameterValue(40, lphn2);
                porder12.SetParameterValue(41, lphn3);
                porder12.SetParameterValue(42, lfax);
                porder12.SetParameterValue(43, prdby);
                porder12.SetParameterValue(44, locrmrkspgefter);
                porder12.SetParameterValue(45, webste);
                porder12.SetParameterValue(46, qtnno);
                porder12.SetParameterValue(47, qtndate);
                porder12.SetParameterValue(48, tax);
                crystalReportViewer1.ReportSource = porder12;              
            }
            else
            {
                porder12.SetDataSource(billng11);
                porder12.SetParameterValue(0, current_company);
                porder12.SetParameterValue(1, brnadd);
                porder12.SetParameterValue(2, brncity);
                porder12.SetParameterValue(3, brnpin);
                porder12.SetParameterValue(4, brnphone1);
                porder12.SetParameterValue(5, brnphone2);
                porder12.SetParameterValue(6, brnphone3);
                porder12.SetParameterValue(7, brnfax);
                porder12.SetParameterValue(8, email);
                porder12.SetParameterValue(9, brnvttin);
                porder12.SetParameterValue(10, brncsttin);
                porder12.SetParameterValue(11, panno);
                porder12.SetParameterValue(12, eccno);
                porder12.SetParameterValue(13, brncomm);
                porder12.SetParameterValue(14, brndiv);
                porder12.SetParameterValue(15, brnrange);
                porder12.SetParameterValue(16, prtyname);
                porder12.SetParameterValue(17, prtyadd1);
                porder12.SetParameterValue(18, prtyadd2);
                porder12.SetParameterValue(19, prtycity);
                porder12.SetParameterValue(20, prtyphone1);
                porder12.SetParameterValue(21, prtyphone2);
                porder12.SetParameterValue(22, prtyphone3);
                porder12.SetParameterValue(23, prtytin);
                porder12.SetParameterValue(24, modstrnport);
                porder12.SetParameterValue(25, locname);
                porder12.SetParameterValue(26, locremarks);
                porder12.SetParameterValue(27, contcprsn);
                porder12.SetParameterValue(28, phno);
                porder12.SetParameterValue(29, pan1);
                porder12.SetParameterValue(30, prtyctypin);
                porder12.SetParameterValue(31, narrsnn);
                porder12.SetParameterValue(32, orderno);
                porder12.SetParameterValue(33, orderdate);
                porder12.SetParameterValue(34, attnsnprsn);
                porder12.SetParameterValue(35, personphnno);
                //porder12.SetParameterValue(36, amtword);
                //porder12.SetParameterValue(37, amtvalue);
                porder12.SetParameterValue(38, brncitypagefter);
                porder12.SetParameterValue(39, lphn1);
                porder12.SetParameterValue(40, lphn2);
                porder12.SetParameterValue(41, lphn3);
                porder12.SetParameterValue(42, lfax);
                porder12.SetParameterValue(43, prdby);
                porder12.SetParameterValue(44, locrmrkspgefter);
                porder12.SetParameterValue(45, webste);
                porder12.SetParameterValue(46, qtnno);
                porder12.SetParameterValue(47, qtndate);
                porder12.SetParameterValue(48, tax);
                crystalReportViewer1.ReportSource = porder12;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        porder12.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = porder12;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }     

                //ended by anirban,Rupak...........................................

            }

        }

        public void indent(string compname, DataTable indent, string comadd, string cmpcty, string ctypin, string cratdby, string cmpname_rptftr, string indntdt, string indntno, string sec, string bunitname, string narr, string bunitrmrks, int stp)
        {
            CrystalReportINTENT abc = new CrystalReportINTENT();
            if (stp == 1)
            {
                abc.SetDataSource(indent);
                abc.SetParameterValue(0, compname);
                abc.SetParameterValue(1, comadd);
                abc.SetParameterValue(2, cmpcty);
                abc.SetParameterValue(3, ctypin);
                abc.SetParameterValue(4, cratdby);
                abc.SetParameterValue(5, cmpname_rptftr);
                abc.SetParameterValue(6, indntdt);
                abc.SetParameterValue(7, indntno);
                abc.SetParameterValue(8, sec);
                abc.SetParameterValue(9, bunitname);
                abc.SetParameterValue(10, narr);
                abc.SetParameterValue(11, bunitrmrks);
                crystalReportViewer1.ReportSource = abc;
            }
            else
            {

                abc.SetDataSource(indent);
                abc.SetParameterValue(0, compname);
                abc.SetParameterValue(1, comadd);
                abc.SetParameterValue(2, cmpcty);
                abc.SetParameterValue(3, ctypin);
                abc.SetParameterValue(4, cratdby);
                abc.SetParameterValue(5, cmpname_rptftr);
                abc.SetParameterValue(6, indntdt);
                abc.SetParameterValue(7, indntno);
                abc.SetParameterValue(8, sec);
                abc.SetParameterValue(9, bunitname);
                //abc.SetParameterValue(10, bunitrmrks);
                abc.SetParameterValue(10, narr);
                abc.SetParameterValue(11, bunitrmrks);
                crystalReportViewer1.ReportSource = abc;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        abc.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = abc;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }     

            }
        }
        public void abcd_def(string companyName, DataTable Dailysalereg, string DURATION, string addre, string panno, string add1, string str44, string str45, string str46, int stp)
        {
            CrystalReportdaily ag = new CrystalReportdaily();
            try
            {

                if (stp == 1)
                {
                    ag.SetDataSource(Dailysalereg);
                    ag.SetParameterValue(0, companyName);
                    ag.SetParameterValue(1, DURATION);
                    // ag.SetParameterValue(2, To);
                    ag.SetParameterValue(2, addre);
                    ag.SetParameterValue(3, panno);
                    ag.SetParameterValue(4, add1);
                    ag.SetParameterValue(5, str44);
                    ag.SetParameterValue(6, str45);
                    ag.SetParameterValue(7, str46);



                    crystalReportViewer1.ReportSource = ag;
                }
                else
                {
                    ag.SetDataSource(Dailysalereg);
                    ag.SetParameterValue(0, companyName);
                    ag.SetParameterValue(1, DURATION);
                    //ag.SetParameterValue(2, To);
                    ag.SetParameterValue(2, addre);
                    ag.SetParameterValue(3, panno);
                    ag.SetParameterValue(4, add1);
                    ag.SetParameterValue(5, str44);
                    ag.SetParameterValue(6, str45);
                    ag.SetParameterValue(7, str46);

                    crystalReportViewer1.ReportSource = ag;
                    if (edpcom.EnvironMent_Bittype == "64")
                    {
                        try
                        {
                            ag.PrintToPrinter(1, false, 0, 0);
                            crystalReportViewer1.ReportSource = ag;
                        }
                        catch { }
                    }
                    else
                    {
                        crystalReportViewer1.PrintReport();
                    }     
                }
            }
            catch { }
        }

        public void ChqPrintOriental(string companyName, string Date, string amt, string amtword, string acno, string partyname, string print_text, int stp, DataTable ChkSetting)
        {           
            CrystalRptChqOriental CO = new CrystalRptChqOriental();
            try
            {
                if (stp == 1)
                {
                    amt = "**"+ amt +"**"; 
                    //CO.SetParameterValue(0, companyName);                  
                    CO.SetParameterValue(0, Convert.ToString(ChkSetting.Rows[0]["PRINT_CO_NAME"]));                  
                    CO.SetParameterValue(1, Date);
                    CO.SetParameterValue(2, amt);
                    CO.SetParameterValue(3, amtword);
                    if (Convert.ToBoolean(ChkSetting.Rows[0]["WITH_AC_NO"]) == false)
                        acno = "";
                    CO.SetParameterValue(4, acno);
                    CO.SetParameterValue(5, partyname);
                    //CO.SetParameterValue(6, print_text);
                    CO.SetParameterValue(6, Convert.ToString(ChkSetting.Rows[0]["PRINT_TEXT"]));                    

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Date1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["DATE_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Date1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["DATE_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Date1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["DATE_WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["partyname1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["PAYTOLINE1_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["partyname1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["PAYTOLINE1_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["partyname1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["PAYTOLINE1_WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amtword1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["AMTINWORDS1_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amtword1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["AMTINWORDS1_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amtword1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["AMTINWORDS1_WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["acno1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["AC_NO_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["acno1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["AC_NO_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["acno1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["AC_NO_WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Text4"].Left = Convert.ToInt32(ChkSetting.Rows[0]["AC_PAYEE_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Text4"].Top = Convert.ToInt32(ChkSetting.Rows[0]["AC_PAYEE_TOP"]) * 50;//companyName1

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["companyName1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["PRINT_CO_NAME_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["companyName1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["PRINT_CO_NAME_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["companyName1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["PRINT_CO_NAME__WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = Convert.ToInt32(ChkSetting.Rows[0]["NOTOVERSTATEMENT_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Top = Convert.ToInt32(ChkSetting.Rows[0]["NOTOVERSTATEMENT_TOP"]) * 50;
                    //CO.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = Convert.ToInt32(ChkSetting.Rows[0]["NOTOVERSTATEMENT_WIDTH"]) * 100;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amt1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["CHEQUE_AMT_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amt1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["CHEQUE_AMT_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amt1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["CHEQUE_AMT_WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["printtext1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["PRINT_TEXT_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["printtext1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["PRINT_TEXT_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["printtext1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["PRINT_TEXT_WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amt2"].Left = CO.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left + CO.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width + 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amt2"].Top = Convert.ToInt32(ChkSetting.Rows[0]["NOTOVERSTATEMENT_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amt2"].Width = Convert.ToInt32(ChkSetting.Rows[0]["CHEQUE_AMT_WIDTH"]) * 50;

                    crystalReportViewer1.ReportSource = CO;
                    // crystalReportViewer1.PrintReport();
                }
                else
                {
                    //CO.SetParameterValue(0, companyName);    
                    amt = "** "+ amt +" **"; 
                    CO.SetParameterValue(0, Convert.ToString(ChkSetting.Rows[0]["PRINT_CO_NAME"]));
                    CO.SetParameterValue(1, Date);
                    CO.SetParameterValue(2, amt);
                    CO.SetParameterValue(3, amtword);
                    if (Convert.ToBoolean(ChkSetting.Rows[0]["WITH_AC_NO"]) == false)
                        acno = "";
                    CO.SetParameterValue(4, acno);
                    CO.SetParameterValue(5, partyname);
                    //CO.SetParameterValue(6, print_text);
                    CO.SetParameterValue(6, Convert.ToString(ChkSetting.Rows[0]["PRINT_TEXT"]));
                    
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Date1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["DATE_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Date1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["DATE_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Date1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["DATE_WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["partyname1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["PAYTOLINE1_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["partyname1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["PAYTOLINE1_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["partyname1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["PAYTOLINE1_WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amtword1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["AMTINWORDS1_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amtword1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["AMTINWORDS1_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amtword1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["AMTINWORDS1_WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["acno1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["AC_NO_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["acno1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["AC_NO_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["acno1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["AC_NO_WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Text4"].Left = Convert.ToInt32(ChkSetting.Rows[0]["AC_PAYEE_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Text4"].Top = Convert.ToInt32(ChkSetting.Rows[0]["AC_PAYEE_TOP"]) * 50;//companyName1

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["companyName1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["PRINT_CO_NAME_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["companyName1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["PRINT_CO_NAME_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["companyName1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["PRINT_CO_NAME__WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = Convert.ToInt32(ChkSetting.Rows[0]["NOTOVERSTATEMENT_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Top = Convert.ToInt32(ChkSetting.Rows[0]["NOTOVERSTATEMENT_TOP"]) * 50;
                    //CO.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = Convert.ToInt32(ChkSetting.Rows[0]["NOTOVERSTATEMENT_WIDTH"]) * 100;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amt1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["CHEQUE_AMT_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amt1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["CHEQUE_AMT_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amt1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["CHEQUE_AMT_WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["printtext1"].Left = Convert.ToInt32(ChkSetting.Rows[0]["PRINT_TEXT_LEFT"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["printtext1"].Top = Convert.ToInt32(ChkSetting.Rows[0]["PRINT_TEXT_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["printtext1"].Width = Convert.ToInt32(ChkSetting.Rows[0]["PRINT_TEXT_WIDTH"]) * 50;

                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amt2"].Left = CO.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left + CO.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width + 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amt2"].Top = Convert.ToInt32(ChkSetting.Rows[0]["NOTOVERSTATEMENT_TOP"]) * 50;
                    CO.ReportDefinition.Sections["Section2"].ReportObjects["amt2"].Width = Convert.ToInt32(ChkSetting.Rows[0]["CHEQUE_AMT_WIDTH"]) * 50;


                    crystalReportViewer1.ReportSource = CO;
                    if (edpcom.EnvironMent_Bittype == "64")
                    {
                        try
                        {
                            CO.PrintToPrinter(1, false, 0, 0);
                            crystalReportViewer1.ReportSource = CO;
                        }
                        catch { }
                    }
                    else
                    {
                        crystalReportViewer1.PrintReport();
                    }     
                }
            }
            catch { }
        }

        public void ChqPrintOriental1(string companyName, string Date, string amt, string amtword, string acno, string partyname, string print_text, int stp)
        {

            CrystalRptCheqfromat1 CO = new CrystalRptCheqfromat1();
            try
            {
                if (stp == 1)
                {
                    CO.SetParameterValue(0, companyName);
                    CO.SetParameterValue(1, Date);
                    CO.SetParameterValue(2, amt);
                    CO.SetParameterValue(3, amtword);
                    CO.SetParameterValue(4, acno);
                    CO.SetParameterValue(5, partyname);
                    CO.SetParameterValue(6, print_text);
                    crystalReportViewer1.ReportSource = CO;
                    // crystalReportViewer1.PrintReport();
                }
                else
                {
                    CO.SetParameterValue(0, companyName);
                    CO.SetParameterValue(1, Date);
                    CO.SetParameterValue(2, amt);
                    CO.SetParameterValue(3, amtword);
                    CO.SetParameterValue(4, acno);
                    CO.SetParameterValue(5, partyname);
                    CO.SetParameterValue(6, print_text);
                    crystalReportViewer1.ReportSource = CO;
                    if (edpcom.EnvironMent_Bittype == "64")
                    {
                        try
                        {
                            CO.PrintToPrinter(1, false, 0, 0);
                            crystalReportViewer1.ReportSource = CO;
                        }
                        catch { }
                    }
                    else
                    {
                        crystalReportViewer1.PrintReport();
                    }     
                }
            }
            catch { }
        }

        public void ChqPrintOriental2(string companyName, string Date, string amt, string amtword, string acno, string partyname, string print_text, int stp)
        {
            CrystalRptCheqfromat2 CO = new CrystalRptCheqfromat2();
            try
            {
                if (stp == 1)
                {
                    CO.SetParameterValue(0, companyName);
                    CO.SetParameterValue(1, Date);
                    CO.SetParameterValue(2, amt);
                    CO.SetParameterValue(3, amtword);
                    CO.SetParameterValue(4, acno);
                    CO.SetParameterValue(5, partyname);
                    CO.SetParameterValue(6, print_text);
                    crystalReportViewer1.ReportSource = CO;
                    // crystalReportViewer1.PrintReport();
                }
                else
                {
                    CO.SetParameterValue(0, companyName);
                    CO.SetParameterValue(1, Date);
                    CO.SetParameterValue(2, amt);
                    CO.SetParameterValue(3, amtword);
                    CO.SetParameterValue(4, acno);
                    CO.SetParameterValue(5, partyname);
                    CO.SetParameterValue(6, print_text);
                    crystalReportViewer1.ReportSource = CO;
                    if (edpcom.EnvironMent_Bittype == "64")
                    {
                        try
                        {
                            CO.PrintToPrinter(1, false, 0, 0);
                            crystalReportViewer1.ReportSource = CO;
                        }
                        catch { }
                    }
                    else
                    {
                        crystalReportViewer1.PrintReport();
                    }     
                }
            }
            catch { }
        }

        public void ChqPrintOriental3(string companyName, string Date, string amt, string amtword, string acno, string partyname, string print_text, int stp)
        {

            CrystalRptCheqfromat3 CO = new CrystalRptCheqfromat3();
            try
            {
                if (stp == 1)
                {
                    CO.SetParameterValue(0, companyName);
                    CO.SetParameterValue(1, Date);
                    CO.SetParameterValue(2, amt);
                    CO.SetParameterValue(3, amtword);
                    CO.SetParameterValue(4, acno);
                    CO.SetParameterValue(5, partyname);
                    CO.SetParameterValue(6, print_text);
                    crystalReportViewer1.ReportSource = CO;
                    // crystalReportViewer1.PrintReport();
                }
                else
                {
                    CO.SetParameterValue(0, companyName);
                    CO.SetParameterValue(1, Date);
                    CO.SetParameterValue(2, amt);
                    CO.SetParameterValue(3, amtword);
                    CO.SetParameterValue(4, acno);
                    CO.SetParameterValue(5, partyname);
                    CO.SetParameterValue(6, print_text);
                    crystalReportViewer1.ReportSource = CO;
                    if (edpcom.EnvironMent_Bittype == "64")
                    {
                        try
                        {
                            CO.PrintToPrinter(1, false, 0, 0);
                            crystalReportViewer1.ReportSource = CO;
                        }
                        catch { }
                    }
                    else
                    {
                        crystalReportViewer1.PrintReport();
                    }     
                }
            }
            catch { }
        }

        public void ChqPrintOriental4(string companyName, string Date, string amt, string amtword, string acno, string partyname, string print_text, int stp)
        {

            CrystalRptCheqfromat4 CO = new CrystalRptCheqfromat4();
            try
            {
                if (stp == 1)
                {
                    CO.SetParameterValue(0, companyName);
                    CO.SetParameterValue(1, Date);
                    CO.SetParameterValue(2, amt);
                    CO.SetParameterValue(3, amtword);
                    CO.SetParameterValue(4, acno);
                    CO.SetParameterValue(5, partyname);
                    CO.SetParameterValue(6, print_text);
                    crystalReportViewer1.ReportSource = CO;
                    // crystalReportViewer1.PrintReport();
                }
                else
                {
                    CO.SetParameterValue(0, companyName);
                    CO.SetParameterValue(1, Date);
                    CO.SetParameterValue(2, amt);
                    CO.SetParameterValue(3, amtword);
                    CO.SetParameterValue(4, acno);
                    CO.SetParameterValue(5, partyname);
                    CO.SetParameterValue(6, print_text);
                    crystalReportViewer1.ReportSource = CO;
                    if (edpcom.EnvironMent_Bittype == "64")
                    {
                        try
                        {
                            CO.PrintToPrinter(1, false, 0, 0);
                            crystalReportViewer1.ReportSource = CO;
                        }
                        catch { }
                    }
                    else
                    {
                        crystalReportViewer1.PrintReport();
                    }     
                }
            }
            catch { }
        }

        public void ChqPrintOriental5(string companyName, string Date, string amt, string amtword, string acno, string partyname, string print_text, int stp)
        {

            CrystalRptCheqfromat5 CO = new CrystalRptCheqfromat5();
            try
            {
                if (stp == 1)
                {
                    CO.SetParameterValue(0, companyName);
                    CO.SetParameterValue(1, Date);
                    CO.SetParameterValue(2, amt);
                    CO.SetParameterValue(3, amtword);
                    CO.SetParameterValue(4, acno);
                    CO.SetParameterValue(5, partyname);
                    CO.SetParameterValue(6, print_text);
                    crystalReportViewer1.ReportSource = CO;
                    // crystalReportViewer1.PrintReport();
                }
                else
                {
                    CO.SetParameterValue(0, companyName);
                    CO.SetParameterValue(1, Date);
                    CO.SetParameterValue(2, amt);
                    CO.SetParameterValue(3, amtword);
                    CO.SetParameterValue(4, acno);
                    CO.SetParameterValue(5, partyname);
                    CO.SetParameterValue(6, print_text);
                    crystalReportViewer1.ReportSource = CO;
                    if (edpcom.EnvironMent_Bittype == "64")
                    {
                        try
                        {
                            CO.PrintToPrinter(1, false, 0, 0);
                            crystalReportViewer1.ReportSource = CO;
                        }
                        catch { }
                    }
                    else
                    {
                        crystalReportViewer1.PrintReport();
                    }     
                }
            }
            catch { }
        }

        //private CrystalDecisions.Shared.ParameterField SizeFromClientSize(int p, int p_2)
        //{CrystalRptCheqfromat1
        //    throw new Exception("The method or operation is not implemented.");
        //}

        public void finish13(string companyName, DataTable finishstk, string DURATION, string compadd, string compcity, string citypin, string comptele1, string compfax, string compemail, string compstate, int stp)
        {
            Crystalrptfinish bal = new Crystalrptfinish();

            if (stp == 1)
            {
                bal.SetDataSource(finishstk);
                bal.SetParameterValue(0, companyName);
                bal.SetParameterValue(1, DURATION);
                bal.SetParameterValue(2, compadd);
                bal.SetParameterValue(3, compcity);
                bal.SetParameterValue(4, citypin);
                bal.SetParameterValue(5, comptele1);
                bal.SetParameterValue(6, compfax);
                bal.SetParameterValue(7, compemail);
                bal.SetParameterValue(8, compstate);

                crystalReportViewer1.ReportSource = bal;
            }
            else
            {
                bal.SetDataSource(finishstk);
                bal.SetParameterValue(0, companyName);
                bal.SetParameterValue(1, DURATION);
                bal.SetParameterValue(2, compadd);
                bal.SetParameterValue(3, compcity);
                bal.SetParameterValue(4, citypin);
                bal.SetParameterValue(5, comptele1);
                bal.SetParameterValue(6, compfax);
                bal.SetParameterValue(7, compemail);
                bal.SetParameterValue(8, compstate);

                crystalReportViewer1.ReportSource = bal;
                crystalReportViewer1.PrintReport();
                try
                {
                    bal.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    bal.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = bal;
                }
                catch { }
            }

        }

        public void VoucherT(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string voucher, string amt, string Check, string Narr, string Date, string vchname, string pan1, string pan2, string pan3, string pan4, int stp)
        {
            CrystalRptVoucherTShape vch = new CrystalRptVoucherTShape();
            if (stp == 1)
            {
                vch.SetDataSource(dtshow);
                vch.SetParameterValue(0, companyName);
                vch.SetParameterValue(1, addre);
                vch.SetParameterValue(2, panno);
                vch.SetParameterValue(3, dura);
                vch.SetParameterValue(4, add1);
                vch.SetParameterValue(5, voucher);
                vch.SetParameterValue(6, amt);
                vch.SetParameterValue(7, Check);
                vch.SetParameterValue(8, Narr);
                vch.SetParameterValue(9, Date);
                vch.SetParameterValue(10, vchname);
                vch.SetParameterValue(11, pan1);
                vch.SetParameterValue(12, pan2);
                vch.SetParameterValue(13, pan3);
                vch.SetParameterValue(14, pan4);
                //vch.SetParameterValue(15, pan5);
                //vch.SetParameterValue(16, pan6);
                //vch.SetParameterValue(17, pan7);
                //vch.SetParameterValue(18, pan8);
                if (pan1 == "" && pan2 != "" && pan3 != "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 500;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 3980;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 7481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 3480;

                }
                if (pan1 != "" && pan2 == "" && pan3 != "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 3985;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 3986;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 7487;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 3473;

                }
                if (pan1 != "" && pan2 != "" && pan3 == "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 3985;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 7487;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 7488;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 3473;

                }
                if (pan1 != "" && pan2 != "" && pan3 != "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 3985;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 7487;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 7488;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                if (pan1 == "" && pan2 == "" && pan3 != "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 482;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 5761;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 5278;

                }
                if (pan1 == "" && pan2 != "" && pan3 == "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 5759;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 5760;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 5278;

                }
                if (pan1 == "" && pan2 != "" && pan3 != "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 5759;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 5760;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                if (pan1 != "" && pan2 == "" && pan3 == "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 5758;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 5759;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 5760;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 5278;

                }
                if (pan1 != "" && pan2 != "" && pan3 == "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 5758;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 10559;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 10560;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                if (pan1 != "" && pan2 == "" && pan3 != "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 5758;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 5759;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 10560;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                if (pan1 == "" && pan2 == "" && pan3 == "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 7060;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 3500;

                }
                if (pan1 == "" && pan2 == "" && pan3 != "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 7060;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 10559;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                if (pan1 == "" && pan2 != "" && pan3 == "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 7060;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 10558;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 10559;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                if (pan1 != "" && pan2 == "" && pan3 == "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 7060;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 10557;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 10558;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 10559;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                else
                {

                }
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
                vch.SetParameterValue(6, amt);
                vch.SetParameterValue(7, Check);
                vch.SetParameterValue(8, Narr);
                vch.SetParameterValue(9, Date);
                vch.SetParameterValue(10, vchname);
                vch.SetParameterValue(11, pan1);
                vch.SetParameterValue(12, pan2);
                vch.SetParameterValue(13, pan3);
                vch.SetParameterValue(14, pan4);
                //vch.SetParameterValue(15, pan5);
                //vch.SetParameterValue(16, pan6);
                //vch.SetParameterValue(17, pan7);
                //vch.SetParameterValue(18, pan8);
                if (pan1 == "" && pan2 != "" && pan3 != "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 500;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 3980;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 7481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 3480;

                }
                if (pan1 != "" && pan2 == "" && pan3 != "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 3985;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 3986;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 7487;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 3473;

                }
                if (pan1 != "" && pan2 != "" && pan3 == "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 3985;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 7487;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 7488;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 3473;

                }
                if (pan1 != "" && pan2 != "" && pan3 != "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 3985;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 7487;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 7488;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                if (pan1 == "" && pan2 == "" && pan3 != "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 482;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 5761;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 5278;

                }
                if (pan1 == "" && pan2 != "" && pan3 == "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 5759;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 5760;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 5278;

                }
                if (pan1 == "" && pan2 != "" && pan3 != "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 5759;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 5760;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                if (pan1 != "" && pan2 == "" && pan3 == "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 5758;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 5759;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 5760;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 5278;

                }
                if (pan1 != "" && pan2 != "" && pan3 == "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 5758;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 10559;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 10560;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                if (pan1 != "" && pan2 == "" && pan3 != "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 5758;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 5759;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 5278;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 10560;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                if (pan1 == "" && pan2 == "" && pan3 == "" && pan4 != "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 7060;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 3500;

                }
                if (pan1 == "" && pan2 == "" && pan3 != "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 481;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 7060;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 10559;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                if (pan1 == "" && pan2 != "" && pan3 == "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 480;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 7060;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 10558;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 10559;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                if (pan1 != "" && pan2 == "" && pan3 == "" && pan4 == "")
                {
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Left = 7060;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["prepared1"].Width = 3500;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Left = 10557;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["sanction1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Left = 10558;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["accounts1"].Width = 0;

                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Left = 10559;
                    vch.ReportDefinition.Sections["Section4"].ReportObjects["recived1"].Width = 0;

                }
                else
                {

                }
                crystalReportViewer1.ReportSource = vch;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        vch.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = vch;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }     
            }
        }


        public void less(string current_company, DataTable Dailysalereg, string DURATION, string address, string pan, string address1, int stp)
        {
            CrystalReporless vch = new CrystalReporless();
            if (stp == 1)
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);


                crystalReportViewer1.ReportSource = vch;
            }
            else
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);

                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);

                crystalReportViewer1.ReportSource = vch;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        vch.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = vch;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }     
            }
        }
        public void invtrn(string current_company, DataTable Dailysalereg, string DURATION, string address, string pan, string address1, int stp)
        {
            CrystalReportinventorytran vch = new CrystalReportinventorytran();
            if (stp == 1)
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);


                crystalReportViewer1.ReportSource = vch;
            }
            else
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);

                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);

                crystalReportViewer1.ReportSource = vch;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        vch.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = vch;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }     
            }
        }

        public void inout(string current_company, DataTable Dailysalereg, string DURATION, string address, string pan, string address1, int stp)
        {
            Crystalrptinoutvat vch = new Crystalrptinoutvat();
            if (stp == 1)
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);


                crystalReportViewer1.ReportSource = vch;
            }
            else
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);

                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);

                crystalReportViewer1.ReportSource = vch;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        vch.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = vch;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }     
            }
        }

        public void outstn(string current_company, DataTable Dailysalereg, string DURATION, string address, string pan, string address1, string sq88, int stp)
        {
            CrystalReportoutstand vch = new CrystalReportoutstand();
            if (stp == 1)
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);
                vch.SetParameterValue(5, sq88);
                crystalReportViewer1.ReportSource = vch;
            }
            else
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);
                vch.SetParameterValue(5, sq88);
                crystalReportViewer1.ReportSource = vch;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        vch.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = vch;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }     
            }
        }
        public void outstn1(string current_company, DataTable Dailysalereg, string DURATION, string address, string pan, string address1, string sq88 ,int stp)
        {
            CrystalReportoutstanddetails vch = new CrystalReportoutstanddetails();
            if (stp == 1)
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);
                vch.SetParameterValue(5, sq88);
                crystalReportViewer1.ReportSource = vch;
            }
            else
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);
                vch.SetParameterValue(5, sq88);
                crystalReportViewer1.ReportSource = vch;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        vch.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = vch;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }     
            }
        }
        public void productwise(string current_company, DataTable Dailysalereg, string DURATION, string address, string pan, string address1, string pp, int stp)
        {
            CrystalReportoutpartywise vch = new CrystalReportoutpartywise();
            if (stp == 1)
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);
                vch.SetParameterValue(5, pp);
                crystalReportViewer1.ReportSource = vch;
            }
            else
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);
                vch.SetParameterValue(5, pp);


                crystalReportViewer1.ReportSource = vch;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        vch.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = vch;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }     
            }
        }
        public void productwisepurchase(string current_company, DataTable Dailysalereg, string DURATION, string address, string pan, string address1, string pp, int stp)
        {
            CrystalReportoutpartywisepurchase vch = new CrystalReportoutpartywisepurchase();
            if (stp == 1)
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);
                vch.SetParameterValue(5, pp);
                crystalReportViewer1.ReportSource = vch;
            }
            else
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);
                vch.SetParameterValue(5, pp);
                crystalReportViewer1.ReportSource = vch;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        vch.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = vch;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }     
            }
        }

        public void purchaseRegisterRpt(string current_company, DataTable dtshow, string address, string address1, string pan, string DURATION, string Heading, string Total, int stp)
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
                bill.SetParameterValue(5, Heading);
                bill.SetParameterValue(6, Total);
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
                bill.SetParameterValue(5, Heading);
                bill.SetParameterValue(6, Total);
                crystalReportViewer1.ReportSource = bill;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        bill.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bill;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }     


            }
        }

        public void tax(string current_company, DataTable Dailysalereg, string DURATION, string address, string pan, string address1, string sq5, string sq6, string sq7, string sq68, int stp)
        {
            CrystalReporttax vch = new CrystalReporttax();
            if (stp == 1)
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);
                vch.SetParameterValue(5, sq5);
                vch.SetParameterValue(6, sq6);
                vch.SetParameterValue(7, sq7);
                vch.SetParameterValue(8, sq68);
                crystalReportViewer1.ReportSource = vch;
            }
            else
            {
                vch.SetDataSource(Dailysalereg);
                vch.SetParameterValue(0, current_company);
                vch.SetParameterValue(1, DURATION);
                vch.SetParameterValue(2, address);
                vch.SetParameterValue(3, pan);
                vch.SetParameterValue(4, address1);
                vch.SetParameterValue(5, sq5);
                vch.SetParameterValue(6, sq6);
                vch.SetParameterValue(7, sq7);
                vch.SetParameterValue(8, sq68);
                crystalReportViewer1.ReportSource = vch;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        vch.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = vch;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }     
            }
        }
        public void Accsellbillfull1(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, string LorryNo, string TinNo, string VatAmtWord, string amountlen, string Details2, string Details3, string Tax, string footer, string pp11,string Hade,string narration, int stp)
        {
            CrystalRpraccordsellbill1 bill = new CrystalRpraccordsellbill1();
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
                bill.SetParameterValue(14, LorryNo);
                bill.SetParameterValue(15, TinNo);
                bill.SetParameterValue(16, VatAmtWord);
                bill.SetParameterValue(17, amountlen);
                bill.SetParameterValue(18, Details2);
                bill.SetParameterValue(19, Details3);
                bill.SetParameterValue(20, Tax);
                bill.SetParameterValue(21, footer);
                bill.SetParameterValue(22, pp11);
                bill.SetParameterValue(23, Hade);
                bill.SetParameterValue(24, narration);
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
                bill.SetParameterValue(14, LorryNo);
                bill.SetParameterValue(15, TinNo);
                bill.SetParameterValue(16, VatAmtWord);
                bill.SetParameterValue(17, amountlen);
                bill.SetParameterValue(18, Details2);
                bill.SetParameterValue(19, Details3);
                bill.SetParameterValue(20, Tax);
                bill.SetParameterValue(21, footer);
                bill.SetParameterValue(22, pp11);
                bill.SetParameterValue(23, Hade);
                bill.SetParameterValue(24, narration);
                crystalReportViewer1.ReportSource = bill;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        bill.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bill;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }    
            }
        }
        public void Cashbillhalf(DataTable dtshow,string company, string Agentadd, string Agentadd1, string phone,string BillDate, string User_Voucher, string AmtWord, string vat1, string vat2,string Amountword, int stp)
        {
            CrystalRptCashbillhalfpage bill = new CrystalRptCashbillhalfpage();
            if (stp == 1)
            {
                bill.SetDataSource(dtshow);          
                bill.SetParameterValue(0, company);
                bill.SetParameterValue(1, Agentadd);
                bill.SetParameterValue(2, Agentadd1);
                bill.SetParameterValue(3, phone);
                bill.SetParameterValue(4, BillDate);
                bill.SetParameterValue(5, User_Voucher);
                bill.SetParameterValue(6, AmtWord);
                bill.SetParameterValue(7, vat1);
                bill.SetParameterValue(8, vat2);
                bill.SetParameterValue(9, Amountword);
                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetDataSource(dtshow);

                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, company);
                bill.SetParameterValue(1, Agentadd);
                bill.SetParameterValue(2, Agentadd1);
                bill.SetParameterValue(3, phone);
                bill.SetParameterValue(4, BillDate);
                bill.SetParameterValue(5, User_Voucher);
                bill.SetParameterValue(6, AmtWord);
                bill.SetParameterValue(7, vat1);
                bill.SetParameterValue(8, vat2);
                bill.SetParameterValue(9, Amountword);
                crystalReportViewer1.ReportSource = bill;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        bill.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bill;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }    
            }
        }

        public void SellChallan(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, string Tan, string amount, string challandt, string ConName, string ConAdd, string ConAdd1, string Removal, string branch, string Exasise, string Examtword, int stp, string conECC, string conPAN, string conCST,string YourOrder,string yourDate,string Printheader)
        {
            CrystalRptsaleschallan bill = new CrystalRptsaleschallan();
            if (stp == 1)
            {               
                companyName = "For " + companyName;
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
                bill.SetParameterValue(14, Tan);
                bill.SetParameterValue(15, amount);
                bill.SetParameterValue(16, challandt);
                bill.SetParameterValue(17, ConName);
                bill.SetParameterValue(18, ConAdd);
                bill.SetParameterValue(19, ConAdd1);
                bill.SetParameterValue(20, Removal);
                bill.SetParameterValue(21, branch);
                bill.SetParameterValue(22, Exasise);
                bill.SetParameterValue(23, Examtword);
                bill.SetParameterValue(24, conECC);
                bill.SetParameterValue(25, conPAN);
                bill.SetParameterValue(26, conCST);
                bill.SetParameterValue(27, YourOrder);
                bill.SetParameterValue(28, yourDate);
                bill.SetParameterValue(29, Printheader);               
                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                companyName = "For " + companyName;
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
                bill.SetParameterValue(14, Tan);
                bill.SetParameterValue(15, amount);
                bill.SetParameterValue(16, challandt);
                bill.SetParameterValue(17, ConName);
                bill.SetParameterValue(18, ConAdd);
                bill.SetParameterValue(19, ConAdd1);
                bill.SetParameterValue(20, Removal);
                bill.SetParameterValue(21, branch);
                bill.SetParameterValue(22, Exasise);
                bill.SetParameterValue(23, Examtword);
                bill.SetParameterValue(24, conECC);
                bill.SetParameterValue(25, conPAN);
                bill.SetParameterValue(26, conCST);
                bill.SetParameterValue(27, YourOrder);
                bill.SetParameterValue(28, yourDate);
                bill.SetParameterValue(29, Printheader);               
                //crystalReportViewer1.ReportSource = bill;
                //crystalReportViewer1.PrintReport();                
                try
                {
                    bill.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    bill.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = bill;
                }
                catch { }
            }
        }

        public void SellDeclaration(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, string Tan, string amount, string challandt, string ConName, string ConAdd, string ConAdd1, string Removal, string branch, int stp)
        {
            CrystalRptDeclaration bill = new CrystalRptDeclaration();
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
                bill.SetParameterValue(14, Tan);
                bill.SetParameterValue(15, amount);
                bill.SetParameterValue(16, challandt);
                bill.SetParameterValue(17, ConName);//5
                bill.SetParameterValue(18, ConAdd);
                bill.SetParameterValue(19, ConAdd1);
                bill.SetParameterValue(20, Removal);
                bill.SetParameterValue(21, branch);

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
                bill.SetParameterValue(14, Tan);
                bill.SetParameterValue(15, amount);
                bill.SetParameterValue(16, challandt);
                bill.SetParameterValue(17, ConName);
                bill.SetParameterValue(18, ConAdd);
                bill.SetParameterValue(19, ConAdd1);
                bill.SetParameterValue(20, Removal);
                bill.SetParameterValue(21, branch);

                bill.PrintToPrinter(3, true, 1, 1);
                crystalReportViewer1.ReportSource = bill;
                //crystalReportViewer1.PrintReport();

            }
        }
        public void calcutta(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, string LorryNo, string TinNo, string VatAmtWord, string amountlen, string Details2, string Details3, string Tax, string footer, string office, string tfax, string shop, string Email, string CSTNO, string WBCST, string MOB, string address2, string TinNo1, string pan1, string dis, string vat, string partyphno1, string prty, string quantity, string Agentadd3, int stp)
        {
            CrystalRprcalcutta bill = new CrystalRprcalcutta();
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
                bill.SetParameterValue(14, LorryNo);
                bill.SetParameterValue(15, TinNo);
                bill.SetParameterValue(16, VatAmtWord);
                bill.SetParameterValue(17, amountlen);
                bill.SetParameterValue(18, Details2);
                bill.SetParameterValue(19, Details3);
                bill.SetParameterValue(20, Tax);
                bill.SetParameterValue(21, footer);
                bill.SetParameterValue(22, office);
                bill.SetParameterValue(23, tfax);
                bill.SetParameterValue(24, shop);
                bill.SetParameterValue(25, Email);
                bill.SetParameterValue(26, CSTNO);
                bill.SetParameterValue(27, WBCST);
                bill.SetParameterValue(28, MOB);
                bill.SetParameterValue(29, address2);
                bill.SetParameterValue(30, TinNo1);
                bill.SetParameterValue(31, pan1);
                bill.SetParameterValue(32, dis);
                bill.SetParameterValue(33, vat);
                bill.SetParameterValue(34, partyphno1);

                bill.SetParameterValue(35, prty);
                bill.SetParameterValue(36, quantity);
                bill.SetParameterValue(37, Agentadd3);
                if (prty != "prty")
                {

                    bill.ReportDefinition.Sections["Section1"].ReportObjects["company1"].Top = 1560;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["company1"].Width = 3240;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Agentadd1"].Top = 1920;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Agentadd1"].Width = 3240;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Agentadd11"].Top = 2160;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Agentadd11"].Width = 3840;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["vxcvc1"].Height = 0;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["vxcvc1"].Width = 0;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["vxcvc1"].Top = 1800;
                    //bill.ReportDefinition.Sections["Section1"].ReportObjects["czz1"].Height = 0;
                    //bill.ReportDefinition.Sections["Section1"].ReportObjects["czz1"].Width = 0;
                    //bill.ReportDefinition.Sections["Section1"].ReportObjects["czz1"].Top = 1800;
                    //bill.ReportDefinition.Sections["Section1"].ReportObjects["xzczxczxc1"].Height = 0;
                    //bill.ReportDefinition.Sections["Section1"].ReportObjects["xzczxczxc1"].Width = 0;
                    //bill.ReportDefinition.Sections["Section1"].ReportObjects["xzczxczxc1"].Top = 1800;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Text20"].Height = 390;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Text20"].Width = 1080;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Text20"].Top = 2520;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["TinNo1"].Height = 390;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["TinNo1"].Width = 2160;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["TinNo1"].Top = 2520;

                }
                if (prty == "prty")
                {

                }
                if (vat != "vat" && dis != "discount" && quantity == "quentity")
                {
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Left = 8500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Left = 8400;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Left = 8350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Left = 8350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Left = 8350;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Left = 8300;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Left = 8300;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Left = 8300;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Width = 2000;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Left = 8500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Width = 2000;

                }
                if (vat != "vat" && dis != "discount" && quantity != "quentity")
                {
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Left = 500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Width = 3800;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Left = 500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Width = 3800;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Left = 4350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Left = 4350;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Width = 0;

                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Left = 8500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Left = 8400;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Left = 8350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Left = 8350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Left = 8350;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Left = 8300;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Left = 8300;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Left = 8300;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Width = 2000;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Left = 8500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Width = 2000;

                }
                if (vat == "vat" && dis != "discount" && quantity == "quentity")
                {

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Left = 7300;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Width = 1500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Left = 7300;

                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Width = 1500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = 6777;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = 500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Left = 6777;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Width = 500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Left = 6777;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Width = 500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Left = 6666;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Left = 6666;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Left = 6666;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Left = 6555;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Left = 6555;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Left = 6555;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Left = 8900;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Width = 1450;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Left = 8900;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Width = 1450;

                }
                if (vat == "vat" && dis != "discount" && quantity != "quentity")
                {
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Left = 500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Width = 3800;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Left = 500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Width = 3800;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Left = 4350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Left = 4350;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Width = 0;

                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Left = 7300;

                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Width = 1500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Left = 7300;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Width = 1500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = 6777;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = 500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Left = 6777;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Width = 500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Left = 6777;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Width = 500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Left = 6666;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Left = 6666;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Left = 6666;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Width = 0;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Left = 6555;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Left = 6555;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Left = 6555;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Width = 0;

                    //bill.ReportDefinition.Sections["Section2"].ReportObjects["Text11"].Left = 6300;
                    //bill.ReportDefinition.Sections["Section2"].ReportObjects["Text11"].Width = 1800;
                    //bill.ReportDefinition.Sections["Section3"].ReportObjects["Rate1"].Left = 6300;
                    //bill.ReportDefinition.Sections["Section3"].ReportObjects["Rate1"].Width = 1800;

                    //bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Left = 4200;
                    //bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Width = 2000;
                    //bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Left = 4200;
                    //bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Width = 2000;


                    //bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Left = 500;
                    //bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Width = 3500;
                    //bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Left = 500;
                    //bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Width = 3500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Left = 8900;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Width = 1450;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Left = 8900;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Width = 1450;

                }

                if (vat != "vat" && dis == "discount" && quantity != "quentity")
                {
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Left = 500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Width = 3800;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Left = 500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Width = 3800;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Left = 4350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Left = 4350;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Width = 0;

                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Left = 8500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Text10"].Left = 8500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Left = 8400;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Left = 7810;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Width = 1500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Left = 7810;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Width = 1500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Left = 7810;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Width = 1500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Left = 6800;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Width = 1200;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Left = 6800;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Width = 1200;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Left = 6800;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Width = 1200;
                }
                if (vat != "vat" && dis == "discount" && quantity == "quentity")
                {

                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Left = 8500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Text10"].Left = 8500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Width = 0;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Left = 8400;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Left = 7810;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Width = 1500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Left = 7810;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Width = 1500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Left = 7810;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Width = 1500;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Left = 6800;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Width = 1200;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Left = 6800;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Width = 1200;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Left = 6800;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Width = 1200;
                }
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
                bill.SetParameterValue(14, LorryNo);
                bill.SetParameterValue(15, TinNo);
                bill.SetParameterValue(16, VatAmtWord);
                bill.SetParameterValue(17, amountlen);
                bill.SetParameterValue(18, Details2);
                bill.SetParameterValue(19, Details3);
                bill.SetParameterValue(20, Tax);
                bill.SetParameterValue(21, footer);
                bill.SetParameterValue(22, office);
                bill.SetParameterValue(23, tfax);
                bill.SetParameterValue(24, shop);
                bill.SetParameterValue(25, Email);
                bill.SetParameterValue(26, CSTNO);
                bill.SetParameterValue(27, WBCST);
                bill.SetParameterValue(28, MOB);
                bill.SetParameterValue(29, address2);
                bill.SetParameterValue(30, TinNo1);
                bill.SetParameterValue(31, pan1);
                bill.SetParameterValue(32, dis);
                bill.SetParameterValue(33, vat);
                bill.SetParameterValue(34, partyphno1);

                bill.SetParameterValue(35, prty);
                bill.SetParameterValue(36, quantity);
                bill.SetParameterValue(37, Agentadd3);
                if (prty != "prty")
                {
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Agentadd1"].Top = 1800;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Agentadd1"].Width = 3240;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Agentadd11"].Top = 1560;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Agentadd11"].Width = 3840;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["vxcvc1"].Height = 0;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["vxcvc1"].Width = 0;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["vxcvc1"].Top = 1800;
                    //bill.ReportDefinition.Sections["Section1"].ReportObjects["czz1"].Height = 0;
                    //bill.ReportDefinition.Sections["Section1"].ReportObjects["czz1"].Width = 0;
                    //bill.ReportDefinition.Sections["Section1"].ReportObjects["czz1"].Top = 1800;
                    //bill.ReportDefinition.Sections["Section1"].ReportObjects["xzczxczxc1"].Height = 0;
                    //bill.ReportDefinition.Sections["Section1"].ReportObjects["xzczxczxc1"].Width = 0;
                    //bill.ReportDefinition.Sections["Section1"].ReportObjects["xzczxczxc1"].Top = 1800;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Text20"].Height = 390;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Text20"].Width = 1080;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["Text20"].Top = 2520;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["TinNo1"].Height = 390;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["TinNo1"].Width = 2160;
                    bill.ReportDefinition.Sections["Section1"].ReportObjects["TinNo1"].Top = 2520;

                }
                if (prty == "prty")
                {

                }
                if (vat != "vat" && dis != "discount" && quantity == "quentity")
                {
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Left = 8500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Left = 8400;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Left = 8350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Left = 8350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Left = 8350;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Width = 0;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Left = 8300;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Left = 8300;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Left = 8300;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Width = 0;



                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Width = 2000;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Left = 8500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Width = 2000;

                }
                if (vat != "vat" && dis != "discount" && quantity != "quentity")
                {
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Left = 500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Width = 3800;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Left = 500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Width = 3800;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Left = 4350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Left = 4350;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Width = 0;


                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Left = 8500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Left = 8400;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Left = 8350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Left = 8350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Left = 8350;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Width = 0;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Left = 8300;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Left = 8300;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Left = 8300;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Width = 0;



                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Width = 2000;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Left = 8500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Width = 2000;

                }
                if (vat == "vat" && dis != "discount" && quantity == "quentity")
                {

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Left = 7300;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Width = 1500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Left = 7300;

                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Width = 1500;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = 6777;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = 500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Left = 6777;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Width = 500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Left = 6777;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Width = 500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Left = 6666;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Left = 6666;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Left = 6666;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Width = 0;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Left = 6555;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Left = 6555;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Left = 6555;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Width = 0;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Left = 8900;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Width = 1450;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Left = 8900;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Width = 1450;

                }
                if (vat == "vat" && dis != "discount" && quantity != "quentity")
                {
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Left = 500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Width = 3800;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Left = 500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Width = 3800;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Left = 4350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Left = 4350;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Width = 0;

                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Left = 7300;

                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Width = 1500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Left = 7300;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Width = 1500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = 6777;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = 500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Left = 6777;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Width = 500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Left = 6777;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Width = 500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Left = 6666;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Left = 6666;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Left = 6666;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Width = 0;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Left = 6555;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Left = 6555;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Left = 6555;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Width = 0;

                    //bill.ReportDefinition.Sections["Section2"].ReportObjects["Text11"].Left = 6300;
                    //bill.ReportDefinition.Sections["Section2"].ReportObjects["Text11"].Width = 1800;
                    //bill.ReportDefinition.Sections["Section3"].ReportObjects["Rate1"].Left = 6300;
                    //bill.ReportDefinition.Sections["Section3"].ReportObjects["Rate1"].Width = 1800;

                    //bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Left = 4200;
                    //bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Width = 2000;
                    //bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Left = 4200;
                    //bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Width = 2000;


                    //bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Left = 500;
                    //bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Width = 3500;
                    //bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Left = 500;
                    //bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Width = 3500;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Left = 8900;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Width = 1450;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Left = 8900;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Amount1"].Width = 1450;

                }

                if (vat != "vat" && dis == "discount" && quantity != "quentity")
                {
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Left = 500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text7"].Width = 3800;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Left = 500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Particular1"].Width = 3800;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Left = 4350;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text9"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Left = 4350;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Quentity1"].Width = 0;

                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Left = 8500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Text10"].Left = 8500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Width = 0;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Left = 8400;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Left = 7810;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Width = 1500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Left = 7810;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Width = 1500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Left = 7810;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Width = 1500;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Left = 6800;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Width = 1200;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Left = 6800;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Width = 1200;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Left = 6800;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Width = 1200;
                }
                if (vat != "vat" && dis == "discount" && quantity == "quentity")
                {

                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Left = 8500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Vatamt1"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["Text10"].Left = 8500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text10"].Width = 0;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text2"].Width = 0;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Left = 8400;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text31"].Width = 0;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Left = 8400;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["VatPar1"].Width = 0;

                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Left = 7810;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text38"].Width = 1500;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Left = 7810;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text39"].Width = 1500;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Left = 7810;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["ExtraDis1"].Width = 1500;


                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Left = 6800;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text35"].Width = 1200;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Left = 6800;
                    bill.ReportDefinition.Sections["Section2"].ReportObjects["Text37"].Width = 1200;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Left = 6800;
                    bill.ReportDefinition.Sections["Section3"].ReportObjects["StdDis1"].Width = 1200;
                }
                crystalReportViewer1.ReportSource = bill;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        bill.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bill;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }    
            }
        }
        public void autobill(DataTable dtshow, string company, string Agentadd, string phone, string tin, string BillDate, string User_Voucher, string GAmount, string TotalAmount, string sgroup1, string sgroup2, string sgroup3, string sgroup4, string accoparating, string selestax, int mounth, string netamount, string lastbal, string alias, string aoc, string out_int, int stp)
        {
            Crysrptautobill bill = new Crysrptautobill();
            if (stp == 1)
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, company);
                bill.SetParameterValue(1, Agentadd);
                bill.SetParameterValue(2, phone);
                bill.SetParameterValue(3, tin);
                bill.SetParameterValue(4, BillDate);
                bill.SetParameterValue(5, User_Voucher);
                bill.SetParameterValue(6, GAmount);
                bill.SetParameterValue(7, TotalAmount);
                bill.SetParameterValue(8, sgroup1);
                bill.SetParameterValue(9, sgroup2);
                bill.SetParameterValue(10, sgroup3);
                bill.SetParameterValue(11, sgroup4);
                bill.SetParameterValue(12, accoparating);
                bill.SetParameterValue(13, selestax);
                bill.SetParameterValue(14, mounth);
                bill.SetParameterValue(15, netamount);
                bill.SetParameterValue(16, lastbal);
                bill.SetParameterValue(17, alias);
                bill.SetParameterValue(18, aoc);
                bill.SetParameterValue(19, out_int);
                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, company);
                bill.SetParameterValue(1, Agentadd);
                bill.SetParameterValue(2, phone);
                bill.SetParameterValue(3, tin);
                bill.SetParameterValue(4, BillDate);
                bill.SetParameterValue(5, User_Voucher);
                bill.SetParameterValue(6, GAmount);
                bill.SetParameterValue(7, TotalAmount);
                bill.SetParameterValue(8, sgroup1);
                bill.SetParameterValue(9, sgroup2);
                bill.SetParameterValue(10, sgroup3);
                bill.SetParameterValue(11, sgroup4);
                bill.SetParameterValue(12, accoparating);
                bill.SetParameterValue(13, selestax);
                bill.SetParameterValue(14, mounth);
                bill.SetParameterValue(15, netamount);
                bill.SetParameterValue(16, lastbal);
                bill.SetParameterValue(17, alias);
                bill.SetParameterValue(18, aoc);
                bill.SetParameterValue(19, out_int);
                bill.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = bill;
                //crystalReportViewer1.PrintReport();
            }
        }
        public void blancesheet_PrintT(string companyName, DataTable dtt, string dura, string addre, string panno, string add1, string drtot, string crtot, string headingdr, string headingcr, int stp)
        {           
            CrystalrptBSTshape bal = new CrystalrptBSTshape();

            if (stp == 1)
            {
                bal.SetDataSource(dtt);
                bal.SetParameterValue(0, companyName);
                bal.SetParameterValue(1, addre);
                bal.SetParameterValue(2, panno);
                bal.SetParameterValue(3, dura);
                bal.SetParameterValue(4, add1);
                bal.SetParameterValue(5, drtot);
                bal.SetParameterValue(6, crtot);
                bal.SetParameterValue(7, headingdr);
                bal.SetParameterValue(8, headingcr);
                crystalReportViewer1.ReportSource = bal;
            }
            else
            {
                bal.SetDataSource(dtt);
                bal.SetParameterValue(0, companyName);
                bal.SetParameterValue(1, addre);
                bal.SetParameterValue(2, panno);
                bal.SetParameterValue(3, dura);
                bal.SetParameterValue(4, add1);
                bal.SetParameterValue(5, drtot);
                bal.SetParameterValue(6, crtot);
                bal.SetParameterValue(7, headingdr);
                bal.SetParameterValue(8, headingcr);
                crystalReportViewer1.ReportSource = bal;

                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {                        
                        bal.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bal;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }
               
            }
        }
        
        public void billhlf(string companyName, DataTable dtshow, string dura, string addre, string panno, string add1, string company, string Agentadd, string Agentadd1, string phone, string Area, string BillDate, string User_Voucher, string challan, string AmtWord, string LorryNo, string TinNo, string VatAmtWord, string amountlen, string Details2, string Details3, string Tax, string footer, string office, string tfax, string shop, string Email, string CSTNO, string WBCST, string MOB, string address2, string TinNo1, string pan1, string dis, string vat, string partyphno1, string prty, string quantity, string Agentadd3, int stp)
        {
            CrystalRptbillhlf bill = new CrystalRptbillhlf();            
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
                bill.SetParameterValue(14, LorryNo);
                bill.SetParameterValue(15, TinNo);
                bill.SetParameterValue(16, VatAmtWord);
                bill.SetParameterValue(17, amountlen);
                bill.SetParameterValue(18, Details2);
                bill.SetParameterValue(19, Details3);
                bill.SetParameterValue(20, Tax);
                bill.SetParameterValue(21, footer);
                bill.SetParameterValue(22, office);
                bill.SetParameterValue(23, tfax);
                bill.SetParameterValue(24, shop);
                bill.SetParameterValue(25, Email);
                bill.SetParameterValue(26, CSTNO);
                bill.SetParameterValue(27, WBCST);
                bill.SetParameterValue(28, MOB);
                bill.SetParameterValue(29, address2);
                bill.SetParameterValue(30, TinNo1);
                bill.SetParameterValue(31, pan1);
                bill.SetParameterValue(32, dis);
                bill.SetParameterValue(33, vat);
                bill.SetParameterValue(34, partyphno1);
                bill.SetParameterValue(35, prty);
                bill.SetParameterValue(36, quantity);
                bill.SetParameterValue(37, Agentadd3);               
                crystalReportViewer1.ReportSource = bill;

                //printDialog1.PrinterSettings.DefaultPageSettings.Landscape = false;              
                ////crystalReportViewer1.ShowPrintButton = PaperOrientation.Portrait;
                //bill.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                //bill.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                //bill.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSource.
                ////PrintDialog pp = new PrintDialog();
                ////pp.PrinterSettings.DefaultPageSettings.PaperSize.Height = 9;
                ////pp.PrinterSettings.DefaultPageSettings.PaperSize.Width = 6;
                ////printDialog1 = pp;
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
                bill.SetParameterValue(14, LorryNo);
                bill.SetParameterValue(15, TinNo);
                bill.SetParameterValue(16, VatAmtWord);
                bill.SetParameterValue(17, amountlen);
                bill.SetParameterValue(18, Details2);
                bill.SetParameterValue(19, Details3);
                bill.SetParameterValue(20, Tax);
                bill.SetParameterValue(21, footer);
                bill.SetParameterValue(22, office);
                bill.SetParameterValue(23, tfax);
                bill.SetParameterValue(24, shop);
                bill.SetParameterValue(25, Email);
                bill.SetParameterValue(26, CSTNO);
                bill.SetParameterValue(27, WBCST);
                bill.SetParameterValue(28, MOB);
                bill.SetParameterValue(29, address2);
                bill.SetParameterValue(30, TinNo1);
                bill.SetParameterValue(31, pan1);
                bill.SetParameterValue(32, dis);
                bill.SetParameterValue(33, vat);
                bill.SetParameterValue(34, partyphno1);
                bill.SetParameterValue(35, prty);
                bill.SetParameterValue(36, quantity);
                bill.SetParameterValue(37, Agentadd3);

                //bill.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperSize.
                //bill.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                crystalReportViewer1.ReportSource = bill;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        bill.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bill;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }    
            }
        }

        public void ttypevoucher(DataTable dtshow, int stp)
        {
            CrystalRptcontinuevoucher bill = new CrystalRptcontinuevoucher();
            if (stp == 1)
            {
                bill.SetDataSource(dtshow);
                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetDataSource(dtshow);
                crystalReportViewer1.ReportSource = bill;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        bill.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = bill;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }    
            }
        }

        //Pradipta (27.05.13)


        //================== For Letter Format Printing 30-08-2013 =============
        #region Letter Format Printing View
        public void Graphic_Preview_LetterFormat(DataTable dt)
        {
            try
            {
                columnHeaderTop = 0;
                CARLF.SetDataSource(dt);
                crystalReportViewer1.ReportSource = CARLF;
            }
            catch { }
        }

        public void Graphic_Print_LetterFormat(DataTable dt)
        {
            try
            {
                columnHeaderTop = 0;
                CARLF.SetDataSource(dt);
                crystalReportViewer1.ReportSource = CARLF;
                crystalReportViewer1.PrintReport();
            }
            catch { }
        }

        //public void ReportHeaderArrenge(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty)
        //{
        //    try
        //    {
        //        string HeaderName = "";
        //        int TotalHeight = 0;
        //        int row_top = 0;
        //        string ColName = "";
        //        string FN = "";
        //        float FSI = 0;

        //        string[] TV = new string[] { };
        //        TV = TopValue.Trim().Split(',');

        //        string[] WV = new string[] { };
        //        WV = WidthValue.Trim().Split(',');

        //        string[] HV = new string[] { };
        //        HV = HeightValue.Trim().Split(',');

        //        string[] LV = new string[] { };
        //        LV = LeftValue.Trim().Split(',');

        //        string[] AV = new string[] { };
        //        AV = AlignmentValue.Trim().Split(',');

        //        for (int i = 0; i < 11; i++)
        //        {
        //            HeaderName = "PF" + Convert.ToString(i + 1) + "1";
        //            if (i < Header_String.Length)
        //            {
        //                FN = Convert.ToString(FontName[i]);
        //                FSI = Convert.ToSingle(FontSize[i]);

        //                CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName]);
        //                txtApprovalStatus1.Text = Convert.ToString(Header_String[i]);

        //                if (Convert.ToString(FontSty[i]) == "B")
        //                    txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
        //                if (Convert.ToString(FontSty[i]) == "I")
        //                    txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
        //                if (Convert.ToString(FontSty[i]) == "U")
        //                    txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
        //                if (Convert.ToString(FontSty[i]) == "R")
        //                    txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));
        //                if (i == 0)
        //                {
        //                    CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
        //                    CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
        //                    CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
        //                    TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
        //                    //row_top = (Convert.ToInt32(TV[i]) * 48);
        //                    CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
        //                }
        //                else
        //                {
        //                    //if (Convert.ToInt32(TV[i]) != 0)
        //                    row_top = row_top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i - 1]) * 48);
        //                    CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = row_top;
        //                    CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
        //                    CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
        //                    TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
        //                    CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
        //                }
        //                if (Convert.ToString(AV[i]).ToUpper() == "L")
        //                    CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
        //                if (Convert.ToString(AV[i]).ToUpper() == "M")
        //                    CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
        //                if (Convert.ToString(AV[i]).ToUpper() == "R")
        //                    CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
        //            }
        //            else
        //            {
        //                CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = 0;
        //                CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = 0;
        //                CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = 0;
        //                CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = 0;
        //            }
        //        }
        //        //CAR.ReportDefinition.Sections["Section1"].Height = TotalHeight + 20;
        //        Section section = CAR.ReportDefinition.Sections["Section1"];
        //        section.Height = TotalHeight;
        //    }
        //    catch { }
        //}

        public void ReportPageHeaderArrenge_LetterFormat(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty)
        {
            try
            {
                string HeaderName = "";
                int TotalHeight = 0, Top = 0;
                string FN = "";
                float FSI = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 0; i < 27; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 10 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName]);
                        txtApprovalStatus1.Text = Convert.ToString(Header_String[i]);
                        if (Convert.ToString(FontSty[i]) == "B")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                        if (Convert.ToString(FontSty[i]) == "I")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                        if (Convert.ToString(FontSty[i]) == "U")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                        if (Convert.ToString(FontSty[i]) == "R")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));

                        if (i == 0)
                        {
                            CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = Top + (Convert.ToInt32(TV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = 0;
                        CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = 0;
                        CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = 0;
                        CARLF.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                //int ExtraHeight = HC * 48;
                int ExtraHeight = 100;
                string ColName = "";
                for (int i = 1; i <= 20; i++)
                {
                    ColName = "Text" + Convert.ToString(i);

                    //CARLF.ReportDefinition.Sections["Section2"].ReportObjects[ColName].Top = columnHeaderTop + 48 + ExtraHeight;
                    CARLF.ReportDefinition.Sections["Section2"].ReportObjects[ColName].Top = 48 + ExtraHeight;

                    CrystalDecisions.CrystalReports.Engine.TextObject txtStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CARLF.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                    txtStatus1.Text = "";
                }

                CrystalDecisions.CrystalReports.Engine.TextObject txtLine1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CARLF.ReportDefinition.Sections["Section2"].ReportObjects["Line11"]);
                //txtLine1.Top = TotalHeight + 10 + ExtraHeight;
                txtLine1.Top = 10 + ExtraHeight;

                CrystalDecisions.CrystalReports.Engine.TextObject txtLine2 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CARLF.ReportDefinition.Sections["Section2"].ReportObjects["Line22"]);
                if (TotalHeight == 0)
                    TotalHeight = 70;
                //txtLine2.Top = TotalHeight + 10 + 80 + 250 + 200 + ExtraHeight;
                txtLine2.Top = 10 + 80 + 250 + 200 + ExtraHeight;

                Section section = CARLF.ReportDefinition.Sections["Section1"];
                section.Height = columnHeaderTop + ExtraHeight + 100;

                TotalHeight = TotalHeight + ExtraHeight;
                columnHeaderTop = columnHeaderTop + ExtraHeight;
            }
            catch { }
        }

        public void ReportPageFooterArrenge_LetterFormat(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty)
        {
            try
            {
                string HeaderName = "";
                int TotalHeight = 0, Top = 0;
                string FN = "";
                float FSI = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 0; i < 9; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 80 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName]);
                        txtApprovalStatus1.Text = Convert.ToString(Header_String[i]);
                        if (Convert.ToString(FontSty[i]) == "B")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                        if (Convert.ToString(FontSty[i]) == "I")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                        if (Convert.ToString(FontSty[i]) == "U")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                        if (Convert.ToString(FontSty[i]) == "R")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));

                        if (i == 0)
                        {
                            CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = Top + (Convert.ToInt32(TV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = 0;
                        CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = 0;
                        CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = 0;
                        CARLF.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                //CrystalDecisions.CrystalReports.Engine.LineObject Line_5 = ((CrystalDecisions.CrystalReports.Engine.LineObject)CARLF.ReportDefinition.Sections["Section5"].ReportObjects["Line5"]);
                //Line_5.LineThickness = 20;   

                if (PageNumberDisplay == true)
                {
                    CARLF.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Top = TotalHeight + 50;
                    CARLF.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Width = 1600;
                    CARLF.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Height = 220;
                    CARLF.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Left = 10200;
                }
                else
                {
                    CrystalDecisions.CrystalReports.Engine.FieldObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.FieldObject)CARLF.ReportDefinition.Sections["Section2"].ReportObjects["PageNofM1"]);
                    txtApprovalStatus1.Height = 0;
                    txtApprovalStatus1.Left = 0;
                    txtApprovalStatus1.Top = 0;
                    txtApprovalStatus1.Width = 0;

                    //CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PF391"] = CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"];

                    CARLF.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Top = 0;
                    CARLF.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Width = 0;
                    CARLF.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Height = 0;
                    CARLF.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Left = 0;
                    TotalHeight = TotalHeight - 50;
                }

                Section section = CARLF.ReportDefinition.Sections["Section5"];
                section.Height = TotalHeight + 50 + 220 + 48;
            }
            catch { }
        }

        public void ReportFooterArrenge_LetterFormat(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty)
        {
            try
            {
                string HeaderName = "";
                int TotalHeight = 0, Top = 0;
                string FN = "";
                float FSI = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 40 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName]);
                        txtApprovalStatus1.Text = Convert.ToString(Header_String[i]);
                        if (Convert.ToString(FontSty[i]) == "B")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                        if (Convert.ToString(FontSty[i]) == "I")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                        if (Convert.ToString(FontSty[i]) == "U")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                        if (Convert.ToString(FontSty[i]) == "R")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));

                        if (i == 0)
                        {
                            CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = Top + (Convert.ToInt32(TV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = 0;
                        CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = 0;
                        CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = 0;
                        CARLF.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                //CrystalDecisions.CrystalReports.Engine.LineObject Line_5 = ((CrystalDecisions.CrystalReports.Engine.LineObject)CARLF.ReportDefinition.Sections["Section5"].ReportObjects["Line5"]);
                //Line_5.LineThickness = 20;               

                Section section = CARLF.ReportDefinition.Sections["Section4"];
                section.Height = TotalHeight + 48;
            }
            catch { }
        }

        public void DetailsColumnsHeaderArrenge_LetterFormat(string[] COL_NAME, string[] FontName, string[] FontSize, string[] FontSty)
        {
            try
            {
                string ColName = "";
                string FN = "";
                float FSI = 0;

                for (int i = 1; i <= COL_NAME.Length; i++)
                {
                    ColName = "Text" + Convert.ToString(i);
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CARLF.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                    txtApprovalStatus1.Text = Convert.ToString(COL_NAME[i - 1]);

                    FN = Convert.ToString(FontName[i - 1]);
                    FSI = Convert.ToSingle(FontSize[i - 1]);
                    if (Convert.ToString(FontSty[i - 1]) == "B")
                        txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                    if (Convert.ToString(FontSty[i - 1]) == "I")
                        txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                    if (Convert.ToString(FontSty[i - 1]) == "U")
                        txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                    if (Convert.ToString(FontSty[i - 1]) == "R")
                        txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));

                    //txtApprovalStatus1.ApplyFont(new Font("Comic Sans MS", 8.25F, FontStyle.Bold));   
                }
            }
            catch { }
        }

        public void DetailsColumnsArrenge_LetterFormat(string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue)
        {
            try
            {
                string ColName = "";
                string ColHeaderName = "";
                int LeftVal = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 1; i <= 20; i++)
                {
                    ColName = "Col" + Convert.ToString(i);
                    ColHeaderName = "Text" + Convert.ToString(i);

                    if (i <= WV.Length)
                    {
                        if (i == 1)
                            LeftVal = LeftVal + (Convert.ToInt32(LV[0]) * 48);
                        else
                        {
                            if (Convert.ToInt32(LV[i - 1]) == 0)
                                LeftVal = LeftVal + (Convert.ToInt32(WV[i - 2]) * 48) + 20;
                        }
                        CARLF.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Top = (Convert.ToInt32(TV[0]) * 48);// +(Convert.ToInt32(TV[i - 1]) * 48);
                        CARLF.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Width = (Convert.ToInt32(WV[i - 1]) * 48);
                        CARLF.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Width = (Convert.ToInt32(WV[i - 1]) * 48);

                        CARLF.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Height = (Convert.ToInt32(HV[i - 1]) * 48);

                        if (Convert.ToInt32(LV[i - 1]) == 0)
                        {
                            CARLF.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = LeftVal;// (Convert.ToInt32(LV[i - 1]) * 48);
                            CARLF.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Left = LeftVal; //(Convert.ToInt32(LV[i - 1]) * 48);
                        }
                        else
                        {
                            CARLF.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = (Convert.ToInt32(LV[i - 1]) * 48);
                            CARLF.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Left = (Convert.ToInt32(LV[i - 1]) * 48);
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "L")
                        {
                            CARLF.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                            CARLF.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "M")
                        {
                            CARLF.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                            CARLF.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "R")
                        {
                            CARLF.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                            CARLF.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                    }
                    else
                    {
                        CARLF.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Top = 0;
                        CARLF.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Width = 0;
                        CARLF.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Height = 0;
                        CARLF.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = 0;
                    }
                }
                //CARLF.ReportDefinition.Sections["Section3"].Height = Convert.ToInt32(HV[0]) + 48;
                //CrystalDecisions.CrystalReports

                //CrystalDecisions.CrystalReports

                Section section = CARLF.ReportDefinition.Sections["Section3"];
                section.Height = (Convert.ToInt32(HV[0]) * 48) + (Convert.ToInt32(TV[0]) * 48);

                //ReportDocument gg = new ReportDocument();
                //Section

            }
            catch { }
        }

        #endregion
        //================== End Letter Format Printing 30-08-2013 =============

        public void Graphic_Print(DataTable dt, string Print_Style)
        {
            try
            {                
                columnHeaderTop = 0;
                CAR_L.SetDataSource(dt);
                CAR_L.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                crystalReportViewer1.ReportSource = CAR_L;

                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        //bal.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                        CAR_L.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = CAR_L;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }
            }
            catch { }
        }

        public void Graphic_Print(DataTable dt)
        {
            try
            {                
                columnHeaderTop = 0;
                CAR.SetDataSource(dt);
                //crystalReportViewer1.ReportSource = CAR;

                //CAR.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;


                //PrintDocument PD = new PrintDocument();
                //System.Drawing.Printing.PaperSize paperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169);
                //paperSize.RawKind = (int)PaperKind.Custom;

                //PrinterSettings ps = new PrinterSettings();
                //ps.DefaultPageSettings.PaperSize = paperSize;

                //PageSetupDialog PSetup = new PageSetupDialog();
                //PSetup.PageSettings.PaperSize = paperSize;

                crystalReportViewer1.ReportSource = CAR;
                if (edpcom.EnvironMent_Bittype == "64")
                {
                    try
                    {
                        //bal.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                        CAR.PrintToPrinter(1, false, 0, 0);
                        crystalReportViewer1.ReportSource = CAR;
                    }
                    catch { }
                }
                else
                {
                    crystalReportViewer1.PrintReport();
                }

                //PageSetupDialog PSetup = new PageSetupDialog();

                //PaperSize ps = new PaperSize("A4", PD.DefaultPageSettings.PaperSize.Width, PD.DefaultPageSettings.PaperSize.Height);
                //.RawKind = (int)PaperKind.Custom;
                //PSetup.PageSettings.PaperSize = ps;

                //PaperSize ps = new System.Drawing.Printing.PaperSize();
                //ps.PaperName = "A4";

                ////PSetup.PrinterSettings.PaperSizes = "A4";

                //PrinterSettings ps = new PrinterSettings();
                //ps.PaperSizes = ps;


            }
            catch { }
        }

        public void Graphic_Preview(DataTable dt)
        {
            try
            {
                columnHeaderTop = 0;
                CAR.SetDataSource(dt);
                crystalReportViewer1.ReportSource = CAR;
            }
            catch { }
        }

        public void Graphic_Preview(DataTable dt, string Print_Style)
        {
            try
            {
                columnHeaderTop = 0;
                CAR_L.SetDataSource(dt);
                CAR_L.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                //bal.PrintToPrinter(1, false, 0, 0);              
                crystalReportViewer1.ReportSource = CAR_L;
            }
            catch { }
        }

        #region Printing View Potrat Format

        public void ReportHeaderArrenge(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty)
        {
            try
            {
                string HeaderName = "";
                int TotalHeight = 0;
                int row_top = 0;
                string ColName = "";
                string FN = "";
                float FSI = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 0; i < 11; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName]);
                        txtApprovalStatus1.Text = Convert.ToString(Header_String[i]);

                        if (Convert.ToString(FontSty[i]) == "B")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                        if (Convert.ToString(FontSty[i]) == "I")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                        if (Convert.ToString(FontSty[i]) == "U")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                        if (Convert.ToString(FontSty[i]) == "R")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));
                        if (i == 0)
                        {
                            CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);

                            //Change 05.11.14 (When Report Export The Hender Not Visible)
                            int len = Convert.ToInt32(WV[i]);
                            if (len < 230)
                                CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (len * 48);
                            else
                                CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (230 * 48);

                            //CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            //End 05.11.14

                            CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            //row_top = (Convert.ToInt32(TV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                        }
                        else
                        {
                            //if (Convert.ToInt32(TV[i]) != 0)
                            row_top = row_top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i - 1]) * 48);
                            CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = row_top;

                            //Change 05.11.14 (When Report Export The Hender Not Visible)
                            int len = Convert.ToInt32(WV[i]);
                            if (len < 230)
                                CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (len * 48);
                            else
                                CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (230 * 48);

                            //CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            //End 05.11.14

                            CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = 0;
                        CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = 0;
                        CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = 0;
                        CAR.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = 0;
                    }
                }
                //CAR.ReportDefinition.Sections["Section1"].Height = TotalHeight + 20;
                Section section = CAR.ReportDefinition.Sections["Section1"];
                section.Height = TotalHeight;
            }
            catch { }
        }

        public void ReportPageHeaderArrenge(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty)
        {
            try
            {
                string HeaderName = "";
                int TotalHeight = 0, Top = 0;
                string FN = "";
                float FSI = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 10 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName]);
                        txtApprovalStatus1.Text = Convert.ToString(Header_String[i]);
                        if (Convert.ToString(FontSty[i]) == "B")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                        if (Convert.ToString(FontSty[i]) == "I")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                        if (Convert.ToString(FontSty[i]) == "U")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                        if (Convert.ToString(FontSty[i]) == "R")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));

                        if (i == 0)
                        {
                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);

                            //Change 05.11.14 (When Report Export The Hender Not Visible)
                            int len = Convert.ToInt32(WV[i]);                            
                            if (len < 230)
                                CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = (len * 48);
                            else
                                CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = (230 * 48);

                            //CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            //End 05.11.14

                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            //if (i < 3)
                            //    SustractTotalHeight = SustractTotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            if (i == 3)
                            {
                                TotalHeight = (Convert.ToInt32(TV[0]) * 48);
                                columnHeaderTop = (Convert.ToInt32(TV[0]) * 48);
                                //TotalHeight = 48;
                                //columnHeaderTop = 48;
                            }
                            else if (i == 2)
                            {
                                if (Header_String.Length == 3)
                                    TotalHeight = 48;
                            }

                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Top = TotalHeight;
                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            //if (i < 3)
                            //    SustractTotalHeight = SustractTotalHeight + (Convert.ToInt32(HV[i]) * 48);


                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Top = 0;
                        CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = 0;
                        CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Height = 0;
                        CAR.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                string ColName = "";
                for (int i = 1; i <= 20; i++)
                {
                    ColName = "Text" + Convert.ToString(i);
                    CAR.ReportDefinition.Sections["Section2"].ReportObjects[ColName].Top = TotalHeight + 70;
                }

                CrystalDecisions.CrystalReports.Engine.TextObject txtLine1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR.ReportDefinition.Sections["Section2"].ReportObjects["Line11"]);
                txtLine1.Top = TotalHeight + 20;

                CrystalDecisions.CrystalReports.Engine.TextObject txtLine2 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR.ReportDefinition.Sections["Section2"].ReportObjects["Line22"]);
                if (TotalHeight == 0)
                    TotalHeight = 50;
                txtLine2.Top = TotalHeight + 60 + 70 + 250 + 200;

                Section section = CAR.ReportDefinition.Sections["Section2"];
                section.Height = TotalHeight + 300 + 140 + 300;
            }
            catch { }
        }

        public void ReportPageFooterArrenge(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty)
        {
            try
            {
                string HeaderName = "";
                int TotalHeight = 0, Top = 0;
                string FN = "";
                float FSI = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 20 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName]);
                        txtApprovalStatus1.Text = Convert.ToString(Header_String[i]);
                        if (Convert.ToString(FontSty[i]) == "B")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                        if (Convert.ToString(FontSty[i]) == "I")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                        if (Convert.ToString(FontSty[i]) == "U")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                        if (Convert.ToString(FontSty[i]) == "R")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));

                        if (i == 0)
                        {
                            CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = Top + (Convert.ToInt32(TV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = 0;
                        CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = 0;
                        CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = 0;
                        CAR.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                //CrystalDecisions.CrystalReports.Engine.LineObject Line_5 = ((CrystalDecisions.CrystalReports.Engine.LineObject)CAR.ReportDefinition.Sections["Section5"].ReportObjects["Line5"]);
                //Line_5.LineThickness = 20;   

                if (PageNumberDisplay == true)
                {
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Top = TotalHeight + 50;
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Width = 1600;
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Height = 220;
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Left = 10200;
                }
                else
                {
                    CrystalDecisions.CrystalReports.Engine.FieldObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.FieldObject)CAR.ReportDefinition.Sections["Section2"].ReportObjects["PageNofM1"]);
                    txtApprovalStatus1.Height = 0;
                    txtApprovalStatus1.Left = 0;
                    txtApprovalStatus1.Top = 0;
                    txtApprovalStatus1.Width = 0;

                    //CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PF391"] = CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"];

                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Top = 0;
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Width = 0;
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Height = 0;
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Left = 0;
                    TotalHeight = TotalHeight - 50;
                }

                Section section = CAR.ReportDefinition.Sections["Section5"];
                section.Height = TotalHeight + 50 + 220 + 48;
            }
            catch { }
        }

        public void ReportFooterArrenge(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty)
        {
            try
            {
                string HeaderName = "";
                int TotalHeight = 0, Top = 0;
                string FN = "";
                float FSI = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 30 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName]);
                        txtApprovalStatus1.Text = Convert.ToString(Header_String[i]);
                        if (Convert.ToString(FontSty[i]) == "B")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                        if (Convert.ToString(FontSty[i]) == "I")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                        if (Convert.ToString(FontSty[i]) == "U")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                        if (Convert.ToString(FontSty[i]) == "R")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));

                        if (i == 0)
                        {
                            CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = Top + (Convert.ToInt32(TV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = 0;
                        CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = 0;
                        CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = 0;
                        CAR.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                //CrystalDecisions.CrystalReports.Engine.LineObject Line_5 = ((CrystalDecisions.CrystalReports.Engine.LineObject)CAR.ReportDefinition.Sections["Section5"].ReportObjects["Line5"]);
                //Line_5.LineThickness = 20;               

                Section section = CAR.ReportDefinition.Sections["Section4"];
                section.Height = TotalHeight + 48;
            }
            catch { }
        }

        public void DetailsColumnsHeaderArrenge(string[] COL_NAME, string[] FontName, string[] FontSize, string[] FontSty)
        {
            try
            {
                string ColName = "";
                string FN = "";
                float FSI = 0;

                for (int i = 1; i <= COL_NAME.Length; i++)
                {
                    ColName = "Text" + Convert.ToString(i);
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                    txtApprovalStatus1.Text = Convert.ToString(COL_NAME[i - 1]);

                    FN = Convert.ToString(FontName[i - 1]);
                    FSI = Convert.ToSingle(FontSize[i - 1]);
                    if (Convert.ToString(FontSty[i - 1]) == "B")
                        txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                    if (Convert.ToString(FontSty[i - 1]) == "I")
                        txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                    if (Convert.ToString(FontSty[i - 1]) == "U")
                        txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                    if (Convert.ToString(FontSty[i - 1]) == "R")
                        txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));

                    //txtApprovalStatus1.ApplyFont(new Font("Comic Sans MS", 8.25F, FontStyle.Bold));   
                }
            }
            catch { }
        }

        public void DetailsColumnsArrenge(string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue)
        {
            try
            {
                string ColName = "";
                string ColHeaderName = "";
                int LeftVal = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                //CrystalDecisions.CrystalReports.Engine.FieldObject F1 = ((CrystalDecisions.CrystalReports.Engine.FieldObject)CAR.ReportDefinition.Sections["Section3"].ReportObjects["Col1"]);
                //F1.ApplyFont(new Font("Times New Roman", 9, FontStyle.Bold));
                //CrystalDecisions.CrystalReports.Engine.FieldObject F2 = ((CrystalDecisions.CrystalReports.Engine.FieldObject)CAR.ReportDefinition.Sections["Section3"].ReportObjects["Col2"]);
                //F2.ApplyFont(new Font("Times New Roman", 9, FontStyle.Bold));
                //CrystalDecisions.CrystalReports.Engine.FieldObject F3 = ((CrystalDecisions.CrystalReports.Engine.FieldObject)CAR.ReportDefinition.Sections["Section3"].ReportObjects["Col3"]);
                //F3.ApplyFont(new Font("Times New Roman", 9, FontStyle.Bold));
                //CrystalDecisions.CrystalReports.Engine.FieldObject F4 = ((CrystalDecisions.CrystalReports.Engine.FieldObject)CAR.ReportDefinition.Sections["Section3"].ReportObjects["Col4"]);
                //F4.ApplyFont(new Font("Times New Roman", 9, FontStyle.Bold));
                //CrystalDecisions.CrystalReports.Engine.FieldObject F5 = ((CrystalDecisions.CrystalReports.Engine.FieldObject)CAR.ReportDefinition.Sections["Section3"].ReportObjects["Col5"]);
                //F5.ApplyFont(new Font("Times New Roman", 9, FontStyle.Bold));

                for (int i = 1; i <= 20; i++)
                {
                    ColName = "Col" + Convert.ToString(i);
                    ColHeaderName = "Text" + Convert.ToString(i);

                    if (i <= WV.Length)
                    {
                        if (i == 1)
                            LeftVal = LeftVal + (Convert.ToInt32(LV[0]) * 48);
                        else
                        {
                            if (Convert.ToInt32(LV[i - 1]) == 0)
                                LeftVal = LeftVal + (Convert.ToInt32(WV[i - 2]) * 48) + 20;
                        }
                        CAR.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Top = (Convert.ToInt32(TV[0]) * 48);// +(Convert.ToInt32(TV[i - 1]) * 48);
                        CAR.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Width = (Convert.ToInt32(WV[i - 1]) * 48);
                        CAR.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Width = (Convert.ToInt32(WV[i - 1]) * 48);

                        CAR.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Height = (Convert.ToInt32(HV[i - 1]) * 48);

                        if (Convert.ToInt32(LV[i - 1]) == 0)
                        {
                            CAR.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = LeftVal;// (Convert.ToInt32(LV[i - 1]) * 48);
                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Left = LeftVal; //(Convert.ToInt32(LV[i - 1]) * 48);
                        }
                        else
                        {
                            CAR.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = (Convert.ToInt32(LV[i - 1]) * 48);
                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Left = (Convert.ToInt32(LV[i - 1]) * 48);
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "L")
                        {
                            CAR.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "M")
                        {
                            CAR.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "R")
                        {
                            CAR.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                            CAR.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                    }
                    else
                    {
                        CAR.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Top = 0;
                        CAR.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Width = 0;
                        CAR.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Height = 0;
                        CAR.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = 0;
                    }
                }
                //CAR.ReportDefinition.Sections["Section3"].Height = Convert.ToInt32(HV[0]) + 48;
                //CrystalDecisions.CrystalReports

                //CrystalDecisions.CrystalReports

                Section section = CAR.ReportDefinition.Sections["Section3"];
                section.Height = (Convert.ToInt32(HV[0]) * 48) + (Convert.ToInt32(TV[0]) * 48);

                //ReportDocument gg = new ReportDocument();
                //Section

            }
            catch { }
        }
        #endregion

        #region Printing View Letter Format
        public void ReportHeaderArrenge(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
        {
            try
            {
                string HeaderName = "";
                int TotalHeight = 0;
                int row_top = 0;
                string ColName = "";
                string FN = "";
                float FSI = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 0; i < 11; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName]);
                        txtApprovalStatus1.Text = Convert.ToString(Header_String[i]);

                        if (Convert.ToString(FontSty[i]) == "B")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                        if (Convert.ToString(FontSty[i]) == "I")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                        if (Convert.ToString(FontSty[i]) == "U")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                        if (Convert.ToString(FontSty[i]) == "R")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));
                        if (i == 0)
                        {
                            CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);

                            //Change 05.11.14 (When Report Export The Hender Not Visible)
                            int len = Convert.ToInt32(WV[i]);
                            if (len <= 330)
                                CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (len * 48);
                            else
                                CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = 330 * 48;

                            //CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            //End 05.11.14

                            CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            //row_top = (Convert.ToInt32(TV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                        }
                        else
                        {
                            row_top = row_top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i - 1]) * 48);
                            CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = row_top;

                            //Change 05.11.14 (When Report Export The Hender Not Visible)
                            int len = Convert.ToInt32(WV[i]);
                            if (len <= 330)
                                CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (len * 48);
                            else
                                CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = 330 * 48;

                            //CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            //End 05.11.14
                            CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = 0;
                        CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = 0;
                        CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = 0;
                        CAR_L.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = 0;
                    }
                }
                //CAR_L.ReportDefinition.Sections["Section1"].Height = TotalHeight + 20;
                Section section = CAR_L.ReportDefinition.Sections["Section1"];
                section.Height = TotalHeight;
            }
            catch { }
        }

        public void ReportPageHeaderArrenge(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
        {
            try
            {
                string HeaderName = "";
                int TotalHeight = 0, Top = 0;
                string FN = "";
                float FSI = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 10 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName]);
                        txtApprovalStatus1.Text = Convert.ToString(Header_String[i]);
                        if (Convert.ToString(FontSty[i]) == "B")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                        if (Convert.ToString(FontSty[i]) == "I")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                        if (Convert.ToString(FontSty[i]) == "U")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                        if (Convert.ToString(FontSty[i]) == "R")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));

                        if (i == 0)
                        {
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            if (i == 3)
                            {
                                TotalHeight = (Convert.ToInt32(TV[0]) * 48);
                                columnHeaderTop = (Convert.ToInt32(TV[0]) * 48);
                                //TotalHeight = 48;
                                //columnHeaderTop = 48;
                            }
                            else if (i == 2)
                            {
                                if (Header_String.Length == 3)
                                    TotalHeight = 48;
                            }

                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Top = TotalHeight;
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);

                            //Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            //columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);

                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }

                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Top = 0;
                        CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = 0;
                        CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Height = 0;
                        CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                string ColName = "";
                for (int i = 1; i <= 20; i++)
                {
                    ColName = "Text" + Convert.ToString(i);
                    CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[ColName].Top = TotalHeight + 70;

                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                    txtApprovalStatus1.Text = "";
                }

                CrystalDecisions.CrystalReports.Engine.TextObject txtLine1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L.ReportDefinition.Sections["Section2"].ReportObjects["Line11"]);
                txtLine1.Top = TotalHeight + 20;

                CrystalDecisions.CrystalReports.Engine.TextObject txtLine2 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L.ReportDefinition.Sections["Section2"].ReportObjects["Line22"]);
                if (TotalHeight == 0)
                    TotalHeight = 50;
                //txtLine2.Top = TotalHeight + 220 + CAR_L.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Height;

                txtLine2.Top = TotalHeight + 60 + 70 + 250 + 200;
                Section section = CAR.ReportDefinition.Sections["Section2"];
                section.Height = TotalHeight + 300 + 140 + 300;


                //Section section = CAR_L.ReportDefinition.Sections["Section2"];
                ////section.Height = columnHeaderTop + 200 + 60 + 260;
                //section.Height = TotalHeight + 220 + 60 + CAR_L.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Height;
            }
            catch { }
        }

        public void ReportPageFooterArrenge(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
        {
            try
            {
                string HeaderName = "";
                int TotalHeight = 0, Top = 0;
                string FN = "";
                float FSI = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 20 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName]);
                        txtApprovalStatus1.Text = Convert.ToString(Header_String[i]);
                        if (Convert.ToString(FontSty[i]) == "B")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                        if (Convert.ToString(FontSty[i]) == "I")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                        if (Convert.ToString(FontSty[i]) == "U")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                        if (Convert.ToString(FontSty[i]) == "R")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));

                        if (i == 0)
                        {
                            CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = Top + (Convert.ToInt32(TV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = 0;
                        CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = 0;
                        CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = 0;
                        CAR_L.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                //CrystalDecisions.CrystalReports.Engine.LineObject Line_5 = ((CrystalDecisions.CrystalReports.Engine.LineObject)CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["Line5"]);
                //Line_5.LineThickness = 20;               

                if (PageNumberDisplay == true)
                {
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Top = TotalHeight + 50;
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Width = 1600;
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Height = 220;
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Left = 13800;
                }
                else
                {
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Top = 0;
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Width = 0;
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Height = 0;
                    CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Left = 0;
                    TotalHeight = TotalHeight - 50;
                }
                Section section = CAR_L.ReportDefinition.Sections["Section5"];
                section.Height = TotalHeight + 50 + 220 + 48;
            }
            catch { }
        }

        public void ReportFooterArrenge(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
        {
            try
            {
                string HeaderName = "";
                int TotalHeight = 0, Top = 0;
                string FN = "";
                float FSI = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 30 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName]);
                        txtApprovalStatus1.Text = Convert.ToString(Header_String[i]);
                        if (Convert.ToString(FontSty[i]) == "B")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                        if (Convert.ToString(FontSty[i]) == "I")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                        if (Convert.ToString(FontSty[i]) == "U")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                        if (Convert.ToString(FontSty[i]) == "R")
                            txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));

                        if (i == 0)
                        {
                            CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = Top + (Convert.ToInt32(TV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = 0;
                        CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = 0;
                        CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = 0;
                        CAR_L.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                CrystalDecisions.CrystalReports.Engine.LineObject Line_5 = ((CrystalDecisions.CrystalReports.Engine.LineObject)CAR_L.ReportDefinition.Sections["Section5"].ReportObjects["Line5"]);
                Line_5.LineThickness = 20;
                Line_5.LineColor = System.Drawing.Color.Black;

                Section section = CAR_L.ReportDefinition.Sections["Section4"];
                section.Height = TotalHeight + 48;
            }
            catch { }
        }

        public void DetailsColumnsHeaderArrenge(string[] COL_NAME, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
        {
            try
            {
                string ColName = "";
                string FN = "";
                float FSI = 0;

                for (int i = 1; i <= COL_NAME.Length; i++)
                {
                    ColName = "Text" + Convert.ToString(i);
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                    txtApprovalStatus1.Text = "";
                    txtApprovalStatus1.Text = Convert.ToString(COL_NAME[i - 1]);

                    FN = Convert.ToString(FontName[i - 1]);
                    FSI = Convert.ToSingle(FontSize[i - 1]);
                    if (Convert.ToString(FontSty[i - 1]) == "B")
                        txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Bold));
                    if (Convert.ToString(FontSty[i - 1]) == "I")
                        txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Italic));
                    if (Convert.ToString(FontSty[i - 1]) == "U")
                        txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Underline));
                    if (Convert.ToString(FontSty[i - 1]) == "R")
                        txtApprovalStatus1.ApplyFont(new Font(FN, FSI, FontStyle.Regular));

                    //txtApprovalStatus1.ApplyFont(new Font("Comic Sans MS", 8.25F, FontStyle.Bold));   
                }
            }
            catch { }
        }

        public void DetailsColumnsArrenge(string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string Print_Style)
        {
            try
            {
                string ColName = "";
                string ColHeaderName = "";
                int LeftVal = 0;

                string[] TV = new string[] { };
                TV = TopValue.Trim().Split(',');

                string[] WV = new string[] { };
                WV = WidthValue.Trim().Split(',');

                string[] HV = new string[] { };
                HV = HeightValue.Trim().Split(',');

                string[] LV = new string[] { };
                LV = LeftValue.Trim().Split(',');

                string[] AV = new string[] { };
                AV = AlignmentValue.Trim().Split(',');

                for (int i = 1; i <= 20; i++)
                {
                    ColName = "Col" + Convert.ToString(i);
                    ColHeaderName = "Text" + Convert.ToString(i);
                    if (i <= WV.Length)
                    {
                        if (i == 1)
                            LeftVal = LeftVal + (Convert.ToInt32(LV[0]) * 48);
                        else
                        {
                            if (Convert.ToInt32(LV[i - 1]) == 0)
                                LeftVal = LeftVal + (Convert.ToInt32(WV[i - 2]) * 48) + 20;
                        }
                        CAR_L.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Top = (Convert.ToInt32(TV[0]) * 48);// +(Convert.ToInt32(TV[i - 1]) * 48);
                        CAR_L.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Width = (Convert.ToInt32(WV[i - 1]) * 48);
                        CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Width = (Convert.ToInt32(WV[i - 1]) * 48);
                        CAR_L.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Height = (Convert.ToInt32(HV[i - 1]) * 48);
                        if (Convert.ToInt32(LV[i - 1]) == 0)
                        {
                            CAR_L.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = LeftVal;// (Convert.ToInt32(LV[i - 1]) * 48);
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Left = LeftVal; //(Convert.ToInt32(LV[i - 1]) * 48);
                        }
                        else
                        {
                            CAR_L.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = (Convert.ToInt32(LV[i - 1]) * 48);
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Left = (Convert.ToInt32(LV[i - 1]) * 48);
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "L")
                        {
                            CAR_L.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "M")
                        {
                            CAR_L.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "R")
                        {
                            CAR_L.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                            CAR_L.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                    }
                    else
                    {
                        CAR_L.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Top = 0;
                        CAR_L.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Width = 0;
                        CAR_L.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Height = 0;
                        CAR_L.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = 0;
                    }
                }
                //CAR_L.ReportDefinition.Sections["Section3"].Height = Convert.ToInt32(HV[0]) + 48;
                //CrystalDecisions.CrystalReports

                //CrystalDecisions.CrystalReports

                Section section = CAR_L.ReportDefinition.Sections["Section3"];
                section.Height = (Convert.ToInt32(HV[0]) * 48) + (Convert.ToInt32(TV[0]) * 48);

                //ReportDocument gg = new ReportDocument();
                //Section

            }
            catch { }
        }
        #endregion

        private void crystalReportViewer1_MouseClick(object sender, MouseEventArgs e)
        {
            PrintDialog pp = new PrintDialog();
            pp.PrinterSettings.DefaultPageSettings.Landscape = false;
        }
        //End(27.05.13)

    }    
}
  