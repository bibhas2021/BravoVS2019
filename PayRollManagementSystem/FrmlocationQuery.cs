using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class FrmlocationQuery : EDPComponent.FormBaseERP
    {

        int Cliant_ID = 0, Location_ID = 0, Employ_ID = 0, state_id=0;
        public FrmlocationQuery()
        {
            InitializeComponent();
        }

        private void cmbcliantname_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select Client_Name, Client_id from tbl_Employee_CliantMaster ");
            if (dt.Rows.Count > 0)
            {
                cmbcliantname.LookUpTable = dt;
                cmbcliantname.ReturnIndex = 1;
            }          
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID from tbl_Emp_Location ");
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }          
        }

        private void CmbEmploy_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select Title +' '+ FirstName +' '+ MiddleName +' '+ LastName,ID from tbl_Employee_Mast");
            if (dt.Rows.Count > 0)
            {
                CmbEmploy.LookUpTable = dt;
                CmbEmploy.ReturnIndex = 1;
            }           
        }

        private void cmbcliantname_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcliantname.ReturnValue) == true)
                Cliant_ID = Convert.ToInt32(cmbcliantname.ReturnValue);
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                Location_ID = Convert.ToInt32(cmbLocation.ReturnValue);
        }

        private void CmbEmploy_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbEmploy.ReturnValue) == true)
                Employ_ID = Convert.ToInt32(CmbEmploy.ReturnValue);
        }

        private void FrmlocationQuery_Load(object sender, EventArgs e)
        {
            this.HeaderText = "Client Details Querey";
            CmbLang.Items.Add("BENGALI");
            CmbLang.Items.Add("ENGLISH");
            CmbLang.Items.Add("HINDI");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Data_retrive();
        }

        private void Data_retrive()
        {
            DataTable dt = new DataTable();
            if (Employ_ID != 0)
            {
                dt = clsDataAccess.RunQDTbl(" select e.FirstName, +' '+ MiddleName +' '+ LastName as Employ_Name,c.Client_Name,l.Location_Name,s.state_name,e.presentcity from  tbl_Employee_CliantMaster c,tbl_Emp_Location l,tbl_Employee_Mast e, statemaster s where l.location_id=e.location_id  and s.state_name like'" + TxtState.Text + "%'");

            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select  e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name, c.Client_Name,l.Location_Name,s.state_name,e.presentcity from  tbl_Employee_CliantMaster c,tbl_Emp_Location l,tbl_Employee_Mast e,statemaster s where c.client_id=" + Cliant_ID + "and l.Location_ID=e.location_id and e.location_id=" + Location_ID + "and s.state_code=e.presentstate and s.state_name like'" + TxtState.Text + "%'");
            }
            dgv.DataSource = dt;


            dgv.Columns[0].HeaderText = "Employ Name";
            dgv.Columns[1].HeaderText = "Client Name";
            dgv.Columns[2].HeaderText = "Location Name";
            dgv.Columns[3].HeaderText = "State Name";
            dgv.Columns[4].HeaderText = "City Name";
            dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
           dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[4].HeaderCell.Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
           dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dgv.Columns[0].Width = 135;
            dgv.Columns[1].Width = 135;
            dgv.Columns[2].Width = 135;
            dgv.Columns[3].Width = 135;
            dgv.Columns[4].Width = 135;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxtState_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void BtnCity_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Employ_ID != 0)
            {
                dt = clsDataAccess.RunQDTbl(" select e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name,c.Client_Name,l.Location_Name,s.state_name,e.presentcity from  tbl_Employee_CliantMaster c,tbl_Emp_Location l,tbl_Employee_Mast e, statemaster s where l.location_id=e.location_id and s.state_code=e.presentstate and state_name like'" + TxtCity.Text + "%'");

            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select  e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name, c.Client_Name,l.Location_Name,s.state_name,e.presentcity from tbl_Employee_Mast e, tbl_Employee_CliantMaster c,tbl_Emp_Location l,statemaster s where c.client_id=" + Cliant_ID + "and l.Location_ID=e.location_id and l.location_id=" + Location_ID + "and s.state_code=e.presentstate and  e.presentcity like'" + TxtCity.Text + "%'");
            }
            dgv.DataSource = dt;


            dgv.Columns[0].HeaderText = "Employ Name";
            dgv.Columns[1].HeaderText = "Client Name";
            dgv.Columns[2].HeaderText = "Location Name";
            dgv.Columns[3].HeaderText = "State Name";
            dgv.Columns[4].HeaderText = "City Name";

            dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dgv.Columns[0].Width = 275;
            dgv.Columns[1].Width = 135;
            dgv.Columns[2].Width = 135;
            dgv.Columns[3].Width = 135;
            dgv.Columns[4].Width = 135;

        }
        
       

        private void BtnRead_Click(object sender, EventArgs e)
        {
         /*   int i;
            DataTable REA = clsDataAccess.RunQDTbl("Select Language_bengali,Language_english,Language_hindi from tbl_employee_mast");
            string[] Bengali = new string[REA.Rows.Count];
            string[] English = new string[REA.Rows.Count];
            string[] Hindi = new string[REA.Rows.Count];
            string[] Beng = new string[REA.Rows.Count];
            string[] Eng = new string[REA.Rows.Count];
            string[] Hin = new string[REA.Rows.Count];
            string[] BNGA = new string[REA.Rows.Count];
            string[] ENGB = new string[REA.Rows.Count];
            string[] HND = new string[REA.Rows.Count];
            string[] LANG = new string[REA.Rows.Count];
      for (i = 0; i < REA.Rows.Count; i++)
            {
   
                Bengali[i] = REA.Rows[i]["Language_bengali"].ToString();
                English[i] = REA.Rows[i]["Language_English"].ToString();
                Hindi[i] = REA.Rows[i]["Language_hindi"].ToString();
                Beng[i]=Bengali[i].Substring(1,1);
                Eng[i] = English[i].Substring(1, 1);
                Hin[i] = Hindi[i].Substring(1, 1);*/

            DataTable dt = new DataTable();
            if (Employ_ID != 0)
            {
                dt = clsDataAccess.RunQDTbl(" select e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name,c.Client_Name,l.Location_Name,s.state_name,e.presentcity from  tbl_Employee_CliantMaster c,tbl_Emp_Location l,tbl_Employee_Mast e, statemaster s where l.location_id=e.location_id and s.state_code=e.presentstate and state_name like'" + TxtCity.Text + "%'");

            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select  e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name, c.Client_Name,l.Location_Name,s.state_name,e.presentcity from tbl_Employee_Mast e, tbl_Employee_CliantMaster c,tbl_Emp_Location l,statemaster s where c.client_id=" + Cliant_ID + "and l.Location_ID=e.location_id and l.location_id=" + Location_ID + "and s.state_code=e.presentstate and substring(e.language_bengali,1,1)='1' and substring(e.language_English,1,1)='1' and substring(e.language_hindi,1,1)='1'");
            }
            dgv.DataSource = dt;


            dgv.Columns[0].HeaderText = "Employ Name";
            dgv.Columns[1].HeaderText = "Client Name";
            dgv.Columns[2].HeaderText = "Location Name";
            dgv.Columns[3].HeaderText = "State Name";
            dgv.Columns[4].HeaderText = "City Name";

            dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dgv.Columns[0].Width = 275;
            dgv.Columns[1].Width = 135;
            dgv.Columns[2].Width = 135;
            dgv.Columns[3].Width = 135;
            dgv.Columns[4].Width = 135;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnAllWrite_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Employ_ID != 0)
            {
                dt = clsDataAccess.RunQDTbl(" select e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name,c.Client_Name,l.Location_Name,s.state_name,e.presentcity from  tbl_Employee_CliantMaster c,tbl_Emp_Location l,tbl_Employee_Mast e, statemaster s where l.location_id=e.location_id and s.state_code=e.presentstate and state_name like'" + TxtCity.Text + "%'");

            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select  e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name, c.Client_Name,l.Location_Name,s.state_name,e.presentcity from tbl_Employee_Mast e, tbl_Employee_CliantMaster c,tbl_Emp_Location l,statemaster s where c.client_id=" + Cliant_ID + "and l.Location_ID=e.location_id and l.location_id=" + Location_ID + "and s.state_code=e.presentstate and substring(e.language_bengali,3,1)='1' and substring(e.language_English,3,1)='1' and substring(e.language_hindi,3,1)='1'");
            }
            dgv.DataSource = dt;


            dgv.Columns[0].HeaderText = "Employ Name";
            dgv.Columns[1].HeaderText = "Client Name";
            dgv.Columns[2].HeaderText = "Location Name";
            dgv.Columns[3].HeaderText = "State Name";
            dgv.Columns[4].HeaderText = "City Name";

            dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dgv.Columns[0].Width = 275;
            dgv.Columns[1].Width = 135;
            dgv.Columns[2].Width = 135;
            dgv.Columns[3].Width = 135;
            dgv.Columns[4].Width = 135;
        }

        private void BtnAllSpeak_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Employ_ID != 0)
            {
                dt = clsDataAccess.RunQDTbl(" select e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name,c.Client_Name,l.Location_Name,s.state_name,e.presentcity from  tbl_Employee_CliantMaster c,tbl_Emp_Location l,tbl_Employee_Mast e, statemaster s where l.location_id=e.location_id and s.state_code=e.presentstate and state_name like'" + TxtCity.Text + "%'");

            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select  e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name, c.Client_Name,l.Location_Name,s.state_name,e.presentcity from tbl_Employee_Mast e, tbl_Employee_CliantMaster c,tbl_Emp_Location l,statemaster s where c.client_id=" + Cliant_ID + "and l.Location_ID=e.location_id and l.location_id=" + Location_ID + "and s.state_code=e.presentstate and substring(e.language_bengali,5,1)='1' and substring(e.language_English,5,1)='1' and substring(e.language_hindi,5,1)='1'");
            }
            dgv.DataSource = dt;


            dgv.Columns[0].HeaderText = "Employ Name";
            dgv.Columns[1].HeaderText = "Client Name";
            dgv.Columns[2].HeaderText = "Location Name";
            dgv.Columns[3].HeaderText = "State Name";
            dgv.Columns[4].HeaderText = "City Name";

            dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dgv.Columns[0].Width = 275;
            dgv.Columns[1].Width = 135;
            dgv.Columns[2].Width = 135;
            dgv.Columns[3].Width = 135;
            dgv.Columns[4].Width = 135;
        }

        private void BtnRead_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Employ_ID != 0)
            {
                dt = clsDataAccess.RunQDTbl(" select e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name,c.Client_Name,l.Location_Name,s.state_name,e.presentcity from  tbl_Employee_CliantMaster c,tbl_Emp_Location l,tbl_Employee_Mast e, statemaster s where l.location_id=e.location_id and s.state_code=e.presentstate and state_name like'" + TxtCity.Text + "%'");

            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select  e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name, c.Client_Name,l.Location_Name,s.state_name,e.presentcity from tbl_Employee_Mast e, tbl_Employee_CliantMaster c,tbl_Emp_Location l,statemaster s where c.client_id=" + Cliant_ID + "and l.Location_ID=e.location_id and l.location_id=" + Location_ID + "and s.state_code=e.presentstate and substring(e.language_" + CmbLang.Text + ",1,1)='1'");
            }
            dgv.DataSource = dt;
            try
            {

                dgv.Columns[0].HeaderText = "Employ Name";
                dgv.Columns[1].HeaderText = "Client Name";
                dgv.Columns[2].HeaderText = "Location Name";
                dgv.Columns[3].HeaderText = "State Name";
                dgv.Columns[4].HeaderText = "City Name";

                dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

                dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


                dgv.Columns[0].Width = 275;
                dgv.Columns[1].Width = 135;
                dgv.Columns[2].Width = 135;
                dgv.Columns[3].Width = 135;
                dgv.Columns[4].Width = 135;
            }
            catch { }
        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Employ_ID != 0)
            {
                dt = clsDataAccess.RunQDTbl(" select e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name,c.Client_Name,l.Location_Name,s.state_name,e.presentcity from  tbl_Employee_CliantMaster c,tbl_Emp_Location l,tbl_Employee_Mast e, statemaster s where l.location_id=e.location_id and s.state_code=e.presentstate and state_name like'" + TxtCity.Text + "%'");

            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select  e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name, c.Client_Name,l.Location_Name,s.state_name,e.presentcity from tbl_Employee_Mast e, tbl_Employee_CliantMaster c,tbl_Emp_Location l,statemaster s where c.client_id=" + Cliant_ID + "and l.Location_ID=e.location_id and l.location_id=" + Location_ID + "and s.state_code=e.presentstate and substring(e.language_" + CmbLang.Text + ",3,1)='1'");
            }
            dgv.DataSource = dt;


            dgv.Columns[0].HeaderText = "Employ Name";
            dgv.Columns[1].HeaderText = "Client Name";
            dgv.Columns[2].HeaderText = "Location Name";
            dgv.Columns[3].HeaderText = "State Name";
            dgv.Columns[4].HeaderText = "City Name";

            dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dgv.Columns[0].Width = 275;
            dgv.Columns[1].Width = 135;
            dgv.Columns[2].Width = 135;
            dgv.Columns[3].Width = 135;
            dgv.Columns[4].Width = 135;
        }

        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Employ_ID != 0)
            {
                dt = clsDataAccess.RunQDTbl(" select e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name,c.Client_Name,l.Location_Name,s.state_name,e.presentcity from  tbl_Employee_CliantMaster c,tbl_Emp_Location l,tbl_Employee_Mast e, statemaster s where l.location_id=e.location_id and s.state_code=e.presentstate and state_name like'" + TxtCity.Text + "%'");

            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select  e.FirstName +' '+ MiddleName +' '+ LastName as Employ_Name, c.Client_Name,l.Location_Name,s.state_name,e.presentcity from tbl_Employee_Mast e, tbl_Employee_CliantMaster c,tbl_Emp_Location l,statemaster s where c.client_id=" + Cliant_ID + "and l.Location_ID=e.location_id and l.location_id=" + Location_ID + "and s.state_code=e.presentstate and substring(e.language_" + CmbLang.Text + ",5,1)='1'");
            }
            dgv.DataSource = dt;


            dgv.Columns[0].HeaderText = "Employ Name";
            dgv.Columns[1].HeaderText = "Client Name";
            dgv.Columns[2].HeaderText = "Location Name";
            dgv.Columns[3].HeaderText = "State Name";
            dgv.Columns[4].HeaderText = "City Name";

            dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dgv.Columns[0].Width = 275;
            dgv.Columns[1].Width = 135;
            dgv.Columns[2].Width = 135;
            dgv.Columns[3].Width = 135;
            dgv.Columns[4].Width = 135;
        }

        

       

        

    }
}
