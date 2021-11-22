namespace PayRollManagementSystem
{
    partial class frmSal_Loan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSal_Loan));
            this.lbl_coid = new System.Windows.Forms.Label();
            this.lbl_locid = new System.Windows.Forms.Label();
            this.BtnEmp_Advance = new EDPComponent.VistaButton();
            this.DTP_MON = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAdvECode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbAdvLoc = new EDPComponent.ComboDialog();
            this.txtEmpAdv = new System.Windows.Forms.TextBox();
            this.dtpEmpAdv = new System.Windows.Forms.DateTimePicker();
            this.cmbEmpAdv = new EDPComponent.ComboDialog();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtEMI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_coid
            // 
            this.lbl_coid.AutoSize = true;
            this.lbl_coid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_coid.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_coid.Location = new System.Drawing.Point(546, 55);
            this.lbl_coid.Name = "lbl_coid";
            this.lbl_coid.Size = new System.Drawing.Size(2, 16);
            this.lbl_coid.TabIndex = 54;
            // 
            // lbl_locid
            // 
            this.lbl_locid.AutoSize = true;
            this.lbl_locid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_locid.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_locid.Location = new System.Drawing.Point(546, 25);
            this.lbl_locid.Name = "lbl_locid";
            this.lbl_locid.Size = new System.Drawing.Size(2, 16);
            this.lbl_locid.TabIndex = 55;
            // 
            // BtnEmp_Advance
            // 
            this.BtnEmp_Advance.BackColor = System.Drawing.Color.Transparent;
            this.BtnEmp_Advance.BaseColor = System.Drawing.Color.Ivory;
            this.BtnEmp_Advance.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.BtnEmp_Advance.ButtonText = "Save";
            this.BtnEmp_Advance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmp_Advance.ForeColor = System.Drawing.Color.Black;
            this.BtnEmp_Advance.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.BtnEmp_Advance.Location = new System.Drawing.Point(463, 102);
            this.BtnEmp_Advance.Name = "BtnEmp_Advance";
            this.BtnEmp_Advance.Size = new System.Drawing.Size(74, 26);
            this.BtnEmp_Advance.TabIndex = 5;
            this.BtnEmp_Advance.Click += new System.EventHandler(this.BtnEmp_Advance_Click);
            // 
            // DTP_MON
            // 
            this.DTP_MON.CustomFormat = "MMMM/ yyyy";
            this.DTP_MON.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_MON.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_MON.Location = new System.Drawing.Point(398, 49);
            this.DTP_MON.Name = "DTP_MON";
            this.DTP_MON.Size = new System.Drawing.Size(136, 20);
            this.DTP_MON.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(292, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 51;
            this.label2.Text = "For the month of :";
            // 
            // txtAdvECode
            // 
            this.txtAdvECode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdvECode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvECode.Location = new System.Drawing.Point(459, 76);
            this.txtAdvECode.Name = "txtAdvECode";
            this.txtAdvECode.ReadOnly = true;
            this.txtAdvECode.Size = new System.Drawing.Size(75, 20);
            this.txtAdvECode.TabIndex = 50;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(18, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 12);
            this.label15.TabIndex = 49;
            this.label15.Text = "Location";
            // 
            // cmbAdvLoc
            // 
            this.cmbAdvLoc.Connection = null;
            this.cmbAdvLoc.DialogResult = "";
            this.cmbAdvLoc.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAdvLoc.Location = new System.Drawing.Point(138, 22);
            this.cmbAdvLoc.LOVFlag = 0;
            this.cmbAdvLoc.MaxCharLength = 500;
            this.cmbAdvLoc.Name = "cmbAdvLoc";
            this.cmbAdvLoc.ReadOnly = true;
            this.cmbAdvLoc.ReturnIndex = -1;
            this.cmbAdvLoc.ReturnValue = "";
            this.cmbAdvLoc.ReturnValue_3rd = "";
            this.cmbAdvLoc.ReturnValue_4th = "";
            this.cmbAdvLoc.Size = new System.Drawing.Size(395, 21);
            this.cmbAdvLoc.TabIndex = 48;
            this.cmbAdvLoc.TabStop = false;
            // 
            // txtEmpAdv
            // 
            this.txtEmpAdv.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpAdv.Location = new System.Drawing.Point(138, 102);
            this.txtEmpAdv.Name = "txtEmpAdv";
            this.txtEmpAdv.Size = new System.Drawing.Size(80, 20);
            this.txtEmpAdv.TabIndex = 0;
            this.txtEmpAdv.Text = "0";
            this.txtEmpAdv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEmpAdv.TextChanged += new System.EventHandler(this.txtEmpAdv_TextChanged);
            // 
            // dtpEmpAdv
            // 
            this.dtpEmpAdv.CustomFormat = "dd/MM/yyyy";
            this.dtpEmpAdv.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEmpAdv.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEmpAdv.Location = new System.Drawing.Point(138, 49);
            this.dtpEmpAdv.Name = "dtpEmpAdv";
            this.dtpEmpAdv.Size = new System.Drawing.Size(152, 20);
            this.dtpEmpAdv.TabIndex = 3;
            // 
            // cmbEmpAdv
            // 
            this.cmbEmpAdv.Connection = null;
            this.cmbEmpAdv.DialogResult = "";
            this.cmbEmpAdv.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpAdv.Location = new System.Drawing.Point(138, 76);
            this.cmbEmpAdv.LOVFlag = 0;
            this.cmbEmpAdv.MaxCharLength = 500;
            this.cmbEmpAdv.Name = "cmbEmpAdv";
            this.cmbEmpAdv.ReadOnly = true;
            this.cmbEmpAdv.ReturnIndex = -1;
            this.cmbEmpAdv.ReturnValue = "";
            this.cmbEmpAdv.ReturnValue_3rd = "";
            this.cmbEmpAdv.ReturnValue_4th = "";
            this.cmbEmpAdv.Size = new System.Drawing.Size(319, 21);
            this.cmbEmpAdv.TabIndex = 42;
            this.cmbEmpAdv.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(18, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 12);
            this.label18.TabIndex = 44;
            this.label18.Text = "Loan Amount";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(18, 55);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 12);
            this.label19.TabIndex = 43;
            this.label19.Text = "Loan Date";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(18, 78);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 12);
            this.label20.TabIndex = 45;
            this.label20.Text = "Employee Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Duration";
            // 
            // txtDuration
            // 
            this.txtDuration.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.Location = new System.Drawing.Point(284, 102);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(55, 20);
            this.txtDuration.TabIndex = 1;
            this.txtDuration.Text = "0";
            this.txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDuration.TextChanged += new System.EventHandler(this.txtDuration_TextChanged);
            // 
            // txtEMI
            // 
            this.txtEMI.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEMI.ForeColor = System.Drawing.Color.Black;
            this.txtEMI.Location = new System.Drawing.Point(378, 103);
            this.txtEMI.Name = "txtEMI";
            this.txtEMI.Size = new System.Drawing.Size(79, 20);
            this.txtEMI.TabIndex = 2;
            this.txtEMI.Text = "0";
            this.txtEMI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(345, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "EMI";
            // 
            // frmSal_Loan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(594, 155);
            this.Controls.Add(this.lbl_coid);
            this.Controls.Add(this.lbl_locid);
            this.Controls.Add(this.BtnEmp_Advance);
            this.Controls.Add(this.DTP_MON);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAdvECode);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbAdvLoc);
            this.Controls.Add(this.txtEMI);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.txtEmpAdv);
            this.Controls.Add(this.dtpEmpAdv);
            this.Controls.Add(this.cmbEmpAdv);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSal_Loan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan";
            this.Load += new System.EventHandler(this.frmSal_Loan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbl_coid;
        public System.Windows.Forms.Label lbl_locid;
        public EDPComponent.VistaButton BtnEmp_Advance;
        public System.Windows.Forms.DateTimePicker DTP_MON;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtAdvECode;
        private System.Windows.Forms.Label label15;
        public EDPComponent.ComboDialog cmbAdvLoc;
        public System.Windows.Forms.TextBox txtEmpAdv;
        public System.Windows.Forms.DateTimePicker dtpEmpAdv;
        public EDPComponent.ComboDialog cmbEmpAdv;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtDuration;
        public System.Windows.Forms.TextBox txtEMI;
        private System.Windows.Forms.Label label3;
    }
}