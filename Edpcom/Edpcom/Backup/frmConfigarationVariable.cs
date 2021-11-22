using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using EDPMessageBox;

namespace Edpcom
{
    public class frmConfigarationVariable
    {
        #region Cofigaration Variable

        public static bool LEGACY_ALLOWED = true;
        public static DateTime ReceiptDate;
        public static string Action;

        public static bool SHOWOPENINGSCREEN_ON = false;
        public static bool NOMINATE_ON = false;
        public static bool MULTICURRENCY_ON = false ;
        public static bool PORTFOLIO_ON = false ;

        public static bool EQLISTED_ON = false;
        public static bool EQUNLISTED_ON = false;
        public static bool DEBENTURES_ON = false;
        public static bool DERIVATIVE_FUTURES_ON = false;
        public static bool DERIVATIVE_OPTION_ON = false;
        public static bool FIXED_DEPOSITS_ON = false;
        public static bool MUTUALFUND_ON = false;
        public static bool BONDS_ON = false;
        public static bool TBILLS_GOVT_SECURITY_ON = false;
        public static bool COMMODITYFUTURES_ON = false;
        public static bool BULLION_ON = false;
        public static bool INSURANCE_ON = false;
        public static bool CASH_ON = false;
        public static bool FOREX_DERIVATIVES_ON = false;
        public static bool PROPERTIES_IMMOVABLE_ON = false;
        public static bool PUBLIC_PROVIDEND_FUND_ON = false;

        public static bool PRINTCOMPANYNAME = true;
        public static bool PRINTADDRESS01 = true;
        public static bool PRINTADDRESS02 = true;
        public static bool PRINTCITY = true;
        public static bool PRINTPAN = true;

        #endregion

        public static string TotalNOofAsset;

        public string ActionType
        {
            get
            {
                return Action;
            }
            set
            {
                Action = value;
            }
        }

        public void CollectAssetDetails()
        {
            try
            {
                ArrayList AssetClass = new ArrayList();
                string filePath = @Environment.CurrentDirectory + "\\ASSETCLASS.txt";
                //string  = @"c:\ASSETCLASS.txt";
                string line;
                if (File.Exists(filePath))
                {
                    StreamReader file = null;
                    try
                    {
                        file = new StreamReader(filePath);
                        if (file.ReadLine() != null)
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                AssetClass.Add(line);
                            }
                        }
                        else
                        {
                            EDPMessage.Show("A file is corrupted. Application will be Terminated !", "AccordFour....");
                            Environment.Exit(0);
                        }
                    }
                    finally
                    {
                        if (file != null)
                            file.Close();
                    }
                }
                else
                {
                    EDPMessage.Show("A file is missing. Application will be Terminated !", "AccordFour....");
                    Environment.Exit(0);
                }

                #region  Asset Checking
                string s1, s2;
                string[] arr;
                TotalNOofAsset = "";
                for (int i = 0; i <= AssetClass.Count - 1; i++)
                {
                    if (AssetClass[i].ToString() != "")
                    {
                        s1 = AssetClass[i].ToString();
                        arr = s1.Split('-');
                        s2 = arr.GetValue(1).ToString();
                        if (s2 == "AA")
                        {
                            OpenState();
                            break;
                        }
                        switch (s2)
                        {
                            case "A1":
                                EQLISTED_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "1,";
                                break;
                            case "A2":
                                EQUNLISTED_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "2,";
                                break;
                            case "A3":
                                DEBENTURES_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "3,";
                                break;
                            case "A4":
                                BONDS_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "7,";
                                break;
                            case "A5":
                                MUTUALFUND_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "6,";
                                break;
                            case "A6":
                                FIXED_DEPOSITS_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "5,";
                                break;
                            case "A7":
                                TBILLS_GOVT_SECURITY_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "8,";
                                break;
                            case "A8":
                                BULLION_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "10,";
                                break;
                            case "A9":
                                INSURANCE_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "11,";
                                break;
                            case "A10":
                                COMMODITYFUTURES_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "9,";
                                break;
                            case "A11":
                                PROPERTIES_IMMOVABLE_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "12,";
                                break;
                            case "A12":
                                DERIVATIVE_FUTURES_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "4,";
                                break;
                            case "A13":
                                DERIVATIVE_OPTION_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "16,";
                                break;
                            case "A14":
                                FOREX_DERIVATIVES_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "28,";
                                break;
                            case "A15":
                                CASH_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "17,";
                                break;
                            case "A16":
                                PUBLIC_PROVIDEND_FUND_ON = true;
                                TotalNOofAsset = TotalNOofAsset + "35,";
                                break;

                            case "NMON":
                                NOMINATE_ON = true;
                                break;
                            case "MCON":
                                MULTICURRENCY_ON = true;
                                break;
                            case "PFON":
                                PORTFOLIO_ON = true;
                                break;
                            case "OPSCON":
                                SHOWOPENINGSCREEN_ON = true;
                                break;
                            case "PRCONAME":
                                PRINTCOMPANYNAME = true;
                                break;
                            case "PRADD1":
                                PRINTADDRESS01 = true;
                                break;
                            case "PRADD2":
                                PRINTADDRESS02 = true;
                                break;
                            case "PRCT":
                                PRINTCITY = true;
                                break;
                            case "PRPAN":
                                PRINTPAN = true;
                                break;
                        }                  
                    }
                }

                TotalNOofAsset = TotalNOofAsset.Substring(0, TotalNOofAsset.Length - 1);

                #endregion

            }
            catch { }
        }

        public void OpenState()
        {
            EQLISTED_ON = true;
            EQUNLISTED_ON = true;
            DEBENTURES_ON = true;
            DERIVATIVE_FUTURES_ON = true;
            DERIVATIVE_OPTION_ON = true;
            FIXED_DEPOSITS_ON = true;
            MUTUALFUND_ON = true;
            BONDS_ON = true;
            TBILLS_GOVT_SECURITY_ON = true;
            COMMODITYFUTURES_ON = true;
            BULLION_ON = true;
            INSURANCE_ON = true;
            CASH_ON = true;
            FOREX_DERIVATIVES_ON = true;
            PROPERTIES_IMMOVABLE_ON = true;
            PUBLIC_PROVIDEND_FUND_ON = true;

            TotalNOofAsset = "1,2,3,4,5,6,7,8,9,10,11,12,16,17,28,35,";
        }
        
    }

}
