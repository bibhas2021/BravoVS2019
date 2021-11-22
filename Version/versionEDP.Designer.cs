namespace EDPVersion
{
    partial class versionEDP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(versionEDP));
            this.prbVersion = new System.Windows.Forms.ProgressBar();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prbVersion
            // 
            this.prbVersion.Location = new System.Drawing.Point(12, 113);
            this.prbVersion.MarqueeAnimationSpeed = 50;
            this.prbVersion.Name = "prbVersion";
            this.prbVersion.Size = new System.Drawing.Size(384, 23);
            this.prbVersion.Step = 1;
            this.prbVersion.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Gold;
            this.lblVersion.Location = new System.Drawing.Point(9, 9);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(387, 68);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Click += new System.EventHandler(this.lblVersion_Click);
            // 
            // lblPath
            // 
            this.lblPath.Location = new System.Drawing.Point(12, 86);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(384, 24);
            this.lblPath.TabIndex = 2;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(76, 73);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(35, 13);
            this.lblCountry.TabIndex = 3;
            this.lblCountry.Text = "label1";
            this.lblCountry.Visible = false;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(118, 51);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(35, 13);
            this.lblCity.TabIndex = 4;
            this.lblCity.Text = "label2";
            this.lblCity.Visible = false;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(37, 51);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 5;
            this.lblState.Text = "label3";
            // 
            // versionEDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 148);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.prbVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "versionEDP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Version";
            this.Load += new System.EventHandler(this.versionEDP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prbVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblState;
    }
}

