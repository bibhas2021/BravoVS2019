using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace EDPComponent
{
    public partial class LOV : Form
    {
        DataView dv;
        string cname,tt;
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        Button b2 = new Button();
        CheckBox chk = new CheckBox();
        private Point Hold;
        string text1;
        int cellIndex;
        public LOV()
        {
            InitializeComponent();
        }
        public LOV(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ComboDialog Modual1 = new ComboDialog();
            Modual1.DialogResult = "NO";
            this.Close();
        }
        private void LOV_Load(object sender, EventArgs e)
        {
            try
            {
                if (common.btnVisi == true)
                {
                    b2.AutoSize = true;
                    b2.Text = common.btnname;
                    b2.TextAlign = ContentAlignment.MiddleCenter;
                    b2.Font = new Font("Arial", 9, FontStyle.Bold);
                    b2.BackColor = Color.Gray;
                    b2.ForeColor = Color.Navy;
                    b2.FlatStyle = FlatStyle.Flat;
                    b2.FlatAppearance.BorderColor = Color.Gray;
                    this.Controls.Add(b2);
                    b2.Dock = DockStyle.Bottom;
                    b2.Click += new EventHandler(this.btn_Click);
                }
                chk.Text = "Select Automatically if total count is One.";
                chk.Dock = DockStyle.Bottom;
                this.Controls.Add(chk);
                if (Information.IsNothing(ds.Tables["fill_lov"]) == false)
                {
                    ds.Tables["fill_lov"].Clear();
                }
                Title.Text = common.title;
                label1.Text = common.subhead;
                if (common.lOVFlag == 100)
                {
                    DG1.DataSource = common.LOVDT;
                }
                else
                {
                    con.Close();
                    con.Open();
                    com = new SqlCommand(common.text, con);
                    da.SelectCommand = com;
                    da.Fill(ds, "fill_lov");
                    con.Close();
                    DG1.DataSource = ds.Tables["fill_lov"];
                }
                cname = DG1.Columns[0].Name.ToString();
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void DG1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                if (common.CellIndex > DG1.Columns.Count - 1)
                {
                    MessageBox.Show("Return Index out of Range");
                    return;
                }
                common.returntext = DG1.Rows[DG1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                common.ret = DG1.Rows[DG1.CurrentCell.RowIndex].Cells[common.CellIndex].Value.ToString();
                this.Close();
            }
            catch { }
        }
        private void DG1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                common.returntext = DG1.Rows[DG1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                common.ret = DG1.Rows[DG1.CurrentCell.RowIndex].Cells[common.CellIndex].Value.ToString();
                this.Close();
            }
        }
        private void LOV_SizeChanged(object sender, EventArgs e)
        {
            button1.Location = new Point(this.Width - 30, 0);
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            //if (textBox1.Text == "<Search By Heading>")
            //    textBox1.Text = "";
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            //if (textBox1.Text == "")
            //    textBox1.Text = "<Search By Heading>";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (common.lOVFlag == 100)
                {
                    dv = new DataView(common.LOVDT);
                }
                else
                {
                    dv = new DataView(ds.Tables["fill_lov"]);
                }
                if (tt != "System.Int32" && tt != "System.Decimal")
                {
                    dv.RowFilter = "[" + cname + "] like" + "'" + textBox1.Text + "%" + "'";
                }
                else
                {
                    if (textBox1.Text != "" && Information.IsNumeric(textBox1.Text) == true)
                    {
                        dv.RowFilter = "[" + cname + "]=" + Convert.ToDecimal(textBox1.Text);
                    }
                }
                DG1.DataSource = dv;
            }
            catch { }
        }
        private void DG1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                cname = DG1.Columns[e.ColumnIndex].Name.ToString();
                tt = DG1.Columns[e.ColumnIndex].ValueType.ToString();
                textBox1.Focus();
            }
            catch { }
        }
        private void LOV_FormClosing(object sender, FormClosingEventArgs e)
        {
            common.btnVisi = false;
            common.lOVFlag = 0;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                text1 = common.text;
                cellIndex = common.CellIndex;
                common.btnVisi = false;
                common.Intfm.ShowDialog();
                if (Information.IsNothing(ds.Tables["fill_lov"]) == false)
                {
                    ds.Tables["fill_lov"].Clear();
                }
                DG1.DataSource = null;
                con.Close();
                con.Open();
                com = new SqlCommand(text1, con);
                da.SelectCommand = com;
                da.Fill(ds, "fill_lov");
                con.Close();
                DG1.DataSource = ds.Tables["fill_lov"];
                common.CellIndex = cellIndex;
                common.btnVisi = true;
            }
            catch { }
        }

        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.SizeAll;
                Hold = new Point(e.X, e.Y);
            }
        }

        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - Hold.X;
                this.Top += e.Y - Hold.Y;
            }
            this.ResumeLayout();
        }

        private void Title_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Hold = new Point(0, 0);
                this.Cursor = Cursors.Default;
                Screen.FromControl(this);
            }
        }
    }
}