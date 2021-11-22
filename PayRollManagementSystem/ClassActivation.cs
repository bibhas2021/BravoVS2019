using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Edpcom;
using EDPComponent;
using System.Data.SqlClient;
using EDPMessageBox;
using Microsoft.VisualBasic;


namespace PayRollManagementSystem
{
    class ClassActivation
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable DT_TRANS = new DataTable();
        DataTable DT_SESSION = new DataTable();
        DataTable DT_COMPANY = new DataTable();
        bool ChkDaysError = false;
       
        public void Check_All_Transactions()
        {
            try
            {
                Master_Transaction();
                //Checking_Transactions();
            }
            catch { }
        }

      
        public void Chk_Days_Error(bool CDE)
        {
            ChkDaysError = CDE;
            Master_Transaction();
            //string TTN = Convert.ToString(Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR").GetValue("EC_TRANS"));
            //string TSN = Convert.ToString(Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR").GetValue("EC_SESSION"));
            //string TCN = Convert.ToString(Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ERROR").GetValue("EC_COMPANY"));

            string TTN = Convert.ToString(edpcom.GetFromRegisrty("EC_TRANS", "SOFTWARE\\DATARAM"));
            string TSN = Convert.ToString(edpcom.GetFromRegisrty("EC_SESSION", "SOFTWARE\\DATARAM"));
            string TCN = Convert.ToString(edpcom.GetFromRegisrty("EC_COMPANY", "SOFTWARE\\DATARAM"));

            Int64 TotalTrans = 0, TotalSession = 0, TotalCompany = 0;
            Int64 ETN = 0, ESN = 0, ECN = 0;

            #region Transaction Checking           
            string ss = edpcom.GetresultS("SELECT COUNT(I.FICODE) [TOTAL TRANS] FROM IDATA I WHERE I.FICODE='" + edpcom.CurrentFicode + "' AND I.GCODE='" + edpcom.PCURRENT_GCODE + "' AND I.T_ENTRY IN('8','9','n','a','OP','SI','SO','SR','PR')");
            if (Information.IsNumeric(ss) == true)
                TotalTrans = Convert.ToInt64(ss);
            ss = "";
            ss = edpcom.GetresultS("SELECT COUNT(D.FICODE) [TOTAL TRANS] FROM DATA D WHERE D.FICODE='" + edpcom.CurrentFicode + "' AND D.GCODE='" + edpcom.PCURRENT_GCODE + "' AND D.T_ENTRY IN('1','2','3','4','5','6','7')");
            if (Information.IsNumeric(ss) == true)
                TotalTrans = TotalTrans + Convert.ToInt64(ss);
            string str = "";            

            DataView dv = new DataView(DT_TRANS);
            dv.RowFilter = "Trans_Code='" + TTN.ToString() + "'";
            if (dv.Count > 0)
                ETN = Convert.ToInt64(dv[0][1]);

            if (TotalTrans >= ETN)
            {
                if (ETN >= 499999)
                {
                    str = "A0499999";
                    goto pp;
                }
                else if (ETN >= 199999 && ETN < 499999)
                {
                    str = "A0199999";
                    goto pp;
                }
                else if (ETN >= 99999 && ETN < 199999)
                {
                    str = "A0099999";
                    goto pp;
                }
                else if (ETN >= 9999 && ETN < 99999)
                {
                    str = "A0009999";
                    goto pp;
                }
                else if (ETN >= 5000 && ETN < 9999)
                {
                    str = "A0005000";
                    goto pp;
                }
                else if (ETN >= 1000 && ETN < 5000)
                {
                    str = "A0001000";
                    goto pp;
                }
                else if (ETN >= 500 && ETN < 1000)
                {
                    str = "A0000500";
                    goto pp;
                }
                else if (ETN >= 100 && ETN < 500)
                {
                    str = "A0000100";
                    goto pp;
                }
            }
            # endregion
             
            #region Session Checking

            dv = new DataView(DT_SESSION);
            dv.RowFilter = "Session_Code='" + TSN.ToString() + "'";
            if (dv.Count > 0)
                ESN = Convert.ToInt64(dv[0][1]);

            if (edpcom.CURRENTSESSION >= ESN)
            {
                if (ESN >= 200 && ESN < 1000)
                {
                    str = "B0000200";
                    goto pp;
                }
                else if (ESN >= 1000 && ESN < 5000)
                {
                    str = "B0001000";
                    goto pp;
                }
                else if (ESN >= 5000 && ESN < 10000)
                {
                    str = "B0005000";
                    goto pp;
                }
                else if (ESN >= 10000 && ESN < 99999)
                {
                    str = "B0099999";
                    goto pp;
                }
            }
            # endregion

            #region Company Checking
            dv = new DataView(DT_COMPANY);
            dv.RowFilter = "Company_Code='" + TCN.ToString() + "'";
            if (dv.Count > 0)
                ECN = Convert.ToInt64(dv[0][1]);

            ss = edpcom.GetresultS("SELECT COUNT(FICODE) [TOTAL COM] FROM Company");
            if (Information.IsNumeric(ss) == true)
                TotalCompany = Convert.ToInt64(ss);

            if (TotalCompany >= ECN)
            {
                if (ECN >= 11 && ECN < 41)
                {
                    str = "C0000011";
                    goto pp;
                }
                else if (ECN >= 41 && ECN < 91)
                {
                    str = "C0000041";
                    goto pp;
                }
                else if (ECN >= 91 && ECN < 125)
                {
                    str = "C0000091";
                    goto pp;
                }
            }
            #endregion

        pp:
            //EDPMessage.Show(str);
            if (str != "")
            {
                ProductKey PK = new ProductKey();
                PK.GetKeyCode(str);
                PK.ShowDialog();
            }
            else
            {
                if (!ChkDaysError)
                {
                    str = "A0000100";
                    ProductKey PK = new ProductKey();
                    PK.GetKeyCode(str);
                    PK.ShowDialog();
                }
            }
            
        }

