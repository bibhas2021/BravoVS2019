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
using System.IO;
namespace PayRollManagementSystem
{
    public partial class frmEmployeePfEsiCsv : Form
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();

        int Head_Cou = 0, pf_gs = 0, chk_cont_type=0;
        string acc1 = "";
        string acc2 = "";
        string acc3 = "";
        string acc4 = "";
        string acc5 = "";
        string acc6 = "";

        string[][] output;
        int indx = 0;
        DataTable dtec = new DataTable();
        public frmEmployeePfEsiCsv()
        {
            InitializeComponent();
        }

        public  void recalc(int idx,DataTable ec)
        {
       
            string Str_PF = "";
            string Str_PF_SLNO = "", ac_pf = "12", ac01 = "3.67", ac10 = "8.33", ac02 = "0.50", ac21 = "0.50", ac22 = "0.00";

            string ac_01 = "3.67", ac_10 = "8.33", ac_02 = "0.50", ac_21 = "0.50", ac_22 = "0.00";
            double bs=0;

           

            //ec = clsDataAccess.RunQDTbl("select  top(1) ac02 ,ac21,ac22,ac01,ac10,(ac01+ac10)pf from tbl_employee_contribution_details where ecdt<='15/" + lbl_Month.Text + "/" + lbl_yr.Text + "' order by slno desc");
            
            ac02 = ec.Rows[0]["ac02"].ToString();
            ac21 = ec.Rows[0]["ac21"].ToString(); ac22 = ec.Rows[0]["ac22"].ToString();

            ac01 = ec.Rows[0]["ac01"].ToString();
            ac10 = ec.Rows[0]["ac10"].ToString();
            string[] ap = ec.Rows[0]["pf"].ToString().Split('.');
            if (Convert.ToDouble(ap[1]) == 0)
            {
                ac_pf = ap[0].ToString();
            }
            else
            {
                ac_pf = ec.Rows[0]["pf"].ToString();
            }


            //     dgvCsv.Rows[idx].Cells["MemberID"].Value=
            //dgvCsv.Rows[idx].Cells["MemberName"].Value=
            bs=Convert.ToDouble(dgvCsv.Rows[idx].Cells["Gross"].Value);
            dgvCsv.Rows[idx].Cells["EPFWage"].Value=bs;
            dgvCsv.Rows[idx].Cells["EPSWage"].Value=bs;
            dgvCsv.Rows[idx].Cells["EDLIWage"].Value=bs;

            dgvCsv.Rows[idx].Cells["EPFCont"].Value = Math.Round(Convert.ToDouble(bs*Convert.ToDouble(ac_pf)/100),0);
            dgvCsv.Rows[idx].Cells["EPSCont"].Value = Math.Round(Convert.ToDouble(bs * Convert.ToDouble(ac10) / 100), 0);
            dgvCsv.Rows[idx].Cells["EDLICont"].Value = Math.Round(Convert.ToDouble(bs * Convert.ToDouble(ac01) / 100), 0);

            //============================================================================================
            //dgvCsv.Rows[idx].Cells["NcpDay"].Value=""
            //dgvCsv.Rows[idx].Cells["NcpRef"].Value=



        }



        public void Retrive_Data(string sess, string Loc, int Mon, string Loc_id, string co_id, string yr, string chk,int opt)
        {
            int pf_age_flag = 0;
            string Str_ErHead_basic = "";
            DataTable ErHead_basic = clsDataAccess.RunQDTbl("select top 1  SalaryHead_Short from tbl_Employee_ErnSalaryHead");
            Str_ErHead_basic = ErHead_basic.Rows[0][0].ToString();
            int final_rw = 0;
            string Str_PF_age = "";
            string Str_PF = "";
            string Str_PF_SLNO = "", ac_pf = "12", ac01 = "3.67", ac10 = "8.33", ac02 = "0.50", ac21 = "0.50", ac22 = "0.00";

            string ac_01 = "3.67", ac_10 = "8.33", ac_02 = "0.50", ac_21 = "0.50", ac_22 = "0.00";
            string month = clsEmployee.GetMonthName(Convert.ToInt32(Mon));
            lbl_Month.Text = month;
            lbl_yr.Text = yr;
            DataTable ec = new DataTable();
            if (Convert.ToInt32(clsDataAccess.ReturnValue("select chk_cont_type from CompanyLimiter")) == 1)
            {
                ec = clsDataAccess.RunQDTbl("select  top(1) ac02 ,ac21,ac22,ac01,ac10,(ac01+ac10)pf from tbl_loc_contribution where (locid in (" + Loc_id + "))");
            }
            else
            {
                ec = clsDataAccess.RunQDTbl("select  top(1) ac02 ,ac21,ac22,ac01,ac10,(ac01+ac10)pf from tbl_employee_contribution_details where ecdt>='15/" + month + "/" + yr + "' order by slno desc");

            }
            
            DataTable ec2 = new DataTable();
            if (ec.Rows.Count == 0)
            {
                ec = clsDataAccess.RunQDTbl("select  top(1) ac02 ,ac21,ac22,ac01,ac10,(ac01+ac10)pf from tbl_employee_contribution_details where ecdt<='15/" + month + "/" + yr + "' order by slno desc");
            }

            dtec = ec.Copy();
            ac02 = ec.Rows[0]["ac02"].ToString();
            ac21 = ec.Rows[0]["ac21"].ToString(); ac22 = ec.Rows[0]["ac22"].ToString();

            ac01 = ec.Rows[0]["ac01"].ToString();
            ac10 = ec.Rows[0]["ac10"].ToString();
            string[] ap = ec.Rows[0]["pf"].ToString().Split('.');
            if (Convert.ToDouble(ap[1]) == 0)
            {
                ac_pf = ap[0].ToString();
            }
            else
            {
                ac_pf = ec.Rows[0]["pf"].ToString();
            }

            DataTable data_PF = clsDataAccess.RunQDTbl("select distinct d.SalaryHead_Short,d.SLNO from tbl_Employee_DeductionSalayHead d,tbl_Employee_Assign_SalStructure e,tbl_Employee_Link_SalaryStructure l where d.SlNo=e.SAL_HEAD and e.PF_PER=1 and e.SAL_STRUCT=l.SalaryStructure_ID and l.Location_ID IN (" + Loc_id + ")");
            if (data_PF.Rows.Count > 0)
            {
                Str_PF = data_PF.Rows[0][0].ToString();
                Str_PF_SLNO = data_PF.Rows[0][1].ToString();
            }
            else
            {
                Str_PF = "";
                ERPMessageBox.ERPMessage.Show("There is no PF Head in this Salary Structure");
                return;
            }

            DataTable data_PFAge = clsDataAccess.RunQDTbl("select [PFAge] from [tbl_Employee_Config_Retirement] where [Session]='" + sess + "'");
            if (data_PF.Rows.Count > 0)
            {
                try
                {
                    Str_PF_age = data_PFAge.Rows[0][0].ToString();
                }
                catch { Str_PF_age = "58"; }
            }
            else
            {
                Str_PF_age = "";
                ERPMessageBox.ERPMessage.Show("There is no assigned PF Age");
                return;
            }

            Boolean flug_deduction = false;



            try
            {

                pf_gs =Convert.ToInt32( clsDataAccess.ReturnValue("select pfgs from CompanyLimiter"));
            }
            catch { pf_gs = 0; }
            try
            {
                chk_cont_type = Convert.ToInt32(clsDataAccess.ReturnValue("select chk_cont_type from CompanyLimiter"));
            }
            catch { chk_cont_type = 0; }


            DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,(CASE WHEN em.pf_name != '' THEN em.pf_name ELSE ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) END) as EmployName ,em.PF as 'PF NO',sm.Emp_Id as ID,'" + Loc + "' as 'Site',DATEDIFF(hour,em.DateOfBirth,GETDATE())/8766.0 AS AgeYearsDecimal,sm.desig_id,sm.location_id FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where em.PF_Deduction=0  and (sm.Session='" + sess + "') " + chk + " and (sm.Month ='" + month + "') and sm.Location_id IN (" + Loc_id + ") and (sm.Company_id='" + co_id + "') and (em.ID = sm.Emp_Id) order by id,EmployName,site");

