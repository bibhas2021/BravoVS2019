namespace PayRollManagementSystem
{
    partial class frmHolidayEntry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Deletecmd = new EDPComponent.VistaButton();
            this.Closecmd = new EDPComponent.VistaButton();
            this.Clearcmd = new EDPComponent.VistaButton();
            this.Savecmd = new EDPComponent.VistaButton();
            this.Remarkstxt = new System.Windows.Forms.TextBox();
            this.PurposeOfDaytxt = new System.Windows.Forms.TextBox();
            this.HolidayTodtpkr = new System.Windows.Forms.DateTimePicker();
            this.HolidayFrmdtpkr = new System.Windows.Forms.DateTimePicker();
            this.NationalChkbx = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Savetag = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HolidayGrid = new System.Windows.Forms.DataGridView();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HolidayGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Deletecmd);
            this.groupBox1.Controls.Add(this.Closecmd);
            this.groupBox1.Controls.Add(this.Clearcmd);
            this.groupBox1.Controls.Add(this.Savecmd);
            this.groupBox1.Controls.Add(this.Remarkstxt);
            this.groupBox1.Controls.Add(this.PurposeOfDaytxt);
            this.groupBox1.Controls.Add(this.HolidayTodtpkr);
            this.groupBox1.Controls.Add(this.HolidayFrmdtpkr);
            this.groupBox1.Controls.Add(this.NationalChkbx);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Savetag);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(678, 223);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(388, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "To";
            // 
            // Deletecmd
            // 
            this.Deletecmd.BackColor = System.Drawing.Color.Transparent;
            this.Deletecmd.ButtonText = "Delete";
            this.Deletecmd.Location = new System.Drawing.Point(368, 190);
            this.Deletecmd.Name = "Deletecmd";
            this.Deletecmd.Size = new System.Drawing.Size(70, 26);
            this.Deletecmd.TabIndex = 7;
            this.Deletecmd.Click += new System.EventHandler(this.Deletecmd_Click);
            // 
            // Closecmd
            // 
            this.Closecmd.BackColor = System.Drawing.Color.Transparent;
            this.Closecmd.ButtonText = "Close";
            this.Closecmd.Location = new System.Drawing.Point(442, 190);
            this.Closecmd.Name = "Closecmd";
            this.Closecmd.Size = new System.Drawing.Size(70, 26);
            this.Closecmd.TabIndex = 6;
            this.Closecmd.Click += new System.EventHandler(this.Closecmd_Click);
            // 
            // Clearcmd
            // 
            this.Clearcmd.BackColor = System.Drawing.Color.Transparent;
            this.Clearcmd.ButtonText = "Clear";
            this.Clearcmd.Location = new System.Drawing.Point(219, 190);
            this.Clearcmd.Name = "Clearcmd";
            this.Clearcmd.Size = new System.Drawing.Size(70, 26);
            this.Clearcmd.TabIndex = 5;
            this.Clearcmd.Click += new System.EventHandler(this.Clearcmd_Click);
            // 
            // Savecmd
            // 
            this.Savecmd.BackColor = System.Drawing.Color.Transparent;
            this.Savecmd.ButtonText = "Save";
            this.Savecmd.Location = new System.Drawing.Point(294, 190);
            this.Savecmd.Name = "Savecmd";
            this.Savecmd.Size = new System.Drawing.Size(70, 26);
            this.Savecmd.TabIndex = 4;
            this.Savecmd.Click += new System.EventHandler(this.Savecmd_Click);
            // 
            // Remarkstxt
            // 
            this.Remarkstxt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remarkstxt.Location = new System.Drawing.Point(218, 108);
            this.Remarkstxt.Multiline = true;
            this.Remarkstxt.Name = "Remarkstxt";
            this.Remarkstxt.Size = new System.Drawing.Size(327, 78);
            this.Remarkstxt.TabIndex = 3;
            // 
            // PurposeOfDaytxt
            // 
            this.PurposeOfDaytxt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PurposeOfDaytxt.Location = new System.Drawing.Point(218, 62);
            this.PurposeOfDaytxt.Name = "PurposeOfDaytxt";
            this.PurposeOfDaytxt.Size = new System.Drawing.Size(329, 21);
            this.PurposeOfDaytxt.TabIndex = 0;
            // 
            // HolidayTodtpkr
            // 
            this.HolidayTodtpkr.CalendarTitleBackColor = System.Drawing.Color.DeepSkyBlue;
            this.HolidayTodtpkr.CustomFormat = "ddd, MMM-dd,yyyy";
            this.HolidayTodtpkr.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HolidayTodtpkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HolidayTodtpkr.Location = new System.Drawing.Point(414, 37);
            this.HolidayTodtpkr.Name = "HolidayTodtpkr";
            this.HolidayTodtpkr.Size = new System.Drawing.Size(133, 21);
            this.HolidayTodtpkr.TabIndex = 1;
            this.HolidayTodtpkr.Value = new System.DateTime(2009, 11, 1, 0, 0, 0, 0);
            // 
            // HolidayFrmdtpkr
            // 
            this.HolidayFrmdtpkr.CalendarTitleBackColor = System.Drawing.Color.DeepSkyBlue;
            this.HolidayFrmdtpkr.CustomFormat = "ddd, MMM-dd,yyyy";
            this.HolidayFrmdtpkr.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HolidayFrmdtpkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HolidayFrmdtpkr.Location = new System.Drawing.Point(414, 12);
            this.HolidayFrmdtpkr.Name = "HolidayFrmdtpkr";
            this.HolidayFrmdtpkr.Size = new System.Drawing.Size(133, 21);
            this.HolidayFrmdtpkr.TabIndex = 1;
            this.HolidayFrmdtpkr.Value = new System.DateTime(2009, 11, 1, 0, 0, 0, 0);
            this.HolidayFrmdtpkr.ValueChanged += new System.EventHandler(this.HolidayFrmdtpkr_ValueChanged);
            // 
            // NationalChkbx
            // 
            this.NationalChkbx.AutoSize = true;
            this.NationalChkbx.Location = new System.Drawing.Point(219, 87);
            this.NationalChkbx.Name = "NationalChkbx";
            this.NationalChkbx.Size = new System.Drawing.Size(211, 17);
            this.NationalChkbx.TabIndex = 2;
            this.NationalChkbx.Text = "Check If this is a national holiday";
            this.NationalChkbx.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Remarks                         :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Holiday/\r\nVacation \r\nDate:";
            // 
            // Savetag
            // 
            this.Savetag.AutoSize = true;
            this.Savetag.Location = new System.Drawing.Point(80, 65);
            this.Savetag.Name = "Savetag";
            this.Savetag.Size = new System.Drawing.Size(134, 13);
            this.Savetag.TabIndex = 0;
            this.Savetag.Tag = "0";
            this.Savetag.Text = "Purpose of the day      :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(373, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "From";
            // 
            // HolidayGrid
            // 
            this.HolidayGrid.AllowUserToAddRows = false;
            this.HolidayGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HolidayGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.HolidayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HolidayGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.HolidayGrid.Location = new System.Drawing.Point(12, 259);
            this.HolidayGrid.Name = "HolidayGrid";
            this.HolidayGrid.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HolidayGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.HolidayGrid.RowHeadersVisible = false;
            this.HolidayGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HolidayGrid.Size = new System.Drawing.Size(678, 201);
            this.HolidayGrid.TabIndex = 43;
            this.HolidayGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.HolidayGrid_CellMouseClick);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(80, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(134, 15);
            this.label22.TabIndex = 259;
            this.label22.Text = "Session                  :";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(218, 13);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(91, 21);
            this.cmbYear.TabIndex = 258;
            // 
            // frmHolidayEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(702, 474);
            this.Controls.Add(this.HolidayGrid);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHolidayEntry";
            this.Text = "Holiday List";
            this.Load += new System.EventHandler(this.frmHolidayEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HolidayGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Savetag;
        private System.Windows.Forms.CheckBox NationalChkbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Remarkstxt;
        private System.Windows.Forms.TextBox PurposeOfDaytxt;
        private System.Windows.Forms.DateTimePicker HolidayFrmdtpkr;
        private EDPComponent.VistaButton Closecmd;
        private EDPComponent.VistaButton Savecmd;
        private System.Windows.Forms.DataGridView HolidayGrid;
        private EDPComponent.VistaButton Clearcmd;
        private EDPComponent.VistaButton Deletecmd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker HolidayTodtpkr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox cmbYear;
    }
}