        public void Master_Transaction()
        {            
            try
            {
                int RC = 0;
                #region Transaction Entry In DataTable
                DT_TRANS.Columns.Add("Trans_Code", typeof(string));
                DT_TRANS.Columns.Add("Trans_Value", typeof(string));
                DT_TRANS.Columns.Add("Trans_Comment", typeof(string));
                DT_TRANS.Columns.Add("SL", typeof(string));

                DT_TRANS.Rows.Add();
                DT_TRANS.Rows[RC][0] = "A0000100";
                DT_TRANS.Rows[RC][1] = "100";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 100";
                DT_TRANS.Rows[RC][3] = "0";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0000500";
                DT_TRANS.Rows[RC][1] = "500";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 500";
                DT_TRANS.Rows[RC][3] = "1";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0001000";
                DT_TRANS.Rows[RC][1] = "1000";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 1000";
                DT_TRANS.Rows[RC][3] = "2";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0005000";
                DT_TRANS.Rows[RC][1] = "5000";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 5000";
                DT_TRANS.Rows[RC][3] = "3";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0009999";
                DT_TRANS.Rows[RC][1] = "9999";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 9999";
                DT_TRANS.Rows[RC][3] = "4";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0099999";
                DT_TRANS.Rows[RC][1] = "99999";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 99999";
                DT_TRANS.Rows[RC][3] = "5";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0199999";
                DT_TRANS.Rows[RC][1] = "199999";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 199999";
                DT_TRANS.Rows[RC][3] = "6";
                DT_TRANS.Rows.Add();
                RC++;
                DT_TRANS.Rows[RC][0] = "A0499999";
                DT_TRANS.Rows[RC][1] = "499999";
                DT_TRANS.Rows[RC][2] = "Total Transactions are 499999";
                DT_TRANS.Rows[RC][3] = "7";
            #endregion
                #region Session Entry In DataTable
                DT_SESSION.Columns.Add("Session_Code", typeof(string));
                DT_SESSION.Columns.Add("Session_Value", typeof(string));
                DT_SESSION.Columns.Add("Session_Comment", typeof(string));
                DT_SESSION.Columns.Add("SL", typeof(string));
                RC = 0;
                DT_SESSION.Rows.Add();
                DT_SESSION.Rows[RC][0] = "B0000200";
                DT_SESSION.Rows[RC][1] = "200";
                DT_SESSION.Rows[RC][2] = "Total Session are 200";
                DT_SESSION.Rows[RC][3] = "0";
                DT_SESSION.Rows.Add();
                RC++;
                DT_SESSION.Rows[RC][0] = "B0001000";
                DT_SESSION.Rows[RC][1] = "1000";
                DT_SESSION.Rows[RC][2] = "Total Session are 1000";
                DT_SESSION.Rows[RC][3] = "1";
                DT_SESSION.Rows.Add();
                RC++;
                DT_SESSION.Rows[RC][0] = "B0005000";
                DT_SESSION.Rows[RC][1] = "5000";
                DT_SESSION.Rows[RC][2] = "Total Session are 5000";
                DT_SESSION.Rows[RC][3] = "2";
                DT_SESSION.Rows.Add();
                RC++;
                DT_SESSION.Rows[RC][0] = "B0010000";
                DT_SESSION.Rows[RC][1] = "10000";
                DT_SESSION.Rows[RC][2] = "Total Session are 10000";
                DT_SESSION.Rows[RC][3] = "3";
                DT_SESSION.Rows.Add();
                RC++;
                DT_SESSION.Rows[RC][0] = "B0099999";
                DT_SESSION.Rows[RC][1] = "99999";
                DT_SESSION.Rows[RC][2] = "Total Session are 99999";
                DT_SESSION.Rows[RC][3] = "4";
                #endregion
                #region Company Entry In DataTable
                DT_COMPANY.Columns.Add("Company_Code", typeof(string));
                DT_COMPANY.Columns.Add("Company_Value", typeof(string));
                DT_COMPANY.Columns.Add("Company_Comment", typeof(string));
                DT_COMPANY.Columns.Add("SL", typeof(string));
                RC = 0;
                DT_COMPANY.Rows.Add();
                DT_COMPANY.Rows[RC][0] = "C0000011";
                DT_COMPANY.Rows[RC][1] = "11";
                DT_COMPANY.Rows[RC][2] = "Total Companies are 15";
                DT_COMPANY.Rows[RC][3] = "0";
                DT_COMPANY.Rows.Add();
                RC++;
                DT_COMPANY.Rows[RC][0] = "C0000041";
                DT_COMPANY.Rows[RC][1] = "41";
                DT_COMPANY.Rows[RC][2] = "Total Companies are 41";
                DT_COMPANY.Rows[RC][3] = "1";
                DT_COMPANY.Rows.Add();
                RC++;
                DT_COMPANY.Rows[RC][0] = "C0000091";
                DT_COMPANY.Rows[RC][1] = "91";
                DT_COMPANY.Rows[RC][2] = "Total Companies are 91";
                DT_COMPANY.Rows[RC][3] = "2";
                #endregion
            }
            catch { }
            
        }
        //public void Checking_Transactions()
        //{
        //    try
        //    {
        //        #region Transaction Checking
        //        Int64 TotalTrans = 0, TotalSession = 0, TotalCompany = 0;
        //        //edpcon.Close();
        //        //edpcon.Open();
        //        string ss = edpcom.GetresultS("SELECT COUNT(I.FICODE) [TOTAL TRANS] FROM IDATA I WHERE I.FICODE='" + edpcom.CurrentFicode + "' AND I.GCODE='" + edpcom.PCURRENT_GCODE + "' AND I.T_ENTRY IN('8','9','n','a','OP','SI','SO','SR','PR')");
        //        if (Information.IsNumeric(ss) == true)
        //            TotalTrans = Convert.ToInt64(ss);
        //        ss = "";
        //        ss = edpcom.GetresultS("SELECT COUNT(D.FICODE) [TOTAL TRANS] FROM DATA D WHERE D.FICODE='" + edpcom.CurrentFicode + "' AND D.GCODE='" + edpcom.PCURRENT_GCODE + "' AND D.T_ENTRY IN('1','2','3','4','5','6','7')");
        //        if (Information.IsNumeric(ss) == true)
        //            TotalTrans = TotalTrans + Convert.ToInt64(ss);

