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
        CrystalAllReport_legal CAR_L = new CrystalAllReport_legal();
        CrystalAllReport_L CAR_L1 = new CrystalAllReport_L();
        CrystalAllReport_PE CAR_PE = new CrystalAllReport_PE();
        CrystalReport_LetterFormat CARLF = new CrystalReport_LetterFormat();
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        public int opt = 0;
        //string Imagedocument = "", 
        //Imagedocument2 = "", 
        //Imagedocument3 = "";

      
        int columnHeaderTop = 0;
        public bool PageNumberDisplay = true;

        public Form1()
        {
            InitializeComponent();
        }
        public void Recover(DataTable dt, string coname, string mon,string lin,string loc) // Bibhas 20-01-2020
        {
            crpt_Reg_Recovery bor = new crpt_Reg_Recovery();
            bor.SetDataSource(dt);
            bor.SetParameterValue(0, coname);//"company"

            bor.SetParameterValue("lin", lin);//"lin"
            //bor.SetParameterValue("location", loc);//"location"
            bor.SetParameterValue(1, mon);//"month"
            if (loc.Trim() == "")
            {
                crystalReportViewer1.ReportSource = bor;
            }
            else if (loc.Trim() == "1")
            {
                bor.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = bor;
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


        public void ChequeReport()
        {
            CrystalRptCheqfromat1 cf = new CrystalRptCheqfromat1();
           
            crystalReportViewer1.ReportSource = cf;
        }


        public void attn_daily_exp(DataTable dt, int type, DataTable dt2,string fname)
        {
            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();

            if (type == 28)
            {
                crpt_MstRoll_28 m28 = new crpt_MstRoll_28();
                m28.SetDataSource(dt);
                crystalReportViewer1.ReportSource = m28;

                rptExportOption = m28.ExportOptions;

                rptFileDestOption.DiskFileName = fname;

                rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                //if we want to generate the report as PDF, change the ExportFormatType as "ExportFormatType.PortableDocFormat"
                //if we want to generate the report as Excel, change the ExportFormatType as "ExportFormatType.Excel"
                rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                rptExportOption.ExportDestinationOptions = rptFileDestOption;
                rptExportOption.ExportFormatOptions = rptFormatOption;

                try
                {

                    m28.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fname);
                }
                catch { }
            }
            else if (type == 29)
            {

                crpt_MstRoll_29 m29 = new crpt_MstRoll_29();
                m29.SetDataSource(dt);
                crystalReportViewer1.ReportSource = m29;

                rptExportOption = m29.ExportOptions;

                rptFileDestOption.DiskFileName = fname;


                rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                //if we want to generate the report as PDF, change the ExportFormatType as "ExportFormatType.PortableDocFormat"
                //if we want to generate the report as Excel, change the ExportFormatType as "ExportFormatType.Excel"
                rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                rptExportOption.ExportDestinationOptions = rptFileDestOption;
                rptExportOption.ExportFormatOptions = rptFormatOption;

                try
                {

                    m29.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fname);
                }
                catch { }
            }
            else if (type == 30)
            {
                crpt_MstRoll_30 m30 = new crpt_MstRoll_30();
                m30.SetDataSource(dt);

                crystalReportViewer1.ReportSource = m30;

                rptExportOption = m30.ExportOptions;

                rptFileDestOption.DiskFileName = fname;


                rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                //if we want to generate the report as PDF, change the ExportFormatType as "ExportFormatType.PortableDocFormat"
                //if we want to generate the report as Excel, change the ExportFormatType as "ExportFormatType.Excel"
                rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                rptExportOption.ExportDestinationOptions = rptFileDestOption;
                rptExportOption.ExportFormatOptions = rptFormatOption;

                try
                {

                    m30.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fname);
                }
                catch { }
            }
            else if (type == 31)
            {
                crpt_MstRoll_31 m31 = new crpt_MstRoll_31();
                m31.SetDataSource(dt);
                crystalReportViewer1.ReportSource = m31;

                rptExportOption = m31.ExportOptions;

                rptFileDestOption.DiskFileName = fname;


                rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                //if we want to generate the report as PDF, change the ExportFormatType as "ExportFormatType.PortableDocFormat"
                //if we want to generate the report as Excel, change the ExportFormatType as "ExportFormatType.Excel"
                rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                rptExportOption.ExportDestinationOptions = rptFileDestOption;
                rptExportOption.ExportFormatOptions = rptFormatOption;

                try
                {

                    m31.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fname);
                }
                catch { }

            }

           
        }
        public void attn_daily(DataTable dt, int type, DataTable dt2)
        {
            if (type == 28)
            {
                crpt_MstRoll_28 m28 = new crpt_MstRoll_28();
                m28.SetDataSource(dt);
                crystalReportViewer1.ReportSource = m28;
            }
            else if (type == 29)
            {

                crpt_MstRoll_29 m29 = new crpt_MstRoll_29();
                m29.SetDataSource(dt);
                crystalReportViewer1.ReportSource = m29;
            }
            else if (type == 30)
            {
                crpt_MstRoll_30 m30 = new crpt_MstRoll_30();
                m30.SetDataSource(dt);
                
                crystalReportViewer1.ReportSource = m30;

            }
            else if (type == 31)
            {
                crpt_MstRoll_31 m31 = new crpt_MstRoll_31();
                m31.SetDataSource(dt);
                crystalReportViewer1.ReportSource = m31;

            }


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

        public void BillOutstandingReport(DataTable dt, string coname, string coadd, string datefrom, string dateto,string ptype)
        {
            CrystalReportBillOutstandingReport bor = new CrystalReportBillOutstandingReport();
            bor.SetDataSource(dt);
            bor.SetParameterValue(0,coname);
            bor.SetParameterValue(1, coadd);
            bor.SetParameterValue(2, datefrom);
            bor.SetParameterValue(3, dateto);
            crystalReportViewer1.ReportSource = bor;
        }

        public void CompositePayslip_print(string CompanyName, DataSet billng, string Narration, int stp, string sub)
        {
          //  CrystalRptCompoPayslip grn = new CrystalRptCompoPayslip();
            
            crptPayslip_company grn = new crptPayslip_company();

            //CrystalRptCompoPaysliphalf grn1 = new CrystalRptCompoPaysliphalf();
            CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            //CrystalRptCompoPayslipTrail grn2 = new CrystalRptCompoPayslipTrail();
            CrystalRptTrail grn2 = new CrystalRptTrail();
            

            //-----------------------------------------------------------
            /*
            CrystalRptGross grn_gr = new CrystalRptGross();
            //crpt_payslip_single grn_gr = new crpt_payslip_single();

            CrystalRptVoucher grn = new CrystalRptVoucher();
            crpt_payslip_ng grn_ng = new crpt_payslip_ng();

            //crptPayslipU grn = new crptPayslipU();
            CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            CrystalRptTrail grn2 = new CrystalRptTrail();

            */
            //-----------------------------------------------------------

            // string query = edpcom.GetresultS("select Cmpimage from branch where  FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'");
            //if (query!="")
            // {
            //     DataTable dt1=new DataTable();
            //     dt1.Columns.Add("Document_Image", typeof(string));
            //     DataRow dr = dt1.NewRow();
            //     dr["Document_Image"] = query; // or dr[0]="Mohammad";
            //     dt1.Rows.Add(dr);

            //     Imagedocument2 = query;
            //     if (Imagedocument2 != "")
            //     {
            //         MemoryStream stream = new MemoryStream();

            //         TextObject text5;
            //         text5 = (TextObject)grn.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["Text9"];
            //         //text5.Text = "It works";

            //         //picturedocument.Image = null;
            //         //context.Response.BinaryWrite((Byte[])dr[0]);
            //         byte[] image = ((byte[])dt1.Rows[0]["Document_Image"]);
            //         stream.Write(image, 0, image.Length);
            //         //edpcon.Close();
            //         Bitmap bitmap = new Bitmap(stream);
            //         picturedocument.Image = bitmap;




            //     }
            // }



            if (stp == 1)
            {
                grn.SetDataSource(billng);
                ////grn.Subreports["CrystalRptCompoPaysliphalf.rpt"].SetDataSource(billng.Tables["ppp1"]);
                ////grn.Subreports["CrystalRptCompoPayslipTrail.rpt"].SetDataSource(billng.Tables["ppq1"]);

                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(ds.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else if (stp == 3)
            {
                grn.SetDataSource(billng);
                grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["psE"]);
                grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["psD"]);
                crystalReportViewer1.ReportSource = grn;

                /*
                 string duration = "";
                 grn_gr.Database.Tables[0].SetDataSource(billng);
            
                 grn_gr.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                 grn_gr.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);
                 grn_gr.SetParameterValue(0, CompanyName);
                 grn_gr.SetParameterValue(1, duration);
                 grn_gr.SetParameterValue(2, sub);

                 crystalReportViewer1.ReportSource = grn_gr;
               * */
            }
            else
            {
                grn.SetDataSource(billng);
                //grn.Subreports[0].SetDataSource(ds.Tables[1]);
                //grn.Subreports[0].SetDataSource(ds.Tables[2]);
                grn.Subreports["CrystalRptCompoPaysliphalf.rpt"].SetDataSource(billng.Tables["ppp1"]);
                grn.Subreports["CrystalRptCompoPayslipTrail.rpt"].SetDataSource(billng.Tables["ppq1"]);


                try
                {
                    grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
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


        public void frmRegWageXVII(DataTable dt,string cname,string cadd,string mnth,string year,string lname,string clname,int ptype,string pagesize)
        {
            RegOfWagesFrm rpt = new RegOfWagesFrm();
            rpt.SetDataSource(dt);
            rpt.SetParameterValue(0, cname);
            rpt.SetParameterValue(1, cadd);
            rpt.SetParameterValue(2, clname);
            rpt.SetParameterValue(3, lname);
            rpt.SetParameterValue(4, mnth);
            rpt.SetParameterValue(5, year);
            if (ptype == 1)
                crystalReportViewer1.ReportSource = rpt;
            else
            {
                if (pagesize == "A4")
                    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                else
                    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal;
                rpt.PrintToPrinter(1, false, 0, 0);
            }
        }

        public void frmRegWageXVII_Updated(DataTable dt, ArrayList EHead, ArrayList DHead, int ErnStartPos, int DedStartPos, string cname, string cadd, string mnth, string year, string lname, string clname, int ptype, string pagesize,string clAdd,string format)
        {
            if (format == "old")
            {
                CrystalReportRegOfWages row = new CrystalReportRegOfWages();
                string ColName = "";
                int CountOfCols = 0;
                for (int i = ErnStartPos; i <= DedStartPos - 2; i++)
                {
                    CountOfCols = i - ErnStartPos + 12;
                    dt.Columns[i].ColumnName = "col" + CountOfCols;
                    
                }
                for (int i = DedStartPos; i <= dt.Columns.Count - 3; i++)
                {
                    CountOfCols = i - DedStartPos + 23;
                    dt.Columns[i].ColumnName = "col" + CountOfCols;
                    
                }
                int ie=0, id=0;
                dt.Columns.Add("EHead", typeof(string));
                dt.Columns.Add("DHead", typeof(string));
                for (int ind = 0; ind < dt.Rows.Count; ind++)
                {ie=0; id=0;
                    for (int i = 0; i < EHead.Count; i++)
                    {
                        ie++;
                        //ColName = "Text" + Convert.ToString(i + 12);
                        //CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                        //txtApprovalStatus1.Text = "";
                        //txtApprovalStatus1.Text = Convert.ToString(EHead[i]);
                        if (ie <= 2)
                        {
                            if (i == 0)
                                dt.Rows[ind]["EHead"] = EHead[i].ToString().Trim() + " : " + dt.Rows[ind]["col12"].ToString();
                            else
                                dt.Rows[ind]["EHead"] = dt.Rows[ind]["EHead"].ToString() + "                " + EHead[i].ToString().Trim() + " : " + dt.Rows[ind][ErnStartPos + i].ToString();
                        }
                        else
                        {
                            ie = 1;
                            dt.Rows[ind]["EHead"] = dt.Rows[ind]["EHead"].ToString() + Environment.NewLine + EHead[i].ToString().Trim() + " : " + dt.Rows[ind][ErnStartPos + i].ToString();

                        }

                    }
                    for (int i = 0; i < DHead.Count; i++)
                    {
                        id++;

                        //ColName = "Text" + Convert.ToString(i + 23);
                        //CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                        //txtApprovalStatus1.Text = "";
                        //txtApprovalStatus1.Text = Convert.ToString(DHead[i]);

                        if (id <= 2)
                        {
                            if (i == 0)
                                dt.Rows[ind]["DHead"] = DHead[i].ToString().Trim() + " : " + dt.Rows[ind]["col23"].ToString();
                            else
                                dt.Rows[ind]["DHead"] = dt.Rows[ind]["DHead"].ToString() + "                " + DHead[i].ToString().Trim() + " : " + dt.Rows[ind][DedStartPos + i].ToString();
                        }
                        else
                        {
                            id = 1;
                            dt.Rows[ind]["DHead"] = dt.Rows[ind]["DHead"].ToString() + Environment.NewLine + DHead[i].ToString().Trim() + " : " + dt.Rows[ind][DedStartPos + i].ToString();

                        }
                    }
                }
                dt.Columns.Remove("col12");
                dt.Columns.Remove("col23");
                //for (int i = ErnStartPos+1; i <= DedStartPos - 2; i++)
                //{
                //    CountOfCols = i - ErnStartPos + 12;
                //    dt.Columns.Remove("col" + CountOfCols);
                //}
                //DedStartPos = dt.Columns["TotalEarning"].Ordinal;
                //for (int i = DedStartPos+1; i <= dt.Columns.Count - 2; i++)
                //{
                //    CountOfCols = i - DedStartPos + 23;
                //    dt.Columns.Remove("col" + CountOfCols);
                //}
                dt.Columns["EHead"].ColumnName = "col12";
                dt.Columns["DHead"].ColumnName = "col23";
                //row.SetDataSource(dt);
                row.Database.Tables[0].SetDataSource(dt);
                row.SetParameterValue(0, cname);
                row.SetParameterValue(1, cadd);
                row.SetParameterValue(2, clname);
                row.SetParameterValue(3, lname);
                row.SetParameterValue(4, mnth);
                row.SetParameterValue(5, year);
                if (ptype == 1)
                    crystalReportViewer1.ReportSource = row;
                else
                {
                    if (pagesize == "A4")
                        //row.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        pagesize = "";
                    else
                        row.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal;
                    row.PrintToPrinter(1, false, 0, 0);
                }
            }
            else if (format == "new")
            {
                Hashtable htEarnStatic = new Hashtable();
                Hashtable htDedcStatic = new Hashtable();
                int noOfEarnStatic = 0;
                int noOfDedcStatic = 0;
                CrystalReportRegOfWages_new row = new CrystalReportRegOfWages_new();
                string ColName = "";
                int CountOfCols = 0;

                if (EHead.Contains("BS"))
                {
                    noOfEarnStatic++;
                    htEarnStatic["BS"] = EHead.IndexOf("BS");
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects["Text9"]);
                    txtApprovalStatus1.Text = "BS";
                    dt.Columns["BS"].ColumnName = "col12";
                }
                else
                {
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects["Text9"]);
                    txtApprovalStatus1.Text = "BS";
                }
                if (EHead.Contains("DA"))
                {
                    noOfEarnStatic++;
                    htEarnStatic["DA"] = EHead.IndexOf("DA");
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects["Text10"]);
                    txtApprovalStatus1.Text = "DA";
                    dt.Columns["DA"].ColumnName = "col13";
                }
                else
                {
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects["Text10"]);
                    txtApprovalStatus1.Text = "DA";
                }
                if (EHead.Contains("OTA"))
                {
                    noOfEarnStatic++;
                    htEarnStatic["OTA"] = EHead.IndexOf("OTA");
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects["Text11"]);
                    txtApprovalStatus1.Text = "OTA";
                    dt.Columns["OTA"].ColumnName = "col14";
                }
                else
                {
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects["Text11"]);
                    txtApprovalStatus1.Text = "OTA";
                }

                if (DHead.Contains("PF"))
                {
                    noOfDedcStatic++;
                    htDedcStatic["PF"] = DHead.IndexOf("PF");
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects["Text15"]);
                    txtApprovalStatus1.Text = "PF";
                    dt.Columns["PF"].ColumnName = "col23";
                }
                else
                {
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects["Text15"]);
                    txtApprovalStatus1.Text = "PF";
                }
                if (DHead.Contains("ESI"))
                {
                    noOfDedcStatic++;
                    htDedcStatic["ESI"] = DHead.IndexOf("ESI");
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects["Text16"]);
                    txtApprovalStatus1.Text = "ESI";
                    dt.Columns["ESI"].ColumnName = "col24";
                }
                else
                {
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects["Text16"]);
                    txtApprovalStatus1.Text = "ESI";
                }


                for (int i = ErnStartPos, j = ErnStartPos; i <= DedStartPos - 2 - noOfEarnStatic && j <= DedStartPos - 2; i++,j++)
                {
                    if (dt.Columns[j].ColumnName == "col12" || dt.Columns[j].ColumnName == "col13" || dt.Columns[j].ColumnName == "col14")
                    {
                        i--;
                        continue;
                    }
                    CountOfCols = i - ErnStartPos + 12 + 3;
                    dt.Columns[j].ColumnName = "col" + CountOfCols;
                }
                for (int i = DedStartPos, j = DedStartPos; i <= dt.Columns.Count - 3 - noOfDedcStatic && j <= dt.Columns.Count - 3; i++,j++)
                {
                    if (dt.Columns[j].ColumnName == "col23" || dt.Columns[j].ColumnName == "col24")
                    {
                        i--;
                        continue;
                    }
                    CountOfCols = i - DedStartPos + 23 + 2;
                    dt.Columns[j].ColumnName = "col" + CountOfCols;
                }
                /*
                for (int i = 0, j = 0; i < EHead.Count-noOfEarnStatic && j < EHead.Count; i++,j++)
                {
                    if (EHead[j].ToString() == "BS" || EHead[j].ToString() == "DA" || EHead[j].ToString() == "OTA")
                    {
                        i--;
                        continue;
                    }
                    ColName = "Text" + Convert.ToString(i + 9 + 3);
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                    txtApprovalStatus1.Text = "";
                    txtApprovalStatus1.Text = Convert.ToString(EHead[j]);
                }
                for (int i = 0, j = 0; i < DHead.Count-noOfDedcStatic && j < DHead.Count; i++, j++)
                {
                    if (DHead[j].ToString() == "PF" || DHead[j].ToString() == "ESI")
                    {
                        i--;
                        continue;
                    }
                    ColName = "Text" + Convert.ToString(i + 15 + 2);
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                    txtApprovalStatus1.Text = "";
                    txtApprovalStatus1.Text = Convert.ToString(DHead[j]);
                }*/

                //row.SetDataSource(dt);
                row.Database.Tables[0].SetDataSource(dt);
                row.SetParameterValue(0, cname);
                row.SetParameterValue(1, cadd);
                row.SetParameterValue(2, clname);
                row.SetParameterValue(3, lname);
                row.SetParameterValue(4, mnth);
                row.SetParameterValue(5, year);
                row.SetParameterValue(6, clAdd);
                if (ptype == 1)
                    crystalReportViewer1.ReportSource = row;
                else
                {
                    if (pagesize == "A4")
                        //row.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        pagesize = "";
                    else
                        row.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal;
                    row.PrintToPrinter(1, false, 0, 0);
                }
            
            }
            //crystalReportViewer1.ReportSource = row;
        }

        //public void PaymentRegisterReportPrint(DataTable dt,ArrayList alColumnHeader,string companyName,string dateFrom,string dateTo,int ptype)
        //{
        //    CrystalReportPaymentRegisterReport crprr = new CrystalReportPaymentRegisterReport();
        //    string ColName = "";
        //    for (int i = 0; i < dt.Columns.Count; i++)
        //    {
        //        dt.Columns[i].ColumnName = "col" + (i+1);
        //    }
        //    for (int i = 0; i < alColumnHeader.Count; i++)
        //    {
        //        ColName = "Text" + Convert.ToString(i + 1);
        //        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)crprr.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
        //        txtApprovalStatus1.Text = "";
        //        txtApprovalStatus1.Text = Convert.ToString(alColumnHeader[i]);
        //    }
        //    crprr.SetDataSource(dt);
        //    crprr.SetParameterValue(0, companyName);
        //    crprr.SetParameterValue(1, dateFrom);
        //    crprr.SetParameterValue(2, dateTo);
        //    if (ptype == 1)
        //        crystalReportViewer1.ReportSource = crprr;
        //    else
        //        crprr.PrintToPrinter(1,false,0,0);
        //}
        //================== 25/05/2018
        public void PaymentRegisterReportPrint(string Company, string sub, string CO_ADD, DataTable dta, int flag)
        {
            // CrystalRegisterReport1 crprr = new CrystalRegisterReport1();
            CrystalReceipt3Report crprr = new CrystalReceipt3Report();
            crprr.SetDataSource(dta);
            crprr.SetParameterValue(0, Company);
            crprr.SetParameterValue(1, sub);
            crprr.SetParameterValue(2, CO_ADD);


            crystalReportViewer1.ReportSource = crprr;

            if (flag == 1)
            {

                crprr.PrintToPrinter(1, false, 0, 0);
            }


        }
        public void GstReport(string Company, string sub, string CO_ADD, DataTable dt)
        {
            CrystalGST crg = new CrystalGST();
            crg.SetDataSource(dt);
            crg.SetParameterValue(0, Company);
            crg.SetParameterValue(1, sub);
            crg.SetParameterValue(2, CO_ADD);

            crystalReportViewer1.ReportSource = crg;
        }

        //=====================================================================

        public void CanceledBillRegister(DataTable dt,string CoName,string CoAdd,string DateRange)
        {
            CrystalReportCanceledBillReg crcbr = new CrystalReportCanceledBillReg();
            crcbr.SetDataSource(dt);
            crcbr.SetParameterValue(0, CoName);
            crcbr.SetParameterValue(1, CoAdd);
            crcbr.SetParameterValue(2, DateRange);

            crystalReportViewer1.ReportSource = crcbr;
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
        public void Empprofitloss_print(string CompanyName, DataSet billng, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp)
        {
            CrystalRptPrftloss grn = new CrystalRptPrftloss();
            //CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            //CrystalRptTrail grn2 = new CrystalRptTrail();
            if (stp == 1)
            {
                grn.SetDataSource(billng);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(ds.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else
            {
                grn.SetDataSource(billng.Tables["profitloss"]);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                //grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }

        public void attend_pdf(DataTable dt, string co, string loc, string mon,string fname)
        {

            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();


            AttenRpt crptPS = new AttenRpt();



            crptPS.SetDataSource(dt);

            
            crptPS.SetParameterValue(0, co);
            crptPS.SetParameterValue(1, loc);
            crptPS.SetParameterValue(2, mon);

            crystalReportViewer1.ReportSource = crptPS;

            rptExportOption = crptPS.ExportOptions;




            rptFileDestOption.DiskFileName = fname;

            
                rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                //if we want to generate the report as PDF, change the ExportFormatType as "ExportFormatType.PortableDocFormat"
                //if we want to generate the report as Excel, change the ExportFormatType as "ExportFormatType.Excel"
                rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                rptExportOption.ExportDestinationOptions = rptFileDestOption;
                rptExportOption.ExportFormatOptions = rptFormatOption;
                        
            try
            {
                crystalReportViewer1.ReportSource = crptPS;
                crptPS.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fname);
            }
            catch { }
            

        }




        public void payslip_save(DataSet ds, int stp, DataSet billng, string sub, int cmp, string fname)
        {
            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();

            
            crpt_payslip_single crptPS = new crpt_payslip_single();



            crptPS.SetDataSource(billng);

            crptPS.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
            crptPS.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);
            //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
            //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(ds.Tables[2]);



            //grn1.SetDataSource(billng);
            //grn2.SetDataSource(billng);
            crptPS.SetParameterValue(0, CompanyName);
            ////grn.SetParameterValue(1, duration);
            crptPS.SetParameterValue(2, sub);

            crystalReportViewer1.ReportSource = crptPS;

            rptExportOption = crptPS.ExportOptions;




            rptFileDestOption.DiskFileName = fname;

            {
                rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                //if we want to generate the report as PDF, change the ExportFormatType as "ExportFormatType.PortableDocFormat"
                //if we want to generate the report as Excel, change the ExportFormatType as "ExportFormatType.Excel"
                rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                rptExportOption.ExportDestinationOptions = rptFileDestOption;
                rptExportOption.ExportFormatOptions = rptFormatOption;
            }
            //crystalReportViewer1.ReportSource = crptPS;
            //crystalReportViewer1.ExportReport();
            try
            {
                crptPS.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fname);
                crptPS.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, fname);
            }
            catch { }
            try
            {
                // crptPS.Export();
            }
            catch { }
        }



        //added by rupak,anirban on 06.08.2012.................
        public void grn_print(string CompanyName, DataSet billng, string sub, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp,int pr)
        {
            string duration = "";
                CrystalRptGross grn_gr = new CrystalRptGross();
            //crpt_payslip_single grn_gr = new crpt_payslip_single();
           
                CrystalRptVoucher grn = new CrystalRptVoucher();
                crpt_payslip_ng grn_ng = new crpt_payslip_ng();
                crpt_payslip_fxix grn_fxix = new crpt_payslip_fxix();
                crpt_payslip_GE grn_ge = new crpt_payslip_GE();
            
            //crptPayslipU grn = new crptPayslipU();
            CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            CrystalRptTrail grn2 = new CrystalRptTrail();


            // string query = edpcom.GetresultS("select Cmpimage from branch where  FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'");
            //if (query!="")
            // {
            //     DataTable dt1=new DataTable();
            //     dt1.Columns.Add("Document_Image", typeof(string));
            //     DataRow dr = dt1.NewRow();
            //     dr["Document_Image"] = query; // or dr[0]="Mohammad";
            //     dt1.Rows.Add(dr);

            //     Imagedocument2 = query;
            //     if (Imagedocument2 != "")
            //     {
            //         MemoryStream stream = new MemoryStream();

            //         TextObject text5;
            //         text5 = (TextObject)grn.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["Text9"];
            //         //text5.Text = "It works";

            //         //picturedocument.Image = null;
            //         //context.Response.BinaryWrite((Byte[])dr[0]);
            //         byte[] image = ((byte[])dt1.Rows[0]["Document_Image"]);
            //         stream.Write(image, 0, image.Length);
            //         //edpcon.Close();
            //         Bitmap bitmap = new Bitmap(stream);
            //         picturedocument.Image = bitmap;




            //     }
            // }



            if (stp == 1)
            {
                grn.Database.Tables[0].SetDataSource(billng);
                //grn.SetDataSource(billng.Tables[0]);
             

                grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);
                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(ds.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                grn.SetParameterValue(0, CompanyName);
                grn.SetParameterValue(1, duration);
                grn.SetParameterValue(2, sub);
               
               // crystalReportViewer1.ReportSource = grn;
                try
                {
                    grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    if (pr == 1)
                    {
                        grn.PrintToPrinter(1, false, 0, 0);
                    }
                    else
                    {
                        crystalReportViewer1.ReportSource = grn;
                    }
                }
                catch { }

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else if (stp == 2)
            {
                grn_gr.Database.Tables[0].SetDataSource(billng);
                //grn.SetDataSource(billng.Tables[0]);


                grn_gr.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                grn_gr.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);
                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(ds.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                grn_gr.SetParameterValue(0, CompanyName);
                grn.SetParameterValue(1, duration);
                grn_gr.SetParameterValue(2, sub);

               // crystalReportViewer1.ReportSource = grn_gr;

                try
                {
                    grn_gr.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    if (pr == 1)
                    { grn_gr.PrintToPrinter(1, false, 0, 0); }
                    else
                    {
                        crystalReportViewer1.ReportSource = grn_gr;
                    }
                }
                catch { }

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else if (stp == 3)
            {
                grn_gr.Database.Tables[0].SetDataSource(billng);
                //grn.SetDataSource(billng.Tables[0]);


                grn_gr.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                grn_gr.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);
                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(ds.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                grn_gr.SetParameterValue(0, CompanyName);
                grn.SetParameterValue(1, duration);
                grn_gr.SetParameterValue(2, sub);

                //crystalReportViewer1.ReportSource = grn_gr;

                try
                {
                    grn_gr.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    if (pr == 1)
                    { grn_gr.PrintToPrinter(1, false, 0, 0); }
                    else
                    {
                        crystalReportViewer1.ReportSource = grn_gr;
                    }
                }
                catch { }

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else if (stp == 4)
            {
                grn_ng.Database.Tables[0].SetDataSource(billng);
                //grn.SetDataSource(billng.Tables[0]);


                grn_ng.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                grn_ng.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);
                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(ds.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                grn_ng.SetParameterValue(0, CompanyName);
                grn.SetParameterValue(1, duration);
                grn_ng.SetParameterValue(2, sub);

               // crystalReportViewer1.ReportSource = grn_ng;
                try
                {
                    grn_ng.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    if (pr == 1)
                    { grn_ng.PrintToPrinter(1, false, 0, 0); }
                    else
                    {
                        crystalReportViewer1.ReportSource = grn_ng;
                    }
                }
                catch { }

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else if (stp == 5)
            {
                grn_ge.Database.Tables[0].SetDataSource(billng);
                //grn.SetDataSource(billng.Tables[0]);


                grn_ge.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                grn_ge.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);
                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(ds.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                grn_ge.SetParameterValue(0, CompanyName);
                grn_ge.SetParameterValue(1, duration);
                grn_ge.SetParameterValue(2, sub);

                // crystalReportViewer1.ReportSource = grn_ng;
                try
                {
                    grn_ge.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    if (pr == 1)
                    { grn_ge.PrintToPrinter(1, false, 0, 0); }
                    else
                    {
                        crystalReportViewer1.ReportSource = grn_ge;
                    }
                }
                catch { }

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else if (stp == 6)
            {
                grn_fxix.Database.Tables[0].SetDataSource(billng);
                //grn.SetDataSource(billng.Tables[0]);


                grn_fxix.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                grn_fxix.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);
                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(ds.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                grn_fxix.SetParameterValue(0, CompanyName);
                grn.SetParameterValue(1, duration);
                grn_fxix.SetParameterValue(2, sub);

                // crystalReportViewer1.ReportSource = grn_ng;
                try
                {
                    grn_fxix.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    if (pr == 1)
                    { grn_fxix.PrintToPrinter(1, false, 0, 0); }
                    else
                    {
                        crystalReportViewer1.ReportSource = grn_fxix;
                    }
                }
                catch { }

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else
            {
                grn.SetDataSource(billng.Tables[0]);
                //grn.Subreports[0].SetDataSource(ds.Tables[1]);
                //grn.Subreports[0].SetDataSource(ds.Tables[2]);
                grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                grn.SetParameterValue(0, CompanyName);
                grn.SetParameterValue(1, duration);
                grn.SetParameterValue(2, sub);

                try
                {
                    grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    if (pr == 1)
                    { grn.PrintToPrinter(1, false, 0, 0); }
                    else
                    {
                        crystalReportViewer1.ReportSource = grn;
                    }
                }
                catch { }
            }
        }
        
        
        //public void CompositePayslip_print(string CompanyName, DataSet billng, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp)
        //{
        //    CrystalRptCompoPayslip  grn = new CrystalRptCompoPayslip ();
        //    CrystalRptCompoPaysliphalf  grn1 = new CrystalRptCompoPaysliphalf ();
        //    CrystalRptCompoPayslipTrail grn2 = new CrystalRptCompoPayslipTrail();


        //    // string query = edpcom.GetresultS("select Cmpimage from branch where  FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "'");
        //    //if (query!="")
        //    // {
        //    //     DataTable dt1=new DataTable();
        //    //     dt1.Columns.Add("Document_Image", typeof(string));
        //    //     DataRow dr = dt1.NewRow();
        //    //     dr["Document_Image"] = query; // or dr[0]="Mohammad";
        //    //     dt1.Rows.Add(dr);

        //    //     Imagedocument2 = query;
        //    //     if (Imagedocument2 != "")
        //    //     {
        //    //         MemoryStream stream = new MemoryStream();

        //    //         TextObject text5;
        //    //         text5 = (TextObject)grn.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["Text9"];
        //    //         //text5.Text = "It works";

        //    //         //picturedocument.Image = null;
        //    //         //context.Response.BinaryWrite((Byte[])dr[0]);
        //    //         byte[] image = ((byte[])dt1.Rows[0]["Document_Image"]);
        //    //         stream.Write(image, 0, image.Length);
        //    //         //edpcon.Close();
        //    //         Bitmap bitmap = new Bitmap(stream);
        //    //         picturedocument.Image = bitmap;




        //    //     }
        //    // }



        //    if (stp == 1)
        //    {
        //        grn.SetDataSource(billng);
        //        grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
        //        grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

        //        //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
        //        //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(ds.Tables[2]);



        //        //grn1.SetDataSource(billng);
        //        //grn2.SetDataSource(billng);
        //        //grn.SetParameterValue(0, CompanyName);
        //        ////grn.SetParameterValue(1, duration);
        //        ////grn.SetParameterValue(2, addr);
        //        ////grn.SetParameterValue(3, panno);
        //        ////grn.SetParameterValue(4, addr1);
        //        //grn.SetParameterValue(5, agentcompany);
        //        //grn.SetParameterValue(6, agentaddr);
        //        //grn.SetParameterValue(7, agentaddr1);
        //        //grn.SetParameterValue(8, phone);
        //        //grn.SetParameterValue(9, area);
        //        //grn.SetParameterValue(10, billdt);
        //        //grn.SetParameterValue(11, uservouchar);
        //        //grn.SetParameterValue(12, challan);
        //        //grn.SetParameterValue(13, amtword);
        //        ////grn.SetParameterValue(14, tin1);
        //        //grn.SetParameterValue(15, finalamt);
        //        //grn.SetParameterValue(16, challandt);
        //        //grn.SetParameterValue(17, amtvalue);
        //        //grn.SetParameterValue(18, lorry_no);
        //        //grn.SetParameterValue(19, locname);
        //        //grn.SetParameterValue(20, modtran);
        //        //grn.SetParameterValue(21, prtyname);
        //        //grn.SetParameterValue(22, prtyadd1);
        //        //grn.SetParameterValue(23, prtyadd2);
        //        //grn.SetParameterValue(24, prtycity);
        //        //grn.SetParameterValue(25, prtycitypinno);
        //        //grn.SetParameterValue(26, prtytele1);
        //        //grn.SetParameterValue(27, prtytele2);
        //        //grn.SetParameterValue(28, prtyemailid);
        //        //grn.SetParameterValue(29, prtyfax);
        //        //grn.SetParameterValue(30, prtyeccno);
        //        //grn.SetParameterValue(31, prtytin);
        //        //grn.SetParameterValue(32, Narration);
        //        crystalReportViewer1.ReportSource = grn;

        //        //crystalReportViewer1.ReportSource = grn1;
        //        //crystalReportViewer1.ReportSource = grn2;

        //    }
        //    else
        //    {
        //        grn.SetDataSource(billng);
        //        //grn.Subreports[0].SetDataSource(ds.Tables[1]);
        //        //grn.Subreports[0].SetDataSource(ds.Tables[2]);
        //        grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
        //        grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


        //        grn.SetParameterValue(0, CompanyName);
        //        //grn.SetParameterValue(1, duration);
        //        //grn.SetParameterValue(2, addr);
        //        //grn.SetParameterValue(3, panno);
        //        //grn.SetParameterValue(4, addr1);
        //        ////grn.SetParameterValue(5, agentcompany);
        //        ////grn.SetParameterValue(6, agentaddr);
        //        ////grn.SetParameterValue(7, agentaddr1);
        //        ////grn.SetParameterValue(8, phone);
        //        ////grn.SetParameterValue(9, area);
        //        ////grn.SetParameterValue(10, billdt);
        //        ////grn.SetParameterValue(11, uservouchar);
        //        ////grn.SetParameterValue(12, challan);
        //        ////grn.SetParameterValue(13, amtword);
        //        //////grn.SetParameterValue(14, tin1);
        //        ////grn.SetParameterValue(15, finalamt);
        //        ////grn.SetParameterValue(16, challandt);
        //        ////grn.SetParameterValue(17, amtvalue);
        //        ////grn.SetParameterValue(18, lorry_no);
        //        ////grn.SetParameterValue(19, locname);
        //        ////grn.SetParameterValue(20, modtran);
        //        ////grn.SetParameterValue(21, prtyname);
        //        ////grn.SetParameterValue(22, prtyadd1);
        //        ////grn.SetParameterValue(23, prtyadd2);
        //        ////grn.SetParameterValue(24, prtycity);
        //        ////grn.SetParameterValue(25, prtycitypinno);
        //        ////grn.SetParameterValue(26, prtytele1);
        //        ////grn.SetParameterValue(27, prtytele2);
        //        ////grn.SetParameterValue(28, prtyemailid);
        //        ////grn.SetParameterValue(29, prtyfax);
        //        ////grn.SetParameterValue(30, prtyeccno);
        //        ////grn.SetParameterValue(31, prtytin);
        //        ////grn.SetParameterValue(32, Narration);
        //        try
        //        {
        //            grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
        //            grn.PrintToPrinter(1, false, 0, 0);
        //            crystalReportViewer1.ReportSource = grn;
        //        }
        //        catch { }
        //    }
        //}

        public void paybill_print(string CompanyName, DataSet billng, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp)
        {
            CrystalRptPayBill grn = new CrystalRptPayBill();
            //CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            //CrystalRptTrail grn2 = new CrystalRptTrail();
            if (stp == 1)
            {
                grn.SetDataSource(billng);
               // grn.SetDataSource(billng.Tables["Branch"]);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(ds.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else
            {
                grn.SetDataSource(billng.Tables["paybill"]);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                //grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }

        public void prntgststmntrpt(string coname, string coadd, string datee, DataTable dt)
        {
           BillGSTDetailsDTWise bgstdt = new BillGSTDetailsDTWise();
           // Bill_complete bgstdt = new Bill_complete();
            bgstdt.SetDataSource(dt);

            bgstdt.SetParameterValue(0, coname);
            bgstdt.SetParameterValue(1, coadd);
            bgstdt.SetParameterValue(2, datee);
            
            crystalReportViewer1.ReportSource = bgstdt;
        }

        public void paybillO_print(string stname, string stper,string odet, string trmcon,string bankD,string onote, string CompanyName, DataSet ds, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp,string refno,string pono,string DesgInfo,Boolean boolAdPermission,string tc)
        {
            CrystalRptPayBillO grn = new CrystalRptPayBillO();
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            txtReportHeader = grn.ReportDefinition.ReportObjects["Text22"] as TextObject;
            if(boolAdPermission)
                txtReportHeader.Text = "";
          //  SubBillRpt subrpt = new SubBillRpt();
            // grn.Subreports["SubBillRpt.rpt"].SetDataSource(ds.Tables["taxrpt"]);
            //CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            //CrystalRptTrail grn2 = new CrystalRptTrail();
            if (stp == 1)
            {
                
                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, bankD);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, tc);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetParameterValue(0, DesgInfo);
                //grn.SetParameterValue("billDescription", DesgInfo, grn.Subreports["CrystalRptDesgWiseDtl.rpt"].Name.ToString());
                // grn.SetDataSource(billng.Tables["Branch"]);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(DS.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else
            {
                grn.SetDataSource(ds.Tables["paybill"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, bankD);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, tc);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                //grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }

        public void paybillO_Format1_blank_print(string stname, string stper, string odet, string trmcon, string bankD, string onote, string CompanyName, DataSet ds, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp, string refno, string pono, string DesgInfo, Boolean boolAdPermission, string tc, string bill_type, string bl_type)
        {
            CrystalRptPayBillO_format1_blank grn = new CrystalRptPayBillO_format1_blank();
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            txtReportHeader = grn.ReportDefinition.ReportObjects["Text22"] as TextObject;
            if (boolAdPermission)
                txtReportHeader.Text = "";
            //  SubBillRpt subrpt = new SubBillRpt();
            // grn.Subreports["SubBillRpt.rpt"].SetDataSource(ds.Tables["taxrpt"]);
            //CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            //CrystalRptTrail grn2 = new CrystalRptTrail();
            if (stp == 1)
            {

                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, bankD);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, tc);
                grn.SetParameterValue(9, bill_type);
                grn.SetParameterValue(10, bl_type);

               

                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetParameterValue(0, DesgInfo);
                //grn.SetParameterValue("billDescription", DesgInfo, grn.Subreports["CrystalRptDesgWiseDtl.rpt"].Name.ToString());
                // grn.SetDataSource(billng.Tables["Branch"]);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(DS.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else
            {
                grn.SetDataSource(ds.Tables["paybill"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, bankD);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, tc);
                grn.SetParameterValue(7, bill_type);

                grn.SetParameterValue(8, bl_type);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                //grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }



        public void paybillO_Format1_print(string stname, string stper, string odet, string trmcon, string bankD, string onote, string CompanyName, DataSet ds, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp, string refno, string pono, string DesgInfo, Boolean boolAdPermission, string tc, string bill_type, string bl_type)
        {
            CrystalRptPayBillO_Format1 grn = new CrystalRptPayBillO_Format1();
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            txtReportHeader = grn.ReportDefinition.ReportObjects["Text22"] as TextObject;
            if (boolAdPermission)
                txtReportHeader.Text = "";
            //  SubBillRpt subrpt = new SubBillRpt();
            // grn.Subreports["SubBillRpt.rpt"].SetDataSource(ds.Tables["taxrpt"]);
            //CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            //CrystalRptTrail grn2 = new CrystalRptTrail();
            if (stp == 1)
            {

                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, bankD);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, tc);
                grn.SetParameterValue(9, bill_type);
                grn.SetParameterValue(10, bl_type);

               

                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetParameterValue(0, DesgInfo);
                //grn.SetParameterValue("billDescription", DesgInfo, grn.Subreports["CrystalRptDesgWiseDtl.rpt"].Name.ToString());
                // grn.SetDataSource(billng.Tables["Branch"]);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(DS.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else
            {
                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, bankD);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, tc);
                grn.SetParameterValue(9, bill_type);
                grn.SetParameterValue(10, bl_type);

                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                //grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }


        public void paybillO_Format2_mail(string stname, string stper, string odet, string trmcon, string bankD, string onote, string CompanyName, DataSet ds, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp, string refno, string pono, string DesgInfo, Boolean boolAdPermission, string prep, string enclosure, string loc, string prev, string tc, string bill_type, string bl_type, string range, string nar, string fname)
        {

            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();


            CrystalRptPayBillO_Format2 grn = new CrystalRptPayBillO_Format2();
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            txtReportHeader = grn.ReportDefinition.ReportObjects["Text22"] as TextObject;
            if (boolAdPermission)
                txtReportHeader.Text = "";
             if (stp == 3)
            {
                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, enclosure);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, prep);
                grn.SetParameterValue(9, loc);
                grn.SetParameterValue(10, edpcom.GetAmountFormat(Convert.ToDouble(prev), 2));
                grn.SetParameterValue(11, tc);
                grn.SetParameterValue(12, bill_type);
                grn.SetParameterValue(13, bl_type);

                grn.SetParameterValue(14, range);
                grn.SetParameterValue(15, nar);
                crystalReportViewer1.ReportSource = grn;

                rptExportOption = grn.ExportOptions;




                rptFileDestOption.DiskFileName = fname;

                {
                    rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                    //if we want to generate the report as PDF, change the ExportFormatType as "ExportFormatType.PortableDocFormat"
                    //if we want to generate the report as Excel, change the ExportFormatType as "ExportFormatType.Excel"
                    rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rptExportOption.ExportDestinationOptions = rptFileDestOption;
                    rptExportOption.ExportFormatOptions = rptFormatOption;
                }
                //crystalReportViewer1.ReportSource = crptPS;
                //crystalReportViewer1.ExportReport();
                try
                {
                    grn.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fname);
                }
                catch { }

            }


        }
        public void paybillO_RTF_print(string stname, string stper, string odet, string trmcon, string bankD, string onote, string CompanyName, DataSet ds, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp, string refno, string pono, string DesgInfo, Boolean boolAdPermission, string prep, string enclosure, string loc, string prev, string tc, string bill_type, string bl_type, string range, string nar)
        {

            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();


            CrystalRptPayBillO_Rtf grn = new CrystalRptPayBillO_Rtf();
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            txtReportHeader = grn.ReportDefinition.ReportObjects["Text22"] as TextObject;
            if (boolAdPermission)
                txtReportHeader.Text = "";
            //  SubBillRpt subrpt = new SubBillRpt();
            // grn.Subreports["SubBillRpt.rpt"].SetDataSource(ds.Tables["taxrpt"]);
            //CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            //CrystalRptTrail grn2 = new CrystalRptTrail();
            if (stp == 1)
            {

                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, enclosure);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, prep);
                grn.SetParameterValue(9, loc);
                grn.SetParameterValue(10, edpcom.GetAmountFormat(Convert.ToDouble(prev), 2));
                grn.SetParameterValue(11, tc);
                grn.SetParameterValue(12, bill_type);
                grn.SetParameterValue(13, bl_type);

                grn.SetParameterValue(14, range);
                grn.SetParameterValue(15, nar);

                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetParameterValue(0, DesgInfo);
                //grn.SetParameterValue("billDescription", DesgInfo, grn.Subreports["CrystalRptDesgWiseDtl.rpt"].Name.ToString());
                // grn.SetDataSource(billng.Tables["Branch"]);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(DS.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else if (stp == 3)
            {
                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, enclosure);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, prep);
                grn.SetParameterValue(9, loc);
                grn.SetParameterValue(10, edpcom.GetAmountFormat(Convert.ToDouble(prev), 2));
                grn.SetParameterValue(11, tc);
                grn.SetParameterValue(12, bill_type);
                grn.SetParameterValue(13, bl_type);

                grn.SetParameterValue(14, range);
                grn.SetParameterValue(15, nar);
                crystalReportViewer1.ReportSource = grn;


            }
            else
            {
                grn.SetDataSource(ds.Tables["paybill"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, bankD);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, tc);
                grn.SetParameterValue(7, bill_type);
                grn.SetParameterValue(8, bl_type);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                //grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }



        public void paybillO_GST_print(string stname, string stper, string odet, string trmcon, string bankD, string onote, string CompanyName, DataSet ds, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp, string refno, string pono, string DesgInfo, Boolean boolAdPermission, string prep, string enclosure, string loc, string prev, string tc, string bill_type, string bl_type, string range, string nar, string hsn, string tamt, string sper, string samt, string cper, string camt, string tval, string ptype)
        {

            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();


            CrystalRptPayBillO_GST grn = new CrystalRptPayBillO_GST();
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            txtReportHeader = grn.ReportDefinition.ReportObjects["Text22"] as TextObject;
            if (boolAdPermission)
                txtReportHeader.Text = "";
            //  SubBillRpt subrpt = new SubBillRpt();
            // grn.Subreports["SubBillRpt.rpt"].SetDataSource(ds.Tables["taxrpt"]);
            //CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            //CrystalRptTrail grn2 = new CrystalRptTrail();
            if (stp == 1)
            {

                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, enclosure);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, prep);
                grn.SetParameterValue(9, loc);
                grn.SetParameterValue(10, edpcom.GetAmountFormat(Convert.ToDouble(prev), 2));
                grn.SetParameterValue(11, tc);
                grn.SetParameterValue(12, bill_type);
                grn.SetParameterValue(13, bl_type);

                grn.SetParameterValue(14, range);
                grn.SetParameterValue(15, nar);


                grn.SetParameterValue("hsn",hsn);
                grn.SetParameterValue("TAmt",tamt);
                grn.SetParameterValue("sgstper",sper);
                grn.SetParameterValue("sgst",samt);
                grn.SetParameterValue("cgstper",cper);
                grn.SetParameterValue("cgstamt",camt);
                grn.SetParameterValue("TVAL", tval);

                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetParameterValue(0, DesgInfo);
                //grn.SetParameterValue("billDescription", DesgInfo, grn.Subreports["CrystalRptDesgWiseDtl.rpt"].Name.ToString());
                // grn.SetDataSource(billng.Tables["Branch"]);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(DS.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else if (stp == 3)
            {
                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, enclosure);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, prep);
                grn.SetParameterValue(9, loc);
                grn.SetParameterValue(10, edpcom.GetAmountFormat(Convert.ToDouble(prev), 2));
                grn.SetParameterValue(11, tc);
                grn.SetParameterValue(12, bill_type);
                grn.SetParameterValue(13, bl_type);

                grn.SetParameterValue(14, range);
                grn.SetParameterValue(15, nar);
                crystalReportViewer1.ReportSource = grn;


            }
            else
            {
                grn.SetDataSource(ds.Tables["paybill"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, bankD);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, tc);
                grn.SetParameterValue(7, bill_type);
                grn.SetParameterValue(8, bl_type);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                //grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }






        public void paybillO_Format2_print(string stname, string stper, string odet, string trmcon, string bankD, string onote, string CompanyName, DataSet ds, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp, string refno, string pono, string DesgInfo, Boolean boolAdPermission, string prep, string enclosure, string loc, string prev, string tc, string bill_type, string bl_type, string range, string nar)
        {

            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();


            CrystalRptPayBillO_Format2 grn = new CrystalRptPayBillO_Format2();
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            txtReportHeader = grn.ReportDefinition.ReportObjects["Text22"] as TextObject;
            if (boolAdPermission)
                txtReportHeader.Text = "";
            //  SubBillRpt subrpt = new SubBillRpt();
            // grn.Subreports["SubBillRpt.rpt"].SetDataSource(ds.Tables["taxrpt"]);
            //CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            //CrystalRptTrail grn2 = new CrystalRptTrail();
            if (stp == 1)
            {

                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, enclosure);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, prep);
                grn.SetParameterValue(9, loc);
                grn.SetParameterValue(10, edpcom.GetAmountFormat(Convert.ToDouble(prev), 2));
                grn.SetParameterValue(11, tc);
                grn.SetParameterValue(12, bill_type);
                grn.SetParameterValue(13, bl_type);

                grn.SetParameterValue(14, range);
                grn.SetParameterValue(15, nar);

                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetParameterValue(0, DesgInfo);
                //grn.SetParameterValue("billDescription", DesgInfo, grn.Subreports["CrystalRptDesgWiseDtl.rpt"].Name.ToString());
                // grn.SetDataSource(billng.Tables["Branch"]);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(DS.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else if (stp == 3)
            {
                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, enclosure);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, prep);
                grn.SetParameterValue(9, loc);
                grn.SetParameterValue(10, edpcom.GetAmountFormat(Convert.ToDouble(prev), 2));
                grn.SetParameterValue(11, tc);
                grn.SetParameterValue(12, bill_type);
                grn.SetParameterValue(13, bl_type);

                grn.SetParameterValue(14, range);
                grn.SetParameterValue(15, nar);
                crystalReportViewer1.ReportSource = grn;


            }
            else
            {
                grn.SetDataSource(ds.Tables["paybill"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, bankD);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, tc);
                grn.SetParameterValue(7, bill_type);
                grn.SetParameterValue(8, bl_type);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                //grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }




        public void paybillO_Format_print(string stname, string stper, string odet, string trmcon, string bankD, string onote, string CompanyName, DataSet ds, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp, string refno, string pono, string DesgInfo, Boolean boolAdPermission, string prep, string enclosure, string loc, string prev, string tc, string bill_type, string bl_type, string range, string nar)
        {

            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();


            CrystalRptPayBillO_Format2 grn = new CrystalRptPayBillO_Format2();
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            txtReportHeader = grn.ReportDefinition.ReportObjects["Text22"] as TextObject;
            if (boolAdPermission)
                txtReportHeader.Text = "";
            //  SubBillRpt subrpt = new SubBillRpt();
            // grn.Subreports["SubBillRpt.rpt"].SetDataSource(ds.Tables["taxrpt"]);
            //CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            //CrystalRptTrail grn2 = new CrystalRptTrail();
            if (stp == 1)
            {

                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, enclosure);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, prep);
                grn.SetParameterValue(9, loc);
                grn.SetParameterValue(10,edpcom.GetAmountFormat(Convert.ToDouble(prev),2));
                grn.SetParameterValue(11, tc);
                grn.SetParameterValue(12, bill_type);
                grn.SetParameterValue(13, bl_type);

                grn.SetParameterValue(14, range);
                grn.SetParameterValue(15, nar);

               
                //crystalReportViewer1.ReportSource = grn;
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else if (stp == 3)
            {
                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, enclosure);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, prep);
                grn.SetParameterValue(9, loc);
                grn.SetParameterValue(10, edpcom.GetAmountFormat(Convert.ToDouble(prev), 2));
                grn.SetParameterValue(11, tc);
                grn.SetParameterValue(12, bill_type);
                grn.SetParameterValue(13, bl_type);

                grn.SetParameterValue(14, range);
                grn.SetParameterValue(15, nar);
                //crystalReportViewer1.ReportSource = grn;

                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }


            }
            else
            {
                grn.SetDataSource(ds.Tables["paybill"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, bankD);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, tc);
                grn.SetParameterValue(7, bill_type);
                grn.SetParameterValue(8, bl_type);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                //grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }


        //public void paybillO_Format3_print(string stname, string stper, string odet, string trmcon, string bankD, string onote, string CompanyName, DataSet ds, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp, string refno, string pono, string DesgInfo, Boolean boolAdPermission, string prep, string enclosure, string loc, string prev, string tc)
        //{
        //    CrystalRptPayBillO_Format3 grn = new CrystalRptPayBillO_Format3();
        //    CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
        //    txtReportHeader = grn.ReportDefinition.ReportObjects["Text22"] as TextObject;
        //    if (boolAdPermission)
        //        txtReportHeader.Text = "";
        //    //  SubBillRpt subrpt = new SubBillRpt();
        //    // grn.Subreports["SubBillRpt.rpt"].SetDataSource(ds.Tables["taxrpt"]);
        //    //CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
        //    //CrystalRptTrail grn2 = new CrystalRptTrail();
        //    if (stp == 1)
        //    {

        //        grn.SetDataSource(ds);
        //        //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
        //        grn.SetParameterValue(0, stname);
        //        grn.SetParameterValue(1, stper);
        //        grn.SetParameterValue(2, odet);
        //        grn.SetParameterValue(3, trmcon);
        //        grn.SetParameterValue(4, enclosure);
        //        grn.SetParameterValue(5, onote);
        //        grn.SetParameterValue(6, refno);
        //        grn.SetParameterValue(7, pono);
        //        grn.SetParameterValue(8, prep);
        //        grn.SetParameterValue(9, loc);
        //        grn.SetParameterValue(10, edpcom.GetAmountFormat(Convert.ToDouble(prev), 2));
        //        grn.SetParameterValue(11, tc);
        //        //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetParameterValue(0, DesgInfo);
        //        //grn.SetParameterValue("billDescription", DesgInfo, grn.Subreports["CrystalRptDesgWiseDtl.rpt"].Name.ToString());
        //        // grn.SetDataSource(billng.Tables["Branch"]);
        //        //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
        //        //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

        //        //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
        //        //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(DS.Tables[2]);



        //        //grn1.SetDataSource(billng);
        //        //grn2.SetDataSource(billng);
        //        //grn.SetParameterValue(0, CompanyName);
        //        ////grn.SetParameterValue(1, duration);
        //        ////grn.SetParameterValue(2, addr);
        //        ////grn.SetParameterValue(3, panno);
        //        ////grn.SetParameterValue(4, addr1);
        //        //grn.SetParameterValue(5, agentcompany);
        //        //grn.SetParameterValue(6, agentaddr);
        //        //grn.SetParameterValue(7, agentaddr1);
        //        //grn.SetParameterValue(8, phone);
        //        //grn.SetParameterValue(9, area);
        //        //grn.SetParameterValue(10, billdt);
        //        //grn.SetParameterValue(11, uservouchar);
        //        //grn.SetParameterValue(12, challan);
        //        //grn.SetParameterValue(13, amtword);
        //        ////grn.SetParameterValue(14, tin1);
        //        //grn.SetParameterValue(15, finalamt);
        //        //grn.SetParameterValue(16, challandt);
        //        //grn.SetParameterValue(17, amtvalue);
        //        //grn.SetParameterValue(18, lorry_no);
        //        //grn.SetParameterValue(19, locname);
        //        //grn.SetParameterValue(20, modtran);
        //        //grn.SetParameterValue(21, prtyname);
        //        //grn.SetParameterValue(22, prtyadd1);
        //        //grn.SetParameterValue(23, prtyadd2);
        //        //grn.SetParameterValue(24, prtycity);
        //        //grn.SetParameterValue(25, prtycitypinno);
        //        //grn.SetParameterValue(26, prtytele1);
        //        //grn.SetParameterValue(27, prtytele2);
        //        //grn.SetParameterValue(28, prtyemailid);
        //        //grn.SetParameterValue(29, prtyfax);
        //        //grn.SetParameterValue(30, prtyeccno);
        //        //grn.SetParameterValue(31, prtytin);
        //        //grn.SetParameterValue(32, Narration);
        //        crystalReportViewer1.ReportSource = grn;

        //        //crystalReportViewer1.ReportSource = grn1;
        //        //crystalReportViewer1.ReportSource = grn2;

        //    }
        //    else
        //    {
        //        grn.SetDataSource(ds.Tables["paybill"]);
        //        grn.SetParameterValue(0, stname);
        //        grn.SetParameterValue(1, stper);
        //        grn.SetParameterValue(2, odet);
        //        grn.SetParameterValue(3, trmcon);
        //        grn.SetParameterValue(4, bankD);
        //        grn.SetParameterValue(5, onote);
        //        grn.SetParameterValue(6, tc);
        //        //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
        //        //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


        //        //grn.SetParameterValue(0, CompanyName);
        //        //grn.SetParameterValue(1, duration);
        //        //grn.SetParameterValue(2, addr);
        //        //grn.SetParameterValue(3, panno);
        //        //grn.SetParameterValue(4, addr1);
        //        //grn.SetParameterValue(5, agentcompany);
        //        //grn.SetParameterValue(6, agentaddr);
        //        //grn.SetParameterValue(7, agentaddr1);
        //        //grn.SetParameterValue(8, phone);
        //        //grn.SetParameterValue(9, area);
        //        //grn.SetParameterValue(10, billdt);
        //        //grn.SetParameterValue(11, uservouchar);
        //        //grn.SetParameterValue(12, challan);
        //        //grn.SetParameterValue(13, amtword);
        //        ////grn.SetParameterValue(14, tin1);
        //        //grn.SetParameterValue(15, finalamt);
        //        //grn.SetParameterValue(16, challandt);
        //        //grn.SetParameterValue(17, amtvalue);
        //        //grn.SetParameterValue(18, lorry_no);
        //        //grn.SetParameterValue(19, locname);
        //        //grn.SetParameterValue(20, modtran);
        //        //grn.SetParameterValue(21, prtyname);
        //        //grn.SetParameterValue(22, prtyadd1);
        //        //grn.SetParameterValue(23, prtyadd2);
        //        //grn.SetParameterValue(24, prtycity);
        //        //grn.SetParameterValue(25, prtycitypinno);
        //        //grn.SetParameterValue(26, prtytele1);
        //        //grn.SetParameterValue(27, prtytele2);
        //        //grn.SetParameterValue(28, prtyemailid);
        //        //grn.SetParameterValue(29, prtyfax);
        //        //grn.SetParameterValue(30, prtyeccno);
        //        //grn.SetParameterValue(31, prtytin);
        //        //grn.SetParameterValue(32, Narration);
        //        try
        //        {
        //            //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
        //            grn.PrintToPrinter(1, false, 0, 0);
        //            crystalReportViewer1.ReportSource = grn;
        //        }
        //        catch { }
        //    }
        //}

        public void paybillO_Format3_mail(string stname, string stper, string odet, string trmcon, string bankD, string onote, string CompanyName, DataSet ds, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp, string refno, string pono, string DesgInfo, Boolean boolAdPermission, string prep, string enclosure, string loc, string prev, string tc, string bill_type, string bl_type, string range, string nar, string fname)
        {
            ExportOptions rptExportOption;
            DiskFileDestinationOptions rptFileDestOption = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions rptFormatOption = new PdfRtfWordFormatOptions();


            CrystalRptPayBillO_Format3 grn = new CrystalRptPayBillO_Format3();
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            txtReportHeader = grn.ReportDefinition.ReportObjects["Text22"] as TextObject;
            if (boolAdPermission)
                txtReportHeader.Text = "";

            if (stp == 1)
            {

                grn.SetDataSource(ds);

                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, enclosure);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, prep);
                grn.SetParameterValue(9, loc);
                grn.SetParameterValue(10, edpcom.GetAmountFormat(Convert.ToDouble(prev), 2));
                grn.SetParameterValue(11, tc);
                grn.SetParameterValue(12, bill_type);
                grn.SetParameterValue(13, bl_type);

                grn.SetParameterValue(14, range);
                grn.SetParameterValue(15, nar);

                crystalReportViewer1.ReportSource = grn;

                rptExportOption = grn.ExportOptions;

                rptFileDestOption.DiskFileName = fname;

                {
                    rptExportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                    //if we want to generate the report as PDF, change the ExportFormatType as "ExportFormatType.PortableDocFormat"
                    //if we want to generate the report as Excel, change the ExportFormatType as "ExportFormatType.Excel"
                    rptExportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rptExportOption.ExportDestinationOptions = rptFileDestOption;
                    rptExportOption.ExportFormatOptions = rptFormatOption;
                }
                //crystalReportViewer1.ReportSource = crptPS;
                //crystalReportViewer1.ExportReport();
                try
                {
                    grn.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fname);
                }
                catch { }

            }
            
        }

        public void paybillO_Format3_print(string stname, string stper, string odet, string trmcon, string bankD, string onote, string CompanyName, DataSet ds, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp, string refno, string pono, string DesgInfo, Boolean boolAdPermission, string prep, string enclosure, string loc, string prev, string tc, string bill_type,string bl_type,string range,string nar)
        {
            CrystalRptPayBillO_Format3 grn = new CrystalRptPayBillO_Format3();
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            txtReportHeader = grn.ReportDefinition.ReportObjects["Text22"] as TextObject;
            if (boolAdPermission)
                txtReportHeader.Text = "";
            //  SubBillRpt subrpt = new SubBillRpt();
            // grn.Subreports["SubBillRpt.rpt"].SetDataSource(ds.Tables["taxrpt"]);
            //CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            //CrystalRptTrail grn2 = new CrystalRptTrail();
            if (stp == 1)
            {

                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, enclosure);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, prep);
                grn.SetParameterValue(9, loc);
                grn.SetParameterValue(10, edpcom.GetAmountFormat(Convert.ToDouble(prev), 2));
                grn.SetParameterValue(11, tc);
                grn.SetParameterValue(12, bill_type);
                grn.SetParameterValue(13, bl_type);

                grn.SetParameterValue(14, range);
                grn.SetParameterValue(15, nar);

                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetParameterValue(0, DesgInfo);
                //grn.SetParameterValue("billDescription", DesgInfo, grn.Subreports["CrystalRptDesgWiseDtl.rpt"].Name.ToString());
                // grn.SetDataSource(billng.Tables["Branch"]);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(DS.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else
            {
                grn.SetDataSource(ds.Tables["paybill"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, bankD);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, tc);
                grn.SetParameterValue(7, bill_type);
                grn.SetParameterValue(8, bl_type);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                //grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }



        public void paybillO_Format2_blank_print(string stname, string stper, string odet, string trmcon, string bankD, string onote, string CompanyName, DataSet ds, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp, string refno, string pono, string DesgInfo, Boolean boolAdPermission, string prep, string enclosure, string loc, string prev, string tc, string bill_type, string bl_type, string range, string nar)
        {
            CrystalRptPayBillO_Format2_blank grn = new CrystalRptPayBillO_Format2_blank();
            CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
            txtReportHeader = grn.ReportDefinition.ReportObjects["Text22"] as TextObject;
            if (boolAdPermission)
                txtReportHeader.Text = "";
            //  SubBillRpt subrpt = new SubBillRpt();
            // grn.Subreports["SubBillRpt.rpt"].SetDataSource(ds.Tables["taxrpt"]);
            //CrystalRptVoucherhalf grn1 = new CrystalRptVoucherhalf();
            //CrystalRptTrail grn2 = new CrystalRptTrail();
            if (stp == 1)
            {

                grn.SetDataSource(ds);
                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetDataSource(ds.Tables["dsgwsbilld"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, enclosure);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, refno);
                grn.SetParameterValue(7, pono);
                grn.SetParameterValue(8, prep);
                grn.SetParameterValue(9, loc);
                grn.SetParameterValue(10, edpcom.GetAmountFormat(Convert.ToDouble(prev), 2));
                grn.SetParameterValue(11, tc);
                grn.SetParameterValue(12, bill_type);
                grn.SetParameterValue(13, bl_type);

                grn.SetParameterValue(14, range);
                grn.SetParameterValue(15, nar);

                //grn.Subreports["CrystalRptDesgWiseDtl.rpt"].SetParameterValue(0, DesgInfo);
                //grn.SetParameterValue("billDescription", DesgInfo, grn.Subreports["CrystalRptDesgWiseDtl.rpt"].Name.ToString());
                // grn.SetDataSource(billng.Tables["Branch"]);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(DS.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else
            {
                grn.SetDataSource(ds.Tables["paybill"]);
                grn.SetParameterValue(0, stname);
                grn.SetParameterValue(1, stper);
                grn.SetParameterValue(2, odet);
                grn.SetParameterValue(3, trmcon);
                grn.SetParameterValue(4, bankD);
                grn.SetParameterValue(5, onote);
                grn.SetParameterValue(6, tc);
                grn.SetParameterValue(7, bill_type);
                grn.SetParameterValue(8, bl_type);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                //grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }


        public void desgWiseBillPrint(DataTable dt,string str1,string totalamt)
        {
            CrystalRptDesgWiseDtl desgwsdtl = new CrystalRptDesgWiseDtl();
            desgwsdtl.SetDataSource(dt);
            desgwsdtl.SetParameterValue(0,str1);
            //desgwsdtl.SetParameterValue(1,totalamt);
            crystalReportViewer1.ReportSource = desgwsdtl;
        }
        public void md_lis1(DataTable dt, string lblprepb, int ind)
        {
            Crystal_dm2 dm = new Crystal_dm2();
            dm.SetDataSource(dt);
            dm.SetParameterValue(0, lblprepb);
            crystalReportViewer1.ReportSource = dm;
        }
        public void md_lis(DataTable dt, int ind)
        {
            crystal_dm dm = new crystal_dm();
            dm.SetDataSource(dt);

            crystalReportViewer1.ReportSource = dm;
        }

        public void paymentAdvice_print(string CompanyName, DataSet billng, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp)
        {
            CrystalRptPaymentAdvice grn = new CrystalRptPaymentAdvice();
            if (stp == 1)
            {
                grn.SetDataSource(billng.Tables["paymentAdvice"]);
                grn.SetDataSource(billng.Tables["Branch"]);

                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);

                //grn1.Subreports("CrystalRptVoucherhalf.rpt").SetDataSource(billng.Tables[ppq]);
                //grn2.Subreports("CrystalRptTrai.rpt").SetDataSource(ds.Tables[2]);



                //grn1.SetDataSource(billng);
                //grn2.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;

                //crystalReportViewer1.ReportSource = grn1;
                //crystalReportViewer1.ReportSource = grn2;

            }
            else
            {
                grn.SetDataSource(billng.Tables["paymentAdvice"]);
                //grn.Subreports["CrystalRptVoucherhalf.rpt"].SetDataSource(billng.Tables["ppp"]);
                //grn.Subreports["CrystalRptTrail.rpt"].SetDataSource(billng.Tables["ppq"]);


                //grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }

        public void paymentAdvice_2_print(string CompanyName, DataSet billng, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp)
        {
            CrystalRptPaymentAdvice_co grn = new CrystalRptPaymentAdvice_co();
            if (stp == 1)
            {
                grn.SetDataSource(billng.Tables["paymentAdvice"]);
                grn.SetDataSource(billng.Tables["Branch"]);

                crystalReportViewer1.ReportSource = grn;


            }
            else
            {
                grn.SetDataSource(billng.Tables["paymentAdvice"]);
                
                try
                {
                    //grn.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    grn.PrintToPrinter(1, false, 0, 0);
                    crystalReportViewer1.ReportSource = grn;
                }
                catch { }
            }
        }






        // test crpt
        public void tstPrint(DataSet tr)
        {
            testCrptEmp tp = new testCrptEmp();
            //tp.SetParameterValue(0, );
            tp.SetDataSource(tr.Tables["Test_Code"]);
            crystalReportViewer1.ReportSource = tp;
        }
        //=============================================================================

        public void grn_print1(string CompanyName, DataTable billng, string agentcompany, string agentaddr, string agentaddr1, string phone, string area, string billdt, string uservouchar, string challan, string amtword, string finalamt, string challandt, string amtvalue, string lorry_no, string locname, string modtran, string prtyname, string prtyadd1, string prtyadd2, string prtycity, string prtycitypinno, string prtytele1, string prtytele2, string prtyemailid, string prtyfax, string prtyeccno, string prtytin, string Narration, int stp)
        {
            CrystalRptVoucherhalf grn = new CrystalRptVoucherhalf();
            if (stp == 1)
            {
                grn.SetDataSource(billng);
                //grn.SetParameterValue(0, CompanyName);
                ////grn.SetParameterValue(1, duration);
                ////grn.SetParameterValue(2, addr);
                ////grn.SetParameterValue(3, panno);
                ////grn.SetParameterValue(4, addr1);
                //grn.SetParameterValue(5, agentcompany);
                //grn.SetParameterValue(6, agentaddr);
                //grn.SetParameterValue(7, agentaddr1);
                //grn.SetParameterValue(8, phone);
                //grn.SetParameterValue(9, area);
                //grn.SetParameterValue(10, billdt);
                //grn.SetParameterValue(11, uservouchar);
                //grn.SetParameterValue(12, challan);
                //grn.SetParameterValue(13, amtword);
                ////grn.SetParameterValue(14, tin1);
                //grn.SetParameterValue(15, finalamt);
                //grn.SetParameterValue(16, challandt);
                //grn.SetParameterValue(17, amtvalue);
                //grn.SetParameterValue(18, lorry_no);
                //grn.SetParameterValue(19, locname);
                //grn.SetParameterValue(20, modtran);
                //grn.SetParameterValue(21, prtyname);
                //grn.SetParameterValue(22, prtyadd1);
                //grn.SetParameterValue(23, prtyadd2);
                //grn.SetParameterValue(24, prtycity);
                //grn.SetParameterValue(25, prtycitypinno);
                //grn.SetParameterValue(26, prtytele1);
                //grn.SetParameterValue(27, prtytele2);
                //grn.SetParameterValue(28, prtyemailid);
                //grn.SetParameterValue(29, prtyfax);
                //grn.SetParameterValue(30, prtyeccno);
                //grn.SetParameterValue(31, prtytin);
                //grn.SetParameterValue(32, Narration);
                crystalReportViewer1.ReportSource = grn;
            }
            else
            {
                grn.SetDataSource(billng);
                grn.SetParameterValue(0, CompanyName);
                //grn.SetParameterValue(1, duration);
                //grn.SetParameterValue(2, addr);
                //grn.SetParameterValue(3, panno);
                //grn.SetParameterValue(4, addr1);
                grn.SetParameterValue(5, agentcompany);
                grn.SetParameterValue(6, agentaddr);
                grn.SetParameterValue(7, agentaddr1);
                grn.SetParameterValue(8, phone);
                grn.SetParameterValue(9, area);
                grn.SetParameterValue(10, billdt);
                grn.SetParameterValue(11, uservouchar);
                grn.SetParameterValue(12, challan);
                grn.SetParameterValue(13, amtword);
                //grn.SetParameterValue(14, tin1);
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


        public void Schoolbillhlf(string companyName, DataTable dtshow, string addre, string add1, string User_Voucher, string BillDate, string AmtWord, string Phone, string Title, string studentname, string Class, int stp)
        {
            CrystalRptschoolbill bill = new CrystalRptschoolbill();
            if (stp == 1)
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, add1);
                bill.SetParameterValue(3, User_Voucher);
                bill.SetParameterValue(4, BillDate);
                bill.SetParameterValue(5, AmtWord);
                bill.SetParameterValue(6, Phone);
                bill.SetParameterValue(7, Title);
                bill.SetParameterValue(8, studentname);
                bill.SetParameterValue(9, Class);

                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetDataSource(dtshow);
                bill.SetParameterValue(0, companyName);
                bill.SetParameterValue(1, addre);
                bill.SetParameterValue(2, add1);
                bill.SetParameterValue(3, User_Voucher);
                bill.SetParameterValue(4, BillDate);
                bill.SetParameterValue(5, AmtWord);
                bill.SetParameterValue(6, Phone);
                bill.SetParameterValue(7, Title);
                bill.SetParameterValue(8, studentname);
                bill.SetParameterValue(9, Class);
                bill.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                bill.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = bill;
               
               

            }
        }
        
        public void Barcoder(string Pname, string aliase, string pcode,string Mfg,string company,string Phone,string Email, int stp)
        {
            CrystalRptbarcoder bill = new CrystalRptbarcoder();
            if (stp == 1)
            {
                bill.SetParameterValue(0, Pname);
                bill.SetParameterValue(1, aliase);
                bill.SetParameterValue(2, pcode);
                bill.SetParameterValue(3, Mfg);
                bill.SetParameterValue(4, company);
                bill.SetParameterValue(5, Phone);
                bill.SetParameterValue(6, Email);    
                crystalReportViewer1.ReportSource = bill;
            }
            else
            {
                bill.SetParameterValue(0, Pname);
                bill.SetParameterValue(1, aliase);
                bill.SetParameterValue(2, pcode);
                bill.SetParameterValue(3, Mfg);
                bill.SetParameterValue(4, company);
                bill.SetParameterValue(5, Phone);
                bill.SetParameterValue(6, Email);    
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

        public void Graphic_Print(DataTable dt, string Print_Style, string Odet,string Oamt,string Agent)
        {
            try
            {
                columnHeaderTop = 0;
                CAR_L.SetDataSource(dt);
                CAR_L.SetParameterValue(0, Odet);
                CAR_L.SetParameterValue(1, Agent);
                CAR_L.SetParameterValue(2, Oamt);

                CAR_L.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                CAR_L.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = CAR_L;
            }
            catch { }
        }

        public void Graphic_Print_L(DataTable dt, string Print_Style, string Odet, string Oamt, string Agent)
        {
            try
            {
                columnHeaderTop = 0;
                CAR_L1.SetDataSource(dt);
                CAR_L1.SetParameterValue(0, Odet);
                CAR_L1.SetParameterValue(1, Agent);
                CAR_L1.SetParameterValue(2, Oamt);

                CAR_L1.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                CAR_L1.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = CAR_L1;
            }
            catch { }
        }

        public void Graphic_Print_PE(DataTable dt, string Print_Style, string Odet, string Oamt, string Agent)
        {
            try
            {
                columnHeaderTop = 0;
                CAR_PE.SetDataSource(dt);
                //CAR_PE.SetParameterValue(0, Odet);
                //CAR_PE.SetParameterValue(1, Agent);
                //CAR_PE.SetParameterValue(2, Oamt);
                CAR_PE.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                CAR_PE.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = CAR_PE;
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
                    CAR.PrintToPrinter(1, false, 0, 0);
                    //crystalReportViewer1.PrintReport();
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

        public void Graphic_Preview(DataTable dt, string Print_Style, string Odet,string Oamt,string Agent)
        {
            
                //CrystalAllReport_legal CAR_L = new CrystalAllReport_legal();
            
            try
            {
                columnHeaderTop = 0;
                CAR_L.SetDataSource(dt);
                CAR_L.SetParameterValue(0, Odet);
                CAR_L.SetParameterValue(1, Agent);
                CAR_L.SetParameterValue(2, Oamt);
                CAR_L.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
               
                //bal.PrintToPrinter(1, false, 0, 0);              
                crystalReportViewer1.ReportSource = CAR_L;
            }
            catch { }
        }

        public void Graphic_Preview_L(DataTable dt, string Print_Style, string Odet, string Oamt, string Agent)
        {
            
                //CrystalAllReport_L CAR_L1 = new CrystalAllReport_L();
            
            try
            {
                columnHeaderTop = 0;
                CAR_L1.SetDataSource(dt);
                CAR_L1.SetParameterValue(0, Odet);
                CAR_L1.SetParameterValue(1, Agent);
                CAR_L1.SetParameterValue(2, Oamt);
                CAR_L1.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;

                //bal.PrintToPrinter(1, false, 0, 0);              
                crystalReportViewer1.ReportSource = CAR_L1;
            }
            catch { }
        }
        
        public void Graphic_Preview_PE(DataTable dt, string Print_Style, string Odet, string Oamt, string Agent)
        {
            try
            {
                columnHeaderTop = 0;
                CAR_PE.SetDataSource(dt);
                //CAR_PE.SetParameterValue(1, Agent);
                //CAR_PE.SetParameterValue(2, Oamt);
                CAR_PE.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                //bal.PrintToPrinter(1, false, 0, 0);              
                crystalReportViewer1.ReportSource = CAR_PE;
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
                //string ColName = "";
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

        public void ReportHeaderArrenge_L(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
        {
            
//CrystalAllReport_L CAR_L1 = new CrystalAllReport_L();
            
            try
            {
                string HeaderName = "";
                int TotalHeight = 0;
                int row_top = 0;
                //string ColName = "";
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

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName]);
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
                            CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);

                            //Change 05.11.14 (When Report Export The Hender Not Visible)
                            int len = Convert.ToInt32(WV[i]);
                            if (len <= 330)
                                CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (len * 48);
                            else
                                CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = 330 * 48;

                            //CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            //End 05.11.14

                            CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            //row_top = (Convert.ToInt32(TV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                        }
                        else
                        {
                            row_top = row_top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i - 1]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = row_top;

                            //Change 05.11.14 (When Report Export The Hender Not Visible)
                            int len = Convert.ToInt32(WV[i]);
                            if (len <= 330)
                                CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (len * 48);
                            else
                                CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = 330 * 48;

                            //CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            //End 05.11.14
                            CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = 0;
                        CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = 0;
                        CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = 0;
                        CAR_L1.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = 0;

                    }
                }
                //CAR_L1.ReportDefinition.Sections["Section1"].Height = TotalHeight + 20;
                Section section = CAR_L1.ReportDefinition.Sections["Section1"];
                section.Height = TotalHeight;
            }
            catch { }
        }

        public void ReportHeaderArrenge_PE(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
        {

            //CrystalAllReport_L CAR_PE = new CrystalAllReport_L();

            try
            {
                string HeaderName = "";
                int TotalHeight = 0;
                int row_top = 0;
                //string ColName = "";
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

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName]);
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
                            CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);

                            //Change 05.11.14 (When Report Export The Hender Not Visible)
                            int len = Convert.ToInt32(WV[i]);
                            if (len <= 330)
                                CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (len * 48);
                            else
                                CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = 330 * 48;

                            //CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            //End 05.11.14

                            CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            //row_top = (Convert.ToInt32(TV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                        }
                        else
                        {
                            row_top = row_top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i - 1]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = row_top;

                            //Change 05.11.14 (When Report Export The Hender Not Visible)
                            int len = Convert.ToInt32(WV[i]);
                            if (len <= 330)
                                CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (len * 48);
                            else
                                CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = 330 * 48;

                            //CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            //End 05.11.14
                            CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Top = 0;
                        CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Width = 0;
                        CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Height = 0;
                        CAR_PE.ReportDefinition.Sections["Section1"].ReportObjects[HeaderName].Left = 0;

                    }
                }
                //CAR_PE.ReportDefinition.Sections["Section1"].Height = TotalHeight + 20;
                Section section = CAR_PE.ReportDefinition.Sections["Section1"];
                section.Height = TotalHeight;
            }
            catch { }
        }


        public void ReportHeaderArrenge(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
        {
         
                ////CrystalAllReport_legal CAR_L = new CrystalAllReport_legal();
           
            try
            {
                string HeaderName = "";
                int TotalHeight = 0;
                int row_top = 0;
                //string ColName = "";
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

        public void ReportPageHeaderArrenge_PE(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
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

                //CrystalAllReport_L CAR_PE = new CrystalAllReport_L();


                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 10 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName]);
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
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
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

                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Top = TotalHeight;
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);

                            //Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            //columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);

                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }

                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Top = 0;
                        CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = 0;
                        CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Height = 0;
                        CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                string ColName = "";
                for (int i = 1; i <= 20; i++)
                {
                    ColName = "Text" + Convert.ToString(i);
                    CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[ColName].Top = TotalHeight + 70;

                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                    txtApprovalStatus1.Text = "";
                }

                CrystalDecisions.CrystalReports.Engine.TextObject txtLine1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects["Line11"]);
                txtLine1.Top = TotalHeight + 20;

                CrystalDecisions.CrystalReports.Engine.TextObject txtLine2 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects["Line22"]);
                if (TotalHeight == 0)
                    TotalHeight = 50;
                //txtLine2.Top = TotalHeight + 220 + CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Height;

                txtLine2.Top = TotalHeight + 60 + 70 + 250 + 200;
                Section section = CAR.ReportDefinition.Sections["Section2"];
                section.Height = TotalHeight + 300 + 140 + 300;


                //Section section = CAR_PE.ReportDefinition.Sections["Section2"];
                ////section.Height = columnHeaderTop + 200 + 60 + 260;
                //section.Height = TotalHeight + 220 + 60 + CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Height;
            }
            catch { }
        }

        public void ReportPageHeaderArrenge_L(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
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

                    //CrystalAllReport_L CAR_L1 = new CrystalAllReport_L();
                

                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 10 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName]);
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
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
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

                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Top = TotalHeight;
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);

                            //Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            //columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);

                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }

                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Top = 0;
                        CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Width = 0;
                        CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Height = 0;
                        CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                string ColName = "";
                for (int i = 1; i <= 20; i++)
                {
                    ColName = "Text" + Convert.ToString(i);
                    CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[ColName].Top = TotalHeight + 70;

                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                    txtApprovalStatus1.Text = "";
                }

                CrystalDecisions.CrystalReports.Engine.TextObject txtLine1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects["Line11"]);
                txtLine1.Top = TotalHeight + 20;

                CrystalDecisions.CrystalReports.Engine.TextObject txtLine2 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects["Line22"]);
                if (TotalHeight == 0)
                    TotalHeight = 50;
                //txtLine2.Top = TotalHeight + 220 + CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Height;

                txtLine2.Top = TotalHeight + 60 + 70 + 250 + 200;
                Section section = CAR.ReportDefinition.Sections["Section2"];
                section.Height = TotalHeight + 300 + 140 + 300;


                //Section section = CAR_L1.ReportDefinition.Sections["Section2"];
                ////section.Height = columnHeaderTop + 200 + 60 + 260;
                //section.Height = TotalHeight + 220 + 60 + CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects["Text1"].Height;
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

                
                    //CrystalAllReport_legal CAR_L = new CrystalAllReport_legal();
                
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

        public void ReportPageFooterArrenge_PE(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
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

                // CrystalAllReport_L CAR_PE = new CrystalAllReport_L();


                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 20 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName]);
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
                            CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = Top + (Convert.ToInt32(TV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = 0;
                        CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = 0;
                        CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = 0;
                        CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                //CrystalDecisions.CrystalReports.Engine.LineObject Line_5 = ((CrystalDecisions.CrystalReports.Engine.LineObject)CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects["Line5"]);
                //Line_5.LineThickness = 20;               

                if (PageNumberDisplay == true)
                {
                    CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Top = TotalHeight + 50;
                    CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Width = 1600;
                    CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Height = 220;
                    CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Left = 13800;
                }
                else
                {
                    CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Top = 0;
                    CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Width = 0;
                    CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Height = 0;
                    CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Left = 0;
                    TotalHeight = TotalHeight - 50;
                }
                Section section = CAR_PE.ReportDefinition.Sections["Section5"];
                section.Height = TotalHeight + 50 + 220 + 48;
            }
            catch { }
        }
        public void ReportPageFooterArrenge_L(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
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
                
                   // CrystalAllReport_L CAR_L1 = new CrystalAllReport_L();
                

                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 20 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName]);
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
                            CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = Top + (Convert.ToInt32(TV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Top = 0;
                        CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Width = 0;
                        CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Height = 0;
                        CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                //CrystalDecisions.CrystalReports.Engine.LineObject Line_5 = ((CrystalDecisions.CrystalReports.Engine.LineObject)CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects["Line5"]);
                //Line_5.LineThickness = 20;               

                if (PageNumberDisplay == true)
                {
                    CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Top = TotalHeight + 50;
                    CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Width = 1600;
                    CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Height = 220;
                    CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Left = 13800;
                }
                else
                {
                    CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Top = 0;
                    CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Width = 0;
                    CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Height = 0;
                    CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects["PageNofM1"].Left = 0;
                    TotalHeight = TotalHeight - 50;
                }
                Section section = CAR_L1.ReportDefinition.Sections["Section5"];
                section.Height = TotalHeight + 50 + 220 + 48;
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
              
                    ////CrystalAllReport_legal CAR_L = new CrystalAllReport_legal();
              
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

        public void ReportFooterArrenge_PE(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
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

                //CrystalAllReport_L CAR_PE = new CrystalAllReport_L();

                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 30 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName]);
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

                            CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = Top + (Convert.ToInt32(TV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = 0;
                        CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = 0;
                        CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = 0;
                        CAR_PE.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                CrystalDecisions.CrystalReports.Engine.LineObject Line_5 = ((CrystalDecisions.CrystalReports.Engine.LineObject)CAR_PE.ReportDefinition.Sections["Section5"].ReportObjects["Line5"]);
                Line_5.LineThickness = 20;
                Line_5.LineColor = System.Drawing.Color.Black;

                Section section = CAR_PE.ReportDefinition.Sections["Section4"];
                section.Height = TotalHeight + 48;
            }
            catch { }
        }
        public void ReportFooterArrenge_L(string[] Header_String, string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
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

//CrystalAllReport_L CAR_L1 = new CrystalAllReport_L();

                for (int i = 0; i < 10; i++)
                {
                    HeaderName = "PF" + Convert.ToString(i + 30 + 1) + "1";
                    if (i < Header_String.Length)
                    {
                        FN = Convert.ToString(FontName[i]);
                        FSI = Convert.ToSingle(FontSize[i]);

                        CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName]);
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
                            
                            CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = (Convert.ToInt32(TV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48); // Default Height 226
                            TotalHeight = TotalHeight + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        else
                        {
                            CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = Top + (Convert.ToInt32(TV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = (Convert.ToInt32(WV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = (Convert.ToInt32(HV[i]) * 48);
                            TotalHeight = TotalHeight + (Convert.ToInt32(HV[i]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = (Convert.ToInt32(LV[i]) * 48);
                            Top = Top + (Convert.ToInt32(HV[i]) * 48);
                            columnHeaderTop = columnHeaderTop + (Convert.ToInt32(TV[i]) * 48) + (Convert.ToInt32(HV[i]) * 48);
                        }
                        if (Convert.ToString(AV[i]).ToUpper() == "L")
                            CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "M")
                            CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        if (Convert.ToString(AV[i]).ToUpper() == "R")
                            CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                    }
                    else
                    {
                        CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Top = 0;
                        CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Width = 0;
                        CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Height = 0;
                        CAR_L1.ReportDefinition.Sections["Section4"].ReportObjects[HeaderName].Left = 0;
                    }
                }

                CrystalDecisions.CrystalReports.Engine.LineObject Line_5 = ((CrystalDecisions.CrystalReports.Engine.LineObject)CAR_L1.ReportDefinition.Sections["Section5"].ReportObjects["Line5"]);
                Line_5.LineThickness = 20;
                Line_5.LineColor = System.Drawing.Color.Black;

                Section section = CAR_L1.ReportDefinition.Sections["Section4"];
                section.Height = TotalHeight + 48;
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

               
                    //CrystalAllReport_legal CAR_L = new CrystalAllReport_legal();
               
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

        public void DetailsColumnsHeaderArrenge_PE(string[] COL_NAME, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
        {
            try
            {
                string ColName = "";
                string FN = "";
                float FSI = 0;

                for (int i = 1; i <= COL_NAME.Length; i++)
                {
                    ColName = "Text" + Convert.ToString(i);
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
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
        public void DetailsColumnsHeaderArrenge_L(string[] COL_NAME, string[] FontName, string[] FontSize, string[] FontSty, string Print_Style)
        {
            try
            {
                string ColName = "";
                string FN = "";
                float FSI = 0;

                for (int i = 1; i <= COL_NAME.Length; i++)
                {
                    ColName = "Text" + Convert.ToString(i);
                    CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
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

              
                    //CrystalAllReport_legal CAR_L = new CrystalAllReport_legal();
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
        public void DetailsColumnsArrenge_L(string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string Print_Style)
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

                
                   // CrystalAllReport_L CAR_L1 = new CrystalAllReport_L();
                

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
                        CAR_L1.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Top = (Convert.ToInt32(TV[0]) * 48);// +(Convert.ToInt32(TV[i - 1]) * 48);
                        CAR_L1.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Width = (Convert.ToInt32(WV[i - 1]) * 48);
                        CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Width = (Convert.ToInt32(WV[i - 1]) * 48);
                        CAR_L1.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Height = (Convert.ToInt32(HV[i - 1]) * 48);

                        if (Convert.ToInt32(LV[i - 1]) == 0)
                        {
                            CAR_L1.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = LeftVal;// (Convert.ToInt32(LV[i - 1]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Left = LeftVal; //(Convert.ToInt32(LV[i - 1]) * 48);
                        }
                        else
                        {
                            CAR_L1.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = (Convert.ToInt32(LV[i - 1]) * 48);
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Left = (Convert.ToInt32(LV[i - 1]) * 48);
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "L")
                        {
                            CAR_L1.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "M")
                        {
                            CAR_L1.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "R")
                        {
                            CAR_L1.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                            CAR_L1.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                    }
                    else
                    {
                        CAR_L1.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Top = 0;
                        CAR_L1.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Width = 0;
                        CAR_L1.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Height = 0;
                        CAR_L1.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = 0;
                    }
                }
                //CAR_L1.ReportDefinition.Sections["Section3"].Height = Convert.ToInt32(HV[0]) + 48;
                //CrystalDecisions.CrystalReports

                //CrystalDecisions.CrystalReports

                Section section = CAR_L1.ReportDefinition.Sections["Section3"];
                section.Height = (Convert.ToInt32(HV[0]) * 48) + (Convert.ToInt32(TV[0]) * 48);

                //ReportDocument gg = new ReportDocument();
                //Section

            }
            catch { }
        }

        public void DetailsColumnsArrenge_PE(string TopValue, string WidthValue, string HeightValue, string LeftValue, string AlignmentValue, string Print_Style)
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


                // CrystalAllReport_L CAR_PE = new CrystalAllReport_L();


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
                        CAR_PE.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Top = (Convert.ToInt32(TV[0]) * 48);// +(Convert.ToInt32(TV[i - 1]) * 48);
                        CAR_PE.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Width = (Convert.ToInt32(WV[i - 1]) * 48);
                        CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Width = (Convert.ToInt32(WV[i - 1]) * 48);
                        CAR_PE.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Height = (Convert.ToInt32(HV[i - 1]) * 48);

                        if (Convert.ToInt32(LV[i - 1]) == 0)
                        {
                            CAR_PE.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = LeftVal;// (Convert.ToInt32(LV[i - 1]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Left = LeftVal; //(Convert.ToInt32(LV[i - 1]) * 48);
                        }
                        else
                        {
                            CAR_PE.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = (Convert.ToInt32(LV[i - 1]) * 48);
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].Left = (Convert.ToInt32(LV[i - 1]) * 48);
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "L")
                        {
                            CAR_PE.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "M")
                        {
                            CAR_PE.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                        if (Convert.ToString(AV[i - 1]).ToUpper() == "R")
                        {
                            CAR_PE.ReportDefinition.Sections["Section3"].ReportObjects[ColName].ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
                            CAR_PE.ReportDefinition.Sections["Section2"].ReportObjects[ColHeaderName].ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                        }
                    }
                    else
                    {
                        CAR_PE.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Top = 0;
                        CAR_PE.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Width = 0;
                        CAR_PE.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Height = 0;
                        CAR_PE.ReportDefinition.Sections["Section3"].ReportObjects[ColName].Left = 0;
                    }
                }
                //CAR_PE.ReportDefinition.Sections["Section3"].Height = Convert.ToInt32(HV[0]) + 48;
                //CrystalDecisions.CrystalReports

                //CrystalDecisions.CrystalReports

                Section section = CAR_PE.ReportDefinition.Sections["Section3"];
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



        //biplab Bibhas
        public void empjoining(string title, string firstname, string middlename, string lastname, string fathtitle, string fathfn, string fathmn, string fathln, string mothtitle, string mothfn, string mothmn, string mothln, string hustitle, string husfn, string husmn, string husln, DateTime dateofbirth, string maritalstatus, string gender, string religion, string cast, string weight, string height, string designation, string company, string location, string jobtype, string present_add, string Pre_building, string Pre_street, string pre_area, string pre_town, string pre_pincode, string pre_country, string Pre_state, string Per_Add, string Per_Building, string per_street, string Per_Area, string Per_City, string Per_state, string Per_country, string Per_Pincode, string Language_bengali, string Language_English, string Language_Hindi, string PanNO, string PF, string ESI, string BankAccountNo, string Bank_name, string Branch_Name, string AccountType, string IFSC_Code, string PensionNo, DateTime DateOfJoining, DateTime DateOfRetirement, string Emerg_Name, string Emerg_Add, string Emerg_Tele, string Emerg_Mobile, string Family_name, string family_Realtion, int Family_Age, string Family_dependent, string Ref_name, string Ref_Add, string Ref_Occupation, string Ref_Phone, string Ref_Email, string Emp_service, string Emp_PeriodOfService, string Emp_Rank, string Emp_IcardNo, string Emp_Arms, string Emp_PensionNo, string Emp_GunLicenseNo, string Emp_Operation, string Emp_Issue, string Emp_GunType, string Emp_GunValid, string emp_DrivingLicence, string empid, string passportno, DataSet ds,string aadhar)
        {
            try
            {
                EMPJOININGRPT EMPDET = new EMPJOININGRPT();
                Qualificationde qu = new Qualificationde();
                Family FA = new Family();
                EMPDET.SetDataSource(ds);
                try
                {
                    EMPDET.Subreports["Qualificationde.rpt"].SetDataSource(ds.Tables["quali1"]);
                }
                catch { }
                try
                {
                    EMPDET.Subreports["Family.rpt"].SetDataSource(ds.Tables["Family"]);
                }
                catch { }
                EMPDET.SetParameterValue(0, title);
                EMPDET.SetParameterValue(1, firstname);
                EMPDET.SetParameterValue(2, middlename);
                EMPDET.SetParameterValue(3, lastname);
                EMPDET.SetParameterValue(4, fathtitle);
                EMPDET.SetParameterValue(5, fathfn);
                EMPDET.SetParameterValue(6, fathmn);
                EMPDET.SetParameterValue(7, fathln);
                EMPDET.SetParameterValue(8, mothtitle);
                EMPDET.SetParameterValue(9, mothfn);
                EMPDET.SetParameterValue(10, mothmn);
                EMPDET.SetParameterValue(11, mothln);
                EMPDET.SetParameterValue(12, hustitle);
                EMPDET.SetParameterValue(13, husfn);
                EMPDET.SetParameterValue(14, husmn);
                EMPDET.SetParameterValue(15, husln);
                EMPDET.SetParameterValue(16, dateofbirth);
                EMPDET.SetParameterValue(17, maritalstatus);
                EMPDET.SetParameterValue(18, gender);
                EMPDET.SetParameterValue(19, religion);
                EMPDET.SetParameterValue(20, cast);
                EMPDET.SetParameterValue(21, weight);
                EMPDET.SetParameterValue(22, height);
                EMPDET.SetParameterValue(23, designation);
                EMPDET.SetParameterValue(24, company);
                EMPDET.SetParameterValue(25, location);
                EMPDET.SetParameterValue(26, jobtype);
                EMPDET.SetParameterValue(27, present_add);
                EMPDET.SetParameterValue(28, Pre_building);
                EMPDET.SetParameterValue(29, Pre_street);
                EMPDET.SetParameterValue(30, pre_area);
                EMPDET.SetParameterValue(31, pre_town);
                EMPDET.SetParameterValue(32, pre_pincode);
                EMPDET.SetParameterValue(33, pre_country);
                EMPDET.SetParameterValue(34, Pre_state);
                EMPDET.SetParameterValue(35, Per_Add);
                EMPDET.SetParameterValue(36, Per_Building);
                EMPDET.SetParameterValue(37, per_street);
                EMPDET.SetParameterValue(38, Per_Area);
                EMPDET.SetParameterValue(39, Per_City);
                EMPDET.SetParameterValue(40, Per_state);
                EMPDET.SetParameterValue(41, Per_country);
                EMPDET.SetParameterValue(42, Per_Pincode);
                EMPDET.SetParameterValue(43, Language_bengali);
                EMPDET.SetParameterValue(44, Language_English);
                EMPDET.SetParameterValue(45, Language_Hindi);
                EMPDET.SetParameterValue(46, PanNO);
                EMPDET.SetParameterValue(47, PF);
                EMPDET.SetParameterValue(48, ESI);
                EMPDET.SetParameterValue(49, BankAccountNo);
                EMPDET.SetParameterValue(50, Bank_name);
                EMPDET.SetParameterValue(51, Branch_Name);
                EMPDET.SetParameterValue(52, AccountType);
                EMPDET.SetParameterValue(53, IFSC_Code);
                EMPDET.SetParameterValue(54, PensionNo);
                EMPDET.SetParameterValue(55, DateOfJoining);
                EMPDET.SetParameterValue(56, DateOfRetirement);
                EMPDET.SetParameterValue(57, Emerg_Name);
                EMPDET.SetParameterValue(58, Emerg_Add);
                EMPDET.SetParameterValue(59, Emerg_Tele);
                EMPDET.SetParameterValue(60, Emerg_Mobile);

                EMPDET.SetParameterValue(61, Family_name);
                EMPDET.SetParameterValue(62, family_Realtion);
                EMPDET.SetParameterValue(63, Family_Age);
                EMPDET.SetParameterValue(64, Family_dependent);
                EMPDET.SetParameterValue(82, Ref_name);
                EMPDET.SetParameterValue(65, Ref_Add);
                EMPDET.SetParameterValue(66, Ref_Occupation);
                EMPDET.SetParameterValue(67, Ref_Phone);
                EMPDET.SetParameterValue(68, Ref_Email);
                EMPDET.SetParameterValue(69, Emp_service);
                EMPDET.SetParameterValue(70, Emp_PeriodOfService);
                EMPDET.SetParameterValue(71, Emp_Rank);
                EMPDET.SetParameterValue(72, Emp_IcardNo);
                EMPDET.SetParameterValue(73, Emp_Arms);
                EMPDET.SetParameterValue(74, Emp_PensionNo);
                EMPDET.SetParameterValue(75, Emp_GunLicenseNo);
                EMPDET.SetParameterValue(76, Emp_Operation);
                EMPDET.SetParameterValue(77, Emp_Issue);
                EMPDET.SetParameterValue(78, Emp_GunType);
                EMPDET.SetParameterValue(79, Emp_GunValid);
                EMPDET.SetParameterValue(80, emp_DrivingLicence);
                EMPDET.SetParameterValue(81, empid);
                EMPDET.SetParameterValue(83, passportno);
                EMPDET.SetParameterValue(85, aadhar);

                crystalReportViewer1.ReportSource = EMPDET;
            }
            catch { };
        }
        //bibhas
        ////public void Salcomp(string company, string session, DataTable dt_ass)
        ////{
        ////    SalaryComposite slcom = new SalaryComposite();
        ////    slcom.SetDataSource(dt_ass);
        ////    slcom.SetParameterValue(1, company);
        ////    //strucrpt.SetParameterValue(1, location);
        ////    slcom.SetParameterValue(0, session);
        ////    crystalReportViewer1.ReportSource = slcom;
        ////}

        public void Salcomp(string com, string address, string session, DataTable dt_ass)
        {
            SalaryComposite slcom = new SalaryComposite();
            slcom.SetDataSource(dt_ass);
            slcom.SetParameterValue(1, com);
            //strucrpt.SetParameterValue(1, location);
            slcom.SetParameterValue(0, session);
            slcom.SetParameterValue(2, address);
            crystalReportViewer1.ReportSource = slcom;
        }
        public void Ptaxcomp(string company, string session,string add, DataTable dt_ass)
        {
            PTaxComposite ptcom = new PTaxComposite();
            ptcom.SetDataSource(dt_ass);
            ptcom.SetParameterValue(0, session);
            ptcom.SetParameterValue(1, company);
            ptcom.SetParameterValue(2, add);
           
            crystalReportViewer1.ReportSource = ptcom;
        }

        //biplab
        public void SalStructure(string company, string location, string session, DataTable dt_ass)
        {
            SalStructure strucrpt = new SalStructure();
            strucrpt.SetDataSource(dt_ass);
            strucrpt.SetParameterValue(0, company);
            strucrpt.SetParameterValue(1, location);
            strucrpt.SetParameterValue(2, session);
            crystalReportViewer1.ReportSource = strucrpt;
        }

        public void atten_emp_rpt(string company, string location, string month, string session, int year, DataTable attdt, int flag)
        {
            AttenRpt_Emp rpt = new AttenRpt_Emp();
            rpt.SetDataSource(attdt);
            rpt.SetParameterValue(0, company);
            
            rpt.SetParameterValue(1, session);
            rpt.SetParameterValue(2, location);
            crystalReportViewer1.ReportSource = rpt;


            if (flag == 1)
            {

                rpt.PrintToPrinter(1, false, 0, 0);

            }
        }

        public void atten_rpt(string company, string location, string month, string session, int year, DataTable attdt, int flag)
        {
            AttenRpt rpt = new AttenRpt();
            rpt.SetDataSource(attdt);
            rpt.SetParameterValue(0, company);
            rpt.SetParameterValue(1, location);
            rpt.SetParameterValue(2, month);
            rpt.SetParameterValue(3, session);
            rpt.SetParameterValue(4, year);
            crystalReportViewer1.ReportSource = rpt;


             if (flag == 1)
            {
               
                rpt.PrintToPrinter(1, false, 0, 0);

            }
        }

        public void Holiday_Rpt(string Session, DataTable dt, int ptype)
        {
            CrptHolidayList crptHL = new CrptHolidayList();
            crptHL.SetDataSource(dt);
            crptHL.SetParameterValue(0, Session);

            if (ptype == 1)
                crystalReportViewer1.ReportSource = crptHL;
            else if (ptype == 2)
                crptHL.PrintToPrinter(1, false, 0, 0);
            

        }
        public void employee_rpt(string company, string session, DataTable dl)
        {
            EmployRpt rpt = new EmployRpt();
            rpt.SetDataSource(dl);
            rpt.SetParameterValue(0, company);
            rpt.SetParameterValue(1, session);
            crystalReportViewer1.ReportSource = rpt;
        }
        //public void EmpWiseJoin(string company, string session, DataTable dtme)
        //{
        //    EmpWiseJoining rpt = new EmpWiseJoining();
        //    rpt.SetDataSource(dtme);
        //    rpt.SetParameterValue(0, company);
        //    rpt.SetParameterValue(1, session);
        //    crystalReportViewer1.ReportSource = rpt;
        //}

        public void Bill_Report(string company, string session, DataTable billdt, string coadd)
        {
            BillRpt rpt = new BillRpt();
            rpt.SetDataSource(billdt);
            rpt.SetParameterValue(0, company);
            rpt.SetParameterValue(1, session);
            rpt.SetParameterValue(2, coadd);
            crystalReportViewer1.ReportSource = rpt;
        }
        public void Bill_ReportO(string company, string session, DataTable billdt)
        {
            BillRptO rpt = new BillRptO();
            rpt.SetDataSource(billdt);
            rpt.SetParameterValue(0, company);
            rpt.SetParameterValue(1, session);
            crystalReportViewer1.ReportSource = rpt;
        }

        public void bankpaymentrpt(string bankname, string bankaccountno, string company, string Designation, string city, string tag,string add,string contact, DataTable tot_employ, int pri_pre)
        {
            BankPaymentRpt grn = new BankPaymentRpt(); //crystal report file
           

            grn.SetDataSource(tot_employ);
            grn.SetParameterValue(0, bankname);
            grn.SetParameterValue(1, bankaccountno);
            grn.SetParameterValue(2, company);
            grn.SetParameterValue(3, Designation);
            grn.SetParameterValue(4, city);
            grn.SetParameterValue(5, tag);
            grn.SetParameterValue(6, add);
            grn.SetParameterValue(7, contact);

            if (pri_pre==1)
            crystalReportViewer1.ReportSource = grn;
            else if (pri_pre==2)
                grn.PrintToPrinter(1, false, 0, 0);

        }
        public void bankpaymentrpt_bob(string bankname, string bankaccountno, string company, string Designation, string city, 
        string tag, string add, string contact, DataTable tot_employ, int pri_pre, string BnkCode,string usr,string c_ift,string c_neft,string a_ift,string a_neft)
        {
            BankPaymentRpt_BOB grn = new BankPaymentRpt_BOB(); //crystal report file


            grn.SetDataSource(tot_employ);
            grn.SetParameterValue(0, bankname);
            grn.SetParameterValue(1, bankaccountno);
            grn.SetParameterValue(2, company);
            grn.SetParameterValue(3, Designation);
            grn.SetParameterValue(4, city);
            grn.SetParameterValue(5, tag);
            grn.SetParameterValue(6, add);
            grn.SetParameterValue(7, contact);
            grn.SetParameterValue(8, BnkCode);
            grn.SetParameterValue(9, usr);
            grn.SetParameterValue(10, c_ift);
            grn.SetParameterValue(11, c_neft);
            grn.SetParameterValue(12, a_ift);
            grn.SetParameterValue(13, a_neft);

            if (pri_pre == 1)
                crystalReportViewer1.ReportSource = grn;
            else if (pri_pre == 2)
                grn.PrintToPrinter(1, false, 0, 0);

        }

        public void bank_letter(string bankname, string bankaccountno, string company, string Designation, string city, string tag, string add, string contact, DataTable tot_employ, int pri_pre)
        {
            rptBankW grn = new rptBankW(); //crystal report file

            grn.SetDataSource(tot_employ);
            if (pri_pre == 1)
                crystalReportViewer1.ReportSource = grn;
            else if (pri_pre == 2)
                grn.PrintToPrinter(1, false, 0, 0);

        }

      
        public void KycExcept(string Company, String Location, string Session, string rpn, DataTable dts)
        {
            KycExceptionRpt rpt = new KycExceptionRpt();
            rpt.SetDataSource(dts);
            rpt.SetParameterValue(0, Company);
            rpt.SetParameterValue(1, Location);
            rpt.SetParameterValue(2, Session);
            rpt.SetParameterValue(3, rpn);
            crystalReportViewer1.ReportSource = rpt;
        }

        public void AdvRpt(string company, string location, string session, DataTable dts,int ptype)
        {
            AdvRpt rpt = new AdvRpt();
            rpt.SetDataSource(dts);
            rpt.SetParameterValue(0, company);
            rpt.SetParameterValue(1, location);
            rpt.SetParameterValue(2, session);
            if (ptype==1)
            crystalReportViewer1.ReportSource = rpt;
            else if (ptype==2)
                rpt.PrintToPrinter(1, false, 0, 0);
        }


        //ANURAG
        public void EmpWiseJoin(string company, string session,string sub,string End_d, DataTable dtme)
        {
            EmpWiseJoin rpt = new EmpWiseJoin();
            rpt.SetDataSource(dtme);
            rpt.SetParameterValue(0, company);
            rpt.SetParameterValue(1, session);
            rpt.SetParameterValue(2,sub);
            rpt.SetParameterValue(3, End_d);
            crystalReportViewer1.ReportSource = rpt;
        }
        public void PfEsiEligibility(string company, string co_add, string Header, DataTable dt,string col1, string col2, string col3, string col4, string col5)
        {
            PF_ESI_Eligibility rpt = new PF_ESI_Eligibility();
            rpt.SetDataSource(dt);
            rpt.SetParameterValue(0, company);
            rpt.SetParameterValue(1, co_add);
            rpt.SetParameterValue(2, Header);

            rpt.SetParameterValue(3, col1);
            rpt.SetParameterValue(4, col2);
            rpt.SetParameterValue(5, col3);
            rpt.SetParameterValue(6, col4);
            rpt.SetParameterValue(7, col5);
            crystalReportViewer1.ReportSource = rpt;
        }
        // joji -- 10/12/2018
        public void PfEsiEligibility_print(string company, string co_add, string Header, DataTable dt, string col1, string col2, string col3, string col4, string col5)
        {
            PF_ESI_Eligibility rpt = new PF_ESI_Eligibility();
            rpt.SetDataSource(dt);
            rpt.SetParameterValue(0, company);
            rpt.SetParameterValue(1, co_add);
            rpt.SetParameterValue(2, Header);

            rpt.SetParameterValue(3, col1);
            rpt.SetParameterValue(4, col2);
            rpt.SetParameterValue(5, col3);
            rpt.SetParameterValue(6, col4);
            rpt.SetParameterValue(7, col5);
            crystalReportViewer1.ReportSource = rpt;
            rpt.PrintToPrinter(1, false, 0, 0);
        }
       

        public void Bill_Register(string company, string address, string session, string Start_d, string End_d, DataTable dt, string type)
        {
            Bill_Register rpt = new Bill_Register();
            rpt.SetDataSource(dt);
            rpt.SetParameterValue(0, company);
            rpt.SetParameterValue(1, address);
            rpt.SetParameterValue(2, session);
            rpt.SetParameterValue(3, Start_d);
            rpt.SetParameterValue(4, End_d);
            rpt.SetParameterValue(5, type);
            crystalReportViewer1.ReportSource = rpt;
        }

        public void Bill_outstanding(string company, string address, string session, DataTable dt)
        {
            crpt_bill_register rpt = new crpt_bill_register();
            rpt.SetDataSource(dt);
            rpt.SetParameterValue(0, company);
            rpt.SetParameterValue(1, address);
           
            crystalReportViewer1.ReportSource = rpt;
        }
        public void Order_Register(string company, string address, string sub, string End_d, DataTable dt, int flag)
        {
            Order_Register rpt = new Order_Register();
            rpt.SetDataSource(dt);
            rpt.SetParameterValue(0, company);
            rpt.SetParameterValue(1, address);
             rpt.SetParameterValue(2,sub);
             rpt.SetParameterValue(3, End_d);
            crystalReportViewer1.ReportSource = rpt;
             if (flag == 2)
            {
               
                rpt.PrintToPrinter(1, false, 0, 0);
            }
        }
        public void AdvRpt(string company, string month, DataTable dts, int ptype)
        {
            AdvRpt rpt = new AdvRpt();
            rpt.SetDataSource(dts);
            rpt.SetParameterValue(0, company);
            //rpt.SetParameterValue(1, location);
            rpt.SetParameterValue(2, month);
            if (ptype == 1)
                crystalReportViewer1.ReportSource = rpt;
            else if (ptype == 2)
                rpt.PrintToPrinter(1, false, 0, 0);
        }

        //Bibhas - 26-10-2019 / 29-10-2019    Tamil Register
        public void register_tamil(DataTable dt, int tp, string oth)
        {
            if (tp == 20)
            {
                crpt_register_tamil_empcard ec = new crpt_register_tamil_empcard();
                ec.SetDataSource(dt);
                crystalReportViewer1.ReportSource = ec;
                //ec.Dispose();
            }
            else if (tp == 21)
            {
                crpt_register_tamil_workmen_frmXIII wm = new crpt_register_tamil_workmen_frmXIII();
                wm.SetDataSource(dt);
                crystalReportViewer1.ReportSource = wm;
            }


        }
        // 29-10-2019
        public void Register_tamil_fine(string com, string add, string sub, string client, string clientadd, string month, string session, DataTable dt, int flag)
        {
            crpt_register_tamil_fine wf = new crpt_register_tamil_fine();
            wf.SetDataSource(dt);
            wf.SetParameterValue(0, com);
            wf.SetParameterValue(1, add);
            wf.SetParameterValue(2, sub);
            wf.SetParameterValue(3, client);
            wf.SetParameterValue(4, clientadd);
            wf.SetParameterValue(5, month);
            wf.SetParameterValue(6, session);
            crystalReportViewer1.ReportSource = wf;
            if (flag == 1)
            {
                wf.PrintToPrinter(1, false, 0, 0);
            }

        }

        public void Register_tamil_frmD(DataTable dt)
        {
            crpt_register_tamil_FrmD fd = new crpt_register_tamil_FrmD();
            fd.SetDataSource(dt);
            crystalReportViewer1.ReportSource = fd;

        }


        //08-11-2019

        public void Register_tamil_frm11(DataTable dt)
        {
            crpt_register_tamil_Frm11_null fd = new crpt_register_tamil_Frm11_null();
            fd.SetDataSource(dt);
            crystalReportViewer1.ReportSource = fd;

        }
        public void Register_tamil_frmVI()
        {
            crpt_register_tamil_FrmVI_null fd = new crpt_register_tamil_FrmVI_null();
            //fd.SetDataSource(dt);
            crystalReportViewer1.ReportSource = fd;

        }

        // 09-11-2019

        public void Register_tamil_frmA(DataTable dt)
        {
            crpt_register_tamil_FrmA_null fd = new crpt_register_tamil_FrmA_null();
           // fd.SetDataSource(dt);
            crystalReportViewer1.ReportSource = fd;
        }
        public void Register_tamil_frmC(DataTable dt, string comp, string mon)
        {
            crpt_register_tamil_FrmC_null fd = new crpt_register_tamil_FrmC_null();
            //fd.SetDataSource(dt);
            fd.SetParameterValue(0, comp);
            fd.SetParameterValue(1, mon);
            crystalReportViewer1.ReportSource = fd;
        }

        // 11-11-2019
        public void Register_tamil_frmQ(DataTable dt,string comp,string mon)
        {
            crpt_register_tamil_FrmQ_null fd = new crpt_register_tamil_FrmQ_null();
            fd.SetDataSource(dt);
            fd.SetParameterValue(0, comp);
            fd.SetParameterValue(1, mon);
            crystalReportViewer1.ReportSource = fd;
        }

        //Bibhas - 23/01/2018 - 21/03/2018
        public void show_icard( DataTable dt_icard,int tp,string cadd)
        {
            if (tp == 1)
            {
                crpt_icard_small cicard = new crpt_icard_small();

                cicard.SetDataSource(dt_icard);
                cicard.SetParameterValue(0, cadd);
                crystalReportViewer1.ReportSource = cicard;
            }
            else if (tp == 2)
            {
                crpt_icard1_small cicard = new crpt_icard1_small();
                cicard.SetDataSource(dt_icard);
                cicard.SetParameterValue(0, cadd);
                crystalReportViewer1.ReportSource = cicard;
            }
            else if (tp == 4)
            {
                crpt_icard1_small_2 cicard = new crpt_icard1_small_2();

                cicard.SetDataSource(dt_icard);
                cicard.SetParameterValue(0, cadd);
                crystalReportViewer1.ReportSource = cicard;
            }
            else if (tp == 10)
            {
                crpt_register_empcard ec = new crpt_register_empcard();
                ec.SetDataSource(dt_icard);
                crystalReportViewer1.ReportSource = ec;
            }
            else if (tp == 20)
            {
                crpt_register_tamil_empcard ec = new crpt_register_tamil_empcard();
                ec.SetDataSource(dt_icard);
                crystalReportViewer1.ReportSource = ec;
            }
            else
            {
                Regis_card cicard = new Regis_card();
                cicard.SetDataSource(dt_icard);

                crystalReportViewer1.ReportSource = cicard;
            }
        }

        public void ptax(string com, string add, string sub, DataTable dt)
        {
            Ptax_Crpt pt = new Ptax_Crpt();
            pt.SetDataSource(dt);
            pt.SetParameterValue(0, com);
            pt.SetParameterValue(1, add);
            pt.SetParameterValue(2, sub);
            crystalReportViewer1.ReportSource = pt;

        }

        public void ESI(string com, string add, string sub, DataTable dt,string empl)
        {
            ESI_rpt pt = new ESI_rpt();
            pt.SetDataSource(dt);
            pt.SetParameterValue(0, com);
            pt.SetParameterValue(1, add);
            pt.SetParameterValue(2, sub);
            pt.SetParameterValue(3, empl);
            crystalReportViewer1.ReportSource = pt;

        }

        public void show_hist(DataTable dt_icard)
        {
            
                EmpHistSheet hs = new EmpHistSheet();
                hs.SetDataSource(dt_icard);

                crystalReportViewer1.ReportSource = hs;
            
        }
        public void show_hist1(DataTable dt_icard)
        {

            EmpSingleBio hs = new EmpSingleBio();
            hs.SetDataSource(dt_icard);

            crystalReportViewer1.ReportSource = hs;

        }



        public void Workflow(DataTable dt)
        {
            Workflow_crpt wf = new Workflow_crpt();
            wf.SetDataSource(dt);
            wf.SetParameterValue(0, "Session");
            crystalReportViewer1.ReportSource = wf;

        }


        ////som - tauhid
        //public void R_Advance(DataTable dt1)
        //{
        //    regis_advance wf = new regis_advance();
        //    wf.SetDataSource(dt1);
        //    //wf.SetParameterValue(0, "Session");
        //    crystalReportViewer1.ReportSource = wf;

        //}
        // joji reupdate - 13/12/2018
        public void R_Advance(DataTable dt1, int flag)
        {
            regis_advance wf = new regis_advance();
            wf.SetDataSource(dt1);
            //wf.SetParameterValue(0, "Session");
            crystalReportViewer1.ReportSource = wf;
            if (flag == 1)
            {
                wf.PrintToPrinter(1, false, 0, 0);
            }

        }


        //public void f_fine(string com, string add, string sub, string client,string clientadd,string month,string session , DataTable dt)
        //{
        //    R_fine wf = new R_fine();
        //    wf.SetDataSource(dt);
        //    wf.SetParameterValue(0, com);
        //    wf.SetParameterValue(1, add);
        //    wf.SetParameterValue(2, sub);
        //    wf.SetParameterValue(3, client);
        //    wf.SetParameterValue(4, clientadd);
        //    wf.SetParameterValue(5, month);
        //    wf.SetParameterValue(6, session);
        //    crystalReportViewer1.ReportSource = wf;

        //}
        //joji - reupdate - 13/12/2018
        public void f_fine(string com, string add, string sub, string client, string clientadd, string month, string session, DataTable dt, int flag)
        {
            R_fine wf = new R_fine();
            wf.SetDataSource(dt);
            wf.SetParameterValue(0, com);
            wf.SetParameterValue(1, add);
            wf.SetParameterValue(2, sub);
            wf.SetParameterValue(3, client);
            wf.SetParameterValue(4, clientadd);
            wf.SetParameterValue(5, month);
            wf.SetParameterValue(6, session);
            crystalReportViewer1.ReportSource = wf;
            if (flag == 1)
            {
                wf.PrintToPrinter(1, false, 0, 0);
            }

        }
       


        //public void d_deduct(string com, string add, string sub, string client, DataTable dt)
        //{
        //    R_Deduct wf = new R_Deduct();
        //    wf.SetDataSource(dt);
        //    wf.SetParameterValue(0, com);
        //    wf.SetParameterValue(1, add);
        //    wf.SetParameterValue(2, sub);
        //    wf.SetParameterValue(3, client);
        //    crystalReportViewer1.ReportSource = wf;

        //}

        //Bibhas - joji 22_11_2018
        public void attbill(string com,string coadd,string sub,DataTable dt)
        {
            Crypt_AttBill_Rpt ab = new Crypt_AttBill_Rpt();
            ab.SetDataSource(dt);
            ab.SetParameterValue(0, com);
            ab.SetParameterValue(1, coadd);
            ab.SetParameterValue(2, sub);
            crystalReportViewer1.ReportSource = ab;

        }

        ////- updated by joji 15-11-2018
        //public void d_deduct(string com, string CO_ADD, string loc, string client, string clientadd, string sub, DataTable dt)
        //{
        //    R_Deduct wf = new R_Deduct();
        //    wf.SetDataSource(dt);
        //    wf.SetParameterValue(0, com);
        //    wf.SetParameterValue(1, CO_ADD);
        //    wf.SetParameterValue(2, loc);
        //    wf.SetParameterValue(3, client);
        //    wf.SetParameterValue(4, clientadd);
        //    wf.SetParameterValue(5, sub);

        //    crystalReportViewer1.ReportSource = wf;

        //}

        //- updated by joji 13-12-2018


        public void d_deduct(string com, string CO_ADD, string loc, string client, string clientadd, string sub, DataTable dt, int flag)
        {
            R_Deduct wf = new R_Deduct();
            wf.SetDataSource(dt);
            wf.SetParameterValue(0, com);
            wf.SetParameterValue(1, CO_ADD);
            wf.SetParameterValue(2, loc);
            wf.SetParameterValue(3, client);
            wf.SetParameterValue(4, clientadd);
            wf.SetParameterValue(5, sub);

            crystalReportViewer1.ReportSource = wf;
            if (flag == 1)
            { wf.PrintToPrinter(1, false, 0, 0); }

        }


        ////joji new - 15-11-2018 
        //public void dam(string com, string CO_ADD, string loc, string client, string clientadd, string sub, DataTable dt)
        //{
        //    R_Damage wf = new R_Damage();
        //    wf.SetDataSource(dt);
        //    wf.SetParameterValue(0, com);
        //    wf.SetParameterValue(1, CO_ADD);
        //    wf.SetParameterValue(2, loc);
        //    wf.SetParameterValue(3, client);
        //    wf.SetParameterValue(4, clientadd);
        //    wf.SetParameterValue(5, sub);

        //    crystalReportViewer1.ReportSource = wf;

        //}

        //joji readd - 13-12-2018 

        public void dam(string com, string CO_ADD, string loc, string client, string clientadd, string sub, DataTable dt, int flag)
        {
            R_Damage wf = new R_Damage();
            wf.SetDataSource(dt);
            wf.SetParameterValue(0, com);
            wf.SetParameterValue(1, CO_ADD);
            wf.SetParameterValue(2, loc);
            wf.SetParameterValue(3, client);
            wf.SetParameterValue(4, clientadd);
            wf.SetParameterValue(5, sub);

            crystalReportViewer1.ReportSource = wf;
            if (flag == 1)
            {
                wf.PrintToPrinter(1, false, 0, 0);
            }

        }

        //public void R_OT(string com, string add, string sub, string client, DataTable dt, string month,string cl_add)
        //{
        //    regis_ot wf = new regis_ot();
        //    wf.SetDataSource(dt);
        //    wf.SetParameterValue(0, com);
        //    wf.SetParameterValue(1, add);
        //    wf.SetParameterValue(2, sub);
        //    wf.SetParameterValue(3, client);
        //    wf.SetParameterValue(4, month);
        //    wf.SetParameterValue(5, cl_add);
        //    crystalReportViewer1.ReportSource = wf;

        //}

        //joji remodify - 13-12-2018
        public void R_OT(string com, string add, string sub, string client, DataTable dt, string month, string cl_add, int flag)
        {
            regis_ot wf = new regis_ot();
            wf.SetDataSource(dt);
            wf.SetParameterValue(0, com);
            wf.SetParameterValue(1, add);
            wf.SetParameterValue(2, sub);
            wf.SetParameterValue(3, client);
            wf.SetParameterValue(4, month);
            wf.SetParameterValue(5, cl_add);
            crystalReportViewer1.ReportSource = wf;
            if (flag == 1)
            {
                wf.PrintToPrinter(1, false, 0, 0);
            }

        }

        //---------joji ---- 16-07-2018
        public void VerifyLetter(DataTable dvl_table)
        {
            Crypt_VerifyLetter_NoHeader verl = new Crypt_VerifyLetter_NoHeader();
            verl.SetDataSource(dvl_table);

            crystalReportViewer1.ReportSource = verl;

        }
        // 09 / 01  / 2019
        public void VerifyLetter_2(DataTable dvl_table)
        {
            Crypt_VerifyLetter_1 verl = new Crypt_VerifyLetter_1();
            verl.SetDataSource(dvl_table);

            crystalReportViewer1.ReportSource = verl;

        }

        public void kycDoc(DataTable dvl_table)
        {
            Crypt_PrntDoc verl = new Crypt_PrntDoc();
            verl.SetDataSource(dvl_table);

            crystalReportViewer1.ReportSource = verl;

        }
        //---joji 05_09_2018
        public void empwiseposting(String cmp, String sub, DataTable dt_post)
        {
            Crypt_EmpWise_Posting po = new Crypt_EmpWise_Posting();
            po.SetDataSource(dt_post);
            po.SetParameterValue(0, cmp);
            po.SetParameterValue(1, sub);

            crystalReportViewer1.ReportSource = po;
        }

        //-- Joji 25-10-2018
        //public void regwrkmen(string adj, string sub, string header, DataTable dty)
        //{
        //    Crypt_RegWrkMen abc = new Crypt_RegWrkMen();
        //    abc.SetDataSource(dty);
        //    abc.SetParameterValue(0, header);
        //    abc.SetParameterValue(1, sub);
        //    abc.SetParameterValue(2, adj);

        //    crystalReportViewer1.ReportSource = abc;

        //}

        //-- joji update 12/11/2018 again - 19/12/2018
        public void regwrkmen(string comp, string CO_ADD, string sub, string client, string clientadd, DataTable dty, int stp)
        {
            Crypt_RegWrkMen abc = new Crypt_RegWrkMen();
            abc.SetDataSource(dty);
            abc.SetParameterValue(0, comp);
            abc.SetParameterValue(1, CO_ADD);
            abc.SetParameterValue(2, sub);
            abc.SetParameterValue(3, client);
            abc.SetParameterValue(4, clientadd);

            crystalReportViewer1.ReportSource = abc;
            if (stp == 1)
            {
                abc.PrintToPrinter(1, false, 0, 0);
            }

        }

        //joji 06_09_2018
        public void empdetails(string Header, DataTable dt)
        {
            Crypt_EMP_Details ed = new Crypt_EMP_Details();
            ed.SetDataSource(dt);
            ed.SetParameterValue(0, Header);

            crystalReportViewer1.ReportSource = ed;
        }
        //joji - 18_09_2018
        public void ledacc(string cl, string loc, string comp, string sub, string Start_d, DataTable dt_main, int flag)
        {
            Crypt_LedgerAcc rp = new Crypt_LedgerAcc();
            rp.SetDataSource(dt_main);
            rp.SetParameterValue(0, cl);
            rp.SetParameterValue(1, loc);
            rp.SetParameterValue(2, comp);
            rp.SetParameterValue(3, sub);
            rp.SetParameterValue(4, Start_d);
            crystalReportViewer1.ReportSource = rp;
            if (flag == 1)
            {
               
                rp.PrintToPrinter(1, false, 0, 0);
            }


            //Crypt_LedgerAcc rp = new Crypt_LedgerAcc();
            //rp.SetDataSource(dt_main);
            //rp.SetParameterValue(0, cl);
            //rp.SetParameterValue(1, loc);
            //rp.SetParameterValue(2, comp);
            //rp.SetParameterValue(3, sub);
            //rp.SetParameterValue(4, Start_d);
            //crystalReportViewer1.ReportSource = rp;
        }

        //joji 30-10-2018 updated 01-11-2018 again 19/12/2018

        public void bonus(string co_add, string co_name, string sub, string month, DataTable dt, int stp)
        {
            Crypt_BonusReg bt = new Crypt_BonusReg();
            bt.SetDataSource(dt);
            bt.SetParameterValue(0, co_name);
            bt.SetParameterValue(1, co_add);
            bt.SetParameterValue(2, sub);
            bt.SetParameterValue(3, month);

            crystalReportViewer1.ReportSource = bt;
            if (stp == 1)
            {
                bt.PrintToPrinter(1, false, 0, 0);
            }
        }

        // joji - 05_11_2018 - updated - 19/12/2018
        public void i_card(string com, string add, string sub, string client, string clientadd, DataTable dt, int stp)
        {
            Crypt_Icard wf = new Crypt_Icard();
            wf.SetDataSource(dt);
            wf.SetParameterValue(0, com);
            wf.SetParameterValue(1, add);
            wf.SetParameterValue(2, sub);
            wf.SetParameterValue(3, client);
            wf.SetParameterValue(4, clientadd);
            crystalReportViewer1.ReportSource = wf;
            if (stp == 1)
            {
                wf.PrintToPrinter(1, false, 0, 0);
            }

        }

        //25/07/2018
        public void regattnd(string id, string strClientName, string cltadd, string coadd, string Sub, string head, string head1, DataTable dt_regatt, int stp)
        {
            Crypt_RegisterAttendance cra = new Crypt_RegisterAttendance();
            cra.SetDataSource(dt_regatt);
            cra.SetParameterValue(0, id);
            cra.SetParameterValue(1, strClientName);
            cra.SetParameterValue(2, cltadd);
            cra.SetParameterValue(3, coadd);
            cra.SetParameterValue(4, Sub);
            cra.SetParameterValue(5, head);
            cra.SetParameterValue(6, head1);
            crystalReportViewer1.ReportSource = cra;
            if (stp == 1)
            { cra.PrintToPrinter(1, false, 0, 0); }
        }

        public void empsalwage(DataTable dt, ArrayList EHead, ArrayList DHead, int ErnStartPos, int DedStartPos, string cname, string cadd, string mnth, string year, int ptype)
        {
            CryptRpt_EmpSalWage row = new CryptRpt_EmpSalWage();
            string ColName = "";
            int CountOfCols = 0;
            for (int i = ErnStartPos; i <= DedStartPos - 2; i++)
            {
                CountOfCols = i - ErnStartPos + 12;
                dt.Columns[i].ColumnName = "col" + CountOfCols;
            }
            for (int i = DedStartPos; i <= dt.Columns.Count - 3; i++)
            {
                CountOfCols = i - DedStartPos + 23;
                dt.Columns[i].ColumnName = "col" + CountOfCols;
            }
            for (int i = 0; i < EHead.Count; i++)
            {
                ColName = "Text" + Convert.ToString(i + 12);
                CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                txtApprovalStatus1.Text = "";
                txtApprovalStatus1.Text = Convert.ToString(EHead[i]);
            }
            for (int i = 0; i < DHead.Count; i++)
            {
                ColName = "Text" + Convert.ToString(i + 23);
                CrystalDecisions.CrystalReports.Engine.TextObject txtApprovalStatus1 = ((CrystalDecisions.CrystalReports.Engine.TextObject)row.ReportDefinition.Sections["Section2"].ReportObjects[ColName]);
                txtApprovalStatus1.Text = "";
                txtApprovalStatus1.Text = Convert.ToString(DHead[i]);
            }

            //row.SetDataSource(dt);
            row.Database.Tables[0].SetDataSource(dt);
            row.SetParameterValue(0, cname);
            row.SetParameterValue(1, cadd);                //row.SetParameterValue(2, clname);
            //row.SetParameterValue(3, lname);
            row.SetParameterValue(2, mnth);
            row.SetParameterValue(3, year);

            if (ptype == 1)
                crystalReportViewer1.ReportSource = row;

        }

      
        //------------------------- 
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }    
}
  