namespace PayRollManagementSystem
{
    partial class frmPaymentRegisterReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaymentRegisterReport));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnPrint = new EDPComponent.VistaButton();
            this.btnPreview = new EDPComponent.VistaButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpZone = new System.Windows.Forms.GroupBox();
            this.cmbZone = new EDPComponent.ComboDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.rdbZone = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbclient = new EDPComponent.ComboDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.cmblocation = new EDPComponent.ComboDialog();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.rdb_location = new System.Windows.Forms.RadioButton();
            this.rdb_client = new System.Windows.Forms.RadioButton();
            this.rdb_company = new System.Windows.Forms.RadioButton();
            this.rdb_all = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnPreview);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 72);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Print Options";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.SlateGray;
            this.btnClose.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.GlowColor = System.Drawing.Color.Aqua;
            this.btnClose.Location = new System.Drawing.Point(399, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 29);
            this.btnClose.TabIndex = 316;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BaseColor = System.Drawing.Color.SlateGray;
            this.btnPrint.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnPrint.ButtonText = "Print";
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.GlowColor = System.Drawing.Color.Aqua;
            this.btnPrint.Location = new System.Drawing.Point(47, 22);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 29);
            this.btnPrint.TabIndex = 315;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.BaseColor = System.Drawing.Color.SlateGray;
            this.btnPreview.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnPreview.ButtonText = "Preview";
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.GlowColor = System.Drawing.Color.Aqua;
            this.btnPreview.Location = new System.Drawing.Point(306, 22);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(87, 29);
            this.btnPreview.TabIndex = 314;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpZone);
            this.groupBox1.Controls.Add(this.rdbZone);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbclient);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmblocation);
            this.groupBox1.Controls.Add(this.cmbcompany);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rdb_location);
            this.groupBox1.Controls.Add(this.rdb_client);
            this.groupBox1.Controls.Add(this.rdb_company);
            this.groupBox1.Controls.Add(this.rdb_all);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 221);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail";
            // 
            // grpZone
            // 
            this.grpZone.Controls.Add(this.cmbZone);
            this.grpZone.Controls.Add(this.label8);
            this.grpZone.Location = new System.Drawing.Point(9, 157);
            this.grpZone.Name = "grpZone";
            this.grpZone.Size = new System.Drawing.Size(493, 58);
            this.grpZone.TabIndex = 329;
            this.grpZone.TabStop = false;
            // 
            // cmbZone
            // 
            this.cmbZone.Connection = null;
            this.cmbZone.DialogResult = "";
            this.cmbZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbZone.Location = new System.Drawing.Point(81, 22);
            this.cmbZone.LOVFlag = 0;
            this.cmbZone.MaxCharLength = 500;
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.ReturnIndex = -1;
            this.cmbZone.ReturnValue = "";
            this.cmbZone.ReturnValue_3rd = "";
            this.cmbZone.ReturnValue_4th = "";
            this.cmbZone.Size = new System.Drawing.Size(396, 21);
            this.cmbZone.TabIndex = 328;
            this.cmbZone.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbZone_DropDown);
            this.cmbZone.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbZone_CloseUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 313;
            this.label8.Text = "Zone";
            // 
            // rdbZone
            // 
            this.rdbZone.AutoSize = true;
            this.rdbZone.Checked = true;
            this.rdbZone.Location = new System.Drawing.Point(423, 24);
            this.rdbZone.Name = "rdbZone";
            this.rdbZone.Size = new System.Drawing.Size(63, 21);
            this.rdbZone.TabIndex = 327;
            this.rdbZone.TabStop = true;
            this.rdbZone.Text = "Zone";
            this.rdbZone.UseVisualStyleBackColor = true;
            this.rdbZone.CheckedChanged += new System.EventHandler(this.rdb_all_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 315;
            this.label6.Text = "Client";
            // 
            // cmbclient
            // 
            this.cmbclient.Connection = null;
            this.cmbclient.DialogResult = "";
            this.cmbclient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclient.Location = new System.Drawing.Point(90, 104);
            this.cmbclient.LOVFlag = 0;
            this.cmbclient.MaxCharLength = 500;
            this.cmbclient.Name = "cmbclient";
            this.cmbclient.ReturnIndex = -1;
            this.cmbclient.ReturnValue = "";
            this.cmbclient.ReturnValue_3rd = "";
            this.cmbclient.ReturnValue_4th = "";
            this.cmbclient.Size = new System.Drawing.Size(396, 21);
            this.cmbclient.TabIndex = 314;
            this.cmbclient.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbclient_DropDown);
            this.cmbclient.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbclient_CloseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 313;
            this.label5.Text = "Location";
            // 
            // cmblocation
            // 
            this.cmblocation.Connection = null;
            this.cmblocation.DialogResult = "";
            this.cmblocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblocation.Location = new System.Drawing.Point(90, 131);
            this.cmblocation.LOVFlag = 0;
            this.cmblocation.MaxCharLength = 500;
            this.cmblocation.Name = "cmblocation";
            this.cmblocation.ReturnIndex = -1;
            this.cmblocation.ReturnValue = "";
            this.cmblocation.ReturnValue_3rd = "";
            this.cmblocation.ReturnValue_4th = "";
            this.cmblocation.Size = new System.Drawing.Size(396, 21);
            this.cmblocation.TabIndex = 312;
            this.cmblocation.UseWaitCursor = true;
            this.cmblocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmblocation_DropDown);
            this.cmblocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(90, 77);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(396, 21);
            this.cmbcompany.TabIndex = 311;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Company";
            // 
            // rdb_location
            // 
            this.rdb_location.AutoSize = true;
            this.rdb_location.Location = new System.Drawing.Point(322, 24);
            this.rdb_location.Name = "rdb_location";
            this.rdb_location.Size = new System.Drawing.Size(88, 21);
            this.rdb_location.TabIndex = 4;
            this.rdb_location.TabStop = true;
            this.rdb_location.Text = "Location";
            this.rdb_location.UseVisualStyleBackColor = true;
            this.rdb_location.CheckedChanged += new System.EventHandler(this.rdb_all_CheckedChanged);
            // 
            // rdb_client
            // 
            this.rdb_client.AutoSize = true;
            this.rdb_client.Location = new System.Drawing.Point(246, 24);
            this.rdb_client.Name = "rdb_client";
            this.rdb_client.Size = new System.Drawing.Size(67, 21);
            this.rdb_client.TabIndex = 3;
            this.rdb_client.TabStop = true;
            this.rdb_client.Text = "Client";
            this.rdb_client.UseVisualStyleBackColor = true;
            this.rdb_client.CheckedChanged += new System.EventHandler(this.rdb_all_CheckedChanged);
            // 
            // rdb_company
            // 
            this.rdb_company.AutoSize = true;
            this.rdb_company.Location = new System.Drawing.Point(148, 22);
            this.rdb_company.Name = "rdb_company";
            this.rdb_company.Size = new System.Drawing.Size(92, 21);
            this.rdb_company.TabIndex = 2;
            this.rdb_company.TabStop = true;
            this.rdb_company.Text = "Company";
            this.rdb_company.UseVisualStyleBackColor = true;
            this.rdb_company.CheckedChanged += new System.EventHandler(this.rdb_all_CheckedChanged);
            // 
            // rdb_all
            // 
            this.rdb_all.AutoSize = true;
            this.rdb_all.Location = new System.Drawing.Point(90, 22);
            this.rdb_all.Name = "rdb_all";
            this.rdb_all.Size = new System.Drawing.Size(44, 21);
            this.rdb_all.TabIndex = 1;
            this.rdb_all.TabStop = true;
            this.rdb_all.Text = "All";
            this.rdb_all.UseVisualStyleBackColor = false;
            this.rdb_all.UseWaitCursor = true;
            this.rdb_all.CheckedChanged += new System.EventHandler(this.rdb_all_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Search By";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Date Form";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Date To";
            // 
            // dtp_to
            // 
            this.dtp_to.CustomFormat = "dd/MM/yyyy";
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(418, 8);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(96, 20);
            this.dtp_to.TabIndex = 49;
            // 
            // dtp_from
            // 
            this.dtp_from.CustomFormat = "dd/MM/yyyy";
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from.Location = new System.Drawing.Point(258, 8);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(102, 20);
            this.dtp_from.TabIndex = 49;
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.ForeColor = System.Drawing.Color.Black;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(75, 8);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(102, 21);
            this.cmbYear.TabIndex = 260;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(13, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 15);
            this.label22.TabIndex = 261;
            this.label22.Text = "Session";
            // 
            // frmPaymentRegisterReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(551, 377);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.dtp_from);
            this.Controls.Add(this.dtp_to);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPaymentRegisterReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt Register";
            this.Load += new System.EventHandler(this.frmPaymentRegisterReport_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpZone.ResumeLayout(false);
            this.grpZone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnPrint;
        private EDPComponent.VistaButton btnPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.RadioButton rdb_location;
        private System.Windows.Forms.RadioButton rdb_client;
        private System.Windows.Forms.RadioButton rdb_company;
        private System.Windows.Forms.RadioButton rdb_all;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private EDPComponent.ComboDialog cmblocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private EDPComponent.ComboDialog cmbclient;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RadioButton rdbZone;
        private EDPComponent.ComboDialog cmbZone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grpZone;
    }
}