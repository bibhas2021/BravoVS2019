using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Edpcom;
using System.Collections;
using Microsoft.VisualBasic;
//using Investment_Report;

namespace Utility
{
    public partial class Sessionwise_Report : EDPComponent.FormBase
    {
        
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        ArrayList arr = new ArrayList();
        ArrayList arrpcode = new ArrayList();
        Hashtable getcode = new Hashtable();
        Hashtable getMaxTime = new Hashtable();
        DataTable dtSession = new DataTable();
        DataTable dx = new DataTable();
        public Sessionwise_Report()
        {
            InitializeComponent();
        }
        private void Sessionwise_Report_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Text = DateTime.Today.ToShortDateString();
            this.HeaderText = "Sessionwise Report";
            this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            groupBox1.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            groupBox2.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);

            //******************************companyName & financial year***********************************//
            {
                try
                {
                    lblComName.Text = Convert.ToString(edpcom.CURRENT_COMPANY);

                    string FincYrQry = "select ficodegen.start_Date, ficodegen.end_date from ficodegen where ficodegen.ficode='" + edpcom.CurrentFicode + "' ";
                    DataTable dtFincYr = RunQDTbl(FincYrQry);
                    lblFincYrStDt.Text = Convert.ToDateTime(dtFincYr.Rows[0][0]).ToShortDateString();
                    lblFincYrEnDt.Text = Convert.ToDateTime(dtFincYr.Rows[0][1]).ToShortDateString();

                }
                catch
                {
                }
            }
           
