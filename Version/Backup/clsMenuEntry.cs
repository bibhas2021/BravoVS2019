using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace EDPVersion
{
    class clsMenuEntry
    {
        public void EnterIntomenu(SqlConnection con, DateTime Pbuilddate, DateTime Cbuilddate)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            if (Cbuilddate > Pbuilddate)
            {
                //if (edpcom.EnvironMent_Menu == "NewMenu")
                //    Entermenufirst1(con);
                //else
                    Entermenufirst(con);
            }
        }
        private void Entermenufirst(SqlConnection con)
        {
            try
            {
                string sql = " delete from menutable";
                sql = sql + " Insert into menutable values('10000000000','0','Company','Compnay Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('10010000000','10000000000','Install Company','Install Details',1,' ',' ',1)";
                sql = sql + " Insert into menutable values('10020000000','10000000000','Select Company','Select Details',1,' ',' ',1)";
                sql = sql + " Insert into menutable values('10030000000','10000000000','Edit Company','Edit Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('10040000000','10000000000','Delete Company','Delete Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('10050000000','10000000000','Branch Entry','Branch Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('10060000000','10000000000','Currency Details','Currency Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('10060100000','10060000000','Define Currency','Define Currency',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('10070000000','10000000000','Admin','Admin',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('10070100000','10070000000','User Login','User Login',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('10080000000','10000000000','Exit','Exit',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('20000000000','0','Entry','Entry',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('20010000000','20000000000','Accounts','Accounts',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20010100000','20010000000','Sub Groups','Sub Groups',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20010200000','20010000000','Ledger A/C','Ledger A/C',1,' ','F2',0)";
                sql = sql + " Insert into menutable values('20010300000','20010000000','Documents Entry','Documents Entry',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20010301000','20010300000','Voucher','Voucher',1,' ','F4',0)";
                sql = sql + " Insert into menutable values('20010302000','20010300000','BRS Entry','BRS Entry',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20010303000','20010300000','Images','Images',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20010304000','20010300000','Allocation','Allocation',1,' ','Ctrl+L',0)";
                sql = sql + " Insert into menutable values('20010305000','20010300000','Forms','Forms',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20010306000','20010300000','Waybill','Waybill',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20010400000','20010000000','Stock In Hand','Stock In Hand',1,' ','Ctrl+H',0)";
                sql = sql + " Insert into menutable values('20010500000','20010000000','Last Year Balance','Last Year Balance',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20010600000','20010000000','FBT Ledger','FBT Ledger',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20010700000','20010000000','VAT Grouping','VAT Grouping',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20010701000','20010700000','VAT Group Master','VAT Group Master',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20010702000','20010700000','VAT Item Group Relation','VAT Item Group Relation',1,' ',' ',0)";


                //sql = sql + " Insert into menutable values('20020000000','20000000000','Inventory','Inventory',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('20020100000','20020000000','Item / Product','Item / Product',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('20020101000','20020100000','Description','Description',1,' ','F7',0)";
                //sql = sql + " Insert into menutable values('20020102000','20020100000','Rate','Rate',1,' ','Ctrl+R',0)";
                //sql = sql + " Insert into menutable values('20020103000','20020100000','Tax / VAT','Tax / VAT',1,' ','Ctrl+E',0)";
                //sql = sql + " Insert into menutable values('20020104000','20020100000','Fixed / Market Cast','Fixed / Market Cast',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('20020000000','20000000000','Inventory','Inventory',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020100000','20020000000','Item / Product','Item / Product',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020101000','20020100000','Description','Description',1,' ','F7',0)";
                sql = sql + " Insert into menutable values('20020102000','20020100000','Tax / VAT','Tax / VAT',1,' ','Ctrl+E',0)";
                sql = sql + " Insert into menutable values('20020103000','20020100000','MRP Rate Update','MRPRateUpdate',1,' ','Ctrl+R',0)";
                sql = sql + " Insert into menutable values('20020104000','20020100000','Sale Rate Update','SaleRateUpdate',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020105000','20020100000','Fixed Rate','FixedRate',1,' ',' ',0)";

                //sql = sql + " Insert into menutable values('20020200000','20020000000','Unit','Unit',1,' ',' ',0)";
                ////sql = sql + " Insert into menutable values('20020201000','20020200000','Details','Details',1,' ',' ',0)";
                ////sql = sql + " Insert into menutable values('20020202000','20020200000','Relation','Relation',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('20020201000','20020200000','Create Unit','CreateUnit',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('20020202000','20020200000','Unit Series','UnitSeries',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('20020203000','20020200000','Unit Relation','UnitRelation',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('20020200000','20020000000','Unit','Unit',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020201000','20020200000','Create Unit','CreateUnit',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020202000','20020200000','Unit Series','UnitSeries',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020203000','20020200000','Unit Relation','UnitRelation',1,' ',' ',0)";


                sql = sql + " Insert into menutable values('20020300000','20020000000','Trading','Trading',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020301000','20020300000','Sales','Sales',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020301010','20020301000','Sales Order','SalesOrder',1,' ','',0)";
                sql = sql + " Insert into menutable values('20020301020','20020301000','Sales Challan/DNote','Sales Challon/DNote',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020301030','20020301000','Sales Invoice','Sales Invoice',1,' ','F5',0)";
                sql = sql + " Insert into menutable values('20020301040','20020301000','Sales Return','Sales Return',1,' ','',0)";
                sql = sql + " Insert into menutable values('20020302000','20020300000','Purchase','Purchase',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020302010','20020302000','Purchase Order','Purchase',1,' ','',0)";
                sql = sql + " Insert into menutable values('20020302020','20020302000','Purchase Challan/DNote','Challan/DNote',1,' ','',0)";
                sql = sql + " Insert into menutable values('20020302030','20020302000','Purchase Invoice','Purchase Invoice',1,' ','F8',0)";
                sql = sql + " Insert into menutable values('20020302040','20020302000','Purchase Return','Purchase Return',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020303000','20020300000','Stock Transfer','Stock Transfer',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('20020400000','20020000000','Manufacturing','Manufacturing',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020401000','20020400000','Mfg Vouchers','Mfg Vouchers',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020402000','20020400000','Production','Production',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020402010','20020402000','Log','Log',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020402020','20020402000','Formula','Formula',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020403000','20020400000','Physical Stock','Physical Stock',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('20020500000','20020000000','Stock In / Out','Stock In / Out',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020501000','20020500000','Stock In','Stock In',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20020502000','20020500000','Stock Out','Stock Out',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('20030000000','20000000000','Vectors','Vectors',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20030100000','20030000000','Vector Config','Vector Config',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20030200000','20030000000','Vector Master','Vector Master',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20030201000','20030200000','Cost Centre','Cost Centre',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('20040000000','20000000000','Registery','Registery',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('20040100000','20040000000','Reg Description','Reg Description',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('30000000000','0','Query','Query',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010000000','30000000000','Accounts(Q)','Accounts(Q)',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010100000','30010000000','Accounts Book','Accounts Book',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010101000','30010100000','Ledger (Q)','Ledger (Q)',1,' ','Ctrl+F2',0)";

                sql = sql + " Insert into menutable values('30010102000','30010100000','Cash Book(Q)','Cash Book(Q)',1,' ','',0)";
                sql = sql + " Insert into menutable values('30010103000','30010100000','Bank Book(Q)','Bank Book(Q)',1,' ','',0)";
                sql = sql + " Insert into menutable values('30010104000','30010100000','Journal(Q)','Journal(Q)',1,' ','',0)";

                sql = sql + " Insert into menutable values('30010105000','30010100000','Account Details','Account Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010106000','30010100000','Party Details','Party Details',1,' ','Ctrl+P',0)";
                sql = sql + " Insert into menutable values('30010107000','30010100000','Outstanding','Outstanding',1,' ','Ctrl+O',0)";
                sql = sql + " Insert into menutable values('30010108000','30010100000','Opening Balance','Opening Balance',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010109000','30010100000','Audit Check','Audit Check',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010110000','30010100000','Narration/Cheque Wise Search','Narration/Cheque Wise Search',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('30010200000','30010000000','Final Accounts','FinalAccounts',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010201000','30010200000','Trail Balance Ctrl+T','TrailBalance',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010202000','30010200000','Balance Sheet Ctrl+T','BalanceSheet',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010300000','30010000000','Budget Ctrl+T ','Budget',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010400000','30010000000','Transaction (Q)','Transaction (Q)',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('30010500000','30010000000','Maintainance','Maintainance',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010501000','30010500000','Main Groups','Main Groups',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010502000','30010500000','Sub Group','Sub Group',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30010503000','30010500000','Vat Statutory Master','VatStatutoryMaster',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('30020000000','30000000000','Inventory(Q)','Inventory(Q)',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30020100000','30020000000','Locatoin','Locatoin',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30020200000','30020000000','Items/Products','Items/Products',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30020201000','30020200000','Details Ctrl+F7','Details Ctrl+F7',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30020202000','30020200000','Valuation and Rate','Valuation and Rate',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30020203000','30020200000','Adv Maintainance','Adv Maintainance',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30020300000','30020000000','Order Analysis','orderAnalysis',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30020400000','30020000000','Dnote Analysis','DnoteAnalysis',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('30030000000','30000000000','Vector','Vector',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30030100000','30030000000','Vector details','Vectordetails',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30030200000','30030000000','Product Closing Analysis','ProductClosingAnalysis',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30040000000','30000000000','Custom Field Ctrl+F6','Vector',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('30050000000','30000000000','Mismatch in item Bal','MismatchinitemBal',1,' ',' ',0)";

                //Reports                                
                sql = sql + " Insert into menutable values('40000000000','0','Reports','Reports',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010000000','40000000000','Account(R) ','Account(R)',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010100000','40010000000','Account Books ','Account Books',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010101000','40010100000','Ledger ','Ledger',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010101010','40010101000','Normal ','Normal',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010102000','40010100000','Cash Book ','Cash Book',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010103000','40010100000','Bank Book ','BankBook',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010104000','40010100000','Sales ','Sales',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010105000','40010100000','Purchases ','Purchases',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010106000','40010100000','Journal ','Journal',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010107000','40010100000','Debit Note ','DebitNote',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010108000','40010100000','Credit Note ','CreditNote',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010109000','40010100000','Receipt/Payment ','Receipt/Payment',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010110000','40010100000','FBT Report ','FBT Report',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010200000','40010000000','Account Documents ','AccountDocuments',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010201000','40010200000','Invoice Ctrl+I','Invoice',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010202000','40010200000','Voucher(R) Ctrl+Z ','Voucher(R)',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010203000','40010200000','Tax Invoice Ctrl+Alt+Z ','AccountDocuments',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010204000','40010200000','A/C Statement','A/C Statement',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010205000','40010200000','Money Receipt','MoneyReceipt',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010300000','40010000000','Final Account','Final Account',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010301000','40010300000','Trial Balance','TrialBalance',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010302000','40010300000','Profit/Loss A/C','Profit/Loss A/C',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010303000','40010300000','Balance Sheet','Balance Sheet',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010304000','40010300000','Group Summary','Group Summary',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010305000','40010300000','Monthly P/L A/C','Monthly P/L A/C',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010306000','40010300000','Monthly Trial Balance','MonthlyTrialBalance',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010307000','40010300000','Income and Expenditure','ncome and Expenditure',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010308000','40010300000','Manufacturing and Trading A/C','Manufacturing and Trading A/C',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010309000','40010300000','Final Account Rpt.','Final Account Rpt',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('40010310000','40010300000','Final Account','Final Account',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010400000','40010000000','MIS ','MIS',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010401000','40010400000','Input/Output Tax','Input/Output Tax',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010402000','40010400000','Vat Computation','Vat Computation',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010403000','40010400000','Ageing','Ageing',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010403010','40010403000','Payable','Payable',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010403020','40010403000','Receivable','Receivable',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010404000','40010400000','Analysis','Analysis',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010404010','40010404000','Broker','Broker',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010404020','40010404000','PartyWise','PartyWise',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010404030','40010404000','Transaction (R)','Transaction (R)',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010404040','40010404000','Partywise Vat','Partywise Vat',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010405000','40010400000','Budgets','Budgets',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010406000','40010400000','Cashflow','Cashflow',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010407000','40010400000','FundsFlow','FundsFlow',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010408000','40010400000','Forms','Forms',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010408010','40010408000','Forms Due','Forms Due',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010408020','40010408000','Forms Analysis','Forms Analysis',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010409000','40010400000','Interest Collection','Interest Collection',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010410000','40010400000','Out Standing','Out Standing',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010410100','40010410000','Out Standing Payable','Out Standing Payable',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010410200','40010410000','Out Standing Receivable','Out Standing Receivable',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010411000','40010400000','Ratio','Ratio',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010411010','40010411000','Status','Status',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010411020','40010411000','Periodical','Periodical',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010412000','40010400000','Depreciation','Depreciation',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010412010','40010412000','Depreciation Chart','Depreciation Chart',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010412020','40010412000','Fixed Asset Register','Fixed Asset Register',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010413000','40010400000','WayBillRegister','WayBillRegister',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010414000','40010400000','OP. DOC. Register','OP. DOC. Register',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010415000','40010400000','Missing Srl Nos','Missing Srl Nos',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010416000','40010400000','PDC ','PDC',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010416010','40010416000','A/C Statement','A/C Statement',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010416020','40010416000','Payable Ageing','Payable Ageing',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010416030','40010416000','Receivable Ageing','Receivable Ageing',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010416040','40010416000','Payable Outstanding','Payable Outstanding',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010416050','40010416000','Receivable Outstanding','Receivable Outstanding',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010416060','40010416000','PDC Register','PDC Register',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010417000','40010400000','Payment Advice','Payment Advice',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010418000','40010400000','TDS','TDS',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010418010','40010418000','TDS Certificate','TDS Certificate',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010418020','40010418000','TDS Allocation','TDS Allocation',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010419000','40010400000','Vat Analysis','Vat Analysis',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010420000','40010400000','Form 14 Annexure B','Form 14 Annexure B',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010421000','40010400000','Documents','Documents',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010422010','40010421000','Conformation A/CS ','Conformation A/CS',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40010500000','40010000000','Check List ','CheckList',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010501000','40010500000','Audit Check','Audit Check',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010502000','40010500000','Ledger','Ledger',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010503000','40010500000','Transactions','Transactions',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010504000','40010500000','Predifind Groups','Predifind',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40010505000','40010500000','Audit Trail','Audit Trail',1,' ',' ',0)";

                // Report Inventory

                sql = sql + " Insert into menutable values('40020000000','40000000000','Inventory(R)','Inventory(R)',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020100000','40020000000','Documents Inventory(R)','Documents Inventory(R)',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020101000','40020100000','Trading Rpt','Trading Rpt',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40020101010','40020101000','Stock Out Rpt','Stock Out Rpt',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020101020','40020101000','Challan Rpt','Challan Rpt',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('40020101030','40020101000','Order','Order',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('40020101040','40020101000','D Note','D Note',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40020102000','40020100000','Manufacturing Rpt','Manufacturing Rpt',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020102010','40020102000','Voucher Rpt','Voucher Rpt',1,' ',' ',0)";

                //sql = sql + " Insert into menutable values('40020100000','40020000000','Documents','Documents',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('40020100000','40020000000','Documents','Documents',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('40020100000','40020000000','Documents','Documents',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40020200000','40020000000','Stock Reports','Stock Reports',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020201000','40020200000','Stock Reports Status','Stock Reports Status',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020201010','40020201000','Status Standard','Standard',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020201020','40020201000','Status Advance','StatusAdvance',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020202000','40020200000','Statement','Statement',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020203000','40020200000','Ledger','Ledger',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020204000','40020200000','Valuation','Valuation',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020204010','40020204000','Standard','Standard',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020204020','40020204000','Monthly','Monthly',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020205000','40020200000','Classification','Classification',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020206000','40020200000','Batch Reports','Batch Reports',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40020206010','40020206000','Status','Status',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020207000','40020200000','GroupWise','GroupWise',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020207010','40020207000','Statement','Statement',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40020300000','40020000000','Register','Register',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020400000','40020000000','MIS','MIS',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40020500000','40020000000','Checklist','Checklist',1,' ',' ',0)";
                //////////////////////////////////                
                sql = sql + " Insert into menutable values('40030000000','40000000000','Vector(R)','Vector(R)',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40030100000','40030000000','Register(V)','Register(V)',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40030101000','40030100000','Vector Register','VectorRegister',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40030102000','40030100000','Ledger Vector Register','Ledger Vector Register',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40030103000','40030100000','Vector Sale Register','Vector Sale Register',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40030104000','40030100000','Vector Purchase','Vector Purchase',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40030200000','40030000000','Relation(V)','Relation(V)',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40030201000','40030200000','Inter Vector Relation','Inter Vector Relation',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40030202000','40030200000','Vector Ledger Relation','Vector Ledger Relation',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40030203000','40030200000','Vector Type_Ledger Relation','Vector Type_Ledger Relation',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40030300000','40030000000','MIS(V)','MIS(V)',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40030301000','40030300000','Vector Trail','VectorTrail',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40030302000','40030300000','Unallocated Vector','UnallocatedVector',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40030303000','40030300000','Trail Balance with vector','Trail Balance with vector',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40030304000','40030300000','P/L with Vector','P/L with Vector',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40030400000','40030000000','CheckList','CheckList',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('40040000000','40000000000','Custom Field','Custom Field',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('40040100000','40040000000','CheckList','CheckList',1,' ',' ',0)";

                //Utility

                sql = sql + " Insert into menutable values('50000000000','0','Utility','Utility',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50010000000','50000000000','Rebuild','Rebuild',1,' ','F10',0)";
                sql = sql + " Insert into menutable values('50020000000','50000000000','Advanced Rebuild','Advanced Rebuild',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50030000000','50000000000','Recalculate','Recalculate',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50040000000','50000000000','Diagnostic','Diagnostic',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50050000000','50000000000','Renumber','Renumber',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50060000000','50000000000','Padding','Padding',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50070000000','50000000000','Delete Document','Delete Document',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50070100000','50070000000','Current Document','CurrentDocument',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50070200000','50070000000','Opening Document','Opening Document',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('50080000000','50000000000','Diagnostic Analysis','Diagnostic Analysis',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50090000000','50000000000','Audit Trail(U)','Audit Trail(U)',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50100000000','50000000000','Copy Master','Copy Master',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50110000000','50000000000','ServerSpeedUp','ServerSpeedUp',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50120000000','50000000000','Import Balances','Import Balances',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50130000000','50000000000','BackUp of data','BackUp of data',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50140000000','50000000000','Restoration of Data','RestorationofData',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('50140100000','50140000000','Branch Wise','Branch Wise',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50140200000','50140000000','Normal','Normal',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('50150000000','50000000000','Merge Item','MergeItem',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50160000000','50000000000','Consolidation','Consolidation',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('50160100000','50160000000','Location','Location',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50160200000','50160000000','Item Groups','Item Groups',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50160300000','50160000000','Account Groups','AccountGroups',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('50170000000','50000000000','Predefined Narration','Predefined Narration',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50180000000','50000000000','Document Statistics','Document Statistics',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50190000000','50000000000','Configuration F10','Configuration',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50200000000','50000000000','User Login F12','User Login F12',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50210000000','50000000000','Maintenance','Maintenance',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50211000000','50210000000','Accounts Maintenance','Accounts Maintenance',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50211010000','50211000000','Main Group Maintenance','Main Group Maintenance',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50211020000','50211000000','Sub Group Maintenance','Sub Group Maintenance',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('50211030000','50211000000','Ledger Maintenance','Ledger Maintenance',1,' ',' ',0)";


                //Tools.......................
                sql = sql + " Insert into menutable values('60000000000','0','Tools','Tools',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('60010000000','60000000000','Monitor','Monitor',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60020000000','60000000000','User Log','User Log',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60030000000','60000000000','Float on Top','Float on Top',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60040000000','60000000000','Notepad','Notepad',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('6005000000','60000000000','Calender','Calender',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60060000000','60000000000','Report Font','Report Font',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60070000000','60000000000','Printer Setup','Printer Setup',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60080000000','60000000000','Preview Saved Report','Preview Saved Report',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60090000000','60000000000','Accord Date Format','Accord Date Format',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60100000000','60000000000','Migrate from DosAccord','Migrate from DosAccord',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60110000000','60000000000','Consolidate  Companies','Consolidate  Companies',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60120000000','60000000000','Import Data','Import Data',1,' ',' ',0)";


                sql = sql + " Insert into menutable values('60120100000','60120000000','Accord Invoice Import','Accord Invoice Import',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60120200000','60120000000','Item Import','Item Import',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60120300000','60120000000','Ledger Import','LedgerImport',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60120400000','60120000000','Voucher Import from Excel','VoucherImportfromExcel',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60120500000','60120000000','Voucher Import','Voucher Import',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60120600000','60120000000','Manufacturing Voucher Import','Manufacturing Voucher Import',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60120700000','60120000000','Order Import from Excell','OrderImportfromExcell',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60120800000','60120000000','Order Import from Text','Order Import from Text',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60120900000','60120000000','Invoice Import from Excell','InvoiceImportfromExcell',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60121000000','60120000000','Price List import from Excell','Price List import from Excell',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60121100000','60120000000','Locationwise item  import Excell','LocationwiseitemimportExcell',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('60130000000','60000000000','Export Data','Export Data',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('60130100000','60130000000','Accord Invoice Export','Accord Invoice Export',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60130200000','60130000000','Accord Voucher Export','Accord Voucher Export',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('60130300000','60130000000','Manufacturing Voucher Export','Manufacturing Voucher Export',1,' ',' ',0)";

                sql = sql + " Insert into menutable values('60140000000','60000000000','Send Diagnostics Error report to EDPSOFT','Send Diagnostics Error report to EDPSOFT',1,' ',' ',0)";

                //sql = sql + " Insert into menutable values('70000000000','0','Utilityyyy','Utilityyy',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('70010000000','70000000000','Send Mail','Send Mail',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('70020000000','70000000000','Backup','Backup',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('70030000000','70000000000','Restore','Restore',1,' ',' ',0)";
                //sql = sql + " Insert into menutable values('70000000000','0','Global Aspect','Global Aspect',1,' ',' ',0)";                

                sql = sql + " Insert into menutable values('71000000000','0','Help','Help',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('71010000000','71000000000','Topics','Topics',1,' ',' ',0)";
                sql = sql + " Insert into menutable values('71020000000','71000000000','About AccordFour !.....','About AccordFour',1,' ',' ',0)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
        }


        private void Entermenufirst1(SqlConnection con)
        {
            try
            {
                string sql = " delete from menutable_New";
                sql = sql + " Insert into menutable_New values('10000000000','0','Company','Compnay Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('10010000000','10000000000','Install Company','Install Details',1,' ',' ',1)";
                sql = sql + " Insert into menutable_New values('10020000000','10000000000','Select Company','Select Details',1,' ',' ',1)";
                sql = sql + " Insert into menutable_New values('10030000000','10000000000','Edit Company','Edit Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('10040000000','10000000000','Delete Company','Delete Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('10050000000','10000000000','Branch Entry','Branch Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('10060000000','10000000000','Currency Details','Currency Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('10070000000','10000000000','User Login Details','User Login Details',1,' ',' ',0)";



                sql = sql + " Insert into menutable_New values('20000000000','0','Entry','Entry',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('20010000000','20000000000','Accounts','Accounts',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20010100000','20010000000','Ledger A/C','Ledger A/C',1,' ','F2',0)";
                sql = sql + " Insert into menutable_New values('20010200000','20010000000','Sub Groups','SubGroups',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20010300000','20010000000','Voucher','Voucher',1,' ','F4',0)";               
                sql = sql + " Insert into menutable_New values('20010400000','20010000000','Document/Entry','Document/Entry',1,' ',' ',0)";
               
                sql = sql + " Insert into menutable_New values('20010301000','20010400000','BRS Entry','BRSEntry',1,' ',' ',0)";               
                sql = sql + " Insert into menutable_New values('20010302000','20010300000','Allocation','Allocation',1,' ','Ctrl+L',0)";

                sql = sql + " Insert into menutable_New values('20010500000','20010000000','VAT Grouping','VATGrouping',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20010701000','20010500000','VAT Group Master','VATGroupMaster',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20010702000','20010500000','VAT Item Group Relation','VATItemGroupRelation',1,' ',' ',0)";


                sql = sql + " Insert into menutable_New values('20020000000','20000000000','Trading','Trading',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20020100000','20020000000','Sales','Sales',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20020101000','20020100000','Sales Invoice','SalesInvoice',1,' ','F5',0)";
                sql = sql + " Insert into menutable_New values('20020202000','20020100000','Sales Return','SalesReturn',1,' ','',0)";
                sql = sql + " Insert into menutable_New values('20020303000','20020100000','Sales Order','SalesOrder',1,' ','',0)";
                sql = sql + " Insert into menutable_New values('20020404000','20020100000','Sales Challan/DNote','SalesChallon/DNote',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('20020200000','20020000000','Purchase','Purchase',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20020201000','20020200000','Purchase Invoice','PurchaseInvoice',1,' ','F8',0)";
                sql = sql + " Insert into menutable_New values('20020202000','20020200000','Purchase Return','PurchaseReturn',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20020203000','20020200000','Purchase Indent','PurchaseIndent',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20020204000','20020200000','Purchase Order','Purchase',1,' ','',0)";
                sql = sql + " Insert into menutable_New values('20020205000','20020200000','Purchase GRN','PurchaseGRN',1,' ','',0)";

                sql = sql + " Insert into menutable_New values('20030000000','20000000000','Inventory','Inventory',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030100000','20030000000','Item / Product','Item/Product',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030101000','20030100000','Add New Product','AddNewProduct',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030102000','20030100000','Edit Product','EditProduct',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030103000','20030100000','Product Master','ProductMaster',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030104000','20030100000','Sale Rate Update','SaleRateUpdate',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('20030200000','20030000000','Unit','Unit',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030201000','20030200000','Create Unit','CreateUnit',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030202000','20030200000','Edit Unit','EditUnit',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030203000','20030200000','Unit Series','UnitSeries',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030204000','20030200000','Unit Relation','UnitRelation',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('20030300000','20030000000','Stock In/Out','StockIn/Out',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030301000','20030300000','Stock In','StockIn',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030302000','20030300000','Stock Out','StockOut',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('20030400000','20030000000','Manufacturing','Manufacturing',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030401000','20030400000','Manufacturing Vouchers','ManufacturingVouchers',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030402000','20030400000','Production Formula','ProductionFormula',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030403000','20030400000','Production Log','ProductionLog',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('20040000000','20000000000','Vectors','Vectors',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20040100000','20040000000','Vectors Configaration','VectorsConfigaration',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20040200000','20040000000','Vectors Master','VectorsMaster',1,' ',' ',0)";


                sql = sql + " Insert into menutable_New values('30000000000','0','Query','Query',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30010000000','30000000000','General','General',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30010100000','30010000000','Transactions','Transactions',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30010200000','30010000000','Outstanding','Outstanding',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30010300000','30010000000','Party Details','PartyDetails',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('30020000000','30000000000','Accounts(Q)','Accounts',1,' ','',0)";
                sql = sql + " Insert into menutable_New values('30020100000','30020000000','Accounts Books','AccountsBooks',1,' ','',0)";
                sql = sql + " Insert into menutable_New values('30020101000','30020100000','Ledger','Journal(Q)',1,' ','',0)";
                sql = sql + " Insert into menutable_New values('30020102000','30020100000','Cash Book','CashBook',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30020103000','30020100000','Bank Book','BankBook',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30020104000','30020100000','Journal','Journal',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('30020200000','30020000000','Final Accounts','FinalAccounts',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30020201000','30020200000','Trail Balance Ctrl+T','TrailBalance',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30020202000','30020200000','Balance Sheet Ctrl+T','BalanceSheet',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30020203000','30020200000','P&L Account','P&LAccount',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('30030000000','30000000000','Inventory(Q)','Inventory',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30030100000','30030000000','Items/Products','Items/Products',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30030101000','30030100000','Details','Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30030102000','30030100000','Locatoin','Locatoin',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30030103000','30030100000','Valuation & Rate','Valuation&Rate',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('30030200000','30030000000','Stock Statemrnt','StockStatemrnt',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('30040000000','30000000000','Vector','Vector',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30040100000','30040000000','Vector Details','VectorDetails',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30040200000','30040000000','Product Closing Analysis','ProductClosingAnalysis',1,' ',' ',0)";


                sql = sql + " Insert into menutable_New values('40000000000','0','Reports','Reports',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010000000','40000000000','Account(R)','Account',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010100000','40010000000','Documents','Documents',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010101000','40010100000','Sales ','Sales',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010102000','40010100000','Purchase ','Purchase',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010103000','40010100000','Voucher ','Voucher',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010104000','40010100000','Receipt/Payment ','Receipt/Payment',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010105000','40010100000','Debit Note ','DebitNote ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010106000','40010100000','Credit Note ','CreditNote ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010107000','40010100000','Tax Invoice ','TaxInvoice ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010108000','40010100000','BRS Report ','BRSReport ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010109000','40010100000','Group Summary ','GroupSummary',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010110000','40010100000','Cheque Printing ','ChequePrinting',1,' ',' ',0)";


                sql = sql + " Insert into menutable_New values('40010200000','40010000000','MIS Report ','MISReport ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010201000','40010200000','Ageging','Ageging',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010202000','40010200000','Analysis','Analysis',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010203000','40010200000','Forms','Forms',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010204000','40010200000','Budgets ','Budgets',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010205000','40010200000','Cash Flow','CashFlow',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010206000','40010200000','Tax Register','TaxRegister',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010207000','40010200000','Vat Computation','Vat Computation',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010208000','40010200000','Vat Analysis','VatAnalysis',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010209000','40010200000','State_Wise VAT ','State_Wise_VAT',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010210000','40010200000','Outstanding Letter Bills','Outstanding_Letter_Bills',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40010300000','40010000000','Checklist','Checklist ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010301000','40010300000','Ledger','Ledger',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010302000','40010300000','Party Checklist','Party_Checklist',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010303000','40010300000','Audit Check','AuditCheck',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40020000000','40000000000','Inventory(R)','Inventory',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020100000','40020000000','Documents','Documents ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020101000','40020100000','Trading Reports','TradingReports',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020102000','40020100000','Manufacturing Report','ManufacturingReport',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40020200000','40020000000','Stock Reports','StockReports ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020201000','40020200000','Stock Status','StockStatus ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020202000','40020200000','D-Note','D-Note',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020203000','40020200000','Unbilled D-Note','UnbilledD-Note',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40020300000','40020000000','MIS Reports','MISReports ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020301000','40020300000','Product Wise Analysis','ProductWiseAnalysis ',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40030000000','40000000000','Vector(R)','Vector',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030100000','40030000000','Register','Register ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030101000','40030100000','Vector Register','VectorRegister',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030102000','40030100000','Ledger Vector Register ','LedgerVectorRegister',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030103000','40030100000','Vector Sales Register','VectorSalesRegister',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030104000','40030100000','Vector Purchase ','VectorPurchase ',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40030200000','40030000000','Relation','Relation ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030201000','40030200000','Inter Vector Relation','InterVectorRelation',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030202000','40030200000','Vector Ledger Relation','VectorLedgerRelation',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030203000','40030200000','Vector Type_Ledger Relation','VectorType_LedgerRelation',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40030300000','40030000000','MIS','MIS ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030301000','40030300000','Vector Trail','Vector Trail',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030302000','40030300000','Unallocated Vector','UnallocatedVector',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030303000','40030300000','Trail Blance With Vector','TrailBlanceWithVector',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030304000','40030300000','P/L With Vector','P/L With Vector',1,' ',' ',0)";



                sql = sql + " Insert into menutable_New values('50000000000','0','Utility','Utility',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50010000000','50000000000','Transaction Trail','Transaction Trail',1,' ','F10',0)";
                sql = sql + " Insert into menutable_New values('50020000000','50000000000','Delet Document','DeletDocument',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50030000000','50000000000','Copy Master','CopyMaster',1,' ',' ',0)";


                sql = sql + " Insert into menutable_New values('50040000000','50000000000','Import Balance','ImportBalance',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50040100000','50040000000','Account Import','AccountImport',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50040200000','50040000000','Stock Import','StockImport',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('50050000000','50000000000','Maintanance','Maintanance',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50050100000','50050000000','Main Group Maintanance','MainGroupMaintanance',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50050200000','50050000000','Sub Group Maintanance','SubGroupMaintanance',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50050300000','50050000000','Ledger Maintanance','LedgerMaintanance',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('50060000000','50000000000','Rebuild','Rebuild',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50070000000','50000000000','Advance Rebuild','AdvanceRebuild',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50080000000','50000000000','Diagnostics','Diagnostics',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50090000000','50000000000','Renumber','Renumber',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50100000000','50000000000','Set Cheque Position','SetChequePosition',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50110000000','50000000000','User Log','UserLog',1,' ',' ',0)";


                sql = sql + " Insert into menutable_New values('60000000000','0','Tools','Tools',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60010000000','60000000000','Import Data','ImportData',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60010100000','60010000000','Item Import','ItemImport',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60010200000','60010000000','Ledger Import','LedgerImport',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60020000000','60000000000','Dat Back Up','DatBackUp',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60020100000','60020000000','Normal Back Up','NormalBackUp',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60020200000','60020000000','Financial Year Back Up','FinancialYearBack Up',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60030000000','60000000000','Data Restoration','Data Restoration',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60030100000','60030000000','Normal Restoration','NormalRestoration',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60030200000','60030000000','Financial Year Restoration','FinancialYearRestoration',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60040000000','60000000000','Data Statistics','Data Statistics',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60050000000','60000000000','Settings and configuration','Settingsandconfiguration',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60050100000','60050000000','Documents Numbering and A/C Posting Setup','DocumentsNumberingandA/CPostingSetup',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60050200000','60050000000','Configuration','Configuration',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60050300000','60050000000','Setting Hotkeys','SettingHotkeys',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60060000000','60000000000','Migration','Migration',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60060100000','60060000000','From Dos Accord','FromDosAccord',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60060200000','60060000000','From Win Accord','FromWinAccord',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60070000000','60000000000','Re_User Login','Re_UserLogin',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60080000000','60000000000','User Details','UserDetails',1,' ',' ',0)";
               
            }
            catch { }
        }
    }
}
