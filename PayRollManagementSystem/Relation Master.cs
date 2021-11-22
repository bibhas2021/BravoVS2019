using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class Relation_Master : EDPComponent.FormBaseERP
    {
        public Relation_Master()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                ERPMessageBox.ERPMessage.Show("Relation Name Saved Successfully");
                GetDetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Relation Name");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteDetails())
            {
                GetDetails();
                ERPMessageBox.ERPMessage.Show("Relation Name Deleted Successfully");
            }
            else
            {
                //  ERPMessageBox.ERPMessage.Show("Failed To Delete Salary Category");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                            DataTable dt = clsDataAccess.RunQDTbl("Select Relation from tbl_Employee_FamilyDetails Where Relation='" + strSlNo + "'");
                             if (dt.Rows.Count > 0)
                             {
                                 boolStatus = clsDataAccess.RunNQwithStatus("update Relation_Master set Relation_Name='" + strCategory + "' where Relation_Code=" + strSlNo + "");
                             }
                        }
                        else
                        {
                            int Max_ID = 0;
                            DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(Relation_Code) FROM Relation_Master");
                            if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                            {
                                Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                            }
                            else
                            {
                                Max_ID = 1;
                            }


                            boolStatus = clsDataAccess.RunNQwithStatus("insert into Relation_Master(Relation_Name,Relation_Code) values('" + strCategory + "','" + Max_ID + "')");
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Relation Name for " + i + "th Row.");
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
            if (dgCatg.Rows.Count > 1)
            {
                String strSlno = Convert.ToString(dgCatg.CurrentRow.Cells["Slno"].Value);
                String strCatg = Convert.ToString(dgCatg.CurrentRow.Cells["Catg"].Value);

                if (!String.IsNullOrEmpty(strSlno))
                {
                    DataTable dt = clsDataAccess.RunQDTbl("Select Relation from tbl_Employee_FamilyDetails Where Relation='" + strSlno + "'");
                    if (dt.Rows.Count > 0)
                    {
                        ERPMessageBox.ERPMessage.Show("Relation Name Used So Delete Not Possible");
                    }
                    else
                        boolStatus = clsDataAccess.RunNQwithStatus("Delete from Relation_Master where Relation_Code=" + strSlno + "");
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Section Does Not Exists. Cannot Delete Selected Relation Name.");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Delete");
            }
            return boolStatus;
        }

        private void GetDetails()
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select Relation_Code,Relation_Name from Relation_Master");
            if (dt.Rows.Count > 0)
            {
                dgCatg.DataSource = dt;
            }
        }

        private void Relation_Master_Load(object sender, EventArgs e)
        {
            this.HeaderText = "Relation Master";
            GetDetails();
        }

    }
}
