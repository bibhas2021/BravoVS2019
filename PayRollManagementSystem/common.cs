using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using Edpcom;
using Microsoft.VisualBasic;
//using MidasReport;
//using Finance;
using EDPMessageBox;
namespace PayRollManagementSystem
{
    sealed class common
    {
        #region Static Variable
        static Edpcom.EDPCommon edpcom = new EDPCommon();
        public static bool flag_ItemTaged = false;
        public static Boolean Flug_Save = false;
        static SqlConnection con = new SqlConnection();
        static SqlCommand com = new SqlCommand();
        static SqlDataAdapter da = new SqlDataAdapter();
        static DataSet ds = new DataSet();
        public static string ConSrting, BTNname, CompanyNameFinancialYear, DOCBOOL;
        public static bool btnVisi = false;
        public static Form Intfm;
        public static decimal Shortsalequantity, SaleQuantity;
        public static Hashtable arr = new Hashtable();
        public static Hashtable HAST = new Hashtable();
        public static Hashtable HAST1 = new Hashtable();
        public static ArrayList ArrLiFORMENUTREE = new ArrayList();
        public static ArrayList ArrLiFORCOMTREE = new ArrayList();
        public static ArrayList COMMArrSlink = new ArrayList();
        public static ArrayList CompositArrSlink = new ArrayList();
        public static Hashtable HAST2 = new Hashtable();
        public static Hashtable HAST3 = new Hashtable();
        public static Hashtable FillBuffer = new Hashtable();
        public static Hashtable SSaleBuffer = new Hashtable();
        public static Hashtable MSaleBuffer = new Hashtable();
        #region Mutual Fund
        public static Hashtable MFundBuffer = new Hashtable();  // CG
        public static ArrayList AgainstVoucher = new ArrayList();// CG
        public static ArrayList AgainstVoucherDate = new ArrayList();//CG
        public static ArrayList AgainstVoucherCode = new ArrayList();//CG
        public static ArrayList AgainstRate = new ArrayList();//CG
        public static ArrayList MFProfit_Loss = new ArrayList();//CG
        public static ArrayList linktentry = new ArrayList();//CG
        #endregion
        public static Hashtable ShortSale = new Hashtable();
        public static Hashtable SShortSale = new Hashtable();
        public static Hashtable FDIntInfo = new Hashtable();
        public static Hashtable FDIntInfo1 = new Hashtable();
        public static Hashtable FDIntInfo2 = new Hashtable();
        public static Hashtable FDIntInfo3 = new Hashtable();
        public static Hashtable FDIntInfo4 = new Hashtable();
        public static Hashtable bufferForSale = new Hashtable();
        public static Hashtable bufferForPurchase = new Hashtable();
        public static Hashtable SaleFlag = new Hashtable();
        public static Hashtable SaleFlag1 = new Hashtable();
        public static Hashtable FlagBuffer = new Hashtable();
        public static Hashtable IcodeBuffer = new Hashtable();
        public static Hashtable FlagBuffer1 = new Hashtable();
        public static Hashtable StoreFD = new Hashtable();
        public static Hashtable StoreFD1 = new Hashtable();
        public static Hashtable StoreFD2 = new Hashtable();
        public static Hashtable StoreFD3 = new Hashtable();
        public static Hashtable StoreFD4 = new Hashtable();
        public static Hashtable OpeningInfo = new Hashtable();
        public static Hashtable GiftinInfo = new Hashtable();
        public static Hashtable StockinInfo = new Hashtable();
        public static Hashtable GiftinInfo1 = new Hashtable();
        public static Hashtable StockinInfo1 = new Hashtable();
        public static Hashtable FixedDepositeInfo = new Hashtable();
        public static Hashtable CommodityInfo = new Hashtable();
        public static Hashtable CommodityBuffer = new Hashtable();
        public static Hashtable CommodityLinkSale = new Hashtable();
        public static Hashtable CommodityPurchaseState = new Hashtable();
        public static Hashtable CompositeInfo = new Hashtable();
        public static Hashtable CompositSaleBuffer = new Hashtable();
        public static Hashtable CompositLinkSale = new Hashtable();
        public static Hashtable CompositPurchaseState = new Hashtable();
        public static Hashtable ConversionInfo = new Hashtable();
        public static Hashtable MutualFundInfo = new Hashtable();
        public static Hashtable HTfrmLogRet = new Hashtable();
        public static string mcode, LOVRESULT, RadioCHK, DegitWord, ChkMode, Allocvch = "";
        public static int Undo = 0, CellIndex, No_of_Units, PCCode, LOVFlag, SSFlag, PCCode1, TableCounter = 0, TableChecker = 0, ItemNoForPur = 0, CommodityTabelChecker = 0, CommodityFlag = 0, ComFlg = 0, CompositeTabelChecker = 0, CompositeFlag = 0, CompositSFlg = 0, ConversionFlag = 0, ConversionTableChecker = 0, MutualFundFlag = 0, MutualFundTableChecker = 0, possition = 0, width = 0, height = 0;
        public static string title, text, LovReturnValue, LovReturnText, TableCounterName = null, Prdct_Fcvalue, Prdct_Cllasi, Prdct_Bus, Prdct_ISN, Prdct_Alias, Plist, AddlessSub;
        public static System.Windows.Forms.TextBox tb;
        public static string quantity, Description, Icode, Ccode, VoucherNo, RefNo;
        public static bool Demat_Phy, ChComposit;
        public static DateTime ReceiptDate;
        public static decimal OpeningBal = 0, ClosingBal = 0, CommoTotalQun = 0, CompositSelQun = 0, CompositPrchRate = 0;
        public static decimal TotalQty, TotalSaleAmt, SaleRate, BrkPer, AmtAfterBrk, SalOrdVal;
        //public static ArrayList EffAmt = new ArrayList();
        public static ArrayList Cer_FDR = new ArrayList();
        public static ArrayList Ifrom = new ArrayList();
        public static ArrayList Ito = new ArrayList();
        public static ArrayList Units = new ArrayList();
        public static ArrayList Location = new ArrayList();
        public static ArrayList PPFMaturityDate = new ArrayList();
        public static ArrayList Nominee = new ArrayList();
        public static ArrayList DepositPaybleTo = new ArrayList();
        public static ArrayList DPid = new ArrayList();
        public static ArrayList ClientID = new ArrayList();
        public static ArrayList ACNO = new ArrayList();
        public static ArrayList PLAN = new ArrayList();
        public static ArrayList OPTION = new ArrayList();
        public static ArrayList TEntry = new ArrayList();    // cg
        public static ArrayList VchNo = new ArrayList();  //cg

        //public static ArrayList PolicyNo = new ArrayList();
        //public static ArrayList PolicyDate = new ArrayList();
        //public static ArrayList MOP = new ArrayList();
        //public static ArrayList PremiumAmt = new ArrayList();
        //public static ArrayList TotalAmt = new ArrayList();
        //public static ArrayList PolicyTerms = new ArrayList();
        //public static ArrayList TotalPremiumAmt = new ArrayList();
        //public static ArrayList SumAssured = new ArrayList();
        //public static ArrayList NextDueDate = new ArrayList();

        public static DataSet TempDS = new DataSet();
        public static int BufferIndex, BUFFERFLAG, tblcountar = 0, infochk = 0, SLCOMFLAG = 0, SLCOMFLAG1 = 0, SETVal = 0;
        public static DataTable DT;
        public static DataTable dtCurrency = new DataTable();
        public static DataTable LOVDT;
        public static DataTable DTforShortSale;
        public static DataTable DTforSale;
        public static DataTable DTforFD;
        public static decimal ShortSaleRate, SSRate, SSQTY;
        public static int ForFD = 0, ForFD1 = 0, ForFD2 = 0, ForFD3 = 0, ForFD4 = 0, FV = 0; //for FD buffer
        public static string mnth = "";     //  cg
        public static bool chk_PofitLossQry_To_Trialbal = false;
        //        bool chkval;


        
        public static DataTable dtOrg = new DataTable();//pp
        public static DataTable dtCP1 = new DataTable();//pp
        public static DataTable dtCP2 = new DataTable();//pp
        public static DataTable dtCP3 = new DataTable();//pp
        public static Hashtable HTAddress = new Hashtable();
        public static Hashtable HT_Batch_Serial = new Hashtable();
        public static Hashtable HT_Batch_Serial_MI = new Hashtable();
        public static Hashtable HT_Batch_Serial_NI = new Hashtable();
        public static Hashtable HT_ONLINE_ALLOCATION = new Hashtable();
        public static Hashtable HT_ONLINE_APPROPRIATION = new Hashtable();       

        //----------------------FiexdDeposit-----------------------//
        public static char SimCu;
        public static string ReceiptDate1;
        public static string StartDate;
        public static string FirstInterstDate;
        public static string FirstPayOutDate;
        public static string MaturityDate;
        public static string ClassCode;
        public static string PolicyNo;
        public static string PolicyDate;
        public static string MOP;
        public static decimal TotalUnit;
        public static decimal NAV;
        public static decimal PremiumAmt;
        public static decimal TotalAmt;
        public static decimal PolicyTerms;
        public static decimal TotalPremiumAmt;
        public static decimal SumAssured;
        public static string NextDueDate;
        public static decimal Bonus;
        public static decimal PremiumDeposited;
        public static decimal LockPeriod;
        public static decimal ROI;

        public static decimal MaturityAmt;
        public static decimal Period;
        public static string PeriodUnit;
        public static string PrincpalAmt;
        public static decimal AmountPaid;
        public static decimal InterstRate;
        public static string InterestUnit;
        public static decimal Frequency;
        public static string FrequencyUnit;
        public static decimal PayOutFreq;
        public static string PayOutFreqUnit;
        public static decimal Profit_Loss;
        public static string TDSRate;
        public static ArrayList Tentry = new ArrayList();

        // private Timer tmrBlink;
        //  private static int BlinkRate, count;
        //---------------------------------End---------------------//
        public static ArrayList arr_mod = new ArrayList();
        public static ArrayList arr1_mod = new ArrayList();
        public static ArrayList arr2_mod = new ArrayList();
        public static string Query, Caption, Header, ClmHeader, Query_Existing_Item;
        public static int columnindex;
        public static Hashtable get_code = new Hashtable();
        public static Hashtable get_code1 = new Hashtable();
        public static string StckTb;
        public static DataSet STCK_DS = new DataSet();
        //-----------------------------------------------------
        public static Hashtable Tr_Maingrp = new Hashtable();
        public static Hashtable Tr_Subgrp = new Hashtable();
        public static Hashtable Tr_Subgrp1 = new Hashtable();
        public static Hashtable Hold_index = new Hashtable();
        public static int Sgroup_Code;
        public static string HeaderCaption;
        public static int Mgroup_Code, SGP_COUNT, TrFrm_Count;
        // public static Boolean Sub_Ledg;
        public static DataTable SGP;
        public static int ClassF_Code, qry_dt = 0, BlockAsset = 0;
        public static int FormX;
        public static int FormY;
        public static bool SLC_COMP;
        public static int Conversion = 0;
        public static Hashtable htConversion = new Hashtable();
        public static Hashtable htShare = new Hashtable();
        public static int ConversionRowIndex = -1;
        public static int GridColIndex = 0;
        public static string GroupSelect = "";
        public static bool First_Time_Load = false;
        public static bool flug_group = false;
        //Subrata


        #region Configuration
        public static Hashtable CNFG_FlagVal = new Hashtable();
        public static Hashtable CNFG_CodeVal = new Hashtable();
        public static bool Search_By_Alise;//pppp
        #endregion
        #endregion
        //------------------------For Composite-------------------------------
        //public static int CompositeSLNO;
        //public static string ComIcode, ComCcode;
        public static Hashtable ConfigData = new Hashtable();
        public static void LoadConfigData()
        {
            ConfigData.Clear();
            Edpcom.EDPCommon com = new Edpcom.EDPCommon();
            Edpcom.EDPConnection con = new Edpcom.EDPConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("select cnfg_code,bool_val from PayRollManagementSystemoptn where ficode='" + com.CurrentFicode + "' and gcode='" + com.PCURRENT_GCODE + "' and user_code='" + edpcom.PCURRENT_USER + "'", con.mycon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "PayRollManagementSystemoptn");
            cmd = new SqlCommand("select cnfg_code from cnfgmst", con.mycon);
            da.SelectCommand = cmd;
            da.Fill(ds, "cnfgmst");
            for (int i = 0; i < ds.Tables["cnfgmst"].Rows.Count; i++)
            {
                DataView dv = new DataView(ds.Tables["PayRollManagementSystemoptn"]);
                dv.RowFilter = "cnfg_code='" + ds.Tables["cnfgmst"].Rows[i][0].ToString() + "'";
                if (!ConfigData.ContainsKey(ds.Tables["cnfgmst"].Rows[i][0]))
                {
                    if (dv.Count > 0)
                    {
                        ConfigData.Add(ds.Tables["cnfgmst"].Rows[i][0], dv[0][1]);
                    }
                    else
                    {
                        ConfigData.Add(ds.Tables["cnfgmst"].Rows[i][0], true);
                    }
                }
            }
            con.Close();
        }

