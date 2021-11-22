namespace PayRollManagementSystem
{
    partial class frmRegister_Bonus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister_Bonus));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpUpto = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnlog = new EDPComponent.VistaButton();
            this.LblCompany = new System.Windows.Forms.Label();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.LblLocation = new System.Windows.Forms.Label();
            this.LblSession = new System.Windows.Forms.Label();
            this.CmbSession = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdb_loc = new System.Windows.Forms.RadioButton();
            this.rdb_Co = new System.Windows.Forms.RadioButton();
            this.txtBonusHead = new System.Windows.Forms.TextBox();
            this.txtBonus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 274;
            this.label3.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 14);
            this.label2.TabIndex = 273;
            this.label2.Text = "Month Range from";
            // 
            // dtpUpto
            // 
            this.dtpUpto.Checked = false;
            this.dtpUpto.CustomFormat = "MMMM - yyyy";
            this.dtpUpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUpto.Location = new System.Drawing.Point(271, 49);
            this.dtpUpto.Name = "dtpUpto";
            this.dtpUpto.Size = new System.Drawing.Size(139, 20);
            this.dtpUpto.TabIndex = 271;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Checked = false;
            this.dtpFrom.CustomFormat = "MMMM - yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(125, 49);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(121, 20);
            this.dtpFrom.TabIndex = 272;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPreview);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Location = new System.Drawing.Point(23, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 54);
            this.groupBox3.TabIndex = 327;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Print Details";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "Export";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(298, 18);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(90, 30);
            this.btnPreview.TabIndex = 315;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(394, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 320;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtBonus);
            this.groupBox2.Controls.Add(this.txtBonusHead);
            this.groupBox2.Controls.Add(this.btnlog);
            this.groupBox2.Controls.Add(this.LblCompany);
            this.groupBox2.Controls.Add(this.CmbCompany);
            this.groupBox2.Controls.Add(this.LblLocation);
            this.groupBox2.Location = new System.Drawing.Point(23, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 95);
            this.groupBox2.TabIndex = 326;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select";
            // 
            // btnlog
            // 
            this.btnlog.BackColor = System.Drawing.Color.Transparent;
            this.btnlog.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnlog.ButtonText = "Select Location";
            this.btnlog.CornerRadius = 4;
            this.btnlog.ImageSize = new System.Drawing.Size(16, 16);
            this.btnlog.Location = new System.Drawing.Point(63, 43);
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(132, 28);
            this.btnlog.TabIndex = 319;
            this.btnlog.Click += new System.EventHandler(this.btnlog_Click);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(6, 20);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(51, 13);
            this.LblCompany.TabIndex = 311;
            this.LblCompany.Text = "Company";
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(63, 16);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(379, 21);
            this.CmbCompany.TabIndex = 0;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Location = new System.Drawing.Point(6, 51);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(48, 13);
            this.LblLocation.TabIndex = 312;
            this.LblLocation.Text = "Location";
            // 
            // LblSession
            // 
            this.LblSession.AutoSize = true;
            this.LblSession.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSession.Location = new System.Drawing.Point(8, 22);
            this.LblSession.Name = "LblSession";
            this.LblSession.Size = new System.Drawing.Size(52, 14);
            this.LblSession.TabIndex = 316;
            this.LblSession.Text = "Session";
            // 
            // CmbSession
            // 
            this.CmbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSession.FormattingEnabled = true;
            this.CmbSession.Location = new System.Drawing.Point(125, 19);
            this.CmbSession.Name = "CmbSession";
            this.CmbSession.Size = new System.Drawing.Size(121, 21);
            this.CmbSession.TabIndex = 317;
            this.CmbSession.SelectedIndexChanged += new System.EventHandler(this.CmbSession_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblSession);
            this.groupBox1.Controls.Add(this.CmbSession);
            this.groupBox1.Controls.Add(this.dtpUpto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(23, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 82);
            this.groupBox1.TabIndex = 328;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdb_loc);
            this.groupBox4.Controls.Add(this.rdb_Co);
            this.groupBox4.Location = new System.Drawing.Point(23, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(480, 44);
            this.groupBox4.TabIndex = 329;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search by";
            // 
            // rdb_loc
            // 
            this.rdb_loc.AutoSize = true;
            this.rdb_loc.Location = new System.Drawing.Point(291, 13);
            this.rdb_loc.Name = "rdb_loc";
            this.rdb_loc.Size = new System.Drawing.Size(90, 17);
            this.rdb_loc.TabIndex = 320;
            this.rdb_loc.Text = "Location wise";
            this.rdb_loc.UseVisualStyleBackColor = true;
            this.rdb_loc.CheckedChanged += new System.EventHandler(this.rdb_Co_CheckedChanged);
            // 
            // rdb_Co
            // 
            this.rdb_Co.AutoSize = true;
            this.rdb_Co.Checked = true;
            this.rdb_Co.Location = new System.Drawing.Point(107, 13);
            this.rdb_Co.Name = "rdb_Co";
            this.rdb_Co.Size = new System.Drawing.Size(93, 17);
            this.rdb_Co.TabIndex = 319;
            this.rdb_Co.TabStop = true;
            this.rdb_Co.Text = "Company wise";
            this.rdb_Co.UseVisualStyleBackColor = true;
            this.rdb_Co.CheckedChanged += new System.EventHandler(this.rdb_Co_CheckedChanged);
            // 
            // txtBonusHead
            // 
            this.txtBonusHead.Location = new System.Drawing.Point(271, 48);
            this.txtBonusHead.Name = "txtBonusHead";
            this.txtBonusHead.Size = new System.Drawing.Size(88, 20);
            this.txtBonusHead.TabIndex = 320;
            this.txtBonusHead.Text = "BS+DA";
            this.txtBonusHead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBonus
            // 
            this.txtBonus.Location = new System.Drawing.Point(387, 48);
            this.txtBonus.Name = "txtBonus";
            this.txtBonus.Size = new System.Drawing.Size(40, 20);
            this.txtBonus.TabIndex = 321;
            this.txtBonus.Text = "8.33";
            this.txtBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 322;
            this.label1.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 322;
            this.label4.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 322;
            this.label5.Text = "Based on";
            // 
            // frmRegister_Bonus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(525, 326);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegister_Bonus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register Bonus";
            this.Load += new System.EventHandler(this.frmRegister_Bonus_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpUpto;
        public System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.GroupBox groupBox3;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblCompany;
        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.Label LblSession;
        private System.Windows.Forms.ComboBox CmbSession;
        private System.Windows.Forms.GroupBox groupBox1;
        private EDPComponent.VistaButton btnlog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdb_loc;
        private System.Windows.Forms.RadioButton rdb_Co;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBonus;
        private System.Windows.Forms.TextBox txtBonusHead;
        private System.Windows.Forms.Label label5;
    }
}