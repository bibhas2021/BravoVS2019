using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class PFReport3 : EDPComponent.FormBaseERP
    {
        public PFReport3()
        {
            InitializeComponent();
        }
                       

        private void Extractcmd_Click(object sender, EventArgs e)
        {
            //PFRepDtGridv
            //clsDataAccess.ConnectDB(); Month='" + Monthcombo.Text + "' AND

            

            DataTable DtSetting = clsDataAccess.RunQDTbl("SELECT * from tbl_Employee_PFESIRate" +
                " WHERE Year='" + SeasonCombo.Text + "'");

            if (DtSetting.Rows.Count < 1)
            {
                MessageBox.Show("There is no settings found for this month...");
                PFRepDtGridv.DataSource = DtSetting;
                return;
            }

              
            DataTable DtEmpSal = clsDataAccess.RunQDTbl("SELECT * FROM tbl_Employee_SalaryMast " +
                "INNER JOIN tbl_Employee_Mast ON tbl_Employee_Mast.ID=tbl_Employee_SalaryMast.Emp_Id" +
                " WHERE tbl_Employee_SalaryMast.Month='" + Monthcombo.Text +
                "' AND tbl_Employee_SalaryMast.Session='" + SeasonCombo.Text + "'");
            
            if (DtEmpSal.Rows.Count < 1)
            {
                MessageBox.Show("No Record found");
                return;
            }

            DataTable DtExec = new DataTable();
            DataColumn DC = new DataColumn();
            DC.DataType = System.Type.GetType("System.String");
            DC.AllowDBNull = false;
            DC.Caption = "Employee_Name";
            DC.ColumnName = "Employee Name";
            DC.DefaultValue = 25;

            DtExec.Columns.Add(DC);

            DC = new DataColumn();
            DC.DataType = System.Type.GetType("System.Decimal");
            DC.AllowDBNull = false;
            DC.Caption = "Amt_Due_For_PF";
            DC.ColumnName = "Amt. Due For PF";
            DC.DefaultValue = 25;

            DtExec.Columns.Add(DC);

            DC = new DataColumn();
            DC.DataType = System.Type.GetType("System.Decimal");
            DC.AllowDBNull = false;
            DC.Caption = "Teachers_Contri";
            DC.ColumnName = "Teachers Contri.";
            DC.DefaultValue = 25;

            DtExec.Columns.Add(DC);

            DC = new DataColumn();
            DC.DataType = System.Type.GetType("System.Decimal");
            DC.AllowDBNull = false;
            DC.Caption = "Pension" + "\n" + DtSetting.Rows[0]["PFCMPEPS"].ToString();
            DC.ColumnName = "Pension";
            DC.DefaultValue = 25;

            DtExec.Columns.Add(DC);

            DC = new DataColumn();
            DC.DataType = System.Type.GetType("System.Decimal");
            DC.AllowDBNull = false;
            DC.Caption = "Employers_Contri";
            DC.ColumnName = "Employers Contri.";
            DC.DefaultValue = 25;

            DtExec.Columns.Add(DC);

            DC = new DataColumn();
            DC.DataType = System.Type.GetType("System.Decimal");
            DC.AllowDBNull = false;
            DC.Caption = "DUe_EDLI_Pension";
            DC.ColumnName = "Amount Due for EDLI & Pension";
            DC.DefaultValue = 25;

            DtExec.Columns.Add(DC);

            DC = new DataColumn();
            DC.DataType = System.Type.GetType("System.Decimal");
            DC.AllowDBNull = false;
            DC.Caption = "Amount_Exc.";
            DC.ColumnName = "Amount Due For EDLI";
            DC.DefaultValue = 25;

            DtExec.Columns.Add(DC);

            DC = new DataColumn();
            DC.DataType = System.Type.GetType("System.Decimal");
            DC.AllowDBNull = false;
            DC.Caption = "EDLI_Conti.";
            DC.ColumnName = "EDLI Conti";
            DC.DefaultValue = 25;

            DtExec.Columns.Add(DC);

            DC = new DataColumn();
            DC.DataType = System.Type.GetType("System.Decimal");
            DC.AllowDBNull = false;
            DC.Caption = "EDLI_Admin";
            DC.ColumnName = "EDLI Admin";
            DC.DefaultValue = 25;

            DtExec.Columns.Add(DC);

            DC = new DataColumn();
            DC.DataType = System.Type.GetType("System.Decimal");
            DC.AllowDBNull = false;
            DC.Caption = "Ins._Charge";
            DC.ColumnName = "Ins. Charge";
            DC.DefaultValue = 25;

            DtExec.Columns.Add(DC);



            DataRow DtRw;// = new DataRow();
            int Cnt=0;


            while (Cnt <= DtEmpSal.Rows.Count - 1)
            {
                
                DtRw = DtExec.NewRow();
                DtRw[0] = DtEmpSal.Rows[0][19].ToString() +" " + DtEmpSal.Rows[0][20].ToString() + " " + DtEmpSal.Rows[0][21].ToString() + " " + DtEmpSal.Rows[0][22].ToString();
                DtRw[1] = DtEmpSal.Rows[0]["PFDue"].ToString();
                DtRw[2] = Convert.ToDouble(DtEmpSal.Rows[0][13].ToString()) * Convert.ToDouble(DtSetting.Rows[0]["PFEMP"].ToString()) /100 ;
                DtRw[3] = Convert.ToDouble(DtEmpSal.Rows[0][13].ToString()) * Convert.ToDouble(DtSetting.Rows[0]["PFCMPEPS"].ToString()) / 100;
                DtRw[4] = Convert.ToDouble(DtRw[1]) - Convert.ToDouble(DtRw[3]);
                DtRw[5] = DtSetting.Rows[0]["PFCUTOFF"].ToString(); //Convert.ToDouble(DtRw[1]) - Convert.ToDouble(DtRw[4]);
                DtRw[6] = Convert.ToDouble(DtRw[4]) * Convert.ToDouble(DtSetting.Rows[0]["PFACC21"].ToString());
                DtRw[7] = Convert.ToDouble(DtRw[4]) * Convert.ToDouble(DtSetting.Rows[0]["PFACC22"].ToString());
                DtRw[8] = Convert.ToDouble(DtRw[4]) * Convert.ToDouble(DtSetting.Rows[0]["PFACC2"].ToString());
                DtRw[9] = Convert.ToDouble(DtRw[3]) + Convert.ToDouble(DtRw[4]) + Convert.ToDouble(DtRw[7]) - Convert.ToDouble(DtRw[8]) + Convert.ToDouble(DtRw[9]);// - Convert.ToDouble(DtRw[2]); 
                //DtRw[10] = DtEmpSal.Rows[0][13].ToString();

                //DtRw[0]= DtEmpSal.

                DtExec.Rows.Add(DtRw);
                Cnt++;
            }

            PFRepDtGridv.DataSource = DtExec;




        }

        public void SeasonExtract()
        {

            DataTable DtEmpSal = clsDataAccess.RunQDTbl("SELECT [Month] " +
                " FROM tbl_Employee_SalaryMast Group By  [Month]");

            for (int Cnt = 0; Cnt < DtEmpSal.Rows.Count ; Cnt++)
            {
                Monthcombo.Items.Add(DtEmpSal.Rows[Cnt][0].ToString());
            }
            DtEmpSal = clsDataAccess.RunQDTbl("SELECT Session " +
                " FROM tbl_Employee_SalaryMast Group By Session");

            for (int Cnt = 0; Cnt < DtEmpSal.Rows.Count ; Cnt++)
            {
                SeasonCombo.Items.Add(DtEmpSal.Rows[Cnt][0].ToString());

            }


        }

        private void PFReport3_Load(object sender, EventArgs e)
        {
            SeasonExtract();
        }
    }
}