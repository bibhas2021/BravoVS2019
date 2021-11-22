using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using EDPComponent;
using System.IO;
using System.Globalization;
using System.Threading;

namespace PayRollManagementSystem
{
    public partial class EmpJoining : Form//MstFrmDialog
    //EDPComponent.FormBaseERP
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        SqlTransaction sqltran;
        public EmpJoining()
        {
            InitializeComponent();
        }

        Edpcom.EDPCommon edpcmn = new Edpcom.EDPCommon();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommandBuilder cmb = new SqlCommandBuilder();
        SqlCommand cmd = new SqlCommand();
        DataTable dt_document1 = new DataTable();
        //Int32 intNoOfQueries = 0;
        String strMode = "";
        String[] strQuery;
        string Imagepath = "";
        string Imagedocument = "", Imagedocument2 = "", Imagedocument3 = "";
        #region Functions
        Boolean flugAdd_import = false;
        int counter = 1, counter2 = 1, counter3 = 1, doc_type_no = 0, Loc_id = 0, Company_id = 0;
        int defaultEmpCreationLimit = 2000;
        Boolean boolNewEmployeeEntry = false;
        int close_frm = 0;
        #region Validation Functions

        private Boolean ValidateHusband()
        {
            Boolean boolStatus = true;
            //if (cmbHusTitle.Enabled && txtHusFN.Enabled && txtHusLN.Enabled)
            //{
            //    if (clsValidation.ValidateComboBox(cmbHusTitle, "", "Please Enter Husband's Title"))
            //    {
            //        if (clsValidation.ValidateTextBox(txtHusFN, "", "Please Enter Husband's First Name"))
            //        {
            //            if (clsValidation.ValidateTextBox(txtHusLN, "", "Please Enter Husband's Last Name"))
            //            {
            //                boolStatus = true;
            //            }
            //            else
            //            {
            //                tabControl1.SelectedTab = tabPersonal;
            //                txtHusLN.Focus();
            //            }
            //        }
            //        else
            //        {
            //            tabControl1.SelectedTab = tabPersonal;
            //            txtHusFN.Focus();
            //        }
            //    }
            //    else
            //    {
            //        tabControl1.SelectedTab = tabPersonal;
            //        cmbHusTitle.Focus();
            //    }
            //}
            //else
            //{
            //    boolStatus = true;
            //}

            return boolStatus;
        }

        private Boolean Validation()
        {
            Boolean boolStatus = false;
            if (clsValidation.ValidateEdpCombo(cmbdEmpId, "", "Please Enter Employee ID"))
            {
                //if (clsValidation.ValidateComboBox(cmbEmpTitle, "", "Please Enter Employee Title"))
                //{
                if (clsValidation.ValidateTextBox(txtEmpFName, "", "Please Enter Employee First Name"))
                {
                    //if (clsValidation.ValidateTextBox(txtEmpLName, "", "Please Enter Employee Last Name"))
                    //{
                    //if (clsValidation.ValidateComboBox(cmbFatherTitle, "", "Please Enter Father's Title"))
                    //{
                    //if (clsValidation.ValidateTextBox(txtFathFN, "", "Please Enter Father's First Name"))
                    //{
                    //if (clsValidation.ValidateTextBox(txtFathLN, "", "Please Enter Father's Last Name"))
                    //{
                    //if (clsValidation.ValidateComboBox(cmbMotherTitle, "", "Please Enter Mother's Title"))
                    //{
                    //if (clsValidation.ValidateTextBox(txtMothFN, "", "Please Enter Mother's First Name"))
                    //{
                    //    if (clsValidation.ValidateTextBox(txtMotherLN, "", "Please Enter Mother's Last Name"))
                    //    {                                                   
                    //if (ValidateHusband())
                    //{
                    //if (clsValidation.ValidateComboBox(cmbGender, "", "Please Enter Employee Gender"))
                    //{
                    //    if (clsValidation.ValidateComboBox(cmbCast, "", "Please Enter Employee Cast"))
                    //    {
                    if (clsValidation.ValidateEdpCombo(cmbDesg, "", "Please Enter Employee Designation"))
                    {
                        if (ValidateDate(dtpDOB.Text.Trim(), "Date Of Birth"))
                        {

                            //if (clsValidation.ValidateComboBox(cmbMaritalStatus, "", "Please Enter Marital Status"))
                            //{
                            //    if (clsValidation.ValidateEdpCombo(cmbEmpType, "", "Please Enter Job Type"))
                            //    {
                            //        if (clsValidation.ValidateTextBox(txtprestreet, "", "Please Enter Employee's Present Address"))
                            //        {
                            //            if (clsValidation.ValidateTextBox(txtperstreet, "", "Please Enter Employee's Premanent Address"))
                            //            {
                            if (clsValidation.ValidateEdpCombo(cmblocation, "", "Please Enter Employee Location"))
                            {
                                if (clsValidation.ValidateEdpCombo(cmbcopany, "", "Please Enter Company Name"))
                                {
                                    //if (clsValidation.ValidateComboBox(cmbSal, "", "Please Select Salary Structure."))
                                    //{
                                    //if (clsValidation.ValidateTextBox(txtPF, "", "Please Enter Employee's P.F. A/C NO."))
                                    //{
                                    //    if (clsValidation.ValidateTextBox(txtPension, "", "Please Enter Employee's Pension A/C NO."))
                                    //    {
                                    //        if (clsValidation.ValidateTextBox(txtEDLI, "", "Please Enter Employee's EDLI A/C NO."))
                                    //        {
                                    //            if (clsValidation.ValidateTextBox(txtBankAC, "", "Please Enter Employee's Bank Account No. For Salary And Pension"))
                                    //            {
                                    //if (clsValidation.ValidateTextBox(txtESI, "", "Please Enter Employee's E.S.I. No."))
                                    //{
                                    //    if (clsValidation.ValidateTextBox(txtGMI, "", "Please Enter Employee's G.M.I. No."))
                                    //    {




                                    //if (ValidateQualification())
                                    //{
                                    //    if (ValidateFamily())
                                    //    {
                                    boolStatus = true;
                                    //    }
                                    //    else
                                    //    {
                                    //        tabControl1.SelectedTab = tabOther;
                                    //        dgFamily.Rows[0].Cells[0].Selected = true;
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    tabControl1.SelectedTab = tabOther;
                                    //    dgQualification.Rows[0].Cells[0].Selected = true;
                                    //}


                                    //    }
                                    //    else
                                    //    {
                                    //        tabControl1.SelectedTab = tabPersonal;
                                    //        txtGMI.Focus();
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    tabControl1.SelectedTab = tabPersonal;
                                    //    txtBankAC.Focus();
                                    //}
                                    //            }
                                    //            else
                                    //            {
                                    //                tabControl1.SelectedTab = tabPersonal;
                                    //                txtESI.Focus();
                                    //            }
                                    //        }
                                    //        else
                                    //        {
                                    //            tabControl1.SelectedTab = tabPersonal;
                                    //            txtEDLI.Focus();
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        tabControl1.SelectedTab = tabPersonal;
                                    //        txtPension.Focus();
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    tabControl1.SelectedTab = tabPersonal;
                                    //    txtPF.Focus();
                                    //}
                                    //}
                                    //else
                                    //{
                                    //    tabControl1.SelectedTab = tabPersonal;
                                    //    cmbSal.Focus();
                                    //}
                                }
                                else
                                {
                                    tabControl1.SelectedTab = tabPersonal;
                                    cmbcopany.Focus();
                                }
                            }
                            else
                            {
                                tabControl1.SelectedTab = tabPersonal;
                                cmblocation.Focus();
                            }
                        }

                        //                else
                        //                {
                        //                    tabControl1.SelectedTab = tabPersonal;
                        //                    txtperstreet.Focus();
                        //                }
                        //            }
                        //            else
                        //            {
                        //                tabControl1.SelectedTab = tabPersonal;
                        //                txtprestreet.Focus();
                        //            }
                        //        }
                        //        else
                        //        {
                        //            tabControl1.SelectedTab = tabPersonal;
                        //            cmbEmpType.Focus();
                        //        }
                        //    }

                        //    else
                        //    {
                        //        tabControl1.SelectedTab = tabPersonal;
                        //        cmbMaritalStatus.Focus();
                        //    }
                        //}
                        else
                        {
                            tabControl1.SelectedTab = tabPersonal;
                            dtpDOB.Focus();
                        }
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabPersonal;
                        cmbDesg.Focus();
                    }
                }
                //        else
                //        {
                //            tabControl1.SelectedTab = tabPersonal;
                //            cmbCast.Focus();
                //        }
                //    }
                //    else
                //    {
                //        tabControl1.SelectedTab = tabPersonal;
                //        cmbGender.Focus();
                //    }
                //}
                //}

                                //    else
                //    {
                //        tabControl1.SelectedTab = tabPersonal;
                //        txtMotherLN.Focus();
                //    }
                //}
                //else
                //{
                //    tabControl1.SelectedTab = tabPersonal;
                //    txtMothFN.Focus();
                //}
                //}
                //    else
                //    {
                //        tabControl1.SelectedTab = tabPersonal;
                //        cmbMotherTitle.Focus();
                //    }
                //}

                                //else
                //{
                //    tabControl1.SelectedTab = tabPersonal;
                //    txtFathLN.Focus();
                //}
                // }
                //else
                //{
                //    tabControl1.SelectedTab = tabPersonal;
                //    txtFathFN.Focus();
                //}
                //}
                //else
                //{
                //    tabControl1.SelectedTab = tabPersonal;
                //    cmbFatherTitle.Focus();
                //}
                //}
                //else
                //{
                //    tabControl1.SelectedTab = tabPersonal;
                //    txtEmpLName.Focus();
                //}
                //}
                else
                {
                    tabControl1.SelectedTab = tabPersonal;
                    txtEmpFName.Focus();
                }
                //}
                //else
                //{
                //    tabControl1.SelectedTab = tabPersonal;
                //    cmbEmpTitle.Focus();
                //}

            }
            else
            {
                tabControl1.SelectedTab = tabPersonal;
                cmbdEmpId.Focus();
            }

            return boolStatus;
        }

        private Boolean ValidateEmailId()
        {
            Boolean boolStatus = true;

            //if (!clsValidation.IsValidEmail(txtEmailId, "Invalid Email Id"))
            //{
            //    tabControl1.SelectedTab = tabPersonal;
            //    txtEmailId.Focus();
            //    boolStatus = false;
            //} 

            return boolStatus;
        }

        private Boolean ValidateGuardianName(String strGuardian)
        {
            Boolean boolStatus = false;

            if (clsValidation.ValidateTextBox(txtFathFN, "", "Please Enter " + strGuardian + "'s First Name"))
            {
                if (clsValidation.ValidateTextBox(txtFathLN, "", "Please Enter " + strGuardian + "'s Last Name"))
                {
                    boolStatus = true;
                }
                else
                {
                    txtFathLN.Focus();
                }
            }
            else
            {
                txtFathFN.Focus();
            }

            return boolStatus;
        }

