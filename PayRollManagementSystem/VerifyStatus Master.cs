using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class VerifyStatus_Master : Form
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        public VerifyStatus_Master()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                ERPMessageBox.ERPMessage.Show(" Verification Status details Saved Successfully");
                GetDetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Verification Status details");
            }
       
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteDetails())
            {
                GetDetails();
                ERPMessageBox.ERPMessage.Show("Verification Status details Deleted Successfully");
            }
            else
            {

            }
       
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Boolean SubmitDetails()
        {
            Boolean boolstatus = false;

            System.Collections.ArrayList arrListIDs = new System.Collections.ArrayList();
            arrListIDs.Clear();
            for (int i = 0; i < dgv_vs.Rows.Count - 1; i++)
            {

                string empID = dgv_vs.Rows[i].Cells["verifystatus"].Value.ToString().Trim();
                if (!arrListIDs.Contains(empID))
                {
                    arrListIDs.Add(empID);

                }
                else
                {
                    MessageBox.Show("Duplicate row! No Record To Save");
                    boolstatus = false;
                    return boolstatus;
                }
            }
            if (dgv_vs.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgv_vs.Rows.Count - 1; i++)
                {
                    String strSlNo = Convert.ToString(dgv_vs.Rows[i].Cells["vid"].Value);
                    String strCategory = Convert.ToString(dgv_vs.Rows[i].Cells["verifystatus"].Value);

                            if (!String.IsNullOrEmpty(strCategory))
                            {
                                if (!String.IsNullOrEmpty(strSlNo))
                                {
                                    DataTable dt = clsDataAccess.RunQDTbl("Select verify_status from tbl_Emp_verifystatus Where verify_status='" + strSlNo + "'");
                                    if (dt.Rows.Count > 0)
                                    {
                                        boolstatus = clsDataAccess.RunNQwithStatus("update verify_status_master set verifystatus='" + strCategory + "' where vid=" + strSlNo + "");
                                    }
                                }
                                else
                                {
                                    int Max_ID = 0;
                                    DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(vid) FROM verify_status_master");
                                    if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                                    {
                                        Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                                    }
                                    else
                                    {
                                        Max_ID = 1;
                                    }

                                    boolstatus = clsDataAccess.RunNQwithStatus("insert into verify_status_master(verifystatus,vid) values('" + strCategory + "','" + Max_ID + "')");

                                }

                                edpcom.InsertMidasLog(this, true, "add", "verification status :" + strSlNo);
                            }
                            else
                            {
                                ERPMessageBox.ERPMessage.Show("Please Enter verification status for " + i + "th Row.");
                            }

                     }
                       
                    
            
              }
                 else
                 {
                    ERPMessageBox.ERPMessage.Show("No Record To Save");
                 }
            return boolstatus;
            }
                 
        private void GetDetails()
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select vid,verifystatus from verify_status_master");
            if (dt.Rows.Count > 0)
            {
                dgv_vs.DataSource = dt;
            }
        }

        private Boolean DeleteDetails()
        {
            Boolean boolStatus = false;
            if (dgv_vs.Rows.Count > 1)
            {
                String strSlno = Convert.ToString(dgv_vs.CurrentRow.Cells["vid"].Value);
                String strCatg = Convert.ToString(dgv_vs.CurrentRow.Cells["verifystatus"].Value);

                if (!String.IsNullOrEmpty(strSlno))
                {
                    DataTable dt = clsDataAccess.RunQDTbl("Select  verify_status from tbl_Emp_verifystatus Where verify_status='" + strSlno + "'");
                    if (dt.Rows.Count > 0)
                    {
                        ERPMessageBox.ERPMessage.Show("Verification Status Name Used So Delete Not Possible");
                    }
                    else
                        boolStatus = clsDataAccess.RunNQwithStatus("Delete from verify_status_master where vid=" + strSlno + "");
                    edpcom.InsertMidasLog(this, true, "del", "verificationstatus :" + strSlno);
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Section Does Not Exists. Cannot Delete Selected Verification Status name.");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Delete");
            }
            return boolStatus;
        }

        private void VerifyStatus_Master_Load(object sender, EventArgs e)
        {
            GetDetails();
 
        }


   }
                    
}
           
   
