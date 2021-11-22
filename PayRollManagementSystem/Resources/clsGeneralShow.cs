using System;
using System.Collections.Generic;
using System.Text;
using Edpcom;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using Finance;
using MidasReport;
using Utility;
using FinanceReport;
using EDPMessageBox;
using Investment_Report;
using EDPSetting;

namespace AccordFour
{
    class clsGeneralShow
    {
        Edpcom.EDPCommon EDPComm = new EDPCommon();
        Edpcom.EDPConnection EDPConn = new EDPConnection();
        SqlCommand mycmd;
        DataTable dt;
            
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet DS = new DataSet();
        public void GeneralShow(String Menucode, Form parent)
        {
            switch (Menucode)//40020100000//40020302000 
            {
                case "20010100000": ShowLedgerSubgrp(parent); // 105000000ShowFinance
                    break;
                case "20010200000": ShowFinance(parent); // 105000000
                    break;
                case "20020201000": ShowForm(new frmInvMst(0), parent); // 105000000
                    break;               
                case "20020202000": ShowForm(new frmInvMst(1), parent); // 105000000
                    break;
                case "20020203000": ShowForm(new frmInvMst(2), parent); // 105000000
                    break;
                case "20020101000": ShowForm(new frmInvMst(3), parent); // 105000000
                    break;
                case "20020402020": ShowForm(new frmInvMst(4), parent); // 105000000
                    break;
                case "20060000000": ShowForm(new frmInvMst(5), parent); // 105000000
                    break;
                case "20070000000": ShowForm(new frmInvMst(6), parent); // 105000000
                    break;
                case "20080000000": ShowForm(new frmInvMst(7), parent); // 105000000
                    break;
                case "20090000000": ShowForm(new frmInvMst(8), parent); // 105000000
                    break;
                case "20100000000": ShowForm(new frmInvMst(9), parent); // 105000000
                    break;
                //case "2011000000": ShowForm(new frmInvMst(10), parent); // 20010701000
                //    break;
                case "20010701000": ShowForm(new frmInvMst(10), parent); // 20010701000
                    break;
                case "20010702000": ShowForm(new frmInvMst(11), parent); // 20010701000
                    break;
                case "20020301010":
                    if (EDPComm.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno = '3.10.1'") == "TRUE")
                    {
                        EDPMessage.Show("Service Type Order ?", "Confirm", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
                        if (EDPMessage.ButtonResult == "edpYES")
                            ShowForm(new frmBILL("OS", 'P'), parent);
                        else
                            ShowForm(new frmBILL("OS", 'O'), parent);
                    }
                    else
                        ShowForm(new frmBILL("OS", 'A'), parent);
                    break;
                case "20020301020": //ShowForm(new frmBILL("CHLN",'A'), parent); // 105000000                
                    if (EDPComm.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno = '3.10.1'") == "TRUE")
                    {
                        EDPMessage.Show("Service Type Challan ?", "Confirm", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
                        if (EDPMessage.ButtonResult == "edpYES")
                            ShowForm(new frmBILL("CHLN", 'P'), parent);
                        else
                            ShowForm(new frmBILL("CHLN", 'O'), parent);
                    }
                    else
                        ShowForm(new frmBILL("CHLN", 'A'), parent);
                    break;
                case "20020301030": //ShowForm(new frmBILL("SALES", 'A'), parent); // 105000000                
                    if (EDPComm.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno = '3.10.1'") == "TRUE")
                    {
                        EDPMessage.Show("Service Type Billing ?", "Confirm", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
                        if (EDPMessage.ButtonResult == "edpYES")
                            ShowForm(new frmBILL("SALES", 'P'), parent);
                        else
                            ShowForm(new frmBILL("SALES", 'O'), parent);
                    }
                    else
                        ShowForm(new frmBILL("SALES", 'A'), parent);
                    break;
                case "20020301040": ShowForm(new frmBILL("SRETURN", 'A'), parent); // 105000000                
                    break;
                case "20020501000": ShowForm(new frmBILL("SI", 'A'), parent); // 105000000                
                    break;
                case "20020502000": ShowForm(new frmBILL("STKOUT", 'A'), parent); // 105000000                
                    break;
                case "20020302010": ShowForm(new frmBILL("PO", 'A'), parent); // 105000000                
                    break;
                case "20020302020": ShowForm(new frmBILL("PURCHLN", 'A'), parent); // 105000000                
                    break;
                case "20020302030": ShowForm(new frmBILL("PUR", 'A'), parent); // 105000000                
                    break;
                case "20020302040": ShowForm(new frmBILL("PR", 'A'), parent); // 105000000                
                    break;
                case "30020201000": ShowForm(new frmStockQryProductWise(), parent); // 105000000                
                    break;
                case "40010102000": showCashBook(parent); // 105000000                
                    break;
                case "40010103000": showBankBook(parent); // 105000000                
                    break;
                case "40010101010": showGeneralLedger(parent); // 105000000          
                    break;
                case "30010102000": showCashBookQry(parent);// 310000100
                    break;
                case "30010103000": showBankBookQry(parent);// 310000200
                    break;
                case "30010101000": showGeneralLedgerQry(parent);// 310000400
                    break;
                case "20020103000": SalesRate(parent); // 105000000                
                    break;
                case "20020104000": MarketRate(parent); // 105000000                
                    break;
                case "40010203000": billrpt(parent);
                    break;
                case "40010404040": ShowForm(new FinanceReport.SalesVatRegister(), parent);
                    break;
               
                case "50010000000": ShowForm(new frmConfigure(), parent); // 105000000
                    break;

                case "60090000000": UpdateTentry(parent);
                    break;
                case "2012000000":
                    ShowForm(new frmInvMst(11), parent);
                    break;

                case "10050000000": ShowBranch(parent);// 105000000                  
                    break;
                case "10030000000": ShowEditComp(parent);// 103000000
                    break;
                case "10040000000": ShowDelComp(parent);// 104000000
                    break;
                case "10060100000": ShowCurrency(parent);// 106010000
                    break;                               
                case "20010301000": ShowVoucher(parent);// 201040100
                    break;                                                         
                case "60030000000": ShowAcpost(parent);// 503000000
                    break;               
                case "91020000000": showabout(parent);// 902000000
                    break;
                case "80020000000": ShowBackup();// 720000000
                    break;
                case "80030000000": ShowRestore();// 730000000
                    break;
                case "60060000000": showInflt(parent);// 506000000
                    break;
                case "50010301000": showTrialBalance(parent);// 410000500         
                    break;              
                case "50020100000": showStckVal(parent);// 420000100
                    break;
                case "50010302000": showPL(parent);// 410000600
                    break;
                case "50020201000": showPurchaseReg(parent);// 420000200
                    break;
                case "50020202000": ShowSalesReg(parent);//sb40020101000
                    break;
                case "40010201000": showTrBlnc(parent);// 310000500
                    break;
                case "50211010000": ShowForm(new frmActiveMainSubGrp("M"), parent);
                    break;
                case "50211020000": ShowForm(new frmActiveMainSubGrp("S"), parent);
                    break;
                case "50211030000": ShowForm(new frmActiveMainSubGrp("AC"), parent);
                    break;
               
                case "60070000000": UserFormula(parent);// 507000000
                    break;
                case "50010104000": showJurnal(parent);// 410000300
                    break;
                case "40010104000": showJurnalQ(parent);// 310000300
                    break;
                case "40020405000": showSttQ(parent);// 320000600
                    break;               
                case "60040000000": showToolBar(parent);// 504000000
                    break;
                //case "30020100000": showConversion(parent);// 202130000
                   //break;


                case "60080000000": showHotKey(parent);// 
                    break;                           
                case "320000800": showAccountLedgDetl(parent);//old
                    break;               
                case "510000000": showTConfig(parent);//old 
                    break;                
                case "70100000000": ShowForm(new frmColorScheme(), parent);
                    break;
                case "40010303000": ShowForm(new FinanceReport.BalanceSheetReport(), parent);
                    break;
                case "40010302000": ShowForm(new FinanceReport.PeofitandLossReport(), parent);
                    break;
                case "30010104000": ShowForm(new frmJurnal(), parent);
                    break;
                case "30010201000": ShowForm(new TrialBlncScrn(), parent);
                    break;
                case "30010202000": ShowForm(new BalanceSheetQry(), parent);
                    break;
                case "40010106000": ShowForm(new FinanceReport.frmRptJurnal(), parent);
                    break;
                case "40010202000": ShowForm(new FinanceReport.frmReportVoucher(), parent);
                    break;//
                case "40010301000": ShowForm(new TrialBalance(), parent);
                    break;
                case "50130000000": ShowForm(new Utility.frmBackUp(), parent);
                    break;
                case "50140200000": ShowForm(new Utility.frmRestore(), parent);
                    break;
                case "20010304000": ShowForm(new frmAllocation(), parent);
                    break;
                case "50060000000": ShowForm(new frmAccountPosting(), parent);
                    break;
                case "20020402010": ShowForm(new frmLOG(), parent);
                    break;
                case "6005000000":
                    try
                    {
                        //System.Diagnostics.Process.Start("notepad.exe");
                    }
                    catch { }
                    break;
                case "40020202000":
                    if (EDPComm.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno = '3.10.1'") == "TRUE")
                    {
                        ShowForm(new FinanceReport.PaperstatementRpt(), parent);
                    }
                    break;
                case "20020303000":
                    if (EDPComm.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno = '3.10.1'") == "TRUE")
                    {
                        ShowForm(new frmStockTransfer(), parent);
                    }
                    break;
                case "40020101010": Stockout(parent);
                    break;
                case "40020101020": Challan(parent);
                    break;
                case "30010400000": ShowForm(new frmSalesQury(), parent);
                    break;
            }
        }

        private void Stockout(Form parent)
        {
            if (EDPComm.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno='3.10.1'") == "TRUE")
            {
                billrpt sb = new billrpt();
                sb.Get("SO");
                sb.Show();
            }
        }
        private void Challan(Form parent)
        {
            if (EDPComm.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno='3.10.1'") == "TRUE")
            {
                billrpt sb = new billrpt();
                sb.Get("n");
                sb.Show();
            }
            if (EDPComm.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno='3.10.2'") == "TRUE")
            {
                FinanceReport.DyeningChallan dc = new DyeningChallan();
                dc.ShowDialog();
            }
        }

        private void billrpt(Form parent)
        {
            if (EDPComm.GetresultS("select distinct  upper(bool_val) from WACCOPTN where  FICODE='" + EDPComm.CurrentFicode + "' AND GCODE='" + EDPComm.PCURRENT_GCODE + "' and seriesno in ('3.10.1')") == "TRUE")
            {
                billrpt sb = new billrpt();
                sb.Get("9");
                sb.Show();
            }
            else
            {
                FinanceReport.sellbillrpt sb = new FinanceReport.sellbillrpt();
                sb.Show();
            }
        }

        private void SalesRate(Form parent)
        {
            frmInvMst iv = new frmInvMst(8);
            iv.ShowDialog();
        }
        private void MarketRate(Form parent)
        {
            frmInvMst iv = new frmInvMst(9);
            iv.ShowDialog();
        }

        private void UpdateTentry(Form parent)
        {
            frmTypeMastChange tmc = new frmTypeMastChange();
            tmc.ShowDialog();
        }

        private void purRegisterReport(Form parent)
        {
            //frmPruchaseRegReport AP = new frmPruchaseRegReport();
            //AP.ShowDialog();
        }

        private void DailyTallySheet(Form parent)
        {
            //DailyTellysheerrpt AP = new DailyTellysheerrpt();
            //AP.ShowDialog();
        }

        private void AgentWiseSalesReport(Form parent)
        {
            //Agentwisesalesrpt AP = new Agentwisesalesrpt();
            //AP.ShowDialog();
        }

        private void showPrintingOrderRpt(Form parent)
        {
            //frmBookBinding AP = new frmBookBinding();
            //AP.ShowDialog();
        }

        private void showBindingOrderRpt(Form parent)
        {
            //frmBindingOrder AP = new frmBindingOrder();
            //AP.ShowDialog();
        }

        private void showAgentPerformance(Form parent)
        {
            //AgentPerformancerpt AP = new AgentPerformancerpt();
            //AP.ShowDialog();
        }

        private void PrintCashMemo(Form parent)
        {
            //string page = "Sin";
            //billrpt fd = new billrpt();
            ////Specimentinrpt fd = new Specimentinrpt();
            //fd.Get(page);
            ////frmDelComp fd = new frmDelComp();
            //fd.ShowDialog();
        }

        private void PrintSpecimenIn(Form parent)
        {
            //string page = "Sin";
            //Specimentinrpt fd = new Specimentinrpt();
            //fd.Get(page);
            ////frmDelComp fd = new frmDelComp();
            //fd.ShowDialog();
        }

        private void PrintSpecimenOut(Form parent)
        {
            //string page = "Out";
            //Specimentinrpt fd = new Specimentinrpt();
            //fd.Get(page);
            ////frmDelComp fd = new frmDelComp();
            //fd.ShowDialog();
        }


        private void MarketRateUpdate(Form parent)
        {
            frmMasters NRM = new frmMasters(5);
            if (EDPComm.CheckMdiChild(NRM, parent))
                return;
            NRM.MdiParent = parent;
            NRM.Show();
        }

        private void FnoReport(Form parent)
        {
            Investment_Report.Derivativesrpt dev = new Investment_Report.Derivativesrpt();
            dev.Show();
        }

        private void CommodityMISReport(Form parent)
        {
            Investment_Report.Commodityrpt CDT = new Investment_Report.Commodityrpt();
            CDT.Show();
        }
//New
        private void EquityBonusReceivedReport(Form parent)
        {
            Investment_Report.Equitybonusrpt equ = new Investment_Report.Equitybonusrpt();
            equ.Show();
        }

        private void AssetInfoGlobal(Form parent)
        {
            //frmAssetInformationGlobal NRM = new frmAssetInformationGlobal();
            //if (EDPComm.CheckMdiChild(NRM, parent))
            //    return;
            //NRM.MdiParent = parent;
            //NRM.Show();
        }

        private void BRSReport(Form parent)
        {
            FinanceReport.Bank_Reconcilliation_Report Br = new FinanceReport.Bank_Reconcilliation_Report();
            Br.Show();
        }

        private void SalesPurchaseAnanlytical(Form parent)
        {
            Investment_Report.SalesPurchaseAnalyticalregister mfgl = new SalesPurchaseAnalyticalregister();
            if (EDPComm.CheckMdiChild(mfgl, parent))
                return;
            mfgl.MdiParent = parent;
            mfgl.Show();
        }

        private void MFOpening(Form parent)
        {
            Investment_Report.Mfund mf = new Investment_Report.Mfund();
            mf.Show();
        }
        private void MFDevedendReceived(Form parent)
        {
            Investment_Report.MFDevidendReceived mf = new Investment_Report.MFDevidendReceived();
            mf.Show();
        }

        private void MFata_glance(Form parent)
        {
            Investment_Report.MFglance mfgl = new MFglance();
            if (EDPComm.CheckMdiChild(mfgl, parent))
                return;
            mfgl.MdiParent = parent;
            mfgl.Show();
        }

        private void ShowfrmMFGlobal(Form parent)
        {
            //frmMFGlobal mfg = new frmMFGlobal("Units");
            //if (EDPComm.CheckMdiChild(mfg, parent))
            //    return;
            //mfg.MdiParent = parent;
            //mfg.Show();
        }


        private void MutualFundReport(Form parent)
        {
            Investment_Report.MutualFundReport mf = new Investment_Report.MutualFundReport();
            mf.Show();
        }

        private void ShowBalanceSheetReport(Form parent)
        {
            FinanceReport.BalanceSheetReport testFD = new FinanceReport.BalanceSheetReport();
            if (EDPComm.CheckMdiChild(testFD, parent))
                return;
            testFD.MdiParent = parent;
            testFD.Show();
        }

        private void ShowSubscriptionForFD(Form parent)
        {
            Investment_Report.Frmfdcreaterpt testFD = new Frmfdcreaterpt();
            if (EDPComm.CheckMdiChild(testFD, parent))
                return;
            testFD.MdiParent = parent;
            testFD.Show();
        }
        private void ShowRedemptionReportFD(Form parent)
        {
            Investment_Report.Frmfdredemptionrpt testFD = new Frmfdredemptionrpt();
            if (EDPComm.CheckMdiChild(testFD, parent))
                return;
            testFD.MdiParent = parent;
            testFD.Show();
        }
        private void ShowInterestReceivedFD(Form parent)
        {
            Investment_Report.Frmfdinterestrpt testFD = new Frmfdinterestrpt();
            if (EDPComm.CheckMdiChild(testFD, parent))
                return;
            testFD.MdiParent = parent;
            testFD.Show();
        }

        private void Sessionwise_Report_Show(Form parent)
        {            
            Utility.Sessionwise_Report Session_wise_rpt = new Sessionwise_Report();
            if (EDPComm.CheckMdiChild(Session_wise_rpt, parent))
                return;
            Session_wise_rpt.MdiParent = parent;
            Session_wise_rpt.Show();

        }
        private void Formwise_Report_Show(Form parent)
        {            
            Utility.frmfromwisereport frmreport = new frmfromwisereport();
            if (EDPComm.CheckMdiChild(frmreport, parent))
                return;
            frmreport.MdiParent = parent;
            frmreport.Show();            
        }

        private void ShowFDPerformanceReport(Form parent)
        {
            Investment_Report.frmFDAccruedInterest FDO = new frmFDAccruedInterest("PER");
            if (EDPComm.CheckMdiChild(FDO, parent))
                return;
            FDO.MdiParent = parent;
            FDO.Show();
        }

        private void ShowFDAccruedInterest(Form parent)
        {            
            Investment_Report.frmFDAccruedInterest FDO = new frmFDAccruedInterest("ACC");
            if (EDPComm.CheckMdiChild(FDO, parent))
                return;
            FDO.MdiParent = parent;
            FDO.Show();
        }

        private void ShowFDOpeningChecklist(Form parent)
        {
            Investment_Report.frmfdopening FDO = new Investment_Report.frmfdopening();
            if (EDPComm.CheckMdiChild(FDO, parent))
                return;
            FDO.MdiParent = parent;
            FDO.Show();
        }

        private void ShowRealizedGainLossSummary(Form parent)
        {
            PortfolioReport.frmAssetUnderManagement AUM = new PortfolioReport.frmAssetUnderManagement("SRGL");
            if (EDPComm.CheckMdiChild(AUM, parent))
                return;
            AUM.MdiParent = parent;
            AUM.Show();
        }

        private void showDPStockStatusReport(Form parent)
        {
            Investment_Report.frmDpclosingstock dpclosing = new frmDpclosingstock();
            dpclosing.Show();
        }

        private void showDPSummaryReport(Form parent)
        {            
            Investment_Report.DpSummaryReport dpsr = new DpSummaryReport();
            dpsr.Show();            
        }

        private void showPerformanceHistoryReport(Form parent)
        {
            PortfolioReport.frmPerformanceHistoryOfNetFees AUM = new PortfolioReport.frmPerformanceHistoryOfNetFees();
            if (EDPComm.CheckMdiChild(AUM, parent))
                return;
            AUM.MdiParent = parent;
            AUM.Show();
        }

        private void Voucher_Statistics_Show(Form parent)
        {
           // frm_new_voucher_statics AUM = new frm_new_voucher_statics();
           //// Voucher_Statistics AUM = new Voucher_Statistics();            
           // if (EDPComm.CheckMdiChild(AUM, parent))
           //     return;
           // AUM.MdiParent = parent;
           // AUM.Show();            
        }

        private void showDPWiseStockReport(Form parent)
        {
            Investment_Report.stockdpwise DPS = new stockdpwise();
            if (EDPComm.CheckMdiChild(DPS, parent))
                return;
            DPS.MdiParent = parent;
            DPS.Show();
        }

        private void showPortfolioAssetUnderManagementReport(Form parent)
        {
            PortfolioReport.frmAssetUnderManagement AUM = new PortfolioReport.frmAssetUnderManagement("AUM");
            if (EDPComm.CheckMdiChild(AUM, parent))
                return;
            AUM.MdiParent = parent;
            AUM.Show();            
        }

        private void ShowPortfolioMaster(Form parent)
        {
            frmMasters PFM = new frmMasters(5);
            if (EDPComm.CheckMdiChild(PFM, parent))
                return;
            PFM.MdiParent = parent;
            PFM.Show();
        }

        private void showOpeningForEquityReport(Form parent)
        {
            //Investment_Report testOpeningEquity = new Mfund();
            Investment_Report.frmOpeningEquity testOpeningEquity = new frmOpeningEquity();
            if (EDPComm.CheckMdiChild(testOpeningEquity, parent))
                return;
            testOpeningEquity.MdiParent = parent;
            testOpeningEquity.Show();
        }

        private void showLongTermSalesReport(Form parent)
        {
            Investment_Report.frmSalesAnalypisRegisterLong DivRec = new Investment_Report.frmSalesAnalypisRegisterLong();
            if (EDPComm.CheckMdiChild(DivRec, parent))
                return;
            DivRec.MdiParent = parent;
            DivRec.Show();
        }

        private void showDividendReport(Form parent)
        {
            Investment_Report.frmDevidendReceived DivRec = new Investment_Report.frmDevidendReceived();
            if (EDPComm.CheckMdiChild(DivRec, parent))
                return;
            DivRec.MdiParent = parent;
            DivRec.Show();
        }

        private void showShortTermSalesReport(Form parent)
        {
            Investment_Report.frmSalesPurAnalysis SPA = new Investment_Report.frmSalesPurAnalysis();
            if (EDPComm.CheckMdiChild(SPA, parent))
                return;
            SPA.MdiParent = parent;
            SPA.Show();
        }

        private void ShowLnkCtConfig(Form parent)
        {
            //frmVTran PPFS = new frmVTran();
            //if (EDPComm.CheckMdiChild(PPFS, parent))
            //    return;
            //PPFS.MdiParent = parent;
            //PPFS.Show();
        }

        private void ShowCtConfig(Form parent)
        {
            //frmVMast PPFS = new frmVMast();
            //if (EDPComm.CheckMdiChild(PPFS, parent))
            //    return;
            //PPFS.MdiParent = parent;
            //PPFS.Show();
        }

        private void ShowcmstckQ(Form parent)
        {
            //frmcmstckQ PPFS = new frmcmstckQ();
            //if (EDPComm.CheckMdiChild(PPFS, parent))
            //    return;
            //PPFS.MdiParent = parent;
            //PPFS.Show();
        }
        //private void showMFPortFolio(Form parent)
        //{
        //    frmMutualFundPortFolio MFP = new frmMutualFundPortFolio();
        //    if (EDPComm.CheckMdiChild(MFP, parent))
        //        return;
        //    MFP.MdiParent = parent;
        //    MFP.Show();
        //}
      
        private void showPPFSubscription(Form parent)
        {
            //frmPPFEntry PPFS = new frmPPFEntry();
            //if (EDPComm.CheckMdiChild(PPFS, parent))
            //    return;
            //PPFS.MdiParent = parent;
            //PPFS.Show();
        }

        private void showMFTransactionQry(Form parent)
        {
            //frmMutualFundTransactionQry MFTQ = new frmMutualFundTransactionQry();
            //if (EDPComm.CheckMdiChild(MFTQ, parent))
            //    return;
            //MFTQ.MdiParent = parent;
            //MFTQ.Show();
        }

        private void showAssetUnrealizedGainLoss(Form parent)
        {
            //frmAssetUnrealizedGainLoss AUGL = new frmAssetUnrealizedGainLoss();
            //if (EDPComm.CheckMdiChild(AUGL, parent))
            //    return;
            //AUGL.MdiParent = parent;
            //AUGL.Show();
        }

        private void show_AC_BalTransfer(Form parent)
        {
            //frmACBalTransfer ABT = new frmACBalTransfer();
            //if (EDPComm.CheckMdiChild(ABT, parent))
            //    return;
            //ABT.MdiParent = parent;
            //ABT.Show();
        }

        private void showStockTransfer(Form parent)
        {
            //frmClosingStockTransfer AC = new frmClosingStockTransfer();
            //if (EDPComm.CheckMdiChild(AC, parent))
            //    return;
            //AC.MdiParent = parent;
            //AC.Show();
        }

        private void showAssetClassUpdate(Form parent)
        {
            //frmActiveMainSubGrp AC = new frmActiveMainSubGrp("AC");
            //if (EDPComm.CheckMdiChild(AC, parent))
            //    return;
            //AC.MdiParent = parent;
            //AC.Show();
        }

        private void showClassificationUpdate(Form parent)
        {
            //frmActiveMainSubGrp CL = new frmActiveMainSubGrp("Cl");
            //if (EDPComm.CheckMdiChild(CL, parent))
            //    return;
            //CL.MdiParent = parent;
            //CL.Show();
        }

        private void showPortfolioAssetUpdate(Form parent)
        {
            //frmActiveMainSubGrp PAC = new frmActiveMainSubGrp("PAC");
            //if (EDPComm.CheckMdiChild(PAC, parent))
            //    return;
            //PAC.MdiParent = parent;
            //PAC.Show();
        }
        private void showMainGroupUpdate(Form parent)
        {
            //frmActiveMainSubGrp MG = new frmActiveMainSubGrp("M");
            //if (EDPComm.CheckMdiChild(MG, parent))
            //    return;
            //MG.MdiParent = parent;
            //MG.Show();
        }

        private void showSubGroupUpdate(Form parent)
        {
            //frmActiveMainSubGrp SG = new frmActiveMainSubGrp("S");
            //if (EDPComm.CheckMdiChild(SG, parent))
            //    return;
            //SG.MdiParent = parent;
            //SG.Show();
        }

        private void showStockUpDate(Form parent)
        {
            //StockUpdate pr = new StockUpdate();
            //if (EDPComm.CheckMdiChild(pr, parent))
            //    return;
            ////pr.MdiParent = parent;
            //pr.Show();
        }

        private void showFDMSIReport(Form parent)
        {
            //frmFDMsiReport pr = new frmFDMsiReport();
            //if (EDPComm.CheckMdiChild(pr, parent))
            //    return;
            //pr.MdiParent = parent;
            //pr.Show();
        }

        private void showPortfolio_Analysis_Equity(Form parent)
        {
            //frmPortfolioManagement_EqListed pme = new frmPortfolioManagement_EqListed();
            //if (EDPComm.CheckMdiChild(pme, parent))
            //    return;
            //pme.MdiParent = parent;
            //pme.Show();
        }

        private void showMutualFundAtaGlance(Form parent)
        {
            //frmMutualFundQry mfq = new frmMutualFundQry();
            //if (EDPComm.CheckMdiChild(mfq, parent))
            //    return;
            //mfq.MdiParent = parent;
            //mfq.Show();
        }

        private void ShowForm(Form ToShow, Form parent)
        {
            if (EDPComm.CheckMdiChild(ToShow, parent))
                return;
            ToShow.MdiParent = parent;
            ToShow.Show();
        }
        private void showAssetpropfld(Form parent)
        {
            //frmAssetProperty pr = new frmAssetProperty();
            //if (EDPComm.CheckMdiChild(pr, parent))
            //    return;
            //pr.MdiParent = parent;
            //pr.Show();
        }

        private void showOPBulk(Form parent)
        {
            //frmOpeningImport pr = new frmOpeningImport();
            //if (EDPComm.CheckMdiChild(pr, parent))
            //    return;
            //pr.MdiParent = parent;
            //pr.Show();
        }

        private void ShowPurchaseEU(Form parent)
        {
            //Purchase pr = new Purchase("2");
            //if (EDPComm.CheckMdiChild(pr, parent))
            //    return;
            //pr.MdiParent = parent;
            //pr.Show();
        }

        private void showFDredemption(Form parent)
        {
            //frmFdwithdraw fs = new frmFdwithdraw();
            //if (EDPComm.CheckMdiChild(fs, parent))
            //    return;
            //fs.MdiParent = parent;
            //fs.Show();
        }

        private void showEUSale(Form parent)
        {
            //frmSales fs = new frmSales("2");
            //if (EDPComm.CheckMdiChild(fs, parent))
            //    return;
            //fs.MdiParent = parent;
            //fs.Show();
        }

        private void showFDWithDrawn(Form parent)
        {
            //frmFdwithdraw fs = new frmFdwithdraw();
            //if (EDPComm.CheckMdiChild(fs, parent))
            //    return;
            //fs.MdiParent = parent;
            //fs.Show();
        }

        private void showDebentureS(Form parent)
        {
            //frmSales fs = new frmSales("3");
            //if (EDPComm.CheckMdiChild(fs, parent))
            //    return;
            //fs.MdiParent = parent;
            //fs.Show();
        }

        private void showDebentureP(Form parent)
        {
            //Purchase pr = new Purchase("3");
            //if (EDPComm.CheckMdiChild(pr, parent))
            //    return;
            //pr.MdiParent = parent;
            //pr.Show();
        }

        private void ShowInvMasterRate(Form parent)
        {
            //frmInsMktRate tcf = new frmInsMktRate();
            //if (EDPComm.CheckMdiChild(tcf, parent))
            //    return;
            //tcf.MdiParent = parent;
            //tcf.Show();
        }

        private void showTConfig(Form parent)
        {
            frmTConfig tcf = new frmTConfig();
            if (EDPComm.CheckMdiChild(tcf, parent))
                return;
            tcf.MdiParent = parent;
            tcf.Show();
        }

        private void showDividentEntry(Form parent)
        {
            //frmDividentEntry tcf = new frmDividentEntry();
            //if (EDPComm.CheckMdiChild(tcf, parent))
            //    return;
            //tcf.MdiParent = parent;
            //tcf.Show();
        }

        private void showInsRateDetails(Form parent)
        {
            //frmInsMktRate imr = new frmInsMktRate();
            //if (EDPComm.CheckMdiChild(imr, parent))
            //    return;
            //imr.MdiParent = parent;
            //imr.Show();
        }

        private void showAccountLedgDetl(Form parent)
        {
            frmAccLedDetl ald = new frmAccLedDetl();
            if (EDPComm.CheckMdiChild(ald, parent))
                return;
            ald.MdiParent = parent;
            ald.Show();
        }

        private void showNomineemaster(Form parent)
        {
            //FrmNomineeMaster NM = new FrmNomineeMaster(1);
            frmMasters NM = new frmMasters(1);
            if (EDPComm.CheckMdiChild(NM, parent))
                return;
            NM.MdiParent = parent;
            NM.Show();
        }

        private void showNomineerelation(Form parent)
        {
            //FrmNomineeMaster NRM = new FrmNomineeMaster(2);
            frmMasters NRM = new frmMasters(2);
            if (EDPComm.CheckMdiChild(NRM, parent))
                return;
            NRM.MdiParent = parent;
            NRM.Show();
        }

        private void showUnitMaster(Form parent)
        {
            //UnitMaster UM = new UnitMaster();
            frmMasters UM = new frmMasters(6);
            if (EDPComm.CheckMdiChild(UM, parent))
                return;
            UM.MdiParent = parent;
            UM.Show();
        }

        private void showFormulaMaster(Form parent)
        {
            //UnitMaster UM = new UnitMaster();
            frmMasters UM = new frmMasters(7);
            if (EDPComm.CheckMdiChild(UM, parent))
                return;
            UM.MdiParent = parent;
            UM.Show();
        }

        private void showDevidentEntry(Form parent)
        {
            //frmDividentEntry NRM = new frmDividentEntry();
            //if (EDPComm.CheckMdiChild(NRM, parent))
            //    return;
            //NRM.MdiParent = parent;
            //NRM.Show();
        }

        private void ShowBRS(Form parent)
        {
            //frmBRS brs = new frmBRS();
            //if (EDPComm.CheckMdiChild(brs, parent))
            //    return;
            //brs.MdiParent = parent;
            //brs.Show();
        }

        private void showAllocation(Form parent)
        {
            Allocation all = new Allocation();
            if (EDPComm.CheckMdiChild(all, parent))
                return;
            all.MdiParent = parent;
            all.Show();
        }

        private void showBalanSheetQry(Form parent)
        {
            //BalanceSheetQry blq = new BalanceSheetQry();            
            //if (EDPComm.CheckMdiChild(blq, parent))
            //    return;
            //blq.MdiParent = parent;
            //blq.Show();
        }

        private void showAssetClass(Form parent)
        {
            //frmAssetClassReoprt RP = new frmAssetClassReoprt();
            //if (EDPComm.CheckMdiChild(RP, parent))
            //    return;
            //RP.MdiParent = parent;
            //RP.Show();
        }

        private void showHotKey(Form parent)
        {
            HotKeys hk = new HotKeys();
            if (EDPComm.CheckMdiChild(hk, parent))
                return;
            hk.MdiParent = parent;
            hk.Show();
        }
        private void showMutualFund(Form parent)
        {
           Finance.frmBaseBrowse fi = new frmBaseBrowse();
            if (EDPComm.CheckMdiChild(fi, parent))
                return;
            EDPConn.Open();
            fi.value_pass(EDPComm.CurrentFicode, EDPComm.PCURRENT_GCODE, EDPConn.connectionstr, 2);
            fi.MdiParent = parent;
            fi.Show();
            EDPConn.Close();
        }

        //private void showShrtCptGnRpt(Form parent)
        //{
        //    //ShrtLngTrmCptGn slcg = new ShrtLngTrmCptGn(1);
        //    //if (EDPComm.CheckMdiChild(slcg, parent))
        //    //    return;
        //    //slcg.MdiParent = parent;
        //    //slcg.Show();
        //}

        //private void showLngCptGnRpt(Form parent)
        //{
        //    //Investment_Report.ShrtLngTrmCptGn slcg = new Investment_Report.ShrtLngTrmCptGn(2);
        //    //if (EDPComm.CheckMdiChild(slcg, parent))
        //    //    return;
        //    //slcg.MdiParent = parent;
        //    //slcg.Show();
        //}

        //private void showHelp(Form parent)
        //{
        //    //ProfitandLossQure plq = new ProfitandLossQure();
        //    //if (EDPComm.CheckMdiChild(plq, parent))
        //    //    return;
        //    //plq.MdiParent = parent;
        //    //plq.Show();
        //    try
        //    {
        //        Help.ShowHelp(parent, Environment.CurrentDirectory + "\\AccordFourGold.chm");
        //    }
        //    catch
        //    {
        //    }
        //}

        private void showPLScrn(Form parent)
        {
            //ProfitandLossQure plq = new ProfitandLossQure();
            //if (EDPComm.CheckMdiChild(plq, parent))
            //    return;
            //plq.MdiParent = parent;
            //plq.Show();
        }
        private void showcommodity(Form parent)
        {
            //commodity cm = new commodity();
            //frmSalesBills cm = new frmSalesBills("CASH");
            //if (EDPComm.CheckMdiChild(cm, parent))
            //    return;
            //cm.MdiParent = parent;
            //cm.Show();
        }

        private void showCreditBill(Form parent)
        {
            //commodity cm = new commodity();
            //frmSalesBills cm = new frmSalesBills("CREDIT");
            //if (EDPComm.CheckMdiChild(cm, parent))
            //    return;
            //cm.MdiParent = parent;
            //cm.Show();
        }

        private void showExpences(Form parent)
        {
            //InprovDiscount id = new InprovDiscount("I", '2');
            //if (EDPComm.CheckMdiChild(id, parent))
            //    return;
            //id.MdiParent = parent;
            //id.Show();
        }
        private void showDiscount(Form parent)
        {
            //InprovDiscount id = new InprovDiscount("D", '3');
            //if (EDPComm.CheckMdiChild(id, parent))
            //    return;
            //id.MdiParent = parent;
            //id.Show();
        }
        private void showInsPremium(Form parent)
        {
            //INS_PREMIUM insp = new INS_PREMIUM();
            //if (EDPComm.CheckMdiChild(insp, parent))
            //    return;
            //insp.MdiParent = parent;
            //insp.Show();
        }
        private void showFDCreation(Form parent)
        {
            //frmFD_Creation fdc = new frmFD_Creation();
            //if (EDPComm.CheckMdiChild(fdc, parent))
            //    return;
            //fdc.MdiParent = parent;
            //fdc.Show();
        }
        private void showFundCreation(Form parent)
        {
            //FundCreation fc = new FundCreation();
            frmMasters fc = new frmMasters(4);
            if (EDPComm.CheckMdiChild(fc, parent))
                return;
            fc.MdiParent = parent;
            fc.Show();
        }
        private void showInsurance(Form parent)
        {
            //INSURANCE ins = new INSURANCE();
            //if (EDPComm.CheckMdiChild(ins, parent))
            //    return;
            //ins.MdiParent = parent;
            //ins.Show();
        }
        private void showInsuranceCharges(Form parent)
        {
            //InsuranceCharges ins = new InsuranceCharges();
            //if (EDPComm.CheckMdiChild(ins, parent))
            //    return;
            //ins.MdiParent = parent;
            //ins.Show();
        }
        private void showReceiptPayment_Prnt(Form parent)
        {
            frmRecptPayment RPP = new frmRecptPayment();
            if (EDPComm.CheckMdiChild(RPP, parent))
                return;
            RPP.MdiParent = parent;
            RPP.Show();
        }
        private void showFDColl(Form parent)
        {
            //frmFdInstCollect FDCol = new frmFdInstCollect();
            //if (EDPComm.CheckMdiChild(FDCol, parent))
            //    return;
            //FDCol.MdiParent = parent;
            //FDCol.Show();
        }
        private void showVchr_Prnt(Form parent)
        {
            frmReportVoucher rptvchr = new frmReportVoucher();
            if (EDPComm.CheckMdiChild(rptvchr, parent))
                return;
            rptvchr.MdiParent = parent;
            rptvchr.Show();
        }
        private void showCopy_Acc(Form parent)
        {
            frmCopyAcc cpy_acc = new frmCopyAcc();
            if (EDPComm.CheckMdiChild(cpy_acc, parent))
                return;
            cpy_acc.MdiParent = parent;
            cpy_acc.Show();
        }
        private void showExchng_Mst(Form parent)
        {
            //Exch_Mst Ex = new Exch_Mst();
            frmMasters Ex = new frmMasters(3);
            if (EDPComm.CheckMdiChild(Ex, parent))
                return;
            Ex.MdiParent = parent;
            Ex.Show();
        }
        private void showGiftIN(Form parent)
        {
            //Of_Market of = new Of_Market("8G", "Off Market GiftIN");
            //if (EDPComm.CheckMdiChild(of, parent))
            //    return;
            //of.MdiParent = parent;
            //of.Show();
        }
        private void showGiftOUT(Form parent)
        {
            //Of_Market of = new Of_Market("9G", "Off Market GiftOUT");
            //if (EDPComm.CheckMdiChild(of, parent))
            //    return;
            //of.MdiParent = parent;
            //of.Show();
        }
        private void showStockIN(Form parent)
        {
            //Of_Market of = new Of_Market("8S", "Off Market StockIN");
            //if (EDPComm.CheckMdiChild(of, parent))
            //    return;
            //of.MdiParent = parent;
            //of.Show();
        }
        private void showStockOUT(Form parent)
        {
            //Of_Market of = new Of_Market("9S", "Off Market StockOUT");
            //if (EDPComm.CheckMdiChild(of, parent))
            //    return;
            //of.MdiParent = parent;
            //of.Show();
        }
        private void showConversion(Form parent)
        {
            //Conversion cnv = new Conversion();
            //frmPurchaseBill cnv = new frmPurchaseBill();
            //if (EDPComm.CheckMdiChild(cnv, parent))
            //    return;
            //cnv.MdiParent = parent;
            //cnv.Show();
        }
        private void showCashBook(Form parent)
        {
            FinanceReport.frmCashBook MCB = new FinanceReport.frmCashBook(1);
            if (EDPComm.CheckMdiChild(MCB, parent))
                return;
            MCB.MdiParent = parent;
            MCB.Show();
        }
        private void showBankBook(Form parent)
        {
            FinanceReport.frmCashBook MBB = new FinanceReport.frmCashBook(2);
            if (EDPComm.CheckMdiChild(MBB, parent))
                return;
            MBB.MdiParent = parent;
            MBB.Show();
        }
        private void showGeneralLedger(Form parent)
        {
            FinanceReport.frmCashBook MGL = new FinanceReport.frmCashBook(3);
            if (EDPComm.CheckMdiChild(MGL, parent))
                return;
            MGL.MdiParent = parent;
            MGL.Show();
        }
        //private void showCashBook(Form parent)
        //{
        //    //frmCashBook fcb = new frmCashBook();
        //    //fcb.MdiParent = parent;
        //    //fcb.Show();
        //}
        private void showToolBar(Form parent)
        {
            ToolsStng tls = new ToolsStng();
            if (EDPComm.CheckMdiChild(tls, parent))
                return;
            tls.MdiParent = parent;
            tls.Show();
        }
        private void showCompstEntry(Form parent)
        {
            try
            {
                //CompositeTran cmst = new CompositeTran();
                //CompositTran cmst = new CompositTran();
                //if (EDPComm.CheckMdiChild(cmst, parent))
                //    return;
                //cmst.MdiParent = parent;
                //cmst.Show();
            }
            catch { }
        }
        private void showSttQ(Form parent)
        {
            //STTQry sttq = new STTQry();
            //if (EDPComm.CheckMdiChild(sttq, parent))
            //    return;
            //sttq.MdiParent = parent;
            //sttq.Show();
        }
        private void showStkQryDPWise(Form parent)
        {
            //frmStkQry_DPwise sqdpw = new frmStkQry_DPwise();
            //if (EDPComm.CheckMdiChild(sqdpw, parent))
            //    return;
            //sqdpw.MdiParent = parent;
            //sqdpw.Show();
        }
        private void showEqListedReturnAtaGlance(Form parent)
        {
            //frmReturn_At_A_Glance_Equity ER = new frmReturn_At_A_Glance_Equity();
            //if (EDPComm.CheckMdiChild(ER, parent))
            //    return;
            //ER.MdiParent = parent;
            //ER.Show();
        }
        private void showJurnalQ(Form parent)
        {
            //frmJurnal frmJrn = new frmJurnal();
            //if (EDPComm.CheckMdiChild(frmJrn, parent))
            //    return;
            //frmJrn.MdiParent = parent;
            //frmJrn.Show();
        }
        private void showJurnal(Form parent)
        {
            frmRptJurnal MRJ = new frmRptJurnal();
            if (EDPComm.CheckMdiChild(MRJ, parent))
                return;
            MRJ.MdiParent = parent;
            MRJ.Show();
        }
        private void UserFormula(Form parent)
        {
            //frmUserFormula UF = new frmUserFormula();
            //if (EDPComm.CheckMdiChild(UF, parent))
            //    return;
            //UF.MdiParent = parent;
            //UF.Show();
        }
        private void GlbStckQry(Form parent)
        {
            //frmGlbStckQry glbstckqry = new frmGlbStckQry();
            //if (EDPComm.CheckMdiChild(glbstckqry, parent))
            //    return;
            //glbstckqry.MdiParent = parent;
            //glbstckqry.Show();
        }
        private void showPurRegQry(Form parent)
        {
            //frmPurchaseReg prreg = new frmPurchaseReg();
            //if (EDPComm.CheckMdiChild(prreg, parent))
            //    return;
            //prreg.MdiParent = parent;
            //prreg.Show();
        }
        private void showSlsRegQry(Form parent)
        {
            //frmSalesReg slsreg = new frmSalesReg();
            //if (EDPComm.CheckMdiChild(slsreg, parent))
            //    return;
            //slsreg.MdiParent = parent;
            //slsreg.Show();
        }
        private void showLngtSlsRegQry(Form parent)
        {
            //LngTrmRegQry shrt1 = new LngTrmRegQry("Investment");
            //if (EDPComm.CheckMdiChild(shrt1, parent))
            //    return;
            //shrt1.MdiParent = parent;
            //shrt1.Show();
        }
        private void showLngtSlsRegTradQry(Form parent)
        {
            //LngTrmRegQry shrt1 = new LngTrmRegQry("Trading");
            //if (EDPComm.CheckMdiChild(shrt1, parent))
            //    return;
            //shrt1.MdiParent = parent;
            //shrt1.Show();
        }
        private void showShrtSlsRegQry(Form parent)
        {
            //ShrtTrmSlsRegQry shrt = new ShrtTrmSlsRegQry("Investment");
            //if (EDPComm.CheckMdiChild(shrt, parent))
            //    return;
            //shrt.MdiParent = parent;
            //shrt.Show();
        }
        private void showShrtSlsRegTradQry(Form parent)
        {
            //ShrtTrmSlsRegQry shrt = new ShrtTrmSlsRegQry("Trading");
            //if (EDPComm.CheckMdiChild(shrt, parent))
            //    return;
            //shrt.MdiParent = parent;
            //shrt.Show();
        }
        private void showStckQry(Form parent)
        {
            //STCKSCRN stckscrrn = new STCKSCRN();
            //if (EDPComm.CheckMdiChild(stckscrrn, parent))
            //    return;
            //stckscrrn.MdiParent = parent;
            //stckscrrn.Show();
        }
        private void showCashBookQry(Form parent)
        {
            frmCashBankGen cbq = new frmCashBankGen(1);
            if (EDPComm.CheckMdiChild(cbq, parent))
                return;
            cbq.MdiParent = parent;
            cbq.Show();
        }
        private void showBankBookQry(Form parent)
        {
            frmCashBankGen cbq = new frmCashBankGen(2);
            if (EDPComm.CheckMdiChild(cbq, parent))
                return;
            cbq.MdiParent = parent;
            cbq.Show();
        }
        private void showGeneralLedgerQry(Form parent)
        {
            frmCashBankGen cbq = new frmCashBankGen(3);
            if (EDPComm.CheckMdiChild(cbq, parent))
                return;
            cbq.MdiParent = parent;
            cbq.Show();
        }
        private void showTrBlnc(Form parent)
        {
            //TrialBlncScrn tb = new TrialBlncScrn();
            //if (EDPComm.CheckMdiChild(tb, parent))
            //    return;
            //tb.MdiParent = parent;
            //tb.Show();
        }
        //private void showPurchaseReg(Form parent)
        //{

        //}
        private void showPurchaseReg(Form parent)
        {

            Investment_Report.SalePurchaseAnalysis salpur = new SalePurchaseAnalysis(2);

            if (EDPComm.CheckMdiChild(salpur, parent))
            {
                return;
            }
            salpur.MdiParent = parent;
            salpur.Show();

        }
        private void ShowSalesReg(Form parent)
        {
            Investment_Report.SalePurchaseAnalysis salpur = new SalePurchaseAnalysis(1);

            if (EDPComm.CheckMdiChild(salpur, parent))
            {
                return;
            }
            salpur.MdiParent = parent;
            salpur.Show();


            //Investment_Report.ShrtLngTrmCptGn SAR = new Investment_Report.ShrtLngTrmCptGn(3);
            //if (EDPComm.CheckMdiChild(SAR, parent))
            //    return;
            //SAR.MdiParent = parent;
            //SAR.Show();
        }

        private void showPL(Form parent)
        {
            //frmProfit_loss spl = new frmProfit_loss();
            FinanceReport.PeofitandLossReport spl = new FinanceReport.PeofitandLossReport();
            if (EDPComm.CheckMdiChild(spl, parent))
                return;
            spl.MdiParent = parent;
            spl.Show();
        }
        private void showStckVal(Form parent)
        {
            //string page = "CBill";
            //billrpt br = new billrpt();
            //br.Get(page);
            ////StockRpt sr = new StockRpt();
            //if (EDPComm.CheckMdiChild(br, parent))
            //    return;
            //br.MdiParent = parent;
            //br.Show();
        }

        private void showTrialBalance(Form parent)
        {
            //TrialBalance tb = new TrialBalance();
            //if (EDPComm.CheckMdiChild(tb, parent))
            //    return;
            //tb.MdiParent = parent;
            //tb.Show();
        }
        private void showInflt(Form parent)
        {
            //frmInflt frinf = new frmInflt();
            //if (EDPComm.CheckMdiChild(frinf, parent))
            //    return;
            //frinf.MdiParent = parent;
            //frinf.Show();
        }
        private void ShowBackup()
        {
            Utility.frmBackUp frmb = new frmBackUp();
            frmb.ShowDialog();
        }
        private void ShowRestore()
        {
            // string res = MessageBox.Show("Before Continue With Restore Process you have to Restart this Apllication.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            try
            {
                EDPMessage.Show("Before Continue With Restore Process you have to Restart this Apllication.", "Confirm", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
                if (EDPMessage.ButtonResult == "edpYES")
                {
                    EDPComm.RestoreMode = true;
                    Utility.frmRestore frmr = new frmRestore();
                    frmr.ShowDialog();
                    if (frmr.DialogResult == DialogResult.Cancel)
                        Environment.Exit(0);
                }
            }
            catch
            {
            }
        }
        private void showabout(Form parent)
        {
            About about = new About();
            if (EDPComm.CheckMdiChild(about, parent))
                return;
            about.ShowDialog();
        }
        private void ConfigShow(Form parent)
        {
            //frmConfigSystem frm_config = new frmConfigSystem();
            //if (EDPComm.CheckMdiChild(frm_config, parent))
            //    return;
            //frm_config.MdiParent = parent;
            //frm_config.Show();
        }
        private void ShowTaxConfig(Form parent)
        {
            //frmTaxConfig tx_cnfg = new frmTaxConfig();
            //if (EDPComm.CheckMdiChild(tx_cnfg, parent))
            //    return;
            //tx_cnfg.MdiParent = parent;
            //tx_cnfg.Show();
        }
        private void ShowTaxDetails(Form parent)
        {
            //frmTaxDetails frmTaxd = new frmTaxDetails();
            //if (EDPComm.CheckMdiChild(frmTaxd, parent))
            //    return;
            //frmTaxd.page_fill();
            //frmTaxd.MdiParent = parent;
            //frmTaxd.Show();
        }
        private void ShowTaxProfiles(Form parent)
        {
            //frmTaxDetails frmTaxp = new frmTaxDetails();
            //frmTaxp.page_fill();
            //frmTaxp.ShowDialog();
        }
        private void ShowSchoolMaster(Form parent)
        {
            //frmInvMst frmInv = new frmInvMst(0);
            //if (EDPComm.CheckMdiChild(frmInv, parent))
            //    return;
            ////frmInv.tab_open_function(2);
            //frmInv.MdiParent = parent;
            //frmInv.Show();

            Finance.frmBaseBrowse fi = new frmBaseBrowse();
            if (EDPComm.CheckMdiChild(fi, parent))
                return;
            EDPConn.Open();
            fi.value_pass(EDPComm.CurrentFicode, EDPComm.PCURRENT_GCODE, EDPConn.connectionstr, 1);
            fi.MdiParent = parent;
            fi.Show();
            EDPConn.Close();
        }

        private void ShowClassMaster(Form parent)
        {
            frmInvMst frmInv = new frmInvMst(1);
            if (EDPComm.CheckMdiChild(frmInv, parent))
                return;
            //frmInv.tab_open_function(2);
            frmInv.MdiParent = parent;
            frmInv.Show();
        }

        private void ShowSubjectMaster(Form parent)
        {
            frmInvMst frmInv = new frmInvMst(2);
            if (EDPComm.CheckMdiChild(frmInv, parent))
                return;
            //frmInv.tab_open_function(2);
            frmInv.MdiParent = parent;
            frmInv.Show();
        }

        private void ShowBookListMaster(Form parent)
        {
            frmInvMst frmInv = new frmInvMst(3);
            if (EDPComm.CheckMdiChild(frmInv, parent))
                return;
            //frmInv.tab_open_function(2);
            frmInv.MdiParent = parent;
            frmInv.Show();
        }

        private void ShowTransportMaster(Form parent)
        {
            frmInvMst frmInv = new frmInvMst(4);
            if (EDPComm.CheckMdiChild(frmInv, parent))
                return;
            //frmInv.tab_open_function(2);
            frmInv.MdiParent = parent;
            frmInv.Show();
        }

        private void ShowAgentTransportMaster(Form parent)
        {
            frmInvMst frmInv = new frmInvMst(5);
            if (EDPComm.CheckMdiChild(frmInv, parent))
                return;
            //frmInv.tab_open_function(2);
            frmInv.MdiParent = parent;
            frmInv.Show();
        }

        private void ShowSchoolTeacherMaster(Form parent)
        {
            frmInvMst frmInv = new frmInvMst(6);
            if (EDPComm.CheckMdiChild(frmInv, parent))
                return;
            //frmInv.tab_open_function(2);
            frmInv.MdiParent = parent;
            frmInv.Show();
        }

        private void ShowAreaMaster(Form parent)
        {
            frmInvMst frmInv = new frmInvMst(7);
            if (EDPComm.CheckMdiChild(frmInv, parent))
                return;
            //frmInv.tab_open_function(2);
            frmInv.MdiParent = parent;
            frmInv.Show();
        }

        private void ShowBranch(Form parent)
        {
            frmbranch fb = new frmbranch();            
            if (EDPComm.CheckMdiChild(fb, parent))
                return;
            fb.MdiParent = parent;
            if (parent.ActiveMdiChild == fb)
            {
                fb.Close();
                return;
            }
            fb.EditBranch();
            fb.Show();
        }
        private void ShowFinance(Form parent)
        {
            Finance.frmBaseBrowse fi = new frmBaseBrowse();
            if (EDPComm.CheckMdiChild(fi, parent))
                return;
            EDPConn.Open();
            fi.value_pass(EDPComm.CurrentFicode, EDPComm.PCURRENT_GCODE, EDPConn.connectionstr, 2);
            fi.MdiParent = parent;
            fi.Show();
            EDPConn.Close();
        }
       
        private void ShowEditComp(Form parent)
        {
            frmbranch br = new frmbranch();
            if (EDPComm.CheckMdiChild(br, parent))
                return;
            string gcode = EDPComm.PCURRENT_GCODE;
            DateTime sdate, edate, f_from, f_to;
            EDPConn.Open();
            mycmd = new SqlCommand("select CO_SDATE,CO_EDATE from company where GCODE='" + gcode + "'", EDPConn.mycon);
            da.SelectCommand = mycmd;
            da.Fill(DS, "coll_sdate_edate");
            EDPConn.Close();
            sdate = Convert.ToDateTime(DS.Tables["coll_sdate_edate"].Rows[0][0]);
            edate = Convert.ToDateTime(DS.Tables["coll_sdate_edate"].Rows[0][1]);
            DS.Tables["coll_sdate_edate"].Clear();
            EDPConn.Open();
            mycmd = new SqlCommand("select FREEZE_FROM,FREEZE_TO from branch where GCODE='" + gcode + "' and BRNCH_CODE='" + 1 + "'", EDPConn.mycon);
            da.SelectCommand = mycmd;
            da.Fill(DS, "coll_freeze");
            EDPConn.Close();
            if (Information.IsDBNull(DS.Tables["coll_freeze"].Rows[0][0]) == false)
                f_from = Convert.ToDateTime(DS.Tables["coll_freeze"].Rows[0][0]);
            else
                f_from = sdate;
            if (Information.IsDBNull(DS.Tables["coll_freeze"].Rows[0][1]) == false)
                f_to = Convert.ToDateTime(DS.Tables["coll_freeze"].Rows[0][1]);
            else
                f_to = edate;
            DS.Tables["coll_freeze"].Clear();

            bool bu = true;
            br.MdiParent = parent;
            br.RuntimeTab(bu, sdate, edate, f_from, f_to);  //passing boolean for creating runtime tab menu
            br.Show();
        }

        private void ShowDelComp(Form parent)
        {
            frmDelComp fd = new frmDelComp();
            fd.ShowDialog();            
        }

        private void ShowCurrency(Form parent)
        {
            frmCurrency fd = new frmCurrency();
           // frmAssetInformation fd = new frmAssetInformation();
            if (EDPComm.CheckMdiChild(fd, parent))
                return;
            fd.MdiParent = parent;
            fd.Show();
            //UnitMaster un = new UnitMaster();
            //un.MdiParent = parent;
            //un.Show();
        }        

        private void ShowVoucher(Form parent)
        {
            frmVch vch = new frmVch();
            if (EDPComm.CheckMdiChild(vch, parent))
                return;
            vch.MdiParent = parent;
            vch.Show();
        }
        private void ShowBillTerms(Form parent, string Type)
        {
            frmBillingTerms billt = new frmBillingTerms();
            if (Type == "S")
                billt.HeaderText = "Billing Terms For Sales";
            else
                billt.HeaderText = "Billing Terms For Purchase";
            if (EDPComm.CheckMdiChild(billt, parent))
                return;
            billt.MdiParent = parent;
            billt.Entry(Type);
            billt.Show();
        }
        private void ShowAcpost(Form parent)
        {
            frmAccountPosting Acpost = new frmAccountPosting();
            if (EDPComm.CheckMdiChild(Acpost, parent))
                return;
            Acpost.MdiParent = parent;
            Acpost.Show();
        }
        private void ShowApplicationSystem(Form parent)
        {
            frmAllotment Al = new frmAllotment();
            if (EDPComm.CheckMdiChild(Al, parent))
                return;
            Al.MdiParent = parent;
            Al.Show();
        }
        private void ShowLedgerSubgrp(Form parent)
        {
            Finance.frmBaseBrowse fi = new frmBaseBrowse();
            if (EDPComm.CheckMdiChild(fi, parent))
                return;
            EDPConn.Open();
            fi.value_pass(EDPComm.CurrentFicode, EDPComm.PCURRENT_GCODE, EDPConn.connectionstr, 1);
            fi.MdiParent = parent;
            fi.Show();
            EDPConn.Close();
        }
    }
}
