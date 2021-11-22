namespace PayRollManagementSystem
{
    partial class frmSearch_by_Aadhar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch_by_Aadhar));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new EDPComponent.VistaButton();
            this.txtAadharNo = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Aadhar Number";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.ButtonText = " Search";
            this.btnSearch.CornerRadius = 4;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ImageSize = new System.Drawing.Size(16, 16);
            this.btnSearch.Location = new System.Drawing.Point(224, 76);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAadharNo
            // 
            this.txtAadharNo.BackColor = System.Drawing.Color.White;
            this.txtAadharNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAadharNo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAadharNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtAadharNo.Location = new System.Drawing.Point(29, 45);
            this.txtAadharNo.Mask = "0000 0000 0000";
            this.txtAadharNo.Name = "txtAadharNo";
            this.txtAadharNo.Size = new System.Drawing.Size(292, 22);
            this.txtAadharNo.TabIndex = 0;
            // 
            // frmSearch_by_Aadhar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(344, 129);
            this.Controls.Add(this.txtAadharNo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearch_by_Aadhar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search by Aadhar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private EDPComponent.VistaButton btnSearch;
        private System.Windows.Forms.MaskedTextBox txtAadharNo;
    }
}