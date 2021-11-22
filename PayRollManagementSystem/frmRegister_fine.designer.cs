namespace PayRollManagementSystem
{
    partial class frmRegister_fine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister_fine));
            this.CmbLocation = new EDPComponent.ComboDialog();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.LblLocation = new System.Windows.Forms.Label();
            this.LblCompany = new System.Windows.Forms.Label();
            this.btnPreview = new EDPComponent.VistaButton();
            this.label21 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.LblSession = new System.Windows.Forms.Label();
            this.btnClose = new EDPComponent.VistaButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CmbSession = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbLocation
            // 
            this.CmbLocation.Connection = null;
            this.CmbLocation.DialogResult = "";
            this.CmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLocation.Location = new System.Drawing.Point(63, 51);
            this.CmbLocation.LOVFlag = 0;
            this.CmbLocation.MaxCharLength = 500;
            this.CmbLocation.Name = "CmbLocation";
            this.CmbLocation.ReturnIndex = -1;
            this.CmbLocation.ReturnValue = "";
            this.CmbLocation.ReturnValue_3rd = "";
            this.CmbLocation.ReturnValue_4th = "";
            this.CmbLocation.Size = new System.Drawing.Size(379, 21);
            this.CmbLocation.TabIndex = 1;
            this.CmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbLocation_DropDown);
            this.CmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbLocation_DropDown_Closeup);
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
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_DropDown_Closeup);
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
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(6, 16);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(51, 13);
            this.LblCompany.TabIndex = 311;
            this.LblCompany.Text = "Company";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(194, 32);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(90, 30);
            this.btnPreview.TabIndex = 315;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(255, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 319;
            this.label21.Text = "Month";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MMMM, yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(294, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(161, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // LblSession
            // 
            this.LblSession.AutoSize = true;
            this.LblSession.Location = new System.Drawing.Point(27, 19);
            this.LblSession.Name = "LblSession";
            this.LblSession.Size = new System.Drawing.Size(44, 13);
            this.LblSession.TabIndex = 316;
            this.LblSession.Text = "Session";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(390, 32);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 320;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CmbSession);
            this.groupBox1.Controls.Add(this.LblSession);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 49);
            this.groupBox1.TabIndex = 321;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // CmbSession
            // 
            this.CmbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSession.FormattingEnabled = true;
            this.CmbSession.Location = new System.Drawing.Point(77, 16);
            this.CmbSession.Name = "CmbSession";
            this.CmbSession.Size = new System.Drawing.Size(126, 21);
            this.CmbSession.TabIndex = 322;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LblCompany);
            this.groupBox2.Controls.Add(this.CmbCompany);
            this.groupBox2.Controls.Add(this.LblLocation);
            this.groupBox2.Controls.Add(this.CmbLocation);
            this.groupBox2.Location = new System.Drawing.Point(26, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 95);
            this.groupBox2.TabIndex = 322;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.vistaButton1);
            this.groupBox3.Controls.Add(this.btnPreview);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Location = new System.Drawing.Point(26, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 74);
            this.groupBox3.TabIndex = 323;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Print Details";
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.vistaButton1.ButtonText = "  Print";
            this.vistaButton1.CornerRadius = 4;
            this.vistaButton1.ImageSize = new System.Drawing.Size(16, 16);
            this.vistaButton1.Location = new System.Drawing.Point(292, 32);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(90, 30);
            this.vistaButton1.TabIndex = 321;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // frmRegister_fine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 277);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegister_fine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FINE REGISTER";
            this.Load += new System.EventHandler(this.frmUserWorkLog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EDPComponent.ComboDialog CmbLocation;
        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.Label LblCompany;
        private EDPComponent.VistaButton btnPreview;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label LblSession;
        private EDPComponent.VistaButton btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private EDPComponent.VistaButton vistaButton1;
        internal System.Windows.Forms.ComboBox CmbSession;
    }
}