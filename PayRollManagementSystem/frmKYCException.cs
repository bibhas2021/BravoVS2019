using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data.SqlClient;
using Edpcom;
namespace PayRollManagementSystem
{
    public partial class frmKYCException : EDPComponent.FormBaseRptMidium
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        public frmKYCException()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        int company_id = 0;
        int Location = 0;
        DataTable dtKyc = new DataTable();
        
        DataTable dts = new DataTable();
        DataTable dtid = new DataTable();
        string a = "";

        DataTable dt1 = new DataTable();



        private void frmKYCException_Load(object sender, EventArgs e)
        {

            clsValidation.GenerateYear(CmbSession, 2014, System.DateTime.Now.Year, 1);
            if (System.DateTime.Now.Month >= 4)
            {
                CmbSession.SelectedIndex = 0;
            }
            else
            {
                CmbSession.SelectedIndex = 1;
            }

            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbcompany.Text = Convert.ToString(dt_co.Rows[0][0]);

                company_id = Convert.ToInt32(dt_co.Rows[0][1]);
                cmbcompany.ReturnValue = company_id.ToString();
                cmbcompany.Enabled = false;
                //cmbLoc.Enabled = false;

            }
            else if (dt_co.Rows.Count > 1)
            {
                cmbcompany.PopUp();
                cmbcompany.Enabled = true;

            }
       
        }
        public void Load_Data1(string qry, ComboBox cb, int i)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {
                for (int d = 0; d < dt.Rows.Count; d++)
                {
                    cb.Items.Add(dt.Rows[d][0].ToString());
                }
                if (i >= 0)
                    cb.SelectedIndex = i;
            }
        }
        public int get_CompID(string name)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            string s = " select GCODE  from Company where CO_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        
        public int get_LocationID(string name)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select Location_ID from tbl_Emp_Location where Location_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
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
                //cmbsalstruc.Items.Clear();
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                company_id = Convert.ToInt32(cmbcompany.ReturnValue);

            //data_retrive_Company();
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            string s = " select  l.Location_Name,l.Location_ID  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and (company_ID = " + company_id + ")";
            DataTable dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                CmbLocation.LookUpTable = dt;
                CmbLocation.ReturnIndex = 1;
                //cmbsalstruc.Items.Clear();
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbLocation.ReturnValue) == true)
            {
                Location = Convert.ToInt32(CmbLocation.ReturnValue);

            }

        }

        private void BtnKycException_Click(object sender, EventArgs e)
        {
            if (cmbcompany.Text != "")
            {
                if (CmbLocation.Text != "")
                {
                    if (ChkPhoto.Checked == false && ChkIdentity.Checked == false && ChkAddressProof.Checked == false && ChkAdhar.Checked==false && ChkPassport.Checked==false)
                    {

                        MessageBox.Show("Please check any one option", "BRAVO");
                        return;
                    }
                    string br = "";
                    int val_p = 0, val_ip = 0, val_ia = 0, val_av = 0, val_ap = 0;
                    dt = clsDataAccess.RunQDTbl("select *  from tbl_employee_mast where session='" + CmbSession.Text + "' and company_id=" + get_CompID(cmbcompany.Text) + "and location_id=" + get_LocationID(CmbLocation.Text));
                    //dtid = clsDataAccess.RunQDTbl("select id from tbl_employee_masrt where session='" + CmbSession.Text + "'and company_id=" + get_CompID(cmbcompany.Text) + "and Location_id=" + get_LocationID(CmbLocation.Text));
                    //DataTable dtimg = clsDataAccess.RunQDTbl("select empimage from tbl_employee_mast where empimage is null");
                    /* string [] ar=new string[4];
                     ar[0] = "Voter id card";
                     ar[1] = "Pan Card";
                     ar[2] = "aadhar card";
                     ar[3] = "aadhar card";
                     string[] ar2 = new string[4];*/
                    List<string> tmp = new List<string>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tmp.Clear();
                        tmp.Add("voter id card");
                        tmp.Add("Pan card");
                        tmp.Add("AAdhar card");
                        tmp.Add("Passport");
                        tmp.Add("photo");

                        br = "";
                        string doc = dt.Rows[i]["document_Titel"].ToString();
                        string doc2 = dt.Rows[i]["document_Titel2"].ToString();
                        string doc3 = dt.Rows[i]["document_Titel3"].ToString();


                        string id1 = dt.Rows[i]["id"].ToString();


                        if (ChkPhoto.Checked == true)
                        {
                            val_p = 0;
                            string img = dt.Rows[i]["EmpImage"].ToString();


                            if (img == "")
                            {
                                if (br == "")
                                {
                                    br = "photo";
                                }
                                else
                                {
                                    br = br + " | " + "photo";
                                }
                                val_p = 0;
                            }
                            else
                            {
                                val_p = 1;
                                tmp.Remove("photo");

                            }


                            //dtKyc = clsDataAccess.RunQDTbl("select distinct id,'" +br + "'as documents,firstname,middlename,lastname,presentstreet,presentcity,presentareia,presentpin from tbl_employee_mast where Empimage is null and  session='" + CmbSession.Text + "'and id='" +id1 + "'and company_id=" + get_CompID(cmbcompany.Text) + " and Location_id=" + get_LocationID(CmbLocation.Text));
                        }
                        if (ChkIdentity.Checked == true)
                        {
                            val_ip = 0;

                            if (doc == "Pan card" || doc2 == "Pan card" || doc3 == "Pan card")
                            {
                                tmp.Remove("Pan card");
                                val_ip = 1;
                            }
                            else
                            {
                                val_ip = 0;

                                if (br == "")
                                {
                                    br = "Pan card";
                                }
                                else
                                {
                                    br = br + " | " + "Pan card";
                                }
                            }
                        }
                        if(ChkAdhar.Checked==true)
                        {
                            val_ia = 0;
                            if (doc == "AAdhar card" || doc2 == "AAdhar card" || doc3 == "AAdhar card")
                            {
                                tmp.Remove("AAdhar card");
                                val_ia = 2;
                            }
                            else
                            {
                                val_ia = 0;
                                if (br == "")
                                {
                                    br = "AAdhar card";
                                }
                                else
                                {
                                    br = br + " | " + "AAdhar card";
                                }
                            }


                            //dtKyc = clsDataAccess.RunQDTbl("select distinct id,'" + br + "' as Documents,firstname,middlename,lastname,presentstreet,presentcity,presentareia,presentpin from tbl_employee_mast where  Document_Titel + ' ' + Document_Titel2 + ' ' + Document_Titel3 not in('aadhar card','pan card')and  session='" + CmbSession.Text + "'and id='" + id1 + "'and company_id=" + get_CompID(cmbcompany.Text) + " and Location_id=" + get_LocationID(CmbLocation.Text));

                        }

                        if (ChkAddressProof.Checked == true)
                        {
                            val_av = 0;
                            if (doc == "voter id card" || doc2 == "voter id card" || doc3 == "voter id card")
                            {
                                tmp.Remove("voter id card");
                                val_av = 1;
                            }
                            else
                            {
                                val_ia = 0;
                                if (br == "")
                                {
                                    br = "voter id card";
                                }
                                else
                                {
                                    br = br + " | " + "voter id card";
                                }
                            }
                        }
                        if(ChkPassport.Checked==true)
                        {
                            val_ap = 0;
                            if (doc == "Passport" || doc2 == "Passport" || doc3 == "Passport")
                            {
                                tmp.Remove("Passport");
                                val_ap = 1;
                            }
                            else
                            {
                                val_ip = 0;
                                if (br == "")
                                {
                                    br = "Passport";
                                }
                                else
                                {
                                    br = br + " | " + "Passport";
                                }
                            }

                        }

                        //for (int tl = 0; tl < tmp.Count; tl++)
                        //{
                        //    if (br == "")
                        //    {
                        //        br = tmp[tl].ToString();
                        //    }
                        //    else
                        //    {
                        //        br = br + " | " + tmp[tl].ToString();
                        //    }
                        //}

                        dtKyc = clsDataAccess.RunQDTbl("select distinct id,'" + br + "' as Documents,firstname,middlename,lastname,presentstreet,presentcity,presentareia,presentpin from tbl_employee_mast where  Document_Titel + ' ' + Document_Titel2 + ' ' + Document_Titel3 not in('aadhar card','pan card')and  session='" + CmbSession.Text + "'and id='" + id1 + "' and company_id=" + get_CompID(cmbcompany.Text) + " and Location_id=" + get_LocationID(CmbLocation.Text));
                        if ((val_p == 0) || (val_ap == 0) || (val_av == 0) || (val_ia == 0) || (val_ip == 0))
                        {
                            if (br != "")
                            {
                                dts.Merge(dtKyc);
                            }
                        }


                    }


                    MidasReport.Form1 kyc = new MidasReport.Form1();
                    kyc.KycExcept(cmbcompany.Text, CmbLocation.Text, CmbSession.Text, ChkPhoto.Text + "  " + ChkIdentity.Text + "  " + ChkAddressProof.Text, dts);
                    kyc.Show();
                    dts.Clear();
                }
                else
                {
                    MessageBox.Show("Please select location");
                    return;
                }
            }
            else
            {
                MessageBox.Show("please select company");
                return;
            }

            
    }

        private void CmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /* for (int i = 0; i < dt.Rows.Count; i++)
         {
             string ar = dt.Rows[i][1].ToString().Trim();
             //string id1 = dt.Rows[i][0].ToString();
                
                 if (ar == "")
                 {
                     br = "voter id card pan card aadhar card passport";
                 }
                 else if (ar == "voter id card")
                 {
                     br = "pan card aadhar card passport";
                 }
                 else if (ar == "aadhar card")
                 {
                     br = "voter id card pan card passport";
                 }
                 else if (ar == "pan card")
                 {
                     br = "voter id card pan card passport";
                 }
                 else if (ar == "passport")
                 {
                     br = "voter id card pan card aadhar card";
                 }
                 else if (ar == "voter id card Pan card")
                 {
                     br = "aadhar card passport";
                 }
                 else if (ar == "Pan card voter id card")
                 {
                     br = "aadhar card passport";
                 }

                 else if (ar == "voter id card aadhar card")
                 {
                     br = "pan card passport";
                 }
                 else if (ar == "aadhar card voter id card")
                 {
                     br = "pan card passport";
                 }
                 else if (ar == "voter id card passport")
                 {
                     br = "pan card aadhar card";
                 }
                 else if (ar == "passport voter id card")
                 {
                     br = "pan card aadhar card";
                 }
                 else if (ar == "pan card aadhar card")
                 {
                     br = "voter id card passport";
                 }
                 else if (ar == "AAdhar card Pan card")
                 {
                     br = "voter id card passport";
                 }
                 else if (ar == "pan card Passport")
                 {
                     br = "voter id card aadhar card";
                 }
                 else if (ar == "Passport Pan Card")
                 {
                     br = "voter id card aadhar card";
                 }
                 else if (ar == "aadhar card passport")
                 {
                     br = "voter id card pan card";
                 }
                 else if (ar == "passport aadhar card")
                 {
                     br = "voter id card pan card";
                 }

                 else if (ar == "voter id card pan card aadhar card")
                 {
                     br = "Passport";

                 }
                 else if (ar == "aadhar card pan card voter id card")
                 {
                     br = "Passport";

                 }
                 else if (ar == "pan card Voter Id Card aadhar card")
                 {
                     br = "Passport";

                 }
                 else if (ar == "voter id card aadhar card passport")
                 {
                     br = "pan card";
                 }
                 else if (ar == "aadhar card pan card passport")
                 {
                     br = "voter id card";
                 }
                 else if (ar == "voter id card pan card aadhar card passport")
                 {
                     br = "";
                 }
                    
            

                if (ChkPhoto.Checked == true)
                 {
                     dtKyc = clsDataAccess.RunQDTbl("select tbl_employee_mast.ID,firstname,middlename,lastname,presentstreet,presentcity,presentareia,presentpin,Document_Titel,Document_Titel2,Document_Titel3,'photo' as documents from tbl_employee_mast where Empimage is null  and session='" + CmbSession.Text + "'and company_id=" + get_CompID(cmbcompany.Text) + " and Location_id=" + get_LocationID(CmbLocation.Text));
                 }
                 if (ChkIdentity.Checked == true)
                 {
                     dtKyc = clsDataAccess.RunQDTbl("select'" + br + "' as Documents, id,firstname,middlename,lastname,presentstreet,presentcity,presentareia,presentpin from tbl_employee_mast where  Document_Titel not in('aadhar card','pan card') and Document_Titel2 not in('aadhar card','pan card')and Document_Titel3 not in('aadhar card','pan card')and session='" + CmbSession.Text + "'and company_id=" + get_CompID(cmbcompany.Text) + " and Location_id=" + get_LocationID(CmbLocation.Text));

                 }
                 if (ChkAddressProof.Checked == true)
                 {
                     dtKyc = clsDataAccess.RunQDTbl("select'" + br + "' as Documents,id,firstname,middlename,lastname,presentstreet,presentcity,presentareia,presentpin,'addressproof' as Documents from tbl_employee_mast where Document_Titel not in('voter id card','passport') and Document_Titel2 not in('voter id card','passport')and Document_Titel3 not in('voter id card','passport')and session='" + CmbSession.Text + "'and company_id=" + get_CompID(cmbcompany.Text) + " and Location_id=" + get_LocationID(CmbLocation.Text));
                 }
                 if (ChkPhoto.Checked == false && ChkIdentity.Checked == false && ChkAddressProof.Checked == false)
                 {
                     dtKyc = clsDataAccess.RunQDTbl("select id,firstname,middlename,lastname,presentstreet,presentcity,presentareia,presentpin from tbl_employee_mast where session='" + CmbSession.Text + "'and company_id=" + get_CompID(cmbcompany.Text) + " and Location_id=" + get_LocationID(CmbLocation.Text));

                 }
                 

            
        if (ChkPhoto.Checked == true && ChkIdentity.Checked == true)
        {
            dtKyc = clsDataAccess.RunQDTbl("select id,firstname,middlename,lastname,presentstreet,presentcity,presentareia,presentpin  from tbl_employee_mast where Document_Titel not in('aadhar card','pan card') or Document_Titel2 not in('aadhar card','pan card')and Document_Titel3 not in('aadhar card','pan card') or empimage is null and session='" + CmbSession.Text + "'and company_id=" + get_CompID(cmbcompany.Text) + " and Location_id=" + get_LocationID(CmbLocation.Text));        
        }
        if (ChkPhoto.Checked == true && ChkIdentity.Checked == true && ChkAddressProof.Checked == true)
        {
            dtKyc = clsDataAccess.RunQDTbl("select id,firstname,middlename,lastname,presentstreet,presentcity,presentareia,presentpin,'photo,identity,address' as Documents from tbl_employee_mast where Document_Titel not in('aadhar card','pan card') and Document_Titel2 not in('aadhar card','pan card')and Document_Titel3 not in('aadhar card','pan card')and Document_Titel not in('voter id card','passport') and Document_Titel2 not in('voter id card','passport')and Document_Titel3 not in('voter id card','passport') or empimage is null and session='" + CmbSession.Text + "'and company_id=" + get_CompID(cmbcompany.Text) + " and Location_id=" + get_LocationID(CmbLocation.Text));
        }
        if (ChkPhoto.Checked == true && ChkAddressProof.Checked == true)
        {
            dtKyc = clsDataAccess.RunQDTbl("select id,firstname,middlename,lastname,presentstreet,presentcity,presentareia,presentpin from tbl_employee_mast where Document_Titel not in('voter id card','passport') and Document_Titel2 not in('voter id card','passport')and Document_Titel3 not in('voter id card','passport') or empimage is null and session='" + CmbSession.Text + "'and company_id=" + get_CompID(cmbcompany.Text) + " and Location_id=" + get_LocationID(CmbLocation.Text));
        }
            
           
    
   /* public string photo_identity()
    {
        dt = clsDataAccess.RunQDTbl("Select distinct ID from tbl_employee_Mast where empimage is null and session='" + CmbSession.Text + "' and company_id=" + get_CompID(cmbcompany.Text) + "and location_id=" + get_LocationID(CmbLocation.Text));
        if (dt.Rows.Count > 0)
        {
             a = "photo";
        }
        dt1 = clsDataAccess.RunQDTbl("select distinct id from tbl_employee_mast where Document_Titel not in('aadhar card','pan card') or Document_Titel2 not in('aadhar card','pan card') or Document_Titel3 not in('aadhar card' ,'pan card')and session='" + CmbSession.Text + "' and company_id=" + get_CompID(cmbcompany.Text) + "and location_id=" + get_LocationID(CmbLocation.Text));
        if (dt1.Rows.Count > 0)
        {
            a = "Identity";
        }
        return a;
    }
    
*/

    }
}


