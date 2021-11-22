using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PayRollManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void employeeJoiningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpJoining objempjoin = new EmpJoining();
            objempjoin.Show();
        }

        private void salaryStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee_Salary_Structure objempsalarystruct = new Employee_Salary_Structure();
            objempsalarystruct.Show();
        }

        private void salaryHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salary_Head objempsalaryhead = new Salary_Head();
            objempsalaryhead.Show();
        }
    }
}