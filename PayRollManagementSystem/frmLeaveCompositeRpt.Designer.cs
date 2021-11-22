namespace PayRollManagementSystem
{
    partial class frmLeaveCompositeRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeaveCompositeRpt));
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.LblLocation = new System.Windows.Forms.Label();
            this.LblCompany = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.label22 = new System.Windows.Forms.Label();
            this.lstMon = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHead = new System.Windows.Forms.TextBox();
            this.btnExport = new EDPComponent.VistaButton();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(97, 12);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(356, 21);
            this.CmbCompany.TabIndex = 10;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_CloseUp);
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Location = new System.Drawing.Point(19, 40);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(48, 13);
            this.LblLocation.TabIndex = 12;
            this.LblLocation.Text = "Location";
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(19, 16);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(51, 13);
            this.LblCompany.TabIndex = 13;
            this.LblCompany.Text = "Company";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(97, 36);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(356, 21);
            this.cmbLocation.TabIndex = 11;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(19, 66);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 13);
            this.label22.TabIndex = 259;
            this.label22.Text = "Select Year";
            // 
            // lstMon
            // 
            this.lstMon.FormattingEnabled = true;
            this.lstMon.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.lstMon.Location = new System.Drawing.Point(95, 91);
            this.lstMon.Name = "lstMon";
            this.lstMon.Size = new System.Drawing.Size(86, 95);
            this.lstMon.TabIndex = 260;
            this.lstMon.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 259;
            this.label1.Text = "HEAD";
            // 
            // txtHead
            // 
            this.txtHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHead.Location = new System.Drawing.Point(353, 63);
            this.txtHead.Name = "txtHead";
            this.txtHead.Size = new System.Drawing.Size(100, 20);
            this.txtHead.TabIndex = 261;
            this.txtHead.Text = "BS+DA";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.ButtonText = "Export";
            this.btnExport.CornerRadius = 4;
            this.btnExport.ImageSize = new System.Drawing.Size(16, 16);
            this.btnExport.Location = new System.Drawing.Point(333, 105);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 30);
            this.btnExport.TabIndex = 262;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(97, 63);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.Size = new System.Drawing.Size(84, 20);
            this.dtpYear.TabIndex = 263;
            // 
            // frmLeaveCompositeRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(515, 198);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtHead);
            this.Controls.Add(this.lstMon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.CmbCompany);
            this.Controls.Add(this.LblLocation);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.cmbLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLeaveCompositeRpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leave Composite Report";
            this.Load += new System.EventHandler(this.frmLeaveCompositeRpt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.Label LblCompany;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ListBox lstMon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHead;
        private EDPComponent.VistaButton btnExport;
        private System.Windows.Forms.DateTimePicker dtpYear;
    }
}