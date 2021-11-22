namespace PayRollManagementSystem
{
    partial class PFLoanRegister
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PFGrid = new EDPMyComponent.PrintGridView(this.components);
            this.Ppulatecms = new EDPComponent.VistaButton();
            this.Printcmd = new EDPComponent.VistaButton();
            ((System.ComponentModel.ISupportInitialize)(this.PFGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PFGrid
            // 
            this.PFGrid.AllowUserToAddRows = false;
            this.PFGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PFGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.PFGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PFGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.PFGrid.Location = new System.Drawing.Point(7, 54);
            this.PFGrid.Name = "PFGrid";
            this.PFGrid.Size = new System.Drawing.Size(814, 453);
            this.PFGrid.TabIndex = 0;
            // 
            // Ppulatecms
            // 
            this.Ppulatecms.BackColor = System.Drawing.Color.Transparent;
            this.Ppulatecms.ButtonText = "Populate P.F. Register";
            this.Ppulatecms.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ppulatecms.Location = new System.Drawing.Point(12, 27);
            this.Ppulatecms.Name = "Ppulatecms";
            this.Ppulatecms.Size = new System.Drawing.Size(158, 26);
            this.Ppulatecms.TabIndex = 1;
            this.Ppulatecms.Click += new System.EventHandler(this.button1_Click);
            // 
            // Printcmd
            // 
            this.Printcmd.BackColor = System.Drawing.Color.Transparent;
            this.Printcmd.ButtonText = "Print";
            this.Printcmd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Printcmd.Location = new System.Drawing.Point(173, 27);
            this.Printcmd.Name = "Printcmd";
            this.Printcmd.Size = new System.Drawing.Size(80, 26);
            this.Printcmd.TabIndex = 2;
            this.Printcmd.Click += new System.EventHandler(this.button2_Click);
            // 
            // PFLoanRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 510);
            this.Controls.Add(this.PFGrid);
            this.Controls.Add(this.Ppulatecms);
            this.Controls.Add(this.Printcmd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HeaderText = "P.F. Register";
            this.Name = "PFLoanRegister";
            this.ShowMin = true;
            this.Text = "PFLoanRegister";
            this.Load += new System.EventHandler(this.PFLoanRegister_Load);
            this.Controls.SetChildIndex(this.Printcmd, 0);
            this.Controls.SetChildIndex(this.Ppulatecms, 0);
            this.Controls.SetChildIndex(this.PFGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PFGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPMyComponent.PrintGridView PFGrid;
        private EDPComponent.VistaButton Ppulatecms;
        private EDPComponent.VistaButton Printcmd;

    }
}