        //        DataView dv = new DataView(DT_TRANS);
        //        dv.RowFilter = "Trans_Value='" + TotalTrans.ToString() + "'";
        //        if (dv.Count > 0)
        //        {
        //            EDPMessage.Show(dv[0][0].ToString() + "  " + dv[0][2].ToString());
        //            ProductKey PK = new ProductKey();
        //            PK.ShowDialog();
        //        }
        //        # endregion

        //        #region Session Checking                
        //        dv = new DataView(DT_SESSION);
        //        dv.RowFilter = "Session_Value='" + edpcom.CURRENTSESSION.ToString() + "'";
        //        if (dv.Count > 0)
        //        {
        //            EDPMessage.Show(dv[0][0].ToString() + "  " + dv[0][2].ToString());
        //            ProductKey PK = new ProductKey();
        //            PK.ShowDialog();
        //        }
        //        # endregion

        //        #region Company Checking
        //        ss = edpcom.GetresultS("SELECT COUNT(FICODE) [TOTAL COM] FROM Company");
        //        if (Information.IsNumeric(ss) == true)
        //            TotalCompany = Convert.ToInt64(ss);
        //        dv = new DataView(DT_COMPANY);
        //        dv.RowFilter = "Company_Value='" + TotalCompany.ToString() + "'";
        //        if (dv.Count > 0)
        //        {
        //            EDPMessage.Show(dv[0][0].ToString() + "  " + dv[0][2].ToString());
        //            ProductKey PK = new ProductKey();
        //            PK.ShowDialog();
        //        }
        //        # endregion
        //    }
        //    catch { }
        //}
    }
}
