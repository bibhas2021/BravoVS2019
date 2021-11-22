using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using EDPComponent;
using Edpcom;
using System.Collections;
using System.IO;

using FirstTimeNeed;
using System.Runtime.InteropServices;

namespace PayRollManagementSystem
{
    public partial class frmPayBill : Form 
        //EDPComponent.FormBaseERP
    {

        string Employ_ID = "", setting_type="", startPath="";
        int Company_id = 0;
        int Client_id = 0;
        int DesgID = 0;
        int cinv = 0;
        
        int SacGst = 0,btype=0;
        double Tot_GstVal = 0;

        string Locations = "", location_id="";
        int calculated_days = 0;
        EDPConnection edpcon;
        // for browse oreder purpose
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        ArrayList arr = new ArrayList();
        ArrayList array = new ArrayList();
        ArrayList arritem = new ArrayList();
        Hashtable getcode = new Hashtable();
        Hashtable getcode_Group = new Hashtable();
        Hashtable getcode_item = new Hashtable();
        Hashtable htSalHead = new Hashtable();
        Boolean bTagging = false;
        Boolean boolSalAllotmentNotFound = false;

        string Party_Code = "", Party_Group = "", t_entry = "", Item_Code = "";
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int PrvLev = 0, descode = 0;
        Label[] lbe = new Label[32];
        Label[] lbH = new Label[32];
        Label[] lbp = new Label[4];
        Boolean boolSingleDesignationBillingPermission = false;
        
        //
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        public frmPayBill()
        {
            InitializeComponent();
        }
        public int get_CompID(string name)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            string s = " select GCODE from Company where (CO_Name='" + name + "')";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        private void txtVoucherChallan_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select BILLNO,BILLDATE,Descord, (Select Co_Name from Company where Co_Code=pb.comany_id) as Company, (select Client_Name from tbl_Employee_CliantMaster where Client_id=pb.cliant_ID) as Client, (Select Location_Name from tbl_Emp_Location where Location_ID=pb.Location_ID) as Location,Session from paybill pb where (session='" + cmbYear.Text + "') order by pb.Session desc, pb.BILLNO desc");
            if (dt.Rows.Count > 0)
            {
                txtVoucherChallan.LookUpTable = dt;
                txtVoucherChallan.ReturnIndex = 2;
                txtVoucherChallan.Text = "";                
            }

        }
        private void txtVoucherChallan_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(txtVoucherChallan.ReturnValue) == true)
            {
                descode = Convert.ToInt32(txtVoucherChallan.ReturnValue);

                DataTable dtlocORdesigWiseBill = clsDataAccess.RunQDTbl("select [Location_ID],BillStatus,status,btype,BILLNO from [paybill] where (BILLNO='" + txtVoucherChallan.Text.Trim() + "')");

            if (dtlocORdesigWiseBill.Rows[0][0].ToString().Trim() != "0")
            {
                if (dtlocORdesigWiseBill.Rows[0]["btype"].ToString().Trim() == "0")
                {
                    cmbBillType.SelectedIndex = 0;
                }
                else if (dtlocORdesigWiseBill.Rows[0]["btype"].ToString().Trim() == "1")
                {
                    cmbBillType.SelectedIndex = 2;
                }

            }
            else
            {
                cmbBillType.SelectedIndex = 1;
            }
            txtVoucherChallan.Text = dtlocORdesigWiseBill.Rows[0]["BillNo"].ToString().Trim();
            DataTable dt = txtVoucherChallan.LookUpTable;
            txtVoucherChallan.ReadOnly = true;
            cmbcompany.ReadOnly = true; lblEnclosure.Text = "";
            txtVoucherChallan.BackColor = Color.LightGray;
            btnSave.Text = "Modify";
            
            //Following block has been added by dwipraj dutta 24102017
            lblprevbal.Text = "0";
            DataTable ord_dtl = clsDataAccess.RunQDTbl("select distinct ref_order_no from paybillD where (BILLNO='" + txtVoucherChallan.Text.Trim() + "')");
            if (ord_dtl.Rows.Count > 0)
            {
                try
                {
                    string encid = Convert.ToString(clsDataAccess.GetresultS("select isnull(enclosure,'') from tbl_Employee_OrderDetails where (Order_Name = '"+ ord_dtl.Rows[0]["ref_order_no"].ToString()+"')")).Replace('|', ',');

                    if (encid.Trim() == "") { lblEnclosure.Text = ""; }
                    else
                    {
                        DataTable enc = clsDataAccess.RunQDTbl("select enclosure from tbl_enclosure where eid in (" + encid + ")");
                        for (int indx = 0; indx < enc.Rows.Count; indx++)
                        {
                            if (lblEnclosure.Text.Trim() == "")
                            {
                                lblEnclosure.Text = (indx + 1) + "-" + enc.Rows[indx]["enclosure"].ToString().Trim();

                            }
                            else
                            {
                                lblEnclosure.Text = lblEnclosure.Text + Environment.NewLine + (indx + 1) + "-" + enc.Rows[indx]["enclosure"].ToString().Trim();
                            }
                        }
                    }
                }
                catch { }
            }
            try
            {
                if (dtlocORdesigWiseBill.Rows[0]["status"].ToString().Trim() == "1")
                {
                    chkAuthorise.Checked = true;
                }
                else if (dtlocORdesigWiseBill.Rows[0]["status"].ToString().Trim() == "0")
                {
                    chkAuthorise.Checked = false;
                }

                switch (dtlocORdesigWiseBill.Rows[0]["BillStatus"].ToString())
                {
                    case "CANCELED":
                        cbCancelBill.Visible = true;
                        cbCancelBill.Checked = true;
                        break;
                    case "ACTIVE":
                        cbCancelBill.Visible = true;
                        cbCancelBill.Checked = false;
                        break;
                }
                //Check if bill type Single location or single designation
                if (dtlocORdesigWiseBill.Rows[0][0].ToString().Trim() != "0")
                {
                   
                    label15.Visible = false;
                    cmbDesgName.Visible = false;

                    label12.Visible = true;
                    cmbLocation.Visible = true;
                    /*ChkServiceChaerge.Visible = true;
                    label11.Visible = true;
                    TxtPer.Visible = true;
                    sacSClbl.Visible = true;
                    sacServiceCharge.Visible = true;
                    checkBox1.Visible = true;
                    label9.Visible = true;
                    txtSTPer.Visible = true;
                    label13.Visible = false;
                    cgstPer.Visible = false;
                    rdbCharged.Visible = true;
                    rdbChargeN.Visible = true;
                    btnChange.Visible = true;
                    dgotherjob.Visible = true;*/


                    GetDetails();

                    btnPreview.Enabled = true;
                    btnPreview.Text = "Preview";
                }
                else
                {
                    cmbBillType.SelectedIndex = 1;
                    label15.Visible = true;
                    cmbDesgName.Visible = true;

                    //btnPreview.Enabled = false;
                    //btnPreview.Text = "...";
                    btnPreview.Enabled = true;
                    btnPreview.Text = "Preview";

                    label12.Visible = false;
                    cmbLocation.Visible = false;
                    /*ChkServiceChaerge.Visible = false;
                    label11.Visible = false;
                    TxtPer.Visible = false;
                    sacSClbl.Visible = false;
                    sacServiceCharge.Visible = false;
                    checkBox1.Visible = false;
                    label9.Visible = false;
                    txtSTPer.Visible = false;
                    label13.Visible = false;
                    cgstPer.Visible = false;
                    rdbCharged.Visible = false;
                    rdbChargeN.Visible = false;
                    btnChange.Visible = false;
                    dgotherjob.Visible = false;*/

                    GetDetailsDesg();
                }
            }
            catch { }

            }
            else
            {
                btnCLear_Click(sender, e);
            }
        }

        private void GetDetailsDesg()
        {
            if (dgemployjob.Rows.Count > 1)
                dgemployjob.Rows.Clear();
            dgotherjob.Rows.Clear();
            DataTable dsc = clsDataAccess.RunQDTbl("Select Descord,Session from paybill where (BILLNO='" + txtVoucherChallan.Text.ToString().Trim() + "')");
            //descode
            DataTable dt_des = clsDataAccess.RunQDTbl("select type_desc as 'Description',desccode as 'Code'  from typedoc where (ficode='1') and (gcode='1') and (t_entry='9') and (desccode='" + dsc.Rows[0]["Descord"].ToString() + "') and  (Session='" + dsc.Rows[0]["Session"].ToString() + "')");
            if (dt_des.Rows.Count > 0)
                cmbdescription.Text = Convert.ToString(dt_des.Rows[0]["Description"]);
            //bellow isGST field has been added by Dwipraj 25/07/2017 5:55PM //h.sac dwipraj dutta 19082017

            DataTable dt35 = clsDataAccess.RunQDTbl("select h.BILLDATE,(select co_name from Company where CO_CODE=h.Comany_id ) as 'coname', h.Session,(select [DesignationName] from [tbl_Employee_DesignationMaster] where [SlNo]=h.[Designation_Id] ) as 'desgname',h.Month,h.TotAMT,h.IsService,(select cl.Client_Name   from tbl_Employee_CliantMaster cl where cl.Client_id =h.Cliant_ID) as 'Client_Name',IsSC,SCPer,isRound,Cliant_ID,[Designation_Id],isScAdd,h.Comany_id,h.AUTOINCRE,h.isGST,h.ScAmt,h.ServiceAmount,(select csm.serviceName+':'+csm.sacNo as 'SACNo' from CompanySACMaster csm where csm.slno = h.SAC) as 'SAC',h.GstPer from paybill h where (h.BILLNO = '" + txtVoucherChallan.Text.ToString().Trim() + "')");
            if (dt35.Rows.Count > 0)
            {

                /*-------------------------------Added by Dwipraj Dutta 11092017 have to modify in order to make it more dynamic--------------------------------*/


                DataTable gstInfo = clsDataAccess.RunQDTbl("select distinct (select crm.GSTTYPE from Companywiseid_Relation crm where crm.Location_ID = pbd.Location_ID and crm.Company_ID = pbd.Company_id) as 'GSTTYPE' from paybillD pbd where pbd.BILLNO = '" + txtVoucherChallan.Text + "'");
                if (gstInfo.Rows.Count > 1)
                {
                    //EDPMessageBox.EDPMessage.Show("This Bill have some problems. Plase do the bill again.");
                    //return;
                }
                string gstapplicable = gstInfo.Rows[0][0].ToString().Trim();
                //string gstPercentage = clsDataAccess.RunQDTbl("select GSTPER from Branch where GCODE = " + Company_id + "").Rows[0][0].ToString().Trim();
                string gstPercentage = dt35.Rows[0]["GstPer"].ToString(); //Math.Round(100 * Convert.ToDouble(dt35.Rows[0]["ServiceAmount"]) / (Convert.ToDouble(dt35.Rows[0]["TotAMT"]) + Convert.ToDouble(dt35.Rows[0]["ScAmt"]))).ToString().Trim();
                if (Convert.ToString(dt35.Rows[0]["isGST"].ToString().Trim()) == "True" || Convert.ToString(dt35.Rows[0]["IsService"].ToString().Trim()) == "False")            //2nd condition added at 040820170148PM : Reason : If bill has no Service Tax or GST checked then by default the GST option will be appeared.
                {
                    //checkBox1.Checked = true;
                    btnChange.Visible = false;
                    if (gstapplicable == "LOCAL")
                    {
                        checkBox1.Text = "GST";
                        label9.Text = "SGST%@";
                        txtSTPer.Text = (Convert.ToDouble(gstPercentage) / 2).ToString();
                        label13.Visible = true;
                        cgstPer.Visible = true;
                        cgstPer.Text = (Convert.ToDouble(gstPercentage) / 2).ToString();
                    }
                    else
                    {
                        checkBox1.Text = "GST";
                        label9.Text = "IGST%@";
                        txtSTPer.Text = gstPercentage;
                        label13.Visible = false;
                        cgstPer.Visible = false;
                    }
                }
                else
                {
                    btnChange.Visible = true;
                    checkBox1.Text = "Service Tax";
                    label9.Text = "Service Tax % @";
                    //txtSTPer.Text = "14.5";
                    label13.Visible = false;
                    cgstPer.Visible = false;
                }
                /*-------------------------------------------------------------end of 6:04pm------------------------------------------------------------------------*/


                this.dtpto.Text = dt35.Rows[0][0].ToString().Trim();
                this.cmbcompany.Text = dt35.Rows[0][1].ToString().Trim();
                Company_id = Convert.ToInt32(dt35.Rows[0]["Comany_id"].ToString().Trim());
                this.cmbYear.Text = dt35.Rows[0][2].ToString().Trim();
                this.cmbsalstruc.Text = Convert.ToString(dt35.Rows[0][3].ToString().Trim());
                this.cmbclintname.Text = dt35.Rows[0][7].ToString().Trim();
                Client_id = Convert.ToInt32(dt35.Rows[0]["Cliant_ID"]);
                this.cmbDesgName.Text = dt35.Rows[0]["desgname"].ToString().Trim();
                DesgID = Convert.ToInt32(dt35.Rows[0]["Designation_Id"].ToString().Trim());


                lblCoid.Text = Company_id.ToString();
                lblClid.Text = Client_id.ToString();
                lblLocid.Text = location_id.ToString();

                DataTable config = new DataTable();

                if (location_id.Trim() != "")
                {
                    config = clsDataAccess.RunQDTbl("Select MOD from  Companywiseid_Relation where (Company_ID='" + Company_id + "') and (Location_ID='" + location_id + "') and (prefix<>'' or prefix  IS NOT NULL)");
                    try
                    {
                        if ((config.Rows[0]["MOD"].ToString().Trim().ToUpper() == "MONTHOFDAYS") || (config.Rows[0]["MOD"].ToString().Trim() == "0"))
                        {
                            lblMOD.Text = DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month).ToString();
                        }
                        else
                        {
                            lblMOD.Text = config.Rows[0]["MOD"].ToString();

                        }
                    }
                    catch { }

                }
                lblbid.Text = dt35.Rows[0]["AUTOINCRE"].ToString().Trim();


                
                if (Convert.ToString(dt35.Rows[0][6].ToString().Trim()) == "True" || Convert.ToString(dt35.Rows[0]["isGST"].ToString().Trim()) == "True")   //Added by dwipraj dutta 010820170638PM
                {
                    this.checkBox1.Checked = true;
                }
                else
                {
                    this.checkBox1.Checked = false;
                }

                if (Convert.ToString(dt35.Rows[0]["IsSC"].ToString().Trim()) == "True")
                {
                    this.ChkServiceChaerge.Checked = true;
                }
                else
                {
                    this.ChkServiceChaerge.Checked = false;
                }
                if (Convert.ToString(dt35.Rows[0]["IsScAdd"].ToString().Trim()) == "True")
                {
                    this.rdbCharged.Checked = true;
                }
                else
                {
                    this.rdbChargeN.Checked = true;
                }
                if (Convert.ToString(dt35.Rows[0]["IsRound"].ToString().Trim()) == "True")
                {
                    this.chkRound.Checked = false;
                }
                else
                {
                    this.chkRound.Checked = true;
                }
                this.TxtPer.Text = dt35.Rows[0]["SCPer"].ToString();


                dateTimePicker1.CustomFormat = "MMMM - yyyy";

                dateTimePicker1.Value = Convert.ToDateTime(dt35.Rows[0][4]);

                cmbmonth.Text = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

                DataTable dt = clsDataAccess.RunQDTbl("select d.Dtl_id,d.ref_order_no,d.ref_order_date,(select DesignationName from tbl_Employee_DesignationMaster where SlNo=d.desig_ID )as 'designation',d.Hour,d.MonthDays,d.Attendance,d.BILLAMT,d.RATE,(select Location_Name from tbl_Emp_Location where Location_ID=d.Location_ID ) as 'locname',(select serviceName+':'+sacNo from CompanySACMaster where slno = d.SAC) as 'SAC',d.NoOfPersonnel from paybillD d where d.BILLNO = '" + txtVoucherChallan.Text.ToString().Trim() + "'");
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dgemployjob.Rows.Add();
                    dgemployjob.Rows[i].Cells["id"].Value = Convert.ToString(dt.Rows[i]["Dtl_id"]);
                    dgemployjob.Rows[i].Cells["locationname"].Value = Convert.ToString(dt.Rows[i]["locname"]);

                    dgemployjob.Rows[i].Cells["OrderNo"].Value = Convert.ToString(dt.Rows[i]["ref_order_no"]);
                    dgemployjob.Rows[i].Cells["orderdate"].Value = Convert.ToString(dt.Rows[i]["ref_order_date"]);


                    dgemployjob.Rows[i].Cells["Designation"].Value = Convert.ToString(dt.Rows[i]["designation"]);

                    //change made in following line 18082017
                    dgemployjob.Rows[i].Cells["sacno"].Value = Convert.ToString(dt.Rows[i]["SAC"]);

                    dgemployjob.Rows[i].Cells["Hour"].Value = Convert.ToString(dt.Rows[i]["Hour"]);
                    dgemployjob.Rows[i].Cells["MontOfDays"].Value = Convert.ToString(dt.Rows[i]["MonthDays"]);
                    dgemployjob.Rows[i].Cells["Attendance"].Value = Convert.ToString(dt.Rows[i]["Attendance"]);
                    double _rate = 0.00;
                    _rate = Convert.ToDouble(dt.Rows[i]["Rate"]);
                    dgemployjob.Rows[i].Cells["Rate"].Value = _rate;
                    dgemployjob.Rows[i].Cells["Amount"].Value = Convert.ToDouble(dt.Rows[i]["BILLAMT"]);
                    dgemployjob.Rows[i].Cells["Personnel"].Value = Convert.ToString(dt.Rows[i]["NoOfPersonnel"]);
                }
                DataTable dt2 = clsDataAccess.RunQDTbl("select [OID],[OCHARGES],[ORate],[OQty],[OAttend],[OAMT],(select serviceName+':'+sacNo from CompanySACMaster where slno = d.SAC) as 'SAC',isNull(IncGst,0)as IncGst FROM [paybillO] d where (BILLNO ='" + txtVoucherChallan.Text.ToString().Trim() + "')");
                for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                {
                    dgotherjob.Rows.Add();
                    dgotherjob.Rows[i].Cells["OCID"].Value = Convert.ToString(dt2.Rows[i]["OID"]);
                    dgotherjob.Rows[i].Cells["OCDESC"].Value = Convert.ToString(dt2.Rows[i]["OCHARGES"]);
                    dgotherjob.Rows[i].Cells["sacnoOC"].Value = Convert.ToString(dt2.Rows[i]["SAC"]);
                    dgotherjob.Rows[i].Cells["IncGST"].Value = Convert.ToString(dt2.Rows[i]["IncGst"]);
                    double oamt = 0, ORate = 0, OQty = 0, OAttend = 0;

                    try
                    {
                        OAttend = Convert.ToDouble(dt2.Rows[i]["OAttend"]);
                    }
                    catch { OAttend = 0; }

                    try
                    { ORate = Convert.ToDouble(dt2.Rows[i]["ORate"]); }
                    catch { ORate = 0; }

                    try
                    { OQty = Convert.ToDouble(dt2.Rows[i]["OQty"]); }
                    catch { OQty = 0; }

                    try
                    { oamt = Convert.ToDouble(dt2.Rows[i]["OAMT"]); }
                    catch { oamt = 0; }

                    dgotherjob.Rows[i].Cells["OCAMT"].Value = oamt;
                    dgotherjob.Rows[i].Cells["OCQty"].Value = OQty;
                    dgotherjob.Rows[i].Cells["OCRate"].Value = ORate;
                    dgemployjob.Rows[i].Cells["OCAttend"].Value = OAttend;
                }
            }
        }

        private void cmbsalstruc_DropDown(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                cmbsalstruc.Items.Clear();

                s = " select  l.Location_Name  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and company_ID = '" + get_CompID(cmbcompany.Text) + "' and l.Cliant_ID =" + clsEmployee.GetClintID(cmbclintname.Text) + "";

                Load_Data1(s, cmbsalstruc, -1);

            }
            catch (Exception x) { }
        }

        private void cmbsalstruc_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbsalstruc.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Location  must be entered");
                return;
            }
            else
            {
                Locations = Convert.ToString(get_LocationID(cmbsalstruc.Text));
            }

        }

        public int get_LocationID(string name)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select Location_ID from tbl_Emp_Location where Location_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
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
                cmbsalstruc.Items.Clear();
            }
        }



        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);

            //data_retrive_Company();
        }

        private void cmborderno_DropDown(object sender, EventArgs e)
        {
            if (cmbmonth.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Month Name Can not Blank");
                cmbmonth.DroppedDown = true;
                cmbmonth.SelectedIndex = 0;
                cmbmonth.Focus();
                return;
            }
            DataTable dt = clsDataAccess.RunQDTbl("select Title +' '+ FirstName +' '+ MiddleName +' '+ LastName,ID from tbl_Employee_Mast");
            if (dt.Rows.Count > 0)
            {               
                cmborderno.LookUpTable = dt;
                cmborderno.ReturnIndex = 1;
            }  
            
        }

        private void FrmAllocateEmployDetails_Load (object sender, EventArgs e)
        {

            SacGst = Convert.ToInt32(clsDataAccess.ReturnValue("select SacGst from CompanyLimiter"));

            if (SacGst == 1)
            {
                cmbBillType.Items.Add("Sac wise Gst");
                

                dgemployjob.Columns["gst_per"].Visible = true;
                dgemployjob.Columns["gst_amt"].Visible = true;

                dgotherjob.Columns["OC_gst_per"].Visible = true;
                dgotherjob.Columns["OC_gst_amt"].Visible = true;

                cmbBillType.SelectedIndex = 2;
            }
            else
            {
                dgemployjob.Columns["gst_per"].Visible = false;
                dgemployjob.Columns["gst_amt"].Visible = false;

                dgotherjob.Columns["OC_gst_per"].Visible = false;
                dgotherjob.Columns["OC_gst_amt"].Visible = false;
                cmbBillType.SelectedIndex = 0;
            }


            string filePath = "";
            cinv = 0;
            chkAuthorise.Checked = false; lblprevbal.Text = "0";
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
                                if (str == "BILLING_TYPE")
                                    chk_str = 1;
                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                if (StrLine_WACC[0] == "SINGLE_DESIGNATION")
                                    boolSingleDesignationBillingPermission = true;
                                chk_str = 0;
                            }
                        }
                    }

                }
                catch
                { }
            }
            if (!boolSingleDesignationBillingPermission)
            {
                cmbBillType.Items.Remove("Single Designation");
            }
            ////cmbBillType.SelectedIndex = 0;
            //this.HeaderText = "Bill Details";
            clsfirsttime obj_CFT = new clsfirsttime();
            bool result;
            edpcon = new EDPConnection();

            int mn = Convert.ToInt32(clsDataAccess.GetresultI("paybill", "IsSC"));
            if (mn == 0)
            {
                string str = "ALTER TABLE paybill ADD [IsSC] [bit] NULL";
                bool rs = clsDataAccess.RunNQwithStatus(str);

               
            }

            mn = Convert.ToInt32(clsDataAccess.GetresultI("paybill", "SCPer"));
            if (mn == 0)
            {
                string str = "ALTER TABLE paybill ADD [SCPer] [numeric] (18,2) NULL";
                bool rs = clsDataAccess.RunNQwithStatus(str);

              
            }

            mn = Convert.ToInt32(clsDataAccess.GetresultI("paybill", "ScAmt"));

            if (mn == 0)
            {
                string str = "ALTER TABLE paybill ADD [ScAmt] [numeric] (18,2) NULL";
                bool rs = clsDataAccess.RunNQwithStatus(str);

                str = "Update paybill set IsSC='true', SCPer=0, ScAmt=0";
                rs = clsDataAccess.RunNQwithStatus(str);
            }


            mn = Convert.ToInt32(clsDataAccess.GetresultI("paybill", "isRound"));
            if (mn == 0)
            {
                string str = "ALTER TABLE paybill ADD [isRound] [bit] NULL";
                bool rs = clsDataAccess.RunNQwithStatus(str);

                str = "Update paybill set isRound='False'";
                rs = clsDataAccess.RunNQwithStatus(str);
            }
            mn = Convert.ToInt32(clsDataAccess.GetresultI("paybill", "isScAdd"));
            if (mn == 0)
            {
                string str = "ALTER TABLE paybill ADD [isScAdd] [bit] NULL";
                bool rs = clsDataAccess.RunNQwithStatus(str);

                str = "Update paybill set isScAdd='True' where isSC='True' ";
                str = str + "Update paybill set isScAdd='False' where isSC='False' ";
                rs = clsDataAccess.RunNQwithStatus(str);
            }

            int var_mstcount = Convert.ToInt32(clsDataAccess.GetresultIT("paybillO"));
            if (var_mstcount == 0)
            {
                edpcon.Open();
                result = obj_CFT.AccessLocation_paybillO(edpcon.mycon);             

            }
            else if (var_mstcount > 0)
            {
                if (var_mstcount < 7)
                {

                }
            }

            clsValidation.GenerateYear(cmbYear, 2000, System.DateTime.Now.Year, 1);
            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }

            dateTimePicker1.Value = System.DateTime.Now.AddMonths(-1);

            cmbmonth.Text = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
            int year = dateTimePicker1.Value.Year;
            calculated_days = Convert.ToInt32(clsEmployee.GetTotalDaysByMonth(cmbmonth.Text, year));
            dtpto.Value = DateTime.Now;//Convert.ToDateTime("01/" + clsEmployee.GetMonthName(dateTimePicker1.Value.AddMonths(1).Month) + "/" + dateTimePicker1.Value.Year);
            var_mstcount = Convert.ToInt32(clsDataAccess.GetresultIT("paybillST"));
            if (var_mstcount == 0)
            {
                edpcon.Open();
                result = obj_CFT.AccessLocation_paybillST(edpcon.mycon);

            }
            else if (var_mstcount > 0)
            {
                if (var_mstcount < 8)
                {

                }
            }
           

            

            DataTable dt2 = clsDataAccess.RunQDTbl("select DesignationName from tbl_Employee_DesignationMaster ");
            DataGridViewComboBoxColumn dgcombo3 = dgemployjob.Columns["Designation"] as DataGridViewComboBoxColumn;

            dgcombo3.Items.Clear();
            for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dt2.Rows[i]["DesignationName"]);
                dgcombo3.Items.Add(st);
            }

            //Following block has created by dwipraj dutta 18082017
            DataTable dtSAC = clsDataAccess.RunQDTbl("select serviceName+':'+sacNo as 'SACNo' from CompanySACMaster");
            DataGridViewComboBoxColumn dgcomboSAC = dgemployjob.Columns["sacno"] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn dgcomboOCSAC = dgotherjob.Columns["sacnoOC"] as DataGridViewComboBoxColumn;

            dgcomboSAC.Items.Clear();
            dgcomboOCSAC.Items.Clear();
            sacServiceCharge.Items.Clear();

            dgcomboSAC.Items.Add("");
            dgcomboOCSAC.Items.Add("");
            sacServiceCharge.Items.Add("");

            for (int i = 0; i < dtSAC.Rows.Count ; i++)
            {
                string st = Convert.ToString(dtSAC.Rows[i]["SACNo"]);
                dgcomboSAC.Items.Add(st);
                dgcomboOCSAC.Items.Add(st);
                sacServiceCharge.Items.Add(st);
            }

            //End of adding 18082017

            string strsql = "select distinct Location_Name  from tbl_Emp_Location ";
            DataTable dt3 = clsDataAccess.RunQDTbl(strsql);
            DataGridViewComboBoxColumn dgcombo6 = dgemployjob.Columns["locationname"] as DataGridViewComboBoxColumn;
            dgcombo6.Items.Clear();
            for (int i = 0; i <= dt3.Rows.Count - 1; i++)
            {
                string st1 = Convert.ToString(dt3.Rows[i]["Location_Name"]);
                dgcombo6.Items.Add(st1);
            }

            DataTable dtH = clsDataAccess.RunQDTbl("select Hour_Name from HourMaster ");
            DataGridViewComboBoxColumn dgcombo4 = dgemployjob.Columns["Hour"] as DataGridViewComboBoxColumn;

            dgcombo4.Items.Clear();
            for (int i = 0; i <= dtH.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dtH.Rows[i]["Hour_Name"]);
                dgcombo4.Items.Add(st);
            }

            DataTable dtM = clsDataAccess.RunQDTbl("select MONTH_Name from MonthOfDays ");
            DataGridViewComboBoxColumn dgcombo5 = dgemployjob.Columns["MontOfDays"] as DataGridViewComboBoxColumn;

           // dgcombo5.Items.Clear();
            for (int i = 0; i <= dtM.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dtM.Rows[i]["MONTH_Name"]);
               // dgcombo5.Items.Add(st);
            }



            ////////DataTable dt = clsDataAccess.RunQDTbl("select Client_Name from tbl_Employee_CliantMaster");
            ////////DataGridViewComboBoxColumn dgcombo = dgemployjob.Columns["Cliantname"] as DataGridViewComboBoxColumn;
            ////////dgcombo.Items.Clear();
            ////////for (int i = 0; i <= dt.Rows.Count - 1; i++)
            ////////{
            ////////    string st = Convert.ToString(dt.Rows[i]["Client_Name"]);
            ////////    dgcombo.Items.Add(st);
            ////////}

            ////////DataTable dt1 = clsDataAccess.RunQDTbl("select Location_Name from tbl_Emp_Location");
            ////////DataGridViewComboBoxColumn dgcombo1 = dgemployjob.Columns["locationname"] as DataGridViewComboBoxColumn;
            ////////dgcombo1.Items.Clear();
            ////////for (int i = 0; i <= dt1.Rows.Count - 1; i++)
            ////////{
            ////////    string st = Convert.ToString(dt1.Rows[i]["Location_Name"]);
            ////////    dgcombo1.Items.Add(st);
            ////////}

            ////////DataTable dt2 = clsDataAccess.RunQDTbl("select Order_Name from tbl_Employee_OrderDetails");
            ////////DataGridViewComboBoxColumn dgcombo2 = dgemployjob.Columns["OrderNo"] as DataGridViewComboBoxColumn;
            ////////dgcombo2.Items.Clear();
            ////////for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            ////////{
            ////////    string st = Convert.ToString(dt2.Rows[i]["Order_Name"]);
            ////////    dgcombo2.Items.Add(st);
            ////////}


            //generate year
            //clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
            ////

            ////set session
            //if (System.DateTime.Now.Month >= 4)
            //{
            //    cmbYear.SelectedIndex = 0;
            //}
            //else
            //{
            //    cmbYear.SelectedIndex = 1;
            //}
            //       
            SessionValueCheckAndAssignNoOfDays();
            cmbYear.Focus();
            funct_stper();
            
            startPath = Application.StartupPath;

            string[] type_setting = System.IO.File.ReadAllLines(startPath + "\\type_settings.txt");

            foreach (string line in type_setting)
            {
                if (!line.Contains("*"))
                {
                    setting_type = line;
                }
            }
            comp_show();

            cmbdescription.PopUp();

            if (clsDataAccess.ReturnValue("select isNull(OCAttend,0) from CompanyLimiter") == "0")
            {
                dgotherjob.Columns["OCAttend"].Visible = false;
            }
            else
            {
                dgotherjob.Columns["OCAttend"].Visible = true;
            }
        }
        public void comp_show()
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count == 1)
            {
                cmbcompany.Text = dt.Rows[0]["CO_Name"].ToString();
                Company_id = Convert.ToInt32(dt.Rows[0]["CO_Code"]);

            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void link_comp_loc()
        {
             DataTable dtt = clsDataAccess.RunQDTbl("SELECT * FROM Companywiseid_Relation where (Company_ID=" + Company_id + ") and (Location_ID ='" + location_id + "')");

            int Max_ID = 0;
            Boolean boolStatus = false;
          
          if (dtt.Rows.Count == 0)
           {

               boolStatus = false;


               DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(ID) FROM Companywiseid_Relation");
               if (Convert.ToString(dt.Rows[0][0]).Length > 0)
               {
                   Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
               }
               else
               {
                   Max_ID = 1;
               }


               boolStatus = clsDataAccess.RunNQwithStatus("insert into  Companywiseid_Relation(ID,Company_ID,Location_ID,PF_Code,Esi_Code,Ptax_Code,Pan_Code,StReg_Code,M_inst,MOD) values('" + Max_ID + "','" + Company_id + "','" + location_id + "','','','','','','F','0')");
           }
        }

        public void UpdateDocNumberLoc(Int64 Desccode, string Tentry, int vouno, string session, string loc)
        {
            try
            {
                //=========================                
                
                //=========================                


                int ss = Convert.ToInt32(clsDataAccess.ReturnValue("select voucherno from docgen where (desccode='" + Desccode + "') and (t_entry='" + Tentry + "')"));
                
                if (vouno >= ss)
                {
                    //Change S.Dutta(14.01.13)
                    string docnumber = Convert.ToString(vouno);
                    //string docnumber = Convert.ToString(Convert.ToInt64(ss) + 1);
                    //End 14.01.13

                    
                    DataTable dt = clsDataAccess.RunQDTbl("select * from DOCGEN where (T_ENTRY='" + Tentry + "') And (DESCCODE=" + Desccode + ") And (VOUCHERNO <>" + docnumber + ")");
                    
                    if (dt.Rows.Count > 0)
                    {
                        clsDataAccess.RunQry("delete from DOCGEN where voucherno='" + docnumber + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'");
                        
                        clsDataAccess.RunQry("update docgen set voucherno='" + docnumber + "' where desccode='" + Desccode + "' and t_entry='" + Tentry + "'");
                        
                    }
                    else
                    {
                        clsDataAccess.RunQry("delete from DOCGEN where voucherno='" + docnumber + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'");
                        
                        clsDataAccess.RunQry("insert into DOCGEN(Ficode,GCODE,T_ENTRY,DESCCODE,VOUCHERNO,State,User_Code,session) Values('0','0','" + Tentry + "'," + Desccode + "," + docnumber + ",'1','" + session + "')");
                        
                    }
                }
               
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
              if (cmbcompany.Text == "")
                {
                    ERPMessageBox.ERPMessage.Show("Select Company Name");
                    cmbcompany.Focus();
                    return;
                }
              if (cmbBillType.SelectedIndex == 0)
              {
                  if (cmbLocation.Text == "")
                  {
                      ERPMessageBox.ERPMessage.Show("Enter Location Name");
                      cmbLocation.Focus();
                      return;
                  }
              }
              else if(cmbBillType.SelectedIndex == 1)
              {
                  if (cmbDesgName.Text == "")
                  {
                      ERPMessageBox.ERPMessage.Show("Enter Designation Name");
                      cmbDesgName.Focus();
                      return;
                  }
              }
            if (cmbclintname.Text == "")
                {
                    ERPMessageBox.ERPMessage.Show("Enter Client Name");
                    cmbclintname.Focus();
                    return;
                }

            Boolean flag_modify = false;
            DataTable dt1 = clsDataAccess.RunQDTbl("select BILLNO from paybill where Session= '" + cmbYear.Text + "' and (billNo='"+txtVoucherChallan.Text.Trim()+"')");
            if (dt1.Rows.Count > 0)
                flag_modify = true;


            int sts = 0;
            string type = "";
            if (chkAuthorise.Checked == true)
            {
                sts = 1;
            }
            else
            {
                sts = 0;
            }
            type = btnSave.Text;

            //Following block has been added by dwipraj dutta 25102017
            //At first check if the bill modification has been done or bill is saving for first time

            if (type.ToLower() == "save")
            {
                int vChk =Convert.ToInt32( clsDataAccess.GetresultS("select count(*) from paybill where BILLNO = '" + txtVoucherChallan.Text.Trim() + "'"));

                if (vChk > 0)
                {
                    
                    //change made by dwipraj dutta 23082017 following if block
                    if (cmbdescription.Text.Trim() == "")
                        txtVoucherChallan.Text = GetDocNo(descode, "9", "");
                    else
                    {

                        descode = Convert.ToInt32(cmbdescription.ReturnValue);
                        txtVoucherChallan.Text = GetDocNumber(descode, "9", cmbYear.Text);
                    }

                }

            }

            DataTable dtBillExistsOrNot = clsDataAccess.RunQDTbl("select BillStatus from paybill where BILLNO = '" + txtVoucherChallan.Text.Trim() + "'");


            clsDataAccess.RunWorkflow_Log(edpcom.UserDesc, "Bill", sts.ToString(), DateAndTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt"), type, Environment.MachineName, dateTimePicker1.Value.ToString("MMM"), dateTimePicker1.Value.Year.ToString(), location_id.ToString(), Company_id.ToString(), txtVoucherChallan.Text);
                    

            
            if (dtBillExistsOrNot.Rows.Count > 0)
            {
                //Check if bill has been tagged with payment addressing or not
                DataTable dtBillRelatedPaymentVerification = clsDataAccess.RunQDTbl("select * from tbl_Payment_Register where billNo = '"+txtVoucherChallan.Text+"'");
                if (dtBillRelatedPaymentVerification.Rows.Count > 0)
                {
                    //If payment addressing has been already tagged with this bill and user wants to cancel it then the permission will not be granted. 
                    if (cbCancelBill.Checked)
                    {
                        EDPMessageBox.EDPMessage.Show("You cannot cancel this bill as it has payment tagged with bill.");
                        return;
                    }
                }
            }

            if (SubmitDetails())
            {
                if (flag_modify == false)
                {
                    string[] s1 = new string[] { };
                    s1 = txtVoucherChallan.Text.Trim().Split('/');
                    if (s1.Length == 3)
                    {
                        int ss = 0;
                        try
                        {
                            ss = Convert.ToInt32(s1[2]);
                        }
                        catch { try { ss = Convert.ToInt32(s1[1]); } catch { ss = Convert.ToInt32(s1[0]); } }
                        int vch_update = 0;
                        vch_update = Convert.ToInt32(clsDataAccess.GetresultS("select Voucherno from docgen where ficode='1' and gcode='1' and DESCCODE=" + descode + " and session ='" + cmbYear.Text + "'"));
                        if (vch_update < ss)
                        {
                            if (cinv == 0)
                            {
                                edpcom.UpdateDocNumber(descode, Convert.ToString(9), ss, cmbYear.Text);
                            }
                            else
                            {
                                UpdateDocNumberLoc(descode, "9", ss, cmbYear.Text, cmbLocation.ReturnValue);
                            }
                        }
                    }
                    else
                    {
                        int ss = 0;
                        try{
                            ss=Convert.ToInt32(lblbillno.Text);
                        }
                        catch { ss = Convert.ToInt32(lblbid.Text); }
                        int vch_update = 0;

                        if (clsDataAccess.ReturnValue("select bill_doc_type from CompanyLimiter") == "3")
                        {
                            //DataTable dtDes = clsDataAccess.RunQDTbl("SELECT Descode, coid, locid, Type_Desc, Suffix, AccYr, DocNo FROM Docgen_Zone where (Type_Desc='" + lblDesc.Text.Trim() + "') and (accyr='" + cmbYear.Text + "') and (coid='" + Company_id + "') and (locid='" + location_id + "')");
                            try
                            {
                                vch_update = Convert.ToInt32(clsDataAccess.GetresultS("select isNull(DocNo,0)docno from FROM Docgen_Zone where (Type_Desc='" + lblDesc.Text.Trim() + "') and (accyr='" + cmbYear.Text + "') and (coid='" + Company_id + "') and (locid='" + location_id + "')"));
                            }
                            catch { vch_update = 0; }
                             if (vch_update < ss)
                             {
                                // clsDataAccess.RunQry("INSERT INTO Docgen_Zone(Descode, coid, locid, Type_Desc, Suffix, AccYr, DocNo) values ('2','" + Company_id + "','" + location_id + "','" + lblDesc.Text.Trim() + "','20-21','" + cmbYear.Text + "','0')");


                                 clsDataAccess.RunQry("UPDATE Docgen_Zone SET DocNo='"+ ss +"' where (Type_Desc='" + lblDesc.Text.Trim() + "') and (accyr='" + cmbYear.Text + "') and (coid='" + Company_id + "') and (locid='" + location_id + "')");
                             }
                        }
                        else
                        {
                            vch_update = Convert.ToInt32(clsDataAccess.GetresultS("select Voucherno from docgen where ficode='1' and gcode='1' and DESCCODE=" + descode + " and session ='" + cmbYear.Text + "'"));
                            if (vch_update < ss)
                            {
                                if (cinv == 0)
                                {
                                    edpcom.UpdateDocNumber(descode, Convert.ToString(9), ss, cmbYear.Text);
                                }
                                else
                                {

                                    UpdateDocNumberLoc(descode, "9", ss, cmbYear.Text, cmbLocation.ReturnValue);
                                }


                            }
                        }
                    }
                }
                if (cmbBillType.SelectedIndex == 0 || cmbBillType.SelectedIndex == 2)
                {
                    if (type.ToLower()=="save")
                        MessageBox.Show("Bill Details Saved Successfully"+ Environment.NewLine + "Alloted Bill No is : "+ txtVoucherChallan.Text.Trim(),"Bravo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    else if (type.ToLower()=="modify")
                        MessageBox.Show("Bill Details Modified Successfully", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    if (!cbCancelBill.Checked)
                    {
                        frmEmployeeBillReportO soe = new frmEmployeeBillReportO("Q");
                        soe.Company_id = Company_id;
                        soe.comboBox1.SelectedIndex = 0;
                        soe.client_id = Client_id.ToString();
                        soe.Location_id = Convert.ToInt32(location_id);
                        soe.cmbcompany.Text = cmbcompany.Text.Trim();
                        soe.cmbLocation.Text = cmbLocation.Text;
                        soe.Item_Code = "'" + txtVoucherChallan.Text + "'";
                        soe.lblprepby.Text = edpcom.UserDesc + Environment.NewLine + btnSave.Text;
                        clsValidation.GenerateYear(soe.cmbYear, 2014, System.DateTime.Now.Year, 1);
                        //soe.dateTimePicker1.Text = dateTimePicker1.Text;
                        soe.dateTimePicker1.Value = dateTimePicker1.Value;
                        soe.dateTimePicker1.Text = dateTimePicker1.Text;
                        soe.cmbYear.Text = cmbYear.Text;
                        soe.lblNote.Text = lblNote.Text;
                        soe.lblEnclosure.Text = lblEnclosure.Text;
                        soe.lblprevbal.Text = lblprevbal.Text;
                        soe.chkBank.Checked = true;
                        soe.vSes = cmbYear.Text;
                        soe.cmbYear.Text = cmbYear.Text;
                        soe.ShowDialog();
                        chkAuthorise.Checked = false;
                        btnSave.Text = "Save";
                    }


                    link_comp_loc();
                    dgemployjob.Rows.Clear();
                    //added by dwipraj dutta 19082017
                    DataTable dtSAC = clsDataAccess.RunQDTbl("select serviceName+':'+sacNo as 'SACNo' from CompanySACMaster");
                    sacServiceCharge.Items.Clear();

                    for (int i = 0; i < dtSAC.Rows.Count; i++)
                    {
                        string st = Convert.ToString(dtSAC.Rows[i]["SACNo"]);
                        sacServiceCharge.Items.Add(st);
                    }
                    ChkServiceChaerge.Checked = false;
                    //End of 19082017
                    dgotherjob.Rows.Clear();
                    cmbcompany.Text = "";
                    cmbYear.Text = "";
                    txtVoucherChallan.Text = "";
                    cmbclintname.Text = "";
                    cmbLocation.Text = "";
                    //cmbdescription.Text = "";
                    rdbCharged.Checked = true;
                    checkBox1.Checked = false;
                    txtVoucherChallan.ReadOnly = false;
                    cmbcompany.ReadOnly = false;
                    lblMsg.Text = ""; lblEnclosure.Text = "";
                    ChkServiceChaerge.Visible = true;
                    checkBox1.Visible = true;
                    rdbCharged.Visible = true;
                    rdbChargeN.Visible = true;
                    cbDueDate.Checked = false;
                    comp_show();
                    if (descode > 0)
                        txtVoucherChallan.Text = GetDocNumber(descode, "9", cmbYear.Text);

                    cmborderno.Text = "";
                    Employ_ID = "";

                    btnCLear_Click(sender,e);
                    
                }
                else if (cmbBillType.SelectedIndex == 1)
                {
                    if (type.ToLower() == "save")
                        MessageBox.Show("Bill Details Saved Successfully" + Environment.NewLine + "Alloted Bill No is : " + txtVoucherChallan.Text.Trim(), "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (type.ToLower() == "modify")
                        MessageBox.Show("Bill Details Modified Successfully", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //
                    //Bill showing code will be here
                    //

                    dgemployjob.Rows.Clear();
                    cmbcompany.Text = "";
                    cmbYear.Text = "";
                    txtVoucherChallan.Text = "";
                    cmbclintname.Text = "";
                    cmbDesgName.Text = "";
                    txtVoucherChallan.ReadOnly = false;
                    cmbcompany.ReadOnly = false;
                    lblEnclosure.Text = "";
                    comp_show();
                    if (descode > 0)
                        txtVoucherChallan.Text = GetDocNumber(descode, "9", cmbYear.Text);

                    cmborderno.Text = "";
                    chkAuthorise.Checked = false;
                    btnSave.Text = "Save";

                    btnCLear_Click(sender, e);
                    //Employ_ID = "";
                }
                //this.Close();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Bill Details");
            }
        }

        private Boolean SubmitDetails()
        {
            Boolean flug = true;
            Boolean boolStatus = false;
            double amt = 0.0,sc_bs=0,gst_bs=0,dst_per_full=0;
            string strExcSC, strIncGst;
            double servamt = 0.0;
            double ServChgPer = 0.0;
            double ServChgAmt = 0.0;
            bool chkstate;
            bool chkserChg;
            bool chkRound;
            bool chkScAdd;
            bool isGST;
            string strBillStatus = "";
            //This strBillStatus will be used in the insertion query
            if (cbCancelBill.Checked)
                strBillStatus = "CANCELED";
            else
                strBillStatus = "ACTIVE";
            int sts = 0;
            string type = "";
            if (chkAuthorise.Checked == true)
            {
                sts = 1;
            }
            else
            {
                sts = 0;
            }
            type = btnSave.Text;
            clsDataAccess.RunWorkflow_Log(edpcom.UserDesc, "Bill", sts.ToString(), DateAndTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt"), type, Environment.MachineName, dateTimePicker1.Value.ToString("MMM"), dateTimePicker1.Value.Year.ToString(), location_id.ToString(), Company_id.ToString(), txtVoucherChallan.Text.Trim());

            if (cmbBillType.SelectedIndex == 0 || cmbBillType.SelectedIndex == 2)
            {
                if (dgemployjob.Rows.Count > 1 || dgotherjob.Rows.Count > 1)
                {

                    DataTable dt46 = clsDataAccess.RunQDTbl("delete from paybill where BILLNO='" + txtVoucherChallan.Text.ToString().Trim() + "'");
                    DataTable dt47 = clsDataAccess.RunQDTbl("delete from paybilld where BILLNO='" + txtVoucherChallan.Text.ToString().Trim() + "'");
                    DataTable dt48 = clsDataAccess.RunQDTbl("delete from paybillO where BILLNO='" + txtVoucherChallan.Text.ToString().Trim() + "'");


                    if (flug == true)
                    {



                        DataTable dt8 = clsDataAccess.RunQDTbl("select co_code from Company where co_name = '" + cmbcompany.Text.ToString().Trim() + "' ");
                        string comid = "";
                        if (dt8.Rows.Count > 0)
                        {
                            comid = dt8.Rows[0][0].ToString().Trim();
                        }
                        else
                        {
                            comid = Company_id.ToString();
                        }
                        DataTable dt9 = clsDataAccess.RunQDTbl("select Location_ID from tbl_Emp_Location where Location_Name = '" + cmbsalstruc.Text.ToString().Trim() + "' ");
                        string locid = "";
                        if (dt9.Rows.Count > 0)
                        {
                            locid = dt9.Rows[0][0].ToString().Trim();
                        }
                        else
                        {
                            locid = location_id;
                        }

                        //DataTable dtcl = clsDataAccess.RunQDTbl("select Client_id from tbl_Employee_CliantMaster where Client_Name = '" + cmbclintname.Text.ToString().Trim() + "' ");
                        string client = "";
                        //if (dtcl.Rows.Count > 0)
                        //{
                        //    client = dtcl.Rows[0][0].ToString().Trim();
                        //}

                        client = Client_id.ToString();
                        //===============================================================================
                        Tot_GstVal=0;
                        for (Int32 i = 0; i < dgemployjob.Rows.Count-1; i++)
                        {
                            amt = amt + Convert.ToDouble(dgemployjob.Rows[i].Cells["Amount"].Value);
                            gst_bs = gst_bs + Convert.ToDouble(dgemployjob.Rows[i].Cells["Amount"].Value);
                            sc_bs = sc_bs + Convert.ToDouble(dgemployjob.Rows[i].Cells["Amount"].Value);

                            Tot_GstVal=Tot_GstVal+ Convert.ToDouble(dgemployjob.Rows[i].Cells["Gst_Amt"].Value);
                        }
                        
                        for (int i = 0; i < dgotherjob.Rows.Count-1; i++)
                        {
                            //Tot_GstVal = Tot_GstVal + Convert.ToDouble(dgemployjob.Rows[i].Cells["OC_Gst_Amt"].Value);
                            amt = amt + Convert.ToDouble(dgotherjob.Rows[i].Cells["OCAmt"].Value);

                            strIncGst = Convert.ToString(dgotherjob.Rows[i].Cells["IncGST"].Value);
                            strExcSC = Convert.ToString(dgotherjob.Rows[i].Cells["ExcSC"].Value);
                            if (!String.IsNullOrEmpty(strIncGst))
                            {
                                if (strIncGst.ToLower() == "true" || strIncGst.ToLower() == "1")
                                {
                                    dgotherjob.Rows[i].Cells["OC_Gst_Amt"].Value = 0;
                                    strIncGst = "1";
                                    Tot_GstVal = Tot_GstVal + 0;
                                }
                                else
                                {
                                    
                                    Tot_GstVal = Tot_GstVal + Convert.ToDouble(dgotherjob.Rows[i].Cells["OC_Gst_Amt"].Value);
                                    strIncGst = "0";
                                }
                            }
                            else
                            {
                                Tot_GstVal = Tot_GstVal + Convert.ToDouble(dgotherjob.Rows[i].Cells["OC_Gst_Amt"].Value);
                                strIncGst = "0";
                            }
                            if (!String.IsNullOrEmpty(strExcSC))
                            {
                                if (strExcSC.ToLower() == "true" || strExcSC.ToLower() == "1")
                                {
                                    strExcSC = "1";
                                }
                                else
                                {
                                    strExcSC = "0";
                                }
                            }
                            else
                            {
                                strExcSC = "0";
                            }

                            if (strIncGst == "0")
                            {
                                gst_bs = gst_bs + Convert.ToDouble(dgotherjob.Rows[i].Cells["OCAmt"].Value);

                            }


                            if (strExcSC == "0")
                            {
                                sc_bs = sc_bs + Convert.ToDouble(dgotherjob.Rows[i].Cells["OCAmt"].Value);
                            }
                        }

                        //===Service Charge===============================================================
                        string strSACServiceCharge = "";
                        if (ChkServiceChaerge.Checked == true)
                        {
                            strSACServiceCharge = Convert.ToString(sacServiceCharge.Text);
                            if (!String.IsNullOrEmpty(strSACServiceCharge))
                            {
                                string[] sac = strSACServiceCharge.Split(':');
                                strSACServiceCharge = sac[1];
                                strSACServiceCharge = Convert.ToString(clsDataAccess.RunQDTbl("select slno from CompanySACMaster where sacNo = '" + strSACServiceCharge + "'").Rows[0][0]);
                            }
                            ServChgPer = Convert.ToDouble(TxtPer.Text);
                            chkserChg = true;
                            ServChgAmt = Math.Round(Convert.ToDouble((sc_bs * ServChgPer) / 100), 2);
                        }
                        else
                        {
                            strSACServiceCharge = "";
                            chkserChg = false;
                            ServChgAmt = 0.0;
                        }

                        //===Service Tax or GST===================================================================
                        /**/

                        dst_per_full = 0;
                        if (checkBox1.Text != "GST")
                        {

                            if (checkBox1.Checked == true)
                            {
                                double servper = Convert.ToDouble(txtSTPer.Text);
                                chkstate = true;
                                isGST = false;
                                if (rdbCharged.Checked == true)
                                {
                                    chkScAdd = true;
                                }
                                else
                                {
                                    chkScAdd = false;
                                }
                                servamt = Math.Round(Convert.ToDouble(((amt + ServChgAmt) * servper) / 100), 2);

                            }
                            else
                            {
                                chkScAdd = false;
                                chkstate = false;
                                isGST = false;
                                servamt = 0.0;

                            }
                        }
                        else            //IF GST applicable
                        {
                           
                            if (checkBox1.Checked == true)
                            {
                                isGST = true;
                                chkstate = false;
                                double servper = Convert.ToDouble(txtSTPer.Text);
                                dst_per_full = Convert.ToDouble(txtSTPer.Text);
                                double Bs_GST = gst_bs + servamt + ServChgAmt;
                                if (label9.Text == "SGST%@")
                                {
                                    dst_per_full = dst_per_full + dst_per_full;

                                    double cgstper = Convert.ToDouble(cgstPer.Text);
                                    //servper = servper + cgstper;
                                    if (this.chkRound.Checked)
                                        servamt = Math.Round(Convert.ToDouble(((Bs_GST) * servper) / 100), 2) + Math.Round(Convert.ToDouble(((Bs_GST) * cgstper) / 100), 2);
                                    else
                                        servamt = Math.Round(Convert.ToDouble(((Bs_GST) * servper) / 100), 2) + Math.Round(Convert.ToDouble(((Bs_GST) * cgstper) / 100), 2);
                                    //
                                }
                                else
                                {
                                    if (this.chkRound.Checked)
                                        servamt = Math.Round(Convert.ToDouble(((Bs_GST) * servper) / 100), 2);
                                    else
                                        servamt = Math.Round(Convert.ToDouble(((Bs_GST) * servper) / 100), 2);
                                }


                                if (rdbCharged.Checked == true)
                                {
                                    chkScAdd = true;
                                }
                                else
                                {
                                    chkScAdd = false;
                                }
                                //servamt = Math.Round(Convert.ToDouble(((amt + ServChgAmt) * servper) / 100), 2);

                            }
                            else
                            {
                                chkScAdd = false;
                                chkstate = false;
                                isGST = false;
                                servamt = 0.0;

                            }

                        }
                        //===Is round===================================================================
                        if (this.chkRound.Checked == true)
                        {
                            chkRound = true;
                            //amt = Convert.ToInt32(amt);
                            //ServChgAmt = Convert.ToInt32(ServChgAmt);
                            //servamt = Convert.ToInt32(servamt);

                        }
                        else
                        {
                            chkRound = false;

                        }

                        if (SacGst == 1 && btype == 1)
                        {
                            dst_per_full = 0;
                            servamt = Tot_GstVal;
                        }

                        //boolStatus = clsDataAccess.RunNQwithStatus("insert into paybill(BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,Cliant_ID) values('" + txtVoucherChallan.Text.ToString().Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + comid + " ,'" + cmbYear.Text + "'," + locid + ",'" + cmbmonth.Text + "','" + amt + "','" + chkstate + "','" + servamt + "'," + client + ")");
                        if (cbDueDate.Checked)
                        {
                            if (String.IsNullOrEmpty(strSACServiceCharge))
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into paybill(BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,Cliant_ID,Descord,IsSC,SCPer,SCAmt,isRound,isScAdd,isGST,BillStatus,DUEDATE,status,GstPer,btype) values('" + txtVoucherChallan.Text.ToString().Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + Company_id + " ,'" + cmbYear.Text + "'," + location_id + ",'" + dateTimePicker1.Text + "','" + amt + "','" + chkstate + "','" + servamt + "'," + Client_id + "," + descode + ",'" + chkserChg + "'," + ServChgPer + "," + ServChgAmt + ",'" + chkRound + "','" + chkScAdd + "','" + isGST + "','" + strBillStatus + "',cast(convert(datetime,'" + dtpDueDate.Text + "',103) as datetime),'" + sts + "','" + dst_per_full + "','"+btype+"')");
                            }
                            else
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into paybill(BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,Cliant_ID,Descord,IsSC,SCPer,SCAmt,isRound,isScAdd,isGST,SAC,BillStatus,DUEDATE,status,GstPer,btype) values('" + txtVoucherChallan.Text.ToString().Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + Company_id + " ,'" + cmbYear.Text + "'," + location_id + ",'" + dateTimePicker1.Text + "','" + amt + "','" + chkstate + "','" + servamt + "'," + Client_id + "," + descode + ",'" + chkserChg + "'," + ServChgPer + "," + ServChgAmt + ",'" + chkRound + "','" + chkScAdd + "','" + isGST + "','" + strSACServiceCharge + "','" + strBillStatus + "',cast(convert(datetime,'" + dtpDueDate.Text + "',103) as datetime),'" + sts + "','" + dst_per_full + "','" + btype + "')");
                            }
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(strSACServiceCharge))
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into paybill(BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,Cliant_ID,Descord,IsSC,SCPer,SCAmt,isRound,isScAdd,isGST,BillStatus,status,GstPer,btype) values('" + txtVoucherChallan.Text.ToString().Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + Company_id + " ,'" + cmbYear.Text + "'," + location_id + ",'" + dateTimePicker1.Text + "','" + amt + "','" + chkstate + "','" + servamt + "'," + Client_id + "," + descode + ",'" + chkserChg + "'," + ServChgPer + "," + ServChgAmt + ",'" + chkRound + "','" + chkScAdd + "','" + isGST + "','" + strBillStatus + "','" + sts + "','" + dst_per_full + "','" + btype + "')");
                            }
                            else
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into paybill(BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,Cliant_ID,Descord,IsSC,SCPer,SCAmt,isRound,isScAdd,isGST,SAC,BillStatus,status,GstPer,btype) values('" + txtVoucherChallan.Text.ToString().Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + Company_id + " ,'" + cmbYear.Text + "'," + location_id + ",'" + dateTimePicker1.Text + "','" + amt + "','" + chkstate + "','" + servamt + "'," + Client_id + "," + descode + ",'" + chkserChg + "'," + ServChgPer + "," + ServChgAmt + ",'" + chkRound + "','" + chkScAdd + "','" + isGST + "','" + strSACServiceCharge + "','" + strBillStatus + "','" + sts + "','" + dst_per_full + "','" + btype + "')");
                            }
                        }
                        for (Int32 i = 0; i < dgemployjob.Rows.Count - 1; i++)
                        {
                            dgemployjob.Rows[i].Cells["id"].Value = i + 1;
                            string ID = Convert.ToString(dgemployjob.Rows[i].Cells["id"].Value);

                            //string strCliantName = Convert.ToString(dgemployjob.Rows[i].Cells["Cliantname"].Value);
                            //string strlocname = Convert.ToString(dgemployjob.Rows[i].Cells["locationname"].Value);

                            string strdesig = Convert.ToString(dgemployjob.Rows[i].Cells["Designation"].Value);
                            string strNoOfPersonnel = "";
                            try
                            {
                                strNoOfPersonnel = Convert.ToString(dgemployjob.Rows[i].Cells["Personnel"].Value);
                                if (strNoOfPersonnel.Trim() == "")
                                {
                                    strNoOfPersonnel = "1";
                                }
                            }
                            catch
                            {
                                strNoOfPersonnel = "1";
                            }
                            


                            string rmrks = "";
                            if (dgemployjob.Rows[i].Cells["MontOfDays"].Value.ToString().Trim().ToLower() == "perday")
                            {
                                String at = Convert.ToString(dgemployjob.Rows[i].Cells["Rate"].Value);
                                double a = Convert.ToDouble(dgemployjob.Rows[i].Cells["Attendance"].Value);
                                int b = Convert.ToInt32(lblMOD.Text);
                                String nop = Convert.ToString(a / b);
                                if (dgemployjob.Rows[i].Cells["colRmrks"].Value.ToString().Trim() != "")
                                {
                                    rmrks =dgemployjob.Rows[i].Cells["colRmrks"].Value.ToString().Trim();
                                }
                                else
                                {
                                    rmrks = at + " x " + a + " days";
                                    //nop + " x " + lblMOD.Text.ToString() + " ]";
                                }
                            }
                            else
                            {
                                //Edited by Dwipraj dutta 31/07/2017 
                                try
                                {
                                    if (!String.IsNullOrEmpty(dgemployjob.Rows[i].Cells["colRmrks"].Value.ToString()))// (dgemployjob.Rows[i].Cells["colRmrks"].Value.ToString().Trim() != "" )//|| dgemployjob.Rows[i].Cells["colRmrks"].Value == null)
                                    {
                                        rmrks = dgemployjob.Rows[i].Cells["colRmrks"].Value.ToString() ;
                                    }
                                    else
                                    {
                                        rmrks = "";
                                    }
                                }
                                catch (Exception x)
                                {
                                    rmrks = "";
                                }
                                //End of editing 31/07/2017
                            }

                            if (!String.IsNullOrEmpty(strdesig))
                            {
                                if (!String.IsNullOrEmpty(ID))
                                {
                                    //boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Emp_Posting set Cliant_ID='" + strCliantName + "',LOcation_ID='" + strlocname + "',FromDate='" + dgemployjob.Rows[i].Cells["fromdate"].Value + "',ToDate='" + dgemployjob.Rows[i].Cells["todate"].Value + "' , Order_Person = '" + dgemployjob.Rows[i].Cells["personName"].Value + "',Order_Date = '" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',UserName = '" + dgemployjob.Rows[i].Cells["username"].Value + "',Transaction_ID = '" + dgemployjob.Rows[i].Cells["transaction"].Value + "',Order_No='" + dgemployjob.Rows[i].Cells["OrderNo"].Value + "', Session = '" + cmbYear.Text + "' where ID =" + ID + " and Posting_Month='" + cmbmonth.Text + "' ");

                                    string strdesig_id = "";
                                    DataTable dt1 = clsDataAccess.RunQDTbl("select SLNO from tbl_Employee_DesignationMaster where DesignationName= '" + dgemployjob.Rows[i].Cells["designation"].Value + "'");
                                    if (dt1.Rows.Count > 0)
                                        strdesig_id = dt1.Rows[0]["SLNO"].ToString();

                                    DataTable dtloc = clsDataAccess.RunQDTbl("select Location_ID from tbl_Emp_Location where Location_Name = '" + dgemployjob.Rows[i].Cells["locationname"].Value + "'");
                                    string locations = "";
                                    if (dtloc.Rows.Count > 0)
                                    {
                                        locations = dtloc.Rows[0][0].ToString().Trim();
                                    }
                                    if (locations == "")
                                    {
                                        locations = location_id;
                                    }

                                    //change made by dwipraj dutta 18082017
                                    string strsacno = "";
                                    strsacno = Convert.ToString(dgemployjob.Rows[i].Cells["sacno"].Value);


                                    //////have to continue form here 18082017

                                    if (chkRound == false)
                                    {
                                        double amt1 = Convert.ToDouble(dgemployjob.Rows[i].Cells["Amount"].Value);
                                        //amt1 = Convert.ToInt32(amt1);
                                        double D_gst_per = 0;
                                        double gstval = (amt1 * dst_per_full) / 100;
                                        if (SacGst == 1)
                                        {
                                            D_gst_per=Convert.ToDouble(dgemployjob.Rows[i].Cells["Gst_Per"].Value);
                                            gstval = Convert.ToDouble(dgemployjob.Rows[i].Cells["Gst_Amt"].Value);
                                        }
                                        else
                                        {
                                            D_gst_per = dst_per_full;

                                            gstval = (amt1 * dst_per_full) / 100;
                                        }
                                        //boolStatus = clsDataAccess.RunNQwithStatus("insert into paybillD(Dtl_id,BILLNO,BILLDATE,desig_ID,Hour,MonthDays,Attendance,BILLAMT,RATE,Location_ID,ref_order_no,ref_order_date,Session,Month) values(" + ID + ",'" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime),'" + strdesig_id + "','" + dgemployjob.Rows[i].Cells["Hour"].Value + "','" + dgemployjob.Rows[i].Cells["MontOfDays"].Value + "','" + dgemployjob.Rows[i].Cells["Attendance"].Value + "','" + dgemployjob.Rows[i].Cells["Amount"].Value + "','" + dgemployjob.Rows[i].Cells["Rate"].Value + "','" + locations + "','" + dgemployjob.Rows[i].Cells["OrderNo"].Value + "', cast(convert(datetime,'" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',103) as datetime),'" + cmbYear.Text + "','" + cmbmonth.Text + "')");
                                        if (!String.IsNullOrEmpty(strsacno))
                                        {
                                             amt1 = Convert.ToDouble(dgemployjob.Rows[i].Cells["Amount"].Value);
                                            //amt1 = Convert.ToInt32(amt1);
                                             gstval = (amt1 * dst_per_full) / 100;

                                            string[] sac = strsacno.Split(':');
                                            strsacno = sac[1];
                                            strsacno = Convert.ToString(clsDataAccess.RunQDTbl("select slno from CompanySACMaster where sacNo = '" + strsacno + "'").Rows[0][0]);

                                            boolStatus = clsDataAccess.RunNQwithStatus("insert into paybillD(Dtl_id,BILLNO,BILLDATE,desig_ID,Hour," +
                                           "MonthDays,Attendance,BILLAMT,RATE,Location_ID,ref_order_no,ref_order_date,Session,Month,Cliant_ID,Company_id,rmrks,SAC,NoOfPersonnel,GstPer, Gst) values(" +
                                           ID + ",'" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime),'" +
                                           strdesig_id + "','" + dgemployjob.Rows[i].Cells["Hour"].Value + "','" + dgemployjob.Rows[i].Cells["MontOfDays"].Value + "','" +
                                           dgemployjob.Rows[i].Cells["Attendance"].Value + "','" + dgemployjob.Rows[i].Cells["Amount"].Value + "','" +
                                           dgemployjob.Rows[i].Cells["Rate"].Value + "','" + locations + "','" + dgemployjob.Rows[i].Cells["OrderNo"].Value +
                                           "', cast(convert(datetime,'" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',103) as datetime),'" + cmbYear.Text + "','" +
                                           cmbmonth.Text + "'," + client + "," + comid + ",'" + rmrks + "','" + strsacno + "'," + strNoOfPersonnel + "," + D_gst_per + "," + gstval + ")");
                                        }
                                        else
                                        {
                                            boolStatus = clsDataAccess.RunNQwithStatus("insert into paybillD(Dtl_id,BILLNO,BILLDATE,desig_ID,Hour," +
                                           "MonthDays,Attendance,BILLAMT,RATE,Location_ID,ref_order_no,ref_order_date,Session,Month,Cliant_ID,Company_id,rmrks,NoOfPersonnel,GstPer, Gst) values(" +
                                           ID + ",'" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime),'" +
                                           strdesig_id + "','" + dgemployjob.Rows[i].Cells["Hour"].Value + "','" + dgemployjob.Rows[i].Cells["MontOfDays"].Value + "','" +
                                           dgemployjob.Rows[i].Cells["Attendance"].Value + "','" + dgemployjob.Rows[i].Cells["Amount"].Value + "','" +
                                           dgemployjob.Rows[i].Cells["Rate"].Value + "','" + locations + "','" + dgemployjob.Rows[i].Cells["OrderNo"].Value +
                                           "', cast(convert(datetime,'" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',103) as datetime),'" + cmbYear.Text + "','" +
                                           cmbmonth.Text + "'," + client + "," + comid + ",'" + rmrks + "'," + strNoOfPersonnel + "," + D_gst_per + "," + gstval + ")");
                                        }
                                    }
                                    else
                                    {
                                        double amt1 = Convert.ToDouble(dgemployjob.Rows[i].Cells["Amount"].Value);
                                        //amt1 = Convert.ToInt32(amt1);
                                        //double gstval = (amt1 * dst_per_full) / 100;
                                        double D_gst_per = 0;
                                        double gstval = (amt1 * dst_per_full) / 100;
                                        if (SacGst == 1)
                                        {
                                            D_gst_per = Convert.ToDouble(dgemployjob.Rows[i].Cells["Gst_Per"].Value);
                                            gstval = Convert.ToDouble(dgemployjob.Rows[i].Cells["Gst_Amt"].Value);
                                        }
                                        else
                                        {
                                            D_gst_per = dst_per_full;

                                            gstval = (amt1 * dst_per_full) / 100;
                                        }

                                        if (!String.IsNullOrEmpty(strsacno))
                                        {
                                            string[] sac = strsacno.Split(':');
                                            strsacno = sac[1];
                                            strsacno = Convert.ToString(clsDataAccess.RunQDTbl("select slno from CompanySACMaster where sacNo = '" + strsacno + "'").Rows[0][0]);

                                            boolStatus = clsDataAccess.RunNQwithStatus("insert into paybillD(Dtl_id,BILLNO,BILLDATE,desig_ID,Hour," +
                                                                               "MonthDays,Attendance,BILLAMT,RATE,Location_ID,ref_order_no,ref_order_date,Session,Month,Cliant_ID,Company_id,rmrks,SAC,NoOfPersonnel,GstPer, Gst) values(" +
                                                                               ID + ",'" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime),'" +
                                                                               strdesig_id + "','" + dgemployjob.Rows[i].Cells["Hour"].Value + "','" + dgemployjob.Rows[i].Cells["MontOfDays"].Value + "','" +
                                                                               dgemployjob.Rows[i].Cells["Attendance"].Value + "','" + amt1 + "','" +
                                                                               dgemployjob.Rows[i].Cells["Rate"].Value + "','" + locations + "','" + dgemployjob.Rows[i].Cells["OrderNo"].Value +
                                                                               "', cast(convert(datetime,'" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',103) as datetime),'" + cmbYear.Text + "','" +
                                                                               cmbmonth.Text + "'," + client + "," + comid + ",'" + rmrks + "','" + strsacno + "'," + strNoOfPersonnel + "," + D_gst_per + "," + gstval + ")");
                                        }
                                        else
                                        {
                                            boolStatus = clsDataAccess.RunNQwithStatus("insert into paybillD(Dtl_id,BILLNO,BILLDATE,desig_ID,Hour," +
                                                                               "MonthDays,Attendance,BILLAMT,RATE,Location_ID,ref_order_no,ref_order_date,Session,Month,Cliant_ID,Company_id,rmrks,NoOfPersonnel,GstPer, Gst) values(" +
                                                                               ID + ",'" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime),'" +
                                                                               strdesig_id + "','" + dgemployjob.Rows[i].Cells["Hour"].Value + "','" + dgemployjob.Rows[i].Cells["MontOfDays"].Value + "','" +
                                                                               dgemployjob.Rows[i].Cells["Attendance"].Value + "','" + amt1 + "','" +
                                                                               dgemployjob.Rows[i].Cells["Rate"].Value + "','" + locations + "','" + dgemployjob.Rows[i].Cells["OrderNo"].Value +
                                                                               "', cast(convert(datetime,'" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',103) as datetime),'" + cmbYear.Text + "','" +
                                                                               cmbmonth.Text + "'," + client + "," + comid + ",'" + rmrks + "'," + strNoOfPersonnel + "," + D_gst_per + "," + gstval + ")");
                                        }

                                    }
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                ERPMessageBox.ERPMessage.Show("Please Enter Designation Name for " + i + " th Row.");
                            }
                        }

                        //============================Bibhas===================================================
                        for (Int32 i = 0; i < dgotherjob.Rows.Count - 1; i++)
                        {
                            dgotherjob.Rows[i].Cells["OCID"].Value = i + 1;
                            string OID = Convert.ToString(dgotherjob.Rows[i].Cells["OCID"].Value);
                            string OCHARGES = Convert.ToString(dgotherjob.Rows[i].Cells["OCDESC"].Value);
                            double OCRate = 0, OCQty = 0, OAMT = 0,OCAttend=0;

                            try { OCRate = Convert.ToDouble(dgotherjob.Rows[i].Cells["OCRate"].Value); }
                            catch { OCRate = 0; }
                            try { OCQty = Convert.ToDouble(dgotherjob.Rows[i].Cells["OCQty"].Value); }
                            catch { OCQty = 0; }
                            try { OAMT = Convert.ToDouble(dgotherjob.Rows[i].Cells["OCAMT"].Value); }
                            catch { OAMT = 0; }
                            try
                            {
                                OCAttend = Convert.ToDouble(dgotherjob.Rows[i].Cells["OCAttend"].Value);
                            }
                            catch {OCAttend=0; }
                            //following changed by dwipraj dutta 19082017
                            string strsacno = Convert.ToString(dgotherjob.Rows[i].Cells["sacnoOC"].Value);

                            strIncGst = Convert.ToString(dgotherjob.Rows[i].Cells["IncGST"].Value);
                            strExcSC = Convert.ToString(dgotherjob.Rows[i].Cells["ExcSC"].Value);
                            //double amt1 = Convert.ToDouble(dgemployjob.Rows[i].Cells["Amount"].Value);
                            ////amt1 = Convert.ToInt32(amt1);
                            double gstval = 0,gst=0;// (amt1 * dst_per_full) / 100;
                            if (!String.IsNullOrEmpty(strIncGst))
                            {
                                if (strIncGst.ToLower() == "true" || strIncGst.ToLower() == "1")
                                {
                                    strIncGst = "1";
                                    gst = 0;
                                    gstval=(OAMT* 0) / 100;
                                }
                                else
                                {
                                    strIncGst = "0";

                                    gst = dst_per_full;
                                    gstval = (OAMT * gst) / 100;
                                    if (SacGst == 1)
                                    {
                                        gst = Convert.ToDouble(dgotherjob.Rows[i].Cells["OC_Gst_Per"].Value);
                                        gstval = Convert.ToDouble(dgotherjob.Rows[i].Cells["OC_Gst_Amt"].Value);
                                    }
                                    else
                                    {
                                        gst = dst_per_full;

                                        gstval = (OAMT * dst_per_full) / 100;
                                    }
                                    
                                }
                            }
                            else
                            {
                                strIncGst = "0";

                                gst = dst_per_full;
                                gstval = (OAMT * gst) / 100;
                                if (SacGst == 1)
                                {
                                    gst = Convert.ToDouble(dgotherjob.Rows[i].Cells["OC_Gst_Per"].Value);
                                    gstval = Convert.ToDouble(dgotherjob.Rows[i].Cells["OC_Gst_Amt"].Value);
                                }
                                else
                                {
                                    gst = dst_per_full;

                                    gstval = (OAMT * gst) / 100;
                                }
                            }

                            if (!String.IsNullOrEmpty(strExcSC))
                            {
                                if (strExcSC.ToLower() == "true" || strExcSC.ToLower() == "1")
                                {
                                    strExcSC = "1";
                                }
                                else
                                {
                                    strExcSC = "0";
                                }
                            }
                            else
                            {
                                strExcSC = "0";
                            }

                           

                            if (!String.IsNullOrEmpty(OCHARGES))
                            {
                                if (!String.IsNullOrEmpty(OID))
                                {
                                    if (chkRound == true)
                                    {
                                        OAMT = Convert.ToDouble(OAMT);

                                    }
                                    if (!String.IsNullOrEmpty(strsacno))
                                    {
                                        //following line added by dwipraj dutta 19082017
                                        string[] sac = strsacno.Split(':');
                                        strsacno = sac[1];
                                        strsacno = Convert.ToString(clsDataAccess.RunQDTbl("select slno from CompanySACMaster where sacNo = '" + strsacno + "'").Rows[0][0]);

                                        boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO [paybillO]([BILLNO],[BILLDATE],[OID],[OCHARGES],[ORate],[OQty],[OAMT],SAC,IncGst,ExcSC,[OAttend],GstPer,Gst) VALUES ('" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + OID + ",'" + OCHARGES + "'," + OCRate + "," + OCQty + "," + OAMT + ",'" + strsacno + "'," + strIncGst + "," + strExcSC + ",'" + OCAttend + "','" + gst + "','" + gstval + "')");
                                    }
                                    else
                                        boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO [paybillO]([BILLNO],[BILLDATE],[OID],[OCHARGES],[ORate],[OQty],[OAMT],SAC,IncGst,ExcSC,[OAttend],GstPer,Gst) VALUES ('" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + OID + ",'" + OCHARGES + "'," + OCRate + "," + OCQty + "," + OAMT + ",''," + strIncGst + "," + strExcSC + ",'" + OCAttend + "','" + gst + "','" + gstval + "')");
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                ERPMessageBox.ERPMessage.Show("Please enter Other Description for " + i + " th Row.");
                            }

                        }


                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("No Record To Save");
                }
            }
            else if (cmbBillType.SelectedIndex == 1)
            {
                chkstate = false;
                chkserChg = false;
                chkScAdd = false;
                isGST = false;
                double servper = Convert.ToDouble(txtSTPer.Text);
                dst_per_full = Convert.ToDouble(txtSTPer.Text);

                
//========================================================================================================================
                for (int i = 0; i < dgotherjob.Rows.Count - 1; i++)
                {
                    amt = amt + Convert.ToDouble(dgotherjob.Rows[i].Cells["OCAmt"].Value);

                    strIncGst = Convert.ToString(dgotherjob.Rows[i].Cells["IncGST"].Value);
                    strExcSC = Convert.ToString(dgotherjob.Rows[i].Cells["ExcSC"].Value);

                    if (!String.IsNullOrEmpty(strIncGst))
                    {
                        if (strIncGst.ToLower() == "true" || strIncGst.ToLower() == "1")
                        {
                            strIncGst = "1";
                        }
                        else
                        {
                            strIncGst = "0";
                        }
                    }
                    else
                    {
                        strIncGst = "0";
                    }


                    if (!String.IsNullOrEmpty(strExcSC))
                    {
                        if (strExcSC.ToLower() == "true" || strExcSC.ToLower() == "1")
                        {
                            strExcSC = "1";
                        }
                        else
                        {
                            strExcSC = "0";
                        }
                    }
                    else
                    {
                        strExcSC = "0";
                    }

                   
                    if (strExcSC == "0")
                    {
                        sc_bs = sc_bs + Convert.ToDouble(dgotherjob.Rows[i].Cells["OCAmt"].Value);
                    }
                    if (strIncGst == "0")
                    {
                        gst_bs = gst_bs + Convert.ToDouble(dgotherjob.Rows[i].Cells["OCAmt"].Value);

                    }
                }


                for (Int32 i = 0; i < dgemployjob.Rows.Count - 1; i++)
                {
                    amt = amt + Convert.ToDouble(dgemployjob.Rows[i].Cells["Amount"].Value);
                    gst_bs = gst_bs + Convert.ToDouble(dgemployjob.Rows[i].Cells["Amount"].Value);
                    sc_bs = sc_bs + Convert.ToDouble(dgemployjob.Rows[i].Cells["Amount"].Value);
                }
                if (this.chkRound.Checked == true)
                {
                    amt = Convert.ToInt32(amt);

                }
                //===Service Charge===============================================================
                string strSACServiceCharge = "";
                if (ChkServiceChaerge.Checked == true)
                {
                    strSACServiceCharge = Convert.ToString(sacServiceCharge.Text);
                    if (!String.IsNullOrEmpty(strSACServiceCharge))
                    {
                        string[] sac = strSACServiceCharge.Split(':');
                        strSACServiceCharge = sac[1];
                        strSACServiceCharge = Convert.ToString(clsDataAccess.RunQDTbl("select slno from CompanySACMaster where sacNo = '" + strSACServiceCharge + "'").Rows[0][0]);
                    }
                    ServChgPer = Convert.ToDouble(TxtPer.Text);
                    chkserChg = true;
                    ServChgAmt = Math.Round(Convert.ToDouble((sc_bs * ServChgPer) / 100), 2);
                }
                else
                {
                    strSACServiceCharge = "";
                    chkserChg = false;
                    ServChgAmt = 0.0;
                }
                //======================================================================================
                double Bs_GST = gst_bs + servamt + ServChgAmt;
                amt = amt + ServChgAmt;
                if (label9.Text == "SGST%@")
                {
                    dst_per_full = dst_per_full + dst_per_full;

                    double cgstper = Convert.ToDouble(cgstPer.Text);
                    //servper = servper + cgstper;
                    if (this.chkRound.Checked)
                        servamt = Math.Round(Convert.ToDouble(((Bs_GST) * servper) / 100), 2) + Math.Round(Convert.ToDouble(((Bs_GST) * cgstper) / 100), 2);
                    else
                        servamt = Math.Round(Convert.ToDouble(((Bs_GST) * servper) / 100), 2) + Math.Round(Convert.ToDouble(((Bs_GST) * cgstper) / 100), 2);
                    //
                }
                else
                {
                    if (this.chkRound.Checked)
                        servamt = Math.Round(Convert.ToDouble(((Bs_GST) * servper) / 100), 2);
                    else
                        servamt = Math.Round(Convert.ToDouble(((Bs_GST) * servper) / 100), 2);
                }

                if (dgemployjob.Rows.Count > 1)
                {
                    DataTable dt46 = clsDataAccess.RunQDTbl("delete from paybill where BILLNO='" + txtVoucherChallan.Text.ToString().Trim() + "'");
                    DataTable dt47 = clsDataAccess.RunQDTbl("delete from paybilld where BILLNO='" + txtVoucherChallan.Text.ToString().Trim() + "'");
                    DataTable dt48 = clsDataAccess.RunQDTbl("delete from paybillO where BILLNO='" + txtVoucherChallan.Text.ToString().Trim() + "'");



                    if (flug == true)
                    {
                        DataTable dt8 = clsDataAccess.RunQDTbl("select co_code from Company where co_name = '" + cmbcompany.Text.ToString().Trim() + "' ");
                        string comid = "";
                        if (dt8.Rows.Count > 0)
                        {
                            comid = dt8.Rows[0][0].ToString().Trim();
                        }
                        else
                        {
                            comid = Company_id.ToString();
                        }

                        DataTable dt9 = clsDataAccess.RunQDTbl("select [SlNo] from [tbl_Employee_DesignationMaster] where [DesignationName] = '" + cmbDesgName.Text.ToString().Trim() + "' ");
                        string desgid = "";
                        if (dt9.Rows.Count > 0)
                        {
                            desgid = dt9.Rows[0][0].ToString().Trim();
                        }
                        else
                        {
                            desgid = DesgID.ToString();
                        }
                        

                        string client = "";
                        client = Client_id.ToString();

                        
                        //HERE HAVE TO ADD CODES........
                        //====================================================================
                       
                        //===Service Tax or GST===================================================================
                        /**/
                        if (checkBox1.Text != "GST")
                        {

                            if (checkBox1.Checked == true)
                            {
                                servper = Convert.ToDouble(txtSTPer.Text);
                                chkstate = true;
                                isGST = false;
                                if (rdbCharged.Checked == true)
                                {
                                    chkScAdd = true;
                                }
                                else
                                {
                                    chkScAdd = false;
                                }
                                servamt = Math.Round(Convert.ToDouble(((amt + ServChgAmt) * servper) / 100), 2);

                            }
                            else
                            {
                                chkScAdd = false;
                                chkstate = false;
                                isGST = false;
                                servamt = 0.0;

                            }
                        }
                        else            //IF GST applicable
                        {

                            if (checkBox1.Checked == true)
                            {
                                isGST = true;
                                chkstate = false;
                                 servper = Convert.ToDouble(txtSTPer.Text);
                                if (label9.Text == "SGST%@")
                                {

                                    double cgstper = Convert.ToDouble(cgstPer.Text);
                                    //servper = servper + cgstper;
                                    if (this.chkRound.Checked)
                                        servamt = Math.Round(Convert.ToDouble(((gst_bs + ServChgAmt) * servper) / 100)) + Math.Round(Convert.ToDouble(((gst_bs + ServChgAmt) * cgstper) / 100));
                                    else
                                        servamt = Math.Round(Convert.ToDouble(((gst_bs + ServChgAmt) * servper) / 100), 2) + Math.Round(Convert.ToDouble(((gst_bs + ServChgAmt) * cgstper) / 100), 2);
                                    //
                                }
                                else
                                {
                                    if (this.chkRound.Checked)
                                        servamt = Math.Round(Convert.ToDouble(((gst_bs + ServChgAmt) * servper) / 100));
                                    else
                                        servamt = Math.Round(Convert.ToDouble(((gst_bs + ServChgAmt) * servper) / 100), 2);
                                }


                                if (rdbCharged.Checked == true)
                                {
                                    chkScAdd = true;
                                }
                                else
                                {
                                    chkScAdd = false;
                                }
                                //servamt = Math.Round(Convert.ToDouble(((amt + ServChgAmt) * servper) / 100), 2);

                            }
                            else
                            {
                                chkScAdd = false;
                                chkstate = false;
                                isGST = false;
                                servamt = 0.0;

                            }

                        }
                       
                        location_id = "0";

                        //Is Rounded
                        if (this.chkRound.Checked == true)
                        {
                            chkRound = true;
                            amt = Convert.ToInt32(amt);
                            ServChgAmt = Convert.ToInt32(ServChgAmt);
                            servamt = Convert.ToInt32(servamt);

                        }
                        else
                        {
                            chkRound = false;

                        }



                        //boolStatus = clsDataAccess.RunNQwithStatus("insert into paybill(BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,Cliant_ID) values('" + txtVoucherChallan.Text.ToString().Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + comid + " ,'" + cmbYear.Text + "'," + locid + ",'" + cmbmonth.Text + "','" + amt + "','" + chkstate + "','" + servamt + "'," + client + ")");
                        
                        //===Is round===================================================================
                        if (this.chkRound.Checked == true)
                        {
                            chkRound = true;
                            //amt = Convert.ToInt32(amt);
                            //ServChgAmt = Convert.ToInt32(ServChgAmt);
                            //servamt = Convert.ToInt32(servamt);

                        }
                        else
                        {
                            chkRound = false;

                        }
                        if (String.IsNullOrEmpty(strSACServiceCharge))
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into paybill(BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,Cliant_ID,Descord,IsSC,SCPer,SCAmt,isRound,isScAdd,isGST,Designation_Id,BillStatus,status,DUEDATE,GstPer) values('" + txtVoucherChallan.Text.ToString().Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + Company_id + " ,'" + cmbYear.Text + "'," + location_id + ",'" + dateTimePicker1.Text + "','" + amt + "','" + chkstate + "','" + servamt + "'," + Client_id + "," + descode + ",'" + chkserChg + "'," + ServChgPer + "," + ServChgAmt + ",'" + chkRound + "','" + chkScAdd + "','" + isGST + "','" + desgid + "','" + strBillStatus + "','" + sts + "',cast(convert(datetime,'" + dtpDueDate.Text + "',103) as datetime),'" + dst_per_full + "')");
                        }
                        else
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into paybill(BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,Cliant_ID,Descord,IsSC,SCPer,SCAmt,isRound,isScAdd,isGST,Designation_Id,SAC,BillStatus,status,DUEDATE,GstPer) values('" + txtVoucherChallan.Text.ToString().Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + Company_id + " ,'" + cmbYear.Text + "'," + location_id + ",'" + dateTimePicker1.Text + "','" + amt + "','" + chkstate + "','" + servamt + "'," + Client_id + "," + descode + ",'" + chkserChg + "'," + ServChgPer + "," + ServChgAmt + ",'" + chkRound + "','" + chkScAdd + "','" + isGST + "','" + desgid + "','" + strSACServiceCharge + "','" + strBillStatus + "','" + sts + "',cast(convert(datetime,'" + dtpDueDate.Text + "',103) as datetime),'" + dst_per_full +"')");
                        }
                        ////if (cbDueDate.Checked)
                        ////{
                        ////    if (String.IsNullOrEmpty(strSACServiceCharge))
                        ////    {
                        ////        boolStatus = clsDataAccess.RunNQwithStatus("insert into paybill(BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,Cliant_ID,Descord,IsSC,SCPer,SCAmt,isRound,isScAdd,isGST,BillStatus,DUEDATE,status,GstPer) values('" + txtVoucherChallan.Text.ToString().Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + Company_id + " ,'" + cmbYear.Text + "'," + location_id + ",'" + dateTimePicker1.Text + "','" + amt + "','" + chkstate + "','" + servamt + "'," + Client_id + "," + descode + ",'" + chkserChg + "'," + ServChgPer + "," + ServChgAmt + ",'" + chkRound + "','" + chkScAdd + "','" + isGST + "','" + strBillStatus + "',cast(convert(datetime,'" + dtpDueDate.Text + "',103) as datetime),'" + sts + "','" + dst_per_full + "')");
                        ////    }
                        ////    else
                        ////    {
                        ////        boolStatus = clsDataAccess.RunNQwithStatus("insert into paybill(BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,Cliant_ID,Descord,IsSC,SCPer,SCAmt,isRound,isScAdd,isGST,SAC,BillStatus,DUEDATE,status,GstPer) values('" + txtVoucherChallan.Text.ToString().Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + Company_id + " ,'" + cmbYear.Text + "'," + location_id + ",'" + dateTimePicker1.Text + "','" + amt + "','" + chkstate + "','" + servamt + "'," + Client_id + "," + descode + ",'" + chkserChg + "'," + ServChgPer + "," + ServChgAmt + ",'" + chkRound + "','" + chkScAdd + "','" + isGST + "','" + strSACServiceCharge + "','" + strBillStatus + "',cast(convert(datetime,'" + dtpDueDate.Text + "',103) as datetime),'" + sts + "','" + dst_per_full + "')");
                        ////    }
                        ////}
                        ////else
                        ////{
                        ////    if (String.IsNullOrEmpty(strSACServiceCharge))
                        ////    {
                        ////        boolStatus = clsDataAccess.RunNQwithStatus("insert into paybill(BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,Cliant_ID,Descord,IsSC,SCPer,SCAmt,isRound,isScAdd,isGST,BillStatus,status,GstPer) values('" + txtVoucherChallan.Text.ToString().Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + Company_id + " ,'" + cmbYear.Text + "'," + location_id + ",'" + dateTimePicker1.Text + "','" + amt + "','" + chkstate + "','" + servamt + "'," + Client_id + "," + descode + ",'" + chkserChg + "'," + ServChgPer + "," + ServChgAmt + ",'" + chkRound + "','" + chkScAdd + "','" + isGST + "','" + strBillStatus + "','" + sts + "','" + dst_per_full + "')");
                        ////    }
                        ////    else
                        ////    {
                        ////        boolStatus = clsDataAccess.RunNQwithStatus("insert into paybill(BILLNO,BILLDATE,Comany_id,Session,Location_ID,Month,TotAMT,IsService,ServiceAmount,Cliant_ID,Descord,IsSC,SCPer,SCAmt,isRound,isScAdd,isGST,SAC,BillStatus,status,GstPer) values('" + txtVoucherChallan.Text.ToString().Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + Company_id + " ,'" + cmbYear.Text + "'," + location_id + ",'" + dateTimePicker1.Text + "','" + amt + "','" + chkstate + "','" + servamt + "'," + Client_id + "," + descode + ",'" + chkserChg + "'," + ServChgPer + "," + ServChgAmt + ",'" + chkRound + "','" + chkScAdd + "','" + isGST + "','" + strSACServiceCharge + "','" + strBillStatus + "','" + sts + "','" + dst_per_full + "')");
                        ////    }
                        ////}

                        for (Int32 i = 0; i < dgemployjob.Rows.Count - 1; i++)
                        {
                            dgemployjob.Rows[i].Cells["id"].Value = i + 1;
                            string ID = Convert.ToString(dgemployjob.Rows[i].Cells["id"].Value);

                            //string strCliantName = Convert.ToString(dgemployjob.Rows[i].Cells["Cliantname"].Value);
                            //string strlocname = Convert.ToString(dgemployjob.Rows[i].Cells["locationname"].Value);

                            string strdesig = Convert.ToString(dgemployjob.Rows[i].Cells["Designation"].Value);
                            string strloc = Convert.ToString(dgemployjob.Rows[i].Cells["locationname"].Value);
                            string strNoOfPersonnel = "";
                            try
                            {
                                strNoOfPersonnel = Convert.ToString(dgemployjob.Rows[i].Cells["Personnel"].Value);
                            }
                            catch
                            {
                                strNoOfPersonnel = "0";
                            }
                            string rmrks = "";
                            if (dgemployjob.Rows[i].Cells["MontOfDays"].Value.ToString().Trim().ToLower() == "perday")
                            {
                                String at = Convert.ToString(dgemployjob.Rows[i].Cells["Rate"].Value);
                                double a = Convert.ToDouble(dgemployjob.Rows[i].Cells["Attendance"].Value);
                                int b = Convert.ToInt32(lblMOD.Text);
                                String nop = Convert.ToString(a / b);
                                if (dgemployjob.Rows[i].Cells["colRmrks"].Value.ToString().Trim() != "")
                                {
                                    rmrks = "[ " + dgemployjob.Rows[i].Cells["colRmrks"].Value + " ]";
                                }
                                else
                                {
                                    rmrks = "[ " + at + " x " + a + " days ]";
                                    //nop + " x " + lblMOD.Text.ToString() + " ]";
                                }
                            }
                            else
                            {
                                //Edited by Dwipraj dutta 31/07/2017 
                                try
                                {
                                    if (!String.IsNullOrEmpty(dgemployjob.Rows[i].Cells["colRmrks"].Value.ToString()))// (dgemployjob.Rows[i].Cells["colRmrks"].Value.ToString().Trim() != "" )//|| dgemployjob.Rows[i].Cells["colRmrks"].Value == null)
                                    {
                                        rmrks = "[ " + dgemployjob.Rows[i].Cells["colRmrks"].Value + " ]";
                                    }
                                    else
                                    {
                                        rmrks = "";
                                    }
                                }
                                catch (Exception x)
                                {
                                    rmrks = "";
                                }
                                //End of editing 31/07/2017
                            }

                            if (!String.IsNullOrEmpty(strdesig)&&!String.IsNullOrEmpty(strloc))
                            {
                                if (!String.IsNullOrEmpty(ID))
                                {
                                    //boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Emp_Posting set Cliant_ID='" + strCliantName + "',LOcation_ID='" + strlocname + "',FromDate='" + dgemployjob.Rows[i].Cells["fromdate"].Value + "',ToDate='" + dgemployjob.Rows[i].Cells["todate"].Value + "' , Order_Person = '" + dgemployjob.Rows[i].Cells["personName"].Value + "',Order_Date = '" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',UserName = '" + dgemployjob.Rows[i].Cells["username"].Value + "',Transaction_ID = '" + dgemployjob.Rows[i].Cells["transaction"].Value + "',Order_No='" + dgemployjob.Rows[i].Cells["OrderNo"].Value + "', Session = '" + cmbYear.Text + "' where ID =" + ID + " and Posting_Month='" + cmbmonth.Text + "' ");

                                    string strdesig_id = "";
                                    DataTable dt1 = clsDataAccess.RunQDTbl("select SLNO from tbl_Employee_DesignationMaster where DesignationName= '" + dgemployjob.Rows[i].Cells["designation"].Value + "'");
                                    if (dt1.Rows.Count > 0)
                                        strdesig_id = dt1.Rows[0]["SLNO"].ToString();

                                    DataTable dtloc = clsDataAccess.RunQDTbl("select Location_ID from tbl_Emp_Location where Location_Name = '" + dgemployjob.Rows[i].Cells["locationname"].Value + "'");
                                    string locations = "";
                                    if (dtloc.Rows.Count > 0)
                                    {
                                        locations = dtloc.Rows[0][0].ToString().Trim();
                                    }
                                    if (locations == "")
                                    {
                                        locations = location_id;
                                    }

                                    //change made by dwipraj dutta 18082017
                                    string strsacno = "";
                                    strsacno = Convert.ToString(dgemployjob.Rows[i].Cells["sacno"].Value);


                                    //////have to continue form here 18082017

                                    if (chkRound == false)
                                    {
                                        //boolStatus = clsDataAccess.RunNQwithStatus("insert into paybillD(Dtl_id,BILLNO,BILLDATE,desig_ID,Hour,MonthDays,Attendance,BILLAMT,RATE,Location_ID,ref_order_no,ref_order_date,Session,Month) values(" + ID + ",'" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime),'" + strdesig_id + "','" + dgemployjob.Rows[i].Cells["Hour"].Value + "','" + dgemployjob.Rows[i].Cells["MontOfDays"].Value + "','" + dgemployjob.Rows[i].Cells["Attendance"].Value + "','" + dgemployjob.Rows[i].Cells["Amount"].Value + "','" + dgemployjob.Rows[i].Cells["Rate"].Value + "','" + locations + "','" + dgemployjob.Rows[i].Cells["OrderNo"].Value + "', cast(convert(datetime,'" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',103) as datetime),'" + cmbYear.Text + "','" + cmbmonth.Text + "')");
                                        if (!String.IsNullOrEmpty(strsacno))
                                        {
                                            string[] sac = strsacno.Split(':');
                                            strsacno = sac[1];
                                            strsacno = Convert.ToString(clsDataAccess.RunQDTbl("select slno from CompanySACMaster where sacNo = '" + strsacno + "'").Rows[0][0]);

                                            boolStatus = clsDataAccess.RunNQwithStatus("insert into paybillD(Dtl_id,BILLNO,BILLDATE,desig_ID,Hour," +
                                           "MonthDays,Attendance,BILLAMT,RATE,Location_ID,ref_order_no,ref_order_date,Session,Month,Cliant_ID,Company_id,rmrks,SAC,NoOfPersonnel) values(" +
                                           ID + ",'" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime),'" +
                                           strdesig_id + "','" + dgemployjob.Rows[i].Cells["Hour"].Value + "','" + dgemployjob.Rows[i].Cells["MontOfDays"].Value + "','" +
                                           dgemployjob.Rows[i].Cells["Attendance"].Value + "','" + dgemployjob.Rows[i].Cells["Amount"].Value + "','" +
                                           dgemployjob.Rows[i].Cells["Rate"].Value + "','" + locations + "','" + dgemployjob.Rows[i].Cells["OrderNo"].Value +
                                           "', cast(convert(datetime,'" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',103) as datetime),'" + cmbYear.Text + "','" +
                                           cmbmonth.Text + "'," + client + "," + comid + ",'" + rmrks + "','" + strsacno + "',"+strNoOfPersonnel+")");
                                        }
                                        else
                                        {
                                            boolStatus = clsDataAccess.RunNQwithStatus("insert into paybillD(Dtl_id,BILLNO,BILLDATE,desig_ID,Hour," +
                                           "MonthDays,Attendance,BILLAMT,RATE,Location_ID,ref_order_no,ref_order_date,Session,Month,Cliant_ID,Company_id,rmrks,NoOfPersonnel) values(" +
                                           ID + ",'" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime),'" +
                                           strdesig_id + "','" + dgemployjob.Rows[i].Cells["Hour"].Value + "','" + dgemployjob.Rows[i].Cells["MontOfDays"].Value + "','" +
                                           dgemployjob.Rows[i].Cells["Attendance"].Value + "','" + dgemployjob.Rows[i].Cells["Amount"].Value + "','" +
                                           dgemployjob.Rows[i].Cells["Rate"].Value + "','" + locations + "','" + dgemployjob.Rows[i].Cells["OrderNo"].Value +
                                           "', cast(convert(datetime,'" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',103) as datetime),'" + cmbYear.Text + "','" +
                                           cmbmonth.Text + "'," + client + "," + comid + ",'" + rmrks + "',"+strNoOfPersonnel+")");
                                        }
                                    }
                                    else
                                    {
                                        double amt1 = Convert.ToDouble(dgemployjob.Rows[i].Cells["Amount"].Value);
                                        amt1 = Convert.ToInt32(amt1);
                                        if (!String.IsNullOrEmpty(strsacno))
                                        {
                                            string[] sac = strsacno.Split(':');
                                            strsacno = sac[1];
                                            strsacno = Convert.ToString(clsDataAccess.RunQDTbl("select slno from CompanySACMaster where sacNo = '" + strsacno + "'").Rows[0][0]);

                                            boolStatus = clsDataAccess.RunNQwithStatus("insert into paybillD(Dtl_id,BILLNO,BILLDATE,desig_ID,Hour," +
                                                                               "MonthDays,Attendance,BILLAMT,RATE,Location_ID,ref_order_no,ref_order_date,Session,Month,Cliant_ID,Company_id,rmrks,SAC,NoOfPersonnel) values(" +
                                                                               ID + ",'" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime),'" +
                                                                               strdesig_id + "','" + dgemployjob.Rows[i].Cells["Hour"].Value + "','" + dgemployjob.Rows[i].Cells["MontOfDays"].Value + "','" +
                                                                               dgemployjob.Rows[i].Cells["Attendance"].Value + "','" + amt1 + "','" +
                                                                               dgemployjob.Rows[i].Cells["Rate"].Value + "','" + locations + "','" + dgemployjob.Rows[i].Cells["OrderNo"].Value +
                                                                               "', cast(convert(datetime,'" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',103) as datetime),'" + cmbYear.Text + "','" +
                                                                               cmbmonth.Text + "'," + client + "," + comid + ",'" + rmrks + "','" + strsacno + "',"+strNoOfPersonnel+")");
                                        }
                                        else
                                        {
                                            boolStatus = clsDataAccess.RunNQwithStatus("insert into paybillD(Dtl_id,BILLNO,BILLDATE,desig_ID,Hour," +
                                                                               "MonthDays,Attendance,BILLAMT,RATE,Location_ID,ref_order_no,ref_order_date,Session,Month,Cliant_ID,Company_id,rmrks,NoOfPersonnel) values(" +
                                                                               ID + ",'" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime),'" +
                                                                               strdesig_id + "','" + dgemployjob.Rows[i].Cells["Hour"].Value + "','" + dgemployjob.Rows[i].Cells["MontOfDays"].Value + "','" +
                                                                               dgemployjob.Rows[i].Cells["Attendance"].Value + "','" + amt1 + "','" +
                                                                               dgemployjob.Rows[i].Cells["Rate"].Value + "','" + locations + "','" + dgemployjob.Rows[i].Cells["OrderNo"].Value +
                                                                               "', cast(convert(datetime,'" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',103) as datetime),'" + cmbYear.Text + "','" +
                                                                               cmbmonth.Text + "'," + client + "," + comid + ",'" + rmrks + "',"+strNoOfPersonnel+")");
                                        }

                                    }
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                ERPMessageBox.ERPMessage.Show("Please Enter Designation Name or Location name for " + i + " th Row.");
                            }
                        }
                        for (Int32 i = 0; i < dgotherjob.Rows.Count - 1; i++)
                        {
                            dgotherjob.Rows[i].Cells["OCID"].Value = i + 1;
                            string OID = Convert.ToString(dgotherjob.Rows[i].Cells["OCID"].Value);
                            string OCHARGES = Convert.ToString(dgotherjob.Rows[i].Cells["OCDESC"].Value);
                            double OCRate = 0, OCQty = 0, OAMT = 0;

                            try { OCRate = Convert.ToDouble(dgotherjob.Rows[i].Cells["OCRate"].Value); }
                            catch { OCRate = 0; }
                            try { OCQty = Convert.ToDouble(dgotherjob.Rows[i].Cells["OCQty"].Value); }
                            catch { OCRate = 0; }
                            try { OAMT = Convert.ToDouble(dgotherjob.Rows[i].Cells["OCAMT"].Value); }
                            catch { OCRate = 0; }

                            //following changed by dwipraj dutta 19082017
                            string strsacno = Convert.ToString(dgotherjob.Rows[i].Cells["sacnoOC"].Value);

                            strIncGst = Convert.ToString(dgotherjob.Rows[i].Cells["IncGST"].Value);
                            strExcSC = Convert.ToString(dgotherjob.Rows[i].Cells["ExcSC"].Value);

                            if (!String.IsNullOrEmpty(strIncGst))
                            {
                                if (strIncGst.ToLower() == "true" || strIncGst.ToLower() == "1")
                                {
                                    strIncGst = "1";
                                }
                                else
                                {
                                    strIncGst = "0";
                                }
                            }
                            else
                            {
                                strIncGst = "0";
                            }


                            if (!String.IsNullOrEmpty(strExcSC))
                            {
                                if (strExcSC.ToLower() == "true" || strExcSC.ToLower() == "1")
                                {
                                    strExcSC = "1";
                                }
                                else
                                {
                                    strExcSC = "0";
                                }
                            }
                            else
                            {
                                strExcSC = "0";
                            }

                            if (!String.IsNullOrEmpty(OCHARGES))
                            {
                                if (!String.IsNullOrEmpty(OID))
                                {
                                    if (chkRound == true)
                                    {
                                        OAMT = Convert.ToInt32(OAMT);

                                    }
                                    if (!String.IsNullOrEmpty(strsacno))
                                    {
                                        //following line added by dwipraj dutta 19082017
                                        string[] sac = strsacno.Split(':');
                                        strsacno = sac[1];
                                        strsacno = Convert.ToString(clsDataAccess.RunQDTbl("select slno from CompanySACMaster where sacNo = '" + strsacno + "'").Rows[0][0]);

                                        boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO [paybillO]( [BILLNO],[BILLDATE],[OID],[OCHARGES],[ORate],[OQty],[OAMT],SAC,IncGst,ExcSC) VALUES ('" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + OID + ",'" + OCHARGES + "'," + OCRate + "," + OCQty + "," + OAMT + ",'" + strsacno + "'," + strIncGst + "," + strExcSC + ")");
                                    }
                                    else
                                        boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO [paybillO]( [BILLNO],[BILLDATE],[OID],[OCHARGES],[ORate],[OQty],[OAMT],SAC,IncGst,ExcSC) VALUES ('" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + OID + ",'" + OCHARGES + "'," + OCRate + "," + OCQty + "," + OAMT + ",''," + strIncGst + "," + strExcSC + ")");
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                ERPMessageBox.ERPMessage.Show("Please enter Other Description for " + i + " th Row.");
                            }

                        }
                        /*added  by dipraj dutta 070920170431PM will be added soon
                        for (Int32 i = 0; i < dgotherjob.Rows.Count - 1; i++)
                        {
                            dgotherjob.Rows[i].Cells["OCID"].Value = i + 1;
                            string OID = Convert.ToString(dgotherjob.Rows[i].Cells["OCID"].Value);
                            string OCHARGES = Convert.ToString(dgotherjob.Rows[i].Cells["OCDESC"].Value);
                            double OCRate = 0, OCQty = 0, OAMT = 0;

                            try { OCRate = Convert.ToDouble(dgotherjob.Rows[i].Cells["OCRate"].Value); }
                            catch { OCRate = 0; }
                            try { OCQty = Convert.ToDouble(dgotherjob.Rows[i].Cells["OCQty"].Value); }
                            catch { OCRate = 0; }
                            try { OAMT = Convert.ToDouble(dgotherjob.Rows[i].Cells["OCAMT"].Value); }
                            catch { OCRate = 0; }

                            //following changed by dwipraj dutta 19082017
                            string strsacno = Convert.ToString(dgotherjob.Rows[i].Cells["sacnoOC"].Value);


                            if (!String.IsNullOrEmpty(OCHARGES))
                            {
                                if (!String.IsNullOrEmpty(OID))
                                {
                                    if (chkRound == true)
                                    {
                                        OAMT = Convert.ToInt32(OAMT);

                                    }
                                    if (!String.IsNullOrEmpty(strsacno))
                                    {
                                        //following line added by dwipraj dutta 19082017
                                        string[] sac = strsacno.Split(':');
                                        strsacno = sac[1];
                                        strsacno = Convert.ToString(clsDataAccess.RunQDTbl("select slno from CompanySACMaster where sacNo = '" + strsacno + "'").Rows[0][0]);

                                        boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO [paybillO]( [BILLNO],[BILLDATE],[OID],[OCHARGES],[ORate],[OQty],[OAMT],SAC) VALUES ('" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + OID + ",'" + OCHARGES + "'," + OCRate + "," + OCQty + "," + OAMT + ",'" + strsacno + "')");
                                    }
                                    else
                                        boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO [paybillO]( [BILLNO],[BILLDATE],[OID],[OCHARGES],[ORate],[OQty],[OAMT]) VALUES ('" + txtVoucherChallan.Text.Trim() + "',cast(convert(datetime,'" + dtpto.Text + "',103) as datetime)," + OID + ",'" + OCHARGES + "'," + OCRate + "," + OCQty + "," + OAMT + ")");
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                ERPMessageBox.ERPMessage.Show("Please enter Other Description for " + i + " th Row.");
                            }

                        }*/
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("No Record To Save");
                }
            }
            return boolStatus;
        }

        private void cmborderno_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Employ_ID = cmborderno.ReturnValue;
            GetDetails();
        }

        private void GetDetailsOrder()
        {
            //DataTable dtdtl = clsDataAccess.RunQDTbl("select d.Dtl_id,(select DesignationName from tbl_Employee_DesignationMaster where SlNo=d.desig_ID )as 'designation',d.Hour,d.MonthDays,d.RATE from tbl_Employee_OrderDetails_Dtl d where d.Order_Name = '" + co_code + "'");
            //for (int i = 0; i <= dtdtl.Rows.Count - 1; i++)
            //{
            //    dgemployjob.Rows.Add();
            //    dgemployjob.Rows[i].Cells["id"].Value = Convert.ToString(dtdtl.Rows[i]["Dtl_id"]);
            //    dgemployjob.Rows[i].Cells["Designation"].Value = Convert.ToString(dtdtl.Rows[i]["designation"]);
            //    dgemployjob.Rows[i].Cells["Hour"].Value = Convert.ToString(dtdtl.Rows[i]["Hour"]);
            //    dgemployjob.Rows[i].Cells["MontOfDays"].Value = Convert.ToString(dtdtl.Rows[i]["MonthDays"]);
            //    dgemployjob.Rows[i].Cells["Rate"].Value = Convert.ToString(dtdtl.Rows[i]["Rate"]);

            //}


        }
        private void GetDetails()
        {
            if (txtVoucherChallan.Text != "")
            {
                if(dgemployjob.Rows.Count > 1)
                dgemployjob.Rows.Clear();
                dgotherjob.Rows.Clear();
                DataTable dsc = clsDataAccess.RunQDTbl("Select Descord,Session from paybill where (BILLNO='" + txtVoucherChallan.Text.ToString().Trim() + "')");
                //descode
                DataTable dt_des = clsDataAccess.RunQDTbl("select type_desc as 'Description',desccode as 'Code'  from typedoc where (ficode='1') and (gcode='1') and (t_entry='9') and (desccode='" + dsc.Rows[0]["Descord"].ToString() + "') and  (Session='" + dsc.Rows[0]["Session"].ToString() + "')");
                if (dt_des.Rows.Count > 0)
                    cmbdescription.Text = Convert.ToString(dt_des.Rows[0]["Description"]);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                //bellow isGST field has been added by Dwipraj 25/07/2017 5:55PM //h.sac dwipraj dutta 19082017
                DataTable dt35 = clsDataAccess.RunQDTbl("select h.BILLDATE,(select co_name from Company where CO_CODE=h.Comany_id ) as 'coname', h.Session,(select Location_Name from tbl_Emp_Location where Location_ID=h.Location_ID ) as 'locname',h.Month,h.TotAMT,h.IsService,(select cl.Client_Name from tbl_Employee_CliantMaster cl where cl.Client_id =h.Cliant_ID) as 'Client_Name',IsSC,SCPer,isRound,Cliant_ID,Location_ID,isScAdd,h.Comany_id,h.AUTOINCRE,h.isGST,h.ScAmt,h.ServiceAmount,(select csm.serviceName+':'+csm.sacNo as 'SACNo' from CompanySACMaster csm where csm.slno = h.SAC) as 'SAC',h.DUEDATE,h.GstPer,h.billno from paybill h where (h.BILLNO = '" + txtVoucherChallan.Text.ToString().Trim() + "')");
                if (dt35.Rows.Count > 0)
                {
                    this.dtpto.Text = dt35.Rows[0][0].ToString().Trim();
                    try
                    {
                        if (String.IsNullOrEmpty(dt35.Rows[0]["DUEDATE"].ToString().Trim()))
                        {
                            cbDueDate.Checked = false;
                        }
                        else
                        {
                            cbDueDate.Checked = true;
                            this.dtpDueDate.Text = dt35.Rows[0]["DUEDATE"].ToString().Trim();
                        }
                    }
                    catch { cbDueDate.Checked = false; }

                    dateTimePicker1.CustomFormat = "MMMM - yyyy";
                    ////dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    ////string str = string.Format("MMMM - yyyy");
                    ////string ab = dateTimePicker1.Value(str);

                    dateTimePicker1.Value = Convert.ToDateTime("01-"+dt35.Rows[0]["Month"]);

                    cmbmonth.Text = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);


                    this.cmbcompany.Text = dt35.Rows[0][1].ToString().Trim();
                    Company_id =Convert.ToInt32(dt35.Rows[0]["Comany_id"].ToString().Trim());
                    this.cmbYear.Text = dt35.Rows[0][2].ToString().Trim();
                    this.cmbsalstruc.Text = Convert.ToString(dt35.Rows[0][3].ToString().Trim());
                    this.cmbclintname.Text = dt35.Rows[0][7].ToString().Trim();
                    Client_id =Convert.ToInt32(dt35.Rows[0]["Cliant_ID"]);
                    this.cmbLocation.Text = dt35.Rows[0]["Locname"].ToString().Trim();
                    location_id = dt35.Rows[0]["Location_ID"].ToString().Trim();

                    this.dtpto.Text = dt35.Rows[0][0].ToString().Trim();

                    //added by dwipraj dutta 19082017
                    sacServiceCharge.Text = Convert.ToString(dt35.Rows[0]["SAC"]);

                    lblCoid.Text = Company_id.ToString();
                    lblClid.Text = Client_id.ToString();
                    lblLocid.Text = location_id.ToString();

                    txtVoucherChallan.Text = dt35.Rows[0]["billno"].ToString().Trim();

                    if (Convert.ToInt32(clsDataAccess.GetresultS("select count(*) from tbl_Payment_Register where (billNo='" + txtVoucherChallan.Text.Trim() + "') and (tblName='tbl_Payment_Receipt_Register')")) > 0)
                    {
                        lblprevbal.Text = "0";

                    }
                    else
                    {
                        lblprevbal.Text = (Convert.ToDouble(clsDataAccess.GetresultS("SELECT IsNull(SUM(TotAMT + ServiceAmount + ScAmt),0) FROM paybill WHERE (Location_ID ='" + location_id + "') AND (BILLNO <> '" + txtVoucherChallan.Text.Trim() + "')")) - Convert.ToDouble(clsDataAccess.GetresultS("SELECT isNull(sum(ISNULL(amount,0)),0) from tbl_Payment_Receipt_Register WHERE (vchrNo IN (SELECT userVchNo FROM tbl_Payment_Register WHERE (LocationId ='" + location_id + "') AND (tblName = 'tbl_Payment_Receipt_Register')))"))).ToString("0.00");

                    }

                    if (lblprevbal.Text == "")
                    {
                        lblprevbal.Text = "0";
                    }

                       DataTable config = clsDataAccess.RunQDTbl("Select MOD from  Companywiseid_Relation where (Company_ID='" + Company_id + "') and (Location_ID='" + location_id + "') and (prefix<>'' or prefix  IS NOT NULL)");
                       try
                       {
                           if ((config.Rows[0]["MOD"].ToString().Trim().ToUpper() == "MONTHOFDAYS") || (config.Rows[0]["MOD"].ToString().Trim() == "0"))
                           {
                               lblMOD.Text = DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month).ToString();
                           }
                           else
                           {
                               lblMOD.Text = config.Rows[0]["MOD"].ToString();

                           }
                       }
                       catch { }

                    lblbid.Text = dt35.Rows[0]["AUTOINCRE"].ToString().Trim();


/*-------------------------------Added by Dwipraj Dutta 6:03pm 25/07/2017 have to modify in order to make it more dynamic--------------------------------*/
                    
                    
                    DataTable gstInfo = clsDataAccess.RunQDTbl("Select GSTTYPE from Companywiseid_Relation where (Company_ID=" + Company_id + ") and (Location_ID ='" + location_id + "')");
                    string gstapplicable = gstInfo.Rows[0][0].ToString().Trim();
                    //string gstPercentage = clsDataAccess.RunQDTbl("select GSTPER from Branch where GCODE = " + Company_id + "").Rows[0][0].ToString().Trim();
                    string gstPercentage = dt35.Rows[0]["GstPer"].ToString();//Math.Round(100*Convert.ToDouble(dt35.Rows[0]["ServiceAmount"]) / (Convert.ToDouble(dt35.Rows[0]["TotAMT"]) + Convert.ToDouble(dt35.Rows[0]["ScAmt"]))).ToString().Trim();
                    if (gstPercentage == "NaN")
                    {
                        gstPercentage = "0";

                    }

                    if (Convert.ToString(dt35.Rows[0]["isGST"].ToString().Trim()) == "True" || Convert.ToString(dt35.Rows[0]["IsService"].ToString().Trim()) == "False")            //2nd condition added at 040820170148PM : Reason : If bill has no Service Tax or GST checked then by default the GST option will be appeared.
                    {
                        //checkBox1.Checked = true;
                        btnChange.Visible = false;
                        if (gstapplicable == "LOCAL")
                        {
                            checkBox1.Text = "GST";
                            label9.Text = "SGST%@";
                            txtSTPer.Text = (Convert.ToDouble(gstPercentage) / 2).ToString();
                            label13.Visible = true;
                            cgstPer.Visible = true;
                            cgstPer.Text = (Convert.ToDouble(gstPercentage) / 2).ToString();
                        }
                        else
                        {
                            checkBox1.Text = "GST";
                            label9.Text = "IGST%@";
                            txtSTPer.Text = gstPercentage;
                            label13.Visible = false;
                            cgstPer.Visible = false;
                        }
                    }
                    else
                    {
                        btnChange.Visible = true;
                        checkBox1.Text = "Service Tax";
                        label9.Text = "Service Tax % @";
                        //txtSTPer.Text = "14.5";
                        label13.Visible = false;
                        cgstPer.Visible = false;
                    }
/*-------------------------------------------------------------end of 6:04pm------------------------------------------------------------------------*/
                    if (Convert.ToString(dt35.Rows[0][6].ToString().Trim()) == "True" || Convert.ToString(dt35.Rows[0]["isGST"].ToString().Trim()) == "True")   //Added by dwipraj dutta 010820170638PM
                    {
                        this.checkBox1.Checked = true;
                    }
                    else
                    {
                        this.checkBox1.Checked = false;
                    }

                    if (Convert.ToString(dt35.Rows[0]["IsSC"].ToString().Trim()) == "True")
                    {
                        this.ChkServiceChaerge.Checked = true;
                    }
                    else
                    {
                        this.ChkServiceChaerge.Checked = false;
                    }
                    if (Convert.ToString(dt35.Rows[0]["IsScAdd"].ToString().Trim()) == "True")
                    {
                        this.rdbCharged.Checked=true;
                    }
                    else
                    {
                        this.rdbChargeN.Checked = true;
                    }
                    if (Convert.ToString(dt35.Rows[0]["IsRound"].ToString().Trim()) == "True")
                    {
                        this.chkRound.Checked = true;
                    }
                    else
                    {
                        this.chkRound.Checked = false;
                    }
                    this.TxtPer.Text = dt35.Rows[0]["SCPer"].ToString();
                    
                    //this.cmbmonth.Text = Convert.ToString(dt35.Rows[0][4].ToString().Trim());
               
               

                }
                //change made in following line 18082017
                DataTable dt = clsDataAccess.RunQDTbl("select d.Dtl_id,d.ref_order_no,d.ref_order_date,"+
                    "(select DesignationName from tbl_Employee_DesignationMaster where SlNo=d.desig_ID )as 'designation',d.Hour,d.MonthDays,d.Attendance,"+
                    "d.BILLAMT,d.RATE,(select Location_Name from tbl_Emp_Location where Location_ID=d.Location_ID ) as 'locname',"+
                    "(select serviceName+':'+sacNo from CompanySACMaster where slno = d.SAC) as 'SAC',rmrks,d.NoOfPersonnel,GstPer,Gst from paybillD d where d.BILLNO = '" + txtVoucherChallan.Text.ToString().Trim() + "'");
                for (int i = 0; i <= dt.Rows.Count - 1;i++)
                {
                    dgemployjob.Rows.Add();
                    dgemployjob.Rows[i].Cells["id"].Value = Convert.ToString(dt.Rows[i]["Dtl_id"]);
                    dgemployjob.Rows[i].Cells["locationname"].Value = Convert.ToString(dt.Rows[i]["locname"]);

                    dgemployjob.Rows[i].Cells["OrderNo"].Value = Convert.ToString(dt.Rows[i]["ref_order_no"]);
                    dgemployjob.Rows[i].Cells["orderdate"].Value = Convert.ToString(dt.Rows[i]["ref_order_date"]);
                    

                    dgemployjob.Rows[i].Cells["Designation"].Value = Convert.ToString(dt.Rows[i]["designation"]);

                    //change made in following line 18082017
                    dgemployjob.Rows[i].Cells["sacno"].Value = Convert.ToString(dt.Rows[i]["SAC"]);

                    dgemployjob.Rows[i].Cells["Hour"].Value = Convert.ToString(dt.Rows[i]["Hour"]);
                    dgemployjob.Rows[i].Cells["MontOfDays"].Value = Convert.ToString(dt.Rows[i]["MonthDays"]);
                    dgemployjob.Rows[i].Cells["Attendance"].Value = Convert.ToString(dt.Rows[i]["Attendance"]);
                    double  _rate = 0.00;
                    _rate = Convert.ToDouble(dt.Rows[i]["Rate"]);
                    dgemployjob.Rows[i].Cells["Rate"].Value = _rate;
                    dgemployjob.Rows[i].Cells["Amount"].Value = Convert.ToDouble(dt.Rows[i]["BILLAMT"]);
                    dgemployjob.Rows[i].Cells["colRmrks"].Value = Convert.ToString(dt.Rows[i]["rmrks"]);
                    dgemployjob.Rows[i].Cells["Personnel"].Value = Convert.ToString(dt.Rows[i]["NoOfPersonnel"]);


                    dgemployjob.Rows[i].Cells["Gst_Per"].Value = Convert.ToString(dt.Rows[i]["GstPer"]);
                    dgemployjob.Rows[i].Cells["Gst_Amt"].Value = Convert.ToString(dt.Rows[i]["Gst"]); 
                   
                   
                }

                DataTable dt2 = clsDataAccess.RunQDTbl("select [OID],[OCHARGES],[ORate],[OQty],[OAttend],[OAMT],"+
                    "(select serviceName+':'+sacNo from CompanySACMaster where slno = d.SAC) as 'SAC',isNull(IncGst,0)as IncGst,"+
                    "isNull(ExcSC,0)as ExcSC,GstPer,Gst FROM [paybillO] d where (BILLNO ='" + txtVoucherChallan.Text.ToString().Trim() + "')");
                 for (int i = 0; i < dt2.Rows.Count ; i++)
                 {
                     dgotherjob.Rows.Add();
                     dgotherjob.Rows[i].Cells["OCID"].Value = Convert.ToString(dt2.Rows[i]["OID"]);
                     dgotherjob.Rows[i].Cells["OCDESC"].Value = Convert.ToString(dt2.Rows[i]["OCHARGES"]);
                     dgotherjob.Rows[i].Cells["sacnoOC"].Value = Convert.ToString(dt2.Rows[i]["SAC"]);
                     dgotherjob.Rows[i].Cells["IncGST"].Value = Convert.ToString(dt2.Rows[i]["IncGst"]);
                     dgotherjob.Rows[i].Cells["ExcSC"].Value = Convert.ToString(dt2.Rows[i]["ExcSC"]);
                     
                     double oamt=0,ORate=0,OQty=0,OAttend=0;

                     try
                     {
                         OAttend = Convert.ToDouble(dt2.Rows[i]["OAttend"]);
                     }
                     catch { OAttend = 0; }

                     try
                     { ORate = Convert.ToDouble(dt2.Rows[i]["ORate"]); }
                     catch { ORate = 0; }

                     try
                     { OQty = Convert.ToDouble(dt2.Rows[i]["OQty"]); }
                     catch { OQty = 0; }
                     
                     try
                     { oamt = Convert.ToDouble(dt2.Rows[i]["OAMT"]); }
                     catch {oamt = 0;}
                     
                     dgotherjob.Rows[i].Cells["OCAMT"].Value = oamt;
                     dgotherjob.Rows[i].Cells["OCQty"].Value = OQty;
                     dgotherjob.Rows[i].Cells["OCRate"].Value = ORate;
                     dgotherjob.Rows[i].Cells["OCAttend"].Value = OAttend;


                     dgotherjob.Rows[i].Cells["OC_Gst_Per"].Value = Convert.ToString(dt2.Rows[i]["GstPer"]);
                     dgotherjob.Rows[i].Cells["OC_Gst_Amt"].Value = Convert.ToString(dt2.Rows[i]["Gst"]); 
                 }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int Allocate_ID = Convert.ToInt32(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["id"].Value);
                if (Information.IsNumeric(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["id"].Value) == true)
                {

                }
            }
            catch { }
            Boolean boolStatus = false;
            ERPMessageBox.ERPMessage.Show("Are You Sure to Delete  ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
            if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
            {
                DataTable chkPaymentExistsAgainstBill = clsDataAccess.RunQDTbl("select * from tbl_Payment_Register where billNo = '" + txtVoucherChallan.Text.ToString().Trim() + "'");
                if (chkPaymentExistsAgainstBill.Rows.Count == 0)
                {
                    boolStatus = clsDataAccess.RunNQwithStatus("Delete from paybill where BILLNO ='" + txtVoucherChallan.Text.ToString().Trim() + "'");
                    boolStatus = clsDataAccess.RunNQwithStatus("Delete from paybillD where BILLNO='" + txtVoucherChallan.Text.ToString().Trim() + "'");
                    boolStatus = clsDataAccess.RunNQwithStatus("Delete from paybillO where BILLNO='" + txtVoucherChallan.Text.ToString().Trim() + "'");
                    if (boolStatus)
                    {
                        int ss = 0;
                        string[] s = new string[] { };
                        s = txtVoucherChallan.Text.Trim().Split('/');
                        if (s.Length == 3)
                            try
                            {
                                ss = Convert.ToInt32(s[2]);
                            }
                            catch
                            {
                                ss = Convert.ToInt32(s[1]);
                            }
                        //edpcom.delCurrentVoucher("9", ss, descode, cmbYear.Text);
                        ERPMessageBox.ERPMessage.Show("Bill Deleted Successfully, If required to change series number goto 'Document Number' and update");
                        //GetDetails();
                        btnCLear_Click(sender, e);
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Payment against this bill number Exists. Please delete all payment records in order to delete the bill information.");
                }
            }
        }

        private void cmbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetDetailsOrder();

            //string mnth = "";
            //mnth = cmbmonth.SelectedText;

            //string strsql4 = " select bill_tag from tbl_Employee_SalaryMast where Cliant_ID='" + clsEmployee.GetClintID(cmbclintname.Text) + "' and Location_ID='' and Comany_id='' and SESSION='' and MONTH='' ";
            //DataTable dt24 = clsDataAccess.RunQDTbl(strsql4);
            



        }

        private void dgemployjob_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbmonth.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Month Name Can not Blank");
                cmbmonth.DroppedDown = true;
                cmbmonth.SelectedIndex = 0;
                cmbmonth.Focus();
                return;
            }

            if (dgemployjob.Columns[e.ColumnIndex].HeaderText == "Designation")
            {
                string mnth = "";
                mnth = cmbmonth.Text;

                string _session = "";
                _session = cmbYear.Text;

                string var = "";
                  try
                {
                var = dgemployjob.Rows[e.RowIndex].Cells["locationname"].Value.ToString();
                }
                  catch { var = ""; }
                string _desig = "";
                try{
                _desig = dgemployjob.Rows[e.RowIndex].Cells["Designation"].Value.ToString();
                }
                catch { _desig = ""; }

                string strsql4 = " select Desig_Id,bill_tag from tbl_Employee_SalaryMast where Location_ID=" + clsEmployee.GetlocID(var) + "  and Company_id='" + get_CompID(cmbcompany.Text) + "'  and SESSION='" + _session + "' and MONTH='" + mnth + "' and Desig_Id=" + clsEmployee.GetDesgId(_desig) + "  group by Desig_Id,bill_tag";
                
                DataTable dt24 = clsDataAccess.RunQDTbl(strsql4);

                if (dt24.Rows.Count > 0)
                {
                    if (dt24.Rows[0]["bill_tag"].ToString().Trim() == "1")
                    {
                        ERPMessageBox.ERPMessage.Show("Already billed the " + _desig + "for the month of " + mnth);
                        dgemployjob.ClearSelection();

                        dgemployjob.Rows[dgemployjob.CurrentCell.RowIndex].Cells["Designation"].Selected = true;
                        dgemployjob.CurrentCell = dgemployjob[5, dgemployjob.CurrentCell.RowIndex];
                        return;
                    }
                }
            }


            if (dgemployjob.Columns[e.ColumnIndex].HeaderText == "Location Site Name")
            {
                string strsql4 = "select Location_Name  from tbl_Emp_Location where Cliant_ID=" + clsEmployee.GetClintID(cmbclintname.Text) + "";
                DataTable dt24 = clsDataAccess.RunQDTbl(strsql4);
                DataGridViewComboBoxColumn dgcombo44 = dgemployjob.Columns["locationname"] as DataGridViewComboBoxColumn;
                dgcombo44.Items.Clear();
                for (int i = 0; i <= dt24.Rows.Count - 1; i++)
                {
                    string st = Convert.ToString(dt24.Rows[i]["Location_Name"]);
                    dgcombo44.Items.Add(st);
                }


                string var = "";
                try
                {
                    var = dgemployjob.Rows[e.RowIndex].Cells["locationname"].Value.ToString();
                }
                catch { var = ""; }
                string strsql = "";
                //strsql = "select  distinct (select t.DesignationName  from tbl_Employee_DesignationMaster t";
                //strsql = strsql + " where t.SlNo=m.DesgId ) as 'DesignationName',m.Location_id from tbl_Employee_Mast  m where m.Location_id =" + clsEmployee.GetlocID(var) + " ";
                strsql = "select distinct DesignationName from tbl_Employee_DesignationMaster";
                DataTable dt2 = clsDataAccess.RunQDTbl(strsql);
                DataGridViewComboBoxColumn dgcombo5 = dgemployjob.Columns["Designation"] as DataGridViewComboBoxColumn;
                dgcombo5.Items.Clear();

                for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                {


                    string st = Convert.ToString(dt2.Rows[i]["DesignationName"]);
                    dgcombo5.Items.Add(st);
                }
            }

            string loc = "";
            string desig = "";
           
            
            if (dgemployjob.Rows[e.RowIndex].Cells["Designation"].Value !=null)
            {
                string var = "";
                var = dgemployjob.Rows[e.RowIndex].Cells["locationname"].Value.ToString();

                string strsql = "";
                //strsql = "select  distinct (select t.DesignationName  from tbl_Employee_DesignationMaster t";
                //strsql = strsql + " where t.SlNo=m.DesgId ) as 'DesignationName',m.Location_id from tbl_Employee_Mast  m where m.Location_id =" + clsEmployee.GetlocID(var) + " ";
                strsql = "select distinct DesignationName from tbl_Employee_DesignationMaster";
                DataTable dt2 = clsDataAccess.RunQDTbl(strsql);
                DataGridViewComboBoxColumn dgcombo5 = dgemployjob.Columns["Designation"] as DataGridViewComboBoxColumn;
                dgcombo5.Items.Clear();

                for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                {
                    string st = Convert.ToString(dt2.Rows[i]["DesignationName"]);
                    dgcombo5.Items.Add(st);
                }

                 try
                {
                loc = dgemployjob.Rows[e.RowIndex].Cells["locationname"].Value.ToString();
                }
                 catch { loc = ""; }
                 try
                {
                desig = dgemployjob.Rows[e.RowIndex].Cells["Designation"].Value.ToString();
                     }
                 catch { desig = ""; }
               
                string sqlstr = "";
                sqlstr = "select  sum(sm.TotalDays) as 'Attandance',(select  e.DesignationName  from tbl_Employee_DesignationMaster e where e.SlNo =m.DesgId ) as [DesignationName]  from tbl_Employee_SalaryMast sm inner join tbl_Employee_Mast m ";
                sqlstr = sqlstr + " on sm.Location_id=m.Location_id where sm.Emp_Id=m.id and sm.Month='" + cmbmonth.Text + "' and m.DesgId=" + clsEmployee.GetDesgId(desig) + "  and m.Location_id =" + clsEmployee.GetlocID(loc) + " group by m.DesgId ";
                DataTable dtid = clsDataAccess.RunQDTbl(sqlstr);

                if (dtid.Rows.Count > 0)
                {

                    if ((dtid.Rows.Count > 0) && (Information.IsNumeric(dtid.Rows[0][0]) == true))
                    {
                        if ((dgemployjob.Rows[e.RowIndex].Cells["Attendance"].Value == "") || (dgemployjob.Rows[e.RowIndex].Cells["Attendance"].Value == "0") || (dgemployjob.Rows[e.RowIndex].Cells["Attendance"].Value == null))
                        {
                            dgemployjob.Rows[e.RowIndex].Cells["Attendance"].Value = Convert.ToString(dtid.Rows[0][0]);
                        }
                    }
                }
                else
                {
                    //ERPMessageBox.ERPMessage.Show("Attendance not found in '" + desig + "' for the month of '" + cmbmonth.Text + "'");
                }
            }




            //string strdesigid = "";
            //if (dt2.Rows.Count > 0)
            //{
            //    strdesigid = dt2.Rows[0][0].ToString();
            //}
            //if (strdesigid != "")
            //{
            //    string sqlstr = "select  sum(sm.TotalDays) as 'Attandance',(select  e.DesignationName  from tbl_Employee_DesignationMaster e where e.SlNo =m.DesgId ) as [DesignationName]  from tbl_Employee_SalaryMast sm inner join tbl_Employee_Mast m ";
            //    sqlstr = sqlstr + " on sm.Location_id=m.Location_id where sm.Month='" + cmbmonth.Text + "' and m.DesgId=" + clsEmployee.GetDesgId(strdesigid) + " group by m.DesgId ";
            //    DataTable dtid = clsDataAccess.RunQDTbl(sqlstr);
            //    if ((dtid.Rows.Count > 0) && (Information.IsNumeric(dtid.Rows[0][0]) == true))
            //    {
            //        dgemployjob.Rows[e.RowIndex].Cells["Attendance"].Value = Convert.ToString(dtid.Rows[0][0]);
            //    }
            //}

            calculateAmt();

           
            ////string strHour = Convert.ToString(dgemployjob.Rows[e.RowIndex].Cells["Hour"].Value);



            ////if (dgemployjob.Columns[e.ColumnIndex].HeaderText == "MontOfDays")
            ////{
                
            ////    if (cmbmonth.Text != clsEmployee.GetMonthName(Convert.ToDateTime(dgemployjob.Rows[e.RowIndex].Cells["fromdate"].Value).Month))
            ////    {
            ////        ERPMessageBox.ERPMessage.Show("From Date not inside the Selected Month");
            ////        //dgemployjob.Rows[e].Cells["fromdate"].Value = "s";                    
            ////    }
            ////}
        }
        private void calculateAmt()
        {
            ////if ((Information.IsNumeric(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value) == true) && (Information.IsNumeric(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value) == true) && (Information.IsNumeric(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value) == true) && (Information.IsNumeric(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) == true))

            if ((Information.IsNumeric(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value) == true) && (Information.IsNumeric(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value) == true) && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value !="") && (Information.IsNumeric(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) == true))

            {
                if ((dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "8") && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString() == "26"))
                {
                    dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(( (Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) /Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value) )* Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)),2);
                }
                else if ((dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "12") && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString() == "26"))
                {
                    if (setting_type == "type 1")
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);
                    }
                    else
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);
                    }
                }

                else if ((dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "8") && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString() == "MOD-SUNDAY"))
                {

                    dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(NoOfWorkingDays(dateTimePicker1.Value))) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);

                }
                else if ((dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "12") && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString() == "MOD-SUNDAY"))
                {
                    if (setting_type == "type 1")
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(NoOfWorkingDays(dateTimePicker1.Value))) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);
                    }
                    else
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(NoOfWorkingDays(dateTimePicker1.Value))) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);

                    }
                }

                else if ((dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "8") && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString().Length>=5 && dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString().Substring(0,5) == "RANGE"))
                {
                    string modVal = dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString();
                    int fromDate = Convert.ToInt32(modVal.Substring(5,(modVal.IndexOf("-")-5)));
                    int toDate = Convert.ToInt32(modVal.Substring(modVal.IndexOf("-")+1));
                    dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(NoOfWorkingDays(dateTimePicker1.Value,fromDate,toDate))) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);

                }
                else if ((dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "12") && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString().Length>=5&&dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString().Substring(0,5) == "RANGE"))
                {
                    string modVal = dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString();
                    int fromDate = Convert.ToInt32(modVal.Substring(5, (modVal.IndexOf("-") - 5)));
                    int toDate = Convert.ToInt32(modVal.Substring(modVal.IndexOf("-") + 1));
                    if (setting_type == "type 1")
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(NoOfWorkingDays(dateTimePicker1.Value, fromDate, toDate))) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);
                    }
                    else
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(NoOfWorkingDays(dateTimePicker1.Value, fromDate, toDate))) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);

                    }
                }

                else if ((dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "8") && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString() == "MonthOfDays"))
                {

                   dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(calculated_days)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);

                }
                else if ((dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "12") && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString() == "MonthOfDays"))
                {
                    if (setting_type == "type 1")
                    {
                    dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(calculated_days)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);
                    }
                    else
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(calculated_days)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);

                    }
                }

                else if ((dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "8") && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString() == "PerDay"))
                {

                    dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(1)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);

                }
                else if ((dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "12") && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString() == "PerDay"))
                {
                    if (setting_type == "type 1")
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(1)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);
                    }
                    else
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(1)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);

                    }
                }

                else if ((dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "8") && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString() == "PerHour"))
                {

                    dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(1)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);

                }
                else if ((dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "12") && (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value.ToString() == "PerHour"))
                {
                    if (setting_type == "type 1")
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(1)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);
                    }
                    else
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(1)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);

                    }
                }
                else
                {
                    double cdays =0;
                    try
                    {
                        cdays = Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["MontOfDays"].Value);
                    }
                    catch {
                        cdays = 0;
                    }

                    if (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "8")
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(cdays)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);
                    }
                    else if (dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Hour"].Value.ToString() == "12")
                    {
                        if (setting_type == "type 1")
                    {
                        dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(cdays)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);
                        } else {

                            dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value = Math.Round(((Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Rate"].Value) / Convert.ToDouble(cdays)) * Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Attendance"].Value)), 2);
                        }
                    }
                }

                dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["gst_amt"].Value = (Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["Amount"].Value) * (Convert.ToDouble(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["gst_per"].Value) / 100)).ToString("0.00");

            }
        }


        private void dgemployjob_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ////////if (dgemployjob.Columns[e.ColumnIndex].HeaderText == "Cliant Name")
            ////////{
            ////////    dgemployjob.Rows[e.RowIndex].Cells["OrderNo"].Value = "";
            ////////    dgemployjob.Rows[e.RowIndex].Cells["locationname"].Value = "";
            ////////    if (cmborderno.Text == "")
            ////////    {
            ////////        ERPMessageBox.ERPMessage.Show("Employ Name Can not Blank");
            ////////        cmborderno.PopUp();
            ////////    }
            ////////}
            try
            {
                string strsql4 = "select Location_Name  from tbl_Emp_Location where Cliant_ID=" + clsEmployee.GetClintID(cmbclintname.Text) + "";
                DataTable dt24 = clsDataAccess.RunQDTbl(strsql4);
                DataGridViewComboBoxColumn dgcombo44 = dgemployjob.Columns["locationname"] as DataGridViewComboBoxColumn;
                dgcombo44.Items.Clear();
                for (int i = 0; i <= dt24.Rows.Count - 1; i++)
                {
                    string st = Convert.ToString(dt24.Rows[i]["Location_Name"]);
                    dgcombo44.Items.Add(st);
                }
            }
            catch { }

            try
            {
            DataTable dt2 = clsDataAccess.RunQDTbl("select DesignationName from tbl_Employee_DesignationMaster ");
            DataGridViewComboBoxCell dgcombo1 = new DataGridViewComboBoxCell();
            dgcombo1.Items.Clear();
            for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dt2.Rows[i]["DesignationName"]);
                dgcombo1.Items.Add(st);
            }
            ////////this.dgemployjob["DesignationName", e.RowIndex] = dgcombo1;
               
            }
            catch { }
             try
            {
            if (dgemployjob.Columns[e.ColumnIndex].HeaderText == "MontOfDays")
            {
                string strMontOfDays = Convert.ToString(dgemployjob.Rows[e.RowIndex].Cells["MontOfDays"].Value);
                decimal strRate = Convert.ToInt32 (dgemployjob.Rows[e.RowIndex].Cells["Rate"].Value) ;
                decimal stramt=Convert.ToInt32 (dgemployjob.Rows[e.RowIndex].Cells["Amount"].Value) ;

                 //decimal stramt=Convert.ToInt32 (dgemployjob.Rows[e.RowIndex].Cells["Amount"].Value) ;

                if (strMontOfDays != "")
                {
                    //dgemployjob.Rows[e.RowIndex].Cells["Amount"]=strRate/strMontOfDays*

                //////////    DataTable dt = clsDataAccess.RunQDTbl("select Client_id from tbl_Employee_CliantMaster where Client_Name = '" + strCliantName + "'");
                //////////    if (dt.Rows.Count > 0)
                //////////        strCliantName = Convert.ToString(dt.Rows[0]["Client_id"]);
                //////////    DataTable dt1 = clsDataAccess.RunQDTbl("select Location_Name from tbl_Emp_Location where Cliant_ID='" + strCliantName + "' ");
                //////////    DataGridViewComboBoxCell dgcombo1 = new DataGridViewComboBoxCell();
                //////////    dgcombo1.Items.Clear();
                //////////    for (int i = 0; i <= dt1.Rows.Count - 1; i++)
                //////////    {
                //////////        string st = Convert.ToString(dt1.Rows[i]["Location_Name"]);
                //////////        dgcombo1.Items.Add(st);
                //////////    }
                //////////    this.dgemployjob["locationname", e.RowIndex] = dgcombo1;



                //////////    DataTable dt2 = clsDataAccess.RunQDTbl("select Order_Name from tbl_Employee_OrderDetails where Cliant_ID = '" + strCliantName + "' ");
                //////////    DataGridViewComboBoxCell dgcombo2 = new DataGridViewComboBoxCell();                    
                //////////    dgcombo2.Items.Clear();
                //////////    for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                //////////    {
                //////////        string st = Convert.ToString(dt2.Rows[i]["Order_Name"]);
                //////////        dgcombo2.Items.Add(st);
                //////////    }
                //////////    this.dgemployjob["OrderNo", e.RowIndex] = dgcombo2;
                }
            }
                   }
            catch { }
             try
            {
                 if (e.ColumnIndex==10)
                 {
                     if (Convert.ToDouble(dgemployjob.Rows[e.RowIndex].Cells["Amount"].Value) == 0)
                     {
                     double KITMONTH = 0;
                     try
                     {
                         KITMONTH = Convert.ToDouble(dgemployjob.Rows[e.RowIndex].Cells["Attendance"].Value);
                     }
                     catch { KITMONTH = 0; }

                     double KITVAL = 0;
                     try
                     {
                         KITVAL = Convert.ToDouble(dgemployjob.Rows[e.RowIndex].Cells["Rate"].Value);
                     }
                     catch { KITVAL = 0; }

                     double KITEMI = Convert.ToDouble(KITVAL) * Convert.ToDouble(KITMONTH);
                     dgemployjob.Rows[e.RowIndex].Cells["Amount"].Value = KITEMI;

                     dgemployjob.Rows[e.RowIndex].Cells["gst_amt"].Value = KITEMI * (Convert.ToDouble(dgemployjob.Rows[e.RowIndex].Cells["gst_per"].Value)/100);
                 }
             }
                    }
            catch { }
           
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Select Session"))
            {
                cmbdescription_CloseUp();
            }
        }

        private void cmbdescription_CloseUp()
        {
            descode = 0;

            if (edpcom.CurrentFicode.Trim() == "")
            {
                edpcom.CurrentFicode = "1";
            }

            if (Information.IsNumeric(cmbdescription.ReturnValue) == true)
                descode = Convert.ToInt32(cmbdescription.ReturnValue);
            txtVoucherChallan.Text = GetDocNumber(descode, "9", cmbYear.Text);
            //edpcom.GetDocNumber(descode, "9",cmbYear.Text);
            dtpto.Focus();
        }

        private void cmbclintname_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select Client_Name,client_id as ClientID from tbl_Employee_CliantMaster order by Client_Name");
            if (dt.Rows.Count > 0)
            {
                cmbclintname.LookUpTable = dt;
                cmbclintname.ReturnIndex = 1;
            }

            //string strsql = "select  distinct  (select t.DesignationName  from tbl_Employee_DesignationMaster t where t.SlNo=m.DesgId ) as 'DesignationName',m.Location_id  from tbl_Employee_Mast  m where m.Location_id =(select l.Location_ID from tbl_Emp_Location l where l.Cliant_ID=" + clsEmployee.GetClintID(cmbclintname.Text) + ")";
            //DataTable dt2 = clsDataAccess.RunQDTbl(strsql);         
            //DataGridViewComboBoxColumn dgcombo3 = dgemployjob.Columns["Designation"] as DataGridViewComboBoxColumn;
            //dgcombo3.Items.Clear();
            //for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            //{
            //    string st = Convert.ToString(dt2.Rows[i]["DesignationName"]);
            //    dgcombo3.Items.Add(st);
            //}
        }

        private void cmbsalstruc_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDetailsOrder();
        }

        private void cmbclintname_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbclintname.ReturnValue) == true)
                Client_id  = Convert.ToInt32(cmbclintname.ReturnValue);

            switch(cmbBillType.SelectedIndex)
            {
                case 0:
                    string strsql = "select Location_Name  from tbl_Emp_Location where (Cliant_ID=" + Client_id + ")";// clsEmployee.GetClintID(cmbclintname.Text) + "";
                    DataTable dt2 = clsDataAccess.RunQDTbl(strsql);
                    DataGridViewComboBoxColumn dgcombo4 = dgemployjob.Columns["locationname"] as DataGridViewComboBoxColumn;
                    dgcombo4.Items.Clear();
                    for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        string st = Convert.ToString(dt2.Rows[i]["Location_Name"]);
                        dgcombo4.Items.Add(st);
                    }
                    break;
            }
        }

        public void contract()
        {
            Label lb = new Label();
            Label lb1 = new Label();
            int val_ot = 0;
            string prx = "";
            if (cmbBillType.SelectedIndex == 0)
            {
                try
                {
                    string arrayItem = "";
                    string mod_val;
                    int mod_days = 0;
                    int bmod = 0;
                    val_ot = 0;
                    string sqlstmnt = "Select Order_Name,Order_Date,Location,Order_ID from tbl_Employee_OrderDetails where (Co_Code='" + Company_id + "') and (Cliant_ID='" + Client_id + "') and (ltrim(rtrim(location))='" + cmbLocation.Text.Trim() + "')";

                    DataTable dt2 = clsDataAccess.RunQDTbl(sqlstmnt);
                    if (dt2.Rows.Count > 1)
                    {


                        EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Item Name", "List of Item Name", 0, "CMPN", 0);

                        arritem.Clear();
                        arritem = EDPCommon.arr_mod;

                        for (int i = 0; i < arritem.Count; i++)
                        {
                            if (arrayItem.Trim() == "")
                            {
                                arrayItem = "'" + arritem[i].ToString().Trim() + "'";
                            }
                            else
                            {
                                arrayItem = arrayItem + ",'" + arritem[i].ToString().Trim() + "'";
                            }

                        }
                    }
                    else
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            arrayItem = "'" + dt2.Rows[i]["Order_Name"].ToString() + "'";

                        }
                    }



                    dgemployjob.Rows.Clear();
                    if (arritem.Count > 0 || arrayItem.Trim() != "")
                    {

                        DataTable dtdtl = clsDataAccess.RunQDTbl("select d.Dtl_id,d.Order_Name,d.Order_Date,(select DesignationName from tbl_Employee_DesignationMaster where SlNo=d.desig_ID )as 'designation',(select h.Location  from tbl_Employee_OrderDetails h where h.Order_Name=d.Order_Name  ) as 'locname',d.Hour,d.MonthDays,d.RATE,d.desig_ID,d.rmrks,d.bmod,(select serviceName+':'+sacNo as 'SACNo' from CompanySACMaster where slno = d.SAC) as 'SAC',(select h.Enclosure  from tbl_Employee_OrderDetails h where h.Order_Name=d.Order_Name  ) as 'Enclosure',d.nop,ODesg from tbl_Employee_OrderDetails_Dtl d where d.Order_Name  in (" + arrayItem.ToString().Trim() + ")");

                        for (int y = 0; y <= dtdtl.Rows.Count - 1; y++)
                        {
                            dgemployjob.Rows.Add();
                            dgemployjob.Rows[y].Cells["id"].Value = Convert.ToString(dtdtl.Rows[y]["Dtl_id"]);
                            dgemployjob.Rows[y].Cells["locationname"].Value = Convert.ToString(dtdtl.Rows[y]["locname"]);
                            dgemployjob.Rows[y].Cells["Designation"].Value = Convert.ToString(dtdtl.Rows[y]["designation"]);

                            if (!String.IsNullOrEmpty(Convert.ToString(dtdtl.Rows[y]["SAC"])))
                            {
                                dgemployjob.Rows[y].Cells["sacno"].Value = Convert.ToString(dtdtl.Rows[y]["SAC"]);
                            }

                            try
                            {
                                string encid = Convert.ToString(dtdtl.Rows[y]["enclosure"]).Replace('|', ',');
                                if (encid.Trim() == "") { lblEnclosure.Text = ""; }
                                else
                                {

                                    lblEnclosure.Text = "";
                                    DataTable enc = clsDataAccess.RunQDTbl("select enclosure from tbl_enclosure where eid in (" + encid + ")");
                                    for (int indx = 0; indx < enc.Rows.Count; indx++)
                                    {
                                        if (lblEnclosure.Text.Trim() == "")
                                        {
                                            lblEnclosure.Text = (indx + 1) + "-" + enc.Rows[indx]["enclosure"].ToString().Trim();

                                        }
                                        else
                                        {
                                            lblEnclosure.Text = lblEnclosure.Text + Environment.NewLine + (indx + 1) + "-" + enc.Rows[indx]["enclosure"].ToString().Trim();
                                        }
                                    }
                                }
                            }
                            catch { }

                            dgemployjob.Rows[y].Cells["Hour"].Value = Convert.ToString(dtdtl.Rows[y]["Hour"]);
                            mod_val = Convert.ToString(dtdtl.Rows[y]["MonthDays"]);
                            string sqlstr = "";
                            if (mod_val == "MonthOfDays")
                            {
                                mod_days = System.DateTime.DaysInMonth(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value.Month);
                            }
                            else if (mod_val == "MOD-SUNDAY")
                            {
                                mod_days = NoOfWorkingDays(dateTimePicker1.Value);
                            }
                            else if (mod_val.Length>=5 && mod_val.Substring(0, 5) == "RANGE")
                            {
                                string modVal = mod_val;
                                int fromDate = Convert.ToInt32(modVal.Substring(5, (modVal.IndexOf("-") - 5)));
                                int toDate = Convert.ToInt32(modVal.Substring(modVal.IndexOf("-") + 1));
                                mod_days = NoOfWorkingDays(dateTimePicker1.Value, fromDate, toDate);
                            }
                            else if (mod_val == "26")
                            {
                                mod_days = 26;
                            }
                            else if (mod_val == "PerDay" || mod_val == "PerHour")
                            {
                                mod_days = 1;
                            }
                            dgemployjob.Rows[y].Cells["MontOfDays"].Value = Convert.ToString(dtdtl.Rows[y]["MonthDays"]);
                            dgemployjob.Rows[y].Cells["OrderNo"].Value = Convert.ToString(dtdtl.Rows[y]["Order_Name"]);
                            dgemployjob.Rows[y].Cells["orderdate"].Value = Convert.ToDateTime(dtdtl.Rows[y]["Order_Date"]).ToShortDateString();


                            double _rate = 0.00;
                            _rate = Convert.ToDouble(dtdtl.Rows[y]["Rate"]);
                            dgemployjob.Rows[y].Cells["Rate"].Value = _rate;
                            if (Convert.ToString(dtdtl.Rows[y]["rmrks"]).Trim() != "")
                            {
                                dgemployjob.Rows[y].Cells["colRmrks"].Value = Convert.ToString(dtdtl.Rows[y]["rmrks"]).Trim();
                            }
                            else
                            {
                                dgemployjob.Rows[y].Cells["colRmrks"].Value = "";
                            }
                            //for calculating attandance
                            string loc1 = "";
                            string desig1 = "",ODesg="";
                            prx = "";
                            loc1 = dgemployjob.Rows[y].Cells["locationname"].Value.ToString();
                            desig1 = dtdtl.Rows[y]["desig_ID"].ToString();
                            ODesg = dtdtl.Rows[y]["ODesg"].ToString();
                            //sqlstr = "select  sum(sm.TotalDays) as 'Attandance',(select  e.DesignationName from tbl_Employee_DesignationMaster e where e.SlNo =m.DesgId ) as [DesignationName]  from tbl_Employee_SalaryMast sm inner join tbl_Employee_Mast m ";
                            //sqlstr = sqlstr + " on sm.Location_id=m.Location_id where sm.Emp_Id=m.id and sm.Month='" + cmbmonth.Text + "' and m.DesgId=" + clsEmployee.GetDesgId(desig1) + "  and m.Location_id =" + clsEmployee.GetlocID(loc1) + " group by m.DesgId ";

                            //sqlstr = "select  sum(sm.DaysPresent + sm.OT) as 'Attandance',(select  e.DesignationName from tbl_Employee_DesignationMaster e where e.SlNo =" + desig1 + " ) as [DesignationName]  from tbl_Employee_SalaryMast sm inner join tbl_Employee_Attend m ";
                            //sqlstr = sqlstr + " on sm.Location_id=m.Location_id where sm.Emp_Id=m.id and sm.Month='" + cmbmonth.Text + "' and (m.Location_id =" + clsEmployee.GetlocID(loc1) + ")  and (m.desgid=" + desig1 + ") ";
                            val_ot = Convert.ToInt32(clsDataAccess.GetresultS("SELECT  count(*) FROM tbl_order_FB_detail where (htext='OT' or htext='Overtime') and Fname in (" + arrayItem.ToString().Trim() + ")"));
                            bmod = Convert.ToInt32(dtdtl.Rows[y]["bmod"]);

                            dgemployjob.Rows[y].Cells["col_bmod"].Value = bmod;
                            if (val_ot == 0 && bmod != 1)
                            {
                                if (clsDataAccess.ReturnValue("Select ed_bill from CompanyLimiter") == "1")
                                {
                                    sqlstr = "select sum(days_wd+days_ot+days_ed) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                }
                                else
                                {
                                    sqlstr = "select sum(days_wd + days_ot) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                }
                            }
                            else
                            {
                                if (bmod == 1)
                                {
                                    sqlstr = "select (sum(days_wd)*1.5) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                }
                                else
                                {
                                    if ((clsDataAccess.ReturnValue("Select ot_bill from CompanyLimiter") == "1") && (clsDataAccess.ReturnValue("Select ed_bill from CompanyLimiter") == "1"))
                                    {
                                        sqlstr = "select sum(days_wd + days_ot + days_ed) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                    }
                                    else if ((clsDataAccess.ReturnValue("Select ot_bill from CompanyLimiter") == "1") && (clsDataAccess.ReturnValue("Select ed_bill from CompanyLimiter") == "0"))
                                    {
                                        sqlstr = "select sum(days_wd + days_ot) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                    }
                                    else if ((clsDataAccess.ReturnValue("Select ot_bill from CompanyLimiter") == "0") && (clsDataAccess.ReturnValue("Select ed_bill from CompanyLimiter") == "1"))
                                    {
                                        sqlstr = "select sum(days_wd+days_ed) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                    }
                                    else
                                    {
                                        sqlstr = "select sum(days_wd) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                    }
                                }
                            }
                            DataTable dtid = clsDataAccess.RunQDTbl(sqlstr);

                            if (dtid.Rows.Count > 0)
                            {
                                if ((dtid.Rows.Count > 0) && (Information.IsNumeric(dtid.Rows[0][0]) == true))
                                {
                                    //if ((dgemployjob.Rows[y].Cells["Attendance"].Value == "") || (dgemployjob.Rows[y].Cells["Attendance"].Value == "0"))
                                    //{
                                    dgemployjob.Rows[y].Cells["Attendance"].Value = Convert.ToString(dtid.Rows[0][0]);
                                    //}
                                }
                            }
                            else
                            {
                                //ERPMessageBox.ERPMessage.Show("Attendance not found in '" + desig1 + "' for the month of '" + cmbmonth.Text + "'");
                                //return;
                            }
                            //for calculating noofpersonnels
                            string strSQL = "select count(*) from tbl_Employee_Attend as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                            dgemployjob.Rows[y].Cells["Personnel"].Value = clsDataAccess.GetresultS(strSQL);

                            //for calculating Amount

                            if ((setting_type == "type 1") && (dgemployjob.Rows[y].Cells["Hour"].Value.ToString() == "12"))
                            {
                                dgemployjob.Rows[y].Cells["Amount"].Value = Convert.ToInt32(Math.Round(((Convert.ToDouble(_rate) / Convert.ToDouble(mod_days)) * Convert.ToDouble(dgemployjob.Rows[y].Cells["Attendance"].Value)), 2)).ToString("0.00");
                            }
                            else
                            {
                                dgemployjob.Rows[y].Cells["Amount"].Value = Convert.ToInt32(Math.Round(((Convert.ToDouble(_rate) / Convert.ToDouble(mod_days)) * Convert.ToDouble(dgemployjob.Rows[y].Cells["Attendance"].Value)), 2)).ToString("0.00");
                            }
                            //for calculating Amount

                            if (dtdtl.Rows[y]["nop"].ToString() != "0")
                            {
                                dgemployjob.Rows[y].Cells["Personnel"].Value = dtdtl.Rows[y]["nop"].ToString();
                            }
                        }

                        double bsc = 0, bs = 0;
                        int ind = 0;
                        for (int indx = 0; indx < dgemployjob.Rows.Count; indx++)
                        {
                            bsc = bsc + Convert.ToDouble(dgemployjob.Rows[indx].Cells["Amount"].Value);
                        }

                        DataTable dt_bs_head = clsDataAccess.RunQDTbl("SELECT C_DET,atten_day,Daily_wages FROM tbl_Employee_Assign_SalStructure WHERE (SAL_HEAD=(SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short='BS'))) AND (Location_id = '" + location_id + "') AND (Company_id = '" + Company_id + "') AND (P_TYPE = 'E')");
                        if (dt_bs_head.Rows.Count > 0)
                        {
                            DataTable dt_bs = clsDataAccess.RunQDTbl("SELECT LUMPNAME,GRADE,AMOUNT FROM tbl_Employee_Lumpsum WHERE (LUMPID ='" + dt_bs_head.Rows[0]["C_DET"].ToString() + "')");
                            while (ind < dt_bs.Rows.Count)
                            {
                                if (dt_bs_head.Rows[0]["Daily_wages"].ToString() == "1")
                                {
                                    bs = bs + Convert.ToInt32(Convert.ToDouble(dt_bs.Rows[ind]["AMOUNT"]) * Convert.ToDouble(lblMOD.Text));
                                }
                                else
                                {
                                    bs = bs + Convert.ToDouble(dt_bs.Rows[ind]["AMOUNT"]);
                                }
                                ind = ind + 1;
                            }
                        }
                        Label lb2 = new Label();
                        Label lb3 = new Label();
                        lb.Text = "BS";
                        lbe[0] = lb;
                        lb1.Text = bs.ToString();
                        lbH[0] = lb1;

                        lb2.Text = "BSC";
                        lbe[1] = lb2;
                        lb3.Text = bsc.ToString();
                        lbH[1] = lb3;

                        //htext
                        htSalHead.Clear();
                        string qrySalDet = "SELECT (case sd.TableName when 'tbl_Employee_ErnSalaryHead' then (select eh.SalaryHead_Short from tbl_Employee_ErnSalaryHead eh where eh.SlNo = sd.SalId) "+
		                                    "when 'tbl_Employee_DeductionSalayHead' then (select eh.SalaryHead_Short from tbl_Employee_DeductionSalayHead eh where eh.SlNo = sd.SalId) "+
		                                    "end) as 'SalID'"+
                                            ",sum([Amount]) as 'Amt' "+
                                            "FROM [tbl_Employee_SalaryDetails] sd " +
                                            "where Session = '" + cmbYear.Text + "' and Location_id = '" + location_id + "' and Company_id = '" + Company_id + "' and Month = '" + dateTimePicker1.Text.Substring(0, dateTimePicker1.Text.IndexOf('-') - 1) + "'  and (TableName = 'tbl_Employee_ErnSalaryHead' or TableName = 'tbl_Employee_DeductionSalayHead')" +
                                            "group by SalId,TableName";
                        DataTable dtSalDet = clsDataAccess.RunQDTbl(qrySalDet);
                        if (dtSalDet.Rows.Count > 0)
                        {
                            bTagging = true;
                            for (int i = 0; i < dtSalDet.Rows.Count; i++)
                            {
                                htSalHead.Add(dtSalDet.Rows[i]["SalID"].ToString(), dtSalDet.Rows[i]["Amt"].ToString());                                
                            }
                        }
                        else
                        {
                            bTagging = false;
                        }
                        DataTable dtdtl1 = clsDataAccess.RunQDTbl("select Fid,Fname,position,basis,Fexpr,fper,vnote,htext,tagging FROM tbl_order_FB_detail where Fname in (" + arrayItem.ToString().Trim() + ") order by position");
                        ind = 0;
                        for (int y = 0; y <= dtdtl1.Rows.Count - 1; y++)
                        {
                            if (dtdtl1.Rows[y]["htext"].ToString().ToLower() != "note")
                            {
                                ind = dgotherjob.Rows.Add();
                                Label la = new Label();
                                Label la1 = new Label();


                                if (dtdtl1.Rows[y]["basis"].ToString().ToLower() == "formula")
                                {
                                    /*dgotherjob.Rows[ind].Cells["OCDesc"].Value = dtdtl1.Rows[y]["vnote"].ToString();
                                    dgotherjob.Rows[ind].Cells["OCAmt"].Value = formula(dtdtl1.Rows[y]["Fexpr"].ToString());*/

                                    if (clsDataAccess.ReturnValue("select bill_rcalc from CompanyLimiter").ToString().Trim() == "1")
                                    {
                                        groupBox2.Text = "Basic Charges (Press F10 for Recalculation)";
                                        lblF10.Visible = true;
                                    }
                                    else
                                    {
                                        groupBox2.Text = "Basic Charges";
                                        lblF10.Visible = false;
                                    }


                                    if (dtdtl1.Rows[y]["tagging"].ToString() == "1")
                                    {
                                        dgotherjob.Rows[ind].Cells["OCDesc"].Value = dtdtl1.Rows[y]["vnote"].ToString();
                                        dgotherjob.Rows[ind].Cells["OCAmt"].Value = formula(dtdtl1.Rows[y]["Fexpr"].ToString());
                                    }
                                    else if (dtdtl1.Rows[y]["tagging"].ToString() == "2")
                                    {
                                        if (!bTagging &&!boolSalAllotmentNotFound)
                                        {
                                            boolSalAllotmentNotFound = true;
                                        }
                                        if(bTagging)
                                        {
                                            dgotherjob.Rows[ind].Cells["OCDesc"].Value = dtdtl1.Rows[y]["vnote"].ToString();
                                            dgotherjob.Rows[ind].Cells["OCAmt"].Value = formula_sal(dtdtl1.Rows[y]["Fexpr"].ToString());
                                        }
                                    }
                                }
                                else
                                {
                                    if (dtdtl1.Rows[y]["htext"].ToString().ToLower() == "ot")
                                    {
                                        val_ot = Convert.ToInt32(clsDataAccess.GetresultS("SELECT  count(*) FROM tbl_order_FB_detail where (htext='OT' or htext='Overtime') and Fname in (" + arrayItem.ToString().Trim() + ")"));
                                        if (val_ot > 0)
                                        {
                                            string desig1 = "",ODesg="", Ot_Det = dtdtl1.Rows[y]["vnote"].ToString(), val_amt = "";
                                            double Ot_val = 0;

                                            for (int y1 = 0; y1 <= dtdtl.Rows.Count - 1; y1++)
                                            {
                                                desig1 = dtdtl.Rows[y1]["desig_ID"].ToString();
                                                ODesg = dtdtl.Rows[y1]["ODesg"].ToString();
                                                prx = clsDataAccess.GetresultS("select isNull(sum(proxy),0) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')");
                                                val_amt = dgemployjob.Rows[y1].Cells["Rate"].Value.ToString();
                                                Ot_val = Ot_val + Convert.ToInt32(Convert.ToDouble(val_amt) * Convert.ToDouble(prx.ToString()) / Convert.ToDouble(lblMOD.Text.ToString()));

                                                if (Ot_Det == "")
                                                {

                                                    if (Convert.ToDouble(prx.ToString()) > 0)
                                                    {
                                                        Ot_Det = Convert.ToString(dtdtl.Rows[y]["designation"]) + " : [" + Convert.ToString((val_amt.ToString()) + " x " + (prx.ToString()) + "/" + (lblMOD.Text.ToString())) + "]";
                                                    }

                                                }
                                                else
                                                {
                                                    if (Convert.ToDouble(prx.ToString()) > 0)
                                                    {
                                                        Ot_Det = Ot_Det + Environment.NewLine + Convert.ToString(dtdtl.Rows[y1]["designation"]) + " : [" + Convert.ToString((val_amt.ToString()) + " x " + (prx.ToString()) + "/" + (lblMOD.Text.ToString())) + "]";
                                                    }
                                                }
                                            }

                                            dgotherjob.Rows[ind].Cells["OCDesc"].Value = Ot_Det;
                                            dgotherjob.Rows[ind].Cells["OCAmt"].Value = Ot_val.ToString();
                                        }
                                    }
                                    else
                                    {
                                        if (dtdtl1.Rows[y]["vnote"].ToString().Trim() == "")
                                        {
                                            dgotherjob.Rows[ind].Cells["OCDesc"].Value = dtdtl1.Rows[y]["htext"].ToString();
                                        }
                                        else
                                        {
                                            dgotherjob.Rows[ind].Cells["OCDesc"].Value = dtdtl1.Rows[y]["vnote"].ToString();
                                        }
                                        dgotherjob.Rows[ind].Cells["OCAmt"].Value = dtdtl1.Rows[y]["fper"].ToString();
                                    }
                                }

                                la.Text = dtdtl1.Rows[y]["htext"].ToString();
                                la1.Text = dgotherjob.Rows[ind].Cells["OCAmt"].Value.ToString();
                                lbe[y + 2] = la;
                                lbH[y + 2] = la1;
                            }
                            else
                            {
                                lblNote.Text = dtdtl1.Rows[y]["vnote"].ToString();
                            }
                        }
                        if (boolSalAllotmentNotFound)
                        {
                            EDPMessageBox.EDPMessage.Show("Salary has not been alloted yet.");
                        }

                    }
                    boolSalAllotmentNotFound = false;

                }
                catch 
                {
                    boolSalAllotmentNotFound = false;
                }
            }
            else if (cmbBillType.SelectedIndex == 1)
            {
                try
                {
                    string arrayItem = "";
                    string mod_val;
                    int mod_days = 0;
                    int bmod = 0;
                    val_ot = 0;
                    string firstDate = "", lastDate = "";

                    firstDate = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-01";
                    lastDate = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + DateTime.DaysInMonth(dateTimePicker1.Value.Year,dateTimePicker1.Value.Month);

                    String sqlLocGet = "select odd.Order_Name,pb.Location,odd.Order_Date from (select [Location],rtrim(ltrim([Order_Name])) as 'Order_Name',Co_Code,Cliant_ID from [tbl_Employee_OrderDetails]) pb inner join tbl_Employee_OrderDetails_Dtl odd on odd.Order_Name = pb.Order_Name where desig_ID = " + DesgID + " and Cliant_ID = " + Client_id + " and Co_Code = " + Company_id + " and Order_Date between '" + firstDate + "' and '" + lastDate + "'";
                    DataTable dtsqlLocGet = clsDataAccess.RunQDTbl(sqlLocGet);
                    if (dtsqlLocGet.Rows.Count > 0)
                    {
                        EDPCommon.MLOV_EDP(sqlLocGet, "Tag Item", "Select Item Name", "List of Item Name", 0, "CMPN", 0);
                        arritem.Clear();
                        arritem = EDPCommon.arr_mod;
                        for (int i = 0; i < arritem.Count; i++)
                        {
                            if (arrayItem.Trim() == "")
                            {
                                arrayItem = "'" + arritem[i].ToString().Trim() + "'";
                            }
                            else
                            {
                                arrayItem = arrayItem + ",'" + arritem[i].ToString().Trim() + "'";
                            }

                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtsqlLocGet.Rows.Count; i++)
                        {
                            arrayItem = "'" + dtsqlLocGet.Rows[i]["Order_Name"].ToString() + "'";

                        }
                    }



                    dgemployjob.Rows.Clear();
                    if (arritem.Count > 0 || arrayItem.Trim() != "")
                    {

                        DataTable dtdtl = clsDataAccess.RunQDTbl("select d.Dtl_id,d.Order_Name,d.Order_Date,(select DesignationName from tbl_Employee_DesignationMaster where SlNo=d.desig_ID )as 'designation',(select h.Location  from tbl_Employee_OrderDetails h where h.Order_Name=d.Order_Name  ) as 'locname',d.Hour,d.MonthDays,d.RATE,d.desig_ID,d.rmrks,d.bmod,(select serviceName+':'+sacNo as 'SACNo' from CompanySACMaster where slno = d.SAC) as 'SAC',ODesg from tbl_Employee_OrderDetails_Dtl d where d.Order_Name  in (" + arrayItem.ToString().Trim() + ") and d.[desig_ID] = '"+DesgID+"'");

                        for (int y = 0; y <= dtdtl.Rows.Count - 1; y++)
                        {
                            dgemployjob.Rows.Add();
                            dgemployjob.Rows[y].Cells["id"].Value = Convert.ToString(dtdtl.Rows[y]["Dtl_id"]);
                            dgemployjob.Rows[y].Cells["locationname"].Value = Convert.ToString(dtdtl.Rows[y]["locname"]);
                            dgemployjob.Rows[y].Cells["Designation"].Value = Convert.ToString(dtdtl.Rows[y]["designation"]);

                            if (!String.IsNullOrEmpty(Convert.ToString(dtdtl.Rows[y]["SAC"])))
                            {
                                dgemployjob.Rows[y].Cells["sacno"].Value = Convert.ToString(dtdtl.Rows[y]["SAC"]);
                            }

                            dgemployjob.Rows[y].Cells["Hour"].Value = Convert.ToString(dtdtl.Rows[y]["Hour"]);
                            mod_val = Convert.ToString(dtdtl.Rows[y]["MonthDays"]);
                            string sqlstr = "";
                            if (mod_val == "MonthOfDays")
                            {
                                mod_days = System.DateTime.DaysInMonth(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value.Month);
                            }
                            else if (mod_val == "MOD-SUNDAY")
                            {
                                mod_days = NoOfWorkingDays(dateTimePicker1.Value);
                            }
                            else if (mod_val.Length>=5&&mod_val.Substring(0, 5) == "RANGE")
                            {
                                string modVal = mod_val;
                                int fromDate = Convert.ToInt32(modVal.Substring(5, (modVal.IndexOf("-") - 5)));
                                int toDate = Convert.ToInt32(modVal.Substring(modVal.IndexOf("-") + 1));
                                mod_days = NoOfWorkingDays(dateTimePicker1.Value, fromDate, toDate);
                            }
                            else if (mod_val == "26")
                            {
                                mod_days = 26;
                            }
                            else if (mod_val == "PerDay" || mod_val == "PerHour")
                            {
                                mod_days = 1;
                            }
                            dgemployjob.Rows[y].Cells["MontOfDays"].Value = Convert.ToString(dtdtl.Rows[y]["MonthDays"]);
                            dgemployjob.Rows[y].Cells["OrderNo"].Value = Convert.ToString(dtdtl.Rows[y]["Order_Name"]);
                            dgemployjob.Rows[y].Cells["orderdate"].Value = Convert.ToDateTime(dtdtl.Rows[y]["Order_Date"]).ToShortDateString();


                            double _rate = 0.00;
                            _rate = Convert.ToDouble(dtdtl.Rows[y]["Rate"]);
                            dgemployjob.Rows[y].Cells["Rate"].Value = _rate;
                            if (Convert.ToString(dtdtl.Rows[y]["rmrks"]).Trim() != "")
                            {
                                dgemployjob.Rows[y].Cells["colRmrks"].Value = Convert.ToString(dtdtl.Rows[y]["rmrks"]).Trim();
                            }
                            else
                            {
                                dgemployjob.Rows[y].Cells["colRmrks"].Value = "";
                            }
                            //for calculating attandance
                            string loc1 = "";
                            string desig1 = "",ODesg="";

                            prx = "";
                            loc1 = dgemployjob.Rows[y].Cells["locationname"].Value.ToString();
                            desig1 = dtdtl.Rows[y]["desig_ID"].ToString();
                            ODesg = dtdtl.Rows[y]["ODesg"].ToString();
                            //sqlstr = "select  sum(sm.TotalDays) as 'Attandance',(select  e.DesignationName from tbl_Employee_DesignationMaster e where e.SlNo =m.DesgId ) as [DesignationName]  from tbl_Employee_SalaryMast sm inner join tbl_Employee_Mast m ";
                            //sqlstr = sqlstr + " on sm.Location_id=m.Location_id where sm.Emp_Id=m.id and sm.Month='" + cmbmonth.Text + "' and m.DesgId=" + clsEmployee.GetDesgId(desig1) + "  and m.Location_id =" + clsEmployee.GetlocID(loc1) + " group by m.DesgId ";

                            //sqlstr = "select  sum(sm.DaysPresent + sm.OT) as 'Attandance',(select  e.DesignationName from tbl_Employee_DesignationMaster e where e.SlNo =" + desig1 + " ) as [DesignationName]  from tbl_Employee_SalaryMast sm inner join tbl_Employee_Attend m ";
                            //sqlstr = sqlstr + " on sm.Location_id=m.Location_id where sm.Emp_Id=m.id and sm.Month='" + cmbmonth.Text + "' and (m.Location_id =" + clsEmployee.GetlocID(loc1) + ")  and (m.desgid=" + desig1 + ") ";
                            val_ot = Convert.ToInt32(clsDataAccess.GetresultS("SELECT  count(*) FROM tbl_order_FB_detail where (htext='OT' or htext='Overtime') and Fname in (" + arrayItem.ToString().Trim() + ")"));
                            bmod = Convert.ToInt32(dtdtl.Rows[y]["bmod"]);

                            dgemployjob.Rows[y].Cells["col_bmod"].Value = bmod;
                            if (val_ot == 0 && bmod != 1)
                            {
                                sqlstr = "select sum(wday + proxy) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                            }
                            else
                            {
                                if (bmod == 1)
                                {
                                    sqlstr = "select (sum(wday)*1.5) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                }
                                else
                                {
                                    sqlstr = "select sum(wday) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                }
                            }
                            DataTable dtid = clsDataAccess.RunQDTbl(sqlstr);

                            if (dtid.Rows.Count > 0)
                            {
                                if ((dtid.Rows.Count > 0) && (Information.IsNumeric(dtid.Rows[0][0]) == true))
                                {
                                    //if ((dgemployjob.Rows[y].Cells["Attendance"].Value == "") || (dgemployjob.Rows[y].Cells["Attendance"].Value == "0"))
                                    //{
                                    dgemployjob.Rows[y].Cells["Attendance"].Value = Convert.ToString(dtid.Rows[0][0]);
                                    //}
                                }
                            }
                            else
                            {
                                //ERPMessageBox.ERPMessage.Show("Attendance not found in '" + desig1 + "' for the month of '" + cmbmonth.Text + "'");
                                //return;
                            }
                            //for calculating no of personnel
                            string strSQL = "select count(*) from tbl_Employee_Attend as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                            dgemployjob.Rows[y].Cells["Personnel"].Value = clsDataAccess.GetresultS(strSQL);
                            //for calculating Amount

                            if ((setting_type == "type 1") && (dgemployjob.Rows[y].Cells["Hour"].Value.ToString() == "12"))
                            {
                                dgemployjob.Rows[y].Cells["Amount"].Value = Convert.ToInt32(Math.Round(((Convert.ToDouble(_rate) / Convert.ToDouble(mod_days)) * Convert.ToDouble(dgemployjob.Rows[y].Cells["Attendance"].Value)), 2)).ToString("0.00");
                            }
                            else
                            {
                                dgemployjob.Rows[y].Cells["Amount"].Value = Convert.ToInt32(Math.Round(((Convert.ToDouble(_rate) / Convert.ToDouble(mod_days)) * Convert.ToDouble(dgemployjob.Rows[y].Cells["Attendance"].Value)), 2)).ToString("0.00");
                            }
                            //for calculating Amount
                        }

                        double bsc = 0, bs = 0;
                        int ind = 0;
                        for (int indx = 0; indx < dgemployjob.Rows.Count; indx++)
                        {
                            bsc = bsc + Convert.ToDouble(dgemployjob.Rows[indx].Cells["Amount"].Value);
                        }

                        DataTable dt_bs_head = clsDataAccess.RunQDTbl("SELECT C_DET,atten_day,Daily_wages FROM tbl_Employee_Assign_SalStructure WHERE (SAL_HEAD=(SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short='BS'))) AND (Location_id = '" + location_id + "') AND (Company_id = '" + Company_id + "') AND (P_TYPE = 'E')");
                        if (dt_bs_head.Rows.Count > 0)
                        {
                            DataTable dt_bs = clsDataAccess.RunQDTbl("SELECT LUMPNAME,GRADE,AMOUNT FROM tbl_Employee_Lumpsum WHERE (LUMPID ='" + dt_bs_head.Rows[0]["C_DET"].ToString() + "')");
                            while (ind < dt_bs.Rows.Count)
                            {
                                if (dt_bs_head.Rows[0]["Daily_wages"].ToString() == "1")
                                {
                                    bs = bs + Convert.ToInt32(Convert.ToDouble(dt_bs.Rows[ind]["AMOUNT"]) * Convert.ToDouble(lblMOD.Text));
                                }
                                else
                                {
                                    bs = bs + Convert.ToDouble(dt_bs.Rows[ind]["AMOUNT"]);
                                }
                                ind = ind + 1;
                            }
                        }
                        Label lb2 = new Label();
                        Label lb3 = new Label();
                        lb.Text = "BS";
                        lbe[0] = lb;
                        lb1.Text = bs.ToString();
                        lbH[0] = lb1;

                        lb2.Text = "BSC";
                        lbe[1] = lb2;
                        lb3.Text = bsc.ToString();
                        lbH[1] = lb3;
                    }

                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
              Label lb = new Label();
              Label lb1 = new Label();

              double val_ot = 0;
              string prx = "";
              if (cmbBillType.SelectedIndex == 0 || cmbBillType.SelectedIndex == 2)
              {
                  try
                  {

                      string sqlstmnt = "Select Order_Name,Order_Date,Location,Order_ID from tbl_Employee_OrderDetails  where (Co_Code='" + Company_id + "') and (Cliant_ID='" + Client_id + "') and (ltrim(rtrim(location))='" + cmbLocation.Text.Trim() + "')";

                      //DataTable dt2 = clsDataAccess.RunQDTbl(sqlstmnt);
                      //EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Item Name", "List of Item Name", 0, "CMPN",0);

                      EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Item Name", "List of Item Name", 0, "CMPN", 0);

                      arritem.Clear();
                      arritem = EDPCommon.arr_mod;
                      string arrayItem = "";
                      string mod_val,ODesg="";
                      int mod_days = 0, bmod = 0;
                      for (int i = 0; i < arritem.Count; i++)
                      {
                          if (arrayItem.Trim() == "")
                          {
                              arrayItem = "'" + arritem[i].ToString() + "'";
                          }
                          else
                          {
                              arrayItem = arrayItem + "," + "'" + arritem[i].ToString() + "'";
                          }
                      }

                      dgemployjob.Rows.Clear();
                      lblEnclosure.Text = "";
                      if (arritem.Count > 0)
                      {

                          DataTable dtdtl = clsDataAccess.RunQDTbl("select d.Dtl_id,d.Order_Name,d.Order_Date,"+
                         "(select DesignationName from tbl_Employee_DesignationMaster where SlNo=d.desig_ID )as 'designation',"+
                         "(select h.Location  from tbl_Employee_OrderDetails h where h.Order_Name=d.Order_Name  ) as 'locname',"+
                         "d.Hour,d.MonthDays,d.RATE,d.desig_ID,d.rmrks,d.bmod,(select serviceName+':'+sacNo as 'SACNo' from CompanySACMaster where slno = d.SAC) as 'SAC',(select GstPer from CompanySACMaster where (slno=d.SAC)) GstPer," +
                         "(select h.Enclosure  from tbl_Employee_OrderDetails h where h.Order_Name=d.Order_Name  ) as 'Enclosure',d.nop,ODesg from tbl_Employee_OrderDetails_Dtl d where d.Order_Name in (" + arrayItem.ToString().Trim() + ")");

                          for (int y = 0; y <= dtdtl.Rows.Count - 1; y++)
                          {
                              dgemployjob.Rows.Add();
                              dgemployjob.Rows[y].Cells["id"].Value = Convert.ToString(dtdtl.Rows[y]["Dtl_id"]);
                              dgemployjob.Rows[y].Cells["locationname"].Value = Convert.ToString(dtdtl.Rows[y]["locname"]);
                              dgemployjob.Rows[y].Cells["Designation"].Value = Convert.ToString(dtdtl.Rows[y]["designation"]);
                              try
                              {
                                  string encid = Convert.ToString(dtdtl.Rows[y]["enclosure"]).Replace('|',',');
                                  if (encid.Trim() == "") { lblEnclosure.Text = ""; }
                                  else
                                  {


                                      DataTable enc = clsDataAccess.RunQDTbl("select enclosure from tbl_enclosure where eid in (" + encid + ")");
                                      for (int indx = 0; indx < enc.Rows.Count; indx++)
                                      {
                                          if (lblEnclosure.Text.Trim() == "")
                                          {
                                              lblEnclosure.Text = (indx + 1) + "-" + enc.Rows[indx]["enclosure"].ToString().Trim();

                                          }
                                          else
                                          {
                                              lblEnclosure.Text = lblEnclosure.Text + Environment.NewLine + (indx + 1) + "-" + enc.Rows[indx]["enclosure"].ToString().Trim();
                                          }
                                      }
                                  }
                              }
                              catch { }
                              //changes made by dwipraj dutta 18082017
                              if (!String.IsNullOrEmpty(Convert.ToString(dtdtl.Rows[y]["SAC"])))
                              {
                                  dgemployjob.Rows[y].Cells["sacno"].Value = Convert.ToString(dtdtl.Rows[y]["SAC"]);


                                  dgemployjob.Rows[y].Cells["gst_per"].Value = dtdtl.Rows[y]["GstPer"].ToString().Trim();
                              }

                              dgemployjob.Rows[y].Cells["Hour"].Value = Convert.ToString(dtdtl.Rows[y]["Hour"]);
                              dgemployjob.Rows[y].Cells["colRmrks"].Value = Convert.ToString(dtdtl.Rows[y]["rmrks"]);
                              mod_val = Convert.ToString(dtdtl.Rows[y]["MonthDays"]);
                              string sqlstr = "";
                              if (mod_val == "MonthOfDays")
                              {
                                  mod_days = System.DateTime.DaysInMonth(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value.Month);
                              }
                              else if (mod_val == "MOD-SUNDAY")
                              {
                                  mod_days = NoOfWorkingDays(dateTimePicker1.Value);
                              }
                              else if (mod_val.Length>=5 && mod_val.Substring(0, 5) == "RANGE")
                              {
                                  string modVal = mod_val;
                                  int fromDate = Convert.ToInt32(modVal.Substring(5, (modVal.IndexOf("-") - 5)));
                                  int toDate = Convert.ToInt32(modVal.Substring(modVal.IndexOf("-") + 1));
                                  mod_days = NoOfWorkingDays(dateTimePicker1.Value, fromDate, toDate);
                              }
                              else if (mod_val == "26")
                              {
                                  mod_days = 26;
                              }
                              else if (mod_val == "PerDay" || mod_val == "PerHour")
                              {
                                  mod_days = 1;
                              }
                              dgemployjob.Rows[y].Cells["MontOfDays"].Value = Convert.ToString(dtdtl.Rows[y]["MonthDays"]);
                              dgemployjob.Rows[y].Cells["OrderNo"].Value = Convert.ToString(dtdtl.Rows[y]["Order_Name"]);
                              dgemployjob.Rows[y].Cells["orderdate"].Value = Convert.ToDateTime(dtdtl.Rows[y]["Order_Date"]).ToShortDateString();

                             
                              double _rate = 0.00;
                              _rate = Convert.ToDouble(dtdtl.Rows[y]["Rate"]);
                              dgemployjob.Rows[y].Cells["Rate"].Value = _rate;

                              //for calculating attandance
                              string loc1 = "";
                              string desig1 = "";
                              loc1 = dgemployjob.Rows[y].Cells["locationname"].Value.ToString();
                              desig1 = dtdtl.Rows[y]["desig_ID"].ToString();

                              //sqlstr = "select  sum(sm.TotalDays) as 'Attandance',(select  e.DesignationName from tbl_Employee_DesignationMaster e where e.SlNo =m.DesgId ) as [DesignationName]  from tbl_Employee_SalaryMast sm inner join tbl_Employee_Mast m ";
                              //sqlstr = sqlstr + " on sm.Location_id=m.Location_id where sm.Emp_Id=m.id and sm.Month='" + cmbmonth.Text + "' and m.DesgId=" + clsEmployee.GetDesgId(desig1) + "  and m.Location_id =" + clsEmployee.GetlocID(loc1) + " group by m.DesgId ";
                              //sqlstr = "select  sum('" + mod_days + "' + sm.OT) as 'Attandance',(select  e.DesignationName from tbl_Employee_DesignationMaster e where e.SlNo =" + desig1 + " ) as [DesignationName]  from tbl_Employee_SalaryMast sm inner join tbl_Employee_Attend m ";
                              //sqlstr = sqlstr + " on sm.Location_id=m.Location_id where sm.Emp_Id=m.id and sm.Month='" + cmbmonth.Text + "' and (m.Location_id =" + clsEmployee.GetlocID(loc1) + ") ";


                              val_ot = Convert.ToInt32(clsDataAccess.GetresultS("SELECT  count(*) FROM tbl_order_FB_detail where (htext='OT' or htext='Overtime') and Fname in (" + arrayItem.ToString().Trim() + ")"));

                              bmod = Convert.ToInt32(dtdtl.Rows[y]["bmod"]);
                              ODesg = dtdtl.Rows[y]["ODesg"].ToString();

                              dgemployjob.Rows[y].Cells["col_bmod"].Value = bmod;

                              if (ODesg.Trim() == "")
                              {
                                  ODesg = desig1;
                              }
                              if (val_ot == 0 && bmod != 1)
                              {
                                  if (clsDataAccess.ReturnValue("Select ed_bill from CompanyLimiter") == "1")
                                  {
                                      sqlstr = "select sum(days_wd+days_ot+days_ed) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                  }
                                  else
                                  {
                                      sqlstr = "select sum(days_wd + days_ot) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                  }
                              }
                              else
                              {
                                  if (bmod == 1)
                                  {
                                      sqlstr = "select (sum(days_wd)*1.5) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                  }
                                  else
                                  {
                                      if ((clsDataAccess.ReturnValue("Select ot_bill from CompanyLimiter") == "1") && (clsDataAccess.ReturnValue("Select ed_bill from CompanyLimiter") == "1"))
                                      {
                                          sqlstr = "select sum(days_wd + days_ot + days_ed) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                      }
                                      else if ((clsDataAccess.ReturnValue("Select ot_bill from CompanyLimiter") == "1") && (clsDataAccess.ReturnValue("Select ed_bill from CompanyLimiter") == "0"))
                                      {
                                          sqlstr = "select sum(days_wd + days_ot) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                      }
                                      else if ((clsDataAccess.ReturnValue("Select ot_bill from CompanyLimiter") == "0") && (clsDataAccess.ReturnValue("Select ed_bill from CompanyLimiter") == "1"))
                                      {
                                          sqlstr = "select sum(days_wd+days_ed) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                      }
                                      else
                                      {
                                          sqlstr = "select sum(days_wd) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid in (" + ODesg + ")) and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                      }
                                  }
                              }


                              //if (val_ot == 0)
                              //{
                              //    sqlstr = "select sum(wday + proxy) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid='" + desig1 + "') and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                              //}
                              //else
                              //{
                              //    sqlstr = "select sum(wday) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid='" + desig1 + "') and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";

                              //}

                              //sqlstr = "select sum('" + mod_days + "' + Proxy) as 'Attandance',(select  e.DesignationName from tbl_Employee_DesignationMaster e where e.SlNo =" + desig1 + " ) as [DesignationName] from tbl_Employee_Attend where (MONTH='"+ dateTimePicker1.Value.ToString("M/yyyy") +"') and (Season='"+ cmbYear.Text +"') and (LOcation_ID='" + clsEmployee.GetlocID(loc1) + "') and (Desgid='" + desig1 + "')";
                              DataTable dtid = clsDataAccess.RunQDTbl(sqlstr);

                              if (dtid.Rows.Count > 0)
                              {
                                  if ((dtid.Rows.Count > 0) && (Information.IsNumeric(dtid.Rows[0][0]) == true))
                                  {
                                      //if ((dgemployjob.Rows[y].Cells["Attendance"].Value == "") || (dgemployjob.Rows[y].Cells["Attendance"].Value == "0"))
                                      //{
                                      dgemployjob.Rows[y].Cells["Attendance"].Value = Convert.ToString(dtid.Rows[0][0]);
                                      //}
                                  }
                              }
                              else
                              {
                                  //ERPMessageBox.ERPMessage.Show("Attendance not found in '" + desig1 + "' for the month of '" + cmbmonth.Text + "'");
                                  //return;
                              }
                              //for calculating attandance
                              if (dtdtl.Rows[y]["nop"].ToString()!="0")
                              {
                              dgemployjob.Rows[y].Cells["Personnel"].Value = dtdtl.Rows[y]["nop"].ToString();
                              }
                              else{
                              string strSQL = "select count(*) from tbl_Employee_Attend as ea where (LOcation_ID='" + location_id + "') and (Desgid='" + desig1 + "') and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                              dgemployjob.Rows[y].Cells["Personnel"].Value = clsDataAccess.GetresultS(strSQL);
                              }
                              //for calculating Amount
                              if (mod_val == "PerHour")
                              {
                                  dgemployjob.Rows[y].Cells["Amount"].Value = Convert.ToInt32(Math.Round(((Convert.ToDouble(_rate) / Convert.ToDouble(mod_days)) * (Convert.ToDouble(dgemployjob.Rows[y].Cells["Attendance"].Value) * Convert.ToDouble(dgemployjob.Rows[y].Cells["Hour"].Value))), 2)).ToString("0.00");
                              }
                              else
                              {
                                  dgemployjob.Rows[y].Cells["Amount"].Value = Convert.ToInt32(Math.Round(((Convert.ToDouble(_rate) / Convert.ToDouble(mod_days)) * Convert.ToDouble(dgemployjob.Rows[y].Cells["Attendance"].Value)), 2)).ToString("0.00");
                              }
                              //for calculating Amount


                              if (SacGst == 1)
                              {
                                  dgemployjob.Rows[y].Cells["gst_amt"].Value = Convert.ToDouble(Convert.ToDouble(dgemployjob.Rows[y].Cells["Amount"].Value) * (Convert.ToDouble(dgemployjob.Rows[y].Cells["Gst_Per"].Value) / 100)).ToString("0.00");

                              }
                              else
                              {
                                  dgemployjob.Rows[y].Cells["gst_amt"].Value = 0;
                              }
                          }

                          double bsc = 0, bs = 0;
                          int ind = 0;
                          for (int indx = 0; indx < dgemployjob.Rows.Count; indx++)
                          {
                              bsc = bsc + Convert.ToDouble(dgemployjob.Rows[indx].Cells["Amount"].Value);
                          }

                          DataTable dt_bs_head = clsDataAccess.RunQDTbl("SELECT C_DET,atten_day,Daily_wages FROM tbl_Employee_Assign_SalStructure WHERE (SAL_HEAD=(SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short='BS'))) AND (Location_id = '" + location_id + "') AND (Company_id = '" + Company_id + "') AND (P_TYPE = 'E')");
                          if (dt_bs_head.Rows.Count > 0)
                          {
                              DataTable dt_bs = clsDataAccess.RunQDTbl("SELECT LUMPNAME,GRADE,AMOUNT FROM tbl_Employee_Lumpsum WHERE (LUMPID ='" + dt_bs_head.Rows[0]["C_DET"].ToString() + "')");
                              while (ind < dt_bs.Rows.Count)
                              {
                                  if (dt_bs_head.Rows[0]["Daily_wages"].ToString() == "1")
                                  {
                                      bs = bs + Convert.ToInt32(Convert.ToDouble(dt_bs.Rows[ind]["AMOUNT"]) * Convert.ToDouble(lblMOD.Text));
                                  }
                                  else
                                  {
                                      bs = bs + Convert.ToDouble(dt_bs.Rows[ind]["AMOUNT"]);
                                  }
                                  ind = ind + 1;
                              }
                          }
                          Label lb2 = new Label();
                          Label lb3 = new Label();
                          lb.Text = "BS";
                          lbe[0] = lb;
                          lb1.Text = bs.ToString();
                          lbH[0] = lb1;

                          lb2.Text = "BSC";
                          lbe[1] = lb2;
                          lb3.Text = bsc.ToString();
                          lbH[1] = lb3;



                          //htext,
                          htSalHead.Clear();
                          string qrySalDet = "SELECT (case sd.TableName when 'tbl_Employee_ErnSalaryHead' then (select eh.SalaryHead_Short from tbl_Employee_ErnSalaryHead eh where eh.SlNo = sd.SalId) " +
                                            "when 'tbl_Employee_DeductionSalayHead' then (select eh.SalaryHead_Short from tbl_Employee_DeductionSalayHead eh where eh.SlNo = sd.SalId) " +
                                            "end) as 'SalID'" +
                                            ",sum([Amount]) as 'Amt' " +
                                            "FROM [tbl_Employee_SalaryDetails] sd " +
                                            "where Session = '" + cmbYear.Text + "' and Location_id = '" + location_id + "' and Company_id = '" + Company_id + "' and Month = '" + dateTimePicker1.Text.Substring(0, dateTimePicker1.Text.IndexOf('-') - 1) + "'  and (TableName = 'tbl_Employee_ErnSalaryHead' or TableName = 'tbl_Employee_DeductionSalayHead') " +
                                            "group by SalId,TableName";
                          DataTable dtSalDet = clsDataAccess.RunQDTbl(qrySalDet);
                          if (dtSalDet.Rows.Count > 0)
                          {
                              bTagging = true;
                              for (int i = 0; i < dtSalDet.Rows.Count; i++)
                              {
                                  htSalHead.Add(dtSalDet.Rows[i]["SalID"].ToString(), dtSalDet.Rows[i]["Amt"].ToString());
                              }
                          }
                          else
                          {
                              bTagging = false;
                          }

                          DataTable dtdtl1 = clsDataAccess.RunQDTbl("select Fid,Fname,position,basis,Fexpr,fper,(case when ltrim(rtrim(vnote))='' then htext else vnote end) vnote,htext,(select serviceName+':'+sacNo as 'SACNo' from CompanySACMaster where slno = d.SAC) as 'SAC',(select GstPer from CompanySACMaster where (slno=d.SAC)) GstPer,tagging FROM tbl_order_FB_detail d where Fname in (" + arrayItem.ToString().Trim() + ") order by position");
                          ind = 0;
                          for (int y = 0; y <= dtdtl1.Rows.Count - 1; y++)
                          {
                              if (dtdtl1.Rows[y]["htext"].ToString().ToLower() != "note")
                              {
                                  ind = dgotherjob.Rows.Add();
                                  Label la = new Label();
                                  Label la1 = new Label();


                                  if (dtdtl1.Rows[y]["basis"].ToString().ToLower() == "formula")
                                  {
                                      if (dtdtl1.Rows[y]["tagging"].ToString() == "1")
                                      {
                                          dgotherjob.Rows[ind].Cells["OCDesc"].Value = dtdtl1.Rows[y]["vnote"].ToString();
                                          dgotherjob.Rows[ind].Cells["OCAmt"].Value = formula(dtdtl1.Rows[y]["Fexpr"].ToString());
                                      }
                                      else if (dtdtl1.Rows[y]["tagging"].ToString() == "2")
                                      {
                                          if (!bTagging && !boolSalAllotmentNotFound)
                                          {
                                              boolSalAllotmentNotFound = true;
                                          }
                                          if (bTagging)
                                          {
                                              dgotherjob.Rows[ind].Cells["OCDesc"].Value = dtdtl1.Rows[y]["vnote"].ToString();
                                              dgotherjob.Rows[ind].Cells["OCAmt"].Value = formula_sal(dtdtl1.Rows[y]["Fexpr"].ToString());
                                          }
                                      }
                                  }
                                  else
                                  {
                                      if (dtdtl1.Rows[y]["htext"].ToString().ToLower() == "ot")
                                      {
                                          val_ot = Convert.ToInt32(clsDataAccess.GetresultS("SELECT  count(*) FROM tbl_order_FB_detail where (htext='OT' or htext='Overtime') and Fname in (" + arrayItem.ToString().Trim() + ")"));
                                          if (val_ot > 0)
                                          {
                                              string desig1 = "", Ot_Det = dtdtl1.Rows[y]["vnote"].ToString(), val_amt = "";
                                              double Ot_val = 0;

                                              for (int y1 = 0; y1 <= dtdtl.Rows.Count - 1; y1++)
                                              {
                                                  desig1 = dtdtl.Rows[y1]["desig_ID"].ToString();
                                                  prx = clsDataAccess.GetresultS("select isNull(sum(proxy),0) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid='" + desig1 + "') and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')");
                                                  val_amt = dgemployjob.Rows[y1].Cells["Rate"].Value.ToString();
                                                  Ot_val = Ot_val + Convert.ToInt32(Convert.ToDouble(val_amt) * Convert.ToDouble(prx.ToString()) / Convert.ToDouble(lblMOD.Text.ToString()));

                                                  if (Ot_Det == "")
                                                  {

                                                      if (Convert.ToDouble(prx.ToString()) > 0)
                                                      {
                                                          Ot_Det = Convert.ToString(dtdtl.Rows[y]["designation"]) + " : [" + Convert.ToString((val_amt.ToString()) + " x " + (prx.ToString()) + "/" + (lblMOD.Text.ToString())) + "]";
                                                      }

                                                  }
                                                  else
                                                  {
                                                      if (Convert.ToDouble(prx.ToString()) > 0)
                                                      {
                                                          Ot_Det = Ot_Det + Environment.NewLine + Convert.ToString(dtdtl.Rows[y1]["designation"]) + " : [" + Convert.ToString((val_amt.ToString()) + " x " + (prx.ToString()) + "/" + (lblMOD.Text.ToString())) + "]";
                                                      }
                                                  }
                                              }

                                              dgotherjob.Rows[ind].Cells["OCDesc"].Value = Ot_Det;
                                              dgotherjob.Rows[ind].Cells["OCAmt"].Value = Ot_val.ToString();
                                          }
                                      }
                                      else
                                      {
                                          dgotherjob.Rows[ind].Cells["OCDesc"].Value = dtdtl1.Rows[y]["vnote"].ToString();
                                          dgotherjob.Rows[ind].Cells["OCAmt"].Value = dtdtl1.Rows[y]["fper"].ToString();
                                      }
                                  }

                                  la.Text = dtdtl1.Rows[y]["htext"].ToString();
                                  la1.Text = dgotherjob.Rows[ind].Cells["OCAmt"].Value.ToString();

                                  //following lines added by dwipraj dutta 19082017
                                  dgotherjob.Rows[ind].Cells["sacnooc"].Value = dtdtl1.Rows[y]["SAC"].ToString();
                                  dgotherjob.Rows[ind].Cells["OC_gst_per"].Value = dtdtl1.Rows[y]["GstPer"].ToString();//clsDataAccess.ReturnValue("select GstPer from CompanySACMaster where (slno='" + Convert.ToString(dtdtl1.Rows[y]["SAC"].ToString()) + "')");
                                  dgotherjob.Rows[ind].Cells["OC_gst_amt"].Value = 0;

                                  if (SacGst == 1)
                                  {
                                      dgotherjob.Rows[ind].Cells["OC_gst_amt"].Value = Convert.ToDouble(Convert.ToDouble(dgotherjob.Rows[ind].Cells["OCAmt"].Value) * (Convert.ToDouble(dgotherjob.Rows[ind].Cells["OC_Gst_Per"].Value) / 100)).ToString("0.00");

                                  }
                                  else
                                  {
                                      dgotherjob.Rows[ind].Cells["OC_gst_amt"].Value = 0;
                                  }

                                  lbe[y + 2] = la;
                                  lbH[y + 2] = la1;
                              }
                              else
                              {
                                  lblNote.Text = dtdtl1.Rows[y]["vnote"].ToString();
                              }
                          }

                          if (boolSalAllotmentNotFound)
                          {
                              EDPMessageBox.EDPMessage.Show("Salary has not been alloted yet.");
                          }


                          //////getcode_item.Clear();
                          //////arritem = EDPCommon.arr_mod;
                          //////getcode_item = EDPCommon.get_code;

                          //////////////lblproduct.Items.Clear();
                          //////Item_Code = null;
                          //////for (int i = 0; i <= (arritem.Count - 1); i++)
                          //////{
                          //////    ////////lblproduct.Items.Add(arritem[i].ToString());
                          //////    Item_Code = Item_Code + getcode_item[i].ToString();
                          //////    if (i != getcode_item.Count - 1)
                          //////    {
                          //////        Item_Code = Item_Code + ",";
                          //////    }
                          //////}
                      }
                      boolSalAllotmentNotFound = false;
                  }
                  catch 
                  {
                      boolSalAllotmentNotFound = false;
                  }
              }
              else if (cmbBillType.SelectedIndex == 1)
              {
                  try
                  {

                      //string sqlstmnt = "Select Order_Name,Order_Date,Location,Order_ID from tbl_Employee_OrderDetails  where (Co_Code='" + Company_id + "') and (Cliant_ID='" + Client_id + "') and (ltrim(rtrim(location))='" + cmbLocation.Text.Trim() + "')";

                      //DataTable dt2 = clsDataAccess.RunQDTbl(sqlstmnt);
                      //EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Item Name", "List of Item Name", 0, "CMPN",0);
                      string arrayItem = "''";
                      string mod_val;
                      int mod_days = 0, bmod = 0;
                      string firstDate = "", lastDate = "";

                      firstDate = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-01";
                      lastDate = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);

                      String sqlLocGet = "select odd.Order_Name,pb.Location,odd.Order_Date from (select [Location],rtrim(ltrim([Order_Name])) as 'Order_Name',Co_Code,Cliant_ID from [tbl_Employee_OrderDetails]) pb inner join tbl_Employee_OrderDetails_Dtl odd on odd.Order_Name = pb.Order_Name where desig_ID = " + DesgID + " and Cliant_ID = " + Client_id + " and Co_Code = " + Company_id + " and Order_Date between '" + firstDate + "' and '" + lastDate + "'";
                      DataTable dtsqlLocGet = clsDataAccess.RunQDTbl(sqlLocGet);
                      if (dtsqlLocGet.Rows.Count > 0)
                      {
                          EDPCommon.MLOV_EDP(sqlLocGet, "Tag Item", "Select Item Name", "List of Item Name", 0, "CMPN", 0);
                          arritem.Clear();
                          arrayItem = "";
                          arritem = EDPCommon.arr_mod;
                          for (int i = 0; i < arritem.Count; i++)
                          {
                              if (arrayItem.Trim() == "")
                              {
                                  arrayItem = "'" + arritem[i].ToString().Trim() + "'";
                              }
                              else
                              {
                                  arrayItem = arrayItem + ",'" + arritem[i].ToString().Trim() + "'";
                              }

                          }
                      }
                      else
                      {
                          for (int i = 0; i < dtsqlLocGet.Rows.Count; i++)
                          {
                              arrayItem = "'" + dtsqlLocGet.Rows[i]["Order_Name"].ToString() + "'";

                          }
                      }

                      dgemployjob.Rows.Clear();
                      if (arritem.Count > 0)
                      {
                          //--------------------------------------------------added by dwipraj dutta 07092017------------------------------------------
                          string sqlGSTTypeGet = "select distinct (select rm.GSTTYPE from [Companywiseid_Relation] rm where cast(rm.Location_ID as varchar) COLLATE DATABASE_DEFAULT = cast(mt.LocID as varchar) COLLATE DATABASE_DEFAULT and cast(mt.Co_Code as varchar) COLLATE DATABASE_DEFAULT = cast(rm.Company_ID as varchar) COLLATE DATABASE_DEFAULT) from (select (select lm.Location_ID from tbl_Emp_Location lm where lm.Location_Name = od.Location) as 'LocID',od.Co_Code from tbl_Employee_OrderDetails od where od.Order_Name in (" + arrayItem + ")) mt";
                          DataTable gstInfo = clsDataAccess.RunQDTbl(sqlGSTTypeGet);
                          if (gstInfo.Rows.Count > 1)
                          {
                              EDPMessageBox.EDPMessage.Show("Please select the locations with same gsttype catagory.");
                              arrayItem = "";
                              arritem.Clear();
                              return;
                          }
                          string gstapplicable = gstInfo.Rows[0][0].ToString().Trim();
                          //string gstapplicable = "LOCAL";
                          string gstPercentage = clsDataAccess.RunQDTbl("select GSTPER from Branch where GCODE = " + Company_id + "").Rows[0][0].ToString().Trim();
                          if (gstapplicable != "")
                          {
                              if (gstapplicable == "LOCAL")
                              {
                                  checkBox1.Text = "GST";
                                  label9.Text = "SGST%@";
                                  txtSTPer.Text = (Convert.ToDouble(gstPercentage) / 2).ToString();
                                  label13.Visible = true;
                                  cgstPer.Visible = true;
                                  cgstPer.Text = (Convert.ToDouble(gstPercentage) / 2).ToString();
                              }
                              else
                              {
                                  checkBox1.Text = "GST";
                                  label9.Text = "IGST%@";
                                  txtSTPer.Text = gstPercentage;
                                  label13.Visible = false;
                                  cgstPer.Visible = false;
                              }
                          }
                          else
                          {
                              checkBox1.Text = "Service Tax";
                              label9.Text = "Service Tax % @";
                              //txtSTPer.Text = "14.5";
                              label13.Visible = false;
                              cgstPer.Visible = false;
                          }
                          //--------------------------------------------------------------------------------------------------------------------------
                          DataTable dtdtl = clsDataAccess.RunQDTbl("select d.Dtl_id,d.Order_Name,d.Order_Date,(select DesignationName from tbl_Employee_DesignationMaster where SlNo=d.desig_ID )as 'designation',(select h.Location  from tbl_Employee_OrderDetails h where h.Order_Name=d.Order_Name  ) as 'locname',d.Hour,d.MonthDays,d.RATE,d.desig_ID,d.rmrks,d.bmod,"+
                         "(select serviceName+':'+sacNo as 'SACNo' from CompanySACMaster where slno = d.SAC) as 'SAC',(select GstPer from CompanySACMaster where (slno=d.SAC))GstPer from tbl_Employee_OrderDetails_Dtl d where d.Order_Name in (" + arrayItem.ToString().Trim() + ") and d.[desig_ID] = '" + DesgID + "'");

                          for (int y = 0; y <= dtdtl.Rows.Count - 1; y++)
                          {
                              dgemployjob.Rows.Add();
                              dgemployjob.Rows[y].Cells["id"].Value = Convert.ToString(dtdtl.Rows[y]["Dtl_id"]);
                              dgemployjob.Rows[y].Cells["locationname"].Value = Convert.ToString(dtdtl.Rows[y]["locname"]);
                              dgemployjob.Rows[y].Cells["Designation"].Value = Convert.ToString(dtdtl.Rows[y]["designation"]);

                              //changes made by dwipraj dutta 18082017
                              if (!String.IsNullOrEmpty(Convert.ToString(dtdtl.Rows[y]["SAC"])))
                              {
                                  dgemployjob.Rows[y].Cells["sacno"].Value = Convert.ToString(dtdtl.Rows[y]["SAC"]);
                              }

                              dgemployjob.Rows[y].Cells["Hour"].Value = Convert.ToString(dtdtl.Rows[y]["Hour"]);
                              dgemployjob.Rows[y].Cells["colRmrks"].Value = Convert.ToString(dtdtl.Rows[y]["rmrks"]);
                              mod_val = Convert.ToString(dtdtl.Rows[y]["MonthDays"]);
                              string sqlstr = "";
                              if (mod_val == "MonthOfDays")
                              {
                                  mod_days = System.DateTime.DaysInMonth(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value.Month);
                              }
                              else if (mod_val == "MOD-SUNDAY")
                              {
                                  mod_days = NoOfWorkingDays(dateTimePicker1.Value);
                              }
                              else if (mod_val.Length>=5&&mod_val.Substring(0, 5) == "RANGE")
                              {
                                  string modVal = mod_val;
                                  int fromDate = Convert.ToInt32(modVal.Substring(5, (modVal.IndexOf("-") - 5)));
                                  int toDate = Convert.ToInt32(modVal.Substring(modVal.IndexOf("-") + 1));
                                  mod_days = NoOfWorkingDays(dateTimePicker1.Value, fromDate, toDate);
                              }
                              else if (mod_val == "26")
                              {
                                  mod_days = 26;
                              }
                              else if (mod_val == "PerDay" || mod_val == "PerHour")
                              {
                                  mod_days = 1;
                              }
                              dgemployjob.Rows[y].Cells["MontOfDays"].Value = Convert.ToString(dtdtl.Rows[y]["MonthDays"]);
                              dgemployjob.Rows[y].Cells["OrderNo"].Value = Convert.ToString(dtdtl.Rows[y]["Order_Name"]);
                              dgemployjob.Rows[y].Cells["orderdate"].Value = Convert.ToDateTime(dtdtl.Rows[y]["Order_Date"]).ToShortDateString();


                              double _rate = 0.00;
                              _rate = Convert.ToDouble(dtdtl.Rows[y]["Rate"]);
                              dgemployjob.Rows[y].Cells["Rate"].Value = _rate;

                              //for calculating attandance
                              string loc1 = "";
                              string desig1 = "";
                              loc1 = dgemployjob.Rows[y].Cells["locationname"].Value.ToString().Trim();
                              loc1 = clsDataAccess.RunQDTbl("select Location_ID from tbl_Emp_Location where RTRIM(LTRIM(Location_Name)) = '" + loc1 + "'").Rows[0][0].ToString();
                              desig1 = dtdtl.Rows[y]["desig_ID"].ToString();

                              //sqlstr = "select  sum(sm.TotalDays) as 'Attandance',(select  e.DesignationName from tbl_Employee_DesignationMaster e where e.SlNo =m.DesgId ) as [DesignationName]  from tbl_Employee_SalaryMast sm inner join tbl_Employee_Mast m ";
                              //sqlstr = sqlstr + " on sm.Location_id=m.Location_id where sm.Emp_Id=m.id and sm.Month='" + cmbmonth.Text + "' and m.DesgId=" + clsEmployee.GetDesgId(desig1) + "  and m.Location_id =" + clsEmployee.GetlocID(loc1) + " group by m.DesgId ";
                              //sqlstr = "select  sum('" + mod_days + "' + sm.OT) as 'Attandance',(select  e.DesignationName from tbl_Employee_DesignationMaster e where e.SlNo =" + desig1 + " ) as [DesignationName]  from tbl_Employee_SalaryMast sm inner join tbl_Employee_Attend m ";
                              //sqlstr = sqlstr + " on sm.Location_id=m.Location_id where sm.Emp_Id=m.id and sm.Month='" + cmbmonth.Text + "' and (m.Location_id =" + clsEmployee.GetlocID(loc1) + ") ";


                              val_ot = Convert.ToInt32(clsDataAccess.GetresultS("SELECT  count(*) FROM tbl_order_FB_detail where (htext='OT' or htext='Overtime') and Fname in (" + arrayItem.ToString().Trim() + ")"));

                              bmod = Convert.ToInt32(dtdtl.Rows[y]["bmod"]);

                              dgemployjob.Rows[y].Cells["col_bmod"].Value = bmod;
                              if (val_ot == 0 && bmod != 1)
                              {
                                  sqlstr = "select sum(wday + proxy) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + loc1 + "') and (Desgid='" + desig1 + "') and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                              }
                              else
                              {
                                  if (bmod == 1)
                                  {
                                      sqlstr = "select (sum(wday)*1.5) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + loc1 + "') and (Desgid='" + desig1 + "') and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                  }
                                  else
                                  {
                                      sqlstr = "select sum(wday) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + loc1 + "') and (Desgid='" + desig1 + "') and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                                  }
                              }


                              //if (val_ot == 0)
                              //{
                              //    sqlstr = "select sum(wday + proxy) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid='" + desig1 + "') and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                              //}
                              //else
                              //{
                              //    sqlstr = "select sum(wday) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid='" + desig1 + "') and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";

                              //}

                              //sqlstr = "select sum('" + mod_days + "' + Proxy) as 'Attandance',(select  e.DesignationName from tbl_Employee_DesignationMaster e where e.SlNo =" + desig1 + " ) as [DesignationName] from tbl_Employee_Attend where (MONTH='"+ dateTimePicker1.Value.ToString("M/yyyy") +"') and (Season='"+ cmbYear.Text +"') and (LOcation_ID='" + clsEmployee.GetlocID(loc1) + "') and (Desgid='" + desig1 + "')";
                              DataTable dtid = clsDataAccess.RunQDTbl(sqlstr);

                              if (dtid.Rows.Count > 0)
                              {
                                  if ((dtid.Rows.Count > 0) && (Information.IsNumeric(dtid.Rows[0][0]) == true))
                                  {
                                      //if ((dgemployjob.Rows[y].Cells["Attendance"].Value == "") || (dgemployjob.Rows[y].Cells["Attendance"].Value == "0"))
                                      //{
                                      dgemployjob.Rows[y].Cells["Attendance"].Value = Convert.ToString(dtid.Rows[0][0]);
                                      //}
                                  }
                              }
                              else
                              {
                                  //ERPMessageBox.ERPMessage.Show("Attendance not found in '" + desig1 + "' for the month of '" + cmbmonth.Text + "'");
                                  //return;
                              }
                              //for calculating attandance
                              string strSQL = "select count(*) from tbl_Employee_Attend as ea where (LOcation_ID='" + location_id + "') and (Desgid='" + desig1 + "') and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')";
                              dgemployjob.Rows[y].Cells["Personnel"].Value = clsDataAccess.GetresultS(strSQL);
                              //for calculating Amount

                              dgemployjob.Rows[y].Cells["Amount"].Value = Convert.ToInt32(Math.Round(((Convert.ToDouble(_rate) / Convert.ToDouble(mod_days)) * Convert.ToDouble(dgemployjob.Rows[y].Cells["Attendance"].Value)), 2)).ToString("0.00");

                              //for calculating Amount
                          }

                          // WIll be added soon 07092017
                          double bsc = 0, bs = 0;
                          int ind = 0;
                          for (int indx = 0; indx < dgemployjob.Rows.Count; indx++)
                          {
                              bsc = bsc + Convert.ToDouble(dgemployjob.Rows[indx].Cells["Amount"].Value);
                          }

                          DataTable dt_bs_head = clsDataAccess.RunQDTbl("SELECT C_DET,atten_day,Daily_wages FROM tbl_Employee_Assign_SalStructure WHERE (SAL_HEAD=(SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short='BS'))) AND (Location_id = '" + location_id + "') AND (Company_id = '" + Company_id + "') AND (P_TYPE = 'E')");
                          if (dt_bs_head.Rows.Count > 0)
                          {
                              DataTable dt_bs = clsDataAccess.RunQDTbl("SELECT LUMPNAME,GRADE,AMOUNT FROM tbl_Employee_Lumpsum WHERE (LUMPID ='" + dt_bs_head.Rows[0]["C_DET"].ToString() + "')");
                              while (ind < dt_bs.Rows.Count)
                              {
                                  if (dt_bs_head.Rows[0]["Daily_wages"].ToString() == "1")
                                  {
                                      bs = bs + Convert.ToInt32(Convert.ToDouble(dt_bs.Rows[ind]["AMOUNT"]) * Convert.ToDouble(lblMOD.Text));
                                  }
                                  else
                                  {
                                      bs = bs + Convert.ToDouble(dt_bs.Rows[ind]["AMOUNT"]);
                                  }
                                  ind = ind + 1;
                              }
                          }
                          Label lb2 = new Label();
                          Label lb3 = new Label();
                          lb.Text = "BS";
                          lbe[0] = lb;
                          lb1.Text = bs.ToString();
                          lbH[0] = lb1;

                          lb2.Text = "BSC";
                          lbe[1] = lb2;
                          lb3.Text = bsc.ToString();
                          lbH[1] = lb3;



                          
                          DataTable dtdtl1 = clsDataAccess.RunQDTbl("select Fid,Fname,position,basis,Fexpr,fper,vnote,htext,"+
                         "(select serviceName+':'+sacNo as 'SACNo' from CompanySACMaster where slno = d.SAC) as 'SAC',(select GstPer from CompanySACMaster where (slno=d.SAC)) GstPer  FROM tbl_order_FB_detail d where Fname in (" + arrayItem.ToString().Trim() + ") order by position");
                          ind = 0;
                          for (int y = 0; y <= dtdtl1.Rows.Count - 1; y++)
                          {
                              if (dtdtl1.Rows[y]["htext"].ToString().ToLower() != "note")
                              {
                                  ind = dgotherjob.Rows.Add();
                                  Label la = new Label();
                                  Label la1 = new Label();


                                  if (dtdtl1.Rows[y]["basis"].ToString().ToLower() == "formula")
                                  {
                                      dgotherjob.Rows[ind].Cells["OCDesc"].Value = dtdtl1.Rows[y]["vnote"].ToString();
                                      dgotherjob.Rows[ind].Cells["OCAmt"].Value = formula(dtdtl1.Rows[y]["Fexpr"].ToString());
                                  }
                                  else
                                  {
                                      if (dtdtl1.Rows[y]["htext"].ToString().ToLower() == "ot")
                                      {
                                          val_ot = Convert.ToInt32(clsDataAccess.GetresultS("SELECT  count(*) FROM tbl_order_FB_detail where (htext='OT' or htext='Overtime') and Fname in (" + arrayItem.ToString().Trim() + ")"));
                                          if (val_ot > 0)
                                          {
                                              string desig1 = "", Ot_Det = dtdtl1.Rows[y]["vnote"].ToString(), val_amt = "";
                                              double Ot_val = 0;

                                              for (int y1 = 0; y1 <= dtdtl.Rows.Count - 1; y1++)
                                              {
                                                  desig1 = dtdtl.Rows[y1]["desig_ID"].ToString();
                                                  prx = clsDataAccess.GetresultS("select isNull(sum(proxy),0) as attandance,(select DesignationName from tbl_Employee_DesignationMaster where SlNo ='" + desig1 + "') as [DesignationName] from tbl_Employee_Attend  as ea where (LOcation_ID='" + location_id + "') and (Desgid='" + desig1 + "') and (MONTH ='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + "')");
                                                  val_amt = dgemployjob.Rows[y1].Cells["Rate"].Value.ToString();
                                                  Ot_val = Ot_val + Convert.ToInt32(Convert.ToDouble(val_amt) * Convert.ToDouble(prx.ToString()) / Convert.ToDouble(lblMOD.Text.ToString()));

                                                  if (Ot_Det == "")
                                                  {

                                                      if (Convert.ToDouble(prx.ToString()) > 0)
                                                      {
                                                          Ot_Det = Convert.ToString(dtdtl.Rows[y]["designation"]) + " : [" + Convert.ToString((val_amt.ToString()) + " x " + (prx.ToString()) + "/" + (lblMOD.Text.ToString())) + "]";
                                                      }

                                                  }
                                                  else
                                                  {
                                                      if (Convert.ToDouble(prx.ToString()) > 0)
                                                      {
                                                          Ot_Det = Ot_Det + Environment.NewLine + Convert.ToString(dtdtl.Rows[y1]["designation"]) + " : [" + Convert.ToString((val_amt.ToString()) + " x " + (prx.ToString()) + "/" + (lblMOD.Text.ToString())) + "]";
                                                      }
                                                  }
                                              }

                                              dgotherjob.Rows[ind].Cells["OCDesc"].Value = Ot_Det;
                                              dgotherjob.Rows[ind].Cells["OCAmt"].Value = Ot_val.ToString();
                                          }
                                      }
                                      else
                                      {
                                          dgotherjob.Rows[ind].Cells["OCDesc"].Value = dtdtl1.Rows[y]["vnote"].ToString();
                                          dgotherjob.Rows[ind].Cells["OCAmt"].Value = dtdtl1.Rows[y]["fper"].ToString();
                                      }
                                  }

                                  la.Text = dtdtl1.Rows[y]["htext"].ToString();
                                  //la1.Text = dgotherjob.Rows[ind].Cells["OCAmt"].Value.ToString();

                                  //following lines added by dwipraj dutta 19082017
                                  dgotherjob.Rows[ind].Cells["sacnooc"].Value = dtdtl1.Rows[y]["SAC"].ToString();

                                  lbe[y + 2] = la;
                                  lbH[y + 2] = la1;
                              }
                              else
                              {
                                  lblNote.Text = dtdtl1.Rows[y]["vnote"].ToString();
                              }
                          }
                          


                      }

                  }
                  catch { }
              }
        }


        public string formula_sal(string s)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Rows.Add();
            dt.Rows[0][0] = s;
            int g = 0, i = 0;
            string exp = "", res = "";
            try
            {
                for (int f = 0; f < dt.Rows[0][0].ToString().Trim().Length; f++)
                {
                    if (dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "=" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "*" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "+" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "-" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "/" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "%" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "(" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == ")")
                    {
                        if (Information.IsNumeric(dt.Rows[0][0].ToString().Trim().Substring(g, i)) == false)
                        {
                            if (htSalHead.Contains(dt.Rows[0][0].ToString().Trim().Substring(g, i)))
                            {
                                try
                                {
                                    exp += htSalHead[dt.Rows[0][0].ToString().Trim().Substring(g, i)] + dt.Rows[0][0].ToString().Trim().Substring(f, 1);

                                }
                                catch
                                {
                                }
                            }
                            
                        }
                        else
                        {


                            try
                            {
                                exp += dt.Rows[0][0].ToString().Trim().Substring(g, i) + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                            }
                            catch
                            {

                            }
                        }

                        i = 0;
                        g = f + 1;
                    }
                    else
                        i++;
                }
                exp += dt.Rows[0][0].ToString().Trim().Substring(g, i);
                res = f_cal(exp);
            }
            catch { }


            return res;
        }


        public string formula(string s)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Rows.Add();
            dt.Rows[0][0] = s;
            int g = 0, i = 0 ;
            string exp = "",res="";
            try
            {
                for (int f = 0; f < dt.Rows[0][0].ToString().Trim().Length; f++)
                {
                    if (dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "=" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "*" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "+" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "-" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "/" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "%" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == "(" || dt.Rows[0][0].ToString().Trim().Substring(f, 1) == ")")
                    {
                        if (Information.IsNumeric(dt.Rows[0][0].ToString().Trim().Substring(g, i))==false)
                        {
                            for (int lt = 0; lt < lbe.Length; lt++)
                            {
                                Label l = new Label();
                                Label t = new Label();
                                //TextBoxX.TextBoxX t = new TextBoxX.TextBoxX();
                                l = lbe[lt];
                                t = lbH[lt];
                                string te = dt.Rows[0][0].ToString().Trim().Substring(g, i).ToString();
                                if (lbe[lt] != null && l.Text.Trim() == te)
                                {
                                    try
                                    {
                                        exp += t.Text.Trim() + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                                        
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        else
                        {


                            try
                            {
                                exp += dt.Rows[0][0].ToString().Trim().Substring(g, i) + dt.Rows[0][0].ToString().Trim().Substring(f, 1);
                            }
                            catch
                            {

                            }
                        }
                        
                        i = 0;
                        g = f + 1;
                    }
                    else
                        i++;
                }
                exp += dt.Rows[0][0].ToString().Trim().Substring(g, i);
                res= f_cal(exp);
            }
            catch { }
            return res;

        }

        public string f_cal(string exp)
        {
            int g = 0, i = 0, ta = 0;
            double fl = 0, bs = 0;
            string res = "";
            for (int f = 0; f < exp.Trim().Length; f++)
            {

                if (exp.Trim().Substring(f, 1) == "*")
                {
                    if (fl == 0)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                        {
                            try
                            {
                                fl = Convert.ToDouble(exp.Trim().Substring(g, f));
                            }
                            catch
                            { }

                            try
                            {
                                bs = Convert.ToDouble(exp.Trim().Substring(g, f));
                            }
                            catch { }
                        }
                        else
                            fl = 0;
                    }
                    if (ta == 1)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl * 0;
                    }
                    else if (ta == 2)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl + 0;
                    }
                    else if (ta == 3)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl - 0;
                    }
                    else if (ta == 4)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl / 0;
                    }
                    else if (ta == 5)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl % 0;
                    }
                    ta = 1;
                    i = 0;
                    g = f + 1;
                }
                else if (exp.Trim().Substring(f, 1) == "+")
                {
                    if (fl == 0)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                        {
                            fl = Convert.ToDouble(exp.Trim().Substring(g, i));

                            try
                            {
                                bs = Convert.ToDouble(exp.Trim().Substring(g, f));
                            }
                            catch { }
                        }
                        else
                            fl = 0;
                    }
                    if (ta == 1)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl * 0;
                    }
                    else if (ta == 2)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl + 0;
                    }
                    else if (ta == 3)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl - 0;
                    }
                    else if (ta == 4)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl / 0;
                    }
                    else if (ta == 5)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl % 0;
                    }
                    ta = 2;
                    i = 0;
                    g = f + 1;
                }
                else if (exp.Trim().Substring(f, 1) == "-")
                {
                    if (fl == 0)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                        {
                            fl = Convert.ToDouble(exp.Trim().Substring(g, i));

                            try
                            {
                                bs = Convert.ToDouble(exp.Trim().Substring(g, f));
                            }
                            catch { }
                        }
                        else
                            fl = 0;
                    }
                    if (ta == 1)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl * 0;
                    }
                    else if (ta == 2)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl + 0;
                    }
                    else if (ta == 3)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl - 0;
                    }
                    else if (ta == 4)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl / 0;
                    }
                    else if (ta == 5)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl % 0;
                    }
                    ta = 3;
                    i = 0;
                    g = f + 1;
                }
                else if (exp.Trim().Substring(f, 1) == "/")
                {
                    if (fl == 0)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                        {
                            fl = Convert.ToDouble(exp.Trim().Substring(g, i));
                            try
                            {
                                bs = Convert.ToDouble(exp.Trim().Substring(g, f));
                            }
                            catch { }
                        }
                        else
                            fl = 0;
                    }
                    if (ta == 1)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl * 0;
                    }
                    else if (ta == 2)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl + 0;
                    }
                    else if (ta == 3)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl - 0;
                    }
                    else if (ta == 4)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl / 0;
                    }
                    else if (ta == 5)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl % 0;
                    }
                    ta = 4;
                    i = 0;
                    g = f + 1;
                }
                else if (exp.Trim().Substring(f, 1) == "%")
                {
                    if (fl == 0)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                        {
                            fl = Convert.ToDouble(exp.Trim().Substring(g, i));


                            try
                            {
                                bs = Convert.ToDouble(exp.Trim().Substring(g, f));
                            }
                            catch { }
                        }
                        else
                            fl = 0;
                    }
                    if (ta == 1)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl * 0;
                    }
                    else if (ta == 2)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl + 0;
                    }
                    else if (ta == 3)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl - 0;
                    }
                    else if (ta == 4)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl / 0;
                    }
                    else if (ta == 5)
                    {
                        if (exp.Trim().Substring(g, i) != "")
                            fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                        else
                            fl = fl % 0;
                    }
                    ta = 5;
                    i = 0;
                    g = f + 1;
                }
                else if (exp.Trim().Substring(f, 1) == "(")
                {
                    i = 0;
                    g = f + 1;
                }
                else if (exp.Trim().Substring(f, 1) == ")")
                {
                    i = 0;
                    g = f + 1;
                }
                else
                {
                    i++;
                }
            }
            if (ta == 1)
            {
                if (exp.Trim().Substring(g, i) != "")
                    fl = fl * Convert.ToDouble(exp.Trim().Substring(g, i));
                else
                    fl = fl * 0;
            }
            else if (ta == 2)
            {
                if (exp.Trim().Substring(g, i) != "")
                    fl = fl + Convert.ToDouble(exp.Trim().Substring(g, i));
                else
                    fl = fl + 0;
            }
            else if (ta == 3)
            {
                if (exp.Trim().Substring(g, i) != "")
                    fl = fl - Convert.ToDouble(exp.Trim().Substring(g, i));
                else
                    fl = fl - 0;
            }
            else if (ta == 4)
            {
                if (exp.Trim().Substring(g, i) != "")
                    fl = fl / Convert.ToDouble(exp.Trim().Substring(g, i));
                else
                    fl = fl / 0;
            }
            else if (ta == 5)
            {
                if (exp.Trim().Substring(g, i) != "")
                    fl = fl % Convert.ToDouble(exp.Trim().Substring(g, i));
                else
                    fl = fl % 0;
            }

            //if (bs==0)
            //{
            //    fl=bs;
            //}
            res = Convert.ToString(fl);
            if (bs == 0)
            {
                res = bs.ToString();
            }
            return res;
        }




        private void dgemployjob_CellLeave(object sender, DataGridViewCellEventArgs e)
        {


            if (dgemployjob.Columns[e.ColumnIndex].HeaderText == "Designation")
            {
                if (dgemployjob.Rows[e.RowIndex].Cells["Designation"].Value != null )
                {
                    string mnth = "";
                    mnth = cmbmonth.Text;

                    string _session = "";
                    _session = cmbYear.Text;

                    string var = "";
                    var = dgemployjob.Rows[e.RowIndex].Cells["locationname"].Value.ToString();

                    string _desig = "";
                    _desig = dgemployjob.Rows[e.RowIndex].Cells["Designation"].Value.ToString();


                    string strsql4 = " select Desig_Id,bill_tag from tbl_Employee_SalaryMast where Location_ID=" + clsEmployee.GetlocID(var) + "  and Company_id='" + get_CompID(cmbcompany.Text) + "'  and SESSION='" + _session + "' and MONTH='" + mnth + "' and Desig_Id=" + clsEmployee.GetDesgId(_desig) + "  group by Desig_Id,bill_tag";

                    DataTable dt24 = clsDataAccess.RunQDTbl(strsql4);

                    if (dt24.Rows.Count > 0)
                    {
                        if (dt24.Rows[0]["bill_tag"].ToString().Trim() == "1")
                        {
                            ERPMessageBox.ERPMessage.Show("Already billed the " + _desig + "for the month of " + mnth);
                            dgemployjob.ClearSelection();

                            dgemployjob.Rows[dgemployjob.CurrentCell.RowIndex].Cells["Designation"].Selected = true;
                            dgemployjob.CurrentCell = dgemployjob[5, dgemployjob.CurrentCell.RowIndex];
                            return;
                        }

                      
                    }
                }
               

            }
            else if (dgemployjob.Columns[e.ColumnIndex].HeaderText == "Location Site Name")
            {
                if (cmbBillType.SelectedIndex == 1)
                {

                    dgemployjob.Rows[e.RowIndex].Cells["Designation"].Value = cmbDesgName.Text.Trim();
                }

            }
            
            calculateAmt();



        }

        
        private void dgemployjob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dgemployjob.RowCount == 1)
                {
                    return;
                }
                else if (dgemployjob.RowCount > 1)
                {
                    dgemployjob.Rows.RemoveAt(dgemployjob.CurrentRow.Index);
                    dgemployjob.Refresh();
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cmbmonth.Text = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
            int year = dateTimePicker1.Value.Year;
            calculated_days  = Convert.ToInt32(clsEmployee.GetTotalDaysByMonth(cmbmonth.Text, year));
            if (dateTimePicker1.Value.Month < DateTime.Now.Month && dateTimePicker1.Value.Year == DateTime.Now.Year)
            {
                dtpto.Value = DateTime.Now;
            }
            else
            {
                dtpto.Value = Convert.ToDateTime("01/" + clsEmployee.GetMonthName(dateTimePicker1.Value.AddMonths(1).Month) + "/" + dateTimePicker1.Value.AddMonths(1).Year);
            }
            //calculateAmt();
            SessionValueCheckAndAssignNoOfDays();

        }

        private void SessionValueCheckAndAssignNoOfDays()
        {
            int NumberOfDays = DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);
          //  txtDays.Text = NumberOfDays.ToString();

            if (dateTimePicker1.Value.Month >= 4)
            {
                cmbYear.SelectedItem = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.AddYears(1).Year;

                // cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedItem = dateTimePicker1.Value.AddYears(-1).Year + "-" + dateTimePicker1.Value.Year;
                // cmbYear.SelectedIndex = 1;
            }

        }

        private void cmbdescription_DropDown(object sender, EventArgs e)
        {
            string s = "";
            try
            {
                if (location_id != "0")
                {
                    cinv = Convert.ToInt32(clsDataAccess.GetresultS("select COUNT(*) from TypeDoc where t_entry='9' and locid='" + location_id + "' and Type_Desc!=''"));
                }
            }
            catch{cinv=0;}


            if (cinv==0)
            {
                s = "select type_desc as 'Description',desccode as 'Code' from typedoc where ficode='1'and gcode='1' and t_entry='9' and session ='" + cmbYear.Text + "'";
            }
            else
            {
                s = "select type_desc as 'Description',desccode as 'Code' from typedoc where t_entry='9' and session ='' and locid='"+cmbLocation.ReturnValue+"' and Type_Desc!=''";
            }
            DataTable dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count == 1)
                {
                    cmbdescription.Text = Convert.ToString(dt.Rows[0][0]);
                    cmbdescription.ReturnValue = Convert.ToString(dt.Rows[0][1]);
                    cmbdescription_CloseUp();
                }
                else
                {
                    cmbdescription.LookUpTable = dt;
                    cmbdescription.ReturnIndex = 1;
                }
            }
            

        }

        private void cmbdescription_CloseUp(object sender, ComboDialog.CloseUpEventArgs e)
        {
            cmbdescription_CloseUp();
        }

        public string GetDocNumber(Int64 Desccode, string Tentry, string session)
        {
            try
            {
                EDPConnection edpcon = new EDPConnection();
                edpcon.Open();
                string docnumber = "", strsql4 = "";
                string sql = "";
                if (cinv==0)
                {
                    sql="select method from typedoc where ltrim(rtrim(ficode))='" + edpcom.CurrentFicode.Trim() + "' and ltrim(rtrim(gcode))='" + edpcom.PCURRENT_GCODE.Trim() + "' and ltrim(rtrim(desccode))='" + Desccode.ToString().Trim() + "' and ltrim(rtrim(t_entry))='" + Tentry.Trim() + "' and ltrim(rtrim(session))='" + session.Trim() + "'";
                }
                else
                {
                    sql = "select method from typedoc where (locid='"+cmbLocation.ReturnValue+"') and ltrim(rtrim(desccode))='" + Desccode.ToString().Trim() + "' and ltrim(rtrim(t_entry))='" + Tentry.Trim() + "' and ltrim(rtrim(session))=''";
                }
                string mydr = clsDataAccess.GetresultS(sql);



             

                if (mydr.Trim() == "A")
                {
                        if (cinv == 0)
                        {
                            strsql4 = ("select * from docnumber where ltrim(rtrim(ficode))='" + edpcom.CurrentFicode.Trim() + "' and ltrim(rtrim(gcode))='" + edpcom.PCURRENT_GCODE.Trim() + "' and ltrim(rtrim(desccode))='" + Desccode.ToString().Trim() + "' and ltrim(rtrim(t_entry))='" + Tentry.Trim() + "' and ltrim(rtrim(session))='" + session.Trim() + "'");
                        }
                        else
                        {
                            strsql4 = ("select * from docnumber where (locid='" + cmbLocation.ReturnValue + "') and ltrim(rtrim(desccode))='" + Desccode.ToString().Trim() + "' and ltrim(rtrim(t_entry))='" + Tentry.Trim() + "'");
                        }
                        DataTable dt24 = clsDataAccess.RunQDTbl(strsql4);

                        string PREPOS = dt24.Rows[0][7].ToString().Trim();
                        string SUFPOS = dt24.Rows[0][8].ToString().Trim();
                        string padding = dt24.Rows[0][9].ToString().Trim();
                        string doc_pos = dt24.Rows[0][10].ToString().Trim();
                        string no_sep = dt24.Rows[0][11].ToString().Trim();
                        string prefix = dt24.Rows[0][12].ToString().Trim();
                        string suffix = dt24.Rows[0][13].ToString().Trim();//mydr.GetString(13).Trim();
                        dt24.Clear();
                        if (suffix == "Season" || suffix == "Session" || suffix == "AcYr")
                        {
                            suffix = cmbYear.Text;
                        }
                        else if (suffix == "MonthYear")
                        {
                            suffix = dateTimePicker1.Value.ToString("MMM") + "/" + dateTimePicker1.Value.ToString("yy");
                        }

                        if (cinv == 0)
                        {
                            strsql4 = ("select VOUCHERNO from docgen where ltrim(rtrim(ficode))='" + edpcom.CurrentFicode.Trim() + "' and ltrim(rtrim(gcode))='" + edpcom.PCURRENT_GCODE.Trim() + "' and ltrim(rtrim(desccode))='" + Desccode.ToString().Trim() + "' and ltrim(rtrim(t_entry))='" + Tentry.Trim() + "' and ltrim(rtrim(session))='" + session.Trim() + "'");
                        }
                        else
                        {
                            strsql4 = ("select VOUCHERNO from docgen where ltrim(rtrim(desccode))='" + Desccode.ToString().Trim() + "' and ltrim(rtrim(t_entry))='" + Tentry.Trim() + "'");
                        }
                        dt24 = clsDataAccess.RunQDTbl(strsql4);
                        docnumber = dt24.Rows[0][0].ToString();

                        string sep = "", num = ""; int i = 0;
                        Int64 newnum = 0;
                        for (i = 1; i <= Convert.ToInt16(no_sep); i++) sep = sep + "/";
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
                   
                }
                else
                {

                    strsql4 = ("select VOUCHERNO from docgen where ltrim(rtrim(ficode))='" + edpcom.CurrentFicode.Trim() + "' and ltrim(rtrim(gcode))='" + edpcom.PCURRENT_GCODE.Trim() + "' and ltrim(rtrim(desccode))='" + Desccode.ToString().Trim() + "' and ltrim(rtrim(t_entry))='" + Tentry.Trim() + "' and ltrim(rtrim(session))='" + session.Trim() + "'");

                    DataTable dt24 = clsDataAccess.RunQDTbl(strsql4);
                    docnumber = dt24.Rows[0][0].ToString();
                }
                edpcon.Close();
                
                return docnumber;
            }
            catch
            {
                return null;
            }
        }

        public string GetDocNo(Int64 Desccode, string Tentry, string session)
        {
            try
            {
                EDPConnection edpcon = new EDPConnection();
                edpcon.Open();
                string docnumber = "", strsql4 = "";
                string sql = "select method from typedoc where ficode='0' and gcode='0' and desccode='" + Desccode + "' and ltrim(rtrim(t_entry))='9' and session =''";
                string mydr = clsDataAccess.GetresultS(sql);
                if (mydr.Trim() == "A")
                {

                    strsql4 = ("select * from docnumber where ficode='0' and gcode='0' and desccode='" + Desccode + "' and ltrim(rtrim(t_entry))='9' and session =''");
                    DataTable dt24 = clsDataAccess.RunQDTbl(strsql4);

                    string PREPOS = dt24.Rows[0][7].ToString().Trim();
                   
                    string SUFPOS = dt24.Rows[0][8].ToString().Trim();
                    string padding = dt24.Rows[0][9].ToString().Trim();
                    string doc_pos = dt24.Rows[0][10].ToString().Trim();
                    string no_sep = dt24.Rows[0][11].ToString().Trim();
                    string prefix = dt24.Rows[0][12].ToString().Trim();
                    cmbdescription.Text = prefix;
                    string suffix = dt24.Rows[0][13].ToString().Trim();//mydr.GetString(13).Trim();
                    dt24.Clear();
                    if (suffix == "Session" || suffix == "AccYr")
                    {
                        suffix = cmbYear.Text;
                    }
                    else if (suffix == "Month/Year")
                    {
                        suffix = dateTimePicker1.Value.ToString("MMM") + "/" + dateTimePicker1.Value.ToString("yy");
                    }

                    strsql4 = ("select VOUCHERNO from docgen where ficode='0' and gcode='0' and desccode='" + Desccode + "' and ltrim(rtrim(t_entry))='9' and session =''");

                    dt24 = clsDataAccess.RunQDTbl(strsql4);
                    docnumber = dt24.Rows[0][0].ToString();

                    string sep = "", num = ""; int i = 0;
                    Int64 newnum = 0;
                    for (i = 1; i <= Convert.ToInt16(no_sep); i++) sep = sep + "/";
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
                }
                else
                {

                    strsql4 = ("select VOUCHERNO from docgen where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' and desccode='" + Desccode + "' and ltrim(rtrim(t_entry))='" + Tentry + "'and session ='" + session + "'");

                    DataTable dt24 = clsDataAccess.RunQDTbl(strsql4);
                    docnumber = dt24.Rows[0][0].ToString();
                }
                edpcon.Close();
                return docnumber;
            }
            catch
            {
                return null;
            }
        }


        private void cmbYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbdescription.Focus();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Retrive_DataESI();
            //MidasReport.Form1 opening = new MidasReport.Form1();
            //opening.paybill_print(edpcom.CURRENT_COMPANY, ds, company, Agentadd, Agentadd1, phone, Area, BillDate, User_Voucher, challan, AmtWord, FinalAmount, challandt, amtvalue, lorry_no, locname, modtranport, prtyname, prtyadd1, prtyadd2, prtycity, prtyctypin, prtytele1, prtytele2, prtyemail, prtyfax, prtyeccno, prtytin, narrsn, 1);

            //opening.ShowDialog();

            //ds.Tables.Clear();
            //ds.Dispose();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            frmPayBillST fpbst = new frmPayBillST();
            fpbst.ShowDialog();
            funct_stper();           
        }

        private bool funct_stper()
        {
            double stper = 0;
           
            try
            {
                
                DataTable dt = clsDataAccess.RunQDTbl("select [STID],CONVERT(VARCHAR(10),[FromDATE],103) as FromDate ,[STMonth],[Slno],[STNAME],[STPER] from [paybillST] as [pbst] where [FromDATE]= (SELECT MAX(FromDATE) FROM paybillST WHERE FromDATE = paybillST.FromDATE)");
             
                
                    for (int ind_dgv = 0; ind_dgv < dt.Rows.Count; ind_dgv++)
                    {


                        //dgv_Kit.Rows.Add();
                        //dgv_Kit.Rows[ind_dgv].Cells["STNO"].Value = dt.Rows[ind_dgv]["Slno"];
                        //dgv_Kit.Rows[ind_dgv].Cells["STNAME"].Value = dt.Rows[ind_dgv]["STNAME"];
                        stper =stper +  Convert.ToDouble(dt.Rows[ind_dgv]["STPER"]);
                        //dgv_Kit.Rows[ind_dgv].Cells["STVAL"].Value = dt.Rows[ind_dgv]["STPER"];

                        //dtpto.Text = Convert.ToDateTime(dt.Rows[ind_dgv]["FromDATE"]).ToString("dd/MM/yyyy");
                        //lblSTID.Text = Convert.ToString(dt.Rows[ind_dgv]["STID"]);
                    }
                    txtSTPer.Text = Convert.ToString(stper);
                
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void dgotherjob_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgotherjob.Columns["OCAmt"].Index && e.RowIndex != dgotherjob.Rows.Count)//4)
            {
                try
                {
                    double KITMONTH = 0;
                    string sac = (dgotherjob.Rows[e.RowIndex].Cells["sacnoOC"].Value.ToString().Split(':'))[1].Trim();


                    try
                    {
                        dgotherjob.Rows[e.RowIndex].Cells["OC_gst_per"].Value = clsDataAccess.ReturnValue("select isNull(GstPer,0) from CompanySACMaster where (sacNo='" + sac + "')");
                    }
                    catch { }

                    try
                    {
                        if (dgotherjob.Rows[e.RowIndex].Cells["OCAttend"].Value == null || Convert.ToDouble(dgotherjob.Rows[e.RowIndex].Cells["OCAttend"].Value) == 0)
                            KITMONTH = Convert.ToDouble(dgotherjob.Rows[e.RowIndex].Cells["OCQty"].Value);
                        else
                            KITMONTH = Convert.ToDouble(dgotherjob.Rows[e.RowIndex].Cells["OCAttend"].Value);
                    }
                    catch { KITMONTH = 0; }

                    double KITVAL = 0;
                    try
                    {
                        KITVAL = Convert.ToDouble(dgotherjob.Rows[e.RowIndex].Cells["OCRate"].Value);
                    }
                    catch { KITVAL = 0; }

                    double KITEMI = Convert.ToDouble(KITVAL) * Convert.ToDouble(KITMONTH);

                    if (Convert.ToDouble(KITVAL) != 0 && Convert.ToDouble(KITMONTH) != 0 && KITEMI != 0)
                    {
                        dgotherjob.Rows[e.RowIndex].Cells["OCAmt"].Value = KITEMI;
                        dgotherjob.Rows[e.RowIndex].Cells["OC_gst_amt"].Value = KITEMI * (Convert.ToDouble(dgotherjob.Rows[e.RowIndex].Cells["OC_gst_per"].Value) / 100);
                    }

                }
                catch { }
            }

        }

        private void dgemployjob_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            Client_id = 0;
            DataTable dt = new DataTable();
            if (Client_id > 0)
            {
                dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID  from tbl_Emp_Location where (Cliant_ID='" + Client_id + "')  order by Location_Name");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID,"+
            "(select client_name from tbl_Employee_CliantMaster where Client_id= el.Cliant_ID) as Client,el.Cliant_ID as ClientID  from tbl_Emp_Location el where (Location_ID IN (select Location_ID from Companywiseid_Relation where (Company_ID='" + Company_id + "'))) order by Location_Name");
               
            }
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
        }

        private void cmbLocation_CloseUp(object sender, ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                location_id = Convert.ToString(cmbLocation.ReturnValue);
            

            if (Client_id == 0)
            {
                clientname();

            }
            //else
            //{
            //    clientname();

            //}
            try
            {
                if (location_id != "0")
                {
                    cinv = Convert.ToInt32(clsDataAccess.GetresultS("select COUNT(*) from TypeDoc where t_entry='9' and locid='" + location_id + "' and Type_Desc!=''"));
                }
            }
            catch { cinv = 0; }

            

            DataGridViewComboBoxColumn dgcombo4 = dgemployjob.Columns["locationname"] as DataGridViewComboBoxColumn;

            dgcombo4.DisplayMember = cmbLocation.Text;
            dgcombo4.ValueMember = location_id;
            string pref="";
            DataTable config = clsDataAccess.RunQDTbl("Select isST,isSTC,isSC,freeze,MOD,DueDateDays,scPer,OCQ from  Companywiseid_Relation where (Company_ID='" + Company_id + "') and (Location_ID='" + location_id + "') and (prefix<>'' or prefix  IS NOT NULL)");
            try
            {
                if (config.Rows[0]["DueDateDays"].ToString().Trim().ToUpper() == "-1")
                {
                    cbDueDate.Checked = false;
                }
                else
                {
                    cbDueDate.Checked = true;
                    nudDueDays.Value = Convert.ToInt32(config.Rows[0]["DueDateDays"]);
                }

                if ((config.Rows[0]["MOD"].ToString().Trim().ToUpper() == "MONTHOFDAYS") ||  (config.Rows[0]["MOD"].ToString().Trim() == "0"))
                {
                 lblMOD.Text = DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month).ToString();
                }
                
                else{
                    lblMOD.Text = config.Rows[0]["MOD"].ToString();

                }

                //if (config.Rows[0]["DueDateDays"].ToString().Trim().ToUpper() == "1")
                //{
                //    dgotherjob.Columns["OCQty"].HeaderText = "";
                //}
                //else
                //{
                //    dgotherjob.Columns["OCQty"].HeaderText = "";
                //}

                if (config.Rows[0]["isST"].ToString().Trim() == "1")
                {
                    checkBox1.Checked = true;

                    if (config.Rows[0]["isSTC"].ToString().Trim() == "1")
                    { rdbCharged.Checked = true; }
                    else { rdbChargeN.Checked = true; }

                }
                else
                {
                    checkBox1.Checked = false;
                    rdbChargeN.Checked = true;
                }
                if (config.Rows[0]["isSC"].ToString().Trim() == "1") { ChkServiceChaerge.Checked = true; TxtPer.Text = config.Rows[0]["scPer"].ToString().Trim(); } else { ChkServiceChaerge.Checked = false; TxtPer.Text = "0"; }

                try
                {
                    pref = clsDataAccess.GetresultS("Select prefix from  Companywiseid_Relation where (Company_ID='" + Company_id + "') and (Location_ID='" + location_id + "') and (prefix<>'' or prefix  IS NOT NULL)").Trim();
                }
                catch
                {
                    pref = "";
                }
                if (pref != "")
                {
                    string dsc = clsDataAccess.GetresultS("select desccode from typedoc where (ficode='0') and (gcode='0') and (ltrim(rtrim(t_entry))='9') and (session='') and (ltrim(rtrim(type_desc))='" + pref + "') and (coid='" + Company_id + "') and (locid='" + location_id + "') and (clid='" + Client_id + "')");
                    descode = Convert.ToInt32(dsc);

                    //change made by dwipraj dutta 23082017 following if block
                    if (cmbdescription.Text.Trim() == "")
                        txtVoucherChallan.Text = GetDocNo(descode, "9", "");

                    string sqlstmnt = "Select Order_Name,Order_Date,Location,Order_ID from tbl_Employee_OrderDetails  where (Co_Code='" + Company_id + "') and (Cliant_ID='" + Client_id + "') and (ltrim(rtrim(location))='" + cmbLocation.Text.Trim() + "')";

                    DataTable dt2 = clsDataAccess.RunQDTbl(sqlstmnt);
                    if (Convert.ToInt32(dt2.Rows.Count) == 1)
                    {
                        contract();
                    }
                    else if (Convert.ToInt32(dt2.Rows.Count) > 1)
                    {
                        button1_Click(sender, e);
                    }
                    else if (Convert.ToInt32(dt2.Rows.Count) == 0)
                    {
                        lblMsg.Text = "No Contact found for this location, Enter manual bill";
                    }
                    //button1_Click(sender, e);
                }
                else
                {
                    string sqlstmnt = "Select Order_Name,Order_Date,Location,Order_ID,enclosure from tbl_Employee_OrderDetails  where (Co_Code='" + Company_id + "') and (Cliant_ID='" + Client_id + "') and (ltrim(rtrim(location))='" + cmbLocation.Text.Trim() + "')";

                    DataTable dt2 = clsDataAccess.RunQDTbl(sqlstmnt);
                    if (Convert.ToInt32(dt2.Rows.Count) == 1)
                    {
                        contract();
                    }
                    else if (Convert.ToInt32(dt2.Rows.Count) > 1)
                    {
                        button1_Click(sender, e);
                    }
                    else if (Convert.ToInt32(dt2.Rows.Count) == 0)
                    {
                        lblMsg.Text = "No Contact found for this location, Enter manual bill";
                    }
                }

                if (config.Rows[0]["freeze"].ToString().Trim() == "1")
                {
                    ChkServiceChaerge.Visible = false;
                    checkBox1.Visible = false;
                    rdbCharged.Visible = false;
                    rdbChargeN.Visible = false;
                }
                else
                {
                    ChkServiceChaerge.Visible = true;
                    checkBox1.Visible = true;
                    rdbCharged.Visible = true;
                    rdbChargeN.Visible = true;
                }

                if (Convert.ToInt32(clsDataAccess.GetresultS("select count(*) from tbl_Payment_Register where (billNo='" + txtVoucherChallan.Text.Trim() + "') and (tblName='tbl_Payment_Receipt_Register')")) > 0)
                {
                    lblprevbal.Text = "0";

                }
                else
                {
                    lblprevbal.Text = (Convert.ToDouble(clsDataAccess.GetresultS("SELECT isNull(SUM(TotAMT + ServiceAmount + ScAmt),0) FROM paybill WHERE (Location_ID ='" + location_id + "') AND (BILLNO <> '" + txtVoucherChallan.Text.Trim() + "')")) - Convert.ToDouble(clsDataAccess.GetresultS("SELECT isNull(sum(ISNULL(amount,0)),0) from tbl_Payment_Receipt_Register WHERE (vchrNo IN (SELECT userVchNo FROM tbl_Payment_Register WHERE (LocationId ='" + location_id + "') AND (tblName = 'tbl_Payment_Receipt_Register')))"))).ToString("0.00");

                }

                if (lblprevbal.Text == "")
                {
                    lblprevbal.Text = "0";
                }
            }
            catch
            {
                EDPMessageBox.EDPMessage.Show("No Record Present,Configure in Company wise client page else select manually");
            }
