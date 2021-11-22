namespace PayRollManagementSystem
{
    partial class frmficodegenarate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnupdate = new EDPComponent.VistaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.cmbcompany = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgGrd = new System.Windows.Forms.DataGridView();
            this.ficode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RangeFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RangeTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSubmit = new EDPComponent.VistaButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGrd)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.btnupdate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpfrom);
            this.groupBox1.Controls.Add(this.dtpto);
            this.groupBox1.Controls.Add(this.cmbcompany);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dgGrd);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 315);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(73, 14);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(113, 21);
            this.cmbYear.TabIndex = 265;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.Transparent;
            this.btnupdate.ButtonText = "Update";
            this.btnupdate.Location = new System.Drawing.Point(259, 280);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(72, 29);
            this.btnupdate.TabIndex = 113;
            this.btnupdate.Visible = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 111;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "To Date";
            // 
            // dtpfrom
            // 
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrom.Location = new System.Drawing.Point(73, 49);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(113, 20);
            this.dtpfrom.TabIndex = 109;
            // 
            // dtpto
            // 
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(259, 49);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(112, 20);
            this.dtpto.TabIndex = 110;
            // 
            // cmbcompany
            // 
            this.cmbcompany.FormattingEnabled = true;
            this.cmbcompany.Location = new System.Drawing.Point(259, 14);
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.Size = new System.Drawing.Size(165, 21);
            this.cmbcompany.TabIndex = 108;
            this.cmbcompany.SelectedIndexChanged += new System.EventHandler(this.cmbcompany_SelectedIndexChanged);
            this.cmbcompany.Leave += new System.EventHandler(this.cmbcompany_Leave);
            this.cmbcompany.DropDownClosed += new System.EventHandler(this.cmbcompany_DropDownClosed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 107;
            this.label4.Text = "Company";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Session";
            // 
            // dgGrd
            // 
            this.dgGrd.AllowUserToDeleteRows = false;
            this.dgGrd.AllowUserToResizeColumns = false;
            this.dgGrd.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgGrd.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgGrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgGrd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgGrd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgGrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgGrd.ColumnHeadersHeight = 25;
            this.dgGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgGrd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ficode1,
            this.gcode1,
            this.RangeFrom,
            this.RangeTo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgGrd.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgGrd.Location = new System.Drawing.Point(14, 76);
            this.dgGrd.Margin = new System.Windows.Forms.Padding(4);
            this.dgGrd.Name = "dgGrd";
            this.dgGrd.RowHeadersVisible = false;
            this.dgGrd.RowHeadersWidth = 5;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgGrd.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgGrd.RowTemplate.Height = 24;
            this.dgGrd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgGrd.Size = new System.Drawing.Size(410, 200);
            this.dgGrd.TabIndex = 104;
            this.dgGrd.Enter += new System.EventHandler(this.dgGrd_Enter);
            this.dgGrd.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgGrd_RowsAdded);
            // 
            // ficode1
            // 
            this.ficode1.DataPropertyName = "GradeId";
            this.ficode1.FillWeight = 71.90036F;
            this.ficode1.HeaderText = "Financial Create";
            this.ficode1.Name = "ficode1";
            this.ficode1.Visible = false;
            // 
            // gcode1
            // 
            this.gcode1.DataPropertyName = "Grade";
            this.gcode1.FillWeight = 171.1539F;
            this.gcode1.HeaderText = "Company Name";
            this.gcode1.Name = "gcode1";
            // 
            // RangeFrom
            // 
            this.RangeFrom.DataPropertyName = "RangeFrom";
            this.RangeFrom.FillWeight = 100.2427F;
            this.RangeFrom.HeaderText = "Range From";
            this.RangeFrom.Name = "RangeFrom";
            this.RangeFrom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // RangeTo
            // 
            this.RangeTo.DataPropertyName = "RangeTo";
            this.RangeTo.FillWeight = 116.7677F;
            this.RangeTo.HeaderText = "Range To";
            this.RangeTo.Name = "RangeTo";
            this.RangeTo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.ButtonText = "Save";
            this.btnSubmit.Location = new System.Drawing.Point(352, 280);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(72, 29);
            this.btnSubmit.TabIndex = 19;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmficodegenarate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 352);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmficodegenarate";
            this.Load += new System.EventHandler(this.frmficodegenarate_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGrd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal EDPComponent.VistaButton btnSubmit;
        public System.Windows.Forms.DataGridView dgGrd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbcompany;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ficode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RangeFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn RangeTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpfrom;
        private System.Windows.Forms.DateTimePicker dtpto;
        internal EDPComponent.VistaButton btnupdate;
        internal System.Windows.Forms.ComboBox cmbYear;
    }
}