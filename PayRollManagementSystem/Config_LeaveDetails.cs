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
    public partial class Config_LeaveDetails : EDPComponent.FormBaseERP
    {
        int Loc_id = 0;
        public Config_LeaveDetails()
        {
            InitializeComponent();
        }

        #region Function

        private Boolean ValidateGrid(Int32 intGridRowIndex)
        {
            Boolean boolStatus = false;
            if (!String.IsNullOrEmpty(Convert.ToString(dgLeave.Rows[intGridRowIndex].Cells["LeaveHead"].Value)))
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dgLeave.Rows[intGridRowIndex].Cells["ShortName"].Value)))
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(dgLeave.Rows[intGridRowIndex].Cells["TotalLeaves"].Value)))
                    {
                        if (!String.IsNullOrEmpty(Convert.ToString(cmblocation.Text)))
                        {
                            try
                            {
                                Int32 intTotalLeave = Convert.ToInt32(dgLeave.Rows[intGridRowIndex].Cells["TotalLeaves"].Value);
                                boolStatus = true;
                                //if (!String.IsNullOrEmpty(Convert.ToString(dgLeave.Rows[intGridRowIndex].Cells["Amount"].Value)))
                                //{
                                //    try
                                //    {
                                //        Decimal decAmount = Convert.ToDecimal(dgLeave.Rows[intGridRowIndex].Cells["Amount"].Value);
                                //        boolStatus = true;
                                //    }
                                //    catch (Exception ex)
                                //    {
                                //        ERPMessageBox.ERPMessage.Show("Please Enter Valid Amount in Line " + (intGridRowIndex + 1) + "");                                    
                                //    }
                                //}
                                //else
                                //{
                                //    ERPMessageBox.ERPMessage.Show("Please Enter Amount in Line " + (intGridRowIndex + 1) + "");
                                //}
                            }
                            catch (Exception ex)
                            {
                                ERPMessageBox.ERPMessage.Show("Please Enter Valid No Of Leave in Line " + (intGridRowIndex + 1) + "");
                            }
                        }
                        else
                        {
                            ERPMessageBox.ERPMessage.Show("Please Select Loction Name");
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter No of Leave in Line " + (intGridRowIndex + 1) + "");
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Please Enter Short Name in Line " + (intGridRowIndex + 1) + "");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Please Enter Leave Head in Line " + (intGridRowIndex + 1) + "");
            }
            return boolStatus;
        }

        private void GetDetails()
        {
            //DataTable dt = clsDataAccess.RunQDTbl("select LeaveId,LeaveHead,ShortName,TotalLeaves,DayCount as [Countable Days],PayType,LeaveFwd from tbl_Employee_Config_LeaveDetails where Session='" + cmbYear.Text.Trim() + "'");
            DataTable dt = clsDataAccess.RunQDTbl("select lv.LeaveHead,lv.ShortName,lv.TotalLeaves,lv.DayCount,lv.PayType,lv.LeaveFwd,lv.LeaveId from tbl_Employee_Config_LeaveDetails lv , tbl_Emp_Location el where lv.Location_ID = el.Location_ID and (el.Location_ID = '" + Loc_id + "')");// and Session='" + cmbYear.Text.Trim() + "'");
            dgLeave.DataSource = dt;
        }

        private void SubmitDetails()
        {
            Boolean boolStatus = false;
            System.Collections.ArrayList arrListIDs = new System.Collections.ArrayList();
            arrListIDs.Clear();
            for (int i = 0; i < dgLeave.Rows.Count - 2; i++)
            {
                //int empID = int.Parse(DgJobType.Rows[0].Cells["JobType"].Value.ToString());

                string empID = dgLeave.Rows[i].Cells["LeaveHead"].Value.ToString().Trim();
                arrListIDs.Add(empID.ToUpper());

                /*if (empID.ToUpper() == "ABSENT" || empID.ToUpper() == "AB" || empID.ToUpper() == "ABCENT")
                {
                    if (!arrListIDs.Contains(empID))
                    {
                        arrListIDs.Add(empID);
                        //do ur code
                    }
                    else
                    {
                        MessageBox.Show("Duplicate row for " + empID + " No Record To Save");
                        boolStatus = false;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Duplicate row for " + empID + " No Record To Save");
                    boolStatus = false;
                    return;
                }*/
            }
            int dgleavelstrow = dgLeave.Rows.Count - 1;
            String newlyEnteredLeaveID = dgLeave.Rows[dgleavelstrow - 1].Cells["LeaveHead"].Value.ToString().Trim();
            //textBox1.Text = dgLeave.Rows[dgleavelstrow - 1].Cells["LeaveHead"].Value.ToString().Trim(); 
            if (arrListIDs.Contains(newlyEnteredLeaveID.ToUpper()))
            {
                MessageBox.Show("Duplicate row for " + newlyEnteredLeaveID + " No Record To Save");
                boolStatus = false;
                return;
            }

            Int32 intCount = 0;
            if (dgLeave.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgLeave.Rows.Count - 1; i++)
                {
                    if (ValidateGrid(i))
                    {
                        int company_Id = clsEmployee.GetCompany_ID(Loc_id);
                        if (Information.IsNumeric(dgLeave.Rows[i].Cells["DayCount"].Value) == false)
                            dgLeave.Rows[i].Cells["DayCount"].Value = 0;

                        if (!String.IsNullOrEmpty(Convert.ToString(dgLeave.Rows[i].Cells["SlNo"].Value)))
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Config_LeaveDetails set LeaveHead='" + Convert.ToString(dgLeave.Rows[i].Cells["LeaveHead"].Value).ToUpper() + "',ShortName='" + Convert.ToString(dgLeave.Rows[i].Cells["ShortName"].Value).ToUpper() + "',TotalLeaves=" + dgLeave.Rows[i].Cells["TotalLeaves"].Value + ",DayCount=" + dgLeave.Rows[i].Cells["DayCount"].Value + ",PayType='" + dgLeave.Rows[i].Cells["PayType"].Value + "',LeaveFwd='" + dgLeave.Rows[i].Cells["LeaveFwd"].Value + "',Location_ID = '" + Loc_id + "',company_Id = '" + company_Id + "' where LeaveId=" + dgLeave.Rows[i].Cells["SlNo"].Value + "");
                        }
                        else
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Config_LeaveDetails(LeaveHead,ShortName,TotalLeaves,DayCount,Session,PayType,LeaveFwd,Location_ID,company_Id) values('" + Convert.ToString(dgLeave.Rows[i].Cells["LeaveHead"].Value).ToUpper() + "','" + Convert.ToString(dgLeave.Rows[i].Cells["ShortName"].Value).ToUpper() + "'," + dgLeave.Rows[i].Cells["TotalLeaves"].Value + "," + dgLeave.Rows[i].Cells["DayCount"].Value + ",'" + cmbYear.Text.Trim() + "','" + dgLeave.Rows[i].Cells["PayType"].Value + "','" + dgLeave.Rows[i].Cells["LeaveFwd"].Value + "','" + Loc_id + "','" + company_Id + "')");
                        }
                        if (boolStatus)
                        {
                            intCount += 1;
                        }
                    }
                }
                if (intCount == dgLeave.Rows.Count - 1)
                {
                    ERPMessageBox.ERPMessage.Show("Leave Details Submitted Successfully.");
                    GetDetails();
                }
                else
                {
                    //  ERPMessageBox.ERPMessage.Show("Failed to Submit Leave Details.");
                }
            }
        }
        private void DeleteDetails()
        {
            if (dgLeave.Rows.Count > 1)
            {
                String strSlNo = Convert.ToString(dgLeave.CurrentRow.Cells["SlNo"].Value);

                if (!String.IsNullOrEmpty(strSlNo))
                {
                    ERPMessageBox.ERPMessage.Show("You Are Requesting to Delete Leave Details of Line " + (dgLeave.CurrentRow.Index + 1) + "." + Environment.NewLine + "Do You Want to Continue ?", "", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO);
                    if (ERPMessageBox.ERPMessage.ButtonResult.ToLower() == "edpyes")
                    {
                        Boolean boolStatus = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Config_LeaveDetails where LeaveId=" + strSlNo + " and Location_ID='" + Loc_id + "' ");
                        if (boolStatus)
                        {
                            ERPMessageBox.ERPMessage.Show("Leave Details Deleted Sucessfully");
                            GetDetails();
                        }
                        else
                        {
                            ERPMessageBox.ERPMessage.Show("Failed to Delete Leave Details");
                        }
                    }
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Leave Details Does Not Exists");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Delete.");
            }
        }

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Config_LeaveDetails_Load(object sender, EventArgs e)
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
            //
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SubmitDetails();
            GetDetails();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteDetails();
        }

        private void dgLeave_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message.ToLower() == "input string was not in a correct format.")
            {
                ERPMessageBox.ERPMessage.Show("Please Enter Valid " + dgLeave.Columns[e.ColumnIndex].HeaderText + " in Line " + (e.RowIndex + 1) + "");
            }
        }

        private void cmblocation_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL");
            if (dt.Rows.Count > 0)
            {
                cmblocation.LookUpTable = dt;
                cmblocation.ReturnIndex = 1;
            }
        }

        private void cmblocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmblocation.ReturnValue) == true)
                Loc_id = Convert.ToInt32(cmblocation.ReturnValue);
            GetDetails();
        }

    }
}