/*--------------------------------------------------------------------[4:46PM]Changed By dwipraj dutta 25/07/2017--------------------------------------------------*/
            DataTable gstInfo = clsDataAccess.RunQDTbl("Select GSTTYPE from Companywiseid_Relation where (Company_ID=" + Company_id + ") and (Location_ID ='" + location_id + "')");
            string gstapplicable = gstInfo.Rows[0][0].ToString().Trim();
            DataTable dtGSTper = clsDataAccess.RunQDTbl("select GSTPER from Branch where GCODE = " + Company_id + "");
            string gstPercentage = "";
            if (dtGSTper.Rows.Count > 0)
            {
                gstPercentage = dtGSTper.Rows[0][0].ToString().Trim();
            }
            else
            {
                EDPMessageBox.EDPMessage.Show("No GST percentage has defined. Please close the form and try again after defining GST percentage.");
                return;
            }
            if (gstapplicable != "")
            {
                if (gstapplicable == "LOCAL")
                {
                    checkBox1.Text = "GST";
                    checkBox1.Checked = true;
                    label9.Text = "SGST%@";
                    txtSTPer.Text = (Convert.ToDouble(gstPercentage)/2).ToString();
                    label13.Visible = true;
                    cgstPer.Visible = true;
                    cgstPer.Text = (Convert.ToDouble(gstPercentage) / 2).ToString();
                }
                else if (gstapplicable == "INTERSTATE")
                {
                    checkBox1.Text = "GST"; checkBox1.Checked = true;
                    label9.Text = "IGST%@";
                    txtSTPer.Text = gstPercentage;
                    label13.Visible = false;
                    cgstPer.Visible = false;
                }
                else
                {
                    checkBox1.Checked = false;
                    txtSTPer.Text = "0";
                    cgstPer.Text = "0";
                    label13.Visible = false;
                    cgstPer.Visible = false;
                }
            }
            else
            {
                checkBox1.Text = "Service Tax";
                checkBox1.Checked = false;
                label9.Text = "Service Tax % @";
                //txtSTPer.Text = "14.5";
                label13.Visible = false;
                cgstPer.Visible = false;  
            }
