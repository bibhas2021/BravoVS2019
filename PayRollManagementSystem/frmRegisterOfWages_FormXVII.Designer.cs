namespace PayRollManagementSystem
{
    partial class frmRegisterOfWages_FormXVII
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegisterOfWages_FormXVII));
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnPrnt = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_company = new System.Windows.Forms.Label();
            this.Details = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbOld = new System.Windows.Forms.RadioButton();
            this.rbNew = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExport = new EDPComponent.VistaButton();
            this.lbl_ED = new System.Windows.Forms.Label();
            this.lbl_OT = new System.Windows.Forms.Label();
            this.lbl_NC = new System.Windows.Forms.Label();
            this.Details.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(101, 19);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(137, 21);
            this.cmbYear.TabIndex = 260;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 261;
            this.label1.Text = "Session";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(101, 46);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(470, 21);
            this.cmbLocation.TabIndex = 309;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(101, 73);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(470, 21);
            this.cmbcompany.TabIndex = 310;
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(101, 19);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(133, 20);
            this.AttenDtTmPkr.TabIndex = 311;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.AttenDtTmPkr_ValueChanged);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(295, 19);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(93, 30);
            this.btnPreview.TabIndex = 312;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrnt
            // 
            this.btnPrnt.BackColor = System.Drawing.Color.Transparent;
            this.btnPrnt.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrnt.ButtonText = "Print";
            this.btnPrnt.CornerRadius = 4;
            this.btnPrnt.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPrnt.Location = new System.Drawing.Point(394, 19);
            this.btnPrnt.Name = "btnPrnt";
            this.btnPrnt.Size = new System.Drawing.Size(93, 30);
            this.btnPrnt.TabIndex = 313;
            this.btnPrnt.Click += new System.EventHandler(this.btnPrnt_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(493, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 30);
            this.btnClose.TabIndex = 314;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 315;
            this.label2.Text = "Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 316;
            this.label3.Text = "Company";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 317;
            this.label4.Text = "Month";
            // 
            // lbl_company
            // 
            this.lbl_company.AutoSize = true;
            this.lbl_company.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_company.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_company.Location = new System.Drawing.Point(295, 19);
            this.lbl_company.Name = "lbl_company";
            this.lbl_company.Size = new System.Drawing.Size(2, 16);
            this.lbl_company.TabIndex = 318;
            this.lbl_company.Visible = false;
            // 
            // Details
            // 
            this.Details.Controls.Add(this.cmbYear);
            this.Details.Controls.Add(this.lbl_company);
            this.Details.Controls.Add(this.label3);
            this.Details.Controls.Add(this.cmbLocation);
            this.Details.Controls.Add(this.label1);
            this.Details.Controls.Add(this.label2);
            this.Details.Controls.Add(this.cmbcompany);
            this.Details.Location = new System.Drawing.Point(12, 30);
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(592, 100);
            this.Details.TabIndex = 319;
            this.Details.TabStop = false;
            this.Details.Text = "Details";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_show);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.AttenDtTmPkr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 93);
            this.groupBox1.TabIndex = 320;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chose For Month";
            // 
            // dgv_show
            // 
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Location = new System.Drawing.Point(12, 41);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.Size = new System.Drawing.Size(434, 46);
            this.dgv_show.TabIndex = 324;
            this.dgv_show.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbOld);
            this.groupBox4.Controls.Add(this.rbNew);
            this.groupBox4.Location = new System.Drawing.Point(469, 46);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(117, 41);
            this.groupBox4.TabIndex = 323;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Report Format";
            // 
            // rbOld
            // 
            this.rbOld.AutoSize = true;
            this.rbOld.Location = new System.Drawing.Point(10, 18);
            this.rbOld.Name = "rbOld";
            this.rbOld.Size = new System.Drawing.Size(41, 17);
            this.rbOld.TabIndex = 320;
            this.rbOld.TabStop = true;
            this.rbOld.Text = "Old";
            this.rbOld.UseVisualStyleBackColor = true;
            // 
            // rbNew
            // 
            this.rbNew.AutoSize = true;
            this.rbNew.Location = new System.Drawing.Point(54, 18);
            this.rbNew.Name = "rbNew";
            this.rbNew.Size = new System.Drawing.Size(47, 17);
            this.rbNew.TabIndex = 321;
            this.rbNew.TabStop = true;
            this.rbNew.Text = "New";
            this.rbNew.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Location = new System.Drawing.Point(469, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(117, 32);
            this.groupBox3.TabIndex = 322;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Page Size";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(38, 17);
            this.radioButton1.TabIndex = 315;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "A4";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(50, 13);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(51, 17);
            this.radioButton2.TabIndex = 318;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Legal";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 319;
            this.label5.Text = "Print In";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnPrnt);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.btnPreview);
            this.groupBox2.Location = new System.Drawing.Point(12, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 60);
            this.groupBox2.TabIndex = 321;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Print Option";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.ButtonText = "Expport to Excel (Format 3)";
            this.btnExport.CornerRadius = 4;
            this.btnExport.ImageSize = new System.Drawing.Size(16, 16);
            this.btnExport.Location = new System.Drawing.Point(101, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(169, 30);
            this.btnExport.TabIndex = 312;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lbl_ED
            // 
            this.lbl_ED.AutoSize = true;
            this.lbl_ED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ED.Location = new System.Drawing.Point(611, 165);
            this.lbl_ED.Name = "lbl_ED";
            this.lbl_ED.Size = new System.Drawing.Size(2, 15);
            this.lbl_ED.TabIndex = 324;
            this.lbl_ED.Visible = false;
            // 
            // lbl_OT
            // 
            this.lbl_OT.AutoSize = true;
            this.lbl_OT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_OT.Location = new System.Drawing.Point(611, 146);
            this.lbl_OT.Name = "lbl_OT";
            this.lbl_OT.Size = new System.Drawing.Size(2, 15);
            this.lbl_OT.TabIndex = 323;
            this.lbl_OT.Visible = false;
            // 
            // lbl_NC
            // 
            this.lbl_NC.AutoSize = true;
            this.lbl_NC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_NC.Location = new System.Drawing.Point(611, 127);
            this.lbl_NC.Name = "lbl_NC";
            this.lbl_NC.Size = new System.Drawing.Size(2, 15);
            this.lbl_NC.TabIndex = 322;
            this.lbl_NC.Visible = false;
            // 
            // frmRegisterOfWages_FormXVII
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 307);
            this.Controls.Add(this.lbl_ED);
            this.Controls.Add(this.lbl_OT);
            this.Controls.Add(this.lbl_NC);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Details);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRegisterOfWages_FormXVII";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register of Wages FormXVII";
            this.Load += new System.EventHandler(this.frmRegisterOfWages_FormXVII_Load);
            this.Details.ResumeLayout(false);
            this.Details.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label1;
        private EDPComponent.ComboDialog cmbLocation;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnPrnt;
        private EDPComponent.VistaButton btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_company;
        private System.Windows.Forms.GroupBox Details;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbNew;
        private System.Windows.Forms.RadioButton rbOld;
        private System.Windows.Forms.GroupBox groupBox4;
        private EDPComponent.VistaButton btnExport;
        private System.Windows.Forms.DataGridView dgv_show;
        private System.Windows.Forms.Label lbl_ED;
        private System.Windows.Forms.Label lbl_OT;
        private System.Windows.Forms.Label lbl_NC;
    }
}