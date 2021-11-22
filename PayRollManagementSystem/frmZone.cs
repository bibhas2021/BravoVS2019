using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmZone : Form
    {
        public frmZone()
        {
            InitializeComponent();
        }

        private Boolean DeleteDetails()
        {
            Boolean boolStatus = false;

            if (dgZone.Rows.Count > 1)
            {
                String strSlno = Convert.ToString(dgZone.CurrentRow.Cells["slno"].Value);

                String strActive = Convert.ToString(dgZone.CurrentRow.Cells["active"].Value);


                    if (!String.IsNullOrEmpty(strSlno) || strActive=="0")
                    {
                        clsDataAccess.RunQry("Delete from tbl_Zone where (zid=" + strSlno + ")"); boolStatus = true;
                        //MessageBox.Show("Zone Deleted");
                    }
                    else
                    {
                        MessageBox.Show("Zone cannot be deleted.");
                    }
                
            }
            else
                MessageBox.Show("No Record To Delete");

            return boolStatus;
        }
        private void GetDetails()
        {
            int ind = 0;
            dgZone.Rows.Clear();
            DataTable dt = clsDataAccess.RunQDTbl("Select zid,zone,(select count(*) from tbl_Emp_Location where zid=tz.zid)as active from tbl_Zone tz");
            if (dt.Rows.Count > 0)
            {
                // DgDesignation.DataSource = dt;
                for (int inx = 0; inx < dt.Rows.Count; inx++)
                {

                    ind = dgZone.Rows.Add();
                    dgZone.Rows[ind].Cells["slno"].Value = dt.Rows[inx]["zid"].ToString();
                    dgZone.Rows[ind].Cells["zone"].Value = dt.Rows[inx]["zone"].ToString();
                    dgZone.Rows[ind].Cells["Active"].Value = dt.Rows[inx]["active"].ToString();
                   if (Convert.ToInt32(dt.Rows[inx]["active"].ToString())>0)
                   {
                       dgZone.Rows[ind].DefaultCellStyle.BackColor = Color.Cyan;

                   }
                    
                }
            }
        }


        private bool SubmitDetails()
        {

            DataTable dt = new DataTable();
            dt = (DataTable)dgZone.DataSource;
            
            Boolean boolStatus = false;
            System.Collections.ArrayList arrListIDs = new System.Collections.ArrayList();
            arrListIDs.Clear();
            for (int i = 0; i < dgZone.Rows.Count - 1; i++)
            {
                
                string vZone = dgZone.Rows[i].Cells["zone"].Value.ToString().Trim();
                if (!arrListIDs.Contains(vZone))
                {
                    arrListIDs.Add(vZone);
                    //do ur code
                }
                else
                {
                    MessageBox.Show("Duplicate row! Zone: " + vZone + ",  Please Change");
                    boolStatus = false;
                    return boolStatus;
                }
            }

           

            if (dgZone.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgZone.Rows.Count - 1; i++)
                {
                    String strSlNo = Convert.ToString(dgZone.Rows[i].Cells["slno"].Value);
                    String strZone = Convert.ToString(dgZone.Rows[i].Cells["zone"].Value);
                    String active = Convert.ToString(dgZone.Rows[i].Cells["Active"].Value);

                    if (!String.IsNullOrEmpty(strZone))
                    {
                        //if (!String.IsNullOrEmpty(active))
                        //{
                            if (!String.IsNullOrEmpty(strSlNo))
                            {

                                clsDataAccess.RunQry("update tbl_Zone set zone='" + strZone + "' where (zid=" + strSlNo + ")");
                                boolStatus = true;
                            }

                            else
                            {

                                DataTable dt33 = clsDataAccess.RunQDTbl("Select zid,zone,active from tbl_Zone where (zone='" + strZone + "')");
                                if (dt33.Rows.Count == 0)
                                {
                                    string slno = clsDataAccess.GetresultS("select isNull(max(zid),0)+1 from tbl_Zone");
                                    clsDataAccess.RunQry("insert into tbl_Zone(zid,zone,active) values('" + slno + "','" + strZone + "','0')");
                                    boolStatus = true;
                                }
                                else
                                {
                                    MessageBox.Show("Zone : " + strZone + " Already Exists");
                                    boolStatus = false;
                                }
                            }
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Zone Blank in " + i + "th Row.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Save");
            }
            return boolStatus;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                MessageBox.Show("Zone Saved Successfully");
                GetDetails();
            }
            else
            {
                MessageBox.Show("Failed To Submit");
            }
        }

        private void frmZone_Load(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteDetails())
            {
                GetDetails();
                MessageBox.Show("Zone Deleted Successfully");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
