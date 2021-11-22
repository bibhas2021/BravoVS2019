using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class statemaster :Form// EDPComponent.FormBaseERP
    {
        public statemaster()
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
                ERPMessageBox.ERPMessage.Show("State Saved Successfully");
                GetDetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit State");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteDetails())
            {
                GetDetails();
                ERPMessageBox.ERPMessage.Show("State Deleted Successfully");
            }
            else
            {
                //  ERPMessageBox.ERPMessage.Show("Failed To Delete Salary Category");
            }
        }

        #region Function

        private Boolean SubmitDetails()
        {
            Boolean boolStatus = false;
            System.Collections.ArrayList arrListIDs = new System.Collections.ArrayList();
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
                    MessageBox.Show("Duplicate row! No Record To Save");
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
                            boolStatus = clsDataAccess.RunNQwithStatus("update StateMaster set STATE_Name='" + strCategory + "' where STATE_CODE=" + strSlNo + "");
                        }
                        else
                        {
                            int Max_ID = 0;
                            DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(STATE_CODE) FROM STATEMaster");
                            if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                            {
                                Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                            }
                            else
                            {
                                Max_ID = 1;
                            }

                            DataTable dt33 = clsDataAccess.RunQDTbl("Select STATE_Name,STATE_CODE from StateMaster where STATE_Name='" + strCategory + "'");
                            if (dt33.Rows.Count == 0)
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into StateMaster(STATE_Name,STATE_CODE) values('" + strCategory + "','" + Max_ID + "')");
                            }
                            else
                            {
                                ERPMessageBox.ERPMessage.Show("State " + strCategory + " Already Exists");
                                boolStatus = false;
                            }

                            //boolStatus = clsDataAccess.RunNQwithStatus("insert into StateMaster(STATE_Name,STATE_CODE) values('" + strCategory + "','"+Max_ID+"')");
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter State for " + i + "th Row.");
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
            DataTable dt = clsDataAccess.RunQDTbl("Select STATE_CODE,STATE_Name from StateMaster");
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
                    boolStatus = clsDataAccess.RunNQwithStatus("Delete from StateMaster where STATE_CODE=" + strSlno + "");
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Section Does Not Exists. Cannot Delete Selected State.");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Delete");
            }
            return boolStatus;
        }

        #endregion

        private void statemaster_Load(object sender, EventArgs e)
        {
            GetDetails();
        }
    }
}
