using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Edpcom;

namespace PayRollManagementSystem
{
    public partial class frmEmpAttend_daily : Form
    {
        public frmEmpAttend_daily()
        {
            InitializeComponent();
        }

        int Location_ID = 0;
        int calc_tot_days = 0;
        EDPConnection edpcon = new EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();


        private void cmblocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmblocation.ReturnValue) == true)
            {
                Location_ID = Convert.ToInt32(cmblocation.ReturnValue);
                lblClientID.Text = Location_ID.ToString();

                lblCoid.Text= clsEmployee.GetCompany_ID(Location_ID).ToString();

                txtClient.Text = clsDataAccess.GetresultS("SELECT Client_Name FROM tbl_Employee_CliantMaster where client_id=(select distinct Cliant_ID from tbl_Emp_Location where Location_ID='" + Location_ID + "')");


            }



        }

        private void cmblocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            if (edpcom.CurrentLocation.Trim() != "")
            {
                DataTable dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID in (" + edpcom.CurrentLocation + ") ");
                if (dt.Rows.Count > 0)
                {
                    cmblocation.LookUpTable = dt;
                    cmblocation.ReturnIndex = 1;
                }
                else
                {
                    EDPMessageBox.EDPMessage.Show("No location found.", "BRAVO");
                }
            }
            else
            {
                DataTable dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL");
                if (dt.Rows.Count > 0)
                {
                    cmblocation.LookUpTable = dt;
                    cmblocation.ReturnIndex = 1;
                }
                else
                {
                    EDPMessageBox.EDPMessage.Show("No location found.", "BRAVO");
                }
            }
        }

       
    }
}
