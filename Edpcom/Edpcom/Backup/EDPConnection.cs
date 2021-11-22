using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using EDPMessageBox;
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
        bool status, PSI;
        public SqlConnection mycon;
        string mainDataSourch = "", mainNetworkLibrary = "", mainIntegratedSecurity = "", maintxtuserID = "", mainPassword = "", mainConnectiontime = "", mainstatus = "", DSE = "";

        //------------Public Properties


        //------------Methods
        public EDPConnection()
        {
            EDPCommon EDPComm = new EDPCommon();
            this.SvrName = EDPComm.PSERVER_NAME;
            this.DatabaseName = EDPComm.PDATABASE_NAME;
           this.mainNetworkLibrary = EDPComm.NetWork_library;
               this.mainIntegratedSecurity=EDPComm.Integrated_Security;
               this.maintxtuserID = EDPComm.User_ID;
               this.mainPassword=EDPComm.Password;
               this.mainstatus =EDPComm.Trusted_Conection;
               this.mainConnectiontime = EDPComm.Conection_TimeOut;
               this.PSI = EDPComm.Persist_Security_Info;
               this.DSE = EDPComm.DataSourceExtention;
        }

        public void Open()
        {
            //try
            //{
                EDPCommon edpcom = new EDPCommon();
                //if (new EDPCommon().DataVersion == "2005")
                //    this.connectionstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" + DatabaseName + ";Data Source=" + SvrName + "\\SQLEXPRESS; Connection Timeout=40;";
                //else
                //    this.connectionstr = "Data Source=" + SvrName + ";Initial Catalog=" + DatabaseName + ";Integrated Security=True;pooling=true; Connection Timeout=40;";
                string st = "192.168.0.100,1433";
                if (new EDPCommon().DataVersion == "2005")
                    if (edpcom.Remote)
                        //Change S Dutta 17.08.12(Change DataBase Conection)
                        //this.connectionstr = "Initial Catalog=" + DatabaseName + ";Data Source=" + SvrName + "\\SQLEXPRESS; User ID=edp; Password=2477147edp; Connection Timeout=100;";
                        //this.connectionstr = "Data Source=" + st + ";Network Library=DBMSSOCN;Integrated Security=SSPI;Initial Catalog=" + DatabaseName + ";User ID=edp;Password=2477147edp;Trusted_Connection=yes;Connection Timeout=100;";
                        if (mainIntegratedSecurity == "" && mainNetworkLibrary == "")
                            this.connectionstr = "Data Source=" + SvrName + ""+ DSE + ";Initial Catalog=" + DatabaseName + ";Persist Security Info=" + PSI + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";";
                        else if (mainIntegratedSecurity == "")
                        {
                            this.connectionstr = "Data Source=" + SvrName + "" + DSE + ";Network Library=" + mainNetworkLibrary + ";Initial Catalog=" + DatabaseName + ";Persist Security Info=" + PSI + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";";
                        }
                        else if (mainNetworkLibrary == "")
                            this.connectionstr = "Data Source=" + SvrName + "" + DSE + ";Integrated Security=" + mainIntegratedSecurity + ";Initial Catalog=" + DatabaseName + ";Persist Security Info=" + PSI + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";";
                        else
                            this.connectionstr = "Data Source=" + SvrName + "" + DSE + ";Network Library=" + mainNetworkLibrary + ";Integrated Security=" + mainIntegratedSecurity + ";Persist Security Info=" + PSI + ";Initial Catalog=" + DatabaseName + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";";
                    else
                        //this.connectionstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" + DatabaseName + ";Data Source=" + SvrName + "\\SQLEXPRESS; Connection Timeout=40;";
                        //this.connectionstr = "Data Source=" + st + ";Network Library=DBMSSOCN;Integrated Security=SSPI;Initial Catalog=" + DatabaseName + ";User ID=edp;Password=2477147edp;Trusted_Connection=yes;Connection Timeout=40;";
                        if (mainIntegratedSecurity == "" && mainNetworkLibrary == "")
                            this.connectionstr = "Data Source=" + SvrName + "" + DSE + ";Initial Catalog=" + DatabaseName + ";Persist Security Info=" + PSI + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";";
                        else if (mainIntegratedSecurity == "")
                        {
                            this.connectionstr = "Data Source=" + SvrName + "" + DSE + ";Network Library=" + mainNetworkLibrary + ";Persist Security Info=" + PSI + ";Initial Catalog=" + DatabaseName + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";";
                        }
                        else if (mainNetworkLibrary == "")
                            this.connectionstr = "Data Source=" + SvrName + "" + DSE + ";Integrated Security=" + mainIntegratedSecurity + ";Persist Security Info=" + PSI + ";Initial Catalog=" + DatabaseName + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";";
                        else
                            this.connectionstr = "Data Source=" + SvrName + "" + DSE + ";Network Library=" + mainNetworkLibrary + ";Integrated Security=" + mainIntegratedSecurity + ";Persist Security Info=" + PSI + ";Initial Catalog=" + DatabaseName + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";";//;Persist Security Info=False;
                //this.connectionstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=master;Data Source=" + SvrName + "\\SQLEXPRESS; Connection Timeout=" + mainConnectiontime + ";";
                   
                else
                    //this.connectionstr = "Data Source=" + SvrName + ";Initial Catalog=" + DatabaseName + ";Integrated Security=True;pooling=true; Connection Timeout=40;";   
                    //this.connectionstr = "Data Source=" + st + ";Network Library=DBMSSOCN;Integrated Security=SSPI;Initial Catalog=" + DatabaseName + ";User ID=edp;Password=2477147edp;Trusted_Connection=yes;Connection Timeout=40;";
                    if (mainIntegratedSecurity == "" && mainNetworkLibrary == "")
                        this.connectionstr = "Data Source=" + SvrName + "" + DSE + ";Initial Catalog=" + DatabaseName + ";Persist Security Info=" + PSI + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";";
                    else if (mainIntegratedSecurity == "")
                    {
                        this.connectionstr = "Data Source=" + SvrName + "" + DSE + ";Network Library=" + mainNetworkLibrary + ";Persist Security Info=" + PSI + ";Initial Catalog=" + DatabaseName + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";";
                    }
                    else if (mainNetworkLibrary == "")
                        this.connectionstr = "Data Source=" + SvrName + "" + DSE + ";Integrated Security=" + mainIntegratedSecurity + ";Persist Security Info=" + PSI + ";Initial Catalog=" + DatabaseName + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";";
                    else
                        this.connectionstr = "Data Source=" + SvrName + "" + DSE + ";Network Library=" + mainNetworkLibrary + ";Persist Security Info=" + PSI + ";Integrated Security=" + mainIntegratedSecurity + ";Initial Catalog=" + DatabaseName + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";";                        
                //End 17.08.12    
                this.mycon = new SqlConnection(connectionstr);
                this.mycon.Open();
               
            //}           
            //catch
            //{
            //    //EDPMessage.Show(ex.Message);               
            //    if (mainIntegratedSecurity == "" && mainNetworkLibrary == "")
            //        EDPMessage.Show("Data Source=" + SvrName + ";Initial Catalog=" + DatabaseName + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";");
            //    else if (mainIntegratedSecurity == "")
            //    {
            //        EDPMessage.Show("Data Source=" + SvrName + ";Network Library=" + mainNetworkLibrary + ";Initial Catalog=" + DatabaseName + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";");
            //    }
            //    else if (mainNetworkLibrary == "")
            //        EDPMessage.Show( "Data Source=" + SvrName + ";Integrated Security=" + mainIntegratedSecurity + ";Initial Catalog=" + DatabaseName + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";");
            //    else
            //        EDPMessage.Show( "Data Source=" + SvrName + ";Network Library=" + mainNetworkLibrary + ";Integrated Security=" + mainIntegratedSecurity + ";Initial Catalog=" + DatabaseName + ";User ID=" + maintxtuserID + ";Password=" + mainPassword + ";Trusted_Connection=" + mainstatus + ";Connection Timeout=" + mainConnectiontime + ";");
                
            //}
        }

        public void Close()
        {
            try
            {
                this.mycon.Close();
            }
            catch { }
        }

        public void userdefineconnection(string DataSourch,string NetworkLibrary, string IntegratedSecurity,string txtuserID,string Password,string Connectiontime,string status)
        {
            mainDataSourch = ""; mainNetworkLibrary = ""; mainIntegratedSecurity = ""; maintxtuserID = ""; mainPassword = ""; mainConnectiontime = ""; mainstatus = "";

            mainDataSourch = DataSourch;
            mainNetworkLibrary = NetworkLibrary;
            mainIntegratedSecurity = IntegratedSecurity;
            maintxtuserID = txtuserID;
            mainPassword = Password;
            mainConnectiontime = Connectiontime;
            mainstatus = status;

        }

        public bool sta()
        {
            Open();
            if (status == true)
                return true;
            else
                return false;
            
        }

    }


}
