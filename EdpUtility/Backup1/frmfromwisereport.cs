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

namespace Utility
{
    public partial class frmfromwisereport : EDPComponent.FormBase
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
        public frmfromwisereport()
        {
            InitializeComponent();
        }

        private void frmfromwisereport_Load(object sender, EventArgs e)
        {
            lblFrmName.Visible = false;
            txtSession.Visible = false;
            txtSession.ReadOnly = true;
            lblForm1.Visible = false;
            txtSession1.Visible = false;
            txtSession1.ReadOnly = true;
            timer1.Start();
            lblDate.Text = DateTime.Today.ToShortDateString();
            this.HeaderText = "Formwise Report";
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
                dtSession.Columns.Add("Form No", typeof(string));
                dtSession.Columns.Add("Starting Date", typeof(string));
                dtSession.Columns.Add("Ending Date", typeof(string));
            }
            catch
            {
            }
            {
                lblMachineName.Text = Environment.MachineName.ToString();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnInv_Click(object sender, EventArgs e)
        {

            try
            {
               
                arr.Clear();
                string st = "select form_name , min(date_from) as starting_time , max(date_to) as Ending_time from midaslog   where midaslog.Log_Gcode='" + edpcom.PCURRENT_GCODE + "' and midaslog.Log_Ucode='" + edpcom.PCURRENT_USER + "' and midaslog.Log_Ccode='" + edpcom.CurrentFicode + "' group by form_name";
               
                EDPCommon.MLOV_EDP(st, "Form Name", "Select Form Name", "List of Form Name ", 0, "INV",0); //and midaslog.Log_Ucode='" + edpcom.CurrentFicode + "'
                arr = EDPCommon.arr_mod;
                if (arr.Count > 0)
                {
                    getcode.Clear();
                    arr = EDPCommon.arr_mod;
                    getcode = EDPCommon.get_code;
                    getMaxTime = EDPCommon.Hsdtss;
                    dtSession.Clear();
                    string sessionCode = null;
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
                        if (i != arr.Count - 1)
                            sessionCode += arr[i].ToString() + ",";
                        else
                            sessionCode += arr[i].ToString();

                    }
                    dgvShow.DataSource = dtSession;
                    dgvShow.Columns[0].Width = 140;
                    dgvShow.Columns[1].Width = 155;
                    dgvShow.Columns[2].Width = 155;
                    //  dgvSessionWise.DataSource = this.getFormNameThroughSessionNo(sessionCode);

                    dgvShow_CellDoubleClick(sender, new DataGridViewCellEventArgs(0, 0));

                  
                }

            }

            catch
            {
            }
        }

        private void dgvShow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            dx.Rows.Clear();
            lblFrmName.Visible = true;
            txtSession.Visible = true;
            txtSession1.Visible = true;
            lblForm1.Visible = true;
            lblFrmName.Text = "";
            txtSession.Text = "";
            string strSQL = "select distinct form_name, Session_no from midaslog where form_name='" + (dgvShow.CurrentRow.Cells[0].Value.ToString().Trim()) + "'";
            dx = RunQDTbl(strSQL);
            if (dx.Rows.Count > 0)
            {
                lblFrmName.Text =  Convert.ToString(dx.Rows[0][0]);
                for (int a = 0; a < dx.Rows.Count; a++)
                {
                    txtSession.Text = txtSession.Text+ Convert.ToString(dx.Rows[a][1]);
                    if (a != dx.Rows.Count - 1)
                        txtSession.Text = txtSession.Text + ",";
                }
            }
                
            

        }

       
       

        
    }
}




