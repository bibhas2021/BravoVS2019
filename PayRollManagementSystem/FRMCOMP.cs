using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using Edpcom;

namespace PayRollManagementSystem
{
    public partial class FRMCOMP : Form
    {
        public FRMCOMP()
        {
            InitializeComponent();
        }
        /* private void TreeView1_enter(object sender, EventArgs e)
           {
               DataTable empdt = clsDataAccess.RunQDTbl("select FirstName +' '+ MiddleName +' '+ LastName as Employ_Name,id from tbl_employee_mast where session='" + CmbSession.Text + "' and company_id=" + Convert.ToInt32(CmbCompany_id.SelectedItem));
               for (int i = 0; i < empdt.Rows.Count; i++)
               {
                   treeView1.Nodes.Add(empdt.Rows[i]["Employ_Name"].ToString());

               }
           }*/
        string Item_Code = "";
        ArrayList arritem = new ArrayList();
        Hashtable getcode_item = new Hashtable();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        string[] ar = new string[12];
        int Location_id = 0;
       
           
         string sqlstmnt = "";
        DataTable dtsql = new DataTable();

        private void BtnReport_Click(object sender, EventArgs e)
        {
            if (Information.IsNumeric(CmbLocation.ReturnValue) == true)
                Location_id = Convert.ToInt32(CmbLocation.ReturnValue);


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
            string mo = "";
            string str_val = "";
            DataTable dl = new DataTable();
            DataTable DTPOSTING = clsDataAccess.RunQDTbl("SELECT FROMDATE,TODATE FROM TBL_EMP_POSTING");
            /*for (int j = 0; j < DTPOSTING.Rows.Count; j++)
            {
                DateTime startdate = Convert.ToDateTime(DTPOSTING.Rows[j]["fromdate"].ToString());
                DateTime enddate = Convert.ToDateTime(DTPOSTING.Rows[j]["todate"].ToString());*/
                for (int i = 0; i < ar.Length; i++)
                {
                    mo = ar[i];
                    if (checkBox1.Checked == false)
                    {
                        str_val = "select ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName,fromdate,todate,location_name,designationname,posting_month as month,DATEDIFF(DAY,convert(datetime,FROMDATE,105),convert(datetime,TODATE,105)) AS DAYS from tbl_emp_posting p,tbl_employee_mast m,tbl_emp_location l,tbl_employee_designationmaster d where m.id=p.employ_id  and P.EMPLOY_ID IN(" + Item_Code + ")and p.location_id= '" + Location_id + "' and P.desgid=d.slno and p.session='" + CmbSession.Text + "'and Posting_month='" + mo + "'";
                    }
                    else
                    {
                        str_val = "select ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName,fromdate,todate,location_name,designationname,posting_month as month,DATEDIFF(DAY,convert(datetime,FROMDATE,105),convert(datetime,TODATE,105)) AS DAYS from tbl_emp_posting p,tbl_employee_mast m,tbl_emp_location l,tbl_employee_designationmaster d where m.id=p.employ_id and p.location_id= '" + Location_id + "' and P.desgid=d.slno and p.session='" + CmbSession.Text + "'and Posting_month='" + mo + "'";
                    }
                    //DataTable dt = clsDataAccess.RunQDTbl("select firstname,middlename,lastname,designationname,location_name,DAYSPRESENT,fromdate,todate,month from tbl_EMPLOYEE_MAST m,tbl_emp_location l,tbl_employee_designationmaster d,tbl_employee_salarymast s,tbl_emp_posting p WHERE M.ID=s.Emp_id AND s.emp_ID='" + (CmbEmployee_id.SelectedItem) + "'and m.code=p.id and d.slno= m.desgid and m.location_id=l.location_id and l.cliant_id=p.cliant_id and p.session='" + CmbSession.Text + "'and s.month='" + mo + "'");
                    DataTable dt = clsDataAccess.RunQDTbl(str_val);
                    dl.Merge(dt);
                    dl.AcceptChanges();
                }
            //}
            MidasReport.Form1 Employ = new MidasReport.Form1();
            Employ.employee_rpt(CmbCompany.Text, CmbSession.Text, dl);
            Employ.Show();
        }




