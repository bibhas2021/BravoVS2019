using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class Arrears : EDPComponent.FormBaseERP 
    {
        public Arrears()
        {
            InitializeComponent();
        }

        #region Function

        private Boolean  Validation()
        {
            Boolean boolStatus = false;
            if (clsValidation.ValidateEdpCombo(cmbdArrName, "", "Please Enter Arrear Name"))
            {
                if (clsValidation.ValidateComboBox(cmbFromMonth, "", "Please Enter From Month"))
                {
                    if (clsValidation.ValidateComboBox(cmbFromYear, "", "Please Enter From Year"))
                    {
                        if (clsValidation.ValidateComboBox(cmbToMonth, "", "Please Enter To Month"))
                        {
                            if (clsValidation.ValidateComboBox(cmbToYear, "", "Please Enter To Year"))
                            {
                                if (clsValidation.ValidateComboBox(cmbEffMonth, "", "Please Enter Effect From Month"))
                                {
                                    if (clsValidation.ValidateComboBox(cmbEffYear, "", "Please Enter Effect From Year"))
                                    {
                                        if (dgArrear.Rows.Count > 0)
                                        {
                                            boolStatus = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return boolStatus;
        }

        private DataTable GetTotalErnHeads()
        {
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");
            return dtErn;
        }

        private DataTable GetTotalDeductionHeads()
        {
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");
            return dtDeduction;
        }

        private DataTable GetTotalPFHeads()
        {
            DataTable dtPF = clsDataAccess.RunQDTbl("select ShortName,SlNo from tbl_Employee_Config_PFHeads ");
            return dtPF;
        }

        private DataTable GetSalaryHeads()
        {
            DataTable dtSalaryHead = new DataTable();
            DataTable dtErn = GetTotalErnHeads();
            DataTable dtDeduction = GetTotalDeductionHeads();
            DataTable dtPF = GetTotalPFHeads();

            dtSalaryHead.Columns.Add("SalaryHead");
            dtSalaryHead.Columns.Add("ID");
            dtSalaryHead.Columns.Add("TableName");
            
            for (Int32 i = 0; i < dtErn.Rows.Count; i++)
            {
                dtSalaryHead.Rows.Add();
                dtSalaryHead.Rows[i]["SalaryHead"] = Convert.ToString(dtErn.Rows[i]["SalaryHead_Short"]);
                dtSalaryHead.Rows[i]["ID"] = Convert.ToString(dtErn.Rows[i]["SlNo"]);
                dtSalaryHead.Rows[i]["TableName"] = Convert.ToString("tbl_Employee_ErnSalaryHead");
            }

            for (Int32 i = 0; i < dtPF.Rows.Count; i++)
            {
                dtSalaryHead.Rows.Add();
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = Convert.ToString(dtPF.Rows[i]["ShortName"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["ID"] = Convert.ToString(dtPF.Rows[i]["SlNo"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["TableName"] = Convert.ToString("tbl_Employee_Config_PFHeads");
            }

            for (Int32 i = 0; i < dtDeduction.Rows.Count; i++)
            {
                dtSalaryHead.Rows.Add();
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["SalaryHead"] = Convert.ToString(dtDeduction.Rows[i]["SalaryHead_Short"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["ID"] = Convert.ToString(dtDeduction.Rows[i]["SlNo"]);
                dtSalaryHead.Rows[dtSalaryHead.Rows.Count - 1]["TableName"] = Convert.ToString("tbl_Employee_DeductionSalayHead");
            }

            
            return dtSalaryHead;
        }

        private void PopulateSalaryHeadsInGrid()
        {
            DataTable dt= GetSalaryHeads();
            if (dt.Rows.Count > 0)
            {
                dgArrear.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgArrear.Rows.Add();
                    dgArrear.Rows[i].Cells["SalHead"].Value = dt.Rows[i]["SalaryHead"];
                    dgArrear.Rows[i].Cells["SalId"].Value = dt.Rows[i]["ID"];
                    dgArrear.Rows[i].Cells["SalTable"].Value = dt.Rows[i]["TableName"];

                    if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["TableName"])))
                    {
                        if (Convert.ToString(dt.Rows[i]["TableName"]).ToLower().Trim() == "tbl_employee_ernsalaryhead")
                        {
                            dgArrear.Rows[i].Cells["SalHead"].Style.BackColor = Color.MistyRose;
                        }
                        else if (Convert.ToString(dt.Rows[i]["TableName"]).ToLower().Trim() == "tbl_employee_deductionsalayhead")
                        {
                            dgArrear.Rows[i].Cells["SalHead"].Style.BackColor = Color.Moccasin;
                        }
                        else if (Convert.ToString(dt.Rows[i]["TableName"]).ToLower().Trim() == "tbl_employee_config_pfheads")
                        {
                            dgArrear.Rows[i].Cells["SalHead"].Style.BackColor = Color.Aquamarine;
                        }
                    }
                }
            }
        }

        private Boolean ExArrearMast(Int32 ArrearId)
        {
            Boolean boolStatus = false;
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_ArrearMast where ArrearId="+ ArrearId +"");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }
            return boolStatus;
        }

        private Boolean ExArrearDet(Int32 intArrearId,Int32 intSalId,String strSalTable)
        {
            Boolean boolStatus = false;
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_ArrearDet where ArrearId=" + intArrearId + " and SalId=" + intSalId + " and SalTable='" + strSalTable + "'");
            if (dt.Rows.Count > 0)
            {
                boolStatus = true;
            }
            return boolStatus;
        }

        private Boolean InsertIntoArrearMast()
        {
            Boolean boolStatus = false;
            if (!String.IsNullOrEmpty(cmbdArrName.ReturnValue))
            {
                if (ExArrearMast(Convert.ToInt32(cmbdArrName.ReturnValue)))
                {
                    boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Config_ArrearMast set ArrearName='" + cmbdArrName.Text.Trim() + "',ArrearDesc='" + txtArrDesc.Text.Trim() + "',FromMonth='" + cmbFromMonth.Text.Trim() + "',FromYear=" + cmbFromYear.Text.Trim() + ",ToMonth='" + cmbToMonth.Text.Trim() + "',ToYear=" + cmbToYear.Text.Trim() + ",EffMonth='" + cmbEffMonth.Text.Trim() + "',EffYear=" + cmbEffYear.Text.Trim() + " where ArrearId=" + Convert.ToInt32(cmbdArrName.ReturnValue) + "");
                }
                else
                {
                    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_ArrearMast(ArrearName,ArrearDesc,FromMonth,FromYear,ToMonth,ToYear,EffMonth,EffYear) values('" + cmbdArrName.Text.Trim() + "','" + txtArrDesc.Text.Trim() + "','" + cmbFromMonth.Text.Trim() + "'," + cmbFromYear.Text.Trim() + ",'" + cmbToMonth.Text.Trim() + "'," + cmbToYear.Text.Trim() + ",'" + cmbEffMonth.Text.Trim() + "'," + cmbEffYear.Text.Trim() + ")");
                }
            }
            else
            {
                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_ArrearMast(ArrearName,ArrearDesc,FromMonth,FromYear,ToMonth,ToYear,EffMonth,EffYear) values('" + cmbdArrName.Text.Trim() + "','" + txtArrDesc.Text.Trim() + "','" + cmbFromMonth.Text.Trim() + "'," + cmbFromYear.Text.Trim() + ",'" + cmbToMonth.Text.Trim() + "'," + cmbToYear.Text.Trim() + ",'" + cmbEffMonth.Text.Trim() + "'," + cmbEffYear.Text.Trim() + ")");
            }
            return boolStatus;
        }

        private Boolean InsertIntoArrearDet(Int32 intArrearId)
        {
            Boolean boolStatus = false;

            if (dgArrear.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dgArrear.Rows.Count; i++)
                {

                    String strSalId = Convert.ToString(dgArrear.Rows[i].Cells["SalId"].Value);
                    if (String.IsNullOrEmpty(strSalId))
                    {
                        strSalId = "0";
                    }
                    String strSalTable = Convert.ToString(dgArrear.Rows[i].Cells["SalTable"].Value);
                    String strPayType = Convert.ToString(dgArrear.Rows[i].Cells["Type"].Value);
                    String strAmt = Convert.ToString(dgArrear.Rows[i].Cells["Amount"].Value);
                    Decimal decAmt=0.00m;
                    if (!String.IsNullOrEmpty(strAmt))
                    {
                        decAmt = Convert.ToDecimal(strAmt);
                    }
                    
                    String strPayMode = Convert.ToString(dgArrear.Rows[i].Cells["PayMode"].Value);
                    String strPayMode_sub = Convert.ToString(dgArrear.Rows[i].Cells["pay"].Value);

                    if ((decAmt > 0))
                    {
                        if ((!String.IsNullOrEmpty(cmbdArrName.ReturnValue)))
                        {
                            if (ExArrearDet(Convert.ToInt32(cmbdArrName.ReturnValue), Convert.ToInt32(strSalId), strSalTable))
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Config_ArrearDet set PayType='" + strPayType + "',Amount=" + decAmt + ",PayMode='" + strPayMode + "',PayMode_sub='" + strPayMode_sub + "' where ArrearId=" + intArrearId + " and SalId=" + strSalId + " and SalTable='" + strSalTable + "'");
                            }
                            else
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_ArrearDet(ArrearId,SalId,SalTable,PayType,Amount,PayMode,PayMode_sub) values(" + intArrearId + "," + strSalId + ",'" + strSalTable + "','" + strPayType + "'," + decAmt + ",'" + strPayMode + "','" + strPayMode_sub + "')");
                            }
                        }
                        else
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_ArrearDet(ArrearId,SalId,SalTable,PayType,Amount,PayMode,PayMode_sub) values(" + intArrearId + "," + strSalId + ",'" + strSalTable + "','" + strPayType + "'," + decAmt + ",'" + strPayMode + "','" + strPayMode_sub + "')");
                        }
                    }
                }
            }
            return boolStatus;
        }

        private Int32 GetLastInsertedArrearId()
        {
            Int32 intArrearId = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select top 1 ArrearId from tbl_Employee_Config_ArrearMast order by InsertionDate desc");
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ArrearId"])))
                {
                    intArrearId = Convert.ToInt32(dt.Rows[0]["ArrearId"]);
                }
            }
            return intArrearId;
        }

        private void ClearControl()
        {
            cmbdArrName.Text = String.Empty;
            txtArrDesc.Text = String.Empty;
            cmbFromMonth.Items.Clear();
            cmbFromYear.Items.Clear();
            cmbToMonth.Items.Clear();
            cmbToYear.Items.Clear();
            cmbEffMonth.Items.Clear();
            cmbEffYear.Items.Clear();
            
            PopulateSalaryHeadsInGrid();
        }

        private void ClearControlAcceptArrName()
        {
            //cmbdArrName.Text = String.Empty;
            txtArrDesc.Text = String.Empty;
            cmbFromMonth.Items.Clear();
            cmbFromYear.Items.Clear();
            cmbToMonth.Items.Clear();
            cmbToYear.Items.Clear();
            cmbEffMonth.Items.Clear();
            cmbEffYear.Items.Clear();

            PopulateSalaryHeadsInGrid();
        }

        private void GetAllArrears()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select ArrearName,ArrearId,ArrearDesc from tbl_Employee_Config_ArrearMast");
            cmbdArrName.LookUpTable = dt;
            cmbdArrName.ReturnIndex = 1;
        }

        private void GetArrMastDetailsByArrId(Int32 ArrearId)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_ArrearMast where ArrearId=" + ArrearId + "");
            if (dt.Rows.Count > 0)
            {
                txtArrDesc.Text = Convert.ToString(dt.Rows[0]["ArrearDesc"]);
                cmbFromMonth_DropDown(cmbFromMonth, new EventArgs());
                cmbFromMonth.SelectedItem = Convert.ToString(dt.Rows[0]["FromMonth"]);
                cmbFromYear_DropDown(cmbFromYear, new EventArgs());
                cmbFromYear.SelectedItem = Convert.ToString(dt.Rows[0]["FromYear"]);
                cmbToMonth_DropDown(cmbToMonth, new EventArgs());
                cmbToMonth.SelectedItem = Convert.ToString(dt.Rows[0]["ToMonth"]);
                cmbToYear_DropDown(cmbToYear, new EventArgs());
                cmbToYear.SelectedItem = Convert.ToString(dt.Rows[0]["ToYear"]);
                cmbEffMonth_DropDown(cmbEffMonth, new EventArgs());
                cmbEffMonth.SelectedItem = Convert.ToString(dt.Rows[0]["EffMonth"]);
                cmbEffYear_DropDown(cmbEffYear, new EventArgs());
                cmbEffYear.SelectedItem = Convert.ToString(dt.Rows[0]["EffYear"]);
            }
        }

        private void GetArrDetByArrId(Int32 ArrearId)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_ArrearDet where ArrearId=" + ArrearId + "");
            if (dt.Rows.Count > 0)
            {
                if (dgArrear.Rows.Count > 0)
                {
                    for (Int32 intDgRow = 0; intDgRow < dgArrear.Rows.Count; intDgRow++)
                    {
                        String strDgSalId = Convert.ToString(dgArrear.Rows[intDgRow].Cells["SalId"].Value);
                        String strDgSalTable = Convert.ToString(dgArrear.Rows[intDgRow].Cells["SalTable"].Value);

                        for (Int32 intDtRow = 0; intDtRow < dt.Rows.Count; intDtRow++)
                        {
                            String strDtSalId = Convert.ToString(dt.Rows[intDtRow]["SalId"]);
                            String strDtSalTable = Convert.ToString(dt.Rows[intDtRow]["SalTable"]);

                            if (!String.IsNullOrEmpty(strDtSalId) && !String.IsNullOrEmpty(strDgSalId))
                            {
                                if (strDtSalId == strDgSalId && strDtSalTable == strDgSalTable)
                                {
                                    dgArrear.Rows[intDgRow].Cells["Type"].Value = dt.Rows[intDtRow]["PayType"];
                                    dgArrear.Rows[intDgRow].Cells["Amount"].Value = dt.Rows[intDtRow]["Amount"];
                                    dgArrear.Rows[intDgRow].Cells["PayMode"].Value = dt.Rows[intDtRow]["PayMode"];
                                    dgArrear.Rows[intDgRow].Cells["pay"].Value = dt.Rows[intDtRow]["PayMode_sub"];
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion


        private void Arrears_Load(object sender, EventArgs e)
        {
            PopulateSalaryHeadsInGrid();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                if (InsertIntoArrearMast())
                {
                    Int32 intArrearId=GetLastInsertedArrearId();
                    if (intArrearId > 0)
                    {
                        if (InsertIntoArrearDet(intArrearId))
                        {
                            ClearControl();
                            ERPMessageBox.ERPMessage.Show("Arrear Details Submitted Successfully");
                        }
                    }
                }
            }
        }

        private void dgArrear_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgArrear.CurrentRow.Cells["Type"].ColumnIndex)
            {
                
            }
        }        

        private void cmbFromYear_DropDown(object sender, EventArgs e)
        {
            clsEmployee.GenerateYear(cmbFromYear);
        }

        private void cmbToYear_DropDown(object sender, EventArgs e)
        {
            clsEmployee.GenerateYear(cmbToYear);
        }

        private void cmbEffYear_DropDown(object sender, EventArgs e)
        {
            clsEmployee.GenerateYear(cmbEffYear);
        }

        private void cmbdArrName_DropDown(object sender, EventArgs e)
        {
            GetAllArrears();
        }

        private void cmbFromMonth_DropDown(object sender, EventArgs e)
        {
           clsEmployee.PopulateMonthByName(cmbFromMonth);
        }

        private void cmbToMonth_DropDown(object sender, EventArgs e)
        {
            clsEmployee.PopulateMonthByName(cmbToMonth);
        }

        private void cmbEffMonth_DropDown(object sender, EventArgs e)
        {
            clsEmployee.PopulateMonthByName(cmbEffMonth);
        }

        private void cmbdArrName_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbdArrName.ReturnValue))
            {
                ClearControlAcceptArrName();
                GetArrMastDetailsByArrId(Convert.ToInt32(cmbdArrName.ReturnValue));
                GetArrDetByArrId(Convert.ToInt32(cmbdArrName.ReturnValue));
            }
        }             
    }
}