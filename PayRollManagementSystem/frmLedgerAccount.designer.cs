namespace PayRollManagementSystem
{
    partial class frmLedgerAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLedgerAccount));
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.cmbclient = new EDPComponent.ComboDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbltype = new System.Windows.Forms.Label();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.rdbComp = new System.Windows.Forms.RadioButton();
            this.rdbLocation = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.rdbZone = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.ForeColor = System.Drawing.Color.Black;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(98, 15);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(118, 21);
            this.cmbYear.TabIndex = 261;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(35, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 262;
            this.label22.Text = "Session";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 263;
            this.label1.Text = "Date Form";
            // 
            // dtp_from
            // 
            this.dtp_from.CustomFormat = "dd/MM/yyyy";
            this.dtp_from.Enabled = false;
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from.Location = new System.Drawing.Point(98, 44);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(118, 20);
            this.dtp_from.TabIndex = 264;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(320, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 265;
            this.label2.Text = "Date To";
            // 
            // dtp_to
            // 
            this.dtp_to.CustomFormat = "dd/MM/yyyy";
            this.dtp_to.Enabled = false;
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(377, 42);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(111, 20);
            this.dtp_to.TabIndex = 266;
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(70, 29);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(459, 21);
            this.cmbcompany.TabIndex = 312;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // cmbclient
            // 
            this.cmbclient.Connection = null;
            this.cmbclient.DialogResult = "";
            this.cmbclient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclient.Location = new System.Drawing.Point(56, 287);
            this.cmbclient.LOVFlag = 0;
            this.cmbclient.MaxCharLength = 500;
            this.cmbclient.Name = "cmbclient";
            this.cmbclient.ReturnIndex = -1;
            this.cmbclient.ReturnValue = "";
            this.cmbclient.ReturnValue_3rd = "";
            this.cmbclient.ReturnValue_4th = "";
            this.cmbclient.Size = new System.Drawing.Size(37, 21);
            this.cmbclient.TabIndex = 315;
            this.cmbclient.Visible = false;
            this.cmbclient.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbclient_DropDown);
            this.cmbclient.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbclient_CloseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 317;
            this.label4.Text = "Company";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 318;
            this.label6.Text = "Client";
            this.label6.Visible = false;
            // 
            // lbltype
            // 
            this.lbltype.AutoSize = true;
            this.lbltype.Location = new System.Drawing.Point(9, 65);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(56, 13);
            this.lbltype.TabIndex = 319;
            this.lbltype.Text = "Location";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.BaseColor = System.Drawing.Color.SlateGray;
            this.btnPreview.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnPreview.ButtonText = "Preview";
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.GlowColor = System.Drawing.Color.Aqua;
            this.btnPreview.Location = new System.Drawing.Point(206, 19);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(101, 29);
            this.btnPreview.TabIndex = 320;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.SlateGray;
            this.btnClose.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.GlowColor = System.Drawing.Color.Aqua;
            this.btnClose.Location = new System.Drawing.Point(418, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 29);
            this.btnClose.TabIndex = 321;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(69, 62);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(460, 21);
            this.cmbLocation.TabIndex = 322;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // rdbComp
            // 
            this.rdbComp.AutoSize = true;
            this.rdbComp.Location = new System.Drawing.Point(103, 15);
            this.rdbComp.Name = "rdbComp";
            this.rdbComp.Size = new System.Drawing.Size(76, 17);
            this.rdbComp.TabIndex = 324;
            this.rdbComp.TabStop = true;
            this.rdbComp.Text = "Company";
            this.rdbComp.UseVisualStyleBackColor = true;
            this.rdbComp.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdbLocation
            // 
            this.rdbLocation.AutoSize = true;
            this.rdbLocation.Location = new System.Drawing.Point(228, 15);
            this.rdbLocation.Name = "rdbLocation";
            this.rdbLocation.Size = new System.Drawing.Size(110, 17);
            this.rdbLocation.TabIndex = 325;
            this.rdbLocation.TabStop = true;
            this.rdbLocation.Text = "Client-Location";
            this.rdbLocation.UseVisualStyleBackColor = true;
            this.rdbLocation.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(298, 289);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(204, 11);
            this.dataGridView1.TabIndex = 326;
            this.dataGridView1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp_to);
            this.groupBox1.Controls.Add(this.dtp_from);
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Location = new System.Drawing.Point(14, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 68);
            this.groupBox1.TabIndex = 327;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbZone);
            this.groupBox2.Controls.Add(this.rdbLocation);
            this.groupBox2.Controls.Add(this.rdbComp);
            this.groupBox2.Location = new System.Drawing.Point(14, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 40);
            this.groupBox2.TabIndex = 328;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SEARCH BY";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmbcompany);
            this.groupBox3.Controls.Add(this.lbltype);
            this.groupBox3.Controls.Add(this.cmbLocation);
            this.groupBox3.Location = new System.Drawing.Point(14, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(535, 92);
            this.groupBox3.TabIndex = 329;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CHOOSE DETAILS";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.vistaButton1);
            this.groupBox4.Controls.Add(this.btnPreview);
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Location = new System.Drawing.Point(14, 227);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(535, 54);
            this.groupBox4.TabIndex = 330;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PRINT DETAILS";
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.BaseColor = System.Drawing.Color.SlateGray;
            this.vistaButton1.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.vistaButton1.ButtonText = "Print";
            this.vistaButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton1.GlowColor = System.Drawing.Color.Aqua;
            this.vistaButton1.Location = new System.Drawing.Point(311, 19);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(101, 29);
            this.vistaButton1.TabIndex = 322;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // rdbZone
            // 
            this.rdbZone.AutoSize = true;
            this.rdbZone.Checked = true;
            this.rdbZone.Location = new System.Drawing.Point(377, 15);
            this.rdbZone.Name = "rdbZone";
            this.rdbZone.Size = new System.Drawing.Size(83, 17);
            this.rdbZone.TabIndex = 326;
            this.rdbZone.TabStop = true;
            this.rdbZone.Text = "Zone wise";
            this.rdbZone.UseVisualStyleBackColor = true;
            this.rdbZone.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // frmLedgerAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 299);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbclient);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLedgerAccount";
            this.Text = "LEDGER ACCOUNT";
            this.Load += new System.EventHandler(this.frmLedgerAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private EDPComponent.ComboDialog cmbcompany;
        private EDPComponent.ComboDialog cmbclient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbltype;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.RadioButton rdbComp;
        private System.Windows.Forms.RadioButton rdbLocation;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private EDPComponent.VistaButton vistaButton1;
        private System.Windows.Forms.RadioButton rdbZone;
    }
}