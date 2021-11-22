namespace PayRollManagementSystem
{
    partial class PFReport3
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
            this.PFRepDtGridv = new System.Windows.Forms.DataGridView();
            this.SeasonCombo = new System.Windows.Forms.ComboBox();
            this.Monthcombo = new System.Windows.Forms.ComboBox();
            this.SaveCmd = new EDPComponent.VistaButton();
            ((System.ComponentModel.ISupportInitialize)(this.PFRepDtGridv)).BeginInit();
            this.SuspendLayout();
            // 
            // PFRepDtGridv
            // 
            this.PFRepDtGridv.AllowUserToAddRows = false;
            this.PFRepDtGridv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PFRepDtGridv.Location = new System.Drawing.Point(2, 60);
            this.PFRepDtGridv.Name = "PFRepDtGridv";
            this.PFRepDtGridv.RowHeadersVisible = false;
            this.PFRepDtGridv.Size = new System.Drawing.Size(943, 430);
            this.PFRepDtGridv.TabIndex = 42;
            // 
            // SeasonCombo
            // 
            this.SeasonCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SeasonCombo.FormattingEnabled = true;
            this.SeasonCombo.Location = new System.Drawing.Point(183, 33);
            this.SeasonCombo.Name = "SeasonCombo";
            this.SeasonCombo.Size = new System.Drawing.Size(131, 21);
            this.SeasonCombo.TabIndex = 44;
            // 
            // Monthcombo
            // 
            this.Monthcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Monthcombo.FormattingEnabled = true;
            this.Monthcombo.Location = new System.Drawing.Point(12, 33);
            this.Monthcombo.Name = "Monthcombo";
            this.Monthcombo.Size = new System.Drawing.Size(165, 21);
            this.Monthcombo.TabIndex = 44;
            // 
            // SaveCmd
            // 
            this.SaveCmd.BackColor = System.Drawing.Color.Transparent;
            this.SaveCmd.ButtonColor = System.Drawing.Color.DimGray;
            this.SaveCmd.ButtonText = "Extract";
            this.SaveCmd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveCmd.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SaveCmd.Location = new System.Drawing.Point(813, 30);
            this.SaveCmd.Name = "SaveCmd";
            this.SaveCmd.Size = new System.Drawing.Size(109, 28);
            this.SaveCmd.TabIndex = 47;
            this.SaveCmd.Click += new System.EventHandler(this.Extractcmd_Click);
            // 
            // PFReport3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 491);
            this.Controls.Add(this.SaveCmd);
            this.Controls.Add(this.Monthcombo);
            this.Controls.Add(this.SeasonCombo);
            this.Controls.Add(this.PFRepDtGridv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PFReport3";
            this.Load += new System.EventHandler(this.PFReport3_Load);
            this.Controls.SetChildIndex(this.PFRepDtGridv, 0);
            this.Controls.SetChildIndex(this.SeasonCombo, 0);
            this.Controls.SetChildIndex(this.Monthcombo, 0);
            this.Controls.SetChildIndex(this.SaveCmd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PFRepDtGridv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PFRepDtGridv;
        private System.Windows.Forms.ComboBox SeasonCombo;
        private System.Windows.Forms.ComboBox Monthcombo;
        private EDPComponent.VistaButton SaveCmd;
    }
}