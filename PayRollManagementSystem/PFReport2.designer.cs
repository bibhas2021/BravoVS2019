namespace PayRollManagementSystem
{
    partial class PFReport2
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
            this.label1 = new System.Windows.Forms.Label();
            this.SaveCmd = new EDPComponent.VistaButton();
            this.ConsolMonthdttmpkr = new System.Windows.Forms.DateTimePicker();
            this.ConsolGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ConsolGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Select Month-Year";
            // 
            // SaveCmd
            // 
            this.SaveCmd.BackColor = System.Drawing.Color.Transparent;
            this.SaveCmd.ButtonColor = System.Drawing.Color.DimGray;
            this.SaveCmd.ButtonText = "Extract";
            this.SaveCmd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveCmd.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SaveCmd.Location = new System.Drawing.Point(772, 41);
            this.SaveCmd.Name = "SaveCmd";
            this.SaveCmd.Size = new System.Drawing.Size(109, 28);
            this.SaveCmd.TabIndex = 46;
            this.SaveCmd.Click += new System.EventHandler(this.SaveCmd_Click);
            // 
            // ConsolMonthdttmpkr
            // 
            this.ConsolMonthdttmpkr.CustomFormat = "MMMM - yyyy";
            this.ConsolMonthdttmpkr.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsolMonthdttmpkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ConsolMonthdttmpkr.Location = new System.Drawing.Point(114, 43);
            this.ConsolMonthdttmpkr.Name = "ConsolMonthdttmpkr";
            this.ConsolMonthdttmpkr.ShowUpDown = true;
            this.ConsolMonthdttmpkr.Size = new System.Drawing.Size(152, 21);
            this.ConsolMonthdttmpkr.TabIndex = 47;
            // 
            // ConsolGrid
            // 
            this.ConsolGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsolGrid.Location = new System.Drawing.Point(4, 75);
            this.ConsolGrid.Name = "ConsolGrid";
            this.ConsolGrid.Size = new System.Drawing.Size(918, 445);
            this.ConsolGrid.TabIndex = 48;
            // 
            // PFReport2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 523);
            this.Controls.Add(this.ConsolGrid);
            this.Controls.Add(this.ConsolMonthdttmpkr);
            this.Controls.Add(this.SaveCmd);
            this.Controls.Add(this.label1);
            this.Name = "PFReport2";
            this.Text = "PFReport2";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.SaveCmd, 0);
            this.Controls.SetChildIndex(this.ConsolMonthdttmpkr, 0);
            this.Controls.SetChildIndex(this.ConsolGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ConsolGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private EDPComponent.VistaButton SaveCmd;
        private System.Windows.Forms.DateTimePicker ConsolMonthdttmpkr;
        private System.Windows.Forms.DataGridView ConsolGrid;
    }
}