using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class Countrymaster : EDPComponent.FormBaseERP
    {
        public Countrymaster()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteDetails())
            {
                GetDetails();
                ERPMessageBox.ERPMessage.Show("Country Deleted Successfully");
            }
            else
            {
                //  ERPMessageBox.ERPMessage.Show("Failed To Delete Salary Category");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                ERPMessageBox.ERPMessage.Show("Country Saved Successfully");
                GetDetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Country");
            }
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
                            boolStatus = clsDataAccess.RunNQwithStatus("update Country set Country_Name='" + strCategory + "' where Country_CODE=" + strSlNo + "");
                        }
                        else
                        {
                            int Max_ID = 0;
                            DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(Country_CODE) FROM Country");
                            if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                            {
                                Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                            }
                            else
                            {
                                Max_ID = 1;
                            }

                            DataTable dt33 = clsDataAccess.RunQDTbl("Select Country_Name,Country_CODE from Country where Country_Name='" + strCategory + "'");
                            if (dt33.Rows.Count == 0)
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into Country(Country_Name,Country_CODE) values('" + strCategory + "','" + Max_ID + "')");
                            }
                            else
                            {
                                ERPMessageBox.ERPMessage.Show("Country " + strCategory + " Already Exists");
                                boolStatus = false;
                            }


                            //boolStatus = clsDataAccess.RunNQwithStatus("insert into Country(Country_Name,Country_CODE) values('" + strCategory + "','" + Max_ID + "')");
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Country for " + i + "th Row.");
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
            DataTable dt = clsDataAccess.RunQDTbl("Select Country_CODE,Country_Name from Country order by Country_Name");
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
                    boolStatus = clsDataAccess.RunNQwithStatus("Delete from Country where Country_CODE=" + strSlno + "");
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Section Does Not Exists. Cannot Delete Selected Country.");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Delete");
            }
            return boolStatus;
        }

        #endregion

        private void Countrymaster_Load(object sender, EventArgs e)
        {
            GetDetails();
        }

    }
}
