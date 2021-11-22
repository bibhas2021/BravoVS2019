using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.VisualBasic;
using System.Collections;
using System.Data.SqlClient;
using Edpcom;
using EDPComponent;
using System.Diagnostics;


namespace PayRollManagementSystem
{
    public partial class frmDevolopersAccess : Form
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();


        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        SqlTransaction sqltran;
        Edpcom.EDPCommon edpcmn = new Edpcom.EDPCommon();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommandBuilder cmb = new SqlCommandBuilder();
        SqlCommand cmd = new SqlCommand();


        DataTable dtComp, dtState;

        string AttendLimit="250", AttendPrime="0";
        
        public frmDevolopersAccess()
        {
            InitializeComponent();
        }




        private void frmDevolopersAccess_Load(object sender, EventArgs e)
        {
            OnLoad();
        }
        private void OnLoad()
        {
            string qryForGettingAccessList = "select MENUCODE as 'MenuCode',MENUDESC as 'MenuName',ACCESSVALUE as 'AccessStatus' from MenuAccessList";
                //"SELECT MENUCODE as 'MenuCode', MENUDESC  as 'MenuName',ENABLE_MENU as 'AccessStatus' FROM MenuTable";
                //
            DataTable dtCompanyNo, dtCompanyLmtr;
            DataTable dtAccessList = clsDataAccess.RunQDTbl(qryForGettingAccessList);

            dataGridView1.DataSource = dtAccessList;
            dataGridView1.Columns["MenuCode"].Visible = false;
            dataGridView1.Columns["MenuName"].Width = 200;

            numComp.Maximum = Decimal.MaxValue;
            dtCompanyNo = clsDataAccess.RunQDTbl("select count(*) from Company");
            pnocLable.Text = dtCompanyNo.Rows[0][0].ToString().Trim();

            dtCompanyLmtr = clsDataAccess.RunQDTbl("select LMTVALUE,ClientLimit,LocLimit,EmpLimit,pf_limit,esi_limit,"+
            "bill_sign,ed,lv,Society,Shift,zone,payslip,woff,desgday,inv,empid,ps_hide_doj,pinfo,lv_type,bon,email,email_bill,"+
            "desg_formula,empsal,download,user_limit,ptax,nonpfesi,bankdetails,wd_limit,bill_format,OCAttend,pfgs,"+
            "reg_central,reg_tamilnadu,reg_general,lang,bill_head,SalExp,dAttend,BillTC,SalOC,"+
            "chk_active_limit,limit_gross,chk_active_limit_esi,limit_gross_esi,chk_cont_type,State,city,country,"+
            "salflag,salafterdeduction,MenuLvSal,SalExc2,UsrEmp,UsrClient,UsrFo,Aemp,Aclient,Afo,bill_doc_type,ODesg,ed_bill,ot_bill,bill_rcalc,sal_nc,"+
            "web_admin,web_emp,web_client,web_fo,web_fmsAdm,web_fmsUsr,PfEsiEdit,MEmp,DormentDur,ieAttend,SacGst,AttendLimit,"+
            "AttendPrime from CompanyLimiter");
            if (dtCompanyLmtr.Rows.Count > 0)
            {

                try
                {
                    cmbAttend_primary.SelectedIndex = Convert.ToInt32(dtCompanyLmtr.Rows[0]["AttendPrime"].ToString());
                }
                catch { cmbAttend_primary.SelectedIndex = 0; }

                try
                {
                    txtLimitAttend.Text = dtCompanyLmtr.Rows[0]["AttendLimit"].ToString();
                }
                catch { }
                //---------web config-----------------------------------------------------------

                chk_web_FmsUsr.Checked = false;
                chk_web_FmsAdm.Checked = false;
                chk_web_FO.Checked = false;
                chk_web_client.Checked = false;
                chk_web_emp.Checked = false;
                chk_web_admin.Checked = false;
                chkPfEsiEdit.Checked = false;
                chkMEmp.Checked = false;
                chk_ieAttend.Checked = false;
                chkSacGst.Checked = false;

                
                if (dtCompanyLmtr.Rows[0]["SacGst"].ToString() == "1") // Sac wise Gst per
                {
                    chkSacGst.Checked = true;
                }

                if (dtCompanyLmtr.Rows[0]["ieAttend"].ToString() == "1") // mirroring
                {
                    chk_ieAttend.Checked = true;
                }


                if (dtCompanyLmtr.Rows[0]["MEmp"].ToString() == "1") // mirroring
                {
                    chkMEmp.Checked = true;
                }

                if (dtCompanyLmtr.Rows[0]["PfEsiEdit"].ToString() == "1")
                {
                    chkPfEsiEdit.Checked = true;
                }
                
                if (dtCompanyLmtr.Rows[0]["web_admin"].ToString() == "1")
                {
                    chk_web_admin.Checked = true;
                }

                if (dtCompanyLmtr.Rows[0]["web_emp"].ToString() == "1")
                {
                    chk_web_emp.Checked = true;
                }
                if (dtCompanyLmtr.Rows[0]["web_client"].ToString() == "1")
                {
                    chk_web_client.Checked = true;
                }
                if (dtCompanyLmtr.Rows[0]["web_fo"].ToString() == "1")
                {
                    chk_web_FO.Checked = true;
                }
                if (dtCompanyLmtr.Rows[0]["web_fmsAdm"].ToString() == "1")
                {
                    chk_web_FmsAdm.Checked = true;
                }
                if (dtCompanyLmtr.Rows[0]["web_fmsUsr"].ToString() == "1")
                {
                    chk_web_FmsUsr.Checked = true;
                }
                

                
                //--------------------- Configuration ---------------------------------
                if (dtCompanyLmtr.Rows[0]["chk_active_limit"].ToString().Trim() == "1")
                {
                    chk_activate_limit_PF.Checked = true;
                }
                else
                {
                    chk_activate_limit_PF.Checked = false;
                }


                


                if (dtCompanyLmtr.Rows[0]["UsrEmp"].ToString().Trim() == "1")
                {
                    chkUsrEmp.Checked = true;
                }
                else
                {
                    chkUsrEmp.Checked = false;
                }


                if (dtCompanyLmtr.Rows[0]["UsrClient"].ToString().Trim() == "1")
                {
                    chkUsrClient.Checked = true;
                }
                else
                {
                    chkUsrClient.Checked = false;
                }

                 
                if (dtCompanyLmtr.Rows[0]["UsrFo"].ToString().Trim() == "1")
                {
                    chkUsrFo.Checked = true;
                }
                else
                {
                    chkUsrFo.Checked = false;
                }

                txtUsrEmpLimit.Text = dtCompanyLmtr.Rows[0]["Aemp"].ToString().Trim();
                txtUsrClientLimit.Text = dtCompanyLmtr.Rows[0]["Aclient"].ToString().Trim();
                txtUsrFoLimit.Text = dtCompanyLmtr.Rows[0]["Afo"].ToString().Trim();
                txtDormentDur.Text = dtCompanyLmtr.Rows[0]["DormentDur"].ToString().Trim();
                //--------------------- Salary Structure -----------------------------  
                if (dtCompanyLmtr.Rows[0]["sal_nc"].ToString().Trim() == "1")  //sal_nc
                {
                    chkSalNC.Checked = true;
                }
                else
                {
                    chkSalNC.Checked = false;
                }
                
                //SalExc2
                if (dtCompanyLmtr.Rows[0]["SalExc2"].ToString().Trim() == "1")
                {
                    chkEmpQry.Checked = true;
                }
                else
                {
                    chkEmpQry.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["MenuLvSal"].ToString().Trim() == "1")
                {
                    chkMenuLvSal.Checked = true;
                }
                else
                {
                    chkMenuLvSal.Checked = false;
                }
                if (dtCompanyLmtr.Rows[0]["salflag"].ToString().Trim() == "1")
                {
                    chkSalFlag.Checked = true;
                }
                else
                {
                    chkSalFlag.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["salafterdeduction"].ToString().Trim() == "1")
                {
                    chkSalEffectAfterDeduction.Checked = true;
                }
                else
                {
                    chkSalEffectAfterDeduction.Checked = false;
                }
                //--------------------------------------------------------------------

                txtGross_PF.Text = dtCompanyLmtr.Rows[0]["limit_gross"].ToString().Trim();
                
                if (dtCompanyLmtr.Rows[0]["chk_active_limit_esi"].ToString().Trim() == "1")
                {
                    chk_activate_limit_ESI.Checked = true;
                }
                else
                {
                    chk_activate_limit_ESI.Checked = false;
                }
                
                if (dtCompanyLmtr.Rows[0]["chk_cont_type"].ToString().Trim() == "1")
                {
                    chkLocContribution.Checked = true;
                }
                else
                {
                    chkLocContribution.Checked = false;
                }

                txtGross_ESI.Text = dtCompanyLmtr.Rows[0]["limit_gross_esi"].ToString().Trim();
                cmbState.Text = dtCompanyLmtr.Rows[0]["State"].ToString().Trim();
                txtCity.Text = dtCompanyLmtr.Rows[0]["City"].ToString().Trim();
                cmbCountry.Text = dtCompanyLmtr.Rows[0]["Country"].ToString().Trim();

                //--------------------- register --------------------------------------


                if (dtCompanyLmtr.Rows[0]["SalExp"].ToString() == "1")
                {
                    chkCgfm.Checked = true;
                }
                else if (dtCompanyLmtr.Rows[0]["SalExp"].ToString() == "2")
                {
                    chkCTC.Checked = true;
                }
                else
                {
                    chkCTC.Checked = false;
                    chkCgfm.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["reg_central"].ToString() == "1")
                {
                    chk_register_central.Checked = true;
                }
                else
                {
                    chk_register_central.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["reg_general"].ToString() == "1")
                {
                    chk_register_general.Checked = true;
                }
                else
                {
                    chk_register_general.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["reg_tamilnadu"].ToString() == "1")
                {
                    chk_Register_Tamil.Checked = true;
                }
                else
                {
                    chk_Register_Tamil.Checked = false;
                }
                //=========Menu========================================================

                if (dtCompanyLmtr.Rows[0]["dAttend"].ToString() == "1")
                {
                    chk_daily_Attend.Checked = true;
                }
                else
                {
                    chk_daily_Attend.Checked = false;
                }
                //=====================================================================
                numComp.Value = Convert.ToInt32(dtCompanyLmtr.Rows[0]["LMTVALUE"]);
                numClient.Value = Convert.ToInt32(dtCompanyLmtr.Rows[0]["ClientLimit"]);
                numLoc.Value = Convert.ToInt32(dtCompanyLmtr.Rows[0]["LocLimit"]);
                numEmp.Value = Convert.ToDecimal(dtCompanyLmtr.Rows[0]["EmpLimit"]);
                txtPfLimit.Text = Convert.ToString(dtCompanyLmtr.Rows[0]["pf_limit"]);
                txtEsiLimit.Text = Convert.ToString(dtCompanyLmtr.Rows[0]["esi_limit"]);
                txt_wd_limit.Text = dtCompanyLmtr.Rows[0]["wd_limit"].ToString();
                txtLang.Text = dtCompanyLmtr.Rows[0]["lang"].ToString();
                txtUser.Text=dtCompanyLmtr.Rows[0]["user_limit"].ToString();
                if (dtCompanyLmtr.Rows[0]["desg_formula"].ToString() == "1")
                {
                    chkformula.Checked=true;
                }
                else
                {
                    chkformula.Checked=false;
                }

               if (dtCompanyLmtr.Rows[0]["empsal"].ToString() == "1")
               {
                   chkEmpSal.Checked = true;
               }
               else
               {
                   chkEmpSal.Checked = false;
               }

               if (dtCompanyLmtr.Rows[0]["SalOC"].ToString() == "1") // Enable Salary Other Charges
               {
                   chkSalOthCharge.Checked = true;
               }
               else
               {
                   chkSalOthCharge.Checked = false;
               }

               if (dtCompanyLmtr.Rows[0]["OCAttend"].ToString() == "1")
               {
                   chkOcAttend.Checked = true;
               }
               else
               {
                   chkOcAttend.Checked = false;
               }


               if (dtCompanyLmtr.Rows[0]["download"].ToString() == "1")
               {
                   chkDownload.Checked = true;
               }
               else
               {
                   chkDownload.Checked = false;
               }


                if (dtCompanyLmtr.Rows[0]["desgday"].ToString() == "1")
                {
                    chkDesgDaysCalc.Checked=true;
                }
                else
                {
                    chkDesgDaysCalc.Checked=false;
                }


                if (dtCompanyLmtr.Rows[0]["inv"].ToString() == "1")
                {
                    chkInventory.Checked = true;
                }
                else
                {
                    chkInventory.Checked = false;
                }



                if (dtCompanyLmtr.Rows[0]["bill_sign"].ToString()=="1")
                {
                    chkBillAuthorise.Checked=true;
                }
                else
                {
                    chkBillAuthorise.Checked=false;
                }

                if (dtCompanyLmtr.Rows[0]["ODesg"].ToString() == "1")//odesg in bill
                {
                    chkBill_odesg.Checked = true;
                }
                else { chkBill_odesg.Checked = false; }
                if (dtCompanyLmtr.Rows[0]["ed_bill"].ToString() == "1")//ed included in attendance count for bill
                { chkBill_ED.Checked = true; }
                else
                { chkBill_ED.Checked = false; }

                if (dtCompanyLmtr.Rows[0]["ot_bill"].ToString() == "1")//ot included in attendance count for bill
                { chkBill_OT.Checked = true; }
                else
                { chkBill_OT.Checked = false; }


                if (dtCompanyLmtr.Rows[0]["ed"].ToString() == "1")
                {
                    chkED.Checked=true;
                }
                else
                {
                    chkED.Checked=false;
                }


                if (dtCompanyLmtr.Rows[0]["bon"].ToString() == "1")
                {
                    chkBon.Checked = true;
                }
                else
                {
                    chkBon.Checked = false;
                }


                if (dtCompanyLmtr.Rows[0]["email"].ToString() == "1")
                {
                    chkMail_PS.Checked = true;
                }
                else
                {
                    chkMail_PS.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["email_bill"].ToString() == "1")
                {
                    chkMail_Bill.Checked = true;
                }
                else
                {
                    chkMail_Bill.Checked = false;
                }


                if (dtCompanyLmtr.Rows[0]["lv"].ToString() == "1")
                {
                    chkLeave.Checked = true;
                }
                else
                {
                    chkLeave.Checked = false;
                }


                if (dtCompanyLmtr.Rows[0]["bill_rcalc"].ToString() == "1")// bill recalculate
                {
                    chkBill_rcalc.Checked = true;
                }
                else
                {
                    chkBill_rcalc.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["BillTC"].ToString() == "1")// bill Terms condition
                {
                    chkBillTC.Checked = true;
                }
                else
                {
                    chkBillTC.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["bill_format"].ToString() == "1") // Bill FOrmat
                {
                    cmbBillType.SelectedIndex = 0;                    
                }
                else if (dtCompanyLmtr.Rows[0]["bill_format"].ToString() == "2")
                {
                    cmbBillType.SelectedIndex =1;                   
                }
                else if (dtCompanyLmtr.Rows[0]["bill_format"].ToString() == "3")
                {
                    cmbBillType.SelectedIndex =2;                    
                }
                else if (dtCompanyLmtr.Rows[0]["bill_format"].ToString() == "4")
                {
                    cmbBillType.SelectedIndex = 3;                    
                }
                else if (dtCompanyLmtr.Rows[0]["bill_format"].ToString() == "5") // new format - with reverse charges
                {
                    //cmbBillType.SelectedIndex = 4;
                }
                else if (dtCompanyLmtr.Rows[0]["bill_format"].ToString() == "6") // new format - Terms and condition CQ/DD/PO
                {
                    cmbBillType.SelectedIndex = 4;
                }
                else if (dtCompanyLmtr.Rows[0]["bill_format"].ToString() == "7") // new format - Terms and condition CQ/DD/PO
                {
                    cmbBillType.SelectedIndex = 5;
                }


                if (dtCompanyLmtr.Rows[0]["bill_doc_type"].ToString() == "1") // Bill Doc Type
                {
                    cmbBillDocType.SelectedIndex = 0; //Series
                }
                else if (dtCompanyLmtr.Rows[0]["bill_doc_type"].ToString() == "2")
                {
                    cmbBillDocType.SelectedIndex = 1; //Location
                }
                else if (dtCompanyLmtr.Rows[0]["bill_doc_type"].ToString() == "3")
                {
                    cmbBillDocType.SelectedIndex = 2; //Zone
                }



                if (dtCompanyLmtr.Rows[0]["bill_head"].ToString() == "1") // Bill Head
                {
                    cmbBillHead.SelectedIndex = 0; //tax inv
                }
                else if (dtCompanyLmtr.Rows[0]["bill_head"].ToString() == "2")
                {
                    cmbBillHead.SelectedIndex = 1; //bill
                }
                else if (dtCompanyLmtr.Rows[0]["bill_head"].ToString() == "3")
                {
                    cmbBillHead.SelectedIndex = 2; //bos
                }


                if (dtCompanyLmtr.Rows[0]["lv_type"].ToString() == "2") // Lv Type
                {
                    cmbLeave.SelectedIndex = 1;
                }
                else
                {
                    cmbLeave.SelectedIndex = 0;
                }

                if (dtCompanyLmtr.Rows[0]["ptax"].ToString() == "1") // ptax type
                {
                    cmbPt.SelectedIndex = 1;
                }
                else
                {
                    cmbPt.SelectedIndex = 0;
                }

                if (dtCompanyLmtr.Rows[0]["payslip"].ToString() == "2") // gross
                {
                    cmbPayslip.SelectedIndex = 1;
                }
                else if (dtCompanyLmtr.Rows[0]["payslip"].ToString() == "3")//Rate
                {
                    cmbPayslip.SelectedIndex = 3;
                }
                else if (dtCompanyLmtr.Rows[0]["payslip"].ToString() == "4")//No-gross
                {
                    cmbPayslip.SelectedIndex = 2;
                }
                else if (dtCompanyLmtr.Rows[0]["payslip"].ToString() == "5")//Earnings
                {
                    cmbPayslip.SelectedIndex = 4;
                }
                else if (dtCompanyLmtr.Rows[0]["payslip"].ToString() == "6")//Form XIX
                {
                    cmbPayslip.SelectedIndex = 5;
                }
                else
                {
                    cmbPayslip.SelectedIndex = 0; //simple
                }

                if (dtCompanyLmtr.Rows[0]["pinfo"].ToString() == "1") // personal information
                {
                    cmbEmpInfo.SelectedIndex = 1;
                }
                else
                {
                    cmbEmpInfo.SelectedIndex = 0;
                }

                if (dtCompanyLmtr.Rows[0]["pfgs"].ToString() == "1") // Pf Gs type
                {
                    cmbPFGS.SelectedIndex = 1;
                }
                else
                {
                    cmbPFGS.SelectedIndex = 0;
                }

                if (dtCompanyLmtr.Rows[0]["ps_hide_doj"].ToString() == "1")
                {
                    chk_Ps_doj_hide.Checked = true;
                }
                else
                {
                    chk_Ps_doj_hide.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["Society"].ToString() == "1")
                {
                    chkSociety.Checked = true;
                }
                else
                {
                    chkSociety.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["Shift"].ToString() == "1")
                {
                    chkShift.Checked = true;
                }
                else
                {
                    chkShift.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["zone"].ToString() == "1")
                {
                    chkZone.Checked = true;
                }
                else
                {
                    chkZone.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["woff"].ToString() == "1")
                {
                    chkWOff.Checked = true;
                }
                else
                {
                    chkWOff.Checked = false;
                }

                if (dtCompanyLmtr.Rows[0]["empid"].ToString() == "1")
                {
                    chkEID.Checked = true;
                }
                else
                {
                    chkEID.Checked = false;
                }
                if (dtCompanyLmtr.Rows[0]["nonpfesi"].ToString() == "1")
                {
                    chkNonPfEsi.Checked = true;
                }
                else
                {
                    chkNonPfEsi.Checked = false;
                }
                if (dtCompanyLmtr.Rows[0]["bankdetails"].ToString() == "1")
                {
                    chkBankDetails.Checked = true;
                }
                else
                {
                    chkBankDetails.Checked = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveMenuAccess();
            setCompanyLimiter();
            OnLoad();

            MessageBox.Show("Need to close the application, Please start again", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //foreach (var process in Process.GetProcessesByName("PayRollManagementSystem.exe"))
            //{
            //    process.Kill();
            //}
            Environment.Exit(0);

        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            //Process.Start(Application.ExecutablePath);
            //Application.Exit();
            this.Close();
            //MessageBox.Show("Need to close the application, Please start again","Bravo", MessageBoxButtons.OK,MessageBoxIcon.Information);
            //foreach (var process in Process.GetProcessesByName(Application.ExecutablePath))
            //{
            //    process.Kill();
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["AccessStatus"].Index && e.RowIndex != -1)
            {
                //it will show the complement of the current checkbox value
                textBox1.Text = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() + "           " + dataGridView1.Rows[e.RowIndex].Cells["MenuCode"].Value.ToString();
                this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        /*
        private void saveMenuAccess()
        {
            Boolean boolUpdate = false;
            DataTable dt6 = new DataTable();

            dt6.Clear();
            dt6.Columns.Add("MENUCODE");
            dt6.Columns.Add("MENUDESC");
            dt6.Columns.Add("ACCESSVALUE");

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                DataRow dataRow = dt6.NewRow();
                dataRow["MENUCODE"] = dataGridView1.Rows[row].Cells[0].Value;
                dataRow["MENUDESC"] = dataGridView1.Rows[row].Cells[1].Value;
                dataRow["ACCESSVALUE"] = dataGridView1.Rows[row].Cells[2].Value;

                dt6.Rows.Add(dataRow);
            }

            foreach (DataRow dr6 in dt6.Rows)
            {
                if (clsDataAccess.ReturnValue("Select count(*) from MenuAccessList where MENUCODE = '" + dr6[0] + "'") == "1")
                {
                    boolUpdate = clsDataAccess.RunNQwithStatus("update MenuAccessList set MENUDESC = '" + dr6[1] + "',ACCESSVALUE = '" + Convert.ToBoolean(dr6[2]) + "' where MENUCODE = '" + dr6[0] + "'");
                }
                else
                {
                    if (Convert.ToBoolean(dr6[2]) == Convert.ToBoolean(1))
                    {
                        boolUpdate = clsDataAccess.RunNQwithStatus("insert into MenuAccessList (MENUCODE,MENUDESC,ACCESSVALUE) values ('" + dr6[0] + "','" + dr6[1] + "','" + Convert.ToBoolean(dr6[2]) + "')");
                    }
                }
                if (boolUpdate == true)
                {
                    clsDataAccess.RunQry("update MenuTable set ENABLE_MENU = '" + Convert.ToBoolean(dr6[2]) + "' where MENUCODE = '" + dr6[0] + "'");
                }
            }

            if (boolUpdate)
            {
                ERPMessageBox.ERPMessage.Show("Configuration Saved Successfully.");
                try
                {
                    dataGridView1.Rows.Clear();
                }
                catch
                {

                }
                //OnLoad();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Something Went Wrong During The Process.");
            }
        }
*/
        private void saveMenuAccess()
        {
            Boolean boolUpdate = false;
            DataTable dt6 = new DataTable();

            dt6.Clear();
            dt6.Columns.Add("MENUCODE");
            dt6.Columns.Add("MENUDESC");
            dt6.Columns.Add("ACCESSVALUE");

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                DataRow dataRow = dt6.NewRow();
                dataRow["MENUCODE"] = dataGridView1.Rows[row].Cells[0].Value;
                dataRow["MENUDESC"] = dataGridView1.Rows[row].Cells[1].Value;
                dataRow["ACCESSVALUE"] = dataGridView1.Rows[row].Cells[2].Value;

                dt6.Rows.Add(dataRow);
            }

            foreach (DataRow dr6 in dt6.Rows)
            {
                boolUpdate = clsDataAccess.RunNQwithStatus("update MenuAccessList set MENUDESC = '" + dr6[1] + "',ACCESSVALUE = '" + dr6[2] + "' where MENUCODE = '" + dr6[0] + "'");
            }

            if (boolUpdate)
            {
                ERPMessageBox.ERPMessage.Show("Configuration Saved Successfully.");
                try
                {
                    dataGridView1.Rows.Clear();
                }
                catch
                {

                }
                //OnLoad();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Something Went Wrong During The Process.");
            }
        }

        private void setCompanyLimiter()
        {
            try
            {
                string sqlCL = "select LMTVALUE from CompanyLimiter";
                DataTable dt = clsDataAccess.RunQDTbl(sqlCL);
                Boolean dltFlag = false;
                Boolean insrtFlag = false;
                string lang = "";
                int BillTC = 0, SalOC = 0, bill_sign = 0, pfgs = 0, bill_head = 0, bill_doc_type = 0, wd_limit = 60, woff = 0, ed = 0, bon = 0, email = 0, email_bill = 0, lv = 0, lv_type = 0, Society = 0, Shift = 0, zone = 0, empid = 0, ps_hide_doj = 0, payslip = 0, desgday = 0, inv = 0, pinfo = 0, desg_formula = 0, empsal = 0, download = 0, user_limit = 0, ptax = 0, nonpfesi = 0, bankdetails = 0, bill_format = 3, ocattend = 0, SalExp = 0, dAttend = 0, salflag = 0, salafterdeduction = 0, MenuLvSal = 0, SalExc2 = 0, UsrEmp = 0, UsrClient = 0, UsrFo = 0, Aemp = 0, Aclient = 0, Afo = 0, ODesg = 0, ed_bill = 0, OT_bill = 0, bill_rcalc=0;
                int sal_nc = 0, PfEsiEdit = 0, MEmp = 0, ieAttend=0;
                //-------Registers------------------------------------
                int reg_central = 0, reg_tamil = 0, reg_general = 0, SacGst=0;
                //-------------Configuration---------------------------
                string chk_limit = "0", gross = "0", chk_limit_esi = "0", gross_esi = "0", chk_cont_type = "0",state="",city="",country="";
                //----------Web Config---------------------------------
                string web_admin = "0", web_emp = "0", web_client = "0", web_fo = "0", web_fmsAdm = "0", web_fmsUsr = "0", DormentDur = "2";
                //-----------------------------------------------------

                AttendLimit=txtLimitAttend.Text;
                try
                {
                    AttendPrime = cmbAttend_primary.SelectedIndex.ToString();
                }
                catch { AttendPrime = "0"; }
                if (chk_ieAttend.Checked == true)
                {
                    ieAttend = 1;
                }

                if (chk_web_admin.Checked==true)
                    { web_admin ="1";}
                if (chk_web_emp.Checked==true)
                    { web_emp ="1";}
                 if (chk_web_client.Checked==true)
                    { web_client ="1";}
                 if (chk_web_FO.Checked==true)
                    { web_fo ="1";}
                 if (chk_web_FmsAdm.Checked==true)
                    { web_fmsAdm ="1";}
                 if (chk_web_FmsUsr.Checked==true)
                    { web_fmsUsr ="1";}


                 if (chkPfEsiEdit.Checked == true)
                 {
                     PfEsiEdit = 1;
                 }

                 if (chkMEmp.Checked == true)
                 {
                     MEmp = 1;
                 }


                if (chkSalNC.Checked==true)
                {
                    sal_nc = 1;
                }
                if (chkBill_odesg.Checked == true)
                { ODesg=1; }

                if (chkBill_ED.Checked==true)
                {
                    ed_bill = 1;
                }

                if (chkBill_OT.Checked == true)
                {
                    OT_bill = 1;
                }

                if (chkBill_rcalc.Checked == true)
                {
                    bill_rcalc = 1;
                }

                if (chkEmpQry.Checked == true)
                {
                    SalExc2 = 1;
                }
                else
                {
                    SalExc2 = 0;
                }


                if (chkUsrEmp.Checked==true)
                    UsrEmp=1;
                else
                    UsrEmp=0;

                if (chkUsrClient.Checked == true)
                    UsrClient = 1;
                else
                    UsrClient = 0;


                if (chkUsrFo.Checked == true)
                    UsrFo = 1;
                else
                    UsrFo = 0;

                try
                {
                    Aemp = Convert.ToInt32(txtUsrEmpLimit.Text);
                }
                catch { }
                try
                {
                    Aclient = Convert.ToInt32(txtUsrClientLimit.Text);
                }
                catch { }
                try
                {
                    Afo = Convert.ToInt32(txtUsrFoLimit.Text);
                }
                catch { }
                
                
                if (chk_activate_limit_PF.Checked == true)
                {
                    chk_limit = "1";
                }
                if (chkSalFlag.Checked == true)
                {
                    salflag = 1;
                }
                if (chkSalEffectAfterDeduction.Checked == true)
                {
                    salafterdeduction =1;
                }

                try
                {
                    if (Convert.ToDouble(txtGross_PF.Text) > 0)
                    {
                        gross = txtGross_PF.Text;
                    }
                }
                catch { gross = "15000.00"; }

                if (chk_activate_limit_ESI.Checked == true)
                {
                    chk_limit_esi = "1";
                }
                try
                {
                    if (Convert.ToDouble(txtGross_ESI.Text) > 0)
                    {
                        gross_esi = txtGross_ESI.Text;
                    }
                }
                catch { gross_esi = "21000.00"; }


                try
                {
                    if (Convert.ToDouble(txtDormentDur.Text) > 0)
                    {
                        DormentDur = txtDormentDur.Text;
                    }
                    else
                    {
                        DormentDur = "0";
                    }
                }
                catch { DormentDur = "0"; }

                if (chkLocContribution.Checked == true)
                {
                    chk_cont_type = "1";
                }
                else
                {
                    chk_cont_type = "0";
                }
                state = cmbState.Text.Trim();
                city = txtCity.Text.Trim();
                country = cmbCountry.Text.Trim();
                //string chk_active_limit = "0", limit_gross = "15000", chk_active_limit_esi = "0", limit_gross_esi = "21000";
                //try
                //{
                //    DataTable dtGrs = clsDataAccess.RunQDTbl("select top 1 chk_active_limit, limit_gross, chk_active_limit_esi, limit_gross_esi from CompanyLimiter");
                //    if (dtGrs.Rows.Count>0){
                //    chk_active_limit = dtGrs.Rows[0]["chk_active_limit"].ToString();
                //        limit_gross= dtGrs.Rows[0]["limit_gross"].ToString();
                //        chk_active_limit_esi= dtGrs.Rows[0]["chk_active_limit_esi"].ToString();
                //        limit_gross_esi = dtGrs.Rows[0]["limit_gross_esi"].ToString();
                //    }
                //}
                //catch { chk_active_limit = "0"; limit_gross = "15000"; chk_active_limit_esi = "0"; limit_gross_esi = "21000"; }
              

                    if (chkSalOthCharge.Checked==true)//salary other charge
                    {SalOC=1;}
                    else{SalOC=0;}

                if(chkBillTC.Checked==true)//bill terms condition CQ/DD/po
                {BillTC=1;}
                else{BillTC=0;}

                if (chkCgfm.Checked == true)
                {
                    SalExp = 1;
                }
                else if (chkCTC.Checked == true)
                {
                    SalExp = 2;
                }
                else
                {
                    SalExp = 0;
                }

                if (chk_register_central.Checked == true)
                {
                    reg_central = 1;
                }

                if (chk_Register_Tamil.Checked == true)
                {
                    reg_tamil = 1;
                }

                if (chk_register_general.Checked == true)
                {
                    reg_general = 1;
                }

                //=======================================================
                //-------Menu--------------------------------------------
                if (chk_daily_Attend.Checked == true)
                    dAttend = 1;
                else dAttend = 0;

                //-------------------------------------------------------
                if (chkInventory.Checked == true)
                {
                    inv = 1;
                }

                if (chkformula.Checked == true)
                {
                    desg_formula = 1;

                }
                try
                {
                   user_limit = Convert.ToInt32(txtUser.Text.Trim());
                }
                catch { user_limit = 0; }


                try
                {
                    wd_limit = Convert.ToInt32(txt_wd_limit.Text.Trim());
                }
                catch
                { wd_limit = 60; }

                if (chkDownload.Checked == true)
                {
                    download=1;
                }


                if (chkEmpSal.Checked==true)
                {
                    empsal = 1;
                }

                if (chkBillAuthorise.Checked==true)
                    bill_sign=1;
                
                if (chkED.Checked==true)
                    ed=1;

                if (chkWOff.Checked == true)
                    woff = 1;


                if (chkOcAttend.Checked == true)
                {
                    ocattend = 1;
                }

                if (chkSociety.Checked==true)
                {
                   Society=1;
                }

                if (chkDesgDaysCalc.Checked == true)
                {
                    desgday = 1;
                }

                if(chkShift.Checked==true) { Shift=1;}
                if (chkZone.Checked==true){zone=1;}
                if (chkEID.Checked==true){empid=1;}


                if (chkBon.Checked == true) { bon = 1; }

                if (chkMenuLvSal.Checked==true){MenuLvSal=1;}

                if (chkMail_PS.Checked == true) { email = 1; }
                if (chkMail_Bill.Checked == true) { email_bill = 1; }
                if (cmbPayslip.SelectedIndex == 1)
                    payslip = 2; // gross
                else if (cmbPayslip.SelectedIndex == 2)
                    payslip = 4; // no-gross
                else if (cmbPayslip.SelectedIndex == 3)
                    payslip = 3; // rate
                else if (cmbPayslip.SelectedIndex == 4)
                    payslip = 5; // earnings
                else if (cmbPayslip.SelectedIndex == 5)
                    payslip = 6; //Form XIX

                else payslip = 1; //simple

                if (cmbBillHead.SelectedIndex == 0)//tax inv
                { bill_head = 1; }
                else if (cmbBillHead.SelectedIndex == 1)//bill
                { bill_head = 2; }
                else if (cmbBillHead.SelectedIndex == 2)//bill of supply
                { bill_head = 3; }


                if (cmbBillDocType.SelectedIndex == 0)//Series
                { bill_doc_type = 1; }
                else if (cmbBillDocType.SelectedIndex == 1)//Location
                { bill_doc_type = 2; }
                else if (cmbBillDocType.SelectedIndex == 2)//Zone
                { bill_doc_type = 3; }


                if (chkLeave.Checked == true)
                {
                    lv = 1;

                    if (cmbLeave.SelectedIndex == 1)
                    {
                        lv_type = 2;
                    }
                    else
                    {
                        lv_type = 1;
                    }
                }
                else
                {
                    lv_type = 0;
                    lv = 0;
                }

                if (cmbEmpInfo.SelectedIndex == 1)
                {
                    pinfo = 1;
                }
                else
                {
                    pinfo = 0;
                }

                if (cmbBillType.SelectedIndex == 0)
                {
                    bill_format = 1;
                }
                else if (cmbBillType.SelectedIndex == 1)
                {
                    bill_format = 2;
                }
                else if (cmbBillType.SelectedIndex == 2)
                {
                    bill_format = 3;
                }
                else if (cmbBillType.SelectedIndex == 3)
                {
                    bill_format = 4;
                }
                else if (cmbBillType.SelectedIndex == 4) // Terms and condition
                {
                    bill_format = 6;
                }
                else if (cmbBillType.SelectedIndex == 5) // GST
                {
                    bill_format = 7;
                }


                if (cmbPt.SelectedIndex == 1)
                {
                    ptax = 1;
                }
                else
                {
                    ptax = 0;
                }

                if (cmbPFGS.SelectedIndex == 1)
                {

                    pfgs = 1;
                }
                else
                {
                    pfgs = 0;
                }

                nonpfesi = 0; bankdetails = 0;

                if (chkSacGst.Checked == true) //Sac wise Gst Per
                {
                    SacGst = 1;
                }
                else
                {
                    SacGst = 0;
                }




                if (chkBankDetails.Checked == true) 
                { 
                    bankdetails = 1;

                    clsDataAccess.RunNQwithStatus("update tbl_Employee_Mast set pay_mod=1 where (Bank_Name<>'') and (BankAcountNo<>'') and (GMIno<>'')"); 
                }
                if (chkNonPfEsi.Checked == true) { nonpfesi = 1; }

                if (chk_Ps_doj_hide.Checked == true) { ps_hide_doj = 1; }
                lang = txtLang.Text.Trim();
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(pnocLable.Text) <= numComp.Value || numComp.Value==0)
                    {
                        dltFlag = clsDataAccess.RunNQwithStatus("delete from CompanyLimiter");
                        if (dltFlag)
                            insrtFlag = clsDataAccess.RunNQwithStatus("insert into CompanyLimiter (LMTVALUE,ClientLimit,LocLimit,EmpLimit,pf_limit,esi_limit,bill_sign,ed,lv,Society,Shift,zone,empid,payslip,woff,desgday,inv,ps_hide_doj,pinfo,lv_type,bon,email,desg_formula,empsal,download,user_limit,ptax,nonpfesi,bankdetails,wd_limit,bill_format,OCAttend,pfgs,reg_central,reg_tamilnadu,lang,bill_head,SalExp,dAttend,reg_general,BillTC,SalOC, chk_active_limit,limit_gross,chk_active_limit_esi,limit_gross_esi,chk_cont_type,state,city,country,email_bill,salflag,salafterdeduction,MenuLvSal,SalExc2,UsrEmp,UsrClient,UsrFo,Aemp,Aclient,Afo,bill_doc_type,ODesg,ed_bill,ot_bill,bill_rcalc,sal_nc,web_admin,web_emp,web_client,web_fo,web_fmsAdm,web_fmsUsr,PfEsiEdit,MEmp,DormentDur,ieAttend,SacGst,AttendLimit, AttendPrime) values ('" + numComp.Value + "','" + numClient.Value + "','" + numLoc.Value + "','" + numEmp.Value + "','" + txtPfLimit.Text + "','" + txtEsiLimit.Text + "','" + bill_sign + "','" + ed + "','" + lv + "','" + Society + "','" + Shift + "','" + zone + "','" + empid + "','" + payslip + "','" + woff + "','" + desgday + "','" + inv + "','" + ps_hide_doj + "','" + pinfo + "','" + lv_type + "','" + bon + "','" + email + "','" + desg_formula + "','" + empsal + "','" + download + "','" + user_limit + "','" + ptax + "','" + nonpfesi + "','" + bankdetails + "','" + wd_limit + "','" + bill_format + "','" + ocattend + "','" + pfgs + "','" + reg_central + "','" + reg_tamil + "','" + lang + "','" + bill_head + "','" + SalExp + "','" + dAttend + "','" + reg_general + "','" + BillTC + "','" + SalOC + "','" + chk_limit + "','" + gross + "','" + chk_limit_esi + "','" + gross_esi + "','" + chk_cont_type + "','" + state + "','" + city + "','" + country + "','" + email_bill + "','" + salflag + "','" + salafterdeduction + "','" + MenuLvSal + "','" + SalExc2 + "','" + UsrEmp + "','" + UsrClient + "','" + UsrFo + "','" + Aemp + "','" + Aclient + "','" + Afo + "','" + bill_doc_type + "','" + ODesg + "','" + ed_bill + "','" + OT_bill + "','" + bill_rcalc + "','" + sal_nc + "','" + web_admin + "','" + web_emp + "','" + web_client + "','" + web_fo + "','" + web_fmsAdm + "','" + web_fmsUsr + "','" + PfEsiEdit + "','" + MEmp + "','" + DormentDur + "','" + ieAttend + "','" + SacGst + "','" + AttendLimit + "','" + AttendPrime + "')");
                        else
                            EDPMessageBox.EDPMessage.Show("There is some problem occured during seletion of data");
                    }
                    else
                        EDPMessageBox.EDPMessage.Show("Currently saved number of companies is more than "+numComp.Value+". Can not set this value as limiter.");
                }
                else
                {
                    if (Convert.ToInt32(pnocLable.Text) <= numComp.Value)
                        insrtFlag = clsDataAccess.RunNQwithStatus("insert into CompanyLimiter (LMTVALUE,ClientLimit,LocLimit,EmpLimit,pf_limit,esi_limit,bill_sign,ed,lv,Society,Shift,zone,empid,payslip,woff,desgday,inv,ps_hide_doj,pinfo,lv_type,bon,email,desg_formula,empsal,download,user_limit,ptax,nonpfesi,bankdetails,wd_limit,bill_format,OCAttend,pfgs,reg_central,reg_tamilnadu,lang,bill_head,SalExp,dAttend,reg_general,BillTC,SalOC, chk_active_limit,limit_gross,chk_active_limit_esi,limit_gross_esi,chk_cont_type,state,city,country,email_bill,salflag,salafterdeduction,MenuLvSal,SalExc2,UsrEmp,UsrClient,UsrFo,Aemp,Aclient,Afo,bill_doc_type,ODesg,ed_bill,ot_bill,bill_rcalc,sal_nc,web_admin,web_emp,web_client,web_fo,web_fmsAdm,web_fmsUsr,PfEsiEdit,MEmp,DormentDur,ieAttend,SacGst,AttendLimit, AttendPrime) values ('" + numComp.Value + "','" + numClient.Value + "','" + numLoc.Value + "','" + numEmp.Value + "','" + txtPfLimit.Text + "','" + txtEsiLimit.Text + "','" + bill_sign + "','" + ed + "','" + lv + "','" + Society + "','" + Shift + "','" + zone + "','" + empid + "','" + payslip + "','" + woff + "','" + desgday + "','" + inv + "','" + ps_hide_doj + "','" + pinfo + "','" + lv_type + "','" + bon + "','" + email + "','" + desg_formula + "','" + empsal + "','" + download + "','" + user_limit + "','" + ptax + "','" + nonpfesi + "','" + bankdetails + "','" + wd_limit + "','" + bill_format + "','" + ocattend + "','" + pfgs + "','" + reg_central + "','" + reg_tamil + "','" + lang + "','" + bill_head + "','" + SalExp + "','" + dAttend + "','" + reg_general + "','" + BillTC + "','" + SalOC + "','" + chk_limit + "','" + gross + "','" + chk_limit_esi + "','" + gross_esi + "','" + chk_cont_type + "','" + state + "','" + city + "','" + country + "','" + email_bill + "','" + salflag + "','" + salafterdeduction + "','" + MenuLvSal + "','" + SalExc2 + "','" + UsrEmp + "','" + UsrClient + "','" + UsrFo + "','" + Aemp + "','" + Aclient + "','" + Afo + "','" + bill_doc_type + "','" + ODesg + "','" + ed_bill + "','" + OT_bill + "','" + bill_rcalc + "','" + sal_nc + "','" + web_admin + "','" + web_emp + "','" + web_client + "','" + web_fo + "','" + web_fmsAdm + "','" + web_fmsUsr + "','" + PfEsiEdit + "','" + MEmp + "','" + DormentDur + "','" + ieAttend + "','" + SacGst + "','" + AttendLimit + "','" + AttendPrime + "')");
                    else if (numComp.Value == 0)
                    {
                        insrtFlag = clsDataAccess.RunNQwithStatus("insert into CompanyLimiter (LMTVALUE,ClientLimit,LocLimit,EmpLimit,pf_limit,esi_limit,bill_sign,ed,lv,Society,Shift,zone,empid,payslip,woff,desgday,inv,ps_hide_doj,pinfo,lv_type,bon,email,desg_formula,empsal,download,user_limit,ptax,nonpfesi,bankdetails,wd_limit,bill_format,OCAttend,pfgs,reg_central,reg_tamilnadu,lang,bill_head,SalExp,dAttend,reg_general,BillTC,SalOC, chk_active_limit,limit_gross,chk_active_limit_esi,limit_gross_esi,chk_cont_type,state,city,country,email_bill,salflag,salafterdeduction,MenuLvSal,SalExc2,UsrEmp,UsrClient,UsrFo,Aemp,Aclient,Afo,bill_doc_type,ODesg,ed_bill,ot_bill,bill_rcalc,sal_nc,web_admin,web_emp,web_client,web_fo,web_fmsAdm,web_fmsUsr,PfEsiEdit,MEmp,DormentDur,ieAttend,SacGst,AttendLimit, AttendPrime) values ('" + numComp.Value + "','" + numClient.Value + "','" + numLoc.Value + "','" + numEmp.Value + "','" + txtPfLimit.Text + "','" + txtEsiLimit.Text + "','" + bill_sign + "','" + ed + "','" + lv + "','" + Society + "','" + Shift + "','" + zone + "','" + empid + "','" + payslip + "','" + woff + "','" + desgday + "','" + inv + "','" + ps_hide_doj + "','" + pinfo + "','" + lv_type + "','" + bon + "','" + email + "','" + desg_formula + "','" + empsal + "','" + download + "','" + user_limit + "','" + ptax + "','" + nonpfesi + "','" + bankdetails + "','" + wd_limit + "','" + bill_format + "','" + ocattend + "','" + pfgs + "','" + reg_central + "','" + reg_tamil + "','" + lang + "','" + bill_head + "','" + SalExp + "','" + dAttend + "','" + reg_general + "','" + BillTC + "','" + SalOC + "','" + chk_limit + "','" + gross + "','" + chk_limit_esi + "','" + gross_esi + "','" + chk_cont_type + "','" + state + "','" + city + "','" + country + "','" + email_bill + "','" + salflag + "','" + salafterdeduction + "','" + MenuLvSal + "','" + SalExc2 + "','" + UsrEmp + "','" + UsrClient + "','" + UsrFo + "','" + Aemp + "','" + Aclient + "','" + Afo + "','" + bill_doc_type + "','" + ODesg + "','" + ed_bill + "','" + OT_bill + "','" + bill_rcalc + "','" + sal_nc + "','" + web_admin + "','" + web_emp + "','" + web_client + "','" + web_fo + "','" + web_fmsAdm + "','" + web_fmsUsr + "','" + PfEsiEdit + "','" + MEmp + "','" + DormentDur + "','" + ieAttend + "','" + SacGst + "','" +AttendLimit+ "','" + AttendPrime+"')");
                    }
                    else

                    {
                        EDPMessageBox.EDPMessage.Show("Currently saved number of companies is more than " + numComp.Value + ". Can not set this value as limiter.");
                    }
                }

                if (insrtFlag)
                    EDPMessageBox.EDPMessage.Show("Company limiter setting is complete.");

            }
            catch
            {
                EDPMessageBox.EDPMessage.Show("Some problem occured.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*frmEmployeeUpdateSelectedField bgdw = new frmEmployeeUpdateSelectedField();*/
            frmEmployeeSalAssignNewUI bgdw = new frmEmployeeSalAssignNewUI();
            //frmClientOutstandingReport bgdw = new frmClientOutstandingReport();
            bgdw.ShowDialog();
        }

        private void btn_Process_Click(object sender, EventArgs e)
        {

        }

        private void cmbBillDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBillDocType.SelectedIndex == 2)
            {
                chkZone.Checked = true;
            }
            
        }

        private void cmbCountry_DropDown(object sender, EventArgs e)
        {
            dtComp = clsDataAccess.RunQDTbl("SELECT Country_Name FROM Country");
            
            if (dtComp.Rows.Count > 0)
            {
                cmbCountry.LookUpTable = dtComp;
                cmbCountry.ReturnIndex = 0;
            }
            
        }

        private void cmbCountry_CloseUp(object sender, ComboDialog.CloseUpEventArgs e)
        {

        }

        private void cmbState_DropDown(object sender, EventArgs e)
        {
            dtState = clsDataAccess.RunQDTbl("SELECT State_name FROM StateMaster");

            if (dtState.Rows.Count > 0)
            {
                cmbState.LookUpTable = dtState;
                cmbState.ReturnIndex = 0;
            }
        }

        private void cmbState_CloseUp(object sender, ComboDialog.CloseUpEventArgs e)
        {

        }

        private void chkSacGst_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSacGst.Checked == true)
            {
                cmbBillType.SelectedIndex = 5;
            }
        }

       


      
        
       

      
    }
}
