using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class MonthOfDays : EDPComponent.FormBaseERP
    {
        public MonthOfDays()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                ERPMessageBox.ERPMessage.Show("Month Of Days Saved Successfully");
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Month Of Days");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteDetails())
            {
                GetDetails();
                ERPMessageBox.ERPMessage.Show("Month Of Days Deleted Successfully");
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Delete Salary Category");
            }
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
                            boolStatus = clsDataAccess.RunNQwithStatus("update MonthOfDays set MONTH_Name='" + strCategory + "' where MONTH_CODE=" + strSlNo + "");
                        }
                        else
                        {
                            int Max_ID = 0;
                            DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(MONTH_CODE) FROM MonthOfDays");
                            if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                            {
                                Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                            }
                            else
                            {
                                Max_ID = 1;
                            }


                            boolStatus = clsDataAccess.RunNQwithStatus("insert into MonthOfDays(MONTH_Name,MONTH_CODE) values('" + strCategory + "','"+Max_ID+"')");
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Month for " + i + "th Row.");
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
            DataTable dt = clsDataAccess.RunQDTbl("Select MONTH_CODE,MONTH_Name from MonthOfDays");
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
                    boolStatus = clsDataAccess.RunNQwithStatus("Delete from MonthOfDays where MONTH_CODE=" + strSlno + "");
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Section Does Not Exists. Cannot Delete Selected Month Of Days.");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Delete");
            }
            return boolStatus;
        }

        #endregion

        private void Hrmaster_Load(object sender, EventArgs e)
        {
            GetDetails();
            
           // lblHead.Text = "Month of Days";
        }






    }
}