            try
            {
                dtSession.Columns.Add("Session No", typeof(string));
                dtSession.Columns.Add("Starting Time", typeof(string));
                dtSession.Columns.Add("Ending Time", typeof(string));
            }
            catch
            { 
            }
            { 
            lblMachineName.Text=Environment.MachineName.ToString();
            lblUserName.Text = edpcom.PCURRENT_USER.ToString();               
            }
        }

       public static DataTable RunQDTbl(String strSql)
        {
            SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MidasGold;Data Source=.\\SQLEXPRESS");

            conn.Open();
            SqlDataAdapter dtAdap = new SqlDataAdapter(strSql, conn);

            DataTable dtTbl = new DataTable();

            SqlCommand cmd = new SqlCommand(strSql);
            cmd.Connection = conn;
            dtAdap.SelectCommand = cmd;

            try
            {


                cmd = new SqlCommand(strSql);
                cmd.Connection = conn;
                dtAdap.SelectCommand = cmd;

                dtAdap.Fill(dtTbl);
                //DisconnectDB();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return dtTbl;
        }

        private void btnInv_Click(object sender, EventArgs e)
        {

            try
                {
                //    string sessionQry = "select distinct session_no from midaslog order by session_no";
                //DataTable dt
                    //lbInv.Items.Clear();
                    //Pcode_sl = null;
                    //getcode.Clear();
                    //inv_sl = null;
                    arr.Clear();
                    string st = "select session_no , min(date_from) , max(date_to) from midaslog where midaslog.Log_Gcode='" + edpcom.PCURRENT_GCODE + "' and midaslog.Log_Ucode='" + edpcom.PCURRENT_USER + "' and midaslog.Log_Ccode='" + edpcom.CurrentFicode + "'  group by session_no order by session_no "; //-- where Ficode='" + edpcom.CurrentFicode + "' and Itype='I' and icode IN (1,2)";
                    EDPCommon.MLOV_EDP(st, "Session No", "Select Session No", "List of Session ", 0, "INV",0); //and midaslog.Log_Ucode='" + edpcom.CurrentFicode + "'
                    arr = EDPCommon.arr_mod;
                    if (arr.Count > 0)
                   
                    {                        
                        getcode.Clear();
                        arr = EDPCommon.arr_mod;
                        getcode = EDPCommon.get_code;
                        getMaxTime = EDPCommon.Hsdtss;
                        dtSession.Clear();
                        string sessionCode=null;
                        for (int i = 0; i <= (arr.Count - 1); i++)
                        {
                            dtSession.Rows.Add();
                            dtSession.Rows[dtSession.Rows.Count - 1][0] = arr[i].ToString();
                            dtSession.Rows[dtSession.Rows.Count - 1][1] = getcode[i].ToString();
                            if (getMaxTime[i].ToString().Trim() == "")
                                dtSession.Rows[dtSession.Rows.Count - 1][2] = "Ending time is not found";
                            else
                                dtSession.Rows[dtSession.Rows.Count - 1][2] = getMaxTime[i].ToString();
                            //dtSession.Add(arr[i].ToString() + "     " + getcode[i].ToString() + "     " + getMaxTime[i].ToString());
                            if (i!=arr.Count-1)
                                sessionCode+=arr[i].ToString()+",";
                            else
                                sessionCode+=arr[i].ToString();
                                                          
                        }
                        dgvShow.DataSource = dtSession;
                        dgvShow.Columns[0].Width = 140;
                        dgvShow.Columns[1].Width = 155;
                        dgvShow.Columns[2].Width = 155;
                      //  dgvSessionWise.DataSource = this.getFormNameThroughSessionNo(sessionCode);
                                                
                        dgvShow_CellDoubleClick_1(sender, new DataGridViewCellEventArgs(0, 0));

                        //dx.Rows.Clear();
                        //string strSQL = "SELECT Form_Name as[Form Name], COUNT(Form_Name) as [Number] FROM MidasLog WHERE Session_No ='" + dgvShow.CurrentRow.Cells[0].Value + "' Group By Form_Name";//and midaslog.Log_Gcode='" + edpcom.PCURRENT_GCODE + "' and midaslog.Log_Ucode='"+edpcom.PCURRENT_USER+"' and midaslog.Log_Ccode='"+edpcom.CurrentFicode+"'
                        //dx = RunQDTbl(strSQL);
                        //dgvSessionWise.DataSource = dx;
                       

                    }
                }
                
            catch
                {
                }
            }
       // protected DataTable getFormNameThroughSessionNo(string pSessionCode)
        //{
            //string strSQL = "SELECT Form_Name as[Form Name], COUNT(Form_Name) as [Number] FROM MidasLog WHERE Session_No IN(" + pSessionCode + ")  Group By Form_Name";//and midaslog.Log_Gcode='" + edpcom.PCURRENT_GCODE + "' and midaslog.Log_Ucode='"+edpcom.PCURRENT_USER+"' and midaslog.Log_Ccode='"+edpcom.CurrentFicode+"'
            ////string strSQL = "SELECT Form_Name as[Form Name], COUNT(Form_Name) as [Number] FROM MidasLog WHERE Session_No ='" + dgvShow.CurrentRow.Cells[0].Value + "' Group By Form_Name";//and midaslog.Log_Gcode='" + edpcom.PCURRENT_GCODE + "' and midaslog.Log_Ucode='"+edpcom.PCURRENT_USER+"' and midaslog.Log_Ccode='"+edpcom.CurrentFicode+"'
            //dgvShow.DataSource = RunQDTbl(strSQL);

            //return RunQDTbl(strSQL);

            ////    //and midaslog.Log_Ucode='" + edpcom.CurrentFicode + "'
            ////    //and midaslog.Log_Gcode='" + edpcom.PCURRENT_GCODE + "' and midaslog.Log_Ucode='" + edpcom.CurrentFicode + "'
            //    //SELECT midaslog.form_name, count(form_name) from midaslog where session_no in('arr')  group by form_name  
            //    //DataTable dtSession = new DataTable(strSQL);

        //}
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }
//*******************************************************SB********************************************************
       

        private void dgvShow_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            dx.Rows.Clear();
            string strSQL = "SELECT Form_Name as[Form Name], COUNT(Form_Name) as [Number] FROM MidasLog WHERE Session_No ='" + dgvShow.CurrentRow.Cells[0].Value + "' Group By Form_Name";//and midaslog.Log_Gcode='" + edpcom.PCURRENT_GCODE + "' and midaslog.Log_Ucode='"+edpcom.PCURRENT_USER+"' and midaslog.Log_Ccode='"+edpcom.CurrentFicode+"'
           dx = RunQDTbl(strSQL);
            dgvSessionWise.DataSource = dx;

            dgvSessionWise.Columns[0].Width = 225;
            dgvSessionWise.Columns[1].Width = 230;
        }

        }
          
        }

       
       
        
    



//####################################################...SS...###################################################\\