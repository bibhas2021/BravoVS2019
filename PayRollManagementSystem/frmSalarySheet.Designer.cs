namespace PayRollManagementSystem
{
    partial class frmSalarySheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalarySheet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.chkZone = new System.Windows.Forms.CheckBox();
            this.cmbZone = new EDPComponent.ComboDialog();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.dtp_DOE = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.txtcalculated_days = new System.Windows.Forms.TextBox();
            this.lblidate = new System.Windows.Forms.Label();
            this.chkAuthorise = new System.Windows.Forms.CheckBox();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.btnclose_frm = new EDPComponent.VistaButton();
            this.btnSubmit = new EDPComponent.VistaButton();
            this.dgvSalary = new System.Windows.Forms.DataGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtcalculated_days);
            this.splitContainer1.Panel1.Controls.Add(this.lblidate);
            this.splitContainer1.Panel1.Controls.Add(this.label22);
            this.splitContainer1.Panel1.Controls.Add(this.cmbYear);
            this.splitContainer1.Panel1.Controls.Add(this.AttenDtTmPkr);
            this.splitContainer1.Panel1.Controls.Add(this.label21);
            this.splitContainer1.Panel1.Controls.Add(this.dtp_DOE);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.cmbLocation);
            this.splitContainer1.Panel1.Controls.Add(this.cmbZone);
            this.splitContainer1.Panel1.Controls.Add(this.chkZone);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1131, 514);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvSalary);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chkAuthorise);
            this.splitContainer2.Panel2.Controls.Add(this.vistaButton1);
            this.splitContainer2.Panel2.Controls.Add(this.btnclose_frm);
            this.splitContainer2.Panel2.Controls.Add(this.btnSubmit);
            this.splitContainer2.Size = new System.Drawing.Size(1131, 417);
            this.splitContainer2.SplitterDistance = 373;
            this.splitContainer2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(447, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Location";
            // 
            // chkZone
            // 
            this.chkZone.AutoSize = true;
            this.chkZone.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkZone.Location = new System.Drawing.Point(450, 14);
            this.chkZone.Name = "chkZone";
            this.chkZone.Size = new System.Drawing.Size(87, 17);
            this.chkZone.TabIndex = 317;
            this.chkZone.Text = "Select Zone";
            this.chkZone.UseVisualStyleBackColor = true;
            // 
            // cmbZone
            // 
            this.cmbZone.Connection = null;
            this.cmbZone.DialogResult = "";
            this.cmbZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbZone.Location = new System.Drawing.Point(543, 13);
            this.cmbZone.LOVFlag = 0;
            this.cmbZone.MaxCharLength = 500;
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.ReturnIndex = -1;
            this.cmbZone.ReturnValue = "";
            this.cmbZone.ReturnValue_3rd = "";
            this.cmbZone.ReturnValue_4th = "";
            this.cmbZone.Size = new System.Drawing.Size(299, 21);
            this.cmbZone.TabIndex = 318;
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(544, 39);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(549, 21);
            this.cmbLocation.TabIndex = 319;
            // 
            // dtp_DOE
            // 
            this.dtp_DOE.Checked = false;
            this.dtp_DOE.CustomFormat = "dd/MM/yyyy";
            this.dtp_DOE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DOE.Location = new System.Drawing.Point(340, 13);
            this.dtp_DOE.Name = "dtp_DOE";
            this.dtp_DOE.Size = new System.Drawing.Size(93, 20);
            this.dtp_DOE.TabIndex = 321;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(253, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 320;
            this.label9.Text = "Date of Salary";
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(108, 15);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(139, 20);
            this.AttenDtTmPkr.TabIndex = 323;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(7, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 13);
            this.label21.TabIndex = 322;
            this.label21.Text = "For The Month of";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(7, 46);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 15);
            this.label22.TabIndex = 325;
            this.label22.Text = "Session";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(108, 41);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(139, 22);
            this.cmbYear.TabIndex = 324;
            // 
            // txtcalculated_days
            // 
            this.txtcalculated_days.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcalculated_days.ForeColor = System.Drawing.Color.Black;
            this.txtcalculated_days.Location = new System.Drawing.Point(367, 42);
            this.txtcalculated_days.Name = "txtcalculated_days";
            this.txtcalculated_days.Size = new System.Drawing.Size(66, 20);
            this.txtcalculated_days.TabIndex = 327;
            this.txtcalculated_days.Text = "0";
            this.txtcalculated_days.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblidate
            // 
            this.lblidate.AutoSize = true;
            this.lblidate.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidate.Location = new System.Drawing.Point(253, 44);
            this.lblidate.Name = "lblidate";
            this.lblidate.Size = new System.Drawing.Size(113, 13);
            this.lblidate.TabIndex = 326;
            this.lblidate.Text = "Days of Calculation ";
            // 
            // chkAuthorise
            // 
            this.chkAuthorise.AutoSize = true;
            this.chkAuthorise.Location = new System.Drawing.Point(794, 11);
            this.chkAuthorise.Name = "chkAuthorise";
            this.chkAuthorise.Size = new System.Drawing.Size(71, 18);
            this.chkAuthorise.TabIndex = 288;
            this.chkAuthorise.Text = "Authorise";
            this.chkAuthorise.UseVisualStyleBackColor = true;
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vistaButton1.BackgroundImage")));
            this.vistaButton1.ButtonText = "Delete";
            this.vistaButton1.Location = new System.Drawing.Point(956, 6);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(80, 29);
            this.vistaButton1.TabIndex = 287;
            // 
            // btnclose_frm
            // 
            this.btnclose_frm.BackColor = System.Drawing.Color.Transparent;
            this.btnclose_frm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose_frm.BackgroundImage")));
            this.btnclose_frm.ButtonText = "Close";
            this.btnclose_frm.Location = new System.Drawing.Point(1039, 6);
            this.btnclose_frm.Name = "btnclose_frm";
            this.btnclose_frm.Size = new System.Drawing.Size(80, 29);
            this.btnclose_frm.TabIndex = 286;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.ButtonText = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(873, 6);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 29);
            this.btnSubmit.TabIndex = 285;
            // 
            // dgvSalary
            // 
            this.dgvSalary.AllowUserToAddRows = false;
            this.dgvSalary.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalary.Location = new System.Drawing.Point(0, 0);
            this.dgvSalary.Name = "dgvSalary";
            this.dgvSalary.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSalary.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalary.Size = new System.Drawing.Size(1131, 373);
            this.dgvSalary.TabIndex = 1;
            // 
            // frmSalarySheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1131, 514);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalarySheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary Sheet";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkZone;
        private EDPComponent.ComboDialog cmbZone;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.DateTimePicker dtp_DOE;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.TextBox txtcalculated_days;
        private System.Windows.Forms.Label lblidate;
        private System.Windows.Forms.CheckBox chkAuthorise;
        private EDPComponent.VistaButton vistaButton1;
        private EDPComponent.VistaButton btnclose_frm;
        private EDPComponent.VistaButton btnSubmit;
        private System.Windows.Forms.DataGridView dgvSalary;
    }
}