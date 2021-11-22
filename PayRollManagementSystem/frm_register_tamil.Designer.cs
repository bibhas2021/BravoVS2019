namespace PayRollManagementSystem
{
    partial class frm_register_tamil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_register_tamil));
            this.btnicard_prev = new EDPComponent.VistaButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_ic_emp = new System.Windows.Forms.RadioButton();
            this.rdb_ic_loc = new System.Windows.Forms.RadioButton();
            this.rdb_ic_co = new System.Windows.Forms.RadioButton();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.LblLocation = new System.Windows.Forms.Label();
            this.btnclient = new System.Windows.Forms.Button();
            this.btnWorkmen = new EDPComponent.VistaButton();
            this.btnFine = new EDPComponent.VistaButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CmbSession = new System.Windows.Forms.ComboBox();
            this.LblSession = new System.Windows.Forms.Label();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.btnFormD = new EDPComponent.VistaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFormC = new EDPComponent.VistaButton();
            this.btnFormVI = new EDPComponent.VistaButton();
            this.btnFormA = new EDPComponent.VistaButton();
            this.btnFormQ = new EDPComponent.VistaButton();
            this.btnForm11 = new EDPComponent.VistaButton();
            this.grp_sign = new System.Windows.Forms.GroupBox();
            this.rdb_sign2 = new System.Windows.Forms.RadioButton();
            this.rdb_sign = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grp_sign.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnicard_prev
            // 
            this.btnicard_prev.BackColor = System.Drawing.Color.Transparent;
            this.btnicard_prev.BaseColor = System.Drawing.Color.Ivory;
            this.btnicard_prev.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnicard_prev.ButtonText = "Employement Card";
            this.btnicard_prev.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnicard_prev.ForeColor = System.Drawing.Color.Black;
            this.btnicard_prev.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnicard_prev.Location = new System.Drawing.Point(173, 260);
            this.btnicard_prev.Name = "btnicard_prev";
            this.btnicard_prev.Size = new System.Drawing.Size(147, 28);
            this.btnicard_prev.TabIndex = 328;
            this.btnicard_prev.Click += new System.EventHandler(this.btnicard_prev_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_ic_emp);
            this.groupBox1.Controls.Add(this.rdb_ic_loc);
            this.groupBox1.Controls.Add(this.rdb_ic_co);
            this.groupBox1.Location = new System.Drawing.Point(29, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 48);
            this.groupBox1.TabIndex = 327;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print icard";
            // 
            // rdb_ic_emp
            // 
            this.rdb_ic_emp.AutoSize = true;
            this.rdb_ic_emp.Checked = true;
            this.rdb_ic_emp.Location = new System.Drawing.Point(268, 19);
            this.rdb_ic_emp.Name = "rdb_ic_emp";
            this.rdb_ic_emp.Size = new System.Drawing.Size(119, 17);
            this.rdb_ic_emp.TabIndex = 4;
            this.rdb_ic_emp.TabStop = true;
            this.rdb_ic_emp.Text = "Individual Employee";
            this.rdb_ic_emp.UseVisualStyleBackColor = true;
            // 
            // rdb_ic_loc
            // 
            this.rdb_ic_loc.AutoSize = true;
            this.rdb_ic_loc.Location = new System.Drawing.Point(140, 19);
            this.rdb_ic_loc.Name = "rdb_ic_loc";
            this.rdb_ic_loc.Size = new System.Drawing.Size(90, 17);
            this.rdb_ic_loc.TabIndex = 4;
            this.rdb_ic_loc.Text = "Location wise";
            this.rdb_ic_loc.UseVisualStyleBackColor = true;
            // 
            // rdb_ic_co
            // 
            this.rdb_ic_co.AutoSize = true;
            this.rdb_ic_co.Location = new System.Drawing.Point(19, 18);
            this.rdb_ic_co.Name = "rdb_ic_co";
            this.rdb_ic_co.Size = new System.Drawing.Size(96, 17);
            this.rdb_ic_co.TabIndex = 4;
            this.rdb_ic_co.Text = "Company Wise";
            this.rdb_ic_co.UseVisualStyleBackColor = true;
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(97, 74);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(325, 21);
            this.CmbCompany.TabIndex = 323;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(26, 74);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(51, 13);
            this.LblCompany.TabIndex = 326;
            this.LblCompany.Text = "Company";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(97, 98);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(325, 21);
            this.cmbLocation.TabIndex = 324;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Location = new System.Drawing.Point(26, 102);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(48, 13);
            this.LblLocation.TabIndex = 325;
            this.LblLocation.Text = "Location";
            // 
            // btnclient
            // 
            this.btnclient.Location = new System.Drawing.Point(97, 125);
            this.btnclient.Name = "btnclient";
            this.btnclient.Size = new System.Drawing.Size(325, 26);
            this.btnclient.TabIndex = 322;
            this.btnclient.Text = "Select Employee";
            this.btnclient.UseVisualStyleBackColor = true;
            this.btnclient.Click += new System.EventHandler(this.btnclient_Click);
            // 
            // btnWorkmen
            // 
            this.btnWorkmen.BackColor = System.Drawing.Color.Transparent;
            this.btnWorkmen.BaseColor = System.Drawing.Color.Ivory;
            this.btnWorkmen.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnWorkmen.ButtonText = "Workmen Employed";
            this.btnWorkmen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWorkmen.ForeColor = System.Drawing.Color.Black;
            this.btnWorkmen.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnWorkmen.Location = new System.Drawing.Point(29, 259);
            this.btnWorkmen.Name = "btnWorkmen";
            this.btnWorkmen.Size = new System.Drawing.Size(139, 29);
            this.btnWorkmen.TabIndex = 328;
            this.btnWorkmen.Click += new System.EventHandler(this.btnWorkmen_Click);
            // 
            // btnFine
            // 
            this.btnFine.BackColor = System.Drawing.Color.Transparent;
            this.btnFine.BaseColor = System.Drawing.Color.Ivory;
            this.btnFine.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnFine.ButtonText = "Fines";
            this.btnFine.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFine.ForeColor = System.Drawing.Color.Black;
            this.btnFine.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnFine.Location = new System.Drawing.Point(326, 261);
            this.btnFine.Name = "btnFine";
            this.btnFine.Size = new System.Drawing.Size(141, 26);
            this.btnFine.TabIndex = 328;
            this.btnFine.Click += new System.EventHandler(this.btnFine_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CmbSession);
            this.groupBox2.Controls.Add(this.LblSession);
            this.groupBox2.Controls.Add(this.AttenDtTmPkr);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Location = new System.Drawing.Point(29, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 49);
            this.groupBox2.TabIndex = 329;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // CmbSession
            // 
            this.CmbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSession.FormattingEnabled = true;
            this.CmbSession.Location = new System.Drawing.Point(68, 16);
            this.CmbSession.Name = "CmbSession";
            this.CmbSession.Size = new System.Drawing.Size(109, 21);
            this.CmbSession.TabIndex = 322;
            // 
            // LblSession
            // 
            this.LblSession.AutoSize = true;
            this.LblSession.Location = new System.Drawing.Point(16, 19);
            this.LblSession.Name = "LblSession";
            this.LblSession.Size = new System.Drawing.Size(44, 13);
            this.LblSession.TabIndex = 316;
            this.LblSession.Text = "Session";
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.CustomFormat = "MMMM, yyyy";
            this.AttenDtTmPkr.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(255, 16);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(138, 22);
            this.AttenDtTmPkr.TabIndex = 2;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(205, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 319;
            this.label21.Text = "Month";
            // 
            // btnFormD
            // 
            this.btnFormD.BackColor = System.Drawing.Color.Transparent;
            this.btnFormD.BaseColor = System.Drawing.Color.Ivory;
            this.btnFormD.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnFormD.ButtonText = "Form D";
            this.btnFormD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormD.ForeColor = System.Drawing.Color.Black;
            this.btnFormD.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnFormD.Location = new System.Drawing.Point(173, 295);
            this.btnFormD.Name = "btnFormD";
            this.btnFormD.Size = new System.Drawing.Size(78, 25);
            this.btnFormD.TabIndex = 328;
            this.btnFormD.Click += new System.EventHandler(this.btnFormD_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(17, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 1);
            this.panel1.TabIndex = 330;
            // 
            // btnFormC
            // 
            this.btnFormC.BackColor = System.Drawing.Color.Transparent;
            this.btnFormC.BaseColor = System.Drawing.Color.Ivory;
            this.btnFormC.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnFormC.ButtonText = "Form C";
            this.btnFormC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormC.ForeColor = System.Drawing.Color.Black;
            this.btnFormC.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnFormC.Location = new System.Drawing.Point(106, 294);
            this.btnFormC.Name = "btnFormC";
            this.btnFormC.Size = new System.Drawing.Size(62, 27);
            this.btnFormC.TabIndex = 328;
            this.btnFormC.Click += new System.EventHandler(this.btnFormC_Click);
            // 
            // btnFormVI
            // 
            this.btnFormVI.BackColor = System.Drawing.Color.Transparent;
            this.btnFormVI.BaseColor = System.Drawing.Color.Ivory;
            this.btnFormVI.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnFormVI.ButtonText = "Form VI";
            this.btnFormVI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormVI.ForeColor = System.Drawing.Color.Black;
            this.btnFormVI.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnFormVI.Location = new System.Drawing.Point(400, 294);
            this.btnFormVI.Name = "btnFormVI";
            this.btnFormVI.Size = new System.Drawing.Size(67, 26);
            this.btnFormVI.TabIndex = 328;
            this.btnFormVI.Click += new System.EventHandler(this.btnFormVI_Click);
            // 
            // btnFormA
            // 
            this.btnFormA.BackColor = System.Drawing.Color.Transparent;
            this.btnFormA.BaseColor = System.Drawing.Color.Ivory;
            this.btnFormA.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnFormA.ButtonText = "Form A";
            this.btnFormA.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormA.ForeColor = System.Drawing.Color.Black;
            this.btnFormA.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnFormA.Location = new System.Drawing.Point(29, 294);
            this.btnFormA.Name = "btnFormA";
            this.btnFormA.Size = new System.Drawing.Size(71, 28);
            this.btnFormA.TabIndex = 328;
            this.btnFormA.Click += new System.EventHandler(this.btnFormA_Click);
            // 
            // btnFormQ
            // 
            this.btnFormQ.BackColor = System.Drawing.Color.Transparent;
            this.btnFormQ.BaseColor = System.Drawing.Color.Ivory;
            this.btnFormQ.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnFormQ.ButtonText = "Form Q";
            this.btnFormQ.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormQ.ForeColor = System.Drawing.Color.Black;
            this.btnFormQ.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnFormQ.Location = new System.Drawing.Point(257, 294);
            this.btnFormQ.Name = "btnFormQ";
            this.btnFormQ.Size = new System.Drawing.Size(63, 28);
            this.btnFormQ.TabIndex = 328;
            this.btnFormQ.Click += new System.EventHandler(this.btnFormQ_Click);
            // 
            // btnForm11
            // 
            this.btnForm11.BackColor = System.Drawing.Color.Transparent;
            this.btnForm11.BaseColor = System.Drawing.Color.Ivory;
            this.btnForm11.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnForm11.ButtonText = "Form 11";
            this.btnForm11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForm11.ForeColor = System.Drawing.Color.Black;
            this.btnForm11.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnForm11.Location = new System.Drawing.Point(326, 294);
            this.btnForm11.Name = "btnForm11";
            this.btnForm11.Size = new System.Drawing.Size(68, 27);
            this.btnForm11.TabIndex = 328;
            this.btnForm11.Click += new System.EventHandler(this.btnForm11_Click);
            // 
            // grp_sign
            // 
            this.grp_sign.Controls.Add(this.rdb_sign2);
            this.grp_sign.Controls.Add(this.rdb_sign);
            this.grp_sign.Enabled = false;
            this.grp_sign.Location = new System.Drawing.Point(29, 207);
            this.grp_sign.Name = "grp_sign";
            this.grp_sign.Size = new System.Drawing.Size(230, 46);
            this.grp_sign.TabIndex = 331;
            this.grp_sign.TabStop = false;
            this.grp_sign.Text = "Company Authorise Signature";
            // 
            // rdb_sign2
            // 
            this.rdb_sign2.AutoSize = true;
            this.rdb_sign2.Location = new System.Drawing.Point(121, 19);
            this.rdb_sign2.Name = "rdb_sign2";
            this.rdb_sign2.Size = new System.Drawing.Size(79, 17);
            this.rdb_sign2.TabIndex = 0;
            this.rdb_sign2.Text = "2nd Person";
            this.rdb_sign2.UseVisualStyleBackColor = true;
            // 
            // rdb_sign
            // 
            this.rdb_sign.AutoSize = true;
            this.rdb_sign.Checked = true;
            this.rdb_sign.Location = new System.Drawing.Point(18, 19);
            this.rdb_sign.Name = "rdb_sign";
            this.rdb_sign.Size = new System.Drawing.Size(75, 17);
            this.rdb_sign.TabIndex = 0;
            this.rdb_sign.TabStop = true;
            this.rdb_sign.Text = "1st Person";
            this.rdb_sign.UseVisualStyleBackColor = true;
            // 
            // frm_register_tamil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(479, 377);
            this.Controls.Add(this.grp_sign);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnFine);
            this.Controls.Add(this.btnWorkmen);
            this.Controls.Add(this.btnFormQ);
            this.Controls.Add(this.btnFormA);
            this.Controls.Add(this.btnForm11);
            this.Controls.Add(this.btnFormVI);
            this.Controls.Add(this.btnFormC);
            this.Controls.Add(this.btnFormD);
            this.Controls.Add(this.btnicard_prev);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmbCompany);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.LblLocation);
            this.Controls.Add(this.btnclient);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_register_tamil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "State Register - Tamil Nadu";
            this.Load += new System.EventHandler(this.frm_register_tamil_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grp_sign.ResumeLayout(false);
            this.grp_sign.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.VistaButton btnicard_prev;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_ic_emp;
        private System.Windows.Forms.RadioButton rdb_ic_loc;
        private System.Windows.Forms.RadioButton rdb_ic_co;
        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label LblCompany;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.Button btnclient;
        private EDPComponent.VistaButton btnWorkmen;
        private EDPComponent.VistaButton btnFine;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.ComboBox CmbSession;
        private System.Windows.Forms.Label LblSession;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        internal System.Windows.Forms.Label label21;
        private EDPComponent.VistaButton btnFormD;
        private System.Windows.Forms.Panel panel1;
        private EDPComponent.VistaButton btnFormC;
        private EDPComponent.VistaButton btnFormVI;
        private EDPComponent.VistaButton btnFormA;
        private EDPComponent.VistaButton btnFormQ;
        private EDPComponent.VistaButton btnForm11;
        private System.Windows.Forms.GroupBox grp_sign;
        private System.Windows.Forms.RadioButton rdb_sign2;
        private System.Windows.Forms.RadioButton rdb_sign;
    }
}