        public static void HScrollBarVisible(DataGridView dg)
        {
            bool Scroll_H = false;
            bool Scroll_V = false;
            foreach (Control ctrl in dg.Controls)
            {
                if (ctrl.GetType().ToString() == "System.Windows.Forms.VScrollBar")
                {
                    if (ctrl.Visible == true)
                        Scroll_V = true;
                    else
                        Scroll_V = false;
                }
                else if (ctrl.GetType().ToString() == "System.Windows.Forms.HScrollBar")
                {
                    if (ctrl.Visible == true)
                        Scroll_H = true;
                    else
                        Scroll_H = false;
                }
            }
            //if (!Scroll_V)
            //{
            int Columns_Count = dg.Columns.Count;
            int Total_Columns_Width = 0;
            int Total_Effected_Columns = 0;
            int Last_Visible_Column_Index = 0;
            for (int i = 0; i <= Columns_Count - 1; i++)
            {
                if (dg.Columns[i].Visible == true)
                {
                    if (dg.Columns[i].Width >= 90)
                        Total_Effected_Columns = Total_Effected_Columns + 1;
                    Total_Columns_Width = Total_Columns_Width + dg.Columns[i].Width;
                    Last_Visible_Column_Index = i;
                }
            }

            int Width_Difference = 0;
            int Width_Ratio = 0;
            if (dg.RowHeadersVisible)
                Width_Difference = Math.Abs(Convert.ToInt32((dg.Width - dg.RowHeadersWidth - Total_Columns_Width)));
            else
                Width_Difference = Math.Abs(Convert.ToInt32((dg.Width - Total_Columns_Width)));
            if (Total_Effected_Columns > 0)
                Width_Ratio = Convert.ToInt32(Width_Difference / Total_Effected_Columns);

            if (dg.Width > Total_Columns_Width)
            {
                for (int i = 0; i <= Columns_Count - 1; i++)
                {
                    if (dg.Columns[i].Visible == true)
                    {
                        if (dg.Columns[i].Width >= 90)
                            dg.Columns[i].Width = dg.Columns[i].Width + Width_Ratio;
                    }
                }
            }
            else
            {
                for (int i = 0; i <= Columns_Count - 1; i++)
                {
                    if (dg.Columns[i].Visible == true)
                    {
                        if (dg.Columns[i].Width >= 90)
                            dg.Columns[i].Width = dg.Columns[i].Width - Width_Ratio;
                    }
                }
            }

            Total_Columns_Width = 0;
            for (int i = 0; i <= Columns_Count - 1; i++)
            {
                if (dg.Columns[i].Visible == true)                
                    Total_Columns_Width = Total_Columns_Width + dg.Columns[i].Width;   
            }
            if (dg.RowHeadersVisible)
                Total_Columns_Width = Total_Columns_Width + dg.RowHeadersWidth;

            dg.Columns[Last_Visible_Column_Index].Width = dg.Columns[Last_Visible_Column_Index].Width - Math.Abs(Total_Columns_Width - dg.Width) - 1;

            if (Scroll_V)           
                dg.Columns[Last_Visible_Column_Index].Width = dg.Columns[Last_Visible_Column_Index].Width - 18;
            try
            {
                int Row_Height = dg.Rows[0].Height;
                int Avg_Row_Height = Convert.ToInt32(dg.Height / Row_Height);
                int Total_Row_Height = Avg_Row_Height * Row_Height;
                dg.Height = dg.Height - Math.Abs(dg.Height - Total_Row_Height);
            }
            catch { }
            try
            {
                dg.RowHeadersWidthSizeMode=DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dg.AllowUserToResizeColumns = false;
                dg.AllowUserToResizeRows = false;
            }
            catch { }
        }

