namespace PayRollManagementSystem
{
    partial class frmShift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShift));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblsid = new System.Windows.Forms.Label();
            this.lblsno = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbShiftHrs = new System.Windows.Forms.ComboBox();
            this.dtpUpto = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.txtShift = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgShift = new System.Windows.Forms.DataGridView();
            this.colsid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colshift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colshifthr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colshift_timefrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colshift_timeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgShift)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblsid);
            this.groupBox1.Controls.Add(this.lblsno);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.cmbShiftHrs);
            this.groupBox1.Controls.Add(this.dtpUpto);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.txtShift);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shift Details";
            // 
            // lblsid
            // 
            this.lblsid.AutoSize = true;
            this.lblsid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblsid.Location = new System.Drawing.Point(508, 23);
            this.lblsid.Name = "lblsid";
            this.lblsid.Size = new System.Drawing.Size(2, 15);
            this.lblsid.TabIndex = 98;
            // 
            // lblsno
            // 
            this.lblsno.AutoSize = true;
            this.lblsno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblsno.Location = new System.Drawing.Point(589, 25);
            this.lblsno.Name = "lblsno";
            this.lblsno.Size = new System.Drawing.Size(2, 15);
            this.lblsno.TabIndex = 97;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(470, 84);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 94;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(389, 84);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 95;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(551, 84);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 96;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbShiftHrs
            // 
            this.cmbShiftHrs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShiftHrs.FormattingEnabled = true;
            this.cmbShiftHrs.Items.AddRange(new object[] {
            "8 Hrs",
            "12 Hrs"});
            this.cmbShiftHrs.Location = new System.Drawing.Point(114, 53);
            this.cmbShiftHrs.Name = "cmbShiftHrs";
            this.cmbShiftHrs.Size = new System.Drawing.Size(100, 21);
            this.cmbShiftHrs.TabIndex = 5;
            this.cmbShiftHrs.SelectedIndexChanged += new System.EventHandler(this.cmbShiftHrs_SelectedIndexChanged);
            // 
            // dtpUpto
            // 
            this.dtpUpto.CustomFormat = "hh:mm tt";
            this.dtpUpto.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpUpto.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpUpto.Location = new System.Drawing.Point(246, 80);
            this.dtpUpto.Name = "dtpUpto";
            this.dtpUpto.Size = new System.Drawing.Size(100, 20);
            this.dtpUpto.TabIndex = 4;
            this.dtpUpto.Value = new System.DateTime(2018, 3, 7, 18, 0, 0, 0);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "hh:mm tt";
            this.dtpFrom.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFrom.Location = new System.Drawing.Point(114, 80);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom.TabIndex = 4;
            this.dtpFrom.Value = new System.DateTime(2018, 3, 7, 6, 0, 0, 0);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            this.dtpFrom.Leave += new System.EventHandler(this.dtpFrom_Leave);
            // 
            // txtShift
            // 
            this.txtShift.Location = new System.Drawing.Point(114, 20);
            this.txtShift.Name = "txtShift";
            this.txtShift.Size = new System.Drawing.Size(232, 20);
            this.txtShift.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Shift Timings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Shift Hours";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shift System Name";
            // 
            // dgShift
            // 
            this.dgShift.AllowUserToAddRows = false;
            this.dgShift.AllowUserToDeleteRows = false;
            this.dgShift.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgShift.BackgroundColor = System.Drawing.Color.White;
            this.dgShift.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgShift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colsid,
            this.colshift,
            this.colsno,
            this.colshifthr,
            this.colshift_timefrom,
            this.colshift_timeto});
            this.dgShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgShift.Location = new System.Drawing.Point(0, 133);
            this.dgShift.Name = "dgShift";
            this.dgShift.ReadOnly = true;
            this.dgShift.RowHeadersVisible = false;
            this.dgShift.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgShift.Size = new System.Drawing.Size(638, 343);
            this.dgShift.TabIndex = 1;
            this.dgShift.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgShift_CellClick);
            this.dgShift.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgShift_CellContentClick);
            // 
            // colsid
            // 
            this.colsid.HeaderText = "sid";
            this.colsid.Name = "colsid";
            this.colsid.ReadOnly = true;
            this.colsid.Visible = false;
            // 
            // colshift
            // 
            this.colshift.HeaderText = "Shift";
            this.colshift.Name = "colshift";
            this.colshift.ReadOnly = true;
            // 
            // colsno
            // 
            this.colsno.HeaderText = "sno";
            this.colsno.Name = "colsno";
            this.colsno.ReadOnly = true;
            this.colsno.Visible = false;
            // 
            // colshifthr
            // 
            this.colshifthr.HeaderText = "Duration Hours";
            this.colshifthr.Name = "colshifthr";
            this.colshifthr.ReadOnly = true;
            // 
            // colshift_timefrom
            // 
            this.colshift_timefrom.HeaderText = "Timings From";
            this.colshift_timefrom.Name = "colshift_timefrom";
            this.colshift_timefrom.ReadOnly = true;
            // 
            // colshift_timeto
            // 
            this.colshift_timeto.HeaderText = "Timings To";
            this.colshift_timeto.Name = "colshift_timeto";
            this.colshift_timeto.ReadOnly = true;
            // 
            // frmShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 476);
            this.Controls.Add(this.dgShift);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShift";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shift Master";
            this.Load += new System.EventHandler(this.frmShift_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgShift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShift;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpUpto;
        private System.Windows.Forms.DataGridView dgShift;
        private System.Windows.Forms.ComboBox cmbShiftHrs;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblsid;
        private System.Windows.Forms.Label lblsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colshift;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colshifthr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colshift_timefrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colshift_timeto;
    }
}