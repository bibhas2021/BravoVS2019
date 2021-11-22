using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class FrmLinkCompanywiseClient : Form //MstFrmDialog
    {
        int Company_id = 0, Client_id = 0, cWD_MOD = 0;
        string pf_code = "", Esi_Code = "", Ptax_Code = "", LIN="",Pan_Code = "", StReg_Code = "", typeRem = "", prefix = "", sufix = "", hidedocno = "", mtd = "";
        string stateName = "",statecode="";
        DataTable dt = new DataTable();
        public FrmLinkCompanywiseClient()
        {
            InitializeComponent();
        }
        bool ins_updt_chk = false;
        string demo_value;
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        string startPath = "", setting_type = "", oremarks = "";
        string SelectedACNo = "";
        DataTable dtBank = new DataTable();
        public void readFile()
        {
            string ODetails = "", termsconditions = "", onote = "";
            startPath = Application.StartupPath;

            string[] type_setting = System.IO.File.ReadAllLines(startPath + "\\type_settings.txt");

            foreach (string line in type_setting)
            {
                if (!line.Contains("*"))
                {
                    setting_type = line;
                }
            }

            txtRemarks.Text = "";
            termsconditions = System.IO.File.ReadAllText(startPath + "\\" + setting_type + "\\TermsConditions.txt");
            ODetails = System.IO.File.ReadAllText(startPath + "\\" + setting_type + "\\ODetails.txt");
            onote = System.IO.File.ReadAllText(startPath + "\\" + setting_type + "\\note.txt");
            Txt_TermsConditions.Text = termsconditions;
            txt_Odetails.Text = ODetails;
            txtNote.Text = onote;
        }
        public void Config_WD_MOD()   // View Desg wise MOD
        {
            int rw = 0, rw1 = 0; 
            dgvDesgMOD.Rows.Clear();


            DataTable desg_mod = clsDataAccess.RunQDTbl("Select SlNo as col_dgid,DesignationName as col_Mod_desg, 'MOD'as col_mod_mod, '0' as col_mod_other, '0' as col_mod_limit from tbl_Employee_DesignationMaster");

            if (desg_mod.Rows.Count > 0)
            {
                rw1 = 0; rw = 0;
                dgvDesgMOD.Rows.Clear();
                while (rw < desg_mod.Rows.Count)
                {
                    rw1 = dgvDesgMOD.Rows.Add();
                    dgvDesgMOD.Rows[rw].Cells["col_dgid"].Value = desg_mod.Rows[rw]["col_dgid"];
                    dgvDesgMOD.Rows[rw].Cells["col_Mod_desg"].Value = desg_mod.Rows[rw]["col_Mod_desg"];
                    dgvDesgMOD.Rows[rw].Cells["col_mod_mod"].Value = desg_mod.Rows[rw]["col_mod_mod"];
                    dgvDesgMOD.Rows[rw].Cells["col_mod_other"].Value = desg_mod.Rows[rw]["col_mod_other"];
                    dgvDesgMOD.Rows[rw].Cells["col_mod_limit"].Value = desg_mod.Rows[rw]["col_mod_limit"];
                    rw++;
                }
                dgvDesgMOD.AutoResizeColumns();

            }


            desg_mod = clsDataAccess.RunQDTbl("Select sid,desgid,mod,other,limit from tbl_Site_mod_desg where (sid='" + LblLocationID.Text + "')");
            if (desg_mod.Rows.Count > 0)
            {
                rw1 = 0;
                while (rw1 < desg_mod.Rows.Count)
                {
                    for (int ind = 0; ind < dgvDesgMOD.Rows.Count; ind++)
                    {
                        if (dgvDesgMOD.Rows[ind].Cells["col_dgid"].Value.ToString().Trim().ToLower() == desg_mod.Rows[rw1]["desgid"].ToString().Trim().ToLower())
                        {
                            dgvDesgMOD.Rows[ind].Cells["col_mod_mod"].Value = desg_mod.Rows[rw1]["mod"].ToString();
                            dgvDesgMOD.Rows[ind].Cells["col_mod_other"].Value = desg_mod.Rows[rw1]["other"].ToString();
                            dgvDesgMOD.Rows[ind].Cells["col_mod_limit"].Value = desg_mod.Rows[rw1]["limit"].ToString();

                        }

                    }
                    rw1++;
                }

            }

        }

        public void otherDetails()
        {

            if (lblCoid.Text != "")
            {
                dt = clsDataAccess.RunQDTbl("SELECT narration,remarks,note,others,termscondition,chkBank FROM tbl_BillNarr where ([coid]=" + lblCoid.Text + ") and ([clid]=" + lblClientID.Text + ") and ([locid]=" + LblLocationID.Text + ")");

                if (dt.Rows.Count > 0)
                {
                    txtDesc.Text = dt.Rows[0]["narration"].ToString();
                    txtRemarks.Text = dt.Rows[0]["remarks"].ToString();
                    txtNote.Text = dt.Rows[0]["note"].ToString();
                    txt_Odetails.Text = dt.Rows[0]["others"].ToString();
                    Txt_TermsConditions.Text = dt.Rows[0]["termscondition"].ToString();
                    

                    //dtBank = clsDataAccess.RunQDTbl("select top 1 bank,acno from Branch where ltrim(rtrim(bank))!='' and (gcode='" + Company_id + "') and (acno='" + dt.Rows[0]["acno"].ToString() + "')");
                    //if (dt.Rows.Count > 0)
                    //{
                    //    bnkDtl.Text = dt.Rows[0]["bank"].ToString();
                    //    SelectedACNo = dt.Rows[0]["acno"].ToString();
                       
                    //    bnkDtl.ReturnValue = dt.Rows[0]["acno"].ToString();
                    //}

                    if (dt.Rows[0]["chkBank"].ToString() == "1")
                    {
                        chkBank.Checked = true;
                    }
                    else
                    {
                        chkBank.Checked = false;
                    }
                }
                else
                {
                    txtDesc.Text = "BEING THE AMOUNT CHARGED FOR THE SUPPLY OF SERVICE " + Environment.NewLine + "PLACED AT YOUR DISPOSAL AT " + cmbLocation.Text.Trim();
                    //txtRemarks.Text = dt.Rows[0]["remarks"].ToString();
                    //txtNote.Text = dt.Rows[0]["note"].ToString();
                    //txt_Odetails.Text = dt.Rows[0]["others"].ToString();
                    //Txt_TermsConditions.Text = dt.Rows[0]["termscondition"].ToString();
                }

            }
            else
            {
                MessageBox.Show("Please select company first");

            }
        }

        private void FrmLinkCompanywiseClient_Load(object sender, EventArgs e)
        {
            //this.lblTitle.Text = "Link Company with Client Location";
            int pn, streg, mn, mod,cnt_lv=0;
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            lblDocStruct.Text=clsDataAccess.ReturnValue("select bill_doc_type from CompanyLimiter");
            cWD_MOD = 0;
            pnlDocNo.Visible = false;
            try
            {
                cWD_MOD = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select desgday from CompanyLimiter")));
            }
            catch
            {
                cWD_MOD = 0;
            }
            try
            {
                chkWO.Checked = false;
                if (Convert.ToInt32(clsDataAccess.GetresultS("select woff from CompanyLimiter")) == 1)
                {
                    chkWO.Visible = true;
                    chkWoPS.Visible = true;
                }
                else
                {
                    chkWO.Visible = false;
                    chkWoPS.Visible = false;
                }
            }
            catch { }
            try
            {
                if (clsDataAccess.GetresultS("select sal_nc from CompanyLimiter") == "1")
                {
                    chk_nonCompliance.Visible = true;
                }
                else
                {
                    chk_nonCompliance.Visible = false;
                }
            }
            catch{}
            
            if(lblDocStruct.Text=="3")
            {
                tabControl1.TabPages.Remove(tabPage6);

                pnlDocNo.Visible = true;

                dateTimePicker1.Value = DateTime.Now;

                DataTable dt = clsDataAccess.RunQDTbl("select type_desc as 'Description',desccode as 'Code' from typedoc where (ficode='1') and (gcode='1') and (t_entry='9') and (session ='" + lblSess.Text + "')");

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count == 1)
                    {
                        cmbdescription.Text = Convert.ToString(dt.Rows[0][0]);
                        cmbdescription.ReturnValue = Convert.ToString(dt.Rows[0][1]);
                        cmbdescription.PopUp(); 
                    }
                    else
                    {
                        cmbdescription.LookUpTable = dt;
                        cmbdescription.ReturnIndex = 1;
                        cmbdescription.PopUp(); 
                    }


                }
            }

            if (cWD_MOD == 0)
            {
                tabControl1.TabPages.Remove(tabWD_MOD_Desg);

            
            }
            else
            {
                Config_WD_MOD();
            }

            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                cmbcompany.Text = dta.Rows[0][0].ToString();

                Company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                cmbcompany.ReturnValue = Company_id.ToString();
                lblCoid.Text = Company_id.ToString();
                data_retrive_Company();
            }
            else if (dta.Rows.Count > 1)
            {
                cmbcompany.PopUp();
            }

            stateName = "";

            if (type_doc_check() == false)
            {
                lblMsg.Text = "Bill Number declared in Document Number";
                txtPref.Text = "";
                txtPref.Enabled = false;
            }
            else
            {
                txtPref.Text = "";
                txtPref.Enabled = true;
                lblMsg.Text = "";
            }

            try
            {
                if (System.DateTime.Now.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = System.DateTime.Now.Year + "-" + System.DateTime.Now.AddYears(1).Year; }
                    catch { }

                }
                else
                {
                    cmbYear.SelectedItem = System.DateTime.Now.AddYears(-1).Year + "-" + System.DateTime.Now.Year;

                }
            }
            catch
            { }

            gstTypeComboBox.SelectedIndex = 2;

            pn = Convert.ToInt32(clsDataAccess.GetresultI("Companywiseid_Relation", "Pan_Code"));
            streg = Convert.ToInt32(clsDataAccess.GetresultI("Companywiseid_Relation", "StReg_Code"));
            mn = Convert.ToInt32(clsDataAccess.GetresultI("Companywiseid_Relation", "M_inst"));
            string str = "";
            if (pn == 0 || streg == 0 || mn == 0)
            {
                str = "ALTER TABLE Companywiseid_Relation ADD ";
                if (pn == 0)
                {
                    str = str + "[Pan_Code] [varchar](50) NULL, ";
                }
                if (streg == 0)
                {
                    str = str + "[StReg_Code] [varchar](50) NULL, ";
                }
                if (mn == 0)
                {
                    str = str + "[M_inst] [varchar](5) NULL";
                }

                bool rs = clsDataAccess.RunNQwithStatus(str);
            }
            mod = Convert.ToInt32(clsDataAccess.GetresultI("Companywiseid_Relation", "MOD"));
            if (mod == 0)
            {
                str = "ALTER TABLE Companywiseid_Relation ADD MOD [varchar](50) NULL";
                bool rs = clsDataAccess.RunNQwithStatus(str);

                str = "update Companywiseid_Relation set MOD=0";
                rs = clsDataAccess.RunNQwithStatus(str);
            }
            //=======================
            txtPad.Text = "2";
            txtNumsep.Text = "1";
            txtPos.Text = "3";
            txtDoc.Text = "0";
            chkHide_DocNo.Checked = true;
            // txtPref.Focus();

            readFile();

            cmbSuffix.SelectedIndex = 1;
            TxtSuffix.Text = "";
            getShift();

            cnt_lv = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select lv from CompanyLimiter")));
            if (cnt_lv == 0)
            {
                txtLvRate.Visible = false;
                cmbLvAdj.Visible = false;
                label33.Visible = false;
                label34.Visible = false;
            }
            else
            {
                label33.Visible = true;
                label34.Visible = true;
                txtLvRate.Visible = true;
                cmbLvAdj.Visible = true;
            }


            if (clsDataAccess.GetresultS("select desgday from CompanyLimiter") == "1")
            {
                grpLv.Visible = true;
            }
            else
            {
                grpLv.Visible = false;
            }
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
           
            if (edpcom.CurrentLocation.Trim() != "")
            {

                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            }
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);
            lblCoid.Text = Company_id.ToString();
            data_retrive_Company();
        }

        private void comclient_DropDown(object sender, EventArgs e)
        {
             dt = clsDataAccess.RunQDTbl("select Location_Name,ClientName,location_id,COID from " +
        "(Select ltrim(rtrim(EL.Location_Name))Location_Name,EL.Location_ID,(SELECT Client_Name FROM tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName,"+
        "(SELECT isNUll(coid,1) FROM tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as COID from tbl_Emp_Location EL)x where ([COID]='" + Company_id + "')");
         //       "Select EL.Location_Name,EL.Location_ID,"+
         //"(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName "+
         //" from tbl_Emp_Location EL,Companywiseid_Relation cr where (cr.Location_ID=EL.Location_ID) and (cr.Company_ID='" + Company_id + "')");
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 2;
            }
        }

        private void comclient_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                Client_id = Convert.ToInt32(cmbLocation.ReturnValue);

            LblLocationID.Text = Client_id.ToString();
            data_retrive();
            clientname();

            otherDetails();

            Config_WD_MOD();
            if (dgView.Rows.Count > 1)
            {
                data_select(0);
            }
        }
        /*public bool Zone_DocNo()
        {
            {
                string docnumber = "";
                string[] dss = cmbdescription.Text.Split('/');
                string zone = clsDataAccess.ReturnValue("select zone from tbl_zone where zid=(select zid from tbl_Emp_Location where Location_ID='" + location_id + "')");
                string loc = cmbLocation.Text.Trim().Substring(0, 3);
                string locID = Convert.ToDouble(cmbLocation.ReturnValue.Trim()).ToString("00");
                string cli = cmbclintname.Text.Trim().Substring(0, 3);
                string cliID = Convert.ToDouble(Client_id).ToString("00");
                if (dss.Length > 0)
                {
                    try
                    {
                        if (dss[1].ToString().Trim().ToLower() == "z")
                        {
                            lblDesc.Text = dss[0].Trim() + "/" + zone.Substring(0, 1);
                        }
                        else if (dss[1].ToString().Trim().ToLower() == "zone")
                        {
                            lblDesc.Text = dss[0].Trim() + "/" + zone.Trim();
                        }
                        else if (dss[1].ToString().Trim().ToLower() == "loc")
                        {
                            lblDesc.Text = dss[0].Trim() + "/" + loc;
                        }
                        else if (dss[1].ToString().Trim().ToLower() == "client")
                        {
                            lblDesc.Text = dss[0].Trim() + "/" + cli;
                        }
                        else if (dss[1].ToString().Trim().ToLower() == "locid")
                        {
                            lblDesc.Text = dss[0].Trim() + "/" + locID;
                        }
                        else if (dss[1].ToString().Trim().ToLower() == "clientid")
                        {
                            lblDesc.Text = dss[0].Trim() + "/" + cliID;
                        }
                    }
                    catch { lblDesc.Text = dss[0].Trim(); }
                    try
                    {
                        if (dss[2].ToString().Trim().ToLower() == "z")
                        {
                            lblDesc.Text = lblDesc.Text + "/" + zone.Substring(0, 1);
                        }
                        else if (dss[2].ToString().Trim().ToLower() == "zone")
                        {
                            lblDesc.Text = lblDesc.Text + "/" + zone.Trim();
                        }
                        else if (dss[2].ToString().Trim().ToLower() == "loc")
                        {
                            lblDesc.Text = lblDesc.Text + "/" + loc;
                        }
                        else if (dss[2].ToString().Trim().ToLower() == "client")
                        {
                            lblDesc.Text = lblDesc.Text + "/" + cli;
                        }
                        else if (dss[2].ToString().Trim().ToLower() == "locid")
                        {
                            lblDesc.Text = lblDesc.Text + "/" + locID;
                        }
                        else if (dss[2].ToString().Trim().ToLower() == "clientid")
                        {
                            lblDesc.Text = lblDesc.Text + "/" + cliID;
                        }
                    }
                    catch { lblDesc.Text = lblDesc.Text; }



                    DataTable dtDes = clsDataAccess.RunQDTbl("SELECT Descode, coid, locid, Type_Desc, Suffix, AccYr, DocNo FROM Docgen_Zone where (Type_Desc='" + lblDesc.Text.Trim() + "') and (accyr='" + cmbYear.Text + "') and (coid='" + Company_id + "') and (locid='" + location_id + "')");


                    DataTable dt24 = clsDataAccess.RunQDTbl("select * from docnumber where (ltrim(rtrim(ficode))='" + edpcom.CurrentFicode.Trim() + "') and (ltrim(rtrim(gcode))='" + edpcom.PCURRENT_GCODE.Trim() + "') and (ltrim(rtrim(desccode))='" + cmbdescription.ReturnValue.ToString().Trim() + "') and (ltrim(rtrim(t_entry))='9') and (ltrim(rtrim(session))='" + cmbYear.Text + "')");


                    string PREPOS = dt24.Rows[0][7].ToString().Trim();
                    string SUFPOS = dt24.Rows[0][8].ToString().Trim();
                    string padding = dt24.Rows[0][9].ToString().Trim();
                    string doc_pos = dt24.Rows[0][10].ToString().Trim();
                    string no_sep = dt24.Rows[0][11].ToString().Trim();
                    string prefix = lblDesc.Text.Trim();//dt24.Rows[0][12].ToString().Trim();
                    string suffix = dt24.Rows[0][13].ToString().Trim();//mydr.GetString(13).Trim();
                    string Descode = dt24.Rows[0]["DESCCODE"].ToString().Trim();
                    dt24.Clear();
                    if (suffix == "Season" || suffix == "Session" || suffix == "AcYr")
                    {
                        suffix = cmbYear.Text;
                    }
                    else if (suffix == "MonthYear")
                    {
                        suffix = dateTimePicker1.Value.ToString("MMM") + "/" + dateTimePicker1.Value.ToString("yy");
                    }

                    if (dtDes.Rows.Count > 0)
                    {
                        docnumber = dtDes.Rows[0]["DocNo"].ToString(); //dt24.Rows[0][0].ToString();
                    }
                    else
                    {
                        docnumber = "0";

                        clsDataAccess.RunQry("INSERT INTO Docgen_Zone(Descode, coid, locid, Type_Desc, Suffix, AccYr, DocNo) values ('" + Descode + "','" + Company_id + "','" + location_id + "','" + prefix + "','" + suffix + "','" + cmbYear.Text + "','" + docnumber + "')");
                    }
                    string sep = "", num = ""; int i = 0;
                    Int64 newnum = 0;
                    for (i = 1; i <= Convert.ToInt16(no_sep); i++)
                        sep = sep + "/";
                    newnum = Convert.ToInt64(docnumber) + 1;
                    string form = "";
                    for (i = 1; i <= (Convert.ToInt16(padding) - Convert.ToString(newnum).Length); i++) form = form + "0";
                    num = form + Convert.ToString(newnum);
                    switch (PREPOS.Trim())
                    {
                        case "1":
                            {
                                if (SUFPOS.Trim() == "3")
                                {
                                    if (padding != "0")
                                    {
                                        docnumber = prefix.Trim() + sep + num + sep + suffix;
                                    }
                                    else
                                    {
                                        docnumber = prefix.Trim() + sep + suffix;
                                    }
                                }
                                else if (SUFPOS.Trim() == "2")
                                {
                                    if (padding != "0")
                                    {
                                        docnumber = prefix + sep + suffix + sep + num;

                                    }
                                    else
                                    {
                                        docnumber = prefix + sep + suffix;
                                    }
                                }
                                break;
                            }
                        case "2":
                            {
                                if (SUFPOS.Trim() == "1")
                                {
                                    if (padding != "0")
                                    {
                                        docnumber = suffix + sep + prefix + sep + num;
                                    }
                                    else
                                    {
                                        docnumber = suffix + sep + prefix;
                                    }
                                }
                                else if (SUFPOS.Trim() == "3")
                                {
                                    if (padding != "0")
                                    {
                                        docnumber = num + sep + prefix + sep + suffix;

                                    }
                                    else
                                    {
                                        docnumber = prefix + sep + suffix;
                                    }
                                }
                                break;
                            }
                        case "3":
                            {
                                if (SUFPOS.Trim() == "1")
                                {

                                    if (padding != "0")
                                    {
                                        docnumber = suffix + sep + num + sep + prefix;
                                    }
                                    else
                                    {
                                        docnumber = suffix + sep + prefix;
                                    }


                                }
                                else if (SUFPOS.Trim() == "2")
                                {

                                    if (padding != "0")
                                    {
                                        docnumber = num + sep + suffix + sep + prefix;
                                    }
                                    else
                                    {
                                        docnumber = suffix + sep + prefix;
                                    }
                                }
                                break;
                            }
                        default:
                            {
                                if (padding != "0")
                                {
                                    docnumber = prefix + sep + num + sep + suffix;
                                }
                                else
                                {
                                    docnumber = prefix + sep + suffix;
                                }
                                break;
                            }
                    }

                    lblbillno.Text = Convert.ToString(newnum);


                    txtVoucherChallan.Text = docnumber;



                    //                    txtVoucherChallan.Text = GetDocNumber(descode, "9", cmbYear.Text);
                }

            }
        }*/
        public void data_select(int e)
        {
            try
            {
                if (Company_id != 0)
                {
                    nudDueDateDats.Value = Convert.ToInt32(dgView.Rows[e].Cells["DueDateDays"].Value);
                    lblCompanyWiseID.Text = Convert.ToString(dgView.Rows[e].Cells["ID"].Value);
                    cmbPTaxCode.Text = Convert.ToString(dgView.Rows[e].Cells["Ptax_Code"].Value);
                    cmbPfcode.Text = Convert.ToString(dgView.Rows[e].Cells["PF_Code"].Value);
                    cmbEsicode.Text = Convert.ToString(dgView.Rows[e].Cells["Esi_Code"].Value);
                    if (cmbLocation.Text == "" || cmbLocation.Text != Convert.ToString(dgView.Rows[e].Cells["Location_Name"].Value))
                    {
                        Client_id = Convert.ToInt32(dgView.Rows[e].Cells["Location_ID"].Value);
                        LblLocationID.Text = Client_id.ToString();
                        cmbLocation.Text = Convert.ToString(dgView.Rows[e].Cells["Location_Name"].Value);
                        clientname();
                        Config_WD_MOD();



                        if (lblDocStruct.Text == "3")
                        {
                            //tabControl1.TabPages.Remove(tabPage6);

                            pnlDocNo.Visible = true;
                        }
                        else
                        {
                            pnlDocNo.Visible = false;
                        }

                    }
                    txtPan.Text = Convert.ToString(dgView.Rows[e].Cells["Pan_Code"].Value);
                    txtLIN.Text = dgView.Rows[e].Cells["LIN"].Value.ToString().Trim();
                    txtSTRegNo.Text = Convert.ToString(dgView.Rows[e].Cells["StReg_Code"].Value);
                    if (Convert.ToString(dgView.Rows[e].Cells["M_inst"].Value) == "T")
                    { chkMother.Checked = true; }
                    else { chkMother.Checked = false; }

                    string modVal = dgView.Rows[e].Cells["MOD"].Value.ToString().ToUpper();
                    if (modVal == "MONTHOFDAYS")
                    {
                        cmbMOD.SelectedIndex = 0;
                        txtDays.Text = "0";
                        cmbMOD.Text = "MONTHOFDAYS";
                        // txtDays.Visible = false;
                    }
                    else if (modVal == "MOD-SUNDAYS")
                    {
                        cmbMOD.SelectedIndex = 2;
                        txtDays.Text = "0";
                        cmbMOD.Text = "MOD-SUNDAYS";
                        // txtDays.Visible = false;
                    }
                    else if (modVal.Contains("RANGE-SUNDAYS"))
                    {
                        cmbMOD.SelectedIndex = 4;
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                        txtDays.Text = strFromTo[0];
                        tbTo.Text = strFromTo[1];
                    }
                    else if (modVal.Contains("MOD-WO"))
                    {
                        cmbMOD.SelectedIndex = 5;
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('[');
                        txtDays.Text = strFromTo[0];
                        //tbTo.Text = strFromTo[1];
                    }
                    else if (modVal.Contains("RANGE"))
                    {
                        cmbMOD.SelectedIndex = 3;
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                        txtDays.Text = strFromTo[0];
                        tbTo.Text = strFromTo[1];
                    }
                    else if (modVal == "MOD-EWO")
                    {
                        cmbMOD.SelectedIndex = 6;
                        txtDays.Text = "0";
                        cmbMOD.Text = "MOD-EWO";
                        // txtDays.Visible = false;
                    }
                    else
                    {
                        cmbMOD.SelectedIndex = 1;
                        txtDays.Text = dgView.Rows[e].Cells["MOD"].Value.ToString();
                        // txtDays.Visible = true;
                    }

                    txtRemType.Text = dgView.Rows[e].Cells["typeRem"].Value.ToString();
                    txtPref.Text = dgView.Rows[e].Cells["prefix"].Value.ToString();
                    TxtSuffix.Text = dgView.Rows[e].Cells["sufix"].Value.ToString();
                    if (dgView.Rows[e].Cells["hidedocno"].Value.ToString() == "1") { chkHide_DocNo.Checked = true; txtPad.Text = "0"; } else { chkHide_DocNo.Checked = false; txtPad.Text = dgView.Rows[e].Cells["padding"].Value.ToString(); };

                    if (dgView.Rows[e].Cells["isST"].Value.ToString().Trim() == "1")
                    {
                        chkTax.Checked = true;

                        if (dgView.Rows[e].Cells["isSTC"].Value.ToString().Trim() == "1")
                        { rdbCharged.Checked = true; }
                        else { rdbNotCharged.Checked = true; }

                    }
                    else
                    {
                        chkTax.Checked = false;
                        rdbNotCharged.Checked = true;
                    }

                    //mode_cwd=0, pf_limit=15000, esi_limit=21000,pf_base=0, esi_base=1

                    if (dgView.Rows[e].Cells["mode_cwd"].Value.ToString().Trim() == "1") { rdbLv_RD.Checked = true; }
                    else if (dgView.Rows[e].Cells["mode_cwd"].Value.ToString().Trim() == "2") { rdbLv_RU.Checked = true; }
                    else if (dgView.Rows[e].Cells["mode_cwd"].Value.ToString().Trim() == "3") { rdbLv_RO.Checked = true; }
                    else { rdbLv_normal.Checked = true; }
                    try
                    {
                        txtPF_limit.Text = dgView.Rows[e].Cells["pf_limit"].Value.ToString();
                    }
                    catch { }
                    try
                    {
                        txtEsi_Limit.Text = dgView.Rows[e].Cells["esi_limit"].Value.ToString();
                    }
                    catch { }

                    try
                    {
                        DataTable getGSTApplicable = clsDataAccess.RunQDTbl("select GSTTYPE from Companywiseid_Relation where Company_ID=" + Company_id + " and Location_ID =" + Client_id);
                        string gstApplicable = "";
                        try
                        {
                            gstApplicable = getGSTApplicable.Rows[0][0].ToString();
                        }
                        catch
                        {
                            gstApplicable = "";
                        }
                        if (gstApplicable.ToUpper() == "LOCAL")
                        {
                            gstTypeComboBox.SelectedIndex = 0;
                        }
                        else if (gstApplicable.ToUpper() == "INTERSTATE")
                        {
                            gstTypeComboBox.SelectedIndex = 1;
                        }
                        else if (gstApplicable.ToUpper() == "REVERSE CHARGES")
                        {
                            gstTypeComboBox.SelectedIndex = 4;
                        }
                        else if (gstApplicable.ToUpper() == "EXEMPTED")
                        {
                            gstTypeComboBox.SelectedIndex = 3;
                        }
                        else
                        {
                            gstTypeComboBox.SelectedIndex = 2;
                        }
                    }
                    catch { }


                    if (dgView.Rows[e].Cells["isSC"].Value.ToString().Trim() == "1") { chkSC.Checked = true; } else { chkSC.Checked = false; }
                    txtDoc.Text = dgView.Rows[e].Cells["lstDocNo"].Value.ToString();

                    if (dgView.Rows[e].Cells["freeze"].Value.ToString().Trim() == "1") { chkFreeze.Checked = true; } else { chkFreeze.Checked = false; }

                    txtAddress.Text = dgView.Rows[e].Cells["blAdd"].Value.ToString();
                    txtContact.Text = dgView.Rows[e].Cells["blPh"].Value.ToString();
                    txtFax.Text = dgView.Rows[e].Cells["blFax"].Value.ToString();
                    txtEmail.Text = dgView.Rows[e].Cells["blEmail"].Value.ToString();
                    txtState.Text = dgView.Rows[e].Cells["blState"].Value.ToString();
                    try
                    {
                        txtState.ReturnValue = clsDataAccess.ReturnValue("SELECT [STATE_CODE] FROM StateMaster where ({ fn LCASE([State_Name])}='" + dgView.Rows[e].Cells["blState"].Value.ToString().Trim().ToLower() + "')");
                    }
                    catch { txtState.ReturnValue = "0"; }
                    cmbBankDetail.Text = clsDataAccess.GetresultS("select (bank + ' - AcNo : '+acno + ' - IFSC : '+ifsc) as bank from Branch where ltrim(rtrim(bank))!='' and (gcode='" + Company_id + "') and (acno='" + dgView.Rows[e].Cells["blAcNo"].Value.ToString().Trim() + "')"); 
                    //dgView.Rows[e].Cells["blAcNo"].Value.ToString();

                    //[hrs_per_wd]=8,[hrs_per_ot]=4,[apply_hrs_wd]=0,[apply_hrs_wd]=
                    try
                    {
                        txt_sal_wd_Hrs.Text = dgView.Rows[e].Cells["hrs_per_wd"].Value.ToString();
                    }
                    catch
                    {
                        txt_sal_wd_Hrs.Text = "8";
                    }

                    try
                    {
                        txt_sal_ED_Hrs.Text = dgView.Rows[e].Cells["hrs_per_ed"].Value.ToString();
                    }
                    catch
                    {
                        txt_sal_ED_Hrs.Text = "4";
                    }

                    try
                    {
                        txt_sal_ot_Hrs.Text = dgView.Rows[e].Cells["hrs_per_ot"].Value.ToString();
                    }
                    catch
                    {
                        txt_sal_ot_Hrs.Text = "4";
                    }
                    try
                    {
                        if (dgView.Rows[e].Cells["apply_hrs_wd"].Value.ToString() == "1") { chk_sal_wd.Checked = true; } else { chk_sal_wd.Checked = false; }
                    }
                    catch
                    {
                        chk_sal_wd.Checked = false;
                    }


                    //non-complaince
                    try
                    {
                        if (dgView.Rows[e].Cells["nocpl"].Value.ToString() == "1")
                        {
                            chk_nonCompliance.Checked = true;
                        }
                        else
                        {
                            chk_nonCompliance.Checked = false;
                        }
                    }
                    catch { chk_nonCompliance.Checked = false; }

                    //remit_pfesi


                    try
                    {
                        if (dgView.Rows[e].Cells["remit_pfesi"].Value.ToString() == "1")
                        {
                            chk_pf_esi_remit.Checked = true;
                        }
                        else
                        {
                            chk_pf_esi_remit.Checked = false;
                        }
                    }
                    catch { chk_pf_esi_remit.Checked = false; }

                    try
                    {
                        if (dgView.Rows[e].Cells["apply_hrs_ed"].Value.ToString() == "1") { chk_sal_ED.Checked = true; } else { chk_sal_ED.Checked = false; }
                    }
                    catch
                    {
                        chk_sal_ED.Checked = false;
                    }

                    try
                    {
                        if (dgView.Rows[e].Cells["apply_hrs_ot"].Value.ToString() == "1") { chk_sal_ot.Checked = true; } else { chk_sal_ot.Checked = false; }
                    }
                    catch
                    {
                        chk_sal_ot.Checked = false;

                    }

                    try
                    {
                        TxtSCPer.Text = dgView.Rows[e].Cells["scPer"].Value.ToString();
                    }
                    catch { TxtSCPer.Text = "0"; }
                    try
                    {
                        txtLvRate.Text = dgView.Rows[e].Cells["Lv_Rate"].Value.ToString();
                    }
                    catch
                    {
                        txtLvRate.Text = "0";
                    }

                    try
                    {
                        cmbLvAdj.SelectedIndex = Convert.ToInt32(dgView.Rows[e].Cells["Lv_adj"].Value);
                    }
                    catch { cmbLvAdj.SelectedIndex = 0; }

                    DataTable dno = clsDataAccess.RunQDTbl("Select PREPOS,SUFPOS,padding,doc_pos FROM docnumber where (locid='" + LblLocationID.Text + "') and (clid='" + lblClientID.Text + "') and (coid='" + lblCoid.Text + "')");

                    if (dgView.Rows[e].Cells["isAdd"].Value.ToString().Trim() == "1")
                    { chkIsAdd.Checked = true; }
                    else if (dgView.Rows[e].Cells["isAdd"].Value.ToString().Trim() == "2")
                    { chkSupplyAdd.Checked = true; }
                    else { chkIsAdd.Checked = false; }

                    try
                    {
                        nudPref.Value = Convert.ToInt32(dno.Rows[0]["PREPOS"]);
                    }
                    catch
                    {
                        nudPref.Value = 1;
                    }

                    try
                    {
                        nudSuf.Value = Convert.ToInt32(dno.Rows[0]["SUFPOS"]);
                    }
                    catch
                    {
                        nudSuf.Value = 2;
                    }
                    try
                    {
                        txtPos.Text = dno.Rows[0]["doc_pos"].ToString();
                    }
                    catch
                    {
                        txtPos.Text = "3";
                    }

                    clientname();
                    otherDetails();
                    shift_display(Convert.ToInt32(lblCoid.Text), Convert.ToInt32(LblLocationID.Text));
                    btnsave.Visible = true;
                }
            }
            catch { }

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPfcode_DropDown(object sender, EventArgs e)
        {
            dt = clsDataAccess.RunQDTbl("Select PF_Code,Company_ID from PFCodeMaster where  (Company_ID='" + Company_id + "')");
            if (dt.Rows.Count > 0)
            {
                cmbPfcode.LookUpTable = dt;
                cmbPfcode.ReturnIndex = 0;
            }
        }

        private void cmbPfcode_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNothing(cmbPfcode.ReturnValue) == false)
                pf_code = cmbPfcode.ReturnValue;
        }
        //---------------------------------SAVE SECTION---------------------------------------------
        private void btnBillDocSave_Click()
        {
            mtd = "A";
            try
            {

                //type_doc_insert();

                //    docnumber_insert();
                //    docgen();




            }
            catch
            {

            }
        }


        public bool type_doc_check()
        {
            string s=clsDataAccess.ReturnValue("select bill_doc_type from CompanyLimiter");
            bool doc_chk = false;
            //if (Convert.ToInt32(clsDataAccess.GetresultS("Select count(*) from TypeDoc where (GCode='1') and (FICODE='1') and (T_ENTRY='9') and (coid='0') and (locid='0') and (clid='0')")) > 0)
            //{
            //    doc_chk = false;
            //}
            //else
            //{
            //    doc_chk = true;
            //}

            if (s == "3" || s == "2")
            {
                doc_chk = true;
            }
            else
            {
                doc_chk = false;
            }
            return doc_chk;
        }


        public void type_doc_insert()
        {
            string s;
            ins_updt_chk = false;
            if (clsDataAccess.GetresultS("Select count(*) from TypeDoc where (GCode='0') and (FICODE='0') and (T_ENTRY='9') and (coid='" + lblCoid.Text + "') and (locid='" + LblLocationID.Text + "') and (clid='" + lblClientID.Text + "')") == "0")
            {
                ins_updt_chk = false;
            }
            else
            {
                ins_updt_chk = true;
            }
            //if (ins_updt_chk)
            //{


            //}
            //else
            //{


            //}




            if (ins_updt_chk == true)
            {
                int temp_dcode = Convert.ToInt32(clsDataAccess.GetresultS("Select Desccode from TypeDoc where (GCode='0') and (FICODE='0') and (T_ENTRY='9') and (coid='" + lblCoid.Text + "') and (locid='" + LblLocationID.Text + "') and (clid='" + lblClientID.Text + "')"));
                s = "update TypeDoc set Type_Desc='" + txtPref.Text + "',Specific_Acc='0',METHOD='A',Effect_Amt='0',Req_Acc='0' ";
                s += " where (GCode='0') and (FICODE='0') and (T_ENTRY='9') and (locid='" + LblLocationID.Text + "') and (clid='" + lblClientID.Text + "') and (Session='')" + Environment.NewLine +

                    "update DOCGEN set VOUCHERNO='" + txtDoc.Text + "' where (FICODE='0') and (Gcode='0') and (T_ENTRY='9') and (DESCCODE='" + temp_dcode + "') and (Session='')" + Environment.NewLine +

                    "update docnumber set TYPE_DESC='" + txtPref.Text.Trim() + "',PREPOS='" + nudPref.Value + "',SUFPOS='" + nudSuf.Value +
                    "',padding='" + txtPad.Text.Trim() + "',doc_pos='" + txtPos.Text.Trim() + "',no_sep='" + txtNumsep.Text.Trim() +
                    "',prefix='" + txtPref.Text.Trim() + "',suffix='" + TxtSuffix.Text + "',locid='" + LblLocationID.Text +
                    "',clid='" + lblClientID.Text + "',coid='" + lblCoid.Text + "' where (FICODE='0') and (Gcode='0') and (T_ENTRY='9') and (TYPE_NAME='Sales') and (DESCCODE=" + temp_dcode + ") and (Session='')";
                clsDataAccess.RunNQwithStatus(s);

            }
            else
            {
                int temp_dcode = desc_code();
                string s1 = "";
                s = "insert into TypeDoc(FICode,GCODE,T_ENTRY,Desccode,Type_Desc,Specific_Acc,METHOD,Effect_Amt,Req_Acc," +
               "User_Code,Bill_Type,Bill_Format,Session, locid, clid,coid) values('0','0','9'," + temp_dcode + ",'" + txtPref.Text.Trim() + "','0','A','0','0','" + edpcom.PCURRENT_USER + "','0','','', '" + LblLocationID.Text + "', '" + lblClientID.Text + "','" + lblCoid.Text + "')" + Environment.NewLine +

               "INSERT INTO docnumber(FICode,GCODE,T_ENTRY,TYPE_NAME,DESCCODE,TYPE_DESC,METHOD,PREPOS,SUFPOS,padding,doc_pos," +
               "no_sep,prefix,suffix,User_Code,Session,locid,clid,coid)VALUES ('0','0','9','Sales'," + temp_dcode + ",'" + txtPref.Text.Trim() + "','A','" +
               nudPref.Value + "','" + nudSuf.Value + "','" + txtPad.Text.Trim() + "','" + txtPos.Text.Trim() + "','" + txtNumsep.Text.Trim() + "','" + txtPref.Text.Trim() +
               "','" + TxtSuffix.Text + "','" + edpcom.PCURRENT_USER + "','','" + LblLocationID.Text + "','" + lblClientID.Text + "','" + lblCoid.Text + "')" + Environment.NewLine +

               "insert into DOCGEN(FICode,GCODE,T_ENTRY,DESCCODE,VOUCHERNO,User_Code,Session) values('0','0','9','" + temp_dcode + "','" + txtDoc.Text + "','" + edpcom.PCURRENT_USER + "','')";

                clsDataAccess.RunNQwithStatus(s);

            }
        }

        //------------------------------------------------------------------------------------------
        public int desc_code()
        {
            int rtrn_val = 0;
            string s = "select max(Desccode) from TypeDoc where (GCode='0') and (FICODE='0') and (T_ENTRY='9')";// and Type_Desc='" + txtDesc.Text + "'";
            dt = clsDataAccess.RunQDTbl(s);

            if (Information.IsDBNull(dt.Rows[0][0]) == false)
            {
                rtrn_val = Convert.ToInt32(dt.Rows[0][0]);
                rtrn_val += 1;
            }
            else
            {
                rtrn_val += 1;
            }
            return rtrn_val;
        }
        //------------------------------------------------------------------------------------------
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtDoc.Text == "")
            {
                txtDoc.Text = "0";
            }
            if (txtPad.Text == "")
            {
                txtPad.Text = "0";
            }
            if (Validation())
            {

                if (lblDocStruct.Text == "3")
                {
                    //tabControl1.TabPages.Remove(tabPage6);

                    pnlDocNo.Visible = true;


                    gen_docno();
                }
                else
                {
                    pnlDocNo.Visible = false;
                }

                SaveData();

               
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed to submit.");
            }

            /*if (chkIsAdd.Checked)
            {
                if (txtState.Text != "")
                    SaveData();
                else
                {
                    ERPMessageBox.ERPMessage.Show("Select State.");
                    tabControl1.SelectedIndex = 2;
                    txtState.Focus();
                }
            }
            else
                SaveData();*/

        }

        private Boolean Validation()
        {
            Boolean Flag = true;

            if (cmbMOD.SelectedIndex == 3 || cmbMOD.SelectedIndex == 4)
            {
                if (!Information.IsNumeric(txtDays.Text))
                {
                    Flag = false;
                    EDPMessageBox.EDPMessage.Show("From date is either empty or non-numeric.");
                    tabControl1.SelectedIndex = 0;
                    txtDays.Focus();
                }
                if (Flag && !Information.IsNumeric(tbTo.Text))
                {
                    Flag = false;
                    EDPMessageBox.EDPMessage.Show("To date is either empty or non-numeric.");
                    tabControl1.SelectedIndex = 0;
                    tbTo.Focus();
                }
            }
            if (Flag && cmbMOD.SelectedIndex == 1)
            {
                if (!Information.IsNumeric(txtDays.Text))
                {
                    Flag = false;
                    EDPMessageBox.EDPMessage.Show("No of Days is either empty or non-numeric");
                    tabControl1.SelectedIndex = 0;
                    txtDays.Focus();
                }
            }
            if (Flag && !Information.IsNumeric(txtDoc.Text))
            {
                Flag = false;
                EDPMessageBox.EDPMessage.Show("Last Document no. is either empty or non-numeric");
                tabControl1.SelectedIndex = 0;
                txtDoc.Focus();
            }
            if (Flag && !Information.IsNumeric(txtPad.Text))
            {
                Flag = false;
                EDPMessageBox.EDPMessage.Show("Padding no. is either empty or non-numeric");
                tabControl1.SelectedIndex = 0;
                txtPad.Focus();
            }
            if (Flag && chkIsAdd.Checked)
            {
                if (txtState.Text.Trim() == "")
                {
                    Flag = false;
                    EDPMessageBox.EDPMessage.Show("State is not selected");
                    tabControl1.SelectedIndex = 2;
                    txtState.Focus();
                }
            }

            return Flag;
        }


        private void Config_WD()  // Insert desg wise mod
        {

            try
            {
                bool m = false;
                string dgid = "", Mod_desg = "", mod_mod = "", mod_other = "",mod_limit="", qry_inst = "";
                clsDataAccess.RunQry("delete from tbl_Site_mod_desg where (sid='" + LblLocationID.Text + "')");
                for (int ind = 0; ind < dgvDesgMOD.Rows.Count; ind++)
                {

                    dgid = dgvDesgMOD.Rows[ind].Cells["col_dgid"].Value.ToString().Trim();
                    Mod_desg = dgvDesgMOD.Rows[ind].Cells["col_Mod_desg"].Value.ToString().Trim();
                    mod_mod = dgvDesgMOD.Rows[ind].Cells["col_mod_mod"].Value.ToString().Trim();
                    mod_other = dgvDesgMOD.Rows[ind].Cells["col_mod_other"].Value.ToString().Trim();
                    mod_limit = dgvDesgMOD.Rows[ind].Cells["col_mod_limit"].Value.ToString().Trim();
                    if (qry_inst == "")
                    {
                        qry_inst = "insert into tbl_Site_mod_desg (sid,desgid,mod,other,limit) values ('" + LblLocationID.Text + "','" + dgid + "','" + mod_mod + "','" + mod_other + "','" + mod_limit + "')";
                    }
                    else
                    {
                        qry_inst = qry_inst + Environment.NewLine + "insert into tbl_Site_mod_desg (sid,desgid,mod,other,limit) values ('" + LblLocationID.Text + "','" + dgid + "','" + mod_mod + "','" + mod_other + "','" + mod_limit + "')";

                    }

                }

                m = clsDataAccess.RunQry(qry_inst);


            }
            catch { }



        }


        private void SaveData()
        {
            DataTable dtt = clsDataAccess.RunQDTbl("SELECT * FROM Companywiseid_Relation where (Location_ID ='" + Client_id + "')");

            int Max_ID = 0, lstDocNo = 0, pad = 0, chkBnk = 0;
            string mo = "F";
            string mod = "0", scPer = "0",Sc_Rate="0", blState = "", blAdd = "", blPh = "", blFax = "", blEmail = "", blBankDetail = "", hrs_per_wd = "8", hrs_per_ot = "4", hrs_per_ed = "4", apply_hrs_wd = "0", apply_hrs_ed = "0", apply_hrs_ot = "0", Lv_Rate = "0", lv_adj = "0";//mode_cwd="0", pf_limit="15000", esi_limit="21000",pf_base="0", esi_base="1";
            Boolean boolStatus = false;
            int chk_SC = 0, chk_ST = 0, chk_stc = 0, freeze = 0, isAdd = 0, remit_pfesi=0,nocpl=0,OCQ=0;
            double mode_cwd = 0, pf_limit = 15000, esi_limit = 21000, pf_base = 0, esi_base = 1, loc_initial = 0, PsWO=0;
            Pan_Code = Convert.ToString(txtPan.Text.Trim());
            LIN = txtLIN.Text.Trim();
            StReg_Code = Convert.ToString(txtSTRegNo.Text.Trim());

            lstDocNo = Convert.ToInt32(txtDoc.Text);
            if (chkIsAdd.Checked == true)
            {
                isAdd = 1;
            }
            else if (chkSupplyAdd.Checked == true)
            {
                isAdd = 2;
            }
            else
            {
                isAdd = 0;
            }

            if (chkWO.Checked == true)
            {
                loc_initial = 1;
            }

            if (chkWoPS.Checked == true)
            {
                PsWO = 1;
            }

            if (rdb_oc_attendence.Checked == true)
            {
                OCQ = 1;
            }
            else
            {
                OCQ = 0;
            }

            try
            {
                esi_limit =Convert.ToDouble(txtEsi_Limit.Text);
            }
            catch { esi_limit = 21000; }

            try
            {
             pf_limit= Convert.ToDouble(txtPF_limit.Text);
            }
            catch { pf_limit = 15000; }

            if (rdbLv_RD.Checked == true)
            {
                mode_cwd = 1;
            }
            else if (rdbLv_RU.Checked == true)
            {
                mode_cwd = 2;
            }
            else if (rdbLv_RO.Checked == true)
            {
                mode_cwd = 3;
            }
            else
            {
                mode_cwd = 0;
            }


            if (chkMother.Checked == true)
            { mo = "T"; }
            else { mo = "F"; }
            if (cmbMOD.SelectedIndex == 0)
            {
                mod = "MonthOfDays";//cmbMOD.Text;
            }
            else if (cmbMOD.SelectedIndex == 3 || cmbMOD.SelectedIndex == 4)
            {
                mod = cmbMOD.Text + "[" + txtDays.Text + "-" + tbTo + "]";
            }
            else if (cmbMOD.SelectedIndex == 2 || cmbMOD.SelectedIndex == 6)
            {
                mod = cmbMOD.Text;
            }
            else if (cmbMOD.SelectedIndex == 5)
            {
                mod = cmbMOD.Text + "[" + txtDays.Text + "]";//cmbMOD.Text;
            }
            else
            {
                mod = txtDays.Text;
            }
            if (chkBank.Checked == true)
            {
                chkBnk = 1;
            }
            else
            {
                chkBnk = 0;
            }


            typeRem = txtRemType.Text.Trim();
            prefix = txtPref.Text.Trim();
            sufix = TxtSuffix.Text.ToString();
            if (SelectedACNo.Trim() == "")
                SelectedACNo = cmbBankDetail.ReturnValue.Trim();
            blBankDetail = SelectedACNo;
            blAdd = txtAddress.Text.Trim();
            blPh = txtContact.Text.Trim();
            blFax = txtFax.Text.Trim();
            blEmail = txtEmail.Text.Trim();
            blState = txtState.Text;
            statecode = txtState.ReturnValue;
            stateName = txtState.Text;

            if (chkHide_DocNo.Checked == true)
            {
                hidedocno = "1";
                pad = 0;
            }
            else
            {
                hidedocno = "0";
                pad = Convert.ToInt32(txtPad.Text);
            }

            if (chkFreeze.Checked == true)
            {
                freeze = 1;
            }
            else
            {
                freeze = 0;
            }
            if (chkSC.Checked == true)
            {

                chk_SC = 1;

            }
            else
            {
                chk_SC = 0;

            }

            scPer = TxtSCPer.Text;
            hrs_per_wd = txt_sal_wd_Hrs.Text.Trim();
            hrs_per_ot = txt_sal_ot_Hrs.Text.Trim();
            hrs_per_ed = txt_sal_ED_Hrs.Text.Trim();

            if (chk_sal_wd.Checked == true)
            { apply_hrs_wd = "1"; }
            else { apply_hrs_wd = "0"; }

            if (chk_sal_ot.Checked == true)
            { apply_hrs_ot = "1"; }
            else
            { apply_hrs_ot = "0"; }

            if (chk_sal_ED.Checked == true)
            { apply_hrs_ed = "1"; }
            else
            { apply_hrs_ed = "0"; }

            if (chk_pf_esi_remit.Checked == true)
                remit_pfesi = 1;
            else
                remit_pfesi = 0;


            if (chk_nonCompliance.Checked == true)
            {
                nocpl = 1;
                string nc_qry = "update tbl_Employee_Assign_SalStructure set chkHide=2,NCompliance=1 where (Location_id=" + LblLocationID.Text + ") and (p_type='E') and (SAL_HEAD in (select SLNO from tbl_Employee_ErnSalaryHead where nocpl=1))" + Environment.NewLine +
                              "update tbl_Employee_Assign_SalStructure set chkHide=2,NCompliance=1 where (Location_id=" + LblLocationID.Text + ") and (p_type='D') and (SAL_HEAD in (select SLNO from tbl_Employee_DeductionSalayHead where nocpl=1))";
                clsDataAccess.RunQry(nc_qry);

            }
            else
            {
                nocpl = 0;
            }

            Lv_Rate = txtLvRate.Text;
            lv_adj = cmbLvAdj.SelectedIndex.ToString();
            Sc_Rate = txtScRate.Text.ToString();
            //===Service Tax===================================================================
            if (chkTax.Checked == true)
            {
                if (rdbCharged.Checked == true)
                {
                    chk_ST = 1;
                    chk_stc = 1;
                }
                else
                {
                    chk_ST = 1;
                    chk_stc = 0;
                }
            }
            else
            {
                chk_ST = 0;
                chk_stc = 0;
            }

            if (dtt.Rows.Count == 0)
            {
                boolStatus = false;
                if (cmbcompany.Text == "")
                {
                    ERPMessageBox.ERPMessage.Show("Select Company Name");
                    cmbcompany.Focus();
                    return;
                }
                if (cmbLocation.Text == "")
                {
                    ERPMessageBox.ERPMessage.Show("Enter Client Name");
                    cmbLocation.Focus();
                    return;
                }


                dt = clsDataAccess.RunQDTbl("SELECT Max(ID) FROM Companywiseid_Relation");
                if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                {
                    Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                }
                else
                {
                    Max_ID = 1;
                }

                //
                //DataTable dt33 = clsDataAccess.RunQDTbl("Select Company_ID,Location_ID from Companywiseid_Relation where Company_ID=" + Company_id + "' and '" + Client_id + "'");
                //if (dt33.Rows.Count == 0)
                //{
                //    boolStatus = clsDataAccess.RunNQwithStatus("insert into  Companywiseid_Relation(ID,Company_ID,Location_ID,PF_Code,Esi_Code,Ptax_Code) values('" + Max_ID + "','" + Company_id + "','" + Client_id + "','" + pf_code + "','" + Esi_Code + "','" + Ptax_Code + "')");
                //}
                //else
                //{
                //    ERPMessageBox.ERPMessage.Show("Company & Clint Relation Already Exit");
                //    boolStatus = false;
                //}
                //
                ins_updt_chk = false;
                if (gstTypeComboBox.Text != "NA")
                {
                    boolStatus = clsDataAccess.RunNQwithStatus("insert into Companywiseid_Relation(ID,Company_ID,Location_ID,PF_Code,Esi_Code,Ptax_Code,Pan_Code,LIN,StReg_Code,M_inst,MOD,[typeRem],[prefix],[sufix],[hidedocno],[lstDocNo],[padding],[isSC],[isST],[isSTC],[freeze],blAdd,blPh,blFax, blEmail,isAdd,blState,blAcNo,GSTTYPE,DueDateDays,[hrs_per_wd],[hrs_per_ot],[apply_hrs_wd],[apply_hrs_ot],[Lv_Rate],[lv_adj],[scPer],[hrs_per_ed],[apply_hrs_ed],mode_cwd,pf_limit, esi_limit,pf_base, esi_base,[remit_pfesi],[OCQ],[Sc_Rate],[nocpl],loc_initial,PsWO) values('" +
                    Max_ID + "','" + lblCoid.Text + "','" + LblLocationID.Text + "','" + pf_code + "','" + Esi_Code + "','" + Ptax_Code + "','" + Pan_Code + "','" + LIN +"','" + StReg_Code + "','" + mo + "','" + mod + "','" + typeRem + "','" + prefix + "','" + sufix + "','" + hidedocno + "','" + lstDocNo + "','" + pad + "','" + chk_SC + "','" + chk_ST + "','" + chk_stc + "','" + freeze + "','" + blAdd + "','" + blPh + "','" +
                    blFax + "','" + blEmail + "','" + isAdd + "','" + blState + "','" + blBankDetail + "','" + gstTypeComboBox.Text + "'," + nudDueDateDats.Value + ",'" + hrs_per_wd + "','" + hrs_per_ot + "','" + apply_hrs_wd + "','" + apply_hrs_ot + "','" + Lv_Rate + "','" + lv_adj + "','" + scPer + "','" + hrs_per_ed + "','" + apply_hrs_ed + "','" + mode_cwd + "','" + pf_limit + "','" + esi_limit + "','" + pf_base + "','" + esi_base + "','" + remit_pfesi + "','" + OCQ + "','" + Sc_Rate + "','" + nocpl + "','" + loc_initial + "','" + PsWO + "')");
                }
                else
                {
                    boolStatus = clsDataAccess.RunNQwithStatus("insert into Companywiseid_Relation(ID,Company_ID,Location_ID,PF_Code,Esi_Code,Ptax_Code,Pan_Code,LIN,StReg_Code,M_inst,MOD,[typeRem],[prefix],[sufix],[hidedocno],[lstDocNo],[padding],[isSC],[isST],[isSTC],[freeze],blAdd,blPh,blFax, blEmail,isAdd,blState,blAcNo,DueDateDays,[hrs_per_wd],[hrs_per_ot],[apply_hrs_wd],[apply_hrs_ot],[Lv_Rate],[lv_adj],[scPer],[hrs_per_ed],[apply_hrs_ed],mode_cwd,pf_limit,esi_limit,pf_base, esi_base,[remit_pfesi],[OCQ],[Sc_Rate],[nocpl],loc_initial,PsWO) values('" +
                    Max_ID + "','" + lblCoid.Text + "','" + LblLocationID.Text + "','" + pf_code + "','" + Esi_Code + "','" + Ptax_Code + "','" + Pan_Code + "','" + LIN + "','" + StReg_Code + "','" + mo + "','" + mod + "','" + typeRem + "','" + prefix + "','" + sufix + "','" + hidedocno + "','" + lstDocNo + "','" + pad + "','" + chk_SC + "','" + chk_ST + "','" + chk_stc + "','" + freeze + "','" + blAdd + "','" +
                    blPh + "','" + blFax + "','" + blEmail + "','" + isAdd + "','" + blState + "','" + blBankDetail + "'," + nudDueDateDats.Value + ",'" + hrs_per_wd + "','" + hrs_per_ot + "','" + apply_hrs_wd + "','" + apply_hrs_ot + "','" + Lv_Rate + "','" + lv_adj + "','" + scPer + "','" + hrs_per_ed + "','" + apply_hrs_ed + "','" + mode_cwd + "','" + pf_limit + "','" + esi_limit + "','" + pf_base + "','" + esi_base + "','" + remit_pfesi + "','" + OCQ + "','" + Sc_Rate + "','" + nocpl + "','" + loc_initial + "','" + PsWO + "')");
                }
                if (boolStatus == true)
                {
                    type_doc_insert();
                    boolStatus = clsDataAccess.RunNQwithStatus("update [tbl_Emp_Location] set Location_Address='" + blAdd.Trim() + "', Location_State=" + statecode.Trim() + " where Location_ID = " + LblLocationID.Text + " and Cliant_ID = " + lblClientID.Text);
                    if (Convert.ToInt32(clsDataAccess.GetresultS("select count(*) from tbl_BillNarr where ([coid]='" + lblCoid.Text + "') and ([clid]='" + lblClientID.Text + "') and ([locid]='" + LblLocationID.Text + "')")) > 0)
                    {
                        boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_BillNarr where ([coid]='" + lblCoid.Text + "') and ([clid]='" + lblClientID.Text + "') and ([locid]='" + LblLocationID.Text + "')");
                    }

                    try
                    {
                        boolStatus = clsDataAccess.RunNQwithStatus("insert into [tbl_BillNarr]" +
                            "([nid],[coid],[clid],[locid],[narration],[remarks],[note],[others],[termscondition],[chkBank]) VALUES (" + Max_ID + "," + lblCoid.Text + "," + lblClientID.Text + "," + LblLocationID.Text +
                            ",'" + txtDesc.Text.Replace("'", "''").Trim() + "','" + txtRemarks.Text.Replace("'", "''").Trim() + "','" + txtNote.Text.Replace("'", "''").Trim() + "','" +
                            txt_Odetails.Text.Replace("'", "''").Trim() + "','" + Txt_TermsConditions.Text.Replace("'", "''").Trim() + "','" + chkBnk + "')");
                    }
                    catch { }

                    SHIFT_LINK(Convert.ToInt32(lblCoid.Text.Trim()), Convert.ToInt32(LblLocationID.Text.Trim()));
                    if (cWD_MOD == 1)
                    {
                        Config_WD();
                    }
                    ERPMessageBox.ERPMessage.Show("Save Successfuly");
                    clearAll();
                }
                else
                    ERPMessageBox.ERPMessage.Show("No Record To Save");
            }
            else
            {
                Max_ID = Convert.ToInt32(dtt.Rows[0][0]);
                pf_code = cmbPfcode.Text;
                Esi_Code = cmbEsicode.Text;
                Ptax_Code = cmbPTaxCode.Text;
                boolStatus = false;
                ins_updt_chk = true;

                blAdd = txtAddress.Text.Trim();
                if (SelectedACNo.Trim() == "")
                    SelectedACNo = cmbBankDetail.ReturnValue.Trim();
                blBankDetail = SelectedACNo;
                blPh = txtContact.Text.Trim();
                blFax = txtFax.Text.Trim();
                blEmail = txtEmail.Text.Trim();
                blState = txtState.Text;
                statecode = txtState.ReturnValue;
                stateName = txtState.Text;

                if (cmbMOD.SelectedIndex == 0 || cmbMOD.SelectedIndex == 2 || cmbMOD.SelectedIndex == 6)
                {
                    mod = cmbMOD.Text;
                }
                else if (cmbMOD.SelectedIndex == 3 || cmbMOD.SelectedIndex == 4)
                {
                    mod = cmbMOD.Text + "[" + txtDays.Text + "-" + tbTo.Text + "]";
                }
                else if (cmbMOD.SelectedIndex == 1)
                {
                    mod = txtDays.Text;
                }

                hrs_per_wd = txt_sal_wd_Hrs.Text.Trim();
                hrs_per_ot = txt_sal_ot_Hrs.Text.Trim();

                if (chk_sal_wd.Checked == true)
                { apply_hrs_wd = "1"; }
                else { apply_hrs_wd = "0"; }
                if (chk_sal_ot.Checked == true)
                { apply_hrs_ot = "1"; }
                else
                {
                    apply_hrs_ot = "0";
                }
                Lv_Rate = txtLvRate.Text;


                if (rdb_oc_attendence.Checked == true)
                {
                    OCQ = 1;
                }
                else
                {
                    OCQ = 0;
                }
                if (chk_nonCompliance.Checked == true)
                {
                    nocpl = 1;
                }
                else
                {
                    nocpl = 0;
                }


                if (gstTypeComboBox.Text != "NA")
                {
                    boolStatus = clsDataAccess.RunNQwithStatus("update Companywiseid_Relation set Company_ID='"+Company_id+"',PF_Code='" + pf_code + "',Esi_Code='" + Esi_Code +
                   "',Ptax_Code='" + Ptax_Code + "',Pan_Code='" + Pan_Code + "',StReg_Code='" + StReg_Code + "',M_inst='" + mo + "',MOD='" + mod +
                   "',typeRem='" + typeRem + "',prefix='" + prefix + "',sufix='" + sufix + "',hidedocno='" + hidedocno + "',lstDocNo='" + lstDocNo +
                   "',padding='" + pad + "',[isSC]='" + chk_SC + "',[isST]='" + chk_ST + "',[isSTC]='" + chk_stc + "',[freeze]='" + freeze +
                   "',blAdd='" + blAdd + "', blPh='" + blPh + "',blFax='" + blFax + "', blEmail='" + blEmail + "',blState='" + blState +
                   "',isAdd='" + isAdd + "',blAcNo = '" + blBankDetail + "',GSTTYPE = '" + gstTypeComboBox.Text + "',DueDateDays = " + nudDueDateDats.Value +
                   ",[hrs_per_wd]='" + hrs_per_wd + "',[hrs_per_ot]='" + hrs_per_ot + "',[apply_hrs_wd]='" + apply_hrs_wd + "',[apply_hrs_ot]='" + apply_hrs_ot +
                   "',[Lv_Rate]='" + Lv_Rate + "',[lv_adj]='" + lv_adj + "',[scPer]='" + scPer + "',[hrs_per_ed]='" + hrs_per_ed + "',[apply_hrs_ed]='" + apply_hrs_ed + 
                   "',mode_cwd='" + mode_cwd + "', pf_limit='" + pf_limit + "', esi_limit='" + esi_limit + "',pf_base='" + pf_base + "', esi_base='" + esi_base +
                   "',remit_pfesi='" + remit_pfesi + "',OCQ='" + OCQ + "',LIN='" + LIN + "',Sc_Rate='" + Sc_Rate + "',nocpl='" + nocpl + "',loc_initial='" + loc_initial + "',PsWO='" + PsWO + "' where (ID='" + Max_ID + "')");
                }
                else
                {
                    boolStatus = clsDataAccess.RunNQwithStatus("update Companywiseid_Relation set Company_ID='" + Company_id + "',PF_Code='" + pf_code + "',Esi_Code='" + Esi_Code +
                   "',Ptax_Code='" + Ptax_Code + "',Pan_Code='" + Pan_Code + "',StReg_Code='" + StReg_Code + "',M_inst='" + mo + "',MOD='" + mod +
                   "',typeRem='" + typeRem + "',prefix='" + prefix + "',sufix='" + sufix + "',hidedocno='" + hidedocno + "',lstDocNo='" + lstDocNo +
                   "',padding='" + pad + "',[isSC]='" + chk_SC + "',[isST]='" + chk_ST + "',[isSTC]='" + chk_stc + "',[freeze]='" + freeze +
                   "',blAdd='" + blAdd + "', blPh='" + blPh + "',blFax='" + blFax + "', blEmail='" + blEmail + "',blState='" + blState +
                   "',isAdd='" + isAdd + "',blAcNo = '" + blBankDetail + "',GSTTYPE = NULL,DueDateDays = " + nudDueDateDats.Value +
                   ",[hrs_per_wd]='" + hrs_per_wd + "',[hrs_per_ot]='" + hrs_per_ot + "',[apply_hrs_wd]='" + apply_hrs_wd + "',[apply_hrs_ot]='" + apply_hrs_ot + 
                   "',[Lv_Rate]='" + Lv_Rate + "',[lv_adj]='" + lv_adj + "',[scPer]='" + scPer + "',[hrs_per_ed]='" + hrs_per_ed + "',[apply_hrs_ed]='" + apply_hrs_ed +
                   "',mode_cwd='" + mode_cwd + "', pf_limit='" + pf_limit + "', esi_limit='" + esi_limit + "',pf_base='" + pf_base + "', esi_base='" + esi_base +
                   "',remit_pfesi='" + remit_pfesi + "',OCQ='" + OCQ + "',LIN='" + LIN + "',Sc_Rate='" + Sc_Rate + "',nocpl='" + nocpl + "',loc_initial='" + loc_initial + "',PsWO='" + PsWO + "' where (ID='" + Max_ID + "')");
                }

                typeRem = txtRemType.Text.Trim();
                prefix = txtPref.Text.Trim();
                sufix = TxtSuffix.Text.ToString();
                if (chkHide_DocNo.Checked == true) { hidedocno = "1"; } else { hidedocno = "0"; }

                if (boolStatus == true)
                {
                    type_doc_insert();
                    if (blAdd.Trim() != "")
                    {
                        boolStatus = clsDataAccess.RunNQwithStatus("update [tbl_Emp_Location] set Location_Address='" + blAdd.Trim() + "', Location_State=" + statecode.Trim() + " where Location_ID = " + LblLocationID.Text + " and Cliant_ID = " + lblClientID.Text);
                    }
                    if (Convert.ToInt32(clsDataAccess.GetresultS("select count(*) from tbl_BillNarr where ([coid]='" + lblCoid.Text + "') and ([clid]='" + lblClientID.Text + "') and ([locid]='" + LblLocationID.Text + "')")) > 0)
                    {
                        boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_BillNarr where ([coid]='" + lblCoid.Text + "') and ([clid]='" + lblClientID.Text + "') and ([locid]='" + LblLocationID.Text + "')");
                    }

                    try
                    {
                        boolStatus = clsDataAccess.RunNQwithStatus("insert into [tbl_BillNarr]" +
                            "([nid],[coid],[clid],[locid],[narration],[remarks],[note],[others],[termscondition],[chkBank]) VALUES (" + Max_ID + "," + lblCoid.Text + "," + lblClientID.Text + "," + LblLocationID.Text +
                            ",'" + txtDesc.Text.Replace("'", "''").Trim() + "','" + txtRemarks.Text.Replace("'", "''").Trim() + "','" + txtNote.Text.Replace("'", "''").Trim() + "','" +
                            txt_Odetails.Text.Replace("'", "''").Trim() + "','" + Txt_TermsConditions.Text.Replace("'", "''").Trim() + "','" + chkBnk + "')");
                    }
                    catch { }
                    SHIFT_LINK(Convert.ToInt32(lblCoid.Text.Trim()), Convert.ToInt32(LblLocationID.Text.Trim()));
                    if (cWD_MOD == 1)
                    {
                        Config_WD();
                    }



                    double ss = 0;
                    try
                    {
                        ss = Convert.ToDouble(txtLstDocNo.Text);
                    }
                    catch { ss = Convert.ToDouble(0); }
                    int vch_update = 0;

                    if (lblDocStruct.Text == "3")
                    {
                        //DataTable dtDes = clsDataAccess.RunQDTbl("SELECT Descode, coid, locid, Type_Desc, Suffix, AccYr, DocNo FROM Docgen_Zone where (Type_Desc='" + lblDesc.Text.Trim() + "') and (accyr='" + cmbYear.Text + "') and (coid='" + Company_id + "') and (locid='" + location_id + "')");
                        try
                        {
                            vch_update = Convert.ToInt32(clsDataAccess.GetresultS("select isNull(DocNo,0)docno from FROM Docgen_Zone where (Type_Desc='" + lblDesc.Text.Trim() + "') and (accyr='" + lblSess.Text + "') and (coid='" + lblCoid.Text + "') and (locid='" + LblLocationID.Text + "')"));
                        }
                        catch { vch_update = 0; }
                        if (vch_update < ss)
                        {
                            // clsDataAccess.RunQry("INSERT INTO Docgen_Zone(Descode, coid, locid, Type_Desc, Suffix, AccYr, DocNo) values ('2','" + Company_id + "','" + location_id + "','" + lblDesc.Text.Trim() + "','20-21','" + cmbYear.Text + "','0')");


                            clsDataAccess.RunQry("UPDATE Docgen_Zone SET DocNo='" + ss + "' where (Type_Desc='" + lblDesc.Text.Trim() + "') and (accyr='" + lblSess.Text + "') and (coid='" + lblCoid.Text + "') and (locid='" + LblLocationID.Text + "')");
                        }
                    }

                    ERPMessageBox.ERPMessage.Show("Save Successfuly");
                    clearAll();
                }
                else
                    ERPMessageBox.ERPMessage.Show("No Record To Save");
            }
            SelectedACNo = "";
        }


        private void btndelete_Click(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(lblCompanyWiseID.Text))
            {
                EDPMessageBox.EDPMessage.Show("Please select location first.");
                return;
            }
            Boolean boolStatus = false;
            //boolStatus = clsDataAccess.RunNQwithStatus("Delete from Companywiseid_Relation where Company_ID=" + Company_id + " and Location_ID ='" + Client_id + "' ");
            boolStatus = clsDataAccess.RunNQwithStatus("delete Companywiseid_Relation where ID = " + lblCompanyWiseID.Text);
            if (boolStatus == true)
            {
                ERPMessageBox.ERPMessage.Show("Delete Successfuly");
                clearAll();
            }
            else
                ERPMessageBox.ERPMessage.Show("No Record To Delete");
        }

        private void data_retrive()
        {
            dgView.DataSource = null;

            //DataTable dt = clsDataAccess.RunQDTbl("Select C.Co_Name,CR.Company_ID,CL.Location_Name,CR.Location_ID,CR.PF_Code,CR.Esi_Code,CR.Ptax_Code,CR.Pan_Code,CR.StReg_Code,CR.M_inst,CR.MOD from Companywiseid_Relation CR,tbl_Emp_Location CL,Company C  where  CR.Company_ID = '" + Company_id + "'and CR.Location_ID ='" + Client_id + "'and C.CO_CODE = CR.Company_ID and CL.Location_ID = CR.Location_ID ");
            

                dt = clsDataAccess.RunQDTbl("Select C.Co_Name,CR.Company_ID,CL.Location_Name,CR.Location_ID,CR.PF_Code," +
               "CR.Esi_Code,CR.Ptax_Code,CR.Pan_Code,CR.LIN,CR.StReg_Code,CR.M_inst,CR.MOD,CR.typeRem,CR.prefix,CR.sufix,CR.hidedocno," +
               "CR.lstDocNo,CR.padding,CR.isST,CR.isSTC,CR.isSC,CR.freeze,CR.blAdd,CR.blPh,CR.blFax,CR.blEmail,CR.isAdd,CR.blState," +
               "CR.blAcNo,CR.ID,CR.DueDateDays,isNull(CR.[hrs_per_wd],8) as hrs_per_wd,isNull(CR.[hrs_per_ot],4) as hrs_per_ot," +
               "isNull(CR.[apply_hrs_wd],0)as apply_hrs_wd,isNull(CR.[apply_hrs_ot],0)as apply_hrs_ot,isNull(cr.[Lv_Rate],0)as Lv_Rate," +
               "isNull(lv_adj,0)as lv_adj,isNull(scPer,0)as scPer,isNull(CR.[apply_hrs_ed],0)as apply_hrs_ed,isNull(CR.[hrs_per_ed],0)as hrs_per_ed," +
               "cr.mode_cwd, cr.pf_limit, cr.esi_limit,cr.pf_base, cr.esi_base,cr.remit_pfesi,cr.OCQ,cr.Sc_Rate,cr.nocpl,cr.loc_initial,cr.PsWO from Companywiseid_Relation CR,tbl_Emp_Location CL,Company C where (CR.Company_ID='" +
               Company_id + "') and (CR.Location_ID='" + Client_id + "') and C.CO_CODE = CR.Company_ID and CL.Location_ID = CR.Location_ID ");
            
            dgView.DataSource = dt;

            dgView.Columns["Company_ID"].Visible = false;
            dgView.Columns["Location_ID"].Visible = false;
            dgView.Columns["loc_initial"].Visible = false;

            dgView.Columns["PsWO"].Visible = false;

            dgView.Columns["typeRem"].Visible = false;
            dgView.Columns["prefix"].Visible = false;
            dgView.Columns["sufix"].Visible = false;
            dgView.Columns["lstDocNo"].Visible = false;
            dgView.Columns["hidedocno"].Visible = false;
            dgView.Columns["isAdd"].Visible = false;
            dgView.Columns["hrs_per_wd"].Visible = false;
            dgView.Columns["hrs_per_ot"].Visible = false;
            dgView.Columns["apply_hrs_wd"].Visible = false;
            dgView.Columns["apply_hrs_ot"].Visible = false;
            
            dgView.Columns["apply_hrs_ed"].Visible = false;
            dgView.Columns["hrs_per_ed"].Visible = false;

            dgView.Columns["Lv_Rate"].Visible = false;
            dgView.Columns["lv_adj"].Visible = false;
            dgView.Columns["Sc_Rate"].Visible = false;
            dgView.Columns["scPer"].Visible = false;

            dgView.Columns["mode_cwd"].Visible = false; 
            dgView.Columns["pf_limit"].Visible = false; 
            dgView.Columns["esi_limit"].Visible = false; 
            dgView.Columns["pf_base"].Visible = false; 
            dgView.Columns["esi_base"].Visible = false;
            dgView.Columns["remit_pfesi"].Visible = false;
            dgView.Columns["OCQ"].Visible = false;
            dgView.Columns["nocpl"].Visible = false;

            dgView.AutoResizeColumns();
            //dataGridView1.Columns[0].Width = 150;
            //dataGridView1.Columns[2].Width = 140;
            dgView.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataTable getGSTApplicable = clsDataAccess.RunQDTbl("select GSTTYPE from Companywiseid_Relation where Company_ID=" + Company_id + " and Location_ID =" + Client_id);
            string gstApplicable = "";
            try
            {
                gstApplicable = getGSTApplicable.Rows[0][0].ToString();
            }
            catch
            {
                gstApplicable = "";
            }
            if (gstApplicable.ToUpper() == "LOCAL")
            {
                gstTypeComboBox.SelectedIndex = 0;
            }
            else if (gstApplicable.ToUpper() == "INTERSTATE")
            {
                gstTypeComboBox.SelectedIndex = 1;
            }
            else if (gstApplicable.ToUpper() == "REVERSE CHARGES")
            {
                gstTypeComboBox.SelectedIndex = 4;
            }
            else if (gstApplicable.ToUpper() == "EXEMPTED")
            {
                gstTypeComboBox.SelectedIndex = 3;
            }
            else
            {
                gstTypeComboBox.SelectedIndex = 2;
            }
        }

        private void clientname()
        {
            try
            {
                dt = clsDataAccess.RunQDTbl("SELECT Cliant_ID,(SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE (Client_id = el.Cliant_ID)) AS ClientName FROM tbl_Emp_Location AS el WHERE (Location_ID='" + Client_id + "')");
                lblClientID.Text = dt.Rows[0]["Cliant_ID"].ToString();
                cmbClient.Text = dt.Rows[0]["ClientName"].ToString();
            }
            catch { }

            //try
            //{
            //    DataTable dt = clsDataAccess.RunQDTbl("");
            //}
            //catch { }

        }

        private void data_retrive_Company()
        {
            /*SET OTHER DETAILS AND TERMS AND CONDITIONS AUTOMATICALLY AFTER 1 MANUAL ENTRY OF THAT COMPANY*/
            DataTable dtNarrTrmCond = clsDataAccess.RunQDTbl("select TOP 1 narration,others,termscondition,remarks,note from tbl_BillNarr where coid = " + Company_id);
            if (dtNarrTrmCond.Rows.Count > 0)
            {
                try
                {
                    txt_Odetails.Text = dtNarrTrmCond.Rows[0]["others"].ToString();
                }
                catch
                {

                }

                try
                {
                    Txt_TermsConditions.Text = dtNarrTrmCond.Rows[0]["termscondition"].ToString();
                }
                catch
                {

                }

                try
                {
                    txtNote.Text = dtNarrTrmCond.Rows[0]["note"].ToString();
                }
                catch
                {

                }

                try
                {
                    txtRemarks.Text = dtNarrTrmCond.Rows[0]["remarks"].ToString();
                }
                catch
                {

                }

                try
                {
                    txtDesc.Text = dtNarrTrmCond.Rows[0]["narration"].ToString();
                }
                catch
                {

                }
            }
            /**/

            dgView.DataSource = null;
            //"Select C.Co_Name,CR.Company_ID,CL.Location_Name,CR.Location_ID,CR.PF_Code,CR.Esi_Code,CR.Ptax_Code,CR.Pan_Code,CR.StReg_Code,CR.M_inst,CR.MOD,CR.typeRem,CR.prefix,CR.sufix,CR.hidedocno,CR.lstDocNo,CR.padding,isST,isSTC,isSC,CR.DueDateDays from Companywiseid_Relation CR,tbl_Emp_Location CL,Company C  where  CR.Company_ID = '" + Company_id + "'and C.CO_CODE = CR.Company_ID and CL.Location_ID = CR.Location_ID "
            //C.Co_Name,CR.Company_ID,CL.Location_Name,CR.Location_ID,CR.PF_Code,CR.Esi_Code,CR.Ptax_Code,CR.Pan_Code,CR.StReg_Code,CR.M_inst,CR.MOD,CR.typeRem,CR.prefix,CR.sufix,CR.hidedocno,CR.lstDocNo,CR.padding,CR.isST,CR.isSTC,CR.isSC,CR.freeze,CR.blAdd,CR.blPh,CR.blFax,CR.blEmail,CR.isAdd,CR.blState,CR.blAcNo,CR.ID,CR.DueDateDays


             dt = clsDataAccess.RunQDTbl("Select C.Co_Name,CR.Company_ID,CL.Location_Name,CR.Location_ID,CR.PF_Code,CR.Esi_Code,CR.Ptax_Code," +
            "CR.Pan_Code,CR.LIN,CR.StReg_Code,CR.M_inst,CR.MOD,CR.typeRem,CR.prefix,CR.sufix,CR.hidedocno,CR.lstDocNo,CR.padding,CR.isST,CR.isSTC,CR.isSC,CR.freeze," +
            "CR.blAdd,CR.blPh,CR.blFax,CR.blEmail,CR.isAdd,CR.blState,CR.blAcNo,CR.ID,CR.DueDateDays,isNull(CR.[hrs_per_wd],8) as hrs_per_wd," +
            "isNull(CR.[hrs_per_ot],4) as hrs_per_ot,isNull(CR.[apply_hrs_wd],0)as apply_hrs_wd,isNull(CR.[apply_hrs_ot],0)as apply_hrs_ot,isNull(cr.[Lv_Rate],0)as Lv_Rate," +
            "isNull(lv_adj,0)as lv_adj,isNull(scPer,0)as scPer,isNull(CR.[apply_hrs_ed],0)as apply_hrs_ed,isNull(CR.[hrs_per_ed],0)as hrs_per_ed,cr.mode_cwd, cr.pf_limit,"+
            "cr.esi_limit,cr.pf_base, cr.esi_base,cr.remit_pfesi,cr.OCQ,cr.nocpl,cr.loc_initial,cr.PsWO from Companywiseid_Relation CR,tbl_Emp_Location CL,Company C  where  CR.Company_ID = '" + Company_id + "' and C.CO_CODE = CR.Company_ID and CL.Location_ID = CR.Location_ID ");

            dgView.DataSource = dt;

            dgView.Columns["Company_ID"].Visible = false;

            dgView.Columns["loc_initial"].Visible = false;
            dgView.Columns["PsWO"].Visible = false;

            dgView.Columns["Location_ID"].Visible = false;
            dgView.Columns["typeRem"].Visible = false;
            dgView.Columns["prefix"].Visible = false;
            dgView.Columns["sufix"].Visible = false;
            dgView.Columns["hidedocno"].Visible = false;
            dgView.Columns["lstDocNo"].Visible = false;
            dgView.Columns["isAdd"].Visible = false;
            dgView.Columns["hrs_per_wd"].Visible = false;
            dgView.Columns["hrs_per_ot"].Visible = false;
            dgView.Columns["apply_hrs_wd"].Visible = false;
            dgView.Columns["apply_hrs_ot"].Visible = false;

            dgView.Columns["Lv_Rate"].Visible = false;
            dgView.Columns["lv_adj"].Visible = false;
            dgView.Columns["scPer"].Visible = false;

            dgView.Columns["apply_hrs_ed"].Visible = false;
            dgView.Columns["hrs_per_ed"].Visible = false;
            dgView.Columns["remit_pfesi"].Visible = false;
            dgView.Columns["OCQ"].Visible = false;
            dgView.Columns["nocpl"].Visible = false;
            dgView.AutoResizeColumns();
            //dataGridView1.Columns[0].Width = 150;
            //dataGridView1.Columns[2].Width = 140;
            dgView.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void clearAll()
        {
            cmbcompany.Text = "";
            cmbLocation.Text = "";
            cmbClient.Text = "";

            lblCoid.Text = "0";
            LblLocationID.Text = "0";
            lblClientID.Text = "0";
           
            cmbPfcode.Text = "";
            cmbEsicode.Text = "";
            cmbPTaxCode.Text = "";
            txtPan.Text = "";
            txtLIN.Text = "";
            txtSTRegNo.Text = "";

            txt_sal_ot_Hrs.Text = "4";
            txt_sal_wd_Hrs.Text = "8";
            chk_sal_ot.Checked = false;
            chk_sal_wd.Checked = false;

            Company_id = 0;
            Client_id = 0;
            pf_code = "";
            Ptax_Code = "";
            Esi_Code = "";
            Pan_Code = "";
            LIN = "";
            StReg_Code = "";
            dgView.DataSource = null;
            cmbMOD.SelectedIndex = 0;
            cmbMOD.Text = "";
            txtDays.Text = "0";
            nudDueDateDats.Value = -1;
            txtPref.Text = "";
            txtRemType.Text = "";
            cmbSuffix.SelectedIndex = 1;
            TxtSuffix.Text = "";

            TxtSCPer.Text = "0";

            txtPad.Text = "2";
            txtNumsep.Text = "1";
            txtPos.Text = "3";
            chkHide_DocNo.Checked = true;
            txtRemType.Text = "";
            txtPref.Text = "";
            cmbSuffix.SelectedIndex = 0;
            txtDoc.Text = "0";
            txtLocID.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtAddress.Text = "";
            txtLvRate.Text = "0.00";
            txtScRate.Text = "0";
            cmbBankDetail.Text = "";
            cmbLvAdj.SelectedIndex = 0;

            ins_updt_chk = false;
            chkSC.Checked = false;
            chkTax.Checked = false;
            chkBank.Checked = false;
            chkSupplyAdd.Checked = false;
            chkFreeze.Checked = false;
            chkIsAdd.Checked = false;
            chk_pf_esi_remit.Checked = false;
            chk_nonCompliance.Checked = false;
            rdbNotCharged.Checked = true;

            rdbLv_normal.Checked = true;
            txtPF_limit.Text = "15000";
            txtEsi_Limit.Text = "21000";
            txtDesc.Text = "";
            gstTypeComboBox.SelectedIndex = 2;
            readFile();

            getShift();

            Config_WD_MOD();


            cmbcompany.PopUp();

            txtLstDocNo.Text = "0";
            lblDesc.Text = "";
            lblDescOld.Text = "";
            chkWO.Checked = false;
            chkWoPS.Checked = false;
        }

        private void cmbPTaxCode_DropDown(object sender, EventArgs e)
        {
            dt = clsDataAccess.RunQDTbl("Select PTAX_Code,Company_ID from PTAXCodeMaster where  (Company_ID = '" + Company_id + "')");
            if (dt.Rows.Count > 0)
            {
                cmbPTaxCode.LookUpTable = dt;
                cmbPTaxCode.ReturnIndex = 0;
            }
        }

        private void cmbPTaxCode_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNothing(cmbPTaxCode.ReturnValue) == false)
                Ptax_Code = cmbPTaxCode.ReturnValue;
        }

        public void gen_docno()
        {
            if (lblDocStruct.Text == "3")
            {
                string docnumber = "";
                string[] dss = cmbdescription.Text.Split('/');
                string zone = clsDataAccess.ReturnValue("select zone from tbl_zone where zid=(select zid from tbl_Emp_Location where Location_ID='" + LblLocationID.Text + "')");
                string loc = cmbLocation.Text.Trim().Substring(0, 3);
                string locID = "",upd="",olocid="",oid="";
                if (cmbLocation.ReturnValue.Trim() != "")
                { locID = Convert.ToDouble(cmbLocation.ReturnValue.Trim()).ToString("00"); }
                else
                {
                    locID = Convert.ToDouble(LblLocationID.Text.Trim()).ToString("00");

                }

                if (txtLocID.Text.Trim() =="")
                txtLocID.Text=clsDataAccess.ReturnValue( "SELECT olocid FROM Docgen_Zone where (accyr='" + lblSess.Text + "') and (coid='" + Company_id + "') and (locid='" + LblLocationID.Text + "')");


                if (txtLocID.Text.Trim() != "")
                {
                    lblDescOld.Text = dss[0].Trim() + "/" + locID;
                    olocid = txtLocID.Text.Trim();

                    upd = "UPDATE  Docgen_Zone SET   Type_Desc ='" + dss[0].Trim() + "/" + olocid + "', olocid='" + txtLocID.Text.Trim() + "' where (coid='" + lblCoid.Text +
                     "') and (locid='" + LblLocationID.Text + "') and (Type_Desc='" + lblDescOld.Text + "')";

                }
                else
                {

                }
                string cli = cmbClient.Text.Trim().Substring(0, 3);
                string cliID = Convert.ToDouble(Client_id).ToString("00");
                if (dss.Length > 0)
                {
                    try
                    {
                        if (dss[1].ToString().Trim().ToLower() == "z")
                        {
                            lblDesc.Text = dss[0].Trim() + "/" + zone.Substring(0, 1);
                            lblDescOld.Text = lblDesc.Text;
                        }
                        else if (dss[1].ToString().Trim().ToLower() == "zone")
                        {
                            lblDesc.Text = dss[0].Trim() + "/" + zone.Trim();
                            lblDescOld.Text = lblDesc.Text;
                        }
                        else if (dss[1].ToString().Trim().ToLower() == "loc")
                        {
                            lblDesc.Text = dss[0].Trim() + "/" + loc;
                            lblDescOld.Text = lblDesc.Text;
                        }
                        else if (dss[1].ToString().Trim().ToLower() == "client")
                        {
                            lblDesc.Text = dss[0].Trim() + "/" + cli;
                            lblDescOld.Text = lblDesc.Text;
                        }
                        else if (dss[1].ToString().Trim().ToLower() == "locid")
                        {
                            if (olocid.Trim()!="")
                            lblDesc.Text = dss[0].Trim() + "/" + olocid;
                            else
                                lblDesc.Text = dss[0].Trim() + "/" + locID;

                            if (upd.Trim()!="")
                            clsDataAccess.RunQry(upd);
                        }
                        else if (dss[1].ToString().Trim().ToLower() == "clientid")
                        {
                            lblDesc.Text = dss[0].Trim() + "/" + cliID;
                            lblDescOld.Text = lblDesc.Text;
                        }
                    }
                    catch { lblDesc.Text = dss[0].Trim(); }
                    try
                    {
                        if (dss[2].ToString().Trim().ToLower() == "z")
                        {
                            lblDesc.Text = lblDesc.Text + "/" + zone.Substring(0, 1);
                            lblDescOld.Text = lblDesc.Text;
                        }
                        else if (dss[2].ToString().Trim().ToLower() == "zone")
                        {
                            lblDesc.Text = lblDesc.Text + "/" + zone.Trim();
                            lblDescOld.Text = lblDesc.Text;
                        }
                        else if (dss[2].ToString().Trim().ToLower() == "loc")
                        {
                            lblDesc.Text = lblDesc.Text + "/" + loc;
                            lblDescOld.Text = lblDesc.Text;
                        }
                        else if (dss[2].ToString().Trim().ToLower() == "client")
                        {
                            lblDesc.Text = lblDesc.Text + "/" + cli;
                            lblDescOld.Text = lblDesc.Text;
                        }
                        else if (dss[2].ToString().Trim().ToLower() == "locid")
                        {
                            if (olocid.Trim() != "")
                                lblDesc.Text = dss[0].Trim() + "/" + olocid;
                            else
                                lblDesc.Text = dss[0].Trim() + "/" + locID;

                            if (upd.Trim() != "")
                                clsDataAccess.RunQry(upd);
                        }
                        else if (dss[2].ToString().Trim().ToLower() == "clientid")
                        {
                            lblDesc.Text = lblDesc.Text + "/" + cliID;
                            lblDescOld.Text = lblDesc.Text;
                        }
                    }
                    catch { lblDesc.Text = lblDesc.Text; }



                    DataTable dtDes = clsDataAccess.RunQDTbl("SELECT Descode, coid, locid, Type_Desc, Suffix, AccYr, DocNo,olocid FROM Docgen_Zone where (Type_Desc='" + lblDesc.Text.Trim() + "') and (accyr='" + lblSess.Text + "') and (coid='" + Company_id + "') and (locid='" + LblLocationID.Text + "')");


                    DataTable dt24 = clsDataAccess.RunQDTbl("select * from docnumber where (ltrim(rtrim(ficode))='" + edpcom.CurrentFicode.Trim() + "') and (ltrim(rtrim(gcode))='" + edpcom.PCURRENT_GCODE.Trim() + "') and (ltrim(rtrim(desccode))='" + cmbdescription.ReturnValue.ToString().Trim() + "') and (ltrim(rtrim(t_entry))='9') and (ltrim(rtrim(session))='" + cmbYear.Text + "')");


                    string PREPOS = dt24.Rows[0][7].ToString().Trim();
                    string SUFPOS = dt24.Rows[0][8].ToString().Trim();
                    string padding = dt24.Rows[0][9].ToString().Trim();
                    string doc_pos = dt24.Rows[0][10].ToString().Trim();
                    string no_sep = dt24.Rows[0][11].ToString().Trim();
                    string prefix = lblDesc.Text.Trim();//dt24.Rows[0][12].ToString().Trim();
                    string suffix = dt24.Rows[0][13].ToString().Trim();//mydr.GetString(13).Trim();
                    string Descode = dt24.Rows[0]["DESCCODE"].ToString().Trim();
                    try
                    {
                        txtLocID.Text = dtDes.Rows[0]["olocid"].ToString().Trim();
                    }
                    catch { txtLocID.Text = ""; }
                    dt24.Clear();
                    if (suffix == "Season" || suffix == "Session" || suffix == "AcYr")
                    {
                        suffix = lblSess.Text;
                    }
                    else if (suffix == "MonthYear")
                    {
                        suffix = dateTimePicker1.Value.ToString("MMM") + "/" + dateTimePicker1.Value.ToString("yy");
                    }


                    if (dtDes.Rows.Count > 0)
                    {
                        docnumber = dtDes.Rows[0]["DocNo"].ToString(); //dt24.Rows[0][0].ToString();
                        txtLstDocNo.Text = docnumber;
                    }
                    else
                    {
                        docnumber = "0";
                        txtLstDocNo.Text = docnumber;
                        clsDataAccess.RunQry("INSERT INTO Docgen_Zone(Descode, coid, locid, Type_Desc, Suffix, AccYr, DocNo,olocid) values ('" + Descode + "','" + lblCoid.Text + "','" + LblLocationID.Text + "','" + prefix + "','" + suffix + "','" + lblSess.Text + "','" + docnumber + "','"+txtLocID.Text.Trim()+"')");
                    }

                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Company_id != 0)
                {
                    nudDueDateDats.Value = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells["DueDateDays"].Value);
                    lblCompanyWiseID.Text = Convert.ToString(dgView.Rows[e.RowIndex].Cells["ID"].Value);
                    cmbPTaxCode.Text = Convert.ToString(dgView.Rows[e.RowIndex].Cells["Ptax_Code"].Value);
                    cmbPfcode.Text = Convert.ToString(dgView.Rows[e.RowIndex].Cells["PF_Code"].Value);
                    cmbEsicode.Text = Convert.ToString(dgView.Rows[e.RowIndex].Cells["Esi_Code"].Value);
                    if (cmbLocation.Text == "" || cmbLocation.Text != Convert.ToString(dgView.Rows[e.RowIndex].Cells["Location_Name"].Value))
                    {
                        Client_id = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells["Location_ID"].Value);
                        LblLocationID.Text = Client_id.ToString();
                        cmbLocation.Text = Convert.ToString(dgView.Rows[e.RowIndex].Cells["Location_Name"].Value);
                        clientname();
                        Config_WD_MOD();
                    }

                    if (lblDocStruct.Text == "3")
                    {
                        //tabControl1.TabPages.Remove(tabPage6);

                        pnlDocNo.Visible = true;
                        

                        gen_docno();
                    }
                    else
                    {
                        pnlDocNo.Visible = false;
                    }

                    //non-complaince
                    try
                    {
                        if (dgView.Rows[e.RowIndex].Cells["nocpl"].Value.ToString() == "1")
                        {
                            chk_nonCompliance.Checked = true;
                        }
                        else
                        {
                            chk_nonCompliance.Checked = false;
                        }
                    }
                    catch { chk_nonCompliance.Checked = false; }

                    txtPan.Text = Convert.ToString(dgView.Rows[e.RowIndex].Cells["Pan_Code"].Value);
                    txtLIN.Text = dgView.Rows[e.RowIndex].Cells["LIN"].Value.ToString().Trim();
                    txtSTRegNo.Text = Convert.ToString(dgView.Rows[e.RowIndex].Cells["StReg_Code"].Value);
                    if (Convert.ToString(dgView.Rows[e.RowIndex].Cells["M_inst"].Value) == "T")
                    { chkMother.Checked = true; }
                    else { chkMother.Checked = false; }

                    string modVal = dgView.Rows[e.RowIndex].Cells["MOD"].Value.ToString().ToUpper();
                    if (modVal == "MONTHOFDAYS")
                    {
                        cmbMOD.SelectedIndex = 0;
                        txtDays.Text = "0";
                        cmbMOD.Text = "MONTHOFDAYS";
                        // txtDays.Visible = false;
                    }
                    else if (modVal == "MOD-SUNDAYS")
                    {
                        cmbMOD.SelectedIndex = 2;
                        txtDays.Text = "0";
                        cmbMOD.Text = "MOD-SUNDAYS";
                        // txtDays.Visible = false;
                    }
                    else if (modVal.Contains("RANGE-SUNDAYS"))
                    {
                        cmbMOD.SelectedIndex = 4;
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                        txtDays.Text = strFromTo[0];
                        tbTo.Text = strFromTo[1];
                    }
                    else if (modVal.Contains("MOD-WO"))
                    {
                        cmbMOD.SelectedIndex = 5;
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('[');
                        txtDays.Text = strFromTo[0];
                        //tbTo.Text = strFromTo[1];
                    }
                    else if (modVal.Contains("RANGE"))
                    {
                        cmbMOD.SelectedIndex = 3;
                        string[] strFromTo = modVal.Substring(modVal.IndexOf('[') + 1, modVal.Length - modVal.IndexOf('[') - 2).Split('-');
                        txtDays.Text = strFromTo[0];
                        tbTo.Text = strFromTo[1];
                    }
                    else if (modVal == "MOD-EWO")
                    {
                        cmbMOD.SelectedIndex = 6;
                        txtDays.Text = "0";
                        cmbMOD.Text = "MOD-EWO";
                        // txtDays.Visible = false;
                    }
                    else
                    {
                        cmbMOD.SelectedIndex = 1;
                        txtDays.Text = dgView.Rows[e.RowIndex].Cells["MOD"].Value.ToString();
                        // txtDays.Visible = true;
                    }

                    txtRemType.Text = dgView.Rows[e.RowIndex].Cells["typeRem"].Value.ToString();
                    txtPref.Text = dgView.Rows[e.RowIndex].Cells["prefix"].Value.ToString();
                    TxtSuffix.Text = dgView.Rows[e.RowIndex].Cells["sufix"].Value.ToString();
                    if (dgView.Rows[e.RowIndex].Cells["hidedocno"].Value.ToString() == "1") { chkHide_DocNo.Checked = true; txtPad.Text = "0"; } else { chkHide_DocNo.Checked = false; txtPad.Text = dgView.Rows[e.RowIndex].Cells["padding"].Value.ToString(); };

                    if (dgView.Rows[e.RowIndex].Cells["isST"].Value.ToString().Trim() == "1")
                    {
                        chkTax.Checked = true;

                        if (dgView.Rows[e.RowIndex].Cells["isSTC"].Value.ToString().Trim() == "1")
                        { rdbCharged.Checked = true; }
                        else { rdbNotCharged.Checked = true; }

                    }
                    else
                    {
                        chkTax.Checked = false;
                        rdbNotCharged.Checked = true;
                    }

                    //mode_cwd=0, pf_limit=15000, esi_limit=21000,pf_base=0, esi_base=1


                    if (dgView.Rows[e.RowIndex].Cells["loc_initial"].Value.ToString().Trim() == "1") { chkWO.Checked = true; } else { chkWO.Checked = false; }

                    if (dgView.Rows[e.RowIndex].Cells["PsWO"].Value.ToString().Trim() == "1") { chkWoPS.Checked = true; } else { chkWoPS.Checked = false; }

                    if (dgView.Rows[e.RowIndex].Cells["mode_cwd"].Value.ToString().Trim() == "1") { rdbLv_RD.Checked = true; }
                    else if (dgView.Rows[e.RowIndex].Cells["mode_cwd"].Value.ToString().Trim() == "2") { rdbLv_RU.Checked = true; }
                    else if (dgView.Rows[e.RowIndex].Cells["mode_cwd"].Value.ToString().Trim() == "3") { rdbLv_RO.Checked = true; }
                    else { rdbLv_normal.Checked = true; }
                    try
                    {
                        txtPF_limit.Text = dgView.Rows[e.RowIndex].Cells["pf_limit"].Value.ToString();
                    }
                    catch { }
                    try
                    {
                        txtEsi_Limit.Text = dgView.Rows[e.RowIndex].Cells["esi_limit"].Value.ToString();
                    }
                    catch { }

                    try
                    {
                        DataTable getGSTApplicable = clsDataAccess.RunQDTbl("select GSTTYPE from Companywiseid_Relation where Company_ID=" + Company_id + " and Location_ID =" + Client_id);
                        string gstApplicable = "";
                        try
                        {
                            gstApplicable = getGSTApplicable.Rows[0][0].ToString();
                        }
                        catch
                        {
                            gstApplicable = "";
                        }
                        if (gstApplicable.ToUpper() == "LOCAL")
                        {
                            gstTypeComboBox.SelectedIndex = 0;
                        }
                        else if (gstApplicable.ToUpper() == "INTERSTATE")
                        {
                            gstTypeComboBox.SelectedIndex = 1;
                        }
                        else if (gstApplicable.ToUpper() == "REVERSE CHARGES")
                        {
                            gstTypeComboBox.SelectedIndex = 4;
                        }
                        else if (gstApplicable.ToUpper() == "EXEMPTED")
                        {
                            gstTypeComboBox.SelectedIndex = 3;
                        }
                        else
                        {
                            gstTypeComboBox.SelectedIndex = 2;
                        }
                    }
                    catch { }


                    if (dgView.Rows[e.RowIndex].Cells["isSC"].Value.ToString().Trim() == "1") { chkSC.Checked = true; } else { chkSC.Checked = false; }
                    txtDoc.Text = dgView.Rows[e.RowIndex].Cells["lstDocNo"].Value.ToString();

                    if (dgView.Rows[e.RowIndex].Cells["freeze"].Value.ToString().Trim() == "1") { chkFreeze.Checked = true; } else { chkFreeze.Checked = false; }

                    txtAddress.Text = dgView.Rows[e.RowIndex].Cells["blAdd"].Value.ToString();
                    txtContact.Text = dgView.Rows[e.RowIndex].Cells["blPh"].Value.ToString();
                    txtFax.Text = dgView.Rows[e.RowIndex].Cells["blFax"].Value.ToString();
                    txtEmail.Text = dgView.Rows[e.RowIndex].Cells["blEmail"].Value.ToString();
                    txtState.Text = dgView.Rows[e.RowIndex].Cells["blState"].Value.ToString();
                    try
                    {
                        txtState.ReturnValue = clsDataAccess.ReturnValue("SELECT [STATE_CODE] FROM StateMaster where ({ fn LCASE([State_Name])}='" + dgView.Rows[e.RowIndex].Cells["blState"].Value.ToString().Trim().ToLower() + "')");
                    }
                    catch { txtState.ReturnValue = "0"; }
                    cmbBankDetail.Text = clsDataAccess.GetresultS("select (bank + ' - AcNo : '+acno + ' - IFSC : '+ifsc) as bank from Branch where ltrim(rtrim(bank))!='' and (gcode='" + Company_id + "') and (acno='" + dgView.Rows[e.RowIndex].Cells["blAcNo"].Value.ToString() + "')");
                    cmbBankDetail.ReturnValue = dgView.Rows[e.RowIndex].Cells["blAcNo"].Value.ToString();

                    //[hrs_per_wd]=8,[hrs_per_ot]=4,[apply_hrs_wd]=0,[apply_hrs_wd]=
                    try
                    {
                        txt_sal_wd_Hrs.Text = dgView.Rows[e.RowIndex].Cells["hrs_per_wd"].Value.ToString();
                    }
                    catch
                    {
                        txt_sal_wd_Hrs.Text = "8";
                    }

                    try
                    {
                        txt_sal_ED_Hrs.Text = dgView.Rows[e.RowIndex].Cells["hrs_per_ed"].Value.ToString();
                    }
                    catch
                    {
                        txt_sal_ED_Hrs.Text = "4";
                    }

                    try
                    {
                        txt_sal_ot_Hrs.Text = dgView.Rows[e.RowIndex].Cells["hrs_per_ot"].Value.ToString();
                    }
                    catch
                    {
                        txt_sal_ot_Hrs.Text = "4";
                    }
                    try
                    {
                        if (dgView.Rows[e.RowIndex].Cells["apply_hrs_wd"].Value.ToString() == "1") { chk_sal_wd.Checked = true; } else { chk_sal_wd.Checked = false; }
                    }
                    catch
                    {
                        chk_sal_wd.Checked = false;
                    }

                    //remit_pfesi
                    try
                    {
                        if (dgView.Rows[e.RowIndex].Cells["remit_pfesi"].Value.ToString() == "1")
                        {
                            chk_pf_esi_remit.Checked = true;
                        }
                        else
                        {
                            chk_pf_esi_remit.Checked = false;
                        }
                    }
                    catch { chk_pf_esi_remit.Checked = false; }

                    try
                    {
                        if (dgView.Rows[e.RowIndex].Cells["apply_hrs_ed"].Value.ToString() == "1") { chk_sal_ED.Checked = true; } else { chk_sal_ED.Checked = false; }
                    }
                    catch
                    {
                        chk_sal_ED.Checked = false;
                    }

                    try
                    {
                        if (dgView.Rows[e.RowIndex].Cells["apply_hrs_ot"].Value.ToString() == "1") { chk_sal_ot.Checked = true; } else { chk_sal_ot.Checked = false; }
                    }
                    catch
                    {
                        chk_sal_ot.Checked = false;

                    }

                    try
                    {
                        TxtSCPer.Text = dgView.Rows[e.RowIndex].Cells["scPer"].Value.ToString();
                    }
                    catch { TxtSCPer.Text = "0"; }
                    try
                    {
                        txtLvRate.Text = dgView.Rows[e.RowIndex].Cells["Lv_Rate"].Value.ToString();
                    }
                    catch
                    {
                        txtLvRate.Text = "0";
                    }

                    try
                    {
                        txtScRate.Text = dgView.Rows[e.RowIndex].Cells["Sc_Rate"].Value.ToString();
                    }
                    catch
                    {
                        txtScRate.Text = "0";
                    }

                    try
                    {
                        cmbLvAdj.SelectedIndex = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells["Lv_adj"].Value);
                    }
                    catch { cmbLvAdj.SelectedIndex = 0; }

                    DataTable dno = clsDataAccess.RunQDTbl("Select PREPOS, SUFPOS, padding, doc_pos FROM docnumber where (locid='" + LblLocationID.Text + "') and (clid='" + lblClientID.Text + "') and (coid='" + lblCoid.Text + "')");

                    if (dgView.Rows[e.RowIndex].Cells["isAdd"].Value.ToString().Trim() == "1")
                    { chkIsAdd.Checked = true; }
                    else if (dgView.Rows[e.RowIndex].Cells["isAdd"].Value.ToString().Trim() == "2")
                    { chkSupplyAdd.Checked = true; }
                    else { chkIsAdd.Checked = false; }

                    try
                    {
                        nudPref.Value = Convert.ToInt32(dno.Rows[0]["PREPOS"]);
                    }
                    catch
                    {
                        nudPref.Value = 1;
                    }

                    try
                    {
                        nudSuf.Value = Convert.ToInt32(dno.Rows[0]["SUFPOS"]);
                    }
                    catch
                    {
                        nudSuf.Value = 2;
                    }
                    try
                    {
                        txtPos.Text = dno.Rows[0]["doc_pos"].ToString();
                    }
                    catch
                    {
                        txtPos.Text = "3";
                    }

                    clientname();
                    otherDetails();
                    shift_display(Convert.ToInt32(lblCoid.Text), Convert.ToInt32(LblLocationID.Text));
                    btnsave.Visible = true;
                }
            }
            catch { }
        }

        private void cmbEsicode_DropDown(object sender, EventArgs e)
        {
            dt = clsDataAccess.RunQDTbl("select ESI_Code,Company_ID from ESICodeMaster where  (Company_ID = '" + Company_id + "')");
            if (dt.Rows.Count > 0)
            {
                cmbEsicode.LookUpTable = dt;
                cmbEsicode.ReturnIndex = 0;
            }
        }

        private void cmbEsicode_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNothing(cmbEsicode.ReturnValue) == false)
                Esi_Code = cmbEsicode.ReturnValue;
        }

        private void cmbMOD_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-- Please maintain this index order --
            //MonthOfDays - 0
            //Other  - 1
            //MOD-SUNDAYS - 2
            //RANGE  - 3
            //RANGE-SUNDAYS - 4
            //MOD-WO - 5
            txtDays.Text = "0";
            tbTo.Text = "0";

            txtDays.Visible = false;
            lblTo.Visible = false;
            tbTo.Visible = false;
            lblTo.Text = "To";
            if (cmbMOD.SelectedIndex == 1)
            {
                txtDays.Visible = true;
            }
            else if (cmbMOD.SelectedIndex == 3 || cmbMOD.SelectedIndex == 4)
            {
                txtDays.Visible = true;
                lblTo.Visible = true;
                tbTo.Visible = true;
            }
            else if (cmbMOD.SelectedIndex == 5)
            {
                lblTo.Text = "WO";
                txtDays.Visible = true;
                lblTo.Visible = true;
            }
            else
            {
                txtDays.Visible = false;
                lblTo.Visible = false;
                tbTo.Visible = false;
            }

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            preview();
            txtDemo.Focus();
        }
        //-----------------------------------------------------------------------------------------------
        public void position()
        {
            int pad = Convert.ToInt32(txtPad.Text.Trim());
            if (nudPref.Value == 1 && nudSuf.Value == 2)
            {
                txtPos.Text = "3";
                demo_value = "1+2+3";
            }
            else if (nudPref.Value == 1 && nudSuf.Value == 3)
            {
                txtPos.Text = "2";
                demo_value = "1+3+2";
            }
            else if (nudPref.Value == 2 && nudSuf.Value == 1)
            {
                txtPos.Text = "3";
                demo_value = "2+1+3";
            }
            else if (nudPref.Value == 2 && nudSuf.Value == 3)
            {
                txtPos.Text = "1";
                demo_value = "3+1+2";
            }
            else if (nudPref.Value == 3 && nudSuf.Value == 1)
            {
                txtPos.Text = "2";
                demo_value = "2+3+1";
            }
            else if (nudPref.Value == 3 && nudSuf.Value == 2)
            {
                txtPos.Text = "1";
                demo_value = "3+2+1";
            }

        }
        public void preview()
        {

            bool bol = false;//check_function();
            if (bol == false)
            {
                if (Information.IsNothing(txtPos.Text) == false)
                {

                    string pad = "";
                    for (int i = 1; i <= Convert.ToInt32(txtPad.Text.Trim()); i++)
                    {
                        pad += "0";
                    }
                    string septr = null;
                    for (int i = 1; i <= Convert.ToInt32(txtNumsep.Text.Trim()); i++)
                    {
                        septr += "/";
                    }
                    position();
                    if (demo_value == "1+2+3")
                    {
                        if (pad != "")
                        {
                            txtDemo.Text = txtPref.Text.Trim() + septr + TxtSuffix.Text.Trim() + septr + pad.Trim();
                        }
                        else
                        {
                            txtDemo.Text = txtPref.Text.Trim() + septr + TxtSuffix.Text.Trim();
                        }
                    }
                    else if (demo_value == "1+3+2")
                    {
                        if (pad != "")
                        {
                            txtDemo.Text = txtPref.Text.Trim() + septr + pad.Trim() + septr + TxtSuffix.Text.Trim();
                        }
                        else
                        {
                            txtDemo.Text = txtPref.Text.Trim() + septr + TxtSuffix.Text.Trim();
                        }
                    }
                    else if (demo_value == "2+1+3")
                    {
                        if (pad != "")
                        {
                            txtDemo.Text = TxtSuffix.Text.Trim() + septr + txtPref.Text.Trim() + septr + pad.Trim();
                        }
                        else
                        {
                            txtDemo.Text = TxtSuffix.Text.Trim() + septr + txtPref.Text.Trim();
                        }
                    }
                    else if (demo_value == "3+1+2")
                    {
                        if (pad != "")
                        {
                            txtDemo.Text = pad.Trim() + septr + txtPref.Text.Trim() + septr + TxtSuffix.Text.Trim();
                        }
                        else
                        {
                            txtDemo.Text = txtPref.Text.Trim() + septr + TxtSuffix.Text.Trim();
                        }
                    }
                    else if (demo_value == "2+3+1")
                    {
                        if (pad != "")
                        {
                            txtDemo.Text = TxtSuffix.Text.Trim() + septr + pad.Trim() + septr + txtPref.Text.Trim();
                        }
                        else
                        {
                            txtDemo.Text = TxtSuffix.Text.Trim() + septr + txtPref.Text.Trim();
                        }
                    }
                    else if (demo_value == "3+2+1")
                    {
                        if (pad != "")
                        {
                            txtDemo.Text = pad.Trim() + septr + TxtSuffix.Text.Trim() + septr + txtPref.Text.Trim();
                        }
                        else
                        {
                            txtDemo.Text = TxtSuffix.Text.Trim() + septr + txtPref.Text.Trim();
                        }
                    }

                }
            }
            bol = false;
        }


        public void othrs()
        {
            try
            {
                DataTable dt = clsDataAccess.RunQDTbl("SELECT nid, narration, remarks, note, others, termscondition,chkBank FROM tbl_BillNarr where (coid='" + lblCoid.Text + "') and (clid='" + LblLocationID.Text + "') and (locid='" + lblClientID.Text + "')");


                Txt_TermsConditions.Text = dt.Rows[0]["termscondition"].ToString();
                txt_Odetails.Text = dt.Rows[0]["others"].ToString();
                txtNote.Text = dt.Rows[0]["note"].ToString();
                txtDesc.Text = dt.Rows[0]["narration"].ToString();
                txtRemarks.Text = dt.Rows[0]["remarks"].ToString();

                if (dt.Rows[0]["chkBank"].ToString() == "1")
                {
                    chkBank.Checked = true;
                }
                else
                {
                    chkBank.Checked = false;
                }
            }
            catch
            {
                readFile();
            }

        }
        private void chkHide_DocNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHide_DocNo.Checked == true)
            {
                txtPad.Text = "0";
                txtPad.ReadOnly = true;
            }
            else
            {
                txtPad.Text = "0";
                txtPad.ReadOnly = false;

            }
        }

        private void txtState_DropDown(object sender, EventArgs e)
        {
            stateName = "";
            DataTable dt = clsDataAccess.RunQDTbl("SELECT [State_Name],[STATE_CODE] FROM StateMaster");
            if (dt.Rows.Count > 0)
            {
                txtState.LookUpTable = dt;
                txtState.ReturnIndex = 1;
            }
        }

        private void txtState_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            stateName = txtState.Text;
            statecode = txtState.ReturnValue;
        }

        private void gstTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gstTypeComboBox.Text == "NA")
            {
                chkTax.Visible = true;
                rdbCharged.Visible = true;
                rdbNotCharged.Visible = true;
            }
            else
            {
                chkTax.Visible = false;
                rdbCharged.Visible = false;
                rdbNotCharged.Visible = false;
            }
        }

        private void chkTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTax.Checked)
            {
                gstTypeComboBox.Visible = false;
            }
            else
            {
                gstTypeComboBox.Visible = true;
            }
        }

        private void cmbBankDetail_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select (bank + ' - AcNo : '+acno + ' - IFSC : '+ifsc) as bank,acno,ifsc from Branch where ltrim(rtrim(bank))!='' and (gcode='" + Company_id + "')");
            if (dt.Rows.Count > 1)
            {
                cmbBankDetail.LookUpTable = dt;
                cmbBankDetail.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                cmbBankDetail.Text = dt.Rows[0]["bank"].ToString();
                cmbBankDetail.ReturnValue = dt.Rows[0]["acno"].ToString();
                SelectedACNo = Convert.ToString(cmbBankDetail.ReturnValue);
            }
        }

        private void cmbBankDetail_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            SelectedACNo = Convert.ToString(cmbBankDetail.ReturnValue);
        }

        private void chkShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = chkShift.SelectedIndex;
            if (chkShift.GetItemChecked(selected) == true)
            {
                chkShift_id.SelectedIndex = chkShift.SelectedIndex;
                chkShift_id.SetItemChecked(selected, true);
                chkShift_no.SelectedIndex = chkShift.SelectedIndex;
                chkShift_no.SetItemChecked(selected, true);
            }
            else
            {
                //chkShift_id.SelectedIndex = chkShift.SelectedIndex;
                chkShift_id.SetItemChecked(selected, false);
                //chkShift_no.SelectedIndex = chkShift.SelectedIndex;
                chkShift_no.SetItemChecked(selected, false);
            }

        }

        public void getShift()
        {
            chkShift.Items.Clear();
            chkShift_id.Items.Clear();
            chkShift_no.Items.Clear();
            DataTable dt = clsDataAccess.RunQDTbl("select sid,sno,sname FROM tbl_shift order by sid,sno");
            for (int ind = 0; ind < dt.Rows.Count; ind++)
            {
                chkShift.Items.Add(dt.Rows[ind]["sname"].ToString());
                chkShift_id.Items.Add(dt.Rows[ind]["sid"].ToString());
                chkShift_no.Items.Add(dt.Rows[ind]["sno"].ToString());

            }
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            frmShift sft = new frmShift();

            sft.ShowDialog();

            getShift();
        }

        private void SHIFT_LINK(int coid, int locid)
        {
            int sid = 0, sno = 0;
            bool bl = clsDataAccess.RunQry("delete from tbl_link_shift where (locid='" + locid + "') and (coid='" + coid + "')");
            for (int ind = 0; ind < chkShift.Items.Count; ind++)
            {

                if (chkShift.GetItemChecked(ind) == true)
                {
                    sid = Convert.ToInt32(chkShift_id.Items[ind].ToString());
                    sno = Convert.ToInt32(chkShift_no.Items[ind].ToString());
                    clsDataAccess.RunQry("INSERT INTO tbl_link_shift (sid,sno,locid,coid) VALUES ('" + sid + "','" + sno + "','" + locid + "','" + coid + "')");

                }

            }
        }

        private void shift_display(int coid, int locid)
        {
            getShift();
            int dx = 0;
            if (chkShift.Items.Count > 0)
            {
                DataTable dt = clsDataAccess.RunQDTbl("SELECT  sid, sno from tbl_link_shift where (locid='" + locid + "') and (coid='" + coid + "') order by sid");
                if (dt.Rows.Count > 0)
                {
                    for (int ind = 0; ind < dt.Rows.Count; ind++)
                    {
                        chkShift_id.SelectedItem = dt.Rows[ind]["sid"].ToString();

                        dx = chkShift_id.SelectedIndex;
                        chkShift_id.SetItemChecked(dx, true);
                        chkShift_no.SetItemChecked(dx, true);
                        chkShift.SetItemChecked(dx, true);
                    }
                }
            }
        }

        private void chkSC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSC.Checked == true)
            {
                TxtSCPer.ReadOnly = false;
            }
            else
            {
                TxtSCPer.ReadOnly = true;
            }
        }

        private void chkIsAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsAdd.Checked == true)
            {
                chkSupplyAdd.Checked = false;
            }

        }

        private void chkSupplyAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupplyAdd.Checked == true)
            {
                chkIsAdd.Checked = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Month >= 4)
            {
                lblSess.Text = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.AddYears(1).Year;

            }
            else
            {
                lblSess.Text = dateTimePicker1.Value.AddYears(-1).Year + "-" + dateTimePicker1.Value.Year;
                
            }
        }





    }
}

