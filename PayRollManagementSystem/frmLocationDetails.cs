using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frmLocationDetails : EDPComponent.FormBaseERP
    {
        public string ClientID = "", LocationID = "", StateCode = "", zone = "", pf_limit = "15000", esi_limit="21000";


        public frmLocationDetails()
        {
            InitializeComponent();
        }

        private void frmLocationDetails_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.HeaderText = "Location Details";
            this.tbLocAddress.Select();


            DataTable dt = clsDataAccess.RunQDTbl("select pf_limit, esi_limit FROM CompanyLimiter");

            if (dt.Rows.Count > 0)
            {

                pf_limit = dt.Rows[0]["pf_limit"].ToString();
                esi_limit = dt.Rows[0]["esi_limit"].ToString();
            }
            //OnLoad();
        }

        private void OnLoad()
        {
            ClientID = "";
            LocationID = "";
            StateCode = "";
            cmbClient.Text = "";
            cmbLocation.Text = "";
            cmbState.Text = "";
            tbLocAddress.Text = "";
            tbLocType.Text = "";
            tbUsrDefineLocID.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "ADD")
            {
                if (!string.IsNullOrEmpty(cmbClient.Text.Trim()) && !string.IsNullOrEmpty(ClientID) && !string.IsNullOrEmpty(cmbLocation.Text.Trim()) )
                {
                    InsertLocationDet(ClientID, StateCode);
                }
                else
                    EDPMessageBox.EDPMessage.Show("Select location and client first.");
            }
            else
            {
                if (!string.IsNullOrEmpty(cmbClient.Text.Trim()) && !string.IsNullOrEmpty(ClientID) && !string.IsNullOrEmpty(cmbLocation.Text.Trim()) && !string.IsNullOrEmpty(LocationID))
                {

                    if (Information.IsNumeric(LocationID) && Information.IsNumeric(ClientID))
                        updateLocationDet(LocationID, ClientID, StateCode);


                }
                else
                    EDPMessageBox.EDPMessage.Show("Select location and client first.");
            }
        }

        public void cmbClient_DropDown(object sender, EventArgs e)
        {
            DataTable dtClntDrpDwn = clsDataAccess.RunQDTbl("select [Client_Name],[Client_id] from [tbl_Employee_CliantMaster]");
            if (dtClntDrpDwn.Rows.Count > 0)
            {
                cmbClient.LookUpTable = dtClntDrpDwn;
                cmbClient.ReturnIndex = 1;
            }
        }

        public void cmbClient_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbClient.ReturnValue))
            {
                ClientID = cmbClient.ReturnValue;
            }
        }

        public void cmbLocation_DropDown(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ClientID))
            {
                DataTable dtClientLocation = clsDataAccess.RunQDTbl("select [Location_Name],[Location_ID] from tbl_Emp_Location where [Cliant_ID] = " + ClientID);
                if (dtClientLocation.Rows.Count > 0)
                {
                    cmbLocation.LookUpTable = dtClientLocation;
                    cmbLocation.ReturnIndex = 1;
                }
            }
            else
                EDPMessageBox.EDPMessage.Show("Enter client name first.");
        }

        public void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue))
            {
                LocationID = cmbLocation.ReturnValue;
                getData(LocationID);
            }
        }

        private void cmbState_DropDown(object sender, EventArgs e)
        {
            DataTable dtStateMaster = clsDataAccess.RunQDTbl("select [State_Name],[STATE_CODE] from [StateMaster]");
            if (dtStateMaster.Rows.Count > 0)
            {
                cmbState.LookUpTable = dtStateMaster;
                cmbState.ReturnIndex = 1;
            }
        }

        private void cmbState_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbState.ReturnValue))
            {
                StateCode = cmbState.ReturnValue;
            }
        }

        public void sGetData()
        {
           
                string locAddress = "", locState = "", locType = "", locUsrDefineID = "";
               

                try
                {
                   locState ="0";
                    StateCode = locState;
                    
                }
                catch
                {
                    locState = "";
                    StateCode = "";
                }
                try
                {
                   locType = "";
                }
                catch
                {
                    locType = "";
                }
                try
                {
                     locUsrDefineID = "";
                }
                catch
                {
                    locUsrDefineID = "";
                }

               
                tbLocAddress.Text = locAddress;
                cmbState.Text = locState;
                tbLocType.Text = locType;
                tbUsrDefineLocID.Text = locUsrDefineID;

                LocationID = "0";
        }

        public void getData(string locid)
        {
            DataTable dtGetLocationDetails = clsDataAccess.RunQDTbl("select [Location_ID],[Location_Name],[Cliant_ID],[usrdfinLoc_Id],[Location_Address],[Location_State],[Location_Type],[zid] from [tbl_Emp_Location] where Location_ID = " + locid);
            if (dtGetLocationDetails.Rows.Count > 0)
            {
                string locAddress = "",locState = "",locType = "",locUsrDefineID = "";
                try
                {
                    locAddress = dtGetLocationDetails.Rows[0]["Location_Address"].ToString().Trim();
                }
                catch
                {
                    locAddress = "";
                }

                try
                {
                    locState = dtGetLocationDetails.Rows[0]["Location_State"].ToString().Trim();
                    StateCode = locState;
                    if (!String.IsNullOrEmpty(StateCode))
                    {
                        DataTable dtStateDet = clsDataAccess.RunQDTbl("select [State_Name] from [StateMaster] where [STATE_CODE] = " + StateCode);
                        if (dtStateDet.Rows.Count > 0)
                        {
                            locState = dtStateDet.Rows[0][0].ToString();
                        }
                    }
                }
                catch
                {
                    locState = "";
                    StateCode = "";
                }
                try
                {
                    locType = dtGetLocationDetails.Rows[0]["Location_Type"].ToString().Trim();
                }
                catch
                {
                    locType = "";
                }
                try
                {
                    locUsrDefineID = dtGetLocationDetails.Rows[0]["usrdfinLoc_Id"].ToString().Trim();
                }
                catch
                {
                    locUsrDefineID = "";
                }

                //try
                //{
                //    zone
                //}
                //catch { }
                tbLocAddress.Text = locAddress;
                cmbState.Text = locState;
                tbLocType.Text = locType;
                tbUsrDefineLocID.Text = locUsrDefineID;

            }
        }

        private void updateLocationDet(string locid,string clientid,string stateid)
        {
            Boolean flagUpdate = false;
            flagUpdate = clsDataAccess.RunNQwithStatus("update [tbl_Emp_Location] set [Location_Name]='"+cmbLocation.Text.Trim()+"', [usrdfinLoc_Id] = '" + tbUsrDefineLocID.Text.Trim() +
            "',Location_Address = '"+tbLocAddress.Text.Trim()+"',Location_State = "+stateid+",Location_Type = '"+tbLocType.Text.Trim()+
            "',zid='"+ zone +"' where Location_ID = "+locid+" and Cliant_ID = " + clientid);
            if (flagUpdate)
                EDPMessageBox.EDPMessage.Show("Record has been updated successfully.");
            else
                EDPMessageBox.EDPMessage.Show("Record updation failed.");
        }


        private void InsertLocationDet(string clientid, string stateid)
        { 
            Boolean boolStatus = false;
            int Max_ID = 0, Max_rel_id = 0, sal_st_id = 0, LSlink_ID = 0;


             string strCoid="",strCliantName="",strCategory=cmbLocation.Text.Trim();


             DataTable dt = clsDataAccess.RunQDTbl("select Client_id,coid from tbl_Employee_CliantMaster where (Client_id = '" + ClientID + "')");
             if (dt.Rows.Count > 0)
             {
                            strCliantName = Convert.ToString(dt.Rows[0]["Client_id"]);
                            strCoid = Convert.ToString(dt.Rows[0]["coid"]);
             }


            dt = clsDataAccess.RunQDTbl("SELECT Max(Location_ID) FROM tbl_Emp_Location");
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

          
             clsDataAccess.RunNQwithStatus("insert into tbl_Emp_Location(Location_Name,Location_ID,Cliant_ID,zid,"+
             "[usrdfinLoc_Id],Location_Address,Location_State,Location_Type) values('" + 
             strCategory + "','" + Max_ID + "','" + clientid + "','"+zone+"','"+tbUsrDefineLocID.Text.Trim()+"','"+
             tbLocAddress.Text.Trim()+"','"+ stateid +"','"+ tbLocType.Text.Trim() +"')");

             clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_LeaveDetails(LeaveHead,ShortName,TotalLeaves,DayCount,Session,PayType,LeaveFwd,Location_ID,company_Id) values('Absent','AB',0,0,'2016-2017',' ','Nothing','" + Max_ID + "','" + strCoid + "')");

             if (strCoid != "")
             {
                 try
                 {
                 //    clsDataAccess.RunNQwithStatus("INSERT INTO Companywiseid_Relation(ID,Company_ID,Location_ID,PF_Code," +
                 //    "Esi_Code,Ptax_Code,Pan_Code,StReg_Code,M_inst,MOD,typeRem,prefix,sufix,hidedocno,lstDocNo,padding,isST,isSTC,isSC," +
                 //    "narration,note,freeze,blAdd,blPh,blFax,blEmail,isAdd,blState,GSTTYPE,blAcNo,DueDateDays,hrs_per_wd,hrs_per_ot," +
                 //    "apply_hrs_wd,apply_hrs_ot,scPer) VALUES ('" + Max_rel_id + "','" + strCoid + "','" + Max_ID + "','','','','','','False'," +
                 //    "'MonthOfDays','','','Session',0,0,0,0,0,0,'','',0,'','','','',0,'','','',-1,8,4,0,0,'0')");

                     boolStatus = clsDataAccess.RunNQwithStatus("INSERT INTO Companywiseid_Relation(ID,Company_ID,Location_ID,PF_Code,Esi_Code,Ptax_Code," +
                                  "Pan_Code,StReg_Code,M_inst,MOD,[typeRem],[prefix],[sufix],[hidedocno],[lstDocNo],[padding],[isSC],[isST],[isSTC],[freeze],blAdd,blPh," +
                                  "blFax,blEmail,isAdd,blState,blAcNo,GSTTYPE,DueDateDays,[hrs_per_wd],[hrs_per_ot],[apply_hrs_wd],[apply_hrs_ot],[Lv_Rate],[lv_adj]," +
                                  "[scPer],[hrs_per_ed],[apply_hrs_ed],mode_cwd,pf_limit,esi_limit,pf_base,esi_base,narration,note,remit_pfesi,[OCQ]) VALUES ('" +
                              Max_rel_id + "','" + strCoid + "','" + Max_ID + "','','','','','','False','MonthOfDays','','','Session','0','0','0','0','0','0','0','" + tbLocAddress.Text.Trim() + "','','','','0','" + cmbState.Text.Trim() + "','','LOCAL','-1','8','4','0','0','0','0','0','0','0','0', '" + pf_limit + "','" + esi_limit + "','0','1','','','0','0')");
                                
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
                 LocationID = Max_ID.ToString(); ;
                 Loc_permission();

                 EDPMessageBox.EDPMessage.Show("Record Inserted successfully.");
                 btnUpdate.Text = "ADD";
                 zone = "0";
                 cmbZone.Text = clsDataAccess.GetresultS("select zone from tbl_Zone where (zid='0')");
                 LocationID = "0";
                 ClientID = "0";
                 cmbClient.Text = "";
                 cmbLocation.Text = "";

             }
        }


        public void Loc_permission()
        {
            //clsDataAccess.RunNQwithStatus("DELETE FROM AccessLocation");
            DataTable dt_usr = clsDataAccess.RunQDTbl("select user_code from pasword where user_lev='User'");
          //  DataTable dt_loc = clsDataAccess.RunQDTbl("SELECT Location_ID FROM tbl_Emp_Location");

            string qry = "";
            if (dt_usr.Rows.Count > 0)
            {
                
                qry = "";
                for (int ind = 0; ind < dt_usr.Rows.Count; ind++)
                {
                    if (ind==0)
                    {
                    qry = "INSERT INTO AccessLocation(USER_CODE, FICode, GCODE, LOC_CODE)VALUES ";
                    qry = qry + Environment.NewLine + "('" + dt_usr.Rows[ind]["user_code"].ToString() + "',1,1,'" + LocationID + "')";
                    }
                    else
                    {
                      qry = qry + Environment.NewLine + ",('" + dt_usr.Rows[ind]["user_code"].ToString() + "','1','1','" + LocationID + "')";

                    }
                   
                }

                if (qry.Trim() != "")
                {
                    clsDataAccess.RunQry(qry);
                }

            }

        }
        private void btnCLear_Click(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbZone_DropDown(object sender, EventArgs e)
        {

            DataTable dtzone = clsDataAccess.RunQDTbl("select zone,zid from tbl_zone");
            if (dtzone.Rows.Count > 0)
            {
                cmbZone.LookUpTable = dtzone;
                cmbZone.ReturnIndex = 1;
            }
        }

        private void cmbZone_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {

            if (Information.IsNumeric(cmbZone.ReturnValue))
            {
                zone = cmbZone.ReturnValue;
                
            }
        }
    }
}
