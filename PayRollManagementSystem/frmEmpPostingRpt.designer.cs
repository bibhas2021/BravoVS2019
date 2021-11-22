namespace PayRollManagementSystem
{
    partial class frmEmpPostingRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpPostingRpt));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnPreview = new EDPComponent.VistaButton();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AttenDtTmPkr);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(306, 21);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(133, 20);
            this.AttenDtTmPkr.TabIndex = 265;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.AttenDtTmPkr_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(253, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 262;
            this.label21.Text = "Month";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label22.Location = new System.Drawing.Point(7, 23);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 15);
            this.label22.TabIndex = 261;
            this.label22.Text = "Session";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(97, 21);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(126, 21);
            this.cmbYear.TabIndex = 260;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(420, 161);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 19;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(315, 161);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 20;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(19, 108);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(82, 13);
            this.lblCompany.TabIndex = 294;
            this.lblCompany.Text = "Company Name";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbcompany.Location = new System.Drawing.Point(109, 102);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(360, 21);
            this.cmbcompany.TabIndex = 295;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // frmEmpPostingRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(528, 216);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpPostingRpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Posting Report";
            this.Load += new System.EventHandler(this.frmEmpPostingRpt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnPreview;
        private System.Windows.Forms.Label lblCompany;
        private EDPComponent.ComboDialog cmbcompany;
    }
}