using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace PayRollManagementSystem
{
    public partial class frmcompanyMaster : EDPComponent.FormBaseERP
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        SqlTransaction sqltran;
        string Imagepath = "";
        string Imagedocument = "", Imagedocument2 = "", Imagedocument3 = "";
        string vBank = "", vAc = "", vifsc = "", vbnkbr = "", vbnkadd = "", pan = "", lin = "";
        SqlCommand cmd = new SqlCommand();
        int co_code = 0;
        string Type = "";
        SqlDataReader myrd;
        public frmcompanyMaster()
        {
            InitializeComponent();
        }

        public void getcode(int code , string p_type)
        {
            co_code = code;
            Type = p_type;
        }
        public void default_area()
        {
            DataTable cnf = clsDataAccess.RunQDTbl("select state,city,country FROM CompanyLimiter");

            if (cnf.Rows.Count > 0)
            {
                this.cmbstate.Text = cnf.Rows[0]["state"].ToString().ToUpper();
                this.txtcity.Text = cnf.Rows[0]["city"].ToString().ToUpper();
                this.cmbCountry.Text = cnf.Rows[0]["country"].ToString().ToUpper();

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


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string C = "";

            if (Type == "P")
            {
                C = "Client";
            }
            else if (Type == "C")
            {
                C = "Company";
            }


            if (SubmitDetails())
            {
                ERPMessageBox.ERPMessage.Show(C + " Name Saved Successfully");

                imgSig.Image = Properties.Resources.blank2;
                txtSign1.Text = "";
                imgSig2.Image = Properties.Resources.blank2;
                txtSign2.Text = "";

                this.Close();

            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit " + C);
            }

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string C = "";
            if (Type == "P")
                C = "Client";
            else
                C = "Company";


            if (DeleteDetails())
            {
                ERPMessageBox.ERPMessage.Show(C + " Name Deleted Successfully");
                this.Close();               
            }
            else
            {
                //  ERPMessageBox.ERPMessage.Show("Failed To Delete Salary Category");
            }
        }

        private void frmcompanyMaster_Load(object sender, EventArgs e)
        {
           // int pn, streg,
                int mn;

                imgSig.Image = Properties.Resources.blank2;
                txtSign1.Text = "";
                imgSig2.Image = Properties.Resources.blank2;
                txtSign2.Text = "";
                imgSig3.Image = Properties.Resources.blank2;
            if (Type == "P")
            {
                this.HeaderText = "Client Master";
                label1.Text = "Client Name";

                btnclear.Visible = false;
                btnImport.Visible = false;
                lblCoLogo.Visible = false;
                txtpath.Visible = false;
                grpImg.Visible = false;
                lblBank.Visible = false;
                txtBank.Visible = false;
                dgBank.Visible = false;
                lblLin.Visible = true;
                txtLIN.Visible = true;
                lblPAN.Visible = true;
                txtPAN.Visible = true;

                lblPoliceLicenseNo.Visible = false;
                txtPoliceLicenseNo.Visible = false;
                lblPoliceLicenseDt.Visible = false;
                dtpPoliceLicenseDt.Visible = false;

                gstinNoCompanyMaster.Visible = false;
                gstinnoTextBox.Visible = false;
                gstPerCompanyMaster.Visible = false;
                gstPerCompanyMasterTextBox.Visible = false;
                sacNoCompanyMaster.Visible = false;
                sacNoTextBox.Visible = false;
                lblClientComp.Visible = true;
                cmbCompany.Visible = true;
                //-----------------------------------
                lblSign1.Visible = false;
                lblsign2.Visible = false;
                imgSig.Visible = false;
                imgSig2.Visible = false;
                btnimpSig.Visible = false;
                btnimpSig2.Visible = false;
                btnDelSig.Visible = false;
                btnDelSig2.Visible = false;
                txtSign1.Visible = false;
                txtSign2.Visible = false;

                lblSeries.Visible = false;
                txtSeries.Visible = false;
                lblSeriesNo.Visible = false;
                txtPadding.Visible = false;

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
                this.HeaderText = "Company Master";
                btnclear.Visible = true;
                btnImport.Visible = true;
                lblCoLogo.Visible = true;
                txtpath.Visible = true;
                grpImg.Visible = true;

                lblPoliceLicenseNo.Visible = true;
                txtPoliceLicenseNo.Visible = true;
                lblPoliceLicenseDt.Visible = true;
                dtpPoliceLicenseDt.Visible = true;
                txtadd2.Visible = false;

                lblBank.Visible = false;
                dgBank.Visible = true;
                txtBank.Visible = false;
                lblLin.Visible = true;
                txtLIN.Visible = true;
                lblPAN.Visible = true;
                txtPAN.Visible = true;
                lblClientComp.Visible = false;
                cmbCompany.Visible = false;
                gstinNoClientMaster.Visible = false;
                gstinNoClientMasterTextBox.Visible = false;

                lblSign1.Visible = true;
                lblsign2.Visible = true;
                imgSig.Visible = true;
                imgSig2.Visible = true;
                btnimpSig.Visible = true;
                btnimpSig2.Visible = true;
                btnDelSig.Visible = true;
                btnDelSig2.Visible = true;
                txtSign1.Visible = true;
                txtSign2.Visible = true;

                lblSeries.Visible = true;
                txtSeries.Visible = true;
                lblSeriesNo.Visible = true;
                txtPadding.Visible = true;

                mn = Convert.ToInt32(clsDataAccess.GetresultI("Branch", "Country"));
                
                     if (mn == 0)
                        {
                            string str = "ALTER TABLE Branch ADD [Country] [numeric] (18, 0) NULL";
                            bool rs = clsDataAccess.RunNQwithStatus(str);

                            str = "Update Branch set Country=(Select Country_CODE from Country where Country_Name='India')";
                            rs = clsDataAccess.RunNQwithStatus(str);
                        }

                     mn = Convert.ToInt32(clsDataAccess.GetresultI("Branch", "website"));

                     if (mn == 0)
                     {
                         string str = "ALTER TABLE [Branch] ADD [website] [nvarchar] (50) NULL";
                         bool rs = clsDataAccess.RunNQwithStatus(str);
                     }
                     mn = Convert.ToInt32(clsDataAccess.GetresultI("Branch", "Email"));

                     if (mn == 0)
                     {
                         string str = "ALTER TABLE [Branch] ADD [Email] [nvarchar] (50) NULL";
                         bool rs = clsDataAccess.RunNQwithStatus(str);
                     }

                     mn = Convert.ToInt32(clsDataAccess.GetresultI("Branch", "Bank"));
                     if (mn == 0)
                     {
                         string str = "ALTER TABLE [Branch] ADD [bank] [nvarchar] (50) NULL,[acno] [nvarchar] (50) NULL,[ifsc] [nvarchar] (50) NULL";
                         bool rs = clsDataAccess.RunNQwithStatus(str);
                     }
                     mn = Convert.ToInt32(clsDataAccess.GetresultI("Branch", "Fax"));
                     if (mn == 0)
                     {
                         string str = "ALTER TABLE [Branch] ADD [Fax] [nvarchar] (50) NULL";
                         bool rs = clsDataAccess.RunNQwithStatus(str);
                     }
            }
            //this.cmbCountry.Text = "India";
            //this.cmbstate.Text = "West Bengal";
            Configuration_Menu_TypeDoc_companySetting();

            default_area();


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
                    DataTable dt = clsDataAccess.RunQDTbl("Select Client_Name,Client_ADD1,Client_ADD2,Client_City,Client_State,Contract_Person,Contract_No,Country,website,Email,Fax,coid,GSTINNO,PAN,LIN from tbl_Employee_CliantMaster where Client_id = '" + co_code + "'");
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
                        txtLIN.Text=dt.Rows[0]["LIN"].ToString().Trim();
                        txtPAN.Text = dt.Rows[0]["PAN"].ToString().Trim();

                        //string Co_Name = clsDataAccess.RunQDTbl("SELECT CO_NAME FROM Company where GCODE='" + Convert.ToString(dt.Rows[0]["coid"]) + "'").Rows[0][0].ToString();
                        cmbCompany.SelectedValue = dt.Rows[0]["coid"];
                    }
                }
                else
                {
                    DataTable dt = clsDataAccess.RunQDTbl("Select Distinct [CO_CODE],[FICode],[GCODE],[CO_NAME],[CO_ADD],[CO_ADD1],[sign],[sign_name],[sign2],[sign2_name],[sign3],[sign3_name],plicence,plicencedt from Company where (GCODE='" + co_code + "')");
                    if (dt.Rows.Count > 0)
                    {
                        txtconame.Text = Convert.ToString(dt.Rows[0]["CO_NAME"]);
                        txtadd1.Text = Convert.ToString(dt.Rows[0]["CO_ADD"]);
                        txtadd2.Text = Convert.ToString(dt.Rows[0]["CO_ADD1"]);
                        txtSign1.Text = dt.Rows[0]["sign_name"].ToString().Trim();
                        txtSign2.Text = dt.Rows[0]["sign2_name"].ToString().Trim();
                        txtPoliceLicenseNo.Text = dt.Rows[0]["plicence"].ToString().Trim();
                        try
                        {
                            dtpPoliceLicenseDt.Value = Convert.ToDateTime(dt.Rows[0]["plicencedt"].ToString());
                        }
                        catch { dtpPoliceLicenseDt.Value = DateTime.Now; }
                        try
                        {
                            Imagepath = Convert.ToString(dt.Rows[0]["sign"]);
                            if (Imagepath != "")
                            {
                              
                                Byte[] MyData = new byte[0];
                                MyData = (Byte[])dt.Rows[0]["sign"];
                                MemoryStream stream = new MemoryStream(MyData);
                                stream.Position = 0;
                                imgSig.Image = Image.FromStream(stream);
                            }
                        }
                        catch { }

                        try
                        {
                            Imagepath = Convert.ToString(dt.Rows[0]["sign2"]);
                            if (Imagepath != "")
                            {
                             

                                Byte[] MyData = new byte[0];
                                MyData = (Byte[])dt.Rows[0]["sign2"];
                                MemoryStream stream = new MemoryStream(MyData);
                                stream.Position = 0;
                                imgSig2.Image = Image.FromStream(stream);
                            }
                        }
                        catch { }
                        

                    }


                    dt = clsDataAccess.RunQDTbl("Select Distinct BRNCH_NAME,BRNCH_ADD1,BRNCH_ADD2,BRNCH_CITY,BRNCH_STATE,BRNCH_TELE1,CONTACT_PERSON,website,Email,Cmpimage,Country,Fax,[bank],[acno],[ifsc],GSTINNO,GSTPER,SACNO,prefix,padding,PAN,LIN,ODetails from Branch where GCODE = '" + co_code + "'");
                    if (dt.Rows.Count > 0)
                    {
                        txtconame.Text = Convert.ToString(dt.Rows[0]["BRNCH_NAME"]);
                        txtadd1.Text = Convert.ToString(dt.Rows[0]["BRNCH_ADD1"]);
                        txtadd2.Text = Convert.ToString(dt.Rows[0]["BRNCH_ADD2"]);
                        txtphoneno.Text = Convert.ToString(dt.Rows[0]["BRNCH_TELE1"]);
                        txtcontractperson.Text = Convert.ToString(dt.Rows[0]["CONTACT_PERSON"]);
                        txtcity.Text = Convert.ToString(dt.Rows[0]["BRNCH_CITY"]);
                        TxtWebSite.Text = Convert.ToString(dt.Rows[0]["Website"]);
                        TxtEmail.Text = Convert.ToString(dt.Rows[0]["Email"].ToString());
                        txtFax.Text = Convert.ToString(dt.Rows[0]["Fax"].ToString());

                        txtSeries.Text = Convert.ToString(dt.Rows[0]["prefix"].ToString());
                        txtPadding.Text = dt.Rows[0]["padding"].ToString();

                        gstinnoTextBox.Text = dt.Rows[0]["GSTINNO"].ToString();
                        gstPerCompanyMasterTextBox.Text = dt.Rows[0]["GSTPER"].ToString();
                        sacNoTextBox.Text = dt.Rows[0]["SACNO"].ToString();

                        txtLIN.Text = dt.Rows[0]["LIN"].ToString().Trim();
                        txtPAN.Text = dt.Rows[0]["PAN"].ToString().Trim();

                        lblOdetails.Text = dt.Rows[0]["ODetails"].ToString().Trim();

                        if (Information.IsNumeric(dt.Rows[0]["BRNCH_STATE"]) == true)
                        {
                            DataTable dt_state = clsDataAccess.RunQDTbl("Select State_Name from StateMaster where STATE_CODE = '" + dt.Rows[0]["BRNCH_STATE"] + "'");
                            if (dt_state.Rows.Count > 0)
                                cmbstate.Text = Convert.ToString(dt_state.Rows[0]["State_Name"]);
                        }
                        if (Information.IsNumeric(dt.Rows[0]["Country"]) == true)
                        {
                            DataTable dt_Country = clsDataAccess.RunQDTbl("Select Country_Name from Country where (Country_CODE='" + dt.Rows[0]["Country"] + "')");
                            if (dt_Country.Rows.Count > 0)
                                this.cmbCountry.Text = Convert.ToString(dt_Country.Rows[0]["Country_Name"]);
                        }

                        // txtBank.Text = Convert.ToString(dt.Rows[0]["bank"].ToString());
                        //txtAcno.Text = Convert.ToString(dt.Rows[0]["acno"].ToString());
                        // txtIFSC.Text = Convert.ToString(dt.Rows[0]["ifsc"].ToString());
                        try
                        {
                            Imagepath = Convert.ToString(dt.Rows[0]["Cmpimage"]);
                            if (Imagepath != "")
                            {
                                //MemoryStream stream = new MemoryStream();
                                //pictureimport.Image = null;
                                ////context.Response.BinaryWrite((Byte[])dr[0]);
                                //byte[] image = ((byte[])dt.Rows[0]["Cmpimage"]);
                                //stream.Write(image, 0, image.Length);
                                ////edpcon.Close();
                                //Bitmap bitmap = new Bitmap(stream);
                                //pictureimport.Image = bitmap;

                                Byte[] MyData = new byte[0];
                                MyData = (Byte[])dt.Rows[0]["Cmpimage"];
                                MemoryStream stream = new MemoryStream(MyData);
                                stream.Position = 0;
                                pictureimport.Image = Image.FromStream(stream);
                            }
                        }
                        catch { }

                        DataTable dt_bank = clsDataAccess.RunQDTbl("Select distinct [bank],[acno],[ifsc],[bank_br],[bank_br_add],[bank_br_code] from Branch where GCODE = '" + co_code + "'");
                        if (dt_bank.Rows.Count > 0)
                        {
                            int dg_rw_bank = 0;
                            for (int dt_ind = 0; dt_ind < dt_bank.Rows.Count; dt_ind++)
                            {
                                dg_rw_bank = dgBank.Rows.Add();

                                dgBank.Rows[dg_rw_bank].Cells["col_bank"].Value = dt_bank.Rows[dt_ind]["bank"].ToString();
                                dgBank.Rows[dg_rw_bank].Cells["col_ac"].Value = dt_bank.Rows[dt_ind]["acno"].ToString();
                                dgBank.Rows[dg_rw_bank].Cells["col_ifsc"].Value = dt_bank.Rows[dt_ind]["ifsc"].ToString();
                                dgBank.Rows[dg_rw_bank].Cells["col_bnkbr"].Value = dt_bank.Rows[dt_ind]["bank_br"].ToString();
                                dgBank.Rows[dg_rw_bank].Cells["col_bnkadd"].Value = dt_bank.Rows[dt_ind]["bank_br_add"].ToString();
                                dgBank.Rows[dg_rw_bank].Cells["col_bnkcode"].Value = dt_bank.Rows[dt_ind]["bank_br_code"].ToString();
                                dgBank.Rows[dg_rw_bank].Cells["col_bid"].Value = dt_ind + 1;

                            }

                        }
                    }
                    else
                    {
                       
                    }

                     
                }
            }
        }

        private Boolean DeleteDetails()
        {
            Boolean boolStatus = false;
            if (Type == "P")
            {
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Employee_CliantMaster where Client_id=" + co_code + "");
                edpcom.InsertMidasLog(this, true, "del", "Client code : " + co_code);
            }
            else
            {
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from Company where CO_CODE=" + co_code + "");
                edpcom.InsertMidasLog(this, true, "del", "Company code : " + co_code);
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from Branch where GCODE=" + co_code + "");
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from grp where GCODE=" + co_code + "");
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from glmst where GCODE=" + co_code + "");
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from prtyms where GCODE=" + co_code + "");
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from Access where GCODE=" + co_code + "");
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from AccessBranch where GCODE=" + co_code + "");
            }
            return boolStatus;
        }

        private Boolean SubmitDetails()
        {
            edpcon.Open();
            cmd.Connection = edpcon.mycon;
            sqltran = edpcon.mycon.BeginTransaction();

            Boolean boolStatus = false;

            if (!String.IsNullOrEmpty(txtconame.Text.Trim()))
            {
                if (co_code > 0)
                {
                    if (Type == "P")
                    {
                        try
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_CliantMaster set Client_Name='" + txtconame.Text.Trim() +
                "',Client_ADD1='" + txtadd1.Text.Trim() + "',Client_ADD2='" + txtadd2.Text.Trim() + "',Client_City='" + txtcity.Text.Trim() +
                "',Client_State='" + clsEmployee.GetStatID(cmbstate.Text.ToString()) + "',Contract_Person='" + txtcontractperson.Text.Trim() +
                "',Contract_No='" + txtphoneno.Text.Trim() + "',Country='" + clsEmployee.GetCountryID(cmbCountry.Text.ToString()) +
                "',Website='" + TxtWebSite.Text.Trim() + "',Email='" + TxtEmail.Text.Trim() + "',Fax='" + txtFax.Text.Trim() +
                "',coid='" + cmbCompany.SelectedValue.ToString().Trim() + "'," +
                "GSTINNO = '"+gstinNoClientMasterTextBox.Text.Trim()+"',PAN='"+txtPAN.Text.Trim()+"',LIN='"+txtLIN.Text.Trim()+"' where (Client_id=" + co_code + ")");
                        }
                        catch 
                        {
                            MessageBox.Show("Select the link Company first");
                            return false;
                        }
                        edpcom.InsertMidasLog(this, true, "mod", "Client code : "+ co_code);
                    }

                    else
                    {
                        string st = "";
                        //photo_convert();
                                     st = "delete from Branch where (GCODE=" + co_code + ")";
                                    try
                                    {
                                        cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
                                        cmd.ExecuteNonQuery();
                                        //sqltran.Commit();
                                        
                                    }
                                    catch { }
                        if (pictureimport.Image != null)
                        {
                            if (dgBank.Rows.Count - 1 > 0)
                            {
                                for (int inde = 0; inde < (dgBank.Rows.Count - 1); inde++)
                                {
                                    string vBank = "", vAc = "", vifsc = "", vbnkbr = "", vbnkadd = "", vbnkcode="";

                                   try{
                                       if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_bank"].Value as string))
                                       {
                                          vBank  = "";
                                       }
                                       else
                                       vBank = dgBank.Rows[inde].Cells["col_bank"].Value.ToString();
                                       
                                   }catch{vBank="";} 
                                    try{
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_ac"].Value as string))
                                        {
                                            vAc = "";
                                        }
                                        else
                                    vAc = dgBank.Rows[inde].Cells["col_ac"].Value.ToString();
                                    }catch{vAc="";}
                                   try{
                                       if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_ifsc"].Value as string))
                                       {
                                           vifsc = "";
                                       }
                                       else
                                    vifsc=dgBank.Rows[inde].Cells["col_ifsc"].Value.ToString();
                                   }catch{vifsc="";}

                                    try{
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_bnkbr"].Value as string))
                                        {
                                            vbnkbr = "";
                                        }
                                        else
                                    vbnkbr= dgBank.Rows[inde].Cells["col_bnkbr"].Value.ToString();
                                    }
                                    catch
                                    {
                                        vbnkbr = "";
                                    }
                                    try{
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_bnkadd"].Value as string))
                                        {
                                            vbnkadd = "";
                                        }else
                                        vbnkadd = dgBank.Rows[inde].Cells["col_bnkadd"].Value.ToString();
                                    }
                                    catch { vbnkadd = ""; }


                                    try
                                    {

                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_bnkcode"].Value as string))
                                        {
                                            vbnkcode = "";
                                        }else
                                        { vbnkcode = dgBank.Rows[inde].Cells["col_bnkcode"].Value.ToString(); }

                                       
                                    }
                                    catch { vbnkcode="";}

                                   st="INSERT INTO [Branch]([FICode],[GCODE],[BRNCH_CODE],[BRNCH_NAME],[BRNCH_ADD1],[BRNCH_ADD2],[BRNCH_CITY]" +
           ",[BRNCH_STATE],[BRNCH_PIN],[BRNCH_CST],[BRNCH_SST],[BRNCH_TELE1],[BRNCH_TELE2],[BRNCH_TELE3],[BRNCH_PAN1],[BRNCH_PAN2],[VAT_DET]" +
           ",[BRNCH_FAX],[BRNCH_EMAIL],[CONTACT_PERSON],[PERSON_DESIG],[FREEZE_FROM],[FREEZE_TO],[COUNTRY],[EX_REG_NO],[EX_DIV],[EX_COMM],[ECC_NO]" +
           ",[EX_RANGE],[Brnch_Alias],[Stax],[STT],[TAN],[STAXNO],[DIN1],[DIN2],[DIN3],[DIN4],[Comp_Type],[Cmpimage],[website],[Email],[bank],[acno]" +
           ",[ifsc],[Fax],[GSTINNO],GSTPER,SACNO,[bank_br],[bank_br_add],[prefix],padding,PAN,LIN,[bank_br_code],ODetails) VALUES('" + edpcom.CurrentFicode + "','" + co_code + "','" + inde + 1 + "','" + txtconame.Text.Trim() + "','" +
            txtadd1.Text + "','" + txtadd2.Text.Trim() + "','" + txtcity.Text.Trim() + "','" + clsEmployee.GetStatID(Convert.ToString(cmbstate.Text)) +
           "','','','','" + txtphoneno.Text.Trim() +"','','','','','','','" + TxtEmail.Text.Trim() +"','" + txtcontractperson.Text.Trim() + "','','','','" + 
           clsEmployee.GetCountryID(cmbCountry.Text.ToString()) +"','','','','','','','0','0','0','0','','','','','',@Personal_Image,'" + TxtWebSite.Text.Trim() +
           "','" + TxtEmail.Text.Trim() +"','" + vBank +"','" + vAc + "','" + vifsc + "','" + txtFax.Text.Trim() + "','" + gstinnoTextBox.Text.Trim() + "','" +
           gstPerCompanyMasterTextBox.Text.Trim() + "','" + sacNoTextBox.Text.Trim() + "','" + vbnkbr + "','" + vbnkadd + "','"+txtSeries.Text.Trim()+"','"+txtPadding.Text.Trim()+"','"+txtPAN.Text.Trim()+"','"+txtLIN.Text.Trim()+"','"+vbnkcode+"','"+lblOdetails.Text+"')";
          
                                    //st = "update Branch set BRNCH_NAME='" + txtconame.Text.Trim() +
                                    //    "',BRNCH_ADD1='" + txtadd1.Text + "',BRNCH_ADD2='" + txtadd2.Text.Trim() +
                                    //    "',BRNCH_CITY='" + txtcity.Text.Trim() +
                                    //    "',BRNCH_STATE='" + clsEmployee.GetStatID(Convert.ToString(cmbstate.SelectedItem)) +
                                    //    "',CONTACT_PERSON='" + txtcontractperson.Text.Trim() +
                                    //    "',BRNCH_TELE1='" + txtphoneno.Text.Trim() +
                                    //    "',website='" + TxtWebSite.Text.Trim() +
                                    //    "',Email='" + TxtEmail.Text.Trim() +
                                    //    "',Country='" + clsEmployee.GetCountryID(cmbCountry.Text.ToString()) +
                                    //    "',bank='" + dgBank.Rows[inde].Cells[""] + "',acno='" + txtAcno.Text.Trim() + "',ifsc='" + txtIFSC.Text.Trim() +
                                    //    "',Fax='" + txtFax.Text.Trim() + "', Cmpimage = @Personal_Image where (GCODE=" + co_code + ")";
                                    try
                                    {
                                        cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                                        photo_convert();
                                       // edpcon.Open();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                                        cmd.ExecuteNonQuery();
                                        
                                      
                                    }


                                    catch { }
                                    
                                }
                                sqltran.Commit();
                                edpcon.Close();
                            }
                            else
                            {
                               // st = "update Branch set BRNCH_NAME='" + txtconame.Text.Trim() +
                               //"',BRNCH_ADD1='" + txtadd1.Text + "',BRNCH_ADD2='" + txtadd2.Text.Trim() +
                               //"',BRNCH_CITY='" + txtcity.Text.Trim() +
                               //"',BRNCH_STATE='" + clsEmployee.GetStatID(Convert.ToString(cmbstate.SelectedItem)) +
                               //"',CONTACT_PERSON='" + txtcontractperson.Text.Trim() +
                               //"',BRNCH_TELE1='" + txtphoneno.Text.Trim() +
                               //"',website='" + TxtWebSite.Text.Trim() +
                               //"',Email='" + TxtEmail.Text.Trim() +
                               //"',Country='" + clsEmployee.GetCountryID(cmbCountry.Text.ToString()) +
                               //"',bank='',acno='',ifsc='',Fax='" + txtFax.Text.Trim() + "', Cmpimage = @Personal_Image where (GCODE=" + co_code + ")";
                                st = "INSERT INTO [Branch]([FICode],[GCODE],[BRNCH_CODE],[BRNCH_NAME],[BRNCH_ADD1],[BRNCH_ADD2],[BRNCH_CITY]" +
           ",[BRNCH_STATE],[BRNCH_PIN],[BRNCH_CST],[BRNCH_SST],[BRNCH_TELE1],[BRNCH_TELE2],[BRNCH_TELE3],[BRNCH_PAN1],[BRNCH_PAN2],[VAT_DET]" +
           ",[BRNCH_FAX],[BRNCH_EMAIL],[CONTACT_PERSON],[PERSON_DESIG],[FREEZE_FROM],[FREEZE_TO],[COUNTRY],[EX_REG_NO],[EX_DIV],[EX_COMM],[ECC_NO]" +
           ",[EX_RANGE],[Brnch_Alias],[Stax],[STT],[TAN],[STAXNO],[DIN1],[DIN2],[DIN3],[DIN4],[Comp_Type],[Cmpimage],[website],[Email],[bank],[acno]" +
           ",[ifsc],[Fax],[GSTINNO],GSTPER,SACNO,[bank_br],[bank_br_add],prefix,padding,PAN,LIN,[bank_br_code],ODetails) VALUES('" + edpcom.CurrentFicode + "','" + co_code + "','1','" + txtconame.Text.Trim() + "','" +
            txtadd1.Text + "','" + txtadd2.Text.Trim() + "','" + txtcity.Text.Trim() + "','" + clsEmployee.GetStatID(Convert.ToString(cmbstate.Text)) +
           "','','','','" + txtphoneno.Text.Trim() + "','','','','','','','" + TxtEmail.Text.Trim() + "','" + txtcontractperson.Text.Trim() + "','','','','" +
           clsEmployee.GetCountryID(cmbCountry.Text.ToString()) + "','','','','','','','0','0','0','0','','','','','',@Personal_Image,'" + TxtWebSite.Text.Trim() +
           "','" + TxtEmail.Text.Trim() + "','','','','" + txtFax.Text.Trim() + "','" + gstinnoTextBox.Text.Trim() + "','" + gstPerCompanyMasterTextBox.Text.Trim() + "','" + 
           sacNoTextBox.Text.Trim() + "','','','" + txtSeries.Text.Trim() + "','" + txtPadding.Text.Trim() + "','" + txtPAN.Text.Trim() + "','" + txtLIN.Text.Trim() + "','','"+lblOdetails.Text+"')";
                                try
                                {
                                    cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                                    photo_convert();
                                    //edpcon.mycon.Open();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                                    cmd.ExecuteNonQuery();
                                    sqltran.Commit();
                                    edpcon.Close();
                                }
                                catch (Exception Ex) {string exp="";
                                    
                                   exp= Ex.ToString(); }
                            }
                        }
                        else
                        {

                            /*-------------------------------------------------------------------------------------------*/
                            if (dgBank.Rows.Count - 1 > 0)
                            {
                                for (int inde = 0; inde < (dgBank.Rows.Count - 1); inde++)
                                {
                                    string vBank = "", vAc = "", vifsc = "", vbnkbr = "", vbnkadd = "";

                                    try
                                    {
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_bank"].Value as string))
                                        {
                                            vBank = "";
                                        }
                                        else
                                            vBank = dgBank.Rows[inde].Cells["col_bank"].Value.ToString();

                                    }
                                    catch { vBank = ""; }
                                    try
                                    {
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_ac"].Value as string))
                                        {
                                            vAc = "";
                                        }
                                        else
                                            vAc = dgBank.Rows[inde].Cells["col_ac"].Value.ToString();
                                    }
                                    catch { vAc = ""; }
                                    try
                                    {
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_ifsc"].Value as string))
                                        {
                                            vifsc = "";
                                        }
                                        else
                                            vifsc = dgBank.Rows[inde].Cells["col_ifsc"].Value.ToString();
                                    }
                                    catch { vifsc = ""; }

                                    try
                                    {
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_bnkbr"].Value as string))
                                        {
                                            vbnkbr = "";
                                        }
                                        else
                                            vbnkbr = dgBank.Rows[inde].Cells["col_bnkbr"].Value.ToString();
                                    }
                                    catch
                                    {
                                        vbnkbr = "";
                                    }
                                    try
                                    {
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_bnkadd"].Value as string))
                                        {
                                            vbnkadd = "";
                                        }
                                        else
                                            vbnkadd = dgBank.Rows[inde].Cells["col_bnkadd"].Value.ToString();
                                    }
                                    catch { vbnkadd = ""; }
                                    st = "INSERT INTO [Branch]([FICode],[GCODE],[BRNCH_CODE],[BRNCH_NAME],[BRNCH_ADD1],[BRNCH_ADD2],[BRNCH_CITY]" +
            ",[BRNCH_STATE],[BRNCH_PIN],[BRNCH_CST],[BRNCH_SST],[BRNCH_TELE1],[BRNCH_TELE2],[BRNCH_TELE3],[BRNCH_PAN1],[BRNCH_PAN2],[VAT_DET]" +
            ",[BRNCH_FAX],[BRNCH_EMAIL],[CONTACT_PERSON],[PERSON_DESIG],[FREEZE_FROM],[FREEZE_TO],[COUNTRY],[EX_REG_NO],[EX_DIV],[EX_COMM],[ECC_NO]" +
            ",[EX_RANGE],[Brnch_Alias],[Stax],[STT],[TAN],[STAXNO],[DIN1],[DIN2],[DIN3],[DIN4],[Comp_Type],[Cmpimage],[website],[Email],[bank],[acno]" +
            ",[ifsc],[Fax],[GSTINNO],GSTPER,SACNO,[bank_br],[bank_br_add],prefix,padding,PAN,LIN,ODetails) VALUES('" + edpcom.CurrentFicode + "','" + co_code + "','" + inde + 1 + "','" + txtconame.Text.Trim() + "','" +
             txtadd1.Text + "','" + txtadd2.Text.Trim() + "','" + txtcity.Text.Trim() + "','" + clsEmployee.GetStatID(Convert.ToString(cmbstate.Text)) +
            "','','','','" + txtphoneno.Text.Trim() + "','','','','','','','" + TxtEmail.Text.Trim() + "','" + txtcontractperson.Text.Trim() + "','','','','" +
            clsEmployee.GetCountryID(cmbCountry.Text.ToString()) + "','','','','','','','0','0','0','0','','','','','',CAST('bPftidzyAQik' AS VARBINARY),'" + TxtWebSite.Text.Trim() +
            "','" + TxtEmail.Text.Trim() + "','" + vBank + "','" + vAc +
            "','" + vifsc + "','" + txtFax.Text.Trim() + "','" + gstinnoTextBox.Text.Trim() + "','" + gstPerCompanyMasterTextBox.Text.Trim() + "','" +
            sacNoTextBox.Text.Trim() + "','" + vbnkbr + "','" + vbnkadd + "','"+txtSeries.Text.Trim()+"','"+txtPadding.Text.Trim()+"','"+txtPAN.Text.Trim()+"','"+txtLIN.Text.Trim()+"','"+lblOdetails.Text+"')";
                                    try
                                    {
                                        cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                                        //photo_convert();
                                        // edpcon.Open();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                                        cmd.ExecuteNonQuery();
                                    }


                                    catch { }

                                }
                                sqltran.Commit();
                                edpcon.Close();
                            }
                            else
                            {
                                st = "INSERT INTO [Branch]([FICode],[GCODE],[BRNCH_CODE],[BRNCH_NAME],[BRNCH_ADD1],[BRNCH_ADD2],[BRNCH_CITY]" +
           ",[BRNCH_STATE],[BRNCH_PIN],[BRNCH_CST],[BRNCH_SST],[BRNCH_TELE1],[BRNCH_TELE2],[BRNCH_TELE3],[BRNCH_PAN1],[BRNCH_PAN2],[VAT_DET]" +
           ",[BRNCH_FAX],[BRNCH_EMAIL],[CONTACT_PERSON],[PERSON_DESIG],[FREEZE_FROM],[FREEZE_TO],[COUNTRY],[EX_REG_NO],[EX_DIV],[EX_COMM],[ECC_NO]" +
           ",[EX_RANGE],[Brnch_Alias],[Stax],[STT],[TAN],[STAXNO],[DIN1],[DIN2],[DIN3],[DIN4],[Comp_Type],[Cmpimage],[website],[Email],[bank],[acno]" +
           ",[ifsc],[Fax],[GSTINNO],GSTPER,SACNO,[bank_br],[bank_br_add],prefix,padding,PAN,LIN,ODetails) VALUES('" + edpcom.CurrentFicode + "','" + co_code + "','1','" + txtconame.Text.Trim() + "','" +
            txtadd1.Text + "','" + txtadd2.Text.Trim() + "','" + txtcity.Text.Trim() + "','" + clsEmployee.GetStatID(Convert.ToString(cmbstate.Text)) +
           "','','','','" + txtphoneno.Text.Trim() + "','','','','','','','" + TxtEmail.Text.Trim() + "','" + txtcontractperson.Text.Trim() + "','','','','" +
           clsEmployee.GetCountryID(cmbCountry.Text.ToString()) + "','','','','','','','0','0','0','0','','','','','',CAST('bPftidzyAQik' AS VARBINARY),'" + TxtWebSite.Text.Trim() +
           "','" + TxtEmail.Text.Trim() + "','','','','" + txtFax.Text.Trim() + "','" + gstinnoTextBox.Text.Trim() + "','" + gstPerCompanyMasterTextBox.Text.Trim() + "','" + sacNoTextBox.Text.Trim() + "','','','"+txtSeries.Text.Trim()+"','"+txtPadding.Text.Trim()+"','"+txtPAN.Text.Trim()+"','"+txtLIN.Text.Trim()+"','"+lblOdetails.Text+"')";
                                try
                                {
                                    cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                                    photo_convert();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                                    cmd.ExecuteNonQuery();
                                    sqltran.Commit();
                                    edpcon.Close();
                                }
                                catch { }
                            }
                            /*-------------------------------------------------------------------------------------------*/
                            
                            /*st = "update Branch set BRNCH_NAME='" + txtconame.Text.Trim() + 
                                "',BRNCH_ADD1='" + txtadd1.Text.Trim() + "',BRNCH_ADD2='" + txtadd2.Text.Trim() + 
                                "',BRNCH_CITY='" + txtcity.Text.Trim() + 
                                "',BRNCH_STATE='" + clsEmployee.GetStatID(Convert.ToString(cmbstate.Text)) + 
                                "',CONTACT_PERSON='" + txtcontractperson.Text.Trim() + 
                                "',BRNCH_TELE1='" + txtphoneno.Text.Trim() +
                                "',website='" + TxtWebSite.Text.Trim() +
                                "',Email='" + TxtEmail.Text.Trim() +
                                "',Country='" + clsEmployee.GetCountryID(cmbCountry.Text.ToString()) +
                                "',bank='" + txtBank.Text.Trim() + "',acno='" + txtAcno.Text.Trim() + "',ifsc='" + txtIFSC.Text.Trim() +
                                "',Fax='" + txtFax.Text.Trim() + "', Cmpimage =  CAST('bPftidzyAQik' AS VARBINARY),GSTINNO = '" + gstinnoTextBox.Text +
                                "',GSTPER = '"+gstPerCompanyMasterTextBox.Text.Trim()+
                                "',SACNO = '"+sacNoTextBox.Text.Trim()+"' where (GCODE=" + co_code + ")";
                            try
                            {
                                cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                                //photo_convert();
                                //edpcon.mycon.Open();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                                cmd.ExecuteNonQuery();
                                sqltran.Commit();
                                edpcon.Close();
                            }
                            catch { }*/
                            
                        }

                        edpcom.InsertMidasLog(this, true, "mod", "Company code : " + co_code);
                        boolStatus = clsDataAccess.RunNQwithStatus("update Company set CO_NAME='" + txtconame.Text.Trim() + "',CO_ADD='" + txtadd1.Text.Trim() + "',CO_ADD1='" + txtadd2.Text.Trim() + "',CO_SDATE='04/01/2016',CO_EDATE='03/31/2016' where CO_CODE=" + co_code + "");
                        update_company_sign(co_code.ToString());
                        //boolStatus = clsDataAccess.RunNQwithStatus(st);
                     //"update Branch set BRNCH_NAME='" + txtconame.Text.Trim() + "',BRNCH_ADD1='" + txtadd1.Text.Trim() + "',BRNCH_ADD2='" + txtadd2.Text.Trim() + "',BRNCH_CITY='" + txtcity.Text.Trim() + "',BRNCH_STATE='" + clsEmployee.GetStatID(Convert.ToString(cmbstate.Text.Trim())) + "',CONTACT_PERSON='" + txtcontractperson.Text.Trim() + "',BRNCH_TELE1='" + txtphoneno.Text.Trim() + "',Country='" + clsEmployee.GetCountryID(cmbCountry.Text.Trim().ToString()) + "' where (GCODE=" + co_code + ")");
                    }
                }
                else
                {
                    if (Type == "P")
                    {
                        int Max_ID = 0;
                        DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(Client_id) FROM tbl_Employee_CliantMaster");
                        if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                        {
                            Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                        }
                        else
                        {
                            Max_ID = 1;
                        }

                        DataTable dt33 = clsDataAccess.RunQDTbl("Select Client_Name from tbl_Employee_CliantMaster where Client_Name='" + txtconame.Text.Trim() + "'");
                        if (dt33.Rows.Count == 0)
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_CliantMaster(Client_id,Client_Name,Client_ADD1,Client_ADD2,Client_City,Client_State,Contract_Person,Contract_No,Country,Website,Email,Fax,coid,GSTINNO) values('" + Max_ID + "','" + txtconame.Text.Trim() + "','" + txtadd1.Text.Trim() + "','" + txtadd2.Text.Trim() + "','" + txtcity.Text.Trim() + "','" + clsEmployee.GetStatID(cmbstate.Text.Trim().ToString()) + "','" + txtcontractperson.Text.Trim() + "','" + txtphoneno.Text.Trim() + "','" + clsEmployee.GetCountryID(cmbCountry.Text.Trim().ToString()) + "','"+ TxtWebSite.Text.Trim() +"','"+ TxtEmail.Text.Trim() +"','"+ txtFax.Text.Trim() +"','"+ cmbCompany.SelectedValue.ToString().Trim() +"','"+gstinNoClientMasterTextBox.Text.Trim()+"')");
                        }
                        else
                        {
                            ERPMessageBox.ERPMessage.Show("Client '" + txtconame.Text.Trim() + "' Already Exists");
                            boolStatus = false;
                        }
                        edpcom.InsertMidasLog(this, true, "add", "Client code : " + Max_ID);
                        //boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_CliantMaster(Client_id,Client_Name,Client_ADD1,Client_ADD2,Client_City,Client_State,Contract_Person,Contract_No) values('" + Max_ID + "','" + txtconame.Text.Trim() + "','" + txtadd1.Text.Trim() + "','" + txtadd2.Text.Trim() + "','" + txtcity.Text.Trim() + "','" + clsEmployee.GetStatID(cmbstate.SelectedItem.ToString()) + "','" + txtcontractperson.Text.Trim() + "','" + txtphoneno.Text.Trim() + "')");
                    }
                    else
                    {
                        //

                        //
                        int Max_ID = 0;
                        DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(CO_CODE) FROM Company ");
                        if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                        {
                            //Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                            string sqlstr = "";
                            //SqlDataReader myrd;
                            string gcode = "";

                            //edpcon.mycon.Close();
                            sqlstr = "select max(CO_CODE) from company ";
                            //edpcon.mycon.Open ();
                            cmd = new SqlCommand(sqlstr, edpcon.mycon, sqltran);
                            myrd = cmd.ExecuteReader();
                            if (myrd.Read())
                            {
                                gcode = myrd.GetString(0);
                                myrd.Close();
                                //edpcon.mycon.Close();
                                sqlstr = "select * from company where gcode>" + gcode;
                                //edpcon.mycon.Open();
                                cmd = new SqlCommand(sqlstr, edpcon.mycon, sqltran);
                                myrd = cmd.ExecuteReader();
                                while (myrd.Read())
                                    gcode = myrd.GetString(2);
                                gcode = Convert.ToString(int.Parse(gcode) + 1);
                                //edpcon.mycon.Close();
                                myrd.Close();
                                Max_ID = Convert.ToInt32(gcode);
                            }
                        }
                        else
                        {
                            Max_ID = 1;
                        }

                        int Max_ID_comid_rln = 0;
                        DataTable dt1 = clsDataAccess.RunQDTbl("SELECT Max(id) FROM Companywiseid_Relation");
                        if (Convert.ToString(dt1.Rows[0][0]).Length > 0)
                        {
                            Max_ID_comid_rln = Convert.ToInt32(dt1.Rows[0][0]) + 1;
                        }
                        else
                        {
                            Max_ID_comid_rln = 1;
                        }

                        string st = "";
                        //if (pictureimport.Image != null)
                        //{
                        //    try
                        //    {
                        //        //string st = "";
                        //        st = "update Branch set BRNCH_NAME='" + txtconame.Text + "',BRNCH_ADD1='" + txtadd1.Text + "',BRNCH_ADD2='" + txtadd2.Text + "',BRNCH_CITY='" + txtcity.Text + "',BRNCH_STATE='" + clsEmployee.GetStatID(Convert.ToString(cmbstate.Text)) + "',CONTACT_PERSON='" + txtcontractperson.Text + "',BRNCH_TELE1='" + txtphoneno.Text + "',Country='" + clsEmployee.GetCountryID(cmbCountry.Text.ToString()) +  "', Cmpimage = @Personal_Image where (GCODE=" + co_code + ")";
                        //        cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                        //        photo_convert();
                        //        //edpcon.mycon.Open();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                        //        cmd.ExecuteNonQuery();
                        //        sqltran.Commit();
                        //        edpcon.Close();
                        //    }
                        //    catch { }
                        //}
                        //else
                        //{
                        //    st = "update Branch set BRNCH_NAME='" + txtconame.Text + "',BRNCH_ADD1='" + txtadd1.Text + "',BRNCH_ADD2='" + txtadd2.Text + "',BRNCH_CITY='" + txtcity.Text + "',BRNCH_STATE='" + clsEmployee.GetStatID(Convert.ToString(cmbstate.SelectedItem)) + "',CONTACT_PERSON='" + txtcontractperson.Text + "',BRNCH_TELE1='" + txtphoneno.Text + "',Country='" + clsEmployee.GetCountryID(cmbCountry.Text.ToString()) +  "',Cmpimage =  CAST('bPftidzyAQik' AS VARBINARY) where (GCODE=" + co_code + ")";
                        //    cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                        //    //photo_convert();
                        //    edpcon.mycon.Close();
                        //    edpcon.mycon.Open();
                        //    cmd.ExecuteNonQuery();
                        //    //sqltran.Commit();
                        //    edpcon.Close();

                        //}
                        edpcom.InsertMidasLog(this, true, "add", "Company code : " + Max_ID);
                        try
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into Company(CO_CODE,FICode,GCODE,CO_NAME,CO_ADD,CO_ADD1,CO_SDATE,CO_EDATE,plicence,plicencedt) values('" + Max_ID + "','" + edpcom.CurrentFicode + "','" + Max_ID + "','" + txtconame.Text.Trim() + "','" + txtadd1.Text.Trim() + "','" + txtadd2.Text.Trim() + "','04/01/2015','03/31/2016','"+txtPoliceLicenseNo.Text.Trim()+"','"+dtpPoliceLicenseDt.Value.ToString("dd/MMM/yyyy")+"')");
                            co_code = Convert.ToInt32(Max_ID);
                            update_company_sign(co_code.ToString());
                        }
                        catch
                        {
                            //boolStatus = clsDataAccess.RunNQwithStatus("insert into Company(CO_CODE,FICode,GCODE,CO_NAME,CO_ADD,CO_ADD1,CO_SDATE,CO_EDATE) values('" + Convert.ToInt32(Max_ID) + 1 + "','" + edpcom.CurrentFicode + "','" + Convert.ToInt32(Max_ID) + 1 + "','" + txtconame.Text.Trim() + "','" + txtadd1.Text.Trim() + "','" + txtadd2.Text.Trim() + "','04/01/2015','03/31/2016' )");

                        }
                        if (boolStatus == false)
                        {

                            boolStatus = clsDataAccess.RunNQwithStatus("insert into Company(CO_CODE,FICode,GCODE,CO_NAME,CO_ADD,CO_ADD1,CO_SDATE,CO_EDATE,plicence,plicencedt) values('" + Convert.ToInt32(Max_ID) + 1 + "','" + edpcom.CurrentFicode + "','" + Convert.ToInt32(Max_ID) + 1 + "','" + txtconame.Text.Trim() + "','" + txtadd1.Text.Trim() + "','" + txtadd2.Text.Trim() + "','04/01/2015','03/31/2016','" + txtPoliceLicenseNo.Text.Trim() + "','" + dtpPoliceLicenseDt.Value.ToString("dd/MMM/yyyy") + "')");

                            co_code = Convert.ToInt32(Max_ID) + 1;
                        }

                        if (pictureimport.Image != null)
                        {
       //                     try
       //                     {
       //                         //string st = "";
                               
       //                         st = "update Branch set BRNCH_NAME='" + txtconame.Text.Trim() + 
       //"',BRNCH_ADD1='" + txtadd1.Text.Trim() + "',BRNCH_ADD2='" + txtadd2.Text.Trim() + "',BRNCH_CITY='" + txtcity.Text.Trim() + 
       //"',BRNCH_STATE='" + clsEmployee.GetStatID(Convert.ToString(cmbstate.SelectedItem)) + 
       //"',CONTACT_PERSON='" + txtcontractperson.Text.Trim() + "',BRNCH_TELE1='" + txtphoneno.Text.Trim() +
       //"',website='" + TxtWebSite.Text.Trim() + "',Email='" + TxtEmail.Text.Trim() +
       //"',Country='" + clsEmployee.GetCountryID(cmbCountry.Text.Trim().ToString()) +
       //"',bank='" + txtBank.Text.Trim() + "',acno='" + txtAcno.Text.Trim() + "',ifsc='" + txtIFSC.Text.Trim() +
       //"',Fax='" + txtFax.Text.Trim() + "', Cmpimage =  @Personal_Image where GCODE=" + Max_ID + "";
                               
                               
       //                         boolStatus = true;
       //                     }
       //                     catch
       //                     {
       //                         boolStatus = false;
       //                     }
                            if (dgBank.Rows.Count - 1 > 0)
                            {
                                for (int inde = 0; inde < (dgBank.Rows.Count - 1); inde++)
                                {
                                    vBank = ""; vAc = ""; vifsc = ""; vbnkbr = ""; vbnkadd = "";

                                    try
                                    {
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_bank"].Value as string))
                                        {
                                            vBank = "";
                                        }
                                        else
                                            vBank = dgBank.Rows[inde].Cells["col_bank"].Value.ToString();

                                    }
                                    catch { vBank = ""; }
                                    try
                                    {
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_ac"].Value as string))
                                        {
                                            vAc = "";
                                        }
                                        else
                                            vAc = dgBank.Rows[inde].Cells["col_ac"].Value.ToString();
                                    }
                                    catch { vAc = ""; }
                                    try
                                    {
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_ifsc"].Value as string))
                                        {
                                            vifsc = "";
                                        }
                                        else
                                            vifsc = dgBank.Rows[inde].Cells["col_ifsc"].Value.ToString();
                                    }
                                    catch { vifsc = ""; }

                                    try
                                    {
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_bnkbr"].Value as string))
                                        {
                                            vbnkbr = "";
                                        }
                                        else
                                            vbnkbr = dgBank.Rows[inde].Cells["col_bnkbr"].Value.ToString();
                                    }
                                    catch
                                    {
                                        vbnkbr = "";
                                    }
                                    try
                                    {
                                        if (string.IsNullOrEmpty(dgBank.Rows[inde].Cells["col_bnkadd"].Value as string))
                                        {
                                            vbnkadd = "";
                                        }
                                        else
                                            vbnkadd = dgBank.Rows[inde].Cells["col_bnkadd"].Value.ToString();
                                    }
                                    catch { vbnkadd = ""; }
                                    if (co_code == 0) { co_code = 1; }
                                    st = "INSERT INTO [Branch]([FICode],[GCODE],[BRNCH_CODE],[BRNCH_NAME],[BRNCH_ADD1],[BRNCH_ADD2],[BRNCH_CITY]" +
            ",[BRNCH_STATE],[BRNCH_PIN],[BRNCH_CST],[BRNCH_SST],[BRNCH_TELE1],[BRNCH_TELE2],[BRNCH_TELE3],[BRNCH_PAN1],[BRNCH_PAN2],[VAT_DET]" +
            ",[BRNCH_FAX],[BRNCH_EMAIL],[CONTACT_PERSON],[PERSON_DESIG],[FREEZE_FROM],[FREEZE_TO],[COUNTRY],[EX_REG_NO],[EX_DIV],[EX_COMM],[ECC_NO]" +
            ",[EX_RANGE],[Brnch_Alias],[Stax],[STT],[TAN],[STAXNO],[DIN1],[DIN2],[DIN3],[DIN4],[Comp_Type],[Cmpimage],[website],[Email],[bank],[acno]" +
            ",[ifsc],[Fax],GSTINNO,GSTPER,SACNO,[bank_br],[bank_br_add],prefix,padding,PAN,LIN,ODetails) VALUES('" + edpcom.CurrentFicode + "','" + co_code + "','" + (inde + 1) + Convert.ToInt32(1) + "','" + txtconame.Text.Trim() + "','" +
             txtadd1.Text + "','" + txtadd2.Text.Trim() + "','" + txtcity.Text.Trim() + "','" + clsEmployee.GetStatID(Convert.ToString(cmbstate.Text)) +
            "','','','','" + txtphoneno.Text.Trim() + "','','','','','','','" + TxtEmail.Text.Trim() + "','" + txtcontractperson.Text.Trim() + "','','','','" +
            clsEmployee.GetCountryID(cmbCountry.Text.ToString()) + "','','','','','','','0','0','0','0','','','','','',@Personal_Image,'" + TxtWebSite.Text.Trim() +
            "','" + TxtEmail.Text.Trim() + "','" + vBank + "','" + vAc + "','" + vifsc + "','" + txtFax.Text.Trim() + "','" + gstinnoTextBox.Text.Trim() + "','" + gstPerCompanyMasterTextBox.Text.Trim() + "','" +
            sacNoTextBox.Text.Trim() + "','" + vbnkbr + "','" + vbnkadd + "','" + txtSeries.Text.Trim() + "','" + txtPadding.Text.Trim() + "','" + txtPAN.Text.Trim() + "','" + txtLIN.Text.Trim() + "','"+lblOdetails.Text+"')";

                                    //st = "update Branch set BRNCH_NAME='" + txtconame.Text.Trim() +
                                    //    "',BRNCH_ADD1='" + txtadd1.Text + "',BRNCH_ADD2='" + txtadd2.Text.Trim() +
                                    //    "',BRNCH_CITY='" + txtcity.Text.Trim() +
                                    //    "',BRNCH_STATE='" + clsEmployee.GetStatID(Convert.ToString(cmbstate.SelectedItem)) +
                                    //    "',CONTACT_PERSON='" + txtcontractperson.Text.Trim() +
                                    //    "',BRNCH_TELE1='" + txtphoneno.Text.Trim() +
                                    //    "',website='" + TxtWebSite.Text.Trim() +
                                    //    "',Email='" + TxtEmail.Text.Trim() +
                                    //    "',Country='" + clsEmployee.GetCountryID(cmbCountry.Text.ToString()) +
                                    //    "',bank='" + dgBank.Rows[inde].Cells[""] + "',acno='" + txtAcno.Text.Trim() + "',ifsc='" + txtIFSC.Text.Trim() +
                                    //    "',Fax='" + txtFax.Text.Trim() + "', Cmpimage = @Personal_Image where (GCODE=" + co_code + ")";
                                    try
                                    {
                                        cmd = new SqlCommand(st, edpcon.mycon);
                                        photo_convert();
                                        // edpcon.Open();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                                        cmd.ExecuteNonQuery();


                                    }


                                    catch { }

                                }
                                sqltran.Commit();
                                edpcon.Close();
                            }
                            else
                            {
                                /*st = "update Branch set BRNCH_NAME='" + txtconame.Text.Trim() +
                               "',BRNCH_ADD1='" + txtadd1.Text + "',BRNCH_ADD2='" + txtadd2.Text.Trim() +
                               "',BRNCH_CITY='" + txtcity.Text.Trim() +
                               "',BRNCH_STATE='" + clsEmployee.GetStatID(Convert.ToString(cmbstate.SelectedItem)) +
                               "',CONTACT_PERSON='" + txtcontractperson.Text.Trim() +
                               "',BRNCH_TELE1='" + txtphoneno.Text.Trim() +
                               "',website='" + TxtWebSite.Text.Trim() +
                               "',Email='" + TxtEmail.Text.Trim() +
                               "',Country='" + clsEmployee.GetCountryID(cmbCountry.Text.ToString()) +
                               "',bank='" + txtBank.Text.Trim() + "',acno='" + txtAcno.Text.Trim() + "',ifsc='" + txtIFSC.Text.Trim() +"',Fax='" + txtFax.Text.Trim() + "', Cmpimage = @Personal_Image,GSTINNO = '"+gstinnoTextBox.Text+"',GSTPER = '"+gstPerCompanyMasterTextBox.Text.Trim()+
                                "',SACNO = '"+sacNoTextBox.Text.Trim()+"' where (GCODE=" + co_code + ")";*/
                                st = "INSERT INTO [Branch]([FICode],[GCODE],[BRNCH_CODE],[BRNCH_NAME],[BRNCH_ADD1],[BRNCH_ADD2],[BRNCH_CITY]" +
            ",[BRNCH_STATE],[BRNCH_PIN],[BRNCH_CST],[BRNCH_SST],[BRNCH_TELE1],[BRNCH_TELE2],[BRNCH_TELE3],[BRNCH_PAN1],[BRNCH_PAN2],[VAT_DET]" +
            ",[BRNCH_FAX],[BRNCH_EMAIL],[CONTACT_PERSON],[PERSON_DESIG],[FREEZE_FROM],[FREEZE_TO],[COUNTRY],[EX_REG_NO],[EX_DIV],[EX_COMM],[ECC_NO]" +
            ",[EX_RANGE],[Brnch_Alias],[Stax],[STT],[TAN],[STAXNO],[DIN1],[DIN2],[DIN3],[DIN4],[Comp_Type],[Cmpimage],[website],[Email],[bank],[acno]" +
            ",[ifsc],[Fax],GSTINNO,GSTPER,SACNO,[bank_br],[bank_br_add],prefix,padding,PAN,LIN,ODetails) VALUES('" + edpcom.CurrentFicode + "','" + co_code + "','" + (1) + Convert.ToInt32(1) + "','" + txtconame.Text.Trim() + "','" +
             txtadd1.Text + "','" + txtadd2.Text.Trim() + "','" + txtcity.Text.Trim() + "','" + clsEmployee.GetStatID(Convert.ToString(cmbstate.Text)) +
            "','','','','" + txtphoneno.Text.Trim() + "','','','','','','','" + TxtEmail.Text.Trim() + "','" + txtcontractperson.Text.Trim() + "','','','','" +
            clsEmployee.GetCountryID(cmbCountry.Text.ToString()) + "','','','','','','','0','0','0','0','','','','','',@Personal_Image,'" + TxtWebSite.Text.Trim() +
            "','" + TxtEmail.Text.Trim() + "','','','','" + txtFax.Text.Trim() + "','" + gstinnoTextBox.Text.Trim() + "','" + gstPerCompanyMasterTextBox.Text.Trim() + "','" + sacNoTextBox.Text.Trim() + "','','','" + txtSeries.Text.Trim() + "','" + txtPadding.Text.Trim() + "','" + txtPAN.Text.Trim() + "','" + txtLIN.Text.Trim() + "','"+lblOdetails.Text+"')";
                                try
                                {
                                    cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                                    photo_convert();
                                    //edpcon.mycon.Open();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                                    cmd.ExecuteNonQuery();
                                    sqltran.Commit();
                                    edpcon.Close();
                                }
                                catch { }
                            }

                        }
                        else
                        {
                            st = "update Branch set BRNCH_NAME='" + txtconame.Text.Trim() +
                             "',BRNCH_ADD1='" + txtadd1.Text.Trim() + "',BRNCH_ADD2='" + txtadd2.Text.Trim() +
                             "',BRNCH_CITY='" + txtcity.Text.Trim() +
                             "',BRNCH_STATE='" + clsEmployee.GetStatID(Convert.ToString(cmbstate.Text.Trim())) +
                             "',CONTACT_PERSON='" + txtcontractperson.Text.Trim() +
                             "',BRNCH_TELE1='" + txtphoneno.Text.Trim() +
                             "',website='" + TxtWebSite.Text.Trim() + "',Email='" + TxtEmail.Text.Trim() +
                             "',Country='" + clsEmployee.GetCountryID(cmbCountry.Text.Trim().ToString()) +
                             "',bank='" + txtBank.Text.Trim() + "',Fax='" + txtFax.Text.Trim() + 
                             "', Cmpimage =  CAST('bPftidzyAQik' AS VARBINARY),GSTINNO = '" + gstinnoTextBox.Text + 
                             "',GSTPER = '" + gstPerCompanyMasterTextBox.Text.Trim() + "',SACNO = '" + sacNoTextBox.Text.Trim() + 
                             "',prefix='" + txtSeries.Text.Trim() + "',oadding='" + txtPadding.Text.Trim() + 
                             "',PAN='" + txtPAN.Text.Trim() + "',LIN='" + txtLIN.Text.Trim() + "',ODetails='"+lblOdetails.Text+"' where (GCODE=" + co_code + ")";

                            /*st = "INSERT INTO [Branch]([FICode],[GCODE],[BRNCH_CODE],[BRNCH_NAME],[BRNCH_ADD1],[BRNCH_ADD2],[BRNCH_CITY]" +
           ",[BRNCH_STATE],[BRNCH_PIN],[BRNCH_CST],[BRNCH_SST],[BRNCH_TELE1],[BRNCH_TELE2],[BRNCH_TELE3],[BRNCH_PAN1],[BRNCH_PAN2],[VAT_DET]" +
           ",[BRNCH_FAX],[BRNCH_EMAIL],[CONTACT_PERSON],[PERSON_DESIG],[FREEZE_FROM],[FREEZE_TO],[COUNTRY],[EX_REG_NO],[EX_DIV],[EX_COMM],[ECC_NO]" +
           ",[EX_RANGE],[Brnch_Alias],[Stax],[STT],[TAN],[STAXNO],[DIN1],[DIN2],[DIN3],[DIN4],[Comp_Type],[Cmpimage],[website],[Email],[bank],[acno]" +
           ",[ifsc],[Fax],[GSTINNO],GSTPER,SACNO) VALUES('" + edpcom.CurrentFicode + "','" + co_code + "','1','" + txtconame.Text.Trim() + "','" +
            txtadd1.Text + "','" + txtadd2.Text.Trim() + "','" + txtcity.Text.Trim() + "','" + clsEmployee.GetStatID(Convert.ToString(cmbstate.Text)) +
           "','','','','" + txtphoneno.Text.Trim() + "','','','','','','','" + TxtEmail.Text.Trim() + "','" + txtcontractperson.Text.Trim() + "','','','','" +
           clsEmployee.GetCountryID(cmbCountry.Text.ToString()) + "','','','','','','','0','0','0','0','','','','','',@Personal_Image,'" + TxtWebSite.Text.Trim() +
           "','" + TxtEmail.Text.Trim() + "','','','','" + txtFax.Text.Trim() + "','" + gstinnoTextBox.Text.Trim() + "','" + gstPerCompanyMasterTextBox.Text.Trim() + "','" + sacNoTextBox.Text.Trim() + "')";*/
                            //boolStatus = clsDataAccess.RunNQwithStatus(st);
                            try
                            {
                                cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                                photo_convert();
                                //edpcon.mycon.Open();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                                cmd.ExecuteNonQuery();
                                sqltran.Commit();
                                edpcon.Close();
                            }
                            catch { }
                            
                        }
                       
                       
       //                     "update Branch set BRNCH_NAME='" + txtconame.Text + 
       //"',BRNCH_ADD1='" + txtadd1.Text + "',BRNCH_ADD2='" + txtadd2.Text + "',BRNCH_CITY='" + txtcity.Text + 
       //"',BRNCH_STATE='" + clsEmployee.GetStatID(Convert.ToString(cmbstate.SelectedItem)) + 
       //"',CONTACT_PERSON='" + txtcontractperson.Text + "',BRNCH_TELE1='" + txtphoneno.Text + 
       //"',Country='" + clsEmployee.GetCountryID(cmbCountry.Text.ToString()) + 
       //"',Cmpimage =  CAST('bPftidzyAQik' AS VARBINARY) where GCODE=" + Max_ID + "");

                      //  boolStatus = clsDataAccess.RunNQwithStatus("Disable trigger TrigLeave on [Companywiseid_Relation]");

                       // boolStatus = clsDataAccess.RunNQwithStatus("insert into Companywiseid_Relation(id,Company_ID,Location_ID) values('" + Max_ID_comid_rln + "','" + Max_ID + "',0)");

                      //**** for this triger double ab value was inserting ****
                        //boolStatus = clsDataAccess.RunNQwithStatus("Enable trigger TrigLeave on [Companywiseid_Relation]");

                        //boolStatus = clsDataAccess.RunNQwithStatus("insert into Branch(FICode,GCODE,BRNCH_CODE,BRNCH_NAME,BRNCH_ADD1,BRNCH_ADD2,BRNCH_CITY,BRNCH_STATE,CONTACT_PERSON,BRNCH_TELE1) values('1','" + Max_ID + "','" + Max_ID + "','" + txtconame.Text + "','" + txtadd1.Text + "','" + txtadd2.Text + "','" + clsEmployee.GetCountryID(cmbcity.SelectedItem.ToString()) + "','" + clsEmployee.GetStatID(cmbstate.SelectedItem.ToString()) + "','" + txtcontractperson.Text + "','" + txtphoneno.Text + "')");
                    }
                }
            }
            else
            {
                string C = "";
                if (Type == "P")
                    C = "Client";
                else
                    C = "Company";

                ERPMessageBox.ERPMessage.Show("Please Enter " + C + " Name ");
            }
            return boolStatus;
        }       

        private void cmbstate_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT State_Name FROM StateMaster order by State_Name asc");
            cmbstate.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                cmbstate.Items.Add(dt.Rows[i][0].ToString());
            }
            //cmbstate_DropDown(sender, e);
        }      

        private void cmbstate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbstate.DroppedDown = true;
            }
        }

        private void cmbstate_Enter(object sender, EventArgs e)
        {
            if (cmbstate.Text == "")
                cmbstate.DroppedDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtpath.Text = Imagepath;
                pictureimport.ImageLocation = Imagepath;

                //pictureimport.Image = new Bitmap(Imagepath);

                //string ss = "";
                //string arguments = Environment.CommandLine;
                //string[] st = new string[] { };
                //st = Imagepath.Split('\\');
                ////ss = arguments.Replace("PayRollManagementSystem.vshost.exe", "");
                //ss = arguments.Replace("PayRollManagementSystem.exe", "");
                //string sss = ss.Substring(1, ss.Length - 3);
                //Imagepath = sss + "Picture\\" + cmbdEmpId.Text + st[st.Length - 1];

                //Bitmap bp = new Bitmap(texpath.Text);
                //string aa = sss + "Picture\\" + cmbdEmpId.Text + st[st.Length - 1];
                //bp.Save(aa);

            }
            catch { }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            pictureimport.Image = null;
            txtpath.Text = "";
            Imagepath = "";
        }
        public void update_company_sign(string coid)
        {

          
            MemoryStream ms;
            bool boolstatus = false;
            byte[] sign = null, sign2 = null, sign3 = null;


            string qry = "update company set [sign]=@sign,[sign_name]='" + txtSign1.Text.Trim() +
            "',[sign2]=@sign2,[sign2_name]='" + txtSign2.Text.Trim() +
            "',[sign3]=@sign3,[sign3_name]='',plicence='" + txtPoliceLicenseNo.Text.Trim() + 
            "',plicencedt='" + dtpPoliceLicenseDt.Value.ToString("dd/MMM/yyyy") + "' where ([CO_CODE]='" + coid + "')";
            try
            {
                edpcon.Open();
            }
            catch { }
            try
            {
               // sqltran = edpcon.mycon.BeginTransaction();
                cmd = new SqlCommand(qry, edpcon.mycon,sqltran);
                if ( imgSig.Image != null)
                {
                    ms = new MemoryStream();
                    imgSig.Image.Save(ms, ImageFormat.Jpeg);
                    sign = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(sign, 0, sign.Length);
                    cmd.Parameters.AddWithValue("@sign", sign);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sign", null);
                }

                if (imgSig2.Image != null)
                {
                    ms = new MemoryStream();
                    imgSig2.Image.Save(ms, ImageFormat.Jpeg);
                    sign2 = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(sign2, 0, sign2.Length);
                    cmd.Parameters.AddWithValue("@sign2", sign2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sign2", null);
                }

                if (imgSig3.Image != null)
                {
                    ms = new MemoryStream();
                    imgSig3.Image.Save(ms, ImageFormat.Jpeg);
                    sign3 = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(sign3, 0, sign3.Length);
                    cmd.Parameters.AddWithValue("@sign3", sign3);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sign3", null);
                }

                try
                {
                    

                    cmd.ExecuteNonQuery();
                    //sqltran.Commit();

                }
                catch { }

            }catch{}
        }
        public void photo_convert()
        {
            if (pictureimport.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureimport.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                cmd.Parameters.AddWithValue("@Personal_Image", photo_aray);
            }
            else
                cmd.Parameters.AddWithValue("@Personal_Image", null);
        }

        private void cmbCountry_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT Country_Name FROM Country order by Country_Name");
            cmbCountry.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
               this.cmbCountry.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void cmbCountry_Enter(object sender, EventArgs e)
        {
            if (cmbCountry.Text == "")
                cmbCountry.DroppedDown = true;
        }

        private void cmbCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbCountry.DroppedDown = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void gstPerCompanyMasterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnimpSig_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                //txtpath.Text = Imagepath;
                imgSig.ImageLocation = Imagepath;
            }
            catch { }
        }

        private void btnimpSig2_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                //txtpath.Text = Imagepath;
                imgSig2.ImageLocation = Imagepath;
            }
            catch { }
        }

        private void btnDelSig_Click(object sender, EventArgs e)
        {
            imgSig.Image = Properties.Resources.blank2;
            txtSign1.Text="";
        }

        private void btnDelSig2_Click(object sender, EventArgs e)
        {
            imgSig2.Image = Properties.Resources.blank2;
            txtSign2.Text = "";
        }

        private void SaveImage_Opening(object sender, CancelEventArgs e)
        {
            if (clsDataAccess.GetresultS("select download from CompanyLimiter") == "1")
            {

                if (btnSave.Text.ToLower() == "update")
                {
                    string fpath = "";
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    // Show the FolderBrowserDialog.  
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        fpath = folderDlg.SelectedPath;
                        Environment.SpecialFolder root = folderDlg.RootFolder;

                        try
                        {
                            pictureimport.Image.Save(fpath + "\\sig1.jpg");

                            MessageBox.Show("Image saved in " + fpath, "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { MessageBox.Show("No Image Present", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                }
            }
            else
            {
                MessageBox.Show("This feature is not available", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
