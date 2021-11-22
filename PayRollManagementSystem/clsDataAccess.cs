using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Edpcom;
using System.IO;
namespace PayRollManagementSystem
{
    public  class clsDataAccess
    {
        //public static SqlConnection conn;
        public static string databaseName;
        public static string serverName;
        static SqlCommand cmd;
        //static SqlTransaction trans;

         public static  Edpcom.EDPConnection conn = new EDPConnection();
     
        //Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        static Edpcom.EDPCommon edpcom = new EDPCommon();
        static Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        static Edpcom.EDPCommon comm = new EDPCommon();

       static SqlDataReader rdr;
        #region Database Connection
        /// <summary>
        /// Database Connection
        /// </summary>
        public static void ConnectDB()
        {
            edpcon.Open();
            
            //conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" + databaseName + ";Data Source=.\\SQLEXPRESS");
            //if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            //{
            //    try
            //    {
            //        conn.Open();
            //    }
            //    catch
            //    {

            //    }
            //}
            //else
            //{
            //    conn.Open();
            //}           
        }

        /// <summary>
        /// Disconnect Database
        /// </summary>
        public static void DisconnectDB()
        {
            edpcon.Close();
            //if (conn.State != ConnectionState.Closed)
            //{
            //    try
            //    {
            //        conn.Close();
            //        conn.Dispose();
            //    }
            //    catch (SqlException ex)
            //    {
            //        throw new Exception("Error closing connection: " + ex.Message);
            //    }
            //}
        }



        #endregion

