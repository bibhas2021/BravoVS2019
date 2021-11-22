namespace PayRollManagementSystem
{
    partial class Config_RetirementDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config_RetirementDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAge = new TextBoxX.TextBoxX();
            this.btnCancel = new EDPComponent.VistaButton();
            this.btnExit = new EDPComponent.VistaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new EDPComponent.VistaButton();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPenssionAge = new TextBoxX.TextBoxX();
            this.chkTillDate = new System.Windows.Forms.CheckBox();
            this.chkFullMonth = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPfAge = new TextBoxX.TextBoxX();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee\'s Age of Retirement";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(199, 72);
            this.txtAge.MaxLength = 2;
            this.txtAge.Name = "txtAge";
            this.txtAge.NumericStyle = TextBoxX.TextBoxX.Style.SignedInteger;
            this.txtAge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAge.Size = new System.Drawing.Size(33, 20);
            this.txtAge.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(29, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.ButtonText = "Exit";
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(172, 223);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 25);
            this.btnExit.TabIndex = 6;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 237;
            this.label2.Text = "Session";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.ButtonText = "Submit";
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(100, 223);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(60, 25);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(123, 42);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(109, 21);
            this.cmbYear.TabIndex = 1;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 15);
            this.label3.TabIndex = 240;
            this.label3.Text = "Employee\'s Age of Pension\r\n";
            // 
            // txtPenssionAge
            // 
            this.txtPenssionAge.Location = new System.Drawing.Point(199, 98);
            this.txtPenssionAge.MaxLength = 2;
            this.txtPenssionAge.Name = "txtPenssionAge";
            this.txtPenssionAge.NumericStyle = TextBoxX.TextBoxX.Style.SignedInteger;
            this.txtPenssionAge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPenssionAge.Size = new System.Drawing.Size(33, 20);
            this.txtPenssionAge.TabIndex = 3;
            // 
            // chkTillDate
            // 
            this.chkTillDate.AutoSize = true;
            this.chkTillDate.Location = new System.Drawing.Point(107, 22);
            this.chkTillDate.Name = "chkTillDate";
            this.chkTillDate.Size = new System.Drawing.Size(65, 17);
            this.chkTillDate.TabIndex = 246;
            this.chkTillDate.Text = "Till Date";
            this.chkTillDate.UseVisualStyleBackColor = true;
            // 
            // chkFullMonth
            // 
            this.chkFullMonth.AutoSize = true;
            this.chkFullMonth.Checked = true;
            this.chkFullMonth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFullMonth.Location = new System.Drawing.Point(26, 22);
            this.chkFullMonth.Name = "chkFullMonth";
            this.chkFullMonth.Size = new System.Drawing.Size(75, 17);
            this.chkFullMonth.TabIndex = 245;
            this.chkFullMonth.Text = "Full Month";
            this.chkFullMonth.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkFullMonth);
            this.groupBox1.Controls.Add(this.chkTillDate);
            this.groupBox1.Location = new System.Drawing.Point(29, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 47);
            this.groupBox1.TabIndex = 247;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consider Pension For";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 15);
            this.label4.TabIndex = 240;
            this.label4.Text = "Employee\'s Max Age of PF\r\n";
            // 
            // txtPfAge
            // 
            this.txtPfAge.Location = new System.Drawing.Point(199, 187);
            this.txtPfAge.MaxLength = 2;
            this.txtPfAge.Name = "txtPfAge";
            this.txtPfAge.NumericStyle = TextBoxX.TextBoxX.Style.SignedInteger;
            this.txtPfAge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPfAge.Size = new System.Drawing.Size(33, 20);
            this.txtPfAge.TabIndex = 3;
            // 
            // Config_RetirementDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(284, 259);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPfAge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPenssionAge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "Configure Retirement Details";
            this.Name = "Config_RetirementDetails";
            this.Load += new System.EventHandler(this.Config_RetirementDetails_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtAge, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnSubmit, 0);
            this.Controls.SetChildIndex(this.cmbYear, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPenssionAge, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtPfAge, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private TextBoxX.TextBoxX txtAge;
        private EDPComponent.VistaButton btnCancel;
        private EDPComponent.VistaButton btnExit;
        private System.Windows.Forms.Label label2;
        private EDPComponent.VistaButton btnSubmit;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label3;
        private TextBoxX.TextBoxX txtPenssionAge;
        private System.Windows.Forms.CheckBox chkTillDate;
        private System.Windows.Forms.CheckBox chkFullMonth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private TextBoxX.TextBoxX txtPfAge;
    }
}