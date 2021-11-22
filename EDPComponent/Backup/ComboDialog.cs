using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using Microsoft.VisualBasic;
using Edpcom;

namespace EDPComponent
{
    [DefaultEvent("DropDown")]
    [Serializable]
    [ComVisibleAttribute(true)]
    public partial class ComboDialog :UserControl
    {        
        #region Combo Dialog       
        private SqlConnection con = null;
        private string btnname = "", subhead = "", title = "";
        private int CellIndex = -1, lOVFlag = 0;
        private DataTable LOVDT = null;
        private bool btnVisi = false, chkvisi = false, boolreadonly = false;// selectsingle = false;
        private Form Intfm = null;
        private int TextLength = 500;
        public static Boolean flag_comboclick = false;
        public ComboDialog()
        {
            InitializeComponent();
        }
        public ComboDialog(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
        }
        public SqlConnection Connection
        {
            get
            {
                return con;
            }
            set
            {
                con = value;
            }
        }
        [Localizable(true)]
        [DispId(-517)]
        [Bindable(true)]
        [Description("Set the Heading."), DefaultValue("")]
        public string Heading
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        [Description("Set the SQL Command for filling up the grid."), DefaultValue("")]
        public string CommandString
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }
        [Description("Set the Button text."), DefaultValue("")]
        public string ButtonText
        {
            get
            {
                return btnname;
            }
            set
            {
                btnname = value;
            }
        }
        [Description("Set the retrun index into the grid."), DefaultValue(0)]
        public int ReturnIndex
        {
            get
            {
                return CellIndex;
            }
            set
            {
                CellIndex = value;
            }
        }
        [Description("Set the data table for grid."), DefaultValue(null)]
        public DataTable LookUpTable
        {
            get
            {
                return LOVDT;
            }
            set
            {
                LOVDT = value;
            }
        }
        [Description("Whether the button will be visible or not."), DefaultValue(false)]
        public bool ShowButton
        {
            get
            {
                return btnVisi;
            }
            set
            {
                btnVisi = value;
            }
        }
        [Description("Set the Form which against the button click."), DefaultValue(null)]
        public Form OpeningDialog
        {
            get
            {
                return Intfm;
            }
            set
            {
                Intfm = value;
            }
        }
        /// <summary>
        /// Get the return value for corresponding return index.
        /// </summary>
        [Browsable(false)]
        public string ReturnValue
        {
            get
            {
                return ret;
            }
            set
            {
                ret = value;
            }
        }

        public string ReturnValue_3rd
        {
            get
            {
                return ret_3;
            }
            set
            {
                ret_3 = value;
            }
        }

        public string ReturnValue_4th
        {
            get
            {
                return ret_4;
            }
            set
            {
                ret_4 = value;
            }
        }
        
        [Browsable(false)]
        public string DialogResult
        {
            get
            {
                return LOVRESULT;
            }
            set
            {
                LOVRESULT = value;
            }
        }
        public override string Text
        {
            get
            {
                return returntext;
            }
            set
            {
                returntext = value;
                txtPop.Text = returntext;
            } 
        }

        public int MaxCharLength
        {
            get
            {
                return TextLength;
            }
            set
            {
                TextLength = value;               
            } 
        }
        [Description("Maximum Input Charecter"), DefaultValue(500)]

