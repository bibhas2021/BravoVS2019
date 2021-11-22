namespace PayRollManagementSystem
{
    partial class FrmAttRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAttRpt));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.label21 = new System.Windows.Forms.Label();
            this.rdbCompany = new System.Windows.Forms.RadioButton();
            this.rdbLocation = new System.Windows.Forms.RadioButton();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.chkWOdesg = new System.Windows.Forms.CheckBox();
            this.chkWdesg = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrnt = new EDPComponent.VistaButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkEmployee = new System.Windows.Forms.RadioButton();
            this.chkZone = new System.Windows.Forms.RadioButton();
            this.chkCompany = new System.Windows.Forms.RadioButton();
            this.chkLoc = new System.Windows.Forms.RadioButton();
            this.chkEmployeeMulti = new System.Windows.Forms.CheckBox();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MMMM, yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(407, 57);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(161, 26);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 51);
            this.panel1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(104, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(259, 36);
            this.label7.TabIndex = 2;
            this.label7.Text = "Attendance Report";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(98, 51);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(540, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(15, 131);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(559, 21);
            this.cmbcompany.TabIndex = 295;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(357, 59);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 20);
            this.label21.TabIndex = 294;
            this.label21.Text = "Month";
            // 
            // rdbCompany
            // 
            this.rdbCompany.AutoSize = true;
            this.rdbCompany.Location = new System.Drawing.Point(15, 25);
            this.rdbCompany.Name = "rdbCompany";
            this.rdbCompany.Size = new System.Drawing.Size(117, 24);
            this.rdbCompany.TabIndex = 297;
            this.rdbCompany.TabStop = true;
            this.rdbCompany.Text = "Company wise";
            this.rdbCompany.UseVisualStyleBackColor = true;
            // 
            // rdbLocation
            // 
            this.rdbLocation.AutoSize = true;
            this.rdbLocation.Location = new System.Drawing.Point(15, 49);
            this.rdbLocation.Name = "rdbLocation";
            this.rdbLocation.Size = new System.Drawing.Size(112, 24);
            this.rdbLocation.TabIndex = 297;
            this.rdbLocation.TabStop = true;
            this.rdbLocation.Text = "Location wise";
            this.rdbLocation.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(268, 23);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(90, 30);
            this.btnPreview.TabIndex = 299;
            this.btnPreview.Click += new System.EventHandler(this.BtnAttRpt_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(464, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 298;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkWOdesg
            // 
            this.chkWOdesg.AutoSize = true;
            this.chkWOdesg.Location = new System.Drawing.Point(6, 28);
            this.chkWOdesg.Name = "chkWOdesg";
            this.chkWOdesg.Size = new System.Drawing.Size(152, 24);
            this.chkWOdesg.TabIndex = 301;
            this.chkWOdesg.Text = "Without designation";
            this.chkWOdesg.UseVisualStyleBackColor = true;
            this.chkWOdesg.CheckedChanged += new System.EventHandler(this.chkWOdesg_CheckedChanged);
            // 
            // chkWdesg
            // 
            this.chkWdesg.AutoSize = true;
            this.chkWdesg.Location = new System.Drawing.Point(6, 50);
            this.chkWdesg.Name = "chkWdesg";
            this.chkWdesg.Size = new System.Drawing.Size(132, 24);
            this.chkWdesg.TabIndex = 302;
            this.chkWdesg.Text = "With designation";
            this.chkWdesg.UseVisualStyleBackColor = true;
            this.chkWdesg.CheckedChanged += new System.EventHandler(this.chkWdesg_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrnt);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(12, 277);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 59);
            this.groupBox1.TabIndex = 303;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print Details";
            // 
            // btnPrnt
            // 
            this.btnPrnt.BackColor = System.Drawing.Color.Transparent;
            this.btnPrnt.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrnt.ButtonText = "     Print";
            this.btnPrnt.CornerRadius = 4;
            this.btnPrnt.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPrnt.Location = new System.Drawing.Point(369, 23);
            this.btnPrnt.Name = "btnPrnt";
            this.btnPrnt.Size = new System.Drawing.Size(79, 30);
            this.btnPrnt.TabIndex = 307;
            this.btnPrnt.Click += new System.EventHandler(this.btnPrnt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkWOdesg);
            this.groupBox2.Controls.Add(this.chkWdesg);
            this.groupBox2.Location = new System.Drawing.Point(22, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 82);
            this.groupBox2.TabIndex = 304;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Show Report";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbCompany);
            this.groupBox3.Controls.Add(this.rdbLocation);
            this.groupBox3.Location = new System.Drawing.Point(392, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 82);
            this.groupBox3.TabIndex = 305;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Show Report by";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkEmployee);
            this.groupBox4.Controls.Add(this.chkZone);
            this.groupBox4.Controls.Add(this.chkCompany);
            this.groupBox4.Controls.Add(this.chkLoc);
            this.groupBox4.Location = new System.Drawing.Point(15, 85);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(559, 39);
            this.groupBox4.TabIndex = 306;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select";
            // 
            // chkEmployee
            // 
            this.chkEmployee.AutoSize = true;
            this.chkEmployee.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmployee.Location = new System.Drawing.Point(243, 15);
            this.chkEmployee.Name = "chkEmployee";
            this.chkEmployee.Size = new System.Drawing.Size(77, 20);
            this.chkEmployee.TabIndex = 303;
            this.chkEmployee.Text = "Employee";
            this.chkEmployee.UseVisualStyleBackColor = true;
            this.chkEmployee.CheckedChanged += new System.EventHandler(this.chkEmployee_CheckedChanged);
            // 
            // chkZone
            // 
            this.chkZone.AutoSize = true;
            this.chkZone.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkZone.Location = new System.Drawing.Point(456, 15);
            this.chkZone.Name = "chkZone";
            this.chkZone.Size = new System.Drawing.Size(53, 20);
            this.chkZone.TabIndex = 303;
            this.chkZone.Text = "Zone";
            this.chkZone.UseVisualStyleBackColor = true;
            this.chkZone.Visible = false;
            // 
            // chkCompany
            // 
            this.chkCompany.AutoSize = true;
            this.chkCompany.Checked = true;
            this.chkCompany.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompany.Location = new System.Drawing.Point(72, 14);
            this.chkCompany.Name = "chkCompany";
            this.chkCompany.Size = new System.Drawing.Size(76, 20);
            this.chkCompany.TabIndex = 302;
            this.chkCompany.TabStop = true;
            this.chkCompany.Text = "Company";
            this.chkCompany.UseVisualStyleBackColor = true;
            this.chkCompany.CheckedChanged += new System.EventHandler(this.chkCompany_CheckedChanged);
            // 
            // chkLoc
            // 
            this.chkLoc.AutoSize = true;
            this.chkLoc.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLoc.Location = new System.Drawing.Point(159, 15);
            this.chkLoc.Name = "chkLoc";
            this.chkLoc.Size = new System.Drawing.Size(73, 20);
            this.chkLoc.TabIndex = 301;
            this.chkLoc.Text = "Location";
            this.chkLoc.UseVisualStyleBackColor = true;
            this.chkLoc.CheckedChanged += new System.EventHandler(this.rdbLocation_CheckedChanged);
            // 
            // chkEmployeeMulti
            // 
            this.chkEmployeeMulti.AutoSize = true;
            this.chkEmployeeMulti.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmployeeMulti.Location = new System.Drawing.Point(87, 162);
            this.chkEmployeeMulti.Name = "chkEmployeeMulti";
            this.chkEmployeeMulti.Size = new System.Drawing.Size(114, 20);
            this.chkEmployeeMulti.TabIndex = 304;
            this.chkEmployeeMulti.Text = "Select Employee";
            this.chkEmployeeMulti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEmployeeMulti.UseVisualStyleBackColor = true;
            this.chkEmployeeMulti.CheckedChanged += new System.EventHandler(this.chkEmployeeMulti_CheckedChanged);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Enabled = false;
            this.btnEmployee.Location = new System.Drawing.Point(222, 157);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(215, 28);
            this.btnEmployee.TabIndex = 315;
            this.btnEmployee.Text = "Select Employee";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // FrmAttRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(602, 348);
            this.Controls.Add(this.chkEmployeeMulti);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dateTimePicker1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAttRpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAttRpt";
            this.Load += new System.EventHandler(this.FrmAttRpt_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private EDPComponent.ComboDialog cmbcompany;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.RadioButton rdbCompany;
        private System.Windows.Forms.RadioButton rdbLocation;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnClose;
        private System.Windows.Forms.CheckBox chkWOdesg;
        private System.Windows.Forms.CheckBox chkWdesg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private EDPComponent.VistaButton btnPrnt;
        private System.Windows.Forms.RadioButton chkZone;
        private System.Windows.Forms.RadioButton chkCompany;
        private System.Windows.Forms.RadioButton chkLoc;
        private System.Windows.Forms.CheckBox chkEmployeeMulti;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.RadioButton chkEmployee;
    }
}