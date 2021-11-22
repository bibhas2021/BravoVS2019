namespace PayRollManagementSystem
{
    partial class frmStatusLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatusLog));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbEmp = new EDPComponent.ComboDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbLoc = new EDPComponent.ComboDialog();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.lblLoc = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dtpStatus = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus_old = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.cmbStaus = new System.Windows.Forms.ComboBox();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbEmp);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblCompany);
            this.groupBox2.Controls.Add(this.cmbLoc);
            this.groupBox2.Controls.Add(this.cmbcompany);
            this.groupBox2.Controls.Add(this.lblLoc);
            this.groupBox2.Location = new System.Drawing.Point(32, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 122);
            this.groupBox2.TabIndex = 266;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Options";
            // 
            // cmbEmp
            // 
            this.cmbEmp.Connection = null;
            this.cmbEmp.DialogResult = "";
            this.cmbEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmp.Location = new System.Drawing.Point(106, 77);
            this.cmbEmp.LOVFlag = 0;
            this.cmbEmp.MaxCharLength = 500;
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.ReturnIndex = -1;
            this.cmbEmp.ReturnValue = "";
            this.cmbEmp.ReturnValue_3rd = "";
            this.cmbEmp.ReturnValue_4th = "";
            this.cmbEmp.Size = new System.Drawing.Size(360, 21);
            this.cmbEmp.TabIndex = 294;
            this.cmbEmp.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbEmp_DropDown);
            this.cmbEmp.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbEmp_CloseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 295;
            this.label6.Text = "Employee";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(7, 27);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(82, 13);
            this.lblCompany.TabIndex = 293;
            this.lblCompany.Text = "Company Name";
            // 
            // cmbLoc
            // 
            this.cmbLoc.Connection = null;
            this.cmbLoc.DialogResult = "";
            this.cmbLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoc.Location = new System.Drawing.Point(106, 50);
            this.cmbLoc.LOVFlag = 0;
            this.cmbLoc.MaxCharLength = 500;
            this.cmbLoc.Name = "cmbLoc";
            this.cmbLoc.ReturnIndex = -1;
            this.cmbLoc.ReturnValue = "";
            this.cmbLoc.ReturnValue_3rd = "";
            this.cmbLoc.ReturnValue_4th = "";
            this.cmbLoc.Size = new System.Drawing.Size(360, 21);
            this.cmbLoc.TabIndex = 292;
            this.cmbLoc.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLoc_DropDown);
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(106, 24);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(360, 21);
            this.cmbcompany.TabIndex = 292;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Location = new System.Drawing.Point(7, 54);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(48, 13);
            this.lblLoc.TabIndex = 265;
            this.lblLoc.Text = "Location";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(32, 140);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dtpStatus);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus_old);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.txtRemarks);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.label167);
            this.splitContainer1.Panel1.Controls.Add(this.cmbStaus);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvEmployee);
            this.splitContainer1.Size = new System.Drawing.Size(513, 382);
            this.splitContainer1.SplitterDistance = 154;
            this.splitContainer1.TabIndex = 267;
            // 
            // dtpStatus
            // 
            this.dtpStatus.CustomFormat = "dd/MM/yyyy";
            this.dtpStatus.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStatus.Location = new System.Drawing.Point(106, 41);
            this.dtpStatus.Name = "dtpStatus";
            this.dtpStatus.Size = new System.Drawing.Size(200, 20);
            this.dtpStatus.TabIndex = 344;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 343;
            this.label1.Text = "Status Date";
            // 
            // lblStatus_old
            // 
            this.lblStatus_old.AutoSize = true;
            this.lblStatus_old.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus_old.Location = new System.Drawing.Point(108, 129);
            this.lblStatus_old.Name = "lblStatus_old";
            this.lblStatus_old.Size = new System.Drawing.Size(2, 15);
            this.lblStatus_old.TabIndex = 342;
            this.lblStatus_old.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(391, 123);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 341;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(106, 72);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(360, 45);
            this.txtRemarks.TabIndex = 339;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(12, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 340;
            this.label15.Text = "Reason";
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label167.Location = new System.Drawing.Point(12, 14);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(43, 13);
            this.label167.TabIndex = 338;
            this.label167.Text = "Status";
            // 
            // cmbStaus
            // 
            this.cmbStaus.FormattingEnabled = true;
            this.cmbStaus.Location = new System.Drawing.Point(106, 11);
            this.cmbStaus.Name = "cmbStaus";
            this.cmbStaus.Size = new System.Drawing.Size(360, 21);
            this.cmbStaus.TabIndex = 337;
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Location = new System.Drawing.Point(9, 10);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.Size = new System.Drawing.Size(490, 199);
            this.dgvEmployee.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Black;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(310, 123);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 341;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmStatusLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(576, 547);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStatusLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status Log";
            this.Load += new System.EventHandler(this.frmStatusLog_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCompany;
        private EDPComponent.ComboDialog cmbLoc;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.Label lblLoc;
        private EDPComponent.ComboDialog cmbEmp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.ComboBox cmbStaus;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Label lblStatus_old;
        private System.Windows.Forms.DateTimePicker dtpStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
    }
}