namespace PayRollManagementSystem
{
    partial class Bill_SalaryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bill_SalaryForm));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dgv_show2 = new System.Windows.Forms.DataGridView();
            this.dgv_show3 = new System.Windows.Forms.DataGridView();
            this.dgv_show4 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grp_Profit = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.dgv_show1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show4)).BeginInit();
            this.panel1.SuspendLayout();
            this.grp_Profit.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(494, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "BILL";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "SHOW";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(455, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 15);
            this.label2.TabIndex = 3;
            this.label2.Visible = false;
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(78, 12);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(171, 21);
            this.cmbYear.TabIndex = 243;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 244;
            this.label3.Text = "Session";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December",
            "January",
            "February",
            "March"});
            this.listBox1.Location = new System.Drawing.Point(938, 14);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(66, 17);
            this.listBox1.TabIndex = 1;
            this.listBox1.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(150, -2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(92, 19);
            this.radioButton1.TabIndex = 245;
            this.radioButton1.Text = "NETT AMT. ";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(255, -2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(101, 19);
            this.radioButton2.TabIndex = 246;
            this.radioButton2.Text = "GROSS AMT.";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(386, -2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(207, 19);
            this.radioButton3.TabIndex = 247;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "GROSS + EMP CONTRIBUTION";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(540, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 248;
            this.label4.Text = "SALARY";
            this.label4.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(255, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 17);
            this.checkBox1.TabIndex = 251;
            this.checkBox1.Text = "Suppress null data";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dgv_show2
            // 
            this.dgv_show2.AllowUserToAddRows = false;
            this.dgv_show2.AllowUserToDeleteRows = false;
            this.dgv_show2.AllowUserToResizeColumns = false;
            this.dgv_show2.AllowUserToResizeRows = false;
            this.dgv_show2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_show2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show2.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_show2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_show2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_show2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_show2.Location = new System.Drawing.Point(3, 216);
            this.dgv_show2.Name = "dgv_show2";
            this.dgv_show2.RowHeadersVisible = false;
            this.dgv_show2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_show2.Size = new System.Drawing.Size(1002, 37);
            this.dgv_show2.TabIndex = 252;
            this.dgv_show2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_show2_CellContentClick);
            // 
            // dgv_show3
            // 
            this.dgv_show3.AllowUserToAddRows = false;
            this.dgv_show3.AllowUserToDeleteRows = false;
            this.dgv_show3.AllowUserToResizeColumns = false;
            this.dgv_show3.AllowUserToResizeRows = false;
            this.dgv_show3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_show3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show3.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_show3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_show3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_show3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_show3.Location = new System.Drawing.Point(3, 186);
            this.dgv_show3.Name = "dgv_show3";
            this.dgv_show3.RowHeadersVisible = false;
            this.dgv_show3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_show3.Size = new System.Drawing.Size(1002, 33);
            this.dgv_show3.TabIndex = 253;
            // 
            // dgv_show4
            // 
            this.dgv_show4.AllowUserToAddRows = false;
            this.dgv_show4.AllowUserToDeleteRows = false;
            this.dgv_show4.AllowUserToResizeColumns = false;
            this.dgv_show4.AllowUserToResizeRows = false;
            this.dgv_show4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_show4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_show4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_show4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_show4.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_show4.Location = new System.Drawing.Point(3, 16);
            this.dgv_show4.Name = "dgv_show4";
            this.dgv_show4.RowHeadersVisible = false;
            this.dgv_show4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_show4.Size = new System.Drawing.Size(1002, 183);
            this.dgv_show4.TabIndex = 259;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(614, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(299, 16);
            this.label5.TabIndex = 260;
            this.label5.Text = "PROFIT FOR THE SELECTED  LOCATION";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(606, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(315, 13);
            this.label6.TabIndex = 261;
            this.label6.Text = "( CALCULATED ONLY ON GROSS + EMPLR CONTRIBUTION )";
            this.label6.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbYear);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 50);
            this.panel1.TabIndex = 262;
            // 
            // grp_Profit
            // 
            this.grp_Profit.Controls.Add(this.dgv_show4);
            this.grp_Profit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp_Profit.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_Profit.Location = new System.Drawing.Point(0, 528);
            this.grp_Profit.Name = "grp_Profit";
            this.grp_Profit.Size = new System.Drawing.Size(1008, 202);
            this.grp_Profit.TabIndex = 263;
            this.grp_Profit.TabStop = false;
            this.grp_Profit.Text = "PROFIT FOR THE SELECTED  LOCATION  ( CALCULATED ONLY ON GROSS + EMPLR CONTRIBUTIO" +
                "N )";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_show1);
            this.groupBox2.Controls.Add(this.dgv_show3);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1008, 222);
            this.groupBox2.TabIndex = 264;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SALARY";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_show);
            this.groupBox3.Controls.Add(this.dgv_show2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1008, 256);
            this.groupBox3.TabIndex = 265;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BILL";
            // 
            // dgv_show
            // 
            this.dgv_show.AllowUserToAddRows = false;
            this.dgv_show.AllowUserToDeleteRows = false;
            this.dgv_show.AllowUserToResizeColumns = false;
            this.dgv_show.AllowUserToResizeRows = false;
            this.dgv_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_show.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_show.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_show.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_show.Location = new System.Drawing.Point(3, 18);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.RowHeadersVisible = false;
            this.dgv_show.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_show.Size = new System.Drawing.Size(1002, 198);
            this.dgv_show.TabIndex = 255;
            this.dgv_show.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_show_CellDoubleClick);
            this.dgv_show.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_show_CellClick_1);
            // 
            // dgv_show1
            // 
            this.dgv_show1.AllowUserToAddRows = false;
            this.dgv_show1.AllowUserToDeleteRows = false;
            this.dgv_show1.AllowUserToResizeColumns = false;
            this.dgv_show1.AllowUserToResizeRows = false;
            this.dgv_show1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_show1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_show1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_show1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_show1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_show1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_show1.Location = new System.Drawing.Point(3, 18);
            this.dgv_show1.Name = "dgv_show1";
            this.dgv_show1.RowHeadersVisible = false;
            this.dgv_show1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_show1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_show1.Size = new System.Drawing.Size(1002, 168);
            this.dgv_show1.TabIndex = 259;
            // 
            // Bill_SalaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grp_Profit);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bill_SalaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill_SalaryForm";
            this.Load += new System.EventHandler(this.Bill_SalaryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grp_Profit.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView dgv_show2;
        private System.Windows.Forms.DataGridView dgv_show3;
        private System.Windows.Forms.DataGridView dgv_show4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grp_Profit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_show;
        private System.Windows.Forms.DataGridView dgv_show1;


    }
}