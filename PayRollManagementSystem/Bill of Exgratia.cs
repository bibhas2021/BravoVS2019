using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERPMessageBox;
using EDPComponent;

namespace PayRollManagementSystem
{
    public partial class Bill_of_Exgratia : EDPComponent.FormBaseERP 
    {
        public Bill_of_Exgratia()
        {
            InitializeComponent();
        }

        private void GetAllExgratia()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select ExGratia_Name,Session,ExGratia_Id from tbl_Employee_Config_Exgratia where Session=" + cmbYear.Text.Trim() + "");
            cmbExgratiaName.LookUpTable = dt;
            cmbExgratiaName.ReturnIndex = 2;
        }

        private DataTable  GetDetails()
        {
            String[] strtArrDeducName = new String[0];
            Int32[] intArrDeducId = new Int32[lstSelectedHead.Items.Count];
            strtArrDeducName = new String[lstSelectedHead.Items.Count];
            String strSession = cmbYear.Text.Trim() + "-" + (Convert.ToInt32(cmbYear.Text.Trim()) + 1);


            for (Int32 i = 0; i < lstSelectedHead.Items.Count; i++)
            {
                DataTable dtDeducId = clsDataAccess.RunQDTbl("select SlNo from tbl_Employee_DeductionSalayHead where SalaryHead_Short='" + lstSelectedHead.Items[i].ToString() + "'");
                intArrDeducId[i] = Convert.ToInt32(dtDeducId.Rows[0]["SlNo"]);
            }

            DataTable dtGetDetails = new DataTable();
            dtGetDetails.Columns.Add("SlNo");
            dtGetDetails.Columns.Add("Name");
            dtGetDetails.Columns.Add("Total Salary");
            dtGetDetails.Columns.Add("Exgratia");
            for (int i = 0; i < intArrDeducId.Length; i++)
            {
                dtGetDetails.Columns.Add(lstSelectedHead.Items[i].ToString());
            }

            dtGetDetails.Columns.Add("Total Deduction");
            dtGetDetails.Columns.Add("Net Amount Payable");

            DataTable dtEmployee = clsDataAccess.RunQDTbl("select ID,FirstName+' '+MiddleName+' '+LastName as [Employee Name] from tbl_Employee_Mast where Session='" + strSession + "'");
            decimal dcNetPay = 0.00m, dcExgratia = 0.00m, dcDeduc = 0.00m, dcTotalDeduc = 0.00m;
            if (dtEmployee.Rows.Count > 0)
            {
                for (int i = 0; i < dtEmployee.Rows.Count; i++)
                {
                    dcNetPay = 0;
                    dcExgratia = 0;
                    dcDeduc = 0;
                    dcTotalDeduc = 0;
                    dtGetDetails.Rows.Add();
                    dtGetDetails.Rows[i]["SlNo"] = i + 1;
                    dtGetDetails.Rows[i]["Name"] = dtEmployee.Rows[i]["Employee Name"].ToString();
                    for (int j = 1; j <= 12; j++)
                    {
                        DataTable dtNetpay = clsDataAccess.RunQDTbl("select NetPay from tbl_Employee_SalaryMast where Month='" + clsEmployee.GetMonthName(j) + "' and Session='" + strSession + "' and Emp_Id='" + dtEmployee.Rows[i]["ID"] + "'");
                        if (dtNetpay.Rows.Count > 0)
                        {
                            if (!String.IsNullOrEmpty(dtNetpay.Rows[0]["NetPay"].ToString()))
                            {
                                dcNetPay += Convert.ToDecimal(dtNetpay.Rows[0]["NetPay"].ToString());
                            }
                        }
                    }

                    dtGetDetails.Rows[i]["Total Salary"] = dcNetPay.ToString("0.00");

                    for (int j = 1; j <= 12; j++)
                    {
                        //DataTable dtExgratia = clsDataAccess.RunQDTbl("select Emp_Id,Session,Month,Special from tbl_Employee_SalaryMast where Emp_Id='" + dtEmployee.Rows[i]["ID"] + "' and Session='" + strSession + "' and Month='" + clsEmployee.GetMonthName(j) + "'");
                        //if (dtExgratia.Rows.Count > 0)
                        //{
                        //    if (!String.IsNullOrEmpty(dtExgratia.Rows[0]["Special"].ToString()))
                        //    {
                        //        dcExgratia += Convert.ToDecimal(dtExgratia.Rows[0]["Special"].ToString());
                        //    }
                        //}

                        dcExgratia += GetExgratia(Convert.ToString(dtEmployee.Rows[i]["ID"]), j, Convert.ToInt32(cmbExgratiaName.ReturnValue));                           




                    }

                    dtGetDetails.Rows[i]["Exgratia"] = dcExgratia.ToString("0.00");


                    for (int k = 0; k < intArrDeducId.Length; k++)
                    {
                        dcDeduc = 0;
                        for (int j = 1; j <= 12; j++)
                        {

                            DataTable dtDeduc = clsDataAccess.RunQDTbl("select * from tbl_Employee_SalaryDet where EmpId='" + dtEmployee.Rows[i]["ID"] + "' and SalId='" + intArrDeducId[k] + "' and TableName='tbl_Employee_DeductionSalayHead' and Month='" + clsEmployee.GetMonthName(j) + "' and Session='" + strSession + "'");

                            if (dtDeduc.Rows.Count > 0)
                            {
                                if (!String.IsNullOrEmpty(dtDeduc.Rows[0]["Amount"].ToString()))
                                {
                                    dcDeduc += Convert.ToDecimal(dtDeduc.Rows[0]["Amount"].ToString());
                                }
                            }
                        }
                        dtGetDetails.Rows[i][lstSelectedHead.Items[k].ToString()] = dcDeduc.ToString("0.00");
                        dcTotalDeduc += Convert.ToDecimal(dtGetDetails.Rows[i][lstSelectedHead.Items[k].ToString()]);
                    }

                    dtGetDetails.Rows[i]["Total Deduction"] = dcTotalDeduc.ToString();

                    dtGetDetails.Rows[i]["Net Amount Payable"] = Convert.ToDecimal(dtGetDetails.Rows[i]["Exgratia"]) - Convert.ToDecimal(dtGetDetails.Rows[i]["Total Deduction"]);

                }
            }
            dtGetDetails.Rows.Add(); 
            
            dtGetDetails.Rows[dtGetDetails.Rows.Count - 1]["Name"] = "TOTAL";
            dtGetDetails.Rows[dtGetDetails.Rows.Count - 1]["Total Salary"] = "TOTAL AMOUNT";

            Decimal dcTotal = 0.00m;
            for (int j = 2; j < dtGetDetails.Columns.Count;j++ )
            {
                dcTotal = 0;
                for (int i = 0; i < dtGetDetails.Rows.Count - 1; i++)
                {
                    dcTotal+=Convert .ToDecimal(dtGetDetails.Rows[i][j].ToString());
                }
                dtGetDetails.Rows[dtGetDetails.Rows.Count - 1][j] = dcTotal.ToString("0.00");
            }             

                return dtGetDetails;
           
        }