        [Browsable(false)]
        public int LOVFlag
        {
            get
            {
                return lOVFlag;
            }
            set
            {
                lOVFlag = value;
            }
        }
        [Description("Enter the Subheading."), DefaultValue("")]
        public string SubHeading
        {
            get
            {
                return subhead;
            }
            set
            {
                subhead = value;
            }
        }
        [Description("Whether the checkbox visible for single Item  in Grid."), DefaultValue(false)]
        public bool ShowCheckBox
        {
            get
            {
                return chkvisi;
            }
            set
            {
                chkvisi = value;
            }
        }
        [Description("If only one item is there in grid then it will Automatically selected."), DefaultValue(false)]
        public bool SelectSingleItem
        {
            get
            {
                return selectSingleItemAutomatically.Checked; 
            }
            set
            {
                selectSingleItemAutomatically.Checked = value;
            }
        }
        [Description(""), DefaultValue(false)]
        public bool ReadOnly
        {
            get
            {
               return boolreadonly;
            }
            set
            {
                boolreadonly = value;
            }
        }
        [Description(""), DefaultValue(false)]
        public bool ReadOnlyText
        {
            get
            {
                return txtPop.ReadOnly;
            }
            set
            {
                txtPop.ReadOnly = value;
            }
        }
        private void LOVShow(string heading, string Command,int cell_index)
        {
            LOVGen(con);
            Heading = heading;
            text = Command;
            CellIndex = cell_index;
            LOVFORM.ShowDialog();
        }
        private void LOVShow(string heading, DataTable Datatable, int cell_index)
        {
            LOVGen(con);
            Heading = heading;
            LOVDT = Datatable;
            CellIndex = cell_index;
            LOVFlag = 100;
            LOVFORM.ShowDialog();
        }
        private void LOVShow(string heading, string Command, int cell_index, Form FromOpen, bool btnvisible, string btnText)
        {
            LOVGen(con);
            Heading = heading;
            text = Command;
            CellIndex = cell_index;
            btnVisi = btnvisible;
            btnname = btnText;
            Intfm = FromOpen;
            LOVFORM.ShowDialog();
        }
        private void LOVShow(string heading, DataTable Datatable, int cell_index, Form FromOpen, bool btnvisible, string btnText)
        {
            LOVGen(con);
            Heading = heading;
            LOVDT = Datatable;
            CellIndex = cell_index;
            LOVFlag = 100;
            btnVisi = btnvisible;
            btnname = btnText;
            Intfm = FromOpen;
            LOVFORM.ShowDialog();
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            //if ((!this.ReadOnly) && (txtPop.Text == ""))
            if (!this.ReadOnly)
            {
                DropDownHandler dd = DropDown;
                if (dd != null) { dd(this, new System.EventArgs()); }
                this.Invalidate();
                EventHandler ev = Click;
                if (ev != null) { ev(sender, e); }
                this.Invalidate();
                //if ((CommandString == null) && (LookUpTable == null))
                //{
                //    //EDPMessageBox.EDPMessage.Show("No lookup table Sepecified.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    EDPMessageBox.EDPMessage.Show("No lookup table Sepecified.", "Info", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_OK, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                //    return;
                //}
                if ((CommandString != null) && (CommandString != ""))
                {
                    if (ShowButton)
                    {
                        LOVShow(Heading, CommandString, ReturnIndex, OpeningDialog, ShowButton, ButtonText);
                    }
                    else
                    {
                        LOVShow(Heading, CommandString, ReturnIndex);
                    }
                }
                else if (LookUpTable != null)
                {
                    if (ShowButton)
                    {
                        LOVShow(Heading, LookUpTable, ReturnIndex, OpeningDialog, ShowButton, ButtonText);
                    }
                    else
                    {
                        LOVShow(Heading, LookUpTable, ReturnIndex);
                    }
                }
                else
                {
                    return;
                }
                txtPop.Text = returntext;
                bool mod;
                if (prevtext == returntext)
                    mod = false;
                else mod = true;
                CloseUpHandler cu = CloseUp;
                if (cu != null) { cu(this, new CloseUpEventArgs(mod, ret, LOVRESULT, returntext)); }
                this.Invalidate();
            }
            else
            {
                txtPop.Focus();
            }
        }

        public delegate void DropDownHandler(object sender, EventArgs e);

        public event DropDownHandler DropDown;

        public delegate void CloseUpHandler(object sender, CloseUpEventArgs e);

        public event CloseUpHandler CloseUp;

        public class CloseUpEventArgs : EventArgs
        {
            protected bool mod = false; string retval = "", dialogres = "", rettext = "";
            public CloseUpEventArgs(bool modified, string returnvalue, string diaglogresult, string text)
            {
                mod = modified; retval = returnvalue; dialogres = diaglogresult; rettext = text;
            }
            public bool Modified
            {
                get
                {
                    return mod;
                }

            }
            public string ReturnValue
            {
                get
                {
                    return retval;
                }
            }
            public string DialogResult
            {
                get
                {
                    return dialogres;
                }
            }
            public string Text
            {
                get
                {
                    return rettext;
                }
            }

        }

