namespace PayRollManagementSystem
{
    partial class frmKYCException
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKYCException));
            this.CmbSession = new System.Windows.Forms.ComboBox();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            this.LblSession = new System.Windows.Forms.Label();
            this.CmbLocation = new EDPComponent.ComboDialog();
            this.LblLocation = new System.Windows.Forms.Label();
            this.BtnKycException = new System.Windows.Forms.Button();
            this.ChkPhoto = new System.Windows.Forms.CheckBox();
            this.ChkIdentity = new System.Windows.Forms.CheckBox();
            this.ChkAddressProof = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkPassport = new System.Windows.Forms.CheckBox();
            this.ChkAdhar = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbSession
            // 
            this.CmbSession.FormattingEnabled = true;
            this.CmbSession.Location = new System.Drawing.Point(84, 27);
            this.CmbSession.Name = "CmbSession";
            this.CmbSession.Size = new System.Drawing.Size(113, 21);
            this.CmbSession.TabIndex = 299;
            this.CmbSession.UseWaitCursor = true;
            this.CmbSession.SelectedIndexChanged += new System.EventHandler(this.CmbSession_SelectedIndexChanged);
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(82, 68);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(375, 21);
            this.cmbcompany.TabIndex = 301;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(25, 76);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(51, 13);
            this.LblCompany.TabIndex = 302;
            this.LblCompany.Text = "Company";
            // 
            // LblSession
            // 
            this.LblSession.AutoSize = true;
            this.LblSession.Location = new System.Drawing.Point(25, 27);
            this.LblSession.Name = "LblSession";
            this.LblSession.Size = new System.Drawing.Size(44, 13);
            this.LblSession.TabIndex = 300;
            this.LblSession.Text = "Session";
            // 
            // CmbLocation
            // 
            this.CmbLocation.Connection = null;
            this.CmbLocation.DialogResult = "";
            this.CmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLocation.Location = new System.Drawing.Point(82, 108);
            this.CmbLocation.LOVFlag = 0;
            this.CmbLocation.MaxCharLength = 500;
            this.CmbLocation.Name = "CmbLocation";
            this.CmbLocation.ReturnIndex = -1;
            this.CmbLocation.ReturnValue = "";
            this.CmbLocation.ReturnValue_3rd = "";
            this.CmbLocation.ReturnValue_4th = "";
            this.CmbLocation.Size = new System.Drawing.Size(375, 21);
            this.CmbLocation.TabIndex = 303;
            this.CmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.CmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Location = new System.Drawing.Point(25, 113);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(48, 13);
            this.LblLocation.TabIndex = 304;
            this.LblLocation.Text = "Location";
            // 
            // BtnKycException
            // 
            this.BtnKycException.Location = new System.Drawing.Point(191, 253);
            this.BtnKycException.Name = "BtnKycException";
            this.BtnKycException.Size = new System.Drawing.Size(140, 23);
            this.BtnKycException.TabIndex = 305;
            this.BtnKycException.Text = "KYC Exception Report";
            this.BtnKycException.UseVisualStyleBackColor = true;
            this.BtnKycException.Click += new System.EventHandler(this.BtnKycException_Click);
            // 
            // ChkPhoto
            // 
            this.ChkPhoto.AutoSize = true;
            this.ChkPhoto.Location = new System.Drawing.Point(9, 25);
            this.ChkPhoto.Name = "ChkPhoto";
            this.ChkPhoto.Size = new System.Drawing.Size(90, 17);
            this.ChkPhoto.TabIndex = 306;
            this.ChkPhoto.Text = "Photo Absent";
            this.ChkPhoto.UseVisualStyleBackColor = true;
            // 
            // ChkIdentity
            // 
            this.ChkIdentity.AutoSize = true;
            this.ChkIdentity.Location = new System.Drawing.Point(9, 48);
            this.ChkIdentity.Name = "ChkIdentity";
            this.ChkIdentity.Size = new System.Drawing.Size(106, 17);
            this.ChkIdentity.TabIndex = 307;
            this.ChkIdentity.Text = "Pan Card Absent";
            this.ChkIdentity.UseVisualStyleBackColor = true;
            // 
            // ChkAddressProof
            // 
            this.ChkAddressProof.AutoSize = true;
            this.ChkAddressProof.Location = new System.Drawing.Point(292, 47);
            this.ChkAddressProof.Name = "ChkAddressProof";
            this.ChkAddressProof.Size = new System.Drawing.Size(112, 17);
            this.ChkAddressProof.TabIndex = 308;
            this.ChkAddressProof.Text = "Voter Card Absent";
            this.ChkAddressProof.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkPassport);
            this.groupBox1.Controls.Add(this.ChkAdhar);
            this.groupBox1.Controls.Add(this.ChkPhoto);
            this.groupBox1.Controls.Add(this.ChkAddressProof);
            this.groupBox1.Controls.Add(this.ChkIdentity);
            this.groupBox1.Location = new System.Drawing.Point(27, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 99);
            this.groupBox1.TabIndex = 309;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search by";
            // 
            // ChkPassport
            // 
            this.ChkPassport.AutoSize = true;
            this.ChkPassport.Location = new System.Drawing.Point(292, 71);
            this.ChkPassport.Name = "ChkPassport";
            this.ChkPassport.Size = new System.Drawing.Size(103, 17);
            this.ChkPassport.TabIndex = 310;
            this.ChkPassport.Text = "Passport Absent";
            this.ChkPassport.UseVisualStyleBackColor = true;
            // 
            // ChkAdhar
            // 
            this.ChkAdhar.AutoSize = true;
            this.ChkAdhar.Location = new System.Drawing.Point(9, 71);
            this.ChkAdhar.Name = "ChkAdhar";
            this.ChkAdhar.Size = new System.Drawing.Size(115, 17);
            this.ChkAdhar.TabIndex = 309;
            this.ChkAdhar.Text = "Adhar Card Absent";
            this.ChkAdhar.UseVisualStyleBackColor = true;
            // 
            // frmKYCException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 312);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnKycException);
            this.Controls.Add(this.CmbLocation);
            this.Controls.Add(this.LblLocation);
            this.Controls.Add(this.CmbSession);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.LblSession);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKYCException";
            this.Text = "Kyc Exception";
            this.Load += new System.EventHandler(this.frmKYCException_Load);
            this.Controls.SetChildIndex(this.LblSession, 0);
            this.Controls.SetChildIndex(this.LblCompany, 0);
            this.Controls.SetChildIndex(this.cmbcompany, 0);
            this.Controls.SetChildIndex(this.CmbSession, 0);
            this.Controls.SetChildIndex(this.LblLocation, 0);
            this.Controls.SetChildIndex(this.CmbLocation, 0);
            this.Controls.SetChildIndex(this.BtnKycException, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbSession;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Label LblSession;
        private EDPComponent.ComboDialog CmbLocation;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.Button BtnKycException;
        private System.Windows.Forms.CheckBox ChkPhoto;
        private System.Windows.Forms.CheckBox ChkIdentity;
        private System.Windows.Forms.CheckBox ChkAddressProof;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ChkAdhar;
        private System.Windows.Forms.CheckBox ChkPassport;
    }
}