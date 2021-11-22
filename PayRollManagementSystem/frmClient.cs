using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.IO;

namespace PayRollManagementSystem
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        SqlTransaction sqltran;
        string Imagepath = "";
        string Imagedocument = "", Imagedocument2 = "", Imagedocument3 = "";
        SqlCommand cmd = new SqlCommand();
        int co_code = 0;
        string Type = "";
        SqlDataReader myrd;

        public void getcode(int code, string p_type)
        {
            co_code = code;
            Type = p_type;
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            // int pn, streg,
            int mn;

           
            if (Type == "P")
            {
                //this.HeaderText = "Client Master";
                label1.Text = "Client Name";

               
                lblClientComp.Visible = true;
                cmbCompany.Visible = true;
                //-----------------------------------
               

                mn = Convert.ToInt32(clsDataAccess.GetresultI("tbl_Employee_CliantMaster", "Country"));
                if (mn == 0)
                {
                    string str = "ALTER TABLE tbl_Employee_CliantMaster ADD [Country] [numeric] (18, 0) NULL";
                    bool rs = clsDataAccess.RunNQwithStatus(str);

                    str = "Update tbl_Employee_CliantMaster set Country=(Select Country_CODE from Country where Country_Name='India')";
                    rs = clsDataAccess.RunNQwithStatus(str);
                }


                mn = Convert.ToInt32(clsDataAccess.GetresultI("tbl_Employee_CliantMaster", "website"));

                if (mn == 0)
                {
                    string str = "ALTER TABLE tbl_Employee_CliantMaster ADD [website] [nvarchar] (50) NULL";
                    bool rs = clsDataAccess.RunNQwithStatus(str);
                }

                mn = Convert.ToInt32(clsDataAccess.GetresultI("tbl_Employee_CliantMaster", "Email"));

                if (mn == 0)
                {
                    string str = "ALTER TABLE tbl_Employee_CliantMaster ADD [Email] [nvarchar] (50) NULL";
                    bool rs = clsDataAccess.RunNQwithStatus(str);
                }

                mn = Convert.ToInt32(clsDataAccess.GetresultI("tbl_Employee_CliantMaster", "Fax"));

                if (mn == 0)
                {
                    string str = "ALTER TABLE tbl_Employee_CliantMaster ADD [FAX] [nvarchar] (50) NULL";
                    bool rs = clsDataAccess.RunNQwithStatus(str);
                }


                mn = Convert.ToInt32(clsDataAccess.GetresultI("tbl_Employee_CliantMaster", "coid"));

                if (mn == 0)
                {
                    string str = "ALTER TABLE tbl_Employee_CliantMaster ADD [coid] [int] NULL";
                    bool rs = clsDataAccess.RunNQwithStatus(str);
                }

                DataTable dt = clsDataAccess.RunQDTbl("SELECT CO_CODE,FICode,GCODE,CO_NAME FROM Company");




                cmbCompany.Items.Clear();
                //for (int i = 0; i <= dt.Rows.Count - 1; i++)
                //{
                cmbCompany.DataSource = dt;
                cmbCompany.DisplayMember = dt.Columns["CO_Name"].ToString();
                cmbCompany.ValueMember = dt.Columns["GCODE"].ToString();

                //cmbCompany.ValueMember = Convert.ToString(dt.Rows[i]["GCODE"]);
                //    cmbCompany.DisplayMember = Convert.ToString(dt.Rows[i]["CO_Name"]);


                // }
            }
            else
            {
              
            }
            //this.cmbCountry.Text = "India";
            //this.cmbstate.Text = "West Bengal";
            Configuration_Menu_TypeDoc_companySetting();
            if (this.cmbCountry.Text.ToLower() == "india" && this.cmbstate.Text.ToLower() == "west bengal")
            {
                txtcity.Text = "KOLKATA";

            }
            else if (this.cmbCountry.Text.ToLower() == "india" && this.cmbstate.Text.ToLower() != "west bengal")
            {


            }
            else
            {
                txtcity.Text = "";
            }

            GetDetails();
        }

        private void GetDetails()
        {
            if (co_code > 0)
            {
                if (Type == "P")
                {
                    DataTable dt = clsDataAccess.RunQDTbl("Select Client_Name,Client_ADD1,Client_ADD2,Client_City,Client_State,Contract_Person,Contract_No,Country,website,Email,Fax,coid,GSTINNO from tbl_Employee_CliantMaster where Client_id = '" + co_code + "'");
                    if (dt.Rows.Count > 0)
                    {
                        txtconame.Text = Convert.ToString(dt.Rows[0]["Client_Name"]);
                        txtadd1.Text = Convert.ToString(dt.Rows[0]["Client_ADD1"]);
                        txtadd2.Text = Convert.ToString(dt.Rows[0]["Client_ADD2"]);
                        txtphoneno.Text = Convert.ToString(dt.Rows[0]["Contract_No"]);
                        txtcontractperson.Text = Convert.ToString(dt.Rows[0]["Contract_Person"]);
                        txtcity.Text = Convert.ToString(dt.Rows[0]["Client_City"]);
                        gstinNoClientMasterTextBox.Text = Convert.ToString(dt.Rows[0]["GSTINNO"]);

                        if (Information.IsNumeric(dt.Rows[0]["Client_State"]) == true)
                        {
                            DataTable dt_state = clsDataAccess.RunQDTbl("Select State_Name from StateMaster where STATE_CODE = '" + dt.Rows[0]["Client_State"] + "'");
                            if (dt_state.Rows.Count > 0)
                                cmbstate.Text = Convert.ToString(dt_state.Rows[0]["State_Name"]);
                        }

                        if (Information.IsNumeric(dt.Rows[0]["Country"]) == true)
                        {
                            DataTable dt_Country = clsDataAccess.RunQDTbl("Select Country_Name from Country where (Country_CODE='" + dt.Rows[0]["Country"] + "')");
                            if (dt_Country.Rows.Count > 0)
                                this.cmbCountry.Text = Convert.ToString(dt_Country.Rows[0]["Country_Name"]);
                        }
                        this.TxtWebSite.Text = Convert.ToString(dt.Rows[0]["website"]);
                        this.TxtEmail.Text = Convert.ToString(dt.Rows[0]["Email"]);
                        this.txtFax.Text = Convert.ToString(dt.Rows[0]["Fax"]);
                        //string Co_Name = clsDataAccess.RunQDTbl("SELECT CO_NAME FROM Company where GCODE='" + Convert.ToString(dt.Rows[0]["coid"]) + "'").Rows[0][0].ToString();
                        cmbCompany.SelectedValue = dt.Rows[0]["coid"];
                    }
                }



                
            }
        }

        public void Configuration_Menu_TypeDoc_companySetting()
        {
            try
            {
                string filePath = "";
                filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
                string line;
                if (File.Exists(filePath))
                {
                    StreamReader file = null;
                    try
                    {
                        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
                        edpcon.Close();
                        file = new StreamReader(filePath);
                        if (file.ReadLine() != null)
                        {
                            int chk_str = 0;
                            while ((line = file.ReadLine()) != null)
                            {
                                string[] StrSTAR = line.Trim().Split('*');
                                if (StrSTAR.Length == 2)
                                {
                                    if (StrSTAR[0].Trim() == "")
                                        continue;
                                }

                                string[] StrLine = line.Trim().Split('[');
                                if (StrLine.Length == 2)
                                {
                                    string str = line.Substring(1, line.Length - 2);
                                    if (str == "Company_Details")
                                        chk_str = 1;
                                    else if (str == "Environment_Envelope")
                                        chk_str = 2;
                                    else if (str == "SDATE")
                                        chk_str = 3;
                                    else
                                        chk_str = 0;
                                }

                                string[] StrLine_WACC = line.Trim().Split(';');

                                if ((chk_str == 1) && (StrLine_WACC.Length > 2))
                                {
                                    if (StrLine_WACC[0] == "Country")
                                    {
                                        cmbCountry.Text = StrLine_WACC[1];
                                        //DataTable Coun = edpcom.GetDatatable("SELECT Country_CODE FROM Country where Country_Name='" + cmbCountry.Text + "'");
                                        //if (Coun.Rows.Count > 0)
                                        // string   COUNTRYCODE = Convert.ToInt32(Coun.Rows[0][0]);
                                        //MoneyName = edpcom.GetresultS("SELECT Currency_Name From Country Where Country_Name='" + cmbCountry.Text + "'");
                                    }
                                    else if (StrLine_WACC[0] == "State")
                                    {
                                        this.cmbstate.Text = StrLine_WACC[1];
                                        //DataTable stat = edpcom.GetDatatable("SELECT STATE_CODE FROM StateMaster where State_Name='" + cmbstate.Text + "'");
                                        //if (stat.Rows.Count > 0)
                                        //    STATECODE = Convert.ToInt32(stat.Rows[0][0]);
                                    }
                                    else if (StrLine_WACC[0] == "City")
                                    {
                                        this.txtcity.Text = StrLine_WACC[1].ToUpper();

                                        //DataTable stat = edpcom.GetDatatable("SELECT STATE_CODE FROM StateMaster where State_Name='" + cmbstate.Text + "'");
                                        //if (stat.Rows.Count > 0)
                                        //    STATECODE = Convert.ToInt32(stat.Rows[0][0]);
                                    }
                                }
                                //else if ((chk_str == 2) && (StrLine_WACC.Length > 1))
                                //{
                                //    if (StrLine_WACC[0].ToUpper() == "PETROL")
                                //        edpcom.EnvironMent_Envelope = "Petrol";
                                //    else if (StrLine_WACC[0].ToUpper() == "PRINTING")
                                //        edpcom.EnvironMent_Envelope = "PRINTING";
                                //    else
                                //        edpcom.EnvironMent_Envelope = "";
                                //}
                                //else if ((chk_str == 3) && (StrLine_WACC.Length > 1))
                                //{
                                //    if (StrLine_WACC[1].ToUpper() != "")
                                //    {
                                //        Config_Date_Start = Convert.ToString(StrLine_WACC[0]);
                                //        Config_Month_Start = Convert.ToString(StrLine_WACC[1]);
                                //        chk_Date_First = true;
                                //    }
                                //}
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }

        }





    }
}
