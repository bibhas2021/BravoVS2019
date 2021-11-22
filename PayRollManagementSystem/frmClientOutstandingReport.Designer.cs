namespace PayRollManagementSystem
{
    partial class frmClientOutstandingReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientOutstandingReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCompany = new EDPComponent.ComboDialog();
            this.rbBillWise = new System.Windows.Forms.RadioButton();
            this.rbClientWise = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectClient = new EDPComponent.VistaButton();
            this.cbSelectAllClient = new System.Windows.Forms.CheckBox();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnCLear = new EDPComponent.VistaButton();
            this.rdb_location = new System.Windows.Forms.RadioButton();
            this.rdbZone = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Range Details";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.ForeColor = System.Drawing.Color.Black;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(68, 20);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(102, 21);
            this.cmbYear.TabIndex = 263;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(9, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 15);
            this.label22.TabIndex = 262;
            this.label22.Text = "Session";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(284, 49);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(96, 20);
            this.dtpDateTo.TabIndex = 3;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(73, 49);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(96, 20);
            this.dtpFromDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 320;
            this.label3.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.Connection = null;
            this.cmbCompany.DialogResult = "";
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.Location = new System.Drawing.Point(81, 108);
            this.cmbCompany.LOVFlag = 0;
            this.cmbCompany.MaxCharLength = 500;
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.ReturnIndex = -1;
            this.cmbCompany.ReturnValue = "";
            this.cmbCompany.ReturnValue_3rd = "";
            this.cmbCompany.ReturnValue_4th = "";
            this.cmbCompany.Size = new System.Drawing.Size(350, 21);
            this.cmbCompany.TabIndex = 319;
            this.cmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbCompany_DropDown);
            this.cmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbCompany_CloseUp);
            // 
            // rbBillWise
            // 
            this.rbBillWise.AutoSize = true;
            this.rbBillWise.Location = new System.Drawing.Point(12, 144);
            this.rbBillWise.Name = "rbBillWise";
            this.rbBillWise.Size = new System.Drawing.Size(65, 17);
            this.rbBillWise.TabIndex = 321;
            this.rbBillWise.TabStop = true;
            this.rbBillWise.Text = "Bill Wise";
            this.rbBillWise.UseVisualStyleBackColor = true;
            this.rbBillWise.CheckedChanged += new System.EventHandler(this.rbBillWise_CheckedChanged);
            // 
            // rbClientWise
            // 
            this.rbClientWise.AutoSize = true;
            this.rbClientWise.Location = new System.Drawing.Point(118, 144);
            this.rbClientWise.Name = "rbClientWise";
            this.rbClientWise.Size = new System.Drawing.Size(78, 17);
            this.rbClientWise.TabIndex = 322;
            this.rbClientWise.TabStop = true;
            this.rbClientWise.Text = "Client Wise";
            this.rbClientWise.UseVisualStyleBackColor = true;
            this.rbClientWise.CheckedChanged += new System.EventHandler(this.rbClientWise_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectClient);
            this.groupBox2.Controls.Add(this.cbSelectAllClient);
            this.groupBox2.Location = new System.Drawing.Point(11, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 57);
            this.groupBox2.TabIndex = 323;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Details";
            // 
            // btnSelectClient
            // 
            this.btnSelectClient.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectClient.BaseColor = System.Drawing.Color.SlateGray;
            this.btnSelectClient.ButtonColor = System.Drawing.Color.MidnightBlue;
            this.btnSelectClient.ButtonText = "Select Clients / Location";
            this.btnSelectClient.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectClient.GlowColor = System.Drawing.Color.Azure;
            this.btnSelectClient.HighlightColor = System.Drawing.Color.AliceBlue;
            this.btnSelectClient.Location = new System.Drawing.Point(9, 19);
            this.btnSelectClient.Name = "btnSelectClient";
            this.btnSelectClient.Size = new System.Drawing.Size(175, 27);
            this.btnSelectClient.TabIndex = 315;
            this.btnSelectClient.Click += new System.EventHandler(this.btnSelectClient_Click);
            // 
            // cbSelectAllClient
            // 
            this.cbSelectAllClient.AutoSize = true;
            this.cbSelectAllClient.Location = new System.Drawing.Point(315, 29);
            this.cbSelectAllClient.Name = "cbSelectAllClient";
            this.cbSelectAllClient.Size = new System.Drawing.Size(99, 17);
            this.cbSelectAllClient.TabIndex = 0;
            this.cbSelectAllClient.Text = "Select All Client";
            this.cbSelectAllClient.UseVisualStyleBackColor = true;
            this.cbSelectAllClient.Click += new System.EventHandler(this.cbSelectAllClient_Click);
            this.cbSelectAllClient.CheckedChanged += new System.EventHandler(this.cbSelectAllClient_CheckedChanged);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.BaseColor = System.Drawing.Color.SlateGray;
            this.btnPreview.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnPreview.ButtonText = "Preview";
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.GlowColor = System.Drawing.Color.Aqua;
            this.btnPreview.Location = new System.Drawing.Point(291, 239);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(72, 29);
            this.btnPreview.TabIndex = 324;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCLear
            // 
            this.btnCLear.BackColor = System.Drawing.Color.Transparent;
            this.btnCLear.BaseColor = System.Drawing.Color.SlateGray;
            this.btnCLear.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnCLear.ButtonText = "Close";
            this.btnCLear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLear.GlowColor = System.Drawing.Color.Aqua;
            this.btnCLear.Location = new System.Drawing.Point(370, 239);
            this.btnCLear.Name = "btnCLear";
            this.btnCLear.Size = new System.Drawing.Size(62, 29);
            this.btnCLear.TabIndex = 325;
            this.btnCLear.Click += new System.EventHandler(this.btnCLear_Click);
            // 
            // rdb_location
            // 
            this.rdb_location.AutoSize = true;
            this.rdb_location.Location = new System.Drawing.Point(221, 144);
            this.rdb_location.Name = "rdb_location";
            this.rdb_location.Size = new System.Drawing.Size(93, 17);
            this.rdb_location.TabIndex = 322;
            this.rdb_location.TabStop = true;
            this.rdb_location.Text = "Location Wise";
            this.rdb_location.UseVisualStyleBackColor = true;
            this.rdb_location.CheckedChanged += new System.EventHandler(this.rbClientWise_CheckedChanged);
            // 
            // rdbZone
            // 
            this.rdbZone.AutoSize = true;
            this.rdbZone.Location = new System.Drawing.Point(343, 144);
            this.rdbZone.Name = "rdbZone";
            this.rdbZone.Size = new System.Drawing.Size(50, 17);
            this.rdbZone.TabIndex = 326;
            this.rdbZone.Text = "Zone";
            this.rdbZone.UseVisualStyleBackColor = true;
            this.rdbZone.CheckedChanged += new System.EventHandler(this.rbBillWise_CheckedChanged);
            // 
            // frmClientOutstandingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 275);
            this.Controls.Add(this.rdbZone);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnCLear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rdb_location);
            this.Controls.Add(this.rbClientWise);
            this.Controls.Add(this.rbBillWise);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClientOutstandingReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill Outstanding Report";
            this.Load += new System.EventHandler(this.frmClientOutstandingReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label3;
        private EDPComponent.ComboDialog cmbCompany;
        private System.Windows.Forms.RadioButton rbBillWise;
        private System.Windows.Forms.RadioButton rbClientWise;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbSelectAllClient;
        private EDPComponent.VistaButton btnSelectClient;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnCLear;
        private System.Windows.Forms.RadioButton rdb_location;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.RadioButton rdbZone;
    }
}