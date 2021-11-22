using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading;
using Microsoft.Win32;
using Edpcom;

namespace PayRollManagementSystem
{
    public partial class EmpWiseJoiningRpt : Form//MstFrmDialog
    {
        public EmpWiseJoiningRpt()
        {
            InitializeComponent();
        }
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        int Company_id = 0, Location_id = 0;
        int mon = 0;
        String sub;
        DataTable dtme = new DataTable();

        //ArrayList arrecode = new ArrayList();
        //string arrayEcode = "";
        //Hashtable get_ecode = new Hashtable();

        private void EmpWiseJoining_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(CmbSession, 2014, System.DateTime.Now.Year, 1);
            try
            {
               if (DateTime.Now.Month >= 4)
                    {
                        try
                        { CmbSession.SelectedItem = DateTime.Now.Year + "-" + DateTime.Now.AddYears(1).Year; }
                        catch { }

                    }
                    else
                    {
                        CmbSession.SelectedItem = DateTime.Now.AddYears(-1).Year + "-" + DateTime.Now.Year;

                    }
                }
                catch
                { }

            //chkSession_Wise.Checked = false;
            rdbName.Checked = true;

            cmbcompany.ReadOnlyText = true;

            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbcompany.Text = Convert.ToString(dt_co.Rows[0][0]);