        private Decimal GetExgratia(String strEmpID, Int32 intMnth, Int32 intExgId)
        {
            Decimal dcAmount = 0.00m;
            dcAmount = 0;
            DataTable dtExgConfig = clsDataAccess.RunQDTbl("select eeg.ExgAmount,ece.Month,eeg.EmpId,ece.ExGratia_Id from tbl_Employee_ExgratiaGiven eeg,tbl_Employee_Config_Exgratia ece where ece.ExGratia_Id=eeg.ExgratiaId and eeg.EmpId='" + strEmpID + "' and eeg.ExgratiaId='" + intExgId + "'");
            if (dtExgConfig.Rows.Count > 0)
            {
                String[] intArrMnth = Convert.ToString(dtExgConfig.Rows[0]["Month"]).Split('|');
                for (int j = 0; j < intArrMnth.Length; j++)
                {
                    if (Convert.ToInt32(intArrMnth[j]) == intMnth)
                    {
                        dcAmount = Convert.ToDecimal(dtExgConfig.Rows[0]["ExgAmount"].ToString());
                    }
                }
            }
            return dcAmount;
        }
        private string Space(Int32 number)
        {
            string Blank_Space = " ";
            for (int i = 0; i < number; i++)
            {
                Blank_Space = Blank_Space + " ";
            }
            return Blank_Space;
        }


