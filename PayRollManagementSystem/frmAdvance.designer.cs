namespace PayRollManagementSystem
{
    partial class frmAdvance
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
            this.CmbLocation = new EDPComponent.ComboDialog();
            this.LblLocation = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            this.dtmMonthSelect = new System.Windows.Forms.DateTimePicker();
            this.rdbCompany_Wise = new System.Windows.Forms.RadioButton();
            this.rdbLocation_Wise = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbKit = new System.Windows.Forms.RadioButton();
            this.rdbAdvance = new System.Windows.Forms.RadioButton();
            this.rdbLoan = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "ADVANCE TAKEN";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(482, 0);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExpExc
            // 
            this.btnExpExc.Location = new System.Drawing.Point(151, 16);
            this.btnExpExc.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(271, 16);
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrnt
            // 
            this.btnPrnt.Location = new System.Drawing.Point(359, 16);
            this.btnPrnt.Click += new System.EventHandler(this.btnPrnt_Click);
            // 
            // btnClose2
            // 
            this.btnClose2.Location = new System.Drawing.Point(443, 16);
            this.btnClose2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CmbLocation
            // 
            this.CmbLocation.Connection = null;
            this.CmbLocation.DialogResult = "";
            this.CmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLocation.Location = new System.Drawing.Point(167, 149);
            this.CmbLocation.LOVFlag = 0;
            this.CmbLocation.MaxCharLength = 500;
            this.CmbLocation.Name = "CmbLocation";
            this.CmbLocation.ReturnIndex = -1;
            this.CmbLocation.ReturnValue = "";
            this.CmbLocation.ReturnValue_3rd = "";
            this.CmbLocation.ReturnValue_4th = "";
            this.CmbLocation.Size = new System.Drawing.Size(276, 21);
            this.CmbLocation.TabIndex = 309;
            this.CmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.CmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Location = new System.Drawing.Point(62, 149);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(48, 13);
            this.LblLocation.TabIndex = 310;
            this.LblLocation.Text = "Location";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(167, 109);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(276, 21);
            this.cmbcompany.TabIndex = 307;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(62, 109);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(51, 13);
            this.LblCompany.TabIndex = 308;
            this.LblCompany.Text = "Company";
            // 
            // dtmMonthSelect
            // 
            this.dtmMonthSelect.Location = new System.Drawing.Point(167, 72);
            this.dtmMonthSelect.Name = "dtmMonthSelect";
            this.dtmMonthSelect.Size = new System.Drawing.Size(200, 20);
            this.dtmMonthSelect.TabIndex = 311;
            // 
            // rdbCompany_Wise
            // 
            this.rdbCompany_Wise.AutoSize = true;
            this.rdbCompany_Wise.Location = new System.Drawing.Point(6, 19);
            this.rdbCompany_Wise.Name = "rdbCompany_Wise";
            this.rdbCompany_Wise.Size = new System.Drawing.Size(96, 17);
            this.rdbCompany_Wise.TabIndex = 312;
            this.rdbCompany_Wise.TabStop = true;
            this.rdbCompany_Wise.Text = "Company Wise";
            this.rdbCompany_Wise.UseVisualStyleBackColor = true;
            this.rdbCompany_Wise.CheckedChanged += new System.EventHandler(this.rdbCompany_Wise_CheckedChanged);
            // 
            // rdbLocation_Wise
            // 
            this.rdbLocation_Wise.AutoSize = true;
            this.rdbLocation_Wise.Location = new System.Drawing.Point(6, 42);
            this.rdbLocation_Wise.Name = "rdbLocation_Wise";
            this.rdbLocation_Wise.Size = new System.Drawing.Size(93, 17);
            this.rdbLocation_Wise.TabIndex = 313;
            this.rdbLocation_Wise.TabStop = true;
            this.rdbLocation_Wise.Text = "Location Wise";
            this.rdbLocation_Wise.UseVisualStyleBackColor = true;
            this.rdbLocation_Wise.CheckedChanged += new System.EventHandler(this.rdbCompany_Wise_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbKit);
            this.groupBox1.Controls.Add(this.rdbAdvance);
            this.groupBox1.Controls.Add(this.rdbLoan);
            this.groupBox1.Location = new System.Drawing.Point(309, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 93);
            this.groupBox1.TabIndex = 315;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Advance Type";
            // 
            // rdbKit
            // 
            this.rdbKit.AutoSize = true;
            this.rdbKit.Location = new System.Drawing.Point(7, 67);
            this.rdbKit.Name = "rdbKit";
            this.rdbKit.Size = new System.Drawing.Size(37, 17);
            this.rdbKit.TabIndex = 2;
            this.rdbKit.TabStop = true;
            this.rdbKit.Text = "Kit";
            this.rdbKit.UseVisualStyleBackColor = true;
            // 
            // rdbAdvance
            // 
            this.rdbAdvance.AutoSize = true;
            this.rdbAdvance.Location = new System.Drawing.Point(7, 43);
            this.rdbAdvance.Name = "rdbAdvance";
            this.rdbAdvance.Size = new System.Drawing.Size(68, 17);
            this.rdbAdvance.TabIndex = 1;
            this.rdbAdvance.TabStop = true;
            this.rdbAdvance.Text = "Advance";
            this.rdbAdvance.UseVisualStyleBackColor = true;
            // 
            // rdbLoan
            // 
            this.rdbLoan.AutoSize = true;
            this.rdbLoan.Location = new System.Drawing.Point(6, 19);
            this.rdbLoan.Name = "rdbLoan";
            this.rdbLoan.Size = new System.Drawing.Size(49, 17);
            this.rdbLoan.TabIndex = 0;
            this.rdbLoan.TabStop = true;
            this.rdbLoan.Text = "Loan";
            this.rdbLoan.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbCompany_Wise);
            this.groupBox2.Controls.Add(this.rdbLocation_Wise);
            this.groupBox2.Location = new System.Drawing.Point(65, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 93);
            this.groupBox2.TabIndex = 316;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View By";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 317;
            this.label1.Text = "Month";
            // 
            // frmAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 340);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtmMonthSelect);
            this.Controls.Add(this.CmbLocation);
            this.Controls.Add(this.LblLocation);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.LblCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmAdvance";
            this.Load += new System.EventHandler(this.frmAdvance_Load);
            this.Controls.SetChildIndex(this.LblCompany, 0);
            this.Controls.SetChildIndex(this.cmbcompany, 0);
            this.Controls.SetChildIndex(this.LblLocation, 0);
            this.Controls.SetChildIndex(this.CmbLocation, 0);
            this.Controls.SetChildIndex(this.dtmMonthSelect, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.ComboDialog CmbLocation;
        private System.Windows.Forms.Label LblLocation;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.DateTimePicker dtmMonthSelect;
        private System.Windows.Forms.RadioButton rdbCompany_Wise;
        private System.Windows.Forms.RadioButton rdbLocation_Wise;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbKit;
        private System.Windows.Forms.RadioButton rdbAdvance;
        private System.Windows.Forms.RadioButton rdbLoan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}