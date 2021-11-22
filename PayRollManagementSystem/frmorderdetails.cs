using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using Edpcom;
using System.Collections;

namespace PayRollManagementSystem
{
    public partial class frmorderdetails : Form//EDPComponent.FormBaseERP
    {
        string co_code = "", Locid="",CompID="",ClientID="";
        Boolean boolSingleDesignationBillingPermission = false;
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        public frmorderdetails()
        {
            InitializeComponent();
        }

        public void getcode(string code, string p_type)
        {
            co_code = code;
            //Type = p_type;
        }
        public string get_ODNo()
        {
            try
            {
                Int32 odno = 0;
                DataTable dt2 = clsDataAccess.RunQDTbl("Select isNull(MAX(SUBSTRING(Order_Name,5,4)),0)+1 from tbl_Employee_OrderDetails");
                //Select count(*)+1 from tbl_Employee_OrderDetails");// where OrderDate='"+ dtporderdate.Text +"'");
                if (dt2.Rows.Count > 0)
                {
                    odno = Convert.ToInt32(dt2.Rows[0][0]);
                }
                else
                {
                    odno = 1;
                }

                return "ODR-" + odno.ToString("0000") + "-" + dtporderdate.Value.Year;
            }
            catch { return ""; }
        }

        private void frmorderdetails_Load(object sender, EventArgs e)
        {
           // this.HeaderText = "Order Details";

            btnSave.Text = "Save";
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
                                if (str.ToUpper() == "CLIENT_CONTRACT_ORDER_LIMITER")
                                    chk_str = 1;
                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                if (StrLine_WACC[0].ToUpper() == "SAVE_AND_GOTO_ADDITIONAL_DETAILS_VISIBILITY")
                                    boolSingleDesignationBillingPermission = true;
                                chk_str = 0;
                            }
                        }
                    }

                }
                catch
                { }
            }
            btnSave2.Visible = boolSingleDesignationBillingPermission;


            DataTable dt2 = clsDataAccess.RunQDTbl("select DesignationName from tbl_Employee_DesignationMaster ");
            DataGridViewComboBoxColumn dgcombo3 = dgemployjob.Columns["Designation"] as DataGridViewComboBoxColumn;

            dgcombo3.Items.Clear();
            for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dt2.Rows[i]["DesignationName"]);
                dgcombo3.Items.Add(st);
            }

            //change made by dwipraj dutta in order to add sac no in billing in each row 18082017
            DataTable dtSAC = clsDataAccess.RunQDTbl("select serviceName+':'+sacNo as 'SACNo' from CompanySACMaster");
            DataGridViewComboBoxColumn dgcomboSAC = dgemployjob.Columns["sacno"] as DataGridViewComboBoxColumn;

            dgcomboSAC.Items.Clear();
            dgcomboSAC.Items.Add("");

            for (int i = 0; i <= dtSAC.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dtSAC.Rows[i]["SACNo"]);
                dgcomboSAC.Items.Add(st);
            }
            //foreach (DataGridViewComboBoxColumn itm in this.dgemployjob.Columns["sacno"])
            { 
            
            }

            DataTable dtH = clsDataAccess.RunQDTbl("select Hour_Name from HourMaster ORDER BY CAST(Hour_Name AS int)");
            DataGridViewComboBoxColumn dgcombo4 = dgemployjob.Columns["Hour"] as DataGridViewComboBoxColumn;

            dgcombo4.Items.Clear();
            for (int i = 0; i <= dtH.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dtH.Rows[i]["Hour_Name"]);
                dgcombo4.Items.Add(st);
            }

            DataTable dtM = clsDataAccess.RunQDTbl("select MONTH_Name from MonthOfDays ");
            DataGridViewComboBoxColumn dgcombo5 = dgemployjob.Columns["MontOfDays"] as DataGridViewComboBoxColumn;

            dgcombo5.Items.Clear();
            for (int i = 0; i <= dtM.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dtM.Rows[i]["MONTH_Name"]);
                dgcombo5.Items.Add(st);
            }

            cmborderno.Text = get_ODNo();


            //chkEnclosure.Items.Clear();
            chkEnclosureId.Items.Clear();
            DataTable encl = clsDataAccess.RunQDTbl("select enclosure,eid from tbl_enclosure");
            chkEnclosure.DataSource = encl;
            chkEnclosure.DisplayMember = "enclosure";
            chkEnclosure.ValueMember = "eid";
            //for (int i = 0; i < encl.Rows.Count; i++)
            //{
            //    string st = Convert.ToString(encl.Rows[i]["enclosure"]);
            //    chkEnclosure.Items.Add(encl.Rows[i]["enclosure"]);
            //    chkEnclosureId.Items.Add(encl.Rows[i]["eid"]);
            //}
            cmbcompanyname.PopUp();
        }

        private void cmbcompanyname_DropDown(object sender, EventArgs e)
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
            if (dt.Rows.Count > 1)
            {
                cmbcompanyname.LookUpTable = dt;
                cmbcompanyname.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                cmbcompanyname.ReturnValue = dt.Rows[0]["CO_CODE"].ToString();
                cmbcompanyname.Text = dt.Rows[0]["CO_NAME"].ToString();
                CompID = cmbcompanyname.ReturnValue.ToString();
                
            }
        }

        private void cmbclintname_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (edpcom.CurrentLocation.Trim() != "")
            {
                dt = clsDataAccess.RunQDTbl("select distinct (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as Client_Name,(SELECT Contract_Person FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) as Contract_Person,Cliant_ID as Client_id from tbl_Emp_Location EL where Location_ID in (select Location_ID from Companywiseid_Relation cr where (Company_ID='" + CompID + "') and  Location_ID in (" + edpcom.CurrentLocation + ") ) ");
            }
            else
            {
                clsDataAccess.RunQDTbl("select Client_Name,Contract_Person,Client_id from tbl_Employee_CliantMaster");
            }
            if (dt.Rows.Count > 0)
            {
                cmbclintname.LookUpTable = dt;
                cmbclintname.ReturnIndex = 2;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtCompanyChk = clsDataAccess.RunQDTbl("select * from Company where [CO_NAME] = '"+cmbcompanyname.Text+"'");
            DataTable dtClientChk = clsDataAccess.RunQDTbl("select * from [tbl_Employee_CliantMaster] where [Client_Name] = '"+cmbclintname.Text+"'");
            DataTable dtLocationChk = clsDataAccess.RunQDTbl("select * from [tbl_Emp_Location] where [Location_Name] = '"+cmblocation.Text+"'");
            if (dtCompanyChk.Rows.Count > 0 && dtClientChk.Rows.Count > 0 && dtLocationChk.Rows.Count > 0)
            {
                if (SubmitDetails())
                {
                    if (chkAc.Checked == true)
                    {
                        frmOrderDetails_AD foad = new frmOrderDetails_AD();
                        foad.lblClid.Text = ClientID.ToString();
                        foad.lblCoid.Text = CompID.ToString();
                        foad.lbllocid.Text = Locid.ToString();


                        foad.lblLocation.Text = cmblocation.Text;
                        foad.lblClient.Text = cmbclintname.Text;
                        foad.lblContractNo.Text = cmborderno.Text;
                        // foad.lblContractID.Text=



                        foad.ShowDialog();


                    }

                    ERPMessageBox.ERPMessage.Show("Order No. Saved Successfully");
                    cmborderno.ReadOnly = false;
                    clearall();
                    cmborderno.Text = get_ODNo();
                    

                    //this.Close();
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Failed To Submit Order No.");
                }
            }
            else
            {
                EDPMessageBox.EDPMessage.Show("Company name or Client name or Location name is not matching.");
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete","BRAVO",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            { 
                 if (chkDelete() == true)
                 {
                    if (DeleteDetails())
                    {
                        ERPMessageBox.ERPMessage.Show("Order No." + cmborderno.Text + " Deleted Successfully");
                        this.Close();
                    }
                 }
                 else
                 {
                      ERPMessageBox.ERPMessage.Show("Bills present on current Order");
                 }
            }

        }

        private void GetDetails()
        {
            if (co_code.ToString().Trim() !="")
            {
                DataTable dt = clsDataAccess.RunQDTbl("Select Co_Code,Cliant_ID,Order_Name,Order_Date,FromDate,ToDate,Contract_Person,PnoneNo,Location,ManPower,Order_Remarks,Cliant_OrderNo,MONTH_CODE,Hour_CODE,refno,status,enclosure,Locid from tbl_Employee_OrderDetails where (Order_Name = '" + co_code + "')");
                if (dt.Rows.Count > 0)
                {
                    btnSave.Text = "Modify";
                    cmborderno.Text = Convert.ToString(dt.Rows[0]["Order_Name"]);
                    dtporderdate.Text = Convert.ToString(dt.Rows[0]["Order_Date"]);
                    dtpstartdate.Text = Convert.ToString(dt.Rows[0]["FromDate"]);
                    dtpenddate.Text = Convert.ToString(dt.Rows[0]["ToDate"]);
                    txtcontractperson.Text = Convert.ToString(dt.Rows[0]["Contract_Person"]);
                    txtphoneno.Text = Convert.ToString(dt.Rows[0]["PnoneNo"]);
                    cmblocation.Text = Convert.ToString(dt.Rows[0]["Location"]);
                    //txtmanpower.Text = Convert.ToString(dt.Rows[0]["ManPower"]);
                    txtremarks.Text = Convert.ToString(dt.Rows[0]["Order_Remarks"]);
                    txtclintorder.Text = Convert.ToString(dt.Rows[0]["Cliant_OrderNo"]);
                    txtReff.Text = Convert.ToString(dt.Rows[0]["refno"]);
                    if (dt.Rows[0]["status"].ToString().Trim() == "1")
                    {
                        chkAuthorise.Checked = true;
                    }
                    else if (dt.Rows[0]["status"].ToString().Trim() == "0")
                    {
                        chkAuthorise.Checked = false;
                    }

                    string[] encid = Convert.ToString(dt.Rows[0]["enclosure"]).Split('|');
                    try
                    {
                        for (int ind = 0; ind < encid.Length; ind++)
                        {
                            chkEnclosure.SelectedValue = encid[ind].ToString();

                            chkEnclosure.SetItemChecked(chkEnclosure.SelectedIndex, true);

                        }
                    }
                    catch { }
                        if (Information.IsNumeric(dt.Rows[0]["Cliant_ID"]) == true)
                        {
                            ClientID = dt.Rows[0]["Cliant_ID"].ToString();
                            DataTable dt_Clint = clsDataAccess.RunQDTbl("Select Client_Name from tbl_Employee_CliantMaster where Client_id = '" + dt.Rows[0]["Cliant_ID"] + "'");
                            if (dt_Clint.Rows.Count > 0)
                                cmbclintname.Text = Convert.ToString(dt_Clint.Rows[0]["Client_Name"]);
                        }
                    if (Information.IsNumeric(dt.Rows[0]["Co_Code"]) == true)
                    {
                        CompID = dt.Rows[0]["Co_Code"].ToString();
                        DataTable dt_company = clsDataAccess.RunQDTbl("Select CO_NAME from Company where CO_CODE = '" + dt.Rows[0]["Co_Code"] + "'");
                        if (dt_company.Rows.Count > 0)
                            cmbcompanyname.Text = Convert.ToString(dt_company.Rows[0]["CO_NAME"]);
                    }
                    if (dt.Rows[0]["Locid"].ToString() == "0")
                    {
                        DataTable dtLocIdGet = clsDataAccess.RunQDTbl("select lm.Location_ID from tbl_Emp_Location lm where lm.Cliant_ID = '" + ClientID + "' and lm.Location_Name = '" + dt.Rows[0]["Location"].ToString() + "'");
                        if (dtLocIdGet.Rows.Count == 1)
                        {
                            Locid = dtLocIdGet.Rows[0][0].ToString();
                        }
                    }
                    else
                    {
                        try
                        {
                            Locid = dt.Rows[0]["Locid"].ToString();
                        }
                        catch { Locid = "0"; }

                    }

                }
            }

            ////

            DataTable dtdtl = clsDataAccess.RunQDTbl("select d.Dtl_id,(select DesignationName from tbl_Employee_DesignationMaster where SlNo=d.desig_ID )as 'designation',d.Hour,d.MonthDays,cast(d.rate as decimal(18,2)) as 'RATE',d.rmrks,d.bmod,(select serviceName+':'+sacNo as 'SACNo' from CompanySACMaster where slno = d.SAC) as 'SAC',d.nop,d.ODesg from tbl_Employee_OrderDetails_Dtl d where d.Order_Name = '" + co_code + "'");
            for (int i = 0; i <= dtdtl.Rows.Count - 1; i++)
            {
                dgemployjob.Rows.Add();
                dgemployjob.Rows[i].Cells["id"].Value = Convert.ToString(dtdtl.Rows[i]["Dtl_id"]);
                dgemployjob.Rows[i].Cells["Designation"].Value = Convert.ToString(dtdtl.Rows[i]["designation"]);
                dgemployjob.Rows[i].Cells["colODesg"].Value = dtdtl.Rows[i]["ODesg"].ToString(); 
                //changes made by dwipraj dutta 18082017
                if (!String.IsNullOrEmpty(Convert.ToString(dtdtl.Rows[i]["SAC"])))
                {
                    dgemployjob.Rows[i].Cells["sacno"].Value = Convert.ToString(dtdtl.Rows[i]["SAC"]);
                }
                dgemployjob.Rows[i].Cells["Hour"].Value = Convert.ToString(dtdtl.Rows[i]["Hour"]);
                if (dtdtl.Rows[i]["MonthDays"].ToString().Length >= 5 && Convert.ToString(dtdtl.Rows[i]["MonthDays"]).Substring(0, 5) == "RANGE")
                {
                    dgemployjob.Rows[i].Cells["MontOfDays"].Value = dtdtl.Rows[i]["MonthDays"].ToString().Substring(0, 5);
                    string modVal = dtdtl.Rows[i]["MonthDays"].ToString();
                    int fromDate = Convert.ToInt32(modVal.Substring(5, (modVal.IndexOf("-") - 5)));
                    int toDate = Convert.ToInt32(modVal.Substring(modVal.IndexOf("-") + 1));
                    nudFrom.Value = fromDate;
                    nudTo.Value = toDate;
                }
                else
                {
                    dgemployjob.Rows[i].Cells["MontOfDays"].Value = Convert.ToString(dtdtl.Rows[i]["MonthDays"]);
                }
                dgemployjob.Rows[i].Cells["Rate"].Value = Convert.ToString(dtdtl.Rows[i]["Rate"]);
                dgemployjob.Rows[i].Cells["colRem"].Value = Convert.ToString(dtdtl.Rows[i]["rmrks"]);

                if (Convert.ToInt32(dtdtl.Rows[i]["bmod"]) == 1)
                {
                    dgemployjob.Rows[i].Cells["col_bmod"].Value = "Sal 08hrs - Bill 12hrs";
                }
                else if (Convert.ToInt32(dtdtl.Rows[i]["bmod"]) == 2)
                {
                    dgemployjob.Rows[i].Cells["col_bmod"].Value = "Sal 12hrs - Bill 12hrs";
                }
                else
                {
                    dgemployjob.Rows[i].Cells["col_bmod"].Value = "Sal 08hrs - Bill 08hrs";
                }

                dgemployjob.Rows[i].Cells["nop"].Value = Convert.ToString(dtdtl.Rows[i]["nop"]);
                
            }
            
            //////

        }


        private Boolean SubmitDetails()
        {
            Boolean flug = true;
            Boolean boolStatus = false;
            string encid = "";

            if (btnSave.Text.ToLower() == "save")
            {
                cmborderno.Text = get_ODNo();
            }
            //if (dgemployjob.Rows.Count > 1)
            //{
                bool dt46 = clsDataAccess.RunQry("delete from tbl_Employee_OrderDetails where Order_Name='" + cmborderno.Text.ToString().Trim() + "'");
                bool dt47 = clsDataAccess.RunQry("delete from tbl_Employee_OrderDetails_Dtl where Order_Name='" + cmborderno.Text.ToString().Trim() + "'");
                if (flug == true)
                {
                    //DataTable dt8 =
                    string comid = clsDataAccess.ReturnValue("select co_code from Company where co_name = '" + cmbcompanyname.Text.ToString().Trim() + "' ");
                    //string comid = "";
                    ////if (dt8.Rows.Count > 0)
                    ////{
                    ////    comid = dt8.Rows[0][0].ToString().Trim();
                    ////}

                    //////DataTable dt9 = clsDataAccess.RunQDTbl("select Location_ID from tbl_Emp_Location where Location_Name = '" + cmblocation.Text.ToString().Trim() + "' ");
                    //////string locid = "";
                    //////if (dt9.Rows.Count > 0)
                    //////{
                    //////    locid = dt9.Rows[0][0].ToString().Trim();
                    //////}
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
                    string chk_enc = "";
                    foreach (var item in chkEnclosure.CheckedItems)
                    {
                        DataRowView castedItem = item as DataRowView;
                        if (chk_enc == "")
                        {
                            chk_enc = castedItem[1].ToString();// item.ToString();

                        }
                        else
                        {
                            chk_enc = chk_enc + "|" + castedItem[1].ToString();//item.ToString();
                        }

                    }


                    clsDataAccess.RunWorkflow_Log(edpcom.UserDesc, "Contract Order", sts.ToString(), DateAndTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt"), type, Environment.MachineName, dtporderdate.Value.ToString("MMM"), dtporderdate.Value.Year.ToString(), Locid.ToString(), CompID.ToString(), cmborderno.Text.Trim());
                    //clsEmployee.GetCompanyID(cmbcompanyname.Text)  | clsEmployee.GetClintID(cmbclintname.Text) | 
                    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_OrderDetails(Co_Code,Cliant_ID,Order_Name,Order_Date,FromDate,ToDate,Contract_Person,PnoneNo,Location,Order_Remarks,Cliant_OrderNo,Hour_CODE,MONTH_CODE,refno,status,enclosure,locid) values('" + CompID + "','" + ClientID + "','" + cmborderno.Text + "','" + dtporderdate.Text + "','" + dtpstartdate.Text + "','" + dtpenddate.Text + "','" + txtcontractperson.Text + "','" + txtphoneno.Text + "','" + cmblocation.Text + "','" + txtremarks.Text + "','" + txtclintorder.Text + "','" + clsEmployee.GethrID(comboDialog1.Text) + "','" + clsEmployee.GetmnthID(comboDialog2.Text) + "','" + txtReff.Text.Trim() + "','" + sts + "','" + chk_enc + "','"+ Locid +"')");

                    for (Int32 i = 0; i < dgemployjob.Rows.Count - 1; i++)
                    {
                        dgemployjob.Rows[i].Cells["id"].Value = i + 1;
                        string ID = Convert.ToString(dgemployjob.Rows[i].Cells["id"].Value);
                        string strdesig = Convert.ToString(dgemployjob.Rows[i].Cells["Designation"].Value);

                        string nop = "0";
                        try { nop = Convert.ToString(dgemployjob.Rows[i].Cells["nop"].Value); }
                        catch { nop = "0"; }
                        //Following line changed by dwipraj dutta 18082017
                        string strsacno = Convert.ToString(dgemployjob.Rows[i].Cells["sacno"].Value);
                        
                        string blmod = Convert.ToString(dgemployjob.Rows[i].Cells["col_bmod"].Value);
                        int bmod = 0;

                        if (blmod == "Sal 08hrs - Bill 12hrs")
                        {
                            bmod = 1;
                        }
                        else if (blmod == "Sal 12hrs - Bill 12hrs")
                        {
                            bmod = 2;
                        }
                        else
                        {
                            bmod = 0;
                        }

                        string MOD = dgemployjob.Rows[i].Cells["MontOfDays"].Value.ToString();
                        if (MOD == "RANGE")
                        {
                            MOD = MOD + nudFrom.Value.ToString().Trim() + "-" + nudTo.Value.ToString().Trim();
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
                                if (!String.IsNullOrEmpty(strsacno))
                                {
                                    string[] sac = strsacno.Split(':');
                                    strsacno = sac[1];
                                    strsacno = Convert.ToString(clsDataAccess.RunQDTbl("select slno from CompanySACMaster where sacNo = '"+strsacno+"'").Rows[0][0]);

                                    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_OrderDetails_Dtl(Dtl_id,Order_Name,Order_Date,desig_ID,Hour,MonthDays,RATE,rmrks,bmod,SAC,nop,ODesg) values(" + ID + ",'" + cmborderno.Text + "',cast(convert(datetime,'" + dtporderdate.Text + "',103) as datetime),'" + strdesig_id + "','" + dgemployjob.Rows[i].Cells["Hour"].Value + "','" + MOD + "','" + dgemployjob.Rows[i].Cells["Rate"].Value + "','" + dgemployjob.Rows[i].Cells["colRem"].Value + "','" + bmod + "','" + strsacno + "','" + nop + "','" + dgemployjob.Rows[i].Cells["colODesg"].Value + "')");
                                }
                                else
                                    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_OrderDetails_Dtl(Dtl_id,Order_Name,Order_Date,desig_ID,Hour,MonthDays,RATE,rmrks,bmod,nop,ODesg) values(" + ID + ",'" + cmborderno.Text + "',cast(convert(datetime,'" + dtporderdate.Text + "',103) as datetime),'" + strdesig_id + "','" + dgemployjob.Rows[i].Cells["Hour"].Value + "','" + MOD + "','" + dgemployjob.Rows[i].Cells["Rate"].Value + "','" + dgemployjob.Rows[i].Cells["colRem"].Value + "','" + bmod + "','" + nop + "','" + dgemployjob.Rows[i].Cells["colODesg"].Value + "')");

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
                }
            //}
            /*else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Save");
            }*/
            return boolStatus;


            //////Boolean boolStatus = false;

            //////if (!String.IsNullOrEmpty(cmborderno.Text))
            //////{
            //////    if (co_code > 0)
            //////    {

            //////        boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_OrderDetails set Co_Code='" + clsEmployee.GetCompanyID(cmbcompanyname.Text) + "',Cliant_ID='" + clsEmployee.GetClintID(cmbclintname.Text) + "',Order_Name='" + cmborderno.Text + "',Order_Date='" + dtporderdate.Text + "',FromDate='" + dtpstartdate.Text + "',ToDate='" + dtpenddate.Text + "',Contract_Person='" + txtcontractperson.Text + "',PnoneNo='" + txtphoneno.Text + "',Location='" + cmblocation.Text + "',Order_Remarks='" + txtremarks.Text + "',Cliant_OrderNo='"+ txtclintorder.Text+"' where Order_ID='" + co_code + "' ");
            //////    }
            //////    else
            //////    {
            //////        int Max_ID = 0;
            //////        DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(Order_ID) FROM tbl_Employee_OrderDetails");
            //////        if (Convert.ToString(dt.Rows[0][0]).Length > 0)
            //////        {
            //////            Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
            //////        }
            //////        else
            //////        {
            //////            Max_ID = 1;
            //////        }
            //////        boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_OrderDetails(Order_ID,Co_Code,Cliant_ID,Order_Name,Order_Date,FromDate,ToDate,Contract_Person,PnoneNo,Location,Order_Remarks,Cliant_OrderNo,Hour_CODE,MONTH_CODE) values('" + Max_ID + "','" + clsEmployee.GetCompanyID(cmbcompanyname.Text) + "','" + clsEmployee.GetClintID(cmbclintname.Text) + "','" + cmborderno.Text + "','" + dtporderdate.Text + "','" + dtpstartdate.Text + "','" + dtpenddate.Text + "','" + txtcontractperson.Text + "','" + txtphoneno.Text + "','" + cmblocation.Text + "','" + txtremarks.Text + "','" + txtclintorder.Text + "','" + clsEmployee.GethrID(comboDialog1.Text) + "','" + clsEmployee.GetmnthID(comboDialog2.Text) + "')");
            //////    }
            //////}
            //////else
            //////{
            //////    ERPMessageBox.ERPMessage.Show("Please Enter Ordere Name ");
            //////}

            //////return boolStatus;
        }

        private Boolean DeleteDetails()
        {
            Boolean boolStatus = false;

            boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Employee_OrderDetails where (Order_Name='" + co_code + "')");
            clsDataAccess.RunNQwithStatus("delete from tbl_Employee_OrderDetails_Dtl where (Order_Name='" + co_code + "')");
            clsDataAccess.RunNQwithStatus("delete from tbl_order_FB_detail where (Fname='" + co_code + "')");
            
            return boolStatus;
        }
        private Boolean chkDelete()
        {
            DataTable dt = new DataTable();
            bool bl = true;
            dt=clsDataAccess.RunQDTbl("Select distinct count(billNo) from paybillD where (LTRIM(rtrim(ref_order_no))='" + co_code + "')");

             if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
             {
                 bl = false;
             }
             else
             {
                 bl = true;
             }
             return bl;
        }
        private void cmborderno_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select Order_Name,Cliant_OrderNo,Location, (select Client_Name from tbl_Employee_CliantMaster where Client_id=eod.Cliant_ID)as Client from tbl_Employee_OrderDetails eod order by Client");
            if (dt.Rows.Count > 0)
            {
                cmborderno.LookUpTable = dt;
            }
        }

        private void cmborderno_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select Order_Name from tbl_Employee_OrderDetails where Order_Name='" + cmborderno.Text + "'");
            if (dt.Rows.Count > 0)
                co_code = dt.Rows[0]["Order_Name"].ToString().Trim();

            cmborderno.ReadOnly = true;
            GetDetails();
        }

        private void cmblocation_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID from tbl_Emp_Location where Cliant_ID =" + clsEmployee.GetClintID(cmbclintname.Text) + " ");
            if (dt.Rows.Count > 0)
            {
                cmblocation.LookUpTable = dt;
                cmblocation.ReturnIndex = 1;
            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearall();
            cmborderno.Text = get_ODNo();
        }

        private void clearall()
        {
            cmborderno.ReadOnly = false;
            cmborderno.Text = "";
            dtporderdate.Value = System.DateTime.Now;
            dtpstartdate.Value = System.DateTime.Now;
            dtpenddate.Text = "";
            txtcontractperson.Text = "";
            txtphoneno.Text = "";
            cmblocation.Text = "";            
            txtremarks.Text = "";
            txtclintorder.Text = "";
            cmbclintname.Text = "";
            cmbcompanyname.Text = "";

            comboDialog1.Text = "";
            comboDialog2.Text = "";

            dgemployjob.Rows.Clear();
            txtReff.Text = "";
            chkAc.Checked = false;
            btnSave.Text = "Save";
            chkAuthorise.Checked = false;
            try
            {
                chkEnclosure.Items.Clear();
            }
            catch { }
            try
            {
                for (int ind = 0; ind < chkEnclosure.Items.Count; ind++)
                {

                    chkEnclosure.SetItemChecked(ind, false);
                }
               // chkEnclosure.DataSource = "";
            }
            catch { }

            DataTable encl = clsDataAccess.RunQDTbl("select enclosure,eid from tbl_enclosure");
            chkEnclosure.DataSource = encl;
            chkEnclosure.DisplayMember = "enclosure";
            chkEnclosure.ValueMember = "eid";
        }

        private void comboDialog1_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select Hour_Name from HourMaster ORDER BY CAST(Hour_Name AS int)");
            if (dt.Rows.Count > 0)
            {
                comboDialog1.LookUpTable = dt;
            }
        }

        private void comboDialog2_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select MONTH_Name from MonthOfDays");
            if (dt.Rows.Count > 0)
            {
                comboDialog2.LookUpTable = dt;
            }
        }

        private void dgemployjob_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string tagDeg="";
            ArrayList DesgList = new ArrayList();
            if (dgemployjob.Columns[e.ColumnIndex].HeaderText == "Designation")
            {
                DataTable dt2 = clsDataAccess.RunQDTbl("select m.SlNo from tbl_Employee_DesignationMaster m where  m.DesignationName='" + dgemployjob.Rows[e.RowIndex].Cells["Designation"].Value + "'");

                string strdesigid = "";
                if (dt2.Rows.Count > 0)
                {
                    strdesigid = dt2.Rows[0][0].ToString();
                    if (clsDataAccess.ReturnValue("Select ODesg from CompanyLimiter") == "1")
                    {
                        DialogResult response = MessageBox.Show("You want to mearge Designation?", "Mearge Designation?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if ((response == DialogResult.Yes))
                        {

                            string sqlstmnt = "SELECT SlNo, DesignationName, ShortForm FROM tbl_Employee_DesignationMaster order by slno";
                            EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Designation", "Select Designation", 0, "CMPN", 0);

                            DesgList.Clear();
                            DesgList = EDPCommon.arr_mod;
                            if (DesgList.Count > 0)
                            {
                                tagDeg = "";
                                for (int i = 0; i <= DesgList.Count - 1; i++)
                                {
                                    if (tagDeg.Trim() == "") { tagDeg = DesgList[i].ToString(); }
                                    else
                                    {
                                        tagDeg = tagDeg + "," + DesgList[i].ToString();
                                    }
                                }

                            }
                        }
                        else
                        {
                            tagDeg = strdesigid;
                        }
                    }
                    else
                    {
                        tagDeg = strdesigid;

                    }
                    dgemployjob.Rows[e.RowIndex].Cells["colODesg"].Value = tagDeg; 
                }

            }

        }

        private void dgemployjob_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt2 = clsDataAccess.RunQDTbl("select DesignationName from tbl_Employee_DesignationMaster ");
            DataGridViewComboBoxCell dgcombo1 = new DataGridViewComboBoxCell();
            dgcombo1.Items.Clear();
            for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dt2.Rows[i]["DesignationName"]);
                dgcombo1.Items.Add(st);
            }


        }


        private void dgemployjob_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult response = MessageBox.Show("Are you sure you want to delete this row?", "Delete row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if ((response == DialogResult.No))
            {
                e.Cancel = true;
            }

            //DataGridViewRow row = e.Row;

            //foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            //{
            //    this.HandleRowDeletion(row);
            //}

        }

        private void dgemployjob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) 
            {
                if (dgemployjob.RowCount ==1)
                {
                    return;
                }
                else if (dgemployjob.RowCount >1)
                {
                    dgemployjob.Rows.RemoveAt(dgemployjob.CurrentRow.Index);
                    dgemployjob.Refresh();
                  

                }
            }


  
        }

        private void cmblocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Locid = cmblocation.ReturnValue.ToString();

            cmborderno.Text = get_ODNo();

        }

        private void cmbcompanyname_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            //if (Information.IsNumeric(cmbcompanyname.ReturnValue) == true)
                CompID = cmbcompanyname.ReturnValue.ToString() ;
        }

        private void cmbclintname_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
         //   if (Information.IsNumeric(cmbclintname.ReturnValue) == true)
                ClientID= (cmbclintname.ReturnValue).ToString();
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            DataTable dtCompanyChk = clsDataAccess.RunQDTbl("select * from Company where [CO_NAME] = '" + cmbcompanyname.Text + "'");
            DataTable dtClientChk = clsDataAccess.RunQDTbl("select * from [tbl_Employee_CliantMaster] where [Client_Name] = '" + cmbclintname.Text + "'");
            DataTable dtLocationChk = clsDataAccess.RunQDTbl("select * from [tbl_Emp_Location] where [Location_Name] = '" + cmblocation.Text + "'");
            if (dtCompanyChk.Rows.Count > 0 && dtClientChk.Rows.Count > 0 && dtLocationChk.Rows.Count > 0)
            {
                if (SubmitDetails())
                {
                    chkAc.Checked = true;
                    if (chkAc.Checked == true)
                    {
                        frmOrderDetails_AD foad = new frmOrderDetails_AD();
                        foad.lblClid.Text = ClientID.ToString();
                        foad.lblCoid.Text = CompID.ToString();
                        foad.lbllocid.Text = Locid.ToString();


                        foad.lblLocation.Text = cmblocation.Text;
                        foad.lblClient.Text = cmbclintname.Text;
                        foad.lblContractNo.Text = cmborderno.Text;
                        // foad.lblContractID.Text=



                        foad.ShowDialog();


                    }

                    ERPMessageBox.ERPMessage.Show("Order No. Saved Successfully");
                    cmborderno.ReadOnly = false;
                    clearall();
                    cmborderno.Text = get_ODNo();
                    //this.Close();
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Failed To Submit Order No.");
                }
            }
            else//change made by DWIPRAJ DUTTA 090820170328PM
            {
                EDPMessageBox.EDPMessage.Show("Company name or Client name or Location name is not matching.");
                return;
            }
        }

        private void cmborderno_Leave(object sender, EventArgs e)
        {

        }

        private void chkEnclosure_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = chkEnclosure.SelectedIndex;
            if (selected != -1)
            {
                if (chkEnclosure.GetItemChecked(selected) == true)
                {
                   // chkEnclosureId.Items[selected] = true;
                }
                else
                {
                    //chkEnclosureId.Items[selected] = false;
                }
            }
        }


    }
}
