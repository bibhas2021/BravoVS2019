namespace PayRollManagementSystem
{
    partial class Reg_Bill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reg_Bill));
            this.cmbCompany = new EDPComponent.ComboDialog();
            this.lblCompany = new System.Windows.Forms.Label();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnPreview = new EDPComponent.VistaButton();
            this.CmbSession = new System.Windows.Forms.ComboBox();
            this.lblSession = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDOI = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_DOV = new System.Windows.Forms.DateTimePicker();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbtPeriod = new System.Windows.Forms.RadioButton();
            this.rbtVoucher = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBill_To = new EDPComponent.ComboDialog();
            this.cmbBill_from = new EDPComponent.ComboDialog();
            this.grp_period = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grpBill = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdb_ord_party = new System.Windows.Forms.RadioButton();
            this.rdb_ord_bill = new System.Windows.Forms.RadioButton();
            this.rdb_ord_Date = new System.Windows.Forms.RadioButton();
            this.rdbZone = new System.Windows.Forms.RadioButton();
            this.grp_zone = new System.Windows.Forms.GroupBox();
            this.cmbZone = new EDPComponent.ComboDialog();
            this.groupBox7.SuspendLayout();
            this.grp_period.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpBill.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grp_zone.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCompany
            // 
            this.cmbCompany.Connection = null;
            this.cmbCompany.DialogResult = "";
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.Location = new System.Drawing.Point(190, 37);
            this.cmbCompany.LOVFlag = 0;
            this.cmbCompany.MaxCharLength = 500;
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.ReturnIndex = -1;
            this.cmbCompany.ReturnValue = "";
            this.cmbCompany.ReturnValue_3rd = "";
            this.cmbCompany.ReturnValue_4th = "";
            this.cmbCompany.Size = new System.Drawing.Size(246, 21);
            this.cmbCompany.TabIndex = 298;
            this.cmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbCompany_DropDown);
            this.cmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbCompany_CloseUp);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblCompany.Location = new System.Drawing.Point(116, 40);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(66, 16);
            this.lblCompany.TabIndex = 297;
            this.lblCompany.Text = "Company";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(180, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 302;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(94, 19);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 301;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // CmbSession
            // 
            this.CmbSession.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSession.FormattingEnabled = true;
            this.CmbSession.Location = new System.Drawing.Point(190, 12);
            this.CmbSession.Name = "CmbSession";
            this.CmbSession.Size = new System.Drawing.Size(143, 21);
            this.CmbSession.TabIndex = 303;
            this.CmbSession.SelectedIndexChanged += new System.EventHandler(this.CmbSession_SelectedIndexChanged_1);
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblSession.Location = new System.Drawing.Point(116, 15);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(57, 16);
            this.lblSession.TabIndex = 304;
            this.lblSession.Text = "Session";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 305;
            this.label1.Text = "Start Date";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtpDOI
            // 
            this.dtpDOI.CustomFormat = "dd /MMMM /yyyy";
            this.dtpDOI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOI.Location = new System.Drawing.Point(146, 19);
            this.dtpDOI.Name = "dtpDOI";
            this.dtpDOI.Size = new System.Drawing.Size(108, 20);
            this.dtpDOI.TabIndex = 306;
            this.dtpDOI.ValueChanged += new System.EventHandler(this.dtpDOI_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 307;
            this.label2.Text = "End Date";
            // 
            // dtp_DOV
            // 
            this.dtp_DOV.CustomFormat = "dd /MMMM /yyyy";
            this.dtp_DOV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DOV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DOV.Location = new System.Drawing.Point(146, 44);
            this.dtp_DOV.Name = "dtp_DOV";
            this.dtp_DOV.Size = new System.Drawing.Size(108, 20);
            this.dtp_DOV.TabIndex = 308;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rdbZone);
            this.groupBox7.Controls.Add(this.rbtPeriod);
            this.groupBox7.Controls.Add(this.rbtVoucher);
            this.groupBox7.Location = new System.Drawing.Point(156, 73);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(280, 35);
            this.groupBox7.TabIndex = 309;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Selective Features";
            // 
            // rbtPeriod
            // 
            this.rbtPeriod.AutoSize = true;
            this.rbtPeriod.Location = new System.Drawing.Point(57, 13);
            this.rbtPeriod.Name = "rbtPeriod";
            this.rbtPeriod.Size = new System.Drawing.Size(55, 17);
            this.rbtPeriod.TabIndex = 0;
            this.rbtPeriod.TabStop = true;
            this.rbtPeriod.Text = "Period";
            this.rbtPeriod.UseVisualStyleBackColor = true;
            this.rbtPeriod.CheckedChanged += new System.EventHandler(this.rbtPeriod_CheckedChanged);
            // 
            // rbtVoucher
            // 
            this.rbtVoucher.AutoSize = true;
            this.rbtVoucher.Checked = true;
            this.rbtVoucher.Location = new System.Drawing.Point(132, 13);
            this.rbtVoucher.Name = "rbtVoucher";
            this.rbtVoucher.Size = new System.Drawing.Size(55, 17);
            this.rbtVoucher.TabIndex = 1;
            this.rbtVoucher.TabStop = true;
            this.rbtVoucher.Text = "Bill No";
            this.rbtVoucher.UseVisualStyleBackColor = true;
            this.rbtVoucher.CheckedChanged += new System.EventHandler(this.rbtPeriod_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 311;
            this.label4.Text = "Upto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 311;
            this.label3.Text = "From";
            // 
            // cmbBill_To
            // 
            this.cmbBill_To.Connection = null;
            this.cmbBill_To.DialogResult = "";
            this.cmbBill_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBill_To.Location = new System.Drawing.Point(76, 45);
            this.cmbBill_To.LOVFlag = 0;
            this.cmbBill_To.MaxCharLength = 500;
            this.cmbBill_To.Name = "cmbBill_To";
            this.cmbBill_To.ReturnIndex = -1;
            this.cmbBill_To.ReturnValue = "";
            this.cmbBill_To.ReturnValue_3rd = "";
            this.cmbBill_To.ReturnValue_4th = "";
            this.cmbBill_To.Size = new System.Drawing.Size(198, 21);
            this.cmbBill_To.TabIndex = 298;
            this.cmbBill_To.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbBill_To_DropDown);
            this.cmbBill_To.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbBill_To_CloseUp);
            // 
            // cmbBill_from
            // 
            this.cmbBill_from.Connection = null;
            this.cmbBill_from.DialogResult = "";
            this.cmbBill_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBill_from.Location = new System.Drawing.Point(76, 18);
            this.cmbBill_from.LOVFlag = 0;
            this.cmbBill_from.MaxCharLength = 500;
            this.cmbBill_from.Name = "cmbBill_from";
            this.cmbBill_from.ReturnIndex = -1;
            this.cmbBill_from.ReturnValue = "";
            this.cmbBill_from.ReturnValue_3rd = "";
            this.cmbBill_from.ReturnValue_4th = "";
            this.cmbBill_from.Size = new System.Drawing.Size(198, 21);
            this.cmbBill_from.TabIndex = 298;
            this.cmbBill_from.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbBill_from_DropDown);
            this.cmbBill_from.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbBill_from_CloseUp);
            // 
            // grp_period
            // 
            this.grp_period.Controls.Add(this.dtpDOI);
            this.grp_period.Controls.Add(this.label2);
            this.grp_period.Controls.Add(this.label1);
            this.grp_period.Controls.Add(this.dtp_DOV);
            this.grp_period.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_period.Location = new System.Drawing.Point(156, 115);
            this.grp_period.Name = "grp_period";
            this.grp_period.Size = new System.Drawing.Size(280, 80);
            this.grp_period.TabIndex = 311;
            this.grp_period.TabStop = false;
            this.grp_period.Text = "Period Date";
            this.grp_period.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(455, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(105, 334);
            this.groupBox1.TabIndex = 312;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(98, 334);
            this.groupBox2.TabIndex = 313;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnPreview);
            this.groupBox3.Location = new System.Drawing.Point(119, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 55);
            this.groupBox3.TabIndex = 314;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Action";
            // 
            // grpBill
            // 
            this.grpBill.Controls.Add(this.label4);
            this.grpBill.Controls.Add(this.cmbBill_from);
            this.grpBill.Controls.Add(this.label3);
            this.grpBill.Controls.Add(this.cmbBill_To);
            this.grpBill.Location = new System.Drawing.Point(156, 114);
            this.grpBill.Name = "grpBill";
            this.grpBill.Size = new System.Drawing.Size(280, 81);
            this.grpBill.TabIndex = 315;
            this.grpBill.TabStop = false;
            this.grpBill.Text = "Select Bill";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdb_ord_party);
            this.groupBox4.Controls.Add(this.rdb_ord_bill);
            this.groupBox4.Controls.Add(this.rdb_ord_Date);
            this.groupBox4.Location = new System.Drawing.Point(157, 201);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(279, 55);
            this.groupBox4.TabIndex = 320;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Order By";
            // 
            // rdb_ord_party
            // 
            this.rdb_ord_party.AutoSize = true;
            this.rdb_ord_party.Location = new System.Drawing.Point(172, 20);
            this.rdb_ord_party.Name = "rdb_ord_party";
            this.rdb_ord_party.Size = new System.Drawing.Size(101, 17);
            this.rdb_ord_party.TabIndex = 0;
            this.rdb_ord_party.TabStop = true;
            this.rdb_ord_party.Text = "Client - Location";
            this.rdb_ord_party.UseVisualStyleBackColor = true;
            // 
            // rdb_ord_bill
            // 
            this.rdb_ord_bill.AutoSize = true;
            this.rdb_ord_bill.Location = new System.Drawing.Point(93, 20);
            this.rdb_ord_bill.Name = "rdb_ord_bill";
            this.rdb_ord_bill.Size = new System.Drawing.Size(55, 17);
            this.rdb_ord_bill.TabIndex = 0;
            this.rdb_ord_bill.TabStop = true;
            this.rdb_ord_bill.Text = "Bill No";
            this.rdb_ord_bill.UseVisualStyleBackColor = true;
            // 
            // rdb_ord_Date
            // 
            this.rdb_ord_Date.AutoSize = true;
            this.rdb_ord_Date.Checked = true;
            this.rdb_ord_Date.Location = new System.Drawing.Point(11, 20);
            this.rdb_ord_Date.Name = "rdb_ord_Date";
            this.rdb_ord_Date.Size = new System.Drawing.Size(64, 17);
            this.rdb_ord_Date.TabIndex = 0;
            this.rdb_ord_Date.TabStop = true;
            this.rdb_ord_Date.Text = "Bill Date";
            this.rdb_ord_Date.UseVisualStyleBackColor = true;
            // 
            // rdbZone
            // 
            this.rdbZone.AutoSize = true;
            this.rdbZone.Location = new System.Drawing.Point(204, 13);
            this.rdbZone.Name = "rdbZone";
            this.rdbZone.Size = new System.Drawing.Size(50, 17);
            this.rdbZone.TabIndex = 307;
            this.rdbZone.Text = "Zone";
            this.rdbZone.UseVisualStyleBackColor = true;
            this.rdbZone.CheckedChanged += new System.EventHandler(this.rbtPeriod_CheckedChanged);
            // 
            // grp_zone
            // 
            this.grp_zone.Controls.Add(this.cmbZone);
            this.grp_zone.Location = new System.Drawing.Point(158, 115);
            this.grp_zone.Name = "grp_zone";
            this.grp_zone.Size = new System.Drawing.Size(276, 55);
            this.grp_zone.TabIndex = 321;
            this.grp_zone.TabStop = false;
            this.grp_zone.Text = "Select Zone";
            // 
            // cmbZone
            // 
            this.cmbZone.Connection = null;
            this.cmbZone.DialogResult = "";
            this.cmbZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbZone.Location = new System.Drawing.Point(18, 19);
            this.cmbZone.LOVFlag = 0;
            this.cmbZone.MaxCharLength = 500;
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.ReturnIndex = -1;
            this.cmbZone.ReturnValue = "";
            this.cmbZone.ReturnValue_3rd = "";
            this.cmbZone.ReturnValue_4th = "";
            this.cmbZone.Size = new System.Drawing.Size(252, 21);
            this.cmbZone.TabIndex = 298;
            this.cmbZone.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbZone_DropDown);
            // 
            // Reg_Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 334);
            this.Controls.Add(this.grp_zone);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grpBill);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp_period);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.lblSession);
            this.Controls.Add(this.CmbSession);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblCompany);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reg_Bill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill Register";
            this.Load += new System.EventHandler(this.Bill_Register_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grp_period.ResumeLayout(false);
            this.grp_period.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.grpBill.ResumeLayout(false);
            this.grpBill.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grp_zone.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.ComboDialog cmbCompany;
        private System.Windows.Forms.Label lblCompany;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnPreview;
        private System.Windows.Forms.ComboBox CmbSession;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDOI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_DOV;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rbtPeriod;
        private System.Windows.Forms.RadioButton rbtVoucher;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private EDPComponent.ComboDialog cmbBill_To;
        private EDPComponent.ComboDialog cmbBill_from;
        private System.Windows.Forms.GroupBox grp_period;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox grpBill;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdb_ord_party;
        private System.Windows.Forms.RadioButton rdb_ord_bill;
        private System.Windows.Forms.RadioButton rdb_ord_Date;
        private System.Windows.Forms.RadioButton rdbZone;
        private System.Windows.Forms.GroupBox grp_zone;
        private EDPComponent.ComboDialog cmbZone;
    }
}