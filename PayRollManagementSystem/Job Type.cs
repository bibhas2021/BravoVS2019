using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class Employee_Type : EDPComponent.FormBaseERP
    {
        public Employee_Type()
        {
            InitializeComponent();
        }
        #region Functions

        private void GetDetails()
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select SlNo,JobType,ShortForm from tbl_Employee_JobType");
            if (dt.Rows.Count > 0)
            {
                DgJobType.DataSource = dt;
            }
        }

        private bool SubmitDetails()
        {
            Boolean boolStatus = false;
            System.Collections.ArrayList arrListIDs = new System.Collections.ArrayList();
            for (int i = 0; i < DgJobType.Rows.Count-1; i++)
            {
                //int empID = int.Parse(DgJobType.Rows[0].Cells["JobType"].Value.ToString());
                string empID = DgJobType.Rows[i].Cells["JobType"].Value.ToString().Trim();
                if (!arrListIDs.Contains(empID))
                {
                    arrListIDs.Add(empID);
                    //do ur code
                }
                else
                {
                    MessageBox.Show("Duplicate row! No Record To Save");
                    boolStatus = false;
                    return boolStatus;
                }
            }

          
            if (DgJobType.Rows.Count > 1)
            {
                for (Int32 i = 0; i < DgJobType.Rows.Count - 1; i++)
                {
                    String strSlNo = Convert.ToString(DgJobType.Rows[i].Cells["SlNo"].Value);
                    String strJobType = Convert.ToString(DgJobType.Rows[i].Cells["JobType"].Value);
                    String ShortForm = Convert.ToString(DgJobType.Rows[i].Cells["ShortForm"].Value);

                    if (!String.IsNullOrEmpty(strJobType))
                    {
                           if (!String.IsNullOrEmpty(ShortForm))
                            {
                                if (!String.IsNullOrEmpty(strSlNo))
                                {
                         
                                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_JobType set JobType='" + strJobType + "',ShortForm='" + ShortForm + "' where SlNo=" + strSlNo + "");
                                }

                            else
                            {
                                DataTable dt33 = clsDataAccess.RunQDTbl("Select JobType from tbl_Employee_JobType where JobType='" + strJobType + "'");
                                if (dt33.Rows.Count == 0)
                                {
                                    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_JobType(JobType,ShortForm) values('" + strJobType + "','" + ShortForm + "')");
                                }
                                else
                                {
                                    ERPMessageBox.ERPMessage.Show("JobType " + strJobType + " Already Exists");
                                    boolStatus = false;
                                }

                                //boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_JobType(JobType,ShortForm) values('" + strJobType + "','"+ShortForm +"')");
                            }
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Job Type for " + i + "th Row.");
                    }
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Save");
            }
            return boolStatus;
        }

        private Boolean DeleteDetails()
        {
            Boolean boolStatus = false;
            if (DgJobType.Rows.Count > 1)
            {
                String strSlno = Convert.ToString(DgJobType.CurrentRow.Cells["SlNo"].Value);
              
                if (!String.IsNullOrEmpty(strSlno))
                {
                    boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Employee_JobType where SlNo=" + strSlno + "");
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Job Type Does Not Exists. Cannot Delete Selected Job Type.");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Delete");
            }
            return boolStatus;
        }
#endregion

        #region PageEvents 

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                ERPMessageBox.ERPMessage.Show("Job Type Saved Successfully");
                GetDetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Job Type");
            }
        }

        private void Employee_Type_Load(object sender, EventArgs e)
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
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}