                Company_id = Convert.ToInt32(dt_co.Rows[0][1]);

            }
            else if (dt_co.Rows.Count > 1)
            {
                cmbcompany.PopUp();

            }
        }
        public void Load_Data1(string qry, ComboBox cb, int i)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {
                for (int d = 0; d < dt.Rows.Count; d++)
                {
                    cb.Items.Add(dt.Rows[d][0].ToString());
                }
                if (i >= 0)
                    cb.SelectedIndex = i;
            }
        }
        public int get_CompID(string name)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            string s = " select GCODE  from Company where CO_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {

                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            }


            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
                //cmbsalstruc.Items.Clear();
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);

            //data_retrive_Company();
        }
        string[] ar = new string[12];


        private void BtnEmpJoin_Click(object sender, EventArgs e)
        {
            string condt = "";
           
            if (chkallloc.Checked == false)
            {
                DataTable dtdate = clsDataAccess.RunQDTbl("select distinct Month(dateofjoining) as mnth from tbl_employee_mast");
                DataTable dt = new DataTable();
                ar[0] = "April";
                ar[1] = "May";
                ar[2] = "June";
                ar[3] = "July";
                ar[4] = "August";
                ar[5] = "September";
                ar[6] = "October";
                ar[7] = "November";
                ar[8] = "December";
                ar[9] = "January";
                ar[10] = "February";
                ar[11] = "March";

                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                if (chkYr.Checked == false)
                {
                    condt = " and em.DateOfJoining between '" + frmdate.Value.Year + "-" + frmdate.Value.Month + "-" + frmdate.Value.Day + "' and '" + todate.Value.Year + "-" + todate.Value.Month + "-" + todate.Value.Day + "'";
                }
                //String str = "select CONVERT(VARCHAR(11),dateofjoining,103) as 'Date Of Joining',"+
                //"(id + ' - ' + ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End))) as 'Employee Name',"+
                //"Location_Name as Location, Designationname as Designation,Pf as 'PF No', Esino as 'ESI No',BankAcountNo as 'Bank a/c No',GMIno as 'IFSC Code',"+
                //"(Bank_Name + \n\r(case when ltrim(rtrim(Branch_Name))<>'' then '[' + Branch_Name + ']' else '' end )) as 'Bank Name' from tbl_employee_mast m,tbl_emp_location l, tbl_employee_designationmaster d where DateOfJoining between '" + frmdate.Value.Year + "-" + frmdate.Value.Month + "-" + frmdate.Value.Day + "' and '" + todate.Value.Year + "-" + todate.Value.Month + "-" + todate.Value.Day + "' and (d.slno=m.desgId) and (m.location_id='" + Location_id + "') and (m.company_id='" + Company_id + "')";
                String str = "select CONVERT(VARCHAR(11),em.dateofjoining,103) as 'Date Of Joining',"+
                "(id + ' - ' + ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End))) as 'Employee Name',"+
                "el.Location_Name as location,ed.DesignationName as Designation,em.PF as 'PF No',em.ESIno as 'ESI No'" +
                ",(Bank_Name + \n\r(case when ltrim(rtrim(Branch_Name))<>'' then '[' + Branch_Name + ']' else '' end )) as 'Bank Name',em.BankAcountNo as 'Bank a/c No',em.GMIno as 'IFSC Code' from tbl_Employee_Mast em,tbl_Emp_Location el,tbl_Employee_DesignationMaster ed where em.DesgId=ed.SlNo and em.Location_id=el.Location_ID and (em.Location_id='" + Location_id + "') "+condt+" and (em.Company_id='" + Company_id + "')";
                dt = clsDataAccess.RunQDTbl(str);


                String Start_d = frmdate.Value.ToString("dd/MM/yyyy");
                String End_d = todate.Value.ToString("dd/MM/yyyy");



                dtme.Clear();
                //if (chkSession_Wise.Checked == true)
                //{
                //    Sess = CmbSession.Text;
                //    str = str + " and m.session='" + CmbSession.Text + "' ";
                //}
                if (rdbID.Checked == true)
                {
                    str = (str + "order by id");
                    //DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by id");
                    //dtme.Merge(dtjoin);
                }
                else if (rdbName.Checked == true)
                {
                    str = (str + " order by firstname,ID");
                    //DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by firstname,ID");
                    //dtme.Merge(dtjoin);
                }
                else if (rdbLocation.Checked == true)
                {
                    str = (str + "order by Location");
                    //DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by Location");
                    //dtme.Merge(dtjoin);
                }
                else if (rdbJoining_Date.Checked == true)
                {
                    str = (str + "order by dateofjoining");
                    //DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by dateofjoining");
                    //dtme.Merge(dtjoin);
                }
                dt = clsDataAccess.RunQDTbl(str);


                //for (int j = 0; j < dtdate.Rows.Count; j++)
                //{
                //    mon = Convert.ToInt32(dtdate.Rows[j]["Mnth"]);
                //    string monthn = clsEmployee.GetMonthName(mon);
                //    for (int i = 0; i < ar.Length; i++)
                //    {
                //        string month = ar[i].ToString();
                //        //int mon = Convert.ToDateTime(dgemployjob.Rows[i].Cells["fromdate"].Value);


                //        if (monthn == month && radioButton1.Checked)
                //        {
                //            DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by id");
                //            dtme.Merge(dtjoin);
                //        }
                //        else if (monthn == month && radioButton2.Checked)
                //        {
                //            DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by firstname");
                //            dtme.Merge(dtjoin);
                //        }
                //        else if (monthn == month && radioButton3.Checked)
                //        {
                //            DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by Location");
                //            dtme.Merge(dtjoin);
                //        }

                //    }
                //}

                sub = "Employee Wise Joining Report During the period From " + frmdate.Value.ToString("dd/MM/yyyy");
                sub = sub + " To " + todate.Value.ToString("dd/MM/yyyy");
                MidasReport.Form1 join = new MidasReport.Form1();
                join.EmpWiseJoin(cmbcompany.Text, sub, End_d, CO_ADD, dt);
                join.ShowDialog();
                //chkSession_Wise.Checked = false;
                //rdbName.Checked = true;
                ////cmbcompany.PopUp();


            }
            else
            {
                    DataTable dtdate = clsDataAccess.RunQDTbl("select distinct Month(dateofjoining) as mnth from tbl_employee_mast");
                    DataTable dt = new DataTable();
                    ar[0] = "April";
                    ar[1] = "May";
                    ar[2] = "June";
                    ar[3] = "July";
                    ar[4] = "August";
                    ar[5] = "September";
                    ar[6] = "October";
                    ar[7] = "November";
                    ar[8] = "December";
                    ar[9] = "January";
                    ar[10] = "February";
                    ar[11] = "March";
                    if (chkYr.Checked == false)
                    {
                        condt = " and DateOfJoining between '" + frmdate.Value.Year + "-" + frmdate.Value.Month + "-" + frmdate.Value.Day + "' and '" + todate.Value.Year + "-" + todate.Value.Month + "-" + todate.Value.Day + "' " ;
                    }
                    String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 as Address FROM Company WHERE CO_CODE = '" + Company_id + "'");
                    String str = "select CONVERT(VARCHAR(11),dateofjoining,103) as 'Date Of Joining'," +
                "(id + ' - ' + ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End))) as 'Employee Name'," +
                "Location_Name as Location, Designationname as Designation,Pf as 'PF No', Esino as 'ESI No',BankAcountNo as 'Bank a/c No',GMIno as 'IFSC Code'," +
                "(Bank_Name + \n\r(case when ltrim(rtrim(Branch_Name))<>'' then '[' + Branch_Name + ']' else '' end )) as 'Bank Name' from tbl_employee_mast m,tbl_emp_location l, tbl_employee_designationmaster d where (d.slno=m.desgId) and ( l.location_id=m.Location_id )" + condt +" and (m.company_id='" + Company_id + "')";
                    


                    String Start_d = frmdate.Value.ToString("dd/MM/yyyy");
                    String End_d = todate.Value.ToString("dd/MM/yyyy");



                    dtme.Clear();
                    //if (chkSession_Wise.Checked == true)
                    //{
                    //    Sess = CmbSession.Text;
                    //    str = str + " and m.session='" + CmbSession.Text + "' ";
                    //}
                    if (rdbID.Checked == true)
                    {
                        str = (str + "order by id");
                        //DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by id");
                        //dtme.Merge(dtjoin);
                    }
                    else if (rdbName.Checked == true)
                    {
                        str = (str + "order by firstname,ID");
                        //DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by firstname,ID");
                        //dtme.Merge(dtjoin);
                    }
                    else if (rdbLocation.Checked == true)
                    {
                        str = (str + "order by Location");
                        //DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by Location");
                        //dtme.Merge(dtjoin);
                    }
                    else if (rdbJoining_Date.Checked == true)
                    {
                        str = (str + "order by dateofjoining");
                        //DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by dateofjoining");
                        //dtme.Merge(dtjoin);
                    }
                    dt = clsDataAccess.RunQDTbl(str);

                    //for (int j = 0; j < dtdate.Rows.Count; j++)
                    //{
                    //    mon = Convert.ToInt32(dtdate.Rows[j]["Mnth"]);
                    //    string monthn = clsEmployee.GetMonthName(mon);
                    //    for (int i = 0; i < ar.Length; i++)
                    //    {
                    //        string month = ar[i].ToString();
                    //        //int mon = Convert.ToDateTime(dgemployjob.Rows[i].Cells["fromdate"].Value);


                    //        if (monthn == month && radioButton1.Checked)
                    //        {
                    //            DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by id");
                    //            dtme.Merge(dtjoin);
                    //        }
                    //        else if (monthn == month && radioButton2.Checked)
                    //        {
                    //            DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by firstname");
                    //            dtme.Merge(dtjoin);
                    //        }
                    //        else if (monthn == month && radioButton3.Checked)
                    //        {
                    //            DataTable dtjoin = clsDataAccess.RunQDTbl(str + "order by Location");
                    //            dtme.Merge(dtjoin);
                    //        }

                    //    }
                    //}
                    sub = "Employee Wise Joining Report During the period From " + frmdate.Value.ToString("dd/MM/yyyy");
                    sub = sub + " To " + todate.Value.ToString("dd/MM/yyyy");
                    MidasReport.Form1 join = new MidasReport.Form1();
                    join.EmpWiseJoin(cmbcompany.Text,sub, End_d, CO_ADD, dt);
                    join.Show();
                    //chkSession_Wise.Checked = false;
                    //rdbName.Checked = true;
                    ////cmbcompany.PopUp();
                }

            
        }

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    Close();
        //}

        private void CmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] StrLine = this.CmbSession.Text.Trim().Split('-');
            frmdate.MinDate = DateTimePicker.MinimumDateTime;
            frmdate.MaxDate = DateTimePicker.MaximumDateTime;

            todate.MinDate = DateTimePicker.MinimumDateTime;
            todate.MaxDate = DateTimePicker.MaximumDateTime;

            frmdate.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            frmdate.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

            todate.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            todate.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);
            frmdate.Value = Convert.ToDateTime("01/April/" + StrLine[0]);
            todate.Value = Convert.ToDateTime("31/March/" + StrLine[1]);
        }



        private void chkallloc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkallloc.Checked == true)
            {

                cmblocation.ReadOnly = true;
               

            }
            else
            {
                cmblocation.ReadOnly = false;
            }
        }


        private void cmblocation_DropDown_1(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID," +
            "(select client_name from tbl_Employee_CliantMaster where Client_id= el.Cliant_ID) as Client,el.Cliant_ID as ClientID "+
            " from tbl_Emp_Location el where (Location_ID IN (select Location_ID from Companywiseid_Relation where (Company_ID='" + Company_id + "'))) order by Location_Name");
               
                //clsDataAccess.RunQDTbl("select Location_Name,Location_ID from tbl_Emp_Location where (Location_ID in (" + edpcom.CurrentLocation + "))");
            if (dt.Rows.Count > 0)
            {
                cmblocation.LookUpTable = dt;
                cmblocation.ReturnIndex = 1;
            }
        }


        private void cmblocation_DropDown_1(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            
            if (Information.IsNumeric(cmblocation.ReturnValue) == true)
                Location_id = Convert.ToInt32(cmblocation.ReturnValue);
        }

        private void frmdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void butselloc_Click(object sender, EventArgs e)
        {

        }

       
       
        }
    }




