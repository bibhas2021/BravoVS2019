using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Edpcom
{

    /// <summary>
    /// Summary description for the class.
    /// </summary>

    public class EDPConnection
    {

        //------------Private Variables
        public string SvrName = "";
        public string DatabaseName = "";
        //  private string UserName      = "sa";
        //   private string Password      = "";
        public string connectionstr = "";

        public SqlConnection mycon;

        //------------Public Properties


        //------------Methods
        public EDPConnection()
        {
            EDPCommon EDPComm = new EDPCommon();
            this.SvrName = EDPComm.PSERVER_NAME;
            this.DatabaseName = EDPComm.PDATABASE_NAME;
        }

        public void Open()
        {
            if (new EDPCommon().DataVersion == "2005")
                this.connectionstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" + DatabaseName + ";Data Source=" + SvrName + "\\SQLEXPRESS; Connection Timeout=40;";
            else
                this.connectionstr = "Data Source=" + SvrName + ";Initial Catalog=" + DatabaseName + ";Integrated Security=True;pooling=true; Connection Timeout=40;";
            this.mycon = new SqlConnection(connectionstr);
            this.mycon.Open();
        }

        public void Close()
        {
            try
            {
                this.mycon.Close();
            }
            catch { }
        }

    }


}
