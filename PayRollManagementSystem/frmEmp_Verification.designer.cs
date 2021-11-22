namespace PayRollManagementSystem
{
    partial class frmEmp_Verification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmp_Verification));
            this.label1 = new System.Windows.Forms.Label();
            this.rdbCompany = new System.Windows.Forms.RadioButton();
            this.rdbLocation = new System.Windows.Forms.RadioButton();
            this.rdbEmployee = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fathername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preadd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peradd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empimage = new System.Windows.Forms.DataGridViewImageColumn();
            this.ArmLicenseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerificationStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CriminalDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_save = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.CmbEmpId = new EDPComponent.ComboDialog();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.ps_id = new EDPComponent.ComboDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(320, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search by";
            // 
            // rdbCompany
            // 
            this.rdbCompany.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rdbCompany.AutoSize = true;
            this.rdbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCompany.Location = new System.Drawing.Point(416, 11);
            this.rdbCompany.Name = "rdbCompany";
            this.rdbCompany.Size = new System.Drawing.Size(84, 20);
            this.rdbCompany.TabIndex = 1;
            this.rdbCompany.TabStop = true;
            this.rdbCompany.Text = "Company";
            this.rdbCompany.UseVisualStyleBackColor = true;
            this.rdbCompany.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdbLocation
            // 
            this.rdbLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rdbLocation.AutoSize = true;
            this.rdbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLocation.Location = new System.Drawing.Point(516, 12);
            this.rdbLocation.Name = "rdbLocation";
            this.rdbLocation.Size = new System.Drawing.Size(77, 20);
            this.rdbLocation.TabIndex = 2;
            this.rdbLocation.TabStop = true;
            this.rdbLocation.Text = "Location";
            this.rdbLocation.UseVisualStyleBackColor = true;
            this.rdbLocation.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdbEmployee
            // 
            this.rdbEmployee.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rdbEmployee.AutoSize = true;
            this.rdbEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbEmployee.Location = new System.Drawing.Point(616, 12);
            this.rdbEmployee.Name = "rdbEmployee";
            this.rdbEmployee.Size = new System.Drawing.Size(88, 20);
            this.rdbEmployee.TabIndex = 3;
            this.rdbEmployee.TabStop = true;
            this.rdbEmployee.Text = "Employee";
            this.rdbEmployee.UseVisualStyleBackColor = true;
            this.rdbEmployee.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "COMPANY";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 313;
            this.label3.Text = "LOCATION";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 315;
            this.label4.Text = "EMPLOYEE";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1081, 598);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 318;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbcompany
            // 
            this.cmbcompany.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(132, 41);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(572, 21);
            this.cmbcompany.TabIndex = 319;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // cmbLocation
            // 
            this.cmbLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(132, 65);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(572, 21);
            this.cmbLocation.TabIndex = 320;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(17, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 323;
            this.label6.Text = "Police Station";
            // 
            // dgv_show
            // 
            this.dgv_show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Ename,
            this.Fathername,
            this.preadd,
            this.Mobile,
            this.dob,
            this.doj,
            this.peradd,
            this.Empimage,
            this.ArmLicenseNo,
            this.VerificationStatus,
            this.CriminalDetails});
            this.dgv_show.Location = new System.Drawing.Point(12, 163);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.Size = new System.Drawing.Size(1144, 429);
            this.dgv_show.TabIndex = 324;
            this.dgv_show.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_show_DefaultValuesNeeded);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Ename
            // 
            this.Ename.DataPropertyName = "Ename";
            this.Ename.HeaderText = "Ename";
            this.Ename.Name = "Ename";
            // 
            // Fathername
            // 
            this.Fathername.DataPropertyName = "Fathername";
            this.Fathername.HeaderText = "Fathername";
            this.Fathername.Name = "Fathername";
            // 
            // preadd
            // 
            this.preadd.DataPropertyName = "preadd";
            this.preadd.HeaderText = "preadd";
            this.preadd.Name = "preadd";
            // 
            // Mobile
            // 
            this.Mobile.DataPropertyName = "Mobile";
            this.Mobile.HeaderText = "Mobile";
            this.Mobile.Name = "Mobile";
            // 
            // dob
            // 
            this.dob.DataPropertyName = "dob";
            this.dob.HeaderText = "dob";
            this.dob.Name = "dob";
            this.dob.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // doj
            // 
            this.doj.DataPropertyName = "doj";
            this.doj.HeaderText = "doj";
            this.doj.Name = "doj";
            // 
            // peradd
            // 
            this.peradd.DataPropertyName = "peradd";
            this.peradd.HeaderText = "peradd";
            this.peradd.Name = "peradd";
            // 
            // Empimage
            // 
            this.Empimage.DataPropertyName = "Empimage";
            this.Empimage.HeaderText = "Empimage";
            this.Empimage.Name = "Empimage";
            this.Empimage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Empimage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ArmLicenseNo
            // 
            this.ArmLicenseNo.DataPropertyName = "ArmLicenseNo";
            this.ArmLicenseNo.HeaderText = "ArmLicenseNo";
            this.ArmLicenseNo.Name = "ArmLicenseNo";
            // 
            // VerificationStatus
            // 
            this.VerificationStatus.DataPropertyName = "VerificationStatus";
            this.VerificationStatus.HeaderText = "VerificationStatus ";
            this.VerificationStatus.Items.AddRange(new object[] {
            "In Process",
            "Verified",
            "New Submitted",
            "Pending",
            "Rejected"});
            this.VerificationStatus.Name = "VerificationStatus";
            this.VerificationStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VerificationStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CriminalDetails
            // 
            this.CriminalDetails.DataPropertyName = "CriminalDetails";
            this.CriminalDetails.HeaderText = "CriminalDetails";
            this.CriminalDetails.Name = "CriminalDetails";
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(910, 598);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 326;
            this.btn_save.Text = "SAVE";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(991, 598);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 327;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // CmbEmpId
            // 
            this.CmbEmpId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CmbEmpId.Connection = null;
            this.CmbEmpId.DialogResult = "";
            this.CmbEmpId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEmpId.Location = new System.Drawing.Point(132, 89);
            this.CmbEmpId.LOVFlag = 0;
            this.CmbEmpId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmbEmpId.MaxCharLength = 500;
            this.CmbEmpId.Name = "CmbEmpId";
            this.CmbEmpId.ReturnIndex = -1;
            this.CmbEmpId.ReturnValue = "";
            this.CmbEmpId.ReturnValue_3rd = "";
            this.CmbEmpId.ReturnValue_4th = "";
            this.CmbEmpId.Size = new System.Drawing.Size(572, 21);
            this.CmbEmpId.TabIndex = 328;
            this.CmbEmpId.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbEmpId_DropDown);
            this.CmbEmpId.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbEmpId_CloseUp);
            // 
            // dtp_from
            // 
            this.dtp_from.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp_from.CustomFormat = "dd/MM/yyyy";
            this.dtp_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from.Location = new System.Drawing.Point(132, 11);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(167, 22);
            this.dtp_from.TabIndex = 329;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(17, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 330;
            this.label7.Text = "DATE";
            // 
            // ps_id
            // 
            this.ps_id.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ps_id.Connection = null;
            this.ps_id.DialogResult = "";
            this.ps_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ps_id.Location = new System.Drawing.Point(132, 125);
            this.ps_id.LOVFlag = 0;
            this.ps_id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ps_id.MaxCharLength = 500;
            this.ps_id.Name = "ps_id";
            this.ps_id.ReturnIndex = -1;
            this.ps_id.ReturnValue = "";
            this.ps_id.ReturnValue_3rd = "";
            this.ps_id.ReturnValue_4th = "";
            this.ps_id.Size = new System.Drawing.Size(572, 21);
            this.ps_id.TabIndex = 331;
            this.ps_id.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.ps_id_DropDown_1);
            this.ps_id.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.ps_id_CloseUp);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(9, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 1);
            this.panel1.TabIndex = 332;
            // 
            // frmEmp_Verification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1167, 633);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ps_id);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtp_from);
            this.Controls.Add(this.CmbEmpId);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.dgv_show);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdbEmployee);
            this.Controls.Add(this.rdbLocation);
            this.Controls.Add(this.rdbCompany);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmp_Verification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Verification";
            this.Load += new System.EventHandler(this.frmEmp_Verification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbCompany;
        private System.Windows.Forms.RadioButton rdbLocation;
        private System.Windows.Forms.RadioButton rdbEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private EDPComponent.ComboDialog cmbcompany;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_show;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btnPrint;
        private EDPComponent.ComboDialog CmbEmpId;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label label7;
        private EDPComponent.ComboDialog ps_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fathername;
        private System.Windows.Forms.DataGridViewTextBoxColumn preadd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dob;
        private System.Windows.Forms.DataGridViewTextBoxColumn doj;
        private System.Windows.Forms.DataGridViewTextBoxColumn peradd;
        private System.Windows.Forms.DataGridViewImageColumn Empimage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArmLicenseNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn VerificationStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CriminalDetails;
        private System.Windows.Forms.Panel panel1;
    }
}