//        private void selloc_Click(object sender, EventArgs e)
//        {
//            //try
//            //{

//            string sqlstmnt = " SELECT Location_Name AS Location, Location_ID AS ID, Cliant_ID AS ID1  FROM tbl_Emp_Location  ";
//            EDPCommon.MLOV_EDP(sqlstmnt, "Tag ID", "Select Location", "Select ID1", 0, "CMPN", 0);

//            arrecode.Clear();
//            arrecode = EDPCommon.arr_mod;
//            string vecode = "", vename = "", str = "";
//            if (arrecode.Count > 0)
//            {
//                get_ecode.Clear();
//                arrecode = EDPCommon.arr_mod;
//                get_ecode = EDPCommon.get_code;

//                arrayEcode = "";
//                DataSet ds = new DataSet();

//                DataTable dataTable = new DataTable();
//                //ds.Tables[AttendanceGrid];



//                for (int i = 0; i <= arrecode.Count - 1; i++)
//                {

//                    vecode = arrecode[i].ToString();
//                    vename = get_ecode[i].ToString();
//                    //if (chk_data(vecode) == false || chk_data(vecode))
//                    //if (chk_data(vecode) == false || chk_data(vecode) == true)
//                    //{
//                    //str = "select (SELECT DesignationName FROM tbl_Employee_DesignationMaster WHERE (SlNo = em.DesgId)) AS Designation, DesgId FROM tbl_Employee_Mast AS em where (ID='" + vecode + "')";
//                    //DataTable dv = clsDataAccess.RunQDTbl(str);
//                    //try
//                    //{

