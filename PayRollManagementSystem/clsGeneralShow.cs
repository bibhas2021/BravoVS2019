using System;
using System.Collections.Generic;
using System.Text;
using Edpcom;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Threading;

namespace PayRollManagementSystem
{
    class clsGeneralShow
    {
        Edpcom.EDPCommon EDPComm = new EDPCommon();
        Edpcom.EDPConnection EDPConn = new EDPConnection();
        SqlCommand mycmd;
        DataTable dt,AccessValidity;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet DS = new DataSet();
        ListBox lb = new ListBox();

        public void GeneralShow(String Menucode, Form parent)
        {
            /*-------------------------------------------------Added by dwipraj 100820170432PM-------------------------------------------------------*/
            AccessValidity = clsDataAccess.RunQDTbl("select ACCESSVALUE,MENUDESC from MenuAccessList where MENUCODE = '" + Menucode + "'");
            if (AccessValidity.Rows[0]["ACCESSVALUE"].ToString() == "False")
            {
                ERPMessageBox.ERPMessage.Show("The " + AccessValidity.Rows[0]["MENUDESC"].ToString() + " feature is not supported in your version right now." + Environment.NewLine + "Please contact support@edpsoft.com or"+Environment.NewLine+"Call : 033-40003855");
                return;
            }
            /*-----------------------------------------------------End of 100820170433PM-------------------------------------------------------------*/
             switch (Menucode)
            {
                    //admin
                 //  10070100000 frmUserdetails
                case "10070200000": Session(parent);
                    break;
                case "10070300000": AccountTransfer(parent);
                    break;
                case "10070400000": DocNumber(parent); //frmAccountPosting
                    break;
                case "10070500000": Aclink(parent);
                    break;


                // Gen Master
                case "20010010000": COUNTRYMASTER(parent);
                    break;
                case "20010020000": STATEMASTER(parent);
                    break;
                case "20010020001": ZoneMASTER(parent);
                    break;
                case "20010030000": COMPANYMASTER(parent);
                    break;
                case "20010040000": CLIENTMASTER(parent);
                    break;
                case "20010050000": LOCSITEMASTER(parent);
                    break;
                case "20010060000": LEAVEDETAILS(parent);
                    break;
                case "20010070000": ESI(parent);
                    break;
                case "20010080000": PTX(parent);
                    break;
                case "20010090000": PtaxEditor(parent);
                    break;
                case "20010100000": HOLIDAY(parent);
                    break;

                case "20010100001": HOURMASTER(parent);
                    break;
                case "20010100002": MONTHOFDAYSMASTER(parent);
                    break;

                case "20010100003": KITLOGMASTER(parent);//===== NEW MASTER KIT
                    break;
                case "20010100011": FineLog(parent);
                    break;

                case "20010100004": SACMASTER(parent);
                    break;
                case "20010100005": StatusMst(parent);
                    break;

                case "20010100006": ShiftMst(parent);
                    break;
                case "20010100007": EncMst(parent);
                    break;
                case "20010100008": VrfyMst(parent);
                    break;
                case "20010100009": PoliceMst(parent);
                    break;
                case "20010100010": vendor(parent);
                    break;

              // Employee Master
                case "20020010000": JOBMASTER(parent);
                    break;
                case "20020020000": DESIGNATIONMASTER(parent);
                    break;
                case "20020030000": Qualificationmaster(parent);
                    break;
                case "20020040000": RELATIONMASTER(parent); // Relation_Master
                    break;
                case "20020050000": EMPPAYBILL(parent); // Config_RetirementDetails
                    break;
                case "20020060000": show_PTO(parent); // EmpJoining
                    break;
                case "20020070000": show_StatusLog(parent); // EmpStatusLog
                    break;
                case "20020080000": show_DMLog(parent); // EmpStatusLog
                    break;
                case "20020090000": show_LvLog(parent); // EmpStatusLog
                    break;
                case "20020100000": show_EmpVerify(parent); // EmpStatusLog
                    break;
                case "20020110000": show_EmpQry(parent); // EmpQry
                    break;
                case "20020120000": show_EmpMirror(parent); // Emp Mirroring
                    break;
                case "20020130000": show_EmpMonitor(parent); // Emp Mirroring
                    break;


                    // Salary Master
                case "20030010000": SALARYHEAD(parent);
                    break;
                case "20030020000": SALARYSTRUCTURE(parent);
                    break;

                    // Link Master
                case "20040010000": LinkDetails(parent);
                    break;
                case "20040020000": CompanyClint(parent); //FrmLinkCompanywiseClient
                    break;
                case "20040030000": Leave(parent); //Config_LeaveDetails
                    break;
                    //Employee
                case "30010000000": Attendence(parent); // frmEmpAttendance
                    break;
                case "30010000001": Attend(parent); // frmEmpAttendance
                    break;
                case "30020000000": Allotment_Details(parent);  //FrmAllocateEmployDetails
                    break;
                case "30210000000": ADDEARNINGREDUCTION(parent); //additional deduction
                    break;
                // Salary
                case "40010000000": SALARYCALCULATION(parent);
                    break;
                case "40020000000": ASSIGNHEADSSALSTRUCT(parent); //Employee_Heads_to_Structure
                    break;
                case "40030000000": ALLOTMENT(parent); // frmsalarystructure
                    break;
                case "40020000001": Adv_Emp(parent); //frmEmpAdvance
                    break;
                case "40020000002": Oth_Ded(parent); //frmEmpAdvance
                    break;
                case "40010000001": Assignlumpsum(parent); //lumsum assign
                    break;
                case "40030000001": SalPaid_unpaid(parent);
                    break;
                case "40030000002": LvAdj(parent);
                    break;
                case "40040000001": Society(parent);
                    break;
                case "40050000000": EXGRATIA(parent);
                    break;


                //Inventory

                    case "40040000002": Inv_Pur(parent);
                    break;
                    case "40040000003": Inv_PurRet(parent);
                    break;
                    case "40040000004": Inv_Issue(parent);
                    break;
                    case "40040000005": Inv_IssueRet(parent);
                    break;
                    case "40040000006": Inv_Damage(parent);
                    break;
                    case "40040000007": Inv_ClStock(parent);
                    break;


                //Transaction
                case "50010000000": ORDERDETAILS(parent); //frmorderdetails
                    break;
                case "50020000000": RETAIRMNTDTLS(parent);  //frmPayBill
                    break;
                case "50030000000": BillOp(parent);  //frmPayBill
                    break;
                case "50050000000": PAYMENADDRESS(parent);
                    break;
                    //Salary Rpt
                case "60010010001": STATEMNTEXGRATIA(parent); // frmEmployeeSalarySheet
                    break;
                case "60010010002": PAYSLIP(parent); // frmEmployeePaySlipRpt
                    break;
                case "60010010003": STATEMNTPFESI(parent); //frmEmployeePFESIReport
                    break;
                case "60010010004": STATEMNTPTAX(parent); // PTax
                    break;
                //case "60010010005": AQUITTANCE(parent);
                //    break;
                case "60010010006": PFReport1(parent);
                    break;
                case "60010010007": PFReport2(parent);
                    break;
                case "60010010008": PFReport3(parent);
                    break;
                case "60010010009": CompositePS(parent);
                    break;
                case "60010010015": sal_Month(parent);
                    break;
                case "60010010016": PFESI_Month(parent);
                    break;
                case "60010020000": PAYADVICE(parent); //frmEmployee_PayAdvice
                    break;
                case "60020000000": EncashmentReport(parent);
                    break;
                case "60030000000": LEAVESTATEMENT(parent);
                    break;
                case "60030000001": LeaveWageRpt(parent);
                    break;
                case "60040000000": BILLOFEXGRATIA(parent);
                    break;
                case "60050000000": INCREMENT(parent);
                    break;    

                    // Arear
                case "60060010000": ARREARPAYSLIP(parent);
                    break;
                case "60060020000": ARRBILL(parent);
                    break;
                case "60060030000": AQUITTANCE(parent);
                    break;
                    //Bill print
                case "60070000000": STATEMNTBILLPRNT(parent); // frmEmployeeBillReport
                    break;
                   //profit & loss
                //case "60090000000": RptProfLoss(parent);
                //    break;
                    //Grid Report

                case "60080010000": SECTIONMASTER(parent);
                    break;
                //dwipraj
                case "60080020000": PndingBillRpt(parent);
                    break;
                case "60080030000": GSTSTATEMENTGRIDRPT(parent);
                    break;
                case "60080040000": workflowRpt(parent);
                    break;
                case "60080050000": zoneRpt(parent);
                    break;
                case "60080060000": salbillRpt(parent);
                    break;
                    //Employee PF & ESI Report
                case "60100000000": RptEmpPfEsi(parent); //REPORTOFPF
                    break;

                case "60110000000": RptEmpJoin(parent);
                    break;

                case "60120000000": RptSalStructure(parent);
                    break;
                case "60130000000": RptAttendance(parent);
                    break;

                case "60130000001": RptBillAttendance(parent);
                    break;

                case "60140000000": RptHoliday(parent);
                    break;
                case "60150000000": RptEmpPost(parent);
                    break;
                //Anurag
                case "60160000000": RptEmpWiseJoinList(parent);
                    break;
                case "60170000000": RptBillL(parent); //BillingRRpt
                    break;

                case "60170000001": RptBillOut(parent); //14/08/2018
                    break;

                    //--18/07/2018
                case "60160000001": RptEmpList(parent);
                    break;


                case "60180000000": RptBankPayL(parent);//frmBankPayment
                    break;
                case "60190000000": RptKycExc(parent);
                    break;
                //Anurag
                case "60200000000": RptEmpAdv(parent); //frmAdvance
                    break;

                case "60210000000": RptUWL(parent); //frmAdvance
                    break;

                    // Configuration
                case "70010000000": SalarySheetPrintSetup(parent);
                    break;
                case "70011000000": ImpEmpExc(parent);
                    break;
                case "70012000000": DashBoard(parent);
                    break;


                //Anurag

                //Salary Rpt
                case "60010010010": PfEsiEligibility(parent);
                    break;
                case "60010010011": Bill_Register(parent);
                    break;
                case "60010010012": Order_Register(parent);
                    break;

                //Configuration
                case "70013000000": Company_Statistics(parent);
                    break;

                case "70014000000": auto_back_Path(parent);
                    break;
                case "70015000000": clrc(parent);
                    break;

                //Cheque
                case "80010000000": ChequeDetails(parent);
                    break;
               
                case "60010010014": ReportOfWages(parent);
                    break;
                case "60220000000": ReceiptRegisterReport(parent);
                    break;
                case "60230000000": BillOutstandingReport(parent);
                    break;
                case "60240000000": sal_Ledger(parent);
                    break;
                case "60250000000": chq_print(parent);
                    break;
                case "60260000000": ledger_rpt(parent);
                    break;
                case "60270000000": othrDed_rpt(parent);
                    break;


                case "60090000001":Inv_Rpt(parent,1);
                    break;

                case "60090000002": Inv_Rpt(parent, 2);
                    break;


                case "8000000001": Register_ot(parent);
                    break;
                case "8000000002": Register_fine(parent);
                    break;
                case "8000000003": Register_ded(parent);
                    break;
                case "8000000004": Register_adv(parent);
                    break;
                 case "8000000005": Register_attend(parent);
                    break;
                 case "8000000006": Register_workmen(parent);
                    break;
                 case "8000000007": Register_Bonus(parent);
                    break;
                 case "8000000008": Register_ICard(parent);
                    break;
                 case "8000000009": Register_Damage(parent);
                    break;
                 case "8000000010": RegisterOfWages(parent); //old  60010010013
                    break;

                 case "90000000001": about(parent); //old  60010010013
                    break;
                //======================================================================
                //  Central Register


                 case "8000000011": Central_Register(parent, "A"); //'Form A Employment'
                    break;
                 case "8000000012": Central_Register(parent, "B"); //'Form B Wages'
                    break;
                 case "8000000013": Central_Register(parent, "C"); //'Form C RECOVERY'
                    break;
                 case "8000000014": Central_Register(parent, "D"); //'Form D'
                    break;
                 case "8000000015": Central_Register(parent, "E");//'FORM E'
                    break;
                 case "8000000016": Central_Register(parent, "WS");//'Form XIX - WAGE SLIP'
                    break;
                 case "8000000017": Central_Register(parent, "EC");//'FORM XII - EMPLOYMENT CARD'
                    break;

                 case "8000000018": Central_Register(parent, "AR");//'FORM XII - EMPLOYMENT CARD'
                    break;

                    // State Register

                 case "8000000021": State_Register(parent, "Tamil");
                    break;
                //======================================================================

                /*
                case "20050000000": ENCASHMENT(parent);
                    break;

                case "50120300000": ARREARS(parent);
                    break;
                case "20080000000": ARRPAYSLIP(parent);
                    break;
                case "20090000000": PFLOAN(parent);
                    break;

                case "20110000000": TEMP(parent);
                    break;
                */
                                 //case "30180000000": EXGRATIAMASTER(parent);
                //    break;
                //case "30190000000": PTRATEEDITOR(parent);
                //    break;
                //case "30200000000": PFESIRATEEDITOR(parent);
                //    break;
                 
               //case "40010010000": PAYSLIP(parent);

                /* case "40010020000": BILL(parent);
                     break;
                               
                 case "40040000000": STATEMNTEXGRATIA(parent);
                     break;
                  */
                //////case "30230000000": Emp_Location(parent);
                //////    break;
                //case "3016000000": bill1Editor(parent);
                //    break;
                //case "40130000000": PAYADVICE(parent);
                


            }
        }
        //----------------------------- Inventory Report-----------------------------------------------------------------------------------
        private void Inv_Rpt(Form parent, int type)
        {
            frmInv_Rpt frow = new frmInv_Rpt(type);
            show_page(frow, parent);

        }
        //---------------------------- Display form After checking if activated in mdiform -------------------------------
        private void show_page(Form ob, Form parent)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == ob.Name)
                {
                    MessageBox.Show(ob.Text + " Already Opened,Please check", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            ob.MdiParent = parent;
            ob.Show();
        }
        //--------------26-10-2019 State Registers----------------------------------------------------------------------------------
        private void State_Register(Form parent, string type)
        {
            frm_register_tamil reg_A = new frm_register_tamil();
            
            if (type == "Tamil")
            {

                show_page(reg_A, parent);
            }
        }

        //--------------22-10-2019 CENTRAL REGISTERS--------------------------------------------------------------------------------

        private void Central_Register(Form parent, string type)
        {
            frm_register_employee reg_A = new frm_register_employee();
            frm_register_wage_FormB reg_B = new frm_register_wage_FormB();
            frm_register_FORM_XII reg_EC = new frm_register_FORM_XII();
            frm_Register_FrmD reg_fd = new frm_Register_FrmD();
            frm_Register_Recovery reg_rc = new frm_Register_Recovery();

            if (type == "A")
            {

                show_page(reg_A, parent);
            }
            else if (type == "B")
            {

                show_page(reg_B, parent);
            }
            else if (type == "C")
            {

                show_page(reg_rc, parent);
            }
            else if (type == "D")
            {

                show_page(reg_A, parent);
            }
            else if (type == "WS")
            {
                show_page(reg_A, parent);

            }
            else if (type == "EC")
            {

                show_page(reg_EC, parent);
            }
            else if (type == "AR")
            {

                show_page(reg_fd, parent);
            }
        }

        //==========================================================================================================
        
        
        
        
        
        private void about(Form parent)
        {
            frmAbout frow = new frmAbout();
            show_page(frow, parent);
        }




       private void Register_workmen(Form parent)
        {
            Reg_WrkMen wm = new Reg_WrkMen();
          show_page(wm, parent);

        }

       private void Register_Damage(Form parent)
       {
           Reg_Damage_Loss dr = new Reg_Damage_Loss();
           show_page(dr, parent);

       }


       private void Register_ICard(Form parent)
       {
           Reg_Icard wm = new Reg_Icard();
           show_page(wm, parent);

       }
       private void Register_Bonus(Form parent)
       {
           //Reg_Bonus wm = new Reg_Bonus();
           frmRegister_Bonus rb = new frmRegister_Bonus();
           show_page(rb, parent);
       }

private void Register_ot(Form parent)
{
    frmRegister_ot rot = new frmRegister_ot();
   show_page(rot, parent);
}
private void Register_fine(Form parent)
    {
        frmRegister_fine rfine = new frmRegister_fine();
       show_page(rfine, parent);
}
private void Register_ded(Form parent)
    {
        frmRegister_ded rded = new frmRegister_ded();
       show_page(rded, parent);
}
private void Register_adv(Form parent)
{
    Reg_Advance radv = new Reg_Advance();
show_page(radv, parent);
}
        private void Register_attend(Form parent)
        {
            Reg_Attend ratt = new Reg_Attend();
            show_page(ratt, parent);

        }
        private void sal_Ledger(Form parent)
        {
            frmPartyLedger pl =new frmPartyLedger();
           show_page(pl, parent);
        }

        private void chq_print(Form parent) //09_08_2018
        {
            frmCheque_print cp = new frmCheque_print();
            show_page(cp, parent);
        }

        private void ledger_rpt(Form parent) //18_09_2018
        {
            frmLedgerAccount cp = new frmLedgerAccount();
            show_page(cp, parent);
        }
        private void othrDed_rpt(Form parent) //18_09_2018
        {
            frmEmp_deduct_details cp = new frmEmp_deduct_details();
           show_page(cp, parent);
        }
        private void StatusMst(Form parent)
        {
            frmStatusMst stMst = new frmStatusMst();
            show_page(stMst, parent);
        }

        private void ShiftMst(Form parent)
        {
            frmShift sftMst = new frmShift();
           show_page(sftMst, parent);
        }
        private void EncMst(Form parent)
        {
            frmEnclosureList encMst = new frmEnclosureList();
           show_page(encMst, parent);
        }

        private void VrfyMst(Form parent)
        {
            VerifyStatus_Master encMst = new VerifyStatus_Master();
           show_page(encMst, parent);
        }

        private void PoliceMst(Form parent)
        {
            PoliceStationMaster encMst = new PoliceStationMaster();
           show_page(encMst, parent);
        }

        private void vendor(Form parent)
        {
            frmVendor vndr = new frmVendor();
            show_page(vndr, parent);
        }

        private void show_StatusLog(Form parent)
        {
            frmStatusLog stlog = new frmStatusLog();
          show_page(stlog, parent);
        }

        private void show_DMLog(Form parent)
        {
            frmDeploy DMlog = new frmDeploy();
           show_page(DMlog, parent);
        }

        //-------------- 30/05/2018
        private void show_LvLog(Form parent)
        {
            Mstleavebalance lvlog = new Mstleavebalance();
            show_page(lvlog, parent);
        }

        private void RegisterOfWages(Form parent)
        {
            frmRegisterOfWages_FormXVII frow = new frmRegisterOfWages_FormXVII();
            show_page(frow, parent);
        }

        private void ReportOfWages(Form parent)
        {
            frmEmpSalWage_Rpt frow = new frmEmpSalWage_Rpt();
           show_page(frow, parent);
        }

        //Anurag
        private void ChequeDetails(Form parent)
        {
            Cheque chqDet = new Cheque();
            show_page(chqDet, parent);
        }
        private void PfEsiEligibility(Form parent)
        {
            PF_ESI_Eligibility pf_esi = new PF_ESI_Eligibility();
           show_page(pf_esi, parent);
        }
        private void Bill_Register(Form parent)
        {
            Reg_Bill br = new Reg_Bill();
            show_page(br, parent);
        }
        private void Order_Register(Form parent)
        {
            Order_Register or = new Order_Register();
            show_page(or, parent);
        }
        private void Company_Statistics(Form parent)
        {
            Company_Statistics cs = new Company_Statistics();
           show_page(cs, parent);
        }

        //BIBHAS
        private void clrc(Form parent)
        {
            frmDeleteModule dm = new frmDeleteModule();
            show_page(dm, parent);
        }
        private void auto_back_Path(Form parent)
            {
            frmDbBack_Path db = new frmDbBack_Path();
            db.Auto_Back_Up_Path(true);
           show_page(db, parent);
        }
        private void workflowRpt(Form parent)
        {
            frmWorkflow fwf = new frmWorkflow();
           show_page(fwf, parent);
        }
        //17/03/2018
        private void zoneRpt(Form parent)
        {
            frmRptZone rz = new frmRptZone();
            show_page(rz, parent);
        }

        //14-06-2018 *joji
        private void salbillRpt(Form parent)
        {
            Bill_SalaryForm rz = new Bill_SalaryForm();
            show_page(rz, parent);
        }




        private void RptUWL(Form parent)
        {
            frmUserWorkLog fusrWL = new frmUserWorkLog();
            show_page(fusrWL, parent);
        }

        public void getCurLocID()
        {

            Edpcom.EDPCommon edpcom = new EDPCommon();
            // Edpcom.EDPConnection edpcon = new EDPConnection();

            try
            {
                //Retrive Current SuperUser and UserGroupCode
                edpcom.CurrentSuperuser = clsDataAccess.GetresultS("select superUser from usercontrol where  USER_CODE = '" + edpcom.PCURRENT_USER + "'").Trim();
                edpcom.CurrentUGcode = clsDataAccess.GetresultS("select ugcode from usercontrol where USER_CODE = '" + edpcom.PCURRENT_USER + "'").Trim();
                //End 03.04.14

                //Retrive Location Permition from current user
                edpcom.CurrentLocation = "";
                if (edpcom.PCURRENT_USER == "1" || edpcom.CurrentUserLev.ToUpper() == ("Superuser").ToUpper())
                {
                    DataTable dt_company = new DataTable();
                   dt_company= clsDataAccess.RunQDTbl("SELECT Location_ID FROM tbl_Emp_Location ");
                    for (int i = 0; i <= dt_company.Rows.Count - 1; i++)
                    {
                        edpcom.CurrentLocation = edpcom.CurrentLocation + Convert.ToString(dt_company.Rows[i]["Location_ID"]);
                        if (i < dt_company.Rows.Count - 1)
                            edpcom.CurrentLocation = edpcom.CurrentLocation + ",";
                    }

                }
                else
                {
                    DataTable dt_company = clsDataAccess.RunQDTbl("SELECT LOC_CODE FROM AccessLocation WHERE USER_CODE=" + edpcom.PCURRENT_USER + " and LOC_CODE !=0 ");
                    for (int i = 0; i <= dt_company.Rows.Count - 1; i++)
                    {
                        edpcom.CurrentLocation = edpcom.CurrentLocation + Convert.ToString(dt_company.Rows[i]["LOC_CODE"]);
                        if (i < dt_company.Rows.Count - 1)
                            edpcom.CurrentLocation = edpcom.CurrentLocation + ",";
                    }
                }

            }
            catch { }
            // edpcon.Close();
        }
        public void usrfunclist(string job)
        {
            Edpcom.EDPCommon edpcom = new EDPCommon();
            string ucode, gcode, opti, clti;
            ucode = edpcom.PCURRENT_USER;
            gcode = edpcom.PCURRENT_GCODE;
            opti = DateTime.Now.ToLongTimeString();
            clti = DateTime.Now.ToLongTimeString();
            string open_dt, close_dt;
            open_dt = edpcom.getSqlDateStr(DateTime.Today);
            close_dt = edpcom.getSqlDateStr(DateTime.Today);
            //edpcon.Open();
            //int xlsv;
            //if (Edpcom.EDPCommon.UserCount == 1)
            //    xlsv = 1;
            //else
            //    xlsv = 0;
            //string Sql = "insert into AccordFourlog(LOG_UCODE, LOG_GCODE, LOG_CCODE,FORM_NAME, FORM_CODE, DATE_FROM, TIME_FROM, DATE_TO, TIME_TO, LOG_STAT, MACHINE_NAME, Exclusive, session_no)";
            //Sql = Sql + "values('" + ucode + "','" + gcode + "','" + gcode + "','"+ job +"'," + 0 + ",'" + open_dt + "','" + opti + "','" + close_dt + "','" + clti + "'," + 0 + ",'" + Environment.MachineName + "'," + xlsv + "," + session + ")";
            //mycmd = new SqlCommand(Sql, edpcon.mycon);
            //mycmd.ExecuteNonQuery();
            //edpcon.Close();
        }

        //dwipraj
        private void PndingBillRpt(Form parent)
        {
            PendingBillReport pbr = new PendingBillReport();
            show_page(pbr, parent);
        }

       
        private void GSTSTATEMENTGRIDRPT(Form parent)
        {
            frmBillGSTDetailsDateWise fbgdw = new frmBillGSTDetailsDateWise();
            show_page(fbgdw, parent);
        }

        private void KITLOGMASTER(Form parent)
        {
            frm_Mst_Kit frmkit = new frm_Mst_Kit(1);
            show_page(frmkit, parent);
        }

        private void FineLog(Form parent)
        {
            frm_Mst_Kit frmkit = new frm_Mst_Kit(2);
            //frm_Mst_Fine frmkit = new frm_Mst_Fine();
            show_page(frmkit, parent);
        }

        //Inventory
        private void Inv_Pur(Form parent)
                {
                    frmKitPurchase ejs = new frmKitPurchase();

                    show_page(ejs, parent);
                }

        private void Inv_PurRet(Form parent)
                {
                    frmKitPurchaseReturn ejs = new frmKitPurchaseReturn();
                    show_page(ejs, parent);
                }

        private void Inv_Issue(Form parent)
                {
                    KIT_ISSUE ki = new KIT_ISSUE();
                    show_page(ki, parent);
                }

        private void Inv_IssueRet(Form parent)
                {
                    frmKitIssueReturn ejs = new frmKitIssueReturn();
                    show_page(ejs, parent);
                }

        private void Inv_Damage(Form parent)
                {
                    frmDamage fd = new frmDamage();
                    show_page(fd, parent);
                }

        private void Inv_ClStock(Form parent)
        {
            closing_stock cs = new closing_stock();
            show_page(cs, parent);
        }




        private void SACMASTER(Form parent)
        {
            frmCompanySACMaster csacm = new frmCompanySACMaster();
           show_page(csacm, parent);
        }

        private void Adv_Emp(Form parent)
        {
            try
            {
               frmEmpAdvance frmEmpAdv = new frmEmpAdvance();
               show_page(frmEmpAdv, parent);
            }
            catch
            {

            }
        }
        private void Oth_Ded(Form parent) // for force one - 03-05-2019
        {
            try
            {
                frmOtherDeduction frmOd = new frmOtherDeduction();
               show_page(frmOd, parent);
            }
            catch
            {

            }
        }
        //Dwipraj
        private void ReceiptRegisterReport(Form parent)
        {
            frmPaymentRegisterReport prr = new frmPaymentRegisterReport();
            show_page(prr, parent);
        }
        private void BillOutstandingReport(Form parent)
        {
            frmClientOutstandingReport cor = new frmClientOutstandingReport();
            show_page(cor, parent);
        }
        // Biplab

        private void RptEmpAdv(Form parent)
        {
            frmAdvance rptAdv = new frmAdvance();
            show_page(rptAdv, parent);

        }
        private void RptBankPayL(Form parent)
        {
            frmBankPayment frmbnkPL = new frmBankPayment("Q");
            show_page(frmbnkPL, parent);
        }

        private void RptKycExc(Form parent)
        {
            frmKYCException frmKycExc = new frmKYCException();
            show_page(frmKycExc, parent);
        }


        private void RptHoliday(Form parent)
        {
            frmHoliday frmhol = new frmHoliday();
            show_page(frmhol, parent);
        }

        private void RptEmpPost(Form parent)
        {
           // FRMCOMP frmEmpPst = new FRMCOMP();

            frmEmpPostingRpt frmEmpPst = new frmEmpPostingRpt();
           show_page(frmEmpPst, parent);
        }

        private void RptEmpList(Form parent)
        {
            frmempdetailsexport expList = new frmempdetailsexport();
            show_page(expList, parent);
        }
        private void RptEmpWiseJoinList(Form parent)
        {
            EmpWiseJoiningRpt EmpJList = new EmpWiseJoiningRpt();
            show_page(EmpJList, parent);
        }

        private void RptBillL(Form parent)
        {
            BillingRRpt frmbillR = new BillingRRpt();
            show_page(frmbillR, parent);
        }

        private void RptBillOut(Form parent)
        {
            BillOutstandingReport frmbillO = new BillOutstandingReport();
            show_page(frmbillO, parent);
        }



        private void RptSalStructure(Form parent)
        {
            Assignheadsalstru SalStr = new Assignheadsalstru();
            show_page(SalStr, parent);
        }
        private void RptAttendance(Form parent)
        {
            FrmAttRpt attRpt = new FrmAttRpt();
            show_page(attRpt, parent);
        }

        private void RptBillAttendance(Form parent)
        {
            frmAttendBill_diff attRpt = new frmAttendBill_diff();
            show_page(attRpt, parent);
        }


        private void PAYMENADDRESS(Form parent)
        {//change made by Dwipraj dutta 090820170350PM
            
            PaymentRegisterForm prf = new PaymentRegisterForm();
            show_page(prf, parent);
            
        }

        private void RptEmpJoin(Form parent)
        {
            EmpBio_Icard empJ = new EmpBio_Icard();
            show_page(empJ, parent);
        }
        // Bibhas
        private void DashBoard(Form parent)
        {
            frmDashboard dsbrd = new frmDashboard();
            dsbrd.ShowDialog();
        }
        private void ImpEmpExc(Form parent)
        {
            frmEmpJoinExcel impexcel = new frmEmpJoinExcel();
            show_page(impexcel, parent);
        }
        private void RptProfLoss(Form parent)
        {
            frmEmployee_ProfitLossReport pl = new frmEmployee_ProfitLossReport("Q");
            show_page(pl, parent);
        }

        private void RptEmpPfEsi(Form parent)
        {
            REPORTOFPF EsiPf = new REPORTOFPF();
            show_page(EsiPf, parent);


        }
        //==========================================================================


        private void PFESI_Month(Form parent)
        {
            frmPfEsiMonthly pem = new frmPfEsiMonthly();
            show_page(pem, parent);

        }
        private void sal_Month(Form parent)
        {
            frmSalMonthly sm = new frmSalMonthly();
            show_page(sm, parent);

        }



        private void CompositePS(Form parent)
        {
            frmEmployeeCompositePaySlipRpt comps = new frmEmployeeCompositePaySlipRpt("1");
            show_page(comps, parent);

        }
        private void PAYADVICE(Form parent)
        {
            frmEmployee_PayAdvice soe = new frmEmployee_PayAdvice("Q");
            show_page(soe, parent);

        }

        private void Aclink(Form parent)
        {
            frmficodegenarate FB = new frmficodegenarate();
            show_page(FB, parent);
        }

        private void Leave(Form parent)
        {
            Config_LeaveDetails FB = new Config_LeaveDetails();
            show_page(FB, parent);
        }

        private void Session(Form parent)
        {
            Frmsession FB = new Frmsession();
            show_page(FB, parent);
        }

        private void AccountTransfer(Form parent)
        {
            frmEmployeeAccount FB = new frmEmployeeAccount();
            show_page(FB, parent);
        }
        private void DocNumber(Form parent)
        {
            frmAccountPosting FB = new frmAccountPosting();
            show_page(FB, parent);
        }

              


        public void listBoxStatus(ListBox Lst)
        {
            lb = Lst;
        }

        private void PtaxEditor(Form parent)
        {
            frmPTRateEditor FB = new frmPTRateEditor();
            show_page(FB, parent);
        }

        private void bill1Editor(Form parent)
        {
            frmPayBill FB = new frmPayBill();
            show_page(FB, parent);
        }


        private void show_PTO(Form parent)
        {
            EmpJoining EJ = new EmpJoining();
            show_page(EJ, parent);
        }

        private void STATEMNTPFESI(Form parent)
        {
            frmEmployeePFESIReport soe = new frmEmployeePFESIReport("Q");
            show_page(soe, parent);
        }

        private void STATEMNTPTAX(Form parent)
        {
            frmEmployeePTAXReport soe = new frmEmployeePTAXReport("Q");
            show_page(soe, parent);

        }

        private void STATEMNTBILLPRNT(Form parent)
        {
            //frmEmployeeBillReport soe = new frmEmployeeBillReport("Q");
            //frmEmployeeBillReportO soe = new frmEmployeeBillReportO("Q");
            Multi_Bill_Print soe = new Multi_Bill_Print("Q");
            show_page(soe, parent);

        }

        private void Attend(Form parent)
        {
           // frmEmpAttendance FB = new frmEmpAttendance();
             frmEmpAttend FB1 = new frmEmpAttend();
             show_page(FB1, parent);
        }

        private void Attendence(Form parent)
        {
            //frmEmpAttend_daily FB = new frmEmpAttend_daily();
           frmEmpAttendance FB = new frmEmpAttendance();
           show_page(FB, parent);
        }

        private void ESI(Form parent)
        {
            FrmESICode inc = new FrmESICode();
            show_page(inc, parent);
        }

        private void PTX(Form parent)
        {
            FrmPTAXCode inc = new FrmPTAXCode();
            show_page(inc, parent);
        }

        private void CompanyClint(Form parent)
        {
            FrmLinkCompanywiseClient inc = new FrmLinkCompanywiseClient();
            show_page(inc, parent);
        }

        private void ALLOTMENT(Form parent)
        {
            //EmployeeSalaryDetails empsal = new EmployeeSalaryDetails();
            frmsalarystructure empsal = new frmsalarystructure();
            show_page(empsal, parent);                   
        }

        private void SALINCREMENT(Form parent)
        {
            IncrementSalary inc = new IncrementSalary();
            inc.MdiParent = parent;
            inc.ShowDialog();
        }

        private void ENCASHMENT(Form parent)
        {
            LeaveEncashment lcash = new LeaveEncashment();
            lcash.ShowDialog();
        }

        private void EXGRATIA(Form parent)
        {
            //frmsalarystructure exg_cal = new frmsalarystructure();
            //ExgratiaCalculation exg_cal = new ExgratiaCalculation();
            //exg_cal.ShowDialog();
        }

        private void ARREARS(Form parent)
        {
            Arrears ar = new Arrears();
            ar.ShowDialog();
        }

        private void ARRPAYSLIP(Form parent)
        {
            ArrearPaySlip ap = new ArrearPaySlip();
            ap.ShowDialog();
        }

        private void PFLOAN(Form parent)
        {
            frmPFLoan mpl = new frmPFLoan();
            show_page(mpl, parent);
        }

        private void HOLIDAY(Form parent)
        {
            frmHolidayEntry mpl2 = new frmHolidayEntry();
            show_page(mpl2, parent);

        }
        private void TEMP(Form parent)
        {
            MnthlySalRate msr = new MnthlySalRate();
            show_page(msr, parent);
        }
        private void SalarySheetPrintSetup(Form parent)
        {
            frm_salary_print_setup inc = new frm_salary_print_setup();
            show_page(inc, parent);
        }
        
        private void ORDERDETAILS(Form parent)
        {
            frmorderdetails od = new frmorderdetails();
            show_page(od, parent);           
        }
        private void COUNTRYMASTER(Form parent)
        {
            Countrymaster exg = new Countrymaster();
            show_page(exg, parent);
        }

        private void STATEMASTER(Form parent)
        {
            statemaster exg = new statemaster();
            show_page(exg, parent);
        }
        private void ZoneMASTER(Form parent)
        {
            frmZone zone = new frmZone();
            show_page(zone, parent);
        }
        private void HOURMASTER(Form parent)
        {
            Hrmaster exg = new Hrmaster();
            show_page(exg, parent);
        }

        private void MONTHOFDAYSMASTER(Form parent)
        {
            MonthOfDays exg = new MonthOfDays();
            show_page(exg, parent);
        }        

        private void COMPANYMASTER(Form parent)
        {
            FrmcompanyMasterQuery exg = new FrmcompanyMasterQuery();
            show_page(exg, parent);
        }
               

        private void CLIENTMASTER(Form parent)
        {
            frmcontractPartyMaster exg = new frmcontractPartyMaster();
            show_page(exg, parent);
        }
        private void LOCSITEMASTER(Form parent)
        {
            FrmLocationMaster lm = new FrmLocationMaster();
            show_page(lm, parent);
        }
        private void JOBMASTER(Form parent)
        {
            Employee_Type emptype = new Employee_Type();
            show_page(emptype, parent);
        }
        private void DESIGNATIONMASTER(Form parent)
        {
            Designation_Master designation = new Designation_Master();
            show_page(designation, parent);
        }
        private void Qualificationmaster(Form parent)
        {
            Qualificationmaster exg = new Qualificationmaster();
            show_page(exg, parent);
           

        }
        
        private void RELATIONMASTER(Form parent)
        {
            Relation_Master exg = new Relation_Master();
            show_page(exg, parent);
            
        }
        private void SECTIONMASTER(Form parent)
        {
            FrmlocationQuery sec = new FrmlocationQuery();
            show_page(sec, parent);

        }
        private void SALARYHEAD(Form parent)
        {
            Salary_Head objempsalaryhead = new Salary_Head();
            show_page(objempsalaryhead, parent);

        }
        private void SALARYSTRUCTURE(Form parent)
        {
            Employee_Salary_Structure objempsalarystruct = new Employee_Salary_Structure();
            show_page(objempsalarystruct, parent);

        }
        private void SALARYCALCULATION(Form parent)
        {
            Config_SalaryStructure_Formula css = new Config_SalaryStructure_Formula();
            show_page(css, parent);
        }
        private void ASSIGNHEADSSALSTRUCT(Form parent)
        {
            frmSalaryStructure_Define hts = new frmSalaryStructure_Define();
            show_page(hts, parent);

        }

        private void Assignlumpsum(Form parent)
        {
            Lumpsum_definer ld = new Lumpsum_definer();
            show_page(ld, parent);
        }

        private void SalPaid_unpaid(Form parent)
        {
            frmSalaryPaid fsp = new frmSalaryPaid();
            show_page(fsp, parent);

        }

        private void LvAdj(Form parent)
        {
            frmLvEncashment fsp = new frmLvEncashment();
            show_page(fsp, parent);
        }


        private void Society(Form parent)
        {
            frmEmpSociety fsp = new frmEmpSociety(); // Employee Society
            show_page(fsp, parent);
        }

        private void LEAVEDETAILS(Form parent)
        {
            FrmPFCode lv = new FrmPFCode();
            show_page(lv, parent);
        }
        private void EXGRATIAMASTER(Form parent)
        {
            Config_ExGratia exg = new Config_ExGratia();
            show_page(exg, parent);

        }
        private void PTRATEEDITOR(Form parent)
        {
            frmPTRateEditor Rate = new frmPTRateEditor();
            show_page(Rate, parent);

        }
        private void PFESIRATEEDITOR(Form parent)
        {
            Config_PFandESI pf = new Config_PFandESI();
            show_page(pf, parent);
        }
        private void ADDEARNINGREDUCTION(Form parent)
        {
            frmAddErnDeduc earn=new frmAddErnDeduc();
            show_page(earn, parent);
        }
        private void RETAIRMNTDTLS(Form parent)
        {            
            frmPayBill rd = new frmPayBill();
            show_page(rd, parent);
        }

        private void BillOp(Form parent)
        {            
            frmBillOpening rd = new frmBillOpening();
            show_page(rd, parent);
        }

        private void EMPPAYBILL(Form parent)
        {
            Config_RetirementDetails rd = new Config_RetirementDetails();
            show_page(rd, parent);

        }

        private void PAYSLIP(Form parent)
        {
            frmEmployeePaySlipRpt ps = new frmEmployeePaySlipRpt("");
            show_page(ps, parent);

        }
        private void BILL(Form parent)
        {
            Salary_Bill sb = new Salary_Bill();
            show_page(sb, parent);
        }
        private void AQUITTANCE(Form parent)
        {
            
            AquittanceReport ar = new AquittanceReport();
            show_page(ar, parent);

        }
        private void PFReport1(Form parent)
        {
            PFReport1 pf = new PFReport1();
            show_page(pf, parent);

        }
        private void PFReport2(Form parent)
        {
            PFReport2 PF = new PFReport2();
            show_page(PF, parent);

        }
        private void PFReport3(Form parent)
        {
            PFReport3 PF = new PFReport3();
            show_page(PF, parent);

        }
        private void EncashmentReport(Form parent)
        {
            Report_LeaveEnCashment lec = new Report_LeaveEnCashment();
            show_page(lec, parent);

        }
        private void LEAVESTATEMENT(Form parent)
        {
            Leave_Statement ls = new Leave_Statement();
            show_page(ls, parent);

        }
        private void LeaveWageRpt(Form parent)
        {
            frmLeaveCompositeRpt ls = new frmLeaveCompositeRpt();
            show_page(ls, parent);

        }

        private void STATEMNTEXGRATIA(Form parent)
        {
            frmEmployeeSalarySheet soe = new frmEmployeeSalarySheet("Q");
            show_page(soe, parent);

         
        }
        private void BILLOFEXGRATIA(Form parent)
        {
            Bill_of_Exgratia be = new Bill_of_Exgratia();
            show_page(be, parent);

        }
        private void INCREMENT(Form parent)
        {
            Increment inc = new Increment();
            show_page(inc, parent);

        }
        
        private void ARREARPAYSLIP(Form parent)
        {
            ArrearPaySlipReport apr = new ArrearPaySlipReport();
            show_page(apr, parent);

        }
        private void ARRBILL(Form parent)
        {
            ArrearBillReport ab = new ArrearBillReport();
            show_page(ab, parent);

        }

        private void LinkDetails(Form parent)
        {
            Employ_Link_LocationSalary ls = new Employ_Link_LocationSalary();
            show_page(ls, parent);
        }
        private void Allotment_Details(Form parent)
        {
            FrmAllocateEmployDetails exg = new FrmAllocateEmployDetails();
            show_page(exg, parent);
        }
        private void Emp_Location(Form parent)
        {
            FrmlocationQuery lq = new FrmlocationQuery();
            show_page(lq, parent);
        }


        private void show_EmpVerify(Form parent)  // 09_08_2018
        {
            frmEmp_Verification lvlog = new frmEmp_Verification();
            show_page(lvlog, parent);
        }

        private void show_EmpQry(Form parent)  // 27_11_2020
        {
            frmEmpQryE EQry = new frmEmpQryE();
            show_page(EQry, parent);
        }


        private void show_EmpMirror(Form parent)  // 09-08-2021
        {
            frmEmpMirroring mEmp = new frmEmpMirroring();
            show_page(mEmp, parent);
        }

        private void show_EmpMonitor(Form parent)  // 14-08-2021
        {
            frmEmpMonitor mEmp = new frmEmpMonitor();
            show_page(mEmp, parent);
        }
        
    
    }
}