            if (tot_employ.Rows.Count > 0)
            {

                DataTable contribution = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,cast(isNULL(Amount,0) as numeric)Amount,Location_id,0 as Designation_id FROM tbl_Employee_SalaryDet where Session='" + sess + "' and TableName='tbl_Employer_Contribution' and Month ='" + month + "' and Location_id IN (" + Loc_id + ") order by Slno");
                DataView dvcontri = new DataView(contribution);


                DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,cast(isNULL(Amount,0) as numeric)Amount,Location_id,0 as Designation_id FROM tbl_Employee_SalaryDet where Session='" + sess + "' and Month ='" + month + "' and Location_id IN (" + Loc_id + ") order by Slno");
                DataView dv = new DataView(salary_details);

                DataTable contribution1 = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,cast(isNULL(Amount,0) as numeric)Amount,Designation_id,Location_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + sess + "' and TableName='tbl_Employer_Contribution' and Month ='" + month + "' and Location_id IN (" + Loc_id + ") order by Slno");
                DataView dvcontri1 = new DataView(contribution1);


                DataTable salary_details1 = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,cast(isNULL(Amount,0) as numeric)Amount,Designation_id,Location_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + sess + "' and Month ='" + month + "' and Location_id IN (" + Loc_id + ") order by Slno");
                DataView dv1 = new DataView(salary_details1);


                int table_count = tot_employ.Columns.Count;
                final_rw = tot_employ.Rows.Count;
                tot_employ.Rows.Add();
                int dt_count = tot_employ.Rows.Count;
               
                tot_employ.Rows.Add();
                tot_employ.Rows.Add();
                
                int counter = 0;



                tot_employ.Columns.Add("Employer (" + ac01 + "%)", typeof(string));
                tot_employ.Columns.Add("EPFBasic", typeof(string));
                tot_employ.Columns.Add("EPS(" + ac10 + "%)", typeof(string));

                tot_employ.Columns.Add("A/C01 " + ac_pf + "%", typeof(string));
                tot_employ.Columns.Add("A/C01 " + ac01 + "%", typeof(string));
                tot_employ.Columns.Add("A/C02 " + ac02 + "%", typeof(string));
                tot_employ.Columns.Add("A/C10 " + ac10 + "%", typeof(string));
                tot_employ.Columns.Add("A/C21 " + ac21 + "%", typeof(string));
                tot_employ.Columns.Add("A/C22 " + ac22 + "%", typeof(string));

                //tot_employ.Columns.Add("Employer (" + ac01 + "%)", typeof(string));
                //tot_employ.Columns.Add("EPFBasic", typeof(string));
                //tot_employ.Columns.Add("EPS(" + ac10 + "%)", typeof(string));

                //tot_employ.Columns.Add("A/C01 " + ac_pf + "%", typeof(string));
                //tot_employ.Columns.Add("A/C01 " + ac01 + "%", typeof(string));
                //tot_employ.Columns.Add("A/C02 " + ac02 + "%", typeof(string));
                //tot_employ.Columns.Add("A/C10 " + ac10 + "%", typeof(string));
                //tot_employ.Columns.Add("A/C21 " + ac21 + "%", typeof(string));
                //tot_employ.Columns.Add("A/C22 " + ac22 + "%", typeof(string));



                for (int i = 0; i <= tot_employ.Rows.Count - 4; i++)
                {
                    if (Convert.ToDouble(tot_employ.Rows[i]["AgeYearsDecimal"]) > Convert.ToDouble(Str_PF_age))
                    {
                        pf_age_flag = 1;
                    }
                    else
                    { pf_age_flag = 0; }

                    //dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "'";

                    //dvcontri.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "'";


                    dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["desig_id"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "'";

                    dvcontri.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["desig_id"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "'";
                    //if (tot_employ.Rows[i]["ID"].ToString().Trim() == "CFS010114")
                    //{

                    //    MessageBox.Show("");
                    //}

                    if (dv.Count > 0)
                    {
                        for (int j = 0; j <= dv.Count - 1; j++)
                        {
                            if (i == 0)
                            {
                                if (j == 0)
                                    tot_employ.Rows[dt_count][1] = "-";

                                if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                                {
                                    table_count = tot_employ.Columns.Count;
                                    flug_deduction = true;
                                    counter = j;
                                }

                                string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");

                                if (Salary_Head == Str_PF)
                                {
                                    try
                                    {
                                        tot_employ.Columns.Add(Salary_Head, typeof(string));
                                    }
                                    catch { }
                                    tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                                    tot_employ.Rows[dt_count - 1][Salary_Head] = "---------------";
                                    tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                                    tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                                }
                                else if (Salary_Head == Str_ErHead_basic)
                                {
                                    try
                                    {
                                        tot_employ.Columns.Add(Salary_Head, typeof(string));
                                    }
                                    catch { }
                                    if (Salary_Head == "BS")
                                    {
                                        tot_employ.Rows[i][Salary_Head] = clsDataAccess.GetresultS("SELECT cast(pf_bs as numeric)pf_bs FROM tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"] + "') and (month='" + lblMonth.Text + "') and (lid='" + tot_employ.Rows[i]["location_id"] + "')");
                                    }
                                    else
                                    {
                                        tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                                    }
                                    if (Convert.ToDouble((tot_employ.Rows[i][Salary_Head])) > 15000)
                                    {
                                        tot_employ.Rows[i]["EPFBasic"] = 15000;
                                    }
                                    else
                                    {
                                        tot_employ.Rows[i]["EPFBasic"] = Convert.ToDouble(tot_employ.Rows[i][Salary_Head]);
                                    }


                                }

                            }

                            else
                            {
                                string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                                if (Salary_Head == Str_PF)
                                {
                                    tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                                    tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(dv[j]["Amount"]));
                                }
                                else if (Salary_Head == Str_ErHead_basic)
                                {
                                    if (Salary_Head == "BS")
                                    {
                                        tot_employ.Rows[i][Salary_Head] = clsDataAccess.GetresultS("SELECT cast(pf_bs as numeric) pf_bs FROM tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"] + "') and (month='" + lblMonth.Text + "') and (lid='" + tot_employ.Rows[i]["location_id"] + "') and (pf_bs='" + dv[j]["Amount"] + "')");
                                    }
                                    else
                                    {
                                        tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                                    }
                                    try
                                    {
                                        if (tot_employ.Rows[i][Salary_Head].ToString().Trim() == "")
                                        {
                                            if (Salary_Head == "BS")
                                            {
                                                tot_employ.Rows[i][Salary_Head] = clsDataAccess.GetresultS("SELECT cast(pf_bs as numeric) pf_bs FROM tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"] + "') and (month='" + lblMonth.Text + "') and (lid='" + tot_employ.Rows[i]["location_id"] + "')");
                                            }
                                            else
                                            {
                                                tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                                            }

                                        }

                                    }
                                    catch { }
                                    if (Convert.ToDouble((tot_employ.Rows[i][Salary_Head])) > 15000)
                                    {
                                        tot_employ.Rows[i]["EPFBasic"] = 15000;
                                    }
                                    else
                                    {
                                        tot_employ.Rows[i]["EPFBasic"] = Convert.ToDouble(tot_employ.Rows[i][Salary_Head]);
                                    }


                                }

                            }
                        }
                    }
                    else
                    {
                        dv1.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id='" + tot_employ.Rows[i]["desig_id"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "'";
                        //and  TableName='tbl_Employee_DeductionSalayHead' and SalId='1'";

                        dvcontri1.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id='" + tot_employ.Rows[i]["desig_id"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "'";
                        //and  TableName='tbl_Employee_DeductionSalayHead' and SalId='1'";

                        for (int j = 0; j <= dv1.Count - 1; j++)
                        {
                            if (i == 0)
                            {
                                if (j == 0)
                                    tot_employ.Rows[dt_count][1] = "-";

                                if (Convert.ToString(dv1[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                                {
                                    table_count = tot_employ.Columns.Count;
                                    flug_deduction = true;
                                    counter = j;
                                }

                                string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv1[j]["TableName"] + " where SlNo ='" + dv1[j]["SalId"] + "'  ");

                                if (Salary_Head == Str_PF)
                                {
                                    tot_employ.Columns.Add(Salary_Head, typeof(string));
                                    tot_employ.Rows[i][Salary_Head] = dv1[j]["Amount"];

                                    tot_employ.Rows[dt_count - 1][Salary_Head] = "---------------";
                                    tot_employ.Rows[dt_count][Salary_Head] = dv1[j]["Amount"];
                                    tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                                }
                                else if (Salary_Head == Str_ErHead_basic)
                                {
                                    tot_employ.Columns.Add(Salary_Head, typeof(string));
                                    tot_employ.Rows[i][Salary_Head] = dv1[j]["Amount"];

                                    if (Convert.ToDouble((tot_employ.Rows[i][Salary_Head])) > 15000)
                                    {
                                        tot_employ.Rows[i]["EPFBasic"] = 15000;
                                    }
                                    else
                                    {
                                        tot_employ.Rows[i]["EPFBasic"] = Convert.ToDouble(tot_employ.Rows[i][Salary_Head]);
                                    }


                                }

                            }

                            else
                            {
                                string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv1[j]["TableName"] + " where SlNo ='" + dv1[j]["SalId"] + "'  ");
                                if (Salary_Head == Str_PF)
                                {
                                    tot_employ.Rows[i][Salary_Head] = dv1[j]["Amount"];
                                    tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(dv1[j]["Amount"]));
                                }
                                else if (Salary_Head == Str_ErHead_basic)
                                {
                                    if (Salary_Head == "BS")
                                    {
                                        dv1.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id='" + tot_employ.Rows[i]["desig_id"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "' and  TableName='tbl_Employee_DeductionSalayHead' and SalId='1'";

                                        tot_employ.Rows[i][Salary_Head] = clsDataAccess.GetresultS("SELECT cast(pf_bs as numeric)pf_bs FROM tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"] + "') and (month='" + lblMonth.Text + "') and (lid='" + tot_employ.Rows[i]["location_id"] + "') and (pf='" + dv1[j]["Amount"] + "')");
                                    }
                                    else
                                    {
                                        tot_employ.Rows[i][Salary_Head] = dv1[j]["Amount"];
                                    }
                                    if (Convert.ToDouble((tot_employ.Rows[i][Salary_Head])) > 15000)
                                    {
                                        tot_employ.Rows[i]["EPFBasic"] = 15000;
                                    }
                                    else
                                    {
                                        tot_employ.Rows[i]["EPFBasic"] = Convert.ToDouble(tot_employ.Rows[i][Salary_Head]);
                                    }


                                }

                            }
                        }

                    }
                    try
                    {
                        tot_employ.Rows[dt_count - 1][Str_ErHead_basic] = "---------------";
                    }
                    catch { }
                    tot_employ.Rows[dt_count - 1]["EPFBasic"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["EPS(" + ac10 + "%)"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["Employer (" + ac01 + "%)"] = "---------------";

                    //041215


                    tot_employ.Rows[dt_count - 1]["A/C01 " + ac_pf + "%"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["A/C01 " + ac01 + "%"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["A/C02 " + ac02 + "%"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["A/C10 " + ac10 + "%"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["A/C21 " + ac21 + "%"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["A/C22 " + ac22 + "%"] = "---------------";



                    //041215
                    try
                    {
                        if (Information.IsNumeric(tot_employ.Rows[dt_count][Str_ErHead_basic]) == false)
                            tot_employ.Rows[dt_count][Str_ErHead_basic] = 0;
                    }
                    catch { }
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPFBasic"]) == false)
                        tot_employ.Rows[dt_count]["EPFBasic"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPS(" + ac10 + "%)"]) == false)
                        tot_employ.Rows[dt_count]["EPS(" + ac10 + "%)"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["Employer (" + ac01 + "%)"]) == false)
                        tot_employ.Rows[dt_count]["Employer (" + ac01 + "%)"] = 0;

                    //041215
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["A/C01 " + ac_pf + "%"]) == false)
                        tot_employ.Rows[dt_count]["A/C01 " + ac_pf + "%"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["A/C01 " + ac01 + "%"]) == false)
                        tot_employ.Rows[dt_count]["A/C01 " + ac01 + "%"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["A/C02 " + ac02 + "%"]) == false)
                        tot_employ.Rows[dt_count]["A/C02 " + ac02 + "%"] = 0;

                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["A/C10 " + ac10 + "%"]) == false)
                        tot_employ.Rows[dt_count]["A/C10 " + ac10 + "%"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["A/C21 " + ac21 + "%"]) == false)
                        tot_employ.Rows[dt_count]["A/C21 " + ac21 + "%"] = 0;

                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["A/C22 " + ac22 + "%"]) == false)
                        tot_employ.Rows[dt_count]["A/C22 " + ac22 + "%"] = 0;



                    //041215
                    try
                    {
                        tot_employ.Rows[dt_count + 1][Str_ErHead_basic] = "";//"========";
                    }
                    catch { }
                    tot_employ.Rows[dt_count + 1]["EPFBasic"] = "";//"========";
                    tot_employ.Rows[dt_count + 1]["EPS(" + ac10 + "%)"] = "";// "========";
                    tot_employ.Rows[dt_count + 1]["Employer (" + ac01 + "%)"] = "";//"========";

                    //041215
                    tot_employ.Rows[dt_count + 1]["A/C01 " + ac_pf + "%"] = "";//"========";
                    tot_employ.Rows[dt_count + 1]["A/C01 " + ac01 + "%"] = "";//"========";
                    tot_employ.Rows[dt_count + 1]["A/C02 " + ac02 + "%"] = "";//"========";
                    tot_employ.Rows[dt_count + 1]["A/C10 " + ac10 + "%"] = "";// "========";
                    tot_employ.Rows[dt_count + 1]["A/C21 " + ac21 + "%"] = "";//"========";
                    tot_employ.Rows[dt_count + 1]["A/C22 " + ac22 + "%"] = "";//"========";

                    //041215
                    try{
                        if (tot_employ.Rows[i][Str_PF].ToString().Trim()=="")
                        {

                            tot_employ.Rows[i][Str_PF] = Math.Round(Convert.ToDouble(clsDataAccess.ReturnValue("select (pf_bs*"+ac_pf+"/100)'pf' from tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"].ToString() + "') and (month='" + month + " - " + yr + "') and (coid='" + co_id + "') and (lid='" + tot_employ.Rows[i]["Location_ID"].ToString() + "')")));
                        }
                    }
                    catch
                    {
                        tot_employ.Columns.Add(Str_PF, typeof(string));
                        tot_employ.Rows[i][Str_PF] =Math.Round( Convert.ToDouble(clsDataAccess.ReturnValue("select (pf_bs*"+ac_pf+"/100)'pf' from tbl_employers_contribution where (emp_id='" + tot_employ.Rows[i]["ID"].ToString() + "') and (month='"+ month +" - "+ yr +"') and (coid='"+ co_id +"') and (lid='" + tot_employ.Rows[i]["Location_ID"].ToString() + "')")));
                    }
                    tot_employ.Rows[i]["EPS(" + ac10 + "%)"] = string.Format("{0:F}", Convert.ToDouble(System.Math.Round(((((Convert.ToDouble(tot_employ.Rows[i][Str_PF]) * 100) / Convert.ToDouble(ac_pf)) * Convert.ToDouble(ac10)) / 100), 0)));

                    tot_employ.Rows[dt_count][Str_ErHead_basic] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) + Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]));
                    tot_employ.Rows[dt_count]["EPFBasic"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPFBasic"]) + Convert.ToDouble(tot_employ.Rows[i]["EPFBasic"]));
                    tot_employ.Rows[dt_count]["EPS(" + ac10 + "%)"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPS(" + ac10 + "%)"]) + Convert.ToDouble(tot_employ.Rows[i]["EPS(" + ac10 + "%)"]));
                    tot_employ.Rows[i]["Employer (" + ac01 + "%)"] = (Convert.ToDouble(tot_employ.Rows[i]["PF"]) - Convert.ToDouble(tot_employ.Rows[i]["EPS(" + ac10 + "%)"]));
                    tot_employ.Rows[dt_count]["Employer (" + ac01 + "%)"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Employer (" + ac01 + "%)"]) + Convert.ToDouble(tot_employ.Rows[i]["Employer (" + ac01 + "%)"]));

                    //041215
                    if (tot_employ.Rows[i]["PF NO"].ToString().Trim() == "")
                    {
                        tot_employ.Rows[i]["A/C01 " + ac_pf + "%"] = 0;
                        //tot_employ.Rows[dt_count]["A/C01 " + ac_pf + "%"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) * Convert.ToDouble(ac_pf) / 100 + Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac_pf) / 100);

                        tot_employ.Rows[i]["A/C01 " + ac01 + "%"] = 0;
                        //tot_employ.Rows[dt_count]["A/C01 " + ac01 + "%"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) * Convert.ToDouble(ac01)) / 100 + (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac01)) / 100);

                        tot_employ.Rows[i]["A/C02 " + ac02 + "%"] = 0;
                        //tot_employ.Rows[dt_count]["A/C02 " + ac02 + "%"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count]["A/C02 " + ac02 + "%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C02 " + ac02 + "%"])));//Convert.ToDouble(dvcontri[0]["Amount"]))



                        tot_employ.Rows[i]["A/C10 " + ac10 + "%"] = 0;
                        //tot_employ.Rows[dt_count]["A/C10 " + ac10 + "%"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) * Convert.ToDouble(8.33)) / 100 + (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac10)) / 100);

                        tot_employ.Rows[i]["A/C21 " + ac21 + "%"] = 0;
                        //tot_employ.Rows[dt_count]["A/C21 " + ac21 + "%"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count]["A/C21 " + ac21 + "%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C21 " + ac21 + "%"])));

                        tot_employ.Rows[i]["A/C22 " + ac22 + "%"] = 0;
                        //tot_employ.Rows[dt_count]["A/C22 " + ac22 + "%"] = string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[dt_count]["A/C22 " + ac22 + "%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C22 " + ac22 + "%"])));

                        

                    }
                    else
                    {
                        tot_employ.Rows[i]["A/C01 " + ac_pf + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac_pf) / 100);
                        //tot_employ.Rows[dt_count]["A/C01 " + ac_pf + "%"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Str_ErHead_basic]) * Convert.ToDouble(ac_pf) / 100 + Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac_pf) / 100);

                        tot_employ.Rows[dt_count]["A/C01 " + ac_pf + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["A/C01 " + ac_pf + "%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C01 " + ac_pf + "%"]));


                        tot_employ.Rows[i]["A/C10 " + ac10 + "%"] = " " + string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac10)) / 100);
                        tot_employ.Rows[i]["A/C01 " + ac01 + "%"] = " " + string.Format("{0:F}", (Convert.ToDouble(tot_employ.Rows[i][Str_ErHead_basic]) * Convert.ToDouble(ac01)) / 100);
                        if (pf_age_flag > 0)
                        {
                            tot_employ.Rows[i]["A/C01 " + ac01 + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[i]["A/C10 " + ac10 + "%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C01 " + ac01 + "%"]));
                            tot_employ.Rows[i]["A/C10 " + ac10 + "%"] = " " + 0;

                        }

                        tot_employ.Rows[dt_count]["A/C01 " + ac01 + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["A/C01 " + ac01 + "%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C01 " + ac01 + "%"]));
                        try
                        {
                            tot_employ.Rows[i]["A/C02 " + ac02 + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(dvcontri[0]["Amount"]));
                        }
                        catch
                        {
                            tot_employ.Rows[i]["A/C02 " + ac02 + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(0));
                        }
                        tot_employ.Rows[dt_count]["A/C02 " + ac02 + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["A/C02 " + ac02 + "%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C02 " + ac02 + "%"]));
                        tot_employ.Rows[dt_count]["A/C10 " + ac10 + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["A/C10 " + ac10 + "%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C10 " + ac10 + "%"]));
                        try{
                            tot_employ.Rows[i]["A/C21 " + ac21 + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(dvcontri[1]["Amount"]));
                        }
                        catch
                        {
                            tot_employ.Rows[i]["A/C21 " + ac21 + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(0));
                        }
                        tot_employ.Rows[dt_count]["A/C21 " + ac21 + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["A/C21 " + ac21 + "%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C21 " + ac21 + "%"]));
                        try
                        {
                            tot_employ.Rows[i]["A/C22 " + ac22 + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(dvcontri[2]["Amount"]));
                        }
                        catch
                        {
                            tot_employ.Rows[i]["A/C22 " + ac22 + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(0));
                        }
                        tot_employ.Rows[dt_count]["A/C22 " + ac22 + "%"] = " " + string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["A/C22 " + ac22 + "%"]) + Convert.ToDouble(tot_employ.Rows[i]["A/C22 " + ac22 + "%"]));


                    }
                    //041215


                    tot_employ.Rows[i]["sl"] = i + 1;
                }

                tot_employ.Columns[Str_ErHead_basic].SetOrdinal(table_count - 1);
                tot_employ.Columns["EPFBasic"].SetOrdinal(tot_employ.Columns.Count - 1);
                tot_employ.Columns["EPS(" + ac10 + "%)"].SetOrdinal(tot_employ.Columns.Count - 1);

                //tot_employ.Columns.Remove("ID");

                tot_employ.Columns[Str_ErHead_basic].SetOrdinal(4);
                tot_employ.Columns["EPFBasic"].SetOrdinal(5);
                tot_employ.Columns[Str_PF].SetOrdinal(6);
                tot_employ.Columns["EPS(" + ac10 + "%)"].SetOrdinal(7);
                tot_employ.Columns["Employer (" + ac01 + "%)"].SetOrdinal(8);

                tot_employ.Columns[Str_PF].ColumnName = "Emp Cont." + ac_pf + "%";

                tot_employ.Columns["A/C01 " + ac_pf + "%"].SetOrdinal(9);
                tot_employ.Columns["A/C01 " + ac01 + "%"].SetOrdinal(10);
                tot_employ.Columns["A/C02 " + ac02 + "%"].SetOrdinal(11);
                tot_employ.Columns["A/C10 " + ac10 + "%"].SetOrdinal(12);
                tot_employ.Columns["A/C21 " + ac21 + "%"].SetOrdinal(13);
                tot_employ.Columns["A/C22 " + ac22 + "%"].SetOrdinal(14);

                dt = tot_employ.Copy();

                dt.Columns.Remove("EPFBasic");
                dt.Columns.Remove("Emp Cont." + ac_pf + "%");
                dt.Columns.Remove("EPS(" + ac10 + "%)");
                dt.Columns.Remove("Employer (" + ac01 + "%)");
                dt.Columns.Remove("AgeYearsDecimal");
                dt.Rows.RemoveAt(final_rw+2);
                dt.Rows.RemoveAt(final_rw + 1);
                dt.Rows.RemoveAt(final_rw );
                dt.AcceptChanges();
                Head_Cou = dt.Columns.Count;

                int row = dt.Rows.Count, rw = 0;
                string id = "";
                //ac02 = "0.85";
                //ac21="0.5";
                //ac22 = "0.01";
                //ac01 = "3.67";
                //ac10 = "8.33";
                //ac_pf = "12";
                if (opt==1)
                {
                    for (int ind = 0; ind < (row - 3); ind++)
                    {

                        if (dt.Rows[ind]["id"].ToString().Trim() == id)
                        {
                            dt.Rows[rw]["BS"] = Convert.ToDouble(dt.Rows[rw]["BS"]) + Convert.ToDouble(dt.Rows[ind]["BS"]);
                           // dt.Rows[rw]["TotalEarning"] = Convert.ToDouble(dt.Rows[rw]["TotalEarning"]) + Convert.ToDouble(dt.Rows[ind]["TotalEarning"]);
                            dt.Rows[rw]["A/C01 " + ac_pf + "%"] = Convert.ToDouble(dt.Rows[rw]["A/C01 " + ac_pf + "%"]) + Convert.ToDouble(dt.Rows[ind]["A/C01 " + ac_pf + "%"]);
                            dt.Rows[rw]["A/C01 " + ac01 + "%"] = Convert.ToDouble(dt.Rows[rw]["A/C01 " + ac01 + "%"]) + Convert.ToDouble(dt.Rows[ind]["A/C01 " + ac01 + "%"]);
                            dt.Rows[rw]["A/C02 " + ac02 + "%"] = Convert.ToDouble(dt.Rows[rw]["A/C02 " + ac02 + "%"]) + Convert.ToDouble(dt.Rows[ind]["A/C02 " + ac02 + "%"]);
                            dt.Rows[rw]["A/C10 " + ac10 + "%"] = Convert.ToDouble(dt.Rows[rw]["A/C10 " + ac10 + "%"]) + Convert.ToDouble(dt.Rows[ind]["A/C10 " + ac10 + "%"]);
                            dt.Rows[rw]["A/C21 " + ac21 + "%"] = Convert.ToDouble(dt.Rows[rw]["A/C21 " + ac21 + "%"]) + Convert.ToDouble(dt.Rows[ind]["A/C21 " + ac21 + "%"]);
                            dt.Rows[rw]["A/C22 " + ac22 + "%"] = Convert.ToDouble(dt.Rows[rw]["A/C22 " + ac22 + "%"]) + Convert.ToDouble(dt.Rows[ind]["A/C22 " + ac22 + "%"]);

                            dt.Rows.RemoveAt(ind);
                            ind = ind - 1;
                            row = dt.Rows.Count;
                        }
                        else
                        {
                            id = dt.Rows[ind]["id"].ToString().Trim();
                            rw = ind;
                        }

                    }
                  
                }
                
                dt.Rows.Add();

             
            }

            //dgv_pfesi_csv.DataSource = dt;
            dgvCsv.Columns.Add("MemberID", "UAN");
            dgvCsv.Columns.Add("MemberName", "Member Name");
            dgvCsv.Columns.Add("Gross", "Gross Wages");
            dgvCsv.Columns.Add("EPFWage", "EPF Wages");
            dgvCsv.Columns.Add("EPSWage", "EPS Wages");
            dgvCsv.Columns.Add("EDLIWage", "EDLI Wages");

            dgvCsv.Columns.Add("EPFCont", "EPS Contribution");
            dgvCsv.Columns.Add("EPSCont", "EPS Contribution");
            dgvCsv.Columns.Add("EDLICont", "EDLI Contribution");

            //============================================================================================
            dgvCsv.Columns.Add("NcpDay", "NCP Days");
            dgvCsv.Columns.Add("NcpRef", "Refund of Advances");
            //****** convert the pf report in csv challan format ******
            //dgvCsv.Columns.Add("ID", "ID");
            ////dgvCsv.Columns.Add("MemberID","Member ID" );
            ////dgvCsv.Columns.Add("MemberName", "Member Name");
            ////dgvCsv.Columns.Add("EPFWage", "EPF Wages");
            ////dgvCsv.Columns.Add("EPSWage", "EPS Wages");
            ////dgvCsv.Columns.Add("EPFContDue", "EPF Contribution (EE Share) Due" );
            ////dgvCsv.Columns.Add("EPFContRem", "EPF Contribution (EE Share) being remitted");
            ////dgvCsv.Columns.Add("EPSContdue", "EPS Contribution Due");
            ////dgvCsv.Columns.Add("EPSContRem", "EPS Contribution being remitted");
            ////dgvCsv.Columns.Add("EpfEpsContDue", "Diff EPF && EPS Contribution (ER Share) due");
            ////dgvCsv.Columns.Add("EpfEpsContRem", "Diff EPF && EPS Contribution (ER Share) being remitted");
            //////============================================================================================
            ////dgvCsv.Columns.Add("NcpDay", "NCP Days");
            ////dgvCsv.Columns.Add("NcpRef", "Refund of Advances");
            ////dgvCsv.Columns.Add("NcpEpfWage", "Arrear EPF Wages");
            ////dgvCsv.Columns.Add("NcpEEShare", "Arrear EPF EE Share");
            ////dgvCsv.Columns.Add("NcpERShare", "Arrear EPF ER Share");
            ////dgvCsv.Columns.Add("NcpEPS", "Arrear EPS");
            //////=============================================================================================
            ////dgvCsv.Columns.Add("Guardian", "Father's / Husband's Name");
            ////dgvCsv.Columns.Add("Relation", "Relationship with Member");
            ////dgvCsv.Columns.Add("DOB", "Date of Birth");
            ////dgvCsv.Columns.Add("Gender", "Gender");
            ////dgvCsv.Columns.Add("DojEpf", "Date of Joining EPF");
            ////dgvCsv.Columns.Add("DojEps", "Date of Joining EPS");
            ////dgvCsv.Columns.Add("DoeEpf", "Date of Exit from EPF");
            ////dgvCsv.Columns.Add("DoeEps", "Date of Exit from EPS");
            ////dgvCsv.Columns.Add("RoL", "Reason for leaving");
            string EmpID = "",Ecode="", Mname="", Guardian,Rel, Gender,DOJ,DOB,join,locid="" ;
            DataTable val_personal;
            int basic, basic2,EPFContDue,EPSContdue,EPSContRem, Max_bs=15000;
            int max_EPSContdue = 541;

            lblEPS_Wages.Text = "EPS Wages [Max Rs. " + Max_bs + "]";
            lblEPSContdue.Text = "EPS Contribution being remitted [Max Rs. " + max_EPSContdue + "]";
            int ind_gv = 0,desgid=0;
            for (int i = 0; i <= dt.Rows.Count-1; i++)
            {
                EmpID = Convert.ToString(dt.Rows[i]["PF No"]).Trim();
                if (EmpID != "")
                {
                    ind_gv = dgvCsv.Rows.Add();
                    try
                    {
                        EmpID = EmpID.Substring(EmpID.LastIndexOf("/") + 1, 4);
                    }
                    catch(Exception ex)
                    {
                    EmpID="";
                    }

                    locid = Convert.ToString(dt.Rows[i]["Location_id"]).Trim();
                    desgid=Convert.ToInt32(dt.Rows[i]["desig_id"]);
                    Ecode=Convert.ToString(dt.Rows[i]["ID"]);
                    val_personal = clsDataAccess.RunQDTbl("SELECT (CASE WHEN em.pf_name != '' THEN em.pf_name ELSE ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) END) as EmpName," +
"FathFN + ' ' + FathMN + ' ' + FathLN AS FatherName,HusFN + ' ' + HusMN + ' ' + HusLN AS HusbandName,DateOfBirth as DOB, Gender,DateOfJoining as DOJ,em.PassportNo as uan FROM tbl_Employee_Mast em where (em.ID='" + Ecode + "')");
                    string uan = val_personal.Rows[0]["uan"].ToString();
                    Mname = val_personal.Rows[0]["EmpName"].ToString(); //clsDataAccess.GetresultS("SELECT em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName FROM tbl_Employee_Mast em where (em.ID='" + Ecode + "')");
                    if (val_personal.Rows[0]["HusbandName"].ToString() == "") { Guardian = val_personal.Rows[0]["HusbandName"].ToString(); Rel = "S"; } else { Guardian = val_personal.Rows[0]["FatherName"].ToString(); Rel = "F"; }
                    if (val_personal.Rows[0]["Gender"].ToString() == "Male") { Gender = "M"; } else if (val_personal.Rows[0]["Gender"].ToString() == "Female") { Gender = "F"; } else { Gender = "T"; }
                    DOJ = Convert.ToDateTime(val_personal.Rows[0]["DOJ"]).ToString("dd/MM/yyyy");
                    join = Convert.ToDateTime(val_personal.Rows[0]["DOJ"]).ToString("MM/yyyy");
                    DOB = Convert.ToDateTime(val_personal.Rows[0]["DOB"]).ToString("dd/MM/yyyy");
                    basic = Convert.ToInt32( Convert.ToDouble( dt.Rows[i]["BS"]));
                    if (basic > Max_bs) { basic2 = Max_bs; } else { basic2 = basic; }
                   
                    dgvCsv.Rows[ind_gv].Cells["MemberID"].Value = uan;
                    dgvCsv.Rows[ind_gv].Cells["MemberName"].Value = Mname;
                    if (pf_gs == 1)
                    {
                        dgvCsv.Rows[ind_gv].Cells["Gross"].Value = basic; //(clsDataAccess.GetresultS("SELECT cast(GrossAmount as numeric)GrossAmount FROM tbl_Employee_SalaryMast WHERE (Month = '" + month + "') AND (Session = '" + sess + "') AND (Emp_Id='" + Ecode + "') and (Location_id = '" + locid + "') and (Company_id='" + co_id + "')").ToString());
                    }
                    else
                    {
                        if (opt == 1)
                        {
                            dgvCsv.Rows[ind_gv].Cells["Gross"].Value = (clsDataAccess.GetresultS("SELECT cast(sum(GrossAmount) as numeric)GrossAmount FROM tbl_Employee_SalaryMast WHERE (Month = '" + month + "') AND (Session = '" + sess + "') AND (Emp_Id='" + Ecode + "') and (Company_id='" + co_id + "')").ToString());
                        }
                        else
                        {
                            dgvCsv.Rows[ind_gv].Cells["Gross"].Value = (clsDataAccess.GetresultS("SELECT cast(GrossAmount as numeric)GrossAmount FROM tbl_Employee_SalaryMast WHERE (Month = '" + month + "') AND (Session = '" + sess + "') AND (Emp_Id='" + Ecode + "') and (Location_id = '" + locid + "') and (Company_id='" + co_id + "') and (desig_id='" + desgid + "')").ToString());
                        }
                    }
                    dgvCsv.Rows[ind_gv].Cells["EPFWage"].Value = basic;
                    dgvCsv.Rows[ind_gv].Cells["EPSWage"].Value = basic2;
                    dgvCsv.Rows[ind_gv].Cells["EDLIWage"].Value = basic2;
                    EPFContDue = Convert.ToInt32(Convert.ToDouble(dt.Rows[i]["A/C01 " + ac_pf + "%"]));
                    dgvCsv.Rows[ind_gv].Cells["EPFCont"].Value = EPFContDue;

                    EPSContdue = Convert.ToInt32(Convert.ToDouble(dt.Rows[i]["A/C10 " + ac10 + "%"]));
                    //if(EPSContdue>541){EPSContRem=541;}else {
                    EPSContRem = EPSContdue;
                    //}
                    dgvCsv.Rows[ind_gv].Cells["EPSCont"].Value = EPSContdue;
                    dgvCsv.Rows[ind_gv].Cells["EDLICont"].Value = EPFContDue - EPSContdue;

                    //============================================================================================
                    dgvCsv.Rows[ind_gv].Cells["NcpDay"].Value = Convert.ToDouble( clsDataAccess.GetresultS("select Absent FROM tbl_Employee_Attend ea where desgid=(case when " + dt.Rows[i]["desig_id"].ToString() + "=0 then (select Desgid from  tbl_Employee_Mast where id=ea.id) else " + dt.Rows[i]["desig_id"].ToString() + " end) and location_id=" + locid + " and (month='" + Mon + "/" + yr + "') and (id='" + Ecode + "')")).ToString("00");
                    dgvCsv.Rows[ind_gv].Cells["NcpRef"].Value = 0;

                    //=============================================================================================
                    


                }

            }
           // dgvCsv.Columns["MemberID"].SortMode = DataGridViewColumnSortMode.Automatic;
        }



        private void frmEmployeePfEsiCsv_Load(object sender, EventArgs e)
        {
            lblPF_Esi_edit.Text = clsDataAccess.ReturnValue("select PfEsiEdit from CompanyLimiter");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            if (lblPF_Esi_edit.Text == "1")
            {
                bool bl=false;
                string sql,MemberID,MemberName,Gross,EPFWage,EPSWage,EDLIWage,EPFCont,EPSCont,EDLICont,NcpDay,NcpRef,mon,yr;
                for (int idx = 0; idx < dgvCsv.Rows.Count - 1; idx++)
                {
                    mon = lbl_Month.Text;
                    yr = lbl_yr.Text;

                    recalc(idx,dtec);

                    MemberID = dgvCsv.Rows[idx].Cells["MemberID"].Value.ToString();
                    MemberName = dgvCsv.Rows[idx].Cells["MemberName"].Value.ToString();
                    Gross = dgvCsv.Rows[idx].Cells["Gross"].Value.ToString();
                    EPFWage = dgvCsv.Rows[idx].Cells["EPFWage"].Value.ToString();
                    EPSWage = dgvCsv.Rows[idx].Cells["EPSWage"].Value.ToString();
                    EDLIWage = dgvCsv.Rows[idx].Cells["EDLIWage"].Value.ToString();
                    EPFCont = dgvCsv.Rows[idx].Cells["EPFCont"].Value.ToString();
                    EPSCont = dgvCsv.Rows[idx].Cells["EPSCont"].Value.ToString();
                    EDLICont = dgvCsv.Rows[idx].Cells["EDLICont"].Value.ToString();
                    NcpDay = dgvCsv.Rows[idx].Cells["NcpDay"].Value.ToString();
                    NcpRef = dgvCsv.Rows[idx].Cells["NcpRef"].Value.ToString();
                    
                    sql = "delete from tbl_Employee_PfEsiEdit where (MemberID='" + MemberID + "') and (mon='" + mon + "') and (yr='" + yr + "')";
                    clsDataAccess.RunQry(sql);
                     
                         sql="INSERT INTO [tbl_Employee_PfEsiEdit]"+
                         "(MemberID,MemberName,Gross,EPFWage,EPSWage,EDLIWage,EPFCont,EPSCont,EDLICont,NcpDay,NcpRef,mon,yr) values ('"+
                        MemberID+"','"+MemberName+"','"+Gross+"','"+EPFWage+"','"+EPSWage+"','"+EDLIWage+"','"+EPFCont+"','"+EPSCont+"','"+
                        EDLICont+"','"+NcpDay+"','"+NcpRef+"','"+mon+"','"+yr+"')";
                         clsDataAccess.RunQry(sql);
                        
                }
            }

            saveFileDialog1.FileName = "ECR" + DateAndTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_tt");
            saveFileDialog1.ShowDialog();
            string fpath = saveFileDialog1.FileName;
            
            string filePath = fpath ;
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            string delimiter = "#~#";
           
              int ind_gv_rw = dgvCsv.Rows.Count-1;
              int ind_gv_Col = dgvCsv.Columns.Count - 1;
              StringBuilder sb = new StringBuilder();
              //output =new[];
            for(int i = 0; i < ind_gv_rw; i++)
            {
                if (dgvCsv.Rows[i].Cells["MemberID"].Value.ToString().Trim() != "")
                {
                    output = new string[][]
                    {
                    new string[]
                      {
                        dgvCsv.Rows[i].Cells["MemberID"].Value.ToString(),                        
                        dgvCsv.Rows[i].Cells["MemberName"].Value.ToString().Trim(),
                        dgvCsv.Rows[i].Cells["Gross"].Value.ToString().Trim(),
                        dgvCsv.Rows[i].Cells["EPFWage"].Value.ToString().Trim(),
                        dgvCsv.Rows[i].Cells["EPSWage"].Value.ToString().Trim(),
                        dgvCsv.Rows[i].Cells["EDLIWage"].Value.ToString().Trim(),
                        dgvCsv.Rows[i].Cells["EPFCont"].Value.ToString().Trim(),
                        dgvCsv.Rows[i].Cells["EPSCont"].Value.ToString().Trim(),
                        dgvCsv.Rows[i].Cells["EDLICont"].Value.ToString().Trim(),
                        
                        //============================================================================================
                        dgvCsv.Rows[i].Cells["NcpDay"].Value.ToString().Trim(),
                        dgvCsv.Rows[i].Cells["NcpRef"].Value.ToString().Trim()
                      }
/*add the values that you want inside a csv file. Mostly this function can be used in a foreach loop.*/
                    };
                }
            int length = output.GetLength(0);
            for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));
            //sb.AppendLine();
            //sb.AppendLine("\n");
            }
            
            File.AppendAllText(filePath, sb.ToString());
            MessageBox.Show("File Created at : " + fpath , "BRAVO",MessageBoxButtons.OK, MessageBoxIcon.Information  );
        }
        
        private void dgvCsv_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (lblPF_Esi_edit.Text.Trim() == "1")
            {
                indx = e.RowIndex;
                if (dgvCsv.Rows.Count-1 != indx)
                {
                    recalc(indx,dtec);
                }
            }
        }

        private void dgvCsv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lblPF_Esi_edit.Text.Trim() == "1")
                {
                    indx=dgvCsv.CurrentCell.RowIndex;
                    if (dgvCsv.Rows.Count - 1 != indx)
                    {
                        recalc(indx,dtec);
                    }
                }
            }
        }

       
    }
}
