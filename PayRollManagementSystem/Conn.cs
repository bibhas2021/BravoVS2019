using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PayRollManagementSystem
{
    class Conn
    {
        public string MC_Name = ConfigurationSettings.AppSettings["bravo"].ToString();
        public string CON_Type = ConfigurationSettings.AppSettings["type"].ToString();
        public string cnst="";
 //iif (CON_Type=="Local"){
 //           cnst="Data Source="+MC_Name+";Initial Catalog=EDP_BRAVO_CHK_LC;Integrated Security=True";
 //   }
        SqlConnection con_random = new SqlConnection(ConfigurationSettings.AppSettings["bravo"]);

        DataSet dsAA_random = new DataSet();

        public bool SP_Dync_Proc_bool(string sql)
        {
            string x = "";
            bool rply = false;
            con_random.Open();
            SqlCommand sqlcmd = new SqlCommand("SP_DynProc", con_random);
            sqlcmd.CommandTimeout = 0;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@qry", SqlDbType.NVarChar).Value = sql;
            SqlDataAdapter adpt = new SqlDataAdapter();
            dsAA_random = new DataSet();
            adpt.SelectCommand = sqlcmd;
            try
            {
                adpt.Fill(dsAA_random);
                x = dsAA_random.Tables[0].Rows[0][0].ToString();
            }

            catch { }
            con_random.Close();
            if (x == "ok")
            {
                rply = true;
            }
            return rply;
        }

        public DataTable SP_Dync_Proc_Val(string sql)
        {
            DataTable x = new DataTable();
            con_random.Open();
            SqlCommand sqlcmd = new SqlCommand("SP_DynProc", con_random);
            sqlcmd.CommandTimeout = 0;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@qry", SqlDbType.NVarChar).Value = sql;
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataSet dsAA = new DataSet();
            adpt.SelectCommand = sqlcmd;
            try
            {
                adpt.Fill(dsAA);
                x = dsAA.Tables[0];
            }

            catch { }

            con_random.Close();

            return x;
        }
        public bool SP_Dync_Proc_reg(string coid, string EC_COMPANY, string EC_DATE, string EC_LDATE, string EC_NDATE, string EC_SESSION, 
        string EC_TRANS, string START_DATE, string CHK_DT, string ACTIVATION)
        {
            string x = "";
            bool rply = false;

            con_random.Open();
            SqlCommand sqlcmd = new SqlCommand("sp_Add_Activation", con_random);
            sqlcmd.CommandTimeout = 0;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@coid", SqlDbType.NVarChar).Value = coid;
            sqlcmd.Parameters.AddWithValue("@EC_COMPANY", SqlDbType.NVarChar).Value = EC_COMPANY;
            sqlcmd.Parameters.AddWithValue("@EC_DATE", SqlDbType.NVarChar).Value = EC_DATE;
            sqlcmd.Parameters.AddWithValue("@EC_LDATE", SqlDbType.NVarChar).Value = EC_LDATE;
            sqlcmd.Parameters.AddWithValue("@EC_NDATE", SqlDbType.NVarChar).Value = EC_NDATE;

            sqlcmd.Parameters.AddWithValue("@EC_SESSION", SqlDbType.NVarChar).Value = EC_SESSION;
            sqlcmd.Parameters.AddWithValue("@EC_TRANS", SqlDbType.NVarChar).Value = EC_TRANS;
            sqlcmd.Parameters.AddWithValue("@START_DATE", SqlDbType.NVarChar).Value = START_DATE;

            sqlcmd.Parameters.AddWithValue("@CHK_DT", SqlDbType.SmallDateTime).Value = CHK_DT;
            sqlcmd.Parameters.AddWithValue("@ACTIVATION", SqlDbType.NVarChar).Value = ACTIVATION;
            
            try
            {
               sqlcmd.ExecuteNonQuery();               
                x = "ok";
            }
            catch { }
            con_random.Close();


            if (x == "ok")
            {
                rply = true;
            }
            return rply;

        }


        public bool SP_Dync_Proc_Company(string comp,string add,string contact,string email,string build_dt,int reg)
        {
    //        @comp NVARCHAR(max),@add NVARCHAR(max),@contact NVARCHAR(max),@email NVARCHAR(max),
    //@build_dt smalldatetime,@reg bit, 
    //@responseMessage NVARCHAR(max) OUTPUT
            string x = "";
            bool rply = false;
            con_random.Open();
            SqlCommand sqlcmd = new SqlCommand("sp_Add_Company", con_random);
            sqlcmd.CommandTimeout = 0;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@comp", SqlDbType.NVarChar).Value = comp;
            sqlcmd.Parameters.AddWithValue("@add", SqlDbType.NVarChar).Value = add;
            sqlcmd.Parameters.AddWithValue("@contact", SqlDbType.NVarChar).Value = contact;
            sqlcmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = email;
            sqlcmd.Parameters.AddWithValue("@build_dt", SqlDbType.NVarChar).Value = build_dt;
            sqlcmd.Parameters.AddWithValue("@reg", SqlDbType.Bit).Value = reg;
            sqlcmd.Parameters.AddWithValue("@responseMessage", SqlDbType.Bit).Value = "";
            
            //SqlDataAdapter adpt = new SqlDataAdapter();
            //dsAA = new DataSet();
            //adpt.SelectCommand = sqlcmd;
            try
            {
                sqlcmd.ExecuteNonQuery();
                //adpt.Fill(dsAA);
                //x = dsAA.Tables[0].Rows[0][0].ToString();
                x = "ok";
            }

            catch { }
            con_random.Close();
            if (x == "ok")
            {
                rply = true;
            }
            return rply;
        }


    }
}
