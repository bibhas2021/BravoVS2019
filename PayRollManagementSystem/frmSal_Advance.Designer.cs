namespace PayRollManagementSystem
{
    partial class frmSal_Advance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSal_Advance));
            this.txtAdvECode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbAdvLoc = new EDPComponent.ComboDialog();
            this.txtEmpAdv = new System.Windows.Forms.TextBox();
            this.dtpEmpAdv = new System.Windows.Forms.DateTimePicker();
            this.cmbEmpAdv = new EDPComponent.ComboDialog();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.DTP_MON = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnEmp_Advance = new EDPComponent.VistaButton();
            this.lbl_locid = new System.Windows.Forms.Label();
            this.lbl_coid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdvID = new System.Windows.Forms.TextBox();
            this.lblAdvID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAdvECode
            // 
            this.txtAdvECode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdvECode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvECode.Location = new System.Drawing.Point(453, 88);
            this.txtAdvECode.Name = "txtAdvECode";
            this.txtAdvECode.ReadOnly = true;
            this.txtAdvECode.Size = new System.Drawing.Size(75, 20);
            this.txtAdvECode.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 12);
            this.label15.TabIndex = 36;
            this.label15.Text = "Location";
            // 
            // cmbAdvLoc
            // 
            this.cmbAdvLoc.Connection = null;
            this.cmbAdvLoc.DialogResult = "";
            this.cmbAdvLoc.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAdvLoc.Location = new System.Drawing.Point(132, 36);
            this.cmbAdvLoc.LOVFlag = 0;
            this.cmbAdvLoc.MaxCharLength = 500;
            this.cmbAdvLoc.Name = "cmbAdvLoc";
            this.cmbAdvLoc.ReadOnly = true;
            this.cmbAdvLoc.ReturnIndex = -1;
            this.cmbAdvLoc.ReturnValue = "";
            this.cmbAdvLoc.ReturnValue_3rd = "";
            this.cmbAdvLoc.ReturnValue_4th = "";
            this.cmbAdvLoc.Size = new System.Drawing.Size(395, 21);
            this.cmbAdvLoc.TabIndex = 35;
            // 
            // txtEmpAdv
            // 
            this.txtEmpAdv.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpAdv.Location = new System.Drawing.Point(132, 114);
            this.txtEmpAdv.Name = "txtEmpAdv";
            this.txtEmpAdv.Size = new System.Drawing.Size(152, 20);
            this.txtEmpAdv.TabIndex = 0;
            this.txtEmpAdv.Text = "0";
            this.txtEmpAdv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpEmpAdv
            // 
            this.dtpEmpAdv.CustomFormat = "dd/MM/yyyy";
            this.dtpEmpAdv.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEmpAdv.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEmpAdv.Location = new System.Drawing.Point(132, 61);
            this.dtpEmpAdv.Name = "dtpEmpAdv";
            this.dtpEmpAdv.Size = new System.Drawing.Size(152, 20);
            this.dtpEmpAdv.TabIndex = 33;
            // 
            // cmbEmpAdv
            // 
            this.cmbEmpAdv.Connection = null;
            this.cmbEmpAdv.DialogResult = "";
            this.cmbEmpAdv.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpAdv.Location = new System.Drawing.Point(132, 88);
            this.cmbEmpAdv.LOVFlag = 0;
            this.cmbEmpAdv.MaxCharLength = 500;
            this.cmbEmpAdv.Name = "cmbEmpAdv";
            this.cmbEmpAdv.ReadOnly = true;
            this.cmbEmpAdv.ReturnIndex = -1;
            this.cmbEmpAdv.ReturnValue = "";
            this.cmbEmpAdv.ReturnValue_3rd = "";
            this.cmbEmpAdv.ReturnValue_4th = "";
            this.cmbEmpAdv.Size = new System.Drawing.Size(319, 21);
            this.cmbEmpAdv.TabIndex = 29;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(12, 117);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 12);
            this.label18.TabIndex = 31;
            this.label18.Text = "Advance Amount";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(12, 67);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 12);
            this.label19.TabIndex = 30;
            this.label19.Text = "Advance Date";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(12, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 12);
            this.label20.TabIndex = 32;
            this.label20.Text = "Employee Name";
            // 
            // DTP_MON
            // 
            this.DTP_MON.CustomFormat = "MMMM/ yyyy";
            this.DTP_MON.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_MON.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_MON.Location = new System.Drawing.Point(400, 61);
            this.DTP_MON.Name = "DTP_MON";
            this.DTP_MON.Size = new System.Drawing.Size(128, 20);
            this.DTP_MON.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "For the month of :";
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
            this.BtnEmp_Advance.Location = new System.Drawing.Point(453, 115);
            this.BtnEmp_Advance.Name = "BtnEmp_Advance";
            this.BtnEmp_Advance.Size = new System.Drawing.Size(75, 26);
            this.BtnEmp_Advance.TabIndex = 40;
            this.BtnEmp_Advance.Click += new System.EventHandler(this.BtnEmp_Advance_Click);
            // 
            // lbl_locid
            // 
            this.lbl_locid.AutoSize = true;
            this.lbl_locid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_locid.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_locid.Location = new System.Drawing.Point(540, 37);
            this.lbl_locid.Name = "lbl_locid";
            this.lbl_locid.Size = new System.Drawing.Size(2, 16);
            this.lbl_locid.TabIndex = 41;
            // 
            // lbl_coid
            // 
            this.lbl_coid.AutoSize = true;
            this.lbl_coid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_coid.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_coid.Location = new System.Drawing.Point(540, 67);
            this.lbl_coid.Name = "lbl_coid";
            this.lbl_coid.Size = new System.Drawing.Size(2, 16);
            this.lbl_coid.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "Advance ID";
            this.label1.Visible = false;
            // 
            // txtAdvID
            // 
            this.txtAdvID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvID.ForeColor = System.Drawing.Color.Black;
            this.txtAdvID.Location = new System.Drawing.Point(132, 12);
            this.txtAdvID.Name = "txtAdvID";
            this.txtAdvID.Size = new System.Drawing.Size(152, 20);
            this.txtAdvID.TabIndex = 34;
            this.txtAdvID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdvID.Visible = false;
            // 
            // lblAdvID
            // 
            this.lblAdvID.AutoSize = true;
            this.lblAdvID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAdvID.Location = new System.Drawing.Point(287, 15);
            this.lblAdvID.Name = "lblAdvID";
            this.lblAdvID.Size = new System.Drawing.Size(2, 15);
            this.lblAdvID.TabIndex = 42;
            this.lblAdvID.Visible = false;
            // 
            // frmSal_Advance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(575, 149);
            this.Controls.Add(this.lblAdvID);
            this.Controls.Add(this.lbl_coid);
            this.Controls.Add(this.lbl_locid);
            this.Controls.Add(this.BtnEmp_Advance);
            this.Controls.Add(this.DTP_MON);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAdvECode);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbAdvLoc);
            this.Controls.Add(this.txtAdvID);
            this.Controls.Add(this.txtEmpAdv);
            this.Controls.Add(this.dtpEmpAdv);
            this.Controls.Add(this.cmbEmpAdv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSal_Advance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advance";
            this.Load += new System.EventHandler(this.frmSal_Advance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtAdvECode;
        public EDPComponent.ComboDialog cmbAdvLoc;
        public System.Windows.Forms.TextBox txtEmpAdv;
        public System.Windows.Forms.DateTimePicker dtpEmpAdv;
        public EDPComponent.ComboDialog cmbEmpAdv;
        public System.Windows.Forms.DateTimePicker DTP_MON;
        public EDPComponent.VistaButton BtnEmp_Advance;
        public System.Windows.Forms.Label lbl_locid;
        public System.Windows.Forms.Label lbl_coid;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtAdvID;
        private System.Windows.Forms.Label lblAdvID;
    }
}