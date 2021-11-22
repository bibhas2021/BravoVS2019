namespace PayRollManagementSystem
{
    partial class Reg_Advance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reg_Advance));
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbLoc = new EDPComponent.ComboDialog();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.label21 = new System.Windows.Forms.Label();
            this.btnPreview = new EDPComponent.VistaButton();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.lblLoc = new System.Windows.Forms.Label();
            this.btnClose = new EDPComponent.VistaButton();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.lblClient = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(112, 17);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(126, 21);
            this.cmbYear.TabIndex = 296;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCompany.Location = new System.Drawing.Point(24, 66);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(82, 13);
            this.lblCompany.TabIndex = 302;
            this.lblCompany.Text = "Company Name";
            // 
            // cmbLoc
            // 
            this.cmbLoc.Connection = null;
            this.cmbLoc.DialogResult = "";
            this.cmbLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbLoc.Location = new System.Drawing.Point(112, 103);
            this.cmbLoc.LOVFlag = 0;
            this.cmbLoc.MaxCharLength = 500;
            this.cmbLoc.Name = "cmbLoc";
            this.cmbLoc.ReturnIndex = -1;
            this.cmbLoc.ReturnValue = "";
            this.cmbLoc.ReturnValue_3rd = "";
            this.cmbLoc.ReturnValue_4th = "";
            this.cmbLoc.Size = new System.Drawing.Size(387, 21);
            this.cmbLoc.TabIndex = 301;
            this.cmbLoc.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLoc_DropDown);
            this.cmbLoc.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLoc_CloseUp);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(24, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 15);
            this.label22.TabIndex = 295;
            this.label22.Text = "Session";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbcompany.Location = new System.Drawing.Point(112, 66);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(387, 21);
            this.cmbcompany.TabIndex = 300;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(327, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 297;
            this.label21.Text = "Month";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(243, 158);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 294;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(366, 17);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(133, 20);
            this.AttenDtTmPkr.TabIndex = 298;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.AttenDtTmPkr_ValueChanged);
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLoc.Location = new System.Drawing.Point(24, 107);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(48, 13);
            this.lblLoc.TabIndex = 299;
            this.lblLoc.Text = "Location";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(419, 158);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 303;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.vistaButton1.ButtonText = "  Print";
            this.vistaButton1.CornerRadius = 4;
            this.vistaButton1.ImageSize = new System.Drawing.Size(16, 16);
            this.vistaButton1.Location = new System.Drawing.Point(333, 158);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(80, 30);
            this.vistaButton1.TabIndex = 304;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClient.Location = new System.Drawing.Point(113, 131);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(2, 15);
            this.lblClient.TabIndex = 305;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(24, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 299;
            this.label1.Text = "Client";
            // 
            // Reg_Advance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(535, 204);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.cmbLoc);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.AttenDtTmPkr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reg_Advance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADVANCE REGISTER";
            this.Load += new System.EventHandler(this.frmUserWorkLog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblCompany;
        private EDPComponent.ComboDialog cmbLoc;
        private System.Windows.Forms.Label label22;
        private EDPComponent.ComboDialog cmbcompany;
        internal System.Windows.Forms.Label label21;
        private EDPComponent.VistaButton btnPreview;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        private System.Windows.Forms.Label lblLoc;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton vistaButton1;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label label1;
    }
}