        public static void GetUnitDet(ComboBox cmbUnit)
        {
            try
            {
                Edpcom.EDPCommon com = new Edpcom.EDPCommon();
                Edpcom.EDPConnection con = new Edpcom.EDPConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("select udesc from unit where ficode='" + com.CurrentFicode + "' and gcode='" + com.PCURRENT_GCODE + "'", con.mycon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "unit");
                cmbUnit.DataSource = ds.Tables["unit"];
                cmbUnit.DisplayMember = "udesc";
            }
            catch
            { }
        }
        public static string GetUnitDesc(Int32 UnitCode)
        {
            if (UnitCode != 0)
            {
                Edpcom.EDPCommon com = new Edpcom.EDPCommon();
                Edpcom.EDPConnection con = new Edpcom.EDPConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("select udesc from unit where ficode='" + com.CurrentFicode + "' and gcode='" + com.PCURRENT_GCODE + "' AND ucode=" + UnitCode, con.mycon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "unit");
                string udes;
                if (!Information.IsDBNull(ds.Tables["unit"]))
                    udes = ds.Tables["unit"].Rows[0][0].ToString();
                else
                    udes = "";
                return udes;
            }
            else return "";
        }
        public static Int32 GetUnitCode(string UnitDesc, bool IfNewAdd)
        {
            Int32 ucode;
            if (!(UnitDesc.Trim() == ""))
            {
                Edpcom.EDPCommon com = new Edpcom.EDPCommon();
                Edpcom.EDPConnection con = new Edpcom.EDPConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("select ucode from unit where ficode='" + com.CurrentFicode + "' and gcode='" + com.PCURRENT_GCODE + "' AND udesc='" + UnitDesc.Trim() + "'", con.mycon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "unit");
                if (!Information.IsDBNull(ds.Tables["unit"]))
                    ucode = Convert.ToInt32(ds.Tables["unit"].Rows[0][0]);
                else//
                    ucode = 0;
                return ucode;
            }
            else return 0;
        }
        public static Int32 GetUnitCode(string UnitDesc)
        {
            return GetUnitCode(UnitDesc, false);
        }
        public static void StartProcess(string Argument)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                p.StartInfo.FileName = Environment.CurrentDirectory + "\\PopUp.exe";
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                p.StartInfo.Arguments = Argument;
                p.Start();
                Microsoft.VisualBasic.Interaction.Beep();
            }
            catch { }
        }
        /// <summary>
        /// Automatically calculate the effective amount value
        /// </summary>
        /// <param name="index">Row index of the effective table</param>
        /// <param name="dt">table</param>
        /// <param name="dgv">corresponding datagrid</param>
        /// <param name="Row">row index to be insert</param>
        /// <param name="Type">sale or purchase type</param>
        public static void CalculateEffectiveAmount(int index, DataTable dt, DataGridView dgv, int Row, string Type)
        {
            try
            {
                double Rate1, dc;
                int Over1;
                string index1;
                Rate1 = Convert.ToDouble(dt.Rows[Row][8]);
                Over1 = Convert.ToInt32(dt.Rows[Row][10]);
                index1 = GetCellIndex(Over1, Type, dgv);
                int test = index1.IndexOf("&", 0);
                if (test < 0)
                {
                    dc = Convert.ToDouble(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[Convert.ToInt32(index1)].Value) * Rate1 / 100;
                    if (Convert.ToInt32(dt.Rows[Row][11]) == 1)
                        dgv.Rows[dgv.CurrentCell.RowIndex].Cells[index].Value = dc.ToString(common.SetDecimalPlace());
                    else
                        dgv.Rows[dgv.CurrentCell.RowIndex].Cells[index].Value = Convert.ToString(common.SetRoundOff(Convert.ToInt32(dt.Rows[Row][11]), dc));
                }
                else
                {
                    string b1, t1;
                    t1 = index1.Substring(0, test);
                    b1 = index1.Substring(test + 1);
                    double sum1 = Convert.ToDouble(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[Convert.ToInt32(t1)].Value) + Convert.ToDouble(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[Convert.ToInt32(b1)].Value);
                    dc = sum1 * Rate1 / 100;
                    if (Convert.ToInt32(dt.Rows[1][11]) == 1)
                        dgv.Rows[dgv.CurrentCell.RowIndex].Cells[index].Value = dc.ToString(common.SetDecimalPlace());
                    else
                        dgv.Rows[dgv.CurrentCell.RowIndex].Cells[index].Value = Convert.ToString(common.SetRoundOff(Convert.ToInt32(dt.Rows[Row][11]), dc));
                }
            }
            catch (Exception ex) { EDPMessage.Show(ex.Message); }
        }
        private static string GetCellIndex(int TCode, string Ttype, DataGridView dgv)
        {
            EDPConnection edpcon = new EDPConnection();
            edpcon.Open();
            string RCode = null;
            if (TCode == 0)
            {
                RCode = "9";
            }
            else if (TCode == 1)
            {
                RCode = "12";
            }
            else if (TCode == 2)
            {
                RCode = "12";
            }
            else if (TCode == 3)
            {
                RCode = "10";
            }
            else if (TCode == 4)
            {
                if (Information.IsNothing(ds.Tables["get_des"]) == false)
                {
                    ds.Tables["get_des"].Clear();
                }
                con.Open();
                com = new SqlCommand("select description from billterms where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and TERMSTYPE='" + Ttype + "' and Sl_No=" + 6 + "", edpcon.mycon);
                da.SelectCommand = com;
                bool bu = Convert.ToBoolean(da.Fill(ds, "get_des"));
                con.Close();
                if (bu)
                {
                    for (int i = 0; i <= dgv.Columns.Count - 1; i++)
                    {
                        if (dgv.Columns[i].HeaderText.ToString() == ds.Tables["get_des"].Rows[0][0].ToString())
                        {
                            RCode = i.ToString();
                        }
                    }
                }
                else
                {
                    RCode = "0";
                }
            }
            else if (TCode == 5)
            {
                if (Information.IsNothing(ds.Tables["get_des"]) == false)
                {
                    ds.Tables["get_des"].Clear();
                }
                com = new SqlCommand("select description from billterms where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and TERMSTYPE='" + Ttype + "' and Sl_No=" + 6 + "", edpcon.mycon);
                da.SelectCommand = com;
                bool bu = Convert.ToBoolean(da.Fill(ds, "get_des"));
                if (bu)
                {
                    for (int i = 0; i <= dgv.Columns.Count - 1; i++)
                    {
                        if (dgv.Columns[i].HeaderText.ToString() == ds.Tables["get_des"].Rows[0][0].ToString())
                        {
                            RCode = i.ToString();
                        }
                    }
                }
                RCode = RCode + "&" + "10";
            }
            else if (TCode == 7)
            {
                RCode = "14";
            }
            else if (TCode == 8)
            {
                RCode = "18";
            }
            else if (TCode == 9)
            {
                if (Information.IsNothing(ds.Tables["get_des"]) == false)
                {
                    ds.Tables["get_des"].Clear();
                }
                con.Open();
                com = new SqlCommand("select description from billterms where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and TERMSTYPE='" + Ttype + "' and Sl_No=" + 4 + "", edpcon.mycon);
                da.SelectCommand = com;
                bool bu = Convert.ToBoolean(da.Fill(ds, "get_des"));
                con.Close();
                if (bu)
                {
                    for (int i = 0; i <= dgv.Columns.Count - 1; i++)
                    {
                        if (dgv.Columns[i].HeaderText.ToString() == ds.Tables["get_des"].Rows[0][0].ToString())
                        {
                            RCode = i.ToString();
                        }
                    }
                }
                RCode = RCode + "&" + "10";
            }
            else
            {
                RCode = "0";
            }
            return RCode;
        }
        public static void AutoBrkPropCreate(Int32 Glcode, string assetclass)
        {
            EDPConnection edpcon = new EDPConnection();
            common.ClearDataTable(ds.Tables["FillB_T"]);
            common.ClearDataTable(ds.Tables["FillB_T1"]);
            edpcon.Open();
            SqlTransaction SQLT;
            com = new SqlCommand("select sl_no,Description from BillTerms where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and TERMSTYPE='" + "P" + "' order by sl_no", edpcon.mycon);
            da.SelectCommand = com;
            bool bu9 = Convert.ToBoolean(da.Fill(ds, "FillB_T"));
            com = new SqlCommand("select sl_no,Description from BillTerms where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and TERMSTYPE='" + "S" + "' order by sl_no", edpcon.mycon);
            da.SelectCommand = com;
            bool bu10 = Convert.ToBoolean(da.Fill(ds, "FillB_T1"));
            edpcon.Close();
            if (bu9)
            {
                edpcon.Open();
                SQLT = edpcon.mycon.BeginTransaction();
                try
                {
                    int x = 0;
                    string rate = "0", formula = "None", code1 = "6";
                    if ((assetclass == "1") || (assetclass == "2") || (assetclass == "3"))
                    {
                        for (x = 0; x <= ds.Tables["FillB_T"].Rows.Count - 1; x++)
                        {
                            string desc = ds.Tables["FillB_T"].Rows[x][1].ToString();
                            if (assetclass != "3")
                            {
                                switch (desc)
                                {
                                    case "STT":
                                        rate = "0";
                                        formula = "NetAmount";
                                        code1 = "0";
                                        break;
                                    case "SERVICE TAX":
                                        rate = "10.30";
                                        formula = "BrokerageAmount";
                                        code1 = "5";
                                        break;
                                    case "TRN.OVER CHARGES":
                                        rate = "0.0035";
                                        formula = "NetAmount";
                                        code1 = "0";
                                        break;
                                    case "STAMP CHARGES":
                                        rate = "0.002";
                                        formula = "NetAmount";
                                        code1 = "0";
                                        break;
                                    default:
                                        rate = "0";
                                        formula = "None";
                                        code1 = "6";
                                        break;
                                }
                                edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "8" + "','" + "T" + "'," + Glcode + "," + ds.Tables["FillB_T"].Rows[x][0] + ",'" + ds.Tables["FillB_T"].Rows[x][1] + "'," + rate + ",'" + formula + "'," + code1 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                            }
                            switch (desc)
                            {
                                case "STT":
                                    rate = "0.125";
                                    formula = "NetAmount";
                                    code1 = "0";
                                    break;
                                case "SERVICE TAX":
                                    rate = "10.30";
                                    formula = "BrokerageAmount";
                                    code1 = "5";
                                    break;
                                case "TRN.OVER CHARGES":
                                    rate = "0.0035";
                                    formula = "NetAmount";
                                    code1 = "0";
                                    break;
                                case "STAMP CHARGES":
                                    rate = "0.01";
                                    formula = "NetAmount";
                                    code1 = "0";
                                    break;
                                default:
                                    rate = "0";
                                    formula = "None";
                                    code1 = "6";
                                    break;
                            }
                            edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "8" + "','" + "D" + "'," + Glcode + "," + ds.Tables["FillB_T"].Rows[x][0] + ",'" + ds.Tables["FillB_T"].Rows[x][1] + "'," + rate + ",'" + formula + "'," + code1 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                        }
                        if (assetclass != "3")
                            edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "8" + "','" + "T" + "'," + Glcode + "," + (x + 1) + ",'" + "BROKERAGE RATE" + "'," + 0.07 + ",'" + "NetAmount" + "'," + 0 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                        edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "8" + "','" + "D" + "'," + Glcode + "," + (x + 1) + ",'" + "BROKERAGE RATE" + "'," + 0.4 + ",'" + "NetAmount" + "'," + 0 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                        for (x = 0; x <= ds.Tables["FillB_T1"].Rows.Count - 1; x++)
                        {
                            string desc = ds.Tables["FillB_T1"].Rows[x][1].ToString();
                            if (assetclass != "3")
                            {
                                switch (desc)
                                {
                                    case "STT":
                                        rate = "0.025";
                                        formula = "NetAmount";
                                        code1 = "0";
                                        break;
                                    case "SERVICE TAX":
                                        rate = "10.30";
                                        formula = "BrokerageAmount";
                                        code1 = "5";
                                        break;
                                    case "TRN.OVER CHARGES":
                                        rate = "0.0035";
                                        formula = "NetAmount";
                                        code1 = "0";
                                        break;
                                    case "STAMP CHARGES":
                                        rate = "0.002";
                                        formula = "NetAmount";
                                        code1 = "0";
                                        break;
                                    default:
                                        rate = "0";
                                        formula = "None";
                                        code1 = "6";
                                        break;
                                }
                                //com = new SqlCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "9" + "','" + "T" + "'," + Glcode + "," + ds.Tables["FillB_T1"].Rows[x][0] + ",'" + ds.Tables["FillB_T1"].Rows[x][1] + "'," + rate + ",'" + formula + "'," + code1 + "," + 1 + ")", con.mycon, SQLT);
                                edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "9" + "','" + "T" + "'," + Glcode + "," + ds.Tables["FillB_T1"].Rows[x][0] + ",'" + ds.Tables["FillB_T1"].Rows[x][1] + "'," + rate + ",'" + formula + "'," + code1 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                            }
                            switch (desc)
                            {
                                case "STT":
                                    rate = "0.125";
                                    formula = "NetAmount";
                                    code1 = "0";
                                    break;
                                case "SERVICE TAX":
                                    rate = "10.30";
                                    formula = "BrokerageAmount";
                                    code1 = "5";
                                    break;
                                case "TRN.OVER CHARGES":
                                    rate = "0.0035";
                                    formula = "NetAmount";
                                    code1 = "0";
                                    break;
                                case "STAMP CHARGES":
                                    rate = "0.01";
                                    formula = "NetAmount";
                                    code1 = "0";
                                    break;
                                default:
                                    rate = "0";
                                    formula = "None";
                                    code1 = "6";
                                    break;
                            }
                            edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "9" + "','" + "D" + "'," + Glcode + "," + ds.Tables["FillB_T1"].Rows[x][0] + ",'" + ds.Tables["FillB_T1"].Rows[x][1] + "'," + rate + ",'" + formula + "'," + code1 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                        }
                        if (assetclass != "3")
                            edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "9" + "','" + "T" + "'," + Glcode + "," + (x + 1) + ",'" + "BROKERAGE RATE" + "'," + 0 + ",'" + "NetAmount" + "'," + 0 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                        edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "9" + "','" + "D" + "'," + Glcode + "," + (x + 1) + ",'" + "BROKERAGE RATE" + "'," + 0.4 + ",'" + "NetAmount" + "'," + 0 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                        SQLT.Commit();
                        edpcon.Close();
                    }
                    else if ((assetclass == "9") || (assetclass == "4") || (assetclass == "16") || (assetclass == "10"))
                    {
                        string tentry = "";
                        if (assetclass == "9")
                            tentry = "M";
                        else if (assetclass == "4")
                            tentry = "L";
                        else if (assetclass == "16")
                            tentry = "P";
                        else if (assetclass == "10")
                            tentry = "K";
                        for (x = 0; x <= ds.Tables["FillB_T"].Rows.Count - 1; x++)
                        {
                            string desc = ds.Tables["FillB_T"].Rows[x][1].ToString();
                            if (desc == "STT")
                            {
                                rate = "0";
                                formula = "NetAmount";
                                code1 = "0";
                            }
                            else if (desc == "SERVICE TAX")
                            {
                                rate = "10.30";
                                formula = "BrokerageAndTran.Charges";
                                code1 = "9";
                            }
                            else if (desc == "TRANSACTION CHARGES")
                            {
                                rate = "0.004";
                                formula = "NetAmount";
                                code1 = "0";
                            }
                            else if (desc == "STAMP CHARGES")
                            {
                                rate = "0.001";
                                formula = "AmountWithBrokerage";
                                code1 = "1";
                            }
                            else
                            {
                                rate = "0";
                                formula = "None";
                                code1 = "6";
                            }
                            com = new SqlCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "8" + tentry + "','" + "D" + "'," + Glcode + "," + ds.Tables["FillB_T"].Rows[x][0] + ",'" + ds.Tables["FillB_T"].Rows[x][1] + "'," + rate + ",'" + formula + "'," + code1 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                            com.ExecuteNonQuery();
                        }
                        com = new SqlCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "8" + tentry + "','" + "D" + "'," + Glcode + "," + (x + 1) + ",'" + "BROKERAGE RATE" + "'," + 0.02 + ",'" + "NetAmount" + "'," + 0 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                        com.ExecuteNonQuery();
                        for (x = 0; x <= ds.Tables["FillB_T1"].Rows.Count - 1; x++)
                        {
                            string desc = ds.Tables["FillB_T1"].Rows[x][1].ToString();
                            if (desc == "STT")
                            {
                                rate = "0";
                                formula = "NetAmount";
                                code1 = "0";
                            }
                            else if (desc == "SERVICE TAX")
                            {
                                rate = "10.30";
                                formula = "BrokerageAndTran.Charges";
                                code1 = "9";
                            }
                            else if (desc == "TRANSACTION CHARGES")
                            {
                                rate = "0.004";
                                formula = "NetAmount";
                                code1 = "0";
                            }
                            else if (desc == "STAMP CHARGES")
                            {
                                rate = "0.001";
                                formula = "AmountLessBrokerage";
                                code1 = "2";
                            }
                            else
                            {
                                rate = "0";
                                formula = "None";
                                code1 = "6";
                            }
                            com = new SqlCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "9" + tentry + "','" + "D" + "'," + Glcode + "," + ds.Tables["FillB_T1"].Rows[x][0] + ",'" + ds.Tables["FillB_T1"].Rows[x][1] + "'," + rate + ",'" + formula + "'," + code1 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                            com.ExecuteNonQuery();
                        }
                        com = new SqlCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "9" + tentry + "','" + "D" + "'," + Glcode + "," + (x + 1) + ",'" + "BROKERAGE RATE" + "'," + 0.02 + ",'" + "NetAmount" + "'," + 0 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                        com.ExecuteNonQuery();
                        SQLT.Commit();
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    EDPMessage.Show(ex.Message);
                    SQLT.Rollback();
                    edpcon.Close();
                }
            }
        }
        public static Hashtable ComIcodeBuffer = new Hashtable();
        //------------------------End Composite-------------------------------
        public static bool VoucherModify(string Ficode, string Gcode, string Tentry, Int32 Voucher)
        {
            return false;
        }
        public static bool VoucherEdit(string Ficode, string Gcode, string Tentry, Int32 Voucher)
        {
            return false;
        }
        public static bool VoucherView(string Ficode, string Gcode, string Tentry, Int32 Voucher)
        {
            if (edpcom.GetDatatable("select viewflag from vchlock where ficode='" + Ficode + "'and gcode='" + Gcode + "' and t_entry='" + Tentry + "' and voucher=" + Voucher).Rows.Count > 0)
                return edpcom.GetResultB("select viewflag from vchlock where ficode='" + Ficode + "'and gcode='" + Gcode + "' and t_entry='" + Tentry + "' and voucher=" + Voucher);
            else return true;
        }
        /// <summary>
        /// List of ledger.
        /// </summary>
        /// <param name="Code">subgroup or maingroup code</param>
        /// <param name="Type">'M' or 'S' denote main group or sub group</param>
        /// <returns>returns datatable</returns>
        public static DataTable SelectLedger(Int32[] Code, char Type)
        {
            return SelectLedger(Code, Type, true);
        }
        /// <summary>
        /// List of ledger.
        /// </summary>
        /// <param name="Code">subgroup or maingroup code</param>
        /// <param name="Type">'M' or 'S' denote main group or sub group</param>
        /// <returns></returns>
        public static DataTable SelectLedger(Int32 Code, char Type)
        {
            return SelectLedger(new Int32[] { Code }, Type);
        }
        /// <summary>
        /// List of ledger.
        /// </summary>
        /// <param name="Code">subgroup or maingroup code</param>
        /// <param name="Type">'M' or 'S' denote main group or sub group</param>
        /// <param name="ShowMsg">True or False for showing Message if no ledgers found.</param>
        /// <returns>returns datatable</returns>
        public static DataTable SelectLedger(Int32[] Code, char Type, bool ShowMsg)
        {
            try
            {
                EDPConnection edpcon = new EDPConnection();
                edpcon.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand com;
                DataTable dt;
                DataRow Dr;
                ArrayList s = new ArrayList();
                Int32 k;
                if (Type == 'S')
                {
                    if (Information.IsNothing(ds.Tables["ChkBro"]) == false)
                    {
                        ds.Tables["ChkBro"].Clear();
                    }
                    dt = new DataTable("LOV");
                    DataColumn brokername = new DataColumn("BrokerName");
                    DataColumn code = new DataColumn("BrokerCode");
                    dt.Columns.Add(brokername);
                    dt.Columns.Add(code);
                    for (int p = 0; p <= Code.Length - 1; p++)
                    {
                        s.Clear();
                        s.Add(Convert.ToInt32(Code.GetValue(p)));
                        for (int j = 0; j <= s.Count - 1; j++)
                        {
                            if (Information.IsNothing(ds.Tables["Sl"]) == false)
                            {
                                ds.Tables["Sl"].Clear();
                                ds.Clear();
                            }

                            k = Convert.ToInt32(s[j]);
                            com = new SqlCommand("SELECT DISTINCT SGROUP,Prev_Group,MType,LDESC,GLCODE FROM glmst WHERE FICode = " + edpcom.CurrentFicode + " AND GCode = " + edpcom.PCURRENT_GCODE + " AND (PREV_GROUP = " + k + ")", edpcon.mycon);
                            da.SelectCommand = com;
                            da.Fill(ds, "Sl");
                            edpcon.Close();
                            for (int i = 0; i <= ds.Tables["Sl"].Rows.Count - 1; i++)
                            {
                                if (k != Convert.ToInt32(ds.Tables["Sl"].Rows[i][0]))
                                    s.Add(Convert.ToInt32(ds.Tables["Sl"].Rows[i][0]));

                                if ((Convert.ToChar(ds.Tables["Sl"].Rows[i][2]) == 'L') & (Convert.ToInt32(ds.Tables["Sl"].Rows[i][0]) == Convert.ToInt32(ds.Tables["Sl"].Rows[i][1])))
                                {
                                    Dr = dt.NewRow();
                                    Dr[0] = Convert.ToString(ds.Tables["Sl"].Rows[i][3]);
                                    Dr[1] = Convert.ToString(ds.Tables["Sl"].Rows[i][4]);
                                    dt.Rows.Add(Dr);
                                }

                            }

                        }

                    }

                }
                else
                {
                    com = new SqlCommand("select LDESC,GLCODE,MTYPE,SGROUP from glmst where mgroup=" + Code + " and Ficode='" + edpcom.CurrentFicode + "' and GCODE='" + edpcom.PCURRENT_GCODE + "' and mtype='L' and (ACTV_FLG IS NULL OR ACTV_FLG='True')  ", edpcon.mycon);
                    da.SelectCommand = com;
                    da.Fill(ds, "ledger");
                    dt = new DataTable();
                    dt = ds.Tables["ledger"];
                }
                if (ShowMsg)
                {
                    if (dt.Rows.Count < 1)
                    {
                        EDPMessage.Show("No Ledger Found,First Create Ledger", "Information....");
                        //////////Finance.frmBaseBrowse fi = new frmBaseBrowse();
                        edpcon.Open();
                        ////////fi.value_pass(edpcom.CurrentFicode, edpcom.PCURRENT_GCODE, edpcon.connectionstr, 2);
                        ////////fi.ShowDialog();
                        edpcon.Close();
                        return dt;
                    }
                }
                return dt;
            }
            catch { return null; }
        }
        public static string DesmPlc(string value)
        {
            try
            {
                decimal dc = Convert.ToDecimal(value);
                string rtstr = dc.ToString(SetDecimalPlace());
                return rtstr;
            }
            catch { throw new Exception("Not a integer or decimal value."); }

        }
        public static bool CheckGridCellValueN(DataGridViewCell Cell, String Message, DataGridView dgv)
        {
            if (Cell.Value == null)
            {
                Cell.Value = 0;
                return true;
            }
            else if (Information.IsNumeric(Cell.Value) == false)
            {
                EDPMessage.Show(Message.Trim(), "Information....");
                dgv.ClearSelection();
                Cell.Selected = true;
                Cell.Value = null;
                return false;
            }
            return true;
        }
        public static string SetDecimalPlace()
        {
            int Dplace = edpcom.GetDecimal_Place;
            string RetStr = "0.";
            if (Dplace == 0)
            {
                RetStr = "0";
            }
            for (int i = 1; i <= Dplace; i++)
            {
                RetStr = RetStr + "0";
            }
            return RetStr;
        }
        public static string SetDecimalPlace(int DecPlace)
        {
            int Dplace = DecPlace;
            string RetStr = "0.";
            if (Dplace == 0)
            {
                RetStr = "0";
            }
            for (int i = 1; i <= Dplace; i++)
            {
                RetStr = RetStr + "0";
            }
            return RetStr;
        }
        public static double SetRoundOff(int Rcode, double Rvalue)
        {
            try               
            {
                string Tval = Rvalue.ToString();
                if (Rcode == 2) //Alwaya Upper
                {
                    int z = Tval.IndexOf(".");
                    if (z > 0)
                    {
                        string z1 = Tval.Substring(z + 1);
                        string z2 = null;
                        if (Convert.ToInt32(z1) > 0)
                        {
                            z2 = Tval.Substring(0, z);
                            z2 = Convert.ToString(Convert.ToInt32(z2) + 1);
                            Rvalue = Convert.ToDouble(z2);
                            Rvalue = Convert.ToDouble(Rvalue.ToString(common.SetDecimalPlace()));
                        }
                        else
                        {
                            Rvalue = Convert.ToDouble(Tval);
                            Rvalue = Convert.ToDouble(Rvalue.ToString(common.SetDecimalPlace()));
                        }
                    }
                }
                else if (Rcode == 3)  //Alwaya Lower
                {
                    int z = Tval.IndexOf(".");
                    if (z > 0)
                    {
                        string z1 = Tval.Substring(z + 1);
                        string z2 = null;
                        if (Convert.ToInt32(z1) > 0)
                        {
                            z2 = Tval.Substring(0, z);
                            Rvalue = Convert.ToDouble(z2);
                            Rvalue = Convert.ToDouble(Rvalue.ToString(common.SetDecimalPlace()));
                        }
                        else
                        {
                            Rvalue = Convert.ToDouble(Tval);
                            Rvalue = Convert.ToDouble(Rvalue.ToString(common.SetDecimalPlace()));
                        }
                    }
                }
                else if (Rcode == 4)  //Truncate off 1 DecimalPlace
                {
                    int z = Tval.IndexOf(".");
                    string z1 = Tval.Substring(0, z + 2);
                    Rvalue = Convert.ToDouble(z1);
                    //Rvalue = Convert.ToDecimal(Rvalue.ToString(Modual1.SetDecimalPlace()));
                }
                else if (Rcode == 5)  //Truncate off 2 DecimalPlace
                {
                    int z = Tval.IndexOf(".");
                    string z1 = Tval.Substring(0, z + 3);
                    Rvalue = Convert.ToDouble(z1);
                }
                else if (Rcode == 6)  //Truncate off 3 DecimalPlace
                {
                    int z = Tval.IndexOf(".");
                    string z1 = Tval.Substring(0, z + 4);
                    Rvalue = Convert.ToDouble(z1);
                }
                else if (Rcode == 7)  //Same Value return
                {
                    Rvalue = Convert.ToDouble(Tval);
                }
                return Rvalue;
            }
            catch { return Rvalue; }
        }
        public static void MLOV(string query, string caption, string header, string clmheader, int index, string stcktb, int assetblock)
        {
            Query = query;
            Caption = caption;
            Header = header;
            ClmHeader = clmheader;
            columnindex = index;
            StckTb = stcktb;
            qry_dt = 0;
            BlockAsset = assetblock;
            //////////frmListAddRemove lstadd = new frmListAddRemove();
            ////////////lstadd.ShowDialog();
        }

        public static void MLOV(string query, string caption, string header, string clmheader, int index, string stcktb, int assetblock, string query_Existing_Item)
        {
            Query = query;
            Query_Existing_Item = query_Existing_Item;
            Caption = caption;
            Header = header;
            ClmHeader = clmheader;
            columnindex = index;
            StckTb = stcktb;
            qry_dt = 0;
            BlockAsset = assetblock;
            //////////////frmListAddRemove lstadd = new frmListAddRemove();
            //////////////lstadd.ShowDialog();
        }

        public static void MLOV(DataTable dt, string caption, string header, string clmheader, int index)
        {
            //   Query = query;
            Caption = caption;
            Header = header;
            ClmHeader = clmheader;
            columnindex = index;
            //        StckTb = stcktb;
            qry_dt = 1;
            if (Information.IsNothing(common.STCK_DS.Tables["MLOV"]) == false)
            {
                common.STCK_DS.Tables.Remove("MLOV");
            }
            common.STCK_DS.Tables.Add(dt);
            ////////////frmListAddRemove lstadd = new frmListAddRemove();
            ////////////lstadd.ShowDialog();
        }
        public static void LOV(string title1, string quary, System.Windows.Forms.TextBox tb1, int cell_index)
        {
            title = title1;
            text = quary;
            tb = tb1;
            CellIndex = cell_index;
            Intfm = null;
            possition = 0;
            //////////////LOV lov = new LOV();
            //////////lov.ShowDialog();
        }
        public static void LOV(string title1, DataTable dt, System.Windows.Forms.TextBox tb1, int cell_index)
        {
            title = title1;
            LOVDT = dt;
            tb = tb1;
            CellIndex = cell_index;
            LOVFlag = 100;
            Intfm = null;
            possition = 0;
            //////////////LOV lov = new LOV();
            //////////////lov.ShowDialog();
        }
        public static void LOV(string title1, string quary, System.Windows.Forms.TextBox tb1, int cell_index, Form FromOpen, bool btnvisible, string btnText)//pp
        {
            title = title1;
            text = quary;
            tb = tb1;
            CellIndex = cell_index;
            btnVisi = btnvisible;
            BTNname = btnText;
            Intfm = FromOpen;
            possition = 0;
            //////////////LOV lov = new LOV();
            //////////////lov.ShowDialog();
        }

        public static void LOV(string title1, string quary, System.Windows.Forms.TextBox tb1, int cell_index, Form FromOpen, bool btnvisible, string btnText, int flug)//pp
        {
            title = title1;
            text = quary;
            tb = tb1;
            CellIndex = cell_index;
            btnVisi = btnvisible;
            BTNname = btnText;
            Intfm = FromOpen;
            if (flug == 1)
                possition = 500;
            else
                possition = 0;
            ////////////LOV lov = new LOV();
            //////////////lov.ShowDialog();
        }


        public static void LOV(string title1, DataTable dt, System.Windows.Forms.TextBox tb1, int cell_index, Form FromOpen, bool btnvisible, string btnText)
        {
            title = title1;
            LOVDT = dt;
            tb = tb1;
            CellIndex = cell_index;
            LOVFlag = 100;
            btnVisi = btnvisible;
            BTNname = btnText;
            Intfm = FromOpen;
            possition = 0;
            ////////////LOV lov = new LOV();
            //////////////lov.ShowDialog();
        }
        public static void Buffer()
        {
            DT = new DataTable("DT" + common.BufferIndex);
            common.BufferIndex++;
        }
        public static string GenTableName()
        {
            TableCounterName = "DT" + TableCounter;
            TableCounter++;
            return common.TableCounterName;
        }
        public static void DTCR()
        {
            SGP = new DataTable("SGP" + common.SGP_COUNT);
            common.SGP_COUNT++;
        }
        public static void TABLECount()
        {
            common.tblcountar++;
        }
        public static DataTable Ledger(int PreviousGroup, String ConnectionStr)
        {
            con = new SqlConnection(ConnectionStr);
            if (Information.IsNothing(ds.Tables["ChkBro9"]) == false)
            {
                ds.Tables["ChkBro9"].Clear();
            }
            DataTable dt = new DataTable("LOV");
            DataColumn brokername = new DataColumn("LedgerName");
            DataColumn code = new DataColumn("LedgerCode");
            DataColumn CurBal = new DataColumn("LedgerCurrentBalance");
            dt.Columns.Add(brokername);
            dt.Columns.Add(code);
            dt.Columns.Add(CurBal);
            con.Open();
            com = new SqlCommand("select LDESC,GLCODE,MTYPE,SGROUP,CURBAL from glmst where PREV_GROUP=" + PreviousGroup + " and GCODE='" + edpcom.PCURRENT_GCODE + "'", con);
            da.SelectCommand = com;
            bool cb = Convert.ToBoolean(da.Fill(ds, "ChkBro9"));
            con.Close();
            if (cb == true)
            {
                int i = Convert.ToInt32(ds.Tables["ChkBro9"].Rows.Count - 1), f = 0, glcode, sgroup;
                string ldesc;
                decimal CB;
                char mtype;
                for (f = 0; f <= i; f++)
                {
                    ldesc = ds.Tables["ChkBro9"].Rows[f][0].ToString();
                    glcode = Convert.ToInt32(ds.Tables["ChkBro9"].Rows[f][1]);
                    mtype = Convert.ToChar(ds.Tables["ChkBro9"].Rows[f][2]);
                    sgroup = Convert.ToInt32(ds.Tables["ChkBro9"].Rows[f][3]);
                    CB = Convert.ToDecimal(ds.Tables["ChkBro9"].Rows[f][4]);
                    if (mtype == 'L')
                    {
                        DataRow dr;
                        dr = dt.NewRow();
                        dr[0] = ldesc;
                        dr[1] = glcode;
                        dr[2] = CB;
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        if (Information.IsNothing(ds.Tables["ChkBro19"]) == false)
                        {
                            ds.Tables["ChkBro19"].Clear();
                        }
                        con.Open();
                        com = new SqlCommand("select LDESC,GLCODE,MTYPE,SGROUP,CURBAL from glmst where PREV_GROUP=" + sgroup + " and GCODE='" + edpcom.PCURRENT_GCODE + "'", con);
                        da.SelectCommand = com;
                        bool cb1 = Convert.ToBoolean(da.Fill(ds, "ChkBro19"));
                        con.Close();
                        if (cb1 == true)
                        {
                            int ii = Convert.ToInt32(ds.Tables["ChkBro19"].Rows.Count - 1), jj = 0, glc, sg;
                            string ld;
                            decimal cb11;
                            char mt;
                            for (jj = 0; jj <= ii; jj++)
                            {
                                ld = ds.Tables["ChkBro19"].Rows[jj][0].ToString();
                                glc = Convert.ToInt32(ds.Tables["ChkBro19"].Rows[jj][1]);
                                mt = Convert.ToChar(ds.Tables["ChkBro19"].Rows[jj][2]);
                                sg = Convert.ToInt32(ds.Tables["ChkBro19"].Rows[jj][3]);
                                cb11 = Convert.ToDecimal(ds.Tables["ChkBro19"].Rows[jj][4]);
                                if (mt == 'L')
                                {
                                    DataRow dr;
                                    dr = dt.NewRow();
                                    dr[0] = ld;
                                    dr[1] = glc;
                                    dr[2] = cb11;
                                    dt.Rows.Add(dr);
                                }
                                else
                                {
                                    if (Information.IsNothing(ds.Tables["ChkBro29"]) == false)
                                    {
                                        ds.Tables["ChkBro29"].Clear();
                                    }
                                    con.Open();
                                    com = new SqlCommand("select LDESC,GLCODE,MTYPE,SGROUP,CURBAL from glmst where PREV_GROUP=" + sg + " and GCODE='" + edpcom.PCURRENT_GCODE + "'", con);
                                    da.SelectCommand = com;
                                    bool cb2 = Convert.ToBoolean(da.Fill(ds, "ChkBro29"));
                                    con.Close();
                                    if (cb2 == true)
                                    {
                                        int i1 = Convert.ToInt32(ds.Tables["ChkBro29"].Rows.Count - 1), j1 = 0, glc1, sg1;
                                        string ld1;
                                        decimal cb22;
                                        char mt1;
                                        for (j1 = 0; j1 <= i1; j1++)
                                        {
                                            ld1 = ds.Tables["ChkBro29"].Rows[j1][0].ToString();
                                            glc1 = Convert.ToInt32(ds.Tables["ChkBro29"].Rows[j1][1]);
                                            mt1 = Convert.ToChar(ds.Tables["ChkBro29"].Rows[j1][2]);
                                            sg1 = Convert.ToInt32(ds.Tables["ChkBro29"].Rows[j1][3]);
                                            cb22 = Convert.ToDecimal(ds.Tables["ChkBro29"].Rows[j1][4]);
                                            if (mt1 == 'L')
                                            {
                                                DataRow dr;
                                                dr = dt.NewRow();
                                                dr[0] = ld1;
                                                dr[1] = glc1;
                                                dr[2] = cb22;
                                                dt.Rows.Add(dr);
                                            }
                                            else
                                            {
                                                if (Information.IsNothing(ds.Tables["ChkBro39"]) == false)
                                                {
                                                    ds.Tables["ChkBro39"].Clear();
                                                }
                                                con.Open();
                                                com = new SqlCommand("select LDESC,GLCODE,MTYPE,SGROUP,CURBAL from glmst where PREV_GROUP=" + sg1 + " and GCODE='" + edpcom.PCURRENT_GCODE + "'", con);
                                                da.SelectCommand = com;
                                                bool cb3 = Convert.ToBoolean(da.Fill(ds, "ChkBro39"));
                                                con.Close();
                                                if (cb3 == true)
                                                {
                                                    int i11 = Convert.ToInt32(ds.Tables["ChkBro39"].Rows.Count - 1), j11 = 0, glc11, sg11;
                                                    string ld11;
                                                    decimal cb33;
                                                    char mt11;
                                                    for (j11 = 0; j11 <= i11; j11++)
                                                    {
                                                        ld11 = ds.Tables["ChkBro39"].Rows[j11][0].ToString();
                                                        glc11 = Convert.ToInt32(ds.Tables["ChkBro39"].Rows[j11][1]);
                                                        mt11 = Convert.ToChar(ds.Tables["ChkBro39"].Rows[j11][2]);
                                                        sg11 = Convert.ToInt32(ds.Tables["ChkBro39"].Rows[j11][3]);
                                                        cb33 = Convert.ToDecimal(ds.Tables["ChkBro39"].Rows[j11][4]);
                                                        if (mt11 == 'L')
                                                        {
                                                            DataRow dr;
                                                            dr = dt.NewRow();
                                                            dr[0] = ld11;
                                                            dr[1] = glc11;
                                                            dr[2] = cb33;
                                                            dt.Rows.Add(dr);
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
                }
            }
            return dt;
        }
        public static void set_toltip(Control cntrl, string str)
        {
            ToolTip tp = new ToolTip();
            tp.SetToolTip(cntrl, str);
        }
        internal static Hashtable LoadExch(ComboBox exchange)
        {
            Hashtable retTable = new Hashtable();
            try
            {
                exchange.Items.Clear();
                // and gcode='" + edpcom.PCURRENT_GCODE + "'
                DataTable dt = edpcom.GetDatatable("select Exchng_Name,Exchng_Code from Exchng_Mst where ficode='" + edpcom.CurrentFicode + "' and GCODE='" + edpcom.PCURRENT_GCODE + "'");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        exchange.Items.Add(dt.Rows[i][0].ToString());
                        retTable.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1]);
                    }
                }
                else
                {
                    //EDPMessage.Show("Exchange not found !" + Environment.NewLine + "First create Exchange", "Message");
                    //Exch_Mst exc = new Exch_Mst(0);
                    //exc.ShowDialog();
                    //LoadExch(exchange);
                }
            }
            catch { }
            return retTable;
        }        
        public static int GetInt(bool Value)
        {
            if (Value)
                return 1;
            else return 0;
        }
        public static int GetInt(object Value)
        {
            bool value = Convert.ToBoolean(Value);
            if (value)
                return 1;
            else return 0;
        }
        public static void ClearDataTable(DataTable dt)
        {
            if (!Information.IsNothing(dt))
                dt.Reset();
        }
        public static void RuntheLastBuildUpdate()
        {
            //string sql = "delete from PayRollManagementSystem_db_info";
            //EDPConnection edpcon = new EDPConnection();
            //edpcon.Open();
            //SqlCommand mycmd = new SqlCommand(sql, edpcon.mycon);
            //mycmd.ExecuteNonQuery();
            //sql = "Select * from PayRollManagementSystem_db_info order by build_date desc";
            //mycmd = new SqlCommand(sql, edpcon.mycon);
            //DataSet ds = new DataSet();
            //SqlDataAdapter dap = new SqlDataAdapter();
            //DateTime PBuildDate;
            //dap.SelectCommand = mycmd;
            //Version.version version = new Version.version();
            //version.Versionflg = true;
            //edpcom.FirstTimeInstall = true;
            //try
            //{
            //    PBuildDate = Convert.ToDateTime(PayRollManagementSystem.Properties.Resources.Release_Date);
            //    if (PBuildDate != edpcom.PBUILD_DATE)
            //    {
            //        version.ChkVersion(edpcon.mycon, edpcom.PBUILD_DATE, PBuildDate);
            //        edpcon.Close();
            //    }
            //    common.StartProcess("[Update,Info][Successfully,update,the,database.]");
            //}
            //catch { common.StartProcess("[Update,Info][Update,procedure,unsuccessfull.]"); }
            try
            {
                EDPConnection edpcon = new EDPConnection();
                edpcon.Open();
                string sql = "delete from PayRollManagementSystem_db_info where build_date='" + edpcom.getSqlDateStr(edpcom.PBUILD_DATE) + "'";
                edpcon.Open();
                SqlCommand mycmd = new SqlCommand(sql, edpcon.mycon);
                mycmd.ExecuteNonQuery();
                sql = "Select * from PayRollManagementSystem_db_info order by build_date desc";
                mycmd = new SqlCommand(sql, edpcon.mycon);
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter();
                DateTime PBuildDate;
                dap.SelectCommand = mycmd;
                ////////////EDPVersion.versionEDP version1 = new EDPVersion.versionEDP();
                ////////////version1.Versionflg = true;
                if (Convert.ToBoolean(dap.Fill(ds, "db")))
                {
                    PBuildDate = (DateTime)ds.Tables["db"].Rows[0][3];
                    if (PBuildDate != edpcom.PBUILD_DATE)
                    {
                        ////////////version1.ChkVersion(edpcon.mycon, edpcom.PBUILD_DATE, PBuildDate);
                        edpcon.Close();
                    }
                    common.StartProcess("[Update,Info][Successfully,update,the,last,Buld..]");
                }
            }
            catch { common.StartProcess("[Update,Info][Update,procedure,unsuccessfull,for,the,last,build.]"); }
        }

        public static bool FDIntCollect(int vouno, string TE)
        {
            EDPConnection edpcon = new EDPConnection();
            SqlDataAdapter dap = new SqlDataAdapter();
            DataSet ds = new DataSet();
            edpcon.Open();
            bool chkval;
            chkval = false;
            string sql = "SELECT * FROM FDINT WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND T_ENTRY='" + TE + "' AND VOUCHER=" + vouno + " AND Status='Complete'";
            SqlCommand mycmd = new SqlCommand(sql, edpcon.mycon);
            dap.SelectCommand = mycmd;
            chkval = Convert.ToBoolean(dap.Fill(ds, "db1"));
            edpcon.Close();

            return chkval;
        }
        public static bool FDRedemCollect(int vouno, string TE)
        {
            EDPConnection edpcon = new EDPConnection();
            SqlDataAdapter dap = new SqlDataAdapter();
            DataSet ds = new DataSet();
            edpcon.Open();
            bool chkval;

            string sql = "SELECT * FROM FDInfo WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND T_ENTRY='" + TE + "' AND VOUCHER=" + vouno + " AND FDState='S'";
            SqlCommand mycmd = new SqlCommand(sql, edpcon.mycon);
            dap.SelectCommand = mycmd;
            chkval = Convert.ToBoolean(dap.Fill(ds, "db"));
            edpcon.Close();

            return chkval;
        }

        public static bool GetLinkedVch(int vouno, string TE)
        {
            EDPConnection edpcon = new EDPConnection();
            SqlDataAdapter dap = new SqlDataAdapter();
            DataSet ds = new DataSet();
            edpcon.Open();
            bool chkval;
            TE = TE + ',' + '8' + TE;
            string sql = "SELECT * FROM Pltran WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND AgainstTentry in ('" + TE + "') AND AgainstVoucherCode=" + vouno + "";
            SqlCommand mycmd = new SqlCommand(sql, edpcon.mycon);
            dap.SelectCommand = mycmd;
            chkval = Convert.ToBoolean(dap.Fill(ds, "db"));
            edpcon.Close();

            return chkval;
        }

        public static string assetblockfun()
        {
            string assetclass = "";
            ArrayList araset = new ArrayList();
            araset.Clear();
            if (Edpcom.frmConfigarationVariable.EQLISTED_ON == false)
            {
                araset.Add(1);
            }
            if (Edpcom.frmConfigarationVariable.EQUNLISTED_ON == false)
            {
                araset.Add(2);
            }
            if (Edpcom.frmConfigarationVariable.DEBENTURES_ON == false)
            {
                araset.Add(3);
            }
            if (Edpcom.frmConfigarationVariable.DERIVATIVE_FUTURES_ON == false)
            {
                araset.Add(4);
            }
            if (Edpcom.frmConfigarationVariable.FIXED_DEPOSITS_ON == false)
            {
                araset.Add(5);
            }
            if (Edpcom.frmConfigarationVariable.MUTUALFUND_ON == false)
            {
                araset.Add(6);
            }
            if (Edpcom.frmConfigarationVariable.BONDS_ON == false)
            {
                araset.Add(7);
            }
            if (Edpcom.frmConfigarationVariable.COMMODITYFUTURES_ON == false)
            {
                araset.Add(9);
            }
            if (Edpcom.frmConfigarationVariable.BULLION_ON == false)
            {
                araset.Add(10);
            }

            if (Edpcom.frmConfigarationVariable.INSURANCE_ON == false)
            {
                araset.Add(11);
            }

            if (Edpcom.frmConfigarationVariable.CASH_ON == false)
            {
                araset.Add(17);
            }
            if (Edpcom.frmConfigarationVariable.PROPERTIES_IMMOVABLE_ON == false)
            {
                araset.Add(12);
            }
            if (Edpcom.frmConfigarationVariable.PUBLIC_PROVIDEND_FUND_ON == false)
            {
                araset.Add(35);
            }
            if (Edpcom.frmConfigarationVariable.FOREX_DERIVATIVES_ON == false)
            {
                araset.Add(28);
            }

            if (araset.Count > 0)
            {
                for (int s = 0; s < araset.Count; s++)
                {
                    assetclass = assetclass + araset[s];
                    if (s != araset.Count - 1)
                    {
                        assetclass = assetclass + ",";
                    }
                }
            }
            if (assetclass != "")
                return (assetclass);
            else
                return ("0");
        }

        public static void AutoBrkPropCreate(Int32 Glcode, string assetclass, string T_entry)
        {

            string t_entry = T_entry;
            //Int32 icode = Icode;
            EDPConnection edpcon = new EDPConnection();
            common.ClearDataTable(ds.Tables["FillB_T"]);
            common.ClearDataTable(ds.Tables["FillB_T1"]);
            edpcon.Open();
            SqlTransaction SQLT;
            com = new SqlCommand("select sl_no,Description from BillTerms where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and TERMSTYPE='" + "P" + "' order by sl_no", edpcon.mycon);
            da.SelectCommand = com;
            bool bu9 = Convert.ToBoolean(da.Fill(ds, "FillB_T"));
            com = new SqlCommand("select sl_no,Description from BillTerms where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and TERMSTYPE='" + "S" + "' order by sl_no", edpcon.mycon);
            da.SelectCommand = com;
            bool bu10 = Convert.ToBoolean(da.Fill(ds, "FillB_T1"));
            edpcon.Close();
            if (bu9)
            {
                edpcon.Open();
                SQLT = edpcon.mycon.BeginTransaction();
                try
                {
                    int x = 0;
                    string rate = "0", formula = "None", code1 = "6";
                    if ((assetclass == "1") || (assetclass == "2") || (assetclass == "3"))
                    {
                        if (T_entry == "8")
                        {
                            for (x = 0; x <= ds.Tables["FillB_T"].Rows.Count - 1; x++)
                            {
                                string desc = ds.Tables["FillB_T"].Rows[x][1].ToString();
                                if (assetclass != "3")
                                {
                                    switch (desc)
                                    {
                                        case "STT":
                                            rate = "0";
                                            formula = "NetAmount";
                                            code1 = "0";
                                            break;
                                        case "SERVICE TAX":
                                            rate = "10.30";
                                            formula = "BrokerageAmount";
                                            code1 = "5";
                                            break;
                                        case "TRN.OVER CHARGES":
                                            rate = "0.0035";
                                            formula = "NetAmount";
                                            code1 = "0";
                                            break;
                                        case "STAMP CHARGES":
                                            rate = "0.002";
                                            formula = "NetAmount";
                                            code1 = "0";
                                            break;
                                        default:
                                            rate = "0";
                                            formula = "None";
                                            code1 = "6";
                                            break;
                                    }
                                    edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "8" + "','" + "T" + "'," + Glcode + "," + ds.Tables["FillB_T"].Rows[x][0] + ",'" + ds.Tables["FillB_T"].Rows[x][1] + "'," + rate + ",'" + formula + "'," + code1 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                                    //edpcom.RunCommand("update Formula_Master set FICode='" + edpcom.CurrentFicode + "',GCode='" + edpcom.PCURRENT_GCODE + "',T_entry='" + t_entry + "',T_Type='T',GLCode=" + Glcode + ",slno=" + ds.Tables["FillB_T"].Rows[x][0] + ",Description='" + ds.Tables["FillB_T"].Rows[x][1] + "',TRate=" + rate + ",TOver='" + formula + "',TCode=" + code1 + ",RoundoffCode=" + 1 + ",EfftvStartDate='" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "',EfftvEndDate='" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "',EfftvClsVal=" + 0 + ",icode=" + assetclass + " where t_entry='" + t_entry + "' and Icode=" + assetclass + "and ficode='" + EDPCom.CurrentFicode + "' and gcode='" + EDPCom.PCURRENT_GCODE + "' and glcode=" + Glcode + " AND (EfftvStartDate ='" + startdt + "' ) AND (EfftvEndDate ='" + enddt + "')", edpcon.mycon, SQLT);
                                }
                                switch (desc)
                                {
                                    case "STT":
                                        rate = "0.125";
                                        formula = "NetAmount";
                                        code1 = "0";
                                        break;
                                    case "SERVICE TAX":
                                        rate = "10.30";
                                        formula = "BrokerageAmount";
                                        code1 = "5";
                                        break;
                                    case "TRN.OVER CHARGES":
                                        rate = "0.0035";
                                        formula = "NetAmount";
                                        code1 = "0";
                                        break;
                                    case "STAMP CHARGES":
                                        rate = "0.01";
                                        formula = "NetAmount";
                                        code1 = "0";
                                        break;
                                    default:
                                        rate = "0";
                                        formula = "None";
                                        code1 = "6";
                                        break;
                                }
                                edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "8" + "','" + "D" + "'," + Glcode + "," + ds.Tables["FillB_T"].Rows[x][0] + ",'" + ds.Tables["FillB_T"].Rows[x][1] + "'," + rate + ",'" + formula + "'," + code1 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                                //edpcom.RunCommand("update Formula_Master set FICode='" + edpcom.CurrentFicode + "',GCode='" + edpcom.PCURRENT_GCODE + "',T_entry='" + t_entry + "',T_Type='D',GLCode=" + Glcode + ",slno=" + ds.Tables["FillB_T"].Rows[x][0] + ",Description='" + ds.Tables["FillB_T"].Rows[x][1] + "',TRate=" + rate + ",TOver='" + formula + "',TCode=" + code1 + ",RoundoffCode=" + 1 + ",EfftvStartDate='" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "',EfftvEndDate='" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "',EfftvClsVal=" + 0 + ",icode=" + assetclass + " where t_entry='" + t_entry + "' and Icode=" + assetclass + "and ficode='" + EDPCom.CurrentFicode + "' and gcode='" + EDPCom.PCURRENT_GCODE + "' and glcode=" + Glcode + " AND (EfftvStartDate ='" + startdt + "' ) AND (EfftvEndDate ='" + enddt + "')", edpcon.mycon, SQLT);
                            }
                            if (assetclass != "3")
                                edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "8" + "','" + "T" + "'," + Glcode + "," + (x + 1) + ",'" + "BROKERAGE RATE" + "'," + 0.07 + ",'" + "NetAmount" + "'," + 0 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                            edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "8" + "','" + "D" + "'," + Glcode + "," + (x + 1) + ",'" + "BROKERAGE RATE" + "'," + 0.4 + ",'" + "NetAmount" + "'," + 0 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                        }
                        if (T_entry == "9")
                        {
                            for (x = 0; x <= ds.Tables["FillB_T1"].Rows.Count - 1; x++)
                            {
                                string desc = ds.Tables["FillB_T1"].Rows[x][1].ToString();
                                if (assetclass != "3")
                                {
                                    switch (desc)
                                    {
                                        case "STT":
                                            rate = "0.025";
                                            formula = "NetAmount";
                                            code1 = "0";
                                            break;
                                        case "SERVICE TAX":
                                            rate = "10.30";
                                            formula = "BrokerageAmount";
                                            code1 = "5";
                                            break;
                                        case "TRN.OVER CHARGES":
                                            rate = "0.0035";
                                            formula = "NetAmount";
                                            code1 = "0";
                                            break;
                                        case "STAMP CHARGES":
                                            rate = "0.002";
                                            formula = "NetAmount";
                                            code1 = "0";
                                            break;
                                        default:
                                            rate = "0";
                                            formula = "None";
                                            code1 = "6";
                                            break;
                                    }
                                    //com = new SqlCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "9" + "','" + "T" + "'," + Glcode + "," + ds.Tables["FillB_T1"].Rows[x][0] + ",'" + ds.Tables["FillB_T1"].Rows[x][1] + "'," + rate + ",'" + formula + "'," + code1 + "," + 1 + ")", con.mycon, SQLT);
                                    edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "9" + "','" + "T" + "'," + Glcode + "," + ds.Tables["FillB_T1"].Rows[x][0] + ",'" + ds.Tables["FillB_T1"].Rows[x][1] + "'," + rate + ",'" + formula + "'," + code1 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                                }
                                switch (desc)
                                {
                                    case "STT":
                                        rate = "0.125";
                                        formula = "NetAmount";
                                        code1 = "0";
                                        break;
                                    case "SERVICE TAX":
                                        rate = "10.30";
                                        formula = "BrokerageAmount";
                                        code1 = "5";
                                        break;
                                    case "TRN.OVER CHARGES":
                                        rate = "0.0035";
                                        formula = "NetAmount";
                                        code1 = "0";
                                        break;
                                    case "STAMP CHARGES":
                                        rate = "0.01";
                                        formula = "NetAmount";
                                        code1 = "0";
                                        break;
                                    default:
                                        rate = "0";
                                        formula = "None";
                                        code1 = "6";
                                        break;
                                }
                                edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "9" + "','" + "D" + "'," + Glcode + "," + ds.Tables["FillB_T1"].Rows[x][0] + ",'" + ds.Tables["FillB_T1"].Rows[x][1] + "'," + rate + ",'" + formula + "'," + code1 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                            }
                            if (assetclass != "3")
                                edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "9" + "','" + "T" + "'," + Glcode + "," + (x + 1) + ",'" + "BROKERAGE RATE" + "'," + 0 + ",'" + "NetAmount" + "'," + 0 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                            edpcom.RunCommand("insert into Formula_Master(FICode,GCode,T_entry,T_Type,GLCode,slno,Description,TRate,TOver,TCode,RoundoffCode,EfftvStartDate,EfftvEndDate,EfftvClsVal,icode) values('" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + "9" + "','" + "D" + "'," + Glcode + "," + (x + 1) + ",'" + "BROKERAGE RATE" + "'," + 0.4 + ",'" + "NetAmount" + "'," + 0 + "," + 1 + ",'" + edpcom.getSqlDateStr(edpcom.CURRCO_SDT) + "','" + edpcom.getSqlDateStr(edpcom.CURRCO_EDT) + "'," + 0 + "," + assetclass + ")", edpcon.mycon, SQLT);
                        }
                        SQLT.Commit();
                        edpcon.Close();
                    }

                }
                catch (Exception ex)
                {
                    EDPMessage.Show(ex.Message);
                    SQLT.Rollback();
                    edpcon.Close();
                }
            }
        }

        public static void AutoMessageFieldUpdate()
        {
            try
            {
                EDPConnection edpcon1 = new EDPConnection();
                SqlTransaction SQLT1;
                string str = "", str1 = "";
                common.ClearDataTable(ds.Tables["MsgInfo"]);
                edpcon1.Open();
                SQLT1 = edpcon1.mycon.BeginTransaction();
                com = new SqlCommand("select * from ALERT_MARKET_RATE", edpcon1.mycon, SQLT1);
                da.SelectCommand = com;
                bool bu1 = Convert.ToBoolean(da.Fill(ds, "MsgInfo"));
                // edpcon1.Close();
                if (bu1)
                {
                    try
                    {
                        if (ds.Tables["MsgInfo"].Rows[0][2].ToString() == "SINGLE PRODUCT")
                        {
                            str = "SELECT DISTINCT E.FICODE,E.GCODE,E.T_ENTRY,E.USER_VCH,IG.CO_NAME,IG.PCODE,E.VCH_DATE,E.BALQTY,E.EffectiveAmt/E.QTY [COST PRICE] FROM IGLMST IG,ETRAN E,ExngProduct EP,Ins_Mkt_Rate IMP";
                            str = str + " WHERE IG.FICODE='" + edpcom.CurrentFicode + "' AND IG.PCODE=" + Convert.ToDouble(ds.Tables["MsgInfo"].Rows[0][3].ToString()) + " AND IG.INV_TYPECODE=1 AND IG.FICODE=E.FICODE AND IG.PCODE=E.PCODE AND E.BALQTY<>0 AND IG.PCODE=EP.PCODE AND EP.SERIES='" + ds.Tables["MsgInfo"].Rows[0][9].ToString() + "'";

                            str1 = "SELECT DISTINCT IMP.PNAME,IG.PCODE,IMP.ClosingRate FROM Ins_Mkt_Rate IMP,ExngProduct EP,IGLMST IG WHERE ";
                            str1 = str1 + " IG.FICODE='" + edpcom.CurrentFicode + "' AND IG.PCODE=" + Convert.ToDouble(ds.Tables["MsgInfo"].Rows[0][3].ToString()) + " AND IG.FICODE=EP.FICODE AND IG.PCODE=EP.PCODE AND";
                            str1 = str1 + " EP.ExngSymbol=IMP.PName AND IMP.EffectiveDate=(SELECT MAX(EffectiveDate) FROM Ins_Mkt_Rate WHERE Asset_Type='" + ds.Tables["MsgInfo"].Rows[0][9].ToString() + "')";
                        }
                        else if (ds.Tables["MsgInfo"].Rows[0][2].ToString() == "CLASSIFICATION")
                        {
                            str = "SELECT DISTINCT E.FICODE,E.GCODE,E.T_ENTRY,E.USER_VCH,IG.CO_NAME,IG.PCODE,E.VCH_DATE,E.BALQTY,E.EffectiveAmt/E.QTY [COST PRICE] FROM IGLMST IG,ETRAN E,ExngProduct EP,Ins_Mkt_Rate IMP";
                            str = str + " WHERE IG.FICODE='" + edpcom.CurrentFicode + "' AND IG.CLASSCODE=" + Convert.ToDouble(ds.Tables["MsgInfo"].Rows[0][3].ToString()) + " AND IG.FICODE=E.FICODE AND IG.PCODE=E.PCODE AND E.BALQTY<>0";

                            str1 = "SELECT DISTINCT IMP.PNAME,IG.PCODE,IMP.ClosingRate FROM Ins_Mkt_Rate IMP,ExngProduct EP,IGLMST IG WHERE";
                            str1 = str1 + " IG.FICODE='" + edpcom.CurrentFicode + "' AND IG.CLASSCODE=" + Convert.ToDouble(ds.Tables["MsgInfo"].Rows[0][3].ToString()) + " AND IG.FICODE=EP.FICODE AND IG.PCODE=EP.PCODE AND";
                            str1 = str1 + " EP.ExngSymbol=IMP.PName AND IMP.EffectiveDate=(SELECT MAX(EffectiveDate) FROM Ins_Mkt_Rate WHERE Asset_Type='EQ')";
                        }
                        else
                        {
                            str = "SELECT DISTINCT E.FICODE,E.GCODE,E.T_ENTRY,E.USER_VCH,IG.CO_NAME,IG.PCODE,E.VCH_DATE,E.BALQTY,E.EffectiveAmt/E.QTY [COST PRICE] FROM IGLMST IG,ETRAN E,ExngProduct EP,Ins_Mkt_Rate IMP";
                            str = str + " WHERE IG.FICODE='" + edpcom.CurrentFicode + "' AND IG.INV_TYPECODE=" + Convert.ToDouble(ds.Tables["MsgDetail"].Rows[0][3].ToString()) + " AND IG.FICODE=E.FICODE AND IG.PCODE=E.PCODE AND E.BALQTY<>0";

                            str1 = "SELECT DISTINCT IMP.PNAME,IG.PCODE,IMP.ClosingRate FROM Ins_Mkt_Rate IMP,ExngProduct EP,IGLMST IG WHERE";
                            str1 = str1 + " IG.FICODE='" + edpcom.CurrentFicode + "' AND IG.INV_TYPECODE=" + Convert.ToDouble(ds.Tables["MsgDetail"].Rows[0][3].ToString()) + " AND IG.FICODE=EP.FICODE AND IG.PCODE=EP.PCODE AND";
                            str1 = str1 + " EP.ExngSymbol=IMP.PName AND IMP.EffectiveDate=(SELECT MAX(EffectiveDate) FROM Ins_Mkt_Rate WHERE Asset_Type='EQ')";
                        }
                        common.ClearDataTable(ds.Tables["MsgDetail"]);
                        //edpcon1.Open();
                        com = new SqlCommand(str, edpcon1.mycon, SQLT1);
                        da.SelectCommand = com;
                        bool bu2 = Convert.ToBoolean(da.Fill(ds, "MsgDetail"));
                        //edpcon1.Close();

                        common.ClearDataTable(ds.Tables["MsgRateDetail"]);
                        //edpcon1.Open();
                        com = new SqlCommand(str1, edpcon1.mycon, SQLT1);
                        da.SelectCommand = com;
                        bool bu3 = Convert.ToBoolean(da.Fill(ds, "MsgRateDetail"));
                        //edpcon1.Close();

                        DataView dtviewMessage;
                        DataTable dtp;
                        DataRow dro;

                        #region Create Data Table

                        dtp = new DataTable("DTLP");
                        dtp.Clear();
                        DataColumn dtp_FICODE = new DataColumn("FICODE");
                        DataColumn dtp_GCODE = new DataColumn("GCODE");
                        DataColumn dtp_T_ENTRY = new DataColumn("T_ENTRY");
                        DataColumn dtp_USER_VCH = new DataColumn("USER VCH");
                        DataColumn dtp_CO_NAME = new DataColumn("CO NAME");
                        DataColumn dtp_PCODE = new DataColumn("PCODE");
                        DataColumn dtp_VCH_DATE = new DataColumn("VCH DATE");
                        DataColumn dtp_HOLD_QTY = new DataColumn("HOLD QTY");
                        DataColumn dtp_COST_PRICE = new DataColumn("COST PRICE");
                        DataColumn dtp_TERGET_PRICE = new DataColumn("TERGET PRICE");
                        dtp.Columns.Add(dtp_FICODE);
                        dtp.Columns.Add(dtp_GCODE);
                        dtp.Columns.Add(dtp_T_ENTRY);
                        dtp.Columns.Add(dtp_USER_VCH);
                        dtp.Columns.Add(dtp_CO_NAME);
                        dtp.Columns.Add(dtp_PCODE);
                        dtp.Columns.Add(dtp_VCH_DATE);
                        dtp.Columns.Add(dtp_HOLD_QTY);
                        dtp.Columns.Add(dtp_COST_PRICE);
                        dtp.Columns.Add(dtp_TERGET_PRICE);

                        #endregion

                        if ((bu2 == true) && (bu3 == true))
                        {
                            if (ds.Tables["MsgInfo"].Rows[0][2].ToString() == "SINGLE PRODUCT")
                            {
                                //dtviewMessage = new DataView(ds.Tables["MsgDetail"]);
                                //dtviewMessage.RowFilter = "PCODE=" + Convert.ToInt32(getcode[i]) + " ";

                                if (ds.Tables["MsgInfo"].Rows[0][4].ToString().Trim() == ">")
                                {
                                    if (Convert.ToDouble(ds.Tables["MsgRateDetail"].Rows[0][2].ToString()) > Convert.ToDouble(ds.Tables["MsgInfo"].Rows[0][5].ToString()))
                                    {
                                        for (int i = 0; i <= ds.Tables["MsgDetail"].Rows.Count - 1; i++)
                                        {
                                            //if (Convert.ToDouble(ds.Tables["MsgInfo"].Rows[0][5].ToString()) > Convert.ToDouble(ds.Tables["MsgDetail"].Rows[i][5].ToString()))
                                            //{
                                            dro = dtp.NewRow();
                                            dro[0] = ds.Tables["MsgDetail"].Rows[i][0].ToString();
                                            dro[1] = ds.Tables["MsgDetail"].Rows[i][1].ToString();
                                            dro[2] = ds.Tables["MsgDetail"].Rows[i][2].ToString();
                                            dro[3] = ds.Tables["MsgDetail"].Rows[i][3].ToString();
                                            dro[4] = ds.Tables["MsgDetail"].Rows[i][4].ToString();
                                            dro[5] = ds.Tables["MsgDetail"].Rows[i][5].ToString();
                                            dro[6] = ds.Tables["MsgDetail"].Rows[i][6].ToString();
                                            dro[7] = ds.Tables["MsgDetail"].Rows[i][7].ToString();
                                            dro[8] = ds.Tables["MsgDetail"].Rows[i][8].ToString();
                                            dro[9] = ds.Tables["MsgInfo"].Rows[0][5].ToString();
                                            dtp.Rows.Add(dro);
                                            //}
                                        }
                                    }
                                }
                                else if (ds.Tables["MsgInfo"].Rows[0][4].ToString().Trim() == "<")
                                {
                                    if (Convert.ToDouble(ds.Tables["MsgRateDetail"].Rows[0][2].ToString()) < Convert.ToDouble(ds.Tables["MsgInfo"].Rows[0][5].ToString()))
                                    {
                                        for (int i = 0; i <= ds.Tables["MsgDetail"].Rows.Count - 1; i++)
                                        {
                                            //if (Convert.ToDouble(ds.Tables["MsgInfo"].Rows[0][5].ToString()) < Convert.ToDouble(ds.Tables["MsgDetail"].Rows[i][5].ToString()))
                                            //{
                                            dro = dtp.NewRow();
                                            dro[0] = ds.Tables["MsgDetail"].Rows[i][0].ToString();
                                            dro[1] = ds.Tables["MsgDetail"].Rows[i][1].ToString();
                                            dro[2] = ds.Tables["MsgDetail"].Rows[i][2].ToString();
                                            dro[3] = ds.Tables["MsgDetail"].Rows[i][3].ToString();
                                            dro[4] = ds.Tables["MsgDetail"].Rows[i][4].ToString();
                                            dro[5] = ds.Tables["MsgDetail"].Rows[i][5].ToString();
                                            dro[6] = ds.Tables["MsgDetail"].Rows[i][6].ToString();
                                            dro[7] = ds.Tables["MsgDetail"].Rows[i][7].ToString();
                                            dro[8] = ds.Tables["MsgDetail"].Rows[i][8].ToString();
                                            dro[9] = ds.Tables["MsgInfo"].Rows[0][5].ToString();
                                            dtp.Rows.Add(dro);
                                            // }
                                        }
                                    }
                                }
                                else if (ds.Tables["MsgInfo"].Rows[0][4].ToString().Trim() == ">=")
                                {
                                    if (Convert.ToDouble(ds.Tables["MsgRateDetail"].Rows[0][2].ToString()) >= Convert.ToDouble(ds.Tables["MsgInfo"].Rows[0][5].ToString()))
                                    {
                                        for (int i = 0; i <= ds.Tables["MsgDetail"].Rows.Count - 1; i++)
                                        {
                                            //if (Convert.ToDouble(ds.Tables["MsgInfo"].Rows[0][5].ToString()) >= Convert.ToDouble(ds.Tables["MsgDetail"].Rows[i][5].ToString()))
                                            //{
                                            dro = dtp.NewRow();
                                            dro[0] = ds.Tables["MsgDetail"].Rows[i][0].ToString();
                                            dro[1] = ds.Tables["MsgDetail"].Rows[i][1].ToString();
                                            dro[2] = ds.Tables["MsgDetail"].Rows[i][2].ToString();
                                            dro[3] = ds.Tables["MsgDetail"].Rows[i][3].ToString();
                                            dro[4] = ds.Tables["MsgDetail"].Rows[i][4].ToString();
                                            dro[5] = ds.Tables["MsgDetail"].Rows[i][5].ToString();
                                            dro[6] = ds.Tables["MsgDetail"].Rows[i][6].ToString();
                                            dro[7] = ds.Tables["MsgDetail"].Rows[i][7].ToString();
                                            dro[8] = ds.Tables["MsgDetail"].Rows[i][8].ToString();
                                            dro[9] = ds.Tables["MsgInfo"].Rows[0][5].ToString();
                                            dtp.Rows.Add(dro);
                                            //}
                                        }
                                    }
                                }
                                else if (ds.Tables["MsgInfo"].Rows[0][4].ToString().Trim() == "<=")
                                {
                                    if (Convert.ToDouble(ds.Tables["MsgRateDetail"].Rows[0][2].ToString()) <= Convert.ToDouble(ds.Tables["MsgInfo"].Rows[0][5].ToString()))
                                    {
                                        for (int i = 0; i <= ds.Tables["MsgDetail"].Rows.Count - 1; i++)
                                        {
                                            //if (Convert.ToDouble(ds.Tables["MsgInfo"].Rows[0][5].ToString()) <= Convert.ToDouble(ds.Tables["MsgDetail"].Rows[i][5].ToString()))
                                            //{
                                            dro = dtp.NewRow();
                                            dro[0] = ds.Tables["MsgDetail"].Rows[i][0].ToString();
                                            dro[1] = ds.Tables["MsgDetail"].Rows[i][1].ToString();
                                            dro[2] = ds.Tables["MsgDetail"].Rows[i][2].ToString();
                                            dro[3] = ds.Tables["MsgDetail"].Rows[i][3].ToString();
                                            dro[4] = ds.Tables["MsgDetail"].Rows[i][4].ToString();
                                            dro[5] = ds.Tables["MsgDetail"].Rows[i][5].ToString();
                                            dro[6] = ds.Tables["MsgDetail"].Rows[i][6].ToString();
                                            dro[7] = ds.Tables["MsgDetail"].Rows[i][7].ToString();
                                            dro[8] = ds.Tables["MsgDetail"].Rows[i][8].ToString();
                                            dro[9] = ds.Tables["MsgInfo"].Rows[0][5].ToString();
                                            dtp.Rows.Add(dro);
                                            //}
                                        }
                                    }
                                }
                            }
                            #region Insert inti ALERT_MARKET_RATE_DETAILS Table

                            // edpcon1.Open();

                            str = "Delete From ALERT_MARKET_RATE_DETAILS";
                            com = new SqlCommand(str, edpcon1.mycon, SQLT1);
                            com.ExecuteNonQuery();
                            int SL = 0;
                            for (int j = 0; j <= dtp.Rows.Count - 1; j++)
                            {
                                SL = j + 1;
                                str = "Insert into ALERT_MARKET_RATE_DETAILS(MRDA_ID, MRA_ID, FICODE, GCODE, T_Entry, USER_VCH, CO_NAME, PCODE, VCH_DATE, BALQTY, COSTPRICE, TMKT_PRICE) values(" + SL + ",'MR1','" + dtp.Rows[j][0].ToString().Trim() + "','" + dtp.Rows[j][1].ToString().Trim() + "','" + dtp.Rows[j][2].ToString() + "','" + dtp.Rows[j][3].ToString() + "', '" + dtp.Rows[j][4].ToString() + "'," + Convert.ToDouble(dtp.Rows[j][5].ToString()) + ",'" + edpcom.getSqlDateStr(Convert.ToDateTime(dtp.Rows[j][6].ToString())) + "'," + Convert.ToDouble(dtp.Rows[j][7].ToString()) + "," + Convert.ToDouble(dtp.Rows[j][8].ToString()) + "," + Convert.ToDouble(dtp.Rows[j][9].ToString()) + ")";
                                com = new SqlCommand(str, edpcon1.mycon, SQLT1);
                                com.ExecuteNonQuery();
                            }
                            SQLT1.Commit();
                            edpcon1.Close();
                            #endregion
                        }
                    }
                    catch
                    {
                        EDPMessage.Show("Can't save the Alert record.", "Message");
                        SQLT1.Rollback();
                    }
                }
            }
            catch
            {
            }
        }

        public static void AutoDisplayMessage()
        {
            try
            {
                EDPConnection edpcon1 = new EDPConnection();
                SqlTransaction SQLT1;
                DataTable dtDis = new DataTable();
                string str = "", str1 = "";
                common.ClearDataTable(ds.Tables["AlertFlag"]);
                edpcon1.Open();
                com = new SqlCommand("SELECT DISTINCT AM.ALERT_ACTIVE,ALERT_NAME FROM ALERT_MASTER AM,ALERT_MARKET_RATE AMR WHERE AMR.MRA_ID='MR1' AND AMR.ALERT_ID='A1' AND AMR.ALERT_ID=AM.ALERT_ID", edpcon1.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "AlertFlag");
                edpcon1.Close();
                if (Convert.ToBoolean(ds.Tables["AlertFlag"].Rows[0][0].ToString()) == true)
                {
                    common.ClearDataTable(dtDis);
                    edpcon1.Open();
                    SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM ALERT_MARKET_RATE_DETAILS", edpcon1.mycon);
                    da1.Fill(dtDis);
                    edpcon1.Close();
                    if (dtDis.Rows.Count > 0)
                    {
                        //frmAlertDisplay ad = new frmAlertDisplay(ds.Tables["AlertFlag"].Rows[0][1].ToString(), dtDis);
                        //ad.ShowDialog();
                    }
                }

            }
            catch { }
        }

        public static string BalQtyCalCulation(string Qty, int Pcode, int UnitCode, int unitseries)
        {

            try
            {
                if (unitseries == 0)
                    return Qty;
                else
                {
                    double totqty = 0;
                    string[] disqty = new string[] { };
                    disqty = Qty.Trim().Split('/');
                    DataTable dtSeries = edpcom.GetDatatable("Select Distinct Sm_Name from UnitSeriesMaster where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and SM_ID=" + unitseries + " and UCODE=" + UnitCode + "");
                    if (dtSeries.Rows.Count > 0)
                    {
                        string[] a = new string[] { };
                        a = dtSeries.Rows[0][0].ToString().Trim().Split('-');
                        if (a.Length > 0)
                        {
                            for (int s = 0; s < a.Length; s++)
                            {
                                DataTable dt = edpcom.GetDatatable("select Distinct r.Conv_Fig *" + disqty[s] + " from UnitRelationMaster r where r.ficode='" + edpcom.CurrentFicode + "' and r.gcode='" + edpcom.PCURRENT_GCODE + "' and r.SM_ID=" + unitseries + " and r.pcode=" + Pcode + " and UnitF=(select UCODE from unit where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and UDESC='" + a[s].Trim() + "') and UnitT=" + UnitCode + " ");
                                totqty = totqty + Convert.ToDouble(dt.Rows[0][0]);
                            }
                        }
                    }
                    return totqty.ToString();
                }
            }
            catch { return Qty; }
        }
        public static string BalQtySlashForm(string Qty, int Pcode, int UnitCode, int unitseries)
        {
            try
            {
                string totqty = "";
                string hello = "";
                double quentity = Convert.ToDouble(Qty);
                string[] disqty = new string[] { };
                disqty = Qty.Trim().Split('/');
                if (unitseries == 0)
                    return Qty;
                else
                {
                    DataTable dtSeries = edpcom.GetDatatable("Select Distinct Sm_Name from UnitSeriesMaster where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and SM_ID=" + unitseries + " and UCODE=" + UnitCode + "");
                    if (dtSeries.Rows.Count > 0)
                    {
                        string[] a = new string[] { };
                        a = dtSeries.Rows[0][0].ToString().Trim().Split('-');
                        //if (a.Length == 0)
                        //    return Qty;
                        hello = dtSeries.Rows[0][0].ToString().Trim();
                        DataTable dt = edpcom.GetDatatable("select Distinct r.Conv_Fig,r.UnitF,r.UnitT,u.UDESC  from UnitRelationMaster r,unit u where r.ficode=u.ficode and r.gcode=u.gcode and r.unitF=u.ucode and  r.ficode='" + edpcom.CurrentFicode + "' and r.gcode='" + edpcom.PCURRENT_GCODE + "' and r.SM_ID=" + unitseries + " and r.pcode=" + Pcode + "  and unitT=" + UnitCode + " and r.Conv_Fig>0 order by r.Conv_Fig desc");
                        if (dt.Rows.Count > 0)
                        {
                            for (int q = 0; q < dt.Rows.Count; q++)
                            {
                                Int32 qq = 0;
                                qq = Convert.ToInt32(quentity / Convert.ToDouble(dt.Rows[q][0]));
                                hello = hello.Replace(dt.Rows[q][3].ToString().Trim(), qq.ToString());
                                quentity = (quentity % Convert.ToDouble(dt.Rows[q][0]));

                            }
                            hello = hello.Replace('-', '/');

                        }
                    }
                    return hello;

                }
            }
            catch { return Qty; }
        }

        public static string BalQtySlashForm(string Qty, int Pcode)
        {
            try
            {
                int UnitCode = 0, unitseries = 0;

                DataTable userise = edpcom.GetDatatable("select distinct Ucode,Series_Id from iglmst where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and pcode=" + Pcode + "");
                if (userise.Rows.Count > 0)
                {
                    UnitCode = Convert.ToInt32(userise.Rows[0][0]);
                    unitseries = Convert.ToInt32(userise.Rows[0][1]);
                }
                string totqty = "";
                string hello = "";
                double quentity = Convert.ToDouble(Qty);
                string[] disqty = new string[] { };
                disqty = Qty.Trim().Split('/');
                if (unitseries == 0)
                    return Qty;
                else
                {
                    DataTable dtSeries = edpcom.GetDatatable("Select Distinct Sm_Name from UnitSeriesMaster where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and SM_ID=" + unitseries + " and UCODE=" + UnitCode + "");
                    if (dtSeries.Rows.Count > 0)
                    {
                        string[] a = new string[] { };
                        a = dtSeries.Rows[0][0].ToString().Trim().Split('-');
                        //if (a.Length == 0)
                        //    return Qty;
                        hello = dtSeries.Rows[0][0].ToString().Trim();
                        hello = hello.Replace('-', '~');
                        DataTable dt = edpcom.GetDatatable("select Distinct r.Conv_Fig,r.UnitF,r.UnitT,u.UDESC  from UnitRelationMaster r,unit u where r.ficode=u.ficode and r.gcode=u.gcode and r.unitF=u.ucode and  r.ficode='" + edpcom.CurrentFicode + "' and r.gcode='" + edpcom.PCURRENT_GCODE + "' and r.SM_ID=" + unitseries + " and r.pcode=" + Pcode + "  and unitT=" + UnitCode + " and r.Conv_Fig>0 order by r.Conv_Fig desc");
                        if (dt.Rows.Count > 0)
                        {
                            for (int q = 0; q < dt.Rows.Count; q++)
                            {
                                decimal qq1 = 0;
                                qq1 = Convert.ToDecimal(quentity / Convert.ToDouble(dt.Rows[q][0]));
                                string[] qq = new string[] { };
                                qq = qq1.ToString().Trim().Split('.');
                                hello = hello.Replace(dt.Rows[q][3].ToString().Trim(), qq[0].ToString());
                                quentity = (quentity % Convert.ToDouble(dt.Rows[q][0]));
                            }
                            hello = hello.Replace('~', '/');

                        }
                    }
                    return hello;

                }
            }
            catch { return Qty; }
        }

        public static string BalQtySlashForm(string Qty, int Pcode, SqlConnection Con, SqlTransaction SqlT)
        {
            try
            {
                int UnitCode = 0, unitseries = 0;

                DataTable userise = edpcom.GetDatatable("select distinct Ucode,Series_Id from iglmst where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and pcode=" + Pcode + "", Con, SqlT);
                if (userise.Rows.Count > 0)
                {
                    UnitCode = Convert.ToInt32(userise.Rows[0][0]);
                    unitseries = Convert.ToInt32(userise.Rows[0][1]);
                }
                string totqty = "";
                string hello = "";
                double quentity = Convert.ToDouble(Qty);
                string[] disqty = new string[] { };
                disqty = Qty.Trim().Split('/');
                if (unitseries == 0)
                    return Qty;
                else
                {
                    DataTable dtSeries = edpcom.GetDatatable("Select Distinct Sm_Name from UnitSeriesMaster where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and SM_ID=" + unitseries + " and UCODE=" + UnitCode + "", Con, SqlT);
                    if (dtSeries.Rows.Count > 0)
                    {
                        string[] a = new string[] { };
                        a = dtSeries.Rows[0][0].ToString().Trim().Split('-');
                        //if (a.Length == 0)
                        //    return Qty;
                        hello = dtSeries.Rows[0][0].ToString().Trim();
                        hello = hello.Replace('-', '~');
                        DataTable dt = edpcom.GetDatatable("select Distinct r.Conv_Fig,r.UnitF,r.UnitT,u.UDESC  from UnitRelationMaster r,unit u where r.ficode=u.ficode and r.gcode=u.gcode and r.unitF=u.ucode and  r.ficode='" + edpcom.CurrentFicode + "' and r.gcode='" + edpcom.PCURRENT_GCODE + "' and r.SM_ID=" + unitseries + " and r.pcode=" + Pcode + "  and unitT=" + UnitCode + " and r.Conv_Fig>0 order by r.Conv_Fig desc", Con, SqlT);
                        if (dt.Rows.Count > 0)
                        {
                            for (int q = 0; q < dt.Rows.Count; q++)
                            {
                                decimal qq1 = 0;
                                qq1 = Convert.ToDecimal(quentity / Convert.ToDouble(dt.Rows[q][0]));
                                string[] qq = new string[] { };
                                qq = qq1.ToString().Trim().Split('.');
                                hello = hello.Replace(dt.Rows[q][3].ToString().Trim(), qq[0].ToString());
                                quentity = (quentity % Convert.ToDouble(dt.Rows[q][0]));
                            }
                            hello = hello.Replace('~', '/');

                        }
                    }
                    return hello;

                }
            }
            catch { return Qty; }
        }

        public static string BalQtyCalCulation(string Qty, int Pcode)
        {
            int UnitCode = 0, unitseries = 0;
            try
            {
                DataTable userise = new Edpcom.EDPCommon().GetDatatable("select distinct Ucode,Series_Id from iglmst where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and pcode=" + Pcode + "");
                if (userise.Rows.Count > 0)
                {
                    UnitCode = Convert.ToInt32(userise.Rows[0][0]);
                    unitseries = Convert.ToInt32(userise.Rows[0][1]);
                }
                if (unitseries == 0)
                    return Qty;
                else
                {
                    double totqty = 0;
                    string[] disqty = new string[] { };
                    disqty = Qty.Trim().Split('/');
                    DataTable dtSeries = edpcom.GetDatatable("Select Distinct Sm_Name from UnitSeriesMaster where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and SM_ID=" + unitseries + " and UCODE=" + UnitCode + "");
                    if (dtSeries.Rows.Count > 0)
                    {
                        string[] a = new string[] { };
                        a = dtSeries.Rows[0][0].ToString().Trim().Split('-');
                        if (a.Length > 0)
                        {
                            for (int s = 0; s < a.Length; s++)
                            {
                                DataTable dt = edpcom.GetDatatable("select Distinct r.Conv_Fig *" + disqty[s] + " from UnitRelationMaster r where r.ficode='" + edpcom.CurrentFicode + "' and r.gcode='" + edpcom.PCURRENT_GCODE + "' and r.SM_ID=" + unitseries + " and r.pcode=" + Pcode + " and UnitF=(select UCODE from unit where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and UDESC='" + a[s].Trim() + "') and UnitT=" + UnitCode + " ");
                                totqty = totqty + Convert.ToDouble(dt.Rows[0][0]);
                            }
                        }
                    }
                    return totqty.ToString();
                }
            }
            catch { return Qty; }
        }

        public static string BalQtyCalCulation(string Qty, int Pcode, SqlConnection Con, SqlTransaction SqlT)
        {
            int UnitCode = 0, unitseries = 0;
            try
            {
                DataTable userise = new Edpcom.EDPCommon().GetDatatable("select distinct Ucode,Series_Id from iglmst where ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and pcode=" + Pcode + "", Con, SqlT);
                if (userise.Rows.Count > 0)
                {
                    UnitCode = Convert.ToInt32(userise.Rows[0][0]);
                    unitseries = Convert.ToInt32(userise.Rows[0][1]);
                }
                if (unitseries == 0)
                    return Qty;
                else
                {
                    double totqty = 0;
                    string[] disqty = new string[] { };
                    disqty = Qty.Trim().Split('/');
                    DataTable dtSeries = edpcom.GetDatatable("Select Distinct Sm_Name from UnitSeriesMaster where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and SM_ID=" + unitseries + " and UCODE=" + UnitCode + "", Con, SqlT);
                    if (dtSeries.Rows.Count > 0)
                    {
                        string[] a = new string[] { };
                        a = dtSeries.Rows[0][0].ToString().Trim().Split('-');
                        if (a.Length > 0)
                        {
                            for (int s = 0; s < a.Length; s++)
                            {
                                DataTable dt = edpcom.GetDatatable("select Distinct r.Conv_Fig *" + disqty[s] + " from UnitRelationMaster r where r.ficode='" + edpcom.CurrentFicode + "' and r.gcode='" + edpcom.PCURRENT_GCODE + "' and r.SM_ID=" + unitseries + " and r.pcode=" + Pcode + " and UnitF=(select UCODE from unit where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and UDESC='" + a[s].Trim() + "') and UnitT=" + UnitCode + "", Con, SqlT);
                                totqty = totqty + Convert.ToDouble(dt.Rows[0][0]);
                            }
                        }
                    }
                    return totqty.ToString();
                }
            }
            catch { return Qty; }
        }


        public static bool OpenVchlock(string TE, string VchType, string Uservch, int vn, string TransType, SqlConnection SQLCON, SqlTransaction SQT)
        {
            bool flagReturn = false;
            try
            {
                SqlCommand cmd1 = new SqlCommand();
                SqlDataAdapter da1 = new SqlDataAdapter();
                DataSet ds1 = new DataSet();
                Edpcom.EDPConnection edpcon1 = new Edpcom.EDPConnection();

                int vno = vn, UserCode = 0;
                string user_vch = Uservch, vtype = VchType, Trans_Type = TransType, Tentry = TE;
                bool CancelFlag = false;

                edpcon1.Open();
                if (TransType.ToUpper().Trim() == "ADD")
                {
                    cmd1 = new SqlCommand("insert into vchlock(Ficode,GCODE,VTYPE,T_ENTRY,VOUCHER,USER_VCH,USERCODE,Trans_Type,Cancel_Flag) VALUES(" +
                    " '" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + VchType + "','" + Tentry + "'," + vno + ",'" + Uservch + "','" + edpcom.UserDesc + "','" + Trans_Type + "','" + CancelFlag + "')", edpcon1.mycon);
                    cmd1.ExecuteNonQuery();
                }

                if (TransType.ToUpper().Trim() == "MODIFY")
                {
                    //cmd1 = new SqlCommand("delete from vchlock where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry ='" + Tentry + "' and voucher=" + vno + " and user_vch='" + user_vch + "' and USERCODE=" + edpcom.UserDesc + "", edpcon1.mycon);
                    //cmd1.ExecuteNonQuery();

                    cmd1 = new SqlCommand("select Trans_Type from vchlock where T_entry='" + Tentry + "' and ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and VOUCHER=" + vno + " and USER_VCH='" + user_vch + "'", edpcon1.mycon);
                    da1.SelectCommand = cmd1;
                    ClearDataTable(ds1.Tables["dsUserVCH"]);
                    if (Convert.ToBoolean(da1.Fill(ds1, "dsUserVCH")))
                    {
                        if (Convert.ToString(ds1.Tables["dsUserVCH"].Rows[0][0]).Trim() == "MODIFY")
                            EDPMessage.Show("This Document... is modifying please wait or try later.", "Message");

                        if (Convert.ToString(ds1.Tables["dsUserVCH"].Rows[0][0]).Trim() == "DELETE")
                            EDPMessage.Show("This Document... is deleting please wait or try later.", "Message");
                        flagReturn = true;
                    }
                    else
                    {
                        cmd1 = new SqlCommand("insert into vchlock(Ficode,GCODE,VTYPE,T_ENTRY,VOUCHER,USER_VCH,USERCODE,Trans_Type,Cancel_Flag) VALUES(" +
                        " '" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + VchType + "','" + Tentry + "'," + vno + ",'" + Uservch + "'," + edpcom.UserDesc + ",'" + Trans_Type + "','" + CancelFlag + "')", edpcon1.mycon);
                        cmd1.ExecuteNonQuery();
                    }
                }

                if (TransType.ToUpper().Trim() == "DELETE")
                {
                    cmd1 = new SqlCommand("select Trans_Type from vchlock where T_entry='" + Tentry + "' and ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and VOUCHER=" + vno + " and USER_VCH='" + user_vch + "'", edpcon1.mycon);
                    da1.SelectCommand = cmd1;
                    ClearDataTable(ds1.Tables["dsUserVCH"]);
                    if (Convert.ToBoolean(da1.Fill(ds1, "dsUserVCH")))
                    {
                        if (Convert.ToString(ds1.Tables["dsUserVCH"].Rows[0][0]).Trim() == "MODIFY")
                            EDPMessage.Show("This Document... is modifying please wait or try later.", "Message");

                        if (Convert.ToString(ds1.Tables["dsUserVCH"].Rows[0][0]).Trim() == "DELETE")
                            EDPMessage.Show("This Document... is deleting please wait or try later.", "Message");
                        flagReturn = true;
                    }
                    else
                    {
                        cmd1 = new SqlCommand("insert into vchlock(Ficode,GCODE,VTYPE,T_ENTRY,VOUCHER,USER_VCH,USERCODE,Trans_Type,Cancel_Flag) VALUES(" +
                        " '" + edpcom.CurrentFicode + "','" + edpcom.PCURRENT_GCODE + "','" + VchType + "','" + Tentry + "'," + vno + ",'" + Uservch + "'," + edpcom.UserDesc + ",'" + Trans_Type + "','" + CancelFlag + "')", edpcon1.mycon);
                        cmd1.ExecuteNonQuery();
                    }
                }

                edpcon1.Close();
            }
            catch { }
            return flagReturn;
        }

        public static void CloseVchlock(string TE, string VchType, string Uservch, int vn, string TransType, Int64 desc, SqlConnection SQLCON, SqlTransaction SQT)
        {
            try
            {
                SqlCommand cmd2 = new SqlCommand();
                Edpcom.EDPConnection edpcon1 = new Edpcom.EDPConnection();

                int vno = vn;
                Int64 UserCode = desc;
                string user_vch = Uservch, vtype = VchType, Trans_Type = TransType, Tentry = TE;
                bool CancelFlag = false;

                edpcon1.Open();
                cmd2 = new SqlCommand("delete from vchlock where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry ='" + Tentry + "' and voucher=" + vno + " and user_vch='" + user_vch + "' ", edpcon1.mycon);
                cmd2.ExecuteNonQuery();
                edpcon1.Close();
            }
            catch { }
        }

        public static void CommitVchlock(string TE, string Uservch, int vn, string TransType, Int64 des_code, int type)
        {
            try
            {
                SqlCommand cmd2 = new SqlCommand();
                Edpcom.EDPConnection edpcon1 = new Edpcom.EDPConnection();
                DataSet ds1 = new DataSet();
                SqlDataAdapter da1 = new SqlDataAdapter();

                int vno = vn, UserCode = 0; Int64 descode = des_code;
                string user_vch = Uservch, Trans_Type = TransType, Tentry = TE;
                bool CancelFlag = false;
                edpcon1.Open();
                ClearDataTable(ds1.Tables["Status"]);
                cmd2 = new SqlCommand("select Status from vchlock where T_entry='" + Tentry + "' and ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and VOUCHER=" + vno + " and USER_VCH='" + user_vch + "'and USERCODE=" + edpcom.PCURRENT_GCODE + " and Trans_Type='ADD' and Des_Code='" + descode + "' and Status='PENDING'", edpcon1.mycon);
                da1.SelectCommand = cmd2;
                da1.Fill(ds1, "Status");
                if (ds1.Tables["status"].Rows.Count > 0)
                {
                    if (type == 1)
                    {
                        //cmd2 = new SqlCommand("delete from vchlock where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry ='" + Tentry + "' and voucher=" + vno + " and user_vch='" + user_vch + "' and USERCODE=" + edpcom.PCURRENT_USER + " and Trans_Type='ADD' and Des_Code='" + descode + "'", edpcon1.mycon);
                        cmd2 = new SqlCommand("delete from vchlock where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry ='" + Tentry + "' and voucher=" + vno + " and user_vch='" + user_vch + "' and Trans_Type='ADD' and Des_Code='" + descode + "'", edpcon1.mycon);
                        cmd2.ExecuteNonQuery();
                    }

                }
                else
                {
                    if (Trans_Type == "ADD")
                        //cmd2 = new SqlCommand("delete from vchlock where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry ='" + Tentry + "' and voucher=" + vno + " and user_vch='" + user_vch + "' and USERCODE=" + edpcom.PCURRENT_USER + " and Trans_Type='ADD' and Des_Code='" + descode + "'", edpcon1.mycon);
                        cmd2 = new SqlCommand("delete from vchlock where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry ='" + Tentry + "' and voucher=" + vno + " and user_vch='" + user_vch + "' and  Trans_Type='ADD' and Des_Code='" + descode + "'", edpcon1.mycon);
                    else if (Trans_Type == "Close")
                        //cmd2 = new SqlCommand("update vchlock set Status='PENDING' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry ='" + Tentry + "' and voucher=" + vno + " and user_vch='" + user_vch + "' and USERCODE=" + edpcom.PCURRENT_USER + " and Trans_Type='ADD' and Des_Code='" + descode + "'", edpcon1.mycon);
                        cmd2 = new SqlCommand("update vchlock set Status='PENDING' where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and t_entry ='" + Tentry + "' and voucher=" + vno + " and user_vch='" + user_vch + "'  and Trans_Type='ADD' and Des_Code='" + descode + "'", edpcon1.mycon);
                    cmd2.ExecuteNonQuery();
                }
                edpcon1.Close();
            }
            catch { }
        }
        public static void setposition(int flug)
        {
            if (flug == 1)
            {
                possition = 500;
                width = 500;
                height = 300;
            }
        }

        public static string GetTentry(string Description)
        {
            string t_entry = "";
            Edpcom.EDPCommon com = new Edpcom.EDPCommon();
            Edpcom.EDPConnection con = new Edpcom.EDPConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("select T_Entry from TypeMast where ficode='" + com.CurrentFicode + "' and gcode='" + com.PCURRENT_GCODE + "' and TypeName='" + Description + "'", con.mycon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Desc");
            if (ds.Tables["Desc"].Rows.Count > 0)
            {
                t_entry = Convert.ToString(ds.Tables["Desc"].Rows[0]["T_Entry"]);
            }
            return t_entry;
        }
        public static DataTable GetTentryName(string tentry)
        {
            Edpcom.EDPCommon com = new Edpcom.EDPCommon();
            DataTable dt =edpcom.GetDatatable("Select * from TypeMast where ficode='" + com.CurrentFicode + "' and gcode='" + com.PCURRENT_GCODE + "' and T_Entry in(" + tentry + ")  ");
            return dt;
        }
    }
}