        private void ComboDialog_Resize(object sender, EventArgs e)
        { 
            btnPop.Location = new Point(this.Width - 22, 1);
            this.Height = 21;
        }

        public new event EventHandler Click;

        private void ComboDialog_BackColorChanged(object sender, EventArgs e)
        {
            if (this.BackColor != Color.Transparent)
                txtPop.BackColor = this.BackColor;
            else txtPop.BackColor = Color.White;
        }

        private void txtPop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Tab)
                Edpcom.EDPCommon.chk_Key_Press = false;
            else
                Edpcom.EDPCommon.chk_Key_Press = true;
            KeyEventHandler kh = KeyDown;
            if (kh != null) { kh(this, new KeyEventArgs(e.KeyCode)); }
            this.Invalidate();
            if ((e.KeyCode == Keys.Enter) && (txtPop.Text == ""))
                PopUp();
            if (e.KeyCode == Keys.Insert)
                txtPop_DoubleClick(sender, e);

            //if (e.Control)
            //{
            //    if ((e.KeyCode == Keys.D) || (e.KeyCode == Keys.G) || (e.KeyCode == Keys.N) || (e.KeyCode == Keys.S) || (e.KeyCode == Keys.V))
            //    {
            //        txtPop_Leave(txtPop, e);
            //    }
            //}
        }

        public new event KeyEventHandler KeyDown;
        /// <summary>
        /// If you use it by key board.
       /// </summary>
       /// <param name="sender">Pass the sender.</param>
       /// <param name="e">Pass the event arguments.</param>
        public void PopUp(object sender,EventArgs e)
        {
            btnPop_Click(sender, e);
        }
        public void PopUp()
        {
            object sender = txtPop; EventArgs e = new EventArgs();
            btnPop_Click(sender, e);
        }
        #endregion
        #region LOV

        private Form LOVFORM = new Form();
        //private System.Windows.Forms.Button button1;
        //private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.Label label2;
        //private System.Windows.Forms.Label label3;
        //private System.Windows.Forms.Label label4;
        //private System.Windows.Forms.Label label5;
        //private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label panel1;
        private System.Windows.Forms.DataGridView dgv;
        private ListBox lb;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ToolTip toolTip1;

      //  DataView dv;
        string cname,tt;
        DataSet ds = new DataSet();
        SqlCommand com = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        Button b2 = new Button();
        CheckBox chk = new CheckBox();
        private Point Hold;
        string text1;
        int cellIndex;
        private string ret = "", text = "", LOVRESULT = "", returntext = "", prevtext = "";
        private string ret_3 = "", ret_4 = "";

        private void InitializeComponentLOV()
        {
            LOVFORM.Controls.Clear();
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            //button1 = new System.Windows.Forms.Button();
            //Title = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            //label2 = new System.Windows.Forms.Label();
            //label3 = new System.Windows.Forms.Label();
            //label4 = new System.Windows.Forms.Label();
            //label5 = new System.Windows.Forms.Label();
            //label6 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Label();
            lb = new ListBox();
            dgv = new System.Windows.Forms.DataGridView();
            txtSearch = new System.Windows.Forms.TextBox();
            toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgv)).BeginInit();
            LOVFORM.SuspendLayout();
            // 
            // button1
            // 
            //button1.BackColor = System.Drawing.Color.Black;
            //button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            //button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            //button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //button1.ForeColor = System.Drawing.Color.Red;
            //button1.Location = new System.Drawing.Point(297, 0);
            //button1.Name = "button1";
            //button1.Size = new System.Drawing.Size(21, 35);
            //button1.TabIndex = 3;
            //button1.Text = "X";
            //button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //toolTip1.SetToolTip(button1, "Close");
            //button1.UseVisualStyleBackColor = false;
            //button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Title
            // 
            //Title.BackColor = System.Drawing.Color.Black;
            //Title.Dock = System.Windows.Forms.DockStyle.Top;
            //Title.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            //Title.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //Title.ForeColor = System.Drawing.Color.LightYellow;
            //Title.Location = new System.Drawing.Point(0, 0);
            //Title.Name = "Title";
            //Title.Size = new System.Drawing.Size(318, 35);
            //Title.TabIndex = 1;
            //Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_MouseDown);
            //Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Title_MouseMove);
            //Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Title_MouseUp);
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.LightGray;
            label1.Dock = System.Windows.Forms.DockStyle.Top;
            label1.ForeColor = System.Drawing.Color.Navy;
            label1.Location = new System.Drawing.Point(0, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(318, 20);
            label1.TabIndex = 2;
            label1.Text = "Description List for AccordFour";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            //label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            //label2.Location = new System.Drawing.Point(0, 58);
            //label2.Name = "label2";
            //label2.Size = new System.Drawing.Size(316, 3);
            ////label2.TabIndex = 3;
            // 
            // label3
            // 
            //label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            //label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            //label3.Location = new System.Drawing.Point(0, 338);
            //label3.Name = "label3";
            //label3.Size = new System.Drawing.Size(318, 3);
            ////label3.TabIndex = 4;
            // 
            // label4
            // 
            //label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            //label4.Dock = System.Windows.Forms.DockStyle.Left;
            //label4.Location = new System.Drawing.Point(0, 59);
            //label4.Name = "label4";
            //label4.Size = new System.Drawing.Size(3, 279);
            ////label4.TabIndex = 5;
            // 
            // label5
            // 
            //label5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            //label5.Dock = System.Windows.Forms.DockStyle.Right;
            //label5.Location = new System.Drawing.Point(315, 59);
            //label5.Name = "label5";
            //label5.Size = new System.Drawing.Size(3, 279);
            //label5.TabIndex = 6;
            ////label5.Text = "                                                                                 " +
            ////    "                                                                                " +
            ////    "                       ";
            // 
            // label6
            // 
            //label6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            //label6.Location = new System.Drawing.Point(0, -1);
            //label6.Name = "label6";
            //label6.Size = new System.Drawing.Size(274, 3);
            ////label6.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(dgv);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 59);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(230, 230);
            panel1.TabIndex = 0;
            // 
            // DG1
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro;
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle9;
            dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgv.Location = new System.Drawing.Point(0, 0);
            dgv.MultiSelect = false;
            dgv.Name = "DG1";
            dgv.ReadOnly = true;
            dgv.RowHeadersWidth = 10;
            dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.Size = new System.Drawing.Size(220, 220);
            dgv.TabIndex = 0;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.KeyDown += new KeyEventHandler(this.DG1_KeyDown);
            dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG1_ColumnHeaderMouseClick);
            dgv.DoubleClick += new System.EventHandler(this.DG1_DoubleClick);
            // 
            // textBox1
            // 
            txtSearch.BackColor = System.Drawing.SystemColors.Control;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtSearch.Location = new System.Drawing.Point(3, 318);
            txtSearch.Name = "textBox1";
            txtSearch.Size = new System.Drawing.Size(312, 20);
            txtSearch.TabIndex = 1;
            toolTip1.SetToolTip(txtSearch, "Type for searching");
            txtSearch.Enter += new System.EventHandler(this.textBox1_Enter);
            txtSearch.Leave += new System.EventHandler(this.textBox1_Leave);
            txtSearch.KeyDown += new KeyEventHandler(textBox1_KeyDown);
            txtSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // toolTip1
            // 
            toolTip1.ShowAlways = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            lb.Visible = false;
            // 
            // LOV
            // 
            LOVFORM.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            LOVFORM.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //LOVFORM.BackColor = System.Drwaing.Color.White;            
            //change Subrata
            LOVFORM.ClientSize = new System.Drawing.Size(400, 480);
            LOVFORM.ControlBox = true;
            //LOVFORM.CancelButton = button1;
            LOVFORM.Controls.Add(txtSearch);
            //LOVFORM.Controls.Add(button1);
            LOVFORM.Controls.Add(panel1);
            //LOVFORM.Controls.Add(label6);
            //LOVFORM.Controls.Add(label5);
            //LOVFORM.Controls.Add(label4);
            //LOVFORM.Controls.Add(label3);
            //LOVFORM.Controls.Add(label2);
            LOVFORM.Controls.Add(label1);
            //LOVFORM.Controls.Add(Title);
            LOVFORM.Controls.Add(lb);
            LOVFORM.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            LOVFORM.MaximizeBox = false;
            LOVFORM.Name = "LOV";
            LOVFORM.ShowIcon = false;
            LOVFORM.MaximizeBox = false;
            LOVFORM.MinimizeBox = false;
            LOVFORM.ShowInTaskbar = false;
            LOVFORM.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            LOVFORM.SizeChanged += new System.EventHandler(this.LOV_SizeChanged);
            LOVFORM.Shown += new System.EventHandler(this.LOV_Shown);
            LOVFORM.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LOV_FormClosing);
            LOVFORM.Load += new System.EventHandler(this.LOV_Load);
            LOVFORM.KeyPress += new KeyPressEventHandler(LOV_KeyPress);
            LOVFORM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LOV_KeyDown);            
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            LOVFORM.ResumeLayout(false);
            LOVFORM.PerformLayout();
        }

        void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
                dgv.Focus();
            if (e.KeyCode == Keys.Enter)
                DG1_KeyDown(sender, e);
            if (e.KeyCode == Keys.Escape)
                LOVFORM.Close();
        }

        public void LOVGen()
        {
            InitializeComponentLOV();
        }
        public void LOVGen(SqlConnection connection)
        {
            InitializeComponentLOV();
            con = connection;
           // Clear();
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    DialogResult = "NO"; 
        //   LOVFORM.Close();
        //}
        private void LOV_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DG1_KeyDown(sender, e);
                    returntext = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    ret = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[CellIndex].Value.ToString();
                    if(Edpcom.EDPCommon.Chk_3rd_Position_Value==true)
                        ret_3 = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    if (Edpcom.EDPCommon.Chk_4th_Position_Value == true)
                        ret_4 = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    LOVFORM.Close();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    LOVFORM.Close();                   
                }
                //if (e.KeyCode == Keys.Back)
                //{
                //    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                //}
            }
            catch
            { }
        }
        private void LOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {                
                if (e.KeyChar == (char)Keys.Back)
                {
                    e.Handled = false;
                }
                //else
                //{
                //    textBox1.Text = textBox1.Text + e.KeyChar.ToString();
                //}
            }
            catch { }
        }    
        private void LOV_Load(object sender, EventArgs e)
        {
            try
            {
                prevtext = txtPop.Text;
                if (btnVisi == true)
                {
                    b2.AutoSize = true;
                    b2.Text = btnname;
                    b2.TextAlign = ContentAlignment.MiddleCenter;
                    b2.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    b2.BackColor = Color.LightGray;
                    b2.ForeColor = Color.Navy;
                    b2.FlatStyle = FlatStyle.Flat;
                    b2.FlatAppearance.BorderColor = Color.LightGray;
                    LOVFORM.Controls.Add(b2);
                    b2.Dock = DockStyle.Bottom;
                    b2.Click += new EventHandler(this.btn_Click);
                }
                if (chkvisi)
                {
                    chk.Text = "Select Automatically if total count is One.";
                    chk.Dock = DockStyle.Bottom;
                    LOVFORM.Controls.Add(chk);
                }
                if (Information.IsNothing(ds.Tables["fill_lov"]) == false)
                {
                    ds.Tables["fill_lov"].Clear();
                }
                //Title.Text = title;                
                label1.Text = subhead;
                if (lOVFlag == 100)
                {
                    dgv.DataSource = LOVDT;
                    lb.DataSource = LOVDT;
                }
                else
                {
                    con.Close();
                    con.Open();
                    //Edpcom.EDPCommon.ClearDataTable_EDP(ds.Tables["fill_lov"]);
                    com = new SqlCommand(text, con);
                    da.SelectCommand = com;
                    da.Fill(ds, "fill_lov");                    
                    con.Close();                  

                    dgv.DataSource = ds.Tables["fill_lov"];                   
                    lb.DataSource = ds.Tables["fill_lov"];                   
                }

                if ((Edpcom.EDPCommon.Column_Hide_Index != "") && ((Information.IsNothing(ds.Tables["fill_lov"])==false) || (LOVDT.Rows.Count > 0)))
                {
                    string[] aa = new string[] { };
                    aa = Edpcom.EDPCommon.Column_Hide_Index.Trim().Split(',');
                    if (aa.Length > 0)
                    {
                        for (int k = 0; k <= aa.Length - 1; k++)
                        {
                            string str_CN = aa[k].ToString();
                            dgv.Columns[str_CN].Visible = false;
                        }
                    }
                }

                Edpcom.EDPCommon.Column_Hide_Index = "";
                LOVFORM.Text = title;

                if (selectSingleItemAutomatically.Checked)
                {
                    if (dgv.Rows.Count == 1)
                    {
                        if (CellIndex > dgv.Columns.Count - 1)
                        {
                            EDPMessageBox.EDPMessage.Show("Return Index out of Range.");
                            return;
                        }
                        returntext = dgv.Rows[0].Cells[0].Value.ToString();
                        ret = dgv.Rows[0].Cells[CellIndex].Value.ToString();
                    }
                }
                cname = dgv.Columns[0].Name.ToString();
                lb.DisplayMember = cname;
                //dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //for (int k = 0; k < dgv.ColumnCount - 1; k++)
                //{
                //    if (k == 0)
                //        dgv.Columns[k].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //    else
                //        dgv.Columns[k].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //}
                if (dgv.RowCount > 0)
                    dgv.Rows[0].Cells[0].Selected = true;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //for (int k = 0; k < dgv.ColumnCount - 1; k++)
                //{
                //    if (k == 0)
                //        dgv.Columns[k].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //    else
                //        dgv.Columns[k].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //}

                //if (CellIndex >= 0)
                  //  dgv.Columns[CellIndex].Visible = false;   //Amit
               
                // txtSearch.ReadOnly = true;
                txtSearch.Text = "a";
                txtSearch.Text = "";
                txtSearch.Focus();
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);
                LOVFORM.Width = dgv.Columns.Count * 165;

                if (dgv.Columns.Count == 1)
                    LOVFORM.Width = dgv.Columns.Count * 365;

                if (LOVFORM.Width > 600)
                {
                    LOVFORM.Width = 720;
                    dgv.Columns[0].Width = 180;
                }
               new Edpcom.EDPCommon().setFormPosition(LOVFORM);

               //SD Grid Selecttion
               if (dgv.RowCount > 0)
               {
                   dgv.Focus();
                   dgv.ClearSelection();
                   dgv.Rows[0].Cells[0].Selected = true;
                   dgv.CurrentCell = dgv[0, 0];                   
               }
            }
            catch (Exception ex)
            {
                EDPMessageBox.EDPMessage.Show(ex.Message);
                con.Close();
            }
            EDPCommon.HScrollBarVisible(dgv);
        }
        private void DG1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (CellIndex > dgv.Columns.Count - 1)
                {
                    EDPMessageBox.EDPMessage.Show("Return Index out of Range");
                    return;
                }
                returntext = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if (CellIndex >= 0)
                    ret = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[CellIndex].Value.ToString();
                else ret = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if (Edpcom.EDPCommon.Chk_3rd_Position_Value == true)
                    ret_3 = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value.ToString();
                if (Edpcom.EDPCommon.Chk_4th_Position_Value == true)
                    ret_4 = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[3].Value.ToString();
                LOVFORM.Close();
            }
            catch { }
        }
        private void DG1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    LOVFORM.Close();
                }

                if (e.KeyCode == Keys.Home)
                {
                    dgv.Focus();
                    dgv.Rows[0].Cells[0].Selected = true;
                    dgv.CurrentCell = dgv[0, 0];
                }

                if (e.KeyCode == Keys.End)
                {
                    dgv.Focus();
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Selected = true;
                    dgv.CurrentCell = dgv[0, dgv.RowCount - 1];
                }

                //if (e.KeyCode == Keys.PageDown)
                //{
                //    dgv.Focus();
                //    dgv.Rows[dgv.CurrentCell.RowIndex +19].Cells[0].Selected = true;
                //    dgv.CurrentCell = dgv[0, dgv.CurrentCell.RowIndex + 19];
                //}


                if (e.KeyCode == Keys.Enter)
                {
                    returntext = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    if (CellIndex >= 0)
                        ret = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[CellIndex].Value.ToString();
                    else ret = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    if (Edpcom.EDPCommon.Chk_3rd_Position_Value == true)
                        ret_3 = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    if (Edpcom.EDPCommon.Chk_4th_Position_Value == true)
                        ret_4 = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    LOVFORM.Close();
                }
                else if (((e.KeyValue >= 48) && (e.KeyValue <= 57)) || ((e.KeyValue >= 65) && (e.KeyValue <= 90)) || ((e.KeyValue >= 96) && (e.KeyValue <= 105)))
                    txtSearch.Text = txtSearch.Text + Strings.Chr(e.KeyValue);
                else if ((e.KeyValue == 8) && (txtSearch.Text.Length > 0)) txtSearch.Text = txtSearch.Text.Substring(0, txtSearch.Text.Length - 1);
            }
            catch { }
        }
        private void LOV_SizeChanged(object sender, EventArgs e)
        {
            //button1.Location = new Point(LOVFORM.Width - 30, 0);
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
                //if (lOVFlag == 100)
                //{
                //    dv = new DataView(LOVDT);
                //}
                //else
                //{
                //    dv = new DataView(ds.Tables["fill_lov"]);
                //}
                //if (tt != "System.Int32" && tt != "System.Decimal")
                //{
                //    dv.RowFilter = "[" + cname + "] like" + "'" + textBox1.Text + "%" + "'";
                //}
                //else
                //{
                //    if (textBox1.Text != "" && Information.IsNumeric(textBox1.Text) == true)
                //    {
                //        dv.RowFilter = "[" + cname + "]=" + Convert.ToDecimal(textBox1.Text);
                //    }
                //}
                //DG1.DataSource = dv;
                lb.SelectedIndex = lb.FindString(txtSearch.Text);
            }
            catch { }
        }
        private void DG1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                cname = dgv.Columns[e.ColumnIndex].Name.ToString();
                lb.DisplayMember = cname;
                tt = dgv.Columns[e.ColumnIndex].ValueType.ToString();
                txtSearch.Focus();
            }
            catch { }
        }
        private void LOV_FormClosing(object sender, FormClosingEventArgs e)
        {
            lOVFlag = 0;
            new Edpcom.EDPCommon().saveFormPosition(LOVFORM.Name, LOVFORM.Location);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                text1 = text;
                cellIndex = CellIndex;
                btnVisi = false;
                Intfm.ShowDialog();
                if (Information.IsNothing(ds.Tables["fill_lov"]) == false)
                {
                    ds.Tables["fill_lov"].Clear();
                }
                dgv.DataSource = null;
                con.Close();
                con.Open();
                com = new SqlCommand(text1, con);
                da.SelectCommand = com;
                da.Fill(ds, "fill_lov");
                con.Close();
                dgv.DataSource = ds.Tables["fill_lov"];
                lb.DataSource = ds.Tables["fill_lov"];
                lb.DisplayMember = ds.Tables["fill_lov"].Columns[0].ColumnName;
                CellIndex = cellIndex;
                btnVisi = true;
                dgv.Focus();
            }
            catch { }
        }
        //private void Title_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        LOVFORM.Cursor = Cursors.SizeAll;
        //        Hold = new Point(e.X, e.Y);
        //    }
        //}
        //private void Title_MouseMove(object sender, MouseEventArgs e)
        //{
        //    LOVFORM.SuspendLayout();
        //    if (e.Button == MouseButtons.Left)
        //    {
                
        //    }
        //    LOVFORM.ResumeLayout();
        //}
        //private void Title_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        LOVFORM.Left += e.X - Hold.X;
        //        LOVFORM.Top += e.Y - Hold.Y;
        //        LOVFORM.Cursor = Cursors.Default;
        //        Screen.FromControl(LOVFORM);
        //    }
        //}

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                LOVFORM.Close();
            }
        }

        private void LOV_Shown(object sender, EventArgs e)
        {
            if (selectSingleItemAutomatically.Checked)
            {
                if (dgv.Rows.Count == 1)
                    LOVFORM.Close();
            }
            txtSearch.Text = txtPop.Text;
            if (dgv.Rows.Count == 0)
            {
                if (Intfm != null)
                    btn_Click(sender, e);
            }
        }
        #endregion

        private void selectSingleItemAutomatically_Click(object sender, EventArgs e)
        {
          //  selectsingle = selectSingleItemAutomatically.Checked;
        }

        private void txtPop_TextChanged(object sender, EventArgs e)
        {
            returntext = txtPop.Text;
        }

        //private void ComboDialog_Enter(object sender, EventArgs e)
        //{
        //    //if (ReadOnlyText)
        //    //{
        //    //    txtPop.TabStop = false;
        //    //    btnPop.TabStop = true;
        //    //}
        //    //else
        //    //{
        //    //    btnPop.TabStop = false;
        //    //    txtPop.TabStop = true;
        //    //}
        //    if (txtPop.Text == "")
        //    {
        //        txtPop.TabStop = false;
        //        btnPop.TabStop = true;                
        //        btnPop.Focus();
        //    }
        //    else
        //    {
        //        btnPop.TabStop = false;
        //        txtPop.TabStop = true;                
        //        txtPop.Focus();
        //    }
        //}

        private void btnPop_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    this.ParentForm.Parent.SelectNextControl(this, true, true, true, true);
            //}
        }

        private void txtPop_DoubleClick(object sender, EventArgs e)
        {
            if (!this.ReadOnly)
            {
                DropDownHandler dd = DropDown;
                if (dd != null) { dd(this, new System.EventArgs()); }
                this.Invalidate();
                EventHandler ev = Click;
                if (ev != null) { ev(sender, e); }
                this.Invalidate();
                //if ((CommandString == null) && (LookUpTable == null))
                //{
                //    EDPMessageBox.EDPMessage.Show("No lookup table Sepecified.", "Info", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_OK, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                //    return;
                //}
                if ((CommandString != null) && (CommandString != ""))
                {
                    if (ShowButton)
                    {
                        LOVShow(Heading, CommandString, ReturnIndex, OpeningDialog, ShowButton, ButtonText);
                    }
                    else
                    {
                        LOVShow(Heading, CommandString, ReturnIndex);
                    }
                }
                else if (LookUpTable != null)
                {
                    if (ShowButton)
                    {
                        LOVShow(Heading, LookUpTable, ReturnIndex, OpeningDialog, ShowButton, ButtonText);
                    }
                    else
                    {
                        LOVShow(Heading, LookUpTable, ReturnIndex);
                    }
                }
                else
                {
                    return;
                }
                txtPop.Text = returntext;
                bool mod;
                if (prevtext == returntext)
                    mod = false;
                else mod = true;
                CloseUpHandler cu = CloseUp;
                if (cu != null) { cu(this, new CloseUpEventArgs(mod, ret, LOVRESULT, returntext)); }
                this.Invalidate();
            }
        }

        private void btnPop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
                txtPop_DoubleClick(sender, e);
        }

        private void txtPop_Enter(object sender, EventArgs e)
        {
            try
            {
                Edpcom.EDPCommon.chk_Key_Press = false;
                btnPop.Visible = true;
                txtPop.Visible = true;
                if (Information.IsNothing(txtPop.Text) == false && txtPop.Text!="")
                txtPop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                txtPop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtPop.BackColor = Color.White;
                txtPop.ForeColor = Color.Black;                
            }
            catch { }
        }

        private void txtPop_Leave(object sender, EventArgs e)        
        {
            try
            {
                //if ((Edpcom.EDPCommon.chk_Key_Press == false) && (txtPop.Text != ""))
                if (Edpcom.EDPCommon.chk_Key_Press == false)
                {
                    txtPop.BackColor = Color.SeaShell;
                    txtPop.ForeColor = Color.Maroon;
                    //if (Information.IsNothing(txtPop.Text) == false && txtPop.Text != "")
                    //txtPop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    txtPop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btnPop.Visible = false;
                    Edpcom.EDPCommon.chk_Key_Press = true;
                    txtPop.DeselectAll();                    
                }
                else
                {
                    txtPop.Focus();
                }
            }       
            catch { }
        }

        private void txtPop_MouseMove(object sender, MouseEventArgs e)
        {
            Edpcom.EDPCommon.chk_Key_Press = false;
        }
        
        private void txtPop_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Edpcom.EDPCommon.chk_Key_Press = true;
        }

        private void txtPop_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtPop.Text.Length > TextLength)
                {
                    string strText = txtPop.Text.Substring(0, TextLength);
                    txtPop.Text = "";
                    txtPop.AppendText(strText);                 
                }
            }
            catch { }
        }

        private void ComboDialog_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void txtPop_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPop.Text == "" && flag_comboclick==true)
                txtPop_DoubleClick(sender, e);
            flag_comboclick = false;
        }
                           
         
    }
}