        private void GetPrint()
        {

            DataTable dt = GetDetails();

            DataTable dtExgratia = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_Exgratia where Session='" + cmbYear.Text.Trim() + "' and ExGratia_Id=" + cmbExgratiaName.ReturnValue + "");
            if (dtExgratia.Rows.Count > 0)
            {
                SimpleTextReport ExgratiaBill = new SimpleTextReport();

                ExgratiaBill.MainPageHeaders.Add();
                ExgratiaBill.MainPageHeaders[0].Text = "Page No:-" + Space(17) + "VANI BHARATI";
                ExgratiaBill.MainPageHeaders[0].Bold = true;
                ExgratiaBill.MainPageHeaders[0].Expanded = true;
                ExgratiaBill.MainPageHeaders[0].Alignment = SimpleTextReport.PutTextAlign.Left;
                ExgratiaBill.MainPageHeaders.Add();
                ExgratiaBill.MainPageHeaders[1].Text = "Bill of Exgratia('" + cmbExgratiaName.Text.Trim() + "') for '" + cmbYear.Text + "' @ '" + dtExgratia.Rows[0]["Amount"].ToString() + "'";
                ExgratiaBill.MainPageHeaders[1].Bold = true;
                ExgratiaBill.MainPageHeaders[1].Alignment = SimpleTextReport.PutTextAlign.Center;

                ExgratiaBill.ActiveDataTable = true;
                ExgratiaBill.DataTable = dt;

                int intColNo = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    ExgratiaBill.ReportColumns.Add();
                    ExgratiaBill.ReportColumns[intColNo].Header.Text.Add(dc.ColumnName);
                    ExgratiaBill.ReportColumns[intColNo].LinesToAColumn = 10;
                    ExgratiaBill.ReportColumns[intColNo].TDataTable = dt;
                    ExgratiaBill.ReportColumns[intColNo].DataField = dc.ColumnName.ToString();
                    ExgratiaBill.ReportColumns[intColNo].Borderget = true;
                    intColNo += 1;
                }

                ExgratiaBill.CustomisedSection.Add();
                ExgratiaBill.CustomisedSection[0].Position = SimpleTextReport.Position.AtEndofPage;
                ExgratiaBill.CustomisedSection[0].Lines.Add();
                ExgratiaBill.CustomisedSection[0].Lines[0].Cells.Add();
                ExgratiaBill.CustomisedSection[0].Lines[0].Cells[0].Text = "Prepared By:............";

                ExgratiaBill.Print();
            }





        }

        private void Bill_of_Exgratia_Load(object sender, EventArgs e)
        {
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");
            if (dtDeduction.Rows.Count > 0)
            {
                for(int i=0;i<dtDeduction.Rows.Count;i++ )
                {
                    lstDeducHead.Items.Add(dtDeduction.Rows[i]["SalaryHead_Short"].ToString());
                }
            }

        }

        private void cmbYear_DropDown(object sender, EventArgs e)
        {
            clsEmployee.PopulateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);

        }

        private void cmbExgratiaName_DropDown(object sender, EventArgs e)
        {
            GetAllExgratia();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Convert.ToString(lstDeducHead.SelectedItem)))
            {
                lstSelectedHead.Items.Add(lstDeducHead.SelectedItem);
                lstDeducHead.Items.Remove(lstDeducHead.SelectedItem);
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Please Select An Item To Move");
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Convert.ToString(lstSelectedHead.SelectedItem)))
            {
                lstDeducHead.Items.Add(lstSelectedHead.SelectedItem);
                lstSelectedHead.Items.Remove(lstSelectedHead.SelectedItem);
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Please Select An Item To Move");
            }
        }

        private void btnMoveAll_Click(object sender, EventArgs e)
        {
            if (lstDeducHead.Items.Count > 0)
            {
                if (lstSelectedHead.Items.Count <= 0)
                {
                    lstSelectedHead.Items.Clear();
                }
                for (Int32 i = 0; i < lstDeducHead.Items.Count; i++)
                {
                    lstSelectedHead.Items.Add(lstDeducHead.Items[i]);
                    //lstPrevorder.Items.Remove(lstPrevorder.Items[i]);
                }
                lstDeducHead.Items.Clear();
            }
        }

        private void btnPrevAll_Click(object sender, EventArgs e)
        {
            if (lstSelectedHead.Items.Count > 0)
            {
                if (lstDeducHead.Items.Count <= 0)
                {
                    lstDeducHead.Items.Clear();
                }

                for (Int32 i = 0; i < lstSelectedHead.Items.Count; i++)
                {
                    lstDeducHead.Items.Add(lstSelectedHead.Items[i]);
                }

                lstSelectedHead.Items.Clear();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Select Year."))
            {
                if (clsValidation.ValidateEdpCombo(cmbExgratiaName, "", "Please Select Year."))
                {
               
                    GetPrint();
                }
            }
        }
    }
}