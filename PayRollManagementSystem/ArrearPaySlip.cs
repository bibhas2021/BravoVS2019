using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class ArrearPaySlip : EDPComponent.FormBaseERP
    {
        public ArrearPaySlip()
        {
            InitializeComponent();
        }

        private void GetAllArrear()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select ArrearName,ArrearId from tbl_Employee_Config_ArrearMast");
            if (dt.Rows.Count > 0)
            {
                cmbArrearName.LookUpTable = dt;
                cmbArrearName.ReturnIndex = 1;
            }
        }

        private void GetHeader()
        {


            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");

            for (int i = 0; i < dtDeduction.Rows.Count; i++)
            {
                dgArrear.Columns.Add(Convert.ToString(dtDeduction.Rows[i]["SalaryHead_Short"]), Convert.ToString(dtDeduction.Rows[i]["SalaryHead_Short"]));
                dgArrear.Columns[Convert.ToString(dtDeduction.Rows[i]["SalaryHead_Short"])].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgArrear.Columns[Convert.ToString(dtDeduction.Rows[i]["SalaryHead_Short"])].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            dgArrear.Columns.Add("TotalDeduc", "Total Deduction");
            dgArrear.Columns["TotalDeduc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgArrear.Columns["TotalDeduc"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgArrear.Columns.Add("NetPay", "Net Pay");
            dgArrear.Columns["NetPay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgArrear.Columns["NetPay"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        private DataTable GetDtHeader()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SlNo");
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("BasicDA");
            dt.Columns.Add("TotalDA");
            dt.Columns.Add("DADrawn");
            dt.Columns.Add("DADiff");
            dt.Columns.Add("GrandTotal");
            dt.Columns.Add("OnWhichPFDed");
            dt.Columns.Add("LWPds");
            dt.Columns.Add("LWPGross");
            dt.Columns.Add("LWPAmountonPFDed");
            dt.Columns.Add("LWPfrmGrandTotal");
            dt.Columns.Add("GrossAfterLWP");
            dt.Columns.Add("GrossAmtAfterLWP");
            dt.Columns.Add("AfterWhichPFDecLWP");
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");

            for (int i = 0; i < dtDeduction.Rows.Count; i++)
            {
                dt.Columns.Add(Convert.ToString(dtDeduction.Rows[i]["SalaryHead_Short"]));
            }

            dt.Columns.Add("TotalDeduc");
            dt.Columns.Add("NetPay");
            return dt;
        }

        private decimal Basic(string ID)
        {
            decimal dcBasic = 0.00m, dcDA = 0.00m, dcTotal = 0.00m;
            DataTable dtArrSal = clsDataAccess.RunQDTbl("select EffMonth from tbl_Employee_Config_ArrearMast where ArrearId='" + cmbArrearName.ReturnValue + "' and EffYear='" + cmbYear.Text.Substring(0, 4) + "'");
            DataTable dtBasicSalary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + ID + "' and SalId='3' and TableName='tbl_Employee_ErnSalaryHead' and Month='" + Convert.ToString(dtArrSal.Rows[0]["EffMonth"]) + "' and Session='" + cmbYear.Text.Trim() + "'");
            DataTable dtDASalary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + ID + "' and SalId='6' and TableName='tbl_Employee_ErnSalaryHead' and Month='" + Convert.ToString(dtArrSal.Rows[0]["EffMonth"]) + "' and Session='" + cmbYear.Text.Trim() + "'");

            if (dtBasicSalary.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(dtBasicSalary.Rows[0]["Amount"].ToString()))
                {
                    dcBasic = Convert.ToDecimal(dtBasicSalary.Rows[0]["Amount"].ToString());
                }
                else
                {
                    dcBasic = 0;
                }
            }



            dcTotal = dcBasic;
            return dcTotal;
        }
        private DataTable GetDetails()
        {
            decimal dcDASal = 0.00m;
            DataTable dt = GetDtHeader();
            DataTable dtArrSal = clsDataAccess.RunQDTbl("select mast.EffMonth,mast.FromMonth,mast.ToMonth,mast.FromYear,mast.ToYear,det.SalId,det.PayType,det.PayMode,det.SalTable,det.Amount from tbl_Employee_Config_ArrearDet det,dbo.tbl_Employee_Config_ArrearMast mast where det.ArrearId='" + cmbArrearName.ReturnValue + "' and det.ArrearId=mast.ArrearId");
            //DataTable dtArrear = clsDataAccess.RunQDTbl("select EffMonth from tbl_Employee_Config_ArrearMast where ArrearId='" + cmbArrearName.ReturnValue + "' and EffYear='" + cmbYear.Text.Substring(0, 4) + "'");

            if (dtArrSal.Rows.Count > 0)
            {

                DataTable dtEmp = clsDataAccess.RunQDTbl("select ID,FirstName+' '+MiddleName+' '+LastName Name from tbl_Employee_Mast where Session='" + cmbYear.Text.Trim() + "'");
                if (dtEmp.Rows.Count > 0)
                {
                    for (Int32 i = 0; i < dtEmp.Rows.Count; i++)
                    {
                        dt.Rows.Add();
                        foreach (DataColumn dc in dt.Columns) { dt.Rows[i][dc.ColumnName] = "0"; }


                        DataTable dtSalary = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + Convert.ToString(dtEmp.Rows[i]["ID"]) + "' and SalId='" + Convert.ToString(dtArrSal.Rows[0]["Salid"]) + "' and TableName='tbl_Employee_ErnSalaryHead' and Month='" + Convert.ToString(dtArrSal.Rows[0]["EffMonth"]) + "' and Session='" + cmbYear.Text.Trim() + "'");
                        dt.Rows[i]["ID"] = Convert.ToString(dtEmp.Rows[i]["ID"]);
                        dt.Rows[i]["Name"] = Convert.ToString(dtEmp.Rows[i]["Name"]);
                        dt.Rows[i]["BasicDA"] = Basic(Convert.ToString(dtEmp.Rows[i]["ID"]));


                        if (dtSalary.Rows.Count > 0)
                        {
                            if (!String.IsNullOrEmpty(dtSalary.Rows[0]["Amount"].ToString()))
                            {
                                dcDASal = Convert.ToDecimal(dtSalary.Rows[0]["Amount"].ToString());
                            }
                            else
                            {
                                dcDASal = 0;
                            }
                        }
                        dt.Rows[i]["DADrawn"] = dcDASal.ToString("0.00");
                        if (Convert.ToString(dtArrSal.Rows[0]["PayType"]).ToLower() == "amount")
                        {
                            dcDASal += Convert.ToDecimal(dtArrSal.Rows[0]["Amount"].ToString());
                        }
                        else
                        {
                            dcDASal += Convert.ToDecimal(dtArrSal.Rows[0]["Amount"].ToString()) * (dcDASal / 100);
                        }

                        dt.Rows[i]["TotalDA"] = dcDASal.ToString("0.00");
                        decimal dcDiff = Convert.ToDecimal(dt.Rows[i]["TotalDA"]) - Convert.ToDecimal(dt.Rows[i]["DADrawn"]);
                        dt.Rows[i]["DADiff"] = dcDiff.ToString("0.00");

                        int frmMon = clsEmployee.GetMonth_SingleDigit(Convert.ToString(dtArrSal.Rows[0]["FromMonth"]));
                        int toMon = clsEmployee.GetMonth_SingleDigit(Convert.ToString(dtArrSal.Rows[0]["ToMonth"]));
                        int frmYear = Convert.ToInt32(dtArrSal.Rows[0]["FromYear"]);
                        int toYear = Convert.ToInt32(dtArrSal.Rows[0]["ToYear"]);
                        int totalMon = 0, totalYr = 0;
                        if (toYear > frmYear)
                        {
                            totalYr = (toYear - frmYear);
                            if (frmMon > toMon)
                            {

                                totalMon = totalYr * 12 + (frmMon + toMon);
                            }
                            else
                            {
                                totalMon = totalYr * 12 + (toMon - frmMon);
                            }
                        }
                        else if (toYear == frmYear)
                        {
                            totalMon = toMon - frmMon;
                        }
                        dt.Rows[i]["GrandTotal"] = totalMon * dcDiff;
                        dt.Rows[i]["GrossAmtAfterLWP"] = Convert.ToDecimal(dt.Rows[i]["GrandTotal"]) - Convert.ToDecimal(dt.Rows[i]["LWPAmountonPFDed"]);
                        dt.Rows[i]["AfterWhichPFDecLWP"] = Convert.ToDecimal(dt.Rows[i]["GrossAmtAfterLWP"]);
                        dt.Rows[i]["NetPay"] = Convert.ToDecimal(dt.Rows[i]["GrandTotal"]) - Convert.ToDecimal(dt.Rows[i]["TotalDeduc"]);
                    }
                }
            }
            return dt;
        }

        private void ArrearPaySlip_Load(object sender, EventArgs e)
        {
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
            //GetHeader();

        }

        private void cmbArrearName_DropDown(object sender, EventArgs e)
        {
            GetAllArrear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //GetHeader();
            DataTable dt = GetDetails();

            dgArrear.DataSource = dt;
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            bool boolStatus = false;
            DataTable dtArrSal = clsDataAccess.RunQDTbl("select mast.EffMonth,mast.FromMonth,mast.ToMonth,mast.FromYear,mast.ToYear,det.SalId,det.PayType,det.PayMode,det.SalTable,det.Amount from tbl_Employee_Config_ArrearDet det,dbo.tbl_Employee_Config_ArrearMast mast where det.ArrearId='" + cmbArrearName.ReturnValue + "' and det.ArrearId=mast.ArrearId");
            if (dtArrSal.Rows.Count > 0)
            {
                if (dgArrear.Rows.Count > 0)
                {
                    for (int i = 0; i < dgArrear.Rows.Count; i++)
                    {

                        DataTable dtAmount = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month='" + dtArrSal.Rows[0]["EffMonth"] + "' and TableName='tbl_Employee_ErnSalaryHead' and SalId='" + dtArrSal.Rows[0]["SalId"] + "' and EmpId='" + Convert.ToString(dgArrear.Rows[i].Cells["ID"].Value.ToString()) + "'");
                        DataTable dtNet = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryMast where Emp_Id='" + Convert.ToString(dgArrear.Rows[i].Cells["ID"].Value.ToString()) + "' and Month='" + dtArrSal.Rows[0]["EffMonth"] + "' and Session='" + cmbYear.Text + "'");

                        if (Convert.ToString(dtArrSal.Rows[0]["PayMode"]).ToLower() == "pay in salary")
                        {
                            if (dtAmount.Rows.Count > 0)
                            {
                                decimal dcAmt = Convert.ToDecimal(dtAmount.Rows[0]["Amount"]) + Convert.ToDecimal(dgArrear.Rows[i].Cells["NetPay"].Value.ToString());
                                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_SalaryDet set Amount='" + dcAmt + "' where Session='" + cmbYear.Text + "' and Month='" + Convert.ToString(dtArrSal.Rows[0]["EffMonth"]) + "' and TableName='tbl_Employee_ErnSalaryHead' and SalId='" + dtArrSal.Rows[0]["SalId"] + "' and EmpId='" + Convert.ToString(dgArrear.Rows[i].Cells["ID"].Value.ToString()) + "'");
                            }
                            if (dtNet.Rows.Count > 0)
                            {
                                decimal dcNet = Convert.ToDecimal(dtNet.Rows[0]["NetPay"]) + Convert.ToDecimal(dgArrear.Rows[i].Cells["NetPay"].Value.ToString());
                                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_SalaryMast set NetPay='" + dcNet + "', Special='" + Convert.ToDecimal(dgArrear.Rows[i].Cells["NetPay"].Value.ToString()) + "' where Session='" + cmbYear.Text + "' and Month='" + Convert.ToString(dtArrSal.Rows[0]["EffMonth"]) + "' and Emp_Id='" + Convert.ToString(dgArrear.Rows[i].Cells["ID"].Value.ToString()) + "'");
                            }
                        }
                        else
                        {
                            if (dtNet.Rows.Count > 0)
                            {
                                decimal dcNet =  Convert.ToDecimal(dgArrear.Rows[i].Cells["Net Pay"].Value.ToString());
                                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_SalaryMast set Special='" + dcNet + "' where Session='" + cmbYear.Text + "' and Month='" + Convert.ToString(dtArrSal.Rows[0]["EffMonth"]) + "' and Emp_Id='" + Convert.ToString(dgArrear.Rows[i].Cells["ID"].Value.ToString()) + "'");
                            }
                        }
                    }
                }

            }
            if (boolStatus == true)
            {

                ERPMessageBox.ERPMessage.Show("Arrear Details Submitted Successfully.");
                
            }
        }
    }
}