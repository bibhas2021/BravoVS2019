namespace PayRollManagementSystem
{
    partial class REPORTOFPF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORTOFPF));
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EmplistPf = new System.Windows.Forms.Button();
            this.LABEL2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCID = new System.Windows.Forms.ComboBox();
            this.cmbLID = new System.Windows.Forms.ComboBox();
            this.EmpListEsi = new System.Windows.Forms.Button();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.CmbLocation = new EDPComponent.ComboDialog();
            this.SuspendLayout();
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(291, 12);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbMonth.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "MONTH";
            // 
            // EmplistPf
            // 
            this.EmplistPf.Location = new System.Drawing.Point(72, 106);
            this.EmplistPf.Name = "EmplistPf";
            this.EmplistPf.Size = new System.Drawing.Size(133, 23);
            this.EmplistPf.TabIndex = 4;
            this.EmplistPf.Text = "EMPLOYEE LIST PF";
            this.EmplistPf.UseVisualStyleBackColor = true;
            this.EmplistPf.Click += new System.EventHandler(this.button1_Click);
            // 
            // LABEL2
            // 
            this.LABEL2.AutoSize = true;
            this.LABEL2.Location = new System.Drawing.Point(6, 69);
            this.LABEL2.Name = "LABEL2";
            this.LABEL2.Size = new System.Drawing.Size(61, 13);
            this.LABEL2.TabIndex = 5;
            this.LABEL2.Text = "LOCATION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "COMPANY";
            // 
            // cmbSession
            // 
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(72, 12);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(121, 21);
            this.cmbSession.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "SESSION";
            // 
            // cmbCID
            // 
            this.cmbCID.FormattingEnabled = true;
            this.cmbCID.Location = new System.Drawing.Point(418, 39);
            this.cmbCID.Name = "cmbCID";
            this.cmbCID.Size = new System.Drawing.Size(41, 21);
            this.cmbCID.TabIndex = 10;
            this.cmbCID.TabStop = false;
            this.cmbCID.Visible = false;
            // 
            // cmbLID
            // 
            this.cmbLID.FormattingEnabled = true;
            this.cmbLID.Location = new System.Drawing.Point(418, 69);
            this.cmbLID.Name = "cmbLID";
            this.cmbLID.Size = new System.Drawing.Size(41, 21);
            this.cmbLID.TabIndex = 11;
            this.cmbLID.TabStop = false;
            this.cmbLID.Visible = false;
            // 
            // EmpListEsi
            // 
            this.EmpListEsi.Location = new System.Drawing.Point(211, 106);
            this.EmpListEsi.Name = "EmpListEsi";
            this.EmpListEsi.Size = new System.Drawing.Size(131, 23);
            this.EmpListEsi.TabIndex = 12;
            this.EmpListEsi.Text = "EMPLOYEE LIST ESI";
            this.EmpListEsi.UseVisualStyleBackColor = true;
            this.EmpListEsi.Click += new System.EventHandler(this.EmpListEsi_Click);
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(72, 39);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(339, 21);
            this.CmbCompany.TabIndex = 310;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_DropDown_Closeup);
            // 
            // CmbLocation
            // 
            this.CmbLocation.Connection = null;
            this.CmbLocation.DialogResult = "";
            this.CmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLocation.Location = new System.Drawing.Point(72, 69);
            this.CmbLocation.LOVFlag = 0;
            this.CmbLocation.MaxCharLength = 500;
            this.CmbLocation.Name = "CmbLocation";
            this.CmbLocation.ReturnIndex = -1;
            this.CmbLocation.ReturnValue = "";
            this.CmbLocation.ReturnValue_3rd = "";
            this.CmbLocation.ReturnValue_4th = "";
            this.CmbLocation.Size = new System.Drawing.Size(339, 21);
            this.CmbLocation.TabIndex = 311;
            this.CmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbLocation_DropDown);
            this.CmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbLocation_DropDown_Closeup);
            // 
            // REPORTOFPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(471, 161);
            this.Controls.Add(this.CmbLocation);
            this.Controls.Add(this.CmbCompany);
            this.Controls.Add(this.EmpListEsi);
            this.Controls.Add(this.cmbLID);
            this.Controls.Add(this.cmbCID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LABEL2);
            this.Controls.Add(this.EmplistPf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMonth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "REPORTOFPF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORT PF ESI";
            this.Load += new System.EventHandler(this.REPORTOFPF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EmplistPf;
        private System.Windows.Forms.Label LABEL2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCID;
        private System.Windows.Forms.ComboBox cmbLID;
        private System.Windows.Forms.Button EmpListEsi;
        private EDPComponent.ComboDialog CmbCompany;
        private EDPComponent.ComboDialog CmbLocation;
    }
}