//                    //DataRow drToAdd = dataTable.NewRow();
//                    //DataView dvg = new DataView((DataTable)AttendanceGrid.DataSource);
//                    //drToAdd[0] = vecode;
//                    //drToAdd[1] = vename;
//                    //drToAdd[2] = dv.Rows[0][0].ToString();
//                    //drToAdd[3] = txtDays.Text;
//                    //drToAdd[4] = "0";
//                    //drToAdd[5] = "0";

//                    //DataTable prev_att = clsDataAccess.RunQDTbl("select  SUM(Wday) AS Wday, SUM(Proxy) AS Proxy from [tbl_Employee_Attend] where ID='" + vecode + "' and Month ='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "' and  Season = '" + cmbYear.Text + "' and (Location_ID <>'" + Location_ID + "')");
//                    //drToAdd[6] = "WD : " + prev_att.Rows[0]["wday"] + (char)13 + "P : " + prev_att.Rows[0]["proxy"];


//                    //drToAdd[7] = dv.Rows[0][1].ToString();
//                    //dataTable.Rows.Add(drToAdd);
//                    //dataTable.AcceptChanges();
//                    //dvg.AddNew();
//                    int ind = dgvloc.Rows.Add();
//                    this.dgvloc.Rows[ind].Cells[0].Value = vecode;
//                    this.dgvloc.Rows[ind].Cells[1].Value = vename;
//                    //this.dgvloc.Rows[ind].Cells[2].Value = dv.Rows[0][0].ToString();
//                    //    this.dgvAttend.Rows[ind].Cells[3].Value = txtDays.Text;
//                    //    this.dgvAttend.Rows[ind].Cells[4].Value = 0;


//                    //    dgvAttend.Rows[ind].Cells[5].Value = 0;
//                    //    dgvAttend.Rows[ind].Cells[7].Value = dv.Rows[0][1].ToString();


//                    //    DataTable prev_att = clsDataAccess.RunQDTbl("select  IsNull(SUM(Wday),0) AS Wday, IsNull(SUM(Proxy),0) AS Proxy from [tbl_Employee_Attend] where ID='" + vecode + "' and Month ='" + AttenDtTmPkr.Value.Month + "/" + AttenDtTmPkr.Value.Year + "' and  Season = '" + cmbYear.Text + "' and (Location_ID <>'" + Location_ID + "')");
//                    //    dgvAttend.Rows[ind].Cells[6].Value = "WD : " + prev_att.Rows[0]["wday"] + (char)13 + "P : " + prev_att.Rows[0]["proxy"];
//                    //    //dgvAttend.AutoResizeColumns();
//                    //    //dgvAttend.AutoResizeRows();
//                    //}
//                    //                catch { }

//                    //            }
//                    //        }

//                    //    }
//                    //}
//                    //catch { }
//                }
//            }
//        }
//    }
//}

        
        
        
        ////private void checkBox1_CheckedChanged(object sender, EventArgs e)
        ////{
        ////    if (chkSession_Wise.Checked == true)
        ////    {
        ////        CmbSession.Visible = true;
        ////    }
        ////    else
        ////    {
        ////        CmbSession.Visible = false;
        ////    }

        //}
            

//        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {

//        }

//    }
//}


