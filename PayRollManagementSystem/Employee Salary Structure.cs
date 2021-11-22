using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PayRollManagementSystem
{
    public partial class Employee_Salary_Structure : Form//EDPComponent.FormBaseERP 
    {
        public Employee_Salary_Structure()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Function

        private Boolean SubmitDetails()
        {
            Boolean boolStatus = false;

            System.Collections.ArrayList arrListIDs = new System.Collections.ArrayList();
            arrListIDs.Clear();
            for (int i = 0; i < dgCatg.Rows.Count - 1; i++)
            {
                //int empID = int.Parse(DgJobType.Rows[0].Cells["JobType"].Value.ToString());
                string empID = dgCatg.Rows[i].Cells["Catg"].Value.ToString().Trim();
                if (!arrListIDs.Contains(empID))
                {
                    arrListIDs.Add(empID);
                    //do ur code
                }
                else
                {
                    MessageBox.Show("Duplicate row for "+empID+" No Record To Save");
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

                    if (!String.IsNullOrEmpty(strCategory))
                    {
                        if (!String.IsNullOrEmpty(strSlNo))
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_SalaryStructure set SalaryCategory='" + strCategory + "' where SlNo=" + strSlNo + "");
                        }
                        else
                        {
                            DataTable dt = clsDataAccess.RunQDTbl("Select SlNo,SalaryCategory from tbl_Employee_SalaryStructure where SalaryCategory='" + strCategory + "'");
                            if (dt.Rows.Count == 0)
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_SalaryStructure(SalaryCategory) values('" + strCategory + "')");
                            else
                                ERPMessageBox.ERPMessage.Show("Salary Structure Name " + strCategory + " Already Exists");
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Salary Category for " + i + "th Row.");
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
            DataTable dt = clsDataAccess.RunQDTbl("Select SlNo,SalaryCategory from tbl_Employee_SalaryStructure");
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
                    DataTable dtAlreadyLinkedOrNot = clsDataAccess.RunQDTbl("select * from tbl_Employee_Link_SalaryStructure where SalaryStructure_ID = " + strSlno);
                    if (dtAlreadyLinkedOrNot.Rows.Count == 0)
                        boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Employee_SalaryStructure where SlNo=" + strSlno + "");
                    else
                        EDPMessageBox.EDPMessage.Show("Cannot be deleted because this salary structure is already linked with a location.");
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Salary Category Does Not Exists. Cannot Delete Selected Category.");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Delete");
            }
            return boolStatus;
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                ERPMessageBox.ERPMessage.Show("Salary Categories Saved Successfully");
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Salary Categories");
            }
        }

        private void Employee_Salary_Structure_Load(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteDetails())
            {
                GetDetails();
                ERPMessageBox.ERPMessage.Show("Salary Category Deleted Successfully");
            }
            else
            {
              //  ERPMessageBox.ERPMessage.Show("Failed To Delete Salary Category");
            }
        }

        private void dgCatg_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
          
            if (e.Exception.Message.ToString() == "Input string was not in a correct format.")
            {
                
                    ERPMessageBox.ERPMessage.Show("Category type is not valid");
               
            }
        }
    }
}