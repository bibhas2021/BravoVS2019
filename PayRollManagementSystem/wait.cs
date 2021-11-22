using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class wait : Form
    {
        public wait()
        {
            InitializeComponent();
        }
        int b;
        private void wait_Load(object sender, EventArgs e)
        {
            b = 1;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pgb1.Value >= pgb1.Maximum)
            {
                pgb1.Value = 1;
                timer1.Enabled = false;
                this.Close();
            }
            else
            {
                if (b == 1)
                {
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label2.Visible = true;
                    label2.BackColor = Color.Maroon;
                    b = 2;
                }
                else if (b==2)
                {
                    label2.Visible = false;
                    label4.Visible = false;
                    label3.Visible = true;
                    label5.Visible = false;
                    label6.Visible = false;
                    //label1.Visible = false;
                    label3.BackColor = Color.Blue;
                    b = 3;
                }
                else if (b == 3)
                {
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = true;
                    label5.Visible = false;
                    label6.Visible = false;
                    //label1.Visible = true;
                    label4.BackColor = Color.Yellow;
                    b = 4;
                }
                else if (b == 4)
                {
                    label2.Visible = false;
                    label4.Visible = false;
                    label5.Visible = true;
                    label3.Visible = false;
                    label6.Visible = false;
                    //label1.Visible = false;
                    label5.BackColor = Color.Green;
                    b = 5;
                }
                else if (b == 5)
                {
                    label2.Visible = false;
                    label4.Visible = false;
                    label6.Visible = true;
                    label3.Visible = false;
                    label5.Visible = false;
                    //label1.Visible = true;
                    label6.BackColor = Color.Black;
                    b = 1;
                }
                pgb1.Value++;
            }
        }
    }
}