/*---------------------------------------------------------------------------[4:46PM]ends here------------------------------------------------------------*/

            if (clsDataAccess.ReturnValue("select bill_doc_type from CompanyLimiter") == "3")
            {
                string docnumber = "";
                string[] dss = cmbdescription.Text.Split('/');
                string zone = clsDataAccess.ReturnValue("select zone from tbl_zone where zid=(select zid from tbl_Emp_Location where Location_ID='"+location_id+"')");
                string loc = cmbLocation.Text.Trim().Substring(0,3);
                string locID = Convert.ToDouble(cmbLocation.ReturnValue.Trim()).ToString("00");
                string cli = cmbclintname.Text.Trim().Substring(0, 3);
                string cliID = Convert.ToDouble(Client_id).ToString("00");
                string olocid = clsDataAccess.ReturnValue("SELECT olocid FROM Docgen_Zone where (accyr='" + cmbYear.Text + "') and (coid='" + Company_id + "') and (locid='" + location_id + "')");


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
                            if (olocid.Trim() == "")
                            {
                                lblDesc.Text = dss[0].Trim() + "/" + locID;
                            }
                            else
                            {
                                lblDesc.Text = dss[0].Trim() + "/" + olocid.Trim();
                            }
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
                            if (olocid.Trim() == "")
                            {
                                lblDesc.Text = dss[0].Trim() + "/" + locID;
                            }
                            else
                            {
                                lblDesc.Text = dss[0].Trim() + "/" + olocid.Trim();
                            }
                        }
                        else if (dss[2].ToString().Trim().ToLower() == "clientid")
                        {
                            lblDesc.Text = lblDesc.Text + "/" + cliID;
                        }
                    }
                    catch { lblDesc.Text = lblDesc.Text; }



                    DataTable dtDes=clsDataAccess.RunQDTbl("SELECT Descode, coid, locid, Type_Desc, Suffix, AccYr, DocNo,olocid FROM Docgen_Zone where (Type_Desc='"+lblDesc.Text.Trim()+"') and (accyr='"+cmbYear.Text+"') and (coid='"+Company_id+"') and (locid='"+location_id+"')");

                    
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

                    if (dtDes.Rows.Count>0)
                    {
                        docnumber = dtDes.Rows[0]["DocNo"].ToString(); //dt24.Rows[0][0].ToString();
                    }
                    else
                    {
                        docnumber="0";

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
            else
            {
                if (cinv > 0)
                {
                    cmbdescription.PopUp();
                }
            }

        
        }
        private void clientname()
        {
            try
            {
                DataTable dt = new DataTable();
                if (Client_id > 0)
                {
                    dt = clsDataAccess.RunQDTbl("SELECT Client_ID as Cliant_ID ,Client_Name as ClientName FROM tbl_Employee_CliantMaster WHERE (Client_id = '" + Client_id + "')");
                }
                else
                {
                    dt = clsDataAccess.RunQDTbl("SELECT Cliant_ID,(SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE (Client_id = el.Cliant_ID)) AS ClientName FROM tbl_Emp_Location AS el WHERE (Location_ID='" + location_id + "')");
                }
                Client_id =Convert.ToInt32( dt.Rows[0]["Cliant_ID"].ToString());
                cmbclintname.Text = dt.Rows[0]["ClientName"].ToString();
            }
            catch { }

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                rdbCharged.Enabled = true;
                rdbChargeN.Enabled = true;
            }
            else
            {

                rdbCharged.Enabled = false;
                rdbChargeN.Enabled = false;
            }
        }

        private void btnCLear_Click(object sender, EventArgs e)
        {
            groupBox2.Text = "Basic Charges";
            dateTimePicker1.Value = System.DateTime.Now.AddMonths(-1);
            dgemployjob.Rows.Clear();
            dgotherjob.Rows.Clear();
            cmbcompany.Text = "";
            cmbYear.Text = "";
            txtVoucherChallan.Text = "";
            cmbclintname.Text = "";
            cmbLocation.Text = "";
            //cmbdescription.Text = "";
            rdbCharged.Checked = true;
            checkBox1.Checked = false;
            txtVoucherChallan.ReadOnly = false;
            cmbcompany.ReadOnly = false;
            lblMsg.Text = "";
            cbDueDate.Checked = false;
            lblEnclosure.Text = ""; lblprevbal.Text = "0";
            btnSave.Text = "Save";
            if (descode > 0)
                txtVoucherChallan.Text = GetDocNumber(descode, "9", cmbYear.Text);

            comp_show();
            cmborderno.Text = "";
            Employ_ID = "";

            Client_id = 0;
            location_id = "0";
            DesgID = 0;
            comp_show();
            btnPreview.Enabled = false;
            btnPreview.Text = "...";
            dtpto.Value = DateTime.Now;//Convert.ToDateTime("01/" + clsEmployee.GetMonthName(dateTimePicker1.Value.AddMonths(1).Month) + "/" + dateTimePicker1.Value.Year);
            cbCancelBill.Checked = false;
            chkRound.Checked = true;

            switch (cmbBillType.SelectedIndex)
            {
                case 0:
                    label15.Visible = false;
                    cmbDesgName.Visible = false;

                    label12.Visible = true;
                    cmbLocation.Visible = true;
                    /*ChkServiceChaerge.Visible = true;
                    label11.Visible = true;
                    TxtPer.Visible = true;
                    sacSClbl.Visible = true;
                    sacServiceCharge.Visible = true;
                    checkBox1.Visible = true;
                    label9.Visible = true;
                    txtSTPer.Visible = true;
                    label13.Visible = false;
                    cgstPer.Visible = false;
                    rdbCharged.Visible = true;
                    rdbChargeN.Visible = true;
                    btnChange.Visible = true;
                    dgotherjob.Visible = true;*/
                    cmbLocation.Text = "Select Location to view contract";
                    cmbclintname.BackColor = Color.Gainsboro;
                    break;
                case 1:
                    label15.Visible = true;
                    cmbDesgName.Visible = true;
                    cmbDesgName.Text = "";

                    label12.Visible = false;
                    cmbLocation.Visible = false;
                    cmbLocation.Text = "";
                    cmbclintname.BackColor = Color.White;
                    /*ChkServiceChaerge.Visible = false;
                    label11.Visible = false;
                    TxtPer.Visible = false;
                    sacSClbl.Visible = false;
                    sacServiceCharge.Visible = false;
                    checkBox1.Visible = false;
                    label9.Visible = false;
                    txtSTPer.Visible = false;
                    label13.Visible = false;
                    cgstPer.Visible = false;
                    rdbCharged.Visible = false;
                    rdbChargeN.Visible = false;
                    btnChange.Visible = false;
                    dgotherjob.Visible = false;*/
                    break;
                case 2:
                    label15.Visible = false;
                    cmbDesgName.Visible = false;

                    label12.Visible = true;
                    cmbLocation.Visible = true;
                    /*ChkServiceChaerge.Visible = true;
                    label11.Visible = true;
                    TxtPer.Visible = true;
                    sacSClbl.Visible = true;
                    sacServiceCharge.Visible = true;
                    checkBox1.Visible = true;
                    label9.Visible = true;
                    txtSTPer.Visible = true;
                    label13.Visible = false;
                    cgstPer.Visible = false;
                    rdbCharged.Visible = true;
                    rdbChargeN.Visible = true;
                    btnChange.Visible = true;
                    dgotherjob.Visible = true;*/
                    cmbLocation.Text = "Select Location to view contract";
                    cmbclintname.BackColor = Color.Gainsboro;
                    break;

            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ChkServiceChaerge_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkServiceChaerge.Checked)
            {
                sacSClbl.Visible = true;
                sacServiceCharge.Visible = true;
            }
            else
            {
                sacSClbl.Visible = false;
                sacServiceCharge.Visible = false;
            }
        }

        private void cmbBillType_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (SacGst == 1)
            {
                cmbBillType.Items.Add("Sac wise Gst");
                cmbBillType.SelectedIndex = 2;

                dgemployjob.Columns["gst_per"].Visible = true;
                dgotherjob.Columns["gst_amt"].Visible = true;
            }
            else
            {
                dgemployjob.Columns["gst_per"].Visible = false;
                dgotherjob.Columns["gst_amt"].Visible = false;
                cmbBillType.SelectedIndex = 0;
            }*/
            btype = 0;
            switch (cmbBillType.SelectedIndex)
            { 
                case 0:
                    label15.Visible = false;
                    cmbDesgName.Visible = false;
                    cmbclintname.Enabled = false;
                    label12.Visible = true;
                    cmbLocation.Visible = true;
                    dgemployjob.Columns["gst_per"].Visible = false;
                    dgemployjob.Columns["gst_amt"].Visible = false;

                    dgotherjob.Columns["OC_gst_per"].Visible = false;
                    dgotherjob.Columns["OC_gst_amt"].Visible = false;
                    /*ChkServiceChaerge.Visible = true;
                    label11.Visible = true;
                    TxtPer.Visible = true;
                    sacSClbl.Visible = true;
                    sacServiceCharge.Visible = true;
                    checkBox1.Visible = true;
                    label9.Visible = true;
                    txtSTPer.Visible = true;
                    label13.Visible = false;
                    cgstPer.Visible = false;
                    rdbCharged.Visible = true;
                    rdbChargeN.Visible = true;
                    btnChange.Visible = true;
                    dgotherjob.Visible = true;*/
                    btnCLear_Click(sender, e);
                    //SendMessage(cmbclintname.Handle, EM_SETCUEBANNER, 0, "Client is disabled");
                    cmbclintname.BackColor = Color.Gainsboro;
                    cmbclintname.Text = "";
                    //SendMessage(cmbLocation.Handle, EM_SETCUEBANNER, 0, "Select Location to view contract");
                    cmbLocation.Text = "Select Location to view contract";
                    break;
                case 1:
                    if (!boolSingleDesignationBillingPermission)
                    {
                        cmbBillType.SelectedIndex = 0;
                        EDPMessageBox.EDPMessage.Show("Single Designation Bill Printing feature is not supported in your version right now." + Environment.NewLine + "Please contact support@edpsoft.com or" + Environment.NewLine + "Call : 033-40003855");
                        return;
                    }
                    label15.Visible = true;
                    cmbDesgName.Visible = true;
                    cmbclintname.Enabled = true;
                    label12.Visible = false;
                    cmbLocation.Visible = false;
                    dgemployjob.Columns["gst_per"].Visible = false;
                    dgemployjob.Columns["gst_amt"].Visible = false;

                    dgotherjob.Columns["OC_gst_per"].Visible = false;
                    dgotherjob.Columns["OC_gst_amt"].Visible = false;
                    btnCLear_Click(sender, e);

                    /*ChkServiceChaerge.Visible = false;
                    label11.Visible = false;
                    TxtPer.Visible = false;
                    sacSClbl.Visible = false;
                    sacServiceCharge.Visible = false;
                    checkBox1.Visible = false;
                    label9.Visible = false;
                    txtSTPer.Visible = false;
                    label13.Visible = false;
                    cgstPer.Visible = false;
                    rdbCharged.Visible = false;
                    rdbChargeN.Visible = false;
                    btnChange.Visible = false;
                    dgotherjob.Visible = false;*/
                    //SendMessage(cmbclintname.Handle, EM_SETCUEBANNER, 0, "Select Client");
                    cmbclintname.Text = "Select Client";
                    cmbclintname.BackColor = Color.White;
                    //SendMessage(cmbLocation.Handle, EM_SETCUEBANNER, 0, "Select Designation to view heads");
                    cmbDesgName.Text = "Select Designation to view heads";
                    break;

                case 2:
                    label15.Visible = false;
                    cmbDesgName.Visible = false;
                    cmbclintname.Enabled = false;
                    label12.Visible = true;
                    cmbLocation.Visible = true;
                    dgemployjob.Columns["gst_per"].Visible = true;
                    dgemployjob.Columns["gst_amt"].Visible = true;
                    btype = 1;
                    dgotherjob.Columns["OC_gst_per"].Visible = true;
                    dgotherjob.Columns["OC_gst_amt"].Visible = true;
                    /*ChkServiceChaerge.Visible = true;
                    label11.Visible = true;
                    TxtPer.Visible = true;
                    sacSClbl.Visible = true;
                    sacServiceCharge.Visible = true;
                    checkBox1.Visible = true;
                    label9.Visible = true;
                    txtSTPer.Visible = true;
                    label13.Visible = false;
                    cgstPer.Visible = false;
                    rdbCharged.Visible = true;
                    rdbChargeN.Visible = true;
                    btnChange.Visible = true;
                    dgotherjob.Visible = true;*/
                    btnCLear_Click(sender, e);
                    //SendMessage(cmbclintname.Handle, EM_SETCUEBANNER, 0, "Client is disabled");
                    cmbclintname.BackColor = Color.Gainsboro;
                    cmbclintname.Text = "";
                    //SendMessage(cmbLocation.Handle, EM_SETCUEBANNER, 0, "Select Location to view contract");
                    cmbLocation.Text = "Select Location to view contract";
                    break;
            
            }
        }

        private void cmbDesgName_DropDown(object sender, EventArgs e)
        {
            DataTable dtDesignationDrpDwn = clsDataAccess.RunQDTbl("select [DesignationName],[SlNo] from [tbl_Employee_DesignationMaster]");
            if (dtDesignationDrpDwn.Rows.Count > 0)
            {
                cmbDesgName.LookUpTable = dtDesignationDrpDwn;
                cmbDesgName.ReturnIndex = 1;
            }
        }

        private void cmbDesgName_CloseUp(object sender, ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbDesgName.ReturnValue))
            {
                DesgID = Convert.ToInt32(cmbDesgName.ReturnValue);
            }

            switch (cmbBillType.SelectedIndex)
            {
                case 1:
                    string strsql = "select [DesignationName] from [tbl_Employee_DesignationMaster] where SlNo = "+ DesgID;// clsEmployee.GetClintID(cmbclintname.Text) + "";
                    DataTable dt2 = clsDataAccess.RunQDTbl(strsql);
                    DataGridViewComboBoxColumn dgcombo4 = dgemployjob.Columns["Designation"] as DataGridViewComboBoxColumn;
                    dgcombo4.Items.Clear();
                    for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        string st = Convert.ToString(dt2.Rows[i]["DesignationName"]);
                        dgcombo4.Items.Add(st);
                    }
                    dgcombo4.ValueMember=cmbDesgName.Text.Trim();
                    location_id = "";
                    dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID  from tbl_Emp_Location where (Cliant_ID='" + Client_id + "')  order by Location_Name");
                    if (dt.Rows.Count > 0)
                    {
                        for (int idx = 0; idx < dt.Rows.Count; idx++)
                        {
                            if (location_id == "")
                            {
                                location_id = "'"+dt.Rows[idx]["Location_ID"].ToString()+"'";
                            }
                            else
                            {
                                location_id = location_id+",'" + dt.Rows[idx]["Location_ID"].ToString() + "'";
                            }
                        }
                    }
                    /*--------------------------------------------------------------------[4:46PM]Changed By dwipraj dutta 25/07/2017--------------------------------------------------*/
                    DataTable gstInfo = clsDataAccess.RunQDTbl("Select distinct GSTTYPE from Companywiseid_Relation where (Company_ID=" + Company_id + ") and (Location_ID in (" + location_id + "))");
                    string gstapplicable = gstInfo.Rows[0][0].ToString().Trim();
                    DataTable dtGSTper = clsDataAccess.RunQDTbl("select distinct GSTPER from Branch where GCODE = " + Company_id + "");
                    string gstPercentage = "";
                    if (dtGSTper.Rows.Count > 0)
                    {
                        gstPercentage = dtGSTper.Rows[0][0].ToString().Trim();
                    }
                    else
                    {
                        EDPMessageBox.EDPMessage.Show("No GST percentage has defined. Please close the form and try again after defining GST percentage.");
                        return;
                    }
                    if (gstapplicable != "")
                    {
                        if (gstapplicable == "LOCAL")
                        {
                            checkBox1.Text = "GST";
                            checkBox1.Checked = true;
                            label9.Text = "SGST%@";
                            txtSTPer.Text = (Convert.ToDouble(gstPercentage) / 2).ToString();
                            label13.Visible = true;
                            cgstPer.Visible = true;
                            cgstPer.Text = (Convert.ToDouble(gstPercentage) / 2).ToString();
                        }
                        else
                        {
                            checkBox1.Text = "GST"; checkBox1.Checked = true;
                            label9.Text = "IGST%@";
                            txtSTPer.Text = gstPercentage;
                            label13.Visible = false;
                            cgstPer.Visible = false;
                        }
                    }
                    else
                    {
                        checkBox1.Text = "Service Tax";
                        checkBox1.Checked = false;
                        label9.Text = "Service Tax % @";
                        //txtSTPer.Text = "14.5";
                        label13.Visible = false;
                        cgstPer.Visible = false;
                    }
                    /*---------------------------------------------------------------------------[4:46PM]ends here------------------------------------------------------------*/
     
                    break;
            }
        }


        public int NoOfWorkingDays(DateTime dtpBillMon)
        {
            int count = 0;
            int Days = DateTime.DaysInMonth(dtpBillMon.Year, dtpBillMon.Month);
            for (int i = 0; i < Days; i++)
            {
                DateTime dt = new DateTime(dtpBillMon.Year, dtpBillMon.Month, i + 1);
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    count++;
                }
            }
            return (Days-count);
        }

        public int NoOfWorkingDays(DateTime dtpBillMon,int fromDate, int toDate)
        {
            int count = 0;
            int DaysInPreviousMonth = DateTime.DaysInMonth(dtpBillMon.Year, (dtpBillMon.AddMonths(-1).Month));
            count = (DaysInPreviousMonth-fromDate+1) + toDate;
            return (count);
        }

        private void cbDueDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDueDate.Checked)
            {
                dtpDueDate.Visible = true;
                nudDueDays.Visible = true;
            }
            else
            {
                dtpDueDate.Visible = false;
                nudDueDays.Visible = false;
            }
        }

        private void nudDueDays_ValueChanged(object sender, EventArgs e)
        {
            dtpDueDate.ValueChanged -= dtpDueDate_ValueChanged;
            dtpDueDate.Value = dtpto.Value.AddDays((double)nudDueDays.Value);
            dtpDueDate.ValueChanged += dtpDueDate_ValueChanged;
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
            nudDueDays.ValueChanged -= nudDueDays_ValueChanged;
            TimeSpan days = dtpDueDate.Value - dtpto.Value;
            nudDueDays.Value = Convert.ToInt32(days.Days);
            nudDueDays.ValueChanged += nudDueDays_ValueChanged;
        }

        private void dtpto_ValueChanged(object sender, EventArgs e)
        {
            dtpDueDate.MinDate = dtpto.Value;
        }

        private void TxtPer_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgemployjob_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (dgemployjob.CurrentCell.ColumnIndex == dgemployjob.Columns["Attendance"].Index || 
                dgemployjob.CurrentCell.ColumnIndex == dgemployjob.Columns["Rate"].Index 
                || dgemployjob.CurrentCell.ColumnIndex == dgemployjob.Columns["Amount"].Index 
                || dgemployjob.CurrentCell.ColumnIndex == dgemployjob.Columns["Personnel"].Index) //Desired Column
            {
                try
                {
                    e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                }
                catch { }
            }
        }
        // this code section prevents from entering text value in cells of datagridview
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar)
     && !char.IsDigit(e.KeyChar)
     && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '+')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Control2_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = false;
        }

        private void dgotherjob_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgotherjob.CurrentCell.ColumnIndex == dgotherjob.Columns["OCQty"].Index
                || dgotherjob.CurrentCell.ColumnIndex == dgotherjob.Columns["OCAttend"].Index
                || dgotherjob.CurrentCell.ColumnIndex == dgotherjob.Columns["OCRate"].Index
                || dgotherjob.CurrentCell.ColumnIndex == dgotherjob.Columns["OCAmt"].Index) //Desired Column
            {
                try
                {
                    e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                }
                catch { }
            }
            else
            {
                try
                {
                    e.Control.KeyPress += new KeyPressEventHandler(Control2_KeyPress);
                }
                catch { }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (!cbCancelBill.Checked)
            {
                frmEmployeeBillReportO soe = new frmEmployeeBillReportO("Q");
                soe.vl = 2;
                soe.Company_id = Company_id;
                soe.comboBox1.SelectedIndex = 0;
                soe.client_id = Client_id.ToString();
                if (cmbBillType.SelectedIndex == 1)
                {
                    soe.Location_id = 0;
                }
                else
                {
                    soe.Location_id = Convert.ToInt32(location_id);
                }
                soe.cmbcompany.Text = cmbcompany.Text.Trim();
                soe.cmbLocation.Text = cmbLocation.Text;
                soe.Item_Code = "'" + txtVoucherChallan.Text + "'";
                soe.lblprepby.Text = edpcom.UserDesc + Environment.NewLine + btnSave.Text;
                clsValidation.GenerateYear(soe.cmbYear, 2014, System.DateTime.Now.Year, 1);
                //soe.dateTimePicker1.Text = dateTimePicker1.Text;
                soe.dateTimePicker1.Value = dateTimePicker1.Value;
                soe.dateTimePicker1.Text = dateTimePicker1.Text;
                
                soe.lblNote.Text = lblNote.Text;
                soe.lblEnclosure.Text = lblEnclosure.Text;
                soe.lblprevbal.Text = lblprevbal.Text;
                soe.chkBank.Checked = true;
                soe.vSes = cmbYear.Text;
                soe.cmbYear.Text = cmbYear.Text;
                soe.ShowDialog();
                //chkAuthorise.Checked = false;
                //btnSave.Text = "Save";
            }
        }

        private void menu_reCalc_Click(object sender, EventArgs e)
        {
            double bsc = 0, bs = 0;
            int ind = 0;
            string searchValue = "", arrayItem="";
            int rowIndex = -1;

            for (int indx = 0; indx < dgemployjob.Rows.Count; indx++)
            {
                if (arrayItem.Trim() == "")
                {
                    arrayItem = "'" + dgemployjob.Rows[indx].Cells["OrderNo"].Value + "'";
                }
                else
                {
                    arrayItem =arrayItem +",'" + dgemployjob.Rows[indx].Cells["OrderNo"].Value + "'";
                }
                bsc = bsc + Convert.ToDouble(dgemployjob.Rows[indx].Cells["Amount"].Value);
            }

            DataTable dt_bs_head = clsDataAccess.RunQDTbl("SELECT C_DET,atten_day,Daily_wages FROM tbl_Employee_Assign_SalStructure WHERE (SAL_HEAD=(SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short='BS'))) AND (Location_id = '" + location_id + "') AND (Company_id = '" + Company_id + "') AND (P_TYPE = 'E')");
            if (dt_bs_head.Rows.Count > 0)
            {
                DataTable dt_bs = clsDataAccess.RunQDTbl("SELECT LUMPNAME,GRADE,AMOUNT FROM tbl_Employee_Lumpsum WHERE (LUMPID ='" + dt_bs_head.Rows[0]["C_DET"].ToString() + "')");
                while (ind < dt_bs.Rows.Count)
                {
                    if (dt_bs_head.Rows[0]["Daily_wages"].ToString() == "1")
                    {
                        bs = bs + Convert.ToInt32(Convert.ToDouble(dt_bs.Rows[ind]["AMOUNT"]) * Convert.ToDouble(lblMOD.Text));
                    }
                    else
                    {
                        bs = bs + Convert.ToDouble(dt_bs.Rows[ind]["AMOUNT"]);
                    }
                    ind = ind + 1;
                }
            }
            Label lb = new Label();
            Label lb1 = new Label();
            Label lb2 = new Label();
            Label lb3 = new Label();
            lb.Text = "BS";
            lbe[0] = lb;
            lb1.Text = bs.ToString();
            lbH[0] = lb1;

            lb2.Text = "BSC";
            lbe[1] = lb2;
            lb3.Text = bsc.ToString();
            lbH[1] = lb3;

             //htext
                        htSalHead.Clear();
                        string qrySalDet = "SELECT (case sd.TableName when 'tbl_Employee_ErnSalaryHead' then (select eh.SalaryHead_Short from tbl_Employee_ErnSalaryHead eh where eh.SlNo = sd.SalId) "+
		                                    "when 'tbl_Employee_DeductionSalayHead' then (select eh.SalaryHead_Short from tbl_Employee_DeductionSalayHead eh where eh.SlNo = sd.SalId) "+
		                                    "end) as 'SalID'"+
                                            ",sum([Amount]) as 'Amt' "+
                                            "FROM [tbl_Employee_SalaryDetails] sd "+
                                            "where Session = '" + cmbYear.Text + "' and Location_id = '" + location_id + "' and Company_id = '" + Company_id + "' and Month = '" + dateTimePicker1.Text.Substring(0, dateTimePicker1.Text.IndexOf('-') - 1) + "'  and (TableName = 'tbl_Employee_ErnSalaryHead' or TableName = 'tbl_Employee_DeductionSalayHead')" +
                                            "group by SalId,TableName";
                        DataTable dtSalDet = clsDataAccess.RunQDTbl(qrySalDet);
                        if (dtSalDet.Rows.Count > 0)
                        {
                            bTagging = true;
                            for (int i = 0; i < dtSalDet.Rows.Count; i++)
                            {
                                htSalHead.Add(dtSalDet.Rows[i]["SalID"].ToString(), dtSalDet.Rows[i]["Amt"].ToString());                                
                            }
                        }
                        else
                        {
                            bTagging = false;
                        }
                        DataTable dtdtl1 = clsDataAccess.RunQDTbl("select Fid,Fname,position,basis,Fexpr,fper,vnote,htext,tagging FROM tbl_order_FB_detail where Fname in (" + arrayItem.ToString().Trim() + ") order by position");
                        ind = 0;
                        for (int y = 0; y <= dtdtl1.Rows.Count - 1; y++)
                        {
                            if (dtdtl1.Rows[y]["htext"].ToString().ToLower() != "note")
                            {

                                if (dtdtl1.Rows[y]["basis"].ToString().ToLower() == "formula")
                                {
                                    /*dgotherjob.Rows[ind].Cells["OCDesc"].Value = dtdtl1.Rows[y]["vnote"].ToString();
                                    dgotherjob.Rows[ind].Cells["OCAmt"].Value = formula(dtdtl1.Rows[y]["Fexpr"].ToString());*/


                                    if (dtdtl1.Rows[y]["tagging"].ToString() == "1")
                                    {
                                        rowIndex = -1;
                                        searchValue = dtdtl1.Rows[y]["vnote"].ToString();

                                        dgotherjob.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                        try
                                        {
                                            foreach (DataGridViewRow row in dgotherjob.Rows)
                                            {
                                                if (row.Cells["OCDesc"].Value.ToString().Equals(searchValue))
                                                {
                                                    rowIndex = row.Index;
                                                    dgotherjob.CurrentCell = dgotherjob.Rows[rowIndex].Cells[1];
                                                    dgotherjob.Rows[dgotherjob.CurrentCell.RowIndex].Selected = true;

                                                    break;
                                                }
                                            }
                                        }
                                        catch (Exception exc)
                                        {
                                            MessageBox.Show(exc.Message);
                                        }


                                        dgotherjob.Rows[rowIndex].Cells["OCAmt"].Value = formula(dtdtl1.Rows[y]["Fexpr"].ToString());
                                    }
                                    else if (dtdtl1.Rows[y]["tagging"].ToString() == "2")
                                    {
                                        if (!bTagging && !boolSalAllotmentNotFound)
                                        {
                                            boolSalAllotmentNotFound = true;
                                        }
                                        if (bTagging)
                                        {
                                            rowIndex = -1;
                                            searchValue = dtdtl1.Rows[y]["vnote"].ToString();

                                            dgotherjob.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                            try
                                            {
                                                foreach (DataGridViewRow row in dgotherjob.Rows)
                                                {
                                                    if (row.Cells["OCDesc"].Value.ToString().Equals(searchValue))
                                                    {
                                                        rowIndex = row.Index;
                                                        //dgotherjob.CurrentCell = dgotherjob.Rows[rowIndex].Cells[0];
                                                        dgotherjob.Rows[dgotherjob.CurrentCell.RowIndex].Selected = true;

                                                        break;
                                                    }
                                                }
                                            }
                                            catch (Exception exc)
                                            {
                                                MessageBox.Show(exc.Message);
                                            }


                                            //dgotherjob.Rows[ind].Cells["OCDesc"].Value = dtdtl1.Rows[y]["vnote"].ToString();
                                            dgotherjob.Rows[rowIndex].Cells["OCAmt"].Value = formula_sal(dtdtl1.Rows[y]["Fexpr"].ToString());
                                        }
                                    }
                                }
                            }
                        }




           
           
            
        }
        /*

        private void Retrive_DataESI()
        {

            //string Str_ErHead_basic = "";
            //DataTable ErHead_basic = clsDataAccess.RunQDTbl("select top 1  SalaryHead_Short from tbl_Employee_ErnSalaryHead");
            //Str_ErHead_basic = ErHead_basic.Rows[0][0].ToString();
            string[] blno = Item_Code.Split(',');
            string strssql = "";
            string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
            DataTable tot_employ = new DataTable("");
            DataTable tot_employ_main = new DataTable("");
            foreach (string billcode in blno)
            {
                if (billcode.Trim() != "''")
                {
                    strssql = "";
                    strssql = strssql + " select h.BILLNO,CONVERT(VARCHAR(10),h.BILLDATE,103) as BILLDATE,(select c.co_name from Company c where c.CO_CODE=h.Comany_id ) as 'coname',";
                    strssql = strssql + " (select c.CO_ADD  from Company c where c.CO_CODE=h.Comany_id ) as 'Add1',(select distinct BRNCH_TELE1 from Branch B where B.GCODE=h.Comany_id ) as 'Add2',";
                    strssql = strssql + " (select Location_Name from tbl_Emp_Location where Location_ID=d.Location_ID ) as 'locname',h.Month,h.Session,h.TotAMT ,h.IsService,h.ServiceAmount,";
                    strssql = strssql + " d.Attendance ,d.BILLAMT,d.Dtl_id ,d.Hour,d.MonthDays,d.RATE,(select e.DesignationName  from tbl_Employee_DesignationMaster e where e.SlNo=d.desig_ID )as 'designation'";
                    strssql = strssql + "  ,(select c.Client_Name  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) ) as 'ClientName'";
                    strssql = strssql + " ,(select c.Client_City  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) )  as 'ClientCity'";
                    strssql = strssql + " ,(select c.Contract_Person   from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) ) as 'Contract_Person'";

                    strssql = strssql + " ,(select c.Contract_No  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) ) as 'Contract_No'";
                    strssql = strssql + " ,(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) )) AS mis1,";
                    strssql = strssql + " (select c.Client_ADD1  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=d.Location_ID ) ) AS mis2,";
                    strssql = strssql + " '' AS mis3,'' AS mis4,'' AS mis5,'' AS mis6,'' AS mis7,'' AS mis8,'' AS mis9,'' AS mis10,(SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "') as Cmpimage";

                    strssql = strssql + " from paybill h inner join paybillD d on h.BILLNO=d.BILLNO";
                    strssql = strssql + " where h.Session='" + cmbYear.Text + "' and d.Month ='" + month + "'";
                    strssql = strssql + " and d.Location_id = '" + Location_id + "' and h.Comany_id='" + Company_id + "'";

                    if (checkBox1.Checked == false)
                    {
                        strssql = strssql + " and h.BILLNO in (" + billcode + ") ";
                    }

                    tot_employ = clsDataAccess.RunQDTbl(strssql);
                    //  DataRow destRow= new DataRow();
                    DataTable dtimage = clsDataAccess.RunQDTbl("SELECT distinct Cmpimage FROM Branch where GCode='" + Company_id + "' ");
                    DataTable Ord = clsDataAccess.RunQDTbl("Select OCHARGES,OAMT,BILLNO from paybillO where BILLNO in (" + billcode + ") ");
                    for (int rw_ord = 0; rw_ord < Ord.Rows.Count; rw_ord++)
                    {
                        DataRow destRow = tot_employ.NewRow();

                        destRow[0] = tot_employ.Rows[0][0];
                        destRow[1] = tot_employ.Rows[0][1];
                        destRow[2] = tot_employ.Rows[0][2];
                        destRow[3] = tot_employ.Rows[0][3];
                        destRow[4] = tot_employ.Rows[0][4];
                        destRow[5] = tot_employ.Rows[0][5];
                        destRow[6] = tot_employ.Rows[0][6];
                        destRow[7] = tot_employ.Rows[0][7];
                        destRow[8] = tot_employ.Rows[0][8];
                        destRow["designation"] = Ord.Rows[rw_ord]["OCHARGES"];
                        destRow[9] = tot_employ.Rows[0][9];
                        destRow[10] = tot_employ.Rows[0][10];
                        destRow[11] = "";//tot_employ.Rows[0][11];
                        destRow["BILLAMT"] = Ord.Rows[rw_ord]["OAMT"];
                        destRow[13] = tot_employ.Rows[0][13];
                        destRow[14] = tot_employ.Rows[0][14];
                        destRow[15] = tot_employ.Rows[0][15];
                        destRow[16] = "0";//tot_employ.Rows[0][16];
                        //destRow[17] = tot_employ.Rows[0][17];
                        destRow[18] = tot_employ.Rows[0][18];
                        destRow[19] = tot_employ.Rows[0][19];
                        destRow[20] = tot_employ.Rows[0][20];
                        destRow[21] = tot_employ.Rows[0][21];
                        destRow[22] = tot_employ.Rows[0][22];
                        destRow[23] = tot_employ.Rows[0][23];
                        destRow[24] = tot_employ.Rows[0][24];
                        destRow[25] = tot_employ.Rows[0][25];
                        destRow[26] = tot_employ.Rows[0][26];
                        destRow[27] = tot_employ.Rows[0][27];
                        destRow[28] = tot_employ.Rows[0][28];
                        destRow[29] = tot_employ.Rows[0][29];
                        destRow[30] = tot_employ.Rows[0][30];
                        destRow[31] = tot_employ.Rows[0][31];
                        destRow[32] = tot_employ.Rows[0][32];


                        tot_employ.Rows.Add(destRow);

                    }
                    tot_employ_main.Merge(tot_employ);


                }
            }
            ds.Tables.Add(tot_employ_main);
            ds.Tables[0].TableName = "paybill";
         


        }
 

        */

    }
}
