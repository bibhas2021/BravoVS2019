namespace PayRollManagementSystem
{
    partial class frmempdetailsexport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmempdetailsexport));
            this.BtnDisp_Bio = new EDPComponent.VistaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdb_all = new System.Windows.Forms.RadioButton();
            this.rdb_co = new System.Windows.Forms.RadioButton();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFields = new System.Windows.Forms.CheckedListBox();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.rdbActive = new System.Windows.Forms.RadioButton();
            this.rdbInActive = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExp = new EDPComponent.VistaButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rb_loc = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDisp_Bio
            // 
            this.BtnDisp_Bio.BackColor = System.Drawing.Color.Transparent;
            this.BtnDisp_Bio.BaseColor = System.Drawing.Color.Ivory;
            this.BtnDisp_Bio.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.BtnDisp_Bio.ButtonText = "Preview";
            this.BtnDisp_Bio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDisp_Bio.ForeColor = System.Drawing.Color.Black;
            this.BtnDisp_Bio.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.BtnDisp_Bio.Location = new System.Drawing.Point(16, 168);
            this.BtnDisp_Bio.Name = "BtnDisp_Bio";
            this.BtnDisp_Bio.Size = new System.Drawing.Size(145, 36);
            this.BtnDisp_Bio.TabIndex = 4;
            this.BtnDisp_Bio.Click += new System.EventHandler(this.BtnDisp_Bio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "SHOW BY";
            // 
            // rdb_all
            // 
            this.rdb_all.AutoSize = true;
            this.rdb_all.Location = new System.Drawing.Point(56, 12);
            this.rdb_all.Name = "rdb_all";
            this.rdb_all.Size = new System.Drawing.Size(44, 17);
            this.rdb_all.TabIndex = 6;
            this.rdb_all.Text = "ALL";
            this.rdb_all.UseVisualStyleBackColor = true;
            this.rdb_all.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdb_co
            // 
            this.rdb_co.AutoSize = true;
            this.rdb_co.Location = new System.Drawing.Point(56, 33);
            this.rdb_co.Name = "rdb_co";
            this.rdb_co.Size = new System.Drawing.Size(78, 17);
            this.rdb_co.TabIndex = 7;
            this.rdb_co.Text = "COMPANY";
            this.rdb_co.UseVisualStyleBackColor = true;
            this.rdb_co.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(97, 97);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(328, 21);
            this.CmbCompany.TabIndex = 8;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_CloseUp);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(16, 101);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(37, 13);
            this.LblCompany.TabIndex = 9;
            this.LblCompany.Text = "Select";
            this.LblCompany.Click += new System.EventHandler(this.LblCompany_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkFields);
            this.groupBox1.Location = new System.Drawing.Point(34, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 18);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FIELDS";
            this.groupBox1.Visible = false;
            // 
            // chkFields
            // 
            this.chkFields.BackColor = System.Drawing.Color.White;
            this.chkFields.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFields.CheckOnClick = true;
            this.chkFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFields.FormattingEnabled = true;
            this.chkFields.Items.AddRange(new object[] {
            "ID",
            "Employee Name",
            "Father Name",
            "Mother Name",
            "Spouse Name",
            "Date Of Birth",
            "Date Of Joining",
            "Date Of Retirement",
            "Religion",
            "Cast",
            "Gender",
            "Marital Status",
            "Address",
            "Contact No",
            "EPF",
            "ESIC",
            "PAN",
            "UAN",
            "Pension",
            "Aadhar",
            "Bank",
            "Bank Branch",
            "Bank Acount No",
            "Bank IFSC",
            "Designation",
            "Job Type",
            "Location",
            "Client",
            "Company",
            "Emp Basic",
            "Emp Salary",
            "Status"});
            this.chkFields.Location = new System.Drawing.Point(3, 16);
            this.chkFields.MultiColumn = true;
            this.chkFields.Name = "chkFields";
            this.chkFields.Size = new System.Drawing.Size(385, 0);
            this.chkFields.TabIndex = 11;
            this.chkFields.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // dgvShow
            // 
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.Location = new System.Drawing.Point(16, 210);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.Size = new System.Drawing.Size(421, 10);
            this.dgvShow.TabIndex = 319;
            this.dgvShow.Visible = false;
            // 
            // rdbActive
            // 
            this.rdbActive.AutoSize = true;
            this.rdbActive.Checked = true;
            this.rdbActive.Location = new System.Drawing.Point(20, 17);
            this.rdbActive.Name = "rdbActive";
            this.rdbActive.Size = new System.Drawing.Size(55, 17);
            this.rdbActive.TabIndex = 320;
            this.rdbActive.TabStop = true;
            this.rdbActive.Text = "Active";
            this.rdbActive.UseVisualStyleBackColor = true;
            // 
            // rdbInActive
            // 
            this.rdbInActive.AutoSize = true;
            this.rdbInActive.Location = new System.Drawing.Point(20, 34);
            this.rdbInActive.Name = "rdbInActive";
            this.rdbInActive.Size = new System.Drawing.Size(67, 17);
            this.rdbInActive.TabIndex = 320;
            this.rdbInActive.Text = "In Active";
            this.rdbInActive.UseVisualStyleBackColor = true;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(20, 57);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(36, 17);
            this.rdbAll.TabIndex = 320;
            this.rdbAll.Text = "All";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbActive);
            this.groupBox2.Controls.Add(this.rdbAll);
            this.groupBox2.Controls.Add(this.rdbInActive);
            this.groupBox2.Location = new System.Drawing.Point(302, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 81);
            this.groupBox2.TabIndex = 321;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Display Status";
            // 
            // btnExp
            // 
            this.btnExp.BackColor = System.Drawing.Color.Transparent;
            this.btnExp.BaseColor = System.Drawing.Color.Ivory;
            this.btnExp.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnExp.ButtonText = "Export to Excel";
            this.btnExp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExp.ForeColor = System.Drawing.Color.Black;
            this.btnExp.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnExp.Location = new System.Drawing.Point(292, 168);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(145, 36);
            this.btnExp.TabIndex = 4;
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rb_loc);
            this.groupBox3.Controls.Add(this.rdb_co);
            this.groupBox3.Controls.Add(this.rdb_all);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 81);
            this.groupBox3.TabIndex = 322;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Show by";
            // 
            // rb_loc
            // 
            this.rb_loc.AutoSize = true;
            this.rb_loc.Location = new System.Drawing.Point(56, 54);
            this.rb_loc.Name = "rb_loc";
            this.rb_loc.Size = new System.Drawing.Size(79, 17);
            this.rb_loc.TabIndex = 7;
            this.rb_loc.Text = "LOCATION";
            this.rb_loc.UseVisualStyleBackColor = true;
            this.rb_loc.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 323;
            this.button1.Text = "Records";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmempdetailsexport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(461, 227);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvShow);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.CmbCompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExp);
            this.Controls.Add(this.BtnDisp_Bio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmempdetailsexport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMPLOYEE LIST";
            this.Load += new System.EventHandler(this.frmempdetailsexport_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.VistaButton BtnDisp_Bio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdb_all;
        private System.Windows.Forms.RadioButton rdb_co;
        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox chkFields;
        private System.Windows.Forms.DataGridView dgvShow;
        private System.Windows.Forms.RadioButton rdbActive;
        private System.Windows.Forms.RadioButton rdbInActive;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private EDPComponent.VistaButton btnExp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rb_loc;
        private System.Windows.Forms.Button button1;
    }
}