        private void FRMCOMP_Load(object sender, EventArgs e)
        {
            //compname();
            try
            {
               // CmbCompany.SelectedIndex = 0;
                clsValidation.GenerateYear(CmbSession, 2015, DateTime.Now.Year, 1);
                CmbSession.SelectedIndex = 0;
            }
            catch
            {
                clsValidation.GenerateYear(CmbSession, 2015, System.DateTime.Now.Year, 1);
                
            }
        }
        //public void compname()
        //{
        //    CmbCompany_id.Items.Clear();
        //    CmbCompany.Items.Clear();
        //    //edpcon.Open();
        //    DataTable cmpdt = clsDataAccess.RunQDTbl("select distinct Co_Code,Co_Name from company,tbl_Employee_Assign_SalStructure where session='" + CmbSession.Text + "'");
        //    for (int i = 0; i < cmpdt.Rows.Count; i++)
        //    {
        //        CmbCompany.Items.Add(cmpdt.Rows[i]["CO_NAME"].ToString());
        //        CmbCompany_id.Items.Add(cmpdt.Rows[i]["Co_Code"].ToString());
        //    }
        //    // edpcon.Close();
        //}
        //public void locname()
        //{
        //    CmbLocation.Items.Clear();
        //    CmbLocation_id.Items.Clear();
        //    DataTable locdt = clsDataAccess.RunQDTbl(" select distinct l.Location_Name,l.Location_ID  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r,dbo.tbl_Employee_Assign_SalStructure a where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and a.session='" + CmbSession.Text + "'and a.company_id =" + Convert.ToInt32(CmbCompany_id.SelectedItem));
        //    for (int i = 0; i < locdt.Rows.Count; i++)
        //    {
        //        CmbLocation.Items.Add(locdt.Rows[i]["Location_name"].ToString());
        //        CmbLocation_id.Items.Add(locdt.Rows[i]["Location_ID"].ToString());
        //    }
        //}
        public void EmployeeList()
        {
            CmbEmployee.Items.Clear();
            CmbEmployee_id.Items.Clear();
            DataTable empdt = clsDataAccess.RunQDTbl("select FirstName +' '+ MiddleName +' '+ LastName as Employ_Name,id from tbl_employee_mast where session='" + CmbSession.Text + "' and company_id=" + Convert.ToInt32(CmbCompany_id.SelectedItem));
            for (int i = 0; i < empdt.Rows.Count; i++)
            {
                CmbEmployee.Items.Add(empdt.Rows[i]["Employ_Name"].ToString());
                CmbEmployee_id.Items.Add(empdt.Rows[i]["id"].ToString());
            }
        }
        private void CmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void CmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
       

        private void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbEmployee_id.SelectedIndex = CmbEmployee.SelectedIndex;
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        DataTable dtro = clsDataAccess.RunQDTbl("select  fromdate from tbl_emp_posting");

        DataTable dt = new DataTable();
        int j;
        int l;


        private void button1_Click_1(object sender, EventArgs e)
        {
          
            try
            {

                dtsql = clsDataAccess.RunQDTbl("Select Distinct (select ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS Name from tbl_Employee_Mast e where e.ID=p.Employ_id) as 'EmpName',p.Employ_id as 'ID', ' ' ,' ',' ', ' ' from tbl_Emp_Posting p,tbl_employee_mast m where p.Session ='" + CmbSession.Text + "' and m.company_id=" + Convert.ToInt32(CmbCompany_id.SelectedItem));
                //dt.Merge(dtsql);

                EDPCommon.MLOV_EDP(dtsql, "Tag Item", "Select Employee", "Select Employee", 0);

                arritem.Clear();
                arritem = EDPCommon.arr_mod;

                if (arritem.Count > 0)
                {
                    getcode_item.Clear();
                    arritem = EDPCommon.arr_mod;
                    getcode_item = EDPCommon.get_code;
                    //lblproduct.Items.Clear();
                    Item_Code = null;
                    //for (int i = 0; i <= (arritem.Count - 1); i++)
                    //{
                    //    //lblproduct.Items.Add(arritem[i].ToString());
                    //    Item_Code = Item_Code + getcode_item[i].ToString();
                    //    if (i != getcode_item.Count - 1)
                    //    {
                    //        Item_Code = "'" + Item_Code + "'" + "," + "'";
                    //    }
                    //}

                    Item_Code = "''";

                    for (int i = 0; i <= arritem.Count - 1; i++)
                    {
                        Item_Code = Item_Code + "," + "'" + getcode_item[i].ToString() + "'";

                    }


                }


            }

            catch { };
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void CmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID from tbl_Emp_Location");
            if (dt.Rows.Count > 0)
            {
                CmbLocation.LookUpTable = dt;
                CmbLocation.ReturnIndex = 1;
            }
        }

        private void CmbLocation_DropDown_Closeup(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {

            if (Information.IsNumeric(CmbLocation.ReturnValue) == true)
                Location_id = Convert.ToInt32(CmbLocation.ReturnValue);
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {

            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            if (dt.Rows.Count > 0)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
        }
    }
}

        

       
       

    


