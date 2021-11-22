using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmSectionMaster : EDPComponent.FormBaseERP
    {
        public frmSectionMaster()
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
                            boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_SectionMaster set section='" + strCategory + "' where SlNo=" + strSlNo + "");
                        }
                        else
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_SectionMaster(section) values('" + strCategory + "')");
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Section for " + i + "th Row.");
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
            DataTable dt = clsDataAccess.RunQDTbl("Select SlNo,section from tbl_Employee_SectionMaster");
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
                    boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Employee_SectionMaster where SlNo=" + strSlno + "");
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Section Does Not Exists. Cannot Delete Selected Section.");
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
                ERPMessageBox.ERPMessage.Show("Section Saved Successfully");
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Section");
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
                ERPMessageBox.ERPMessage.Show("Section Deleted Successfully");
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

                ERPMessageBox.ERPMessage.Show("Section type is not valid");

            }
        }
    }
}