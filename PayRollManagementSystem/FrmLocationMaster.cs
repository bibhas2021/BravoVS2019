using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;

namespace PayRollManagementSystem
{
    public partial class FrmLocationMaster : Form
        //EDPComponent.FormBaseERP
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Boolean boolPermissionNewClientEntry = false;
        Boolean boolPermissionNewLocEntry = false;
        int defaultClientLimit = 100;
        int defaultLocationLimit = 1000;
        string columnName = "";
        DataTable dtClient, dtZone;
        public FrmLocationMaster()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                Loc_permission();
                ERPMessageBox.ERPMessage.Show("Location Site Saved Successfully");
                
                GetDetails();

                chk_permission();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Location Site");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteDetails())
            {
                GetDetails();
                ERPMessageBox.ERPMessage.Show("Location Site Deleted Successfully");
            }          
        }

        #region Function


        public void Loc_permission()
        {
            //clsDataAccess.RunNQwithStatus("DELETE FROM AccessLocation");
            DataTable dt_usr = clsDataAccess.RunQDTbl("select user_code from pasword where user_lev='User'");
            DataTable dt_loc = clsDataAccess.RunQDTbl("SELECT Location_ID FROM tbl_Emp_Location");

            string qry = "";
            if (dt_usr.Rows.Count > 0)
            {
                clsDataAccess.RunNQwithStatus("DELETE FROM AccessLocation");
                qry = "";
                for (int ind = 0; ind < dt_usr.Rows.Count; ind++)
                {
                   qry = "INSERT INTO AccessLocation(USER_CODE, FICode, GCODE, LOC_CODE)VALUES ";
                   qry = qry + Environment.NewLine + "('"+ dt_usr.Rows[ind]["user_code"].ToString() +"',1,1,0)";
                   // else
                   //qry = qry + Environment.NewLine + ",('" + dt_usr.Rows[ind]["user_code"].ToString() + "',1,1,0)";

                   if (dt_loc.Rows.Count > 0)
                   {
                       for (int ind1 = 0; ind1 < dt_loc.Rows.Count; ind1++)
                       {
                           qry = qry + Environment.NewLine + ",('" + dt_usr.Rows[ind]["user_code"].ToString() + "','1','1','" + dt_loc.Rows[ind1]["Location_ID"].ToString() + "')";
                           
                       }
                   }
                   if (qry.Trim() != "")
                   {
                       clsDataAccess.RunQry(qry);
                   }
                }

            }
            
        }

        private Boolean SubmitDetails()
        {
            Boolean boolStatus = false;

            System.Collections.ArrayList arrListIDs = new System.Collections.ArrayList();
            arrListIDs.Clear();
            for (int i = 0; i < dgCatg.Rows.Count - 1; i++)
            {
                //int empID = int.Parse(DgJobType.Rows[0].Cells["JobType"].Value.ToString());
                string empID = dgCatg.Rows[i].Cells["Catg"].Value.ToString().Trim();
                string empID1 = dgCatg.Rows[i].Cells["Cliantname"].Value.ToString().Trim();
               
                empID = empID.Trim() + empID1.Trim();
                if (!arrListIDs.Contains(empID))
                {
                    arrListIDs.Add(empID);
                    //do ur code
                }
                else
                {
                    MessageBox.Show("Duplicate row! No Record To Save");
                    boolStatus = false;
                    return boolStatus;
                }
            }

            if (dgCatg.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgCatg.Rows.Count - 1; i++)
                {
                    String strSlNo = Convert.ToString(dgCatg.Rows[i].Cells["Slno"].Value);
                    String strCategory = Convert.ToString(dgCatg.Rows[i].Cells["Catg"].Value);
                    string strCliantName = Convert.ToString(dgCatg.Rows[i].Cells["Cliantname"].Value);
                    string strClid = Convert.ToString(dgCatg.Rows[i].Cells["Clid"].Value);
                    string zid = "";
                    try { zid = clsDataAccess.GetresultS("select zid from tbl_zone where (zone='" + dgCatg.Rows[i].Cells["cmbZone"].Value.ToString().Trim() + "')"); }
                    catch { zid = ""; }
                    if (zid == "")
                    {
                        zid = "0";

                    }
                    string strCoid = "";
                    if (strCliantName != "")
                    {
                        DataTable dt = clsDataAccess.RunQDTbl("select Client_id,coid from tbl_Employee_CliantMaster where (Client_id = '" + strClid + "')");
                        if (dt.Rows.Count > 0)
                        {
                            strCliantName = Convert.ToString(dt.Rows[0]["Client_id"]);
                            strCoid = Convert.ToString(dt.Rows[0]["coid"]);
                        }
                    }
                    if (!String.IsNullOrEmpty(strCategory) && !String.IsNullOrEmpty(strCliantName))
                    {
                        if (!String.IsNullOrEmpty(strSlNo))
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Emp_Location set Location_Name='" + strCategory + "',Cliant_ID ='" + strClid + "',zid='"+ zid +"' where (Location_ID=" + strSlNo + ")");
                            
                            //Will be removed after employee joining through Excel have been fully updated-------------------------------------------
                            DataTable dtcwrid = clsDataAccess.RunQDTbl("Select ID from Companywiseid_Relation where (Location_ID = '" + strSlNo + "')");
                            if (dtcwrid.Rows.Count == 0)
                            {
                                int Max_ID = 0, Max_rel_id = 0;
                                string pf_limit="15000",esi_limit="21000";
                                DataTable dt;
                                dt = clsDataAccess.RunQDTbl("SELECT Max(ID) FROM Companywiseid_Relation");
                                if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                                {
                                    Max_rel_id = Convert.ToInt32(dt.Rows[0][0]) + 1;
                                }
                                else
                                {
                                    Max_rel_id = 1;
                                }
                                dt = clsDataAccess.RunQDTbl("select pf_limit, esi_limit FROM CompanyLimiter");

                                if (dt.Rows.Count> 0)
                                {
                                    
                                    pf_limit=dt.Rows[0]["pf_limit"].ToString();
                                    esi_limit = dt.Rows[0]["esi_limit"].ToString();
                                }
                                if (strCoid != "")
                                {
                                    //boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO Companywiseid_Relation(ID,Company_ID,Location_ID,"+
                                    //"PF_Code,Esi_Code,Ptax_Code,Pan_Code,StReg_Code,M_inst,MOD,typeRem,prefix,sufix,hidedocno,lstDocNo,padding,"+
                                    //"isST,isSTC,isSC,narration,note,freeze,blAdd,blPh,blFax,blEmail,isAdd,blState,GSTTYPE,blAcNo,DueDateDays,"+
                                    //"hrs_per_wd,hrs_per_ot,apply_hrs_wd,apply_hrs_ot,scPer) VALUES ('" + Max_rel_id + "','" + strCoid + "','" + strSlNo +
                                    //"','','','','','','False','MonthOfDays','', '','Session',0,0,0,0,0,0,'','',0,'','','','',0,'','','',-1,8,4,0,0,'0')");
                                    boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO Companywiseid_Relation(ID,Company_ID,Location_ID,PF_Code,Esi_Code,Ptax_Code,"+
                                    "Pan_Code,StReg_Code,M_inst,MOD,[typeRem],[prefix],[sufix],[hidedocno],[lstDocNo],[padding],[isSC],[isST],[isSTC],[freeze],blAdd,blPh,"+
                                    "blFax,blEmail,isAdd,blState,blAcNo,GSTTYPE,DueDateDays,[hrs_per_wd],[hrs_per_ot],[apply_hrs_wd],[apply_hrs_ot],[Lv_Rate],[lv_adj],"+
                                    "[scPer],[hrs_per_ed],[apply_hrs_ed],mode_cwd,pf_limit,esi_limit,pf_base,esi_base,narration,note) VALUES ('" +
                                Max_rel_id + "','" + strCoid + "','" + strSlNo + "','','','','','','False','MonthOfDays','','','Session','0','0','0','0','0','0','0','','','','','0','0','','LOCAL','-1','8','4','0','0','0','0','0','0','0','0', '" + pf_limit + "','" + esi_limit + "','0','1','','')");
                                
                                }
                            }
                            DataTable dtConfigLvDet = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_LeaveDetails where Location_ID = '" + strSlNo + "'");
                            if (dtConfigLvDet.Rows.Count == 0)
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_LeaveDetails(LeaveHead,ShortName,TotalLeaves,DayCount,Session,PayType,LeaveFwd,Location_ID,company_Id) values('Absent','AB',0,0,'2016-2017',' ','Nothing','" + strSlNo + "','" + strCliantName + "')");
                            }


                            //----------------------------------------------------------------------------------------------------------------------
                        }
                        else
                        {
                            int Max_ID = 0, Max_rel_id = 0, sal_st_id = 0, LSlink_ID = 0;
                            DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(Location_ID) FROM tbl_Emp_Location");
                            if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                            {
                                Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                            }
                            else
                            {
                                Max_ID = 1;
                            }

                            dt = clsDataAccess.RunQDTbl("SELECT Max(ID) FROM Companywiseid_Relation");
                            if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                            {
                                Max_rel_id = Convert.ToInt32(dt.Rows[0][0]) + 1;
                            }
                            else
                            {
                                Max_rel_id = 1;
                            }
                           
                            //dt = clsDataAccess.RunQDTbl("select Location_Name from tbl_Emp_Location where Location_Name = '" + strCategory + "'");
                            //if (dt.Rows.Count == 0)
                            //{
                            //    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Emp_Location(Location_Name,Location_ID,Cliant_ID) values('" + strCategory + "','" + Max_ID + "','" + strCliantName + "')");
                            //    if (edpcom.PCURRENT_USER == "1")
                            //        edpcom.CurrentLocation = edpcom.CurrentLocation + "," + Max_ID;
                            //}
                            //else
                            //{
                            //    ERPMessageBox.ERPMessage.Show("Location Name Already Exit");
                            //    boolStatus = false;
                            //}
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Emp_Location(Location_Name,Location_ID,Cliant_ID,zid) values('" + strCategory + "','" + Max_ID + "','" + strCliantName + "','"+zid+"')");

                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_LeaveDetails(LeaveHead,ShortName,TotalLeaves,DayCount,Session,PayType,LeaveFwd,Location_ID,company_Id) values('Absent','AB',0,0,'2016-2017',' ','Nothing','" + Max_ID + "','" + strCoid + "')");

                            if (strCoid != "")
                            {
                                try
                                {
                                    boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO Companywiseid_Relation(ID,Company_ID,Location_ID,PF_Code,"+
                                    "Esi_Code,Ptax_Code,Pan_Code,StReg_Code,M_inst,MOD,typeRem,prefix,sufix,hidedocno,lstDocNo,padding,isST,isSTC,isSC,"+
                                    "narration,note,freeze,blAdd,blPh,blFax,blEmail,isAdd,blState,GSTTYPE,blAcNo,DueDateDays,hrs_per_wd,hrs_per_ot,"+
                                    "apply_hrs_wd,apply_hrs_ot) VALUES ('" + Max_rel_id + "','" + strCoid + "','" + Max_ID + "','','','','','','False',"+
                                    "'MonthOfDays','','','Session',0,0,0,0,0,0,'','',0,'','','','',0,'','','',-1,8,4,0,0)");
                                }
                                catch { }
                                
                                try 
                                {
                                    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_SalaryStructure(SalaryCategory) values('" + strCategory + "_Salary_" + Max_ID + "')");

                                    if (boolStatus == true)
                                    {
                                        sal_st_id = Convert.ToInt32(clsDataAccess.GetresultS("select isNull(SlNo,0) from tbl_Employee_SalaryStructure where (SalaryCategory='" + strCategory + "_Salary_" + Max_ID + "')"));
                                        if (sal_st_id > 0)
                                        {
                                            LSlink_ID = 0;
                                            
                                            DataTable dt1 = clsDataAccess.RunQDTbl("SELECT Max(Link_ID) FROM tbl_Employee_Link_SalaryStructure");
                                            if (Convert.ToString(dt1.Rows[0][0]).Length > 0)
                                            {
                                                LSlink_ID = Convert.ToInt32(dt1.Rows[0][0]) + 1;
                                            }
                                            else
                                            {
                                                LSlink_ID = 1;
                                            }

                                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Link_SalaryStructure(Link_ID,Location_ID,SalaryStructure_ID) values('" + LSlink_ID + "','" + Max_ID + "','" + sal_st_id + "')");

                                        }
                                    }
                                }
                                catch { }


                            }
                        }

                       
                    }
                    else
                    {
                        int row_cou = i + 1;
                        ERPMessageBox.ERPMessage.Show("Please Enter Location or Client Site for " + row_cou + "th Row.");
                    }
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Save");
            }
            return boolStatus;
        }

        private void GetDetails()
        {
            try
            {
                columnName = dgCatg.Columns[dgCatg.CurrentCell.ColumnIndex].HeaderText;
            }
            catch
            {
                columnName = dgCatg.Columns[1].HeaderText;
            }
            DataTable dt = new DataTable();
            if (txtSearch.Text.Trim() == "")
            {
                dt = clsDataAccess.RunQDTbl("Select Location_ID,Location_Name," +
                "(select Client_Name from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID)as Client_Name,el.Cliant_ID as Client_id " +
                ",isNull((select zone from tbl_zone where zid=el.zid),'No Zone')as Zone" +
                " from tbl_Emp_Location el order by el.Location_ID");
                btnExit.Enabled = true;
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select Location_ID,Location_Name," +
                                "(select Client_Name from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID)as Client_Name,el.Cliant_ID as Client_id " +
                                ",isNull((select zone from tbl_zone where zid=el.zid),'No Zone')as Zone" +
                                " from tbl_Emp_Location el where Location_Name like '"+ txtSearch.Text.Trim() +"%'");
                btnExit.Enabled = false;
            }
                //"Select l.Location_ID,l.Location_Name,c.Client_Name,l.zid from tbl_Emp_Location L,tbl_Employee_CliantMaster c where c.Client_id = l.Cliant_ID ");
            if (dt.Rows.Count > 0)
            {
                dgCatg.DataSource = dt;
            }
        }

        private Boolean DeleteDetails()
        {
            Boolean boolStatus = false;
            if (dgCatg.Rows.Count > 1)
            {
                String strSlno = Convert.ToString(dgCatg.CurrentRow.Cells["Slno"].Value);
                String strCatg = Convert.ToString(dgCatg.CurrentRow.Cells["Catg"].Value);

                if (!String.IsNullOrEmpty(strSlno))
                {
                    DataTable dt = clsDataAccess.RunQDTbl("Select * from tbl_Employee_Link_SalaryStructure where Location_ID =" + strSlno + " ");
                    if (dt.Rows.Count == 0)
                        boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Emp_Location where Location_ID=" + strSlno + "");
                    else
                        ERPMessageBox.ERPMessage.Show("Location Does Not Delete. Link Location Exit ");
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Location Does Not Exists. Cannot Delete Selected Locatio Site.");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Delete");
            }
            return boolStatus;
        }

        #endregion

        private void FrmLocationMaster_Load(object sender, EventArgs e)
        {
            //this.HeaderText = "Location Site Master";
            dtClient = clsDataAccess.RunQDTbl("select Client_Name,Client_id from tbl_Employee_CliantMaster");
            /*DataGridViewComboBoxColumn dgcombo = dgCatg.Columns["Cliantname"] as DataGridViewComboBoxColumn;
            dgcombo.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dt.Rows[i]["Client_Name"]);
                dgcombo.Items.Add(st);
                
            }
            */
            dtZone = clsDataAccess.RunQDTbl("select zone,zid from tbl_zone");
            DataGridViewComboBoxColumn dgcmbzone = dgCatg.Columns["cmbZone"] as DataGridViewComboBoxColumn;
            dgcmbzone.Items.Clear();
            for (int i = 0; i <= dtZone.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dtZone.Rows[i]["Zone"]);
                dgcmbzone.Items.Add(st);

            }
            //dgcmbzone.DataSource = dt;
            //dgcmbzone.ValueMember = "zid";
            //dgcmbzone.DisplayMember = "zone";

            GetDetails();
            //PermissionLocCreate();
            //PermissionClientCreate();

            chk_permission();
            
            //this.WindowState = FormWindowState.Maximized;


        }
        private void chk_permission()
        {
            DataTable dtCompanyLimiter = clsDataAccess.RunQDTbl("select ClientLimit,LocLimit,zone from CompanyLimiter");
            int count_client = Convert.ToInt32(clsDataAccess.RunQDTbl("select count(*)as 'TR' from [tbl_Employee_CliantMaster]").Rows[0][0]);

            int count_Loc = Convert.ToInt32(clsDataAccess.RunQDTbl("select count(*)as 'TR' from [tbl_Emp_Location]").Rows[0][0]);

            if (count_client == 0)
                btnCreateClient.Enabled = true;
            else
            {
               
                if (dtCompanyLimiter.Rows.Count > 0)
                {
                    if (count_client < Convert.ToInt32(dtCompanyLimiter.Rows[0]["ClientLimit"]) || Convert.ToInt32(dtCompanyLimiter.Rows[0]["ClientLimit"])==0)
                        btnCreateClient.Enabled = true;
                    else
                        btnCreateClient.Enabled = false;
                }
                else
                {
                    btnCreateClient.Enabled = false;
                }
            }
            btn_newLocation.Enabled = true;
            if (count_Loc == 0)
            {  
                dgCatg.AllowUserToAddRows = true;
                btn_newLocation.Enabled = true;
            }
            else
            {

                if (dtCompanyLimiter.Rows.Count > 0)
                {
                    if (count_Loc < Convert.ToInt32(dtCompanyLimiter.Rows[0]["LocLimit"]) || Convert.ToInt32(dtCompanyLimiter.Rows[0]["LocLimit"]) == 0)
                    {
                        dgCatg.AllowUserToAddRows = true;
                        btn_newLocation.Enabled = true;
                    }
                    else
                    {
                        dgCatg.AllowUserToAddRows = false;
                        btn_newLocation.Enabled = false;

                        MessageBox.Show("Limit for Location Reached in your version right now." + Environment.NewLine + "Please contact support@edpsoft.com or" + Environment.NewLine + "Call : 033-40003855", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    dgCatg.AllowUserToAddRows = false;
                    btn_newLocation.Enabled = false;
                    MessageBox.Show("Location Limit Reached in your version right now." + Environment.NewLine + "Please contact support@edpsoft.com or" + Environment.NewLine + "Call : 033-40003855", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (Convert.ToInt32(dtCompanyLimiter.Rows[0]["zone"]) == 1)
            {
                dgCatg.Columns["cmbZone"].Visible = true;
            }
            else
            {
                dgCatg.Columns["cmbZone"].Visible = false;
            }

        }
        private void PermissionLocCreate()
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
                                if (str.ToUpper() == "LOCATION_ENTRY_LIMITER")
                                    chk_str = 1;
                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                if (Information.IsNumeric(StrLine_WACC[0]))
                                {
                                    DataTable dtCountClient = clsDataAccess.RunQDTbl("select count(*) as 'TotalRecord' from [tbl_Emp_Location]");
                                    if (Convert.ToInt32(dtCountClient.Rows[0][0]) < Convert.ToInt32(StrLine_WACC[0]))
                                    {
                                        boolPermissionNewLocEntry = true;
                                    }
                                }
                                else if (StrLine_WACC[0] == "EDP_BRAVO_UNLIMITED")
                                    boolPermissionNewLocEntry = true;
                                else
                                {
                                    DataTable dtCountClient = clsDataAccess.RunQDTbl("select count(*) as 'TotalRecord' from [tbl_Emp_Location]");
                                    if (Convert.ToInt32(dtCountClient.Rows[0][0]) < defaultLocationLimit)
                                    {
                                        boolPermissionNewLocEntry = true;
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
            dgCatg.AllowUserToAddRows = boolPermissionNewLocEntry;
        }

        private void PermissionClientCreate()
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
                                if (str.ToUpper() == "CLIENT_ENTRY_LIMITER")
                                    chk_str = 1;
                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                if (Information.IsNumeric(StrLine_WACC[0]))
                                {
                                    DataTable dtCountLoc = clsDataAccess.RunQDTbl("select count(*) as 'TotalRecord' from [tbl_Employee_CliantMaster]");
                                    if (Convert.ToInt32(dtCountLoc.Rows[0][0]) < Convert.ToInt32(StrLine_WACC[0]))
                                    {
                                        boolPermissionNewClientEntry = true;
                                    }
                                }
                                else if (StrLine_WACC[0] == "EDP_BRAVO_UNLIMITED")
                                    boolPermissionNewClientEntry = true;
                                else
                                {
                                    DataTable dtCountLoc = clsDataAccess.RunQDTbl("select count(*) as 'TotalRecord' from [tbl_Employee_CliantMaster]");
                                    if (Convert.ToInt32(dtCountLoc.Rows[0][0]) < defaultClientLimit)
                                    {
                                        boolPermissionNewClientEntry = true;
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
            btnCreateClient.Visible = boolPermissionNewClientEntry;
        }

        private void btnCreateClient_Click(object sender, EventArgs e)
        {
            frmcompanyMaster cm = new frmcompanyMaster();
            cm.getcode(0, "P");
            cm.ShowDialog();

            DataTable dt = clsDataAccess.RunQDTbl("select Client_Name from tbl_Employee_CliantMaster where Client_id= (select MAX(Client_id) from tbl_Employee_CliantMaster)");
            DataGridViewComboBoxColumn dgcombo = dgCatg.Columns["Cliantname"] as DataGridViewComboBoxColumn;
            if (dt.Rows.Count > 0)
            {
                if(!dgcombo.Items.Contains(dt.Rows[0][0]))
                    dgcombo.Items.Add(dt.Rows[0][0]);
            }
            
            /*dgcombo.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dt.Rows[i]["Client_Name"]);
                dgcombo.Items.Add(st);
            }*/
        }

        private void dgCatg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dgCatg.CurrentCell.ColumnIndex == dgCatg.Columns["Catg"].Index))
            {
                DataGridViewRow row = this.dgCatg.Rows[e.RowIndex];
                if (dgCatg.RowCount > 0)
                {
                    dgCatg.CurrentCell = this.dgCatg[2,e.RowIndex];
                    this.dgCatg.CurrentCell.Selected = false;
                }
                string selectedRowLocId = "",selectedRowLocName = "", selectedRowClientId = "", selectedRowClientName = "",stzone="";
                try
                {
                    selectedRowLocId = row.Cells["slno"].Value.ToString();
                }
                catch
                {
                    selectedRowLocId = "";
                }
                if (!String.IsNullOrEmpty(selectedRowLocId))
                {
                    selectedRowLocName = row.Cells["Catg"].Value.ToString();
                    selectedRowClientName = row.Cells["Cliantname"].Value.ToString();

                    selectedRowClientId = clsDataAccess.RunQDTbl("select Cliant_ID from tbl_Emp_Location where Location_ID = " + selectedRowLocId).Rows[0][0].ToString();

                    stzone = row.Cells["cmbZone"].Value.ToString();
                    frmLocationDetails fld = new frmLocationDetails();
                    //fld.MdiParent = this.MdiParent;
                    fld.cmbClient.Text = selectedRowClientName;
                    fld.ClientID = selectedRowClientId;
                    fld.cmbLocation.Text = selectedRowLocName;
                    fld.cmbZone.Text = stzone;
                    fld.btnUpdate.Text = "UPDATE";
                    fld.zone = clsDataAccess.GetresultS("select zid from tbl_zone where (zone='" + stzone + "')");
                    fld.LocationID = selectedRowLocId;
                    fld.getData(selectedRowLocId);
                    fld.Show();
                }
                else
                {
                    EDPMessageBox.EDPMessage.Show("Please save the location first.");
                }
                
            }

            else if ((dgCatg.CurrentCell.ColumnIndex == dgCatg.Columns["cliantname"].Index))
            {
                DialogView dv = new DialogView();
                dv.sql_frm = "select Client_id as ClientID,Client_Name as ClientName,(select CO_NAME from Company where CO_CODE=cm.coid)as 'Company' from tbl_Employee_CliantMaster cm order by Client_id";
                dv.retno = 2;
                dv.lblCo.Text = "";
                dv.lblHead.Text = "";
                dv.btnPreview.Visible = false;
                dv.ShowDialog();
                try
                {
                    int ind = Convert.ToInt32(dgCatg.CurrentRow.Index);

                    this.dgCatg.Rows[ind].Cells["cliantname"].Value = dv.retval1.ToString();
                    this.dgCatg.Rows[ind].Cells["Clid"].Value = dv.retval.ToString();

                }
                catch { }

            }

        }

        private void splitter3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btnZone_Click(object sender, EventArgs e)
        {
            frmZone zone = new frmZone();
            zone.ShowDialog();


           DataTable dt = clsDataAccess.RunQDTbl("select zone,zid from tbl_zone");
            DataGridViewComboBoxColumn dgcmbzone = dgCatg.Columns["cmbZone"] as DataGridViewComboBoxColumn;
            dgcmbzone.Items.Clear();
            //dgcmbzone.DataSource = dt;
            //dgcmbzone.ValueMember = "zid";
            //dgcmbzone.DisplayMember = "zone";
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dt.Rows[i]["Zone"]);
                dgcmbzone.Items.Add(st);

            }
        }

        private void btn_newLocation_Click(object sender, EventArgs e)
        {
            frmLocationDetails fld = new frmLocationDetails();
            fld.btnUpdate.Text = "ADD";
            fld.zone = "0";
            fld.cmbZone.Text = clsDataAccess.GetresultS("select zone from tbl_Zone where (zid='0')");
            fld.LocationID = "0";
            fld.ClientID = "0";
            fld.cmbClient.Text = "";
            fld.cmbLocation.Text = "";
            fld.sGetData();
            fld.Show();

            GetDetails();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int indx = 0;


            try
            {
                indx = dgCatg.CurrentCell.ColumnIndex;

            }
            catch { }

           


            GetDetails();
        }

        private void dgCatg_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

     

      


    }
}
