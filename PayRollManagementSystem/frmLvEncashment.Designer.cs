namespace PayRollManagementSystem
{
    partial class frmLvEncashment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLvEncashment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClid = new System.Windows.Forms.Label();
            this.Lbl_coid = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkAllLocation = new System.Windows.Forms.CheckBox();
            this.cmbZone = new EDPComponent.ComboDialog();
            this.lblLid = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.txtcalculated_days = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dtp_DOE = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.lblidate = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new EDPComponent.VistaButton();
            this.btnclose_frm = new EDPComponent.VistaButton();
            this.btnSubmit = new EDPComponent.VistaButton();
            this.dgvLv = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblClid);
            this.groupBox1.Controls.Add(this.Lbl_coid);
            this.groupBox1.Controls.Add(this.txtClient);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkAllLocation);
            this.groupBox1.Controls.Add(this.cmbZone);
            this.groupBox1.Controls.Add(this.lblLid);
            this.groupBox1.Controls.Add(this.cmbLocation);
            this.groupBox1.Controls.Add(this.txtcalculated_days);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.dtp_DOE);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.AttenDtTmPkr);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.lblidate);
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 116);
            this.groupBox1.TabIndex = 265;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(715, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 87);
            this.label1.TabIndex = 324;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // lblClid
            // 
            this.lblClid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblClid.AutoSize = true;
            this.lblClid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClid.Location = new System.Drawing.Point(675, 91);
            this.lblClid.Name = "lblClid";
            this.lblClid.Size = new System.Drawing.Size(2, 15);
            this.lblClid.TabIndex = 323;
            this.lblClid.Visible = false;
            // 
            // Lbl_coid
            // 
            this.Lbl_coid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Lbl_coid.AutoSize = true;
            this.Lbl_coid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_coid.Location = new System.Drawing.Point(674, 43);
            this.Lbl_coid.Name = "Lbl_coid";
            this.Lbl_coid.Size = new System.Drawing.Size(2, 15);
            this.Lbl_coid.TabIndex = 322;
            this.Lbl_coid.Visible = false;
            // 
            // txtClient
            // 
            this.txtClient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClient.Enabled = false;
            this.txtClient.ForeColor = System.Drawing.Color.Black;
            this.txtClient.Location = new System.Drawing.Point(107, 88);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(549, 20);
            this.txtClient.TabIndex = 318;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 317;
            this.label8.Text = "Client Name";
            // 
            // chkAllLocation
            // 
            this.chkAllLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkAllLocation.AutoSize = true;
            this.chkAllLocation.Location = new System.Drawing.Point(17, 43);
            this.chkAllLocation.Name = "chkAllLocation";
            this.chkAllLocation.Size = new System.Drawing.Size(84, 17);
            this.chkAllLocation.TabIndex = 316;
            this.chkAllLocation.Text = "Select Zone";
            this.chkAllLocation.UseVisualStyleBackColor = true;
            this.chkAllLocation.Visible = false;
            // 
            // cmbZone
            // 
            this.cmbZone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbZone.Connection = null;
            this.cmbZone.DialogResult = "";
            this.cmbZone.Location = new System.Drawing.Point(107, 41);
            this.cmbZone.LOVFlag = 0;
            this.cmbZone.MaxCharLength = 500;
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.ReturnIndex = -1;
            this.cmbZone.ReturnValue = "";
            this.cmbZone.ReturnValue_3rd = "";
            this.cmbZone.ReturnValue_4th = "";
            this.cmbZone.Size = new System.Drawing.Size(325, 21);
            this.cmbZone.TabIndex = 315;
            this.cmbZone.Visible = false;
            // 
            // lblLid
            // 
            this.lblLid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLid.AutoSize = true;
            this.lblLid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLid.Location = new System.Drawing.Point(675, 65);
            this.lblLid.Name = "lblLid";
            this.lblLid.Size = new System.Drawing.Size(2, 15);
            this.lblLid.TabIndex = 285;
            this.lblLid.Visible = false;
            // 
            // cmbLocation
            // 
            this.cmbLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Location = new System.Drawing.Point(107, 65);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(549, 21);
            this.cmbLocation.TabIndex = 284;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // txtcalculated_days
            // 
            this.txtcalculated_days.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtcalculated_days.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcalculated_days.Location = new System.Drawing.Point(602, 16);
            this.txtcalculated_days.Name = "txtcalculated_days";
            this.txtcalculated_days.ReadOnly = true;
            this.txtcalculated_days.Size = new System.Drawing.Size(54, 20);
            this.txtcalculated_days.TabIndex = 276;
            this.txtcalculated_days.Text = "30";
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(14, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 13);
            this.label22.TabIndex = 257;
            this.label22.Text = "Session";
            // 
            // dtp_DOE
            // 
            this.dtp_DOE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp_DOE.Checked = false;
            this.dtp_DOE.CustomFormat = "dd/MM/yyyy";
            this.dtp_DOE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DOE.Location = new System.Drawing.Point(530, 40);
            this.dtp_DOE.Name = "dtp_DOE";
            this.dtp_DOE.Size = new System.Drawing.Size(126, 20);
            this.dtp_DOE.TabIndex = 263;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(451, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 258;
            this.label9.Text = "Date";
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(343, 15);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(139, 20);
            this.AttenDtTmPkr.TabIndex = 263;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.AttenDtTmPkr_ValueChanged);
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(248, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 13);
            this.label21.TabIndex = 258;
            this.label21.Text = "For The Month of";
            // 
            // lblidate
            // 
            this.lblidate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblidate.AutoSize = true;
            this.lblidate.Location = new System.Drawing.Point(527, 18);
            this.lblidate.Name = "lblidate";
            this.lblidate.Size = new System.Drawing.Size(71, 13);
            this.lblidate.TabIndex = 262;
            this.lblidate.Text = "Days of Basis";
            // 
            // cmbYear
            // 
            this.cmbYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(107, 15);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(118, 21);
            this.cmbYear.TabIndex = 256;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 259;
            this.label2.Text = "Location";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 491);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 56);
            this.panel1.TabIndex = 266;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnclose_frm);
            this.panel2.Controls.Add(this.btnSubmit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 56);
            this.panel2.TabIndex = 267;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExport.BackgroundImage")));
            this.btnExport.ButtonText = "Export";
            this.btnExport.Location = new System.Drawing.Point(831, 13);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 31);
            this.btnExport.TabIndex = 276;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnclose_frm
            // 
            this.btnclose_frm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose_frm.BackColor = System.Drawing.Color.Transparent;
            this.btnclose_frm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose_frm.BackgroundImage")));
            this.btnclose_frm.ButtonText = "Close";
            this.btnclose_frm.Location = new System.Drawing.Point(932, 13);
            this.btnclose_frm.Name = "btnclose_frm";
            this.btnclose_frm.Size = new System.Drawing.Size(80, 31);
            this.btnclose_frm.TabIndex = 276;
            this.btnclose_frm.Click += new System.EventHandler(this.btnclose_frm_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.ButtonText = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(745, 13);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 31);
            this.btnSubmit.TabIndex = 275;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvLv
            // 
            this.dgvLv.AllowUserToAddRows = false;
            this.dgvLv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLv.BackgroundColor = System.Drawing.Color.White;
            this.dgvLv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLv.Location = new System.Drawing.Point(0, 116);
            this.dgvLv.Name = "dgvLv";
            this.dgvLv.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLv.Size = new System.Drawing.Size(1024, 375);
            this.dgvLv.TabIndex = 267;
            this.dgvLv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLv_CellValueChanged);
            // 
            // frmLvEncashment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 547);
            this.Controls.Add(this.dgvLv);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLvEncashment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leave Balance and Encashment";
            this.Load += new System.EventHandler(this.frmLvEncashment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblClid;
        private System.Windows.Forms.Label Lbl_coid;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkAllLocation;
        private EDPComponent.ComboDialog cmbZone;
        private System.Windows.Forms.Label lblLid;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.TextBox txtcalculated_days;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtp_DOE;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblidate;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvLv;
        private System.Windows.Forms.Panel panel2;
        private EDPComponent.VistaButton btnSubmit;
        private EDPComponent.VistaButton btnclose_frm;
        private System.Windows.Forms.Label label1;
        private EDPComponent.VistaButton btnExport;
    }
}