        private Boolean ValidateDate(String strDate, String strDateType)
        {
            Boolean boolStatus = true;
            String[] strArr = new String[3];

            strArr = strDate.Split('/');
            if (strArr.Length > 2)
            {
                if (Convert.ToInt32(strArr[2]) == System.DateTime.Now.Year)
                {
                    ERPMessageBox.ERPMessage.Show("Please Enter A Valid " + strDateType);
                    boolStatus = false;
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Please Enter A Valid " + strDateType);
                boolStatus = false;
            }

            return boolStatus;
        }

        private Boolean ValidateContactNo()
        {
            Boolean boolStatus = false;

            if ((String.IsNullOrEmpty(txtMobile.Text.Trim())) && (String.IsNullOrEmpty(txtSTD.Text.Trim()) && String.IsNullOrEmpty(txtPh.Text.Trim())))
            {
                ERPMessageBox.ERPMessage.Show("Please Enter Contact Number");
                txtSTD.Focus();
            }
            else if ((String.IsNullOrEmpty(txtSTD.Text.Trim()) && !String.IsNullOrEmpty(txtPh.Text.Trim())))
            {
                ERPMessageBox.ERPMessage.Show("Please Enter STD Code");
                txtSTD.Focus();
            }
            else if ((!String.IsNullOrEmpty(txtSTD.Text.Trim()) && String.IsNullOrEmpty(txtPh.Text.Trim())))
            {
                ERPMessageBox.ERPMessage.Show("Please Enter STD Phone Number");
                txtPh.Focus();
            }
            else
            {
                boolStatus = true;
            }

            return boolStatus;
        }

        private Boolean ValidateQualification()
        {
            Boolean boolStatus = false;

            if (dgQualification.Rows.Count > 1)
            {
                boolStatus = true;
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Please Enter Atleast One Qualification");
            }

            return boolStatus;
        }

        private Boolean ValidateFamily()
        {
            Boolean boolStatus = false;

            if (dgFamily.Rows.Count > 1)
            {
                boolStatus = true;
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Please Enter Atleast One Family Member Details");
            }

            return boolStatus;
        }

        #endregion

        #region Record Submit Functions

        private void SubmitDetails()
        {
            strQuery = new String[3];
            //strQuery[0] = SubmitPersonalDetails();

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

        private Boolean SubmitFingerScans()
        {
            MemoryStream ms;
            bool boolstatus = false;
            byte[] lf0 = null, lf1 = null, lf2 = null, lf3 = null, lf4 = null, rf0 = null, rf1 = null, rf2 = null, rf3 = null, rf4 = null, Lface = null, Rface = null,sign=null;

            if (strMode == "update")
            {
                clsDataAccess.RunNQwithStatus("DELETE FROM tbl_employee_fscan where (ID='" + cmbdEmpId.Text.Trim() + "')");
                clsDataAccess.ConnectDB();
            }
            string qry = "INSERT INTO tbl_employee_fscan(ID,lThumb,rThumb,lIndex,rIndex,"+
            "lMiddle,rMiddle,lRing,rRing,lfourth,rfourth,lFace,rFace,sign) VALUES ('" + cmbdEmpId.Text.Trim() + 
            "',@lThumb,@rThumb,@lIndex,@rIndex,@lMiddle,@rMiddle,@lRing,@rRing,@lfourth,@rfourth,@lLeft,@rFace,@sign)";

           


            try
            {
               // sqltran = edpcon.mycon.BeginTransaction();
                cmd = new SqlCommand(qry, edpcon.mycon,sqltran);
                if (txtLF0.Text.Trim() != "" || imgLeft0.Image != null)
                {
                    ms = new MemoryStream();
                    imgLeft0.Image.Save(ms, ImageFormat.Jpeg);
                    lf0 = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(lf0, 0, lf0.Length);
                    cmd.Parameters.AddWithValue("@lThumb", lf0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@lThumb", null);

                }
                if (txtRF0.Text.Trim() != "" || imgRight0.Image != null)
                {
                    ms = new MemoryStream();
                    imgRight0.Image.Save(ms, ImageFormat.Jpeg);
                    rf0 = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(rf0, 0, rf0.Length);
                    cmd.Parameters.AddWithValue("@rThumb", rf0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@rThumb", null);

                }

                //===========================================================================
                if (txtLF1.Text.Trim() != "" || imgLeft1.Image != null)
                {
                    ms = new MemoryStream();
                    imgLeft1.Image.Save(ms, ImageFormat.Jpeg);
                    lf1 = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(lf1, 0, lf1.Length);
                    cmd.Parameters.AddWithValue("@lIndex", lf1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@lIndex", null);
                }
                if (txtRF1.Text.Trim() != "" || imgRight1.Image != null)
                {
                    ms = new MemoryStream();
                    imgRight1.Image.Save(ms, ImageFormat.Jpeg);
                    rf1 = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(rf1, 0, rf1.Length);
                    cmd.Parameters.AddWithValue("@rIndex", rf1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@rIndex", null);
                }
                //==========================================================
                if (txtLF2.Text.Trim() != "" || imgLeft2.Image != null)
                {
                    ms = new MemoryStream();
                    imgLeft2.Image.Save(ms, ImageFormat.Jpeg);
                    lf2 = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(lf2, 0, lf2.Length);
                    cmd.Parameters.AddWithValue("@lMiddle", lf2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@lMiddle", null);
                }
                if (txtRF2.Text.Trim() != "" || imgRight2.Image != null)
                {
                    ms = new MemoryStream();
                    imgRight2.Image.Save(ms, ImageFormat.Jpeg);
                    rf2 = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(rf2, 0, rf2.Length);
                    cmd.Parameters.AddWithValue("@rMiddle", rf2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@rMiddle", null);
                }

                //==========================================================

                if (txtLF3.Text.Trim() != "" || imgLeft3.Image != null)
                {
                    ms = new MemoryStream();
                    imgLeft3.Image.Save(ms, ImageFormat.Jpeg);
                    lf3 = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(lf3, 0, lf3.Length);
                    cmd.Parameters.AddWithValue("@lRing", lf3);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@lRing", null);
                }
                if (txtRF3.Text.Trim() != "" || imgRight3.Image != null)
                {
                    ms = new MemoryStream();
                    imgRight3.Image.Save(ms, ImageFormat.Jpeg);
                    rf3 = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(rf3, 0, rf3.Length);
                    cmd.Parameters.AddWithValue("@rRing", rf3);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@rRing", null);
                }

                //==========================================================

                if (txtLF4.Text.Trim() != "" || imgLeft4.Image != null)
                {
                    ms = new MemoryStream();
                    imgLeft4.Image.Save(ms, ImageFormat.Jpeg);
                    lf4 = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(lf4, 0, lf4.Length);
                    cmd.Parameters.AddWithValue("@lfourth", lf4);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@lfourth", null);
                }
                if (txtRF4.Text.Trim() != "" || imgRight4.Image != null)
                {
                    ms = new MemoryStream();
                    imgRight4.Image.Save(ms, ImageFormat.Jpeg);
                    rf4 = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(rf4, 0, rf4.Length);
                    cmd.Parameters.AddWithValue("@rfourth", rf4);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@rfourth", null);
                }
                
                
                //==========================================================
                if (txtLface.Text.Trim() != "" || imgLface.Image != null)
                {
                    ms = new MemoryStream();
                    imgLface.Image.Save(ms, ImageFormat.Jpeg);
                    Lface = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(Lface, 0, Lface.Length);
                    cmd.Parameters.AddWithValue("@lLeft", Lface);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@lLeft", null);

                }
                if (txtRface.Text.Trim() != "" || imgRFace.Image != null)
                {
                    ms = new MemoryStream();
                    imgRFace.Image.Save(ms, ImageFormat.Jpeg);
                    Rface = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(Rface, 0, Rface.Length);
                    cmd.Parameters.AddWithValue("@rFace", Rface); 
                }
                else
                {
                    cmd.Parameters.AddWithValue("@rFace",null); 

                }

                if (txt_img_sig.Text.Trim() != "" || imgSig.Image != null)
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
                //==========================================================

                cmd.ExecuteScalar();
                 boolstatus = true;
                
            }
            catch (Exception ex)
            {
                boolstatus = false;
            }
            finally
            {
               
            }
            return boolstatus;


        }



        private Boolean SubmitPersonalDetails()
        {
            //String strQuery = "";
            int pf_deduction = 0, esi_deduction = 0;
            int _active = 0, pay_mod = 0;
            //int _empbasic1 = 0;
            string lan_Ben = "", blgrp = "", psid = "0", lan_hindi = "", lan_Eng = "", lan_Other2="",lan_Other = "", chest = "", complexion = "", haircolor = "", eyecolor = "", aadhar = "", identity = "";
            string Pf_No = "", Esi_No = "", pf_name = "", esi_name = "",mode_cwd="0", bankAc_Name = "", salid = "", desg = "" ;

            try
            {
                blgrp = txt_blgrp.Text.Trim();
            }
            catch { blgrp = ""; }

            try
            {
                psid = txtPoliceStation.ReturnValue;
            }
            catch
            {
                psid = "0";
            }
            
            if (txtPF.Text.Trim() == "" && chk_pfdeduction.Checked == false) { Pf_No = "xxxx"; }
            else if (txtPF.Text.Trim() == "" && chk_pfdeduction.Checked == true) { Pf_No = ""; }
            else { Pf_No = txtPF.Text.Trim(); }

            if (txtESI.Text.Trim() == "" && chk_esideduction.Checked == false) { Esi_No = "xxxx"; }
            else if (txtESI.Text.Trim() == "" && chk_esideduction.Checked == true) { Esi_No = ""; }
            else { Esi_No = txtESI.Text.Trim(); }
            if (clsDataAccess.ReturnValue("select bankdetails from CompanyLimiter") == "1")
            {
                if ( txtBankAC.Text.Trim() != "" & txtGMI.Text.Trim() != "")
                {
                    pay_mod = 1;

                }
            }
            else
            {
                if (rdbTrans_Cash.Checked == true) { pay_mod = 2; }
                else if (rdbTrans_cheque.Checked == true) { pay_mod = 3; }
                else { pay_mod = 1; }
            }
            if (txtEmpBasic.Text == "")
            { txtEmpBasic.Text = "0"; }

            if (txtEmpSal.Text == "")
            { txtEmpSal.Text = "0"; }

            if (chebenread.Checked == true)
                lan_Ben = "1";
            else
                lan_Ben = "0";

            if (chebenwrite.Checked == true)
                lan_Ben = lan_Ben + ",1";
            else
                lan_Ben = lan_Ben + ",0";

            if (chebenspeak.Checked == true)
                lan_Ben = lan_Ben + ",1";
            else
                lan_Ben = lan_Ben + ",0";


            if (chehinread.Checked == true)
                lan_hindi = "1";
            else
                lan_hindi = "0";

            if (chehinwrite.Checked == true)
                lan_hindi = lan_hindi + ",1";
            else
                lan_hindi = lan_hindi + ",0";

            if (chehinspeak.Checked == true)
                lan_hindi = lan_hindi + ",1";
            else
                lan_hindi = lan_hindi + ",0";

            if (cheengread.Checked == true)
                lan_Eng = "1";
            else
                lan_Eng = "0";

            if (cheengwrite.Checked == true)
                lan_Eng = lan_Eng + ",1";
            else
                lan_Eng = lan_Eng + ",0";

            if (cheengspeak.Checked == true)
                lan_Eng = lan_Eng + ",1";
            else
                lan_Eng = lan_Eng + ",0";

            if (cheotherread.Checked == true)
                lan_Other = "1";
            else
                lan_Other = "0";

            if (cheotherwrite.Checked == true)
                lan_Other = lan_Other + ",1";
            else
                lan_Other = lan_Other + ",0";

            if (cheotherspeak.Checked == true)
                lan_Other = lan_Other + ",1";
            else
                lan_Other = lan_Other + ",0";



            if (cheother2read.Checked == true)
                lan_Other2 = "1";
            else
                lan_Other2 = "0";

            if (cheother2write.Checked == true)
                lan_Other2 = lan_Other2 + ",1";
            else
                lan_Other2 = lan_Other2 + ",0";

            if (cheother2speak.Checked == true)
                lan_Other2 = lan_Other2 + ",1";
            else
                lan_Other2 = lan_Other2 + ",0";

            if (chk_pfdeduction.Checked == true)
                pf_deduction = 1;
            else
                pf_deduction = 0;

            if (chk_esideduction.Checked == true)
                esi_deduction = 1;
            else
                esi_deduction = 0;

            if (chk_active.Checked == true)
                _active = 1;


            if (chkFixed.Checked == true)
            {
                salid = "1";
            }
            else
            {
                salid = "0";
            }

            desg = cmbDept.Text;

            try
            {
                chest = txtChest.Text.Trim();
                complexion = txtComplexion.Text.Trim();
                haircolor = txtHairColor.Text.Trim();
                eyecolor = txtEyecolor.Text.Trim();
                aadhar = txtaadhar.Text.Trim();
                identity=txtIDMark.Text.Trim();
            }
            catch { }

            string emp_name = "";
            emp_name = txtEmpFName.Text.Trim();
            if (txtEmpMName.Text.Trim() == "")
            { }
            else
            {
                emp_name = emp_name + " " + txtEmpMName.Text.Trim();
            }
            if (txtEmpLName.Text.Trim() == "")
            { }
            else
            {
                emp_name = emp_name + " " + txtEmpLName.Text.Trim();
            }

            if (txtPfName.Text.Trim() == "")
            { pf_name = emp_name; }
            else
            { pf_name = txtPfName.Text; }

            if (txtEsiName.Text.Trim() == "")
            { esi_name = emp_name; }
            else
            { esi_name = txtEsiName.Text; }
            if (txtbankAcName.Text.Trim() == "")
            { bankAc_Name = emp_name; }
            else
            { bankAc_Name = txtbankAcName.Text; }

            txtheight.Text = txtheight.Text.Replace("'", "''");


            if ( rdbLv_full.Checked == true)
            {mode_cwd="1";}
            else if (rdbLv_half.Checked == true)
            {mode_cwd = "2";}
            else
            { mode_cwd = "0"; }

            Boolean boolStatus = false;
            //if (dtpPenssion.Visible || tabControl1.SelectedTab==tabOther)
            if (dtpPenssion.Visible || tabControl1.SelectedTab == tabOther || tabControl1.SelectedTab == tabImport || tabControl1.SelectedTab == tabinformation || tabControl1.SelectedTab == tabreference || tabControl1.SelectedTab == tabPfEsi || tabControl1.SelectedTab == tabfscan)
            {

                SetContactDetails();
                if (ChekExRecordByEmpId_Update())
                {

                    ERPMessageBox.ERPMessage.Show("Record Details Already Exists For Employee Id " + cmbdEmpId.Text.Trim() + "." + Environment.NewLine + "Are You Sure to Update  ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
                    if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
                    {

                        //Bitmap myImage = new Bitmap(texpath.Text);
                        //    ImageConverter converter = new ImageConverter();

                        //    object temp = converter.ConvertTo(myImage, typeof(byte[]));
                        //    byte[] imageBytes = (byte[])temp;


                        //    Bitmap documentImage = new Bitmap(Imagedocument);
                        //    //ImageConverter converter = new ImageConverter();
                        //    object temp1 = converter.ConvertTo(documentImage, typeof(byte[]));
                        //    byte[] docimageBytes = (byte[])temp1;

                        //byte[] docimageBytes = ReadFile(Imagedocument);


                        string st = "";

                        strMode = "update";
                        if (pictureimport.Image != null)
                        {
                             st = "update tbl_Employee_Mast set Title='" + cmbEmpTitle.Text.Trim() + "', FirstName='" + txtEmpFName.Text.Trim() + "',MiddleName='" + txtEmpMName.Text.Trim() + "',LastName='" +
                                 txtEmpLName.Text.Trim() + "',FathTitle='" + cmbFatherTitle.Text.Trim() + "',FathFN='" + txtFathFN.Text.Trim() + "',FathMN='" + txtFathMN.Text.Trim() + "',FathLN='" + txtFathLN.Text.Trim() + "',MothTitle='" +
                                 cmbMotherTitle.Text.Trim() + "',MothFN='" + txtMothFN.Text.Trim() + "',MothMN='" + txtMothMN.Text.Trim() + "',MothLN='" + txtMotherLN.Text.Trim() + "',HusTitle='" + cmbHusTitle.Text.Trim() + "',HusFN='" +
                                 txtHusFN.Text.Trim() + "',HusMN='" + txtHusMN.Text.Trim() + "',HusLN='" + txtHusLN.Text.Trim() + "',DesgId=" + GetDesgId(cmbDesg.Text.Trim()) + ",DateOfBirth='" + edpcmn.getSqlDateStr(dtpDOB.Value) +
                                 "',PresentAddress='" + txtPreAdd.Text.Trim() + "',PermanentAddress='" + txtPerAdd.Text.Trim() + "',STD=" + txtSTD.Text.Trim() + ",Phone=" + txtPh.Text.Trim() + ",Mobile=" + txtMobile.Text.Trim() + ",PANno='" +
                                 txtPAN.Text.Trim() + "',PassportNo='" + txtPassport.Text.Trim() + "',PF='" + Pf_No + "',PenssionNo='" + txtPension.Text.Trim() + "',EDLI='" + txtEDLI.Text.Trim() + "',ESIno='" + Esi_No +
                                 "',BankAcountNo='" + txtBankAC.Text.Trim() + "',DateOfJoining='" + edpcmn.getSqlDateStr(dtpDOJ.Value) + "',DateOfRetirement='" + edpcmn.getSqlDateStr(dtpDOR.Value) + "',Gender='" + cmbGender.Text.Trim() + "',Cast='" +
                                 cmbCast.Text.Trim() + "',MaritalStatus='" + cmbMaritalStatus.Text.Trim() + "',JobType=" + GetJobTypeId(cmbEmpType.Text.Trim()) + ",GMIno='" + txtGMI.Text.Trim() + "',EmailId='" + txtEmailId.Text.Trim() +
                                 "',PenssionDate='" + edpcmn.getSqlDateStr(dtpPenssion.Value) +
                                 "',Presentbuilding='" + txtprebuilding.Text + "',Presentstreet='" + txtprestreet.Text.Replace("'","''") + "',Presentareia='" + txtprearea.Text + "',Presentcity='" + txtpretown.Text + "',Presentpin='" + txtprepin.Text +
                                 "',Presentstate='" + GetStatID(cmbprestate.Text.ToString()) + "',Presentcountry='" + GetCountryID(cmbprecountry.Text.ToString()) + "',Permanentbuilding='" + txtperbuilding.Text + "',Permanentstreet='" + txtperstreet.Text.Replace("'", "''") +
                                 "',Permanentareia='" + txtperarea.Text + "',Permanentcity='" + txtpertown.Text + "',Permanentpin='" + txtperpin.Text + "',Permanentstate='" + GetStatID(cmbperstate.Text.ToString()) +
                                 "',Permanentcountry='" + GetCountryID(cmbpercountry.Text.ToString()) + "', Empimage = @Personal_Image ,Empdocimage = '',Religion='" + cmbreligion.Text + "',Bank_Name='" + txtbank.Text.Replace("'","''") + "',Branch_Name='" + txtbranch.Text + "',Bank_AC_Type='" + cmbtype.Text + "', Weight='" + txtweight.Text +
                                 "',Height='" + txtheight.Text + "',Language_Bengali='" + lan_Ben + "',Language_Hindi='" + lan_hindi + "',Language_English='" + lan_Eng + "',Language_Other='" + lan_Other + "',Language_Name='" + otherLanguage.Text + "',Language_Other2='" + lan_Other2 + "',Language_Name2='" + otherLanguage2.Text + "',Empdocimage2='" + Imagedocument2 +
                                 "',Empdocimage3='" + Imagedocument3 + "',Document_Titel='" + comdocumet1.Text + "',Document_Titel2='" + comdocumet2.Text + "',Document_Titel3='" + comdocumet3.Text + "', Session='" + cmbYear.Text.Trim() + "',Location_id = '" + Loc_id + "',Company_id = '" + Company_id +
                                 "', PF_Deduction ='" + pf_deduction + "', ESI_Deduction ='" + esi_deduction + "',EmpBasic =" + txtEmpBasic.Text.Trim() + " ,EmpSal =" + txtEmpSal.Text.Trim() + " ,active ='" + _active + "',pf_name='" + pf_name + "', esi_name='" + esi_name + "',bankAc_name='" + bankAc_Name +
                                 "',status='" + cmbStaus.SelectedValue.ToString() + "',remarks='" + txtRemarks.Text.Trim() + "',oRemarks='" + txtoRemarks.Text.Trim() + "',pay_mod='" + pay_mod + "',salid='" + salid + "',[chest]='" + chest + "',[complexion]='" + complexion + "',[haircolor]='" + haircolor +
                                 "',[eyecolor]='" + eyecolor + "',[aadhar]='" + aadhar + "',[identity]='" + identity + "',[dept]='" + desg + "',[blgrp]='" + blgrp + "',psid='" + psid + "',mode_cwd='" + mode_cwd + "',[pass]='" + txtPassword.Text + "' where (ID='" + cmbdEmpId.Text.Trim() + "')and (Company_id='" + cmbcopany.ReturnValue.Trim() + "')";

                            //LibaryConnection conect = new LibaryConnection();
                            //Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                            //edpcon.Open();                      
                            cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                            photo_convert();
                            cmd.ExecuteNonQuery();
                            //edpcon.Close();
                        }
                        else
                        {
                            st = "update tbl_Employee_Mast set Title='" + cmbEmpTitle.Text.Trim() + "', FirstName='" + txtEmpFName.Text.Trim() + "',MiddleName='" + txtEmpMName.Text.Trim() + "',LastName='" +
                                 txtEmpLName.Text.Trim() + "',FathTitle='" + cmbFatherTitle.Text.Trim() + "',FathFN='" + txtFathFN.Text.Trim() + "',FathMN='" + txtFathMN.Text.Trim() + "',FathLN='" + txtFathLN.Text.Trim() + "',MothTitle='" +
                                 cmbMotherTitle.Text.Trim() + "',MothFN='" + txtMothFN.Text.Trim() + "',MothMN='" + txtMothMN.Text.Trim() + "',MothLN='" + txtMotherLN.Text.Trim() + "',HusTitle='" + cmbHusTitle.Text.Trim() + "',HusFN='" +
                                 txtHusFN.Text.Trim() + "',HusMN='" + txtHusMN.Text.Trim() + "',HusLN='" + txtHusLN.Text.Trim() + "',DesgId=" + GetDesgId(cmbDesg.Text.Trim()) + ",DateOfBirth='" + edpcmn.getSqlDateStr(dtpDOB.Value) +
                                 "',PresentAddress='" + txtPreAdd.Text.Trim() + "',PermanentAddress='" + txtPerAdd.Text.Trim() + "',STD=" + txtSTD.Text.Trim() + ",Phone=" + txtPh.Text.Trim() + ",Mobile=" + txtMobile.Text.Trim() + ",PANno='" +
                                 txtPAN.Text.Trim() + "',PassportNo='" + txtPassport.Text.Trim() + "',PF='" + Pf_No + "',PenssionNo='" + txtPension.Text.Trim() + "',EDLI='" + txtEDLI.Text.Trim() + "',ESIno='" + Esi_No +
                                 "',BankAcountNo='" + txtBankAC.Text.Trim() + "',DateOfJoining='" + edpcmn.getSqlDateStr(dtpDOJ.Value) + "',DateOfRetirement='" + edpcmn.getSqlDateStr(dtpDOR.Value) + "',Gender='" + cmbGender.Text.Trim() + "',Cast='" +
                                 cmbCast.Text.Trim() + "',MaritalStatus='" + cmbMaritalStatus.Text.Trim() + "',JobType=" + GetJobTypeId(cmbEmpType.Text.Trim()) + ",GMIno='" + txtGMI.Text.Trim() + "',EmailId='" + txtEmailId.Text.Trim() +
                                 "',PenssionDate='" + edpcmn.getSqlDateStr(dtpPenssion.Value) +
                                 "',Presentbuilding='" + txtprebuilding.Text + "',Presentstreet='" + txtprestreet.Text.Replace("'", "''") + "',Presentareia='" + txtprearea.Text + "',Presentcity='" + txtpretown.Text + "',Presentpin='" + txtprepin.Text +
                                 "',Presentstate='" + GetStatID(cmbprestate.Text.ToString()) + "',Presentcountry='" + GetCountryID(cmbprecountry.Text.ToString()) + "',Permanentbuilding='" + txtperbuilding.Text + "',Permanentstreet='" + txtperstreet.Text.Replace("'", "''") +
                                 "',Permanentareia='" + txtperarea.Text + "',Permanentcity='" + txtpertown.Text + "',Permanentpin='" + txtperpin.Text + "',Permanentstate='" + GetStatID(cmbperstate.Text.ToString()) +
                                 "',Permanentcountry='" + GetCountryID(cmbpercountry.Text.ToString()) + "',Empdocimage = '',Religion='" + cmbreligion.Text + "',Bank_Name='" + txtbank.Text.Replace("'","''") + "',Branch_Name='" + txtbranch.Text + "',Bank_AC_Type='" + cmbtype.Text + "',Weight='" + txtweight.Text +
                                 "',Height='" + txtheight.Text + "',Language_Bengali='" + lan_Ben + "',Language_Hindi='" + lan_hindi + "',Language_English='" + lan_Eng + "',Language_Other='" + lan_Other + "',Language_Name='" + otherLanguage.Text + "',Language_Other2='" + lan_Other2 + "',Language_Name2='" + otherLanguage2.Text + "',Empdocimage2='" + Imagedocument2 +
                                 "',Empdocimage3='" + Imagedocument3 + "',Document_Titel='" + comdocumet1.Text + "',Document_Titel2='" + comdocumet2.Text + "',Document_Titel3='" + comdocumet3.Text + "' , Session='" + cmbYear.Text.Trim() + "',Location_id = '" + Loc_id + "',Company_id = '" + Company_id +
                                 "',PF_Deduction ='" + pf_deduction + "', ESI_Deduction ='" + esi_deduction + "',EmpBasic =" + txtEmpBasic.Text.Trim() + " ,EmpSal =" + txtEmpSal.Text.Trim() + " ,active ='" + _active + "',pf_name='" + pf_name + "', esi_name='" + esi_name + "',bankAc_name='" + bankAc_Name +
                                 "',status='" + cmbStaus.SelectedValue.ToString() + "',remarks='" + txtRemarks.Text.Trim() + "',oRemarks='" + txtoRemarks.Text.Trim() + "',pay_mod='" + pay_mod + "',salid='" + salid + "',[chest]='" + chest + "',[complexion]='" + complexion + "',[haircolor]='" + haircolor +
                                 "',[eyecolor]='" + eyecolor + "',[aadhar]='" + aadhar + "',[identity]='" + identity + "',[dept]='" + desg + "',[blgrp]='" + blgrp + "',psid='" + psid + "',mode_cwd='" + mode_cwd + "',[pass]='" + txtPassword.Text.Trim().ToLower() + "' where (ID='" + cmbdEmpId.Text.Trim() + "') and (Company_id='" + cmbcopany.ReturnValue.Trim() + "')";

                            //LibaryConnection conect = new LibaryConnection();
                            //conect.Open();
                            //Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                            //edpcon.Open();
                            cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                            cmd.ExecuteNonQuery();
                            //edpcon.Close();
                        }
                        boolStatus = true;
                        st = "insert into [tbl_statuslog](slid,eid,sid,sdate,ucode,reason) values ((select max(slid)+1 from tbl_statuslog),'" + cmbdEmpId.Text.Trim() +
                                    "','" + cmbStaus.SelectedValue.ToString().Trim() + "','" + dtpDOJ.Value.ToString("dd/MMM/yyyy") + "','" + edpcom.UserDesc + "','Employee Updated')";
                        edpcom.RunCommand(st, edpcon.mycon, sqltran);

                        if (lblStatus_old.Text.Trim() != cmbStaus.SelectedValue.ToString().Trim())
                        {
                            //st = "insert into [tbl_statuslog](slid,eid,sid,sdate,ucode) values ((select max(slid)+1 from tbl_statuslog),'" + cmbdEmpId.Text.Trim() +
                            //         "','" + cmbStaus.SelectedItem.ToString().Trim() + "',getdate(),'" + edpcom.UserDesc + "')";
                            //edpcom.RunCommand(st, edpcon.mycon);
                            //st = "";
                        }

                        edpcom.InsertMidasLog(this, true, "mod", cmbdEmpId.Text.Trim());
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabPersonal;
                        cmbdEmpId.ReadOnly = false;
                        cmbdEmpId.Enabled = true;
                        cmbdEmpId.BackColor = Color.White;
                        cmbdEmpId.Focus();
                    }
                }

                else
                {
                    string st = "",pass=txtPassword.Text.Trim().ToLower();
                    if (pass.Trim() == "")
                    {

                        pass = cmbdEmpId.Text.Trim();
                    }
                    if (pictureimport.Image != null)
                    {
                       st = "insert into tbl_Employee_Mast (ID,Title,FirstName,MiddleName,LastName,FathTitle,FathFN,FathMN,FathLN,MothTitle,MothFN,MothMN,MothLN,HusTitle,HusFN,HusMN,HusLN,DateOfBirth,Cast,MaritalStatus,Gender,DesgId,JobType,PresentAddress,PermanentAddress,STD,Phone,Mobile,PANno,PassportNo,PF,PenssionNo,EDLI, " +
                            " ESIno,BankAcountNo,DateOfJoining,DateOfRetirement,Session,GMIno,EmailId,PenssionDate,Presentbuilding,Presentstreet,Presentareia,Presentcity,Presentpin,Presentstate,Presentcountry,Permanentbuilding,Permanentstreet,Permanentareia,Permanentcity,Permanentpin,Permanentstate,Permanentcountry,Empimage,Empdocimage,Religion,Weight," +
                            " Height,Language_Bengali,Language_Hindi,Language_English,Language_Other,Language_Name,Language_Other2,Language_Name2,Empdocimage2,Empdocimage3,Document_Titel,Document_Titel2,Document_Titel3,Location_id,Company_id,PF_Deduction,EmpBasic,active,EMPSAL,Bank_Name,Branch_Name,Bank_AC_Type,pf_name,esi_name,bankAc_name,ESI_Deduction,remarks,oRemarks,status,pay_mod,salid,[identity],chest,complexion,haircolor,eyecolor,aadhar,dept,blgrp,psid,mode_cwd,pass,del,memp) values('" +
                            cmbdEmpId.Text.Trim() + "','" + cmbEmpTitle.Text.Trim() + "','" + txtEmpFName.Text.Trim() + "','" + txtEmpMName.Text.Trim() + "','" + txtEmpLName.Text.Trim() + "','" + cmbFatherTitle.Text.Trim() + "','" + txtFathFN.Text.Trim() + "','" + txtFathMN.Text.Trim() + "','" + txtFathLN.Text.Trim() + "','" + cmbMotherTitle.Text.Trim() +
                            "','" + txtMothFN.Text.Trim() + "','" + txtMothMN.Text.Trim() + "','" + txtMotherLN.Text.Trim() + "','" + cmbHusTitle.Text.Trim() + "','" + txtHusFN.Text.Trim() + "','" + txtHusMN.Text.Trim() + "','" + txtHusLN.Text.Trim() + "','" + edpcmn.getSqlDateStr(dtpDOB.Value) + "','" + cmbCast.Text.Trim() + "','" + cmbMaritalStatus.Text.Trim() +
                            "','" + cmbGender.Text.Trim() + "'," + GetDesgId(cmbDesg.Text.Trim()) + "," + GetJobTypeId(cmbEmpType.Text.Trim()) + ",'" + txtPreAdd.Text.Trim() + "','" + txtPerAdd.Text.Trim() + "'," + txtSTD.Text.Trim() + "," + txtPh.Text.Trim() + "," + txtMobile.Text.ToString() + ",'" + txtPAN.Text.Trim() + "','" +
                            txtPassport.Text.Trim() + "','" + Pf_No + "','" + txtPension.Text.Trim() + "','" + txtEDLI.Text.Trim() + "','" + Esi_No + "','" + txtBankAC.Text.Trim() + "','" + edpcmn.getSqlDateStr(dtpDOJ.Value) + "','" + edpcmn.getSqlDateStr(dtpDOR.Value) + "','" + cmbYear.Text.Trim() + "','" + txtGMI.Text.Trim() + "','" +
                            txtEmailId.Text.Trim() + "','" + edpcmn.getSqlDateStr(dtpPenssion.Value) + "','" + txtprebuilding.Text + "','" + txtprestreet.Text.Replace("'", "''") + "','" + txtprearea.Text + "','" + txtpretown.Text + "','" + txtprepin.Text +
                            "','" + GetStatID(cmbprestate.Text.ToString()) + "','" + GetCountryID(cmbprecountry.Text.ToString()) + "','" + txtperbuilding.Text + "','" + txtperstreet.Text.Replace("'", "''") + "','" + txtperarea.Text + "','" + txtpertown.Text + "','" + txtperpin.Text + "','" + GetStatID(cmbperstate.Text.ToString()) +
                            "','" + GetCountryID(cmbpercountry.Text.ToString()) + "',@Personal_Image,'" + Imagedocument + "','" + cmbreligion.Text + "','" + txtweight.Text + "','" + txtheight.Text + "','" + lan_Ben + "','" + lan_hindi + "','" + lan_Eng + "','" + lan_Other + "','" + otherLanguage.Text + "','" + "','" + lan_Other2 + "','" + otherLanguage2.Text + Imagedocument2 + "','" + Imagedocument3 +
                            "','" + comdocumet1.Text + "','" + comdocumet2.Text + "','" + comdocumet3.Text + "','" + Loc_id + "','" + Company_id + "','" + pf_deduction + "'," + txtEmpBasic.Text.Trim() + ",'" + _active + "'," + txtEmpSal.Text.Trim() + ",'" + txtbank.Text.Replace("'","''") + "','" + txtbranch.Text + "','" + cmbtype.Text + "','" +
                            pf_name + "','" + esi_name + "','" + bankAc_Name + "','" + esi_deduction + "','" + txtRemarks.Text.Trim() + "','" + txtoRemarks.Text.Trim() + "','" + cmbStaus.SelectedValue.ToString() + "','" + pay_mod + "','" + salid + "','" + identity + "','" + chest + "','" + complexion + "','" + haircolor + "','" + eyecolor + "','" + aadhar + "','" + desg + "','" + blgrp + "','" + psid + "','" + mode_cwd + "','"+pass+"','1','0')";

                        //LibaryConnection conect = new LibaryConnection();
                        //conect.Open();
                        //Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
                        //edpcon.Open();
                        cmd = new SqlCommand(st, edpcon.mycon, sqltran);
                        photo_convert();
                        cmd.ExecuteNonQuery();
                        //edpcon.Close();
                        boolStatus = true;
                    }
                    else
                    {
                        boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Mast (ID,Title,FirstName,MiddleName,LastName,FathTitle,FathFN,FathMN,FathLN,MothTitle,MothFN,MothMN,MothLN,HusTitle,HusFN,HusMN,HusLN,DateOfBirth,Cast,MaritalStatus,Gender,DesgId,JobType,PresentAddress,PermanentAddress,STD,Phone,Mobile,PANno,PassportNo,PF,PenssionNo,EDLI, " +
                            " ESIno,BankAcountNo,DateOfJoining,DateOfRetirement,Session,GMIno,EmailId,PenssionDate,Presentbuilding,Presentstreet,Presentareia,Presentcity,Presentpin,Presentstate,Presentcountry,Permanentbuilding,Permanentstreet,Permanentareia,Permanentcity,Permanentpin,Permanentstate,Permanentcountry,Religion,Weight," +
                            " Height,Language_Bengali,Language_Hindi,Language_English,Language_Other,Language_Name,Language_Other2,Language_Name2,Empdocimage2,Empdocimage3,Document_Titel,Document_Titel2,Document_Titel3,Location_id,Company_id,PF_Deduction,EmpBasic,active,EMPSAL,Bank_Name,Branch_Name,Bank_AC_Type,pf_name,esi_name,bankAc_name,ESI_Deduction, remarks, oRemarks, status,pay_mod,salid,[identity],chest,complexion,haircolor,eyecolor,aadhar,dept,blgrp,psid,mode_cwd,[pass],del,memp) values('" +
                            cmbdEmpId.Text.Trim() + "','" + cmbEmpTitle.Text.Trim() + "','" + txtEmpFName.Text.Trim() + "','" + txtEmpMName.Text.Trim() + "','" + txtEmpLName.Text.Trim() + "','" + cmbFatherTitle.Text.Trim() + "','" + txtFathFN.Text.Trim() + "','" + txtFathMN.Text.Trim() + "','" + txtFathLN.Text.Trim() + "','" + cmbMotherTitle.Text.Trim() +
                            "','" + txtMothFN.Text.Trim() + "','" + txtMothMN.Text.Trim() + "','" + txtMotherLN.Text.Trim() + "','" + cmbHusTitle.Text.Trim() + "','" + txtHusFN.Text.Trim() + "','" + txtHusMN.Text.Trim() + "','" + txtHusLN.Text.Trim() + "','" + edpcmn.getSqlDateStr(dtpDOB.Value) + "','" + cmbCast.Text.Trim() + "','" + cmbMaritalStatus.Text.Trim() +
                            "','" + cmbGender.Text.Trim() + "'," + GetDesgId(cmbDesg.Text.Trim()) + "," + GetJobTypeId(cmbEmpType.Text.Trim()) + ",'" + txtPreAdd.Text.Trim() + "','" + txtPerAdd.Text.Trim() + "'," + txtSTD.Text.Trim() + "," + txtPh.Text.Trim() + "," + txtMobile.Text.ToString() + ",'" + txtPAN.Text.Trim() + "','" +
                            txtPassport.Text.Trim() + "','" + Pf_No + "','" + txtPension.Text.Trim() + "','" + txtEDLI.Text.Trim() + "','" + Esi_No + "','" + txtBankAC.Text.Trim() + "','" + edpcmn.getSqlDateStr(dtpDOJ.Value) + "','" + edpcmn.getSqlDateStr(dtpDOR.Value) + "','" + cmbYear.Text.Trim() + "','" + txtGMI.Text.Trim() + "','" +
                            txtEmailId.Text.Trim() + "','" + edpcmn.getSqlDateStr(dtpPenssion.Value) + "','" + txtprebuilding.Text + "','" + txtprestreet.Text.Replace("'", "''") + "','" + txtprearea.Text + "','" + txtpretown.Text + "','" + txtprepin.Text +
                            "','" + GetStatID(cmbprestate.Text.ToString()) + "','" + GetCountryID(cmbprecountry.Text.ToString()) + "','" + txtperbuilding.Text + "','" + txtperstreet.Text.Replace("'", "''") + "','" + txtperarea.Text + "','" + txtpertown.Text + "','" + txtperpin.Text + "','" + GetStatID(cmbperstate.Text.ToString()) +
                            "','" + GetCountryID(cmbpercountry.Text.ToString()) + "','" + cmbreligion.Text + "','" + txtweight.Text + "','" + txtheight.Text + "','" + lan_Ben + "','" + lan_hindi + "','" + lan_Eng + "','" + lan_Other + "','" + otherLanguage.Text + "','" + lan_Other2 + "','" + otherLanguage2.Text + "','" + Imagedocument2 + "','" + Imagedocument3 +
                            "','" + comdocumet1.Text + "','" + comdocumet2.Text + "','" + comdocumet3.Text + "','" + Loc_id + "','" + Company_id + "','" + pf_deduction + "'," + txtEmpBasic.Text.Trim() + ",'" + _active + "'," + txtEmpSal.Text.Trim() + ",'" + txtbank.Text.Replace("'","''") + "','" + txtbranch.Text + "','" +
                            cmbtype.Text + "','" + pf_name + "','" + esi_name + "','" + bankAc_Name + "','" + esi_deduction + "','" + txtRemarks.Text.Trim() + "','" + txtoRemarks.Text.Trim() + "','" + cmbStaus.SelectedValue.ToString() + "','" + pay_mod + "','" + salid + "','" + identity + "','" + chest + "','" + complexion + "','" + haircolor + "','" + eyecolor + "','" + aadhar + "','" + desg + "','" + blgrp + "','" + psid + "','" + mode_cwd + "','"+pass+"','1','0')", edpcon.mycon, sqltran);
                    }
                    edpcom.InsertMidasLog(this, true, "add", cmbdEmpId.Text.Trim());


                    st = "insert into [tbl_statuslog](slid,eid,sid,sdate,ucode,reason) values ((select max(slid)+1 from tbl_statuslog),'" + cmbdEmpId.Text.Trim() +
                                    "','" + cmbStaus.SelectedValue.ToString().Trim() + "','"+ dtpDOJ.Value.ToString("dd/MMM/yyyy") +"','" + edpcom.UserDesc + "','Employee Inserted')";
                    edpcom.RunCommand(st, edpcon.mycon, sqltran);
                    st = "";
                    //boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Mast (ID,Title,FirstName,MiddleName,LastName,FathTitle,FathFN,FathMN,FathLN,MothTitle,MothFN,MothMN,MothLN,HusTitle,HusFN,HusMN,HusLN,DateOfBirth,Cast,MaritalStatus,Gender,DesgId,JobType,PresentAddress,PermanentAddress,STD,Phone,Mobile,PANno,PassportNo,PF,PenssionNo,EDLI, " +
                    //    " ESIno,BankAcountNo,DateOfJoining,DateOfRetirement,Session,GMIno,EmailId,PenssionDate,salid,secid,Presentbuilding,Presentstreet,Presentareia,Presentcity,Presentpin,Presentstate,Presentcountry,Permanentbuilding,Permanentstreet,Permanentareia,Permanentcity,Permanentpin,Permanentstate,Permanentcountry,Empimage,Empdocimage,Religion,Weight," +
                    //    " Height,Language_Bengali,Language_Hindi,Language_English,Language_Other,Language_Name,Empdocimage2,Empdocimage3,Document_Titel,Document_Titel2,Document_Titel3) values('" +
                    //    cmbdEmpId.Text.Trim() + "','" + cmbEmpTitle.Text.Trim() + "','" + txtEmpFName.Text.Trim() + "','" + txtEmpMName.Text.Trim() + "','" + txtEmpLName.Text.Trim() + "','" + cmbFatherTitle.Text.Trim() + "','" + txtFathFN.Text.Trim() + "','" + txtFathMN.Text.Trim() + "','" + txtFathLN.Text.Trim() + "','" + cmbMotherTitle.Text.Trim() +
                    //    "','" + txtMothFN.Text.Trim() + "','" + txtMothMN.Text.Trim() + "','" + txtMotherLN.Text.Trim() + "','" + cmbHusTitle.Text.Trim() + "','" + txtHusFN.Text.Trim() + "','" + txtHusMN.Text.Trim() + "','" + txtHusLN.Text.Trim() + "','" + edpcmn.getSqlDateStr(dtpDOB.Value) + "','" + cmbCast.Text.Trim() + "','" + cmbMaritalStatus.Text.Trim() +
                    //    "','" + cmbGender.Text.Trim() + "'," + clsEmployee.GetDesgId(cmbDesg.Text.Trim()) + "," + clsEmployee.GetJobTypeId(cmbEmpType.Text.Trim()) + ",'" + txtPreAdd.Text.Trim() + "','" + txtPerAdd.Text.Trim() + "'," + txtSTD.Text.Trim() + "," + txtPh.Text.Trim() + "," + txtMobile.Text.ToString() + ",'" + txtPAN.Text.Trim() + "','" +
                    //    txtPassport.Text.Trim() + "','" + txtPF.Text.Trim() + "','" + txtPension.Text.Trim() + "','" + txtEDLI.Text.Trim() + "','" + txtESI.Text.Trim() + "','" + txtBankAC.Text.Trim() + "','" + edpcmn.getSqlDateStr(dtpDOJ.Value) + "','" + edpcmn.getSqlDateStr(dtpDOR.Value) + "','" + cmbYear.Text.Trim() + "','" + txtGMI.Text.Trim() + "','" +
                    //    txtEmailId.Text.Trim() + "','" + edpcmn.getSqlDateStr(dtpPenssion.Value) + "'," + clsEmployee.GetSalID(cmbSal.SelectedItem.ToString()) + "," + clsEmployee.GetSecID(cmbSection.SelectedItem.ToString()) + ",'" + txtprebuilding.Text + "','" + txtprestreet.Text + "','" + txtprearea.Text + "','" + txtpretown.Text + "','" + txtprepin.Text +
                    //    "','" + clsEmployee.GetStatID(cmbprestate.SelectedItem.ToString()) + "','" + clsEmployee.GetCountryID(cmbprecountry.SelectedItem.ToString()) + "','" + txtperbuilding.Text + "','" + txtperstreet.Text + "','" + txtperarea.Text + "','" + txtpertown.Text + "','" + txtperpin.Text + "','" + clsEmployee.GetStatID(cmbperstate.SelectedItem.ToString()) +
                    //    "','" + clsEmployee.GetCountryID(cmbpercountry.SelectedItem.ToString()) + "','" + Imagepath + "','" + Imagedocument + "','" + cmbreligion.Text + "','" + txtweight.Text + "','" + txtheight.Text + "','" + lan_Ben + "','" + lan_hindi + "','" + lan_Eng + "','" + lan_Other + "','" + otherLanguage.Text + "','" + Imagedocument2 + "','" + Imagedocument3 +
                    //    "','" + comdocumet1.Text + "','" + comdocumet2.Text + "','" + comdocumet3.Text + "')");
                }

                //for (int i = 0; i <= dt_document1.Rows.Count - 1; i++)
                //{
                //    if (Convert.ToString(dt_document1.Rows[i]["new"].ToString()) == "5")
                //        boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Emp_DocumentImage where (ID='" + cmbdEmpId.Text.Trim() + "') and (Document_Type='" + dt_document1.Rows[i]["document_type"] + "')", edpcon.mycon, sqltran);
                //}
                try
                {
                    clsDataAccess.RunNQwithStatus("delete from tbl_Emp_DocumentImage where (ID='" + cmbdEmpId.Text.Trim() + "')", edpcon.mycon, sqltran);
                }
                catch { }
                for (int i = 0; i <= dt_document1.Rows.Count - 1; i++)
                {
                    //LibaryConnection conect = new LibaryConnection();


                    if (Convert.ToString(dt_document1.Rows[i]["new"].ToString()) == "1")
                    {
                        string st2 = "Insert into tbl_Emp_DocumentImage (ID,Document_Type,Document_Image) values ('" + dt_document1.Rows[i]["ID"] + "','" + dt_document1.Rows[i]["document_type"] + "',@Doc_img )";
                        //edpcon.Open();
                        cmd = new SqlCommand(st2, edpcon.mycon, sqltran);
                        object temp1;
                        try
                        {
                            Bitmap documentImage = new Bitmap(Convert.ToString(dt_document1.Rows[i]["Image1"]));
                            ImageConverter converter = new ImageConverter();
                            temp1 = converter.ConvertTo(documentImage, typeof(byte[]));
                        }
                        catch {

                            //Bitmap documentImage = new Bitmap(Convert.ToString(dt_document1.Rows[i]["Image1"]));
                            //ImageConverter converter = new ImageConverter();
                            //temp1 = converter.ConvertTo(documentImage, typeof(byte[]));

                            temp1 = System.IO.File.ReadAllBytes(dt_document1.Rows[i]["Image1"].ToString());
                        }
                        byte[] docimageBytes = (byte[])temp1;

                        cmd.Parameters.AddWithValue("Doc_img", docimageBytes);
                        cmd.ExecuteNonQuery();
                        //edpcon.Close();
                    }
                    else
                    {

                        try
                        {
                            string Imgpath = Convert.ToString(dt_document1.Rows[i]["Image1"]);
                            if (Imgpath == "")
                            {
                                MemoryStream stream = new MemoryStream();
                                //imgLeft0.Image = null;
                                //context.Response.BinaryWrite((Byte[])dr[0]);
                                byte[] image = ((byte[])dt_document1.Rows[i]["Image"]);
                                stream.Write(image, 0, image.Length);
                                //edpcon.Close();
                                Bitmap bitmap = new Bitmap(stream);
                                //imgLeft0.Image = bitmap;


                                string st2 = "Insert into tbl_Emp_DocumentImage (ID,Document_Type,Document_Image) values ('" + dt_document1.Rows[i]["ID"] + "','" + dt_document1.Rows[i]["document_type"] + "',@Doc_img )";
                                //edpcon.Open();
                                cmd = new SqlCommand(st2, edpcon.mycon, sqltran);

                                //   Bitmap documentImage = new Bitmap(Convert.ToString(dt_document1.Rows[i]["Image1"]));
                                // ImageConverter converter = new ImageConverter();
                                //object temp1 = converter.ConvertTo(documentImage, typeof(byte[]));
                                //byte[] docimageBytes = (byte[])temp1;

                                cmd.Parameters.AddWithValue("Doc_img", image);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch { }

                    }

                }
            }
            else
            {
                SetPenssionAge();
            }

            return boolStatus;
        }

        private Boolean SubmitQualification()
        {
            int j;
            Boolean boolSubmit = true;
            Boolean boolStatus = false;
            Int32 intCounter = 0;
            if (dgQualification.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgQualification.Rows.Count - 1; i++)
                {
                    String strQualification = Convert.ToString(dgQualification.Rows[i].Cells["Qualification"].Value);
                    String strBoard = Convert.ToString(dgQualification.Rows[i].Cells["Board"].Value);
                    String strYear = Convert.ToString(dgQualification.Rows[i].Cells["Year"].Value);
                    String strPercentage = Convert.ToString(dgQualification.Rows[i].Cells["Percentage"].Value);
                    String strSlNo = Convert.ToString(dgQualification.Rows[i].Cells["SlNo"].Value);

                    if (!String.IsNullOrEmpty(strQualification))
                    {
                        if (!String.IsNullOrEmpty(strBoard))
                        {
                            if (!String.IsNullOrEmpty(strYear))
                            {
                                if (!String.IsNullOrEmpty(strPercentage))
                                {
                                    DataTable dt = new DataTable();
                                    if (strQualification != "")
                                        dt = clsDataAccess.RunQDTbl("Select Quali_Code from Qualification_Master Where Quali_Name='" + strQualification + "'", edpcon.mycon, sqltran);
                                    if (dt.Rows.Count > 0)
                                    {
                                        strQualification = Convert.ToString(dt.Rows[0]["Quali_Code"]);
                                    }
                                    if (!String.IsNullOrEmpty(strSlNo) && strMode == "update")
                                    {
                                        boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_QualificationDetails set Qualification='" + strQualification + "',University='" + strBoard + "',YearOfPassing=" + strYear + ",Percentage=" + strPercentage + " where ID='" + cmbdEmpId.Text.Trim() + "' and SlNo=" + strSlNo + "", edpcon.mycon, sqltran);
                                    }
                                    else
                                    {
                                        boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_QualificationDetails (ID,Qualification,University,YearOfPassing,Percentage) values('" + cmbdEmpId.Text.Trim() + "','" + strQualification + "','" + strBoard + "'," + strYear + "," + strPercentage + ")", edpcon.mycon, sqltran);
                                    }
                                    if (boolStatus)
                                    {
                                        intCounter += 1;
                                    }
                                }
                                else
                                {
                                    j = i + 1;
                                    dgQualification.Rows[j - 1].Cells["Percentage"].Selected = true;
                                    dgQualification.Rows[j - 1].Cells["Year"].Selected = false;
                                    dgQualification.Rows[j - 1].Cells["Board"].Selected = false;
                                    dgQualification.Rows[j - 1].Cells["Qualification"].Selected = false;
                                    ERPMessageBox.ERPMessage.Show("Please Enter Percentage In " + j + "th Row");
                                }
                            }
                            else
                            {
                                j = i + 1;
                                dgQualification.Rows[j - 1].Cells["Percentage"].Selected = false;
                                dgQualification.Rows[j - 1].Cells["Year"].Selected = true;
                                dgQualification.Rows[j - 1].Cells["Board"].Selected = false;
                                dgQualification.Rows[j - 1].Cells["Qualification"].Selected = false;
                                ERPMessageBox.ERPMessage.Show("Please Enter Year Of Passing In " + j + "th Row");
                            }
                        }
                        else
                        {
                            j = i + 1;
                            dgQualification.Rows[j - 1].Cells["Percentage"].Selected = false;
                            dgQualification.Rows[j - 1].Cells["Year"].Selected = false;
                            dgQualification.Rows[j - 1].Cells["Board"].Selected = true;
                            dgQualification.Rows[j - 1].Cells["Qualification"].Selected = false;
                            ERPMessageBox.ERPMessage.Show("Please Enter University In " + j + "th Row");
                        }
                    }
                    else
                    {
                        j = i + 1;
                        dgQualification.Rows[j - 1].Cells["Percentage"].Selected = false;
                        dgQualification.Rows[j - 1].Cells["Year"].Selected = false;
                        dgQualification.Rows[j - 1].Cells["Board"].Selected = false;
                        dgQualification.Rows[j - 1].Cells["Qualification"].Selected = true;
                        ERPMessageBox.ERPMessage.Show("Please Enter Qualification In " + j + "th Row");
                    }

                }

                if (intCounter == dgQualification.Rows.Count - 1)
                {
                    boolSubmit = true;
                    // ERPMessageBox.ERPMessage.Show("Qualification Details Inserted Successfully");
                }
            }
            return boolSubmit;
        }

        private Boolean SubmitFamilyDetails()
        {
            int j;
            Boolean boolSubmit = true;
            Boolean boolStatus = false;
            //Boolean boolSelect = false;
            Int32 intCounter = 0;
            if (dgFamily.Rows.Count > 1)
            {
                if (RepeatRelation("Father"))
                {
                    if (RepeatRelation("Mother"))
                    {
                        if (RepeatRelation("Wife"))
                        {
                            for (Int32 i = 0; i < dgFamily.Rows.Count - 1; i++)
                            {

                                String strName = Convert.ToString(dgFamily.Rows[i].Cells["name1"].Value);
                                String strRelation = Convert.ToString(dgFamily.Rows[i].Cells["Relation"].Value);
                                String strAge = Convert.ToString(dgFamily.Rows[i].Cells["Age"].Value);
                                String strDependent = Convert.ToString(dgFamily.Rows[i].Cells["Dependent"].Value);
                                String strSlNo = Convert.ToString(dgFamily.Rows[i].Cells["Id"].Value);

                                String strdob = Convert.ToString(dgFamily.Rows[i].Cells["family_dob"].Value);

                                String straadhar = Convert.ToString(dgFamily.Rows[i].Cells["family_aadhar"].Value);

                                if (!String.IsNullOrEmpty(strDependent))
                                {
                                    if (strDependent.ToLower() == "true" || strDependent.ToLower() == "1")
                                    {
                                        strDependent = "1";
                                    }
                                    else
                                    {
                                        strDependent = "0";
                                    }
                                }
                                else
                                {
                                    strDependent = "0";
                                }

                                if (!String.IsNullOrEmpty(strName))
                                {
                                    if (!String.IsNullOrEmpty(strRelation))
                                    {
                                        if (!String.IsNullOrEmpty(strAge))
                                        {
                                            DataTable dt = new DataTable();
                                            if (strRelation != "")
                                                //dt = clsDataAccess.RunQDTbl("Select Relation_Code from Relation_Master Where Relation_Name='" + strRelation + "'");
                                                dt = clsDataAccess.RunQDTbl("Select Relation_Code from Relation_Master Where Relation_Name='" + strRelation + "'", edpcon.mycon, sqltran);
                                            if (dt.Rows.Count > 0)
                                            {
                                                strRelation = Convert.ToString(dt.Rows[0]["Relation_Code"]);
                                            }

                                            if (!String.IsNullOrEmpty(strSlNo) && strMode == "update")
                                            {
                                                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_FamilyDetails set Name='" + strName + "',Relation='" + strRelation + "',Age='" + strAge + "',Dependent='" + strDependent + "',dob='"+strdob+"',aadhar='"+straadhar+"' where ID='" + cmbdEmpId.Text.Trim() + "' and SlNo='" + strSlNo + "'", edpcon.mycon, sqltran);
                                            }
                                            else
                                            {
                                                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_FamilyDetails(ID,Name,Relation,Age,Dependent,dob,aadhar) values('" + cmbdEmpId.Text.Trim() + "','" + strName + "','" + strRelation + "'," + strAge + "," + strDependent + ",'"+strdob+"','"+straadhar+"')", edpcon.mycon, sqltran);
                                            }
                                            if (boolStatus)
                                            {
                                                intCounter += 1;
                                            }
                                        }
                                        else
                                        {
                                            j = i + 1;
                                            ERPMessageBox.ERPMessage.Show("Please Enter Age In Line" + j + "");
                                        }
                                    }
                                    else
                                    {
                                        j = i + 1;
                                        ERPMessageBox.ERPMessage.Show("Please Enter Relation In Line" + j + "");
                                    }
                                }
                                else
                                {
                                    j = i + 1;
                                    ERPMessageBox.ERPMessage.Show("Please Enter Person Name In Line" + j + "");
                                }
                            }
                        }
                        else
                        {
                            ERPMessageBox.ERPMessage.Show("Relationship Wife Cannot be Repeated");
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Relationship Mother Cannot be Repeated");
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Relationship Father Cannot be Repeated");
                }
                if (intCounter == dgFamily.Rows.Count - 1)
                {
                    boolSubmit = true;
                    //ERPMessageBox.ERPMessage.Show("Family Details Inserted Successfully");
                }
            }
            return boolSubmit;
        }

        private Boolean SubmitOthersDetails()
        {
            Boolean boolStatus = false;

            string Pre_location = "";
            Pre_location = textBox31.Text + "," + textBox32.Text + "," + textBox33.Text;
            if (strMode == "update")
            {
                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Other_Reff set Emarg_Name='" + txtemername.Text.Trim() + "', Emarg_Address='" + txtemeraddress.Text.Trim() + "',Emarg_Tele='" + txtemerphone.Text.Trim() + "',Emarg_Mobile='" +
                        txtemermobile.Text.Trim() + "',Emp_Achiev='" + textBox25.Text.Trim() + "',Emp_Club='" + textBox26.Text.Trim() + "',Emp_Association='" + textBox27.Text.Trim() + "',Emp_Org='" + textBox28.Text.Trim() + "',Emp_Notic='" +
                        textBox29.Text.Trim() + "',Emp_Join_refer='" + textBox30.Text.Trim() + "',Emp_Preferlocation='" + Pre_location + "',Emp_Criminal_Rec='" + textBox34.Text.Trim() + "',Emp_illness='" + textBox35.Text.Trim() + "',Emp_Interview_Details='" +
                        textBox36.Text.Trim() + "',Emp_OtherInformation='" + textBox37.Text.Trim() + "',Emp_Expected_Salary='" + textBox38.Text.Trim() + "',Ref_Name='" + txtname1.Text.Trim() + "',Ref_Address='" + txtAddress1.Text.Trim() +
                        "',Ref_Occupation='" + txtoccuption1.Text.Trim() + "',Ref_Phone='" + txtphone1.Text.Trim() + "',Ref_Email='" + txtemail1.Text.Trim() + "',Ref_Name1='" + txtname2.Text.Trim() + "',Ref_Address1='" + txtaddress2.Text.Trim() + "',Ref_Occupation1='" +
                        txtoccupation2.Text.Trim() + "',Ref_Phone1='" + txtphone2.Text.Trim() + "',Ref_Email1='" + txtemail2.Text.Trim() + "',Emp_Service='" + txtservice.Text.Trim() + "',Emp_Period_Service='" + txtperiod.Text.Trim() + "',Emp_Rank='" + txtranks.Text.Trim() +
                        "',Emp_ICard_No='" + txticards.Text.Trim() + "',Emp_Arms='" + txtarms.Text.Trim() + "',Emp_Pension_No='" + txtpensionno.Text.Trim() + "',Emp_GunLicence='" + txtgunlicence.Text.Trim() + "',Emp_Operation_Area='" +
                        txtoparation.Text.Trim() + "',Emp_issue='" + txtissue.Text.Trim() + "',Emp_GunType='" + txtgun.Text.Trim() + "',Emp_GunValid='" + txtvalid.Text.Trim() + "',Emp_DrivingLicence='" + txtdrivinglicence.Text.Trim() + "' where ID='" +
                        cmbdEmpId.Text.Trim() + "' ", edpcon.mycon, sqltran);

                if (boolStatus == false)
                {

                    if (clsDataAccess.ReturnValue("Select count(*) from tbl_Employee_Other_Reff where ID='" + cmbdEmpId.Text.Trim() + "'") == "0")
                    {
                        boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Other_Reff (ID,Emarg_Name,Emarg_Address,Emarg_Tele,Emarg_Mobile,Emp_Achiev,Emp_Club,Emp_Association,Emp_Org,Emp_Notic,Emp_Join_refer,Emp_Preferlocation,Emp_Criminal_Rec,Emp_illness,Emp_Interview_Details,Emp_OtherInformation,Emp_Expected_Salary, " +
                   " Ref_Name,Ref_Address,Ref_Occupation,Ref_Phone,Ref_Email,Ref_Name1,Ref_Address1,Ref_Occupation1,Ref_Phone1,Ref_Email1,Emp_Service,Emp_Period_Service,Emp_Rank,Emp_ICard_No,Emp_Arms,Emp_Pension_No,Emp_GunLicence,Emp_Operation_Area,Emp_issue,Emp_GunType,Emp_GunValid,Emp_DrivingLicence) values('" +
                   cmbdEmpId.Text.Trim() + "','" + txtemername.Text.Trim() + "','" + txtemeraddress.Text.Trim() + "','" + txtemerphone.Text.Trim() + "','" + txtemermobile.Text.Trim() + "','" + textBox25.Text.Trim() + "','" + textBox26.Text.Trim() + "','" + textBox27.Text.Trim() + "','" + textBox28.Text.Trim() + "','" + textBox29.Text.Trim() +
                   "','" + textBox30.Text.Trim() + "','" + Pre_location + "','" + textBox34.Text.Trim() + "','" + textBox35.Text.Trim() + "','" + textBox36.Text.Trim() + "','" + textBox37.Text.Trim() + "','" + textBox38.Text.Trim() + "','" + txtname1.Text.Trim() + "','" + txtAddress1.Text.Trim() + "','" + txtoccuption1.Text.Trim() +
                   "','" + txtphone1.Text.Trim() + "','" + txtemail1.Text.Trim() + "','" + txtname2.Text.Trim() + "','" + txtaddress2.Text.Trim() + "','" + txtoccupation2.Text.Trim() + "','" + txtphone2.Text.Trim() + "','" + txtemail2.Text.Trim() + "','" + txtservice.Text.ToString() + "','" + txtperiod.Text.Trim() + "','" +
                   txtranks.Text.Trim() + "','" + txticards.Text.Trim() + "','" + txtarms.Text.Trim() + "','" + txtpensionno.Text.Trim() + "','" + txtgunlicence.Text.Trim() + "','" + txtoparation.Text.Trim() + "','" + txtissue.Text.Trim() + "','" + txtgun.Text.Trim() + "','" + txtvalid.Text.Trim() + "','" + txtdrivinglicence.Text.Trim() + "')", edpcon.mycon, sqltran);

                    }
                }

            }
            else
            {
                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Other_Reff (ID,Emarg_Name,Emarg_Address,Emarg_Tele,Emarg_Mobile,Emp_Achiev,Emp_Club,Emp_Association,Emp_Org,Emp_Notic,Emp_Join_refer,Emp_Preferlocation,Emp_Criminal_Rec,Emp_illness,Emp_Interview_Details,Emp_OtherInformation,Emp_Expected_Salary, " +
                    " Ref_Name,Ref_Address,Ref_Occupation,Ref_Phone,Ref_Email,Ref_Name1,Ref_Address1,Ref_Occupation1,Ref_Phone1,Ref_Email1,Emp_Service,Emp_Period_Service,Emp_Rank,Emp_ICard_No,Emp_Arms,Emp_Pension_No,Emp_GunLicence,Emp_Operation_Area,Emp_issue,Emp_GunType,Emp_GunValid,Emp_DrivingLicence) values('" +
                    cmbdEmpId.Text.Trim() + "','" + txtemername.Text.Trim() + "','" + txtemeraddress.Text.Trim() + "','" + txtemerphone.Text.Trim() + "','" + txtemermobile.Text.Trim() + "','" + textBox25.Text.Trim() + "','" + textBox26.Text.Trim() + "','" + textBox27.Text.Trim() + "','" + textBox28.Text.Trim() + "','" + textBox29.Text.Trim() +
                    "','" + textBox30.Text.Trim() + "','" + Pre_location + "','" + textBox34.Text.Trim() + "','" + textBox35.Text.Trim() + "','" + textBox36.Text.Trim() + "','" + textBox37.Text.Trim() + "','" + textBox38.Text.Trim() + "','" + txtname1.Text.Trim() + "','" + txtAddress1.Text.Trim() + "','" + txtoccuption1.Text.Trim() +
                    "','" + txtphone1.Text.Trim() + "','" + txtemail1.Text.Trim() + "','" + txtname2.Text.Trim() + "','" + txtaddress2.Text.Trim() + "','" + txtoccupation2.Text.Trim() + "','" + txtphone2.Text.Trim() + "','" + txtemail2.Text.Trim() + "','" + txtservice.Text.ToString() + "','" + txtperiod.Text.Trim() + "','" +
                    txtranks.Text.Trim() + "','" + txticards.Text.Trim() + "','" + txtarms.Text.Trim() + "','" + txtpensionno.Text.Trim() + "','" + txtgunlicence.Text.Trim() + "','" + txtoparation.Text.Trim() + "','" + txtissue.Text.Trim() + "','" + txtgun.Text.Trim() + "','" + txtvalid.Text.Trim() + "','" + txtdrivinglicence.Text.Trim() + "')", edpcon.mycon, sqltran);
            }
            return boolStatus;
        }
        #endregion

        #region Existing Records Functions

        private Boolean ChekExRecordByEmpId()
        {
            Boolean boolStatus = false;

            DataTable dt = clsDataAccess.RunQDTbl("SELECT emp.*," +
  "(SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE (SlNo = emp.DesgId)) AS DesignationName," +
 "(SELECT JobType FROM tbl_Employee_JobType WHERE (SlNo = emp.JobType)) AS JobType FROM tbl_Employee_Mast AS emp WHERE (ID ='" + cmbdEmpId.Text.Trim() + "')");

            //"select emp.*,desg.DesignationName,job.JobType from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg, tbl_Employee_JobType job where emp.DesgId=desg.SlNo and emp.JobType=job.SlNo and emp.ID='" + cmbdEmpId.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }

            return boolStatus;
        }

        private Boolean ChekExRecordByEmpId_Update()
        {
            Boolean boolStatus = false;

            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Mast emp where (emp.ID='" + cmbdEmpId.Text.Trim() + "') and (emp.Company_id='"+cmbcopany.ReturnValue.Trim()+"')");
            //"select emp.*,desg.DesignationName,job.JobType from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg, tbl_Employee_JobType job where emp.DesgId=desg.SlNo and emp.JobType=job.SlNo and emp.ID='" + cmbdEmpId.Text.Trim() + "'", edpcon.mycon, sqltran);
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }




            return boolStatus;
        }

        private Boolean ChekAllExRecord()
        {

            Boolean boolStatus = false;
            String st = "Select count(*) from tbl_Employee_Mast";
                //"select emp.*,desg.DesignationName,(select SlNo from tbl_Employee_JobType where SlNo=emp.JobType ) AS JobType from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg where emp.DesgId=desg.SlNo ";
            DataTable dt = clsDataAccess.RunQDTbl(st);  //and emp.Session='" + cmbYear.Text.Trim() + "'
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }
            return boolStatus;
        }

        private void ClearLookUpTable(EDPComponent.ComboDialog edpcmb)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select Id,FirstName+' '+MiddleName+' '+LastName EmployeeName,' ' Designation from tbl_Employee_Mast where Session=' '");
            edpcmb.LookUpTable = dt;
        }
        private void GetFScan()
        {
             DataTable dt = clsDataAccess.RunQDTbl("SELECT lThumb,rThumb,lIndex,rIndex,lMiddle,rMiddle,"+
             "lRing,rRing,lfourth,rfourth,lFace,rFace,sign FROM tbl_employee_fscan WHERE (ID ='" + cmbdEmpId.Text.Trim() + "')");
             if (dt.Rows.Count > 0)
             {

                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["lThumb"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgLeft0.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["lThumb"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgLeft0.Image = bitmap;
                     }
                 }
                 catch { }
                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["rThumb"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgRight0.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["rThumb"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgRight0.Image = bitmap;
                     }
                 }
                 catch { }

                 //----------------------------------------------------------------
                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["lIndex"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgLeft1.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["lIndex"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgLeft1.Image = bitmap;
                     }
                 }
                 catch { }

                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["rIndex"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgRight1.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["rIndex"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgRight1.Image = bitmap;
                     }
                 }
                 catch { }
                 //----------------------------------------------------------------

                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["lMiddle"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgLeft2.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["lMiddle"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgLeft2.Image = bitmap;
                     }
                 }
                 catch { }
                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["rMiddle"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgRight2.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["rMiddle"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgRight2.Image = bitmap;
                     }
                 }
                 catch { }
                 //----------------------------------------------------------------

                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["lRing"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgLeft3.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["lRing"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgLeft3.Image = bitmap;
                     }
                 }
                 catch { }
                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["rRing"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgRight3.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["rRing"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgRight3.Image = bitmap;
                     }
                 }
                 catch { }
                 //----------------------------------------------------------------
                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["lfourth"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgLeft4.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["lfourth"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgLeft4.Image = bitmap;
                     }
                 }
                 catch { }

                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["rfourth"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgRight4.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["rfourth"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgRight4.Image = bitmap;
                     }
                 }
                 catch { }
                 //----------------------------------------------------------------

                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["lFace"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgLface.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["lFace"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgLface.Image = bitmap;
                     }
                 }
                 catch { }
                 //----------------------------------------------------------------

                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["rFace"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgRFace.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["rFace"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgRFace.Image = bitmap;
                     }
                 }
                 catch { }
                 //----------------------------------------------------------------

                 try
                 {
                     Imagepath = Convert.ToString(dt.Rows[0]["sign"]);
                     if (Imagepath != "")
                     {
                         MemoryStream stream = new MemoryStream();
                         imgSig.Image = null;
                         //context.Response.BinaryWrite((Byte[])dr[0]);
                         byte[] image = ((byte[])dt.Rows[0]["sign"]);
                         stream.Write(image, 0, image.Length);
                         //edpcon.Close();
                         Bitmap bitmap = new Bitmap(stream);
                         imgSig.Image = bitmap;
                     }
                 }
                 catch { }
                 //----------------------------------------------------------------

             }

        }

        private void GetPersonalDetails()
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT emp.*," +
  "(SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE (SlNo = emp.DesgId)) AS DesignationName," +
 "(SELECT JobType FROM tbl_Employee_JobType WHERE (SlNo = emp.JobType)) AS JobType"+
 ",isNull((SELECT DATEDIFF(month, max(cast(('01-'+ [Month]) as Date)), CAST( GETDATE() AS Date )) FROM tbl_Employee_SalaryGross where empid=emp.ID),0) lmon " +
 " FROM tbl_Employee_Mast AS emp WHERE (ID ='" + cmbdEmpId.Text.Trim() + "') and (Company_id='" + cmbcopany.ReturnValue.Trim() + "')");

            //clsDataAccess.RunQDTbl("select emp.*,desg.DesignationName,job.JobType Job from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg, tbl_Employee_JobType job where emp.DesgId=desg.SlNo and emp.JobType=job.SlNo and emp.ID='" + cmbdEmpId.Text.Trim() + "'"); // and emp.Session='" + cmbYear.Text.Trim() + "'
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Title"])))
                {
                    cmbEmpTitle_DropDown(cmbEmpTitle, new EventArgs());
                    cmbEmpTitle.SelectedItem = Convert.ToString(dt.Rows[0]["Title"]);
                }
                txtEmpFName.Text = Convert.ToString(dt.Rows[0]["FirstName"]);
                txtEmpMName.Text = Convert.ToString(dt.Rows[0]["MiddleName"]);
                txtEmpLName.Text = Convert.ToString(dt.Rows[0]["LastName"]);

                try
                {
                    txtPassword.Text = dt.Rows[0]["pass"].ToString();
                }
                catch { txtPassword.Text = cmbdEmpId.Text.Trim(); }
                if (dt.Rows[0]["mode_cwd"].ToString()=="1")
                {
                    rdbLv_full.Checked = true;
                }
                else if (dt.Rows[0]["mode_cwd"].ToString()=="2")
                {
                    rdbLv_half.Checked = true;
                }
                else
                {
                    rdbLv_normal.Checked = true;
                }

                try
                {
                    txt_blgrp.Text = Convert.ToString(dt.Rows[0]["blgrp"]);
                }
                catch
                {
                    txt_blgrp.Text = "";
                }
                try
                {
                    cmbDept.Text=dt.Rows[0]["dept"].ToString();

                }
                catch
                {
                    cmbDept.Text = "";
                }
                try
                {
                    if (Convert.ToString(dt.Rows[0]["salid"]) == "1")
                    {
                        chkFixed.Checked = true;
                    }
                    else
                    {
                        chkFixed.Checked = false;
                    }
                }
                catch { }
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FathTitle"])))
                {
                    cmbFatherTitle_DropDown(cmbFatherTitle, new EventArgs());
                    cmbFatherTitle.SelectedItem = Convert.ToString(dt.Rows[0]["FathTitle"]);
                }
                txtFathFN.Text = Convert.ToString(dt.Rows[0]["FathFN"]);
                txtFathMN.Text = Convert.ToString(dt.Rows[0]["FathMN"]);
                txtFathLN.Text = Convert.ToString(dt.Rows[0]["FathLN"]);


                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["MothTitle"])))
                {
                    cmbMotherTitle_DropDown(cmbMotherTitle, new EventArgs());
                    cmbMotherTitle.SelectedItem = Convert.ToString(dt.Rows[0]["MothTitle"]);
                }
                txtMothFN.Text = Convert.ToString(dt.Rows[0]["MothFN"]);
                txtMothMN.Text = Convert.ToString(dt.Rows[0]["MothMN"]);
                txtMotherLN.Text = Convert.ToString(dt.Rows[0]["MothLN"]);
                //-------------------------------------------------------------
                cmbStaus.SelectedItem = dt.Rows[0]["status"];
                lblStatus_old.Text = dt.Rows[0]["status"].ToString();
                txtoRemarks.Text = dt.Rows[0]["oRemarks"].ToString().Trim();
                txtRemarks.Text = dt.Rows[0]["remarks"].ToString().Trim();
                //=============================================================
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["HusTitle"])))
                {
                    cmbHusTitle_DropDown(cmbHusTitle, new EventArgs());
                    cmbHusTitle.SelectedItem = Convert.ToString(dt.Rows[0]["HusTitle"]);
                }
                txtHusFN.Text = Convert.ToString(dt.Rows[0]["HusFN"]);
                txtHusMN.Text = Convert.ToString(dt.Rows[0]["HusMN"]);
                txtHusLN.Text = Convert.ToString(dt.Rows[0]["HusLN"]);

                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DateOfBirth"])))
                {
                    try
                    {
                        dtpDOB.Text = Convert.ToString(dt.Rows[0]["DateOfBirth"]);
                    }
                    catch { dtpDOB.Text = "01/01/1900"; }
                }

                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Cast"])))
                {
                    //cmbCast_DropDown(cmbCast, new EventArgs());
                    cmbCast.Text = Convert.ToString(dt.Rows[0]["Cast"]).ToLower();
                }

                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["MaritalStatus"])))
                {
                    //cmbMaritalStatus_DropDown(cmbMaritalStatus, new EventArgs());
                    cmbMaritalStatus.Text = Convert.ToString(dt.Rows[0]["MaritalStatus"]).ToLower();
                }

                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Gender"])))
                {   
                    cmbGender.Text = Convert.ToString(dt.Rows[0]["Gender"]).ToUpper();
                }

                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DesignationName"])))
                {
                    cmbDesg.Text = Convert.ToString(dt.Rows[0]["DesignationName"]);
                }

                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["JobType1"])))
                {
                    cmbEmpType.Text = Convert.ToString(dt.Rows[0]["JobType1"]).ToLower();
                }

                txtPreAdd.Text = Convert.ToString(dt.Rows[0]["PresentAddress"]);
                txtPerAdd.Text = Convert.ToString(dt.Rows[0]["PermanentAddress"]);

                if (!String.IsNullOrEmpty(txtPreAdd.Text) && !String.IsNullOrEmpty(txtPerAdd.Text))
                {
                    if (txtPreAdd.Text.Trim() == txtPerAdd.Text.Trim())
                    {
                        chkSame.Checked = true;
                    }
                    else
                    {
                        chkSame.Checked = false;
                    }
                }
                else
                {
                    chkSame.Checked = false;
                }


                if (Information.IsNumeric(dt.Rows[0]["Company_id"]) == true)
                {
                    Company_id = Convert.ToInt32(dt.Rows[0]["Company_id"]);
                    DataTable dt_company = clsDataAccess.RunQDTbl("Select CO_NAME from Company where GCODE = '" + dt.Rows[0]["Company_id"] + "'");
                    if (dt_company.Rows.Count > 0)
                        cmbcopany.Text = Convert.ToString(dt_company.Rows[0]["CO_NAME"]);
                }

                if (Information.IsNumeric(dt.Rows[0]["Location_id"]) == true)
                {
                    Loc_id = Convert.ToInt32(dt.Rows[0]["Location_id"]);
                    DataTable dt_company = clsDataAccess.RunQDTbl("Select Location_Name from tbl_Emp_Location where Location_ID = '" + dt.Rows[0]["Location_id"] + "'");
                    if (dt_company.Rows.Count > 0)
                        cmblocation.Text = Convert.ToString(dt_company.Rows[0]["Location_Name"]);


                    DataTable dt_client = clsDataAccess.RunQDTbl("Select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName,Cliant_ID as ClientID from tbl_Emp_Location EL where Location_ID in(select Location_ID from Companywiseid_Relation where Company_ID=" + Company_id + " and Location_ID=" + dt.Rows[0]["Location_id"] + ")");
                    if (dt.Rows.Count > 0)
                    {
                        cmbClient.LookUpTable = dt_client;
                        cmbClient.ReturnIndex = 1;
                        try
                        {
                            cmbClient.Text = dt_client.Rows[0][0].ToString();
                        }
                        catch
                        {
                            cmbClient.Text = "";
                        }
                    }
                }

                DataTable dtps = clsDataAccess.RunQDTbl("SELECT  psid, PoliceStation, address + (case when dist!='' then ',' + dist else '' end )+ (case when state!='' then ',' + state else '' end ) + (case when zip!='' then ',' + zip else '' end ) address, jurisdiction FROM PS_Master where (psid = '" + dt.Rows[0]["psid"] + "')");

                if (dtps.Rows.Count == 1)
                {
                    txtPoliceStation.Text = dtps.Rows[0]["PoliceStation"].ToString();
                    txtPoliceStation.ReturnValue = dtps.Rows[0]["psid"].ToString();

                    txtPS_Address.Text = dtps.Rows[0]["address"].ToString();
                }
                else if (dtps.Rows.Count > 1)
                {
                    txtPoliceStation.LookUpTable = dtps;
                    txtPoliceStation.ReturnIndex = 0;
                    txtPoliceStation.PopUp();
                }
                else
                {
                    txtPoliceStation.ReturnValue = "0";
                    txtPoliceStation.Text = "";
                    txtPS_Address.Text = "";
                }


                txtSTD.Text = Convert.ToString(dt.Rows[0]["STD"]);
                txtPh.Text = Convert.ToString(dt.Rows[0]["Phone"]);
                txtEmailId.Text = Convert.ToString(dt.Rows[0]["EmailId"]);

                txtChest.Text = Convert.ToString(dt.Rows[0]["chest"]);
                txtComplexion.Text = Convert.ToString(dt.Rows[0]["complexion"]);
                txtHairColor.Text = Convert.ToString(dt.Rows[0]["haircolor"]);
                txtEyecolor.Text = Convert.ToString(dt.Rows[0]["eyecolor"]);
                txtIDMark.Text = Convert.ToString(dt.Rows[0]["Identity"]);

                txtPAN.Text = Convert.ToString(dt.Rows[0]["PANno"]);
                txtPassport.Text = Convert.ToString(dt.Rows[0]["PassportNo"]);

                txtaadhar.Text =Convert.ToString(dt.Rows[0]["aadhar"]);

                txtPF.Text = Convert.ToString(dt.Rows[0]["PF"]);
                txtPension.Text = Convert.ToString(dt.Rows[0]["PenssionNo"]);
                txtEDLI.Text = Convert.ToString(dt.Rows[0]["EDLI"]);
                txtESI.Text = Convert.ToString(dt.Rows[0]["ESIno"]);
                txtGMI.Text = Convert.ToString(dt.Rows[0]["GMIno"]);
                txtBankAC.Text = Convert.ToString(dt.Rows[0]["BankAcountNo"]);
                otherLanguage.Text = Convert.ToString(dt.Rows[0]["Language_Name"]);
                cmbYear.Text = Convert.ToString(dt.Rows[0]["Session"]);
                txtPfName.Text = Convert.ToString(dt.Rows[0]["pf_name"]);
                txtEsiName.Text = Convert.ToString(dt.Rows[0]["esi_name"]);
                txtbankAcName.Text = Convert.ToString(dt.Rows[0]["bankAc_name"]);
                
                //testless
                // Convert.ToDouble(txtmin.Text.Trim())
                if (Convert.ToString(dt.Rows[0]["EmpBasic"]) == "0")
                {
                    txtEmpBasic.Text = "";
                }
                else
                {
                    txtEmpBasic.Text = Convert.ToString(dt.Rows[0]["EmpBasic"]);
                }
                if (Convert.ToString(dt.Rows[0]["EmpSal"]) == "0")
                {
                    txtEmpSal.Text = "";
                }
                else
                {
                    txtEmpSal.Text = Convert.ToString(dt.Rows[0]["EmpSal"]);
                }

                //testless

                if (Convert.ToString(dt.Rows[0]["Mobile"]) == "0")
                {
                    txtMobile.Text = "";
                }
                else
                {
                    txtMobile.Text = Convert.ToString(dt.Rows[0]["Mobile"]);
                }

                if (Convert.ToString(dt.Rows[0]["STD"]) == "0")
                {
                    txtSTD.Text = "";
                }
                else
                {
                    txtSTD.Text = Convert.ToString(dt.Rows[0]["STD"]);
                }

                if (Convert.ToString(dt.Rows[0]["Phone"]) == "0")
                {
                    txtPh.Text = "";
                }
                else
                {
                    txtPh.Text = Convert.ToString(dt.Rows[0]["Phone"]);
                }

                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DateOfRetirement"])))
                {
                    dtpDOR.Text = Convert.ToString(dt.Rows[0]["DateOfRetirement"]);
                }

                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PenssionDate"])))
                {
                    dtpPenssion.Text = Convert.ToString(dt.Rows[0]["PenssionDate"]);
                }

                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DateOfJoining"])))
                {
                    try
                    {
                        dtpDOJ.Text = Convert.ToString(dt.Rows[0]["DateOfJoining"]);
                    }
                    catch {
                        dtpDOJ.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                }
                //Block Section & Salary Details(04.03.15) 
                //if (Information.IsNumeric(dt.Rows[0]["salid"]))
                //{
                //    DataTable dt2 = clsDataAccess.RunQDTbl("select SalaryCategory from tbl_Employee_SalaryStructure where slno=" + dt.Rows[0]["salid"]);
                //    if (dt2.Rows.Count > 0)
                //    {
                //        cmbSal_DropDown(cmbSal, new EventArgs());
                //        cmbSal.SelectedItem = Convert.ToString(dt2.Rows[0]["SalaryCategory"]);
                //        //cmbSal.Text = dt2.Rows[0]["SalaryCategory"].ToString().Trim();
                //    }

                //    //cmbSal.Text = clsEmployee.GetSalName(Convert.ToInt32(dt.Rows[0]["salid"]));
                //}
                //if (Information.IsNumeric(dt.Rows[0]["secid"]))
                //{
                //    DataTable dt2 = clsDataAccess.RunQDTbl("select section from tbl_Employee_SectionMaster where slno=" + dt.Rows[0]["secid"]);
                //    if (dt2.Rows.Count > 0)
                //    {
                //        cmbSection_DropDown(cmbSection, new EventArgs());
                //        cmbSection.SelectedItem = Convert.ToString(dt2.Rows[0]["section"]);
                //    }
                //    //cmbSection.Text = clsEmployee.GetSecName(Convert.ToInt32(dt.Rows[0]["secid"]));
                //}
                //End Section & Salary Details(04.03.15) 


                if (Information.IsNumeric(dt.Rows[0]["Presentstate"]))
                {
                    DataTable dt2 = clsDataAccess.RunQDTbl("select STATE_Name from StateMaster where STATE_CODE=" + dt.Rows[0]["Presentstate"]);
                    if (dt2.Rows.Count > 0)
                    {
                        cmbprestate_DropDown(cmbSection, new EventArgs());
                        cmbprestate.SelectedItem = Convert.ToString(dt2.Rows[0]["STATE_Name"]);
                    }
                }

                if (Information.IsNumeric(dt.Rows[0]["Permanentstate"]))
                {
                    DataTable dt2 = clsDataAccess.RunQDTbl("select STATE_Name from StateMaster where STATE_CODE=" + dt.Rows[0]["Permanentstate"]);
                    if (dt2.Rows.Count > 0)
                    {
                        cmbperstate_DropDown(cmbSection, new EventArgs());
                        cmbperstate.SelectedItem = Convert.ToString(dt2.Rows[0]["STATE_Name"]);
                    }
                }

                if (Information.IsNumeric(dt.Rows[0]["Presentcountry"]))
                {
                    DataTable dt2 = clsDataAccess.RunQDTbl("select Country_Name from Country where Country_CODE=" + dt.Rows[0]["Presentcountry"]);
                    if (dt2.Rows.Count > 0)
                    {
                        cmbprecountry_DropDown(cmbSection, new EventArgs());
                        cmbprecountry.SelectedItem = Convert.ToString(dt2.Rows[0]["Country_Name"]);
                    }
                }

                if (Information.IsNumeric(dt.Rows[0]["Permanentcountry"]))
                {
                    DataTable dt2 = clsDataAccess.RunQDTbl("select Country_Name from Country where Country_CODE=" + dt.Rows[0]["Permanentcountry"]);
                    if (dt2.Rows.Count > 0)
                    {
                        cmbpercountry_DropDown(cmbSection, new EventArgs());
                        cmbpercountry.SelectedItem = Convert.ToString(dt2.Rows[0]["Country_Name"]);
                    }
                }


                txtprebuilding.Text = Convert.ToString(dt.Rows[0]["Presentbuilding"]);
                txtprestreet.Text = Convert.ToString(dt.Rows[0]["Presentstreet"]);
                txtprearea.Text = Convert.ToString(dt.Rows[0]["Presentareia"]);
                txtpretown.Text = Convert.ToString(dt.Rows[0]["Presentcity"]);
                txtprepin.Text = Convert.ToString(dt.Rows[0]["Presentpin"]);
                txtperbuilding.Text = Convert.ToString(dt.Rows[0]["Permanentbuilding"]);
                txtperstreet.Text = Convert.ToString(dt.Rows[0]["Permanentstreet"]);
                txtperarea.Text = Convert.ToString(dt.Rows[0]["Permanentareia"]);
                txtpertown.Text = Convert.ToString(dt.Rows[0]["Permanentcity"]);
                txtperpin.Text = Convert.ToString(dt.Rows[0]["Permanentpin"]);


                if (!String.IsNullOrEmpty(txtperstreet.Text) && !String.IsNullOrEmpty(txtprestreet.Text))
                {
                    if (txtperstreet.Text.Trim() == txtprestreet.Text.Trim())
                    {
                        chkSame.Checked = true;
                    }
                    else
                    {
                        chkSame.Checked = false;
                    }
                }
                else
                {
                    chkSame.Checked = false;
                }

                txtweight.Text = Convert.ToString(dt.Rows[0]["Weight"]);
                txtheight.Text = Convert.ToString(dt.Rows[0]["Height"]);
                txtheight.Text = txtheight.Text.Replace("~", "'");
                cmbreligion.Text = Convert.ToString(dt.Rows[0]["Religion"]);
                otherLanguage.Text = Convert.ToString(dt.Rows[0]["Language_Name"]);
                comdocumet1.Text = Convert.ToString(dt.Rows[0]["Document_Titel"]);
                comdocumet2.Text = Convert.ToString(dt.Rows[0]["Document_Titel2"]);
                comdocumet3.Text = Convert.ToString(dt.Rows[0]["Document_Titel3"]);

                txtbank.Text = Convert.ToString(dt.Rows[0]["Bank_Name"]);
                txtbranch.Text = Convert.ToString(dt.Rows[0]["Branch_Name"]);
                cmbtype.Text = Convert.ToString(dt.Rows[0]["Bank_AC_Type"]);

                if (Convert.ToString(dt.Rows[0]["PF_Deduction"]) == "1")
                    chk_pfdeduction.Checked = true;
                else
                    chk_pfdeduction.Checked = false;

                if (Convert.ToString(dt.Rows[0]["ESI_Deduction"]) == "1")
                    chk_esideduction.Checked = true;
                else
                    chk_esideduction.Checked = false;

                if (Convert.ToString(dt.Rows[0]["active"]) == "1")
                {
                    chk_active.Checked = true;

                    if (Convert.ToInt32(dt.Rows[0]["lmon"]) >= 1 && Convert.ToInt32(dt.Rows[0]["lmon"]) <= 3)
                    {
                        lblStatus.Visible = true;

                        lblStatus.Text = "Pre-Dormant";
                        lblStatus.ForeColor = Color.Yellow;
                    }
                    else if (Convert.ToInt32(dt.Rows[0]["lmon"]) > 3)
                    {
                        lblStatus.Visible = true;
                        lblStatus.Text = "Dormant";
                        lblStatus.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblStatus.Visible = true;
                        lblStatus.Text = "Active";
                        lblStatus.ForeColor = Color.Green;
                    }
                    
                }
                else
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "InActive";
                    lblStatus.ForeColor = Color.Red;
                    chk_active.Checked = false;
                }


                if (Convert.ToString(dt.Rows[0]["pay_mod"]) == "1")
                {
                    rdbTrans_Bank.Checked = true;
                }
                else if (Convert.ToString(dt.Rows[0]["pay_mod"]) == "3")
                {
                    rdbTrans_cheque.Checked = true;
                }
                else
                {
                    rdbTrans_Cash.Checked = true;
                }

                string[] s = new string[] { };
                s = Convert.ToString(dt.Rows[0]["Language_Bengali"]).Split(',');
                if (s.Length > 0 && s[0] == "1")
                    chebenread.Checked = true;
                if (s.Length > 1 && s[1] == "1")
                    chebenwrite.Checked = true;
                if (s.Length > 2 && s[2] == "1")
                    chebenspeak.Checked = true;
                s = null;
                s = Convert.ToString(dt.Rows[0]["Language_Hindi"]).Split(',');
                if (s.Length > 0 && s[0] == "1")
                    chehinread.Checked = true;
                if (s.Length > 1 && s[1] == "1")
                    chehinwrite.Checked = true;
                if (s.Length > 2 && s[2] == "1")
                    chehinspeak.Checked = true;
                s = null;
                s = Convert.ToString(dt.Rows[0]["Language_English"]).Split(',');
                if (s.Length > 0 && s[0] == "1")
                    cheengread.Checked = true;
                if (s.Length > 1 && s[1] == "1")
                    cheengwrite.Checked = true;
                if (s.Length > 2 && s[2] == "1")
                    cheengspeak.Checked = true;
                s = null;
                s = Convert.ToString(dt.Rows[0]["Language_Other"]).Split(',');
                if (s.Length > 0 && s[0] == "1")
                    cheotherread.Checked = true;
                if (s.Length > 1 && s[1] == "1")
                    cheotherwrite.Checked = true;
                if (s.Length > 2 && s[2] == "1")
                    cheotherspeak.Checked = true;


                try
                {
                    otherLanguage2.Text = Convert.ToString(dt.Rows[0]["Language_Name2"]);

                    s = null;
                    s = Convert.ToString(dt.Rows[0]["Language_Other2"]).Split(',');
                    if (s.Length > 0 && s[0] == "1")
                        cheother2read.Checked = true;
                    if (s.Length > 1 && s[1] == "1")
                        cheother2write.Checked = true;
                    if (s.Length > 2 && s[2] == "1")
                        cheother2speak.Checked = true;



                }
                catch { }

                try
                {
                    Imagepath = Convert.ToString(dt.Rows[0]["Empimage"]);
                    if (Imagepath != "")
                    {
                        
                            MemoryStream stream = new MemoryStream();
                            pictureimport.Image = null;
                            //context.Response.BinaryWrite((Byte[])dr[0]);
                            byte[] image = ((byte[])dt.Rows[0]["Empimage"]);
                            stream.Write(image, 0, image.Length);
                            //edpcon.Close();
                            try
                            {
                            Bitmap bitmap = new Bitmap(stream);
                            pictureimport.Image = bitmap;
                            ////pdfbox_doc.Visible = false;
                            //this.pdfbox_doc.LoadFile(bitmap);
                            }
                            catch
                            {

                                var input = ((byte[])dt.Rows[0]["Empimage"]).ToString();
                                ////  this.pdfbox_doc.LoadFile(input);
                                //// pdfbox_doc.Visible = true;

                                ////byte[] fileData = (byte[])dr.GetValue(0);


                                ////// write bytes to disk as file
                                ////using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                                ////{
                                ////    // use a binary writer to write the bytes to disk
                                ////    using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                                ////    {
                                ////        bw.Write(fileData);
                                ////        bw.Close();
                                ////    }
                                ////}
                            
                            
                            }
                    }
                }
                catch { }

                try
                {
                    dt_document1 = clsDataAccess.RunQDTbl("select ID,Document_Type as document_type,Document_Image as Image,null as new,Temp_Image as Image1 from tbl_Emp_DocumentImage where ID='" + cmbdEmpId.Text.Trim() + "'");
                    DataTable dt1 = clsDataAccess.RunQDTbl("select Document_Image from tbl_Emp_DocumentImage where ID='" + cmbdEmpId.Text.Trim() + "' and Document_Type='1' ");
                    try
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            Imagedocument = Convert.ToString(dt1.Rows[0]["Document_Image"]);
                            if (Imagedocument != "")
                            {
                                MemoryStream stream1 = new MemoryStream();
                                picturedocument.Image = null;
                                //context.Response.BinaryWrite((Byte[])dr[0]);
                                byte[] image = ((byte[])dt1.Rows[0]["Document_Image"]);
                                stream1.Write(image, 0, image.Length);
                                //edpcon.Close();
                                Bitmap bitmap1 = new Bitmap(stream1);
                                picturedocument.Image = bitmap1;
                                label35.Text = "1";
                                label36.Text = dt1.Rows.Count.ToString();
                            }
                        }
                    }
                    catch { }

                    dt1 = clsDataAccess.RunQDTbl("select Document_Image from tbl_Emp_DocumentImage where ID='" + cmbdEmpId.Text.Trim() + "' and Document_Type='2' ");
                    try
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            Imagedocument2 = Convert.ToString(dt1.Rows[0]["Document_Image"]);
                            if (Imagedocument2 != "")
                            {
                                MemoryStream stream = new MemoryStream();
                                picturedocument.Image = null;
                                //context.Response.BinaryWrite((Byte[])dr[0]);
                                byte[] image = ((byte[])dt1.Rows[0]["Document_Image"]);
                                stream.Write(image, 0, image.Length);
                                //edpcon.Close();
                                Bitmap bitmap = new Bitmap(stream);
                                picturedocument.Image = bitmap;
                                label149.Text = "1";
                                label148.Text = dt1.Rows.Count.ToString();
                            }
                        }
                    }
                    catch { }
                    dt1 = clsDataAccess.RunQDTbl("select Document_Image from tbl_Emp_DocumentImage where ID='" + cmbdEmpId.Text.Trim() + "' and Document_Type='3' ");
                    try
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            Imagedocument3 = Convert.ToString(dt1.Rows[0]["Document_Image"]);
                            if (Imagedocument3 != "")
                            {
                                MemoryStream stream = new MemoryStream();
                                picturedocument.Image = null;
                                //context.Response.BinaryWrite((Byte[])dr[0]);
                                byte[] image = ((byte[])dt1.Rows[0]["Document_Image"]);
                                stream.Write(image, 0, image.Length);
                                //edpcon.Close();
                                Bitmap bitmap = new Bitmap(stream);
                                picturedocument.Image = bitmap;
                                label153.Text = "1";
                                label152.Text = dt1.Rows.Count.ToString();
                            }
                        }
                    }
                    catch { }
                }
                catch { }



                //Imagedocument = Convert.ToString(dt.Rows[0]["Empdocimage"]);
                ////Imagepath = Convert.ToString(dt.Rows[0]["Empimage"]);
                ////texpath.Text = Imagepath;
                ////if (Imagepath != "")
                ////    pictureimport.Image = new Bitmap(Imagepath);
                //if (Imagedocument != "")
                //{
                //    label35.Text = "1";
                //    string[] st = new string[] { };
                //    st = Imagedocument.Split(',');
                //    textdocument.Text = st[0];
                //    label36.Text = Convert.ToString(st.Length);
                //    picturedocument.Image = new Bitmap(st[0]);
                //}
                //Imagedocument2 = Convert.ToString(dt.Rows[0]["Empdocimage2"]);
                //if (Imagedocument2 != "")
                //{
                //    label149.Text = "1";
                //    string[] st = new string[] { };
                //    st = Imagedocument2.Split(',');
                //    textdocument2.Text = st[0];
                //    label148.Text = Convert.ToString(st.Length);
                //    picturedocument.Image = new Bitmap(st[0]);
                //}
                //Imagedocument3 = Convert.ToString(dt.Rows[0]["Empdocimage3"]);
                //if (Imagedocument3 != "")
                //{
                //    label53.Text = "1";
                //    string[] st = new string[] { };
                //    st = Imagedocument3.Split(',');
                //    textdocument3.Text = st[0];
                //    label152.Text = Convert.ToString(st.Length);
                //    picturedocument.Image = new Bitmap(st[0]);
                //}
            }
        }

        private void GetQualificationDetails()
        {
            ClearQualificationDetails();
            DataTable dt = clsDataAccess.RunQDTbl("select (case when qu.Qualification='' then '-' else (select Quali_Name from Qualification_Master where Quali_Code=qu.Qualification) end) as Qualification,qu.University,qu.YearOfPassing,qu.Percentage,qu.SlNo from tbl_Employee_QualificationDetails qu where qu.ID='" + cmbdEmpId.Text.Trim() + "'");
            //"select qm.Quali_Name as Qualification,qu.University,qu.YearOfPassing,qu.Percentage,qu.SlNo from tbl_Employee_QualificationDetails qu,Qualification_Master qm where qu.ID='" + cmbdEmpId.Text.Trim() + "' and qu.Qualification = qm.Quali_Code");
            if (dt.Rows.Count > 0)
            {
                dgQualification.DataSource = dt;
            }
        }

        private void GetFamilyDetails()
        {
            ClearFamilyDetails();
            DataTable dt = clsDataAccess.RunQDTbl("select Name,(select Relation_Name from Relation_Master where Relation_Code=fd.Relation) as Relation,dob as DOB,Age,Dependent,SlNo,aadhar as AADHAR from tbl_Employee_FamilyDetails fd where (ID='" + cmbdEmpId.Text.Trim() + "') and (Relation<>'-' or Relation='')");
             //"select fd.Name,fm.Relation_Name as Relation,fd.dob as DOB,fd.Age,fd.Dependent,fd.SlNo,fd.aadhar as AADHAR from tbl_Employee_FamilyDetails fd , Relation_Master fm where fd.ID='" + cmbdEmpId.Text.Trim() + "' and fd.Relation=fm.Relation_Code and (fd.Relation<>'-' or fd.Relation='')");
            if (dt.Rows.Count > 0)
            {
                dgFamily.DataSource = dt;
            }
        }

        private void GetempDetails()
        {

            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Other_Reff where ID='" + cmbdEmpId.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {

                txtemername.Text = Convert.ToString(dt.Rows[0]["Emarg_Name"]);
                txtemeraddress.Text = Convert.ToString(dt.Rows[0]["Emarg_Address"]);
                txtemerphone.Text = Convert.ToString(dt.Rows[0]["Emarg_Tele"]);
                txtemermobile.Text = Convert.ToString(dt.Rows[0]["Emarg_Mobile"]);
                textBox25.Text = Convert.ToString(dt.Rows[0]["Emp_Achiev"]);
                textBox26.Text = Convert.ToString(dt.Rows[0]["Emp_Club"]);
                textBox27.Text = Convert.ToString(dt.Rows[0]["Emp_Association"]);
                textBox28.Text = Convert.ToString(dt.Rows[0]["Emp_Org"]);
                textBox29.Text = Convert.ToString(dt.Rows[0]["Emp_Notic"]);
                textBox30.Text = Convert.ToString(dt.Rows[0]["Emp_Join_refer"]);
                textBox34.Text = Convert.ToString(dt.Rows[0]["Emp_Criminal_Rec"]);
                //textBox31.Text = Convert.ToString(dt.Rows[0]["Emp_Preferlocation"]);
                string[] s = new string[] { };
                s = Convert.ToString(dt.Rows[0]["Emp_Preferlocation"]).Split(',');
                if (s.Length > 0)
                    textBox31.Text = s[0];
                if (s.Length > 1)
                    textBox32.Text = s[1];
                if (s.Length > 2)
                    textBox33.Text = s[2];

                textBox35.Text = Convert.ToString(dt.Rows[0]["Emp_illness"]);
                textBox36.Text = Convert.ToString(dt.Rows[0]["Emp_Interview_Details"]);
                textBox37.Text = Convert.ToString(dt.Rows[0]["Emp_OtherInformation"]);
                textBox38.Text = Convert.ToString(dt.Rows[0]["Emp_Expected_Salary"]);
                txtname1.Text = Convert.ToString(dt.Rows[0]["Ref_Name"]);
                txtAddress1.Text = Convert.ToString(dt.Rows[0]["Ref_Address"]);
                txtoccuption1.Text = Convert.ToString(dt.Rows[0]["Ref_Occupation"]);
                txtphone1.Text = Convert.ToString(dt.Rows[0]["Ref_Phone"]);
                txtemail1.Text = Convert.ToString(dt.Rows[0]["Ref_Email"]);
                txtname2.Text = Convert.ToString(dt.Rows[0]["Ref_Name1"]);
                txtaddress2.Text = Convert.ToString(dt.Rows[0]["Ref_Address1"]);
                txtoccupation2.Text = Convert.ToString(dt.Rows[0]["Ref_Occupation1"]);
                txtphone2.Text = Convert.ToString(dt.Rows[0]["Ref_Phone1"]);
                txtemail2.Text = Convert.ToString(dt.Rows[0]["Ref_Email1"]);
                txtservice.Text = Convert.ToString(dt.Rows[0]["Emp_Service"]);
                txtperiod.Text = Convert.ToString(dt.Rows[0]["Emp_Period_Service"]);
                txtranks.Text = Convert.ToString(dt.Rows[0]["Emp_Rank"]);
                txticards.Text = Convert.ToString(dt.Rows[0]["Emp_ICard_No"]);
                txtarms.Text = Convert.ToString(dt.Rows[0]["Emp_Arms"]);
                txtpensionno.Text = Convert.ToString(dt.Rows[0]["Emp_Pension_No"]);
                txtgunlicence.Text = Convert.ToString(dt.Rows[0]["Emp_GunLicence"]);
                txtoparation.Text = Convert.ToString(dt.Rows[0]["Emp_Operation_Area"]);
                txtissue.Text = Convert.ToString(dt.Rows[0]["Emp_issue"]);
                txtgun.Text = Convert.ToString(dt.Rows[0]["Emp_GunType"]);
                txtvalid.Text = Convert.ToString(dt.Rows[0]["Emp_GunValid"]);
                txtdrivinglicence.Text = Convert.ToString(dt.Rows[0]["Emp_DrivingLicence"]);
            }
        }

        #endregion

        #region Delete Record

        private void DeleteRecord()
        {
            Boolean boolStatus = false;

            if (String.IsNullOrEmpty(Convert.ToString(txtSTD.Text)))
            {
                txtSTD.Text = "0";
            }

            if (String.IsNullOrEmpty(Convert.ToString(txtPh.Text)))
            {
                txtPh.Text = "0";
            }

            if (String.IsNullOrEmpty(Convert.ToString(txtMobile.Text)))
            {
                txtMobile.Text = "0";
            }

            /*-----------------------------------------------------------Edited by Dwipraj Dutta - 13/07/2017(5:35PM)-------------------------------------------------*/
            /*Boolean boolInsert = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_DeletedEmp (ID,Title,FirstName,MiddleName,LastName,FathTitle,FathFN,FathMN,FathLN,MothTitle,MothFN,MothMN,MothLN,HusTitle,HusFN,HusMN,HusLN,DateOfBirth,Cast,MaritalStatus,Gender,DesgId,JobType,PresentAddress,PermanentAddress,STD,Phone,Mobile,PANno,PassportNo,PF,PenssionNo,EDLI,ESIno,BankAcountNo,DateOfJoining,DateOfRetirement,Session,GMIno) values('" + cmbdEmpId.Text.Trim() + "','" + cmbEmpTitle.Text.Trim() + "','" + txtEmpFName.Text.Trim() + "','" + txtEmpMName.Text.Trim() + "','" + txtEmpLName.Text.Trim() + "','" + cmbFatherTitle.Text.Trim() + "','" + txtFathFN.Text.Trim() + "','" + txtFathMN.Text.Trim() + "','" + txtFathLN.Text.Trim() + "','" + cmbMotherTitle.Text.Trim() + "','" + txtMothFN.Text.Trim() + "','" + txtMothMN.Text.Trim() + "','" + txtMotherLN.Text.Trim() + "','" + cmbHusTitle.Text.Trim() + "','" + txtHusFN.Text.Trim() + "','" + txtHusMN.Text.Trim() + "','" + txtHusLN.Text.Trim() + "','" + edpcmn.getSqlDateStr(dtpDOB.Value) + "','" + cmbCast.Text.Trim() + "','" + cmbMaritalStatus.Text.Trim() + "','" + cmbGender.Text.Trim() + "'," + clsEmployee.GetDesgId(cmbDesg.Text.Trim()) + "," + clsEmployee.GetJobTypeId(cmbEmpType.Text.Trim()) + ",'" + txtPreAdd.Text.Trim() + "','" + txtPerAdd.Text.Trim() + "'," + txtSTD.Text.Trim() + "," + txtPh.Text.Trim() + "," + txtMobile.Text.ToString() + ",'" + txtPAN.Text.Trim() + "','" + txtPassport.Text.Trim() + "','" + txtPF.Text.Trim() + "','" + txtPension.Text.Trim() + "','" + txtEDLI.Text.Trim() + "','" + txtESI.Text.Trim() + "','" + txtBankAC.Text.Trim() + "','" + edpcmn.getSqlDateStr(dtpDOJ.Value) + "','" + edpcmn.getSqlDateStr(dtpDOR.Value) + "','" + cmbYear.Text.Trim() + "','" + txtGMI.Text.Trim() + "')");
            if (boolInsert)
            {
                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Mast set active=0 where (ID='" + cmbdEmpId.Text.Trim() + "')");
                //boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Mast where ID='" + cmbdEmpId.Text.Trim() + "' and Session='" + cmbYear.Text.Trim() + "'");
                //boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Other_Reff where ID='" + cmbdEmpId.Text.Trim() + "'");
                //boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_QualificationDetails where ID='" + cmbdEmpId.Text.Trim() + "'");
                //boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_FamilyDetails where ID='" + cmbdEmpId.Text.Trim() + "'");
                edpcom.InsertMidasLog(this, true, "del", cmbdEmpId.Text.Trim());
            }*/
            boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Mast set active=0 where (ID='" + cmbdEmpId.Text.Trim() + "')");
            /*-----------------------------------------------------------------Editing End For 13/07/2017(5:35PM)------------------------------------------------------*/
            if (boolStatus)
            {
                ClearAll();
                cmbdEmpId.Text = get_EmpNo();
                ERPMessageBox.ERPMessage.Show("Employee Details Deleted Successfully");
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed to Delete Employee Details");
            }
        }

        #endregion

        #region Clear Controls

        private void ClearPersonalDetailsExceptEmpId()
        {
            lblStatus.Text = "";
            Loc_id = 0; Company_id = 0;
            //cmbdEmpId.Text = "";
            cmbcopany.Text = "";
            cmblocation.Text = "";
            cmbClient.Text = "";
            cmbStaus.SelectedItem = 1;
            txtRemarks.Text = "";
            txtoRemarks.Text = "";
            cmbEmpTitle.Items.Clear();
            txtEmpFName.Text = "";
            txtEmpMName.Text = "";
            txtEmpLName.Text = "";
            cmbFatherTitle.Items.Clear();
            txtFathFN.Text = "";
            txtFathMN.Text = "";
            txtFathLN.Text = "";
            cmbMotherTitle.Items.Clear();
            txtMothFN.Text = "";
            txtMothMN.Text = "";
            txtMotherLN.Text = "";
            cmbHusTitle.Items.Clear();
            txtHusFN.Text = "";
            txtHusMN.Text = "";
            txtHusLN.Text = "";
            cmbCast.Items.Clear();
            cmbGender.Items.Clear();
            cmbDesg.Text = "";
            cmbEmpType.Text = "";
            cmbMaritalStatus.Items.Clear();
            dtpDOB.Text = Convert.ToString(System.DateTime.Now);
            txtPreAdd.Text = "";
            txtPerAdd.Text = "";
            txtSTD.Text = "";
            txtPh.Text = "";
            chkSame.Checked = false;
            txtMobile.Text = "";
            txtEmailId.Text = "";
            txtPAN.Text = "";
            txtPassport.Text = "";
            txtPF.Text = "";
            txtPension.Text = "";
            txtEDLI.Text = "";
            txtESI.Text = "";
            txtGMI.Text = "";
            txtBankAC.Text = "";
            dtpDOR.Value = System.DateTime.Now;
            dtpDOJ.Value = System.DateTime.Now;
            dtpPenssion.Value = System.DateTime.Now;

            txtprebuilding.Text = "";
            txtprestreet.Text = "";
            txtprearea.Text = "";
            txtpretown.Text = "";
            txtprepin.Text = "";
            txtperbuilding.Text = "";
            txtperstreet.Text = "";
            txtperarea.Text = "";
            txtpertown.Text = "";
            txtperpin.Text = "";
            txtweight.Text = "";
            txtheight.Text = "";
            cmbreligion.SelectedIndex = -1;
            otherLanguage.Text = "";
            otherLanguage2.Text = "";
            txtEmpBasic.Text = "";
            txtEmpSal.Text = "";

            comdocumet1.SelectedIndex = -1;
            comdocumet2.SelectedIndex = -1;
            comdocumet3.SelectedIndex = -1;

            chebenread.Checked = false;
            chebenwrite.Checked = false;
            chebenspeak.Checked = false;
            chehinread.Checked = false;
            chehinwrite.Checked = false;
            chehinspeak.Checked = false;
            cheengread.Checked = false;
            cheengwrite.Checked = false;
            cheengspeak.Checked = false;
            cheotherread.Checked = false;
            cheotherwrite.Checked = false;
            cheotherspeak.Checked = false;

            cheother2read.Checked = false;
            cheother2write.Checked = false;
            cheother2speak.Checked = false;

            chk_pfdeduction.Checked = false;
            chk_esideduction.Checked = false;

            cmbprestate.Items.Clear();
            cmbprecountry.Items.Clear();
            cmbperstate.Items.Clear();
            cmbpercountry.Items.Clear();
            dt_document1.Rows.Clear();
            cmbDept.Text = "";
            cmbreligion.Items.Clear();
            cmbreligion.Items.Add("Hindu");
            cmbreligion.Items.Add("Muslim");
            cmbreligion.Items.Add("Sikh");
            cmbreligion.Items.Add("christian");
            cmbreligion.Items.Add("Others");
            try
            {
                DataTable dt_rel = clsDataAccess.RunQDTbl("select distinct(ltrim(rtrim(Religion))) from  tbl_Employee_Mast where (upper(Religion) not in ('Hindu','Muslim','Sikh','christian','Others',''))");
                if (dt_rel.Rows.Count > 0)
                {
                    for (int idx = 0; idx < dt_rel.Rows.Count; idx++)
                    {

                        cmbreligion.Items.Add(dt_rel.Rows[idx][0].ToString());
                    }
                }
            }
            catch { }


            cmbMaritalStatus.Items.Clear();
            cmbMaritalStatus.Items.Add("Single");
            cmbMaritalStatus.Items.Add("Married");
            cmbMaritalStatus.Items.Add("Unmarried");
            cmbMaritalStatus.Items.Add("Divorced");
            cmbMaritalStatus.Items.Add("Widowed");
            try
            {
                DataTable dt_status = clsDataAccess.RunQDTbl("select distinct(ltrim(rtrim(MaritalStatus))) from  tbl_Employee_Mast where (upper(MaritalStatus) not in ('SINGLE','MARRIED','UNMARRIED','DIVORCED','WIDOWED',''))");
                if (dt_status.Rows.Count > 0)
                {
                    for (int idx = 0; idx < dt_status.Rows.Count; idx++)
                    {

                        cmbMaritalStatus.Items.Add(dt_status.Rows[idx][0].ToString());
                    }
                }
            }
            catch { }
            cmbGender.Items.Clear();
            cmbGender.Items.Add("MALE");
            cmbGender.Items.Add("FEMALE");
            cmbGender.Items.Add("OTHER");


            cmbCast.Items.Clear();
            cmbCast.Items.Add("General");
            cmbCast.Items.Add("OBC");
            cmbCast.Items.Add("SC");
            cmbCast.Items.Add("ST");
            try
            {
                DataTable dt_cast = clsDataAccess.RunQDTbl("select distinct(ltrim(rtrim(cast))) from tbl_Employee_Mast where (upper(cast) not in ('General','OBC','SC','ST',''))");
                if (dt_cast.Rows.Count > 0)
                {
                    for (int idx = 0; idx < dt_cast.Rows.Count; idx++)
                    {

                        cmbCast.Items.Add(dt_cast.Rows[idx][0].ToString());
                    }
                }
            }
            catch { }

            //lblPenssionAge.Text = "";
        }

        private void ClearPersonalDetails()
        {
            lbl_msg_fb.Visible = false;
            lbl_fb_click.Text = "Click +";
            lblCashMode_msg.Visible = false;

            lblStatus.Text = "";
            lblStatus.Visible = false;


            Loc_id = 0; Company_id = 0;
            cmbcopany.Text = "";
            cmblocation.Text = "";
            cmbClient.Text = "";
            cmbdEmpId.ReadOnly = false;
            cmbdEmpId.Enabled = true;
            chk_active.Checked = true;
            chkFixed.Checked = false;
            otherLanguage.Text = "";
            otherLanguage2.Text = "";
            txtPassword.Text = "";
            chkShowPass.Checked = false;
            string[] lang = clsDataAccess.EMPLang().Split('|');
                //clsDataAccess.Emp_lang().Split('|');
            if (lang.Length == 1)
            {
                try
                {
                    if (lang[0].ToString().Trim() == "")
                    {
                        MessageBox.Show("Check 'lang_config' File");
                        lbl_lang1.Text = "";
                        lbl_lang2.Text = "";
                        lbl_lang3.Text = "";
                        otherLanguage.Text = "";
                        otherLanguage2.Text = "";
                    }
                    else
                    {
                        lbl_lang1.Text = lang[0].ToString();

                    }
                }
                catch { }
            }
            else
            {
                lbl_lang1.Text = lang[0].ToString();
                lbl_lang2.Text = lang[1].ToString();
                lbl_lang3.Text = lang[2].ToString();
                if (lang.Length == 4)
                {
                    otherLanguage.Text = lang[3].ToString();
                    otherLanguage2.Text = "";
                }
                else if (lang.Length == 5)
                {
                    otherLanguage.Text = lang[3].ToString();
                    otherLanguage2.Text = lang[4].ToString();

                }
            }
            //generate year
            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
            //

            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }
            //

            txtPfName.Text = "";
            txtEsiName.Text = "";
            txtbankAcName.Text = "";

            txtaadhar.Text = "";
            txtComplexion.Text = "";
            txtChest.Text = "";
            txtIDMark.Text = "";
            txtHairColor.Text = "";
            txtEyecolor.Text = "";
            

            cmbdEmpId.BackColor = Color.White;
            cmbdEmpId.Text = "";
            cmbEmpTitle.Items.Clear();
            cmbEmpTitle.Text = "";
            txtbank.Text = "";
            txtbranch.Text = "";
            cmbtype.Text = "";
            txtEmpFName.Text = "";
            txtEmpMName.Text = "";
            txtEmpLName.Text = "";
            cmbFatherTitle.Items.Clear();
            cmbFatherTitle.Text = "";
            txtFathFN.Text = "";
            txtFathMN.Text = "";
            txtFathLN.Text = "";
            cmbMotherTitle.Items.Clear();
            cmbMotherTitle.Text = "";
            txtMothFN.Text = "";
            txtMothMN.Text = "";
            txtMotherLN.Text = "";
            cmbHusTitle.Items.Clear();
            cmbHusTitle.Text = "";
            txtHusFN.Text = "";
            txtHusMN.Text = "";
            txtHusLN.Text = "";
            cmbCast.Items.Clear();
           
            cmbDesg.Text = "";
            cmbEmpType.Text = "";

            cmbEmpType.PopUp();

            txtPoliceStation.Text = "";
            txtPS_Address.Text = "";

            dtpDOB.Text = Convert.ToString(System.DateTime.Now);
            txtPreAdd.Text = "";
            txtPerAdd.Text = "";
            txtSTD.Text = "";
            txtPh.Text = "";
            chkSame.Checked = false;
            txtMobile.Text = "";
            txtEmailId.Text = "";
            txtPAN.Text = "";
            txtPassport.Text = "";
            txtPF.Text = "";
            txtPension.Text = "";
            txtEDLI.Text = "";
            txtESI.Text = "";
            txtGMI.Text = "";
            txtBankAC.Text = "";
            dtpDOJ.Text = Convert.ToString(System.DateTime.Now);
            dtpDOR.Text = Convert.ToString(System.DateTime.Now);
            //lblPenssionAge.Text = "";
            dtpPenssion.Value = System.DateTime.Now;
            //cmbSal.SelectedIndex = -1;cmbSection.SelectedIndex = -1;
            txtEmpBasic.Text = "0";//"";
            txtEmpSal.Text = "0"; //"";
            txtprebuilding.Text = "";
            txtprestreet.Text = "";
            txtprearea.Text = "";
            txtpretown.Text = "";
            txtprepin.Text = "";
            txtperbuilding.Text = "";
            txtperstreet.Text = "";
            txtperarea.Text = "";
            txtpertown.Text = "";
            txtperpin.Text = "";
            txtweight.Text = "";
            txtheight.Text = "";
            
           
            cmbStaus.SelectedItem = 1;
            
            txtRemarks.Text = "";
            txtoRemarks.Text = "";
            cmbDept.Text = "";

            chebenread.Checked = false;
            chebenwrite.Checked = false;
            chebenspeak.Checked = false;
            chehinread.Checked = false;
            chehinwrite.Checked = false;
            chehinspeak.Checked = false;
            cheengread.Checked = false;
            cheengwrite.Checked = false;
            cheengspeak.Checked = false;
            cheotherread.Checked = false;
            cheotherwrite.Checked = false;
            cheotherspeak.Checked = false;

            cmbreligion.Items.Clear();
            cmbreligion.Items.Add("Hindu");
            cmbreligion.Items.Add("Muslim");
            cmbreligion.Items.Add("Sikh");
            cmbreligion.Items.Add("christian");
            cmbreligion.Items.Add("Others");
            try
            {
                DataTable dt_rel = clsDataAccess.RunQDTbl("select distinct(ltrim(rtrim(Religion))) from  tbl_Employee_Mast where (upper(Religion) not in ('Hindu','Muslim','Sikh','christian','Others',''))");
                if (dt_rel.Rows.Count > 0)
                {
                    for (int idx = 0; idx < dt_rel.Rows.Count; idx++)
                    {

                        cmbreligion.Items.Add(dt_rel.Rows[idx][0].ToString());
                    }
                }
            }
            catch { }

            cmbreligion.SelectedIndex = 0;

            comdocumet1.SelectedIndex = -1;
            comdocumet2.SelectedIndex = -1;
            comdocumet3.SelectedIndex = -1;

            cmbprestate.Items.Clear();
            cmbprecountry.Items.Clear();
            cmbperstate.Items.Clear();
            cmbpercountry.Items.Clear();
            dt_document1.Rows.Clear();
            dtpDOB.Value = DateTime.Now.Date.AddYears(-18);

            rdbTrans_Cash.Checked = false;
            rdbLv_normal.Checked = true;
            rdbTrans_Cash.Checked = true;
            //cmbprecountry.Text = ("India").ToUpper();
            //cmbpercountry.Text = ("India").ToUpper();
            //cmbperstate.Text = ("West Bengal").ToUpper();
            //cmbprestate.Text = ("West Bengal").ToUpper();


            dtpDOB.Value = DateTime.Now.Date.AddYears(-18);
            
            cmbprecountry.Text = ("India").ToUpper();
            cmbpercountry.Text = ("India").ToUpper();
            cmbperstate.Text = ("West Bengal").ToUpper();
            cmbprestate.Text = ("West Bengal").ToUpper();
           

            Configuration_Menu_TypeDoc_companySetting();
            if (this.cmbprecountry.Text.ToLower() == "india" && this.cmbprestate.Text.ToLower() == "west bengal")
            {
                this.txtpretown.Text = ("KOLKATA").ToUpper();
                this.txtpertown.Text = ("KOLKATA").ToUpper();
                cmbreligion.SelectedIndex = 0;
            }
            else
            {
                this.txtpretown.Text = "";
                this.txtpertown.Text = "";

                if (this.cmbprecountry.Text.ToLower() == "bangladesh")
                {
                    cmbreligion.SelectedIndex = 1;
                }
            }
            dtpPenssion.Visible = true;


            cmbMaritalStatus.Items.Clear();
            cmbMaritalStatus.Items.Add("Single");
            cmbMaritalStatus.Items.Add("Married");
            cmbMaritalStatus.Items.Add("Unmarried");
            cmbMaritalStatus.Items.Add("Divorced");
            cmbMaritalStatus.Items.Add("Widowed");
            try
            {
                DataTable dt_status = clsDataAccess.RunQDTbl("select distinct(ltrim(rtrim(MaritalStatus))) from  tbl_Employee_Mast where (upper(MaritalStatus) not in ('SINGLE','MARRIED','UNMARRIED','DIVORCED','WIDOWED',''))");
                if (dt_status.Rows.Count > 0)
                {
                    for (int idx = 0; idx < dt_status.Rows.Count; idx++)
                    {

                        cmbMaritalStatus.Items.Add(dt_status.Rows[idx][0].ToString());
                    }
                }
            }
            catch { }
            cmbGender.Items.Clear();
            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
            cmbGender.Items.Add("Other");

            
            cmbCast.Items.Clear();
            cmbCast.Items.Add("General");
            cmbCast.Items.Add("OBC");
            cmbCast.Items.Add("SC");
            cmbCast.Items.Add("ST");
            try
            {
                DataTable dt_cast = clsDataAccess.RunQDTbl("select distinct(ltrim(rtrim(cast))) from tbl_Employee_Mast where (upper(cast) not in ('General','OBC','SC','ST',''))");
                if (dt_cast.Rows.Count > 0)
                {
                    for (int idx = 0; idx < dt_cast.Rows.Count; idx++)
                    {

                        cmbCast.Items.Add(dt_cast.Rows[idx][0].ToString());
                    }
                }
            }
            catch { }

            btnSave.Text = "Save";

            lblEmpNo.Text = "Total Record : " + clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Mast") + Environment.NewLine +
               " Active Record : " + clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Mast where active=1") +
               " | Deactive Record : " + clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Mast where active=0");

            
        }

        private void ClearQualificationDetails()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select '' Qualification,'' University,'' YearOfPassing,'' Percentage,'' SlNo from tbl_Employee_QualificationDetails where ID='" + cmbdEmpId.Text.Trim() + "'");
            dgQualification.DataSource = dt;
        }
        private void ClearFamilyDetails()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select '' Name,'' Relation,''as DOB,'' Age,0 Dependent,'' as AADHAR,'' SlNo from tbl_Employee_FamilyDetails where (ID='" + cmbdEmpId.Text.Trim() + "')");
            dt.Rows.Clear();
            dgFamily.DataSource = dt;

        }

        private void ClearDocumentImport()
        {
            Imagepath = ""; Imagedocument = ""; Imagedocument2 = ""; Imagedocument3 = "";
            picturedocument.Image = null; pictureimport.Image = null;
            label35.Text = ""; label36.Text = ""; label148.Text = ""; label149.Text = ""; label152.Text = ""; label153.Text = "";
            texpath.Text = ""; textdocument.Text = ""; textdocument2.Text = ""; textdocument3.Text = "";
        }

     
        private void ClearEmpDetails()
        {

            txtemername.Text = "";
            txtemeraddress.Text = "";
            txtemerphone.Text = "";
            txtemermobile.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox38.Text = "";
            txtname1.Text = "";
            txtAddress1.Text = "";
            txtoccuption1.Text = "";
            txtphone1.Text = "";
            txtemail1.Text = "";
            txtname2.Text = "";
            txtaddress2.Text = "";
            txtoccupation2.Text = "";
            txtphone2.Text = "";
            txtemail2.Text = "";
            txtservice.Text = "";
            txtperiod.Text = "";
            txtranks.Text = "";
            txticards.Text = "";
            txtarms.Text = "";
            txtpensionno.Text = "";
            txtgunlicence.Text = "";
            txtoparation.Text = "";
            txtissue.Text = "";
            txtgun.Text = "";
            txtvalid.Text = "";
            txtdrivinglicence.Text = "";
        }

        private void ClearAll()
        {
            //lblEmpNo.Text = "Total Record : " + clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Mast")+ 
            //    " Active Record : " + clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Mast where active=1")+
            //    " Deactive Record : " + clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Mast where active=0");
            ClearPersonalDetails();
            ClearQualificationDetails();
            ClearFamilyDetails();
            ClearEmpDetails();
            ClearDocumentImport();

            clearBioScan();

            tabControl1.SelectedTab = tabControl1.TabPages["tabPersonal"];//tabPersonal;

            cmbcopany.PopUp();
        }

        #endregion

        #region Frequently Used Functions

        private void SetContactDetails()
        {
            if (String.IsNullOrEmpty(Convert.ToString(txtSTD.Text)))
            {
                txtSTD.Text = "0";
            }

            if (String.IsNullOrEmpty(Convert.ToString(txtPh.Text)))
            {
                txtPh.Text = "0";
            }

            if (String.IsNullOrEmpty(Convert.ToString(txtMobile.Text)))
            {
                txtMobile.Text = "0";
            }
        }

        private void GetPenssionDate()
        {
            if (clsValidation.ValidateComboBox(cmbYear, ""))
            {
                if (clsValidation.ValidateEdpCombo(cmbdEmpId, ""))
                {
                    DataTable dt = clsDataAccess.RunQDTbl("Select PenssionAge from tbl_Employee_Config_Retirement where Session='" + cmbYear.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                    {
                        dtpPenssion.Value = Convert.ToDateTime(Convert.ToString(dtpDOB.Value.Day) + "/" + Convert.ToString(dtpDOB.Value.Month) + "/" + Convert.ToString(dtpDOB.Value.Year + Convert.ToInt32(dt.Rows[0]["PenssionAge"])));
                        dtpPenssion.Value = dtpPenssion.Value.AddDays(1);
                        lblpenssion.Text = "Attain " + Convert.ToInt32(dt.Rows[0]["PenssionAge"]) + " years on ";
                    }
                }
            }
        }

        private void SetPenssionAge()
        {
            if (clsValidation.ValidateComboBox(cmbYear, ""))
            {
                DataTable dt = clsDataAccess.RunQDTbl("select PenssionAge from tbl_Employee_Config_Retirement");  // where Session='" + cmbYear.Text.Trim() + "'
                if (dt.Rows.Count > 0)
                {
                    //lblPenssionAge.Text = "";
                    //dtpPenssion.Visible = true;
                    //label90.Text = "Attained " + dt.Rows[0]["PenssionAge"] + " Years " + Environment.NewLine + "Penssion";
                }
                else
                {
                    //label90.Text = "";
                    //dtpPenssion.Visible = false;
                    ERPMessageBox.ERPMessage.Show("Please Configure Employee's Age of Pension First");
                    Config_RetirementDetails rd = new Config_RetirementDetails();
                    rd.ShowDialog();
                }
            }
        }

       

        private void GetRetirementDate()
        {
            if (clsValidation.ValidateComboBox(cmbYear, ""))
            {
                if (clsValidation.ValidateEdpCombo(cmbdEmpId, ""))
                {
                    DataTable dt = clsDataAccess.RunQDTbl("Select Age from tbl_Employee_Config_Retirement where Session='" + cmbYear.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                    {
                        dtpDOR.Value = Convert.ToDateTime(Convert.ToString(dtpDOB.Value.Day) + "/" + Convert.ToString(dtpDOB.Value.Month) + "/" + Convert.ToString(dtpDOB.Value.Year + Convert.ToInt32(dt.Rows[0]["Age"])));
                        dtpDOR.Value = dtpDOR.Value.AddDays(1);
                    }
                }
            }
        }

        private Boolean RepeatRelation(String strRelation)
        {
            int CountRelation = 0;
            Boolean boolStatus = true;
            if (dgFamily.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgFamily.Rows.Count - 1; i++)
                {
                    //String strRelation = Convert.ToString(dgFamily.Rows[i].Cells["Relation"].Value).ToUpper();
                    if (strRelation.ToLower() == Convert.ToString(dgFamily.Rows[i].Cells["Relation"].Value).Trim().ToLower())
                    {
                        CountRelation = CountRelation + 1;
                    }
                }
            }
            if (CountRelation > 1)
            {
                boolStatus = false;
            }
            return boolStatus;
        }

        private void SetHusbandDetails()
        {
            if (cmbMaritalStatus.Text.Trim().ToLower() == "married" )//&& cmbGender.Text.Trim().ToLower() == "female")
            {
                cmbHusTitle.BackColor = Color.LightYellow;
                //cmbHusTitle.SelectedIndex = 0;
                txtHusFN.BackColor = Color.LightYellow;
                txtHusMN.BackColor = Color.White;
                txtHusLN.BackColor = Color.LightYellow;
                cmbHusTitle.Enabled = true;
                txtHusFN.Enabled = true;
                txtHusMN.Enabled = true;
                txtHusLN.Enabled = true;
            }
            else
            {
                //cmbHusTitle.BackColor = Color.LightGray;
                //txtHusFN.BackColor = Color.LightGray;
                //txtHusMN.BackColor = Color.LightGray;
                //txtHusLN.BackColor = Color.LightGray;
                //cmbHusTitle.Enabled = false;
                //txtHusFN.Enabled = false;
                //txtHusMN.Enabled = false;
                //txtHusLN.Enabled = false;

                cmbHusTitle.BackColor = Color.LightYellow;
                //cmbHusTitle.SelectedIndex = 0;
                txtHusFN.BackColor = Color.LightYellow;
                txtHusMN.BackColor = Color.White;
                txtHusLN.BackColor = Color.LightYellow;
                cmbHusTitle.Enabled = true;
                txtHusFN.Enabled = true;
                txtHusMN.Enabled = true;
                txtHusLN.Enabled = true;
            }
        }

        #endregion

        #endregion

        private void chkSame_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSame.Checked == true)
            {
                txtPerAdd.Text = txtPreAdd.Text;
                txtperbuilding.Text = txtprebuilding.Text;
                txtperstreet.Text = txtprestreet.Text;
                txtperarea.Text = txtprearea.Text;
                txtpertown.Text = txtpretown.Text;
                txtperpin.Text = txtprepin.Text;
                cmbperstate.SelectedIndex = cmbprestate.SelectedIndex;
                cmbpercountry.SelectedIndex = cmbprecountry.SelectedIndex;
            }
            else
            {
                txtPerAdd.Text = "";
                txtperbuilding.Text = "";
                txtperstreet.Text = "";
                txtperarea.Text = "";
                txtpertown.Text = "";
                txtperpin.Text = "";
                cmbperstate.SelectedIndex = -1;
                cmbpercountry.SelectedIndex = -1;
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Do you want to close the form?", "Employee Joining", MessageBoxButtons.YesNo) == DialogResult.No)
            //{
            //    // Cancel the Closing event from closing the form.
            //    close_frm = 1;
            //    // Call method to save file...
            //}
            //else
            //{
            //    close_frm = 0;
            //    edpcom.UpdateMidasLog(this, true);
            //}
            //if (close_frm == 0)
            //{
            //    this.Close();
            //    this.Dispose(true);
            //}
            this.Close();
        }

        #region Combobox



        private void cmbdEmpId_DropDown(object sender, EventArgs e)
        {
            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Select Session"))
            {
                if (ChekAllExRecord())
                {
                    String str = "select ID,EmployeeName,DesignationName,Location,Client,Mobile,Aadhar,(case when (active=1) then (case when lmon>2 then 'Dormant' else (case when lmon<=3 then 'Pre-Dormant' else 'Active' end) end ) else 'InActive' end)'Status' from (SELECT ID,((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS 'EmployeeName'," +
                "(SELECT DesignationName FROM tbl_Employee_DesignationMaster AS Desg WHERE (SlNo = emp.DesgId)) AS DesignationName,"+
                "(SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = emp.Location_id)) AS Location,"+
                "(Select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID in(select Location_ID from Companywiseid_Relation where (Company_ID= emp.Company_id) and (Location_ID= emp.Location_id)))'Client'," +
                "(case when Mobile!=0 then convert(nvarchar(max),Mobile) else convert(nvarchar(max),'') end)as Mobile,REPLACE(aadhar, ' ', '') as 'Aadhar',(SELECT DATEDIFF(month, max(cast(('01-'+ [Month]) as Date)), CAST( GETDATE() AS Date )) FROM tbl_Employee_SalaryGross where empid=emp.ID)lmon,active FROM tbl_Employee_Mast AS emp where emp.Company_id='" + Company_id + "' and emp.del=1 and emp.memp=0)x ORDER BY ID";
                   //"SELECT ID, ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS [Employee Name],(SELECT DesignationName FROM tbl_Employee_DesignationMaster AS Desg WHERE (SlNo = emp.DesgId)) AS DesignationName,(SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = emp.Location_id)) AS Location,Mobile FROM tbl_Employee_Mast AS emp ORDER BY [Employee Name], ID";
                    DataTable dt = clsDataAccess.RunQDTbl(str);
                    //"select emp.ID,emp.FirstName+' '+emp.MiddleName+' '+emp.LastName as [Employee Name],desg.DesignationName from tbl_Employee_Mast emp, tbl_Employee_DesignationMaster desg where emp.DesgId=desg.SlNo order by [Employee Name] "); //and emp.Session='" + cmbYear.Text.Trim() + "'
                    if (dt.Rows.Count > 0)
                    {
                        cmbdEmpId.LookUpTable = dt;
                    }
                }
            }
        }

        private void cmbdEmpId_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            counter = 1;
            pictureimport.Image = null;
            texpath.Text = "";
            picturedocument.Image = null;
            textdocument.Text = "";
            flugAdd_import = false;
            Imagedocument = "";
            Imagepath = "";

            ClearPersonalDetailsExceptEmpId();
            if (ChekExRecordByEmpId())
            {
                edpcom.InsertMidasLog(this, true, "view", cmbdEmpId.Text.Trim());
                cmbdEmpId.ReadOnly = true;
                cmbdEmpId.Enabled = false;
                cmbdEmpId.BackColor = Color.LightGray;
                GetPersonalDetails();
                GetQualificationDetails();
                GetFamilyDetails();
                SetPenssionAge();
                GetempDetails();
                GetFScan();
                cmbYear.Focus();
                btnSave.Text = "Update";
            }
        }

      

       
        

        private void cmbEmpType_DropDown_1(object sender, EventArgs e)
        {
            //if (cmbEmpType.ReturnValue == "")
            //{
                DataTable dt = clsDataAccess.RunQDTbl("select JobType,ShortForm,SlNo from tbl_Employee_JobType"); //where ShortForm='FT' or 
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count == 1)
                    {
                        cmbEmpType.Text = dt.Rows[0][0].ToString();
                        cmbEmpType.ReturnIndex = 2;
                        cmbEmpType.ReturnValue = dt.Rows[0][2].ToString();
                    }
                }
                else if (dt.Rows.Count > 1)
                {
                    cmbEmpType.LookUpTable = dt;
                    cmbEmpType.ReturnIndex = 2;
                }
            //}
            //else
            //{
            //    DataTable dt = clsDataAccess.RunQDTbl("select JobType,ShortForm,SlNo from tbl_Employee_JobType");
            //    if (dt.Rows.Count > 0)
            //    {
            //        cmbEmpType.LookUpTable = dt;
            //        cmbEmpType.ReturnIndex = 2;
            //    }
            //}
        }

        private void cmbDesg_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select DesignationName,ShortForm,SlNo from tbl_Employee_DesignationMaster");
            if (dt.Rows.Count > 0)
            {
                cmbDesg.LookUpTable = dt;
                cmbDesg.ReturnIndex = 2;
            }
        }

        private void cmbEmpTitle_DropDown(object sender, EventArgs e)
        {
            cmbEmpTitle.Items.Clear();
            cmbEmpTitle.Items.Add("Sri.");
            cmbEmpTitle.Items.Add("Smt.");
            cmbEmpTitle.Items.Add("Mr.");
            cmbEmpTitle.Items.Add("Ms.");
            cmbEmpTitle.Items.Add("Mrs.");
            
            cmbEmpTitle.Items.Add("Md.");
            cmbEmpTitle.Items.Add("MOHD");

            cmbEmpTitle.Items.Add("Dr.");
            cmbEmpTitle.Items.Add("Proff.");
            cmbEmpTitle.Items.Add("Late.");
            cmbEmpTitle.Items.Add("-");
            cmbEmpTitle.SelectedIndex = 2;
        }

        private void cmbFatherTitle_DropDown(object sender, EventArgs e)
        {
            cmbFatherTitle.Items.Clear();
            cmbFatherTitle.Items.Add("Sri.");
            cmbFatherTitle.Items.Add("Mr.");

            cmbFatherTitle.Items.Add("Md.");
            cmbFatherTitle.Items.Add("MOHD");
            
            cmbFatherTitle.Items.Add("Dr.");
            cmbFatherTitle.Items.Add("Proff.");
            cmbFatherTitle.Items.Add("Late.");
            cmbFatherTitle.Items.Add("-");
            cmbFatherTitle.SelectedIndex = 0;
        }

        private void cmbMotherTitle_DropDown(object sender, EventArgs e)
        {
            cmbMotherTitle.Items.Clear();
            cmbMotherTitle.Items.Add("Smt.");
            cmbMotherTitle.Items.Add("Mrs.");
            cmbMotherTitle.Items.Add("Dr.");
            cmbMotherTitle.Items.Add("Proff.");
            cmbMotherTitle.Items.Add("Late.");
            cmbMotherTitle.Items.Add("-");
            cmbMotherTitle.SelectedIndex = 0;
        }

        private void cmbHusTitle_DropDown(object sender, EventArgs e)
        {
            cmbHusTitle.Items.Clear();
            if ((cmbMaritalStatus.Text.Trim().ToLower() == "married") && (cmbGender.Text.Trim().ToLower() == "female"))
            {

                cmbHusTitle.Items.Add("Smt.");
                cmbHusTitle.Items.Add("Mrs.");

            }
            else if ((cmbMaritalStatus.Text.Trim().ToLower() == "married") && (cmbGender.Text.Trim().ToLower() == "male"))
            {

                cmbHusTitle.Items.Add("Sri.");
                cmbHusTitle.Items.Add("Mr.");

                cmbHusTitle.Items.Add("Md.");
                cmbHusTitle.Items.Add("MOHD");
            }
            else
            {


                cmbHusTitle.Items.Add("Sri.");
                cmbHusTitle.Items.Add("Mr.");

                cmbMotherTitle.Items.Add("Smt.");
                cmbMotherTitle.Items.Add("Mrs.");
            }
            cmbHusTitle.Items.Add("Dr.");
            cmbHusTitle.Items.Add("Proff.");
            cmbHusTitle.Items.Add("Md.");
            cmbHusTitle.Items.Add("Sk.");
            cmbHusTitle.Items.Add("Late.");
            cmbHusTitle.Items.Add("-");
            cmbHusTitle.SelectedIndex = 0;
        }

        private void cmbMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetHusbandDetails();
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetHusbandDetails();
        }

        #endregion

        #region TextboxValidation
        private void txtEmpFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clsValidation.AlphabetsOnly(txtEmpFName, "Invalid Character", e))
            {
            }
        }

        private void txtEmpMName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clsValidation.AlphabetsOnly(txtEmpMName, "Invalid Character", e))
            {

            }
        }

        private void txtEmpLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clsValidation.AlphabetsOnly(txtEmpLName, "Invalid Character", e))
            {
            }
        }

        private void txtFN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clsValidation.AlphabetsOnly(txtFathFN, "Invalid Character", e))
            {
            }
        }

        private void txtMN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clsValidation.AlphabetsOnly(txtFathMN, "Invalid Character", e))
            {
            }
        }

        private void txtLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clsValidation.AlphabetsOnly(txtFathLN, "Invalid Character", e))
            {
            }
        }

        private void txtSTD_TextChanged(object sender, EventArgs e)
        {
            if (txtSTD.Text.Length > 6)
                ERPMessageBox.ERPMessage.Show("Too much Digits");
        }

        private void txtPh_TextChanged(object sender, EventArgs e)
        {
            if (txtPh.Text.Length > 9)
                ERPMessageBox.ERPMessage.Show("Too much Digits");
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            if (txtMobile.Text.Length > 10)
            {
                ERPMessageBox.ERPMessage.Show("Too much Digits");
                txtMobile.Text = txtMobile.Text.ToString().Substring(0, 10);
                txtMobile.Focus();
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clsValidation.NumberOnly(txtMobile, "Invalid Character", e))
            {
            }
        }



        private void txtEmailId_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtSTD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clsValidation.NumberOnly(txtSTD, "Invalid Character", e))
            {
            }
        }

        private void txtPh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clsValidation.NumberOnly(txtPh, "Invalid Character", e))
            {
            }
        }



        private void txtEmpFName_Validating(object sender, CancelEventArgs e)
        {
            txtEmpFName.Text = clsValidation.FirstLetterCap(txtEmpFName.Text.ToString());
        }

        private void txtEmpMName_Validating(object sender, CancelEventArgs e)
        {
            txtEmpMName.Text = clsValidation.FirstLetterCap(txtEmpMName.Text.ToString());
        }

        private void txtEmpLName_Validating(object sender, CancelEventArgs e)
        {
            txtEmpLName.Text = clsValidation.FirstLetterCap(txtEmpLName.Text.ToString());
        }

        private void txtFN_Validating(object sender, CancelEventArgs e)
        {
            txtFathFN.Text = clsValidation.FirstLetterCap(txtFathFN.Text.ToString());
        }

        private void txtMN_Validating(object sender, CancelEventArgs e)
        {
            txtFathMN.Text = clsValidation.FirstLetterCap(txtFathMN.Text.ToString());
        }

        private void txtLN_Validating(object sender, CancelEventArgs e)
        {
            txtFathLN.Text = clsValidation.FirstLetterCap(txtFathLN.Text.ToString());
        }
        #endregion

        #region GridValidation
        private void dgQualification_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                int ErrColoum = Convert.ToInt32(dgQualification.CurrentCell.ColumnIndex);
                if (e.Exception.Message.ToString() == "Input string was not in a correct format.")
                {
                    if (ErrColoum.ToString() == "2")
                    {
                        ERPMessageBox.ERPMessage.Show("Year of Passing must be Numeric");
                    }
                    if (ErrColoum.ToString() == "3")
                    {
                        ERPMessageBox.ERPMessage.Show("Percentage must be Numeric");
                    }
                }
            }
            catch { }
        }

        private void dgFamily_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int ErrColoum = Convert.ToInt32(dgFamily.CurrentCell.ColumnIndex);
            if (e.Exception.Message.ToString() == "Input string was not in a correct format.")
            {
                if (ErrColoum.ToString() == "2")
                {
                    ERPMessageBox.ERPMessage.Show("Age must be Numeric");
                }
            }
        }

        private void dgFamily_Validating(object sender, CancelEventArgs e)
        {
            for (int i = 0; i < dgFamily.Rows.Count - 1; i++)
            {
                dgFamily.Rows[i].Cells["Relation"].Value = clsSchool.FirstLetterCap(Convert.ToString(dgFamily.Rows[i].Cells["Relation"].Value.ToString()));
            }
        }

        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ChekExRecordByEmpId())
            {
                ERPMessageBox.ERPMessage.Show("Are you Sure ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
                if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
                {
                    DeleteRecord();
                    Imagedocument = "";
                    Imagepath = "";
                    pictureimport.Image = null;
                    texpath.Text = "";
                    picturedocument.Image = null;
                    textdocument.Text = "";
                    flugAdd_import = false;
                }
            }
        }
        /*--------------------The Following section has Edited by Dwipraj Dutta By the suggetion of Sanjay Parolia[CEO of EDP Soft] - 13/07/2017-----------------*/
        //After 9999 error handeling has not implemented. Logic is in Progress.
        public string get_EmpNo()
        {
            Int32 odno = 0;
            int dcno = 4;
            string dcpref = "E", dcsufix = "";
            DataTable dt2 = new DataTable();
            if (Information.IsNumeric(cmbcopany.ReturnValue) == false)
            {
                string[] dc = clsDataAccess.Emp_No_struct().Split('|');

                dcpref = dc[0].Trim();
                dcno = Convert.ToInt32(dc[1]);
            }
            else
            {
                dt2 = clsDataAccess.RunQDTbl("select prefix,padding from Branch where (BRNCH_CODE=1) and (gcode='"+Company_id+"')");
                if (dt2.Rows.Count > 0)
                {
                    try
                    {
                        dcpref = dt2.Rows[0]["Prefix"].ToString().Trim();
                        dcno = Convert.ToInt32(dt2.Rows[0]["padding"].ToString().Trim());
                    }
                    catch
                    {
                        string[] dc = clsDataAccess.Emp_No_struct().Split('|');

                        dcpref = dc[0].Trim();
                        dcno = Convert.ToInt32(dc[1]);
                    }
                }

            }
            for (int idx = 0; idx < dcno; idx++)
            {
                if (dcsufix == "")
                {
                    dcsufix = "0";
                }
                else
                {
                    dcsufix = dcsufix + "0";
                }

            }


         

            if (dcpref.Trim() != "")
            {   
                dt2 = clsDataAccess.RunQDTbl("select [maxget].ID from (select ID from tbl_Employee_Mast where ID like '" + dcpref + "%') as maxget" +
                                                    " order by CAST(SUBSTRING(maxget.ID,"+(dcpref.Length+1)+",LEN(maxget.ID)-1) as int) desc");
            }
            else
            {
                dt2 = clsDataAccess.RunQDTbl("select [maxget].ID from (select ID from tbl_Employee_Mast) as maxget order by CAST(maxget.ID as int) desc");
            }

            if (dt2.Rows.Count > 0)
            {
                string maxEmployeeId = dt2.Rows[0][0].ToString(); //21092017
                if (dcpref.Trim() != "")
                {
                    maxEmployeeId = maxEmployeeId.Substring(dcpref.Length, maxEmployeeId.Length - dcpref.Length);

                }
                odno = Convert.ToInt32(maxEmployeeId);
                odno = odno + 1;
            }
            else
            {
                odno = 1;
            }
            return dcpref + odno.ToString(dcsufix);
        }
        /*-------------------------------------------------------------------End of Editing----------------------------------------------------------------------*/

        public void default_area()
        {
            DataTable cnf = clsDataAccess.RunQDTbl("select state,city,country FROM CompanyLimiter");

            if (cnf.Rows.Count > 0)
            {
                this.cmbprestate.Text = cnf.Rows[0]["state"].ToString().ToUpper();
                this.cmbperstate.Text = cnf.Rows[0]["state"].ToString().ToUpper();

                this.txtpretown.Text = cnf.Rows[0]["city"].ToString().ToUpper();
                this.txtpertown.Text = cnf.Rows[0]["city"].ToString().ToUpper();

                this.cmbprecountry.Text = cnf.Rows[0]["country"].ToString().ToUpper();
                this.cmbpercountry.Text = cnf.Rows[0]["country"].ToString().ToUpper();
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
                                        this.cmbprecountry.Text = StrLine_WACC[1].ToUpper();
                                        this.cmbpercountry.Text = StrLine_WACC[1].ToUpper();
                                        //DataTable Coun = edpcom.GetDatatable("SELECT Country_CODE FROM Country where Country_Name='" + cmbCountry.Text + "'");
                                        //if (Coun.Rows.Count > 0)
                                        // string   COUNTRYCODE = Convert.ToInt32(Coun.Rows[0][0]);
                                        //MoneyName = edpcom.GetresultS("SELECT Currency_Name From Country Where Country_Name='" + cmbCountry.Text + "'");
                                    }
                                    else if (StrLine_WACC[0] == "State")
                                    {
                                        this.cmbprestate.Text = StrLine_WACC[1].ToUpper();
                                        this.cmbperstate.Text = StrLine_WACC[1].ToUpper();
                                        //DataTable stat = edpcom.GetDatatable("SELECT STATE_CODE FROM StateMaster where State_Name='" + cmbstate.Text + "'");
                                        //if (stat.Rows.Count > 0)
                                        //    STATECODE = Convert.ToInt32(stat.Rows[0][0]);
                                    }
                                    else if (StrLine_WACC[0] == "City")
                                    {
                                        this.txtpretown.Text = StrLine_WACC[1].ToUpper();
                                        this.txtpertown.Text = StrLine_WACC[1].ToUpper();
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
        private void EmpJoining_Load(object sender, EventArgs e)
        {
          //  PermissionNewEmployeJoining();
            clearBioScan();
            ClearPersonalDetails();
            chk_active.Checked = true;

            dt_document1.Columns.Add("ID", typeof(string));
            dt_document1.Columns.Add("Image", typeof(string));
            dt_document1.Columns.Add("document_type", typeof(byte));
            dt_document1.Columns.Add("new", typeof(string));
            dt_document1.Columns.Add("Image1", typeof(string));


            if (clsDataAccess.GetresultS("select desgday from CompanyLimiter") == "1")
            {
                grpLv.Visible = true;
            }
            else
            {
                grpLv.Visible = false;
            }

            if (clsDataAccess.GetresultS("select UsrEmp from CompanyLimiter") == "1")
            {
                grpPass.Visible = true;
            }
            else
            {
                grpPass.Visible = false;
            }

            //generate year
            clsValidation.GenerateYear(cmbYear, 2016, System.DateTime.Now.Year, 1);
            //
            //set session
            //if (System.DateTime.Now.Month >= 4)
            //{
            //    cmbYear.SelectedIndex = 0;
            //}
            //else
            //{
            //    cmbYear.SelectedIndex = 1;
            //}

            try
            {
                if (System.DateTime.Now.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = System.DateTime.Now.Year + "-" + System.DateTime.Now.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = System.DateTime.Now.AddYears(-1).Year + "-" + System.DateTime.Now.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }

            //
            

            SetPenssionAge();
            comdocumet1.SelectedIndex = -1;
            DataTable dt_status = clsDataAccess.RunQDTbl("SELECT sid,status FROM tbl_StatusMst");
            cmbStaus.DataSource = dt_status;
            cmbStaus.DisplayMember = "status";
            cmbStaus.ValueMember = "sid";

            DataTable dt = clsDataAccess.RunQDTbl("select Quali_Name from Qualification_Master");
            DataGridViewComboBoxColumn dgcombo = dgQualification.Columns[0] as DataGridViewComboBoxColumn;
            dgcombo.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dt.Rows[i]["Quali_Name"]);
                dgcombo.Items.Add(st);
            }

            DataTable dt1 = clsDataAccess.RunQDTbl("select Relation_Name from Relation_Master");
            DataGridViewComboBoxColumn dgcombo1 = dgFamily.Columns[1] as DataGridViewComboBoxColumn;
            dgcombo1.Items.Clear();
            for (int i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dt1.Rows[i]["Relation_Name"]);
                dgcombo1.Items.Add(st);
            }
            dtpDOB.Value = DateTime.Now.Date.AddYears(-18);
            cmbdEmpId.Text = get_EmpNo();
            cmbprecountry.Text = ("India").ToUpper();
            cmbpercountry.Text = ("India").ToUpper();
            cmbperstate.Text = ("West Bengal").ToUpper();
            cmbprestate.Text = ("West Bengal").ToUpper();
            cmbEmpType.PopUp();

            Configuration_Menu_TypeDoc_companySetting();
            default_area();
            if (this.cmbprecountry.Text.ToLower() == "india" && this.cmbprestate.Text.ToLower() == "west bengal")
            {
                this.txtpretown.Text = ("KOLKATA").ToUpper();
                this.txtpertown.Text = ("KOLKATA").ToUpper();
                cmbreligion.SelectedIndex = 0;
            }
            else if (this.cmbprecountry.Text.ToLower() == "india" && this.cmbprestate.Text.ToLower() != "west bengal")
            {
              
                cmbreligion.SelectedIndex = 0;
            }
            else
            {
                this.txtpretown.Text = "";
                this.txtpertown.Text = "";

                if (this.cmbprecountry.Text.ToLower() == "bangladesh")
                {
                    cmbreligion.SelectedIndex = 1;
                }
            }

            DataTable dt_user = clsDataAccess.RunQDTbl("select USER_LEV, hide_pfesi from pasword where (user_code ='" + edpcom.PCURRENT_USER + "')");
            if (dt_user.Rows[0]["USER_LEV"].ToString().Trim() != "Superuser")
            {
                if (dt_user.Rows[0]["hide_pfesi"].ToString().Trim() != "1")
                {
                    tabControl1.TabPages.Remove(tabPfEsi);
                }
            }

            chk_active.Checked = true;

            string[] lang = clsDataAccess.EMPLang().Split('|');
                //clsDataAccess.Emp_lang().Split('|');

            lbl_lang1.Text = lang[0].ToString();
            lbl_lang2.Text = lang[1].ToString();
            lbl_lang3.Text = lang[2].ToString();


            if (clsDataAccess.GetresultS("select distinct empid from CompanyLimiter") == "1")
            {
                cmbdEmpId.ReadOnlyText = true;
            }
            else
            {
                cmbdEmpId.ReadOnlyText = false;

            }


            cmbcopany.ReadOnlyText = true;

            //DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            //if (dt_co.Rows.Count == 1)
            //{
            //    cmbcopany.Text = Convert.ToString(dt_co.Rows[0][0]);

            //    Company_id = Convert.ToInt32(dt_co.Rows[0][1]);

            //}
            //else if (dt_co.Rows.Count > 1)
            //{
            //    cmbcopany.PopUp();

            //}
            cmbcopany.PopUp();
        }



        private bool chk_permission(string tp, double eid)
        {
            DataTable dtCompanyLimiter = clsDataAccess.RunQDTbl("select EmpLimit from CompanyLimiter");
            int count_emp = 0;
            Boolean bl;
            if (tp=="I")
            count_emp=    Convert.ToInt32(clsDataAccess.RunQDTbl("select count(*) as 'TotalRecord' from [tbl_Employee_Mast] where active=1 and del=1").Rows[0][0]);
            else if(tp=="U")
            count_emp = Convert.ToInt32(clsDataAccess.RunQDTbl("select count(*)+1 as 'TotalRecord' from [tbl_Employee_Mast] where (code<='"+ eid +"')").Rows[0][0]);


            if (count_emp == 0)
                bl = true;
            else
            {

                if (dtCompanyLimiter.Rows.Count > 0)
                {
                    if (count_emp < Convert.ToInt32(dtCompanyLimiter.Rows[0]["EmpLimit"]) || Convert.ToInt32(dtCompanyLimiter.Rows[0]["EmpLimit"])==0)
                        bl = true;
                    else
                        bl = false;
                }
                else
                {
                    bl = false;
                }
            }

            return bl;

        }


        private void PermissionNewEmployeJoining()
        {
            string filePath = "";
            filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
            string lineForConfigSetting;
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
                                if (str.ToUpper() == "EMPLOYEE_ENTRY_LIMITER")
                                    chk_str = 1;
                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                if (Information.IsNumeric(StrLine_WACC[0]))
                                {
                                    DataTable dtCountEmployee = clsDataAccess.RunQDTbl("select count(*) as 'TotalRecord' from [tbl_Employee_Mast]");
                                    if (Convert.ToInt32(dtCountEmployee.Rows[0][0]) < Convert.ToInt32(StrLine_WACC[0]))
                                    {
                                        boolNewEmployeeEntry = true;
                                    }
                                }
                                else if (StrLine_WACC[0] == "EDP_BRAVO_UNLIMITED")
                                    boolNewEmployeeEntry = true;
                                else
                                {
                                    DataTable dtCountEmployee = clsDataAccess.RunQDTbl("select count(*) as 'TotalRecord' from [tbl_Employee_Mast]");
                                    if (Convert.ToInt32(dtCountEmployee.Rows[0][0]) < defaultEmpCreationLimit)
                                    {
                                        boolNewEmployeeEntry = true;
                                    }
                                }
                                chk_str = 0;
                            }
                        }
                    }

                }
                catch
                { }
            }
            if (!boolNewEmployeeEntry)
                this.BeginInvoke(new MethodInvoker(Close));
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Select Session"))
            {
                if (!ChekAllExRecord())
                {
                    ClearLookUpTable(cmbdEmpId);
                    //ERPMessageBox.ERPMessage.Show("No Employee Record Exists For Selected Session");
                }
                SetPenssionAge();
            }
        }

        private void dtpDOJ_Leave(object sender, EventArgs e)
        {
            GetRetirementDate();
            GetPenssionDate();
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            GetRetirementDate();
            GetPenssionDate();
        }

        private void txtPreAdd_TextChanged(object sender, EventArgs e)
        {
            if (chkSame.Checked)
                txtPerAdd.Text = txtPreAdd.Text;
        }

        private void dtpDOJ_ValueChanged(object sender, EventArgs e)
        {
            GetRetirementDate();
            GetPenssionDate();
        }

        private void dtpDOB_Leave(object sender, EventArgs e)
        {
            GetRetirementDate();
            GetPenssionDate();
        }

        private void cmbSal_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT SalaryCategory FROM tbl_Employee_SalaryStructure");
            cmbSal.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                cmbSal.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void cmbLedger_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select Ldesc,Glcode from glmst where mtype='L'");
            cmbLedger.LookUpTable = dt;
        }

        private void cmbSection_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT Section FROM tbl_Employee_SectionMaster");
            cmbSection.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                cmbSection.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ingdoc = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();
                //openFileDialog1.InitialDirectory = "Picture/";
                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;

                openFileDialog1.ShowDialog();
                ingdoc = openFileDialog1.FileName;
                textdocument.Text = ingdoc;
                picturedocument.ImageLocation = ingdoc;


           
                    if (flugAdd_import == true)
                    {
                        Imagedocument = ingdoc + "," + ingdoc;

                        string[] st1 = new string[] { };
                        st1 = Imagedocument.Split(',');
                        counter = st1.Length;
                        label35.Text = counter.ToString();
                        label36.Text = counter.ToString();
                    }
                    else
                        Imagedocument = ingdoc;
                    doc_type_no = 1;

            
                //picturedocument.Image = new Bitmap(ingdoc);
                //string ss = "";
                //string arguments = Environment.CommandLine;
                //string[] st = new string[] { };
                //st = ingdoc.Split('\\');
                ////ss = arguments.Replace("PayRollManagementSystem.vshost.exe", "");
                //ss = arguments.Replace("PayRollManagementSystem.exe", "");
                //string sss = ss.Substring(1, ss.Length - 3);

                //if (flugAdd_import == true)
                //{
                //    Imagedocument = Imagedocument + "," + sss + "Picture\\" + cmbdEmpId.Text + st[st.Length - 1];

                //    string[] st1 = new string[] { };
                //    st1 = Imagedocument.Split(',');
                //    counter = st1.Length;
                //    label35.Text = counter.ToString();
                //    label36.Text = counter.ToString();
                //}
                //else
                //    Imagedocument = sss + "Picture\\" + cmbdEmpId.Text + st[st.Length - 1];

                //string path = textdocument.Text;
                //Bitmap bp = new Bitmap(path);
                //bp.Save(sss + "Picture\\" + cmbdEmpId.Text + st[st.Length - 1]);
                //flugAdd_import = false;
            }
            catch { }
        }




        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                picturedocument.Image = null;
                textdocument.Text = "";
                try
                {
                    if (dt_document1.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt_document1.Rows.Count - 1; i++)
                        {
                            if (Convert.ToString(dt_document1.Rows[i]["document_type"]) == "1")
                            {
                                dt_document1.Rows[i]["new"] = 5;

                                dt_document1.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
                catch { }
                label35.Text = "0";
                label36.Text = "0";

                   // dt_document1.Rows.Clear();

                //string[] st1 = new string[] { };
                //st1 = Imagedocument.Split(',');

                //counter = st1.Length;
                //if (counter > 1)
                //{
                //    st1[Convert.ToInt32(label35.Text) - 1] = "";
                //    counter = counter - 1;
                //    label35.Text = counter.ToString();
                //    label36.Text = counter.ToString();
                //    Imagedocument = "";
                //    for (int i = 0; i <= st1.Length - 1; i++)
                //    {
                //        if (st1[i] != "")
                //        {
                //            if (i < st1.Length - 1 && i > 0)
                //                Imagedocument = Imagedocument + ",";

                //            Imagedocument = Imagedocument + st1[i];

                //        }
                //    }
                //    textdocument.Text = st1[counter];
                //    picturedocument.Image = new Bitmap(st1[counter]);

                //}
                //else
                //{
                //    counter = 0;
                //    label35.Text = counter.ToString();
                //    label36.Text = counter.ToString();
                //    Imagedocument = "";
                //}
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ERPMessageBox.ERPMessage.Show("Do You Want Another Document Import ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
            if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
            {
                textdocument.Text = "";
                picturedocument.Image = null;
                flugAdd_import = true;
                button2_Click(sender, e);

            }
        }

        private void s_Click(object sender, EventArgs e)
        {
            if (counter > 1)
                counter = counter - 1;

            DataTable dt1 = clsDataAccess.RunQDTbl("select Document_Image from tbl_Emp_DocumentImage where ID='" + cmbdEmpId.Text.Trim() + "' and Document_Type='1' ");
            if (dt1.Rows.Count >= counter)
            {
                Imagedocument = Convert.ToString(dt1.Rows[counter - 1]["Document_Image"]);
                if (Imagedocument != "")
                {
                    MemoryStream stream = new MemoryStream();
                    picturedocument.Image = null;
                    byte[] image = ((byte[])dt1.Rows[counter - 1]["Document_Image"]);
                    stream.Write(image, 0, image.Length);
                    Bitmap bitmap = new Bitmap(stream);
                    picturedocument.Image = bitmap;
                    label35.Text = counter.ToString();
                    label36.Text = dt1.Rows.Count.ToString();
                }
            }


            //if (Imagedocument != "")
            //{
            //    string[] st = new string[] { };
            //    st = Imagedocument.Split(',');
            //    if (st.Length > counter && counter > 0)
            //    {
            //        label35.Text = counter.ToString();
            //        picturedocument.Image = new Bitmap(st[counter - 1]);
            //        textdocument.Text = st[counter - 1];
            //    }
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(label36.Text) > counter)
                counter = counter + 1;


            DataTable dt1 = clsDataAccess.RunQDTbl("select Document_Image from tbl_Emp_DocumentImage where ID='" + cmbdEmpId.Text.Trim() + "' and Document_Type='1' ");
            if (dt1.Rows.Count >= counter)
            {
                Imagedocument = Convert.ToString(dt1.Rows[counter - 1]["Document_Image"]);
                if (Imagedocument != "")
                {
                    MemoryStream stream = new MemoryStream();
                    picturedocument.Image = null;
                    byte[] image = ((byte[])dt1.Rows[counter - 1]["Document_Image"]);
                    stream.Write(image, 0, image.Length);
                    Bitmap bitmap = new Bitmap(stream);
                    picturedocument.Image = bitmap;
                    label35.Text = counter.ToString();
                    label36.Text = dt1.Rows.Count.ToString();
                }
            }


            //if (Imagedocument != "")
            //{
            //    string[] st = new string[] { };
            //    st = Imagedocument.Split(',');
            //    if (st.Length >= counter && counter > 0)
            //    {
            //        picturedocument.Image = new Bitmap(st[counter-1]);
            //        textdocument.Text = st[counter - 1];
            //        label35.Text = counter.ToString();
            //    }
            //}
        }

        private void cmbprestate_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT STATE_Name FROM StateMaster");
            cmbprestate.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                cmbprestate.Items.Add(dt.Rows[i][0].ToString().ToUpper());
            }
            cmbperstate_DropDown(sender, e);
        }

        private void cmbperstate_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT STATE_Name FROM StateMaster");
            cmbperstate.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                cmbperstate.Items.Add(dt.Rows[i][0].ToString().ToUpper());
            }
        }

        private void cmbprecountry_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT Country_Name FROM Country");
            cmbprecountry.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                cmbprecountry.Items.Add(dt.Rows[i][0].ToString().ToUpper());
            }
            cmbpercountry_DropDown(sender, e);
        }

        private void cmbpercountry_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT Country_Name FROM Country");
            cmbpercountry.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                cmbpercountry.Items.Add(dt.Rows[i][0].ToString().ToUpper());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();
                //openFileDialog1.InitialDirectory = "Picture/";
                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                texpath.Text = Imagepath;
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

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            pictureimport.Image = Properties.Resources.blank2;
            texpath.Text = "";
            Imagepath = "";
        }

        private void btndocumentimport2_Click(object sender, EventArgs e)
        {
            try
            {
                string ingdoc = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();
                //openFileDialog1.InitialDirectory = "Picture/";
                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;

                openFileDialog1.ShowDialog();
                ingdoc = openFileDialog1.FileName;
                textdocument2.Text = ingdoc;
                picturedocument.ImageLocation = ingdoc;
                if (flugAdd_import == true)
                {
                    Imagedocument2 = ingdoc + "," + ingdoc;

                    string[] st1 = new string[] { };
                    st1 = Imagedocument2.Split(',');
                    counter2 = st1.Length;
                    label149.Text = counter2.ToString();
                    label148.Text = counter2.ToString();
                }
                else
                    Imagedocument2 = ingdoc;
                doc_type_no = 2;


                //picturedocument.Image = new Bitmap(ingdoc);
                //string ss = "";
                //string arguments = Environment.CommandLine;
                //string[] st = new string[] { };
                //st = ingdoc.Split('\\');
                ////ss = arguments.Replace("PayRollManagementSystem.vshost.exe", "");
                //ss = arguments.Replace("PayRollManagementSystem.exe", "");
                //string sss = ss.Substring(1, ss.Length - 3);

                //if (flugAdd_import == true)
                //{
                //    Imagedocument2 = Imagedocument2 + "," + sss + "Picture\\" + cmbdEmpId.Text + st[st.Length - 1];

                //    string[] st1 = new string[] { };
                //    st1 = Imagedocument2.Split(',');
                //    counter2 = st1.Length;
                //    label149.Text = counter2.ToString();
                //    label148.Text = counter2.ToString();
                //}
                //else
                //    Imagedocument2 = sss + "Picture\\" + cmbdEmpId.Text + st[st.Length - 1];

                //string path = textdocument2.Text;
                //Bitmap bp = new Bitmap(path);
                //bp.Save(sss + "Picture\\" + cmbdEmpId.Text + st[st.Length - 1]);
                flugAdd_import = false;
            }
            catch { }
        }

        private void btndocumentadd2_Click(object sender, EventArgs e)
        {
            ERPMessageBox.ERPMessage.Show("Do You Want Another Document Import ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
            if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
            {
                textdocument2.Text = "";
                picturedocument.Image = null;
                flugAdd_import = true;
                btndocumentimport2_Click(sender, e);
            }
        }

        private void btndocumentclear2_Click(object sender, EventArgs e)
        {
            try
            {

                picturedocument.Image = null;
                textdocument2.Text = "";
                try
                {
                    if (dt_document1.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt_document1.Rows.Count - 1; i++)
                        {
                            if (Convert.ToString(dt_document1.Rows[i]["document_type"]) == "2")
                            {
                                dt_document1.Rows[i]["new"] = 5;


                                dt_document1.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
                catch { }
                label148.Text = "0";
                label149.Text = "0";


                //dt_document2.Rows.Clear();

                //picturedocument.Image = null;
                //textdocument2.Text = "";

                //string[] st1 = new string[] { };
                //st1 = Imagedocument2.Split(',');

                //counter2 = st1.Length;
                //if (counter2 > 1)
                //{
                //    st1[Convert.ToInt32(label153.Text) - 1] = "";
                //    counter2 = counter2 - 1;
                //    label148.Text = counter2.ToString();
                //    label149.Text = counter2.ToString();
                //    Imagedocument2 = "";
                //    for (int i = 0; i <= st1.Length - 1; i++)
                //    {
                //        if (st1[i] != "")
                //        {
                //            if (i < st1.Length - 1 && i > 0)
                //                Imagedocument2 = Imagedocument2 + ",";

                //            Imagedocument2 = Imagedocument2 + st1[i];

                //        }
                //    }
                //    textdocument2.Text = st1[counter2];
                //    picturedocument.Image = new Bitmap(st1[counter2]);

                //}
                //else
                //{
                //    counter2 = 0;
                //    label148.Text = counter2.ToString();
                //    label149.Text = counter2.ToString();
                //    Imagedocument2 = "";
                //}
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (counter2 > 1)
                counter2 = counter2 - 1;

            DataTable dt1 = clsDataAccess.RunQDTbl("select Document_Image from tbl_Emp_DocumentImage where ID='" + cmbdEmpId.Text.Trim() + "' and Document_Type='2' ");
            if (dt1.Rows.Count >= counter2)
            {
                Imagedocument2 = Convert.ToString(dt1.Rows[counter2 - 1]["Document_Image"]);
                if (Imagedocument2 != "")
                {
                    MemoryStream stream = new MemoryStream();
                    pictureimport.Image = null;
                    byte[] image = ((byte[])dt1.Rows[counter2 - 1]["Document_Image"]);
                    stream.Write(image, 0, image.Length);
                    Bitmap bitmap = new Bitmap(stream);
                    picturedocument.Image = bitmap;
                    label149.Text = counter2.ToString();
                    label148.Text = dt1.Rows.Count.ToString();
                }
            }


            //if (counter2 > 1)
            //    counter2 = counter2 - 1;

            //if (Imagedocument2 != "")
            //{
            //    string[] st = new string[] { };
            //    st = Imagedocument2.Split(',');
            //    if (st.Length > counter2 && counter2> 0)
            //    {
            //        label149.Text = counter2.ToString();
            //        picturedocument.Image = new Bitmap(st[counter2 - 1]);
            //        textdocument2.Text = st[counter2 - 1];
            //    }
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(label148.Text) > counter2)
                counter2 = counter2 + 1;


            DataTable dt1 = clsDataAccess.RunQDTbl("select Document_Image from tbl_Emp_DocumentImage where ID='" + cmbdEmpId.Text.Trim() + "' and Document_Type='2' ");
            if (dt1.Rows.Count >= counter2)
            {
                Imagedocument2 = Convert.ToString(dt1.Rows[counter2 - 1]["Document_Image"]);
                if (Imagedocument2 != "")
                {
                    MemoryStream stream = new MemoryStream();
                    pictureimport.Image = null;
                    byte[] image = ((byte[])dt1.Rows[counter2 - 1]["Document_Image"]);
                    stream.Write(image, 0, image.Length);
                    Bitmap bitmap = new Bitmap(stream);
                    picturedocument.Image = bitmap;
                    label149.Text = counter2.ToString();
                    label148.Text = dt1.Rows.Count.ToString();
                }
            }



            //if (Convert.ToInt32(label148.Text) > counter2)
            //    counter2 = counter2 + 1;
            //if (Imagedocument2 != "")
            //{
            //    string[] st = new string[] { };
            //    st = Imagedocument2.Split(',');
            //    if (st.Length >= counter2 && counter2 > 0)
            //    {
            //        picturedocument.Image = new Bitmap(st[counter2 - 1]);
            //        textdocument2.Text = st[counter2 - 1];
            //        label149.Text = counter2.ToString();
            //    }
            //}
        }

        private void btndocumentimport3_Click(object sender, EventArgs e)
        {
            try
            {
                string ingdoc = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();
                //openFileDialog1.InitialDirectory = "Picture/";
                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;

                openFileDialog1.ShowDialog();
                ingdoc = openFileDialog1.FileName;
                textdocument3.Text = ingdoc;


                picturedocument.ImageLocation = ingdoc;
                if (flugAdd_import == true)
                {
                    Imagedocument3 = ingdoc + "," + ingdoc;

                    string[] st1 = new string[] { };
                    st1 = Imagedocument3.Split(',');
                    counter3 = st1.Length;
                    label153.Text = counter3.ToString();
                    label152.Text = counter3.ToString();
                }
                else
                    Imagedocument3 = ingdoc;

                doc_type_no = 3;

                //picturedocument.Image = new Bitmap(ingdoc);
                //string ss = "";
                //string arguments = Environment.CommandLine;
                //string[] st = new string[] { };
                //st = ingdoc.Split('\\');
                ////ss = arguments.Replace("PayRollManagementSystem.vshost.exe", "");
                //ss = arguments.Replace("PayRollManagementSystem.exe", "");
                //string sss = ss.Substring(1, ss.Length - 3);

                //if (flugAdd_import == true)
                //{
                //    Imagedocument3 = Imagedocument3 + "," + sss + "Picture\\" + cmbdEmpId.Text + st[st.Length - 1];

                //    string[] st1 = new string[] { };
                //    st1 = Imagedocument3.Split(',');
                //    counter3 = st1.Length;
                //    label153.Text = counter3.ToString();
                //    label152.Text = counter3.ToString();
                //}
                //else
                //    Imagedocument3 = sss + "Picture\\" + cmbdEmpId.Text + st[st.Length - 1];

                //string path = textdocument3.Text;
                //Bitmap bp = new Bitmap(path);
                //bp.Save(sss + "Picture\\" + cmbdEmpId.Text + st[st.Length - 1]);
                flugAdd_import = false;
            }
            catch { }
        }

        private void btndocumentadd3_Click(object sender, EventArgs e)
        {
            ERPMessageBox.ERPMessage.Show("Do You Want Another Document Import ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
            if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
            {
                textdocument3.Text = "";
                picturedocument.Image = null;
                flugAdd_import = true;
                btndocumentimport3_Click(sender, e);
            }
        }

        private void btndocumentclear3_Click(object sender, EventArgs e)
        {
            picturedocument.Image = null;
            textdocument3.Text = "";
            try
            {
                if (dt_document1.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt_document1.Rows.Count - 1; i++)
                    {
                        if (Convert.ToString(dt_document1.Rows[i]["document_type"]) == "3")
                        {
                            dt_document1.Rows[i]["new"] = 5;

                            dt_document1.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
            catch { }
            label152.Text = "0";
            label153.Text = "0";



            //    picturedocument.Image = null;
            //    textdocument3.Text = "";

            //    string[] st1 = new string[] { };
            //    st1 = Imagedocument3.Split(',');

            //    counter3 = st1.Length;
            //    if (counter3 > 1)
            //    {
            //        st1[Convert.ToInt32(label153.Text) - 1] = "";
            //        counter3 = counter3 - 1;
            //        label153.Text = counter3.ToString();
            //        label152.Text = counter3.ToString();
            //        Imagedocument3 = "";
            //        for (int i = 0; i <= st1.Length - 1; i++)
            //        {
            //            if (st1[i] != "")
            //            {
            //                if (i < st1.Length - 1 && i > 0)
            //                    Imagedocument3 = Imagedocument3 + ",";

            //                Imagedocument3 = Imagedocument3 + st1[i];

            //            }
            //        }
            //        textdocument3.Text = st1[counter3];
            //        picturedocument.Image = new Bitmap(st1[counter3]);

            //    }
            //    else
            //    {
            //        counter3 = 0;
            //        label153.Text = counter3.ToString();
            //        label152.Text = counter3.ToString();
            //        Imagedocument3 = "";
            //    }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            if (counter3 > 1)
                counter3 = counter3 - 1;

            DataTable dt1 = clsDataAccess.RunQDTbl("select Document_Image from tbl_Emp_DocumentImage where ID='" + cmbdEmpId.Text.Trim() + "' and Document_Type='3' ");
            if (dt1.Rows.Count >= counter3)
            {
                Imagedocument3 = Convert.ToString(dt1.Rows[counter3 - 1]["Document_Image"]);
                if (Imagedocument3 != "")
                {
                    MemoryStream stream = new MemoryStream();
                    pictureimport.Image = null;
                    byte[] image = ((byte[])dt1.Rows[counter3 - 1]["Document_Image"]);
                    stream.Write(image, 0, image.Length);
                    Bitmap bitmap = new Bitmap(stream);
                    picturedocument.Image = bitmap;
                    label153.Text = counter3.ToString();
                    label152.Text = dt1.Rows.Count.ToString();
                }
            }

            //if (counter3 > 1)
            //    counter3 = counter3 - 1;

            //if (Imagedocument3 != "")
            //{
            //    string[] st = new string[] { };
            //    st = Imagedocument3.Split(',');
            //    if (st.Length > counter3 && counter3 > 0)
            //    {
            //        label153.Text = counter3.ToString();
            //        picturedocument.Image = new Bitmap(st[counter3 - 1]);
            //        textdocument3.Text = st[counter3 - 1];
            //    }
            //}
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToInt32(label152.Text) > counter3)
                    counter3 = counter3 + 1;


                DataTable dt1 = clsDataAccess.RunQDTbl("select Document_Image from tbl_Emp_DocumentImage where ID='" + cmbdEmpId.Text.Trim() + "' and Document_Type='2' ");
                if (dt1.Rows.Count >= counter3)
                {
                    Imagedocument3 = Convert.ToString(dt1.Rows[counter3 - 1]["Document_Image"]);
                    if (Imagedocument3 != "")
                    {
                        MemoryStream stream = new MemoryStream();
                        pictureimport.Image = null;
                        byte[] image = ((byte[])dt1.Rows[counter3 - 1]["Document_Image"]);
                        stream.Write(image, 0, image.Length);
                        Bitmap bitmap = new Bitmap(stream);
                        picturedocument.Image = bitmap;
                        label153.Text = counter3.ToString();
                        label152.Text = dt1.Rows.Count.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("No doc present");
            }

            //if (Convert.ToInt32(label152.Text) > counter3)
            //    counter3 = counter3 + 1;
            //if (Imagedocument3 != "")
            //{
            //    string[] st = new string[] { };
            //    st = Imagedocument3.Split(',');
            //    if (st.Length >= counter3 && counter3 > 0)
            //    {
            //        picturedocument.Image = new Bitmap(st[counter3 - 1]);
            //        textdocument3.Text = st[counter3 - 1];
            //        label153.Text = counter3.ToString();
            //    }
            //}
        }

        public Boolean chkPrevRecord(string PF, string ESI, string UAN, string PanNo, string AadharNo, string EmpFName, string EmpMName, string EmpLName, string FathFN, string FathMN, string FathLN,int tp)
        {
            Boolean boolStatus = false;
            int cnt = 0;
            //string[] dateonly = EDOB.Split(' ');
            //string vdt = dateonly[0];

            string opt = "";
            //PF.Replace('xxxx','****');
            if (PF.Trim() != "****" && PF.Trim() != "xxxx")
            {
                opt = "where (PF='" + PF + "')";

            }
            if (ESI.Trim() != "****" && ESI.Trim() != "xxxx")
            {
                if (opt == "")
                    opt = "where (ESIno='" + ESI + "')";
                else
                {
                    opt = opt + " or (ESIno='" + ESI + "')";
                }
            }
            if (UAN.Trim() != "****" && UAN.Trim() != "xxxx")
            {
                if (opt == "")
                    opt = "where (PassportNo='" + UAN.Trim() + "')";
                else
                {
                    opt = opt + " or (PassportNo='" + UAN.Trim() + "')";
                }
            }
            if (PanNo.Trim() != "")
            {
                if (opt == "")
                    opt = "where (PANno='" + PanNo + "')";
                else
                {
                    opt = opt + " or (PANno='" + PanNo + "')";
                }
            }

            if (AadharNo.Trim() != "")
            {
                if (opt == "")
                    opt = "where (aadhar='" + AadharNo + "')";
                else
                {
                    opt = opt + " or (aadhar='" + AadharNo + "')";
                }
            }
            //if (EDOJ.Trim() != "")
            //{
            //    if (opt == "")
            //        opt = "where (CONVERT(VARCHAR(11),DateOfBirth,103)='" + EDOJ + "')";
            //    else
            //    {
            //        opt = opt + " and (CONVERT(VARCHAR(11),DateOfBirth,103)='" + EDOJ + "')"
            //    }
            //}

            if (opt != "")
            {
                cnt = Convert.ToInt32(clsDataAccess.ReturnValue("select count(*) from tbl_Employee_Mast " + opt));
            }
            
            if (cnt == 0 && tp==1)
            {/*
                cnt = Convert.ToInt32(clsDataAccess.ReturnValue("Select count (*) from tbl_Employee_Mast where (lower(ltrim(rtrim(FirstName)))='" + EmpFName.Trim().ToLower() +
            "') and (lower(ltrim(rtrim(MiddleName)))='" + EmpMName.Trim().ToLower() + "') and (lower(ltrim(rtrim(LastName)))='" + EmpLName.Trim().ToLower() +
            "') and (lower(ltrim(rtrim(FathFN)))='" + FathFN.Trim().ToLower() + "') and (lower(ltrim(rtrim(FathMN)))='" + FathMN.Trim().ToLower() +
            "') and (lower(ltrim(rtrim(FathLN)))='" + FathLN.Trim().ToLower() + "') and (CONVERT(VARCHAR(11),DateOfBirth,103)='" + chk_dt(EDOB) + "')"));
           */ }
            else if (cnt > 1)
            {
               
                cnt = 0;

            }
            if (cnt > 0)
            {
                boolStatus = true;
            }
            return boolStatus;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation() && ValidateEmailId())
            {
                string tp=""; double emp_id=0;
                edpcon.Open();
                cmd.Connection = edpcon.mycon;
                sqltran = edpcon.mycon.BeginTransaction();

                if (rdbTrans_Bank.Checked == true)
                {
                    if (txtBankAC.Text.Trim() == "" || txtGMI.Text.Trim() == "")
                    {
                        MessageBox.Show("Bank Name / Account Number / IFSC Code is missing. Please Modify","BRAVO",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (ChekExRecordByEmpId_Update())
                {
                    tp = "U";
                    emp_id = Convert.ToDouble(clsDataAccess.RunQDTbl("select code from tbl_Employee_Mast emp where (emp.ID='" + cmbdEmpId.Text.Trim() + "') and (emp.Company_id='"+cmbcopany.ReturnValue.Trim()+"')").Rows[0][0]);
                }
                else
                {
                    tp = "I";
                    emp_id = 0;
                }


                if ( btnSave.Text.ToLower() == "save")
                {
                    if (Convert.ToDouble(clsDataAccess.GetresultS("select code from tbl_Employee_Mast emp where (emp.ID='" + cmbdEmpId.Text.Trim() + "') and (emp.Company_id='" + cmbcopany.ReturnValue.Trim() + "')")) > 0)
                    {
                        MessageBox.Show("Employee Code already Present, Please Change", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }

                if (chk_permission(tp, emp_id) == true)
                {



                    if (SubmitPersonalDetails() && SubmitQualification() && SubmitFamilyDetails() && SubmitOthersDetails())
                    {
                        try
                        {
                            SubmitFingerScans();
                        }
                        catch { }
                        sqltran.Commit();
                        edpcon.Close();

                       // tabControl1.SelectedTab = tabControl1.TabPages["tabPersonal"];//tabPersonal;
                        ERPMessageBox.ERPMessage.Show("Employee Details Submitted Successfully.");
                        ClearAll();
                        strMode = "";

                    }
                    else
                    {
                        sqltran.Rollback();
                        if (strMode != "update")
                        {
                            //Boolean boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Mast where (ID='" + cmbdEmpId.Text.Trim() + "') and (Session='" + cmbYear.Text.Trim() + "')");
                            //boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Other_Reff where (ID='" + cmbdEmpId.Text.Trim() + "')");
                            //boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_QualificationDetails where (ID='" + cmbdEmpId.Text.Trim() + "')");
                            //boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_FamilyDetails where (ID='" + cmbdEmpId.Text.Trim() + "')");
                            //boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Emp_DocumentImage where (ID='" + cmbdEmpId.Text.Trim() + "')");
                            //boolStatus = clsDataAccess.RunNQwithStatus("DELETE FROM tbl_employee_fscan where (ID='" + cmbdEmpId.Text.Trim() + "')");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Employee Limit Reached in your version right now." + Environment.NewLine + "Please contact support@edpsoft.com or" + Environment.NewLine + "Call : 033-40003855", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    strMode = "";

                }
                cmbdEmpId.Text = get_EmpNo();

            }
        }

        private void cmbEmpTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbEmpTitle.DroppedDown = true;
            }
        }

        private void cmbFatherTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbFatherTitle.DroppedDown = true;
            }
        }

        private void cmbMotherTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbMotherTitle.DroppedDown = true;
            }
        }

        private void cmbMaritalStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbMaritalStatus.DroppedDown = true;
            }
        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbGender.DroppedDown = true;
            }
        }

        private void cmbreligion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbreligion.DroppedDown = true;
            }
        }

        private void cmbCast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbCast.DroppedDown = true;
            }
        }

        private void cmbprestate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbprestate.DroppedDown = true;
            }
        }

        private void cmbprecountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbprecountry.DroppedDown = true;
            }
        }

        private void cmbperstate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbperstate.DroppedDown = true;
            }
        }

        private void cmbpercountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbpercountry.DroppedDown = true;
            }
        }

        private void comdocumet1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                comdocumet1.DroppedDown = true;
            }
        }

        private void comdocumet2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                comdocumet2.DroppedDown = true;
            }
        }

        private void comdocumet3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                comdocumet3.DroppedDown = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabPersonal)
            {
                cmbEmpTitle.Focus();
                return;
            }
            if (tabControl1.SelectedTab == tabOther)
            {       txtemername.Focus();
                     return;
            }
        
            if (tabControl1.SelectedTab == tabinformation)
            {   textBox25.Focus();
                 return;
            }
            if (tabControl1.SelectedTab == tabreference)
            {   txtname1.Focus();
            return;
            }
            if (tabControl1.SelectedTab == tabImport)
            {
                button2.Focus();
                return;
            }
            if (tabControl1.SelectedTab == tabPfEsi)
            {
                txtPF.Focus();
                string ename = "";
                if (txtEmpFName.Text.Trim() != "")
                {
                    ename = txtEmpFName.Text.Trim();
                    if (txtEmpMName.Text.Trim() != "")
                    {
                        ename = ename.Trim() + " " + txtEmpMName.Text.Trim();
                    }
                    if (txtEmpLName.Text.Trim() != "")
                    {
                        ename = ename.Trim() + " " + txtEmpLName.Text.Trim();
                    }

                }

                if (txtPfName.Text.Trim() == "")
                {
                    txtPfName.Text = ename;
                }
                if (txtEsiName.Text.Trim() == "")
                {
                    txtEsiName.Text = ename;
                }
                if (txtbankAcName.Text.Trim() == "")
                {
                    this.txtbankAcName.Text = ename;
                }
            }
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    int tabcount = tabControl1.TabCount - 1;
                    if (tabcount == tabControl1.SelectedIndex)
                        tabControl1.SelectedIndex = 0;
                    else
                        tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
                }
            }
            catch { }
        }



        private void picturedocument_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
                 MemoryStream ms = new MemoryStream();
                //picturedocument.Image.Save(ms, ImageFormat.Jpeg);


                Image img2 = (Image)picturedocument.Image.Clone();
                img2.Save(ms, ImageFormat.Jpeg);
                img2.Dispose();
                byte[] byteArray = ms.ToArray();
                ms.Close();
                ms.Dispose();


              //  byte[] photo_aray = new byte[ms.Length];
                
                //ms.Position = 0;
                if (byteArray.Length > 1000000)
                {
                    MessageBox.Show("Image Size is Greater than 1MB, it should be lower", "Bravo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    picturedocument.Image = null;
                    return;
                }
            try
            {
                if (picturedocument.Image != null)
                {
                    int co = dt_document1.Rows.Count;
                    dt_document1.Rows.Add();
                    dt_document1.Rows[co]["ID"] = cmbdEmpId.Text;
                    dt_document1.Rows[co]["document_type"] = doc_type_no.ToString();


                    //MemoryStream ms = new MemoryStream();
                    //picturedocument.Image.Save(ms, ImageFormat.Jpeg);
                    //byte[] photo_aray = new byte[ms.Length];
                    //ms.Position = 0;
                    //ms.Read(photo_aray, 0, photo_aray.Length);
                    dt_document1.Rows[co]["Image1"] = picturedocument.ImageLocation;
                    dt_document1.Rows[co]["new"] = 1;

                    //counter = counter + 1;
                    //label35.Text = counter.ToString();
                    //label36.Text = counter.ToString();

                }
            }
            catch { }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClearAll();
            //get_EmpNo();
            cmbdEmpId.Text = get_EmpNo();
        }

        public int get_compID(string name)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select CO_CODE from company where co_name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        private void cmblocation_DropDown(object sender, EventArgs e)
        {
            if (cmbcopany.Text.Trim() != "")
            {
                DataTable dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID in(select Location_ID from Companywiseid_Relation where Company_ID='" + Company_id + "' )");
                if (dt.Rows.Count > 0)
                {
                    cmblocation.LookUpTable = dt;
                    cmblocation.ReturnIndex = 1;
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Please select Company name .");
                cmblocation.Text = "";
                cmbcopany.Focus();

            }


        }

        private void cmblocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmblocation.ReturnValue) == true)
            {
                Loc_id = Convert.ToInt32(cmblocation.ReturnValue);


                DataTable dt = clsDataAccess.RunQDTbl("Select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName,Cliant_ID as ClientID from tbl_Emp_Location EL where Location_ID in(select Location_ID from Companywiseid_Relation where Company_ID=" + Company_id + " and Location_ID=" + Loc_id + ")");
                if (dt.Rows.Count > 0)
                    {
                        cmbClient.LookUpTable = dt;
                        cmbClient.ReturnIndex = 1;

                        cmbClient.Text = dt.Rows[0][0].ToString();
                    }
            }
        }

        private void cmbcopany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {

                dt = clsDataAccess.RunQDTbl("SELECT Distinct c.CO_NAME as 'Company',c.CO_CODE as Code,isNull(b.BRNCH_CITY,'') AS 'CITY',isNull((SELECT State_Name FROM StateMaster WHERE (STATE_CODE = b.BRNCH_STATE)),'') AS 'STATE', isNull(b.BRNCH_TELE1,'') AS contact, isNull(b.Email,'') as Email,isNull( b.GSTINNO,'')'GSTIN' FROM Company AS c FULl OUTER JOIN Branch AS b ON c.CO_CODE = b.GCODE where co_code in (select cr.Company_ID from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ")) order by c.co_code");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("SELECT Distinct c.CO_NAME as 'Company',c.CO_CODE as Code,isNull(b.BRNCH_CITY,'') AS 'CITY',isNull((SELECT State_Name FROM StateMaster WHERE (STATE_CODE = b.BRNCH_STATE)),'') AS 'STATE', isNull(b.BRNCH_TELE1,'') AS contact, isNull(b.Email,'') as Email,isNull( b.GSTINNO,'')'GSTIN' FROM Company AS c FULl OUTER JOIN Branch AS b ON c.CO_CODE = b.GCODE order by c.co_code");
            }
            //clsDataAccess.RunQDTbl("SELECT Distinct c.CO_NAME as 'Company',c.CO_CODE as Code,isNull(b.BRNCH_CITY,'') AS 'CITY',isNull((SELECT State_Name FROM StateMaster WHERE (STATE_CODE = b.BRNCH_STATE)),'') AS 'STATE', isNull(b.BRNCH_TELE1,'') AS contact, isNull(b.Email,'') as Email,isNull( b.GSTINNO,'')'GSTIN' FROM Company AS c FULl OUTER JOIN Branch AS b ON c.CO_CODE = b.GCODE where co_code in (select cr.Company_ID from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ")) order by c.co_code");
                //("Select CO_NAME,CO_CODE,'','','','' from Company");
            if (dt.Rows.Count > 0)
            {
                cmbcopany.LookUpTable = dt;
                cmbcopany.ReturnIndex = 1;
            }
        }

        private void cmbcopany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcopany.ReturnValue) == true)
            {
                Company_id = Convert.ToInt32(cmbcopany.ReturnValue);
                cmbdEmpId.Text = get_EmpNo();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            picturedocument.Width = picturedocument.Width+ 5;
            picturedocument.Height = picturedocument.Height + 5;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            picturedocument.Width = picturedocument.Width- 5;
            picturedocument.Height = picturedocument.Height - 5;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

            picturedocument.Location = new System.Drawing.Point(-hScrollBar1.Value, 20);

            //Graphics g = picturedocument.CreateGraphics();
            //g.DrawImage(picturedocument.Image, new Rectangle(0, 0, picturedocument.Height, hScrollBar1.Value));
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            picturedocument.Location = new System.Drawing.Point(30, -vScrollBar1.Value);
        }

        private Int32 GetDesgId(String strDesignation)
        {
            Int32 intDesgId = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select SlNo from tbl_Employee_DesignationMaster where DesignationName='" + strDesignation + "'", edpcon.mycon, sqltran);
            if (dt.Rows.Count > 0)
            {
                intDesgId = Convert.ToInt32(dt.Rows[0]["SlNo"]);
            }
            return intDesgId;
        }
        private Int32 GetJobTypeId(String strJobType)
        {
            Int32 intJobId = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select SlNo from tbl_Employee_JobType where JobType='" + strJobType + "'", edpcon.mycon, sqltran);
            if (dt.Rows.Count > 0)
            {
                intJobId = Convert.ToInt32(dt.Rows[0]["SlNo"]);
            }
            return intJobId;
        }

        private Int32 GetStatID(string strSecname)
        {
            Int32 salid = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select STATE_CODE from StateMaster where STATE_Name='" + strSecname + "'", edpcon.mycon, sqltran);
            if (dt.Rows.Count > 0)
            {
                salid = Convert.ToInt32(dt.Rows[0]["STATE_CODE"]);
            }
            return salid;
        }

        private Int32 GetCountryID(string strSecname)
        {
            Int32 salid = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select Country_CODE from Country where Country_Name='" + strSecname + "'", edpcon.mycon, sqltran);
            if (dt.Rows.Count > 0)
            {
                salid = Convert.ToInt32(dt.Rows[0]["Country_CODE"]);
            }
            return salid;
        }

        private void cmbtype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbtype.DroppedDown = true;
            }
        }

        private void dtpDOR_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbcopany_Load(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by CO_CODE");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count == 1)
                {
                    cmbcopany.Text = Convert.ToString(dt.Rows[0]["CO_NAME"]);
                    Company_id = Convert.ToInt32(dt.Rows[0]["CO_CODE"]);
                }
            }
        }

        
        private void cmbStaus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStaus.SelectedItem == "1")
            {
                chk_active.Checked = true;
            }
            else
            {
                chk_active.Checked = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmStatusLog stlog = new frmStatusLog();
            stlog.ShowDialog();
             //frmHelp fh = new frmHelp();
            //fh.ShowDialog();
        }

        private void rdbTrans_Cash_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtEmpFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearBioScan()
        {
            Imagepath = "";
            imgLface.Image = Properties.Resources.blank2;
            txtLface.Text = "";
            imgRFace.Image = Properties.Resources.blank2;
            txtRface.Text = "";

            imgLeft0.Image = Properties.Resources.blank2;
            txtLF0.Text = "";
            imgLeft1.Image = Properties.Resources.blank2;
            txtLF1.Text = "";
            imgLeft2.Image = Properties.Resources.blank2;
            txtLF2.Text = "";
            imgLeft3.Image = Properties.Resources.blank2;
            txtLF3.Text = "";
            imgLeft4.Image = Properties.Resources.blank2;
            txtLF4.Text = "";

            imgRight0.Image = Properties.Resources.blank2;
            txtRF0.Text = "";
            imgRight1.Image = Properties.Resources.blank2;
            txtRF1.Text = "";
            imgRight2.Image = Properties.Resources.blank2;
            txtRF2.Text = "";
            imgRight3.Image = Properties.Resources.blank2;
            txtRF3.Text = "";
            imgRight4.Image = Properties.Resources.blank2;
            txtRF4.Text = "";

            imgSig.Image = Properties.Resources.blank2;
            txt_img_sig.Text = "";
        }


        private void btnDelLface_Click(object sender, EventArgs e)
        {
            imgLface.Image = Properties.Resources.blank2;
            txtLface.Text = ""; Imagepath = "";
            
        }
        private void btnDelRface_Click(object sender, EventArgs e)
        {
            imgRFace.Image = Properties.Resources.blank2;
            txtRface.Text = ""; Imagepath = "";
        }
        private void btnImpLface_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();
                
                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtLface.Text = Imagepath;
                imgLface.ImageLocation = Imagepath;

            }
            catch { }
        }
        private void btnImpRface_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();

                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtRface.Text = Imagepath;
                imgRFace.ImageLocation = Imagepath;

            }
            catch { }
        }
        //=========================================================================================
        private void btnL0imp_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();

                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtLF0.Text = Imagepath;
                imgLeft0.ImageLocation = Imagepath;

            }
            catch { }
        }
        private void btnL0Del_Click(object sender, EventArgs e)
        {
            imgLeft0.Image = Properties.Resources.blank2;
            txtLF0.Text = ""; Imagepath = "";
        }
        //=========================================================================================
        private void btnL1imp_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();

                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtLF1.Text = Imagepath;
                imgLeft1.ImageLocation = Imagepath;

            }
            catch { }

        }
        private void btnL1Del_Click(object sender, EventArgs e)
        {
            imgLeft1.Image = Properties.Resources.blank2;
            txtLF1.Text = ""; Imagepath = "";
        }
        //=========================================================================================
        private void btnL2imp_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();

                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtLF2.Text = Imagepath;
                imgLeft2.ImageLocation = Imagepath;

            }
            catch { }
        }
        private void btnL2Del_Click(object sender, EventArgs e)
        {
            imgLeft2.Image = Properties.Resources.blank2;
            txtLF2.Text = ""; Imagepath = "";
        }

        //=========================================================================================
        private void btnL3imp_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();

                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtLF3.Text = Imagepath;
                imgLeft3.ImageLocation = Imagepath;

            }
            catch { }
        }
        private void btnL3Del_Click(object sender, EventArgs e)
        {
            imgLeft3.Image = Properties.Resources.blank2;
            txtLF3.Text = ""; Imagepath = "";
        }
        //=========================================================================================
        private void btnL4imp_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();

                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtLF4.Text = Imagepath;
                imgLeft4.ImageLocation = Imagepath;

            }
            catch { }
        }
        private void btnL4Del_Click(object sender, EventArgs e)
        {
            imgLeft4.Image = Properties.Resources.blank2;
            txtLF4.Text = ""; Imagepath = "";
        }
        //=========================================================================================
        private void btnR0imp_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();

                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtRF0.Text = Imagepath;
                imgRight0.ImageLocation = Imagepath;

            }
            catch { }
        }
        private void btnR0Del_Click(object sender, EventArgs e)
        {
            imgRight0.Image = Properties.Resources.blank2;
            txtRF0.Text = ""; Imagepath = "";
        }
        //=========================================================================================
        private void btnR1imp_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();

                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtRF1.Text = Imagepath;
                imgRight1.ImageLocation = Imagepath;

            }
            catch { }
        }
        private void btnR1Del_Click(object sender, EventArgs e)
        {
            imgRight1.Image = Properties.Resources.blank2;
            txtRF1.Text = ""; Imagepath = "";
        }
        //=========================================================================================
        private void btnR2imp_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();

                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtRF2.Text = Imagepath;
                imgRight2.ImageLocation = Imagepath;

            }
            catch { }
        }
        private void btnR2Del_Click(object sender, EventArgs e)
        {
            imgRight2.Image = Properties.Resources.blank2;
            txtRF2.Text = ""; Imagepath = "";
        }
        //=========================================================================================
        private void btnR3imp_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();

                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtRF3.Text = Imagepath;
                imgRight3.ImageLocation = Imagepath;

            }
            catch { }
        }
        private void btnR30Del_Click(object sender, EventArgs e)
        {
            imgRight3.Image = Properties.Resources.blank2;
            txtRF3.Text = ""; Imagepath = "";
        }
        //=========================================================================================
        private void btnR4imp_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();

                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txtRF4.Text = Imagepath;
                imgRight4.ImageLocation = Imagepath;

            }
            catch { }
        }
        private void btnR4Del_Click(object sender, EventArgs e)
        {
            imgRight4.Image = Properties.Resources.blank2;
            txtRF4.Text = ""; Imagepath = "";
        }

        private void tabPersonal_Click(object sender, EventArgs e)
        {

        }

        private void btnimpSig_Click(object sender, EventArgs e)
        {
            try
            {
                Imagepath = "";
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog1.Reset();

                string fileName = (appPath + "\\Picture\\empimg");
                openFileDialog1.InitialDirectory = fileName;
                openFileDialog1.ShowDialog();
                Imagepath = openFileDialog1.FileName;
                txt_img_sig.Text = Imagepath;
                imgSig.ImageLocation = Imagepath;

            }
            catch { }
        }

        private void btnDelSig_Click(object sender, EventArgs e)
        {
            imgSig.Image = Properties.Resources.blank2;
            txt_img_sig.Text = ""; Imagepath = "";
        }

        private void EmpJoining_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to close the form?", "Employee Joining", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                // Cancel the Closing event from closing the form.
                e.Cancel = true; close_frm = 1;
                // Call method to save file...
            }
            else
            {
                close_frm = 0;
                edpcom.UpdateMidasLog(this, true);
            }
        }

        private void btn_print_kyc_Click(object sender, EventArgs e)
        {
            DataTable dt_Eimg = new DataTable();

            string str = "select (SELECT Distinct ID FROM tbl_Employee_Mast where ID=edi.ID)ID," +
            "(SELECT Distinct ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End))as 'ename' FROM tbl_Employee_Mast where ID=edi.ID)ename," +
            "(case when Document_Type=1 then 'Document '+cast(Document_Type AS nvarchar ) + '  -  ' + (select Document_Titel from tbl_Employee_Mast where ID=edi.ID) else (case when Document_Type=2 then 'Document '+cast(Document_Type AS nvarchar ) + '  -  ' + (select Document_Titel2 from tbl_Employee_Mast where ID=edi.ID) else (case when Document_Type=3 then 'Document '+cast(Document_Type AS nvarchar ) + '  -  ' + (select Document_Titel3 from tbl_Employee_Mast where ID=edi.ID) else '' end) end) end)+' - Slot '+cast(ROW_NUMBER() OVER (PARTITION BY document_type ORDER By document_type,sl_no) as nvarchar) Document_Type," +
            "Document_Image from tbl_Emp_DocumentImage edi where ID='" + cmbdEmpId.Text.Trim() + "' order by Document_Type,Sl_no";
            DataTable dtEimg = clsDataAccess.RunQDTbl(str);

            MidasReport.Form1 f1 = new MidasReport.Form1();
            f1.kycDoc(dtEimg);
            f1.ShowDialog();

            //for (int i = 0; i < dtEimg.Rows.Count; i++)
            //{
            //    if (dtEimg.Rows[i]["Document_Type"].ToString() == "1")
            //    {
            //        dtEimg.Rows[i]["Document_Type"] = clsDataAccess.GetresultS("select Document_Titel from tbl_Employee_Mast where ID='" + cmbdEmpId.Text.Trim() + "'");
            //    }
            //    if (dtEimg.Rows[i]["Document_Type"].ToString() == "2")
            //    {
            //        dtEimg.Rows[i]["Document_Type"] = clsDataAccess.GetresultS("select Document_Titel2 from tbl_Employee_Mast where ID='" + cmbdEmpId.Text.Trim() + "'");
            //    }
            //    if (dtEimg.Rows[i]["Document_Type"].ToString() == "3")
            //    {
            //        dtEimg.Rows[i]["Document_Type"] = clsDataAccess.GetresultS("select Document_Titel3 from tbl_Employee_Mast where ID='" + cmbdEmpId.Text.Trim() + "'");
            //    }
            //}
        }
        DataTable dt_bnk_emp = new DataTable();
        private void txtbank_DropDown(object sender, EventArgs e)
        {
            string sql = "SELECT ROW_NUMBER() OVER ( ORDER By bank_name)slno,Bank_Name,Branch_Name, IFSC FROM "+
            "(SELECT DISTINCT TOP (100) PERCENT Bank_Name, Branch_Name, GMIno AS IFSC FROM tbl_Employee_Mast WHERE (Bank_Name <> '') AND (Branch_Name <> '') AND (GMIno <> '') ORDER BY Bank_Name) AS e";
                
                //"SELECT DISTINCT Bank_Name, Branch_Name, GMIno FROM tbl_Employee_Mast WHERE (Bank_Name <> '')";
            DataTable dt = clsDataAccess.RunQDTbl(sql);
            dt_bnk_emp = dt.Copy();
            if (dt.Rows.Count > 0)
            {
                txtbank.LookUpTable = dt;
                txtbank.ReturnIndex = 0;
            }
        }

        private void txtbank_CloseUp(object sender, ComboDialog.CloseUpEventArgs e)
        {
            Int32 bid = 0;
            if (Information.IsNumeric(txtbank.ReturnValue) == true)
                bid =Convert.ToInt32(txtbank.ReturnValue)-1;
            try
            {
                txtbank.Text = dt_bnk_emp.Rows[Convert.ToInt32(bid)]["Bank_Name"].ToString().Trim();
            }
            catch { txtbank.Text = ""; }
            try
            {
                txtbranch.Text = dt_bnk_emp.Rows[Convert.ToInt32(bid)]["Branch_Name"].ToString().Trim();
            }
            catch { txtbranch.Text = ""; }

            try
            {
                txtGMI.Text = dt_bnk_emp.Rows[Convert.ToInt32(bid)]["IFSC"].ToString().Trim();
            }
            catch { txtGMI.Text = ""; }

        }

        private void cmbDept_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT ROW_NUMBER() OVER ( ORDER By Department)slno,Department FROM "+
            "(SELECT dept as Department FROM tbl_Employee_Mast WHERE (dept <> '')) e");
            dt_bnk_emp = dt.Copy();
            if (dt.Rows.Count > 0)
            {
                cmbDept.LookUpTable = dt;
                cmbDept.ReturnIndex = 0;
            }
        }

        private void cmbDept_CloseUp(object sender, ComboDialog.CloseUpEventArgs e)
        {
            Int32 did = 0;
            if (Information.IsNumeric(cmbDept.ReturnValue) == true)
                did = Convert.ToInt32(cmbDept.ReturnValue) - 1;
          
            try
            {
                cmbDept.Text = dt_bnk_emp.Rows[did]["Department"].ToString().Trim();
            }
            catch { cmbDept.Text = ""; }
        }

        private void btnAadhar_Click(object sender, EventArgs e)
        {
            //==================== 16/08/2018 search by aadhar ======================
            frmSearch_by_Aadhar sba = new frmSearch_by_Aadhar();
            sba.ShowDialog();
            if (sba.eid != "")
            {
                cmbdEmpId.Text = sba.eid;

                counter = 1;
                pictureimport.Image = null;
                texpath.Text = "";
                picturedocument.Image = null;
                textdocument.Text = "";
                flugAdd_import = false;
                Imagedocument = "";
                Imagepath = "";
                //------------------------------------------------------------
                ClearPersonalDetailsExceptEmpId();
                if (ChekExRecordByEmpId())
                {
                    edpcom.InsertMidasLog(this, true, "view", cmbdEmpId.Text.Trim());
                    cmbdEmpId.ReadOnly = true;
                    cmbdEmpId.Enabled = false;
                    cmbdEmpId.BackColor = Color.LightGray;
                    GetPersonalDetails();
                    GetQualificationDetails();
                    GetFamilyDetails();
                    SetPenssionAge();
                    GetempDetails();
                    GetFScan();
                    cmbYear.Focus();
                    btnSave.Text = "Update";
                }
                //-----------------------------------------------------------------
            }

        }

        private void txtaadhar_Leave(object sender, EventArgs e)
        {
            if (txtaadhar.Text.Trim() != "")
            {
                string msg = "";
                if (btnSave.Text.ToLower() == "save")
                {
                    msg = "";
                    DataTable rw_total = clsDataAccess.RunQDTbl("select ID FROM tbl_Employee_Mast where (aadhar='" + txtaadhar.Text + "' or aadhar='" + txtaadhar.Text.Replace(" ", "") + "')");
                    if (rw_total.Rows.Count > 0)
                    {
                        for (int id = 0; id < rw_total.Rows.Count; id++)
                        {
                            if (msg == "")
                            {
                                msg = rw_total.Rows[id]["ID"].ToString().Trim();

                            }
                            else
                            {
                                msg = msg + Environment.NewLine + rw_total.Rows[id]["ID"].ToString().Trim();
                            }
                        }
                        if (msg!="")
                        MessageBox.Show("Aadhar Number is tagged with IDs : "+Environment.NewLine + msg, "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        btnSave.Enabled=true;
                    }
                }
                else
                {
                    msg = "";
                    DataTable rw_total = clsDataAccess.RunQDTbl("select ID FROM tbl_Employee_Mast where (ID!='" + cmbdEmpId.Text.Trim() + "') and (aadhar='" + txtaadhar.Text + "' or aadhar='" + txtaadhar.Text.Replace(" ", "") + "')");
                    if (rw_total.Rows.Count > 0)
                    {
                        for (int id = 0; id < rw_total.Rows.Count; id++)
                        {
                            if (msg == "")
                            {
                                msg = rw_total.Rows[id]["ID"].ToString().Trim();
                            }
                            else
                            {
                                msg = msg + Environment.NewLine + rw_total.Rows[id]["ID"].ToString().Trim();
                            }

                        }
                        if (msg != "")
                            MessageBox.Show("Aadhar Number is tagged with IDs : " + Environment.NewLine + msg, "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                        btnSave.Enabled = false;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                    }

                }
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPoliceStation_DropDown(object sender, EventArgs e)
        {
            Get_ps();
        }

        public void add_ps()
        {
            bool boolstatus = false;
            if (txtPoliceStation.ReturnValue == "0")
            {
                String strSlNo = clsDataAccess.ReturnValue("SELECT Max(psid) FROM PS_Master");
                String strCategory = Convert.ToString(txtPoliceStation.Text.Trim());
                String stradd = Convert.ToString(txtPS_Address.Text.Trim());
                String strjur = Convert.ToString(txtprepin.Text.Trim());
                boolstatus = clsDataAccess.RunNQwithStatus("insert into PS_Master(PoliceStation,address,jurisdiction,psid) values('" + strCategory + "','" + stradd + "','" + strjur + "','" + strSlNo + "')");
            }
            else// if ()
            {

            }

        }

        public void Get_ps()
        {
            DataTable dtps = clsDataAccess.RunQDTbl("SELECT  psid, PoliceStation, address + (case when dist!='' then ',' + dist else '' end )+ (case when state!='' then ',' + state else '' end ) + (case when zip!='' then ',' + zip else '' end ) address, jurisdiction FROM PS_Master where (jurisdiction like '%" + txtprepin.Text.Trim() + "%')");

            if (dtps.Rows.Count==1)
            {
                txtPoliceStation.Text = dtps.Rows[0]["PoliceStation"].ToString();
                txtPoliceStation.ReturnValue = dtps.Rows[0]["psid"].ToString();

                txtPS_Address.Text = dtps.Rows[0]["address"].ToString();
            }
            else if (dtps.Rows.Count > 1)
            {
                txtPoliceStation.LookUpTable = dtps;
                txtPoliceStation.ReturnIndex = 0;
                txtPoliceStation.PopUp();
            }
            else
            {
                txtPoliceStation.ReturnValue = "0";
                txtPoliceStation.Text = "";
                txtPS_Address.Text = "";
            }

        }
        private void txtprepin_Leave(object sender, EventArgs e)
        {
            Get_ps();

        }

       

        private void menuSave_Click(object sender, EventArgs e)
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
                            pictureimport.Image.Save(fpath + "\\" + cmbdEmpId.Text + ".jpg");

                            MessageBox.Show("Image saved in " + fpath, "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { MessageBox.Show("No Image Present", "Bravo",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
                    }
                }
            }
            else
            {
                MessageBox.Show("This feature is not available", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbl_fb_click_Click(object sender, EventArgs e)
        {
            if (lbl_msg_fb.Visible == false)
            {
                lbl_msg_fb.Visible = true;
                lbl_fb_click.Text = "Click -";
            }
            else if (lbl_msg_fb.Visible == true)
            {
                lbl_msg_fb.Visible = false;
                lbl_fb_click.Text = "Click +";
            }
        }

        private void rdbTrans_Cash_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdbTrans_Cash.Checked == true)
            {
                lblCashMode_msg.Visible = true;
                //txtbank.Enabled = false;
                //txtbranch.Enabled = false;
                //txtBankAC.Enabled = false;
                //txtGMI.Enabled = false;

            }

            else
            {
                lblCashMode_msg.Visible = false;
                //txtbank.Enabled = true;
                //txtbranch.Enabled = true;
                //txtBankAC.Enabled = true;
                //txtGMI.Enabled = true;
            }
        }

        private void rdbTrans_cheque_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTrans_cheque.Checked == true)
            {
                lblCashMode_msg.Visible = true;
            }
            else
            {
                lblCashMode_msg.Visible = false;
            }
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

      
       
        //=========================================================================================
    





        //     private void chk_active_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chk_active.CheckState == CheckState.Checked)
        //    {
        //        ERPMessageBox.ERPMessage.Show("Checked Employees salary cannot be genareted " + cmbdEmpId.Text.Trim() + "." + Environment.NewLine + "Are You Sure to Update  ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
        //        if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
        //        {

        //        }
        //        else
        //        {
        //            chk_active.CheckState = CheckState.Unchecked;
        //        }

        //    }
        //    else
        //    {
        //        ERPMessageBox.ERPMessage.Show("Un Checked Employees salary cann be genareted");

        //    }
        //}

        //private Int32 GetStatID(string strSecname)
        //{
        //    Int32 salid = 0;
        //    DataTable dt = clsDataAccess.RunQDTbl("select STATE_CODE from StateMaster where STATE_Name='" + strSecname + "'", edpcon.mycon, sqltran);
        //    if (dt.Rows.Count > 0)
        //    {
        //        salid = Convert.ToInt32(dt.Rows[0]["STATE_CODE"]);
        //    }
        //    return salid;
        //}


    }
}