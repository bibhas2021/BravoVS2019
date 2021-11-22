namespace PayRollManagementSystem
{
    partial class frmCompanyBillConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanyBillConfig));
            this.label6 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.lblCoid = new System.Windows.Forms.Label();
            this.txt_Odetails = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new EDPComponent.VistaButton();
            this.btnSave = new EDPComponent.VistaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTermsConditions = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(13, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 14);
            this.label6.TabIndex = 295;
            this.label6.Text = "Company Name";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(101, 28);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(442, 21);
            this.cmbcompany.TabIndex = 294;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // lblCoid
            // 
            this.lblCoid.AutoSize = true;
            this.lblCoid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCoid.ForeColor = System.Drawing.Color.Black;
            this.lblCoid.Location = new System.Drawing.Point(549, 31);
            this.lblCoid.Name = "lblCoid";
            this.lblCoid.Size = new System.Drawing.Size(2, 16);
            this.lblCoid.TabIndex = 296;
            this.lblCoid.Visible = false;
            // 
            // txt_Odetails
            // 
            this.txt_Odetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Odetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Odetails.ForeColor = System.Drawing.Color.Black;
            this.txt_Odetails.Location = new System.Drawing.Point(101, 93);
            this.txt_Odetails.Name = "txt_Odetails";
            this.txt_Odetails.Size = new System.Drawing.Size(442, 107);
            this.txt_Odetails.TabIndex = 297;
            this.txt_Odetails.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.TabIndex = 295;
            this.label1.Text = "Other Details";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BaseColor = System.Drawing.Color.SlateGray;
            this.btnExit.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnExit.ButtonText = "Exit";
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.GlowColor = System.Drawing.Color.Aqua;
            this.btnExit.Location = new System.Drawing.Point(16, 407);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 31);
            this.btnExit.TabIndex = 313;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.SlateGray;
            this.btnSave.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.GlowColor = System.Drawing.Color.Aqua;
            this.btnSave.Location = new System.Drawing.Point(468, 407);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 312;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 28);
            this.label2.TabIndex = 295;
            this.label2.Text = "Terms &&\r\nConditions";
            // 
            // txtTermsConditions
            // 
            this.txtTermsConditions.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTermsConditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTermsConditions.ForeColor = System.Drawing.Color.Black;
            this.txtTermsConditions.Location = new System.Drawing.Point(101, 204);
            this.txtTermsConditions.Name = "txtTermsConditions";
            this.txtTermsConditions.Size = new System.Drawing.Size(442, 107);
            this.txtTermsConditions.TabIndex = 297;
            this.txtTermsConditions.Text = "";
            // 
            // frmCompanyBillConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(563, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTermsConditions);
            this.Controls.Add(this.txt_Odetails);
            this.Controls.Add(this.lblCoid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbcompany);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCompanyBillConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Bill Config";
            this.Load += new System.EventHandler(this.frmCompanyBillConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        public EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.Label lblCoid;
        private System.Windows.Forms.RichTextBox txt_Odetails;
        private System.Windows.Forms.Label label1;
        private EDPComponent.VistaButton btnExit;
        private EDPComponent.VistaButton btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtTermsConditions;
    }
}