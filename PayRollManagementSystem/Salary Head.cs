using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class Salary_Head : EDPComponent.FormBaseERP
    {
        Edpcom.EDPCommon EDPComm = new Edpcom.EDPCommon();
        Edpcom.EDPConnection EDPConn = new Edpcom.EDPConnection();
        DataSet ds = new DataSet();
        public Salary_Head()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Function

        private Boolean SubmitErnDetails()
        {
            Boolean boolStatus = false;
            int Ledger_Code = 0, gs = 0, nocpl = 0;

            string strSlNo="",strFull ="",strShort ="",strAmount="";
            
            if (dgErn.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgErn.Rows.Count - 1; i++)
                {
                    Ledger_Code = 0; gs = 0; nocpl = 0;
                    strSlNo = Convert.ToString(dgErn.Rows[i].Cells["ESlNo"].Value);
                    strFull = Convert.ToString(dgErn.Rows[i].Cells["EFull"].Value);
                    strShort = Convert.ToString(dgErn.Rows[i].Cells["EShort"].Value);
                    strAmount = Convert.ToString(dgErn.Rows[i].Cells["EAmount"].Value);
                    try
                    {
                        gs = Convert.ToInt32(dgErn.Rows[i].Cells["GS"].Value);
                    }
                    catch
                    {
                        gs = 0;
                    }

                    try
                    {
                        nocpl = Convert.ToInt32(dgErn.Rows[i].Cells["eNC"].Value);
                    }
                    catch
                    {
                        nocpl = 0;
                    }
                    if (Information.IsNumeric(dgErn.Rows[i].Cells["glcodeE"].Value) == true)
                        Ledger_Code = Convert.ToInt32(dgErn.Rows[i].Cells["glcodeE"].Value);

                    if (!String.IsNullOrEmpty(strFull))
                    {
                        if (String.IsNullOrEmpty(strAmount))
                        {
                            strAmount = "0.0";
                        }
                        if (!String.IsNullOrEmpty(strSlNo))
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_ErnSalaryHead set SalaryHead_Full='" + strFull + "',SalaryHead_Short='" + strShort + "',Amount=" + strAmount + ",Glcode='" + Ledger_Code + "',gs=" + gs + ",nocpl=" + nocpl + " where (SlNo=" + strSlNo + ")");

                            if (boolStatus==true)
                            {
                                clsDataAccess.RunNQwithStatus("update tbl_Employee_Assign_SalStructure set gs=" + gs + " where (SAL_HEAD=" + strSlNo + ") and (P_TYPE='E') and (Lock=0)");
                            }
                        }
                        else
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_ErnSalaryHead(SalaryHead_Full,SalaryHead_Short,Amount,Glcode,gs,nocpl) values('" + strFull + "','" + strShort + "'," + strAmount + ",'" + Ledger_Code + "','" + gs + "','" + nocpl + "')");
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Salary Head ( Full Name ) for " + i + "th Row.");
                    }
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Save For 'Salary Head of Employee Earning'");
            }
            return boolStatus;
        }

        private Boolean SubmitContributionDetails()
        {
            Boolean boolStatus = false;
            string oth_head = "";
            if (dgPfContribution.Rows.Count > 1)
            {
                for (Int32 i = 0; i <= dgPfContribution.Rows.Count - 1; i++)
                {
                    int Ledger_Code = 0;
                    String strSlNo = Convert.ToString(dgPfContribution.Rows[i].Cells["CSlNo"].Value);
                    String strFull = Convert.ToString(dgPfContribution.Rows[i].Cells["Cfull"].Value);
                    String strShort = Convert.ToString(dgPfContribution.Rows[i].Cells["Cshort"].Value);
                    String strAmount = Convert.ToString(dgPfContribution.Rows[i].Cells["CAmount"].Value);
                    if (Information.IsNumeric(dgPfContribution.Rows[i].Cells["CGlcode"].Value) == true)
                        Ledger_Code = Convert.ToInt32(dgPfContribution.Rows[i].Cells["CGlcode"].Value);

                    if (oth_head == "")
                    {
                        oth_head = "'" + strAmount + "'";
                    }
                    else
                    {
                        oth_head = oth_head+",'" + strAmount + "'";
                    }


                    if (!String.IsNullOrEmpty(strFull))
                    {
                        if (String.IsNullOrEmpty(strAmount))
                        {
                            strAmount = "0.0";
                        }
                        if (!String.IsNullOrEmpty(strSlNo))
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employer_Contribution set SalaryHead_Full='" + strFull + "',SalaryHead_Short='" + strFull + "',Amount=" + strAmount + ",Glcode='" + Ledger_Code + "' where SlNo=" + strSlNo + "");
                        }
                        else
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employer_Contribution(SalaryHead_Full,SalaryHead_Short,Amount,Glcode) values('" + strFull + "','" + strFull + "'," + strAmount + ",'" + Ledger_Code + "')");
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Salary Head ( Full Name ) for " + i + "th Row.");
                    }
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Save For 'Salary Head of Employee Earning'");
                
            }
            if (boolStatus == true)
            {
                if (dg_pf_emp_cont.Rows.Count > 1)
                {
                    for (Int32 i = 0; i <= dg_pf_emp_cont.Rows.Count - 1; i++)
                    {
                        int Ledger_Code = 0;
                        String strSlNo = Convert.ToString(dg_pf_emp_cont.Rows[i].Cells["ecSlNo"].Value);
                        String strFull = Convert.ToString(dg_pf_emp_cont.Rows[i].Cells["ecfull"].Value);
                        String strShort = Convert.ToString(dg_pf_emp_cont.Rows[i].Cells["ecshort"].Value);
                        String strAmount = Convert.ToString(dg_pf_emp_cont.Rows[i].Cells["ecAmount"].Value);
                        if (Information.IsNumeric(dg_pf_emp_cont.Rows[i].Cells["ecGlcode"].Value) == true)
                            Ledger_Code = Convert.ToInt32(dg_pf_emp_cont.Rows[i].Cells["ecGlcode"].Value);

                        if (oth_head == "")
                        {
                            oth_head = "'" + strAmount + "'";
                        }
                        else
                        {
                            oth_head = oth_head + ",'" + strAmount + "'";
                        }


                        if (!String.IsNullOrEmpty(strFull))
                        {
                            if (String.IsNullOrEmpty(strAmount))
                            {
                                strAmount = "0.0";
                            }
                            if (!String.IsNullOrEmpty(strSlNo))
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Contribution set SalaryHead_Full='" + strFull + "',SalaryHead_Short='" + strFull + "',Amount=" + strAmount + ",Glcode='" + Ledger_Code + "' where SlNo=" + strSlNo + "");
                            }
                            else
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Contribution(SalaryHead_Full,SalaryHead_Short,Amount,Glcode) values('" + strFull + "','" + strFull + "'," + strAmount + ",'" + Ledger_Code + "')");
                            }
                        }
                        else
                        {
                            ERPMessageBox.ERPMessage.Show("Please Enter Salary Head ( Full Name ) for " + i + "th Row.");

                        }
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("No Record To Save For 'Salary Head of Employee Earning'");
                }
            }


            if (boolStatus == true)
            {
                string qry = "insert into tbl_employee_contribution_details(slno ,ecdt,ac02 ,ac21,ac22,ac01,ac10)values "+
                 "((select max(slno)+1 from tbl_employee_contribution_details),cast(convert(datetime,GETDATE(),103) as datetime),"+oth_head+")";
                clsDataAccess.RunNQwithStatus(qry);

            }

            return boolStatus;
        }
        private Boolean SubmitDeductionDetails()
        {
            Boolean boolStatus = false;
            int nocpl = 0, Ledger_Code = 0, pre = 0;
            String strSlNo = ""; String strFull = ""; String strShort = ""; String strAmount = "0";

            if (dgDeduction.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgDeduction.Rows.Count - 1; i++)
                {
                    Ledger_Code = 0; pre = 0;
                    nocpl = 0;
                     strSlNo = Convert.ToString(dgDeduction.Rows[i].Cells["DSlNo"].Value);
                     strFull = Convert.ToString(dgDeduction.Rows[i].Cells["DFull"].Value);
                     strShort = Convert.ToString(dgDeduction.Rows[i].Cells["DShort"].Value);
                     strAmount = Convert.ToString(dgDeduction.Rows[i].Cells["DAmount"].Value);
                    if (Information.IsNumeric(dgDeduction.Rows[i].Cells["glcodeD"].Value) == true)
                        Ledger_Code = Convert.ToInt32(dgDeduction.Rows[i].Cells["glcodeD"].Value);

                    try
                    {
                        pre = Convert.ToInt32(dgDeduction.Rows[i].Cells["pre"].Value);
                    }
                    catch
                    {
                        pre = 0;
                    }

                    
                    try
                    {
                        nocpl = Convert.ToInt32(dgDeduction.Rows[i].Cells["dNC"].Value);
                    }
                    catch
                    {
                        nocpl = 0;
                    }
                    if (!String.IsNullOrEmpty(strFull))
                    {
                        if (String.IsNullOrEmpty(strAmount))
                        {
                            strAmount = "0.0";
                        }
                        if (!String.IsNullOrEmpty(strSlNo))
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_DeductionSalayHead set SalaryHead_Full='" + strFull + "',SalaryHead_Short='" + strShort + "',Amount=" + strAmount + ",Glcode=" + Ledger_Code + ",pre='" + pre + "',nocpl='" + nocpl + "' where SlNo=" + strSlNo + "");
                        }
                        else
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_DeductionSalayHead(SalaryHead_Full,SalaryHead_Short,Amount,Glcode,pre,nocpl) values('" + strFull + "','" + strShort + "'," + strAmount + ",'" + Ledger_Code + "','" + pre + "','" + nocpl + "')");
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Salary Head ( Full Name ) for " + i + "th Row.");
                    }
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Save For 'Salary Head For Employees's Salary Deduction'");
            }
            return boolStatus;
        }

        private void GetErnDetails()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select SlNo,SalaryHead_Full,SalaryHead_Short,Amount,Glcode,gs,nocpl as eNC from tbl_Employee_ErnSalaryHead");
            if (dt.Rows.Count > 0)
            {
                dgErn.DataSource = dt;
                DataView dv = new DataView(ds.Tables["config"]);
                for (int i = 0; i <= dgErn.Rows.Count - 2; i++)
                {
                    dv.RowFilter = "glcode='" + dt.Rows[i]["glcode"] + "'  ";
                    if (dv.Count > 0)
                    {
                        dgErn.Rows[i].Cells["ELedger"].Value = dv[0]["ldesc"];
                        dgErn.Rows[i].Cells["glcodeE"].Value = dt.Rows[i]["glcode"];
                    }
                    else
                    {
                        dgErn.Rows[i].Cells["ELedger"].Value = "";
                        dgErn.Rows[i].Cells["glcodeE"].Value = 0;
                    }
                }
            }
            //FreezeBand(dgErn.Rows[dgErn.Rows.Count - 2]);
        }

        private void GetEmpContribution()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select SlNo,SalaryHead_Full,SalaryHead_Short,Amount,Glcode from tbl_Employer_Contribution");
            if (dt.Rows.Count > 0)
            {

                dgPfContribution.DataSource = dt;
                dgPfContribution.Columns["CSlNo"].Visible = false;

                DataView dv = new DataView(ds.Tables["config"]);
                for (int i = 0; i <= dgPfContribution.Rows.Count - 2; i++)
                {
                    dv.RowFilter = "glcode='" + dt.Rows[i]["glcode"] + "'  ";
                    if (dv.Count > 0)
                    {
                        dgPfContribution.Rows[i].Cells["CLedger"].Value = dv[0]["ldesc"];
                        dgPfContribution.Rows[i].Cells["CGlcode"].Value = dt.Rows[i]["glcode"];
                    }
                    else
                    {
                        dgPfContribution.Rows[i].Cells["CLedger"].Value = "";
                        dgPfContribution.Rows[i].Cells["CGlcode"].Value = 0;
                    }
                }
            }



            dt = clsDataAccess.RunQDTbl("select SlNo,SalaryHead_Full,SalaryHead_Short,Amount,Glcode from tbl_Employee_Contribution");
            if (dt.Rows.Count > 0)
            {

                dg_pf_emp_cont.DataSource = dt;
                dg_pf_emp_cont.Columns["ecSlNo"].Visible = false;

                DataView dv = new DataView(ds.Tables["config"]);
                for (int i = 0; i <= dg_pf_emp_cont.Rows.Count - 2; i++)
                {
                    dv.RowFilter = "glcode='" + dt.Rows[i]["glcode"] + "'  ";
                    if (dv.Count > 0)
                    {
                        dg_pf_emp_cont.Rows[i].Cells["ecLedger"].Value = dv[0]["ldesc"];
                        dg_pf_emp_cont.Rows[i].Cells["ecGlcode"].Value = dt.Rows[i]["glcode"];
                    }
                    else
                    {
                        dg_pf_emp_cont.Rows[i].Cells["ecLedger"].Value = "";
                        dg_pf_emp_cont.Rows[i].Cells["ecGlcode"].Value = 0;
                    }
                }
            }


            //   FreezeBand(dgPfContribution.Rows[dgPfContribution.Rows.Count-1]);
        }

        private void GetDeductionDetails()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select SlNo,SalaryHead_Full,SalaryHead_Short,Amount,Glcode,pre,nocpl as dNC from tbl_Employee_DeductionSalayHead");
            if (dt.Rows.Count > 0)
            {
                dgDeduction.DataSource = dt;
                DataView dv = new DataView(ds.Tables["config2"]);
                for (int i = 0; i <= dgDeduction.Rows.Count - 2; i++)
                {
                    dv.RowFilter = "Glcode='" + Convert.ToString(dt.Rows[i]["Glcode"])+ "'  ";
                    if (dv.Count > 0)
                    {
                        dgDeduction.Rows[i].Cells["DLedger"].Value = dv[0]["ldesc"];
                        dgDeduction.Rows[i].Cells["glcodeD"].Value = Convert.ToString(dt.Rows[i]["Glcode"]);
                       // dgDeduction.Rows[i].Cells["pre"].Value = dt.Rows[i]["pre"];
                    }
                    else
                    {
                        dgDeduction.Rows[i].Cells["DLedger"].Value = "";
                        dgDeduction.Rows[i].Cells["glcodeD"].Value = 0;
                        //dgDeduction.Rows[i].Cells["pre"].Value = 0;
                    }
                }
            }
        }

        private Boolean DeleteErnDetails()
        {
           Boolean boolStatus=false;
           if (dgErn.Rows.Count > 1)
           {
               String strSlNo = Convert.ToString(dgErn.CurrentRow.Cells["ESlNo"].Value);
               String strFull = Convert.ToString(dgErn.CurrentRow.Cells["EFull"].Value);
               String strShort = Convert.ToString(dgErn.CurrentRow.Cells["EShort"].Value);

               if (!String.IsNullOrEmpty(strSlNo))
               {
                   if (clsDataAccess.GetresultS("Select count(*) from tbl_Employee_Assign_SalStructure where (Sal_Head='" + strSlNo + "')") == "0")
                   {
                       boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_ErnSalaryHead where SlNo=" + strSlNo + "");
                   }
                   else
                   {
                       ERPMessageBox.ERPMessage.Show("Salary Head Does Can Not be deleted, already assigned in salary structure");
                   }
               }
               else
               {
                   ERPMessageBox.ERPMessage.Show("Salary Head Does Not Exists");
               }
           }
           else
           {
               ERPMessageBox.ERPMessage.Show("No Record To Delete.");
           }
            return boolStatus;
        }
        private Boolean DeleteContributeDetails()
        {
            Boolean boolStatus = false;
            if (dgPfContribution.Rows.Count > 1)
            {

                String strSlNo = Convert.ToString(dgPfContribution.CurrentRow.Cells["CSlNo"].Value);
                String strFull = Convert.ToString(dgPfContribution.CurrentRow.Cells["Cfull"].Value);
                String strShort = Convert.ToString(dgPfContribution.CurrentRow.Cells["Cshort"].Value);

                if (!String.IsNullOrEmpty(strSlNo))
                {
                    boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employer_Contribution where SlNo=" + strSlNo + "");
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Salary Head Does Not Exists");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Delete.");
            }
            return boolStatus;
        }

        private Boolean DeleteDeductionDetails()
        {
            Boolean boolStatus = false;
            if (dgDeduction.Rows.Count > 1)
            {
                String strSlNo = Convert.ToString(dgDeduction.CurrentRow.Cells["DSlNo"].Value);
                String strFull = Convert.ToString(dgDeduction.CurrentRow.Cells["DFull"].Value);
                String strShort = Convert.ToString(dgDeduction.CurrentRow.Cells["DShort"].Value);

                if (!String.IsNullOrEmpty(strSlNo))
                {
                    if (clsDataAccess.GetresultS("Select count(*) from tbl_Employee_Assign_SalStructure where (Sal_Head='" + strSlNo + "')") == "0")
                    {
                        boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_DeductionSalayHead where SlNo=" + strSlNo + "");
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Salary Head Does Can Not be deleted, already assigned in salary structure");
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Salary Head Does Not Exists");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Delete.");
            }
            return boolStatus;
        }

        //private Boolean DeletePFHead()
        //{
        //    Boolean boolStatus = false;
        //    if (dgPF.Rows.Count > 1)
        //    {
        //        String strSlNo = Convert.ToString(dgPF.CurrentRow.Cells["PF_SlNo"].Value);
        //        String strFull = Convert.ToString(dgPF.CurrentRow.Cells["PF_HeadFull"].Value);
        //        String strShort = Convert.ToString(dgPF.CurrentRow.Cells["PF_Short"].Value);

        //        if (!String.IsNullOrEmpty(strSlNo))
        //        {
        //            boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Config_PFHeads where SlNo=" + strSlNo + "");
        //        }
        //        else
        //        {
        //            ERPMessageBox.ERPMessage.Show("P.F. Head Does Not Exists");
        //        }
        //    }
        //    else
        //    {
        //        ERPMessageBox.ERPMessage.Show("No Record To Delete.");
        //    }
        //    return boolStatus;
        //}

        //private void GetPFHeads()
        //{
        //    DataTable dt = clsDataAccess.RunQDTbl("select SlNo,PFHead,ShortName from tbl_Employee_Config_PFHeads");
        //    if (dt.Rows.Count > 0)
        //    {
        //        dgPF.DataSource = dt;
        //    }
        //}


        //private Boolean SubmitPFHeads()
        //{
        //    Boolean boolStatus = false;
        //    if (dgPF.Rows.Count > 1)
        //    {
        //        for (Int32 i = 0; i < dgPF.Rows.Count - 1; i++)
        //        {
        //            String strSlNo = Convert.ToString(dgPF.Rows[i].Cells["PF_SlNo"].Value);
        //            String strFull = Convert.ToString(dgPF.Rows[i].Cells["PF_HeadFull"].Value);
        //            String strShort = Convert.ToString(dgPF.Rows[i].Cells["PF_Short"].Value);
        //            //String strAmount = Convert.ToString(dgDeduction.Rows[i].Cells["DAmount"].Value);

        //            if (!String.IsNullOrEmpty(strFull))
        //            {
                       
        //                if (!String.IsNullOrEmpty(strSlNo))
        //                {
        //                    boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Config_PFHeads set PFHead='" + strFull.ToUpper() + "',ShortName='" + strShort.ToUpper() + "' where SlNo=" + strSlNo + "");
        //                }
        //                else
        //                {
        //                    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_PFHeads(PFHead,ShortName) values('" + strFull.ToUpper() + "','" + strShort.ToUpper() + "')");
        //                }
        //            }
        //            else
        //            {
        //                ERPMessageBox.ERPMessage.Show("Please Enter P.F. Head ( Full Name ) for " + i + "th Row.");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        ERPMessageBox.ERPMessage.Show("No P.F. Details To Save'");
        //    }
        //    return boolStatus;
        //}

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDeductionDetails())
            {
                GetDeductionDetails();
                ERPMessageBox.ERPMessage.Show("Employee's Salary Deduction Head Details Submitted Successfully");
            }
        }

        private void Salary_Head_Load(object sender, EventArgs e)
        {
            //SqlDataAdapter adp = new SqlDataAdapter();
            //SqlCommand cmd;
            //EDPConn.Open();
            //SqlConnection con = new SqlConnection(EDPConn.connectionstr);//"Data Source=" + EDPComm.PSERVER_NAME + "" + EDPComm.DataSourceExtention + ";Initial Catalog=master;Integrated Security=True;pooling=true; Connection Timeout=" + EDPComm.Conection_TimeOut + ";");
            //con.Open();
            //string sq3 = "SELECT name FROM sys.sysdatabases where name ='AccordFour'";
            //cmd = new SqlCommand(sq3, con);
            //adp.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //adp.Fill(dt);
            //con.Close();
            //if (dt.Rows.Count > 0)
            //{
            //    dgDeduction.Columns["DSlNo"].Visible = false;
            //    DataTable focode_genarate = clsDataAccess.RunQDTbl("select Ficode,Gcode from GenarateFicode where FromDate <='" + EDPComm.getSqlDateStr(Convert.ToDateTime(System.DateTime.Now)) + "' and ToDate >='" + EDPComm.getSqlDateStr(Convert.ToDateTime(System.DateTime.Now)) + "' order by SL_No ");
            //    int ficode = 0, company_code = 0;
            //    if (focode_genarate.Rows.Count > 0)
            //    {
            //        ficode = Convert.ToInt32(focode_genarate.Rows[0]["Ficode"]);
            //        company_code = Convert.ToInt32(focode_genarate.Rows[0]["Gcode"]);
            //    }


            //    Edpcom.EDPConnection EDPCon = new Edpcom.EDPConnection();
            //    EDPComm.PDATABASE_NAME = "AccordFour";
            //    EDPCon.DatabaseName = "AccordFour";

            //    EDPCon.Close();
            //    EDPCon.Open();
            //    common.ClearDataTable(ds.Tables["config"]);
            //    cmd = new SqlCommand("select Ldesc,Glcode from glmst where ficode='" + ficode + "' and gcode='" + company_code + "' and MGroup in('7','8','10')and MTYPE='L' order by Ldesc", EDPCon.mycon);
            //    adp.SelectCommand = cmd;
            //    adp.Fill(ds, "config");

            //    //DataTable dt = clsDataAccess.RunQDTbl("select Ldesc,Glcode from glmst where MGroup='8'");
               
               
            //    DataGridViewComboBoxColumn dgcombo = dgErn.Columns["ELedger"] as DataGridViewComboBoxColumn;
            //    dgcombo.Items.Add("");
            //    for (int i = 0; i <= ds.Tables["config"].Rows.Count - 1; i++)
            //    {
            //        string st = Convert.ToString(ds.Tables["config"].Rows[i]["Ldesc"]);
            //        dgcombo.Items.Add(st);
            //    }
            //    common.ClearDataTable(ds.Tables["config2"]);
            //    cmd = new SqlCommand("select Ldesc,Glcode from glmst where ficode='" + ficode + "' and gcode='" + company_code + "' and MGroup='3' and MTYPE='L' order by Ldesc", EDPCon.mycon);
            //    adp.SelectCommand = cmd;
            //    adp.Fill(ds, "config2");
            //    DataGridViewComboBoxColumn dgcombo2 = dgDeduction.Columns["DLedger"] as DataGridViewComboBoxColumn;
            //    dgcombo2.Items.Add("");
            //    for (int i = 0; i <= ds.Tables["config2"].Rows.Count - 1; i++)
            //    {
            //        string st = Convert.ToString(ds.Tables["config2"].Rows[i]["Ldesc"]);
            //        dgcombo2.Items.Add(st);
            //    }
            //    EDPCon.Close();
            //    EDPComm.PDATABASE_NAME = "EDP_Payroll";
            //    EDPCon.DatabaseName = "EDP_Payroll";
            //    EDPCon.Open();                
            //}
            //else
            //{
                dgErn.Columns["EFull"].Width = 291;
                dgErn.Columns["EShort"].Width = 124;                
                dgErn.Columns["ELedger"].Visible = false;

                dgDeduction.Columns["DSlNo"].Visible = false;
                dgDeduction.Columns["DFull"].Width = 291;
                dgDeduction.Columns["DShort"].Width = 124;
                dgDeduction.Columns["DLedger"].Visible = false;

                dgPfContribution.Columns["CSlNo"].Visible = false;
                dgPfContribution.Columns["Cfull"].Width = 291;
                dgPfContribution.Columns["Cshort"].Width = 124;
                dgPfContribution.Columns["CLedger"].Visible = false;

                try
                {
                    dg_pf_emp_cont.Columns["ecSlNo"].Visible = false;
                    dg_pf_emp_cont.Columns["ecfull"].Width = 291;
                    dg_pf_emp_cont.Columns["ecshort"].Width = 124;
                    dg_pf_emp_cont.Columns["ecLedger"].Visible = false;
                }
                catch { }
               
           // }

            //dgcontribution.AutoGenerateColumns = false;
            //dgcontribution.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    DataPropertyName = "Id",
            //    HeaderText = "Id",
            //    ValueType = typeof(int)
            //});
            //dgcontribution.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    DataPropertyName = "Name",
            //    HeaderText = "Name",
            //    ValueType = typeof(string),
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            //});
            //var objectTypeComboBoxColumn = new DataGridViewComboBoxColumn
            //{
            //    DataPropertyName = "Type",
            //    HeaderText = "Object Type",
            //    ValueType = typeof(Container),
            //    ValueMember = "Id",
            //    DisplayMember = "Name",
            //    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
            //};
            //dgcontribution.Columns.Add(objectTypeComboBoxColumn);

            //var dataTable = new DataTable();
            //dataTable.Columns.Add("Id");
            //dataTable.Columns.Add("Name");
            //dataTable.Columns.Add("Type");
            //dataTable.Columns.Add("Container");
            //dataTable.Rows.Add("", "Ss", "Ss", "");

            //foreach (var assignedObject in assignedObjects)
            //{
            //    dataTable.Rows.Add(assignedObject.Id,
            //                       assignedObject.Name,
            //                       assignedObject.ObjectType,
            //                       assignedObject.Container);
            //}
            //_objectDataGridView.DataSource = dataTable;          

            GetErnDetails();
            GetDeductionDetails();
            GetEmpContribution();

            if (dgPfContribution.Rows.Count > 1)
            {
                dgPfContribution.Columns["CSlNo"].Visible = false;
            }
            else
            {
                dgPfContribution.Rows.Add();
                dgPfContribution.Rows.Add();
                dgPfContribution.Rows.Add();
                dgPfContribution.Rows.Add();
                dgPfContribution.Rows.Add();
                dgPfContribution.Rows[0].Cells["Cfull"].Value = "A/C 01";
                dgPfContribution.Rows[1].Cells["Cfull"].Value = "A/C 02";
                dgPfContribution.Rows[2].Cells["Cfull"].Value = "A/C 10";
                dgPfContribution.Rows[3].Cells["Cfull"].Value = "A/C 21";
                dgPfContribution.Rows[4].Cells["Cfull"].Value = "A/C 22";

                dgPfContribution.Rows[0].Cells["CAmount"].Value = "3.67";
                dgPfContribution.Rows[1].Cells["CAmount"].Value = "0.85";
                dgPfContribution.Rows[2].Cells["CAmount"].Value = "8.33";
                dgPfContribution.Rows[3].Cells["CAmount"].Value = "0.50";
                dgPfContribution.Rows[4].Cells["CAmount"].Value = "0.01";
               
               
                
            }


            if (dgEsiContribution.Rows.Count > 1)
            {
                dgEsiContribution.Columns["esi_SlNo"].Visible = false;
            }
            else
            {
                dgEsiContribution.Rows.Add();


                dgEsiContribution.Rows[0].Cells["esi_Cfull"].Value = "A/C 01";
                dgEsiContribution.Rows[0].Cells["esi_CAmount"].Value = clsDataAccess.GetresultS("select top 1 amount from tbl_Employer_Contribution_Esi order by InsertionDate desc");//"4.75";

                dtpEsi.Value =Convert.ToDateTime( clsDataAccess.GetresultS("select top 1 convert(varchar, InsertionDate, 106) from tbl_Employer_Contribution_Esi order by InsertionDate desc"));
               string dt= dtpEsi.Value.ToString("dd/MM/yyyy");
               //dtpEsi.Text = dt;
               
            }




            //GetPFHeads();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ERPMessageBox.ERPMessage.Show("Delete Salary Head: " + dgDeduction.CurrentRow.Cells["DFull"].Value + " ( Row:" + Convert.ToInt32(dgDeduction.CurrentCell.RowIndex + 1) + " ) from 'Salary Head For Employees's Salary Deduction' ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
            if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
            {
                if (DeleteDeductionDetails())
                {                   
                    GetDeductionDetails();
                    ERPMessageBox.ERPMessage.Show("Employee's Deduction Salary Heads Deleted Sucessfully");
                }
            }
        }

        private void dgErn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message.ToString() == "Input string was not in a correct format.")
            {
                ERPMessageBox.ERPMessage.Show("Please Enter Valid Amount");
            }
        }

        private void dgDeduction_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message.ToString() == "Input string was not in a correct format.")
            {
                ERPMessageBox.ERPMessage.Show("Please Enter Valid Amount");
            }
        }

        private void btnErnSave_Click(object sender, EventArgs e)
        {
            if (SubmitErnDetails())
            {
                GetErnDetails();                
                ERPMessageBox.ERPMessage.Show("Salary Head Details ofEmployee Earning Submitted Successfully");
            }
        }

        private void btnErnDelete_Click(object sender, EventArgs e)
        {
            ERPMessageBox.ERPMessage.Show("Delete Salary Head: " + dgErn.CurrentRow.Cells["EFull"].Value + " ( Row:" + Convert.ToInt32(dgErn.CurrentCell.RowIndex + 1) + " ) from 'Salary Head of Employee Earning'?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
            if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
            {
                if (DeleteErnDetails())
                {
                    GetErnDetails();                    
                    ERPMessageBox.ERPMessage.Show("Salary Head Details for Employee Earning Deleted Sucessfully");
                }
            }
        }

        private void dgErn_CellLeave(object sender, DataGridViewCellEventArgs e)
        {            
          
        }

        private void dgErn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgErn.Columns[e.ColumnIndex].HeaderText == "Ledger")
            {
                DataView dv = new DataView(ds.Tables["config"]);
                dv.RowFilter = "ldesc='" + dgErn.Rows[e.RowIndex].Cells["ELedger"].Value + "'";
                if (dv.Count > 0)
                    dgErn.Rows[e.RowIndex].Cells["glcodeE"].Value = dv[0]["Glcode"];
                else
                    dgErn.Rows[e.RowIndex].Cells["glcodeE"].Value = 0;
            }
        }

        private void dgDeduction_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDeduction.Columns[e.ColumnIndex].HeaderText == "Ledger")
            {
                DataView dv = new DataView(ds.Tables["config2"]);
                dv.RowFilter = "ldesc='" + dgDeduction.Rows[e.RowIndex].Cells["DLedger"].Value + "'";
                if (dv.Count > 0)
                    dgDeduction.Rows[e.RowIndex].Cells["glcodeD"].Value = dv[0]["Glcode"];
                else
                    dgDeduction.Rows[e.RowIndex].Cells["glcodeD"].Value = 0;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                DataView dv = new DataView(ds.Tables["config2"]);
                for (int i = 0; i <= dgDeduction.Rows.Count - 2; i++)
                {
                    dv.RowFilter = "glcode='" + dgDeduction.Rows[i].Cells["glcodeD"].Value + "'  ";
                    if (dv.Count > 0)
                        dgDeduction.Rows[i].Cells["DLedger"].Value = dv[0]["ldesc"];
                }
            }

            dgDeduction.Columns["DSlNo"].Visible = false;
        }

        private void btnContributeSave_Click(object sender, EventArgs e)
        {
            if (SubmitContributionDetails())
            {
                GetEmpContribution();
                ERPMessageBox.ERPMessage.Show("Contribution Head Details of Employer Submitted Successfully");
            }
        }

        private void btnContributeDelete_Click(object sender, EventArgs e)
        {
            //ERPMessageBox.ERPMessage.Show("Delete Cont Head: " + dgErn.CurrentRow.Cells["EFull"].Value + " ( Row:" + Convert.ToInt32(dgErn.CurrentCell.RowIndex + 1) + " ) from 'Salary Head of Employee Earning'?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
            //if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
            //{
            //    if (DeleteContributeDetails())
            //    {
            //        GetEmpContribution();
            //        ERPMessageBox.ERPMessage.Show("Salary Head Details for Employee Earning Deleted Sucessfully");
            //    }
            //}

            frmPf_locWise pf = new frmPf_locWise();
            pf.ShowDialog();
        }

        private void dgcontribution_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgPfContribution.Columns[e.ColumnIndex].HeaderText == "Ledger")
            {
                DataView dv = new DataView(ds.Tables["config2"]);
                dv.RowFilter = "ldesc='" + dgPfContribution.Rows[e.RowIndex].Cells["CLedger"].Value + "'";
                if (dv.Count > 0)
                    dgDeduction.Rows[e.RowIndex].Cells["CGlcode"].Value = dv[0]["Glcode"];
                else
                    dgDeduction.Rows[e.RowIndex].Cells["CGlcode"].Value = 0;
            }
        }

        private void dgcontribution_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message.ToString() == "Input string was not in a correct format.")
            {
                ERPMessageBox.ERPMessage.Show("Please Enter Valid Amount");
            }
        }

        //private void btnPFDel_Click(object sender, EventArgs e)
        //{
        //    ERPMessageBox.ERPMessage.Show("Delete P.F. Head: " + dgPF.CurrentRow.Cells["PF_HeadFull"].Value + " ( Line:" + Convert.ToInt32(dgDeduction.CurrentCell.RowIndex + 1) + " ) ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
        //    if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
        //    {
        //        if (DeletePFHead())
        //        {
        //            GetPFHeads();
        //            ERPMessageBox.ERPMessage.Show("P.F. Head Deleted Sucessfully");
        //        }
        //    }
        //}

        //private void btnPFSave_Click(object sender, EventArgs e)
        //{
        //    if (SubmitPFHeads())
        //    {
        //        GetPFHeads();
        //        ERPMessageBox.ERPMessage.Show("P.F. Head Details Submitted Successfully");
        //    }
        //}
        private static void FreezeBand(DataGridViewBand band)
        {
            band.Frozen = true;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.WhiteSmoke;
            band.DefaultCellStyle = style;
        }

        private void btnEsi_Save_Click(object sender, EventArgs e)
        {
            double esi_empl = 4.75;

            try
            {
                esi_empl = Convert.ToDouble(dgEsiContribution.Rows[0].Cells["esi_cAmount"].Value);
                    //Convert.ToDouble(clsDataAccess.GetresultS("select top 1 amount from tbl_Employer_Contribution_Esi order by InsertionDate desc"));//"4.75";
            }
            catch { esi_empl = 4.75; }

           string qry = "insert into tbl_Employer_Contribution_Esi ([SalaryHead_Full],[SalaryHead_Short],[Amount],[InsertionDate],[Glcode])" +
       "VALUES('Esi Contribution','EsiContribution','" + esi_empl + "','"+dtpEsi.Value.ToString("dd/MMMM/yyyy")+"',0)";

           bool bl = clsDataAccess.RunNQwithStatus(qry);
            if (bl==true)
            {
                dgEsiContribution.Rows[0].Cells["esi_CAmount"].Value = clsDataAccess.GetresultS("select top 1 amount from tbl_Employer_Contribution_Esi order by InsertionDate desc");//"4.75";

                dtpEsi.Text = clsDataAccess.GetresultS("select top 1 InsertionDate from tbl_Employer_Contribution_Esi order by InsertionDate desc");
                ERPMessageBox.ERPMessage.Show("Contribution Head Details of Employer Submitted Successfully");
            }
        }

        private void btn_emp_cont_del_Click(object sender, EventArgs e)
        {

        }

        private void btn_emp_cont_save_Click(object sender, EventArgs e)
        {
            if (SubmitContributionDetails_emp())
            {
                GetEmpContribution();
                ERPMessageBox.ERPMessage.Show("Contribution Head Details of Employer Submitted Successfully");
            }
        }

        public bool SubmitContributionDetails_emp()
        {
            Boolean boolStatus = false;
            string oth_head = "";
            if (dg_pf_emp_cont.Rows.Count > 1)
            {
                for (Int32 i = 0; i <= dg_pf_emp_cont.Rows.Count - 1; i++)
                {
                    int Ledger_Code = 0;
                    String strSlNo = Convert.ToString(dg_pf_emp_cont.Rows[i].Cells["CSlNo"].Value);
                    String strFull = Convert.ToString(dg_pf_emp_cont.Rows[i].Cells["Cfull"].Value);
                    String strShort = Convert.ToString(dg_pf_emp_cont.Rows[i].Cells["Cshort"].Value);
                    String strAmount = Convert.ToString(dg_pf_emp_cont.Rows[i].Cells["CAmount"].Value);
                    if (Information.IsNumeric(dg_pf_emp_cont.Rows[i].Cells["CGlcode"].Value) == true)
                        Ledger_Code = Convert.ToInt32(dg_pf_emp_cont.Rows[i].Cells["CGlcode"].Value);

                    if (oth_head == "")
                    {
                        oth_head = "'" + strAmount + "'";
                    }
                    else
                    {
                        oth_head = oth_head + ",'" + strAmount + "'";
                    }


                    if (!String.IsNullOrEmpty(strFull))
                    {
                        if (String.IsNullOrEmpty(strAmount))
                        {
                            strAmount = "0.0";
                        }
                        if (!String.IsNullOrEmpty(strSlNo))
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Contribution set SalaryHead_Full='" + strFull + "',SalaryHead_Short='" + strFull + "',Amount=" + strAmount + ",Glcode='" + Ledger_Code + "' where SlNo=" + strSlNo + "");
                        }
                        else
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Contribution(SalaryHead_Full,SalaryHead_Short,Amount,Glcode) values('" + strFull + "','" + strFull + "'," + strAmount + ",'" + Ledger_Code + "')");
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Salary Head ( Full Name ) for " + i + "th Row.");
                    }
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Save For 'Salary Head of Employee Earning'");
            }
            

            return boolStatus;
        }

    }
}