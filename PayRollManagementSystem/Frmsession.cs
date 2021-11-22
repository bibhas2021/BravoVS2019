using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using EDPComponent;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class Frmsession : Form// FormBaseERP
    {
        public Frmsession()
        {
            InitializeComponent();
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            int sb = 0, sfico = 0;
            string concate = "";
            int dateto = Convert.ToInt32(Convert.ToDateTime(dtpto.Text.Trim()).Year);
            int datefrom = Convert.ToInt32(Convert.ToDateTime(dtpfrom.Text.Trim()).Year);
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dtselectto = clsDataAccess.RunQDTbl("Select *  from tbl_Session where session=(select max(session)  from tbl_Session) ");

            try
            {
                if (txtSessionname.Text.Trim() == "")
                {
                    MessageBox.Show("Session Name Cannot Blank");
                    return;
                }

                if (Convert.ToDateTime(dtpfrom.Text) > Convert.ToDateTime(dtpto.Text))
                {
                    sb = 1;
                    MessageBox.Show("From date can't be greater than todate");
                    return;
                }
                else if (dtselectto.Rows.Count > 0)
                {
                    //string[] X = (Convert.ToString(dtselectto.Rows[0][3])).Split('-');
                    //concate = X[1].Trim() + "-" + Convert.ToString((Convert.ToInt32(X[1]) + 1)).Trim();

                    if ((Convert.ToDateTime(dtselectto.Rows[0]["ToDate"])) > Convert.ToDateTime(dtpfrom.Text))
                    {
                        sb = 1;
                        MessageBox.Show("The FromDate year'" + datefrom + "' Already Exist ");
                        return;

                    }

                }
                DataTable dublicate_name = clsDataAccess.RunQDTbl("Select * from tbl_Session where session ='" + txtSessionname.Text + "'");
                if (dublicate_name.Rows.Count > 0)
                    if (Information.IsDBNull(dublicate_name.Rows[0][3]) == false)
                    {
                        MessageBox.Show("The Session Name Already Exist ");
                        return;
                    }

                DataTable dtsfi = clsDataAccess.RunQDTbl("Select max(SFicode) from tbl_Session");
                if (dtsfi.Rows.Count > 0)
                {
                    if (Information.IsDBNull(dtsfi.Rows[0][0]) == false)
                        sfico = Convert.ToInt32(dtsfi.Rows[0][0]);
                }
                concate = txtSessionname.Text;
                clsDataAccess.RunNQwithStatus("insert into tbl_Session(FromDate,SFicode,ToDate,Session)values('" + edpcom.getSqlDateStr(dtpfrom.Value) + "','" + (sfico + 1) + "','" + edpcom.getSqlDateStr(dtpto.Value) + "','" + concate + "')");
                MessageBox.Show("Session " + concate + " Successfully insert");
                this.Close();

            }
            catch
            {
                MessageBox.Show("Session Creation Problem");
            }
        }

        private void Frmsession_Load(object sender, EventArgs e)
        {
            //this.HeaderText = "Create Session";
            DataTable session_name = clsDataAccess.RunQDTbl("Select * from tbl_Session order by SFiCode desc");
            if (session_name.Rows.Count > 0)
            {
                if (Information.IsDBNull(session_name.Rows[0][0]) == false)
                {
                    DateTime fromda = Convert.ToDateTime(session_name.Rows[0]["FromDate"]);
                    dtpfrom.Value = fromda;
                    fromda = Convert.ToDateTime(session_name.Rows[0]["ToDate"]);
                    dtpto.Value = fromda;
                    txtSessionname.Text = Convert.ToString(session_name.Rows[0]["Session"]);
                }
                else
                {
                    string year = System.DateTime.Now.Year.ToString();
                    dtpfrom.Value = Convert.ToDateTime("01.01." + year);
                    dtpto.Value = Convert.ToDateTime("31.12." + year);
                }
            }
        }
    }
}
