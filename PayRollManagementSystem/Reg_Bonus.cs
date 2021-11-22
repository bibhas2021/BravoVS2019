using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data.SqlClient;
using Edpcom;


namespace PayRollManagementSystem
{
    public partial class Reg_Bonus : Form
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        DataTable dt = new DataTable();
        string Locations = "", Item_Code = "", co_name = "", co_add = "", sub = "",month="";
       
        int company_id = 0, Loc_id = 0;

        public Reg_Bonus()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rdb_Co.Checked == true)
            {
                DataTable dtLocations = clsDataAccess.RunQDTbl("select [Location_ID] from [Companywiseid_Relation] where [Company_ID] = " + company_id + " and Location_ID <> 0");
                Locations = "";
                for (int ind = 0; ind < dtLocations.Rows.Count; ind++)
                {
                    if (ind == 0)
                        Locations =  "'" + dtLocations.Rows[ind][0] + "'";
                    else
                        Locations = Locations + ",'" + dtLocations.Rows[ind][0] + "'";
                }
                //Locations = Locations + ")";
                get_data();
                sub = "For all locations"; ;
              
            }
            else if (rdb_loc.Checked == true)
            {
                get_data();
                
            }
            co_add = clsDataAccess.GetresultS("select CO_ADD from Company where GCODE = '" + company_id+ "' ");
            co_name = clsDataAccess.GetresultS("select CO_NAME from Company where GCODE = '" + company_id + "'");
            month = "For the month of "+AttenDtTmPkr.Value.ToString("MMMM,yyyy");
            MidasReport.Form1 bns = new MidasReport.Form1();
            bns.bonus(co_add,co_name,sub,month,dt,0);
            bns.ShowDialog();
      
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void Stock_inventory_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }


            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbcompany.Text = Convert.ToString(dt_co.Rows[0][0]);

                company_id = Convert.ToInt32(dt_co.Rows[0][1]);
                cmbcompany.ReturnValue = company_id.ToString();

            }
            else if (dt_co.Rows.Count > 1)
            {
                cmbcompany.PopUp();

            }
            btnlog.Enabled = false;
            AttenDtTmPkr.Value = DateTime.Now.AddMonths(-1);
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt;
            dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
            {
                
                company_id = Convert.ToInt32(cmbcompany.ReturnValue);

            }
       
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            string sqlstmnt = "";
            sqlstmnt = "select l.Location_Name,l.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l ,Companywiseid_Relation r where  l.Location_ID =r.Location_ID and (company_ID='" + company_id + "')";
            EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Location", "Select Location", 0, "CMPN", 0);
            arr.Clear();
            arr = EDPCommon.arr_mod;
            //lbllog.Items.Clear();
            if (arr.Count > 0)
            {
                getcode.Clear();
                arr = EDPCommon.arr_mod;
                getcode = EDPCommon.get_code;
                //lbllog.Items.Clear();
                Item_Code = "";

                for (int i = 0; i <= (arr.Count - 1); i++)
                {
                    //lbllog.Items.Add(arr[i].ToString());
                    Item_Code = Item_Code + getcode[i].ToString();
                    if (i != getcode.Count - 1)
                    {
                        Item_Code = Item_Code + ",";
                    }
                }
                Locations = Item_Code;
            }
       
        }

        private void get_data()
        {
            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            string Str_ESI = "";
            string Str_ESI_SLNO = "";
            DataTable data_ESI = clsDataAccess.RunQDTbl("SELECT DISTINCT d.SalaryHead_Full,d.SlNo FROM tbl_Employee_ErnSalaryHead AS d INNER JOIN tbl_Employee_Assign_SalStructure AS e ON d.SlNo = e.SAL_HEAD WHERE ({ fn UCASE(d.SalaryHead_Full) } = 'BONUS') AND (e.Location_ID IN (" + Locations + "))");

            if (data_ESI.Rows.Count > 0)
            {
                Str_ESI = data_ESI.Rows[0][0].ToString();
                Str_ESI_SLNO = data_ESI.Rows[0][1].ToString();
            }
            else
            {
                Str_ESI = "";
                ERPMessageBox.ERPMessage.Show("There is no BONUS Head in the Salary Structure");
                return;
            }

            Boolean flug_deduction = false;

            DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,''+em.FathFN+''+em.FathMN+''+em.FathLN as Fname,sm.Emp_Id as ID,sm.Location_id,(select lm.[Location_Name] from [tbl_Emp_Location] lm where lm.[Location_ID] = sm.Location_id) as 'LocationName'," +
            "(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as Rank,sm.desig_id," +
            "(select distinct (case when alt_mon='1'then pt_basis else '' end)from tbl_Employee_Assign_SalStructure  where Location_id =sm.Location_id  and SAL_HEAD='" + Str_ESI_SLNO + "' and P_TYPE='E')as 'bonus_period'," +
            "(select distinct REMARKS from tbl_Employee_Assign_SalStructure  where Location_id =sm.Location_id  and SAL_HEAD='" + Str_ESI_SLNO + "' and P_TYPE='E')as 'remarks'" +
            " from tbl_Employee_SalaryMast sm,tbl_Employee_Mast em  where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id in (" + Locations + ") and em.ID = sm.Emp_Id order by sm.Emp_Id");

            DataTable salary_details = clsDataAccess.RunQDTbl("Select * from (SELECT EmpId,SalId,TableName,Slno,Amount,0 as Designation_id,Location_id,cast(convert(char(11), InsertionDate, 103) as VARCHAR) as InsertionDate FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id IN (" + Locations + ") and salid='" + Str_ESI_SLNO + "' and TableName='tbl_Employee_ErnSalaryHead' union SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id,Location_id,cast(convert(char(11), InsertionDate, 103) as VARCHAR) as InsertionDate FROM [tbl_Employee_SalaryDet_MultiDesignation] where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id IN (" + Locations + ") and salid='" + Str_ESI_SLNO + "' and TableName='tbl_Employee_ErnSalaryHead') main order by Designation_id,Slno");

            DataView dv = new DataView(salary_details);
            tot_employ.Columns.Add("Date", typeof(string));
            tot_employ.Columns.Add("BONUS", typeof(string));

            int table_count = tot_employ.Columns.Count;

            tot_employ.Rows.Add();
            int dt_count = tot_employ.Rows.Count-1;
            //tot_employ.Rows.Add();
            //tot_employ.Rows.Add();

            int counter = 0;

            //tot_employ.Columns.Add("Date", typeof(string));

            string Salary_Head = "";

            for (int i = 0; i < tot_employ.Rows.Count-1 ; i++)
            {
                dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["desig_id"] + "' and Location_id = '" + tot_employ.Rows[i]["location_id"] + "'";
                try
                {
                    Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Full from " + dv[0]["TableName"] + " where SlNo ='" + dv[0]["SalId"] + "'  ");
                }
                catch { }
                tot_employ.Rows[dt_count][5] = "                Total :";

                if (i == 0)
                {
                    if (Salary_Head == Str_ESI && dv.Count > 0)
                    {
                        //tot_employ.Columns.Add(Salary_Head, typeof(string));
                        tot_employ.Rows[i]["BONUS"] = dv[0]["Amount"];
                        tot_employ.Rows[i]["Date"] = dv[0]["InsertionDate"];


                        //tot_employ.Rows[dt_count - 1]["BONUS"] = "";
                        tot_employ.Rows[dt_count]["BONUS"] = Convert.ToDouble( dv[0]["Amount"]).ToString();
                        //tot_employ.Rows[dt_count + 1]["BONUS"] = "";
                        tot_employ.Rows[i]["sl"] = i + 1;
                    }
                    else
                    {

                        if (dv.Count == 0)
                        {
                            tot_employ.Rows.RemoveAt(i);
                            dt_count--;
                            i--;

                        }
                        if (Information.IsNumeric(tot_employ.Rows[dt_count]["BONUS"].ToString()) == true)
                            tot_employ.Rows[dt_count]["BONUS"] = Convert.ToDouble(tot_employ.Rows[dt_count]["BONUS"].ToString()) + 0;
                        else
                            tot_employ.Rows[dt_count]["BONUS"] =  0;
                
                    }
                }
                else
                {
                    if (Salary_Head == Str_ESI && dv.Count>0 )
                    {
                        tot_employ.Rows[i]["BONUS"] =dv[0]["Amount"];
                        tot_employ.Rows[i]["Date"] = dv[0]["InsertionDate"];

                        tot_employ.Rows[dt_count]["BONUS"] = string.Format("{0:n}", Convert.ToDouble(tot_employ.Rows[dt_count]["BONUS"]) + Convert.ToDouble(dv[0]["Amount"]));
                        tot_employ.Rows[i]["sl"] = i + 1;

                    }
                    else
                    {
                        if (dv.Count == 0)
                        {
                            tot_employ.Rows.RemoveAt(i);
                            dt_count--;
                            i--;

                        }
                        if (Information.IsNumeric(tot_employ.Rows[dt_count]["BONUS"].ToString()) == true)
                            tot_employ.Rows[dt_count]["BONUS"] = Convert.ToDouble(tot_employ.Rows[dt_count]["BONUS"].ToString())+ 0;
                
                    }
                }

               // tot_employ.Rows[i]["sl"] = ;
               // tot_employ.Rows[dt_count - 1]["sign"] = "";
                //tot_employ.Rows[dt_count + 1]["sign"] = "";
            }
            if (Salary_Head != "")
            {
                //tot_employ.Columns[Salary_Head].SetOrdinal(table_count - 1);
                tot_employ.Columns.Remove("ID");
                tot_employ.Columns.Remove("desig_id");
                //tot_employ.Columns.Remove("Location_id");

                dt = tot_employ.Copy();
                dt.AcceptChanges();
                 
 
            }



        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            if (rdb_Co.Checked == true)
            {
                DataTable dtLocations = clsDataAccess.RunQDTbl("select [Location_ID] from [Companywiseid_Relation] where [Company_ID] = " + company_id + " and Location_ID <> 0");
                Locations = "";
                for (int ind = 0; ind < dtLocations.Rows.Count; ind++)
                {
                    if (ind == 0)
                        Locations = "'" + dtLocations.Rows[ind][0] + "'";
                    else
                        Locations = Locations + ",'" + dtLocations.Rows[ind][0] + "'";
                }
                //Locations = Locations + ")";
                get_data();
                sub = "For all locations"; ;

            }
            else if (rdb_loc.Checked == true)
            {
                get_data();

            }
            co_add = clsDataAccess.GetresultS("select CO_ADD from Company where GCODE = '" + company_id + "' ");
            co_name = clsDataAccess.GetresultS("select CO_NAME from Company where GCODE = '" + company_id + "'");
            month = "For the month of " + AttenDtTmPkr.Value.ToString("MMMM,yyyy");
            MidasReport.Form1 bns = new MidasReport.Form1();
            bns.bonus(co_add, co_name, sub, month, dt,1);
           // bns.ShowDialog();

        }

        private void rdb_Co_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Co.Checked == false)
            {
                btnlog.Enabled = true;
            }
            else if (rdb_Co.Checked == true)
            {
                btnlog.Enabled = false;
            }
        }

        
    }
}
