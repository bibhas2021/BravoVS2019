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
//using Excel;

namespace PayRollManagementSystem
{
    public partial class frmEmployeePTAXReport : EDPComponent.FormBaseRptMidium
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        string Item_Code = "", Tentry_code = "";
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Frm_Type = "";
        int Head_Cou = 0;
        string Locations = "";
        int Company_id = 0,Location_Id=0;

        string current_company;
        string address = "";
        string address1 = "";
        string pan;
        string DURATION;
        string sq1;


        public frmEmployeePTAXReport(string type)
        {
            InitializeComponent();
            Frm_Type = type;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmEmployeeSalarySheet_Load(object sender, EventArgs e)
        {
            this.Text = "P.Tax Report";
           
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            //set session
            AttenDtTmPkr.Value = DateAndTime.Now;
            cmbState.SelectedIndex = 0;
            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbcompany.Text = Convert.ToString(dt_co.Rows[0][0]);

                Company_id = Convert.ToInt32(dt_co.Rows[0][1]);
                cmbcompany.ReturnValue = Company_id.ToString();
                cmbcompany.Enabled = false;

            }
            else if (dt_co.Rows.Count > 1)
            {
                cmbcompany.PopUp();

            }
       
      
        }
        
        private void btnPreview_Click(object sender, EventArgs e)
        {

            if (rdb_loc.Checked == true)
            {
                Locations = "";
                Retrive_DataESI();
                if (dt.Rows.Count > 0)
                {
                    string sub = "",com = "",add = "";
                    com = cmbcompany.Text.ToString();
                    add = clsDataAccess.GetresultS(" select CO_ADD +' '+CO_ADD1 from Company where GCODE = '" + cmbcompany.ReturnValue + "' ");
                    sub = "Detailed P.TAX Report (Location Wise) for the month of " + AttenDtTmPkr.Value.ToString("MMMM, yyyy");
                    MidasReport.Form1 opening = new MidasReport.Form1();
                    opening.ptax(com, add, sub, dt);

                    opening.ShowDialog();

                    //PrintDetails(1);
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("No record Found");
                    return;
                }

                dt.Dispose();
                dt.Clear();
            }
            else
            {
                string qry_pt = "", qry_tbl="",cid="0",pt="0";
                double tot_emp=0, tot_amt=0;
                Locations = "";
                DataTable dt_rpt = new DataTable();
               // clsDataAccess.RunQDTbl("select 'c1','c2','c3','c4','c5','c6','c7','c8','c9','c10','c11','c12','c13','c14','c15'");
                int col_i = 0;


                string Ptax_Head_id=  clsDataAccess.GetresultS("SELECT Distinct SAL_HEAD FROM tbl_Employee_Assign_SalStructure AS e WHERE (PT = 1) AND (Company_id = '" + Company_id + "')");
                if (cmbState.SelectedIndex==1)
                {
                    qry_pt = "SELECT distinct Location_id FROM tbl_Employee_Assign_SalStructure AS e WHERE (PT=1 or SAL_HEAD='" + Ptax_Head_id + "') AND (Company_id ='" + Company_id + "') and (Location_id in (SELECT [Location_ID] FROM [tbl_Emp_Location] where Cliant_ID in (SELECT Client_id FROM tbl_Employee_CliantMaster where client_state in (SELECT STATE_CODE FROM StateMaster where State_Name='WEST BENGAL')))) order by Location_id";
                }
                else
                {
                   qry_pt = "SELECT distinct Location_id FROM tbl_Employee_Assign_SalStructure AS e WHERE (PT=1 or SAL_HEAD='" + Ptax_Head_id + "') AND (Company_id = '" + Company_id + "')  order by Location_id";
                }
                    DataTable dt = clsDataAccess.RunQDTbl(qry_pt);
                for (int ind = 0; ind < dt.Rows.Count; ind++)
                {
                    if (Locations == "")
                        Locations = "'" + dt.Rows[ind][0].ToString() + "'";
                    else
                        Locations = Locations + ",'" + dt.Rows[ind][0].ToString() + "'";

                }
                string st = clsDataAccess.GetresultS("SELECT STATE_CODE FROM StateMaster WHERE (State_Name = 'West Bengal')");
                qry_pt="SELECT DISTINCT Cliant_ID,(SELECT Client_Name FROM tbl_Employee_CliantMaster WHERE " +
              "(Client_id = el.Cliant_ID)) AS CName,(SELECT Client_State FROM tbl_Employee_CliantMaster WHERE (Client_id = el.Cliant_ID)) AS CSt  FROM tbl_Emp_Location AS el WHERE (Location_ID IN (" + Locations + "))";
                DataTable comp = clsDataAccess.RunQDTbl(qry_pt);
                qry_pt = "SELECT pt FROM tbl_Employee_PTRate order by pt";
                DataTable dt_pt = clsDataAccess.RunQDTbl(qry_pt);

                dt_rpt.Rows.Add();
                dt_rpt.Columns.Add();
                dt_rpt.Rows[0][0] = "NAME OF THE CLIENT";
                dt_rpt.Columns.Add();
                dt_rpt.Rows[0][1] = "Total Employee";
                for (int ind = 0; ind < dt_pt.Rows.Count; ind++)
                {
                    if (cmbState.SelectedIndex == 1)
                    {
                        dt_rpt.Columns.Add();
                        col_i = ind + 2;
                        if (dt_pt.Rows[ind][0].ToString() == "0.00")
                        {
                            dt_rpt.Rows[0][col_i] = "Slab"+Environment.NewLine+"NIL";
                        }
                        else
                        {
                            dt_rpt.Rows[0][col_i] = "Slab" + Environment.NewLine + dt_pt.Rows[ind][0].ToString();
                        }
                    }
                    else
                    {
                       // if (dt_pt.Rows[ind][0].ToString() == "0.00")             //in this line statecode is compairing with ptaxes. this line is genarating problem at line 180 because of this next columns cant be genarated
                        {
                            dt_rpt.Columns.Add();
                            col_i = ind + 2;
                            if (dt_pt.Rows[ind][0].ToString() == "0.00")
                            {
                                dt_rpt.Rows[0][col_i] = "Slab" + Environment.NewLine + "NIL";
                            }
                            else
                            {
                                dt_rpt.Rows[0][col_i] = "Slab" + Environment.NewLine + dt_pt.Rows[ind][0].ToString();
                            }
                        }
                        
                    }
                }
                dt_rpt.Columns.Add();
                //Changed by dwipraj dutta at 28072017
                if (col_i > 0)
                    col_i = col_i + 1;
                else
                    col_i = col_i + 2;
                dt_rpt.Rows[0][col_i] = "Total Amount";

               
                for (int cl_i = 0; cl_i < comp.Rows.Count; cl_i++)
                {
                    tot_amt = 0;
                    tot_emp = 0;
                    cid = comp.Rows[cl_i]["Cliant_ID"].ToString();
                    dt_rpt.Rows.Add();
                    dt_rpt.Rows[cl_i + 1][0] = comp.Rows[cl_i]["CName"].ToString();

                for (int ind = 0; ind < dt_pt.Rows.Count; ind++)
                  {
                    
                    col_i=ind+2;
                    pt = dt_pt.Rows[ind]["pt"].ToString();
                    
                     string qry_count = "select "+
                    "(SELECT count(EmpId) FROM tbl_Employee_SalaryDet WHERE (TableName='tbl_Employee_DeductionSalayHead') AND (SalId="+ 
                    Ptax_Head_id  + ") and (Amount="+ pt +") and (Month='"+ AttenDtTmPkr.Value.ToString("MMMM") +
                    "') and (Session='"+ cmbYear.SelectedItem +"') and (Company_id='" + Company_id +
                    "') and (Location_id IN (SELECT Location_ID FROM tbl_Emp_Location WHERE (Cliant_ID=(" + cid + ")))))";// +
                         //" + "+
                         //"(SELECT count(EmpId) FROM tbl_Employee_SalaryDet WHERE (TableName='tbl_Employee_DeductionSalayHead') AND (SalId=" +
                         //Ptax_Head_id + ") and (Amount=" + pt + ") and (Month='" + AttenDtTmPkr.Value.ToString("MMMM") +
                         //"') and (Session='" + cmbYear.SelectedItem + "') and (Company_id='" + Company_id +
                         //"') and (Location_id IN (SELECT Location_ID FROM tbl_Emp_Location WHERE (Cliant_ID=(" + cid + ")))))";

                       dt_rpt.Rows[cl_i + 1][col_i] = clsDataAccess.GetresultS(qry_count);
                    
                    tot_emp = tot_emp + Convert.ToDouble(dt_rpt.Rows[cl_i + 1][col_i]);
                    
                    tot_amt = tot_amt +Convert.ToDouble (Convert.ToDouble(dt_rpt.Rows[cl_i + 1][col_i])* Convert.ToDouble(pt));
                  }
                
                  dt_rpt.Rows[cl_i + 1][1] = tot_emp;
                  dt_rpt.Rows[cl_i + 1][col_i + 1] = tot_amt;
                }

             //   dt_rpt.Rows.Add();
                dt_rpt.Rows.Add();
                col_i = dt_rpt.Rows.Count-1;//col_i + 5;
                dt_rpt.Rows[col_i][0] = "Summation";
                dt_rpt.Rows.Add();
                col_i = col_i + 1;
                dt_rpt.Rows[col_i][0] = "Number of Employee";
                dt_rpt.Rows.Add();
              
                dt_rpt.Rows[col_i+1][0] = "Total Amount";

                for (int cl_i = 0; cl_i < comp.Rows.Count; cl_i++)
                {
                    try
                    {
                        dt_rpt.Rows[col_i][1] = Convert.ToDouble(dt_rpt.Rows[cl_i + 1][1]) + Convert.ToDouble(dt_rpt.Rows[col_i][1]);
                    }
                    catch
                    {
                        dt_rpt.Rows[col_i][1] = Convert.ToDouble(dt_rpt.Rows[cl_i + 1][1]) + 0;
                    }
                    for (int ind = 0; ind <= dt_pt.Rows.Count; ind++)
                    {
                        if (ind != dt_pt.Rows.Count)
                        {
                            try
                            {
                                dt_rpt.Rows[col_i][ind + 2] = Convert.ToDouble(dt_rpt.Rows[cl_i + 1][ind + 2]) + Convert.ToDouble(dt_rpt.Rows[col_i][ind + 2]);
                            }
                            catch
                            {
                                dt_rpt.Rows[col_i][ind + 2] = Convert.ToDouble(dt_rpt.Rows[cl_i + 1][ind + 2]) + 0;
                            }
                            try
                            {
                                dt_rpt.Rows[col_i + 1][ind + 2] = Convert.ToDouble(dt_rpt.Rows[col_i][ind + 2]) * Convert.ToDouble(dt_pt.Rows[ind][0]);
                            }
                            catch
                            {
                                dt_rpt.Rows[col_i + 1][ind + 2] = 0;
                            }
                        }
                        else
                        {
                            try
                            {
                                dt_rpt.Rows[col_i+1][ind + 2] = Convert.ToDouble(dt_rpt.Rows[cl_i + 1][ind + 2]) + Convert.ToDouble(dt_rpt.Rows[col_i+1][ind + 2]);
                            }
                            catch
                            {
                                dt_rpt.Rows[col_i+1][ind + 2] = Convert.ToDouble(dt_rpt.Rows[cl_i + 1][ind + 2]) + 0;
                            }

                        }

                        
                    }

                }
                string sub = "",add = "";
                add = clsDataAccess.GetresultS(" select CO_ADD +' '+CO_ADD1 from Company where GCODE = '" + cmbcompany.ReturnValue + "' ");
                sub = sub = "P.TAX Report For the month of '" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "' ";
                  MidasReport.Form1 MR = new MidasReport.Form1();
                  MR.Ptaxcomp(cmbcompany.Text, sub,add, dt_rpt);
                MR.Show();
            }

           
            
                     
        }
        public void Printheader()
        {

            DataSet dsBRANCH = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();

            edpcon.Close();
            edpcon.Open();
            dsBRANCH.Clear();
            cmd = new SqlCommand("select b.BRNCH_ADD1,b.BRNCH_ADD2,b.BRNCH_CITY,s.State_Name,b.BRNCH_PIN,b.BRNCH_PAN1 FROM BRANCH b,StateMaster s WHERE b.FICODE=" + edpcom.CurrentFicode + " AND b.GCODE=" + edpcom.PCURRENT_GCODE + " AND b.BRNCH_CODE=0 and s.STATE_CODE=b.BRNCH_STATE ", edpcon.mycon);
            //edpcon.mycon.Open();

            adp.SelectCommand = cmd;

            try
            {
                adp.Fill(dsBRANCH, "BR");

                DURATION = "As On : " + "" + AttenDtTmPkr.Value.ToShortDateString() + "";


                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][0]) != "")
                    address = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][0]) + ",";

                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]) != "")
                    address = address + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][1]);


                address1 = "";
                if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                    address1 = address1 + " - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                    address1 = address1 + ", " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                    address1 = address + " - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() == ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]) + "," + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]) + ", PIN No. - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() == ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() != "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() == ""))
                {
                    address1 = Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]);
                }
                else if ((Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][2]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][3]).Trim() == "") && (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]).Trim() != ""))
                {
                    address1 = "PIN No. - " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][4]);
                }
                if (Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][5]) != "")
                    pan = "PAN No. : " + Convert.ToString(dsBRANCH.Tables["BR"].Rows[0][5]);
                else
                    pan = "";

                string query = "select co_name from company where ficode='" + edpcom.CurrentFicode + "' and Gcode='" + edpcom.PCURRENT_GCODE + "'";
                DataTable dtre = RunQDTbl(query);
                current_company = (dtre.Rows[0][0].ToString());
            }
            catch
            {
            }

        }

        public static DataTable RunQDTbl(String strSql)
        {
            return new EDPCommon().GetDatatable(strSql);
        }

      
        private void btnPrnt_Click(object sender, EventArgs e)
        {
           
            PrintDetails(2);
        }

        public void PrintDetails(int flug)
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = dt.Copy();               
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    int s = i + 1;
                    dt.Columns[i].ColumnName = "col" + s;
                }
                 //dt1 = dt.Copy();
                MidasReport.Form1 MR = new MidasReport.Form1();
                DataTable dt_Sal_Pur_Reg_Final = dt;

                //string[] Report_Columns_Header = new string[6];

                //============================Report Header============================================
                string[] Report_Header = new string[4];
                string[] Report_Header_FontName = new string[4];
                string[] Report_Header_FontSize = new string[4];
                string[] Report_Header_FontStyle = new string[4];

                string TopVal = "1,0,0,0";
                string WidthVal = "1150,1150,1150,1150";
                string HeightVal = "6,5,4,5";// "226,226,226,226";
                string LeftVal = "0,0,0,0";
                string AlignVal = "M,M,M,M";

                Report_Header[0] = cmbcompany.Text;//edpcom.CURRENT_COMPANY;
                Report_Header[1] = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                Report_Header[2] = "Detailed P.TAX Report (locationwise) For the month of  " + AttenDtTmPkr.Text; ;
                //Report_Header[3] = " For the month of  " + AttenDtTmPkr.Text;//+ Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString();

                //Report_Header[3] = "Form " + Convert.ToDateTime(dtpForm.Value).ToShortDateString() + " TO " + Convert.ToDateTime(dtpto.Value).ToShortDateString();
                

                //Report_Header[4] = ""; //"Periodical Stock Transaction";

                for (int i = 0; i <= Report_Header.Length - 1; i++)
                {
                    Report_Header_FontName[i] = "Arial";
                    Report_Header_FontSize[i] = "10";
                    Report_Header_FontStyle[i] = "B";
                }
                MR.ReportHeaderArrenge(Report_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Header_FontName, Report_Header_FontSize, Report_Header_FontStyle);
                //=================================End===========================================

                //============================Report Page Header============================================
                string[] Report_Page_Header = new string[2];
                string[] Report_PageHeader_FontName = new string[2];
                string[] Report_PageHeader_FontSize = new string[2];
                string[] Report_PageHeader_FontStyle = new string[2];

                TopVal = "2,0";
                WidthVal = "200,200";
                //HeightVal = "6,6";// "226,226,226,226";
                HeightVal = "0,0";// "226,226,226,226";
                LeftVal = "2,2";
                AlignVal = "M,L";  //L for Left,R for Right,M for center

                Report_Page_Header[0] = "Salary Sheet for the location " + cmbsalstruc.Text;
                Report_Page_Header[1] = "Session " + cmbYear.SelectedItem + " For the month of  " + AttenDtTmPkr.Text;

                Report_PageHeader_FontName[0] = "Arial";
                Report_PageHeader_FontName[1] = "Arial";
                Report_PageHeader_FontSize[0] = "10";
                Report_PageHeader_FontSize[1] = "10";
                Report_PageHeader_FontStyle[0] = "B";
                Report_PageHeader_FontStyle[1] = "B";             
                MR.ReportPageHeaderArrenge(Report_Page_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageHeader_FontName, Report_PageHeader_FontSize, Report_PageHeader_FontStyle);
                //====================================End===========================================

                //============================Report Page Footer============================================
                string[] Report_PageFooter = new string[1];
                string[] Report_PageFooter_FontName = new string[1];
                string[] Report_PageFooter_FontSize = new string[1];
                string[] Report_PageFooter_FontStyle = new string[1];

                TopVal = "1";
                WidthVal = "33";
                HeightVal = "2";// "226,226,226,226";
                LeftVal = "2";
                AlignVal = "R";

                Report_PageFooter[0] = " ";               
                Report_PageFooter_FontName[0] = "Arial";               
                Report_PageFooter_FontName[0] = "8";               
                Report_PageFooter_FontStyle[0] = "B";               
                MR.ReportPageFooterArrenge(Report_PageFooter, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageFooter_FontName, Report_PageFooter_FontName, Report_PageFooter_FontStyle);
                ////====================================End===========================================

                ////============================Report Footer============================================
                string[] Report_Footer = new string[1];
                string[] Report_Footer_FontName = new string[1];
                string[] Report_Footer_FontSize = new string[1];
                string[] Report_Footer_FontStyle = new string[1];

                TopVal = "2";
                WidthVal = "155";
                HeightVal = "2";// "226,226,226,226";
                LeftVal = "2";
                AlignVal = "L";

                Report_Footer[0] = " ";
                //Report_Footer[1] = Convert.ToString(total_Qty);
                Report_Footer_FontName[0] = "Times New Roman";
                //Report_Footer_FontName[1] = "Times New Roman";
                Report_Footer_FontSize[0] = "10";
                //Report_Footer_FontSize[1] = "10";
                Report_Footer_FontStyle[0] = "B";
                //Report_Footer_FontStyle[1] = "B";
                MR.ReportFooterArrenge(Report_Footer, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Footer_FontName, Report_Footer_FontSize, Report_Footer_FontStyle);
                //====================================End===========================================

                //============================Details Columns Header============================================
                int Col_Count = dt1.Columns.Count;
                string[] Report_Columns_Header = new string[Col_Count];
                string[] Report_Columns_Header_FontName = new string[Col_Count];
                string[] Report_Columns_Header_FontSize = new string[Col_Count];
                string[] Report_Columns_Header_FontStyle = new string[Col_Count];



                if (CmbReport.SelectedIndex == 0)
                {
                    for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                    {
                        string ao = dt1.Columns[i].ToString();
                        //Report_Columns_Header[i] = ao+ "              ";

                        Report_Columns_Header[i] = ao + "                     ";
                    }
                }
                else
                {
                    for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                    {
                        string ao = dt1.Columns[i].ToString();
                        Report_Columns_Header[i] = ao + "                                       ";
                    }
                }

                for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                {
                    Report_Columns_Header_FontName[i] = "Times New Roman";
                    Report_Columns_Header_FontSize[i] = "8";
                    Report_Columns_Header_FontStyle[i] = "R";
                }

                int Head_width = 0;
                if (Head_Cou == 0)
                {
                    TopVal = "1,1,1";
                    WidthVal = "6,40,10";
                    HeightVal = "4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0";
                    AlignVal = "L,L,L";
                    Head_width = 274;

                }
                else if (Head_Cou == 1)
                {
                    TopVal = "1,1,1,1";
                    WidthVal = "6,40,10,14";
                    HeightVal = "4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0";
                    AlignVal = "L,M,L,L";
                    Head_width = 260;
                }
                else if (Head_Cou == 2)
                {
                    TopVal = "1,1,1,1,1";
                    WidthVal = "6,40,10,14,14";
                    HeightVal = "4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0";
                    AlignVal = "L,L,L,L,L";
                    Head_width = 246;
                }
                else if (Head_Cou == 3)
                {
                    TopVal = "1,1,1,1,1,1";
                    WidthVal = "6,40,10,14,14,14";
                    HeightVal = "4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L";
                    Head_width = 232;

                }
                else if (Head_Cou == 4)
                {
                    TopVal = "1,1,1,1,1,1,1";
                    WidthVal = "6,40,10,14,14,14,14";
                    HeightVal = "4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L";
                    Head_width = 218;
                }
                else if (Head_Cou == 5)
                {
                    TopVal = "1,1,1,1,1,1";
                    WidthVal = "8,65,75,60,60";
                    HeightVal = "4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0";
                    AlignVal = "L,L,L,L,L";
                    Head_width = 300;
                }

                else if (Head_Cou == 6)
                {
                    TopVal = "1,1,1,1,1,1";
                    WidthVal = "8,70,40,40,40,40";
                    HeightVal = "4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L";
                    Head_width = 300;
                }
                else if (Head_Cou == 8)
                {
                    TopVal = "1,1,1,1,1,1,1,1,1";
                    WidthVal = "6,60,40,40,40,40,40,40,40";
                    HeightVal = "4,4,4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L,L";
                    Head_width = 310;
                }

                else if (Head_Cou == 9)
                {
                    TopVal = "1,1,1,1,1,1,1,1,1";
                    WidthVal = "6,50,25,25,25,25,25,25,25";
                    HeightVal = "4,4,4,4,4,4,4,4,4";// "226,226,226,226";
                    LeftVal = "2,0,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L,L";
                    Head_width = 230;
                }
               

                    //int a = dt.Columns.Count;
                    //a = a - (Head_Cou + 3);
                    //int ab = Head_width / a;
                    //Head_Cou = Head_Cou + 3;
                    //for (int i = Head_Cou; i <= dt.Columns.Count - 1; i++)
                    //{
                    //    TopVal = TopVal + "," + 1;
                    //    WidthVal = WidthVal + "," +ab;
                    //    HeightVal = HeightVal + "," + 4;
                    //    LeftVal = LeftVal + "," + 0;
                    //    AlignVal = AlignVal + "," + "R";
                    //}


                    //int a = dt.Columns.Count;
                    //a = Head_Cou ;
                    //int ab = Head_width / a;
                    ////Head_Cou = Head_Cou ;
                    //for (int i = 0; i <= dt.Columns.Count - 1; i++)
                    //{
                    //    TopVal = TopVal + "," + 1;
                    //    WidthVal = WidthVal + "," + ab;
                    //    HeightVal = HeightVal + "," + 4;
                    //    LeftVal = LeftVal + "," + 0;
                    //    AlignVal = AlignVal + "," + "R";
                    //}      

                MR.DetailsColumnsHeaderArrenge(Report_Columns_Header, Report_Columns_Header_FontName, Report_Columns_Header_FontSize, Report_Columns_Header_FontStyle);
                MR.DetailsColumnsArrenge(TopVal, WidthVal, HeightVal, LeftVal, AlignVal);

                //===================================End====================================================
                if (flug == 1)
                {
                    MR.Graphic_Preview(dt_Sal_Pur_Reg_Final);
                    MR.Show();
                }
                else
                    MR.Graphic_Print(dt_Sal_Pur_Reg_Final);
            }
            catch { }
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


     
        public int get_LocationID(string name)
        {
            
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select Location_ID from tbl_Emp_Location where Location_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public int get_CompID(string name)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            string s = " select GCODE  from Company where CO_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }


        private void cmbsalstruc_DropDownClosed(object sender, EventArgs e)
        {
            
            if (cmbsalstruc.Text=="")
            {
                ERPMessageBox.ERPMessage.Show("Location  must be entered");
                return ;
            }
            else
            {
                Locations = Convert.ToString(get_LocationID(cmbsalstruc.Text));
            }
        }

        private void Retrive_Data()
        {

            string Str_ErHead_basic="";
            DataTable ErHead_basic = clsDataAccess.RunQDTbl("select top 1  SalaryHead_Short from tbl_Employee_ErnSalaryHead");
            Str_ErHead_basic = ErHead_basic.Rows[0][0].ToString ();
            
            string Str_PF="";
            DataTable data_PF = clsDataAccess.RunQDTbl("select SalaryHead_Short from tbl_Employee_DeductionSalayHead d,tbl_Employee_Assign_SalStructure e,tbl_Employee_Link_SalaryStructure l where d.SlNo=e.SAL_HEAD and e.PF_PER=1 and e.SAL_STRUCT=l.SalaryStructure_ID and Location_ID = '" + get_LocationID(cmbsalstruc.Text) + "'");
            Str_PF = data_PF.Rows[0][0].ToString();

            Boolean flug_deduction = false;
            //string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as 'Employee Id',em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as 'Employee Name' ,(select pf.PF_Code from Companywiseid_Relation pf where pf.location_id='" + get_LocationID(cmbsalstruc.Text) + "' ) as 'PF NO',sm.Emp_Id as ID,'" + cmbsalstruc.Text + "' as 'Location',sm.desig_id  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");

            if (tot_employ.Rows.Count > 0)
            {
                DataTable salary_details = clsDataAccess.RunQDTbl("select * from (SELECT EmpId,SalId,TableName,Slno,Amount,0 as Designation_id FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' union SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + get_LocationID(cmbsalstruc.Text) + "') main order by Designation_id,Slno");
                DataView dv = new DataView(salary_details);
                int table_count = tot_employ.Columns.Count;

                tot_employ.Rows.Add();
                int dt_count = tot_employ.Rows.Count;
                tot_employ.Rows.Add();
                tot_employ.Rows.Add();

                int counter = 0;

                tot_employ.Columns.Add("Employer (3.67%)", typeof(string));
                tot_employ.Columns.Add("EPFBasic", typeof(string));
                tot_employ.Columns.Add("EPS(8.33%)", typeof(string));

                for (int i = 0; i <= tot_employ.Rows.Count - 4; i++)
                {
                    dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["desig_id"] + "'";

                    for (int j = 0; j <= dv.Count - 1; j++)
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                                tot_employ.Rows[dt_count][1] = "                Total :";

                            if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                            {
                                table_count = tot_employ.Columns.Count;
                                flug_deduction = true;
                                counter = j;
                            }

                            string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");

                            if (Salary_Head == Str_PF)
                            {
                                tot_employ.Columns.Add(Salary_Head, typeof(string));
                                tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                                tot_employ.Rows[dt_count - 1][Salary_Head] = "========";
                                tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                            }
                            else if (Salary_Head == Str_ErHead_basic)
                            {
                                tot_employ.Columns.Add(Salary_Head, typeof(string));
                                tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                                if (Convert.ToDouble((tot_employ.Rows[i][Salary_Head])) > 15000)
                                {
                                    tot_employ.Rows[i]["EPFBasic"] = 15000;
                                }
                                else
                                {
                                    tot_employ.Rows[i]["EPFBasic"] = Convert.ToDouble(tot_employ.Rows[i][Salary_Head]);
                                }

                                tot_employ.Rows[i]["EPS(8.33%)"] = string.Format("{0:F}", Convert.ToDouble(System.Math.Round((((Convert.ToDouble(tot_employ.Rows[i][Salary_Head])) * 8.33) / 100), 0)));
                                tot_employ.Rows[dt_count - 1][Salary_Head] = "========";
                                tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                            }

                        }
                        else
                        {
                            string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                            if (Salary_Head == Str_PF)
                            {
                                tot_employ.Rows[i][j + 8] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count][j + 8] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][j + 8]) + Convert.ToDouble(dv[j]["Amount"]));
                            }
                            else if (Salary_Head == Str_ErHead_basic)
                            {
                                tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                                if (Convert.ToDouble((tot_employ.Rows[i][Salary_Head])) > 15000)
                                {
                                    tot_employ.Rows[i]["EPFBasic"] = 15000;
                                }
                                else
                                {
                                    tot_employ.Rows[i]["EPFBasic"] = Convert.ToDouble(tot_employ.Rows[i][Salary_Head]);
                                }

                                tot_employ.Rows[i]["EPS(8.33%)"] = string.Format("{0:F}", Convert.ToDouble(System.Math.Round((((Convert.ToDouble(tot_employ.Rows[i][Salary_Head])) * 8.33) / 100), 0)));


                                tot_employ.Rows[dt_count - 1][Salary_Head] = "========";
                                tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count + 1][Salary_Head] = "========";
                            }

                        }
                    }

                    tot_employ.Rows[dt_count - 1]["BA"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["EPFBasic"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["EPS(8.33%)"] = "---------------";
                    tot_employ.Rows[dt_count - 1]["Employer (3.67%)"] = "---------------";


                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["BA"]) == false)
                        tot_employ.Rows[dt_count]["BA"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPFBasic"]) == false)
                        tot_employ.Rows[dt_count]["EPFBasic"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["EPS(8.33%)"]) == false)
                        tot_employ.Rows[dt_count]["EPS(8.33%)"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["Employer (3.67%)"]) == false)
                        tot_employ.Rows[dt_count]["Employer (3.67%)"] = 0;

                    tot_employ.Rows[dt_count + 1]["BA"] = "========";
                    tot_employ.Rows[dt_count + 1]["EPFBasic"] = "========";
                    tot_employ.Rows[dt_count + 1]["EPS(8.33%)"] = "========";
                    tot_employ.Rows[dt_count + 1]["Employer (3.67%)"] = "========";

                    tot_employ.Rows[i]["sl"] = i + 1;

                    tot_employ.Rows[dt_count]["BA"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["BA"]) + Convert.ToDouble(tot_employ.Rows[i]["BA"]));
                    tot_employ.Rows[dt_count]["EPFBasic"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPFBasic"]) + Convert.ToDouble(tot_employ.Rows[i]["EPFBasic"]));
                    tot_employ.Rows[dt_count]["EPS(8.33%)"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["EPS(8.33%)"]) + Convert.ToDouble(tot_employ.Rows[i]["EPS(8.33%)"]));
                    tot_employ.Rows[i]["Employer (3.67%)"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[i]["PF"]) - Convert.ToDouble(tot_employ.Rows[i]["EPS(8.33%)"]));
                    tot_employ.Rows[dt_count]["Employer (3.67%)"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["Employer (3.67%)"]) + Convert.ToDouble(tot_employ.Rows[i]["Employer (3.67%)"]));

                }

                tot_employ.Columns["BA"].SetOrdinal(table_count - 1);
                tot_employ.Columns["EPFBasic"].SetOrdinal(tot_employ.Columns.Count - 1);
                tot_employ.Columns["EPS(8.33%)"].SetOrdinal(tot_employ.Columns.Count - 1);

                tot_employ.Columns.Remove("ID");
                tot_employ.Columns.Remove("desig_id");

                tot_employ.Columns["BA"].SetOrdinal(4);
                tot_employ.Columns["EPFBasic"].SetOrdinal(5);
                tot_employ.Columns["PF"].SetOrdinal(6);
                tot_employ.Columns["EPS(8.33%)"].SetOrdinal(7);
                tot_employ.Columns["Employer (3.67%)"].SetOrdinal(8);

                tot_employ.Columns["PF"].ColumnName = "Employee Contribution (12%)";

                dt = tot_employ.Copy();

                dt.AcceptChanges();
                Head_Cou = dt.Columns.Count;
            }
            

           

        }

    

        private void Retrive_DataESI()
        {

            string Str_ESI = "";
            string Str_ESI_SLNO = "";

            DataTable data_ESI = clsDataAccess.RunQDTbl("select d.SalaryHead_Short,d.SLNO  from tbl_Employee_DeductionSalayHead d,tbl_Employee_Assign_SalStructure e,tbl_Employee_Link_SalaryStructure l where d.SlNo=e.SAL_HEAD and e.pt=1 and e.SAL_STRUCT=l.SalaryStructure_ID and l.Location_ID = '" + get_LocationID(cmbsalstruc.Text) + "'");

            if (data_ESI.Rows.Count > 0)
            {
                Str_ESI = data_ESI.Rows[0][0].ToString();
                Str_ESI_SLNO = data_ESI.Rows[0][1].ToString();

            }
            else
            {
                Str_ESI = "";
                ERPMessageBox.ERPMessage.Show("There is no PTAX Head in this Salary Structure");
                return;
            }

            Boolean flug_deduction = false;
          

            string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as 'SlNo',em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as 'Employee Name' ,sm.Emp_Id as ID,'" + cmbsalstruc.Text + "' as 'Location',cast(sm.TotalSal as numeric(18,0)) 'Gross Salary',sm.desig_id  FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");


            DataTable salary_details = clsDataAccess.RunQDTbl("select * from (SELECT EmpId,SalId,TableName,Slno,Amount,0 as Designation_id FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and tablename='tbl_Employee_DeductionSalayHead' and salid='" + Str_ESI_SLNO + "' union SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and tablename='tbl_Employee_DeductionSalayHead' and salid='" + Str_ESI_SLNO + "') main order by Designation_id,Slno");
            DataView dv = new DataView(salary_details);
           
            int table_count = tot_employ.Columns.Count;
            DataView d = new DataView(tot_employ);
            if (tot_employ.Rows.Count > 0)
            {
                tot_employ.Rows.Add();
                int dt_count = tot_employ.Rows.Count;
                tot_employ.Rows.Add();
                tot_employ.Rows.Add();

                int counter = 0;
                for (int i = 0; i <= tot_employ.Rows.Count - 4; i++)
                {
                    dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["desig_id"] + "'";

                    string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[0]["TableName"] + " where SlNo ='" + dv[0]["SalId"] + "'  ");
                    tot_employ.Rows[dt_count][3] = "                    Total :";
                    



                    if (i == 0)
                    {
                        if (Salary_Head == Str_ESI)
                        {
                            tot_employ.Columns.Add(Salary_Head, typeof(string));
                            tot_employ.Rows[i][Salary_Head] = dv[0]["Amount"];

                           
                            tot_employ.Rows[dt_count][Salary_Head] = dv[0]["Amount"];
                            
                        }
                    }
                    else
                    {

                       if (Salary_Head == Str_ESI)
                        {
                            tot_employ.Rows[i][Salary_Head] = dv[0]["Amount"];
                            tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:n}", Convert.ToDouble(tot_employ.Rows[dt_count][Str_ESI]) + Convert.ToDouble(dv[0]["Amount"]));
                        }
                    }

                    if (i == 0)
                    {
                        tot_employ.Rows[i]["Gross Salary"] = d[0]["Gross Salary"];

                    
                        tot_employ.Rows[dt_count]["Gross Salary"] = d[0]["Gross Salary"];
                 
                    }
                    else
                    {
                        tot_employ.Rows[i]["Gross Salary"] = d[i]["Gross Salary"];

                        //tot_employ.Rows[dt_count - 1]["Gross Salary"] = "";
                        tot_employ.Rows[dt_count]["Gross Salary"] = string.Format("{0:n}", Convert.ToDouble(tot_employ.Rows[dt_count]["Gross Salary"]) + Convert.ToDouble(d[i]["Gross Salary"]));
                        //tot_employ.Rows[dt_count + 1]["Gross Salary"] = "";
                    }

                    if (Salary_Head == Str_ESI)
                    {

                    if (Information.IsNumeric(tot_employ.Rows[dt_count][Str_ESI]) == false)
                        tot_employ.Rows[dt_count][Str_ESI] = 0;
                    }

            
                    if (Salary_Head == Str_ESI)
                    {
                            tot_employ.Rows[dt_count + 1][Str_ESI] = "";
                    }
                  
                    tot_employ.Rows[i]["SlNo"] = i + 1;

                }

                if (tot_employ.Columns.Contains(Str_ESI) == true)
                {
tot_employ.Columns[Str_ESI].SetOrdinal(table_count - 1);
                }

                tot_employ.Columns.Remove("desig_id");
                tot_employ.Columns.Remove("ID");

                if (tot_employ.Columns.Contains(Str_ESI) == true)
                {
 tot_employ.Columns[Str_ESI].SetOrdinal(4);
                }
               
                tot_employ.Columns["Gross Salary"].SetOrdinal(3);
              
                dt = tot_employ.Copy();

                dt.AcceptChanges();
                Head_Cou = dt.Columns.Count;

            }


          

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
               
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);

        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            Retrive_DataESI();

            if (dt.Rows.Count > 1)
            {
                System.Data.DataTable dtCloned = dt.Clone();
                dtCloned.AcceptChanges();
                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }
                dtCloned.AcceptChanges();

                //excel

                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                int iCol = 0;
                foreach (DataColumn c in dtCloned.Columns)
                {
                    iCol++;
                    excel.Cells[1, iCol] = c.ColumnName;
                }
                int iRow = 0;
                foreach (DataRow r in dtCloned.Rows)
                {
                    iRow++;
                    iCol = 0;
                    foreach (DataColumn c in dtCloned.Columns)
                    {
                        try
                        {
                            iCol++;
                            excel.Cells[iRow + 1, iCol] = r[c.ColumnName];
                        }
                        catch
                        {

                        }
                    }

                }
                object missing = System.Reflection.Missing.Value;

                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;

                ((Excel._Worksheet)worksheet).Activate();

                ((Excel._Application)excel).Quit();

                MessageBox.Show("Export To ExcelCompleted!", "Export");
            }
            else
            {
                MessageBox.Show("There is no Record to export to excel!", "Export");
            }

            dt.Dispose();
            dt.Clear();

            // excel
        }

        private void cmbsalstruc_DropDown_1(object sender, EventArgs e)
        {
            string Loc_sql = "select  l.Location_Name,l.Location_Id,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and (company_ID = '" + Company_id + "')";
            DataTable dt = clsDataAccess.RunQDTbl(Loc_sql);
            if (dt.Rows.Count > 0)
            {
                cmbsalstruc.LookUpTable = dt;
                cmbsalstruc.ReturnIndex = 1;

            }
        }

        private void cmbsalstruc_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbsalstruc.ReturnValue) == true)
                Location_Id = Convert.ToInt32(cmbsalstruc.ReturnValue);

        }

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {
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
        }

        private void rdb_Co_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Co.Checked == true)
            {
                cmbState.Enabled = true;
                cmbState.SelectedIndex = 0;
                cmbsalstruc.Text = "";
                cmbsalstruc.Enabled = false;
                
            }

            else if (rdb_Co.Checked==false)
            {
                cmbState.SelectedIndex = 0;
                cmbState.Enabled = false;
                cmbsalstruc.Enabled = true;
            }
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }

}