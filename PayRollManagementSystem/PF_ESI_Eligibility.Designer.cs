namespace PayRollManagementSystem
{
    partial class PF_ESI_Eligibility
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PF_ESI_Eligibility));
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbCompany = new EDPComponent.ComboDialog();
            this.chkALL = new System.Windows.Forms.CheckBox();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.chkACNames = new System.Windows.Forms.CheckBox();
            this.rdbMatched = new System.Windows.Forms.RadioButton();
            this.rdbNotMatched = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrnt = new EDPComponent.VistaButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblCompany.Location = new System.Drawing.Point(21, 37);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(68, 15);
            this.lblCompany.TabIndex = 245;
            this.lblCompany.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.Connection = null;
            this.cmbCompany.DialogResult = "";
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.Location = new System.Drawing.Point(101, 33);
            this.cmbCompany.LOVFlag = 0;
            this.cmbCompany.MaxCharLength = 500;
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.ReturnIndex = -1;
            this.cmbCompany.ReturnValue = "";
            this.cmbCompany.ReturnValue_3rd = "";
            this.cmbCompany.ReturnValue_4th = "";
            this.cmbCompany.Size = new System.Drawing.Size(447, 21);
            this.cmbCompany.TabIndex = 296;
            this.cmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbCompany_DropDown);
            this.cmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbCompany_DropDown);
            // 
            // chkALL
            // 
            this.chkALL.AutoSize = true;
            this.chkALL.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkALL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chkALL.Location = new System.Drawing.Point(60, 30);
            this.chkALL.Name = "chkALL";
            this.chkALL.Size = new System.Drawing.Size(151, 19);
            this.chkALL.TabIndex = 298;
            this.chkALL.Text = "PF_ESI ELIGIBILITY";
            this.chkALL.UseVisualStyleBackColor = true;
            this.chkALL.CheckedChanged += new System.EventHandler(this.chkALL_CheckedChanged);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(296, 203);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 299;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(491, 203);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 300;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkACNames
            // 
            this.chkACNames.AutoSize = true;
            this.chkACNames.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkACNames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chkACNames.Location = new System.Drawing.Point(348, 30);
            this.chkACNames.Name = "chkACNames";
            this.chkACNames.Size = new System.Drawing.Size(100, 19);
            this.chkACNames.TabIndex = 302;
            this.chkACNames.Text = "A/C NAMES";
            this.chkACNames.UseVisualStyleBackColor = true;
            this.chkACNames.CheckedChanged += new System.EventHandler(this.chkACNames_CheckedChanged);
            // 
            // rdbMatched
            // 
            this.rdbMatched.AutoSize = true;
            this.rdbMatched.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMatched.ForeColor = System.Drawing.Color.Green;
            this.rdbMatched.Location = new System.Drawing.Point(370, 55);
            this.rdbMatched.Name = "rdbMatched";
            this.rdbMatched.Size = new System.Drawing.Size(78, 17);
            this.rdbMatched.TabIndex = 303;
            this.rdbMatched.TabStop = true;
            this.rdbMatched.Text = "MATCHED";
            this.rdbMatched.UseVisualStyleBackColor = true;
            // 
            // rdbNotMatched
            // 
            this.rdbNotMatched.AutoSize = true;
            this.rdbNotMatched.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNotMatched.ForeColor = System.Drawing.Color.Maroon;
            this.rdbNotMatched.Location = new System.Drawing.Point(370, 80);
            this.rdbNotMatched.Name = "rdbNotMatched";
            this.rdbNotMatched.Size = new System.Drawing.Size(107, 17);
            this.rdbNotMatched.TabIndex = 304;
            this.rdbNotMatched.TabStop = true;
            this.rdbNotMatched.Text = "NOT_MATCHED";
            this.rdbNotMatched.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkALL);
            this.groupBox1.Controls.Add(this.rdbNotMatched);
            this.groupBox1.Controls.Add(this.chkACNames);
            this.groupBox1.Controls.Add(this.rdbMatched);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 110);
            this.groupBox1.TabIndex = 305;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SELECT";
            // 
            // btnPrnt
            // 
            this.btnPrnt.BackColor = System.Drawing.Color.Transparent;
            this.btnPrnt.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrnt.ButtonText = "     Print";
            this.btnPrnt.CornerRadius = 4;
            this.btnPrnt.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPrnt.Location = new System.Drawing.Point(394, 203);
            this.btnPrnt.Name = "btnPrnt";
            this.btnPrnt.Size = new System.Drawing.Size(79, 30);
            this.btnPrnt.TabIndex = 306;
            this.btnPrnt.Click += new System.EventHandler(this.btnPrnt_Click);
            // 
            // PF_ESI_Eligibility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 258);
            this.Controls.Add(this.btnPrnt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblCompany);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PF_ESI_Eligibility";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PF ESI Eligibility";
            this.Load += new System.EventHandler(this.PF_ESI_Eligibility_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompany;
        private EDPComponent.ComboDialog cmbCompany;
        private System.Windows.Forms.CheckBox chkALL;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnClose;
        private System.Windows.Forms.CheckBox chkACNames;
        private System.Windows.Forms.RadioButton rdbMatched;
        private System.Windows.Forms.RadioButton rdbNotMatched;
        private System.Windows.Forms.GroupBox groupBox1;
        private EDPComponent.VistaButton btnPrnt;
    }
}