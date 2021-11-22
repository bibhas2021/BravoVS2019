using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmCheque_print : Form
    {
        public frmCheque_print()
        {
            InitializeComponent();
        }

        private void frmCheque_print_Load(object sender, EventArgs e)
        {
            try
            {
                MidasReport.Form1 f1 = new MidasReport.Form1();
                f1.ChequeReport();
                f1.Show();

            }
            catch { }
        }
    }
}
