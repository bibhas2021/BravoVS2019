using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace PayRollManagementSystem
{
    
    class LibaryConnection
    {
        public static string databaseName;
        public SqlConnection Mycon;

        public void Open()
        {
            databaseName = "EDP_Payroll";
            Mycon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" + databaseName + ";Data Source=.\\SQLEXPRESS");
            if (Mycon.State == ConnectionState.Closed || Mycon.State == ConnectionState.Broken)
            {
                try
                {
                    Mycon.Open();
                }
                catch
                {

                }
            }
            else
            {
                Mycon.Open();
            }
        }

        public void Close()
        {
            if (Mycon.State != ConnectionState.Closed)
            {
                try
                {
                    Mycon.Close();
                    Mycon.Dispose();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error closing connection: " + ex.Message);
                }
            }
        }

    }
}
