namespace PayRollManagementSystem
{
    partial class frmDbBack_Path
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDbBack_Path));
            this.btn_Save_Path = new EDPComponent.VistaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccordDir = new EDPComponent.VistaButton();
            this.txtAccordDir = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmbCompanyName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRecordCounter = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.PB1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btn_Save_Path
            // 
            this.btn_Save_Path.BackColor = System.Drawing.Color.Transparent;
            this.btn_Save_Path.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Save_Path.ButtonText = "   Save Path";
            this.btn_Save_Path.CornerRadius = 4;
            this.btn_Save_Path.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save_Path.GlowColor = System.Drawing.Color.White;
            this.btn_Save_Path.ImageSize = new System.Drawing.Size(16, 16);
            this.btn_Save_Path.Location = new System.Drawing.Point(283, 50);
            this.btn_Save_Path.Name = "btn_Save_Path";
            this.btn_Save_Path.Size = new System.Drawing.Size(94, 30);
            this.btn_Save_Path.TabIndex = 89;
            this.btn_Save_Path.Click += new System.EventHandler(this.btn_Save_Path_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "Bravo Directory";
            // 
            // btnAccordDir
            // 
            this.btnAccordDir.BackColor = System.Drawing.Color.Transparent;
            this.btnAccordDir.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnAccordDir.ButtonText = "";
            this.btnAccordDir.CornerRadius = 4;
            this.btnAccordDir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccordDir.GlowColor = System.Drawing.Color.White;
            this.btnAccordDir.Image = global::PayRollManagementSystem.Properties.Resources._41;
            this.btnAccordDir.ImageSize = new System.Drawing.Size(16, 16);
            this.btnAccordDir.Location = new System.Drawing.Point(383, 25);
            this.btnAccordDir.Name = "btnAccordDir";
            this.btnAccordDir.Size = new System.Drawing.Size(31, 20);
            this.btnAccordDir.TabIndex = 88;
            this.btnAccordDir.Click += new System.EventHandler(this.btnAccordDir_Click);
            // 
            // txtAccordDir
            // 
            this.txtAccordDir.Location = new System.Drawing.Point(141, 25);
            this.txtAccordDir.Name = "txtAccordDir";
            this.txtAccordDir.ReadOnly = true;
            this.txtAccordDir.Size = new System.Drawing.Size(236, 20);
            this.txtAccordDir.TabIndex = 87;
            // 
            // cmbCompanyName
            // 
            this.cmbCompanyName.FormattingEnabled = true;
            this.cmbCompanyName.Location = new System.Drawing.Point(141, 100);
            this.cmbCompanyName.Name = "cmbCompanyName";
            this.cmbCompanyName.Size = new System.Drawing.Size(236, 21);
            this.cmbCompanyName.TabIndex = 91;
            this.cmbCompanyName.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 90;
            this.label4.Text = "Company Name";
            this.label4.Visible = false;
            // 
            // lblRecordCounter
            // 
            this.lblRecordCounter.AutoSize = true;
            this.lblRecordCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRecordCounter.Location = new System.Drawing.Point(226, 56);
            this.lblRecordCounter.Name = "lblRecordCounter";
            this.lblRecordCounter.Size = new System.Drawing.Size(2, 15);
            this.lblRecordCounter.TabIndex = 92;
            this.lblRecordCounter.Visible = false;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRecord.Location = new System.Drawing.Point(179, 56);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(2, 15);
            this.lblRecord.TabIndex = 92;
            this.lblRecord.Visible = false;
            // 
            // PB1
            // 
            this.PB1.Location = new System.Drawing.Point(39, 84);
            this.PB1.Name = "PB1";
            this.PB1.Size = new System.Drawing.Size(338, 10);
            this.PB1.TabIndex = 93;
            // 
            // frmDbBack_Path
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(457, 123);
            this.Controls.Add(this.PB1);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.lblRecordCounter);
            this.Controls.Add(this.cmbCompanyName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Save_Path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccordDir);
            this.Controls.Add(this.txtAccordDir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDbBack_Path";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Db Backup Path";
            this.Load += new System.EventHandler(this.frmDbBack_Path_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.VistaButton btn_Save_Path;
        private System.Windows.Forms.Label label1;
        private EDPComponent.VistaButton btnAccordDir;
        private System.Windows.Forms.TextBox txtAccordDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cmbCompanyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRecordCounter;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.ProgressBar PB1;
    }
}