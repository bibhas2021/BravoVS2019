using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using System.Web.UI.WebControls;

namespace PayRollManagementSystem
{
    public partial class Pop_up_kit : Form
    {
        //int k_type, p_type;

        
        public Pop_up_kit()
        {
            InitializeComponent();
             //k_type = type_1;
             //p_type = type_2;

        }
        
        DataTable dt_val;
        EDPConnection edpcon;
        Edpcom.EDPCommon edpcom = new EDPCommon();

        public string sql_frm = "";

        private void Pop_up_kit_Load(object sender, EventArgs e)
        {
            //if (k_type == 0)
            //{ show_data(); }
            //else if (p_type == 1)
            //{ get_data(); }
            
        }

        public void show_data(int type_1, int intYear, int intYr, string ktn )
        {
            
           
            sql_frm = "select EKKIT, EKDT as 'KIT ISSUE DATE',EKNAME as 'EMPLOYEE NAME',EKMONTH as 'ISSUE MONTH' ,EKAMT as 'KIT COST','1' as 'QUANTITY'," +
                             "(SELECT Location_Name FROM tbl_Emp_Location WHERE Location_ID=kt.LocID)as'LOCATION'" +
                             "from tbl_Employee_KIT kt WHERE EKKIT='" + ktn + "' and  EKDT between '" + intYear + "-04-01' and '" + intYr + "-03-31'"; 
                      
            dt_val = clsDataAccess.RunQDTbl(sql_frm);
            dt_val.Rows.Add();
            int ind = dt_val.Rows.Count-1;
            dt_val.Rows[ind]["QUANTITY"] = ind + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + ktn+"'");
            for (int j = 0; j < dt_val.Rows.Count - 1; j++)
            {
                try
                {
                    dt_val.Rows[ind]["EMPLOYEE NAME"] = "TOTAL:";
                    
                }
                catch
                {

                }
                if (j == 0)
                {
                    dt_val.Rows[ind]["KIT COST"] =string.Format("{0:n2}", Convert.ToDouble(dt_val.Rows[j]["KIT COST"].ToString() )+ 0);
                    dt_val.Rows[j]["QUANTITY"] = dt_val.Rows[j]["QUANTITY"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt_val.Rows[j]["EKKIT"] + "'");
              
                }
                else
                {
                    try
                    {
                        dt_val.Rows[ind]["KIT COST"] = string.Format("{0:n2}", Convert.ToDouble(dt_val.Rows[ind]["KIT COST"].ToString()) + Convert.ToDouble(dt_val.Rows[j]["KIT COST"].ToString()));
                        dt_val.Rows[j]["QUANTITY"] = dt_val.Rows[j]["QUANTITY"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt_val.Rows[j]["EKKIT"] + "'");
                    }
                    catch
                    { }
                }
            }
            
            dgv_popup_kit.DataSource = dt_val;
            dgv_popup_kit.Columns["EKKIT"].Visible = false;

            //dgv_popup_kit.Rows[dgv_popup_kit.Rows.Count - 1].Cells[2].Style.Font.Bold=true; //new Font("Ariel", 8, FontStyle.Bold);

           //dgv_popup_kit.Columns[0].Selected = true;
            dgv_popup_kit.Columns["KIT COST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_popup_kit.AutoResizeColumns();
        }

        public  void get_data(int type_2,int intYear,int intYr,string ktn)
        {
            sql_frm = "select kt_nm as 'KIT NAME',stk_in as 'STOCK PURCHASED',unit as 'UNIT',p_date as 'PURCHASE DATE',month as 'PURCHASE MONTH' from purchase where kid='" + ktn + "' and p_date between '" + intYear + "-04-01' and '" + intYr + "-03-31' ";
            dt_val = clsDataAccess.RunQDTbl(sql_frm);
            dt_val.Rows.Add();
            int ind = dt_val.Rows.Count - 1;
            dt_val.Rows[ind]["UNIT"] = clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + ktn + "'");
            for (int j = 0; j < dt_val.Rows.Count - 1; j++)
            {
                try
                {
                    dt_val.Rows[ind]["KIT NAME"] = "TOTAL:";

                }
                catch
                {

                }
                if (j == 0)
                {
                    dt_val.Rows[ind]["STOCK PURCHASED"] = string.Format("{0:n0}", Convert.ToDouble(dt_val.Rows[j]["STOCK PURCHASED"].ToString()) + 0);
                   

                }
                else
                {
                    try
                    {
                        dt_val.Rows[ind]["STOCK PURCHASED"] = string.Format("{0:n0}", Convert.ToDouble(dt_val.Rows[ind]["STOCK PURCHASED"].ToString()) + Convert.ToDouble(dt_val.Rows[j]["STOCK PURCHASED"].ToString()));
                        
                    }
                    catch
                    { }
                }
            }

            dgv_popup_kit.DataSource = dt_val;
            //dgv_popup_purchase.Columns["EKKIT"].Visible = false;

            //dgv_popup_kit.Rows[dgv_popup_kit.Rows.Count - 1].Cells[2].Style.Font.Bold=true; //new Font("Ariel", 8, FontStyle.Bold);

            //dgv_popup_kit.Columns[0].Selected = true;
            dgv_popup_kit.Columns["STOCK PURCHASED"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
           
            dgv_popup_kit.AutoResizeColumns();

        }
        
    }
}