        public static string Emp_No_struct()
        {

            string filePath = "",dcno="";
            filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
            string lineForConfigSetting;
            Boolean boolPermission=false;
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    if (file.ReadLine() != null)
                    {
                        int chk_str = 0;
                        while ((lineForConfigSetting = file.ReadLine()) != null)
                        {
                            string[] StrSTAR = lineForConfigSetting.Trim().Split('*');
                            if (StrSTAR.Length == 2)
                            {
                                if (StrSTAR[0].Trim() == "")
                                    continue;
                            }

                            string[] StrLine = lineForConfigSetting.Trim().Split('[');
                            if (StrLine.Length == 2)
                            {
                                string str = lineForConfigSetting.Substring(1, lineForConfigSetting.Length - 2);
                                if (str.ToUpper() == ("Emp_Prefix").ToUpper() || str.ToUpper()==("Emp_Code_pad").ToUpper())
                                    chk_str = 1;
                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                if (StrLine_WACC[0].ToUpper() == "SAVE_AND_GOTO_ADDITIONAL_DETAILS_VISIBILITY")
                                    boolPermission = true;


                                dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper();
                                chk_str = 0;
                            }
                        }
                    }

                }
                catch
                { }
            }
            return dcno;
        }


        public static string EMPLang()
        {
            string dcno = "";
            string[] StrLine_WACC = clsDataAccess.ReturnValue("select lang from CompanyLimiter").Split(';');
            if (StrLine_WACC.Length > 1)
            {
                


                if (StrLine_WACC.Length == 3)
                {
                    try
                    {
                        dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper() + "|" + StrLine_WACC[2].ToUpper();
                    }
                    catch
                    {
                        dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper() + "|" + StrLine_WACC[2].ToUpper() + "|" + StrLine_WACC[3].ToUpper();

                    }

                }
                else if (StrLine_WACC.Length == 4)
                {
                    try
                    {
                        dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper() + "|" + StrLine_WACC[2].ToUpper() + "|" + StrLine_WACC[3].ToUpper();
                    }
                    catch
                    {
                        dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper() + "|" + StrLine_WACC[2].ToUpper() + "|" + StrLine_WACC[3].ToUpper();

                    }
                }
                else if (StrLine_WACC.Length == 5)
                {
                    try
                    {
                        dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper() + "|" + StrLine_WACC[2].ToUpper() + "|" + StrLine_WACC[3].ToUpper() + "|" + StrLine_WACC[4].ToUpper();
                    }
                    catch
                    {
                        dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper() + "|" + StrLine_WACC[2].ToUpper() + "|" + StrLine_WACC[3].ToUpper();

                    }
                }
               
            }
            else
            {
                dcno = "";

            }

            return dcno;

        }

        public static string Emp_lang()
        {

            string filePath = "", dcno = "";
            filePath = @Environment.CurrentDirectory + "\\lang_config.txt";
            string lineForConfigSetting;
            Boolean boolPermission = false;
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    if (file.ReadLine() != null)
                    {
                        int chk_str = 0;
                        while ((lineForConfigSetting = file.ReadLine()) != null)
                        {
                            string[] StrSTAR = lineForConfigSetting.Trim().Split('*');
                            if (StrSTAR.Length == 2)
                            {
                                if (StrSTAR[0].Trim() == "")
                                    continue;
                            }

                            string[] StrLine = lineForConfigSetting.Trim().Split('[');
                            if (StrLine.Length == 2)
                            {
                                string str = lineForConfigSetting.Substring(1, lineForConfigSetting.Length - 2);
                                if (str.ToUpper() == ("Lang_1_2_3").ToUpper() || str.ToUpper() == ("Lang_1_2_3").ToUpper())
                                    chk_str = 1;
                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                if (StrLine_WACC[0].ToUpper() == "SAVE_AND_GOTO_ADDITIONAL_DETAILS_VISIBILITY")
                                    boolPermission = true;


                                if (StrLine_WACC.Length == 3)
                                {
                                    try
                                    {
                                        dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper() + "|" + StrLine_WACC[2].ToUpper();
                                    }
                                    catch
                                    {
                                        dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper() + "|" + StrLine_WACC[2].ToUpper() + "|" + StrLine_WACC[3].ToUpper();

                                    }

                                }
                                else if (StrLine_WACC.Length == 4)
                                {
                                    try
                                    {
                                        dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper() + "|" + StrLine_WACC[2].ToUpper() + "|" + StrLine_WACC[3].ToUpper();
                                    }
                                    catch
                                    {
                                        dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper() + "|" + StrLine_WACC[2].ToUpper() + "|" + StrLine_WACC[3].ToUpper();

                                    }
                                }
                                else if (StrLine_WACC.Length == 5)
                                {
                                    try
                                    {
                                        dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper() + "|" + StrLine_WACC[2].ToUpper() + "|" + StrLine_WACC[3].ToUpper() + "|" + StrLine_WACC[4].ToUpper();
                                    }
                                    catch
                                    {
                                        dcno = StrLine_WACC[0].ToUpper() + "|" + StrLine_WACC[1].ToUpper() + "|" + StrLine_WACC[2].ToUpper() + "|" + StrLine_WACC[3].ToUpper();

                                    }
                                }
                                chk_str = 0;
                            }
                            else
                            {
                                dcno = "";

                            }
                        }
                    }

                }
                catch
                { }
            }
            return dcno;
        }


        public static DataSet sp_EmpMonitoring(string curMon,int coid,int dur)
        {
            ConnectDB();
        
            DataTable x = new DataTable();
            SqlCommand sqlcmd = new SqlCommand("sp_EmpMonitoring", edpcon.mycon);
            sqlcmd.CommandTimeout = 0;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@curMon", SqlDbType.NVarChar).Value = curMon;
            sqlcmd.Parameters.AddWithValue("@coid", SqlDbType.Int).Value = coid;
            sqlcmd.Parameters.AddWithValue("@dur", SqlDbType.Int).Value = dur;


            SqlDataAdapter adpt = new SqlDataAdapter();
            DataSet dsAA = new DataSet();
            adpt.SelectCommand = sqlcmd;
            try
            {
                adpt.Fill(dsAA);
                dsAA.ToString();
            }

            catch { }
            finally
            {
                DisconnectDB();
            }
            
            x = dsAA.Tables[0];
            return dsAA;

        }




        #region Functions to Insert/Update/Delete

        /// <summary>
        /// Return Dataset by SQL
        /// </summary>
        /// <param name="strSql">SQL STRING</param>
        /// <returns>DATASET</returns>
        public static DataSet RunQDSet(String strSql)
        {
            SqlDataAdapter dtAdap = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                
                ConnectDB();
                
                cmd = new SqlCommand(strSql);
                //cmd.Connection = conn;
                cmd.Connection = edpcon.mycon;
                dtAdap.SelectCommand = cmd;

                dtAdap.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DisconnectDB();
            }
            return ds;
        }

        /// <summary>
        /// Return STATUS BY SQL
        /// </summary>
        /// <param name="strSql">SQL STRING</param>
        /// <returns>RETURNS DATATABLE</returns>
        /// 

        public static bool RunQry(string Command)
        {
            bool result = false;
            ConnectDB();
            SqlCommand cmd = new SqlCommand(Command, edpcon.mycon);
            result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            return result;
        }

        public static bool RunWorkflow_Log(string ucode,string Job,string status,string wdate,string type,string node,string month,string year,string locid,string coid,string docno)
        {
            string[] lcno = locid.Split(',');
            string qry = "";
            bool result = false;
            if (lcno.Length > 0)
            {
                result = false;
                for (int ix = 0; ix < lcno.Length; ix++)
                {
                    qry = "INSERT INTO tbl_workflow_log(wfid,ucode,Job,docno,status,wdate,type,node,month,year,locid,coid) VALUES " +
            "((select isNull(max(wfid),0)+1 from tbl_workflow_log),'" + ucode + "','" + Job + "','" + docno + "','" + status + "','" + wdate + "','" + type + "','" +
            node + "','" + month + "','" + year + "'," + lcno[ix].ToString() + ",'" + coid + "')";
                   
                    ConnectDB();
                    SqlCommand cmd = new SqlCommand(qry, edpcon.mycon);
                    try
                    {
                        result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    }
                    catch { }
                }

            }
            else
            {
                qry = "INSERT INTO tbl_workflow_log(wfid,ucode,Job,docno,status,wdate,type,node,month,year,locid,coid) VALUES " +
            "((select isNull(max(wfid),0)+1 from tbl_workflow_log),'" + ucode + "','" + Job + "','" + docno + "','" + status + "','" + wdate + "','" + type + "','" +
            node + "','" + month + "','" + year + "','" + locid + "','" + coid + "')";
              
                ConnectDB();
                SqlCommand cmd = new SqlCommand(qry, edpcon.mycon);
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
                return result;
            }
            return result;
        }


        public static string GetresultI(string tab_name, string col_Name)
        {
            int data = 0;
            string strSql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS"
                  + " WHERE TABLE_NAME ='" + tab_name + "' AND COLUMN_NAME"
                  + " = '" + col_Name + "'";


            SqlDataAdapter dtAdap = new SqlDataAdapter(strSql, edpcon.mycon);
            DataTable dtTbl = new DataTable();
            cmd = new SqlCommand(strSql);
            cmd.Connection = edpcon.mycon;
            dtAdap.SelectCommand = cmd;
            try
            {
                ConnectDB();
                cmd = new SqlCommand(strSql);
                cmd.Connection = edpcon.mycon;
                dtAdap.SelectCommand = cmd;

                dtAdap.Fill(dtTbl);

                if (dtTbl.Rows.Count > 0)
                {
                    data = Convert.ToInt32(dtTbl.Rows[0][0]);
                }
                else
                {
                    data = 0;
                }
            }
            catch
            {
                return "0";
            }
            finally
            {
                DisconnectDB();
            }
            return Convert.ToString(data);
        }//return string value

        public static string GetresultIT(string tab_name)
        {
            int data = 0;
            string strSql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS"
                  + " WHERE (TABLE_NAME ='" + tab_name + "')";
            
            SqlDataAdapter dtAdap = new SqlDataAdapter(strSql, edpcon.mycon);
            DataTable dtTbl = new DataTable();
            cmd = new SqlCommand(strSql);
            cmd.Connection = edpcon.mycon;
            dtAdap.SelectCommand = cmd;
            try
            {
                ConnectDB();
                cmd = new SqlCommand(strSql);
                cmd.Connection = edpcon.mycon;
                dtAdap.SelectCommand = cmd;

                dtAdap.Fill(dtTbl);

                if (dtTbl.Rows.Count > 0)
                {
                    data = Convert.ToInt32(dtTbl.Rows[0][0]);
                }
                else
                {
                    data = 0;
                }
            }
            catch
            {
                return "0";
            }
            finally
            {
                DisconnectDB();
            }
            return Convert.ToString(data);
        }//return string value


        public static string GetresultS(string strSql)
        {
            string data = "";
            SqlDataAdapter dtAdap = new SqlDataAdapter(strSql, edpcon.mycon);
            DataTable dtTbl = new DataTable();
            cmd = new SqlCommand(strSql);
            cmd.Connection = edpcon.mycon;
            dtAdap.SelectCommand = cmd;
            try
            {
                ConnectDB();
                cmd = new SqlCommand(strSql);
                cmd.Connection = edpcon.mycon;
                dtAdap.SelectCommand = cmd;

                dtAdap.Fill(dtTbl);

                if (dtTbl.Rows.Count>0)
                {
                    data = Convert.ToString(dtTbl.Rows[0][0]);
                }
                else
                {
                    data = null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                DisconnectDB();
            }
            return data;
        }//return string value

        public static string ReturnValue(string selectString)
        {
            string data = "";
            
            try
            {
                if (edpcon.mycon.State== ConnectionState.Closed)
                    edpcon.mycon.Open();
                cmd = new SqlCommand(selectString, edpcon.mycon);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        data = (rdr.GetValue(0).ToString());


                    }
                }
                rdr.Close();
            }
            catch { }
            finally
            {
               
            }
            return data;
        }

        public static DataTable RunQDTbl(String strSql)
        {
            SqlDataAdapter dtAdap = new SqlDataAdapter(strSql, edpcon.mycon);
            DataTable dtTbl = new DataTable();

            cmd = new SqlCommand(strSql);
            cmd.Connection = edpcon.mycon;
            dtAdap.SelectCommand = cmd;

            try
            {
                ConnectDB();

                cmd = new SqlCommand(strSql);
                cmd.Connection = edpcon.mycon;
                dtAdap.SelectCommand = cmd;

                dtAdap.Fill(dtTbl);
                //DisconnectDB();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
            finally
            {
                DisconnectDB();
            }
            return dtTbl;
        }

        public static DataTable RunQDTbl(string SelectCommand, SqlConnection Con, SqlTransaction SqlT)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(SelectCommand, Con, SqlT);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                
            }
            return dt;
        }

        /// <summary>
        /// Return STATUS BY SQL
        /// </summary>
        /// <param name="strSql">SQL STRING</param>
        /// <returns>RETURNS DataSet</returns>
        public static DataSet GetDataSetVal(String strSql, string TableName)
        {
            //conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=EDP_Payroll;Data Source=SANTANUPC");
            SqlDataAdapter dtAdap = new SqlDataAdapter(strSql, edpcon.mycon);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strSql, edpcon.mycon);
            da.Fill(ds, TableName);
            return ds;
        }



        // FOR INSERT UPDATE AND DELETE

        /// <summary>
        /// Return DataTable BY SQL
        /// </summary>
        /// <param name="strSql">SQL STRING</param>
        /// <returns>RETURNS STATUS</returns>
        public static Boolean RunNQwithStatus(String strSql)
        {
            Boolean rs = false;
            try
            {
                ConnectDB();
                //trans = conn.BeginTransaction();
                //cmd.Transaction = trans;
                cmd = new SqlCommand(strSql);
                cmd.Connection = edpcon.mycon;
                rs = Convert.ToBoolean(cmd.ExecuteNonQuery());

                //trans.Commit();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DisconnectDB();
            }
            return rs;
        }
        //


        public static Boolean RunNQwithStatus(string Command, SqlConnection Con, SqlTransaction SqlT)
        {
            Boolean result = false;
            SqlCommand cmd = new SqlCommand(Command, Con, SqlT);
            result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            return result;
        }



        #endregion

        #region Transaction

        public static Boolean Transaction(Int32 intNoOfQueries, String[] strQuery)
        {
            strQuery = new String[intNoOfQueries];
            SqlTransaction tran = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                //SqlConnection con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SchoolManagement;Data Source=SANTANUPC");

                ConnectDB();
                tran = edpcon.mycon.BeginTransaction();
                cmd.Connection = edpcon.mycon;
                cmd.Transaction = tran;
                for (Int32 i = 0; i < intNoOfQueries; i++)
                {
                    cmd.CommandText = strQuery[i];
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                DisconnectDB();
            }
        }
       
        #endregion

    }
}
